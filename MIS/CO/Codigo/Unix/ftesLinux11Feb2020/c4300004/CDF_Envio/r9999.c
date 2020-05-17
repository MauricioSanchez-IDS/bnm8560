/*
** Confidential property of Eissa, Inc.
** (c) Copyright Eissa, Inc. 2000 to 2001
** All rights reserved.
*/

/*
** r9999.c:      2/06/2001      9:31:56
**
** Elaborado por: Ing Jose Ramon Gonzalez Diaz
**  
**  
*/
#if USE_SCCSID
static char Sccsid[] = {"@(#) r9999.c  2/06/2001"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <ctype.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>  
#include "sybdbex.h"
#include "cam9999.h" /*campos 9999*/

#define CADENAREG9999 120
#define TOTALPARAMETROS 2

/* variables globales para el manejo de los argumentos de fechayhora y nombredel
 archivo a generar */                                                           
char fechayhora[20];                                                            
char nombrearchivo[60];                                                         
char sqlcmd[3000];                                                              


/* Forward declarations of the error handler and message handler. */
int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();


/* variables para uso del proceso */
int i;

main(argc, argv)
int             argc;
char            *argv[];

{
  FILE *reg9999;

  DBPROCESS *q_dbproc;       /* Our connection with SQL Server. */
  LOGINREC  *login;        /* Our login information. */

  /*longitud del registro*/           
  char cadenareg9999[CADENAREG9999+1];

  time_t lcl_time; 
  struct tm *today;

  char          ge_user[20];     
  char          ge_password[20]; 
  char          ge_server[20];   
  char          ge_hostname[20]; 
  char          ge_dbase[20];    

  char bulkcopy[500];          
  char directorio_archivo[150]; 
  char nombrearchivo_temp[300];

  /* variables globales para el manejo de los argumentos de fecha proceso y nombre del archivo a generar  */    
  extern char fechayhora[20];                             
  extern char nombrearchivo[60];                          
  extern char sqlcmd[3000];                                

  /* variables para la informacion de la tabla MTCICA01 */

  DBCHAR issuerica[11+1];
  DBCHAR issuernumberica[11+1];

    /* checa que se hayan pasado los parametros correspondientes*/              
/* JMC                                                                              
  if ((argc > TOTALPARAMETROS) || (argc < TOTALPARAMETROS))                     
    {
     printf("Programa: r9999.c \n");
     printf("El numero de argumentos no son validos para el programa r9999.c\n");
     exit(1);
    }                                                                             
JMC */
  /*obtiene fecha y hora del proceso */     
  time(&lcl_time);                          
  today = localtime(&lcl_time);             
  strftime(fechayhora,20,"%Y%m%d %T",today); 

  /* variables globales para el manejo de los argumentos nombre del archivo CDF a generar y el rango de fechas de los movimientos*/
  strcpy(nombrearchivo,argv[1]);                                               
 
    /*inicializamos  DB-Library. */                                               
  if (dbinit() == FAIL)
      {
       /* Registro del error en el archivo log */
       printf("Fecha proceso:%s\n", fechayhora);
       printf("Nombre archivo: %s\n", nombrearchivo);
       printf("Programa: r9999.c \n");
       printf("Error: No se inicializaron las dblibrary de C en el programa r9999.c");                                                                          
       exit(1);
      }

  /* Install the user-supplied error-handling and message-handling
  * routines. They are defined at the bottom of this source file.
  */
  dberrhandle((EHANDLEFUNC)err_handler);                          
  dbmsghandle((MHANDLEFUNC)msg_handler);                          

  dbsetversion(DBVERSION_100);

  /*obtenemos la informacion del ambiente*/       
  sprintf(ge_user,"%s",getenv("GE_USER"));        
  sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
  sprintf(ge_server,"%s",getenv("GE_SERVER"));    
  sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));
  sprintf(ge_dbase,"%s",getenv("GE_DBASE"));       
  sprintf(directorio_archivo,"%s",getenv("DIR_TEMP"));                 
                                                                       
  
  if ( ( (strlen(ge_user) == 0)   || (strlen(ge_password) == 0)        || 
      (strlen(ge_server) == 0) || (strlen(ge_hostname) == 0)        || 
      (strlen(ge_dbase) == 0)  || (strlen(directorio_archivo) == 0) ) )
    {                                                                      
     printf("Fecha proceso: %s\n", fechayhora);                            
     printf("Nombre archivo: %s\n", nombrearchivo);                        
     printf("Programa: r9999.c \n");                                       
     printf("Error: debe verificar las variables de ambiente\n");          
     exit(1);                                                              
    }                                                                      
                                                                       
   login = dblogin();             
   DBSETLUSER(login, ge_user);    
   DBSETLPWD(login, ge_password); 
   DBSETLAPP(login, ge_hostname); 
   DBSETLHOST(login, ge_hostname); 
   DBSETLCHARSET(login,"roman8");
   DBSETLENCRYPT(login, TRUE);
   /*                                  
   ** abrimos la base de datos.        
   */                                  
                                     
   q_dbproc = dbopen(login, ge_server);
                                     
   /*nos ubicamos en la base de datos*/
   dbuse(q_dbproc, ge_dbase);          

   sprintf(nombrearchivo_temp,"%s/reg9999.txt",directorio_archivo); 
 
  fflush(stdout);

  system("date \"+%I:%M:%S %p ************inicio el programa          \"");

   /* armamos el sql para valida la existencia de la tabla. */        
                                                                    
 /* se borra la tabla REG9999 si existe */                          
 sprintf(sqlcmd,"if object_id('dbo.REG9999') is not null ");        
 strcat(sqlcmd," begin ");                                          
 strcat(sqlcmd,"  drop table dbo.REG9999 ");                        
 strcat(sqlcmd," end ");                                            
 dbcmd(q_dbproc, sqlcmd);                                           
 if ( dbsqlexec(q_dbproc) == FAIL)                                  
   {                                                                
    printf("Fecha proceso: %s\n", fechayhora);                      
    printf("Nombre archivo: %s\n", nombrearchivo);                  
    printf("Programa: r9999.c \n");                                 
    printf("Fallo al intentar borrar la tabla REG9999 dbsqlexec\n");
    dbclose(q_dbproc);                                              
    dbexit();                                                       
    exit(ERREXIT);                                                  
   }                                                                
 dbcancel(q_dbproc);                                                

   /* se crea la tabla REG9999 */                                    
 sprintf(sqlcmd,"select * into REG9999 ");                         
 strcat(sqlcmd, "from MTC9999 where 1=2 ");                        
 dbcmd(q_dbproc, sqlcmd);                                          
 if ( dbsqlexec(q_dbproc) == FAIL)                                 
   {                                                               
    printf("Fecha proceso: %s\n", fechayhora);                     
    printf("Nombre archivo: %s\n", nombrearchivo);                 
    printf("Programa: r9999.c \n");                                
    printf("Fallo al intentar crear la tabla REG9999 dbsqlexec\n");
    dbclose(q_dbproc);                                             
    dbexit();                                                      
    exit(ERREXIT);                                                 
   }                                                               
 dbcancel(q_dbproc);                                               


