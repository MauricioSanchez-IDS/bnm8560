/* NOMBRE       : C430GetCompanies                                           */
/* DESCRIPCION	: Permite la recuperacion de las Empreas que se encuentren   */
/*                bajo el esquema de Tarjeta Corporativa.                    */
/* PARAMETROS 	:                                                            */
/*    argv[1] = Usuario de Base De Datos                                     */
/*    argv[2] = Password de Base de Datos                                    */
/*    argv[3] = Servidor donde se encuentra la Base de Datos                 */
/*    argv[4] = Tipo de Empresa a Analizar:                                  */
/*                 0 - Proceso Diario.                                       */
/*                 1 - Proceso Por Corte.                                    */
/*    argv[5] = Fecha de Procesamiento (Opcional).                           */
/* SALIDAS      : Empresas bajo esquema de Tarjeta Corporativa.              */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 19/08/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     19/08/2003     Primera Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "C430GetCompanies.h"

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

   if(!((argc == 5) || (argc == 6)))   
   {

#ifdef DEBUG1
      printf("\nUse: C430GetCompanies <User> <Password> <Server>\n");
      printf("                   <Process Type> [<Process Date>]\n");
#endif

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

   /* Recuperacion de Empresas. */

   iC430GetComp(argv);

   EXEC SQL COMMIT WORK;

   EXEC SQL DISCONNECT ALL;

   exit(STDEXIT);
}

/* NOMBRE       : iC430GetComp                                               */
/* DESCRIPCION	: Recupera las Empresas bajo el esquema de Tarjeta Corpora-  */
/*                tiva de acuerdo con los parametros proporcionados por el   */
/*                usuario.                                                   */
/* PARAMETROS 	:                                                            */
/*    psParams[4] = Tipo de Empresa a Analizar:                              */
/*                 0 - Proceso Diario.                                       */
/*                 1 - Proceso Por Corte.                                    */
/*    psParams[5] = Fecha de Procesamiento (Opcional).                       */
/* SALIDAS      : Estatus de conclusion de la rutina:                        */
/*                0 - Exito.                                                 */
/*                1 - Falla.                                                 */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */ 
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 19/08/2003                                                 */
/* CONTROL DE MODIFICACION                                                   */
/*   	IS	NOMBRE			FECHA		DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     19/08/2003     Primera Version         */
/*   Observaciones:                                                          */
/*                                                                           */

