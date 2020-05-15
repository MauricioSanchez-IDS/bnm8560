#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# NOMBRE    : C430TransCCF.                                             #
# DESCRIPCION   : Permite ejecutar el proceso encargado de generar      #
#                 los archivos de transacciones de tarjetahabientes     #
#                 de una empresa en formato CCF.                        #
# PRECEDIDO POR	:                                                       #
#                                                                       #
#                                                                       #
# VARIABLES DE                                                          #
# AMBIENTE              : NOMBRE VARIABLE           DESCRIPCION         #
#                                                                       #
#                            LAPath           Ruta de Ubicacion         #
#                                             Archivo CCF por Empresa.  #
#                            LABackupPath     Ruta de Respaldo Archivo  #
#                                             CCF por Empresa y Archivo #
#                                             CCF Unico.                #
#                            LATransPath      Ruta de Transferencia     #
#                                             Archivo CCF Unico.        #
#                            LAFileType       Modo de Generacion del    #
#                                             Archivo CCF por Empresa.  #
#                            LAFileTypeCode   Clave de Modo de          #
#                                             Generacion del Archivo    #
#                                             CCF por Empresa.          #
#                            LAFileRange      Rango de Empresas del     #
#                                             Archivo CCF.              #
#                            LAFileRangeCode  Clave de Rango de         #
#                                             Empresas del Archivo CCF. #
#                            LAFileName       Nombre del Archivo        #
#                                             CCF.                      #
#                            LAFileUniqName   Nombre del Archivo CCF    #
#                                             Unico.                    #
#                            LADate           Fecha de Generacion del   #
#                                             Archivo (MMDD).           #
#                            LAProcessDate    Fecha de Procesamiento    #
#                            LAProcessDateTransCCFcp Fec. dia arc deseado#
#                            LAPreffix        Prefijo asociado al       #
#                                             Archivo.                  #
#                            LASuffix         Sufijo asociado al        #
#                                             Archivo.                  #
#                            LAUserName       Nombre de Usuario de      #
#                                             UNIX.                     #
#                            LNProcesses      Numero de Instancias      #
#                                             Activas del Programa.     #
#                            LALogFile        Nombre del Archivo de     #
#                                             Log.                      #
#                            LARegLogFile     Registro de Archivo de    #
#                                             Log.                      #
#                            LASysDate        Fecha del Sistema.        #
#                            LNStatus         Estado de Ejecucion del   #
#                                             Programa.                 #
#                            LNStaInter       Estado de Ejecucion de    #
#                                             procesos intermedios.     #
#                            LAIDProcess      Clave de Identificacion   #
#                                             del Programa.             #
#                            LAIDAdicProc     Clave de Identificacion   #
#                                             de Proceso Adicional.     #
#                            LATempFile       Archivo Temporal.         #
#                            LAUser           Usuario de Base de Datos. #
#                            LAPassword       Password de Base de       #
#                                             Datos.                    #
#                            LAServer         Servidor de Base de       #
#                                             Datos.                    #
#                            LAProgram        Nombre del Programa.      #
#                            LAVerifProg      Nombre del Programa para  #
#                                             Verificacion de la        #
#                                             Estructura del Archivo    #
#                                             CCF.                      #
#                            LAGenUniqProg    Nombre del Programa para  #
#                                             Generar el Archivo CCF    #
#                                             Unico.                    #
#                            LAVerUniqProg    Nombre del Programa para  #
#                                             Verificacion de la        #
#                                             Estructura del Archivo    #
#                                             CCF Unico.                #
#                            LACoPreffix      Prefijo asociado a la     #
#                                             Empresa.                  #
#                            LABankGroup      Grupo de Banco asociado a #
#                                             la Empresa.               #
#                            LACompanyID      Clave de la Empresa.      #
#                            LACompExtr       Nombre del Programa para  #
#                                             Extraccion de Empresas    #
#                                             a Procesar.               #
#                            LAISQLUtil       Nombre del Programa para  #
#                                             Acceso a Base de Datos.   #
#                            LADatabase       Nombre de la Base de      #
#                                             Datos del Sistema C430.   #
#                            LAStatusTab      Nombre de la Tabla de     #
#                                             Registro de Estatus del   #
#                                             Proceso de Generacion del #
#                                             Archivo CCF.              #
#                            LNValStaTab      Valor a Almacenar en la   #
#                                             Tabla de Registro de      #
#                                             Estatus.                  #
#                            LAErrMsg1        Mensaje de Error 1.       #
#                            LAErrMsg2        Mensaje de Error 2.       #
#                            LAErrMsg3        Mensaje de Error 3.       #
#                            LAInfMsg1        Mensaje Informativo 1.    #
#                            LAInfMsg2        Mensaje Informativo 2.    #
#                            LAInfMsg3        Mensaje Informativo 3.    #
# PARAMETROS 	:                                                       #
#                 $1 = Ruta de Ubicacion Archivo CCF.                   #
#                 $2 = Rango de Archivo CCF (Todas las Empresas /       #
#                                            Por Empresa).              #
#                 $3 = Fecha de Procesamiento (Parametro Opcional).     #
#                 $4 = Prefijo de la Empresa (Parametro Opcional).      #
#                 $5 = Grupo de Banco de la Empresa (Parametro Opcio-   #
#                      nal).                                            #
#                 $6 = Clave de la Empresa (Parametro Opcional).        #
#                                                                       #
# SALIDAS   :                                                           #
# AUTOR     : Vicente Ferrer Andrade <VFA>                              #
# COMPANIA  : Softtek                                                   #
# FECHA     : 26/06/2003                                                #
# CONTROL DE                                                            #
# VERSIONES : V.1.2                                                     #
# CONTROL DE MODIFICACION                                               #
#   IS        NOMBRE           FECHA    DESCRIPCION                     #
#  VFA  Vicente Ferrer Andrade  26/06/2003  Primer Version              #
#                                                                       #
#  JAGG JOSE ALBERTO GARCIA GARCIA 20/07/2004 Primera Modificacion      #
#                                                                       #
#  IERM IVAN EDUARDO ROLDAN   01/10/2005 Segunda Modificacion           #
#                                                                       #
#  MARG MIGUEL ANGEL DE LA ROSA GARCIA 14/11/2005 Segunda Modificacion  #
#                                                                       #
#                                                                       #
# Copyright Derechos Reservados Banamex S.A. de C.V 2003                #
#

