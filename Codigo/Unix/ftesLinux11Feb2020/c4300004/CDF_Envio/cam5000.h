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
** Nombre: cam5000.h
** 
** Elaborado por : Ing. José Ramón González Díaz 
**
** Historial/Modificaciones
**
** 001 15/dic/2000 Creación de este header para el manejo de campos en 
** las variables de los programas para la elaboración del archivo CDF.  
**  para el registro 5000. 
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
#define FRMA23 "%-23s"
#define FRMA24 "%-24s"
#define FRMA25 "%-25s"
#define FRMA35 "%-35s"
#define FRMA40 "%-40s"
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
#define ADDENDUMTYPE 3
#define RESERVEDFORINTERNALUSE1 17
#define RESERVEDFORINTERNALUSE2 6
#define MERCHANTACTTRANORIGININD 1
#define ACCOUNTNUMBER 19
#define RESERVEDFORINTERNALUSE3 10
#define ACQUIRERSORISSUERSREFNUM 23
#define RECORDTYPE 1
#define TRANSACTIONTYPE 1
#define DEBITCREDITINDICATOR 1
#define TRANSACTIONAMOUNT 16
#define POSTINGDATE 8
#define TRANSACTIONDATE 8
#define PROCESSINGDATE 8
#define MERCHANTNAME 25
#define MERCHANTCITY 13
#define MERCHANTSTATEPROVINCE 3
#define MERCHANTCOUNTRY 3
#define MERCHANTCATEGORYCODE 4
#define AMOUNTINORIGINALCURRENCY 16
#define ORIGINALCURRENCYCODE 3
#define CURRCONVDATEJULIAN 5
#define POSTEDCURRENCYCODE 3
#define CONVERSIONRATE 16
#define CONVERSIONEXPONENT 1
#define ACQUIRINGICA 11			/*Se actualiz'o de 4 a 11, IERM Sept. 15, 2004*/
#define CUSTOMERCODE 17
#define SALESTAXAMOUNT 16
#define RESERVEDFORINTERNALUSE4 1
#define RESERVEDFORINTERNALUSE5 5
#define FREIGHTAMOUNT 16
#define DESTINATIONPOSTALCODE 10
#define MERCHANTTYPE 4
#define MERCHANTLOCATIONPOSTALCODE 10
#define DUTYAMOUNT 16
#define MERCHANTFEDERALTAXID 15
#define MERCHANTSTATEPROVINCECODE 3
#define SHIPFROMPOSTALCODE 10
#define ALTERNATETAXAMOUNT 16
#define DESTINATIONCOUNTRYCODE 3
#define MERCHANTREFERENCENUMBER 17
#define ALTERNATETAXINDICATOR 1
#define ALTERNATETAXIDENTIFIER 15
#define SALESTAXCOLLECTEDIND_POS 1
#define ADDENDUMDETAILINDICATOR 1
#define MERCHANTID 15
#define BANKNETREFERENCENUMBER 12		/*Nuevo campo Insertado, IERM Sept. 14, 2004*/
#define APPROVALCODE 6 				/*Nuevo Campo Insertado, IERM Sept. 14, 2004*/
#define ADJUSTMENTREASONCODE 5
#define ADJUSTMENTDESCRIPTION 40
#define MAINTENANCEACTIONCODE 1
#define INPUTFILERECORDNUMBER 6
#define OUTGOINGINCOMINGERRORCODE 6

