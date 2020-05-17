DBSETVERSION(DBVERSION_100);
DBSETLENCRYPT(login, TRUE);
/*
** Autor:   Jesus Munoz M.
** Cia:     EISSA 
** Fecha:   01/MARZO/2001
** Funcion: Recibe un archivo con los registros rechazados por Master
**          Card y actualiza el codigo  de error enviado en  cada una 
**          de las entidades correspondientes.
*/
#if USE_SCCSID
static char Sccsid[] = {"@(#) ActRech.c 87.1 01/03/01"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include "sybdbex.h"
#include <stdlib.h>
#include <string.h>
#include "substr.h"
#define LONGCADENA 1200 /*antes tenia 802, se modifica 28/02/05*/

/******* 
   #define LONGCADENA 708  MODIFICADA POR JAGG  19 MAY 2004 EISSA i
****/


long RegLeidos;      /* Regs Leidos en el arch de rechazos     */ 
long Reg1000Act;     /* Regs actualizados en Reg1000           */ 
long Reg1100Act;     /* Regs actualizados en Reg1100           */ 
long Reg3000Act;     /* Regs actualizados en Reg3000           */ 
long Reg4000Act;     /* Regs actualizados en Reg4000           */ 
long Reg4100Act;     /* Regs actualizados en Reg4100           */ 
long Reg4200Act;     /* Regs actualizados en Reg4200           */ 
long Reg4300Act;     /* Regs actualizados en Reg4300           */ 
long Reg5000Act;     /* Regs actualizados en Reg5000           */ 
long Reg9999Act;     /* Regs actualizados en Reg9999           */ 
long TotRegRech;     /* No. regs rech segun el sumario (Reg 1100) */

int  CS_PUBLIC   sqlEval(); 

/* Forward declarations of the error handler and message handler. */

int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();

main(numarg, arg)
int numarg;
char *arg[];
{
FILE * archivo;
char   ge_user[10];
char   ge_password[10];
char   ge_server[10];
char   ge_hostname[10];
char   ge_dbase[10];
  
int IFR;     /* contendra el numero de registro dentro de archivo*/
int  resultado;    /* bandera que indica el resultado del sql */
char cadena[LONGCADENA + 1];
char CodError[6+1];
char inputFileRecordNumber[6+1];
char CorpNum[19+1];
char OrgPointNum[19+1];
char Cuenta[19+1];
char Referencia[23+1];
char RecordId[4+1];
char RITF[6+1];     /* compara el campo recordsinthisfile */
int a,i,c,n,ultimo,largo;

char sTotRegRech[6+1];    
int  RegLeidosRech;    
DBPROCESS     *q_dbproc;  
LOGINREC      *login;        /* Our login information. */

/* These are the variables used to store the returning data. */
char           sqlcmd[SQLBUFLEN];
RETCODE        result_code;
DBCHAR         longReg[5];

RegLeidos = 0;      
Reg1000Act = 0;    
Reg1100Act = 0;   
Reg3000Act = 0;  
Reg4000Act = 0; 
Reg4100Act = 0;
Reg4200Act = 0;     
Reg4300Act = 0;    
Reg5000Act = 0;   
Reg9999Act = 0;  
TotRegRech = 0; 

fflush(stdout);
/*obtenemos variables de ambiente*/
sprintf(ge_user,"%s",getenv("GE_USER"));
sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
sprintf(ge_dbase,"%s",getenv("GE_DBASE"));
sprintf(ge_server,"%s",getenv("GE_SERVER"));
sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));

i = 0;
sTotRegRech[0] = '\0';    

/* inicializamos  DB-Library. */
if (dbinit() == FAIL)
 exit(ERREXIT);

/* Install the user-supplied error-handling and message-handling
routines. They are defined at the bottom of this source file.*/
dberrhandle((EHANDLEFUNC)err_handler);
dbmsghandle((MHANDLEFUNC)msg_handler);

/* damos informacion al login */
login = dblogin();

DBSETLUSER(login, ge_user);
DBSETLPWD(login, ge_password);
DBSETLAPP(login, ge_hostname);
DBSETLHOST(login, ge_hostname);
DBSETLCHARSET(login,"roman8");


if (numarg != 2)
{ 
  printf("Error. No proporciono nombre de archivo.\n");
  CifrasControl();
  exit(1);
}

/* abrimos la base de datos. */
q_dbproc = dbopen(login, ge_server);

/*nos ubicamos en la base de datos */
dbuse(q_dbproc, ge_dbase);