/*****************************************************************************/
  /*obtengo datos de la tabla de MTCICA01*/

  sprintf(sqlcmd,"select icaNumero,icaNumBanco from MTCICA01");

  dbcmd(q_dbproc, sqlcmd);

  if ( dbsqlexec(q_dbproc) == FAIL)                                           
    {                                                                        
     printf("Fecha proceso:%s\n", fechayhora);                               
     printf("Nombre archivo: %s\n", nombrearchivo);                          
     printf("Programa: r9999.c \n");                                         
     printf("Error: Fallo al intentar traer datos de MTCICA01 bdsqlexec \n");
     dbclose(q_dbproc);                                                      
     dbexit();                                                               
     exit(ERREXIT);                                                          
    }                                                                        
  dbresults(q_dbproc);                                                         
  if ( DBROWS(q_dbproc) != SUCCEED)                                             
    {                                                                          
     printf("Fecha proceso:%s\n", fechayhora);                                 
     printf("Nombre archivo: %s\n", nombrearchivo);                            
     printf("Programa: r9999.c \n");                                           
     printf("Fallo al intentar traer datos de MTCICA01 DBROWS\n");             
     dbclose(q_dbproc);                                                        
     dbexit();
     exit(ERREXIT);
    }                                                                               

  dbbind(q_dbproc, 1, NTBSTRINGBIND, (DBINT)0,(BYTE DBFAR *)issuerica);
  dbbind(q_dbproc, 2, NTBSTRINGBIND, (DBINT)0,(BYTE DBFAR *)issuernumberica);
   while (dbnextrow(q_dbproc) != NO_MORE_ROWS);

/*****************************************************************************/
 