char recordidentifier[RECORDIDENTIFIER + 1];
char issuerica[ISSUERICA + 1];
char issuernumberica[ISSUERNUMBERICA + 1];
char corporationnumber[CORPORATIONNUMBER + 1];
char addendumtype[ADDENDUMTYPE + 1];
char reservedforinternaluse1[RESERVEDFORINTERNALUSE1 + 1];
char reservedforinternaluse2[RESERVEDFORINTERNALUSE2 + 1];
char merchantacttranoriginind[MERCHANTACTTRANORIGININD + 1];
char accountnumber[ACCOUNTNUMBER + 1];
char reservedforinternaluse3[RESERVEDFORINTERNALUSE3 + 1];
char acquirersorissuersrefnum[ACQUIRERSORISSUERSREFNUM + 1];
char recordtype[RECORDTYPE + 1];
char transactiontype[TRANSACTIONTYPE + 1];
char debitcreditindicator[DEBITCREDITINDICATOR + 1];
char transactionamount[TRANSACTIONAMOUNT + 1];
char postingdate[POSTINGDATE + 1];
char transactiondate[TRANSACTIONDATE + 1];
char processingdate[PROCESSINGDATE + 1];
char merchantname[MERCHANTNAME + 1];
char merchantcity[MERCHANTCITY + 1];
char merchantstateprovince[MERCHANTSTATEPROVINCE + 1];
char merchantcountry[MERCHANTCOUNTRY + 1];
char merchantcategorycode[MERCHANTCATEGORYCODE + 1];
char amountinoriginalcurrency[AMOUNTINORIGINALCURRENCY + 1];
char originalcurrencycode[ORIGINALCURRENCYCODE + 1];
char currconvdatejulian[CURRCONVDATEJULIAN + 1];
char postedcurrencycode[POSTEDCURRENCYCODE + 1];
char conversionrate[CONVERSIONRATE + 1];
char conversionexponent[CONVERSIONEXPONENT + 1];
char acquiringica[ACQUIRINGICA + 1];
char customercode[CUSTOMERCODE + 1];
char salestaxamount[SALESTAXAMOUNT + 1];
char reservedforinternaluse4[RESERVEDFORINTERNALUSE4 + 1];
char reservedforinternaluse5[RESERVEDFORINTERNALUSE5 + 1];
char freightamount[FREIGHTAMOUNT + 1];
char destinationpostalcode[DESTINATIONPOSTALCODE + 1];
char merchanttype[MERCHANTTYPE + 1];
char merchantlocationpostalcode[MERCHANTLOCATIONPOSTALCODE + 1];
char dutyamount[DUTYAMOUNT + 1];
char merchantfederaltaxid[MERCHANTFEDERALTAXID + 1];
char merchantstateprovincecode[MERCHANTSTATEPROVINCECODE + 1];
char shipfrompostalcode[SHIPFROMPOSTALCODE + 1];
char alternatetaxamount[ALTERNATETAXAMOUNT + 1];
char destinationcountrycode[DESTINATIONCOUNTRYCODE + 1];
char merchantreferencenumber[MERCHANTREFERENCENUMBER + 1];
char alternatetaxindicator[ALTERNATETAXINDICATOR + 1];
char alternatetaxidentifier[ALTERNATETAXIDENTIFIER + 1];
char salestaxcollectedind_pos[SALESTAXCOLLECTEDIND_POS + 1];
char addendumdetailindicator[ADDENDUMDETAILINDICATOR + 1];
char merchantid[MERCHANTID + 1];
char banknetReferenceNumber[ BANKNETREFERENCENUMBER + 1  ];             /*Nuevo campo Insertado, IERM Sept. 15, 2004*/
char approvalCode[ APPROVALCODE + 1 ];					/*Nuevo campo Insertado, IERM Sept. 15, 2004*/ 
char adjustmentreasoncode[ADJUSTMENTREASONCODE + 1];
char adjustmentdescription[ADJUSTMENTDESCRIPTION + 1];
char maintenanceactioncode[MAINTENANCEACTIONCODE + 1];
char inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];


/* varaibles para almacenara la informacion obtenida de la consulta a la tabla MTC5000 */

