#if USE_SCCSID
static char Sccsid[] = {"@(#) vali1000opt.c  12/29/2000"};
#endif /* USE_SCCSID */

#include <sybfront.h>
#include <sybdb.h>
#include "sybdbex.h"
#include <string.h> 
#include <stdlib.h> 
#include <stdio.h> 
#include "simbolos.h"
#include "campos.h"		/*Para prueba, IERM*/

#define LONGCADENA1000    187 /*Ampliado de 181 a 187, IERM Sept. 17, 2004*/  
#define LONGREGISTRO1000 71

union
{
char registro [LONGREGISTRO1000 + 2]; /* con retorno de carro y nulo*/
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
} r1000;

union
{
char cadena [LONGCADENA1000 + 2]; /* con retorno de carro y nulo*/
struct
	{
      char recordidentifier[RECORDIDENTIFIER1000];
      char issuerica[ISSUERICA1000];
      char issuernumberica[ISSUERNUMBERICA1000];
      char reservedforinternaluse1[RESERVEDFORINTERNALUSE11000];
      char reservedforinternaluse2[RESERVEDFORINTERNALUSE21000];
      char reservedforinternaluse3[RESERVEDFORINTERNALUSE31000];
      char reservedforinternaluse4[RESERVEDFORINTERNALUSE41000];
      char rejectionlevel[REJECTIONLEVEL1000];
      char providingfromdate[PROVIDINGFROMDATE1000];
      char providingtodate[PROVIDINGTODATE1000];
      char runmodeindicator[RUNMODEINDICATOR1000];
      char filereferencenumber[FILEREFERENCENUMBER1000];
      char custumerprocessornumber[CUSTUMERPROCESSORNUMBER1000];
      char custumerprocessorname[CUSTUMERPROCESSORNAME1000];
      char cdfversionnumber[CDFVERSIONNUMBER1000];
      char inputfilerecordnumber[INPUTFILERECORDNUMBER1000];
      char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE1000];
	} c;
} b1000;
/********************************************************************************************/
vali1000(char *cadena1000,char Arreglo1000[][80], int reg1000)
{
      char *reporte;
      char sqlcmd[SQLBUFLEN]; 
      char leye[100];
      int largo,rsql,i,j, nregistros; 
      strcpy(sqlcmd,"");
      strcpy(sqlcmd,"select * from REG1000");

  /*obtener los campos*/
      strcpy(b1000.cadena,cadena1000);
      largo = strlen(b1000.cadena);
      if (largo!=LONGCADENA1000) 
      {
        printf("La lectura del registro 1000 es incorrecta (%d %d)\n",largo, LONGCADENA1000);
      }
      largo = (
      strlen(strncpy(recordidentifier1000, b1000.c.recordidentifier, RECORDIDENTIFIER1000)) +
      strlen(strncpy(issuerica1000, b1000.c.issuerica, ISSUERICA1000)) +
      strlen(strncpy(issuernumberica1000, b1000.c.issuernumberica, ISSUERNUMBERICA1000)) +
      strlen(strncpy(reservedforinternaluse11000, b1000.c.reservedforinternaluse1, RESERVEDFORINTERNALUSE11000)) +
      strlen(strncpy(reservedforinternaluse21000, b1000.c.reservedforinternaluse2, RESERVEDFORINTERNALUSE21000)) +
      strlen(strncpy(reservedforinternaluse31000, b1000.c.reservedforinternaluse3, RESERVEDFORINTERNALUSE31000)) +
      strlen(strncpy(reservedforinternaluse41000, b1000.c.reservedforinternaluse4, RESERVEDFORINTERNALUSE41000)) +
      strlen(strncpy(rejectionlevel1000, b1000.c.rejectionlevel, REJECTIONLEVEL1000)) +
      strlen(strncpy(providingfromdate1000, b1000.c.providingfromdate, PROVIDINGFROMDATE1000)) +
      strlen(strncpy(providingtodate1000, b1000.c.providingtodate, PROVIDINGTODATE1000)) +
      strlen(strncpy(runmodeindicator1000, b1000.c.runmodeindicator, RUNMODEINDICATOR1000)) +
      strlen(strncpy(filereferencenumber1000, b1000.c.filereferencenumber, FILEREFERENCENUMBER1000)) +
      strlen(strncpy(custumerprocessornumber1000, b1000.c.custumerprocessornumber, CUSTUMERPROCESSORNUMBER1000)) +
      strlen(strncpy(custumerprocessorname1000, b1000.c.custumerprocessorname, CUSTUMERPROCESSORNAME1000)) +
      strlen(strncpy(cdfversionnumber1000, b1000.c.cdfversionnumber, CDFVERSIONNUMBER1000)) +
      strlen(strncpy(inputfilerecordnumber1000, b1000.c.inputfilerecordnumber, INPUTFILERECORDNUMBER1000)) +
      strlen(strncpy(outgoingincomingerrorcode1000, b1000.c.outgoingincomingerrorcode, OUTGOINGINCOMINGERRORCODE1000)));

      if ((largo)!= LONGCADENA1000)
      {
        printf("Error en longitud del registro 1000 (%d)%d\n\n",largo, LONGCADENA1000+1);
      }
      /* El registro corresponde a un registro tipo 1000
      y tanto la longiud de lo leido como la sumatoria de la longitud
      de los campos es la adecuada   */
      /* y ahora a checar cada uno de los campos      */
      /*se barre el arreglo de los campos y se asignan valores*/
      for (i = 0;i < reg1000; i++)
      {
	// HP strcpy(r1000.registro, *Arreglo1000[i]);
	strcpy(r1000.registro, Arreglo1000[i]);
        strncpy(ftoNumCampo,r1000.a.ftonumcam,4);
        strncpy(ftoNomCampo,r1000.a.ftonomcam,35);
        strncpy(ftoLongitud,r1000.a.ftolong,4);
        strncpy(ftoTipoDato,r1000.a.ftotipodat,1);
        strncpy(ftoFill,r1000.a.ftofiller,1);
        strncpy(ftoJustificado,r1000.a.ftojust,1);
        strncpy(ftoFormato,r1000.a.ftoforma,25);
     
        switch(atoi(ftoNumCampo))
        {
          case 1:
            valFormatogral(reporte, recordidentifier1000, "recordidentifier", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            /*Ejemplo anterior : valFormatogral(reporte, recordidentifier, "recordidentifier", inputfilerecordnumber, ftoTipoDato, strcat(ftoFill, ftoJustificado));*/
            break;
          case 2:
            valFormatogral(reporte, issuerica1000, "issuerica", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 3:
            valFormatogral(reporte, issuernumberica1000, "issuernumberica", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 4:
            valFormatogral(reporte, reservedforinternaluse11000, "reservedforinternaluse1", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 5:
            valFormatogral(reporte, reservedforinternaluse21000, "reservedforinternaluse2", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 6:
            valFormatogral(reporte, reservedforinternaluse31000, "reservedforinternaluse3", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 7:
            valFormatogral(reporte, reservedforinternaluse41000, "reservedforinternaluse4", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 8:
            valFormatogral(reporte, rejectionlevel1000, "rejectionlevel", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 9:
            valFormatogral(reporte, providingfromdate1000, "providingfromdate", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 10:
            valFormatogral(reporte, providingtodate1000, "providingtodate", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 11:
            valFormatogral(reporte, runmodeindicator1000, "runmodeindicator", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 12:
            valFormatogral(reporte, filereferencenumber1000, "filereferencenumber", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 13:
            valFormatogral(reporte, custumerprocessornumber1000, "custumerprocessornumber", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 14:
            valFormatogral(reporte, custumerprocessorname1000, "custumerprocessorname", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 15:
            valFormatogral(reporte, cdfversionnumber1000, "cdfversionnumber", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 16:
            valFormatogral(reporte, inputfilerecordnumber1000, "inputfilerecordnumber", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 17:
            valFormatogral(reporte, outgoingincomingerrorcode1000, "outgoingincomingerrorcode", inputfilerecordnumber1000, ftoTipoDato, ftoFill, ftoJustificado);
            break;
        } /*Case numero de campo */
        ftoNumCampo[0]=NULL;   
        ftoNomCampo[0]=NULL;   
        ftoLongitud[0]=NULL;   
        ftoTipoDato[0]=NULL;   
        ftoFill[0]=NULL;       
        ftoJustificado[0]=NULL;
        ftoFormato[0]=NULL;    
      } /* For */
          
      /** VALIDACIONES ESPECIFICAS DEL REGISTRO    **/
      blancos(reporte,reservedforinternaluse11000,"reservedforinternaluse1", inputfilerecordnumber1000);
      blancos(reporte,reservedforinternaluse21000,"reservedforinternaluse2", inputfilerecordnumber1000);
      blancos(reporte,reservedforinternaluse31000,"reservedforinternaluse3", inputfilerecordnumber1000);
      blancos(reporte,reservedforinternaluse41000,"reservedforinternaluse4", inputfilerecordnumber1000);
      blancos(reporte,outgoingincomingerrorcode1000,"outgoingincomingerrorcode", inputfilerecordnumber1000);
      numespdosp(reporte,filereferencenumber1000, "filereferencenumber", inputfilerecordnumber1000);

      if (rejectionlevel1000[0]!='T')
      {
        printf ("El campo rejectionlevel solo acepta 'T' como valor =%s= (%s)\n", rejectionlevel1000, inputfilerecordnumber1000);
      }
      if (providingfromdate1000[8] !=SP || providingfromdate1000[11]!=DOSPUNTOS || providingfromdate1000[14]!=DOSPUNTOS)
      {  
        printf("Falta el espacio o los dos puntos en fecha providingfromdate =%s= (%s)\n",providingfromdate1000,inputfilerecordnumber1000);
      }
      if (providingtodate1000[8] !=SP || providingtodate1000[11]!=DOSPUNTOS || providingtodate1000[14]!=DOSPUNTOS)
      {  
        printf("Falta el espacio o los dos puntos en fecha providingtodate =%s= (%s)\n",providingtodate1000,inputfilerecordnumber1000);
      }
      if (runmodeindicator1000[0]!='C' && runmodeindicator1000[0]!='P')
      {
         printf("El campo runmodeindicator solo acepta 'C' 0 'P' como valor =%s= (%s)\n", runmodeindicator1000, inputfilerecordnumber1000);
      }
      if (cdfversionnumber1000[0]!='2'|| cdfversionnumber1000[1]!=PUNTO || cdfversionnumber1000[2]!='0' || cdfversionnumber1000[3]!='0')
      {
        printf("El campo cdfversionnumber solo acepta '2.00' como valor =%s= (%s)\n", cdfversionnumber1000, inputfilerecordnumber1000);
      }
      /** FIN DE LA VALIDACIONES ESPECIFICAS **/  
} /* fin main principal */
/********************************************************************************************/
