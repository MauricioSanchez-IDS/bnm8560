/*
** Confidential property of Eissa, Inc.
** (c) Copyright Eissa, Inc.2003 to 2005
** All rights reserved.
** r4200.c:      4/06/2003
**  
**
** Elaborado por: Ing Jose Ramon Gonzalez Diaz
**
** Funcion: Este programa obtiene la estructura jerarquica necesaria para
**           generar el archivo cdf. 
** Parametros: nombre del programa         r4200
**             nombre archivo para bcp     reg4200.txt
**             numero del prefijo          5473 o 0
**             grupo banco                 88 o 0
**             numero de empresa           640 o 0          
*/
#if USE_SCCSID
static char Sccsid[] = {"@(#) r4200.c 87.1 12/29/93"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <syberror.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "sybdbex.h"
#include "cam4200.h" /*campos 4200*/

/* Forward declarations of the error handler and message handler. */
int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();

#define CADENAREG4200 274
#define LONGPREFBANCO 6
#define TOTALPARAMETROS 5

/* variables globales para el manejo de los argumentos de fechayhora y nombredel
 archivo a generar */
char fechayhora[20];
char nombrearchivo[60];
char sqlcmd[3000];

main(argc, argv)
int             argc;
char            *argv[];
{
	/* Se define un apuntador para manejo del archivo */   
	FILE *reg4200;

	RETCODE         return_code; 

	DBPROCESS     *q_dbproc;       /* Our connection with SQL Server. */
	DBPROCESS     *m_dbproc;       /* Our connection with SQL Server. */
	DBPROCESS     *c_dbproc;     /*coneccion para los campos */
	DBPROCESS     *i_dbproc;     /*coneccion para los campos */
	LOGINREC      *login;        /* Our login information. */

	/*longitud del registro*/            
	char cadenareg4200[ CADENAREG4200 + 1 ]; 
	char cadenaregMTC4200[ CADENAREG4200 + 1 ]; 

	/* variables globales para el manejo de los argumentos
	de fecha proceso y nombre del archivo a generar  */  
	extern char fechayhora[20];
	extern char nombrearchivo[60];
	extern char sqlcmd[3000];

	/* These are the variables used to store the returning data. */
	RETCODE        result_code;

	time_t lcl_time;     
	struct tm *today;    

	int cont1, cont2, dec;
	char *p;

	char ejePrefijo[5];
	char gpoBanco[3];
	char empNumero[6];
	int i;
	int long_ini;
	int act;
	char ge_user[10];
	char ge_password[10];
	char ge_server[10];
	char ge_hostname[10];
	char ge_dbase[10];
	char bulkcopy[100];
	int banderainserto;
	char directorio_archivo[50];
	char nombrearchivo_temp[100];
	int  existenDatos;


	int intRegs;

	/* variables para MTCICA01 */

	DBCHAR issuerIca[ 11 + 1 ];
	DBCHAR issuerNumberIca[ 11 + 1 ];

	/* variables para MTC4200 */
	DBCHAR  mtc4200recordidentifier[ 4 + 1 ];
	DBCHAR  mtc4200issuerica[ 11 + 1 ];
	DBCHAR  mtc4200issuernumberica[ 11 + 1 ];
	DBCHAR  mtc4200corporationnumber[ 19 + 1 ];
	DBCHAR  mtc4200reservedforinternaluse1[ 3 + 1 ];
	DBCHAR  mtc4200reservedforinternaluse2[ 17 + 1];
	DBCHAR  mtc4200reservedforinternaluse3[ 6 + 1 ];
	DBCHAR  mtc4200organizationpointnumber[ 19 + 1 ];
	DBCHAR  mtc4200freeformattext[ 25 + 1 ];
	DBCHAR  mtc4200reportsto[ 19 + 1 ];
	DBCHAR  mtc4200reportstofreeformattext[ 25 + 1 ];
	DBCHAR  mtc4200reservedforinternaluse4[ 2 + 1 ];

	/* variables para la consulta de jerarquias */
	DBCHAR  dbEje_prefijo[5];
	DBCHAR dbGpo_banco[3];
	DBCHAR dbEmp_num[6];
	DBCHAR dbCorpo_num[17];
	DBCHAR dbPadre[16];
	DBCHAR dbHijos[16];

	  /* checa que se hayan pasado los parametros correspondientes*/                
/*  JMC
	if(( argc > TOTALPARAMETROS ) || ( argc < TOTALPARAMETROS )){
		printf("Programa: r4200.c \n");
		printf("El numero de argumentos no son validos para el programa r4200.c\n");
		exit(1);
	}
 JMC  */
	/*obtiene fecha y hora del proceso */
	time(&lcl_time);
	fflush(stdout);
	today = localtime(&lcl_time);
	strftime(fechayhora,20,"%Y%m%d %T",today);

	/* variables globales para el manejo de los parametrosnombre del archivo CDF a generar */ 
	strcpy(nombrearchivo,argv[1]);
	strcpy(ejePrefijo,argv[2]);
	strcpy(gpoBanco,argv[3]);
	strcpy(empNumero,argv[4]);

	/*inicializamos  DB-Library. */
	if (dbinit() == FAIL){

		/* Registro del error en el archivo log */
		printf("Fecha proceso:%s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4200.c \n");
		printf("Error: No se inicializaron dblibrary de C en el programa r4200.c");
		exit(1);
	}

	/* Instala las rutinas de manejo de errores y mensajes definidas al final del programa */
	dberrhandle((EHANDLEFUNC)err_handler);
	dbmsghandle((MHANDLEFUNC)msg_handler);

        dbsetversion(DBVERSION_100);

	/*obtenemos informacion del ambiente*/
	sprintf(ge_user,"%s",getenv("GE_USER"));
	sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
	sprintf(ge_server,"%s",getenv("GE_SERVER"));
	sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));
	sprintf(ge_dbase,"%s",getenv("GE_DBASE"));
	sprintf(directorio_archivo,"%s",getenv("DIR_TEMP"));

	if( ( ( strlen( ge_user ) == 0 )   || ( strlen( ge_password ) == 0 ) || 
          ( strlen( ge_server ) == 0 ) || ( strlen( ge_hostname ) == 0 ) || 
          ( strlen( ge_dbase ) == 0 )  || ( strlen( directorio_archivo ) == 0) ) ){

			printf("Fecha proceso: %s\n", fechayhora);
			printf("Nombre archivo: %s\n", nombrearchivo);
			printf("Programa: r4200.c \n");
			printf("Error: debe verificar las variables de ambiente\n");
			exit(1);
	}

	/* damos informacion del login */

	login = dblogin( );
	DBSETLUSER( login, ge_user );
	DBSETLPWD( login, ge_password );
	DBSETLAPP( login, ge_hostname );
	DBSETLHOST( login, ge_hostname );
        DBSETLCHARSET(login,"roman8");
	DBSETLENCRYPT(login, TRUE);

	/* abrimos la base de datos. */

	q_dbproc = dbopen( login, ge_server );
	m_dbproc = dbopen( login, ge_server );
	c_dbproc = dbopen( login, ge_server );
	i_dbproc = dbopen( login, ge_server );

	/*nos ubicamos en la base de datos */
	dbuse( q_dbproc, ge_dbase );
	dbuse( m_dbproc, ge_dbase );
	dbuse( c_dbproc, ge_dbase );
	dbuse( i_dbproc, ge_dbase );

	sprintf( nombrearchivo_temp, "%s/reg4200.txt", directorio_archivo );

	system("date \"+%I:%M:%S %p ************inicio el programa          \"");

	/* armamos el sql para valida la existencia de la tabla. */        
	/* se borra la tabla REG4200 si existe */
	sprintf( sqlcmd,"if object_id('dbo.REG4200') is not null \n" );
	strcat( sqlcmd," begin \n" );
	strcat( sqlcmd,"  drop table dbo.REG4200 \n" );
	strcat( sqlcmd," end \n" );
	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if( dbsqlexec( q_dbproc ) == FAIL ){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4200.c \n");
		printf("Fallo al intentar borrar la tabla REG4200 dbsqlexec s %ld\n",sqlcmd);
		dbclose(q_dbproc);
		dbexit();
		exit(ERREXIT);
	}

	dbcancel( q_dbproc );

	sqlcmd[0]='0';

	/**
	  *		Se crea la tabla REG4200 
	  **/

	sprintf( sqlcmd,"select * into REG4200 " );
	strcat( sqlcmd, "from MTC4200 where 1=2 " );
	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if( dbsqlexec( q_dbproc ) == FAIL ){

		/**
		  *		Se ejecuta creaci'on de la tabla REG4200, entra  este punto en caso de fallo
		  **/

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4200.c \n");
		printf("Fallo al intentar crear la tabla REG4200 dbsqlexec %s \n",sqlcmd);
		dbclose(q_dbproc);
		dbexit();
		exit(ERREXIT);
	}

	dbcancel( q_dbproc );

	sqlcmd[0]='\0';

	/**
	  *		Obtengo datos de la tabla de MTCICA01
	  **/

	sprintf( sqlcmd, "select icaNumero, icaNumBanco" );
	strcat( sqlcmd, " from MTCICA01" );
	dbcmd( c_dbproc,sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/
	
	if( dbsqlexec( c_dbproc ) == FAIL){

		/**
		 *		Ejecuci'on de la extraci'on de datos de MTCICA01, entra en caso de falla
		 **/

		printf( "Fecha proceso:%s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al intentar traer datos de MTCICA01 bdsqlexec %s \n", sqlcmd );
		dbclose( c_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Recorremos puntero de resultados
	  **/
	dbresults( c_dbproc );

	if( DBROWS( c_dbproc ) != SUCCEED ){

		/**
		  *		Error con la falta de datos.
		  **/
	
		printf( "Fecha proceso:%s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Fallo al intentar traer datos de MTCICA01 DBROWS\n" );
		dbclose( c_dbproc );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Ligamos los resultados a variables locales.
	  **/

	dbbind( c_dbproc, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)issuerIca );
	dbbind( c_dbproc, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)issuerNumberIca );
	while ( dbnextrow( c_dbproc ) != NO_MORE_ROWS );

/*	sprintf( issuerica, FRMN11 , issuerIca );*/
        sprintf( issuerica, "%011ld" , atol(issuerIca) );

	sqlcmd[0]='\0';

	/* Preparo el archivo que se utilizara para realizar bulkcopy */
	reg4200 = fopen( nombrearchivo_temp, "w" );

	if( reg4200 == NULL ){
		/* registro del error en el archivo log */
		printf( "Fecha proceso:%s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "No se pudo abrir el archivo de trabajo %ld\n", nombrearchivo_temp ); 
		exit( 1 );
	}

	sqlcmd[0]='\0';

	/**
	  *		Vaciamos Tabla de Jerarquias
	  **/

	sprintf( sqlcmd, " if object_id('dbo.MTCJER01') is not null \n" );
	strcat( sqlcmd, " begin \n" );
	strcat( sqlcmd, "  drop table dbo.MTCJER01 \n" );
	strcat( sqlcmd, " end \n" );
	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){

		/**
		  *		Registro del error en el archivo log
		  **/

		printf( "Fecha proceso:%s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al eliminar la tabla MTCJER01 dbsqlexec:%s\n", sqlcmd );
		dbclose( q_dbproc );
		dbexit( );
		exit( 1 );
	}

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';

	/**
	  *		Construyendo tabla MTCJER01
	  **/

	sprintf( sqlcmd, " create table MTCJER01(\n" );
	strcat( sqlcmd, " eje_prefijo int   not null, \n" );
	strcat( sqlcmd, " gpo_banco   int   not null, \n" );
	strcat( sqlcmd, " emp_num     int   not null, \n" );
	strcat( sqlcmd, " padre       char(15)  null, \n" );
	strcat( sqlcmd, " hijos       char(15)  null, \n" );
	strcat( sqlcmd, " nom_padre   char(40) null) \n" );
	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if( dbsqlexec( q_dbproc ) == FAIL ){

		/* registro del error en el archivo log */
		printf( "Fecha proceso:%s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al crear la tabla MTCJER01 dbsqlexec: %s\n", sqlcmd );
		dbclose( q_dbproc );
		dbexit( );
		exit( 1 );
	}

	dbcancel( q_dbproc );

	sqlcmd[0]='\0';

	/**
	  *		Ejecutamos SP de llenado de MTCJER01
	  **/

	sprintf( sqlcmd, " exec sp_jerarquia_cdf_todos %s", ejePrefijo );
	sprintf( sqlcmd, "%s, %s, %s", sqlcmd, gpoBanco, empNumero );
	sprintf( sqlcmd, "%s, '0', 0, 0 ", sqlcmd );

	dbcmd( q_dbproc, sqlcmd );

	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);

	if( dbsqlexec( q_dbproc ) == FAIL ){

		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo intento crear jerarquia dbsqlexec %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	sqlcmd[0]='\0';

	dbcancel( q_dbproc );

	/**
	  *		Verificando contenido de MTCJER01
	  **/

	sprintf( sqlcmd, " select * from MTCJER01 ");
	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo no existe la tabla MTCJER01 dbsqlexec %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	dbresults( q_dbproc );

	/**
	  *		Verificando la existencia de jerarquias
	  **/
	if( dbnextrow( q_dbproc ) != NO_MORE_ROWS ){
		existenDatos = 1;
	}
	else{
		existenDatos = 0;
	}

	if( existenDatos == 0 ){
		dbclose( q_dbproc ); 
		dbclose( m_dbproc ); 
		dbclose( c_dbproc ); 
		dbclose( i_dbproc );
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );                                        
		printf( "Error: Fallo intento crear las jerarquias dbsqlexec %s \n", sqlcmd ); 
		dbexit( );
		exit( ERREXIT );
	}

	dbcanquery( q_dbproc );
	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';

	/**
	  *		Borramos la tabla tmpfinal
	  **/

	strcpy( sqlcmd, "IF OBJECT_ID('tmpfinal') IS NOT NULL BEGIN DROP TABLE tmpfinal END ");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al intentar borrar tabla tmpfinal!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *		Creación de tabla temporal, Dic 2, 2004 FUN.
	  **/

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';
	
	strcpy( sqlcmd, "create table tmpfinal ( cuenta   ");
	strcat( sqlcmd, "char( 16 ), padre char( 10 ), hijos char(10), organizationHierarchyMainAct char( 1 )) ");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al intentar crear tabla tmpfinal!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}


	/**
	  *		Ejecuci'on de SP de ordenamiento, Dic 2, 2004 FUN.
	  **/

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';
	
	strcat( sqlcmd, "exec spS_CompJer ");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al correr el procedure spS_CompJer!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}
	
	
	/**
	  *		Proceso de Actualizaci'on y o Eliminaci'on. Dic 2, 2004. IERM
	  **/

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';

	strcat( sqlcmd, " select a.* into #Iguales  ");
	strcat( sqlcmd, " from MTC4200 a, tmpfinal b  ");
	strcat( sqlcmd, " where a.corporationNumber = b.cuenta  ");
	strcat( sqlcmd, " and a.organizationPointNumber = b.hijos  ");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al intentar borrar tabla tmpfinal!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *
	  **/

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';

	strcat( sqlcmd, " update tmpfinal  ");
	strcat( sqlcmd, " set organizationHierarchyMainAct = 'A'     ");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al intentar borrar tabla tmpfinal!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *
	  **/

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';

	strcat( sqlcmd, " delete tmpfinal ");
	strcat( sqlcmd, " from MTC4200  ");
	strcat( sqlcmd, " where MTC4200.corporationNumber = tmpfinal.cuenta  ");
	strcat( sqlcmd, " and MTC4200.organizationPointNumber = tmpfinal.hijos   ");
	strcat( sqlcmd, " and MTC4200.reportsTo = tmpfinal.padre  ");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al intentar borrar tabla tmpfinal!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *
	  **/

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';

	strcat( sqlcmd, " update tmpfinal ");
	strcat( sqlcmd, " set organizationHierarchyMainAct = 'U'  ");
	strcat( sqlcmd, " from #Iguales  ");
	strcat( sqlcmd, " where tmpfinal.cuenta = #Iguales.corporationNumber  ");
	strcat( sqlcmd, " and tmpfinal.hijos = #Iguales.organizationPointNumber ");

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al intentar borrar tabla tmpfinal!!!\n\n dbsqlexec: %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	/**
	  *
	  **/

	dbcancel( q_dbproc );

	sqlcmd[ 0 ] = '\0';

	strcat( sqlcmd, " select cuenta, hijos, padre, organizationHierarchyMainAct from tmpfinal ");

	/********************************************************************/

	dbcmd( q_dbproc, sqlcmd );

