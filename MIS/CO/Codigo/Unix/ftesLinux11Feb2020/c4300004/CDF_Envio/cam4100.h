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
** Nombre: cam4100.h
** 
** Elaborado por : Ing. José Ramón González Díaz 
**
** Historial/Modificaciones
**
** 001 15/dic/2000 Creación de este header para el manejo de campos en 
** las variables de los programas para la elaboración del archivo CDF.  
**  para el registro 4100. 
*/
/**
  *		Declaracion de los formatos
   **/

#define EMPTYSTR "\0"

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
#define FRMN7 "%+07s"
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
#define ORGANIZATIONPOINTNUMBER 19
#define FREEFORMATTEXT 25
#define ORGANIZATIONPOINTNAMELINE1 35
#define ORGANIZATIONPOINTNAMELINE2 35
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
char organizationpointnumber[ORGANIZATIONPOINTNUMBER + 1];
char freeformattext[FREEFORMATTEXT + 1];
char organizationpointnameline1[ORGANIZATIONPOINTNAMELINE1 + 1];
char organizationpointnameline2[ORGANIZATIONPOINTNAMELINE2 + 1];
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
char totalaccounts[ TOTALACCOUNTS + 1];
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
char addressmaintenanceactioncode[ADDRESSMAINTENANCEACTIONCODE + 1];
char inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];

/*variables para contener al registro MTC4100*/

DBCHAR  mtc4100recordidentifier[RECORDIDENTIFIER                         + 1];
DBCHAR  mtc4100issuerica[ISSUERICA                                       + 1];
DBCHAR  mtc4100issuernumberica[ISSUERNUMBERICA                           + 1];
DBCHAR  mtc4100corporationnumber[CORPORATIONNUMBER                       + 1];
DBCHAR  mtc4100reservedforinternaluse1[RESERVEDFORINTERNALUSE1           + 1];
DBCHAR  mtc4100reservedforinternaluse2[RESERVEDFORINTERNALUSE2           + 1];
DBCHAR  mtc4100reservedforinternaluse3[RESERVEDFORINTERNALUSE3           + 1];
DBCHAR  mtc4100organizationpointnumber[ORGANIZATIONPOINTNUMBER           + 1];
DBCHAR  mtc4100freeformattext[FREEFORMATTEXT                             + 1];
DBCHAR  mtc4100organizationpointnameline1[ORGANIZATIONPOINTNAMELINE1     + 1];
DBCHAR  mtc4100organizationpointnameline2[ORGANIZATIONPOINTNAMELINE2     + 1];
DBCHAR  mtc4100addressline1[ADDRESSLINE1                                 + 1];
DBCHAR  mtc4100addressline2[ADDRESSLINE2                                 + 1];
DBCHAR  mtc4100city[CITY                                                 + 1];
DBCHAR  mtc4100stateprovince[STATEPROVINCE                               + 1];
DBCHAR  mtc4100country[COUNTRY                                           + 1];
DBCHAR  mtc4100postalcode[POSTALCODE                                     + 1];
DBCHAR  mtc4100currencycode[CURRENCYCODE                                 + 1];
DBCHAR  mtc4100contactperson[CONTACTPERSON                               + 1];
DBCHAR  mtc4100phonenumber[PHONENUMBER                                   + 1];
DBCHAR  mtc4100faxnumber[FAXNUMBER                                       + 1];
DBCHAR  mtc4100emailaddress[EMAILADDRESS                                 + 1];
DBCHAR  mtc4100budgetlimit[BUDGETLIMIT                                   + 1];
DBCHAR  mtc4100totalaccounts[TOTALACCOUNTS                               + 1];
DBCHAR  mtc4100accountspastdue[ACCOUNTSPASTDUE                           + 1];
DBCHAR  mtc4100accountswithdispute[ACCOUNTSWITHDISPUTE                   + 1];
DBCHAR  mtc4100numberofcards[NUMBEROFCARDS                               + 1];
DBCHAR  mtc4100chargeoffsign[CHARGEOFFSIGN                               + 1];
DBCHAR  mtc4100chargeoffamount[CHARGEOFFAMOUNT                           + 1];
DBCHAR  mtc4100pastdueamountsign[PASTDUEAMOUNTSIGN                       + 1];
DBCHAR  mtc4100pastdueamount[PASTDUEAMOUNT                               + 1];
DBCHAR  mtc4100disputeamountsign[DISPUTEAMOUNTSIGN                       + 1];
DBCHAR  mtc4100disputeamount[DISPUTEAMOUNT                               + 1];
DBCHAR  mtc4100creditlimitsign[CREDITLIMITSIGN                           + 1];
DBCHAR  mtc4100creditlimit[CREDITLIMIT                                   + 1];
DBCHAR  mtc4100paymentduesign[PAYMENTDUESIGN                             + 1];
DBCHAR  mtc4100paymentdue[PAYMENTDUE                                     + 1];
DBCHAR  mtc4100outstandingbalancesign[OUTSTANDINGBALANCESIGN             + 1];
DBCHAR  mtc4100outstandingbalance[OUTSTANDINGBALANCE                     + 1];
DBCHAR  mtc4100numberofdebits[NUMBEROFDEBITS                             + 1];
DBCHAR  mtc4100numberofcredits[NUMBEROFCREDITS                           + 1];
DBCHAR  mtc4100amountofdebits[AMOUNTOFDEBITS                             + 1];
DBCHAR  mtc4100amountofcredits[AMOUNTOFCREDITS                           + 1];
DBCHAR  mtc4100numberaccountsoverlimit[NUMBERACCOUNTSOVERLIMIT           + 1];
DBCHAR  mtc4100portfoliodate[PORTFOLIODATE                               + 1];
DBCHAR  mtc4100addressmaintenanceactioncode[ADDRESSMAINTENANCEACTIONCODE + 1];
DBCHAR  mtc4100inputfilerecordnumber[INPUTFILERECORDNUMBER               + 1];
DBCHAR  mtc4100outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE       + 1];


