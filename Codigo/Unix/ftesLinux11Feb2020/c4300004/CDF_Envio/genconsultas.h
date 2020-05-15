#include <sybdb.h>
#include <sybfront.h>

char *DevQry(Query)
int  Query;
{
		char Consulta[10000];
		char *p_Consulta;
		strcpy(Consulta,"");
		switch(Query)
		{
			  case 10:
					strcat(Consulta, "select recordIdentifier, issuerIca,  issuerNumberIca,");
					strcat(Consulta, " reservedForInternalUse1, reservedForInternalUse2,"); 
					strcat(Consulta, " reservedForInternalUse3, reservedForInternalUse4,"); 
					strcat(Consulta, " rejectionLevel, providingFromDate, providingToDate,");
					strcat(Consulta, " runModeIndicator, fileReferenceNumber,");
					strcat(Consulta, " custumerProcessorNumber, custumerProcessorName,"); 
					strcat(Consulta, " cdfVersionNumber, outgoingIncomingErrorCode");
					strcat(Consulta, " from REG1000");

/*          printf("\n 1000:  %s \n ",Consulta);*/

					break;
			  case 30: 
					strcat(Consulta," select recordIdentifier, issuerIca, issuerNumberIca, ");
					strcat(Consulta, "reservedForInternalUse1, reservedForInternalUse2, ");
					strcat(Consulta, "reservedForInternalUse3, reservedForInternalUse4, ");
					strcat(Consulta, "issuerNameLine1, issuerNameLine2,addressLine1, ");
					strcat(Consulta, "addressLine2, city, stateProvince,country, ");
					strcat(Consulta, "postalCode, currency, contactPerson,phoneNumber, "); 
					strcat(Consulta, "faxNumber, emailAddress, addressMaintenanceAction, ");
					strcat(Consulta, "outgoingIncomingErrorCode ");
					strcat(Consulta, "from REG3000");

/*          printf("\n 3000:  %s \n ",Consulta);*/

					break;
			  case 40:
					strcat(Consulta, "select distinct a.recordIdentifier, a.issuerIca, a.issuerNumberIca, a.corporationNumber, ");
					strcat(Consulta, "a.reservedForInternalUse1, a.reservedForInternalUse2, a.reservedForInternalUse3, ");
					strcat(Consulta, "a.corporationNameLine1, a.corporationNameLine2, a.addressLine1, a.addressLine2, ");
					strcat(Consulta, "a.city, a.stateProvince, a.country, a.postalCode, a.currencyCode, a.contactPerson, ");
					strcat(Consulta, "a.phoneNumber, a.faxNumber, a.emailAddress, a.budgetLimit, a.cycleDateIndicator, ");
					strcat(Consulta, "a.totalAccounts, a.accountsPastDue, a.accountsWithDispute, a.numberOfCards,  ");
					strcat(Consulta, "a.chargeOffSign, a.chargeOffAmount, a.pastDueAmountSign, a.pastDueAmount,  ");
					strcat(Consulta, "a.disputeAmountSign, a.disputeAmount, a.creditLimitSign, a.creditLimit,  ");
					strcat(Consulta, "a.paymentDueSign, a.paymentDue, a.outstandingBalanceSign, a.outstandingBalance, "); 
					strcat(Consulta, "a.numberOfDebits, a.numberOfCredits, a.amountOfDebits, a.amountOfCredits,  ");
					strcat(Consulta, "a.numberAccountsOverLimit, a.portfolioDate, a.addressMaintenanceActionCode, ");
					strcat(Consulta, "a.outgoingIncomingErrorCode, a.indJer,  ");
					strcat(Consulta, "prueba = case when b.corporationNumber = null "); 
					strcat(Consulta, "then 9999999999999999 else convert(numeric(19,0), ");
					strcat(Consulta, "b.corporationNumber) end ");
					strcat(Consulta, "from REG4000 a, REG4200 b ");
					strcat(Consulta, "where a.corporationNumber*=b.corporationNumber order by "); 
					strcat(Consulta, "prueba,  ");
					strcat(Consulta, "convert(numeric(19,0),b.corporationNumber) ");

  /*        printf("\n 4000:  %s \n ",Consulta);*/

					break;
			  case 41:
					strcat(Consulta, " select distinct a.recordIdentifier, a.issuerIca, a.issuerNumberIca, ");
					strcat(Consulta, " a.corporationNumber, a.reservedForInternalUse1, ");
					strcat(Consulta, " a.reservedForInternalUse2, a.reservedForInternalUse3, ");
					strcat(Consulta, " a.organizationPointNumber, a.freeFormatText, ");
					strcat(Consulta, " a.organizationPointNameLine1, a.organizationPointNameLine2, ");
					strcat(Consulta, " a.addressLine1, a.addressLine2, a.city, a.stateProvince, ");
					strcat(Consulta, " a.country, a.postalCode, a.currencyCode, a.contactPerson, ");
					strcat(Consulta, " a.phoneNumber, a.faxNumber, a.eMailAddress, a.budgetLimit, ");
					strcat(Consulta, " a.totalAccounts, a.accountsPastDue, a.accountsWithDispute, ");
					strcat(Consulta, " a.numberOfCards, a.chargeOffSign, a.chargeOffAmount, ");
					strcat(Consulta, " a.pastDueAmountSign, a.pastDueAmount, a.disputeAmountSign, ");
					strcat(Consulta, " a.disputeAmount, a.creditLimitSign, a.creditLimit, ");
					strcat(Consulta, " a.paymentDueSign, a.paymentDue, a.outstandingBalanceSign, ");
					strcat(Consulta, " a.outstandingBalance, a.numberOfDebits, a.numberOfCredits, ");
					strcat(Consulta, " a.amountOfDebits, a.amountOfCredits, ");
					strcat(Consulta, " a.numberAccountsOverLimit, a.portfolioDate, ");
					strcat(Consulta, " a.addressMaintenanceActionCode, ");
					strcat(Consulta, " a.outgoingIncomingErrorCode, ");
					strcat(Consulta, " prueba = case when b.corporationNumber = null then 9999999999999999 else convert(numeric(19,0),b.corporationNumber) end,  ");
					strcat(Consulta, " b.organizationPointNumber, ");
					strcat(Consulta, " b.reportsTo  ");
					strcat(Consulta, " from REG4100 a, REG4200 b  ");
					strcat(Consulta, " where a.corporationNumber*=b.corporationNumber  ");
					strcat(Consulta, " and a.organizationPointNumber*=b.organizationPointNumber  ");
					strcat(Consulta, " order by  ");
					strcat(Consulta, " prueba,  ");
					strcat(Consulta, " convert(numeric(19,0),b.corporationNumber), ");
					strcat(Consulta, " convert(numeric(19,0),b.organizationPointNumber),  ");
					strcat(Consulta, " convert(numeric(19,0),b.reportsTo)  ");

/*          printf("\n 4100:  %s \n ",Consulta);*/

					break;
			  case 42:
					/* consulta a la tabla reg4200 */
					strcat(Consulta, "select recordIdentifier, issuerIca, issuerNumberIca, ");
					strcat(Consulta, "corporationNumber, reservedForInternalUse1, ");
					strcat(Consulta, "reservedForInternalUse2, reservedforInternalUse3, ");
					strcat(Consulta, "organizationPointNumber, freeFormatText, reportsTo, ");
					strcat(Consulta, "reportsToFreeFormatText, reservedforInternalUse4, ");
					strcat(Consulta, "organizationHierarchyMainAct, ");
					strcat(Consulta, "outgoingIncomingErrorCode, ");
					strcat(Consulta, "corporationNumber, ");
					strcat(Consulta, "reportsTo "); 
					strcat(Consulta, "from REG4200 ");
					/*strcat(Consulta, "order by convert(numeric(16,0),corporationNumber), ");
					strcat(Consulta, "convert(numeric(16,0),organizationPointNumber), ");
					strcat(Consulta, "convert(numeric(16,0),reportsTo) ");*/

  /*        printf("\n 4200:  %s \n ",Consulta);*/

					break;
			   case 43:
					strcat(Consulta, "select distinct a.recordIdentifier, a.issuerIca, a.issuerNumberIca, ");
					strcat(Consulta, "a.corporationNumber, a.reservedForInternalUse1, ");
					strcat(Consulta, "a.reservedForInternalUse2, a.reservedForInternalUse3, ");
					strcat(Consulta, "a.reportsToOrgPointNumber, a.reportsToFreeFormatText, ");
					strcat(Consulta, "a.accountNumber, a.corporateProduct, a.effectiveDate, ");
					strcat(Consulta, "a.expirationDate, a.accountNameLine1, a.accountNameLine2, ");
					strcat(Consulta, "a.accountAddressLine1, a.accountAddressLine2, a.accountCity, ");
					strcat(Consulta, "a.accountStateProvince, a.accountCountry, ");
					strcat(Consulta, "a.accountPostalCode, a.accountPhoneNumber, ");
					strcat(Consulta, "a.accountFaxNumber, a.internalAuditCode, ");
					strcat(Consulta, "a.employeeID, ");  
					strcat(Consulta, "a.dailyNumberLimitofTransactions, ");
					strcat(Consulta, "a.singleTransactionDollarLimit, ");
					strcat(Consulta, "a.dailyTransactionDollarLimit, ");
					strcat(Consulta, "a.cycleNumberofTransactionsLimit, a.cycleDollarLimit, ");
					strcat(Consulta, "a.monthlyNumLimitOfTran, a.monthlyDollarLimit, ");
					strcat(Consulta, "a.otherNumberofTransactionsLimit, a.otherDollarLimit, ");
					strcat(Consulta, "a.taxExemptIndicator, a.currencyCode, ");
					strcat(Consulta, "a.statementDate, a.previousBalanceSign, a.previousBalance, ");
					strcat(Consulta, "a.endingBalanceSign, a.endingBalance, ");
					strcat(Consulta, "a.paymentDueSign, a.paymentDueBalance, a.creditLimitSign, ");
					strcat(Consulta, "a.creditLimit, a.pastDueAmountSign, a.pastDueBalance, ");
					strcat(Consulta, "a.chargeOffSign, a.chargeOffAmount, a.disputedAmountSign, ");
					strcat(Consulta, "a.disputedAmount, a.numberPaymentsPastDue, ");
					strcat(Consulta, "a.highestDelinquencyPeriod, a.accountInDisputeFlag, ");
					strcat(Consulta, "a.addressMaintenanceActionCode, ");
					strcat(Consulta, "a.outgoingIncomingErrorCode, ");
					strcat(Consulta, "prueba = case when b.corporationNumber = null then 9999999999999999 else convert(numeric(19,0),b.corporationNumber) end, ");
					strcat(Consulta, "b.organizationPointNumber,");
					strcat(Consulta, "b.reportsTo ");
					strcat(Consulta, "from REG4300 a, REG4200 b ");
					strcat(Consulta, "where a.corporationNumber*=b.corporationNumber ");
					strcat(Consulta, "and a.reportsToOrgPointNumber*=b.organizationPointNumber ");
					strcat(Consulta, "order by  ");
					strcat(Consulta, "prueba, ");
					strcat(Consulta, "convert(numeric(19,0),b.organizationPointNumber), ");
					strcat(Consulta, "convert(numeric(19,0),b.reportsTo), ");
					strcat(Consulta, "convert(numeric(19,0),a.accountNumber) ");

/*          printf("\n 4300:  %s \n ",Consulta);*/

					break;
			  case 50:
					strcat(Consulta, "select distinct a.recordIdentifier, a.issuerIca, ");
					strcat(Consulta, " a.issuerNumberIca, a.corporationNumber, a.addendumType, ");
					strcat(Consulta, " a.reservedForInternalUse1, a.reservedForInternalUse2, ");
					strcat(Consulta, " a.merchantActTranOriginInd, a.accountNumber, ");
					strcat(Consulta, " a.reservedForInternalUse3, a.acquirersOrIssuersRefNum, ");
					strcat(Consulta, " a.recordType,a.transactionType, a.debitCreditIndicator, ");
					strcat(Consulta, " a.transactionAmount, a.postingDate, a.transactionDate, ");
					strcat(Consulta, " a.processingDate, a.merchantName, a.merchantCity, ");
					strcat(Consulta, " a.merchantStateProvince, a.merchantCountry, ");
					strcat(Consulta, " a.merchantCategoryCode, a.amountInOriginalCurrency, ");
					strcat(Consulta, " a.originalCurrencyCode, a.currConvDateJulian, ");
					strcat(Consulta, " a.postedCurrencyCode, a.conversionRate, ");
					strcat(Consulta, " a.conversionExponent, a.acquiringICA, a.customerCode, ");
					strcat(Consulta, " a.salesTaxAmount, a.reservedForInternalUse4, ");
					strcat(Consulta, " a.reservedForInternalUse5, a.freightAmount, ");
					strcat(Consulta, " a.destinationPostalCode, a.merchantType, ");
					strcat(Consulta, " a.merchantLocationPostalCode, a.dutyAmount, ");
					strcat(Consulta, " a.merchantFederalTaxID, a.merchantStateProvinceCode, ");
					strcat(Consulta, " a.shipFromPostalCode, a.alternateTaxAmount, ");
					strcat(Consulta, " a.destinationCountryCode, a.merchantReferenceNumber, ");
					strcat(Consulta, " a.alternateTaxIndicator, a.alternateTaxIdentifier, ");
					strcat(Consulta, " a.salesTaxCollectedInd@POS, a.addendumDetailIndicator, ");
					strcat(Consulta, " a.merchantID, a.banknetReferenceNumber, a.approvalCode, a.adjustmentReasonCode, ");
					strcat(Consulta, " a.adjustmentDescription, a.maintenanceActionCode, ");
					strcat(Consulta, " a.outgoingIncomingErrorCode, ");
					strcat(Consulta, " a.organizationPointNumber,  ");
					strcat(Consulta, " Padre = case when a.accountNumber = c.accountNumber  then 0 ");
					strcat(Consulta, " else 1 end, ");
					strcat(Consulta, " Prueba = case when b.corporationNumber = null then ");
					strcat(Consulta, "  9999999999999999 else convert(numeric(19,0),b.corporationNumber) end, ");
					strcat(Consulta, " b.organizationPointNumber, ");
					strcat(Consulta, " b.reportsTo  ");
					strcat(Consulta, " from REG5000 a, REG4200 b ,  REG4300 c ");
					strcat(Consulta, " where a.corporationNumber*=b.corporationNumber  ");
					strcat(Consulta, " and a.organizationPointNumber*=b.organizationPointNumber ");
					/*strcat(Consulta, " and a.organizationPointNumber*=b.reportsTo ");*/
					strcat(Consulta, " and a.corporationNumber  *= c.corporationNumber ");
					strcat(Consulta, " and a.organizationPointNumber  *= c.reportsToOrgPointNumber ");
					strcat(Consulta, " and a.accountNumber *= c.accountNumber ");
					strcat(Consulta, " order by  Padre, Prueba, ");
					strcat(Consulta, " convert(numeric(19,0),b.organizationPointNumber), ");
					strcat(Consulta, " convert(numeric(19,0),b.reportsTo), ");
					strcat(Consulta, " convert(numeric(19,0),a.accountNumber) ");

  /*        printf("\n 5000:  %s \n ",Consulta);*/

					break;
			  case 99:
					strcpy(Consulta, "select  recordIdentifier, issuerIca, issuerNumberIca, ");
					strcat(Consulta, "reservedForInternalUse1,   reservedForInternalUse2, ");
					strcat(Consulta, "reservedForInternalUse3, reservedForInternalUse4, ");
					strcat(Consulta, "outgoingIncomingErrorCode ");
					strcat(Consulta, "from REG9999 ");

 /*         printf("\n 9999:  %s \n ",Consulta);*/

					break;
		}
		p_Consulta=Consulta;
		return(p_Consulta);
}
/*****************************************************************************/