/*	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);*/

	if ( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: Fallo al intentar traer datos dbsqlexec %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}

	//for( act = 0 ; act < 5 ; act++ )
		dbresults( q_dbproc );

	dbbind( q_dbproc, 1, STRINGBIND,( DBINT )0, ( BYTE DBFAR * )dbCorpo_num );
	dbbind( q_dbproc, 2, STRINGBIND,( DBINT )0, ( BYTE DBFAR * ) dbHijos );
	dbbind( q_dbproc, 3, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * )dbPadre );
	dbbind( q_dbproc, 4, STRINGBIND, ( DBINT )0, ( BYTE DBFAR * )organizationhierarchymainact );

	doinicia( );
	banderainserto = 0;


	intRegs=0;

	while( dbnextrow( q_dbproc ) != NO_MORE_ROWS ){

		act = 0;									//Inicia el ciclo
			
		/*campo 1:*/
		sprintf( recordidentifier, FRMA4, "4200" );

		/* campo 4:*/
		
		sprintf( corporationnumber, FRMA19, dbCorpo_num ); 

		/* campo 5:*/ 
		sprintf( reservedforinternaluse1, FRMA3, EMPTYSTR );

		/*campo 6: */
		sprintf( reservedforinternaluse2, FRMA17, EMPTYSTR );

		/* campo 7: */ 
		sprintf( reservedforinternaluse3, FRMA6, EMPTYSTR );

		/*campo 8:*/
		sprintf( organizationpointnumber, FRMA19, dbHijos );  /** Se cambia dbHijos por dbPadre y Vicceversa 20.05.2004 JAGG  EiSSA **/

		/*campo 9:*/ 
		sprintf( freeformattext, FRMA25, EMPTYSTR );

		/* campo 10:*/ 
		sprintf( reportsto, FRMA19, dbPadre ); 

		/* campo 11:*/ 
		sprintf( reportstofreeformattext, FRMA25, EMPTYSTR );

		/*campo 12:*/ 
		sprintf( reservedforinternaluse4, FRMA2, EMPTYSTR );

		/* Se arma cadena para compara el reg4200 v.s. mtc4200 */ 
		sprintf( cadenareg4200, "%s", recordidentifier );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, issuerica );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, issuerNumberIca );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, corporationnumber );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, reservedforinternaluse1 );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, reservedforinternaluse2 );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, reservedforinternaluse3 );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, organizationpointnumber );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, freeformattext );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, reportsto );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, reportstofreeformattext );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, reservedforinternaluse4 );
		 
		/*campo 13:*/
		
		/*campo 14: */
