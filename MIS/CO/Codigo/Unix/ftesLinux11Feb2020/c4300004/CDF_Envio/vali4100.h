#if USE_SCCSID
static char Sccsid[] = {"@(#) vali4100opt.c  18/01/2001"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include "sybdbex.h"
#include "simbolos.h"
#include "campos.h"	/*Para prueba, IERM*/

#define LONGCADENA4100    655  /* Ampliado de 649 a 655, IERM Sept. 17, 2004*/
#define LONGREGISTRO4100 71

union                                                                 
{                                                                     
char registro [LONGREGISTRO4100 + 2]; /* con retorno de carro y nulo*/
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
} r4100;                                                                  

union
{
char cadena [LONGCADENA4100 + 2]; /* con retorno de carro y nulo*/
struct
	{
      char recordidentifier[RECORDIDENTIFIER4100];
      char issuerica[ISSUERICA4100];
      char issuernumberica[ISSUERNUMBERICA4100];
      char corporationnumber[CORPORATIONNUMBER4100];
      char reservedforinternaluse1[RESERVEDFORINTERNALUSE14100];
      char reservedforinternaluse2[RESERVEDFORINTERNALUSE24100];
      char reservedforinternaluse3[RESERVEDFORINTERNALUSE34100];
      char organizationpointnumber[ORGANIZATIONPOINTNUMBER4100];
      char freeformattext[FREEFORMATTEXT4100];
      char organizationpointnameline1[ORGANIZATIONPOINTNAMELINE14100];
      char organizationpointnameline2[ORGANIZATIONPOINTNAMELINE24100];
      char addressline1[ADDRESSLINE14100];
      char addressline2[ADDRESSLINE24100];
      char city[CITY4100];
      char stateprovince[STATEPROVINCE4100];
      char country[COUNTRY4100];
      char postalcode[POSTALCODE4100];
      char currencycode[CURRENCYCODE4100];
      char contactperson[CONTACTPERSON4100];
      char phonenumber[PHONENUMBER4100];
      char faxnumber[FAXNUMBER4100];
      char emailaddress[EMAILADDRESS4100];
      char budgetlimit[BUDGETLIMIT4100];
      char totalaccounts[TOTALACCOUNTS4100];
      char accountspastdue[ACCOUNTSPASTDUE4100];
      char accountswithdispute[ACCOUNTSWITHDISPUTE4100];
      char numberofcards[NUMBEROFCARDS4100];
      char chargeoffsign[CHARGEOFFSIGN4100];
      char chargeoffamount[CHARGEOFFAMOUNT4100];
      char pastdueamountsign[PASTDUEAMOUNTSIGN4100];
      char pastdueamount[PASTDUEAMOUNT4100];
      char disputeamountsign[DISPUTEAMOUNTSIGN4100];
      char disputeamount[DISPUTEAMOUNT4100];
      char creditlimitsign[CREDITLIMITSIGN4100];
      char creditlimit[CREDITLIMIT4100];
      char paymentduesign[PAYMENTDUESIGN4100];
      char paymentdue[PAYMENTDUE4100];
      char outstandingbalancesign[OUTSTANDINGBALANCESIGN4100];
      char outstandingbalance[OUTSTANDINGBALANCE4100];
      char numberofdebits[NUMBEROFDEBITS4100];
      char numberofcredits[NUMBEROFCREDITS4100];
      char amountofdebits[AMOUNTOFDEBITS4100];
      char amountofcredits[AMOUNTOFCREDITS4100];
      char numberaccountsoverlimit[NUMBERACCOUNTSOVERLIMIT4100];
      char portfoliodate[PORTFOLIODATE4100];
      char addressmaintenanceactioncode[ADDRESSMAINTENANCEACTIONCODE4100];
      char inputfilerecordnumber[INPUTFILERECORDNUMBER4100];
      char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE4100];
	} c;
} b4100;

