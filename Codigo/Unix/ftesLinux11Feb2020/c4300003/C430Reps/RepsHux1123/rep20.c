#include <stdio.h>
#include <stdlib.h>
#include <sybfront.h>
#include <sybdb.h>
#include "reportes.h"
#include "lib_rep.h"

int SVCREP20(totarg, argu)
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
  char                fechaCorteMD[4 + 1];
  char                Archivo[256];
  char                *pPtr;
  char                Buffer[1000];
  int                 ret;
  int                 rsql1;
  int                 rsql2;
  int                 rsql3;
  int                 R1;
  int                 R2;
  int                 TOT_ARGS = 12;
  int                 Por_Grupo = 0;
  int                 Por_Tot = 0;
  short int           iComa = 0;
  short int           iPrimero = 0;
  register short int  i;
  FILE                *pf;

/*** TITULO 1 (TITULO PRINCIPAL)***/

  static stFormatoTit TitRep1[9] = {
    {"UNIDAD", 6, 'I', " "},
    {"NIVEL", 5, 'I', " "},
    {"CUENTA", 16, 'I', " "},
    {"NOMBRE", 40, 'I', " "},
    {"NOMINA", 15, 'I', " "},
    {"LIMITE DE GASTOS", 18, 'D', " "},
    {"SALDO ", 20, 'D', " "},
    {"% UTILIDAD", 16, 'D', " "},
    {"ESTATUS", 13, 'D', " "}
  };

/**** DETALLE 1 (CUENTAS) ****/

  static stFormatoDat DetRep1[9] = {
    {0, 6, 'I', " "},
    {1, 5, 'I', " "},
    {2, 16, 'I', " "},
    {3, 40, 'I', " "},
    {4, 15, 'I', " "},
    {5, 18, 'D', " "},
    {6, 20, 'D', " "},
    {7, 16, 'D', " "},
    {8, 13, 'D', " "},
  };

/**** DETALLE 2 (SUMARIZADO POR UNIDAD) ****/

  static stFormatoDat DetRep2[8] = {
    {0, 19, 'I', " "},
    {1, 5, 'I', " "},
    {2, 15, 'I', " "},
    {3, 8, 'I', " "},
    {4, 19, 'I', " "},
    {5, 8, 'I', " "},
    {6, 19, 'I', " "},
    {7, 8, 'I', " "},
  };

/**** DETALLE 2 (SUMARIZADO TOTAL) ****/

  static stFormatoDat DetRep3[6] = {
    {0, 33, 'I', " "},
    {1, 8, 'I', " "},
    {2, 19, 'I', " "},
    {3, 8, 'I', " "},
    {4, 19, 'I', " "},
    {5, 8, 'I', " "},
  };

