/*
** Nombre:  creaDerSBF.c (consumos.c)
** Autor:   Ing. Jose Ramon Gonzalez Diaz
** Cia:     EISSA
** Fecha:   31/MAY/2002
** Funcion: Genera archivo de reporte Consumos, tomando en cuenta
**          las empresas que estan calificadas en el campo
**          emp_gen_SBF = 1 o 3 o 4 y que contengan asignada su
**          unidad
**
** Historico:
**
**1.-18/jun/2002
**          Se modifica el formato del campo importe y saldos tenian
**          como separador  "," y cambia por el "."
**
**2.-18/jun/2002
**          Se cambia de posicion el saldo anterior y saldo nuevo en la
**          grabacion del archivo.
**
**3.-18/jun/2002
**          Se modifico el nombre del ejecutivo se tomaba de ths_nombre
**          ahora se toma de eje_nombre
**
**8.-18/jun/2002
**          Se elimina el saldo anterior de la facturacion corporativa
**          a nivel de ejecutivo.
**
**9.-20/jun/2002
**          Se adiciona el filtro de numero de empresa al query que
**          selecciona a las empresas a procesar, la razon es que se
**          pueda procesar una sola empresa.
**
**10.-20/jun/2002
**          Se adiciona en las validaciones del resultado DBROWS la validacion
**          DBROWS() == NO_MORE_ROWS
**
**11.-20/jun/2002
**          Se adiciona en la validacion del
**          while (atol(num_cuentasal) < atol(num_cuentaant)
**          la validacion de
**          && fin_hih != _NO_MORE_ROWS
**
**12.-21/jun/2002
**          Se modifica el nombre del reporte que genera este programa
**          era rpt014.txt ahora queda como rpt012.txt
**
**13.-24/jun/2002
**          Se adiciona la columna de fecha_valor al reporte que se genera.
**
**14.-24/jun/2002
**          Se adiciona al query de empresa el valor de 4 al filtro del
**          query.
**
**15.-02/jul/2002
**          Se adiciona a la consulta de MTCEMP01 y MTCUNI01 el campo
**          de nivel_num para visualizarlo en el reporte.
**
**16.-02/jul/2002
**          Se adiciona a la consulta de MTCEJE01 el campo eje_cta_contable
**          para visualizarlo en el reporte
**
**17.-08/ene/2003
**          Se adicionan los parametros prefijo, banco para procesar una empresa
**          de foma manual.
**
**18.-21/ene/2003
**          Se adiciona validacion del mes si es mes 1 se debera tomar tambien
**          el anio anterior con el anio actual
**
**19.-25/Oct/2006
**          Se sustituye la rutina de obtención del MCC ya que estaba incorrecta
**          Corregido por : Angel Pérez Quintanar de SAS
*/

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
/* #include "../include/sybdbex.h" jrgd 08/ene/2003 */

/* parametros prefijo, banco,empresa,mes_corte,anio */

/* #define		TOTALPARAMETROS 4  jrgd 08/ene/2003 */
#define		TOTALPARAMETROS 6 /* jrgd 08/ene/2003 */
#define		LONGCADENALARGA	500
#define     SQLBUFLEN       10000 /* jrgd 08/ene/2003 */
#define     ERR_CH          stderr /* jrgd 08/ene/2003 */


/*varibles globales  para el manejo de los argumentos de fecha proceso y nombre
del archivo a generar*/
char fechayhora[20];
char nombrearchivo[60];
char sqlcmd[SQLBUFLEN];

/* declaraciones para el tratamiento de errores */
int		CS_PUBLIC   err_handler();
int		CS_PUBLIC   msg_handler();
int		i;

main(argc, argv)
int             argc;
char            *argv[];
{
 FILE *archivo;

DBPROCESS	*q_dbproc_emp;
DBPROCESS	*q_dbproc_thsmap;
DBPROCESS	*q_dbproc_hisneg;
DBPROCESS	*q_dbproc_hih;
DBPROCESS	*q_dbproc; 
LOGINREC    *login;        /* Our login information. */
RETCODE		return_code;

time_t	lcl_time;
struct	tm *today;

/*  variables para ambiente */
char ge_user[10];
char ge_password[10];
char ge_server[10];
char ge_hostname[10];
char ge_dbase[10];
char dir_deposito[200];

/* variables de proceso */
char num_cuenta     [16+1];
char num_cuenta1    [20+1];
char num_cuenta11   [16+1];
char num_cuentasal  [16+1];
char num_cuentaant  [16+1];
char cuenta         [16+1];
char car            [1+1];
int  cont;
char eje_nombre     [45+1];
char importec       [12+1];
char dolaresc       [12+1];
char salnvoc        [12+1];
char salantc        [12+1];
char salantcc       [12+1];
char estado         [3+1];
char ciudad         [3+1];
char pos5           [1+1];
char pos6y7         [2+1];
int  flag;
char encabezado     [LONGCADENALARGA+1];
char detalle        [LONGCADENALARGA+1];
char saldos         [LONGCADENALARGA+1];
int ciclo_corte;
int mes;
int anio;
int anioant; /* jrgd 21/ene/2003 */
int anioact; /* jrgd 21/ene/2003 */
char anioproc[10]; /* jrgd 21/ene/2003 */
int pre; /* jrgd 08/ene/2003 */
int ban; /* jrgd 08/ene/2003 */
int emp;
int fin_thsmap;
int fin_hisneg;
int fin_hih;
int fin_emp;
char nomarch        [25+1];
char nomarchpro     [20+1];
char directorio     [60+1];
char dirarch        [150+1];
int sigue;
char creacarpeta    [200+1];
int primervez;
char fechaArch      [8+1];
char unidad         [5+1];
int j;
int es_num;

/* variables db para almacenar datos de los queries */
DBCHAR             eje_num[6];
DBCHAR             eje_pre1[5+1];
DBCHAR             emp_num1[6];
DBCHAR             eje_num1[6];
DBCHAR             roll_over1[1+1];
DBCHAR             eje_digit1[1+1];
DBCHAR             gpo_banco1[2+1];
DBCHAR             fecha[8+1];
DBCHAR             fechaval[8+1];
DBCHAR             importe[12+1];
DBCHAR             dolares[12+1];
DBCHAR             saldo_ant[12+1];
DBCHAR             saldo_nvo[12+1];
DBCHAR             roll_over[1+1];
DBCHAR             eje_digit[1+1];
DBCHAR             thsnombre[24+1];
DBCHAR             nom_neg[26+1];
DBCHAR             num_neg[10+1];
DBCHAR             MCC[4+1];
DBCHAR             ref_a[4+1];
DBCHAR             pais[3+1];
DBCHAR             tipo_reg[1+1];
DBCHAR             estatus[1+1];
DBCHAR             limcred1[12+1];
DBCHAR             eje_numsal[6];
DBCHAR             cuenta_citi    [16+1];
DBCHAR             cuenta_banamex [16+1];
DBCHAR             prefijo[4+1];
DBCHAR             banco[2+1];
DBCHAR             empresa[5+1];
DBCHAR             dia_corte[2+1];
DBCHAR             sbf[1+1];
DBCHAR             tipo_fac[1+1];
DBCHAR             eje_num_nom[15+1];
DBCHAR             eje_centro_c[15+1];
DBCHAR             signo_tra[1+1];
DBCHAR             unit[5+1];
DBCHAR             cta_contable[40+1];
DBCHAR             unit_level[5+1];
DBCHAR             tip_transac[15+1];

/* variables globales para el manejo de los argumentos de fecha proceso y nombre del archivo a generar  */
  extern char fechayhora[20];
  extern char nombrearchivo[60];
  extern char sqlcmd[SQLBUFLEN];

fflush(stdout);

/* Valida los parametros  */
  if ((argc > TOTALPARAMETROS) || (argc < TOTALPARAMETROS))
    {
     printf("Programa: creaDerSBF.c \n");
     printf("El numero de argumentos no son validos para el programa creaDerSBF.c\n");
     exit(1);
    }

/*obtiene fecha y hora del proceso */
time(&lcl_time);
today = localtime(&lcl_time);
strftime(fechayhora,20,"%m/%d/%Y %T",today);
strftime(fechaArch,9,"%Y%m%d",today);
printf("Hora inicio proceso generar archivo creaDerSBF(rpt012.TXT): %s \n",fechayhora);

/* variables globales para el manejo de los argumentos
nombre del archivo CDF a generar y el rango de fechas de los movimientos*/
strcpy(nombrearchivo,argv[0]);
pre=atoi(argv[1]);
ban=atoi(argv[2]);
emp=atoi(argv[3]);
mes=atoi(argv[4]);
anio=atoi(argv[5]);

/* if ( mes == 1 )  jrgd 21/ene/2003
  {
   anioant = anio-1;
   anioact = anio;
   sprintf(anioproc,"%d,%d",anioant,anioact);
   anioproc[9]="\0";
  }
else
  {
   sprintf(anioproc,"%d",anio);
   anioproc[4]="\0";
  } */

if (dbinit() == FAIL)
{
  /* registro del error en el archivo log */
  printf("Fecha proceso:%s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: creaDerSBF.c \n");
  printf("Error: No se inicializaron dblibrary de C en el prog creaDerSBF.c\n");
  dbexit();
  exit(1);
}

dberrhandle((EHANDLEFUNC)err_handler);
dbmsghandle((MHANDLEFUNC)msg_handler);

dbsetversion(DBVERSION_100);

sprintf(ge_user,"%s",getenv("GE_USER"));
sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
sprintf(ge_server,"%s",getenv("GE_SERVER"));
sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));
sprintf(ge_dbase,"%s",getenv("GE_DBASE"));
sprintf(dir_deposito,"%s",getenv("DIR_ARCH"));

