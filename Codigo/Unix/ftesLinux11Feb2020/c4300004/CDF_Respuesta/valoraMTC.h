char ge_user[20];
char ge_password[20];
char ge_server[20];
char ge_hostname[20];
char ge_dbase[20]; 

char QryCampo[50];

LOGINREC  *login;
time_t lcl_time;     
struct tm *today;    
char fechayhora[20];   
char sqlcmd[1000];

/*Variable que almacena la suma de los REGS*/
DBINT Reg1000;

/*Variables para la insersion en MTCPRO01*/
DBCHAR pro_nomarch[30];
DBCHAR pro_fecha[16]; 
DBCHAR pro_estatus[5];
DBCHAR pro_mensaje[100];

DBCHAR Registros[10];

RETCODE result_code;
/***********************************************************************/
/* ARREGLO DE TAMAÑOS DE LOS REGISTROS */
/*AFRH EISSA 09/20/2004  anterior 00001
 int tamcamposReg1000[]={4, 5, 11, 19, 3, 17, 6, 1, 17, 17, 1, 24, 5, 35, 4, 6, 6};
 int tamcamposReg3000[]={4, 5, 11, 19, 3, 17, 6, 35, 35, 35, 35, 20, 3, 3, 10, 3, 35, 25, 25, 50, 1, 6, 6, };
 int tamcamposReg4000[]={35, 35, 20, 3, 3, 10, 3, 35, 25, 25, 50, 16, 2, 7, 7, 7, 7, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 10, 10, 16, 16, 7, 8, 1, 6};
 int tamcamposReg4100[]={4, 5, 11, 19, 3, 17, 6, 19, 25, 35, 35, 35, 35, 20, 3, 3, 10, 3, 35, 25, 25, 50, 16, 7, 7, 7, 7, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 10, 10, 16, 16, 7, 8, 1, 6};
 int tamcamposReg4200[]={4, 5, 11, 19, 3, 17, 6, 19, 25, 19, 25, 2, 1, 6};
 int tamcamposReg4300[]={4, 5, 11, 19, 3, 17, 6, 19, 25, 19, 1, 8, 6, 35, 35, 35, 35, 20, 3, 3, 10, 25, 25, 75, 8, 16, 16, 8, 16, 8, 16, 8, 16, 1, 3, 8, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 3, 2, 1, 1, 6};
 int tamcamposReg5000[]={4, 5, 11, 19, 3, 17, 6, 1, 19, 10, 23, 1, 1, 1, 16, 8, 8, 8, 25, 13, 3, 3, 4, 16, 3, 5, 3, 16, 1, 4, 17, 16, 1, 5, 16, 10, 4, 10, 16, 15, 3, 10, 16, 3, 17, 1, 15, 1, 1, 15, 5, 40, 1, 6};
 int tamcamposReg9999[]={4, 5, 11, 19, 3, 17, 6, 6, 6};
AFRH EISSA 09/20/2004  anterior 00001*/
/*AFRH EISSA 09/20/2004  nuevo 00001*/
 int tamcamposReg1000[]={4, 11, 11, 19, 3, 17, 6, 1, 17, 17, 1, 24, 5, 35, 4, 6};
 int tamcamposReg3000[]={4, 11, 11, 19, 3, 17, 6, 35, 35, 35, 35, 20, 3, 3, 10, 3, 35, 25, 25, 50, 1, 6, 6};
 int tamcamposReg4000[]={4, 11, 11, 19, 3, 17, 6, 35, 35, 35, 35, 20, 3, 3, 10, 3, 35, 25, 25, 50, 16, 2, 7, 7, 7, 7, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 10, 10, 16, 16, 7, 8, 1, 6};
 int tamcamposReg4100[]={4, 11, 11, 19, 3, 17, 6, 19, 25, 35, 35, 35, 35, 20, 3, 3, 10, 3, 35, 25, 25, 50, 16, 7, 7, 7, 7, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 10, 10, 16, 16, 7, 8, 1, 6};
 int tamcamposReg4200[]={4, 11, 11, 19, 3, 17, 6, 19, 25, 19, 25, 2, 1, 6};
 int tamcamposReg4300[]={4, 11, 11, 19, 3, 17, 6, 19, 25, 19, 1, 8, 6, 35, 35, 35, 35, 20, 3, 3, 10, 25, 25, 75, 20, 8, 16, 16, 8, 16, 8, 16, 8, 16, 1, 3, 8, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 1, 16, 3, 2, 1, 1, 6};
 int tamcamposReg5000[]={4, 11, 11, 19, 3, 17, 6, 1, 19, 10, 23, 1, 1, 1, 16, 8, 8, 8, 25, 13, 3, 3, 4, 16, 3, 5, 3, 16, 1, 11, 17, 16, 1, 5, 16, 10, 4, 10, 16, 15, 3, 10, 16, 3, 17, 1, 15, 1, 1, 15, 12, 6, 5, 40, 1, 6};
 int tamcamposReg9999[]={4, 11, 11, 19, 3, 17, 6, 6, 6};
