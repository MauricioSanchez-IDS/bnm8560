#if USE_SCCSID
static char Sccsid[] = {"@(#) vali4300opt.c 30/01/2001"};
#endif /* USE_SCCSID */

#include <stdio.h>
#include <sybfront.h>
#include <sybdb.h>
#include <stdlib.h>
#include <string.h>
#include "sybdbex.h"
#include "simbolos.h"
#include "campos.h"	/*Para prueba, IERM*/

#define LONGCADENA4300    734 	/*Ampliado de 706 a 732, IERM Sept. 17, 2004*/ 
#define LONGREGISTRO4300 75

union                                                                 
{                                                                     
char registro [ LONGREGISTRO4300 + 3 ]; /* con retorno de carro y nulo*/
struct                                                                
        {                                                             
         char ftonumcam[ 4 + 1];                                           
         char ftonomcam[ 35 + 1 ];                                          
         char ftolong[ 4 +1 ];                                             
         char ftotipodat[ 1 +1 ];                                          
         char ftofiller[ 1 +1 ];                                           
         char ftojust[ 1 + 1 ];                                             
         char ftoforma[ 25 + 1 ];                                           
        } a;                                                          
} r4300;                                                                  

union
{
char cadena [LONGCADENA4300 + 2]; /* con retorno de carro y nulo*/
struct
	{
      char recordidentifier[RECORDIDENTIFIER4300];
      char issuerica[ISSUERICA4300];
      char issuernumberica[ISSUERNUMBERICA4300];
      char corporationnumber[CORPORATIONNUMBER4300];
      char reservedforinternaluse1[RESERVEDFORINTERNALUSE14300];
      char reservedforinternaluse2[RESERVEDFORINTERNALUSE24300];
      char reservedforinternaluse3[RESERVEDFORINTERNALUSE34300];
      char reportstoorgpointnumber[REPORTSTOORGPOINTNUMBER4300];
      char reportstofreeformattext[REPORTSTOFREEFORMATTEXT4300];
      char accountnumber[ACCOUNTNUMBER4300];
      char corporateproduct[CORPORATEPRODUCT4300];
      char effectivedate[EFFECTIVEDATE4300];
      char expirationdate[EXPIRATIONDATE4300];
      char accountnameline1[ACCOUNTNAMELINE14300];
      char accountnameline2[ACCOUNTNAMELINE24300];
      char accountaddressline1[ACCOUNTADDRESSLINE14300];
      char accountaddressline2[ACCOUNTADDRESSLINE24300];
      char accountcity[ACCOUNTCITY4300];
      char accountstateprovince[ACCOUNTSTATEPROVINCE4300];
      char accountcountry[ACCOUNTCOUNTRY4300];
      char accountpostalcode[ACCOUNTPOSTALCODE4300];
      char accountphonenumber[ACCOUNTPHONENUMBER4300];
      char accountfaxnumber[ACCOUNTFAXNUMBER4300];
      char internalauditcode[INTERNALAUDITCODE4300];
      char employeeid[ EMPLOYEEID4300 ];
      char dailynumberlimitoftransactions[DAILYNUMBERLIMITOFTRANSACTIONS4300];
      char singletransactiondollarlimit[SINGLETRANSACTIONDOLLARLIMIT4300];
      char dailytransactiondollarlimit[DAILYTRANSACTIONDOLLARLIMIT4300];
      char cyclenumberoftransactionslimit[CYCLENUMBEROFTRANSACTIONSLIMIT4300];
      char cycledollarlimit[CYCLEDOLLARLIMIT4300];
      char monthlynumlimitoftran[MONTHLYNUMLIMITOFTRAN4300];
      char monthlydollarlimit[MONTHLYDOLLARLIMIT4300];
      char othernumberoftransactionslimit[OTHERNUMBEROFTRANSACTIONSLIMIT4300];
      char otherdollarlimit[OTHERDOLLARLIMIT4300];
      char taxexemptindicator[TAXEXEMPTINDICATOR4300];
      char currencycode[CURRENCYCODE4300];
      char statementdate[STATEMENTDATE4300];
      char previousbalancesign[PREVIOUSBALANCESIGN4300];
      char previousbalance[PREVIOUSBALANCE4300];
      char endingbalancesign[ENDINGBALANCESIGN4300];
      char endingbalance[ENDINGBALANCE4300];
      char paymentduesign[PAYMENTDUESIGN4300];
      char paymentduebalance[PAYMENTDUEBALANCE4300];
      char creditlimitsign[CREDITLIMITSIGN4300];
      char creditlimit[CREDITLIMIT4300];
      char pastdueamountsign[PASTDUEAMOUNTSIGN4300];
      char pastduebalance[PASTDUEBALANCE4300];
      char chargeoffsign[CHARGEOFFSIGN4300];
      char chargeoffamount[CHARGEOFFAMOUNT4300];
      char disputedamountsign[DISPUTEDAMOUNTSIGN4300];
      char disputedamount[DISPUTEDAMOUNT4300];
      char numberpaymentspastdue[NUMBERPAYMENTSPASTDUE4300];
      char highestdelinquencyperiod[HIGHESTDELINQUENCYPERIOD4300];
      char accountindisputeflag[ACCOUNTINDISPUTEFLAG4300];
      char addressmaintenanceactioncode[ADDRESSMAINTENANCEACTIONCODE4300];
      char inputfilerecordnumber[INPUTFILERECORDNUMBER4300];
      char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE4300];
	} c;
} b4300;

