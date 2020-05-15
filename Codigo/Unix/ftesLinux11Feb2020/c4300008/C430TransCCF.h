/* NOMBRE       : C430TransCCF.h                                             */
/* DESCRIPCION  : Definicion de constantes y funciones utilizadas en el      */
/*                programa C430TransCCF.                                     */
/* AUTOR        : Vicente Ferrer Andrade (VFA)                               */
/* COMPANIA     : Softtek                                                    */
/* FECHA        : 26/06/2003                                                 */
/* CONTROL DE                                                                */
/* VERSIONES    : V.1.0                                                      */
/* CONTROL DE MODIFICACION                                                   */
/*      IS      NOMBRE                  FECHA           DESCRIPCION          */
/*     VFA Vicente Ferrer Andrade     26/06/2003     Primera Version         */
/* Copyright Derechos Reservados Banamex S.A. de C.V 2003a                   */
/*   Observaciones:                                                          */
/*                                                                           */

/* Definicion de constantes numericas. */

/* Longitudes de campo. */

#define LEN1 1
#define LEN2 2
#define LEN3 3
#define LEN4 4
#define LEN5 5
#define LEN6 6
#define LEN7 7
#define LEN8 8
#define LEN9 9
#define LEN10 10
#define LEN12 12
#define LEN13 13
#define LEN14 14
#define LEN15 15
#define LEN16 16
#define LEN17 17
#define LEN18 18
#define LEN19 19
#define LEN20 20 
#define LEN23 23 
#define LEN25 25 
#define LEN26 26 
#define LEN30 30 
#define LEN35 35 
#define LEN36 36
#define LEN40 40
#define LEN45 45 
#define LEN50 50 
#define LEN60 60
#define LEN70 70 
#define LEN100 100
#define LEN150 150
#define LEN169 169

#define LEN193 193			  /*FUN 10122004*/
/*#define LEN201 201			FUN 10122004*/

#define LEN255 255 
#define LEN326 326

#define LEN336 336			  /*FUN 10122004*/
#define LEN356 356
/*#define LEN344 344			FUN 10122204*/

#define LEN362 362 
#define LEN507 507 
#define LEN584 584 
#define LEN610 610 
#define LEN630 630 

#define LEN204 204			  /*FUN 10122004*/
#define LEN679 679			/*FUN 10122004*/

#define LEN701 701 
#define LEN799 799 

#define LEN759 759			  /*FUN 10122004*/
/*#define LEN821 821			FUN 10122004*/

#define LEN823 823 
#define LEN834 834 
#define LEN835 835 
#define LEN855 855 
#define LEN885 885 
#define LEN1000 1000
#define LEN5000 5000

/* Formatos de Campos. */

/* Cadena. */

#define FMTSTR    "%s"
#define FMTSLONG1 "%1s"
#define FMTSLLONG2 "%-2s"
#define FMTSLLONG3 "%-3s"
#define FMTSLLONG4 "%-4s"
#define FMTSLLONG5 "%-5s"
#define FMTSLLONG6 "%-6s"
#define FMTSLLONG7 "%-7s"
#define FMTSLLONG8 "%-8s"
#define FMTSLLONG9 "%-9s"
#define FMTSLLONG10 "%-10s"
#define FMTSLLONG12 "%-12s"
#define FMTSLLONG13 "%-13s"
#define FMTSLLONG14 "%-14s"
#define FMTSLLONG15 "%-15s"
#define FMTSLLONG16 "%-16s"
#define FMTSLLONG17 "%-17s"
#define FMTSLLONG18 "%-18s"
#define FMTSLLONG19 "%-19s"
#define FMTSLLONG20 "%-20s" 
#define FMTSLLONG23 "%-23s" 
#define FMTSLLONG25 "%-25s" 
#define FMTSLLONG26 "%-26s" 
#define FMTSLLONG30 "%-30s" 
#define FMTSLLONG35 "%-35s" 
#define FMTSLLONG40 "%-40s" 
#define FMTSLLONG50 "%-50s" 
#define FMTSLLONG60 "%-60s" 
#define FMTSLLONG100 "%-100s"
#define FMTSLLONG150 "%-150s"
#define FMTSLLONG169 "%-169s"

#define FMTSLLONG193 "%-193s"			  /*FUN 10122004*/
/*#define FMTSLLONG201 "%-201s"				FUN 10122004*/

#define FMTSLLONG204 "%-204s"			  /*FUN 20122004*/	
#define FMTSLLONG326 "%-326s"

#define FMTSLLONG336 "%-336s"			  /*FUN 10122004*/
/*#define FMTSLLONG344 "%-344s"				FUN 10122004*/

#define FMTSLLONG356 "%-356s"                     /*IERM 13052005*/
#define FMTSLLONG362 "%-362s" 
#define FMTSLLONG507 "%-507s" 
#define FMTSLLONG584 "%-584s" 
#define FMTSLLONG610 "%-610s" 
#define FMTSLLONG630 "%-630s" 

#define FMTSLLONG204 "%-204s" 			  /*FUN 10122004*/
#define FMTSLLONG679 "%-679s"				/*FUN 10122004*/

#define FMTSLLONG701 "%-701s" 
#define FMTSLLONG799 "%-799s" 

#define FMTSLLONG759 "%-759s"  			  /*FUN 10122004*/
/*#define FMTSLLONG821 "%-821s"				FUN 10122004*/

