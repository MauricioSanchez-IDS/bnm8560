/*
**      EISSA Header
**      Propiedad de EISSA.
**      (c) Copyright EISSA. 2000.
**      All rights reserved.
**
**
** El uso, copiado, o distribuci�n de este c�digo esta sujeto a restricciones 
** y protegido por Technical Data and Computer Software para EISSA. 
** 
** Nombre: cam1000.h
** 
** Elaborado por : Ing. Jos� Ram�n Gonz�lez D�az 
**
** Historial/Modificaciones
**
** 001 15/dic/2000 Creaci�n de este header para el manejo de campos en 
** las variables de los programas para la elaboraci�n del archivo CDF.  
**  para el registro 1000. 
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
#define REJECTIONLEVEL 1
#define PROVIDINGFROMDATE 17
#define PROVIDINGTODATE 17
#define RUNMODEINDICATOR 1
#define FILEREFERENCENUMBER 24
#define CUSTUMERPROCESSORNUMBER 5
#define CUSTUMERPROCESSORNAME 35
#define CDFVERSIONNUMBER 4
#define INPUTFILERECORDNUMBER 6
#define OUTGOINGINCOMINGERRORCODE 6

char recordidentifier[RECORDIDENTIFIER + 1];
char issuerica[ISSUERICA + 1];
char issuernumberica[ISSUERNUMBERICA + 1];
char reservedforinternaluse1[RESERVEDFORINTERNALUSE1 + 1];
char reservedforinternaluse2[RESERVEDFORINTERNALUSE2 + 1];
char reservedforinternaluse3[RESERVEDFORINTERNALUSE3 + 1];
char reservedforinternaluse4[RESERVEDFORINTERNALUSE4 + 1];
char rejectionlevel[REJECTIONLEVEL + 1];
char providingfromdate[PROVIDINGFROMDATE + 1];
char providingtodate[PROVIDINGTODATE + 1];
char runmodeindicator[RUNMODEINDICATOR + 1];
char filereferencenumber[FILEREFERENCENUMBER + 1];
char custumerprocessornumber[CUSTUMERPROCESSORNUMBER + 1];
char custumerprocessorname[CUSTUMERPROCESSORNAME + 1];
char cdfversionnumber[CDFVERSIONNUMBER + 1];
char inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];

