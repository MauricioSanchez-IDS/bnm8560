/*
** Confidential property of Eissa, Inc. 
** (c) Copyright Eissa, Inc.2000 to 2001
** All rights reserved.      
*/     

/*
** r3000.c:      87.1      12/29/93      19:05:56
**  
** Elaborado por: Ing Jose Ramon Gonzalez Diaz
**
**  
*/
#if USE_SCCSID
static char Sccsid[] = {"@(#) r3000.c 87.1 12/29/93"};
#endif /* USE_SCCSID */

#include <stddef.h>
#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "sybdbex.h"
#include "cam3000.h" /*campos 3000*/


#define CADENAREG3000 398
#define TOTALPARAMETROS 2

/*variables globales para el manejo de errores*/
char fechayhora[20];      
char nombrearchivo[60];   
char sqlcmd[5000];        

/* Forward declarations of the error handler and message handler. */ 
int CS_PUBLIC   err_handler();      
int CS_PUBLIC   msg_handler();      

main(argc, argv)
int  argc;
char *argv[];
{
  
	FILE *reg3000;

	DBPROCESS     *q_dbproc;       /* Our connection with SQL Server. */
	DBPROCESS     *i_dbproc;       /* Our connection with SQL Server. */
	DBPROCESS     *m_dbproc;       /* Our connection with SQL Server. */
	LOGINREC      *login;        /* Our login information. */

	/*longitud del registro*/
	char cadenareg3000[CADENAREG3000+1];
	char cadenamtc3000[CADENAREG3000+1];

	time_t lcl_time; 
	struct tm *today;

	char          ge_user[10];    
	char          ge_password[10];
	char          ge_server[10];  
	char          ge_hostname[10];
	char          ge_dbase[10];   

	char directorio_archivo[50];  
	char nombrearchivo_temp[100]; 
	char bulkcopy[100];
	int act;

	/* These are the variables used to store the returning data. */ 
	extern char fechayhora[20];
	extern char nombrearchivo[60];
	extern char sqlcmd[5000];

	fflush(stdout);
 
	if((argc > TOTALPARAMETROS) || (argc < TOTALPARAMETROS)){

		printf("Programa: r3000.c \n");
		printf("El numero de argumentos no son validos para el programa r3000.c\n");
		exit(1);
	}

	/*obtiene fecha y hora del proceso */
	time(&lcl_time);
	today = localtime(&lcl_time);
	strftime(fechayhora,20,"%Y%m%d %T",today);

	/* variables globales para el manejo de los argumentos nombre del archivo CDF a generar y el rango de fechas de los movimientos*/
	strcpy(nombrearchivo,argv[1]);

	/*inicializamos  DB-Library. */
	if (dbinit() == FAIL){

		/*registro del error en el archivo log*/
		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r3000.c \n");
		printf("Error: No se inicializaron las dblibrary de C en el programa r3000.c \n");
		exit(1);
	}

	/** Install the user-supplied error-handling and message-handling
	  * routines. They are defined at the bottom of this source file.
	  **/

	dberrhandle((EHANDLEFUNC)err_handler);
	dbmsghandle((MHANDLEFUNC)msg_handler);

	/*obtenemos informacion del ambiente*/
	sprintf(ge_user,"%s",getenv("GE_USER"));
	sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
	sprintf(ge_server,"%s",getenv("GE_SERVER"));
	sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));
	sprintf(ge_dbase,"%s",getenv("GE_DBASE"));
	sprintf(directorio_archivo,"%s",getenv("DIR_TEMP"));

	if( ( (strlen(ge_user) == 0) || (strlen(ge_password) == 0) || (strlen(ge_server) == 0) || (strlen(ge_hostname) == 0) ||  (strlen(ge_dbase) == 0) || (strlen(directorio_archivo) == 0) ) ) {

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r3000.c \n");
		printf("Error: debe verificar las variables de ambiente\n");
		exit(1);
	}

	/**
	  * damos informacion del login
	  **/

	login = dblogin();
	DBSETLUSER(login, ge_user);
	DBSETLPWD(login, ge_password);
	DBSETLAPP(login, ge_hostname);
	DBSETLHOST(login, ge_hostname);
        DBSETLCHARSET(login,"roman8");

	/**
	  * abrimos la base de datos.
	  **/

	q_dbproc = dbopen(login, ge_server);
	i_dbproc = dbopen(login, ge_server);
	m_dbproc = dbopen(login, ge_server);

	/*nos ubicamos en la base de datos */
	dbuse(q_dbproc, ge_dbase);
	dbuse(i_dbproc, ge_dbase);
	dbuse(m_dbproc, ge_dbase);

	sprintf(nombrearchivo_temp,"%s/reg3000.txt",directorio_archivo);

	printf("Hora de Inicio del proceso para generar el registro 3000 \n");
	system("date \"+%I:%M:%S %p ************ entro a ejecutar programa\" \n");

	/* se borra la tabla REG3000 si existe */
	sprintf(sqlcmd,"if object_id('dbo.REG3000') is not null ");
	strcat(sqlcmd," begin ");
	strcat(sqlcmd,"  drop table dbo.REG3000 ");
	strcat(sqlcmd," end ");
	dbcmd(q_dbproc, sqlcmd);


	if ( dbsqlexec(q_dbproc) == FAIL){
		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r3000.c \n");
		printf("Fallo al intentar borrar la tabla REG3000 dbsqlexec\n");
		dbclose(q_dbproc);
		dbexit();
		exit(1);
	}

	dbcancel(q_dbproc);

	/* se crea la tabla REG3000 */
	sprintf(sqlcmd,"select * into REG3000 ");
	strcat(sqlcmd, "from MTC3000 where 1=2 ");
	dbcmd(q_dbproc, sqlcmd);

	
	if ( dbsqlexec(q_dbproc) == FAIL){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r3000.c \n");
		printf("Fallo al intentar crear la tabla REG3000 dbsqlexec\n");
		dbclose(q_dbproc);
		dbexit();
		exit(1);
	}

	dbcancel(q_dbproc);

	sqlcmd[ 0 ] = '\0';
	strcpy( sqlcmd, "select icaNumero,icaNumBanco,icaNomEmisor1,icaNomEmisor2,icaIssuerDirContac1,icaIssuerDirContac2, ");
	strcat( sqlcmd, "icaIssuerCiuContac1,icaIssuerEdoProvContac1,icaIssuerPaisContac1,icaIssuerCpContac1,currency, ");
	strcat( sqlcmd, "icaIssuerNomContac1,icaIssuerTelContac1,icaIssuerFaxContac1,icaIssuerEmailContac1, ");
	strcat( sqlcmd, "addressMaintenanceActionCode = ' '  ");
	strcat( sqlcmd, "into #REG3000 ");
	strcat( sqlcmd, "from MTCICA01 ");
	strcat( sqlcmd, "select a.*   ");
	strcat( sqlcmd, "into #Iguales  ");
	strcat( sqlcmd, "from MTC3000 a, #REG3000 b  ");
	strcat( sqlcmd, "where SUBSTRING( a.issuerIca, 11 - (CHAR_LENGTH( b.icaNumero ) - 1), 11 ) = b.icaNumero ");
	strcat( sqlcmd, "and a.issuerNumberIca = b.icaNumBanco     ");
	strcat( sqlcmd, "update #REG3000  ");
	strcat( sqlcmd, "set addressMaintenanceActionCode = 'A'     ");
	strcat( sqlcmd, "delete #REG3000  ");
	strcat( sqlcmd, "from MTC3000 a, #REG3000 b ");
	strcat( sqlcmd, "where icaNomEmisor1 = a.issuerNameLine1 ");
	strcat( sqlcmd, "and b.icaNomEmisor2 = a.issuerNameLine2 ");
	strcat( sqlcmd, "and b.icaIssuerDirContac1 = a.addressLine1 ");
	strcat( sqlcmd, "and b.icaIssuerDirContac2 = a.addressLine2 ");
	strcat( sqlcmd, "and b.icaIssuerCiuContac1 = a.city ");
	strcat( sqlcmd, "and b.icaIssuerEdoProvContac1 = a.stateProvince ");
	strcat( sqlcmd, "and b.icaIssuerPaisContac1 = a.country ");
	strcat( sqlcmd, "and b.icaIssuerCpContac1 = a.postalCode ");
	strcat( sqlcmd, "and b.currency = a.currency ");
	strcat( sqlcmd, "and b.icaIssuerNomContac1 = a.contactPerson ");
	strcat( sqlcmd, "and b.icaIssuerTelContac1 = a.phoneNumber ");
	strcat( sqlcmd, "and b.icaIssuerFaxContac1 = a.faxNumber ");
	strcat( sqlcmd, "and b.icaIssuerEmailContac1 = a.emailAddress ");
	strcat( sqlcmd, "update #REG3000  ");
	strcat( sqlcmd, "set addressMaintenanceActionCode = 'U'  ");
	strcat( sqlcmd, "from #Iguales  ");
	strcat( sqlcmd, "where SUBSTRING( #Iguales.issuerIca, 11 - (CHAR_LENGTH( #REG3000.icaNumero ) - 1), 11 ) = #REG3000.icaNumero   ");
	strcat( sqlcmd, "and #Iguales.issuerNumberIca = #REG3000.icaNumBanco  ");
	strcat( sqlcmd, "select icaNumero,icaNumBanco,icaNomEmisor1,icaNomEmisor2,icaIssuerDirContac1,icaIssuerDirContac2, ");
	strcat( sqlcmd, "icaIssuerCiuContac1,icaIssuerEdoProvContac1,icaIssuerPaisContac1,icaIssuerCpContac1,currency, ");
	strcat( sqlcmd, "icaIssuerNomContac1,icaIssuerTelContac1,icaIssuerFaxContac1,icaIssuerEmailContac1, ");
	strcat( sqlcmd, "addressMaintenanceActionCode ");
	strcat( sqlcmd, "from #REG3000 ");

	dbcmd(q_dbproc, sqlcmd);

	if ( dbsqlexec(q_dbproc) == FAIL){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r3000.c \n");
		printf("Fallo al intentar crear la tabla REG3000 dbsqlexec\n");
		dbclose(q_dbproc);
		dbexit();
		exit(1);
	}

	for( act = 0 ; act < 6 ; act++ )
		dbresults( q_dbproc );

	dbbind(q_dbproc, 1, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) issuerIca);
	dbbind(q_dbproc, 2, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) issuerNumberIca);
	dbbind(q_dbproc, 3, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) issuerNameLine1);
	dbbind(q_dbproc, 4, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) issuerNameLine2);
	dbbind(q_dbproc, 5, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) addressLine1);
	dbbind(q_dbproc, 6, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) addressLine2);
	dbbind(q_dbproc, 7, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) City);
	dbbind(q_dbproc, 8, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) stateProvince);
	dbbind(q_dbproc, 9, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) Country);
	dbbind(q_dbproc, 10, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) postalCode);
	dbbind(q_dbproc, 11, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) Currency);
	dbbind(q_dbproc, 12, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) contactPerson);
	dbbind(q_dbproc, 13, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) phoneNumber);
	dbbind(q_dbproc, 14, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) faxNumber);
	dbbind(q_dbproc, 15, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) emailAddress);
	dbbind(q_dbproc, 16, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * ) addressMaintenanceActionCode);

	dbnextrow( q_dbproc );
	
	/*****************************************************************************/
	/* campo 1: */
	if( strcmp(issuerIca,"") != 0 &&  strcmp(issuerNumberIca,"") != 0 ){

		sprintf(recordidentifier,FRMA4,"3000");

		/* campo 2: */ 
/*		sprintf(issuerica,FRMN11,issuerIca);*/
	        sprintf(issuerica,"%011ld", atol(issuerIca));	

		/* campo 3: */
		sprintf(issuernumberica,FRMA11,issuerNumberIca);
		
		/* campo 4: */
		sprintf(reservedforinternaluse1,FRMA19,reservedforinternaluse1);

		/* campo 5: */
		sprintf(reservedforinternaluse2,FRMA3,reservedforinternaluse2);
		
		/* campo 6: */
		sprintf(reservedforinternaluse3,FRMA17,reservedforinternaluse3);

		/* campo 7: */
		sprintf(reservedforinternaluse4,FRMA6,reservedforinternaluse4);

		/* campo 8: */
		sprintf(issuernameline1,FRMA35,issuerNameLine1);
		
		/* campo 9: */
		sprintf(issuernameline2,FRMA35,issuerNameLine2);
		
		/* campo 10: */
		sprintf(addressline1,FRMA35,addressLine1);
		
		/* campo 11: */
		sprintf(addressline2,FRMA35,addressLine2);

		/* campo 12: */
		sprintf(city,FRMA20,City);

		/* campo 13: */ 
		sprintf(stateprovince,FRMA3,stateProvince);

		/* campo 14: */
		sprintf(country,FRMA3,Country);

		/* campo 15: */
		sprintf(postalcode,FRMA10,postalCode);

		/* campo 16: */
		sprintf(currency,FRMN3,Currency);

		/* campo 17: */
		sprintf(contactperson,FRMA35,contactPerson);

		/* campo 18: */
		sprintf(phonenumber,FRMA25,phoneNumber);

		/* campo 19: */
		sprintf(faxnumber,FRMA25,faxNumber);

		/* campo 20: */
		sprintf(emailaddress,FRMA50,emailAddress);


		/* campo 21: */
		sprintf( addressmaintenanceactioncode,FRMA1, addressMaintenanceActionCode );

		/*campo 22: */
/*		sprintf(inputfilerecordnumber,FRMN6,inputfilerecordnumber);*/
                sprintf(inputfilerecordnumber,"%06ld", atol(inputfilerecordnumber));
		/* campo 23: */
		sprintf(outgoingincomingerrorcode,FRMA6,outgoingincomingerrorcode);

		/* inserto la informacion */

		cadenareg3000[0]='\0';

		sprintf(cadenareg3000,"%s",recordidentifier);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,issuerica);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,issuernumberica);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,reservedforinternaluse1);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,reservedforinternaluse2);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,reservedforinternaluse3);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,reservedforinternaluse4);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,issuernameline1);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,issuernameline2);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,addressline1);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,addressline2);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,city);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,stateprovince);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,country);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,postalcode);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,currency);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,contactperson);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,phonenumber);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,faxnumber);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,emailaddress);
		sprintf(cadenareg3000,"%s%s",cadenareg3000,addressmaintenanceactioncode);

		sprintf(sqlcmd," insert into REG3000 \n ");
		strcat(sqlcmd,"(recordIdentifier,issuerIca,issuerNumberIca,\n");
		strcat(sqlcmd,"reservedForInternalUse1,reservedForInternalUse2,\n");
		strcat(sqlcmd,"reservedForInternalUse3,reservedForInternalUse4,\n");
		strcat(sqlcmd,"issuerNameLine1,issuerNameLine2,addressLine1,\n");
		strcat(sqlcmd,"addressLine2,city,stateProvince,\n");
		strcat(sqlcmd,"country,postalCode,currency,\n");
		strcat(sqlcmd,"contactPerson,phoneNumber,faxNumber,\n");
		strcat(sqlcmd,"emailAddress,addressMaintenanceAction,");
		strcat(sqlcmd,"inputFileRecordNumber,outgoingIncomingErrorCode)\n ");
		strcat(sqlcmd,"values\n ");
		sprintf(sqlcmd," %s ( '%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s','%s')", sqlcmd, recordidentifier,issuerica,issuernumberica, reservedforinternaluse1,reservedforinternaluse2, reservedforinternaluse3,reservedforinternaluse4, issuernameline1,issuernameline2,addressline1, addressline2,city,stateprovince, country,postalcode,currency, contactperson,phonenumber,faxnumber, emailaddress,addressmaintenanceactioncode, inputfilerecordnumber,outgoingincomingerrorcode);
		dbcmd(i_dbproc, sqlcmd);

		if( dbsqlexec(i_dbproc) == FAIL) {
			printf("Fecha proceso: %s\n", fechayhora);
			printf("Nombre archivo: %s\n", nombrearchivo);
			printf("Programa: r3000.c \n");
			printf("Fallo al intentar insertar la informacion en la tabla REG3000 dbsqlexec %s \n",sqlcmd);
			dbclose(i_dbproc);  
			dbexit();
			exit(1);
		}
		dbcancel(i_dbproc);
		act=0;
	}

	printf("Hora de termino del proceso para generar el registro 3000 \n");     
	system("date \"+%I:%M:%S %p ************ salgo de  ejecutar programa\"\n"); 
	printf("Se termino satisfactoriamente la ejecucion del programa r3000.c\n");

	dbclose(q_dbproc);
	dbclose(i_dbproc);
	dbclose(m_dbproc);
	dbexit();
	exit(0);
}