#define FMTSLLONG823 "%-823s" 
#define FMTSLLONG834 "%-834s" 
#define FMTSLLONG835 "%-835s" 
#define FMTSLLONG855 "%-855s" 
#define FMTSLLONG885 "%-885s" 
#define FMTSRLONG2 "%2s"
#define FMTSRLONG3 "%3s"
#define FMTSRLONG4 "%4s"
#define FMTSRLONG5 "%5s"
#define FMTSRLONG6 "%6s"
#define FMTSRLONG7 "%7s"
#define FMTSRLONG8 "%8s"
#define FMTSRLONG9 "%9s"
#define FMTSRLONG10 "%10s"
#define FMTSRLONG12 "%12s"
#define FMTSRLONG13 "%13s"
#define FMTSRLONG14 "%14s"
#define FMTSRLONG15 "%15s"
#define FMTSRLONG16 "%16s"
#define FMTSRLONG17 "%17s"
#define FMTSRLONG18 "%18s"
#define FMTSRLONG19 "%19s"
#define FMTSRLONG20 "%20s" 
#define FMTSRLONG23 "%23s" 
#define FMTSRLONG25 "%25s" 
#define FMTSRLONG26 "%26s" 
#define FMTSRLONG30 "%30s" 
#define FMTSRLONG35 "%35s" 
#define FMTSRLONG40 "%40s" 
#define FMTSRLONG50 "%50s" 
#define FMTSRLONG60 "%60s" 
#define FMTSRLONG100 "%100s"
#define FMTSRLONG150 "%150s"
#define FMTSRLONG169 "%169s"
#define FMTSRLONG201 "%201s" 
#define FMTSRLONG326 "%326s"
#define FMTSRLONG344 "%344s" 
#define FMTSRLONG362 "%362s" 
#define FMTSRLONG507 "%507s" 
#define FMTSRLONG584 "%584s" 
#define FMTSRLONG610 "%610s" 
#define FMTSRLONG630 "%630s" 
#define FMTSRLONG679 "%679s" 
#define FMTSRLONG701 "%701s" 
#define FMTSRLONG799 "%799s" 
#define FMTSRLONG821 "%821s" 
#define FMTSRLONG823 "%823s" 
#define FMTSRLONG834 "%834s" 
#define FMTSRLONG835 "%835s" 
#define FMTSRLONG855 "%855s" 
#define FMTSRLONG885 "%885s"

/* Constantes de Cadena para Registros. */

#define FMTREC0000 "0000"
#define FMTREC1000 "1000"
#define FMTREC1001 "1001"
#define FMTREC2000 "2000"
#define FMTREC2001 "2001"
#define FMTREC5000 "5000"
#define FMTREC6000 "60"
#define FMTREC9000 "9000"
#define FMTTYPEIND1 "000"
#define FMTTYPEIND2 "100"
#define FMTTYPEIND3 "110"
#define FMTTYPEIND4 "200"
#define FMTTYPEIND5 "210"
#define FMTTYPEIND6 "500"
#define FMTTYPEIND7 "01"
#define FMTTYPEIND8 "02"
#define FMTTYPEIND9 "04"
#define FMTTYPEIND10 "05"
#define FMTTYPEIND11 "900"
#define FMTSUBCOID "000"       /* Se rellena con blancos, no ceros, IERM Mayo 12, 2005*/
#define FMTCCFVER "1.1.1"
#define FMTHIERID "R"
#define FMTBMX "BNX" 
#define FMTCOUNTRY "MEXICO"    /* CADENA DE PAIS JAGG */
#define FMTMBCURR "MXN"
#define FMTIAMEXCURR "484"
#define FMTIAUSACURR "840"
#define FMTUSACURR "USD"
#define FMTNUMCARDS "01"
#define FMTCOACCNUM "C"
#define FMTSTAACC " " 
#define FMTMEXDESC "MEX"
#define FMTUSADESC "USA"
#define FMTUSACTRY "US"
#define FMTMEXCTRY "MX"
#define FMTMEX3PWB "MX "
#define FMTUSA3PWB "US "
#define FMTCREDTRAN "C"
#define FMTDEBTRAN "D"
#define FMTDBCRFLAG1 "1"
#define FMTDBCRFLAG2 "2"
#define FMTVATEVFLAG "N"
#define FMTMEMOFLAG "M"
#define FMTCADZERO "0"			/*fun cadena 0   10/01/2005*/

/* Numericos. */

#define FMTZERO      0
#define FMTZEROFLOAT 0.0
#define FMT100PERC   100.0
#define FMTINT       "%d"
#define FMTFLO       "%f"
#define FMTCUR       "%0.2f"
#define FMT4DEC      "%0.4f"
#define FMT5DEC      "%05.0f"
#define FMTCURLONG4  "%04.1f"
#define FMTCURLONG7  "%07.2f"
#define FMTCURLONG12 "%012.2f"
#define FMTCURLONG13 "%013.2f"
#define FMTCONVRATE  "%-14f"
#define FMTCURLONG15 "%015.4f"
#define FMTCURLONG18 "%018.2f"
#define FMTCURLONG18D "%018.2lf"
#define FMTNZLONG2   "%-2d"
#define FMTNZLONG3   "%-3d"
#define FMTNZLONG4   "%-4d"
#define FMTNZLONG6   "%-6d"
#define FMTNZLONG8   "%-8d"
#define FMTNZLONG9   "%-9d" 
#define FMTNZLONG10  "%-10d"
#define FMTNLONG10   "%-10d"   /* Formato alineado a la izquierda para codogo postal JAGG **/
#define FMTNZLONG12  "%-12d"
#define FMTNZLONG15  "%-15d"
#define FMTNZLONG16  "%-16d"
#define FMTNZLONG18  "%-18d"
#define FMTNZLONG25  "%-25d"   
#define FMTTEL18     "%018s"

/* Formatos con Zero, IERM MAYO 12, 2005  */

#define FMTZLONG1   "%01d"
#define FMTZLONG2   "%02d"
#define FMTZLONG3   "%03d"
#define FMTZLONG4   "%04d"
#define FMTZLONG5   "%05ld"
#define FMTZLONG6   "%06d"
#define FMTZLONG8   "%08d"
#define FMTZLONG9   "%09d"
#define FMTZLONG10  "%010d"
#define FMTZLONG12  "%012d"
#define FMTZLONG15  "%015d"
#define FMTZLONG16  "%016d"
#define FMTZLONG18  "%018d"
#define FMTZLONG25  "%025d"

#define FMTZIPLONG18 "%016d00"
#define FMTADDKEY50 "%s%s%s%s"

#define FMTSZLONG18 "%018s"

#define FMTPLADATE   "%ld01"
#define FMTTRANSREF  "%07d%016.0f"
#define FMTMERCHREF  "%07d%016.0f00"
#define FMTPREFGPO   "%d%d"
#define FMTNBLONG6   "%-6d"    /* Formato numerico relleno de blancos para 6 posiciones - IERM*/

#define FMTNUMLONG2 "%+02s"


/* Usos diversos. */

