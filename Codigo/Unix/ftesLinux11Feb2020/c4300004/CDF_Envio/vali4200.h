#if USE_SCCSID
static char Sccsid[] = {"@(#) vali4200.c 24/01/2001"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include "sybdbex.h"
#include "simbolos.h"
#include "campos.h"	/*Para prueba, IERM*/

#define LONGCADENA4200    174  /*Ampliado de 168 a 174, IERM Sept. 17, 2004*/
#define LONGREGISTRO4200 71

union                                                                   
{                                                                       
char registro [LONGREGISTRO4200 + 2]; /* con retorno de carro y nulo*/  
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
} r4200;


union
{
char cadena [LONGCADENA4200 + 2]; /* con retorno de carro y nulo*/
struct
	{
      char recordidentifier[RECORDIDENTIFIER4200];
      char issuerica[ISSUERICA4200];
      char issuernumberica[ISSUERNUMBERICA4200];
      char corporationnumber[CORPORATIONNUMBER4200];
      char reservedforinternaluse1[RESERVEDFORINTERNALUSE14200];
      char reservedforinternaluse2[RESERVEDFORINTERNALUSE24200];
      char reservedforinternaluse3[RESERVEDFORINTERNALUSE34200];
      char organizationpointnumber[ORGANIZATIONPOINTNUMBER4200];
      char freeformattext[FREEFORMATTEXT4200];
      char reportsto[REPORTSTO4200];
      char reportstofreeformattext[REPORTSTOFREEFORMATTEXT4200];
      char reservedforinternaluse4[RESERVEDFORINTERNALUSE44200];
      char organizationhierarchymainact[ORGANIZATIONHIERARCHYMAINACT4200];
      char inputfilerecordnumber[INPUTFILERECORDNUMBER4200];
      char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE4200];
	} c;
} b4200;

