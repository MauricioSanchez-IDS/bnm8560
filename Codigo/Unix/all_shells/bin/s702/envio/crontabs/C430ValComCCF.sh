#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# NOMBRE	: C430ValComCCF.												#
# DESCRIPCION	: Permite validar la estructura interna de los archivos por Empresa en formato CCF previamente generados por	#
#                 la aplicacion C430TransCCF. Los Archivos Analizados puede ser Diarios o por Fecha de Corte.			#
# PRECEDIDO POR	: C430TransCCF.													#
#																#
#																#
# VARIABLES DE															#
# AMBIENTE		: NOMBRE VARIABLE		DESCRIPCION								#
#																#
#				LAPath		Ruta de Ubicacion Archivos CCF.							#
#				LABackup	Ruta de Respaldo Archivos CCF.							#
#				LAFileType	Modo de Generacion del Archivo.							#
#				LAFileTypeCode	Clave de Modo de Generacion del Archivo.					#
#				LAFileName	Nombre del Archivo CCF.								#
#				LADate		Fecha de Generacion del Archivo (MMDD).						#
#				LAPreffix	Prefijo asociado al Archivo.							#
#				LASuffix	Sufijo asociado al Archivo.							#
#				LAUserName	Nombre de Usuario de UNIX.							#
#				LNProcesses	Numero de Instancias Activas del Programa.					#
#				LAPattern	Patron de Busqueda de Archivos CCF.						#
#				LALogFile	Nombre del Archivo de Log.							#
#				LARegLogFile	Registro de Archivo de Log.							#
#				LASysDate	Fecha del Sistema.								#
#				LNStatus	Estado de Ejecucion del Programa.						#
#				LAIDProcess	Clave de Identificacion del Programa.						#
#				LNCCFFiles	Archivos CCF por Empresa Disponibles en la Ruta Especificada.			#
#				LATempFile	Archivo Temporal.								#
#				LATempISQLFile	Archivo Temporal de resultado de ejecucion de comandos de SQL.			#
#				LAUser		Usuario de Base de Datos.							#
#				LAPassword	Password de Base de Datos.							#
#				LAServer	Servidor de Base de Datos.							#
#				LAISQLUtil	Nombre del Programa para Acceso a Base de Datos.				#
#				LADatabase	Nombre de la Base de Datos del Sistema C430.					#
#				LAStatusTab	Nombre de la Tabla de Registro de Estatus del Proceso de Generacion del Archivo CCF.#
#				LNValStaTab	Valor a Almacenar en la Tabla de Registro de Estatus.				#
#				LNValCurSta	Valor Actual de la columna Estatus de la Tabla de Registro de Estatus.		#
#				LAErrMsg1	Mensaje de Error 1.								#
#				LAErrMsg2	Mensaje de Error 2.								#
#				LAErrMsg3	Mensaje de Error 3.								#
#				LAErrMsg4	Mensaje de Error 4.								#
#				LAErrMsg5	Mensaje de Error 5.								#
#				LAErrMsg6	Mensaje de Error 6.								#
#				LAErrMsg7	Mensaje de Error 7.								#
#				LAErrMsg8	Mensaje de Error 8.								#
#				LAErrMsg9	Mensaje de Error 9.								#
#				LAErrMsg10	Mensaje de Error 10.								#
#				LAErrMsg11	Mensaje de Error 11.								#
#				LAErrMsg12	Mensaje de Error 12.								#
#				LAErrMsg13	Mensaje de Error 13.								#
#				LAErrMsg14	Mensaje de Error 14.								#
#				LAErrMsg15	Mensaje de Error 15.								#
#				LAErrMsg16	Mensaje de Error 16.								#
#				LAErrMsg17	Mensaje de Error 17.								#
#				LAErrMsg18	Mensaje de Error 18.								#
#				LAErrMsg19	Mensaje de Error 19.								#
#				LAErrMsg20	Mensaje de Error 20.								#
#				LAErrMsg21	Mensaje de Error 21.								#
#				LAErrMsg22	Mensaje de Error 22.								#
#				LAErrMsg23	Mensaje de Error 23.								#
#				LAErrMsg24	Mensaje de Error 24.								#
#				LAErrMsg25	Mensaje de Error 25.								#
#				LAErrMsg26	Mensaje de Error 26.								#
#				LAErrMsg27	Mensaje de Error 27.								#
#				LAErrMsg28	Mensaje de Error 28.								#
#				LAInfMsg1	Mensaje Informativo 1.								#
#				LNStructCCFOK	Bandera para verificacion  de Estructura de Archivo CCF Unico.			#
#				LNTotType0000Rec Numero Total de Reg. 0000							#
#				LNTotType1000Rec Numero Total de Reg. 1000							#
#				LNTotType1001Rec Numero Total de Reg. 1001							#
#				LNTotType2000Rec Numero Total de Reg. 2000							#
#				LNTotType2001Rec Numero Total de Reg. 2001							#
#				LNTotType2002Rec Numero Total de Reg. 2002							#
#				LNTotType5000Rec Numero Total de Reg. 5000							#
#				LNTotType5000Val Monto Total de Reg. 5000							#
#				LNTotType5000In9000                        Monto Total de Reg. 5000 en Reg. 9000		#
#				LNTotType5001Rec Numero Total de Reg. 5001							#
#				LNTotType6001Rec Numero Total de Reg. 6001							#
#				LNTotType6002Rec Numero Total de Reg. 6002							#
#				LNTotType6004Rec Numero Total de Reg. 6004							#
#				LNTotType6005Rec Numero Total de Reg. 6005							#
#				LNTotType9000Rec Numero Total de Reg. 9000							#
#				LAResult	Resultado de una operacion de Analisis.					#