/*** INICIA DE VALIDACION DE ARGUMENTOS  DE ENTRADA ***/

  static ARGU     argumento[12] = {
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
 
  IniciaBase();
  fflush(stdout);
  ObtenArbolUni(&myStrArb);

  if ( Por_Grupo ) {
       strcpy(EmpresaMenor, "");
       sprintf(cadSQL, "select distinct emp_num from MTCUNI01 where eje_prefijo=%s and gpo_banco=%s and gpo_num = %s order by emp_num",Prefijo,Banco,Empresa);
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
       TraeUnidad(&myStrArb, &SubArb,Prefijo,Banco,EmpresaMenor, Unidad, R1, R2);
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
fprintf(stdout,"REP 20 Prefijo %s %s %s %s \n %s \n",Prefijo,Banco,Empresa,Unidad,cadUnids);

/*** CONSULTAS ***/
  sprintf(cadSQL, "IF OBJECT_ID('dbo.TMP_REP_PRESOBREGIRO') IS NOT NULL ");
  strcat(cadSQL, "BEGIN ");
  strcat(cadSQL, "DROP TABLE dbo.TMP_REP_PRESOBREGIRO ");
  strcat(cadSQL, "PRINT '<<< DROPPED TABLE dbo.TMP_REP_PRESOBREGIRO >>>' ");
  strcat(cadSQL, "END ");

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 1;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

  sprintf(cadSQL, "select\n ");
  strcat(cadSQL, "  eje.eje_centro_c unidad, \n");
  strcat(cadSQL, "uni.nivel_num as nivel,\n ");
  strcat(cadSQL, "  convert(char(16),\n ");
  strcat(cadSQL, "  convert(char(4),ths.eje_prefijo)+\n ");
  strcat(cadSQL, "  convert(char(2),ths.gpo_banco)+\n ");
  strcat(cadSQL, "  replicate(  '0',\n ");
  strcat(cadSQL, "  ( select\n ");
  strcat(cadSQL, "  pgs_long_emp\n ");
  strcat(cadSQL, "  from\n ");
  strcat(cadSQL, "  MTCPGS01 a\n ");
  strcat(cadSQL, "  where\n ");
  strcat(cadSQL, "  a.pgs_rep_prefijo = ths.eje_prefijo and\n ");
  strcat(cadSQL, "  a.pgs_rep_banco = ths.gpo_banco)\n ");
  strcat(cadSQL, "  -char_length(ltrim(rtrim(str(ths.emp_num)))))+\n ");
  strcat(cadSQL, "  ltrim(rtrim(str(ths.emp_num)))+\n ");
  strcat(cadSQL, "  replicate(  '0',\n ");
  strcat(cadSQL, "  ( select\n ");
  strcat(cadSQL, "  pgs_long_eje\n ");
  strcat(cadSQL, "  from\n ");
  strcat(cadSQL, "  MTCPGS01 b\n ");
  strcat(cadSQL, "  where\n ");
  strcat(cadSQL, "  b.pgs_rep_prefijo = ths.eje_prefijo and\n ");
  strcat(cadSQL, "  b.pgs_rep_banco = ths.gpo_banco)\n ");
  strcat(cadSQL, "  -char_length(ltrim(rtrim(str(ths.eje_num)))))+\n ");
  strcat(cadSQL, "  ltrim(rtrim(str(ths.eje_num)))+\n ");
  strcat(cadSQL, "  convert(char(1),ths.eje_roll_over)+\n ");
  strcat(cadSQL, "  convert(char(1),ths.eje_digit)) as numero_de_la_cuenta,\n ");
  strcat(cadSQL, "  eje.eje_nombre  as nombre_de_la_cuenta,\n ");
  strcat(cadSQL, "      ltrim(rtrim(eje.eje_num_nom)) as nomina,\n ");
  strcat(cadSQL, "  ths.ths_limite_credito  as limite_de_credito,\n ");
  if ( Por_Tot ) {
      strcat(cadSQL, "  convert(numeric(12,2), tot.sdo_nvo_hih ) as saldo,\n ");
  } else { 
      /*
      strcat(cadSQL, "  convert(numeric(12,2),(hih.hih_saldo_anterior +\n ");
      strcat(cadSQL, "  hih.hih_compras_y_disp +\n ");
      strcat(cadSQL, "  hih.hih_comisiones +\n ");
      strcat(cadSQL, "  hih.hih_intereses +\n ");
      strcat(cadSQL, "  ((-1)* hih.hih_pagos_y_abonos))) as saldo,\n ");
      */
      strcat(cadSQL, "  convert(numeric(12,2), ths.ths_act_saldo) as saldo,\n ");
  }
  strcat(cadSQL, "  ths.ths_vencidos_num_total  as meses_vencidos,\n ");
  strcat(cadSQL, "  ths.ths_situacion_cta  + replicate(' ',19) as status,\n ");
  strcat(cadSQL, "  ths.ths_vencidos_pagos_por_mes1 as vencidos1,\n ");
  strcat(cadSQL, "  ths.ths_vencidos_pagos_por_mes2 as vencidos2,\n ");
  strcat(cadSQL, "  ths.ths_vencidos_pagos_por_mes3 as vencidos3,\n ");
  strcat(cadSQL, "  ths.ths_vencidos_pagos_por_mes4 as vencidos4,\n ");
  strcat(cadSQL, "  ths.ths_vencidos_pagos_por_mes5 as vencidos5,\n ");
  strcat(cadSQL, "  ths.ths_vencidos_pagos_por_mes6 as vencidos6\n ");
  strcat(cadSQL, "into #TMP1_REPORTEPP\n ");
  strcat(cadSQL, "from\n ");
  strcat(cadSQL, "  MTCTHS01  ths,\n ");
  strcat(cadSQL, "  MTCEJE01  eje,\n ");
  if ( Por_Tot )  {
     strcat(cadSQL, "  MTCUNI01  uni,\n ");
     strcat(cadSQL, "  MTCTOT01  tot\n ");
  }
  else {
     strcat(cadSQL, "  MTCUNI01  uni\n ");
  }
  strcat(cadSQL, "where\n ");
  strcat(cadSQL, "  ths.eje_prefijo = eje.eje_prefijo and\n ");
  strcat(cadSQL, "  ths.gpo_banco = eje.gpo_banco and\n ");
  strcat(cadSQL, "  ths.emp_num = eje.emp_num and\n ");
  strcat(cadSQL, "  ths.eje_num = eje.eje_num and\n ");
  if ( Por_Tot ) {
     strcat(cadSQL, "  ths.eje_prefijo = tot.eje_prefijo and\n ");
     strcat(cadSQL, "  ths.gpo_banco = tot.gpo_banco and\n ");
     strcat(cadSQL, "  ths.emp_num = tot.emp_num and\n ");
     strcat(cadSQL, "  ths.eje_num = tot.eje_num and\n ");
  } else {
     /*
     strcat(cadSQL, "  ths.eje_prefijo = hih.eje_prefijo and\n ");
     strcat(cadSQL, "  ths.gpo_banco = hih.gpo_banco and\n ");
     strcat(cadSQL, "  ths.emp_num = hih.emp_num and\n ");
     strcat(cadSQL, "  ths.eje_num = hih.eje_num and\n ");
     */
  }
  strcat(cadSQL, "  ths.eje_prefijo = ");
  strcat(cadSQL, Prefijo);
  strcat(cadSQL, "  and ths.gpo_banco = ");
  strcat(cadSQL, Banco);
 
  if ( Por_Grupo ) {
     strcat(cadSQL, " and ths.emp_num in ( ");
     strcat(cadSQL, Empresas );
     strcat(cadSQL, " ) ");
  } else {
    strcat(cadSQL, "  and ths.emp_num = ");
    strcat(cadSQL, Empresa);
  }
  if ( Por_Tot ) {
      strcat(cadSQL, "  and tot.hih_corte_md = ");
      strcat(cadSQL, fechaCorteMD);
  }
  else {
      /*
      strcat(cadSQL, "  and hih.hih_corte_md = ");
      strcat(cadSQL, fechaCorteMD);
      */
  }

  strcat(cadSQL, " and eje.eje_prefijo = uni.eje_prefijo \n ");
  strcat(cadSQL, " and eje.gpo_banco = uni.gpo_banco \n ");
  strcat(cadSQL, " and eje.emp_num = uni.emp_num \n ");
  strcat(cadSQL, " and eje.eje_centro_c = uni.unit_id\n ");

  if (strlen(cadUnids) < 128) {
    strcat(cadSQL, " and eje.eje_centro_c in ");
    strcat(cadSQL, cadUnids);
  }
  else {
    strcat(cadSQL, " and eje.eje_centro_c != NULL ");
  }

  strcat(cadSQL, " select\n ");
  strcat(cadSQL, "unidad,\n ");
  strcat(cadSQL, "nivel,\n ");
  strcat(cadSQL, "numero_de_la_cuenta,\n ");
  strcat(cadSQL, "nombre_de_la_cuenta,\n ");
  strcat(cadSQL, "nomina,\n ");
  strcat(cadSQL, "convert(money,limite_de_credito) as limite_de_credito,\n ");
  strcat(cadSQL, "convert(money,saldo) as saldo,\n ");
  strcat(cadSQL, "convert(money,0) as porc_utilidad,\n ");
  strcat(cadSQL, "status\n ");
  strcat(cadSQL, "into TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, " from #TMP1_REPORTEPP\n ");
  strcat(cadSQL, " order by nivel, unidad, numero_de_la_cuenta\n ");

  strcat(cadSQL, " update TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, " set numero_de_la_cuenta = map_cta_citi\n ");
  strcat(cadSQL, " from TMP_REP_PRESOBREGIRO, MTCMAP01\n ");
  strcat(cadSQL, " where numero_de_la_cuenta = map_cta_bnx\n ");
  strcat(cadSQL, " and map_estatus = ' '\n ");

  strcat(cadSQL, "update TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "set status = 'NORMAL'\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where status = ' '\n ");

  strcat(cadSQL, "update TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "set status = 'CANCEL CS'\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where status = 'C'\n ");

  strcat(cadSQL, "update TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "set status = 'CANCEL SS'\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where status = 'E'\n ");

  strcat(cadSQL, "update TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "set status = 'SOBREGIRO'\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where status = 'O'\n ");

  strcat(cadSQL, "update TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "set status = 'PROB COBRO'\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where status = 'P'\n ");

  strcat(cadSQL, "update TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "set status = 'ATRASADO'\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where status = 'D'\n ");

  strcat(cadSQL, "update TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "set porc_utilidad = convert(money,(saldo / limite_de_credito) * 100) \n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where limite_de_credito > 0\n ");
  
  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 1;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

/*** CONSULTA PARA DETALLE 1 ***/

  sprintf(cadSQL, " select * from TMP_REP_PRESOBREGIRO ");
  strcat(cadSQL, "order by nivel, unidad, numero_de_la_cuenta ");

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 9;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

/*** CONSULTA PARA DETALLE 2 ***/

  sprintf(cadSQL, "select distinct unidad, nivel, 0 as tot_unidad, 0 as tot_status_d, 0 as tot_status_p\n ");
  strcat(cadSQL, "into #TMP2_REPORTEPP\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, " group by nivel, unidad\n ");

  strcat(cadSQL, "select unidad, count(status) as status\n ");
  strcat(cadSQL, "into #TMP3_REPORTEPP\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where status = 'ATRASADO'\n ");
  strcat(cadSQL, "group by unidad\n ");

  strcat(cadSQL, "select unidad, count(status) as status\n ");
  strcat(cadSQL, "into #TMP4_REPORTEPP\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "where status = 'PROB COBRO'\n ");
  strcat(cadSQL, "group by unidad\n ");

  strcat(cadSQL, "select unidad, count(unidad) as tot_uni\n ");
  strcat(cadSQL, "into #TMP5_REPORTEPP\n ");
  strcat(cadSQL, "from TMP_REP_PRESOBREGIRO\n ");
  strcat(cadSQL, "group by unidad\n ");

  strcat(cadSQL, "update #TMP2_REPORTEPP\n ");
  strcat(cadSQL, "set tot_status_d = tmp3.status\n ");
  strcat(cadSQL, "from #TMP2_REPORTEPP tmp2, #TMP3_REPORTEPP tmp3 \n ");
  strcat(cadSQL, "where tmp3.unidad = tmp2.unidad\n ");

  strcat(cadSQL, "update #TMP2_REPORTEPP\n ");
  strcat(cadSQL, "set tot_status_p = tmp4.status\n ");
  strcat(cadSQL, "from #TMP2_REPORTEPP tmp2, #TMP4_REPORTEPP tmp4 \n ");
  strcat(cadSQL, "where tmp4.unidad = tmp2.unidad\n ");

  strcat(cadSQL, "update #TMP2_REPORTEPP\n ");
  strcat(cadSQL, "set tot_unidad = tmp5.tot_uni\n ");
  strcat(cadSQL, "from #TMP2_REPORTEPP tmp2, #TMP5_REPORTEPP tmp5 \n ");
  strcat(cadSQL, "where tmp5.unidad = tmp2.unidad\n ");

  strcat(cadSQL, "select 'TOTAL PARA UNIDAD:  ',unidad , '      CUENTAS:',\n ");
  strcat(cadSQL, "tot_unidad,\n ");
  strcat(cadSQL, "'     ATRASADAS:   ',\n ");
  strcat(cadSQL, "tot_status_d,\n ");
  strcat(cadSQL, "'     CANCELADAS:   ',\n ");
  strcat(cadSQL, "tot_status_p\n ");
  strcat(cadSQL, " from #TMP2_REPORTEPP\n ");
  strcat(cadSQL, " order by nivel, unidad\n ");

  myStr2.scadena_sql = cadSQL;
  myStr2.icampos = 8;
  myStr2.lRegistros = 0;
  EjecutaSQL(&myStr2);

/*** CONSULTA PARA DETALLE 3 ***/

  sprintf(cadSQL, "select 'TOTAL PARA: %s      CUENTAS:', ", sUnidadPadre);
  strcat(cadSQL, "count(unidad),\n ");
  strcat(cadSQL, "'     SUSPENDIDAS:   ',\n ");
  strcat(cadSQL, "(select count(status) from TMP_REP_PRESOBREGIRO where status = 'ATRASADO'),\n ");
  strcat(cadSQL, "'     CANCELADAS:   ',\n ");
  strcat(cadSQL, "(select count(status) from TMP_REP_PRESOBREGIRO where status = 'PROB COBRO')\n ");
  strcat(cadSQL, " from TMP_REP_PRESOBREGIRO\n ");

  myStr3.scadena_sql = cadSQL;
  myStr3.icampos = 6;
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
       pcEncabezado(Banco, Empresas, sUnidadPadre, argu[2], argu[1], "REPORTE DE ESTATUS DE CUENTAS", 160, Buffer);
    else
       pcEncabezado(Banco, Empresa, sUnidadPadre, argu[2], argu[1], "REPORTE DE ESTATUS DE CUENTAS", 160, Buffer);
    fprintf(pf, "\n%s", Buffer);
    fflush(pf);

    sprintf(Buffer, "");
    pcTitulos(TitRep1, "-", 0, 8, Buffer);
    fprintf(pf, "\n %s", Buffer);
    fflush(pf);

    do {
      sprintf(sCambioUni1, "%s", sCambioUni2);
      sprintf(sCambioUni2, "");
      ObtenCampo(&myStr1, 0, sCambioUni2);

      if (strcmp(sCambioUni1, sCambioUni2) != 0) {
        sprintf(Buffer, "");
        pcDetalle(DetRep2, 0, 7, &myStr2, Buffer);
        fprintf(pf, "\n %s\n", Buffer);
        fflush(pf);

        rsql2 = RegistroSiguiente(&myStr2);
      }

      sprintf(Buffer, "");
      pcDetalle(DetRep1, 0, 8, &myStr1, Buffer);
      fprintf(pf, " %s", Buffer);
      fflush(pf);

      rsql1 = RegistroSiguiente(&myStr1);
    }
    while (rsql1 == 0);

    sprintf(Buffer, "");
    pcDetalle(DetRep2, 0, 7, &myStr2, Buffer);
    fprintf(pf, "\n %s\n", Buffer);
    fflush(pf);

    sprintf(Buffer, "");
    pcDetalle(DetRep3, 0, 5, &myStr3, Buffer);
    fprintf(pf, "\n\n %s\n\n", Buffer);
    fflush(pf);

    fclose(pf);
    LiberaMemCab(&myStr1);
    LiberaMemCab(&myStr2);
    LiberaMemCab(&myStr3);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (0);
  }
  else {
    fprintf(stdout, "No existe informacion para los parametros introducidos\n");

    LiberaMemCab(&myStr1);
    LiberaMemCab(&myStr2);
    LiberaMemCab(&myStr3);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (1);
  }
}