vali4200(cadena4200, Arreglo4200, reg4200)
char cadena4200[];
char *Arreglo4200[];
int reg4200;
{  
  char *reporte;
  int largo,i;
  char leye[100];
      strcpy(b4200.cadena, cadena4200);
      largo = strlen(b4200.cadena);
      if (largo!=LONGCADENA4200)
      {
        printf("La lectura del registro 4200 es incorrecta (%d)\n",largo);
      }
      largo = (
      strlen(strncpy(recordidentifier4200, b4200.c.recordidentifier, RECORDIDENTIFIER4200)) +
      strlen(strncpy(issuerica4200, b4200.c.issuerica, ISSUERICA4200)) +
      strlen(strncpy(issuernumberica4200, b4200.c.issuernumberica, ISSUERNUMBERICA4200)) +
      strlen(strncpy(corporationnumber4200, b4200.c.corporationnumber, CORPORATIONNUMBER4200)) +
      strlen(strncpy(reservedforinternaluse14200, b4200.c.reservedforinternaluse1, RESERVEDFORINTERNALUSE14200)) +
      strlen(strncpy(reservedforinternaluse24200, b4200.c.reservedforinternaluse2, RESERVEDFORINTERNALUSE24200)) +
      strlen(strncpy(reservedforinternaluse34200, b4200.c.reservedforinternaluse3, RESERVEDFORINTERNALUSE34200)) +
      strlen(strncpy(organizationpointnumber4200, b4200.c.organizationpointnumber, ORGANIZATIONPOINTNUMBER4200)) +
      strlen(strncpy(freeformattext4200, b4200.c.freeformattext, FREEFORMATTEXT4200)) +
      strlen(strncpy(reportsto4200, b4200.c.reportsto, REPORTSTO4200)) +
      strlen(strncpy(reportstofreeformattext4200, b4200.c.reportstofreeformattext, REPORTSTOFREEFORMATTEXT4200)) +
      strlen(strncpy(reservedforinternaluse44200, b4200.c.reservedforinternaluse4, RESERVEDFORINTERNALUSE44200)) +
      strlen(strncpy(organizationhierarchymainact4200, b4200.c.organizationhierarchymainact, ORGANIZATIONHIERARCHYMAINACT4200)) +
      strlen(strncpy(inputfilerecordnumber4200, b4200.c.inputfilerecordnumber, INPUTFILERECORDNUMBER4200)) +
      strlen(strncpy(outgoingincomingerrorcode4200, b4200.c.outgoingincomingerrorcode, OUTGOINGINCOMINGERRORCODE4200)) );

      if ((largo)!= LONGCADENA4200)
      {
        printf("Error en longitud del registro 4200 (%d)%d\n\n",largo, LONGCADENA4200+1);
      }
      /* El registro corresponde a un registro tipo 4200
      y tanto la longiud de lo leido como la sumatoria de la longitud
      de los campos es la adecuada   */
      /* y ahora a checar cada uno de los campos      */
      /*se barre el arreglo de los campos y se asignan valores*/
      for (i = 0;i < reg4200;i++)
      {
        strcpy(r4200.registro,Arreglo4200[i]);
	strncpy(ftoNumCampo,r4200.a.ftonumcam,4); 
        strncpy(ftoNomCampo,r4200.a.ftonomcam,35);
        strncpy(ftoLongitud,r4200.a.ftolong,4);   
        strncpy(ftoTipoDato,r4200.a.ftotipodat,1);
        strncpy(ftoFill,r4200.a.ftofiller,1);     
        strncpy(ftoJustificado,r4200.a.ftojust,1);
        strncpy(ftoFormato,r4200.a.ftoforma,25);  
               
        switch(atoi(ftoNumCampo))             
        {
          case 1:
            valFormatogral(reporte, recordidentifier4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            /*valFormatogral(reporte, recordidentifier, ftoNomCampo, inputfilerecordnumber, ftoTipoDato, strcat(ftoFill,ftoJustificado));*/
            break;           
          case 2:
            valFormatogral(reporte, issuerica4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 3:
            valFormatogral(reporte, issuernumberica4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 4:
            valFormatogral(reporte, corporationnumber4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 5:
            valFormatogral(reporte, reservedforinternaluse14200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 6:
            valFormatogral(reporte, reservedforinternaluse24200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 7:
            valFormatogral(reporte, reservedforinternaluse34200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 8:
            valFormatogral(reporte, organizationpointnumber4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 9:
            valFormatogral(reporte, freeformattext4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 10:
            valFormatogral(reporte, reportsto4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 11:
            valFormatogral(reporte, reportstofreeformattext4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 12:
            valFormatogral(reporte, reservedforinternaluse44200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 13:
            valFormatogral(reporte, organizationhierarchymainact4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 14:
            valFormatogral(reporte, inputfilerecordnumber4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 15:
            valFormatogral(reporte, outgoingincomingerrorcode4200, ftoNomCampo, inputfilerecordnumber4200, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
        } /* Case numero de campo */
        ftoNumCampo[0]=NULL;          
        ftoNomCampo[0]=NULL;          
        ftoLongitud[0]=NULL;          
        ftoTipoDato[0]=NULL;          
        ftoFill[0]=NULL;              
        ftoJustificado[0]=NULL;       
        ftoFormato[0]=NULL;
      } /* Mientras existan registros / For i=0 a MAXCAMPOS */

      /** VALIDACIONES ESPECIFICAS DEL REGISTRO **/
      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN PUROS BLANCOS **/
      blancos(reporte,reservedforinternaluse14200,"reservedforinternaluse1", inputfilerecordnumber4200);
      blancos(reporte,reservedforinternaluse24200,"reservedforinternaluse2", inputfilerecordnumber4200);
      blancos(reporte,reservedforinternaluse34200,"reservedforinternaluse3", inputfilerecordnumber4200);
      blancos(reporte,freeformattext4200,"freeformattext", inputfilerecordnumber4200);
      blancos(reporte,reportsto4200, "reportsto", inputfilerecordnumber4200);
      blancos(reporte,reportstofreeformattext4200,"reportstofreeformattext", inputfilerecordnumber4200);
      blancos(reporte,reservedforinternaluse44200,"reservedforinternaluse4", inputfilerecordnumber4200);
      blancos(reporte,outgoingincomingerrorcode4200,"outgoingincomingerrorcode", inputfilerecordnumber4200);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN NUMEROS O ESPACIOS O GUIONES **/
      numespgui(reporte,corporationnumber4200,"corporationnumber", inputfilerecordnumber4200);
      numespgui(reporte,organizationpointnumber4200,"organizationpointnumber", inputfilerecordnumber4200);

      if (organizationhierarchymainact4200[0]!='A' && organizationhierarchymainact4200[0]!='U' && organizationhierarchymainact4200[0]!='D')
      {  
        printf("El campo organizationhierarchymainact solo acepta 'A' o 'U' o 'D' =%s=(%s)\n", organizationhierarchymainact4200, inputfilerecordnumber4200);
      }
      /** FIN DE LAS VALIDACIONES ESPECIFICAS **/
}
