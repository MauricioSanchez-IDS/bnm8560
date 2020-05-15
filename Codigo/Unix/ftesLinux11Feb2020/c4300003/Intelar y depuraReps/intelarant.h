/*******************************************************************************
*                        DEFINE's                                              *
*******************************************************************************/
#include <sys/types.h>
#include <unistd.h>
#include <time.h>
#include <sybfront.h>
#include <sybdb.h>

#ifdef NDEBUG
	#undef NDEBUG
#endif

#ifndef NULL
	#define NULL ((char *) 0)
#endif

#if !defined(FALSE) || !defined(TRUE)
	enum {FALSE, TRUE};
#endif

#define SUCCESS 	0
#define WARNING		1
#define FAILURE		-1

#define LEN_BUFFER	1024
#define	LEN_SQLCMD	8192

/*******************************************************************************
*                        VARIABLES GLOBALES                                    *
*******************************************************************************/
DBPROCESS   *dbproc;
LOGINREC    *login;

char		sqlcmd[LEN_SQLCMD];
int	 		iEmpresa;

struct nodo_t {
	int		prefijo;
	int		banco;
	int		empresa;
	char	unidad[6];
	int		representante;
	char	arch_original[512];
	char	arch_destino[512];
	char	fcreacion_arch[9];
	char	fenvio_arch[9];
	int		estatus;
};

/*******************************************************************************
*                        VARIABLES DE ENTORNO                                  *
*******************************************************************************/
#define	N_VARS_ENTORNO	11

enum {	GE_USER,
		GE_PASSWORD,
		GE_DBASE,
		GE_SERVER,
		GE_HOSTNAME,
		REENVIO,
		FECHA,
		ESTATUS,
		VAL_ESTATUS,
		ARCH_EXT,
		DIR_ARCH };

typedef struct {
	char	nombre[LEN_BUFFER];
	char	valor[LEN_BUFFER];
} T_VAR_ENTORNO;

T_VAR_ENTORNO	vars_entorno[N_VARS_ENTORNO] = {{"GE_USER"		, ""},
												{"GE_PASSWORD"	, ""},
												{"GE_DBASE"		, ""},
												{"GE_SERVER"	, ""},
												{"GE_HOSTNAME"	, ""},
												{"REENVIO"		, ""},
												{"FECHA"		, ""},
												{"ESTATUS"		, ""},
												{"VAL_ESTATUS"	, ""},
												{"ARCH_EXT"		, ""},
												{"DIR_ARCH"		, ""} };

/*******************************************************************************
*                        VARIABLES DE EMPRESAS                                 *
*******************************************************************************/
#define MAX_EMPRESAS	2000
#define LEN_CAMPO		10

typedef struct {
	char	prefijo_emp[LEN_CAMPO];
	char	banco_emp[LEN_CAMPO];
	char	numero_emp[LEN_CAMPO];
	int		long_emp;
	int		long_uni;
	int		long_cli;
	int		long_rep;
} T_EMPRESA;

T_EMPRESA empresas[MAX_EMPRESAS];

/*******************************************************************************
*                        VARIABLES DE LISTA DE REPORTES                        *
*******************************************************************************/
//#define MAX_REPORTES	30000
#define MAX_REPORTES    50000

typedef struct {
	char	archivo_origen[LEN_BUFFER];
	char	archivo_destino[LEN_BUFFER];
} T_REPORTE;

T_REPORTE reportes[MAX_REPORTES];

/*******************************************************************************
*                        ARREGLOS PARA CATALOGOS                               *
*******************************************************************************/
long int rg_arregloCliente[2000][4];
long int rg_arregloRepre[10000][13];

/*******************************************************************************
*                        DECLARACION DE PROTOTIPOS                             *
*******************************************************************************/
#ifdef __cpluplus
extern "C" {
#endif

#ifdef _PROTOTYPES
	void	arbol(const char *, void (*pf)(const char *));
	void	procesa_arch(const char *);
	void	ejecuta_sql(const char *);
	int		generaEmpresas(int);
	void	procesaTablaReportes(char *, char *);
	void	signal_handler(int);
	void	obtieneVarsEntorno();
	int		verificaVarsEntorno();
	void	muestraVarsEntorno();
	void	fecha_hora(char *);
	char	*elem_n(char *, char *, int);
	int		envia_ftp(char *, char *);
	void	catClie(int, int, char *, long int [1000][4]);
	void	catRpr(int, int, char *, long int [10000][13]);
	int		extraNumCli(int, int, int, long int [1000][4]);
	char	*extraNumRpr(int, int, int, int, long int [10000][13]);
#else
	void	arbol();
	void	procesa_arch();
	void	ejecuta_sql();
	int		generaEmpresas();
	void	procesaTablaReportes();
	void	signal_handler();
	void	obtieneVarsEntorno();
	int		verificaVarsEntorno();
	void	muestraVarsEntorno();
	void	fecha_hora();
	char	*elem_n();
	int		envia_ftp();
	void	catClie();
	int		extraNumCli();
	void	catRpr();
	char	*extraNumRpr();
#endif

#ifdef __cpluplus
}
#endif

/* Manejadores de error y mensaje. */
int CS_PUBLIC err_handler PROTOTYPE((
	DBPROCESS	*dbproc,
	int			severity,
	int			dberr,
	int			oserr,
	char		*dberrstr,
	char		*oserrstr
));

