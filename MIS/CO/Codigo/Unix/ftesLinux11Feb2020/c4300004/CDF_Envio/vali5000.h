#if USE_SCCSID
static char Sccsid[] = {"@(#) vali5000opt.c  02/06/2001"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include "sybdbex.h"
#include "simbolos.h"
#include "campos.h"	/*Para prueba, IERM*/

#define LONGCADENA5000   538 /*Ampliado de 507 a 531, IERM Sept. 17, 2004*/
#define LONGREGISTRO5000 71

union                                                                 
{                                                                     
char registro [LONGREGISTRO5000 + 2]; /* con retorno de carro y nulo*/
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
} r5000;                                                                  

union
{
char cadena [LONGCADENA5000 + 2]; /* con retorno de carro y nulo*/
struct
	{
     char recordidentifier[RECORDIDENTIFIER5000];
     char issuerica[ISSUERICA5000];
     char issuernumberica[ISSUERNUMBERICA5000];
     char corporationnumber[CORPORATIONNUMBER5000];
     char addendumtype[ADDENDUMTYPE5000];
     char reservedforinternaluse1[RESERVEDFORINTERNALUSE15000];
     char reservedforinternaluse2[RESERVEDFORINTERNALUSE25000];
     char merchantacttranoriginind[MERCHANTACTTRANORIGININD5000];
     char accountnumber[ACCOUNTNUMBER5000];
     char reservedforinternaluse3[RESERVEDFORINTERNALUSE35000];
     char acquirersorissuersrefnum[ACQUIRERSORISSUERSREFNUM5000];
     char recordtype[RECORDTYPE5000];
     char transactiontype[TRANSACTIONTYPE5000];
     char debitcreditindicator[DEBITCREDITINDICATOR5000];
     char transactionamount[TRANSACTIONAMOUNT5000];
     char postingdate[POSTINGDATE5000];
     char transactiondate[TRANSACTIONDATE5000];
     char processingdate[PROCESSINGDATE5000];
     char merchantname[MERCHANTNAME5000];
     char merchantcity[MERCHANTCITY5000];
     char merchantstateprovince[MERCHANTSTATEPROVINCE5000];
     char merchantcountry[MERCHANTCOUNTRY5000];
     char merchantcategorycode[MERCHANTCATEGORYCODE5000];
     char amountinoriginalcurrency[AMOUNTINORIGINALCURRENCY5000];
     char originalcurrencycode[ORIGINALCURRENCYCODE5000];
     char currconvdatejulian[CURRCONVDATEJULIAN5000];
     char postedcurrencycode[POSTEDCURRENCYCODE5000];
     char conversionrate[CONVERSIONRATE5000];
     char conversionexponent[CONVERSIONEXPONENT5000];
     char acquiringica[ACQUIRINGICA5000];
     char customercode[CUSTOMERCODE5000];
     char salestaxamount[SALESTAXAMOUNT5000];
     char reservedforinternaluse4[RESERVEDFORINTERNALUSE45000];
     char reservedforinternaluse5[RESERVEDFORINTERNALUSE55000];
     char freightamount[FREIGHTAMOUNT5000];
     char destinationpostalcode[DESTINATIONPOSTALCODE5000];
     char merchanttype[MERCHANTTYPE5000];
     char merchantlocationpostalcode[MERCHANTLOCATIONPOSTALCODE5000];
     char dutyamount[DUTYAMOUNT5000];
     char merchantfederaltaxid[MERCHANTFEDERALTAXID5000];
     char merchantstateprovincecode[MERCHANTSTATEPROVINCECODE5000];
     char shipfrompostalcode[SHIPFROMPOSTALCODE5000];
     char alternatetaxamount[ALTERNATETAXAMOUNT5000];
     char destinationcountrycode[DESTINATIONCOUNTRYCODE5000];
     char merchantreferencenumber[MERCHANTREFERENCENUMBER5000];
     char alternatetaxindicator[ALTERNATETAXINDICATOR5000];
     char alternatetaxidentifier[ALTERNATETAXIDENTIFIER5000];
     char salestaxcollectedind_pos[SALESTAXCOLLECTEDIND_POS5000];
     char addendumdetailindicator[ADDENDUMDETAILINDICATOR5000];
     char merchantid[MERCHANTID5000];
     char banknetreferencenumber[ BANKNETREFERENCENUMBER5000 ];	/*Nuevo campo insertado (51), IERM Sept. 17, 2004*/
     char approvalcode[ APPROVALCODE5000 ];				/*Nuevo campo insertado (52), IERM Sept. 17, 2004*/
     char adjustmentreasoncode[ADJUSTMENTREASONCODE5000];
     char adjustmentdescription[ADJUSTMENTDESCRIPTION5000];
     char maintenanceactioncode[MAINTENANCEACTIONCODE5000];
     char inputfilerecordnumber[INPUTFILERECORDNUMBER5000];
     char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE5000];
	} c;
} b5000;
vali5000(cadena5000, Arreglo5000, reg5000)
char cadena5000[];
char *Arreglo5000[80];
int reg5000;
{  
  char *reporte;
  int largo,i;
  char leye[100];
 
  strcpy(b5000.cadena,cadena5000);
      largo = strlen(b5000.cadena);
      if (largo!=LONGCADENA5000)
      {
        printf("La lectura del registro 5000 es incorrecta (%d)\n",largo);
      }
      largo = (
      strlen(strncpy(recordidentifier5000, b5000.c.recordidentifier, RECORDIDENTIFIER5000)) +
      strlen(strncpy(issuerica5000, b5000.c.issuerica, ISSUERICA5000)) +
      strlen(strncpy(issuernumberica5000, b5000.c.issuernumberica, ISSUERNUMBERICA5000)) +
      strlen(strncpy(corporationnumber5000, b5000.c.corporationnumber, CORPORATIONNUMBER5000)) +
      strlen(strncpy(addendumtype5000, b5000.c.addendumtype, ADDENDUMTYPE5000)) +
      strlen(strncpy(reservedforinternaluse15000, b5000.c.reservedforinternaluse1, RESERVEDFORINTERNALUSE15000)) +
      strlen(strncpy(reservedforinternaluse25000, b5000.c.reservedforinternaluse2, RESERVEDFORINTERNALUSE25000)) +
      strlen(strncpy(merchantacttranoriginind5000, b5000.c.merchantacttranoriginind, MERCHANTACTTRANORIGININD5000)) +
      strlen(strncpy(accountnumber5000, b5000.c.accountnumber, ACCOUNTNUMBER5000)) +
      strlen(strncpy(reservedforinternaluse35000, b5000.c.reservedforinternaluse3, RESERVEDFORINTERNALUSE35000)) +
      strlen(strncpy(acquirersorissuersrefnum5000, b5000.c.acquirersorissuersrefnum, ACQUIRERSORISSUERSREFNUM5000)) +
      strlen(strncpy(recordtype5000, b5000.c.recordtype, RECORDTYPE5000)) +
      strlen(strncpy(transactiontype5000, b5000.c.transactiontype, TRANSACTIONTYPE5000)) +
      strlen(strncpy(debitcreditindicator5000, b5000.c.debitcreditindicator, DEBITCREDITINDICATOR5000)) +
      strlen(strncpy(transactionamount5000, b5000.c.transactionamount, TRANSACTIONAMOUNT5000)) +
      strlen(strncpy(postingdate5000, b5000.c.postingdate, POSTINGDATE5000)) +
      strlen(strncpy(transactiondate5000, b5000.c.transactiondate, TRANSACTIONDATE5000)) +
      strlen(strncpy(processingdate5000, b5000.c.processingdate, PROCESSINGDATE5000)) +
      strlen(strncpy(merchantname5000, b5000.c.merchantname, MERCHANTNAME5000)) +
      strlen(strncpy(merchantcity5000, b5000.c.merchantcity, MERCHANTCITY5000)) +
      strlen(strncpy(merchantstateprovince5000, b5000.c.merchantstateprovince, MERCHANTSTATEPROVINCE5000)) +
      strlen(strncpy(merchantcountry5000, b5000.c.merchantcountry, MERCHANTCOUNTRY5000)) +
      strlen(strncpy(merchantcategorycode5000, b5000.c.merchantcategorycode, MERCHANTCATEGORYCODE5000)) +
      strlen(strncpy(amountinoriginalcurrency5000, b5000.c.amountinoriginalcurrency, AMOUNTINORIGINALCURRENCY5000)) +
      strlen(strncpy(originalcurrencycode5000, b5000.c.originalcurrencycode, ORIGINALCURRENCYCODE5000)) +
      strlen(strncpy(currconvdatejulian5000, b5000.c.currconvdatejulian, CURRCONVDATEJULIAN5000)) +
      strlen(strncpy(postedcurrencycode5000, b5000.c.postedcurrencycode, POSTEDCURRENCYCODE5000)) +
      strlen(strncpy(conversionrate5000, b5000.c.conversionrate, CONVERSIONRATE5000)) +
      strlen(strncpy(conversionexponent5000, b5000.c.conversionexponent, CONVERSIONEXPONENT5000)) +
      strlen(strncpy(acquiringica5000, b5000.c.acquiringica, ACQUIRINGICA5000)) +
      strlen(strncpy(customercode5000, b5000.c.customercode, CUSTOMERCODE5000)) +
      strlen(strncpy(salestaxamount5000, b5000.c.salestaxamount, SALESTAXAMOUNT5000)) +
      strlen(strncpy(reservedforinternaluse45000, b5000.c.reservedforinternaluse4, RESERVEDFORINTERNALUSE45000)) +
      strlen(strncpy(reservedforinternaluse55000, b5000.c.reservedforinternaluse5, RESERVEDFORINTERNALUSE55000)) +
      strlen(strncpy(freightamount5000, b5000.c.freightamount, FREIGHTAMOUNT5000)) +
      strlen(strncpy(destinationpostalcode5000, b5000.c.destinationpostalcode, DESTINATIONPOSTALCODE5000)) +
      strlen(strncpy(merchanttype5000, b5000.c.merchanttype, MERCHANTTYPE5000)) +
      strlen(strncpy(merchantlocationpostalcode5000, b5000.c.merchantlocationpostalcode, MERCHANTLOCATIONPOSTALCODE5000)) +
      strlen(strncpy(dutyamount5000, b5000.c.dutyamount, DUTYAMOUNT5000)) +
      strlen(strncpy(merchantfederaltaxid5000, b5000.c.merchantfederaltaxid, MERCHANTFEDERALTAXID5000)) +
      strlen(strncpy(merchantstateprovincecode5000, b5000.c.merchantstateprovincecode, MERCHANTSTATEPROVINCECODE5000)) +
      strlen(strncpy(shipfrompostalcode5000, b5000.c.shipfrompostalcode, SHIPFROMPOSTALCODE5000)) +
      strlen(strncpy(alternatetaxamount5000, b5000.c.alternatetaxamount, ALTERNATETAXAMOUNT5000)) +
      strlen(strncpy(destinationcountrycode5000, b5000.c.destinationcountrycode, DESTINATIONCOUNTRYCODE5000)) +
      strlen(strncpy(merchantreferencenumber5000, b5000.c.merchantreferencenumber, MERCHANTREFERENCENUMBER5000)) +
      strlen(strncpy(alternatetaxindicator5000, b5000.c.alternatetaxindicator, ALTERNATETAXINDICATOR5000)) +
      strlen(strncpy(alternatetaxidentifier5000, b5000.c.alternatetaxidentifier, ALTERNATETAXIDENTIFIER5000)) +
      strlen(strncpy(salestaxcollectedind_pos5000, b5000.c.salestaxcollectedind_pos, SALESTAXCOLLECTEDIND_POS5000)) +
      strlen(strncpy(addendumdetailindicator5000, b5000.c.addendumdetailindicator, ADDENDUMDETAILINDICATOR5000)) +
      strlen(strncpy(merchantid5000, b5000.c.merchantid, MERCHANTID5000)) +
      strlen(strncpy(banknetreferencenumber5000, b5000.c.banknetreferencenumber, BANKNETREFERENCENUMBER5000 )) + /*IERM*/
      strlen(strncpy(approvalcode5000, b5000.c.approvalcode, APPROVALCODE5000 )) + /*IERM*/
      strlen(strncpy(adjustmentreasoncode5000, b5000.c.adjustmentreasoncode, ADJUSTMENTREASONCODE5000)) +
      strlen(strncpy(adjustmentdescription5000, b5000.c.adjustmentdescription, ADJUSTMENTDESCRIPTION5000)) +
      strlen(strncpy(maintenanceactioncode5000, b5000.c.maintenanceactioncode, MAINTENANCEACTIONCODE5000)) +
      strlen(strncpy(inputfilerecordnumber5000, b5000.c.inputfilerecordnumber, INPUTFILERECORDNUMBER5000)) +
      strlen(strncpy(outgoingincomingerrorcode5000, b5000.c.outgoingincomingerrorcode, OUTGOINGINCOMINGERRORCODE5000)) );

      if ((largo - 167)!= LONGCADENA5000)
      {
        printf("Error en longitud del registro 5000 (%d)%d\n\n",largo, LONGCADENA5000+1);
      }
      /* El registro corresponde a un registro tipo 5000
      y tanto la longiud de lo leido como la sumatoria de la longitud
      de los campos es la adecuada   */
      /* y ahora a checar cada uno de los campos      */
      /*se barre el arreglo de los campos y se asignan valores*/
      for (i=0; i<reg5000; i++)
      {
        strcpy(r5000.registro,Arreglo5000[i]);
        strncpy(ftoNumCampo,r5000.a.ftonumcam,4); 
        strncpy(ftoNomCampo,r5000.a.ftonomcam,35);
        strncpy(ftoLongitud,r5000.a.ftolong,4);   
        strncpy(ftoTipoDato,r5000.a.ftotipodat,1);
        strncpy(ftoFill,r5000.a.ftofiller,1);     
        strncpy(ftoJustificado,r5000.a.ftojust,1);
        strncpy(ftoFormato,r5000.a.ftoforma,25);  
                
        switch(atoi(ftoNumCampo))                                      
        {
          case 1:
            valFormatogral (reporte, recordidentifier5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            /* Ejemplo anterior : valFormatogral (reporte, recordidentifier, ftoNomCampo, inputfilerecordnumber, ftoTipoDato, strcat(ftoFill,ftoJustificado));*/
            break;           
          case 2:
            valFormatogral (reporte, issuerica5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 3:
            valFormatogral (reporte, issuernumberica5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 4:
            valFormatogral (reporte, corporationnumber5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 5:
            valFormatogral (reporte, addendumtype5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 6:
            valFormatogral (reporte, reservedforinternaluse15000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 7:
            valFormatogral (reporte, reservedforinternaluse25000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 8:
            valFormatogral (reporte, merchantacttranoriginind5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 9:
            valFormatogral (reporte, accountnumber5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 10:
            valFormatogral (reporte, reservedforinternaluse35000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 11:
            valFormatogral (reporte, acquirersorissuersrefnum5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 12:
            valFormatogral (reporte, recordtype5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 13:
            valFormatogral (reporte, transactiontype5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 14:
            valFormatogral (reporte, debitcreditindicator5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 15:
            valFormatogral (reporte, transactionamount5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 16:
            valFormatogral (reporte, postingdate5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 17:
            valFormatogral (reporte, transactiondate5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 18:
            valFormatogral (reporte, processingdate5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 19:
            valFormatogral (reporte, merchantname5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 20:
            valFormatogral (reporte, merchantcity5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 21:
            valFormatogral (reporte, merchantstateprovince5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 22:
            valFormatogral (reporte, merchantcountry5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 23:
            valFormatogral (reporte, merchantcategorycode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 24:
            valFormatogral (reporte, amountinoriginalcurrency5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;           
          case 25:
            valFormatogral (reporte, originalcurrencycode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 26:
            valFormatogral (reporte, currconvdatejulian5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 27:
            valFormatogral (reporte, postedcurrencycode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 28:
            valFormatogral (reporte, conversionrate5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 29:
            valFormatogral (reporte, conversionexponent5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 30:
            valFormatogral (reporte, acquiringica5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 31:
            valFormatogral (reporte, customercode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 32:
            valFormatogral (reporte, salestaxamount5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 33:
            valFormatogral (reporte, reservedforinternaluse45000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 34:
            valFormatogral (reporte, reservedforinternaluse55000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 35:
            valFormatogral (reporte, freightamount5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 36:
            valFormatogral (reporte, destinationpostalcode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 37:
            valFormatogral (reporte, merchanttype5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 38:
            valFormatogral (reporte, merchantlocationpostalcode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 39:
            valFormatogral (reporte, dutyamount5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 40:
            valFormatogral (reporte, merchantfederaltaxid5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 41:
            valFormatogral (reporte, merchantstateprovincecode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 42:
            valFormatogral (reporte, shipfrompostalcode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 43:
            valFormatogral (reporte, alternatetaxamount5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 44:
            valFormatogral (reporte, destinationcountrycode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 45:
            valFormatogral (reporte, merchantreferencenumber5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 46:
            valFormatogral (reporte, alternatetaxindicator5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 47:
            valFormatogral (reporte, alternatetaxidentifier5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 48:
            valFormatogral (reporte, salestaxcollectedind_pos5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 49:
            valFormatogral (reporte, addendumdetailindicator5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 50:
            valFormatogral (reporte, merchantid5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
	case 51:
            valFormatogral (reporte,banknetreferencenumber5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);		/*IERM Sept 17, 2004*/
	    break;
	case 52:
            valFormatogral (reporte, approvalcode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);			/*IERM Sept. 17, 2004*/
	  break;
          case 53:
            valFormatogral (reporte, adjustmentreasoncode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 54:
            valFormatogral (reporte, adjustmentdescription5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 55:
            valFormatogral (reporte, maintenanceactioncode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 56:
            valFormatogral (reporte, inputfilerecordnumber5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 57:
            valFormatogral (reporte, outgoingincomingerrorcode5000, ftoNomCampo, inputfilerecordnumber5000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
        } /* Case numero de campo */
        ftoNumCampo[0]=NULL;          
        ftoNomCampo[0]=NULL;          
        ftoLongitud[0]=NULL;          
        ftoTipoDato[0]=NULL;          
        ftoFill[0]=NULL;              
        ftoJustificado[0]=NULL;       
        ftoFormato[0]=NULL;           
      } /*For */

      /** VALIDACIONES ESPECIFICAS DEL REGISTRO **/
      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN PUROS BLANCOS **/
      blancos(reporte,reservedforinternaluse15000,"reservedforinternaluse1", inputfilerecordnumber5000);
      blancos(reporte,reservedforinternaluse25000,"reservedforinternaluse2", inputfilerecordnumber5000);
      blancos(reporte,reservedforinternaluse35000,"reservedforinternaluse3", inputfilerecordnumber5000);
      blancos(reporte,merchantcategorycode5000,"merchantcategorycode", inputfilerecordnumber5000);
      blancos(reporte,customercode5000,"customercode", inputfilerecordnumber5000);
      blancos(reporte,reservedforinternaluse45000,"reservedforinternaluse4", inputfilerecordnumber5000);
      blancos(reporte,reservedforinternaluse55000,"reservedforinternaluse5", inputfilerecordnumber5000);
      blancos(reporte,destinationpostalcode5000,"destinationpostalcode", inputfilerecordnumber5000);
      blancos(reporte,merchanttype5000,"merchanttype", inputfilerecordnumber5000);
      blancos(reporte,merchantlocationpostalcode5000,"merchantlocationpostalcode", inputfilerecordnumber5000);
      blancos(reporte,merchantfederaltaxid5000,"merchantfederaltaxid", inputfilerecordnumber5000);
      blancos(reporte,shipfrompostalcode5000,"shipfrompostalcode", inputfilerecordnumber5000);
      blancos(reporte,merchantreferencenumber5000,"merchantreferencenumber", inputfilerecordnumber5000);
      blancos(reporte,alternatetaxidentifier5000,"alternatetaxidentifier", inputfilerecordnumber5000);
      blancos(reporte,outgoingincomingerrorcode5000,"outgoingincomingerrorcode", inputfilerecordnumber5000);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN NUMEROS O ESPACIOS o GUIONES **/
      numespgui(reporte,corporationnumber5000,"corporationnumber", inputfilerecordnumber5000);
      numespgui(reporte,accountnumber5000,"accountnumber", inputfilerecordnumber5000);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN PUROS CEROS  **/
      ceros(reporte,alternatetaxamount5000,"alternatetaxamount", inputfilerecordnumber5000);
     
      if (!(addendumtype5000[0]=='0' && addendumtype5000[1]==SP  && addendumtype5000[2]==SP))
      {
        printf("El campo addendumtype es diferente de '0  ' =%s=(%s)\n", addendumtype5000, inputfilerecordnumber5000);
      }

      if (merchantacttranoriginind5000[0]!='A' && merchantacttranoriginind5000[0]!='M')
      {
        printf("El campo merchantacttranoriginind solo acepta 'A' o 'M' =%s=(%s)\n", merchantacttranoriginind5000, inputfilerecordnumber5000);
      }

      if (recordtype5000[0]!='R' && recordtype5000[0]!= SP)
      {
        printf("El campo recordtype solo acepta 'R' o blanco =%s=(%s)\n", recordtype5000, inputfilerecordnumber5000);
      }

      if (debitcreditindicator5000[0]!='C' && debitcreditindicator5000[0]!='D')
      {
        printf("El campo debitcreditindicator solo acepta 'C' o 'D' =%s=(%s)\n", debitcreditindicator5000, inputfilerecordnumber5000);
      }

      if (conversionexponent5000[0]!='2')
      {
        printf("El campo conversionexponent solo acepta '2' =%s=(%s)\n", conversionexponent5000, inputfilerecordnumber5000);
      }

      if (!(postedcurrencycode5000[0]=='4' && postedcurrencycode5000[1]=='8' && postedcurrencycode5000[2]=='4'))
      {
        printf("El campo postedcurrencycode solo acepta '484' =%s=(%s)\n", postedcurrencycode5000, inputfilerecordnumber5000);
      }

      if (alternatetaxindicator5000[0]!='N')
      {
        printf("El campo alternatetaxindicator solo acepta 'N' =%s=(%s)\n", alternatetaxindicator5000, inputfilerecordnumber5000);
      }

      if (!(destinationcountrycode5000[0]=='U' && destinationcountrycode5000[1]=='N' && destinationcountrycode5000[2]=='K'))
      {
        printf("El campo destinationcountrycode solo acepta 'UNK' =%s=(%s)\n", destinationcountrycode5000, inputfilerecordnumber5000);
      }

      if (salestaxcollectedind_pos5000[0]!='N' && salestaxcollectedind_pos5000[0]!='Y' && salestaxcollectedind_pos5000[0]!= SP)
      {
        printf("El campo salestaxcollectedind_pos solo acepta 'N','Y' o espacio =%s=(%s)\n", salestaxcollectedind_pos5000, inputfilerecordnumber5000);
      }

      if (addendumdetailindicator5000[0]!='0')
      {
        printf("El campo addendumdetailindicator solo acepta '0' =%s=(%s)\n", addendumdetailindicator5000, inputfilerecordnumber5000);
      }

      if (maintenanceactioncode5000[0]!='A' && maintenanceactioncode5000[0]!='U' && maintenanceactioncode5000[0]!='D')
      {
        printf("El campo maintenanceactioncode solo acepta 'A' o 'U' o 'D' =%s=(%s)\n", maintenanceactioncode5000, inputfilerecordnumber5000);
      }

      if(merchantcountry5000[0]=='M' && merchantcountry5000[1]=='E' && merchantcountry5000[2]=='X') 
        if(!(originalcurrencycode5000[0]=='4' && originalcurrencycode5000[1]=='8' && originalcurrencycode5000[2]=='4'))
        {
          printf("El campo originalcurrencycode debe ser '484' =%s=(%s)\n", originalcurrencycode5000, inputfilerecordnumber5000);
        }
        else
          ;
      else
      {
        if(merchantcountry5000[0]=='U' && merchantcountry5000[1]=='S' && merchantcountry5000[2]=='A') 
          if(!(originalcurrencycode5000[0]=='8' && originalcurrencycode5000[1]=='4' && originalcurrencycode5000[2]=='0'))
          {
            printf("El campo originalcurrencycode debe ser '840' =%s=(%s)\n", originalcurrencycode5000, inputfilerecordnumber5000);
          }
          else
            ; 
        else
        {
          if(merchantacttranoriginind5000[0]=='M')
          {
            printf("En merchantcountry solo debe haber 'MEX' o 'USA' =%s= (%s)\n",merchantcountry5000, inputfilerecordnumber5000); 
          }
        }
      }

      if(merchantacttranoriginind5000[0]=='A')
      {
        if(transactiontype5000[0]!='3')
        {
          printf("El campo transactiontype debe tener un '3' =%s=(%s)\n", transactiontype5000, inputfilerecordnumber5000);
        }
        blancos(reporte,merchantname5000,"merchantname", inputfilerecordnumber5000);
        blancos(reporte,merchantcity5000,"merchantcity", inputfilerecordnumber5000);
        blancos(reporte,merchantstateprovince5000,"merchantstateprovince", inputfilerecordnumber5000);
        blancos(reporte,merchantcountry5000,"merchantcountry", inputfilerecordnumber5000);
        blancos(reporte,currconvdatejulian5000,"currconvdatejulian", inputfilerecordnumber5000);
        /* blancos(reporte,acquiringica,"acquiringica", inputfilerecordnumber);
        blancos(reporte,salestaxamount,"salestaxamount", inputfilerecordnumber);
        blancos(reporte,freightamount,"freightamount", inputfilerecordnumber);
        blancos(reporte,dutyamount,"dutyamount", inputfilerecordnumber);
        blancos(reporte,merchantstateprovincecode,"merchantstateprovincecode", inputfilerecordnumber); */   /* se comento por solicitud de Yuria */

        if(salestaxcollectedind_pos5000[0]!= SP && salestaxcollectedind_pos5000[0]!='N')
        {
          printf("El campo salestaxcollectedind_pos solo acepta 'N' o espacio =%s=(%s)\n", salestaxcollectedind_pos5000, inputfilerecordnumber5000);
        }
        numespgui(reporte,merchantid5000,"merchantid", inputfilerecordnumber5000);
        numespgui(reporte,banknetreferencenumber5000,"banknetreferencenumber", inputfilerecordnumber5000);
        numespgui(reporte,approvalcode5000,"approvalcode", inputfilerecordnumber5000);
        numespgui(reporte,adjustmentreasoncode5000,"adjustmentreasoncode", inputfilerecordnumber5000);
      }/* merchchantacttiranoriginind='A'  */
      else /*merchchantacttiranoriginind[0]=='M')     */
      {
        if(transactiontype5000[0]<'5' && transactiontype5000[0]>'7')
        {
          printf("El campo transactiontype solo acepta '5' o '6' o '7' =%s=(%s)\n", transactiontype5000,inputfilerecordnumber5000);
        }
        vacia(reporte,merchantname5000,"merchantname", inputfilerecordnumber5000);
        vacia(reporte,merchantcity5000,"merchantcity", inputfilerecordnumber5000);
        if (merchantcountry5000[0]=='M' && merchantcountry5000[1]=='E' && merchantcountry5000[2]=='X') 
          if(!(merchantstateprovince5000[0]=='U' && merchantstateprovince5000[1]=='N' && merchantstateprovince5000[2]=='K'))
          {
            printf("El campo merchantstateprovince debe tener 'UNK' =%s=(%s)\n", merchantstateprovince5000, inputfilerecordnumber5000);
          }
        /*else
            ;
        
        else
        {
         vacia(reporte,merchantstateprovince,"merchantstateprovince", inputfilerecordnumber);
        } */
        if (!((merchantcountry5000[0]=='M' && merchantcountry5000[1]=='E' && merchantcountry5000[2]=='X') || (merchantcountry5000[0]=='U' && merchantcountry5000[1]=='S' && merchantcountry5000[2]=='A')))
        {
          printf("El campo merchantcountry solo acepta 'MEX' o 'USA' =%s=(%s)\n", merchantcountry5000, inputfilerecordnumber5000);
        }
        if(merchantcountry5000[0]=='M' && merchantcountry5000[1]=='E' && merchantcountry5000[2]=='X')
          /* if (!(acquiringica[0]=='1' && acquiringica[1]=='0' && acquiringica[2]=='3' && acquiringica[3]=='5'))
          {
            printf("El campo acquiringica debe ser '1035' =%s=(%s)\n", acquiringica, inputfilerecordnumber);
          }
          else
            ; */
        {
           ceros(reporte,acquiringica5000,"acquiringica", inputfilerecordnumber5000);
        } 
        else
        {
          vacia(reporte,acquiringica5000,"acquiringica", inputfilerecordnumber5000);
        }
        if (merchantcountry5000[0]=='M' && merchantcountry5000[1]=='E' && merchantcountry5000[2]=='X')
          if(!(merchantstateprovincecode5000[0]=='U' && merchantstateprovincecode5000[1]=='N' && merchantstateprovincecode5000[2]=='K'))
          {  
            printf("El campo merchantstateprovincecode debe ser 'UNK' =%s=(%s)\n", merchantstateprovincecode5000, inputfilerecordnumber5000);
          }
          else
            ;
        else
        {
          vacia(reporte,merchantstateprovincecode5000, "merchantstateprovincecode", inputfilerecordnumber5000);
        }
        if(salestaxcollectedind_pos5000[0]!='N')
        {
          printf("El campo salestaxcollectedind_pos debe ser 'N' =%s=(%s)\n", salestaxcollectedind_pos5000, inputfilerecordnumber5000);
        }
        blancos(reporte,adjustmentreasoncode5000,"adjustmentreasoncode", inputfilerecordnumber5000);
        blancos(reporte,adjustmentdescription5000,"adjustmentdescription", inputfilerecordnumber5000);
      }/* merchchantacttiranoriginind='M'   */
      /** FIN DE LAS VALIDACIONES ESPECIFICAS **/  
} /* fin main */


