/*
**      EISSA Header
**      Propiedad de EISSA.
**      (c) Copyright EISSA. 2000.
**      All rights reserved.
**
**
** El uso, copiado, o distribucisn de este csdigo esta sujeto a restricciones 
** y protegido por Technical Data and Computer Software para EISSA. 
** 
** Nombre: cam4300.h
** 
** Elaborado por : Ing. Josi Ramsn Gonzalez Dmaz 
**
** Historial/Modificaciones
**
** 001 15/dic/2000 Creacisn de este header para el manejo de campos en 
** las variables de los programas para la elaboracisn del archivo CDF.  
**  para el registro 4300. 
*/


/**
  *		Declaracion de los formatos
   **/

#define EMPTYSTR "\0"
#define FRMN7 "%+07s"
#define FRMN8 "%+08s"


#define FRMA1 "%-1s"
#define FRMA2 "%-2s"
#define FRMA3 "%-3s"
#define FRMA4 "%-4s"
#define FRMA5 "%-5s"
#define FRMA6 "%-6s"
#define FRMA7 "%-7s"
#define FRMA8 "%-8s"
#define FRMA9 "%-9s"
#define FRMA10 "%-10s"
#define FRMA11 "%-11s"
#define FRMA12 "%-12s"
#define FRMA13 "%-13s"
#define FRMA14 "%-14s"
#define FRMA15 "%-15s"
#define FRMA16 "%-16s"
#define FRMA17 "%-17s"
#define FRMA18 "%-18s"
#define FRMA19 "%-19s"
#define FRMA20 "%-20s"
#define FRMA21 "%-21s"
#define FRMA22 "%-22s"
#define FRMA24 "%-24s"
#define FRMA25 "%-25s"
#define FRMA35 "%-35s"
#define FRMA50 "%-50s"
#define FRMA75 "%-70s"


#define FRMN1 "%+01s"
#define FRMN2 "%+02s"
#define FRMN3 "%+03s"
#define FRMN4 "%+04s"
#define FRMN5 "%+05s"
#define FRMN6 "%+06s"
#define FRMN10 "%+010s"
#define FRMN11 "%+011s"
#define FRMN16 "%+016s"
#define FRMN20 "%+020s"


/**
  *		Fin de la definicion de formatos
  **/


#define RECORDIDENTIFIER 4
#define ISSUERICA 11
#define ISSUERNUMBERICA 11
#define CORPORATIONNUMBER 19
#define RESERVEDFORINTERNALUSE1 3
#define RESERVEDFORINTERNALUSE2 17
#define RESERVEDFORINTERNALUSE3 6
#define REPORTSTOORGPOINTNUMBER 19
#define REPORTSTOFREEFORMATTEXT 25
#define ACCOUNTNUMBER 19
#define CORPORATEPRODUCT 1
#define EFFECTIVEDATE 8
#define EXPIRATIONDATE 6
#define ACCOUNTNAMELINE1 35
#define ACCOUNTNAMELINE2 35
#define ACCOUNTADDRESSLINE1 35
#define ACCOUNTADDRESSLINE2 35
#define ACCOUNTCITY 20
#define ACCOUNTSTATEPROVINCE 3
#define ACCOUNTCOUNTRY 3
#define ACCOUNTPOSTALCODE 10
#define ACCOUNTPHONENUMBER 25
#define ACCOUNTFAXNUMBER 25
#define INTERNALAUDITCODE 75
#define EMPLOYEEID 20					/*Insertado!!*/
#define DAILYNUMBERLIMITOFTRANSACTIONS 8
#define SINGLETRANSACTIONDOLLARLIMIT 16
#define DAILYTRANSACTIONDOLLARLIMIT 16
#define CYCLENUMBEROFTRANSACTIONSLIMIT 8
#define CYCLEDOLLARLIMIT 16
#define MONTHLYNUMLIMITOFTRAN 8
#define MONTHLYDOLLARLIMIT 16
#define OTHERNUMBEROFTRANSACTIONSLIMIT 8
#define OTHERDOLLARLIMIT 16
#define TAXEXEMPTINDICATOR 1
#define CURRENCYCODE 3
#define STATEMENTDATE 8
#define PREVIOUSBALANCESIGN 1
#define PREVIOUSBALANCE 16
#define ENDINGBALANCESIGN 1
#define ENDINGBALANCE 16
#define PAYMENTDUESIGN 1
#define PAYMENTDUEBALANCE 16
#define CREDITLIMITSIGN 1
#define CREDITLIMIT 16
#define PASTDUEAMOUNTSIGN 1
#define PASTDUEBALANCE 16
#define CHARGEOFFSIGN 1
#define CHARGEOFFAMOUNT 16
#define DISPUTEDAMOUNTSIGN 1
#define DISPUTEDAMOUNT 16
#define NUMBERPAYMENTSPASTDUE 3
#define HIGHESTDELINQUENCYPERIOD 2
#define ACCOUNTINDISPUTEFLAG 1
#define ADDRESSMAINTENANCEACTIONCODE 1
#define INPUTFILERECORDNUMBER 6
#define OUTGOINGINCOMINGERRORCODE 6


