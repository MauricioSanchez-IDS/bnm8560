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
** Nombre: cam9999.h
** 
** Elaborado por : Jose Rios Arellano            
**
** Historial/Modificaciones
**
** 001 28/dic/2000 Creación de este header para el manejo de campos en 
** las variables de los programas para la elaboración del archivo CDF.  
**  para el registro 9999.
** 002 06/feb/2001 Modificacion al nombre tenia cam9000.h y debe ser
** cam9999.h JRGD. 
*/

/**
  *	Para el manejo de Formatos!
  **/
#define FRMA1 "%-1s"
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
#define FRMA23 "%-23s"
#define FRMA24 "%-24s"
#define FRMA25 "%-25s"
#define FRMA35 "%-35s"
#define FRMA40 "%-40s"

#define FRMN1 "%+01s"
#define FRMN3 "%+03s"
#define FRMN5 "%+05s"
#define FRMN6 "%+06s"
#define FRMN8 "%+08s"
#define FRMN11 "%+011s"
#define FRMN16 "%+016s"

/**
  *		Fin de la Declaracion de Formatos
  **/


#define RECORDIDENTIFIER 4
#define ISSUERICA 11
#define ISSUERNUMBERICA 11
#define RESERVEDFORINTERNALUSE1 19
#define RESERVEDFORINTERNALUSE2 3
#define RESERVEDFORINTERNALUSE3 17
#define RESERVEDFORINTERNALUSE4 6
#define NUMBEROFRECORDSINTHISFILE 6
#define INPUTFILERECORDNUMBER 6
#define OUTGOINGINCOMINGERRORCODE 6

char recordidentifier[RECORDIDENTIFIER + 1];
char issuerica[ISSUERICA + 1];
char issuernumberica[ISSUERNUMBERICA + 1];
char reservedforinternaluse1[RESERVEDFORINTERNALUSE1 + 1];
char reservedforinternaluse2[RESERVEDFORINTERNALUSE2 + 1];
char reservedforinternaluse3[RESERVEDFORINTERNALUSE3 + 1];
char reservedforinternaluse4[RESERVEDFORINTERNALUSE4 + 1];
char numberofrecordsinthisfile[NUMBEROFRECORDSINTHISFILE + 1];
char inputfilerecordnumber[INPUTFILERECORDNUMBER + 1];
char outgoingincomingerrorcode[OUTGOINGINCOMINGERRORCODE + 1];