#define ERREXIT -1    /* Salida de aplicacion con estatus de error. */ 
#define STDEXIT 0     /* Salida de aplicacion con exito. */ 
#define DEBUG1  1     /* Para analisis de salidas. */
#define DEBUG2  2     /* Para ejecucion de porciones de codigo. */ 
#define EOLN   '\0'   /* Fin de linea. */
#define EMPSTR "\0"   /* Cadena Vacia. */
#define TYPESTR "E"      /* Cadena Con el Tipo de Empresa */
#define TYPESTRC "C"
#define TYPESTRI "I"
#define SPACE " "     /* Cadena con Espacio en Blanco. */
#define DIAG '/'      /* Diagonal. */
#define COMMA ','     /* Coma. */
#define SPACEC ' '    /* Espacio en Blanco (caracter). */ 


#ifdef DEBUG1 
#undef DEBUG1 
#endif

#ifdef DEBUG2 
#undef DEBUG2 
#endif 

/* Macro para deteccion de espacios en blanco. */
 
#define ISWORDSPACE(c) (c == ' ' || c == '\t')

/* Estructuras. */

/* Descripcion de Estatus de Tarjetas de Credito. */

#define SIZE9 9 

struct strStatus {
   char sStaCode[LEN1+1];
   char sStaDesc[LEN25+1];
};

static struct strStatus strPlaStatus[SIZE9] =
{
   {" ", "Normal"},
   {"B", "Inicio etapa de credito"},
   {"C", "Cancelado sin saldo"},
   {"E", "Cancelado con saldo"},
   {"F", "Canc. con saldo y cobro"},
   {"L", "Extravio"},
   {"P", "Problemas de cobro"},
   {"S", "En sucursal"},
   {"U", "Robada"}
};

/* Registro 0000. */

struct strRecord0000 {
   char sRecordID[LEN4+1];
   char sTypeID[LEN3+1];
   char sCompName[LEN100+1];
   char sCompID[LEN6+1];
   char sSubCompID[LEN3+1];
   char sEffecFileDate[LEN8+1];
   char sCCFVersion[LEN5+1];
   char sCompNameKanjiShiftOUT[LEN1+1];			/* FUN 10122004 */
   char sCompNameKanji[LEN60+1];				/* FUN 10122004 */
   char sCompNameKanjiShiftIN[LEN1+1];			/* FUN 10122004 */
   char sFiller[LEN759+1];			/* FUN 10122004    original    char sFiller[LEN821+1];*/
   char sTRXContData[LEN50+1];
};

typedef struct strRecord0000 Record0000;

/* Registro 1000 100. */

struct strRecord1100 {
   char sRecordID[LEN4+1];
   char sTypeID[LEN3+1];
   char sCompID[LEN6+1];
   char sSubCompID[LEN3+1];
   char sCorpParentNode[LEN50+1];
   char sCorpChildNode[LEN50+1];
   char sDepth[LEN10+1];
   char sLevelName[LEN50+1];
   char sHierType[LEN10+1];
   char sAccCodeID[LEN10+1];
   char sCurrSicTemp[LEN15+1];
   char sFutSicTemp[LEN15+1];
   char sReportTemp[LEN15+1]; 
   char sTextSetTemp[LEN15+1];
   char sExcepTemp[LEN15+1];
   char sFiller[LEN679+1];			   
   char sTRXContData[LEN50+1];
};

typedef struct strRecord1100 Record1100;

/* Registro 1001 110. */

struct strRecord1001 {
   char sRecordID[LEN4+1];
   char sTypeID[LEN3+1];
   char sCompID[LEN6+1];
   char sSubCompID[LEN3+1];
   char sNodeID[LEN50+1];
   char sAccNumber[LEN50+1];
   char sFiller[LEN834+1];
   char sTRXContData[LEN50+1];
};

typedef struct strRecord1001 Record1001;

/* Registro 2000 200. */

struct strRecord2200 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sProcessor[LEN3+1];  
   char sAccNumber[LEN25+1]; 
   char sAccType[LEN1+1]; 
   char sLastName[LEN25+1];
   char sCardHFirstN[LEN25+1];
   char sCardHMidN[LEN20+1];
   char sAddrLine1kanjiShiftOUT[LEN1+1];		/* FUN 10122004 */
   char sAddrLine1[LEN40+1];					/* FUN 10122004 */
   char sAddrLine1kanjiShiftIN[LEN1+1];			/* FUN 10122004 */
   char sAddrLine2kanjiShiftOUT[LEN1+1];		/* FUN 10122004 */
   char sAddrLine2[LEN40+1];					/* FUN 10122004 */
   char sAddrLine2kanjiShiftIN[LEN1+1];			/* FUN 10122004 */
   char sAddrLine3kanjiShiftOUT[LEN1+1];		/* FUN 10122004 */
   char sAddrLine3[LEN40+1];					/* FUN 10122004 */
   char sAddrLine3kanjiShiftIN[LEN1+1];			/* FUN 10122004 */
   char sAddrLine4SO[LEN1+1];					/* FUN 10122004 */
   char sAddrLine4[LEN40+1];					/* FUN 10122004 */
   char sAddrLine4SI[LEN1+1];					/* FUN 10122004 */
   char sAddrLine5[LEN40+1];
   char sCity[LEN25+1];
   char sStaCoPro[LEN25+1];
   char sPostalCode[LEN10+1];
   char sCountry[LEN20+1];
   char sNatID[LEN30+1];
   char sTelNumber[LEN18+1];
   char sWorkTelNumber[LEN18+1];
   char sIDVerifCode[LEN15+1];
   char sBirthDay[LEN8+1];
   char sCycleCode[LEN2+1];
   char sFaxNumber[LEN18+1];
   char sEmailAddr[LEN60+1];
   char sEmployeeID[LEN20+1];
   char sCliIDCustNum[LEN20+1];
   char sCustVATNum[LEN20+1];
   char sKanjiNameKanjiShiftOUT[LEN1+1];		/* FUN 10122004 */
   char sKanjiNameKanji[LEN50+1];				/* FUN 10122004 */
   char sKanjiNameKanjiShiftIN[LEN1+1];			/* FUN 10122004 */
   char sAddrLine4kanjiShiftOUT[LEN1+1];		/* FUN 10122004 */
   char sAddrLine4kanji[LEN60+1];				/* FUN 10122004 */
   char sAddrLine4kanjiShiftIN[LEN1+1];			/* FUN 10122004 */
   char sFiller[LEN204+1];						/* FUN 10122004    original   char sFiller[LEN326+1];*/
   char sTRXContData[LEN50+1];
};

