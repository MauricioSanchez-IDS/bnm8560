#! /bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: 
# Procedimiento: depura.sh
# Descripción: procesa la respuesta del archivo CDF que envia Master Card     
# Versión y fecha: 1.0
# Autor:  Jesus Munoz Monsalvo.
# Modifico: Jose Ramon Gonzalez Diaz
# Fecha Modificacion:03/09/2003            

##### Inicia proceso para validar respuesta de Master Card #####
fecha_proceso=`date '+%Y/%m/%d %H:%M:%S'`
terminaPrograma=0
insertaMTCPRO02=0

date

# Se elimina la tabla TMPXXXX
echo "                                         " > $DIR_CARGA/DroTMP.txt
echo "dump transaction $(base.sh) with no_log  " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt
echo "                                         " >> $DIR_CARGA/DroTMP.txt
echo "if object_id('dbo.TMP1000') is not null  " >> $DIR_CARGA/DroTMP.txt
echo "Begin                                    " >> $DIR_CARGA/DroTMP.txt
echo "  drop table dbo.TMP1000                 " >> $DIR_CARGA/DroTMP.txt
echo "End                                      " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt
echo "                                         " >> $DIR_CARGA/DroTMP.txt
echo "if object_id('dbo.TMP3000') is not null  " >> $DIR_CARGA/DroTMP.txt
echo "Begin                                    " >> $DIR_CARGA/DroTMP.txt
echo "  drop table dbo.TMP3000                 " >> $DIR_CARGA/DroTMP.txt
echo "End                                      " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt
echo "                                         " >> $DIR_CARGA/DroTMP.txt
echo "if object_id('dbo.TMP4000') is not null  " >> $DIR_CARGA/DroTMP.txt
echo "Begin                                    " >> $DIR_CARGA/DroTMP.txt
echo "  drop table dbo.TMP4000                 " >> $DIR_CARGA/DroTMP.txt
echo "End                                      " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt
echo "                                         " >> $DIR_CARGA/DroTMP.txt
echo "if object_id('dbo.TMP4100') is not null  " >> $DIR_CARGA/DroTMP.txt
echo "Begin                                    " >> $DIR_CARGA/DroTMP.txt
echo "  drop table dbo.TMP4100                 " >> $DIR_CARGA/DroTMP.txt
echo "End                                      " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt
echo "                                         " >> $DIR_CARGA/DroTMP.txt
echo "if object_id('dbo.TMP4200') is not null  " >> $DIR_CARGA/DroTMP.txt
echo "Begin                                    " >> $DIR_CARGA/DroTMP.txt
echo "  drop table dbo.TMP4200                 " >> $DIR_CARGA/DroTMP.txt
echo "End                                      " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt
echo "                                         " >> $DIR_CARGA/DroTMP.txt
echo "if object_id('dbo.TMP4300') is not null  " >> $DIR_CARGA/DroTMP.txt
echo "Begin                                    " >> $DIR_CARGA/DroTMP.txt
echo "  drop table dbo.TMP4300                 " >> $DIR_CARGA/DroTMP.txt
echo "End                                      " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt
echo "                                         " >> $DIR_CARGA/DroTMP.txt
echo "if object_id('dbo.TMP5000') is not null  " >> $DIR_CARGA/DroTMP.txt
echo "Begin                                    " >> $DIR_CARGA/DroTMP.txt
echo "  drop table dbo.TMP5000                 " >> $DIR_CARGA/DroTMP.txt
echo "End                                      " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt
echo "                                         " >> $DIR_CARGA/DroTMP.txt
echo "if object_id('dbo.TMP9999') is not null  " >> $DIR_CARGA/DroTMP.txt
echo "Begin                                    " >> $DIR_CARGA/DroTMP.txt
echo "  drop table dbo.TMP9999                 " >> $DIR_CARGA/DroTMP.txt
echo "End                                      " >> $DIR_CARGA/DroTMP.txt
echo "go                                       " >> $DIR_CARGA/DroTMP.txt

