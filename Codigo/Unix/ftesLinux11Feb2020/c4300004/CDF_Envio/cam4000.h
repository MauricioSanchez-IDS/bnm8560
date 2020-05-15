/*
**      EISSA Header
**      Propiedad de EISSA.
**      (c) Copyright EISSA. 2000.
**      All rights reserved.
**
**
** El uso, copiado, o distribución de este código esta sujeto a restricciones 
** y protegido por Technical Data and Computer Software para EISSA. 
** 
** Nombre: cam4000.h
** 
** Elaborado por : Ing. José Ramón González Díaz 
**
** Historial/Modificaciones
**
** 001 15/dic/2000 Creación de este header para el manejo de campos en 
** las variables de los programas para la elaboración del archivo CDF.  
**  para el registro 4000. 
*/


/**
  *		Declaracion de los formatos
   **/

#define EMPTYSTR "\0"
#define FRMN7 "%+07s"

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
#define CORPORATIONNAMELINE1 35
#define CORPORATIONNAMELINE2 35
#define ADDRESSLINE1 35
#define ADDRESSLINE2 35
#define CITY 20
#define STATEPROVINCE 3
#define COUNTRY 3
#define POSTALCODE 10
#define CURRENCYCODE 3
#define CONTACTPERSON 35
#define PHONENUMBER 25
#define FAXNUMBER 25
#define EMAILADDRESS 50
#define BUDGETLIMIT 16
#define CYCLEDATEINDICATOR 2
#define TOTALACCOUNTS 7
#define ACCOUNTSPASTDUE 7
#define ACCOUNTSWITHDISPUTE 7
#define NUMBEROFCARDS 7
#define CHARGEOFFSIGN 1
#define CHARGEOFFAMOUNT 16
#define PASTDUEAMOUNTSIGN 1
#define PASTDUEAMOUNT 16
#define DISPUTEAMOUNTSIGN 1
#define DISPUTEAMOUNT 16
#define CREDITLIMITSIGN 1
#define CREDITLIMIT 16
#define PAYMENTDUESIGN 1
#define PAYMENTDUE 16
#define OUTSTANDINGBALANCESIGN 1
#define OUTSTANDINGBALANCE 16
#define NUMBEROFDEBITS 10
#define NUMBEROFCREDITS 10
#define AMOUNTOFDEBITS 16
#define AMOUNTOFCREDITS 16
#define NUMBERACCOUNTSOVERLIMIT 7
#define PORTFOLIODATE 8
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
char corporationnameline1[CORPORATIONNAMELINE1 + 1];
char corporationnameline2[CORPORATIONNAMELINE2 + 1];
char addressline1[ADDRESSLINE1 + 1];
char addressline2[ADDRESSLINE2 + 1];
char city[CITY + 1];
char stateprovince[STATEPROVINCE + 1];
char country[COUNTRY + 1];
char postalcode[POSTALCODE + 1];
char currencycode[CURRENCYCODE + 1];
char contactperson[CONTACTPERSON + 1];
char phonenumber[PHONENUMBER + 1];
char faxnumber[FAXNUMBER + 1];
char emailaddress[EMAILADDRESS + 1];
char budgetlimit[BUDGETLIMIT + 1];
char cycledateindicator[CYCLEDATEINDICATOR + 1];
char totalaccounts[TOTALACCOUNTS + 1];
char accountspastdue[ACCOUNTSPASTDUE + 1];
char accountswithdispute[ACCOUNTSWITHDISPUTE + 1];
char numberofcards[NUMBEROFCARDS + 1];
char chargeoffsign[CHARGEOFFSIGN + 1];
char chargeoffamount[CHARGEOFFAMOUNT + 1];
char pastdueamountsign[PASTDUEAMOUNTSIGN + 1];
char pastdueamount[PASTDUEAMOUNT + 1];
char disputeamountsign[DISPUTEAMOUNTSIGN + 1];
char disputeamount[DISPUTEAMOUNT + 1];
char creditlimitsign[CREDITLIMITSIGN + 1];
char creditlimit[CREDITLIMIT + 1];
char paymentduesign[PAYMENTDUESIGN + 1];
char paymentdue[PAYMENTDUE + 1];
char outstandingbalancesign[OUTSTANDINGBALANCESIGN + 1];
char outstandingbalance[OUTSTANDINGBALANCE + 1];
char numberofdebits[NUMBEROFDEBITS + 1];
char numberofcredits[NUMBEROFCREDITS + 1];
char amountofdebits[AMOUNTOFDEBITS + 1];
char amountofcredits[AMOUNTOFCREDITS + 1];
char numberaccountsoverlimit[NUMBERACCOUNTSOVERLIMIT + 1];
char portfoliodate[PORTFOLIODATE + 1];
char addressmaintenanceactioncode[ ADDRESSMAINTENANCEACTIONCODE + 1 ];
char inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];

