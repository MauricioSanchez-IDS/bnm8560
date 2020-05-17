#if USE_SCCSID
static char Sccsid[] = {"@(#) vali3000opt.c  01/05/2001"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include "sybdbex.h"
#include "campos.h" 		/*Para prueba, IERM*/
#include "simbolos.h"
/*#include "camFTO.h"*/
#include "ArchComunes.h"

#define LONGCADENA3000    398 /*Ampliado de 392 a 398, IERM Sept. 17, 2004*/ 
#define LONGREGISTRO3000 71 

 union                                                                  
{                                                                      
char registro [LONGREGISTRO3000 + 2]; /* con retorno de carro y nulo*/ 
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
} r3000;

union
{
char cadena [LONGCADENA3000 + 2]; /* con retorno de carro y nulo*/
struct
	{
      char recordidentifier[RECORDIDENTIFIER3000];
      char issuerica[ISSUERICA3000];
      char issuernumberica[ISSUERNUMBERICA3000];
      char reservedforinternaluse1[RESERVEDFORINTERNALUSE13000];
      char reservedforinternaluse2[RESERVEDFORINTERNALUSE23000];
      char reservedforinternaluse3[RESERVEDFORINTERNALUSE33000];
      char reservedforinternaluse4[RESERVEDFORINTERNALUSE43000];
      char issuernameline1[ISSUERNAMELINE13000];
      char issuernameline2[ISSUERNAMELINE23000];
      char addressline1[ADDRESSLINE13000];
      char addressline2[ADDRESSLINE23000];
      char city[CITY3000];
      char stateprovince[STATEPROVINCE3000];
      char country[COUNTRY3000];
      char postalcode[POSTALCODE3000];
      char currency[CURRENCY3000];
      char contactperson[CONTACTPERSON3000];
      char phonenumber[PHONENUMBER3000];
      char faxnumber[FAXNUMBER3000];
      char emailaddress[EMAILADDRESS3000];
      char addressmaintenanceaction[ADDRESSMAINTENANCEACTION3000];
      char inputfilerecordnumber[INPUTFILERECORDNUMBER3000];
      char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE3000];
	} c;
} b3000;

