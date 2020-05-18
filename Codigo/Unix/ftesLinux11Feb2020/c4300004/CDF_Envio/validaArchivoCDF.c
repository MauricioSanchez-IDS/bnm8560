#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include <string.h>
#include <sybfront.h>
#include <sybdb.h>
#include "sybdbex.h"
#include "campos.h"
#include "camFTO.h"
#include "substr.h"
#include "archivoCDF.h"
#include "vali1000.h"
#include "vali3000.h"
#include "vali4000.h"
#include "vali4100.h"
#include "vali4200.h"
#include "vali4300.h"
#include "vali5000.h"
#include "vali9999.h"
#include "llena.h"
#include "lib_rep.h"

/* #include "genvar1.h"
#include "conexion.h"
#include "risqldb.h" */

#define CADENA 734
#define CADENA1000 189/*Estos campos se les suma 6 por la expansion del campo issuerica, IERM Sept. 20, 2004*/
#define CADENA3000 400
#define CADENA4000 615
#define CADENA4100 657
#define CADENA4200 176
#define CADENA4300 734
#define CADENA5000 540
#define CADENA9999 91

char cadena[ CADENA ];
char cadena1000[CADENA1000 ];
char cadena3000[CADENA3000 ];
char cadena4000[CADENA4000 ];
char cadena4100[CADENA4100 ];
char cadena4200[CADENA4200 ];
char cadena4300[CADENA4300 ];
char cadena5000[CADENA5000 ];
char cadena9999[CADENA9999 ];

#if defined(__cplusplus)
extern "C" {
#endif

#if defined(_PROTOTYPES)
    int     ObtenRegistro(PTRRISQL, int);
        int             RegistroSiguiente(PTRRISQL);
        int             RegistroPrevio(PTRRISQL);
        int             RegistroPrimero(PTRRISQL);
        int             RegistroUltimo(PTRRISQL);
        int             ObtenCampo(PTRRISQL, int, char *);
        void    LiberaMemCab(PTRRISQL);
        int     EjecutaSQL(PTRRISQL);
        void    obtenvalor(char *, char *);
#else
    int     ObtenRegistro();
        int             RegistroSiguiente();
        int             RegistroPrevio();
        int             RegistroPrimero();
        int             RegistroUltimo();
        int             ObtenCampo();
        void    LiberaMemCab();
        int     EjecutaSQL();
        void    obtenvalor();
#endif

#if defined(__cplusplus)
}
#endif



/********************** MAIN ************************/