if ((archivo=fopen(arg[1],"rb")) == NULL)  
{
  printf("Error. No existe archivo");
  CifrasControl();
  exit(1);
} 

dbcmd(q_dbproc,"BEGIN TRANSACTION ");
dbsqlexec(q_dbproc);
dbresults(q_dbproc);

while ( fgets(cadena, LONGCADENA, archivo) != NULL ) /* Lee archivo */
{
  ++RegLeidos;
  sqlcmd[0] = '\0';
  CodError[0] = '\0';
  inputFileRecordNumber[0]= '\0';

  /* carga de RecordIdentifier */
   printf("Cadena %s\n", cadena);
  sprintf(RecordId,"%s", substr(cadena, 1, 4));
   printf("Registro Identifier : %s\n", RecordId);
  /* Identifica el tipo de registro y su codigo de error */
  switch (atoi(RecordId))
  {
    case 1000:   /* Registro 1000 */
	/*AFRH EISSA 09/20/2004  anterior 00001
	  sprintf(CodError,"%s", substr(cadena, 176, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 170, 6));
	AFRH EISSA 09/20/2004  anterior 00001*/
	/*AFRH EISSA 09/20/2004  nuevo 00001*/
	  sprintf(CodError,"%s", substr(cadena, 182, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 176, 6));
	/*AFRH EISSA 09/20/2004  nuevo 00001*/

      /* armamos el sql. */
      sprintf(sqlcmd,"UPDATE REG1000 ");
      strcat(sqlcmd,"SET outgoingIncomingErrorCode = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CodError);
      strcat(sqlcmd,"', inputFileRecordNumber = '");
      strcat(sqlcmd,inputFileRecordNumber);
      strcat(sqlcmd,"'");

      /* enviamos el comando a SQL Server y ejecutamos. */
      resultado = sqlEval(q_dbproc, sqlcmd);
      
      if (resultado == 1) 
      {
        ++Reg1000Act;      
      }
      else
      { 
        CifrasControl();
        exit(1);
      }
      break;

    case 1100:   /* Registro 1100. Sumario del archivo. */
/*    sprintf(sTotRegRech,"%s", substr(cadena, 186, 6));   */
      sprintf(sTotRegRech,"%s", substr(cadena, 192, 6));
      TotRegRech = atoi(sTotRegRech);
      ++Reg1100Act;      
      if (RegLeidos == 1) 
      {
        if (TotRegRech == 0) 
        {
          /* Notificacion de aceptacion de todos los registros */;
          printf("NO EXISTEN REGS RECH. PROCESO ACEPTADO.");
        }
        else
        { 
          printf("Error. En el sumario regs. rech. es diferente a 0.");
          CifrasControl();
          exit(1);
        }
      }
      break;

    case 3000:   /* Registro 3000 */
    /*AFRH EISSA 09/20/2004  anterior 00002
	  sprintf(CodError,"%s", substr(cadena, 387, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 381, 6));
    AFRH EISSA 09/20/2004  anterior 00002*/
    /*AFRH EISSA 09/20/2004  nuevo 00002*/
	  sprintf(CodError,"%s", substr(cadena, 393, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 387, 6));
    /*AFRH EISSA 09/20/2004  nuevo 00002*/

      /* armamos el sql. */
      sprintf(sqlcmd,"UPDATE REG3000 ");
      strcat(sqlcmd,"SET outgoingIncomingErrorCode = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CodError);
      strcat(sqlcmd,"', inputFileRecordNumber = '");
      strcat(sqlcmd,inputFileRecordNumber);
      strcat(sqlcmd,"'\n");

      /* enviamos el comando a SQL Server y ejecutamos. */
      resultado = sqlEval(q_dbproc, sqlcmd);
      if (resultado == 1) 
      {
        ++Reg3000Act;      
      }
      else
      { 
        CifrasControl();
        exit(1);
      }
      break;

    case 4000:   /* Registro 4000 */
    /*AFRH EISSA 09/20/2004  nuevo 00003
	  sprintf(CorpNum,"%s", substr(cadena, 21, 19));
      sprintf(CodError,"%s", substr(cadena, 602, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 596, 6));
    AFRH EISSA 09/20/2004  nuevo 00003*/
    /*AFRH EISSA 09/20/2004  nuevo 00003*/
	  sprintf(CorpNum,"%s", substr(cadena, 27, 19));
      sprintf(CodError,"%s", substr(cadena, 608, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 602, 6));
    /*AFRH EISSA 09/20/2004  nuevo 00003*/
      /* armamos el sql. */
      sprintf(sqlcmd,"UPDATE REG4000 ");
      strcat(sqlcmd,"SET outgoingIncomingErrorCode = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CodError);
      strcat(sqlcmd,"', inputFileRecordNumber = '");
      strcat(sqlcmd,inputFileRecordNumber);
      strcat(sqlcmd,"' WHERE corporationNumber = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CorpNum);
      strcat(sqlcmd,"'\n");

      /* enviamos el comando a SQL Server y ejecutamos. */
      resultado = sqlEval(q_dbproc, sqlcmd);
      if(resultado == 1) 
      {
        ++Reg4000Act;      
      }
      else
      { 
        CifrasControl();
        exit(1);
      }
      break;

    case 4100:   /* Registro 4100 */
    /*AFRH EISSA 09/20/2004  anterior 00004
      sprintf(CorpNum,"%s", substr(cadena, 21, 19));
      sprintf(OrgPointNum,"%s", substr(cadena, 66, 19));
      sprintf(CodError,"%s", substr(cadena, 644, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 638, 6));
    AFRH EISSA 09/20/2004  anterior 00004*/
    /*AFRH EISSA 09/20/2004  nuevo 00004*/
      sprintf(CorpNum,"%s", substr(cadena, 27, 19));
      sprintf(OrgPointNum,"%s", substr(cadena, 72, 19));
      sprintf(CodError,"%s", substr(cadena, 650, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 644, 6));
    /*AFRH EISSA 09/20/2004  nuevo 00004*/

      /* armamos el sql. */
      sprintf(sqlcmd,"UPDATE REG4100 ");
      strcat(sqlcmd,"SET outgoingIncomingErrorCode = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CodError);
      strcat(sqlcmd,"', inputFileRecordNumber = '");
      strcat(sqlcmd,inputFileRecordNumber);
      strcat(sqlcmd,"'");
      strcat(sqlcmd,"\n WHERE corporationNumber = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CorpNum);
      strcat(sqlcmd,"'");
      strcat(sqlcmd,"\n AND organizationPointNumber = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,OrgPointNum);
      strcat(sqlcmd,"'\n");

      /* enviamos el comando a SQL Server y ejecutamos. */
      resultado = sqlEval(q_dbproc, sqlcmd);
      if (resultado == 1) 
      {
        ++Reg4100Act;      
      }
      else
      { 
        CifrasControl();
        exit(1);
      }
      break;

    case 4200:   /* Registro 4200 */
    /*AFRH EISSA 09/20/2004  anterior 00005
	  sprintf(CorpNum,"%s", substr(cadena, 21, 19));
      sprintf(OrgPointNum,"%s", substr(cadena, 66, 19));
      sprintf(CodError,"%s", substr(cadena, 163, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 157, 6));
    /*AFRH EISSA 09/20/2004  anterior 00005*/
    /*AFRH EISSA 09/20/2004  nuevo 00005*/
	  sprintf(CorpNum,"%s", substr(cadena, 27, 19));
      sprintf(OrgPointNum,"%s", substr(cadena, 72, 19));
      sprintf(CodError,"%s", substr(cadena, 169, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 163, 6));
    /*AFRH EISSA 09/20/2004  nuevo 00005*/

      /* armamos el sql. */
      sprintf(sqlcmd,"UPDATE REG4200 ");
      strcat(sqlcmd,"SET outgoingIncomingErrorCode = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CodError);
      strcat(sqlcmd,"', inputFileRecordNumber = '");
      strcat(sqlcmd,inputFileRecordNumber);
      strcat(sqlcmd,"'");
      strcat(sqlcmd,"\n WHERE corporationNumber = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CorpNum);
      strcat(sqlcmd,"'");
      strcat(sqlcmd,"\n AND organizationPointNumber = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,OrgPointNum);
      strcat(sqlcmd,"'\n");

      /* enviamos el comando a SQL Server y ejecutamos. */
      resultado = sqlEval(q_dbproc, sqlcmd);
      if (resultado == 1) 
      {
        ++Reg4200Act;      
      }
      else
      { 
        CifrasControl();
        exit(1);
      }
      break;

    case 4300:   /* Registro 4300 */
    /*AFRH EISSA 09/20/2004  anterior 00006
	  sprintf(CorpNum,"%s", substr(cadena, 21, 19));
      sprintf(Cuenta,"%s", substr(cadena, 110, 19));
      sprintf(CodError,"%s", substr(cadena, 701, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 695, 6));
    /*AFRH EISSA 09/20/2004  anterior 00006*/
    /*AFRH EISSA 09/20/2004  nuevo 00006*/
	  sprintf(CorpNum,"%s", substr(cadena, 27, 19));
      sprintf(Cuenta,"%s", substr(cadena, 116, 19));
      sprintf(CodError,"%s", substr(cadena, 727, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 721, 6));
    /*AFRH EISSA 09/20/2004  nuevo 00006*/

      /* armamos el sql. */
      sprintf(sqlcmd,"UPDATE REG4300 SET outgoingIncomingErrorCode = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd, CodError);
      strcat(sqlcmd,"', inputFileRecordNumber = '");
      strcat(sqlcmd,inputFileRecordNumber);
      strcat(sqlcmd,"'");
      strcat(sqlcmd,"\nWHERE corporationNumber = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd, CorpNum);
      strcat(sqlcmd,"'");
      strcat(sqlcmd,"\nAND accountNumber = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd, Cuenta);
      strcat(sqlcmd,"'\n");

      /* enviamos el comando a SQL Server y ejecutamos. */
      resultado = sqlEval(q_dbproc, sqlcmd);
      if (resultado == 1) 
      {
        ++Reg4300Act;      
      }
      else
      { 
        CifrasControl();
        exit(1);
      }
      break;

    case 5000:   /* Registro 5000 */
    /*AFRH EISSA 09/20/2004  anterior 00007
      sprintf(Cuenta,"%s", substr(cadena, 67, 19));
      //  Modificado 19 mayo 2004 JAGG EISSA       sprintf(Referencia,"%s", substr(cadena, 93, 23));
      sprintf(Referencia,"%s", substr(cadena, 96, 23));
      sprintf(CodError,"%s", substr(cadena, 502, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 496, 6));
    /*AFRH EISSA 09/20/2004  anterior 00007*/
    /*AFRH EISSA 09/20/2004  nuevo 00007*/
      sprintf(Cuenta,"%s", substr(cadena, 73, 19));
      sprintf(Referencia,"%s", substr(cadena, 102, 23));
      sprintf(CodError,"%s", substr(cadena, 533, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 527, 6));
    /*AFRH EISSA 09/20/2004  nuevo 00007*/

      /* armamos el sql. */
      sprintf(sqlcmd,"UPDATE REG5000 ");
      strcat(sqlcmd,"SET outgoingIncomingErrorCode = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CodError);
      strcat(sqlcmd,"', inputFileRecordNumber = '");
      strcat(sqlcmd,inputFileRecordNumber);
      strcat(sqlcmd,"'");
      strcat(sqlcmd,"\n WHERE accountNumber = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,Cuenta);
      strcat(sqlcmd,"'");
      strcat(sqlcmd,"\n AND acquirersOrIssuersRefNum = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,Referencia);
      strcat(sqlcmd,"'\n");

      /* enviamos el comando a SQL Server y ejecutamos. */
      resultado = sqlEval(q_dbproc, sqlcmd);
      if (resultado == 1) 
      {
        ++Reg5000Act;      
      }
      else
      { 
        CifrasControl();
        exit(1);
      }
      break;

    case 9999:   /* Registro 9999 */
    /*AFRH EISSA 09/20/2004  anterior 00008
      sprintf(CodError,"%s", substr(cadena, 78, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 72, 6));
      AFRH EISSA 09/20/2004  anterior 00008*/
      /*AFRH EISSA 09/20/2004  nuevo 00008*/
      sprintf(CodError,"%s", substr(cadena, 84, 6));
      sprintf(inputFileRecordNumber,"%s", substr(cadena, 78, 6));
      /*AFRH EISSA 09/20/2004  nuevo 00008*/
      /* armamos el sql. */
      sprintf(sqlcmd,"UPDATE REG9999 ");
      strcat(sqlcmd,"SET outgoingIncomingErrorCode = ");
      strcat(sqlcmd,"'");
      strcat(sqlcmd,CodError);
      strcat(sqlcmd,"', inputFileRecordNumber = '");
      strcat(sqlcmd,inputFileRecordNumber);
      strcat(sqlcmd,"'\n");

      /* enviamos el comando a SQL Server y ejecutamos. */
      resultado = sqlEval(q_dbproc, sqlcmd);
      if (resultado == 1) 
      {
        ++Reg9999Act;      
      }
      else
      { 
        CifrasControl();
        exit(1);
      }
      break;

    default:
      printf("Error. Tipo de registro desconocido (%s)\n", RecordId);
      CifrasControl();
      exit(1);
      break;
  } /* Fin del case Tipo de Registro */  
} /* Lectura del archivo  */

if ( RegLeidos == 0 ) /* Valida arch vacio */
{
  printf("Error. Archivo vacio");
  CifrasControl();
  exit(1);
}

CifrasControl();
RegLeidosRech = RegLeidos - 1;
if (TotRegRech != RegLeidosRech) 
{
  printf("Error. Incongruencia en el numero de registros.\n");
  printf("Regs. leidos:     %ld\n ", --RegLeidos);
  printf("Regs. esperados:  %ld\n ", TotRegRech);
  exit(1);
}

dbcmd(q_dbproc, "COMMIT TRANSACTION");
dbsqlexec(q_dbproc);
dbresults(q_dbproc);
printf("Programa 'ActRech' termino exitosamente,\n\n");

/* Cierra nuestra conexion y sale del programa */
dbexit();
exit(STDEXIT);
}/* main*/


/*+++++++++++++++++++++++++++++++++++++++++++++*/
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

/*+++++++++++++++++++++++++++++++++++++++++++++*/
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
if ( (msgno != 5701) && (msgno !=5703) )
{
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
}
return(0);
}

/*+++++++++++++++++++++++++++++++++++++++++++++*/
/* Ejecuta una instruccion sql devolviendo si fue exitosa. En este */
/* caso en particular se considera error actualizar mas de un reg. */

int  CS_PUBLIC sqlEval(q_dbproc1, sqlcmd) 
DBPROCESS      *q_dbproc1;
char           sqlcmd[SQLBUFLEN];

{
/* Estas variables guardan el resultado del sql para la db library */
RETCODE  result_code;
DBINT    NumRegsAct;
int      exitoso = 0;    /* bandera que indica el resultado del sql */

/* enviamos el comando a SQL Server y ejecutamos. */
dbcmd(q_dbproc1, sqlcmd);
dbsqlexec(q_dbproc1);

/* Procesa cada instruccion sql hasta que no haya mas */
while ((result_code = dbresults(q_dbproc1)) != NO_MORE_RESULTS)
{
  NumRegsAct = DBCOUNT(q_dbproc1);

  /*Identifica el tipo de registro y su codigo de error */
  switch (NumRegsAct)
  {
    case -1:
      printf("Error al ejecutar la instruccion SQL:\n ");
      printf("%s\n",sqlcmd);
      break;

    case 0:
      printf("Error. No existe registro para actualizar:\n ");
      printf("%s\n",sqlcmd);
      break;

    case 1:   
      if (result_code == SUCCEED)
      {
        exitoso = 1; 
      }
      else
      { 
        printf("Error al ejecutar el SQL:\n ");
        printf("%s\n",sqlcmd);
      }
      break;

    default:
      printf("Error. Actualizo mas de un registro para esa llave:\n ");
      printf("%s\n",sqlcmd);
      exitoso = 1;  /*  JAGG   */
      break;
  }
} 

/*printf("Exitoso: %d\n", exitoso);*/
return (exitoso);
}

/*+++++++++++++++++++++++++++++++++++++++++++++*/
/* Despliega No. de regs procesados al momento de llamar la rutina */
int CS_PUBLIC CifrasControl() 
{ 
/*char *msgCifCtrl;*/
char msgCifCtrl[100];
printf("\n\n******************* Cifras de Control *******************\n\n");
printf("Prog 'ActRech':  Actualiza Regs Rechazados por MasterCard\n\n");

sprintf(msgCifCtrl,"Regs actualizados en Reg1000:    %ld", Reg1000Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs lei tipo sumario   1100:    %ld", Reg1100Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs actualizados en Reg3000:    %ld", Reg3000Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs actualizados en Reg4000:    %ld", Reg4000Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs actualizados en Reg4100:    %ld", Reg4100Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs actualizados en Reg4200:    %ld", Reg4200Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs actualizados en Reg4300:    %ld", Reg4300Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs actualizados en Reg5000:    %ld", Reg5000Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs actualizados en Reg9999:    %ld", Reg9999Act);
printf("      %s\n",msgCifCtrl);

sprintf(msgCifCtrl,"Regs leidos arch de rechazos:    %ld", RegLeidos);
printf("      %s\n\n",msgCifCtrl);

printf("*********************************************************\n\n");

return(0);
}