char recordidentifier[RECORDIDENTIFIER + 1];
char issuerica[ISSUERICA + 1];
char issuernumberica[ISSUERNUMBERICA + 1];
char corporationnumber[CORPORATIONNUMBER + 1];
char reservedforinternaluse1[RESERVEDFORINTERNALUSE1 + 1];
char reservedforinternaluse2[RESERVEDFORINTERNALUSE2 + 1];
char reservedforinternaluse3[RESERVEDFORINTERNALUSE3 + 1];
char reportstoorgpointnumber[REPORTSTOORGPOINTNUMBER + 1];
char reportstofreeformattext[REPORTSTOFREEFORMATTEXT + 1];
char accountnumber[ACCOUNTNUMBER + 1];
char corporateproduct[CORPORATEPRODUCT + 1];
char effectivedate[EFFECTIVEDATE + 1];
char expirationdate[EXPIRATIONDATE + 1];
char accountnameline1[ACCOUNTNAMELINE1 + 1];
char accountnameline2[ACCOUNTNAMELINE2 + 1];
char accountaddressline1[ACCOUNTADDRESSLINE1 + 1];
char accountaddressline2[ACCOUNTADDRESSLINE2 + 1];
char accountcity[ACCOUNTCITY + 1];
char accountstateprovince[ACCOUNTSTATEPROVINCE + 1];
char accountcountry[ACCOUNTCOUNTRY + 1];
char accountpostalcode[ACCOUNTPOSTALCODE + 1];
char accountphonenumber[ACCOUNTPHONENUMBER + 1];
char accountfaxnumber[ACCOUNTFAXNUMBER + 1];
char internalauditcode[INTERNALAUDITCODE + 1];
char employeeid[ EMPLOYEEID + 1 ];                                     /*Insertado!!!*/

char dailynumberlimitoftransactions[DAILYNUMBERLIMITOFTRANSACTIONS + 1];
char singletransactiondollarlimit[SINGLETRANSACTIONDOLLARLIMIT + 1];
char dailytransactiondollarlimit[DAILYTRANSACTIONDOLLARLIMIT + 1];
char cyclenumberoftransactionslimit[CYCLENUMBEROFTRANSACTIONSLIMIT + 1];
char cycledollarlimit[CYCLEDOLLARLIMIT + 1];
char monthlynumlimitoftran[MONTHLYNUMLIMITOFTRAN + 1];
char monthlydollarlimit[MONTHLYDOLLARLIMIT + 1];
char othernumberoftransactionslimit[OTHERNUMBEROFTRANSACTIONSLIMIT + 1];
char otherdollarlimit[OTHERDOLLARLIMIT + 1];
char taxexemptindicator[TAXEXEMPTINDICATOR + 1];
char currencycode[CURRENCYCODE + 1];
char statementdate[STATEMENTDATE + 1];
char previousbalancesign[PREVIOUSBALANCESIGN + 1];
char previousbalance[PREVIOUSBALANCE + 1];
char endingbalancesign[ENDINGBALANCESIGN + 1];
char endingbalance[ENDINGBALANCE + 1];
char paymentduesign[PAYMENTDUESIGN + 1];
char paymentduebalance[PAYMENTDUEBALANCE + 1];
char creditlimitsign[CREDITLIMITSIGN + 1];
char creditlimit[CREDITLIMIT + 1];
char pastdueamountsign[PASTDUEAMOUNTSIGN + 1];
char pastduebalance[PASTDUEBALANCE + 1];
char chargeoffsign[CHARGEOFFSIGN + 1];
char chargeoffamount[CHARGEOFFAMOUNT + 1];
char disputedamountsign[DISPUTEDAMOUNTSIGN + 1];
char disputedamount[DISPUTEDAMOUNT + 1];
char numberpaymentspastdue[NUMBERPAYMENTSPASTDUE + 1];
char highestdelinquencyperiod[HIGHESTDELINQUENCYPERIOD + 1];
char accountindisputeflag[ACCOUNTINDISPUTEFLAG + 1];
char addressmaintenanceactioncode[ADDRESSMAINTENANCEACTIONCODE + 1];
char inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];
 


