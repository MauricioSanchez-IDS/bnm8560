#if USE_SCCSID
static char Sccsid[] = {"@(#) vali9999opt.c  02/15/2001"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include "sybdbex.h"
#include "simbolos.h"
#include "campos.h"		/*Para prueba, IERM*/

#define LONGCADENA9999     89  /*Ampliado de 83 a 89, IERM Sept. 17, 2004*/
#define LONGREGISTRO9999 71

union                                                                 
{                                                                     
char registro [LONGREGISTRO9999 + 2]; /* con retorno de carro y nulo*/
struct                                                                
        {                                                             
         char ftonumcam[4];                                           
         char ftonomcam[35];                                          
         char ftolong[4];                                             
         char ftotipodat[1];                                          
         char ftofiller[1];                                           
         char ftojust[1];                                             
         char ftoforma[25];                                           
        } a;                                                          
} r9999;                                                                  

union
{
char cadena [LONGCADENA9999 + 2]; /* con retorno de carro y nulo*/
struct
	{
	char recordidentifier[RECORDIDENTIFIER9999];
	char issuerica[ISSUERICA9999];
	char issuernumberica[ISSUERNUMBERICA9999];
	char reservedforinternaluse1[RESERVEDFORINTERNALUSE19999];
	char reservedforinternaluse2[RESERVEDFORINTERNALUSE29999];
	char reservedforinternaluse3[RESERVEDFORINTERNALUSE39999];
	char reservedforinternaluse4[RESERVEDFORINTERNALUSE49999];
	char numberofrecordsinthisfile[NUMBEROFRECORDSINTHISFILE9999];
	char inputfilerecordnumber[INPUTFILERECORDNUMBER9999];
	char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE9999];
	} c;
} b9999;

vali9999(cadena9999, Arreglo9999, reg9999)
char cadena9999[];
char *Arreglo9999[];
int reg9999;
{  
  char *reporte;
  int largo,i;
  char leye[100];
    
      strcpy(b9999.cadena,cadena9999);
      largo = strlen(b9999.cadena);
      if (largo!=LONGCADENA9999)
      {
        printf("La lectura del registro 9999 es incorrecta (%d)\n",largo);
      }
      largo = (
      strlen(strncpy(recordidentifier9999, b9999.c.recordidentifier, RECORDIDENTIFIER9999)) +
      strlen(strncpy(issuerica9999, b9999.c.issuerica, ISSUERICA9999)) +
      strlen(strncpy(issuernumberica9999, b9999.c.issuernumberica, ISSUERNUMBERICA9999)) +
      strlen(strncpy(reservedforinternaluse19999, b9999.c.reservedforinternaluse1, RESERVEDFORINTERNALUSE19999)) +
      strlen(strncpy(reservedforinternaluse29999, b9999.c.reservedforinternaluse2, RESERVEDFORINTERNALUSE29999)) +
      strlen(strncpy(reservedforinternaluse39999, b9999.c.reservedforinternaluse3, RESERVEDFORINTERNALUSE39999)) +
      strlen(strncpy(reservedforinternaluse49999, b9999.c.reservedforinternaluse4, RESERVEDFORINTERNALUSE49999)) +
      strlen(strncpy(numberofrecordsinthisfile9999, b9999.c.numberofrecordsinthisfile, NUMBEROFRECORDSINTHISFILE9999)) +
      strlen(strncpy(inputfilerecordnumber9999, b9999.c.inputfilerecordnumber, INPUTFILERECORDNUMBER9999)) +
      strlen(strncpy(outgoingincomingerrorcode9999, b9999.c.outgoingincomingerrorcode, OUTGOINGINCOMINGERRORCODE9999)) );

      if ((largo)!= LONGCADENA9999)
      {
        printf("Error en longitud del registro 9999 (%d)%d\n\n",largo, LONGCADENA9999+1);
      }
      /* El registro corresponde a un registro tipo 9999
      y tanto la longiud de lo leido como la sumatoria de la longitud
      de los campos es la adecuada   */
      /* y ahora a checar cada uno de los campos      */
      /*se barre el arreglo de los campos y se asignan valores*/
      for (i=0; i<reg9999; i++)      
      {
        strcpy(r9999.registro,Arreglo9999[i]);
	strncpy(ftoNumCampo,r9999.a.ftonumcam,4); 
        strncpy(ftoNomCampo,r9999.a.ftonomcam,35);
        strncpy(ftoLongitud,r9999.a.ftolong,4);   
        strncpy(ftoTipoDato,r9999.a.ftotipodat,1);
        strncpy(ftoFill,r9999.a.ftofiller,1);     
        strncpy(ftoJustificado,r9999.a.ftojust,1);
        strncpy(ftoFormato,r9999.a.ftoforma,25);  
                                               
        switch(atoi(ftoNumCampo))             
        {
          case 1:
            valFormatogral(reporte, recordidentifier9999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            /*ejemplo anterior : valFormatogral(reporte, recordidentifier, ftoNomCampo, inputfilerecordnumber, ftoTipoDato, strcat(ftoFill,ftoJustificado)) ; */
            break;           
          case 2:
            valFormatogral(reporte, issuerica9999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 3:
            valFormatogral(reporte, issuernumberica9999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 4:
            valFormatogral(reporte, reservedforinternaluse19999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 5:
            valFormatogral(reporte, reservedforinternaluse29999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 6:
            valFormatogral(reporte, reservedforinternaluse39999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 7:
            valFormatogral(reporte, reservedforinternaluse49999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 8:
            valFormatogral(reporte, numberofrecordsinthisfile9999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 9:
            valFormatogral(reporte, inputfilerecordnumber9999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 10:
            valFormatogral(reporte, outgoingincomingerrorcode9999, ftoNomCampo, inputfilerecordnumber9999, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
        } /* Case numero de campo */

        ftoNumCampo[0]=NULL;          
        ftoNomCampo[0]=NULL;          
        ftoLongitud[0]=NULL;          
        ftoTipoDato[0]=NULL;          
        ftoFill[0]=NULL;              
        ftoJustificado[0]=NULL;       
        ftoFormato[0]=NULL;       
      } /* For */

      /** VALIDACIONES ESPECIFICAS DEL REGISTRO **/
      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN PUROS BLANCOS **/
      blancos(reporte,reservedforinternaluse19999,"reservedforinternaluse1", inputfilerecordnumber9999);
      blancos(reporte,reservedforinternaluse29999,"reservedforinternaluse2", inputfilerecordnumber9999);
      blancos(reporte,reservedforinternaluse39999,"reservedforinternaluse3", inputfilerecordnumber9999);
      blancos(reporte,reservedforinternaluse49999,"reservedforinternaluse4", inputfilerecordnumber9999);
      blancos(reporte,outgoingincomingerrorcode9999,"outgoingincomingerrorcode", inputfilerecordnumber9999);
      /** FIN DE LAS VALIDACIONES ESPECIFICAS **/  
} /* fin main */

