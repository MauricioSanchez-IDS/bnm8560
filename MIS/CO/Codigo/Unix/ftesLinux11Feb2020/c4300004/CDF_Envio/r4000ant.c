/*
** Confidential property of Eissa, Inc.       
** (c) Copyright Eissa, Inc.2003 to 2003      
** All rights reserved.                       
**                                            
** Elaborado por: Ing. Jose Ramon Gonzalez Diaz 
*/                                       
/*
** r4000.c:   03/07/03      10:55:45 
**
**
** Historia:
**
** 1.- 5/abr/2002 JRGD
**     reingenieria para proceso por jerarquias.  
*/
#if USE_SCCSID
static char Sccsid[] = {"@(#) r4000.c 87.1 01/03/01"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <stdlib.h>
#include <sybdb.h>
#include <string.h>
#include <time.h>
#include "sybdbex.h"
#include "cam4000.h" /*campos 4000*/

#define CADENAREG4000   613
#define LONGPREFBANCO   6
#define TOTALPARAMETROS 5

/* Forward declarations of the error handler and message handler. */
int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();

/* variables globales */
char fechayhora[20];
char nombrearchivo[60];
char sqlcmd[3000];
FILE * param;


main(argc, argv)
int             argc;
char            *argv[];
{
	/**
	  *		Puntero para lectura de Archivos
	  **/

	FILE * reg4000; 
/*	FILE * param; */


	/**
	  *		Variables de Conexion a la Base de Datos
	  **/

	DBPROCESS     *q_dbproc;
	DBPROCESS     *q_dbprocCorp;
	DBPROCESS     *q_dbprocCorp2;
	DBPROCESS     *q_dbprocEmpresa;
	DBPROCESS     *q_dbprocCtaPlas;
	DBPROCESS     *q_dbprocSobregi;
	DBPROCESS     *q_dbprocCredito;
	DBPROCESS     *q_dbprocDebitos;
	DBPROCESS     *q_dbprocCiclo;
	DBPROCESS     *q_dbprocMTC4000;
	LOGINREC      *login;        /* Our login information. */ 


	/**
	  *		Cadenas de Almacenamiento de Registro para MTC y REG
	  **/

//	char cadenareg4000[ CADENAREG4000 + 1 ];
	char cadenareg4000[669];
	char cadenamtc4000[ CADENAREG4000 + 1 ];

	time_t lcl_time;
	struct tm *today;
	int cont1, cont2, dec, indPlasticos, indSobregiros, indCiclo, indCre, indDeb;

	char           ge_user[ 10 ];
	char           ge_password[ 10 ];
	char           ge_server[ 10 ];
	char           ge_hostname[ 10 ];
	char           ge_dbase[ 10 ]; 

	char ejePrefijo[ 4 + 1 ];
	char gpoBanco[ 2 + 1 ];
	char empNumero[ 5 + 1 ];
	char directorio_archivo[ 50 ];
	char nombrearchivo_temp[ 100 ];

	extern char fechayhora[ 20 ];
	extern char nombrearchivo[ 60 ];
	extern char sqlcmd[ 3000 ];

	/**
	  *	Variables para contencion de Datos de las Consultas
	  **/

	DBCHAR        issuerIca[ 11 + 1 ];
	DBCHAR        issuerNumberIca[ 11 + 1 ];
	DBCHAR        originalCurrencyCode[ 3 + 1 ];

	DBCHAR        Empr_eje_prefijo[ 4 + 1 ];
	DBCHAR        Empr_gpo_bco[ 2 + 1 ];
	DBCHAR        Empr_gpo_num[ 5 + 1 ];
	DBCHAR        Empr_emp_num[ 5 + 1 ];
	DBCHAR        Empr_emp_nom1[ 45 + 1 ];
	DBCHAR        Empr_emp_nom2[ 45 + 1 ];
	DBCHAR        Empr_emp_fiscal_calle[ 35 + 1 ];
	DBCHAR        Empr_emp_fiscal_col[ 35 + 1 ];
	DBCHAR        Empr_emp_fiscal_cp[ 10 + 1 ];
	DBCHAR        Empr_emp_fiscal_ciudad[ 20 + 1 ];
	DBCHAR        Empr_emp_fiscal_poblacion[ 20 + 1 ];
	DBCHAR        Empr_emp_fiscal_edo[ 3 + 1 ];
	DBCHAR        Empr_emp_nom_r1 [ 35 + 1 ];
	DBCHAR        Empr_emp_tel_r1 [ 25 + 1 ];
	DBCHAR        Empr_emp_fax_r1 [ 25 + 1 ];
	DBCHAR        Empr_emp_email [ 50 + 1 ];
	DBCHAR        Empr_cred_total [ 16 + 1 ];
	DBCHAR        Empr_paymentDue [ 16 + 1 ];
	DBCHAR        Empr_pastDue [ 16 + 1 ];
	DBCHAR        Empr_balance [ 16 + 1 ];
	DBCHAR        Empr_num_Account_Past [ 16 + 1 ];
	DBCHAR        Corporativo [ 16 + 1 ];

	DBCHAR        Plas_eje_prefijo[ 4 + 1 ];
	DBCHAR        Plas_gpo_bco[ 2 + 1 ];
	DBCHAR        Plas_emp_num[ 5 +1 ];
	DBCHAR        Plas_cta_plas [ 7 + 1 ];

	DBCHAR        Sobr_eje_prefijo[4+1];
	DBCHAR        Sobr_gpo_bco[2+1];
	DBCHAR        Sobr_emp_num[5+1];
	DBCHAR        Sobr_sobregir [7+1];

	DBCHAR        Cred_corporationNumber[16+1];
	DBCHAR        Cred_num [10+1];
	DBCHAR        Cred_monto [16+1];

	DBCHAR        Debi_corporationNumber[16+1];
	DBCHAR        Debi_num [10+1];
	DBCHAR        Debi_monto [16+1];

	DBCHAR        Ciclo_eje_prefijo[4+1];
	DBCHAR        Ciclo_gpo_bco[2+1];
	DBCHAR        Ciclo_num [2+1];

	DBCHAR        Emp[16+1];
	DBCHAR        Ciclo[2+1];
	DBCHAR        Pla[11+1];
	DBCHAR        Sob[11+1];
	DBCHAR        Deb[16+1];
	DBCHAR        Cor[16+1];
	DBCHAR        Cor2[11+1];

	DBCHAR        MTC_corporationNumber [16+1];
	DBCHAR        MTC_cadena1 [205+1];
	DBCHAR        MTC_cadena2 [190+1];
	DBCHAR        MTC_cadena3 [191+1];

	int           corporativos;
	int           corporativos2;
	int           empresas;
	int           plasticos;
	int           sobregiros;
	int           creditos;
	int           debitos;
	int           ciclo;
	int           ilMTC4000;


	char        Debi[11+1];
	char        Cred[11+1];

	char fechaProceso[8+1];

	int act;
	int banderainserto; 
	char bulkcopy[100]; 

	fflush(stdout);

	/**
	  *		Validación de Parámetros
	  **/


	if ((argc > TOTALPARAMETROS) || (argc < TOTALPARAMETROS)){

		printf("Programa: r4000.c \n");
		printf("El numero de argumentos no son validos para el programa r4000.c\n");
		exit(1);
	}


	/**
	  *		Obtenemos Hora y Fecha de Inicio.
	  **/

	time( &lcl_time );
	today = localtime( &lcl_time );
	strftime( fechayhora, 20, "%Y%m%d %T", today );
	strncpy( fechaProceso, fechayhora, 8 );

	/**
	  *		Variables globales para el manejo de los argumentos nombre del archivo CDF a generar
	  **/
	strcpy( nombrearchivo, argv[ 1 ] );
	strcpy( ejePrefijo, argv[ 2 ] );
	strcpy( gpoBanco, argv[ 3 ] );
	strcpy( empNumero, argv[ 4 ] );

	/**
	  *		Comprobando inicio de DBLibraries
	  **/

	if( dbinit( ) == FAIL ){

		/**
		  *		Registro del error en el archivo LOG
		  **/

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: 4000.c \n");
		printf("Error: No se inicializaron las dblibrary de C en el programa r4000.c\n");
		exit( 1 );
	}

	/**
	  *		Instala las rutinas de manejo de errores 
	  **/

	dberrhandle((EHANDLEFUNC)err_handler);
	dbmsghandle((MHANDLEFUNC)msg_handler);

	/**
	  *		Obtencion de valores de entorno 
	  **/

	sprintf( ge_user,"%s", getenv( "GE_USER" ));
	sprintf( ge_password,"%s", getenv( "GE_PASSWORD" ));
	sprintf( ge_server,"%s", getenv( "GE_SERVER" ));
	sprintf( ge_hostname,"%s", getenv( "GE_HOSTNAME" ));
	sprintf( ge_dbase,"%s", getenv( "GE_DBASE" ));

	sprintf( directorio_archivo, "%s", getenv( "DIR_TEMP" ));


	/**
	  *		Comprobando Datos de Conexi'on
	  **/

	if( ( (strlen( ge_user ) == 0 ) || ( strlen( ge_password ) == 0 ) ||
		( strlen( ge_server ) == 0 ) || ( strlen( ge_hostname ) == 0 ) ||
		( strlen( ge_dbase ) == 0 ) || ( strlen( directorio_archivo ) == 0 ) ) ){

		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: 4000.c \n");
		printf("Error: debe verificar las variables de ambiente\n");
		exit( 1 );
	}

	/**
	  *		Rstableciendo Datos de Conexi'on
	  **/

	login = dblogin( );
	DBSETLUSER( login, ge_user );
	DBSETLPWD( login, ge_password );
	DBSETLAPP( login, ge_hostname );
	DBSETLHOST( login, ge_hostname );
        DBSETLCHARSET(login,"roman8");
	BCP_SETL( login, TRUE );

	/**
	  *		Abrimos la base de datos.
	  **/

	q_dbproc = dbopen( login, ge_server );
	q_dbprocCorp = dbopen( login, ge_server );
	q_dbprocCorp2 = dbopen( login, ge_server );
	q_dbprocEmpresa = dbopen( login, ge_server );
	q_dbprocCtaPlas = dbopen( login, ge_server );
	q_dbprocSobregi = dbopen( login, ge_server );
	q_dbprocCredito = dbopen( login, ge_server );
	q_dbprocDebitos = dbopen( login, ge_server );
	q_dbprocMTC4000 = dbopen( login, ge_server );
	q_dbprocCiclo = dbopen( login, ge_server );

	/**
	  *		Nos ubicamos en la base de datos 
	  **/ 
	
	dbuse( q_dbproc, ge_dbase );
	dbuse( q_dbprocCorp, ge_dbase );
	dbuse( q_dbprocCorp2, ge_dbase );
	dbuse( q_dbprocEmpresa, ge_dbase );
	dbuse( q_dbprocCtaPlas, ge_dbase );
	dbuse( q_dbprocSobregi, ge_dbase );
	dbuse( q_dbprocCredito, ge_dbase );
	dbuse( q_dbprocDebitos, ge_dbase );
	dbuse( q_dbprocCiclo, ge_dbase );
	dbuse( q_dbprocMTC4000, ge_dbase );


	/**
	  *		Impresion a Pantalla de la hora de Inicio del Proceso
	  **/
	sprintf( nombrearchivo_temp, "%s/reg4000.txt", directorio_archivo );

	printf("Hora de inicio del proceso para generar el registro 4000 \n");
	system("date \"+%I:%M:%S %p\"\n");

	/**
	  *	Preparo el archivo que se utilizara para realizar bulkcopy
	  **/

	reg4000 = fopen( nombrearchivo_temp, "w" );

	/**
	  *		La pertura del Archivo Fall'o.
	  **/
	if ( reg4000 == NULL ){

		/**
		  *		Registro del error en el archivo log
		  **/

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n",nombrearchivo);
		printf("Programa: r4000.c \n");
		printf("Error: No abrio el archivo de trabajo %ld\n", nombrearchivo_temp );
		exit( 1 );
	}

	/**
	  *		Inicializamos variables 
	  **/

	memset( issuerica, '\0', sizeof(issuerica));
	memset( issuernumberica, '\0', sizeof(issuernumberica));
	memset( currencycode, '\0', sizeof(currencycode));

	/**
	  *		Consulta 1. Se borra la tabla REG4000 si existe
	  **/

	sprintf( sqlcmd, "if object_id('dbo.REG4000') is not null");
	strcat( sqlcmd, " begin ");
	strcat( sqlcmd, " drop table dbo.REG4000 ");
	strcat( sqlcmd, " end ");
	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa primer Consulta: \n\n%s\n\n", sqlcmd );*/

	if( dbsqlexec( q_dbproc ) == FAIL){

		/**
		  *		Se ejecuta Consulta y entra aqui en caso de falla al borrar la tabla
		  *		REG4000.
		  **/

		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4000.c \n");
		printf("Error: Fallo al intentar borrar la tabla REG4000\n");
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	dbcancel( q_dbproc );

	/**
	  *		Consulta 2. Creaci'on de la tabla REG4000 
	  **/

	sprintf( sqlcmd, "select *, indJer = chargeOffSign" );
	strcat( sqlcmd, " into REG4000 " );
	strcat( sqlcmd, "from MTC4000 where 1=2 " );
	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa segunda Consulta: \n\n%s\n\n", sqlcmd );*/

	if ( dbsqlexec(q_dbproc) == FAIL){

		/**
		  *		Se ejecuta la cosnulta para crear la tabla REG4000, si falla la creaci'on entra a este punto
		  **/

		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4000.c \n" );
		printf( "Fallo al intentar crear la tabla REG4000 dbsqlexec:%s \n", sqlcmd );
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	dbcancel(q_dbproc);

	/**
	  *		Consulta 3. Extraemos informaci'on de la tabla MTCICA01.
	  **/

	sprintf( sqlcmd, "select icaNumero, icaNumBanco, currency " );
	strcat( sqlcmd, "from MTCICA01" );
	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa Tercer Consulta: \n\n%s\n\n", sqlcmd );*/

	if(dbsqlexec(q_dbproc) == FAIL){

		/**
		  *		Ejecutamos consulta 3 y entra a este punto si falla la consulta.
		  **/

		printf( "Fecha proceso:%s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4000.c \n" );
		printf( "Error: Fallo al intentar traer datos de MTCICA01 bdsqlexec \n" );
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Recorremos Puntero de Resultados
	  **/

	dbresults( q_dbproc );
	
	if( DBROWS( q_dbproc ) != SUCCEED ){

		/**
		  *		Entra a este punto en caso de que la consulta 3 no contenga datos
		  **/

		printf("Fecha proceso:%s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4000.c \n");
		printf("Fallo al intentar traer datos de MTCICA01 DBROWS\n");
		dbclose(q_dbproc);
		dbexit();
		exit(ERREXIT);
	}

	/**
	  *		Ligamos los resultados a variables locales
	  **/

	dbbind( q_dbproc, 1, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * )issuerIca );
	dbbind( q_dbproc, 2, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * )issuerNumberIca );
	dbbind( q_dbproc, 3, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * )originalCurrencyCode );
	dbnextrow( q_dbproc );

	/**
	  *		Consulta 4. Cuentas y plasticos
	  **/

	sprintf( sqlcmd, " select prefijo = right( '0000' + convert( char( 4 ),\n" );
	strcat( sqlcmd, " A.eje_prefijo ), 4 ), \n" ); 
	strcat( sqlcmd, " banco = right( '00' + convert( char( 2 ), A.gpo_banco ), 2 ), \n" );
	strcat( sqlcmd, " empresa = replicate ( '0', ( select pgs_long_emp \n" );
	strcat( sqlcmd, " from MTCPGS01 i where i.pgs_rep_prefijo = A.eje_prefijo \n" );
	strcat( sqlcmd, " and i.pgs_rep_banco = A.gpo_banco ) - char_length( ltrim( rtrim( \n" );
	strcat( sqlcmd, " str( A.emp_num ) ) ) ) ) + ltrim( rtrim( str( A.emp_num ) ) ), \n" ); 
	strcat( sqlcmd, " contado_cuentas = right( '0000000' + convert( char( 7 ),\n" );
	strcat( sqlcmd, " count( A.emp_num ) ), 7 ) \n" ); 
	strcat( sqlcmd, " from MTCTHS01 A, MTCEMP01 B \n" ); 
	strcat( sqlcmd, " Where A.ths_situacion_cta in ('C', 'D', 'E', 'O', 'P', ' ') \n" );

	if ( strcmp( ejePrefijo, "0" ) != 0 && strcmp( gpoBanco, "0" ) != 0 ){

		strcat( sqlcmd, "and A.eje_prefijo = \n" );
		sprintf( sqlcmd, "%s %s \n ", sqlcmd, ejePrefijo );
		strcat( sqlcmd, "and A.gpo_banco = \n" );
		sprintf( sqlcmd, "%s %s \n ", sqlcmd,gpoBanco );
	
		if ( strcmp( empNumero, "0" ) != 0 ){

			strcat( sqlcmd, "and A.emp_num = \n" );
			sprintf( sqlcmd, "%s %s ", sqlcmd, empNumero );
		}
	}
	
	strcat( sqlcmd, "and A.eje_prefijo = B.eje_prefijo \n" );
	strcat( sqlcmd, "and A.gpo_banco = B.gpo_banco \n" );
	strcat( sqlcmd, "and A.emp_num = B.emp_num \n" );
	strcat( sqlcmd, "and B.emp_gen_CDF=1 \n" );
	strcat( sqlcmd, "group by A.eje_prefijo, A.gpo_banco, A.emp_num \n" ); 
	strcat( sqlcmd, "order by A.eje_prefijo, A.gpo_banco, A.emp_num \n" ); 

	dbcmd( q_dbprocCtaPlas, sqlcmd );

/*	printf("\nLa cuarta Consulta: \n\n%s\n\n", sqlcmd );*/

	if ( dbsqlexec( q_dbprocCtaPlas ) == FAIL ){

		/**
		  *		Ejecutamos Consulta 4. En caso de fallo entra este punto.
		  **/

		printf("Fallo el proceso r4000. Query plasticos.\n");
		dbclose( q_dbprocCtaPlas );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Recorriendo Puntero de Resultados
	  **/
	dbresults( q_dbprocCtaPlas );

	if( DBROWS( q_dbprocCtaPlas) != SUCCEED ){

		/**
		  *		En caso de estar vacia la consulta se considera error.
		  **/

		printf("Fallo el proceso r4000. Query plasticos.\n");
		dbclose( q_dbprocCtaPlas );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Ligando resultados de la consulta 4 a variables locales.
	  **/

	dbbind( q_dbprocCtaPlas, 1, NTBSTRINGBIND, 0, (CS_BYTE *)Plas_eje_prefijo);
	dbbind( q_dbprocCtaPlas, 2, NTBSTRINGBIND, 0, (CS_BYTE *)Plas_gpo_bco);
	dbbind( q_dbprocCtaPlas, 3, NTBSTRINGBIND, 0, (CS_BYTE *)Plas_emp_num);
	dbbind( q_dbprocCtaPlas, 4, NTBSTRINGBIND, 0, (CS_BYTE *)Plas_cta_plas);

	/**
	  *		Recogiendo Datos del primer registro
	  **/
	plasticos = dbnextrow( q_dbprocCtaPlas );

	/**
	  *		Consulta 5. Sobregiros
	  **/

	sprintf( sqlcmd, "select prefijo = right( '0000' + convert( char( 4 ), A.eje_prefijo ), 4 ),\n" );
	strcat( sqlcmd, "banco = right( '00' + convert( char( 2 ), A.gpo_banco ), 2 ), \n" );
	strcat( sqlcmd, "empresa = replicate( '0', ( select pgs_long_emp from MTCPGS01 i\n" );
	strcat( sqlcmd, " where i.pgs_rep_prefijo = A.eje_prefijo \n" );
	strcat( sqlcmd, "and i.pgs_rep_banco = A.gpo_banco ) - char_length( ltrim( \n" );
	strcat( sqlcmd, "rtrim( str( A.emp_num ) ) ) ) ) + ltrim( rtrim( str( A.emp_num ) ) ), \n" );
	strcat( sqlcmd, "contador_sob = right( '0000000' + convert( char( 7 ), count( \n" );
	strcat( sqlcmd, "A.emp_num ) ), 7 ) \n" );
	strcat( sqlcmd, "from MTCTHS01 A, MTCEMP01 B \n" );
	strcat( sqlcmd, "where A.ths_situacion_cta = 'O' \n" );
	
	if ( strcmp( ejePrefijo, "0" ) != 0 && strcmp( gpoBanco, "0" ) != 0 ){
		strcat( sqlcmd, "and A.eje_prefijo = \n" );
		sprintf( sqlcmd, "%s %s \n", sqlcmd, ejePrefijo );
		strcat( sqlcmd, "and A.gpo_banco = \n" );
		sprintf( sqlcmd, "%s %s \n", sqlcmd, gpoBanco );
	
		if ( strcmp( empNumero, "0") != 0 ){
			strcat( sqlcmd, "and A.emp_num=\n" );
			sprintf( sqlcmd," %s %s \n ", sqlcmd, empNumero );
		}
	}
	
	strcat( sqlcmd, "and  A.eje_prefijo=B.eje_prefijo \n" );
	strcat( sqlcmd, "and A.gpo_banco=B.gpo_banco \n" );
	strcat( sqlcmd, "and A.emp_num=B.emp_num \n" );
	strcat( sqlcmd, "and B.emp_gen_CDF=1 \n" );
	strcat( sqlcmd, "group by A.eje_prefijo, A.gpo_banco, A.emp_num \n" );
	strcat( sqlcmd, "order by A.eje_prefijo, A.gpo_banco, A.emp_num \n" );

	dbcmd( q_dbprocSobregi, sqlcmd );

/*	printf("\nLa quinta Consulta: \n\n%s\n\n", sqlcmd );*/

	if ( dbsqlexec( q_dbprocSobregi ) == FAIL ){

		/**
		  *		Se ejecuta la Consulta 5. Entra en este punto en caso de fallo.
		  **/

		printf("Fallo el proceso r4000. Query sobregiros.\n");
		dbclose( q_dbprocSobregi );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Recorremos puntero de Resultados.
	  **/

	dbresults(q_dbprocSobregi);

	/**
	  *		Ligamos los resultados de la consulta 5 a variables locales.
	  **/

	dbbind( q_dbprocSobregi, 1, NTBSTRINGBIND, 0,(CS_BYTE *) Sobr_eje_prefijo );
	dbbind( q_dbprocSobregi, 2, NTBSTRINGBIND, 0,(CS_BYTE *) Sobr_gpo_bco );
	dbbind( q_dbprocSobregi, 3, NTBSTRINGBIND, 0,(CS_BYTE *) Sobr_emp_num );
	dbbind( q_dbprocSobregi, 4, NTBSTRINGBIND, 0,(CS_BYTE *) Sobr_sobregir );
	sobregiros = dbnextrow( q_dbprocSobregi );

	/**
	  *		Consulta 6. Creditos.
	  **/

	sprintf( sqlcmd, "select rtrim( A.corporationNumber ), \n");
	strcat( sqlcmd, "right( '0000000000000000' + ltrim( str( sum( convert( \n");
	strcat( sqlcmd, "numeric( 16, 4 ), A.transactionAmount ) ), 16) ), 16 ) credit_amount, \n");
	strcat( sqlcmd, "right( '0000000000' + convert( char( 10 ),\n");
	strcat( sqlcmd, "count( A.accountNumber ) ), 10 ) credi_num \n"); 
	strcat( sqlcmd, "from REG5000 A \n");
	strcat( sqlcmd, "where A.debitCreditIndicator = 'C' \n"); 
	
	if ( strcmp( ejePrefijo, "0" ) != 0 && strcmp( gpoBanco, "0" ) != 0 ){
		strcat( sqlcmd, "and convert( int, substring( corporationNumber, 1, 4 ) ) = \n");
		sprintf( sqlcmd, "%s %s \n",sqlcmd,ejePrefijo);  
		strcat( sqlcmd, "and convert( int,substring( corporationNumber, 5, 2 ) ) = \n");
		sprintf( sqlcmd, "%s %s \n",sqlcmd,gpoBanco);

		if ( strcmp( empNumero, "0" ) != 0 ){
	
			strcat( sqlcmd, " and convert(int,substring(corporationNumber,7,(\n" );
			strcat( sqlcmd, "select pgs_long_emp from MTCPGS01 i \n" );
			strcat( sqlcmd, "where i.pgs_rep_prefijo =\n" );
			sprintf( sqlcmd, "%s %s \n ",sqlcmd,ejePrefijo);
			strcat( sqlcmd, "and i.pgs_rep_banco =\n" );
			sprintf( sqlcmd, "%s %s \n ", sqlcmd, gpoBanco );
			strcat( sqlcmd, "))) = \n" );
			sprintf( sqlcmd, "%s %s \n ", sqlcmd, empNumero );
		}
	}

	strcat( sqlcmd, "group by A.corporationNumber \n" );
	strcat( sqlcmd, "order by A.corporationNumber \n" ); 

	dbcmd( q_dbprocCredito, sqlcmd );

/*	printf("\nLa sexta Consulta: \n\n%s\n\n", sqlcmd );*/
	
	if ( dbsqlexec( q_dbprocCredito ) == FAIL ){

		/**
		  *		Se ejecuta la consulta 6. Entra en este punto en caso de fallo.
		  **/

		printf("Fallo el proceso r4000. Query creditos. %s \n", sqlcmd );
		dbclose( q_dbprocCredito );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Recorremos Puntero de Resultados
	  **/

	dbresults( q_dbprocCredito );
	
	if ( DBROWS( q_dbprocCredito ) != SUCCEED ){

		/**
		  *		Fallo en caso de que los resultados sean vacios.
		  **/

		if ( DBROWS( q_dbprocCredito ) != 0 ){
			
			printf( "Fallo el proceso r4000. Query creditos.\n" );
			dbclose( q_dbprocCredito );
			dbexit( );
			exit( ERREXIT );
		}
	}
	
	/**
	  *		Se Ligan los resultados de la consulta 6 a variables locales.
	  **/

	dbbind( q_dbprocCredito, 1, NTBSTRINGBIND, 0, (CS_BYTE *) Cred_corporationNumber );
	dbbind( q_dbprocCredito, 2, NTBSTRINGBIND, 0, (CS_BYTE *) Cred_monto );
	dbbind( q_dbprocCredito, 3, NTBSTRINGBIND, 0, (CS_BYTE *) Cred_num );
	creditos = dbnextrow( q_dbprocCredito );

	/**
	  *		Consulta 7. Debitos.
	  **/

	sprintf( sqlcmd, "select rtrim( A.corporationNumber ) \n" );
	strcat( sqlcmd, ", right( '0000000000000000' + ltrim( str( sum( convert( \n" );
	strcat( sqlcmd, " numeric( 16, 4 ), A.transactionAmount ) ), 16 ) ), 16 ) debit_amount \n" );
	strcat( sqlcmd, ", right( '0000000000' + convert( char( 10 ), count( \n" );
	strcat( sqlcmd, " A.accountNumber ) ), 10 ) debit_num \n" );
	strcat( sqlcmd, " from REG5000 A \n" );
	strcat( sqlcmd, " where A.debitCreditIndicator = 'D' \n" );
	
	if ( strcmp( ejePrefijo, "0" ) != 0 && strcmp( gpoBanco, "0" ) != 0 ){

		strcat( sqlcmd, " and convert( int, substring( corporationNumber, 1, 4 ) ) = \n");
		sprintf( sqlcmd, "%s %s \n",sqlcmd,ejePrefijo );
		strcat( sqlcmd, " and convert( int, substring( corporationNumber, 5, 2) ) = \n");
		sprintf( sqlcmd, "%s %s \n", sqlcmd, gpoBanco );

		if ( strcmp(empNumero,"0") != 0 ){

			strcat( sqlcmd, "and convert( int, substring( corporationNumber, 7,( \n");
			strcat( sqlcmd, "select pgs_long_emp from MTCPGS01 i \n");
			strcat( sqlcmd, "where i.pgs_rep_prefijo = \n");
			sprintf( sqlcmd, "%s %s \n ", sqlcmd, ejePrefijo );
			strcat( sqlcmd, "and i.pgs_rep_banco = \n" );
			sprintf( sqlcmd, "%s %s \n ", sqlcmd, gpoBanco );
			strcat( sqlcmd, "))) = \n" );
			sprintf( sqlcmd, "%s %s \n ", sqlcmd, empNumero );
		}
	}

	strcat( sqlcmd, " group by A.corporationNumber \n");
	strcat( sqlcmd, " order by A.corporationNumber \n");

	dbcmd( q_dbprocDebitos, sqlcmd );

/*	printf("\nLa septima Consulta: \n\n%s\n\n", sqlcmd );*/
	
	if( dbsqlexec( q_dbprocDebitos ) == FAIL ){

		/**
		  *		Ejecuci'on de la consulta 7. Entra a este punto en caso de fallo.
		  **/

		printf( "Fallo el proceso r4000. Query debitos. %s \n", sqlcmd );
		dbclose( q_dbprocDebitos );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Recorremos el puntero de resultados
	  **/

	dbresults( q_dbprocDebitos );

	/**
	  *		Ligamos los resultados a variables locales
	  **/

	dbbind( q_dbprocDebitos, 1, NTBSTRINGBIND, 0, (CS_BYTE *) Debi_corporationNumber );
	dbbind( q_dbprocDebitos, 2, NTBSTRINGBIND, 0, (CS_BYTE *) Debi_monto );
	dbbind( q_dbprocDebitos, 3, NTBSTRINGBIND, 0, (CS_BYTE *) Debi_num );
	debitos = dbnextrow( q_dbprocDebitos );


	/**
	  *		Consulta 8. Ciclo
	  **/

	sprintf( sqlcmd, " select pgs_rep_prefijo, pgs_rep_banco, right( '00' + convert( char( 2 ), pgs_dia_corte ), 2 ) \n");
	strcat( sqlcmd, " from MTCPGS01 A \n");
	
	if ( strcmp( ejePrefijo, "0" ) != 0 && strcmp( gpoBanco, "0" ) != 0 ) {
		strcat( sqlcmd, " where A.pgs_rep_prefijo = \n" );
		sprintf( sqlcmd, "%s %s \n ", sqlcmd, ejePrefijo );
		strcat( sqlcmd, " and A.pgs_rep_banco = \n" );
		sprintf( sqlcmd, "%s %s \n ", sqlcmd, gpoBanco );
	}

	strcat( sqlcmd, "order by A.pgs_rep_prefijo, A.pgs_rep_banco \n" );

	dbcmd( q_dbprocCiclo, sqlcmd );

/*	printf("\nLa primer octava: \n\n%s\n\n", sqlcmd );*/
	
	if ( dbsqlexec( q_dbprocCiclo ) == FAIL ){

		/**
		  *		Ejecuci'on de la consulta 9. Entra a este punto en caso de fallo.
		  **/

		printf( "Fallo el proceso r4000. Query Ciclo.\n" );
		dbclose( q_dbprocCiclo );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Recorremos puntero de Resultados
	  **/

	dbresults( q_dbprocCiclo );
	
	if ( DBROWS( q_dbprocCiclo ) != SUCCEED ){

		/**
		  *		Fallo en caso de estar vacio el resultado
		  **/

		if ( DBROWS( q_dbprocCiclo ) != 0 ){
			printf("Fallo el proceso r4000. Query Ciclo.\n");
			dbclose( q_dbprocCiclo );
			dbexit( );
			exit( ERREXIT );
		}
	}

	/**
	  *		Ligando resultados a variables locales
	  **/

	dbbind( q_dbprocCiclo, 1, NTBSTRINGBIND, 0, (CS_BYTE *)Ciclo_eje_prefijo );
	dbbind( q_dbprocCiclo, 2, NTBSTRINGBIND, 0, (CS_BYTE *)Ciclo_gpo_bco );
	dbbind( q_dbprocCiclo, 3, NTBSTRINGBIND, 0, (CS_BYTE *)Ciclo_num );
	ciclo = dbnextrow( q_dbprocCiclo );

	/**
	  *		Inicializo las variables que son de valor constante
	  **/

        memset( reservedforinternaluse1, '\0' , sizeof(reservedforinternaluse1));
        memset( reservedforinternaluse2, '\0' , sizeof(reservedforinternaluse2));
        memset( reservedforinternaluse3, '\0' , sizeof(reservedforinternaluse3));
        memset( country, '\0' , sizeof(country));
        memset( currencycode, '\0' , sizeof(currencycode));
        memset( accountswithdispute, '\0' , sizeof(accountswithdispute));
        memset( chargeoffsign, '\0' , sizeof(chargeoffsign));
        memset( chargeoffamount, '\0' , sizeof(chargeoffamount));
        memset( pastdueamountsign, '\0' , sizeof(pastdueamountsign));
        memset( disputeamountsign, '\0' , sizeof(disputeamountsign));
        memset( disputeamount, '\0' , sizeof(disputeamount));
        memset( creditlimitsign, '\0' , sizeof(creditlimitsign));
        memset( portfoliodate, '\0' , sizeof(portfoliodate));
        memset( inputfilerecordnumber, '\0' , sizeof(inputfilerecordnumber));
        memset( outgoingincomingerrorcode, '\0' , sizeof(outgoingincomingerrorcode));

	/**
	  *		Asignando Variables constantes.
	  **/

	sprintf( recordidentifier, FRMA4, "4000" );
/*	sprintf( issuerica, FRMN11, issuerIca );i*/
        sprintf( issuerica, "%011ld", atol(issuerIca) );
	sprintf( issuernumberica, FRMA11, issuerNumberIca );
	sprintf( reservedforinternaluse1, FRMA3, EMPTYSTR );
	sprintf( reservedforinternaluse2, FRMA17, EMPTYSTR );
	sprintf( reservedforinternaluse3, FRMA6, EMPTYSTR );
	sprintf( country, FRMA3, "MEX" );
	sprintf( currencycode, FRMN3, originalCurrencyCode );
/*	sprintf( accountswithdispute, FRMN7, EMPTYSTR );*/
        sprintf( accountswithdispute, "%07ld", atol(EMPTYSTR) );
	sprintf( chargeoffsign, FRMA1, "D" ); 
/*	sprintf( chargeoffamount, FRMN16, EMPTYSTR ); */
        sprintf( chargeoffamount, "%016ld", atol(EMPTYSTR) );
	sprintf( pastdueamountsign, FRMA1, "D" ); 
	sprintf( disputeamountsign, FRMA1, "D" ); 
/*	sprintf( disputeamount, FRMN16, EMPTYSTR ); */
        sprintf( disputeamount, "%016ld", atol(EMPTYSTR) );
	sprintf( creditlimitsign, FRMA1, "D" ); 
	sprintf( portfoliodate, FRMA8, fechaProceso );
/*	sprintf( inputfilerecordnumber, FRMN6, EMPTYSTR );*/
        sprintf( inputfilerecordnumber, "%06ld", atol(EMPTYSTR) );
	sprintf( outgoingincomingerrorcode, FRMA6, EMPTYSTR );

	/* ********************************** */ 

	banderainserto = 0;
	act = 0;

	/**
	  *		Consulta 8. Empresas
	  **/

	sprintf( sqlcmd, " select prefijo=right('0000'+convert(char(4),A.eje_prefijo),4), \n");
	strcat( sqlcmd, " banco=right('00'+convert(char(2),A.gpo_banco),2), \n");  
	strcat( sqlcmd, "empresa=replicate ('0', (select pgs_long_emp from MTCPGS01 i \n"); 
	strcat( sqlcmd, "where i.pgs_rep_prefijo = A.eje_prefijo \n"); 
	strcat( sqlcmd, "and i.pgs_rep_banco = A.gpo_banco) - char_length(ltrim(\n"); 
	strcat( sqlcmd, "rtrim(str(A.emp_num)))))+ltrim(rtrim(str(A.emp_num))),\n");
	strcat( sqlcmd, "empNom1=substring(convert(char(45), min(A.emp_nom)), 1, 35),\n"); 
	strcat( sqlcmd, "empNom2=substring(convert(char(45), min(A.emp_nom)), 36, 45), \n");
	strcat( sqlcmd, "empDom1=convert(char(35),min(A.emp_fiscal_calle)), \n");
	strcat( sqlcmd, "empDom2=convert(char(35),min(A.emp_fiscal_col)), \n");
	strcat( sqlcmd, "empPob=convert(char(20), min(A.emp_fiscal_pob)), \n"); 
	strcat( sqlcmd, "empEdo=convert(char(3),  min(A.emp_fiscal_edo)), \n");
	strcat( sqlcmd, "empCP=convert(char(10), min(A.emp_fiscal_cp)), \n");
	strcat( sqlcmd, "empNomRep=convert(char(35), min(A.emp_nom_r1)), \n");
	strcat( sqlcmd, "empTel=convert(char(25), min(A.emp_tel_r1)), \n");
	strcat( sqlcmd, "empFax=convert(char(25), min(A.emp_fax_r1)), \n");
	strcat( sqlcmd, "empEmail=convert(char(50), min(A.emp_email)), \n");
	strcat( sqlcmd, "empCredito=ltrim(str(min(A.emp_cred_tot),16,0)), \n");
	strcat( sqlcmd, "right('0000000'+ltrim(str(sum(convert(\n");
	strcat( sqlcmd, "float,R4300.numberPaymentsPastDue)))), 7) retrazos,\n"); 
	strcat( sqlcmd, "right('0000000000000000'+ltrim(str(sum(\n");
	strcat( sqlcmd, "convert(numeric(16,2), R4300.pastDueBalance)),16,0)),16) montoRetrazos, \n");
	strcat( sqlcmd, "right('0000000000000000' + ltrim(str(sum(convert(\n");
	strcat( sqlcmd, "numeric(16,2),R4300.paymentDueBalance)),16,0)),16) pagosDeudore,\n");
	strcat( sqlcmd, "right('0000000000000000' + ltrim(str(sum(convert(\n");
	strcat( sqlcmd, "numeric(16,2), R4300.endingBalance)),16,0)),16) balance, \n");
	strcat( sqlcmd, "convert(char(16), convert(char(4), A.eje_prefijo)+\n"); 
	strcat( sqlcmd, "convert(char(2), A.gpo_banco)+replicate('0',(select pgs_long_emp \n"); 
	strcat( sqlcmd, "from MTCPGS01 i where i.pgs_rep_prefijo=A.eje_prefijo \n"); 
	strcat( sqlcmd, "and i.pgs_rep_banco = A.gpo_banco)- char_length(ltrim(rtrim(\n"); 
	strcat( sqlcmd, "str(A.emp_num)))))+ltrim(rtrim(str(A.emp_num)))+\n"); 
	strcat( sqlcmd, "replicate ('0',(select pgs_long_eje from MTCPGS01 h \n"); 
	strcat( sqlcmd, "where h.pgs_rep_prefijo = A.eje_prefijo \n"); 
	strcat( sqlcmd, "and h.pgs_rep_banco = A.gpo_banco))+'9'+\n"); 
	strcat( sqlcmd, "convert(char(1),(select p.eje_digit \n"); 
	strcat( sqlcmd, "from MTCPLA01 p where p.eje_roll_over=9 \n"); 
	strcat( sqlcmd, "and p.eje_prefijo = A.eje_prefijo \n"); 
	strcat( sqlcmd, "and p.gpo_banco = A.gpo_banco \n"); 
	strcat( sqlcmd, "and p.emp_num = A.emp_num  and p.eje_num = 0))) CtaCorp \n"); 
	strcat( sqlcmd, "from MTCEMP01 A, REG4300 R4300 \n");
	strcat( sqlcmd, "where A.eje_prefijo=convert(int,substring(\n");
	strcat( sqlcmd, "R4300.corporationNumber,1,4)) \n");
	strcat( sqlcmd, "and A.gpo_banco=convert(int,substring( \n");
	strcat( sqlcmd, "R4300.corporationNumber,5,2)) \n");
	strcat( sqlcmd, "and A.emp_num=convert(int,substring(\n");
	strcat( sqlcmd, "R4300.corporationNumber,7,(select pgs_long_emp \n"); 
	strcat( sqlcmd, "from MTCPGS01 i where i.pgs_rep_prefijo = A.eje_prefijo \n");
	strcat( sqlcmd, "and i.pgs_rep_banco = A.gpo_banco))) \n");
	strcat( sqlcmd, "and A.emp_gen_CDF=1 \n");
	
	if ( strcmp(ejePrefijo,"0") != 0 && strcmp(gpoBanco,"0") != 0 ) {

		strcat( sqlcmd, "and A.eje_prefijo=\n" );
		sprintf( sqlcmd, "%s %s \n ", sqlcmd, ejePrefijo );
		strcat( sqlcmd, "and A.gpo_banco = \n");
		sprintf( sqlcmd, "%s %s \n ", sqlcmd, gpoBanco);
		
		if ( strcmp( empNumero,"0") != 0 ){
			strcat( sqlcmd,"and A.emp_num=\n");
			sprintf( sqlcmd,"%s %s \n", sqlcmd, empNumero);
		}
	}
	
	strcat( sqlcmd, "group by A.eje_prefijo, A.gpo_banco,  A.emp_num \n" );
	strcat( sqlcmd, "order by A.eje_prefijo, A.gpo_banco, A.emp_num \n" );

	dbcmd( q_dbprocEmpresa, sqlcmd );

/*	printf("\nLa novena Consulta: \n\n%s\n\n", sqlcmd );*/
	
	if( dbsqlexec( q_dbprocEmpresa ) == FAIL ){

		/**
		  *		Ejecucion de la consulta 8. En caso de fallo entra a este punto
		  **/

		printf( "Fallo el proceso r4000. Query empresa. %s \n", sqlcmd );
		dbclose( q_dbprocEmpresa );
		dbexit( );
		exit( ERREXIT );
	}

	dbresults( q_dbprocEmpresa );
	
	/*************************************************************************************/

	/**
	  *		Ligando resultados de la consulta 8 a variables locales.
	  **/

	dbbind( q_dbprocEmpresa, 1, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_eje_prefijo );
	dbbind( q_dbprocEmpresa, 2, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_gpo_bco );
	dbbind( q_dbprocEmpresa, 3, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_num );
	dbbind( q_dbprocEmpresa, 4, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_nom1 );
	dbbind( q_dbprocEmpresa, 5, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_nom2 );
	dbbind( q_dbprocEmpresa, 6, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_fiscal_calle );
	dbbind( q_dbprocEmpresa, 7, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_fiscal_col );
	dbbind( q_dbprocEmpresa, 8, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_fiscal_poblacion );
	dbbind( q_dbprocEmpresa, 9, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_fiscal_edo );
	dbbind( q_dbprocEmpresa, 10, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_fiscal_cp );
	dbbind( q_dbprocEmpresa, 11, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_nom_r1 );
	dbbind( q_dbprocEmpresa, 12, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_tel_r1 );
	dbbind( q_dbprocEmpresa, 13, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_fax_r1 );
	dbbind( q_dbprocEmpresa, 14, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_emp_email );
	dbbind( q_dbprocEmpresa, 15, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_cred_total );
	dbbind( q_dbprocEmpresa, 16, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_num_Account_Past );
	dbbind( q_dbprocEmpresa, 17, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_pastDue );
	dbbind( q_dbprocEmpresa, 18, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_paymentDue );
	dbbind( q_dbprocEmpresa, 19, NTBSTRINGBIND, 0, (CS_BYTE *)Empr_balance );
	dbbind( q_dbprocEmpresa, 20, NTBSTRINGBIND, 0, (CS_BYTE *)Corporativo );

	/**
	  *		Obtenci¡on del primer Registro
	  **/

	empresas = dbnextrow( q_dbprocEmpresa );

	/**
	  *		Ciclo de extracci'on de todas las empresas contenidas en la consulta 8
	  **/

	while ( empresas != NO_MORE_ROWS ){

		/**
		  *		Limpieza de Variables
		  **/

                memset( corporationnumber, '\0', sizeof(corporationnumber));
                memset( corporationnameline1, '\0', sizeof(corporationnameline1));
                memset( corporationnameline2, '\0', sizeof(corporationnameline2));
                memset( addressline1, '\0', sizeof(addressline1));
                memset( addressline2, '\0', sizeof(addressline2));
                memset( city, '\0', sizeof(city));
                memset( stateprovince, '\0', sizeof(stateprovince));
                memset( postalcode, '\0', sizeof(postalcode));
                memset( contactperson, '\0', sizeof(contactperson));
                memset( phonenumber, '\0', sizeof(phonenumber));
                memset( faxnumber, '\0', sizeof(faxnumber));
                memset( emailaddress, '\0', sizeof(emailaddress));
                memset( budgetlimit, '\0', sizeof(budgetlimit));
                memset( cycledateindicator, '\0', sizeof(cycledateindicator));
                memset( totalaccounts, '\0', sizeof(totalaccounts));
                memset( accountspastdue, '\0', sizeof(accountspastdue));
                memset( numberofcards, '\0', sizeof(numberofcards));
                memset( pastdueamount, '\0', sizeof(pastdueamount));
                memset( creditlimit, '\0', sizeof(creditlimit));
                memset( paymentduesign, '\0', sizeof(paymentduesign));
                memset( paymentdue, '\0', sizeof(paymentdue));
                memset( outstandingbalancesign, '\0', sizeof(outstandingbalancesign));
                memset( outstandingbalance, '\0', sizeof(outstandingbalance));
                memset( numberofdebits, '\0', sizeof(numberofdebits));
                memset( numberofcredits, '\0', sizeof(numberofcredits));
                memset( amountofdebits, '\0', sizeof(amountofdebits));
                memset( amountofcredits, '\0', sizeof(amountofcredits));
                memset( numberaccountsoverlimit, '\0', sizeof(numberaccountsoverlimit));
                memset( addressmaintenanceactioncode, '\0', sizeof(addressmaintenanceactioncode));

/*		sprintf( totalaccounts, FRMN7, EMPTYSTR );
		sprintf( numberofcards, FRMN7, EMPTYSTR );
		sprintf( numberofdebits, FRMN10, EMPTYSTR );
		sprintf( numberofcredits, FRMN10, EMPTYSTR );
		sprintf( amountofdebits, FRMN16, EMPTYSTR );
		sprintf( amountofcredits, FRMN16, EMPTYSTR );
		sprintf( numberaccountsoverlimit, FRMN7, EMPTYSTR );*/

                sprintf( totalaccounts, "%07ld", atol(EMPTYSTR) );
                sprintf( numberofcards, "%07ld", atol(EMPTYSTR) );
                sprintf( numberofdebits, "%010ld", atol(EMPTYSTR) );
                sprintf( numberofcredits, "%010ld", atol(EMPTYSTR) );
                sprintf( amountofdebits, "%016ld", atol(EMPTYSTR) );
                sprintf( amountofcredits, "%016ld", atol(EMPTYSTR) );
                sprintf( numberaccountsoverlimit, "%07ld", atol(EMPTYSTR) );

		/**
		  * Proceso para las empresas que no tienen corporativos 
		  **/ 

                memset( corporationnumber, '\0' , sizeof(corporationnumber));
                memset( corporationnameline1, '\0' , sizeof(corporationnameline1));
                memset( corporationnameline2, '\0' , sizeof(corporationnameline2));
                memset( addressline1, '\0' , sizeof(addressline1));
                memset( addressline2, '\0' , sizeof(addressline2));
                memset( city, '\0' , sizeof(city));
                memset( stateprovince, '\0' , sizeof(stateprovince));
                memset( postalcode, '\0' , sizeof(postalcode));
                memset( contactperson, '\0' , sizeof(contactperson));
                memset( phonenumber, '\0' , sizeof(phonenumber));
                memset( faxnumber, '\0' , sizeof(faxnumber));
                memset( emailaddress, '\0' , sizeof(emailaddress));
                memset( budgetlimit, '\0' , sizeof(budgetlimit));
                memset( cycledateindicator, '\0' , sizeof(cycledateindicator));

		sprintf( corporationnumber, "%s", Corporativo );
		sprintf( corporationnameline1, FRMA35, Empr_emp_nom1 );
		sprintf( corporationnameline2, FRMA35, Empr_emp_nom2 );
		sprintf( addressline1, FRMA35, Empr_emp_fiscal_calle );
		sprintf( addressline2, FRMA35, Empr_emp_fiscal_col );
		sprintf( city, FRMA20, Empr_emp_fiscal_poblacion );
		sprintf( stateprovince, FRMA3, Empr_emp_fiscal_edo );
		sprintf( postalcode, FRMA10, Empr_emp_fiscal_cp );
		sprintf( contactperson, FRMA35, Empr_emp_nom_r1 );
		sprintf( phonenumber, FRMA25, Empr_emp_tel_r1 );
		sprintf( faxnumber, FRMA25, Empr_emp_fax_r1 );
		sprintf( emailaddress, FRMA50, Empr_emp_email );
		//strcat( Empr_cred_total, "0000" );
/*		sprintf( budgetlimit, FRMN16, Empr_cred_total ); */
                sprintf( budgetlimit, "%016ld", atol(Empr_cred_total) );
		sprintf( accountspastdue, "%s", Empr_num_Account_Past );
/*		sprintf( pastdueamount, FRMN16, Empr_pastDue );
		sprintf( creditlimit, FRMN16, Empr_cred_total );*/
                sprintf( pastdueamount, "%016ld", atol(Empr_pastDue) );
                sprintf( creditlimit, "%016ld", atol(Empr_cred_total) );
		sprintf( paymentduesign, FRMA1, "D" ); 
/*		sprintf( paymentdue, FRMN16, Empr_paymentDue );*/
                sprintf( paymentdue, "%016ld", atol(Empr_paymentDue) );
		sprintf( outstandingbalancesign, FRMA1, "D" );
/*		sprintf( outstandingbalance, FRMN16, Empr_balance );*/
                sprintf( outstandingbalance, "%016ld", atol(Empr_balance) );

		/* Ciclo */

		indCiclo = 0;
		sprintf( Emp, "%s%s", Empr_eje_prefijo, Empr_gpo_bco );
		sprintf( Ciclo, "%s%s", Ciclo_eje_prefijo, Ciclo_gpo_bco );

		while ( ( atoi( Emp ) >= atoi( Ciclo ) ) && ( ciclo != NO_MORE_ROWS ) && ( indCiclo == 0 ) ){

			if ( ( strcmp( Emp, Ciclo) == 0 ) ){

				strcpy( cycledateindicator, Ciclo_num );
				indCiclo = 1;
			}
		
			else{

				if ( atoi( Emp ) > atoi( Ciclo ) ){
					
					ciclo = dbnextrow( q_dbprocCiclo );
					sprintf(Ciclo, "%s%s",Ciclo_eje_prefijo,Ciclo_gpo_bco);
				}
			}
		}

		/* Obtengo la informacion de plasticos */

		sprintf( Emp, "%s%s%s", Empr_eje_prefijo, Empr_gpo_bco, Empr_emp_num );
		sprintf( Pla, "%s%s%s", Plas_eje_prefijo, Plas_gpo_bco, Plas_emp_num );
		
		indPlasticos = 0;
		
		while ( ( strcmp( Emp, Pla ) >= 0 ) && ( plasticos != NO_MORE_ROWS ) && ( indPlasticos == 0 ) ){

			if ( strcmp( Emp, Pla ) == 0 ){
				sprintf( totalaccounts, "%07ld", atol( Plas_cta_plas ) );
				sprintf( numberofcards, "%07ld", atol( Plas_cta_plas ) );
				indPlasticos = 1;
			}

			plasticos = dbnextrow( q_dbprocCtaPlas );
			sprintf(Pla,"%s%s%s", Plas_eje_prefijo, Plas_gpo_bco,Plas_emp_num );
		}

		/**
		  *		Obtengo la informacion de sobregiros
		  **/
		
		sprintf( Emp, "%s%s%s", Empr_eje_prefijo, Empr_gpo_bco, Empr_emp_num );
		sprintf( Sob, "%s%s%s", Sobr_eje_prefijo, Sobr_gpo_bco, Sobr_emp_num );
		indSobregiros = 0;

		while ( ( strcmp( Emp, Sob ) >= 0) && ( sobregiros != NO_MORE_ROWS ) && ( indSobregiros == 0 ) ){

			if ( strcmp( Emp, Sob ) == 0 ){
/*				sprintf( numberaccountsoverlimit, FRMN7, Sobr_sobregir );*/
                               sprintf( numberaccountsoverlimit, "%07ld", atol(Sobr_sobregir) );
				indSobregiros = 1;
			}

			sobregiros = dbnextrow( q_dbprocSobregi );
			sprintf( Sob, "%s%s%s", Sobr_eje_prefijo, Sobr_gpo_bco, Sobr_emp_num );
		}

		/**
		  *		Obtengo la informacion de creditos
		  **/

		sprintf( Emp, "%s", Corporativo );
		sprintf( Cred, "%s", Cred_corporationNumber );
		indCre = 0;
		
		while ( ( strcmp( Emp, Cred ) >= 0 ) && ( creditos != NO_MORE_ROWS ) && ( indCre == 0 ) ){

			if ( strcmp( Emp, Cred ) == 0 ){
				sprintf( numberofcredits, "%010ld", atol( Cred_num ) );
				sprintf( amountofcredits, "%016ld", atol( Cred_monto ) );
				indCre = 1;
			}

			creditos = dbnextrow( q_dbprocCredito );
			sprintf( Cred, "%s", Cred_corporationNumber );
		}

		/**
		  *		Obtengo la informacion de debitos
		  **/

		sprintf( Debi, "%s", Debi_corporationNumber );
		
		indDeb = 0;

		while ( ( strcmp( Emp, Debi ) >= 0 ) && ( debitos != NO_MORE_ROWS ) && ( indDeb == 0 ) ){
			
			if ( strcmp( Emp, Debi ) == 0 ){

				sprintf( numberofdebits, "%010ld", atol( Debi_num ) );
				sprintf( amountofdebits, "%016ld", atol( Debi_monto ) );
				indDeb = 1;
			}
		
			debitos = dbnextrow( q_dbprocDebitos );
			sprintf( Debi, "%s", Debi_corporationNumber ); 
		}
		

		/**
		  *		armo cadena de MTC4000 para la compracion y definicion del codigo de mantenimiento
		  **/

		sprintf( cadenamtc4000, "%s", MTC_cadena1 );
		strcat( cadenamtc4000, MTC_cadena2 );
		strcat( cadenamtc4000, MTC_cadena3 );
		memset( mtc4000corporationnumber, '\0', sizeof(mtc4000corporationnumber));
		sprintf( mtc4000corporationnumber, "%s", MTC_corporationNumber );

		/**
		  *		armo cadena del registro a insertar para la comparacion y definicion del codigo 
		  *		de mantenimiento 
		  **/

		sprintf( cadenareg4000, "%s",recordidentifier );
		strcat( cadenareg4000, issuerica );
		strcat( cadenareg4000, issuernumberica );
		strcat( cadenareg4000, corporationnumber );
		strcat( cadenareg4000, reservedforinternaluse1 );
		strcat( cadenareg4000, reservedforinternaluse2 );
		strcat( cadenareg4000, reservedforinternaluse3 );
		strcat( cadenareg4000, corporationnameline1 );
		strcat( cadenareg4000, corporationnameline2 );
		strcat( cadenareg4000, addressline1 );
		strcat( cadenareg4000, addressline2 );
		strcat( cadenareg4000, city );
		strcat( cadenareg4000, stateprovince );
		strcat( cadenareg4000, country );
		strcat( cadenareg4000, postalcode );
		strcat( cadenareg4000, currencycode );
		strcat( cadenareg4000, contactperson );
		strcat( cadenareg4000, phonenumber );
		strcat( cadenareg4000, faxnumber );
		strcat( cadenareg4000, emailaddress );
		strcat( cadenareg4000, budgetlimit );
		strcat( cadenareg4000, cycledateindicator );
		strcat( cadenareg4000, totalaccounts );
		strcat( cadenareg4000, accountspastdue );
		strcat( cadenareg4000, accountswithdispute );
		strcat( cadenareg4000, numberofcards );
		strcat( cadenareg4000, chargeoffsign );
		strcat( cadenareg4000, chargeoffamount );
		strcat( cadenareg4000, pastdueamountsign );
		strcat( cadenareg4000, pastdueamount );
		strcat( cadenareg4000, disputeamountsign );
		strcat( cadenareg4000, disputeamount );
		strcat( cadenareg4000, creditlimitsign );
		strcat( cadenareg4000, creditlimit );
		strcat( cadenareg4000, paymentduesign );
		strcat( cadenareg4000, paymentdue );
		strcat( cadenareg4000, outstandingbalancesign );
		strcat( cadenareg4000, outstandingbalance );
		strcat( cadenareg4000, numberofdebits );
		strcat( cadenareg4000, numberofcredits );
		strcat( cadenareg4000, amountofdebits );
		strcat( cadenareg4000, amountofcredits );
		strcat( cadenareg4000, numberaccountsoverlimit );

 /*		sprintf( inputfilerecordnumber, FRMN6, EMPTYSTR ); */
                sprintf( inputfilerecordnumber, "%06ld", atol(EMPTYSTR) );
		sprintf(outgoingincomingerrorcode, FRMA6, EMPTYSTR ); 

		cadenareg4000[ 0 ] = '\0';

		act = 0;

		/**
		  *		Armando Registgro REG4000
		  **/

		sprintf( cadenareg4000, "%s\t", recordidentifier);
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, issuerica );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, issuernumberica );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, corporationnumber );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, reservedforinternaluse1 );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, reservedforinternaluse2 );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, reservedforinternaluse3 );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, corporationnameline1 );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, corporationnameline2 );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, addressline1 );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, addressline2 );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, city );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, stateprovince );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, country );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, postalcode );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, currencycode );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, contactperson );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, phonenumber );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, faxnumber );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, emailaddress );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, budgetlimit );

		sprintf( cycledateindicator, FRMN2, cycledateindicator );

		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, cycledateindicator ); 
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, totalaccounts);  