vali4100(Arreglo4100, reg4100)
char *Arreglo4100[];
int reg4100;
{
  char *reporte;
  int largo,i;
  char leye[100]; 
      strcpy(b4100.cadena,Arreglo4100[0]);
      largo = strlen(b4100.cadena);
      if (largo!=LONGCADENA4100)
      {
        printf("La lectura del registro 4100 es incorrecta (%d)\n",largo);
      }
      largo = (
      strlen(strncpy(recordidentifier4100, b4100.c.recordidentifier, RECORDIDENTIFIER4100)) +
      strlen(strncpy(issuerica4100, b4100.c.issuerica, ISSUERICA4100)) +
      strlen(strncpy(issuernumberica4100, b4100.c.issuernumberica, ISSUERNUMBERICA4100)) +
      strlen(strncpy(corporationnumber4100, b4100.c.corporationnumber, CORPORATIONNUMBER4100)) +
      strlen(strncpy(reservedforinternaluse14100, b4100.c.reservedforinternaluse1, RESERVEDFORINTERNALUSE14100)) +
      strlen(strncpy(reservedforinternaluse24100, b4100.c.reservedforinternaluse2, RESERVEDFORINTERNALUSE24100)) +
      strlen(strncpy(reservedforinternaluse34100, b4100.c.reservedforinternaluse3, RESERVEDFORINTERNALUSE34100)) +
      strlen(strncpy(organizationpointnumber4100, b4100.c.organizationpointnumber, ORGANIZATIONPOINTNUMBER4100)) +
      strlen(strncpy(freeformattext4100, b4100.c.freeformattext, FREEFORMATTEXT4100)) +
      strlen(strncpy(organizationpointnameline14100, b4100.c.organizationpointnameline1, ORGANIZATIONPOINTNAMELINE14100)) +
      strlen(strncpy(organizationpointnameline24100, b4100.c.organizationpointnameline2, ORGANIZATIONPOINTNAMELINE24100)) +
      strlen(strncpy(addressline14100, b4100.c.addressline1, ADDRESSLINE14100)) +
      strlen(strncpy(addressline24100, b4100.c.addressline2, ADDRESSLINE24100)) +
      strlen(strncpy(city4100, b4100.c.city, CITY4100)) +
      strlen(strncpy(stateprovince4100, b4100.c.stateprovince, STATEPROVINCE4100)) +
      strlen(strncpy(country4100, b4100.c.country, COUNTRY4100)) +
      strlen(strncpy(postalcode4100, b4100.c.postalcode, POSTALCODE4100)) +
      strlen(strncpy(currencycode4100, b4100.c.currencycode, CURRENCYCODE4100)) +
      strlen(strncpy(contactperson4100, b4100.c.contactperson, CONTACTPERSON4100)) +
      strlen(strncpy(phonenumber4100, b4100.c.phonenumber, PHONENUMBER4100)) +
      strlen(strncpy(faxnumber4100, b4100.c.faxnumber, FAXNUMBER4100)) +
      strlen(strncpy(emailaddress4100, b4100.c.emailaddress, EMAILADDRESS4100)) +
      strlen(strncpy(budgetlimit4100, b4100.c.budgetlimit, BUDGETLIMIT4100)) +
      strlen(strncpy(totalaccounts4100, b4100.c.totalaccounts, TOTALACCOUNTS4100)) +
      strlen(strncpy(accountspastdue4100, b4100.c.accountspastdue, ACCOUNTSPASTDUE4100)) +
      strlen(strncpy(accountswithdispute4100, b4100.c.accountswithdispute, ACCOUNTSWITHDISPUTE4100)) +
      strlen(strncpy(numberofcards4100, b4100.c.numberofcards, NUMBEROFCARDS4100)) +
      strlen(strncpy(chargeoffsign4100, b4100.c.chargeoffsign, CHARGEOFFSIGN4100)) +
      strlen(strncpy(chargeoffamount4100, b4100.c.chargeoffamount, CHARGEOFFAMOUNT4100)) +
      strlen(strncpy(pastdueamountsign4100, b4100.c.pastdueamountsign, PASTDUEAMOUNTSIGN4100)) +
      strlen(strncpy(pastdueamount4100, b4100.c.pastdueamount, PASTDUEAMOUNT4100)) +
      strlen(strncpy(disputeamountsign4100, b4100.c.disputeamountsign, DISPUTEAMOUNTSIGN4100)) +
      strlen(strncpy(disputeamount4100, b4100.c.disputeamount, DISPUTEAMOUNT4100)) +
      strlen(strncpy(creditlimitsign4100, b4100.c.creditlimitsign, CREDITLIMITSIGN4100)) +
      strlen(strncpy(creditlimit4100, b4100.c.creditlimit, CREDITLIMIT4100)) +
      strlen(strncpy(paymentduesign4100, b4100.c.paymentduesign, PAYMENTDUESIGN4100)) +
      strlen(strncpy(paymentdue4100, b4100.c.paymentdue, PAYMENTDUE4100)) +
      strlen(strncpy(outstandingbalancesign4100, b4100.c.outstandingbalancesign, OUTSTANDINGBALANCESIGN4100)) +
      strlen(strncpy(outstandingbalance4100, b4100.c.outstandingbalance, OUTSTANDINGBALANCE4100)) +
      strlen(strncpy(numberofdebits4100, b4100.c.numberofdebits, NUMBEROFDEBITS4100)) +
      strlen(strncpy(numberofcredits4100, b4100.c.numberofcredits, NUMBEROFCREDITS4100)) +
      strlen(strncpy(amountofdebits4100, b4100.c.amountofdebits, AMOUNTOFDEBITS4100)) +
      strlen(strncpy(amountofcredits4100, b4100.c.amountofcredits, AMOUNTOFCREDITS4100)) +
      strlen(strncpy(numberaccountsoverlimit4100, b4100.c.numberaccountsoverlimit, NUMBERACCOUNTSOVERLIMIT4100)) +
      strlen(strncpy(portfoliodate4100, b4100.c.portfoliodate, PORTFOLIODATE4100)) +
      strlen(strncpy(addressmaintenanceactioncode4100, b4100.c.addressmaintenanceactioncode, ADDRESSMAINTENANCEACTIONCODE4100)) +
      strlen(strncpy(inputfilerecordnumber4100, b4100.c.inputfilerecordnumber, INPUTFILERECORDNUMBER4100)) +
      strlen(strncpy(outgoingincomingerrorcode4100, b4100.c.outgoingincomingerrorcode, OUTGOINGINCOMINGERRORCODE4100)) );
      if ((largo)!= LONGCADENA4100)
      {
        printf("Error en longitud del registro 4100 (%d)%d\n\n",largo, LONGCADENA4100+1);
      }
      /* El registro corresponde a un registro tipo 4100
      y tanto la longiud de lo leido como la sumatoria de la longitud
      de los campos es la adecuada   */
      /* y ahora a checar cada uno de los campos      */
      /*se barre el arreglo de los campos y se asignan valores*/
       for (i = 0;i < reg4100;i++)      
      {
        strcpy(b4100.cadena,Arreglo4100[i]);
		strncpy(ftoNumCampo,r4100.a.ftonumcam,4); 
        strncpy(ftoNomCampo,r4100.a.ftonomcam,35);
        strncpy(ftoLongitud,r4100.a.ftolong,4);   
        strncpy(ftoTipoDato,r4100.a.ftotipodat,1);
        strncpy(ftoFill,r4100.a.ftofiller,1);     
        strncpy(ftoJustificado,r4100.a.ftojust,1);
        strncpy(ftoFormato,r4100.a.ftoforma,25);  
                
        switch(atoi(ftoNumCampo))
        {
          case 1:
            valFormatogral(reporte, recordidentifier4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            /* Ejemplo anterior : valFormatogral(reporte, recordidentifier, ftoNomCampo, inputfilerecordnumber, ftoTipoDato, strcat(ftoFill,ftoJustificado)); */
            break;           
          case 2:
            valFormatogral(reporte, issuerica4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 3:
            valFormatogral(reporte, issuernumberica4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 4:
            valFormatogral(reporte, corporationnumber4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 5:
            valFormatogral(reporte, reservedforinternaluse14100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 6:
            valFormatogral(reporte, reservedforinternaluse24100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 7:
            valFormatogral(reporte, reservedforinternaluse34100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 8:
            valFormatogral(reporte, organizationpointnumber4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 9:
            valFormatogral(reporte, freeformattext4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 10:
            valFormatogral(reporte, organizationpointnameline14100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 11:
            valFormatogral(reporte, organizationpointnameline24100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato,ftoFill,ftoJustificado);
            break; 
          case 12:
            valFormatogral(reporte, addressline14100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 13:
            valFormatogral(reporte, addressline24100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 14:
            valFormatogral(reporte, city4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 15:
            valFormatogral(reporte, stateprovince4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 16:
            valFormatogral(reporte, country4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 17:
            valFormatogral(reporte, postalcode4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 18:
            valFormatogral(reporte, currencycode4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 19:
            valFormatogral(reporte, contactperson4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 20:
            valFormatogral(reporte, phonenumber4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 21:
            valFormatogral(reporte, faxnumber4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 22:
            valFormatogral(reporte, emailaddress4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 23:
            valFormatogral(reporte, budgetlimit4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 24:
            valFormatogral(reporte, totalaccounts4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;           
          case 25:
            valFormatogral(reporte, accountspastdue4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato,ftoFill,ftoJustificado);
            break;
          case 26:
            valFormatogral(reporte, accountswithdispute4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 27:
            valFormatogral(reporte, numberofcards4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 28:
            valFormatogral(reporte, chargeoffsign4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 29:
            valFormatogral(reporte, chargeoffamount4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 30:
            valFormatogral(reporte, pastdueamountsign4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 31:
            valFormatogral(reporte, pastdueamount4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 32:
            valFormatogral(reporte, disputeamountsign4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 33:
            valFormatogral(reporte, disputeamount4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 34:
            valFormatogral(reporte, creditlimitsign4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 35:
            valFormatogral(reporte, creditlimit4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 36:
            valFormatogral(reporte, paymentduesign4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 37:
            valFormatogral(reporte, paymentdue4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 38:
            valFormatogral(reporte, outstandingbalancesign4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break; 
          case 39:
            valFormatogral(reporte, outstandingbalance4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 40:
            valFormatogral(reporte, numberofdebits4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 41:
            valFormatogral(reporte, numberofcredits4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 42:
            valFormatogral(reporte, amountofdebits4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 43:
            valFormatogral(reporte, amountofcredits4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 44:
            valFormatogral(reporte, numberaccountsoverlimit4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 45:
            valFormatogral(reporte, portfoliodate4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 46:
            valFormatogral(reporte, addressmaintenanceactioncode4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 47:
            valFormatogral(reporte, inputfilerecordnumber4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
          case 48:
            valFormatogral(reporte, outgoingincomingerrorcode4100, ftoNomCampo, inputfilerecordnumber4100, ftoTipoDato, ftoFill,ftoJustificado);
            break;
        } /* Case numero de campo */
        
        ftoNumCampo[0]=NULL;          
        ftoNomCampo[0]=NULL;          
        ftoLongitud[0]=NULL;          
        ftoTipoDato[0]=NULL;          
        ftoFill[0]=NULL;              
        ftoJustificado[0]=NULL;       
        ftoFormato[0]=NULL;
      }  /* Mientras existan registros / For i=0 a MAXCAMPOS */

      /** VALIDACIONES ESPECIFICAS DEL REGISTRO **/
      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN PUROS BLANCOS **/
      blancos(reporte,reservedforinternaluse14100,"reservedforinternaluse1", inputfilerecordnumber4100);
      blancos(reporte,reservedforinternaluse24100,"reservedforinternaluse2", inputfilerecordnumber4100);
      blancos(reporte,reservedforinternaluse34100,"reservedforinternaluse3", inputfilerecordnumber4100);
      blancos(reporte,freeformattext4100,"freeformattext", inputfilerecordnumber4100);
      blancos(reporte,outgoingincomingerrorcode4100,"outgoingincomingerrorcode", inputfilerecordnumber4100);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN NUMEROS O ESPACIOS O GUIONES **/
      numespgui(reporte,corporationnumber4100,"corporationnumber", inputfilerecordnumber4100);
      numespgui(reporte,organizationpointnumber4100,"organizationpointnumber", inputfilerecordnumber4100);
      numespgui(reporte,postalcode4100,"postalcode", inputfilerecordnumber4100);
      numespgui(reporte,phonenumber4100,"phonenumber", inputfilerecordnumber4100);
      numespgui(reporte,faxnumber4100,"faxnumber", inputfilerecordnumber4100);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN PUROS CEROS **/
      ceros(reporte,chargeoffamount4100,"chargeoffamount", inputfilerecordnumber4100);

      if (!(country4100[0]=='M' && country4100[1]=='E' && country4100[2]=='X'))
      {
        printf("El campo country solo acepta 'MEX' =%s=(%s)\n", country4100, inputfilerecordnumber4100);
      }
      if (!(currencycode4100[0]=='4' && currencycode4100[1]=='8' && currencycode4100[2]=='4'))
      {
        printf("El campo currencycode solo acepta '484' =%s=(%s)\n", currencycode4100, inputfilerecordnumber4100);
      }
      if (chargeoffsign4100[0]!='C' && chargeoffsign4100[0]!='D')
      {
        printf("El campo chargeoffsign solo acepta 'C' o 'D' =%s=(%s)\n", chargeoffsign4100, inputfilerecordnumber4100);
      }
      if (pastdueamountsign4100[0]!='C' && pastdueamountsign4100[0]!='D')
      {
        printf("El campo pastdueamountsign solo acepta 'C' o 'D' =%s=(%s)\n", pastdueamountsign4100, inputfilerecordnumber4100);
      }
      if (disputeamountsign4100[0]!='C' && disputeamountsign4100[0]!='D')
      {
        printf("El campo disputeamountsign solo acepta 'C' o 'D' =%s=(%s)\n", disputeamountsign4100, inputfilerecordnumber4100);
      }
      if (creditlimitsign4100[0]!='C' && creditlimitsign4100[0]!='D')
      {
        printf("El campo creditlimitsign solo acepta 'C' o 'D' =%s=(%s)\n", creditlimitsign4100, inputfilerecordnumber4100);
      }
      if (paymentduesign4100[0]!='C' && paymentduesign4100[0]!='D')
      {
        printf("El campo paymentduesign solo acepta 'C' o 'D' =%s=(%s)\n", paymentduesign4100, inputfilerecordnumber4100);
      }
      if (outstandingbalancesign4100[0]!='C' && outstandingbalancesign4100[0]!='D')
      {
        printf("El campo outstandingbalancesign solo acepta 'C' o 'D' =%s=(%s)\n", outstandingbalancesign4100, inputfilerecordnumber4100);
      }
      if (addressmaintenanceactioncode4100[0]!='A' && addressmaintenanceactioncode4100[0]!='U' && addressmaintenanceactioncode4100[0]!='D')
      {  
        printf("El campo addressmaintenanceactioncode solo acepta 'A' o 'U' o 'D' =%s=(%s)\n", addressmaintenanceactioncode4100, inputfilerecordnumber4100);
      }
      /** FIN DE LAS VALIDACIONES ESPECIFICAS **/
}
