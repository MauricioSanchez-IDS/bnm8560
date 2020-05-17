#if USE_SCCSID
static char     Sccsid[] = { "@(#) repGen.c 87.1 12/10/01" };
#endif							/* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>


#define TOTALPARAMETROS 2
#define         LONGCADENALARGA 500   
#define         SQLBUFLEN       10000 
#define         ERR_CH          stderr

/*
 * Forward declarations of the error handler and message handler. 
 */
int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();
void            dbVars();

char            fechayhora[20];
char            nombrearchivo[60];
char            sqlcmd[20000];

main(argc, argv)
  int             argc;
  char           *argv[];
{
  DBPROCESS      *q_dbproc;
  LOGINREC       *login;

  time_t          lcl_time;
  struct tm      *today;

  char            rep_clave[8 + 1];
  char            rep_nombre[30 + 1];
  char            prefijo[4 + 1];
  char            banco[2 + 1];
  char            empresa[8 + 1];
  char            unidad[15 + 1];
  char            rep_frecuencia[1 + 1];
  char            rep_detalle[1 + 1];
  char            rep_profundidad[1 + 1];
  char            rep_programa[20 + 1];
  char            nomArchTxt[16 + 1];

  char            cb_user[10];
  char            cb_password[10];
  char            cb_server[10];
  char            cb_hostname[10];
  char            cb_dbase[10];

  char            directorio_archivo[50];
  /*
   * char nombrearchivo_temp[100];
   */
  char            fecha[8 + 1];
  char            hora[8 + 1];

  char            reporte[300 + 1];
  char            directorio_bin[50 + 1];
  char            directorio_temp[80 + 1];
  char            nombrearchivo_bin[80 + 1];
  char            nombrearchivo_temp[80 + 1];
  char            creacarpeta[80 + 1];

  char            banCic[1 + 1];
  char            banMes[1 + 1];
  char            banTri[1 + 1];
  char            banA_o[1 + 1];
  char            banResultado[4 + 1];
  char            fechaCorte[4 + 1];
  char            corte[4 + 1];

  RETCODE         result_code;

  if (argc > TOTALPARAMETROS) {
	printf("Programa: repGen.c\n");
	printf("Numero de argumentos no validos para el programa repGen.c\n");
	exit(1);
  }

  if (argv[1] == '\0') {
	time(&lcl_time);
	today = localtime(&lcl_time);
	strftime(fechayhora, 20, "%Y%m%d %T", today);
  } else {
	sprintf(fechayhora, "%s", argv[1]);
  }

  if (dbinit() == FAIL) {
	printf("Fecha proceso: %s\n", fechayhora);
	printf("Nombre archivo: %s\n", nombrearchivo);
	printf("Programa: repGen.c \n");
	printf("Error: No se inicializaron dblibrarys de C en repGen.c \n");
	exit(1);
  }

  dberrhandle((EHANDLEFUNC) err_handler);
  dbmsghandle((MHANDLEFUNC) msg_handler);

  /*
   * obtenemos variables de ambiente
   */
  sprintf(cb_user, "%s", getenv("GE_USER"));
  sprintf(cb_password, "%s", getenv("GE_PASSWORD"));
  sprintf(cb_dbase, "%s", getenv("GE_DBASE"));
  sprintf(cb_server, "%s", getenv("GE_SERVER"));
  sprintf(cb_hostname, "%s", getenv("GE_HOSTNAME"));
  sprintf(directorio_temp, "%s", getenv("DIR_ARCH"));
  sprintf(directorio_bin, "%s", getenv("DIR_CARGA"));
  sprintf(directorio_archivo, "%s", getenv("DIR_ARCH"));
  sprintf(creacarpeta, "%s%s", "mkdir -p ", directorio_archivo);

  if (((strlen(cb_user) == 0) || (strlen(cb_password) == 0) || (strlen(cb_server) == 0) || (strlen(cb_hostname) == 0) || (strlen(cb_dbase) == 0)
	   || (strlen(directorio_archivo) == 0))) {
	printf("Fecha proceso: %s\n", fechayhora);
	printf("Nombre archivo: %s\n", nombrearchivo);
	printf("Programa: regGen.c \n");
	printf("Error: debe verificar las variables de ambiente\n");
	exit(1);
  }

  login = dblogin();
  DBSETLUSER(login, cb_user);
  DBSETLPWD(login, cb_password);
  DBSETLAPP(login, cb_hostname);
  DBSETLHOST(login, cb_hostname);
  DBSETLCHARSET(login,"roman8"); 

  q_dbproc = dbopen(login, cb_server);

  dbuse(q_dbproc, cb_dbase);

  /*
   * obtengo datos de los reportes que se tienen que generar
   */
  sprintf(sqlcmd, "declare @fechaHoy char(8)\n ");
  strcat(sqlcmd, "declare @dia    int \n");
  strcat(sqlcmd, "declare @mesIni int \n");
  strcat(sqlcmd, "declare @mesSig int \n");
  strcat(sqlcmd, "declare @triIni int \n");
  strcat(sqlcmd, "declare @triSig int \n");
  strcat(sqlcmd, "declare @anuIni int \n");
  strcat(sqlcmd, "declare @anuSig int \n");
  strcat(sqlcmd, "declare @banCic char(1) \n");
  strcat(sqlcmd, "declare @banMes char(1) \n");
  strcat(sqlcmd, "declare @banTri char(1) \n");
  strcat(sqlcmd, "declare @banA_o char(1) \n");
  strcat(sqlcmd, "select @banCic = '0' \n");
  strcat(sqlcmd, "select @banMes = '0' \n");
  strcat(sqlcmd, "select @banTri = '0' \n");
  strcat(sqlcmd, "select @banA_o = '0' \n");

  /*
   * strcat(sqlcmd, "select @fechaHoy = convert(char(8),getdate(),112) \n "); strcat(sqlcmd, "select @fechaHoy ='20011218' \n ");
   */

  sprintf(sqlcmd, "%s select @fechaHoy = '%s' \n ", sqlcmd, fechayhora);
  strcat(sqlcmd, "select @dia    = datepart(dd,@fechaHoy) \n");
  strcat(sqlcmd, "select @mesIni = datepart(mm,@fechaHoy) \n");
  strcat(sqlcmd, "select @mesSig = datepart(mm,dateadd(dd,1,@fechaHoy))\n ");
  strcat(sqlcmd, "select @triIni = datepart(qq,@fechaHoy) \n");
  strcat(sqlcmd, "select @triSig = datepart(qq,dateadd(dd,1,@fechaHoy)) \n");
  strcat(sqlcmd, "select @anuIni = datepart(yy,@fechaHoy) \n");
  strcat(sqlcmd, "select @anuIni = datepart(yy,@fechaHoy) \n");
  strcat(sqlcmd, "select @anuSig = datepart(yy,dateadd(dd,1,@fechaHoy)) \n");
  strcat(sqlcmd, "if exists(select distinct emp_dia_corte from MTCEMP01 \n");
  strcat(sqlcmd, "where emp_dia_corte = datepart(dd,dateadd(dd,-1,@fechaHoy\n");
  strcat(sqlcmd, "))) select @banCic = '1' else select @banCic = '0' \n");
  strcat(sqlcmd, "if @mesIni  <> @mesSig  select @banMes = '1'  \n");
  strcat(sqlcmd, "else select @banMes = '0' \n");
  strcat(sqlcmd, "if @triIni  <> @triSig  select @banTri = '1' \n");
  strcat(sqlcmd, "else select @banTri = '0' \n");
  strcat(sqlcmd, "if @anuIni  <> @anuSig  select @banA_o = '1' \n");
  strcat(sqlcmd, "else select @banA_o = '0' \n");
  strcat(sqlcmd, "select @banCic  \n");
  strcat(sqlcmd, "select @banMes  \n");
  strcat(sqlcmd, "select @banTri  \n");
  strcat(sqlcmd, "select @banA_o  \n");

  /*
   * printf("%s\n\n",sqlcmd); 
   */

  dbcmd(q_dbproc, sqlcmd);
  if (dbsqlexec(q_dbproc) == FAIL) {
	printf("Fecha proceso:%s\n", fechayhora);
	printf("Nombre archivo: %s\n", nombrearchivo);
	printf("Programa: repGen.c\n");
	printf("Error al intentar traer datos de REPORTES bdsqlexec %s \n", sqlcmd);
	dbclose(q_dbproc);
	dbexit();
	exit(1);
  }

  while ((result_code = dbresults(q_dbproc)) != NO_MORE_RESULTS) {
	/*
	 * printf("comando %d\n",dbcurcmd(q_dbproc));
	 */
	if (dbcurcmd(q_dbproc) == 22)
	  dbbind(q_dbproc, 1, NTBSTRINGBIND, 0, (BYTE DBFAR *)banCic);

	if (dbcurcmd(q_dbproc) == 23)
	  dbbind(q_dbproc, 1, NTBSTRINGBIND, 0, (BYTE DBFAR *)banMes);

	if (dbcurcmd(q_dbproc) == 24)
	  dbbind(q_dbproc, 1, NTBSTRINGBIND, 0, (BYTE DBFAR *)banTri);

	if (dbcurcmd(q_dbproc) == 25)
	  dbbind(q_dbproc, 1, NTBSTRINGBIND, 0, (BYTE DBFAR *)banA_o);

	while (dbnextrow(q_dbproc) != NO_MORE_ROWS) {
	}
  }

  /*
   * se obtiene dia de corte con formato mmdd 
   */
  /*
   * sprintf(sqlcmd,"select substring(convert(char(8), dateadd(dd, -1, getdate()), 112), 5, 4)\n"); 
   */
  sprintf(sqlcmd, "select substring(convert(char(8), dateadd(dd, -1, '%s'), 112), 5, 4) \n", fechayhora);
  dbcmd(q_dbproc, sqlcmd);
  if (dbsqlexec(q_dbproc) == FAIL) {
	printf("Fecha proceso:%s\n", fechayhora);
	printf("Nombre archivo: %s\n", nombrearchivo);
	printf("Programa: repGen.c\n");
	printf("Error al intentar traer la fecha de corte bdsqlexec %s \n", sqlcmd);
	dbclose(q_dbproc);
	dbexit();
	exit(1);
  }

  while ((result_code = dbresults(q_dbproc)) != NO_MORE_RESULTS) {
	dbbind(q_dbproc, 1, NTBSTRINGBIND, 0, (BYTE DBFAR *)fechaCorte);
	while (dbnextrow(q_dbproc) != NO_MORE_ROWS) {
	  sprintf(corte, "%s", fechaCorte);
	}
  }

  /*
   * se arma el query que evalua los reportes a generar
   */
  sprintf(sqlcmd, "select rtrim(r.report_id) \n");
  strcat(sqlcmd, ", r.report_name \n");
  strcat(sqlcmd, ", u.eje_prefijo \n");
  strcat(sqlcmd, ", u.gpo_banco \n");
  strcat(sqlcmd, ", replicate('0',(select pgs_long_emp from MTCPGS01 \n ");
  strcat(sqlcmd, "      where pgs_rep_prefijo = u.eje_prefijo \n ");
  strcat(sqlcmd, "        and pgs_rep_banco =u.gpo_banco)-char_length \n ");
  strcat(sqlcmd, "          (ltrim(str(u.emp_num))))+ltrim(str(u.emp_num)) \n");
  strcat(sqlcmd, ", u.unit_id \n");
  strcat(sqlcmd, ", u.reporting_freq \n");
  strcat(sqlcmd, ", u.reporting_depth \n");
  strcat(sqlcmd, ", u.reporting_details \n");
  strcat(sqlcmd, ", rtrim(r.report_prg) \n");
  strcat(sqlcmd, "from MTCREP01 r, MTCURP01 u, MTCEMP01 e\n");
  strcat(sqlcmd, "where u.reporting_gen = 'Y' \n ");
  strcat(sqlcmd, "  and u.eje_prefijo = e.eje_prefijo \n");
  strcat(sqlcmd, "  and u.gpo_banco = e.gpo_banco \n");
  strcat(sqlcmd, "  and u.emp_num = e.emp_num \n");
  strcat(sqlcmd, "  and r.report_id = u.report_id \n ");
  /* se eliminan estas lineas porque en la tabla de MTCREP01 los campos */
  /*  supported_detail y supported_depth estan en blanco */ 
  /* strcat(sqlcmd, "  and r.supported_detail = u.reporting_details \n ");
  strcat(sqlcmd, "  and r.supported_depth = u.reporting_depth \n"); */
  strcat(sqlcmd, "  and r.supported_frequencies = u.reporting_freq  \n");
  strcat(sqlcmd, "  and r.supported_frequencies in ");
  sprintf(banResultado, "%s%s%s%s", banCic, banMes, banTri, banA_o);

  if (strcmp(banResultado, "0000") == 0)
	strcat(sqlcmd, "('D') ");
  else if (strcmp(banResultado, "0001") == 0)
	strcat(sqlcmd, "('D','Y') ");
  else if (strcmp(banResultado, "0010") == 0)
	strcat(sqlcmd, "('D','Q') ");
  else if (strcmp(banResultado, "0011") == 0)
	strcat(sqlcmd, "('D','Q','Y') ");
  else if (strcmp(banResultado, "0100") == 0)
	strcat(sqlcmd, "('D','M') ");
  else if (strcmp(banResultado, "0101") == 0)
	strcat(sqlcmd, "('D','M','Y') ");
  else if (strcmp(banResultado, "0110") == 0)
	strcat(sqlcmd, "('D','M','Q') ");
  else if (strcmp(banResultado, "0111") == 0)
	strcat(sqlcmd, "('D','M','Q','Y') ");
  else if (strcmp(banResultado, "1000") == 0)
	strcat(sqlcmd, "('D','C') ");
  else if (strcmp(banResultado, "1001") == 0)
	strcat(sqlcmd, "('D','C','Y') ");
  else if (strcmp(banResultado, "1010") == 0)
	strcat(sqlcmd, "('D','C','Q') ");
  else if (strcmp(banResultado, "1011") == 0)
	strcat(sqlcmd, "('D','C','Q','Y') ");
  else if (strcmp(banResultado, "1100") == 0)
	strcat(sqlcmd, "('D','C','M') ");
  else if (strcmp(banResultado, "1101") == 0)
	strcat(sqlcmd, "('D','C','M','Y') ");
  else if (strcmp(banResultado, "1110") == 0)
	strcat(sqlcmd, "('D','C','M','Q') ");
  else if (strcmp(banResultado, "1111") == 0)
	strcat(sqlcmd, "('D','C','M','Q','Y') ");
  else
	strcat(sqlcmd, "('x') ");

  strcat(sqlcmd, "\n and e.emp_dia_corte = \n");

  sprintf(sqlcmd, "%s datepart(dd,dateadd(dd,-1,'%s')) \n ", sqlcmd, fechayhora);

  strcat(sqlcmd, " \nOrder by 7  \n");

  /*
    jmm 
  printf("%s\n", sqlcmd);
  exit(1);
  */

  dbcmd(q_dbproc, sqlcmd);
  if (dbsqlexec(q_dbproc) == FAIL) {
	printf("Fecha proceso:%s\n", fechayhora);
	printf("Nombre archivo: %s\n", nombrearchivo);
	printf("Programa: repGen.c\n");
	printf("Error al intentar traer datos de REPORTES bdsqlexec %s \n", sqlcmd);
	dbclose(q_dbproc);
	dbexit();
	exit(1);
  }

  while ((result_code = dbresults(q_dbproc)) != NO_MORE_RESULTS) {
	dbbind(q_dbproc, 1, NTBSTRINGBIND, 0, (BYTE DBFAR *)rep_clave);
	dbbind(q_dbproc, 2, NTBSTRINGBIND, 0, (BYTE DBFAR *)rep_nombre);
	dbbind(q_dbproc, 3, NTBSTRINGBIND, 0, (BYTE DBFAR *)prefijo);
	dbbind(q_dbproc, 4, NTBSTRINGBIND, 0, (BYTE DBFAR *)banco);
	dbbind(q_dbproc, 5, NTBSTRINGBIND, 0, (BYTE DBFAR *)empresa);
	dbbind(q_dbproc, 6, NTBSTRINGBIND, 0, (BYTE DBFAR *)unidad);
	dbbind(q_dbproc, 7, NTBSTRINGBIND, 0, (BYTE DBFAR *)rep_frecuencia);
	dbbind(q_dbproc, 8, NTBSTRINGBIND, 0, (BYTE DBFAR *)rep_detalle);
	dbbind(q_dbproc, 9, NTBSTRINGBIND, 0, (BYTE DBFAR *)rep_profundidad);
	dbbind(q_dbproc, 10, NTBSTRINGBIND, 0, (BYTE DBFAR *)rep_programa);
	while (dbnextrow(q_dbproc) != NO_MORE_ROWS) {
	  sprintf(creacarpeta, "%s%s", "mkdir -p ", directorio_archivo);
	  sprintf(creacarpeta, "%s/%s%s%s", creacarpeta, prefijo, banco, empresa);
	  system(creacarpeta);
	  if (strncmp(rep_programa, "rpt002", 6) == 0)
		sprintf(nomArchTxt, "%s.TXT", rep_programa);
	  else if (strncmp(rep_programa, "rpt003", 6) == 0)
		sprintf(nomArchTxt, "%s.TXT", rep_programa);
	  else if (strncmp(rep_programa, "rpt004", 6) == 0)
		sprintf(nomArchTxt, "%s.TXT", rep_programa);
	  else if (strncmp(rep_programa, "rpt006", 6) == 0)
		sprintf(nomArchTxt, "%s.TXT", rep_programa);
	  else if (strncmp(rep_programa, "rpt007", 6) == 0)
		sprintf(nomArchTxt, "%s.TXT", rep_programa);
	  else if (strncmp(rep_programa, "rpt001", 6) == 0)
		sprintf(nomArchTxt, "%s.TXT", rep_programa);
	  else
		sprintf(nomArchTxt, "%s.TXT", rep_programa);

	  sprintf(nombrearchivo_temp, "%s/%s%s%s/%s.%'0'5s.%s", directorio_temp, prefijo, banco, empresa, fechayhora, unidad, nomArchTxt);

	  /*
	   * sprintf(nombrearchivo_temp,"%s/%s%s%s/%s.%'0'5s.%s",directorio_temp, prefijo, banco, empresa, fechayhora, unidad, rep_programa); 
	   */
	  sprintf(nombrearchivo_bin, "%s/%s", directorio_bin, rep_programa);

	  if (strncmp(rep_programa, "rpt001", 6) == 0 || strncmp(rep_programa, "rpt004", 6) == 0 || strncmp(rep_programa, "rpt007", 6) == 0)
		sprintf(reporte, "%s %s %s %s %s %s %s %s", nombrearchivo_bin, nombrearchivo_temp, prefijo, banco, empresa, unidad, corte, fechayhora);
	  else
		sprintf(reporte, "%s %s %s %s %s %s %s", nombrearchivo_bin, nombrearchivo_temp, prefijo, banco, empresa, unidad, fechayhora);

	  /*
	  printf("%s\n", reporte); 
	  */
	  system(reporte);
	}
  }
  dbexit();
  exit(STDEXIT);
}

