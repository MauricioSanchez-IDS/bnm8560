/*
** r5000.c:      05/06/03
**
** Elaborado por: Jose Ramon Gonzalez Diaz
**
** Objetivo:
**     Seleccionar el detalle de movimientos realizados en el rango de fechas
**     establecidas incluyendo las estructuras jerarquicas.
**
** Historia:
**     1. Se Corrige BCP y Error en Query
*/

#if USE_SCCSID
static char Sccsid[] = {"@(#) r5000.c 87.1 01/03/01"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include <ctype.h>
#include "sybdbex.h"
#include "camFTO.h"  /*formato de los campos */
#include "cam5000.h" /*campos 5000*/
#include "fechas.h"

#define CADENAREG5000 538                    /*Se actualiz'o de 520 a 538, IERM Sept. 15, 2004*/
#define TOTALPARAMETROS 8

/* variables globales para el manejo de los argumentos de fechayhora y nombredel archivo a generar */
char fechayhora[20];
char nombrearchivo[60];
char sqlcmd[5000];

/* Forward declarations of the error handler and message handler. */
int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();
void convfechjuliana();
void redondea( char * );
char * formateaTasa( char * );
int calcfeclimpago(char * fecha);

/**
  *  formateaTasa
  **/

char * formateaTasa( char * cifra ){

 char entero[ 9 + 1 ];
 char fraccion[ 7 + 1 ];
 char *pFormat=NULL;
 static char formateado[ 16 + 1 ];

 strncpy( entero, cifra, 9 );

 strncpy( fraccion, &cifra[ 10 ], 6 );
 fraccion[ 6 ] = '0';
 fraccion[ 7 ] = '\0';

 strcpy( formateado, entero );
 strcat( formateado, fraccion );

 pFormat=formateado;

 return pFormat;
}


/**
  *  Funcion redondeo2. Funcion que redondea un numero con 2 cifras de presicion
  **/

void redondeo( char *cifra ){

 char res[ 16 + 1 ];
 long int n_entero;
 long int n_fraccion;
 float resultado;
 char *entero;
 char *fraccion;
 char *aux;
 int presicion;
 int longitud;
 int lon_frac;
 int punto;
 int caso;
 int factor = 1;
 char ch;

 //Sacamos la longitud del numero
 longitud = strlen( cifra );

 //Sacamos la localizacion del punto
 for( int i = 0 ; i < longitud ; i++ )
  if( cifra[ i ] == '.' ){
   punto = i;
   break;
  }

 //Separamos la parte entera
 entero = (char *) malloc( sizeof( char ) * (punto + 1) ); //asignamos memoria
 strncpy( entero, cifra, punto );    //Copiamos la parte entera
 entero[ punto + 1 ] = '\0';     //Nulo al final
 n_entero = atol( entero );

 //Separamos la parte fraccionaria
 fraccion = (char *)malloc( sizeof( char ) * 9 );  //Asignando memoria

 for( int i = punto + 1, j = 0 ; j < 8 ; i++, j++ )  //Copiando
  if( i < longitud )
   fraccion[ j ] = cifra[ i ];
  else       //Relleno de 0
   fraccion[ j ] = '0';

 fraccion[ 7 ] = '\0';      //Nulo al final

 for( int i = 0 ; i < 8 ; i++ )     //Primer digito distinto de 0 despues del punto
  if( fraccion[ i ] > 48 && fraccion[ i ] < 58 ){
   caso = i;
   break;
  }

 if( n_entero <= 0 )      //Presicion Caso Critico
  presicion = 4;
 else{        //Presicion Caso normal
  if( n_entero  < 10 )
   presicion = 4;
  else
   presicion = 3;
  caso = 0;
 }

 for( int i = caso + presicion ; i < 7 ; i++ )   //Quito los digitos inservibles
  fraccion[ i ] = '0';

 for( int i = 7 ; i >= 0 ; i-- )
  if( fraccion[ i ] >48 && fraccion[ i ] < 58 )
   break;
  else
   factor *= 10;

 n_fraccion = atol( fraccion );     //Convertimos a numero
 ch = fraccion[ caso + presicion - 1 ];

 if( atol(&ch) >= 5 )
  n_fraccion += (factor);     //Redondeo

 n_fraccion -= (atol( &ch ) * (factor/10));
 resultado = n_entero + ((float)n_fraccion / (float)10000000);
 sprintf(res, "%016f", resultado);
 aux = formateaTasa( res );
 strcpy( conversionrate, aux );
 free( fraccion );
 free( entero );
 return;
}

/***************************************************************************************************/

main(argc, argv)
int argc;
char *argv[];
{
 FILE *reg5000;
 DBPROCESS *q_dbproc;     /* Nuestra conexion con el servidor SQL*/
 LOGINREC  *login;        /* nuestra informacion de login */
/*longitud del registro*/
char cadenareg5000[CADENAREG5000+54+1]; /*se agregan 54 espacios para tabulador*/
time_t lcl_time;
struct tm *today;
int  cont1,cont2,dec;
float tasaConversion;
int monedaUsual;
int es_num;

/*Variables para Calculo de Fecha Limite de Pago*/
char prodemp[11+1];
char feclimpago[8+1];
char feclimpagosig[8+1];
char fecCorte[8+1];
char fecHoy[8+1];
DBCHAR corte_emp[2+1];
int Anioaux, Mesaux, fecCorteNum, fecHoyNum, fecPosteoNum, fecCorteAnt;
char anio_s[4+1];
char mes_s[2+1];
char dia_s[2+1];

typedef struct {
	char	cod2[2 + 1];
	char	cod3[3 + 1];
	char	moneda_num[3 + 1];
	char	moneda_alf[3 + 1];
} CODIGO_PAIS;

typedef struct {
	char	moneda_num[3 + 1];
	char	moneda_alf[3 + 1];
	float	tasa_rango1;
	float	tasa_rango2;
} MONEDAS;

CODIGO_PAIS arreglo_pais[300];
MONEDAS monedas_usuales[300];

int contadorMonUsu;
int totalMonUsu;

DBCHAR          cod2_pais[2 + 1];
DBCHAR          cod3_pais[3 + 1];
DBCHAR          moneda_num[3 + 1];
DBCHAR          moneda_alf[3 + 1];
DBCHAR          tipo[1 + 1];
DBCHAR          tasa1[16 + 1]; /*8 enteros, punto y 7 decimales*/
DBCHAR          tasa2[16 + 1]; /*8 enteros, punto y 7 decimales*/
RETCODE         result_code;

int             tipo_pais;
int contadorPais;
int totalPais;
int j;
int i;
char num[2];
long entero;
char *p;
char ge_user[10];
char ge_password[10];
char ge_server[10];
char ge_hostname[10];
char ge_dbase[10];

/*variables para armar el where*/
char fecIni[8+1];
char fecFin[8+1];
char corte[40+1];
char cortenum[4+1];
char ejePrefijo[4+1];
char gpoBanco[2+1];
char empNumero[5+1];
char cadena[50];
char directorio_archivo[50];
char nombrearchivo_temp[100];
char caracter[2];
char cad_car[16];
int contador;
int paisdesconocido;

/*variables para determinar el mcc*/
char ftoNegocio[10+1];
char ult4Posiciones[4+1];
char ftoLeyenda[26+1];
char ult4Leyenda[4+1];
char conversionrate1[16+1];
char conversionrate2[16+1];
char conversionrate3[16+1];
char conversionrate4[16+1];
char valor_mcc[4+1];
char posicion5[1+1];
char posicion6y7[2+1];
char cadena_aux[50];
char bulkcopy[100];
char organizationpointnumber[16+1];
char * aux;

/* variables globales para el manejo de los argumentos
   de fecha proceso y nombre del archivo a generar  */
extern char fechayhora[20];
extern char nombrearchivo[60];
extern char sqlcmd[5000];

/* variables para MTCICA01 */
DBCHAR issuerIca[11+1];    /*Se actualiz'o de 5 a 11, IERM Sept. 15, 2004 */
DBCHAR issuerNumberIca[11+1];
DBCHAR originalCurrencyCode[3+1];
char arregloPais2[500][2+1];
char arregloPais3[500][3+1];
char arregloMoneda3[500][3+1];
char currencyInternacional[ 3+1 ];

/*variables utilizadas para almacenar informacisn
  obtenida de la consulta a la tabla REGT5000*/
 DBCHAR numEmpresa     [16+1];
 DBCHAR numCuenta      [16+1];
 DBCHAR fecValor       [8+1];
 DBCHAR fecProceso     [8+1];
 DBCHAR fecPosteo      [8+1];
 DBCHAR numNegocio     [10+1];
 DBCHAR importe        [18+1];
 DBCHAR dolares        [18+1];
 DBCHAR importe1       [18+1];
 DBCHAR dolares1       [18+1];
 DBCHAR merchantname1  [25+1];
 DBCHAR fechajuliana   [5+1];
 DBCHAR transaccion    [4+1];
 DBCHAR referencia     [23+1];
 DBCHAR cicloCorte     [4+1];
 DBCHAR pais           [3+1];
 DBCHAR leyenda        [26+1];
 DBCHAR pobNego        [14+1];
 DBCHAR desTran        [10+1];
 DBCHAR claveTran      [5+1];
 DBCHAR claveTran1      [5+1];
 DBCHAR clasifTran     [1+1];
 DBCHAR signoTran      [1+1];
 DBCHAR b06Acd         [4+1];
 DBCHAR referencia_a   [4+1];
 DBCHAR orgpointnum    [16+1];
 DBCHAR unitpadre      [16+1];
 DBCHAR paisVisa       [2+1];
 DBCHAR currencyCode   [3+1];

 fflush(stdout);
 /* checa que se hayan pasado los parametros correspondientes*/
 if ((argc > TOTALPARAMETROS) || (argc < TOTALPARAMETROS))
 {
  printf("Programa: r5000.c \n");
  printf("El numero de argumentos no son validos para el programa r5000.c\n");
  exit(1);
 }

 /*obtiene fecha y hora del proceso */
 time(&lcl_time);
 today = localtime(&lcl_time);
 strftime(fechayhora,20,"%Y%m%d %T",today);
 /* variables globales para el manejo de los argumentos
   nombre del archivo CDF a generar y el rango de fechas de los movimientos*/
 strcpy(nombrearchivo,argv[1]);
 strcpy(ejePrefijo,argv[2]);
 strcpy(gpoBanco,argv[3]);
 strcpy(numEmpresa,argv[4]);
 strcpy(fecIni, argv[5]);
 strcpy(fecFin, argv[6]);
 strcpy(corte, argv[7]);

 if( dbinit() == FAIL)
 {
  /* registro del error en el archivo log */
  printf("Fecha proceso: %s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: 5000.c \n");
  printf("Error: No se inicializaron las dblibrary de C en el programa r5000.c\n");
  exit(1);
 }

 /*instala las rutinas de manejo de errores y mensajes. Estan definidas
   al final de este programa */
 dberrhandle((EHANDLEFUNC)err_handler);
 dbmsghandle((MHANDLEFUNC)msg_handler);

 /*obtencion de la informacion de ambiente*/
 sprintf(ge_user,"%s",getenv("GE_USER"));
 sprintf(ge_password,"%s",getenv("GE_PASSWORD"));
 sprintf(ge_server,"%s",getenv("GE_SERVER"));
 sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));
 sprintf(ge_dbase,"%s",getenv("GE_DBASE"));
 sprintf(directorio_archivo,"%s",getenv("DIR_TEMP"));

 if( ( (strlen(ge_user) == 0)   || (strlen(ge_password) == 0)  ||  (strlen(ge_server) == 0) || (strlen(ge_hostname) == 0)  ||
   (strlen(ge_dbase) == 0)  || (strlen(directorio_archivo) == 0) ) )
 {
  printf("Fecha proceso: %s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: 5000.c \n");
  printf("Error: debe verificar las variables de ambiente\n");
  exit(1);
 }

 /* Inicializacion de la biblioteca de fechas incluir path de archivo */
 if(iInitFecha(directorio_archivo) == INTERNA )
    printf("Se toma tabla interna de dias inhabiles\n");
 else
    printf("Se toma archivo de dias inhabiles: %s/dias_festivos.txt \n",directorio_archivo);

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

 /*nos ubicamos en la base de datos */
 dbuse(q_dbproc, ge_dbase);
 sprintf(nombrearchivo_temp,"%s/reg5000.txt",directorio_archivo);
 printf("Hora de inicio del programa r5000: %s\n",fechayhora);

 /* se borra la tabla REG5000 si existe */
 sprintf(sqlcmd,"if object_id('dbo.REG5000') is not null ");
 strcat(sqlcmd," begin                               ");
 strcat(sqlcmd,"  drop table dbo.REG5000                ");
 strcat(sqlcmd," end                                 ");
 dbcmd(q_dbproc, sqlcmd);

 if( dbsqlexec(q_dbproc) == FAIL)
 {
  printf("Fecha proceso: %s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: r5000.c \n");
  printf("Error: Fallo al intentar borrar la tabla REG5000 dbsqlexec\n");
  dbclose(q_dbproc);
  dbexit();
  exit(ERREXIT);
 }

 dbcancel(q_dbproc);
 /* se crea la tabla REG5000 */
 sprintf(sqlcmd,"select * into REG5000 ");
 strcat(sqlcmd, "from MTC5000 where 1=2 ");
 dbcmd(q_dbproc, sqlcmd);
 if( dbsqlexec(q_dbproc) == FAIL)
 {
  printf("Fecha proceso: %s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: r5000.c \n");
  printf("Fallo al intentar crear la tabla REG5000 dbsqlexec\n");
  dbclose(q_dbproc);
  dbexit();
  exit(ERREXIT);
 }

 /*informacion de MTCICA01*/
 sprintf(sqlcmd,"select icaNumero, icaNumBanco, currency ");
 strcat(sqlcmd,"from MTCICA01");
 dbcmd(q_dbproc, sqlcmd);
 if( dbsqlexec(q_dbproc) == FAIL)
 {
  printf("Fecha proceso:%s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: r5000.c \n");
  printf("Error: Fallo al intentar traer datos de MTCICA01 bdsqlexec \n");
  dbclose(q_dbproc);
  dbexit();
  exit(ERREXIT);
 }
 dbresults(q_dbproc);
 if( DBROWS(q_dbproc) != SUCCEED)
 {
  printf("Fecha proceso:%s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: r5000.c \n");
  printf("Fallo al intentar traer datos de MTCICA01 DBROWS\n");
  dbclose(q_dbproc);
  dbexit();
  exit(ERREXIT);
 }
 dbbind(q_dbproc, 1, STRINGBIND,(DBINT)0, (BYTE DBFAR *)issuerIca);
 dbbind(q_dbproc, 2, STRINGBIND,(DBINT)0, (BYTE DBFAR *)issuerNumberIca);
 dbbind(q_dbproc, 3, STRINGBIND,(DBINT)0, (BYTE DBFAR *)originalCurrencyCode);
 while (dbnextrow(q_dbproc) != NO_MORE_ROWS);

 /*informacion de MTCEMP01*/
 strcpy(sqlcmd,"select emp_dia_corte from MTCEMP01 \n");
 strcat(sqlcmd,"where eje_prefijo=5473 and gpo_banco=80 and emp_num=16200 \n");
 dbcmd(q_dbproc, sqlcmd);
 if( dbsqlexec(q_dbproc) == FAIL)
 {
  printf("Fecha proceso:%s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: r5000.c \n");
  printf("Error: Fallo al intentar traer datos de MTCEMP01 bdsqlexec \n");
  dbclose(q_dbproc);
  dbexit();
  exit(ERREXIT);
 }
 dbresults(q_dbproc);
 if( DBROWS(q_dbproc) != SUCCEED)
 {
  printf("Fecha proceso:%s\n", fechayhora);
  printf("Nombre archivo: %s\n", nombrearchivo);
  printf("Programa: r5000.c \n");
  printf("Fallo al intentar traer datos de MTCEMP01 DBROWS\n");
  dbclose(q_dbproc);
  dbexit();
  exit(ERREXIT);
 }
 dbbind(q_dbproc, 1, STRINGBIND,(DBINT)0, (BYTE DBFAR *) corte_emp);
 while (dbnextrow(q_dbproc) != NO_MORE_ROWS);

 if ( strlen(corte_emp) > 0 )
 {
  fecHoy[0]='\0';
  strncpy(fecHoy,&fechayhora[0],8);
  fecHoy[8]='\0';

  if ( strlen(corte_emp) == 1)
  {
    dia_s[0]='\0';
    strcat(dia_s,"0");
    strcat(dia_s,corte_emp);
    corte_emp[0]='\0';
    strcat(corte_emp,dia_s);
    strcat(dia_s,corte_emp);
    corte_emp[strlen(corte_emp)]='\0';
  }

  printf("Corte para LG es : %s \n",corte_emp);

  fecCorte[0]='\0';
  strncpy(fecCorte,&fechayhora[0],6);
  fecCorte[6]='\0';
  strcat(fecCorte,corte_emp);
  fecCorte[strlen(fecCorte)]='\0';

  fecCorteNum=atoi(fecCorte);
  fecHoyNum=atoi(fecHoy);

  printf("Fecha de Hoy : %d \n",fecHoyNum);
  printf("Fecha de Corte : %d \n",fecCorteNum);

  if ( fecCorteNum > fecHoyNum )
  {
   printf("Fecha de Corte > Fecha de Hoy \n");
   feclimpagosig[0]='\0';
   strcat(feclimpagosig,fecCorte);
   feclimpagosig[strlen(feclimpagosig)]='\0';

   printf("La Fecha Limite de Pago sig antes de calculo : %s \n",feclimpagosig);

   if (calcfeclimpago(feclimpagosig) != 0)
   {
    printf("Fecha proceso:%s\n", fechayhora);
    printf("Nombre archivo: %s\n", nombrearchivo);
    printf("Programa: r5000.c \n");
    printf("Fallo calculo de fecha limite de pago corte actual \n");
    dbclose(q_dbproc);
    dbexit();
    exit(ERREXIT);
   }
   else
   {
    printf("La Fecha Limite de Pago Corte siguiente Calculada para LG es : %s \n",feclimpagosig);
    strncpy(anio_s,fecCorte,4);
    anio_s[4]='\0';
    strncpy(mes_s,&fecCorte[4],2);
    mes_s[2]='\0';
    Anioaux=atoi(anio_s);
    Mesaux =atoi(mes_s);

    if (Mesaux == 1)
    {
     Anioaux=Anioaux-1;
     Mesaux=12;
     anio_s[0]='\0';
     mes_s[0]='\0';
     sprintf(anio_s,"%04d",Anioaux);
     sprintf(mes_s,"%02d",Mesaux);
    }
    else
    {
     Mesaux=Mesaux-1;
     mes_s[0]='\0';
     sprintf(mes_s,"%02d",Mesaux);
    }

    feclimpago[0]='\0';
    strcat(feclimpago,anio_s);
    strcat(feclimpago,mes_s);
    strcat(feclimpago,corte_emp);
    feclimpago[strlen(feclimpago)]='\0';

    printf("La Fecha Limite de Pago antes de calculo : %s \n",feclimpago);

    fecCorteAnt=atoi(feclimpago);

    if (calcfeclimpago(feclimpago) != 0)
    {
     printf("Fecha proceso:%s\n", fechayhora);
     printf("Nombre archivo: %s\n", nombrearchivo);
     printf("Programa: r5000.c \n");
     printf("Fallo calculo de fecha limite de pago siguiente corte \n");
     dbclose(q_dbproc);
     dbexit();
     exit(ERREXIT);
    }
    else
     printf("La Fecha Limite de Pago Corte anterior Calculada para LG es : %s \n",feclimpago);
   }
  }
  else
  {

   printf("Fecha de Corte <= Fecha de Hoy \n");

   feclimpago[0]='\0';
   strcat(feclimpago,fecCorte);
   feclimpago[strlen(feclimpago)]='\0';

   printf("La Fecha Limite de Pago antes de calculo : %s \n",feclimpago);

   fecCorteAnt=atoi(feclimpago);

   if (calcfeclimpago(feclimpago) != 0)
   {
    printf("Fecha proceso:%s\n", fechayhora);
    printf("Nombre archivo: %s\n", nombrearchivo);
    printf("Programa: r5000.c \n");
    printf("Fallo calculo de fecha limite de pago corte actual \n");
    dbclose(q_dbproc);
    dbexit();
    exit(ERREXIT);
   }
   else
   {
    printf("La Fecha Limite de Pago Corte anterior Calculada para LG es : %s \n",feclimpago);
    strncpy(anio_s,fecCorte,4);
    anio_s[4]='\0';
    strncpy(mes_s,&fecCorte[4],2);
    mes_s[2]='\0';
    Anioaux=atoi(anio_s);
    Mesaux =atoi(mes_s);

    if (Mesaux == 12)
    {
     Anioaux=Anioaux+1;
     Mesaux=1;
     anio_s[0]='\0';
     mes_s[0]='\0';
     sprintf(anio_s,"%04d",Anioaux);
     sprintf(mes_s,"%02d",Mesaux);
    }
    else
    {
     Mesaux=Mesaux+1;
     mes_s[0]='\0';
     sprintf(mes_s,"%02d",Mesaux);
    }

    feclimpagosig[0]='\0';
    strcat(feclimpagosig,anio_s);
    strcat(feclimpagosig,mes_s);
    strcat(feclimpagosig,corte_emp);
    feclimpagosig[strlen(feclimpagosig)]='\0';

    printf("La Fecha Limite de Pago sig antes de calculo : %s \n",feclimpagosig);

    if (calcfeclimpago(feclimpagosig) != 0)
    {
     printf("Fecha proceso:%s\n", fechayhora);
     printf("Nombre archivo: %s\n", nombrearchivo);
     printf("Programa: r5000.c \n");
     printf("Fallo calculo de fecha limite de pago siguiente corte \n");
     dbclose(q_dbproc);
     dbexit();
     exit(ERREXIT);
    }
    else
     printf("La Fecha Limite de Pago Corte Siguiente Calculada para LG es : %s \n",feclimpagosig);
   }
  }
 }
 else
  {
   printf("Fecha proceso:%s\n", fechayhora);
   printf("Nombre archivo: %s\n", nombrearchivo);
   printf("Programa: r5000.c \n");
   printf("Corte de empresa LG no valido %s \n",corte_emp);
   dbclose(q_dbproc);
   dbexit();
   exit(ERREXIT);
  }

 /**
   * Yuri: Extraemos la informaci'on de la tabla MTCPAIS01
   **/