# PARAMETROS 	:                                                       #
#                 $0 = Nombre del Programa.                             #
#                 $1 = Ruta de Ubicacion Archivos CCF.                  #
#                 $2 = Ruta de Respaldo Archivos CCF.                   #
#                 $3 = Fecha de Procesamiento (Parametro Opcional).     #
#                                                                       #
#                                                                       # 
# SALIDAS	:                                                       #
#                 Notificacion de Evolucion de Proceso al Archivo de    #
#                 Log C430TransCCF.log.                                 #
# AUTOR		: Vicente Ferrer Andrade <VFA>                          #
# COMPANIA	: Softtek                                               #
# FECHA		: 28/07/2003                                            #
# CONTROL DE                                                            #
# VERSIONES	: V.1.0	                                                #
# CONTROL DE MODIFICACION                                               #
#   IS	      NOMBRE		   FECHA	DESCRIPCION             #
#  VFA  Vicente Ferrer Andrade  28/07/2003  Primer Version              #
# Copyright Derechos Reservados Banamex S.A. de C.V 2003                #
#  Observaciones:                                                       #
#
#. /opt/c430/fuentes/CCF/.variables 
. $(paths.sh 08 PAR)/.variables 


echo "Estoy en el script C430ValComCCF.sh"
echo "Estoy en el script C430ValComCCF.sh"
echo "Estoy en el script C430ValComCCF.sh"

# Determinar el No. de Parametros de Ejecucion.