/*AFRH EISSA 09/20/2004  nuevo 00001*/


/*arreglo de campos Correccion 02-07-2004 JAGG CAMPOS en Mayusculas Minusculas*/
/*AFRH EISSA 09/20/2004  anterior 00002
 char *camposReg1000[16]= {"recordIdentifier","issuerIca","issuerNumberIca","reservedForInternalUse1","reservedForInternalUse2","reservedForInternalUse3","reservedForInternalUse4","rejectionLevel","providingFromDate","providingToDate","runModeIndicator","fileReferenceNumber","custumerProcessorNumber","custumerProcessorName","cdfVersionNumber","inputFileRecordNumber"};

 char *camposReg3000[22]={"recordIdentifier", "issuerIca", "issuerNumberIca", "reservedForInternalUse1", "reservedForInternalUse2", "reservedForInternalUse3", "reservedForInternalUse4", "issuerNameLine1", "issuerNameLine2", "addressLine1", "addressLine2", "city", "stateProvince", "country", "postalCode", "currency", "contactPerson", "phoneNumber", "faxNumber", "emailAddress", "addressMaintenanceAction", "inputFileRecordNumber"};

 char *camposReg4000[46]={"recordIdentifier", "issuerIca", "issuerNumberIca","corporationNumber","reservedForInternalUse1","reservedForInternalUse2","reservedForInternalUse3", "corporationNameLine1", "corporationNameLine2", "addressLine1", "addressLine2", "city", "stateProvince", "country", "postalCode", "currencyCode", "contactPerson", "phoneNumber", "faxNumber", "emailAddress", "budgetLimit", "cycleDateIndicator", "totalAccounts", "accountsPastDue", "accountsWithDispute", "numberOfCards", "chargeOffSign", "chargeOffAmount", "pastDueAmountSign", "pastDueAmount", "disputeAmountSign", "disputeAmount", "creditLimitSign", "creditLimit", "paymentDueSign", "paymentDue", "outstandingBalanceSign", "outstandingBalance", "numberOfDebits", "numberOfCredits", "amountOfDebits", "amountOfCredits", "numberAccountsOverLimit", "portfolioDate", "addressMaintenanceActionCode", "inputFileRecordNumber"};

 char *camposReg4100[48]={"recordIdentifier", "issuerIca", "issuerNumberIca", "corporationNumber", "reservedForInternalUse1", "reservedForInternalUse2", "reservedForInternalUse3", "organizationPointNumber", "freeFormatText", "organizationPointNameLine1", "organizationPointNameLine2", "addressLine1", "addressLine2", "city", "stateProvince", "country", "postalCode", "currencyCode", "contactPerson", "phoneNumber", "faxNumber", "eMailAddress", "budgetLimit", "totalAccounts", "accountsPastDue", "accountsWithDispute", "numberOfCards", "chargeOffSign", "chargeOffAmount", "pastDueAmountSign", "pastDueAmount", "disputeAmountSign", "disputeAmount", "creditLimitSign", "creditLimit", "paymentDueSign", "paymentDue", "outstandingBalanceSign", "outstandingBalance", "numberOfDebits", "numberOfCredits", "amountOfDebits", "amountOfCredits", "numberAccountsOverLimit", "portfolioDate", "addressMaintenanceActionCode", "inputFileRecordNumber"};

 char *camposReg4200[14]={"recordIdentifier", "issuerIca", "issuerNumberIca", "corporationNumber", "reservedForInternalUse1", "reservedForInternalUse2", "reservedforInternalUse3", "organizationPointNumber", "freeFormatText", "reportsTo", "reportsToFreeFormatText", "reservedforInternalUse4", "organizationHierarchyMainAct", "inputFileRecordNumber"}; 

 char *camposReg4300[56]={"ssuerIca", "issuerNumberIca", "corporationNumber", "reservedForInternalUse1", "reservedForInternalUse2", "reservedForInternalUse3", "reportsToOrgPointNumber", "reportsToFreeFormatText", "accountNumber", "corporateProduct", "effectiveDate", "expirationDate", "accountNameLine1", "accountNameLine2", "accountAddressLine1", "accountAddressLine2", "accountCity", "accountStateProvince", "accountCountry", "accountPostalCode", "accountPhoneNumber", "accountFaxNumber", "internalAuditCode", "dailyNumberLimitofTransactions", "singleTransactionDollarLimit", "dailyTransactionDollarLimit", "cycleNumberofTransactionsLimit", "cycleDollarLimit", "monthlyNumLimitOfTran", "monthlyDollarLimit", "otherNumberofTransactionsLimit", "otherDollarLimit", "taxExemptIndicator", "currencyCode", "statementDate", "previousBalanceSign", "previousBalance", "endingBalanceSign", "endingBalance", "paymentDueSign", "paymentDueBalance", "creditLimitSign", "creditLimit", "pastDueAmountSign", "pastDueBalance", "chargeOffSign", "chargeOffAmount", "disputedAmountSign", "disputedAmount", "numberPaymentsPastDue", "highestDelinquencyPeriod", "accountInDisputeFlag", "addressMaintenanceActionCode", "inputFileRecordNumber"};

 char *camposReg5000[54]={"recordIdentifier", "issuerIca", "issuerNumberIca", "corporationNumber", "addendumType", "reservedForInternalUse1", "reservedForInternalUse2", "merchantActTranOriginInd", "accountNumber", "reservedForInternalUse3", "acquirersOrIssuersRefNum", "recordType", "transactionType", "debitCreditIndicator", "transactionAmount", "postingDate", "transactionDate", "processingDate", "merchantName", "merchantCity", "merchantStateProvince", "merchantCountry", "merchantCategoryCode", "amountInOriginalCurrency", "originalCurrencyCode", "currConvDateJulian", "postedCurrencyCode", "conversionRate", "conversionExponent", "acquiringICA", "customerCode", "salesTaxAmount", "reservedForInternalUse4", "reservedForInternalUse5", "freightAmount", "destinationPostalCode", "merchantType", "merchantLocationPostalCode", "dutyAmount", "merchantFederalTaxID", "merchantStateProvinceCode", "shipFromPostalCode", "alternateTaxAmount", "destinationCountryCode", "merchantReferenceNumber", "alternateTaxIndicator", "alternateTaxIdentifier", "salesTaxCollectedInd@POS", "addendumDetailIndicator", "merchantID", "adjustmentReasonCode", "adjustmentDescription", "maintenanceActionCode", "inputFileRecordNumber"};

 char *camposReg9999[9]={"recordIdentifier", "issuerIca", "issuerNumberIca", "reservedForInternalUse1", "reservedForInternalUse2", "reservedForInternalUse3", "reservedForInternalUse4", "numberOfRecordsInThisfile", "inputFileRecordNumber"};

AFRH EISSA 09/20/2004  anterior 00002*/
/*AFRH EISSA 09/20/2004  nuevo 00002*/
 char *camposReg1000[16]= {"recordIdentifier","issuerIca","issuerNumberIca","reservedForInternalUse1","reservedForInternalUse2","reservedForInternalUse3","reservedForInternalUse4","rejectionLevel","providingFromDate","providingToDate","runModeIndicator","fileReferenceNumber","custumerProcessorNumber","custumerProcessorName","cdfVersionNumber","inputFileRecordNumber"};

 char *camposReg3000[22]={"recordIdentifier", "issuerIca", "issuerNumberIca", "reservedForInternalUse1", "reservedForInternalUse2", "reservedForInternalUse3", "reservedForInternalUse4", "issuerNameLine1", "issuerNameLine2", "addressLine1", "addressLine2", "city", "stateProvince", "country", "postalCode", "currency", "contactPerson", "phoneNumber", "faxNumber", "emailAddress", "addressMaintenanceAction", "inputFileRecordNumber"};

 char *camposReg4000[46]={"recordIdentifier", "issuerIca", "issuerNumberIca","corporationNumber","reservedForInternalUse1","reservedForInternalUse2","reservedForInternalUse3", "corporationNameLine1", "corporationNameLine2", "addressLine1", "addressLine2", "city", "stateProvince", "country", "postalCode", "currencyCode", "contactPerson", "phoneNumber", "faxNumber", "emailAddress", "budgetLimit", "cycleDateIndicator", "totalAccounts", "accountsPastDue", "accountsWithDispute", "numberOfCards", "chargeOffSign", "chargeOffAmount", "pastDueAmountSign", "pastDueAmount", "disputeAmountSign", "disputeAmount", "creditLimitSign", "creditLimit", "paymentDueSign", "paymentDue", "outstandingBalanceSign", "outstandingBalance", "numberOfDebits", "numberOfCredits", "amountOfDebits", "amountOfCredits", "numberAccountsOverLimit", "portfolioDate", "addressMaintenanceActionCode", "inputFileRecordNumber"};

 char *camposReg4100[47]={"recordIdentifier", "issuerIca", "issuerNumberIca", "corporationNumber", "reservedForInternalUse1", "reservedForInternalUse2", "reservedForInternalUse3", "organizationPointNumber", "freeFormatText", "organizationPointNameLine1", "organizationPointNameLine2", "addressLine1", "addressLine2", "city", "stateProvince", "country", "postalCode", "currencyCode", "contactPerson", "phoneNumber", "faxNumber", "eMailAddress", "budgetLimit", "totalAccounts", "accountsPastDue", "accountsWithDispute", "numberOfCards", "chargeOffSign", "chargeOffAmount", "pastDueAmountSign", "pastDueAmount", "disputeAmountSign", "disputeAmount", "creditLimitSign", "creditLimit", "paymentDueSign", "paymentDue", "outstandingBalanceSign", "outstandingBalance", "numberOfDebits", "numberOfCredits", "amountOfDebits", "amountOfCredits", "numberAccountsOverLimit", "portfolioDate", "addressMaintenanceActionCode", "inputFileRecordNumber"};

 char *camposReg4200[14]={"recordIdentifier", "issuerIca", "issuerNumberIca", "corporationNumber", "reservedForInternalUse1", "reservedForInternalUse2", "reservedforInternalUse3", "organizationPointNumber", "freeFormatText", "reportsTo", "reportsToFreeFormatText", "reservedforInternalUse4", "organizationHierarchyMainAct", "inputFileRecordNumber"}; 

 char *camposReg4300[56]={"recordIdentifier", "issuerIca", "issuerNumberIca", "corporationNumber", "reservedForInternalUse1", "reservedForInternalUse2", "reservedForInternalUse3", "reportsToOrgPointNumber", "reportsToFreeFormatText", "accountNumber", "corporateProduct", "effectiveDate", "expirationDate", "accountNameLine1", "accountNameLine2", "accountAddressLine1", "accountAddressLine2", "accountCity", "accountStateProvince", "accountCountry", "accountPostalCode", "accountPhoneNumber", "accountFaxNumber", "internalAuditCode", "employID", "dailyNumberLimitofTransactions", "singleTransactionDollarLimit", "dailyTransactionDollarLimit", "cycleNumberofTransactionsLimit", "cycleDollarLimit", "monthlyNumLimitOfTran", "monthlyDollarLimit", "otherNumberofTransactionsLimit", "otherDollarLimit", "taxExemptIndicator", "currencyCode", "statementDate", "previousBalanceSign", "previousBalance", "endingBalanceSign", "endingBalance", "paymentDueSign", "paymentDueBalance", "creditLimitSign", "creditLimit", "pastDueAmountSign", "pastDueBalance", "chargeOffSign", "chargeOffAmount", "disputedAmountSign", "disputedAmount", "numberPaymentsPastDue", "highestDelinquencyPeriod", "accountInDisputeFlag", "addressMaintenanceActionCode", "inputFileRecordNumber"};

 char *camposReg5000[56]={"recordIdentifier", "issuerIca", "issuerNumberIca", "corporationNumber", "addendumType", "reservedForInternalUse1", "reservedForInternalUse2", "merchantActTranOriginInd", "accountNumber", "reservedForInternalUse3", "acquirersOrIssuersRefNum", "recordType", "transactionType", "debitCreditIndicator", "transactionAmount", "postingDate", "transactionDate", "processingDate", "merchantName", "merchantCity", "merchantStateProvince", "merchantCountry", "merchantCategoryCode", "amountInOriginalCurrency", "originalCurrencyCode", "currConvDateJulian", "postedCurrencyCode", "conversionRate", "conversionExponent", "acquiringICA", "customerCode", "salesTaxAmount", "reservedForInternalUse4", "reservedForInternalUse5", "freightAmount", "destinationPostalCode", "merchantType", "merchantLocationPostalCode", "dutyAmount", "merchantFederalTaxID", "merchantStateProvinceCode", "shipFromPostalCode", "alternateTaxAmount", "destinationCountryCode", "merchantReferenceNumber", "alternateTaxIndicator", "alternateTaxIdentifier", "salesTaxCollectedInd@POS", "addendumDetailIndicator", "merchantID", "banknetReferenceNumber", "approvalCode", "adjustmentReasonCode", "adjustmentDescription", "maintenanceActionCode", "inputFileRecordNumber"};

 char *camposReg9999[9]={"recordIdentifier", "issuerIca", "issuerNumberIca", "reservedForInternalUse1", "reservedForInternalUse2", "reservedForInternalUse3", "reservedForInternalUse4", "numberOfRecordsInThisfile", "inputFileRecordNumber"};