LD_LIBRARY_PATH=/optware/sybase/ase157sp104/ASE-15_0/lib:/optware/sybase/ase157sp104/OCS-15_0/lib:/optware/sybase/ase157sp104/OCS-15_0/include:/usr/lib:/opt/c046/105/lib:/optware/sybase/ase157sp104/OCS-15_0/lib/libsybct64.so

export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:/opt/sybase15/OCS-15_0/lib

. $(paths.sh 08 PAR)/.variables	  #descomentar en la nueva ruta

#set -x

LAPath=$TempFilePath
LABackupPath=$BackupPath
LATransPath=$TransPath
LAFileType=$FileMode
LAFileTypeCode=""
LAFileRange=$1
LAFileRangeCode=""
LAFileName=""
LAFileUniqName=""
LADate=""
LAProcessDate=""
LAProcessDateTransCCFcp=""
LAPreffix=$PreffixCCF
LASuffix=$SuffixCCF
LAUserName=$UserNameUNIX
LNProcesses=0
LALogFile=$LogFile
LARegLogFile=""
LASysDate=""
LNStatus=0
LNStaInter=0
LAIDProcess="02"
LAIDAdicProc="03"
LATempFile=$TempFilePath"TempC430TransCCF.tmp"
LAUser=$UserSYB
LAPassword=$PasswordSYB
LAServer=$ServerSYB
LAProgram=$BinPath"C430TransCCF"
LAVerifProg=$CronPath"C430ValComCCF.sh"
LAGenUniqProg=$CronPath"C430GenUniqCCF.sh"
LAVerUniqProg=$CronPath"C430ValUniqCCF.sh"
LACoPreffix=""
LABankGroup=""
LACompanyID=""
LACompExtr=$BinPath"C430GetCompanies"
LAISQLUtil=$ISQLUtilSYB
LADatabase=$DatabaseSYB
LAStatusTab=$StatusTabSYB                                           #MTCCCF01
LAErrMsg1="Archivo CCF por empresa, ya generado con anterioridad"
LAErrMsg2="Archivo CCF Unico, ya generado con anterioridad"
LAErrMsg3="Archivo CCF Unico, no se puede generar por que no existe archivo CCF por empresa"
LAInfMsg1="Generacion del Archivo"
LAInfMsg2="Dispara generacion del archivo CCF"
LAInfMsg3="Proceso generado con exito"

