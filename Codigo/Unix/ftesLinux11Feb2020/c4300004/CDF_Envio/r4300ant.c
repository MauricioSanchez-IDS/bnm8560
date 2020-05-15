/*                                                                              
** Propiedad de EISSA                                                           
** (c) Copyright EISSA 2000                                                     
** All rights reserved.                                                         
** r4300.c:      2001.1      01/03/01      10:55:45 
**                                                                              
** Elaborado por : Walter Munoz Oliver                                          
** Modificado por: Jose Ramon Gonzalez Diaz
*/                                                                              

/* Objetivo;
**   Obtener el la informacion de tarjetahabientes y su   
**   resumen de movimientos si asi los hubieran tenido 
**   si el mismo obedecio a una fecha de corte, se incluyo
**   la estructuras de jerarquias.
** 
** Historia: 30-Marzo-2004 Se Arreglan Querys JAGG
** Historia: 18-MAyo-2004 Se Arreglan Validaciones codigo de Mantenimiento JAGG
**
*/

#if USE_SCCSID
static char Sccsid[] = {"@(#) r4300.c 87.1 01/03/01"};
#endif /* USE_SCCSID */

#include <stddef.h>
#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "sybdbex.h"
#include "cam4300.h" /*campos 4300*/


#define CADENAREG4300  732             /*Actualizado de 706 a 732*/
#define TOTALPARAMETROS 8

/* variables globales para el manejo de los argumentos de fechayhora y nombred
el archivo a generar */                                                         

char fechayhora[20];                                                          
char nombrearchivo[60];                                                         
char sqlcmd[SQLBUFLEN];                                                         

/* Forward declarations of the error handler and message handler. */
int CS_PUBLIC   err_handler();  
int CS_PUBLIC   msg_handler();

main(argc, argv)
int argc;
char *argv[];

