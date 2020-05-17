/*Archivo genarchb.h 
  Donde declaramos las variables */
/* cadena para querys MUY grandes  */
#define CADENAQUERY 1024

/* definicion variables de uso general */
#define CADENAREG1000  187 
#define CADENAREG3000  398 
#define CADENAREG4000  614 
#define CADENAREG4100  655
#define CADENAREG4200  174
#define CADENAREG4300  732 
#define CADENAREG5000  538 
#define CADENAREG9999  89

/* definicion variables registro 1000  187 */
/*#define LARGOREG1000 181*/
#define RECID1000 4
#define ICANUMERO1000 11
#define ICANUMBANCO1000 11
#define RESERVEDFORINTERNALUSE11000 19
#define RESERVEDFORINTERNALUSE21000 3
#define RESERVEDFORINTERNALUSE31000 17
#define RESERVEDFORINTERNALUSE41000 6
#define REJECTIONLEVEL1000 1
#define PROVIDINGFROMDATE1000 17
#define PROVIDINGTODATE1000 17
#define RUNMODEINDICATOR1000 1
#define FILEREFERENCENUMBER1000 24
#define CUSTUMERPROCESSORNUMBER1000 5
#define CUSTUMERPROCESSORNAME1000 35
#define CDFVERSIONNUMBER1000 4
#define INFILERECNUM1000 6
#define OUTGOINGINCOMINGERRORCODE1000 6

/*  definicion variables registro 3000  398 */
/*#define LARGOREG3000 250    recordIdentifier-currency */
#define RECID3000 4
#define ICANUMERO3000 11
#define ICANUMBANCO3000 11
#define RESERVEDFORINTERNALUSE13000 19
#define RESERVEDFORINTERNALUSE23000 3
#define RESERVEDFORINTERNALUSE33000 17
#define RESERVEDFORINTERNALUSE43000 6
#define ISSUERNAMELINE13000 35
#define ISSUERNAMELINE23000 35
#define ADDRESSLINE13000 35
#define ADDRESSLINE23000 35
#define CITY3000 20
#define STATEPROVINCE3000 3
#define COUNTRY3000 3
#define POSTALCODE3000 10
#define CURRENCY3000 3

/*#define LARGOREG3000_2 142	contactPerson-inputFileRecordNumber*/
#define CONTACTPERSON3000 35
#define PHONENUMBER3000 25
#define FAXNUMBER3000 25
#define EMAILADDRESS3000 50
#define ADDRESSMAINTENANCEACTION3000 1
#define INFILERECNUM3000 6
#define OUTGOINGINCOMINGERRORCODE3000 6

/* definicion varaibles registro 4000 614 */
/*#define CAMPO4000_1 26   recordIdentifier - issuerNumberIca*/
#define RECID4000 4
#define ICANUMERO4000 11
#define ICANUMBANCO4000 11
#define CORPORATIONNUMBER4000 19

/*#define CAMPO4000_2 240		reservedForInternalUse1 - contactPerson*/
#define RESERVEDFORINTERNALUSE14000 3
#define RESERVEDFORINTERNALUSE24000 17
#define RESERVEDFORINTERNALUSE34000 6
#define CORPORATIONNAMELINE14000 35
#define CORPORATIONNAMELINE24000 35
#define ADDRESSLINE14000 35
#define ADDRESSLINE24000 35
#define CITY4000 20
#define STATEPROVINCE4000 3
#define COUNTRY4000 3
#define POSTALCODE4000 10
#define CURRENCY4000 3
#define CONTACTPERSON4000 35

/*#define CAMPO4000_3 248		phoneNumber - outstandingBalance*/
#define PHONENUMBER4000 25
#define FAXNUMBER4000 25
#define EMAILADDRESS4000 50
#define BUDGETLIMIT4000 16
#define CYCLEDATEINDICATOR4000 2
#define TOTALACCOUNTS4000 7
#define ACCOUNTSPASTDUE4000 7
#define ACCOUNTSWITHDISPUTE4000 7
#define NUMBEROFCARDS4000 7
#define CHARGEOFFSIGN4000 1
#define CHARGEOFFAMOUNT4000 16
#define PASTDUEAMOUNTSIGN4000 1
#define PASTDUEAMOUNT4000 16
#define DISPUTEAMOUNTSIGN4000 1
#define DISPUTEAMOUNT4000 16
#define CREDITLIMITSIGN4000 1
#define CREDITLIMIT4000 16
#define PAYMENTDUESIGN4000 1
#define PAYMENTDUE4000 16
#define OUTSTANDINGBALANCESIGN4000 1
#define OUTSTANDINGBALANCE4000 16

/*#define CAMPO4000_4 74		numberOfDebits - addressMaintenanceActionCode */
#define NUMBEROFDEBITS4000 10
#define NUMBEROFCREDITS4000 10
#define AMOUNTOFDEBITS4000 16
#define AMOUNTOFCREDITS4000 16
#define NUMBERACCOUNTSOVERLIMIT4000 7
#define PORTFOLIODATE4000 8
#define ADDRESSMAINTENANCEACTION4000 1
#define INFILERECNUM4000 6
#define OUTGOINGINCOMINGERRORCODE4000 6
#define INDJER4000 1 

/* definicion variables registro 4100  655*/
/*#define CAMPO4100_1 26		recordIdentifier - issuerNumberIca*/
#define RECID4100 4
#define ICANUMERO4100 11
#define ICANUMBANCO4100 11
#define CORPORATIONNUMBER4100 19

/*#define CAMPO4100_2 26		reservedForInternalUse1 - reservedForInternalUse3*/
#define RESERVEDFORINTERNALUSE14100 3
#define RESERVEDFORINTERNALUSE24100 17
#define RESERVEDFORINTERNALUSE34100 6
#define ORGANIZATIONPOINTNUMBER4100 19