/*AFRH EISSA 09/20/2004  nuevo 00002*/
/***********************************************************************/
/*Arreglo de tablas*/
 char *TablasReg[]={"REG1000",  "REG3000" , "REG4000",  "REG4100" , "REG4200",  
                    "REG4300" , "REG5000",  "REG9999", "MTCPRO02"};
/***********************************************************************/
/****** Funcion que valida los campos *********/
int CamposTablasReg(numTabla)
int numTabla;
{
  switch (numTabla)
  {
    case 0:
      return (16);

    case 1:
      return (22);

    case 2:
      return (46);

    case 3:
      return (47); //AFRH EISSA 09/21/2004  anterior return (48);

    case 4:
      return (14);

    case 5:
      return (56); //AFRH EISSA 09/21/2004  anterior return (56);

    case 6:
      return (56); //AFRH EISSA 09/21/2004  anterior return (54);

    case 7:
      return (9);
  
    case 8:
      return (1);
    
    default:
      return (0);
  }
}
/***********************************************************************/
int TamanioCampo(Tabla, Campo)
int Tabla;
int Campo;
{
int tamano;
switch (Tabla)
  {
    case 0:  /*REG1000*/
        tamano=tamcamposReg1000[Campo-1];
      break;

    case 1:  /*REG3000*/
        tamano=tamcamposReg3000[Campo-1];
      break;

    case 2:  /*REG4000*/
        tamano=tamcamposReg4000[Campo-1];
      break;

    case 3:  /*REG4100*/
        tamano=tamcamposReg4100[Campo-1];
      break;

    case 4:  /*REG4200*/
        tamano=tamcamposReg4200[Campo-1];
      break;

    case 5:   /*REG4300*/
        tamano=tamcamposReg4300[Campo-1];
      break;

    case 6:  /*REG5000*/
        tamano=tamcamposReg5000[Campo-1];
      break;
    
    case 7:  /*REG9999*/
        tamano=tamcamposReg9999[Campo-1];
      break;
 }
 return (tamano);
}

