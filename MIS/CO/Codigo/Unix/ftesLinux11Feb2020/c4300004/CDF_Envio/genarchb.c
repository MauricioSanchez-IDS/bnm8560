/*
** genarchcdf.c  01/09/2001 
** Elaborado por : Ing Jose Ramon Gonzalez Diaz  
** Este programa substrae la informacion para generar el archivo CDF.
** Este programa necesita tres parametros que son el fecha de generacion
** nombre del archivo a generar, tipo de proceso
**
** Historia:
** 1.-  26/feb/2001 Modificar los nombres de las tablas que se utilizan para 
** la consulta dela informacion para formar cada registro.
** 2.- 26/feb/2001 Modificar el path para la lectura de las cabeceras.
** 3.- 02/mar/2001 Modificar el enque momento se estan contado los registros 
** 4.- 05/mar/2001 Modificaciones a los accesos a las tablas para 
** optimizar el proceso de generacion del archivo cdf.
** 5.- 12/mar/2001 Modificaciones para subir a memoria todas las consultas y
** barrer los set de datos desde memoria y procesar la informacion, esta 
** accion permitira el ahorro de tiempo en la generacion del archivo cdf. 
** 6./ 31 de julio de 2003: Modificaciones para Modularizar el archivo 
** en tres los cuales son genarchb.c (PRINCIPAL), genconsultas (QUERYS)
** y genvar.h (VARIABLES).
*********** Modificaciones por: JAIME RAMIREZ NI@O 
** 7.- 07 de agosto de 2003: Modificaciones en el proceso para armar el
** archivo CDF,estas se utilizaran para elmanejo de las jerarquias por
** unidades jrgd.
*/

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include "sybdbex.h"
#include <time.h> 
#include "genconsultas.h"
#include "genvar.h"