/*#define CAMPO4100_3 204		freeFormatText - currencyCode*/
#define FREEFORMATTEXT4100 25
#define ORGANIZATIONPOINTNAMELINE14100 35
#define ORGANIZATIONPOINTNAMELINE24100 35
#define ADDRESSLINE14100 35
#define ADDRESSLINE24100 35
#define CITY4100 20
#define STATEPROVINCE4100 3
#define COUNTRY4100 3
#define POSTALCODE4100 10
#define CURRENCYCODE4100 3

/*#define CAMPO4100_4 231		contactPerson - creditLimitSign*/
#define CONTACTPERSON4100 35
#define PHONENUMBER4100 25
#define FAXNUMBER4100 25
#define EMAILADDRESS4100 50
#define BUDGETLIMIT4100 16
#define TOTALACCOUNTS4100 7
#define ACCOUNTSPASTDUE4100 7
#define ACCOUNTSWITHDISPUTE4100 7
#define NUMBEROFCARDS4100 7
#define CHARGEOFFSIGN4100 1
#define CHARGEOFFAMOUNT4100 16
#define PASTDUEAMOUNTSIGN4100 1
#define PASTDUEAMOUNT4100 16
#define DISPUTEAMOUNTSIGN4100 1
#define DISPUTEAMOUNT4100 16
#define CREDITLIMITSIGN4100 1

/*#define CAMPO4100_5 124		creditLimit - addressMaintenanceActionCode*/
#define CREDITLIMIT4100 16
#define PAYMENTDUESIGN4100 1
#define PAYMENTDUE4100 16
#define OUTSTANDINGBALANCESIGN4100 1
#define OUTSTANDINGBALANCE4100 16
#define NUMBEROFDEBITS4100 10
#define NUMBEROFCREDITS4100 10
#define AMOUNTOFDEBITS4100 16
#define AMOUNTOFCREDITS4100 16
#define NUMBERACCOUNTSOVERLIMIT4100 7
#define PORTFOLIODATE4100 8
#define ADDRESSMAINTENANCEACTION4100 1
#define INFILERECNUM4100 6
#define OUTGOING4100 6

/*  definicion variables registro 4200 174 */
/*#define CAMPO4200_1 71	recordIdentifier - reservedforInternalUse3*/
#define RECID4200 4
#define ICANUMERO4200 11
#define ICANUMBANCO4200 11
#define CORPORATIONNUMBER4200 19
#define RESERVEDFORINTERNALUSE14200 3
#define RESERVEDFORINTERNALUSE24200 17
#define RESERVEDFORINTERNALUSE34200 6
#define ORGANIZATIONPOINTNUMBER4200 19

/*#define CAMPO4200_2 78	freeFormatText - organizationHierarchyMainAct*/
#define FREEFORMATTEXT4200 25
#define REPORTSTO4200 19   
#define REPORTSTOFREEFORMATTEXT4200 25
#define RESERVEDFORINTERNALUSE44200 2
#define ORGANIZATIONHIERARCHYMAINACT4200 1
#define INFILERECNUM4200 6
#define OUTGOINGINCOMINGERRORCODE4200 6

/* definicion variables registro 4300  732*/
/*#define CAMPO4300_1 26 recordIdentifier - issuerNumberIca*/
#define RECID4300 4
#define ICANUMERO4300 11
#define ICANUMBANCO4300 11
#define CORPORATIONNUMBER4300 19

/*#define CAMPO4300_2 26	reservedForInternalUse1 - reservedForInternalUse3*/
#define RESERVEDFORINTERNALUSE14300 3
#define RESERVEDFORINTERNALUSE24300 17
#define RESERVEDFORINTERNALUSE34300 6
#define REPORTSTOORGPOINTNUMBER4300 19
#define REPORTSTOFREEFORMATTEXT4300 25
#define ACCOUNTNUMBER4300 19

/*#define CAMPO4300_3 241		corporateProduct - accountFaxNumber*/
#define CORPORATEPRODUCT4300 1
#define EFFECTIVEDATE4300 8
#define EXPIRATIONDATE4300 6
#define ACCOUNTNAMELINE14300 35
#define ACCOUNTNAMELINE24300 35
#define ACCOUNTADDRESSLINE14300 35
#define ACCOUNTADDRESSLINE24300 35
#define ACCOUNTCITY4300 20
#define ACCOUNTSTATEPROVINCE4300 3
#define ACCOUNTCOUNTRY4300 3
#define ACCOUNTPOSTALCODE4300 10
#define ACCOUNTPHONENUMBER4300 25
#define ACCOUNTFAXNUMBER4300 25

/*#define CAMPO4300_4 270		internalAuditCode - paymentDueBalance*/
#define INTERNALAUDITCODE4300 75
#define EMPLOYEEID4300 20
#define DAILYNUMBERLIMITOFTRANSACTIONS4300 8
#define SINGLETRANSACTIONDOLLARLIMIT4300 16
#define DAILYTRANSACTIONDOLLARLIMIT4300 16
#define CYCLENUMBEROFTRANSACTIONLIMIT4300 8
#define CYCLEDOLLARLIMIT4300 16
#define MONTHLYNUMLIMITOFTRAN4300 8
#define MONTHLYDOLLARLIMIT4300 16
#define OTHERNUMBEROFTRANSACTIONLIMIT4300 8
#define OTHERDOLLARLIMIT4300 16
#define TAXEXEMPTINDICATOR4300 1
#define CURRENCYCODE4300 3
#define STATEMENTDATE4300 8
#define PREVIOUSBALANCESIGN4300 1
#define PREVIOUSBALANCE4300 16
#define ENDINGBALANCESIGN4300 1
#define ENDINGBALANCE4300 16
#define PAYMENTDUESIGN4300 1
#define PAYMENTDUEBALANCE4300 16