if ( ( (strlen(ge_user) == 0) || (strlen(ge_password) == 0) || (strlen(ge_server) == 0) || (strlen(ge_hostname) == 0) || (strlen(ge_dbase) == 0) || (strlen(dir_deposito) == 0)  ) )
{
 printf("Fecha proceso: %s\n", fechayhora);
 printf("Nombre archivo: %s\n", nombrearchivo);
 printf("%s\n; %s\n; %s\n; %s\n; %s\n",ge_user, ge_password,ge_server,ge_hostname,ge_dbase );
 printf("Programa: creaDerSBF.c \n");
 printf("Error: debe verificar las variables de ambiente\n");
 exit(1);
}

 /* damos informacion del login */
 login = dblogin();
 DBSETLUSER(login, ge_user);
 DBSETLPWD(login, ge_password);
 DBSETLAPP(login, ge_hostname);
 DBSETLHOST(login, ge_hostname);
 DBSETLCHARSET(login,"roman8");
 DBSETLENCRYPT(login, TRUE);

 q_dbproc_emp = dbopen(login, ge_server);
 q_dbproc_thsmap = dbopen(login, ge_server);
 q_dbproc_hisneg = dbopen(login, ge_server);
 q_dbproc_hih = dbopen(login, ge_server);
 q_dbproc = dbopen(login, ge_server);

 dbuse(q_dbproc_emp, ge_dbase);
 dbuse(q_dbproc_thsmap, ge_dbase);
 dbuse(q_dbproc_hisneg, ge_dbase);
 dbuse(q_dbproc_hih, ge_dbase);
 dbuse(q_dbproc, ge_dbase);

 sigue=0;

 /* consulta a la tabla MTCEMP01 y a la tabla MTCUNI01 */
 sprintf(sqlcmd,"select right('0000'+convert(char(4),a.eje_prefijo),4) pref,\n");
 strcat(sqlcmd,"right('00'+convert(char(2),a.gpo_banco),2) banco,\n");
 strcat(sqlcmd,"replicate('0',(select pgs_long_emp from MTCPGS01 i \n");
 strcat(sqlcmd,"where i.pgs_rep_prefijo = a.eje_prefijo \n");
 strcat(sqlcmd,"and i.pgs_rep_banco = a.gpo_banco)-char_length(ltrim(rtrim( \n");
 strcat(sqlcmd,"str(a.emp_num)))))+ ltrim(rtrim(str(a.emp_num))) empresa,\n ");
 strcat(sqlcmd,"isnull(convert(char(2),a.emp_dia_corte),'00') diacorte,\n ");
 strcat(sqlcmd,"right('0'+convert(char(1),a.emp_gen_SBF),1) sbf,\n ");
 strcat(sqlcmd,"right('0'+convert(char(1),a.emp_tipo_fac),1) tipo_fac, \n ");
 strcat(sqlcmd,"rtrim(unit_id) unidad, \n");
 strcat(sqlcmd,"isnull(convert(varchar(5),b.nivel_num),' ') unit_level \n");
 strcat(sqlcmd,"from MTCEMP01 a, MTCUNI01 b \n ");
 strcat(sqlcmd,"where \n");
 if( pre != 0 && ban != 0 ) /* Se adiciona validacion para parametrizacion */
 {
  strcat(sqlcmd," a.eje_prefijo=");
  sprintf(sqlcmd,"%s %d \n",sqlcmd,pre);
  strcat(sqlcmd,"and a.gpo_banco =");
  sprintf(sqlcmd,"%s %d \n",sqlcmd,ban);
  /* Se incluye para selecciona una sola empresa */
  if( emp != 0 )
  {
   strcat(sqlcmd,"and a.emp_num =");
   sprintf(sqlcmd,"%s %d \n",sqlcmd,emp);
  }
  strcat(sqlcmd," and ");
 }
 strcat(sqlcmd,"a.emp_gen_SBF in (1,3,4) \n ");
 strcat(sqlcmd,"and a.eje_prefijo=b.eje_prefijo \n ");
 strcat(sqlcmd,"and a.gpo_banco=b.gpo_banco \n ");
 strcat(sqlcmd,"and a.emp_num=b.emp_num \n ");
 strcat(sqlcmd,"and b.unit_parent_id=null \n ");
 strcat(sqlcmd,"and b.nivel_num=1 \n ");
 strcat(sqlcmd,"order by a.eje_prefijo, a.gpo_banco, a.emp_num \n");

dbcmd(q_dbproc_emp, sqlcmd);
/* printf("SQL='%s'\n", sqlcmd); */
if(dbsqlexec(q_dbproc_emp) == FAIL)
 {
  printf("Fecha proceso:%s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: creaDerSBF.c \n");
  printf("Error: Fallo al intentar traer datos de MTCEMP01 bdsqlexec,%s \n",sqlcmd);
  dbclose(q_dbproc_emp);
  dbexit();
  exit(1);
 }

dbresults(q_dbproc_emp);

if(DBROWS(q_dbproc_emp) != SUCCEED)
 {
  printf("Fecha proceso:%s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: creaDerSBF.c \n");
  printf("No existen datos de MTCEMP01 DBROWS\n");
  dbclose(q_dbproc_emp);
  dbexit();
  exit(1);
 }
dbbind(q_dbproc_emp,1,STRINGBIND,(DBINT)0,(BYTE DBFAR *)prefijo);
dbbind(q_dbproc_emp,2,STRINGBIND,(DBINT)0,(BYTE DBFAR *)banco);
dbbind(q_dbproc_emp,3,STRINGBIND,(DBINT)0,(BYTE DBFAR *)empresa);
dbbind(q_dbproc_emp,4,STRINGBIND,(DBINT)0,(BYTE DBFAR *)dia_corte);
dbbind(q_dbproc_emp,5,STRINGBIND,(DBINT)0,(BYTE DBFAR *)sbf);
dbbind(q_dbproc_emp,6,STRINGBIND,(DBINT)0,(BYTE DBFAR *)tipo_fac);
dbbind(q_dbproc_emp,7,STRINGBIND,(DBINT)0,(BYTE DBFAR *)unit);
dbbind(q_dbproc_emp,8,STRINGBIND,(DBINT)0,(BYTE DBFAR *)unit_level);
fin_emp=dbnextrow(q_dbproc_emp);
/* puts("T0"); */