LAStartDate=""
LAEndDate=""
DIR_BIN=$(paths.sh 01 BIN)
BITACORA=$DIR_BIN/bitacoraITO.sh
MSG2="FALLO LA GENERACION DEL ARCHIVO CCF"

# Determinar el No. de Parametros de Ejecucion.
case $# in
   1) ;;   # No. de Parametros Correcto.
   2) ;;   # No. de Parametros Correcto.
   5) ;;   # No. de Parametros Correcto.
   *) print "Use: C430TransCCF.sh <0|1> [<yyyymmdd>  <0000>    <00>   <000000>]"
      print "                     Range   Date       Preffix   Bank    Corp"
      print "\n\tRange\t --------------- 0 All Corps\n\t     \t --------------- 1 Specific Corp "
      print "\tDate:\t --------------- Specific date"
      exit 1 ;

#Escribe en el log del proceso C430TransCCF.log
registraEstatus () {
        f=`date '+%Y%m%d%H%M%S'`
        echo "$f:$1" >> $LALogFile
}

# Eliminar archivos temporales.  

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi

# Determinar el No. de Procesos Activos.

#ps -ef | grep C430TransCCF.sh | grep -v grep > $LATempFile
ps -ef | grep $LAUserName | grep $0 | grep "sh -c" | grep -v grep > $LATempFile

LNProcesses=$(wc -l $LATempFile | awk '{ print $1; }')

#if [[ -a $LATempFile ]]
#hen
#  rm $LATempFile
#i


if [[ $LNProcesses > 1 ]]   # No puede haber mas de un proceso activo.
then
   msg="The process C430TransCCF.sh is online."
   print $msg
   registraEstatus "$msg"
   exit 1
fi

# Establecer la Clave Asociada al Modo de Generacion del Archivo CCF.

if [[ $LAFileType = "0" ]]   # El archivo CCF es Diario.
then
   LAFileTypeCode="D" 
elif [[ $LAFileType = "1" ]]   # El archivo CCF es por Fecha de Corte.
then
   LAFileTypeCode="C"
else
   msg="The FileType Parameter's Value is incorrect."
   print $msg
   registraEstatus "$msg"
   exit 1
fi

# Establecer la Clave Asociada al Rango de Generacion del Archivo CCF.

if [[ $LAFileRange = "0" ]]   # El archivo CCF abarca Todas las Empresas.
then
   LAFileRangeCode="A" 
elif [[ $LAFileRange = "1" ]]   # El archivo CCF abarca solo una Empresa.
then
   LAFileRangeCode="O"
else
   msg="The File Range Parameter's Value is incorrect"
   print $msg
   registraEstatus "$msg"
   exit 1
fi

# Establecer la Fecha de Generacion del Archivo.

if [[ -z $2 ]]
then
   LAProcessDate=$(date +'%Y%m%d')
   LAProcessDateTransCCFcp=$LAProcessDate
   LADate=$(echo $LAProcessDate | awk '{ print substr($0, 5, 4); }')
else
   LAProcessDate=$2 
   LAProcessDateTransCCFcp=$LAProcessDate
   LADate=$(echo $LAProcessDate | awk '{ print substr($0, 5, 4); }')
   LAProcessDate=$(date +'%Y%m%d') 
fi

# Establecer el nombre del Archivo CCF Unico.

LAFileUniqName=$LAPreffix$LADate$LAFileTypeCode$LASuffix

msg="Inicia la generacion del archivo $LAFileUniqName "
registraEstatus "$msg"

# Construccion de script de SQL para actualizar la tabla
# de Estatus del Proceso de Generacion del Archivo Unico
# CCF MTCCCF01 (Inicio de Proceso).

LNValStaTab=0


echo "select distinct nom_archivo from $LAStatusTab "   > $LATempFile
echo " where nom_archivo = '$LAFileUniqName' " >> $LATempFile
echo "go                                  " >> $LATempFile

chmod 775 $LATempFile

result=`$LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -i$LATempFile -D$LADatabase | grep "(1 row affected)" | wc -l`

if [[ -f $LATempFile ]]
then
   rm $LATempFile
fi

if [[  $result -eq 1 ]]
then
   msg="Favor de revisar en MTCCCF01 ya existe una instancia del archivo:$LAFileUniqName"
   print $msg
   registraEstatus "$msg"
   exit