case $# in
   2) ;;   # No. de Parametros Correcto.
   3) ;;   # No. de Parametros Correcto.
   *) print "Use: C430ValComCCF.sh  <Path> <Backup Path> [<Date>]" 
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
LAPattern=""
LNProcesses=0
LALogFile=$LogFile
LARegLogFile=""
LASysDate=""
LNStatus=0
LAIDProcess="04"
LATempFile=$TempFilePath"TempC430ValComCCF.tmp"
LATempISQLFile=$ISQLFile
LAUser=$UserSYB
LAPassword=$PasswordSYB
LAServer=$ServerSYB
LAISQLUtil=$ISQLUtilSYB
LADatabase=$DatabaseSYB
LAStatusTab=$StatusTabSYB
LNValStaTab=1
LNValCurSta=0
LNCCFFiles=0
LAErrMsg1="No existe(n) archivo(s) CCF por empresa disponible(s)"
LAErrMsg2="Registro de Archivo CCF con Longitud Incorrecta"
LAErrMsg3="Estructura de Registro 0000 Incorrecta o Inexistente"
LAErrMsg4="Estructura de Registro 9000 Incorrecta o Inexistente"
LAErrMsg5="Estructura de Registro 1000 Inexistente"
LAErrMsg6="Inconsistencia en Conteo de Estructuras de Registro 1000"
LAErrMsg7="Estructura de Registro 1001 Inexistente"
LAErrMsg8="Inconsistencia en Conteo de Estructuras de Registro 1001"
LAErrMsg9="Estructura de Registro 2000 Inexistente"
LAErrMsg10="Inconsistencia en Conteo de Estructuras de Registro 2000"
LAErrMsg11="Estructura de Registro 2001 Inexistente"
LAErrMsg12="Inconsistencia en Conteo de Estructuras de Registro 2001"
LAErrMsg13="Estructura de Registro 2002 Inexistente"
LAErrMsg14="Inconsistencia en Conteo de Estructuras de Registro 2002"
LAErrMsg15="Estructura de Registro 5000 Inexistente"
LAErrMsg16="Inconsistencia en Conteo de Estructuras de Registro 5000"
LAErrMsg17="Inconsistencia en Monto Total de Transacciones de Estructuras de Registro 5000"
LAErrMsg18="Estructura de Registro 5001 Inexistente"
LAErrMsg19="Inconsistencia en Conteo de Estructuras de Registro 5001"
LAErrMsg20="Estructura de Registro 60; Subtipo 01 Inexistente"
LAErrMsg21="Inconsistencia en Conteo de Estructuras de Registro Tipo 60; Subtipo 01"
LAErrMsg22="Estructura de Registro 60; Subtipo 02 Inexistente"
LAErrMsg23="Inconsistencia en Conteo de Estructuras de Registro Tipo 60; Subtipo 02"
LAErrMsg24="Estructura de Registro 60; Subtipo 04 Inexistente"
LAErrMsg25="Inconsistencia en Conteo de Estructuras de Registro Tipo 60; Subtipo 04"
LAErrMsg26="Estructura de Registro 60; Subtipo 05 Inexistente"
LAErrMsg27="Inconsistencia en Conteo de Estructuras de Registro Tipo 60; Subtipo 05"
LAInfMsg1="Validacion de la estructura del Archivo CCF OK"
LNStructCCFOK=1
LNTotType0000Rec=0
LNTotType1000Rec=0
LNTotType1001Rec=0
LNTotType2000Rec=0
LNTotType2001Rec=0
LNTotType2002Rec=0
LNTotType5000Rec=0
LNTotType5000Val=0.0
LNTotType5000In9000=0.0
LNTotType5001Rec=0
LNTotType6001Rec=0
LNTotType6002Rec=0
LNTotType6004Rec=0
LNTotType6005Rec=0
LNTotType9000Rec=0
LAResult=""

#<---- Variables para tratamiento de Registros ---->#
set -A  registros 0000 1000 1001 2000 2001 2002211 2002212 2002213 5001511 5001512 5001513 6001 6002 6004 5000 9000
set -A longitudes 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000 1000

#<---- Si se desean agregar mas registros en un futuro descomentar la linea de abajo y agregar ---->#
#<---- los prefijos separados por un espacio, tambien se deben agregar sus longitudes ---->#
#set -A registros
#set -A longitudes 

integer no_regs;
integer index=0;

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

# Establecer la Clave Asociada al Modo de Generacion del Archivo CCF.

