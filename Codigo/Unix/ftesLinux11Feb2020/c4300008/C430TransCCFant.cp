/* DESCRIPCION	: Permite la generacion del archivo CCF (Diario / Por Corte) */
/* PARAMETROS 	:                                                            */
/*    argv[1] = Usuario de Base De Datos                                     */
/*    argv[2] = Password de Base de Datos                                    */
/*    argv[3] = Servidor donde se encuentra la Base de Datos                 */
/*    argv[4] = Tipo de archivo(s) a generar:                                */
/*                 0 - Diario.                                               */
/*                 1 - Por Corte.                                            */
/*    argv[5] = Modo de generacion de archivo:                               */
/*                 0 - Todas las empresas.                                   */
/*                 1 - Por empresa.                                          */
/*    argv[6] = Nombre del archivo donde seran concentrados los registros    */
/*              recuperados.                                                 */
/*    argv[7] = Clave de Prefijo de Ejecutivo (Opcional).                    */
/*    argv[8] = Clave de Grupo de Banco (Opcional).                          */
/*    argv[9] = Clave de la Empresa (Opcional).                              */ 
/*    argv[10] = Fecha de Procesamiento (Opcional).                          */
/* SALIDAS      : Archivo CCF Diario / Archivo CCF por Corte.                */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 26/06/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     26/06/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón	      12/12/2004     Se agregan campos en    */
/*						     algunas tablas para     */
/*						     soportar caracteres     */
/*						     japoneses (kanjis)      */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h> /*agrego yuria 09102005*/
#include "C430FechaRFC.h"
#include "C430TransCCF.h"
#include "C430Pais.h" /*agrego  yuria 09102005*/

EXEC SQL INCLUDE SQLCA;

#if defined(__STDC__) || defined(__cplusplus)
int main(int argc, char *argv[])             
#else                                        
int main(argc, argv)                         
int argc;                                    
char *argv[];                                
#endif                                       
{
   EXEC SQL BEGIN DECLARE SECTION;
      char sUsername[LEN30+1];	 /* Usuario. */
      char sPassword[LEN30+1];   /* Password. */
      char sServer[LEN30+1];     /* Servidor. */

   EXEC SQL END DECLARE SECTION;

   /* El No. de Parametros pasados a la aplicacion es incorrecto. */

   if(!((argc == 7) || (argc == 10) || (argc == 11)))   
   {
      printf("\nUse: C430TransCCF <User> <Password> <Server>\n");
      printf("                  <File Type> <File Mode> <File Name>\n");
      printf("                  [<Preffix> <Bank Group> <Company ID> <Process Date>]\n");
      exit(ERREXIT);
   }

   /* Definicion de rutinas para manejo de errores y mensajes de
      alerta. */

   EXEC SQL WHENEVER SQLERROR CALL error_handler();
   EXEC SQL WHENEVER SQLWARNING CALL warning_handler();
   EXEC SQL WHENEVER NOT FOUND CONTINUE;

   strcpy(sUsername, argv[1]);
   strcpy(sPassword, argv[2]);
   strcpy(sServer, argv[3]);

   /* Conexion al servidor de SYBASE. */

   EXEC SQL CONNECT :sUsername IDENTIFIED BY :sPassword USING :sServer;

   /* Cambio a Base de Datos Sistema Tarjeta Corporativa. */

   EXEC SQL USE M111;    

   /* Recuperacion de datos para formato CCF. */

   iC430GetData_CCF(argv);

   EXEC SQL COMMIT WORK;

   EXEC SQL DISCONNECT ALL;

   exit(STDEXIT);
}

/* NOMBRE       : iC430GetData_CCF                                           */
/* DESCRIPCION	: Genera los registros necesarios para la construccion del   */
/*                archivo CCF                                                */
/* PARAMETROS 	:                                                            */
/*    psParams[4] = Tipo de archivo(s) a generar:                            */
/*                 0 - Diario.                                               */
/*                 1 - Por Corte.                                            */
/*    psParams[5] = Modo de generacion de archivo:                           */
/*                 0 - Todas las empresas.                                   */
/*                 1 - Por empresa.                                          */
/*    psParams[6] = Nombre del archivo donde seran concentrados los          */
/*                  registros recuperados.                                   */
/*    psParams[7] = Clave de Prefijo de Ejecutivo (Opcional).                */
/*    psParams[8] = Clave de Grupo de Banco (Opcional).                      */
/*    psParams[9] = Clave de la Empresa (Opcional).                          */ 
/*    psParams[10] = Fecha de Procesamiento (Opcional).                      */
/* SALIDAS      : Estatus de conclusion de la rutina:                        */
/*                0 - Exito.                                                 */
/*                1 - Falla.                                                 */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 26/06/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     26/06/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
int iC430GetData_CCF(char *psParams[])             
#else                                        
int iC430GetData_CCF(psParams)                         
char *psParams[];                                
#endif                                       
{
   EXEC SQL BEGIN DECLARE SECTION;

      /* Datos de Empresa. */

      int  iPreffix;		     /* Prefijo del Ejecutivo. */
      int  iBankGroup;               /* No. de Grupo del Banco. */
      int  iCompanyID;               /* Identificador de la Empresa. */
      char sFmtCompanyID[LEN6+1];    /* Identificador de la Empresa (con formato). */
      char sCompanyName[LEN45+1];    /* Nombre de la Empresa. */
      int  iChargeOffDate;           /* Fecha de Corte (Dia). */
      int  iFileType;                /* Tipo de archivo. */ 
      char sBillType[LEN1+1];        /* Tipo de Facturacion. */
      int  iGenPla;
      int  iPayDate;                 /* Fecha de Pago (Dia). */
      char sPayDueDate[LEN8+1];      /* Fecha Limite de Pago asignada al Tarjetahabiente. */
      int  iNumCompanies;            /* No. Total de Empresas a Procesar. */

      /* Datos de Tarjetahabiente. */
 
      char  sCardHRating[LEN1+1];   /* Situacion de cuenta del Tarjetahabiente. */
      int   iCardHLastPayDate;      /* Ultima Fecha de Pago del Tarjetahabiente. */
      double dCardHPayAmtDue;       /* Minimo a Pagar por parte del Tarjetahabiente. */
      double dCardHChargeOffBal;    /* Saldo Maximo del Tarjetahabiente. */
      double dCardHPreviewBal;      /* Saldo Anterior del Tarjetahabiente. */
      double dCardHCurrBal;         /* Saldo Actual del Tarjetahabiente. */
      int   iCardHRollOver;         /* Digito RollOver del Tarjetahabiente. */
      int   iCardHDigit;            /* Digito Verificador del Tarjetahabiente. */
      int   iNumCardHolders;        /* No. Total de Tarjetahabientes a Procesar. */
      int   iCardPRollOver;         /* Roll Over de la Cuenta Padre */ 
      int   iCardPDigit;            /* Digito Verificador de la cuenta Padre */

      /* Datos del Plastico (Tarjeta de Credito). */

      int  iPlaValidSince;            /* Fecha de Apertura Tarjeta de Credito. */ 
      char sPlaTransStatus[LEN1+1];   /* Situacion Actual de Tarjeta de Credito. */
      int  iPlaRollOver;              /* Digito RollOver asociado al Plastico. */   
      int  iPlaDigit;                 /* Digito Verificador asociado al Plastico. */
      char sAccType[LEN1+1];          /* Tipo de Cuenta E para Corporativa papa */

      /* Datos del Encabezado de Historico de Transacciones. */

      double dHihCurrBalance;    /* Saldo Actual del Tarjetahabiente. */
      double dHihPrevBalance;    /* Saldo Anterior del Tarjetahabiente. */

      /* Datos de Unidades. */

      char sUniUnitID[LEN15+1];     /* Identificador de Unidad. */
      char sUniUnitFID[LEN15+1];
      char sUniUnitPID[LEN15+1];    /* Identificador de Unidad Padre. */
      char sUnitPPID[LEN15+1];      /* Identificador de Unidad Padre. */
      char sUnitPCN[ LEN23 + 1 ];   /* SUstituto del nodo padre en nivel 0*/ 
      char sUniUnitName[LEN40+1];   /* Nombre de la Unidad. */
      int  iUniLevelNum;            /* Identificador de Nivel de la Unidad. */
      int  iNumUnits;               /* No. Total de Unidades por Empresa. */

      /* Datos de Ejecutivo. */

      int  iExeExeNum;               /* No. de Ejecutivo del Tarjetahabiente. */
      char sFmtExeExeNum[LEN6+1];    /* No. de Ejecutivo del Tarj. (con formato). */
      char sFmtExeExePNum[LEN6+1];   /*No. de Ejecutivo del Padre. (con formato)  */
      char sExeName[LEN45+1];        /* Nombre del Tarjetahabiente. */
      char sExeAddress1[LEN35+1];    /* Direccion del Tarjetahabiente (Parte 1). */
      char sExeAddress2[LEN25+1];    /* Direccion del Tarjetahabiente (Parte 2). */
      char sExeCity[LEN25+1];        /* Ciudad de Origen del Tarjetahabiente. */
      char sExeState[LEN4+1];        /* Estado de Origen del Tarjetahabiente. */
      int  iExePostalCode;           /* Codigo Postal del Tarjetahabiente. */
      char sExeTelNumber[LEN10+1];   /* Telefono Particular del Tarjetahabiente. */
      char sExeOfficeNum[LEN10+1];   /* Tel. Oficina del Tarjetahabiente. */  
      char sExeFaxNum[LEN15+1];      /* Numero de Fax del Tarjetahabiente. */
      char sExeRFC[LEN13+1];         /* RFC del Tarjetahabiente. */
      char sExeEmail[LEN70+1];       /* Email del Tarjetahabiente. */
      char sExeEmpNum[LEN15+1];      /* Numero de Empleado del Tarjetahabiente. */
      char sExeMAccCode[LEN40+1];    /* Codigo Cuenta Contable Tarjetahabiente. */
      int  iExeOpenDate;             /* Fecha de Apertura Cuenta Tarjetahab. */
      int  iExeCredLim;              /* Limite de Credito del Tarjetahabiente. */
      char sExeEmbName[LEN26+1];     /* Nombre Grabado en Plastico Tarjetahab. */
      int  iExeLastMaintDate;        /* Fecha Ultimo Mov. Tarjetahabiente. */
      int  iExePerCashLim;           /* Porcentaje de Disposicion de Efectivo
                                        permitido al Tarjetahabiente. */
      int  iNumExecutives;           /* No. Total de Ejecutivos por Unidad. */ 

      /* Datos de Historico de Transacciones. */

      int  iHisTransDate;              /* Fecha de la Transaccion. */
      int  iHisTransTime;              /* Hora de la Transaccion. */
      int  iHisPostDate;               /* Fecha de Procesamiento de la Transaccion. */
      double dHisTransAmount;          /* Monto de la Transaccion. */
      int  iHisReference1;             /* Numero Referencia Transaccion (Parte 1). */
      double dHisReference2;           /* Numero Referencia Transaccion (Parte 2). */
      int  iHisTransID;                /* Clave de la Transaccion. */
      int  iCodeSBF;
      int  iHisTransIDSBF;
      int  iHisMerchAcepID;            /* Clave del Negocio Generador de la Trans. */
      char sHisMerchDesc[LEN26+1];     /* Nombre del Negocio Generador de la Trans. */
      char sHisMerchStaPro[LEN14+1];   /* Poblacion donde fue generada la Trans. */
      char sHisMerchCountry[LEN3+1];   /* Pais donde fue generada la Trans. */

      double dHisDollars;              /* Monto en Dolares de la Trans. */
      
      char  sHisRefNumber[LEN23+1];    /* Numero de Referencia de la Trans. */

      int  iNumTransactions;           /* No. Total de Transacciones por 
                                          Tarjetahabiente. */

      /* Datos de Estado. */

      char sStateName[LEN40+1];   /* Nombre de Estado de la Republica. */

      /* Datos del Negocio. */

      int  iEntMCC;                /* Codigo MCC del Negocio. */
      char sEntDescMCC[LEN30+1];   /* Descripcion del Codigo MCC. */
      char sEntName[LEN36+1];      /* Nombre del Negocio. */
      char sNomNegocio[LEN36+1];   /* Nombre del Negocio sin  espacios*/
      int  i,n;

      /* Datos de Transacciones en Aerolineas. */

      double dAirTotFareAmt;               /* Costo Total del Boleto. */
      double dAirTotTaxAmt;                /* Monto Total de Impuestos. */
      double dAirNatTaxAmt;                /* Monto de Impuesto Nacional. */
      double dAirTotFeeAmt;                /* Monto Total de Cargos. */
      char  sAirTicketNum[LEN15+1];        /* Numero de Boleto. */
      char  sAirExchgTicketNum[LEN13+1];   /* Num. de Boleto de Intercambio. */
      char  sAirExchgTicketAmt[LEN12+1];   /* Monto de Boleto de Intercambio. */
      char  sAirTraAgenCode[LEN8+1];       /* Clave de Agencia de Viajes. */
      char  sAirTraAgenName[LEN25+1];      /* Nombre de Agencia de Viajes. */
      char  sAirPassName[LEN20+1];         /* Nombre del Pasajero. */
      int   iAirDepartDate;                /* Fecha de Salida del Vuelo. */
      char  sAirDepartDate[LEN8+1];        /* Fecha Salida Vuelo (Cadena). */
      char  sAirOrigCode[LEN3+1];          /* Codigo de Origen. */
      char  sAirInternetInd[LEN1+1];       /* Indicador Compra por Internet. */
      char  sAirElectTicketNum[LEN1+1];    /* Num. de Boleto Electronico. */
      int   iNumAirlineTran;               /* No. Total de Transacciones de 
                                              Gastos de Aerolineas. */
      
      /* Datos de Escalas asociadas a un Vuelo. */

      char sScaStopOver[LEN1+1];    /* Bandera de Definicion de Escala. */
      char sScaDest[LEN5+1];        /* Clave de Destino del Vuelo. */ 
      char sScaCarrCode[LEN2+1];    /* Clave de Empresa Transportadora. */
      char sScaServClass[LEN1+1];   /* Clave de Tipo de Servicio. */
      char sScaFlightNum[LEN5+1];   /* Numero de Vuelo. */ 
      int  iNumScales;              /* No. Total de Escalas asociadas a
                                       un grupo de Vuelos. */

      /* Datos de Transacciones de Compras. */

      int   iPurDetSeqNum;              /* Num. Secuencial de Detalle Compra. */
      int   iPurOrderDate;              /* Fecha de Solicitud del Producto. */
      char  sPurDestZipCode[LEN10+1];   /* Codigo Postal Destino Compra. */
      char  sPurDestCountry[LEN3+1];    /* Pais Destino Compra (Clave). */
      char  sPurOrigZipCode[LEN10+1];   /* Codigo Postal Origen Compra. */
      double dPurFreightAmt;            /* Monto de la Compra. */ 
      double dPurFreightVATTaxAmt;      /* Impuesto Total sobre la Compra. */
      double dPurFreightVATTaxRat;      /* Porcentaje de Impuesto Compra. */
      char  sPurCommCode[LEN15+1];      /* Codigo de Compra. */
      char  sPurDescription[LEN35+1];   /* Descripcion del Producto. */
      char  sPurProductCode[LEN12+1];   /* Codigo de Producto. */
      double dPurQuantity;              /* Cantidad de Producto. */
      char  sPurUnitMeasure[LEN12+1];   /* Unidad de Medida Producto. */
      double dPurUnitCost;              /* Costo Unitario. */
      double dPurVATTaxAmt;             /* Impuesto sobre el Producto. */
      double dPurVATTaxRat;             /* Porcentaje de Impuesto Producto. */
      char  sPurVATInvRefNum[LEN15+1];  /* Clave de Identificacion Impuesto. */
      double dPurDiscPerItem;           /* Descuento Unitario a Producto. */
      double dPurLineItemTot;           /* Costo Total Unitario de Producto. */
      int   iNumPurchasingTran;         /* No. Total de Transacciones de 
                                           Gastos por Compras. */

      /* Datos de Transacciones de Hospedaje. */

      int  iLodDetSeqNum;                /* Num. Secuencial de Detalle Hospedaje. */
      char sLodPropTelNumber[LEN10+1];   /* Num. Tel. del Hotel. */
      char sLodCustTelNumber[LEN10+1];   /* Num. Tel. Serv. a Clientes. */
      int  iLodCheckInDate;              /* Fecha de Ingreso. */
      int  iLodCheckOutDate;             /* Fecha de Salida. */
      char sLodNoShowInd[LEN1+1];        /* Indicador No-Show. */
      double dLodTotAutAmt;              /* Monto Total Hospedaje. */
      double dLodPrepaidExp;             /* Gastos Prepagados. */
      int  iLodNumRoomNights;            /* Num. de Cuartos. */
      double dLodDayRoomRate;            /* Tarifa Diaria del Cuarto. */
      double dLodVATTaxAmt;              /* Monto de Impuesto. */
      double dLodVATTaxRate;             /* Porcentaje de Impuesto. */
      double dLodRoomTaxAmt;             /* Impuesto sobre el Cuarto. */
      char  sLodVATInvRefNum[LEN15+1];   /* Clave de Identificacion Impuesto. */
      double dLodDiscAmt;                /* Monto de Descuento. */
      double dLodFoodBevCharges;         /* Cargos por Comida y Bebida. */
      double dLodCashAdv;                /* Cargos por Propinas. */
      double dLodValParkCharges;         /* Cargos por Valet Parking. */
      double dLodMiniBarCharges;         /* Cargos por Consumo Minibar. */
      double dLodLaundryCharges;         /* Cargos por Lavanderia. */
      double dLodPhoneCharges;           /* Cargos por Serv. Telefonico. */
      double dLodGiftShopCharges;        /* Cargos por Tienda de Regalos. */
      double dLodMovieCharges;           /* Cargos por Peliculas. */
      double dLodBusCentCharges;         /* Cargos por Centro de Negocios. */
      double dLodHeaClubCharges;         /* Cargos por Uso de Gimnasio. */
      double dLodOtherCharges;           /* Otros Cargos. */
      double dLodTotNonRoomCharges;      /* Importe Total Cargos Diversos. */
      int   iNumLodgingTran;             /* No. Total de Transacciones de 
                                            Gastos por Hospedaje. */

      /* Datos de Transacciones de Renta de Auto(s). */

      int  iCarDetSeqNum;               /* Num. Secuencial de Detalle Renta. */
      char sCarRentAgreeNum[LEN25+1];   /* No. de Contrato de Renta. */
      char sCarRentName[LEN40+1];       /* Nombre del Arrendatario. */
      char sCarRetCity[LEN25+1];        /* Ciudad de Retorno del Auto. */
      char sCarRetStaCtry[LEN3+1];      /* Estado/Pais de Retorno del Auto. */ 
      char sCarClassCode[LEN2+1];       /* Codigo de Tipo de Auto. */
      char sCarNoShowInd[LEN1+1];       /* Indicador No-Show. */
      int  iCarCheckOutDate;            /* Fecha de Salida del Auto. */
      int  iCarCheckInDate;             /* Fecha de Regreso del Auto. */
      char sCarInsInd[LEN1+1];          /* Indicador de Auto Asegurado. */
      double dCarInsCharges;            /* Cargos aplicados por Aseguradora. */
      double dCarTotMiles;              /* Millas aplicadas por el Auto. */
      int  iCarNumDaysRent;             /* No. de Dias de Renta. */
      double dCarDailyRate;             /* Monto de Renta Diaria. */
      double dCarVATTaxAmt;             /* Impuesto Aplicado a Renta. */
      double dCarVATTaxRate;            /* Porcentaje de Impuesto. */
      char sCarVATInvRefNum[LEN15+1];   /* Clave de Identificacion Impuesto. */
      double dCarWeeklyRate;            /* Monto de Renta Semanal. */
      double dCarRatePerMile;           /* Monto de Renta por Milla. */
      double dCarOneWayDropOff;         /* Cargo Unico por Renta de Auto. */
      double dCarRegMilCharge;          /* Cargo por Millage Regular. */
      double dCarExtMilCharge;          /* Cargo Extra por Millage Regular. */
      double dCarMaxFreeMiles;          /* No. de Millas Libres. */
      double dCarLateRetCharge;         /* Cargo por Demora Retorno Auto. */
      double dCarFuelCharge;            /* Cargo por Gasolina. */
      double dCarTelCharge;             /* Cargo por Servicio Telefonico. */
      double dCarTowCharge;             /* Cargo por Remolque de Auto. */
      double dCarExtCharges;            /* Cargos Extras. */
      double dCarOthCharges;            /* Otros Cargos. */
      double dCarDiscAmt;               /* Monto de Descuento. */
      double dCarLineItemTot;           /* Monto Total Renta. */
      int   iNumRentCarTran;            /* No. Total de Transacciones de 
                                           Gastos por Renta de Auto(s). */

      /* Datos de Mapeo de No. de Cuenta. */

      char sAccNumberBMX[LEN16+1];      /* No. de Cuenta del Tarjetahabiente
                                           (Banamex). */
      char sAccNumberCB[LEN16+1];       /* No. de Cuenta del Tarjetahabiente
                                           (CitiBank). */
      char sParAccNumberBMX[LEN16+1];      /* No. de Cuenta del Tarjetahabiente
                                                (Banamex). */
      char sParAccNumberCB[LEN16+1];       /* No. de Cuenta del Tarjetahabiente
                                               (CitiBank). */

      /* Datos de Descripcion de Transacciones. */

      char sTraSign[LEN1+1];            /* Signo de la Transaccion. */
      char sTraType[LEN10+1];           /* Signo de la Trans agrega yuria*/
 
 /*estas variales agrega yuria para recuperar datos de pais*/
      char cod2_pais[LEN_COD2 + 1];
      char cod3_pais[LEN_COD3 + 1];
      char moneda_num[LEN_COD3 + 1];
      char moneda_alf[LEN_COD3 + 1];
      float tasa1;
      float tasa2;
      int  tipo_pais;/* borrar yuria*/

      /* Utilitarios */
      int aux1, aux2, aux3, aux4;
      
      /* Fecha del Sistema y componentes. */
 
      char sSystemDate[LEN10+1];   /* Fecha del Sistema. */
      char sASystemDate[LEN8+1];   /* Fecha Actual del Sistema. */
      char sProcessDate[LEN8+1];   /* Fecha de Procesamiento de Datos. */ 
      int  iSystemDay;             /* Fecha del Sistema (Dia). */
      int  iSystemMonth;           /* Fecha del Sistema (Mes). */
      int  iSystemYear;            /* Fecha del Sistema (Annio). */

      /* Comando de SQL a ejecutar en la Base de Datos. */

      char sSQLCommand[LEN5000+1];

   EXEC SQL END DECLARE SECTION;

   int  iFileTypeProc;           /* Tipo de Archivo a Procesar (Diario / Por Corte). */
   int  iFileMode;               /* Modo de Generacion del Archivo a Procesar. */
   int  iCont;                   /* Contador para ciclos. */
   char sTempNum[LEN10+1];       /* Cadena para conversion de numeros enteros. */
   char sAccNumber[LEN16+1];     /* No. de Cuenta del Tarjetahabiente. */
   char sParAccNumber[LEN16+1];  /* Cuenta Padre */
   char sOthAccNum[LEN25+1];     /* Cuenta Padre asociada al Tarjetahabiente. */
   char sPlaTransAcc[LEN25+1];   /* Descripcion Situacion Plastico. */
   double dCurrBalance;          /* Balance Actual de un Tarjetahabiente. */
   double dPrevBalance;          /* Balance Previo de un Tarjetahabiente. */
   char sMemoFlag[LEN1+1];       /* Clave asociada al campo Memo Flag (Registro
                                    5000 500. */
   Scales ScalesDesc[LEN16];     /* Descripcion de Escalas asociadas a un Vuelo. */
   int   iAirDepartDate6;        /* Fecha Salida Vuelo (6 posiciones). */
   FILE *pFileCCF;               /* Puntero al archivo CCF. */
   int  iType1000RecCnt;         /* Numero de Registros 1000 100 por Empresa. */
   int  iType1001RecCnt;         /* Numero de Registros 1001 110 por Empresa. */
   int  iType2000RecCnt;         /* Numero de Registros 2000 200 por Empresa. */
   int  iType2001RecCnt;         /* Numero de Registros 2001 210 por Empresa. */
   int  iType2002RecCnt;         /* Numero de Registros 2002 211, 212 y 213 
                                    por Empresa. */
   int  iType5000RecCnt;         /* Numero de Registros 5000 500 por Empresa. */
   double dType5000Value;        /* Importe Total correspondiente a Registros 
                                    5000 500 por Empresa. */
   int  iType5001RecCnt;         /* Numero de Registros 5001 511, 512 y 513
                                    por Empresa. */
   int  iType6001RecCnt;         /* Numero de Registros 6001 por Empresa. */
   int  iType6002RecCnt;         /* Numero de Registros 6002 por Empresa. */
   int  iType6004RecCnt;         /* Numero de Registros 6004 por Empresa. */
   int  iType6005RecCnt;         /* Numero de Registros 6005 por Empresa. */
   Record0000 Rec0000;           /* Estructura correspondiente al Registro 0000. */
   Record1100 Rec1100;           /* Estructura correspondiente al Registro 1000 100. */
   Record1001 Rec1001;           /* Estructura correspondiente al Registro 1001 110. */
   Record2200 Rec2200;           /* Estructura correspondiente al Registro 2000 200. */
   Record2001 Rec2001;           /* Estructura correspondiente al Registro 2001 210. */
   Record2211 Rec2211;           /* Estructura correspondiente al Registro 2002 211. */
   Record2212 Rec2212;           /* Estructura correspondiente al Registro 2002 212. */
   Record2213 Rec2213;           /* Estructura correspondiente al Registro 2002 213. */
   Record5500 Rec5500;           /* Estructura correspondiente al Registro 5000 500. */
   Record5511 Rec5511;           /* Estructura correspondiente al Registro 5001 511. */
   Record5512 Rec5512;           /* Estructura correspondiente al Registro 5001 512. */
   Record5513 Rec5513;           /* Estructura correspondiente al Registro 5001 513. */
   Record6001 Rec6001;           /* Estructura correspondiente al Registro 6001. */
   Record6002 Rec6002;           /* Estructura correspondiente al Registro 6002. */
   Record6004 Rec6004;           /* Estructura correspondiente al Registro 6004. */
   Record6005 Rec6005;           /* Estructura correspondiente al Registro 6005. */
   Record9000 Rec9000;           /* Estructura correspondiente al Registro 9000. */
   Company *psCompanies;         /* Conjunto de Empresas a Procesar. */

   Unit *psUnits;                /* Conjunto de Unidades a Procesar. */

   Executive *psExecutives;      /* Conjunto de Ejecutivos a Procesar. */

   CardHolder *psCardHolders;    /* Conjunto de Tarjetahabientes a Procesar. */

   Transaction *psTransactions;  /* Conjunto de Transacciones a Procesar. */

   HeaderTran *psHeaderTrans;    /* Conjunto de Encabezados de Historico de
                                    Transacciones. */

   AirlineTran *psAirlineTrans;  /* Conjunto de Transacciones de Gastos de
                                    Aerolineas a Procesar. */

   ScalesGroup *psScales;        /* Conjunto de Escales asociadas a un Vuelo
                                    a Procesar. */

   PurchasingTran *psPurchTrans; /* Conjunto de Transacciones de Gastos por
                                    Compras a Procesar. */
   
   LodgingTran *psLodTrans;      /* Conjunto de Transacciones de Gastos por
                                    Hospedaje a Procesar. */
   
   RentCarTran *psRentTrans;     /* Conjunto de Transacciones de Gastos por
                                    Renta de Auto(s) a Procesar. */

   int iCompCount;               /* Contador para Empresas. */

   int iUnitCount;               /* Contador para Unidades. */

   int iExeCount;                /* Contador para Ejecutivos. */

   int iCardHCount;              /* Contador para Tarjetahabientes. */

   int iTranCount;               /* Contador para Transacciones. */
   
   int iAirTranCount;            /* Contador para Transacciones de
                                    Gastos de Aerolineas. */

   int iScalesCount;             /* Contador para Escalas asociadas a un
                                    Vuelo determinado. */

   int iPurchTranCount;          /* Contador para Transacciones de
                                    Gastos por Compras. */

   int iLodTranCount;            /* Contador para Transacciones de
                                    Gastos por Hospedaje. */

   int iRentTranCount;           /* Contador para Transacciones de
                                    Gastos por Renta de Auto(s). */

   int iHeaderCount;             /* Contador para Encabezados de Historico
                                    de Transacciones. */

   int iTotalUnits;              /* No. Total de Unidades a Procesar. */

   int iTotalExe;                /* No. Total de Ejecutivos a Procesar. */

   int iTotalCardH;              /* No. Total de Tarjetahabientes a Procesar. */

   int iTotalTran;               /* No. Total de Transacciones a Procesar. */
   
   int iTotalAirTran;            /* No. Total de Transacciones de Gastos de
                                    Aerolineas a Procesar. */

   int iTotalScales;             /* No. Total de Escalas asociadas a un Vuelo
                                    determinado. */

   int iTotalPurTran;            /* No. Total de Transacciones de Gastos por
                                    Compras a Procesar. */

   int iTotalLodTran;            /* No. Total de Transacciones de Gastos por
                                    Hospedaje a Procesar. */
   
   int iTotalRentTran;           /* No. Total de Transacciones de Gastos por
                                    Renta de Auto(s) a Procesar. */

   int iTotalHeader;             /* No. Total de Encabezados de Historico
                                    de Transacciones a Procesar. */



   /* Inicializacion de Variables. */

   iSystemDay=0;  
   iSystemMonth=0;
   iSystemYear=0;
   strcpy(sSystemDate, EMPSTR);
   strcpy(sASystemDate, EMPSTR);
   strcpy(sProcessDate, EMPSTR);
   strcpy(sSQLCommand, EMPSTR);
   strcpy(sTempNum, EMPSTR);
   strcpy(sOthAccNum, EMPSTR);
   strcpy(sAccNumber, EMPSTR);
   strcpy(sParAccNumber, EMPSTR);
   strcpy(sAccType, EMPSTR);
   strcpy(sMemoFlag, EMPSTR);
   iFileTypeProc=0;
   iFileMode=0;
   iType1000RecCnt=0;
   iType1001RecCnt=0;
   iType2000RecCnt=0;
   iType2001RecCnt=0;
   iType2002RecCnt=0;
   iType5000RecCnt=0;
   dType5000Value=0.0;
   iType5001RecCnt=0;
   iType6001RecCnt=0;
   iType6002RecCnt=0;
   iType6004RecCnt=0;
   iType6005RecCnt=0;
   iCompCount=0;
   iUnitCount=0;
   iExeCount=0;
   iCardHCount=0;
   iTranCount=0;
   iAirTranCount=0;
   iScalesCount=0;
   iPurchTranCount=0;
   iLodTranCount=0;
   iRentTranCount=0;
   iHeaderCount=0;
   iTotalUnits=0;
   iTotalExe=0;
   iTotalCardH=0;
   iTotalTran=0;
   iTotalAirTran=0;
   iTotalScales=0;
   iTotalPurTran=0;
   iTotalLodTran=0;
   iTotalRentTran=0;
   iTotalHeader=0;
   iRadPos=0;
   iSign=0;  

   /* Extraccion de la Fecha del Sistema menos un dia. */

   if(strlen(psParams[10]) > 0)

      strcpy(sProcessDate, psParams[10]);

   /* Si la Fecha de Procesamiento fue definida por el usuario,  tomarla
      como referencia para la extraccion de datos;  de lo contrario,
      tomar la Fecha del Sistema. */

   if(strcmp(sProcessDate, EMPSTR) != 0)
   {
      strcpy(sSQLCommand, "SELECT convert(char(10),");
      strcat(sSQLCommand, " dateadd(dd, -1,");
      strcat(sSQLCommand, " convert(datetime, \'");
      strcat(sSQLCommand, sProcessDate); 
      strcat(sSQLCommand, "\')), 101)");
   } 
   else
   {
      strcpy(sSQLCommand, "SELECT convert(char(10),");
      strcat(sSQLCommand, " dateadd(dd, -1,");
      strcat(sSQLCommand, " getdate()");
      strcat(sSQLCommand, "), 101)");
   }


   EXEC SQL PREPARE setdate FROM :sSQLCommand;  
                                               
   EXEC SQL EXECUTE setdate INTO :sSystemDate;

   /* Calculo del dia, mes y annio previo a la Fecha del Sistema. */

   strcpy(sSQLCommand, "SELECT datepart(dd,");
   strcat(sSQLCommand, " convert(datetime, \'");
   strcat(sSQLCommand, sSystemDate); 
   strcat(sSQLCommand, "\'))");
   

   EXEC SQL PREPARE setday FROM :sSQLCommand;  
                                               
   EXEC SQL EXECUTE setday INTO :iSystemDay;

   strcpy(sSQLCommand, "SELECT datepart(mm,");
   strcat(sSQLCommand, " convert(datetime, \'");
   strcat(sSQLCommand, sSystemDate); 
   strcat(sSQLCommand, "\'))");
   

   EXEC SQL PREPARE setmonth FROM :sSQLCommand;  
                                               
   EXEC SQL EXECUTE setmonth INTO :iSystemMonth;

   strcpy(sSQLCommand, "SELECT datepart(yy,");
   strcat(sSQLCommand, " convert(datetime, \'");
   strcat(sSQLCommand, sSystemDate); 
   strcat(sSQLCommand, "\'))");
   

   EXEC SQL PREPARE setyear FROM :sSQLCommand;  
                                               
   EXEC SQL EXECUTE setyear INTO :iSystemYear;

   /* Calculo de la Fecha Actual. */

   strcpy(sSQLCommand, "SELECT convert(char(8),");
   strcat(sSQLCommand, " dateadd(dd, 1,");
   strcat(sSQLCommand, " convert(datetime, \'");
   strcat(sSQLCommand, sSystemDate); 
   strcat(sSQLCommand, "\')), 112)");


   EXEC SQL PREPARE setsysdate FROM :sSQLCommand;  
                                               
   EXEC SQL EXECUTE setsysdate INTO :sASystemDate;

#ifdef DEBUG1
   printf("\nDay: %d", iSystemDay);
   printf("\nMonth: %d", iSystemMonth);
   printf("\nYear: %d", iSystemYear);
   printf("\nSystem Date: %s\n", sASystemDate);
#endif
  
/*inicio codigo yuria para cargar la informacion de paises y tipos de moneda*/

N_CODS_PAIS=0;   
N_CODS_MONED=0;   
strcpy(sSQLCommand, " SELECT ");
strcat(sSQLCommand, " convert(char(2),rtrim(ltrim(alpha2_country_code))), ");
strcat(sSQLCommand, " convert(char(3),rtrim(ltrim(alpha3_country_code))), ");
strcat(sSQLCommand, " convert(char(3),rtrim(ltrim(numeric_currency_code))), ");
strcat(sSQLCommand, " convert(char(3),rtrim(ltrim(alpha_currency_code))), ");
strcat(sSQLCommand, " pais_tipo, ");
strcat(sSQLCommand, " pais_tasa1, ");
strcat(sSQLCommand, " pais_tasa2 ");
strcat(sSQLCommand, " FROM ");
strcat(sSQLCommand, "  MTCPAIS01 ");
   EXEC SQL PREPARE paissql FROM :sSQLCommand;
   EXEC SQL DECLARE paisdata CURSOR FOR paissql;
   EXEC SQL OPEN paisdata;
   for(;;) 
   {
      strcpy(cod2_pais, EMPSTR);  
      strcpy(cod3_pais, EMPSTR);  
      strcpy(moneda_num, EMPSTR);  
      strcpy(moneda_alf, EMPSTR);  
      tipo_pais=0;
      tasa1=0;
      tasa2=0;
   
      EXEC SQL FETCH paisdata 
               INTO :cod2_pais, :cod3_pais, :moneda_num,
                    :moneda_alf, :tipo_pais, 
                    :tasa1, :tasa2;

      if(sqlca.sqlcode == 100)	
         break;




      sprintf(pais[N_CODS_PAIS].cod2, "%-2s", cod2_pais);
      sprintf(pais[N_CODS_PAIS].cod3, "%-3s", cod3_pais);
      sprintf(pais[N_CODS_PAIS].moneda_num, "%-3s",moneda_num);
      sprintf(pais[N_CODS_PAIS].moneda_alf, "%-3s",moneda_alf);
      ++N_CODS_PAIS;
      if( tipo_pais == 1) 
      {
         sprintf(monedas_usuales[N_CODS_MONED].moneda_num, "%-3s",moneda_num);
         sprintf(monedas_usuales[N_CODS_MONED].moneda_alf, "%-3s",moneda_alf);
         monedas_usuales[N_CODS_MONED].tasa_rango1=tasa1;
         monedas_usuales[N_CODS_MONED].tasa_rango2=tasa2;
         ++N_CODS_MONED;
      }

   }

   EXEC SQL CLOSE paisdata;            
                                       
   EXEC SQL DEALLOCATE PREPARE paissql;

   EXEC SQL COMMIT WORK;

/*fin codigo yuria para paises y tipos de moneda borrar*/ 


   iFileTypeProc=atoi(psParams[4]);
   iFileMode=atoi(psParams[5]);

   /* Recuperacion de Informacion de Base de Datos. */

   /* Determinacion de Empresas a Procesar. */

   iNumCompanies=0;

   strcpy(sSQLCommand, "SELECT count(*) ");
   strcat(sSQLCommand, "FROM MTCEMP01 EMP, MTCEJE01 EJE ");
   strcat(sSQLCommand, "WHERE EMP.eje_prefijo = EJE.eje_prefijo ");
   strcat(sSQLCommand, "AND EMP.gpo_banco = EJE.gpo_banco ");
   strcat(sSQLCommand, "AND EMP.emp_num = EJE.emp_num ");
   strcat(sSQLCommand, "AND EJE.eje_tipo_cuenta = \'E\' "); 

   /* Establecer los criterios de recuperacion de Empresas de
      acuerdo con los Parametros de Entrada. */

   if(iFileTypeProc == 0)   /* Archivo Diario. */
   {
      strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) ");
   }
   else   
   {
      if(iFileTypeProc == 1)   /* Archivo por Fecha de Corte. */
      {
         strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) ");
         strcat(sSQLCommand, "AND EMP.emp_dia_corte = ");
         sprintf(sTempNum, "%d", iSystemDay);
         strcat(sSQLCommand, sTempNum);
         strcat(sSQLCommand, " ");
      }
      else   /* Error en el parametro Tipo de Archivo. */
      {
         printf("\nFile Type not specified.\n");
         exit(ERREXIT);
      }
   }

   /* Determinar si la generacion de los archivos estara enfocada a
      una empresa en particular. */

   if(iFileMode == 0)   /* Todas las empresas seran procesadas. */
   {
      ;
   }
   else
   {
      if(iFileMode == 1)   /* La empresa indicada sera analizada. */
      {
         strcat(sSQLCommand, "AND EMP.eje_prefijo = ");
         strcat(sSQLCommand, psParams[7]);
         strcat(sSQLCommand, " AND EMP.gpo_banco = ");
         strcat(sSQLCommand, psParams[8]);
         strcat(sSQLCommand, " AND EMP.emp_num = ");
         strcat(sSQLCommand, psParams[9]);
      }
      else   /* Error en el parametro Modo de Generacion del Archivo. */      
      {                                                        
         printf("\nFile Mode not specified.\n");
         exit(ERREXIT);                                        
      }                                                        
   }
   

   EXEC SQL PREPARE countcomp FROM :sSQLCommand;

   EXEC SQL EXECUTE countcomp INTO :iNumCompanies;

   psCompanies=malloc(iNumCompanies * sizeof(Company));

   if(psCompanies == NULL)
   {
      printf("\nMemory Not Available.\n");
      exit(ERREXIT);
   }

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {  
      psCompanies[iCompCount].iPreffix=0;                 
      psCompanies[iCompCount].iBankGroup=0;             
      psCompanies[iCompCount].iCompanyID=0;             
      strcpy(psCompanies[iCompCount].sCompanyName, EMPSTR);
      psCompanies[iCompCount].iChargeOffDate=0;     
      psCompanies[iCompCount].iFileType=0;               
      strcpy(psCompanies[iCompCount].sBillType, EMPSTR);      
      psCompanies[iCompCount].iPayDate=0;                 
   }                                                           

   EXEC SQL DEALLOCATE PREPARE countcomp;

   EXEC SQL COMMIT WORK; 

   /* Extraccion de registros de la tabla de Empresas MTCEMP01. 
      con generacion de archivo de Tipo Fecha de Corte. */

   iCompCount=0;

	/***
	 ***
		primer consulta obtiene datos de la compañia
	 ***
	 ***/

   strcpy(sSQLCommand, "SELECT EMP.eje_prefijo, EMP.gpo_banco, ");
   strcat(sSQLCommand, "EMP.emp_num, EMP.emp_nom, ");
   strcat(sSQLCommand, "isnull(EMP.emp_dia_corte, 0), isnull(EMP.emp_gen_SBF, 0), ");
   strcat(sSQLCommand, "isnull(EMP.emp_tipo_fac, ' '), isnull(eje_gen_pin_pla,1), isnull(EMP.emp_plazo_gracia, 0) ");
   strcat(sSQLCommand, "FROM MTCEMP01 EMP, MTCEJE01 EJE ");
   strcat(sSQLCommand, "WHERE EMP.eje_prefijo = EJE.eje_prefijo ");
   strcat(sSQLCommand, "AND EMP.gpo_banco = EJE.gpo_banco ");
   strcat(sSQLCommand, "AND EMP.emp_num = EJE.emp_num ");
   strcat(sSQLCommand, "AND EJE.eje_tipo_cuenta = \'E\' "); 

   /* Establecer los criterios de recuperacion de Empresas de
      acuerdo con los Parametros de Entrada. */

   if(iFileTypeProc == 0)   /* Archivo Diario. */
   {
      strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) ");
   }
   else   
   {
      if(iFileTypeProc == 1)   /* Archivo por Fecha de Corte. */
      {
         strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) ");
         strcat(sSQLCommand, "AND EMP.emp_dia_corte = ");
         sprintf(sTempNum, "%d", iSystemDay);
         strcat(sSQLCommand, sTempNum);
         strcat(sSQLCommand, " ");
      }
      else   /* Error en el parametro Tipo de Archivo. */
      {
         printf("\nFile Type not specified.\n");

         free(psCompanies);
                     
         exit(ERREXIT);
      }
   }

   /* Determinar si la generacion de los archivos estara enfocada a
      una empresa en particular. */

   if(iFileMode == 0)   /* Todas las empresas seran procesadas. */
   {
      ;
   }
   else
   {
      if(iFileMode == 1)   /* La empresa indicada sera analizada. */
      {
         strcat(sSQLCommand, "AND EMP.eje_prefijo = ");
         strcat(sSQLCommand, psParams[7]);
         strcat(sSQLCommand, " AND EMP.gpo_banco = ");
         strcat(sSQLCommand, psParams[8]);
         strcat(sSQLCommand, " AND EMP.emp_num = ");
         strcat(sSQLCommand, psParams[9]);
      }
      else   /* Error en el parametro Modo de Generacion del Archivo. */      
      {                                                        
         printf("\nFile Mode not specified.\n");

         free(psCompanies);

         exit(ERREXIT);                                        
      }                                                        
   }

   EXEC SQL PREPARE companysql FROM :sSQLCommand;

   EXEC SQL DECLARE companydata CURSOR FOR companysql;

   EXEC SQL OPEN companydata;

   for(;;) 
   {
      iPreffix=0;          
      iBankGroup=0;        
      iCompanyID=0;        
      strcpy(sCompanyName, EMPSTR);  
      iChargeOffDate=0;
      iFileType=0;
      strcpy(sBillType, EMPSTR);
      iPayDate=0;
   
      EXEC SQL FETCH companydata 
               INTO :iPreffix, :iBankGroup, :iCompanyID,
                    :sCompanyName, :iChargeOffDate, :iFileType,
                    :sBillType, :iGenPla, :iPayDate;

      if(sqlca.sqlcode == 100)	/* Fin de consulta. */
         break;

#ifdef DEBUG1 
         printf("\nResult (Company): %d, %d, %d\n", 
                                     iPreffix, iBankGroup,
                                     iCompanyID); 
         printf("                  %s, %d, %d, %s, %d\n", 
                                     sCompanyName, iChargeOffDate, 
                                     iFileType, sBillType, iPayDate);
#endif 


      /* En caso de que el Archivo a Procesar sea por Fecha de Corte,
         evaluar la Fecha de Corte asociada a los registros de la
         Empresa. */ 

      if(iFileTypeProc == 1)
      {
         /* La Fecha de Corte no corresponde a la Fecha del Sistema 
            menos 1. */
                                                                
         if(iChargeOffDate != iSystemDay)                                
         {
            continue; 
         }
      } 

      /* La informacion recuperada es almacenada en el arreglo de Empresas. */

      psCompanies[iCompCount].iPreffix=iPreffix;
      psCompanies[iCompCount].iBankGroup=iBankGroup;
      psCompanies[iCompCount].iCompanyID=iCompanyID;
      strcpy(psCompanies[iCompCount].sCompanyName, sCompanyName);
      psCompanies[iCompCount].iChargeOffDate=iChargeOffDate;
      psCompanies[iCompCount].iFileType=iFileType;
      strcpy(psCompanies[iCompCount].sBillType, sBillType);
      psCompanies[iCompCount].iPayDate=iPayDate;

      iCompCount++;    

   }

   EXEC SQL CLOSE companydata;            
                                       
   EXEC SQL DEALLOCATE PREPARE companysql;

   EXEC SQL COMMIT WORK;

   /* Ordena el arreglo de Empresas en forma ascendente. */

   qsort((void *) psCompanies, iNumCompanies, sizeof(Company), iCompareComp);

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      /* Determinacion de Unidades a Procesar. */ 

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      iNumUnits=0;

	/***
	 ***
		segunda consulta obtiene el # de las unidades
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCUNI01 A ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null))");
      EXEC SQL PREPARE countunits FROM :sSQLCommand;
                                                  
      EXEC SQL EXECUTE countunits INTO :iNumUnits;

      iTotalUnits+=iNumUnits;
                                                  
      EXEC SQL DEALLOCATE PREPARE countunits;            

   }

   EXEC SQL COMMIT WORK;
 
   psUnits=malloc(iTotalUnits * sizeof(Unit));

   if(psUnits == NULL)                
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      exit(ERREXIT);
   }

   for(iUnitCount=0; iUnitCount < iTotalUnits; iUnitCount++)
   { 
      psUnits[iUnitCount].iPreffix=0;
      psUnits[iUnitCount].iBankGroup=0;
      psUnits[iUnitCount].iCompanyID=0;
      strcpy(psUnits[iUnitCount].sUniUnitID, EMPSTR);
      strcpy(psUnits[iUnitCount].sUniUnitPID, EMPSTR);
      strcpy(psUnits[iUnitCount].sUniUnitName, EMPSTR);
      psUnits[iUnitCount].iUniLevelNum=0;
   }
       
   iUnitCount=0;
                                                    
   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* Extraccion de registros de la tabla de Unidades MTCUNI01. */

	/***
	 ***
		tercera consulta obtiene los datos de las unidades
	 ***
	 ***/

     /* strcpy(sSQLCommand, "SELECT distinct A.unit_id, ");
      strcat(sSQLCommand, "isnull(A.unit_parent_id, \' \'), ");
      strcat(sSQLCommand, "A.unit_name, ");
      strcat(sSQLCommand, "A.nivel_num ");
      strcat(sSQLCommand, "FROM MTCUNI01 A ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)) ");
      strcat(sSQLCommand, "ORDER BY A.nivel_num, A.emp_num");

      sSQLCommand[0]='\0';
      strcpy(sSQLCommand, "drop table MTCTEST ");
      EXEC SQL EXECUTE IMMEDIATE :sSQLCommand;*/

      sSQLCommand[0]='\0';
      strcpy(sSQLCommand, "if exists( select * from sysobjects ");
      strcat(sSQLCommand, " where name=\'MTCTEST\') ");
      strcat(sSQLCommand, "begin  ");
      strcat(sSQLCommand, " drop table MTCTEST ");
      strcat(sSQLCommand, "end  ");
      EXEC SQL EXECUTE IMMEDIATE :sSQLCommand;


      sSQLCommand[0]='\0';
      strcpy(sSQLCommand, "exec sp_CCFDepth ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " , ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " , ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));


      EXEC SQL SET CHAINED OFF;
      EXEC SQL EXECUTE IMMEDIATE :sSQLCommand;

      sSQLCommand[0]='\0';
      strcpy(sSQLCommand, "select * from M111.dbo.MTCTEST");

      EXEC SQL PREPARE unitsql FROM :sSQLCommand; 

      EXEC SQL DECLARE unitdata CURSOR FOR unitsql;
                                                               
      EXEC SQL OPEN unitdata;

      for(;;)                                           
      {                                                 
         strcpy(sUniUnitID, EMPSTR);    
         strcpy(sUniUnitPID, EMPSTR);
         strcpy(sUniUnitName, EMPSTR); 
         iUniLevelNum=0;                           
                                                              
         EXEC SQL FETCH unitdata                        
                  INTO :sUniUnitID, :sUniUnitPID,
                       :sUniUnitName, :iUniLevelNum; 
                                                              
         if(sqlca.sqlcode == 100) /* Fin de consulta. */
            break;     

#ifdef DEBUG1
         printf("\nResult (Unit): %s, %s\n", sUniUnitID, sUniUnitPID);   
         printf("               %s, %d\n", sUniUnitName, iUniLevelNum);   
#endif
 
         /* La informacion recuperada es almacenada en el arreglo de 
            Unidades. */

         psUnits[iUnitCount].iPreffix=iPreffix;
         psUnits[iUnitCount].iBankGroup=iBankGroup;
         psUnits[iUnitCount].iCompanyID=iCompanyID;
         strcpy(psUnits[iUnitCount].sUniUnitID, sUniUnitID);
         strcpy(psUnits[iUnitCount].sUniUnitPID, sUniUnitPID);
         strcpy(psUnits[iUnitCount].sUniUnitName, sUniUnitName);
         psUnits[iUnitCount].iUniLevelNum=iUniLevelNum;

         iUnitCount++;    
 
      }

      EXEC SQL CLOSE unitdata;

      EXEC SQL DEALLOCATE PREPARE unitsql;
   }

   EXEC SQL COMMIT WORK;

/*   sSQLCommand[0]='\0';
   strcpy(sSQLCommand, "drop table MTCTEST ");
   EXEC SQL EXECUTE IMMEDIATE :sSQLCommand;*/

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {
      /* Determinacion de Ejecutivos a Procesar. */ 

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      iNumExecutives=0;

	/***
	 ***
		cuarta consulta obtiene el # de los ejecutivos
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco = "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in  ");
      strcat(sSQLCommand, " (select unit_id from MTCTEST) ");

     /* strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))");*/

      EXEC SQL PREPARE countexecs FROM :sSQLCommand;

      EXEC SQL EXECUTE countexecs INTO :iNumExecutives;

      iTotalExe+=iNumExecutives;
                                                  
      EXEC SQL DEALLOCATE PREPARE countexecs;            

   }

   EXEC SQL COMMIT WORK;

   psExecutives=malloc(iTotalExe * sizeof(Executive));

   if(psExecutives == NULL)
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      free(psUnits);

      exit(ERREXIT);
   }

   for(iExeCount=0; iExeCount < iTotalExe; iExeCount++)
   {
      psExecutives[iExeCount].iPreffix=0;
      psExecutives[iExeCount].iBankGroup=0;
      psExecutives[iExeCount].iCompanyID=0;
      strcpy(psExecutives[iExeCount].sUniUnitID, EMPSTR);
      psExecutives[iExeCount].iExeExeNum=0;
      strcpy(psExecutives[iExeCount].sExeName, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeAddress1, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeAddress2, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeCity, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeState, EMPSTR);
      psExecutives[iExeCount].iExePostalCode=0;
      strcpy(psExecutives[iExeCount].sExeTelNumber, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeOfficeNum, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeFaxNum, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeRFC, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeEmail, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeEmpNum, EMPSTR);
      strcpy(psExecutives[iExeCount].sExeMAccCode, EMPSTR);
      psExecutives[iExeCount].iExeOpenDate=0;
      psExecutives[iExeCount].iExeCredLim=0;
      strcpy(psExecutives[iExeCount].sExeEmbName, EMPSTR);
      psExecutives[iExeCount].iExeLastMaintDate=0;
      psExecutives[iExeCount].iExePerCashLim=0;
   }
       
   iExeCount=0;
   
   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {
      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* Extraccion de registros de la tabla de Ejecutivos MTCEJE01. */
      
	/***
	 ***
		quinta consulta obtiene los datos de los ejecutivos
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT EJE.eje_num, EJE.eje_nombre, "); 
      strcat(sSQLCommand, "isnull(EJE.eje_calle, \' \'), ");
      strcat(sSQLCommand, "isnull(EJE.eje_col, \' \'), "); 
      strcat(sSQLCommand, "isnull(EJE.eje_pob, \' \'), ");
      strcat(sSQLCommand, "isnull(EJE.eje_edo, \' \'), ");
      strcat(sSQLCommand, "isnull(EJE.eje_cp, 0), ");
      strcat(sSQLCommand, "isnull(replicate(\'0\',10-char_length(ltrim(rtrim( EJE.eje_tel_dom))))+ltrim(rtrim(EJE.eje_tel_dom)),replicate(\'0\',10)),");
      strcat(sSQLCommand, "isnull(replicate(\'0\',10-char_length(ltrim(rtrim( EJE.eje_tel_ofi))))+ltrim(rtrim(EJE.eje_tel_ofi)),replicate(\'0\',10)),");
      strcat(sSQLCommand, "isnull(replicate(\'0\',15-char_length(ltrim(rtrim( EJE.eje_fax))))    +ltrim(rtrim(EJE.eje_fax)),replicate(\'0\',15)),");
      strcat(sSQLCommand, "isnull(EJE.eje_rfc, \' \'), ");
      strcat(sSQLCommand, "isnull(EJE.eje_email, \' \'), ");
      strcat(sSQLCommand, "isnull(EJE.eje_num_nom, \' \'), ");
      strcat(sSQLCommand, "isnull(EJE.eje_cta_contable, \' \'), ");
      strcat(sSQLCommand, "isnull(EJE.eje_fecha_alta, 0), ");
      strcat(sSQLCommand, "isnull(EJE.eje_limcred, 0), ");
      strcat(sSQLCommand, "EJE.eje_nom_gra, isnull(EJE.eje_fecha_cam, 0), ");
      strcat(sSQLCommand, "isnull(EJE.eje_lim_dis_efec, 0), ");
      strcat(sSQLCommand, "isnull(EJE.eje_centro_c, \' \') ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco = "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in  ");
      strcat(sSQLCommand, " (select unit_id from MTCTEST) ");

/*      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco = "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ");
      strcat(sSQLCommand, " (select unit_id from MTCTEST) ");
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null))) ");*/
      strcat(sSQLCommand, "ORDER BY EJE.eje_num");
      
      EXEC SQL PREPARE execsql FROM :sSQLCommand;

      EXEC SQL DECLARE executivedata CURSOR FOR execsql;
                                                
      EXEC SQL OPEN executivedata; 
                                                
      for(;;)                             
      {  
         iExeExeNum=0;
         strcpy(sExeName, EMPSTR);
         strcpy(sExeAddress1, EMPSTR);
         strcpy(sExeAddress2, EMPSTR);
         strcpy(sExeCity, EMPSTR); 
         strcpy(sExeState, EMPSTR);
         iExePostalCode=0;  
         strcpy(sExeTelNumber, EMPSTR);
         strcpy(sExeOfficeNum, EMPSTR); 
         strcpy(sExeFaxNum, EMPSTR);
         strcpy(sExeRFC, EMPSTR);
         strcpy(sExeEmail, EMPSTR); 
         strcpy(sExeEmpNum, EMPSTR);
         strcpy(sExeMAccCode, EMPSTR);
         iExeOpenDate=0;
         iExeCredLim=0;
         strcpy(sExeEmbName, EMPSTR); 
         iExeLastMaintDate=0;
         iExePerCashLim=0;
         strcpy(sUniUnitID, EMPSTR);

         EXEC SQL FETCH executivedata  
                  INTO :iExeExeNum, :sExeName,
                       :sExeAddress1, :sExeAddress2,
                       :sExeCity, :sExeState,
                       :iExePostalCode, :sExeTelNumber,
                       :sExeOfficeNum, :sExeFaxNum,
                       :sExeRFC, :sExeEmail,
                       :sExeEmpNum, :sExeMAccCode,
                       :iExeOpenDate, :iExeCredLim,
                       :sExeEmbName, :iExeLastMaintDate,
                       :iExePerCashLim, :sUniUnitID;

         if(sqlca.sqlcode == 100) /* Fin de consulta. */
            break;

#ifdef DEBUG1
         printf("\nResult (Executive): %d, %s, %s\n", 
                                       iExeExeNum, sExeName, sExeAddress1);
         printf("                    %s, %s, %s\n",      
                                       sExeAddress2, sExeCity,sExeState);
         printf("                    %d, %s, %s\n",      
                                       iExePostalCode, sExeTelNumber, sExeOfficeNum);
         printf("                    %s, %s, %s\n",      
                                       sExeFaxNum, sExeRFC, sExeEmail);
         printf("                    %s, %s, %d\n",
                                        sExeEmpNum, sExeMAccCode, iExeOpenDate);
         printf("                    %d, %s, %d\n", 
                                        iExeCredLim, sExeEmbName, iExeLastMaintDate); 
         printf("                    %d, %s\n", 
                                        iExePerCashLim, sUniUnitID); 
#endif

         /* La informacion recuperada es almacenada en el arreglo de 
            Ejecutivos. */

         psExecutives[iExeCount].iPreffix=iPreffix;
         psExecutives[iExeCount].iBankGroup=iBankGroup;
         psExecutives[iExeCount].iCompanyID=iCompanyID;
         strcpy(psExecutives[iExeCount].sUniUnitID, sUniUnitID);
         psExecutives[iExeCount].iExeExeNum=iExeExeNum;
         strcpy(psExecutives[iExeCount].sExeName, sExeName);
         strcpy(psExecutives[iExeCount].sExeAddress1, sExeAddress1);
         strcpy(psExecutives[iExeCount].sExeAddress2, sExeAddress2);
         strcpy(psExecutives[iExeCount].sExeCity, sExeCity);
         strcpy(psExecutives[iExeCount].sExeState, sExeState);
         psExecutives[iExeCount].iExePostalCode=iExePostalCode;
         strcpy(psExecutives[iExeCount].sExeTelNumber, sExeTelNumber);
         strcpy(psExecutives[iExeCount].sExeOfficeNum, sExeOfficeNum);
         strcpy(psExecutives[iExeCount].sExeFaxNum, sExeFaxNum);
         strcpy(psExecutives[iExeCount].sExeRFC, sExeRFC);
         strcpy(psExecutives[iExeCount].sExeEmail, sExeEmail);
         strcpy(psExecutives[iExeCount].sExeEmpNum, sExeEmpNum);
         strcpy(psExecutives[iExeCount].sExeMAccCode, sExeMAccCode);
         psExecutives[iExeCount].iExeOpenDate=iExeOpenDate;
         psExecutives[iExeCount].iExeCredLim=iExeCredLim;
         strcpy(psExecutives[iExeCount].sExeEmbName, sExeEmbName);
         psExecutives[iExeCount].iExeLastMaintDate=iExeLastMaintDate;
         psExecutives[iExeCount].iExePerCashLim=iExePerCashLim;


         iExeCount++;
      }

      EXEC SQL CLOSE executivedata;

      EXEC SQL DEALLOCATE PREPARE execsql;
   }

   EXEC SQL COMMIT WORK;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {
      /* Determinacion de Tarjetahabientes a Procesar. */ 

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      iNumCardHolders=0;

	/***
	 ***
		sexta consulta obtiene el # de los THS
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCTHS01 THS , MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE THS.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND THS.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND THS.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND THS.eje_prefijo = EJE.eje_prefijo ");
      strcat(sSQLCommand, " AND THS.gpo_banco =  EJE.gpo_banco "); 
      strcat(sSQLCommand, " AND THS.emp_num = EJE.emp_num ");
      strcat(sSQLCommand, " AND THS.eje_num = EJE.eje_num ");
      strcat(sSQLCommand, " AND EJE.eje_centro_c in  ");
      strcat(sSQLCommand, " (select unit_id from MTCTEST) ");

      EXEC SQL PREPARE countcardh FROM :sSQLCommand;
 
      EXEC SQL EXECUTE countcardh INTO :iNumCardHolders;
 
      iTotalCardH+=iNumCardHolders;
 
      EXEC SQL DEALLOCATE PREPARE countcardh;
   }

   iTotalHeader=iTotalCardH;

   EXEC SQL COMMIT WORK;

   psCardHolders=malloc(iTotalCardH * sizeof(CardHolder));
   psHeaderTrans=malloc(iTotalHeader * sizeof(HeaderTran));

   if(psCardHolders == NULL && psHeaderTrans == NULL)
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      free(psUnits);
                     
      free(psExecutives);

      exit(ERREXIT);
   }

   for(iCardHCount=0; iCardHCount < iTotalCardH; iCardHCount++)
   {
      psCardHolders[iCardHCount].iPreffix=0;
      psCardHolders[iCardHCount].iBankGroup=0;
      psCardHolders[iCardHCount].iCompanyID=0;
      psCardHolders[iCardHCount].iExeExeNum=0;
      psCardHolders[iCardHCount].iCardHRollOver=0;
      psCardHolders[iCardHCount].iCardHDigit=0;
      strcpy(psCardHolders[iCardHCount].sCardHRating, EMPSTR);
      psCardHolders[iCardHCount].iCardHLastPayDate=0;
      psCardHolders[iCardHCount].dCardHPayAmtDue=0.0;
      psCardHolders[iCardHCount].dCardHChargeOffBal=0.0;
      psCardHolders[iCardHCount].dCardHPreviewBal=0.0;
      psCardHolders[iCardHCount].dCardHCurrBal=0.0;
   }

   for(iHeaderCount=0; iHeaderCount < iTotalHeader; iHeaderCount++)
   {
      psHeaderTrans[iHeaderCount].iPreffix=0;
      psHeaderTrans[iHeaderCount].iBankGroup=0;
      psHeaderTrans[iHeaderCount].iCompanyID=0;
      psHeaderTrans[iHeaderCount].iExeExeNum=0;
      psHeaderTrans[iHeaderCount].iCardHRollOver=0;
      psHeaderTrans[iHeaderCount].iCardHDigit=0;
      psHeaderTrans[iHeaderCount].dHihCurrBalance=0.0;
      psHeaderTrans[iHeaderCount].dHihPrevBalance=0.0;
   } 

   iCardHCount=0;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* Extraccion de registros de la tabla de Tarjetahabientes 
         MTCTHS01. */ 


	/***
	 ***
		septima consulta obtiene los datos de los THS
	 ***
	 ***/
/*SI DESEAN enviar roll_over original
      strcpy(sSQLCommand, "SELECT THS.eje_roll_over, THS.eje_digit, ");*/
/*SI NO DESEAN enviar roll_over original
      strcpy(sSQLCommand, "SELECT EJE.eje_roll_over, EJE.eje_digit, ");*/

      strcpy(sSQLCommand, "SELECT THS.eje_roll_over, THS.eje_digit, ");
      strcat(sSQLCommand, "isnull(THS.ths_situacion_cta, \' \'), ");
      strcat(sSQLCommand, "isnull(THS.ths_ultimo_pago_amd, 0), ");
      strcat(sSQLCommand, "isnull(THS.ths_ant_minimo_pagar, 0.0), ");
      strcat(sSQLCommand, "isnull(THS.ths_hue_saldo_maximo, 0.0), ");
      strcat(sSQLCommand, "isnull(THS.ths_ant_saldo, 0.0), ");
      strcat(sSQLCommand, "isnull(THS.ths_act_saldo, 0.0)+ ");
      strcat(sSQLCommand, "isnull(THS.ths_act_ext_saldo, 0.0), ");
      strcat(sSQLCommand, "THS.eje_num ");
      strcat(sSQLCommand, "FROM MTCTHS01 THS , MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE THS.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND THS.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND THS.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND THS.eje_prefijo = EJE.eje_prefijo ");
      strcat(sSQLCommand, " AND THS.gpo_banco =  EJE.gpo_banco "); 
      strcat(sSQLCommand, " AND THS.emp_num = EJE.emp_num ");
      strcat(sSQLCommand, " AND THS.eje_num = EJE.eje_num ");
      strcat(sSQLCommand, " AND EJE.eje_centro_c in  ");
      strcat(sSQLCommand, " (select unit_id from MTCTEST) ");
      strcat(sSQLCommand, "ORDER BY THS.eje_num, THS.eje_roll_over ");

      EXEC SQL PREPARE cardhsql FROM :sSQLCommand;

      EXEC SQL DECLARE cardhdata CURSOR FOR cardhsql;
                                                
      EXEC SQL OPEN cardhdata;
 
      for(;;)   
      {          
         iCardHRollOver=0;    
         iCardHDigit=0;
         iCardPRollOver=0;
         iCardPDigit=0;     
         strcpy(sCardHRating, EMPSTR);
         iCardHLastPayDate=0; 
         dCardHPayAmtDue=0.0;
         dCardHChargeOffBal=0.0;
         dCardHPreviewBal=0.0;
         dCardHCurrBal=0.0;
         iExeExeNum=0;
 
         EXEC SQL FETCH cardhdata                         
                  INTO :iCardHRollOver, :iCardHDigit,
                       :sCardHRating, :iCardHLastPayDate,
                       :dCardHPayAmtDue, :dCardHChargeOffBal,
                       :dCardHPreviewBal, :dCardHCurrBal,
                       :iExeExeNum;  

         if(sqlca.sqlcode == 100) /* Fin de consulta. */ 
            break;                      

#ifdef DEBUG1
         printf("\nResult (CardHolder): %d, %d, %s\n", iCardHRollOver,
                                                       iCardHDigit,
                                                       sCardHRating); 
         printf("                     %d, %0.2f, %0.2f\n", 
                                                       iCardHLastPayDate,
                                                       dCardHPayAmtDue,
                                                       dCardHChargeOffBal);
         printf("                     %0.2f, %0.2f, %d\n", 
                                                       dCardHPreviewBal,
                                                       dCardHCurrBal,
                                                       iExeExeNum);
#endif

         /* La informacion recuperada es almacenada en el arreglo de 
            Tarjetahabientes. */

         psCardHolders[iCardHCount].iPreffix=iPreffix;
         psCardHolders[iCardHCount].iBankGroup=iBankGroup;
         psCardHolders[iCardHCount].iCompanyID=iCompanyID;
         psCardHolders[iCardHCount].iExeExeNum=iExeExeNum;
         psCardHolders[iCardHCount].iCardHRollOver=iCardHRollOver;
         psCardHolders[iCardHCount].iCardHDigit=iCardHDigit;
         strcpy(psCardHolders[iCardHCount].sCardHRating, sCardHRating);
         psCardHolders[iCardHCount].iCardHLastPayDate=iCardHLastPayDate;
         psCardHolders[iCardHCount].dCardHPayAmtDue=dCardHPayAmtDue;
         psCardHolders[iCardHCount].dCardHChargeOffBal=dCardHChargeOffBal;
         psCardHolders[iCardHCount].dCardHPreviewBal=dCardHPreviewBal;
         psCardHolders[iCardHCount].dCardHCurrBal=dCardHCurrBal;

         iCardHCount++;

      }

      EXEC SQL CLOSE cardhdata;
 
      EXEC SQL DEALLOCATE PREPARE cardhsql;

   }

   EXEC SQL COMMIT WORK;

   iHeaderCount=0;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* Extraccion de registros de la tabla de Encabezado de Historico
         de Transacciones MTCHIH01. */

	/***
	 ***
		octava consulta obtiene los Encabezado de Historico
	 ***
	 ***/
 
      strcpy(sSQLCommand, "SELECT isnull(C.hih_saldo_anterior, 0.0) + ");
      strcat(sSQLCommand, "isnull(C.hih_compras_y_disp, 0.0) + ");
      strcat(sSQLCommand, "isnull(C.hih_comisiones, 0.0) + ");
      strcat(sSQLCommand, "isnull(C.hih_intereses, 0.0) - ");
      strcat(sSQLCommand, "isnull(C.hih_pagos_y_abonos, 0.0), "); 
      strcat(sSQLCommand, "isnull(C.hih_saldo_anterior, 0.0), ");
      strcat(sSQLCommand, "C.eje_num, E.eje_roll_over, E.eje_digit ");
      strcat(sSQLCommand, "FROM MTCHIH01 C ,MTCEJE01 D, MTCTHS01 E ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_prefijo = D.eje_prefijo ");
      strcat(sSQLCommand, " AND C.gpo_banco =  D.gpo_banco "); 
      strcat(sSQLCommand, " AND C.emp_num = D.emp_num ");
      strcat(sSQLCommand, " AND C.eje_num = D.eje_num ");
      strcat(sSQLCommand, " AND C.eje_prefijo = E.eje_prefijo ");
      strcat(sSQLCommand, " AND C.gpo_banco =  E.gpo_banco "); 
      strcat(sSQLCommand, " AND C.emp_num = E.emp_num ");
      strcat(sSQLCommand, " AND C.eje_num = E.eje_num ");
      strcat(sSQLCommand, " AND D.eje_centro_c in  ");
      strcat(sSQLCommand, " (select unit_id from MTCTEST) ");
      strcat(sSQLCommand, " AND C.hih_corte_a = ");
      strcat(sSQLCommand, psInt2Char(iSystemYear));
      strcat(sSQLCommand, " AND C.hih_corte_md = convert(int, ");
      strcat(sSQLCommand, "ltrim(rtrim(convert(char(4), ");
      strcat(sSQLCommand, psInt2Char(iSystemMonth));
      strcat(sSQLCommand, "))) + ");
      /*strcat(sSQLCommand, "ltrim(rtrim(convert(char(4), ");*/
      strcat(sSQLCommand, "replicate(\'0\',2-char_length(ltrim(rtrim(convert(char(4), ");
      strcat(sSQLCommand, psInt2Char(iSystemDay));
      strcat(sSQLCommand, ")))))+ ");
      strcat(sSQLCommand, "ltrim(rtrim(convert(char(4), ");
      strcat(sSQLCommand, psInt2Char(iSystemDay));
      strcat(sSQLCommand, ")))) ");
      strcat(sSQLCommand, "ORDER BY C.eje_num, C.eje_roll_over ");

      EXEC SQL PREPARE headersql FROM :sSQLCommand;

      EXEC SQL DECLARE headerdata CURSOR FOR headersql;
                                                
      EXEC SQL OPEN headerdata;

      for(;;)   
      {  
         dHihCurrBalance=0.0;
         dHihPrevBalance=0.0;
         iExeExeNum=0;
         iCardHRollOver=0;    
         iCardHDigit=0;     
 
         EXEC SQL FETCH headerdata                         
                  INTO :dHihCurrBalance, :dHihPrevBalance,
                       :iExeExeNum, :iCardHRollOver,
                       :iCardHDigit;  

         if(sqlca.sqlcode == 100) /* Fin de consulta. */ 
            break;

#ifdef DEBUG1
         printf("\nResult (Header): %0.2f %0.2f %d %d %d\n", 
                                            dHihCurrBalance, 
                                            dHihPrevBalance,
                                            iExeExeNum,
                                            iCardHRollOver,
                                            iCardHDigit);
#endif

         /* La informacion recuperada es almacenada en el arreglo de 
            Encabezado de Historico de Transacciones. */

         psHeaderTrans[iHeaderCount].iPreffix=iPreffix;
         psHeaderTrans[iHeaderCount].iBankGroup=iBankGroup;
         psHeaderTrans[iHeaderCount].iCompanyID=iCompanyID;
         psHeaderTrans[iHeaderCount].iExeExeNum=iExeExeNum;
         psHeaderTrans[iHeaderCount].iCardHRollOver=iCardHRollOver;
         psHeaderTrans[iHeaderCount].iCardHDigit=iCardHDigit;
         psHeaderTrans[iHeaderCount].dHihCurrBalance=dHihCurrBalance;
         psHeaderTrans[iHeaderCount].dHihPrevBalance=dHihPrevBalance;

         iHeaderCount++;

      }

      EXEC SQL CLOSE headerdata;
 
      EXEC SQL DEALLOCATE PREPARE headersql;

   }

   EXEC SQL COMMIT WORK;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      /* Determinacion de Transacciones a Procesar. */ 

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;
      iChargeOffDate=psCompanies[iCompCount].iChargeOffDate;

      iNumTransactions=0;

      strcpy(sSQLCommand, EMPSTR);

	/***
	 ***
		novena consulta obtiene # de Historico
	 ***
	 ***/


      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCHIS01 C, MTCEJE01 A, MTCTHS01 B ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand," AND C.eje_prefijo = A.eje_prefijo ");
      strcat(sSQLCommand," AND C.gpo_banco =  A.gpo_banco ");
      strcat(sSQLCommand," AND C.emp_num =  A.emp_num ");
      strcat(sSQLCommand," AND C.eje_num = A.eje_num ");
      strcat(sSQLCommand," AND C.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand," AND C.gpo_banco =  B.gpo_banco ");
      strcat(sSQLCommand," AND C.emp_num =  B.emp_num ");
      strcat(sSQLCommand," AND C.eje_num = B.eje_num ");
      strcat(sSQLCommand," AND A.eje_centro_c in ");
      strcat(sSQLCommand,"  (select unit_id from MTCTEST) ");
      strcat(sSQLCommand, " AND C.his_transaccion not in (select cve_transaccion from MTCTRA02)  ");

      /* Si el archivo a generar es de Tipo Fecha de Corte o
         si el archivo a generar es de Tipo Diario y necesita
         procesar informacion asociada con una Fecha de Corte,
         incluir en la consulta la columna 
         his_mes_y_ciclo_corte. */
 
      if((iFileTypeProc == 1) && (iChargeOffDate == iSystemDay))
      {
         strcat(sSQLCommand, " AND C.his_mes_y_ciclo_corte = ");
         strcat(sSQLCommand, "convert(int,");
         strcat(sSQLCommand, " ltrim(rtrim(convert(char(4), ");
         strcat(sSQLCommand, psInt2Char(iSystemMonth));
         strcat(sSQLCommand, "))) + ltrim(rtrim(convert(char(4), ");
         strcat(sSQLCommand, psInt2Char(iSystemDay));
         strcat(sSQLCommand, "))))");
         strcat(sSQLCommand, " AND convert(datetime, ");
         strcat(sSQLCommand, "ltrim(rtrim(convert(char(8), ");
         strcat(sSQLCommand, " C.his_proceso_amd))) + ");
         strcat(sSQLCommand, "\' 00:00:00\') BETWEEN ");
         strcat(sSQLCommand, "dateadd(mm, -1, convert(datetime, \'");
         strcat(sSQLCommand, sSystemDate);
         strcat(sSQLCommand, "\' + \' 00:00:00\')) AND ");
         strcat(sSQLCommand, "convert(datetime, \'");
         strcat(sSQLCommand, sSystemDate);
         strcat(sSQLCommand, "\' + \' 23:59:59\') ");
         strcat(sSQLCommand, " AND C.his_importe != 0.0 ");
      }
      else
      {
         strcat(sSQLCommand, " AND convert(datetime, ");
         strcat(sSQLCommand, "ltrim(rtrim(convert(char(8), ");
         strcat(sSQLCommand, " C.his_proceso_amd))) + ");
         strcat(sSQLCommand, "\' 00:00:00\') BETWEEN ");
         strcat(sSQLCommand, "convert(datetime, \'");
         strcat(sSQLCommand, sSystemDate);
         strcat(sSQLCommand, "\' + \' 00:00:00\') AND ");
         strcat(sSQLCommand, "convert(datetime, \'");
         strcat(sSQLCommand, sSystemDate);
         strcat(sSQLCommand, "\' + \' 23:59:59\') ");
         strcat(sSQLCommand, "AND C.his_importe != 0.0 ");
      } 

      EXEC SQL PREPARE counttran FROM :sSQLCommand;    

      EXEC SQL EXECUTE counttran INTO :iNumTransactions; 
                                                               
      iTotalTran+=iNumTransactions;

      EXEC SQL DEALLOCATE PREPARE counttran;

   }

   EXEC SQL COMMIT WORK;


   psTransactions=malloc(iTotalTran * sizeof(Transaction));

   if(psTransactions == NULL)
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      free(psUnits);
                     
      free(psExecutives);
                     
      free(psCardHolders);

      exit(ERREXIT);
   }

   for(iTranCount=0; iTranCount < iTotalTran; iTranCount++)
   {
      psTransactions[iTranCount].iPreffix=0;
      psTransactions[iTranCount].iBankGroup=0;
      psTransactions[iTranCount].iCompanyID=0;
      psTransactions[iTranCount].iExeExeNum=0;
      psTransactions[iTranCount].iCardHRollOver=0;
      psTransactions[iTranCount].iCardHDigit=0;
      psTransactions[iTranCount].iHisTransDate=0;
      psTransactions[iTranCount].iHisTransTime=0;
      psTransactions[iTranCount].iHisPostDate=0;
      psTransactions[iTranCount].dHisTransAmount=0.0;
      psTransactions[iTranCount].iHisReference1=0;
      psTransactions[iTranCount].dHisReference2=0.0;
      psTransactions[iTranCount].iHisTransID=0;
      psTransactions[iTranCount].iCodeSBF=0;
      psTransactions[iTranCount].iHisMerchAcepID=0;
      strcpy(psTransactions[iTranCount].sHisMerchDesc, EMPSTR);
      strcpy(psTransactions[iTranCount].sHisMerchStaPro, EMPSTR);
      strcpy(psTransactions[iTranCount].sHisMerchCountry, EMPSTR);
      psTransactions[iTranCount].dHisDollars=0.0;
   }
   
   iTranCount=0;

/*inicio de if de prueba    080105*/
if (iTotalTran > 0)
{

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;
      iChargeOffDate=psCompanies[iCompCount].iChargeOffDate;

      /* Extraccion de registros de la tabla de Historico de
         Movimientos MTCHIS01. */

      strcpy(sSQLCommand, EMPSTR);
      sSQLCommand[0] = '\0';

	/***
	 ***
		decima consulta obtiene los datos de Historico
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT isnull(C.his_valor_amd,0), C.his_time, ");
      strcat(sSQLCommand, "C.his_proceso_amd, C.his_importe, ");
      strcat(sSQLCommand, "C.his_referencia_a, C.his_referencia_b, ");
      strcat(sSQLCommand, "C.his_transaccion, C.b01_neg_num_neg, ");
      /*strcat(sSQLCommand, "C.his_negocio_leyenda, ltrim(rtrim(isnull(C.his_poblacion,' '))), ");*/
      strcat(sSQLCommand, "C.his_negocio_leyenda, C.his_poblacion, ");
      strcat(sSQLCommand, "C.his_pais, C.his_dolares, C.eje_num, ");
      strcat(sSQLCommand, "C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "TRS.trs_tran_code_sbf ");
      strcat(sSQLCommand, "FROM MTCHIS01 C,MTCEJE01 A,MTCTHS01 B,MTCTRS01 TRS");
      strcat(sSQLCommand, " WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.his_transaccion = TRS.trs_cve_tran ");
      strcat(sSQLCommand," AND C.eje_prefijo = A.eje_prefijo ");
      strcat(sSQLCommand," AND C.gpo_banco =  A.gpo_banco ");
      strcat(sSQLCommand," AND C.emp_num =  A.emp_num ");
      strcat(sSQLCommand," AND C.eje_num = A.eje_num ");
      strcat(sSQLCommand," AND C.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand," AND C.gpo_banco =  B.gpo_banco ");
      strcat(sSQLCommand," AND C.emp_num =  B.emp_num ");
      strcat(sSQLCommand," AND C.eje_num = B.eje_num ");
      strcat(sSQLCommand," AND A.eje_centro_c in ");
      strcat(sSQLCommand,"  (select unit_id from MTCTEST) ");
      strcat(sSQLCommand, " AND C.his_transaccion not in (select cve_transaccion from MTCTRA02)  ");

      /* Si el archivo  a generar es de Tipo Fecha de Corte,
         incluir en la consulta la columna 
         his_mes_y_ciclo_corte. */
 
      if((iFileTypeProc == 1) && (iChargeOffDate == iSystemDay))
      {
         strcat(sSQLCommand, " AND C.his_mes_y_ciclo_corte = ");
         strcat(sSQLCommand, "convert(int,");
         strcat(sSQLCommand, " ltrim(rtrim(convert(char(4), ");
         strcat(sSQLCommand, psInt2Char(iSystemMonth));
         strcat(sSQLCommand, "))) + ltrim(rtrim(convert(char(4), ");
         strcat(sSQLCommand, psInt2Char(iSystemDay));
         strcat(sSQLCommand, "))))");
         strcat(sSQLCommand, " AND convert(datetime, ");
         strcat(sSQLCommand, "ltrim(rtrim(convert(char(8), ");
         strcat(sSQLCommand, " C.his_proceso_amd))) + ");
         strcat(sSQLCommand, "\' 00:00:00\') BETWEEN ");
         strcat(sSQLCommand, "dateadd(mm, -1, convert(datetime, \'");
         strcat(sSQLCommand, sSystemDate);
         strcat(sSQLCommand, "\' + \' 00:00:00\')) AND ");
         strcat(sSQLCommand, "convert(datetime, \'");
         strcat(sSQLCommand, sSystemDate);
         strcat(sSQLCommand, "\' + \' 23:59:59\') ");
         strcat(sSQLCommand, " AND C.his_importe != 0.0 ");
      }
      else
      {
         strcat(sSQLCommand, " AND convert(datetime, ");
         strcat(sSQLCommand, "ltrim(rtrim(convert(char(8), ");
         strcat(sSQLCommand, " C.his_proceso_amd))) + ");
         strcat(sSQLCommand, "\' 00:00:00\') BETWEEN ");
         strcat(sSQLCommand, "convert(datetime, \'");
         strcat(sSQLCommand, sSystemDate);
         strcat(sSQLCommand, "\' + \' 00:00:00\') AND ");
         strcat(sSQLCommand, "convert(datetime, \'");
         strcat(sSQLCommand, sSystemDate);
         strcat(sSQLCommand, "\' + \' 23:59:59\') ");
         strcat(sSQLCommand, " AND C.his_importe != 0.0 ");
      }

      strcat(sSQLCommand, " ORDER BY C.eje_num, C.eje_roll_over "); 

      EXEC SQL PREPARE transsql FROM :sSQLCommand;     
                                                   
      EXEC SQL DECLARE transactiondata CURSOR FOR transsql;
                           
      EXEC SQL OPEN transactiondata;            

                                                       
      for(;;) 
      {
         iHisTransDate=0; 
         iHisTransTime=0; 
         iHisPostDate=0; 
         dHisTransAmount=0.0; 
         iHisReference1=0; 
         dHisReference2=0.0; 
         iHisTransID=0;
         iHisMerchAcepID=0; 
         strcpy(sHisMerchDesc, EMPSTR); 
         strcpy(sHisMerchStaPro, EMPSTR);
         strcpy(sHisMerchCountry, EMPSTR); 
         dHisDollars=0.0;
         iExeExeNum=0;        
         iCardHRollOver=0;
         iCardHDigit=0;      
         iHisTransIDSBF=0;      

         EXEC SQL FETCH transactiondata  
                  INTO :iHisTransDate, :iHisTransTime,
                       :iHisPostDate, :dHisTransAmount,
                       :iHisReference1, :dHisReference2,
                       :iHisTransID, :iHisMerchAcepID,
                       :sHisMerchDesc, :sHisMerchStaPro,
                       :sHisMerchCountry, :dHisDollars,
                       :iExeExeNum, :iCardHRollOver,
                       :iCardHDigit, :iHisTransIDSBF;

         if(sqlca.sqlcode == 100) /* Fin de consulta. */
            break;   

#ifdef DEBUG1
         printf("\nResult (Transaction): %d, %d, %d, %0.2f, %d\n", 
                                         iHisTransDate, iHisTransTime,
                                         iHisPostDate, dHisTransAmount,
                                         iHisReference1);
                                                                               
         printf("                      %.0f, %d, %d\n", 
                                         dHisReference2, iHisTransID,
                                         iHisMerchAcepID);

         printf("                      %s, %s, %s, %0.2f\n", 
                                         sHisMerchDesc, sHisMerchStaPro,
                                         sHisMerchCountry, dHisDollars);

         printf("                      %d, %d, %d\n", 
                                         iExeExeNum, iCardHRollOver,
                                         iCardHDigit);
#endif
         /* Si his_poblacion esta vacia o con una 'E' pone le leyenda UNKNOWN*/
         if( (strcmp(sHisMerchStaPro,"") == 0) || 
             (strcmp(sHisMerchStaPro,"E") == 0) ||
             (strcmp(sHisMerchStaPro,"              ") == 0) || 
             (strcmp(sHisMerchStaPro,"           E  ") == 0)    )
            strcpy(sHisMerchStaPro,"UNKNOWN");
         /* La informacion recuperada es almacenada en el arreglo de
            Transacciones. */
         /*para transacciones con monto cero en algunas ocasiones llega
a traer la fecha con cero en este caso se pone la misma de posteo*/
         if( iHisTransDate == 0)
               iHisTransDate=iHisPostDate;
         psTransactions[iTranCount].iPreffix=iPreffix;
         psTransactions[iTranCount].iBankGroup=iBankGroup;
         psTransactions[iTranCount].iCompanyID=iCompanyID;
         psTransactions[iTranCount].iExeExeNum=iExeExeNum;
         psTransactions[iTranCount].iCardHRollOver=iCardHRollOver;
         psTransactions[iTranCount].iCardHDigit=iCardHDigit;
         psTransactions[iTranCount].iHisTransDate=iHisTransDate;
         psTransactions[iTranCount].iHisTransTime=iHisTransTime;
         psTransactions[iTranCount].iHisPostDate=iHisPostDate;
         psTransactions[iTranCount].dHisTransAmount=dHisTransAmount;
         psTransactions[iTranCount].iHisReference1=iHisReference1;
         psTransactions[iTranCount].dHisReference2=dHisReference2;
         psTransactions[iTranCount].iHisTransID=iHisTransID;
         psTransactions[iTranCount].iCodeSBF=iHisTransIDSBF;      
         psTransactions[iTranCount].iHisMerchAcepID=iHisMerchAcepID;
         strcpy(psTransactions[iTranCount].sHisMerchDesc, sHisMerchDesc);
         strcpy(psTransactions[iTranCount].sHisMerchStaPro, sHisMerchStaPro);
         strcpy(psTransactions[iTranCount].sHisMerchCountry, sHisMerchCountry);
         psTransactions[iTranCount].dHisDollars=dHisDollars;


         iTranCount++;

      }

      EXEC SQL CLOSE transactiondata;      
                                     
      EXEC SQL DEALLOCATE PREPARE transsql;

      EXEC SQL COMMIT WORK;

   }
}
/*fin de if de prueba    080105*/


      sSQLCommand[0]='\0';
      strcpy(sSQLCommand, "if exists( select * from sysobjects ");
      strcat(sSQLCommand, " where name=\'MTCTEST\') ");
      strcat(sSQLCommand, "begin  ");
      strcat(sSQLCommand, " drop table MTCTEST ");
      strcat(sSQLCommand, "end  ");
      EXEC SQL EXECUTE IMMEDIATE :sSQLCommand;


   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      /* Determinacion de Transacciones Especiales a Procesar
         (Gastos de Avion). */ 

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      iNumAirlineTran=0;

	/***
	 ***
		undecima consulta obtiene el # de aerolineas
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCAER01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.aer_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.aer_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.aer_message_id)"); 
 
      EXEC SQL PREPARE countairtr FROM :sSQLCommand;
 
      EXEC SQL EXECUTE countairtr INTO :iNumAirlineTran;
 
      iTotalAirTran+=iNumAirlineTran;
 
      EXEC SQL DEALLOCATE PREPARE countairtr;

   }

   EXEC SQL COMMIT WORK;

   psAirlineTrans=malloc(iTotalAirTran * sizeof(AirlineTran));

   if(psAirlineTrans == NULL)
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      free(psUnits);
                     
      free(psExecutives);
                     
      free(psCardHolders);
                     
      free(psTransactions);
                     
      free(psHeaderTrans);
                     
      exit(ERREXIT);
   }

   for(iAirTranCount=0; iAirTranCount < iTotalAirTran; iAirTranCount++)
   {
      psAirlineTrans[iAirTranCount].iPreffix=0;
      psAirlineTrans[iAirTranCount].iBankGroup=0;
      psAirlineTrans[iAirTranCount].iCompanyID=0;
      psAirlineTrans[iAirTranCount].iExeExeNum=0;
      psAirlineTrans[iAirTranCount].iCardHRollOver=0;
      psAirlineTrans[iAirTranCount].iCardHDigit=0;
      psAirlineTrans[iAirTranCount].iMessageID=0;
      strcpy(psAirlineTrans[iAirTranCount].sHisRefNumber, EMPSTR);
      psAirlineTrans[iAirTranCount].dAirTotFareAmt=0.0;
      psAirlineTrans[iAirTranCount].dAirTotTaxAmt=0.0;
      psAirlineTrans[iAirTranCount].dAirNatTaxAmt=0.0;
      psAirlineTrans[iAirTranCount].dAirTotFeeAmt=0.0;
      strcpy(psAirlineTrans[iAirTranCount].sAirTicketNum, EMPSTR);
      strcpy(psAirlineTrans[iAirTranCount].sAirExchgTicketNum, EMPSTR);
      strcpy(psAirlineTrans[iAirTranCount].sAirExchgTicketAmt, EMPSTR);
      strcpy(psAirlineTrans[iAirTranCount].sAirTraAgenCode, EMPSTR);
      strcpy(psAirlineTrans[iAirTranCount].sAirTraAgenName, EMPSTR);
      strcpy(psAirlineTrans[iAirTranCount].sAirPassName, EMPSTR);
      psAirlineTrans[iAirTranCount].iAirDepartDate=0;
      strcpy(psAirlineTrans[iAirTranCount].sAirOrigCode, EMPSTR);
      strcpy(psAirlineTrans[iAirTranCount].sAirInternetInd, EMPSTR);
      strcpy(psAirlineTrans[iAirTranCount].sAirElectTicketNum, EMPSTR);
   }
   
   iAirTranCount=0;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* duodecima consulta Extraccion de registros de la tabla de 
         Aerolineas MTCAER01. */ 

      strcpy(sSQLCommand, "SELECT isnull(C.aer_total_fare_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aer_total_tax_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aer_national_tax_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aer_total_fee_amount, 0.0), ");
      strcat(sSQLCommand, "C.aer_airline_ticket_number, ");
      strcat(sSQLCommand, "isnull(C.aer_exchange_ticket_number, \' \'), ");
      strcat(sSQLCommand, "isnull(C.aer_exchange_ticket_amount, \' \'), ");
      strcat(sSQLCommand, "isnull(C.aer_travel_agency_code, \' \'), ");
      strcat(sSQLCommand, "isnull(C.aer_travel_agency_name, \' \'), ");
      strcat(sSQLCommand, "C.aer_passenger_name, ");
      strcat(sSQLCommand, "C.aer_departure_date, ");
      strcat(sSQLCommand, "isnull(C.aer_origination_code, \' \'), ");
      strcat(sSQLCommand, "isnull(C.aer_internet_indicator, \' \'), ");
      strcat(sSQLCommand, "isnull(C.aer_electronic_ticket_ind, \' \'), ");
      strcat(sSQLCommand, "C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.aer_message_id, C.aer_reference_number "); 
      strcat(sSQLCommand, "FROM MTCAER01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.aer_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.aer_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.aer_message_id) "); 
      strcat(sSQLCommand, "ORDER BY C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.aer_message_id, C.aer_reference_number");

      EXEC SQL PREPARE airlinesql FROM :sSQLCommand;     
                                                   
      EXEC SQL DECLARE airlinedata CURSOR FOR airlinesql;
                           
      EXEC SQL OPEN airlinedata;            

      for(;;)   
      {
         dAirTotFareAmt=0.0;
         dAirTotTaxAmt=0.0;
         dAirNatTaxAmt=0.0;
         dAirTotFeeAmt=0.0;
         strcpy(sAirTicketNum, EMPSTR);
         strcpy(sAirExchgTicketNum, EMPSTR);
         strcpy(sAirExchgTicketAmt, EMPSTR);
         strcpy(sAirTraAgenCode, EMPSTR);
         strcpy(sAirTraAgenName, EMPSTR);
         strcpy(sAirPassName, EMPSTR);
         iAirDepartDate=0;
         strcpy(sAirOrigCode, EMPSTR);
         strcpy(sAirInternetInd, EMPSTR);
         strcpy(sAirElectTicketNum, EMPSTR);
         iExeExeNum=0;
         iCardHRollOver=0;
         iCardHDigit=0;
         iHisTransID=0;
         strcpy(sHisRefNumber, EMPSTR);
                                                              
         EXEC SQL FETCH airlinedata 
                  INTO :dAirTotFareAmt, :dAirTotTaxAmt,
                       :dAirNatTaxAmt, :dAirTotFeeAmt,
                       :sAirTicketNum, 
                       :sAirExchgTicketNum,
                       :sAirExchgTicketAmt, 
                       :sAirTraAgenCode,
                       :sAirTraAgenName, :sAirPassName,
                       :iAirDepartDate, :sAirOrigCode,
                       :sAirInternetInd, 
                       :sAirElectTicketNum, :iExeExeNum,
                       :iCardHRollOver, :iCardHDigit,
                       :iHisTransID, :sHisRefNumber;
                                                           
         if(sqlca.sqlcode == 100) /* Fin de consulta. */
            break;                                      
                                                              
#ifdef DEBUG1
         printf("\nResult (Airline): %0.2f, %0.2f, %0.2f, %0.2f\n",
                                     dAirTotFareAmt, dAirTotTaxAmt,
                                     dAirNatTaxAmt, dAirTotFeeAmt);
         printf("                  %s, %s, %s, %s\n",
                                   sAirTicketNum, 
                                   sAirExchgTicketNum,
                                   sAirExchgTicketAmt, 
                                   sAirTraAgenCode);
         printf("                  %s, %s, %d, %s\n",
                                   sAirTraAgenName, sAirPassName,
                                   iAirDepartDate, sAirOrigCode);
         printf("                  %s, %s, %d, %d\n",
                                   sAirInternetInd,
                                   sAirElectTicketNum,
                                   iExeExeNum, iCardHRollOver);
         printf("                  %d, %d, %s\n",
                                   iCardHDigit,
                                   iHisTransID,
                                   sHisRefNumber);
#endif

         /* La informacion es almacenada en el arreglo de
            Transacciones de Gastos de Avion. */

         psAirlineTrans[iAirTranCount].iPreffix=iPreffix;
         psAirlineTrans[iAirTranCount].iBankGroup=iBankGroup;
         psAirlineTrans[iAirTranCount].iCompanyID=iCompanyID;
         psAirlineTrans[iAirTranCount].iExeExeNum=iExeExeNum;
         psAirlineTrans[iAirTranCount].iCardHRollOver=iCardHRollOver;
         psAirlineTrans[iAirTranCount].iCardHDigit=iCardHDigit;
         psAirlineTrans[iAirTranCount].iMessageID=iHisTransID;
         strcpy(psAirlineTrans[iAirTranCount].sHisRefNumber, sHisRefNumber);
         psAirlineTrans[iAirTranCount].dAirTotFareAmt=dAirTotFareAmt;
         psAirlineTrans[iAirTranCount].dAirTotTaxAmt=dAirTotTaxAmt;
         psAirlineTrans[iAirTranCount].dAirNatTaxAmt=dAirNatTaxAmt;
         psAirlineTrans[iAirTranCount].dAirTotFeeAmt=dAirTotFeeAmt;
         strcpy(psAirlineTrans[iAirTranCount].sAirTicketNum, sAirTicketNum);
         strcpy(psAirlineTrans[iAirTranCount].sAirExchgTicketNum, sAirExchgTicketNum);
         strcpy(psAirlineTrans[iAirTranCount].sAirExchgTicketAmt, sAirExchgTicketAmt);
         strcpy(psAirlineTrans[iAirTranCount].sAirTraAgenCode, sAirTraAgenCode);
         strcpy(psAirlineTrans[iAirTranCount].sAirTraAgenName, sAirTraAgenName);
         strcpy(psAirlineTrans[iAirTranCount].sAirPassName, sAirPassName);
         psAirlineTrans[iAirTranCount].iAirDepartDate=iAirDepartDate;
         strcpy(psAirlineTrans[iAirTranCount].sAirOrigCode, sAirOrigCode);
         strcpy(psAirlineTrans[iAirTranCount].sAirInternetInd, sAirInternetInd);
         strcpy(psAirlineTrans[iAirTranCount].sAirElectTicketNum, sAirElectTicketNum);

         iAirTranCount++;
 
      }

      EXEC SQL CLOSE airlinedata;      
                                     
      EXEC SQL DEALLOCATE PREPARE airlinesql;

      EXEC SQL COMMIT WORK;

   }

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      /* Determinacion de Escalas asociadas a un Vuelo de Avion 
         determinado (Gastos de Avion). */ 

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      iNumScales=0;

	/***
	 ***
		treceava consulta obtiene las escalas de los vuelos
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCESC01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.esc_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.esc_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.esc_message_id)"); 

      EXEC SQL PREPARE countscals FROM :sSQLCommand;
 
      EXEC SQL EXECUTE countscals INTO :iNumScales;
 
      iTotalScales+=iNumScales;
 
      EXEC SQL DEALLOCATE PREPARE countscals;

   }

   EXEC SQL COMMIT WORK;

   psScales=malloc(iTotalScales * sizeof(ScalesGroup));

   if(psScales == NULL)
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      free(psUnits);
                     
      free(psExecutives);
                     
      free(psCardHolders);
                     
      free(psTransactions);
                     
      free(psHeaderTrans);
                     
      free(psAirlineTrans);

      exit(ERREXIT);
   }

   for(iScalesCount=0; iScalesCount < iTotalScales; iScalesCount++)
   {
      psScales[iScalesCount].iPreffix=0;
      psScales[iScalesCount].iBankGroup=0;
      psScales[iScalesCount].iCompanyID=0;
      psScales[iScalesCount].iExeExeNum=0;
      psScales[iScalesCount].iCardHRollOver=0;
      psScales[iScalesCount].iCardHDigit=0;
      psScales[iScalesCount].iMessageID=0;
      strcpy(psScales[iScalesCount].sHisRefNumber, EMPSTR);
      strcpy(psScales[iScalesCount].sAirlineStopOver, EMPSTR);
      strcpy(psScales[iScalesCount].sDestination, EMPSTR);
      strcpy(psScales[iScalesCount].sAirlineCarrierCode, EMPSTR);
      strcpy(psScales[iScalesCount].sAirlineServClass, EMPSTR);
      strcpy(psScales[iScalesCount].sFlightNum, EMPSTR);
   }
   
   iScalesCount=0;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* Extraccion de registros de la tabla de
         Escalas de Vuelos MTCESC01. */

	/***
	 ***
		catorceava consulta obtiene las escalas de los vuelos
	 ***
	 ***/


      strcpy(sSQLCommand, "SELECT isnull(C.esc_airline_stop_over, \' \'), ");
      strcat(sSQLCommand, "isnull(C.esc_destination, \' \'), ");
      strcat(sSQLCommand, "isnull(C.esc_airline_carrier_code, \' \'), ");
      strcat(sSQLCommand, "isnull(C.esc_airline_service_class, \' \'), ");
      strcat(sSQLCommand, "C.esc_flight_number, C.eje_num, ");
      strcat(sSQLCommand, "C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.esc_message_id, C.esc_reference_number ");
      strcat(sSQLCommand, "FROM MTCESC01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.esc_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.esc_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.esc_message_id) "); 
      strcat(sSQLCommand, "ORDER BY C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.esc_message_id, C.esc_reference_number");

      EXEC SQL PREPARE scalesql FROM :sSQLCommand;     
                                                   
      EXEC SQL DECLARE scaledata CURSOR FOR scalesql;
                           
      EXEC SQL OPEN scaledata;            

      for(;;)   
      {
         strcpy(sScaStopOver, EMPSTR); 
         strcpy(sScaDest, EMPSTR);
         strcpy(sScaCarrCode, EMPSTR);
         strcpy(sScaServClass, EMPSTR);
         strcpy(sScaFlightNum, EMPSTR);
         iExeExeNum=0;
         iCardHRollOver=0;
         iCardHDigit=0;
         iHisTransID=0;
         strcpy(sHisRefNumber, EMPSTR);

         EXEC SQL FETCH scaledata  
                  INTO :sScaStopOver, :sScaDest,
                       :sScaCarrCode, :sScaServClass,
                       :sScaFlightNum, :iExeExeNum,
                       :iCardHRollOver, :iCardHDigit,
                       :iHisTransID, :sHisRefNumber;

         if(sqlca.sqlcode == 100) /* Fin de consulta. */
            break;   

#ifdef DEBUG1
            printf("\nResult (Scale): %s, %s, %s, %s, %s\n",
                                      sScaStopOver, sScaDest,
                                      sScaCarrCode, sScaServClass,
                                      sScaFlightNum);
            printf("                %d, %d, %d, %d, %s\n",
                                    iExeExeNum, iCardHRollOver,
                                    iCardHDigit, iHisTransID,
                                    sHisRefNumber);
#endif

         /* La informacion es almacenada en el arreglo de
            Escalas. */

         psScales[iScalesCount].iPreffix=iPreffix;
         psScales[iScalesCount].iBankGroup=iBankGroup;
         psScales[iScalesCount].iCompanyID=iCompanyID;
         psScales[iScalesCount].iExeExeNum=iExeExeNum;
         psScales[iScalesCount].iCardHRollOver=iCardHRollOver;
         psScales[iScalesCount].iCardHDigit=iCardHDigit;
         psScales[iScalesCount].iMessageID=iHisTransID;
         strcpy(psScales[iScalesCount].sHisRefNumber, sHisRefNumber);
         strcpy(psScales[iScalesCount].sAirlineStopOver, sScaStopOver);
         strcpy(psScales[iScalesCount].sDestination, sScaDest);
         strcpy(psScales[iScalesCount].sAirlineCarrierCode, sScaCarrCode);
         strcpy(psScales[iScalesCount].sAirlineServClass, sScaServClass);
         strcpy(psScales[iScalesCount].sFlightNum, sScaFlightNum);

         iScalesCount++;
 
      }

      EXEC SQL CLOSE scaledata;      
                                     
      EXEC SQL DEALLOCATE PREPARE scalesql;

      EXEC SQL COMMIT WORK;

   }


   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      /* Determinacion de Transacciones Especiales a Procesar
         (Gastos por Compras). */

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      iNumPurchasingTran=0;

	/***
	 ***
		quinceava consulta obtiene el # de compras
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCCOM01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.com_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.com_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.com_message_id)"); 

      EXEC SQL PREPARE countpurtr FROM :sSQLCommand;
 
      EXEC SQL EXECUTE countpurtr INTO :iNumPurchasingTran;
 
      iTotalPurTran+=iNumPurchasingTran;
 
      EXEC SQL DEALLOCATE PREPARE countpurtr;

   }

   EXEC SQL COMMIT WORK;

   psPurchTrans=malloc(iTotalPurTran * sizeof(PurchasingTran));

   if(psPurchTrans == NULL)
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      free(psUnits);
                     
      free(psExecutives);
                     
      free(psCardHolders);
                     
      free(psTransactions);
                     
      free(psHeaderTrans);
                     
      free(psAirlineTrans);
                     
      free(psScales);

      exit(ERREXIT);
   }

   for(iPurchTranCount=0; iPurchTranCount < iTotalPurTran; iPurchTranCount++)
   {
      psPurchTrans[iPurchTranCount].iPreffix=0;
      psPurchTrans[iPurchTranCount].iBankGroup=0;
      psPurchTrans[iPurchTranCount].iCompanyID=0;
      psPurchTrans[iPurchTranCount].iExeExeNum=0;
      psPurchTrans[iPurchTranCount].iCardHRollOver=0;
      psPurchTrans[iPurchTranCount].iCardHDigit=0;
      psPurchTrans[iPurchTranCount].iMessageID=0;
      strcpy(psPurchTrans[iPurchTranCount].sHisRefNumber, EMPSTR);
      psPurchTrans[iPurchTranCount].iPurDetSeqNum=0;
      psPurchTrans[iPurchTranCount].iPurOrderDate=0;
      strcpy(psPurchTrans[iPurchTranCount].sPurDestZipCode, EMPSTR);
      strcpy(psPurchTrans[iPurchTranCount].sPurDestCountry, EMPSTR);
      strcpy(psPurchTrans[iPurchTranCount].sPurOrigZipCode, EMPSTR);
      psPurchTrans[iPurchTranCount].dPurFreightAmt=0.0;
      psPurchTrans[iPurchTranCount].dPurFreightVATTaxAmt=0.0;
      psPurchTrans[iPurchTranCount].dPurFreightVATTaxRat=0.0;
      strcpy(psPurchTrans[iPurchTranCount].sPurCommCode, EMPSTR);
      strcpy(psPurchTrans[iPurchTranCount].sPurDescription, EMPSTR);
      strcpy(psPurchTrans[iPurchTranCount].sPurProductCode, EMPSTR);
      psPurchTrans[iPurchTranCount].dPurQuantity=0.0;
      strcpy(psPurchTrans[iPurchTranCount].sPurUnitMeasure, EMPSTR);
      psPurchTrans[iPurchTranCount].dPurUnitCost=0.0;
      psPurchTrans[iPurchTranCount].dPurVATTaxAmt=0.0;
      psPurchTrans[iPurchTranCount].dPurVATTaxRat=0.0;
      strcpy(psPurchTrans[iPurchTranCount].sPurVATInvRefNum, EMPSTR);
      psPurchTrans[iPurchTranCount].dPurDiscPerItem=0.0;
      psPurchTrans[iPurchTranCount].dPurLineItemTot=0.0;
   }
   
   iPurchTranCount=0;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* Extraccion de registros de la tabla de 
         Compras MTCCOM01. */ 

	/***
	 ***
		dieciseisava consulta obtiene los datos de compras
	 ***
	 ***/

      strcpy(sSQLCommand, "SELECT C.com_purch_detail_seq_number, ");
      strcat(sSQLCommand, "C.com_order_date, ");
      strcat(sSQLCommand, "isnull(C.com_destination_zip_code, \' \'), ");
      strcat(sSQLCommand, "isnull(C.com_destination_country_code, \' \'), ");
      strcat(sSQLCommand, "C.com_origination_zip_code, ");
      strcat(sSQLCommand, "isnull(C.com_freight_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.com_freight_vat_tax_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.com_freight_vat_tax_rate, 0.0), ");
      strcat(sSQLCommand, "isnull(C.com_commodity_code, \' \'), ");
      strcat(sSQLCommand, "C.com_description, ");
      strcat(sSQLCommand, "isnull(C.com_product_code, \' \'), ");
      strcat(sSQLCommand, "C.com_quantity, "); 
      strcat(sSQLCommand, "isnull(C.com_unit_measure, \' \'), ");
      strcat(sSQLCommand, "C.com_unit_cost, "); 
      strcat(sSQLCommand, "isnull(C.com_vat_tax_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.com_vat_tax_rate, 0.0), ");
      strcat(sSQLCommand, "isnull(C.com_unique_vat_inv_ref_number, \' \'), ");
      strcat(sSQLCommand, "isnull(C.com_discount_pline_item, 0.0), ");
      strcat(sSQLCommand, "isnull(C.com_line_item_total, 0.0), ");
      strcat(sSQLCommand, "C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.com_message_id, C.com_reference_number ");
      strcat(sSQLCommand, "FROM MTCCOM01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.com_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.com_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.com_message_id) "); 
      strcat(sSQLCommand, "ORDER BY C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.com_message_id, C.com_reference_number");

      EXEC SQL PREPARE purchsql FROM :sSQLCommand;     
                                                   
      EXEC SQL DECLARE purchasingdata CURSOR FOR purchsql;
                           
      EXEC SQL OPEN purchasingdata;            

      for(;;)   
      {
         iPurDetSeqNum=0;
         iPurOrderDate=0;
         strcpy(sPurDestZipCode, EMPSTR);
         strcpy(sPurDestCountry, EMPSTR);
         strcpy(sPurOrigZipCode, EMPSTR);
         dPurFreightAmt=0.0;
         dPurFreightVATTaxAmt=0.0;
         dPurFreightVATTaxRat=0.0;
         strcpy(sPurCommCode, EMPSTR);
         strcpy(sPurDescription, EMPSTR);
         strcpy(sPurProductCode, EMPSTR);
         dPurQuantity=0.0;
         strcpy(sPurUnitMeasure, EMPSTR);
         dPurUnitCost=0.0;
         dPurVATTaxAmt=0.0;
         dPurVATTaxRat=0.0;
         strcpy(sPurVATInvRefNum, EMPSTR);
         dPurDiscPerItem=0.0;
         dPurLineItemTot=0.0;
         iExeExeNum=0;
         iCardHRollOver=0;
         iCardHDigit=0;
         iHisTransID=0;
         strcpy(sHisRefNumber, EMPSTR);
                                                              
         EXEC SQL FETCH purchasingdata 
                  INTO :iPurDetSeqNum, :iPurOrderDate,
                       :sPurDestZipCode, 
                       :sPurDestCountry,
                       :sPurOrigZipCode, 
                       :dPurFreightAmt,
                       :dPurFreightVATTaxAmt, 
                       :dPurFreightVATTaxRat,
                       :sPurCommCode, :sPurDescription,
                       :sPurProductCode, :dPurQuantity,
                       :sPurUnitMeasure, :dPurUnitCost,
                       :dPurVATTaxAmt, :dPurVATTaxRat,
                       :sPurVATInvRefNum, 
                       :dPurDiscPerItem,
                       :dPurLineItemTot, :iExeExeNum,
                       :iCardHRollOver, :iCardHDigit,
                       :iHisTransID, :sHisRefNumber;
                                                              
         if(sqlca.sqlcode == 100) /* Fin de consulta. */
            break;                                      
                                                              
#ifdef DEBUG1
         printf("\nResult (Purchasing): %d, %d, %s, %s\n",
                                        iPurDetSeqNum, iPurOrderDate,
                                        sPurDestZipCode, sPurDestCountry);
         printf("                     %s, %0.2f, %0.2f, %0.2f\n",
                                   sPurOrigZipCode, dPurFreightAmt,
                                   dPurFreightVATTaxAmt, 
                                   dPurFreightVATTaxRat);
         printf("                     %s, %s, %s, %0.2f\n",
                                   sPurCommCode, sPurDescription,
                                   sPurProductCode, dPurQuantity);
         printf("                     %s, %0.2f, %0.2f, %0.2f\n",
                                   sPurUnitMeasure, dPurUnitCost,
                                   dPurVATTaxAmt, dPurVATTaxRat);
         printf("                     %s, %0.2f, %0.2f, %d\n",
                                   sPurVATInvRefNum, dPurDiscPerItem,
                                   dPurLineItemTot, iExeExeNum);
         printf("                     %d, %d, %d, %s\n",
                                   iCardHRollOver, iCardHDigit,
                                   iHisTransID, sHisRefNumber);
#endif


         /* La informacion es almacenada en el arreglo de
            Gastos por Compras. */

         psPurchTrans[iPurchTranCount].iPreffix=iPreffix;
         psPurchTrans[iPurchTranCount].iBankGroup=iBankGroup;
         psPurchTrans[iPurchTranCount].iCompanyID=iCompanyID;
         psPurchTrans[iPurchTranCount].iExeExeNum=iExeExeNum;
         psPurchTrans[iPurchTranCount].iCardHRollOver=iCardHRollOver;
         psPurchTrans[iPurchTranCount].iCardHDigit=iCardHDigit;
         psPurchTrans[iPurchTranCount].iMessageID=iHisTransID;
         strcpy(psPurchTrans[iPurchTranCount].sHisRefNumber, sHisRefNumber);
         psPurchTrans[iPurchTranCount].iPurDetSeqNum=iPurDetSeqNum;
         psPurchTrans[iPurchTranCount].iPurOrderDate=iPurOrderDate;
         strcpy(psPurchTrans[iPurchTranCount].sPurDestZipCode, sPurDestZipCode);
         strcpy(psPurchTrans[iPurchTranCount].sPurDestCountry, sPurDestCountry);
         strcpy(psPurchTrans[iPurchTranCount].sPurOrigZipCode, sPurOrigZipCode);
         psPurchTrans[iPurchTranCount].dPurFreightAmt=dPurFreightAmt;
         psPurchTrans[iPurchTranCount].dPurFreightVATTaxAmt=dPurFreightVATTaxAmt;
         psPurchTrans[iPurchTranCount].dPurFreightVATTaxRat=dPurFreightVATTaxRat;
         strcpy(psPurchTrans[iPurchTranCount].sPurCommCode, sPurCommCode);
         strcpy(psPurchTrans[iPurchTranCount].sPurDescription, sPurDescription);
         strcpy(psPurchTrans[iPurchTranCount].sPurProductCode, sPurProductCode);
         psPurchTrans[iPurchTranCount].dPurQuantity=dPurQuantity;
         strcpy(psPurchTrans[iPurchTranCount].sPurUnitMeasure, sPurUnitMeasure);
         psPurchTrans[iPurchTranCount].dPurUnitCost=dPurUnitCost;
         psPurchTrans[iPurchTranCount].dPurVATTaxAmt=dPurVATTaxAmt;
         psPurchTrans[iPurchTranCount].dPurVATTaxRat=dPurVATTaxRat;
         strcpy(psPurchTrans[iPurchTranCount].sPurVATInvRefNum, sPurVATInvRefNum);
         psPurchTrans[iPurchTranCount].dPurDiscPerItem=dPurDiscPerItem;
         psPurchTrans[iPurchTranCount].dPurLineItemTot=dPurLineItemTot;
         
         iPurchTranCount++;
 
      }

      EXEC SQL CLOSE purchasingdata;      
                                     
      EXEC SQL DEALLOCATE PREPARE purchsql;

      EXEC SQL COMMIT WORK;

   }


   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      /* Determinacion de Transacciones Especiales a Procesar
         (Gastos por Hospedaje). */

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      iNumLodgingTran=0;

	/***
	 ***
	diecisieteava consulta obtiene el # de transacciones especiales hospedaje
	 ***
	***/

      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCHOS01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.hos_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.hos_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.hos_message_id)"); 

      EXEC SQL PREPARE countlodtr FROM :sSQLCommand;
 
      EXEC SQL EXECUTE countlodtr INTO :iNumLodgingTran;
 
      iTotalLodTran+=iNumLodgingTran;
 
      EXEC SQL DEALLOCATE PREPARE countlodtr;

   }

   EXEC SQL COMMIT WORK;

   psLodTrans=malloc(iTotalLodTran * sizeof(LodgingTran));

   if(psLodTrans == NULL)
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      free(psUnits);
                     
      free(psExecutives);
                     
      free(psCardHolders);
                     
      free(psTransactions);
                     
      free(psHeaderTrans);
                     
      free(psAirlineTrans);
                     
      free(psScales);
                     
      free(psPurchTrans);
                     
      exit(ERREXIT);
   }

   for(iLodTranCount=0; iLodTranCount < iTotalLodTran; iLodTranCount++)
   {
      psLodTrans[iLodTranCount].iPreffix=0;
      psLodTrans[iLodTranCount].iBankGroup=0;
      psLodTrans[iLodTranCount].iCompanyID=0;
      psLodTrans[iLodTranCount].iExeExeNum=0;
      psLodTrans[iLodTranCount].iCardHRollOver=0;
      psLodTrans[iLodTranCount].iCardHDigit=0;
      psLodTrans[iLodTranCount].iMessageID=0;
      strcpy(psLodTrans[iLodTranCount].sHisRefNumber, EMPSTR);
      psLodTrans[iLodTranCount].iLodDetSeqNum=0;             
      strcpy(psLodTrans[iLodTranCount].sLodPropTelNumber, EMPSTR);
      strcpy(psLodTrans[iLodTranCount].sLodCustTelNumber, EMPSTR);
      psLodTrans[iLodTranCount].iLodCheckInDate=0;
      psLodTrans[iLodTranCount].iLodCheckOutDate=0;
      strcpy(psLodTrans[iLodTranCount].sLodNoShowInd, EMPSTR);
      psLodTrans[iLodTranCount].dLodTotAutAmt=0.0;
      psLodTrans[iLodTranCount].dLodPrepaidExp=0.0;
      psLodTrans[iLodTranCount].iLodNumRoomNights=0;
      psLodTrans[iLodTranCount].dLodDayRoomRate=0.0;
      psLodTrans[iLodTranCount].dLodVATTaxAmt=0.0;
      psLodTrans[iLodTranCount].dLodVATTaxRate=0.0;
      psLodTrans[iLodTranCount].dLodRoomTaxAmt=0.0;
      strcpy(psLodTrans[iLodTranCount].sLodVATInvRefNum, EMPSTR);
      psLodTrans[iLodTranCount].dLodDiscAmt=0.0;
      psLodTrans[iLodTranCount].dLodFoodBevCharges=0.0;
      psLodTrans[iLodTranCount].dLodCashAdv=0.0;
      psLodTrans[iLodTranCount].dLodValParkCharges=0.0;
      psLodTrans[iLodTranCount].dLodMiniBarCharges=0.0;
      psLodTrans[iLodTranCount].dLodLaundryCharges=0.0;
      psLodTrans[iLodTranCount].dLodPhoneCharges=0.0;
      psLodTrans[iLodTranCount].dLodGiftShopCharges=0.0;
      psLodTrans[iLodTranCount].dLodMovieCharges=0.0;
      psLodTrans[iLodTranCount].dLodBusCentCharges=0.0;
      psLodTrans[iLodTranCount].dLodHeaClubCharges=0.0;
      psLodTrans[iLodTranCount].dLodOtherCharges=0.0;
      psLodTrans[iLodTranCount].dLodTotNonRoomCharges=0.0;
   }
   
   iLodTranCount=0;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* Extraccion de registros de la tabla de
         Hospedaje MTCHOS01. */ 

	/***
	 ***
		dieciochoava consulta obtiene los datos de transacciones especiales hospedaje
	 ***
	***/

      strcpy(sSQLCommand, "SELECT C.hos_purch_detail_seq_number, ");
      strcat(sSQLCommand, "isnull(C.hos_property_tel_number, \' \'), ");
      strcat(sSQLCommand, "isnull(C.hos_cust_serv_phone_number, \' \'), ");
      strcat(sSQLCommand, "C.hos_checkin_date, "); 
      strcat(sSQLCommand, "isnull(C.hos_checkout_date, 0), ");
      strcat(sSQLCommand, "isnull(C.hos_noshow_indicator, \' \'), ");
      strcat(sSQLCommand, "isnull(C.hos_total_authorized_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_prepaid_expenses, 0.0), ");
      strcat(sSQLCommand, "C.hos_number_room_nights, ");
      strcat(sSQLCommand, "isnull(C.hos_daily_room_rate, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_vat_tax_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_vat_tax_rate, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_room_tax_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_unique_vat_inv_ref_number, \' \'), ");
      strcat(sSQLCommand, "isnull(C.hos_discount_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_food_beverage_charge, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_cash_advances, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_valet_parking_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_minibar_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_laundry_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_phone_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_gift_shop_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_movie_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_business_center_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_health_club_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_other_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.hos_total_nonroom_charges, 0.0), ");
      strcat(sSQLCommand, "C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.hos_message_id, C.hos_reference_number ");
      strcat(sSQLCommand, "FROM MTCHOS01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.hos_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.hos_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.hos_message_id) "); 
      strcat(sSQLCommand, "ORDER BY C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.hos_message_id, C.hos_reference_number");

      EXEC SQL PREPARE lodgingsql FROM :sSQLCommand;

      EXEC SQL DECLARE lodgingdata CURSOR FOR lodgingsql;

      EXEC SQL OPEN lodgingdata;

      for(;;)   
      {
         iLodDetSeqNum=0;
         strcpy(sLodPropTelNumber, EMPSTR);
         strcpy(sLodCustTelNumber, EMPSTR);
         iLodCheckInDate=0;
         iLodCheckOutDate=0;
         strcpy(sLodNoShowInd, EMPSTR);
         dLodTotAutAmt=0.0;
         dLodPrepaidExp=0.0;
         iLodNumRoomNights=0;
         dLodDayRoomRate=0.0;
         dLodVATTaxAmt=0.0;
         dLodVATTaxRate=0.0;
         dLodRoomTaxAmt=0.0;
         strcpy(sLodVATInvRefNum, EMPSTR);
         dLodDiscAmt=0.0;
         dLodFoodBevCharges=0.0;
         dLodCashAdv=0.0;
         dLodValParkCharges=0.0;
         dLodMiniBarCharges=0.0;
         dLodLaundryCharges=0.0;
         dLodPhoneCharges=0.0;
         dLodGiftShopCharges=0.0;
         dLodMovieCharges=0.0;
         dLodBusCentCharges=0.0;
         dLodHeaClubCharges=0.0;
         dLodOtherCharges=0.0;
         dLodTotNonRoomCharges=0.0;
         iExeExeNum=0;
         iCardHRollOver=0;
         iCardHDigit=0;
         iHisTransID=0;
         strcpy(sHisRefNumber, EMPSTR);
                                                             
         EXEC SQL FETCH lodgingdata 
                  INTO :iLodDetSeqNum, 
                       :sLodPropTelNumber,
                       :sLodCustTelNumber, 
                       :iLodCheckInDate,
                       :iLodCheckOutDate,
                       :sLodNoShowInd,
                       :dLodTotAutAmt,
                       :dLodPrepaidExp,
                       :iLodNumRoomNights,
                       :dLodDayRoomRate,
                       :dLodVATTaxAmt, :dLodVATTaxRate,
                       :dLodRoomTaxAmt, 
                       :sLodVATInvRefNum,
                       :dLodDiscAmt,
                       :dLodFoodBevCharges,
                       :dLodCashAdv,
                       :dLodValParkCharges,
                       :dLodMiniBarCharges, 
                       :dLodLaundryCharges,
                       :dLodPhoneCharges, 
                       :dLodGiftShopCharges,
                       :dLodMovieCharges, 
                       :dLodBusCentCharges,
                       :dLodHeaClubCharges, 
                       :dLodOtherCharges,
                       :dLodTotNonRoomCharges, :iExeExeNum,
                       :iCardHRollOver, :iCardHDigit,
                       :iHisTransID, :sHisRefNumber;
                                                             
         if(sqlca.sqlcode == 100) /* Fin de consulta. */
            break;                                      
                                                              
#ifdef DEBUG1
         printf("\nResult (Lodging): %d, %s, %s, %d\n",
                                     iLodDetSeqNum, sLodPropTelNumber,
                                     sLodCustTelNumber, iLodCheckInDate);
         printf("                  %d, %s, %0.2f, %0.2f\n",
                                   iLodCheckOutDate, sLodNoShowInd,
                                   dLodTotAutAmt, dLodPrepaidExp); 
         printf("                  %d, %0.2f, %0.2f, %0.2f\n",
                                   iLodNumRoomNights, dLodDayRoomRate,
                                   dLodVATTaxAmt, dLodVATTaxRate);
         printf("                  %0.2f, %s, %0.2f, %0.2f\n",
                                   dLodRoomTaxAmt, sLodVATInvRefNum,
                                   dLodDiscAmt, dLodFoodBevCharges);
         printf("                  %0.2f, %0.2f, %0.2f, %0.2f\n",
                                   dLodCashAdv, dLodValParkCharges,
                                   dLodMiniBarCharges,
                                   dLodLaundryCharges);
         printf("                  %0.2f, %0.2f, %0.2f, %0.2f\n",
                                   dLodPhoneCharges, dLodGiftShopCharges,
                                   dLodMovieCharges, dLodBusCentCharges);
         printf("                  %0.2f, %0.2f, %0.2f, %d\n",
                                   dLodHeaClubCharges, dLodOtherCharges,
                                   dLodTotNonRoomCharges, iExeExeNum);
         printf("                  %d, %d, %d, %s\n",
                                   iCardHRollOver, iCardHDigit,
                                   iHisTransID, sHisRefNumber);
#endif
                                                              
         /* La informacion es almacenada en el arreglo de
            Gastos por Hospedaje. */

         psLodTrans[iLodTranCount].iPreffix=iPreffix;
         psLodTrans[iLodTranCount].iBankGroup=iBankGroup;
         psLodTrans[iLodTranCount].iCompanyID=iCompanyID;
         psLodTrans[iLodTranCount].iExeExeNum=iExeExeNum;
         psLodTrans[iLodTranCount].iCardHRollOver=iCardHRollOver;
         psLodTrans[iLodTranCount].iCardHDigit=iCardHDigit;
         psLodTrans[iLodTranCount].iMessageID=iHisTransID;
         strcpy(psLodTrans[iLodTranCount].sHisRefNumber, sHisRefNumber);
         psLodTrans[iLodTranCount].iLodDetSeqNum=iLodDetSeqNum;             
         strcpy(psLodTrans[iLodTranCount].sLodPropTelNumber, sLodPropTelNumber);
         strcpy(psLodTrans[iLodTranCount].sLodCustTelNumber, sLodCustTelNumber);
         psLodTrans[iLodTranCount].iLodCheckInDate=iLodCheckInDate;
         psLodTrans[iLodTranCount].iLodCheckOutDate=iLodCheckOutDate;
         strcpy(psLodTrans[iLodTranCount].sLodNoShowInd, sLodNoShowInd);
         psLodTrans[iLodTranCount].dLodTotAutAmt=dLodTotAutAmt;
         psLodTrans[iLodTranCount].dLodPrepaidExp=dLodPrepaidExp;
         psLodTrans[iLodTranCount].iLodNumRoomNights=iLodNumRoomNights;
         psLodTrans[iLodTranCount].dLodDayRoomRate=dLodDayRoomRate;
         psLodTrans[iLodTranCount].dLodVATTaxAmt=dLodVATTaxAmt;
         psLodTrans[iLodTranCount].dLodVATTaxRate=dLodVATTaxRate;
         psLodTrans[iLodTranCount].dLodRoomTaxAmt=dLodRoomTaxAmt;
         strcpy(psLodTrans[iLodTranCount].sLodVATInvRefNum, sLodVATInvRefNum);
         psLodTrans[iLodTranCount].dLodDiscAmt=dLodDiscAmt;
         psLodTrans[iLodTranCount].dLodFoodBevCharges=dLodFoodBevCharges;
         psLodTrans[iLodTranCount].dLodCashAdv=dLodCashAdv;
         psLodTrans[iLodTranCount].dLodValParkCharges=dLodValParkCharges;
         psLodTrans[iLodTranCount].dLodMiniBarCharges=dLodMiniBarCharges;
         psLodTrans[iLodTranCount].dLodLaundryCharges=dLodLaundryCharges;
         psLodTrans[iLodTranCount].dLodPhoneCharges=dLodPhoneCharges;
         psLodTrans[iLodTranCount].dLodGiftShopCharges=dLodGiftShopCharges;
         psLodTrans[iLodTranCount].dLodMovieCharges=dLodMovieCharges;
         psLodTrans[iLodTranCount].dLodBusCentCharges=dLodBusCentCharges;
         psLodTrans[iLodTranCount].dLodHeaClubCharges=dLodHeaClubCharges;
         psLodTrans[iLodTranCount].dLodOtherCharges=dLodOtherCharges;
         psLodTrans[iLodTranCount].dLodTotNonRoomCharges=dLodTotNonRoomCharges;

         iLodTranCount++;
 
      }

      EXEC SQL CLOSE lodgingdata;      
                                     
      EXEC SQL DEALLOCATE PREPARE lodgingsql;

      EXEC SQL COMMIT WORK;

   }


   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      /* Determinacion de Transacciones Especiales a Procesar
         (Gastos por Renta de Auto(s)). */

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      iNumRentCarTran=0;

	/***
	 ***
		diecinueveava consulta obtiene el # de transacciones especiales renta autos
	 ***
	***/

      strcpy(sSQLCommand, "SELECT count(*) ");
      strcat(sSQLCommand, "FROM MTCAUT01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.aut_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.aut_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.aut_message_id)"); 

      EXEC SQL PREPARE countrentr FROM :sSQLCommand;
 
      EXEC SQL EXECUTE countrentr INTO :iNumRentCarTran;
 
      iTotalRentTran+=iNumRentCarTran;
 
      EXEC SQL DEALLOCATE PREPARE countrentr;

   }

   EXEC SQL COMMIT WORK;

   psRentTrans=malloc(iTotalRentTran * sizeof(RentCarTran));

   if(psRentTrans == NULL)
   {
      printf("\nMemory Not Available.\n");

      free(psCompanies);
                     
      free(psUnits);
                     
      free(psExecutives);
                     
      free(psCardHolders);
                     
      free(psTransactions);
                     
      free(psHeaderTrans);
                     
      free(psAirlineTrans);
                     
      free(psScales);
                     
      free(psPurchTrans);
                     
      free(psLodTrans);
                     
      exit(ERREXIT);
   }

   for(iRentTranCount=0; iRentTranCount < iTotalRentTran; iRentTranCount++)
   {
      psRentTrans[iRentTranCount].iPreffix=0;
      psRentTrans[iRentTranCount].iBankGroup=0;
      psRentTrans[iRentTranCount].iCompanyID=0;
      psRentTrans[iRentTranCount].iExeExeNum=0;
      psRentTrans[iRentTranCount].iCardHRollOver=0;
      psRentTrans[iRentTranCount].iCardHDigit=0;
      psRentTrans[iRentTranCount].iMessageID=0;
      strcpy(psRentTrans[iRentTranCount].sHisRefNumber, EMPSTR);
      psRentTrans[iRentTranCount].iCarDetSeqNum=0;
      strcpy(psRentTrans[iRentTranCount].sCarRentAgreeNum, EMPSTR);
      strcpy(psRentTrans[iRentTranCount].sCarRentName, EMPSTR);
      strcpy(psRentTrans[iRentTranCount].sCarRetCity, EMPSTR);
      strcpy(psRentTrans[iRentTranCount].sCarRetStaCtry, EMPSTR);
      strcpy(psRentTrans[iRentTranCount].sCarClassCode, EMPSTR);
      strcpy(psRentTrans[iRentTranCount].sCarNoShowInd, EMPSTR);
      psRentTrans[iRentTranCount].iCarCheckOutDate=0;
      psRentTrans[iRentTranCount].iCarCheckInDate=0;
      strcpy(psRentTrans[iRentTranCount].sCarInsInd, EMPSTR);
      psRentTrans[iRentTranCount].dCarInsCharges=0.0;
      psRentTrans[iRentTranCount].dCarTotMiles=0.0;
      psRentTrans[iRentTranCount].iCarNumDaysRent=0;
      psRentTrans[iRentTranCount].dCarDailyRate=0.0;
      psRentTrans[iRentTranCount].dCarVATTaxAmt=0.0;
      psRentTrans[iRentTranCount].dCarVATTaxRate=0.0;
      strcpy(psRentTrans[iRentTranCount].sCarVATInvRefNum, EMPSTR);
      psRentTrans[iRentTranCount].dCarWeeklyRate=0.0;
      psRentTrans[iRentTranCount].dCarRatePerMile=0.0;
      psRentTrans[iRentTranCount].dCarOneWayDropOff=0.0;
      psRentTrans[iRentTranCount].dCarRegMilCharge=0.0;
      psRentTrans[iRentTranCount].dCarExtMilCharge=0.0;
      psRentTrans[iRentTranCount].dCarMaxFreeMiles=0.0;
      psRentTrans[iRentTranCount].dCarLateRetCharge=0.0;
      psRentTrans[iRentTranCount].dCarFuelCharge=0.0;
      psRentTrans[iRentTranCount].dCarTelCharge=0.0;
      psRentTrans[iRentTranCount].dCarTowCharge=0.0;
      psRentTrans[iRentTranCount].dCarExtCharges=0.0;
      psRentTrans[iRentTranCount].dCarOthCharges=0.0;
      psRentTrans[iRentTranCount].dCarDiscAmt=0.0;
      psRentTrans[iRentTranCount].dCarLineItemTot=0.0;
   }
   
   iRentTranCount=0;

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;

      /* Extraccion de registros de la tabla de 
         Renta de Automoviles MTCAUT01. */

	/***
	 ***
		veinteava consulta obtiene los datos de transacciones especiales renta autos
	 ***
	***/

      strcpy(sSQLCommand, "SELECT C.aut_purch_detail_seq_number, ");
      strcat(sSQLCommand, "C.aut_rental_agreement_number, ");
      strcat(sSQLCommand, "C.aut_renter_name, ");
      strcat(sSQLCommand, "C.aut_location_return_city, ");
      strcat(sSQLCommand, "C.aut_return_statecountry, ");
      strcat(sSQLCommand, "isnull(C.aut_car_class_code, \' \'), ");
      strcat(sSQLCommand, "isnull(C.aut_noshow_indicator, \' \'), ");
      strcat(sSQLCommand, "C.aut_checkout_date, ");
      strcat(sSQLCommand, "isnull(C.aut_checkin_date, 0), ");
      strcat(sSQLCommand, "isnull(C.aut_insurance_indicator, \' \'), ");
      strcat(sSQLCommand, "isnull(C.aut_insurance_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_total_miles, 0.0), ");
      strcat(sSQLCommand, "C.aut_number_days_rented, C.aut_daily_rate, ");
      strcat(sSQLCommand, "isnull(C.aut_vat_tax_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_vat_tax_rate, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_unique_vat_inv_ref_number, \' \'), ");
      strcat(sSQLCommand, "isnull(C.aut_weekly_rate, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_rate_pmile, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_oneway_dropoff_charge, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_regular_mileage_charge, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_extra_mileage_charge, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_maximum_free_miles, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_late_ret_chrg_hourly_rate, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_fuel_charge, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_telephone_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_auto_towing_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_extra_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_other_charges, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_discount_amount, 0.0), ");
      strcat(sSQLCommand, "isnull(C.aut_line_item_total, 0.0), ");
      strcat(sSQLCommand, "C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.aut_message_id, C.aut_reference_number ");
      strcat(sSQLCommand, "FROM MTCAUT01 C ");
      strcat(sSQLCommand, "WHERE C.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND C.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND C.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND C.eje_num in ( ");
      strcat(sSQLCommand, "SELECT EJE.eje_num ");
      strcat(sSQLCommand, "FROM MTCEJE01 EJE ");
      strcat(sSQLCommand, "WHERE EJE.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND EJE.gpo_banco =  "); 
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND EJE.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND EJE.eje_centro_c in ( ");
      strcat(sSQLCommand, " SELECT distinct A.unit_id ");
      strcat(sSQLCommand, " FROM MTCUNI01 A ");
      strcat(sSQLCommand, " WHERE A.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND A.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND A.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));  
      strcat(sSQLCommand, " AND ((A.unit_parent_id IS null ");
      strcat(sSQLCommand, "AND A.nivel_num = 1) OR ");
      strcat(sSQLCommand, "(A.unit_parent_id in ( ");
      strcat(sSQLCommand, "SELECT distinct B.unit_id ");
      strcat(sSQLCommand, "FROM MTCUNI01 B ");
      strcat(sSQLCommand, "WHERE A.eje_prefijo = B.eje_prefijo ");
      strcat(sSQLCommand, "AND A.gpo_banco = B.gpo_banco ");
      strcat(sSQLCommand, "AND A.emp_num = B.emp_num ");
      strcat(sSQLCommand, ") AND A.nivel_num > 1 ");
      strcat(sSQLCommand, "AND A.unit_parent_id IS NOT null)))) ");
      strcat(sSQLCommand, "AND C.eje_roll_over = ( ");
      strcat(sSQLCommand, "SELECT D.eje_roll_over ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.eje_digit = ( ");
      strcat(sSQLCommand, "SELECT D.eje_digit ");
      strcat(sSQLCommand, "FROM MTCTHS01 D ");
      strcat(sSQLCommand, "WHERE D.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND D.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND D.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND D.eje_num = C.eje_num) ");
      strcat(sSQLCommand, "AND C.aut_message_id in ( ");
      strcat(sSQLCommand, "SELECT E.cve_transaccion ");
      strcat(sSQLCommand, "FROM MTCTRA01 E) ");
      strcat(sSQLCommand, "AND C.aut_reference_number in ( ");
      strcat(sSQLCommand, "SELECT convert(char(23), ");
      strcat(sSQLCommand, "replicate('0', 7 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_a, ");
      strcat(sSQLCommand, "7))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_a, 7))) + ");
      strcat(sSQLCommand, "replicate('0', 16 - ");
      strcat(sSQLCommand, "char_length(ltrim(rtrim(str(F.his_referencia_b, ");
      strcat(sSQLCommand, "16, 0))))) + ");
      strcat(sSQLCommand, "ltrim(rtrim(str(F.his_referencia_b, 16, 0)))) ");
      strcat(sSQLCommand, "FROM MTCHIS01 F ");
      strcat(sSQLCommand, "WHERE F.eje_prefijo = ");
      strcat(sSQLCommand, psInt2Char(iPreffix));
      strcat(sSQLCommand, " AND F.gpo_banco = ");
      strcat(sSQLCommand, psInt2Char(iBankGroup));
      strcat(sSQLCommand, " AND F.emp_num = ");
      strcat(sSQLCommand, psInt2Char(iCompanyID));
      strcat(sSQLCommand, " AND F.eje_num = C.eje_num ");
      strcat(sSQLCommand, "AND F.eje_roll_over = C.eje_roll_over ");
      strcat(sSQLCommand, "AND F.eje_digit = C.eje_digit ");
      strcat(sSQLCommand, "AND F.his_transaccion = C.aut_message_id) "); 
      strcat(sSQLCommand, "ORDER BY C.eje_num, C.eje_roll_over, C.eje_digit, ");
      strcat(sSQLCommand, "C.aut_message_id, C.aut_reference_number");

      EXEC SQL PREPARE rentalsql FROM :sSQLCommand;

      EXEC SQL DECLARE carrentaldata CURSOR FOR rentalsql;

      EXEC SQL OPEN carrentaldata;

      for(;;)   
      {
         iCarDetSeqNum=0;
         strcpy(sCarRentAgreeNum, EMPSTR);
         strcpy(sCarRentName, EMPSTR);
         strcpy(sCarRetCity, EMPSTR);
         strcpy(sCarRetStaCtry, EMPSTR);
         strcpy(sCarClassCode, EMPSTR);
         strcpy(sCarNoShowInd, EMPSTR);
         iCarCheckOutDate=0;
         iCarCheckInDate=0;
         strcpy(sCarInsInd, EMPSTR);
         dCarInsCharges=0.0;
         dCarTotMiles=0.0;
         iCarNumDaysRent=0;
         dCarDailyRate=0.0;
         dCarVATTaxAmt=0.0;
         dCarVATTaxRate=0.0;
         strcpy(sCarVATInvRefNum, EMPSTR);
         dCarWeeklyRate=0.0;
         dCarRatePerMile=0.0;
         dCarOneWayDropOff=0.0;
         dCarRegMilCharge=0.0;
         dCarExtMilCharge=0.0;
         dCarMaxFreeMiles=0.0;
         dCarLateRetCharge=0.0;
         dCarFuelCharge=0.0;
         dCarTelCharge=0.0;
         dCarTowCharge=0.0;
         dCarExtCharges=0.0;
         dCarOthCharges=0.0;
         dCarDiscAmt=0.0;
         dCarLineItemTot=0.0;
         iExeExeNum=0;
         iCardHRollOver=0;
         iCardHDigit=0;
         iHisTransID=0;
         strcpy(sHisRefNumber, EMPSTR);

         EXEC SQL FETCH carrentaldata 
                  INTO :iCarDetSeqNum, 
                       :sCarRentAgreeNum,
                       :sCarRentName, :sCarRetCity,    
                       :sCarRetStaCtry, :sCarClassCode, 
                       :sCarNoShowInd, 
                       :iCarCheckOutDate, 
                       :iCarCheckInDate, :sCarInsInd,
                       :dCarInsCharges, :dCarTotMiles,
                       :iCarNumDaysRent, :dCarDailyRate,
                       :dCarVATTaxAmt, :dCarVATTaxRate,
                       :sCarVATInvRefNum,
                       :dCarWeeklyRate,
                       :dCarRatePerMile, 
                       :dCarOneWayDropOff,
                       :dCarRegMilCharge, 
                       :dCarExtMilCharge,
                       :dCarMaxFreeMiles,
                       :dCarLateRetCharge,
                       :dCarFuelCharge, :dCarTelCharge,
                       :dCarTowCharge, :dCarExtCharges,
                       :dCarOthCharges, :dCarDiscAmt,
                       :dCarLineItemTot, :iExeExeNum,
                       :iCardHRollOver, :iCardHDigit,
                       :iHisTransID, :sHisRefNumber;

         if(sqlca.sqlcode == 100) /* Fin de consulta. */
            break;                                      
                                                              
#ifdef DEBUG1
         printf("\nResult (Car Rental): %d, %s, %s, %s\n",
                                        iCarDetSeqNum, sCarRentAgreeNum,
                                        sCarRentName, sCarRetCity);
         printf("                  %s, %s, %s, %d\n",
                                   sCarRetStaCtry, sCarClassCode,
                                   sCarNoShowInd, iCarCheckOutDate); 
         printf("                  %d, %s, %0.2f, %0.2f\n",
                                   iCarCheckInDate, sCarInsInd,
                                   dCarInsCharges, dCarTotMiles);
         printf("                  %d, %0.2f, %0.2f, %0.2f\n",
                                   iCarNumDaysRent, dCarDailyRate,
                                   dCarVATTaxAmt, dCarVATTaxRate);
         printf("                  %s, %0.2f, %0.2f, %0.2f\n",
                                   sCarVATInvRefNum, dCarWeeklyRate,
                                   dCarRatePerMile,
                                   dCarOneWayDropOff);
         printf("                  %0.2f, %0.2f, %0.2f, %0.2f\n",
                                   dCarRegMilCharge, dCarExtMilCharge,
                                   dCarMaxFreeMiles, dCarLateRetCharge);
         printf("                  %0.2f, %0.2f, %0.2f, %0.2f\n",
                                   dCarFuelCharge, dCarTelCharge,
                                   dCarTowCharge, dCarExtCharges);
         printf("                  %0.2f, %0.2f, %0.2f, %d\n",
                                   dCarOthCharges, dCarDiscAmt,
                                   dCarLineItemTot, iExeExeNum);
         printf("                  %d, %d, %d, %s\n",
                                   iCardHRollOver, iCardHDigit,
                                   iHisTransID, sHisRefNumber);
#endif
                                                              
         /* La informacion es almacenada en el arreglo de
            Gastos por Renta de Auto(s). */

         psRentTrans[iRentTranCount].iPreffix=iPreffix;
         psRentTrans[iRentTranCount].iBankGroup=iBankGroup;
         psRentTrans[iRentTranCount].iCompanyID=iCompanyID;
         psRentTrans[iRentTranCount].iExeExeNum=iExeExeNum;
         psRentTrans[iRentTranCount].iCardHRollOver=iCardHRollOver;
         psRentTrans[iRentTranCount].iCardHDigit=iCardHDigit;
         psRentTrans[iRentTranCount].iMessageID=iHisTransID;
         strcpy(psRentTrans[iRentTranCount].sHisRefNumber, sHisRefNumber);
         psRentTrans[iRentTranCount].iCarDetSeqNum=iCarDetSeqNum;
         strcpy(psRentTrans[iRentTranCount].sCarRentAgreeNum, sCarRentAgreeNum);
         strcpy(psRentTrans[iRentTranCount].sCarRentName, sCarRentName);
         strcpy(psRentTrans[iRentTranCount].sCarRetCity, sCarRetCity);
         strcpy(psRentTrans[iRentTranCount].sCarRetStaCtry, sCarRetStaCtry);
         strcpy(psRentTrans[iRentTranCount].sCarClassCode, sCarClassCode);
         strcpy(psRentTrans[iRentTranCount].sCarNoShowInd, sCarNoShowInd);
         psRentTrans[iRentTranCount].iCarCheckOutDate=iCarCheckOutDate;
         psRentTrans[iRentTranCount].iCarCheckInDate=iCarCheckInDate;
         strcpy(psRentTrans[iRentTranCount].sCarInsInd, sCarInsInd);
         psRentTrans[iRentTranCount].dCarInsCharges=dCarInsCharges;
         psRentTrans[iRentTranCount].dCarTotMiles=dCarTotMiles;
         psRentTrans[iRentTranCount].iCarNumDaysRent=iCarNumDaysRent;
         psRentTrans[iRentTranCount].dCarDailyRate=dCarDailyRate;
         psRentTrans[iRentTranCount].dCarVATTaxAmt=dCarVATTaxAmt;
         psRentTrans[iRentTranCount].dCarVATTaxRate=dCarVATTaxRate;
         strcpy(psRentTrans[iRentTranCount].sCarVATInvRefNum, sCarVATInvRefNum);
         psRentTrans[iRentTranCount].dCarWeeklyRate=dCarWeeklyRate;
         psRentTrans[iRentTranCount].dCarRatePerMile=dCarRatePerMile;
         psRentTrans[iRentTranCount].dCarOneWayDropOff=dCarOneWayDropOff;
         psRentTrans[iRentTranCount].dCarRegMilCharge=dCarRegMilCharge;
         psRentTrans[iRentTranCount].dCarExtMilCharge=dCarExtMilCharge;
         psRentTrans[iRentTranCount].dCarMaxFreeMiles=dCarMaxFreeMiles;
         psRentTrans[iRentTranCount].dCarLateRetCharge=dCarLateRetCharge;
         psRentTrans[iRentTranCount].dCarFuelCharge=dCarFuelCharge;
         psRentTrans[iRentTranCount].dCarTelCharge=dCarTelCharge;
         psRentTrans[iRentTranCount].dCarTowCharge=dCarTowCharge;
         psRentTrans[iRentTranCount].dCarExtCharges=dCarExtCharges;
         psRentTrans[iRentTranCount].dCarOthCharges=dCarOthCharges;
         psRentTrans[iRentTranCount].dCarDiscAmt=dCarDiscAmt;
         psRentTrans[iRentTranCount].dCarLineItemTot=dCarLineItemTot;

         iRentTranCount++;
 
      }

      EXEC SQL CLOSE carrentaldata;      
                                     
      EXEC SQL DEALLOCATE PREPARE rentalsql;

      EXEC SQL COMMIT WORK;

   }


   /* Apertura del archivo CCF. */ 
   
   if((pFileCCF = fopen(psParams[6], "w")) == NULL)
   {
      printf("\nThe file %s was not created.\n", psParams[6]);

      free(psCompanies);
                     
      free(psUnits);
                     
      free(psExecutives);
                     
      free(psCardHolders);
                     
      free(psTransactions);
                     
      free(psHeaderTrans);
                     
      free(psAirlineTrans);
                     
      free(psScales);
                     
      free(psPurchTrans);
                     
      free(psLodTrans);
                     
      free(psRentTrans);

      exit(ERREXIT);
   }

   /* Generacion del Archivo CCF. */


   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   { 

      iPreffix=psCompanies[iCompCount].iPreffix;
      iBankGroup=psCompanies[iCompCount].iBankGroup;
      iCompanyID=psCompanies[iCompCount].iCompanyID;
      strcpy(sCompanyName, psCompanies[iCompCount].sCompanyName);
      iChargeOffDate=psCompanies[iCompCount].iChargeOffDate;
      iFileType=psCompanies[iCompCount].iFileType;
      strcpy(sBillType, psCompanies[iCompCount].sBillType);
      iPayDate=psCompanies[iCompCount].iPayDate;
 
      /* Calcular la Fecha Limite de Pago asignada a los Tarjetahabientes
         de la Empresa actualmente procesada. */

      strcpy(sPayDueDate, EMPSTR);

      strcpy(sSQLCommand, "SELECT convert(char(8), ");
      strcat(sSQLCommand, "dateadd(dd, ");
      strcat(sSQLCommand, psInt2Char(iPayDate)); 
      strcat(sSQLCommand, " - 1, ");
      strcat(sSQLCommand, "convert(datetime, \'");
      strcat(sSQLCommand, sASystemDate); 
      strcat(sSQLCommand, "\')), 112)");
   

      EXEC SQL PREPARE setsdate FROM :sSQLCommand;  
                                               
      EXEC SQL EXECUTE setsdate INTO :sPayDueDate;
      

      /* Generacion y grabado en disco del Registro 0000. */
      
      

      GenRecord0000(&Rec0000, sCompanyName, atol(psUnits[0].sUniUnitID), sASystemDate);
      SaveRecord0000(&Rec0000, pFileCCF); 

      for(iUnitCount=0; iUnitCount < iTotalUnits; iUnitCount++)
      {
         /* Procesar solo aquellos elementos del arreglo de Unidades que 
            correspondan a la Empresa actualmente procesada. */

         if((psUnits[iUnitCount].iPreffix == iPreffix) &&
            (psUnits[iUnitCount].iBankGroup == iBankGroup) &&
            (psUnits[iUnitCount].iCompanyID == iCompanyID))
         {
                 
            strcpy(sUniUnitID, psUnits[iUnitCount].sUniUnitID);
            strcpy(sUniUnitPID, psUnits[iUnitCount].sUniUnitPID);
            strcpy(sUniUnitName, psUnits[iUnitCount].sUniUnitName);
/*            iUniLevelNum=psUnits[iUnitCount].iUniLevelNum;      modificado por FUN 080405*/
            iUniLevelNum=psUnits[iUnitCount].iUniLevelNum-1;
 
            /* Generacion y grabado en disco del Registro 1000 100. */
            if( atol( sUniUnitPID ) == 0 )
                strcpy( sUnitPPID, sUniUnitID );

          if( iUniLevelNum == 0 ){

              sSQLCommand[ 0 ] = '\0';

              strcpy( sSQLCommand, " select  isnull(replicate(\'0\', ");
              strcat( sSQLCommand, " PGS.pgs_long_eje - char_length(ltrim(rtrim(str( 0 ))))), \'\') ");
              strcat( sSQLCommand, " + ltrim(rtrim(str( 0 ))) , ");
              strcat( sSQLCommand, " EJE.eje_roll_over, ");
              strcat( sSQLCommand, " EJE.eje_digit ");
              strcat( sSQLCommand, " from    MTCEJE01 EJE, ");
              strcat( sSQLCommand, " MTCPGS01 PGS ");
              strcat( sSQLCommand, " where       EJE.eje_prefijo = ");
              strcat( sSQLCommand, psInt2Char(iPreffix) );
              strcat( sSQLCommand, " and EJE.gpo_banco = ");
              strcat( sSQLCommand, psInt2Char( iBankGroup ));
              strcat( sSQLCommand, " and EJE.emp_num = ");
              strcat( sSQLCommand, psInt2Char( iCompanyID ));
              strcat( sSQLCommand, " and EJE.eje_num = 0 ");
              strcat( sSQLCommand, " and PGS.pgs_rep_prefijo = EJE.eje_prefijo ");
              strcat( sSQLCommand, " and PGS.pgs_rep_banco = EJE.gpo_banco ");

              EXEC SQL PREPARE setaccount1 FROM :sSQLCommand;

              EXEC SQL EXECUTE setaccount1 INTO :sFmtExeExePNum, :iCardPRollOver, :iCardPDigit;

              sprintf(sParAccNumber, "%d%d%d%s%d%d", iPreffix,
                                                     iBankGroup,
                                                     iCompanyID,
                                                     psElimChar( sFmtExeExePNum, SPACEC ),
                                                     iCardPRollOver,
                                                     iCardPDigit );




              strcpy(sUnitPCN, sParAccNumber);
              strcat(sUnitPCN, "_");
              sprintf(sUniUnitFID, FMTZLONG5, atol( sUniUnitID ));
              strcat(sUnitPCN,sUniUnitFID); 
              GenRecord1100(&Rec1100, iPreffix, iBankGroup,
                               atol(sUnitPPID), sUnitPCN,
                               sUniUnitID, sUniUnitName,
                               iUniLevelNum);

	     

            }

            else{
                 GenRecord1100(&Rec1100, iPreffix, iBankGroup, 
                               atol(sUnitPPID), sUniUnitID, 
                               sUniUnitPID, sUniUnitName,
                               iUniLevelNum); 
            }

            SaveRecord1100(&Rec1100, pFileCCF);

            iType1000RecCnt++;

         }

      }


      for(iUnitCount=0; iUnitCount < iTotalUnits; iUnitCount++)
      {
         /* Procesar solo aquellos elementos del arreglo de Unidades que 
            correspondan a la Empresa actualmente procesada. */

         if((psUnits[iUnitCount].iPreffix == iPreffix) &&
            (psUnits[iUnitCount].iBankGroup == iBankGroup) &&
            (psUnits[iUnitCount].iCompanyID == iCompanyID))
         {
                 
            strcpy(sUniUnitID, psUnits[iUnitCount].sUniUnitID);
            strcpy(sUniUnitPID, psUnits[iUnitCount].sUniUnitPID);
            strcpy(sUniUnitName, psUnits[iUnitCount].sUniUnitName);
            iUniLevelNum=psUnits[iUnitCount].iUniLevelNum;
 
            for(iExeCount=0; iExeCount < iTotalExe; iExeCount++)
            {  
               /* Procesar solo aquellos elementos del arreglo de Ejecutivos que
                  correspondan a la Unidad actualmente procesada. */

               if((psExecutives[iExeCount].iPreffix == iPreffix) &&
                  (psExecutives[iExeCount].iBankGroup == iBankGroup) &&
                  (psExecutives[iExeCount].iCompanyID == iCompanyID) &&
                  (strcmp(psExecutives[iExeCount].sUniUnitID, sUniUnitID) == 0))
               {

                  iExeExeNum=psExecutives[iExeCount].iExeExeNum;
                  strcpy(sExeName, psExecutives[iExeCount].sExeName);
                  strcpy(sExeAddress1, psExecutives[iExeCount].sExeAddress1);
                  strcpy(sExeAddress2, psExecutives[iExeCount].sExeAddress2);
                  strcpy(sExeCity, psExecutives[iExeCount].sExeCity);
                  strcpy(sExeState, psExecutives[iExeCount].sExeState);
                  iExePostalCode=psExecutives[iExeCount].iExePostalCode;
                  strcpy(sExeTelNumber, psExecutives[iExeCount].sExeTelNumber);
                  strcpy(sExeOfficeNum, psExecutives[iExeCount].sExeOfficeNum);
                  strcpy(sExeFaxNum, psExecutives[iExeCount].sExeFaxNum);
                  strcpy(sExeRFC, psExecutives[iExeCount].sExeRFC);
                  strcpy(sExeEmail, psExecutives[iExeCount].sExeEmail);
                  strcpy(sExeEmpNum, psExecutives[iExeCount].sExeEmpNum);
                  strcpy(sExeMAccCode, psExecutives[iExeCount].sExeMAccCode);
                  iExeOpenDate=psExecutives[iExeCount].iExeOpenDate;
                  iExeCredLim=psExecutives[iExeCount].iExeCredLim;
                  strcpy(sExeEmbName, psExecutives[iExeCount].sExeEmbName);
                  iExeLastMaintDate=psExecutives[iExeCount].iExeLastMaintDate;
                  iExePerCashLim=psExecutives[iExeCount].iExePerCashLim;


                  /* Construccion del Numero de Cuenta del Tarjetahabiente. */

                  /* Formateo de los Identificadores de Empresa y de
                     Tarjetahabiente. */

                  strcpy(sFmtCompanyID, EMPSTR);
                  strcpy(sFmtExeExeNum, EMPSTR);
                  strcpy(sFmtExeExePNum, EMPSTR);

                  strcpy(sSQLCommand, "SELECT isnull(replicate(\'0\', ");
                  strcat(sSQLCommand, "pgs_long_emp - ");
                  strcat(sSQLCommand, "char_length(ltrim(rtrim(str(");
                  strcat(sSQLCommand, psInt2Char(iCompanyID));
                  strcat(sSQLCommand, "))))), '') + ltrim(rtrim(str(");
                  strcat(sSQLCommand, psInt2Char(iCompanyID));
                  strcat(sSQLCommand, "))), isnull(replicate(\'0\', ");
                  strcat(sSQLCommand, "pgs_long_eje - ");
                  strcat(sSQLCommand, "char_length(ltrim(rtrim(str("); 
                  strcat(sSQLCommand, psInt2Char(iExeExeNum));
                  strcat(sSQLCommand, "))))), '') + ltrim(rtrim(str(");
                  strcat(sSQLCommand, psInt2Char(iExeExeNum));
                  strcat(sSQLCommand, "))) ");
                  strcat(sSQLCommand, "FROM MTCPGS01 ");
                  strcat(sSQLCommand, "WHERE pgs_rep_prefijo = ");
                  strcat(sSQLCommand, psInt2Char(iPreffix));
                  strcat(sSQLCommand, " AND pgs_rep_banco = ");
                  strcat(sSQLCommand, psInt2Char(iBankGroup));
   

                  EXEC SQL PREPARE setformats1 FROM :sSQLCommand;  
                                               
                  EXEC SQL EXECUTE setformats1 INTO :sFmtCompanyID,
                                                    :sFmtExeExeNum;


                  strcpy(sFmtCompanyID, psElimChar(sFmtCompanyID, SPACEC));
                  strcpy(sFmtExeExeNum, psElimChar(sFmtExeExeNum, SPACEC));

                  for(iCardHCount=0; iCardHCount < iTotalCardH; iCardHCount++)
                  {
                     /* Procesar aquellos elementos del arreglo de 
                        Tarjetahabientes que correspondan al Ejecutivo
                        actualmente procesado. */

                     if((psCardHolders[iCardHCount].iPreffix == iPreffix) &&
                        (psCardHolders[iCardHCount].iBankGroup == iBankGroup) &&
                        (psCardHolders[iCardHCount].iCompanyID == iCompanyID) &&
                        (psCardHolders[iCardHCount].iExeExeNum == iExeExeNum))
                     {
                        iCardHRollOver=psCardHolders[iCardHCount].iCardHRollOver;
                        iCardHDigit=psCardHolders[iCardHCount].iCardHDigit;

                        strcpy(sCardHRating, psCardHolders[iCardHCount].sCardHRating);
                        iCardHLastPayDate=psCardHolders[iCardHCount].iCardHLastPayDate;
                        dCardHPayAmtDue=psCardHolders[iCardHCount].dCardHPayAmtDue;
                        dCardHChargeOffBal=psCardHolders[iCardHCount].dCardHChargeOffBal;
                        dCardHPreviewBal=psCardHolders[iCardHCount].dCardHPreviewBal;
                        dCardHCurrBal=psCardHolders[iCardHCount].dCardHCurrBal;



                        /*Obteniendo cuenta padre*/
                        sSQLCommand[ 0 ] = '\0';

                        strcpy( sSQLCommand, " select  isnull(replicate(\'0\', ");
                        strcat( sSQLCommand, " PGS.pgs_long_eje - char_length(ltrim(rtrim(str( 0 ))))), \'\') ");
                        strcat( sSQLCommand, " + ltrim(rtrim(str( 0 ))) , ");
                        strcat( sSQLCommand, " EJE.eje_roll_over, ");
                        strcat( sSQLCommand, " EJE.eje_digit ");
                        strcat( sSQLCommand, " from    MTCEJE01 EJE, ");
                        strcat( sSQLCommand, " MTCPGS01 PGS ");
                        strcat( sSQLCommand, " where       EJE.eje_prefijo = ");
                        strcat( sSQLCommand, psInt2Char(iPreffix) );
                        strcat( sSQLCommand, " and EJE.gpo_banco = ");
                        strcat( sSQLCommand, psInt2Char( iBankGroup ));
                        strcat( sSQLCommand, " and EJE.emp_num = ");
                        strcat( sSQLCommand, psInt2Char( iCompanyID ));
                        strcat( sSQLCommand, " and EJE.eje_num = 0 ");
                        strcat( sSQLCommand, " and PGS.pgs_rep_prefijo = EJE.eje_prefijo ");
                        strcat( sSQLCommand, " and PGS.pgs_rep_banco = EJE.gpo_banco ");

                        EXEC SQL PREPARE setaccount1 FROM :sSQLCommand;

                        EXEC SQL EXECUTE setaccount1 INTO :sFmtExeExePNum, :iCardPRollOver, :iCardPDigit;

                        sprintf(sParAccNumber, "%d%d%s%s%d%d", iPreffix,
                                                               iBankGroup,
                                                               sFmtCompanyID,
                                                               psElimChar( sFmtExeExePNum, SPACEC ),
                                                               iCardPRollOver,
                                                               iCardPDigit );
  
                        /* Ajuste del valor del No. de Cuenta. */
  
                        strcpy(sParAccNumberBMX, EMPSTR);
                        strcpy(sParAccNumberCB, EMPSTR);
  
                        strcpy(sParAccNumberBMX, sParAccNumber);

                        sSQLCommand[ 0 ] = '\0';
  
                        strcpy(sSQLCommand, "SELECT isnull(max(map_cta_citi), ");
                        strcat(sSQLCommand, "\' \') ");
                        strcat(sSQLCommand, "FROM MTCMAP01 ");
                        strcat(sSQLCommand, "WHERE map_cta_bnx = \'");
                        strcat(sSQLCommand, sParAccNumberBMX);
                        strcat(sSQLCommand, "\' AND map_estatus = \' \'");
 
  
                        EXEC SQL PREPARE setaccount1 FROM :sSQLCommand;

                        EXEC SQL EXECUTE setaccount1 INTO :sParAccNumberCB;
  
                        strcpy(sParAccNumberCB, psElimChar(sParAccNumberCB, SPACEC));
  
                        if(strlen(sParAccNumberCB) > 0)
                        {
                           strcpy(sParAccNumber, sParAccNumberCB);
                        }

                        /************************************************************************/

                        sprintf(sAccNumber, "%d%d%s%s%d%d", iPreffix,
                                                            iBankGroup,
                                                            sFmtCompanyID,
                                                            sFmtExeExeNum,
                                                            iCardHRollOver,
                                                            iCardHDigit);

                        /* Ajuste del valor del No. de Cuenta. */

                        strcpy(sAccNumberBMX, EMPSTR);
                        strcpy(sAccNumberCB, EMPSTR);

                        strcpy(sAccNumberBMX, sAccNumber);

                        strcpy(sSQLCommand, "SELECT isnull(max(map_cta_citi), ");
                        strcat(sSQLCommand, "\' \') ");
                        strcat(sSQLCommand, "FROM MTCMAP01 ");
                        strcat(sSQLCommand, "WHERE map_cta_bnx = \'");
                        strcat(sSQLCommand, sAccNumberBMX);
                        strcat(sSQLCommand, "\' AND map_estatus = \' \'");
   

                        EXEC SQL PREPARE setaccount1 FROM :sSQLCommand;  
                                               
                        EXEC SQL EXECUTE setaccount1 INTO :sAccNumberCB;

                        strcpy(sAccNumberCB, psElimChar(sAccNumberCB, SPACEC));

                        if(strlen(sAccNumberCB) > 0)
                        {
                           strcpy(sAccNumber, sAccNumberCB);
                        }

#ifdef DEBUG1
                        printf("\nOriginal Account: %s\n", sAccNumberBMX); 
                        printf("Mapped Account: %s\n", sAccNumber); 
#endif

                        /* Generacion y grabado en disco del Registro 
                           1001 110. */
                                                          
                        GenRecord1001(&Rec1001, atol(sUnitPPID), sUniUnitID,
                                                            sAccNumber); 
                        SaveRecord1001(&Rec1001, pFileCCF);

                        iType1001RecCnt++;

                     }

                  }

               }

            }

         }

      }


      for(iUnitCount=0; iUnitCount < iTotalUnits; iUnitCount++)
      {
         /* Procesar solo aquellos elementos del arreglo de Unidades que 
            correspondan a la Empresa actualmente procesada. */

         if((psUnits[iUnitCount].iPreffix == iPreffix) &&
            (psUnits[iUnitCount].iBankGroup == iBankGroup) &&
            (psUnits[iUnitCount].iCompanyID == iCompanyID))
         {
                 
            strcpy(sUniUnitID, psUnits[iUnitCount].sUniUnitID);
            strcpy(sUniUnitPID, psUnits[iUnitCount].sUniUnitPID);
            strcpy(sUniUnitName, psUnits[iUnitCount].sUniUnitName);
            iUniLevelNum=psUnits[iUnitCount].iUniLevelNum;
 
            for(iExeCount=0; iExeCount < iTotalExe; iExeCount++)
            {  
               /* Procesar solo aquellos elementos del arreglo de Ejecutivos que
                  correspondan a la Unidad actualmente procesada. */

               if((psExecutives[iExeCount].iPreffix == iPreffix) &&
                  (psExecutives[iExeCount].iBankGroup == iBankGroup) &&
                  (psExecutives[iExeCount].iCompanyID == iCompanyID) &&
                  (strcmp(psExecutives[iExeCount].sUniUnitID, sUniUnitID) == 0))
               {

                  iExeExeNum=psExecutives[iExeCount].iExeExeNum;
                  strcpy(sExeName, psExecutives[iExeCount].sExeName);
                  strcpy(sExeAddress1, psExecutives[iExeCount].sExeAddress1);
                  strcpy(sExeAddress2, psExecutives[iExeCount].sExeAddress2);
                  strcpy(sExeCity, psExecutives[iExeCount].sExeCity);
                  strcpy(sExeState, psExecutives[iExeCount].sExeState);
                  iExePostalCode=psExecutives[iExeCount].iExePostalCode;
                  strcpy(sExeTelNumber, psExecutives[iExeCount].sExeTelNumber);
                  strcpy(sExeOfficeNum, psExecutives[iExeCount].sExeOfficeNum);
                  strcpy(sExeFaxNum, psExecutives[iExeCount].sExeFaxNum);
                  strcpy(sExeRFC, psExecutives[iExeCount].sExeRFC);
                  strcpy(sExeEmail, psExecutives[iExeCount].sExeEmail);
                  strcpy(sExeEmpNum, psExecutives[iExeCount].sExeEmpNum);
                  strcpy(sExeMAccCode, psExecutives[iExeCount].sExeMAccCode);
                  iExeOpenDate=psExecutives[iExeCount].iExeOpenDate;
                  iExeCredLim=psExecutives[iExeCount].iExeCredLim;
                  strcpy(sExeEmbName, psExecutives[iExeCount].sExeEmbName);
                  iExeLastMaintDate=psExecutives[iExeCount].iExeLastMaintDate;
                  iExePerCashLim=psExecutives[iExeCount].iExePerCashLim;


                  /* Construccion del Numero de Cuenta del Tarjetahabiente. */

                  /* Formateo de los Identificadores de Empresa y de
                     Tarjetahabiente. */

                  strcpy(sFmtCompanyID, EMPSTR);
                  strcpy(sFmtExeExeNum, EMPSTR);


                  /* Construccion del Numero de Cuenta del Tarjetahabiente. */

                  /* Formateo de los Identificadores de Empresa y de
                     Tarjetahabiente. */

                  strcpy(sFmtCompanyID, EMPSTR);
                  strcpy(sFmtExeExeNum, EMPSTR);
                   
                  strcpy(sSQLCommand, "SELECT isnull(replicate(\'0\', ");
                  strcat(sSQLCommand, "pgs_long_emp - ");
                  strcat(sSQLCommand, "char_length(ltrim(rtrim(str(");
                  strcat(sSQLCommand, psInt2Char(iCompanyID));
                  strcat(sSQLCommand, "))))), '') + ltrim(rtrim(str(");
                  strcat(sSQLCommand, psInt2Char(iCompanyID));
                  strcat(sSQLCommand, "))), isnull(replicate(\'0\', ");
                  strcat(sSQLCommand, "pgs_long_eje - ");
                  strcat(sSQLCommand, "char_length(ltrim(rtrim(str("); 
                  strcat(sSQLCommand, psInt2Char(iExeExeNum));
                  strcat(sSQLCommand, "))))), '') + ltrim(rtrim(str(");
                  strcat(sSQLCommand, psInt2Char(iExeExeNum));
                  strcat(sSQLCommand, "))) ");
                  strcat(sSQLCommand, "FROM MTCPGS01 ");
                  strcat(sSQLCommand, "WHERE pgs_rep_prefijo = ");
                  strcat(sSQLCommand, psInt2Char(iPreffix));
                  strcat(sSQLCommand, " AND pgs_rep_banco = ");
                  strcat(sSQLCommand, psInt2Char(iBankGroup));
   

                  EXEC SQL PREPARE setformats2 FROM :sSQLCommand;  
                                               
                  EXEC SQL EXECUTE setformats2 INTO :sFmtCompanyID,
                                                    :sFmtExeExeNum;


/* sprintf("sFmtCompanyID %s\n",sFmtCompanyID);*/
/* sprintf("sFmtExeExeNum %s\n",sFmtExeExeNum);*/
                  strcpy(sFmtCompanyID, psElimChar(sFmtCompanyID, SPACEC));
                  strcpy(sFmtExeExeNum, psElimChar(sFmtExeExeNum, SPACEC));

                  /* Obtencion de Nombre de Estado de Origen del Tarjetahabiente
                     tomando como base la Clave de Estado. */

                  strcpy(sStateName, EMPSTR);

                  strcpy(sSQLCommand, "SELECT isnull(edo_descripcion, ");
                  strcat(sSQLCommand, "\' \') ");
                  strcat(sSQLCommand, "FROM MTCEDO01 ");
                  strcat(sSQLCommand, "WHERE edo_cve_edo = \'");
                  strcat(sSQLCommand, sExeState);
                  strcat(sSQLCommand, "\'");
   

                  EXEC SQL PREPARE setstaname FROM :sSQLCommand;  
                                               
                  EXEC SQL EXECUTE setstaname INTO :sStateName;

#ifdef DEBUG1
                  printf("\nResult (State): %s\n", sExeState); 
#endif

                  for(iCardHCount=0; iCardHCount < iTotalCardH; iCardHCount++)
                  {
                     /* Procesar aquellos elementos del arreglo de 
                        Tarjetahabientes que correspondan al Ejecutivo
                        actualmente procesado. */

                     if((psCardHolders[iCardHCount].iPreffix == iPreffix) &&
                        (psCardHolders[iCardHCount].iBankGroup == iBankGroup) &&
                        (psCardHolders[iCardHCount].iCompanyID == iCompanyID) &&
                        (psCardHolders[iCardHCount].iExeExeNum == iExeExeNum))
                     {
                        iCardHRollOver=psCardHolders[iCardHCount].iCardHRollOver;
                        iCardHDigit=psCardHolders[iCardHCount].iCardHDigit;

                        strcpy(sCardHRating, psCardHolders[iCardHCount].sCardHRating);
                        iCardHLastPayDate=psCardHolders[iCardHCount].iCardHLastPayDate;
                        dCardHPayAmtDue=psCardHolders[iCardHCount].dCardHPayAmtDue;
                        dCardHChargeOffBal=psCardHolders[iCardHCount].dCardHChargeOffBal;
                        dCardHPreviewBal=psCardHolders[iCardHCount].dCardHPreviewBal;
                        dCardHCurrBal=psCardHolders[iCardHCount].dCardHCurrBal;


                        sprintf(sAccNumber, "%d%d%s%s%d%d", iPreffix,
                                                            iBankGroup,
                                                            sFmtCompanyID,
                                                            sFmtExeExeNum,
                                                            iCardHRollOver,
                                                            iCardHDigit);


                        /* Ajuste del valor del No. de Cuenta. */

                        strcpy(sAccNumberBMX, EMPSTR);
                        strcpy(sAccNumberCB, EMPSTR);

                        strcpy(sAccNumberBMX, sAccNumber);

                        strcpy(sSQLCommand, "SELECT isnull(max(map_cta_citi), ");
                        strcat(sSQLCommand, "\' \') ");
                        strcat(sSQLCommand, "FROM MTCMAP01 ");
                        strcat(sSQLCommand, "WHERE map_cta_bnx = \'");
                        strcat(sSQLCommand, sAccNumberBMX);
                        strcat(sSQLCommand, "\' AND map_estatus = \' \'");
   

                        EXEC SQL PREPARE setaccount2 FROM :sSQLCommand;  
                                               
                        EXEC SQL EXECUTE setaccount2 INTO :sAccNumberCB;

                        strcpy(sAccNumberCB, psElimChar(sAccNumberCB, SPACEC));

                        if(strlen(sAccNumberCB) > 0)
                        {
                           strcpy(sAccNumber, sAccNumberCB);
                        }

                        /* C = No Genera Plasticos, I = Si genera Plastico, D = Diversion Account */
                        if( iGenPla == 1 )
                        {
                           strcpy(sAccType,TYPESTRI);  
                        } else { 
                           strcpy(sAccType,TYPESTRC);  
                        }

                        /* Generacion y grabado en disco del Registro
                           2000 200. */  
                                                            
                        /* Enviar por Parametro el Tipo de Cuenta */
                        /* psTypAcc  */

                        GenRecord2200(&Rec2200, atol(sUnitPPID), sAccNumber, sAccType,  
                                      sExeName, sExeEmbName, sExeAddress1,
                                      sExeAddress2, sExeCity, sStateName,
                                      iExePostalCode, sExeTelNumber,
                                      sExeOfficeNum, sExeRFC, iChargeOffDate,
                                      sExeFaxNum, sExeEmail, sExeEmpNum);
                         
                        SaveRecord2200(&Rec2200, pFileCCF); 

                        iType2000RecCnt++;

                        /* Si la cuenta del Tarjetahabiente es Corporativa,
                           establecer el No. de Cuenta Padre (No. de Cuenta de
                           la Empresa). */

                        if((strcmp(sBillType, FMTCOACCNUM) == 0) && 
                           (sUniUnitPID[0] == ' '))
                        {
                           strcpy(sOthAccNum, sParAccNumber);
                          //poner tipo de Cuenta E   
                        }


                        /* Recuperacion de datos pariculares de 
                           Tarjetahabiente. */

                        /* Fecha de Apertura de Plastico. */
                        /* Situacion Actual del Plastico. */

                        iPlaRollOver=0;
                        iPlaDigit=0;   
 
                        iPlaValidSince=0;
                        strcpy(sPlaTransStatus, EMPSTR);

/***
 ***
		obtiene el digito verificador y el roll over
 ***
 ***/
			
			strcpy(sSQLCommand, "SELECT min(eje_roll_over) ");
                        strcat(sSQLCommand, "FROM MTCPLA01 ");
                        strcat(sSQLCommand, "WHERE eje_prefijo = ");
                        strcat(sSQLCommand, psInt2Char(iPreffix));
                        strcat(sSQLCommand, " AND gpo_banco = ");
                        strcat(sSQLCommand, psInt2Char(iBankGroup));
                        strcat(sSQLCommand, " AND emp_num = ");
                        strcat(sSQLCommand, psInt2Char(iCompanyID));
                        strcat(sSQLCommand, " AND eje_num = ");
                        strcat(sSQLCommand, psInt2Char(iExeExeNum));
   

                        EXEC SQL PREPARE getplainfo FROM :sSQLCommand;  
                                               
                        EXEC SQL EXECUTE getplainfo INTO :iPlaRollOver;

/***
 ***
		obtiene la fecha desde y situacion del plastico
 ***
 ***/

                        strcpy(sSQLCommand, "SELECT isnull(pla_valido_desde_aamm, 0), ");
                        strcat(sSQLCommand, "isnull(pla_situacion_plastico, \' \') ");
                        strcat(sSQLCommand, "FROM MTCPLA01 ");
                        strcat(sSQLCommand, "WHERE eje_prefijo = ");
                        strcat(sSQLCommand, psInt2Char(iPreffix));
                        strcat(sSQLCommand, " AND gpo_banco = ");
                        strcat(sSQLCommand, psInt2Char(iBankGroup));
                        strcat(sSQLCommand, " AND emp_num = ");
                        strcat(sSQLCommand, psInt2Char(iCompanyID));
                        strcat(sSQLCommand, " AND eje_num = ");
                        strcat(sSQLCommand, psInt2Char(iExeExeNum));
                        strcat(sSQLCommand, " AND eje_roll_over = ");
                        strcat(sSQLCommand, psInt2Char(iPlaRollOver));
   

                        EXEC SQL PREPARE getplasta FROM :sSQLCommand;  
                                               
                        EXEC SQL EXECUTE getplasta INTO :iPlaValidSince,
                                                        :sPlaTransStatus;

                        /* Descripcion situacion Actual del Plastico. */

                        strcpy(sPlaTransAcc, EMPSTR);

                        /* Si la Situacion de la Cuenta no es Normal,
                           extraer la Descripcion que le corresponda. */

                        if(strcmp(sPlaTransStatus, FMTSTAACC) != 0)
                        {
                           for(iCont=0; iCont < SIZE9; iCont++)
                           {
                              if(strcmp(sPlaTransStatus, 
                                        strPlaStatus[iCont].sStaCode) == 0)
                              {
                                 strcpy(sPlaTransAcc, 
                                                  strPlaStatus[iCont].sStaDesc);
                              }
                           }
                        }

                        /* Saldo Actual y Anterior del Tarjetahabiente. */
                                      
                        dCurrBalance=0.0;
                        dPrevBalance=0.0;
                        dHihCurrBalance=0.0;
                        dHihPrevBalance=0.0;
            
                        for(iHeaderCount=0; iHeaderCount < iTotalHeader; iHeaderCount++)
                        {

                           /* Procesar aquellos elementos del arreglo de 
                              Encabezados que correspondan al Tarjetahabiente 
                              actualmente procesado. */

                           if((psHeaderTrans[iHeaderCount].iPreffix == iPreffix) &&
                              (psHeaderTrans[iHeaderCount].iBankGroup == iBankGroup) &&
                              (psHeaderTrans[iHeaderCount].iCompanyID == iCompanyID) &&
                              (psHeaderTrans[iHeaderCount].iExeExeNum == iExeExeNum))
/* &&
                              (psHeaderTrans[iHeaderCount].iCardHDigit == iCardHDigit))*/
                           {
                              dHihCurrBalance=psHeaderTrans[iHeaderCount].dHihCurrBalance;
                              dHihPrevBalance=psHeaderTrans[iHeaderCount].dHihPrevBalance;
                              break;
                           }
                        }

                        /* Ajustar los valores del Saldo Actual y Anterior 
                           del Tarjetahabiente dependiendo si la Fecha de
                           Proceso corresponde a una Fecha de Corte. */
 
                        if(iChargeOffDate == iSystemDay)
                        {
                           /* Asignar datos extraidos de la tabla MTCHIH01. */

                           dCurrBalance=dHihCurrBalance;
                           dPrevBalance=dHihPrevBalance;
                        }
                        else
                        {

                           /* Asignar datos extraidos de la tabla MTCTHS01. */

                           dCurrBalance=dCardHCurrBal;
                           dPrevBalance=dCardHPreviewBal;
                        }


#ifdef DEBUG1
                        printf("Plastic Valid Since: %d\n", iPlaValidSince);    
                        printf("Plastic Status (Code): %s\n", sPlaTransStatus);
                        printf("Plastic Status (Descr.): %s\n", sPlaTransAcc); 
                        printf("Current Balance: %0.2f\n", dCurrBalance);
                        printf("Preview Balance: %0.2f\n", dPrevBalance);  
#endif

                        /* Generacion y grabado en disco del Registro 
                           2001 210. */
                                                                
                        GenRecord2001(&Rec2001, atol(sUnitPPID), sAccNumber, sParAccNumber,
                                      sExeMAccCode, iExeOpenDate, sCardHRating,
                                      iExeCredLim, sExeEmbName, sCompanyName,
                                      iPlaValidSince, iCardHLastPayDate, 
                                      dCurrBalance, dPrevBalance, 
                                      dCardHPayAmtDue, sPayDueDate,   
                                      iExeLastMaintDate, sBillType,
                                      sPlaTransAcc, sPlaTransStatus, 
                                      dCardHChargeOffBal, sOthAccNum,
                                      iExePerCashLim );
 
                        SaveRecord2001(&Rec2001, pFileCCF);

                        iType2001RecCnt++;

                        /* Nota: Por el momento,  los registros de tipo 2002
                           (211, 212 y 213) no seran generados por la
                           aplicacion; sin embargo, la definicion de los
                           mismos ya se encuentra disponible en el archivo
                           de encabezado. */

                        for(iTranCount=0; iTranCount < iTotalTran; iTranCount++)
                        {
                           /* Procesar aquellos elementos del arreglo de    
                              Transacciones que correspondan al 
                              Tarjetahabiente actualmente procesado. */                     
                           if((psTransactions[iTranCount].iPreffix == iPreffix) &&
                              (psTransactions[iTranCount].iBankGroup == iBankGroup) &&
                              (psTransactions[iTranCount].iCompanyID == iCompanyID) &&
                              (psTransactions[iTranCount].iExeExeNum == iExeExeNum) )
/*&&
                              (psTransactions[iTranCount].iCardHRollOver == iCardHRollOver) &&
                              (psTransactions[iTranCount].iCardHDigit == iCardHDigit))*/
                           {
                              iHisTransDate=psTransactions[iTranCount].iHisTransDate;
                              iHisTransTime=psTransactions[iTranCount].iHisTransTime;
                              iHisPostDate=psTransactions[iTranCount].iHisPostDate;
                              dHisTransAmount=psTransactions[iTranCount].dHisTransAmount;
                              iHisReference1=psTransactions[iTranCount].iHisReference1;
                              dHisReference2=psTransactions[iTranCount].dHisReference2;
                              iHisTransID=psTransactions[iTranCount].iHisTransID;
                              iCodeSBF=psTransactions[iTranCount].iCodeSBF;
                              iHisMerchAcepID=psTransactions[iTranCount].iHisMerchAcepID;
                              strcpy(sHisMerchDesc, psTransactions[iTranCount].sHisMerchDesc);
                              strcpy(sHisMerchStaPro, psTransactions[iTranCount].sHisMerchStaPro);
                              strcpy(sHisMerchCountry, psTransactions[iTranCount].sHisMerchCountry);
                              dHisDollars=psTransactions[iTranCount].dHisDollars;
                              strcpy(sHisRefNumber, EMPSTR); 
                              sprintf(sHisRefNumber, FMTTRANSREF, iHisReference1, dHisReference2);

                              /* Recuperacion de datos particulares del Negocio
                                 (b01_neg_num_neg). */

                              iEntMCC=0;
                              strcpy(sEntDescMCC, EMPSTR);
                              strcpy(sEntName, EMPSTR);

                              /* MCC. */
                              /* Nombre del Negocio. */

                              strcpy(sSQLCommand, "SELECT isnull(b06_acd_num_acd, 0), ");
                              strcat(sSQLCommand, "isnull(b01_neg_nom_neg, \' \') ");
                              strcat(sSQLCommand, "FROM MTCNEG01 ");
                              strcat(sSQLCommand, "WHERE b01_neg_num_neg = ");
                              strcat(sSQLCommand, psInt2Char(iHisMerchAcepID));
   

                              EXEC SQL PREPARE getentinfo FROM :sSQLCommand;  
                                               
                              EXEC SQL EXECUTE getentinfo INTO :iEntMCC,
                                                               :sEntName;

                              /* Descripcion MCC. */

                              strcpy(sSQLCommand, "SELECT isnull(b06_acd_des_acd, \' \') ");
                              strcat(sSQLCommand, "FROM MTCACT01 ");
                              strcat(sSQLCommand, "WHERE b06_acd_num_acd = ");
                              strcat(sSQLCommand, psInt2Char(iEntMCC));
   

                              EXEC SQL PREPARE getmccinfo FROM :sSQLCommand;  
                                               
                              EXEC SQL EXECUTE getmccinfo INTO :sEntDescMCC;


                              /* Signo de la Transaccion. */
                              strcpy(sTraSign, EMPSTR);

                              strcpy(sSQLCommand, "SELECT rtrim(ltrim(signo_transaccion)),");
                              strcat(sSQLCommand, "        rtrim(ltrim(tip_transaccion))  ");
                              strcat(sSQLCommand, "FROM MTCTRA01 "); /*yuria*/
                              strcat(sSQLCommand, "WHERE cve_transaccion = ");
                              strcat(sSQLCommand, psInt2Char(iHisTransID));
   

                              EXEC SQL PREPARE getsigntra FROM :sSQLCommand;  
                                               
                              EXEC SQL EXECUTE getsigntra INTO :sTraSign,
                                                               :sTraType;/*yuria*/
                              strcpy(sHisMerchCountry, 
                                         psElimChar(sHisMerchCountry, SPACEC));

                              /* Ajustar el valor del Nombre del Negocio (si
                                 el caso lo requiere). */

                              /*if((strcmp(sEntName, EMPSTR) == 0) ||
                                 (strcmp(sEntName, " ") == 0)) SE PASA
el nombre de his_negocio_leyenda tal cual*/
                              strcpy(sEntName, sHisMerchDesc); 
                              strcpy(sNomNegocio,sEntName);
                              i=strlen(sEntName);
                              for (n=i; n > 0 ; n--)
                              { 
                                 if (sNomNegocio[n-1] != ' ')
                                     break;
                                 else
                                     sNomNegocio[n-1]='\0';
                              }


                              /* Establecer el valor del campo Memo Flag. */

                              if( strcmp( sBillType, "C") == 0 ){

                                 if( iExeExeNum == 0  )
                                   strcpy(sMemoFlag, "N");
                                 else
                                   strcpy( sMemoFlag, "Y");
                              }
                              else if( strcmp( sBillType, "I") == 0 ){ 
                                 strcpy( sMemoFlag, "N");
                              }

/****** Agrega Yuria 27 Dic 2006
SE AGREGA ESTE CODIGO EN BASE  A PETICION DE DELAWARE
PARA SEPARAR LOS PAGOS DEL CLIENTE CON CODIGO 31 y 
TODOS lOS DEMAS AJUSTES DE CREDITO CON CODIGO 61 INCLUYENDO ALGUNAS DEVOLUCIONES
****/
if ( iHisTransID==5400 )
{
  if (    ( strcmp(sNomNegocio,"SU PAGO ... GRACIAS")  == 0 )
       || ( strcmp(sNomNegocio,"SU ABONO ... GRACIAS")  == 0 )
       || ( strcmp(sNomNegocio,"SU PAGO INTERBANCARIO") == 0 )
       || ( strcmp(sNomNegocio,"SU ABONO")  == 0 )
       || ( strcmp(sNomNegocio,"SU ABONO GRACIAS")  == 0 )
       || ( strcmp(sNomNegocio,"SU PAGO GRACIAS")  == 0 )
       || ( strcmp(sNomNegocio,"ABONO EN EFECTIVO")  == 0 ) )
     iCodeSBF=31;
  else
     iCodeSBF=61;
}
/*termina codigo 27 Dic 2006*/

                              /* Generacion y grabado en disco del Registro
                                 5000 500. */
             /*yuria agrega sTraType*/ 
                              GenRecord5500(&Rec5500, atol(sUnitPPID), sAccNumber,
                                            iHisTransDate, iHisTransTime,
                                            iHisPostDate, dHisTransAmount,
                                            iHisReference1, dHisReference2,
                                            iHisTransID, iEntMCC, sEntDescMCC, 
                                            iHisMerchAcepID, sEntName,
                                            sHisMerchStaPro, sHisMerchCountry, 
                                            dHisDollars, sOthAccNum, 
                                            sTraSign, sTraType, sMemoFlag, iCodeSBF);

                              SaveRecord5500(&Rec5500, pFileCCF);

                              iType5000RecCnt++;

                              dType5000Value+=dHisTransAmount;


                              /* Nota: Por el momento,  los registros de tipo
                                 5001 (511, 512 y 513) no seran generados por 
                                 la aplicacion; sin embargo, la definicion de
                                 los mismos ya se encuentra disponible en el
                                 archivo de encabezado. */


                              /* Recuperacion de Transacciones Especiales. */
                                                                
                              /* Gastos de Avion. */                         

                              for(iAirTranCount=0; iAirTranCount < iTotalAirTran; iAirTranCount++)
                              {
                           
                                 /* Procesar aquellos elementos del arreglo de
                                    Transacciones de Gastos de Avion que 
                                    correspondan al Tarjetahabiente actualmente 
                                    actualmente procesado. */

                                 if((psAirlineTrans[iAirTranCount].iPreffix == iPreffix) &&
                                    (psAirlineTrans[iAirTranCount].iBankGroup == iBankGroup) &&
                                    (psAirlineTrans[iAirTranCount].iCompanyID == iCompanyID) &&
                                    (psAirlineTrans[iAirTranCount].iExeExeNum == iExeExeNum) &&
                                    (psAirlineTrans[iAirTranCount].iCardHRollOver == iCardHRollOver) &&
                                    (psAirlineTrans[iAirTranCount].iCardHDigit == iCardHDigit) &&
                                    (psAirlineTrans[iAirTranCount].iMessageID == iHisTransID) && 
                                    (strcmp(psAirlineTrans[iAirTranCount].sHisRefNumber, sHisRefNumber) == 0))
                                 {
                                    dAirTotFareAmt=psAirlineTrans[iAirTranCount].dAirTotFareAmt;
                                    dAirTotTaxAmt=psAirlineTrans[iAirTranCount].dAirTotTaxAmt;
                                    dAirNatTaxAmt=psAirlineTrans[iAirTranCount].dAirNatTaxAmt;
                                    dAirTotFeeAmt=psAirlineTrans[iAirTranCount].dAirTotFeeAmt;
                                    strcpy(sAirTicketNum, psAirlineTrans[iAirTranCount].sAirTicketNum);
                                    strcpy(sAirExchgTicketNum, psAirlineTrans[iAirTranCount].sAirExchgTicketNum);
                                    strcpy(sAirExchgTicketAmt, psAirlineTrans[iAirTranCount].sAirExchgTicketAmt);
                                    strcpy(sAirTraAgenCode, psAirlineTrans[iAirTranCount].sAirTraAgenCode);
                                    strcpy(sAirTraAgenName, psAirlineTrans[iAirTranCount].sAirTraAgenName);
                                    strcpy(sAirPassName, psAirlineTrans[iAirTranCount].sAirPassName);
                                    iAirDepartDate=psAirlineTrans[iAirTranCount].iAirDepartDate;
                                    strcpy(sAirOrigCode, psAirlineTrans[iAirTranCount].sAirOrigCode);
                                    strcpy(sAirInternetInd, psAirlineTrans[iAirTranCount].sAirInternetInd);
                                    strcpy(sAirElectTicketNum, psAirlineTrans[iAirTranCount].sAirElectTicketNum);


                                    /* Ajuste de la Fecha de Salida del Vuelo. */
                                    iAirDepartDate6=0;

                                    strcpy(sAirDepartDate, EMPSTR);

                                    strcpy(sSQLCommand, "SELECT convert(char(8), ");
                                    strcat(sSQLCommand, "convert(datetime, ");
                                    strcat(sSQLCommand, "str(");
                                    strcat(sSQLCommand, psInt2Char(iAirDepartDate));
                                    strcat(sSQLCommand, ")), 1)");
   

                                    EXEC SQL PREPARE getdepdate 
                                             FROM :sSQLCommand;  
                                               
                                    EXEC SQL EXECUTE getdepdate 
                                             INTO :sAirDepartDate;

                                    strcpy(sAirDepartDate, 
                                             psElimChar(sAirDepartDate, DIAG));

                                    iAirDepartDate6 = atoi(sAirDepartDate);


                                    /* Inicializacion de estructura de Escalas. */

                                    for(iCont=0; iCont < LEN16; iCont++)
                                    {
                                       strcpy(ScalesDesc[iCont].sAirlineStopOver,
                                                                EMPSTR);
                                       strcpy(ScalesDesc[iCont].sDestination,
                                                                EMPSTR);
                                       strcpy(ScalesDesc[iCont].sAirlineCarrierCode,
                                                                EMPSTR);
                                       strcpy(ScalesDesc[iCont].sAirlineServClass,
                                                                EMPSTR);
                                       strcpy(ScalesDesc[iCont].sFlightNum,
                                                                EMPSTR);
                                    } 

                                    iCont=0;

                                    for(iScalesCount=0; iScalesCount < iTotalScales; iScalesCount++)
                                    {

                                       /* Procesar aquellos elementos del
                                          arreglo de Escalas que correspondan 
                                          al Vuelo actualmente procesado. */ 

                                       if((psScales[iScalesCount].iPreffix == iPreffix) &&
                                          (psScales[iScalesCount].iBankGroup == iBankGroup) &&
                                          (psScales[iScalesCount].iCompanyID == iCompanyID) &&
                                          (psScales[iScalesCount].iExeExeNum == iExeExeNum) &&
                                          (psScales[iScalesCount].iCardHRollOver == iCardHRollOver) &&
                                          (psScales[iScalesCount].iCardHDigit == iCardHDigit) &&
                                          (psScales[iScalesCount].iMessageID == iHisTransID) && 
                                          (strcmp(psScales[iScalesCount].sHisRefNumber, sHisRefNumber) == 0))
                                       {

                                          strcpy(sScaStopOver, 
                                                 psScales[iScalesCount].sAirlineStopOver); 
                                          strcpy(sScaDest, 
                                                 psScales[iScalesCount].sDestination);
                                          strcpy(sScaCarrCode, 
                                                 psScales[iScalesCount].sAirlineCarrierCode);
                                          strcpy(sScaServClass, 
                                                 psScales[iScalesCount].sAirlineServClass);
                                          strcpy(sScaFlightNum, 
                                                 psScales[iScalesCount].sFlightNum);

                                          /* Actualizacion de estructura de Escalas. */

                                          strcpy(ScalesDesc[iCont].sAirlineStopOver,
                                                             sScaStopOver);   
                                          strcpy(ScalesDesc[iCont].sDestination,
                                                             sScaDest);
                                          strcpy(ScalesDesc[iCont].sAirlineCarrierCode,
                                                             sScaCarrCode);
                                          strcpy(ScalesDesc[iCont].sAirlineServClass,
                                                             sScaServClass);  
                                          strcpy(ScalesDesc[iCont].sFlightNum, 
                                                             sScaFlightNum);

                                          iCont++;

                                          /* Solo podran recuperarse hasta un
                                             maximo de 16 escalas para un vuelo
                                             determinado. */

                                          if(iCont >= LEN16)
                                             break;
                                       }

                                    }

                                    /* Generacion y grabado en disco del 
                                       Registro 6001. */
               
                                    GenRecord6001(&Rec6001, atol(sUnitPPID), 
                                                  sAccNumber, iHisTransID,
                                                  iHisReference1,
                                                  dHisReference2, 
                                                  dAirTotFareAmt,
                                                  dAirTotTaxAmt, dAirNatTaxAmt,
                                                  dAirTotFeeAmt, sAirTicketNum, 
                                                  sAirExchgTicketNum, 
                                                  sAirExchgTicketAmt, 
                                                  ScalesDesc, 
                                                  sAirTraAgenCode, 
                                                  sAirTraAgenName,
                                                  sAirPassName, iAirDepartDate6,
                                                  sAirOrigCode, sAirInternetInd,
                                                  sAirElectTicketNum);

                                    SaveRecord6001(&Rec6001, pFileCCF);

                                    iType6001RecCnt++;

                                 }

                              }


                              /* Compras Diversas. */

                              for(iPurchTranCount=0; iPurchTranCount < iTotalPurTran; iPurchTranCount++)
                              {
                           
                                 /* Procesar aquellos elementos del arreglo de
                                    Transacciones de Gastos por Compras que 
                                    correspondan al Tarjetahabiente actualmente 
                                    actualmente procesado. */

                                 if((psPurchTrans[iPurchTranCount].iPreffix == iPreffix) &&
                                    (psPurchTrans[iPurchTranCount].iBankGroup == iBankGroup) &&
                                    (psPurchTrans[iPurchTranCount].iCompanyID == iCompanyID) &&
                                    (psPurchTrans[iPurchTranCount].iExeExeNum == iExeExeNum) &&
                                    (psPurchTrans[iPurchTranCount].iCardHRollOver == iCardHRollOver) &&
                                    (psPurchTrans[iPurchTranCount].iCardHDigit == iCardHDigit) &&
                                    (psPurchTrans[iPurchTranCount].iMessageID == iHisTransID) && 
                                    (strcmp(psPurchTrans[iPurchTranCount].sHisRefNumber, sHisRefNumber) == 0))
                                 {

                                    iPurDetSeqNum=psPurchTrans[iPurchTranCount].iPurDetSeqNum;
                                    iPurOrderDate=psPurchTrans[iPurchTranCount].iPurOrderDate;
                                    strcpy(sPurDestZipCode, psPurchTrans[iPurchTranCount].sPurDestZipCode);
                                    strcpy(sPurDestCountry, psPurchTrans[iPurchTranCount].sPurDestCountry);
                                    strcpy(sPurOrigZipCode, psPurchTrans[iPurchTranCount].sPurOrigZipCode);
                                    dPurFreightAmt=psPurchTrans[iPurchTranCount].dPurFreightAmt;
                                    dPurFreightVATTaxAmt=psPurchTrans[iPurchTranCount].dPurFreightVATTaxAmt;
                                    dPurFreightVATTaxRat=psPurchTrans[iPurchTranCount].dPurFreightVATTaxRat;
                                    strcpy(sPurCommCode, psPurchTrans[iPurchTranCount].sPurCommCode);
                                    strcpy(sPurDescription, psPurchTrans[iPurchTranCount].sPurDescription);
                                    strcpy(sPurProductCode, psPurchTrans[iPurchTranCount].sPurProductCode);
                                    dPurQuantity=psPurchTrans[iPurchTranCount].dPurQuantity;
                                    strcpy(sPurUnitMeasure, psPurchTrans[iPurchTranCount].sPurUnitMeasure);
                                    dPurUnitCost=psPurchTrans[iPurchTranCount].dPurUnitCost;
                                    dPurVATTaxAmt=psPurchTrans[iPurchTranCount].dPurVATTaxAmt;
                                    dPurVATTaxRat=psPurchTrans[iPurchTranCount].dPurVATTaxRat;
                                    strcpy(sPurVATInvRefNum, psPurchTrans[iPurchTranCount].sPurVATInvRefNum);
                                    dPurDiscPerItem=psPurchTrans[iPurchTranCount].dPurDiscPerItem;
                                    dPurLineItemTot=psPurchTrans[iPurchTranCount].dPurLineItemTot;

                                    /* Generacion y grabado en disco del 
                                       Registro 6002. */
               
                                    GenRecord6002(&Rec6002, atol(sUnitPPID), 
                                                  sAccNumber, iPurDetSeqNum,
                                                  iPurOrderDate, 
                                                  sPurDestZipCode,
                                                  sPurDestCountry,
                                                  sPurOrigZipCode, 
                                                  dPurFreightAmt,
                                                  dPurFreightVATTaxAmt,
                                                  dPurFreightVATTaxRat, 
                                                  sPurCommCode, sPurDescription,
                                                  sPurProductCode, 
                                                  dPurQuantity, sPurUnitMeasure,
                                                  dPurUnitCost, dPurVATTaxAmt, 
                                                  dPurVATTaxRat,
                                                  sPurVATInvRefNum, 
                                                  dPurDiscPerItem,
                                                  dPurLineItemTot);
                            
                                    SaveRecord6002(&Rec6002, pFileCCF);

                                    iType6002RecCnt++;

                                 }
        
                              }


                              /* Hospedaje. */

                              for(iLodTranCount=0; iLodTranCount < iTotalLodTran; iLodTranCount++)
                              {
                           
                                 /* Procesar aquellos elementos del arreglo de
                                    Transacciones de Gastos por Hospedaje que 
                                    correspondan al Tarjetahabiente actualmente 
                                    procesado. */

                                 if((psLodTrans[iLodTranCount].iPreffix == iPreffix) &&
                                    (psLodTrans[iLodTranCount].iBankGroup == iBankGroup) &&
                                    (psLodTrans[iLodTranCount].iCompanyID == iCompanyID) &&
                                    (psLodTrans[iLodTranCount].iExeExeNum == iExeExeNum) &&
                                    (psLodTrans[iLodTranCount].iCardHRollOver == iCardHRollOver) &&
                                    (psLodTrans[iLodTranCount].iCardHDigit == iCardHDigit) &&
                                    (psLodTrans[iLodTranCount].iMessageID == iHisTransID) && 
                                    (strcmp(psLodTrans[iLodTranCount].sHisRefNumber, sHisRefNumber) == 0))
                                 {
                                    iLodDetSeqNum=psLodTrans[iLodTranCount].iLodDetSeqNum;
                                    strcpy(sLodPropTelNumber, psLodTrans[iLodTranCount].sLodPropTelNumber);
                                    strcpy(sLodCustTelNumber, psLodTrans[iLodTranCount].sLodCustTelNumber);
                                    iLodCheckInDate=psLodTrans[iLodTranCount].iLodCheckInDate;
                                    iLodCheckOutDate=psLodTrans[iLodTranCount].iLodCheckOutDate;
                                    strcpy(sLodNoShowInd, psLodTrans[iLodTranCount].sLodNoShowInd);
                                    dLodTotAutAmt=psLodTrans[iLodTranCount].dLodTotAutAmt;
                                    dLodPrepaidExp=psLodTrans[iLodTranCount].dLodPrepaidExp;
                                    iLodNumRoomNights=psLodTrans[iLodTranCount].iLodNumRoomNights;
                                    dLodDayRoomRate=psLodTrans[iLodTranCount].dLodDayRoomRate;
                                    dLodVATTaxAmt=psLodTrans[iLodTranCount].dLodVATTaxAmt;
                                    dLodVATTaxRate=psLodTrans[iLodTranCount].dLodVATTaxRate;
                                    dLodRoomTaxAmt=psLodTrans[iLodTranCount].dLodRoomTaxAmt;
                                    strcpy(sLodVATInvRefNum, psLodTrans[iLodTranCount].sLodVATInvRefNum);
                                    dLodDiscAmt=psLodTrans[iLodTranCount].dLodDiscAmt;
                                    dLodFoodBevCharges=psLodTrans[iLodTranCount].dLodFoodBevCharges;
                                    dLodCashAdv=psLodTrans[iLodTranCount].dLodCashAdv;
                                    dLodValParkCharges=psLodTrans[iLodTranCount].dLodValParkCharges;
                                    dLodMiniBarCharges=psLodTrans[iLodTranCount].dLodMiniBarCharges;
                                    dLodLaundryCharges=psLodTrans[iLodTranCount].dLodLaundryCharges;
                                    dLodPhoneCharges=psLodTrans[iLodTranCount].dLodPhoneCharges;
                                    dLodGiftShopCharges=psLodTrans[iLodTranCount].dLodGiftShopCharges;
                                    dLodMovieCharges=psLodTrans[iLodTranCount].dLodMovieCharges;
                                    dLodBusCentCharges=psLodTrans[iLodTranCount].dLodBusCentCharges;
                                    dLodHeaClubCharges=psLodTrans[iLodTranCount].dLodHeaClubCharges;
                                    dLodOtherCharges=psLodTrans[iLodTranCount].dLodOtherCharges;
                                    dLodTotNonRoomCharges=psLodTrans[iLodTranCount].dLodTotNonRoomCharges;


                                    /* Generacion y grabado en disco del
                                       Registro 6004. */
              
                                    GenRecord6004(&Rec6004, atol(sUnitPPID),
                                                  sAccNumber, iLodDetSeqNum,
                                                  sLodPropTelNumber,
                                                  sLodCustTelNumber,
                                                  iLodCheckInDate,
                                                  iLodCheckOutDate,
                                                  sLodNoShowInd, dLodTotAutAmt,
                                                  dLodPrepaidExp,
                                                  iLodNumRoomNights, 
                                                  dLodDayRoomRate,
                                                  dLodVATTaxAmt, dLodVATTaxRate,
                                                  dLodRoomTaxAmt, 
                                                  sLodVATInvRefNum, dLodDiscAmt,
                                                  dLodFoodBevCharges, 
                                                  dLodCashAdv, 
                                                  dLodValParkCharges, 
                                                  dLodMiniBarCharges,
                                                  dLodLaundryCharges,
                                                  dLodPhoneCharges,
                                                  dLodGiftShopCharges,
                                                  dLodMovieCharges,
                                                  dLodBusCentCharges, 
                                                  dLodHeaClubCharges,
                                                  dLodOtherCharges,
                                                  dLodTotNonRoomCharges);

                                    SaveRecord6004(&Rec6004, pFileCCF);

                                    iType6004RecCnt++;

                                 }

                              }


                              /* Renta de Auto(s). */

                              for(iRentTranCount=0; iRentTranCount < iTotalRentTran; iRentTranCount++)
                              {
                           
                                 /* Procesar aquellos elementos del arreglo de
                                    Transacciones de Gastos por Renta de Auto(s)
                                    que correspondan al Tarjetahabiente  
                                    actualmente procesado. */

                                 if((psRentTrans[iRentTranCount].iPreffix == iPreffix) &&
                                    (psRentTrans[iRentTranCount].iBankGroup == iBankGroup) &&
                                    (psRentTrans[iRentTranCount].iCompanyID == iCompanyID) &&
                                    (psRentTrans[iRentTranCount].iExeExeNum == iExeExeNum) &&
                                    (psRentTrans[iRentTranCount].iCardHRollOver == iCardHRollOver) &&
                                    (psRentTrans[iRentTranCount].iCardHDigit == iCardHDigit) &&
                                    (psRentTrans[iRentTranCount].iMessageID == iHisTransID) && 
                                    (strcmp(psRentTrans[iRentTranCount].sHisRefNumber, sHisRefNumber) == 0))
                                 {

                                    iCarDetSeqNum=psRentTrans[iRentTranCount].iCarDetSeqNum;
                                    strcpy(sCarRentAgreeNum, psRentTrans[iRentTranCount].sCarRentAgreeNum);
                                    strcpy(sCarRentName, psRentTrans[iRentTranCount].sCarRentName);
                                    strcpy(sCarRetCity, psRentTrans[iRentTranCount].sCarRetCity);
                                    strcpy(sCarRetStaCtry, psRentTrans[iRentTranCount].sCarRetStaCtry);
                                    strcpy(sCarClassCode, psRentTrans[iRentTranCount].sCarClassCode);
                                    strcpy(sCarNoShowInd, psRentTrans[iRentTranCount].sCarNoShowInd);
                                    iCarCheckOutDate=psRentTrans[iRentTranCount].iCarCheckOutDate;
                                    iCarCheckInDate=psRentTrans[iRentTranCount].iCarCheckInDate;
                                    strcpy(sCarInsInd, psRentTrans[iRentTranCount].sCarInsInd);
                                    dCarInsCharges=psRentTrans[iRentTranCount].dCarInsCharges;
                                    dCarTotMiles=psRentTrans[iRentTranCount].dCarTotMiles;
                                    iCarNumDaysRent=psRentTrans[iRentTranCount].iCarNumDaysRent;
                                    dCarDailyRate=psRentTrans[iRentTranCount].dCarDailyRate;
                                    dCarVATTaxAmt=psRentTrans[iRentTranCount].dCarVATTaxAmt;
                                    dCarVATTaxRate=psRentTrans[iRentTranCount].dCarVATTaxRate;
                                    strcpy(sCarVATInvRefNum, psRentTrans[iRentTranCount].sCarVATInvRefNum);
                                    dCarWeeklyRate=psRentTrans[iRentTranCount].dCarWeeklyRate;
                                    dCarRatePerMile=psRentTrans[iRentTranCount].dCarRatePerMile;
                                    dCarOneWayDropOff=psRentTrans[iRentTranCount].dCarOneWayDropOff;
                                    dCarRegMilCharge=psRentTrans[iRentTranCount].dCarRegMilCharge;
                                    dCarExtMilCharge=psRentTrans[iRentTranCount].dCarExtMilCharge;
                                    dCarMaxFreeMiles=psRentTrans[iRentTranCount].dCarMaxFreeMiles;
                                    dCarLateRetCharge=psRentTrans[iRentTranCount].dCarLateRetCharge;
                                    dCarFuelCharge=psRentTrans[iRentTranCount].dCarFuelCharge;
                                    dCarTelCharge=psRentTrans[iRentTranCount].dCarTelCharge;
                                    dCarTowCharge=psRentTrans[iRentTranCount].dCarTowCharge;
                                    dCarExtCharges=psRentTrans[iRentTranCount].dCarExtCharges;
                                    dCarOthCharges=psRentTrans[iRentTranCount].dCarOthCharges;
                                    dCarDiscAmt=psRentTrans[iRentTranCount].dCarDiscAmt;
                                    dCarLineItemTot=psRentTrans[iRentTranCount].dCarLineItemTot;

                                    /* Generacion y grabado en disco del
                                       Registro 6005. */

                                    GenRecord6005(&Rec6005, atol(sUnitPPID),
                                               sAccNumber,
                                               iCarDetSeqNum, sCarRentAgreeNum,
                                               sCarRentName, sCarRetCity,
                                               sCarRetStaCtry, sCarClassCode,
                                               sCarNoShowInd, iCarCheckOutDate,
                                               iCarCheckInDate, sCarInsInd,
                                               dCarInsCharges, dCarTotMiles, 
                                               iCarNumDaysRent, dCarDailyRate,  
                                               dCarVATTaxAmt, dCarVATTaxRate,
                                               sCarVATInvRefNum, dCarWeeklyRate,
                                               dCarRatePerMile,
                                               dCarOneWayDropOff, 
                                               dCarRegMilCharge,
                                               dCarExtMilCharge,
                                               dCarMaxFreeMiles, 
                                               dCarLateRetCharge,
                                               dCarFuelCharge, dCarTelCharge,
                                               dCarTowCharge, dCarExtCharges,
                                               dCarOthCharges, dCarDiscAmt,
                                               dCarLineItemTot);

                                    SaveRecord6005(&Rec6005, pFileCCF);

                                    iType6005RecCnt++;

                                 }
                               
                              }

                           }

                        }

                     }    
                   
                  }

               }

            }

         }

      }                       
      

      /* Generacion y grabado en disco del Registro 9000 900. */      
    
      GenRecord9000(&Rec9000, sCompanyName, atol(sUnitPPID), sASystemDate, 
                    iType1000RecCnt, iType1001RecCnt, iType2000RecCnt,
                    iType2001RecCnt, iType2002RecCnt, iType5000RecCnt,   
                    dType5000Value, iType5001RecCnt, iType6001RecCnt,   
                    iType6002RecCnt, iType6004RecCnt, iType6005RecCnt); 
 
      SaveRecord9000(&Rec9000, pFileCCF);

      iType1000RecCnt=0; 
      iType1001RecCnt=0; 
      iType2000RecCnt=0; 
      iType2001RecCnt=0; 
      iType2002RecCnt=0; 
      iType5000RecCnt=0; 
      dType5000Value=0.0;
      iType5001RecCnt=0; 
      iType6001RecCnt=0; 
      iType6002RecCnt=0; 
      iType6004RecCnt=0; 
      iType6005RecCnt=0; 
   }

   /* Liberacion de Espacios Reservados para informacion recuperada de 
      la Base de Datos. */

   free(psCompanies);

   free(psUnits);

   free(psExecutives);

   free(psCardHolders);

   free(psTransactions);

   free(psHeaderTrans);

   free(psAirlineTrans);

   free(psScales);

   free(psPurchTrans);

   free(psLodTrans);

   free(psRentTrans);

   fclose(pFileCCF);

   return STDEXIT;
}

/* NOMBRE       : psElimChar                                                 */
/* DESCRIPCION	: Elimina dentro de la cadena pasada como parametro el       */
/*                caracter especificado.                                     */
/* PARAMETROS 	:                                                            */
/*    psString = Cadena a procesar.                                          */
/*    cCharacter = Caracter a eliminar de psString.                          */
/* SALIDAS      :                                                            */
/*    sResult = Cadena sin caracteres cCharacter.                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 09/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     09/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */


#if defined(__STDC__) || defined(__cplusplus)
char *psElimChar(char *psString, char cCharacter)
#else
extern char *psElimChar(psString, cCharacter);
char *psString;
char cCharacter;
#endif
{
   static char sResult[LEN255+1];   /* Cadena sin los caracteres cCharacter. */
   char *pResult;
   char sTemp[LEN2+1];       /* Cadena temporal. */
   int  iPos;                /* Posicion actual de la cadena. */

   strcpy(sResult, EMPSTR); 
                                               
   for(iPos=0; iPos < strlen(psString); iPos++)
   {
      /* Si el caracter analizado no es igual a cCharacter,  colocarlo
         en la cadena de salida sResult. */
 
      if(psString[iPos] != cCharacter)
      {
         sTemp[0] = psString[iPos];
         sTemp[1] = EOLN;
         strcat(sResult, sTemp);
      }
   }
   pResult=sResult;
   return(pResult);
}

/* NOMBRE       : GenRecord0000                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 0000 del Formato CCF.                             */
/* PARAMETROS 	:                                                            */
/*    pRec0000 = Registro 0000 a inicializar.                                */
/*    psCompName = Nombre de la Empresa.                                     */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psGenDate = Fecha de Generacion del archivo CCF.                       */
/* SALIDAS      :                                                            */
/*    Registro 0000 inicializado.                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 10/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     10/07/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón	      20/12/2004     Segunda Version	     */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord0000(Record0000 *pRec0000, char *psCompName, 
                   int iCompID, char *psGenDate)
#else
void GenRecord0000(pRec0000, psCompName, iCompID, psGenDate)
Record0000 *pRec0000;
char *psCompName;
int  iCompID;
char *psGenDate;
#endif
{
   /* Inicializa la estructura 0000. */

   strcpy(pRec0000->sRecordID, EMPSTR); 
   strcpy(pRec0000->sTypeID, EMPSTR); 
   strcpy(pRec0000->sCompName, EMPSTR); 
   strcpy(pRec0000->sCompID, EMPSTR); 
   strcpy(pRec0000->sSubCompID, EMPSTR); 
   strcpy(pRec0000->sEffecFileDate, EMPSTR);
   strcpy(pRec0000->sCCFVersion, EMPSTR); 
   strcpy(pRec0000->sCompNameKanjiShiftOUT, EMPSTR); 			/* FUN 20122004 */
   strcpy(pRec0000->sCompNameKanji, EMPSTR); 				/* FUN 20122004 */
   strcpy(pRec0000->sCompNameKanjiShiftIN, EMPSTR); 			/* FUN 20122004 */
   strcpy(pRec0000->sFiller, EMPSTR); 
   strcpy(pRec0000->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec0000->sRecordID, FMTREC0000);
   strcpy(pRec0000->sTypeID, FMTTYPEIND1);
   sprintf(pRec0000->sCompName, FMTSLLONG100, psCompName);
   sprintf(pRec0000->sCompID, FMTNZLONG6, iCompID);                 /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec0000->sSubCompID, FMTSUBCOID);
   sprintf(pRec0000->sEffecFileDate, FMTSLLONG8, psGenDate);
   strcpy(pRec0000->sCCFVersion, FMTCCFVER);
   sprintf(pRec0000->sCompNameKanjiShiftOUT, FMTSLONG1, EMPSTR); 			/* FUN 20122004 */
   sprintf(pRec0000->sCompNameKanji, FMTSLLONG60, EMPSTR); 				/* FUN 20122004 */
   sprintf(pRec0000->sCompNameKanjiShiftIN, FMTSLONG1, EMPSTR); 			/* FUN 20122004 */
   sprintf(pRec0000->sFiller, FMTSLLONG759, EMPSTR);
   sprintf(pRec0000->sTRXContData, FMTSLLONG50, EMPSTR);
}

/* NOMBRE       : SaveRecord0000                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 0000.                          */
/* PARAMETROS 	:                                                            */
/*    pRec0000 = Registro 0000 con datos.                                    */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 10/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     10/07/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón	      20/12/2004     Segunda Version	     */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord0000(Record0000 *pRec0000, FILE *pFileReg) 
#else
void SaveRecord0000(pRec0000, pFileReg)
Record0000 *pRec0000;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s\n",	pRec0000->sRecordID,
							pRec0000->sTypeID,
							pRec0000->sCompName,
							pRec0000->sCompID,
							pRec0000->sSubCompID,
							pRec0000->sEffecFileDate,
							pRec0000->sCCFVersion,
							pRec0000->sCompNameKanjiShiftOUT,	/* FUN 20122004 */
							pRec0000->sCompNameKanji,		/* FUN 20122004 */
							pRec0000->sCompNameKanjiShiftIN,	/* FUN 20122004 */
							pRec0000->sFiller,
							pRec0000->sTRXContData); 
}

/* NOMBRE       : GenRecord1100                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 1000 100  del Formato CCF.                        */
/* PARAMETROS 	:                                                            */
/*    pRec1100 = Registro 1000 100 a inicializar.                            */
/*    iPref = Prefijo de la Empresa.                                         */ 
/*    iBankGp = Grupo de Banco de la Empresa.                                */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psUnitId = Identificador de la Unidad.                                 */
/*    psUnitPId = Identificador de la Unidad a la cual pertenece psUnitId    */
/*                (Nodo Padre).                                              */
/*    psUnitName = Nombre de la Unidad.                                      */
/*    iLevel = Numero de Nivel correspondiente a la Unidad analizada.        */
/* SALIDAS      :                                                            */
/*    Registro 1000 100 inicializado.                                        */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 10/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     10/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord1100(Record1100 *pRec1100, int iPref, int iBankGp,
                   int iCompID, char *psUnitId, char *psUnitPId, 
                   char *psUnitName, int iLevel)
#else
void GenRecord1100(pRec1100, iPref, iBankGp, iCompID, psUnitId, 
                   psUnitPId, psUnitName, iLevel)
Record1100 *pRec1100;
int iPref;
int iBankGp;
int iCompID;
char *psUnitId;
char *psUnitPId;
char *psUnitName;
int iLevel;
#endif
{
   int iPrefGpoBanco;      /* Identificador de Prefijo y Grupo de
                              Banco de la Empresa. */
   char sTemp[LEN255+1];   /* Cadena para procesos intermedios. */
    

   /* Inicializa la estructura 1000 100. */

   strcpy(pRec1100->sRecordID, EMPSTR);
   strcpy(pRec1100->sTypeID, EMPSTR);
   strcpy(pRec1100->sCompID, EMPSTR);
   strcpy(pRec1100->sSubCompID, EMPSTR);
   strcpy(pRec1100->sCorpParentNode, EMPSTR);
   strcpy(pRec1100->sCorpChildNode, EMPSTR);
   strcpy(pRec1100->sDepth, EMPSTR);
   strcpy(pRec1100->sLevelName, EMPSTR);
   strcpy(pRec1100->sHierType, EMPSTR);
   strcpy(pRec1100->sAccCodeID, EMPSTR);
   strcpy(pRec1100->sCurrSicTemp, EMPSTR);
   strcpy(pRec1100->sFutSicTemp, EMPSTR);
   strcpy(pRec1100->sReportTemp, EMPSTR);
   strcpy(pRec1100->sTextSetTemp, EMPSTR);
   strcpy(pRec1100->sExcepTemp, EMPSTR);
   strcpy(pRec1100->sFiller, EMPSTR);
   strcpy(pRec1100->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec1100->sRecordID, FMTREC1000);
   strcpy(pRec1100->sTypeID, FMTTYPEIND2);
   sprintf(pRec1100->sCompID, FMTNZLONG6, iCompID);            /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec1100->sSubCompID, FMTSUBCOID);

   /* Ajustar los valores de los campos sCorpParentNode y sCorpChildNode
      de acuerdo con los valores de los parametros psUnitPId y
      psUnitId. */

   if( iLevel == 0 )   /* Nodo Padre. */
   {
      sprintf(pRec1100->sCorpParentNode, FMTSLLONG50, EMPSTR); 
      sprintf(pRec1100->sCorpChildNode, FMTSLLONG50, psUnitId); 
   }
   else   /* Nodo Hijo. */
   {
      sprintf(pRec1100->sCorpParentNode, FMTSLLONG50, psUnitPId); 
      sprintf(pRec1100->sCorpChildNode, FMTSLLONG50, psUnitId); 
   }

   sprintf(pRec1100->sDepth, FMTNZLONG10, iLevel); 
   sprintf(pRec1100->sLevelName, FMTSLLONG50, psUnitName); 
   sprintf(pRec1100->sHierType, FMTSLLONG10, FMTHIERID);
 
   /* sprintf(pRec1100->sAccCodeID, FMTSLLONG10, EMPSTR); */ 
   sprintf(sTemp, FMTPREFGPO, iPref, iBankGp);
   iPrefGpoBanco = atoi(sTemp);
   sprintf(pRec1100->sAccCodeID, FMTNZLONG10, iPrefGpoBanco);

   sprintf(pRec1100->sCurrSicTemp, FMTSLLONG15, EMPSTR); 
   sprintf(pRec1100->sFutSicTemp, FMTSLLONG15, EMPSTR); 
   sprintf(pRec1100->sReportTemp, FMTSLLONG15, EMPSTR); 
   sprintf(pRec1100->sTextSetTemp, FMTSLLONG15, EMPSTR); 
   sprintf(pRec1100->sExcepTemp, FMTSLLONG15, EMPSTR);
   sprintf(pRec1100->sFiller, FMTSLLONG679, EMPSTR);
   sprintf(pRec1100->sTRXContData, FMTSLLONG50, EMPSTR);
}

/* NOMBRE       : SaveRecord1100                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 1000 100.                      */
/* PARAMETROS 	:                                                            */
/*    pRec1100 = Registro 1100 100 con datos.                                */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 10/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     10/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord1100(Record1100 *pRec1100, FILE *pFileReg) 
#else
void SaveRecord1100(pRec1100, pFileReg)
Record1100 *pRec1100;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n", 
                                          pRec1100->sRecordID,
                                          pRec1100->sTypeID,
                                          pRec1100->sCompID,
                                          pRec1100->sSubCompID,
                                          pRec1100->sCorpParentNode,
                                          pRec1100->sCorpChildNode,
                                          pRec1100->sDepth,
                                          pRec1100->sLevelName,
                                          pRec1100->sHierType,
                                          pRec1100->sAccCodeID,
                                          pRec1100->sCurrSicTemp,
                                          pRec1100->sFutSicTemp,
                                          pRec1100->sReportTemp,
                                          pRec1100->sTextSetTemp,
                                          pRec1100->sExcepTemp,
                                          pRec1100->sFiller, 
                                          pRec1100->sTRXContData);
}

/* NOMBRE       : GenRecord1001                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 1001 110  del Formato CCF.                        */
/* PARAMETROS 	:                                                            */
/*    pRec1001 = Registro 1001 110 a inicializar.                            */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psUnitId = Identificador de la Unidad.                                 */
/*    psAccNum = Numero de Cuenta.                                           */
/* SALIDAS      :                                                            */
/*    Registro 1001 110 inicializado.                                        */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 10/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     10/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord1001(Record1001 *pRec1001, int iCompID, char *psUnitId, 
                   char *psAccNum)
#else
void GenRecord1001(pRec1001, iCompID, psUnitId, psAccNum)
Record1001 *pRec1001;
int iCompID;
char *psUnitId;
char *psAccNum;
#endif
{
   /* Inicializa la estructura 1001 110. */

   strcpy(pRec1001->sRecordID, EMPSTR);
   strcpy(pRec1001->sTypeID, EMPSTR);
   strcpy(pRec1001->sCompID, EMPSTR);
   strcpy(pRec1001->sSubCompID, EMPSTR);
   strcpy(pRec1001->sNodeID, EMPSTR);
   strcpy(pRec1001->sAccNumber, EMPSTR);
   strcpy(pRec1001->sFiller, EMPSTR);
   strcpy(pRec1001->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec1001->sRecordID, FMTREC1001);
   strcpy(pRec1001->sTypeID, FMTTYPEIND3);
   sprintf(pRec1001->sCompID, FMTNZLONG6, iCompID);                 /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec1001->sSubCompID, FMTSUBCOID);
   sprintf(pRec1001->sNodeID, FMTSLLONG50, psUnitId);  
   sprintf(pRec1001->sAccNumber, FMTSLLONG50, psAccNum); 
   sprintf(pRec1001->sFiller, FMTSLLONG834, EMPSTR);
   sprintf(pRec1001->sTRXContData, FMTSLLONG50, EMPSTR);
}

/* NOMBRE       : SaveRecord1001                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 1001 110.                      */
/* PARAMETROS 	:                                                            */
/*    pRec1001 = Registro 1001 110 con datos.                                */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 10/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     10/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord1001(Record1001 *pRec1001, FILE *pFileReg) 
#else
void SaveRecord1001(pRec1001, pFileReg)
Record1001 *pRec1001;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s\n", 
                                          pRec1001->sRecordID,
                                          pRec1001->sTypeID,
                                          pRec1001->sCompID,
                                          pRec1001->sSubCompID,
                                          pRec1001->sNodeID,
                                          pRec1001->sAccNumber,
                                          pRec1001->sFiller, 
                                          pRec1001->sTRXContData);
}


/* NOMBRE       : GenRecord2200                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 2000 200  del Formato CCF.                        */
/* PARAMETROS 	:                                                            */
/*    pRec2200 = Registro 2000 200 a inicializar.                            */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psAccNum = Numero de Cuenta.                                           */
/*    psAccType = Tipo  de Cuenta.                                           */
/*    psName = Nombre del Tarjetahabiente.                                   */
/*    psPlaName = Nombre del Tarjetahabiente tal como aparece en el          */
/*                Plastico.                                                  */
/*    psAdd1 = Direccion del Tarjetahabiente (Calle).                        */
/*    psAdd2 = Direccion del Tarjetahabiente (Colonia).                      */
/*    psCity = Ciudad de Origen del Tarjetahabiente.                         */
/*    psState = Estado de Origen del Tarjetahabiente.                        */
/*    iPostCode = Codigo Postal del Tarjetahabiente.                         */
/*    psTelNum = Telefono del Domicilio del Tarjetahabiente.                 */
/*    psOffNum = Telefono del Lugar de Trabajo del Tarjetahabiente.          */
/*    psRFC = Registro Federal de Causante del Tarjetahabiente.              */
/*    iChargOffDate = Fecha de Corte de la Cuenta.                           */
/*    psFaxNum = Numero de Fax del Tarjetahabiente.                          */
/*    psEmail = Direccion de Correo Electronico del Tarjetahabiente.         */
/*    psEmpNum = Numeor de Empleado del Tarjetahabiente.                     */ 
/* SALIDAS      :                                                            */
/*    Registro 2000 200 inicializado.                                        */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 11/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     11/07/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón	      20/12/2004     Segunda Version	     */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord2200(Record2200 *pRec2200, int iCompID, char *psAccNum, char *psAccType, 
                   char *psName, char *psPlaName, char *psAdd1, 
                   char *psAdd2, char *psCity, char *psState, 
                   int iPostCode, char *psTelNum, char *psOffNum, 
                   char *psRFC, int iChargOffDate, char *psFaxNum,
                   char *psEmail, char *psEmpNum) 
#else
void GenRecord2200(pRec2200, iCompID, psAccNum, psAccType, psName, psPlaName, 
                   psAdd1, psAdd2, psCity, psState, iPostCode,
                   psTelNum, psOffNum, psRFC, iChargOffDate, psFaxNum,
                   psEmail, psEmpNum)
Record2200 *pRec2200;
int iCompID;
char *psAccNum;
char *psAccType;
char *psName;
char *psPlaName;
char *psAdd1;
char *psAdd2;
char *psCity;
char *psState;
int iPostCode;
char *psTelNum;
char *psOffNum;
char *psRFC;
int iChargOffDate;
char *psFaxNum;
char *psEmail;
char *psEmpNum;
#endif
{
   char sLastName[LEN255+1];       /* Apellido Paterno contenido en el parametro
                                      psPlaName. */
   char sLastNames[LEN255+1];      /* Apellidos Paterno y Materno contenidos en
                                      el parametro psName. */

   char *sNames[LEN20];            /* Nombre(s) contenidos en el parametro
                                      psName. */

   char *psString;                 /* Apuntador a una cadena determinada. */

   char sBirthYear[LEN2+1];        /* Annio de Nacimiento del Tarjetahabiente. */
   
   char sBirthMonth[LEN2+1];       /* Mes de Nacimiento del Tarjetahabiente. */
   
   char sBirthDay[LEN2+1];         /* Dia de Nacimiento del Tarjetahabiente. */

   char sBirthDate[LEN8+1];        /* Fecha de Nacimiento del Tarjetahabiente. */

   int  iNumNames;                 /* Numero Total de Nombres contenidos en
                                      sNames. */

   int iCounter;                   /* Contador de ciclos. */

   char sTemp[LEN255+1];           /* Cadena para procesos intermedios. */
   char sLastNameT[LEN255+1];       /* Cadena para procesos intermedios. */
   char sPlaNameT[LEN255+1];       /* Cadena para procesos intermedios. */
   char psNameT[LEN255+1];       /* Cadena para procesos intermedios. */
   char psNameT2[LEN255+1];       /* Cadena para procesos intermedios. */

   int iEncontroApellido;                   
   int iLenTemp;                   /* Longitud de Cadena Teporal. */
   int iLenTemp2;                   /* Longitud de Cadena Teporal. */
   int iLenTemp3;                   /* Longitud de Cadena Teporal. */
   char *apunta;
   char *apunta2;
   char *apunta3;


   strcpy(sLastName, EMPSTR);
   strcpy(sLastNames, EMPSTR);
   strcpy(sBirthYear, EMPSTR);
   strcpy(sBirthMonth, EMPSTR);
   strcpy(sBirthDay, EMPSTR);
   strcpy(sBirthDate, EMPSTR);
   strcpy(sTemp, EMPSTR);

   iNumNames = 0;
   iLenTemp = 0;
   iLenTemp2= 0;
   iLenTemp3= 0;

   /* Inicializa y reserva espacio para el arreglo de cadenas sNames. */

   for(iCounter=0; iCounter < LEN20; iCounter++)
   {
      sNames[iCounter] = malloc(LEN255 * sizeof(char));
      strcpy(sNames[iCounter], EMPSTR);
   }

   /* Inicializa la estructura 2000 200. */

   strcpy(pRec2200->sRecordID, EMPSTR);
   strcpy(pRec2200->sTypeID, EMPSTR);
   strcpy(pRec2200->sCompID, EMPSTR);
   strcpy(pRec2200->sSubCompID, EMPSTR);
   strcpy(pRec2200->sProcessor, EMPSTR);
   strcpy(pRec2200->sAccNumber, EMPSTR);
   strcpy(pRec2200->sAccType, EMPSTR);
   strcpy(pRec2200->sLastName, EMPSTR);
   strcpy(pRec2200->sCardHFirstN, EMPSTR);
   strcpy(pRec2200->sCardHMidN, EMPSTR);
   strcpy(pRec2200->sAddrLine1kanjiShiftOUT, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine1, EMPSTR);
   strcpy(pRec2200->sAddrLine1kanjiShiftIN, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine2kanjiShiftOUT, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine2, EMPSTR);
   strcpy(pRec2200->sAddrLine2kanjiShiftIN, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine3kanjiShiftOUT, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine3, EMPSTR);
   strcpy(pRec2200->sAddrLine3kanjiShiftIN, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine4SO, EMPSTR);			/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine4, EMPSTR);
   strcpy(pRec2200->sAddrLine4SI, EMPSTR);			/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine5, EMPSTR);
   strcpy(pRec2200->sCity, EMPSTR);
   strcpy(pRec2200->sStaCoPro, EMPSTR);
   strcpy(pRec2200->sPostalCode, EMPSTR);
   strcpy(pRec2200->sCountry, EMPSTR);
   strcpy(pRec2200->sNatID, EMPSTR);
   strcpy(pRec2200->sTelNumber, EMPSTR);
   strcpy(pRec2200->sWorkTelNumber, EMPSTR);
   strcpy(pRec2200->sIDVerifCode, EMPSTR);
   strcpy(pRec2200->sBirthDay, EMPSTR);
   strcpy(pRec2200->sCycleCode, EMPSTR);
   strcpy(pRec2200->sFaxNumber, EMPSTR);
   strcpy(pRec2200->sEmailAddr, EMPSTR);
   strcpy(pRec2200->sEmployeeID, EMPSTR);
   strcpy(pRec2200->sCliIDCustNum, EMPSTR);
   strcpy(pRec2200->sCustVATNum, EMPSTR);
   strcpy(pRec2200->sKanjiNameKanjiShiftOUT, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sKanjiNameKanji, EMPSTR);			/* FUN 20122004 */
   strcpy(pRec2200->sKanjiNameKanjiShiftIN, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine4kanjiShiftOUT, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine4kanji, EMPSTR);			/* FUN 20122004 */
   strcpy(pRec2200->sAddrLine4kanjiShiftIN, EMPSTR);		/* FUN 20122004 */
   strcpy(pRec2200->sFiller, EMPSTR);
   strcpy(pRec2200->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec2200->sRecordID, FMTREC2000);
   strcpy(pRec2200->sTypeID, FMTTYPEIND4);
   sprintf(pRec2200->sCompID, FMTNZLONG6, iCompID);                /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec2200->sSubCompID, FMTSUBCOID);
   strcpy(pRec2200->sProcessor, FMTBMX);
   sprintf(pRec2200->sAccNumber, FMTSLLONG25, psAccNum); 
   sprintf(pRec2200->sAccType, FMTSLONG1, psAccType);  /* Modificar pasar por parametro */

   /* Determina el Apellido Paterno del Tarjetahabiente. */
   iEncontroApellido=0;
   strcpy(sPlaNameT,psPlaName);
   apunta=strchr(sPlaNameT,',');
   apunta2=strchr(sPlaNameT,'/');
   if ( (apunta != NULL) && (apunta2 != NULL) )
   {
      apunta=apunta+1; /*para no considerar la coma como parte del apellido*/
      (*apunta2)='\0' ;/*para no considerar la diagonal como parte del apellido*/
      strcpy(sPlaNameT,apunta);
      quitaBlancos(sPlaNameT);
      iLenTemp=strlen(sPlaNameT);
      if( iLenTemp > 1) /* si es de una letra el apellido  NO se encontrara  */
        iEncontroApellido=1;
      else
        iEncontroApellido=0;
   }
   else
   {
      if(apunta != NULL)
      {
        apunta=apunta+1; /*para no considerar la coma como parte del apellido*/
        apunta3=strchr(apunta,' ');
        if (apunta3 != NULL)
        {
         (*apunta3)='\0';
         strcpy(sPlaNameT,apunta);
         quitaBlancos(sPlaNameT);
         iLenTemp=strlen(sPlaNameT);
         if( iLenTemp > 1)
           iEncontroApellido=1;
         else
           iEncontroApellido=0;
        }
        else 
        {
           iEncontroApellido=0;
        }
      }
      else
      {
        if (apunta2 != NULL)  
        {
          apunta2=apunta2+1; /*para no tomar la diagonal como parte apellido*/
          apunta3=strchr(apunta2,' ');
          if (apunta3 != NULL)
          {
            (*apunta3)='\0';
            strcpy(sPlaNameT,apunta2);
            quitaBlancos(sPlaNameT);
            iLenTemp=strlen(sPlaNameT);
            if( iLenTemp > 1)
              iEncontroApellido=1;
            else
              iEncontroApellido=0;
          }
          else
          {
            iEncontroApellido=0;
          }
        }
        else
        {
          iEncontroApellido=0;
        }
      }
   }

   /* Extrae los Apellidos Paterno y Materno del parametro psName. */
  /* Se agrega el siguiente codigo 26 de Dic 2006, 
  para considerar los nombres que en el apellido paterno tengan la letra Ñ
  debido a que para encontrar el(los) nombre(s) compara el apellido paterno del
  nombre de grabacion e intenta encontrarlo en el nombre largo, y existen
  varias posibilidades
  1. Existe @ en lugar de Ñ tanto en nombre largo como en nombre de grabacion
  2. Existe N en lugar de Ñ tanto en nombre largo como en nombre de grabacion
  3. Se captura N en lugar de Ñ en nombre largo  y @ en nombre de grabacion
  4. Se captura Ñ en nombre largo y @ en nombre de grabacion
  5. Se captura Ñ en nombre largo y N en nombre de grabacion
   en los dos primeros casos con la primer llamada de GetName encuentra bien el 
   nombre*/
   if( iEncontroApellido == 1 )
   {
   strcpy(sLastNameT,sPlaNameT); 
   strcpy(psNameT,psName); 
   if((psString = strstr(psNameT, sLastNameT)) != NULL)
   {
      /*se agrega la siguiente validacion debido a que se
      identifico que un nombre es identico al apellido por
      ejemplo LUNA LUNA RUIZ */
      strcpy(sTemp, psString);    
      iLenTemp=strlen(sTemp);
      iLenTemp2=strlen(psNameT);
      if (iLenTemp == iLenTemp2)
      {
        strcpy(sTemp,&psNameT[1]); /*se recorre una posicion hacia adelante el nombre largo para buscar de nuevo*/
        if((psString = strstr(sTemp, sLastNameT)) != NULL)
        {
          strcpy(sLastNames, psString);    
          iEncontroApellido=1;
        }
        else
        {
           iEncontroApellido=0;
        }
      }
      else
      {
        strcpy(sLastNames, sTemp);    
        iEncontroApellido=1;
      }
   }
   else 
   {  
      if( (apunta=strchr(sLastNameT,'@')) != NULL )
      {
        (*apunta)='Ñ';
        if((psString = strstr(psNameT, sLastNameT)) != NULL)
        {
          strcpy(sLastNames, psString);                    
          iEncontroApellido=1;
        }
        else
        {
           (*apunta)='N';
           if((psString = strstr(psNameT, sLastNameT)) != NULL)
           {
              strcpy(sLastNames, psString);
              iEncontroApellido=1;
           }
           else
           {
              strcpy(sLastNames, sLastNameT); 
              iEncontroApellido=0;
           }
        }
      }
      else
      {
         if(  (apunta=strchr(psNameT,'Ñ')) != NULL)
         {
           (*apunta)='N';
           if((psString = strstr(psNameT, sLastNameT)) != NULL)
           {
              strcpy(sLastNames, psString);                    
              iEncontroApellido=1;
           }
           else
           {
              strcpy(sLastNames, sLastNameT); 
              iEncontroApellido=0;
           }
         } 
         else
         {
            strcpy(sLastNames, sLastNameT); 
            iEncontroApellido=0;
         }
      }
   }
   }
   strcpy(psNameT,psName); 
   if( iEncontroApellido == 0 ) /* no encontro apellido */
   {
     iLenTemp3=strlen(psNameT);
     apunta=strtok(psNameT," ");
     iLenTemp2=strlen(apunta);
     if ( iLenTemp3 == iLenTemp2) /*NO encontro ningun blanco en nombre largo*/
     {                            /*Entonces deja nombre en apellido y nombres*/
       strncpy(sTemp, psNameT, LEN25);
       sTemp[LEN25] = EOLN;
       sprintf(pRec2200->sLastName, FMTSLLONG25, sTemp);
       sprintf(pRec2200->sCardHFirstN, FMTSLLONG25, sTemp);
       sTemp[0]='\0';
       sprintf(pRec2200->sCardHMidN, FMTSLLONG20, sTemp);
     }
     else
     { /*se separa la primer cadena como nombre principal */
       strcpy(sTemp, &psName[iLenTemp2+1]);
       sTemp[LEN25] = EOLN;
       sprintf(pRec2200->sLastName, FMTSLLONG25, sTemp);
       strcpy(sTemp, apunta);
       sTemp[LEN25] = EOLN;
       sprintf(pRec2200->sCardHFirstN, FMTSLLONG25, sTemp);
       sTemp[0]='\0';
       sprintf(pRec2200->sCardHMidN, FMTSLLONG20, sTemp);
     }
   }
   else
   {
       strcpy(psNameT,psName); 
       iLenTemp2=strlen(sLastNames);
       iLenTemp3=strlen(psNameT);
       iLenTemp2=iLenTemp3-iLenTemp2;
       if ( iLenTemp2 >= 0 )
         psNameT[iLenTemp2]='\0';  
       else
         psNameT[0]='\0';
       strcpy(sTemp, sLastNames);
       sTemp[LEN25] = EOLN;
       sprintf(pRec2200->sLastName, FMTSLLONG25, sTemp);
       strcpy(sTemp,psNameT);
       apunta=strtok(sTemp," "); /*detecta el primer nombre*/
       strcpy(sTemp,apunta);
       iLenTemp2=strlen(sTemp); 
       sTemp[LEN25] = EOLN;
       sprintf(pRec2200->sCardHFirstN, FMTSLLONG25, sTemp);
       strcpy(sTemp,&psNameT[iLenTemp2+1]);
       sTemp[LEN20] = EOLN;
       sprintf(pRec2200->sCardHMidN, FMTSLLONG20, sTemp);
        
   }
   sprintf(pRec2200->sAddrLine1kanjiShiftOUT, FMTSLONG1, EMPSTR);		/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine1, FMTSLLONG40, psAdd1);
   sprintf(pRec2200->sAddrLine1kanjiShiftIN, FMTSLONG1, EMPSTR);		/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine2kanjiShiftOUT, FMTSLONG1, EMPSTR);		/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine2, FMTSLLONG40, psAdd2);
   sprintf(pRec2200->sAddrLine2kanjiShiftIN, FMTSLONG1, EMPSTR);		/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine3kanjiShiftOUT, FMTSLONG1, EMPSTR);		/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine3, FMTSLLONG40, EMPSTR);
   sprintf(pRec2200->sAddrLine3kanjiShiftIN, FMTSLONG1, EMPSTR);		/* FUN 20122004 */
  

   sprintf(pRec2200->sAddrLine4SO, FMTSLONG1, EMPSTR);				/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine4, FMTSLLONG40, EMPSTR); 
   sprintf(pRec2200->sAddrLine4SI, FMTSLONG1, EMPSTR);				/* FUN 20122004 */
   

   sprintf(pRec2200->sAddrLine5, FMTSLLONG40, EMPSTR); 
   sprintf(pRec2200->sCity, FMTSLLONG25, psCity);

   strncpy(sTemp, psState, LEN25);
   sTemp[LEN25] = EOLN;            
   sprintf(pRec2200->sStaCoPro, FMTSLLONG25, sTemp);

   sprintf(pRec2200->sPostalCode, FMTNLONG10, iPostCode);   /* CODIGO POSTAL CORREGIDO JAGG antes FMTNZLONG10 */
   sprintf(pRec2200->sCountry, FMTSLLONG20, FMTCOUNTRY);    /* PAIS CORREGIDO antes EMPSTR */


   sprintf(pRec2200->sNatID, FMTSLLONG30, EMPSTR);
   sprintf(pRec2200->sTelNumber, FMTTEL18, psTelNum );
   sprintf(pRec2200->sWorkTelNumber, FMTTEL18, psOffNum);
   sprintf(pRec2200->sIDVerifCode, FMTSLLONG15, EMPSTR);
   /* Determinar la Fecha de Nacimiento del Tarjetahabiente tomando como
      referencia el Registro Federal de Causante (psRFC). */

   strcpy(sTemp, psElimChar(psRFC, ' '));
   
   obtenFecha( sTemp, sBirthDate );
   
   sprintf(pRec2200->sBirthDay, FMTSLLONG8, sBirthDate);

   sprintf(pRec2200->sCycleCode, FMTNZLONG2, iChargOffDate);
   sprintf(pRec2200->sFaxNumber, FMTTEL18, psFaxNum);

   strncpy(sTemp, psEmail, LEN60);
   sTemp[LEN60] = EOLN;         
   sprintf(pRec2200->sEmailAddr, FMTSLLONG60, sTemp);

   sprintf(pRec2200->sEmployeeID, FMTSLLONG20, psEmpNum);
   sprintf(pRec2200->sCliIDCustNum, FMTSLLONG20, EMPSTR);
   sprintf(pRec2200->sCustVATNum, FMTSLLONG20, EMPSTR);

   sprintf(pRec2200->sKanjiNameKanjiShiftOUT, FMTSLONG1, EMPSTR);	/* FUN 20122004 */
   sprintf(pRec2200->sKanjiNameKanji, FMTSLLONG50, EMPSTR);		/* FUN 20122004 */
   sprintf(pRec2200->sKanjiNameKanjiShiftIN, FMTSLONG1, EMPSTR);	/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine4kanjiShiftOUT, FMTSLONG1, EMPSTR);	/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine4kanji, FMTSLLONG60, EMPSTR);		/* FUN 20122004 */
   sprintf(pRec2200->sAddrLine4kanjiShiftIN, FMTSLONG1, EMPSTR);	/* FUN 20122004 */


   sprintf(pRec2200->sFiller, FMTSLLONG204, EMPSTR);
   sprintf(pRec2200->sTRXContData, FMTSLLONG50, EMPSTR);


}

/* NOMBRE       : SaveRecord2200                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 2000 200.                      */
/* PARAMETROS 	:                                                            */
/*    pRec2200 = Registro 2000 200 con datos.                                */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 14/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     14/07/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón	      20/12/2004     Segunda Version	     */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord2200(Record2200 *pRec2200, FILE *pFileReg) 
#else
void SaveRecord2200(pRec2200, pFileReg)
Record2200 *pRec2200;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n", 
                                         pRec2200->sRecordID,
                                         pRec2200->sTypeID, 
                                         pRec2200->sCompID,
                                         pRec2200->sSubCompID,
                                         pRec2200->sProcessor,
                                         pRec2200->sAccNumber,
                                         pRec2200->sAccType,
                                         pRec2200->sLastName,
                                         pRec2200->sCardHFirstN,
                                         pRec2200->sCardHMidN,
					 pRec2200->sAddrLine1kanjiShiftOUT,
                                         pRec2200->sAddrLine1,
					 pRec2200->sAddrLine1kanjiShiftIN,
					 pRec2200->sAddrLine2kanjiShiftOUT,
                                         pRec2200->sAddrLine2,
					 pRec2200->sAddrLine2kanjiShiftIN,
					 pRec2200->sAddrLine3kanjiShiftOUT,
                                         pRec2200->sAddrLine3,
					 pRec2200->sAddrLine3kanjiShiftIN,
					 pRec2200->sAddrLine4SO,
                                         pRec2200->sAddrLine4,
					 pRec2200->sAddrLine4SI,
                                         pRec2200->sAddrLine5,
                                         pRec2200->sCity,
                                         pRec2200->sStaCoPro,
                                         pRec2200->sPostalCode,
                                         pRec2200->sCountry,
                                         pRec2200->sNatID,
                                         pRec2200->sTelNumber,
                                         pRec2200->sWorkTelNumber,
                                         pRec2200->sIDVerifCode,
                                         pRec2200->sBirthDay,
                                         pRec2200->sCycleCode,
                                         pRec2200->sFaxNumber,
                                         pRec2200->sEmailAddr,
                                         pRec2200->sEmployeeID,
                                         pRec2200->sCliIDCustNum,
                                         pRec2200->sCustVATNum,
					 pRec2200->sKanjiNameKanjiShiftOUT,
					 pRec2200->sKanjiNameKanji,
					 pRec2200->sKanjiNameKanjiShiftIN,
					 pRec2200->sAddrLine4kanjiShiftOUT,
					 pRec2200->sAddrLine4kanji,
					 pRec2200->sAddrLine4kanjiShiftIN,
                                         pRec2200->sFiller,
                                         pRec2200->sTRXContData);
}


/* NOMBRE       : GenRecord2001                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 2001 210  del Formato CCF.                        */
/* PARAMETROS 	:                                                            */
/*    pRec2001 = Registro 2001 210 a inicializar.                            */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psAccNum = Numero de Cuenta.                                           */
/*    psMAccNum = Numero de Cuenta de la Empresa.                            */
/*    iOpenDate = Fecha de Apertura de la Cuenta.                            */
/*    psRating = Estatus Actual de la Cuenta.                                */
/*    iCredLim = Limite de Credito asignado al Tarjetahabiente.              */
/*    psPlaName = Nombre del Tarjetahabiente tal como aparece en el          */
/*                Plastico.                                                  */
/*    psCompName = Nombre de la Empresa.                                     */
/*    iValidDate = Fecha de Alta del Tarjetahabiente.                        */
/*    iLastPayDate = Fecha de Ultimo Pago del Tarjetahabiente.               */
/*    dCurrBal = Saldo Actual del Tarjetahabiente.                           */
/*    dPrevBal = Saldo Anterior del Tarjetahabiente.                         */
/*    dPayDue = Minimo a Pagar por Parte del Tarjetahabiente.                */ 
/*    psPayDate = Fecha Limite de Pago del Tarjetahabiente.                  */
/*    iLastMaintDate = Fecha de Ultimo Movimiento aplicado a la Cuenta.      */
/*    psBillType = Tipo de Facturacion aplicado a la Cuenta.                 */
/*    psTransAcc = Descripcion de Situacion Actual de la Cuenta.             */
/*    psTransStatus = Clave de Situacion Actual de la Cuenta.                */
/*    dChargeOffBal = Saldo Maximo del Tarjetahabiente.                      */
/*    psOthAccNum = Numero de Cuenta Maestra.                                */
/*    iPerCashLim = Porcentaje Maximo de Disp. de Efectivo.                  */
/* SALIDAS      :                                                            */
/*    Registro 2001 210 inicializado.                                        */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 14/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     14/07/2003     Primera Version         */
/*     FUN Felipe Uribe Negrón	      20/12/2004     Segunda Version	     */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord2001(Record2001 *pRec2001, int iCompID, char *psAccNum, char *psParAccNum, 
                   char *psMAccNum, int iOpenDate, char *psRating,
                   int iCredLim, char *psPlaName, char *psCompName,
                   int iValidDate, int iLastPayDate, double dCurrBal,
                   double dPrevBal, double dPayDue, char *psPayDate,
                   int iLastMaintDate, char *psBillType, char *psTransAcc,
                   char *psTransStatus, double dChargeOffBal, char *psOthAccNum,
                   int iPerCashLim)
#else
void GenRecord2001(pRec2001, iCompID, psAccNum, psParAccNumber, psMAccNum, iOpenDate,
                   psRating, iCredLim, psPlaName, psCompName, iValidDate,
                   iLastPayDate, dCurrBal, dPrevBal, dPayDue, psPayDate,
                   iLastMaintDate, psBillType, psTransAcc, psTransStatus,
                   dChargeOffBal, psOthAccNum, iPerCashLim)
Record2001 *pRec2001;
int iCompID;
char *psAccNum;
char *psParAccNum;
char *psMAccNum;
int iOpenDate;
char *psRating;
int iCredLim;
char *psPlaName;
char *psCompName;
int iValidDate;
int iLastPayDate;
double dCurrBal;
double dPrevBal;
double dPayDue;
char *psPayDate;
int iLastMaintDate;
char *psBillType;
char *psTransAcc;
char *psTransStatus;
double dChargeOffBal;
char *psOthAccNum;
int iPerCashLim;
#endif
{
   int   iCounter;               /* Contador de ciclos. */
   char  sCardActDate[LEN8+1];   /* Fecha de Activacion de la Tarjeta. */ 
   double dCashAdvLim;           /* Limite de Disposiciones de Efectivo. */
   char sTemp[LEN255+1];         /* Cadena para procesos intermedios. */
   char sBillVrtCtrl[ 25 + 1 ]; 

   strcpy(sCardActDate, EMPSTR);
   strcpy(sTemp, EMPSTR);
   dCashAdvLim=0.0;

   /* Inicializa la estructura 2001 210. */

   strcpy(pRec2001->sRecordID, EMPSTR);
   strcpy(pRec2001->sTypeID, EMPSTR);
   strcpy(pRec2001->sCompID, EMPSTR);
   strcpy(pRec2001->sSubCompID, EMPSTR);
   strcpy(pRec2001->sProcessor, EMPSTR);
   strcpy(pRec2001->sAccNumber, EMPSTR);
   strcpy(pRec2001->sContBillVirt, EMPSTR);
   strcpy(pRec2001->sMastAccCode, EMPSTR);
   strcpy(pRec2001->sCityPairCode, EMPSTR);
   strcpy(pRec2001->sTaxExemptNum, EMPSTR);
   strcpy(pRec2001->sTaxExemptFlag, EMPSTR);
   strcpy(pRec2001->sTaxExemptSta, EMPSTR);
   strcpy(pRec2001->sNumCards, EMPSTR);
   strcpy(pRec2001->sOpenDate, EMPSTR);
   strcpy(pRec2001->sCredRat, EMPSTR);
   strcpy(pRec2001->sCredLim, EMPSTR);
   strcpy(pRec2001->sSingTranLim, EMPSTR);
   strcpy(pRec2001->sPrimEmbName, EMPSTR);
   strcpy(pRec2001->sEmbLegend, EMPSTR);
   strcpy(pRec2001->sCardActDate, EMPSTR);
   strcpy(pRec2001->sLastPayDate, EMPSTR);
   strcpy(pRec2001->sBillCurr, EMPSTR);
   strcpy(pRec2001->sCurrBalance, EMPSTR);
   strcpy(pRec2001->sPayAmtDue, EMPSTR);
   strcpy(pRec2001->sPayDueDate, EMPSTR);
   strcpy(pRec2001->sTransRoutNum, EMPSTR);
   strcpy(pRec2001->sDDANumber, EMPSTR);
   strcpy(pRec2001->sAuthStatus, EMPSTR);
   strcpy(pRec2001->sNewCardInd, EMPSTR);
   strcpy(pRec2001->sNewCardSerNum, EMPSTR);
   strcpy(pRec2001->sLastMaintDate, EMPSTR);
   strcpy(pRec2001->sPinReqFlag, EMPSTR);
   strcpy(pRec2001->sBillType, EMPSTR);
   strcpy(pRec2001->sTransfAcc, EMPSTR);
   strcpy(pRec2001->sTransfSta, EMPSTR);
   strcpy(pRec2001->sTransfReason, EMPSTR);
   strcpy(pRec2001->sTransfDate, EMPSTR);
   strcpy(pRec2001->sChargeOffSta, EMPSTR);
   strcpy(pRec2001->sChargeOffDate, EMPSTR);
   strcpy(pRec2001->sChargeOffBal, EMPSTR);
   strcpy(pRec2001->sChargeOffReason, EMPSTR);
   strcpy(pRec2001->sOthAccNBR, EMPSTR);
   strcpy(pRec2001->sCVRStatus, EMPSTR);
   strcpy(pRec2001->sCashAdvLim, EMPSTR);
   strcpy(pRec2001->sCashAdvLimFreq, EMPSTR);
   strcpy(pRec2001->sEcsAccountStatus, EMPSTR);				/*fun 20122004 */
   strcpy(pRec2001->sEcsBlockCode, EMPSTR);				/*fun 20122004 */
   strcpy(pRec2001->sEcsBlockReason, EMPSTR);				/*fun 20122004 */
   strcpy(pRec2001->sPreviewBalance, EMPSTR);
   strcpy(pRec2001->sNumberOfCyclesPastDue, EMPSTR);			/*fun 20122004 */
   strcpy(pRec2001->sFiller, EMPSTR);
   strcpy(pRec2001->sTRXContData, EMPSTR);
 
   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec2001->sRecordID, FMTREC2001);
   strcpy(pRec2001->sTypeID, FMTTYPEIND5);
   sprintf(pRec2001->sCompID, FMTNZLONG6, iCompID);                /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec2001->sSubCompID, FMTSUBCOID);
   strcpy(pRec2001->sProcessor, FMTBMX);
   sprintf(pRec2001->sAccNumber, FMTSLLONG25, psAccNum);
   strcpy( sBillVrtCtrl, "000000000");
   strcat( sBillVrtCtrl, psParAccNum );
   sprintf(pRec2001->sContBillVirt, FMTSLLONG25, sBillVrtCtrl );
   sprintf(pRec2001->sMastAccCode, FMTSLLONG150, EMPSTR); /* Deben de Ir Ceros antes psMAccNum JAGG */
   sprintf(pRec2001->sCityPairCode, FMTSLONG1, EMPSTR); 
   sprintf(pRec2001->sTaxExemptNum, FMTSLLONG20, EMPSTR);
   sprintf(pRec2001->sTaxExemptFlag, FMTSLONG1, EMPSTR);
   sprintf(pRec2001->sTaxExemptSta, FMTSLLONG3, EMPSTR);
   strcpy(pRec2001->sNumCards, FMTNUMCARDS);
   sprintf(pRec2001->sOpenDate, FMTNZLONG8, iOpenDate);
   sprintf(pRec2001->sCredRat, FMTSLLONG2, psRating);
   sprintf(pRec2001->sCredLim, FMTZIPLONG18, iCredLim);
   //iImplicitPoint( pRec2001->sCredLim );
   strcpy( sBillVrtCtrl, "000000000");
   strcpy(pRec2001->sSingTranLim, "000000000000000000");
   /*sprintf(pRec2001->sSingTranLim, FMTCURLONG18, FMTZERO );
   iImplicitPoint( pRec2001->sSingTranLim );*/
   /* Ajusta el contenido del campo sPrimEmbName. */

   strcpy(sTemp, psPlaName);

   for(iCounter = 0; sTemp[iCounter] != EOLN; iCounter++)
   {
      if((sTemp[iCounter] == DIAG) || (sTemp[iCounter] == COMMA))

         sTemp[iCounter] = SPACEC;
   }

   sprintf(pRec2001->sPrimEmbName, FMTSLLONG30, sTemp);

   strncpy(sTemp, psCompName, LEN26);                   
   sTemp[LEN26] = EOLN;                            
   sprintf(pRec2001->sEmbLegend, FMTSLLONG26, sTemp);

   /* Ajusta el valor de iValidDate. */

   if( iValidDate > 0 ){
   	sprintf(sCardActDate, FMTPLADATE, (long )iValidDate);
   	sprintf(pRec2001->sCardActDate, FMTSLLONG8, sCardActDate);
   }
   else
		sprintf(pRec2001->sCardActDate, FMTSLLONG8, "");
		
   sprintf(pRec2001->sLastPayDate, FMTNZLONG8, iLastPayDate);
   strcpy(pRec2001->sBillCurr, FMTIAMEXCURR);
   sprintf(pRec2001->sCurrBalance, FMTCURLONG18, dCurrBal); 
   iImplicitPoint( pRec2001->sCurrBalance );
   sprintf(pRec2001->sPayAmtDue, FMTCURLONG18, dPayDue); 
   iImplicitPoint( pRec2001->sPayAmtDue );
   sprintf(pRec2001->sPayDueDate, FMTSLLONG8, psPayDate);
   sprintf(pRec2001->sTransRoutNum, FMTZLONG9, FMTZERO);
   sprintf(pRec2001->sDDANumber, FMTSLLONG25, EMPSTR);
   sprintf(pRec2001->sAuthStatus, FMTSLLONG4, EMPSTR);
   sprintf(pRec2001->sNewCardInd, FMTSLONG1, EMPSTR);
   sprintf(pRec2001->sNewCardSerNum, FMTSLLONG20, EMPSTR);
   sprintf(pRec2001->sLastMaintDate, FMTNZLONG8, iLastMaintDate);
   sprintf(pRec2001->sPinReqFlag, FMTSLONG1, EMPSTR);
   strcpy(pRec2001->sBillType, psBillType);
   /*sprintf(pRec2001->sTransfAcc, FMTSLLONG25, psTransAcc);*/
   sprintf(pRec2001->sTransfAcc, FMTSLLONG25, "");
   sprintf(pRec2001->sTransfSta, FMTSLONG1, EMPSTR);
   sprintf(pRec2001->sTransfReason, FMTSLONG1, EMPSTR);
   
   if( iValidDate > 0 )
   	sprintf(pRec2001->sTransfDate, FMTSLLONG8, sCardActDate );
   else
   	sprintf(pRec2001->sTransfDate, FMTSLLONG8, "" );
   	
   sprintf(pRec2001->sChargeOffSta, FMTSLONG1, EMPSTR);
   sprintf(pRec2001->sChargeOffDate, FMTSLLONG8, EMPSTR);		/*fun 20122004    se cambio la long de 6 a 8*/
   sprintf(pRec2001->sChargeOffBal, FMTCURLONG18, dChargeOffBal); 
   iImplicitPoint( pRec2001->sChargeOffBal );
   sprintf(pRec2001->sChargeOffReason, FMTSLONG1, EMPSTR);
   sprintf(pRec2001->sOthAccNBR, FMTSLLONG25, psOthAccNum);
   sprintf(pRec2001->sCVRStatus, FMTSLONG1, EMPSTR);
   dCashAdvLim = ((double) iCredLim) * (((double) iPerCashLim) / FMT100PERC);
   sprintf(pRec2001->sCashAdvLim, FMTCURLONG18, dCashAdvLim); 
   iImplicitPoint( pRec2001->sCashAdvLim );
   sprintf(pRec2001->sCashAdvLimFreq, FMTSLLONG3, EMPSTR);


   sprintf(pRec2001->sEcsAccountStatus, FMTZLONG1, FMTZERO );			/*fun 20122004 */
   sprintf(pRec2001->sEcsBlockCode, FMTSLONG1, EMPSTR);				/*fun 20122004 */
   sprintf(pRec2001->sEcsBlockReason, FMTSLLONG2, EMPSTR);			/*fun 20122004 */

   sprintf(pRec2001->sPreviewBalance, FMTCURLONG18, dPrevBal);
   iImplicitPoint( pRec2001->sPreviewBalance );

   sprintf(pRec2001->sNumberOfCyclesPastDue, FMTZLONG2, FMTZERO);		/*fun 20122004 */

/*   sprintf(pRec2001->sFiller, FMTSLLONG356, EMPSTR);				fun 30122004*/

   sprintf(pRec2001->sFiller, FMTSLLONG336, EMPSTR);				/*fun 30122004*/

   sprintf(pRec2001->sTRXContData, FMTSLLONG50, EMPSTR);
}

/* NOMBRE       : SaveRecord2001                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 2001 210.                      */
/* PARAMETROS 	:                                                            */
/*    pRec2001 = Registro 2001 210 con datos.                                */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 15/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     15/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord2001(Record2001 *pRec2001, FILE *pFileReg) 
#else
void SaveRecord2001(pRec2001, pFileReg)
Record2001 *pRec2001;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n",
                                         pRec2001->sRecordID,
                                         pRec2001->sTypeID,
                                         pRec2001->sCompID,
                                         pRec2001->sSubCompID,
                                         pRec2001->sProcessor,
                                         pRec2001->sAccNumber,
                                         pRec2001->sContBillVirt,
                                         pRec2001->sMastAccCode,
                                         pRec2001->sCityPairCode,
                                         pRec2001->sTaxExemptNum,
                                         pRec2001->sTaxExemptFlag,
                                         pRec2001->sTaxExemptSta,
                                         pRec2001->sNumCards,
                                         pRec2001->sOpenDate,
                                         pRec2001->sCredRat,
                                         pRec2001->sCredLim,
                                         pRec2001->sSingTranLim,
                                         pRec2001->sPrimEmbName,
                                         pRec2001->sEmbLegend,
                                         pRec2001->sCardActDate,
                                         pRec2001->sLastPayDate,
                                         pRec2001->sBillCurr,
                                         pRec2001->sCurrBalance,
                                         pRec2001->sPayAmtDue,
                                         pRec2001->sPayDueDate,
                                         pRec2001->sTransRoutNum,
                                         pRec2001->sDDANumber,
                                         pRec2001->sAuthStatus,
                                         pRec2001->sNewCardInd,
                                         pRec2001->sNewCardSerNum,
                                         pRec2001->sLastMaintDate,
                                         pRec2001->sPinReqFlag,
                                         pRec2001->sBillType,
                                         pRec2001->sTransfAcc,
                                         pRec2001->sTransfSta,
                                         pRec2001->sTransfReason,
                                         pRec2001->sTransfDate,
                                         pRec2001->sChargeOffSta,
                                         pRec2001->sChargeOffDate,
                                         pRec2001->sChargeOffBal,
                                         pRec2001->sChargeOffReason,
                                         pRec2001->sOthAccNBR,
                                         pRec2001->sCVRStatus,
                                         pRec2001->sCashAdvLim,
                                         pRec2001->sCashAdvLimFreq,
					 pRec2001->sEcsAccountStatus,			/*fun 20122004 */
					 pRec2001->sEcsBlockCode,			/*fun 20122004 */
					 pRec2001->sEcsBlockReason,			/*fun 20122004 */
                                         pRec2001->sPreviewBalance,
					 pRec2001->sNumberOfCyclesPastDue, 		/*fun 20122004 */
                                         pRec2001->sFiller,
                                         pRec2001->sTRXContData);
}


/* NOMBRE       : GenRecord5500                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 5000 500  del Formato CCF.                        */
/* PARAMETROS 	:                                                            */
/*    pRec5500 = Registro 5000 500 a inicializar.                            */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psAccNum = Numero de Cuenta.                                           */
/*    iTransDate = Fecha de la Transaccion.                                  */
/*    iTransTime = Hora de la Transaccion.                                   */
/*    iPostDate = Fecha de Procesamiento de la Transaccion.                  */
/*    dTransAmt = Monto de la Transaccion.                                   */
/*    iRef1 = Clave de Referencia de la Transaccion (Parte 1).               */
/*    dRef2 = Clave de Referencia de la Transaccion (Parte 2).               */
/*    iTransID = Identificador de la Transaccion.                            */
/*    iMCC = Clave MCC.                                                      */
/*    psDescMCC = Descripcion Clave MCC.                                     */
/*    iMerchID = Clave del Negocio.                                          */
/*    psMerchName = Nombre del Negocio.                                      */
/*    psMerchCity = Ciudad de Residencia del Negocio.                        */
/*    psMerchCtry = Pais de Residencia del Negocio.                          */
/*    dDollars = Monto en Dolares de la Transaccion.                         */
/*    psOthAccNum = Numero de Cuenta Maestra.                                */
/*    psTraSign = Signo de la Transaccion.                                   */
/*    psTraType = Tipo  de la Transaccion.  agrega yuria                     */
/*    psMemoFlag = Valor del campo Memo Flag.                                */
/* SALIDAS      :                                                            */
/*    Registro 5000 500 inicializado.                                        */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 16/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     16/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord5500(Record5500 *pRec5500, int iCompID, char *psAccNum, 
                   int iTransDate, int iTransTime, int iPostDate,
                   double dTransAmt, int iRef1, double dRef2, int iTransID, 
                   int iMCC, char *psDescMCC, int iMerchID, char *psMerchName,
                   char *psMerchCity, char *psMerchCtry, double dDollars,
                   char *psOthAccNum, char *psTraSign, char *psTraType,char *psMemoFlag, int iTransIDSBF ) /*agrega yura psTraType*/
#else
void GenRecord5500(pRec5500, iCompID, psAccNum, iTransDate, iTransTime,
                   iPostDate, dTransAmt, iRef1, dRef2, iTransID, iMCC,
                   psDescMCC, iMerchID, psMerchName, psMerchCity, psMerchCtry, 
                   dDollars, psOthAccNum, psTraSign, psTraType, psMemoFlag, iTransIDSBF )
Record5500 *pRec5500;
int iCompID;
char *psAccNum;
int iTransDate;
int iTransTime;
int iPostDate;
double dTransAmt;
int iRef1;
double dRef2;
int iTransID;
int iMCC;
char *psDescMCC;
int iMerchID;
char *psMerchName;
char *psMerchCity;
char *psMerchCtry;
double dDollars;
char *psOthAccNum;
char *psTraSign;
char *psTraType; /* agrega yuria*/
char *psMemoFlag;
int iTransIDSBF;
#endif
{
   char sMCC[LEN255+1];   /* Clave MCC. */
   char sSBFCodes[ 4 + 1 ];  /* Codigo SBF */
   int  iCutPosMCC;       /* Posicion de Corte para Clave MCC. */
   int i,j;
   int paisdesconocido; /*agrega yuria para rutina de pais */
   int es_num;
   int monedaUsual;
   float tasaConversion;
   int iMCCvalidado;

   char sTemp[LEN255+1];  /* Cadena para procesos intermedios. */
   char sMerchRefNumb[ 25 + 1 ];

   strcpy(sMCC, EMPSTR); 
   strcpy(sTemp, EMPSTR); 
   iCutPosMCC=0;

   /* Inicializa la estructura 5000 500. */

   strcpy(pRec5500->sRecordID, EMPSTR);
   strcpy(pRec5500->sTypeID, EMPSTR);
   strcpy(pRec5500->sCompID, EMPSTR);
   strcpy(pRec5500->sSubCompID, EMPSTR);
   strcpy(pRec5500->sCBSTRRunDate, EMPSTR);
   strcpy(pRec5500->sAccNumber, EMPSTR);
   strcpy(pRec5500->sTransDate, EMPSTR);
   strcpy(pRec5500->sTransTime, EMPSTR);
   strcpy(pRec5500->sPostDate, EMPSTR);
   strcpy(pRec5500->sTransAmt, EMPSTR);
   strcpy(pRec5500->sAuthReq, EMPSTR);
   strcpy(pRec5500->sAuthID, EMPSTR);
   strcpy(pRec5500->sConversDate, EMPSTR);
   strcpy(pRec5500->sPosEntry, EMPSTR);
   strcpy(pRec5500->sPosCondCode, EMPSTR);
   strcpy(pRec5500->sAcquirerID, EMPSTR);
   strcpy(pRec5500->sReferenceNum, EMPSTR);
   strcpy(pRec5500->sTraceNumber, EMPSTR);
   strcpy(pRec5500->sTransCurrCD, EMPSTR);
   strcpy(pRec5500->sTransID, EMPSTR);
   strcpy(pRec5500->sMCC, EMPSTR);
   strcpy(pRec5500->sMCCInfoData, EMPSTR);
   strcpy(pRec5500->sMerchAccepId, EMPSTR);
   strcpy(pRec5500->sMerchDescrip, EMPSTR);
   strcpy(pRec5500->sMerchantCity, EMPSTR);
   strcpy(pRec5500->sMerchantStaProv, EMPSTR);
   strcpy(pRec5500->sMerchantPostCod, EMPSTR);
   strcpy(pRec5500->sMerchCountry, EMPSTR);
   strcpy(pRec5500->sMerchVatNumber, EMPSTR);
   strcpy(pRec5500->sMerchDescFlag, EMPSTR);
   strcpy(pRec5500->sMerchRefNumber, EMPSTR);
   strcpy(pRec5500->sSourceCurr, EMPSTR);
   strcpy(pRec5500->sSourceAmt, EMPSTR);
   strcpy(pRec5500->sBillCurrency, EMPSTR);
   strcpy(pRec5500->sBillAmt, EMPSTR);
   strcpy(pRec5500->sSettlemCurr, EMPSTR);
   strcpy(pRec5500->sSettlemAmt, EMPSTR);
   strcpy(pRec5500->sUSDollarCurr, EMPSTR);
   strcpy(pRec5500->sUSDollarAmt, EMPSTR);
   strcpy(pRec5500->sGBPoundCurr, EMPSTR);
   strcpy(pRec5500->sGBPoundAmt, EMPSTR);
   strcpy(pRec5500->sEuroCurr, EMPSTR);
   strcpy(pRec5500->sEuroAmt, EMPSTR);
   strcpy(pRec5500->sAsiaYenCurr, EMPSTR);
   strcpy(pRec5500->sAsiaYenAmt, EMPSTR);
   strcpy(pRec5500->sSwedKronCurr, EMPSTR);
   strcpy(pRec5500->sSwedKronAmt, EMPSTR);
   strcpy(pRec5500->sCanadianCurr, EMPSTR);
   strcpy(pRec5500->sCanadianAmt, EMPSTR);
   strcpy(pRec5500->sConvRate, EMPSTR);
   strcpy(pRec5500->sDBCRFlag, EMPSTR);
   strcpy(pRec5500->sMemoFlag, EMPSTR);
   strcpy(pRec5500->sCorpAcctNum, EMPSTR);
   strcpy(pRec5500->sSalesTax, EMPSTR);
   strcpy(pRec5500->sSalesTaxFlag, EMPSTR);
   strcpy(pRec5500->sVATTax, EMPSTR);
   strcpy(pRec5500->sVATTaxFlag, EMPSTR);
   strcpy(pRec5500->sPurchaseID, EMPSTR);
   strcpy(pRec5500->sPurchIDFlag, EMPSTR);
   strcpy(pRec5500->sTranType, EMPSTR);
   strcpy(pRec5500->sNumAddendums, EMPSTR);
   strcpy(pRec5500->sVisaTranCode, EMPSTR);
   strcpy(pRec5500->sAddendumKey, EMPSTR);
   strcpy(pRec5500->sTicketNumber, EMPSTR);
   strcpy(pRec5500->sMsgType, EMPSTR);
   strcpy(pRec5500->sFiller1, EMPSTR);
   strcpy(pRec5500->sVATEvidenceFlag, EMPSTR);
   strcpy(pRec5500->sCustRefNum, EMPSTR);
   strcpy(pRec5500->sDiscountAmt, EMPSTR);
   strcpy(pRec5500->sBillingDate, EMPSTR);
   strcpy(pRec5500->sFiller2, EMPSTR);
   strcpy(pRec5500->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec5500->sRecordID, FMTREC5000);
   strcpy(pRec5500->sTypeID, FMTTYPEIND6);
   sprintf(pRec5500->sCompID, FMTNZLONG6, iCompID); /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec5500->sSubCompID, FMTSUBCOID);
   sprintf(pRec5500->sCBSTRRunDate, FMTSLLONG8, EMPSTR);
   sprintf(pRec5500->sAccNumber, FMTSLLONG25, psAccNum);
   sprintf(pRec5500->sTransDate, FMTNZLONG8, iTransDate);
   sprintf(pRec5500->sTransTime, FMTNZLONG8, iTransTime);
   sprintf(pRec5500->sPostDate, FMTNZLONG8, iPostDate);

   /* Calculo del Signo del Monto de la Transaccion. */
   if(strcmp(psTraSign, FMTDEBTRAN) == 0)
   {
      strcpy(pRec5500->sDBCRFlag, FMTDBCRFLAG1);
   }
   else
   {
      if(strcmp(psTraSign, FMTCREDTRAN) == 0)
      {
         strcpy(pRec5500->sDBCRFlag, FMTDBCRFLAG2);
   
         if(dTransAmt < 0.0)
            dTransAmt*=-1;
      } else {
         strcpy(pRec5500->sDBCRFlag, FMTDBCRFLAG2);  /**VALOR POR DEFAULT  CREDITO 2 **/
     }
   }
 
   sprintf(pRec5500->sTransAmt, FMTCURLONG18, dTransAmt);
   iImplicitPoint( pRec5500->sTransAmt );

   sprintf(pRec5500->sAuthReq, FMTSLONG1, EMPSTR);
   sprintf(pRec5500->sAuthID, FMTSLLONG6, EMPSTR);
   sprintf(pRec5500->sConversDate, FMTSLLONG8, EMPSTR);
   sprintf(pRec5500->sPosEntry, FMTSLLONG12, EMPSTR);
   sprintf(pRec5500->sPosCondCode, FMTSLLONG2, EMPSTR);
   sprintf(pRec5500->sAcquirerID, FMTSLLONG15, EMPSTR);
   sprintf(pRec5500->sReferenceNum, FMTTRANSREF, iRef1, dRef2);
   sprintf(pRec5500->sTraceNumber, FMTSLLONG6, EMPSTR);
   strcpy(pRec5500->sTransCurrCD, FMTIAMEXCURR);
   strcpy(sTemp, psInt2Char(iTransID));
   sprintf(pRec5500->sTransID, FMTSLLONG15, sTemp);
   strncpy(sTemp, psDescMCC, LEN19);                
   sTemp[LEN19] = EOLN;                            
   sprintf(pRec5500->sMCCInfoData, FMTSLLONG19, sTemp);
   sprintf(pRec5500->sMerchAccepId, FMTNZLONG16, iMerchID);
   sprintf(pRec5500->sMerchDescrip, FMTSLLONG40, psMerchName);
   sprintf(pRec5500->sMerchantCity, FMTSLLONG15, psMerchCity);

   sprintf(pRec5500->sMerchantPostCod, FMTSLLONG10, EMPSTR);
   sprintf(pRec5500->sMerchVatNumber, FMTSLLONG20, EMPSTR);
   sprintf(pRec5500->sMerchDescFlag, FMTSLONG1, EMPSTR);
   sprintf(pRec5500->sMerchRefNumber, FMTMERCHREF, iRef1, dRef2 );


/*inicia codigo yuria para MCC,SocurceAmt,Merchant Country, State Country, tasa Conversion */

   /*El estado del negocio no se tine, excepto para transacciones MasterCard 
     realizadas en USA, por defaul se inicia con blancos*/
   sprintf(pRec5500->sMerchantStaProv, FMTSLLONG5, EMPSTR);

   /*sprintf(pRec5500->sMCC, FMTNZLONG4, iMCC);*/
  /*  Debido a que algunos MCC de la tabla MTCACT01 
      tienen mas de cuatro posiciones, es necesario
      obtener  4 ultimas posiciones de iMCC. */

   strcpy(sMCC, psInt2Char(iMCC));

   iCutPosMCC = strlen(sMCC) - LEN4;

   if(iCutPosMCC >= 0)
   {
      strncpy(sMCC, &(sMCC[iCutPosMCC]), LEN4);
      sMCC[LEN4] = EOLN;
   }
   /*se agrega este codigo 26 Dic 2006 en base a solicitud de Gerencia*/
   if ( (strcmp(sMCC,"9999") == 0) || (strcmp(sMCC,"0000") == 0) ) 
      strcpy(sMCC,"7299");
   sprintf(pRec5500->sMCC, FMTNZLONG4, atoi(sMCC));


   /* De acuerdo al valor del parametro psMerchCtry,  establecer el
      valor de los campos sMerchantStaProv y sMerchCountry. */

  /*Si la transaccion es nacional */            
   if((strcmp(psMerchCtry, FMTMEXDESC) == 0) || /* busca MEX*/ 
      (strcmp(psMerchCtry, "") == 0))
   {
     sprintf(pRec5500->sSourceAmt, FMTCURLONG18, dTransAmt);    
     strcpy(pRec5500->sSourceCurr, FMTIAMEXCURR); /*484 */     
     strcpy(pRec5500->sMerchCountry, FMTMEX3PWB ); /*pais MX a dos posiciones*/
     sprintf(pRec5500->sConvRate, "%014.7f", 1.00 );
     if (strncmp(psTraType,"dispo",5)== 0)
     { /*coloca MCC para cajeros o para sucursal*/
       strcpy(pRec5500->sMCC, "6011");
       /* Se verifican pos. 5, 6 y 7 de num. ref. */
       if ((*(pRec5500->sReferenceNum + 4) == '0') ||
       (  *(pRec5500->sReferenceNum + 4) != '0' && 
       (! strncmp(pRec5500->sReferenceNum + 5, "96", 2)) ))
         strcpy(pRec5500->sMCC, "6010");
     }
     else
     {  
        if ( ( strncmp(psTraType,"abono",5)==0 ) ||
             ( strncmp(psTraType,"devolucion",10)==0 ) ||
  	   ( iMerchID == 0) ) /*revisar porque en el nume neg es int*/
          strcpy(pRec5500->sMCC,"0000");
     }
   }
   else /* si la transaccion es internacional*/
   {
      sprintf(pRec5500->sSourceAmt, FMTCURLONG18, dDollars);
      strcpy(pRec5500->sSourceCurr, FMTIAUSACURR); /*por default840*/
      /*se copian las ultimas 4 posiciones de his_negocio_leyenda*/
      strncpy(pRec5500->sMCC,&psMerchName[22],4);
      pRec5500->sMCC[4]='\0';
      if ( dDollars > 0.0  && dTransAmt > 0.0 )
         tasaConversion = dTransAmt/dDollars; 
      else  /* si no viene el monto original, se considera pesos */
         tasaConversion = 1.0;
      /*sprintf(pRec5500->sConvRate, "%014.7f", dTransAmt/dDollars);*/
      sprintf(pRec5500->sConvRate, "%014.7f", tasaConversion);
      sprintf(pRec5500->sMerchCountry, FMTSLLONG3, psMerchCtry);
      /*transacciones realizadas en CITISHARE o VISA traen merchant_country de
        dos posiciones. y para transacciones de Master Card vienen de 2
        posiciones cuando se realizo en USA y de 3 pos para cualquier otro pais
        por lo que debemos dejar los paises todos de tres posiciones numeric
        SABEMOS QUE EL MOVIMIENTO ES EN CITISHARE porque las ultimas 4 pos del
        his_negocio_leyenda vienen con cuatro ceros 0000*/
      /*checa transacciones realizada en MASTER CARD*/
      if( (strcmp(pRec5500->sMCC,"0000") != 0) &&
           ( psAccNum[0]=='5' ) )
      {
         if ( strlen(psMerchCtry) == 2 ) 
         {
           sprintf(pRec5500->sMerchantStaProv, FMTSLLONG5, psMerchCtry);
           strcpy(pRec5500->sMerchCountry,FMTUSA3PWB);/*paisAlf 2 pos*/ 
         }
         else
         {   /*si es pais de tres posisiones busca el equivalente a dos posici*/
             for(j=0;j<N_CODS_PAIS;j++)
             {
               if( strcmp(psMerchCtry,pais[j].cod3)==0 )
               {
                 sprintf(pRec5500->sMerchCountry,FMTSLLONG3,pais[j].cod2); 
                  break;
               }
             }
         }
      }/*fin del if de transacciones MASTER CARD*/

     
      /* en este punto el campo pRec5500->sMerchCountry trae el 
        pais a 2 posisiones a con un blanco en la
        tercera posicion, y como se debera hacer una busqueda en 
        la tabla MTCPAIS01 con el campo alpha2_country_code se 
        quita el espacio y se deja temporalemnte en psMerchCtry */
        strncpy(psMerchCtry,pRec5500->sMerchCountry,2);
        psMerchCtry[2]='\0';
        
          /* primero checa si la moneda es en pesos */
      if( tasaConversion >= 0.99 && tasaConversion <= 1.02 )
         strcpy(pRec5500->sSourceCurr, FMTIAMEXCURR); /*484 pesos*/     
      else
      { 
        if ( strcmp(pRec5500->sMerchCountry,"US ")==0 )/* are dollars 840*/
          strcpy(pRec5500->sSourceCurr, FMTIAUSACURR); /*840 dolares*/
        else
        {
          for(i=0,monedaUsual=0;i<N_CODS_MONED;i++)
          {
            if( (tasaConversion>= monedas_usuales[i].tasa_rango1) && 
                (tasaConversion<= monedas_usuales[i].tasa_rango2)  )
            {
               strcpy(pRec5500->sSourceCurr,monedas_usuales[i].moneda_num);
               monedaUsual=1;
            }
          }    
          /*si no correspondio a moneda usual se pone la moneda del pais*/
          if ( monedaUsual == 0)
          { 
            for(j=0,paisdesconocido=0;j<N_CODS_PAIS;j++)
            {
              if( strcmp(psMerchCtry,pais[j].cod2)==0 )
              {
                 strcpy(pRec5500->sSourceCurr,pais[j].moneda_num);
                 paisdesconocido=1;
              }
            }
            if( paisdesconocido==0)
            { 
         /*si no se encuentra el pais se envia tal cual y  deja moneda dolares*/
              strcpy(pRec5500->sSourceCurr,FMTIAUSACURR); /* 840 codigo dolare*/
            }
          }/* fin de la validacion monedaUsual==0*/
        }/*fin del else de que no es US*/
      }/* fin de checa tasa conversion*/
      if ( strcmp(pRec5500->sMCC,"0000")==0)
        strcpy(pRec5500->sMCC,"6010"); /*disposiciones CITISHARE*/
      else
      {
        if(strncmp(psTraType,"dispo",5)==0)
          strcpy(pRec5500->sMCC,"6010");  /*dispo en VISA y MASTER CARD*/
        else
        {
          if(strncmp(psTraType,"devolucion",10)==0)
             strcpy(pRec5500->sMCC,"0000");
        }
      }

   }/*fin de transacciones internacionales*/ 
  
   /* con este codigo se asegura que el MCC siempre contega numeros */
   es_num = 0;
   for (j = 0; j < 4; ++j) 
   {
     if (!isdigit(pRec5500->sMCC[j])) 
     {
       es_num = 1;
       break;
     }
   }
   /* Si no son numericas las 4 posiciones. */
   if (es_num== 1) 
   {
     strcpy(pRec5500->sMCC,"0000");
   }

//printf("MCC -%s-, pais -%s-, moneda -%s-\n",pRec5500->sMCC,pRec5500->sMerchCountry,pRec5500->sSourceCurr);
/*fin codigo yuria para MCC,SocurceAmt,Merchant Country, State Country, tasa Conversion */
   /*se agrega este codigo 26 Dic 2006 en base a solicitud de Gerencia*/
   if ( (strcmp(pRec5500->sMCC,"9999") == 0) || (strcmp(pRec5500->sMCC,"0000") == 0) ) 
      strcpy(pRec5500->sMCC,"7299");
   
   iImplicitPoint( pRec5500->sSourceAmt );

   strcpy(pRec5500->sBillCurrency, FMTIAMEXCURR);

   sprintf(pRec5500->sBillAmt, FMTCURLONG18, dTransAmt );
   iImplicitPoint( pRec5500->sBillAmt );

   sprintf(pRec5500->sSettlemCurr, FMTSLLONG3, FMTIAMEXCURR);
   sprintf(pRec5500->sSettlemAmt, FMTCURLONG18, dTransAmt );
   iImplicitPoint( pRec5500->sSettlemAmt );

   sprintf(pRec5500->sUSDollarCurr, FMTSLLONG3, EMPSTR);
   sprintf(pRec5500->sUSDollarAmt, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sUSDollarAmt );

   sprintf(pRec5500->sGBPoundCurr, FMTSLLONG3, EMPSTR);
   sprintf(pRec5500->sGBPoundAmt, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sGBPoundAmt );

   sprintf(pRec5500->sEuroCurr, FMTSLLONG3, EMPSTR);
   sprintf(pRec5500->sEuroAmt, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sEuroAmt );

   sprintf(pRec5500->sAsiaYenCurr, FMTSLLONG3, EMPSTR);
   sprintf(pRec5500->sAsiaYenAmt, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sAsiaYenAmt );

   sprintf(pRec5500->sSwedKronCurr, FMTSLLONG3, EMPSTR);
   sprintf(pRec5500->sSwedKronAmt, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sSwedKronAmt );

   sprintf(pRec5500->sCanadianCurr, FMTSLLONG3, EMPSTR);
   sprintf(pRec5500->sCanadianAmt, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sCanadianAmt );

   sprintf(pRec5500->sMemoFlag, FMTSLONG1, psMemoFlag );            

   sprintf(pRec5500->sCorpAcctNum, FMTSLLONG25, psOthAccNum);
   sprintf(pRec5500->sSalesTax, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sSalesTax );

   sprintf(pRec5500->sSalesTaxFlag, FMTSLONG1, EMPSTR);
   sprintf(pRec5500->sVATTax, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sVATTax );
   sprintf(pRec5500->sVATTaxFlag, FMTSLONG1, EMPSTR);
   sprintf(pRec5500->sPurchaseID, FMTSLLONG25, EMPSTR);
   sprintf(pRec5500->sPurchIDFlag, FMTSLONG1, EMPSTR);
   sprintf(pRec5500->sTranType, FMTSLONG1, EMPSTR);
   sprintf(pRec5500->sNumAddendums, FMTZLONG4, FMTZERO);
   sprintf(sSBFCodes, FMTZLONG4, iTransIDSBF );
   sprintf(pRec5500->sVisaTranCode, FMTSLLONG4, sSBFCodes );
   sprintf(pRec5500->sAddendumKey, FMTADDKEY50, psAccNum, pRec5500->sTransDate, pRec5500->sTransTime, pRec5500->sTransAmt );
   sprintf(pRec5500->sTicketNumber, FMTSLLONG15, EMPSTR);
   sprintf(pRec5500->sMsgType, FMTSLLONG4, EMPSTR);
   sprintf(pRec5500->sFiller1, FMTSLONG1, EMPSTR);
   strcpy(pRec5500->sVATEvidenceFlag, FMTVATEVFLAG);
   sprintf(pRec5500->sCustRefNum, FMTSLLONG17, EMPSTR);
   sprintf(pRec5500->sDiscountAmt, FMTCURLONG18, FMTZEROFLOAT);
   iImplicitPoint( pRec5500->sDiscountAmt );
   sprintf(pRec5500->sBillingDate, FMTSLLONG8, EMPSTR);
   sprintf(pRec5500->sFiller2, FMTSLLONG193, EMPSTR);
   sprintf(pRec5500->sTRXContData, FMTSLLONG50, EMPSTR);
}

/* NOMBRE       : SaveRecord5500                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 5000 500.                      */
/* PARAMETROS 	:                                                            */
/*    pRec5500 = Registro 5000 500 con datos.                                */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 16/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     16/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord5500(Record5500 *pRec5500, FILE *pFileReg) 
#else
void SaveRecord5500(pRec5500, pFileReg)
Record5500 *pRec5500;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n", 
                                          pRec5500->sRecordID,
                                          pRec5500->sTypeID,
                                          pRec5500->sCompID,
                                          pRec5500->sSubCompID,
                                          pRec5500->sCBSTRRunDate,
                                          pRec5500->sAccNumber,
                                          pRec5500->sTransDate,
                                          pRec5500->sTransTime,
                                          pRec5500->sPostDate,
                                          pRec5500->sTransAmt,
                                          pRec5500->sAuthReq,
                                          pRec5500->sAuthID,
                                          pRec5500->sConversDate,
                                          pRec5500->sPosEntry,
                                          pRec5500->sPosCondCode,
                                          pRec5500->sAcquirerID,
                                          pRec5500->sReferenceNum,
                                          pRec5500->sTraceNumber,
                                          pRec5500->sTransCurrCD,
                                          pRec5500->sTransID,
                                          pRec5500->sMCC,
                                          pRec5500->sMCCInfoData,
                                          pRec5500->sMerchAccepId,
                                          pRec5500->sMerchDescrip,
                                          pRec5500->sMerchantCity,
                                          pRec5500->sMerchantStaProv,
                                          pRec5500->sMerchantPostCod,
                                          pRec5500->sMerchCountry,
                                          pRec5500->sMerchVatNumber,
                                          pRec5500->sMerchDescFlag,
                                          pRec5500->sMerchRefNumber,
                                          pRec5500->sSourceCurr,
                                          pRec5500->sSourceAmt,
                                          pRec5500->sBillCurrency,
                                          pRec5500->sBillAmt,
                                          pRec5500->sSettlemCurr,
                                          pRec5500->sSettlemAmt,
                                          pRec5500->sUSDollarCurr,
                                          pRec5500->sUSDollarAmt,
                                          pRec5500->sGBPoundCurr,
                                          pRec5500->sGBPoundAmt,
                                          pRec5500->sEuroCurr,
                                          pRec5500->sEuroAmt,
                                          pRec5500->sAsiaYenCurr,
                                          pRec5500->sAsiaYenAmt,
                                          pRec5500->sSwedKronCurr,
                                          pRec5500->sSwedKronAmt,
                                          pRec5500->sCanadianCurr,
                                          pRec5500->sCanadianAmt,
                                          pRec5500->sConvRate,
                                          pRec5500->sDBCRFlag,
                                          pRec5500->sMemoFlag,
                                          pRec5500->sCorpAcctNum,
                                          pRec5500->sSalesTax,
                                          pRec5500->sSalesTaxFlag,
                                          pRec5500->sVATTax,
                                          pRec5500->sVATTaxFlag,
                                          pRec5500->sPurchaseID,
                                          pRec5500->sPurchIDFlag,
                                          pRec5500->sTranType,
                                          pRec5500->sNumAddendums,
                                          pRec5500->sVisaTranCode,
                                          pRec5500->sAddendumKey,
                                          pRec5500->sTicketNumber,
                                          pRec5500->sMsgType,
                                          pRec5500->sFiller1,
                                          pRec5500->sVATEvidenceFlag,
                                          pRec5500->sCustRefNum,
                                          pRec5500->sDiscountAmt,
					  pRec5500->sBillingDate,
                                          pRec5500->sFiller2,
                                          pRec5500->sTRXContData);
}


/* NOMBRE       : GenRecord6001                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 6001  del Formato CCF.                            */
/* PARAMETROS 	:                                                            */
/*    pRec6001 = Registro 6001 a inicializar.                                */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psAccNum = Numero de Cuenta.                                           */
/*    iTransID = Identificador de la Transaccion.                            */
/*    iRef1 = Clave de Referencia de la Transaccion (Parte 1).               */
/*    dRef2 = Clave de Referencia de la Transaccion (Parte 2).               */
/*    dTotFareAmt = Monto Total del Boleto.                                  */
/*    dTotTaxAmt = Monto Total de Impuestos.                                 */
/*    dNatTaxAmt = Monto de Impuestos Nacionales.                            */
/*    dTotFeeAmt = Monto Total de Cargos.                                    */
/*    psTicketNum = Numero de Boleto de Avion.                               */
/*    psExchgTickNum = Numero de Boleto de Intercambio.                      */
/*    psExchgAmt = Monto de Boleto de Intercambio.                           */
/*    pScaDesc = Descripcion de Escalas efectuadas por el vuelo.             */
/*    psAgenCode = Clave de la Agencia de Viajes.                            */
/*    psAgenName = Nombre de la Agencia de Viajes,                           */
/*    psPassName = Nombre del Pasajero.                                      */
/*    iDepDate = Fecha de Salida del Vuelo.                                  */ 
/*    psOrigCode = Codigo de Origen.                                         */
/*    psInterInd = Indicador de Compra de Boleto via Internet.               */
/*    psElectNum = Numero de Boleto Electronico.                             */
/* SALIDAS      :                                                            */
/*    Registro 6001 inicializado.                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 21/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     21/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord6001(Record6001 *pRec6001, int iCompID, char *psAccNum, 
                   int iTransID, int iRef1, double dRef2, double dTotFareAmt,
                   double dTotTaxAmt, double dNatTaxAmt, double dTotFeeAmt,
                   char *psTicketNum, char *psExchgTickNum, char *psExchgAmt,
                   Scales *pScaDesc, char *psAgenCode, char *psAgenName,
                   char *psPassName, int iDepDate, char *psOrigCode,
                   char *psInterInd, char *psElectNum)
#else
void GenRecord6001(pRec6001, iCompID, psAccNum, iTransID, iRef1, dRef2,
                   dTotFareAmt, dTotTaxAmt, dNatTaxAmt, dTotFeeAmt,
                   psTicketNum, psExchgTickNum, psExchgAmt, pScaDesc,
                   psAgenCode, psAgenName, psPassName, iDepDate,
                   psOrigCode, psInterInd, psElectNum)
Record6001 *pRec6001;
int iCompID;
char *psAccNum;
int iTransID;
int iRef1;
double dRef2;
double dTotFareAmt;
double dTotTaxAmt;
double dNatTaxAmt;
double dTotFeeAmt;
char *psTicketNum;
char *psExchgTickNum;
char *psExchgAmt;
Scales *pScaDesc;
char *psAgenCode;
char *psAgenName;
char *psPassName;
int iDepDate;
char *psOrigCode;
char *psInterInd;
char *psElectNum;
#endif
{
   int  iCounter;    /* Contador de ciclos. */

   /* Inicializa la estructura 6001. */

   strcpy(pRec6001->sRecordID, EMPSTR);
   strcpy(pRec6001->sAddDetRecType, EMPSTR);
   strcpy(pRec6001->sCompID, EMPSTR);
   strcpy(pRec6001->sSubCompID, EMPSTR);
   strcpy(pRec6001->sAccNumber, EMPSTR);
   strcpy(pRec6001->sMessageID, EMPSTR);
   strcpy(pRec6001->sReferenceNum, EMPSTR);
   strcpy(pRec6001->sTotalFareAmt, EMPSTR);
   strcpy(pRec6001->sTotalTaxAmt, EMPSTR);
   strcpy(pRec6001->sNatTaxAmt, EMPSTR);
   strcpy(pRec6001->sTotalFeeAmt, EMPSTR);
   strcpy(pRec6001->sAirlineTicketNum, EMPSTR);
   strcpy(pRec6001->sExchgTicketNum, EMPSTR);
   strcpy(pRec6001->sExchgTicketAmt, EMPSTR);

   for(iCounter=0; iCounter < LEN16; iCounter++)
   {
      strcpy(pRec6001->Record6001Scales[iCounter].sAirlineStopOver, EMPSTR);   
      strcpy(pRec6001->Record6001Scales[iCounter].sDestination, EMPSTR);
      strcpy(pRec6001->Record6001Scales[iCounter].sAirlineCarrierCode, EMPSTR);
      strcpy(pRec6001->Record6001Scales[iCounter].sAirlineServClass, EMPSTR);
      strcpy(pRec6001->Record6001Scales[iCounter].sFlightNum, EMPSTR);
   }

   strcpy(pRec6001->sTravelAgencyCode, EMPSTR);
   strcpy(pRec6001->sTravelAgencyName, EMPSTR);
   strcpy(pRec6001->sPassengerName, EMPSTR);
   strcpy(pRec6001->sDepartDate, EMPSTR);
   strcpy(pRec6001->sOrigCode, EMPSTR);
   strcpy(pRec6001->sInternetInd, EMPSTR);
   strcpy(pRec6001->sElectTicketInd, EMPSTR);
   strcpy(pRec6001->sFiller, EMPSTR);
   strcpy(pRec6001->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec6001->sRecordID, FMTREC6000);
   strcpy(pRec6001->sAddDetRecType, FMTTYPEIND7);
   sprintf(pRec6001->sCompID, FMTNZLONG6, iCompID);               /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec6001->sSubCompID, FMTSUBCOID);
   sprintf(pRec6001->sAccNumber, FMTSLLONG16, psAccNum); 
   sprintf(pRec6001->sMessageID, FMTNZLONG15, iTransID);
   sprintf(pRec6001->sReferenceNum, FMTTRANSREF, iRef1, dRef2);
   sprintf(pRec6001->sTotalFareAmt, FMTCURLONG12, dTotFareAmt);
   sprintf(pRec6001->sTotalTaxAmt, FMTCURLONG12, dTotTaxAmt);
   sprintf(pRec6001->sNatTaxAmt, FMTCURLONG12, dNatTaxAmt);
   sprintf(pRec6001->sTotalFeeAmt, FMTCURLONG12, dTotFeeAmt);
   sprintf(pRec6001->sAirlineTicketNum, FMTSLLONG15, psTicketNum);
   sprintf(pRec6001->sExchgTicketNum, FMTSLLONG13, psExchgTickNum);
   sprintf(pRec6001->sExchgTicketAmt, FMTSLLONG12, psExchgAmt);

   for(iCounter=0; iCounter < LEN16; iCounter++)
   {
      sprintf(pRec6001->Record6001Scales[iCounter].sAirlineStopOver, FMTSLONG1,
                       pScaDesc[iCounter].sAirlineStopOver);   
      sprintf(pRec6001->Record6001Scales[iCounter].sDestination, FMTSLLONG5,
                       pScaDesc[iCounter].sDestination);
      sprintf(pRec6001->Record6001Scales[iCounter].sAirlineCarrierCode, 
                       FMTSLLONG2, pScaDesc[iCounter].sAirlineCarrierCode);
      sprintf(pRec6001->Record6001Scales[iCounter].sAirlineServClass, 
                       FMTSLONG1, pScaDesc[iCounter].sAirlineServClass);
      sprintf(pRec6001->Record6001Scales[iCounter].sFlightNum, FMTSLLONG5,
                       pScaDesc[iCounter].sFlightNum);
   }

   sprintf(pRec6001->sTravelAgencyCode, FMTSLLONG8, psAgenCode);
   sprintf(pRec6001->sTravelAgencyName, FMTSLLONG25, psAgenName);
   sprintf(pRec6001->sPassengerName, FMTSLLONG20, psPassName);
   sprintf(pRec6001->sDepartDate, FMTNZLONG6, iDepDate);
   sprintf(pRec6001->sOrigCode, FMTSLLONG3, psOrigCode);
   sprintf(pRec6001->sInternetInd, FMTSLONG1, psInterInd);
   sprintf(pRec6001->sElectTicketInd, FMTSLONG1, psElectNum);
   sprintf(pRec6001->sFiller, FMTSLLONG507, EMPSTR);
   sprintf(pRec6001->sTRXContData, FMTSLLONG50, EMPSTR);

}

/* NOMBRE       : SaveRecord6001                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 6001.                          */
/* PARAMETROS 	:                                                            */
/*    pRec6001 = Registro 6001 con datos.                                    */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 21/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     21/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord6001(Record6001 *pRec6001, FILE *pFileReg) 
#else
void SaveRecord6001(pRec6001, pFileReg)
Record6001 *pRec6001;
FILE *pFileReg;
#endif
{
   int  iCounter;    /* Contador de ciclos. */

   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s",
                                          pRec6001->sRecordID,
                                          pRec6001->sAddDetRecType,
                                          pRec6001->sCompID,
                                          pRec6001->sSubCompID,
                                          pRec6001->sAccNumber,
                                          pRec6001->sMessageID,
                                          pRec6001->sReferenceNum,
                                          pRec6001->sTotalFareAmt,
                                          pRec6001->sTotalTaxAmt,
                                          pRec6001->sNatTaxAmt,
                                          pRec6001->sTotalFeeAmt,
                                          pRec6001->sAirlineTicketNum,
                                          pRec6001->sExchgTicketNum,
                                          pRec6001->sExchgTicketAmt);
   
   for(iCounter=0; iCounter < LEN16; iCounter++)
   {
      fprintf(pFileReg, "%s%s%s%s%s", 
                      pRec6001->Record6001Scales[iCounter].sAirlineStopOver, 
                      pRec6001->Record6001Scales[iCounter].sDestination,
                      pRec6001->Record6001Scales[iCounter].sAirlineCarrierCode, 
                      pRec6001->Record6001Scales[iCounter].sAirlineServClass, 
                      pRec6001->Record6001Scales[iCounter].sFlightNum);
   }

   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s\n", 
                                             pRec6001->sTravelAgencyCode,
                                             pRec6001->sTravelAgencyName,
                                             pRec6001->sPassengerName,
                                             pRec6001->sDepartDate,
                                             pRec6001->sOrigCode,
                                             pRec6001->sInternetInd,
                                             pRec6001->sElectTicketInd,
                                             pRec6001->sFiller,
                                             pRec6001->sTRXContData);

}


/* NOMBRE       : GenRecord6002                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 6002 del Formato CCF.                             */
/* PARAMETROS 	:                                                            */
/*    pRec6002 = Registro 6002 a inicializar.                                */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psAccNum = Numero de Cuenta.                                           */
/*    iDetSeqNum = Numero Secuencial asociado a la Compra.                   */
/*    iOrderDate = Fecha de la Compra.                                       */
/*    psDestZipCode = Codigo Postal Destino de la Compra.                    */
/*    psDestCountry = Pais Destino de la Compra.                             */
/*    psOrigZipCode = Codigo Postal Origen de la Compra.                     */
/*    dFreightAmt = Monto Total de la Compra.                                */
/*    dFreightTaxAmt = Impuesto Total aplicado a la Compra.                  */
/*    dFreightTaxRat = Porcentaje de Impuesto aplicado a la Compra.          */
/*    psCommCode = Codigo de la Compra.                                      */
/*    psDescription = Descripcion del Producto objeto de la Compra.          */
/*    psProductCode = Codigo de Producto.                                    */
/*    dQuantity = Cantidad de Producto comprado.                             */
/*    psUnitMeasure = Unidad de Medida del Producto.                         */
/*    dUnitCost = Costo Unitario del Producto.                               */
/*    dTaxAmt = Impuesto aplicado al Producto.                               */
/*    dTaxRat = Porcentaje de Impuesto aplicado al Producto.                 */
/*    psVATInvRefNum = Numero de Referencia correspondiente al Impuesto.     */
/*    dDiscPerItem = Descuento aplicado al Producto.                         */
/*    dLineItemTot = Costo Total Unitario del Producto.                      */
/* SALIDAS      :                                                            */
/*    Registro 6002 inicializado.                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 22/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     22/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord6002(Record6002 *pRec6002, int iCompID, char *psAccNum, 
                   int iDetSeqNum, int iOrderDate, char *psDestZipCode,
                   char *psDestCountry, char *psOrigZipCode, double dFreightAmt,
                   double dFreightTaxAmt, double dFreightTaxRat, 
                   char *psCommCode, char *psDescription, char *psProductCode, 
                   double dQuantity, char *psUnitMeasure, double dUnitCost,
                   double dTaxAmt, double dTaxRat, char *psVATInvRefNum,
                   double dDiscPerItem, double dLineItemTot)
#else
void GenRecord6002(pRec6002, iCompID, psAccNum, iDetSeqNum, iOrderDate, 
                   psDestZipCode, psDestCountry, psOrigZipCode, dFreightAmt,
                   dFreightTaxAmt, dFreightTaxRat, psCommCode, psDescription,
                   psProductCode, dQuantity, psUnitMeasure, dUnitCost, 
                   dTaxAmt, dTaxRat, psVATInvRefNum, dDiscPerItem,
                   dLineItemTot)
Record6002 *pRec6002;
int iCompID;
char *psAccNum;
int iDetSeqNum;
int iOrderDate;
char *psDestZipCode;
char *psDestCountry;
char *psOrigZipCode;
double dFreightAmt;
double dFreightTaxAmt;
double dFreightTaxRat;
char *psCommCode;
char *psDescription;
char *psProductCode;
double dQuantity;
char *psUnitMeasure;
double dUnitCost;
double dTaxAmt;
double dTaxRat;
char *psVATInvRefNum;
double dDiscPerItem;
double dLineItemTot;
#endif
{
   char sTemp[LEN255+1];      /* Cadena para procesos intermedios. */
   char sOrderDate[LEN6+1];   /* Fecha de la Compra (sin centuria). */ 

   strcpy(sTemp, EMPSTR); 
   strcpy(sOrderDate, EMPSTR); 

   /* Inicializa la estructura 6002. */

   strcpy(pRec6002->sRecordID, EMPSTR);
   strcpy(pRec6002->sAddDetRecType, EMPSTR);
   strcpy(pRec6002->sCompID, EMPSTR);
   strcpy(pRec6002->sSubCompID, EMPSTR);
   strcpy(pRec6002->sAccNumber, EMPSTR);
   strcpy(pRec6002->sPurchDetSeqNum, EMPSTR);
   strcpy(pRec6002->sOrderDate, EMPSTR);
   strcpy(pRec6002->sDestZipCode, EMPSTR);
   strcpy(pRec6002->sDestCountryCode, EMPSTR);
   strcpy(pRec6002->sOrigZipCode, EMPSTR);
   strcpy(pRec6002->sFreightAmt, EMPSTR);
   strcpy(pRec6002->sFreightVATTaxAmt, EMPSTR);
   strcpy(pRec6002->sFreightVATTaxRate, EMPSTR);
   strcpy(pRec6002->sCommodityCode, EMPSTR);
   strcpy(pRec6002->sDescription, EMPSTR);
   strcpy(pRec6002->sProductCode, EMPSTR);
   strcpy(pRec6002->sQuantity, EMPSTR);
   strcpy(pRec6002->sUnitMeasure, EMPSTR);
   strcpy(pRec6002->sUnitCost, EMPSTR);
   strcpy(pRec6002->sVATTaxAmt, EMPSTR);
   strcpy(pRec6002->sVATTaxRate, EMPSTR);
   strcpy(pRec6002->sUniqVATInvRefNum, EMPSTR);
   strcpy(pRec6002->sDiscPerLineItem, EMPSTR);
   strcpy(pRec6002->sLineItemTotal, EMPSTR);
   strcpy(pRec6002->sFiller, EMPSTR);
   strcpy(pRec6002->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec6002->sRecordID, FMTREC6000);
   strcpy(pRec6002->sAddDetRecType, FMTTYPEIND8);
   sprintf(pRec6002->sCompID, FMTNZLONG6, iCompID);                 /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec6002->sSubCompID, FMTSUBCOID);
   sprintf(pRec6002->sAccNumber, FMTSLLONG16, psAccNum);
   sprintf(pRec6002->sPurchDetSeqNum, FMTNZLONG3, iDetSeqNum);

   /* Ajuste de la Fecha de la Compra. */
 
   sprintf(sTemp, FMTINT, iOrderDate);

   strncpy(sOrderDate, &(sTemp[LEN2]), LEN6);
                                                     
   sOrderDate[LEN6] = EOLN;                            
                                                     
   sprintf(pRec6002->sOrderDate, FMTSLLONG6, sOrderDate);

   sprintf(pRec6002->sDestZipCode, FMTSLLONG10, psDestZipCode);
   sprintf(pRec6002->sDestCountryCode, FMTSLLONG3, psDestCountry);
   sprintf(pRec6002->sOrigZipCode, FMTSLLONG10, psOrigZipCode);
   sprintf(pRec6002->sFreightAmt, FMTCURLONG13, dFreightAmt);
   sprintf(pRec6002->sFreightVATTaxAmt, FMTCURLONG12, dFreightTaxAmt);
   sprintf(pRec6002->sFreightVATTaxRate, FMTCURLONG4, dFreightTaxRat);
   sprintf(pRec6002->sCommodityCode, FMTNZLONG15, atoi(psCommCode));
   sprintf(pRec6002->sDescription, FMTSLLONG35, psDescription);
   sprintf(pRec6002->sProductCode, FMTSLLONG12, psProductCode);
   sprintf(pRec6002->sQuantity, FMTCURLONG15, dQuantity);
   sprintf(pRec6002->sUnitMeasure, FMTSLLONG12, psUnitMeasure);
   sprintf(pRec6002->sUnitCost, FMTCURLONG15, dUnitCost);
   sprintf(pRec6002->sVATTaxAmt, FMTCURLONG12, dTaxAmt);
   sprintf(pRec6002->sVATTaxRate, FMTCURLONG4, dTaxRat);
   sprintf(pRec6002->sUniqVATInvRefNum, FMTSLLONG15, psVATInvRefNum);
   sprintf(pRec6002->sDiscPerLineItem, FMTCURLONG12, dDiscPerItem);
   sprintf(pRec6002->sLineItemTotal, FMTCURLONG12, dLineItemTot);
   sprintf(pRec6002->sFiller, FMTSLLONG701, EMPSTR);
   sprintf(pRec6002->sTRXContData, FMTSLLONG50, EMPSTR);

}


/* NOMBRE       : SaveRecord6002                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 6002.                          */
/* PARAMETROS 	:                                                            */
/*    pRec6002 = Registro 6002 con datos.                                    */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 22/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     22/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord6002(Record6002 *pRec6002, FILE *pFileReg) 
#else
void SaveRecord6002(pRec6002, pFileReg)
Record6002 *pRec6002;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n",
                                          pRec6002->sRecordID,
                                          pRec6002->sAddDetRecType,
                                          pRec6002->sCompID,
                                          pRec6002->sSubCompID,
                                          pRec6002->sAccNumber,
                                          pRec6002->sPurchDetSeqNum,
                                          pRec6002->sOrderDate,
                                          pRec6002->sDestZipCode,
                                          pRec6002->sDestCountryCode, 
                                          pRec6002->sOrigZipCode,
                                          pRec6002->sFreightAmt,
                                          pRec6002->sFreightVATTaxAmt,
                                          pRec6002->sFreightVATTaxRate,
                                          pRec6002->sCommodityCode,
                                          pRec6002->sDescription,
                                          pRec6002->sProductCode,
                                          pRec6002->sQuantity,
                                          pRec6002->sUnitMeasure,
                                          pRec6002->sUnitCost,
                                          pRec6002->sVATTaxAmt,
                                          pRec6002->sVATTaxRate,
                                          pRec6002->sUniqVATInvRefNum,
                                          pRec6002->sDiscPerLineItem, 
                                          pRec6002->sLineItemTotal,
                                          pRec6002->sFiller,
                                          pRec6002->sTRXContData);
}


/* NOMBRE       : GenRecord6004                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 6004 del Formato CCF.                             */
/* PARAMETROS 	:                                                            */
/*    pRec6004 = Registro 6004 a inicializar.                                */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psAccNum = Numero de Cuenta.                                           */
/*    iDetSeqNum = Numero Secuencial asociado al Hospedaje.                  */
/*    psPropTelNumber = Numero Telefonico del Hotel.                         */
/*    psCustTelNumber = Numero Telefonico Servicio a Clientes.               */
/*    iCheckInDate = Fecha de Ingreso.                                       */
/*    iCheckOutDate = Fecha de Salida.                                       */
/*    psNoShowInd = Indicador No-Show.                                       */
/*    dTotAutAmt = Monto Total Hospedaje.                                    */
/*    dPrepaidExp = Gastos Prepagados.                                       */
/*    iNumRoomNights = Numero de Cuartos.                                    */
/*    dDayRoomRate = Tarifa Diaria del Cuarto.                               */
/*    dVATTaxAmt = Monto de Impuesto.                                        */
/*    dVATTaxRate = Porcentaje de Impuesto.                                  */
/*    dRoomTaxAmt = Impuesto sobre el Cuarto.                                */
/*    psVATInvRefNum = Numero de Referencia correspondiente al Impuesto.     */
/*    dDiscAmt = Monto de Descuento.                                         */
/*    dFoodBevCharges = Cargos por Comida y Bebida.                          */
/*    dCashAdv = Cargos por Propinas.                                        */
/*    dValParkCharges = Cargos por Valet Parking.                            */
/*    dMiniBarCharges = Cargos por Consumo de Minibar.                       */
/*    dLaundryCharges = Cargos por Lavanderia.                               */
/*    dPhoneCharges = Cargos por Uso de Servicio Telefonico.                 */
/*    dGiftShopCharges = Cargos por Tienda de Regalos.                       */
/*    dMovieCharges = Cargos por Peliculas.                                  */
/*    dBusCentCharges = Cargos por Uso de Centro de Negocios.                */
/*    dHeaClubCharges = Cargos por Uso de Gimnasio.                          */
/*    dOtherCharges = Otros Cargos.                                          */
/*    dTotNonRoomCharges = Importe Total Cargos Diversos.                    */
/* SALIDAS      :                                                            */
/*    Registro 6004 inicializado.                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 23/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     23/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord6004(Record6004 *pRec6004, int iCompID, char *psAccNum, 
                   int iDetSeqNum, char *psPropTelNumber,
                   char *psCustTelNumber, int iCheckInDate, int iCheckOutDate,
                   char *psNoShowInd, double dTotAutAmt, double dPrepaidExp,
                   int iNumRoomNights, double dDayRoomRate, double dVATTaxAmt,
                   double dVATTaxRate, double dRoomTaxAmt, char *psVATInvRefNum,
                   double dDiscAmt, double dFoodBevCharges, double dCashAdv,
                   double dValParkCharges, double dMiniBarCharges, 
                   double dLaundryCharges, double dPhoneCharges,
                   double dGiftShopCharges, double dMovieCharges, 
                   double dBusCentCharges, double dHeaClubCharges,
                   double dOtherCharges, double dTotNonRoomCharges)
#else
void GenRecord6004(pRec6004, iCompID, psAccNum, iDetSeqNum, psPropTelNumber, 
                   psCustTelNumber, iCheckInDate, iCheckOutDate, psNoShowInd,
                   dTotAutAmt, dPrepaidExp, iNumRoomNights, dDayRoomRate,
                   dVATTaxAmt, dVATTaxRate, dRoomTaxAmt, psVATInvRefNum, 
                   dDiscAmt, dFoodBevCharges, dCashAdv, dValParkCharges, 
                   dMiniBarCharges, dLaundryCharges, dPhoneCharges,
                   dGiftShopCharges, dMovieCharges, dBusCentCharges,
                   dHeaClubCharges, dOtherCharges, dTotNonRoomCharges)
Record6004 *pRec6004;
int iCompID;
char *psAccNum;
int iDetSeqNum;
char *psPropTelNumber;
char *psCustTelNumber;
int iCheckInDate;
int iCheckOutDate;
char *psNoShowInd;
double dTotAutAmt;
double dPrepaidExp;
int iNumRoomNights;
double dDayRoomRate;
double dVATTaxAmt;
double dVATTaxRate;
double dRoomTaxAmt;
char *psVATInvRefNum;
double dDiscAmt;
double dFoodBevCharges;
double dCashAdv;
double dValParkCharges;
double dMiniBarCharges;              
double dLaundryCharges;
double dPhoneCharges;
double dGiftShopCharges;
double dMovieCharges;
double dBusCentCharges;
double dHeaClubCharges;
double dOtherCharges;
double dTotNonRoomCharges;             
#endif
{
   /* Inicializa la estructura 6004. */

   strcpy(pRec6004->sRecordID, EMPSTR);
   strcpy(pRec6004->sAddDetRecType, EMPSTR);
   strcpy(pRec6004->sCompID, EMPSTR);
   strcpy(pRec6004->sSubCompID, EMPSTR);
   strcpy(pRec6004->sAccNumber, EMPSTR);
   strcpy(pRec6004->sPurchDetSeqNum, EMPSTR);
   strcpy(pRec6004->sPropTelNumber, EMPSTR);
   strcpy(pRec6004->sCustServPhoneNum, EMPSTR);
   strcpy(pRec6004->sCheckInDate, EMPSTR);
   strcpy(pRec6004->sCheckOutDate, EMPSTR);
   strcpy(pRec6004->sNoShowInd, EMPSTR);
   strcpy(pRec6004->sTotalAuthAmt, EMPSTR);
   strcpy(pRec6004->sPrepExpenses, EMPSTR);
   strcpy(pRec6004->sNumRoomNights, EMPSTR);
   strcpy(pRec6004->sDailyRoomRate, EMPSTR);
   strcpy(pRec6004->sVATTaxAmt, EMPSTR);
   strcpy(pRec6004->sVATTaxRate, EMPSTR);
   strcpy(pRec6004->sRoomTaxAmt, EMPSTR);
   strcpy(pRec6004->sUniqVATInvRefNum, EMPSTR);
   strcpy(pRec6004->sDiscountAmt, EMPSTR);
   strcpy(pRec6004->sFoodBeverageCharge, EMPSTR);
   strcpy(pRec6004->sCashAdvances, EMPSTR);
   strcpy(pRec6004->sValetParkCharges, EMPSTR);
   strcpy(pRec6004->sMiniBarCharges, EMPSTR);
   strcpy(pRec6004->sLaundryCharges, EMPSTR);
   strcpy(pRec6004->sPhoneCharges, EMPSTR);
   strcpy(pRec6004->sGiftShopCharges, EMPSTR);
   strcpy(pRec6004->sMovieCharges, EMPSTR);
   strcpy(pRec6004->sBusinessCenterCharges, EMPSTR);
   strcpy(pRec6004->sHealthClubCharges, EMPSTR);
   strcpy(pRec6004->sOtherCharges, EMPSTR);
   strcpy(pRec6004->sTotalNonRoomCharges, EMPSTR);
   strcpy(pRec6004->sFiller, EMPSTR);
   strcpy(pRec6004->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec6004->sRecordID, FMTREC6000);
   strcpy(pRec6004->sAddDetRecType, FMTTYPEIND9);
   sprintf(pRec6004->sCompID, FMTNZLONG6, iCompID);               /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec6004->sSubCompID, FMTSUBCOID);
   sprintf(pRec6004->sAccNumber, FMTSLLONG16, psAccNum);
   sprintf(pRec6004->sPurchDetSeqNum, FMTNZLONG3, iDetSeqNum);
   sprintf(pRec6004->sPropTelNumber, FMTSLLONG10, psPropTelNumber);
   sprintf(pRec6004->sCustServPhoneNum, FMTSLLONG10, psCustTelNumber);
   sprintf(pRec6004->sCheckInDate, FMTNZLONG8, iCheckInDate);
   sprintf(pRec6004->sCheckOutDate, FMTNZLONG8, iCheckOutDate);
   sprintf(pRec6004->sNoShowInd, FMTSLONG1, psNoShowInd);
   sprintf(pRec6004->sTotalAuthAmt, FMTCURLONG13, dTotAutAmt);
   sprintf(pRec6004->sPrepExpenses, FMTCURLONG7, dPrepaidExp);
   sprintf(pRec6004->sNumRoomNights, FMTNZLONG12, iNumRoomNights);
   sprintf(pRec6004->sDailyRoomRate, FMTCURLONG12, dDayRoomRate);
   sprintf(pRec6004->sVATTaxAmt, FMTCURLONG12, dVATTaxAmt);
   sprintf(pRec6004->sVATTaxRate, FMTCURLONG12, dVATTaxRate);
   sprintf(pRec6004->sRoomTaxAmt, FMTCURLONG12, dRoomTaxAmt);
   sprintf(pRec6004->sUniqVATInvRefNum, FMTSLLONG15, psVATInvRefNum);
   sprintf(pRec6004->sDiscountAmt, FMTCURLONG12, dDiscAmt);
   sprintf(pRec6004->sFoodBeverageCharge, FMTCURLONG12, dFoodBevCharges);
   sprintf(pRec6004->sCashAdvances, FMTCURLONG12, dCashAdv);
   sprintf(pRec6004->sValetParkCharges, FMTCURLONG12, dValParkCharges);
   sprintf(pRec6004->sMiniBarCharges, FMTCURLONG12, dMiniBarCharges);
   sprintf(pRec6004->sLaundryCharges, FMTCURLONG12, dLaundryCharges);
   sprintf(pRec6004->sPhoneCharges, FMTCURLONG12, dPhoneCharges);
   sprintf(pRec6004->sGiftShopCharges, FMTCURLONG12, dGiftShopCharges);
   sprintf(pRec6004->sMovieCharges, FMTCURLONG12, dMovieCharges);
   sprintf(pRec6004->sBusinessCenterCharges, FMTCURLONG12, dBusCentCharges);
   sprintf(pRec6004->sHealthClubCharges, FMTCURLONG12, dHeaClubCharges);
   sprintf(pRec6004->sOtherCharges, FMTCURLONG12, dOtherCharges);
   sprintf(pRec6004->sTotalNonRoomCharges, FMTCURLONG12, dTotNonRoomCharges);
   sprintf(pRec6004->sFiller, FMTSLLONG630, EMPSTR);
   sprintf(pRec6004->sTRXContData, FMTSLLONG50, EMPSTR);
}

/* NOMBRE       : SaveRecord6004                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 6004.                          */
/* PARAMETROS 	:                                                            */
/*    pRec6004 = Registro 6004.                                              */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 23/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     23/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord6004(Record6004 *pRec6004, FILE *pFileReg) 
#else
void SaveRecord6004(pRec6004, pFileReg)
Record6004 *pRec6004;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n",
                                          pRec6004->sRecordID,
                                          pRec6004->sAddDetRecType,
                                          pRec6004->sCompID,
                                          pRec6004->sSubCompID,
                                          pRec6004->sAccNumber,
                                          pRec6004->sPurchDetSeqNum,
                                          pRec6004->sPropTelNumber,
                                          pRec6004->sCustServPhoneNum,
                                          pRec6004->sCheckInDate,
                                          pRec6004->sCheckOutDate,
                                          pRec6004->sNoShowInd,
                                          pRec6004->sTotalAuthAmt,
                                          pRec6004->sPrepExpenses,
                                          pRec6004->sNumRoomNights,
                                          pRec6004->sDailyRoomRate,
                                          pRec6004->sVATTaxAmt,
                                          pRec6004->sVATTaxRate,
                                          pRec6004->sRoomTaxAmt,
                                          pRec6004->sUniqVATInvRefNum,
                                          pRec6004->sDiscountAmt,
                                          pRec6004->sFoodBeverageCharge,
                                          pRec6004->sCashAdvances,
                                          pRec6004->sValetParkCharges,
                                          pRec6004->sMiniBarCharges,
                                          pRec6004->sLaundryCharges,
                                          pRec6004->sPhoneCharges,
                                          pRec6004->sGiftShopCharges,
                                          pRec6004->sMovieCharges,
                                          pRec6004->sBusinessCenterCharges,
                                          pRec6004->sHealthClubCharges,
                                          pRec6004->sOtherCharges,
                                          pRec6004->sTotalNonRoomCharges, 
                                          pRec6004->sFiller,
                                          pRec6004->sTRXContData); 

}


/* NOMBRE       : GenRecord6005                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 6005 del Formato CCF.                             */
/* PARAMETROS 	:                                                            */
/*    pRec6005 = Registro 6005 a inicializar.                                */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psAccNum = Numero de Cuenta.                                           */
/*    iDetSeqNum = Numero Secuencial asociado a la Renta.                    */
/*    psRentAgreeNum = No. de Contrato de Renta.                             */
/*    psRentName = Nombre del Arrendatario.                                  */
/*    psRetCity = Ciudad de Retorno del Auto.                                */
/*    psRetStaCtry = Estado/Pais de Retorno del Auto.                        */
/*    psClassCode = Codigo de Tipo de Auto.                                  */
/*    psNoShowInd = Indicador No-Show.                                       */
/*    iCheckOutDate = Fecha de Salida del Auto.                              */
/*    iCheckInDate = Fecha de Regreso del Auto.                              */
/*    psInsInd = Indicador de Auto Asegurado.                                */
/*    dInsCharges = Cargos aplicados por Aseguradora.                        */
/*    dTotMiles = Millas aplicadas por el Auto.                              */
/*    iNumDaysRent = No. de Dias de Renta.                                   */
/*    dDailyRate = Monto de Renta Diaria.                                    */
/*    dVATTaxAmt = Impuesto Aplicado a Renta.                                */
/*    dVATTaxRate = Porcentaje de Impuesto.                                  */
/*    psVATInvRefNum = Numero de Referencia correspondiente al Impuesto.     */
/*    dWeeklyRate = Monto de Renta Semanal.                                  */
/*    dRatePerMile = Monto de Renta por Milla.                               */
/*    dOneWayDropOff = Cargo Unico por Renta de Auto.                        */
/*    dRegMilCharge = Cargo por Millage Regular.                             */
/*    dExtMilCharge = Cargo Extra por Millage Regular.                       */
/*    dMaxFreeMiles = No. de Millas Libres.                                  */
/*    dLateRetCharge = Cargo por Demora Retorno Auto.                        */
/*    dFuelCharge = Cargo por Gasolina.                                      */
/*    dTelCharge = Cargo por Servicio Telefonico.                            */
/*    dTowCharge = Cargo por Remolque de Auto.                               */
/*    dExtCharges = Cargos Extras.                                           */
/*    dOthCharges = Otros Cargos.                                            */
/*    dDiscAmt = Monto de Descuento.                                         */
/*    dLineItemTot = Monto Total Renta.                                      */
/* SALIDAS      :                                                            */
/*    Registro 6005 inicializado.                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 24/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     24/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord6005(Record6005 *pRec6005, int iCompID, char *psAccNum, 
                   int iDetSeqNum, char *psRentAgreeNum, char *psRentName,
                   char *psRetCity, char *psRetStaCtry, char *psClassCode,
                   char *psNoShowInd, int iCheckOutDate, int iCheckInDate,
                   char *psInsInd, double dInsCharges, double dTotMiles,
                   int iNumDaysRent, double dDailyRate, double dVATTaxAmt,
                   double dVATTaxRate, char *psVATInvRefNum, double dWeeklyRate,
                   double dRatePerMile, double dOneWayDropOff, 
                   double dRegMilCharge, double dExtMilCharge, 
                   double dMaxFreeMiles, double dLateRetCharge,
                   double dFuelCharge, double dTelCharge, double dTowCharge,
                   double dExtCharges, double dOthCharges, double dDiscAmt,
                   double dLineItemTot)
#else
void GenRecord6005(pRec6005, iCompID, psAccNum, iDetSeqNum, psRentAgreeNum,
                   psRentName, psRetCity, psRetStaCtry, psClassCode, 
                   psNoShowInd, iCheckOutDate, iCheckInDate, psInsInd,
                   dInsCharges, dTotMiles, iNumDaysRent, dDailyRate,
                   dVATTaxAmt, dVATTaxRate, psVATInvRefNum, dWeeklyRate,
                   dRatePerMile, dOneWayDropOff, dRegMilCharge, dExtMilCharge,
                   dMaxFreeMiles, dLateRetCharge, dFuelCharge, dTelCharge,
                   dTowCharge, dExtCharges, dOthCharges, dDiscAmt,
                   dLineItemTot)
Record6005 *pRec6005;
int iCompID;
char *psAccNum;
int iDetSeqNum;
char *psRentAgreeNum;
char *psRentName;
char *psRetCity;
char *psRetStaCtry;
char *psClassCode;
char *psNoShowInd;
int iCheckOutDate;
int iCheckInDate;
char *psInsInd;
double dInsCharges;
double dTotMiles;
int iNumDaysRent;
double dDailyRate;
double dVATTaxAmt;
double dVATTaxRate;
char *psVATInvRefNum;
double dWeeklyRate;
double dRatePerMile;
double dOneWayDropOff;
double dRegMilCharge;
double dExtMilCharge;
double dMaxFreeMiles;
double dLateRetCharge;
double dFuelCharge;
double dTelCharge;
double dTowCharge;
double dExtCharges;
double dOthCharges;
double dDiscAmt;
double dLineItemTot;
#endif
{
   char sTemp[LEN255+1];        /* Cadena para procesos intermedios. */ 
   char sCheckInDate[LEN6+1];   /* Fecha de Regreso del Auto (sin centuria). */
   
   strcpy(sTemp, EMPSTR);                                             
   strcpy(sCheckInDate, EMPSTR);                                        

   /* Inicializa la estructura 6005. */

   strcpy(pRec6005->sRecordID, EMPSTR);
   strcpy(pRec6005->sAddDetRecType, EMPSTR);
   strcpy(pRec6005->sCompID, EMPSTR);
   strcpy(pRec6005->sSubCompID, EMPSTR);
   strcpy(pRec6005->sAccNumber, EMPSTR);
   strcpy(pRec6005->sPurchDetSeqNum, EMPSTR);
   strcpy(pRec6005->sRentAgreemtNum, EMPSTR);
   strcpy(pRec6005->sRenterName, EMPSTR);
   strcpy(pRec6005->sLocReturnCity, EMPSTR);
   strcpy(pRec6005->sReturnStaCount, EMPSTR);
   strcpy(pRec6005->sCarClassCode, EMPSTR);
   strcpy(pRec6005->sNoShowInd, EMPSTR);
   strcpy(pRec6005->sCheckOutDate, EMPSTR);
   strcpy(pRec6005->sCheckInDate, EMPSTR);
   strcpy(pRec6005->sInsurIndicator, EMPSTR);
   strcpy(pRec6005->sInsurCharges, EMPSTR);
   strcpy(pRec6005->sTotalMiles, EMPSTR);
   strcpy(pRec6005->sNumberDaysRented, EMPSTR);
   strcpy(pRec6005->sDailyRate, EMPSTR);
   strcpy(pRec6005->sVATTaxAmt, EMPSTR);
   strcpy(pRec6005->sVATTaxRate, EMPSTR);
   strcpy(pRec6005->sUniqVATInvRefNum, EMPSTR);
   strcpy(pRec6005->sWeeklyRate, EMPSTR);
   strcpy(pRec6005->sRatePerMile, EMPSTR);
   strcpy(pRec6005->sOneWayDropOffCharge, EMPSTR);
   strcpy(pRec6005->sRegMileageCharge, EMPSTR);
   strcpy(pRec6005->sExtraMileageCharge, EMPSTR);
   strcpy(pRec6005->sMaxFreeMiles, EMPSTR);
   strcpy(pRec6005->sLateRetChargeHourRate, EMPSTR);
   strcpy(pRec6005->sFuelCharge, EMPSTR);
   strcpy(pRec6005->sTelCharges, EMPSTR);
   strcpy(pRec6005->sAutoTowCharges, EMPSTR);
   strcpy(pRec6005->sExtraCharges, EMPSTR);
   strcpy(pRec6005->sOtherCharges, EMPSTR);
   strcpy(pRec6005->sDiscountAmt, EMPSTR);
   strcpy(pRec6005->sLineItemTotal, EMPSTR);
   strcpy(pRec6005->sFiller, EMPSTR);
   strcpy(pRec6005->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec6005->sRecordID, FMTREC6000);
   strcpy(pRec6005->sAddDetRecType, FMTTYPEIND10);
   sprintf(pRec6005->sCompID, FMTNZLONG6, iCompID);                /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec6005->sSubCompID, FMTSUBCOID);
   sprintf(pRec6005->sAccNumber, FMTSLLONG16, psAccNum);
   sprintf(pRec6005->sPurchDetSeqNum, FMTNZLONG3, iDetSeqNum);
   sprintf(pRec6005->sRentAgreemtNum, FMTSLLONG25, psRentAgreeNum);
   sprintf(pRec6005->sRenterName, FMTSLLONG40, psRentName);
   sprintf(pRec6005->sLocReturnCity, FMTSLLONG25, psRetCity);
   sprintf(pRec6005->sReturnStaCount, FMTSLLONG3, psRetStaCtry);
   sprintf(pRec6005->sCarClassCode, FMTSLLONG2, psClassCode);
   sprintf(pRec6005->sNoShowInd, FMTSLONG1, psNoShowInd);
   sprintf(pRec6005->sCheckOutDate, FMTNZLONG8, iCheckOutDate);

   /* Ajuste de la Fecha de Regreso del Auto. */                
                                                      
   sprintf(sTemp, FMTINT, iCheckInDate);                   
                                                      
   strncpy(sCheckInDate, &(sTemp[LEN2]), LEN6);            
                                                      
   sCheckInDate[LEN6] = EOLN;                              
                                                      
   sprintf(pRec6005->sCheckInDate, FMTSLLONG6, sCheckInDate);

   sprintf(pRec6005->sInsurIndicator, FMTSLONG1, psInsInd);
   sprintf(pRec6005->sInsurCharges, FMTCURLONG12, dInsCharges);
   sprintf(pRec6005->sTotalMiles, FMT5DEC, dTotMiles);
   sprintf(pRec6005->sNumberDaysRented, FMTNZLONG2, iNumDaysRent);
   sprintf(pRec6005->sDailyRate, FMTCURLONG12, dDailyRate);
   sprintf(pRec6005->sVATTaxAmt, FMTCURLONG12, dVATTaxAmt);
   sprintf(pRec6005->sVATTaxRate, FMTCURLONG4, dVATTaxRate); 
   sprintf(pRec6005->sUniqVATInvRefNum, FMTSLLONG15, psVATInvRefNum);
   sprintf(pRec6005->sWeeklyRate, FMTCURLONG12, dWeeklyRate);
   sprintf(pRec6005->sRatePerMile, FMTCURLONG12, dRatePerMile);
   sprintf(pRec6005->sOneWayDropOffCharge, FMTCURLONG12, dOneWayDropOff);
   sprintf(pRec6005->sRegMileageCharge, FMTCURLONG12, dRegMilCharge);
   sprintf(pRec6005->sExtraMileageCharge, FMTCURLONG12, dExtMilCharge);
   sprintf(pRec6005->sMaxFreeMiles, FMT5DEC, dMaxFreeMiles);
   sprintf(pRec6005->sLateRetChargeHourRate, FMTCURLONG12, dLateRetCharge);
   sprintf(pRec6005->sFuelCharge, FMTCURLONG12, dFuelCharge);
   sprintf(pRec6005->sTelCharges, FMTCURLONG12, dTelCharge);
   sprintf(pRec6005->sAutoTowCharges, FMTCURLONG12, dTowCharge);
   sprintf(pRec6005->sExtraCharges, FMTCURLONG12, dExtCharges);
   sprintf(pRec6005->sOtherCharges, FMTCURLONG12, dOthCharges);
   sprintf(pRec6005->sDiscountAmt, FMTCURLONG12, dDiscAmt);
   sprintf(pRec6005->sLineItemTotal, FMTCURLONG12, dLineItemTot);
   sprintf(pRec6005->sFiller, FMTSLLONG584, EMPSTR);
   sprintf(pRec6005->sTRXContData, FMTSLLONG50, EMPSTR);

}


/* NOMBRE       : SaveRecord6005                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 6005.                          */
/* PARAMETROS 	:                                                            */
/*    pRec6005 = Registro 6005 con datos.                                    */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 24/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     24/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord6005(Record6005 *pRec6005, FILE *pFileReg) 
#else
void SaveRecord6005(pRec6005, pFileReg)
Record6005 *pRec6005;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n",
                                          pRec6005->sRecordID,
                                          pRec6005->sAddDetRecType,
                                          pRec6005->sCompID,
                                          pRec6005->sSubCompID,
                                          pRec6005->sAccNumber,
                                          pRec6005->sPurchDetSeqNum,
                                          pRec6005->sRentAgreemtNum,
                                          pRec6005->sRenterName,
                                          pRec6005->sLocReturnCity,
                                          pRec6005->sReturnStaCount,
                                          pRec6005->sCarClassCode,
                                          pRec6005->sNoShowInd,
                                          pRec6005->sCheckOutDate,
                                          pRec6005->sCheckInDate,
                                          pRec6005->sInsurIndicator,
                                          pRec6005->sInsurCharges,
                                          pRec6005->sTotalMiles,
                                          pRec6005->sNumberDaysRented,
                                          pRec6005->sDailyRate,
                                          pRec6005->sVATTaxAmt,
                                          pRec6005->sVATTaxRate,
                                          pRec6005->sUniqVATInvRefNum,
                                          pRec6005->sWeeklyRate,
                                          pRec6005->sRatePerMile,
                                          pRec6005->sOneWayDropOffCharge,
                                          pRec6005->sRegMileageCharge,
                                          pRec6005->sExtraMileageCharge,
                                          pRec6005->sMaxFreeMiles,
                                          pRec6005->sLateRetChargeHourRate, 
                                          pRec6005->sFuelCharge,
                                          pRec6005->sTelCharges,
                                          pRec6005->sAutoTowCharges,
                                          pRec6005->sExtraCharges,
                                          pRec6005->sOtherCharges,
                                          pRec6005->sDiscountAmt,
                                          pRec6005->sLineItemTotal,
                                          pRec6005->sFiller,
                                          pRec6005->sTRXContData);

}


/* NOMBRE       : GenRecord9000                                              */
/* DESCRIPCION	: Permite construir la estructura correspondiente al         */
/*                Registro 9000 900  del Formato CCF.                        */
/* PARAMETROS 	:                                                            */
/*    pRec9000 = Registro 9000 900 a inicializar.                            */
/*    psCompName = Nombre de la Empresa.                                     */
/*    iCompID = Identificador de la Empresa.                                 */
/*    psGenDate = Fecha de Generacion del archivo CCF.                       */
/*    iTotal1000 = Numero Total de Registros 1000.                           */
/*    iTotal1001 = Numero Total de Registros 1001.                           */
/*    iTotal2000 = Numero Total de Registros 2000.                           */
/*    iTotal2001 = Numero Total de Registros 2001.                           */
/*    iTotal2002 = Numero Total de Registros 2002.                           */
/*    iTotal5000 = Numero Total de Registros 5000.                           */
/*    dTotAmt5000 = Importe Total de Registros 5000.                         */
/*    iTotal5001 = Numero Total de Registros 5001.                           */
/*    iTotal6001 = Numero Total de Registros 6001.                           */
/*    iTotal6002 = Numero Total de Registros 6002.                           */ 
/*    iTotal6004 = Numero Total de Registros 6004.                           */
/*    iTotal6005 = Numero Total de Registros 6005.                           */
/* SALIDAS      :                                                            */
/*    Registro 9000 900 inicializado.                                        */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 16/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     16/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GenRecord9000(Record9000 *pRec9000, char *psCompName, int iCompID, 
                   char *psGenDate, int iTotal1000, int iTotal1001,
                   int iTotal2000, int iTotal2001, int iTotal2002, 
                   int iTotal5000, double dTotAmt5000, int iTotal5001, 
                   int iTotal6001, int iTotal6002, int iTotal6004, 
                   int iTotal6005) 
#else
void GenRecord9000(pRec9000, psCompName, iCompID, psGenDate, iTotal1000,
                   iTotal1001, iTotal2000, iTotal2001, iTotal2002,
                   iTotal5000, dTotAmt5000, iTotal5001, iTotal6001,
                   iTotal6002, iTotal6004, iTotal6005)
Record9000 *pRec9000;
char *psCompName;
int iCompID;
char *psGenDate;
int iTotal1000;
int iTotal1001;
int iTotal2000;
int iTotal2001;
int iTotal2002;
int iTotal5000;
double dTotAmt5000;
int iTotal5001;
int iTotal6001;
int iTotal6002;
int iTotal6004;
int iTotal6005;                                     
#endif
{
   int   iRadPos;         /* Posicion del punto decimal. */
   int   iSign;           /* Signo. */

   /* Inicializa la estructura 9000 900. */

   strcpy(pRec9000->sRecordID, EMPSTR);
   strcpy(pRec9000->sTypeID, EMPSTR);
   strcpy(pRec9000->sCompName, EMPSTR);
   strcpy(pRec9000->sCompID, EMPSTR);
   strcpy(pRec9000->sSubCompID, EMPSTR);
   strcpy(pRec9000->sEffecFileDate, EMPSTR);
   strcpy(pRec9000->sType1000RecCnt, EMPSTR);
   strcpy(pRec9000->sType1001RecCnt, EMPSTR);
   strcpy(pRec9000->sType2000RecCnt, EMPSTR);
   strcpy(pRec9000->sType2001RecCnt, EMPSTR);
   strcpy(pRec9000->sType2002RecCnt, EMPSTR);
   strcpy(pRec9000->sType5000RecCnt, EMPSTR);
   strcpy(pRec9000->sType5000TotVal, EMPSTR);
   strcpy(pRec9000->sType5001RecCnt, EMPSTR);
   strcpy(pRec9000->sType6001RecCnt, EMPSTR);
   strcpy(pRec9000->sType6002RecCnt, EMPSTR);
   strcpy(pRec9000->sType6004RecCnt, EMPSTR);
   strcpy(pRec9000->sType6005RecCnt, EMPSTR);
   strcpy(pRec9000->sFiller, EMPSTR);
   strcpy(pRec9000->sTRXContData, EMPSTR);

   /* Copia a la estructura los parametros recibidos. */

   strcpy(pRec9000->sRecordID, FMTREC9000);
   strcpy(pRec9000->sTypeID, FMTTYPEIND11);
   sprintf(pRec9000->sCompName, FMTSLLONG100, psCompName);
   sprintf(pRec9000->sCompID, FMTNZLONG6, iCompID);                  /*Se cambia al formato FMTNBLONG6, IERM, Mayo 10, 2005*/
   strcpy(pRec9000->sSubCompID, FMTSUBCOID);
   sprintf(pRec9000->sEffecFileDate, FMTSLLONG8, psGenDate);
   sprintf(pRec9000->sType1000RecCnt, FMTZLONG18, iTotal1000);
   sprintf(pRec9000->sType1001RecCnt, FMTZLONG18, iTotal1001);
   sprintf(pRec9000->sType2000RecCnt, FMTZLONG18, iTotal2000);
   sprintf(pRec9000->sType2001RecCnt, FMTZLONG18, iTotal2001);
   sprintf(pRec9000->sType2002RecCnt, FMTZLONG18, iTotal2002);
   sprintf(pRec9000->sType5000RecCnt, FMTZLONG18, iTotal5000);
   sprintf(pRec9000->sType5000TotVal, FMTCURLONG18D, dTotAmt5000);
   iImplicitPoint( pRec9000->sType5000TotVal );
   sprintf(pRec9000->sType5001RecCnt, FMTZLONG18, iTotal5001);
   sprintf(pRec9000->sType6001RecCnt, FMTZLONG18, iTotal6001);
   sprintf(pRec9000->sType6002RecCnt, FMTZLONG18, iTotal6002);
   sprintf(pRec9000->sType6004RecCnt, FMTZLONG18, iTotal6004);
   sprintf(pRec9000->sType6005RecCnt, FMTZLONG18, iTotal6005);
   sprintf(pRec9000->sFiller, FMTSRLONG610, EMPSTR);
   sprintf(pRec9000->sTRXContData, FMTSRLONG50, EMPSTR);
}


/* NOMBRE       : SaveRecord9000                                             */
/* DESCRIPCION	: Permite guardar en el archivo especificado la informacion  */
/*                correspondiente al Registro 9000 900.                      */
/* PARAMETROS 	:                                                            */
/*    pRec9000 = Registro 9000 900 con datos.                                */
/*    pFileReg = Apuntador a archivo.                                        */
/* SALIDAS      :                                                            */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 16/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     16/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void SaveRecord9000(Record9000 *pRec9000, FILE *pFileReg) 
#else
void SaveRecord9000(pRec9000, pFileReg)
Record9000 *pRec9000;
FILE *pFileReg;
#endif
{
   fprintf(pFileReg, "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n",
                                          pRec9000->sRecordID,
                                          pRec9000->sTypeID,
                                          pRec9000->sCompName,
                                          pRec9000->sCompID,
                                          pRec9000->sSubCompID,
                                          pRec9000->sEffecFileDate,
                                          pRec9000->sType1000RecCnt,
                                          pRec9000->sType1001RecCnt,
                                          pRec9000->sType2000RecCnt,
                                          pRec9000->sType2001RecCnt,
                                          pRec9000->sType2002RecCnt,
                                          pRec9000->sType5000RecCnt,
                                          pRec9000->sType5000TotVal,
                                          pRec9000->sType5001RecCnt,
                                          pRec9000->sType6001RecCnt,
                                          pRec9000->sType6002RecCnt,
                                          pRec9000->sType6004RecCnt,
                                          pRec9000->sType6005RecCnt,
                                          pRec9000->sFiller,
                                          pRec9000->sTRXContData);

}


/* NOMBRE       : psGetLastName                                              */
/* DESCRIPCION	: Obtiene el Apellido Paterno del Nombre enviado como        */
/*                parametro.                                                 */
/* PARAMETROS 	:                                                            */
/*    psName = Nombre a procesar.                                            */
/* SALIDAS      :                                                            */
/*    sFName = Apellido Paterno del Nombre Procesado.                        */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 11/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     11/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
char *psGetLastName(char *psName)
#else
char *psGetLastName(psName)
char *psName;
#endif
{
   static char sFName[LEN255+1];   /* Apellido Paterno. */
   char *pFName;
   char sTemp[LEN2+1];      /* Cadena temporal. */
   int  iPos;               /* Posicion actual de la cadena. */
   int  iFlagP;             /* Bandera para control de proceso de extraccion. */
   int  iFlagFN;            /* Bandera para indicar que el Apellido Paterno 
                               ha sido establecido. */

   strcpy(sFName, EMPSTR);
   iFlagP=0;
   iFlagFN=0; 
                                               
   for(iPos=0; (iPos < strlen(psName)) && (iFlagFN == 0); iPos++)
   {
      switch(psName[iPos])
      {
         case COMMA:   /* Inicia el proceso de extraccion. */
            iFlagP=1;
            break;
         case DIAG:   /* Termina el proceso de extraccion. */
            iFlagP=0;
            iFlagFN=1;
            break; 
      }
 
      if(iFlagP == 1)
      {
         if(psName[iPos] != COMMA)
         {
            sTemp[0] = psName[iPos];
            sTemp[1] = EOLN;
            strcat(sFName, sTemp);
         }
      }
   }
   pFName=sFName;
   return(sFName);
}

/* NOMBRE       : GetNames                                                   */
/* DESCRIPCION	: Obtiene los Nombres (sin Apellidos) contenidos en el       */
/*                parametro psCardHName.                                     */
/* PARAMETROS 	:                                                            */
/*    psNames = Nombre(s) sin Apellidos del Tarjetahabiente.                 */
/*    psCardHName = Nombre Completo del Tarjetahabiente.                     */
/*    psFirstName  = Apellido Paterno del Tarjetahabiente.                   */
/*    piTotal = Numero Total de Nombres recuperados del parametro            */ 
/*              psCardHName                                                  */
/*    psSepChar = Caracter separador de campos.                              */
/* SALIDAS      :                                                            */
/*    Parametro psNames inicializado.                                        */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 14/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     14/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void GetNames(char *psNames[], char *psCardHName, char *psFirstName,
              int *piTotal, char *psSepChar)
#else
void GetNames(psNames, psCardHName, psFirstName, piTotal, psSepChar)
char *psNames[]; 
char *psCardHName;
char *psFirstName;
int *piTotal;
char *psSepChar;
#endif
{
   char *psString;         /* Apuntador a cadena de caracteres. */
   char sTemp[LEN255+1];   /* Cadena para procesamiento temporal. */   
   char sTemp2[LEN255+1];   
   int  iCounter;          /* Contador de ciclos. */
   int  iFNameFlag;        /* Bandera para deteccion de Apellido Paterno. */
   int longNom,i;
   int longNom2;

   strcpy(sTemp, psCardHName);

   iFNameFlag = 0;
   
   psString = strtok(sTemp, psSepChar);
   if(psString != (char *) NULL)   
   {
      /* El primer campo de psCardHName no esta vacio. */
   
      if(strlen(psString) <= 1)   /* El primer campo es un caracter. */
      {

         /* Verificar si el campo recuperado no corresponde al Apellido
            Paterno. */

         if(strcmp(psString, psFirstName) != 0)
         {
            psNames[0][0] = *psString;
            psNames[0][1] = EOLN;
         }
         else
         
            iFNameFlag = 1;
      }
      else   /* El primer campo de psCardHName es una cadena de caracteres. */
      {
         /* Verificar si el campo recuperado no corresponde al Apellido
            Paterno. */                                                

         if(strcmp(psString, psFirstName) != 0)
 
            strcpy(psNames[0], psString);

         else

            iFNameFlag = 1;
      }      
   }
   else

      psNames[0][0] = EOLN;


   /* Incrementa el valor de piTotal (siempre y cuando el Apellido Paterno
      aun no haya sido detectado). */

   if((iFNameFlag != 1) && (psNames[0][0] != EOLN))

      (*piTotal)++;


   /* Determina el resto de los campos de la cadena. */

   for(iCounter = 1; (iFNameFlag != 1) && (psString != (char *) NULL);
                                                           iCounter++)
   {
      psString = strtok(NULL, psSepChar);

      if(strlen(psString) <= 1)   /* El campo obtenido es un caracter. */
      { 
         if(psString == (char *) NULL)   /* El campo esta vacio. */

            psNames[iCounter][0] = EOLN;

         else
         {
            if(strcmp(psString, psFirstName) != 0)
            {
               psNames[iCounter][0] = *psString;
               psNames[iCounter][1] = EOLN;
               (*piTotal)++;
            }
            else

               iFNameFlag = 1;
         } 
      }
      else   /* El campo es una cadena de caracteres. */
      {
         if(strcmp(psString, psFirstName) != 0)
         { 
            strcpy(psNames[iCounter], psString);
            (*piTotal)++;
         }
         else              
                  
            iFNameFlag = 1;
         
      } 
   }
}

/* NOMBRE       : psInt2Char                                                 */
/* DESCRIPCION	: Convierte un numero entero a una cadena de caracteres      */
/* PARAMETROS 	:                                                            */
/*    iNumber = Numero a convertir.                                          */
/* SALIDAS      :                                                            */
/*    sResult = Numero Convertido a Cadena de Caracteres.                    */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 15/07/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     15/07/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
char *psInt2Char(int iNumber)
#else
char *psInt2Char(iNumber)
int iNumber;
#endif
{
   static char sResult[LEN255+1];   /* Numero en formato de Cadena. */
   char *pResult;
   strcpy(sResult, EMPSTR); 
   
   sprintf(sResult, FMTINT, iNumber);
   pResult=sResult;                                  
   return(pResult);
}

#if defined(__STDC__) || defined(__cplusplus)
void quitaBlancos(char *cadena)
#else
void quitaBlancos(cadena)
char *cadena;
#endif
{
  int i=0;
  int j=0;
  int posicion=0;
  int longitud = strlen(cadena);
  if ( longitud > 0 )
  {
   /*quita blancos a la derecha*/
    for (j = longitud - 1; j >= 0 && (cadena[j] == ' ') ; j --)
    cadena[j] = '\0';
    longitud = strlen(cadena);
   /*quita blancos a la izquierda*/
    for (i=0;i < longitud && longitud > 0; i++)
    {
      if ( cadena[i] != ' ')
      {
          strcpy(cadena,&cadena[i]);
          break;
      }
    }
  }
}

/* NOMBRE       : iCompareComp                                               */
/* DESCRIPCION	: Permite comparar los elementos contenidos en el arreglo de */
/*                Empresas.                                                  */
/* PARAMETROS 	:                                                            */
/*    pCompElem1 = Primer Elemento a Comparar.                               */
/*    pCompElem2 = Segundo Elemento a Comparar.                              */ 
/* SALIDAS      :                                                            */
/*    iResult = Resultado de la Operacion de Comparacion.                    */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 20/08/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     20/08/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
int iCompareComp(const void *pCompElem1, const void *pCompElem2)
#else
int iCompareComp(pCompElem1, pCompElem2)
Company *pCompElem1;
Company *pCompElem2;
#endif
{

   Company *pCompE1;
   Company *pCompE2;

   pCompE1=(Company *) pCompElem1;
   pCompE2=(Company *) pCompElem2;
 
   if(pCompE1->iPreffix < pCompE2->iPreffix)

      return -1;

   else
   
      if(pCompE1->iPreffix == pCompE2->iPreffix)
      {
         if(pCompE1->iBankGroup < pCompE2->iBankGroup)

            return -1;

         else

            if(pCompE1->iBankGroup == pCompE2->iBankGroup)
            {
               if(pCompE1->iCompanyID < pCompE2->iCompanyID)

                  return -1;

               else

                  if(pCompE1->iCompanyID == pCompE2->iCompanyID)

                     return 0;

                  else
                 
                     if(pCompE1->iCompanyID > pCompE2->iCompanyID)

                        return 1; 
            }
            else

               if(pCompE1->iBankGroup > pCompE2->iBankGroup)

                  return 1;

      }
      else

         if(pCompE1->iPreffix > pCompE2->iPreffix)

            return 1;
         return -1;
}


/* NOMBRE       : iImplicitPoint                                             */
/* DESCRIPCION  : Convierte un numero de punto explicito en punto implicito  */
/* PARAMETROS   :                                                            */
/*    pNumber = Numero a convertir                                           */
/* SALIDAS      :                                                            */
/*    Ninguna                                                                */
/* AUTOR        : Ivan Eduardo Roldan Morales (IERM)                         */
/* COMPANIA     : EISSA                                                      */
/* FECHA        : 21/09/2005                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*      IS      NOMBRE                  FECHA           DESCRIPCION          */
/*     IER Ivan Eduardo Roldan M.     21/09/2005      Version  1.2.1         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
void iImplicitPoint( char *pNumber )
#else
void implicitPoint( )
char *pNumber;
#endif
{

  char *flotante = strchr( pNumber, '.' );
  char *entero='\0';
  char sign = pNumber[0];
  int lenf = strlen( flotante ) - 1;
  int lend = strlen( pNumber ) - lenf - 1;

  entero = (char *) malloc( sizeof( char ) * lend );
  strncpy( entero, pNumber, lend );

  pNumber[ 0 ] = '0';

  for( int i = 1 ; i <= lend ; i++ )
     pNumber[ i ] = entero[ i - 1 ];

  if( sign == '-' ){
    pNumber[ 0 ] = '-';
    pNumber[ 1 ] = '0'; 
  }
  free( entero );
}


#if defined(__STDC__) || defined(__cplusplus)
void fillStr( char *source, char *dest, char fill, int size )
#else
void fillStr( )
char *source;
char *dest;
char fill;
int size;
#endif
{
     int len = strlen( source );
     int fillzone = size - len;
     int index, j;

     for( index = 0, j = 0 ; index < size ; index++ ){
	if( index < fillzone )
           dest[ index ] = fill;
	else{
           dest[ index ] = source[ j ];
	   j++;
	}
     }
}