int CS_PUBLIC err_handler(dbproc, severity, dberr, oserr, dberrstr, oserrstr)
DBPROCESS       *dbproc;
int  severity;
int  dberr;
int  oserr;
char *dberrstr;
char *oserrstr;
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
DBINT msgno;
int  msgstate;
int  severity;
char *msgtext;
char *srvname;
char *procname;
int     	line;

{
	extern char fechayhora[20];
	extern char nombrearchivo[60];
	extern char sqlcmd[5000];

	if ((msgno != 5701) && (msgno != 5703)){

		if (severity == 16){

			fprintf (ERR_CH, "Msg %ld, Level %d, State %d\n", 
			msgno, severity, msgstate);

			if(strlen(srvname) > 0)
				fprintf (ERR_CH, "Server '%s', ", srvname);

			if(strlen(procname) > 0)
				fprintf (ERR_CH, "Procedure '%s', ", procname);

			if(line > 0)
				fprintf (ERR_CH, "Line %d", line);

			fprintf (ERR_CH, "\n\t%s\n", msgtext);

			/*registro del error en el archivo log*/
			printf("Fecha proceso: %s\n", fechayhora );
			printf("Nombre archivo: %ld\n", nombrearchivo );
			printf("Programa: r3000\n");
			printf("Error %lid, Nivel Severidad %d, Estado %d \n", msgno, severity, msgstate);
			printf("Mensaje error: \n%s\n",msgtext);
			printf("Se ejecuta el sql: \n%s\n", sqlcmd);
			exit(1);
		}
	}
	return (0);
}