/*		sprintf( inputfilerecordnumber, FRMN6, EMPTYSTR );*/
                sprintf( inputfilerecordnumber, "%06ld", atol(EMPTYSTR) );

		/*campo 15:*/
		sprintf( outgoingincomingerrorcode, FRMA6, EMPTYSTR );

		/*inserto la informacion*/

		act = 0;								//Regresando al inicio del ciclo
		sprintf( cadenareg4200, "%s\t", recordidentifier );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, issuerica );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, issuerNumberIca );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, corporationnumber );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, reservedforinternaluse1 );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, reservedforinternaluse2 );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, reservedforinternaluse3 );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, organizationpointnumber );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, freeformattext );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, reportsto );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, reportstofreeformattext );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, reservedforinternaluse4 );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, organizationhierarchymainact );
		sprintf( cadenareg4200, "%s%s\t", cadenareg4200, inputfilerecordnumber );
		sprintf( cadenareg4200, "%s%s", cadenareg4200, outgoingincomingerrorcode );

		if (( fprintf( reg4200, "%s\n", cadenareg4200 )) == -1 ){
			printf( "Fecha proceso: %s\n", fechayhora );
			printf( "Nombre archivo: %s\n", nombrearchivo );
			printf( "Programa: r4200.c \n" );
			printf( "Error: No se grabo el registro en el archivo reg42000.txt " ); 
			exit( ERREXIT );
		}

		else{
			doinicia( );
			banderainserto = 1;
		}

		intRegs++;
		/*printf("\n Entro por %d vez\n",intRegs);*/

	} /* dbnextrows principal */

	/**
	  *		Borramos la tabla tmpfinal. Dic 3, 2004. IERM.
	  **/