/*#define CAMPO4300_5 81		creditLimitSign - addressMaintenanceActionCode*/
#define CREDITLIMITSIGN4300 1
#define CREDITLIMIT4300 16
#define PASTDUEAMOUNTSIGN4300 1
#define PASTDUEBALANCE4300 16
#define CHARGEOFFSIGN4300 1
#define CHARGEOFFAMOUNT4300 16
#define DISPUTEAMOUNTSIGN4300 1
#define DISPUTEAMOUNT4300 16
#define NUMBERPAYMENTSPASTDUE4300 3
#define HIGHESTDELINQUENCYPERIOD4300 2
#define ACCOUNTINDISPUTEFLAGS4300 1
#define ADDRESSMAINTENANCEACTIONCODE4300 1
#define INFILERECNUM4300 6
#define OUTGOING4300 6

/* definicion variables registro 5000 538*/
#define RECID5000 4
#define ICANUMERO5000 11
#define ICANUMBANCO5000 11
#define CORPORATIONNUMBER5000 19
#define ADDENDUMTYPE5000 3
#define RESERVADO15000 17
#define RESERVADO25000 6
#define MERCHANTACTTRANORIGININD5000 1
#define ACCOUNTNUMBER5000 19
#define RESERVEDFORINTERNALUSE35000 10
#define ACQUIRERSORISSUERSREFNUM5000 23
#define RECORDTYPE5000 1
#define TRANSACTIONTYPE5000 1
#define DEBITCREDITINDICATOR5000 1
#define TRANSACTIONAMOUNT5000 16
#define POSTINGDATE5000 8
#define TRANSACTIONDATE5000 8
#define PROCESSINGDATE5000 8
#define MERCHANTNAME5000 25
#define MERCHANTCITY5000 13
#define MERCHANTSTATEPROVINCE5000 3
#define MERCHANTCOUNTRY5000 3
#define MERCHANTCATEGORYCODE5000 4
#define AMOUNTINORIGINALCURRENCY5000 16
#define ORIGINALCURRENCYCODE5000 3
#define CURRCONVDATEJULIAN5000 5
#define POSTEDCURRENCYCODE5000 3
#define CONVERSIONRATE5000 50
#define CONVERSIONEXPONENT5000 1
#define ACQUIRINGICA5000 11
#define CUSTOMERCODE5000 17
#define SALESTAXAMOUNT5000 16
#define RESERVADO45000 1
#define RESERVADO55000 5
#define FREIGHTAMOUNT5000 16
#define DESTINATIONPOSTALCODE5000 10
#define MERCHANTTYPE5000 4
#define MERCHANTLOCATIONPOSTALCOD5000 10
#define DUTYAMOUNT5000 16
#define MERCHANTFEDERALTAXID5000 15
#define MERCHANTSTATEPROVINCECODE5000 3
#define SHIPFROMPOSTALCODE5000 10
#define ALTERNATETAXAMOUNT5000 16
#define DESTINATIONCOUNTRYCODE5000 3
#define MERCHANTREFERENCENUMBER5000 17
#define ALTERNATETAXINDICATOR5000 1
#define ALTERNATETAXIDENTIFIER5000 15
#define SALESTAXCOLLECTEDINDPOS5000 1
#define ADDENDUMDETAILINDICATOR5000 1
#define MERCHANTID5000 15
#define BANKNETREFERENCENUMBER5000 12
#define APPROVALCODE5000 6
#define ADJUSTMENTREASONCODE5000 5
#define ADJUSTMENTDESCRIPTION5000 40
#define MANTENIMIENTO5000 1
#define INFILERECNUM5000 6
#define OUTGOING5000 6
#define ORGANIZATIONPOINTNUMBER5000 19

/* definicion variables registro 9999   89*/
/*#define LARGOREG9999 83 		recordIdentifier - reservedForInternalUse4*/
#define RECID9999 4
#define ICANUMERO9999 11
#define ICANUMBANCO9999 11
#define RESERVEDFORINTERNALUSE19999 19
#define RESERVEDFORINTERNALUSE29999 3
#define RESERVEDFORINTERNALUSE39999 17
#define RESERVEDFORINTERNALUSE49999 6
#define NUMBEROFRECORDSINTHISFILE9999 6
#define INFILERECNUM9999 6
#define OUTGOINGINCOMINGERRORCODE9999 6

#define REF5000 23 
#define CONTADORSTR 4
#define CONTADORSTRPASO 255
#define NUMEROCUENTAVALIDA 19
#define NUMEROCORPORATIVOVALIDO 19
#define NUMEROEMPRESAVALIDA 19
/*#define CORPORATIVO 5*/
#define CORPORATIVO 11

/* Se define el tamano del nombre del archivo */
#define NOMBREARCHIVO 60

/* Se define la variable que contendra la informacion que se almacenara */
char buf1000[CADENAREG1000+1];
char buf3000[CADENAREG3000+1];
char buf4000[CADENAREG4000+1];
char buf4100[CADENAREG4100+1];
char buf4100bis[CADENAREG4100+1];
char buf4200[CADENAREG4200+1];
char buf4300[CADENAREG4300+1];
char buf5000[CADENAREG5000+1];
char buf5000bis[CADENAREG5000+1];
char buf9999[CADENAREG9999+1];

/* declaraciones de el manejo de errores  y manejo de mensajes. */
/*int CS_PUBLIC err_handler();
int CS_PUBLIC msg_handler();*/