main(argc, argv)
int argc; /* numero de parametros enviados al programa */
char *argv[]; /* toma los parametros enviados al programa */
{
			/* Se define un apuntador para manejo del archivo */ 
			FILE *archcdf;
			char corporativo4100[20];
			char orgpointnum4100[20];
			char corporativo4200[20];
			char report4200[20];
			char corporativo4300[20];
			char cta4300[20];
			char report4300[20];

			DBPROCESS *dbproc1000; /* Conexion con SQL Server para consultas reg 1000*/
			DBPROCESS *dbproc3000; /* Conexion con SQL Server para consultas reg 3000*/
			DBPROCESS *dbproc4000; /* Conexion con SQL Server para consultas reg 4000*/
			DBPROCESS *dbproc4100; /* Conexion con SQL Server para consultas reg 4100*/
			DBPROCESS *dbproc4100bis; /* Conexion con SQL Server para consultas reg 4100*/
			DBPROCESS *dbproc4200; /* Conexion con SQL Server para consultas reg 4200*/
			DBPROCESS *dbproc4300; /* Conexion con SQL Server para consultas reg 4300*/
			DBPROCESS *dbproc5000; /* Conexion con SQL Server para consultas reg 5000*/
			DBPROCESS *dbproc5000bis; /* Conexion con SQL Server para consultas reg 5000*/
			DBPROCESS *dbproc9999; /* Conexion con SQL Server para consultas reg 9999*/

			LOGINREC *login; /* Informacion del Login */

			/* variables globales para el manejo de los argumentos de fecha proceso y nombre del archivo a generar  */    
			extern char fechayhora[20];                             
			extern char nombrearchivo[60];                          
			extern char sqlcmd[3000];                               
			time_t lcl_time;  
			struct tm *today; 

			/*obtiene fecha y hora del proceso */                                         
			time(&lcl_time);                                                              
			today = localtime(&lcl_time);                                                 
			strftime(fechayhora,20,"%Y%m%d %T",today);                                    
			/* variables globales para el manejo de los argumentos nombre del archivo CDF a generar */  
			strcpy(nombrearchivo,argv[2]);
			/* Inicializa contador de registros */
			contador = 0;
			fflush(stdout);
			/* Initialize DB-Library. */
			if (dbinit() == FAIL)
			{
					/* Registro del error en el archivo log */
					printf("Fecha proceso:%s\n", fechayhora);
					printf("Nombre archivo: %s\n", nombrearchivo);
					printf("Programa: genarchb.c \n");
					printf("Error: No se inicializaron las dblibrary de C en el programa genarchb.c");
					exit(1);
			}

                        dbsetversion(DBVERSION_100);

			/*obtencion de los datos del ambiente*/
			sprintf(ge_user,"%s",getenv("GE_USER"));
			sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
			sprintf(ge_server,"%s",getenv("GE_SERVER"));
			sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));
			sprintf(ge_dbase,"%s",getenv("GE_DBASE"));
			sprintf(archivo_direccion,"%s",getenv("DIR_TEMP"));
			if ( ( (strlen(ge_user) == 0) || (strlen(ge_password) == 0) ||(strlen(ge_server) == 0) || (strlen(ge_hostname) == 0) ||
			(strlen(ge_dbase) == 0)  || (strlen(archivo_direccion) == 0) ) )
			{
					printf("Fecha proceso: %s\n", fechayhora);
					printf("Nombre archivo: %s\n", nombrearchivo);
					printf("Programa: genarchb.c \n");
					printf("Error: debe verificar las variables de ambiente\n");
					exit(1);
			}
			/* checa que se hayan pasado los parametros correspondientes*/
			if ((argc > TOTALPARAMETROS) || (argc < TOTALPARAMETROS))
			{
					printf("Programa: genarchb.c \n");
					printf("El numero de argumentos no son validos para el programa genarchb.c\n");
					exit(1);
			}
			else
			{
					/* Se indica el nombre el archivo a generar y  se abre */
					strcat(archivo_direccion,"/");
					strcat(archivo_direccion,nombrearchivo);
					strcpy(banderasigue,argv[3]);
					archcdf = fopen(archivo_direccion, "w");
					if (archcdf == NULL)
					{
							printf("No se pudo abrir el archivo de trabajo\n");   
							exit(1);
					}
			}
			/* Toma una  estructura LOGINREC y la llena con lo  necesario tomando la informacion del login.	*/
			login = dblogin();
			DBSETLUSER(login, ge_user);
			DBSETLPWD(login, ge_password);
			DBSETLAPP(login, ge_hostname);
			DBSETLHOST(login, ge_hostname);
                        DBSETLCHARSET(login,"roman8");
			DBSETLENCRYPT(login, TRUE); 
			/* Toma una estructura DBPROCESS para comunicarse c/ SQL Server.  Un nulo en server name utiliza por default 
			     servidor especificado por DSQUERY.	*/
			dbproc1000 = dbopen(login, ge_server);
			dbproc3000 = dbopen(login, ge_server);
			dbproc4000 = dbopen(login, ge_server);
			dbproc4100 = dbopen(login, ge_server);
			dbproc4100bis = dbopen(login, ge_server);
			dbproc4200 = dbopen(login, ge_server);
			dbproc4300 = dbopen(login, ge_server);
			dbproc5000 = dbopen(login, ge_server);
			dbproc5000bis = dbopen(login, ge_server);
			dbproc9999 = dbopen(login, ge_server);
			dbuse(dbproc1000,ge_dbase);
			dbuse(dbproc3000,ge_dbase);
			dbuse(dbproc4000,ge_dbase);
			dbuse(dbproc4100,ge_dbase);
			dbuse(dbproc4100bis,ge_dbase);
			dbuse(dbproc4200,ge_dbase);
			dbuse(dbproc4300,ge_dbase);
			dbuse(dbproc5000,ge_dbase);
			dbuse(dbproc5000bis,ge_dbase);
			dbuse(dbproc9999,ge_dbase);
			/**********************   SE Habilita el BUffer para Poder Usar dbfirstrow   10-06-2004 JAGG  *********/
			dbsetopt(dbproc4300 ,DBBUFFER, "100000", -1); 
			dbsetopt(dbproc5000bis ,DBBUFFER, "100000", -1); 
			/* Inicia proceso para la generacion del archivo CDF */ 
			/* Se limpian los dbproccess */
			dbcancel(dbproc1000);
			dbcancel(dbproc3000);
			dbcancel(dbproc4000);
			dbcancel(dbproc4100);  
			dbcancel(dbproc4100bis);  
			dbcancel(dbproc4200);  
			dbcancel(dbproc4300);  
			dbcancel(dbproc5000);  
			dbcancel(dbproc5000bis);
			dbcancel(dbproc9999);  
			printf("Hora de inicio del proceso para generar el archivo CDF \n");   
			system("date \"+%I:%M:%S %p\"\n");                                       
			printf("\n Obtencion Informacion para generar el archivo CDF \n\n");
			printf("\n Espere un momento procesando informacion. \n");
			/**************************************************************************/ 
			/*  PROCESO REGISTRO 1000  */
			contador = contador + 1;
			sprintf(contadorstr,"%d",contador);
			sprintf(contadorstrpaso, "%06s", contadorstr);
			strcpy(query, DevQry(10));
			dbcmd(dbproc1000, query); /*QUERY PARA EL REGISTRO 1000*/
			dbsqlexec(dbproc1000);
			/* printf("\nREGISTRO 1000\n"); */
			while ((result_code = dbresults(dbproc1000)) != NO_MORE_RESULTS)
			{
					if ((dbrows(dbproc1000) != 0) || (result_code == SUCCEED))
					{
							/*dbbind(dbproc1000, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)largoreg1000);*/
								dbbind(dbproc1000, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid1000);
								dbbind(dbproc1000, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero1000);
								dbbind(dbproc1000, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco1000);
								dbbind(dbproc1000, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse11000);
								dbbind(dbproc1000, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse21000);
								dbbind(dbproc1000, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse31000);
								dbbind(dbproc1000, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse41000);
								dbbind(dbproc1000, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *)rejectionlevel1000);
								dbbind(dbproc1000, 9, STRINGBIND, (DBINT)0, (BYTE DBFAR *)providingfromdate1000);
								dbbind(dbproc1000, 10, STRINGBIND, (DBINT)0, (BYTE DBFAR *)providingtodate1000);
								dbbind(dbproc1000, 11, STRINGBIND, (DBINT)0, (BYTE DBFAR *)runmodeindicator1000);
								dbbind(dbproc1000, 12, STRINGBIND, (DBINT)0, (BYTE DBFAR *)filereferencenumber1000);
								dbbind(dbproc1000, 13, STRINGBIND, (DBINT)0, (BYTE DBFAR *)custumerprocessornumber1000);
								dbbind(dbproc1000, 14, STRINGBIND, (DBINT)0, (BYTE DBFAR *)custumerprocessorname1000);
								dbbind(dbproc1000, 15, STRINGBIND, (DBINT)0, (BYTE DBFAR *)cdfversionnumber1000);
								dbbind(dbproc1000, 16, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outgoingincomingerrorcode1000);
								while (dbnextrow(dbproc1000) != NO_MORE_ROWS)
								{
										cadenareg1000[0]='\0';
										/*strcat(cadenareg1000,largoreg1000);*/
										strcat(cadenareg1000,recid1000);
										strcat(cadenareg1000,icanumero1000);
										strcat(cadenareg1000,icanumbanco1000);
										strcat(cadenareg1000,reservedforinternaluse11000);
										strcat(cadenareg1000,reservedforinternaluse21000);
										strcat(cadenareg1000,reservedforinternaluse31000);
										strcat(cadenareg1000,reservedforinternaluse41000);
										strcat(cadenareg1000,rejectionlevel1000);
										strcat(cadenareg1000,providingfromdate1000);
										strcat(cadenareg1000,providingtodate1000);
										strcat(cadenareg1000,runmodeindicator1000);
										strcat(cadenareg1000,filereferencenumber1000);
										strcat(cadenareg1000,custumerprocessornumber1000);
										strcat(cadenareg1000,custumerprocessorname1000);
										strcat(cadenareg1000,cdfversionnumber1000);
										strcat(cadenareg1000,contadorstrpaso);
										strcat(cadenareg1000,outgoingincomingerrorcode1000);
										/* Graba el registro en el archivo */
										strcpy(buf1000,cadenareg1000);

										if ((fprintf(archcdf,"%s\n",buf1000)) == -1)
										{
												printf("El registro no se grabo\n");
												exit(1);
										} 
										else 
										{    
												contador = contador + 1;  
										}
							}
					}
			} /* fin proceso 1000 */
			/**************************************************************************/ 
			/* PROCESO REGISTRO 3000 */
			/* printf("\nREGISTRO 3000\n"); */
			strcpy(query, DevQry(30));
			dbcmd(dbproc3000, query); /*QUERY PARA EL REGISTRO 3000*/
			dbsqlexec(dbproc3000);
			while ((result_code = dbresults(dbproc3000)) != NO_MORE_RESULTS)
			{
					if ((dbrows(dbproc3000) != 0) || (result_code == SUCCEED))
					{
							/*dbbind(dbproc3000, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)largoreg3000);*/
							dbbind(dbproc3000, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid3000);
							dbbind(dbproc3000, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero3000);
							dbbind(dbproc3000, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco3000);
							dbbind(dbproc3000, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse13000);
							dbbind(dbproc3000, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse23000);
							dbbind(dbproc3000, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse33000);
							dbbind(dbproc3000, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse43000);
							dbbind(dbproc3000, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *)issuernameline13000);
							dbbind(dbproc3000, 9, STRINGBIND, (DBINT)0, (BYTE DBFAR *)issuernameline23000);
							dbbind(dbproc3000, 10, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressline13000);
							dbbind(dbproc3000, 11, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressline23000);
							dbbind(dbproc3000, 12, STRINGBIND, (DBINT)0, (BYTE DBFAR *)city3000);
							dbbind(dbproc3000, 13, STRINGBIND, (DBINT)0, (BYTE DBFAR *)stateprovince3000);
							dbbind(dbproc3000, 14, STRINGBIND, (DBINT)0, (BYTE DBFAR *)country3000);
							dbbind(dbproc3000, 15, STRINGBIND, (DBINT)0, (BYTE DBFAR *)postalcode3000);
							dbbind(dbproc3000, 16, STRINGBIND, (DBINT)0, (BYTE DBFAR *)currency3000);
							/*dbbind(dbproc3000, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)largoreg3000_2);*/
							dbbind(dbproc3000, 17, STRINGBIND, (DBINT)0, (BYTE DBFAR *)contactperson3000);
							dbbind(dbproc3000, 18, STRINGBIND, (DBINT)0, (BYTE DBFAR *)phonenumber3000);
							dbbind(dbproc3000, 19, STRINGBIND, (DBINT)0, (BYTE DBFAR *)faxnumber3000);
							dbbind(dbproc3000, 20, STRINGBIND, (DBINT)0, (BYTE DBFAR *)emailaddress3000);
							dbbind(dbproc3000, 21, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressmaintenanceaction3000);
							dbbind(dbproc3000, 22, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outgoingincomingerrorcode3000);
							while (dbnextrow(dbproc3000) != NO_MORE_ROWS)
							{
									cadenareg3000[0]='\0';
									sprintf(contadorstr,"%d",contador);
									sprintf(contadorstrpaso, "%06s", contadorstr);
									/*strcat(cadenareg3000,largoreg3000);*/
									strcat(cadenareg3000,recid3000);
									strcat(cadenareg3000,icanumero3000);
									strcat(cadenareg3000,icanumbanco3000);
									strcat(cadenareg3000,reservedforinternaluse13000);
									strcat(cadenareg3000,reservedforinternaluse23000);
									strcat(cadenareg3000,reservedforinternaluse33000);
									strcat(cadenareg3000,reservedforinternaluse43000);
									strcat(cadenareg3000,issuernameline13000);
									strcat(cadenareg3000,issuernameline23000);
									strcat(cadenareg3000,addressline13000);
									strcat(cadenareg3000,addressline23000);
									strcat(cadenareg3000,city3000);
									strcat(cadenareg3000,stateprovince3000);
									strcat(cadenareg3000,country3000);
									strcat(cadenareg3000,postalcode3000);
									strcat(cadenareg3000,currency3000);
									/*strcat(cadenareg3000,largoreg3000_2);*/
									strcat(cadenareg3000,contactperson3000);
									strcat(cadenareg3000,phonenumber3000);
									strcat(cadenareg3000,faxnumber3000);
									strcat(cadenareg3000,emailaddress3000);
									strcat(cadenareg3000,addressmaintenanceaction3000);
									strcat(cadenareg3000,contadorstrpaso);
									strcat(cadenareg3000,outgoingincomingerrorcode3000);
									/* Graba el registro en el archivo */
									strcpy(buf3000,cadenareg3000);
									
									if ((fprintf(archcdf,"%s\n",buf3000)) == -1)
									{
											printf("El registro no se grabo\n");
											exit(1);
									} 
									else 
									{
											contador = contador + 1;
									}   
							}
					}
					else 
					{
									printf("No hay Registro 3000 \n");
					}
			} /* fin proceso 3000 */
			/**************************************************************************/ 
			/* consulta a la tabla REG4100 */
			strcpy(query, DevQry(41));
			dbcmd(dbproc4100bis, query); /*QUERY PARA EL REGISTRO 4100*/
			dbsqlexec(dbproc4100bis);
			if ((result_code = dbresults(dbproc4100bis)) != NO_MORE_RESULTS)
			{
					if ((dbrows(dbproc4100bis) != 0) || (result_code == SUCCEED))
					{
							entrareg4100 = 1;
							/*dbbind(dbproc4100bis,  1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4100_1);*/
							dbbind(dbproc4100bis, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid4100);
							dbbind(dbproc4100bis, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero4100);
							dbbind(dbproc4100bis, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco4100);
							dbbind(dbproc4100bis, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)corporationnumber4100);
							/*dbbind(dbproc4100bis, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4100_2);*/
							dbbind(dbproc4100bis, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse14100);
							dbbind(dbproc4100bis, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse24100);
							dbbind(dbproc4100bis, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse34100);
							dbbind(dbproc4100bis, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *)organizationpointnumber4100);
							/*dbbind(dbproc4100bis, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4100_3);*/
							dbbind(dbproc4100bis, 9, STRINGBIND, (DBINT)0, (BYTE DBFAR *)freeformattext4100);
							dbbind(dbproc4100bis, 10, STRINGBIND, (DBINT)0, (BYTE DBFAR *)organizationpointnameline14100);
							dbbind(dbproc4100bis, 11, STRINGBIND, (DBINT)0, (BYTE DBFAR *)organizationpointnameline24100);
							dbbind(dbproc4100bis, 12, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressline14100);
							dbbind(dbproc4100bis, 13, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressline24100);
							dbbind(dbproc4100bis, 14, STRINGBIND, (DBINT)0, (BYTE DBFAR *)city4100);
							dbbind(dbproc4100bis, 15, STRINGBIND, (DBINT)0, (BYTE DBFAR *)stateprovince4100);
							dbbind(dbproc4100bis, 16, STRINGBIND, (DBINT)0, (BYTE DBFAR *)country4100);
							dbbind(dbproc4100bis, 17, STRINGBIND, (DBINT)0, (BYTE DBFAR *)postalcode4100);
							dbbind(dbproc4100bis, 18, STRINGBIND, (DBINT)0, (BYTE DBFAR *)currencycode4100);
							/*dbbind(dbproc4100bis, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4100_4);*/
							dbbind(dbproc4100bis, 19, STRINGBIND, (DBINT)0, (BYTE DBFAR *)contactperson4100);
							dbbind(dbproc4100bis, 20, STRINGBIND, (DBINT)0, (BYTE DBFAR *)phonenumber4100);
							dbbind(dbproc4100bis, 21, STRINGBIND, (DBINT)0, (BYTE DBFAR *)faxnumber4100);
							dbbind(dbproc4100bis, 22, STRINGBIND, (DBINT)0, (BYTE DBFAR *)emailaddress4100);
							dbbind(dbproc4100bis, 23, STRINGBIND, (DBINT)0, (BYTE DBFAR *)budgetlimit4100);
							dbbind(dbproc4100bis, 24, STRINGBIND, (DBINT)0, (BYTE DBFAR *)totalaccounts4100);
							dbbind(dbproc4100bis, 25, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountspastdue4100);
							dbbind(dbproc4100bis, 26, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountswithdispute4100);
							dbbind(dbproc4100bis, 27, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberofcards4100);
							dbbind(dbproc4100bis, 28, STRINGBIND, (DBINT)0, (BYTE DBFAR *)chargeoffsign4100);
							dbbind(dbproc4100bis, 29, STRINGBIND, (DBINT)0, (BYTE DBFAR *)chargeoffamount4100);
							dbbind(dbproc4100bis, 30, STRINGBIND, (DBINT)0, (BYTE DBFAR *)pastdueamountsign4100);
							dbbind(dbproc4100bis, 31, STRINGBIND, (DBINT)0, (BYTE DBFAR *)pastdueamount4100);
							dbbind(dbproc4100bis, 32, STRINGBIND, (DBINT)0, (BYTE DBFAR *)disputeamountsign4100);
							dbbind(dbproc4100bis, 33, STRINGBIND, (DBINT)0, (BYTE DBFAR *)disputeamount4100);
							dbbind(dbproc4100bis, 34, STRINGBIND, (DBINT)0, (BYTE DBFAR *)creditlimitsign4100);
							/*dbbind(dbproc4100bis, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4100_5);*/
							dbbind(dbproc4100bis, 35, STRINGBIND, (DBINT)0, (BYTE DBFAR *)creditlimit4100);
							dbbind(dbproc4100bis, 36, STRINGBIND, (DBINT)0, (BYTE DBFAR *)paymentduesign4100);
							dbbind(dbproc4100bis, 37, STRINGBIND, (DBINT)0, (BYTE DBFAR *)paymentdue4100);
							dbbind(dbproc4100bis, 38, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outstandingbalancesign4100);
							dbbind(dbproc4100bis, 39, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outstandingbalance4100);
							dbbind(dbproc4100bis, 40, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberofdebits4100);
							dbbind(dbproc4100bis, 41, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberofcredits4100);
							dbbind(dbproc4100bis, 42, STRINGBIND, (DBINT)0, (BYTE DBFAR *)amountofdebits4100);
							dbbind(dbproc4100bis, 43, STRINGBIND, (DBINT)0, (BYTE DBFAR *)amountofcredits4100);
							dbbind(dbproc4100bis, 44, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberaccountsoverlimit4100);
							dbbind(dbproc4100bis, 45, STRINGBIND, (DBINT)0, (BYTE DBFAR *)portfoliodate4100);
							dbbind(dbproc4100bis, 46, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressmaintenanceaction4100);
							dbbind(dbproc4100bis, 47, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outgoing4100);
							seguir4100=dbnextrow(dbproc4100bis); 
					}
					else
					{
							printf("No hay regsitros a procesar en la tabla REG4100\n");
					}
			}
			/****************************************************************************/                     
			/* consulta a la tabla reg4200 */
			strcpy(query, DevQry(42));
			dbcmd(dbproc4200, query); /*QUERY PARA EL REGISTRO 4200*/
			dbsqlexec(dbproc4200);
			if ((result_code = dbresults(dbproc4200)) != NO_MORE_RESULTS)
			{
					if ((dbrows(dbproc4200) != 0) || (result_code == SUCCEED))
					{
							entrareg4200=1;
							/*dbbind(dbproc4200, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *) campo4200_1);*/
							dbbind(dbproc4200, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid4200);
							dbbind(dbproc4200, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero4200);
							dbbind(dbproc4200, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco4200);
							dbbind(dbproc4200, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)corporationnumber4200);
							dbbind(dbproc4200, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse14200);
							dbbind(dbproc4200, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse24200);
							dbbind(dbproc4200, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse34200);
							dbbind(dbproc4200, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *) organizationPointNumber4200);
							/*dbbind(dbproc4200, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *) campo4200_2);*/
							dbbind(dbproc4200, 9, STRINGBIND, (DBINT)0, (BYTE DBFAR *)freeformattext4200);
							dbbind(dbproc4200, 10, STRINGBIND, (DBINT)0, (BYTE DBFAR *) reportsTo4200);
							dbbind(dbproc4200, 11, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reportstofreeformattext4200);
							dbbind(dbproc4200, 12, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse44200);
							dbbind(dbproc4200, 13, STRINGBIND, (DBINT)0, (BYTE DBFAR *)organizationhierarchymainact4200);
							dbbind(dbproc4200, 14, STRINGBIND, (DBINT)0, (BYTE DBFAR *) outgoingIncomingErrorCode4200);
							seguir4200=dbnextrow(dbproc4200);  
					}
					else
					{
							printf("No hay regsitros a procesar en la tabla REG4200\n");
					}
			}
			/**************************************************************************/ 
			/* consulta a la tabla reg4300 */
			query[0]='\0'; 
			strcpy(query, DevQry(43));
			dbcmd(dbproc4300, query); /*QUERY PARA EL REGISTRO 4300*/
			entrareg4300 = 0;
			renglon4300= 0;
			dbsqlexec(dbproc4300);
			if ((result_code = dbresults(dbproc4300)) != NO_MORE_RESULTS)
			{
					if ((dbrows(dbproc4300) != 0) || (result_code == SUCCEED))
					{
							entrareg4300 = 1;
							/*dbbind(dbproc4300,  1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4300_1);*/
							dbbind(dbproc4300, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid4300);
							dbbind(dbproc4300, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero4300);
							dbbind(dbproc4300, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco4300);
							dbbind(dbproc4300, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)corporationnumber4300);
							/*dbbind(dbproc4300,  3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4300_2);*/
							dbbind(dbproc4300, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse14300);
							dbbind(dbproc4300, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse24300);
							dbbind(dbproc4300, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse34300);
							dbbind(dbproc4300, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reportstoorgpointnumber4300);
							dbbind(dbproc4300, 9, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reportstofreeformattext4300);
							dbbind(dbproc4300, 10, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountnumber4300);
							/*dbbind(dbproc4300,  7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4300_3);*/
							dbbind(dbproc4300, 11, STRINGBIND, (DBINT)0, (BYTE DBFAR *)corporateproduct4300);
							dbbind(dbproc4300, 12, STRINGBIND, (DBINT)0, (BYTE DBFAR *)effectivedate4300);
							dbbind(dbproc4300, 13, STRINGBIND, (DBINT)0, (BYTE DBFAR *)expirationdate4300);
							dbbind(dbproc4300, 14, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountnameline14300);
							dbbind(dbproc4300, 15, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountnameline24300);
							dbbind(dbproc4300, 16, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountaddressline14300);
							dbbind(dbproc4300, 17, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountaddressline24300);
							dbbind(dbproc4300, 18, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountcity4300);
							dbbind(dbproc4300, 19, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountstateprovince4300);
							dbbind(dbproc4300, 20, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountcountry4300);
							dbbind(dbproc4300, 21, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountpostalcode4300);
							dbbind(dbproc4300, 22, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountphonenumber4300);
							dbbind(dbproc4300, 23, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountfaxnumber4300);
							/*dbbind(dbproc4300,  8, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4300_4);*/
							dbbind(dbproc4300, 24, STRINGBIND, (DBINT)0, (BYTE DBFAR *)internalauditcode4300);
							dbbind(dbproc4300, 25, STRINGBIND, (DBINT)0, (BYTE DBFAR *)employeeid4300);
							dbbind(dbproc4300, 26, STRINGBIND, (DBINT)0, (BYTE DBFAR *)dailynumberlimitoftransactions4300);
							dbbind(dbproc4300, 27, STRINGBIND, (DBINT)0, (BYTE DBFAR *)singletransactiondollarlimit4300);
							dbbind(dbproc4300, 28, STRINGBIND, (DBINT)0, (BYTE DBFAR *)dailytransactiondollarlimit4300);
							dbbind(dbproc4300, 29, STRINGBIND, (DBINT)0, (BYTE DBFAR *)cyclenumberoftransactionlimit4300);
							dbbind(dbproc4300, 30, STRINGBIND, (DBINT)0, (BYTE DBFAR *)cycledollarlimit4300);
							dbbind(dbproc4300, 31, STRINGBIND, (DBINT)0, (BYTE DBFAR *)monthlynumlimitoftran4300);
							dbbind(dbproc4300, 32, STRINGBIND, (DBINT)0, (BYTE DBFAR *)monthlydollarlimit4300);
							dbbind(dbproc4300, 33, STRINGBIND, (DBINT)0, (BYTE DBFAR *)othernumberoftransactionlimit4300);
							dbbind(dbproc4300, 34, STRINGBIND, (DBINT)0, (BYTE DBFAR *)otherdollarlimit4300);
							dbbind(dbproc4300, 35, STRINGBIND, (DBINT)0, (BYTE DBFAR *)taxexemptindicator4300);
							dbbind(dbproc4300, 36, STRINGBIND, (DBINT)0, (BYTE DBFAR *)currencycode4300);
							dbbind(dbproc4300, 37, STRINGBIND, (DBINT)0, (BYTE DBFAR *)statementdate4300);
							dbbind(dbproc4300, 38, STRINGBIND, (DBINT)0, (BYTE DBFAR *)previousbalancesign4300);
							dbbind(dbproc4300, 39, STRINGBIND, (DBINT)0, (BYTE DBFAR *)previousbalance4300);
							dbbind(dbproc4300, 40, STRINGBIND, (DBINT)0, (BYTE DBFAR *)endingbalancesign4300);
							dbbind(dbproc4300, 41, STRINGBIND, (DBINT)0, (BYTE DBFAR *)endingbalance4300);
							dbbind(dbproc4300, 42, STRINGBIND, (DBINT)0, (BYTE DBFAR *)paymentduesign4300);
							dbbind(dbproc4300, 43, STRINGBIND, (DBINT)0, (BYTE DBFAR *)paymentduebalance4300);
							/*dbbind(dbproc4300,  9, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4300_5);*/
							dbbind(dbproc4300, 44, STRINGBIND, (DBINT)0, (BYTE DBFAR *)creditlimitsign4300);
							dbbind(dbproc4300, 45, STRINGBIND, (DBINT)0, (BYTE DBFAR *)creditlimit4300);
							dbbind(dbproc4300, 46, STRINGBIND, (DBINT)0, (BYTE DBFAR *)pastdueamountsign4300);
							dbbind(dbproc4300, 47, STRINGBIND, (DBINT)0, (BYTE DBFAR *)pastduebalance4300);
							dbbind(dbproc4300, 48, STRINGBIND, (DBINT)0, (BYTE DBFAR *)chargeoffsign4300);
							dbbind(dbproc4300, 49, STRINGBIND, (DBINT)0, (BYTE DBFAR *)chargeoffamount4300);
							dbbind(dbproc4300, 50, STRINGBIND, (DBINT)0, (BYTE DBFAR *)disputeamountsign4300);
							dbbind(dbproc4300, 51, STRINGBIND, (DBINT)0, (BYTE DBFAR *)disputeamount4300);
							dbbind(dbproc4300, 52, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberpaymentspastdue4300);
							dbbind(dbproc4300, 53, STRINGBIND, (DBINT)0, (BYTE DBFAR *)highestdelinquencyperiod4300);
							dbbind(dbproc4300, 54, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountindisputeflags4300);
							dbbind(dbproc4300, 55, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressmaintenanceactioncode4300);
							dbbind(dbproc4300, 56, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outgoing4300);
							seguir4300=dbnextrow(dbproc4300); 
							if ( seguir4300 != NO_MORE_ROWS ) 
									renglon4300++;
							while (dbnextrow(dbproc4300) != NO_MORE_ROWS )  /** BARRE EL RESULTADO PARA ALMACENAR EL BUFER **/
									renglon4300++;
//							printf("renglon4300 %d\n",renglon4300); 
					}
					else
					{
							printf("No hay regsitros a procesar en la tabla REG4300\n");
					}
			}
			/*************** Si no Esta habilitado el Buffer no se Puede ir al Registro Primero ***********/
			dbgetrow(dbproc4300, DBFIRSTROW(dbproc4300));
			/*****************************************************************************/
			/* consulta a la tabla reg5000 */
			strcpy(query, DevQry(50));
			dbcmd(dbproc5000bis, query); /*QUERY PARA EL REGISTRO 5000*/
			dbsqlexec(dbproc5000bis);
			if ((result_code = dbresults(dbproc5000bis)) != NO_MORE_RESULTS)
			{
					if ((dbrows(dbproc5000bis) != 0) || (result_code == SUCCEED))
					{
							entrareg5000 = 1;
							dbbind(dbproc5000bis, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid5000);
							dbbind(dbproc5000bis, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero5000);
							dbbind(dbproc5000bis, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco5000);
							dbbind(dbproc5000bis, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)corporationnumber5000);
							dbbind(dbproc5000bis, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addendumtype5000);
							dbbind(dbproc5000bis, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservado15000);
							dbbind(dbproc5000bis, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservado25000);
							dbbind(dbproc5000bis, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantacttranoriginind5000);
							dbbind(dbproc5000bis, 9, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountnumber5000);
							dbbind(dbproc5000bis, 10, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse35000);
							dbbind(dbproc5000bis, 11, STRINGBIND, (DBINT)0, (BYTE DBFAR *)acquirersorissuersrefnum5000);
							dbbind(dbproc5000bis, 12, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recordtype5000);
							dbbind(dbproc5000bis, 13, STRINGBIND, (DBINT)0, (BYTE DBFAR *)transactiontype5000);
							dbbind(dbproc5000bis, 14, STRINGBIND, (DBINT)0, (BYTE DBFAR *)debitcreditindicator5000);
							dbbind(dbproc5000bis, 15, STRINGBIND, (DBINT)0, (BYTE DBFAR *)transactionamount5000);
							dbbind(dbproc5000bis, 16, STRINGBIND, (DBINT)0, (BYTE DBFAR *)postingdate5000);
							dbbind(dbproc5000bis, 17, STRINGBIND, (DBINT)0, (BYTE DBFAR *)transactiondate5000);
							dbbind(dbproc5000bis, 18, STRINGBIND, (DBINT)0, (BYTE DBFAR *)processingdate5000);
							dbbind(dbproc5000bis, 19, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantname5000);
							dbbind(dbproc5000bis, 20, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantcity5000);
							dbbind(dbproc5000bis, 21, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantstateprovince5000);
							dbbind(dbproc5000bis, 22, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantcountry5000);
							dbbind(dbproc5000bis, 23, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantcategorycode5000);
							dbbind(dbproc5000bis, 24, STRINGBIND, (DBINT)0, (BYTE DBFAR *)amountinoriginalcurrency5000);
							dbbind(dbproc5000bis, 25, STRINGBIND, (DBINT)0, (BYTE DBFAR *)originalcurrencycode5000);
							dbbind(dbproc5000bis, 26, STRINGBIND, (DBINT)0, (BYTE DBFAR *)currconvdatejulian5000);
							dbbind(dbproc5000bis, 27, STRINGBIND, (DBINT)0, (BYTE DBFAR *)postedcurrencycode5000);
							dbbind(dbproc5000bis, 28, STRINGBIND, (DBINT)0, (BYTE DBFAR *)conversionrate5000);
							dbbind(dbproc5000bis, 29, STRINGBIND, (DBINT)0, (BYTE DBFAR *)conversionexponent5000);
							dbbind(dbproc5000bis, 30, STRINGBIND, (DBINT)0, (BYTE DBFAR *)acquiringica5000);
							dbbind(dbproc5000bis, 31, STRINGBIND, (DBINT)0, (BYTE DBFAR *)customercode5000);
							dbbind(dbproc5000bis, 32, STRINGBIND, (DBINT)0, (BYTE DBFAR *)salestaxamount5000);
							dbbind(dbproc5000bis, 33, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservado45000);
							dbbind(dbproc5000bis, 34, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservado55000);
							dbbind(dbproc5000bis, 35, STRINGBIND, (DBINT)0, (BYTE DBFAR *)freightamount5000);
							dbbind(dbproc5000bis, 36, STRINGBIND, (DBINT)0, (BYTE DBFAR *)destinationpostalcode5000);
							dbbind(dbproc5000bis, 37, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchanttype5000);
							dbbind(dbproc5000bis, 38, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantlocationpostalcod5000);
							dbbind(dbproc5000bis, 39, STRINGBIND, (DBINT)0, (BYTE DBFAR *)dutyamount5000);
							dbbind(dbproc5000bis, 40, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantfederaltaxid5000);
							dbbind(dbproc5000bis, 41, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantstateprovincecode5000);
							dbbind(dbproc5000bis, 42, STRINGBIND, (DBINT)0, (BYTE DBFAR *)shipfrompostalcode5000);
							dbbind(dbproc5000bis, 43, STRINGBIND, (DBINT)0, (BYTE DBFAR *)alternatetaxamount5000);
							dbbind(dbproc5000bis, 44, STRINGBIND, (DBINT)0, (BYTE DBFAR *)destinationcountrycode5000);
							dbbind(dbproc5000bis, 45, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantreferencenumber5000);
							dbbind(dbproc5000bis, 46, STRINGBIND, (DBINT)0, (BYTE DBFAR *)alternatetaxindicator5000);
							dbbind(dbproc5000bis, 47, STRINGBIND, (DBINT)0, (BYTE DBFAR *)alternatetaxidentifier5000);
							dbbind(dbproc5000bis, 48, STRINGBIND, (DBINT)0, (BYTE DBFAR *)salestaxcollectedindpos5000);
							dbbind(dbproc5000bis, 49, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addendumdetailindicator5000);
							dbbind(dbproc5000bis, 50, STRINGBIND, (DBINT)0, (BYTE DBFAR *)merchantid5000);
							dbbind(dbproc5000bis, 51, STRINGBIND, (DBINT)0, (BYTE DBFAR *)banknetreferencenumber5000);
							dbbind(dbproc5000bis, 52, STRINGBIND, (DBINT)0, (BYTE DBFAR *)approvalcode5000);
							dbbind(dbproc5000bis, 53, STRINGBIND, (DBINT)0, (BYTE DBFAR *)adjustmentreasoncode5000);         
							dbbind(dbproc5000bis, 54, STRINGBIND, (DBINT)0, (BYTE DBFAR *)adjustmentdescription5000);
							dbbind(dbproc5000bis, 55, STRINGBIND, (DBINT)0, (BYTE DBFAR *)mantenimiento5000);
							dbbind(dbproc5000bis, 56, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outgoing5000);
							dbbind(dbproc5000bis, 57, STRINGBIND, (DBINT)0, (BYTE DBFAR *)organizationPointNumber5000);
							seguir5000=dbnextrow(dbproc5000bis); 
							while (dbnextrow(dbproc5000bis) != NO_MORE_ROWS )  /** BARRE EL RESULTADO PARA ALMACENAR EL BUFER **/
									renglon5000++;
					}
					else
					{
							printf("No hay regsitros a procesar en la tabla REG5000\n");
					}
			}
			/**********Si no Esta Habilitado el Buffer No se Puede Usar dbfirstrow  ************/ 
			dbgetrow(dbproc5000bis, DBFIRSTROW(dbproc5000bis));
			/*****************************************************************************/
			/* consulta a la tabla REG4000 */
			strcpy(query, DevQry(40));
			dbcmd(dbproc4000, query); /*QUERY PARA EL REGISTRO 4000*/
			dbsqlexec(dbproc4000);
			if ( strcmp(banderasigue,"0" ) == 0 )     /** PARAMETRO 3 **/
			{                                       
				/* Proceso Registro 4000 */
						while ((result_code = dbresults(dbproc4000)) != NO_MORE_RESULTS)
						{
								if ((dbrows(dbproc4000) != 0) || (result_code == SUCCEED))
								{
										/*dbbind(dbproc4000, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4000_1);*/
										dbbind(dbproc4000, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid4000);
										dbbind(dbproc4000, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero4000);
										dbbind(dbproc4000, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco4000);
										dbbind(dbproc4000, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)corporationnumber4000);
										/*dbbind(dbproc4000, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4000_2);*/
										dbbind(dbproc4000, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *) reservedforinternaluse14000);
										dbbind(dbproc4000, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *) reservedforinternaluse24000);
										dbbind(dbproc4000, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *) reservedforinternaluse34000);
										dbbind(dbproc4000, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *) corporationnameline14000);
										dbbind(dbproc4000, 9, STRINGBIND, (DBINT)0, (BYTE DBFAR *) corporationnameline24000);
										dbbind(dbproc4000, 10, STRINGBIND, (DBINT)0, (BYTE DBFAR *) addressline14000);
										dbbind(dbproc4000, 11, STRINGBIND, (DBINT)0, (BYTE DBFAR *) addressline24000);
										dbbind(dbproc4000, 12, STRINGBIND, (DBINT)0, (BYTE DBFAR *) city4000);
										dbbind(dbproc4000, 13, STRINGBIND, (DBINT)0, (BYTE DBFAR *) stateprovince4000);
										dbbind(dbproc4000, 14, STRINGBIND, (DBINT)0, (BYTE DBFAR *) country4000);
										dbbind(dbproc4000, 15, STRINGBIND, (DBINT)0, (BYTE DBFAR *) postalcode4000);
										dbbind(dbproc4000, 16, STRINGBIND, (DBINT)0, (BYTE DBFAR *) currency4000);
										dbbind(dbproc4000, 17, STRINGBIND, (DBINT)0, (BYTE DBFAR *) contactperson4000);
										/*dbbind(dbproc4000, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4000_3);*/
										dbbind(dbproc4000, 18, STRINGBIND, (DBINT)0, (BYTE DBFAR *)phonenumber4000);
										dbbind(dbproc4000, 19, STRINGBIND, (DBINT)0, (BYTE DBFAR *)faxnumber4000);
										dbbind(dbproc4000, 20, STRINGBIND, (DBINT)0, (BYTE DBFAR *)emailaddress4000);
										dbbind(dbproc4000, 21, STRINGBIND, (DBINT)0, (BYTE DBFAR *)budgetlimit4000);
										dbbind(dbproc4000, 22, STRINGBIND, (DBINT)0, (BYTE DBFAR *)cycledateindicator4000);
										dbbind(dbproc4000, 23, STRINGBIND, (DBINT)0, (BYTE DBFAR *)totalaccounts4000);
										dbbind(dbproc4000, 24, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountspastdue4000);
										dbbind(dbproc4000, 25, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountswithdispute4000);
										dbbind(dbproc4000, 26, STRINGBIND, (DBINT)0, (BYTE DBFAR *)nuumberofcards4000);
										dbbind(dbproc4000, 27, STRINGBIND, (DBINT)0, (BYTE DBFAR *)chargeoffsign4000);
										dbbind(dbproc4000, 28, STRINGBIND, (DBINT)0, (BYTE DBFAR *)chargeoffamount4000);
										dbbind(dbproc4000, 29, STRINGBIND, (DBINT)0, (BYTE DBFAR *)pastdueamountsign4000);
										dbbind(dbproc4000, 30, STRINGBIND, (DBINT)0, (BYTE DBFAR *)pastdueamount4000);
										dbbind(dbproc4000, 31, STRINGBIND, (DBINT)0, (BYTE DBFAR *)disputeamountsign4000);
										dbbind(dbproc4000, 32, STRINGBIND, (DBINT)0, (BYTE DBFAR *)disputeamount4000);
										dbbind(dbproc4000, 33, STRINGBIND, (DBINT)0, (BYTE DBFAR *)creditlimitsign4000);
										dbbind(dbproc4000, 34, STRINGBIND, (DBINT)0, (BYTE DBFAR *)creditlimit4000);
										dbbind(dbproc4000, 35, STRINGBIND, (DBINT)0, (BYTE DBFAR *)paymentduesign4000);
										dbbind(dbproc4000, 36, STRINGBIND, (DBINT)0, (BYTE DBFAR *)paymentdue4000);
										dbbind(dbproc4000, 37, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outstandingbalancesign4000);
										dbbind(dbproc4000, 38, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outstandingbalance4000);
										/*dbbind(dbproc4000, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4000_4);*/
										dbbind(dbproc4000, 39, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberofdebits4000);
										dbbind(dbproc4000, 40, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberofcredits4000);
										dbbind(dbproc4000, 41, STRINGBIND, (DBINT)0, (BYTE DBFAR *)amountofdebits4000);
										dbbind(dbproc4000, 42, STRINGBIND, (DBINT)0, (BYTE DBFAR *)amountofcredits4000);
										dbbind(dbproc4000, 43, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberaccountsoverlimit4000);
										dbbind(dbproc4000, 44, STRINGBIND, (DBINT)0, (BYTE DBFAR *)portfoliodate4000);
										dbbind(dbproc4000, 45, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressmaintenanceaction4000);
										dbbind(dbproc4000, 46, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outgoingincomingerrorcode4000);
										dbbind(dbproc4000, 47, STRINGBIND, (DBINT)0, (BYTE DBFAR *)jerarquia4000);
										while (dbnextrow(dbproc4000) != NO_MORE_ROWS)
										{
												cadenareg4000[0] = '\0';
												sprintf(contadorstr,"%d",contador);
											sprintf(contadorstrpaso, "%06s", contadorstr);
												/*strcat(cadenareg4000,campo4000_1);*/
												strcat(cadenareg4000,recid4000);
												strcat(cadenareg4000,icanumero4000);
												strcat(cadenareg4000,icanumbanco4000);
												strcat(cadenareg4000,corporationnumber4000);
												/*strcat(cadenareg4000,campo4000_2);*/
												strcat(cadenareg4000, reservedforinternaluse14000);
												strcat(cadenareg4000, reservedforinternaluse24000);
												strcat(cadenareg4000, reservedforinternaluse34000);
												strcat(cadenareg4000, corporationnameline14000);
												strcat(cadenareg4000, corporationnameline24000);
												strcat(cadenareg4000, addressline14000);
												strcat(cadenareg4000, addressline24000);
												strcat(cadenareg4000, city4000);
												strcat(cadenareg4000, stateprovince4000);
												strcat(cadenareg4000, country4000);
												strcat(cadenareg4000, postalcode4000);
												strcat(cadenareg4000, currency4000);
												strcat(cadenareg4000, contactperson4000);
												/*strcat(cadenareg4000,campo4000_3);*/
												strcat(cadenareg4000,phonenumber4000);
												strcat(cadenareg4000,faxnumber4000);
												strcat(cadenareg4000,emailaddress4000);
												strcat(cadenareg4000,budgetlimit4000);
												strcat(cadenareg4000,cycledateindicator4000);
												strcat(cadenareg4000,totalaccounts4000);
												strcat(cadenareg4000,accountspastdue4000);
												strcat(cadenareg4000,accountswithdispute4000);
												strcat(cadenareg4000,nuumberofcards4000);
												strcat(cadenareg4000,chargeoffsign4000);
												strcat(cadenareg4000,chargeoffamount4000);
												strcat(cadenareg4000,pastdueamountsign4000);
												strcat(cadenareg4000,pastdueamount4000);
												strcat(cadenareg4000,disputeamountsign4000);
												strcat(cadenareg4000,disputeamount4000);
												strcat(cadenareg4000,creditlimitsign4000);
												strcat(cadenareg4000,creditlimit4000);
												strcat(cadenareg4000,paymentduesign4000);
												strcat(cadenareg4000,paymentdue4000);
												strcat(cadenareg4000,outstandingbalancesign4000);
												strcat(cadenareg4000,outstandingbalance4000);
												/*strcat(cadenareg4000,campo4000_4);*/
												strcat(cadenareg4000,numberofdebits4000);
												strcat(cadenareg4000,numberofcredits4000);
												strcat(cadenareg4000,amountofdebits4000);
												strcat(cadenareg4000,amountofcredits4000);
												strcat(cadenareg4000,numberaccountsoverlimit4000);
												strcat(cadenareg4000,portfoliodate4000);
												strcat(cadenareg4000,addressmaintenanceaction4000);
												strcat(cadenareg4000,contadorstrpaso);
												strcat(cadenareg4000,outgoingincomingerrorcode4000);
												/*strcat(cadenareg4000,jerarquia4000);*/
												/* Graba el registro en el archivo */
												strcpy(buf4000,cadenareg4000);

												if ((fprintf(archcdf,"%s\n",buf4000)) == -1)
												{
														printf("El registro no se grabo\n");
														exit(1);
												}    
												else
												{
														strcpy(numerocorporativovalido, corporationnumber4000);
														contador = contador + 1;
												} 

												/* validamos si es corporativo o empresa sin corportivo */
												if (atoi(jerarquia4000) == 0) 
												{
															/* Proceso registro 4300  */
															strcpy(numeroempresavalida, numerocorporativovalido);
															if (entrareg4300 == 1)
															{
																		while ((atol(numeroempresavalida) == atol(corporationnumber4300)) && (seguir4300 != NO_MORE_ROWS) )
																		{
																					if ((strcmp(numeroempresavalida, corporationnumber4300)) == 0)
																					{ 
																							cadenareg4300[0]='\0';
																							sprintf(contadorstr,"%d",contador);
																							sprintf(contadorstrpaso, "%06s", contadorstr);
																							/*strcat(cadenareg4300,campo4300_1);*/
																							strcat(cadenareg4300,recid4300);
																							strcat(cadenareg4300,icanumero4300);
																							strcat(cadenareg4300,icanumbanco4300);
																							strcat(cadenareg4300,corporationnumber4300);
																							/*strcat(cadenareg4300,campo4300_2);*/
																							strcat(cadenareg4300,reservedforinternaluse14300);
																							strcat(cadenareg4300,reservedforinternaluse24300);
																							strcat(cadenareg4300,reservedforinternaluse34300);
																							strcat(cadenareg4300,reportstoorgpointnumber4300);
																							strcat(cadenareg4300,reportstofreeformattext4300);
																							strcat(cadenareg4300,accountnumber4300);
																							/*strcat(cadenareg4300,campo4300_3);*/
																							strcat(cadenareg4300,corporateproduct4300);
																							strcat(cadenareg4300,effectivedate4300);
																							strcat(cadenareg4300,expirationdate4300);
																							strcat(cadenareg4300,accountnameline14300);
																							strcat(cadenareg4300,accountnameline24300);
																							strcat(cadenareg4300,accountaddressline14300);
																							strcat(cadenareg4300,accountaddressline24300);
																							strcat(cadenareg4300,accountcity4300);
																							strcat(cadenareg4300,accountstateprovince4300);
																							strcat(cadenareg4300,accountcountry4300);
																							strcat(cadenareg4300,accountpostalcode4300);
																							strcat(cadenareg4300,accountphonenumber4300);
																							strcat(cadenareg4300,accountfaxnumber4300);
																							/*strcat(cadenareg4300,campo4300_4);*/
																							strcat(cadenareg4300,internalauditcode4300);
																							strcat(cadenareg4300,employeeid4300);
																							strcat(cadenareg4300,dailynumberlimitoftransactions4300);
																							strcat(cadenareg4300,singletransactiondollarlimit4300);
																							strcat(cadenareg4300,dailytransactiondollarlimit4300);
																							strcat(cadenareg4300,cyclenumberoftransactionlimit4300);
																							strcat(cadenareg4300,cycledollarlimit4300);
																							strcat(cadenareg4300,monthlynumlimitoftran4300);
																							strcat(cadenareg4300,monthlydollarlimit4300);
																							strcat(cadenareg4300,othernumberoftransactionlimit4300);
																							strcat(cadenareg4300,otherdollarlimit4300);
																							strcat(cadenareg4300,taxexemptindicator4300);
																							strcat(cadenareg4300,currencycode4300);
																							strcat(cadenareg4300,statementdate4300);
																							strcat(cadenareg4300,previousbalancesign4300);
																							strcat(cadenareg4300,previousbalance4300);
																							strcat(cadenareg4300,endingbalancesign4300);
																							strcat(cadenareg4300,endingbalance4300);
																							strcat(cadenareg4300,paymentduesign4300);
																							strcat(cadenareg4300,paymentduebalance4300);
																							/*strcat(cadenareg4300,campo4300_5);*/
																							strcat(cadenareg4300,creditlimitsign4300);
																							strcat(cadenareg4300,creditlimit4300);
																							strcat(cadenareg4300,pastdueamountsign4300);
																							strcat(cadenareg4300,pastduebalance4300);
																							strcat(cadenareg4300,chargeoffsign4300);
																							strcat(cadenareg4300,chargeoffamount4300);
																							strcat(cadenareg4300,disputeamountsign4300);
																							strcat(cadenareg4300,disputeamount4300);
																							strcat(cadenareg4300,numberpaymentspastdue4300);
																							strcat(cadenareg4300,highestdelinquencyperiod4300);
																							strcat(cadenareg4300,accountindisputeflags4300);
																							strcat(cadenareg4300,addressmaintenanceactioncode4300);
																							strcat(cadenareg4300,contadorstrpaso);
																							strcat(cadenareg4300,outgoing4300);
																							/* Graba el registro en el archivo */
																							strcpy(buf4300,cadenareg4300);

																							if ((fprintf(archcdf,"%s\n",buf4300)) == -1)
																							{
																									printf("El registro no se grabo\n");
																									exit(1);
																							}
																							else
																							{
																									strcpy(numerocuentavalida, accountnumber4300);
																									contador = contador + 1;
																									/* seguir4300=dbnextrow(dbproc4300); 04052002 jrgd */
																							} 
																							/* Proceso registro 5000 */
																							if (entrareg5000 == 1)
																							{
																									while ( (atol(corporationnumber4300) == atol(corporationnumber5000) ) &&  (atol(numerocuentavalida) == atol(accountnumber5000)) && (seguir5000 != NO_MORE_ROWS) ) 
																									{
																											if ((strcmp(numerocuentavalida, accountnumber5000)) == 0)
																											{
																														cadenareg5000bis[0]='\0'; 
																														sprintf(contadorstr, "%d", contador);
																														sprintf( contadorstrpaso, "%06s", contadorstr);
																														strcat(cadenareg5000bis, recid5000);
																														strcat(cadenareg5000bis, icanumero5000);
																														strcat(cadenareg5000bis, icanumbanco5000);
																														strcat(cadenareg5000bis, corporationnumber5000);
																														strcat(cadenareg5000bis, addendumtype5000);
																														strcat(cadenareg5000bis, reservado15000);
																														strcat(cadenareg5000bis, reservado25000);
																														strcat(cadenareg5000bis, merchantacttranoriginind5000);
																														strcat(cadenareg5000bis, accountnumber5000);
																														strcat(cadenareg5000bis, reservedforinternaluse35000);
																														strcat(cadenareg5000bis, acquirersorissuersrefnum5000);
																														strcat(cadenareg5000bis, recordtype5000);
																														strcat(cadenareg5000bis, transactiontype5000);
																														strcat(cadenareg5000bis, debitcreditindicator5000);
																														strcat(cadenareg5000bis, transactionamount5000);
																														strcat(cadenareg5000bis, postingdate5000);
																														strcat(cadenareg5000bis, transactiondate5000);
																														strcat(cadenareg5000bis, processingdate5000);
																														strcat(cadenareg5000bis, merchantname5000);
																														strcat(cadenareg5000bis, merchantcity5000);
																														strcat(cadenareg5000bis, merchantstateprovince5000);
																														strcat(cadenareg5000bis, merchantcountry5000);
																														strcat(cadenareg5000bis, merchantcategorycode5000);
																														strcat(cadenareg5000bis, amountinoriginalcurrency5000);
																														strcat(cadenareg5000bis, originalcurrencycode5000);
																														strcat(cadenareg5000bis, currconvdatejulian5000);
																														strcat(cadenareg5000bis, postedcurrencycode5000);
																														strcat(cadenareg5000bis, conversionrate5000);
																														strcat(cadenareg5000bis, conversionexponent5000);
																														strcat(cadenareg5000bis, acquiringica5000);
																														strcat(cadenareg5000bis, customercode5000);
																														strcat(cadenareg5000bis, salestaxamount5000);
																														strcat(cadenareg5000bis, reservado45000);
																														strcat(cadenareg5000bis, reservado55000);
																														strcat(cadenareg5000bis, freightamount5000);
																														strcat(cadenareg5000bis, destinationpostalcode5000);
																														strcat(cadenareg5000bis, merchanttype5000);
																														strcat(cadenareg5000bis, merchantlocationpostalcod5000);
																														strcat(cadenareg5000bis, dutyamount5000);
																														strcat(cadenareg5000bis, merchantfederaltaxid5000);
																														strcat(cadenareg5000bis, merchantstateprovincecode5000);
																														strcat(cadenareg5000bis, shipfrompostalcode5000);
																														strcat(cadenareg5000bis, alternatetaxamount5000);
																														strcat(cadenareg5000bis, destinationcountrycode5000);
																														strcat(cadenareg5000bis, merchantreferencenumber5000);
																														strcat(cadenareg5000bis, alternatetaxindicator5000);
																														strcat(cadenareg5000bis, alternatetaxidentifier5000);
																														strcat(cadenareg5000bis, salestaxcollectedindpos5000);
																														strcat(cadenareg5000bis, addendumdetailindicator5000);
																														strcat(cadenareg5000bis, merchantid5000);
																														strcat(cadenareg5000bis, banknetreferencenumber5000);
																														strcat(cadenareg5000bis, approvalcode5000);
																														strcat(cadenareg5000bis, adjustmentreasoncode5000);
																														strcat(cadenareg5000bis, adjustmentdescription5000);
																														strcat(cadenareg5000bis, mantenimiento5000);
																														strcat(cadenareg5000bis, contadorstrpaso);
																														strcat(cadenareg5000bis, outgoing5000);
																														/* Graba el registro en el archivo */
																														//contador = contador + 1;
																														strcpy(buf5000bis,cadenareg5000bis);

																														if ((fprintf(archcdf,"%s\n",buf5000bis)) == -1)
																														 {
																																  printf("El registro no se grabo\n");
																																  exit(1);
																														 }    
																														 else
																														{
																															 contador = contador + 1;
																														}
																														seguir5000=dbnextrow(dbproc5000bis); 
																											} /* fin if comparacion reg5000 */
																									} /* fin while nextrow proceso 5000 bis  */
																									seguir5000=dbnextrow(dbproc5000bis); /* 04052002 jrgd */ 
																							} /* fin if proceso 5000 bis */
//																						contador =contador + 1;
																						seguir4300=dbnextrow(dbproc4300);  /* 04052002 jrgd */
																					} /* fin if comparacion reg4300 */
																		} /* fin while next row proceso 4300 */
															} /* fin if proceso 4300 */
												} /* fin del if validacion si tiene corporativo */
												/* Substraemos la cadena que contiene el numero de corporativo 
												strncpy(corporativo, &numerocorporativovalido[6],5);
												corporativo[6]="\0"; se comata ya no se usa grupos */
												/* validamos si es corporativo o empresa sin corportivo */
										if (atoi(jerarquia4000) == 1) 
										{ 
													/* Proceso registro 4100  */
													if (entrareg4100 == 1)
													{
															while ( (atol(numerocorporativovalido) == atol(corporationnumber4100)) && (seguir4100 != NO_MORE_ROWS) ) 
															{
																	cadenareg4100bis[0]='\0';
																	sprintf(contadorstr,"%d",contador);
																	sprintf(contadorstrpaso, "%06s", contadorstr);
																	/*strcat(cadenareg4100bis,campo4100_1);*/
																	strcat(cadenareg4100bis,recid4100);
																	strcat(cadenareg4100bis,icanumero4100);
																	strcat(cadenareg4100bis,icanumbanco4100);
																	strcat(cadenareg4100bis,corporationnumber4100);
																	/*strcat(cadenareg4100bis,campo4100_2);*/
																	strcat(cadenareg4100bis,reservedforinternaluse14100);
																	strcat(cadenareg4100bis,reservedforinternaluse24100);
																	strcat(cadenareg4100bis,reservedforinternaluse34100);
																	strcat(cadenareg4100bis,organizationpointnumber4100);
																	/*strcat(cadenareg4100bis,campo4100_3);*/
																	strcat(cadenareg4100bis,freeformattext4100);
																	strcat(cadenareg4100bis,organizationpointnameline14100);
																	strcat(cadenareg4100bis,organizationpointnameline24100);
																	strcat(cadenareg4100bis,addressline14100);
																	strcat(cadenareg4100bis,addressline24100);
																	strcat(cadenareg4100bis,city4100);
																	strcat(cadenareg4100bis,stateprovince4100);
																	strcat(cadenareg4100bis,country4100);
																	strcat(cadenareg4100bis,postalcode4100);
																	strcat(cadenareg4100bis,currencycode4100);
																	/*strcat(cadenareg4100bis,campo4100_4);*/
																	strcat(cadenareg4100bis,contactperson4100);
																	strcat(cadenareg4100bis,phonenumber4100);
																	strcat(cadenareg4100bis,faxnumber4100);
																	strcat(cadenareg4100bis,emailaddress4100);
																	strcat(cadenareg4100bis,budgetlimit4100);
																	strcat(cadenareg4100bis,totalaccounts4100);
																	strcat(cadenareg4100bis,accountspastdue4100);
																	strcat(cadenareg4100bis,accountswithdispute4100);
																	strcat(cadenareg4100bis,numberofcards4100);
																	strcat(cadenareg4100bis,chargeoffsign4100);
																	strcat(cadenareg4100bis,chargeoffamount4100);
																	strcat(cadenareg4100bis,pastdueamountsign4100);
																	strcat(cadenareg4100bis,pastdueamount4100);
																	strcat(cadenareg4100bis,disputeamountsign4100);
																	strcat(cadenareg4100bis,disputeamount4100);
																	strcat(cadenareg4100bis,creditlimitsign4100);
																	/*strcat(cadenareg4100bis,campo4100_5);*/
																	strcat(cadenareg4100bis,creditlimit4100);
																	strcat(cadenareg4100bis,paymentduesign4100);
																	strcat(cadenareg4100bis,paymentdue4100);
																	strcat(cadenareg4100bis,outstandingbalancesign4100);
																	strcat(cadenareg4100bis,outstandingbalance4100);
																	strcat(cadenareg4100bis,numberofdebits4100);
																	strcat(cadenareg4100bis,numberofcredits4100);
																	strcat(cadenareg4100bis,amountofdebits4100);
																	strcat(cadenareg4100bis,amountofcredits4100);
																	strcat(cadenareg4100bis,numberaccountsoverlimit4100);
																	strcat(cadenareg4100bis,portfoliodate4100);
																	strcat(cadenareg4100bis,addressmaintenanceaction4100);
																	strcat(cadenareg4100bis,contadorstrpaso);
																	strcat(cadenareg4100bis,outgoing4100);

																	/* Graba el registro en el archivo */
																	strcpy(buf4100bis,cadenareg4100bis);

																	if ((fprintf(archcdf,"%s\n",buf4100bis)) == -1)
																	{
																			printf("El registro no se grabo\n");
																			exit(1);
																	}    
																	else
																	{
																			strcpy(orgpointnum4100,organizationpointnumber4100); 
																			strcpy(corporativo4100,corporationnumber4100);
																			seguir4100=dbnextrow(dbproc4100bis);
																			contador =contador + 1;
																	} 
																	//contador = contador + 1;

																	/* Proceso registro 4200  */
																	if (entrareg4200 == 1)
																	{
																			/**  while ( (atol(corporativo4100) == atol(corporationnumber4200)) && (atol(orgpointnum4100) == atol(reportsTo4200))  && (seguir4200 != NO_MORE_ROWS) ) 27-05-2004 JAGG  */ 
																			while ( (atol(corporativo4100) == atol(corporationnumber4200)) && (atol(orgpointnum4100) == atol(organizationPointNumber4200))  && (seguir4200 != NO_MORE_ROWS) )  
																			{
																					if ( (atol(corporativo4100) == atol(corporationnumber4200)) && (atol(orgpointnum4100) == atol(organizationPointNumber4200)))
																					{
																							cadenareg4200[0]='\0';
																							sprintf(contadorstr,"%d",contador);
																							sprintf(contadorstrpaso, "%06s", contadorstr);
																							/*strcat(cadenareg4200,campo4200_1);*/
																							strcat(cadenareg4200,recid4200);
																							strcat(cadenareg4200,icanumero4200);
																							strcat(cadenareg4200,icanumbanco4200);
																							strcat(cadenareg4200,corporationnumber4200);
																							strcat(cadenareg4200,reservedforinternaluse14200);
																							strcat(cadenareg4200,reservedforinternaluse24200);
																							strcat(cadenareg4200,reservedforinternaluse34200);
																							strcat(cadenareg4200,organizationPointNumber4200);
																							/*strcat(cadenareg4200,campo4200_2);*/
																							strcat(cadenareg4200,freeformattext4200);
																							strcat(cadenareg4200,reportsTo4200);
																							strcat(cadenareg4200,reportstofreeformattext4200);
																							strcat(cadenareg4200,reservedforinternaluse44200);
																							strcat(cadenareg4200,organizationhierarchymainact4200);
																							strcat(cadenareg4200,contadorstrpaso);
																							strcat(cadenareg4200,outgoingIncomingErrorCode4200);
																							/* Graba el registro en el archivo */
																							strcpy(buf4200,cadenareg4200);

																							if ((fprintf(archcdf,"%s\n",buf4200)) == -1)
																							{
																									printf("El registro no se grabo\n");
																									exit(1);
																							}    
																							else
																							{
																									strcpy(corporativo4200, corporationnumber4200); 
																									strcpy(report4200,reportsTo4200);
																									seguir4200=dbnextrow(dbproc4200); 
																									contador =contador + 1;
																							} 
																							//contador = contador + 1;
																							/* Proceso registro 4300  */
																							/* printf("Proceso registro 4300\n"); */
																							if (entrareg4300 == 1)
																							{
																									while ( (atol(corporativo4200) == atol(corporationnumber4300)) && (atol(report4200) == atol(reportstoorgpointnumber4300)) && (seguir4300 != NO_MORE_ROWS) ) 
																									{
																											 if ((atol(report4200) == atol(reportstoorgpointnumber4300)))
																											  {
																													   cadenareg4300[0]='\0';
																													   sprintf(contadorstr,"%d",contador);
																													   sprintf(contadorstrpaso, "%06s", contadorstr);
																													   /*strcat(cadenareg4300,campo4300_1);*/
																													   strcat(cadenareg4300,recid4300);
																													   strcat(cadenareg4300,icanumero4300);
																													   strcat(cadenareg4300,icanumbanco4300);
																													   strcat(cadenareg4300,corporationnumber4300);
																													   /*strcat(cadenareg4300,campo4300_2);*/
																													   strcat(cadenareg4300,reservedforinternaluse14300);
																													   strcat(cadenareg4300,reservedforinternaluse24300);
																													   strcat(cadenareg4300,reservedforinternaluse34300);
																													   strcat(cadenareg4300,reportstoorgpointnumber4300);
																													   strcat(cadenareg4300,reportstofreeformattext4300);
																													   strcat(cadenareg4300,accountnumber4300);
																													   /*strcat(cadenareg4300,campo4300_3);*/
																														strcat(cadenareg4300,corporateproduct4300);
																														strcat(cadenareg4300,effectivedate4300);
																														strcat(cadenareg4300,expirationdate4300);
																														strcat(cadenareg4300,accountnameline14300);
																														strcat(cadenareg4300,accountnameline24300);
																														strcat(cadenareg4300,accountaddressline14300);
																														strcat(cadenareg4300,accountaddressline24300);
																														strcat(cadenareg4300,accountcity4300);
																														strcat(cadenareg4300,accountstateprovince4300);
																														strcat(cadenareg4300,accountcountry4300);
																														strcat(cadenareg4300,accountpostalcode4300);
																														strcat(cadenareg4300,accountphonenumber4300);
																														strcat(cadenareg4300,accountfaxnumber4300);
																													   /*strcat(cadenareg4300,campo4300_4);*/
																														strcat(cadenareg4300,internalauditcode4300);
																														strcat(cadenareg4300,employeeid4300);
																														strcat(cadenareg4300,dailynumberlimitoftransactions4300);
																														strcat(cadenareg4300,singletransactiondollarlimit4300);
																														strcat(cadenareg4300,dailytransactiondollarlimit4300);
																														strcat(cadenareg4300,cyclenumberoftransactionlimit4300);
																														strcat(cadenareg4300,cycledollarlimit4300);
																														strcat(cadenareg4300,monthlynumlimitoftran4300);
																														strcat(cadenareg4300,monthlydollarlimit4300);
																														strcat(cadenareg4300,othernumberoftransactionlimit4300);
																														strcat(cadenareg4300,otherdollarlimit4300);
																														strcat(cadenareg4300,taxexemptindicator4300);
																														strcat(cadenareg4300,currencycode4300);
																														strcat(cadenareg4300,statementdate4300);
																														strcat(cadenareg4300,previousbalancesign4300);
																														strcat(cadenareg4300,previousbalance4300);
																														strcat(cadenareg4300,endingbalancesign4300);
																														strcat(cadenareg4300,endingbalance4300);
																														strcat(cadenareg4300,paymentduesign4300);
																														strcat(cadenareg4300,paymentduebalance4300);
																													   /*strcat(cadenareg4300,campo4300_5);*/
																														strcat(cadenareg4300,creditlimitsign4300);
																														strcat(cadenareg4300,creditlimit4300);
																														strcat(cadenareg4300,pastdueamountsign4300);
																														strcat(cadenareg4300,pastduebalance4300);
																														strcat(cadenareg4300,chargeoffsign4300);
																														strcat(cadenareg4300,chargeoffamount4300);
																														strcat(cadenareg4300,disputeamountsign4300);
																														strcat(cadenareg4300,disputeamount4300);
																														strcat(cadenareg4300,numberpaymentspastdue4300);
																														strcat(cadenareg4300,highestdelinquencyperiod4300);
																														strcat(cadenareg4300,accountindisputeflags4300);
																														strcat(cadenareg4300,addressmaintenanceactioncode4300);
																														strcat(cadenareg4300,contadorstrpaso);
																														strcat(cadenareg4300,outgoing4300);
																													   /* Graba el registro en el archivo */
																													   strcpy(buf4300,cadenareg4300);

																													   if ((fprintf(archcdf,"%s\n",buf4300)) == -1)
																														{
																																 printf("El registro no se grabo\n");
																																 exit(1);
																														}
																													   else
																														{
																																 strcpy(corporativo4300,corporationnumber4300);
																																 strcpy(cta4300, accountnumber4300); 
																																 strcpy(report4300, reportstoorgpointnumber4300); 
																																 seguir4300=dbnextrow(dbproc4300); 
																																 contador = contador + 1;
																														} 
																													   /* Proceso registro 5000  */
																													   if (entrareg5000 == 1)
																														{
																																 while ( (atol(corporativo4300) == atol(corporationnumber5000)) && (atol(report4300) == atol(organizationPointNumber5000)) && (atol(cta4300) == atol(accountnumber5000)) && (seguir5000 != NO_MORE_ROWS) )  
																																  {
																																		   if ((atol(report4300) == atol(organizationPointNumber5000)) && (atol(cta4300) == atol(accountnumber5000)))
																																			{
																																					 cadenareg5000bis[0]='\0'; 
																																					 sprintf(contadorstr, "%d", contador);
																																					 sprintf( contadorstrpaso, "%06s", contadorstr);
																																					 strcat(cadenareg5000bis, recid5000);
																																					 strcat(cadenareg5000bis, icanumero5000);
																																					 strcat(cadenareg5000bis, icanumbanco5000);
																																					 strcat(cadenareg5000bis, corporationnumber5000);
																																					 strcat(cadenareg5000bis, addendumtype5000);
																																					 strcat(cadenareg5000bis, reservado15000);
																																					 strcat(cadenareg5000bis, reservado25000);
																																					 strcat(cadenareg5000bis, merchantacttranoriginind5000);
																																					 strcat(cadenareg5000bis, accountnumber5000);
																																					 strcat(cadenareg5000bis, reservedforinternaluse35000);
																																					 strcat(cadenareg5000bis, acquirersorissuersrefnum5000);
																																					 strcat(cadenareg5000bis, recordtype5000);
																																					 strcat(cadenareg5000bis, transactiontype5000);
																																					 strcat(cadenareg5000bis, debitcreditindicator5000);
																																					 strcat(cadenareg5000bis, transactionamount5000);
																																					 strcat(cadenareg5000bis, postingdate5000);
																																					 strcat(cadenareg5000bis, transactiondate5000);
																																					 strcat(cadenareg5000bis, processingdate5000);
																																					 strcat(cadenareg5000bis, merchantname5000);
																																					 strcat(cadenareg5000bis, merchantcity5000);
																																					 strcat(cadenareg5000bis, merchantstateprovince5000);
																																					 strcat(cadenareg5000bis, merchantcountry5000);
																																					 strcat(cadenareg5000bis, merchantcategorycode5000);
																																					 strcat(cadenareg5000bis, amountinoriginalcurrency5000);
																																					 strcat(cadenareg5000bis, originalcurrencycode5000);
																																					 strcat(cadenareg5000bis, currconvdatejulian5000);
																																					 strcat(cadenareg5000bis, postedcurrencycode5000);
																																					 strcat(cadenareg5000bis, conversionrate5000);
																																					 strcat(cadenareg5000bis, conversionexponent5000);
																																					 strcat(cadenareg5000bis, acquiringica5000);
																																					 strcat(cadenareg5000bis, customercode5000);
																																					 strcat(cadenareg5000bis, salestaxamount5000);
																																					 strcat(cadenareg5000bis, reservado45000);
																																					 strcat(cadenareg5000bis, reservado55000);
																																					 strcat(cadenareg5000bis, freightamount5000);
																																					 strcat(cadenareg5000bis, destinationpostalcode5000);
																																					 strcat(cadenareg5000bis, merchanttype5000);
																																					 strcat(cadenareg5000bis, merchantlocationpostalcod5000);
																																					 strcat(cadenareg5000bis, dutyamount5000);
																																					 strcat(cadenareg5000bis, merchantfederaltaxid5000);
																																					 strcat(cadenareg5000bis, merchantstateprovincecode5000);
																																					 strcat(cadenareg5000bis, shipfrompostalcode5000);
																																					 strcat(cadenareg5000bis, alternatetaxamount5000);
																																					 strcat(cadenareg5000bis, destinationcountrycode5000);
																																					 strcat(cadenareg5000bis, merchantreferencenumber5000);
																																					 strcat(cadenareg5000bis, alternatetaxindicator5000);
																																					 strcat(cadenareg5000bis, alternatetaxidentifier5000);
																																					 strcat(cadenareg5000bis, salestaxcollectedindpos5000);
																																					 strcat(cadenareg5000bis, addendumdetailindicator5000);
																																					 strcat(cadenareg5000bis, merchantid5000);
																																					 strcat(cadenareg5000bis, banknetreferencenumber5000);
																																					 strcat(cadenareg5000bis, approvalcode5000);
																																					 strcat(cadenareg5000bis, adjustmentreasoncode5000);
																																					 strcat(cadenareg5000bis, adjustmentdescription5000);
																																					 strcat(cadenareg5000bis, mantenimiento5000);
																																					 strcat(cadenareg5000bis, contadorstrpaso);
																																					 strcat(cadenareg5000bis, outgoing5000);
																																					 /* Graba el registro en el archivo */
																																					//contador = contador + 1; 
																																					strcpy(buf5000bis,cadenareg5000bis);

																																					 if ((fprintf(archcdf,"%s\n",buf5000bis)) == -1)
																																					{
																																							printf("El registro no se grabo\n");
																																							exit(1);
																																					}    
																																					else
																																					{
																																						contador =contador + 1;
																																					}
																																					seguir5000=dbnextrow(dbproc5000bis); 
																																			} /* fin if comparacion reg5000 */
																																  } /* fin while nextrow proceso 5000 bis  */
																														} /* fin if proceso 5000 bis */
																													   //contador =contador + 1;
																											  } /* fin if comparacion reg4300 */
																									} /* fin while next row proceso 4300 */ 
																							} /* fin if proceso 4300 */
																					} /* fin del if comparacion reg4200 */
																			} /* fin while dbnext row reg4200 */
																	} /* fin if principal reg4200 */
															} /* fin while nextrow proceso 4100 bis */
													} /* fin if proceso 4100 bis */
											} /* fin if compara corporativo dif de ceros */ 
										} /* fin while next row proceso 4000  */
								}  /* fin if proceso 4000  */
						}  /* fin while proceso 4000  */

				/* proceso registro 4100 sin dependencias */
				while ( seguir4100 != NO_MORE_ROWS )
				// while (dbnextrow(dbproc4100bis) != NO_MORE_ROWS)  Comentado 05-07-2004 JAGG
				{
						cadenareg4100bis[0]='\0';
						sprintf(contadorstr,"%d",contador);
						sprintf(contadorstrpaso, "%06s", contadorstr);
						/*strcat(cadenareg4100bis,campo4100_1);*/
						strcat(cadenareg4100bis,recid4100);
						strcat(cadenareg4100bis,icanumero4100);
						strcat(cadenareg4100bis,icanumbanco4100);
						strcat(cadenareg4100bis,corporationnumber4100);
						/*strcat(cadenareg4100bis,campo4100_2);*/
						strcat(cadenareg4100bis,reservedforinternaluse14100);
						strcat(cadenareg4100bis,reservedforinternaluse24100);
						strcat(cadenareg4100bis,reservedforinternaluse34100);
						strcat(cadenareg4100bis,organizationpointnumber4100);
						/*strcat(cadenareg4100bis,campo4100_3);*/
						strcat(cadenareg4100bis,freeformattext4100);
						strcat(cadenareg4100bis,organizationpointnameline14100);
						strcat(cadenareg4100bis,organizationpointnameline24100);
						strcat(cadenareg4100bis,addressline14100);
						strcat(cadenareg4100bis,addressline24100);
						strcat(cadenareg4100bis,city4100);
						strcat(cadenareg4100bis,stateprovince4100);
						strcat(cadenareg4100bis,country4100);
						strcat(cadenareg4100bis,postalcode4100);
						strcat(cadenareg4100bis,currencycode4100);
						/*strcat(cadenareg4100bis,campo4100_4);*/
						strcat(cadenareg4100bis,contactperson4100);
						strcat(cadenareg4100bis,phonenumber4100);
						strcat(cadenareg4100bis,faxnumber4100);
						strcat(cadenareg4100bis,emailaddress4100);
						strcat(cadenareg4100bis,budgetlimit4100);
						strcat(cadenareg4100bis,totalaccounts4100);
						strcat(cadenareg4100bis,accountspastdue4100);
						strcat(cadenareg4100bis,accountswithdispute4100);
						strcat(cadenareg4100bis,numberofcards4100);
						strcat(cadenareg4100bis,chargeoffsign4100);
						strcat(cadenareg4100bis,chargeoffamount4100);
						strcat(cadenareg4100bis,pastdueamountsign4100);
						strcat(cadenareg4100bis,pastdueamount4100);
						strcat(cadenareg4100bis,disputeamountsign4100);
						strcat(cadenareg4100bis,disputeamount4100);
						strcat(cadenareg4100bis,creditlimitsign4100);
						/*strcat(cadenareg4100bis,campo4100_5);*/
						strcat(cadenareg4100bis,creditlimit4100);
						strcat(cadenareg4100bis,paymentduesign4100);
						strcat(cadenareg4100bis,paymentdue4100);
						strcat(cadenareg4100bis,outstandingbalancesign4100);
						strcat(cadenareg4100bis,outstandingbalance4100);
						strcat(cadenareg4100bis,numberofdebits4100);
						strcat(cadenareg4100bis,numberofcredits4100);
						strcat(cadenareg4100bis,amountofdebits4100);
						strcat(cadenareg4100bis,amountofcredits4100);
						strcat(cadenareg4100bis,numberaccountsoverlimit4100);
						strcat(cadenareg4100bis,portfoliodate4100);
						strcat(cadenareg4100bis,addressmaintenanceaction4100);
						strcat(cadenareg4100bis,contadorstrpaso);
						strcat(cadenareg4100bis,outgoing4100);
						/* Graba el registro en el archivo */
						strcpy(buf4100bis,cadenareg4100bis);

						if ((fprintf(archcdf,"%s\n",buf4100bis)) == -1)
						{
								printf("El registro no se grabo\n");
								exit(1);
						}    
						else
						{
								contador = contador + 1;
						} 
						seguir4100=dbnextrow(dbproc4100bis);
				} /* fin del while del dbnext rows  registro 4100 */

				/* proceso registro 4200 sin dependencias */
				while ( seguir4200 != NO_MORE_ROWS )
				//    while (dbnextrow(dbproc4200) != NO_MORE_ROWS) 
				{
						cadenareg4200[0]='\0';
						sprintf(contadorstr,"%d",contador);
						sprintf(contadorstrpaso, "%06s", contadorstr);
						/*strcat(cadenareg4200,campo4200_1);*/
						strcat(cadenareg4200,recid4200);
						strcat(cadenareg4200,icanumero4200);
						strcat(cadenareg4200,icanumbanco4200);
						strcat(cadenareg4200,corporationnumber4200);
						strcat(cadenareg4200,reservedforinternaluse14200);
						strcat(cadenareg4200,reservedforinternaluse24200);
						strcat(cadenareg4200,reservedforinternaluse34200);
						strcat(cadenareg4200,organizationPointNumber4200);
						/*strcat(cadenareg4200,campo4200_2);*/
						strcat(cadenareg4200,freeformattext4200);
						strcat(cadenareg4200,reportsTo4200);
						strcat(cadenareg4200,reportstofreeformattext4200);
						strcat(cadenareg4200,reservedforinternaluse44200);
						strcat(cadenareg4200,organizationhierarchymainact4200);
						strcat(cadenareg4200,contadorstrpaso);
						strcat(cadenareg4200,outgoingIncomingErrorCode4200);
						/* Graba el registro en el archivo */
						strcpy(buf4200,cadenareg4200);

						if ((fprintf(archcdf,"%s\n",buf4200)) == -1)
						{
								printf("El registro no se grabo\n");
								exit(1);
						}    
						else
						{
								contador = contador + 1;
						} 
						seguir4200=dbnextrow(dbproc4200);
				} /* fin del dbnextrows del registro 4200 */
				/* proceso registro 4300 sin dependencias */
				while ( seguir4300 != NO_MORE_ROWS )
				{  
						cadenareg4300[0]='\0';
						sprintf(contadorstr,"%d",contador);
						sprintf(contadorstrpaso, "%06s", contadorstr);
						/*strcat(cadenareg4300,campo4300_1);*/
						strcat(cadenareg4300,recid4300);
						strcat(cadenareg4300,icanumero4300);
						strcat(cadenareg4300,icanumbanco4300);
						strcat(cadenareg4300,corporationnumber4300);
						/*strcat(cadenareg4300,campo4300_2);*/
						strcat(cadenareg4300,reservedforinternaluse14300);
						strcat(cadenareg4300,reservedforinternaluse24300);
						strcat(cadenareg4300,reservedforinternaluse34300);
						strcat(cadenareg4300,reportstoorgpointnumber4300);
						strcat(cadenareg4300,reportstofreeformattext4300);
						strcat(cadenareg4300,accountnumber4300);
						/*strcat(cadenareg4300,campo4300_3);*/
						strcat(cadenareg4300,corporateproduct4300);
						strcat(cadenareg4300,effectivedate4300);
						strcat(cadenareg4300,expirationdate4300);
						strcat(cadenareg4300,accountnameline14300);
						strcat(cadenareg4300,accountnameline24300);
						strcat(cadenareg4300,accountaddressline14300);
						strcat(cadenareg4300,accountaddressline24300);
						strcat(cadenareg4300,accountcity4300);
						strcat(cadenareg4300,accountstateprovince4300);
						strcat(cadenareg4300,accountcountry4300);
						strcat(cadenareg4300,accountpostalcode4300);
						strcat(cadenareg4300,accountphonenumber4300);
						strcat(cadenareg4300,accountfaxnumber4300);
						/*strcat(cadenareg4300,campo4300_4);*/
						strcat(cadenareg4300,internalauditcode4300);
						strcat(cadenareg4300,employeeid4300);
						strcat(cadenareg4300,dailynumberlimitoftransactions4300);
						strcat(cadenareg4300,singletransactiondollarlimit4300);
						strcat(cadenareg4300,dailytransactiondollarlimit4300);
						strcat(cadenareg4300,cyclenumberoftransactionlimit4300);
						strcat(cadenareg4300,cycledollarlimit4300);
						strcat(cadenareg4300,monthlynumlimitoftran4300);
						strcat(cadenareg4300,monthlydollarlimit4300);
						strcat(cadenareg4300,othernumberoftransactionlimit4300);
						strcat(cadenareg4300,otherdollarlimit4300);
						strcat(cadenareg4300,taxexemptindicator4300);
						strcat(cadenareg4300,currencycode4300);
						strcat(cadenareg4300,statementdate4300);
						strcat(cadenareg4300,previousbalancesign4300);
						strcat(cadenareg4300,previousbalance4300);
						strcat(cadenareg4300,endingbalancesign4300);
						strcat(cadenareg4300,endingbalance4300);
						strcat(cadenareg4300,paymentduesign4300);
						strcat(cadenareg4300,paymentduebalance4300);
						/*strcat(cadenareg4300,campo4300_5);*/
						strcat(cadenareg4300,creditlimitsign4300);
						strcat(cadenareg4300,creditlimit4300);
						strcat(cadenareg4300,pastdueamountsign4300);
						strcat(cadenareg4300,pastduebalance4300);
						strcat(cadenareg4300,chargeoffsign4300);
						strcat(cadenareg4300,chargeoffamount4300);
						strcat(cadenareg4300,disputeamountsign4300);
						strcat(cadenareg4300,disputeamount4300);
						strcat(cadenareg4300,numberpaymentspastdue4300);
						strcat(cadenareg4300,highestdelinquencyperiod4300);
						strcat(cadenareg4300,accountindisputeflags4300);
						strcat(cadenareg4300,addressmaintenanceactioncode4300);
						strcat(cadenareg4300,contadorstrpaso);
						strcat(cadenareg4300,outgoing4300);
						/* Graba el registro en el archivo */
						strcpy(buf4300,cadenareg4300);

						if ((fprintf(archcdf,"%s\n",buf4300)) == -1)
						{
								printf("El registro no se grabo\n");
								exit(1);
						}
						else
						{
								contador =contador + 1;
						}
						seguir4300=dbnextrow(dbproc4300);
				} 
				/* proceso registro 5000 sin dependencias */
				while ( seguir5000 != NO_MORE_ROWS )
				{ 
						cadenareg5000bis[0]='\0';
						sprintf(contadorstr, "%d", contador);
						sprintf( contadorstrpaso, "%06s", contadorstr);
						strcat(cadenareg5000bis, recid5000);
						strcat(cadenareg5000bis, icanumero5000);
						strcat(cadenareg5000bis, icanumbanco5000);
						strcat(cadenareg5000bis, corporationnumber5000);
						strcat(cadenareg5000bis, addendumtype5000);
						strcat(cadenareg5000bis, reservado15000);
						strcat(cadenareg5000bis, reservado25000);
						strcat(cadenareg5000bis, merchantacttranoriginind5000);
						strcat(cadenareg5000bis, accountnumber5000);
						strcat(cadenareg5000bis, reservedforinternaluse35000);
						strcat(cadenareg5000bis, acquirersorissuersrefnum5000);
						strcat(cadenareg5000bis, recordtype5000);
						strcat(cadenareg5000bis, transactiontype5000);
						strcat(cadenareg5000bis, debitcreditindicator5000);
						strcat(cadenareg5000bis, transactionamount5000);
						strcat(cadenareg5000bis, postingdate5000);
						strcat(cadenareg5000bis, transactiondate5000);
						strcat(cadenareg5000bis, processingdate5000);
						strcat(cadenareg5000bis, merchantname5000);
						strcat(cadenareg5000bis, merchantcity5000);
						strcat(cadenareg5000bis, merchantstateprovince5000);
						strcat(cadenareg5000bis, merchantcountry5000);
						strcat(cadenareg5000bis, merchantcategorycode5000);
						strcat(cadenareg5000bis, amountinoriginalcurrency5000);
						strcat(cadenareg5000bis, originalcurrencycode5000);
						strcat(cadenareg5000bis, currconvdatejulian5000);
						strcat(cadenareg5000bis, postedcurrencycode5000);
						strcat(cadenareg5000bis, conversionrate5000);
						strcat(cadenareg5000bis, conversionexponent5000);
						strcat(cadenareg5000bis, acquiringica5000);
						strcat(cadenareg5000bis, customercode5000);
						strcat(cadenareg5000bis, salestaxamount5000);
						strcat(cadenareg5000bis, reservado45000);
						strcat(cadenareg5000bis, reservado55000);
						strcat(cadenareg5000bis, freightamount5000);
						strcat(cadenareg5000bis, destinationpostalcode5000);
						strcat(cadenareg5000bis, merchanttype5000);
						strcat(cadenareg5000bis, merchantlocationpostalcod5000);
						strcat(cadenareg5000bis, dutyamount5000);
						strcat(cadenareg5000bis, merchantfederaltaxid5000);
						strcat(cadenareg5000bis, merchantstateprovincecode5000);
						strcat(cadenareg5000bis, shipfrompostalcode5000);
						strcat(cadenareg5000bis, alternatetaxamount5000);
						strcat(cadenareg5000bis, destinationcountrycode5000);
						strcat(cadenareg5000bis, merchantreferencenumber5000);
						strcat(cadenareg5000bis, alternatetaxindicator5000);
						strcat(cadenareg5000bis, alternatetaxidentifier5000);
						strcat(cadenareg5000bis, salestaxcollectedindpos5000);
						strcat(cadenareg5000bis, addendumdetailindicator5000);
						strcat(cadenareg5000bis, merchantid5000);
						strcat(cadenareg5000bis, banknetreferencenumber5000);
						strcat(cadenareg5000bis, approvalcode5000);
						strcat(cadenareg5000bis, adjustmentreasoncode5000);         
						strcat(cadenareg5000bis, adjustmentdescription5000);
						strcat(cadenareg5000bis, mantenimiento5000);
						strcat(cadenareg5000bis, contadorstrpaso);
						strcat(cadenareg5000bis, outgoing5000);
						/* Graba el registro en el archivo */
						strcpy(buf5000bis,cadenareg5000bis);

						if ((fprintf(archcdf,"%s\n",buf5000bis)) == -1)
						{
								printf("El registro no se grabo\n");
								exit(1);
						}    
						else
						{
								contador=contador+1;
						}
						seguir5000=dbnextrow(dbproc5000bis);
				} 
				/* fin while dbnextrows del registro 5000 */
				sprintf(contadorstr, "%d", contador);
				sprintf( contadorstrpaso, "%06s", contadorstr);
			}
			if ( strcmp(banderasigue, "1" ) == 0 )
			{
					/* proceso registro 4000 regenerado */
					while ((result_code = dbresults(dbproc4000)) != NO_MORE_RESULTS)
					{
							if ((dbrows(dbproc4000) != 0) || (result_code == SUCCEED))
							{
									/*dbbind(dbproc4000, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4000_1);*/
									dbbind(dbproc4000, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid4000);
									dbbind(dbproc4000, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero4000);
									dbbind(dbproc4000, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco4000);
									dbbind(dbproc4000, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)corporationnumber4000);
									/*dbbind(dbproc4000, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4000_2);*/
									dbbind(dbproc4000, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *) reservedforinternaluse14000);
									dbbind(dbproc4000, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *) reservedforinternaluse24000);
									dbbind(dbproc4000, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *) reservedforinternaluse34000);
									dbbind(dbproc4000, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *) corporationnameline14000);
									dbbind(dbproc4000, 9, STRINGBIND, (DBINT)0, (BYTE DBFAR *) corporationnameline24000);
									dbbind(dbproc4000, 10, STRINGBIND, (DBINT)0, (BYTE DBFAR *) addressline14000);
									dbbind(dbproc4000, 11, STRINGBIND, (DBINT)0, (BYTE DBFAR *) addressline24000);
									dbbind(dbproc4000, 12, STRINGBIND, (DBINT)0, (BYTE DBFAR *) city4000);
									dbbind(dbproc4000, 13, STRINGBIND, (DBINT)0, (BYTE DBFAR *) stateprovince4000);
									dbbind(dbproc4000, 14, STRINGBIND, (DBINT)0, (BYTE DBFAR *) country4000);
									dbbind(dbproc4000, 15, STRINGBIND, (DBINT)0, (BYTE DBFAR *) postalcode4000);
									dbbind(dbproc4000, 16, STRINGBIND, (DBINT)0, (BYTE DBFAR *) currency4000);
									dbbind(dbproc4000, 17, STRINGBIND, (DBINT)0, (BYTE DBFAR *) contactperson4000);
									/*dbbind(dbproc4000, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4000_3);*/
									dbbind(dbproc4000, 18, STRINGBIND, (DBINT)0, (BYTE DBFAR *)phonenumber4000);
									dbbind(dbproc4000, 19, STRINGBIND, (DBINT)0, (BYTE DBFAR *)faxnumber4000);
									dbbind(dbproc4000, 20, STRINGBIND, (DBINT)0, (BYTE DBFAR *)emailaddress4000);
									dbbind(dbproc4000, 21, STRINGBIND, (DBINT)0, (BYTE DBFAR *)budgetlimit4000);
									dbbind(dbproc4000, 22, STRINGBIND, (DBINT)0, (BYTE DBFAR *)cycledateindicator4000);
									dbbind(dbproc4000, 23, STRINGBIND, (DBINT)0, (BYTE DBFAR *)totalaccounts4000);
									dbbind(dbproc4000, 24, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountspastdue4000);
									dbbind(dbproc4000, 25, STRINGBIND, (DBINT)0, (BYTE DBFAR *)accountswithdispute4000);
									dbbind(dbproc4000, 26, STRINGBIND, (DBINT)0, (BYTE DBFAR *)nuumberofcards4000);
									dbbind(dbproc4000, 27, STRINGBIND, (DBINT)0, (BYTE DBFAR *)chargeoffsign4000);
									dbbind(dbproc4000, 28, STRINGBIND, (DBINT)0, (BYTE DBFAR *)chargeoffamount4000);
									dbbind(dbproc4000, 29, STRINGBIND, (DBINT)0, (BYTE DBFAR *)pastdueamountsign4000);
									dbbind(dbproc4000, 30, STRINGBIND, (DBINT)0, (BYTE DBFAR *)pastdueamount4000);
									dbbind(dbproc4000, 31, STRINGBIND, (DBINT)0, (BYTE DBFAR *)disputeamountsign4000);
									dbbind(dbproc4000, 32, STRINGBIND, (DBINT)0, (BYTE DBFAR *)disputeamount4000);
									dbbind(dbproc4000, 33, STRINGBIND, (DBINT)0, (BYTE DBFAR *)creditlimitsign4000);
									dbbind(dbproc4000, 34, STRINGBIND, (DBINT)0, (BYTE DBFAR *)creditlimit4000);
									dbbind(dbproc4000, 35, STRINGBIND, (DBINT)0, (BYTE DBFAR *)paymentduesign4000);
									dbbind(dbproc4000, 36, STRINGBIND, (DBINT)0, (BYTE DBFAR *)paymentdue4000);
									dbbind(dbproc4000, 37, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outstandingbalancesign4000);
									dbbind(dbproc4000, 38, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outstandingbalance4000);
									/*dbbind(dbproc4000, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)campo4000_4);*/
									dbbind(dbproc4000, 39, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberofdebits4000);
									dbbind(dbproc4000, 40, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberofcredits4000);
									dbbind(dbproc4000, 41, STRINGBIND, (DBINT)0, (BYTE DBFAR *)amountofdebits4000);
									dbbind(dbproc4000, 42, STRINGBIND, (DBINT)0, (BYTE DBFAR *)amountofcredits4000);
									dbbind(dbproc4000, 43, STRINGBIND, (DBINT)0, (BYTE DBFAR *)numberaccountsoverlimit4000);
									dbbind(dbproc4000, 44, STRINGBIND, (DBINT)0, (BYTE DBFAR *)portfoliodate4000);
									dbbind(dbproc4000, 45, STRINGBIND, (DBINT)0, (BYTE DBFAR *)addressmaintenanceaction4000);
									dbbind(dbproc4000, 47, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outgoingincomingerrorcode4000);
									dbbind(dbproc4000, 48, STRINGBIND, (DBINT)0, (BYTE DBFAR *)jerarquia4000);
									while (dbnextrow(dbproc4000) != NO_MORE_ROWS)
									{
											cadenareg4000[0] = '\0';
											sprintf(contadorstr,"%d",contador);
											sprintf(contadorstrpaso, "%06s", contadorstr);
											/*strcat(cadenareg4000,campo4000_1);*/
											strcat(cadenareg4000,recid4000);
											strcat(cadenareg4000,icanumero4000);
											strcat(cadenareg4000,icanumbanco4000);
											strcat(cadenareg4000,corporationnumber4000);
											/*strcat(cadenareg4000,campo4000_2);*/
											strcat(cadenareg4000, reservedforinternaluse14000);
											strcat(cadenareg4000, reservedforinternaluse24000);
											strcat(cadenareg4000, reservedforinternaluse34000);
											strcat(cadenareg4000, corporationnameline14000);
											strcat(cadenareg4000, corporationnameline24000);
											strcat(cadenareg4000, addressline14000);
											strcat(cadenareg4000, addressline24000);
											strcat(cadenareg4000, city4000);
											strcat(cadenareg4000, stateprovince4000);
											strcat(cadenareg4000, country4000);
											strcat(cadenareg4000, postalcode4000);
											strcat(cadenareg4000, currency4000);
											strcat(cadenareg4000, contactperson4000);
											/*strcat(cadenareg4000,campo4000_3);*/
											strcat(cadenareg4000,phonenumber4000);
											strcat(cadenareg4000,faxnumber4000);
											strcat(cadenareg4000,emailaddress4000);
											strcat(cadenareg4000,budgetlimit4000);
											strcat(cadenareg4000,cycledateindicator4000);
											strcat(cadenareg4000,totalaccounts4000);
											strcat(cadenareg4000,accountspastdue4000);
											strcat(cadenareg4000,accountswithdispute4000);
											strcat(cadenareg4000,nuumberofcards4000);
											strcat(cadenareg4000,chargeoffsign4000);
											strcat(cadenareg4000,chargeoffamount4000);
											strcat(cadenareg4000,pastdueamountsign4000);
											strcat(cadenareg4000,pastdueamount4000);
											strcat(cadenareg4000,disputeamountsign4000);
											strcat(cadenareg4000,disputeamount4000);
											strcat(cadenareg4000,creditlimitsign4000);
											strcat(cadenareg4000,creditlimit4000);
											strcat(cadenareg4000,paymentduesign4000);
											strcat(cadenareg4000,paymentdue4000);
											strcat(cadenareg4000,outstandingbalancesign4000);
											strcat(cadenareg4000,outstandingbalance4000);
											/*strcat(cadenareg4000,campo4000_4);*/
											strcat(cadenareg4000,numberofdebits4000);
											strcat(cadenareg4000,numberofcredits4000);
											strcat(cadenareg4000,amountofdebits4000);
											strcat(cadenareg4000,amountofcredits4000);
											strcat(cadenareg4000,numberaccountsoverlimit4000);
											strcat(cadenareg4000,portfoliodate4000);
											strcat(cadenareg4000,addressmaintenanceaction4000);
											strcat(cadenareg4000,contadorstrpaso);
											strcat(cadenareg4000,outgoingincomingerrorcode4000);
											/*strcat(cadenareg4000,jerarquia4000);*/
											/* Graba el registro en el archivo */
											strcpy(buf4000,cadenareg4000);

											if ((fprintf(archcdf,"%s\n",buf4000)) == -1)
											{
													printf("El registro no se grabo\n");
													exit(1);
											}    
											else
											{
													contador=contador+1;
											} 
									} /* fin del while dbnext rows */
							} /* fin del if  SUCEEDD  */
					}  /* fin del while  dbresult */ 
					/* proceso registro 4100 regenerado */
					while (dbnextrow(dbproc4100bis) != NO_MORE_ROWS) 
					{
							cadenareg4100bis[0]='\0';
							sprintf(contadorstr,"%d",contador);
							sprintf(contadorstrpaso, "%06s", contadorstr);
							/*strcat(cadenareg4100bis,campo4100_1);*/
							strcat(cadenareg4100bis,recid4100);
							strcat(cadenareg4100bis,icanumero4100);
							strcat(cadenareg4100bis,icanumbanco4100);
							strcat(cadenareg4100bis,corporationnumber4100);
							/*strcat(cadenareg4100bis,campo4100_2);*/
							strcat(cadenareg4100bis,reservedforinternaluse14100);
							strcat(cadenareg4100bis,reservedforinternaluse24100);
							strcat(cadenareg4100bis,reservedforinternaluse34100);
							strcat(cadenareg4100bis,organizationpointnumber4100);
							/*strcat(cadenareg4100bis,campo4100_3);*/
							strcat(cadenareg4100bis,freeformattext4100);
							strcat(cadenareg4100bis,organizationpointnameline14100);
							strcat(cadenareg4100bis,organizationpointnameline24100);
							strcat(cadenareg4100bis,addressline14100);
							strcat(cadenareg4100bis,addressline24100);
							strcat(cadenareg4100bis,city4100);
							strcat(cadenareg4100bis,stateprovince4100);
							strcat(cadenareg4100bis,country4100);
							strcat(cadenareg4100bis,postalcode4100);
							strcat(cadenareg4100bis,currencycode4100);
							/*strcat(cadenareg4100bis,campo4100_4);*/
							strcat(cadenareg4100bis,contactperson4100);
							strcat(cadenareg4100bis,phonenumber4100);
							strcat(cadenareg4100bis,faxnumber4100);
							strcat(cadenareg4100bis,emailaddress4100);
							strcat(cadenareg4100bis,budgetlimit4100);
							strcat(cadenareg4100bis,totalaccounts4100);
							strcat(cadenareg4100bis,accountspastdue4100);
							strcat(cadenareg4100bis,accountswithdispute4100);
							strcat(cadenareg4100bis,numberofcards4100);
							strcat(cadenareg4100bis,chargeoffsign4100);
							strcat(cadenareg4100bis,chargeoffamount4100);
							strcat(cadenareg4100bis,pastdueamountsign4100);
							strcat(cadenareg4100bis,pastdueamount4100);
							strcat(cadenareg4100bis,disputeamountsign4100);
							strcat(cadenareg4100bis,disputeamount4100);
							strcat(cadenareg4100bis,creditlimitsign4100);
							/*strcat(cadenareg4100bis,campo4100_5);*/
							strcat(cadenareg4100bis,creditlimit4100);
							strcat(cadenareg4100bis,paymentduesign4100);
							strcat(cadenareg4100bis,paymentdue4100);
							strcat(cadenareg4100bis,outstandingbalancesign4100);
							strcat(cadenareg4100bis,outstandingbalance4100);
							strcat(cadenareg4100bis,numberofdebits4100);
							strcat(cadenareg4100bis,numberofcredits4100);
							strcat(cadenareg4100bis,amountofdebits4100);
							strcat(cadenareg4100bis,amountofcredits4100);
							strcat(cadenareg4100bis,numberaccountsoverlimit4100);
							strcat(cadenareg4100bis,portfoliodate4100);
							strcat(cadenareg4100bis,addressmaintenanceaction4100);
							strcat(cadenareg4100bis,contadorstrpaso);
							strcat(cadenareg4100bis,outgoing4100);
							/* Graba el registro en el archivo */
							strcpy(buf4100bis,cadenareg4100bis);

							if ((fprintf(archcdf,"%s\n",buf4100bis)) == -1)
							{
									printf("El registro no se grabo\n");
									exit(1);
							}    
							else
							{
									contador = contador + 1;
							} 
					} /* fin del while del dbnext rows  registro 4100 */
					/* proceso registro 4200 regenerado */
					while (dbnextrow(dbproc4200) != NO_MORE_ROWS) 
					{
							cadenareg4200[0]='\0';
							sprintf(contadorstr,"%d",contador);
							sprintf(contadorstrpaso, "%06s", contadorstr);
							/*strcat(cadenareg4200,campo4200_1);*/
							strcat(cadenareg4200,recid4200);
							strcat(cadenareg4200,icanumero4200);
							strcat(cadenareg4200,icanumbanco4200);
							strcat(cadenareg4200,corporationnumber4200);
							strcat(cadenareg4200,reservedforinternaluse14200);
							strcat(cadenareg4200,reservedforinternaluse24200);
							strcat(cadenareg4200,reservedforinternaluse34200);
							strcat(cadenareg4200,organizationPointNumber4200);
							/*strcat(cadenareg4200,campo4200_2);*/
							strcat(cadenareg4200,freeformattext4200);
							strcat(cadenareg4200,reportsTo4200);
							strcat(cadenareg4200,reportstofreeformattext4200);
							strcat(cadenareg4200,reservedforinternaluse44200);
							strcat(cadenareg4200,organizationhierarchymainact4200);
							strcat(cadenareg4200,contadorstrpaso);
							strcat(cadenareg4200,outgoingIncomingErrorCode4200);
							/* Graba el registro en el archivo */
							strcpy(buf4200,cadenareg4200);

							if ((fprintf(archcdf,"%s\n",buf4200)) == -1)
							{
									printf("El registro no se grabo\n");
									exit(1);
							}    
							else
							{
									contador = contador + 1;
							}
					} /* fin del dbnextrows del registro 4200 */
					/* proceso registro 4300 regenerado */
					do 
					{        
							cadenareg4300[0]='\0';
							sprintf(contadorstr,"%d",contador);
							sprintf(contadorstrpaso, "%06s", contadorstr);
							/*strcat(cadenareg4300,campo4300_1);*/
							strcat(cadenareg4300,recid4300);
							strcat(cadenareg4300,icanumero4300);
							strcat(cadenareg4300,icanumbanco4300);
							strcat(cadenareg4300,corporationnumber4300);
							/*strcat(cadenareg4300,campo4300_2);*/
							strcat(cadenareg4300,reservedforinternaluse14300);
							strcat(cadenareg4300,reservedforinternaluse24300);
							strcat(cadenareg4300,reservedforinternaluse34300);
							strcat(cadenareg4300,reportstoorgpointnumber4300);
							strcat(cadenareg4300,reportstofreeformattext4300);
							strcat(cadenareg4300,accountnumber4300);
							/*strcat(cadenareg4300,campo4300_3);*/
							strcat(cadenareg4300,corporateproduct4300);
							strcat(cadenareg4300,effectivedate4300);
							strcat(cadenareg4300,expirationdate4300);
							strcat(cadenareg4300,accountnameline14300);
							strcat(cadenareg4300,accountnameline24300);
							strcat(cadenareg4300,accountaddressline14300);
							strcat(cadenareg4300,accountaddressline24300);
							strcat(cadenareg4300,accountcity4300);
							strcat(cadenareg4300,accountstateprovince4300);
							strcat(cadenareg4300,accountcountry4300);
							strcat(cadenareg4300,accountpostalcode4300);
							strcat(cadenareg4300,accountphonenumber4300);
							strcat(cadenareg4300,accountfaxnumber4300);
							/*strcat(cadenareg4300,campo4300_4);*/
							strcat(cadenareg4300,internalauditcode4300);
							strcat(cadenareg4300,employeeid4300);
							strcat(cadenareg4300,dailynumberlimitoftransactions4300);
							strcat(cadenareg4300,singletransactiondollarlimit4300);
							strcat(cadenareg4300,dailytransactiondollarlimit4300);
							strcat(cadenareg4300,cyclenumberoftransactionlimit4300);
							strcat(cadenareg4300,cycledollarlimit4300);
							strcat(cadenareg4300,monthlynumlimitoftran4300);
							strcat(cadenareg4300,monthlydollarlimit4300);
							strcat(cadenareg4300,othernumberoftransactionlimit4300);
							strcat(cadenareg4300,otherdollarlimit4300);
							strcat(cadenareg4300,taxexemptindicator4300);
							strcat(cadenareg4300,currencycode4300);
							strcat(cadenareg4300,statementdate4300);
							strcat(cadenareg4300,previousbalancesign4300);
							strcat(cadenareg4300,previousbalance4300);
							strcat(cadenareg4300,endingbalancesign4300);
							strcat(cadenareg4300,endingbalance4300);
							strcat(cadenareg4300,paymentduesign4300);
							strcat(cadenareg4300,paymentduebalance4300);
							/*strcat(cadenareg4300,campo4300_5);*/
							strcat(cadenareg4300,creditlimitsign4300);
							strcat(cadenareg4300,creditlimit4300);
							strcat(cadenareg4300,pastdueamountsign4300);
							strcat(cadenareg4300,pastduebalance4300);
							strcat(cadenareg4300,chargeoffsign4300);
							strcat(cadenareg4300,chargeoffamount4300);
							strcat(cadenareg4300,disputeamountsign4300);
							strcat(cadenareg4300,disputeamount4300);
							strcat(cadenareg4300,numberpaymentspastdue4300);
							strcat(cadenareg4300,highestdelinquencyperiod4300);
							strcat(cadenareg4300,accountindisputeflags4300);
							strcat(cadenareg4300,addressmaintenanceactioncode4300);
							strcat(cadenareg4300,contadorstrpaso);
							strcat(cadenareg4300,outgoing4300);
							/* Graba el registro en el archivo */
							strcpy(buf4300,cadenareg4300);
							if( renglon4300 > 0 ) 
							{
									if ((fprintf(archcdf,"%s\n",buf4300)) == -1)
									{
											printf("El registro no se grabo\n");
											exit(1);
									} 
									else 
									{
											contador=contador+1;
									}
							}
					} while (dbnextrow(dbproc4300) != NO_MORE_ROWS) ;
					/* fin while dbnextrows de registro 4300 */
					/* proceso registro 5000 regenerado */
					do 
					{
							cadenareg5000bis[0]='\0';
							sprintf(contadorstr, "%d", contador);
							sprintf( contadorstrpaso, "%06s", contadorstr);
							strcat(cadenareg5000bis, recid5000);
							strcat(cadenareg5000bis, icanumero5000);
							strcat(cadenareg5000bis, icanumbanco5000);
							strcat(cadenareg5000bis, corporationnumber5000);
							strcat(cadenareg5000bis, addendumtype5000);
							strcat(cadenareg5000bis, reservado15000);
							strcat(cadenareg5000bis, reservado25000);
							strcat(cadenareg5000bis, merchantacttranoriginind5000);
							strcat(cadenareg5000bis, accountnumber5000);
							strcat(cadenareg5000bis, reservedforinternaluse35000);
							strcat(cadenareg5000bis, acquirersorissuersrefnum5000);
							strcat(cadenareg5000bis, recordtype5000);
							strcat(cadenareg5000bis, transactiontype5000);
							strcat(cadenareg5000bis, debitcreditindicator5000);
							strcat(cadenareg5000bis, transactionamount5000);
							strcat(cadenareg5000bis, postingdate5000);
							strcat(cadenareg5000bis, transactiondate5000);
							strcat(cadenareg5000bis, processingdate5000);
							strcat(cadenareg5000bis, merchantname5000);
							strcat(cadenareg5000bis, merchantcity5000);
							strcat(cadenareg5000bis, merchantstateprovince5000);
							strcat(cadenareg5000bis, merchantcountry5000);
							strcat(cadenareg5000bis, merchantcategorycode5000);
							strcat(cadenareg5000bis, amountinoriginalcurrency5000);
							strcat(cadenareg5000bis, originalcurrencycode5000);
							strcat(cadenareg5000bis, currconvdatejulian5000);
							strcat(cadenareg5000bis, postedcurrencycode5000);
							strcat(cadenareg5000bis, conversionrate5000);
							strcat(cadenareg5000bis, conversionexponent5000);
							strcat(cadenareg5000bis, acquiringica5000);
							strcat(cadenareg5000bis, customercode5000);
							strcat(cadenareg5000bis, salestaxamount5000);
							strcat(cadenareg5000bis, reservado45000);
							strcat(cadenareg5000bis, reservado55000);
							strcat(cadenareg5000bis, freightamount5000);
							strcat(cadenareg5000bis, destinationpostalcode5000);
							strcat(cadenareg5000bis, merchanttype5000);
							strcat(cadenareg5000bis, merchantlocationpostalcod5000);
							strcat(cadenareg5000bis, dutyamount5000);
							strcat(cadenareg5000bis, merchantfederaltaxid5000);
							strcat(cadenareg5000bis, merchantstateprovincecode5000);
							strcat(cadenareg5000bis, shipfrompostalcode5000);
							strcat(cadenareg5000bis, alternatetaxamount5000);
							strcat(cadenareg5000bis, destinationcountrycode5000);
							strcat(cadenareg5000bis, merchantreferencenumber5000);
							strcat(cadenareg5000bis, alternatetaxindicator5000);
							strcat(cadenareg5000bis, alternatetaxidentifier5000);
							strcat(cadenareg5000bis, salestaxcollectedindpos5000);
							strcat(cadenareg5000bis, addendumdetailindicator5000);
							strcat(cadenareg5000bis, merchantid5000);
							strcat(cadenareg5000bis, banknetreferencenumber5000);
							strcat(cadenareg5000bis, approvalcode5000);
							strcat(cadenareg5000bis, adjustmentreasoncode5000);         
							strcat(cadenareg5000bis, adjustmentdescription5000);
							strcat(cadenareg5000bis, mantenimiento5000);
							strcat(cadenareg5000bis, contadorstrpaso);
							strcat(cadenareg5000bis, outgoing5000);
							/* Graba el registro en el archivo */
							strcpy(buf5000bis,cadenareg5000bis);

							if ((fprintf(archcdf,"%s\n",buf5000bis)) == -1)
							{
									printf("El registro no se grabo\n");
									exit(1);
							}    
							else
							{
									contador=contador+1;
							}
					} while (dbnextrow(dbproc5000bis) != NO_MORE_ROWS); 
					/* fin while dbnextrows del registro 5000 */
					sprintf(contadorstr, "%d", contador);                                       
					sprintf( contadorstrpaso, "%06s", contadorstr);
                                       
			} /* fin del if bandera sigue == 1 */ 
			/*****************************************************************************/
			/* registro 9999   */
			strcpy(query, DevQry(99));
			dbcmd(dbproc9999, query); /*QUERY PARA EL REGISTRO 5000*/
			dbsqlexec(dbproc9999);
			while ((result_code = dbresults(dbproc9999)) != NO_MORE_RESULTS)
			{
					if ((dbrows(dbproc9999) != 0) || (result_code == SUCCEED))
					{
							/*dbbind(dbproc9999, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)largoreg9999);*/
							dbbind(dbproc9999, 1, STRINGBIND, (DBINT)0, (BYTE DBFAR *)recid9999);
							dbbind(dbproc9999, 2, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumero9999);
							dbbind(dbproc9999, 3, STRINGBIND, (DBINT)0, (BYTE DBFAR *)icanumbanco9999);
							dbbind(dbproc9999, 4, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse19999);
							dbbind(dbproc9999, 5, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse29999);
							dbbind(dbproc9999, 6, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse39999);
							dbbind(dbproc9999, 7, STRINGBIND, (DBINT)0, (BYTE DBFAR *)reservedforinternaluse49999);
							dbbind(dbproc9999, 8, STRINGBIND, (DBINT)0, (BYTE DBFAR *)outgoingincomingerrorcode9999);
							while (dbnextrow(dbproc9999) != NO_MORE_ROWS)
							{
									cadenareg9999[0]='\0';
									/*strcat(cadenareg9999, largoreg9999);*/
									strcat(cadenareg9999,recid9999);
									strcat(cadenareg9999,icanumero9999);
									strcat(cadenareg9999,icanumbanco9999);
									strcat(cadenareg9999,reservedforinternaluse19999);
									strcat(cadenareg9999,reservedforinternaluse29999);
									strcat(cadenareg9999,reservedforinternaluse39999);
									strcat(cadenareg9999,reservedforinternaluse49999);
									strcat(cadenareg9999,contadorstrpaso);
									strcat(cadenareg9999,contadorstrpaso);
									strcat(cadenareg9999,outgoingincomingerrorcode9999);
									/* Graba el registro en el archivo */
									strcpy(buf9999,cadenareg9999);

									if ((fprintf(archcdf,"%s\n",buf9999)) == -1)
									{
											printf("El registro no se grabo\n");
											exit(1);
									}    
									else
									{
										contador =contador + 1;
									}
							}  /* fin while next row proceso registro 9999  */
					}   /* fin if proceso registro 9999 */
			}  /* fin while proceso registro 9999 */
		/* Limpia los dbproccess para no dejar nada en memoria. */
		dbcancel(dbproc1000);
		dbcancel(dbproc3000);
		dbcancel(dbproc4000);
		dbcancel(dbproc4100);
		dbcancel(dbproc4100bis);
		dbcancel(dbproc4200);
		dbcancel(dbproc4300);
		dbcancel(dbproc5000);
		dbcancel(dbproc5000bis);
		dbcancel(dbproc9999);
		printf("\n ********** FIN DEL PROCESO PARA GENERAR EL ARCHIVO CDF **********\n");
		/* Cierra el archivo */
		fclose(archcdf);
		printf("Hora de termino del proceso para generar el archivo CDF \n");   
		system("date \"+%I:%M:%S %p\"\n");                                       
		/* Cierra la conexion y sale del programa. */
		dbexit();
		exit(STDEXIT);
}  /*  Fin main  */
