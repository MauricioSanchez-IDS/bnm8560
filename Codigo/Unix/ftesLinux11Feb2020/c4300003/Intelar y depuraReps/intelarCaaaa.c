/*******************************************************************************
*                                                                              *
*	Program		: enviarepINTE.c                                               *
*	Porpouse	: Send the account report to the INTELAR internal server.      *
*				  by ftp services.                                             *
*	Owner		: EISSA Information Technologies Provider.                     *
*	Design		: Ing. Ivan Troy Santaella Martinez.                           *
*                                                                              *
*******************************************************************************/

/*******************************************************************************
*                        INCLUDE's                                             *
*******************************************************************************/
#include        <sys/wait.h>
#include        <unistd.h>
#include	<stdio.h>
#include	<stdlib.h>
#include	<stdarg.h>
#include	<string.h>
#include	<signal.h>
#include	<assert.h>
#include	<dirent.h>
#include	<sys/stat.h>
#include	"intelar.h"

#define		__DEBUG__

/*******************************************************************************
*                        VARIABLES GLOBLALES                                   *
*******************************************************************************/
extern DBPROCESS		*dbproc;
extern LOGINREC			*login;

extern char				sqlcmd[];
extern int				iEmpresa;

extern T_VAR_ENTORNO	vars_entorno[];
extern T_EMPRESA		empresas[];
extern T_REPORTE		reportes[];
extern long int			rg_arregloCliente[2000][4];
extern long int			rg_arregloRepre[10000][13];

/*******************************************************************************
*                        FUNCION PRINCIPAL                                     *
*******************************************************************************/
#if defined(__STDC__) || defined(__cplusplus)
int main(int argc, char *argv[])
#else
int main(argc, argv)
int argc;
char *argv[];
#endif
{
	int		n;
	// JMC int		i;
	char	*sEmpresa;
	char	sBuffer[LEN_BUFFER];
	char	sFecha[LEN_BUFFER];
	void	(*pf)();

	/* Verifica el numero de parametros. */
	if (argc != 2) {
		fprintf(stderr, "uso: %s <parametro>\n", argv[0]);
		fflush(stderr);
		exit(WARNING);
	}

	/* Obtiene y verifica la variables de entorno. */
	obtieneVarsEntorno();
	if (! verificaVarsEntorno()) {
		fprintf(stderr, "%s: Variables de entorno no definidas.\n", argv[0]);
		fflush(stderr);
		exit(WARNING);
	}
	/*muestraVarsEntorno();*/

	/* Inicializa la DB-Library. */
	if (dbinit() == FAIL) {
		fprintf(stderr, "%s: Error al inicializar DB-Library.\n", argv[0]);
		fflush(stderr);
		exit(FAILURE);
	}

	/* Instala el manejador de SIGTERM. */
	if (signal(SIGTERM, signal_handler) == SIG_ERR) {
		perror("SIGNAL");
		exit(FAILURE);
	}

	/* Instala el manejador de SIGINT. */
	if (signal(SIGINT, signal_handler) == SIG_ERR) {
		perror("SIGNAL");
		exit(FAILURE);
	}

	/* Instala los manejadores de error y mensaje de DB-Library. */
	dberrhandle((EHANDLEFUNC) err_handler);
	dbmsghandle((MHANDLEFUNC) msg_handler);

	/* Obtiene una estructura LOGINREC para la informacion del login. */
	if ((login = dblogin()) == NULL) {
		fprintf(stderr, "%s: Error al inicializar el login.\n", argv[0]);
		fflush(stderr);
		exit(FAILURE);
	}

	/* Especifica informacion del login. */
	DBSETLUSER(login, vars_entorno[GE_USER].valor);
	DBSETLPWD(login, vars_entorno[GE_PASSWORD].valor);
	DBSETLHOST(login, vars_entorno[GE_HOSTNAME].valor);
	DBSETLAPP(login, vars_entorno[GE_HOSTNAME].valor);
        DBSETLCHARSET(login,"roman8");
	
	/* Obtiene una estructura DBPROCESS para comunicacion con el servidor. */
	if ((dbproc = dbopen(login, vars_entorno[GE_SERVER].valor)) == NULL) {
		fprintf(stderr, "%s: Error al inicializar el dbproc.\n", argv[0]);
		fflush(stderr);
		exit(FAILURE);
	}

	/* Abre la base de datos. */
	if (dbuse(dbproc, vars_entorno[GE_DBASE].valor) == FAIL) {
		fprintf(stderr, "%s: Error al accesar a la base de datos %s.\n",
				argv[0], vars_entorno[GE_DBASE].valor);
		fflush(stderr);
		exit(FAILURE);
	}

	fecha_hora(sFecha);
	printf("Fecha-Hora de inicio: %s.\n", sFecha);
	chdir(getenv("DIR_ARCH"));
	printf("Directorio de archivos: %s.\n", getenv("DIR_ARCH"));

	if ((! strcmp(vars_entorno[REENVIO].valor, "TRUE")) &&
		(! strcmp(vars_entorno[VAL_ESTATUS].valor, "TRUE"))) {
		procesaTablaReportes(vars_entorno[FECHA].valor,
							vars_entorno[ESTATUS].valor);
	}
	else {
		sqlcmd[0] = NULL;
		strcpy(sqlcmd, " DELETE FROM MTCENV01 ");
		strcat(sqlcmd, " WHERE ");
		strcat(sqlcmd, " env_fecha_archivo = '");
		strcat(sqlcmd, vars_entorno[FECHA].valor);
		strcat(sqlcmd, "'");
		ejecuta_sql(sqlcmd);

		puts("Buscando directorios de empresas ...\n");
		generaEmpresas(1);
		n = generaEmpresas(0);
		pf = procesa_arch;

		for (iEmpresa = 0; iEmpresa < n; iEmpresa++) {
			sEmpresa = (char *) malloc(LEN_BUFFER);
			*sEmpresa = NULL;

			if (empresas[iEmpresa].long_emp == 3)
				sprintf(sBuffer, "%03d", atoi(empresas[iEmpresa].numero_emp));
			else if (empresas[iEmpresa].long_emp == 4)
				sprintf(sBuffer, "%04d", atoi(empresas[iEmpresa].numero_emp));
			else if (empresas[iEmpresa].long_emp == 5)
				sprintf(sBuffer, "%05d", atoi(empresas[iEmpresa].numero_emp));

			strcpy(sEmpresa, empresas[iEmpresa].prefijo_emp);
			strcat(sEmpresa, empresas[iEmpresa].banco_emp);
			strcat(sEmpresa, sBuffer);

			puts(sEmpresa);

			arbol(sEmpresa, pf);
			free(sEmpresa);
		}
		procesaTablaReportes(vars_entorno[FECHA].valor, "0,2,10");
	}

	fecha_hora(sFecha);
	printf("Fecha-Hora de termino: %s.\n", sFecha);

	dbexit();
	exit(SUCCESS);
}