int renglon4300;
int renglon5000;
int renglon4100;
int renglon4200;
int entrareg4300;
int entrareg5000;
int entrareg4200;
int entrareg4100;
char banderasigue[1+1];

char corporativo[CORPORATIVO+1];

/* variables globales para el manejo de los argumentos de fecha y hora y nombre del archivo a generar */ 
char fechayhora[20];
char nombrearchivo[60];
char sqlcmd[3000];

#define TOTALPARAMETROS 4 

  /* declaracion de variables */

  /* registro 1000 */
  /*DBCHAR largoreg1000[LARGOREG1000+1];*/

	DBCHAR recid1000[RECID1000+1];
	DBCHAR icanumero1000[ICANUMERO1000+1];
	DBCHAR icanumbanco1000[ICANUMBANCO1000+1];
	DBCHAR reservedforinternaluse11000[RESERVEDFORINTERNALUSE11000+1];
	DBCHAR reservedforinternaluse21000[RESERVEDFORINTERNALUSE21000+1];
	DBCHAR reservedforinternaluse31000[RESERVEDFORINTERNALUSE31000+1];
	DBCHAR reservedforinternaluse41000[RESERVEDFORINTERNALUSE41000+1];
	DBCHAR rejectionlevel1000[REJECTIONLEVEL1000+1];
	DBCHAR providingfromdate1000[PROVIDINGFROMDATE1000+1];
	DBCHAR providingtodate1000[PROVIDINGTODATE1000+1];
	DBCHAR runmodeindicator1000[RUNMODEINDICATOR1000+1];
	DBCHAR filereferencenumber1000[FILEREFERENCENUMBER1000+1];
	DBCHAR custumerprocessornumber1000[CUSTUMERPROCESSORNUMBER1000+1];
	DBCHAR custumerprocessorname1000[CUSTUMERPROCESSORNAME1000+1];
	DBCHAR cdfversionnumber1000[CDFVERSIONNUMBER1000+1];
	DBCHAR infilerecnum1000[INFILERECNUM1000+1];
    DBCHAR outgoingincomingerrorcode1000[OUTGOINGINCOMINGERRORCODE1000+1];
 
  /*  registro 3000  */
  /*DBCHAR largoreg3000[LARGOREG3000+1];*/
	DBCHAR recid3000[RECID3000+1];
	DBCHAR icanumero3000[ICANUMERO3000+1];
	DBCHAR icanumbanco3000[ICANUMBANCO3000+1];
	DBCHAR reservedforinternaluse13000[RESERVEDFORINTERNALUSE13000+1];
	DBCHAR reservedforinternaluse23000[RESERVEDFORINTERNALUSE23000+1];
	DBCHAR reservedforinternaluse33000[RESERVEDFORINTERNALUSE33000+1];
	DBCHAR reservedforinternaluse43000[RESERVEDFORINTERNALUSE43000+1];
	DBCHAR issuernameline13000[ISSUERNAMELINE13000+1];
	DBCHAR issuernameline23000[ISSUERNAMELINE23000+1];
	DBCHAR addressline13000[ADDRESSLINE13000+1];
	DBCHAR addressline23000[ADDRESSLINE23000+1];
	DBCHAR city3000[CITY3000+1];
	DBCHAR stateprovince3000[STATEPROVINCE3000+1];
	DBCHAR country3000[COUNTRY3000+1];
	DBCHAR postalcode3000[POSTALCODE3000+1];
	DBCHAR currency3000[CURRENCY3000+1];
	/*DBCHAR largoreg3000_2[LARGOREG3000_2+1];*/
	DBCHAR contactperson3000[CONTACTPERSON3000+1];
	DBCHAR phonenumber3000[PHONENUMBER3000+1];
	DBCHAR faxnumber3000[FAXNUMBER3000+1];
	DBCHAR emailaddress3000[EMAILADDRESS3000+1];
	DBCHAR addressmaintenanceaction3000[ADDRESSMAINTENANCEACTION3000+1];
	DBCHAR infilerecnum3000[INFILERECNUM3000+1];
	DBCHAR outgoingincomingerrorcode3000[OUTGOINGINCOMINGERRORCODE3000+1];

  /* registro 4000  */
	/*DBCHAR campo4000_1[CAMPO4000_1+1];*/
	DBCHAR recid4000[RECID4000+1];
	DBCHAR icanumero4000[ICANUMERO4000+1];
	DBCHAR icanumbanco4000[ICANUMBANCO4000+1];
	DBCHAR corporationnumber4000[CORPORATIONNUMBER4000+1];
	/*DBCHAR campo4000_2[CAMPO4000_2+1];*/
	DBCHAR reservedforinternaluse14000[RESERVEDFORINTERNALUSE14000+1];
	DBCHAR reservedforinternaluse24000[RESERVEDFORINTERNALUSE24000+1];
	DBCHAR reservedforinternaluse34000[RESERVEDFORINTERNALUSE34000+1];
	DBCHAR corporationnameline14000[CORPORATIONNAMELINE14000+1];
	DBCHAR corporationnameline24000[CORPORATIONNAMELINE24000+1];
	DBCHAR addressline14000[ADDRESSLINE14000+1];
	DBCHAR addressline24000[ADDRESSLINE24000+1];
	DBCHAR city4000[CITY4000+1];
	DBCHAR stateprovince4000[STATEPROVINCE4000+1];
	DBCHAR country4000[COUNTRY4000+1];
	DBCHAR postalcode4000[POSTALCODE4000+1];
	DBCHAR currency4000[CURRENCY4000+1];
	DBCHAR contactperson4000[CONTACTPERSON4000+1];
	/*DBCHAR campo4000_3[CAMPO4000_3+1];*/
	DBCHAR phonenumber4000[PHONENUMBER4000+1];
	DBCHAR faxnumber4000[FAXNUMBER4000+1];
	DBCHAR emailaddress4000[EMAILADDRESS4000+1];
	DBCHAR budgetlimit4000[BUDGETLIMIT4000+1];
	DBCHAR cycledateindicator4000[CYCLEDATEINDICATOR4000+1];
	DBCHAR totalaccounts4000[TOTALACCOUNTS4000+1];
	DBCHAR accountspastdue4000[ACCOUNTSPASTDUE4000+1];
	DBCHAR accountswithdispute4000[ACCOUNTSWITHDISPUTE4000+1];
	DBCHAR nuumberofcards4000[NUMBEROFCARDS4000+1];
	DBCHAR chargeoffsign4000[CHARGEOFFSIGN4000+1];
	DBCHAR chargeoffamount4000[CHARGEOFFAMOUNT4000+1];
	DBCHAR pastdueamountsign4000[PASTDUEAMOUNTSIGN4000+1];
	DBCHAR pastdueamount4000[PASTDUEAMOUNT4000+1];
	DBCHAR disputeamountsign4000[DISPUTEAMOUNTSIGN4000+1];
	DBCHAR disputeamount4000[DISPUTEAMOUNT4000+1];
	DBCHAR creditlimitsign4000[CREDITLIMITSIGN4000+1];
	DBCHAR creditlimit4000[CREDITLIMIT4000+1];
	DBCHAR paymentduesign4000[PAYMENTDUESIGN4000+1];
	DBCHAR paymentdue4000[PAYMENTDUE4000+1];
	DBCHAR outstandingbalancesign4000[OUTSTANDINGBALANCESIGN4000+1];
	DBCHAR outstandingbalance4000[OUTSTANDINGBALANCE4000+1];
	/*DBCHAR campo4000_4[CAMPO4000_4+1];*/
	DBCHAR numberofdebits4000[NUMBEROFDEBITS4000+1];
	DBCHAR numberofcredits4000[NUMBEROFCREDITS4000+1];
	DBCHAR amountofdebits4000[AMOUNTOFDEBITS4000+1];
	DBCHAR amountofcredits4000[AMOUNTOFCREDITS4000+1];
	DBCHAR numberaccountsoverlimit4000[NUMBERACCOUNTSOVERLIMIT4000+1];
	DBCHAR portfoliodate4000[PORTFOLIODATE4000+1];
	DBCHAR addressmaintenanceaction4000[ADDRESSMAINTENANCEACTION4000+1];
	DBCHAR infilerecnum4000[INFILERECNUM4000+1];
	DBCHAR outgoingincomingerrorcode4000[OUTGOINGINCOMINGERRORCODE4000+1];
	DBCHAR jerarquia4000[INDJER4000+1];

  /* registro 4100  */
	/*DBCHAR campo4100_1[CAMPO4100_1+1];*/
	DBCHAR recid4100[RECID4100+1];
	DBCHAR icanumero4100[ICANUMERO4100+1];
	DBCHAR icanumbanco4100[ICANUMBANCO4100+1];
	DBCHAR corporationnumber4100[CORPORATIONNUMBER4100+1];
	/*DBCHAR campo4100_2[CAMPO4100_2+1];*/
	DBCHAR reservedforinternaluse14100[RESERVEDFORINTERNALUSE14100+1];
	DBCHAR reservedforinternaluse24100[RESERVEDFORINTERNALUSE24100+1];
	DBCHAR reservedforinternaluse34100[RESERVEDFORINTERNALUSE34100+1];
	DBCHAR organizationpointnumber4100[ORGANIZATIONPOINTNUMBER4100+1];
	/*DBCHAR campo4100_3[CAMPO4100_3+1];*/
	DBCHAR freeformattext4100[FREEFORMATTEXT4100+1];
	DBCHAR organizationpointnameline14100[ORGANIZATIONPOINTNAMELINE14100+1];
	DBCHAR organizationpointnameline24100[ORGANIZATIONPOINTNAMELINE24100+1];
	DBCHAR addressline14100[ADDRESSLINE14100+1];
	DBCHAR addressline24100[ADDRESSLINE24100+1];
	DBCHAR city4100[CITY4100+1];
	DBCHAR stateprovince4100[STATEPROVINCE4100+1];
	DBCHAR country4100[COUNTRY4100+1];
	DBCHAR postalcode4100[POSTALCODE4100+1];
	DBCHAR currencycode4100[CURRENCYCODE4100+1];
	/*DBCHAR campo4100_4[CAMPO4100_4+1];*/
	DBCHAR contactperson4100[CONTACTPERSON4100+1];
	DBCHAR phonenumber4100[PHONENUMBER4100+1];
	DBCHAR faxnumber4100[FAXNUMBER4100+1];
	DBCHAR emailaddress4100[EMAILADDRESS4100+1];
	DBCHAR budgetlimit4100[BUDGETLIMIT4100+1];
	DBCHAR totalaccounts4100[TOTALACCOUNTS4100+1];
	DBCHAR accountspastdue4100[ACCOUNTSPASTDUE4100+1];
	DBCHAR accountswithdispute4100[ACCOUNTSWITHDISPUTE4100+1];
	DBCHAR numberofcards4100[NUMBEROFCARDS4100+1];
	DBCHAR chargeoffsign4100[CHARGEOFFSIGN4100+1];
	DBCHAR chargeoffamount4100[CHARGEOFFAMOUNT4100+1];
	DBCHAR pastdueamountsign4100[PASTDUEAMOUNTSIGN4100+1];
	DBCHAR pastdueamount4100[PASTDUEAMOUNT4100+1];
	DBCHAR disputeamountsign4100[DISPUTEAMOUNTSIGN4100+1];
	DBCHAR disputeamount4100[DISPUTEAMOUNT4100+1];
	DBCHAR creditlimitsign4100[CREDITLIMITSIGN4100+1];
	/*DBCHAR campo4100_5[CAMPO4100_5+1];*/
	DBCHAR creditlimit4100[CREDITLIMIT4100+1];
	DBCHAR paymentduesign4100[PAYMENTDUESIGN4100+1];
	DBCHAR paymentdue4100[PAYMENTDUE4100+1];
	DBCHAR outstandingbalancesign4100[OUTSTANDINGBALANCESIGN4100+1];
	DBCHAR outstandingbalance4100[OUTSTANDINGBALANCE4100+1];
	DBCHAR numberofdebits4100[NUMBEROFDEBITS4100+1];
	DBCHAR numberofcredits4100[NUMBEROFCREDITS4100+1];
	DBCHAR amountofdebits4100[AMOUNTOFDEBITS4100+1];
	DBCHAR amountofcredits4100[AMOUNTOFCREDITS4100+1];
	DBCHAR numberaccountsoverlimit4100[NUMBERACCOUNTSOVERLIMIT4100+1];
	DBCHAR portfoliodate4100[PORTFOLIODATE4100+1];
	DBCHAR addressmaintenanceaction4100[ADDRESSMAINTENANCEACTION4100+1];
	DBCHAR infilerecnum4100[INFILERECNUM4100+1];
	DBCHAR outgoing4100[OUTGOING4100+1];

  /*  registro 4200  */
  /*DBCHAR campo4200_1[CAMPO4200_1];*/
	DBCHAR recid4200[RECID4200+1];
	DBCHAR icanumero4200[ICANUMERO4200+1];
	DBCHAR icanumbanco4200[ICANUMBANCO4200+1];
	DBCHAR corporationnumber4200[CORPORATIONNUMBER4200+1];
	DBCHAR reservedforinternaluse14200[RESERVEDFORINTERNALUSE14200+1];
	DBCHAR reservedforinternaluse24200[RESERVEDFORINTERNALUSE24200+1];
	DBCHAR reservedforinternaluse34200[RESERVEDFORINTERNALUSE34200+1];
	DBCHAR organizationPointNumber4200[ORGANIZATIONPOINTNUMBER4200+1];
	DBCHAR reportsTo4200[REPORTSTO4200+1];
  /*DBCHAR campo4200_2[CAMPO4200_2];*/
	DBCHAR freeformattext4200[FREEFORMATTEXT4200+1];
	DBCHAR reportstofreeformattext4200[REPORTSTOFREEFORMATTEXT4200+1];
	DBCHAR reservedforinternaluse44200[RESERVEDFORINTERNALUSE44200+1];
	DBCHAR organizationhierarchymainact4200[ORGANIZATIONHIERARCHYMAINACT4200+1];
	DBCHAR infilerecnum4200[INFILERECNUM4200+1];
    DBCHAR outgoingIncomingErrorCode4200[OUTGOINGINCOMINGERRORCODE4200+1];

  /*  registro 4300 */
  /*DBCHAR campo4300_1 [CAMPO4300_1+1];*/

	DBCHAR recid4300[RECID4300+1];
	DBCHAR icanumero4300[ICANUMERO4300+1];
	DBCHAR icanumbanco4300[ICANUMBANCO4300+1];
	DBCHAR corporationnumber4300 [CORPORATIONNUMBER4300+1];
	/*DBCHAR campo4300_2 [CAMPO4300_2+1];*/
	DBCHAR reservedforinternaluse14300[RESERVEDFORINTERNALUSE14300+1];
	DBCHAR reservedforinternaluse24300[RESERVEDFORINTERNALUSE24300+1];
	DBCHAR reservedforinternaluse34300[RESERVEDFORINTERNALUSE34300+1];
	DBCHAR reportstoorgpointnumber4300[REPORTSTOORGPOINTNUMBER4300+1];
	DBCHAR reportstofreeformattext4300[REPORTSTOFREEFORMATTEXT4300+1];
	DBCHAR accountnumber4300[ACCOUNTNUMBER4300+1];
	/*DBCHAR campo4300_3 [CAMPO4300_3+1];*/
	DBCHAR corporateproduct4300[CORPORATEPRODUCT4300+1];
	DBCHAR effectivedate4300[EFFECTIVEDATE4300+1];
	DBCHAR expirationdate4300[EXPIRATIONDATE4300+1];
	DBCHAR accountnameline14300[ACCOUNTNAMELINE14300+1];
	DBCHAR accountnameline24300[ACCOUNTNAMELINE24300+1];
	DBCHAR accountaddressline14300[ACCOUNTADDRESSLINE14300+1];
	DBCHAR accountaddressline24300[ACCOUNTADDRESSLINE24300+1];
	DBCHAR accountcity4300[ACCOUNTCITY4300+1];
	DBCHAR accountstateprovince4300[ACCOUNTSTATEPROVINCE4300+1];
	DBCHAR accountcountry4300[ACCOUNTCOUNTRY4300+1];
	DBCHAR accountpostalcode4300[ACCOUNTPOSTALCODE4300+1];
	DBCHAR accountphonenumber4300[ACCOUNTPHONENUMBER4300+1];
	DBCHAR accountfaxnumber4300[ACCOUNTFAXNUMBER4300+1];
	/*DBCHAR campo4300_4 [CAMPO4300_4+1];*/
	DBCHAR internalauditcode4300[INTERNALAUDITCODE4300+1];
	DBCHAR employeeid4300[EMPLOYEEID4300+1];
	DBCHAR dailynumberlimitoftransactions4300[DAILYNUMBERLIMITOFTRANSACTIONS4300+1];
	DBCHAR singletransactiondollarlimit4300[SINGLETRANSACTIONDOLLARLIMIT4300+1];
	DBCHAR dailytransactiondollarlimit4300[DAILYTRANSACTIONDOLLARLIMIT4300+1];
	DBCHAR cyclenumberoftransactionlimit4300[CYCLENUMBEROFTRANSACTIONLIMIT4300+1];
	DBCHAR cycledollarlimit4300[CYCLEDOLLARLIMIT4300+1];
	DBCHAR monthlynumlimitoftran4300[MONTHLYNUMLIMITOFTRAN4300+1];
	DBCHAR monthlydollarlimit4300[MONTHLYDOLLARLIMIT4300+1];
	DBCHAR othernumberoftransactionlimit4300[OTHERNUMBEROFTRANSACTIONLIMIT4300+1];
	DBCHAR otherdollarlimit4300[OTHERDOLLARLIMIT4300+1];
	DBCHAR taxexemptindicator4300[TAXEXEMPTINDICATOR4300+1];
	DBCHAR currencycode4300[CURRENCYCODE4300+1];
	DBCHAR statementdate4300[STATEMENTDATE4300+1];
	DBCHAR previousbalancesign4300[PREVIOUSBALANCESIGN4300+1];
	DBCHAR previousbalance4300[PREVIOUSBALANCE4300+1];
	DBCHAR endingbalancesign4300[ENDINGBALANCESIGN4300+1];
	DBCHAR endingbalance4300[ENDINGBALANCE4300+1];
	DBCHAR paymentduesign4300[PAYMENTDUESIGN4300+1];
	DBCHAR paymentduebalance4300[PAYMENTDUEBALANCE4300+1];
  /*DBCHAR campo4300_5 [CAMPO4300_5+1];*/
	DBCHAR creditlimitsign4300[CREDITLIMITSIGN4300+1];
	DBCHAR creditlimit4300[CREDITLIMIT4300+1];
	DBCHAR pastdueamountsign4300[PASTDUEAMOUNTSIGN4300+1];
	DBCHAR pastduebalance4300[PASTDUEBALANCE4300+1];
	DBCHAR chargeoffsign4300[CHARGEOFFSIGN4300+1];
	DBCHAR chargeoffamount4300[CHARGEOFFAMOUNT4300+1];
	DBCHAR disputeamountsign4300[DISPUTEAMOUNTSIGN4300+1];
	DBCHAR disputeamount4300[DISPUTEAMOUNT4300+1];
	DBCHAR numberpaymentspastdue4300[NUMBERPAYMENTSPASTDUE4300+1];
	DBCHAR highestdelinquencyperiod4300[HIGHESTDELINQUENCYPERIOD4300+1];
	DBCHAR accountindisputeflags4300[ACCOUNTINDISPUTEFLAGS4300+1];
	DBCHAR addressmaintenanceactioncode4300[ADDRESSMAINTENANCEACTIONCODE4300+1];
	DBCHAR infilerecnum4300[INFILERECNUM4300+1];
    DBCHAR outgoing4300 [OUTGOING4300+1];

  /* registro 5000  */
	DBCHAR recid5000[RECID5000+1];
	DBCHAR icanumero5000[ICANUMERO5000+1];
	DBCHAR icanumbanco5000[ICANUMBANCO5000+1];
	DBCHAR corporationnumber5000[CORPORATIONNUMBER5000+1];
	DBCHAR addendumtype5000[ADDENDUMTYPE5000+1];
	DBCHAR reservado15000[RESERVADO15000+1];
	DBCHAR reservado25000[RESERVADO25000+1];
	DBCHAR merchantacttranoriginind5000[MERCHANTACTTRANORIGININD5000+1];
	DBCHAR accountnumber5000[ACCOUNTNUMBER5000+1];
	DBCHAR reservedforinternaluse35000[RESERVEDFORINTERNALUSE35000+1];
	DBCHAR acquirersorissuersrefnum5000[ACQUIRERSORISSUERSREFNUM5000+1];
	DBCHAR recordtype5000[RECORDTYPE5000+1];
	DBCHAR transactiontype5000[TRANSACTIONTYPE5000+1];
	DBCHAR debitcreditindicator5000[DEBITCREDITINDICATOR5000+1];
	DBCHAR transactionamount5000[TRANSACTIONAMOUNT5000+1];
	DBCHAR postingdate5000[POSTINGDATE5000+1];
	DBCHAR transactiondate5000[TRANSACTIONDATE5000+1];
	DBCHAR processingdate5000[PROCESSINGDATE5000+1];
	DBCHAR merchantname5000[MERCHANTNAME5000+1];
	DBCHAR merchantcity5000[MERCHANTCITY5000+1];
	DBCHAR merchantstateprovince5000[MERCHANTSTATEPROVINCE5000+1];
	DBCHAR merchantcountry5000[MERCHANTCOUNTRY5000+1];
	DBCHAR merchantcategorycode5000[MERCHANTCATEGORYCODE5000+1];
	DBCHAR amountinoriginalcurrency5000[AMOUNTINORIGINALCURRENCY5000+1];
	DBCHAR originalcurrencycode5000[ORIGINALCURRENCYCODE5000+1];
	DBCHAR currconvdatejulian5000[CURRCONVDATEJULIAN5000+1];
	DBCHAR postedcurrencycode5000[POSTEDCURRENCYCODE5000+1];
	DBCHAR conversionrate5000[CONVERSIONRATE5000+1];
	DBCHAR conversionexponent5000[CONVERSIONEXPONENT5000+1];
	DBCHAR acquiringica5000[ACQUIRINGICA5000+1];
	DBCHAR customercode5000[CUSTOMERCODE5000+1];
	DBCHAR salestaxamount5000[SALESTAXAMOUNT5000+1];
	DBCHAR reservado45000[RESERVADO45000+1];
	DBCHAR reservado55000[RESERVADO55000+1];
	DBCHAR freightamount5000[FREIGHTAMOUNT5000+1];
	DBCHAR destinationpostalcode5000[DESTINATIONPOSTALCODE5000+1];
	DBCHAR merchanttype5000[MERCHANTTYPE5000+1];
	DBCHAR merchantlocationpostalcod5000[MERCHANTLOCATIONPOSTALCOD5000+1];
	DBCHAR dutyamount5000[DUTYAMOUNT5000+1];
	DBCHAR merchantfederaltaxid5000[MERCHANTFEDERALTAXID5000+1];
	DBCHAR merchantstateprovincecode5000[MERCHANTSTATEPROVINCECODE5000+1];
	DBCHAR shipfrompostalcode5000[SHIPFROMPOSTALCODE5000+1];
	DBCHAR alternatetaxamount5000[ALTERNATETAXAMOUNT5000+1];
	DBCHAR destinationcountrycode5000[DESTINATIONCOUNTRYCODE5000+1];
	DBCHAR merchantreferencenumber5000[MERCHANTREFERENCENUMBER5000+1];
	DBCHAR alternatetaxindicator5000[ALTERNATETAXINDICATOR5000+1];
	DBCHAR alternatetaxidentifier5000[ALTERNATETAXIDENTIFIER5000+1];
	DBCHAR salestaxcollectedindpos5000[SALESTAXCOLLECTEDINDPOS5000+1];
	DBCHAR addendumdetailindicator5000[ADDENDUMDETAILINDICATOR5000+1];
	DBCHAR merchantid5000[MERCHANTID5000+1];
	DBCHAR banknetreferencenumber5000[BANKNETREFERENCENUMBER5000+1];
	DBCHAR approvalcode5000[APPROVALCODE5000+1];
	DBCHAR adjustmentreasoncode5000[ADJUSTMENTREASONCODE5000+1];
	DBCHAR adjustmentdescription5000[ADJUSTMENTDESCRIPTION5000+1];
	DBCHAR mantenimiento5000[MANTENIMIENTO5000+1];
	DBCHAR infilerecnum5000[INFILERECNUM5000+1];
	DBCHAR outgoing5000[OUTGOING5000+1];
	DBCHAR organizationPointNumber5000[ORGANIZATIONPOINTNUMBER5000+1];
  

  /* registro 9999 */
  /*DBCHAR largoreg9999 [LARGOREG9999];*/
	DBCHAR recid9999[RECID9999+1];
	DBCHAR icanumero9999[ICANUMERO9999+1];
	DBCHAR icanumbanco9999[ICANUMBANCO9999+1];
	DBCHAR reservedforinternaluse19999[RESERVEDFORINTERNALUSE19999+1];
	DBCHAR reservedforinternaluse29999[RESERVEDFORINTERNALUSE29999+1];
	DBCHAR reservedforinternaluse39999[RESERVEDFORINTERNALUSE39999+1];
	DBCHAR reservedforinternaluse49999[RESERVEDFORINTERNALUSE49999+1];
	DBCHAR numberofrecordsinthisfile9999[NUMBEROFRECORDSINTHISFILE9999+1];
	DBCHAR infilerecnum9999[INFILERECNUM9999+1];
	DBCHAR outgoingincomingerrorcode9999[OUTGOINGINCOMINGERRORCODE9999+1];

  /* variable para cachar el resultado de la ejecuacion del sql */
  RETCODE result_code; 
  RETCODE result_codes;

  /*campo contador para numero de registro */
  int contador;

  /*campo contadorstrin  para numero de registro */
  char contadorstr[CONTADORSTR+1];

  /* campo contador str para numero de registro */
  char contadorstrpaso[CONTADORSTRPASO+1];

  /* campo para retener el num. de cuenta para seleccionar reg. 5000 */
  char numerocuentavalida[NUMEROCUENTAVALIDA+1];

  /* campo para retener el num. de corporativo para seleccionar reg. 5000 */
  char numerocorporativovalido[NUMEROCORPORATIVOVALIDO+1];

  /* campo para retener el num. de empresa para seleccionar reg. 5000 */
  char numeroempresavalida[NUMEROEMPRESAVALIDA+1];

  /* variables para concatenado de las cadenas */
  char cadenareg1000[CADENAREG1000+1]; 
  char cadenareg3000[CADENAREG3000+1]; 
  char cadenareg4000[CADENAREG4000+1]; 
  char cadenareg4100[CADENAREG4100+1];
  char cadenareg4100bis[CADENAREG4100+1];
  char cadenareg4200[CADENAREG4200+1];
  char cadenareg4300[CADENAREG4300+1]; 
  char cadenareg5000[CADENAREG5000+1]; 
  char cadenareg5000bis[CADENAREG5000+1];
  char cadenareg9999[CADENAREG9999+1]; 
  char cadenaquery[CADENAQUERY+1];
 
  char archivo_direccion[60];                        
 
  char ge_user[10];
  char ge_password[10];
  char ge_server[10];
  char ge_hostname[10];
  char ge_dbase[10];

  int seguir4100;
  int seguir4200;
  int seguir4300;
  int seguir5000;

  char query[10000];