{
	FILE *reg4300;                                      
	FILE *param;

        DBPROCESS     *q_dbproc;     /* Our connection with SQL Server. */
	DBPROCESS     *dbproc_mtc;   /* coneccion para MTC4300 */
	DBPROCESS     *dbproc_cta;   /* corporativos y cuentas*/
	DBPROCESS     *dbproc_mon;   /* montos de los trjetahabientes*/
	LOGINREC      *login;        /* Our login information. */


	/*longitud del registro*/           
	char cadenareg4300[CADENAREG4300+55+1];
	char cadenamtc4300[CADENAREG4300+55+1];

	time_t lcl_time;
	struct tm *today;

	char          ge_user[10];
	char          ge_password[10];
	char          ge_server[10];
	char          ge_hostname[10];
	char          ge_dbase[10];

	/*variables para armar el where*/    
	char fecCor[200+1];
	char ejePrefijo[4+1]; 
	char gpoBanco[2+1];
	char empNumero[5+1];
	char fecIni[8+1];
	char fecFin[8+1]; 
	char cadena[150];
	char directorio_archivo[50]; 
	char nombrearchivo_temp[100];
	char bulkcopy[100];
	int contador;
	char cad_car[17];
	char caracter[2];
	int graba;
	int graba2;

	/* variables globales para el manejo de los argumentos de fecha proceso y nombre del archivo a generar  */ 
	extern char fechayhora[20];
	extern char nombrearchivo[60];
	extern char sqlcmd[SQLBUFLEN];

	/*variables para MTCICA01*/
	DBCHAR issuerIca[11+1];                   /*Actualizado de 6 a 11*/
	DBCHAR issuerNumberIca[11+1];
	DBCHAR originalCurrencyCode[3+1];

	int banderainserto;

	/* Variables para informacion base cuentas  */
	DBCHAR ctaEjePrefijo         [4  + 1];
	DBCHAR ctaGpoBanco           [2  + 1];
	DBCHAR ctaEmpNum             [5  + 1];
	DBCHAR ctaEjeNum             [3  + 1];
	char   cta                   [16 + 1];
	DBCHAR eje_num_corp          [16 + 1];
	DBCHAR eje_reportsTo         [15 + 1];
	DBCHAR eje_num_cuenta        [16 + 1];
	DBCHAR eje_nombre            [45 + 1];
	DBCHAR eje_direccion         [70 + 1];
	DBCHAR eje_pob               [25 + 1];
	DBCHAR eje_cp                [10 + 1];
	char   mon                   [16 + 1];
	DBCHAR eje_tel_dom           [15 + 1];
	DBCHAR eje_fax               [15 + 1];
	DBCHAR eje_limcred           [16 + 1];
	DBCHAR monEjePrefijo         [4  + 1];
	DBCHAR monGpoBanco           [2  + 1];
	DBCHAR monEmpNum             [5  + 1];
	DBCHAR monEjeNum             [3  + 1];
	DBCHAR eje_saldo_anterior    [16 + 1];
	DBCHAR eje_intereses         [16 + 1];
	DBCHAR eje_comisiones        [16 + 1];
	DBCHAR eje_pagos_abonos      [16 + 1];
	DBCHAR eje_compras_dispo     [16 + 1];
	DBCHAR eje_plas_ini          [8  + 1];  
	DBCHAR eje_plas_fin          [6  + 1];
	DBCHAR eje_retrazos          [16 + 1];
	DBCHAR eje_balance_ini       [16 + 1];
	DBCHAR eje_balance_fin       [16 + 1];
	DBCHAR eje_pagos_atr         [16 + 1];
	DBCHAR eje_bal_pagos_atr     [16 + 1];
	DBCHAR unitpadre             [16];
	DBCHAR eje_num_nom           [ 15 + 1 ]; /*IERM*/

	/* Variables para llamar fecha de proceso*/
	DBCHAR        fechaGenera[8+1]; /*el formato es ccyymmdd*/

	banderainserto=0;
	fflush(stdout);

	/* revisa que se hayan pasado los parametros correspondientes*/ 

	if ((argc > TOTALPARAMETROS) || (argc < TOTALPARAMETROS)){ 

		printf("Programa: r4300.c \n");
		printf("El numero de argumentos no son validos para el programa r4300.c\n");
		exit(1); 
	}

	/*obtiene fecha y hora del proceso */
	time(&lcl_time); 
	today = localtime(&lcl_time); 
	strftime(fechayhora,20,"%Y%m%d %T",today); 

	/* variables globales para el manejo de los argumentos                       
	nombre del archivo CDF a generar y el rango de fechas de los movimientos*/

	// printf("\nParametros Recibidos  -%s- -%s-  -%s-", ejePrefijo,gpoBanco,empNumero); 
/*
	strcpy(gpoBanco,""); 
	strcpy(empNumero,"");
	fecIni[0] = '\0';
	fecFin[0] = '\0';
	fecCor[0] =  '\0';
        sprintf(nombrearchivo,"%s","");
        sprintf(ejePrefijo,"%s","");
*/

        memset(gpoBanco,'\0', sizeof(gpoBanco));
        memset(empNumero,'\0', sizeof(empNumero));
        memset(fecIni,'\0', sizeof(fecIni));
        memset(fecFin,'\0', sizeof(fecFin));
        memset(fecCor,'\0', sizeof(fecCor));
	memset(nombrearchivo,'\0', sizeof(nombrearchivo));
	memset(ejePrefijo,'\0', sizeof(ejePrefijo));

	strncpy(nombrearchivo,argv[1], strlen(argv[1]));                                               
	strncpy(ejePrefijo,argv[2],  strlen(argv[2]));                                               
	strncpy(gpoBanco,argv[3],  strlen(argv[3]));                                               
	strncpy(empNumero,argv[4],  strlen(argv[4]));                                               
	strncpy(fecIni,argv[5],  strlen(argv[5]));                                               
	strncpy(fecFin,argv[6], strlen(argv[6]));                                               
	strncpy(fecCor, argv[7], strlen(argv[7]));                                                     

        printf("fecCor: %s %d\n", fecCor,strlen(argv[7]));
 
	if (dbinit() == FAIL){

		/* registro del error en el archivo log */
		printf("Fecha proceso:%s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n");
		printf("Error: No se inicializaron las dblibrary de C en el programa r4300.c\n"); 
	/*	dbclose(q_dbproc); */
		dbexit(); 
		exit(ERREXIT);
	}

	/* instala las rutinas de manejo de errores y mensajes definidas
	* al final de este programa.
	*/
	dberrhandle((EHANDLEFUNC)err_handler);  
	dbmsghandle((MHANDLEFUNC)msg_handler);

	/*obtencion de datos de ambiente*/
	sprintf(ge_user,"%s",getenv("GE_USER"));
	sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
	sprintf(ge_server,"%s",getenv("GE_SERVER"));
	sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));
	sprintf(ge_dbase,"%s",getenv("GE_DBASE"));

	sprintf(directorio_archivo,"%s",getenv("DIR_TEMP"));

	if  ( (strlen(ge_user) == 0)   || (strlen(ge_password) == 0) || 
		(strlen(ge_server) == 0) || (strlen(ge_hostname) == 0) || 
		(strlen(ge_dbase) == 0)  || (strlen(directorio_archivo) == 0) ){

		printf("Fecha proceso: %s\n", fechayhora);                          
		printf("Nombre archivo: %s\n", nombrearchivo);                      
		printf("Programa: 4300.c \n");                                      
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

	/*
	** abrimos la base de datos.
	*/

	q_dbproc = dbopen(login, ge_server);
	dbproc_mtc = dbopen(login, ge_server);
	dbproc_cta = dbopen(login, ge_server);
	dbproc_mon = dbopen(login, ge_server);

	/*nos ubicamos en la base de datos */
	dbuse(q_dbproc, ge_dbase);
	dbuse(dbproc_mtc, ge_dbase);
	dbuse(dbproc_cta, ge_dbase);
	dbuse(dbproc_mon, ge_dbase);

	sprintf(nombrearchivo_temp,"%s/reg4300.txt",directorio_archivo); 

	printf("Hora de inicio del proceso para generar el registro 4300 %s\n",fechayhora);

	/* se borra la tabla REG4300 si existe */ 
	sprintf(sqlcmd,"if object_id('dbo.REG4300') is not null ");
	strcat(sqlcmd," begin                               ");
	strcat(sqlcmd,"  drop table dbo.REG4300                ");
	strcat(sqlcmd," end                                 "); 
	dbcmd(q_dbproc, sqlcmd);
	if( dbsqlexec(q_dbproc) == FAIL){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: 43000.c \n");
		printf("Error: Fallo al intentar borrar la tabla REG4300 dbsqlexec\n");
		dbclose(q_dbproc);
		dbexit();
		exit(ERREXIT);
	}

	dbcancel(q_dbproc);

	/* se crea la tabla REG4300 */ 
	sprintf(sqlcmd,"select * into REG4300 ");
	strcat(sqlcmd, "from MTC4300 where 1=2 ");
	dbcmd(q_dbproc, sqlcmd);

	if( dbsqlexec(q_dbproc) == FAIL){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n"); 
		printf("Fallo al intentar crear la tabla REG4300 dbsqlexec %s\n",sqlcmd);
		dbclose(q_dbproc); 
		dbexit(); 
		exit(ERREXIT);
	} 

	sprintf(sqlcmd,"select icaNumero, icaNumBanco, currency, ");
	sprintf(sqlcmd,"%s %s",sqlcmd,"fechaGenera=convert(char(8),getdate(),112) ");
	strcat(sqlcmd,"from MTCICA01");
	dbcmd(q_dbproc,sqlcmd);

	if (dbsqlexec(q_dbproc) == FAIL){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n");
		printf("Error: Fallo al intentar traer datos de MTCICA dbsqlexec %s \n",sqlcmd);
		dbclose(q_dbproc); 
		dbexit(); 
		exit(ERREXIT);
	}

	dbresults(q_dbproc);
	
	if (dbrows(q_dbproc) != SUCCEED){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n");
		printf("Error al tratar de evaluar el resultado del query de emisor\n");
		dbclose(q_dbproc); 
		dbexit(); 
		exit(ERREXIT);
	}
	/*evaluamos los resultados*/
	dbbind(q_dbproc, 1, NTBSTRINGBIND, 0,(CS_BYTE *)issuerIca);
	dbbind(q_dbproc, 2, NTBSTRINGBIND, 0,(CS_BYTE *)issuerNumberIca);
	dbbind(q_dbproc, 3, NTBSTRINGBIND, 0,(CS_BYTE *)originalCurrencyCode);
	dbbind(q_dbproc, 4, NTBSTRINGBIND, 0,(CS_BYTE *)fechaGenera);
	while (dbnextrow(q_dbproc) != NO_MORE_ROWS);

	/*archivo para realizar el bolkcopy*/
	reg4300 = fopen(nombrearchivo_temp, "w");                    
	if (reg4300 == NULL){

		/* registro del error en el archivo log */                                 
		printf("Fecha proceso:%s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n");                                            
		printf("Error: No se pudo abrir el archivo de trabajo %ld\n",nombrearchivo_temp);
		exit(1);                                              
	}                                                     

	/*************************************************************/

	/*obtenemos la informacion monetaria de las cuentas*/
	sprintf(sqlcmd, " select distinct right('0000'+convert(char(4),a.eje_prefijo),4), \n");
	strcat(sqlcmd, "right('00'+convert(char(2),a.gpo_banco),2), \n"); 
	strcat(sqlcmd, "replicate ('0', (select pgs_long_emp from MTCPGS01 i \n"); 
	strcat(sqlcmd, "where i.pgs_rep_prefijo = a.eje_prefijo \n");
	strcat(sqlcmd, "and i.pgs_rep_banco = a.gpo_banco) - \n");
	strcat(sqlcmd, "char_length(ltrim(rtrim(str(a.emp_num)))))+ \n");
	strcat(sqlcmd, "ltrim(rtrim(str(a.emp_num))), \n");
	strcat(sqlcmd, "replicate ('0',(select pgs_long_eje from MTCPGS01 g \n"); 
	strcat(sqlcmd, "where g.pgs_rep_prefijo = a.eje_prefijo \n");
	strcat(sqlcmd, "and g.pgs_rep_banco = a.gpo_banco) - \n");
	strcat(sqlcmd, "char_length(ltrim(rtrim(str(a.eje_num)))))+ \n");
	strcat(sqlcmd, "ltrim(rtrim(str(a.eje_num))), \n"); 
	strcat(sqlcmd, "isnull(str(sum(a.hih_saldo_anterior),16,2),\n");
	strcat(sqlcmd, "'0000000000000000') saldo_anterior, \n");
	strcat(sqlcmd, "isnull(str((sum(a.hih_intereses))*10000,16), \n");
	strcat(sqlcmd, "'0000000000000000') intereses, \n");
	strcat(sqlcmd, "isnull(str((sum(a.hih_comisiones))*10000,16), \n");
	strcat(sqlcmd, "'0000000000000000') comisiones, \n");
	strcat(sqlcmd, "isnull(str((sum(a.hih_pagos_y_abonos))*10000,16),\n");
	strcat(sqlcmd, "'0000000000000000') pagos_abonos, \n");
	strcat(sqlcmd, "isnull(str((sum(a.hih_compras_y_disp))*10000,16),\n");
	strcat(sqlcmd, "'0000000000000000') compras_dispo, \n");
	strcat(sqlcmd, "isnull(convert(varchar(3),sum(a.hih_num_meses_vencidos))\n");
	strcat(sqlcmd, ",'0') retrazos, \n");
	strcat(sqlcmd, "isnull(str((sum(a.hih_saldo_anterior))*10000,16),\n");
	strcat(sqlcmd, "'0000000000000000') balance_ini, \n");
	strcat(sqlcmd, "isnull(str((sum(a.hih_saldo_anterior + a.hih_compras_y_disp\n"); 
	strcat(sqlcmd, "+ a.hih_comisiones + a.hih_intereses\n"); 
	strcat(sqlcmd, "+ ((-1)* a.hih_pagos_y_abonos)))*10000,16),\n");
	strcat(sqlcmd, "'0000000000000000') balance_fin, \n");
	/* se obtiene el minimo a pagar y se almacena como bal_pagos_atr */
	strcat(sqlcmd, "convert(float,(ltrim(rtrim(right(convert(char(8), \n");
	strcat(sqlcmd, "sum(hih_num_compras)), 4)))+ltrim(rtrim(substring( \n");
	strcat(sqlcmd, "convert(char(8),sum(hih_num_disp)),1,2)))+'.'+ \n");
	strcat(sqlcmd, "ltrim(rtrim(right(convert(char(8),sum(hih_num_disp)),2))))) \n");
	strcat(sqlcmd, "*10000 bal_pagos_atr \n");
	strcat(sqlcmd, "from MTCHIH01 a , MTCEMP01 b \n");
	sprintf(sqlcmd, "%s where  a.hih_corte_md in (%s) \n",sqlcmd,fecCor);
	
	
	if ( strcmp(ejePrefijo,"0") != 0 && strcmp(gpoBanco,"0") != 0 ){

		strcat(sqlcmd, " and a.eje_prefijo = \n");       
		sprintf(sqlcmd, "%s %s ",sqlcmd,ejePrefijo);
		strcat(sqlcmd, "and  a.gpo_banco = \n");    
		sprintf(sqlcmd, "%s %s ",sqlcmd,gpoBanco);  
	
		if ( strcmp(empNumero,"0") != 0 ){

			strcat(sqlcmd, "and  a.emp_num = \n");      
			sprintf(sqlcmd, "%s %s ",sqlcmd,empNumero); 
		}
	}

	strcat(sqlcmd, "and a.eje_num > 0 ");                                        
	strcat(sqlcmd, "and a.eje_prefijo=b.eje_prefijo \n");
	strcat(sqlcmd, "and a.gpo_banco=b.gpo_banco \n");
	strcat(sqlcmd, "and a.emp_num=b.emp_num \n");
	strcat(sqlcmd, "and b.emp_gen_CDF=1 \n");
	strcat(sqlcmd, "group by a.eje_prefijo, a.gpo_banco, a.emp_num, a.eje_num \n");
	strcat(sqlcmd, "order by a.eje_prefijo, a.gpo_banco, a.emp_num, \n");
	strcat(sqlcmd," a.eje_num \n");

	 
//	 printf("\n\n\n\tRegistro 4300 MONETARIO: \n %s \n", sqlcmd ); 


	dbcmd(dbproc_mon, sqlcmd);
	
	if (dbsqlexec(dbproc_mon) == FAIL){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n");
		printf("No se pudo obtener informacion de MONTOS %s \n",sqlcmd);
		dbclose(dbproc_mon); 
		dbexit(); 
		exit(ERREXIT);
	}

	dbresults(dbproc_mon);
	
	dbbind(dbproc_mon, 1, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)monEjePrefijo);
	dbbind(dbproc_mon, 2, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)monGpoBanco); 
	dbbind(dbproc_mon, 3, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)monEmpNum);
	dbbind(dbproc_mon, 4, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)monEjeNum);
	dbbind(dbproc_mon, 5, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_saldo_anterior);  //No se USA
	dbbind(dbproc_mon, 6, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_intereses);       //no se USA
	dbbind(dbproc_mon, 7, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_comisiones);      //no se USA
	dbbind(dbproc_mon, 8, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_pagos_abonos);    //no se USA
	dbbind(dbproc_mon, 9, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_compras_dispo);    //no se USA
	dbbind(dbproc_mon, 10, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_retrazos); 
	dbbind(dbproc_mon, 11, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_balance_ini);
	dbbind(dbproc_mon, 12, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_balance_fin);
	dbbind(dbproc_mon, 13, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_bal_pagos_atr); 
	dbnextrow(dbproc_mon);


	/******************************************************+*/

	/*obtenemos el numero de cuentas que son susceptibles de reportarse*/ 
	sprintf(sqlcmd," select right('0000'+convert(char(4),a.eje_prefijo),4) pref, \n");
	strcat(sqlcmd," right('00'+convert(char(2),a.gpo_banco),2) banco, \n");
	strcat(sqlcmd," replicate ('0', (select pgs_long_emp from MTCPGS01 g \n");
	strcat(sqlcmd," where g.pgs_rep_prefijo = a.eje_prefijo \n");
	strcat(sqlcmd," and g.pgs_rep_banco = a.gpo_banco) - char_length(ltrim(\n");
	strcat(sqlcmd,"rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num))) empresa,\n");
	strcat(sqlcmd," replicate ('0',(select pgs_long_eje from MTCPGS01 f \n");
	strcat(sqlcmd," where f.pgs_rep_prefijo = a.eje_prefijo \n");
	strcat(sqlcmd," and f.pgs_rep_banco = a.gpo_banco) - char_length(ltrim(\n");
	strcat(sqlcmd,"rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num))) eje,\n");
	strcat(sqlcmd,"CtaCorp=convert(char(16), convert(char(4), a.eje_prefijo)+\n");
	strcat(sqlcmd,"convert(char(2), a.gpo_banco)+replicate('0',( \n");
	strcat(sqlcmd,"select pgs_long_emp from MTCPGS01 i  \n");
	strcat(sqlcmd,"where i.pgs_rep_prefijo = a.eje_prefijo \n");
	strcat(sqlcmd,"and i.pgs_rep_banco = a.gpo_banco)- char_length(ltrim(\n");
	strcat(sqlcmd,"rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num)))+\n");
	strcat(sqlcmd,"replicate ('0',(select pgs_long_eje from MTCPGS01 h \n");
	strcat(sqlcmd,"where h.pgs_rep_prefijo = a.eje_prefijo \n");
	strcat(sqlcmd,"and h.pgs_rep_banco = a.gpo_banco))+'9'+convert(char(1),\n");
	strcat(sqlcmd,"(select p.eje_digit from MTCPLA01 p \n");
	strcat(sqlcmd," where p.eje_roll_over=9 and p.eje_prefijo = a.eje_prefijo\n");
	strcat(sqlcmd," and p.gpo_banco = a.gpo_banco and p.emp_num = a.emp_num \n");   
	strcat(sqlcmd," and p.eje_num = 0))), \n");
	strcat(sqlcmd," isnull(SUBSTRING(c.eje_centro_c,1,8),' ') reportsTo, \n");
	strcat(sqlcmd," accountNumber = convert(char(4),a.eje_prefijo)+\n");
	strcat(sqlcmd,"convert(char(2),a.gpo_banco)+replicate('0',(\n");
	strcat(sqlcmd,"select pgs_long_emp from MTCPGS01 i \n");
	strcat(sqlcmd," where i.pgs_rep_prefijo = a.eje_prefijo \n");
	strcat(sqlcmd," and i.pgs_rep_banco = a.gpo_banco)-char_length(ltrim(\n");
	strcat(sqlcmd,"rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num)))+\n");
	strcat(sqlcmd,"replicate ('0',(select pgs_long_eje from MTCPGS01 h \n");
	strcat(sqlcmd," where h.pgs_rep_prefijo = a.eje_prefijo \n");
	strcat(sqlcmd," and h.pgs_rep_banco = a.gpo_banco)-char_length(ltrim(\n");
	strcat(sqlcmd,"rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num)))\n");
	strcat(sqlcmd,"+'9'+convert(char(1),(select c.eje_digit from MTCPLA01 c \n");
	strcat(sqlcmd," where c.eje_roll_over=9 and c.eje_prefijo=a.eje_prefijo \n");
	strcat(sqlcmd," and c.gpo_banco = a.gpo_banco and c.emp_num = a.emp_num \n"); 
	strcat(sqlcmd," and c.eje_num = a.eje_num)), \n"); 
	strcat(sqlcmd," isnull(c.eje_nombre, a.ths_nombre) nombre, \n"); 
	strcat(sqlcmd," isnull(ltrim(c.eje_calle+' '+c.eje_col), \n");
	strcat(sqlcmd,"ltrim(a.ths_direccion_1+' '+a.ths_direccion_2)) direccion,\n");
	strcat(sqlcmd," isnull(c.eje_pob,a.ths_direccion_3) pob, \n"); 
	strcat(sqlcmd," isnull(c.eje_cp,a.ths_codigo_postal) cp, \n"); 
	strcat(sqlcmd,"isnull(ltrim(rtrim(c.eje_tel_dom)), ltrim(rtrim(str(a.ths_tel_particular)))) tel_dom,\n");
	strcat(sqlcmd,"c.eje_fax fax, \n");
	strcat(sqlcmd," 'limcred'= \n"); /* cambio para hyperplex 31/07/03 */ 
	strcat(sqlcmd," case \n");
	strcat(sqlcmd," when c.eje_limcred = 0 then a.ths_limite_credito \n");
	strcat(sqlcmd," when c.eje_limcred = null then a.ths_limite_credito \n");
	strcat(sqlcmd," else c.eje_limcred \n");
	strcat(sqlcmd," end \n");
	strcat(sqlcmd,",\n"); 
	/*strcat(sqlcmd," isnull(c.eje_limcred,a.ths_limite_credito) limcred, \n");*/
	strcat(sqlcmd," convert(varchar(8), a.ths_inicio_credito_aamm) plas_ini, \n");
	strcat(sqlcmd," (select isnull(max(d.pla_vencimiento),99999999) from MTCPLA01 d \n"); 
	strcat(sqlcmd," where a.eje_prefijo = d.eje_prefijo \n");
	strcat(sqlcmd," and a.gpo_banco = d.gpo_banco and a.emp_num = d.emp_num \n"); 
	strcat(sqlcmd," and a.eje_num = d.eje_num) pla_vencimiento, \n");
	strcat(sqlcmd," isnull(str((a.ths_vencidos_pagos_por_mes1+\n");
	strcat(sqlcmd,"ths_vencidos_pagos_por_mes2+ths_vencidos_pagos_por_mes3+\n");
	strcat(sqlcmd,"ths_vencidos_pagos_por_mes4+ths_vencidos_pagos_por_mes5+\n");
	strcat(sqlcmd,"ths_vencidos_pagos_por_mes6)*10000,16), \n");
	strcat(sqlcmd,"'0000000000000000') pagos_atr, \n");
	strcat(sqlcmd,"padre = u.unit_id, eje_num_nom = isnull(rtrim(c.eje_num_nom),'')  \n");                     /*IERM*/
	strcat(sqlcmd, "from MTCTHS01 a, MTCEMP01 b, MTCEJE01 c, MTCUNI01 u \n");
	strcat(sqlcmd, " where ");
	
	if ( strcmp(ejePrefijo,"0") != 0 && strcmp(gpoBanco,"0") != 0 && strcmp(empNumero,"0") != 0 ){
		
		strcat(sqlcmd," a.eje_prefijo = \n");
		sprintf(sqlcmd, "%s %s ",sqlcmd,ejePrefijo);
		strcat(sqlcmd, "and  a.gpo_banco = \n");
		sprintf(sqlcmd, "%s %s ",sqlcmd,gpoBanco);

		if ( strcmp(empNumero,"0") != 0 ){

			strcat(sqlcmd, "and  a.emp_num = \n");
			sprintf(sqlcmd, "%s %s ",sqlcmd,empNumero);
		}

		strcat(sqlcmd, " and ");
	} 

	strcat(sqlcmd, " a.eje_prefijo = b.eje_prefijo \n");
	strcat(sqlcmd, "and a.gpo_banco = b.gpo_banco \n");
	strcat(sqlcmd, "and a.emp_num = b.emp_num \n");
	strcat(sqlcmd, "and b.emp_gen_CDF=1 \n");
	strcat(sqlcmd, "and a.eje_prefijo *= c.eje_prefijo \n");
	strcat(sqlcmd, "and a.gpo_banco *= c.gpo_banco \n");
	strcat(sqlcmd, "and a.emp_num *= c.emp_num \n");
	strcat(sqlcmd, "and a.eje_num *= c.eje_num \n");
	strcat(sqlcmd, "and a.eje_num > 0 \n");
	strcat(sqlcmd, "and b.eje_prefijo*=u.eje_prefijo \n"); 
	strcat(sqlcmd, "and b.gpo_banco*=u.gpo_banco \n");  
	strcat(sqlcmd, "and b.emp_num*=u.emp_num \n"); 
	strcat(sqlcmd, "and u.unit_parent_id=null \n");  
	strcat(sqlcmd, "and u.nivel_num=1 \n");  

	strcat(sqlcmd, "and ltrim(rtrim(SUBSTRING(c.eje_centro_c,1,8))) in (select isnull(ltrim(rtrim(z.unit_id)), ' ') \n");
	strcat(sqlcmd, "from MTCUNI01 z, MTCEMP01 y \n");
	strcat(sqlcmd, "where z.eje_prefijo = c.eje_prefijo \n");
	strcat(sqlcmd, "and z.gpo_banco   = c.gpo_banco \n");
	strcat(sqlcmd, "and z.emp_num     = c.emp_num \n");
	strcat(sqlcmd, "and z.eje_prefijo = y.eje_prefijo \n");
	strcat(sqlcmd, "and z.gpo_banco   = y.gpo_banco \n");
	strcat(sqlcmd, "and z.emp_num     = y.emp_num \n");
	strcat(sqlcmd, "and z.nivel_num   <> 99 \n");
	strcat(sqlcmd, "and y.emp_gen_CDF = 1) \n");

	strcat(sqlcmd," order by  a.eje_prefijo, a.gpo_banco, \n");
	strcat(sqlcmd," a.emp_num, a.eje_num, CtaCorp, \n");
	strcat(sqlcmd," eje_centro_c, accountNumber \n"); 

