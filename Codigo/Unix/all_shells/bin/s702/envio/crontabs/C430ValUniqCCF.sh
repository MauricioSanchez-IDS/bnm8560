#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# NOMBRE	: C430ValUniqCCF.											#
# DESCRIPCION	: Permite validar la estructura interna de el archivo UNICO en formato CCF previamente generado por la	#
#                 aplicacion C430GenUniqCCF. El archivo analizado puede ser Diario o por Fecha de Corte.		#
# PRECEDIDO POR	: C430GenUniqCCF.											#
#															#
#															#
# VARIABLES DE														#
# AMBIENTE		: NOMBRE VARIABLE           DESCRIPCION								#
#															#
#                            LAPath           Ruta de Ubicacion	Archivo CCF Unico.					# 
#                            LABackup         Ruta de Respaldo								#
#                                             Archivos CCF.								#
#                            LAFileType       Modo de Generacion del							#
#                                             Archivo.                  						#
#                            LAFileTypeCode   Clave de Modo de          						#
#                                             Generacion del Archivo.   						#
#                            LAFileName       Nombre del Archivo        						#
#                                             Unico.                    						#
#                            LADate           Fecha de Generacion del   						#
#                                             Archivo (MMDD).           						#
#                            LAPreffix        Prefijo asociado al       						#
#                                             Archivo.                  						#
#                            LASuffix         Sufijo asociado al        						#
#                                             Archivo.                  						#
#                            LAUserName       Nombre de Usuario de      						#
#                                             UNIX.                     						#
#                            LNProcesses      Numero de Instancias Activas del Programa.     				# 
#                            LALogFile        Nombre del Archivo de Log.						#
#                            LARegLogFile     Registro de Archivo de Log.						#
#                            LASysDate        Fecha del Sistema.							#
#                            LNStatus         Estado de Ejecucion del Programa.						#
#                            LNStaInter       Estado de Ejecucion de procesos intermedios.				#
#                            LAIDProcess      Clave de Identificacion del Programa.					#
#                            LATempFile       Archivo Temporal.								#
#                            LATempISQLFile   Archivo Temporal de resultado de ejecucion de comandos de SQL.		#
#                            LAUser           Usuario de Base de Datos.							#
#                            LAPassword       Password de Base de Datos.						#
#                            LAServer         Servidor de Base de Datos.						#
#                            LAISQLUtil       Nombre del Programa para Acceso a Base de Datos.				#
#                            LADatabase       Nombre de la Base de Datos del Sistema C430.				#
#                            LAStatusTab      Nombre de la Tabla de Registro de Estatus del Proceso de Generacion del Archivo CCF#
#                            LNValStaTab      Valor a Almacenar en la Tabla de Registro de Estatus.			#
#                            LNValCurSta      Valor Actual de la columna Estatus de la Tabla de Registro de Estatus.	#
#                            LAInsertProg     Programa para insertar los registros del Archivo CCF Unico en la Base.	#
#                            LAErrMsg1        Mensaje de Error 1.							#
#                            LAErrMsg2        Mensaje de Error 2.							#
#                            LAErrMsg3        Mensaje de Error 3.							#
#                            LAErrMsg4        Mensaje de Error 4.							#
#                            LAErrMsg5        Mensaje de Error 5.							#
#                            LAErrMsg6        Mensaje de Error 6.							#
#                            LAErrMsg7        Mensaje de Error 7.							#
#                            LAErrMsg8        Mensaje de Error 8.							#
#                            LAErrMsg9        Mensaje de Error 9.							#
#                            LAErrMsg10       Mensaje de Error 10.							#
#                            LAErrMsg11       Mensaje de Error 11.							#
#                            LAErrMsg12       Mensaje de Error 12.							#
#                            LAErrMsg13       Mensaje de Error 13.							#
#                            LAErrMsg14       Mensaje de Error 14.							#
#                            LAErrMsg15       Mensaje de Error 15.							#
#                            LAInfMsg1        Mensaje Informativo 1.							#
#                            LNStructCCFOK    Bandera para verificacion de Estructura de Archivo CCF Unico.		#
#                            LAResult         Resultado de una operacion de Analisis.					#