/*******************************************************************************
*                        FUNCIONES DEL PROCESO                                 *
*******************************************************************************/
#if defined(__STDC__) || defined(__cplusplus)
int generaEmpresas(int band)
#else
int generaEmpresas(band)
int band;
#endif
{
	DBCHAR		prefijo_emp[LEN_CAMPO];
	DBCHAR		banco_emp[LEN_CAMPO];
	DBCHAR		numero_emp[LEN_CAMPO];
	DBCHAR		long_emp[LEN_CAMPO];
	DBCHAR		long_uni[LEN_CAMPO];
	DBCHAR		long_cli[LEN_CAMPO];
	DBCHAR		long_rep[LEN_CAMPO];
	RETCODE		result_code;
	static int	indice = 0;
	int			i = 0;

	if (! band)
		return indice;

	sqlcmd[0] = NULL;
	strcpy(sqlcmd, " SELECT ");
	strcat(sqlcmd, "   distinct ");
	strcat(sqlcmd, "   ltrim(rtrim(str(URP.eje_prefijo))), ");
	strcat(sqlcmd, "   ltrim(rtrim(str(URP.gpo_banco))), ");
	strcat(sqlcmd, "   ltrim(rtrim(str(URP.emp_num))), ");
	strcat(sqlcmd, "   ltrim(rtrim(str(PGS.pgs_long_emp))), ");
	strcat(sqlcmd, "   ltrim(rtrim(str(PGS.pgs_long_uni))), ");
	strcat(sqlcmd, "   ltrim(rtrim(str(PGS.pgs_long_cli))), ");
	strcat(sqlcmd, "   ltrim(rtrim(str(PGS.pgs_long_rep))) ");
	strcat(sqlcmd, " FROM ");
	strcat(sqlcmd, "   MTCURP01 URP, ");
	strcat(sqlcmd, "   MTCPGS01 PGS ");
	strcat(sqlcmd, " WHERE ");
	strcat(sqlcmd, "   URP.eje_prefijo = PGS.pgs_rep_prefijo and ");
	strcat(sqlcmd, "   URP.gpo_banco = PGS.pgs_rep_banco ");
	strcat(sqlcmd, " and  PGS.pgs_tipo_prod='C' ");
	strcat(sqlcmd, " ORDER BY ");
	strcat(sqlcmd, "   URP.eje_prefijo, URP.gpo_banco, URP.emp_num ");

	dbcmd(dbproc, sqlcmd);
	if (dbsqlexec(dbproc) == FAIL) {
		fprintf(stderr, "Error al ejecutar SQL: %s.\n", sqlcmd);
		fflush(stderr);
		exit(FAILURE);
	}

	while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS) {
		if (result_code == SUCCEED) {
			dbbind(	dbproc, 1, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) prefijo_emp);
			dbbind(	dbproc, 2, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) banco_emp);
			dbbind(	dbproc, 3, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) numero_emp);
			dbbind(	dbproc, 4, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) long_emp);
			dbbind(	dbproc, 5, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) long_uni);
			dbbind(	dbproc, 6, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) long_cli);
			dbbind(	dbproc, 7, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) long_rep);

			while (dbnextrow(dbproc) != NO_MORE_ROWS) {
				strcpy(empresas[indice].prefijo_emp, prefijo_emp);
				strcpy(empresas[indice].banco_emp, banco_emp);
				strcpy(empresas[indice].numero_emp, numero_emp);
                                printf("Empresa %s %s %s \n",prefijo_emp,banco_emp,numero_emp);
				empresas[indice].long_emp = atoi(long_emp);
				empresas[indice].long_uni = atoi(long_uni);
				empresas[indice].long_cli = atoi(long_cli);
				empresas[indice].long_rep = atoi(long_rep);
				++indice;
			}
		}
	}

	for (i = 0; i < indice; ++i) {
		catClie(atoi(empresas[i].prefijo_emp),
				atoi(empresas[i].banco_emp),
				empresas[i].numero_emp,
				rg_arregloCliente);

		catRpr(	atoi(empresas[i].prefijo_emp),
				atoi(empresas[i].banco_emp),
				empresas[i].numero_emp,
				rg_arregloRepre);
	}
	return 0;
}