int CS_PUBLIC   err_handler();
int CS_PUBLIC   msg_handler();

vali4300(cadena4300, Arreglo4300, reg4300)
char cadena4300[];
char *Arreglo4300[];
int reg4300;
{
  char *reporte;
  int largo, a, i;
  char leye[100];

      strcpy(b4300.cadena,cadena4300); 
      largo = strlen(b4300.cadena);
      if (largo!=LONGCADENA4300)
      {
        printf("La lectura del registro 4300 es incorrecta (%d)\n",largo);
      }
      largo = (
      strlen(strncpy(recordidentifier4300, b4300.c.recordidentifier, RECORDIDENTIFIER4300)) +
      strlen(strncpy(issuerica4300, b4300.c.issuerica, ISSUERICA4300)) +
      strlen(strncpy(issuernumberica4300, b4300.c.issuernumberica, ISSUERNUMBERICA4300)) +
      strlen(strncpy(corporationnumber4300, b4300.c.corporationnumber, CORPORATIONNUMBER4300)) +
      strlen(strncpy(reservedforinternaluse14300, b4300.c.reservedforinternaluse1, RESERVEDFORINTERNALUSE14300)) +
      strlen(strncpy(reservedforinternaluse24300, b4300.c.reservedforinternaluse2, RESERVEDFORINTERNALUSE24300)) +
      strlen(strncpy(reservedforinternaluse34300, b4300.c.reservedforinternaluse3, RESERVEDFORINTERNALUSE34300)) +
      strlen(strncpy(reportstoorgpointnumber4300, b4300.c.reportstoorgpointnumber, REPORTSTOORGPOINTNUMBER4300)) +
      strlen(strncpy(reportstofreeformattext4300, b4300.c.reportstofreeformattext, REPORTSTOFREEFORMATTEXT4300)) +
      strlen(strncpy(accountnumber4300, b4300.c.accountnumber, ACCOUNTNUMBER4300)) +
      strlen(strncpy(corporateproduct4300, b4300.c.corporateproduct, CORPORATEPRODUCT4300)) +
      strlen(strncpy(effectivedate4300, b4300.c.effectivedate, EFFECTIVEDATE4300)) +
      strlen(strncpy(expirationdate4300, b4300.c.expirationdate, EXPIRATIONDATE4300)) +
      strlen(strncpy(accountnameline14300, b4300.c.accountnameline1, ACCOUNTNAMELINE14300)) +
      strlen(strncpy(accountnameline24300, b4300.c.accountnameline2, ACCOUNTNAMELINE24300)) +
      strlen(strncpy(accountaddressline14300, b4300.c.accountaddressline1, ACCOUNTADDRESSLINE14300)) +
      strlen(strncpy(accountaddressline24300, b4300.c.accountaddressline2, ACCOUNTADDRESSLINE24300)) +
      strlen(strncpy(accountcity4300, b4300.c.accountcity, ACCOUNTCITY4300)) +
      strlen(strncpy(accountstateprovince4300, b4300.c.accountstateprovince, ACCOUNTSTATEPROVINCE4300)) +
      strlen(strncpy(accountcountry4300, b4300.c.accountcountry, ACCOUNTCOUNTRY4300)) +
      strlen(strncpy(accountpostalcode4300, b4300.c.accountpostalcode, ACCOUNTPOSTALCODE4300)) +
      strlen(strncpy(accountphonenumber4300, b4300.c.accountphonenumber, ACCOUNTPHONENUMBER4300)) +
      strlen(strncpy(accountfaxnumber4300, b4300.c.accountfaxnumber, ACCOUNTFAXNUMBER4300)) +
      strlen(strncpy(internalauditcode4300, b4300.c.internalauditcode, INTERNALAUDITCODE4300)) +
      strlen(strncpy(employeeid4300, b4300.c.employeeid, EMPLOYEEID4300)) +
      strlen(strncpy(dailynumberlimitoftransactions4300, b4300.c.dailynumberlimitoftransactions, DAILYNUMBERLIMITOFTRANSACTIONS4300)) +
      strlen(strncpy(singletransactiondollarlimit4300, b4300.c.singletransactiondollarlimit, SINGLETRANSACTIONDOLLARLIMIT4300)) +
      strlen(strncpy(dailytransactiondollarlimit4300, b4300.c.dailytransactiondollarlimit, DAILYTRANSACTIONDOLLARLIMIT4300)) +
      strlen(strncpy(cyclenumberoftransactionslimit4300, b4300.c.cyclenumberoftransactionslimit, CYCLENUMBEROFTRANSACTIONSLIMIT4300)) +
      strlen(strncpy(cycledollarlimit4300, b4300.c.cycledollarlimit, CYCLEDOLLARLIMIT4300)) +
      strlen(strncpy(monthlynumlimitoftran4300, b4300.c.monthlynumlimitoftran, MONTHLYNUMLIMITOFTRAN4300)) +
      strlen(strncpy(monthlydollarlimit4300, b4300.c.monthlydollarlimit, MONTHLYDOLLARLIMIT4300)) +
      strlen(strncpy(othernumberoftransactionslimit4300, b4300.c.othernumberoftransactionslimit, OTHERNUMBEROFTRANSACTIONSLIMIT4300)) +
      strlen(strncpy(otherdollarlimit4300, b4300.c.otherdollarlimit, OTHERDOLLARLIMIT4300)) +
      strlen(strncpy(taxexemptindicator4300, b4300.c.taxexemptindicator, TAXEXEMPTINDICATOR4300)) +
      strlen(strncpy(currencycode4300, b4300.c.currencycode, CURRENCYCODE4300)) +
      strlen(strncpy(statementdate4300, b4300.c.statementdate, STATEMENTDATE4300)) +
      strlen(strncpy(previousbalancesign4300, b4300.c.previousbalancesign, PREVIOUSBALANCESIGN4300)) +
      strlen(strncpy(previousbalance4300, b4300.c.previousbalance, PREVIOUSBALANCE4300)) +
      strlen(strncpy(endingbalancesign4300, b4300.c.endingbalancesign, ENDINGBALANCESIGN4300)) +
      strlen(strncpy(endingbalance4300, b4300.c.endingbalance, ENDINGBALANCE4300)) +
      strlen(strncpy(paymentduesign4300, b4300.c.paymentduesign, PAYMENTDUESIGN4300)) +
      strlen(strncpy(paymentduebalance4300, b4300.c.paymentduebalance, PAYMENTDUEBALANCE4300)) +
      strlen(strncpy(creditlimitsign4300, b4300.c.creditlimitsign, CREDITLIMITSIGN4300)) +
      strlen(strncpy(creditlimit4300, b4300.c.creditlimit, CREDITLIMIT4300)) +
      strlen(strncpy(pastdueamountsign4300, b4300.c.pastdueamountsign, PASTDUEAMOUNTSIGN4300)) +
      strlen(strncpy(pastduebalance4300, b4300.c.pastduebalance, PASTDUEBALANCE4300)) +
      strlen(strncpy(chargeoffsign4300, b4300.c.chargeoffsign, CHARGEOFFSIGN4300)) +
      strlen(strncpy(chargeoffamount4300, b4300.c.chargeoffamount, CHARGEOFFAMOUNT4300)) +
      strlen(strncpy(disputedamountsign4300, b4300.c.disputedamountsign, DISPUTEDAMOUNTSIGN4300)) +
      strlen(strncpy(disputedamount4300, b4300.c.disputedamount, DISPUTEDAMOUNT4300)) +
      strlen(strncpy(numberpaymentspastdue4300, b4300.c.numberpaymentspastdue, NUMBERPAYMENTSPASTDUE4300)) +
      strlen(strncpy(highestdelinquencyperiod4300, b4300.c.highestdelinquencyperiod, HIGHESTDELINQUENCYPERIOD4300)) +
      strlen(strncpy(accountindisputeflag4300, b4300.c.accountindisputeflag, ACCOUNTINDISPUTEFLAG4300)) +
      strlen(strncpy(addressmaintenanceactioncode4300, b4300.c.addressmaintenanceactioncode, ADDRESSMAINTENANCEACTIONCODE4300)) +
      strlen(strncpy(inputfilerecordnumber4300, b4300.c.inputfilerecordnumber, INPUTFILERECORDNUMBER4300)) +
      strlen(strncpy(outgoingincomingerrorcode4300, b4300.c.outgoingincomingerrorcode, OUTGOINGINCOMINGERRORCODE4300)) );

      if( ( (-largo ) - 734 ) != LONGCADENA4300 )
      {
        printf("Error en longitud del registro 4300 (%d)%d\n\n", largo, LONGCADENA4300 + 1 );
      }
      /* El registro corresponde a un registro tipo 4300
      y tanto la longiud de lo leido como la sumatoria de la longitud
      de los campos es la adecuada   */
      /* y ahora a checar cada uno de los campos      */
      /*se barre el arreglo de los campos y se asignan valores*/
      for (i = 0;i < reg4300;i++)
      {
        strcpy(r4300.registro,Arreglo4300[i]);
	strncpy(ftoNumCampo,r4300.a.ftonumcam,4); 
        strncpy(ftoNomCampo,r4300.a.ftonomcam,35);
        strncpy(ftoLongitud,r4300.a.ftolong,4);   
        strncpy(ftoTipoDato,r4300.a.ftotipodat,1);
        strncpy(ftoFill,r4300.a.ftofiller,1);     
        strncpy(ftoJustificado,r4300.a.ftojust,1);
        strncpy(ftoFormato,r4300.a.ftoforma,25);  
                                                      
        switch(atoi(ftoNumCampo))             
        {
          case 1:
            valFormatogral(reporte, recordidentifier4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            /*Ejemplo anterior : valFormatogral(reporte, recordidentifier, ftoNomCampo, inputfilerecordnumber, ftoTipoDato, strcat(ftoFill, ftoJustificado));*/
            break;           
          case 2:
            valFormatogral(reporte, issuerica4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 3:
            valFormatogral(reporte, issuernumberica4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 4:
            valFormatogral(reporte, corporationnumber4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 5:
            valFormatogral(reporte, reservedforinternaluse14300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 6:
            valFormatogral(reporte, reservedforinternaluse24300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 7:
            valFormatogral(reporte, reservedforinternaluse34300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 8:
            valFormatogral(reporte, reportstoorgpointnumber4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 9:
            valFormatogral(reporte, reportstofreeformattext4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 10:
            valFormatogral(reporte, accountnumber4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 11:
            valFormatogral(reporte, corporateproduct4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 12:
            valFormatogral(reporte, effectivedate4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato,ftoFill, ftoJustificado);
            break; 
          case 13:
            valFormatogral(reporte, expirationdate4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 14:
            valFormatogral(reporte, accountnameline14300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 15:
            valFormatogral(reporte, accountnameline24300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 16:
            valFormatogral(reporte, accountaddressline14300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 17:
            valFormatogral(reporte, accountaddressline24300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 18:
            valFormatogral(reporte, accountcity4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 19:
            valFormatogral(reporte, accountstateprovince4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 20:
            valFormatogral(reporte, accountcountry4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato,ftoFill, ftoJustificado);
            break;
          case 21:
            valFormatogral(reporte, accountpostalcode4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 22:
            valFormatogral(reporte, accountphonenumber4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 23:
            valFormatogral(reporte, accountfaxnumber4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 24:
            valFormatogral(reporte, internalauditcode4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;           
          case 25:
            valFormatogral(reporte, dailynumberlimitoftransactions4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 26:
            valFormatogral(reporte, singletransactiondollarlimit4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 27:
            valFormatogral(reporte, dailytransactiondollarlimit4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 28:
            valFormatogral(reporte, cyclenumberoftransactionslimit4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 29:
            valFormatogral(reporte, cycledollarlimit4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 30:
            valFormatogral(reporte, monthlynumlimitoftran4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 31:
            valFormatogral(reporte, monthlydollarlimit4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 32:
            valFormatogral(reporte, othernumberoftransactionslimit4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 33:
            valFormatogral(reporte, otherdollarlimit4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 34:
            valFormatogral(reporte, taxexemptindicator4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 35:
            valFormatogral(reporte, currencycode4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 36:
            valFormatogral(reporte, statementdate4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 37:
            valFormatogral(reporte, previousbalancesign4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 38:
            valFormatogral(reporte, previousbalance4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break; 
          case 39:
            valFormatogral(reporte, endingbalancesign4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 40:
            valFormatogral(reporte, endingbalance4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 41:
            valFormatogral(reporte, paymentduesign4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 42:
            valFormatogral(reporte, paymentduebalance4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 43:
            valFormatogral(reporte, creditlimitsign4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 44:
            valFormatogral(reporte, creditlimit4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 45:
            valFormatogral(reporte, pastdueamountsign4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 46:
            valFormatogral(reporte, pastduebalance4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 47:
            valFormatogral(reporte, chargeoffsign4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 48:
            valFormatogral(reporte, chargeoffamount4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 49:
            valFormatogral(reporte, disputedamountsign4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 50:
            valFormatogral(reporte, disputedamount4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 51:
            valFormatogral(reporte, numberpaymentspastdue4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 52:
            valFormatogral(reporte, highestdelinquencyperiod4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 53:
            valFormatogral(reporte, accountindisputeflag4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 54:
            valFormatogral(reporte, addressmaintenanceactioncode4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 55:
            valFormatogral(reporte, inputfilerecordnumber4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 56:
            valFormatogral(reporte, outgoingincomingerrorcode4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
            break;
          case 57:
             valFormatogral(reporte, employeeid4300, ftoNomCampo, inputfilerecordnumber4300, ftoTipoDato, ftoFill, ftoJustificado);
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
      blancos(reporte,reservedforinternaluse14300,"reservedforinternaluse1", inputfilerecordnumber4300);
      blancos(reporte,reservedforinternaluse24300,"reservedforinternaluse2", inputfilerecordnumber4300);
      blancos(reporte,reservedforinternaluse34300,"reservedforinternaluse3", inputfilerecordnumber4300);
      blancos(reporte,reportstofreeformattext4300,"reportstofreeformattext", inputfilerecordnumber4300);
      blancos(reporte,internalauditcode4300,"internalauditcode", inputfilerecordnumber4300);
      blancos(reporte,accountindisputeflag4300,"accountindisputeflag", inputfilerecordnumber4300);
      blancos(reporte,outgoingincomingerrorcode4300,"outgoingincomingerrorcode", inputfilerecordnumber4300);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN NUMEROS O ESPACIOS O GUIONES **/
      numespgui(reporte,corporationnumber4300,"corporationnumber", inputfilerecordnumber4300);
      numespgui(reporte,reportstoorgpointnumber4300,"reportstoorgpointnumber", inputfilerecordnumber4300);
      numespgui(reporte,accountnumber4300,"accountnumber", inputfilerecordnumber4300);
      numespgui(reporte,accountpostalcode4300,"accountpostalcode", inputfilerecordnumber4300);
      numespgui(reporte,accountphonenumber4300,"accountphonenumber", inputfilerecordnumber4300);
      numespgui(reporte,accountfaxnumber4300,"accountfaxnumber", inputfilerecordnumber4300);

      /** VALIDA QUE EL CONTENIDO DE LOS CAMPOS SEAN PUROS CEROS **/
      ceros(reporte,dailynumberlimitoftransactions4300,"dailynumberlimitoftransactions", inputfilerecordnumber4300);
      ceros(reporte,singletransactiondollarlimit4300,"singletransactiondollarlimit", inputfilerecordnumber4300);
      ceros(reporte,dailytransactiondollarlimit4300,"dailytransactiondollarlimit", inputfilerecordnumber4300);
      ceros(reporte,cyclenumberoftransactionslimit4300,"cyclenumberoftransactionslimit", inputfilerecordnumber4300);
      ceros(reporte,cycledollarlimit4300,"cycledollarlimit", inputfilerecordnumber4300);
      ceros(reporte,monthlynumlimitoftran4300,"monthlynumlimitoftran", inputfilerecordnumber4300);
      ceros(reporte,monthlydollarlimit4300,"monthlydollarlimit", inputfilerecordnumber4300);
      ceros(reporte,othernumberoftransactionslimit4300,"othernumberoftransactionslimit", inputfilerecordnumber4300);
      ceros(reporte,otherdollarlimit4300, "otherdollarlimit", inputfilerecordnumber4300);
      ceros(reporte,chargeoffamount4300,"chargeoffamount", inputfilerecordnumber4300);
      ceros(reporte,highestdelinquencyperiod4300,"highestdelinquencyperiod", inputfilerecordnumber4300);
      
      if (!(accountstateprovince4300[0]=='M' && accountstateprovince4300[1]=='E' && accountstateprovince4300[2]=='X'))
      {
        printf("El campo accountstateprovince solo acepta 'MEX' =%s=(%s)\n", accountstateprovince4300, inputfilerecordnumber4300);
      }
      if (!(accountcountry4300[0]=='M' && accountcountry4300[1]=='E' && accountcountry4300[2]=='X'))
      {
        printf("El campo accountcountry solo acepta 'MEX' =%s=(%s)\n", accountcountry4300, inputfilerecordnumber4300);
      }
      if (taxexemptindicator4300[0]!='Y' && taxexemptindicator4300[0]!='N' && taxexemptindicator4300[0]!=SP)
      {  
        printf("El campo taxexemptindicator solo acepta 'A' o 'U' o 'D' =%s=(%s)\n", taxexemptindicator4300, inputfilerecordnumber4300);
      }
      if (!(currencycode4300[0]=='4' && currencycode4300[1]=='8' && currencycode4300[2]=='4'))
      {
        printf("El campo currencycode solo acepta '484' =%s=(%s)\n", currencycode4300, inputfilerecordnumber4300);
      }
      if (previousbalancesign4300[0]!='C' && previousbalancesign4300[0]!='D')
      {
        printf("El campo previousbalancesign solo acepta 'C' o 'D' =%s=(%s)\n", previousbalancesign4300, inputfilerecordnumber4300);
      }
      if (endingbalancesign4300[0]!='C' && endingbalancesign4300[0]!='D')
      {
        printf("El campo endingbalancesign solo acepta 'C' o 'D' =%s=(%s)\n", endingbalancesign4300, inputfilerecordnumber4300);
      }
      if (paymentduesign4300[0]!='C' && paymentduesign4300[0]!='D')
      {
        printf("El campo paymentduesign solo acepta 'C' o 'D' =%s=(%s)\n", paymentduesign4300, inputfilerecordnumber4300);
      }
      if (creditlimitsign4300[0]!='C' && creditlimitsign4300[0]!='D')
      {
        printf("El campo creditlimitsign solo acepta 'C' o 'D' =%s=(%s)\n", creditlimitsign4300, inputfilerecordnumber4300);
      }
      if (pastdueamountsign4300[0]!='C' && pastdueamountsign4300[0]!='D')
      {
        printf("El campo pastdueamountsign solo acepta 'C' o 'D' =%s=(%s)\n", pastdueamountsign4300, inputfilerecordnumber4300);
      }
      if (chargeoffsign4300[0]!='D')
      {
        printf("El campo chargeoffsign solo acepta 'C' o 'D' =%s=(%s)\n", chargeoffsign4300, inputfilerecordnumber4300);
      }
      if (disputedamountsign4300[0]!='C' && disputedamountsign4300[0]!='D')
      {
        printf("El campo disputedamountsign solo acepta 'C' o 'D' =%s=(%s)\n", disputedamountsign4300, inputfilerecordnumber4300);
      }
      if (addressmaintenanceactioncode4300[0]!='A' && addressmaintenanceactioncode4300[0]!='U' && addressmaintenanceactioncode4300[0]!='D')
      {  
        printf("El campo addressmaintenanceactioncode solo acepta 'A' o 'U' o 'D' =%s=(%s)\n", addressmaintenanceactioncode4300, inputfilerecordnumber4300);
      }
      /** FIN DE LAS VALIDACIONES ESPECIFICAS **/  
}
/********************************************************************************************/