strcpy(sqlcmd, " select ");
strcat(sqlcmd, " convert(char(2),rtrim(ltrim(alpha2_country_code))), ");
strcat(sqlcmd, " convert(char(3),rtrim(ltrim(alpha3_country_code))), ");
strcat(sqlcmd, " convert(char(3),rtrim(ltrim(numeric_currency_code))), ");
strcat(sqlcmd, " convert(char(3),rtrim(ltrim(alpha_currency_code))), ");
strcat(sqlcmd, " str(pais_tipo,1,0), ");
strcat(sqlcmd, " str(pais_tasa1,8,7), ");
strcat(sqlcmd, " str(pais_tasa2,8,7) ");
strcat(sqlcmd, " from ");
strcat(sqlcmd, "  MTCPAIS01 ");

dbcmd(q_dbproc, sqlcmd);

if( dbsqlexec(q_dbproc) == FAIL)
{
printf("Fecha proceso:%s\n", fechayhora);
printf("Nombre archivo: %s\n", nombrearchivo);
printf("Programa: r5000.c \n");
printf("Error: Fallo al intentar traer datos de MTCPAIS01 bdsqlexec \n");
dbclose(q_dbproc);
dbexit();
exit(ERREXIT);
}
dbresults(q_dbproc);

if( DBROWS(q_dbproc) != SUCCEED){
printf("Fecha proceso:%s\n", fechayhora);
printf("Nombre archivo: %s\n", nombrearchivo);
printf("Programa: r5000.c \n");
printf("Fallo al intentar traer datos de MTCPAIS01 DBROWS\n");
dbclose(q_dbproc);
dbexit();
exit(ERREXIT);
}