void catClie(iprefijo, ibanco, cempresas, rg_iNumerosClientes)
int			iprefijo;
int			ibanco;
char		cempresas[5000];
long int	rg_iNumerosClientes[2000][4];
{
	static 	int iIndiceRen = 0;
	char	cpref[5];
	char	cbanc[3];
	char	cempr[5000];

	DBCHAR	iEjePrefijo[5];
	DBCHAR	iGrupoBanco[3];
	DBCHAR	iNumeroEmpresa[6];
	DBCHAR	iNumeroCliente[13];
	// JMC RETCODE result_code;

	sprintf(cpref, "%d", iprefijo);
	sprintf(cbanc, "%d", ibanco);
	strcpy(cempr, cempresas);
	
	strcpy(sqlcmd, " select ltrim(convert(char(4), eje_prefijo)), \n");
	strcat(sqlcmd, " ltrim(convert(char(2), gpo_banco)), \n");
	strcat(sqlcmd, " ltrim(convert(char(5), emp_num)), \n");
	strcat(sqlcmd, " ltrim(convert(char(12), cliente_num)) \n");
	strcat(sqlcmd, " from MTCCLI01 \n");
	strcat(sqlcmd, " where eje_prefijo = \n");
	strcat(sqlcmd, cpref);
	strcat(sqlcmd, " and gpo_banco = \n");
	strcat(sqlcmd, cbanc);
	strcat(sqlcmd, " and emp_num in( \n");
	strcat(sqlcmd, cempr);
	strcat(sqlcmd, " ) \n");
	strcat(sqlcmd, " order by eje_prefijo, gpo_banco, emp_num \n");
	
	dbcmd(dbproc, sqlcmd);
	if (dbsqlexec(dbproc) == FAIL) {
		fprintf(stderr, "Error al ejecutar SQL: %s.\n", sqlcmd);
		fflush(stderr);
		return;
	}
	
	dbresults(dbproc);
	if (DBROWS(dbproc) != SUCCEED) {
		return;
	}
	
	dbbind(dbproc, 1, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iEjePrefijo);
	dbbind(dbproc, 2, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iGrupoBanco);
	dbbind(dbproc, 3, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroEmpresa);
	dbbind(dbproc, 4, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroCliente);
	
	while (dbnextrow(dbproc) != NO_MORE_ROWS) {
		rg_iNumerosClientes[iIndiceRen][0] = atoi(iEjePrefijo);
		rg_iNumerosClientes[iIndiceRen][1] = atoi(iGrupoBanco);
		rg_iNumerosClientes[iIndiceRen][2] = atoi(iNumeroEmpresa);
		rg_iNumerosClientes[iIndiceRen][3] = atol(iNumeroCliente);
                printf("Cliente %d %d %d %ld \n",atoi(iEjePrefijo),atoi(iGrupoBanco),atoi(iNumeroEmpresa),atol(iNumeroCliente));
		iIndiceRen++;
	}
}