if [[ $LAFileType = "0" ]]   # El archivo CCF a generar es Diario.
then
   LAFileTypeCode="D"
elif [[ $LAFileType = "1" ]]   # El archivo CCF a generar es por Fecha de Corte.
then
   LAFileTypeCode="C"
else
   print "The FileType Parameter's Value is incorrect."
   exit 3
fi

# Establecer la Fecha de Generacion del Archivo.

if [[ -z $3 ]]                                  
then                                            
   LADate=$(date +'%m%d')                       
else                                            
   LADate=$3                                    
fi                                              

# Establecer el Nombre del Archivo CCF Unico (para fines de Filtrado).       

LAFileName=$LAPreffix$LADate$LAFileTypeCode$LASuffix

# Establecer el Patron de Busqueda de Archivos CCF.           

LAPattern=$LAPreffix"*"$LADate$LAFileTypeCode$LASuffix        

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

print "<------------------------------------------------------->"
print "La consulta\n"
cat $LATempFile
print "<------------------------------------------------------->"
print "La respuesta\n"
cat $LATempISQLFile
print "<------------------------------------------------------->"


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
   print "<----------------------------------------------------->"
   print "Estos son los valores: " $LNValCurSta " y " $LNValStaTab
   print "The Validation process can't continue."
   exit 4
fi

# Buscar los archivos CCF por Empresa en la Ruta Especificada.

cd $LAPath

# Verificar existencia de Archivos CCF.

ls $LAPattern > $LATempFile     

echo "<--------------------------->"
echo $LAPattern
echo "<--------------------------->"                                                

LNCCFFiles=$(wc -l $LATempFile | awk '{ print $1; }')    

echo "<--------------------------->"
echo $LNCCFFiles
echo "<--------------------------->"

if [[ -a $LATempFile ]]
then
   rm $LATempFile
fi

if [[ $LNCCFFiles < 1 ]]   # No hay archivos CCF disponibles.
then
   LASysDate=$(date +'%Y%m%d %H%M%S')
   LNStatus=1
   LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg1","$LAPattern"|"$LASysDate"|"$LNStatus"|"$LAIDProcess
   print $LARegLogFile >> $LALogFile
   exit 5
fi