dbbind(q_dbproc, 1, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) cod2_pais);
dbbind(q_dbproc, 2, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) cod3_pais);
dbbind(q_dbproc, 3, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) moneda_num);
dbbind(q_dbproc, 4, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) moneda_alf);
dbbind(q_dbproc, 5, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) tipo);
dbbind(q_dbproc, 6, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) tasa1);
dbbind(q_dbproc, 7, STRINGBIND, (DBINT) 0, (BYTE DBFAR *) tasa2);

totalPais = 0;
contadorPais=0;
contadorMonUsu=0;
totalMonUsu=0;;

while (dbnextrow(q_dbproc) != NO_MORE_ROWS){
sprintf(arreglo_pais[contadorPais].cod2, "%-2s", cod2_pais);
sprintf(arreglo_pais[contadorPais].cod3, "%-3s", cod3_pais);
sprintf(arreglo_pais[contadorPais].moneda_num, "%-3s",moneda_num);
sprintf(arreglo_pais[contadorPais].moneda_alf, "%-3s",moneda_alf);
tipo_pais=atoi(tipo);
++contadorPais;
if( tipo_pais == 1)  /*PAIS CON MONEDA MUY USUAL*/
{
  sprintf(monedas_usuales[contadorMonUsu].moneda_num, "%-3s",moneda_num);
  sprintf(monedas_usuales[contadorMonUsu].moneda_alf, "%-3s",moneda_alf);
  monedas_usuales[contadorMonUsu].tasa_rango1=atof(tasa1);
  monedas_usuales[contadorMonUsu].tasa_rango2=atof(tasa2);
  ++contadorMonUsu;
}
}