/* Preparo el archivo que se utilizara para realizar bulkcopy */          
reg9999 = fopen(nombrearchivo_temp, "w");                                 
if (reg9999 == NULL)                                                      
  {                                                                       
   /* registro del error en el archivo log */                             
   printf("Fecha proceso:%s\n", fechayhora);                              
   printf("Nombre archivo: %s\n", nombrearchivo);                         
   printf("Programa: r9999.c \n");                                        
   printf("No se pudo abrir el archivo de trabajo %ld\n",nombrearchivo_temp); 
   exit(1);                                                               
  }                                                                       
            /* campo 1: */ 
              sprintf(recordidentifier,FRMA4,"9999"); 
            /* campo 2: */  
              sprintf(issuerica,"%011d",atoi(issuerica)); 
            /* campo 3: */ 
              sprintf(issuernumberica,FRMA11,issuernumberica);
            /* campo 4: */
              sprintf(reservedforinternaluse1,FRMA19,reservedforinternaluse1);
            /* campo 5: */
              sprintf(reservedforinternaluse2,FRMA3,reservedforinternaluse2);
            /* campo 6: */
              sprintf(reservedforinternaluse3,FRMA17,reservedforinternaluse3);
            /* campo 7: */
              sprintf(reservedforinternaluse4,FRMA6,reservedforinternaluse4);
            /* campo 8: */
              sprintf(numberofrecordsinthisfile,FRMN6,numberofrecordsinthisfile);
            /* campo 9: */
              sprintf(inputfilerecordnumber,FRMN6,inputfilerecordnumber);
            /* campo 10: */ 
              sprintf(outgoingincomingerrorcode,FRMA6,outgoingincomingerrorcode);

          /*inserto la informacion*/

          sprintf(cadenareg9999,"%s\t",recordidentifier);
          sprintf(cadenareg9999,"%s%s\t",cadenareg9999,issuerica);
          sprintf(cadenareg9999,"%s%s\t",cadenareg9999,issuernumberica);
          sprintf(cadenareg9999,"%s%s\t",cadenareg9999,reservedforinternaluse1);
          sprintf(cadenareg9999,"%s%s\t",cadenareg9999,reservedforinternaluse2);
          sprintf(cadenareg9999,"%s%s\t",cadenareg9999,reservedforinternaluse3);
          sprintf(cadenareg9999,"%s%s\t",cadenareg9999,reservedforinternaluse4);
          sprintf(cadenareg9999,"%s%s\t",cadenareg9999,numberofrecordsinthisfile);
          sprintf(cadenareg9999,"%s%s\t",cadenareg9999,inputfilerecordnumber);
          sprintf(cadenareg9999,"%s%s",cadenareg9999,outgoingincomingerrorcode);
          
         if ((fprintf(reg9999,"%s\n",cadenareg9999)) == -1)                     
           {                                                                    
            printf("Fecha proceso: %s\n", fechayhora);                          
            printf("Nombre archivo: %s\n", nombrearchivo);                      
            printf("Programa: r9999.c \n");                                     
            printf("Error: No se grabo el registro en el archivo reg9999.txt ");
            exit(ERREXIT);                                                      
           }                                                                    
                                                                            
         fclose(reg9999);                                                       
                                                                            
  /* Se ejecuta el bulkcopyprocedure de reg9999.txt a la tabla REG9999 */   
  sprintf(bulkcopy,"bcp M111.dbo.REG9999 in %s ", nombrearchivo_temp);      
  strcat(bulkcopy, " -c -U");                                               
  strcat(bulkcopy, ge_user);                                                
  strcat(bulkcopy, " -P");                                                  
  strcat(bulkcopy, ge_password);                                            
  strcat(bulkcopy, " -S");                                                  
  strcat(bulkcopy, ge_server);                                              
  system(bulkcopy);                                                         
                                                                            
  printf("Hora de termino del proceso para generar el registro 9999 \n");    

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
        printf("FechaProceso: %s\n", fechayhora);                               
        printf("Nombre Archvio: %s\n", nombrearchivo);                          
        printf("Nombre Programa: r4200.c \n");                                  
        printf("Error %ld, Nivel severidad %d, Estado %d\n", msgno, severity,msgstate);                                                                       
        printf("Mensaje error: \n%ld\n", msgtext);                               
        printf("Se ejecutaba el sql: %s\n", sqlcmd);                            
                                                                                
        exit(1);                                                                
       }                                                                        
    }                                                                           
    return (0);
}


