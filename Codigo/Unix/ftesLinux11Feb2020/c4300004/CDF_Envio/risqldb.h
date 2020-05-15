#define __RISQLDB_H
#define	SQLBUFLEN	10000
#if defined(__cplusplus)
extern "C" {
#endif
#if defined(_PROTOTYPES)
int     ObtenRegistro(PTRRISQL, int);
/* int	RegistroSiguiente(PTRRISQL); */
int	RegistroPrevio(PTRRISQL);
int	RegistroPrimero(PTRRISQL);
int	RegistroUltimo(PTRRISQL);
int	ObtenCampo(PTRRISQL, int, char *); 
void	LiberaMemCab(PTRRISQL);
int	EjecutaSQL(PTRRISQL);
void    obtenvalor(char *, char *);
void    obtenvalorSapuf(char *, char *); 
int     revisaConexion(char *, char *, char *);
int     ObtenSapuf(char *, char *); 
int     getPassword(char *); 
#else
int     ObtenRegistro();
/* Int	RegistroSiguiente(); */
int	RegistroPrevio();
int	RegistroPrimero();
int	RegistroUltimo();
int	ObtenCampo();
void	LiberaMemCab();
int	EjecutaSQL();
void    obtenvalor();
void    obtenvalorSapuf(); 
int     revisaConexion();
int     ObtenSapuf(); 
int     getPassword();  
#endif
#if defined(__cplusplus)
}
#endif

#include "SAPUF_Enlace.h"

int ObtenRegistro(SetDatos,Num)
PTRRISQL SetDatos;
int      Num;
{
int bandera = -1;
   if( dbgetrow(SetDatos->dbproc, Num ) == NO_MORE_ROWS) {
   bandera = 1;
      }
   else {
	bandera = 0;
        SetDatos->lnumreg = DBCURROW(SetDatos->dbproc);
      }
 return bandera;
}

int	RegistroSiguiente(SetDatos) 
PTRRISQL SetDatos; 
{
int bandera = -1;
   if( dbgetrow(SetDatos->dbproc, DBCURROW(SetDatos->dbproc) + 1) == NO_MORE_ROWS) {
    bandera = 1;
   }
   else {
     bandera = 0;  
     SetDatos->lnumreg = DBCURROW(SetDatos->dbproc);
   }
return bandera;
}

int RegistroPrevio(SetDatos) 
PTRRISQL SetDatos;
{
int bandera = -1;
  if( dbgetrow(SetDatos->dbproc, DBCURROW(SetDatos->dbproc) - 1) == NO_MORE_ROWS) {
    bandera = 1;
   }
   else {
     bandera = 0;  
     SetDatos->lnumreg = DBCURROW(SetDatos->dbproc);
   }
return bandera;
}

int RegistroPrimero(SetDatos) 
PTRRISQL SetDatos;
{
int bandera = -1;
  if( dbgetrow(SetDatos->dbproc,  DBFIRSTROW(SetDatos->dbproc)) == NO_MORE_ROWS) {
     bandera = 1;  
    }
     else { 
    bandera = 0; 
    SetDatos->lnumreg = DBCURROW(SetDatos->dbproc);
      }
return bandera;
}

int RegistroUltimo(SetDatos) 
PTRRISQL SetDatos;
{
int bandera = -1;
   if( dbgetrow(SetDatos->dbproc, DBLASTROW(SetDatos->dbproc)) == NO_MORE_ROWS) { 
      bandera = 1;   
     }
  else {
     bandera = 0;  
     SetDatos->lnumreg = DBCURROW(SetDatos->dbproc);
    }
return bandera;
}