resultado=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/DroTMP.txt`
checa=`echo $resultado | grep -c "Cannot drop the table"`
echo $checa
if [ $checa -eq 1 ]
then
  errores="No se borraron las tablas TMPXXXX. Ver el archivo $DIR_CARGA/DroTMP.txt"
  echo "Fecha proceso:  $fecha_proceso"
  echo "Nombre archivo: "
  echo "Programa:       depura.sh"
  echo "Error: $errores"
  terminaPrograma=1
fi

if [ $terminaPrograma -eq 0 ]
then
  # Se insertan los registros de REGXXXX en la tabla de paso TMPXXXX
  echo " " > $DIR_CARGA/InsTMP.txt
  echo "dump transaction $(base.sh) with no_log  " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt
  echo "                                         " >> $DIR_CARGA/InsTMP.txt
  echo "Select * Into TMP1000                    " >> $DIR_CARGA/InsTMP.txt
  echo "  From REG1000                           " >> $DIR_CARGA/InsTMP.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt
  echo "                                         " >> $DIR_CARGA/InsTMP.txt
  echo "Select * Into TMP3000                    " >> $DIR_CARGA/InsTMP.txt
  echo "  From REG3000                           " >> $DIR_CARGA/InsTMP.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt
  echo "                                         " >> $DIR_CARGA/InsTMP.txt
  echo "Select * Into TMP4000                    " >> $DIR_CARGA/InsTMP.txt
  echo "  From REG4000                           " >> $DIR_CARGA/InsTMP.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt
  echo "                                         " >> $DIR_CARGA/InsTMP.txt
  echo "Select * Into TMP4100                    " >> $DIR_CARGA/InsTMP.txt
  echo "  From REG4100                           " >> $DIR_CARGA/InsTMP.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt
  echo "                                         " >> $DIR_CARGA/InsTMP.txt
  echo "Select * Into TMP4200                    " >> $DIR_CARGA/InsTMP.txt
  echo "  From REG4200                           " >> $DIR_CARGA/InsTMP.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt
  echo "                                         " >> $DIR_CARGA/InsTMP.txt
  echo "Select * Into TMP4300                    " >> $DIR_CARGA/InsTMP.txt
  echo "  From REG4300                           " >> $DIR_CARGA/InsTMP.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt
  echo "                                         " >> $DIR_CARGA/InsTMP.txt
  echo "Select * Into TMP5000                    " >> $DIR_CARGA/InsTMP.txt
  echo "  From REG5000                           " >> $DIR_CARGA/InsTMP.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt
  echo "                                         " >> $DIR_CARGA/InsTMP.txt
  echo "Select * Into TMP9999                    " >> $DIR_CARGA/InsTMP.txt
  echo "  From REG9999                           " >> $DIR_CARGA/InsTMP.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/InsTMP.txt
  echo "go                                       " >> $DIR_CARGA/InsTMP.txt

  resultado=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/InsTMP.txt`
fi

