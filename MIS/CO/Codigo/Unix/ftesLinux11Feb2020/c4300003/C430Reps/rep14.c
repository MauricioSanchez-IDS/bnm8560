#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sybfront.h>
#include <sybdb.h>
#include "reportes.h" 
#include "lib_rep.h" 

int SVCREP14(totarg, argu)  
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
  int                 TOT_ARGS = 13;
  int                 Por_Grupo = 0;
  short int           iComa = 0;
  short int           iPrimero = 0;
  register short int  i;
  FILE                *pf;

/*** TITULO 1 (TITULO PRINCIPAL)***/

  static stFormatoTit TitRep1[11] = {
    {"UNIDAD", 6, 'I', " "},
    {"NIVEL", 5, 'I', " "},
    {"CUENTA", 16, 'I', " "},
    {"NOMBRE", 26, 'I', " "},
    {"NOMINA", 15, 'I', " "},
    {"TIPO FACT", 12, 'I', " "},
    {"GENERACION PLASTICO", 21, 'I', " "},
    {"TIPO BLOQUEO", 14, 'I', " "},
    {"TABLA DE BLOQUEO", 17, 'I', " "},
    {"% DISPOSICION", 15, 'I', " "},
    {"SKIP PAYMENT", 12, 'I', " "}
  };

/**** DETALLE 1 (CUENTAS) ****/

  static stFormatoDat DetRep1[11] = {
    {0, 6, 'I', " "},
    {1, 5, 'I', " "},
    {2, 16, 'I', " "},
    {3, 26, 'I', " "},
    {4, 15, 'I', " "},
    {5, 12, 'I', " "},
    {6, 21, 'I', " "},
    {7, 14, 'I', " "},
    {8, 17, 'I', " "},
    {9, 15, 'I', " "},
    {10, 12, 'I', " "}
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
  ObtenArbolUni(&myStrArb);
  
  if ( Por_Grupo ) {
   /** CONSULTA LA EMPRESA MENOR DEL GRUPO SI EL REPORTE ES GENERADO POR GRUPO **/ 
       strcpy(EmpresaMenor, "");
       sprintf(cadSQL, "select distinct emp_num from MTCUNI01 where eje_prefijo= %s and gpo_banco=%s and gpo_num = %s order by emp_num", Prefijo,Banco,Empresa);
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
       TraeUnidad(&myStrArb, &SubArb, Prefijo,Banco,EmpresaMenor, Unidad, R1, R2);
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
         TraeUnidad(&myStrArb, &SubArb, Prefijo,Banco,Empresa, Unidad, R1, R2);
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
fprintf(stdout,"REP 14 Prefijo %s %s %s %s \n %s \n",Prefijo,Banco,Empresa,Unidad,cadUnids);
/*** CONSULTA PARA DETALLE 1 ***/
  sprintf(cadSQL, " select \n");
 /* strcat(cadSQL, " a.eje_prefijo, \n");
  strcat(cadSQL, " a.gpo_banco, \n");
  strcat(cadSQL, " a.emp_num, \n");
  strcat(cadSQL, " a.eje_num, \n"); */
  sprintf(cadSQL, "%s case when c.eje_centro_c = NULL then '%d' ",cadSQL, atoi(sUnidadPadre)); 
  sprintf(cadSQL, "%s when convert(int, c.eje_centro_c) = 0 then '%d'",cadSQL, atoi(sUnidadPadre));
  strcat(cadSQL, " else c.eje_centro_c end unidad, ");
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
  strcat(cadSQL, " isnull(ltrim(rtrim(c.eje_num_nom)),' ') nomina, \n");
  strcat(cadSQL, " c.eje_tipo_fac , \n");
  strcat(cadSQL, " c.eje_gen_pin_pla, ");
  strcat(cadSQL, " c.eje_tipo_bloqueo, ");
  strcat(cadSQL, " c.eje_tabla_mcc, ");
  strcat(cadSQL, " c.eje_lim_dis_efec, ");
  strcat(cadSQL, " c.eje_skip_payment ");

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

  strcat(cadSQL, " update  #mtcths01 set cuenta=map_cta_citi \n");
  strcat(cadSQL, " from #mtcths01, MTCMAP01 \n");
  strcat(cadSQL, " where cuenta=map_cta_bnx \n");
  strcat(cadSQL, " and map_estatus = ' ' \n");

  strcat(cadSQL, " select * from #mtcths01 \n");
  myStr1.scadena_sql = cadSQL;
  myStr1.icampos = 11;
  myStr1.lRegistros = 0;
  EjecutaSQL(&myStr1);

  if (myStr1.lRegistros != 0) {

    if ((pf = fopen(Archivo, "w")) == NULL) {
      fprintf(stdout, "Error al ejecutar fopen\n");
      return (-1);
    }

    RegistroPrimero(&myStr1);
    sprintf(Buffer, "");
    if ( Por_Grupo )
       pcEncabezado(Banco, Empresas, sUnidadPadre, sFecha, sNomRep, "REPORTE DE CALIFICACION", 135, Buffer); 
    else
       pcEncabezado(Banco, Empresa, sUnidadPadre, sFecha, sNomRep, "REPORTE DE CALIFICACION", 135, Buffer); 
    fprintf(pf, "\n%s", Buffer);
    fflush(pf);
    pcTitulos(TitRep1, "-", 0, 10, Buffer);
    fprintf(pf, "\n %s", Buffer);
    fflush(pf);

    do {
      sprintf(Buffer, "");
      pcDetalle(DetRep1, 0, 10, &myStr1, Buffer);
      fprintf(pf, " %s", Buffer);
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
