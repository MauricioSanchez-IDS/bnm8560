/*
**      EISSA Header
**      Propiedad de EISSA.
**      (c) Copyright EISSA. 2003.
**      All rights reserved.
**
** Nombre: qryrep.h
**
** Elaborado por : Leo Basabe
**
** Historial/Modificaciones
**
** 001 01/jul/2001 Creación de este header para el manejo de query's  en
** el reporte de errores de respuesta de CDF
**
*/
#include <sybdb.h>
#include <sybfront.h>

/*Funcion que devuelve el numero de campos del query de cada tipo de registro*/
int DevCamQry(Query)
int  Query;
{
int Campos;
Campos=0;
switch(Query)
{
        case 10:
                Campos=18;
                break;
        case 30:
                Campos=24;
                break;
        case 40:
                Campos=48;
                break;
        case 41:
                Campos=49;
                break;
        case 42:
                Campos=16;
                break;
        case 43:
                Campos = 58;  //AFRH 09/21/2004 anterior Campos=57;
                break;
        case 50:
                Campos = 58;  //AFRH 09/21/2004 anterior Campos=56;
                break;
        case 99:
                Campos=11;
                break;
       }
   return(Campos);
}


/******************************************************************/

/*Funcion que devuelve el query de cada tipo de registro*/
char *DevQryRep(Query)
int  Query;
{
char Consulta[5507+1];
strcpy(Consulta,"");
char *p_Consulta;

switch(Query)
{
	case 10:
	   	strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		//AFRH 09/21/2004 anterior strcat(Consulta,"'2..issuerIca.......................5.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'2..issuerIca......................11.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..reservedForInternalUse1........19.. ' + ltrim(rtrim(reservedForInternalUse1)), ");
		strcat(Consulta,"'5..reservedForInternalUse2.........3.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'6..reservedForInternalUse3........17.. ' + ltrim(rtrim(reservedForInternalUse3)), ");
		strcat(Consulta,"'7..reservedForInternalUse4.........6.. ' + ltrim(rtrim(reservedForInternalUse4)), ");
		strcat(Consulta,"'8..rejectionLevel..................1.. ' + ltrim(rtrim(rejectionLevel)), ");
		strcat(Consulta,"'9..providingFromDate..............17.. ' + ltrim(rtrim(providingFromDate)), ");
		strcat(Consulta,"'10.providingToDate................17.. ' + ltrim(rtrim(providingToDate)), ");
		strcat(Consulta,"'11.runModeIndicator................1.. ' + ltrim(rtrim(runModeIndicator)), ");
		strcat(Consulta,"'12.fileReferenceNumber............24.. ' + ltrim(rtrim(fileReferenceNumber)), ");
		strcat(Consulta,"'13.custumerProcessorNumber.........5.. ' + ltrim(rtrim(custumerProcessorNumber)), ");
		strcat(Consulta,"'14.custumerProcessorName..........35.. ' + ltrim(rtrim(custumerProcessorName)), ");
		strcat(Consulta,"'15.cdfVersionNumber................4.. ' + ltrim(rtrim(cdfVersionNumber)), ");
		strcat(Consulta,"'16.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'17.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'18.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		strcat(Consulta,"from REG1000, MTCERCDF ");
		strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
                break;
	case 30: 
		strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		//AFRH 09/21/2004 anterior strcat(Consulta,"'2..issuerIca.......................5.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'2..issuerIca......................11.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..reservedForInternalUse1........19.. ' + ltrim(rtrim(reservedForInternalUse1)), ");
		strcat(Consulta,"'5..reservedForInternalUse2.........3.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'6..reservedForInternalUse3........17.. ' + ltrim(rtrim(reservedForInternalUse3)), ");
		strcat(Consulta,"'7..reservedForInternalUse4.........6.. ' + ltrim(rtrim(reservedForInternalUse4)), ");
		strcat(Consulta,"'8..issuerNameLine1................35.. ' + ltrim(rtrim(issuerNameLine1)), ");
		strcat(Consulta,"'9..issuerNameLine2................35.. ' + ltrim(rtrim(issuerNameLine2)), ");
		strcat(Consulta,"'10.addressLine1...................35.. ' + ltrim(rtrim(addressLine1)), ");
		strcat(Consulta,"'11.addressLine2...................35.. ' + ltrim(rtrim(addressLine2)), ");
		strcat(Consulta,"'12.city...........................20.. ' + ltrim(rtrim(city)), ");
		strcat(Consulta,"'13.stateProvince...................3.. ' + ltrim(rtrim(stateProvince)), ");
		strcat(Consulta,"'14.country.........................3.. ' + ltrim(rtrim(country)), ");
		strcat(Consulta,"'15.postalCode.....................10.. ' + ltrim(rtrim(postalCode)), ");
		strcat(Consulta,"'16.currency........................3.. ' + ltrim(rtrim(currency)), ");
		strcat(Consulta,"'17.contactPerson..................35.. ' + ltrim(rtrim(contactPerson)), ");
		strcat(Consulta,"'18.phoneNumber....................25.. ' + ltrim(rtrim(phoneNumber)), ");
		strcat(Consulta,"'19.faxNumber......................25.. ' + ltrim(rtrim(faxNumber)), ");
		strcat(Consulta,"'20.emailAddress...................50.. ' + ltrim(rtrim(emailAddress)), ");
		strcat(Consulta,"'21.addressMaintenanceAction........1.. ' + ltrim(rtrim(addressMaintenanceAction)), ");
		strcat(Consulta,"'22.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");	
		strcat(Consulta,"'23.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'24.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		strcat(Consulta,"from REG3000, MTCERCDF ");
	 	strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");	
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
                break;
	case 40:
		strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		//AFRH 09/21/2004 anterior strcat(Consulta,"'2..issuerIca.......................5.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'2..issuerIca......................11.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..corporationNumber..............19.. ' + ltrim(rtrim(corporationNumber)), ");	
		strcat(Consulta,"'5..reservedForInternalUse1.........3.. ' + ltrim(rtrim(reservedForInternalUse1)), ");	
		strcat(Consulta,"'6..reservedForInternalUse2........17.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'7..reservedForInternalUse3.........6.. ' + ltrim(rtrim(reservedForInternalUse3)), ");
		strcat(Consulta,"'8..corporationNameLine1...........35.. ' + ltrim(rtrim(corporationNameLine1)), ");
		strcat(Consulta,"'9..corporationNameLine2...........35.. ' + ltrim(rtrim(corporationNameLine2)), ");
		strcat(Consulta,"'10.addressLine1...................35.. ' + ltrim(rtrim(addressLine1)), ");
		strcat(Consulta,"'11.addressLine2...................35.. ' + ltrim(rtrim(addressLine2)), ");
		strcat(Consulta,"'12.city...........................20.. ' + ltrim(rtrim(city)), ");
		strcat(Consulta,"'13.stateProvince...................3.. ' + ltrim(rtrim(stateProvince)), ");
		strcat(Consulta,"'14.country.........................3.. ' + ltrim(rtrim(country)), ");
		strcat(Consulta,"'15.postalCode.....................10.. ' + ltrim(rtrim(postalCode)), ");
		strcat(Consulta,"'16.currencyCode....................3.. ' + ltrim(rtrim(currencyCode)), ");
		strcat(Consulta,"'17.contactPerson..................35.. ' + ltrim(rtrim(contactPerson)), ");
		strcat(Consulta,"'18.phoneNumber....................25.. ' + ltrim(rtrim(phoneNumber)), ");
		strcat(Consulta,"'19.faxNumber......................25.. ' + ltrim(rtrim(faxNumber)), ");
		strcat(Consulta,"'20.emailAddress...................50.. ' + ltrim(rtrim(emailAddress)), ");
		strcat(Consulta,"'21.budgetLimit....................16.. ' + ltrim(rtrim(budgetLimit)), ");
		strcat(Consulta,"'22.cycleDateIndicator..............2.. ' + ltrim(rtrim(cycleDateIndicator)), ");
		strcat(Consulta,"'23.totalAccounts...................7.. ' + ltrim(rtrim(totalAccounts)), ");
		strcat(Consulta,"'24.accountsPastDue.................7.. ' + ltrim(rtrim(accountsPastDue)), ");
		strcat(Consulta,"'25.accountsWithDispute.............7.. ' + ltrim(rtrim(accountsWithDispute)), ");
		strcat(Consulta,"'26.numberOfCards...................7.. ' + ltrim(rtrim(numberOfCards)), ");
		strcat(Consulta,"'27.chargeOffSign...................1.. ' + ltrim(rtrim(chargeOffSign)), ");
		strcat(Consulta,"'28.chargeOffAmount................16.. ' + ltrim(rtrim(chargeOffAmount)), ");
		strcat(Consulta,"'29.pastDueAmountSign...............1.. ' + ltrim(rtrim(pastDueAmountSign)), ");
		strcat(Consulta,"'30.pastDueAmount..................16.. ' + ltrim(rtrim(pastDueAmount)), ");
		strcat(Consulta,"'31.disputeAmountSign...............1.. ' + ltrim(rtrim(disputeAmountSign)), ");
		strcat(Consulta,"'32.disputeAmount..................16.. ' + ltrim(rtrim(disputeAmount)), ");
		strcat(Consulta,"'33.creditLimitSign.................1.. ' + ltrim(rtrim(creditLimitSign)), ");
		strcat(Consulta,"'34.creditLimit....................16.. ' + ltrim(rtrim(creditLimit)), ");
		strcat(Consulta,"'35.paymentDueSign..................1.. ' + ltrim(rtrim(paymentDueSign)), ");
		strcat(Consulta,"'36.paymentDue.....................16.. ' + ltrim(rtrim(paymentDue)), ");
		strcat(Consulta,"'37.outstandingBalanceSign..........1.. ' + ltrim(rtrim(outstandingBalanceSign)), ");
		strcat(Consulta,"'38.outstandingBalance.............16.. ' + ltrim(rtrim(outstandingBalance)), ");
		strcat(Consulta,"'39.numberOfDebits.................10.. ' + ltrim(rtrim(numberOfDebits)), ");
		strcat(Consulta,"'40.numberOfCredits................10.. ' + ltrim(rtrim(numberOfCredits)), ");
		strcat(Consulta,"'41.amountOfDebits.................16.. ' + ltrim(rtrim(amountOfDebits)), ");
		strcat(Consulta,"'42.amountOfCredits................16.. ' + ltrim(rtrim(amountOfCredits)), ");
		strcat(Consulta,"'43.numberAccountsOverLimit.........7.. ' + ltrim(rtrim(numberAccountsOverLimit)), ");
		strcat(Consulta,"'44.portfolioDate...................8.. ' + ltrim(rtrim(portfolioDate)), ");
		strcat(Consulta,"'45.addressMaintenanceActionCode....1.. ' + ltrim(rtrim(addressMaintenanceActionCode)), ");
		strcat(Consulta,"'46.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'47.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'48.err_accion........................240.. ' + ltrim(rtrim(err_accion)) ");
		strcat(Consulta,"from REG4000, MTCERCDF ");
		strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
                break;
	case 41:
		strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		//AFRH 09/21/2004 anterior strcat(Consulta,"'2..issuerIca.......................5.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'2..issuerIca......................11.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..corporationNumber..............19.. ' + ltrim(rtrim(corporationNumber)), ");
		strcat(Consulta,"'5..reservedForInternalUse1.........3.. ' + ltrim(rtrim(reservedForInternalUse1)), ");
		strcat(Consulta,"'6..reservedForInternalUse2........17.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'7..reservedForInternalUse3.........6.. ' + ltrim(rtrim(reservedForInternalUse3)), ");
		strcat(Consulta,"'8..organizationPointNumber........19.. ' + ltrim(rtrim(organizationPointNumber)), ");
		strcat(Consulta,"'9..freeFormatText.................25.. ' + ltrim(rtrim(freeFormatText)), ");
		strcat(Consulta,"'10.organizationPointNameLine1.....35.. ' + ltrim(rtrim(organizationPointNameLine1)), ");
		strcat(Consulta,"'11.organizationPointNameLine2.....35.. ' + ltrim(rtrim(organizationPointNameLine2)), ");
		strcat(Consulta,"'12.addressLine1...................35.. ' + ltrim(rtrim(addressLine1)), ");
		strcat(Consulta,"'13.addressLine2...................35.. ' + ltrim(rtrim(addressLine2)), ");
		strcat(Consulta,"'14.city...........................20.. ' + ltrim(rtrim(city)), ");
		strcat(Consulta,"'15.stateProvince...................3.. ' + ltrim(rtrim(stateProvince)), ");	
		strcat(Consulta,"'16.country.........................3.. ' + ltrim(rtrim(country)), ");
		strcat(Consulta,"'17.postalCode.....................10.. ' + ltrim(rtrim(postalCode)), ");
		strcat(Consulta,"'18.currencyCode....................3.. ' + ltrim(rtrim(currencyCode)), ");
		strcat(Consulta,"'19.contactPerson..................35.. ' + ltrim(rtrim(contactPerson)), ");
		strcat(Consulta,"'20.phoneNumber....................25.. ' + ltrim(rtrim(phoneNumber)), ");
		strcat(Consulta,"'21.faxNumber......................25.. ' + ltrim(rtrim(faxNumber)), ");
		strcat(Consulta,"'22.eMailAddress...................50.. ' + ltrim(rtrim(eMailAddress)), ");
		strcat(Consulta,"'23.budgetLimit....................16.. ' + ltrim(rtrim(budgetLimit)), ");
		strcat(Consulta,"'24.totalAccounts...................7.. ' + ltrim(rtrim(totalAccounts)), ");
		strcat(Consulta,"'25.accountsPastDue.................7.. ' + ltrim(rtrim(accountsPastDue)), ");
		strcat(Consulta,"'26.accountsWithDispute.............7.. ' + ltrim(rtrim(accountsWithDispute)), ");
		strcat(Consulta,"'27.numberOfCards...................7.. ' + ltrim(rtrim(numberOfCards)), ");
		strcat(Consulta,"'28.chargeOffSign...................1.. ' + ltrim(rtrim(chargeOffSign)), ");
		strcat(Consulta,"'29.chargeOffAmount................16.. ' + ltrim(rtrim(chargeOffAmount)), ");
		strcat(Consulta,"'30.pastDueAmountSign...............1.. ' + ltrim(rtrim(pastDueAmountSign)), ");
		strcat(Consulta,"'31.pastDueAmount..................16.. ' + ltrim(rtrim(pastDueAmount)), ");
		strcat(Consulta,"'32.disputeAmountSign...............1.. ' + ltrim(rtrim(disputeAmountSign)), ");
		strcat(Consulta,"'33.disputeAmount..................16.. ' + ltrim(rtrim(disputeAmount)), ");
		strcat(Consulta,"'34.creditLimitSign.................1.. ' + ltrim(rtrim(creditLimitSign)), ");
		strcat(Consulta,"'35.creditLimit....................16.. ' + ltrim(rtrim(creditLimit)), " );
		strcat(Consulta,"'36.paymentDueSign..................1.. ' + ltrim(rtrim(paymentDueSign)), ");
		strcat(Consulta,"'37.paymentDue.....................16.. ' + ltrim(rtrim(paymentDue)), ");
		strcat(Consulta,"'38.outstandingBalanceSign..........1.. ' + ltrim(rtrim(outstandingBalanceSign)), ");
		strcat(Consulta,"'39.outstandingBalance.............16.. ' + ltrim(rtrim(outstandingBalance)), ");
		strcat(Consulta,"'40.numberOfDebits.................10.. ' + ltrim(rtrim(numberOfDebits)), ");
		strcat(Consulta,"'41.numberOfCredits................10.. ' + ltrim(rtrim(numberOfCredits)), ");
		strcat(Consulta,"'42.amountOfDebits.................16.. ' + ltrim(rtrim(amountOfDebits)), ");
		strcat(Consulta,"'43.amountOfCredits................16.. ' + ltrim(rtrim(amountOfCredits)), ");
		strcat(Consulta,"'44.numberAccountsOverLimit.........7.. ' + ltrim(rtrim(numberAccountsOverLimit)), ");
		strcat(Consulta,"'45.portfolioDate...................8.. ' + ltrim(rtrim(portfolioDate)), ");
		strcat(Consulta,"'46.addressMaintenanceActionCode....1.. ' + ltrim(rtrim(addressMaintenanceActionCode)), ");
		strcat(Consulta,"'47.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'48.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'49.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		strcat(Consulta,"from REG4100, MTCERCDF ");
		strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
                break;
	case 42:	
		strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		//AFRH 09/21/2004 anterior strcat(Consulta,"'2..issuerIca.......................5.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'2..issuerIca......................11.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..corporationNumber..............19.. ' + ltrim(rtrim(corporationNumber)), ");
		strcat(Consulta,"'5..reservedForInternalUse1.........3.. ' + ltrim(rtrim(reservedForInternalUse1)), ");
		strcat(Consulta,"'6..reservedForInternalUse2........17.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'7..reservedForInternalUse3.........6.. ' + ltrim(rtrim(reservedforInternalUse3)), ");
		strcat(Consulta,"'8..organizationPointNumber........19.. ' + ltrim(rtrim(organizationPointNumber)), ");
		strcat(Consulta,"'9..freeFormatText.................25.. ' + ltrim(rtrim(freeFormatText)), ");
		strcat(Consulta,"'10.reportsTo......................19.. ' + ltrim(rtrim(reportsTo)), ");
		strcat(Consulta,"'11.reportsToFreeFormatText........25.. ' + ltrim(rtrim(reportsToFreeFormatText)), ");
		strcat(Consulta,"'12.reservedforInternalUse4.........2.. ' + ltrim(rtrim(reservedforInternalUse4)), ");
		strcat(Consulta,"'13.organizationHierarchyMainAct....1.. ' + ltrim(rtrim(organizationHierarchyMainAct)), ");
		strcat(Consulta,"'14.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'15.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'16.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		strcat(Consulta,"from REG4200, MTCERCDF ");
		strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
                break;
	case 43:
		/* AFRH 09/21/2004 anterior
		strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		strcat(Consulta,"'2..issuerIca.......................5.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..corporationNumber..............19.. ' + ltrim(rtrim(corporationNumber)), ");
		strcat(Consulta,"'5..reservedForInternalUse1.........3.. ' + ltrim(rtrim(reservedForInternalUse1)), ");
		strcat(Consulta,"'6..reservedForInternalUse2........17.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'7..reservedForInternalUse3.........6.. ' + ltrim(rtrim(reservedforInternalUse3)), ");
		strcat(Consulta,"'8..organizationPointNumber........19.. ' + ltrim(rtrim(organizationPointNumber)), ");
		strcat(Consulta,"'9..freeFormatText.................25.. ' + ltrim(rtrim(freeFormatText)), ");
		strcat(Consulta,"'10.reportsTo......................19.. ' + ltrim(rtrim(reportsTo)), ");
		strcat(Consulta,"'11.reportsToFreeFormatText........25.. ' + ltrim(rtrim(reportsToFreeFormatText)), ");
		strcat(Consulta,"'12.reservedforInternalUse4.........2.. ' + ltrim(rtrim(reservedforInternalUse4)), ");
		strcat(Consulta,"'13.organizationHierarchyMainAct....1.. ' + ltrim(rtrim(organizationHierarchyMainAct)), ");
		strcat(Consulta,"'14.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'15.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'16.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		strcat(Consulta,"from REG4200, MTCERCDF ");
		strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
		AFRH 09/21/2004 anterior*/
		// AFRH 09/21/2004 nuevo
		strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		strcat(Consulta,"'2..issuerIca......................11.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..corporationNumber..............19.. ' + ltrim(rtrim(corporationNumber)), ");
		strcat(Consulta,"'5..reservedForInternalUse1.........3.. ' + ltrim(rtrim(reservedForInternalUse1)), ");
		strcat(Consulta,"'6..reservedForInternalUse2........17.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'7..reservedForInternalUse3.........6.. ' + ltrim(rtrim(reservedForInternalUse3)), ");
		strcat(Consulta,"'8..reportsToOrgPointNumber........19.. ' + ltrim(rtrim(reportsToOrgPointNumber)), ");
		strcat(Consulta,"'9..reportsToFreeFormatText........25.. ' + ltrim(rtrim(reportsToFreeFormatText)), ");
		strcat(Consulta,"'10.accountNumbe...................19.. ' + ltrim(rtrim(accountNumber)), ");
		strcat(Consulta,"'11.corporateProduct................1.. ' + ltrim(rtrim(corporateProduct)), ");
		strcat(Consulta,"'12.effectiveDate...................8.. ' + ltrim(rtrim(effectiveDate)), ");
		strcat(Consulta,"'13.expirationDate..................6.. ' + ltrim(rtrim(expirationDate)), ");
		strcat(Consulta,"'14.accountNameLine1...............35.. ' + ltrim(rtrim(accountNameLine1)), ");
		strcat(Consulta,"'15.accountNameLine2...............35.. ' + ltrim(rtrim(accountNameLine2)), ");
		strcat(Consulta,"'16.accountAddressLine1............35.. ' + ltrim(rtrim(accountAddressLine1)), ");
		strcat(Consulta,"'17.accountAddressLine2............35.. ' + ltrim(rtrim(accountAddressLine2)), ");
		strcat(Consulta,"'18.accountCity....................20.. ' + ltrim(rtrim(accountCity)), ");
		strcat(Consulta,"'19.accountStateProvince............3.. ' + ltrim(rtrim(accountStateProvince)), ");
		strcat(Consulta,"'20.accountCountry..................3.. ' + ltrim(rtrim(accountCountry)), ");
		strcat(Consulta,"'21.accountPostalCode..............10.. ' + ltrim(rtrim(accountPostalCode)), ");
		strcat(Consulta,"'22.accountPhoneNumber.............25.. ' + ltrim(rtrim(accountPhoneNumber)), ");
		strcat(Consulta,"'23.accountFaxNumber...............25.. ' + ltrim(rtrim(accountFaxNumber)), ");
		strcat(Consulta,"'24.internalAuditCode..............75.. ' + ltrim(rtrim(internalAuditCode)), ");
		strcat(Consulta,"'25.employeeID.....................20.. ' + ltrim(rtrim(employeeID)), ");
		strcat(Consulta,"'26.dailyNumberLimitofTransactions..8.. ' + ltrim(rtrim(dailyNumberLimitofTransactions)), ");
		strcat(Consulta,"'27.singleTransactionDollarLimit...16.. ' + ltrim(rtrim(singleTransactionDollarLimit)), ");
		strcat(Consulta,"'28.dailyTransactionDollarLimit....16.. ' + ltrim(rtrim(dailyTransactionDollarLimit)), ");
		strcat(Consulta,"'29.cycleNumberofTransactionsLimit..8.. ' + ltrim(rtrim(cycleNumberofTransactionsLimit)), ");
		strcat(Consulta,"'30.cycleDollarLimit...............16.. ' + ltrim(rtrim(cycleDollarLimit)), ");
		strcat(Consulta,"'31.monthlyNumLimitOfTran...........8.. ' + ltrim(rtrim(monthlyNumLimitOfTran)), ");
		strcat(Consulta,"'32.monthlyDollarLimit.............16.. ' + ltrim(rtrim(monthlyDollarLimit)), ");
		strcat(Consulta,"'33.otherNumberofTransactionsLimit..8.. ' + ltrim(rtrim(otherNumberofTransactionsLimit)), ");
		strcat(Consulta,"'34.otherDollarLimit...............16.. ' + ltrim(rtrim(otherDollarLimit)), ");
		strcat(Consulta,"'35.taxExemptIndicator..............1.. ' + ltrim(rtrim(taxExemptIndicator)), ");
		strcat(Consulta,"'36.currencyCode....................3.. ' + ltrim(rtrim(currencyCode)), ");
		strcat(Consulta,"'37.statementDate...................8.. ' + ltrim(rtrim(statementDate)), ");
		strcat(Consulta,"'38.previousBalanceSign.............1.. ' + ltrim(rtrim(previousBalanceSign)), ");
		strcat(Consulta,"'39.previousBalance................16.. ' + ltrim(rtrim(previousBalance)), ");
		strcat(Consulta,"'40.endingBalanceSign...............1.. ' + ltrim(rtrim(endingBalanceSign)), ");
		strcat(Consulta,"'41.endingBalance..................16.. ' + ltrim(rtrim(endingBalance)), ");
		strcat(Consulta,"'42.paymentDueSign..................1.. ' + ltrim(rtrim(paymentDueSign)), ");
		strcat(Consulta,"'43.paymentDueBalance..............16.. ' + ltrim(rtrim(paymentDueBalance)), ");
		strcat(Consulta,"'44.creditLimitSign.................1.. ' + ltrim(rtrim(creditLimitSign)), ");
		strcat(Consulta,"'45.creditLimit....................16.. ' + ltrim(rtrim(creditLimit)), ");
		strcat(Consulta,"'46.pastDueAmountSign...............1.. ' + ltrim(rtrim(pastDueAmountSign)), ");
		strcat(Consulta,"'47.pastDueBalance.................16.. ' + ltrim(rtrim(pastDueBalance)), ");
		strcat(Consulta,"'48.chargeOffSign...................1.. ' + ltrim(rtrim(chargeOffSign)), ");
		strcat(Consulta,"'49.chargeOffAmount................16.. ' + ltrim(rtrim(chargeOffAmount)), ");
		strcat(Consulta,"'50.disputedAmountSign..............1.. ' + ltrim(rtrim(disputedAmountSign)), ");
		strcat(Consulta,"'51.disputedAmount.................16.. ' + ltrim(rtrim(disputedAmount)), ");
		strcat(Consulta,"'52.numberPaymentsPastDue...........3.. ' + ltrim(rtrim(numberPaymentsPastDue)), ");
		strcat(Consulta,"'53.highestDelinquencyPeriod........2.. ' + ltrim(rtrim(highestDelinquencyPeriod)), ");
		strcat(Consulta,"'54.accountInDisputeFlag............1.. ' + ltrim(rtrim(accountInDisputeFlag)), ");
		strcat(Consulta,"'55.addressMaintenanceActionCode....1.. ' + ltrim(rtrim(addressMaintenanceActionCode)), ");
		strcat(Consulta,"'56.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'57.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'58.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		// AFRH 09/21/2004 nuevo
		strcat(Consulta,"from REG4300, MTCERCDF ");
		strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
                break;
		
	case 50:
		strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		//AFRH 09/21/2004 anterior strcat(Consulta,"'2..issuerIca.......................5.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'2..issuerIca......................11.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..corporationNumber..............19.. ' + ltrim(rtrim(corporationNumber)), ");
		strcat(Consulta,"'5..addendumType....................3.. ' + ltrim(rtrim(addendumType)), ");
		strcat(Consulta,"'6..reservedForInternalUse1........17.. ' + ltrim(rtrim(reservedForInternalUse1)), ");
		strcat(Consulta,"'7..reservedForInternalUse2.........6.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'8..merchantActTranOriginInd........1.. ' + ltrim(rtrim(merchantActTranOriginInd)), ");
		strcat(Consulta,"'9..accountNumber..................19.. ' + ltrim(rtrim(accountNumber)), ");
		strcat(Consulta,"'10.reservedForInternalUse3........10.. ' + ltrim(rtrim(reservedForInternalUse3)), ");
		strcat(Consulta,"'11.acquirersOrIssuersRefNum.......23.. ' + ltrim(rtrim(acquirersOrIssuersRefNum)), ");
		strcat(Consulta,"'12.recordType......................1.. ' + ltrim(rtrim(recordType)), ");
		strcat(Consulta,"'13.transactionType.................1.. ' + ltrim(rtrim(transactionType)), ");
		strcat(Consulta,"'14.debitCreditIndicator............1.. ' + ltrim(rtrim(debitCreditIndicator)), ");
		strcat(Consulta,"'15.transactionAmount..............16.. ' + ltrim(rtrim(transactionAmount)), ");
		strcat(Consulta,"'16.postingDate.....................8.. ' + ltrim(rtrim(postingDate)), ");
		strcat(Consulta,"'17.transactionDate.................8.. ' + ltrim(rtrim(transactionDate)), ");
		strcat(Consulta,"'18.processingDate..................8.. ' + ltrim(rtrim(processingDate)), ");
		strcat(Consulta,"'19.merchantName...................25.. ' + ltrim(rtrim(merchantName)), ");
		strcat(Consulta,"'20.merchantCity...................13.. ' + ltrim(rtrim(merchantCity)), ");
		strcat(Consulta,"'21.merchantStateProvince...........3.. ' + ltrim(rtrim(merchantStateProvince)), ");
		strcat(Consulta,"'22.merchantCountry.................3.. ' + ltrim(rtrim(merchantCountry)), ");
		strcat(Consulta,"'23.merchantCategoryCode............4.. ' + ltrim(rtrim(merchantCategoryCode)), ");
		strcat(Consulta,"'24.amountInOriginalCurrency.......16.. ' + ltrim(rtrim(amountInOriginalCurrency)), ");
		strcat(Consulta,"'25.originalCurrencyCode............3.. ' + ltrim(rtrim(originalCurrencyCode)), ");
		strcat(Consulta,"'26.currConvDateJulian..............5.. ' + ltrim(rtrim(currConvDateJulian)), ");
		strcat(Consulta,"'27.postedCurrencyCode..............3.. ' + ltrim(rtrim(postedCurrencyCode)), ");
		strcat(Consulta,"'28.conversionRate.................16.. ' + ltrim(rtrim(conversionRate)), ");
		strcat(Consulta,"'29.conversionExponent..............1.. ' + ltrim(rtrim(conversionExponent)), ");
		//AFRH 09/21/2004 anterior strcat(Consulta,"'30.acquiringICA....................4.. ' + ltrim(rtrim(acquiringICA)), ");
		strcat(Consulta,"'30.acquiringICA...................11.. ' + ltrim(rtrim(acquiringICA)), ");
		strcat(Consulta,"'31.customerCode...................17.. ' + ltrim(rtrim(customerCode)), ");
		strcat(Consulta,"'32.salesTaxAmount.................16.. ' + ltrim(rtrim(salesTaxAmount)), ");
		strcat(Consulta,"'33.reservedForInternalUse4.........1.. ' + ltrim(rtrim(reservedForInternalUse4)), ");
		strcat(Consulta,"'34.reservedForInternalUse5.........5.. ' + ltrim(rtrim(reservedForInternalUse5)), ");
		strcat(Consulta,"'35.freightAmount..................16.. ' + ltrim(rtrim(freightAmount)), ");
		strcat(Consulta,"'36.destinationPostalCode..........10.. ' + ltrim(rtrim(destinationPostalCode)), ");
		strcat(Consulta,"'37.merchantType....................4.. ' + ltrim(rtrim(merchantType)), ");
		strcat(Consulta,"'38.merchantLocationPostalCode.....10.. ' + ltrim(rtrim(merchantLocationPostalCode)), ");
		strcat(Consulta,"'39.dutyAmount.....................16.. ' + ltrim(rtrim(dutyAmount)), ");
		strcat(Consulta,"'40.merchantFederalTaxID...........15.. ' + ltrim(rtrim(merchantFederalTaxID)), ");
		strcat(Consulta,"'41.merchantStateProvinceCode.......3.. ' + ltrim(rtrim(merchantStateProvinceCode)), ");
		strcat(Consulta,"'42.shipFromPostalCode.............10.. ' + ltrim(rtrim(shipFromPostalCode)), ");
		strcat(Consulta,"'43.alternateTaxAmount.............16.. ' + ltrim(rtrim(alternateTaxAmount)), ");
		strcat(Consulta,"'44.destinationCountryCode..........3.. ' + ltrim(rtrim(destinationCountryCode)), ");
		strcat(Consulta,"'45.merchantReferenceNumber........17.. ' + ltrim(rtrim(merchantReferenceNumber)), ");
		strcat(Consulta,"'46.alternateTaxIndicator...........1.. ' + ltrim(rtrim(alternateTaxIndicator)), ");
		strcat(Consulta,"'47.alternateTaxIdentifier.........15.. ' + ltrim(rtrim(alternateTaxIdentifier)), ");
		strcat(Consulta,"'48.salesTaxCollectedInd@POS........1.. ' + ltrim(rtrim(salesTaxCollectedInd@POS)), ");
		strcat(Consulta,"'49.addendumDetailIndicator.........1.. ' + ltrim(rtrim(addendumDetailIndicator)), ");
		strcat(Consulta,"'50.merchantID.....................15.. ' + ltrim(rtrim(merchantID)), ");
		/*AFRH 09/21/2004 anterior 
		strcat(Consulta,"'51.adjustmentReasonCode............5.. ' + ltrim(rtrim(adjustmentReasonCode)), ");
		strcat(Consulta,"'52.adjustmentDescription..........40.. ' + ltrim(rtrim(adjustmentDescription)), ");
		strcat(Consulta,"'53.maintenanceActionCode...........1.. ' + ltrim(rtrim(maintenanceActionCode)), ");
		strcat(Consulta,"'54.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'55.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'56.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		AFRH 09/21/2004 anterior */
		//AFRH 09/21/2004 nuevo
		strcat(Consulta,"'51.banknetReferenceNumber.........12.. ' + ltrim(rtrim(banknetReferenceNumber)), ");
		strcat(Consulta,"'52.approvalCode....................6.. ' + ltrim(rtrim(approvalCode)), ");
		strcat(Consulta,"'53.adjustmentReasonCode............5.. ' + ltrim(rtrim(adjustmentReasonCode)), ");
		strcat(Consulta,"'54.adjustmentDescription..........40.. ' + ltrim(rtrim(adjustmentDescription)), ");
		strcat(Consulta,"'55.maintenanceActionCode...........1.. ' + ltrim(rtrim(maintenanceActionCode)), ");
		strcat(Consulta,"'56.inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'57.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'58.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		//AFRH 09/21/2004 nuevo
		strcat(Consulta,"from REG5000, MTCERCDF ");
		strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
                break;
	case 99:
		strcpy(Consulta,"select ");
		strcat(Consulta,"'1..recordIdentifier................4.. ' + ltrim(rtrim(recordIdentifier)), ");
		//AFRH 09/21/2004 anterior strcat(Consulta,"'2..issuerIca.......................5.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'2..issuerIca......................11.. ' + ltrim(rtrim(issuerIca)), ");
		strcat(Consulta,"'3..issuerNumberIca................11.. ' + ltrim(rtrim(issuerNumberIca)), ");
		strcat(Consulta,"'4..reservedForInternalUse1........19.. ' + ltrim(rtrim(reservedForInternalUse1)), ");
		strcat(Consulta,"'5..reservedForInternalUse2.........3.. ' + ltrim(rtrim(reservedForInternalUse2)), ");
		strcat(Consulta,"'6..reservedForInternalUse3........17.. ' + ltrim(rtrim(reservedForInternalUse3)), ");
		strcat(Consulta,"'7..reservedForInternalUse4.........6.. ' + ltrim(rtrim(reservedForInternalUse4)), ");
		strcat(Consulta,"'8..numberOfRecordsInThisfile.......6.. ' + ltrim(rtrim(numberOfRecordsInThisfile)), ");
		strcat(Consulta,"'9..inputFileRecordNumber...........6.. ' + ltrim(rtrim(inputFileRecordNumber)), ");
		strcat(Consulta,"'10.outgoingIncomingErrorCode.......6.. ' + ltrim(rtrim(outgoingIncomingErrorCode)), ");
		strcat(Consulta,"'11.err_accion....................240.. ' + ltrim(rtrim(err_accion)) ");
		strcat(Consulta,"from REG9999, MTCERCDF ");
		strcat(Consulta,"where ltrim(rtrim(outgoingIncomingErrorCode)) <> null ");
		strcat(Consulta,"and convert(int,outgoingIncomingErrorCode) = convert(int,err_num) ");
                     break;
       }
       p_Consulta=Consulta;
   return(p_Consulta);
}