/*variables para contener al registro MTC4300*/
DBCHAR mtcrecordidentifier[RECORDIDENTIFIER + 1];
DBCHAR mtcissuerica[ISSUERICA + 1];
DBCHAR mtcissuernumberica[ISSUERNUMBERICA + 1];
DBCHAR mtccorporationnumber[CORPORATIONNUMBER + 1];
DBCHAR mtcreservedforinternaluse1[RESERVEDFORINTERNALUSE1 + 1];
DBCHAR mtcreservedforinternaluse2[RESERVEDFORINTERNALUSE2 + 1];
DBCHAR mtcreservedforinternaluse3[RESERVEDFORINTERNALUSE3 + 1];
DBCHAR mtcreportstoorgpointnumber[REPORTSTOORGPOINTNUMBER + 1];
DBCHAR mtcreportstofreeformattext[REPORTSTOFREEFORMATTEXT + 1];
DBCHAR mtcaccountnumber[ACCOUNTNUMBER + 1];
DBCHAR mtccorporateproduct[CORPORATEPRODUCT + 1];
DBCHAR mtceffectivedate[EFFECTIVEDATE + 1];
DBCHAR mtcexpirationdate[EXPIRATIONDATE + 1];
DBCHAR mtcaccountnameline1[ACCOUNTNAMELINE1 + 1];
DBCHAR mtcaccountnameline2[ACCOUNTNAMELINE2 + 1];
DBCHAR mtcaccountaddressline1[ACCOUNTADDRESSLINE1 + 1];
DBCHAR mtcaccountaddressline2[ACCOUNTADDRESSLINE2 + 1];
DBCHAR mtcaccountcity[ACCOUNTCITY + 1];
DBCHAR mtcaccountstateprovince[ACCOUNTSTATEPROVINCE + 1];
DBCHAR mtcaccountcountry[ACCOUNTCOUNTRY + 1];
DBCHAR mtcaccountpostalcode[ACCOUNTPOSTALCODE + 1];
DBCHAR mtcaccountphonenumber[ACCOUNTPHONENUMBER + 1];
DBCHAR mtcaccountfaxnumber[ACCOUNTFAXNUMBER + 1];
DBCHAR mtcinternalauditcode[INTERNALAUDITCODE + 1];
DBCHAR mtcemployeeid[ EMPLOYEEID + 1 ];				/*Insertado!!!*/
DBCHAR mtcdailynumberlimitoftransactions[DAILYNUMBERLIMITOFTRANSACTIONS + 1];
DBCHAR mtcsingletransactiondollarlimit[SINGLETRANSACTIONDOLLARLIMIT + 1];
DBCHAR mtcdailytransactiondollarlimit[DAILYTRANSACTIONDOLLARLIMIT + 1];
DBCHAR mtccyclenumberoftransactionslimit[CYCLENUMBEROFTRANSACTIONSLIMIT + 1];
DBCHAR mtccycledollarlimit[CYCLEDOLLARLIMIT + 1];
DBCHAR mtcmonthlynumlimitoftran[MONTHLYNUMLIMITOFTRAN + 1];
DBCHAR mtcmonthlydollarlimit[MONTHLYDOLLARLIMIT + 1];
DBCHAR mtcothernumberoftransactionslimit[OTHERNUMBEROFTRANSACTIONSLIMIT + 1];
DBCHAR mtcotherdollarlimit[OTHERDOLLARLIMIT + 1];
DBCHAR mtctaxexemptindicator[TAXEXEMPTINDICATOR + 1];
DBCHAR mtccurrencycode[CURRENCYCODE + 1];
DBCHAR mtcstatementdate[STATEMENTDATE + 1];
DBCHAR mtcpreviousbalancesign[PREVIOUSBALANCESIGN + 1];
DBCHAR mtcpreviousbalance[PREVIOUSBALANCE + 1];
DBCHAR mtcendingbalancesign[ENDINGBALANCESIGN + 1];
DBCHAR mtcendingbalance[ENDINGBALANCE + 1];
DBCHAR mtcpaymentduesign[PAYMENTDUESIGN + 1];
DBCHAR mtcpaymentduebalance[PAYMENTDUEBALANCE + 1];
DBCHAR mtccreditlimitsign[CREDITLIMITSIGN + 1];
DBCHAR mtccreditlimit[CREDITLIMIT + 1];
DBCHAR mtcpastdueamountsign[PASTDUEAMOUNTSIGN + 1];
DBCHAR mtcpastduebalance[PASTDUEBALANCE + 1];
DBCHAR mtcchargeoffsign[CHARGEOFFSIGN  + 1];
DBCHAR mtcchargeoffamount[CHARGEOFFAMOUNT + 1];
DBCHAR mtcdisputedamountsign[DISPUTEDAMOUNTSIGN + 1];
DBCHAR mtcdisputedamount[DISPUTEDAMOUNT + 1];
DBCHAR mtcnumberpaymentspastdue[NUMBERPAYMENTSPASTDUE + 1];
DBCHAR mtchighestdelinquencyperiod[HIGHESTDELINQUENCYPERIOD + 1];
DBCHAR mtcaccountindisputeflag[ACCOUNTINDISPUTEFLAG + 1];
DBCHAR mtcaddressmaintenanceactioncode[ADDRESSMAINTENANCEACTIONCODE + 1];
DBCHAR mtcinputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
DBCHAR mtcoutgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];




