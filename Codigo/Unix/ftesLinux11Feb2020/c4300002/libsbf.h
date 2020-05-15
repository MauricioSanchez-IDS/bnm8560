/*******************************************************************************
*		INCLUDE's GENERALES
*******************************************************************************/
#include	<stdio.h>
#include	<stdlib.h>
#include	<string.h>
#include	<ctype.h>

#include	<assert.h>
#include	<time.h>
#include	<signal.h>
#include	<setjmp.h>
#include	<unistd.h>
#include	<sys/wait.h>
#include	<errno.h>

#include	<sybfront.h>
#include	<sybdb.h>

#include	<sys/types.h>


#define         PARTAMANO               255
#define         PARMATTAMANO    1000

struct strParametro{
        int             Registros;
        char    Mat[PARMATTAMANO][PARMATTAMANO];
};

typedef struct strParametro     strParametros;
typedef strParametros           *PTRSTRPARAM;


/*******************************************************************************
*		DEFINE's GENERALES
*******************************************************************************/
#ifdef		NDEBUG
#undef		NDEBUG
#endif

#define		DEBUG


#define		BOOL		unsigned char

#if !defined(TRUE)
#define		TRUE		((BOOL) 1)
#endif

#if !defined(FALSE)
#define		FALSE		((BOOL) 0)
#endif

#if !defined(NULL)
#define		NULL		((char *) 0)
#endif

#define		SUCCESS		0
#define		WARNING		1
#define		FAILURE		-1

/*******************************************************************************
*		BUFFERS GENERALES
*******************************************************************************/
#define		LEN_SQLCMD		16000
#define		LEN_ERROR		1000

char		sqlcmd[LEN_SQLCMD];
char		caderror[LEN_ERROR];

/*******************************************************************************
*		VARIABLES GLOBALES DE SYBASE
*******************************************************************************/
DBPROCESS	*dbproc;
LOGINREC	*login;

/*******************************************************************************
*		VARIABLES DE ENTORNO
*******************************************************************************/
#define		N_VARS_ENTORNO	15
#define		LEN_VAR_ENTORNO	64

#define		GE_USER			0
#define		GE_PASSWORD		1
#define		GE_DBASE		2
#define		GE_SERVER		3
#define		GE_HOSTNAME		4
#define		GE_APPNAME		5

#define		NOM_ARCH_R1		6
#define		NOM_ARCH_R3		7
#define		NOM_ARCH_R4		8
#define		NOM_ARCH_ALFA	9
#define		NOM_ARCH_LOG	10

#define		FECHA_INI		11
#define		FECHA_FIN		12
#define		FECHA_ACTUAL	13
#define		TIPO_ARCH		14

typedef struct {
	char	nombre[LEN_VAR_ENTORNO];
	char	valor[LEN_VAR_ENTORNO];
} VAR_ENTORNO;

VAR_ENTORNO	vars_entorno[N_VARS_ENTORNO] = {
	{"GE_USER",			""},
	{"GE_PASSWORD",		""},
	{"GE_DBASE",		""},
	{"GE_SERVER",		""},
	{"GE_HOSTNAME",		""},
	{"GE_APPNAME",		""},
	{"NOM_ARCH_R1",		""},
	{"NOM_ARCH_R3",		""},
	{"NOM_ARCH_R4",		""},
	{"NOM_ARCH_ALFA",	""},
	{"NOM_ARCH_LOG",	""},
	{"FECHA_INI",		""},
	{"FECHA_FIN",		""},
	{"FECHA_ACTUAL",	""},
	{"TIPO_ARCH",		""} };

/*******************************************************************************
*		MENSAJES DE ESTATUS
*******************************************************************************/
#define	N_MENSAJES	10