int ObtenCampo(SetDatos, icampo, sCadena)
PTRRISQL SetDatos;
int icampo;
char *sCadena;
{
int Bandera;
Campo *ActCampo;
Bandera = -1;
 
 if (icampo >= SetDatos->icampos ){
    printf("Error Campo: %d   no valido\n", icampo);
    return Bandera;
 }

ActCampo = SetDatos->Campos;
         if(icampo == ActCampo->inumcampo){
             strcpy(sCadena,(char *) SetDatos->Campos->Dato);
             Bandera = 0;
	     return Bandera;
	   }
    if (icampo > ActCampo->inumcampo){
    while (ActCampo->inumcampo != icampo) {
      if (ActCampo->Siguiente != NULL) {
	    SetDatos->Campos = ActCampo->Siguiente;
	    ActCampo = SetDatos->Campos; }
      else {
	Bandera = 1;
        return Bandera;
	}
    }
         strcpy(sCadena,(char *) SetDatos->Campos->Dato);
         Bandera = 0;
	 return Bandera;
    }
    else {
         while (ActCampo->inumcampo != icampo) {
            if (ActCampo->Previo != NULL){    
                SetDatos->Campos = ActCampo->Previo;
		ActCampo = SetDatos->Campos; }
             else {
	         Bandera = 1;
                 return Bandera;
		  }
        }  /* Fin del while */
         strcpy(sCadena,(char *) SetDatos->Campos->Dato);
         Bandera = 0;
	 return Bandera;
   }
 return Bandera;
}

void LiberaMemCab(SetDatos)
PTRRISQL SetDatos;
{
 Campo *CampoTem;
 dbclose(SetDatos->dbproc);

 while(SetDatos->Campos->Siguiente != NULL) {
CampoTem = SetDatos->Campos->Siguiente;
SetDatos->Campos = CampoTem;     
}
   while (SetDatos->Campos->Previo != NULL) {
   CampoTem = SetDatos->Campos->Previo;
   /*free(SetDatos->Campos->Dato);*/
   free(SetDatos->Campos);
   SetDatos->Campos = CampoTem;
   }

}


int getPassword(isPassword)
char  *isPassword;
{
    char usr[100], pas[100], passSapuf[250], ser[100], bas[100], cad[100], intentos[3];
    memset(usr, '\0',100); memset(pas, '\0',100); memset(ser, '\0',100); 
	memset(bas, '\0',100); memset(cad, '\0',100); memset(intentos, '\0',3);
    obtenvalorSapuf("USUARIO", usr);
    obtenvalorSapuf("SERVIDOR", ser);
    obtenvalorSapuf("BASE", bas);
    if ( ObtenSapuf(passSapuf, "0") == 0){
		 if (revisaConexion(usr,passSapuf,ser)==0) {
			strcpy(isPassword, passSapuf);
			return(0);
		 } else {
			 if ( ObtenSapuf(passSapuf, "2") == 0){
				 if (revisaConexion(usr,passSapuf,ser)==0) {
					strcpy(isPassword, passSapuf);
					return(0);
                                 } else {
                                         ObtenSapuf(passSapuf, "3");
                                         return(2);
                                 }
			 } else {
                                ObtenSapuf(passSapuf, "3");
                                return(2);
                         } 
		 } 
      }
      return(1);
}


void obtenvalorSapuf( parametro, valor)
char *parametro;
char *valor;
{
   FILE *a;
   char *c;
   char d[200];
   if ((a = fopen("/opt/c430/000/bin/parametrosSAPUF.txt", "r")) == NULL){
         fprintf(stdout,"No se puede abrir el Archivo de ParametrosSAPUF\n");
         return;
   }
   while(!feof(a)){
         fscanf(a,"%s\n",d);
         if (strncmp(d, parametro, strlen(parametro)) == 0 ){
         c = strstr(d, "=");
         strcpy(valor, ++c);
         }
   }
 fclose(a);

}



