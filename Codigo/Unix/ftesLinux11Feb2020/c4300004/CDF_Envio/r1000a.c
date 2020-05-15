/*                                      
** Confidential property of Eissa, Inc. 
** (c) Copyright Eissa, Inc.2000 to 2001
** All rights reserved.                 
*/                                      
/*
** r1000.c:      87.1      12/29/93      19:05:56
**  
** Elaborado por: Ing Jose Ramon Gonzalez Diaz
**
**  
*/
#if USE_SCCSID
static char Sccsid[] = {"@(#) r1000.c 87.1 12/29/93"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>  
#include "sybdbex.h"
#include "cam1000.h" /*campos 1000*/

#define CADENAREG1000 187
#define TOTALPARAMETROS 2

/*  Forward declarations of the error handler and message handler. */
int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();

/*varibles globales  para el manejo de los argumentos de fecha proceso y nombre del archivo a generar*/
char fechayhora[20];
char nombrearchivo[60];
char sqlcmd[3000];

main(argc, argv)
int             argc;
char            *argv[];
{
  DBPROCESS     *q_dbproc;       /* Our connection with SQL Server. */
  DBPROCESS     *c_dbproc;     /*coneccion para los campos */
  LOGINREC      *login;        /* Our login information. */

  /*longitud del registro*/           
  char cadenareg1000[CADENAREG1000+1];
                                    
  time_t lcl_time;                    
  struct tm *today;                   

  /* These are the variables used to store the returning data. */

  extern char fechayhora[20];
  extern char nombrearchivo[60];
  extern char sqlcmd[3000];

  char           ge_user[10];
  char           ge_password[10];
  char           ge_server[10];
  char           ge_hostname[10];
  char           ge_dbase[10];
 
  char directorio_archivo[50]; 
  char nombrearchivo_temp[100];
  char bulkcopy[100];
  char fecha[8+1];
  char hora[8+1];
  char issuericarecortado[ 8 + 1 ];
 
  RETCODE result_code;
 
  if ((argc > TOTALPARAMETROS) || (argc < TOTALPARAMETROS))
  {                                                                            
   printf("Programa: r1000.c \n");                                             
   printf("El numero de argumentos no son validos para el programa r1000.c\n");
   exit(1);                                                                    
  }                                                                             

  /*obtiene fecha y hora del proceso */      
  time(&lcl_time);                           
  today = localtime(&lcl_time);              
  strftime(fechayhora,20,"%Y%m%d %T",today); 

  /* variables globales para el manejo de los argumentos nombre del archivo CDF a generar y el rango de fechas de los movimientos*/                             
   strcpy(nombrearchivo,argv[1]);

    /*inicializamos  DB-Library. */                                               
  if (dbinit() == FAIL)                                                         
    {                                                                           
    /*registro del error en el archivo log*/                                    
    printf("Fecha proceso: %s\n", fechayhora);                                  
    printf("Nombre archivo: %s\n", nombrearchivo);                              
    printf("Programa: r1000.c \n");                                             
    printf("Error: No se inicializaron las dblibrary de C en el programa r1000.c \n");                                                                          
    exit(1);                                                                    
    }                                                                           

  /* Install the user-supplied error-handling and message-handling
  * routines. They are defined at the bottom of this source file.
  */                                                              
  dberrhandle((EHANDLEFUNC)err_handler);                          
  dbmsghandle((MHANDLEFUNC)msg_handler);                          


  /*obtenemos variables de ambiente*/
  sprintf(ge_user,"%s",getenv("GE_USER"));
  sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
  sprintf(ge_dbase,"%s",getenv("GE_DBASE"));
  sprintf(ge_server,"%s",getenv("GE_SERVER"));
  sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));

  sprintf(directorio_archivo,"%s",getenv("DIR_TEMP"));                          
                                                                                
  if( ( (strlen(ge_user) == 0) || (strlen(ge_password) == 0) || (strlen(ge_server) == 0) || (strlen(ge_hostname) == 0) ||  (strlen(ge_dbase) == 0) || (strlen(directorio_archivo) == 0) ) )
{
 printf("Fecha proceso: %s\n", fechayhora);
 printf("Nombre archivo: %s\n", nombrearchivo);
 printf("Programa: r1000.c \n");
 printf("Error: debe verificar las variables de ambiente\n");
 exit(1);
}


  /*
  ** damos informacion del login
  */

  login = dblogin();
  DBSETLUSER(login, ge_user);
  DBSETLPWD(login, ge_password);
  DBSETLAPP(login, ge_hostname);
  DBSETLHOST(login, ge_hostname);
  DBSETLCHARSET(login,"roman8");
  BCP_SETL(login,TRUE);

  /*
  ** abrimos la base de datos.
  */

  q_dbproc = dbopen(login, ge_server);
  c_dbproc = dbopen(login, ge_server);

  /*nos ubicamos en la base de datos */
  dbuse(q_dbproc, ge_dbase);
  dbuse(c_dbproc, ge_dbase);

  sprintf(nombrearchivo_temp,"%s/reg1000.txt",directorio_archivo);

   printf("Hora de Inicio del proceso para generar el registro 1000 \n");     
   system("date \"+%I:%M:%S %p ************ entro a ejecutar programa\" \n"); 

   /* se borra la tabla REG1000 si existe */                          
   sprintf(sqlcmd,"if object_id('dbo.REG1000') is not null ");        
   strcat(sqlcmd," begin ");                                          
   strcat(sqlcmd,"  drop table dbo.REG1000 ");                        
   strcat(sqlcmd," end ");                                            
   dbcmd(q_dbproc, sqlcmd);                                           
   if ( dbsqlexec(q_dbproc) == FAIL)                                  
     {                                                                
      printf("Fecha proceso: %s\n", fechayhora);                      
      printf("Nombre archivo: %s\n", nombrearchivo);                  
      printf("Programa: r1000.c \n");                                 
      printf("Fallo al intentar borrar la tabla REG1000 dbsqlexec\n");
      dbclose(q_dbproc);                                              
      dbexit();                                                       
      exit(1);                                                        
     }                                                                
   dbcancel(q_dbproc);                                                
  
  /* se crea la tabla REG1000 */                                    
  sprintf(sqlcmd,"select * into REG1000 ");                         
  strcat(sqlcmd, "from MTC1000 where 1=2 ");                        
  dbcmd(q_dbproc, sqlcmd);                                          
  if ( dbsqlexec(q_dbproc) == FAIL)                                 
    {                                                               
     printf("Fecha proceso: %s\n", fechayhora);                     
     printf("Nombre archivo: %s\n", nombrearchivo);                 
     printf("Programa: r1000.c \n");                                
     printf("Fallo al intentar crear la tabla REG1000 dbsqlexec\n");
     dbclose(q_dbproc);                                             
     dbexit();                                                      
     exit(1);                                                       
    }                                                               
  dbcancel(q_dbproc);                                                                                                                
  /*obtengo datos de la tabla de MTCICA01*/
  sprintf(sqlcmd, "select icaNumero, icaNumBanco, rejectionLevel, ");
  strcat(sqlcmd, "runModeIndicator, icaNumProcesador, icaNomProcesador, ");
  strcat(sqlcmd, "arcVerArchivo, ");
  strcat(sqlcmd, "fecha=convert(char(8),getdate(),112), ");
  strcat(sqlcmd, "hora=convert(char(8),getdate(),108) ");
  strcat(sqlcmd, "from MTCICA01");

    dbcmd(q_dbproc, sqlcmd);                                                      
  if( dbsqlexec(q_dbproc) == FAIL)                                              
    {                                                                           
     printf("Fecha proceso:%s\n", fechayhora);                                  
     printf("Nombre archivo: %s\n", nombrearchivo);                             
     printf("Programa: r1000.c \n");                                            
     printf("Error: Fallo al intentar traer datos de MTCICA01 bdsqlexec %s \n",sqlcmd);                                                                         
     dbclose(q_dbproc);                                                         
     dbexit();                                                                  
     exit(1);                                                                   
    }                                                                           
  dbresults(q_dbproc);                                                          
  if ( DBROWS(q_dbproc) != SUCCEED)                                             
    {                                                                           
     printf("Fecha proceso:%s\n", fechayhora);                                  
     printf("Nombre archivo: %s\n", nombrearchivo);                             
     printf("Programa: r1000.c \n");                                            
     printf("Fallo al intentar traer datos de MTCICA01 DBROWS\n");              
     dbclose(q_dbproc);                                                         
     dbexit();                                                                  
     exit(1);                                                                   
    }                                                                           
      dbbind( q_dbproc, 1, NTBSTRINGBIND, (DBINT)0, (BYTE DBFAR *)issuerica );
      dbbind(q_dbproc, 2, NTBSTRINGBIND, 0,(CS_BYTE *)issuernumberica);
      dbbind(q_dbproc, 3, NTBSTRINGBIND, 0,(CS_BYTE *)rejectionlevel);
      dbbind(q_dbproc, 4, NTBSTRINGBIND, 0,(CS_BYTE *)runmodeindicator);
      dbbind(q_dbproc, 5, NTBSTRINGBIND, 0,(CS_BYTE *)custumerprocessornumber);
      dbbind(q_dbproc, 6, NTBSTRINGBIND, 0,(CS_BYTE *)custumerprocessorname);
      dbbind(q_dbproc, 7, NTBSTRINGBIND, 0,(CS_BYTE *)cdfversionnumber);
      dbbind(q_dbproc, 8, NTBSTRINGBIND, 0,(CS_BYTE *)fecha);
      dbbind(q_dbproc, 9, NTBSTRINGBIND, 0,(CS_BYTE *)hora);

      while (dbnextrow(q_dbproc) != NO_MORE_ROWS);
		  /* Campo 1 */   
			sprintf(recordidentifier,FRMA4,"1000");           
		  /* Campo 2 */  
			sprintf(issuerica,"%011d", atoi( issuerica ));
		  /* Campo 3 */ 
			sprintf(issuernumberica,FRMA11,issuernumberica);            
		  /* Campo 4 */ 
			sprintf(reservedforinternaluse1,FRMA19,reservedforinternaluse1);            
		  /* Campo 5 */ 
			sprintf(reservedforinternaluse2,FRMA3,reservedforinternaluse2);            
		  /* Campo 6 */ 
			sprintf(reservedforinternaluse3,FRMA17,reservedforinternaluse3);            
		  /* Campo 7 */ 
			sprintf(reservedforinternaluse4,FRMA6,reservedforinternaluse4);            
		  /* Campo 8 */ 
			sprintf(rejectionlevel,FRMA1,rejectionlevel);            
		  /* Campo 9 */ 
			strcat(providingfromdate,fecha);
			strcat(providingfromdate," ");
			strcat(providingfromdate,hora);
			sprintf(providingfromdate,FRMA17,providingfromdate);            
		  /* Campo 10 */ 
		  strcat(providingtodate,fecha);
		  strcat(providingtodate," ");
		  strcat(providingtodate,hora);
		  sprintf(providingtodate,FRMA17,providingtodate);                   
		  /* Campo 11 */ 
		  if (strcmp(runmodeindicator,"P")==0)
		  {
			  sprintf(runmodeindicator,FRMA1,runmodeindicator);            
		  }
		else
		{
			  sprintf(runmodeindicator,FRMA1,"C");            
		}

		if (strcmp(ge_hostname,"ucadmty1")==0)				/*  FUN 22122004   */
		{													/*  FUN 22122004   */
			sprintf(runmodeindicator,FRMA1,"C");            /*  FUN 22122004   */
		}													/*  FUN 22122004   */
		else												/*  FUN 22122004   */
		{													/*  FUN 22122004   */
			sprintf(runmodeindicator,FRMA1," ");            /*  FUN 22122004   */			
		}													/*  FUN 22122004   */

		  /* Campo 12 */ 
			for( int i = 0 ; i < 9 ; i++ )
				issuericarecortado[ i ] = issuerica[ i + 3 ];

			strcat(filereferencenumber,issuericarecortado );
			//strcat(filereferencenumber,"   ");
			strcat(filereferencenumber,fecha);
			strcat(filereferencenumber,hora);
			sprintf(filereferencenumber,FRMA24,filereferencenumber);            
		  /* Campo 13 */ 
			sprintf(custumerprocessornumber,FRMN5,custumerprocessornumber);            
		  /* Campo 14 */ 
			sprintf(custumerprocessorname,FRMA35,custumerprocessorname);            
		  /* Campo 15 */ 
			sprintf(cdfversionnumber,FRMA4,cdfversionnumber);            
		  /* Campo 16 */ 
				sprintf(inputfilerecordnumber,FRMN6,inputfilerecordnumber);           
		  /* Campo 17 */ 
			sprintf(outgoingincomingerrorcode,FRMA6,"       ");
             
  /*inserto la informacion*/
  sprintf(sqlcmd,"%s", " insert into REG1000 ");
  strcat(sqlcmd,"(recordIdentifier,issuerIca,issuerNumberIca, ");
  strcat(sqlcmd,"reservedForInternalUse1,reservedForInternalUse2, ");
  strcat(sqlcmd,"reservedForInternalUse3,reservedForInternalUse4, ");
  strcat(sqlcmd,"rejectionLevel,providingFromDate,providingToDate, ");
  strcat(sqlcmd,"runModeIndicator,fileReferenceNumber, ");
  strcat(sqlcmd,"custumerProcessorNumber,custumerProcessorName, ");
  strcat(sqlcmd,"cdfVersionNumber,inputFileRecordNumber, ");
  strcat(sqlcmd,"outgoingIncomingErrorCode) ");
  strcat(sqlcmd,"values ");
  sprintf(sqlcmd,"%s ( '%s','%s', '%s',",sqlcmd,recordidentifier,issuerica,issuernumberica);
  sprintf(sqlcmd,"%s '%s', '%s',",sqlcmd,reservedforinternaluse1,reservedforinternaluse2);
  sprintf(sqlcmd,"%s '%s', '%s',",sqlcmd,reservedforinternaluse3,reservedforinternaluse4);
  sprintf(sqlcmd,"%s '%s', '%s', '%s',",sqlcmd,rejectionlevel,providingfromdate,providingtodate);
  sprintf(sqlcmd,"%s '%s', '%s',",sqlcmd,runmodeindicator,filereferencenumber);
  sprintf(sqlcmd,"%s '%s', '%s',",sqlcmd,custumerprocessornumber,custumerprocessorname);
  sprintf(sqlcmd,"%s '%s', '%s','%s' ) ",sqlcmd,cdfversionnumber,inputfilerecordnumber,outgoingincomingerrorcode);
  dbcmd(q_dbproc,sqlcmd);
  dbsqlexec(q_dbproc);
  result_code = dbresults(q_dbproc);
  if (result_code == SUCCEED)
    {
     /* printf("si grabo registro")*/;
    }
  else
    {
     /*registro del error en el archivo log*/
     printf("Fecha proceso: %s\n", fechayhora);
     printf("Nombre archivo: %s\n", nombrearchivo);
     printf("Programa: r1000\n");
     printf("Error: No se grabo el registro en la tabla REG1000\n"); 
     exit(1);
    }

  /* Close our connection and exit the program. */

  dbexit();
  exit(STDEXIT);
}



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
        extern char fechayhora[20];
        extern char nombrearchivo[60];
        extern char sqlcmd[3000];

	if ((msgno != 5701) && (msgno != 5703))
        {
          if (severity == 16)
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
        
          /*registro del error en el archivo log*/
          printf("Fecha proceso: %s\n", fechayhora );
          printf("Nombre archivo: %s\n", nombrearchivo );
          printf("Programa: r1000\n");
          printf("Error %lid, Nivel Severidad %d, Estado %d \n", msgno, severity, msgstate);
          printf("Mensaje error: \n%s\n",msgtext);
          printf("Se ejecuta el sql: \n%s\n", sqlcmd);
          exit(1);
          }
        }
	return (0);
}