#if defined(__STDC__) || defined(__cplusplus)
int iC430GetComp(char *psParams[])             
#else                                        
int iC430GetComp(psParams)                         
char *psParams[];                                
#endif                                       
{
   EXEC SQL BEGIN DECLARE SECTION;

      /* Datos de Empresa. */

      int  iPreffix;		     /* Prefijo del Ejecutivo. */
      int  iBankGroup;               /* No. de Grupo del Banco. */
      int  iCompanyID;               /* Identificador de la Empresa. */
      int  iChargeOffDate;           /* Fecha de Corte (Dia). */
      int  iNumCompanies;            /* No. Total de Empresas a Procesar. */


      /* Fecha del Sistema y componentes. */
 
      char sSystemDate[LEN10+1];   /* Fecha del Sistema. */
      char sProcessDate[LEN8+1];   /* Fecha de Procesamiento de Datos. */ 
      int  iSystemDay;             /* Fecha del Sistema (Dia). */
      int  iSystemMonth;           /* Fecha del Sistema (Mes). */
      int  iSystemYear;            /* Fecha del Sistema (Annio). */


      /* Comando de SQL a ejecutar en la Base de Datos. */

      char sSQLCommand[LEN1000+501];

   EXEC SQL END DECLARE SECTION;


   int  iProcType;               /* Tipo de Procesamiento (Diario / Por Corte). */
   int iCompCount;               /* Contador para Empresas. */
   char sTempNum[LEN10+1];       /* Cadena para conversion de numeros enteros. */
   Company *psCompanies;         /* Conjunto de Empresas a Procesar. */


   /* Inicializacion de Variables. */

   iSystemDay=0;  
   iSystemMonth=0;
   iSystemYear=0;
   strcpy(sSystemDate, EMPSTR);
   strcpy(sProcessDate, EMPSTR);
   strcpy(sSQLCommand, EMPSTR);
   iProcType=0;
   iCompCount=0;


   /* Extraccion de la Fecha del Sistema menos un dia. */

   if(strlen(psParams[5]) > 0)

      strcpy(sProcessDate, psParams[5]);

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


#ifdef DEBUG1
   printf("\nDay: %d", iSystemDay);
   printf("\nMonth: %d", iSystemMonth);
   printf("\nYear: %d\n\n", iSystemYear);
#endif 

   iProcType=atoi(psParams[4]);

   /* Recuperacion de Informacion de Base de Datos. */

   /* Determinacion de Empresas a Procesar. */

   iNumCompanies=0;

   strcpy(sSQLCommand, "SELECT count(*) \n");
   strcat(sSQLCommand, "FROM MTCEMP01 EMP, MTCEJE01 EJE \n");
   strcat(sSQLCommand, "WHERE EMP.eje_prefijo = EJE.eje_prefijo \n");
   strcat(sSQLCommand, "AND EMP.gpo_banco = EJE.gpo_banco \n");
   strcat(sSQLCommand, "AND EMP.emp_num = EJE.emp_num \n");
   strcat(sSQLCommand, "AND EJE.eje_tipo_cuenta = \'E\' \n"); 

   /* Establecer los criterios de recuperacion de Empresas de
      acuerdo con los Parametros de Entrada. */

   if(iProcType == 0)   /* Proceso Diario. */
   {
      strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5)\n");
   }
   else   
   {
      if(iProcType == 1)   /* Proceso por Fecha de Corte. */
      {
         strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) \n");
         strcat(sSQLCommand, "AND EMP.emp_dia_corte = ");
         sprintf(sTempNum, "%d", iSystemDay);
         strcat(sSQLCommand, sTempNum);
      }
      else   /* Error en el parametro Tipo de Archivo. */
      {

#ifdef DEBUG1
         printf("\nFile Type not specified.\n");
#endif

         exit(ERREXIT);
      }
   }


   EXEC SQL PREPARE countcomp FROM :sSQLCommand;

   EXEC SQL EXECUTE countcomp INTO :iNumCompanies;

   psCompanies=malloc(iNumCompanies * sizeof(Company));

   if(psCompanies == NULL)
   {

#ifdef DEBUG1
      printf("\nMemory Not Available.\n");
#endif

      exit(ERREXIT);
   }

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {  
      psCompanies[iCompCount].iPreffix=0;
      psCompanies[iCompCount].iBankGroup=0;
      psCompanies[iCompCount].iCompanyID=0;
      psCompanies[iCompCount].iChargeOffDate=0;
   }                                                           

   EXEC SQL DEALLOCATE PREPARE countcomp;

   EXEC SQL COMMIT WORK; 


   /* Extraccion de registros de la tabla de Empresas MTCEMP01. */ 

   iCompCount=0;

   strcpy(sSQLCommand, "SELECT EMP.eje_prefijo, EMP.gpo_banco, EMP.emp_num, ");
   strcat(sSQLCommand, "isnull(EMP.emp_dia_corte, 0) ");
   strcat(sSQLCommand, "FROM MTCEMP01 EMP, MTCEJE01 EJE ");
   strcat(sSQLCommand, "WHERE EMP.eje_prefijo = EJE.eje_prefijo ");
   strcat(sSQLCommand, "AND EMP.gpo_banco = EJE.gpo_banco ");
   strcat(sSQLCommand, "AND EMP.emp_num = EJE.emp_num ");
   strcat(sSQLCommand, "AND EJE.eje_tipo_cuenta = \'E\' "); 

   /* Establecer los criterios de recuperacion de Empresas de
      acuerdo con los Parametros de Entrada. */

   if(iProcType == 0)   /* Proceso Diario. */
   {
      strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) ");
   }
   else   
   {
      if(iProcType == 1)   /* Proceso por Fecha de Corte. */
      {
         strcat(sSQLCommand, "AND EMP.emp_gen_SBF IN (2,3,4,5) ");
         strcat(sSQLCommand, "AND EMP.emp_dia_corte = ");
         sprintf(sTempNum, "%d", iSystemDay);
         strcat(sSQLCommand, sTempNum);
      }
      else   /* Error en el parametro Tipo de Archivo. */
      {

#ifdef DEBUG1
         printf("\nFile Type not specified.\n");
#endif

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
      iChargeOffDate=0;
   
      EXEC SQL FETCH companydata 
               INTO :iPreffix, :iBankGroup, :iCompanyID, :iChargeOffDate;

      if(sqlca.sqlcode == 100)	/* Fin de consulta. */
         break;

      /* Evaluar la Fecha de Corte asociada a los registros de la
         Empresa. */ 

      if(iProcType == 1)
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
      psCompanies[iCompCount].iChargeOffDate=iChargeOffDate;

      iCompCount++;    
   }

   EXEC SQL CLOSE companydata;            
                                       
   EXEC SQL DEALLOCATE PREPARE companysql;

   EXEC SQL COMMIT WORK;

   /* Imprime la informacion previamente recuperada en pantalla. */

   for(iCompCount=0; iCompCount < iNumCompanies; iCompCount++)
   {  
      printf("%d|%d|%d\n", psCompanies[iCompCount].iPreffix,
                           psCompanies[iCompCount].iBankGroup,
                           psCompanies[iCompCount].iCompanyID);
   }                                                           

   free(psCompanies);

   return STDEXIT;
}