# PARAMETROS 	:                                                       #
#                 $0 = Nombre del Programa.                             #
#                 $1 = Ruta de Ubicacion Archivo CCF Unico.             #
#                 $2 = Ruta de Respaldo Archivo CCF Unico.              #
#                 $3 = Nombre del Archivo CCF Unico (Parametro          #
#                      Opcional).                                       #
#                                                                       #
#                                                                       # 
# SALIDAS	:                                                       #
#                 Notificacion de Evolucion de Proceso al Archivo de    #
#                 Log C430TransCCF.log.                                 #
# AUTOR		: Vicente Ferrer Andrade <VFA>                          #
# COMPANIA	: Softtek                                               #
# FECHA		: 24/07/2003                                            #
# CONTROL DE                                                            #
# VERSIONES	: V.1.0	                                                #
# CONTROL DE MODIFICACION                                               #
#   IS	      NOMBRE		   FECHA	DESCRIPCION             #
#  VFA  Vicente Ferrer Andrade  24/07/2003  Primer Version              #
# Copyright Derechos Reservados Banamex S.A. de C.V 2003                #
#  Observaciones:                                                       #
#
#. /opt/c430/fuentes/CCF/.variables
. $(paths.sh 08 PAR)/.variables

# Determinar el No. de Parametros de Ejecucion.

case $# in
   2) ;;   # No. de Parametros Correcto.
   3) ;;   # No. de Parametros Correcto.
   *) print "Use: C430GenUniqCCF.sh <Path> <Backup Path> [<File Name>]" 
      exit 1 ;;
esac

# Inicializacion de Variables.

LAPath=$1
LAFileType=$FileMode
LABackup=$2
LAFileTypeCode=""
LAFileName=""
LADate=""
LAPreffix=$PreffixCCF
LASuffix=$SuffixCCF
LAUserName=$UserNameUNIX
LNProcesses=0
LALogFile=$LogFile
LARegLogFile=""
LASysDate=""
LNStatus=0
LNStaInter=0
LAIDProcess="06"
LATempFile=$TempFilePath"TempC430ValUniqCCF.tmp"
LATempISQLFile=$ISQLFile
LAUser=$UserSYB
LAPassword=$PasswordSYB
LAServer=$ServerSYB
LAISQLUtil=$ISQLUtilSYB
LADatabase=$DatabaseSYB
LAStatusTab=$StatusTabSYB
LNValStaTab=3
LNValCurSta=0
LAInsertProg=$CronPath"C430InsertCCF.sh"
LAErrMsg1="Archivo CCF No Disponible para validacion de Estructura"
LAErrMsg2="Registro de Archivo CCF con Longitud Incorrecta"
LAErrMsg3="Estructura de Registro 0000 Incorrecta o Inexistente"
LAErrMsg4="Estructura de Registro 9000 Incorrecta o Inexistente"
LAErrMsg5="Estructura de Registro 1000 Inexistente"
LAErrMsg6="Estructura de Registro 1001 Inexistente"
LAErrMsg7="Estructura de Registro 2000 Inexistente"
LAErrMsg8="Estructura de Registro 2001 Inexistente"
LAErrMsg9="Estructura de Registro 2002 Inexistente"
LAErrMsg10="Estructura de Registro 5000 Inexistente"
LAErrMsg11="Estructura de Registro 5001 Inexistente"
LAErrMsg12="Estructura de Registro 60; Subtipo 01 Inexistente"
LAErrMsg13="Estructura de Registro 60; Subtipo 02 Inexistente"
LAErrMsg14="Estructura de Registro 60; Subtipo 04 Inexistente"
LAErrMsg15="Estructura de Registro 60; Subtipo 05 Inexistente"
LAInfMsg1="Validacion de la estructura del Archivo CCF Unico OK"
LNStructCCFOK=1
LAResult=""

#<---- Variables para tratamiento de Registros ---->#
set -A  registros 0000 1000 1001 2000 2001 2002211 2002212 2002213 5001511 5001512 5001513 6001 6002 6004 5000 9000
set -A longitudes 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000

#<---- Si se desean agregar mas registros en un futuro descomentar la linea de abajo y agregar ---->#
#<---- los prefijos separados por un espacio, tambien se deben agregar sus longitudes ---->#
#set -A registros
#set -A longitudes 

LAFileName=$1
integer no_regs
integer index=0


# Eliminar archivos temporales.

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi

if [[ -a $LATempISQLFile ]]
then
   rm $LATempISQLFile
fi

# Determinar el No. de Procesos Activos.

ps -ef | grep $LAUserName | grep $0 | grep "sh -c" | grep -v grep > $LATempFile

