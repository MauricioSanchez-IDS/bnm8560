#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# NOMBRE	: C430InsertCCF.                                        #
# DESCRIPCION	: Permite ejecutar el proceso encargado de colocar      #
#                 en la Base de Datos del Sistema C430 la informacion   #
#                 contenida en un Archivo Unico en formato CCF (para    #
#                 su posterior validacion).                             #
# PRECEDIDO POR	: C430ValUniqCCF                                        #
#                                                                       #
#			                                                #
# VARIABLES DE			                                        #
# AMBIENTE		: NOMBRE VARIABLE           DESCRIPCION         #
#                            LAPath           Ruta de Ubicacion         # 
#                                             Archivo Unico.            # 
#                            LAFileType       Modo de Generacion del    #
#                                             Archivo CCF Unico.        #
#                            LAFileTypeCode   Clave de Modo de          #
#                                             Generacion del Archivo    #
#                                             Unico.                    #
#                            LAFileName       Nombre del Archivo        #
#                                             Unico.                    #
#                            LADate           Fecha de Generacion del   #
#                                             Archivo (MMDD).           #
#                            LAPreffix        Prefijo asociado al       #
#                                             Archivo.                  #
#                            LASuffix         Sufijo asociado al        #
#                                             Archivo.                  #
#                            LASuffixBCP      Sufijo asociado a         #
#                                             Archivos Bulkcopy.        #
#                            LAUserName       Nombre de Usuario de      #
#                                             UNIX.                     #
#                            LNProcesses      Numero de Instancias      #
#                                             Activas del Programa.     # 
#                            LAPattern        Patron de Busqueda de     #
#                                             Archivos Bulkcopy.        #
#                            LNStatus         Estado de Ejecucion del   #
#                                             Programa.                 #
#                            LATempFile       Archivo Temporal.         #
#                            LATempISQLFile   Archivo Temporal de       #
#                                             resultado de ejecucion de #
#                                             comandos de SQL.          #
#                            LATempRecTypes   Archivo Temporal de Tipos #
#                                             de Registros asociados al #
#                                             Archivo Unico.            #
#                            LAUser           Usuario de Base de Datos. #  
#                            LAPassword       Password de Base de       #
#                                             Datos.                    #
#                            LAServer         Servidor de Base de       #
#                                             Datos.                    #
#                            LAISQLUtil       Nombre del Programa para  #
#                                             Acceso a Base de Datos.   #
#                            LABCPUtil        Nombre del Programa para  #
#                                             carga de datos a tablas   #
#                                             de SYBASE.                #
#                            LADatabase       Nombre de la Base de      #
#                                             Datos del Sistema C430.   #
#                            LAProgram        Nombre del Programa.      #
#                            LNNumRec         Numero de Registros       #
#                                             contenidos en el Archivo  #
#                                             CCF.                      #
# PARAMETROS 	:                                                       #
#                 $0 = Nombre del Programa.                             #
#                 $1 = Ruta de Ubicacion Archivo Unico.                 #
#                 $2 = Fecha de Procesamiento (Parametro Opcional).     #
#                                                                       #
# SALIDAS	:                                                           #
# AUTOR		: Vicente Ferrer Andrade <VFA>                              #
# COMPANIA	: Softtek                                                   #
# FECHA		: 18/08/2003                                                #
# CONTROL DE                                                            #
# VERSIONES	: V.1.0	                                                    #
# CONTROL DE MODIFICACION                                               #
#   IS	      NOMBRE		   FECHA	DESCRIPCION                     #
#  VFA  Vicente Ferrer Andrade  18/08/2003  Primer Version              #
# MODIFICO	: JOSE ALBERTO GARCIA GARCIA                                #
# COMPANIA	: EISSA                                                     #
# FECHA		: 12/08/2004                                                #
# VERSION	: V.2.0	                                                    #
#  Observaciones: Se Hacen Cambios en el manejo de las tablas del CCF   #
#                 ya no son temporales son fijas                        #
# Copyright Derechos Reservados Banamex S.A. de C.V 2003                #

. $(paths.sh 08 PAR)/.variables	  #descomentar en la nueva ruta

LAPath=$1
LAFileType=$FileMode
LAFileTypeCode=""
LAFileName=""
LADate=""
LAPreffix=$PreffixCCF
LASuffix=$SuffixCCF
LASuffixBCP=$SuffixBCP
LAUserName=$UserNameUNIX
LAPattern=""
LNProcesses=0
LNStatus=0
LATempFile=$TempFilePath"TempC430InsertCCF.tmp"
LATempISQLFile=$ISQLFile
LATempRecTypes=$TempFilePath"TempRecTypes.tmp"
LAUser=$UserSYB
LAPassword=$PasswordSYB
LAServer=$ServerSYB
LAISQLUtil=$ISQLUtilSYB
LABCPUtil=$BCPUtilSYB
LADatabase=$DatabaseSYB
LAStatusTab=$StatusTabSYB
LAProgram=$BinPath"C430CreateTempTables"
LNNumRec=0

# Determinar el No. de Parametros de Ejecucion.

case $# in
   2) ;;   # No. de Parametros Correcto.
   *) print "Use: C430InsertCCF.sh <Path> [<Date>]"
      exit 1 ;;
esac

# Eliminar archivos temporales.  
if [[ -f $LATempFile ]]
then
   rm $LATempFile
fi
if [[ -f $LATempISQLFile ]]
then
   rm $LATempISQLFile
fi
if [[ -f $LATempRecTypes ]]
then
   rm $LATempRecTypes
fi

# Determinar el No. de Procesos Activos.
ps -ef | grep $LAUserName | grep $0 | grep "sh -c" | grep -v grep > $LATempFile

LNProcesses=$(wc -l $LATempFile | awk '{ print $1; }')
if [[ -f $LATempFile ]]
then
   rm $LATempFile
fi

if [[ $LNProcesses > 1 ]]   # No puede haber mas de un proceso activo.
then
   print "The process " $0 " is online."
   exit 1
fi

# Establecer la Clave Asociada al Modo de Generacion del Archivo CCF Unico.

if [[ $LAFileType = "0" ]]   # El archivo CCF Unico es Diario.
then
   LAFileTypeCode="D" 
elif [[ $LAFileType = "1" ]]   # El archivo CCF Unico es por Fecha de Corte.
then
   LAFileTypeCode="C"
else
   print "The FileType Parameter's Value is incorrect."
   exit 1
fi

# Establecer la Fecha de Generacion del Archivo Unico.

if [[ -z $2 ]]
then
   LADate=$(date +'%m%d')
else
   LADate=$2
fi 

# Establecer el Nombre del Archivo CCF Unico.

LAFileName=$LAPreffix$LADate$LAFileTypeCode$LASuffix 

# Verificar si el Archivo Unico ya se encuentra disponible.

cd $LAPath