void catRpr(iprefijo, ibanco, cempresas, rg_iNumeroRepresentantes)
int		iprefijo;
int 		ibanco;
char 		cempresas[5000];
long int	rg_iNumeroRepresentantes[10000][13];
{
	static	int iIndiceRen = 0;
	char	cpref[5];
	char	cbanc[3];
	char	cempr[5000];
	
	DBCHAR	iEjePrefijo[5];
	DBCHAR	iGrupoBanco[3];
	DBCHAR	iNumeroEmpresa[6];
	DBCHAR	iNumeroUnidad[15];
	DBCHAR	iNumeroRepres1[3];
	DBCHAR	iNumeroRepres2[3];
	DBCHAR	iNumeroRepres3[3];

	DBCHAR	iNumeroRepres4[3];
	DBCHAR	iNumeroRepres5[3];
	DBCHAR	iNumeroRepres6[3];
	DBCHAR	iNumeroRepres7[3];
	DBCHAR	iNumeroRepres8[3];
	DBCHAR	iNumeroRepres9[3];

	// JMC RETCODE	result_code;
	
	sprintf(cpref, "%d", iprefijo);
	sprintf(cbanc, "%d", ibanco);
	strcpy(cempr, cempresas);
	
	strcpy(sqlcmd, " select ltrim(convert(char(4),eje_prefijo)), \n");
	strcat(sqlcmd, " ltrim(convert(char(2), gpo_banco)), \n");
	strcat(sqlcmd, " ltrim(convert(char(5), emp_num)), \n");
	strcat(sqlcmd, " ltrim(convert(char(15), unit_id)), \n");
	strcat(sqlcmd, " substring(unit_head_name,1,2), \n");
	strcat(sqlcmd, " substring(unit_head_name,3,2), \n");
	strcat(sqlcmd, " substring(unit_head_name,5,2), \n");

	strcat(sqlcmd, " substring(unit_head_name,7,2), \n");
	strcat(sqlcmd, " substring(unit_head_name,9,2), \n");
	strcat(sqlcmd, " substring(unit_head_name,11,2), \n");
	strcat(sqlcmd, " substring(unit_head_name,13,2), \n");
	strcat(sqlcmd, " substring(unit_head_name,15,2), \n");
	strcat(sqlcmd, " substring(unit_head_name,17,2) \n");

	strcat(sqlcmd, " from MTCUNI01 \n");
	strcat(sqlcmd, " where eje_prefijo=\n");
	strcat(sqlcmd, cpref);
	strcat(sqlcmd, " and gpo_banco=\n");
	strcat(sqlcmd, cbanc);
	strcat(sqlcmd, " and emp_num in( \n");
	strcat(sqlcmd, cempr);
	strcat(sqlcmd, " ) ");
	strcat(sqlcmd, " order by eje_prefijo, gpo_banco, emp_num, unit_id \n" );
	
	dbcmd(dbproc, sqlcmd);
	if (dbsqlexec(dbproc) == FAIL) {
		fprintf(stderr, "Error al ejecutar SQL: %s.\n", sqlcmd);
		fflush(stderr);
		return;
	}

	dbresults(dbproc);
	if (DBROWS(dbproc) != SUCCEED) {
		return;
	}
	
	dbbind(dbproc, 1, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iEjePrefijo);
	dbbind(dbproc, 2, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iGrupoBanco);
	dbbind(dbproc, 3, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroEmpresa);
	dbbind(dbproc, 4, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroUnidad);
	dbbind(dbproc, 5, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres1);
	dbbind(dbproc, 6, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres2);
	dbbind(dbproc, 7, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres3);
	
	dbbind(dbproc, 8, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres4);
	dbbind(dbproc, 9, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres5);
	dbbind(dbproc, 10, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres6);
	dbbind(dbproc, 11, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres7);
	dbbind(dbproc, 12, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres8);
	dbbind(dbproc, 13, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) iNumeroRepres9);

	while (dbnextrow(dbproc) != NO_MORE_ROWS) {
		rg_iNumeroRepresentantes[iIndiceRen][0] = atoi(iEjePrefijo);
		rg_iNumeroRepresentantes[iIndiceRen][1] = atoi(iGrupoBanco);
		rg_iNumeroRepresentantes[iIndiceRen][2] = atoi(iNumeroEmpresa);
		rg_iNumeroRepresentantes[iIndiceRen][3] = atoi(iNumeroUnidad);
		rg_iNumeroRepresentantes[iIndiceRen][4] = atoi(iNumeroRepres1);
		rg_iNumeroRepresentantes[iIndiceRen][5] = atoi(iNumeroRepres2);
		rg_iNumeroRepresentantes[iIndiceRen][6] = atoi(iNumeroRepres3);

		rg_iNumeroRepresentantes[iIndiceRen][7] = atoi(iNumeroRepres4);
		rg_iNumeroRepresentantes[iIndiceRen][8] = atoi(iNumeroRepres5);
		rg_iNumeroRepresentantes[iIndiceRen][9] = atoi(iNumeroRepres6);
		rg_iNumeroRepresentantes[iIndiceRen][10] = atoi(iNumeroRepres7);
		rg_iNumeroRepresentantes[iIndiceRen][11] = atoi(iNumeroRepres8);
		rg_iNumeroRepresentantes[iIndiceRen][12] = atoi(iNumeroRepres9);
                printf("Representante %d %d %d %ld %d %d %d %d %d %d %d %d %d %d\n",atoi(iEjePrefijo),atoi(iGrupoBanco),atoi(iNumeroEmpresa),atol(iNumeroUnidad),atoi(iNumeroRepres1),atoi(iNumeroRepres2),atoi(iNumeroRepres3),atoi(iNumeroRepres4),atoi(iNumeroRepres4),atoi(iNumeroRepres5),atoi(iNumeroRepres6),atoi(iNumeroRepres7),atoi(iNumeroRepres8),atoi(iNumeroRepres9));
		iIndiceRen++;
	}
}

