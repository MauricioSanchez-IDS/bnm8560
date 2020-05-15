#define __CONEXION_H
#define ERR_CH     stderr

#include <stdio.h>
#include <stdlib.h>
#include <sybfront.h>
//#include "sybdbex.h"
#include <sybdb.h>


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
int             msgstate;
int             severity;
char            *msgtext;
char            *srvname;
char            *procname;
int     	line;

{
        if ((msgno != 5701) && (msgno != 5703))
        {
	fprintf (ERR_CH, "Msg %d, Level %d, State %d\n", 
	        msgno, severity, msgstate);

	if (strlen(srvname) > 0)
		fprintf (ERR_CH, "Server '%s', ", srvname);
	if (strlen(procname) > 0)
		fprintf (ERR_CH, "Procedure '%s', ", procname);
	if (line > 0)
		fprintf (ERR_CH, "Line %d", line);
	fprintf (ERR_CH, "\n\t%s\n", msgtext);
	return(0);
        }
    return(0);
}


void IniciaBase()
{
  /*inicializamos  DB-Library. */
  if (dbinit() == FAIL)
    exit(ERREXIT);
  /* Install the user-supplied error-handling and message-handling
   * routines. They are defined at the bottom of this source file.
  */
  dberrhandle((EHANDLEFUNC)err_handler);
  dbmsghandle((MHANDLEFUNC)msg_handler);
}

void ConectaBase(User, Pass, Serv, Base, Host, dbproc, Pvez)
char User[255];
char Pass[255];
char Serv[255];
char Base[255];
char Host[255];
DBPROCESS **dbproc; 
int Pvez;

{
  LOGINREC      *login;  
  /*
  ** damos informacion del login
  */


  login = dblogin();
  DBSETLUSER(login, User);
  DBSETLPWD(login, Pass);
  DBSETLAPP(login, Host);
  DBSETLHOST(login, Host);
  DBSETLCHARSET(login,"roman8");
  DBSETLENCRYPT(login, TRUE);

 /*
  ** abrimos la base de datos.
  */
  *dbproc = dbopen(login, Serv);
  /*nos ubicamos en la base de datos */
  dbuse(*dbproc, Base);  
}


void Desconecta()
{
	dbexit();
}

