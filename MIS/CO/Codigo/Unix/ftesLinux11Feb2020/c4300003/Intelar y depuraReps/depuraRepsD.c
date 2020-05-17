/********************************************************************************
*                                                                              						*
*	Program		: depuraRepsC.c                                               		*
*	Porpouse	: Depura reportes el primero de cada mes 					*
*	Owner		: Banamex 																*
*	Design		: YMF 																		*
*   Last Modif.: May 31,2016                                         					*
*   Modif. by :  Alejandro Pérez Hernández 										*
* 						                                                                            *
*********************************************************************************/

/*******************************************************************************
*                        INCLUDE's                                             *
*******************************************************************************/
#include	<stdio.h>
#include	<stdlib.h>
#include	<stdarg.h>
#include	<string.h>
#include	<signal.h>
#include	<assert.h>
//#include	  <sys/dirent.h>
#include	<dirent.h>
#include	<sys/stat.h>
#include    <stdlib.h>
#include	"depuraRepsC.h"
#include    <unistd.h>
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
extern long int			rg_arregloCliente[10000][4];
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
	int		i;
	char	*sEmpresa;
	char	sBuffer[LEN_BUFFER];
	char	sFecha[LEN_BUFFER];

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

        dbsetversion(DBVERSION_100);

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
        DBSETLENCRYPT(login, TRUE); 
	
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

	puts("Buscando directorios de empresas ...\n");
	generaEmpresas(1);
	n = generaEmpresas(0);
	/*pf = procesa_arch;*/

	for (iEmpresa = 0; iEmpresa < n; iEmpresa++) {
		sEmpresa = (char *) malloc(LEN_BUFFER);
		*sEmpresa = '\0';

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

		arbol(sEmpresa);
		free(sEmpresa);
	/*	procesaTablaReportes(vars_entorno[FECHA].valor, "0,2,10");*/
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

	sqlcmd[0] = '\0';
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
	strcat(sqlcmd, " and  PGS.pgs_tipo_prod='D' ");
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
}

void catClie(iprefijo, ibanco, cempresas, rg_iNumerosClientes)
int			iprefijo;
int			ibanco;
char		cempresas[10000];
long int	rg_iNumerosClientes[10000][4];
{
	static 	iIndiceRen = 0;
	char	cpref[5];
	char	cbanc[3];
	char	cempr[10000];

	DBCHAR	iEjePrefijo[5];
	DBCHAR	iGrupoBanco[3];
	DBCHAR	iNumeroEmpresa[6];
	DBCHAR	iNumeroCliente[13];
	RETCODE result_code;

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
		iIndiceRen++;
	}
}

void catRpr(iprefijo, ibanco, cempresas, rg_iNumeroRepresentantes)
int			iprefijo;
int 		ibanco;
char 		cempresas[10000];
long int	rg_iNumeroRepresentantes[10000][13];
{
	static	iIndiceRen = 0;
	char	cpref[5];
	char	cbanc[3];
	char	cempr[10000];
	
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

	RETCODE	result_code;
	
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
		iIndiceRen++;
	}
}

