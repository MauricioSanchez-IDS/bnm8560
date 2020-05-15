#if USE_SCCSID
static char Sccsid[] = {"@(#) vali4000opt.c 10/01/2001"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include "sybdbex.h"
#include "campos.h" 			/*Para prueba, IERM*/
#include "simbolos.h"
/*#include "camFTO.h"*/
/*#include "ArchComunes.h"*/

#define LONGCADENA4000    613 /*Ampliado de 607 a 613*, IERM Sept. 17, 2004*/
#define LONGREGISTRO4000 71

union                                                                 
{                                                                     
char registro [LONGREGISTRO4000 + 2]; /* con retorno de carro y nulo*/
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
} r4000;                                                                  

union
{
char cadena [LONGCADENA4000 + 2]; /* con retorno de carro y nulo*/
struct
	{
      char recordidentifier[RECORDIDENTIFIER4000];
      char issuerica[ISSUERICA4000];
      char issuernumberica[ISSUERNUMBERICA4000];
      char corporationnumber[CORPORATIONNUMBER4000];
      char reservedforinternaluse1[RESERVEDFORINTERNALUSE14000];
      char reservedforinternaluse2[RESERVEDFORINTERNALUSE24000];
      char reservedforinternaluse3[RESERVEDFORINTERNALUSE34000];
      char corporationnameline1[CORPORATIONNAMELINE14000];
      char corporationnameline2[CORPORATIONNAMELINE24000];
      char addressline1[ADDRESSLINE14000];
      char addressline2[ADDRESSLINE24000];
      char city[CITY4000];
      char stateprovince[STATEPROVINCE4000];
      char country[COUNTRY4000];
      char postalcode[POSTALCODE4000];
      char currencycode[CURRENCYCODE4000];
      char contactperson[CONTACTPERSON4000];
      char phonenumber[PHONENUMBER4000];
      char faxnumber[FAXNUMBER4000];
      char emailaddress[EMAILADDRESS4000];
      char budgetlimit[BUDGETLIMIT4000];
      char cycledateindicator[CYCLEDATEINDICATOR4000];
      char totalaccounts[TOTALACCOUNTS4000];
      char accountspastdue[ACCOUNTSPASTDUE4000];
      char accountswithdispute[ACCOUNTSWITHDISPUTE4000];
      char numberofcards[NUMBEROFCARDS4000];
      char chargeoffsign[CHARGEOFFSIGN4000];
      char chargeoffamount[CHARGEOFFAMOUNT4000];
      char pastdueamountsign[PASTDUEAMOUNTSIGN4000]; 
      char pastdueamount[PASTDUEAMOUNT4000];
      char disputeamountsign[DISPUTEAMOUNTSIGN4000];
      char disputeamount[DISPUTEAMOUNT4000];
      char creditlimitsign[CREDITLIMITSIGN4000];
      char creditlimit[CREDITLIMIT4000];
      char paymentduesign[PAYMENTDUESIGN4000];
      char paymentdue[PAYMENTDUE4000];
      char outstandingbalancesign[OUTSTANDINGBALANCESIGN4000];
      char outstandingbalance[OUTSTANDINGBALANCE4000];
      char numberofdebits[NUMBEROFDEBITS4000];
      char numberofcredits[NUMBEROFCREDITS4000];
      char amountofdebits[AMOUNTOFDEBITS4000];
      char amountofcredits[AMOUNTOFCREDITS4000];
      char numberaccountsoverlimit[NUMBERACCOUNTSOVERLIMIT4000];
      char portfoliodate[PORTFOLIODATE4000];
      char addressmaintenanceactioncode[ADDRESSMAINTENANCEACTIONCODE4000];
      char inputfilerecordnumber[INPUTFILERECORDNUMBER4000];
      char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE4000];
	} c;
} b4000;

