#include <stdio.h>
#include <sybfront.h>
#include <stdlib.h>
#include <sybdb.h>
#include <string.h>
#include <time.h>
#include "sybdbex.h"
#include "valoraMTC.h"

/* Forward declarations of the error handler and message handler. */
int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();
/*ARGUMENTOS*/
/* valoraMTC TABLA REGISTRO CAMPO VALOR */
main(argc, argv)
int argc;
char *argv[];
{
  int campos,Total,tablaReg, tamCampo,i,Reg;
  char fechaProceso[10];
  char Tabla[10],Registro[100],Campo[100], Valor[100];
  DBPROCESS     *q_dbproc;        

  if ((argc > 5) || (argc < 5))
  {
    printf("Programa: valoraMTC \n");
    printf("NUMERO DE ARGUMENTOS INVALIDO\n");
    printf("valoraMTC Tabla Registro Campo Valor\n");
    printf("EJEMPLO:\n");
    printf("valoraMTC REG5000 10 53 U\n");
    exit(1);
  }
  fflush(stdout);
  /*obtiene fecha y hora del proceso */
  time(&lcl_time);
  today = localtime(&lcl_time);
  strftime(fechayhora,20,"%Y%m%d %T",today);
  strncpy(fechaProceso, fechayhora, 8);
  /*Copia a las variables los parametros*/
  strcpy(Tabla,argv[1]);
  strcpy(Registro,argv[2]);
  strcpy(Campo,argv[3]);
  strcpy(Valor,argv[4]);

  if( dbinit() == FAIL)                                                         
  {                                                                             
   printf("Fecha proceso: %s\n", fechayhora);                                 
   printf("Programa  valoraMTC \n");
   printf("Error: No se inicializaron las dblibrary de C \n");                                                                          
   exit(1);                                                                   
  }                                                                             

  /* Instala las rutinas de manejo de errores */  
  dberrhandle((EHANDLEFUNC)err_handler);          
  dbmsghandle((MHANDLEFUNC)msg_handler);          

  strcpy(ge_user,'\0');
  strcpy(ge_password,'\0');
  strcpy(ge_server,'\0');
  strcpy(ge_hostname,'\0');
  strcpy(ge_dbase,'\0');

  /* Obtencion de valores de entorno */              
  sprintf(ge_user,"%s",getenv("GE_USER"));           
  sprintf(ge_password,"%s",getenv("GE_PASSWORD"));   
  sprintf(ge_server,"%s",getenv("GE_SERVER"));       
  sprintf(ge_hostname,"%s",getenv("GE_HOSTNAME"));   
  sprintf(ge_dbase,"%s",getenv("GE_DBASE"));         

  if( ( (strlen(ge_user) == 0)   || (strlen(ge_password) == 0) ||
    (strlen(ge_server) == 0) || (strlen(ge_hostname) == 0) ||
    (strlen(ge_dbase) == 0) ) )                             
  {                                                                     
    printf("Fecha proceso: %s\n", fechayhora);                         
    printf("Programa: valoraMTC.c \n");                                     
    printf("Error: debe verificar las variables de ambiente\n");       
    exit(1);                                                           
  }                                                                     
   /*Datos de Login*/
  login = dblogin();                          
  DBSETLUSER(login, ge_user);                 
  DBSETLPWD(login, ge_password);              
  DBSETLAPP(login, ge_hostname);              
  DBSETLHOST(login, ge_hostname);             
  DBSETLCHARSET(login,"roman8");
  DBSETVERSION(DBVERSION_100); 
  DBSETLENCRYPT(login, TRUE);
  BCP_SETL(login, TRUE);                      
  /*abrimos la base de datos.  */
  q_dbproc = dbopen(login, ge_server);        

  /*nos ubicamos en la base de datos */ 
  dbuse(q_dbproc, ge_dbase);            
/***********************************************************************/
  /* Obtiene el número de Tabla en el arreglo válido*/
  tablaReg=validaTabla(Tabla);  
  if (tablaReg==-1)
  {
    printf("\n No es posible actualizar la tabla. \n");
    exit (1);
  }
  if (tablaReg < 8)
  {
    /*Obtiene el número de campos de la tabla */
    campos=CamposTablasReg(tablaReg);

    if (atoi(Campo) > campos || atoi(Campo) < 1)
    {
      printf("\n El número de campo no es válido. \n");
      exit (1);
    }

    /* Obtiene el tamaño del campo */
    tamCampo=TamanioCampo(tablaReg, atoi(Campo)); 

    /* Obtiene el nombre del campo */
    strcpy(QryCampo,NombreCampo(tablaReg, atoi(Campo)));

    strcpy(sqlcmd,'\0');
    strcpy(sqlcmd, QueryValora(3,Tabla,QryCampo,Valor,Registro));    
    
    dbcmd(q_dbproc,sqlcmd);
    dbsqlexec(q_dbproc);
    result_code = dbresults(q_dbproc);
    if (result_code != SUCCEED)
    {
      printf("\nERROR AL ACTUALIZAR EL REGISTRO\n");
      exit(1);
    }  
    else 
    {
      printf("\n SE ACTUALIZO EL REGISTRO SATISFACTORIAMENTE.\n");
    }

    Total=0;
    for (i=0; i<8; i++)
    {   
      strcpy(sqlcmd,'\0');
      strcpy(sqlcmd, QueryValora(1,TablasReg[i],"","",""));
      dbcmd(q_dbproc,sqlcmd);
      if (dbsqlexec(q_dbproc) == FAIL)
      {
          printf("fallo el Query %s\n",sqlcmd);
          dbclose(q_dbproc);
          dbexit();
          exit(ERREXIT);
      }
      dbresults(q_dbproc);
      dbbind(q_dbproc, 1, NTBSTRINGBIND, (DBINT)0, (BYTE DBFAR *) Registros);
      dbnextrow(q_dbproc);
      Reg=atoi(Registros);
      Total+=Reg;
       
    }
    if (Total==0) /* si el Total de Registros Erroneos es Cero */
    {
      strcpy(sqlcmd,'\0');
      strcpy(sqlcmd, QueryValora(2, "","","",""));
      
      dbcmd(q_dbproc,sqlcmd);
      if (dbsqlexec(q_dbproc) == FAIL)
      {
          printf("fallo el Query %s\n",sqlcmd);
          dbclose(q_dbproc);
          dbexit();
          exit(ERREXIT);
      }
      result_code = dbresults(q_dbproc);
      if (result_code != SUCCEED)
      {
       printf("\nERROR AL ACTUALIZAR EL REGISTRO\n");
        exit(1);
      }     
      else 
      {
        printf("\n SE ACTUALIZO MTCPRO02 SATISFACTORIAMENTE.\n");
      }
    }
    else 
    {
      printf("\nTODAVIA EXISTEN  ERRORES EN LAS TABLAS REG\n");
      exit (1);
    }   
  } 
    
    /*cierra la conexion con sybse*/
  dbclose(q_dbproc);
  dbexit();
}/*main*/