#if defined(__STDC__) || defined(__cpluplus)
void arbol(const char *psNombreDir)
#else
void arbol(psNombreDir)
char *psNombreDir;
#endif
{
	DIR				*pdirDirectorio;
	struct dirent	*pdirentEntradaDir;
	struct stat		statInfoArchivo;
	char			sNombreArchivo[LEN_BUFFER];
	int				iCont;
        char                   sFecha[1024];
        char                   sArchivo[1024];
        char                   sBuffer[1024];
        char                   sComando[500];

struct nodo_t   *nuevo = NULL;                      
struct stat             statArchivo;                
struct tm               *ptmFechaArchivo = NULL;    


                                                                     

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
                        printf("INI Este es directorio %s\n",sNombreArchivo);
                        memset(sNombreArchivo,'\0',LEN_BUFFER);
			arbol(sNombreArchivo);
                        printf("FIN Este es directorio %s\n",sNombreArchivo);
                }
		else
                {
                  printf("NombreArchivo %s\n",sNombreArchivo);
                  strcpy(sArchivo, sNombreArchivo);
                  if (stat(sArchivo, &statArchivo) == FAILURE) {
                          perror("STAT");
                          exit(FAILURE);
                  }
                                                                     
                  if ((statArchivo.st_mode & S_IFMT) == S_IFREG) {
                  if (! (statArchivo.st_mode & 0111)) {
                  ptmFechaArchivo = localtime(&statArchivo.st_mtime);
                  strftime(sBuffer, 9, "%Y%m%d", ptmFechaArchivo);
                  strncpy(sFecha, vars_entorno[FECHA].valor, 8);
                  sFecha[8]='\0';  
                    if (strncmp(sFecha, sBuffer, 8)==0)
                    {
                      printf("NO se elimina archivo %s tiene fecha: sBuffer %s y la fecha actual es: %s\n",sNombreArchivo,sBuffer,sFecha);
                    }
                    else
                    {
                      printf("SI elimina el archivo %s tiene Fecha sBuffer %s y la fecha actual es: %s\n",sNombreArchivo,sBuffer,sFecha);
                      sprintf(sComando, "rm -f %s",sNombreArchivo);    
                      system(sComando);
                    } /*strncmp(sfecha,sBuffer,8)==0)*/
                  }
                  }

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
	char	sComando[LEN_BUFFER];

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
		if (! (statArchivo.st_mode & 0111)) {
			ptmFechaArchivo = localtime(&statArchivo.st_mtime);
			strftime(sBuffer, 9, "%Y%m%d", ptmFechaArchivo);
			strncpy(sFecha, vars_entorno[FECHA].valor, 8);

			if (strncmp(sFecha, sBuffer, 8)) return;
			if (strlen(strchr(sArchivo, '/') + 1) != 25) return;

			if ((nuevo = malloc(sizeof(struct nodo_t))) == NULL) {
				perror("MALLOC");
				exit(FAILURE);
			}

			memset(sBuffer, '\0', LEN_BUFFER);
			nuevo->prefijo = atoi(strncpy(sBuffer, sArchivo, 4));
			memset(sBuffer, '\0', LEN_BUFFER);
			nuevo->banco = atoi(strncpy(sBuffer, (sArchivo + 4), 2));
			memset(sBuffer, '\0', LEN_BUFFER);
			nuevo->empresa = atoi(strncpy(	sBuffer,
											(sArchivo + 6),
											empresas[iEmpresa].long_emp));
			strncpy(nuevo->unidad,
					(sArchivo + 6 + empresas[iEmpresa].long_emp + 10),
					empresas[iEmpresa].long_uni);
			*(nuevo->unidad + empresas[iEmpresa].long_uni) = '\0';
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
			strcpy(CadenaRpr, extraNumRpr(	nuevo->prefijo,
											nuevo->banco,
											nuevo->empresa,
											atoi(nuevo->unidad),
											rg_arregloRepre));
			strftime(nuevo->fcreacion_arch, 9, "%Y%m%d", ptmFechaArchivo);
			*(nuevo->fcreacion_arch + 8) = '\0';
			strcpy(nuevo->fenvio_arch, "");
			nuevo->estatus = 2;

			memset(nuevo->arch_destino, '\0', 512);
			sprintf(nuevo->arch_destino, "%012d", NumeroCliente);
			strcat(nuevo->arch_destino, "TC");
			strcat(nuevo->arch_destino, "xx");
			memset(sBuffer, '\0', LEN_BUFFER);
			strncpy(sBuffer, strchr(sArchivo, '/') + 5, 4);
			strcat(nuevo->arch_destino, sBuffer);
			sprintf(nuevo->arch_destino, "%s%s",
					nuevo->arch_destino,
					nuevo->unidad);
			strncat(nuevo->arch_destino, strchr(sArchivo, '/') + 19, 3);
			strcat(nuevo->arch_destino, vars_entorno[ARCH_EXT].valor);

			memset(sBuffer, '\0', LEN_BUFFER);
			sprintf(sBuffer, "%d", atoi(nuevo->unidad));
			strcpy(nuevo->unidad, sBuffer);

			for (i = 1; i <= 9; i++) {
				memset(sCadena, '\0', LEN_BUFFER);
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
				ejecuta_sql(sqlcmd);
			}

		}
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

	sqlcmd[0] = '\0';
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
			dbbind(dbproc, 1, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) a_origen);
			dbbind(dbproc, 2, NTBSTRINGBIND, (DBINT) 0,
					(BYTE DBFAR *) a_destino);

			while (dbnextrow(dbproc) != NO_MORE_ROWS) {
				strcpy(reportes[n].archivo_origen, a_origen);
				strcpy(reportes[n].archivo_destino, a_destino);
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
			ret = execl("/usr/bin/sh", "sh", "-c", comando, 0);
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
long int	rg_arreglo[10000][4];
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
}

char *extraNumRpr(iprefijo, ibanco, iempresa, iunidad, rg_arreglo)
int		iprefijo;
int		ibanco;
int		iempresa;
int		iunidad;
long int	rg_arreglo[10000][13];
{
	static char	cCadenaRepre[100];
	int		iIndiceFila, isigue = 1;
	
	for (iIndiceFila = 0; isigue > 0; ++iIndiceFila) {
		if ((iprefijo == rg_arreglo[iIndiceFila][0])	&&
			(ibanco == rg_arreglo[iIndiceFila][1])		&&
			(iempresa == rg_arreglo[iIndiceFila][2])	&&
			(iunidad == rg_arreglo[iIndiceFila][3])) {
			if (rg_arreglo[iIndiceFila][4] == 0) {
				printf( "No hay representantes para: %d %d %d %d.\n",
						iprefijo, ibanco, iempresa, iunidad);
				return NULL;
			}
			sprintf(cCadenaRepre, "%02d|%02d|%02d|%02d|%02d|%02d|%02d|%02d|%02d|",
					rg_arreglo[iIndiceFila][4],
					rg_arreglo[iIndiceFila][5],
					rg_arreglo[iIndiceFila][6],
					rg_arreglo[iIndiceFila][7],
					rg_arreglo[iIndiceFila][8],
					rg_arreglo[iIndiceFila][9],
					rg_arreglo[iIndiceFila][10],
					rg_arreglo[iIndiceFila][11],
					rg_arreglo[iIndiceFila][12]);
			return cCadenaRepre;
		}
		isigue = rg_arreglo[iIndiceFila][0];
	}
}
