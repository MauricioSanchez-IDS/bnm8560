#include <stdio.h>
#include <stdlib.h>
#include <sybfront.h>
#include <sybdb.h>
#include "reportes.h"
#include "lib_rep.h"

int SVCREPS(totarg, argu)
int     totarg;
char    argu[16][16];
{
  RISQL               myStr1;
  Arbol               myStrArb;
  Arbol               SubArb;
  char                cadSQL[20000];
  char                cadUnids[10000];
  char                sUnidadPadre[10];
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
  int                 ret;
  int                 rsql;
  int                 R1;
  int                 R2;
  int                 NumRep;
  int                 TOT_ARGS = 14;
  int                 Por_Grupo = 0;
  int                 Por_Tot = 0;
  int                 Grupo = 0;
  short int           iComa = 0;
  short int           iPrimero = 0;
  register short int  i;
  FILE                *pf;

  static ARGU argumento[14] = {
    {10, 's'},
    {10, 's'},
    {4, 'n'},
    {2, 'n'},
    {5, 'n'},
    {5, 'n'},
    {8, 'n'},
    {8, 'n'},
    {4, 'n'},
    {2, 'n'},
    {2, 'n'},
    {10, 's'},
    {1, 'n'},
    {1, 'n'}
  };


  fflush(stdout);
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

  NumRep = atoi(argu[0]);
  sprintf(sNomRep, "%s", argu[1]);
  sprintf(sFecha, "%s", argu[2]);
  sprintf(Prefijo, "%s", argu[3]);
  sprintf(Banco, "%s", argu[4]);
  sprintf(Empresa, "%s", argu[5]);
  sprintf(Unidad, "%s", argu[6]);
  sprintf(fechaIniAMD, "%s", argu[7]);
  sprintf(fechaFinAMD, "%s", argu[8]);
  sprintf(fechaCorteMD, "%s", argu[9]);
  R1 = atoi(argu[10]);
  R2 = atoi(argu[11]);
  sprintf(Archivo, "%s", argu[12]);
  Por_Grupo = atoi(argu[13]);
  Por_Tot = atoi(argu[14]);


/*** EJECUTA EL STORED PROCEDURE DE ACUERDO AL NUM. DE REPORTE ***/

  switch ( NumRep )
  {
   case 13 :

        if ( Por_Grupo )
         Grupo = atoi(Empresa);

        sprintf(cadSQL, " exec sp_ObtenDatosRep13 %d,%d,%d,%d,%d,'%s' ",
                         atoi(Prefijo),atoi(Banco),atoi(Empresa),Por_Grupo,Grupo,sFecha);
        break;
   case 14 :

        if ( Por_Grupo )
         Grupo = atoi(Empresa);

        sprintf(cadSQL, " exec sp_ObtenDatosRep14 %d,%d,%d,%d,%d,'%s','%s' ",
                         atoi(Prefijo),atoi(Banco),atoi(Empresa),Por_Grupo,Grupo,Unidad,sFecha);
        break;
   case 18 :

        if ( Por_Grupo )
         Grupo = atoi(Empresa);

        sprintf(cadSQL, " exec sp_ObtenDatosRep18 %d,%d,%d,%d,%d,%d,'%s','%s' ",
                         atoi(Prefijo),atoi(Banco),atoi(Empresa),Por_Tot,Por_Grupo,Grupo,Unidad,sFecha);
        break;

   case 22 :

        if ( Por_Grupo )
         Grupo = atoi(Empresa);

        sprintf(cadSQL, " exec sp_ObtenDatosRep22 %d,%d,%d,%d,%d,%d,'%s','%s','%s' ",
        atoi(Prefijo),atoi(Banco),atoi(Empresa),Por_Tot,Por_Grupo,Grupo,Unidad,fechaCorteMD,sFecha);
        break;

   case 24 :

        if ( Por_Grupo )
         Grupo = atoi(Empresa);

        sprintf(cadSQL, " exec sp_ObtenDatosRep24 %d,%d,%d,%d,%d,%d,'%s','%s','%s','%s','%s' ",atoi(Prefijo),
        atoi(Banco),atoi(Empresa),Por_Tot,Por_Grupo,Grupo,Unidad,fechaIniAMD,fechaFinAMD,fechaCorteMD,sFecha);
        break;

   case 25 :

        if ( Por_Grupo )
         Grupo = atoi(Empresa);
        sprintf(cadSQL, " exec sp_ObtenDatosRep26 %d,%d,%d,%d,%d,'%s','%s','%s','%s','%s' ",atoi(Prefijo),
        atoi(Banco),atoi(Empresa),Por_Grupo,Grupo,Unidad,fechaIniAMD,fechaFinAMD,fechaCorteMD,sFecha);
        break;

   case 26 :

        if ( Por_Grupo )
         Grupo = atoi(Empresa);

        sprintf(cadSQL, " exec sp_ObtenDatosRep26 %d,%d,%d,%d,%d,'%s','%s','%s','%s','%s' ",atoi(Prefijo),
        atoi(Banco),atoi(Empresa),Por_Grupo,Grupo,Unidad,fechaIniAMD,fechaFinAMD,fechaCorteMD,sFecha);
        break;

  }

/*  printf("\n %s comando : %s ", sNomRep,cadSQL); */

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 1;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

  if (myStr1.lRegistros != 0) {

    if ((pf = fopen(Archivo, "w")) == NULL) {
      fprintf(stdout, "Error al ejecutar fopen\n");
      return (-1);
    }

    RegistroPrimero(&myStr1);
    sprintf(Buffer, "");

    do
    {
      sprintf(Buffer, "");
      ret = ObtenCampo(&myStr1, 0, Buffer);
      fprintf(pf, "%s\n", Buffer);
      fflush(pf);
      rsql = RegistroSiguiente(&myStr1);
    }
    while (rsql == 0);

    fclose(pf);
    LiberaMemCab(&myStr1);
    return (0);
  }
  else {
    fprintf(stdout, "No existe informacion para los parametros introducidos\n");

    LiberaMemCab(&myStr1);
    return (1);
  }
}