totalPais = contadorPais;
totalMonUsu = contadorMonUsu;

 /**********************************************************************************/

   /* Preparo el archivo que se utilizara para realizar bulkcopy*/
   reg5000 = fopen(nombrearchivo_temp, "w");
   if (reg5000 == NULL)
   {
    /* registro del error en el archivo log */
    printf("Fecha proceso: %s\n", fechayhora);
    printf("Nombre archivo: %s\n",nombrearchivo);
    printf("Programa: r5000.c \n");
    printf("Error: No se pudo abrir el archivo de trabajo %s\n",nombrearchivo_temp);
    exit(1);
   }

   /*obtengo datos para llenar la tabla REG5000 */
   sprintf(sqlcmd," select distinct CtaCorp=convert(char(16), convert(char(4),\n");
   strcat(sqlcmd," A.eje_prefijo)+convert(char(2), A.gpo_banco)+\n");
   strcat(sqlcmd," replicate ('0', (select pgs_long_emp from MTCPGS01 i \n");
   strcat(sqlcmd," where i.pgs_rep_prefijo=A.eje_prefijo \n");
   strcat(sqlcmd,"and i.pgs_rep_banco=A.gpo_banco)- char_length(ltrim(rtrim(\n");
   strcat(sqlcmd,"str(A.emp_num)))))+ltrim(rtrim(str(A.emp_num)))+replicate \n");
   strcat(sqlcmd,"('0',(select pgs_long_eje from MTCPGS01 h \n");
   strcat(sqlcmd,"where h.pgs_rep_prefijo=A.eje_prefijo \n");
   strcat(sqlcmd,"and h.pgs_rep_banco=A.gpo_banco))+'9'+convert(char(1),(\n");
   strcat(sqlcmd,"select p.eje_digit from MTCPLA01 p where p.eje_roll_over=9\n");
   strcat(sqlcmd," and p.eje_prefijo=A.eje_prefijo \n");
   strcat(sqlcmd," and p.gpo_banco=A.gpo_banco and p.emp_num=A.emp_num \n");
   strcat(sqlcmd," and p.eje_num = 0))), \n");
   strcat(sqlcmd,"cuenta=convert(char(16),convert(char(4),A.eje_prefijo)+\n");
   strcat(sqlcmd,"convert(char(2),A.gpo_banco)+replicate ('0', \n");
   strcat(sqlcmd,"(select pgs_long_emp  from MTCPGS01 h \n");
   strcat(sqlcmd,"where h.pgs_rep_prefijo=A.eje_prefijo \n");
   strcat(sqlcmd,"and h.pgs_rep_banco=A.gpo_banco)-char_length(ltrim(rtrim(\n");
   strcat(sqlcmd,"str( A.emp_num)))))+ltrim(rtrim(str(A.emp_num)))+\n");
   strcat(sqlcmd,"replicate('0',(select pgs_long_eje from MTCPGS01 g \n");
   strcat(sqlcmd,"where g.pgs_rep_prefijo=A.eje_prefijo \n");
   strcat(sqlcmd,"and g.pgs_rep_banco=A.gpo_banco)-char_length(ltrim(rtrim(\n");
   strcat(sqlcmd,"str(A.eje_num)))))+ ltrim(rtrim(str(A.eje_num)))+\n");
   strcat(sqlcmd,"'9'+convert(char(1), (select eje_digit from MTCPLA01 f \n");
   strcat(sqlcmd," where f.eje_roll_over=9 and f.eje_prefijo=A.eje_prefijo \n");
   strcat(sqlcmd," and f.gpo_banco=A.gpo_banco and f.emp_num=A.emp_num \n");
   strcat(sqlcmd," and f.eje_num=A.eje_num))), A.his_valor_amd, \n");
   strcat(sqlcmd," fechaActual=convert(char(8),getdate(),112), \n");
   strcat(sqlcmd," A.his_proceso_amd, A.b01_neg_num_neg, \n");
   strcat(sqlcmd," importe=right('00000000000000000'+ltrim(str( \n");
   strcat(sqlcmd," A.his_importe,12,4)),17), A.his_transaccion, \n");
   strcat(sqlcmd,"referencia=right('0000000'+convert(char(7), \n");
   strcat(sqlcmd,"A.his_referencia_a),7)+right('0000000000000000'+ltrim(str(\n");
   strcat(sqlcmd,"A.his_referencia_b,16,0)),16), A.his_mes_y_ciclo_corte, \n");
   strcat(sqlcmd,"A.his_pais, A.his_negocio_leyenda, A.his_poblacion, \n");
   strcat(sqlcmd,"dolares=right('00000000000000000'+ltrim(str(\n");
   strcat(sqlcmd,"A.his_dolares,12,4)),17), \n");
   strcat(sqlcmd,"B.tip_transaccion,B.cve_transaccion,B.clasif_transaccion, \n");
   strcat(sqlcmd,"B.signo_transaccion, \n");
   strcat(sqlcmd,"b06Acd=isnull(substring(replicate('0',6-char_length(ltrim(\n");
   strcat(sqlcmd,"str(D.b06_acd_num_acd))))+rtrim(ltrim(str(\n");
   strcat(sqlcmd,"D.b06_acd_num_acd))),3,4),'0'), \n");
   strcat(sqlcmd,"ref_a=right('0000'+substring(convert(char(7), \n");
   strcat(sqlcmd,"A.his_referencia_a), 4, 4),4), \n");
   strcat(sqlcmd,"orgpointnum=E.eje_centro_c, \n");
   strcat(sqlcmd,"padre = U.unit_id  \n");
   strcat(sqlcmd,"from MTCHIS01 A, MTCTRA01 B, MTCEMP01 C, MTCNEG01 D, \n");
   strcat(sqlcmd,"MTCEJE01 E, MTCUNI01 U \n");
   strcat(sqlcmd," where \n");
   strcpy(cortenum,corte);
   if (strcmp(cortenum,"0") == 0) /* Proceso dirario o por rango de fechas */
   {
    strcat(sqlcmd," A.his_proceso_amd between \n");
    sprintf(sqlcmd," %s %s ", sqlcmd,fecIni);
    strcat(sqlcmd," and \n");
    sprintf(sqlcmd," %s %s ", sqlcmd,fecFin);
   }
   if (strcmp(cortenum,"0") != 0) /* Proceso por corte */
   {
    strcat(sqlcmd," A.his_mes_y_ciclo_corte in \n");
    sprintf(sqlcmd," %s (%s) ", sqlcmd,corte);
   }
   if (strcmp(ejePrefijo,"0") != 0) /* Valida si se toma prefijo para proceso */
   {
    strcat(sqlcmd,"and A.eje_prefijo= \n");
    sprintf(sqlcmd," %s %s ",sqlcmd,ejePrefijo);
   }
   if (strcmp(gpoBanco,"0") !=0) /* Valida si se tom banco para proceso */
   {
    strcat(sqlcmd,"and A.gpo_banco= \n");
    sprintf(sqlcmd," %s %s ",sqlcmd,gpoBanco);
   }
   if (strcmp(numEmpresa,"0") !=0) /* Valida si se toma empresa para proceso */
   {
    strcat(sqlcmd,"and A.emp_num= \n");
    sprintf(sqlcmd," %s %s ",sqlcmd,numEmpresa);
   }
   strcat(sqlcmd,"and A.eje_prefijo = C.eje_prefijo \n");
   strcat(sqlcmd,"and A.gpo_banco = C.gpo_banco \n");
   strcat(sqlcmd,"and A.emp_num = C.emp_num \n");
   strcat(sqlcmd,"and C.emp_gen_CDF = 1 \n");
   strcat(sqlcmd,"and A.his_transaccion = B.cve_transaccion \n");
   strcat(sqlcmd,"and A.b01_neg_num_neg *= D.b01_neg_num_neg \n");
   strcat(sqlcmd,"and A.eje_prefijo = E.eje_prefijo \n");
   strcat(sqlcmd,"and A.gpo_banco = E.gpo_banco \n");
   strcat(sqlcmd,"and A.emp_num=E.emp_num \n");
   strcat(sqlcmd,"and A.eje_num=E.eje_num \n");
   strcat(sqlcmd,"and A.eje_num <> 0 \n");
   strcat(sqlcmd,"and E.eje_prefijo*=U.eje_prefijo \n");
   strcat(sqlcmd,"and E.gpo_banco*=U.gpo_banco \n");
   strcat(sqlcmd,"and E.emp_num*=U.emp_num \n");
   strcat(sqlcmd,"and U.unit_parent_id=null \n");
   strcat(sqlcmd,"and U.nivel_num=1 \n");
   /*strcat(sqlcmd,"order by CtaCorp, convert(float,substring(E.eje_centro_c,1,6)), cuenta\n"); */
   strcat(sqlcmd,"order by CtaCorp, E.eje_centro_c, cuenta\n");

   dbcmd(q_dbproc, sqlcmd);

   if( dbsqlexec(q_dbproc) == FAIL)
   {
    printf("Fecha proceso: %s\n", fechayhora);
    printf("Nombre archivo: %s\n", nombrearchivo);
    printf("Programa: r5000.c \n");
    printf("Error: Fallo al intentar ejecutar el query princial de r5000 dbsqlexec:\n");
    printf("%s",sqlcmd);
    dbclose(q_dbproc);
    dbexit();
    exit(ERREXIT);
   }

   dbresults(q_dbproc);

   if( DBROWS(q_dbproc) != SUCCEED)
   {
    printf("Fecha proceso: %s\n", fechayhora);
    printf("Nombre archivo: %s\n", nombrearchivo);
    printf("Programa: r5000.c \n");
    printf("Error: No hay datos del query princial del r5000 : %s \n",sqlcmd);
    dbclose(q_dbproc);
    dbexit();
    exit(0);
   }

   dbbind(q_dbproc, 1, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)numEmpresa);
   dbbind(q_dbproc, 2, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)numCuenta);
   dbbind(q_dbproc, 3, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)fecValor);
   dbbind(q_dbproc, 4, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)fecProceso);
   dbbind(q_dbproc, 5, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)fecPosteo);
   dbbind(q_dbproc, 6, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)numNegocio);
   dbbind(q_dbproc, 7, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)importe);
   dbbind(q_dbproc, 8, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)transaccion);
   dbbind(q_dbproc, 9, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)referencia);
   dbbind(q_dbproc, 10, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)cicloCorte);
   dbbind(q_dbproc, 11, STRINGBIND,(DBINT)0, (BYTE DBFAR *)pais);
   dbbind(q_dbproc, 12, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)leyenda);
   dbbind(q_dbproc, 13, STRINGBIND,(DBINT)0, (BYTE DBFAR *)pobNego);
   dbbind(q_dbproc, 14, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)dolares);
   dbbind(q_dbproc, 15, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)desTran);
   dbbind(q_dbproc, 16, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)claveTran);
   dbbind(q_dbproc, 17, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)clasifTran);
   dbbind(q_dbproc, 18, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)signoTran);
   dbbind(q_dbproc, 19, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)b06Acd);
   dbbind(q_dbproc, 20, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)referencia_a);
   dbbind(q_dbproc, 21, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)orgpointnum);
   dbbind(q_dbproc, 22, NTBSTRINGBIND,(DBINT)0, (BYTE DBFAR *)unitpadre);




   while ( dbnextrow(q_dbproc) != NO_MORE_ROWS)
   {
     strcpy(recordidentifier,'\0');
     strcpy(issuerica,'\0');
     strcpy(issuernumberica,'\0');
     strcpy(corporationnumber,'\0');
     strcpy(addendumtype,'\0');
     strcpy(reservedforinternaluse1,'\0');
     strcpy(reservedforinternaluse2,'\0');
     strcpy(merchantacttranoriginind,'\0');
     strcpy(accountnumber,'\0');
     strcpy(reservedforinternaluse3,'\0');
     strcpy(acquirersorissuersrefnum,'\0');
     strcpy(recordtype,'\0');
     strcpy(transactiontype,'\0');
     strcpy(debitcreditindicator,'\0');
     strcpy(transactionamount,'\0');
     strcpy(postingdate,'\0');
     strcpy(transactiondate,'\0');
     strcpy(processingdate,'\0');
     strcpy(merchantname,'\0');
     strcpy(merchantcity,'\0');
     strcpy(merchantstateprovince,'\0');
     strcpy(merchantcountry,'\0');
     strcpy(merchantcategorycode,'\0');
     strcpy(amountinoriginalcurrency,'\0');
     strcpy(originalcurrencycode,'\0');
     strcpy(currconvdatejulian,'\0');
     strcpy(postedcurrencycode,'\0');
     strcpy(conversionrate,'\0');
     strcpy(conversionexponent,'\0');
     strcpy(acquiringica,'\0');
     strcpy(customercode,'\0');
     strcpy(salestaxamount,'\0');
     strcpy(reservedforinternaluse4,'\0');
     strcpy(reservedforinternaluse5,'\0');
     strcpy(freightamount,'\0');
     strcpy(destinationpostalcode,'\0');
     strcpy(merchanttype,'\0');
     strcpy(merchantlocationpostalcode,'\0');
     strcpy(dutyamount,'\0');
     strcpy(merchantfederaltaxid,'\0');
     strcpy(merchantstateprovincecode,'\0');
     strcpy(shipfrompostalcode,'\0');
     strcpy(alternatetaxamount,'\0');
     strcpy(destinationcountrycode,'\0');
     strcpy(merchantreferencenumber,'\0');
     strcpy(alternatetaxindicator,'\0');
     strcpy(alternatetaxidentifier,'\0');
     strcpy(salestaxcollectedind_pos,'\0');
     strcpy(addendumdetailindicator,'\0');
     strcpy(merchantid,'\0');
     strcpy(banknetReferenceNumber, '\0');    /*Nuevo Campo, IERM Sept. 15, 2004*/
     strcpy(approvalCode, '\0');    /*Nuevo Campo, IERM Sept. 15, 2004*/
     strcpy(adjustmentreasoncode,'\0');
     strcpy(adjustmentdescription,'\0');
     strcpy(maintenanceactioncode,'\0');
     strcpy(inputfilerecordnumber,'\0');
     strcpy(outgoingincomingerrorcode,'\0');
     strcpy(organizationpointnumber,'\0');
     strcpy(valor_mcc,'\0');
     strcpy(cadenareg5000,'\0');

     /**
       * Seccion de formateo!!!
       **/
     sprintf(recordidentifier, FRMA4, "5000");
     sprintf(issuerica, FRMN11, issuerIca);
     sprintf(issuernumberica, FRMA11, issuerNumberIca);
     sprintf(corporationnumber, FRMA19,numEmpresa);
     sprintf(addendumtype, FRMA3, "0");
     sprintf(reservedforinternaluse1, FRMA17, EMPTYSTR );
     sprintf(reservedforinternaluse2, FRMA6, EMPTYSTR );
     strcpy(merchantacttranoriginind,clasifTran);
     sprintf(accountnumber, FRMA19,numCuenta);
     sprintf(reservedforinternaluse3, FRMA10, EMPTYSTR);
     sprintf(acquirersorissuersrefnum, FRMA23, referencia);
     sprintf(recordtype, FRMA1, EMPTYSTR);
     sprintf(conversionrate, FRMN16, EMPTYSTR);

     /**
       * Fin de la Seccion de Formateo
       **/

     if(clasifTran[0]=='M')
     {
      if( (strcmp(desTran,"compra")) == 0 )
        strcpy(transactiontype,"5");
      if( (strcmp(desTran,"abono")) == 0 )
        strcpy(transactiontype,"6");
      if( (strcmp(desTran,"pagos")) == 0 )
        strcpy(transactiontype,"6");
      if((strcmp(desTran,"devolucion")) == 0)
        strcpy(transactiontype,"6");
      if((strcmp(desTran,"dispo")) == 0)
        strcpy(transactiontype,"7");
      if( pobNego[0]==' ')
        sprintf(merchantcity, FRMA13,"UNK");
      else
        strncpy(merchantcity,pobNego,13);

      merchantcity[13]='\0';
      sprintf( salestaxcollectedind_pos, FRMA1, "N" );
      sprintf( adjustmentreasoncode, FRMA5, EMPTYSTR );
      sprintf( adjustmentdescription, FRMA40, EMPTYSTR );
      sprintf( merchantstateprovincecode, FRMA3,"UNK");
      sprintf( merchantstateprovince, FRMA3,"UNK");

      if ((fecValor[0] == '0') && (fecPosteo[0] == '0'))
      {
       printf("Fecha proceso: %s\n", fechayhora);
       printf("Nombre archivo: %s\n", nombrearchivo);
       printf("Programa: r5000.c \n");
       printf("Error: No existen fechas de Posting Date y de Transaction Date");
       exit(ERREXIT);
      }
      else
      {
       strcpy(postingdate,fecPosteo);
       strcpy(transactiondate,fecPosteo);
       convfechjuliana(fecPosteo,fechajuliana);
      }

      strcpy(processingdate,fecProceso);
      strcpy(currconvdatejulian,fechajuliana);

      /********************************************/

      if(((strcmp(pais,"MEX")==0) && (atoi(importe)>0) && (atoi(dolares)>0))  || ((strcmp(pais,"MEX")==0) && (atof(importe)!=0) && (atoi(dolares)==0)))
      {
       /* transacciones nacionales*/
       if (strlen(leyenda) == 0)
       {
        strcpy(leyenda,"Consumo Nacional");
        strcpy(merchantname1,leyenda);
       }
       else
       {
        strncpy(merchantname1,leyenda,25);
        merchantname1[25]='\0';
       }
       sprintf( merchantname, FRMA25, merchantname1 );
       sprintf( merchantstateprovince, FRMA3, "UNK" );
       sprintf( merchantcountry, FRMA3, "MEX");

       sprintf( acquiringica, FRMN11,  issuerIca  );   /*Formateado, IERM Sept. 21, 2004*/

       if( (atof(importe) != 0) || ( atof(dolares) != 0))
        sprintf( conversionrate, FRMN16, "0000000010000000");

      if( atol(numNegocio) == 0)
      {
        sprintf(valor_mcc, FRMN4 ,"0000");
        if( strcmp(desTran,"dispo")==0 )
        {
            strcpy(valor_mcc,"6010");  /*por defaul pone dispo en cajero*/
            strncpy(posicion5,&referencia[4],1); /*posicion 5*/
            posicion5[1]='\0';
            strncpy(posicion6y7,&referencia[5],2); /*posicion 6 y 7*/
            posicion6y7[2]='\0';

            if( (posicion5[0] == '0') || ((posicion5[0]!='0') && (strcmp(posicion6y7, "96") == 0)))
            {
               sprintf(valor_mcc, FRMN4, "6011"); /*mcc de sucursal */
            }
         }/*fin del if desTran="dispo"*/
      }
      else
      {
       sprintf(valor_mcc, FRMN4 ,"0000");
       if (strcmp(b06Acd,"0") == 0)
       {
          if( strcmp(desTran,"dispo")==0 )
          {
            strcpy(valor_mcc,"6010");  /*por defaul pone dispo en cajero*/
            strncpy(posicion5,&referencia[4],1); /*posicion 5*/
            posicion5[1]='\0';
            strncpy(posicion6y7,&referencia[5],2); /*posicion 6 y 7*/
            posicion6y7[2]='\0';

            if( (posicion5[0] == '0') || ((posicion5[0]!='0') && (strcmp(posicion6y7, "96") == 0)))
            {
               sprintf(valor_mcc, FRMN4, "6011"); /*mcc de sucursal */
            }
          }/*fin del if desTran="dispo"*/
       }
       else
       {
        sprintf(valor_mcc, FRMN4, b06Acd); /*valor obtenido de MTCNEG01*/
       }/* fin del else b06Acd==0 */
      }/*fin del else  nunNegocio==0 */
     }
     else
     {
      /*transacciones internacionales*/

      if (strlen(leyenda) == 0)
      {
       sprintf(leyenda, FRMA25, "Consumo Internacional");
       sprintf(merchantname1, FRMA25, leyenda);
      }
      else
      {
       strncpy(merchantname1,leyenda,22); /*se quitan ultimas 4 del MCC*/
       merchantname1[22]='\0';
      }

   sprintf( merchantname, FRMA25, merchantname1 );
      sprintf( acquiringica, FRMN11, referencia_a );

   /*si solo trae dos caracteres en pais el pais es USA */
      if( atof(dolares) != 0 )
      {
       tasaConversion = (atof(importe))/(atof(dolares));
       sprintf(conversionrate1,"%016.7f", tasaConversion );
       /*redondeo( conversionrate1 );
	   aux = formateaTasa( conversionrate1 );
	   strcpy( conversionrate, aux );*/
       sprintf(conversionrate1,"%016.7f",(atof(importe))/(atof(dolares)));
       strncpy(conversionrate2,conversionrate1,8);
       conversionrate2[8]='\0';
       strncpy(conversionrate3,&conversionrate1[9],7);
       conversionrate3[7]='\0';
       sprintf(conversionrate4,"0");
       strcat(conversionrate4,conversionrate2);
       strcat(conversionrate4,conversionrate3);
       sprintf(conversionrate,conversionrate4);
      }
      strncpy(valor_mcc,&leyenda[22],4); /* posicion 23 a la 26*/
      valor_mcc[4]='\0';

  /*transacciones realizadas en CITISHARE o VISA traen merchant_country de
    dos posiciones. y para transacciones de Master Card vienen de 2
    posiciones cuando se realizo en USA y de 3 pos para cualquier otro pais
    por lo que debemos dejar los paises todos de tres posiciones*/

  /*checa transacciones realizada en MASTER CARD */
  if( (strcmp(valor_mcc,"0000") != 0) &&
       ( accountnumber[0]=='5' ) )
  {
     if (pais[ 2 ] == ' ' )/*checa checa transacciones realizadas en USA*/
     {
       sprintf(merchantstateprovince,FRMA3,pais);
       strcpy(pais,"USA");
     }
  }/*fin del if de transacciones MASTER CARD*/
  else
  { /*para transacciones CITISHARE y VISA  deja el pais de tres posiciones*/
    for(j=0;j<totalPais;j++)
    {
	  pais[ 2 ] = '\0';	/* El campo pais incluye un espacio en blanco al final*/
      if( strcmp(pais,arreglo_pais[j].cod2)==0 )
      {
        strcpy(pais,arreglo_pais[j].cod3);
        break;
      }
    }
  }
      /* primero checa si la moneda es en pesos */
  if( tasaConversion >= 0.99 && tasaConversion <= 1.02 )
  {
     strcpy(currencyInternacional,"484");
	 sprintf( conversionrate, FRMN16, "0000000010000000");
  }
  else
  {
    if ( strcmp(pais,"USA")==0 )/*for UniteState are dollars 840*/
     strcpy(currencyInternacional,"840");
    else
    {
      for(i=0,monedaUsual=0;i<totalMonUsu;i++)
      {
        if( (tasaConversion>= monedas_usuales[i].tasa_rango1) &&
            (tasaConversion<= monedas_usuales[i].tasa_rango2)  )
        {
           strcpy(currencyInternacional,monedas_usuales[i].moneda_num);
           monedaUsual=1;
        }
      }
      /*si no correspondio a moneda usual se pone la moneda del pais*/
      if ( monedaUsual == 0)
      {
        for(j=0,paisdesconocido=0;j<totalPais;j++)
        {
          if( strcmp(pais,arreglo_pais[j].cod3)==0 )
          {
             strcpy(currencyInternacional,arreglo_pais[j].moneda_num);
             paisdesconocido=1;
          }
        }
        if( paisdesconocido==0)
        {
        /*si no se encuentra el pais se envia tal cual y  deja moneda dolares*/
          strcpy(currencyInternacional,"840");
        }
      }/* fin de la validacion monedaUsual==0*/
    }/*fin del else de que no es USA*/
  }/* fin de checa tasa conversion*/
  if ( strcmp(valor_mcc,"0000")==0)
    strcpy(valor_mcc,"6010"); /*disposiciones CITISHARE*/
  else
  {
    if(strcmp(desTran,"dispo")==0)
      strcpy(valor_mcc,"6010");  /*dispo en VISA y MASTER CARD*/
    else
    {
      if(strcmp(desTran,"devolucion")==0)
         strcpy(valor_mcc,"0000");
    }
  }
  es_num = 1;
  for (j = 0; j < 4; ++j)
  {
    if (!isdigit(valor_mcc[j]))
    {
      es_num = 0;
      break;
    }
  }
  /* Si no son numericas las 4 posiciones. */
  if (es_num== 0)
  {
    strcpy(valor_mcc,"0000");
  }

  sprintf( originalcurrencycode, FRMN3, currencyInternacional );
  sprintf(merchantcountry, FRMA3, pais);



        }/* fin del else transacciones internacionales*/
       }
       else /* para el caso de Adjustment */
       {
        sprintf( conversionrate, FRMN16, "0000000010000000" );
        sprintf( transactiontype, FRMA1, "3" );
        sprintf( merchantname, FRMA25, EMPTYSTR );
        sprintf( merchantcity, FRMA13, EMPTYSTR );
        sprintf( merchantstateprovince, FRMA3, EMPTYSTR );
        sprintf( merchantcountry, FRMA3, EMPTYSTR );
        sprintf( merchantstateprovincecode, FRMA3, EMPTYSTR );
        sprintf( salestaxcollectedind_pos, FRMA1, EMPTYSTR );
        sprintf( claveTran1, FRMA5, claveTran );
        sprintf( adjustmentreasoncode, FRMA5, claveTran1 );
        sprintf( adjustmentdescription, FRMA40, leyenda );
        //Se inserta La fecha de posteo en Formato Juliano - Marzo 28, 2005 - IERM
        convfechjuliana( fecPosteo, fechajuliana );
        sprintf( currconvdatejulian, FRMA5, fechajuliana );
        sprintf( valor_mcc, FRMA4, EMPTYSTR );
        sprintf( acquiringica, FRMA11, EMPTYSTR );   /*Se insertan 11 espacios, IERM Sept 15, 2004*/
       }
       strcpy(merchantcategorycode,valor_mcc);
       if( strlen(transactiontype)==0 )
       {
        printf("Fecha proceso: %s\n", fechayhora);
        printf("Nombre archivo: %s\n", nombrearchivo);
        printf("Programa: r5000.c \n");
        printf("Error: transactiontype vacio r5000 \n");
        printf("       cuenta: %s, pais: %s\n",accountnumber,pais);
        printf("       importe: %s leyenda: %s\n",importe,leyenda);
        dbclose(q_dbproc);
        dbexit();
        exit(1);
       }
       /*se quita punto decimal a importe y a dolares */
       strncpy(importe1,importe,12);
       importe1[12]='\0';
       strncat(importe1,&importe[13],4);
       importe1[16]='\0';
       strncpy(dolares1,dolares,12);
       dolares1[12]='\0';
       strncat(dolares1,&dolares[13],4);
       dolares1[16]='\0';
       strcpy(debitcreditindicator,signoTran);
       sprintf( debitcreditindicator, FRMA1, debitcreditindicator);
       strcpy(transactionamount,importe1); /*cuatro decimales sin punto*/
       if ((fecValor[0] == '0') && (fecPosteo[0] == '0'))
       {
        printf("Fecha proceso: %s\n", fechayhora);
        printf("Nombre archivo: %s\n", nombrearchivo);
        printf("Programa: r5000.c \n");
        printf("Error: No existen fechas de Posting Date y de Transaction Date");
        exit(ERREXIT);
       }
       else if ((fecValor[0] == '0'))
       {
        sprintf( transactiondate, FRMA8, fecPosteo );

        strncpy(prodemp,&numCuenta[0],11); /*posicion 1 a 11*/
        prodemp[11]='\0';
        if (! strcmp(prodemp, "54738016200"))  /* Empresa LG */
        {
           if (strcmp(transactiontype,"6"))
           {
                fecPosteoNum=atoi(fecPosteo);
                if ( fecPosteoNum > fecCorteAnt )
                {
                   fecPosteo[0]='\0';
                   strcat(fecPosteo,feclimpagosig);
                   fecPosteo[strlen(fecPosteo)]='\0';
                }
                else
                {
                   fecPosteo[0]='\0';
                   strcat(fecPosteo,feclimpago);
                   fecPosteo[strlen(fecPosteo)]='\0';
                }
           }
        }
        sprintf( postingdate, FRMA8, fecPosteo );
       }
       else if ((fecValor[0] != '0'))
       {
        strncpy(prodemp,&numCuenta[0],11); /*posicion 1 a 11*/
        prodemp[11]='\0';
        if (! strcmp(prodemp, "54738016200"))  /* Empresa LG */
        {
           if (strcmp(transactiontype,"6"))
           {
                fecPosteoNum=atoi(fecPosteo);
                if ( fecPosteoNum > fecCorteAnt )
                {
                   fecPosteo[0]='\0';
                   strcat(fecPosteo,feclimpagosig);
                   fecPosteo[strlen(fecPosteo)]='\0';
                }
                else
                {
                   fecPosteo[0]='\0';
                   strcat(fecPosteo,feclimpago);
                   fecPosteo[strlen(fecPosteo)]='\0';
                }
           }
        }

        sprintf( postingdate, FRMA8, fecPosteo );
        sprintf( transactiondate, FRMA8, fecValor );
       }
       sprintf( processingdate, FRMA8, fecProceso );
       if(((strcmp(pais,"MEX")==0) && (atoi(importe)>0) && (atoi(dolares)>0))
        || ((strcmp(pais,"MEX")==0) && (atof(importe)!=0) && (atoi(dolares)==0))
        || (clasifTran[0]=='A'))
         sprintf( amountinoriginalcurrency, FRMN16, importe1 ); /*cuatro decimales sin punto*/
       else
        sprintf( amountinoriginalcurrency, FRMN16, dolares1); /*cuatro decimales sin punto*/

    if(((strcmp(pais,"MEX")==0) && (atoi(importe)>0) && (atoi(dolares)>0))
         || ((strcmp(pais,"MEX")==0) && (atof(importe)!=0) && (atoi(dolares)==0))
         || (clasifTran[0]=='A'))
        sprintf( originalcurrencycode, FRMN3, originalCurrencyCode );
       else
    sprintf( originalcurrencycode, FRMN3, currencyInternacional ); /*moneda en dolares*/

      sprintf( postedcurrencycode, FRMN3, originalCurrencyCode );
      sprintf( conversionexponent, FRMN1, "2");
      sprintf( customercode, FRMA17, EMPTYSTR );
      sprintf( salestaxamount, FRMN16, EMPTYSTR );
      sprintf( reservedforinternaluse4, FRMA1, EMPTYSTR );
      sprintf( reservedforinternaluse5, FRMA5, EMPTYSTR );
      sprintf( freightamount, FRMN16, EMPTYSTR );
      sprintf( destinationpostalcode, FRMA10, EMPTYSTR );
      sprintf( merchanttype, FRMA4, EMPTYSTR );
      sprintf( merchantlocationpostalcode, FRMA10, EMPTYSTR );
      sprintf( dutyamount, FRMN16, EMPTYSTR );
      sprintf( merchantfederaltaxid, FRMA15, EMPTYSTR );
      sprintf( shipfrompostalcode, FRMA10, EMPTYSTR );
      sprintf( alternatetaxamount, FRMN16, EMPTYSTR );
      sprintf( destinationcountrycode, FRMA3, "UNK" );
      sprintf( merchantreferencenumber, FRMA17, EMPTYSTR );
      sprintf( alternatetaxindicator, FRMA1, "N" );
      sprintf( alternatetaxidentifier, FRMA15, EMPTYSTR );
      sprintf( addendumdetailindicator, FRMN1, EMPTYSTR );
      sprintf( merchantid, FRMA15, EMPTYSTR );
      sprintf( banknetReferenceNumber, FRMA12, EMPTYSTR );  /*Nuevo Campo Insertado, IERM Sept. 14, 2004*/
      sprintf( approvalCode, FRMA6, EMPTYSTR );    /*Nuevo Campo Insertado, IERM Sept. 14, 2004*/
      maintenanceactioncode[0]='A';
      sprintf( inputfilerecordnumber, FRMN6, EMPTYSTR );
      sprintf( outgoingincomingerrorcode, FRMA6, EMPTYSTR );
      if (strcmp(unitpadre,NULL) != 0)
      {
    if ( (strcmp(orgpointnum,"0") == 0) || (strcmp(orgpointnum,NULL) == 0) || (strcmp(orgpointnum," ") == 0) )
       {
        strcpy(organizationpointnumber,unitpadre);
       }
       else
       {
        contador=0;
        memcpy(cad_car,'\0',16);
        memcpy(caracter,'\0',2);
        for (contador=0; contador <= strlen(orgpointnum); contador ++)
        {
         strncpy(caracter,&orgpointnum[contador],1);
         caracter[1]='\0';
         if ((strcmp(caracter,"0") == 0) || (strcmp(caracter,"1") == 0) || (strcmp(caracter,"2") == 0) || (strcmp(caracter,"3") == 0) ||
             (strcmp(caracter,"4") == 0) || (strcmp(caracter,"5") == 0) || (strcmp(caracter,"6") == 0) || (strcmp(caracter,"7") == 0) ||
             (strcmp(caracter,"8") == 0) || (strcmp(caracter,"9") == 0) )
         {
          strcat(cad_car,caracter);
         }
        }
        sprintf(organizationpointnumber,"%-19s",cad_car);
       }
      }
      else
      {
       strcpy(organizationpointnumber,numEmpresa);
      }
      strcpy(cadenareg5000,recordidentifier); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,issuerica); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,issuernumberica); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,corporationnumber); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,addendumtype); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,reservedforinternaluse1); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,reservedforinternaluse2); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantacttranoriginind); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,accountnumber); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,reservedforinternaluse3); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,acquirersorissuersrefnum); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,recordtype); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,transactiontype); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,debitcreditindicator); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,transactionamount); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,postingdate); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,transactiondate); strcat(cadenareg5000,"\t");
      sprintf( processingdate, FRMA8, processingdate );
      strcat(cadenareg5000,processingdate); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantname); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantcity); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantstateprovince); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantcountry); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantcategorycode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,amountinoriginalcurrency); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,originalcurrencycode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,currconvdatejulian); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,postedcurrencycode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,conversionrate); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,conversionexponent); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,acquiringica); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,customercode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,salestaxamount); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,reservedforinternaluse4); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,reservedforinternaluse5); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,freightamount); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,destinationpostalcode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchanttype); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantlocationpostalcode);strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,dutyamount); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantfederaltaxid); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantstateprovincecode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,shipfrompostalcode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,alternatetaxamount); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,destinationcountrycode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantreferencenumber); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,alternatetaxindicator); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,alternatetaxidentifier); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,salestaxcollectedind_pos); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,addendumdetailindicator); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,merchantid); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000, banknetReferenceNumber); strcat(cadenareg5000,"\t");  /*Nuevo Campo IERM Sept. 14 2004*/
      strcat(cadenareg5000, approvalCode); strcat(cadenareg5000,"\t");  /*Nuevo Campo IERM Sept. 14, 2004*/
      strcat(cadenareg5000,adjustmentreasoncode); strcat(cadenareg5000,"\t");
      if(strlen(adjustmentdescription) != 40)
       sprintf( adjustmentdescription, FRMA40, adjustmentdescription );
      strcat(cadenareg5000,adjustmentdescription); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,maintenanceactioncode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,inputfilerecordnumber); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,outgoingincomingerrorcode); strcat(cadenareg5000,"\t");
      strcat(cadenareg5000,organizationpointnumber);
      if ((fprintf(reg5000,"%s\n",cadenareg5000)) == -1)
      {
       printf("Fecha proceso: %s\n", fechayhora);
       printf("Nombre archivo: %s\n", nombrearchivo);
       printf("Programa: r5000.c \n");
       printf("Error:  El registro r5000 no se pudo grabar en archivo:\n");
       printf("        archivo: %s \n",nombrearchivo_temp);
       printf("        cuenta: %s, pais: %s\n",accountnumber,pais);
       printf("        importe: %s leyenda: %s\n",importe,leyenda);
       dbclose(q_dbproc);
       dbexit();
       exit(1);
      }
     }  /*fin del while dbnexrow*

     /*cierra la conexion con sybse*/
     dbclose(q_dbproc);
     dbexit();
     fclose(reg5000);
     /* Se ejecuta el bulkcopyprocedure de reg5000.txt a la tabla REG5000 */
     sprintf(bulkcopy,"%s in %s -c","bcp M111.dbo.REG5000 ",nombrearchivo_temp);
     strcat(bulkcopy, " -Q -U");
     strcat(bulkcopy, ge_user);
     strcat(bulkcopy, " -P");
     strcat(bulkcopy, ge_password);
     strcat(bulkcopy, " -S");
     strcat(bulkcopy, ge_server);
     system(bulkcopy);
     /*obtiene fecha y hora del proceso */
     time(&lcl_time);
     today = localtime(&lcl_time);
     strftime(fechayhora,20,"%Y%m%d %T",today);
     printf("Hora de termino del programa r5000: %s\n",fechayhora);
     exit(STDEXIT);
    } /* fin del main */

