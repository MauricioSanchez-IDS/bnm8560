/*                                            
** Confidential property of Eissa, Inc.       
** (c) Copyright Eissa, Inc.2000 to 2003      
** All rights reserved.                       
**                                            
** Elaborado por: Ing Jose Ramon Gonzalez Diaz
**                                            
**                                            
** r4100.c: 30/06/03 10:00 
**  
** Historia:
**  
** 01.- 30/Jun/2003 Reingenieria para procesar jerarquia. Jose Ramon G. D.
** 02.- 30/MAR/2004 Se corrigen un error en el bcp.  JOSE ALBERTO GARCIA
**
*/

#if USE_SCCSID
static char Sccsid[ ] = { "@(#) r4100.c  30/06/03" };
#endif /* USE_SCCSID */

#include <time.h>
#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include "sybdbex.h"
#include "cam4100.h" /*campos 4100*/

#define CADENAREG4100 655
#define TOTALPARAMETROS 5

/**
  *		Varibles globales  para el manejo de los argumentos de fecha proceso y nombre del archivo a generar
  **/

char fechayhora[ 20 ];
char nombrearchivo[ 60 ];
char sqlcmd[ 9000 ];

/**
  *		Forward declarations of the error handler and message handler.
  **/

int CS_PUBLIC err_handler( );
int CS_PUBLIC msg_handler( );

