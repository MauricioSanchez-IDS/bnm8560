#include <stdio.h>
#include <stdlib.h>
#include <sybfront.h>
#include <sybdb.h>
#include "reportes.h"
#include "lib_rep.h"
#include <string.h>
#define mcc1 "6011"
#define mcc2 "6010"
#define mcc3 "0000"

int SVCREP26(totarg, argu)
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
  char                Buffer[1050];
  char                *pPtr;
  char                Archivo[256];
  int                 ret;
  int                 rsql;
  int                 R1;
  int                 R2;
  int                 TOT_ARGS = 13;
  int                 Por_Grupo = 0;
  short int           iComa = 0;
  short int           iPrimero = 0;
  register short int  i;
  FILE                *pf;

/*** TITULO 1 (TITULO PRINCIPAL)***/

  static stFormatoTit TitRep1[17] = {
    {"Unidad",15, 'I', " "},
    {"Nivel", 5, 'I', " "},
    {"Numero de Cuenta", 16, 'I', " "},
    {"Nombre", 24, 'I', " "},
    {"Nomina", 15, 'I', " "},
    {"Cuenta Contable", 40, 'I', " "},
    {"Fec.Tra.", 8, 'I', " "},
    {"Fec.Pro.", 8, 'I', " "},
    {"Merchant", 26, 'I', " "},
    {"SIC", 4, 'I', " "},
    {"Monto Pesos ", 12, 'D', " "},
    {"Monto Dolar ", 12, 'D', " "},
    {"Pais", 4, 'I', " "},
    {"Cd", 3, 'I', " "},
    {"Edo",3 , 'I', " "},
    {"$", 1, 'I', " "},
    {"Tran", 4, 'I', ""}
  };

