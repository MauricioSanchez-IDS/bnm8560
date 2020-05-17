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
** Nombre: cam3000.h
** 
** Elaborado por : Jose Rios Arellano 
**
** Historial/Modificaciones
**
** 001 28/dic/2000 Creación de este header para el manejo de campos en 
** las variables de los programas para la elaboración del archivo CDF.  
**  para el registro 3000. 
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
#define RESERVEDFORINTERNALUSE1 19
#define RESERVEDFORINTERNALUSE2 3
#define RESERVEDFORINTERNALUSE3 17
#define RESERVEDFORINTERNALUSE4 6
#define ISSUERNAMELINE1 35
#define ISSUERNAMELINE2 35
#define ADDRESSLINE1 35
#define ADDRESSLINE2 35
#define CITY 20
#define STATEPROVINCE 3
#define COUNTRY 3
#define POSTALCODE 10
#define CURRENCY 3
#define CONTACTPERSON 35
#define PHONENUMBER 25
#define FAXNUMBER 25
#define EMAILADDRESS 50
#define ADDRESSMAINTENANCEACTION 1
#define INPUTFILERECORDNUMBER 6
#define OUTGOINGINCOMINGERRORCODE 6

char recordidentifier[RECORDIDENTIFIER + 1];
char issuerica[ISSUERICA + 1];
char issuernumberica[ISSUERNUMBERICA + 1];
char reservedforinternaluse1[RESERVEDFORINTERNALUSE1 + 1];
char reservedforinternaluse2[RESERVEDFORINTERNALUSE2 + 1];
char reservedforinternaluse3[RESERVEDFORINTERNALUSE3 + 1];
char reservedforinternaluse4[RESERVEDFORINTERNALUSE4 + 1];
char issuernameline1[ISSUERNAMELINE1 + 1];
char issuernameline2[ISSUERNAMELINE2 + 1];
char addressline1[ADDRESSLINE1 + 1];
char addressline2[ADDRESSLINE2 + 1];
char city[CITY + 1];
char stateprovince[STATEPROVINCE + 1];
char country[COUNTRY + 1];
char postalcode[POSTALCODE + 1];
char currency[CURRENCY + 1];
char contactperson[CONTACTPERSON + 1];
char phonenumber[PHONENUMBER + 1];
char faxnumber[FAXNUMBER + 1];
char emailaddress[EMAILADDRESS + 1];
char addressmaintenanceactioncode[ADDRESSMAINTENANCEACTION + 1];
char inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];

DBCHAR recordIdentifier[RECORDIDENTIFIER + 1];
DBCHAR issuerIca[ISSUERICA + 1];
DBCHAR issuerNumberIca[ISSUERNUMBERICA + 1];
DBCHAR reservedForInternalUse1[RESERVEDFORINTERNALUSE1 + 1];
DBCHAR reservedForInternalUse2[RESERVEDFORINTERNALUSE2 + 1];
DBCHAR reservedForInternalUse3[RESERVEDFORINTERNALUSE3 + 1];
DBCHAR reservedForInternalUse4[RESERVEDFORINTERNALUSE4 + 1];
DBCHAR issuerNameLine1[ISSUERNAMELINE1 + 1];
DBCHAR issuerNameLine2[ISSUERNAMELINE2 + 1];
DBCHAR addressLine1[ADDRESSLINE1 + 1];
DBCHAR addressLine2[ADDRESSLINE2 + 1];
DBCHAR City[CITY + 1];
DBCHAR stateProvince[STATEPROVINCE + 1];
DBCHAR Country[COUNTRY + 1];
DBCHAR postalCode[POSTALCODE + 1];
DBCHAR Currency[CURRENCY + 1];
DBCHAR contactPerson[CONTACTPERSON + 1];
DBCHAR phoneNumber[PHONENUMBER + 1];
DBCHAR faxNumber[FAXNUMBER + 1];
DBCHAR emailAddress[EMAILADDRESS + 1];
DBCHAR addressMaintenanceAction[ADDRESSMAINTENANCEACTION + 1];
DBCHAR inputFileRecordNumber[INPUTFILERECORDNUMBER + 1];
DBCHAR outgoingIncomingErrorCode[OUTGOINGINCOMINGERRORCODE + 1];
DBCHAR addressMaintenanceActionCode[ADDRESSMAINTENANCEACTION + 1];
