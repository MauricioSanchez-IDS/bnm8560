/**************************************************
     Libreria para el manejo de Sapuf 
***************************************************/
#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include "SAPUF_Enlace.h"
//#include "/opt/c046/105/include/SAPUF_Enlace.h"
#include <sybfront.h>
#include <sybdb.h>
#include "sybdbex.h"
#include <unistd.h>
#include <tipos.h>

#define PARAMETROS "/opt/c430/000/bin/parametrosSAPUF.txt"

#if defined(_PROTOTYPES)
int    obtenvalor(char *, char *);
int     ConectaBase(char *, char *, char *);
int     ObtenSapuf(char *, char *, char **);
#else
int    obtenvalor();
int     ConectaBase();
int     ObtenSapuf();
#endif

int main ( num_argumentos,  argumentos)
int num_argumentos;
char *argumentos[];
{
  static  int  retorno;
   char isPassword[257];
   char strResult[1000];

   if(getenv("DIR_SAPUF_CFG") == NULL)
   	putenv("DIR_SAPUF_CFG=/opt/c046/105/conf/sapufCentral.cfg");
   if(getenv("DIR_SAPUF_LOG") == NULL)
   	putenv("DIR_SAPUF_LOG=/opt/c430/000/var/log/c046Agentec4300001_c430.log");

   retorno=getPassword(isPassword,strResult);
   switch(retorno){
     case 0:
        printf("%s",isPassword);
        break;
     case 1:
        printf("\nError al obtener Password de SAPUF:\n[%s]\n", strResult);
        break;
     case 2:
        printf("\nDesincronizacion de Password:\n[%s]\n", strResult);
        break;
   }
   return(retorno);
}

int getPassword(char *isPassword, char *strResult)
{
	char usr[100], passSapuf[257], ser[100], bas[100], intentos[3];
	int iResConecta=0;
	int iResObten=0;

	memset(usr, '\0',sizeof(usr));
	memset(ser, '\0',sizeof(ser));
	memset(bas, '\0',sizeof(bas));
	memset(intentos, '\0',sizeof(intentos));
	memset(strResult, '\0',sizeof(strResult));

	if(obtenvalor("USUARIO", usr) != 0 ||
	   obtenvalor("SERVIDOR", ser) != 0 ||
	   obtenvalor("BASE", bas) != 0 ) {
		sprintf(strResult, "Error al obtener valor de archivo de parametros");
		return 1;
	}
	/*Primer Password*/
	iResObten = ObtenSapuf(passSapuf, "0",&strResult);
	if(iResObten==0)
        {
		iResConecta = ConectaBase(usr,passSapuf,ser);
        }
	else
		return 1;/*Error en ObtenSapuf al invocar SolicitarPassword*/

	if(iResConecta == 0) {
		strcpy(isPassword, passSapuf);
		return 0;
	}
	/*Fin Primer Password*/

	/*Inicio Refresco de Password*/
	iResObten = ObtenSapuf(passSapuf, "1",&strResult);

	if(iResObten==0)
		iResConecta = ConectaBase(usr,passSapuf,ser);
	else
		return 1;/*Error en ObtenSapuf al invocar SolicitarPassword*/

	if(iResConecta == 0) {
		strcpy(isPassword, passSapuf);
		return 0;
	}
	/*Fin Refresco de Password*/

	/*Segundo Password*/
	iResObten = ObtenSapuf(passSapuf, "2",&strResult);

	if(iResObten==0)
		iResConecta = ConectaBase(usr,passSapuf,ser);
	else
		return 1;/*Error en ObtenSapuf al invocar SolicitarPassword*/

	if(iResConecta == 0) {
		strcpy(isPassword, passSapuf);
		return 0;
	}
	else {
		ObtenSapuf(passSapuf, "3",&strResult); /*Informa de la Desincronizacion de Password*/
		return(2);
	}
	/*Fin Segundo Password*/

   //   return (1);
}


int obtenvalor( parametro, valor)
char parametro[1000];
char valor[1000];
{
   FILE *a;
   char *c;
   char d[200];
   int iEncontrado = 0;
static 	int iRes = 0;
   
	if ((a = fopen(PARAMETROS, "r")) == NULL){
		iRes = 1;
	}
	else {
		while(!feof(a)){
			fscanf(a,"%s\n",d);
			if (strncmp(d, parametro, strlen(parametro)) == 0 ){
				c = strstr(d, "=");
				strcpy(valor, ++c);
				iEncontrado = 1;
			}
		}
	}
	fclose(a);

	if(iEncontrado==0)
		iRes = 1;

	return iRes;
}

int ConectaBase(User, Pass, Serv)
char User[255];
char Pass[255];
char Serv[255];
{
    LOGINREC    *login;
    DBPROCESS   *dbproc; 
    char Host[255];
    int reginit;
    /*if (dbinit() == FAIL) */
    /*if (dbinit() == fail()) */
    reginit = dbinit();
    if (reginit == 0) 
       return 3;
    dbsetversion(DBVERSION_100);
    login = dblogin();
    DBSETLUSER(login, User);
    DBSETLPWD(login, Pass);
    DBSETLAPP(login, "SAPUF");
    DBSETLHOST(login, Serv);
    DBSETLENCRYPT(login, TRUE);
    dbproc = dbopen(login, Serv);
    if (dbproc == NULL) {
       return 2;
    }
    dbclose(dbproc);
    dbexit();
    return 0;
}

int ObtenSapuf(char *pass, char *sAtributo,char **strResult)
{
	char    sOperacion[80], sMaqDestino[80];
	char    sUsuarioDestino[80], sTipoDestino[80];
	char    sAplDestino[80], sAplOrigen[80], Timer[6];
	char    s[257], sError[4], sSubError[4];
	long    res;
	int     tam, contador, iIntentos=0, maxIntentos=3;

	if(obtenvalor("Operacion", sOperacion)!=0 ||
	   obtenvalor("Maquina_Destino", sMaqDestino) !=0 ||
	   obtenvalor("Usuario_Destino", sUsuarioDestino) !=0 ||
	   obtenvalor("Tipo_Destino", sTipoDestino) !=0 ||
	   obtenvalor("Aplicacion_Destino", sAplDestino) !=0 ||
	   obtenvalor("Aplicacion_Origen", sAplOrigen) !=0 ||
//	   obtenvalor("Modo_refresco", sAtributo) !=0 ||
	   obtenvalor("Timer", Timer) != 0 )
	{
		sprintf(*strResult, "Error al obtener valor de archivo de parametros");
		return 1;
	}

	if ( !strcmp("3",sAtributo))
		sprintf(sOperacion,"01%02d",1);

	memset(pass,'\0',sizeof(pass));

	res = SolicitarPassword( sOperacion, sMaqDestino, sUsuarioDestino, \
					sTipoDestino, sAplDestino, sAplOrigen, sAtributo, Timer);
	if( res != 1 ) {	/*Error al invocar SolicitarPassword*/
		tam = RecuperarMsg(s, sError, sSubError);
		sprintf(*strResult, "Error de SAPUF Descripcion: [%s] Codigo: [%s] Subcodigo: [%s]",s, sError, sSubError );
		strcpy(pass,s);
	} else {	/*Exito al invocar SolicitarPassword*/
		tam = RecuperarMsg(s, sError, sSubError);
		sprintf(*strResult,"Descripcion: [%s] Codigo: [%s] Subcodigo: [%s]",s, sError, sSubError );
		strcpy(pass,s);
		return 0;
	}
	return 1;
}