/**** DETALLE 1 (CUENTAS) ****/

  static stFormatoDat DetRep1[17] = {
    {0, 15, 'I', " "},
    {1, 5, 'I', " "},
    {2, 16, 'I', " "},
    {3, 24, 'I', " "},
    {4, 15, 'I', " "},
    {5, 40, 'I', " "},
    {6, 8, 'I', " "},
    {7, 8, 'I', " "},
    {8, 26, 'I', " "},
    {9, 4, 'I', " "},
    {10, 12, 'D', " "},
    {11, 12, 'D', " "},
    {12, 4, 'I', " "},
    {13, 3, 'I', " "},
    {14, 3, 'I', " "},
    {15, 1, 'I', " "},
    {16, 4, 'I', ""}
  };

  static ARGU argumento[13] = {
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
  fflush(stdout);
  ObtenArbolUni(&myStrArb);

  if ( Por_Grupo ) {
   /** CONSULTA LA EMPRESA MENOR DEL GRUPO SI EL REPORTE ES GENERADO POR GRUPO **/
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
fprintf(stdout,"REP 26 Prefijo %s %s %s %s \n %s \n",Prefijo,Banco,Empresa,Unidad,cadUnids);
/*** CONSULTA PARA DETALLE 1 ***/
  sprintf(cadSQL, " select \n");
  strcat(cadSQL, " a.eje_prefijo, \n");
  strcat(cadSQL, " a.gpo_banco, \n");
  strcat(cadSQL, " a.emp_num, \n");
  strcat(cadSQL, " a.eje_num, \n");
  strcat(cadSQL, " c.eje_centro_c unidad, \n");
  strcat(cadSQL, " d.nivel_num nivel, \n");
  strcat(cadSQL, " convert(char(16),convert(varchar(4),a.eje_prefijo)+convert(varchar(2),a.gpo_banco)+ \n");
  strcat(cadSQL, " replicate('0',(select pgs_long_emp from MTCPGS01 g  \n");
  strcat(cadSQL, " where g.pgs_rep_prefijo = a.eje_prefijo \n");
  strcat(cadSQL, " and g.pgs_rep_banco = a.gpo_banco) \n");
  strcat(cadSQL, " -char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num)))+ \n");
  strcat(cadSQL, " replicate('0',(select pgs_long_eje from MTCPGS01 g  \n");
  strcat(cadSQL, " where g.pgs_rep_prefijo = a.eje_prefijo \n");
  strcat(cadSQL, " and g.pgs_rep_banco = a.gpo_banco) \n");
  strcat(cadSQL, " -char_length(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num)))+ \n");
  strcat(cadSQL, " convert(varchar(1),a.eje_roll_over)+convert(varchar(1),a.eje_digit)) cuenta, \n");
  strcat(cadSQL, " substring(c.eje_nombre,1,24) nombre, \n");
  strcat(cadSQL, " isnull(ltrim(rtrim(c.eje_num_nom)),'0') nomina, \n");
  strcat(cadSQL, " isnull(c.eje_cta_contable, ' ') cta_contable, \n");
 /* strcat(cadSQL, " isnull(c.eje_pob, a.ths_direccion_3) as ciudad, ");
    strcat(cadSQL, " convert(char(2), substring(c.eje_dom_edo, 1, 2)) as estado "); comenta yuria 23 nov 2006*/
  strcat(cadSQL, " '   ' as ciudad, ");
  strcat(cadSQL, " '   ' as estado ");
  strcat(cadSQL, " into #mtcths01 \n");
  strcat(cadSQL, " from MTCTHS01 a, MTCEJE01 c, MTCUNI01 d \n");
  strcat(cadSQL, " where a.eje_prefijo= ");
  strcat(cadSQL, Prefijo);
  strcat(cadSQL, " and a.gpo_banco = ");
  strcat(cadSQL, Banco);
  if ( Por_Grupo ) {
     strcat(cadSQL, " and a.emp_num in ( ");
     strcat(cadSQL, Empresas );
     strcat(cadSQL, " ) ");
  } else {
     strcat(cadSQL, " and a.emp_num = ");
     strcat(cadSQL, Empresa);
  }
  strcat(cadSQL, " and a.eje_prefijo = c.eje_prefijo \n");
  strcat(cadSQL, " and a.gpo_banco = c.gpo_banco \n");
  strcat(cadSQL, " and a.emp_num = c.emp_num \n");
  strcat(cadSQL, " and a.eje_num = c.eje_num \n");
  strcat(cadSQL, " and d.eje_prefijo = c.eje_prefijo \n");
  strcat(cadSQL, " and d.gpo_banco = c.gpo_banco \n");
  strcat(cadSQL, " and d.emp_num = c.emp_num \n");
  strcat(cadSQL, " and d.unit_id = c.eje_centro_c \n");

  if (strlen(cadUnids) < 128) {
    strcat(cadSQL, " and c.eje_centro_c in ");
    strcat(cadSQL, cadUnids);
  }
  else {
    strcat(cadSQL, " and c.eje_centro_c != NULL ");
  }

  strcat(cadSQL, " order by a.eje_prefijo,a.gpo_banco,a.emp_num,nivel,a.eje_num \n");

/* SE COMANTA ESTA PARTE 21 de NOviembre 2006
debido  a que  el reporte original 25 siempre ha desplegado la cuenta de THS
  strcat(cadSQL, " update  #mtcths01 set cuenta=map_cta_citi \n");
  strcat(cadSQL, " from #mtcths01, MTCMAP01 \n");
  strcat(cadSQL, " where cuenta=map_cta_bnx \n");
  strcat(cadSQL, " and map_estatus = ' ' \n");*/

  strcat(cadSQL, " select \n");
  strcat(cadSQL, " d.unidad, \n");
  strcat(cadSQL, " d.nivel, \n");
  strcat(cadSQL, " d.cuenta, \n");
  strcat(cadSQL, " d.nombre, \n");
  strcat(cadSQL, " d.nomina, \n");
  strcat(cadSQL, " d.cta_contable, \n");
  strcat(cadSQL, " a.his_valor_amd fecha_valor, \n");
  strcat(cadSQL, " a.his_proceso_amd fecha_proceso, \n");
  strcat(cadSQL, " isnull(a.his_negocio_leyenda,' ') nombre_negocio, \n");
  strcat(cadSQL, " substring(right('000000'+rtrim(convert(char(6), \n");
  strcat(cadSQL, " isnull(b.b06_acd_num_acd,0))),6),3,4) mcc, \n");
  strcat(cadSQL, " str(isnull(a.his_importe,0),12,2) pesos, \n");
  strcat(cadSQL, " str(isnull(a.his_dolares,0),12,2) dolares, \n");
  strcat(cadSQL, " isnull(a.his_pais,' ') pais, \n");
  strcat(cadSQL, " d.ciudad ciudad, \n");
  strcat(cadSQL, " d.estado estado, \n");
  strcat(cadSQL, " 'M' valor_M, \n");
  strcat(cadSQL, " convert(char(4),isnull(a.his_transaccion,0)) as tra, \n");
  strcat(cadSQL, " substring(str(a.his_referencia_a,7,0),5, 1) pos_5, \n");
  strcat(cadSQL, " substring(str(a.his_referencia_a,7,0),6, 2) pos_67, \n");
  strcat(cadSQL, " a.his_referencia_a, \n");
  strcat(cadSQL, " c.signo_transaccion, \n");
  strcat(cadSQL, " isnull(b.b01_neg_num_neg,0) numero_negocio, \n");
  strcat(cadSQL, " c.tip_transaccion tip_trans \n");
  strcat(cadSQL, " into #TMP_REP_DIACYCLE \n");
  strcat(cadSQL, " from MTCHIS01 a, MTCNEG01 b, MTCTRA01 c, #mtcths01 d \n");
  strcat(cadSQL, " where a.eje_prefijo= ");
  strcat(cadSQL, Prefijo);
  strcat(cadSQL, " and a.gpo_banco= ");
  strcat(cadSQL, Banco);
  if ( Por_Grupo ) {
     strcat(cadSQL, " and a.emp_num in ( ");
     strcat(cadSQL, Empresas );
     strcat(cadSQL, " ) ");
  } else {
     strcat(cadSQL, " and a.emp_num= ");
     strcat(cadSQL, Empresa);
  }
  strcat(cadSQL, " and a.eje_prefijo=d.eje_prefijo \n");
  strcat(cadSQL, " and a.gpo_banco=d.gpo_banco \n");
  strcat(cadSQL, " and a.emp_num=d.emp_num \n");
  strcat(cadSQL, " and a.eje_num = d.eje_num \n");

  if ((atof(fechaIniAMD) != 0) && (atof(fechaFinAMD) != 0)) {
    strcat(cadSQL, " and a.his_proceso_amd between ");
    strcat(cadSQL, fechaIniAMD);
    strcat(cadSQL, " and ");
    strcat(cadSQL, fechaFinAMD);
  }

  if (atof(fechaCorteMD) != 0) {
    strcat(cadSQL, " and a.his_mes_y_ciclo_corte = ");
    strcat(cadSQL, fechaCorteMD);
  }

  strcat(cadSQL, " and a.b01_neg_num_neg *= b.b01_neg_num_neg \n");
  strcat(cadSQL, " and a.his_transaccion = c.cve_transaccion \n");
  strcat(cadSQL, " order by d.nivel,convert(float,substring(d.unidad,1,5)), d.eje_num \n");

  strcat(cadSQL, " update #TMP_REP_DIACYCLE set mcc= '");
  strcat(cadSQL, mcc1);
  strcat(cadSQL, "' where (pais='MEX' or pais='') and tip_trans='dispo' \n");

  strcat(cadSQL, " update #TMP_REP_DIACYCLE set mcc= '");
  strcat(cadSQL, mcc2);
  strcat(cadSQL, "' where \n");
  strcat(cadSQL, " ( (pais='MEX' or pais='') and tip_trans='dispo' ) and \n");
  strcat(cadSQL, " ( (pos_5 = '0') or ((pos_5 != '0') and (pos_67  = '96')) ) \n");

  strcat(cadSQL, " update #TMP_REP_DIACYCLE set mcc= '");
  strcat(cadSQL, mcc3);
  strcat(cadSQL, "' where \n");
  strcat(cadSQL, " ( (pais='MEX' or pais='') and  \n");
  strcat(cadSQL, "   (tip_trans='abono' or tip_trans='devolucion' or  \n");
  strcat(cadSQL, "    (numero_negocio = 0 and tip_trans !='dispo') ) ) \n");

  strcat(cadSQL, " update #TMP_REP_DIACYCLE set estado=pais, pais='USA' \n");
  strcat(cadSQL, " where char_length (pais) = 2 \n");
  strcat(cadSQL, " and pais <> '   ' \n");
  strcat(cadSQL, " and pais <> 'MEX' \n");

  strcat(cadSQL, " update #TMP_REP_DIACYCLE set mcc=substring(nombre_negocio,23,4) \n");
  strcat(cadSQL, " where (pais <> 'MEX' and pais <> '') \n");

  strcat(cadSQL, " update #TMP_REP_DIACYCLE set mcc= '");
  strcat(cadSQL, mcc2);
  strcat(cadSQL, "' where (pais <> 'MEX' and pais <> '') and  \n");
  strcat(cadSQL, " ( mcc = '0000' or (mcc <> '0000' and tip_trans='dispo') ) \n");

  strcat(cadSQL, " update #TMP_REP_DIACYCLE set mcc= '");
  strcat(cadSQL, mcc3);
  strcat(cadSQL, "' where (pais <> 'MEX' and pais <> '') and  \n");
  strcat(cadSQL, " (mcc <> '0000' and tip_trans='devolucion')  \n");

  strcat(cadSQL, " update  #TMP_REP_DIACYCLE  set pesos = str(convert(float,pesos) * -1,12,2),  \n");
  strcat(cadSQL, " dolares=str(convert(float,dolares) * -1,12,2) \n");
  strcat(cadSQL, " where signo_transaccion='C' \n");

  /*strcat(cadSQL, " select * from #TMP_REP_DIACYCLE \n");*/
/*fprintf(stdout,"%s",cadSQL); yuria DEBUG*/
strcat(cadSQL, " select * from #TMP_REP_DIACYCLE order by nivel,convert(float,substring(unidad,1,5)),cuenta,fecha_proceso,fecha_valor \n");

  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 23;
  myStr1.lRegistros = 0;


  EjecutaSQL(&myStr1);

  if (myStr1.lRegistros != 0) {

    if ((pf = fopen(Archivo, "w")) == NULL) {
      fprintf(stdout, "Error al ejecutar fopen\n");
      return (-1);
    }

    RegistroPrimero(&myStr1);

    sprintf(Buffer, "");
    /*pcTitulos(TitRep1,"-", 0, 16, Buffer);
    fprintf(pf, "\n %s", Buffer);comenta yuria 22 nov 2006*/
    pcTitulosOk(TitRep1,""," ", 0, 16, Buffer);
    fprintf(pf, "%s", Buffer);
    fflush(pf);

    do {
      sprintf(Buffer, "");
      /*pcDetalle(DetRep1, 0, 16, &myStr1, Buffer);
      fprintf(pf, " %s", Buffer);comenta yuria 22 nov 2006*/
      pcDetalleOk(DetRep1," ",0, 16, &myStr1, Buffer);
      if( strcmp(Buffer,"EOF") != 0)
        fprintf(pf, "%s", Buffer);
      fflush(pf);

      rsql = RegistroSiguiente(&myStr1);
    }
    while (rsql == 0);

    fclose(pf);
    LiberaMemCab(&myStr1);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (0);
  }
  else {
    fprintf(stdout, "No existe informacion para los parametros introducidos\n");

    LiberaMemCab(&myStr1);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (1);
  }
}