for CCFFiles in $(ls $LAPattern | grep -v $LAFileName)
{
   # Iniciar el Analisis de la Estructura del Archivo.

   LNStructCCFOK=1
   LNTotType0000Rec=0
   LNTotType1000Rec=0
   LNTotType1001Rec=0
   LNTotType2000Rec=0
   LNTotType2001Rec=0
   LNTotType2002Rec=0
   LNTotType5000Rec=0
   LNTotType5000Val=0.0
   LNTotType5000In9000=0.0
   LNTotType5001Rec=0
   LNTotType6001Rec=0
   LNTotType6002Rec=0
   LNTotType6004Rec=0
   LNTotType6005Rec=0
   LNTotType9000Rec=0

   # Deteccion de Registros con una Longitud diferente a 1000 caracteres.

  # LAResult=$(awk '{ if(length($0) != 1000) 
  #                     { print $0;  exit 1; } }
  #                     END { print ""; }' $CCFFiles)

  #   if [[ -n $LAResult ]]
  #   then

  # El archivo CCF contiene por lo menos un registro con longitud diferente de 1000 caracteres; generar el registro de Log
  # correspondiente y continuar con el siguiente archivo disponible.

  #      LASysDate=$(date +'%Y%m%d %H%M%S')
  #      LNStatus=1
  #      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg2","$CCFFiles"|"$LASysDate"|"$LNStatus"|"$LAIDProcess

  #      print $LARegLogFile >> $LALogFile
  #      LNStructCCFOK=0
  #      mv $CCFFiles $LABackup
  #      continue 
 
  #   fi

   # Iniciar el Analisis de la Estructura del Archivo.
   # Deteccion de Registros con una Longitud diferente a 1000 caracteres.
  
   #<---- Determinando numero de Registros ---->#
   no_regs=$(echo ${registros[*]} | wc -w)

   #<---- Determinando Longitudes de registros ---->#
   while((index<$no_regs))
    do
     echo "Procesando registro " ${registros[$index]}

     #<---- Extraemos el tipo de registro en turno del archivo original ---->#
     cat $CCFFiles | grep ^${registros[$index]} > Rec${registros[$index]}.txt

     #<---- Revisamos que no exista ningun registro exceda su longitud correspondiente ---->#
     LAResult=$(awk '{ if(length($0) != '${longitudes[$index]}' )
                         { print $0;  exit 1; } }
                           END { print ""; }' Rec${registros[$index]}.txt)

     #<---- Si lo excedio se aborta el proceso ---->#
     if [[ -n $LAResult ]]
      then

      #El archivo CCF contiene por lo menos un registro con longitud diferente de 1000 caracteres; generar el registro de Log
      #correspondiente y continuar con el siguiente archivo disponible.

     LASysDate=$(date +'%Y%m%d %H%M%S')
     LNStatus=1
     LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg2","$CCFFiles"|"$LASysDate"|"$LNStatus"|"$LAIDProcess

     print $LARegLogFile >> $LALogFile
     LNStructCCFOK=0
     mv $CCFFiles $LABackup
     continue
    fi

    #<---- Borramos archivos temporales---->#
    rm Rec${registros[$index]}.txt

    #<---- Siguiente Registro ---->#
    (( index = index + 1));
   done 

   # Deteccion de Registros Ausentes.

   awk 'BEGIN { 
           iType0000RecCnt=0;       # No. de Registros Tipo 0000.
           iType1000RecCnt=0;       # No. de Registros Tipo 1000.
           iType1001RecCnt=0;       # No. de Registros Tipo 1001.
           iType2000RecCnt=0;       # No. de Registros Tipo 2000.
           iType2001RecCnt=0;       # No. de Registros Tipo 2001.
           iType2002RecCnt=0;       # No. de Registros Tipo 2002.
           iType5000RecCnt=0;       # No. de Registros Tipo 5000.
           fType5000Value=0.0;      # Monto Total de Registros Tipo 5000.
           iType5001RecCnt=0;       # No. de Registros Tipo 5001.
           iType6001RecCnt=0;       # No. de Registros Tipo 6001.
           iType6002RecCnt=0;       # No. de Registros Tipo 6002.
           iType6004RecCnt=0;       # No. de Registros Tipo 6004.
           iType6005RecCnt=0;       # No. de Registros Tipo 6005.
           iType9000RecCnt=0;       # No. de Registros Tipo 9000. 
           iTotType1000Rec=0;       # No. de Registros Tipo 1000 (en Reg. 9000).
           iTotType1001Rec=0;       # No. de Registros Tipo 1001 (en Reg. 9000).
           iTotType2000Rec=0;       # No. de Registros Tipo 2000 (en Reg. 9000).
           iTotType2001Rec=0;       # No. de Registros Tipo 2001 (en Reg. 9000).
           iTotType2002Rec=0;       # No. de Registros Tipo 2002 (en Reg. 9000).
           iTotType5000Rec=0;       # No. de Registros Tipo 5000 (en Reg. 9000).
           fTotType5000Val=0.0;     # Monto Total Reg. Tipo 5000 (en Reg. 9000).
           iTotType5001Rec=0;       # No. de Registros Tipo 5001 (en Reg. 9000).
           iTotType6001Rec=0;       # No. de Registros Tipo 6001 (en Reg. 9000).
           iTotType6002Rec=0;       # No. de Registros Tipo 6002 (en Reg. 9000).
           iTotType6004Rec=0;       # No. de Registros Tipo 6004 (en Reg. 9000).
           iTotType6005Rec=0;       # No. de Registros Tipo 6005 (en Reg. 9000).
        } 
        {
           sRecType=substr($0, 1, 4);   # Extraccion de Tipo de Registro.

	if(sRecType == "0000")
	{
		# Contabilizar el Registro 0000.
		iType0000RecCnt++;
	}

	if(sRecType == "9000")
	{
		# Contabilizar el Registro 9000.

		iType9000RecCnt++;

		iTotType1000Rec=int(substr($0, 125, 18));
		iTotType1001Rec=int(substr($0, 143, 18));
		iTotType2000Rec=int(substr($0, 161, 18));
		iTotType2001Rec=int(substr($0, 179, 18));
		iTotType2002Rec=int(substr($0, 197, 18));
		iTotType5000Rec=int(substr($0, 215, 18));
		fTotType5000Val=substr($0, 233, 18) + 0.0;
		iTotType5001Rec=int(substr($0, 251, 18));
		iTotType6001Rec=int(substr($0, 269, 18));
		iTotType6002Rec=int(substr($0, 287, 18));
		iTotType6004Rec=int(substr($0, 305, 18));
		iTotType6005Rec=int(substr($0, 323, 18));
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
		fType5000Value+=(substr($0, 74, 18) + 0.0);
	}

	if(sRecType == "6001")
	{
		# Contabilizar el Registro 6001.
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
           printf "%d|%d|%d|%d|%d|%d|%d|%d|%0.2f|%d|%d|%d|%d|%d|%d|%d|%d|%d|%d|%d|%0.2f|%d|%d|%d|%d|%d\n",
                                 iType0000RecCnt, iType9000RecCnt,
                                 iType1000RecCnt, iType1001RecCnt, 
                                 iType2000RecCnt, iType2001RecCnt,
                                 iType2002RecCnt, iType5000RecCnt,
                                 fType5000Value, iType5001RecCnt,
                                 iType6001RecCnt, iType6002RecCnt,
                                 iType6004RecCnt, iType6005RecCnt,
                                 iTotType1000Rec, iTotType1001Rec,
                                 iTotType2000Rec, iTotType2001Rec,
                                 iTotType2002Rec, iTotType5000Rec,
                                 fTotType5000Val, iTotType5001Rec,
                                 iTotType6001Rec, iTotType6002Rec,
                                 iTotType6004Rec, iTotType6005Rec;
        }' $CCFFiles > $LATempFile
 
   # Registro 0000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $1; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg3","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   else
      LNTotType0000Rec=$LAResult
   fi
 
   # Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $2; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg4","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   else
      LNTotType9000Rec=$LAResult
   fi

   # Registro 1000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $3; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg5","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   else
      LNTotType1000Rec=$LAResult
   fi

   # Total Registro 1000 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $15; }' $LATempFile)

   if [[ $LNTotType1000Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg6","$CCFFiles"|"$LNTotType1000Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi
   
   # Registro 1001.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $4; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg7","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType1001Rec=$LAResult
   fi

   # Total Registro 1001 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $16; }' $LATempFile)

   if [[ $LNTotType1001Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg8","$CCFFiles"|"$LNTotType1001Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi
   
   # Registro 2000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $5; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg9","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType2000Rec=$LAResult
   fi

   # Total Registro 2000 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $17; }' $LATempFile)

   if [[ $LNTotType2000Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg10","$CCFFiles"|"$LNTotType2000Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Registro 2001.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $6; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg11","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType2001Rec=$LAResult
   fi

   # Total Registro 2001 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $18; }' $LATempFile)

   if [[ $LNTotType2001Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg12","$CCFFiles"|"$LNTotType2001Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Registro 2002.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $7; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg13","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType2002Rec=$LAResult
   fi
   
   # Total Registro 2002 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $19; }' $LATempFile)

   if [[ $LNTotType2002Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg14","$CCFFiles"|"$LNTotType2002Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Registro 5000.

   # No. de Registros.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $8; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg15","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType5000Rec=$LAResult
   fi
   
   # Total Registro 5000 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $20; }' $LATempFile)

   if [[ $LNTotType5000Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg16","$CCFFiles"|"$LNTotType5000Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Monto de Transacciones.

   # Total Registro 5000 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $9; }' $LATempFile)

   LNTotType5000Val=$LAResult

   LAResult=$(awk 'BEGIN { FS="|"; }           
                { print $21; }' $LATempFile)

   LNTotType5000In9000=$LAResult

   if [[ $LNTotType5000Val != $LNTotType5000In9000 ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg17","$CCFFiles"|"$LNTotType5000Val,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Registro 5001.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $10; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg18","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType5001Rec=$LAResult
   fi
   
   # Total Registro 5001 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $22; }' $LATempFile)

   if [[ $LNTotType5001Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg19","$CCFFiles"|"$LNTotType5001Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Registro 6001.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $11; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg20","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType6001Rec=$LAResult
   fi
   
   # Total Registro 6001 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $23; }' $LATempFile)

   if [[ $LNTotType6001Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg21","$CCFFiles"|"$LNTotType6001Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Registro 6002.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $12; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg22","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType6002Rec=$LAResult
   fi
   
   # Total Registro 6002 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $24; }' $LATempFile)

   if [[ $LNTotType6002Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg23","$CCFFiles"|"$LNTotType6002Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Registro 6004.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $13; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg24","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType6004Rec=$LAResult
   fi
   
   # Total Registro 6004 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $25; }' $LATempFile)

   if [[ $LNTotType6004Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg25","$CCFFiles"|"$LNTotType6004Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Registro 6005.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $14; }' $LATempFile)

   if [[ $LAResult < 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=2
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg26","$CCFFiles"|"$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

   else
      LNTotType6005Rec=$LAResult
   fi
   
   # Total Registro 6005 en Registro 9000.

   LAResult=$(awk 'BEGIN { FS="|"; }
                   { print $26; }' $LATempFile)

   if [[ $LNTotType6005Rec != $LAResult ]]
   then

      # Generar el registro de Log correspondiente y continuar con el siguiente archivo disponible.

      LNStatus=1
      LARegLogFile=$LAFileName"|"$LADate"|"$LAErrMsg27","$CCFFiles"|"$LNTotType6005Rec,$LAResult"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      LNStructCCFOK=0
      mv $CCFFiles $LABackup
      continue 

   fi

   # Estructura de Archivo Unico CCF correcta.

   if [[ $LNStructCCFOK = 1 ]]
   then

      # Generar el registro de Log correspondiente.

      LNStatus=0
      LARegLogFile=$LAFileName"|"$LADate"|"$LAInfMsg1"|"$CCFFiles"|"$LNStatus"|"$LAIDProcess

      print $LARegLogFile >> $LALogFile

      if [[ -a $LATempFile ]]
      then
         rm $LATempFile
      fi

      mv $CCFFiles $LABackup

   fi
}

# Construccion de script de SQL para actualizar la tabla de Estatus del Proceso de Generacion del Archivo Unico
# CCF MTCCCF01 (Validacion de Archivos CCF por Empresa).

LNValStaTab=2

echo "use "$LADatabase > $LATempFile
echo "go" >> $LATempFile
echo "if exists (select * from "$LAStatusTab >> $LATempFile
echo "           where nom_archivo = '"$LAFileName"')" >> $LATempFile
echo "   begin" >> $LATempFile
echo "      update "$LAStatusTab >> $LATempFile
echo "      set estatus = "$LNValStaTab >> $LATempFile
echo "      where nom_archivo = '"$LAFileName"'" >> $LATempFile
echo "   end" >> $LATempFile
echo "go" >> $LATempFile
echo "exit" >> $LATempFile

$LAISQLUtil -U$LAUser -P$LAPassword -S$LAServer -i$LATempFile

if [[ -a $LATempFile ]]
then 
   rm $LATempFile
fi

exit 0