/*	sqlcmd[0]='\0';

	dbcancel( q_dbproc );

	sprintf( sqlcmd, " drop table tmpfinal ");
	dbcmd( q_dbproc, sqlcmd );

	printf("\nLa consulta:\n\n %s\n\n", sqlcmd);

	if( dbsqlexec( q_dbproc ) == FAIL ){
		printf( "Fecha proceso: %s\n", fechayhora );
		printf( "Nombre archivo: %s\n", nombrearchivo );
		printf( "Programa: r4200.c \n" );
		printf( "Error: No se pudo borrar la tabla tmpfinal!!!.\n\n dbsqlexec %s \n", sqlcmd );
		dbexit( );
		exit( ERREXIT );
	}*/


	dbcancel( c_dbproc );
	dbcanquery( c_dbproc );
	dbfreebuf( c_dbproc );
	dbcancel( q_dbproc );
	dbcanquery( q_dbproc );
	dbfreebuf( q_dbproc );
	dbcancel( i_dbproc );
	dbcanquery( i_dbproc );
	dbfreebuf( i_dbproc );
	dbcancel( m_dbproc );
	dbcanquery( m_dbproc );
	dbfreebuf( m_dbproc );

	fclose( reg4200 );

	if( banderainserto == 1 ){

		banderainserto = 0;
		/* Se ejecuta el bulkcopyprocedure de reg4200.txt a la tabla REG4200 */
		sprintf( bulkcopy,"bcp M111.dbo.REG4200 in %s ", nombrearchivo_temp );
		strcat( bulkcopy, " -c -U" );
		strcat( bulkcopy, ge_user );
		strcat( bulkcopy, " -P" );
		strcat( bulkcopy, ge_password );
		strcat( bulkcopy, " -S" );
		strcat( bulkcopy, ge_server );
		system( bulkcopy );
	}