void convfechjuliana(fech,fechjul)
char *fech;
char *fechjul;
{
 int Anio, Mes, Dia,Ndias;
 char ani_c[4+1];
 char dia_c[2+1];
 char mes_c[2+1];
 char juliana[5+1];
 char anio_dos_pos[2+1];
 Ndias=0;
 Anio=0;
 Mes=0;
 Dia=0;
 juliana[0]='\0';
 strncpy(ani_c,fech,4);
 ani_c[4]='\0';
 strncpy(dia_c,&fech[6],2);
 dia_c[2]='\0';
 strncpy(mes_c,&fech[4],2);
 mes_c[2]='\0';
 Anio=atoi(ani_c);
 Mes =atoi(mes_c);
 Dia =atoi(dia_c);

 Ndias=((Mes-1)*30)+Dia;
 if(Mes >  1)
  Ndias++;
 if(Mes >  2)
  if ((Anio % 4 == 0) && (Anio % 100 != 0) || (Anio % 400 == 0))
   Ndias--;
  else
  {
   Ndias--;
   Ndias--;
  }
 if(Mes >  3)
  Ndias++;
 if(Mes >  5)
  Ndias++;
 if(Mes >  7)
  Ndias++;
 if(Mes >  8)
  Ndias++;
 if(Mes > 10)
  Ndias++;
 strncpy(anio_dos_pos,&fech[2],2);
 anio_dos_pos[2]='\0';
 Ndias += (1000*(atoi(anio_dos_pos)+100));
 sprintf(juliana,"%d",Ndias);
 strncpy(fechjul,&juliana[1],5);
 fechjul[strlen(fechjul)]='\0';
}