/***********************************************************************/
char *NombreCampo(Tabla, Campo)
int Tabla;
int Campo;
{
char Nombre[30];
strcpy(Nombre,'\0');
char *p_Nombre;
switch (Tabla)
  {
    case 0:  /*REG1000*/
        strcpy(Nombre,camposReg1000[Campo-1]);
      break;

    case 1:  /*REG3000*/
        strcpy(Nombre,camposReg3000[Campo-1]);
      break;

    case 2:  /*REG4000*/
        strcpy(Nombre,camposReg4000[Campo-1]);
      break;

    case 3:  /*REG4100*/
        strcpy(Nombre,camposReg4100[Campo-1]);
      break;

    case 4:  /*REG4200*/
        strcpy(Nombre,camposReg4200[Campo-1]);
      break;

    case 5:   /*REG4300*/
        strcpy(Nombre,camposReg4300[Campo-1]);
      break;

    case 6:  /*REG5000*/
        strcpy(Nombre,camposReg5000[Campo-1]);
      break;
    
    case 7:  /*REG9999*/
        strcpy(Nombre,camposReg9999[Campo-1]);
      break;
 }
 p_Nombre=Nombre;
 return (p_Nombre);
}
/***********************************************************************/
int validaTabla(tabla)
char tabla[];
{
  int i;
  for (i=0;i<9;i++ )
  {
    if (strcmp(tabla,TablasReg[i])==0)
    {
      return (i);
    }
  }
  return (-1);
}
/***********************************************************************/
char *QueryValora(Query, TablaQry, CampoQry, ValQry, RegQry)
int Query;
char TablaQry[];
char CampoQry[];
char ValQry[];
char RegQry[];
{
  char Consulta[1000];
  char *p_Consulta;
  switch (Query)
  {
  case 1:
      strcpy(Consulta,'\0');
      strcat(Consulta,"select count(*) from ");
      strcat(Consulta,TablaQry);
      strcat(Consulta," where outgoingIncomingErrorCode <> '      ' ");
    break;
  case 2:
      strcpy(Consulta,'\0');
      strcat(Consulta,"INSERT MTCPRO02(pro_nomLogi,pro_nomFisi,pro_fecha,pro_estatus,pro_est_usu,pro_mensaje\
                       ,pro_accion,pro_ref_num) \
                       SELECT pro_nomLogi, pro_nomFisi, getdate(), 20, 0, 'CORREGIDO','Volver a Generar CDF'\
                       ,pro_ref_num FROM MTCPRO02 \
                       WHERE pro_fecha = (select max(pro_fecha) from MTCPRO02) AND pro_estatus = 9 ");
    break;
  case 3:
      strcpy(Consulta,'\0');
      sprintf(Consulta,"UPDATE %s SET %s = '%s', outgoingIncomingErrorCode = '      ' \
                        WHERE convert(int,inputFileRecordNumber)= %s", TablaQry, CampoQry, ValQry, RegQry);
    break;
  }
  p_Consulta=Consulta;
  return (p_Consulta);
}
/***********************************************************************/
int CS_PUBLIC err_handler(dbproc, severity, dberr, oserr, dberrstr, oserrstr)

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
		fprintf (ERR_CH, "DB-Library error:\n\t%s\n", dberrstr);

		if (oserr != DBNOERR)
	       	   fprintf (ERR_CH, "Operating-system error:\n\t%s\n", oserrstr);
		return(INT_CANCEL);
	}
}

int CS_PUBLIC msg_handler(dbproc, msgno, msgstate, severity, msgtext, 
                srvname, procname, line)

DBPROCESS       *dbproc;
DBINT           msgno;
int             msgstate;
int             severity;
char            *msgtext;
char            *srvname;
char            *procname;
int     	line;
{
 if ((msgno != 5701) && (msgno != 5703))                                 
   {                                                                       
    if (severity == 16)                                                    
      {                                                                    
       printf("FechaProceso: %s\n", fechayhora);                         
       printf("Nombre Programa: valoraMTC.c \n");                              
       printf("Error %ld, Nivel severidad %d, Estado %d\n", msgno, severity,msgstate);
       printf("Mensaje error: \n%s\n", msgtext);                           
       printf("Se ejecutaba el sql: \n%s\n", sqlcmd);                      
       exit(1);                                                            
      }
   }
   return(0);
}