LNProcesses=$(wc -l $LATempFile | awk '{ print $1; }')

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi

if [[ $LNProcesses > 1 ]]   # No puede haber mas de un proceso activo.
then
   print "The process " $0 " is online."
   exit 2
fi


# Establecer el Nombre del Archivo CCF Unico.

if [[ -z $3 ]]
then          

   # Establecer la Fecha de Generacion del Archivo (en caso de que el Parametro File Name no haya sido definido).

   LADate=$(date +'%m%d')

   # Establecer la Clave Asociada al Modo de Generacion del Archivo CCF Unico.

   if [[ $LAFileType = "0" ]]   # El archivo CCF Unico es Diario.
   then
      LAFileTypeCode="D" 
   elif [[ $LAFileType = "1" ]]   # El archivo CCF Unico es por Fecha de Corte.
   then
      LAFileTypeCode="C"
   else
      print "The FileType Parameter's Value is incorrect."
      exit 3
   fi

   LAFileName=$LAPreffix$LADate$LAFileTypeCode$LASuffix 

else

   LAFileName=$3
   LADate=$(print $LAFileName | awk '{ print substr($0, 4, 4); }')
   LAFileTypeCode=$(print $LAFileName | awk '{ print substr($0, 8, 1); }')

fi

# Construccion de script de SQL para analizar la tabla de Estatus del Proceso de Generacion del Archivo Unico
# CCF MTCCCF01.
 
echo "use "$LADatabase > $LATempFile
echo "go" >> $LATempFile
echo "if exists (select * from "$LAStatusTab >> $LATempFile
echo "           where nom_archivo = '"$LAFileName"')" >> $LATempFile
echo "   begin" >> $LATempFile
echo "      select estatus from "$LAStatusTab >> $LATempFile
echo "      where nom_archivo = '"$LAFileName"'" >> $LATempFile
echo "   end" >> $LATempFile
echo "go" >> $LATempFile
echo "exit" >> $LATempFile
 
chmod 775 $LATempFile                                                          
 
$LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -i$LATempFile -o$LATempISQLFile

LNValCurSta=$(awk '{ if(NR==3) { print $1; } }' $LATempISQLFile)

if [[ -a $LATempFile ]]
then 
   rm $LATempFile
fi

if [[ -a $LATempISQLFile ]]
then
   rm $LATempISQLFile
fi

# Verificar el valor actual de la Tabla de Estatus.
 
if [[ $LNValCurSta -ne $LNValStaTab ]]
then
   print "The Validation of Unique CCF File's process can't continue."
   exit 4
fi

# Buscar el Archivo CCF Unico en la Ruta Especificada.

cd $LAPath

# Verificar si el Archivo CCF unico ya fue generado previamente.