int CS_PUBLIC
err_handler(dbproc, severity, dberr, oserr, dberrstr, oserrstr)
  DBPROCESS      *dbproc;
  int             severity;
  int             dberr;
  int             oserr;
  char           *dberrstr;
  char           *oserrstr;
{
  if ((dbproc == NULL) || (DBDEAD(dbproc)))
	return (INT_EXIT);
  else {
	fprintf(ERR_CH, "DB-Library error:\n\t%s\n", dberrstr);
	if (oserr != DBNOERR)
	  fprintf(ERR_CH, "Operating-system error:\n\t%s\n", oserrstr);
	return (INT_CANCEL);
  }
}

int CS_PUBLIC
msg_handler(dbproc, msgno, msgstate, severity, msgtext, srvname, procname, line)
  DBPROCESS      *dbproc;
  DBINT           msgno;
  int             msgstate;
  int             severity;
  char           *msgtext;
  char           *srvname;
  char           *procname;
  int             line;
{
  if ((msgno != 5701) && (msgno != 5703)) {
	if (severity == 16) {
	  fprintf(ERR_CH, "Msg %ld, Level %d, State %d\n", msgno, severity, msgstate);

	  if (strlen(srvname) > 0)
		fprintf(ERR_CH, "Server '%s', ", srvname);
	  if (strlen(procname) > 0)
		fprintf(ERR_CH, "Procedure '%s', ", procname);
	  if (line > 0)
		fprintf(ERR_CH, "Line %d", line);

	  fprintf(ERR_CH, "\n\t%s\n", msgtext);

	  /*
	   * registro del error en el archivo log
	   */
	  printf("Fecha proceso: %s\n", fechayhora);
	  printf("Nombre archivo: %s\n", nombrearchivo);
	  printf("Programa: repGen.c\n");
	  printf("Error %ld, Nivel Severidad %ld, Estado %ld \n", (long )msgno, (long )severity, (long )msgstate);
	  printf("Mensaje error: \n%s\n", msgtext);
	  printf("Se ejecuta el sql: \n%s\n", sqlcmd);
	  exit(1);
	}
  }
}