/*	strcpy(bulkcopy, "cp ");
	strcat(bulkcopy, nombrearchivo_temp);
	strcat(bulkcopy, " /opt/c430/alberto/felipe/archdem1.txt");

	system(bulkcopy);*/


	printf( "Hora de termino del proceso para generar el registro 4200 \n" );
	system( "date \"+%I:%M:%S %p ************ salgo de  ejecutar programa\"\n" );
	printf( "Se termino satisfactoriamente la ejecucion del programa r4200.c\n" );
	/* Close our connection and exit the program. */
	dbexit( );
	exit( 0 );
}

doinicia( ){

 /* Se inicializan las variables a utilizar */      

        memset( recordidentifier, '\0' , sizeof(recordidentifier));
        memset( corporationnumber, '\0' , sizeof(corporationnumber));
        memset( reservedforinternaluse1, '\0' , sizeof(reservedforinternaluse1));
        memset( reservedforinternaluse2, '\0' , sizeof(reservedforinternaluse2));
        memset( reservedforinternaluse3, '\0' , sizeof(reservedforinternaluse3));
        memset( organizationpointnumber, '\0' , sizeof(organizationpointnumber));
        memset( freeformattext, '\0' , sizeof(freeformattext));
        memset( reportsto, '\0' , sizeof(reportsto));
        memset( reportstofreeformattext, '\0' , sizeof(reportstofreeformattext));
        memset( reservedforinternaluse4, '\0' , sizeof(reservedforinternaluse4));
        memset( organizationhierarchymainact, '\0' , sizeof(organizationhierarchymainact));
        memset( inputfilerecordnumber, '\0' , sizeof(inputfilerecordnumber));
        memset( outgoingincomingerrorcode, '\0' , sizeof(outgoingincomingerrorcode));
}

int CS_PUBLIC err_handler( dbproc, severity, dberr, oserr, dberrstr, oserrstr )
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

int CS_PUBLIC msg_handler(dbproc, msgno, msgstate, severity, msgtext, srvname, procname, line)

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
		if( severity == 16 ){

			fprintf (ERR_CH, "Msg %ld, Level %d, State %d\n", msgno, severity, msgstate );

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