fi


echo "if exists (select * from "$LAStatusTab > $LATempFile                 
echo "           where nom_archivo = '"$LAFileUniqName"')" >> $LATempFile  
echo "   begin" >> $LATempFile                                             
echo "      insert "$LAStatusTab " (nom_archivo,fecha_archivo,estatus,tamanio)" >> $LATempFile
echo "      values ('"$LAFileUniqName"', '"$LAProcessDate"', "$LNValStaTab", 0)" >> $LATempFile
echo "   end" >> $LATempFile
echo "else" >> $LATempFile
echo "   begin" >> $LATempFile
echo "      insert "$LAStatusTab " (nom_archivo,fecha_archivo,estatus,tamanio)" >> $LATempFile
echo "      values ('"$LAFileUniqName"', '"$LAProcessDate"', "$LNValStaTab", 0)" >> $LATempFile
echo "   end" >> $LATempFile
echo "go" >> $LATempFile

chmod 775 $LATempFile

$LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -i$LATempFile -D$LADatabase

if [[ -f $LATempFile ]]
then
   rm $LATempFile
fi

# Buscar los archivos CCF por Empresa en la Ruta Especificada.
                                                      
cd $LAPath                           
                 

# Establecer la Empresa o Empresas a procesar y extraer la informacion
# de la Base de Datos.

LAStartDate=$(date)

if [[ -z $3 && -z $4 && -z $5 ]]  
then

   if [[ $LAFileRange = "0" ]]   # Verificar el rango de Empresas a Procesar.
   then

      $LACompExtr $LAUser $LAPassword $LAServer $LAFileType $LAProcessDate > $LATempFile

      # Ajusta el valor de la variable LAFileRange.

      LAFileRange="1"

      for Companies in $(cat $LATempFile)                             
      do                                                           
         LACoPreffix=$(echo $Companies | awk 'BEGIN { FS="|"; } { print $1; }')
         LABankGroup=$(echo $Companies | awk 'BEGIN { FS="|"; } { print $2; }')
         LACompanyID=$(echo $Companies | awk 'BEGIN { FS="|"; } { print $3; }')

         ##########Arma El Archivo para generar el CCF de una empresa en especifico  JAGG

         LAFileName=$LAPreffix$LACoPreffix$LABankGroup$LACompanyID$LADate$LAFileTypeCode$LASuffix

         # Verificar si el Archivo CCF ya fue generado previamente.
                                                                
         if [[ -f $LAFileName ]]
         then

            # Generar el registro de Log correspondiente y continuar con
            # el proceso
        
            LASysDate=$(date +'%Y%m%d %H%M%S')
            LNStatus=2
            LARegLogFile=$LAFileUniqName"|"$LADate"|"$LAErrMsg1","$LAFileName"|"$LASysDate"|"$LNStatus"|"$LAIDProcess
            
            echo este es el estado que probablemente se esta perdiendo:  $LNStatus 

            print $LARegLogFile >> $LALogFile

            continue

         else 

            $LAProgram $LAUser $LAPassword $LAServer $LAFileType $LAFileRange $LAFileName $LACoPreffix $LABankGroup $LACompanyID $LAProcessDateTransCCFcp


            LNStaInter=$?

            # Verificar si el Archivo CCF por Empresa fue generado con exito.

            if [[ $LNStaInter -eq 0 ]]
            then

               # Generar el registro de Log correspondiente.
        
               LASysDate=$(date +'%Y%m%d %H%M%S')
               LNStatus=0
               LARegLogFile=$LAFileUniqName"|"$LADate"|"$LAInfMsg1","$LAFileName"|"$LASysDate"|"$LNStatus"|"$LAIDAdicProc

               print $LARegLogFile >> $LALogFile
            else
   msg="Hubo problemas con la generacion del archivo $LAFileUniqName y $LAFileName"
   print $msg
   registraEstatus "$msg"
             MSG2="FALLO LA GENERACION DEL ARCHIVO CCF $LAFileUniqName-PASO 1"
              $BITACORA "CCF" "C430TransCCF.sh" "C" "10801" "$MSG2"
              exit 1
            fi

         fi

      done

      if [[ -f $LATempFile ]]
      then
         rm $LATempFile
      fi

   else

      print "The File Range Parameter's Value is incorrect."
      exit 1

   fi

