#include <stdio.h>
#include <stdlib.h>
#include <sybfront.h>
#include <sybdb.h>
#include "reportes.h"
#include "lib_rep.h"

int SVCREP24(totarg, argu)
int     totarg;
char    argu[16][16]; 

{
  RISQL               myStr1;
  RISQL               myStr2;
  RISQL               myStr3;
  RISQL               myStr4;
  RISQL               myStr5;
  Arbol               myStrArb;
  Arbol               SubArb;
  char                cadSQL[20000];
  char                cadUnids[10000];
  char                sUnidadPadre[10];
  char                sCambioSIC1[10];
  char                sCambioSIC2[10];
  char                sCambioCta1[17];
  char                sCambioCta2[17];
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
  int                 R1;
  int                 R2;
  int                 ret;
  int                 rsql1;
  int                 rsql2;
  int                 rsql3;
  int                 rsql4;
  int                 rsql5;
  int                 Por_Grupo = 0;
  int                 TOT_ARGS = 13;
  short int           iComa = 0;
  short int           iPrimero = 0;
  short int           iImpreso;
  register short int  i;
  FILE                *pf;

/*** TITULO 1 (TITULO PRINCIPAL)***/

  static stFormatoTit TitRep1[7] = {
    {"UNIDAD", 6, 'I', " "},
    {"NIVEL", 5, 'I', " "},
    {"CUENTA", 16, 'I', " "},
    {"NOMBRE", 40, 'I', " "},
    {"NOMINA", 15, 'I', " "},
    {"NEGOCIO", 36, 'I', " "},
    {"MONTO", 20, 'D', " "}
  };

/*** TITULO 2 (TITULO PARA CADA CAMBIO DE CATEGORIA)***/

  static stFormatoTit TitRep2[2] = {
    {"SIC", 6, 'I', " "},
    {"DESCRIPCION", 30, 'I', " "}
  };

/**** DETALLE 1 (SIC/DESCRIPCION) ****/

  static stFormatoDat DetRep1[2] = {
    {0, 6, 'I', " "},
    {1, 30, 'I', " "}
  };

/**** DETALLE 2 (TRANSACCIONES) ****/

  static stFormatoDat DetRep2[8] = {
    {0, 6, 'I', " "},
    {1, 5, 'I', " "},
    {2, 16, 'I', " "},
    {3, 40, 'I', " "},
    {4, 15, 'I', " "},
    {5, 36, 'I', " "},
    {6, 20, 'D', " "},
    {7, 6, 'I', " "}
  };

/**** DETALLE 3 (SUMARIZADO POR CUENTA)****/

  static stFormatoDat DetRep3[6] = {
    {0, 12, 'I', " "},
    {1, 16, 'I', " "},
    {2, 13, 'I', " "},
    {3, 12, 'I', " "},
    {4, 16, 'I', " "},
    {5, 21, 'I', " "}
  };

/**** DETALLE 4 (SUMARIZADO POR CATEGORIA)****/

  static stFormatoDat DetRep4[6] = {
    {0, 23, 'I', " "},
    {1, 6, 'I', " "},
    {2, 13, 'I', " "},
    {3, 12, 'I', " "},
    {4, 16, 'I', " "},
    {5, 21, 'I', " "}
  };

/**** DETALLE 5 (SUMARIZADO TOTAL POR UNIDAD)****/

  static stFormatoDat DetRep5[4] = {
    {0, 49, 'I', " "},
    {1, 11, 'I', " "},
    {2, 14, 'I', " "},
    {3, 21, 'I', " "}
  };

/*** INICIA DE VALIDACION DE ARGUMENTOS  DE ENTRADA ***/

  static ARGU     argumento[13] = {
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
    {1, 'n' }
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
  sprintf(fechaIniAMD, "%s", argu[7]);
  sprintf(fechaFinAMD, "%s", argu[8]);
  sprintf(fechaCorteMD, "%s", argu[9]);
  R1 = atoi(argu[10]);
  R2 = atoi(argu[11]);
  sprintf(Archivo, "%s", argu[12]);
  Por_Grupo = atoi(argu[13]);
  
  IniciaBase();
  ObtenArbolUni(&myStrArb);

if ( Por_Grupo ) {
       strcpy(EmpresaMenor, "");
       sprintf(cadSQL, "select distinct emp_num from MTCUNI01 where eje_prefijo=%s and gpo_banco=%s and gpo_num = %s order by emp_num",Prefijo,Banco, Empresa);
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
       TraeUnidad(&myStrArb, &SubArb,Prefijo,Banco,EmpresaMenor,Unidad, R1, R2);
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
      TraeUnidad(&myStrArb, &SubArb,Prefijo,Banco,Empresa, Unidad, R1, R2);
  }
  RegUniPrimero(&SubArb);

/*** CONSTRUCCION DE CADENA DE UNIDADES ***/
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
fprintf(stdout,"REP 24 Prefijo %s %s %s %s \n %s \n",Prefijo,Banco,Empresa,Unidad,cadUnids);
/*** GUARDADO DE CONSULTAS ***/

  sprintf(cadSQL, "IF OBJECT_ID('dbo.TMP_REP_MERCHANTANALYSIS ') IS NOT NULL\n ");
  strcat(cadSQL, "BEGIN\n ");
  strcat(cadSQL, "DROP TABLE dbo.TMP_REP_MERCHANTANALYSIS\n ");
  strcat(cadSQL, "PRINT '<<< DROPPED TABLE dbo.TMP_REP_MERCHANTANALYSIS >>>'\n ");
  strcat(cadSQL, "END\n ");

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 1;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

  sprintf(cadSQL, " select\n ");
  strcat(cadSQL, "convert(char(16),\n ");
  strcat(cadSQL, "convert(char(4),x.eje_prefijo)+\n ");
  strcat(cadSQL, "convert(char(2),x.gpo_banco)+\n ");
  strcat(cadSQL, "replicate('0',(SELECT pgs_long_emp\n ");
  strcat(cadSQL, "FROM MTCPGS01 a\n ");
  strcat(cadSQL, "WHERE a.pgs_rep_prefijo = x.eje_prefijo and\n ");
  strcat(cadSQL, "a.pgs_rep_banco = x.gpo_banco)\n ");
  strcat(cadSQL, "-char_length(ltrim(rtrim(str(x.emp_num)))))+\n ");
  strcat(cadSQL, "ltrim(rtrim(str(x.emp_num)))+\n ");
  strcat(cadSQL, "replicate('0',(SELECT pgs_long_eje\n ");
  strcat(cadSQL, "FROM MTCPGS01 b\n ");
  strcat(cadSQL, "WHERE b.pgs_rep_prefijo = x.eje_prefijo and\n ");
  strcat(cadSQL, "b.pgs_rep_banco = x.gpo_banco)\n ");
  strcat(cadSQL, "-char_length(ltrim(rtrim(str(x.eje_num)))))+\n ");
  strcat(cadSQL, "ltrim(rtrim(str(x.eje_num)))+\n ");
  strcat(cadSQL, "convert(char(1),x.eje_roll_over)+\n ");
  strcat(cadSQL, "convert(char(1),x.eje_digit)) as cuenta,\n ");
  strcat(cadSQL, "x.b01_neg_num_neg,\n ");
  strcat(cadSQL, "convert(money, x.his_importe) as his_importe\n ");
  strcat(cadSQL, "into #TMP1_REPORTEMA\n ");
  strcat(cadSQL, "from MTCHIS01 x\n ");
  strcat(cadSQL, "where\n ");
  strcat(cadSQL, "x.eje_prefijo = ");
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
  if((atof(fechaIniAMD) != 0) && (atof(fechaFinAMD) != 0)) {
    strcat(cadSQL, " and x.his_proceso_amd between ");
    strcat(cadSQL, fechaIniAMD);
    strcat(cadSQL, " and ");
    strcat(cadSQL, fechaFinAMD);
  }

  if(atof(fechaCorteMD) != 0) {
    strcat(cadSQL, " and x.his_mes_y_ciclo_corte = ");
    strcat(cadSQL, fechaCorteMD);
  }

  strcat(cadSQL, " and x.his_transaccion in\n ");
  strcat(cadSQL, "(select cve_transaccion from MTCTRA01\n ");
  strcat(cadSQL, "where\n ");
  strcat(cadSQL, "tip_transaccion = 'compra')\n ");
  strcat(cadSQL, "order by b01_neg_num_neg\n ");

  strcat(cadSQL, " select\n ");
  strcat(cadSQL, "convert(char(16),\n ");
  strcat(cadSQL, "convert(char(4),eje.eje_prefijo)+\n ");
  strcat(cadSQL, "convert(char(2),eje.gpo_banco)+\n ");
  strcat(cadSQL, "replicate('0',(SELECT pgs_long_emp\n ");
  strcat(cadSQL, "FROM MTCPGS01 a\n ");
  strcat(cadSQL, "WHERE a.pgs_rep_prefijo = eje.eje_prefijo and\n ");
  strcat(cadSQL, "a.pgs_rep_banco = eje.gpo_banco)\n ");
  strcat(cadSQL, "-char_length(ltrim(rtrim(str(eje.emp_num)))))+\n ");
  strcat(cadSQL, "ltrim(rtrim(str(eje.emp_num)))+\n ");
  strcat(cadSQL, "replicate('0',(SELECT pgs_long_eje\n ");
  strcat(cadSQL, "FROM MTCPGS01 b\n ");
  strcat(cadSQL, "WHERE b.pgs_rep_prefijo = eje.eje_prefijo and\n ");
  strcat(cadSQL, "b.pgs_rep_banco = eje.gpo_banco)\n ");
  strcat(cadSQL, "-char_length(ltrim(rtrim(str(eje.eje_num)))))+\n ");
  strcat(cadSQL, "ltrim(rtrim(str(eje.eje_num)))+\n ");
  strcat(cadSQL, "convert(char(1),eje.eje_roll_over)+\n ");
  strcat(cadSQL, "convert(char(1),eje.eje_digit)) as cuenta,\n ");
  strcat(cadSQL, "eje.eje_nombre,\n ");
  sprintf(cadSQL, "%s case when eje.eje_centro_c = NULL then '%d' ",cadSQL, atoi(sUnidadPadre)); 
  sprintf(cadSQL, "%s when convert(int, eje.eje_centro_c) = 0 then '%d'",cadSQL, atoi(sUnidadPadre));
  strcat(cadSQL, " else eje.eje_centro_c end eje_centro_c, \n");
  strcat(cadSQL, "ltrim(rtrim(eje.eje_num_nom)) as eje_num_nom, \n ");
  strcat(cadSQL, "eje.eje_prefijo, \n ");
  strcat(cadSQL, "eje.gpo_banco, \n ");
  strcat(cadSQL, "eje.emp_num \n ");
  strcat(cadSQL, "into #TMP2_REPORTEMA\n ");
  strcat(cadSQL, "from MTCEJE01 eje\n ");
  strcat(cadSQL, "where\n ");
  strcat(cadSQL, "eje.eje_prefijo = ");
  strcat(cadSQL, Prefijo);
  strcat(cadSQL, " and eje.gpo_banco = ");
  strcat(cadSQL, Banco);
  
  if ( Por_Grupo ) {
     strcat(cadSQL, " and eje.emp_num in ( ");
     strcat(cadSQL, Empresas );
     strcat(cadSQL, " ) ");
  } else {
  strcat(cadSQL, " and eje.emp_num = ");
  strcat(cadSQL, Empresa);
  } 
  strcat(cadSQL, " and eje.eje_num <> 0\n ");


  if (strlen(cadUnids) < 128) {
    strcat(cadSQL, " and eje.eje_centro_c in ");
    strcat(cadSQL, cadUnids);
  }
  else {
    strcat(cadSQL, " and eje.eje_centro_c != NULL ");
  }

  strcat(cadSQL, " select\n ");
  strcat(cadSQL, "distinct eje.eje_centro_c,\n ");
  strcat(cadSQL, "uni.nivel_num,\n ");
  strcat(cadSQL, "eje.cuenta,\n ");
  strcat(cadSQL, "eje.eje_nombre,\n ");
  strcat(cadSQL, "eje.eje_num_nom,\n ");
  strcat(cadSQL, "neg.b01_neg_nom_neg,\n ");
  strcat(cadSQL, "his.his_importe,\n ");
  strcat(cadSQL, "neg.b06_acd_num_acd\n ");
  strcat(cadSQL, "into TMP_REP_MERCHANTANALYSIS\n ");
  strcat(cadSQL, "from #TMP1_REPORTEMA his, #TMP2_REPORTEMA eje, MTCNEG01 neg, MTCUNI01 uni\n ");
  strcat(cadSQL, "where\n ");
  strcat(cadSQL, "neg.b01_neg_num_neg = his.b01_neg_num_neg and\n ");
  strcat(cadSQL, "substring(eje.cuenta,1,14) = substring(his.cuenta,1,14) and\n ");
  strcat(cadSQL, "eje.eje_centro_c = uni.unit_id and \n ");
  strcat(cadSQL, "eje.eje_prefijo = uni.eje_prefijo and \n ");
  strcat(cadSQL, "eje.gpo_banco = uni.gpo_banco and \n ");
  strcat(cadSQL, "eje.emp_num = uni.emp_num \n ");

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 1;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

  sprintf(cadSQL, "update TMP_REP_MERCHANTANALYSIS\n ");
  strcat(cadSQL, "set cuenta = map.map_cta_citi\n ");
  strcat(cadSQL, "from TMP_REP_MERCHANTANALYSIS tmp, MTCMAP01 map\n ");
  strcat(cadSQL, "where tmp.cuenta = map.map_cta_bnx and map.map_estatus = ' '\n ");

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 1;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

/*** CONSULTA PARA DETALLE 1 ***/

  sprintf(cadSQL, "select\n ");
  strcat(cadSQL, "distinct(neg.b06_acd_num_acd),\n ");
  strcat(cadSQL, "act.b06_acd_des_acd\n ");
  strcat(cadSQL, "from TMP_REP_MERCHANTANALYSIS neg, MTCACT01 act\n ");
  strcat(cadSQL, "where\n ");
  strcat(cadSQL, "neg.b06_acd_num_acd *= act.b06_acd_num_acd\n ");
  strcat(cadSQL, "order by neg.b06_acd_num_acd\n ");

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 2;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

/*** CONSULTA PARA DETALLE 2 ***/

  sprintf(cadSQL, " select * from TMP_REP_MERCHANTANALYSIS\n ");
  strcat(cadSQL, " order by b06_acd_num_acd, nivel_num, eje_centro_c, cuenta\n ");

  myStr2.scadena_sql = cadSQL;
  myStr2.icampos = 8;
  myStr2.lRegistros = 0;
  EjecutaSQL(&myStr2);

/*** CONSULTA PARA DETALLE 3 ***/

  sprintf(cadSQL, "select '   TOTAL PARA:  ',cuenta, '     # TRANS:', count(cuenta),\n ");
  strcat(cadSQL, "'          TOTAL:', sum(his_importe) from TMP_REP_MERCHANTANALYSIS\n ");
  strcat(cadSQL, "group by b06_acd_num_acd, nivel_num, eje_centro_c, cuenta\n ");

  myStr3.scadena_sql = cadSQL;
  myStr3.icampos = 6;
  myStr3.lRegistros = 0;
  EjecutaSQL(&myStr3);

/*** CONSULTA PARA DETALLE 4 ***/

  sprintf(cadSQL, "select '   TOTAL PARA CATEGORIA:  ', b06_acd_num_acd, '     # TRANS:',\n ");
  strcat(cadSQL, "count(b06_acd_num_acd), '          TOTAL:',\n ");
  strcat(cadSQL, "sum(his_importe) from TMP_REP_MERCHANTANALYSIS group by b06_acd_num_acd\n ");

  myStr4.scadena_sql = cadSQL;
  myStr4.icampos = 6;
  myStr4.lRegistros = 0;
  EjecutaSQL(&myStr4);

/*** CONSULTA PARA DETALLE 5 ***/

  sprintf(cadSQL, "select '   TOTAL PARA LA UNIDAD:  ");
  strcat(cadSQL, sUnidadPadre);
  strcat(cadSQL, "# TRANS:',\n ");
  strcat(cadSQL, "count(cuenta), '        TOTAL:', sum(his_importe) from TMP_REP_MERCHANTANALYSIS\n ");

  myStr5.scadena_sql = cadSQL;
  myStr5.icampos = 4;
  myStr5.lRegistros = 0;
  EjecutaSQL(&myStr5);

  if (myStr2.lRegistros != 0) {
    if ((pf = fopen(Archivo, "w")) == NULL) {
      fprintf(stdout, "Error al ejecutar fopen\n");
      return (-1);
    }
    sprintf(sCambioSIC1, "");
    sprintf(sCambioSIC2, "");
    sprintf(sCambioCta1, "");
    sprintf(sCambioCta2, "");

    RegistroPrimero(&myStr1);
    RegistroPrimero(&myStr2);
    RegistroPrimero(&myStr3);
    RegistroPrimero(&myStr4);
    RegistroPrimero(&myStr5);

    ObtenCampo(&myStr2, 2, sCambioCta2);

    sprintf(Buffer, "");
    if ( Por_Grupo )   
       pcEncabezado(Banco, Empresas, sUnidadPadre, argu[2], argu[1], "REPORTE DE NEGOCIOS POR CATEGORIA", 145, Buffer);
    else  
       pcEncabezado(Banco, Empresa, sUnidadPadre, argu[2], argu[1], "REPORTE DE NEGOCIOS POR CATEGORIA", 145, Buffer);
    fprintf(pf, "\n%s", Buffer);
    fflush(pf);

    sprintf(Buffer, "");
    pcTitulos(TitRep1, "-", 0, 6, Buffer);
    fprintf(pf, "\n %s", Buffer);
    fflush(pf);

    do {
      sprintf(sCambioSIC1, "%s", sCambioSIC2);
      sprintf(sCambioCta1, "%s", sCambioCta2);
      sprintf(sCambioSIC2, "");
      sprintf(sCambioCta2, "");
      ObtenCampo(&myStr2, 7, sCambioSIC2);
      ObtenCampo(&myStr2, 2, sCambioCta2);

      iImpreso = 0;
      if (strcmp(sCambioCta1, sCambioCta2) != 0) {
        sprintf(Buffer, "");
        pcDetalle(DetRep3, 0, 5, &myStr3, Buffer);
        rsql3 = RegistroSiguiente(&myStr3);
        fprintf(pf, " %s\n", Buffer);
        fflush(pf);
        iImpreso = 1;

	}

      if (strcmp(sCambioSIC1, sCambioSIC2) != 0) {
      if (iPrimero == 0)
          iPrimero = 1;
       else {  
          if (iImpreso == 0) {
          sprintf(Buffer, "");
          pcDetalle(DetRep3, 0, 5, &myStr3, Buffer);
          fprintf(pf, " %s\n", Buffer);
          fflush(pf);
          rsql3 = RegistroSiguiente(&myStr3);

          }

          sprintf(Buffer, "");
          pcDetalle(DetRep4, 0, 5, &myStr4, Buffer);
          fprintf(pf, "\n %s\n", Buffer);
          fflush(pf);
          rsql4 = RegistroSiguiente(&myStr4);
        }  

        sprintf(Buffer, "");
        pcTitulos(TitRep2, "-", 0, 1, Buffer);
        fprintf(pf, "\n %s", Buffer);
        fflush(pf);

        sprintf(Buffer, "");
        pcDetalle(DetRep1, 0, 1, myStr1, Buffer);
        fprintf(pf, " %s\n", Buffer);
        fflush(pf);

        rsql1 = RegistroSiguiente(&myStr1);
      }

      sprintf(Buffer, "");
      pcDetalle(DetRep2, 0, 6, &myStr2, Buffer);
      fprintf(pf, " %s", Buffer);
      fflush(pf);
      rsql2 = RegistroSiguiente(&myStr2);
    }
    while (rsql2 == 0);

    sprintf(Buffer, "");
    pcDetalle(DetRep3, 0, 5, &myStr3, Buffer);
    fprintf(pf, " %s\n", Buffer);
    fflush(pf);

    sprintf(Buffer, "");
    pcDetalle(DetRep4, 0, 5, &myStr4, Buffer);
    fprintf(pf, "\n %s\n", Buffer);
    fflush(pf);

    sprintf(Buffer, "");
    pcDetalle(DetRep5, 0, 3, myStr5, Buffer);
    fprintf(pf, "\n %s\n\n", Buffer);
    fflush(pf);

    fclose(pf);
    LiberaMemCab(&myStr1);
    LiberaMemCab(&myStr2);
    LiberaMemCab(&myStr3);
    LiberaMemCab(&myStr4);
    LiberaMemCab(&myStr5);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (0);
  } else {
    fprintf(stdout, "No existe informacion para los parametros introducidos\n");

    LiberaMemCab(&myStr1);
    LiberaMemCab(&myStr2);
    LiberaMemCab(&myStr3);
    LiberaMemCab(&myStr4);
    LiberaMemCab(&myStr5);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (1);
  }
}