/*		sprintf( accountspastdue, FRMN7, accountspastdue );*/
                sprintf( accountspastdue, "%07ld", atol(accountspastdue) );

		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, accountspastdue );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, accountswithdispute );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, numberofcards );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, chargeoffsign );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, chargeoffamount );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, pastdueamountsign );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, pastdueamount );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, disputeamountsign );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, disputeamount );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, creditlimitsign );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, creditlimit );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, paymentduesign );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, paymentdue );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, outstandingbalancesign );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, outstandingbalance );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, numberofdebits );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, numberofcredits );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, amountofdebits );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, amountofcredits );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, numberaccountsoverlimit );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, portfoliodate );

		sprintf( addressmaintenanceactioncode, FRMA1, addressmaintenanceactioncode );

		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, addressmaintenanceactioncode );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, inputfilerecordnumber );
		sprintf( cadenareg4000, "%s%s\t", cadenareg4000, outgoingincomingerrorcode );
		sprintf( cadenareg4000, "%s%s", cadenareg4000, "0" );
		if ( ( fprintf(reg4000, "%s\n", cadenareg4000 ) ) == -1 ){
			printf( "Fecha proceso: %s\n", fechayhora );
			printf( "Nombre archivo: %s\n", nombrearchivo );
			printf( "Programa: 4000.c \n");
			printf( "Error: No grabo el registro en el archivo reg4000.txt\n");
			exit( 1 );
		}
	
		else
                {
			banderainserto=1;
		}

		empresas = dbnextrow( q_dbprocEmpresa );
	} /* fin del while de empresa */  

	fclose( reg4000 );