if [ $terminaPrograma -eq 0 ]
then 
  # Se borran los registros de MTCXXXX que se encuentren en TMPXXXX
  echo " " > $DIR_CARGA/DelMTC.txt
  echo "dump transaction $(base.sh) with no_log  " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt
  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Begin Transaction                        " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt
  
  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Delete MTC1000                           " >> $DIR_CARGA/DelMTC.txt
  echo " Where fileReferenceNumber in            " >> $DIR_CARGA/DelMTC.txt
  echo " (Select fileReferenceNumber From TMP1000) " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt

  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Delete MTC3000                           " >> $DIR_CARGA/DelMTC.txt
  echo " Where recordIdentifier in               " >> $DIR_CARGA/DelMTC.txt
  echo " (Select recordIdentifier From TMP3000)  " >> $DIR_CARGA/DelMTC.txt
  echo " and issuerIca in                        " >> $DIR_CARGA/DelMTC.txt
  echo " (Select issuerIca From TMP3000)         " >> $DIR_CARGA/DelMTC.txt 
  echo " and issuerNumberIca in                  " >> $DIR_CARGA/DelMTC.txt
  echo " (Select issuerNumberIca  From TMP3000)  " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt

  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Delete MTC4000                           " >> $DIR_CARGA/DelMTC.txt
  echo " Where corporationNumber in              " >> $DIR_CARGA/DelMTC.txt
  echo " (Select corporationNumber From TMP4000) " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt
  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Delete MTC4100                           " >> $DIR_CARGA/DelMTC.txt
  echo "Where organizationPointNumber in         " >> $DIR_CARGA/DelMTC.txt
  echo "(Select organizationPointNumber From TMP4100) " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt
  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Delete MTC4200                           " >> $DIR_CARGA/DelMTC.txt
  echo "Where organizationPointNumber in         " >> $DIR_CARGA/DelMTC.txt
  echo "(Select organizationPointNumber From TMP4200) " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt
  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Delete MTC4300                           " >> $DIR_CARGA/DelMTC.txt
  echo "  Where  accountNumber in                " >> $DIR_CARGA/DelMTC.txt
  echo "     (Select accountNumber From TMP4300) " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt
  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Delete MTC9999                           " >> $DIR_CARGA/DelMTC.txt 
  echo " Where recordIdentifier in               " >> $DIR_CARGA/DelMTC.txt 
  echo " (Select recordIdentifier From TMP9999)  " >> $DIR_CARGA/DelMTC.txt 
  echo " and issuerIca in                        " >> $DIR_CARGA/DelMTC.txt 
  echo " (Select issuerIca From TMP9999)         " >> $DIR_CARGA/DelMTC.txt 
  echo " and issuerNumberIca in                  " >> $DIR_CARGA/DelMTC.txt 
  echo " (Select issuerNumberIca  From TMP9999)  " >> $DIR_CARGA/DelMTC.txt 
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt 
  echo "                                         " >> $DIR_CARGA/DelMTC.txt
  echo "Commit Transaction                       " >> $DIR_CARGA/DelMTC.txt
  echo "go                                       " >> $DIR_CARGA/DelMTC.txt
  resultado=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/DelMTC.txt`
  checa=`echo $resultado | grep -c "row"`
  if [ $checa -ne 1 ]                 
  then                                
    errores="No se pudo ejecutar el sql. Ver el archivo $DIR_CARGA/DelMTC.txt"
    echo "Fecha proceso:  $fecha_proceso" 
    echo "Nombre archivo: " 
    echo "Programa:       depura.sh" 
    echo "Error: $errores"
    terminaPrograma=1
  fi 
fi

if [ $terminaPrograma -eq 0 ]
then 
  bcp $(base.sh).dbo.TMP1000 out $DIR_CARGA/TMP1000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  bcp $(base.sh).dbo.TMP3000 out $DIR_CARGA/TMP3000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  bcp $(base.sh).dbo.TMP4000 out $DIR_CARGA/TMP4000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  bcp $(base.sh).dbo.TMP4100 out $DIR_CARGA/TMP4100.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  bcp $(base.sh).dbo.TMP4200 out $DIR_CARGA/TMP4200.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  bcp $(base.sh).dbo.TMP4300 out $DIR_CARGA/TMP4300.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  bcp $(base.sh).dbo.TMP5000 out $DIR_CARGA/TMP5000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  bcp $(base.sh).dbo.TMP9999 out $DIR_CARGA/TMP9999.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  if [ $? != 0 ]
  then 
    errores="No se pudo ejecutar el bulkcopy de la tabla TMP al archivo"
    echo "Fecha proceso:  $fecha_proceso" 
    echo "Nombre archivo: " 
    echo "Programa:       depura.sh" 
    echo "Error: $errores"
    terminaPrograma=1
  fi
fi

if [ $terminaPrograma -eq 0 ]
then 
#_HP_Changes for Linux Migration -Start
#Changed bcp to bcp64 with flag -Jroman8

  #bcp $(base.sh).dbo.MTC1000 in $DIR_CARGA/TMP1000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  #bcp $(base.sh).dbo.MTC3000 in $DIR_CARGA/TMP3000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  #bcp $(base.sh).dbo.MTC4000 in $DIR_CARGA/TMP4000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  #bcp $(base.sh).dbo.MTC4100 in $DIR_CARGA/TMP4100.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  #bcp $(base.sh).dbo.MTC4200 in $DIR_CARGA/TMP4200.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  #bcp $(base.sh).dbo.MTC4300 in $DIR_CARGA/TMP4300.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  #bcp $(base.sh).dbo.MTC5000 in $DIR_CARGA/TMP5000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 
  #bcp $(base.sh).dbo.MTC9999 in $DIR_CARGA/TMP9999.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} 

  bcp64 $(base.sh).dbo.MTC1000 in $DIR_CARGA/TMP1000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -Jroman8
  bcp64 $(base.sh).dbo.MTC3000 in $DIR_CARGA/TMP3000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -Jroman8
  bcp64 $(base.sh).dbo.MTC4000 in $DIR_CARGA/TMP4000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -Jroman8
  bcp64 $(base.sh).dbo.MTC4100 in $DIR_CARGA/TMP4100.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -Jroman8
  bcp64 $(base.sh).dbo.MTC4200 in $DIR_CARGA/TMP4200.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -Jroman8
  bcp64 $(base.sh).dbo.MTC4300 in $DIR_CARGA/TMP4300.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -Jroman8
  bcp64 $(base.sh).dbo.MTC5000 in $DIR_CARGA/TMP5000.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -Jroman8
  bcp64 $(base.sh).dbo.MTC9999 in $DIR_CARGA/TMP9999.txt -c -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -Jroman8
#_HP_Changes for Linux Migration -End

  if [ $? != 0 ]
  then 
    errores="No se pudo ejecutar el bulkcopy del archivo a MTC5000"
    echo "Fecha proceso:  $fecha_proceso" 
    echo "Nombre archivo: " 
    echo "Programa:       depura.sh" 
    echo "Error: $errores"
    terminaPrograma=1
  fi
fi

if [ $terminaPrograma -eq 0 ]
then 
  # Se borran los registros de REGXXXX 
  echo " " > $DIR_CARGA/DelREG.txt
  echo "dump transaction $(base.sh) with no_log  " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Begin Transaction                        " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Delete REG1000                           " >> $DIR_CARGA/DelREG.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Delete REG3000                           " >> $DIR_CARGA/DelREG.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Delete REG4000                           " >> $DIR_CARGA/DelREG.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Delete REG4100                           " >> $DIR_CARGA/DelREG.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Delete REG4200                           " >> $DIR_CARGA/DelREG.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Delete REG4300                           " >> $DIR_CARGA/DelREG.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Delete REG5000                           " >> $DIR_CARGA/DelREG.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Delete REG9999                           " >> $DIR_CARGA/DelREG.txt
  echo "  Where  outgoingIncomingErrorCode = ' ' " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  echo "                                         " >> $DIR_CARGA/DelREG.txt
  echo "Commit Transaction                       " >> $DIR_CARGA/DelREG.txt
  echo "go                                       " >> $DIR_CARGA/DelREG.txt
  resultado=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/DelREG.txt`
  checa=`echo $resultado | grep -c "row"`
  if [ $checa -ne 1 ]                 
  then                                
    errores="No se pudo ejecutar el sql. Ver el archivo $DIR_CARGA/DelREG.txt"
    echo "Fecha proceso:  $fecha_proceso" 
    echo "Nombre archivo: " 
    echo "Programa:       depura.sh" 
    echo "Error: $errores"
    terminaPrograma=1
  fi 