else

   LACoPreffix=$3
   LABankGroup=$4
   LACompanyID=$5

   LAFileName=$LAPreffix$LACoPreffix$LABankGroup$LACompanyID$LADate$LAFileTypeCode$LASuffix

   # Verificar si el Archivo CCF ya fue generado previamente.

   if [[ -f $LAFileName ]]
   then

      # Generar el registro de Log correspondiente y continuar con 
      # el proceso
        
      LASysDate=$(date +'%Y%m%d %H%M%S')
      LNStatus=2
      LARegLogFile=$LAFileUniqName"|"$LADate"|"$LAErrMsg1","$LAFileName"|"$LASysDate"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else

      $LAProgram $LAUser $LAPassword $LAServer $LAFileType $LAFileRange $LAFileName $LACoPreffix $LABankGroup $LACompanyID $LAProcessDateTransCCFcp

      LNStaInter=$?

      # Verificar si el Archivo CCF por Empresa fue generado con exito.

      if [[ $LNStaInter -eq 0 ]]
      then

         # Generar el registro de Log correspondiente y continuar con
         # el proceso
        
         LASysDate=$(date +'%Y%m%d %H%M%S')
         LNStatus=0
         LARegLogFile=$LAFileUniqName"|"$LADate"|"$LAInfMsg1","$LAFileName"|"$LASysDate"|"$LNStatus"|"$LAIDAdicProc

         print $LARegLogFile >> $LALogFile

      else
   msg="Hubo problemas con generacion archivo $LAFileUniqName y $LAFileName"
   print $msg
   registraEstatus "$msg"
         MSG2="FALLO LA GENERACION DEL ARCHIVO CCF $LAFileqName-PASO 2"
         $BITACORA "CCF" "C430TransCCF.sh" "C" "10801" "$MSG2"
         exit 1
      fi 
   fi

fi

# Construccion de script de SQL para actualizar la tabla
# de Estatus del Proceso de Generacion del Archivo Unico
# CCF MTCCCF01 (Generacion de Archivos CCF por Empresa).

LNValStaTab=1

echo "if exists (select * from "$LAStatusTab > $LATempFile
echo "           where nom_archivo = '"$LAFileUniqName"')" >> $LATempFile
echo "   begin" >> $LATempFile
echo "      update "$LAStatusTab >> $LATempFile
echo "      set estatus = "$LNValStaTab >> $LATempFile
echo "      where nom_archivo = '"$LAFileUniqName"'" >> $LATempFile
echo "   end" >> $LATempFile
echo "go" >> $LATempFile

chmod 775 $LATempFile

$LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -i$LATempFile -D$LADatabase

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi


# Validar la Estructura de los Archivos CCF previamente generados.
$LAVerifProg $LAPath $LABackupPath $LADate

# Verificar el estatus de termino del proceso previo.

LNStaInter=$?

case $LNStaInter in
   0) ;;   # El Proceso termino con exito.  
   1) msg="Invalid number of parameters."   # Numero Incorrecto de Parametros.
   print $msg
   registraEstatus "$msg"
      exit 1;;
   2) msg="There's a preview process in memory."   # Proceso Activado.
   print $msg
   registraEstatus "$msg"
      exit 2;;
   3) msg"The FileType Parameter's Value is incorrect."  # Parametro Erroneo.
   print $msg
   registraEstatus "$msg"
      exit 3;;
   4) msg="The Estatus Column's Value is incorrect."   # Estatus Erroneo.
   print $msg
   registraEstatus "$msg"
      exit 4;;
   5) msg="CCF File(s) not available."   # Archivo(s) CCF no disponible(s). 
   print $msg
   registraEstatus "$msg"
      exit 5;; 
   *) msg="System Error."   # Error del Sistema.
   print $msg
   registraEstatus "$msg"
    MSG2="FALLO LA GENERACION DEL ARCHIVO CCF $LAFileqName-PASO 3"
    $BITACORA "CCF" "C430TransCCF.sh" "C" "10801" "$MSG2"
      exit $LNStaInter;; 
esac  

# Generar el Archivo CCF Unico.
$LAGenUniqProg $LABackupPath $LATransPath $LAFileUniqName $LADate
     
# Verificar el estatus de termino del proceso previo.

LNStaInter=$?