int CS_PUBLIC err_handler(dbproc,severity,dberr,oserr,dberrstr,oserrstr)
DBPROCESS       *dbproc;
int             severity;
int             dberr;
int             oserr;
char            *dberrstr;
char            *oserrstr;
{
		if ((dbproc == NULL) || (DBDEAD(dbproc)))
			return(INT_EXIT);
		else 
		{
			fprintf (ERR_CH,"DB-Library error:\n\t%s\n",dberrstr);
			if (oserr != DBNOERR)
				fprintf (ERR_CH,"Operating-system error:\n\t%s\n",oserrstr);
			return(INT_CANCEL);
		}
}

int CS_PUBLIC msg_handler(dbproc,msgno,msgstate,severity,msgtext,srvname,procname,line)
DBPROCESS       *dbproc;
DBINT           msgno;
int             msgstate;
int             severity;
char            *msgtext;
char            *srvname;
char            *procname;
int     	line;
{
		extern char fechayhora[20];
		extern char nombrearchivo[60];
		extern char sqlcmd[3000];
		if ((msgno != 5701) && (msgno != 5703))
		{
				if (severity == 16)
				{
						fprintf (ERR_CH, "Msg %ld, Level %d, State %d\n", msgno, severity, msgstate);
						if (strlen(srvname) > 0)
								fprintf (ERR_CH, "Server '%s', ", srvname);
						if (strlen(procname) > 0)
								fprintf (ERR_CH, "Procedure '%s', ", procname);
						if (line > 0)
								fprintf (ERR_CH, "Line %d", line);
						fprintf (ERR_CH, "\n\t%s\n", msgtext);
						printf("FechaProceso: %s\n", fechayhora);
						printf("Nombre Archvio: %s\n", nombrearchivo);
						printf("Nombre Programa: r4200.c \n");
						printf("Error %ld, Nivel severidad %d, Estado %d\n", msgno, severity,msgstate);
						printf("Mensaje error: \n%s\n", msgtext);
						printf("Se ejecutaba el sql: %s\n", sqlcmd);
						exit(1);
				}
		}
		return (0);
}