if [[ -a $LAFileName ]]
then

   # Iniciar el Analisis de la Estructura del Archivo.

   # Deteccion de Registros con una Longitud diferente a 1000 caracteres.
  
   #<---- Determinando numero de Registros ---->#
   no_regs=$(echo ${registros[*]} | wc -w)

   #<---- Determinando Longitudes de registros ---->#
   while((index<$no_regs))
    do
     echo "Procesando registro " ${registros[$index]}

     #<---- Extraemos el tipo de registro en turno del archivo original ---->#
     cat $LAFileName | grep ^${registros[$index]} > Rec${registros[$index]}.txt

      echo del siguiente archivo compara la longitud contra las longitudes
      echo Rec${registros[$index]}.txt
      echo "--------------xxxxxxxxxxxxxxxxxxxxxxx-----------------"

     #<---- Revisamos que no exista ningun registro exceda su longitud correspondiente ---->#
     LAResult=$(awk '{ if(length($0) != '${longitudes[$index]}' )
                         { print $0;  exit 1; } }
                           END { print ""; }' Rec${registros[$index]}.txt)

     #<---- Si lo excedio se aborta el proceso ---->#
     if [[ -n $LAResult ]]
      then
       echo Fallo en el registro ${registros[$index]}
       echo Longitud del registro $(echo LAResult | wc)
     
       # El archivo CCF contiene por lo menos un registro con longitud diferente; generar el registro de Log
       # correspondiente y dar por concluido el proceso.

       LASysDate=$(date +'%Y%m%d %H%M%S')
       LNStatus=1
       LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg2"|"$LASysDate"|"$LNStatus"|"$LAIDProcess

       print $LARegLogFile >> $LALogFile
       LNStructCCFOK=0
       mv $LAFileName $LABackup
       ## AGA se elimina momentaneamente el borrado
       ##rm Rec${registros[$index]}.txt

       echo " "
       echo " "
       echo " "
       echo $(pwd)
        
       echo " "
       echo " "
       echo " "
       mv Rec${registros[$index]}.txt Rec${registros[$index]}.txt_B

      exit 5
    fi

    #<---- Borramos archivos temporales---->#
    #### AGA ###
    ##rm Rec${registros[$index]}.txt

    #<---- Siguiente Registro ---->#
    (( index = index + 1))
   done 

   # Deteccion de Registros Ausentes.

   awk 'BEGIN {
           iType0000RecCnt=0;       # No. de Registros Tipo 0000.
           iType9000RecCnt=0;       # No. de Registros Tipo 9000.
           iType1000RecCnt=0;       # No. de Registros Tipo 1000.
           iType1001RecCnt=0;       # No. de Registros Tipo 1001.
           iType2000RecCnt=0;       # No. de Registros Tipo 2000.
           iType2001RecCnt=0;       # No. de Registros Tipo 2001.
           iType2002RecCnt=0;       # No. de Registros Tipo 2002.
           iType5000RecCnt=0;       # No. de Registros Tipo 5000.
           iType5001RecCnt=0;       # No. de Registros Tipo 5001.
           iType6001RecCnt=0;       # No. de Registros Tipo 6001.
           iType6002RecCnt=0;       # No. de Registros Tipo 6002.
           iType6004RecCnt=0;       # No. de Registros Tipo 6004.
           iType6005RecCnt=0;       # No. de Registros Tipo 6005.
           iCompID=0;               # Clave de la Empresa.
        } 
        {
           sRecType=substr($0, 1, 4);   # Extraccion de Tipo de Registro.

           if(sRecType == "0000")
           {                                 
              iCompID=int(substr($0, 108, 6));   # Extraer ID Empresa.
              # Contabilizar el Registro 0000.
                                                              
              if(iCompID != 0)
              {                                                          
                 iType0000RecCnt++;
              }
           }

           if(sRecType == "9000")
           {                                 
              iCompID=int(substr($0, 108, 6));   # Extraer ID Empresa.
              # Contabilizar el Registro 9000.
                                                              
              if(iCompID != 0) 
              {                                                          
                 iType9000RecCnt++;
              }
           }                                                             

           if(sRecType == "1000")
           {                                 
              # Contabilizar el Registro 1000.
              iType1000RecCnt++;
           }                                                             
                                                             
           if(sRecType == "1001")
           {                                 
              # Contabilizar el Registro 1001.
              iType1001RecCnt++;
           }                                                             

           if(sRecType == "2000")
           {                                 
              # Contabilizar el Registro 2000.
              iType2000RecCnt++;
           }                                                             

           if(sRecType == "2001")
           {                                 
              # Contabilizar el Registro 2001.
              iType2001RecCnt++;
           }                                                             

	   if(sRecType == "2002")
           {                                 
              # Contabilizar el Registro 2002.
              iType2002RecCnt++;
           }                                                             

           if(sRecType == "5000")
           {                                 
              # Contabilizar el Registro 5000.
              iType5000RecCnt++;
           }                                                             

           if(sRecType == "6001")
           {                                 
              iType6001RecCnt++;
           }                                                             

           if(sRecType == "6002")
           {                                 
              # Contabilizar el Registro 6002.
              iType6002RecCnt++;
           }                                                             

           if(sRecType == "6004")
           {                                 
              # Contabilizar el Registro 6004.
              iType6004RecCnt++;
           }                                                             

           if(sRecType == "6005")
           {                                 
              # Contabilizar el Registro 6005.
              iType6005RecCnt++;
           }                                                             
        }
        END {
           printf "%d|%d|%d|%d|%d|%d|%d|%d|%d|%d|%d|%d|%d\n",
                                 iType0000RecCnt, iType9000RecCnt,
                                 iType1000RecCnt, iType1001RecCnt, 
                                 iType2000RecCnt, iType2001RecCnt,
                                 iType2002RecCnt, iType5000RecCnt,
                                 iType5001RecCnt, iType6001RecCnt,
                                 iType6002RecCnt, iType6004RecCnt,
                                 iType6005RecCnt;
        }' $LAFileName >> $LATempFile

   # Registro 0000.