#if defined(__STDC__) || defined(__cpluplus)
void arbol(const char *psNombreDir, void (*pf)(const char *))
#else
void arbol(psNombreDir, pf)
char *psNombreDir;
void (*pf)();
#endif
{
	DIR				*pdirDirectorio;
	struct dirent	*pdirentEntradaDir;
	struct stat		statInfoArchivo;
	char			sNombreArchivo[LEN_BUFFER];
	int				iCont;

	if ((pdirDirectorio = opendir(psNombreDir)) == NULL)
		return;

	for (iCont = 0; iCont < 2; iCont++)
		(void) readdir(pdirDirectorio);

	while ((pdirentEntradaDir = readdir(pdirDirectorio)) != NULL) {
		sprintf(sNombreArchivo, "%s/%s",
				psNombreDir,
				pdirentEntradaDir->d_name);
		if (stat(sNombreArchivo, &statInfoArchivo) == -1) {
			perror("STAT");
			exit(FAILURE);
		}
		if ((statInfoArchivo.st_mode & S_IFMT) == S_IFDIR)
                { 
                        memset(sNombreArchivo, '\0', LEN_BUFFER); 
                        arbol(sNombreArchivo, pf); 
                } 
		else
                  {
                        printf("SE envia el archivo %s \n",sNombreArchivo);
			(*pf)(sNombreArchivo);
                  }
	}

	closedir(pdirDirectorio);
}