/*	printf("\n\n\n\tRegistro 4300 CTA: \n %s \n", sqlcmd ); */
	
	dbcmd(dbproc_cta, sqlcmd);

	if (dbsqlexec(dbproc_cta) == FAIL){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n");
		printf("No se pudo obtener informacion de para generar REG4300 %s  \n",sqlcmd);
		dbclose(dbproc_cta); 
		dbexit(); 
		exit(ERREXIT);
	}

	dbresults(dbproc_cta);
	
	if (dbrows(dbproc_cta) != SUCCEED){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n");
		printf("Error no se encontraron registros para procesar %s\n",sqlcmd);
		dbclose(dbproc_cta); 
		dbexit(); 
		exit(ERREXIT);
	}

	dbbind(dbproc_cta, 1, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)ctaEjePrefijo);
	dbbind(dbproc_cta, 2, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)ctaGpoBanco); 
	dbbind(dbproc_cta, 3, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)ctaEmpNum);
	dbbind(dbproc_cta, 4, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)ctaEjeNum);
	dbbind(dbproc_cta, 5, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_num_corp);
	dbbind(dbproc_cta, 6, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_reportsTo);
	dbbind(dbproc_cta, 7, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_num_cuenta); 
	dbbind(dbproc_cta, 8, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_nombre);
	dbbind(dbproc_cta, 9, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_direccion);
	dbbind(dbproc_cta, 10, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_pob); 
	dbbind(dbproc_cta, 11, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_cp); 
	dbbind(dbproc_cta, 12, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_tel_dom); 
	dbbind(dbproc_cta, 13, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_fax); 
	dbbind(dbproc_cta, 14, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_limcred); 
	dbbind(dbproc_cta, 15, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_plas_ini); 
	dbbind(dbproc_cta, 16, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_plas_fin); 
	/* Se adiciona esta sentencia para obtener past due balance */
	dbbind(dbproc_cta, 17, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_pagos_atr); 
	dbbind(dbproc_cta, 18, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)unitpadre); 
	dbbind(dbproc_cta, 19, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)eje_num_nom);
	/*ciclo hijo de datos del tarjetahabiente*/ 

	while (dbnextrow(dbproc_cta) != NO_MORE_ROWS){

/* JMC
		strcpy(recordidentifier,'\0');
		strcpy(issuerica,'\0');
		strcpy(issuernumberica,'\0');
		strcpy(corporationnumber,'\0');
		strcpy(reservedforinternaluse1,'\0');
		strcpy(reservedforinternaluse2,'\0');
		strcpy(reservedforinternaluse3,'\0');
		strcpy(reportstoorgpointnumber,'\0');
		strcpy(reportstofreeformattext,'\0');
		strcpy(accountnumber,'\0');
		strcpy(corporateproduct,'\0');
		strcpy(effectivedate,'\0');
		strcpy(expirationdate,'\0');
		strcpy(accountnameline1,'\0');
		strcpy(accountnameline2,'\0');
		strcpy(accountaddressline1,'\0');
		strcpy(accountaddressline2,'\0');
		strcpy(accountcity,'\0');
		strcpy(accountstateprovince,'\0');
		strcpy(accountcountry,'\0');
		strcpy(accountpostalcode,'\0');
		strcpy(accountphonenumber,'\0');
		strcpy(accountfaxnumber,'\0');
		strcpy(internalauditcode,'\0');
		strcpy(employeeid, '\0'); 
		strcpy(dailynumberlimitoftransactions,'\0');
		strcpy(singletransactiondollarlimit,'\0');
		strcpy(dailytransactiondollarlimit,'\0');
		strcpy(cyclenumberoftransactionslimit,'\0');
		strcpy(cycledollarlimit,'\0');
		strcpy(monthlynumlimitoftran,'\0');
		strcpy(monthlydollarlimit,'\0');
		strcpy(othernumberoftransactionslimit,'\0');
		strcpy(otherdollarlimit,'\0');
		strcpy(taxexemptindicator,'\0');
		strcpy(currencycode,'\0');
		strcpy(statementdate,'\0');
		strcpy(previousbalancesign,'\0');
		strcpy(previousbalance,'\0');
		strcpy(endingbalancesign,'\0');
		strcpy(endingbalance,'\0');
		strcpy(paymentduesign,'\0');
		strcpy(paymentduebalance,'\0');
		strcpy(creditlimitsign,'\0');
		strcpy(creditlimit,'\0');
		strcpy(pastdueamountsign,'\0');
		strcpy(pastduebalance,'\0');
		strcpy(chargeoffsign,'\0');
		strcpy(chargeoffamount,'\0');
		strcpy(disputedamountsign,'\0');
		strcpy(disputedamount,'\0');
		strcpy(numberpaymentspastdue,'\0');
		strcpy(highestdelinquencyperiod,'\0');
		strcpy(accountindisputeflag,'\0');
		strcpy(addressmaintenanceactioncode,'\0');
		strcpy(inputfilerecordnumber,'\0');
		strcpy(outgoingincomingerrorcode,'\0');
JMC */
                memset(recordidentifier,'\0', sizeof(recordidentifier));
                memset(issuerica,'\0', sizeof(issuerica));
                memset(issuernumberica,'\0', sizeof(issuernumberica));
                memset(corporationnumber,'\0', sizeof(corporationnumber));
                memset(reservedforinternaluse1,'\0', sizeof(reservedforinternaluse1));
                memset(reservedforinternaluse2,'\0', sizeof(reservedforinternaluse2));
                memset(reservedforinternaluse3,'\0', sizeof(reservedforinternaluse3));
                memset(reportstoorgpointnumber,'\0', sizeof(reportstoorgpointnumber));
                memset(reportstofreeformattext,'\0', sizeof(reportstofreeformattext));
                memset(accountnumber,'\0', sizeof(accountnumber));
                memset(corporateproduct,'\0', sizeof(corporateproduct));
                memset(effectivedate,'\0', sizeof(effectivedate));
                memset(expirationdate,'\0', sizeof(expirationdate));
                memset(accountnameline1,'\0', sizeof(accountnameline1));
                memset(accountnameline2,'\0', sizeof(accountnameline2));
                memset(accountaddressline1,'\0', sizeof(accountaddressline1));
                memset(accountaddressline2,'\0', sizeof(accountaddressline2));
                memset(accountcity,'\0', sizeof(accountcity));
                memset(accountstateprovince,'\0', sizeof(accountstateprovince));
                memset(accountcountry,'\0', sizeof(accountcountry));
                memset(accountpostalcode,'\0', sizeof(accountpostalcode));
                memset(accountphonenumber,'\0', sizeof(accountphonenumber));
                memset(accountfaxnumber,'\0', sizeof(accountfaxnumber));
                memset(internalauditcode,'\0', sizeof(internalauditcode));
                memset(employeeid, '\0', sizeof(employeeid));                                                 /*IERM*/
                memset(dailynumberlimitoftransactions,'\0', sizeof(dailynumberlimitoftransactions));
                memset(singletransactiondollarlimit,'\0', sizeof(singletransactiondollarlimit));
                memset(dailytransactiondollarlimit,'\0', sizeof(dailytransactiondollarlimit));
                memset(cyclenumberoftransactionslimit,'\0', sizeof(cyclenumberoftransactionslimit));
                memset(cycledollarlimit,'\0', sizeof(cycledollarlimit));
                memset(monthlynumlimitoftran,'\0', sizeof(monthlynumlimitoftran));
                memset(monthlydollarlimit,'\0', sizeof(monthlydollarlimit));
                memset(othernumberoftransactionslimit,'\0', sizeof(othernumberoftransactionslimit));
                memset(otherdollarlimit,'\0', sizeof(otherdollarlimit));
                memset(taxexemptindicator,'\0', sizeof(taxexemptindicator));
                memset(currencycode,'\0', sizeof(currencycode));
                memset(statementdate,'\0', sizeof(statementdate));
                memset(previousbalancesign,'\0', sizeof(previousbalancesign));
                memset(previousbalance,'\0', sizeof(previousbalance));
                memset(endingbalancesign,'\0', sizeof(endingbalancesign));
                memset(endingbalance,'\0', sizeof(endingbalance));
                memset(paymentduesign,'\0', sizeof(paymentduesign));
                memset(paymentduebalance,'\0', sizeof(paymentduebalance));
                memset(creditlimitsign,'\0', sizeof(creditlimitsign));
                memset(creditlimit,'\0', sizeof(creditlimit));
                memset(pastdueamountsign,'\0', sizeof(pastdueamountsign));
                memset(pastduebalance,'\0', sizeof(pastduebalance));
                memset(chargeoffsign,'\0', sizeof(chargeoffsign));
                memset(chargeoffamount,'\0', sizeof(chargeoffamount));
                memset(disputedamountsign,'\0', sizeof(disputedamountsign));
                memset(disputedamount,'\0', sizeof(disputedamount));
                memset(numberpaymentspastdue,'\0', sizeof(numberpaymentspastdue));
                memset(highestdelinquencyperiod,'\0', sizeof(highestdelinquencyperiod));
                memset(accountindisputeflag,'\0', sizeof(accountindisputeflag));
                memset(addressmaintenanceactioncode,'\0', sizeof(addressmaintenanceactioncode));
                memset(inputfilerecordnumber,'\0', sizeof(inputfilerecordnumber));
                memset(outgoingincomingerrorcode,'\0', sizeof(outgoingincomingerrorcode));

		graba=1;
		graba2=0;

		memset(cadenareg4300,'\0',sizeof(cadenareg4300));
		memset(cadenamtc4300,'\0',sizeof(cadenamtc4300));

		sprintf( recordidentifier, FRMA4, "4300" );
/*		sprintf( issuerica, FRMN11, issuerIca );*/
                sprintf( issuerica, "%011ld", atol(issuerIca) );
		sprintf( issuernumberica, FRMA11, issuerNumberIca );
		sprintf( reservedforinternaluse1, FRMA3, EMPTYSTR );
		sprintf( reservedforinternaluse2, FRMA17, EMPTYSTR );
		sprintf( reservedforinternaluse3, FRMA6, EMPTYSTR );
		/* strcpy(reportstoorgpointnumber,"                   "); */
		/* Se asigna para el manejo de jerarquias */
		sprintf(corporationnumber, FRMA19, eje_num_corp );

		// JMC if (strcmp(unitpadre,NULL) != 0){
		if ( unitpadre[0] !=  '\0'){

			// JMC if ( (strcmp(eje_reportsTo,"0") == 0) || (strcmp(eje_reportsTo,NULL) == 0) || (strcmp(eje_reportsTo," ") == 0) ){
			if ( (strcmp(eje_reportsTo,"0") == 0) || (eje_reportsTo[0] != '\0') || (strcmp(eje_reportsTo," ") == 0) ){

				sprintf( reportstoorgpointnumber, FRMA19, unitpadre);

/*				printf( "\n <%s> <%s> \n", eje_num_cuenta,eje_nombre );*/

			} 
			
			else{

				contador= 0;
				memset(cad_car,'\0',sizeof(cad_car));
	
				for (contador=0; contador <= strlen(eje_reportsTo); contador ++){ //30-06-2004 JAGG

					strncpy(caracter,&eje_reportsTo[contador],1);
					caracter[1]='\0';
	
					if ( (strcmp(caracter,"0") == 0) || (strcmp(caracter,"1") == 0) ||
							(strcmp(caracter,"2") == 0) || (strcmp(caracter,"3") == 0) ||
							(strcmp(caracter,"4") == 0) || (strcmp(caracter,"5") == 0) ||
							(strcmp(caracter,"6") == 0) || (strcmp(caracter,"7") == 0) ||
							(strcmp(caracter,"8") == 0) || (strcmp(caracter,"9") == 0) ){

	
						strcat(cad_car,caracter);
					}
				}
				
				sprintf(reportstoorgpointnumber, FRMA19, cad_car );
	
			}
		}

		else{

			sprintf( reportstoorgpointnumber, FRMA19, eje_num_corp );  /**********************  COMENTAR ESTA PARTE  *****/
		}

		sprintf( reportstofreeformattext, FRMA25, EMPTYSTR );
		sprintf( accountnumber, FRMA19, eje_num_cuenta );
		sprintf( corporateproduct, FRMA1, "B" );
		sprintf( effectivedate,"%s%s", eje_plas_ini, "01");       
		strcat( expirationdate,"  " );
		strncpy(expirationdate,&eje_plas_fin[4],2);
		expirationdate[2]='\0';
		strncat(expirationdate,eje_plas_fin,4);
		expirationdate[6]='\0';
		sprintf( accountnameline2, FRMA35, EMPTYSTR );
	
		if (strlen(eje_nombre)>35){

			strncpy(accountnameline1,eje_nombre,35);
			accountnameline1[35]='\0';
			strncpy(accountnameline2,&eje_nombre[35],strlen(eje_nombre)-35);
			sprintf(accountnameline2, FRMA35, accountnameline2);
		}

		else{

			sprintf( accountnameline1, FRMA35, eje_nombre );
		}

		sprintf( accountaddressline2, FRMA35, EMPTYSTR );
		
		if (strlen(eje_direccion)>35){

			strncpy(accountaddressline1,eje_direccion,35);
			accountaddressline1[35]='\0';
			strncpy(accountaddressline2,&eje_direccion[35],strlen(eje_direccion)-35);
			sprintf( accountaddressline2, FRMA35, accountaddressline2 );
		}

		else{

			sprintf( accountaddressline1, FRMA35, eje_direccion );
		}

		if (strlen(eje_pob) > 20){
			
			strncpy(accountcity,&eje_pob[0],20);
			accountcity[20]='\0';
		}

		else{

			sprintf( accountcity, FRMA20, eje_pob );  
		}

		sprintf( accountstateprovince, FRMA3, "MEX" );
		sprintf( accountcountry, FRMA3, "MEX" );
		sprintf( accountpostalcode, FRMA10 , eje_cp );
		sprintf( accountphonenumber, FRMA25, eje_tel_dom );
		sprintf( accountfaxnumber, FRMA25, eje_fax );
		sprintf( internalauditcode, FRMA75 , internalauditcode );

		sprintf( employeeid, FRMA20, eje_num_nom );                                          /*IERM*/
/*		sprintf( dailynumberlimitoftransactions, FRMN8, EMPTYSTR );
		sprintf( singletransactiondollarlimit, FRMN16, EMPTYSTR );
		sprintf( dailytransactiondollarlimit, FRMN16,  EMPTYSTR );
		sprintf( cyclenumberoftransactionslimit, FRMN8, EMPTYSTR );
		sprintf( cycledollarlimit, FRMN16, EMPTYSTR );
		sprintf( monthlynumlimitoftran, FRMN8, EMPTYSTR );
		sprintf( monthlydollarlimit, FRMN16, EMPTYSTR );
		sprintf( othernumberoftransactionslimit, FRMN8, EMPTYSTR );
		sprintf( otherdollarlimit, FRMN16, EMPTYSTR );*/

                sprintf( dailynumberlimitoftransactions, "%08ld", atol(EMPTYSTR) );
                sprintf( singletransactiondollarlimit,"%016ld", atol(EMPTYSTR) );
                sprintf( dailytransactiondollarlimit, "%016ld",  atol(EMPTYSTR) );
                sprintf( cyclenumberoftransactionslimit, "%08ld", atol(EMPTYSTR) );
                sprintf( cycledollarlimit, "%016ld", atol(EMPTYSTR) );
                sprintf( monthlynumlimitoftran, "%08ld", atol(EMPTYSTR) );
                sprintf( monthlydollarlimit, "%016ld", atol(EMPTYSTR) );
                sprintf( othernumberoftransactionslimit, "%08ld", atol(EMPTYSTR) );
                sprintf( otherdollarlimit, "%016ld", atol(EMPTYSTR) );
 
		sprintf( taxexemptindicator, FRMA1, "N");
		/* sprintf(currencycode,"%-3s",currencycode); */
		sprintf( currencycode, FRMA3, originalCurrencyCode); /* jrgd 09/04/2002 */
		sprintf( statementdate, FRMA8, fechaGenera );
		sprintf( previousbalancesign, FRMN1, "D");  
/*		sprintf( previousbalance, FRMN16, EMPTYSTR );*/
                sprintf( previousbalance, "%016ld", atol(EMPTYSTR) );
		sprintf( endingbalancesign, FRMA1, "D" );  
/*		sprintf( endingbalance, FRMN16, EMPTYSTR );*/
                sprintf( endingbalance, "%016ld", atol(EMPTYSTR) );
		sprintf( paymentduesign, FRMA1, "D");  
/*		sprintf( paymentduebalance, FRMN16, EMPTYSTR );*/
                sprintf( paymentduebalance, "%016ld", atol(EMPTYSTR) );
		sprintf( creditlimitsign, FRMA1, "C");  
/*		sprintf( creditlimit, FRMN16, EMPTYSTR );*/
                sprintf( creditlimit, "%016ld", atol(EMPTYSTR) );
		sprintf( pastdueamountsign, FRMA1, "D");  
/*		sprintf( pastduebalance, FRMN16, EMPTYSTR );*/
                sprintf( pastduebalance, "%016ld", atol(EMPTYSTR) );
		sprintf( chargeoffsign, FRMA1, "D");
/*		sprintf( chargeoffamount, FRMN16, EMPTYSTR );
		sprintf( disputedamount, FRMN16, EMPTYSTR );*/

                sprintf( chargeoffamount, "%016ld", atol(EMPTYSTR) );
                sprintf( disputedamount, "%016ld", atol(EMPTYSTR) );

		if (atol(disputedamount)>=0){

			sprintf( disputedamountsign, FRMA1, "D");
		}

		else{

			sprintf( disputedamountsign, FRMA1, "C");  
			// HP sprintf( disputedamount,"%ld'0'16d",atol(disputedamount)*-1);
			sprintf( disputedamount,"%016ld",atol(disputedamount)*-1);
		}

/*		sprintf(numberpaymentspastdue, FRMN3, EMPTYSTR );
		sprintf(highestdelinquencyperiod, FRMN2, EMPTYSTR );*/

                sprintf(numberpaymentspastdue, "%03ld", atol(EMPTYSTR) );
                sprintf(highestdelinquencyperiod, "%02ld", atol(EMPTYSTR) );

		sprintf(accountindisputeflag, FRMA1, EMPTYSTR );
/*		sprintf(inputfilerecordnumber, FRMN6, EMPTYSTR );
		sprintf(outgoingincomingerrorcode, FRMA6, EMPTYSTR );*/

                sprintf(inputfilerecordnumber, "%06ld", atol(EMPTYSTR) );
                sprintf(outgoingincomingerrorcode, "%06ld", atol(EMPTYSTR) );

		if (atol(eje_limcred)>=0){  /* se Saca del IF (strcmp(cta,mon) == 0) JAGG 06-07-2004 */
	                         //Por que es del query cta
			//strcat(eje_limcred,"0000");
/*			sprintf( creditlimit, FRMN16, eje_limcred );*/
                        sprintf( creditlimit, "%016ld", atol(eje_limcred) );
			sprintf( creditlimitsign, FRMA1, "D" );
		}

		else{

			strcpy(creditlimitsign,"C");  
			//HP sprintf( creditlimit, "%ld'0'16d", atol(eje_limcred)*-1 );
			sprintf( creditlimit, "%016ld", atol(eje_limcred)*-1 );
		}

		/*concatenamos nuestras llaves en cta, mon*/
		sprintf( cta, "%s%s%s%s", ctaEjePrefijo, ctaGpoBanco, ctaEmpNum, ctaEjeNum );
		sprintf( mon, "%s%s%s%s", monEjePrefijo, monGpoBanco, monEmpNum, monEjeNum );

	
		if (strcmp(cta,mon) == 0) {

			graba=0; 
	
			if (atol(eje_balance_ini)>=0){

				strcpy(previousbalancesign,"D");  
				//HP sprintf( previousbalance, "%ld'0'16d", atol( eje_balance_ini ));
				sprintf( previousbalance, "%016ld", atol( eje_balance_ini ));
			}

			else{

				sprintf( previousbalancesign, FRMA1, "C" );  
				//HP sprintf( previousbalance,"%ld'0'16d",atol( eje_balance_ini )*-1 );
				sprintf( previousbalance,"%016ld",atol( eje_balance_ini )*-1 );
			}

			if (atol(eje_balance_fin)>=0){

				sprintf( endingbalancesign, FRMA1, "D" );  
				//HP sprintf( endingbalance, "%ld'0'16d", atol( eje_balance_fin ));
				sprintf( endingbalance, "%016ld", atol( eje_balance_fin ));
			}
	
			else{

				sprintf( endingbalancesign, FRMA1, "C" );  
				//HP sprintf( endingbalance, "%ld'0'16d", atol( eje_balance_fin )*-1 );
				sprintf( endingbalance, "%016ld", atol( eje_balance_fin )*-1 );
			}

			if (atol(eje_bal_pagos_atr)>=0){

				sprintf( paymentduesign, FRMA1, "D" );  
				//HP sprintf( paymentduebalance, "%ld'0'16d", atol( eje_bal_pagos_atr ) );
				sprintf( paymentduebalance, "%016ld", atol( eje_bal_pagos_atr ) );
			}
	
			else{

				sprintf( paymentduesign, FRMA1, "C" );  
				//HP sprintf(paymentduebalance,"%ld'0'16d",atol(eje_bal_pagos_atr)*-1);
				sprintf(paymentduebalance,"%016ld",atol(eje_bal_pagos_atr)*-1);
			}

			if (atol(eje_pagos_atr)>=0){

				sprintf( pastdueamountsign, FRMA1, "D" );  
				//HP sprintf( pastduebalance, "%ld'0'16d", atol( eje_pagos_atr ));
				sprintf( pastduebalance, "%016ld", atol( eje_pagos_atr ));
			}

			else{

				sprintf( pastdueamountsign, FRMA1, "C" );  
				//HP sprintf(pastduebalance,"%ld'0'16d",atol(eje_pagos_atr)*-1);
				sprintf(pastduebalance,"%016ld",atol(eje_pagos_atr)*-1);
			}

			//HP sprintf( numberpaymentspastdue, "%d'0'3d", atoi( eje_retrazos ));
			sprintf( numberpaymentspastdue, "%03d", atoi( eje_retrazos ));

			dbnextrow( dbproc_mon );

			sprintf( mon, "%s%s%s%s", monEjePrefijo, monGpoBanco, monEmpNum, monEjeNum );
		} 


		/*armamos el registro formateado para comparar
		sin los campos de statementDate y addressmaintenanceactioncode*/

		sprintf(cadenareg4300,"%s\t",recordidentifier);                 
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,issuerica);        
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,issuernumberica);  
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,corporationnumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reservedforinternaluse1);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reservedforinternaluse2);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reservedforinternaluse3);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reportstoorgpointnumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reportstofreeformattext);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountnumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,corporateproduct);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,effectivedate);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,expirationdate);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountnameline1);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountnameline2);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountaddressline1);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountaddressline2);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountcity);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountstateprovince);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountcountry);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountpostalcode);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountphonenumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountfaxnumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,internalauditcode);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,employeeid);                                            /*IERM*/
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,dailynumberlimitoftransactions);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,singletransactiondollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,dailytransactiondollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,cyclenumberoftransactionslimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,cycledollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,monthlynumlimitoftran);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,monthlydollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,othernumberoftransactionslimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,otherdollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,taxexemptindicator);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,currencycode);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,"        "); /* fec. proc. */
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,previousbalancesign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,previousbalance);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,endingbalancesign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,endingbalance);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,paymentduesign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,paymentduebalance);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,creditlimitsign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,creditlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,pastdueamountsign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,pastduebalance);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,chargeoffsign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,chargeoffamount);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,disputedamountsign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,disputedamount);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,numberpaymentspastdue);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,highestdelinquencyperiod);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountindisputeflag);
		/** sprintf(cadenareg4300,"%s%s\t",cadenareg4300," "); *cod. mant 14-06-2004 JAGG ***/       
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,"000000");
		sprintf(cadenareg4300,"%s%s",cadenareg4300,outgoingincomingerrorcode);

		if ((strcmp(accountnumber,mtcaccountnumber)) == 0){

			sprintf(cadenamtc4300,"%s\t",mtcrecordidentifier);                 
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcissuerica);        
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcissuernumberica);  
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtccorporationnumber);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcreservedforinternaluse1);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcreservedforinternaluse2);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcreservedforinternaluse3);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcreportstoorgpointnumber);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcreportstofreeformattext);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountnumber);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtccorporateproduct);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtceffectivedate);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcexpirationdate);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountnameline1);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountnameline2);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountaddressline1);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountaddressline2);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountcity);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountstateprovince);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountcountry);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountpostalcode);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountphonenumber);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountfaxnumber);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcinternalauditcode);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcemployeeid);                                  /*IERM*/
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcdailynumberlimitoftransactions);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcsingletransactiondollarlimit);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcdailytransactiondollarlimit);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtccyclenumberoftransactionslimit);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtccycledollarlimit);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcmonthlynumlimitoftran);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcmonthlydollarlimit);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcothernumberoftransactionslimit);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcotherdollarlimit);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtctaxexemptindicator);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtccurrencycode);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,"        ");/*fec proc.*/
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcpreviousbalancesign);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcpreviousbalance);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcendingbalancesign);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcendingbalance);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcpaymentduesign);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcpaymentduebalance);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtccreditlimitsign);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtccreditlimit);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcpastdueamountsign);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcpastduebalance);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcchargeoffsign);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcchargeoffamount);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcdisputedamountsign);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcdisputedamount);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcnumberpaymentspastdue);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtchighestdelinquencyperiod);
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,mtcaccountindisputeflag);
			/**   sprintf(cadenamtc4300,"%s%c\t",cadenamtc4300," "); COD MANT 14-06-2004 JAGG **/
			sprintf(cadenamtc4300,"%s%s\t",cadenamtc4300,"000000");
			sprintf(cadenamtc4300,"%s%s",cadenamtc4300,mtcoutgoingincomingerrorcode);

	
			/*if (strcmp(cadenareg4300,cadenamtc4300) != 0){
				addressmaintenanceactioncode[0]='U';
				graba2 = 1;
			}

			else{   /*** 14-06-2004 JAGG  *****

				addressmaintenanceactioncode[0]='X';  /** Si son identicos los registros ponemos una X no es tomada en cuenta **
				graba2 = 2;
			}*/

			dbnextrow(dbproc_mtc);
		}
	
		else{

			addressmaintenanceactioncode[0]='A';
			graba2 = 1;
		}

	
	/* Se arma la cadena nuevamente incluyendo los campos de statementdate y addressmaintenanceactioncode para enviarlo al achivo reg4300.txt */

		cadenareg4300[0]='\0';
		sprintf(cadenareg4300,"%s\t",recordidentifier);                 
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,issuerica);        
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,issuernumberica);  
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,corporationnumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reservedforinternaluse1);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reservedforinternaluse2);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reservedforinternaluse3);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reportstoorgpointnumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,reportstofreeformattext);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountnumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,corporateproduct);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,effectivedate);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,expirationdate);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountnameline1);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountnameline2);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountaddressline1);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountaddressline2);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountcity);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountstateprovince);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountcountry);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountpostalcode);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountphonenumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountfaxnumber);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,internalauditcode);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,employeeid);                                          /*IERM*/
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,dailynumberlimitoftransactions);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,singletransactiondollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,dailytransactiondollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,cyclenumberoftransactionslimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,cycledollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,monthlynumlimitoftran);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,monthlydollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,othernumberoftransactionslimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,otherdollarlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,taxexemptindicator);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,currencycode);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,statementdate);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,previousbalancesign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,previousbalance);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,endingbalancesign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,endingbalance);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,paymentduesign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,paymentduebalance);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,creditlimitsign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,creditlimit);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,pastdueamountsign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,pastduebalance);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,chargeoffsign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,chargeoffamount);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,disputedamountsign);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,disputedamount);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,numberpaymentspastdue);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,highestdelinquencyperiod);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,accountindisputeflag);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,addressmaintenanceactioncode);
		sprintf(cadenareg4300,"%s%s\t",cadenareg4300,"000000");
		sprintf(cadenareg4300,"%s%s",cadenareg4300,outgoingincomingerrorcode);    

		if (graba2 == 1){

			/*  if (graba == 0 ) {  Comentado por que se requieren todas las  cuentas en el Archivo CDF */   
			if ((fprintf(reg4300,"%s\n",cadenareg4300)) == -1){

				printf("El registro no se grabo\n");                  
				exit(1);                                              
			}
			
			else{

				banderainserto=1;                                     
			}

			//        graba=1;
			/* }  Comentado por que se requieren todas las  cuentas en el Archivo CDF */ 
		}                                                      

	} /*fin del ciclo padre de ctas*/


	fclose(reg4300);

	if (banderainserto == 1){

		/* Se ejecuta el bulkcopyprocedure de reg4300.txt a la tabla REGT4300 */  
		sprintf(bulkcopy,"bcp M111..REG4300 in %s -c",nombrearchivo_temp);
		strcat(bulkcopy, " -U");
		strcat(bulkcopy, ge_user);
		strcat(bulkcopy, " -P");
		strcat(bulkcopy, ge_password);
		strcat(bulkcopy, " -S");
		strcat(bulkcopy, ge_server);
		system(bulkcopy);
	}

	sqlcmd[ 0 ] = '\0';
	strcpy( sqlcmd, "delete REG4300 from MTC4300 where REG4300.accountNumber = MTC4300.accountNumber ");
	strcat( sqlcmd, "and REG4300.reportsToOrgPointNumber = MTC4300.reportsToOrgPointNumber  ");
	strcat( sqlcmd, "and REG4300.corporationNumber = MTC4300.corporationNumber and REG4300.corporateProduct = MTC4300.corporateProduct ");
	strcat( sqlcmd, "and REG4300.accountNameLine1 = MTC4300.accountNameLine1 and REG4300.accountNameLine2 = MTC4300.accountNameLine2 ");
	strcat( sqlcmd, "and REG4300.accountAddressLine1 = MTC4300.accountAddressLine1 and REG4300.accountAddressLine2 = MTC4300.accountAddressLine2 ");
	strcat( sqlcmd, "and REG4300.accountCity = MTC4300.accountCity and REG4300.accountStateProvince = MTC4300.accountStateProvince ");
	strcat( sqlcmd, "and REG4300.accountCountry = MTC4300.accountCountry and REG4300.accountPostalCode = MTC4300.accountPostalCode ");
	strcat( sqlcmd, "and REG4300.accountPhoneNumber = MTC4300.accountPhoneNumber and REG4300.accountFaxNumber = MTC4300.accountFaxNumber ");
	strcat( sqlcmd, "and REG4300.employeeID = MTC4300.employeeID and REG4300.dailyNumberLimitofTransactions = MTC4300.dailyNumberLimitofTransactions ");
	strcat( sqlcmd, "and REG4300.singleTransactionDollarLimit = MTC4300.singleTransactionDollarLimit and REG4300.dailyTransactionDollarLimit = MTC4300.dailyTransactionDollarLimit ");
	strcat( sqlcmd, "and REG4300.cycleNumberofTransactionsLimit = MTC4300.cycleNumberofTransactionsLimit and REG4300.cycleDollarLimit = MTC4300.cycleDollarLimit ");
	strcat( sqlcmd, "and REG4300.monthlyNumLimitOfTran = MTC4300.monthlyNumLimitOfTran and REG4300.monthlyDollarLimit = MTC4300.monthlyDollarLimit ");
	strcat( sqlcmd, "and REG4300.otherNumberofTransactionsLimit = MTC4300.otherNumberofTransactionsLimit and REG4300.otherDollarLimit = MTC4300.otherDollarLimit ");
	strcat( sqlcmd, "and REG4300.previousBalance = MTC4300.previousBalance and REG4300.endingBalance = MTC4300.endingBalance ");
	strcat( sqlcmd, "and REG4300.paymentDueBalance = MTC4300.paymentDueBalance and REG4300.creditLimit = MTC4300.creditLimit ");
	strcat( sqlcmd, "and REG4300.pastDueBalance = MTC4300.pastDueBalance and REG4300.chargeOffAmount = MTC4300.chargeOffAmount ");
	strcat( sqlcmd, "and REG4300.disputedAmount = MTC4300.disputedAmount and REG4300.numberPaymentsPastDue = MTC4300.numberPaymentsPastDue ");
	strcat( sqlcmd, "and REG4300.highestDelinquencyPeriod = MTC4300.highestDelinquencyPeriod ");
	strcat( sqlcmd, "update REG4300 set addressMaintenanceActionCode = 'A' update REG4300 set REG4300.addressMaintenanceActionCode = 'U' ");
	strcat( sqlcmd, "from REG4300, MTC4300 where REG4300.accountNumber = MTC4300.accountNumber ");

	dbcancel( dbproc_mtc );

	dbcmd(dbproc_mtc,sqlcmd);

	if (dbsqlexec(dbproc_mtc) == FAIL){

		printf("Fecha proceso: %s\n", fechayhora);
		printf("Nombre archivo: %s\n", nombrearchivo);
		printf("Programa: r4300.c \n");
		printf("No se pudo obtener informacion de MTC430t %s\n",sqlcmd);
		dbclose(dbproc_mtc); 
		dbexit(); 
		exit(ERREXIT);
	}


	/*obtiene fecha y hora del proceso */
	time(&lcl_time); 
	today = localtime(&lcl_time); 
	strftime(fechayhora,20,"%Y%m%d %T",today); 
	printf("Hora de fin del proceso para generar el registro 4300 %s\n",fechayhora);
	dbexit();
	exit(0);

}


/*inicializamos  DB-Library. */

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
extern char sqlcmd[SQLBUFLEN];

if ((msgno != 5701) && (msgno != 5703))
{
if (severity == 16)                                                    
{                                                                    
printf("FechaProceso: %s\n", fechayhora);
printf("Nombre Archivo: %s\n", nombrearchivo);
printf("Nombre Programa: r4300.c \n");
printf("Error %ld, Nivel severidad %d, Estado %d\n", msgno, severity,msgstate);
printf("Mensaje error: \n%s\n", msgtext);
printf("Se ejecutaba el sql: \n%s\n", sqlcmd);
exit(1);
/*                                                                         
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
*/
}
}
return (0);
}