int calcfeclimpago(char * fecha)
{
 int Anio, Mes, Dia, Anio1, Mes1, Dia1, Ndias;
 char ani_c[4+1];
 char dia_c[2+1];
 char mes_c[2+1];
 Ndias=15;
 Anio=0;
 Mes=0;
 Dia=0;
 strncpy(ani_c,fecha,4);
 ani_c[4]='\0';
 strncpy(mes_c,&fecha[4],2);
 mes_c[2]='\0';
 strncpy(dia_c,&fecha[6],2);
 dia_c[2]='\0';
 Anio=atoi(ani_c);
 Mes =atoi(mes_c);
 Dia =atoi(dia_c);

 if ( hfecmasmenosdias_2k(Anio, Mes, Dia, Ndias, &Anio1, &Mes1, &Dia1) < 0 )
 {
    printf("Fecha de Corte invalida %s \n",fecha);
    return 1;
 }
 else
 {
    fecha[0]='\0';
    ani_c[0]='\0';
    mes_c[0]='\0';
    dia_c[0]='\0';
    sprintf(ani_c,"%04d",Anio1);
    sprintf(mes_c,"%02d",Mes1);
    sprintf(dia_c,"%02d",Dia1);
    strcat (fecha,ani_c);
    strcat (fecha,mes_c);
    strcat (fecha,dia_c);
    fecha[strlen(fecha)]='\0';
    return 0;
 }
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
DBPROCESS       *dbproc;
DBINT           msgno;
int             msgstate;
int             severity;
char            *msgtext;
char            *srvname;
char            *procname;
int      line;
{

 extern char fechayhora[20];
 extern char nombrearchivo[60];
 extern char sqlcmd[5000];
 if ((msgno != 5701) && (msgno != 5703))
 {
  if (severity == 16)
  {
   printf("FechaProceso: %s\n", fechayhora);
   printf("Nombre Archivo: %s\n", nombrearchivo);
   printf("Nombre Programa: r5000.c \n");
   printf("Error %ld, Nivel severidad %d, Estado %d\n", msgno, severity,msgstate);
   printf("Mensaje error: \n%s\n", msgtext);
   printf("Se ejecutaba el sql: \n%s\n", sqlcmd);
   exit(1);
  }
 }
 return 0;
}