int revisaConexion(User, Pass, Serv)
char *User;
char *Pass;
char *Serv;
{
    LOGINREC    *login;
    DBPROCESS   *dbproc;
    char Host[255];
    if (dbinit() == FAIL)
       return 3;
     login = dblogin();
    DBSETLUSER(login, User);
    DBSETLPWD(login, Pass);
    DBSETLAPP(login, "SAPUF");
    DBSETLHOST(login, Serv);
    dbproc = dbopen(login, Serv);
    if (dbproc == NULL)
       return 2;
    dbclose(dbproc);
    dbexit();
    return 0;
}

 
int ObtenSapuf(pass, sAtributo)
char *pass;
char *sAtributo;
{
   char    sOperacion[80], sMaqDestino[80];
   char    sUsuarioDestino[80], sTipoDestino[80];
   char    sAplDestino[80], sAplOrigen[80], Timer[16];;
   long    res;
   int     tam, contador, iIntentos=0, maxIntentos=3;
   char    s[256],sError[4],sSubError[4];

   strcpy(sOperacion,"11");
   strcpy(sMaqDestino,"UEPSIMX");
   strcpy(sUsuarioDestino,"c430_dbo");
   strcpy(sTipoDestino,"SY");
   strcpy(sAplDestino,"SYB_C430");
   strcpy(sAplOrigen,"C430_001");
   strcpy(sAtributo,"0");
   strcpy(Timer,"9999");
  
   if ( !strcmp("3",sAtributo)) 
	   sprintf(sOperacion,"01%02d",1);

   for (contador =0; contador < 10; contador++  ) {
      memset(pass,'\0',255); 
      if(contador > 0) { 
          RecuperarMsg(s, sError, sSubError); 
          sleep(5); 
      }
      res = SolicitarPassword( sOperacion, sMaqDestino, sUsuarioDestino,sTipoDestino, sAplDestino, sAplOrigen, sAtributo, Timer);
      if( res != 1 ) {
          tam = RecuperarMsg(s, sError, sSubError);
          fprintf(stdout,"\nError Res= %l\n Descripcion: %s\n Codigo: %s\n Subcodigo: %s \n",res,s, sError, sSubError );
          strcpy(pass,s);
      } else {
          tam = RecuperarMsg(s, sError, sSubError);
          strcpy(pass,s);
          return 0;
      } 
   }
   return 1;
}