typedef struct strRecord2200 Record2200;

/* Registro 2001 210. */

struct strRecord2001 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sProcessor[LEN3+1];  
   char sAccNumber[LEN25+1];
   char sContBillVirt[LEN25+1];
   char sMastAccCode[LEN150+1];
   char sCityPairCode[LEN1+1];
   char sTaxExemptNum[LEN20+1];
   char sTaxExemptFlag[LEN1+1];
   char sTaxExemptSta[LEN3+1];
   char sNumCards[LEN2+1];
   char sOpenDate[LEN8+1];
   char sCredRat[LEN2+1];
   char sCredLim[LEN18+1]; 
   char sSingTranLim[LEN18+1];
   char sPrimEmbName[LEN30+1];
   char sEmbLegend[LEN26+1];
   char sCardActDate[LEN8+1];
   char sLastPayDate[LEN8+1];
   char sBillCurr[LEN3+1];
   char sCurrBalance[LEN18+1];
   char sPayAmtDue[LEN18+1];
   char sPayDueDate[LEN8+1];
   char sTransRoutNum[LEN9+1];
   char sDDANumber[LEN25+1];
   char sAuthStatus[LEN4+1];
   char sNewCardInd[LEN1+1];
   char sNewCardSerNum[LEN20+1];
   char sLastMaintDate[LEN8+1];
   char sPinReqFlag[LEN1+1];
   char sBillType[LEN1+1];
   char sTransfAcc[LEN25+1];
   char sTransfSta[LEN1+1];
   char sTransfReason[LEN1+1];
   char sTransfDate[LEN8+1];
   char sChargeOffSta[LEN1+1];
   char sChargeOffDate[LEN8+1];				/* fun 10122004   original  char sChargeOffDate[LEN6+1];*/
   char sChargeOffBal[LEN18+1];
   char sChargeOffReason[LEN1+1];
   char sOthAccNBR[LEN25+1];
   char sCVRStatus[LEN1+1];
   char sCashAdvLim[LEN18+1];
   char sCashAdvLimFreq[LEN3+1];
   char sEcsAccountStatus[LEN1+1];				/*fun 10122004 */
   char sEcsBlockCode[LEN1+1];					/*fun 10122004 */
   char sEcsBlockReason[LEN2+1];				/*fun 10122004 */
   char sPreviewBalance[LEN18+1];
   char sNumberOfCyclesPastDue[LEN2+1];			/*fun 10122004 */
   char sFiller[LEN356+1];						/*fun 10122004    original  char sFiller[LEN344+1];*/
   char sTRXContData[LEN50+1];
};

typedef struct strRecord2001 Record2001;

/* Registro 2002 211. */

struct strRecord2211 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN25+1];
   char sFDRAccType[LEN1+1];
   char sAmtPayCyc[LEN18+1];
   char sAmtMiscChrCyc[LEN18+1];
   char sAmtPastDue130[LEN18+1];
   char sSecPinDeact[LEN1+1];
   char sDateLastNonMon[LEN8+1];
   char sLastCRDate[LEN8+1];
   char sReissControl[LEN1+1];
   char sDateLastPla[LEN8+1];
   char sLastTranCode[LEN4+1];
   char sDDAFlag[LEN1+1];
   char sFiller[LEN823+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord2211 Record2211;

/* Registro 2002 212. */

struct strRecord2212 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN25+1];
   char sSerNum[LEN20+1];
   char sOldCardSerNum[LEN20+1];
   char sMainCardSerNum[LEN20+1];
   char sAccLevSerNum[LEN20+1];
   char sAddrSerNum[LEN20+1];
   char sCardSeqNum[LEN15+1];
   char sProdName[LEN20+1];
   char sVirtCardFG[LEN15+1];
   char sIntProfSerNum[LEN20+1];
   char sFeeProfSerNum[LEN20+1];
   char sTransProfSerNum[LEN20+1];
   char sRewProfSerNum[LEN20+1];
   char sLatePaySerNum[LEN20+1];
   char sBankName[LEN20+1];
   char sBankBranchName[LEN20+1];
   char sBankAccName[LEN40+1];
   char sDirDebFlag[LEN1+1];
   char sDirDebFixAmt[LEN18+1];
   char sDirDebPercAmt[LEN18+1];
   char sDirDebComb[LEN2+1];
   char sMinAmtToPay[LEN18+1];
   char sMinPercToPay[LEN3+1];
   char sMinPayComb[LEN7+1];
   char sPosition[LEN30+1];
   char sHolSerNum[LEN20+1];
   char sNextStmDate[LEN8+1];
   char sAuthCurr[LEN3+1];
   char sOverAllAutLim[LEN18+1];
   char sOverAllAutPer[LEN3+1];
   char sCashLim[LEN18+1];
   char sCashTransLim[LEN7+1];
   char sCashRepPer[LEN2+1];
   char sSmtTrigBal[LEN18+1];
   char sTebBonus[LEN18+1];
   char sVIPBonus[LEN18+1];
   char sVIPRefFlag[LEN1+1];
   char sTempAuthBonus[LEN18+1];
   char sTempBonExDate[LEN8+1];
   char sFinStatus[LEN4+1];
   char sReissCount[LEN3+1];
   char sReissDate[LEN8+1];
   char sExpiryDate[LEN8+1];
   char sCostCentre[LEN20+1];
   char sCostCentreDesc[LEN20+1];
   char sLocation[LEN60+1];
   char sBusinessUnit[LEN30+1];
   char sFiller[LEN169+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord2212 Record2212;

/* Registro 2002 213. */

struct strRecord2213 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN25+1];
   char sDiscCode[LEN15+1];
   char sTravID[LEN1+1];
   char sVoyStatus[LEN1+1];
   char sDrivVehFlag[LEN1+1];
   char sFleetBillOpt[LEN1+1];
   char sGerAccNum[LEN19+1];
   char sShortName[LEN15+1];
   char sUserField1[LEN5+1];
   char sUserField2[LEN5+1];
   char sUserField3[LEN5+1];
   char sForAddrFlag[LEN1+1];
   char sCompanyNum[LEN5+1];
   char sFiller[LEN835+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord2213 Record2213;

/* Registro 5000 500. */

struct strRecord5500 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sCBSTRRunDate[LEN8+1];
   char sAccNumber[LEN25+1];
   char sTransDate[LEN8+1];
   char sTransTime[LEN8+1];
   char sPostDate[LEN8+1];
   char sTransAmt[LEN18+1];
   char sAuthReq[LEN1+1];
   char sAuthID[LEN6+1];
   char sConversDate[LEN8+1];
   char sPosEntry[LEN12+1];
   char sPosCondCode[LEN2+1];
   char sAcquirerID[LEN15+1];
   char sReferenceNum[LEN23+1];
   char sTraceNumber[LEN6+1];
   char sTransCurrCD[LEN3+1];
   char sTransID[LEN15+1];
   char sMCC[LEN4+1];
   char sMCCInfoData[LEN19+1];
   char sMerchAccepId[LEN16+1];
   char sMerchDescrip[LEN40+1];
   char sMerchantCity[LEN15+1];
   char sMerchantStaProv[LEN5+1];
   char sMerchantPostCod[LEN10+1];
   char sMerchCountry[LEN3+1];
   char sMerchVatNumber[LEN20+1];
   char sMerchDescFlag[LEN1+1];
   char sMerchRefNumber[LEN25+1];
   char sSourceCurr[LEN3+1];
   char sSourceAmt[LEN18+1];
   char sBillCurrency[LEN3+1];
   char sBillAmt[LEN18+1];
   char sSettlemCurr[LEN3+1];
   char sSettlemAmt[LEN18+1];
   char sUSDollarCurr[LEN3+1];
   char sUSDollarAmt[LEN18+1];
   char sGBPoundCurr[LEN3+1];
   char sGBPoundAmt[LEN18+1];
   char sEuroCurr[LEN3+1];
   char sEuroAmt[LEN18+1];
   char sAsiaYenCurr[LEN3+1];
   char sAsiaYenAmt[LEN18+1];
   char sSwedKronCurr[LEN3+1];
   char sSwedKronAmt[LEN18+1];
   char sCanadianCurr[LEN3+1];
   char sCanadianAmt[LEN18+1];
   char sConvRate[LEN14+1];
   char sDBCRFlag[LEN1+1];
   char sMemoFlag[LEN1+1];
   char sCorpAcctNum[LEN25+1];
   char sSalesTax[LEN18+1];
   char sSalesTaxFlag[LEN1+1];
   char sVATTax[LEN18+1];
   char sVATTaxFlag[LEN1+1];
   char sPurchaseID[LEN25+1];
   char sPurchIDFlag[LEN1+1];
   char sTranType[LEN1+1];
   char sNumAddendums[LEN4+1];
   char sVisaTranCode[LEN4+1];
   char sAddendumKey[LEN50+1];
   char sTicketNumber[LEN15+1];
   char sMsgType[LEN4+1];
   char sFiller1[LEN1+1];
   char sVATEvidenceFlag[LEN1+1];
   char sCustRefNum[LEN17+1];
   char sDiscountAmt[LEN18+1];
   char sBillingDate[LEN8+1];						/*fun 10122004*/
   char sFiller2[LEN193+1];							/*fun 10122004    original    char sFiller2[LEN201+1]; */
   char sTRXContData[LEN50+1];
};