## AGA marca la siguiente linea como error
   ##LAResult=$(awk 'BEGIN { FS="|"; } { print $1; }' $LATempFile )

   LAResult=$(awk -F"|" '{ print $1 }' $LATempFile )

echo "HP-> File: $LATempFile LAResult : $LAResult"

## AGA marca la siguiente linea como error y no sirve para nada
##cat $LATempFile)
echo $( cat $LATempFile )


   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente y dar por concluido el proceso.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg3"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
	 ## AGA no borrare el archivo para tracear
         ##rm $LATempFile
	 mv $LATempFile archivo_tempo.txt
	 ##rm $LATempFile
	 echo "modificar cuando funcione"
      fi

      LNStructCCFOK=0
      mv $LAFileName $LABackup
echo "HP-> Salgo de Script"
      exit 6

   fi

   # Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; } { print $2; }' $LATempFile )

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente y dar por concluido el proceso.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg4"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then 
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $LAFileName $LABackup
      exit 7

   fi

   # Registro 1000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $3; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente y dar por concluido el proceso.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg5"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $LAFileName $LABackup
      exit 8

   fi

   # Registro 1001.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $4; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg6"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi

   # Registro 2000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $5; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg7"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi

   # Registro 2001.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $6; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg8"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi

   # Registro 2002.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $7; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg9"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi

   # Registro 5000.

   # No. de Registros.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $8; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg10"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi

   # Registro 5001.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $9; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg11"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi
   
   # Registro 6001.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $10; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg12"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi
   
   # Registro 6002.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $11; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg13"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi
   
   # Registro 6004.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $12; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg14"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi
   
   # Registro 6005.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $13; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg15"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   fi

   # Estructura de Archivo Unico CCF correcta.

   if [[ $LNStructCCFOK = 1 ]]
   then

      # Ejecuta el programa para insertar los registros del Archivo CCF Unico en la Base de Datos.

      $LAInsertProg $LAPath $LADate

      LNStaInter=$?

      # Verificar si la rutina de Insercion de Registros se completo con exito.

      if [[ $LNStaInter -eq 0 ]]
      then 

         # Generar el registro de Log correspondiente.

         LNStatus=0

         if [[ -a $LATempFile ]]
         then
            rm $LATempFile
         fi

         LARegLogFile=$LAFileName"|"$LADate"|"$LAInfMsg1"|"$LAFileName"|"$LNStatus"|"$LAIDProcess

         print $LARegLogFile >> $LALogFile

         # Construccion de script de SQL para actualizar la tabla de Estatus del Proceso de Generacion del Archivo Unico
         # CCF MTCCCF01 (Validacion de Archivo CCF Unico).

         LNValStaTab=4
         tamanio=`ls -l ${TransPath}/$LAFileName | tr -s ' ' | cut -d' ' -f5`

         echo "use "$LADatabase > $LATempFile
         echo "go" >> $LATempFile
         echo "if exists (select * from "$LAStatusTab >> $LATempFile
         echo "           where nom_archivo = '"$LAFileName"')" >> $LATempFile
         echo "   begin" >> $LATempFile
         echo "      update "$LAStatusTab >> $LATempFile
         echo "      set estatus = "$LNValStaTab >> $LATempFile
         echo "      , tamanio=$tamanio " >> $LATempFile
         echo "      where nom_archivo = '"$LAFileName"'" >> $LATempFile
         echo "   end" >> $LATempFile
         echo "go" >> $LATempFile
         echo "exit" >> $LATempFile
 
         $LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -i$LATempFile

         if [[ -a $LATempFile ]]
         then 
            rm $LATempFile
         fi

      else

         print "The CCF File Records were not inserted in Database"

         if [[ -a $LATempFile ]]
         then
            rm $LATempFile
         fi

         exit 9

      fi

   fi

else

   # Generar el registro de Log correspondiente y dar por concluido el proceso.

   LASysDate=$(date +'%Y%m%d %H%M%S')
   LNStatus=1

   if [[ -a $LATempFile ]]
   then
      rm $LATempFile
   fi

   LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg1"|"$LASysDate"|"$LNStatus"|"$LAIDProcess

   print $LARegLogFile >> $LALogFile
   mv $LAFileName $LABackup
   exit 10 
 
fi

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi

exit 0