int CS_PUBLIC msg_handler PROTOTYPE((
	DBPROCESS	*dbproc,
	DBINT		msgno,
	int			msgstate,
	int			severity,
	char		*msgtext,
	char		*srvname,
	char		*procname,
	int			line
));

/*******************************************************************************
*                        FUNCIONES DE SQL                                      *
*******************************************************************************/
#if defined(__STDC__) || defined(__cplusplus)
void ejecuta_sql(const char *comando)
#else
void ejecuta_sql(comando)
char *comando; 
#endif
{
	RETCODE result_code;

	dbcmd(dbproc,(char *) comando);
	if (dbsqlexec(dbproc) == FAIL) {
		fprintf(stderr, "Error al ejecutar SQL: %s.\n", comando);
		exit(FAILURE);
	}

	while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS)
		if (result_code == SUCCEED) 
			while (dbnextrow(dbproc) != NO_MORE_ROWS);
}

/*******************************************************************************
*                        MANEJO DE ERRORES                                     *
*******************************************************************************/
#if defined(__STDC__) || defined(__cplusplus)
void signal_handler(int sig)
#else
/*void signal_handler(sig) yuria*/
void signal_handler()
int sig;
#endif
{
	switch (sig) {
		case SIGTERM:
			printf("Proceso(%d): SIGTERM.\n", getpid());
			if (signal(SIGTERM, signal_handler) == SIG_ERR) {
				perror("SIGNAL");
				exit(FAILURE);
			}
			break;
		case SIGINT:
			printf("Proceso(%d): SIGINT.\n", getpid());
			if (signal(SIGINT, signal_handler) == SIG_ERR) {
				perror("SIGNAL");
				exit(FAILURE);
			}
			break;
	}
}

int CS_PUBLIC err_handler(	dbproc,
							severity,
							dberr,
							oserr,
							dberrstr,
							oserrstr)
DBPROCESS	*dbproc;
int			severity;
int			dberr;
int			oserr;
char		*dberrstr;
char		*oserrstr;
{
	if ((dbproc == NULL) || DBDEAD(dbproc))
		return (INT_EXIT);
	else {
		fprintf(stderr, "DB-Library error:\n\t%s\n", dberrstr);
		if (oserr != DBNOERR)
			fprintf(stderr, "Operating-system error:\n\t%s\n", oserrstr);
		return (INT_CANCEL);
	}
}

int CS_PUBLIC msg_handler(	dbproc,
							msgno,
							msgstate,
							severity,
							msgtext,
							srvname,
							procname,
							line)
DBPROCESS	*dbproc;
DBINT		msgno;
int			msgstate;
int			severity;
char		*msgtext;
char		*srvname;
char		*procname;
int			line;
{
	if ((msgno != 5701) && (msgno != 5703)) {
		fprintf(stderr,
				"Mensaje: %d, Nivel: %d, Estado: %d, ",
				msgno,
				severity,
				msgstate);
		if (strlen(srvname) > 0)
			fprintf(stderr, "Servidor: '%s', ", srvname);
		if (strlen(procname) > 0)
			fprintf(stderr, "Procedimiento: '%s', ", procname);
		if (line > 0)
			fprintf(stderr, "Linea: %d", line);
		fprintf(stderr, "\n\t%s\n", msgtext);
		return (0);
	}
	return (0);
}

/*******************************************************************************
*                        FUNCIONES DE ENTORNO                                  *
*******************************************************************************/
void obtieneVarsEntorno()
{
	register int i;

	for (i = 0; i < N_VARS_ENTORNO; i++)
		strcpy(	vars_entorno[i].valor,
				getenv(vars_entorno[i].nombre));
}

int verificaVarsEntorno()
{
	register int i;

	for (i = 0; i < N_VARS_ENTORNO; i++)
		if (! strlen(vars_entorno[i].valor)) return (FALSE);

	return (TRUE);
}

void muestraVarsEntorno()
{
	register int i;

	for (i = 0; i < N_VARS_ENTORNO; i++)
		printf(	"%-16s=%-16s\n",
				vars_entorno[i].nombre,
				vars_entorno[i].valor);
}

/*******************************************************************************
*                        FUNCIONES VARIAS                                      *
*******************************************************************************/
#if defined(__STDC__) || (__cplusplus)
void fecha_hora(char *cadena)
#else
void fecha_hora(cadena)
char *cadena;
#endif
{
	time_t 		timeHoraActual;
	struct tm	*tmFechaActual;

	time(&timeHoraActual);
	tmFechaActual = localtime(&timeHoraActual);
	strftime(cadena, 18, "%d.%m.%y %H:%M:%S", tmFechaActual);
}

#if defined(__STDC__) || (__cplusplus)
char *elem_n(char *c1, char *c2, int n)
#else
char *elem_n(c1, c2, n)
char *c1;
char *c2;
int n;
#endif
{
	switch (n) {
		case 1: strncpy(c1, c2    , 2); break;
		case 2: strncpy(c1, c2 + 3, 2); break;
		case 3: strncpy(c1, c2 + 6, 2); break;

		case 4: strncpy(c1, c2 + 9, 2); break;
		case 5: strncpy(c1, c2 + 12, 2); break;
		case 6: strncpy(c1, c2 + 15, 2); break;

		case 7: strncpy(c1, c2 + 18, 2); break;
		case 8: strncpy(c1, c2 + 21, 2); break;
		case 9: strncpy(c1, c2 + 24, 2); break;
	}
	return 0;
}
