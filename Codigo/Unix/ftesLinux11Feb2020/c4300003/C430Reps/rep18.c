#include <stdio.h>
#include <stdlib.h>
#include <sybfront.h>
#include <sybdb.h>
#include "reportes.h"  
#include "lib_rep.h"
#include <string.h>

int SVCREP18(totarg, argu)
int     totarg;
char    argu[16][16];  
{
  RISQL             myStr;
  RISQL             myStr2;
  RISQL             myStr3;
  Arbol             myStrArb;
  Arbol             SubArb;
  char              cadSQL[20000];
  char              cadUnids[10000];
  char              sCadenaRetorno[PARTAMANO];
  char              sCadena[16];
  char              sNomRep[10 + 1];
  char              sFecha[10 + 1];
  char              Prefijo[4 + 1];
  char              Banco[2 + 1];
  char              Empresa[5 + 1];
  char              EmpresaMenor[5 + 1];
  char              Empresas[ 700 + 1];
  char              Unidad[5 + 1];
  char              fechaCorteMD[4 + 1];
  char              Buffer[1000];
  char              sUnidadPadre[10];
  char              *pPtr;
  char              Archivo[256];
  int               ret;
  int               rsql;
  int               rsql2;
  int               rsql3;
  int               R1;
  int               R2;
  int               iRegXHoja;
  int               iPag;
  int               iPagTotales = 1;
  int               iMod;
  int               i;
  int               TOT_ARGS = 12;
  int               Por_Grupo = 0;
  int               Por_Tot = 0;
  short int         iComa = 0;
  short int         iPrimero = 0;
  short int         iImpreso;
  FILE              *pf;

  static stFormatoTit TitRep1[9] = {
    {"UNIDAD", 7, 'I', " "},
    {"NIVEL", 7, 'D', " "},
    {"CUENTA", 20, 'C', " "},
    {"NOMBRE", 40, 'I', " "},
    {"NOMINA", 15, 'C', " "},
    {"FH EXPIRA", 10, 'C', " "},
    {"SC", 10, 'C', " "},
    {"ESTATUS", 35, 'I', " "},
    {"LIMITE", 15, 'D', " "}
  };

  static stFormatoDat DetRep1[9] = {
    {0, 7, 'D', " "},
    {1, 7, 'D', " "},
    {2, 20, 'C', " "},
    {3, 40, 'I', " "},
    {4, 15, 'I', " "},
    {5, 10, 'I', " "},
    {6, 10, 'I', " "},
    {7, 35, 'I', " "},
    {8, 15, 'D', " "}
  };

  static stFormatoDat DetRep2[2] = {
    {0, 50, 'I', " "},
    {1, 12, 'D', " "},
  };

  static stFormatoDat DetRep3[2] = {
    {0, 50, 'I', " "},
    {1, 12, 'D', " "},
  };

  static ARGU argumento[12] = {
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
    ObtenArbolUni(&myStrArb);

  if ( Por_Grupo ) {
     /** CONSULTA LA EMPRESA MENOR DEL GRUPO SI EL REPORTE ES GENERADO POR GRUPO **/
     strcpy(EmpresaMenor, "");
     sprintf(cadSQL, "select distinct emp_num from MTCUNI01 where eje_prefijo=%s and gpo_banco=%s and gpo_num = %s order by emp_num",Prefijo,Banco,Empresa);
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
fprintf(stdout,"REP 18 Prefijo %s %s %s %s \n %s \n",Prefijo,Banco,Empresa,Unidad,cadUnids);
  sprintf(cadSQL, "IF OBJECT_ID('dbo.TMP_REP_ESTATUSGRABACION ') IS NOT NULL ");
  strcat(cadSQL, "BEGIN ");
  strcat(cadSQL, "DROP TABLE dbo.TMP_REP_ESTATUSGRABACION ");
  strcat(cadSQL, "PRINT '<<< DROPPED TABLE dbo.TMP_REP_ESTATUSGRABACION >>>' ");
  strcat(cadSQL, "END ");

  myStr.scadena_sql = cadSQL;
  myStr.icampos = 1;
  myStr.lRegistros = 0;
  EjecutaSQL(&myStr);

  sprintf(cadSQL, " select \n");
  strcat(cadSQL, " eje.eje_centro_c unidad, \n");
  strcat(cadSQL, " uni.nivel_num as nivel, \n");
  strcat(cadSQL, " convert(char(16), convert(char(4), ths.eje_prefijo)+ \n");
  strcat(cadSQL, " convert(char(2),ths.gpo_banco)+ \n");
  strcat(cadSQL, " replicate('0', ( select pgs_long_emp from MTCPGS01 a \n");
  strcat(cadSQL, " where a.pgs_rep_prefijo = ths.eje_prefijo and \n");
  strcat(cadSQL, " a.pgs_rep_banco = ths.gpo_banco) \n");
  strcat(cadSQL, " -char_length(ltrim(rtrim(str(ths.emp_num)))))+ \n");
  strcat(cadSQL, " ltrim(rtrim(str(ths.emp_num)))+ \n");
  strcat(cadSQL, " replicate('0', (select pgs_long_eje from MTCPGS01 b \n");
  strcat(cadSQL, " where b.pgs_rep_prefijo = ths.eje_prefijo and \n");
  strcat(cadSQL, " b.pgs_rep_banco = ths.gpo_banco) \n");
  strcat(cadSQL, " -char_length(ltrim(rtrim(str(ths.eje_num)))))+ \n");
  strcat(cadSQL, " ltrim(rtrim(str(ths.eje_num)))+ \n");
  strcat(cadSQL, " convert(char(1),ths.eje_roll_over)+ \n");
  strcat(cadSQL, " convert(char(1),ths.eje_digit)) as cuenta, \n");
  strcat(cadSQL, " eje.eje_nombre as nombre_ejecutivo, \n");
  strcat(cadSQL, " ltrim(rtrim(eje.eje_num_nom)) as nomina, \n");
  strcat(cadSQL, "  pla.pla_vencimiento as fh_expiracion,\n ");
  strcat(cadSQL, "  ths.ths_situacion_cta  + replicate(' ',19) as sc,\n ");
  strcat(cadSQL, " replicate(' ',35) as status, \n");
  strcat(cadSQL, " str(ths.ths_limite_credito,12,0) as limite, \n");
  strcat(cadSQL, " pla.pla_reparto_ubicacion, \n");
  strcat(cadSQL, " pla.pla_reparto_referencia, \n");
  strcat(cadSQL, " pla.pla_pin, \n");
  strcat(cadSQL, " pla.pla_grabacion_causa, \n");
  strcat(cadSQL, " pla.pla_grabacion_ind, \n");
  strcat(cadSQL, " eje.eje_tipo_fac as tipo_de_facturacion, \n");
  strcat(cadSQL, " ths.eje_num \n");
  strcat(cadSQL, " into TMP_REP_ESTATUSGRABACION \n");
  if ( Por_Tot ) 
	strcat(cadSQL, " from MTCTHS01 ths, MTCEJE01 eje, MTCTOT01 tot ,MTCUNI01 uni, MTCPLA01 pla \n");
  else
	strcat(cadSQL, " from MTCTHS01 ths, MTCEJE01 eje, MTCUNI01 uni, MTCPLA01 pla \n");
  strcat(cadSQL, " where eje.eje_prefijo = ");
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
  
  if (strlen(cadUnids) < 128) {
    strcat(cadSQL, " and eje.eje_centro_c in ");
    strcat(cadSQL, cadUnids);
  }
  else {
    strcat(cadSQL, " and eje.eje_centro_c != NULL ");
  }

  strcat(cadSQL, " and eje.eje_prefijo = ths.eje_prefijo \n");
  strcat(cadSQL, " and eje.gpo_banco = ths.gpo_banco \n");
  strcat(cadSQL, " and eje.emp_num  = ths.emp_num \n");
  strcat(cadSQL, " and eje.eje_num  = ths.eje_num \n");

  strcat(cadSQL, " and eje.eje_prefijo = uni.eje_prefijo  \n");
  strcat(cadSQL, " and eje.gpo_banco = uni.gpo_banco  \n");
  strcat(cadSQL, " and eje.emp_num = uni.emp_num  \n");
  strcat(cadSQL, " and eje.eje_centro_c = uni.unit_id \n");

  strcat(cadSQL, " and eje.eje_prefijo = pla.eje_prefijo \n");
  strcat(cadSQL, " and eje.gpo_banco = pla.gpo_banco \n");
  strcat(cadSQL, " and eje.emp_num  = pla.emp_num \n");
  strcat(cadSQL, " and eje.eje_num  = pla.eje_num \n");
  strcat(cadSQL, " and ths.eje_prefijo = pla.eje_prefijo \n");
  strcat(cadSQL, " and ths.gpo_banco = pla.gpo_banco \n");
  strcat(cadSQL, " and ths.emp_num  = pla.emp_num \n");
  strcat(cadSQL, " and ths.eje_num  = pla.eje_num \n");
  strcat(cadSQL, " and ths.eje_roll_over  = pla.eje_roll_over \n");
  strcat(cadSQL, " order by nivel, unidad, cuenta \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'ACUSE RECIBIDO' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'A' \n");
  strcat(cadSQL, " and convert(int,substring(str(pla_reparto_referencia),1,2)) <> 99 \n");
  strcat(cadSQL, " and convert(int,substring(str(pla_reparto_referencia),1,2)) <> 98 \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'PLASTICO RECIBIDO' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'A' \n");
  strcat(cadSQL, " and (convert(int,substring(str(pla_reparto_referencia),1,2)) = 99 \n");
  strcat(cadSQL, " or convert(int,substring(str(pla_reparto_referencia),1,2)) = 98) \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'PLASTICO EN BOVEDA' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'B' \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'ENVIO ESPECIAL' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'E' \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'MENSAJERIA ESPECIAL' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'M' \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'ENTREGADO Y ACTIVO' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'S' \n");
  strcat(cadSQL, " and pla_pin = 0 \n");
  strcat(cadSQL, " and pla_grabacion_causa in ('A','B','E','L','N') \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'ENTREGA NO CONFIRMADA' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'S' \n");
  strcat(cadSQL, " and pla_pin = 0 \n");
  strcat(cadSQL, " and pla_grabacion_causa in ('W','C','Y','T','Z') \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'NO SE GRABO, ERROR EN DATOS' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'W' \n");
  strcat(cadSQL, " and pla_grabacion_causa in ('D','Z') \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'NO LLEGO A GRABACION' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'W' \n");
  strcat(cadSQL, " and pla_grabacion_ind >= 50 \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'SE GRABO, ENTREGA NO CONFIRMADA' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'W' \n");
  strcat(cadSQL, " and pla_grabacion_causa not in ('D','Z') \n");
  strcat(cadSQL, " and pla_grabacion_ind < 50 \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'ASIGNADO A MENSAJERIA' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where pla_reparto_ubicacion = 'R' \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'STATUS NO PARAMETRIZADO' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where status = ' ' \n");

  strcat(cadSQL, " update TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " set status = 'NO GENERA PLASTICO' \n");
  strcat(cadSQL, " from TMP_REP_ESTATUSGRABACION \n");
  strcat(cadSQL, " where eje_num = 0 \n");

  strcat(cadSQL, "update TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "set sc = 'NORMAL'\n ");
  strcat(cadSQL, "from TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "where sc = ' '\n ");

  strcat(cadSQL, "update TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "set sc = 'CANCEL CS'\n ");
  strcat(cadSQL, "from TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "where sc = 'C'\n ");

  strcat(cadSQL, "update TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "set sc = 'CANCEL SS'\n ");
  strcat(cadSQL, "from TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "where sc = 'E'\n ");

  strcat(cadSQL, "update TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "set sc = 'SOBREGIRO'\n ");
  strcat(cadSQL, "from TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "where sc = 'O'\n ");

  strcat(cadSQL, "update TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "set sc = 'PROB COBRO'\n ");
  strcat(cadSQL, "from TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "where sc = 'P'\n ");

  strcat(cadSQL, "update TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "set sc = 'ATRASADO'\n ");
  strcat(cadSQL, "from TMP_REP_ESTATUSGRABACION\n ");
  strcat(cadSQL, "where sc = 'D'\n ");

  strcat(cadSQL, "update TMP_REP_ESTATUSGRABACION ");
  strcat(cadSQL, "set cuenta = map.map_cta_citi ");
  strcat(cadSQL, "from TMP_REP_ESTATUSGRABACION tmp, MTCMAP01 map ");
  strcat(cadSQL, "where tmp.cuenta = map.map_cta_bnx and map.map_estatus = ' ' ");

  strcat(cadSQL, " select * from TMP_REP_ESTATUSGRABACION ");
  strcat(cadSQL, " order by nivel, unidad, cuenta \n");
  
  myStr.scadena_sql = cadSQL;
  myStr.icampos = 15;
  myStr.lRegistros = 0;
  EjecutaSQL(&myStr);

  sprintf(cadSQL, " select '      ' + status + ': ', count(status) from TMP_REP_ESTATUSGRABACION ");
  strcat(cadSQL, " group by status ");

  myStr2.scadena_sql = cadSQL;
  myStr2.icampos = 2;
  myStr2.lRegistros = 0;
  EjecutaSQL(&myStr2);

  sprintf(cadSQL, " select '      TOTAL DE CUENTAS: ', count(status) from TMP_REP_ESTATUSGRABACION ");

  myStr3.scadena_sql = cadSQL;
  myStr3.icampos = 2;
  myStr3.lRegistros = 0;
  EjecutaSQL(&myStr3);

  if (myStr.lRegistros != 0) {
    if ((pf = fopen(Archivo, "w")) == NULL) {
      fprintf(stdout, "Error al ejecutar fopen\n");
      return (-1);
    }

    RegistroPrimero(&myStr);
    RegistroPrimero(&myStr2);
    RegistroPrimero(&myStr3);

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
      pcEncabezado(Banco, Empresas, sUnidadPadre, sFecha, sNomRep, "ESTATUS GRABACION DE PLASTICO", 135, Buffer);
    else
      pcEncabezado(Banco, Empresa, sUnidadPadre, sFecha, sNomRep, "ESTATUS GRABACION DE PLASTICO", 135, Buffer);
    fprintf(pf, "\n%s", Buffer);
    fflush(pf);
    sprintf(Buffer, "%s", "");
    pcTitulos(TitRep1, "-", 0, 8, Buffer);
    fprintf(pf, "\n %s", Buffer);
    fflush(pf);

    do {
      if (iRegXHoja == 50) {
        sprintf(Buffer, "%s", "");
        pcPiedePagina(iPag, iPagTotales, 135, 'C', Buffer);

        /* fprintf(pf, "\n%s\f ", Buffer); */
        fprintf(pf, "\n%s ", Buffer); 

        fflush(pf);

        sprintf(Buffer, "%s", "");
        if ( Por_Grupo )
           pcEncabezado(Banco, Empresas, sUnidadPadre, sFecha, sNomRep, "ESTATUS GRABACION DE PLASTICO", 135, Buffer);
        else
           pcEncabezado(Banco, Empresa, sUnidadPadre, sFecha, sNomRep, "ESTATUS GRABACION DE PLASTICO", 135, Buffer);
        fprintf(pf, "\n%s", Buffer);
        fflush(pf);

        sprintf(Buffer, "%s", "");
        pcTitulos(TitRep1, "-", 0, 8, Buffer);
        fprintf(pf, "\n %s", Buffer);
        fflush(pf);

        iPag++;
        iRegXHoja = 0;
      }

      sprintf(Buffer, "%s", "");
      pcDetalle(DetRep1, 0, 8, &myStr, Buffer);
      fprintf(pf, " %s", Buffer);
      fflush(pf);

      iRegXHoja++;
      rsql = RegistroSiguiente(&myStr);
    }
    while (rsql == 0);

    do {
      sprintf(Buffer, "%s", "");
      pcDetalle(DetRep2, 0, 1, &myStr2, Buffer);
      fprintf(pf, "%s", Buffer);
      fflush(pf);

      rsql2 = RegistroSiguiente(&myStr2);
    }
    while (rsql2 == 0);

    sprintf(Buffer, "%s", "");
    pcDetalle(DetRep3, 0, 1, &myStr3, Buffer);
    fprintf(pf, "\n%s", Buffer);
    fflush(pf);

    sprintf(Buffer, "%s", "");
    pcPiedePagina(iPag, iPagTotales, 135, 'C', Buffer);

    /* fprintf(pf, "\n%s\f ", Buffer); */
    fprintf(pf, "\n%s ", Buffer);

    fflush(pf);

    fclose(pf);
    LiberaMemCab(&myStr);
    LiberaMemCab(&myStr2);
    LiberaMemCab(&myStr3);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (0);
  }
  else {
    fprintf(stdout, "No existe informacion para los parametros introducidos\n");
    LiberaMemCab(&myStr);
    LiberaMemCab(&myStr2);
    LiberaMemCab(&myStr3);
    LiberaMemArb(&myStrArb);
    Desconecta();
    return (1);
  }
}