/*	fclose( param ); * /

	/**
	  *		Se ejecuta el bulkcopyprocedure de reg4000.txt a la tabla REG4000 
	  **/

	if ( banderainserto == 1 ) { 
		
		sprintf( bulkcopy, "bcp M111.dbo.REG4000 in %s", nombrearchivo_temp );
		strcat( bulkcopy,  " -c  -U" );
		strcat( bulkcopy, ge_user );
		strcat( bulkcopy, " -P" );
		strcat( bulkcopy, ge_password );
		strcat( bulkcopy, " -S" );
		strcat( bulkcopy, ge_server );
		system( bulkcopy );
	}

	/**
	  *		se actualiza la tabla REG4000 en el campo indJer 
	  **/

	dbcancel( q_dbproc );
	sqlcmd[ 0 ] = '\0';
	sprintf( sqlcmd, " update REG4000 set r.indJer='1' \n" );
	strcat( sqlcmd, "from REG4000 r, MTCUNI01 u \n" );
	strcat( sqlcmd, "where u.eje_prefijo=convert(int,\n" );
	strcat( sqlcmd, "substring(r.corporationNumber,1,4)) \n" );
	strcat( sqlcmd, "and u.gpo_banco=convert(int,\n" );
	strcat( sqlcmd, "substring(r.corporationNumber,5,2)) \n" );
	strcat( sqlcmd, "and u.emp_num=convert(int,substring(\n" );
	strcat( sqlcmd, "corporationNumber,7,(select pgs_long_emp \n" );
	strcat( sqlcmd, "from MTCPGS01 i where \n" );
	strcat( sqlcmd, "i.pgs_rep_prefijo = u.eje_prefijo \n" );
	strcat( sqlcmd, "and i.pgs_rep_banco = u.gpo_banco))) \n" );
	strcat( sqlcmd, "and u.unit_parent_id=null \n" );
	strcat( sqlcmd, "and u.nivel_num=1 \n");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa decima Consulta: \n\n%s\n\n", sqlcmd );*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){

		printf("Fecha proceso: %s\n", fechayhora );
		printf("Nombre archivo: %s\n", nombrearchivo );
		printf("Programa: r4000.c \n");
		printf("Fallo intento al actualizar campo indJer en la tabla REG4000 \n"); 
		printf("dbsqlexec:%s \n", sqlcmd );
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	dbcancel( q_dbproc );
	sqlcmd[ 0 ] = '\0';

	/**
	  *		Consulta de Mantenimiento y Actualizaci'on
	  **/

	strcpy( sqlcmd, "delete REG4000 from MTC4000 where REG4000.corporationNumber = MTC4000.corporationNumber ");
	strcat( sqlcmd, "and REG4000.corporationNameLine1 = MTC4000.corporationNameLine1  ");
	strcat( sqlcmd, "and REG4000.corporationNameLine2 = MTC4000.corporationNameLine2 and REG4000.addressLine1 = MTC4000.addressLine1 ");
	strcat( sqlcmd, "and REG4000.addressLine2 = MTC4000.addressLine2 and REG4000.city = MTC4000.city  ");
	strcat( sqlcmd, "and REG4000.stateProvince = MTC4000.stateProvince and REG4000.country = MTC4000.country ");
	strcat( sqlcmd, "and REG4000.postalCode = MTC4000.postalCode and REG4000.currencyCode = MTC4000.currencyCode ");
	strcat( sqlcmd, "and REG4000.contactPerson = MTC4000.contactPerson and REG4000.phoneNumber = MTC4000.phoneNumber ");
	strcat( sqlcmd, "and REG4000.faxNumber = MTC4000.faxNumber and REG4000.emailAddress = MTC4000.emailAddress ");
	strcat( sqlcmd, "and REG4000.budgetLimit = MTC4000.budgetLimit and REG4000.cycleDateIndicator = MTC4000.cycleDateIndicator ");
	strcat( sqlcmd, "and REG4000.totalAccounts = MTC4000.totalAccounts and REG4000.accountsPastDue = MTC4000.accountsPastDue ");
	strcat( sqlcmd, "and REG4000.accountsWithDispute = MTC4000.accountsWithDispute and REG4000.numberOfCards = MTC4000.numberOfCards ");
	strcat( sqlcmd, "and REG4000.chargeOffAmount = MTC4000.chargeOffAmount and REG4000.pastDueAmount = MTC4000.pastDueAmount ");
	strcat( sqlcmd, "and REG4000.disputeAmount = MTC4000.disputeAmount and REG4000.creditLimit = MTC4000.creditLimit ");
	strcat( sqlcmd, "and REG4000.paymentDue = MTC4000.paymentDue and REG4000.outstandingBalance = MTC4000.outstandingBalance ");
	strcat( sqlcmd, "and REG4000.numberOfDebits = MTC4000.numberOfDebits and REG4000.numberOfCredits = MTC4000.numberOfCredits ");
	strcat( sqlcmd, "and REG4000.amountOfDebits = MTC4000.amountOfDebits and REG4000.amountOfCredits = MTC4000.amountOfCredits ");
	strcat( sqlcmd, "and REG4000.numberAccountsOverLimit = MTC4000.numberAccountsOverLimit update REG4000  ");
	strcat( sqlcmd, "set addressMaintenanceActionCode = 'A' update REG4000 set REG4000.addressMaintenanceActionCode = 'U'  ");
	strcat( sqlcmd, "from MTC4000 where REG4000.corporationNumber = MTC4000.corporationNumber  ");
	strcat( sqlcmd, "and REG4000.corporationNameLine1 = MTC4000.corporationNameLine1 ");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa onceava Consulta: \n\n%s\n\n", sqlcmd );*/

	if ( dbsqlexec(q_dbproc) == FAIL){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4000.c \n" );
		printf( "Fallo intento al actualizar campo indJer en la tabla REG4000 \n" ); 
		printf( "dbsqlexec:%s \n", sqlcmd );
		dbclose( q_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	system( "date" );
	/* Close our connection and exit the program */ 
	dbexit( );
	exit( 0 );
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

	else {

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
			printf("Programa: r4000\n");
			printf("Error %lid, Nivel Severidad %d, Estado %d \n", msgno, severity, msgstate);
			printf("Mensaje error: \n%s\n",msgtext);
			printf("Se ejecuta el sql: \n%s\n", sqlcmd);
			exit(1);
		}
	}
	return (0);
}