int EjecutaSQL(SetDatos)	/* sProceso, sParametro, ptrstrDatos) */
PTRRISQL SetDatos;
{

#include <time.h>

    long lnumreg;
    int i, j;
    Campo *campoTemp;
    char sqlcmd[SQLBUFLEN];
    DBPROCESS *pr;
    char usr[100];
    char pas[100];
    char ser[100];
    char bas[100];
    RETCODE result_code;
    FILE *a;
    char password[100];
    char variableAmbiente[250];
    time_t xtime;                                                           
    struct tm *xtmtime;                                                     
    char xcad[16], *xp = xcad, xanio[5];
    char passSapuf[250];

   int  retorno;
   char isPassword[100];

    fflush(stdout);

   putenv("DIR_SAPUF_CFG=/opt/c046/105/conf/sapufCentral.cfg");
   putenv("DIR_SAPUF_LOG=/opt/c430/000/var/log/c046AgenteRepCred.log");
   putenv("DIR_SAPUF_TMP=/opt/c430/000/var/log/c046AgenteRepCred.tmp");

  (void)time(&xtime);
  xtmtime = localtime(&xtime);
  strftime(xanio, 5, "%Y", (struct tm *) &xtmtime);
  sprintf(xanio, "%d", atoi(xanio) + xtmtime->tm_year); 

(void) memset((void *) isPassword, '\0', (size_t) 100);
  strcpy(isPassword,getenv("GE_PASSWORD"));   
  if( isPassword[0] =='\0')
  {
        fprintf(stdout,"EjecutaSQL No se pudo obtener el Password de SAPUF %s%02d%02d%02d%02d%02d", xanio,xtmtime->tm_mon + 1, xtmtime->tm_mday, xtmtime->tm_hour,xtmtime->tm_min, xtmtime->tm_sec);                        
         return FAIL;
  }

if (isPassword[0]=='\0') { 
   if ( ObtenSapuf(passSapuf, "0") == 0)
   {    
      strcpy(isPassword,passSapuf);
      sprintf(variableAmbiente,"PASSC430DBO=%s",isPassword);
      putenv(variableAmbiente);
   }
   else
   {
      fprintf(stdout,"EjecutaSQL No se pudo obtener el Password de SAPUF %s%02d%02d%02d%02d%02d", xanio,xtmtime->tm_mon + 1, xtmtime->tm_mday, xtmtime->tm_hour,xtmtime->tm_min, xtmtime->tm_sec);                        
       return FAIL;
}
}

  /* fprintf(stdout,"\n iPassword = -%s- \n",isPassword);
    strcpy(isPassword,"P48i37SX");*/

    strcpy(sqlcmd, SetDatos->scadena_sql);

    SetDatos->dbproc = pr;   
    lnumreg = 0;
    SetDatos->Campos = NULL;
    SetDatos->lnumreg = 0;

    (void) memset((void *) usr, '\0', (size_t) 100);
    (void) memset((void *) password, '\0', (size_t) 100);
    (void) memset((void *) pas, '\0', (size_t) 100);
    (void) memset((void *) ser, '\0', (size_t) 100);
    (void) memset((void *) bas, '\0', (size_t) 100);



    obtenvalor("USUARIO", usr);
   /* obtenvalor("PASSWORD", pas); se agrega codigo para obtener de SAPUF*/
    strcpy(pas,isPassword);
    obtenvalor("SERVIDOR", ser);
    obtenvalor("BASE", bas);
    ConectaBase(usr, pas, ser, bas,"Hyper", (DBPROCESS **) &(SetDatos->dbproc));
    dbsetopt(SetDatos->dbproc,DBBUFFER, "1500000", -1);
    dbcmd(SetDatos->dbproc, sqlcmd);
     if(dbsqlexec(SetDatos->dbproc) ==  FAIL) { 
    printf("\t ERROR AL EJECUTAR EL QUERY \n");
    return FAIL;
   }
       while ((result_code = dbresults(SetDatos->dbproc)) != NO_MORE_RESULTS) {
	if (dbrows(SetDatos->dbproc) != 0) {  
   	    if (result_code == SUCCEED) {
         for (i = 0; i < (SetDatos->icampos); i++) {
   	        campoTemp = (Campo *) malloc(sizeof(Campo));
	        campoTemp->Previo = NULL;
            campoTemp->Siguiente = NULL;
   	        campoTemp->inumcampo = i;
            if (SetDatos->Campos == NULL) {
   	           SetDatos->Campos = campoTemp;
               dbbind(SetDatos->dbproc, i + 1, STRINGBIND,(DBINT) 0,(BYTE *) SetDatos->Campos->Dato);  
  	         }
	         else {
            	campoTemp->Previo = (SetDatos)->Campos;
    	        ((SetDatos)->Campos)->Siguiente = campoTemp;
    	        (SetDatos)->Campos = campoTemp; 
                 dbbind(SetDatos->dbproc, i + 1, STRINGBIND,(DBINT) 0,(BYTE *) SetDatos->Campos->Dato);  
             }
           }           /*for */
           while (dbnextrow(SetDatos->dbproc) != NO_MORE_ROWS ) 
		      lnumreg++;
              SetDatos->lRegistros = lnumreg;
   	    }			/*if result_code */
	  }			/* if dbrows */
    }				/*while result_code */
    dbgetrow(SetDatos->dbproc, DBFIRSTROW(SetDatos->dbproc));  
    SetDatos->lnumreg = DBCURROW(SetDatos->dbproc);
    return 0;
}  /** Fin de l funcion  */

void obtenvalor( parametro, login)
char *parametro;
char *login;
{
   FILE *a;
   char *c;
   char d[51];

if ((a = fopen("/opt/c430/000/bin/parametros.txt", "r")) == NULL){
      printf("No se puede abrir el Archivo de Parametros\n");
      return;
}

   while(!feof(a)){ 
	 fscanf(a,"%s\n",d);
         if (strncmp(d, parametro, strlen(parametro)) == 0 ){
         c = strstr(d, "=");
	 strcpy(login, ++c);
         }
   }
 fclose(a);
}