if [[ -f $LAFileName ]]
then
   # Construir el script para eliminar Registros Temporales creados por
   # procesos previos. Y depuracion de Registros con mas de 1 Mes de Antiguedad

   for stabla in CCF0000 CCF1000 CCF1001 CCF2000 CCF2001 CCF5000 CCF6001 CCF6002 CCF6004 CCF6005 CCF9000
   do
     echo "DELETE $stabla where nom_archivo =""'"$LAFileName"'" > $LATempFile
     echo "go" >> $LATempFile
     echo "DELETE $stabla where fec_archivo < dateadd(mm,-1,getdate()) " >> $LATempFile
     echo "go" >> $LATempFile
     chmod 775 $LATempFile
     $LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -D$LADatabase -i$LATempFile -o$LATempISQLFile
     if [[ -a $LATempFile ]]
     then
        rm $LATempFile
     fi
   done
   # Extraer del archivo Unico cada uno de los registros y colocarlos 
   # en archivos temporales de acuerdo a su tipo.
   LAFec=$(date +'%Y%m%d') #fecha del generacion del Archivo yyyymmdd

   awk -v sPreffix=$LAPreffix -v sDate=$LADate -v sSuffix=$LAFileTypeCode -v sNombreA=$LAFileName -v sfec=$LAFec '
        BEGIN {
           sRecord="";         # Registro CCF con formato para Bulkcopy. 
           sRecType="";        # Tipo de Registro CCF.
           sFileName="";       # Nombre del archivo bulkcopy.
           sFileType=".out";   # Extension asociada al archivo bulkcopy. 

           # Datos Generales de un Registro.

           sRecordIndicator="";
           sTypeIndicator="";
           sCompanyName="";
           sCompanyID="";
           sSubCompanyID="";
           sEffectiveFileDate="";
           sTRXControlData="";
           sProcessor="";
           sAccountNumber="";
           sAccountNo="";
           sRecordTypeID="";
           sAddDetailRecType="";
           sPurchDetailSeqNum="";
           sUniqueVATInvRefNo="";
           sVATTaxAmount="";
           sVATTaxRate="";
           sNoShowIndicator="";
           sCheckOutDate="";
           sDiscountAmount="";
           sBillingCurrency="";
           sOtherCharges="";
           sLineItemTotal="";
           sNombreArchivo=sNombreA;
           sFechaArchivo=sfec;

           # Informacion correspondiente al Registro 0000.

           sCCFVersion="";
           sCompNameKanjiShiftOUT="";		# FUN 27122004 
           sCompNameKanji="";			# FUN 27122004 
           sCompNameKanjiShiftIN="";		# FUN 27122004 
           sFiller0000="";

           # Informacion correspondiente al Registro 1000.

           sCorpParentNode="";
           sCorpChildNode="";
           sDepth="";
           sLevelName="";
           sHierarchyType="";
           sAcctCodeID="";
           sCurrSicTemplate="";
           sFutureSicTemplate="";
           sReportTemplate="";
           sTextsetTemplate="";
           sExceptionTemplate="";
           sFiller1100="";

           # Informacion correspondiente al Registro 1001.

           sNodeID="";
           sAccountNumber1001="";
           sFiller1001="";

           # Informacion correspondiente al Registro 2000.

           sAccountType="";
           sLastName="";
           sCardhFirstName="";
           sCardhMiddleName="";
           sAddrLine1kanjiShiftOUT="";		# FUN 27122004 
           sAddressLine1="";
           sAddrLine1kanjiShiftIN="";		# FUN 27122004 
           sAddrLine2kanjiShiftOUT="";		# FUN 27122004 
           sAddressLine2="";
           sAddrLine2kanjiShiftIN="";		# FUN 27122004 
           sAddrLine3kanjiShiftOUT="";		# FUN 27122004 
           sAddressLine3="";
           sAddrLine3kanjiShiftIN="";		# FUN 27122004 
           sAddrLine4SO="";			# FUN 27122004 
           sAddressLine4="";
            sAddrLine4SI="";			# FUN 27122004 
           sAddressLine5="";
           sCity="";
           sStateCountyProvince="";
           sPostalCode="";
           sCountry="";
           sNationalID="";
           sTelephoneNumber="";
           sWorkPhoneNum="";
           sIDVerificationCode="";
           sDateOfBirth="";
           sCycleCode="";
           sFaxNumber="";
           sEMailAddress="";
           sEmployeeID="";
           sClientIDCustomerNumber="";
           sCustomerVATNumber="";
           sKanjiNameKanjiShiftOUT="";		# FUN 27122004 
           sKanjiNameKanji="";			# FUN 27122004 
           sKanjiNameKanjiShiftIN="";		# FUN 27122004 
           sAddrLine4kanjiShiftOUT="";		# FUN 27122004 
           sAddrLine4kanji="";			# FUN 27122004 
           sAddrLine4kanjiShiftIN="";		# FUN 27122004 
           sFiller2000="";

           # Informacion correspondiente al Registro 2001.

           sControlBillingVirtual="";
           sMasterAcctCode="";
           sCityPairCode="";
           sTaxExemptNumber="";
           sTaxExemptFlag="";
           sTaxExemptStatus="";
           sNumCards="";
           sOpenDate="";
           sCreditRating="";
           sCreditLimit="";
           sSingleTranLmt="";
           sPrimEmbossName="";
           sEmbossLegend="";
           sCardActivationDate="";
           sLastPayDate="";
           sCurrentBalance="";
           sPaymentAmtDue="";
           sPaymentDueDate="";
           sTransitRoutingNo="";
           sDDANumber="";
           sAuthStatus="";
           sNewCardInd="";
           sNewCardSerNo="";
           sLastMaintenanceDate="";
           sPinRequestFlag="";
           sBillType="";
           sTransferAccount="";
           sTransferStatus="";
           sTransferReason="";
           sTransferDate="";
           sChargeOffStatus="";
           sChargeOffDate="";
           sChargeOffBalance="";
           sChargeOffReason="";
           sOtherAcctNbr="";
           sCRVStatus="";
           sCashAdvanceLimit="";
           sCashAdvLimitFreq="";
           sEcsAccountStatus="";		#fun 27122004 
           sEcsBlockCode="";			#fun 27122004 
           sEcsBlockReason="";			#fun 27122004 
           sPreviewBalance="";
           sNumberOfCyclesPastDue="";		#fun 27122004 
           sFiller2001="";

           # Informacion correspondiente al Registro 5000.

           sCBSTRRunDate="";
           sTransDate="";
           sTransTime="";
           sPostDate="";
           sTransAmount="";
           sAuthRequired="";
           sAuthID="";
           sConversDate="";
           sPosEntry="";
           sPosCondCode="";
           sAcquirerID="";
           sReferenceNum="";
           sTraceNumber="";
           sTransCurrencyCd="";
           sTransID="";
           sMCC="";
           sMCCInfoData="";
           sMerchAcceptorID="";
           sMerchDescription="";
           sMerchantCity="";
           sMerchantStateProvince="";
           sMerchantPostalCode="";
           sMerchCountry="";
           sMerchantVATNumber="";
           sMerchDescFlag="";
           sMerchantReferenceNumber="";
           sSourceCurrency="";
           sSourceAmount="";
           sBillingAmount="";
           sSettlemCurrency="";
           sSettlemAmount="";
           sUSDollarCurr="";
           sUSDollarAmt="";
           sGBPoundCurr="";
           sGBPoundAmt="";
           sEuroCurrency="";
           sEuroAmount="";
           sAsiaYenCurr="";
           sAsiaYenAmt="";
           sSwedKronCurr="";
           sSwedKronAmt="";
           sCanadianCurr="";
           sCanadianAmt="";
           sConversionRate="";
           sDBCRFlag="";
           sMemoFlag="";
           sCorpAcctNo="";
           sSalesTax="";
           sSalesTaxFlag="";
           sVATTax="";
           sVATTaxFlag="";
           sPurchaseID="";
           sPurchIDFlag="";
           sTranType="";
           sNoOfAddendums="";
           sVisaTranCode="";
           sAddendumKey="";
           sTicketNumber="";
           sMsgType="";
           sFiller1_5000="";
           sVATEvidenceFlag="";
           sCustRefNumber="";
           sDiscAmount="";
           sBillingDate="";		#fun 27122004
           sFiller2_5000="";

           # Informacion correspondiente al Registro 6001.

           sMessageID="";
           sReferenceNumber="";
           sTotalFareAmount="";
           sTotalTaxAmount="";
           sNationalTaxAmount="";
           sTotalFeeAmount="";
           sAirlineTicketNumber="";
           sExchangeTicketNumber="";
           sExchangeTicketAmount="";
           sAirlineStopOver1="";
           sDestination1="";
           sAirlineCarrierCode1="";
           sAirlineServiceClass1="";
           sFlightNumber1="";
           sAirlineStopOver2="";
           sDestination2="";
           sAirlineCarrierCode2="";
           sAirlineServiceClass2="";
           sFlightNumber2="";
           sAirlineStopOver3="";
           sDestination3="";
           sAirlineCarrierCode3="";
           sAirlineServiceClass3="";
           sFlightNumber3="";
           sAirlineStopOver4="";
           sDestination4="";
           sAirlineCarrierCode4="";
           sAirlineServiceClass4="";
           sFlightNumber4="";
           sAirlineStopOver5="";
           sDestination5="";
           sAirlineCarrierCode5="";
           sAirlineServiceClass5="";
           sFlightNumber5="";
           sAirlineStopOver6="";
           sDestination6="";
           sAirlineCarrierCode6="";
           sAirlineServiceClass6="";
           sFlightNumber6="";
           sAirlineStopOver7="";
           sDestination7="";
           sAirlineCarrierCode7="";
           sAirlineServiceClass7="";
           sFlightNumber7="";
           sAirlineStopOver8="";
           sDestination8="";
           sAirlineCarrierCode8="";
           sAirlineServiceClass8="";
           sFlightNumber8="";
           sAirlineStopOver9="";
           sDestination9="";
           sAirlineCarrierCode9="";
           sAirlineServiceClass9="";
           sFlightNumber9="";
           sAirlineStopOver10="";
           sDestination10="";
           sAirlineCarrierCode10="";
           sAirlineServiceClass10="";
           sFlightNumber10="";
           sAirlineStopOver11="";
           sDestination11="";
           sAirlineCarrierCode11="";
           sAirlineServiceClass11="";
           sFlightNumber11="";
           sAirlineStopOver12="";
           sDestination12="";
           sAirlineCarrierCode12="";
           sAirlineServiceClass12="";
           sFlightNumber12="";
           sAirlineStopOver13="";
           sDestination13="";
           sAirlineCarrierCode13="";
           sAirlineServiceClass13="";
           sFlightNumber13="";
           sAirlineStopOver14="";
           sDestination14="";
           sAirlineCarrierCode14="";
           sAirlineServiceClass14="";
           sFlightNumber14="";
           sAirlineStopOver15="";
           sDestination15="";
           sAirlineCarrierCode15="";
           sAirlineServiceClass15="";
           sFlightNumber15="";
           sAirlineStopOver16="";
           sDestination16="";
           sAirlineCarrierCode16="";
           sAirlineServiceClass16="";
           sFlightNumber16="";
           sTravelAgencyCode="";
           sTravelAgencyName="";
           sPassengerName="";
           sDepartureDate="";
           sOriginationCode="";
           sInternetIndicator="";
           sElectTicketInd="";
           sFiller6001="";

           # Informacion correspondiente al Registro 6002.

           sOrderDate="";
           sDestinationZipCode="";
           sDestinationCountryCode="";
           sOriginationZipCode="";
           sFreightAmount="";
           sFreightVATTaxAmount="";
           sFreightVATTaxRate="";
           sCommodityCode="";
           sDescription="";
           sProductCode="";
           sQuantity="";
           sUnitOfMeasure="";
           sUnitCost="";
           sDiscountPerLineItem="";
           sFiller6002="";

           # Informacion correspondiente al Registro 6004.

           sPropTelephoneNumber="";
           sCustServPhoneNum="";
           sCheckInDate="";
           sTotalAuthAmount="";
           sPrepaidExpenses="";
           sNumberOfRoomNights="";
           sDailyRoomRate="";
           sVATTaxRate_6004="";
           sRoomTaxAmount="";
           sFoodAndBeverageCharge="";
           sCashAdvances="";
           sValetParkingCharges="";
           sMiniBarCharges="";
           sLaundryCharges="";
           sPhoneCharges="";
           sGiftShopCharges="";
           sMovieCharges="";
           sBusinessCenterCharges="";
           sHealthClubCharges="";
           sTotalNonRoomCharges="";
           sFiller6004="";

           # Informacion correspondiente al Registro 6005.

           sRentalAgreeNum="";
           sRentersName="";
           sLocOfRetCity="";
           sRetStaCountry="";
           sCarClassCode="";
           sCheckInDate_6005="";
           sInsuranceInd="";
           sInsuranceCharges="";
           sTotalMiles="";
           sNumOfDaysRented="";
           sDailyRate="";
           sWeeklyRate="";
           sRatePerMile="";
           sOneWayDropOffCh="";
           sRegMilCharge="";
           sExtraMilCharge="";
           sMaxFreeMiles="";
           sLateRetChHourRate="";
           sFuelCharge="";
           sTelephoneCharges="";
           sAutoTowingCharges="";
           sExtraCharges="";
           sFiller6005="";

           # Informacion correspondiente al Registro 9000.

           sType1000RecordCount="";
           sType1001RecordCount="";
           sType2000RecordCount="";
           sType2001RecordCount="";
           sType2002RecordCount="";
           sType5000RecordCount="";
           sType5000TotalValue="";
           sType5001RecordCount="";
           sType6001RecordCount="";
           sType6002RecordCount="";
           sType6004RecordCount="";
           sType6005RecordCount="";
           sFiller9000="";
        }
        { 

           sRecType=substr($0, 1, 4);

           # Construye los archivos bulkcopy tomando como referencia el
           # Tipo de Registro.

           if(sRecType == "0000")
           {
              sRecordIndicator=sRecType;
              sTypeIndicator=substr($0, 5, 3);
              sCompanyName=substr($0, 8, 100);
              sCompanyID=substr($0, 108, 6);
              sSubCompanyID=substr($0, 114, 3);
              sEffectiveFileDate=substr($0, 117, 8);
              sCCFVersion=substr($0, 125, 5);
              sCompNameKanjiShiftOUT=substr($0, 130, 1);
              sCompNameKanji=substr($0, 131, 60);
              sCompNameKanjiShiftIN=substr($0, 191, 1);
              sFiller0000=substr($0, 192, 759);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordIndicator, sTypeIndicator,
                              sCompanyName, sCompanyID,
                              sSubCompanyID, sEffectiveFileDate,
                              sCCFVersion, sCompNameKanjiShiftOUT,sCompNameKanji,
                              sCompNameKanjiShiftIN,sFiller0000,
                              sTRXControlData,sNombreArchivo,sFechaArchivo);

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  

           }

           if(sRecType == "1000")
           {
              sRecordIndicator=sRecType;
              sTypeIndicator=substr($0, 5, 3);
              sCompanyID=substr($0, 8, 6);
              sSubCompanyID=substr($0, 14, 3);
              sCorpParentNode=substr($0, 17, 50);
              sCorpChildNode=substr($0, 67, 50);
              sDepth=substr($0, 117, 10);
              sLevelName=substr($0, 127, 50);
              sHierarchyType=substr($0, 177, 10);
              sAcctCodeID=substr($0, 187, 10);
              sCurrSicTemplate=substr($0, 197, 15);
              sFutureSicTemplate=substr($0, 212, 15);
              sReportTemplate=substr($0, 227, 15);
              sTextsetTemplate=substr($0, 242, 15);
              sExceptionTemplate=substr($0, 257, 15);
              sFiller1100=substr($0, 272, 679);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordIndicator, sTypeIndicator,
                              sCompanyID, sSubCompanyID,
                              sCorpParentNode, sCorpChildNode,
                              sDepth, sLevelName, sHierarchyType, 
                              sAcctCodeID, sCurrSicTemplate, 
                              sFutureSicTemplate, sReportTemplate, 
                              sTextsetTemplate, sExceptionTemplate, 
                              sFiller1100, sTRXControlData,sNombreArchivo,sFechaArchivo); 

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }
           
           if(sRecType == "1001")
           {
              sRecordIndicator=sRecType;
              sTypeIndicator=substr($0, 5, 3);
              sCompanyID=substr($0, 8, 6);
              sSubCompanyID=substr($0, 14, 3);
              sNodeID=substr($0, 17, 50);
              sAccountNumber1001=substr($0, 67, 50);
              sFiller1001=substr($0, 117, 834);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordIndicator, sTypeIndicator,
                              sCompanyID, sSubCompanyID,
                              sNodeID, sAccountNumber1001,
                              sFiller1001, sTRXControlData,sNombreArchivo,sFechaArchivo);

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "2000")
           {
              sRecordIndicator=sRecType;
              sTypeIndicator=substr($0, 5, 3);
              sCompanyID=substr($0, 8, 6);
              sSubCompanyID=substr($0, 14, 3);
              sProcessor=substr($0, 17, 3);
              sAccountNumber=substr($0, 20, 25);
              sAccountType=substr($0, 45, 1);
              sLastName=substr($0, 46, 25);
              sCardhFirstName=substr($0, 71, 25);
              sCardhMiddleName=substr($0, 96, 20);
              sAddrLine1kanjiShiftOUT=substr($0, 116, 1);
              sAddressLine1=substr($0, 117, 40);
              sAddrLine1kanjiShiftIN=substr($0, 157, 1);
              sAddrLine2kanjiShiftOUT=substr($0, 158, 1);
              sAddressLine2=substr($0, 159, 40);
              sAddrLine2kanjiShiftIN=substr($0, 199, 1);
              sAddrLine3kanjiShiftOUT=substr($0, 200, 1);
              sAddressLine3=substr($0, 201, 40);
              sAddrLine3kanjiShiftIN=substr($0, 241, 1);
              sAddrLine4SO=substr($0, 242, 1);
              sAddressLine4=substr($0, 243, 40);
              sAddrLine4SI=substr($0, 283, 1);
              sAddressLine5=substr($0, 284, 40);
              sCity=substr($0, 324, 25);
              sStateCountyProvince=substr($0, 349, 25);
              sPostalCode=substr($0, 374, 10);
              sCountry=substr($0, 384, 20);
              sNationalID=substr($0, 404, 30);
              sTelephoneNumber=substr($0, 434, 18);
              sWorkPhoneNum=substr($0, 452, 18);
              sIDVerificationCode=substr($0, 470, 15);
              sDateOfBirth=substr($0, 485, 8);
              sCycleCode=substr($0, 493, 2);
              sFaxNumber=substr($0, 495, 18);
              sEMailAddress=substr($0, 513, 60);
              sEmployeeID=substr($0, 573, 20);
              sClientIDCustomerNumber=substr($0, 593, 20);
              sCustomerVATNumber=substr($0, 613, 20);
              sKanjiNameKanjiShiftOUT=substr($0, 633, 1);
              sKanjiNameKanji=substr($0, 634, 50);
              sKanjiNameKanjiShiftIN=substr($0, 684, 1);
              sAddrLine4kanjiShiftOUT=substr($0, 685, 1);
              sAddrLine4kanji=substr($0, 686, 60);
              sAddrLine4kanjiShiftIN=substr($0, 746, 1);
              sFiller2000=substr($0, 747, 204);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordIndicator, sTypeIndicator,
                              sCompanyID, sSubCompanyID,
                              sProcessor, sAccountNumber,
                              sAccountType, sLastName,
                              sCardhFirstName, sCardhMiddleName,
                              sAddrLine1kanjiShiftOUT, sAddressLine1, 
                              sAddrLine1kanjiShiftIN, sAddrLine2kanjiShiftOUT,
			      sAddressLine2, sAddrLine2kanjiShiftIN,
                              sAddrLine3kanjiShiftOUT, sAddressLine3, 
                              sAddrLine3kanjiShiftIN , sAddrLine4SO,
			      sAddressLine4, sAddrLine4SI,
                              sAddressLine5, sCity,
                              sStateCountyProvince, sPostalCode,
                              sCountry, sNationalID,
                              sTelephoneNumber, sWorkPhoneNum,
                              sIDVerificationCode, sDateOfBirth,
                              sCycleCode, sFaxNumber,
                              sEMailAddress, sEmployeeID,
                              sClientIDCustomerNumber, sCustomerVATNumber,
                              sKanjiNameKanjiShiftOUT, sKanjiNameKanji,
                              sKanjiNameKanjiShiftIN, sAddrLine4kanjiShiftOUT,
                              sAddrLine4kanji, sAddrLine4kanjiShiftIN,
                              sFiller2000, sTRXControlData,sNombreArchivo,sFechaArchivo);

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "2001")
           {
              sRecordIndicator=sRecType;
              sTypeIndicator=substr($0, 5, 3);
              sCompanyID=substr($0, 8, 6);
              sSubCompanyID=substr($0, 14, 3);
              sProcessor=substr($0, 17, 3);
              sAccountNumber=substr($0, 20, 25);
              sControlBillingVirtual=substr($0, 45, 25);
              sMasterAcctCode=substr($0, 70, 150);
              sCityPairCode=substr($0, 220, 1);
              sTaxExemptNumber=substr($0, 221, 20);
              sTaxExemptFlag=substr($0, 241, 1);
              sTaxExemptStatus=substr($0, 242, 3);
              sNumCards=substr($0, 245, 2);
              sOpenDate=substr($0, 247, 8);
              sCreditRating=substr($0, 255, 2);
              sCreditLimit=substr($0, 257, 18);
              sSingleTranLmt=substr($0, 275, 18);
              sPrimEmbossName=substr($0, 293, 30);
              sEmbossLegend=substr($0, 323, 26);
              sCardActivationDate=substr($0, 349, 8);
              sLastPayDate=substr($0, 357, 8);
              sBillingCurrency=substr($0, 365, 3);
              sCurrentBalance=substr($0, 368, 18);
              sPaymentAmtDue=substr($0, 386, 18);
              sPaymentDueDate=substr($0, 404, 8);
              sTransitRoutingNo=substr($0, 412, 9);
              sDDANumber=substr($0, 421, 25);
              sAuthStatus=substr($0, 446, 4);
              sNewCardInd=substr($0, 450, 1);
              sNewCardSerNo=substr($0, 451, 20);
              sLastMaintenanceDate=substr($0, 471, 8);
              sPinRequestFlag=substr($0, 479, 1);
              sBillType=substr($0, 480, 1);
              sTransferAccount=substr($0, 481, 25);
              sTransferStatus=substr($0, 506, 1);
              sTransferReason=substr($0, 507, 1);
              sTransferDate=substr($0, 508, 8);
              sChargeOffStatus=substr($0, 516, 1);
              sChargeOffDate=substr($0, 517, 8);
              sChargeOffBalance=substr($0, 525, 18);
              sChargeOffReason=substr($0, 543, 1);
              sOtherAcctNbr=substr($0, 544, 25);
              sCRVStatus=substr($0, 569, 1);
              sCashAdvanceLimit=substr($0, 570, 18);
              sCashAdvLimitFreq=substr($0, 588, 3);
              sEcsAccountStatus=substr($0, 591, 1);
              sEcsBlockCode=substr($0, 592, 1);
              sEcsBlockReason=substr($0, 593, 2);
              sPreviewBalance=substr($0, 595, 18);
              sNumberOfCyclesPastDue=substr($0, 613, 2);
              sFiller2001=substr($0, 615, 336);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordIndicator, sTypeIndicator,
                              sCompanyID, sSubCompanyID,
                              sProcessor, sAccountNumber,
                              sControlBillingVirtual, sMasterAcctCode,
                              sCityPairCode, sTaxExemptNumber,
                              sTaxExemptFlag, sTaxExemptStatus,
                              sNumCards, sOpenDate,
                              sCreditRating, sCreditLimit,
                              sSingleTranLmt, sPrimEmbossName,
                              sEmbossLegend, sCardActivationDate,
                              sLastPayDate, sBillingCurrency,
                              sCurrentBalance, sPaymentAmtDue,
                              sPaymentDueDate, sTransitRoutingNo,
                              sDDANumber, sAuthStatus,
                              sNewCardInd, sNewCardSerNo,
                              sLastMaintenanceDate, sPinRequestFlag,
                              sBillType, sTransferAccount,
                              sTransferStatus, sTransferReason,
                              sTransferDate, sChargeOffStatus,
                              sChargeOffDate, sChargeOffBalance,
                              sChargeOffReason, sOtherAcctNbr,
                              sCRVStatus, sCashAdvanceLimit,
                              sCashAdvLimitFreq, sEcsAccountStatus,
			      sEcsBlockCode, sEcsBlockReason,
			      sPreviewBalance, sNumberOfCyclesPastDue,
                              sFiller2001, sTRXControlData, sNombreArchivo, sFechaArchivo);

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "2002")
           {

              # Nota: Por el momento, el registro 2002 no sera
              # procesado por la aplicacion.

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "5000")
           {
              sRecordIndicator=sRecType;
              sTypeIndicator=substr($0, 5, 3);
              sCompanyID=substr($0, 8, 6);
              sSubCompanyID=substr($0, 14, 3);
              sCBSTRRunDate=substr($0, 17, 8);
              sAccountNumber=substr($0, 25, 25);
              sTransDate=substr($0, 50, 8);
              sTransTime=substr($0, 58, 8);
              sPostDate=substr($0, 66, 8);
              sTransAmount=substr($0, 74, 18);
              sAuthRequired=substr($0, 92, 1);
              sAuthID=substr($0, 93, 6);
              sConversDate=substr($0, 99, 8);
              sPosEntry=substr($0, 107, 12);
              sPosCondCode=substr($0, 119, 2);
              sAcquirerID=substr($0, 121, 15);
              sReferenceNum=substr($0, 136, 23);
              sTraceNumber=substr($0, 159, 6);
              sTransCurrencyCd=substr($0, 165, 3);
              sTransID=substr($0, 168, 15);
              sMCC=substr($0, 183, 4);
              sMCCInfoData=substr($0, 187, 19);
              sMerchAcceptorID=substr($0, 206, 16);
              sMerchDescription=substr($0, 222, 40);
              sMerchantCity=substr($0, 262, 15);
              sMerchantStateProvince=substr($0, 277, 5);
              sMerchantPostalCode=substr($0, 282, 10);
              sMerchCountry=substr($0, 292, 3);
              sMerchantVATNumber=substr($0, 295, 20);
              sMerchDescFlag=substr($0, 315, 1);
              sMerchantReferenceNumber=substr($0, 316, 25);
              sSourceCurrency=substr($0, 341, 3);
              sSourceAmount=substr($0, 344, 18);
              sBillingCurrency=substr($0, 362, 3);
              sBillingAmount=substr($0, 365, 18);
              sSettlemCurrency=substr($0, 383, 3);
              sSettlemAmount=substr($0, 386, 18);
              sUSDollarCurr=substr($0, 404, 3);
              sUSDollarAmt=substr($0, 407, 18);
              sGBPoundCurr=substr($0, 425, 3);
              sGBPoundAmt=substr($0, 428, 18);
              sEuroCurrency=substr($0, 446, 3);
              sEuroAmount=substr($0, 449, 18);
              sAsiaYenCurr=substr($0, 467, 3);
              sAsiaYenAmt=substr($0, 470, 18);
              sSwedKronCurr=substr($0, 488, 3);
              sSwedKronAmt=substr($0, 491, 18);
              sCanadianCurr=substr($0, 509, 3);
              sCanadianAmt=substr($0, 512, 18);
              sConversionRate=substr($0, 530, 14);
              sDBCRFlag=substr($0, 544, 1);
              sMemoFlag=substr($0, 545, 1);
              sCorpAcctNo=substr($0, 546, 25);
              sSalesTax=substr($0, 571, 18);
              sSalesTaxFlag=substr($0, 589, 1);
              sVATTax=substr($0, 590, 18);
              sVATTaxFlag=substr($0, 608, 1);
              sPurchaseID=substr($0, 609, 25);
              sPurchIDFlag=substr($0, 634, 1);
              sTranType=substr($0, 635, 1);
              sNoOfAddendums=substr($0, 636, 4);
              sVisaTranCode=substr($0, 640, 4);
              sAddendumKey=substr($0, 644, 50);
              sTicketNumber=substr($0, 694, 15);
              sMsgType=substr($0, 709, 4);
              sFiller1_5000=substr($0, 713, 1);
              sVATEvidenceFlag=substr($0, 714, 1);
              sCustRefNumber=substr($0, 715, 17);
              sDiscAmount=substr($0, 732, 18);
              sBillingDate=substr($0, 750, 8);
              sFiller2_5000=substr($0, 758, 193);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordIndicator, sTypeIndicator,
                              sCompanyID, sSubCompanyID,
                              sCBSTRRunDate, sAccountNumber,
                              sTransDate, sTransTime,
                              sPostDate, sTransAmount,
                              sAuthRequired, sAuthID,
                              sConversDate, sPosEntry,
                              sPosCondCode, sAcquirerID,
                              sReferenceNum, sTraceNumber,
                              sTransCurrencyCd, sTransID,
                              sMCC, sMCCInfoData,
                              sMerchAcceptorID, sMerchDescription,
                              sMerchantCity, sMerchantStateProvince,
                              sMerchantPostalCode, sMerchCountry,
                              sMerchantVATNumber, sMerchDescFlag,
                              sMerchantReferenceNumber, sSourceCurrency,
                              sSourceAmount, sBillingCurrency,
                              sBillingAmount, sSettlemCurrency,
                              sSettlemAmount, sUSDollarCurr,
                              sUSDollarAmt, sGBPoundCurr,
                              sGBPoundAmt, sEuroCurrency,
                              sEuroAmount, sAsiaYenCurr,
                              sAsiaYenAmt, sSwedKronCurr,
                              sSwedKronAmt, sCanadianCurr,
                              sCanadianAmt, sConversionRate,
                              sDBCRFlag, sMemoFlag,
                              sCorpAcctNo, sSalesTax,
                              sSalesTaxFlag, sVATTax,
                              sVATTaxFlag, sPurchaseID,
                              sPurchIDFlag, sTranType,
                              sNoOfAddendums, sVisaTranCode,
                              sAddendumKey, sTicketNumber,
                              sMsgType, sFiller1_5000,
                              sVATEvidenceFlag, sCustRefNumber,
                              sDiscAmount, sBillingDate, sFiller2_5000,
                              sTRXControlData,sNombreArchivo,sFechaArchivo);

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "5001")
           {

              # Nota: Por el momento, el registro 5001 no sera
              # procesado por la aplicacion.

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "6001")
           {
              sRecordTypeID=substr($0, 1, 2);
              sAddDetailRecType=substr($0, 3, 2);
              sCompanyID=substr($0, 5, 6);
              sSubCompanyID=substr($0, 11, 3);
              sAccountNo=substr($0, 14, 16);
              sMessageID=substr($0, 30, 15);
              sReferenceNumber=substr($0, 45, 23);
              sTotalFareAmount=substr($0, 68, 12);
              sTotalTaxAmount=substr($0, 80, 12);
              sNationalTaxAmount=substr($0, 92, 12);
              sTotalFeeAmount=substr($0, 104, 12);
              sAirlineTicketNumber=substr($0, 116, 15);
              sExchangeTicketNumber=substr($0, 131, 13);
              sExchangeTicketAmount=substr($0, 144, 12);
              sAirlineStopOver1=substr($0, 156, 1);
              sDestination1=substr($0, 157, 5);
              sAirlineCarrierCode1=substr($0, 162, 2);
              sAirlineServiceClass1=substr($0, 164, 1);
              sFlightNumber1=substr($0, 165, 5);
              sAirlineStopOver2=substr($0, 170, 1);
              sDestination2=substr($0, 171, 5);
              sAirlineCarrierCode2=substr($0, 176, 2);
              sAirlineServiceClass2=substr($0, 178, 1);
              sFlightNumber2=substr($0, 179, 5);
              sAirlineStopOver3=substr($0, 184, 1);
              sDestination3=substr($0, 185, 5);
              sAirlineCarrierCode3=substr($0, 190, 2);
              sAirlineServiceClass3=substr($0, 192, 1);
              sFlightNumber3=substr($0, 193, 5);
              sAirlineStopOver4=substr($0, 198, 1);
              sDestination4=substr($0, 199, 5);
              sAirlineCarrierCode4=substr($0, 204, 2);
              sAirlineServiceClass4=substr($0, 206, 1);
              sFlightNumber4=substr($0, 207, 5);
              sAirlineStopOver5=substr($0, 212, 1);
              sDestination5=substr($0, 213, 5);
              sAirlineCarrierCode5=substr($0, 218, 2);
              sAirlineServiceClass5=substr($0, 220, 1);
              sFlightNumber5=substr($0, 221, 5);
              sAirlineStopOver6=substr($0, 226, 1);
              sDestination6=substr($0, 227, 5);
              sAirlineCarrierCode6=substr($0, 232, 2);
              sAirlineServiceClass6=substr($0, 234, 1);
              sFlightNumber6=substr($0, 235, 5);
              sAirlineStopOver7=substr($0, 240, 1);
              sDestination7=substr($0, 241, 5);
              sAirlineCarrierCode7=substr($0, 246, 2);
              sAirlineServiceClass7=substr($0, 248, 1);
              sFlightNumber7=substr($0, 249, 5);
              sAirlineStopOver8=substr($0, 254, 1);
              sDestination8=substr($0, 255, 5);
              sAirlineCarrierCode8=substr($0, 260, 2);
              sAirlineServiceClass8=substr($0, 262, 1);
              sFlightNumber8=substr($0, 263, 5);
              sAirlineStopOver9=substr($0, 268, 1);
              sDestination9=substr($0, 269, 5);
              sAirlineCarrierCode9=substr($0, 274, 2);
              sAirlineServiceClass9=substr($0, 276, 1);
              sFlightNumber9=substr($0, 277, 5);
              sAirlineStopOver10=substr($0, 282, 1);
              sDestination10=substr($0, 283, 5);
              sAirlineCarrierCode10=substr($0, 288, 2);
              sAirlineServiceClass10=substr($0, 290, 1);
              sFlightNumber10=substr($0, 291, 5);
              sAirlineStopOver11=substr($0, 296, 1);
              sDestination11=substr($0, 297, 5);
              sAirlineCarrierCode11=substr($0, 302, 2);
              sAirlineServiceClass11=substr($0, 304, 1);
              sFlightNumber11=substr($0, 305, 5);
              sAirlineStopOver12=substr($0, 310, 1);
              sDestination12=substr($0, 311, 5);
              sAirlineCarrierCode12=substr($0, 316, 2);
              sAirlineServiceClass12=substr($0, 318, 1);
              sFlightNumber12=substr($0, 319, 5);
              sAirlineStopOver13=substr($0, 324, 1);
              sDestination13=substr($0, 325, 5);
              sAirlineCarrierCode13=substr($0, 330, 2);
              sAirlineServiceClass13=substr($0, 332, 1);
              sFlightNumber13=substr($0, 333, 5);
              sAirlineStopOver14=substr($0, 338, 1);
              sDestination14=substr($0, 339, 5);
              sAirlineCarrierCode14=substr($0, 344, 2);
              sAirlineServiceClass14=substr($0, 346, 1);
              sFlightNumber14=substr($0, 347, 5);
              sAirlineStopOver15=substr($0, 352, 1);
              sDestination15=substr($0, 353, 5);
              sAirlineCarrierCode15=substr($0, 358, 2);
              sAirlineServiceClass15=substr($0, 360, 1);
              sFlightNumber15=substr($0, 361, 5);
              sAirlineStopOver16=substr($0, 366, 1);
              sDestination16=substr($0, 367, 5);
              sAirlineCarrierCode16=substr($0, 372, 2);
              sAirlineServiceClass16=substr($0, 374, 1);
              sFlightNumber16=substr($0, 375, 5);
              sTravelAgencyCode=substr($0, 380, 8);
              sTravelAgencyName=substr($0, 388, 25);
              sPassengerName=substr($0, 413, 20);
              sDepartureDate=substr($0, 433, 6);
              sOriginationCode=substr($0, 439, 3);
              sInternetIndicator=substr($0, 442, 1);    
              sElectTicketInd=substr($0, 443, 1);
              sFiller6001=substr($0, 444, 507);         
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordTypeID, sAddDetailRecType,
                              sCompanyID, sSubCompanyID,
                              sAccountNo, sMessageID,
                              sReferenceNumber, sTotalFareAmount,
                              sTotalTaxAmount,
                              sNationalTaxAmount, sTotalFeeAmount,
                              sAirlineTicketNumber, sExchangeTicketNumber,
                              sExchangeTicketAmount, sAirlineStopOver1,
                              sDestination1, sAirlineCarrierCode1,
                              sAirlineServiceClass1, sFlightNumber1,
                              sAirlineStopOver2, sDestination2,
                              sAirlineCarrierCode2, sAirlineServiceClass2,
                              sFlightNumber2, sAirlineStopOver3,
                              sDestination3, sAirlineCarrierCode3,
                              sAirlineServiceClass3, sFlightNumber3,
                              sAirlineStopOver4, sDestination4,
                              sAirlineCarrierCode4, sAirlineServiceClass4,
                              sFlightNumber4, sAirlineStopOver5,
                              sDestination5, sAirlineCarrierCode5,
                              sAirlineServiceClass5, sFlightNumber5,
                              sAirlineStopOver6, sDestination6,
                              sAirlineCarrierCode6, sAirlineServiceClass6,
                              sFlightNumber6, sAirlineStopOver7,
                              sDestination7, sAirlineCarrierCode7,
                              sAirlineServiceClass7, sFlightNumber7,
                              sAirlineStopOver8, sDestination8,
                              sAirlineCarrierCode8, sAirlineServiceClass8,
                              sFlightNumber8, sAirlineStopOver9,
                              sDestination9, sAirlineCarrierCode9,
                              sAirlineServiceClass9, sFlightNumber9,
                              sAirlineStopOver10, sDestination10,
                              sAirlineCarrierCode10, sAirlineServiceClass10,
                              sFlightNumber10, sAirlineStopOver11,
                              sDestination11, sAirlineCarrierCode11,
                              sAirlineServiceClass11, sFlightNumber11,
                              sAirlineStopOver12, sDestination12,
                              sAirlineCarrierCode12, sAirlineServiceClass12,
                              sFlightNumber12, sAirlineStopOver13,
                              sDestination13, sAirlineCarrierCode13,
                              sAirlineServiceClass13, sFlightNumber13,
                              sAirlineStopOver14, sDestination14,
                              sAirlineCarrierCode14, sAirlineServiceClass14,
                              sFlightNumber14, sAirlineStopOver15,
                              sDestination15, sAirlineCarrierCode15,
                              sAirlineServiceClass15, sFlightNumber15,
                              sAirlineStopOver16, sDestination16,
                              sAirlineCarrierCode16, sAirlineServiceClass16,
                              sFlightNumber16, sTravelAgencyCode,
                              sTravelAgencyName, sPassengerName,
                              sDepartureDate, sOriginationCode,
                              sInternetIndicator, sElectTicketInd,    
                              sFiller6001, sElectTicketInd, sNombreArchivo, sFechaArchivo);         

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "6002")
           {
              sRecordTypeID=substr($0, 1, 2);
              sAddDetailRecType=substr($0, 3, 2);
              sCompanyID=substr($0, 5, 6);
              sSubCompanyID=substr($0, 11, 3);
              sAccountNo=substr($0, 14, 16);
              sPurchDetailSeqNum=substr($0, 30, 3);
              sOrderDate=substr($0, 33, 6);
              sDestinationZipCode=substr($0, 39, 10);
              sDestinationCountryCode=substr($0, 49, 3);
              sOriginationZipCode=substr($0, 52, 10);
              sFreightAmount=substr($0, 62, 13);
              sFreightVATTaxAmount=substr($0, 75, 12);
              sFreightVATTaxRate=substr($0, 87, 4);
              sCommodityCode=substr($0, 91, 15);
              sDescription=substr($0, 106, 35);
              sProductCode=substr($0, 141, 12);
              sQuantity=substr($0, 153, 15);
              sUnitOfMeasure=substr($0, 168, 12);
              sUnitCost=substr($0, 180, 15);
              sVATTaxAmount=substr($0, 195, 12);
              sVATTaxRate=substr($0, 207, 4);
              sUniqueVATInvRefNo=substr($0, 211, 15);
              sDiscountPerLineItem=substr($0, 226, 12);
              sLineItemTotal=substr($0, 238, 12);
              sFiller6002=substr($0, 250, 701);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordTypeID, sAddDetailRecType,
                              sCompanyID, sSubCompanyID,
                              sAccountNo, sPurchDetailSeqNum,
                              sOrderDate, sDestinationZipCode,
                              sDestinationCountryCode, sOriginationZipCode,
                              sFreightAmount, sFreightVATTaxAmount,
                              sFreightVATTaxRate, sCommodityCode,
                              sDescription, sProductCode,
                              sQuantity, sUnitOfMeasure,
                              sUnitCost, sVATTaxAmount,
                              sVATTaxRate, sUniqueVATInvRefNo,
                              sDiscountPerLineItem, sLineItemTotal,
                              sFiller6002, sTRXControlData, sNombreArchivo, sFechaArchivo);

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "6004")
           {
              sRecordTypeID=substr($0, 1, 2);
              sAddDetailRecType=substr($0, 3, 2);
              sCompanyID=substr($0, 5, 6);
              sSubCompanyID=substr($0, 11, 3);
              sAccountNo=substr($0, 14, 16);
              sPurchDetailSeqNum=substr($0, 30, 3);
              sPropTelephoneNumber=substr($0, 33, 10);
              sCustServPhoneNum=substr($0, 43, 10);
              sCheckInDate=substr($0, 53, 8);
              sCheckOutDate=substr($0, 61, 8);
              sNoShowIndicator=substr($0, 69, 1);
              sTotalAuthAmount=substr($0, 70, 13);
              sPrepaidExpenses=substr($0, 83, 7);
              sNumberOfRoomNights=substr($0, 90, 12);
              sDailyRoomRate=substr($0, 102, 12);
              sVATTaxAmount=substr($0, 114, 12);
              sVATTaxRate_6004=substr($0, 126, 12);
              sRoomTaxAmount=substr($0, 138, 12);
              sUniqueVATInvRefNo=substr($0, 150, 15);
              sDiscountAmount=substr($0, 165, 12);
              sFoodAndBeverageCharge=substr($0, 177, 12);
              sCashAdvances=substr($0, 189, 12);
              sValetParkingCharges=substr($0, 201, 12);
              sMiniBarCharges=substr($0, 213, 12);
              sLaundryCharges=substr($0, 225, 12);
              sPhoneCharges=substr($0, 237, 12);
              sGiftShopCharges=substr($0, 249, 12);
              sMovieCharges=substr($0, 261, 12);
              sBusinessCenterCharges=substr($0, 273, 12);
              sHealthClubCharges=substr($0, 285, 12);
              sOtherCharges=substr($0, 297, 12);
              sTotalNonRoomCharges=substr($0, 309, 12);
              sFiller6004=substr($0, 321, 630);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordTypeID, sAddDetailRecType,
                              sCompanyID, sSubCompanyID,
                              sAccountNo, sPurchDetailSeqNum,
                              sPropTelephoneNumber, sCustServPhoneNum,
                              sCheckInDate, sCheckOutDate,
                              sNoShowIndicator, sTotalAuthAmount,
                              sPrepaidExpenses, sNumberOfRoomNights,
                              sDailyRoomRate, sVATTaxAmount,
                              sVATTaxRate_6004, sRoomTaxAmount,
                              sUniqueVATInvRefNo, sDiscountAmount,
                              sFoodAndBeverageCharge, sCashAdvances,
                              sValetParkingCharges, sMiniBarCharges,
                              sLaundryCharges, sPhoneCharges,
                              sGiftShopCharges, sMovieCharges,
                              sBusinessCenterCharges, sHealthClubCharges,
                              sOtherCharges, sTotalNonRoomCharges,
                              sFiller6004, sTRXControlData, sNombreArchivo, sFechaArchivo );

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "6005")
           {
              sRecordTypeID=substr($0, 1, 2);
              sAddDetailRecType=substr($0, 3, 2);
              sCompanyID=substr($0, 5, 6);
              sSubCompanyID=substr($0, 11, 3);
              sAccountNo=substr($0, 14, 16);
              sPurchDetailSeqNum=substr($0, 30, 3);
              sRentalAgreeNum=substr($0, 33, 25);
              sRentersName=substr($0, 58, 40);
              sLocOfRetCity=substr($0, 98, 25);
              sRetStaCountry=substr($0, 123, 3);
              sCarClassCode=substr($0, 126, 2);
              sNoShowIndicator=substr($0, 128, 1);
              sCheckOutDate=substr($0, 129, 8);
              sCheckInDate_6005=substr($0, 137, 6);
              sInsuranceInd=substr($0, 143, 1);
              sInsuranceCharges=substr($0, 144, 12);
              sTotalMiles=substr($0, 156, 5);
              sNumOfDaysRented=substr($0, 161, 2);
              sDailyRate=substr($0, 163, 12);
              sVATTaxAmount=substr($0, 175, 12);
              sVATTaxRate=substr($0, 187, 4);
              sUniqueVATInvRefNo=substr($0, 191, 15);
              sWeeklyRate=substr($0, 206, 12);
              sRatePerMile=substr($0, 218, 12);
              sOneWayDropOffCh=substr($0, 230, 12);
              sRegMilCharge=substr($0, 242, 12);
              sExtraMilCharge=substr($0, 254, 12);
              sMaxFreeMiles=substr($0, 266, 5);
              sLateRetChHourRate=substr($0, 271, 12);
              sFuelCharge=substr($0, 283, 12);
              sTelephoneCharges=substr($0, 295, 12);
              sAutoTowingCharges=substr($0, 307, 12);
              sExtraCharges=substr($0, 319, 12);
              sOtherCharges=substr($0, 331, 12);
              sDiscountAmount=substr($0, 343, 12);
              sLineItemTotal=substr($0, 355, 12);
              sFiller6005=substr($0, 367, 584);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordTypeID, sAddDetailRecType,
                              sCompanyID, sSubCompanyID,
                              sAccountNo, sPurchDetailSeqNum,
                              sRentalAgreeNum, sRentersName,
                              sLocOfRetCity, sRetStaCountry,
                              sCarClassCode, sNoShowIndicator,
                              sCheckOutDate, sCheckInDate_6005,
                              sInsuranceInd, sInsuranceCharges,
                              sTotalMiles, sNumOfDaysRented,
                              sDailyRate, sVATTaxAmount,
                              sVATTaxRate, sUniqueVATInvRefNo,
                              sWeeklyRate, sRatePerMile,
                              sOneWayDropOffCh, sRegMilCharge,
                              sExtraMilCharge, sMaxFreeMiles,
                              sLateRetChHourRate, sFuelCharge,
                              sTelephoneCharges, sAutoTowingCharges,
                              sExtraCharges, sOtherCharges,
                              sDiscountAmount, sLineItemTotal,
                              sFiller6005, sTRXControlData, sNombreArchivo, sFechaArchivo);

              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }

           if(sRecType == "9000")
           {
              sRecordIndicator=sRecType;
              sTypeIndicator=substr($0, 5, 3);
              sCompanyName=substr($0, 8, 100);
              sCompanyID=substr($0, 108, 6);
              sSubCompanyID=substr($0, 114, 3);
              sEffectiveFileDate=substr($0, 117, 8);
              sType1000RecordCount=substr($0, 125, 18);
              sType1001RecordCount=substr($0, 143, 18);
              sType2000RecordCount=substr($0, 161, 18);
              sType2001RecordCount=substr($0, 179, 18);
              sType2002RecordCount=substr($0, 197, 18);
              sType5000RecordCount=substr($0, 215, 18);
              sType5000TotalValue=substr($0, 233, 18);
              sType5001RecordCount=substr($0, 251, 18);
              sType6001RecordCount=substr($0, 269, 18);
              sType6002RecordCount=substr($0, 287, 18);
              sType6004RecordCount=substr($0, 305, 18);
              sType6005RecordCount=substr($0, 323, 18);
              sFiller9000=substr($0, 341, 610);
              sTRXControlData=substr($0, 951, 50);

              sRecord=sprintf("%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s\t%s",
                              sRecordIndicator, sTypeIndicator,
                              sCompanyName, sCompanyID,
                              sSubCompanyID, sEffectiveFileDate,
                              sType1000RecordCount, sType1001RecordCount,
                              sType2000RecordCount, sType2001RecordCount,
                              sType2002RecordCount, sType5000RecordCount,
                              sType5000TotalValue, sType5001RecordCount,
                              sType6001RecordCount, sType6002RecordCount,
                              sType6004RecordCount, sType6005RecordCount,
                              sFiller9000, sTRXControlData, sNombreArchivo, sFechaArchivo);
 
              sFileName=sPreffix sRecType "_" sDate sSuffix sFileType;

              printf "%s\n", sRecord >> sFileName;  
           }
        }' $LAFileName 

   # Establecer el Patron de Busqueda de Archivos Bulkcopy.   

   LAPattern=$LAPreffix"*"$LADate$LAFileTypeCode$LASuffixBCP

   for BCPFiles in $(ls $LAPattern)
   {
      slTabla=`echo $BCPFiles | cut -c1-7`

echo  $LABCPUtil $LADatabase".."$slTabla in $BCPFiles -c -U $LAUser -P $LAPassword -S $LAServer 
      $LABCPUtil $LADatabase".."$slTabla in $BCPFiles -c -U $LAUser -P $LAPassword -S $LAServer 
      LNStatus=$?

      if [[ $LNStatus -ne 0 ]]
      then
         print "Bulkcopy process failed. in $slTabla"
         break
      fi 
   }
echo AQUI
   echo "exec sp_CCFActualizaTablas ""'"$LAFileName"'" > $LATempFile
   echo "go" >> $LATempFile
   chmod 775 $LATempFile
   $LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -D$LADatabase -i$LATempFile -o$LATempISQLFile
   if [[ -a $LATempFile ]]
   then
      rm $LATempFile
   fi

# 	Eliminar los Archivos Bulkcopy.
   for BCPFiles in $(ls $LAPattern)
   {
      rm $BCPFiles
   }

   if [[ -f $LATempRecTypes ]]
   then
      rm $LATempRecTypes
   fi
else
   print "File " $LAFileName "not available."
   exit 1
fi
exit $LNStatus
