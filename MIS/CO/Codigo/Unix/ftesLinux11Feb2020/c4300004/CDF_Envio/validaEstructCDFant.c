/*                                                               
** Confidential property of Eissa, Inc.                          
** (c) Copyright Eissa, Inc. 2000 to 2001                        
** All rights reserved.                                          
*/                                                               
/*                                                               
** validEstructCDF.c:      87.1      02/15/2001    19:05:56     
**                                                               
** Elaborado por: Ing.Jose Ramon gonzalez Diaz                   
** Este Programa para revisar la estructura de cada registro contenido
** en el archivoCDF a enviar a MC.   
**                                                               
*/                                                               

#if USE_SCCSID
static char Sccsid[ ] = { "@(#) r4100.c 87.1 01/03/01" };
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include "sybdbex.h"
#include <stdlib.h>
#include <string.h>

#define LONGCADENA 734				/*Se amplia de 708 a 734, IERM Sept. 17, 2004*/

/* Forward declarations of the error handler and message handler. */

int CS_PUBLIC   err_handler( );
int CS_PUBLIC   msg_handler( );

main(numarg, arg)
int numarg;
char *arg[];
{
	FILE * archivo;
	int IFR;     /* contendra el numero de registro dentro de archivo*/
	char cadena[LONGCADENA];
	char paso[6+1];
	char RITF[6+1];     /* para comparar el campo recordsinthisfile */
	char RI  [4+1];     /* para comprobar secuencia de numeros de registros */
	int a, i, c, n, ultimo, largo;

	char ge_user[10];
	char ge_password[10];
	char ge_server[10];
	char ge_hostname[10];
	char ge_dbase[10];

	DBPROCESS     *q_dbproc;     /* Para lectura del archivo CDF. */
	LOGINREC      *login;        /* Our login information. */

	/* These are the variables used to store the returning data. */
	char    sqlcmd[SQLBUFLEN];
	RETCODE result_code;
	DBCHAR  longReg[5];
	
	fflush( stdout );
	ultimo = i = 0;
	system("clear");
	
	/*inicializamos  DB-Library. */
	if( dbinit( ) == FAIL )
		exit( 1 );

	/*obtenemos informacion del ambiente*/          
	sprintf( ge_user, "%s", getenv("GE_USER") );
	sprintf( ge_password, "%s", getenv("GE_PASSWORD") );
	sprintf( ge_server, "%s", getenv("GE_SERVER"));
	sprintf( ge_hostname, "%s", getenv("GE_HOSTNAME") );
	sprintf( ge_dbase, "%s", getenv("GE_DBASE") );

	/* Install the user-supplied error-handling and message-handling
	routines. They are defined at the bottom of this source file.*/
	dberrhandle((EHANDLEFUNC)err_handler);
	dbmsghandle((MHANDLEFUNC)msg_handler);

        dbsetversion(DBVERSION_100);

	/* damos informacion al login */
	login = dblogin( );              
	DBSETLUSER( login, ge_user );     
	DBSETLPWD( login, ge_password );  
	DBSETLAPP( login, ge_hostname );  
	DBSETLHOST( login, ge_hostname ); 
        DBSETLCHARSET(login,"roman8");
        DBSETLENCRYPT(login, TRUE);

	if ( numarg == 2 ){

		/* abrimos la base de datos. */
		q_dbproc = dbopen(login,ge_server);

		/*nos ubicamos en la base de datos */
		dbuse(q_dbproc,ge_dbase);
		archivo=fopen(arg[1],"rb");
		
		while ( fgets(cadena,LONGCADENA,archivo) ){						/*Lee el retorno*/
			largo= strlen(cadena)-1;   /* el -1 elimina el carreturn */
			
			if( i == 0 ){
				/* carga de inputfilerecorenumber */
				for( a = 0 ; a < 6 ; a++ )
					paso[ a ] = cadena[ 175 + a ];
				
				paso[a]='\0';
			}

			/* carga de recordidentifier      */
			for( a = 0 ; a < 4 ; a++ )
				RI[ a ] = cadena[ 0 + a ];

			i = IFR = atoi(paso);
			
			if (ultimo){
				printf("ERROR despues del registro 9999 hay mas registros\n");
			}

			/* armamos el sql. */
			sprintf( sqlcmd, "select * from MTCCDF01 ");
			strcat(sqlcmd,"where cdfNumRegistro = '");
			strcat(sqlcmd,RI);
			strcat(sqlcmd,"'");
			//printf("(%s)\n",sqlcmd);

			/* enviamos el comando a SQL Server y ejecutamos. */
			dbcmd(q_dbproc, sqlcmd);

			/* ejecutamos. */
			dbcancel(q_dbproc);

			dbsqlexec(q_dbproc);

			/* Process each command until there are no more. */
			while ((result_code = dbresults(q_dbproc)) != NO_MORE_RESULTS){
				if (dbrows(q_dbproc) != 0){
					if (result_code == SUCCEED){
						dbcancel(q_dbproc);

						/*obtenemos la longitud del registro*/
						sprintf( sqlcmd, "select tabLongReg from MTCTAB01 ");
						strcat( sqlcmd, "where tabIdTabla = '");
						strcat( sqlcmd, RI);
						strcat( sqlcmd, "'");
						//printf("\n( %s )\n", sqlcmd);
						
						/*enviamos el sql */
						dbcmd(q_dbproc, sqlcmd);

						/*ejecutamos el sql*/
						dbcancel( q_dbproc );
						dbsqlexec( q_dbproc );

						/*evaluamos el resultado*/
						while (( result_code = dbresults( q_dbproc )) != NO_MORE_RESULTS ){
							if( dbrows( q_dbproc ) != 0 ){
								if ( result_code == SUCCEED ){
									/* Bind program variables. */
									dbbind( q_dbproc, 1, NTBSTRINGBIND, 0, (CS_BYTE *)longReg);
									while( dbnextrow( q_dbproc ) != NO_MORE_ROWS );
								}
							}
							else
								printf("ERROR fatal no existe el registro %s en MTCTAB01\n",RI);
						}
					}
				}
				else
					printf("ERROR fatal no existe el registro %s en MTCCDF01\n",RI);
			}/* While results de MTCCDF01  */

/*			printf("Longitud del registro leido (%s)\n",longReg);
			printf("Longitud de la cadena leida (%d)\n",largo);*/

			if (atoi(longReg)!= largo)
				printf("ERROR el registro tiene longitud %d, diferente al archivo (%s)\n",largo,longReg); 

			/* COMPROBACION DE LA SECUENCIA EN EL CAMPO InputFileRecordNumber */

			switch( atoi( longReg )){
				case 187:
					printf("entro al registro 1000++++++++++++++++++++++++++++++++\n");
					break;

				case 398:   /* Supone registro 3000 */
					for ( a = 0 ; a < 6 ; a++ )
						paso[ a ] = cadena[ 386 + a ];				//Prueba de 380 a 386
					
					paso[a]='\0';
					
					if ( atoi( paso ) != ++IFR )
					{
						printf("Error en la secuencia %d ( registro 3000 )\n", IFR );
						printf("paso (%d) IFR (%d) ",atoi( paso ),IFR-1);
					}
					break;
					
				case 613:   /* Supone registro 4000 */
					for( a = 0 ; a < 6 ; a++ )
						paso[ a ] = cadena[ 601 + a ];				//Prueba de 595 a 601
					
					paso[ a ] = '\0';

					if( atoi( paso ) != ++IFR )
					{
						printf("Error en la secuencia %d (registro 4000)\n",IFR);
						printf("paso (%d) IFR (%d) ",atoi( paso ),IFR-1);
					}
					break;

				case 655:   /* Supone registro 4100 */
					for( a = 0 ; a < 6 ; a++ )
						paso[ a ] = cadena[ 643 + a ];				//Prueba de 637 a 643

					paso[ a ] = '\0';

					if( atoi( paso ) != ++IFR )
					{
						printf("Error en la secuencia %d (registro 4100)\n", IFR);
						printf("paso (%d) IFR (%d) ",atoi( paso ),IFR-1);
					}
					break;

				case 174:   /* Supone registro 4200 */
					for( a = 0 ; a < 6 ; a++ )
						paso[ a ] = cadena[ 162 + a ];				//Prueba de 156 a 162

					paso[ a ] = '\0';

					if( atoi( paso ) != ++IFR )
					{
						printf("Error en la secuencia %d (registro 4200)\n",IFR);
						printf("paso (%d) IFR (%d) ",atoi( paso ),IFR-1);
					}
					break;

				case 732:   /* Supone registro 4300 */
					for( a = 0 ; a < 6 ; a++ )
						paso[ a ] = cadena[ 720 + a ];				//Prueba de 694 a 720
					
					paso[ a ]='\0';
					
					if( atoi( paso ) != ++IFR )
					{
						printf("Error en la secuencia %d (registro 4300)\n",IFR);
						printf("paso (%d) IFR (%d) ",atoi( paso ),IFR-1);
					}
					break;

				case 538:   /* Supone registro 5000 */
					for( a = 0 ; a < 6 ; a++ )
						paso[ a ] = cadena[ 526 + a ];				//Prueba de 495 a 516

					paso[ a ] = '\0';
					
					if( atoi( paso ) != ++IFR )
					{
						printf("Error en la secuencia %d (registro 5000)\n",IFR);
						printf("paso (%d) IFR (%d) ",atoi( paso ),IFR-1);
					}
					break;

				case 89:    /* Supone registro 9999 */
					for ( a = 0 ; a < 6 ; a++)
						paso[ a ] = cadena[ 77 + a ];				//Prueba del 71 al 77
					
					paso[ a ] = '\0';
					
					for( a = 0 ; a < 6 ; a++ )
						RITF[ a ] = cadena[ 71 + a ];
					
					RITF[ a ] = '\0';
					
					if( atoi( paso ) != atoi( RITF ))
					{
						printf("ERROR el numero en recordsinthisfile (%d) es diferente a inputrecordnumber (%d)\n",atoi(RITF),atoi(paso));
						printf("paso (%d) IFR (%d) ",atoi( paso ),atoi( RITF ));
					}
					ultimo = 1;
					break;

				default:
					printf("ERROR registro desconocido con largo de (%d)\n",largo);
			}
		/*      FIN DE LA COMPROBACION DE SECUENCIA DEL FOLIO */
    }/* lectura del archivo  */
  }
  else
		printf("debe proporcionar nombre de archivo a analizar\n");
  /* Close our connection and exit the program. */
  dbexit();
  exit(0);
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
  fprintf (ERR_CH, "Msg %ld, Level %d, State %d\n", msgno, severity, msgstate);
  if (strlen(srvname) > 0)
		fprintf (ERR_CH, "Server '%s', ", srvname);
  if (strlen(procname) > 0)
		fprintf (ERR_CH, "Procedure '%s', ", procname);
  if (line > 0)
		fprintf (ERR_CH, "Line %d", line);
  fprintf (ERR_CH, "\n\t%s\n", msgtext);
  return(0);
}