#if defined(__STDC__) || defined(__cpluplus)
void procesa_arch(const char *sNombreArch)
#else
void procesa_arch(sNombreArch)
char *sNombreArch;
#endif
{
	int		i;
	int		NumeroCliente;
	char	CadenaRpr[30];
	char	sBuffer[LEN_BUFFER];
	char	sArchivo[LEN_BUFFER];
	char	*sCadena = NULL;
	char	sFecha[LEN_BUFFER];
	// JMC char	sComando[LEN_BUFFER];

	struct nodo_t	*nuevo = NULL;
	struct stat		statArchivo;
	struct tm		*ptmFechaArchivo = NULL;

	strcpy(sArchivo, sNombreArch);
	if ((sCadena = (char *) malloc(LEN_BUFFER)) == NULL) {
		perror("MALLOC");
		exit(FAILURE);
	}

	if (stat(sArchivo, &statArchivo) == FAILURE) {
		perror("STAT");
		exit(FAILURE);
	}

	if ((statArchivo.st_mode & S_IFMT) == S_IFREG) {
	/*	if (! (statArchivo.st_mode & 0111)) { */

			ptmFechaArchivo = localtime(&statArchivo.st_mtime);
			strftime(sBuffer, 9, "%Y%m%d", ptmFechaArchivo);
			strncpy(sFecha, vars_entorno[FECHA].valor, 8);

			if (strncmp(sFecha, sBuffer, 8)) return;
			if (strlen(strchr(sArchivo, '/') + 1) != 25) return;

			if ((nuevo = malloc(sizeof(struct nodo_t))) == NULL) {
				perror("MALLOC");
				exit(FAILURE);
			}

			memset(sBuffer, NULL, LEN_BUFFER);
			nuevo->prefijo = atoi(strncpy(sBuffer, sArchivo, 4));
			memset(sBuffer, NULL, LEN_BUFFER);
			nuevo->banco = atoi(strncpy(sBuffer, (sArchivo + 4), 2));
			memset(sBuffer, NULL, LEN_BUFFER);
			nuevo->empresa = atoi(strncpy(	sBuffer,
											(sArchivo + 6),
											empresas[iEmpresa].long_emp));
			strncpy(nuevo->unidad,
					(sArchivo + 6 + empresas[iEmpresa].long_emp + 10),
					empresas[iEmpresa].long_uni);
			*(nuevo->unidad + empresas[iEmpresa].long_uni) = NULL;
			strcpy(nuevo->arch_original, getenv("DIR_ARCH"));
			strcat(nuevo->arch_original, "/");
			strcat(nuevo->arch_original, sArchivo);

			/*sprintf(sComando, "%s/%s %s",
					getenv("DIR_CARGA"),
					"add_cr.sh",
					nuevo->arch_original);
			system(sComando);*/

			NumeroCliente = extraNumCli(	nuevo->prefijo,
											nuevo->banco,
											nuevo->empresa,
											rg_arregloCliente);
		        memset(CadenaRpr,'\0',sizeof(CadenaRpr));

			strcpy(CadenaRpr, extraNumRpr(	nuevo->prefijo,
											nuevo->banco,
											nuevo->empresa,
											atoi(nuevo->unidad),
											rg_arregloRepre));

			strftime(nuevo->fcreacion_arch, 9, "%Y%m%d", ptmFechaArchivo);
			*(nuevo->fcreacion_arch + 8) = NULL;
			strcpy(nuevo->fenvio_arch, "");
			nuevo->estatus = 2;

			memset(nuevo->arch_destino, NULL, 512);
			sprintf(nuevo->arch_destino, "%012d", NumeroCliente);
			strcat(nuevo->arch_destino, "TC");
			strcat(nuevo->arch_destino, "xx");
			memset(sBuffer, NULL, LEN_BUFFER);
			strncpy(sBuffer, strchr(sArchivo, '/') + 5, 4);
			strcat(nuevo->arch_destino, sBuffer);
			sprintf(nuevo->arch_destino, "%s%s",
					nuevo->arch_destino,
					nuevo->unidad);
			strncat(nuevo->arch_destino, strchr(sArchivo, '/') + 19, 3);
			strcat(nuevo->arch_destino, vars_entorno[ARCH_EXT].valor);

			memset(sBuffer, NULL, LEN_BUFFER);
			sprintf(sBuffer, "%d", atoi(nuevo->unidad));
			strcpy(nuevo->unidad, sBuffer);

			for (i = 1; i <= 9; i++) {

				memset(sCadena, NULL, LEN_BUFFER);
				elem_n(sCadena, CadenaRpr, i);
				nuevo->representante = atoi(sCadena);

				if (! nuevo->representante) continue;
				*(nuevo->arch_destino + 14) = sCadena[0];
				*(nuevo->arch_destino + 15) = sCadena[1];

				fprintf(stdout, "%s ->\n%s\n\n",
						nuevo->arch_original, nuevo->arch_destino);
				fflush(stdout);

				sprintf(sqlcmd,
						"%s\n(%d,%d,%d,'%s',%d,'%s','%s','%s','%s',%d,%d)",
						"INSERT INTO MTCENV01 VALUES",
						nuevo->prefijo, nuevo->banco, nuevo->empresa,
						nuevo->unidad, nuevo->representante,
						nuevo->arch_original, nuevo->arch_destino,
						nuevo->fcreacion_arch, nuevo->fenvio_arch,
						nuevo->estatus, 1);

/*                                printf(" sqlcmd : %s \n", sqlcmd);*/

				ejecuta_sql(sqlcmd);

			}

		/* } */
	}
}

