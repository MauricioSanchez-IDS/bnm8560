#include <stdio.h>
#include <stdlib.h>
#include <sybfront.h>
#include <sybdb.h>
#include "reportes.h"
#include "lib_rep.h"
#include <string.h>

int SVCREP22(totarg, argu)
int     totarg;
char    argu[16][16];
{
  RISQL               myStr1;
  RISQL               myStr2;
  RISQL               myStr3;
  Arbol               myStrArb;
  Arbol               SubArb;
  char                cadSQL[20000];
  char                cadUnids[10000];
  char                sUnidadPadre[10];
  char                sCambioUni1[6];
  char                sCambioUni2[6];
  char                sCadenaRetorno[PARTAMANO];
  char                sCadena[16];
  char                sEmpTem[255];
  char                sNomRep[10 + 1];
  char                sFecha[10 + 1];
  char                Prefijo[4 + 1];
  char                Banco[2 + 1];
  char                Empresa[5 + 1];
  char                EmpresaMenor[5 + 1];
  char                Empresas[ 700 + 1];
  char                Unidad[5 + 1];
  char                fechaIniAMD[8 + 1];
  char                fechaFinAMD[8 + 1];
  char                fechaCorteMD[4 + 1];
  char                Buffer[1000];
  char                *pPtr;
  char                Archivo[256];
  char                NomTabSal[50];
  char                UnidPadreSal[15];
  int                 ret;
  int                 rsql1;
  int                 rsql2;
  int                 rsql3;
  int                 rsql4;
  int                 rsql5;
  int                 R1;
  int                 Grupo = 0;
  int                 Por_Grupo = 0;
  int                 Por_Tot = 0;
  int                 R2;
  int                 TOT_ARGS = 12;
  short int           iComa = 0;
  register short int  i;
  FILE                *pf;

  char                dataval[50];
  char                *dataname;
  DBINT               datalen;
  int                 ii, numrets;

/*** TITULO ***/
/** JAGG 17-06-2004 intereses **/
/*************  CREDITO  ***************/
  static stFormatoTit TitRep1[16] = {
    {"UNIDAD", 6, 'I', " "},
    {"NIVEL", 5, 'I', " "},
    {"CUENTA", 16, 'I', " "},
    {"NOMBRE EJECUTIVO", 40, 'I', " "},
    {"NOMINA", 15, 'I', " "},
    {"LIMITE CREDITO", 17, 'D', " "},
    {"SC", 10, 'D', " "},
    {"ATRASOS", 12, 'D', " "},
    {"SALDO ANT", 12, 'D', " "},
    {"CONSUMOS", 12, 'D', " "},
    {"DISP EFE", 12, 'D', " "},
    {"PAGOS", 12, 'D', " "},
    {"COMISION", 12, 'D', " "},
    {"GAST COB", 12, 'D', " "},
    {"IVA", 12, 'D', " "},
    {"SAL NUEVO", 12, 'D', " "}
  };
/** JAGG 17-06-2004 intereses **/


/*** DETALLE PRINCIPAL ***/
  static stFormatoDat DetRep1[16] = {
    {0, 6, 'I', " "},
    {1, 5, 'I', " "},
    {2, 16, 'I', " "},
    {3, 40, 'I', " "},
    {4, 15, 'I', " "},
    {5, 14, 'D', " "},
    {6, 10, 'D', " "},
    {7, 12, 'D', " "},
    {8, 12, 'D', " "},
    {9, 12, 'D', " "},
    {10, 12, 'D', " "},
    {11, 12, 'D', " "},
    {12, 12, 'D', " "},
    {14, 12, 'D', " "},
    {15, 12, 'D', " "},
    {16, 12, 'D', " "}
  };

/*** DETALLE (SUMARIZADO POR CUENTA) ***/

  static stFormatoDat DetRep2[11] = {
    {0, 30, 'I', " "},
    {1, 83, 'I', " "},
    {2, 12, 'D', " "},
    {3, 12, 'D', " "},
    {4, 12, 'D', " "},
    {5, 12, 'D', " "},
    {6, 12, 'D', " "},
    {7, 12, 'D', " "},
    {8, 12, 'D', " "},
    {9, 12, 'D', " "},
    {10, 12, 'D', " "}
  };

/*** DETALLE (SUMARIZADO TOTAL) ***/

  static stFormatoDat DetRep3[11] = {
    {0, 30, 'I', " "},
    {1, 83, 'I', " "},
    {2, 12, 'D', " "},
    {3, 12, 'D', " "},
    {4, 12, 'D', " "},
    {5, 12, 'D', " "},
    {6, 12, 'D', " "},
    {7, 12, 'D', " "},
    {8, 12, 'D', " "},
    {9, 12, 'D', " "},
    {10, 12, 'D', " "}
  };

/*** INICIA DE VALIDACION DE ARGUMENTOS  DE ENTRADA ***/

  static ARGU   argumento[13] = {
    {10, 's'},
    {10, 's'},
    {4, 'n'},
    {2, 'n'},
    {5, 'n'},
    {5, 'n'},
    {4, 'n'},
    {2, 'n'},
    {2, 'n'},
    {10, 's'},
    {1, 'n'},
    {1, 'n'}
  };

  if (totarg != (TOT_ARGS + 1)) {
    fprintf(stdout, "Numero de argumentos incorrecto\n");
    return (-1);
  }

  for (i = 0; i < TOT_ARGS; i++) {
    if (strlen(argu[i + 1]) > argumento[i].ilen) {
        fprintf(stdout, "El argumento %d excede la longitud\n", i + 1);
        return (-1);
    }
    else if (argumento[i].cNum == 'n') {
      pPtr = argu[i + 1];
      while (*pPtr) {
        if (! isdigit(*pPtr)) {
          fprintf(stdout, "El argumento %d debe ser totalmente numerico\n", i + 1);
          return (-1);
        }
        ++pPtr;
      }
    }
  }

/*** TERMINA VALIDACION DE ARGUMENTOS ***/
  sprintf(sNomRep, "%s", argu[1]);
  sprintf(sFecha, "%s", argu[2]);
  sprintf(Prefijo, "%s", argu[3]);
  sprintf(Banco, "%s", argu[4]);
  sprintf(Empresa, "%s", argu[5]);
  sprintf(Unidad, "%s", argu[6]);
  sprintf(fechaCorteMD, "%s", argu[7]);
  R1 = atoi(argu[8]);
  R2 = atoi(argu[9]);
  sprintf(Archivo, "%s", argu[10]);
  Por_Grupo = atoi(argu[11]);
  Por_Tot = atoi(argu[12]);

/*
  IniciaBase();
  fflush(stdout);
  ObtenArbolUni(&myStrArb);
   if ( Por_Grupo ) {
	 strcpy(EmpresaMenor, "");
	 sprintf(cadSQL, "select distinct emp_num from MTCUNI01 where eje_prefijo= %s and gpo_banco=%s and gpo_num=%s order by emp_num", Prefijo,Banco,Empresa);
	 myStr1.scadena_sql = cadSQL;
	 myStr1.icampos = 1;
	 myStr1.lRegistros = 0;
	 ret = EjecutaSQL(&myStr1);
	 if ( ret != 0 ) {
	    fprintf(stdout, "Error al ejecutar la consulta de Empresas del grupo \n");
	    return (-1);
	  }
	 ret = RegistroPrimero(&myStr1);
	 ret = ObtenCampo(&myStr1, 0, EmpresaMenor);
	 TraeUnidad(&myStrArb, &SubArb, Prefijo,Banco,EmpresaMenor,Unidad, R1, R2);
	 i = 0;
	 do {
	   ret = ObtenCampo(&myStr1, 0, EmpresaMenor);
	   if ( i != 0 ){
		strcat(Empresas, " , ");
	        strcat(Empresas, EmpresaMenor);
	   } else
	   sprintf(Empresas, "%s", EmpresaMenor);
	   ret = RegistroSiguiente(&myStr1);
	   i++;
	  } while (ret == 0);
   } else {
        TraeUnidad(&myStrArb, &SubArb,Prefijo,Banco,Empresa,Unidad, R1, R2);

   }

  RegUniPrimero(&SubArb);

 */

/*** CONSTRUCCION DE CADENA DE UNIDADES ***/

/*
  sprintf(cadUnids, "(");
  do {
    ObtenValorUni(&SubArb, UNIT_ID, sCadena);

    if (iComa != 1) {
      sprintf(cadUnids, "%s'%d'", cadUnids, atoi(sCadena));
      sprintf(sUnidadPadre, "%s", sCadena);
      iComa = 1;
    }
    else
      sprintf(cadUnids, "%s,\n'%d'", cadUnids, atoi(sCadena));

    ret = RegUniSiguiente(&SubArb);
  }
  while (ret == 0);
  sprintf(cadUnids, "%s)", cadUnids);
fprintf(stdout,"REP 22 Prefijo %s %s %s %s \n %s \n",Prefijo,Banco,Empresa,Unidad,cadUnids);

*/

/*** CONSULTAS ***/

  if ( Por_Grupo )
    Grupo = atoi(Empresa);

  sprintf(cadSQL,
  " declare @TabSal varchar(50), @UPadreSal varchar(15) exec sp_ObtenDatosRep22 %d,%d,%d,%d,%d,%d,'%s','%s',0,NULL,@TabSal output,@UPadreSal output ",
  atoi(Prefijo),atoi(Banco),atoi(Empresa),Por_Tot,Por_Grupo,Grupo,Unidad,fechaCorteMD);

  printf("\n Rep 22 comando1 : %s ", cadSQL);

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 16;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

  /* Obtiene el valor de los parametros de salida del Stored Procedure */
  numrets = dbnumrets(myStr1.dbproc);
  for (ii = 1; ii <= numrets; ii++)
  {
    dataname = dbretname(myStr1.dbproc, ii);
    datalen  = dbretlen (myStr1.dbproc, ii);
    if (datalen == 0)
        strcpy(dataval, "NULL");
    else
        dbconvert(myStr1.dbproc, dbrettype(myStr1.dbproc, ii), dbretdata(myStr1.dbproc, ii),
                datalen, SYBCHAR, (BYTE *)dataval, -1);
    if ( ii == 1)
       strcpy(NomTabSal, dataval);
    else
       strcpy(UnidPadreSal, dataval);
  }

  printf("\n TabSal : %s ", NomTabSal);
  printf("\n UPadreSal : %s ", UnidPadreSal);

/*** CONSULTA PARA DETALLE 2 ***/

  sprintf(cadSQL, " exec sp_ObtenDatosRep22 %d,%d,%d,%d,%d,%d,'%s','%s',%d,'%s',NULL,NULL ",
                    atoi(Prefijo),atoi(Banco),atoi(Empresa),Por_Tot,Por_Grupo,Grupo,Unidad,fechaCorteMD,
                    1,NomTabSal);

  printf("\n Rep 22 comando2 : %s ", cadSQL);

  myStr2.scadena_sql = cadSQL;
  myStr2.icampos = 11;
  myStr2.lRegistros = 0;
  EjecutaSQL(&myStr2);

/*** CONSULTA PARA DETALLE 3 ***/

  sprintf(cadSQL, " exec sp_ObtenDatosRep22 %d,%d,%d,%d,%d,%d,'%s','%s',%d,'%s',NULL,NULL ",
                    atoi(Prefijo),atoi(Banco),atoi(Empresa),Por_Tot,Por_Grupo,Grupo,UnidPadreSal,fechaCorteMD,
                    2,NomTabSal);

  printf("\n Rep 22 comando3 : %s ", cadSQL);

  myStr3.scadena_sql = cadSQL;
  myStr3.icampos = 11;
  myStr3.lRegistros = 0;
  EjecutaSQL(&myStr3);

  if (myStr1.lRegistros != 0) {
    if ((pf = fopen(Archivo, "w")) == NULL) {
      fprintf(stdout, "Error al ejecutar fopen\n");
      return (-1);
    }
    sprintf(sCambioUni1, "");
    sprintf(sCambioUni2, "");

    RegistroPrimero(&myStr1);
    RegistroPrimero(&myStr2);
    RegistroPrimero(&myStr3);

    ObtenCampo(&myStr1, 0, sCambioUni2);

    sprintf(Buffer, "");
    if ( Por_Grupo )
       pcEncabezado(Banco, Empresas, sUnidadPadre, argu[2], argu[1], "CONCENTRADO EMPRESA EJECUTIVO", 220, Buffer);
    else
       pcEncabezado(Banco, Empresa, sUnidadPadre, argu[2], argu[1], "CONCENTRADO EMPRESA EJECUTIVO", 220, Buffer);

    fprintf(pf, "\n%s", Buffer);
    fflush(pf);

    sprintf(Buffer, "");

    pcTitulos(TitRep1, "-", 0, 15, Buffer);

    fprintf(pf, "\n %s", Buffer);
    fflush(pf);

    do {
      sprintf(sCambioUni1, "%s", sCambioUni2);
      sprintf(sCambioUni2, "");

      ObtenCampo(&myStr1, 0, sCambioUni2);

      if (strcmp(sCambioUni1, sCambioUni2) != 0) {
        sprintf(Buffer, "");
        pcDetalle(DetRep2, 0, 10, &myStr2, Buffer);
        fprintf(pf, "\n %s\n", Buffer);
        fflush(pf);

        rsql2 = RegistroSiguiente(&myStr2);
      }

      sprintf(Buffer, "");
      pcDetalle(DetRep1, 0, 15, &myStr1, Buffer);
      fprintf(pf, " %s", Buffer);
      fflush(pf);

      rsql1 = RegistroSiguiente(&myStr1);
    }
    while (rsql1 == 0);

    sprintf(Buffer, "");
    pcDetalle(DetRep2, 0, 10, &myStr2, Buffer);
    fprintf(pf, "\n\n %s\n", Buffer);
    fflush(pf);

    sprintf(Buffer, "");
    pcDetalle(DetRep3, 0, 10, &myStr3, Buffer);
    fprintf(pf, "\n %s\n", Buffer);
    fflush(pf);

    fclose(pf);
    LiberaMemCab(&myStr1);
    LiberaMemCab(&myStr2);
    LiberaMemCab(&myStr3);
/*    LiberaMemArb(&myStrArb);
    Desconecta();
*/
    return (0);
  }
  else {
    fprintf(stdout, "No existe informacion para los parametros introducidos\n");
    LiberaMemCab(&myStr1);
    LiberaMemCab(&myStr2);
    LiberaMemCab(&myStr3);
/*    LiberaMemArb(&myStrArb);
    Desconecta();
*/
    return (1);
  }

}