#define	ESTATUS_0	0	/*	"CARGA DEL SISTEMA S111 REALIZADA"				*/
#define	ESTATUS_1	1	/*	"CARGA DEL SISTEMA S111 INCORRECTA"				*/
#define	ESTATUS_2	2	/*	"INFORMACION DEL SISTEMA C430 VALIDADA"			*/
#define	ESTATUS_3	3	/*	"INFORMACION DEL SISTEMA C430 INCORRECTA"		*/
#define	ESTATUS_4	4	/*	"ESPACIO INSUFICIENTE EN DISCO"					*/
#define	ESTATUS_5	5	/*	"GENERACION DEL ARCHIVO SBF EN PROCESO"			*/
#define	ESTATUS_6	6	/*	"FORMATO CORRECTO DEL ARCHIVO SBF"				*/
#define	ESTATUS_7	7	/*	"FORMATO INCORRECTO DEL ARCHIVO SBF"			*/
#define	ESTATUS_8	8	/*	"ESTRUCTURA CORRECTA DEL ARCHIVO SBF"			*/
#define	ESTATUS_9	9	/*	"ESTRUCTURA INCORRECTA DEL ARCHIVO SBF"			*/

char *mensaje_estado[N_MENSAJES] = {
	"CARGA DEL SISTEMA S111 REALIZADA",
	"CARGA DEL SISTEMA S111 INCORRECTA",
	"INFORMACION DEL SISTEMA C430 VALIDADA",
	"INFORMACION DEL SISTEMA C430 INCORRECTA",
	"ESPACIO INSUFICIENTE EN DISCO",
	"GENERACION DEL ARCHIVO SBF EN PROCESO",
	"FORMATO CORRECTO DEL ARCHIVO SBF",
	"FORMATO INCORRECTO DEL ARCHIVO SBF",
	"ESTRUCTURA CORRECTA DEL ARCHIVO SBF",
	"ESTRUCTURA INCORRECTA DEL ARCHIVO SBF" };

/*******************************************************************************
*		DEFINES's PARA INTEGRA 
*******************************************************************************/
#define		LEN_BUFFER		181
#define		FORMATO_REG		"%180s\n"

/*******************************************************************************
*		MANEJADORES DE ERROR y MENSAJE
*******************************************************************************/
int CS_PUBLIC err_handler PROTOTYPE((
	DBPROCESS	*dbproc,
	int			severity,
	int			dberr,
	int			oserr,
	char		*dberrstr,
	char		*oserrstr));

int CS_PUBLIC msg_handler PROTOTYPE((
	DBPROCESS	*dbproc,
	DBINT		msgno,
	int			msgstate,
	int			severity,
	char		*msgtext,
	char		*srvname,
	char		*procname,
	int			line));

/*******************************************************************************
*	DEFINE's DEL LAYOUT
*******************************************************************************/
#define		LEN_RECORD					 			180

/*******************************************************************************
*	DEFINE's DEL LAYOUT 1
*******************************************************************************/
#define		LEN_R1_TIPO_REGISTRO		   			1
#define		LEN_R1_ID_SISTEMA				   		4
#define		LEN_R1_FECHA_ARCHIVO					8
#define		LEN_R1_SECUENCIA			   			1
#define		LEN_R1_CUENTA_EMPRESA		  			16
#define		LEN_R1_FILLER				 			150

#define		FOR_R1_TIPO_REGISTRO					"%1s"
#define		FOR_R1_ID_SISTEMA						"%4s"
#define		FOR_R1_FECHA_ARCHIVO					"%8s"
#define		FOR_R1_SECUENCIA						"%1s"
#define		FOR_R1_CUENTA_EMPRESA					"%16s"
#define		FOR_R1_FILLER							"%150s"

typedef struct {
	char	m_tipo_registro[LEN_R1_TIPO_REGISTRO + 1];
	char	m_id_sistema[LEN_R1_ID_SISTEMA + 1];
	char	m_fecha_archivo[LEN_R1_FECHA_ARCHIVO + 1];
	char	m_secuencia[LEN_R1_SECUENCIA + 1];
	char	m_cuenta_empresa[LEN_R1_CUENTA_EMPRESA + 1];
	char	m_filler[LEN_R1_FILLER + 1];
} ROW_TYPE_1;