while (fin_emp != NO_MORE_ROWS)
{
 printf("Procesando la empresa\n");
 printf("prefijo: %s\n",prefijo);
 printf("banco: %s\n",banco);
 printf("empresa: %s\n",empresa);
 printf("dia_corte: %s\n",dia_corte);
 printf("sbf: %s\n",sbf);
 printf("tipo_fac: %s\n",tipo_fac);
 printf(" \n");
 /* getchar(); */
/* puts("T1"); */

 if (unit == NULL)
   {
    strcpy(unidad,"00000");
   }
 else
   {
/*    sprintf(unidad,"%05s",unit);  */
      int iunit = atoi(unit);
      sprintf(unidad,"%05d",iunit);
   }
/* puts("T2"); */

 /* Facturacion Individual */
 if (strcmp(tipo_fac,"I") == 0)
  {
   /* printf("Entro al proceso de Facturacion Individual\n");
   getchar(); */
   ciclo_corte = (mes * 100) + atoi(dia_corte);

   /* Consulta a MTCTHS01 Y MTCMAP01 */
   sprintf(sqlcmd,"select a.eje_prefijo,a.gpo_banco, \n");
   strcat(sqlcmd,"replicate('0',(select pgs_long_emp from MTCPGS01 g where g.pgs_rep_prefijo = a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco)-char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num))),\n");
   strcat(sqlcmd,"replicate('0',(select pgs_long_eje from MTCPGS01 g where g.pgs_rep_prefijo = a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco)-char_length(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num))),\n");
   strcat(sqlcmd,"a.eje_roll_over,a.eje_digit,\n");
   strcat(sqlcmd, "isnull(str(a.ths_limite_credito,12,0),\n");
   strcat(sqlcmd, "'000000000000') limiteCredito, \n");
   strcat(sqlcmd,"substring(c.eje_nombre,1,24) nombre,\n");
   strcat(sqlcmd,"isnull(b.map_cta_bnx,' ') cta_banamex, \n");
   strcat(sqlcmd,"isnull(b.map_cta_citi,' ') cta_citi, \n");
   strcat(sqlcmd,"isnull(b.map_estatus,' ') estatus, \n");
   strcat(sqlcmd,"isnull(c.eje_num_nom,' ') nomina, \n");
   strcat(sqlcmd,"isnull(c.eje_centro_c,' ') eje_centro, \n");
   strcat(sqlcmd,"isnull(c.eje_cta_contable, ' ') cta_contable \n");
   strcat(sqlcmd,"from MTCTHS01 a, MTCMAP01 b, MTCEJE01 c \n");
   strcat(sqlcmd,"where right('0000'+convert(char(4),a.eje_prefijo),4) \n");
   strcat(sqlcmd,"+right('00'+convert(char(2),a.gpo_banco),2) \n");
   strcat(sqlcmd,"+replicate('0',(select pgs_long_emp from \n");
   strcat(sqlcmd,"MTCPGS01 i where i.pgs_rep_prefijo = \n");
   strcat(sqlcmd,"a.eje_prefijo and i.pgs_rep_banco = \n");
   strcat(sqlcmd,"a.gpo_banco)-char_length(ltrim(rtrim(str( \n");
   strcat(sqlcmd,"a.emp_num)))))+\n");
   strcat(sqlcmd,"ltrim(rtrim(str(a.emp_num)))+\n");
   strcat(sqlcmd,"replicate('0',(select pgs_long_eje \n");
   strcat(sqlcmd,"from MTCPGS01 g where g.pgs_rep_prefijo = \n");
   strcat(sqlcmd,"a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco)\n");
   strcat(sqlcmd,"-char_length(ltrim(rtrim(str(a.eje_num)))))+\n");
   strcat(sqlcmd,"ltrim(rtrim(str(a.eje_num)))+\n");
   strcat(sqlcmd,"right('0'+convert(char(1),a.eje_roll_over),1)+\n");
   strcat(sqlcmd,"right('0'+convert(char(1),a.eje_digit),1) \n");
   strcat(sqlcmd,"*= b.map_cta_bnx \n");
   strcat(sqlcmd,"and  a.eje_prefijo=");
   sprintf(sqlcmd,"%s %s\n%",sqlcmd,prefijo);
   strcat(sqlcmd,"and a.gpo_banco=");
   sprintf(sqlcmd,"%s %s\n",sqlcmd,banco);
   strcat(sqlcmd,"and a.emp_num=");
   sprintf(sqlcmd,"%s %s\n",sqlcmd,empresa);
   strcat(sqlcmd,"and  a.eje_prefijo *= c.eje_prefijo \n");
   strcat(sqlcmd,"and a.gpo_banco *= c.gpo_banco \n");
   strcat(sqlcmd,"and a.emp_num *= c.emp_num \n");
   strcat(sqlcmd,"and a.eje_num *= c.eje_num \n");
   strcat(sqlcmd,"order by a.eje_prefijo,a.gpo_banco,\n");
   strcat(sqlcmd,"a.emp_num,a.eje_num, estatus \n");
/*    printf("SQL_1='%s'", sqlcmd); */
   dbcmd(q_dbproc_thsmap, sqlcmd);
   if (dbsqlexec(q_dbproc_thsmap) == FAIL)
     {
      printf("Fecha proceso:%s\n", fechayhora);
      printf("Nombre archivo: %s\n", nombrearchivo);
      printf("Programa: creaDerSBF.c \n");
      printf("Error: Fallo al intentar traer datos de MTCTHS01,MTCMAP01 bdsqlexec,%s \n", sqlcmd);
      /* dbclose(q_dbproc_thsmap);
      dbexit();
      exit(1); */
      sigue=1;
     }
/*    puts("T6"); */

   dbresults(q_dbproc_thsmap);

   if (DBROWS(q_dbproc_thsmap) != SUCCEED && DBROWS(q_dbproc_thsmap) == NO_MORE_ROWS)
     {
      printf("Fecha proceso:%s\n", fechayhora);
      printf("Nombre archivo: %s\n", nombrearchivo);
      printf("Programa: creaDerSBF.c \n");
      printf("No existen datos de MTCTHS01,MTCMAP01 DBROWS\n");
      /* dbclose(q_dbproc_thsmap);
      dbexit(); */
      sigue=1;
     }
   else
     {
      dbbind(q_dbproc_thsmap,1,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_pre1);
      dbbind(q_dbproc_thsmap,2,STRINGBIND,(DBINT)0,(BYTE DBFAR *)gpo_banco1);
      dbbind(q_dbproc_thsmap,3,STRINGBIND,(DBINT)0,(BYTE DBFAR *)emp_num1);
      dbbind(q_dbproc_thsmap,4,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_num1);
      dbbind(q_dbproc_thsmap,5,STRINGBIND,(DBINT)0,(BYTE DBFAR *)roll_over1);
      dbbind(q_dbproc_thsmap,6,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_digit1);
      dbbind(q_dbproc_thsmap,7,STRINGBIND,(DBINT)0,(BYTE DBFAR *)limcred1);
      dbbind(q_dbproc_thsmap,8,STRINGBIND,(DBINT)0,(BYTE DBFAR *)thsnombre);
      dbbind(q_dbproc_thsmap,9,STRINGBIND,(DBINT)0,(BYTE DBFAR *)cuenta_banamex);
      dbbind(q_dbproc_thsmap,10,STRINGBIND,(DBINT)0,(BYTE DBFAR *)cuenta_citi);
      dbbind(q_dbproc_thsmap,11,STRINGBIND,(DBINT)0,(BYTE DBFAR *)estatus);
      dbbind(q_dbproc_thsmap,12,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_num_nom);
      dbbind(q_dbproc_thsmap,13,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_centro_c);
      dbbind(q_dbproc_thsmap,14,STRINGBIND,(DBINT)0,(BYTE DBFAR *)cta_contable);
      fin_thsmap=dbnextrow(q_dbproc_thsmap);

/*    puts("T7"); */
      /* Se genera la variable num_cuenta1 para grabar */
      sprintf(num_cuenta1,"%s%s%s%s%s%s",eje_pre1,gpo_banco1,empresa,eje_num1,roll_over1,eje_digit1);
      /* Se genera la variable num_cuenta11 para grabar */
      sprintf(num_cuenta11,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_num1);
     }
/*    puts("T8"); */

   if (sigue == 0)
     { /* inicio del sigue = 0 de de la consulta q_dbproc_hisneg */
      /* printf("Consulta a MTCHIS01 Y MTCNEG01 Y MTCTRA01 \n");
      getchar(); */
/*    puts("T9"); */
      sprintf(sqlcmd,"select replicate('0',(select ");
      strcat(sqlcmd,"pgs_long_eje from MTCPGS01 g where ");
      strcat(sqlcmd,"g.pgs_rep_prefijo = a.eje_prefijo and ");
      strcat(sqlcmd,"g.pgs_rep_banco = a.gpo_banco)-char_length");
      strcat(sqlcmd,"(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim");
      strcat(sqlcmd,"(str(a.eje_num))),");
      strcat(sqlcmd,"a.eje_roll_over,a.eje_digit,a.his_proceso_amd,");
      strcat(sqlcmd,"substring(right('000000'+rtrim(convert(char(6),");
      strcat(sqlcmd,"isnull(b.b06_acd_num_acd,0))),6),3,4),");
      strcat(sqlcmd, "importe=str(isnull(a.his_importe,0),12,2), \n");
      strcat(sqlcmd, "dolares=str(isnull(a.his_dolares,0),12,2), \n");
      strcat(sqlcmd,"isnull(b.b01_neg_num_neg,0),\n");
      strcat(sqlcmd,"isnull(a.his_negocio_leyenda,' '),right('0000000'");
      strcat(sqlcmd,"+ltrim(str(a.his_referencia_a,7,0)),7),");
      strcat(sqlcmd,"isnull(a.his_pais,' '), \n");
      strcat(sqlcmd,"c.signo_transaccion, a.his_valor_amd, \n");
      strcat(sqlcmd,"c.tip_transaccion \n");
      strcat(sqlcmd,"from MTCHIS01 a, MTCNEG01 b, MTCTRA01 c  \n");
      strcat(sqlcmd,"where a.eje_prefijo=");
      sprintf(sqlcmd,"%s%s\n",sqlcmd,eje_pre1);
      strcat(sqlcmd," and a.gpo_banco=");
      sprintf(sqlcmd,"%s%s\n",sqlcmd,gpo_banco1);
      strcat(sqlcmd," and a.emp_num=");
      sprintf(sqlcmd,"%s%s\n",sqlcmd,emp_num1);
      strcat(sqlcmd," and a.his_mes_y_ciclo_corte=");
      sprintf(sqlcmd,"%s %d\n",sqlcmd,ciclo_corte);
      strcat(sqlcmd," and a.b01_neg_num_neg *= b.b01_neg_num_neg \n");
      strcat(sqlcmd," and a.his_transaccion = c.cve_transaccion \n");
      /* strcat(sqlcmd," and convert(int,substring(convert(char(8), \n");
      strcat(sqlcmd," a.his_proceso_amd),1,4)) in("); jrgd 21/ene/2003
      sprintf(sqlcmd,"%s %s) \n",sqlcmd,anioproc);  jrgd 21/ene/2003 */
      strcat(sqlcmd," order by a.eje_prefijo,a.gpo_banco,a.emp_num,\n");
      strcat(sqlcmd,"a.eje_num,a.his_proceso_amd");


/*    printf("SQL_2='%s'", sqlcmd); */

      dbcmd(q_dbproc_hisneg, sqlcmd);
      if (dbsqlexec(q_dbproc_hisneg) == FAIL)
        {
         printf("Fecha proceso:%s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("Error: Fallo al intentar traer datos de MTCHIS01,MTCNEG01 bdsqlexec\n");
         /* dbclose(q_dbproc_hisneg);
         dbexit();
         exit(1); */
         sigue=1;
        }
/*    puts("T10"); */

      dbresults(q_dbproc_hisneg);

      if (DBROWS(q_dbproc_hisneg) != SUCCEED && DBROWS(q_dbproc_hisneg) == NO_MORE_ROWS)
        {
         printf("Fecha proceso:%s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("No existen datos en MTCHIS01,MTCNEG01 DBROWS\n");
         /* dbclose(q_dbproc_hisneg);
         dbexit(); */
         sigue=1;
        }
      else
        {
         dbbind(q_dbproc_hisneg,1,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_num);
         dbbind(q_dbproc_hisneg,2,STRINGBIND,(DBINT)0,(BYTE DBFAR *)roll_over);
         dbbind(q_dbproc_hisneg,3,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_digit);
         dbbind(q_dbproc_hisneg,4,STRINGBIND,(DBINT)0,(BYTE DBFAR *)fecha);
         dbbind(q_dbproc_hisneg,5,STRINGBIND,(DBINT)0,(BYTE DBFAR *)MCC);
         dbbind(q_dbproc_hisneg,6,STRINGBIND,(DBINT)0,(BYTE DBFAR *)importe);
         dbbind(q_dbproc_hisneg,7,STRINGBIND,(DBINT)0,(BYTE DBFAR *)dolares);
         dbbind(q_dbproc_hisneg,8,STRINGBIND,(DBINT)0,(BYTE DBFAR *)num_neg);
         dbbind(q_dbproc_hisneg,9,STRINGBIND,(DBINT)0,(BYTE DBFAR *)nom_neg);
         dbbind(q_dbproc_hisneg,10,STRINGBIND,(DBINT)0,(BYTE DBFAR *)ref_a);
         dbbind(q_dbproc_hisneg,11,STRINGBIND,(DBINT)0,(BYTE DBFAR *)pais);
         dbbind(q_dbproc_hisneg,12,STRINGBIND,(DBINT)0,(BYTE DBFAR *)signo_tra);
         dbbind(q_dbproc_hisneg,13,STRINGBIND,(DBINT)0,(BYTE DBFAR *)fechaval);
         dbbind(q_dbproc_hisneg,14,STRINGBIND,(DBINT)0,(BYTE DBFAR *)tip_transac);

         fin_hisneg=dbnextrow(q_dbproc_hisneg);

         /* Se genera la variable num_cuenta para cortes sin roll_over,eje_digt */
         sprintf(num_cuenta,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_num);
        }

     } /* fin del sigue = 0 de de la consulta q_dbproc_hisneg */
/*    puts("T11"); */

   if (sigue == 0)
     { /* inicio del sigue = 0 de la consula q_dbproc_hih */
      /* printf("Consulta de MTCHIH01\n");
      getchar(); */
      sprintf(sqlcmd,"select replicate('0',(select pgs_long_eje ");
      strcat(sqlcmd, "from MTCPGS01 g where g.pgs_rep_prefijo = ");
      strcat(sqlcmd,"a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco)");
      strcat(sqlcmd,"-char_length(ltrim(rtrim(str(a.eje_num)))))+");
      strcat(sqlcmd,"ltrim(rtrim(str(a.eje_num))),\n");
      strcat(sqlcmd,"saldo_ant=str(isnull(a.hih_saldo_anterior,0),12,2), \n");
      strcat(sqlcmd,"saldo_nvo=str((isnull(a.hih_saldo_anterior, 0)-");
      strcat(sqlcmd,"isnull(a.hih_pagos_y_abonos, 0)+");
      strcat(sqlcmd,"isnull(a.hih_compras_y_disp,0)+");
      strcat(sqlcmd,"isnull(a.hih_comisiones,0)+isnull(a.hih_intereses,0)),12,2) \n");
      strcat(sqlcmd,"from MTCHIH01 a \n");
      strcat(sqlcmd,"where a.eje_prefijo =");
      sprintf(sqlcmd,"%s %s\n",sqlcmd,eje_pre1);
      strcat(sqlcmd," and a.gpo_banco =");
      sprintf(sqlcmd,"%s %s\n",sqlcmd,gpo_banco1);
      strcat(sqlcmd," and a.emp_num =");
      sprintf(sqlcmd,"%s %s\n",sqlcmd,emp_num1);
      strcat(sqlcmd," and a.hih_corte_a =");
      sprintf(sqlcmd,"%s %d\n",sqlcmd,anio);
      strcat(sqlcmd," and a.hih_corte_md =");
      sprintf(sqlcmd,"%s %d \n",sqlcmd,ciclo_corte);
      strcat(sqlcmd," order by a.eje_prefijo,a.gpo_banco,a.emp_num,a.eje_num \n");
      dbcmd(q_dbproc_hih, sqlcmd);
      if (dbsqlexec(q_dbproc_hih) == FAIL)
        {
         printf("Fecha proceso:%s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("Error: Fallo al intentar traer datos de MTCHIH01 bdsqlexec \n");
         /* dbclose(q_dbproc_hih);
         dbexit();
         exit(1); */
         sigue=1;
        }

      dbresults(q_dbproc_hih);
/*    puts("T12"); */

      if (DBROWS(q_dbproc_hih) != SUCCEED && DBROWS(q_dbproc_hih) == NO_MORE_ROWS)
        {
         printf("Fecha proceso:%s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("Fallo al intentar traer datos de MTCHIH01 DBROWS\n");
         /* dbclose(q_dbproc_hih);
         dbexit(); */
         sigue=1;
        }
      else
        {
         dbbind(q_dbproc_hih,1,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_numsal);
         dbbind(q_dbproc_hih,2,STRINGBIND,(DBINT)0,(BYTE DBFAR *)saldo_ant);
         dbbind(q_dbproc_hih,3,STRINGBIND,(DBINT)0,(BYTE DBFAR *)saldo_nvo);
         fin_hih=dbnextrow(q_dbproc_hih);

         /* Se genera la variable num_cuentasal para cortes */
         sprintf(num_cuentasal,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_numsal);
        }

     } /* fin del sigue = 0 de la consulta q_dbproc_hih */
/*    puts("T13"); */

   /* Inicia proceso para generar archivo */
   if (sigue == 0)
     {
      sprintf(nomarch,"%s",fechaArch);
      strcat(nomarch,".");
      strcat(nomarch,unidad);
      strcat(nomarch,".");
      strcat(nomarch,"rpt012.TXT");
      sprintf(nomarchpro,"%s%s%s",prefijo,banco,empresa);
      sprintf(directorio,"%s%s%s%s",dir_deposito,"/",nomarchpro,"/");

      /* Arma Encabezado del Reporte*/
      sprintf(encabezado,"%s","Fec.Pro.");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Fec.Tra.");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Nombre                  ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Cuenta          ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Nomina         ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Unidad         ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Nivel");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"SIC ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Monto Pesos ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Monto Dll   ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Merchant                  ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Pais");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Cd ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Edo");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"$ ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Cuenta Contable                         ");

      sprintf(dirarch,"%s%s",directorio,nomarch);
      sprintf(creacarpeta,"%s%s","mkdir -p ",directorio);
      system(creacarpeta);

      archivo = fopen(dirarch, "w");

      /* archivo = fopen(nomarch, "w"); */

      if ((fprintf(archivo,"%s\n",encabezado)) == -1)
        {
         printf("Fecha proceso: %s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
         exit(1);
        }

      /* while primer set de datos thsmap*/
      /*while((num_cuenta1 != '0') && (fin_thsmap != NO_MORE_ROWS))*/
      while(fin_thsmap != NO_MORE_ROWS)
        {
         /* while  del segundo set de datos hisneg */
         while((strcmp(num_cuenta,num_cuenta11) == 0) && (fin_hisneg != NO_MORE_ROWS))
           {
            /* printf("procesando cuenta: %s\n",num_cuenta);
            printf("tipo_fac: %s\n",tipo_fac);
            getchar(); */

            /* -----------------25/10/06 04:55p.-----------------
             Inicia codigo para obtener el MCC
             --------------------------------------------------*/

            /* Si la Transaccion es Nacional */
            if ((strcmp(pais,"MEX") == 0) || (strcmp(pais,"") == 0))  /* busca MEX */
            {
              strcpy(ciudad,"   ");
              strcpy(estado,"   ");
              if (strcmp(tip_transac,"dispo") == 0)
              {
               /*Coloca MCC para cajeros o para sucursal*/
               strncpy(pos5,&ref_a[4],1); /*posicion 5*/
               strncpy(pos6y7,&ref_a[5],2); /*posicion 6 y 7*/
               strcpy(MCC,"6011"); /*por default se pone mcc de sucursal*/
               if ((atoi(pos5) == 0) || ((atoi(pos5) != 0) && (atoi(pos6y7) == 96)))
                strcpy(MCC,"6010"); /*mcc de Cajeros */
              }
              else
              {
                if ( (strcmp(tip_transac,"abono") == 0) || (strcmp(tip_transac,"devolucion") == 0) ||
                     (atoi(num_neg) == 0) )
                 strcpy(MCC,"0000");
              }
            }
            else

            /* Si la Transaccion es Internacional */
            {
             strcpy(ciudad,"   ");
             strcpy(estado,"   ");

             /*si solo trae dos caracteres en pais el pais es USA */
             if ( strlen(pais) == 2 )
             {
              if ( strcmp(pais, "   ") != 0)
              {
                strcpy(estado,pais);
                strcpy(pais,"USA");
              }
             }

             /* Se copian las ultimas 4 posiciones del nombre de negocio */

             strncpy(MCC,&nom_neg[22],4); /* posicion 23 a la 26*/

             if (strcmp(MCC,"0000") == 0)
                strcpy(MCC,"6010"); /* Disposiciones CITISHARE */
             else
             {
              if (strcmp(tip_transac,"dispo") == 0)
                strcpy(MCC,"6010"); /* Disposiciones en VISA y MASTER CARD */
              else
              {
               if (strcmp(tip_transac,"devolucion") == 0)
                 strcpy(MCC,"0000");
              }
             }
            }
            /* con este codigo se asegura que el MCC siempre contega numeros */
            es_num = 0;
            for (j = 0; j < 4; ++j)
            {
              if (!isdigit(MCC[j]))
              {
                es_num = 1;
                break;
              }
            }
            /* Si no son numericas las 4 posiciones. */
            if (es_num== 1)
            {
               strcpy(MCC,"0000");
            }

            /* -----------------25/10/06 04:55pm.-----------------
             Termina codigo para obtener el MCC
             --------------------------------------------------*/

/*
            if (((strcmp(pais,"MEX") == 0) && (atoi(importe) != 0) && (atoi(dolares) != 0)) || ((strcmp(pais,"MEX") == 0) && (atoi(importe) != 0) && (atoi(dolares) == 0)))
              {
               /* transacciones nacionales*/
/*               strcpy(ciudad,"   ");
               strcpy(estado,"   ");
               if ( atoi(num_neg) == 0)
                 {
                  strncpy(pos5,&ref_a[4],1); /*posicion 5*/
/*                 strncpy(pos6y7,&ref_a[5],2); /*posicion 6 y 7*/
/*                 strcpy(MCC,"6011"); /*por default se pone mcc de sucursal*/
/*                 if ((atoi(pos5) == 0) || ((atoi(pos5) != 0) && (atoi(pos6y7) == 96)))
                    {
                     strcpy(MCC,"6010"); /*mcc de Cajeros */
/*                    }
                 }
              }
            else
              {
               /*transacciones internacionales*/
/*               strcpy(ciudad,"   ");
               strcpy(estado,"   ");

               /*si solo trae dos caracteres en pais el pais es USA */
/*               if ( strlen(pais) == 2 )
                 {
                  if ( strcmp(pais, "   ") != 0)
                    {
                     strcpy(estado,pais);
                     strcpy(pais,"USA");
                    }
                 }
               strncpy(MCC,&nom_neg[22],4); /* posicion 23 a la 26*/
               /* printf("MCC:%s\n",MCC);
               getchar(); */
/*               cont=0;
               while( cont <= 3 )
                 {
                  strncpy(car,&MCC[cont],1); /*para checar que sea numerico*/
                  /* printf("car:%s\n",car);
                  getchar(); */
/*                  if (isalpha(atoi(car)) != 0)
                  /* if (!(car == "1" && car == "2" && car == "3" && car == "4" && car == "5" && car == "6" && car == "7" && car == "8" && car == "9" && car == "0" )) */
/*                    {
                     /* printf("Entro al MCC de 000\n");
                     getchar(); */
/*                     strcpy(MCC,"0000");
                    }
                  cont++;
                 }
              } /* fin del if de transacciones nacionales / internacionales */

            if (strcmp(signo_tra,"C") == 0)
              {
               sprintf(importec,"%12.2f",(atof(importe)*-1));
               importec[9]='.';
               sprintf(dolaresc,"%12.2f",(atof(dolares)*-1));
               dolaresc[9]='.';
              }
            else
              {
               sprintf(importec,"%12.2f",atof(importe));
               importec[9]='.';
               sprintf(dolaresc,"%12.2f",atof(dolares));
               dolaresc[9]='.';
              }

            /* if (strcmp(estatus, " ") == 0 && strcmp(cuenta_banamex,"                ") != 0 && strcmp(cuenta_citi,"                " != 0))
              {
               strcpy(num_cuenta1,cuenta_citi);
              } */

            if (strcmp(estatus, " ") == 0 && strlen(cuenta_banamex) == 16 && strlen(cuenta_citi) == 16)
              {
               strcpy(num_cuenta1,cuenta_citi);
              }

            sprintf(detalle,"%-8s",fecha);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-8s",detalle,fechaval);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-24s",detalle,thsnombre);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-16s",detalle,num_cuenta1);
            sprintf(detalle,"%s%s",detalle," ");
            if (strlen(eje_num_nom) == 15)
              {
               sprintf(detalle,"%s%s",detalle,eje_num_nom);
              }
            else
              {
               sprintf(detalle,"%s%-15s",detalle,eje_num_nom);
              }
            sprintf(detalle,"%s%s",detalle," ");
            if (strlen(eje_centro_c) == 15)
              {
               sprintf(detalle,"%s%s",detalle,eje_centro_c);
              }
            else
              {
               sprintf(detalle,"%s%-15s",detalle,eje_centro_c);
              }
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-5s",detalle,unit_level);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-4s",detalle,MCC);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%s",detalle,importec);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%s",detalle,dolaresc);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-26s",detalle,nom_neg);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-3s",detalle,pais);
            sprintf(detalle,"%s%s",detalle,"  ");
            sprintf(detalle,"%s%-3s",detalle,ciudad);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-3s",detalle,estado);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-1s",detalle,"M");
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-40s",detalle,cta_contable);

            /* printf("%s\n",detalle); */

            if ((fprintf(archivo,"%s\n",detalle)) == -1)
              {
               printf("Fecha proceso: %s\n", fechayhora);
               printf("Nombre archivo: %s\n", nombrearchivo);
               printf("Programa: creaDerSBF.c \n");
               printf("Error: No grabo el registro en el archivo rpt012.TXT\n");
               exit(1);
              }

            strcpy(detalle,"\0");

            strcpy(num_cuentaant,num_cuenta11);
            strcpy(num_cuenta11,num_cuenta);
            flag=1;

            fin_hisneg=dbnextrow(q_dbproc_hisneg);
            /* Se genera la variable num_cuenta para cortes sin roll_over,eje_digt */
            sprintf(num_cuenta,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_num);

           } /* fin del segundo set de datos hisneg */

         if (flag != 0)
           {
            while (atol(num_cuentasal) < atol(num_cuentaant) && fin_hih != NO_MORE_ROWS )
              {
               fin_hih=dbnextrow(q_dbproc_hih);
               /* Se genera la variable num_cuentasal para cortes */
               sprintf(num_cuentasal,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_numsal);
              }

            if (strcmp(num_cuentasal,num_cuentaant) == 0)
              {
               /* formatea con , los montos a grabar en el archivo los saldos */
               sprintf(salantc,"%12.2f",atof(saldo_ant));
               salantc[9]='.';
               sprintf(salnvoc,"%12.2f",atof(saldo_nvo));
               salnvoc[9]='.';
               /* RSP saldos[0]="\0"; */
               memset( saldos, '\0', sizeof( saldos ) );

               if (atof(saldo_ant) == 0)
                 {
                  sprintf(salantc,"%s","        0.00");
                 }

               if (atof(saldo_nvo) == 0)
                 {
                  sprintf(salnvoc,"%s","        0.00");
                 }

               sprintf(saldos,"%s","                  ");
               sprintf(saldos,"%s%s",saldos,"Saldo Anterior  ");
               sprintf(saldos,"%s%s",saldos,"          ");
               sprintf(saldos,"%s%s",saldos,salantc);
               sprintf(saldos,"%s%s",saldos,"        ");
               sprintf(saldos,"%s%s",saldos,"    ");
               sprintf(saldos,"%s%s",saldos,"            ");
               sprintf(saldos,"%s%s",saldos,"                        ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos," ");
               if ((fprintf(archivo,"%s\n",saldos)) == -1)
                 {
                  printf("Fecha proceso: %s\n", fechayhora);
                  printf("Nombre archivo: %s\n", nombrearchivo);
                  printf("Programa: creaDerSBF.c \n");
                  printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
                  exit(1);
                 }

               /* RSP saldos[0]="\0"; */
               memset( saldos, '\0', sizeof( saldos ) );
               sprintf(saldos,"%s","                  ");
               sprintf(saldos,"%s%s",saldos,"Saldo Nuevo     ");
               sprintf(saldos,"%s%s",saldos,"          ");
               sprintf(saldos,"%s%s",saldos,salnvoc);
               sprintf(saldos,"%s%s",saldos,"        ");
               sprintf(saldos,"%s%s",saldos,"    ");
               sprintf(saldos,"%s%s",saldos,"            ");
               sprintf(saldos,"%s%s",saldos,"                        ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos," ");

               if ((fprintf(archivo,"%s\n",saldos)) == -1)
                 {
                  printf("Fecha proceso: %s\n", fechayhora);
                  printf("Nombre archivo: %s\n", nombrearchivo);
                  printf("Programa: creaDerSBF.c \n");
                  printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
                  exit(1);
                 }
               fin_hih=dbnextrow(q_dbproc_hih);

               /* Se genera la variable num_cuentasal para cortes */
               sprintf(num_cuentasal,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_numsal);
               flag=0;
              } /* fin del if num_cuentasal = num_cuenta11  */
            else
              {
               /* formatea con , a los montos para grabar en el archivo los saldos*/
               sprintf(salantc,"%12.2s","000000000000");
               salantc[9]='.';
               sprintf(salnvoc,"%12.2s","000000000000");
               salnvoc[9]='.';

               if (atof(salantc) == 0)
                 {
                  sprintf(salantc,"%s","        0.00");
                 }

               if (atof(salnvoc) == 0)
                 {
                  sprintf(salnvoc,"%s","        0.00");
                 }

               /* RSP saldos[0]="\0"; */
               memset( saldos, '\0', sizeof( saldos ) );
               sprintf(saldos,"%s","                  ");
               sprintf(saldos,"%s%s",saldos,"Saldo Anterior  ");
               sprintf(saldos,"%s%s",saldos,"          ");
               sprintf(saldos,"%s%s",saldos,salantc);
               sprintf(saldos,"%s%s",saldos,"        ");
               sprintf(saldos,"%s%s",saldos,"    ");
               sprintf(saldos,"%s%s",saldos,"            ");
               sprintf(saldos,"%s%s",saldos,"                        ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos," ");
               if ((fprintf(archivo,"%s\n",saldos)) == -1)
                 {
                  printf("Fecha proceso: %s\n", fechayhora);
                  printf("Nombre archivo: %s\n", nombrearchivo);
                  printf("Programa: creaDerSBF.c \n");
                  printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
                  exit(1);
                 }

               /* RSP saldos[0]="\0"; */
               memset( saldos, '\0', sizeof( saldos ) );
               sprintf(saldos,"%s","                  ");
               sprintf(saldos,"%s%s",saldos,"Saldo Nuevo     ");
               sprintf(saldos,"%s%s",saldos,"          ");
               sprintf(saldos,"%s%s",saldos,salnvoc);
               sprintf(saldos,"%s%s",saldos,"        ");
               sprintf(saldos,"%s%s",saldos,"    ");
               sprintf(saldos,"%s%s",saldos,"            ");
               sprintf(saldos,"%s%s",saldos,"                        ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos," ");

               if ((fprintf(archivo,"%s\n",saldos)) == -1)
                 {
                  printf("Fecha proceso: %s\n", fechayhora);
                  printf("Nombre archivo: %s\n", nombrearchivo);
                  printf("Programa: creaDerSBF.c \n");
                  printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
                  exit(1);
                 }
               flag=0;
               /* Se genera la variable num_cuentasal para cortes */
               sprintf(num_cuentasal,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_numsal);
              } /* fin del else del if num_cuentasal = num_cuenta11  */
           } /* fin del if flag != 0 */

         fin_thsmap=dbnextrow(q_dbproc_thsmap);

         num_cuenta1[0]='\0';

         /* Se genera la variable num_cuenta1 para grabar */
         sprintf(num_cuenta1,"%s%s%s%s%s%s",eje_pre1,gpo_banco1,empresa,eje_num1,roll_over1,eje_digit1);

         /* Se genera la variable @num_cuenta11 para grabar */
         sprintf(num_cuenta11,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_num1);

        } /* fin del primer set de datos thsmap */

      fclose(archivo);
      dbcancel(q_dbproc_hih);
      dbcancel(q_dbproc_hisneg);
      dbcancel(q_dbproc_thsmap);
     } /* fin del sigue de facturacion individual */
   else
     {
      dbcancel(q_dbproc_hih);
      dbcancel(q_dbproc_hisneg);
      dbcancel(q_dbproc_thsmap);
     } /* fin else del sigue de facturacion individual */

  /*  sigue=0;
   fin_emp=dbnextrow(q_dbproc_emp); */

  } /* fin del if tipo facturacion 'I' */

/* puts("T3"); */
/* Facturacion corporativa */
if (strcmp(tipo_fac,"C") == 0)
  {
   /* printf("Entro al proceso de Facturacion corporativa\n");
   getchar(); */

   ciclo_corte = (mes * 100) + atoi(dia_corte);

   primervez=0;
   /* RSP sqlcmd[0]="\0"; */
   memset ( sqlcmd, '\0', sizeof( sqlcmd ) );
/* puts("T4"); */

   /* Consulta a MTCTHS01 Y MTCMAP01 */
   sprintf(sqlcmd,"select a.eje_prefijo,a.gpo_banco, ");
   strcat(sqlcmd,"replicate('0',(select pgs_long_emp from MTCPGS01 g where g.pgs_rep_prefijo = a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco)-char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num))),");
   strcat(sqlcmd,"replicate('0',(select pgs_long_eje from MTCPGS01 g where g.pgs_rep_prefijo = a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco)-char_length(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num))),\n");
   strcat(sqlcmd,"a.eje_roll_over,a.eje_digit,\n");
   strcat(sqlcmd, "isnull(str(a.ths_limite_credito,12,0),\n");
   strcat(sqlcmd, "'000000000000') limiteCredito, \n");
   strcat(sqlcmd,"substring(c.eje_nombre,1,24) nombre,\n");
   strcat(sqlcmd,"isnull(b.map_cta_bnx,' ') cta_banamex, \n");
   strcat(sqlcmd,"isnull(b.map_cta_citi,' ') cta_citi, \n");
   strcat(sqlcmd,"isnull(b.map_estatus,' ') estatus, \n");
   strcat(sqlcmd,"isnull(c.eje_num_nom,' ') nomina, \n");
   strcat(sqlcmd,"isnull(c.eje_centro_c,' ') eje_centro, \n");
   strcat(sqlcmd,"c.eje_tipo_cuenta tipo_cta, \n");
   strcat(sqlcmd,"isnull(c.eje_cta_contable, ' ') cta_contable \n");
   strcat(sqlcmd,"from MTCTHS01 a, MTCMAP01 b, MTCEJE01 c \n");
   strcat(sqlcmd,"where right('0000'+convert(char(4),a.eje_prefijo),4)");
   strcat(sqlcmd,"+right('00'+convert(char(2),a.gpo_banco),2)");
   strcat(sqlcmd,"+replicate('0',(select pgs_long_emp from ");
   strcat(sqlcmd,"MTCPGS01 i where i.pgs_rep_prefijo = ");
   strcat(sqlcmd,"a.eje_prefijo and i.pgs_rep_banco = ");
   strcat(sqlcmd,"a.gpo_banco)-char_length(ltrim(rtrim(str(");
   strcat(sqlcmd,"a.emp_num)))))+");
   strcat(sqlcmd,"ltrim(rtrim(str(a.emp_num)))+");
   strcat(sqlcmd,"replicate('0',(select pgs_long_eje ");
   strcat(sqlcmd,"from MTCPGS01 g where g.pgs_rep_prefijo = ");
   strcat(sqlcmd,"a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco)");
   strcat(sqlcmd,"-char_length(ltrim(rtrim(str(a.eje_num)))))+");
   strcat(sqlcmd,"ltrim(rtrim(str(a.eje_num)))+");
   strcat(sqlcmd,"right('0'+convert(char(1),a.eje_roll_over),1)+");
   strcat(sqlcmd,"right('0'+convert(char(1),a.eje_digit),1) ");
   strcat(sqlcmd,"*= b.map_cta_bnx \n");
   strcat(sqlcmd,"and  a.eje_prefijo=");
   sprintf(sqlcmd,"%s %s\n%",sqlcmd,prefijo);
   strcat(sqlcmd,"and a.gpo_banco=");
   sprintf(sqlcmd,"%s %s\n",sqlcmd,banco);
   strcat(sqlcmd,"and a.emp_num=");
   sprintf(sqlcmd,"%s %s\n",sqlcmd,empresa);
   strcat(sqlcmd,"and  a.eje_prefijo *=c.eje_prefijo ");
   strcat(sqlcmd,"and a.gpo_banco *=c.gpo_banco ");
   strcat(sqlcmd,"and a.emp_num *=c.emp_num ");
   strcat(sqlcmd,"and a.eje_num *=c.eje_num ");
   strcat(sqlcmd,"order by a.eje_prefijo,a.gpo_banco,\n");
   strcat(sqlcmd,"a.emp_num,a.eje_num, estatus \n");
   dbcmd(q_dbproc_thsmap, sqlcmd);
   if (dbsqlexec(q_dbproc_thsmap) == FAIL)
     {
      printf("Fecha proceso:%s\n", fechayhora);
      printf("Nombre archivo: %s\n", nombrearchivo);
      printf("Programa: creaDerSBF.c \n");
      printf("Error: Fallo al intentar traer datos de MTCTHS01,MTCMAP01 bdsqlexec,%s \n",sqlcmd);
      dbclose(q_dbproc_thsmap);
      dbexit();
      exit(1);
     }

   dbresults(q_dbproc_thsmap);

   if (DBROWS(q_dbproc_thsmap) != SUCCEED && DBROWS(q_dbproc_thsmap) == NO_MORE_ROWS)
     {
      printf("Fecha proceso:%s\n", fechayhora);
      printf("Nombre archivo: %s\n", nombrearchivo);
      printf("Programa: creaDerSBF.c \n");
      printf("No existen datos de MTCTHS01,MTCMAP01 DBROWS\n");
      /* dbclose(q_dbproc_thsmap);
      dbexit(); */
      sigue=1;
     }
   else
     {
      dbbind(q_dbproc_thsmap,1,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_pre1);
      dbbind(q_dbproc_thsmap,2,STRINGBIND,(DBINT)0,(BYTE DBFAR *)gpo_banco1);
      dbbind(q_dbproc_thsmap,3,STRINGBIND,(DBINT)0,(BYTE DBFAR *)emp_num1);
      dbbind(q_dbproc_thsmap,4,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_num1);
      dbbind(q_dbproc_thsmap,5,STRINGBIND,(DBINT)0,(BYTE DBFAR *)roll_over1);
      dbbind(q_dbproc_thsmap,6,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_digit1);
      dbbind(q_dbproc_thsmap,7,STRINGBIND,(DBINT)0,(BYTE DBFAR *)limcred1);
      dbbind(q_dbproc_thsmap,8,STRINGBIND,(DBINT)0,(BYTE DBFAR *)thsnombre);
      dbbind(q_dbproc_thsmap,9,STRINGBIND,(DBINT)0,(BYTE DBFAR *)cuenta_banamex);
      dbbind(q_dbproc_thsmap,10,STRINGBIND,(DBINT)0,(BYTE DBFAR *)cuenta_citi);
      dbbind(q_dbproc_thsmap,11,STRINGBIND,(DBINT)0,(BYTE DBFAR *)estatus);
      dbbind(q_dbproc_thsmap,12,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_num_nom);
      dbbind(q_dbproc_thsmap,13,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_centro_c);
      dbbind(q_dbproc_thsmap,14,STRINGBIND,(DBINT)0,(BYTE DBFAR *)tipo_reg);
      dbbind(q_dbproc_thsmap,15,STRINGBIND,(DBINT)0,(BYTE DBFAR *)cta_contable);
      fin_thsmap=dbnextrow(q_dbproc_thsmap);

      /* Se genera la variable num_cuenta1 para grabar */
      sprintf(num_cuenta1,"%s%s%s%s%s%s",eje_pre1,gpo_banco1,empresa,eje_num1,roll_over1,eje_digit1);

      /* Se genera la variable num_cuenta11 para cortes */
      sprintf(num_cuenta11,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_num1);
     }


   if (sigue == 0 )
     { /* inicio if sigue = 0 para la consulta q_dbproc_hisneg */
      /* printf("Consulta a MTCHIS01 Y MTCNEG01 Y MTCTRA01\n");
      getchar(); */
      sprintf(sqlcmd,"select replicate('0',(select ");
      strcat(sqlcmd,"pgs_long_eje from MTCPGS01 g where ");
      strcat(sqlcmd,"g.pgs_rep_prefijo = a.eje_prefijo and ");
      strcat(sqlcmd,"g.pgs_rep_banco = a.gpo_banco)-char_length");
      strcat(sqlcmd,"(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim");
      strcat(sqlcmd,"(str(a.eje_num))),");
      strcat(sqlcmd,"a.eje_roll_over,a.eje_digit,a.his_proceso_amd,");
      strcat(sqlcmd,"substring(right('000000'+rtrim(convert(char(6),");
      strcat(sqlcmd,"isnull(b.b06_acd_num_acd,0))),6),3,4),");
      strcat(sqlcmd, "importe=str(isnull(a.his_importe,0),12,2), \n");
      strcat(sqlcmd, "dolares=str(isnull(a.his_dolares,0),12,2), \n");
      strcat(sqlcmd,"isnull(b.b01_neg_num_neg,0),\n");
      strcat(sqlcmd,"isnull(a.his_negocio_leyenda,' '),right('0000000'");
      strcat(sqlcmd,"+ltrim(str(a.his_referencia_a,7,0)),7),");
      strcat(sqlcmd,"isnull(a.his_pais,' '), \n");
      strcat(sqlcmd,"c.signo_transaccion, a.his_valor_amd, \n");
      strcat(sqlcmd,"c.tip_transaccion \n");
      strcat(sqlcmd,"from MTCHIS01 a, MTCNEG01 b, MTCTRA01 c \n");
      strcat(sqlcmd,"where a.eje_prefijo=");
      sprintf(sqlcmd,"%s%s\n",sqlcmd,eje_pre1);
      strcat(sqlcmd," and a.gpo_banco=");
      sprintf(sqlcmd,"%s%s\n",sqlcmd,gpo_banco1);
      strcat(sqlcmd," and a.emp_num=");
      sprintf(sqlcmd,"%s%s\n",sqlcmd,emp_num1);
      strcat(sqlcmd," and a.his_mes_y_ciclo_corte=");
      sprintf(sqlcmd,"%s %d\n",sqlcmd,ciclo_corte);
      strcat(sqlcmd," and a.b01_neg_num_neg *= b.b01_neg_num_neg \n");
      strcat(sqlcmd," and a.his_transaccion = c.cve_transaccion \n");
      /* strcat(sqlcmd," and convert(int,substring(convert(char(8), \n");
      strcat(sqlcmd," a.his_proceso_amd),1,4)) in( \n"); jrgd 21/ene/2003
      sprintf(sqlcmd,"%s %s) \n",sqlcmd,anioproc); jrgd 21/ene/2003 */
      strcat(sqlcmd," order by a.eje_prefijo,a.gpo_banco,a.emp_num,\n");
      strcat(sqlcmd,"a.eje_num,a.his_proceso_amd");
      dbcmd(q_dbproc_hisneg, sqlcmd);
      if (dbsqlexec(q_dbproc_hisneg) == FAIL)
        {
         printf("Fecha proceso:%s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("Error: Fallo al intentar traer datos de MTCHIS01,MTCNEG01 bdsqlexec,%s \n",sqlcmd);
         dbclose(q_dbproc_hisneg);
         dbexit();
         exit(1);
        }

      dbresults(q_dbproc_hisneg);

      if (DBROWS(q_dbproc_hisneg) != SUCCEED && DBROWS(q_dbproc_hisneg) == NO_MORE_ROWS)
        {
         printf("Fecha proceso:%s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("No existen datos de MTCHIS01,MTCNEG01 DBROWS\n");
         /* dbclose(q_dbproc_hisneg);
         dbexit(); */
         sigue=1;
        }
      else
        {
         dbbind(q_dbproc_hisneg,1,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_num);
         dbbind(q_dbproc_hisneg,2,STRINGBIND,(DBINT)0,(BYTE DBFAR *)roll_over);
         dbbind(q_dbproc_hisneg,3,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_digit);
         dbbind(q_dbproc_hisneg,4,STRINGBIND,(DBINT)0,(BYTE DBFAR *)fecha);
         dbbind(q_dbproc_hisneg,5,STRINGBIND,(DBINT)0,(BYTE DBFAR *)MCC);
         dbbind(q_dbproc_hisneg,6,STRINGBIND,(DBINT)0,(BYTE DBFAR *)importe);
         dbbind(q_dbproc_hisneg,7,STRINGBIND,(DBINT)0,(BYTE DBFAR *)dolares);
         dbbind(q_dbproc_hisneg,8,STRINGBIND,(DBINT)0,(BYTE DBFAR *)num_neg);
         dbbind(q_dbproc_hisneg,9,STRINGBIND,(DBINT)0,(BYTE DBFAR *)nom_neg);
         dbbind(q_dbproc_hisneg,10,STRINGBIND,(DBINT)0,(BYTE DBFAR *)ref_a);
         dbbind(q_dbproc_hisneg,11,STRINGBIND,(DBINT)0,(BYTE DBFAR *)pais);
         dbbind(q_dbproc_hisneg,12,STRINGBIND,(DBINT)0,(BYTE DBFAR *)signo_tra);
         dbbind(q_dbproc_hisneg,13,STRINGBIND,(DBINT)0,(BYTE DBFAR *)fechaval);
         dbbind(q_dbproc_hisneg,14,STRINGBIND,(DBINT)0,(BYTE DBFAR *)tip_transac);

         fin_hisneg=dbnextrow(q_dbproc_hisneg);

         /* Se genera la variable @num_cuenta para cortes sin roll_over,eje_digt */
         sprintf(num_cuenta,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_num);
        }
     } /* fin del if sigue = 0 de la consulta q_dbproc_hisneg */

   if (sigue == 0)
     { /* inicio if sigue = 0 para la consulta q_dbproc_hih */
      /* printf("Consulta de MTCHIH01 \n");
      getchar(); */
      sprintf(sqlcmd,"select replicate('0',(select pgs_long_eje ");
      strcat(sqlcmd, "from MTCPGS01 g where g.pgs_rep_prefijo = ");
      strcat(sqlcmd,"a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco)");
      strcat(sqlcmd,"-char_length(ltrim(rtrim(str(a.eje_num)))))+");
      strcat(sqlcmd,"ltrim(rtrim(str(a.eje_num))),\n");
      strcat(sqlcmd,"saldo_ant=str(isnull(a.hih_saldo_anterior,0),12,2), \n");
      strcat(sqlcmd,"saldo_nvo=str((isnull(a.hih_saldo_anterior,0)-");
      strcat(sqlcmd,"isnull(a.hih_pagos_y_abonos, 0)+");
      strcat(sqlcmd,"isnull(a.hih_compras_y_disp,0)+");
      strcat(sqlcmd,"isnull(a.hih_comisiones,0)+isnull(a.hih_intereses,0)),12,2) \n");
      strcat(sqlcmd,"from MTCHIH01 a \n");
      strcat(sqlcmd,"where a.eje_prefijo =");
      sprintf(sqlcmd,"%s %s\n",sqlcmd,eje_pre1);
      strcat(sqlcmd," and a.gpo_banco =");
      sprintf(sqlcmd,"%s %s\n",sqlcmd,gpo_banco1);
      strcat(sqlcmd," and a.emp_num =");
      sprintf(sqlcmd,"%s %s\n",sqlcmd,emp_num1);
      strcat(sqlcmd," and a.hih_corte_a =");
      sprintf(sqlcmd,"%s %d\n",sqlcmd,anio);
      strcat(sqlcmd," and a.hih_corte_md =");
      sprintf(sqlcmd,"%s %d \n",sqlcmd,ciclo_corte);
      strcat(sqlcmd," order by a.eje_prefijo,a.gpo_banco,a.emp_num,a.eje_num \n");
      dbcmd(q_dbproc_hih, sqlcmd);
      if (dbsqlexec(q_dbproc_hih) == FAIL)
        {
         printf("Fecha proceso:%s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("Error: Fallo al intentar traer datos de MTCHIH01 bdsqlexec,%s \n",sqlcmd);
         dbclose(q_dbproc_hih);
         dbexit();
         exit(1);
        }

     dbresults(q_dbproc_hih);

     if (DBROWS(q_dbproc_hih) != SUCCEED && DBROWS(q_dbproc_hih) == NO_MORE_ROWS)
       {
        printf("Fecha proceso:%s\n", fechayhora);
        printf("Nombre archivo: %s\n", nombrearchivo);
        printf("Programa: creaDerSBF.c \n");
        printf("No existen datos de MTCHIH01 DBROWS\n");
        /* dbclose(q_dbproc_hih);
        dbexit(); */
        sigue=1;
       }
     else
       {
        dbbind(q_dbproc_hih,1,STRINGBIND,(DBINT)0,(BYTE DBFAR *)eje_numsal);
        dbbind(q_dbproc_hih,2,STRINGBIND,(DBINT)0,(BYTE DBFAR *)saldo_ant);
        dbbind(q_dbproc_hih,3,STRINGBIND,(DBINT)0,(BYTE DBFAR *)saldo_nvo);
        fin_hih=dbnextrow(q_dbproc_hih);

        /* Se genera la variable num_cuentasal para cortes */
        sprintf(num_cuentasal,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_numsal);
       }
     } /* fin sigue = 0 de la consulta q_dbproc_hih */

   if (sigue == 0) /* inicia proceso de informacion */
     {
      sprintf(nomarch,"%8s",fechaArch);
      strcat(nomarch,".");
      strcat(nomarch,unidad);
      strcat(nomarch,".");
      strcat(nomarch,"rpt012.TXT");
      sprintf(nomarchpro,"%s%s%s",prefijo,banco,empresa);
      sprintf(directorio,"%s%s%s%s",dir_deposito,"/",nomarchpro,"/");

      /* Arma Encabezado del Reporte*/
      sprintf(encabezado,"%s","Fec.Pro.");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Fec.Tra.");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Nombre                  ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Cuenta          ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Nomina         ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Unidad         ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Nivel");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"SIC ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Monto Pesos ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Monto Dll   ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Merchant                  ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Pais");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Cd ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Edo");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"$ ");
      sprintf(encabezado,"%s%s",encabezado," ");
      sprintf(encabezado,"%s%s",encabezado,"Cuenta Contable                         ");

      sprintf(dirarch,"%s%s",directorio,nomarch);
      sprintf(creacarpeta,"%s%s","mkdir -p ",directorio);
      system(creacarpeta);

      archivo = fopen(dirarch, "w");

      /* archivo = fopen(nomarch, "w"); */

      if ((fprintf(archivo,"%s\n",encabezado)) == -1)
        {
         printf("Fecha proceso: %s\n", fechayhora);
         printf("Nombre archivo: %s\n", nombrearchivo);
         printf("Programa: creaDerSBF.c \n");
         printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
         exit(1);
        }
      /* while primer set de datos thsmap*/
      /*while((num_cuenta1 != '0') && (fin_thsmap != NO_MORE_ROWS))*/
      while(fin_thsmap != NO_MORE_ROWS)
        {
         /* while  del segundo set de datos hisneg */
         while((strcmp(num_cuenta,num_cuenta11) == 0) && (fin_hisneg != NO_MORE_ROWS))
           {
            /* printf("procesando cuenta: %s\n",num_cuenta);
            printf("tipo_fac: %s\n",tipo_fac);
            getchar(); */

            /* -----------------25/10/06 04:55p.-----------------
             Inicia codigo para obtener el MCC
             --------------------------------------------------*/

            /* Si la Transaccion es Nacional */
            if ((strcmp(pais,"MEX") == 0) || (strcmp(pais,"") == 0))  /* busca MEX */
            {
              strcpy(ciudad,"   ");
              strcpy(estado,"   ");
              if (strcmp(tip_transac,"dispo") == 0)
              {
               /*Coloca MCC para cajeros o para sucursal*/
               strncpy(pos5,&ref_a[4],1); /*posicion 5*/
               strncpy(pos6y7,&ref_a[5],2); /*posicion 6 y 7*/
               strcpy(MCC,"6011"); /*por default se pone mcc de sucursal*/
               if ((atoi(pos5) == 0) || ((atoi(pos5) != 0) && (atoi(pos6y7) == 96)))
                strcpy(MCC,"6010"); /*mcc de Cajeros */
              }
              else
              {
                if ( (strcmp(tip_transac,"abono") == 0) || (strcmp(tip_transac,"devolucion") == 0) ||
                     (atoi(num_neg) == 0) )
                 strcpy(MCC,"0000");
              }
            }
            else

            /* Si la Transaccion es Internacional */
            {
             strcpy(ciudad,"   ");
             strcpy(estado,"   ");

             /*si solo trae dos caracteres en pais el pais es USA */
             if ( strlen(pais) == 2 )
             {
              if ( strcmp(pais, "   ") != 0)
              {
                strcpy(estado,pais);
                strcpy(pais,"USA");
              }
             }

             /* Se copian las ultimas 4 posiciones del nombre de negocio */

             strncpy(MCC,&nom_neg[22],4); /* posicion 23 a la 26*/

             if (strcmp(MCC,"0000") == 0)
                strcpy(MCC,"6010"); /* Disposiciones CITISHARE */
             else
             {
              if (strcmp(tip_transac,"dispo") == 0)
                strcpy(MCC,"6010"); /* Disposiciones en VISA y MASTER CARD */
              else
              {
               if (strcmp(tip_transac,"devolucion") == 0)
                 strcpy(MCC,"0000");
              }
             }
            }
            /* con este codigo se asegura que el MCC siempre contega numeros */
            es_num = 0;
            for (j = 0; j < 4; ++j)
            {
              if (!isdigit(MCC[j]))
              {
                es_num = 1;
                break;
              }
            }
            /* Si no son numericas las 4 posiciones. */
            if (es_num== 1)
            {
               strcpy(MCC,"0000");
            }

            /* -----------------25/10/06 04:55pm.-----------------
             Termina codigo para obtener el MCC
             --------------------------------------------------*/

/*            if (((strcmp(pais,"MEX") == 0) && (atoi(importe) != 0) && (atoi(dolares) != 0)) || ((strcmp(pais,"MEX") == 0) && (atoi(importe) != 0) && (atoi(dolares) == 0)))
              {
               /* transacciones nacionales*/
/*               strcpy(ciudad,"   ");
               strcpy(estado,"   ");
               if ( atoi(num_neg) == 0)
                 {
                  strncpy(pos5,&ref_a[4],1); /*posicion 5*/
/*                  strncpy(pos6y7,&ref_a[5],2); /*posicion 6 y 7*/
/*                  strcpy(MCC,"6011"); /*por default se pone mcc desucursal*/
/*                  if ((atoi(pos5) == 0) || ((atoi(pos5) != 0) && (atoi(pos6y7) == 96)))
                    {
                     strcpy(MCC,"6010"); /*mcc de Cajeros */
/*                    }
                 }
              }
            else
              {
               /*transacciones internacionales*/
/*               strcpy(ciudad,"   ");
               strcpy(estado,"   ");

               /*si solo trae dos caracteres en pais el pais es USA */
/*               if ( strlen(pais) == 2 )
                 {
                  if ( strcmp(pais, "   ") != 0)
                    {
                     strcpy(estado,pais);
                     strcpy(pais,"USA");
                    }
                 }
               strncpy(MCC,&nom_neg[22],4); /* posicion 23 a la 26*/
               /* printf("MCC:%s\n",MCC);
               getchar(); */
  /*             cont=0;
               while( cont <= 3 )
                 {
                  strncpy(car,&MCC[cont],1); /*para checar que sea numerico*/
                  /* printf("car:%s\n",car);
                  getchar(); */
/*                  if (isalpha(atoi(car)) != 0)
                  /* if (!(car == "1" && car == "2" && car == "3" && car == "4" && car == "5" && car == "6" && car == "7" && car == "8" && car == "9" && car == "0" )) */
/*                    {
                     strcpy(MCC,"0000");
                    }
                  cont++;
                 }
              } /* fin del if de transacciones nacionales / internacionales */

            /* printf("tipo_reg =: %s\n",tipo_reg );
            printf("atoi(eje_num)%d\n",atoi(eje_num));
            printf("primervez: %d\n",primervez);
            getchar(); */

            if ( (strcmp(tipo_reg,"E") == 0) && (atoi(eje_num) == 0) && (primervez == 0) )
              {
               /* printf("Entro al if de tipo_reg=E,eje_num=0,primervez=0\n");
               getchar(); */
               flag = 1;
               sprintf(salantc,"%12.2f",atof(saldo_ant));
               salantc[9]='.';
               salantcc[9]='.';
               sprintf(salnvoc,"%12.2f",atof(saldo_nvo));
               salnvoc[9]='.';
               primervez=1;
              }

            if (strcmp(signo_tra,"C") == 0)
              {
               sprintf(importec,"%12.2f",(atof(importe)*-1));
               importec[9]='.';
               sprintf(dolaresc,"%12.2f",(atof(dolares)*-1));
               dolaresc[9]='.';
              }
            else
              {
               sprintf(importec,"%12.2f",atof(importe));
               importec[9]='.';
               sprintf(dolaresc,"%12.2f",atof(dolares));
               dolaresc[9]='.';
              }

           /* if (strcmp(estatus, " ") == 0 && strcmp(cuenta_banamex,"                ") != 0 && strcmp(cuenta_citi,"                ") != 0 )
              {
               strcpy(num_cuenta1,cuenta_citi);
              } */

            if (strcmp(estatus, " ") == 0 && strlen(cuenta_banamex) == 16 && strlen(cuenta_citi) == 16)
              {
               strcpy(num_cuenta1,cuenta_citi);
              }

            sprintf(detalle,"%-8s",fecha);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-8s",detalle,fechaval);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-24s",detalle,thsnombre);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-16s",detalle,num_cuenta1);
            sprintf(detalle,"%s%s",detalle," ");
            if (strlen(eje_num_nom) == 15)
              {
               sprintf(detalle,"%s%s",detalle,eje_num_nom);
              }
            else
              {
               sprintf(detalle,"%s%-15s",detalle,eje_num_nom);
              }
            sprintf(detalle,"%s%s",detalle," ");
            if (strlen(eje_centro_c) == 15)
              {
               sprintf(detalle,"%s%s",detalle,eje_centro_c);
              }
            else
              {
               sprintf(detalle,"%s%-15s",detalle,eje_centro_c);
              }
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-5s",detalle,unit_level);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-4s",detalle,MCC);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%s",detalle,importec);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%s",detalle,dolaresc);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-26s",detalle,nom_neg);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-3s",detalle,pais);
            sprintf(detalle,"%s%s",detalle,"  ");
            sprintf(detalle,"%s%-3s",detalle,ciudad);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-3s",detalle,estado);
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%-1s",detalle,"M");
            sprintf(detalle,"%s%s",detalle," ");
            sprintf(detalle,"%s%s",detalle,cta_contable);

            /* printf("%s\n",detalle); */

            if ((fprintf(archivo,"%s\n",detalle)) == -1)
              {
               printf("Fecha proceso: %s\n", fechayhora);
               printf("Nombre archivo: %s\n", nombrearchivo);
               printf("Programa: creaDerSBF.c \n");
               printf("Error: No grabo el registro en el archivo rpt012.TXT\n");
               exit(1);
              }

            strcpy(detalle,"\0");

            strcpy(num_cuentaant,num_cuenta11);
            strcpy(num_cuenta11,num_cuenta);
            flag=1;

            fin_hisneg=dbnextrow(q_dbproc_hisneg);
            /* Se genera la variable num_cuenta para cortes sin roll_over,eje_digt */
            sprintf(num_cuenta,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_num);

           } /* fin del segundo set de datos hisneg */

         if (flag != 0)
           {
            while (atol(num_cuentasal) < atol(num_cuentaant) && fin_hih != NO_MORE_ROWS)
              {
               fin_hih=dbnextrow(q_dbproc_hih);
               /* Se genera la variable num_cuentasal para cortes */
               sprintf(num_cuentasal,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_numsal);
              }
            if (strcmp(num_cuentasal,num_cuentaant) == 0)
              {
               /* formatea con , montos para grabar en el archivo los saldos*/
               if ( (strcmp(tipo_reg,"E") == 0) /* && (atoi(eje_num) == 0) */ )
                 {
                  sprintf(saldos,"%s%s",saldos,salantc);
                 }
               else
                 {
                  /* sprintf(saldos,"%s%s",saldos,salantcc); */
                  sprintf(saldos,"%s%s",saldos,"        0.00");
                 }
               /* RSP saldos[0]="\0"; */
               memset (saldos, '\0', sizeof( saldos ) );
               sprintf(saldos,"%s","                  ");
               sprintf(saldos,"%s%s",saldos,"Saldo Anterior  ");
               sprintf(saldos,"%s%s",saldos,"          ");
               if ( (strcmp(tipo_reg,"E") == 0) /* && (atoi(eje_num) == 0)*/ )
                 {
                  sprintf(saldos,"%s%s",saldos,salantc);
                 }
               else
                 {
                  sprintf(salnvoc,"%12.2f",atof(saldo_nvo));
                  salnvoc[9]='.';
                  sprintf(saldos,"%s%s",saldos,"        0.00");
                 }
               sprintf(saldos,"%s%s",saldos,"        ");
               sprintf(saldos,"%s%s",saldos,"    ");
               sprintf(saldos,"%s%s",saldos,"            ");
               sprintf(saldos,"%s%s",saldos,"                        ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos," ");
               if ((fprintf(archivo,"%s\n",saldos)) == -1)
                 {
                  printf("Fecha proceso: %s\n", fechayhora);
                  printf("Nombre archivo: %s\n", nombrearchivo);
                  printf("Programa: creaDerSBF.c \n");
                  printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
                  exit(1);
                 }

               /* RSP saldos[0]="\0"; */
	       memset ( saldos, '\0', sizeof ( saldos ) );
               sprintf(saldos,"%s","                  ");
               sprintf(saldos,"%s%s",saldos,"Saldo Nuevo     ");
               sprintf(saldos,"%s%s",saldos,"          ");
               sprintf(saldos,"%s%s",saldos,salnvoc);
               sprintf(saldos,"%s%s",saldos,"        ");
               sprintf(saldos,"%s%s",saldos,"    ");
               sprintf(saldos,"%s%s",saldos,"            ");
               sprintf(saldos,"%s%s",saldos,"                        ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos," ");

               if ((fprintf(archivo,"%s\n",saldos)) == -1)
                 {
                  printf("Fecha proceso: %s\n", fechayhora);
                  printf("Nombre archivo: %s\n", nombrearchivo);
                  printf("Programa: creaDerSBF.c \n");
                  printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
                  exit(1);
                 }
               fin_hih=dbnextrow(q_dbproc_hih);

               /* Se genera la variable num_cuentasal para cortes */
               sprintf(num_cuentasal,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_numsal);
               flag=0;
              } /* fin del if num_cuentasal = num_cuenta11  */
            else
              {
               /* formatea con "." a los montos para grabar en el archivo los saldos*/
               sprintf(salantc,"%12.2s","000000000000");
               salantc[9]='.';
               sprintf(salnvoc,"%12.2s","000000000000");
               salnvoc[9]='.';

               if (atof(salantc) == 0)
                 {
                  sprintf(salantc,"%s","        0.00");
                 }

               if (atof(salnvoc) == 0)
                 {
                  sprintf(salnvoc,"%s","        0.00");
                 }
               /*RSP saldos[0]="\0"; */
	       memset ( saldos, '\0', sizeof ( saldos ) );
               sprintf(saldos,"%s","                  ");
               sprintf(saldos,"%s%s",saldos,"Saldo Anterior  ");
               sprintf(saldos,"%s%s",saldos,"          ");
               sprintf(saldos,"%s%s",saldos,salantc);
               sprintf(saldos,"%s%s",saldos,"        ");
               sprintf(saldos,"%s%s",saldos,"    ");
               sprintf(saldos,"%s%s",saldos,"            ");
               sprintf(saldos,"%s%s",saldos,"                        ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos," ");
               if ((fprintf(archivo,"%s\n",saldos)) == -1)
                 {
                  printf("Fecha proceso: %s\n", fechayhora);
                  printf("Nombre archivo: %s\n", nombrearchivo);
                  printf("Programa: creaDerSBF.c \n");
                  printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
                  exit(1);
                 }

               /* RSP saldos[0]="\0"; */
	       memset ( saldos, '\0', sizeof ( saldos ) );
               sprintf(saldos,"%s","                  ");
               sprintf(saldos,"%s%s",saldos,"Saldo Nuevo     ");
               sprintf(saldos,"%s%s",saldos,"          ");
               sprintf(saldos,"%s%s",saldos,salnvoc);
               sprintf(saldos,"%s%s",saldos,"        ");
               sprintf(saldos,"%s%s",saldos,"    ");
               sprintf(saldos,"%s%s",saldos,"            ");
               sprintf(saldos,"%s%s",saldos,"                        ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos,"   ");
               sprintf(saldos,"%s%s",saldos," ");

               if ((fprintf(archivo,"%s\n",saldos)) == -1)
                 {
                  printf("Fecha proceso: %s\n", fechayhora);
                  printf("Nombre archivo: %s\n", nombrearchivo);
                  printf("Programa: creaDerSBF.c \n");
                  printf("Error: No grabo el registro en el archivo rpt012.TXT \n");
                  exit(1);
                 }
               flag=0;
               /* Se genera la variable num_cuentasal para cortes */
               sprintf(num_cuentasal,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_numsal);
              } /* fin del else del if num_cuentasal = num_cuenta11  */
           } /* fin del if flag != 0 */

         fin_thsmap=dbnextrow(q_dbproc_thsmap);

         num_cuenta1[0]='\0';

         /* Se genera la variable num_cuenta1 para grabar */
         sprintf(num_cuenta1,"%s%s%s%s%s%s",eje_pre1,gpo_banco1,empresa,eje_num1,roll_over1,eje_digit1);

         /* Se genera la variable @num_cuenta11 para grabar */
         sprintf(num_cuenta11,"%s%s%s%s",eje_pre1,gpo_banco1,emp_num1,eje_num1);

        } /* fin del primer set de datos thsmap */

      fclose(archivo);
      dbcancel(q_dbproc_hih);
      dbcancel(q_dbproc_hisneg);
      dbcancel(q_dbproc_thsmap);

     } /* fin del sigue de facturacion corporativos */
   else
     {
      dbcancel(q_dbproc_hih);
      dbcancel(q_dbproc_hisneg);
      dbcancel(q_dbproc_thsmap);
     } /* fin del else de sigue de facturacion corporativa */

   /* sigue=0;
   fin_emp=dbnextrow(q_dbproc_emp); */

  } /* fin del if tipo facturacion 'C' */

 sigue=0;
 fin_emp=dbnextrow(q_dbproc_emp);

}/* fin while principal de empresa */


  /*obtiene fecha y hora del proceso */
  time(&lcl_time);
  today = localtime(&lcl_time);
  strftime(fechayhora,20,"%m/%d/%Y %T",today);
  printf("Hora termino proceso generar archivo creaDerSBF(rpt012.TXT): %s\n",fechayhora);

 dbexit();
 exit(0);

} /* fin del main */

/*inicializamos  DB-Library. */
int CS_PUBLIC err_handler(dbproc, severity, dberr, oserr, dberrstr, oserrstr)
DBPROCESS       *dbproc;
int             severity;
int             dberr;
int             oserr;
char            *dberrstr;
char            *oserrstr;
{
if ((dbproc == NULL) || (DBDEAD(dbproc)))
  return(INT_EXIT);
else
{
  fprintf (ERR_CH, "DB-Library error:\n\t%s\n", dberrstr);
  if (oserr != DBNOERR)
	fprintf (ERR_CH, "Operating-system error:\n\t%s\n", oserrstr);
  return(INT_CANCEL);
}
}

int CS_PUBLIC msg_handler(dbproc, msgno, msgstate, severity, msgtext,
   srvname, procname, line)
DBPROCESS       *dbproc;
DBINT           msgno;
long             msgstate;
long             severity;
char            *msgtext;
char            *srvname;
char            *procname;
int     	line;
{
 extern char fechahora[20];
 extern char nombrearchivo[60];
if ((msgno != 5701) && (msgno != 5703))
{
  if (severity == 16)
  {
    printf("FechaProceso: %s\n", fechayhora);
    printf("Nombre Archivo: %s\n", nombrearchivo);
    printf("Nombre Programa: creaDerSBF.c \n");
    printf("Error %ld, Nivel severidad %ld, Estado %ld\n", (long *)msgno, (long *)severity,(long *)msgstate);
    printf("Mensaje error: \n%s\n", msgtext);
    printf("Se ejecutaba el sql: \n%s\n", sqlcmd);
    exit(1);
    /*
    fprintf (ERR_CH, "Msg %ld, Level %d, State %d\n",
    msgno, severity, msgstate);

    if (strlen(srvname) > 0)
	  fprintf (ERR_CH, "Server '%s', ", srvname);
    if (strlen(procname) > 0)
	  fprintf (ERR_CH, "Procedure '%s', ", procname);
    if (line > 0)
	  fprintf (ERR_CH, "Line %d", line);
    fprintf (ERR_CH, "\n\t%s\n", msgtext);
    return(0);
          */
  }
}
 return(0);
}