#if defined(__STDC__) || defined(__cplusplus)
void procesaTablaReportes(char *sFecha, char *sEstados)
#else
void procesaTablaReportes(sFecha, sEstados)
char	*sFecha;
char	*sEstados;
#endif
{
	int			i = 0, n = 0;
	int			estado;

	time_t 		timeHoraActual;
	struct tm	*tmFechaActual;
	char		sFechaEnvio[LEN_BUFFER];

	DBCHAR		a_origen[LEN_BUFFER];
	DBCHAR		a_destino[LEN_BUFFER];
	RETCODE		result_code;

	sqlcmd[0] = NULL;
	strcpy(sqlcmd, " SELECT ");
	strcat(sqlcmd, "   ltrim(rtrim(ENV.env_arch_origen)), ");
	strcat(sqlcmd, "   ltrim(rtrim(ENV.env_arch_dest)) ");
	strcat(sqlcmd, " FROM ");
	strcat(sqlcmd, "   MTCENV01 ENV ");
	strcat(sqlcmd, " WHERE ");
	strcat(sqlcmd, "   ENV.env_estatus in (");
	strcat(sqlcmd, sEstados);
	strcat(sqlcmd, ") and ENV.env_fecha_archivo = '");
	strcat(sqlcmd, sFecha);
	strcat(sqlcmd, "'");

	dbcmd(dbproc, sqlcmd);
	if (dbsqlexec(dbproc) == FAIL) {
		fprintf(stderr, "Error al ejecutar SQL: %s.\n", sqlcmd);
		exit(FAILURE);
	}

	while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS) {
		if (result_code == SUCCEED) {

                        memset(a_origen,'\0', LEN_BUFFER);
                        memset(a_destino,'\0', LEN_BUFFER);

                        memset(reportes[n].archivo_origen,'\0', LEN_BUFFER);
                        memset(reportes[n].archivo_destino,'\0', LEN_BUFFER);

			dbbind(dbproc, 1, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) a_origen);
			dbbind(dbproc, 2, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) a_destino);

			while (dbnextrow(dbproc) != NO_MORE_ROWS) {
				strcpy(reportes[n].archivo_origen, a_origen);
				strcpy(reportes[n].archivo_destino, a_destino);
                                printf("PROCESA TABLA ARCH  %s %s %d\n",a_origen,a_destino,n);
				++n;
			}
		}
	}

	time(&timeHoraActual);
	tmFechaActual = localtime(&timeHoraActual);
	strftime(sFechaEnvio, 9, "%Y%m%d", tmFechaActual);

	printf("No. de reportes: %d.\n", n);
	for (i = 0; i < n; ++i) {
		estado = 0;
		estado = envia_ftp(	reportes[i].archivo_origen,
					reportes[i].archivo_destino);
		(estado == 127)? (estado = 10): (estado = 0);
		strcpy(sqlcmd, " UPDATE MTCENV01 ");
		strcat(sqlcmd, " SET env_estatus = ");
		sprintf(sqlcmd, "%s %d,", sqlcmd, estado);
		strcat(sqlcmd, " env_fecha_envio = ");
		sprintf(sqlcmd, "%s '%s'", sqlcmd, sFechaEnvio);
		strcat(sqlcmd, " WHERE env_arch_dest = '");
		strcat(sqlcmd, reportes[i].archivo_destino);
		strcat(sqlcmd, "'");
		ejecuta_sql(sqlcmd);
	}
}