/*******************************************************************************
*	DEFINE's DEL LAYOUT 3
*******************************************************************************/
#define		LEN_R3_TIPO_REGISTRO					1
#define		LEN_R3_NUMERO_MOVIMIENTO				6
#define		LEN_R3_NUMERO_NOMINA					10
#define		LEN_R3_RFC								15
#define		LEN_R3_NOMBRE_EMPLEADO					40
#define		LEN_R3_NUMERO_TARJETA					16
#define		LEN_R3_TIPO_MOVIMIENTO					1
#define		LEN_R3_FECHA_MOVIMIENTO					8
#define		LEN_R3_NUMERO_EMPLEADO					20
#define		LEN_R3_GL_NUMBER_PART_1					15
#define		LEN_R3_GL_NUMBER_PART_2					25
#define		LEN_R3_FILLER							23

#define		FOR_R3_TIPO_REGISTRO					"%1s"
#define		FOR_R3_NUMERO_MOVIMIENTO				"%06s"
#define		FOR_R3_NUMERO_NOMINA					"%-10s"
#define		FOR_R3_RFC								"%-15s"
#define		FOR_R3_NOMBRE_EMPLEADO					"%-40s"
#define		FOR_R3_NUMERO_TARJETA					"%16s"
#define		FOR_R3_TIPO_MOVIMIENTO					"%1s"
#define		FOR_R3_FECHA_MOVIMIENTO					"%8s"
#define		FOR_R3_NUMERO_EMPLEADO					"%-20s"
#define		FOR_R3_GL_NUMBER_PART_1					"%15s"
#define		FOR_R3_GL_NUMBER_PART_2					"%25s"
#define		FOR_R3_FILLER							"%23s"

typedef struct {
	char	m_tipo_registro[LEN_R3_TIPO_REGISTRO + 1];
	char	m_numero_movimiento[LEN_R3_NUMERO_MOVIMIENTO + 1];
	char	m_numero_nomina[LEN_R3_NUMERO_NOMINA + 1];
	char	m_rfc[LEN_R3_RFC + 1];
	char	m_nombre_empleado[LEN_R3_NOMBRE_EMPLEADO + 1];
	char	m_numero_tarjeta[LEN_R3_NUMERO_TARJETA + 1];
	char	m_tipo_movimiento[LEN_R3_TIPO_MOVIMIENTO + 1];
	char	m_fecha_movimiento[LEN_R3_FECHA_MOVIMIENTO + 1];
	char	m_numero_empleado[LEN_R3_NUMERO_EMPLEADO + 1];
	char	m_gl_number_part_1[LEN_R3_GL_NUMBER_PART_1 + 1];
	char	m_gl_number_part_2[LEN_R3_GL_NUMBER_PART_2 + 1];
	char	m_filler[LEN_R3_FILLER + 1];
} ROW_TYPE_3;

/*******************************************************************************
*	DEFINE's DEL LAYOUT 4
*******************************************************************************/
#define		LEN_R4_TIPO_REGISTRO					1
#define		LEN_R4_NUMERO_ALTAS						6
#define		LEN_R4_NUMERO_BAJAS						6
#define		LEN_R4_NUMERO_CAMBIOS					6
#define		LEN_R4_NUMERO_CARGA						6
#define		LEN_R4_FILLER							155

#define		FOR_R4_TIPO_REGISTRO					"%1s"
#define		FOR_R4_NUMERO_ALTAS						"%06s"
#define		FOR_R4_NUMERO_BAJAS						"%06s"
#define		FOR_R4_NUMERO_CAMBIOS					"%06s"
#define		FOR_R4_NUMERO_CARGA						"%06s"
#define		FOR_R4_FILLER							"%155s"

typedef struct {
	char	m_tipo_registro[LEN_R4_TIPO_REGISTRO + 1];
	char	m_numero_altas[LEN_R4_NUMERO_ALTAS + 1];
	char	m_numero_bajas[LEN_R4_NUMERO_BAJAS + 1];
	char	m_numero_cambios[LEN_R4_NUMERO_CAMBIOS + 1];
	char	m_numero_carga[LEN_R4_NUMERO_CARGA + 1];
	char	m_filler[LEN_R4_FILLER + 1];
} ROW_TYPE_4;


/*******************************************************************************
*		FUNCIONES DE VARIABLES DE ENTORNO
*******************************************************************************/
#if defined(__cplusplus)
extern "C" {
#endif

#ifdef _PROTOTYPES
	void	getvars_entorno(void);
	int		testvars_entorno(void);
	void	putvars_entorno(void);
#else
	void	getvars_entorno();
	int		testvars_entorno();
	void	putvars_entorno();
#endif

#if defined(__cplusplus)
}
#endif

