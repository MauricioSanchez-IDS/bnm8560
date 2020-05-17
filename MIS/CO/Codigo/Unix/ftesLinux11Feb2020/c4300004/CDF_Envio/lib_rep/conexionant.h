#define __CONEXION_H

#if defined(__cplusplus)
extern "C" {
 
#endif

#if defined(_PROTOTYPES)
    int CS_PUBLIC err_handler(DBPROCESS *, int, int, int, char *, char *);
    int CS_PUBLIC msg_handler(DBPROCESS *, DBINT, int, int, char *, char *, char *, int);
    void IniciaBase(void);
    void ConectaBase(char *, char *, char *, char *, char *, DBPROCESS **);
    void Desconecta(void);
#else
    int CS_PUBLIC err_handler();
    int CS_PUBLIC msg_handler();
    void IniciaBase();
    void ConectaBase();
    void Desconecta();
#endif

#if defined(__cplusplus)
}
#endif

char	string_error[1024];

/*============================================================================*/
void IniciaBase()
{
    puts("IniciaBase");
    if (dbinit() == FAIL) {
	strcpy(string_error, "Error al ejecutar dbinit.");
	puts(string_error);
	exit(FAILURE);
    }
    puts("Sali de dbinit");
    dberrhandle((EHANDLEFUNC) err_handler);
    dbmsghandle((MHANDLEFUNC) msg_handler);
    puts("Sali de IniciaBase");
}

/*============================================================================*/
#if defined(__STDC__) || defined(__cpluplus)
void ConectaBase(char *User,
		 char *Pass,
		 char *Serv, char *Base, char *Host, DBPROCESS ** dbproc)
#else
void ConectaBase(User, Pass, Serv, Base, Host, dbproc)
char *User;
char *Pass;
char *Serv;
char *Base;
char *Host;
DBPROCESS **dbproc;
#endif
{
    puts("Antes de LOGINREC");
    LOGINREC *login;
    if (!(login = dblogin())) {
	strcpy(string_error, "Error al ejecutar dblogin.");
	puts(string_error);
	exit(FAILURE);
 
    }
    puts("Despues de LOGINREC");

    DBSETLUSER(login, User);
    puts("Despues User");

    DBSETLPWD(login, Pass);
    puts("Despues Pass");

    DBSETLHOST(login, Host);
    puts("Despues Host");

    DBSETLAPP(login, Host);   

    puts("Antes de dbopen");
    if (!(*dbproc = dbopen(login, Serv))) {
	strcpy(string_error, "Error al ejecutar dbopen.");
	puts(string_error);
	exit(FAILURE);
    }
    if (dbuse(*dbproc, Base) == FAIL) {
	strcpy(string_error, "Error al ejecutar dbuse.");
	puts(string_error);
	exit(FAILURE);
    }
    puts("Despues de dbopen");
}

/*============================================================================*/
void Desconecta()
{
    dbexit();
}

/*============================================================================*/
#if defined(__STDC__) || defined(__cpluplus)
int CS_PUBLIC err_handler(DBPROCESS * dbproc,
			  int severity,
			  int dberr,
			  int oserr, char *dberrstr, char *oserrstr)
#else
int CS_PUBLIC err_handler(dbproc,
			  severity, dberr, oserr, dberrstr, oserrstr)
DBPROCESS *dbproc;
int severity;
int dberr;
int oserr;
char *dberrstr;
char *oserrstr;
#endif
{
    if ((dbproc == NULL) || DBDEAD(dbproc))
	return (INT_EXIT);
    else {
	sprintf(string_error, "DB-Library error:\n\t%s\n", dberrstr);
	puts(string_error);
	if (oserr != DBNOERR) {
	    sprintf(string_error, "Operating-system error:\n\t%s\n",
		    oserrstr);
	    puts(string_error);
	}
	return (INT_CANCEL);
    }
}

/*============================================================================*/

#if defined(__STDC__) || defined(__cpluplus)
int CS_PUBLIC msg_handler(DBPROCESS * dbproc,
			  DBINT msgno,
			  int msgstate,
			  int severity,
			  char *msgtext,
			  char *srvname, char *procname, int line)
#else
int CS_PUBLIC msg_handler(dbproc,
			  msgno,
			  msgstate,
			  severity, msgtext, srvname, procname, line)
DBPROCESS *dbproc;
DBINT msgno;
int msgstate;
int severity;
char *msgtext;
char *srvname;
char *procname;
int line;
#endif
{
    if ((msgno != 5701) && (msgno != 5703)) {
	sprintf(string_error,
		"Mensaje: %ld, Nivel: %d, Estado: %d, ",
		msgno, severity, msgstate);
	puts(string_error);

	if (strlen(srvname) > 0) {
	    sprintf(string_error, "Servidor: '%s', ", srvname);
	    puts(string_error);
	}

	if (strlen(procname) > 0) {
	    sprintf(string_error, "Procedimiento: '%s', ", procname);
	    puts(string_error);
	}

	if (line > 0) {
	    sprintf(string_error, "Linea: %d", line);
	    puts(string_error);
	}

	sprintf(string_error, "\n\t%s\n", msgtext);
	puts(string_error);

	return (0);
    }
}