main( argc, argv )
int argc;
char *argv[];
{
	FILE *reg4100;

	DBPROCESS *q_dbproc;	/* Our connection with SQL Server. */
	DBPROCESS *c_dbproc;	/* coneccion para cuentas y plasticos */
	DBPROCESS *d_dbproc;	/* coneccion para reg4100 */
	DBPROCESS *m_dbproc;	/* coneccion para MTC4100 */
	DBPROCESS *s_dbproc;	/* coneccion para creditos */
	DBPROCESS *t_dbproc;	/* coneccion para debitos */
	LOGINREC  *login;		/* Our login information. */

	/**
	  *		Variables que contienen la informaci'on del registro
	  **/

	char cadenareg4100[ CADENAREG4100 + 1 ];
	char cadenaregMTC4100[ CADENAREG4100 + 1 ];

	time_t lcl_time;
	struct tm *today;
	
	int cont1, cont2, dec;
	
	/**
	  *		Variables para almacenar los datos del al DB
	  **/

	char ge_user[ 10 ];
	char ge_password[ 10 ];
	char ge_server[ 10 ];
	char ge_hostname[ 10 ];
	char ge_dbase[ 10 ];

	/**
	  *		Variables globales para el manejo de los argumentos.
	  **/
	extern char fechayhora[ 20 ];
	extern char nombrearchivo[ 60 ];
	extern char sqlcmd[ 9000 ];

	RETCODE result_code;

	char ejePrefijo[ 4 + 1 ];
	char gpoBanco[ 2 + 1 ];
	char empNumero[ 5 + 1 ];
	char cadenamtc[ 150 ];
	char cadena[ 50 ];
	char directorio_archivo[ 50 ];
	char nombrearchivo_temp[ 100 ];
	int long_ini;
	int i;
	int act;
	char num_orgpointnum[ 19 + 1 ];
	char numero_corporacion[ 19 + 1 ];
	int cor_emp_i;
	int cta_pla_i;
	int sobregiro_i;
	int creditos_i;
	int debitos_i;
	int seguir_MTC4100;
	char numemp1[ 12 ];
	char numempcta[ 12 ];
	char numempsob[ 12 ];
	int banderainserto;
	char ejeprecre[ 5 ]; 
	char bancocre[ 3 ];
	char orgpointcre[ 7 ];
	char empresacre[ 6 ];
	char ejepredeb[ 5 ];
	char bancodeb[ 3 ];
	char orgpointdeb[ 7 ];
	char empresadeb[ 6 ];
	char ejepremtc[ 5 ];
	char bancomtc[ 3 ];
	char grupomtc[ 6 ];
	char empresamtc[ 6 ];
	char bulkcopy[ 100 ];
	int indDebitos;
	int indCreditos;
	int indCuentas;
	int indSobregiros;

	/**
	  *		Variables para corporativo y empresa
	  **/

	DBCHAR eje_prefijo           [ 4 + 1 ];
	DBCHAR gpo_banco             [ 2 + 1 ];
	DBCHAR gpo_num               [ 5 + 1 ];
	DBCHAR emp_num               [ 5 + 1 ];
	DBCHAR org_point_num        [ 19 + 1 ];
	DBCHAR nom_empresa_1        [ 35 + 1 ];
	DBCHAR nom_empresa_2        [ 35 + 1 ];
	DBCHAR dir_empresa_1        [ 35 + 1 ];
	DBCHAR dir_empresa_2        [ 35 + 1 ];
	DBCHAR poblacion            [ 25 + 1 ];
	DBCHAR edo_provincia         [ 25 + 1];
	DBCHAR codigo_postal        [ 10 + 1 ];
	DBCHAR persona_contacto     [ 35 + 1 ];
	DBCHAR tel_persona_contacto [ 20 + 1 ];
	DBCHAR fax_persona_contacto [ 20 + 1 ];
	DBCHAR email                [ 50 + 1 ];
	DBCHAR limite_credito       [ 16 + 1 ];
	DBCHAR retrazos              [ 7 + 1 ];
	DBCHAR monto_retrazos       [ 16 + 1 ];
	DBCHAR monto_pagos_adeudo   [ 16 + 1 ];
	DBCHAR balance              [ 16 + 1 ];
	DBCHAR corporativo          [ 19 + 1 ];
	DBCHAR  reportsTo           [ 19 + 1 ];

	/**
	  *		Cuentas y plasticos 
	  **/

	DBCHAR numero_cuentas       [ 7 + 1 ];
	DBCHAR eje_prefijo_cuentas  [ 4 + 1 ];
	DBCHAR gpo_banco_cuentas    [ 2 + 1 ];
	DBCHAR emp_num_cuentas      [ 5 + 1 ];
	DBCHAR emp_org_point        [ 5 + 1 ];

	/**
	  *		Sobregiros 
	  **/

	DBCHAR numero_cuentas_sobregiro [ 7 + 1 ];
	DBCHAR eje_prefijo_sobregiro    [ 4 + 1 ];
	DBCHAR gpo_banco_sobregiro      [ 2 + 1 ];
	DBCHAR emp_num_sobregiro        [ 5 + 1 ];
	DBCHAR org_point_sobregiro      [ 6 + 1 ];

	/**
	  **		Creditos 
	  **/

	DBCHAR numero_corpo_creditos [ 19 + 1 ];
	DBCHAR numero_orgpoint_creditos [ 19 + 1 ];
	DBCHAR numero_creditos [ 10 + 1 ];
	DBCHAR monto_creditos  [ 16 + 1 ];

	/**
	  *		Debitos
	  */

	DBCHAR numero_corpo_debitos [ 19 + 1 ]; 
	DBCHAR numero_orgpoint_debitos [ 19 + 1 ]; 
	DBCHAR numero_debitos [ 10 + 1];
	DBCHAR monto_debitos  [ 16 + 1 ];

	/**
	  *		Variables para llamar fecha de corte
	  */

	DBCHAR fechaGenera [ 8 + 1 ];

	fflush( stdout );

	/**
	  *		Checa que se hayan pasado los parametros correspondientes
	  **/

	if (( argc > TOTALPARAMETROS ) || ( argc < TOTALPARAMETROS )){
		
		printf("Programa: r4100.c \n");
		printf("El numero de argumentos no son validos para el programa r4100.c\n");
		exit( 1 );
	}

	/**
	  *		Obtiene fecha y hora del proceso 
	  **/

	time( &lcl_time );
	today = localtime( &lcl_time );
	strftime( fechayhora, 20, "%Y%m%d %T", today );

	/**
	  *		Variables globales para el manejo de los argumentos nombre del archivo CDF a generar y 
	  *		el rango de fechas de los movimientos
	  **/ 

	strcpy( nombrearchivo, argv[ 1 ] );
	strcpy( ejePrefijo, argv[ 2 ] );
	strcpy( gpoBanco, argv[ 3 ] );
	strcpy( empNumero, argv[ 4 ] );

	/**
	  *		Inicializamos  DB-Library. 
	  **/

	if( dbinit( ) == FAIL ){

		/**
		  *		Registro del error en el archivo log
		  **/

		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("Error: No se inicializaron las dblibrary de C en el programa r4100.c \n");
		exit( 1 );
	}

	/** 
	  *		Install the user-supplied error-handling and message-handling 
	  *		routines. They are defined at the bottom of this source file. 
	  **/

	dberrhandle((EHANDLEFUNC)err_handler);
	dbmsghandle((MHANDLEFUNC)msg_handler);

        dbsetversion(DBVERSION_100);

	/**
	  *		Obtencion de valores de entorno
	  **/

	sprintf( ge_user, "%s", getenv("GE_USER") );
	sprintf( ge_password, "%s", getenv("GE_PASSWORD") );
	sprintf( ge_server, "%s", getenv("GE_SERVER"));
	sprintf( ge_hostname, "%s", getenv("GE_HOSTNAME") );
	sprintf( ge_dbase, "%s", getenv("GE_DBASE"));
	sprintf( directorio_archivo, "%s", getenv("DIR_TEMP") );

	if( ( strlen( ge_user ) == 0 )   || ( strlen( ge_password ) == 0 ) || 
		( strlen( ge_server ) == 0 ) || ( strlen( ge_hostname ) == 0 ) || 
		( strlen( ge_dbase ) == 0 ) || ( strlen( directorio_archivo ) == 0 ) ){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: 4100.c \n");
		printf("Error: debe verificar las variables de ambiente\n");
		exit( 1 );
	}

	/**
	  *		Damos informacion de login 
	  **/

	login = dblogin( );
	DBSETLUSER( login, ge_user );
	DBSETLPWD( login, ge_password );
	DBSETLAPP( login, ge_hostname );
	DBSETLHOST( login, ge_hostname );
        DBSETLCHARSET(login,"roman8");
	DBSETLENCRYPT(login, TRUE);

	/**
	  *		Abrimos la base de datos.
	  **/

	q_dbproc = dbopen( login, ge_server );
	c_dbproc = dbopen( login, ge_server );
	d_dbproc = dbopen( login, ge_server );
	s_dbproc = dbopen( login, ge_server );
	t_dbproc = dbopen( login, ge_server );
	m_dbproc = dbopen( login, ge_server );

	/**
	  *		Nos ubicamos en la base de datos 
	  **/

	dbuse( q_dbproc, ge_dbase );
	dbuse( c_dbproc, ge_dbase );
	dbuse( d_dbproc, ge_dbase );
	dbuse( m_dbproc, ge_dbase );
	dbuse( s_dbproc, ge_dbase );
	dbuse( t_dbproc, ge_dbase );

	sprintf( nombrearchivo_temp, "%s/reg4100.txt", directorio_archivo );

	reg4100 = fopen(nombrearchivo_temp, "w");

	if( reg4100 == NULL){

		/**
		  *		Registro del error en el archivo log 
		  **/

		printf("Fecha proceso:%s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("No se pudo abrir el archivo de trabajo\n");
		exit( 1 );
	}

	printf("Entro a ejecutar programa r4100.c, %s\n ", fechayhora );

	/**
	  *		Armamos el sql para valida la existencia de la tabla.
	  *		se borra la tabla mtccta4100 si existe 
	  **/

	sqlcmd[ 0 ] = '\0';
	sprintf( sqlcmd, " if object_id('dbo.mtccta4100') is not null ");
	strcat( sqlcmd, " begin ");
	strcat( sqlcmd, " drop table dbo.mtccta4100 ");
	strcat( sqlcmd, " end ");

	dbcmd( q_dbproc, sqlcmd );

	

	if ( dbsqlexec(q_dbproc) == FAIL){
		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("Fallo al intentar borrar la tabla mtccta4100 dbsqlexec\n");
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	dbcancel( q_dbproc );

	/**
	  *		Armamos el sql para valida la existencia de la tabla
	  *		se borra la tabla mtcsob4100 si existe 
	  **/

	sqlcmd[ 0 ] = '\0';
	sprintf( sqlcmd, "if object_id('dbo.mtcsob4100') is not null " );
	strcat( sqlcmd, " begin " );
	strcat( sqlcmd, "  drop table dbo.mtcsob4100 " );
	strcat( sqlcmd, " end " );

	dbcmd( q_dbproc, sqlcmd );

	

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		
		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("Fallo al intentar borrar la tabla mtcsob4100 dbsqlexec\n");
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}
	
	dbcancel(q_dbproc);

	/**		Armamos el sql para valida la existencia de la tabla
	  *		se borra la tabla mtctexr4100 existe 
	  **/
 
	sqlcmd[ 0 ] = '\0';
	sprintf( sqlcmd, "if object_id('dbo.mtctexr4100') is not null " );
	strcat( sqlcmd, " begin " );
	strcat( sqlcmd, "  drop table dbo.mtctexr4100" );
	strcat( sqlcmd, " end " );

	dbcmd(q_dbproc, sqlcmd);

	

	if( dbsqlexec(q_dbproc) == FAIL){
		
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4100.c \n");
		printf( "Fallo al intentar borrar la tabla mtctexr4100 dbsqlexec\n" );
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	dbcancel( q_dbproc );

	/**
	  *		Armamos el sql para valida la existencia de la tabla.
	  *		se borra la tabla mtctot4100 si existe 
	  **/

	sqlcmd[ 0 ] = '\0';
	sprintf( sqlcmd, "if object_id('dbo.mtctot4100') is not null " );
	strcat( sqlcmd, " begin " );
	strcat( sqlcmd, "  drop table dbo.mtctot4100 " );
	strcat( sqlcmd, " end " );

	dbcmd( q_dbproc, sqlcmd );

	

	if( dbsqlexec( q_dbproc ) == FAIL ){

		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("Fallo al intentar borrar la tabla mtctot4100 dbsqlexec\n");
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}
	
	dbcancel(q_dbproc);

	/**		Armamos el sql para valida la existencia de la tabla
	  *		se borra la tabla REG4100 si existe 
	  **/
	
	sqlcmd[ 0 ] = '\0';
	sprintf( sqlcmd, "if object_id('dbo.REG4100') is not null ");
	strcat( sqlcmd, " begin ");
	strcat( sqlcmd, "  drop table dbo.REG4100 ");
	strcat( sqlcmd, " end ");
  

	dbcmd(q_dbproc, sqlcmd);

	

	if ( dbsqlexec(q_dbproc) == FAIL){
		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("Fallo al intentar borrar la tabla REG4100 dbsqlexec\n");
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	dbcancel( q_dbproc );

	/**
	  *		Se crea la tabla REG4100 
	  **/

	sqlcmd[ 0 ] = '\0';
	sprintf( sqlcmd,"select * into REG4100 ");
	strcat( sqlcmd, "from MTC4100 where 1=2 ");


	dbcmd( q_dbproc, sqlcmd );

	
	
	if( dbsqlexec( q_dbproc ) == FAIL ){
		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("Fallo al intentar crear la tabla REG4100 dbsqlexec:%s \n", sqlcmd);
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}
	
	dbcancel( q_dbproc );

	sqlcmd[ 0 ]='\0';
	sprintf( sqlcmd, "ALTER TABLE REG4100 REPLACE addressMaintenanceActionCode DEFAULT ' ' ");

	dbcmd( q_dbproc, sqlcmd );

	
	
	if ( dbsqlexec( q_dbproc ) == FAIL ){

		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("Fallo al intentar crear la tabla REG4100 dbsqlexec:%s \n", sqlcmd );
		dbclose( q_dbproc );
		dbexit( );
		exit(ERREXIT);
	}
	
	dbcancel(q_dbproc);

	/**
	  *		Se limpian los dbproc para siguientes consultas.
	  **/

	dbcancel( q_dbproc ); /* Our connection with SQL Server. */
	dbcancel( c_dbproc ); /* coneccion para cuentas y plasticos */
	dbcancel( d_dbproc ); /* coneccion para reg4100 */
	dbcancel( s_dbproc ); /* coneccion para creditos */
	dbcancel( t_dbproc ); /* coneccion para debitos */
	dbcancel( m_dbproc ); /* coneccion para MTC4100 */


	/**
	  *		Llenado de la tabla REG4100, Enero 19, 2005 FUN.
	  **/

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';
	
	sprintf( sqlcmd, " exec spS_R4100 %s, %s, %s", ejePrefijo, gpoBanco, empNumero );

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r1200.c \n" );
		printf( "Error: Fallo al correr el procedure spS_R4100!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}


	dbcancel(q_dbproc); 
	sqlcmd[0]='\0';
	strcpy( sqlcmd, "delete REG4100 from MTC4100 where REG4100.corporationNumber = MTC4100.corporationNumber ");
	strcat( sqlcmd, "and REG4100.organizationPointNumber = MTC4100.organizationPointNumber ");
	strcat( sqlcmd, "and REG4100.organizationPointNameLine1 = MTC4100.organizationPointNameLine1 ");
	strcat( sqlcmd, "and REG4100.organizationPointNameLine2 = MTC4100.organizationPointNameLine2 ");
	strcat( sqlcmd, "and REG4100.addressLine1	= MTC4100.addressLine1 and REG4100.addressLine2 = MTC4100.addressLine2 ");
	strcat( sqlcmd, "and REG4100.city = MTC4100.city and REG4100.stateProvince = MTC4100.stateProvince  ");
	strcat( sqlcmd, "and REG4100.country = MTC4100.country and REG4100.postalCode = MTC4100.postalCode ");
	strcat( sqlcmd, "and REG4100.contactPerson = MTC4100.contactPerson and REG4100.phoneNumber = MTC4100.phoneNumber ");
	strcat( sqlcmd, "and REG4100.faxNumber = MTC4100.faxNumber and REG4100.eMailAddress = MTC4100.eMailAddress ");
	strcat( sqlcmd, "and REG4100.budgetLimit = MTC4100.budgetLimit and REG4100.totalAccounts = MTC4100.totalAccounts ");
	strcat( sqlcmd, "and REG4100.accountsPastDue = MTC4100.accountsPastDue and REG4100.accountsWithDispute = MTC4100.accountsWithDispute ");
	strcat( sqlcmd, "and REG4100.numberOfCards = MTC4100.numberOfCards and REG4100.chargeOffAmount = MTC4100.chargeOffAmount ");
	strcat( sqlcmd, "and REG4100.pastDueAmount = MTC4100.pastDueAmount and REG4100.disputeAmount = MTC4100.disputeAmount  ");
	strcat( sqlcmd, "and REG4100.creditLimit = MTC4100.creditLimit and REG4100.paymentDue = MTC4100.paymentDue ");
	strcat( sqlcmd, "and REG4100.outstandingBalance = MTC4100.outstandingBalance and REG4100.numberOfDebits = MTC4100.numberOfDebits ");
	strcat( sqlcmd, "and REG4100.numberOfCredits = MTC4100.numberOfCredits and REG4100.amountOfDebits = MTC4100.amountOfDebits ");
	strcat( sqlcmd, "and REG4100.amountOfCredits = MTC4100.amountOfCredits and REG4100.numberAccountsOverLimit = MTC4100.numberAccountsOverLimit ");

	dbcmd( q_dbproc, sqlcmd );
	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al borra datos de la REG4100!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';

	strcat( sqlcmd, "update REG4100 set addressMaintenanceActionCode = 'A' ");

	dbcmd( q_dbproc, sqlcmd );

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al Actualizar la REG4100!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';


	strcat( sqlcmd, "update REG4100 set REG4100.addressMaintenanceActionCode = 'U' from MTC4100 ");
	strcat( sqlcmd, "where REG4100.organizationPointNumber = MTC4100.organizationPointNumber ");
	strcat( sqlcmd, "and REG4100.corporationNumber = MTC4100.corporationNumber  ");

	dbcmd( q_dbproc, sqlcmd );

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al Actualizar la REG4100!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}
	

	if ( dbsqlexec(q_dbproc) == FAIL){
		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4100.c \n");
		printf("Fallo al intentar borrar la tabla mtccta4100 dbsqlexec\n");
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	fclose(reg4100);

	printf("Salgo de  ejecutar programa r4100.c %s \n",fechayhora);

	dbclose( q_dbproc ); /* Our connection with SQL Server. */
	dbclose( c_dbproc ); /* coneccion para cuentas y plasticos */
	dbclose( d_dbproc ); /* coneccion para reg4100 */
	dbclose( s_dbproc ); /* coneccion para creditos */
	dbclose( t_dbproc ); /* coneccion para debitos */
	dbclose( m_dbproc ); /* coneccion para MTC4100 */

	/* Close our connection and exit the program. */
	dbexit();
	exit(0);
}

doinicia( ){
	/*inicializamos variables */
        memset(recordidentifier,'\0', sizeof(recordidentifier));
        memset(corporationnumber,'\0', sizeof(corporationnumber));
        memset(reservedforinternaluse1,'\0', sizeof(reservedforinternaluse1));
        memset(reservedforinternaluse2,'\0', sizeof(reservedforinternaluse2));
        memset(reservedforinternaluse3,'\0', sizeof(reservedforinternaluse3));
        memset(organizationpointnumber,'\0', sizeof(organizationpointnumber));
        memset(freeformattext,'\0', sizeof(freeformattext));
        memset(organizationpointnameline1,'\0', sizeof(organizationpointnameline1));
        memset(organizationpointnameline2,'\0', sizeof(organizationpointnameline2));
        memset(addressline1,'\0', sizeof(addressline1));
        memset(addressline2,'\0', sizeof(addressline2));
        memset(city,'\0', sizeof(city));
        memset(stateprovince,'\0', sizeof(stateprovince));
        memset(country,'\0', sizeof(country));
        memset(postalcode,'\0', sizeof(postalcode));
        memset(contactperson,'\0', sizeof(contactperson));
        memset(phonenumber,'\0', sizeof(phonenumber));
        memset(faxnumber,'\0', sizeof(faxnumber));
        memset(emailaddress,'\0', sizeof(emailaddress));
        memset(budgetlimit,'\0', sizeof(budgetlimit));
        memset(totalaccounts,'\0', sizeof(totalaccounts));
        memset(accountspastdue,'\0', sizeof(accountspastdue));
        memset(accountswithdispute,'\0', sizeof(accountswithdispute));
        memset(numberofcards,'\0', sizeof(numberofcards));
        memset(chargeoffsign,'\0', sizeof(chargeoffsign));
        memset(chargeoffamount,'\0', sizeof(chargeoffamount));
        memset(pastdueamountsign,'\0', sizeof(pastdueamountsign));
        memset(pastdueamount,'\0', sizeof(pastdueamount));
        memset(disputeamountsign,'\0', sizeof(disputeamountsign));
        memset(disputeamount,'\0', sizeof(disputeamount));
        memset(creditlimitsign,'\0', sizeof(creditlimitsign));
        memset(creditlimit,'\0', sizeof(creditlimit));
        memset(paymentduesign,'\0', sizeof(paymentduesign));
        memset(paymentdue,'\0', sizeof(paymentdue));
        memset(outstandingbalancesign,'\0', sizeof(outstandingbalancesign));
        memset(outstandingbalance,'\0', sizeof(outstandingbalance));
        memset(numberofdebits,'\0', sizeof(numberofdebits));
        memset(numberofcredits,'\0', sizeof(numberofcredits));
        memset(amountofdebits,'\0', sizeof(amountofdebits));
        memset(amountofcredits,'\0', sizeof(amountofcredits));
        memset(numberaccountsoverlimit,'\0', sizeof(numberaccountsoverlimit));
        memset(portfoliodate,'\0', sizeof(portfoliodate));
        memset(addressmaintenanceactioncode,'\0', sizeof(addressmaintenanceactioncode));
        memset(inputfilerecordnumber,'\0', sizeof(inputfilerecordnumber));
        memset(outgoingincomingerrorcode,'\0', sizeof(outgoingincomingerrorcode));
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

int CS_PUBLIC msg_handler(dbproc, msgno, msgstate, severity, msgtext, srvname, procname, line)

DBPROCESS *dbproc;
DBINT msgno;
int msgstate;
int severity;
char *msgtext;
char *srvname;
char *procname;
int line;
{
	extern char fechayhora[20];
	extern char nombrearchivo[60];
	extern char sqlcmd[9000];

	if ((msgno != 5701) && (msgno != 5703)){
		if (severity == 16){
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
			printf("Programa: r4100.c \n");
			printf("Error %lid, Nivel Severidad %d, Estado %d \n", msgno, severity, msgstate);
			printf("Mensaje error: \n%s\n",msgtext);
			printf("Se ejecuta el sql: \n%s\n", sqlcmd);
			exit(1);
		}
	}
	return (0);
}