void getvars_entorno()
{
	int	i;
	//register int	i;
	strParametros	Valores;

	Valores.Registros = 0;

	for (i = 0; i < N_VARS_ENTORNO; i++) {
			strcpy(	vars_entorno[i].valor,
					getenv(vars_entorno[i].nombre));
	}
}

int testvars_entorno()
{
	int i;
	//register int i;

	for (i = 0; i < N_VARS_ENTORNO; i++)
		if (! strlen(vars_entorno[i].valor))
			return (FALSE);
		else
                   {
                       if (i != 1) /*GE_PASSWORD  no imprimir esta variable*/
			puts(vars_entorno[i].valor);
                   }
	return (TRUE);
}

void putvars_entorno()
{
	register int i;

	for (i = 0; i < N_VARS_ENTORNO; i++) {
		printf(	"%-16s=%-16s\n", vars_entorno[i].nombre, vars_entorno[i].valor);
		fflush(stdout);
	}
}

/*******************************************************************************
*		FUNCIONES DE FECHA Y HORA
*******************************************************************************/
#if defined(__cplusplus)
extern "C" {
#endif

#ifdef _PROTOTYPES
	char	*get_fechahora(char *);
	char	*gettime(char *);
#else
	char	*get_fechahora();
	char	*gettime();
#endif

#if defined(__cplusplus)
}
#endif

#if defined(__STDC__) || defined(__cplusplus)
char *get_fechahora(char *formato)
#else
char *get_fechahora(formato)
char *formato;
#endif
{
	time_t		hora_local;
	struct tm	*fecha_actual;
	char		*cadena;

	cadena = (char *) malloc(21);
	time(&hora_local);
	fecha_actual = localtime(&hora_local);
	strftime(cadena, 20, formato, fecha_actual);
	return cadena;
}

#if defined(__STDC__) || defined(__cplusplus)
char *gettime(char *cadena)
#else
char *gettime(cadena)
char *cadena;
#endif
{
	time_t		hora_local;
	struct tm	*fecha_actual;

	time(&hora_local);
	fecha_actual = localtime(&hora_local);
	strftime(cadena, 10, "%T", fecha_actual);
	return cadena;
}

/*******************************************************************************
*		FUNCIONES DE SQL
*******************************************************************************/
#if defined(__cplusplus)
extern "C" {
#endif

#ifdef _PROTOTYPES
	void	borra_tabla(char *nom_tabla);
	void	ejecuta_sql(char *comando);
#else
	void	borra_tabla();
	void	ejecuta_sql();
#endif

#if defined(__cplusplus)
}
#endif

#if defined(_CANSI) || defined(__STDC__) || defined(__cplusplus)
void borra_tabla(char *nom_tabla)
#else
void borra_tabla(nom_tabla)
char *nom_tabla;
#endif
{
	RETCODE		result_code;

	*sqlcmd = NULL;
	sprintf(sqlcmd, "IF OBJECT_ID('%s') IS NOT NULL\nDROP TABLE %s", nom_tabla, nom_tabla);
	dbcmd(dbproc, sqlcmd);

	if (dbsqlexec(dbproc) == FAIL) {
		sprintf(caderror, "Error al ejecutar la sentencia SQL: %s.\n", sqlcmd);
		Log(__FILE__, "borra_tabla", __LINE__, caderror);
		exit(FAILURE);
	}
	while (dbresults(dbproc) != NO_MORE_RESULTS);
}

#if defined(_CANSI) || defined(__STDC__) || defined(__cplusplus)
void ejecuta_sql(char *comando)
#else
void ejecuta_sql(comando)
char *comando;
#endif
{
	RETCODE result_code;

	dbcmd(dbproc, comando);
	if (dbsqlexec(dbproc) == FAIL) {
		sprintf(caderror, "Error al ejecutar la sentencia SQL: %s.\n", comando);
		Log(__FILE__, "ejecuta_sql", __LINE__, caderror);
		exit(FAILURE);
	}

	while ((result_code = dbresults(dbproc)) != NO_MORE_RESULTS)
		if (result_code == SUCCEED) 
			while (dbnextrow(dbproc) != NO_MORE_ROWS);
}