vali4000(cadena4000,Arreglo4000, reg4000)
char cadena4000[];
char *Arreglo4000[80];
int reg4000;
{
  char *reporte;
  int largo,i;
  char leye[100];

  strcpy(b4000.cadena,cadena4000); 
  largo = strlen(b4000.cadena);
  if (largo!=LONGCADENA4000)
    {
     printf("La lectura del registro 4000 es incorrecta (%d)\n",largo);
    }
     largo = (
     strlen(strncpy(recordidentifier4000, b4000.c.recordidentifier, RECORDIDENTIFIER4000)) +
     strlen(strncpy(issuerica4000, b4000.c.issuerica, ISSUERICA4000)) +
     strlen(strncpy(issuernumberica4000, b4000.c.issuernumberica, ISSUERNUMBERICA4000)) +
     strlen(strncpy(corporationnumber4000, b4000.c.corporationnumber, CORPORATIONNUMBER4000)) +
     strlen(strncpy(reservedforinternaluse14000, b4000.c.reservedforinternaluse1, RESERVEDFORINTERNALUSE14000)) +
      strlen(strncpy(reservedforinternaluse24000, b4000.c.reservedforinternaluse2, RESERVEDFORINTERNALUSE24000)) +
      strlen(strncpy(reservedforinternaluse34000, b4000.c.reservedforinternaluse3, RESERVEDFORINTERNALUSE34000)) +
      strlen(strncpy(corporationnameline14000, b4000.c.corporationnameline1, CORPORATIONNAMELINE14000)) +
      strlen(strncpy(corporationnameline24000, b4000.c.corporationnameline2, CORPORATIONNAMELINE24000)) +
      strlen(strncpy(addressline14000, b4000.c.addressline1, ADDRESSLINE14000)) +
      strlen(strncpy(addressline24000, b4000.c.addressline2, ADDRESSLINE24000)) +
      strlen(strncpy(city4000, b4000.c.city, CITY4000)) +
      strlen(strncpy(stateprovince4000, b4000.c.stateprovince, STATEPROVINCE4000)) +
      strlen(strncpy(country4000, b4000.c.country, COUNTRY4000)) +
      strlen(strncpy(postalcode4000, b4000.c.postalcode, POSTALCODE4000)) +
      strlen(strncpy(currencycode4000, b4000.c.currencycode, CURRENCYCODE4000)) +
      strlen(strncpy(contactperson4000, b4000.c.contactperson, CONTACTPERSON4000)) +
      strlen(strncpy(phonenumber4000, b4000.c.phonenumber, PHONENUMBER4000)) +
      strlen(strncpy(faxnumber4000, b4000.c.faxnumber, FAXNUMBER4000)) +
      strlen(strncpy(emailaddress4000, b4000.c.emailaddress, EMAILADDRESS4000)) +
      strlen(strncpy(budgetlimit4000, b4000.c.budgetlimit, BUDGETLIMIT4000)) +
      strlen(strncpy(cycledateindicator4000, b4000.c.cycledateindicator, CYCLEDATEINDICATOR4000)) +
      strlen(strncpy(totalaccounts4000, b4000.c.totalaccounts, TOTALACCOUNTS4000)) +
      strlen(strncpy(accountspastdue4000, b4000.c.accountspastdue, ACCOUNTSPASTDUE4000)) +
      strlen(strncpy(accountswithdispute4000, b4000.c.accountswithdispute, ACCOUNTSWITHDISPUTE4000)) +
      strlen(strncpy(numberofcards4000, b4000.c.numberofcards, NUMBEROFCARDS4000)) +
      strlen(strncpy(chargeoffsign4000, b4000.c.chargeoffsign, CHARGEOFFSIGN4000)) +
      strlen(strncpy(chargeoffamount4000, b4000.c.chargeoffamount, CHARGEOFFAMOUNT4000)) +
      strlen(strncpy(pastdueamountsign4000, b4000.c.pastdueamountsign, PASTDUEAMOUNTSIGN4000)) +
      strlen(strncpy(pastdueamount4000, b4000.c.pastdueamount, PASTDUEAMOUNT4000)) +
      strlen(strncpy(disputeamountsign4000, b4000.c.disputeamountsign, DISPUTEAMOUNTSIGN4000)) +
      strlen(strncpy(disputeamount4000, b4000.c.disputeamount, DISPUTEAMOUNT4000)) +
      strlen(strncpy(creditlimitsign4000, b4000.c.creditlimitsign, CREDITLIMITSIGN4000)) +
      strlen(strncpy(creditlimit4000, b4000.c.creditlimit, CREDITLIMIT4000)) +
      strlen(strncpy(paymentduesign4000, b4000.c.paymentduesign, PAYMENTDUESIGN4000)) +
      strlen(strncpy(paymentdue4000, b4000.c.paymentdue, PAYMENTDUE4000)) +
      strlen(strncpy(outstandingbalancesign4000, b4000.c.outstandingbalancesign, OUTSTANDINGBALANCESIGN4000)) +
      strlen(strncpy(outstandingbalance4000, b4000.c.outstandingbalance, OUTSTANDINGBALANCE4000)) +
      strlen(strncpy(numberofdebits4000, b4000.c.numberofdebits, NUMBEROFDEBITS4000)) +
      strlen(strncpy(numberofcredits4000, b4000.c.numberofcredits, NUMBEROFCREDITS4000)) +
      strlen(strncpy(amountofdebits4000, b4000.c.amountofdebits, AMOUNTOFDEBITS4000)) +
      strlen(strncpy(amountofcredits4000, b4000.c.amountofcredits, AMOUNTOFCREDITS4000)) +
      strlen(strncpy(numberaccountsoverlimit4000, b4000.c.numberaccountsoverlimit, NUMBERACCOUNTSOVERLIMIT4000)) +
      strlen(strncpy(portfoliodate4000, b4000.c.portfoliodate, PORTFOLIODATE4000)) +
      strlen(strncpy(addressmaintenanceactioncode4000, b4000.c.addressmaintenanceactioncode, ADDRESSMAINTENANCEACTIONCODE4000)) +
      strlen(strncpy(inputfilerecordnumber4000, b4000.c.inputfilerecordnumber, INPUTFILERECORDNUMBER4000)) +
      strlen(strncpy(outgoingincomingerrorcode4000, b4000.c.outgoingincomingerrorcode, OUTGOINGINCOMINGERRORCODE4000)) );

      if ((largo)!= LONGCADENA4000)
      {
        printf("Error en longitud del registro 4000 (%d)%d\n\n",largo, LONGCADENA4000+1);
      }
      /* El registro corresponde a un registro tipo 4000
      y tanto la longiud de lo leido como la sumatoria de la longitud
      de los campos es la adecuada   */
      /* y ahora a checar cada uno de los campos      */
      /*se barre el arreglo de los campos y se asignan valores*/
      for (i=0; i<reg4000; i++)      
      {
        strcpy(r4000.registro,Arreglo4000[i]);
	strncpy(ftoNumCampo,r4000.a.ftonumcam,4);   
        strncpy(ftoNomCampo,r4000.a.ftonomcam,35);  
        strncpy(ftoLongitud,r4000.a.ftolong,4);     
        strncpy(ftoTipoDato,r4000.a.ftotipodat,1);  
        strncpy(ftoFill,r4000.a.ftofiller,1);       
        strncpy(ftoJustificado,r4000.a.ftojust,1);  
        strncpy(ftoFormato,r4000.a.ftoforma,25);                                            
                                               
        switch(atoi(ftoNumCampo))                
        {
          case 1:
            valFormatogral (reporte, recordidentifier4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            /* Ejemplo anterior :  valFormatogral (reporte, recordidentifier, ftoNomCampo, inputfilerecordnumber, ftoTipoDato, strcat(ftoFill,ftoJustificado)); */
            break;           
          case 2:
            valFormatogral (reporte, issuerica4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 3:
            valFormatogral (reporte, issuernumberica4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 4:
            valFormatogral (reporte, corporationnumber4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 5:
            valFormatogral (reporte, reservedforinternaluse14000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 6:
            valFormatogral (reporte, reservedforinternaluse24000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 7:
            valFormatogral (reporte, reservedforinternaluse34000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 8:
            valFormatogral (reporte, corporationnameline14000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 9:
            valFormatogral (reporte, corporationnameline24000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 10:
            valFormatogral (reporte, addressline14000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 11:
            valFormatogral (reporte, addressline24000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 12:
            valFormatogral (reporte, city4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 13:
            valFormatogral (reporte, stateprovince4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 14:
            valFormatogral (reporte, country4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 15:
            valFormatogral (reporte, postalcode4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 16:
            valFormatogral (reporte, currencycode4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 17:
            valFormatogral (reporte, contactperson4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 18:
            valFormatogral (reporte, phonenumber4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 19:
            valFormatogral (reporte, faxnumber4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 20:
            valFormatogral (reporte, emailaddress4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 21:
            valFormatogral (reporte, budgetlimit4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 22:
            valFormatogral (reporte, cycledateindicator4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 23:
            valFormatogral (reporte, totalaccounts4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;           
          case 24:
            valFormatogral (reporte, accountspastdue4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 25:
            valFormatogral (reporte, accountswithdispute4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 26:
            valFormatogral (reporte, numberofcards4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 27:
            valFormatogral (reporte, chargeoffsign4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 28:
            valFormatogral (reporte, chargeoffamount4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 29:
            valFormatogral (reporte, pastdueamountsign4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 30:
            valFormatogral (reporte, pastdueamount4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 31:
            valFormatogral (reporte, disputeamountsign4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 32:
            valFormatogral (reporte, disputeamount4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 33:
            valFormatogral (reporte, creditlimitsign4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 34:
            valFormatogral (reporte, creditlimit4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 35:
            valFormatogral (reporte, paymentduesign4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 36:
            valFormatogral (reporte, paymentdue4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 37:
            valFormatogral (reporte, outstandingbalancesign4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 38:
            valFormatogral (reporte, outstandingbalance4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 39:
            valFormatogral (reporte, numberofdebits4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 40:
            valFormatogral (reporte, numberofcredits4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 41:
            valFormatogral (reporte, amountofdebits4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 42:
            valFormatogral (reporte, amountofcredits4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 43:
            valFormatogral (reporte, numberaccountsoverlimit4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 44:
            valFormatogral (reporte, portfoliodate4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 45:
            valFormatogral (reporte, addressmaintenanceactioncode4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 46:
            valFormatogral (reporte, inputfilerecordnumber4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 47:
            valFormatogral (reporte, outgoingincomingerrorcode4000, ftoNomCampo, inputfilerecordnumber4000, ftoTipoDato, ftoFill,ftoJustificado);
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

      /**  VALIDACIONES ESPECIFICAS DEL REGISTRO  **/
      /** VALIDA QUE EL CONTENIDO SEAN PUROS BLANCOS **/
      blancos(reporte,reservedforinternaluse14000,"reservedforinternaluse1", inputfilerecordnumber4000);
      blancos(reporte,reservedforinternaluse24000,"reservedforinternaluse2", inputfilerecordnumber4000);
      blancos(reporte,reservedforinternaluse34000,"reservedforinternaluse3", inputfilerecordnumber4000);
      blancos(reporte,outgoingincomingerrorcode4000,"outgoingincomingerrorcode", inputfilerecordnumber4000);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN NUMEROS O ESPACIOS O GUIONES **/
      numespgui(reporte,corporationnumber4000,"corporationnumber", inputfilerecordnumber4000);
      numespgui(reporte,postalcode4000,"postalcode", inputfilerecordnumber4000);
      numespgui(reporte,phonenumber4000,"phonenumber", inputfilerecordnumber4000);
      numespgui(reporte,faxnumber4000,"faxnumber", inputfilerecordnumber4000);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN PUROS CEROS **/
      ceros(reporte,chargeoffamount4000,"chargeoffamount", inputfilerecordnumber4000);

      if (!(country4000[0]=='M' && country4000[1]=='E' && country4000[2]=='X'))
      {
        printf("El campo country solo acepta 'MEX' =%s=(%s)\n", country4000, inputfilerecordnumber4000);
      }
      if (!(currencycode4000[0]=='4' && currencycode4000[1]=='8' && currencycode4000[2]=='4'))
      {
        printf("El campo currencycode solo acepta '484' =%s=(%s)\n", currencycode4000, inputfilerecordnumber4000);
      }
      if (chargeoffsign4000[0]!='C' && chargeoffsign4000[0]!='D')
      {
        printf("El campo chargeoffsign solo acepta 'C' o 'D' =%s=(%s)\n", chargeoffsign4000, inputfilerecordnumber4000);
      }
      if (pastdueamountsign4000[0]!='C' && pastdueamountsign4000[0]!='D')
      {
        printf("El campo pastdueamountsign solo acepta 'C' o 'D' =%s=(%s)\n", pastdueamountsign4000, inputfilerecordnumber4000);
      }
      if (disputeamountsign4000[0]!='C' && disputeamountsign4000[0]!='D')
      {
        printf("El campo disputeamountsign solo acepta 'C' o 'D' =%s=(%s)\n", disputeamountsign4000, inputfilerecordnumber4000);
      }
      if (creditlimitsign4000[0]!='C' && creditlimitsign4000[0]!='D')
      {
        printf("El campo creditlimitsign solo acepta 'C' o 'D' =%s=(%s)\n", creditlimitsign4000, inputfilerecordnumber4000);
      }
      if (paymentduesign4000[0]!='C' && paymentduesign4000[0]!='D')
      {
        printf("El campo paymentduesign solo acepta 'C' o 'D' =%s=(%s)\n", paymentduesign4000, inputfilerecordnumber4000);
      }
       if (outstandingbalancesign4000[0]!='C' && outstandingbalancesign4000[0]!='D')
      {
        printf("El campo outstandingbalancesign solo acepta 'C' o 'D' =%s=(%s)\n", outstandingbalancesign4000, inputfilerecordnumber4000);
      }
      if (addressmaintenanceactioncode4000[0]!='A' && addressmaintenanceactioncode4000[0]!='U' && addressmaintenanceactioncode4000[0]!='D')
      {  
        printf("El campo addressmaintenanceactioncode solo acepta 'A' o 'U' o 'D' =%s=(%s)\n", addressmaintenanceactioncode4000, inputfilerecordnumber4000);
      }
      /**  FIN DE LAS VALIDACIONES ESPECIFICAS  **/
}
/*********************************************************************************************/