#if defined(__STDC__) || (__cplusplus)
int envia_ftp(char *arch1, char *arch2)
#else
int envia_ftp(arch1, arch2)
char *arch1;
char *arch2;
#endif
{
	int pid, estado, ret;
	char comando[512];

	pid = fork();
	switch (pid) {
		case -1:
			perror("FORK");
			exit(FAILURE);
	 	case 0:
			sprintf(comando, "%s/%s %s %s",
					getenv("DIR_CARGA"), "intelar.ftp", arch1, arch2);

			/* ret = execl("/usr/bin/sh", "sh", "-c", comando, (char *)0); */

                        ret = system(comando);

                        if (ret != 0)
                           printf("Error a realizar comando de envio a Intelar, ret : %d \n",ret);

			exit(10);
		default:
			waitpid(pid, &estado, 0);
			return WEXITSTATUS(estado);
	}
}

int extraNumCli(iprefijo, ibanco, iempresa, rg_arreglo)
int		iprefijo;
int		ibanco;
int		iempresa;
long int	rg_arreglo[1000][4];
{
	int iIndiceFila, isigue	= 1, inocli	= 0;
	
	for (iIndiceFila = 0; isigue > 0; ++iIndiceFila) {
		if ((iprefijo == rg_arreglo[iIndiceFila][0])	&&
			(ibanco == rg_arreglo[iIndiceFila][1])		&&
			(iempresa == rg_arreglo[iIndiceFila][2])) {
			inocli = rg_arreglo[iIndiceFila][3];
			if (inocli == 0) {
				printf(	"No hay cliente para: %d %d %d.\n",
						iprefijo, ibanco, iempresa);
				return 0;
			}
			return inocli;
		}
		isigue = rg_arreglo[iIndiceFila][0];
	}
	return 0;
}

char *extraNumRpr(iprefijo, ibanco, iempresa, iunidad, rg_arreglo)
int		iprefijo;
int		ibanco;
int		iempresa;
int		iunidad;
long int	rg_arreglo[10000][13];
{
	char      	cCadenaRepre[100];
	static char	*pCadenaRepre;
	int		iIndiceFila, isigue = 1;

        

        memset(cCadenaRepre, '\0', 100);

	for (iIndiceFila = 0; isigue > 0; ++iIndiceFila) {

		if ((iprefijo == rg_arreglo[iIndiceFila][0])	&&
			(ibanco == rg_arreglo[iIndiceFila][1])		&&
			(iempresa == rg_arreglo[iIndiceFila][2])	&&
			(iunidad == rg_arreglo[iIndiceFila][3])) {
			if (rg_arreglo[iIndiceFila][4] == 0) {
				printf( "1)No hay representantes para: %d %d %d %d.\n",
						iprefijo, ibanco, iempresa, iunidad);
                                pCadenaRepre=cCadenaRepre;
                                return pCadenaRepre;
			}
			sprintf(cCadenaRepre, "%02ld|%02ld|%02ld|%02ld|%02ld|%02ld|%02ld|%02ld|%02ld|",
					rg_arreglo[iIndiceFila][4],
					rg_arreglo[iIndiceFila][5],
					rg_arreglo[iIndiceFila][6],
					rg_arreglo[iIndiceFila][7],
					rg_arreglo[iIndiceFila][8],
					rg_arreglo[iIndiceFila][9],
					rg_arreglo[iIndiceFila][10],
					rg_arreglo[iIndiceFila][11],
					rg_arreglo[iIndiceFila][12]);

                        printf("cCadenaRepre : %s \n",cCadenaRepre);

                        pCadenaRepre=cCadenaRepre;
			return pCadenaRepre;
		}
		isigue = rg_arreglo[iIndiceFila][0];
	}
        printf( "2)No hay representantes para: %d %d %d %d.\n",
                        iprefijo, ibanco, iempresa, iunidad);
        pCadenaRepre=cCadenaRepre;
        return pCadenaRepre;
}