main(numarg, arg)
int numarg;
char *arg[];
{
FILE *archivo;

struct strCampo {
        int                              inumcampo;
        struct strCampo         *Previo;
        struct strCampo         *Siguiente;
        DBCHAR          Dato[PARTAMANO];

};
typedef struct strCampo Campo;

struct strRISQL{
        char *scadena_sql;
        int       icampos;
        long   lRegistros;
        Campo     *Campos;
        long      lnumreg;
        DBPROCESS *dbproc;
};
typedef struct strRISQL RISQL; 
typedef RISQL *PTRRISQL;

RISQL myStr;

int i,pid,rsql,k,j;
char Arreglo1000[100][80]; char Arreglo3000[100][80]; char Arreglo4000[100][80]; 
char Arreglo4100[100][80]; char Arreglo4200[100][80]; char Arreglo4300[100][80]; 
char Arreglo5000[100][80]; char Arreglo9999[100][80]; char valor[100];
char idrecord[4 + 1];
/* contadores de los registros */
int reg1000=0; int reg3000=0; int reg4000=0; int reg4100=0; 
int reg4200=0; int reg4300=0; int reg5000=0; int reg9999=0;
int nregistros; 
char campo1[ 4 + 1 ];char campo2[35 + 1];char campo3[4 + 1];char campo4[1 + 1];char campo5[1 + 1];char campo6[1 + 1];
char campo7[ 25 + 1 ];
char hora[ 50 ];
char aux[ 79 ];
char Registro[ 4 + 1 ]; 
char sqlcmd[ SQLBUFLEN ]; 
char *cadena1;
char s;


//fflush(stdout);
printf("Hora De inicio del proceso para validar los registros del archivo cdf \n");
strcpy(hora,system("date \"+%I:%M:%S %p\"\n"));
printf("%s\n", hora);

dberrhandle((EHANDLEFUNC)err_handler);
dbmsghandle((MHANDLEFUNC)msg_handler);

for (i=0;i<8; i++){
	switch(i){
	case 0:
		strcpy(Registro,"1000"); break;
    	case 1:
		strcpy(Registro,"3000"); break;
    	case 2:
		strcpy(Registro,"4000"); break;
    	case 3:
		strcpy(Registro,"4100"); break;
    	case 4:
		strcpy(Registro,"4200"); break;
    	case 5: 
		strcpy(Registro,"4300"); break;
    	case 6:
		strcpy(Registro,"5000"); break;
    	case 7:
		strcpy(Registro,"9999"); break;
	} /*switch*/
        strcpy(sqlcmd, "\0");
	strcpy(sqlcmd, "select ftoNumCampo, ftoNomCampo, ftoLongitud, ");
	strcat(sqlcmd, "ftoTipoDato, ftoFill, ftoJustificado, ftoFormato ");
	strcat(sqlcmd, "from MTCFTO01 ");
	strcat(sqlcmd, "where tabIdTabla ='");
	strcat(sqlcmd, Registro);
        strcat(sqlcmd, "'");
	IniciaBase ();  /*Conecta a la base y ejecuta Query*/
	myStr.scadena_sql = sqlcmd; /* Sentencia SQL */
	myStr.icampos = 7; /* Campos a retornar */
	myStr.lRegistros = 0; /* Registros iniciales */
	EjecutaSQL(&myStr); /* Ejecuta el Query */
	nregistros = myStr.lRegistros; /* Obtiene el numero de registros */
	rsql=RegistroPrimero(&myStr);
        do{
        j= ObtenCampo(&myStr, 0, campo1);
	j= ObtenCampo(&myStr, 1, campo2);
	j= ObtenCampo(&myStr, 2, campo3);
	j= ObtenCampo(&myStr, 3, campo4);
	j= ObtenCampo(&myStr, 4, campo5);
	j= ObtenCampo(&myStr, 5, campo6);
	j= ObtenCampo(&myStr, 6, campo7);
	strcpy(aux,"");
	strcat (aux,formatea(campo1,4, ' ','D',"NULL",'N','1'));
	strcat (aux,formatea(campo2,35,' ','D',"NULL",'N','1'));
	strcat (aux,formatea(campo3,4, ' ','D',"NULL",'N','1'));
	strcat (aux,formatea(campo4,1, ' ','I',"NULL",'N','1'));
	strcat (aux,formatea(campo5,1, ' ','I',"NULL",'N','1'));
	strcat (aux,formatea(campo6,1, ' ','I',"NULL",'N','1'));
	strcat (aux,formatea(campo7,25,' ','D',"NULL",'N','1'));
        cadena1=aux;
        switch(i){
		case 0:
		        strcpy(Arreglo1000[reg1000],cadena1);
		        reg1000++;
                        break;
		case 1:
		       	strcpy(Arreglo3000[reg3000],cadena1); 
			reg3000++;
			break;
		case 2:
			strcpy(Arreglo4000[reg4000],cadena1);
			reg4000++;
			break;
		case 3:
			strcpy(Arreglo4100[reg4100],cadena1);
			reg4100++;
			break;
		case 4:
			strcpy(Arreglo4200[reg4200],cadena1);
			reg4200++;
			break;
		case 5: 
			strcpy(Arreglo4300[reg4300],cadena1);
			reg4300++;
			break;
		case 6:
			strcpy(Arreglo5000[reg5000],cadena1);
			reg5000++;
			break;
		case 7:
			strcpy(Arreglo9999[reg9999],cadena1);
			reg9999++;
			break;
		}
        rsql = RegistroSiguiente(&myStr);
	}while (rsql == 0);
}/*for*/
	/* Segunda Parte*/
if (numarg == 2)
  {
    archivo=fopen(arg[1],"rb");
      if (archivo==NULL)
      {
        printf("No se pudo abrir al archivo de trabajo =%s=\n", arg[1]);
        exit(1);
      } /*if*/
      else
      {
       strcpy( cadena, "\0" );
      while(fgets(cadena,CADENA,archivo)) /*lee retorno */
       {
         strcpy( idrecord,"\0" );
		 strncpy( idrecord, cadena, 4 );
         switch( atoi( idrecord ) )
         {
         case 1000:
              strcpy(cadena1000,substr(cadena,1,187));
              if ((pid = fork()) == -1)
                {
                 printf("\nerror, no puedo hacer el fork\n ");
                 exit(1);
                } /*if*/
              else if (!pid)
                {
                 vali1000(cadena1000, Arreglo1000, reg1000);
                 exit(0);
                }/*else*/
              else
                {
                  wait((int *)0);
                } /*else*/
              /*getchar(); */
              break;
         case 3000:
              strcpy(cadena3000,substr(cadena,1,398));
              if ((pid = fork()) == -1)
                {
                 printf("\nerror, no puedo hacer el fork\n ");
                 exit(1);
                }
              else if (!pid)
                {
                 vali3000(cadena3000, Arreglo3000, reg3000);
                 exit(0);
                }
              else
                {
                  wait((int *)0);
                }
              break;
         case 4000:
              strcpy(cadena4000,substr(cadena,1,613));
              if ((pid = fork()) == -1)
                {
                 printf("\nerror, no puedo hacer el fork\n ");
                 exit(1);
                }
              else if (!pid)
                {
		 vali4000( cadena4000, Arreglo4000, reg4000);
                 exit(0);
                }
              else
                {
                  wait((int *)0);
                }
              break; 
         case 4100:
              strcpy(cadena4100,substr(cadena,1,655));
              if ((pid = fork()) == -1)
                {
                 printf("\nerror, no puedo hacer el fork\n ");
                 exit(1);
                }
              else if (!pid)
                {
                 vali4100(cadena4100, Arreglo4100,reg4100);
                 exit(0);
                }
              else
                {
                  wait((int *)0);
                }
              break; 
         case 4200:
              strcpy(cadena4200,substr(cadena,1,174));
              if ((pid = fork()) == -1)
                {
                 printf("\nerror, no puedo hacer el fork\n ");
                 exit(1);
                }
              else if (!pid)
                {
		 vali4200(cadena4200, Arreglo4200, reg4200);
                 exit(0);
                }
              else
                {
                  wait((int *)0);
                }
              break; 
         case 4300:
              strncpy( cadena4300, cadena,732 );
              if ((pid = fork()) == -1)
                {
                 printf("\nError, no puedo hacer el fork\n ");
                 exit(1);
                }
              else if (!pid)
                {
		 vali4300(cadena4300, Arreglo4300, reg4300);
                 exit(0);
                }
              else
                {
                  wait((int *)0);
                }
              break; 
         case 5000:
              strcpy(cadena5000,substr(cadena,1,538));
              if ((pid = fork()) == -1)
                {
                 printf("\nerror, no puedo hacer el fork\n ");
                 exit(1);
                }
              else if (!pid)
                {
		 vali5000( cadena5000, *Arreglo5000, reg5000);
                 exit(0);
                }
              else
                {
                  wait((int *)0);
                }
              break; 
         case 9999:
              strcpy(cadena9999,substr(cadena,1,89));
              if ((pid = fork()) == -1)
                {
                 printf("\nerror, no puedo hacer el fork\n ");
                 exit(1);
                }
              else if (!pid)
                {
		 vali9999(cadena9999, *Arreglo9999, reg9999);
                 exit(0);
                }
              else
                {
                  wait((int *)0);
                }
              break; 
         default:
              printf("El registro leido es erroneo saldre de la aplicacion\n");
              printf("verifique el contenido del archivo\n");
              fclose(archivo);
              exit(1); 
              break; 
        } /* fin switch */
       } /* fin while de lectura del archivo */ 
      } /* else apaertura del archivo */ 
  }/* mientras sean dos los parametros recibidos */
  else /* parametros incorrectos en la llamada del programa */ 
  {
    printf("***************************************************************\n");
    printf("* debe proporcionar el nombre del archivo a analizar *\n");
    printf("*           PROGRAMA 'espacio' Nombre_Archivo                 *\n");
    printf("***************************************************************\n");
  }

  Desconecta(); /* Corta la conexion con la BD */
  printf("Hora de termino del proceso para validar los registros del archivo cdf\n");
  strcpy(hora,system("date \"+%I:%M:%S %p\"\n"));
  printf("%s\n", hora);
  fclose(archivo);
  exit(0);
}