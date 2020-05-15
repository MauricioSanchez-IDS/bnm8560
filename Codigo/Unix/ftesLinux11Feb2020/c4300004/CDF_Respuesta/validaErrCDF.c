#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include <sybfront.h>
#include <sybdb.h>
#include <string.h>
#include <sybdbex.h> /* Agregue esta linea para los PROTOTIPOS */
#include "qryrep.h" 
#include "lib_rep.h"
#include "conexion.h"
#include "risqldb.h"

int main(void)
{
 RISQL myStr;
 int i,camposQRY;
 int rsql,conta,lret;
 int bandera;
 char cad[8000];
 char fechas[8+1];
 char NomArch[255];
 char comando[50];
 FILE *archsal;
 FILE *archivofecha;
 char LsValor[255];
 char QryStr[8000];
 char dir_logs[255];

    //Genera archivo para obtención de fecha
    system("date +%d%m%Y > fecha");
    archivofecha = fopen("fecha","r");
    if (archivofecha == NULL)
    {
        printf("no se pudo abrir archivo de fecha \n");
        exit(1);
    }
    //Lee el archivo para obtener la fecha
    fgets(fechas, 8+1, archivofecha);
    sprintf(dir_logs,"%s/",getenv("DIR_LOGS"));
    strcpy(NomArch,dir_logs);
    strcat(NomArch,"Rep");
    strcat(NomArch,fechas);
    //printf("Archivo: %s\n",NomArch);
    archsal = fopen(NomArch, "w");
    if (archsal == NULL)
    {
        printf(" \n No se puede abrir el archivo de trabajo\n");
        exit(1);
    }
    //Comienza proceso de validación de error
    bandera =0;

    IniciaBase();

    for(i=10;i<=99;i++)
    {
        camposQRY=DevCamQry(i);
        if (camposQRY!=0)
        {
            /* IniciaBase(); */
            strcpy(QryStr,DevQryRep(i));
            myStr.scadena_sql = QryStr;
            myStr.icampos = camposQRY;
            myStr.lRegistros = 0;
            EjecutaSQL(&myStr);
            if(myStr.lRegistros != 0)
            {
                bandera = 1;
                rsql = RegistroPrimero(&myStr);
                do
                {
                    for(conta = 0; conta < myStr.icampos; conta++)
                    {
                        lret = ObtenCampo(&myStr, conta, LsValor); 
                        if ((fprintf(archsal, "%s\n", LsValor)) == -1)
                        {
                            printf("\n El registro no se guardo \n");
                            exit(1);
                        }//Fin de validación de grabado en el archivo
                    }//Fin for de recorrido de campos
                    rsql = RegistroSiguiente(&myStr);
                }while(rsql == 0);  //Fin de recorrido de registros consultados
            }//Fin if de datos en consulta
            Desconecta();
        }//Fin if numero de campos valido
    }//Fin for para obención de numero de campos
    if (bandera == 0)
    {
        sprintf(comando,"%s", "rm ");
        strcat(comando,NomArch);
        system(comando);
    }// fin bandera == 0
}// fin main