/*******************************************************************************
*		FUNCIONES DE ESTATUS Y LOG
*******************************************************************************/
#if defined(__cplusplus)
extern "C" {
#endif

#ifdef _PROTOTYPES
	int		Log(char *, char *, int, char *);
#else
	int		Log();
#endif

#if defined(__cplusplus)
}
#endif

int Log(v_programa, v_modulo, v_linea, v_mensaje)
char	v_programa[50];
char	v_modulo[50];
int	v_linea;
char	v_mensaje[100];
{
	FILE		*log;
	char		cfechayhora[50];
	char		cnombreArchivo[20];
	char		ccadenalog[1000];
	int		vallog = 0;
	time_t		lcl_time;
	struct tm	*today;

	strcpy(cnombreArchivo, vars_entorno[NOM_ARCH_LOG].valor);
	time(&lcl_time);
	today = localtime(&lcl_time);
	strftime(cfechayhora, 50, "%b %d %H:%M:%S %Y", today);

	log = fopen(cnombreArchivo, "a");
	if (log == NULL) {
		fprintf(stdout, "Error al abrir el log %s.", cnombreArchivo);
		fflush(stdout);
		vallog = 1;
		return vallog;
	}

	sprintf(ccadenalog, "%s ", cfechayhora);
	sprintf(ccadenalog, "%s %s ", ccadenalog, v_programa);
	sprintf(ccadenalog, "%s %s ", ccadenalog, v_modulo);
	sprintf(ccadenalog, "%s %d ", ccadenalog, v_linea);
	sprintf(ccadenalog, "%s %s ", ccadenalog, v_mensaje);

	if (fprintf(log, "%s\n", ccadenalog) == FAILURE) {
		fprintf(stdout, "Error al grabar en el log %s.", cnombreArchivo);
		fflush(stdout);
		vallog = 1;
		return vallog;
	}
	fclose(log);

	return vallog;
}

/*******************************************************************************
*		MANEJADORES DE ERROR y MENSAJE
*******************************************************************************/
int CS_PUBLIC err_handler(dbproc, severity, dberr, oserr, dberrstr, oserrstr)
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
		sprintf(caderror, "DB-Library error:\n\t%s\n", dberrstr);
		Log(__FILE__, "err_handler", __LINE__, caderror);
		if (oserr != DBNOERR) {
			fprintf(stderr, "Operating-system error:\n\t%s\n", oserrstr);
			sprintf(caderror, "Operating-system error:\n\t%s\n", oserrstr);
			Log(__FILE__, "err_handler", __LINE__, caderror);
		}
		return (INT_CANCEL);
	}
}

int CS_PUBLIC msg_handler(dbproc, msgno, msgstate, severity, msgtext, 
						   srvname, procname, line)
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
		fprintf(stderr, "Mensaje: %d, Nivel: %d, Estado: %d, ",
				msgno, severity, msgstate);
		sprintf(caderror, "Mensaje: %d, Nivel: %d, Estado: %d, ",
				msgno, severity, msgstate);
		Log(__FILE__, "msg_handler", __LINE__, caderror);
		if (strlen(srvname) > 0) {
			fprintf(stderr, "Servidor: '%s', ", srvname);
			sprintf(caderror, "Servidor: '%s', ", srvname);
			Log(__FILE__, "msg_handler", __LINE__, caderror);
		}
		if (strlen(procname) > 0) {
			fprintf(stderr, "Procedimiento: '%s', ", procname);
			sprintf(caderror, "Procedimiento: '%s', ", procname);
			Log(__FILE__, "msg_handler", __LINE__, caderror);
		}
		if (line > 0) {
			fprintf(stderr, "Linea: %d", line);
			sprintf(caderror, "Linea: %d", line);
			Log(__FILE__, "msg_handler", __LINE__, caderror);
		}
		fprintf(stderr, "\n\t%s\n", msgtext);
		sprintf(caderror, "\n\t%s\n", msgtext);
		Log(__FILE__, "msg_handler", __LINE__, caderror);
		return (0);
	}
     return 0;
}