typedef struct strRecord5500 Record5500;

/* Registro 5001 511. */

struct strRecord5511 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN25+1];
   char sTranCode[LEN4+1];
   char sAuditTrailDate[LEN8+1];
   char sJulianPostDate[LEN5+1];
   char sRunSeqNum[LEN7+1];
   char sFiller[LEN885+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord5511 Record5511;

/* Registro 5001 512. */

struct strRecord5512 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN25+1];
   char sTranCode[LEN4+1];
   char sSerialNum[LEN20+1];
   char sCardSerNum[LEN20+1];
   char sPosID[LEN8+1];
   char sSerNumInterest[LEN20+1];
   char sTotalPoints[LEN18+1];
   char sLinktrxnSerNum[LEN20+1];
   char sFiller[LEN799+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord5512 Record5512;

/* Registro 5001 513. */

struct strRecord5513 {        
   char sRecordID[LEN4+1];    
   char sTypeID[LEN3+1];      
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN25+1];
   char sTranCode[LEN4+1];
   char sMerchICA[LEN4+1];
   char s1099Status[LEN1+1];
   char sMinoritySta[LEN4+1];
   char sFleetAccNum[LEN19+1];
   char sTermEntryMode[LEN2+1];
   char sMailPhoneInd[LEN1+1];
   char sMPSKey[LEN15+1];
   char sMinorityCode[LEN4+1];
   char sFiller[LEN855+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord5513 Record5513;

/* Registro 6001. */

struct strScales {
   char sAirlineStopOver[LEN1+1];   
   char sDestination[LEN5+1];       
   char sAirlineCarrierCode[LEN2+1];
   char sAirlineServClass[LEN1+1];  
   char sFlightNum[LEN5+1];         
};

typedef struct strScales Scales;

struct strRecord6001 {        
   char sRecordID[LEN2+1];
   char sAddDetRecType[LEN2+1];
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN16+1];
   char sMessageID[LEN15+1];
   char sReferenceNum[LEN23+1];
   char sTotalFareAmt[LEN12+1];
   char sTotalTaxAmt[LEN12+1];
   char sNatTaxAmt[LEN12+1];
   char sTotalFeeAmt[LEN12+1];
   char sAirlineTicketNum[LEN15+1];
   char sExchgTicketNum[LEN13+1];
   char sExchgTicketAmt[LEN12+1];
   Scales Record6001Scales[LEN16];
   char sTravelAgencyCode[LEN8+1];
   char sTravelAgencyName[LEN25+1];
   char sPassengerName[LEN20+1];
   char sDepartDate[LEN6+1];
   char sOrigCode[LEN3+1];
   char sInternetInd[LEN1+1];
   char sElectTicketInd[LEN1+1];
   char sFiller[LEN507+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord6001 Record6001;

/* Registro 6002. */

struct strRecord6002 {        
   char sRecordID[LEN2+1];
   char sAddDetRecType[LEN2+1];
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN16+1];
   char sPurchDetSeqNum[LEN3+1];
   char sOrderDate[LEN6+1];
   char sDestZipCode[LEN10+1];
   char sDestCountryCode[LEN3+1];
   char sOrigZipCode[LEN10+1];
   char sFreightAmt[LEN13+1];
   char sFreightVATTaxAmt[LEN12+1];
   char sFreightVATTaxRate[LEN4+1];
   char sCommodityCode[LEN15+1];
   char sDescription[LEN35+1];
   char sProductCode[LEN12+1];
   char sQuantity[LEN15+1];
   char sUnitMeasure[LEN12+1];
   char sUnitCost[LEN15+1];
   char sVATTaxAmt[LEN12+1];
   char sVATTaxRate[LEN4+1];
   char sUniqVATInvRefNum[LEN15+1];
   char sDiscPerLineItem[LEN12+1];
   char sLineItemTotal[LEN12+1];
   char sFiller[LEN701+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord6002 Record6002;

/* Registro 6004. */

struct strRecord6004 {        
   char sRecordID[LEN2+1];
   char sAddDetRecType[LEN2+1];
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN16+1];
   char sPurchDetSeqNum[LEN3+1];
   char sPropTelNumber[LEN10+1];
   char sCustServPhoneNum[LEN10+1];
   char sCheckInDate[LEN8+1];
   char sCheckOutDate[LEN8+1];
   char sNoShowInd[LEN1+1];
   char sTotalAuthAmt[LEN13+1];
   char sPrepExpenses[LEN7+1];
   char sNumRoomNights[LEN12+1];
   char sDailyRoomRate[LEN12+1];
   char sVATTaxAmt[LEN12+1];
   char sVATTaxRate[LEN12+1];
   char sRoomTaxAmt[LEN12+1];
   char sUniqVATInvRefNum[LEN15+1];
   char sDiscountAmt[LEN12+1];
   char sFoodBeverageCharge[LEN12+1];
   char sCashAdvances[LEN12+1];
   char sValetParkCharges[LEN12+1];
   char sMiniBarCharges[LEN12+1];
   char sLaundryCharges[LEN12+1];
   char sPhoneCharges[LEN12+1];
   char sGiftShopCharges[LEN12+1];
   char sMovieCharges[LEN12+1];
   char sBusinessCenterCharges[LEN12+1];
   char sHealthClubCharges[LEN12+1];
   char sOtherCharges[LEN12+1];
   char sTotalNonRoomCharges[LEN12+1];
   char sFiller[LEN630+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord6004 Record6004;

/* Registro 6005. */

struct strRecord6005 {        
   char sRecordID[LEN2+1];
   char sAddDetRecType[LEN2+1];
   char sCompID[LEN6+1];      
   char sSubCompID[LEN3+1]; 
   char sAccNumber[LEN16+1];
   char sPurchDetSeqNum[LEN3+1];
   char sRentAgreemtNum[LEN25+1];
   char sRenterName[LEN40+1];
   char sLocReturnCity[LEN25+1];
   char sReturnStaCount[LEN3+1];
   char sCarClassCode[LEN2+1];
   char sNoShowInd[LEN1+1];
   char sCheckOutDate[LEN8+1];
   char sCheckInDate[LEN6+1];
   char sInsurIndicator[LEN1+1];
   char sInsurCharges[LEN12+1];
   char sTotalMiles[LEN5+1];
   char sNumberDaysRented[LEN2+1];
   char sDailyRate[LEN12+1];
   char sVATTaxAmt[LEN12+1];
   char sVATTaxRate[LEN4+1];
   char sUniqVATInvRefNum[LEN15+1];
   char sWeeklyRate[LEN12+1];
   char sRatePerMile[LEN12+1];
   char sOneWayDropOffCharge[LEN12+1];
   char sRegMileageCharge[LEN12+1];
   char sExtraMileageCharge[LEN12+1];
   char sMaxFreeMiles[LEN5+1];
   char sLateRetChargeHourRate[LEN12+1];
   char sFuelCharge[LEN12+1];
   char sTelCharges[LEN12+1];
   char sAutoTowCharges[LEN12+1];
   char sExtraCharges[LEN12+1];
   char sOtherCharges[LEN12+1];
   char sDiscountAmt[LEN12+1];
   char sLineItemTotal[LEN12+1];
   char sFiller[LEN584+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord6005 Record6005;

/* Registro 9000. */

struct strRecord9000 {        
   char sRecordID[LEN4+1];
   char sTypeID[LEN3+1];
   char sCompName[LEN100+1];
   char sCompID[LEN6+1];
   char sSubCompID[LEN3+1];
   char sEffecFileDate[LEN8+1];
   char sType1000RecCnt[LEN18+1];
   char sType1001RecCnt[LEN18+1];
   char sType2000RecCnt[LEN18+1];
   char sType2001RecCnt[LEN18+1];
   char sType2002RecCnt[LEN18+1];
   char sType5000RecCnt[LEN18+1];
   char sType5000TotVal[LEN18+1];
   char sType5001RecCnt[LEN18+1];
   char sType6001RecCnt[LEN18+1];
   char sType6002RecCnt[LEN18+1];
   char sType6004RecCnt[LEN18+1];
   char sType6005RecCnt[LEN18+1];
   char sFiller[LEN610+1]; 
   char sTRXContData[LEN50+1];
};

typedef struct strRecord9000 Record9000;

/* Empresas. */  
                      
struct strCompany {
   int  iPreffix;             
   int  iBankGroup;           
   int  iCompanyID;           
   char sCompanyName[LEN45+1];
   int  iChargeOffDate;       
   int  iFileType;            
   char sBillType[LEN1+1];    
   int  iPayDate;             
};

typedef struct strCompany Company;

/* Unidades. */

struct strUnit {
   int  iPreffix;
   int  iBankGroup;
   int  iCompanyID;
   char sUniUnitID[LEN15+1];  
   char sUniUnitPID[LEN15+1]; 
   char sUniUnitName[LEN40+1];
   int  iUniLevelNum;         
};

typedef struct strUnit Unit;

/* Ejecutivos. */

struct strExecutive {
   int  iPreffix;
   int  iBankGroup;
   int  iCompanyID;
   char sUniUnitID[LEN15+1];  
   int  iExeExeNum;
   char sExeName[LEN45+1];
   char sExeAddress1[LEN35+1];
   char sExeAddress2[LEN25+1];
   char sExeCity[LEN25+1];
   char sExeState[LEN4+1];
   int  iExePostalCode;
   char sExeTelNumber[LEN10+1];
   char sExeOfficeNum[LEN10+1];
   char sExeFaxNum[LEN15+1];
   char sExeRFC[LEN13+1];
   char sExeEmail[LEN70+1];
   char sExeEmpNum[LEN15+1];
   char sExeMAccCode[LEN40+1];
   int  iExeOpenDate;
   int  iExeCredLim;
   char sExeEmbName[LEN26+1];
   int  iExeLastMaintDate;
   int  iExePerCashLim;
};

typedef struct strExecutive Executive;

/* Tarjetahabientes. */

struct strCardHolder {
   int   iPreffix;
   int   iBankGroup;
   int   iCompanyID;
   int   iExeExeNum;
   int   iCardHRollOver;
   int   iCardHDigit;
   char  sCardHRating[LEN1+1];
   int   iCardHLastPayDate;
   double dCardHPayAmtDue;
   double dCardHChargeOffBal;
   double dCardHPreviewBal;
   double dCardHCurrBal;
};

typedef struct strCardHolder CardHolder;

/* Transacciones. */

struct strTransaction {
   int   iPreffix;
   int   iBankGroup;
   int   iCompanyID;
   int   iExeExeNum;
   int   iCardHRollOver;
   int   iCardHDigit;
   int   iHisTransDate;
   int   iHisTransTime;
   int   iHisPostDate;
   double dHisTransAmount;
   int   iHisReference1;
   double dHisReference2;
   int   iHisTransID;
   int   iCodeSBF;
   int   iHisMerchAcepID;
   char  sHisMerchDesc[LEN26+1];
   char  sHisMerchStaPro[LEN14+1];
   char  sHisMerchCountry[LEN3+1];
   double dHisDollars;
};

typedef struct strTransaction Transaction;

/* Encabezado de Transacciones. */

struct strHeaderTran {
   int   iPreffix;
   int   iBankGroup;
   int   iCompanyID;
   int   iExeExeNum;
   int   iCardHRollOver;
   int   iCardHDigit;
   double dHihCurrBalance;
   double dHihPrevBalance;
};

typedef struct strHeaderTran HeaderTran;

/* Transacciones de Gastos de Avion. */

struct strAirlineTran {
   int   iPreffix;
   int   iBankGroup;
   int   iCompanyID;
   int   iExeExeNum;
   int   iCardHRollOver;
   int   iCardHDigit;
   int   iMessageID;
   char  sHisRefNumber[LEN23+1];
   double dAirTotFareAmt;             
   double dAirTotTaxAmt;              
   double dAirNatTaxAmt;              
   double dAirTotFeeAmt;              
   char  sAirTicketNum[LEN15+1];     
   char  sAirExchgTicketNum[LEN13+1];
   char  sAirExchgTicketAmt[LEN12+1];
   char  sAirTraAgenCode[LEN8+1];    
   char  sAirTraAgenName[LEN25+1];   
   char  sAirPassName[LEN20+1];      
   int   iAirDepartDate;             
   char  sAirOrigCode[LEN3+1];       
   char  sAirInternetInd[LEN1+1];    
   char  sAirElectTicketNum[LEN1+1]; 
};

typedef struct strAirlineTran AirlineTran;

/* Escalas asociadas a un grupo de Vuelos. */

struct strScalesGroup {
   int  iPreffix;
   int  iBankGroup;
   int  iCompanyID;
   int  iExeExeNum;
   int  iCardHRollOver;
   int  iCardHDigit;
   int  iMessageID;
   char sHisRefNumber[LEN23+1];
   char sAirlineStopOver[LEN1+1];
   char sDestination[LEN5+1];
   char sAirlineCarrierCode[LEN2+1];
   char sAirlineServClass[LEN1+1];
   char sFlightNum[LEN5+1];
};

typedef struct strScalesGroup ScalesGroup;

/* Transacciones de Compras. */

struct strPurchasingTran {
   int   iPreffix;
   int   iBankGroup;
   int   iCompanyID;
   int   iExeExeNum;
   int   iCardHRollOver;
   int   iCardHDigit;
   int   iMessageID;
   char  sHisRefNumber[LEN23+1];
   int   iPurDetSeqNum;
   int   iPurOrderDate;
   char  sPurDestZipCode[LEN10+1];
   char  sPurDestCountry[LEN3+1];
   char  sPurOrigZipCode[LEN10+1];
   double dPurFreightAmt;
   double dPurFreightVATTaxAmt;
   double dPurFreightVATTaxRat;
   char  sPurCommCode[LEN15+1];
   char  sPurDescription[LEN35+1];
   char  sPurProductCode[LEN12+1];
   double dPurQuantity;
   char  sPurUnitMeasure[LEN12+1];
   double dPurUnitCost;
   double dPurVATTaxAmt;
   double dPurVATTaxRat;
   char  sPurVATInvRefNum[LEN15+1];
   double dPurDiscPerItem;
   double dPurLineItemTot;
};

typedef struct strPurchasingTran PurchasingTran;

/* Transacciones de Hospedaje. */

struct strLodgingTran {
   int   iPreffix;
   int   iBankGroup;
   int   iCompanyID;
   int   iExeExeNum;
   int   iCardHRollOver;
   int   iCardHDigit;
   int   iMessageID;
   char  sHisRefNumber[LEN23+1];
   int   iLodDetSeqNum;
   char  sLodPropTelNumber[LEN10+1];
   char  sLodCustTelNumber[LEN10+1];
   int   iLodCheckInDate;
   int   iLodCheckOutDate;
   char  sLodNoShowInd[LEN1+1];
   double dLodTotAutAmt;
   double dLodPrepaidExp;
   int   iLodNumRoomNights;
   double dLodDayRoomRate;
   double dLodVATTaxAmt;
   double dLodVATTaxRate;
   double dLodRoomTaxAmt;
   char  sLodVATInvRefNum[LEN15+1];
   double dLodDiscAmt;
   double dLodFoodBevCharges;
   double dLodCashAdv;
   double dLodValParkCharges;
   double dLodMiniBarCharges;
   double dLodLaundryCharges;
   double dLodPhoneCharges;
   double dLodGiftShopCharges;
   double dLodMovieCharges;
   double dLodBusCentCharges;
   double dLodHeaClubCharges;
   double dLodOtherCharges;
   double dLodTotNonRoomCharges;
};

typedef struct strLodgingTran LodgingTran;


/* Transacciones de Renta de Auto(s). */

struct strRentCarTran {
   int   iPreffix;
   int   iBankGroup;
   int   iCompanyID;
   int   iExeExeNum;
   int   iCardHRollOver;
   int   iCardHDigit;
   int   iMessageID;
   char  sHisRefNumber[LEN23+1];
   int  iCarDetSeqNum;
   char sCarRentAgreeNum[LEN25+1];
   char sCarRentName[LEN40+1];
   char sCarRetCity[LEN25+1];
   char sCarRetStaCtry[LEN3+1];
   char sCarClassCode[LEN2+1];
   char sCarNoShowInd[LEN1+1];
   int  iCarCheckOutDate;
   int  iCarCheckInDate;
   char sCarInsInd[LEN1+1];
   double dCarInsCharges;
   double dCarTotMiles;
   int  iCarNumDaysRent;
   double dCarDailyRate;
   double dCarVATTaxAmt;
   double dCarVATTaxRate;
   char sCarVATInvRefNum[LEN15+1];
   double dCarWeeklyRate;
   double dCarRatePerMile;
   double dCarOneWayDropOff;
   double dCarRegMilCharge;
   double dCarExtMilCharge;
   double dCarMaxFreeMiles;
   double dCarLateRetCharge;
   double dCarFuelCharge;
   double dCarTelCharge;
   double dCarTowCharge;
   double dCarExtCharges;
   double dCarOthCharges;
   double dCarDiscAmt;
   double dCarLineItemTot;
};

typedef struct strRentCarTran RentCarTran;


/* Definicion de prototipos de funciones. */

#if defined(__cplusplus)
extern "C" {            
#endif                  
                        
#ifdef _PROTOTYPES      

   void error_handler();
   void warning_handler();
   int  iC430GetData_CCF(char *[]);
   char *psElimChar(char *, char);
   char *psInt2Char(int);
   void GenRecord0000(Record0000 *, char *, int, char *);
   void SaveRecord0000(Record0000 *, FILE *);
   void GenRecord1100(Record1100 *, int, int, int, char *, char *, char *, int);
   void SaveRecord1100(Record1100 *, FILE *);
   void GenRecord1001(Record1001 *, int, char *, char *);
   void SaveRecord1001(Record1001 *, FILE *);
   void GenRecord2200(Record2200 *, int, char *, char *, char *, char *,
                   char *, char *, char *, char *, int, char *, 
                   char *, char *, int, char *, 
                   char *, char *);
   void SaveRecord2200(Record2200 *, FILE *);
   void GenRecord2001(Record2001 *, int, char *, char *,char *, int, char *, 
                   int, char *, char *, int, int, double, double, double,
                   char *, int, char *, char *, char *, double, char *, int); 
   void SaveRecord2001(Record2001 *, FILE *);
   void GenRecord5500(Record5500 *, int, char *, int, int, int,
                   double, int, double, int, int, char *, int, char *,
                   char *, char *, double, char *, char *, char *,char *, int );
   void SaveRecord5500(Record5500 *, FILE *);
   void GenRecord6001(Record6001 *, int, char *, int, int, double, double,
                     double, double, double, char *, char *, char *,
                     Scales *, char *, char *, char *, int, char *,
                     char *, char *);
   void SaveRecord6001(Record6001 *, FILE *);
   void GenRecord6002(Record6002 *, int, char *, int, int, char *, char *,
                      char *, double, double, double, char *, char *, char *,
                      double, char *, double, double, double, char *, double,
                      double);
   void SaveRecord6002(Record6002 *, FILE *);
   void GenRecord6004(Record6004 *, int, char *, int, char *,
                      char *, int, int, char *, double, double,
                      int, double, double, double, double, char *,
                      double, double, double, double, double, double,
                      double, double, double, double, double, double,
                      double);
   void SaveRecord6004(Record6004 *, FILE *);
   void GenRecord6005(Record6005 *, int, char *, int, char *, char*,
                      char *, char *, char *, char *, int, int,
                      char *, double, double, int, double, double, double,
                      char *, double, double, double, double, double,
                      double, double, double, double, double, double, double,
                      double, double);
   void SaveRecord6005(Record6005 *, FILE *); 
   void GenRecord9000(Record9000 *, char *, int, char *, int, int,
                      int, int, int, int, double, int, int, int, 
                      int, int);
   void SaveRecord9000(Record9000 *, FILE *);
   char *psGetLastName(char *);
   void GetNames(char *[], char *, char *, int *, char *);
   int  iCompareComp(const void *, const void *);
   void iImplicitPoint( char *pNumber );
   void fillStr( char *source, char *dest, char fill, int size );
   void quitaBlancos(char *cadena);

#else
                                              
   void error_handler();
   void warning_handler();
   int  iC430GetData_CCF();
   char *psElimChar(char *,char);
   char *psInt2Char();
   void GenRecord0000();
   void SaveRecord0000();
   void GenRecord1100();
   void SaveRecord1100();
   void GenRecord1001(); 
   void SaveRecord1001();
   void GenRecord2200();
   void SaveRecord2200();
   void GenRecord2001();
   void SaveRecord2001();
   void GenRecord5500();
   void SaveRecord5500();
   void GenRecord6001();
   void SaveRecord6001();
   void GenRecord6002();
   void SaveRecord6002();
   void GenRecord6004();
   void SaveRecord6004();
   void GenRecord6005();
   void SaveRecord6005();
   void GenRecord9000();
   void SaveRecord9000();
   char *psGetLastName();
   void  GetNames();
   int  iCompareComp();
   void iImplicitPoint( );
   void fillStr(char *,char *,char,int);
   void quitaBlancos();
#endif                  
                        
#if defined(__cplusplus)
}                       
#endif

/* Variables para conversion de Numeros Reales
   a Enteros (Funcion fcvt). */

int   iRadPos;   /* Posicion del punto decimal. */
int   iSign;     /* Signo. */                      