fi 

if [ $terminaPrograma -eq 0 ]
then
  echo " declare @countR1000 int," > $DIR_CARGA/contReg.txt
  echo "@countR3000 int," >> $DIR_CARGA/contReg.txt
  echo "@countR4000 int," >> $DIR_CARGA/contReg.txt
  echo "@countR4100 int," >> $DIR_CARGA/contReg.txt
  echo "@countR4200 int," >> $DIR_CARGA/contReg.txt
  echo "@countR4300 int," >> $DIR_CARGA/contReg.txt
  echo "@countR5000 int," >> $DIR_CARGA/contReg.txt
  echo "@countR9999 int," >> $DIR_CARGA/contReg.txt
  echo "@total int" >> $DIR_CARGA/contReg.txt
  echo " " >> $DIR_CARGA/contReg.txt
  echo "select @countR1000=count(*) from REG1000" >> $DIR_CARGA/contReg.txt
  echo "select @countR3000=count(*) from REG3000" >> $DIR_CARGA/contReg.txt
  echo "select @countR4000=count(*) from REG4000" >> $DIR_CARGA/contReg.txt
  echo "select @countR4100=count(*) from REG4100" >> $DIR_CARGA/contReg.txt
  echo "select @countR4200=count(*) from REG4200" >> $DIR_CARGA/contReg.txt
  echo "select @countR4300=count(*) from REG4300" >> $DIR_CARGA/contReg.txt
  echo "select @countR5000=count(*) from REG5000" >> $DIR_CARGA/contReg.txt
  echo "select @countR9999=count(*) from REG9999" >> $DIR_CARGA/contReg.txt
  echo " " >> $DIR_CARGA/contReg.txt
  echo "select @total=@countR1000+@countR3000+@countR4000+" >> $DIR_CARGA/contReg.txt
  echo "@countR4100+@countR4200+@countR4300+@countR5000+@countR9999" >> $DIR_CARGA/contReg.txt
  echo " " >> $DIR_CARGA/contReg.txt
  echo "select '|'+ convert(varchar,@total) +'|' " >> $DIR_CARGA/contReg.txt
  echo "go                                       " >> $DIR_CARGA/contReg.txt
  
  variable=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/contReg.txt | grep '[0-9]' | egrep -v '\(.*\)' | sed 's/ //g'` 
                                                                                
    # En la sentecia de Arriba se asigna el resultado en variable,              
    # y en seguida se da el mismo comando                                       
    # para que el sistema operativo determine si el programa                    
    # termino exitosamente o no termino exiosamente                             
    isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/contReg.txt
    if [ $? -gt 0 ] #si el resultado del ultimo comando es mayor que 0
    then
      errores="No se ejecuto el sql. Ver el archivo $DIR_CARGA/contReg.txt"
      echo "Fecha proceso:  $fecha_proceso"
      echo "Nombre archivo: "
      echo "Programa:       depura.sh"
      echo "Error: $errores"
      terminaPrograma=1
    else
      registros=`echo $variable | cut -f2 -d'|'`
      terminaPrograma=0 
    fi

   if [ $terminaPrograma -eq 0 -a $registros -gt 0  ]
   then                      
     gdb $DIR_CARGA/validaErrCDF
     if [ $? != 0 ]
     then
        errores="No se ejecuto el validaErrCDF que genera reporte de errores "
        echo "Fecha proceso:  $fecha_proceso"
        echo "Nombre archivo: "
        echo "Programa:depura.sh y validaErrCDF"
        echo "Error: $errores"
        exit
     fi
   fi                                                               
fi

date