case $LNStaInter in
   0) ;;   # El Proceso termino con exito.  
   1) print "Invalid number of parameters."   # Numero Incorrecto de Parametros.
      exit 1;;
   2) print "There's a preview process in memory."   # Proceso Activado.
      exit 2;;
   3) print "The FileType Parameter's Value is incorrect."  # Parametro Erroneo.
      exit 3;;
   4) print "The Estatus Column's Value is incorrect."   # Estatus Erroneo.
      exit 4;;
   5) LASysDate=$(date +'%Y%m%d %H%M%S')   # Archivo Unico ya generado.
      LNStatus=1
      LARegLogFile=$LAFileUniqName"|"$LADate"|"$LAErrMsg2"|"$LASysDate"|"$LNStatus"|"$LAIDProcess
      print $LARegLogFile >> $LALogFile
      exit 5;; 
   6) LASysDate=$(date +'%Y%m%d %H%M%S')   # Archivos CCF por Empresa No Disp.
      LNStatus=1
      LARegLogFile=$LAFileUniqName"|"$LADate"|"$LAErrMsg3"|"$LASysDate"|"$LNStatus"|"$LAIDProcess
      print $LARegLogFile >> $LALogFile
    MSG2="NO SE ENCONTRO UN ARCHIVO POR EMPRESA NECESARIO PARA $LAFileUniqName"
    $BITACORA "CCF" "C430TransCCF.sh" "C" "10802" "$MSG2"
      exit 6;;
   *) print "System Error."   # Error del Sistema.
    MSG2="FALLO LA GENERACION DEL ARCHIVO CCF $LAFileqName-PASO 4"
    $BITACORA "CCF" "C430TransCCF.sh" "C" "10801" "$MSG2"
      exit $LNStaInter;; 
esac

#exit 0

# Validar el Archivo CCF Unico.
$LAVerUniqProg $LATransPath $LABackupPath $LAFileUniqName 

# Verificar el estatus de termino del proceso previo.

LNStaInter=$?

case $LNStaInter in
   0) LASysDate=$(date +'%Y%m%d %H%M%S')   # El Proceso termino con exito.
      LNStatus=0
      LARegLogFile=$LAFileUniqName"|"$LADate"|"$LAInfMsg2"|"$LAInfMsg3","$LASysDate"|"$LNStatus"|"$LAIDProcess
      print $LARegLogFile >> $LALogFile;;
   1) print "Invalid number of parameters."   # Numero Incorrecto de Parametros.
      exit 1;;
   2) print "There's a preview process in memory."   # Proceso Activado.
      exit 2;;
   3) print "The FileType Parameter's Value is incorrect."  # Parametro Erroneo.
      exit 3;;
   4) print "The Estatus Column's Value is incorrect."   # Estatus Erroneo.
      exit 4;;
   5) print "Wrong Structure of File " $LAFileUniqName   # Registro Incorrecto. 
      exit 5;; 
   6) print "Wrong Structure of File " $LAFileUniqName   # Sin Registro 0000. 
      exit 6;;
   7) print "Wrong Structure of File " $LAFileUniqName   # Sin Registro 9000. 
      exit 7;;
   8) print "Wrong Structure of File " $LAFileUniqName   # Sin Registro 1000. 
      exit 8;;
   9) print "The Insertion of CCF Records failed."   # Falla en Insercion Reg.
      exit 9;;
   10) print "File " $LAFileUniqName " not available."   # Archivo CCF no disp. 
      exit 10;;
   *) print "System Error."   # Error del Sistema.
    MSG2="FALLO LA GENERACION DEL ARCHIVO CCF $LAFileUniqName-PASO 5"
    $BITACORA "CCF" "C430TransCCF.sh" "C" "10801" "$MSG2"
      exit $LNStaInter;; 
esac
#Borra los archivos por empresa que deja el proceso
mmdd=`echo $LAFileUniqName | cut -c4-7 `
if [ -f $LABackupPath/CCF??????*${mmdd}D.txt ]
then
   rm $LABackupPath/CCF??????*${mmdd}D.txt
fi

LAEndDate=$(date)

msg="Termina la generacion del archivo $LAFileUniqName "
echo $msg
registraEstatus "$msg"
msg="Start Date: $LAStartDate"
registraEstatus "$msg"
echo $msg
msg="End Date:  $LAEndDate"
registraEstatus "$msg"
echo $msg


