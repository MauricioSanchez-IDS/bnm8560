#include <stdio.h>
#include <stdlib.h>
#include <sybfront.h>
#include <sybdb.h>
#include "reportes.h" 
#include "lib_rep.h"
#include <string.h>

int SVCREP16(totarg, argu) 
int     totarg;
char    argu[16][16]; 
{
  RISQL               myStr;
  Arbol               myStrArb;
  Arbol               SubArb;
  char                cadSQL[20000];
  char                cadUnids[10000];
  char                sUnidadPadre[10];
  char                Buffer[1000];
  char                *pPtr;
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
  char                Archivo[256];
  int                 ret;
  int                 rsql;
  int                 R1;
  int                 R2;
  int                 iRegXHoja;
  int                 iPag;
  int                 iPagTotales = 1;
  int                 Por_Grupo = 0;
  int                 iMod;
  int                 TOT_ARGS = 12;
  short int           iComa = 0;
  register short int  i;
  FILE                *pf;

  static stFormatoTit TitRep1[6] = {
    {"UNIDAD", 7, 'I', " "},
    {"NIVEL", 7, 'I', " "},
    {"CUENTA", 17, 'I', " "},
    {"NOMBRE", 40, 'I', " "},
    {"NOMINA", 15, 'I', " "},
    {"MONTO ACLARACION", 16, 'D', " "}
  };

  static stFormatoDat DetRep1[6] = {
    {0, 7, 'I', " "},
    {1, 7, 'I', " "},
    {2, 17, 'I', " "},
    {3, 40, 'I', " "},
    {4, 15, 'I', " "},
    {5, 16, 'D', " "}
  };

  static ARGU argumento[12] = {
    {10, 's'},
    {10, 's'},
    {4, 'n'},
    {2, 'n'},
    {5, 'n'},
    {5, 'n'},
    {8, 'n'},
    {8, 'n'},
    {2, 'n'},
    {2, 'n'},
    {10, 's'},
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

  sprintf(sNomRep, "%s", argu[1]);
  sprintf(sFecha, "%s", argu[2]);
  sprintf(Prefijo, "%s", argu[3]);
  sprintf(Banco, "%s", argu[4]);
  sprintf(Empresa, "%s", argu[5]);
  sprintf(Unidad, "%s", argu[6]);
  sprintf(fechaIniAMD, "%s", argu[7]);
  sprintf(fechaFinAMD, "%s", argu[8]);
  R1 = atoi(argu[9]);
  R2 = atoi(argu[10]);
  sprintf(Archivo, "%s", argu[11]);
  Por_Grupo = atoi(argu[12]);
  
  IniciaBase();
  fflush(stdout);
  ObtenArbolUni(&myStrArb);


	
 if ( Por_Grupo ) {
          /** CONSULTA LA EMPRESA MENOR DEL GRUPO SI EL REPORTE ES GENERADO POR GRUPO **/
    strcpy(EmpresaMenor, "");
    sprintf(cadSQL, "select distinct emp_num from MTCUNI01 where eje_prefijo=%s and gpo_banco=%s and gpo_num = %s order by emp_num", Prefijo,Banco,Empresa);
    myStr.scadena_sql = cadSQL;
    myStr.icampos = 1;
    myStr.lRegistros = 0;
    ret = EjecutaSQL(&myStr);
    if ( ret != 0 ) {
        fprintf(stdout, "Error al ejecutar la consulta de Empresas del grupo \n");
        return (-1);
    }
    ret = RegistroPrimero(&myStr);
    ret = ObtenCampo(&myStr, 0, EmpresaMenor);
    TraeUnidad(&myStrArb, &SubArb, Prefijo,Banco,EmpresaMenor, Unidad, R1, R2);
    i = 0;
    do {
          ret = ObtenCampo(&myStr, 0, EmpresaMenor);
          if ( i != 0 ){
              strcat(Empresas, " , ");
              strcat(Empresas, EmpresaMenor);
          } else
              sprintf(Empresas, "%s", EmpresaMenor);
          ret = RegistroSiguiente(&myStr);
          i++;
          } while (ret == 0);
  } else {
    TraeUnidad(&myStrArb, &SubArb, Prefijo,Banco,Empresa, Unidad, R1, R2);
  }
  RegUniPrimero(&SubArb);
  sprintf(cadUnids, "(");

  do {
    ObtenValorUni(&SubArb, UNIT_ID, sCadena);

    if (iComa != 1) {
      sprintf(cadUnids, "%s'%d'", cadUnids, atoi(sCadena));
      sprintf(sUnidadPadre, "%s", sCadena);
      iComa = 1;
    } else
      sprintf(cadUnids, "%s,\n'%d'", cadUnids, atoi(sCadena));

    ret = RegUniSiguiente(&SubArb);
  }
  while (ret == 0);
  sprintf(cadUnids, "%s)", cadUnids);

fprintf(stdout,"REP 16 Prefijo %s %s %s %s \n %s \n",Prefijo,Banco,Empresa,Unidad,cadUnids);

  sprintf(cadSQL, " SELECT \n");
  strcat(cadSQL, " x.eje_centro_c, \n");
  strcat(cadSQL, " uni.nivel_num, \n");
  strcat(cadSQL, " convert(char(16), \n");
  strcat(cadSQL, " convert(char(4),x.eje_prefijo)+ \n");
  strcat(cadSQL, " convert(char(2),x.gpo_banco)+ \n");
  strcat(cadSQL, " replicate('0',(SELECT pgs_long_emp \n");
  strcat(cadSQL, " FROM MTCPGS01 a \n");
  strcat(cadSQL, " WHERE a.pgs_rep_prefijo = x.eje_prefijo and \n");
  strcat(cadSQL, " a.pgs_rep_banco = x.gpo_banco) \n");
  strcat(cadSQL, " -char_length(ltrim(rtrim(str(x.emp_num)))))+ \n");
  strcat(cadSQL, " ltrim(rtrim(str(x.emp_num)))+ \n");
  strcat(cadSQL, " replicate('0',(SELECT pgs_long_eje \n");
  strcat(cadSQL, " FROM MTCPGS01 b \n");
  strcat(cadSQL, " WHERE b.pgs_rep_prefijo = x.eje_prefijo and \n");
  strcat(cadSQL, " b.pgs_rep_banco = x.gpo_banco) \n");
  strcat(cadSQL, " -char_length(ltrim(rtrim(str(x.eje_num)))))+ \n");
  strcat(cadSQL, " ltrim(rtrim(str(x.eje_num)))+ \n");
  strcat(cadSQL, " convert(char(1),x.eje_roll_over)+ \n");
  strcat(cadSQL, " convert(char(1),x.eje_digit)) as cuenta, \n");
  strcat(cadSQL, " x.eje_nombre as nombre, \n");
  strcat(cadSQL, " ltrim(rtrim(x.eje_num_nom)) as nomina, \n");
  strcat(cadSQL, " a.imp_acl_pesos as monto \n");
  strcat(cadSQL, " into #TMP_REP_ACLARACIONES \n");
  strcat(cadSQL, " FROM MTCEJE01 x , MTCACL01 a, MTCUNI01 uni \n");
  strcat(cadSQL, " where x.eje_prefijo = ");
  strcat(cadSQL, Prefijo);
  strcat(cadSQL, " and x.gpo_banco = ");
  strcat(cadSQL, Banco);
  
  if ( Por_Grupo ) {
     strcat(cadSQL, " and x.emp_num in ( ");
     strcat(cadSQL, Empresas );
     strcat(cadSQL, " ) ");
  } else {
  strcat(cadSQL, " and x.emp_num = ");
  strcat(cadSQL, Empresa);
  }
  
  strcat(cadSQL, " and x.eje_centro_c = uni.unit_id \n");
  strcat(cadSQL, " and a.eje_prefijo = uni.eje_prefijo \n");
  strcat(cadSQL, " and a.gpo_banco = uni.gpo_banco \n");
  strcat(cadSQL, " and a.emp_num = uni.emp_num \n");

  strcat(cadSQL, " and a.fec_valor between '");
  strcat(cadSQL, fechaIniAMD);
  strcat(cadSQL, "' and '");
  strcat(cadSQL, fechaFinAMD);

  if (strlen(cadUnids) < 128) {
    strcat(cadSQL, "' and x.eje_centro_c in ");
    strcat(cadSQL, cadUnids);
  }
  else {
    strcat(cadSQL, " and x.eje_centro_c != NULL ");
  }


  strcat(cadSQL, " and a.eje_prefijo = x.eje_prefijo \n");
  strcat(cadSQL, " and a.gpo_banco = x.gpo_banco \n");
  strcat(cadSQL, " and a.emp_num = x.emp_num \n");
  strcat(cadSQL, " and a.eje_num = x.eje_num \n");

  strcat(cadSQL, " update #TMP_REP_ACLARACIONES \n");
  strcat(cadSQL, " set cuenta = map.map_cta_citi \n");
  strcat(cadSQL, " from #TMP_REP_ACLARACIONES tmp, MTCMAP01 map \n");
  strcat(cadSQL, " where tmp.cuenta = map.map_cta_bnx and map.map_estatus = ' ' \n");

  strcat(cadSQL, " select eje_centro_c, nivel_num, cuenta, nombre, nomina, \n");
  strcat(cadSQL, " convert(money, isnull(monto, 0.00)) \n");
  strcat(cadSQL, " from #TMP_REP_ACLARACIONES \n");
  strcat(cadSQL, " order by nivel_num, eje_centro_c, cuenta, nombre, nomina \n");

  myStr.scadena_sql = cadSQL;
  myStr.icampos = 6;
  myStr.lRegistros = 0;
  EjecutaSQL(&myStr);

  if (myStr.lRegistros != 0) {
    if ((pf = fopen(Archivo, "w")) == NULL) {
      fprintf(stdout, "Error al ejecutar fopen\n");
      return (-1);
    }

    RegistroPrimero(&myStr);

    /* PAGINACION */
    iRegXHoja = 0;
    iPag = 1;
    if (myStr.lRegistros >= 0) {
      iMod = myStr.lRegistros % 50;
      if (iMod != 0)
        iPagTotales = (myStr.lRegistros / 50) + 1;
      else
        iPagTotales = (myStr.lRegistros / 50);
    }
    else
      iPagTotales = 1;

    sprintf(Buffer, "%s", "");
    if ( Por_Grupo ) 
      pcEncabezado(Banco, Empresas, sUnidadPadre, argu[2], argu[1], "ACLARACIONES", 110, Buffer);
    else
      pcEncabezado(Banco, Empresa, sUnidadPadre, argu[2], argu[1], "ACLARACIONES", 110, Buffer);
    fprintf(pf, "\n%s", Buffer);
    fflush(pf);
    sprintf(Buffer, "%s", "");
    pcTitulos(TitRep1, "-", 0, 5, Buffer);
    fprintf(pf, "\n %s", Buffer);
    fflush(pf);

    do {
      if (iRegXHoja == 50) {
        sprintf(Buffer, "%s", "");
        pcPiedePagina(iPag, iPagTotales, 110, 'C', Buffer);

        /* fprintf(pf, "\n%s\f ", Buffer); */
        fprintf(pf, "\n%s ", Buffer);

        fflush(pf);

        sprintf(Buffer, "%s", "");
        if ( Por_Grupo ) 
           pcEncabezado(Banco, Empresas, sUnidadPadre, argu[2], argu[1], "ACLARACIONES", 110, Buffer);
       else
           pcEncabezado(Banco, Empresa, sUnidadPadre, argu[2], argu[1], "ACLARACIONES", 110, Buffer);
        fprintf(pf, "\n%s", Buffer);
        fflush(pf);

        sprintf(Buffer, "%s", "");
        pcTitulos(TitRep1, "-", 0, 5, Buffer);
        fprintf(pf, "\n %s", Buffer);
        fflush(pf);

        iPag++;
        iRegXHoja = 0;
      }
      sprintf(Buffer, "%s", "");
      pcDetalle(DetRep1, 0, 5, &myStr, Buffer);
      fprintf(pf, " %s", Buffer);
      fflush(pf);

      iRegXHoja++;
      rsql = RegistroSiguiente(&myStr);
    } while (rsql == 0);

    sprintf(Buffer, "%s", "");
    pcPiedePagina(iPag, iPagTotales, 110, 'C', Buffer);

    /* fprintf(pf, "\n%s\f ", Buffer); */
    fprintf(pf, "\n%s ", Buffer); 
 
    fflush(pf);

    fclose(pf);
    LiberaMemCab(&myStr);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (0);
  }
  else {
    fprintf(stdout, "No existe informacion para los parametros introducidos\n");

    LiberaMemCab(&myStr);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (1);
  }
}