vali3000(Arreglo3000, reg3000)
char *Arreglo3000[80];
int reg3000;
{
  char *reporte;  
  int largo,i;
  char leye[100]; 

      strcpy(b3000.cadena,Arreglo3000[0]); 
      largo = strlen(b3000.cadena);
      if (largo!=LONGCADENA3000)
      {
        printf("La lectura del registro 3000 es incorrecta (%d)\n",largo);
      }
      largo = (
      strlen(strncpy(recordidentifier3000, b3000.c.recordidentifier, RECORDIDENTIFIER3000)) +
      strlen(strncpy(issuerica3000, b3000.c.issuerica, ISSUERICA3000)) +
      strlen(strncpy(issuernumberica3000, b3000.c.issuernumberica, ISSUERNUMBERICA3000)) +
      strlen(strncpy(reservedforinternaluse13000, b3000.c.reservedforinternaluse1, RESERVEDFORINTERNALUSE13000)) +
      strlen(strncpy(reservedforinternaluse23000, b3000.c.reservedforinternaluse2, RESERVEDFORINTERNALUSE23000)) +
      strlen(strncpy(reservedforinternaluse33000, b3000.c.reservedforinternaluse3, RESERVEDFORINTERNALUSE33000)) +
      strlen(strncpy(reservedforinternaluse43000, b3000.c.reservedforinternaluse4, RESERVEDFORINTERNALUSE43000)) +
      strlen(strncpy(issuernameline13000, b3000.c.issuernameline1, ISSUERNAMELINE13000)) +
      strlen(strncpy(issuernameline23000, b3000.c.issuernameline2, ISSUERNAMELINE23000)) +
      strlen(strncpy(addressline13000, b3000.c.addressline1, ADDRESSLINE13000)) +
      strlen(strncpy(addressline23000, b3000.c.addressline2, ADDRESSLINE23000)) +
      strlen(strncpy(city3000, b3000.c.city, CITY3000)) +
      strlen(strncpy(stateprovince3000, b3000.c.stateprovince, STATEPROVINCE3000)) +
      strlen(strncpy(country3000, b3000.c.country, COUNTRY3000)) +
      strlen(strncpy(postalcode3000, b3000.c.postalcode, POSTALCODE3000)) +
      strlen(strncpy(currency3000, b3000.c.currency, CURRENCY3000)) +
      strlen(strncpy(contactperson3000, b3000.c.contactperson, CONTACTPERSON3000)) +
      strlen(strncpy(phonenumber3000, b3000.c.phonenumber, PHONENUMBER3000)) +
      strlen(strncpy(faxnumber3000, b3000.c.faxnumber, FAXNUMBER3000)) +
      strlen(strncpy(emailaddress3000, b3000.c.emailaddress, EMAILADDRESS3000)) +
      strlen(strncpy(addressmaintenanceaction3000, b3000.c.addressmaintenanceaction, ADDRESSMAINTENANCEACTION3000)) +
      strlen(strncpy(inputfilerecordnumber3000, b3000.c.inputfilerecordnumber, INPUTFILERECORDNUMBER3000)) +
      strlen(strncpy(outgoingincomingerrorcode3000, b3000.c.outgoingincomingerrorcode, OUTGOINGINCOMINGERRORCODE3000)) );

      if ((largo)!= LONGCADENA3000)
      {
        printf("Error en longitud del registro 3000 (%d)%d\n\n",largo, LONGCADENA3000+1);
      }
      /* El registro corresponde a un registro tipo 3000
      y tanto la longiud de lo leido como la sumatoria de la longitud
      de los campos es la adecuada   */
      /* y ahora a checar cada uno de los campos      */
      /*se barre el arreglo de los campos y se asignan valores*/
      for (i=0;i < reg3000;i++)
      {                                                                      
	 strcpy(b3000.cadena,Arreglo3000[i]);
	 strncpy(ftoNumCampo,r3000.a.ftonumcam,4);
         strncpy(ftoNomCampo,r3000.a.ftonomcam,35);
         strncpy(ftoLongitud,r3000.a.ftolong,4);
         strncpy(ftoTipoDato,r3000.a.ftotipodat,1);
         strncpy(ftoFill,r3000.a.ftofiller,1);
         strncpy(ftoJustificado,r3000.a.ftojust,1);
         strncpy(ftoFormato,r3000.a.ftoforma,25);
        switch(atoi(ftoNumCampo))
        {
          case 1:
            valFormatogral(reporte,recordidentifier3000,"recordidentifier",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            /*valFormatogral(reporte,recordidentifier,"recordidentifier",inputfilerecordnumber,ftoTipoDato,strcat(ftoFill,ftoJustificado));*/
            break;           
            break;           
          case 2:
            valFormatogral(reporte,issuerica3000,"issuerica",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 3:
            valFormatogral(reporte,issuernumberica3000,"issuernumberica",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 4:
            valFormatogral(reporte,reservedforinternaluse13000,"reservedforinternaluse1",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 5:
            valFormatogral(reporte,reservedforinternaluse23000,"reservedforinternaluse2",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 6:
            valFormatogral(reporte,reservedforinternaluse33000,"reservedforinternaluse3",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 7:
            valFormatogral(reporte,reservedforinternaluse43000,"reservedforinternaluse4",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 8:
            valFormatogral(reporte,issuernameline13000,"issuernameline1",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 9:
            valFormatogral(reporte,issuernameline23000,"issuernameline2",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 10:
            valFormatogral(reporte,addressline13000,"addressline1",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 11:
            valFormatogral(reporte,addressline23000,"addressline2",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 12:
            valFormatogral(reporte,city3000,"city",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 13:
            valFormatogral(reporte,stateprovince3000,"stateprovince",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 14:
            valFormatogral(reporte,country3000,"country",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 15:
            valFormatogral(reporte,postalcode3000,"postalcode",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 16:
            valFormatogral(reporte,currency3000,"currency",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 17:
            valFormatogral(reporte,contactperson3000,"contactperson",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 18:
            valFormatogral(reporte,phonenumber3000,"phonenumber",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 19:
            valFormatogral(reporte,faxnumber3000,"faxnumber",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 20:
            valFormatogral(reporte,emailaddress3000,"emailaddress",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 21:
            valFormatogral(reporte,addressmaintenanceaction3000,"addressmaintenanceaction",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 22:
            valFormatogral(reporte,inputfilerecordnumber3000,"inputfilerecordnumber",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 23:
            valFormatogral(reporte,outgoingincomingerrorcode3000,"outgoingincomingerrorcode",inputfilerecordnumber3000,ftoTipoDato,ftoFill,ftoJustificado);
            break;
        } /* Case numero de campo */
        ftoNumCampo[0]=NULL;           
        ftoNomCampo[0]=NULL;           
        ftoLongitud[0]=NULL;           
        ftoTipoDato[0]=NULL;           
        ftoFill[0]=NULL;               
        ftoJustificado[0]=NULL;        
        ftoFormato[0]=NULL;                   
      } /* For i=0 a MAXCAMPOS */
      /** VALIDACIONES ESPECIFICAS DEL REGISTRO **/
      blancos(reporte,reservedforinternaluse13000,"reservedforinternaluse1", inputfilerecordnumber3000);
      blancos(reporte,reservedforinternaluse23000,"reservedforinternaluse2", inputfilerecordnumber3000);
      blancos(reporte,reservedforinternaluse33000,"reservedforinternaluse3", inputfilerecordnumber3000);
      blancos(reporte,reservedforinternaluse43000,"reservedforinternaluse4", inputfilerecordnumber3000);
      blancos(reporte,outgoingincomingerrorcode3000,"outgoingincomingerrorcode", inputfilerecordnumber3000);
      numespgui(reporte,postalcode3000,"postalcode", inputfilerecordnumber3000);
      numespgui(reporte,phonenumber3000,"phonenumber", inputfilerecordnumber3000);
      numespgui(reporte,faxnumber3000,"faxnumber",inputfilerecordnumber3000);
      if (!(country3000[0]=='M' && country3000[1]=='E' && country3000[2]=='X'))
      {
        printf("El campo country solo acepta 'MEX' =%s=(%s)\n", country3000, inputfilerecordnumber3000);
      }
      if (!(currency3000[0]=='4' && currency3000[1]=='8' && currency3000[2]=='4'))
      {
        printf("El campo currency solo acepta '484' =%s=(%s)\n", currency3000, inputfilerecordnumber3000);
      }
      if (*b3000.c.addressmaintenanceaction!='U')
      {  
        printf("El campo addressmaintenanceaction solo acepta 'U' =%s=(%s)\n", addressmaintenanceaction3000, inputfilerecordnumber3000);
      }
      /** FIN DE LAS VALIDACIONES ESPECIFICAS **/
}
/********************************************************************************************/