DBCHAR mtc5000recordidentifier[RECORDIDENTIFIER + 1];
DBCHAR mtc5000issuerica[ISSUERICA + 1];
DBCHAR mtc5000issuernumberica[ISSUERNUMBERICA + 1];
DBCHAR mtc5000corporationnumber[CORPORATIONNUMBER + 1];
DBCHAR mtc5000addendumtype[ADDENDUMTYPE + 1];
DBCHAR mtc5000reservedforinternaluse1[RESERVEDFORINTERNALUSE1 + 1];
DBCHAR mtc5000reservedforinternaluse2[RESERVEDFORINTERNALUSE2 + 1];
DBCHAR mtc5000merchantacttranoriginind[MERCHANTACTTRANORIGININD + 1];
DBCHAR mtc5000accountnumber[ACCOUNTNUMBER + 1];
DBCHAR mtc5000reservedforinternaluse3[RESERVEDFORINTERNALUSE3 + 1];
DBCHAR mtc5000acquirersorissuersrefnum[ACQUIRERSORISSUERSREFNUM + 1];
DBCHAR mtc5000recordtype[RECORDTYPE + 1];
DBCHAR mtc5000transactiontype[TRANSACTIONTYPE + 1];
DBCHAR mtc5000debitcreditindicator[DEBITCREDITINDICATOR + 1];
DBCHAR mtc5000transactionamount[TRANSACTIONAMOUNT + 1];
DBCHAR mtc5000postingdate[POSTINGDATE + 1];
DBCHAR mtc5000transactiondate[TRANSACTIONDATE + 1];
DBCHAR mtc5000processingdate[PROCESSINGDATE + 1];
DBCHAR mtc5000merchantname[MERCHANTNAME + 1];
DBCHAR mtc5000merchantcity[MERCHANTCITY + 1];
DBCHAR mtc5000merchantstateprovince[MERCHANTSTATEPROVINCE + 1];
DBCHAR mtc5000merchantcountry[MERCHANTCOUNTRY + 1];
DBCHAR mtc5000merchantcategorycode[MERCHANTCATEGORYCODE + 1];
DBCHAR mtc5000amountinoriginalcurrency[AMOUNTINORIGINALCURRENCY + 1];
DBCHAR mtc5000originalcurrencycode[ORIGINALCURRENCYCODE + 1];
DBCHAR mtc5000currconvdatejulian[CURRCONVDATEJULIAN + 1];
DBCHAR mtc5000postedcurrencycode[POSTEDCURRENCYCODE + 1];
DBCHAR mtc5000conversionrate[CONVERSIONRATE + 1];
DBCHAR mtc5000conversionexponent[CONVERSIONEXPONENT + 1];
DBCHAR mtc5000acquiringica[ACQUIRINGICA + 1];
DBCHAR mtc5000customercode[CUSTOMERCODE + 1];
DBCHAR mtc5000salestaxamount[SALESTAXAMOUNT + 1];
DBCHAR mtc5000reservedforinternaluse4[RESERVEDFORINTERNALUSE4 + 1];
DBCHAR mtc5000reservedforinternaluse5[RESERVEDFORINTERNALUSE5 + 1];
DBCHAR mtc5000freightamount[FREIGHTAMOUNT + 1];
DBCHAR mtc5000destinationpostalcode[DESTINATIONPOSTALCODE + 1];
DBCHAR mtc5000merchanttype[MERCHANTTYPE + 1];
DBCHAR mtc5000merchantlocationpostalcode[MERCHANTLOCATIONPOSTALCODE + 1];
DBCHAR mtc5000dutyamount[DUTYAMOUNT + 1];
DBCHAR mtc5000merchantfederaltaxid[MERCHANTFEDERALTAXID + 1];
DBCHAR mtc5000merchantstateprovincecode[MERCHANTSTATEPROVINCECODE + 1];
DBCHAR mtc5000shipfrompostalcode[SHIPFROMPOSTALCODE + 1];
DBCHAR mtc5000alternatetaxamount[ALTERNATETAXAMOUNT + 1];
DBCHAR mtc5000destinationcountrycode[DESTINATIONCOUNTRYCODE + 1];
DBCHAR mtc5000merchantreferencenumber[MERCHANTREFERENCENUMBER + 1];
DBCHAR mtc5000alternatetaxindicator[ALTERNATETAXINDICATOR + 1];
DBCHAR mtc5000alternatetaxidentifier[ALTERNATETAXIDENTIFIER + 1];
DBCHAR mtc5000salestaxcollectedind_pos[SALESTAXCOLLECTEDIND_POS + 1];
DBCHAR mtc5000addendumdetailindicator[ADDENDUMDETAILINDICATOR + 1];
DBCHAR mtc5000merchantid[MERCHANTID + 1];
DBCHAR mtc5000bankNetReferenceNumber[ BANKNETREFERENCENUMBER + 1 ];	/*Nuevo campo Insertado, IERM Sept. 14, 2004*/
DBCHAR mtc5000approvalCode[ APPROVALCODE + 1 ];				/*Nuevo campo Insertado, IERM Sept. 14, 2004*/
DBCHAR mtc5000adjustmentreasoncode[ADJUSTMENTREASONCODE + 1];
DBCHAR mtc5000adjustmentdescription[ADJUSTMENTDESCRIPTION + 1];
DBCHAR mtc5000maintenanceactioncode[MAINTENANCEACTIONCODE + 1];
DBCHAR mtc5000inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
DBCHAR mtc5000outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];