DBCHAR mtc4000recordidentifier[RECORDIDENTIFIER + 1];
DBCHAR mtc4000issuerica[ISSUERICA + 1];
DBCHAR mtc4000issuernumberica[ISSUERNUMBERICA + 1];
DBCHAR mtc4000corporationnumber[CORPORATIONNUMBER + 1];
DBCHAR mtc4000reservedforinternaluse1[RESERVEDFORINTERNALUSE1 + 1];
DBCHAR mtc4000reservedforinternaluse2[RESERVEDFORINTERNALUSE2 + 1];
DBCHAR mtc4000reservedforinternaluse3[RESERVEDFORINTERNALUSE3 + 1];
DBCHAR mtc4000corporationnameline1[CORPORATIONNAMELINE1 + 1];
DBCHAR mtc4000corporationnameline2[CORPORATIONNAMELINE2 + 1];
DBCHAR mtc4000addressline1[ADDRESSLINE1 + 1];
DBCHAR mtc4000addressline2[ADDRESSLINE2 + 1];
DBCHAR mtc4000city[CITY + 1];
DBCHAR mtc4000stateprovince[STATEPROVINCE + 1];
DBCHAR mtc4000country[COUNTRY + 1];
DBCHAR mtc4000postalcode[POSTALCODE + 1];
DBCHAR mtc4000currencycode[CURRENCYCODE + 1];
DBCHAR mtc4000contactperson[CONTACTPERSON + 1];
DBCHAR mtc4000phonenumber[PHONENUMBER + 1];
DBCHAR mtc4000faxnumber[FAXNUMBER + 1];
DBCHAR mtc4000emailaddress[EMAILADDRESS + 1];
DBCHAR mtc4000budgetlimit[BUDGETLIMIT + 1];
DBCHAR mtc4000cycledateindicator[CYCLEDATEINDICATOR + 1];
DBCHAR mtc4000totalaccounts[TOTALACCOUNTS + 1];
DBCHAR mtc4000accountspastdue[ACCOUNTSPASTDUE + 1];
DBCHAR mtc4000accountswithdispute[ACCOUNTSWITHDISPUTE + 1];
DBCHAR mtc4000numberofcards[NUMBEROFCARDS + 1];
DBCHAR mtc4000chargeoffsign[CHARGEOFFSIGN + 1];
DBCHAR mtc4000chargeoffamount[CHARGEOFFAMOUNT + 1];
DBCHAR mtc4000pastdueamountsign[PASTDUEAMOUNTSIGN + 1];
DBCHAR mtc4000pastdueamount[PASTDUEAMOUNT + 1];
DBCHAR mtc4000disputeamountsign[DISPUTEAMOUNTSIGN + 1];
DBCHAR mtc4000disputeamount[DISPUTEAMOUNT + 1];
DBCHAR mtc4000creditlimitsign[CREDITLIMITSIGN + 1];
DBCHAR mtc4000creditlimit[CREDITLIMIT + 1];
DBCHAR mtc4000paymentduesign[PAYMENTDUESIGN + 1];
DBCHAR mtc4000paymentdue[PAYMENTDUE + 1];
DBCHAR mtc4000outstandingbalancesign[OUTSTANDINGBALANCESIGN + 1];
DBCHAR mtc4000outstandingbalance[OUTSTANDINGBALANCE + 1];
DBCHAR mtc4000numberofdebits[NUMBEROFDEBITS + 1];
DBCHAR mtc4000numberofcredits[NUMBEROFCREDITS + 1];
DBCHAR mtc4000amountofdebits[AMOUNTOFDEBITS + 1];
DBCHAR mtc4000amountofcredits[AMOUNTOFCREDITS + 1];
DBCHAR mtc4000numberaccountsoverlimit[NUMBERACCOUNTSOVERLIMIT + 1];
DBCHAR mtc4000portfoliodate[PORTFOLIODATE + 1];
DBCHAR mtc4000addressmaintenanceactioncode[ADDRESSMAINTENANCEACTIONCODE + 1];
DBCHAR mtc4000inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
DBCHAR mtc4000outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];
