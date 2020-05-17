#!/usr/bin/ksh 
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 07 CRO)
# Procedimiento: ejecutaBCP.sh
# Descripción:
# Versión y fecha: 1.0
# Autor: YMF    03/11/97
# Modificaciones: septiembre de 2002
# proposito: Adecuar a directorios estandar
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 07 LOG)/ejecutaBCP.log
exec 2>&1
#set -x

#LANG=C
#locale

LD_LIBRARY_PATH=/optware/sybase/ase157sp104/ASE-15_0/lib:/optware/sybase/ase157sp104/DataAccess64/ODBC/lib:/optware/sybase/ase157sp104/DataAccess/ODBC/lib:/optware/sybase/ase157sp104/OCS-15_0/lib:/optware/sybase/ase157sp104/OCS-15_0/include:/usr/lib:/opt/c046/105/lib
export LD_LIBRARY_PATH
DIR_ARCH2=$(paths.sh 07 RES)
DIR_ARCH=$(paths.sh 07 DEP) 
DIR_CARGA=$(paths.sh 07 BIN)
DIR_PARAM=$(paths.sh 07 PAR)
DIR_LOGS=$(paths.sh 07 LOG)
DIR_TEMP=$(paths.sh 07 TMP)
DIR_BIN=$(paths.sh 01 BIN)


####################################
ESTATUS=$DIR_BIN/estatus_c430.sh  
BITACORA=$DIR_BIN/bitacoraITO.sh
VALIDA=$DIR_BIN/valida.sh
HORA=$(date '+%H:%M')
#################################### 

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 07 CRO)
export DIR_ARCH DIR_TEMP DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS PATH

SERVIDOR=$(servidor.sh)
USUARIO=$(usuario.sh)
PASSWD=$(password.sh)

export SERVIDOR USUARIO PASSWD

# Variables de Sybase
	SYBASE=$(sybase.sh)
	DSQUERY=$(servidor.sh)
	USER=$(base.sh)
export SYBASE DSQUERY USER


# CONSULTA ESTATUS DEL SISTEMA C430 
#/** $ESTATUS **/

#  VALIDA QUE SEA MAS DE LAS 10:00 AM 
if [[ $HORA = "10:00" ]]
then
  $VALIDA
  RESULT=$?  
  case "$RESULT" in 
      1) $BITACORA "PROCESO DE CARGA" "ejecutaBCP.sh" "M" "10005" "LA CARGA ESTA INCOMPLETA"
      ;;
      2) $BITACORA "PROCESO DE CARGA" "ejecutaBCP.sh" "M" "10006" "NO HA LLEGADO NINGUN ARCHIVO DEL S111"
      ;;
  esac 
fi

tMaxEspera=120	#en minutos
tMaxSinModif=5
readonly tMaxEspera tMaxSinModif

registraEstatus () {
	f=`date '+%Y%m%d%H%M%S'`
	echo "$1:$f:$2:$3" ###>> $DIR_LOGS/integraArchS111.log
}

compruebaErr () {
	if [ $? -ne 0 ]
	then
		#echo "Error al intentar escribir en REGTIEMPO\n"
		msg="ERROR AL ESCRIBIR EN REGTIEMPO. SIN PERMISO DE ESCRITURA"
		estatus=40	# Poner estatus adecuado
		registraEstatus "noArch" $estatus "$msg"
                $BITACORA "PROCESO DE CARGA" "ejecutaBCP.sh" "C" "10040" "$msg"
                exit 0
	fi
}

iniREGTIEMPO () {
	echo "0\n0" > $DIR_PARAM/REGTIEMPO
	compruebaErr
}

# Verifica que haya al menos un archivo a procesar
totArch=`ls $DIR_ARCH | grep -c -f $DIR_PARAM/arch.list`
#echo "- Total de archivos encontrados: $totArch\n"
if [ $totArch -le 0 ]				#1
then
	exit 0
fi										#x1

# Verifica que no haya otros procesos levantados
programa=`ps -fe | grep -c -f $DIR_PARAM/archInteg.list | grep -v grep`
#echo "- Numero de procesos levantados $programa\n"
if [ $programa -gt 0 ] #Se sale si hay otro proceso levantado #2
then
	#echo "- Salida: Hay otro proceso levantado\n"
   	exit 0
fi									#x2

# Identifica el archivo a procesar
archProcesar=`ls -tr $DIR_ARCH | grep -f $DIR_PARAM/arch.list | head -1`
#echo "- El archivo a procesar es: $archProcesar\n"

# Checa que el archivo tenga permisos
if [ ! -r $DIR_ARCH/$archProcesar ]	#3
then
	iniREGTIEMPO 
	#echo "El archivo no tiene permiso de lectura\n";
	msg="EL ARCHIVO NO TIENE PERMISO DE LECTURA"
	estatus=41 	# Poner status adecuado
	registraEstatus $archProcesar $estatus "$msg"
        $BITACORA "PROCESO DE CARGA" "ejecutaBCP.sh - $archProcesar" "C" "10041" "$msg"
	exit 0
fi								#x3
#echo "- El archivo tiene permiso de lectura...\n"

# Si no existe REGTIEMPO lo crea
if [ ! -f $DIR_PARAM/REGTIEMPO ]		#5
then
	iniREGTIEMPO 
	#echo "- $DIR_PARAM/REGTIEMPO creado: `date`"
fi							#x5

# Verifica que el archivo a procesar tenga como ultima linea el TRAILER
trailer=`tail -1 $DIR_ARCH/$archProcesar | grep "TRAILER" | cut -c1-7`
if [ "$trailer" = "TRAILER" ]	#4
then

	# Validar que el archivo tenga mas de 2 registros
	registros=`head $DIR_ARCH/$archProcesar | wc -l` 
	#echo "- $registros registros encontrados"
	if [ $registros -lt 2 ]
	then
        	iniREGTIEMPO
        	#echo "- El archivo tiene menos de dos registros\n"
        	msg="EL ARCHIVO TIENE MENOS DE DOS LINEAS FAVOR DE AVISAR AL ENCARGADO."
        	estatus=4
        	registraEstatus $archProcesar $estatus "$msg"
                $BITACORA "PROCESO DE CARGA" "ejecutaBCP.sh-$archProcesar" "C" "10104" "$msg"
        	exit 0
	fi
	#echo "- El archivo tiene mas de 2 registros\n"

	# verifica que haya espacio en disco
	tamano=`ls -l ${DIR_ARCH}/$archProcesar | tr -s ' ' | cut -d' ' -f5`

	espacio=`df -k . | grep "/" | tr -s ' ' | cut -d' ' -f4`
	#espacio=`bdf | grep "/opt/c430/000$" | tr -s ' ' | cut -d' ' -f4`
	espacio=`echo "$espacio * 1024 - 1024" | bc` #le da un margen
	checaEsp=`expr $espacio \<= $tamano`
	
	# Si el espacio en el servidor es insuficiente, termina
	if [ $checaEsp -eq 1 ]              #8
   	then
		#Avisa a SYBASE una sola vez
		c=`isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_PARAM/checaAviso.txt | grep -c "(0"` #Resultado (0 rows affected)
		if [ $c -eq 1 ]
		then
			isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_PARAM/noHayEspacio.txt
		fi
		iniREGTIEMPO
		#echo "- Espacio insuficiente en el servidor\n"
                $BITACORA "PROCESO DE CARGA" "ejecutaBCP.sh" "C" "10105" "Espacio insuficiente en el servidor"
   		exit 0
	fi                                  #x8
	#echo "- El archivo esta completo. Se pasa el control a IntegraArchS111.sh\n"
	#echo "- Se espero a que llegara por completo `head -1 $DIR_PARAM/REGTIEMPO` minutos\n"
	iniREGTIEMPO
	#echo "- Ok en EjecutaBCP: `date`\n"
	$DIR_CARGA/integraArchS111.sh $archProcesar
else
	tiempo=`head -1 $DIR_PARAM/REGTIEMPO`
	tActual=`date '+%Y%j%H%M'`
	
	# Primera vez que se detecta el archivo
	if [ $tiempo -ne 0 ]			#6 corregi tiempo por $tiempo
	then
		tAnterior=`tail -1 $DIR_PARAM/REGTIEMPO`
		tDiff=`$DIR_CARGA/diffTime $tAnterior $tActual`
		if [ $tDiff -lt 0 -o $tDiff -gt 3 ]	#7 corregi tDiff por $tDiff
		then
			iniREGTIEMPO
			#echo "- La fecha UNIX ha cambiado\n"
			isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_PARAM/cambioFechaUnix.txt
			exit 0;
		fi									#x7
		#echo "- $tAnterior:$tActual\n\n- Diferencia: $tDiff\n"

		#Verificar que el archivo no se exceda en tiempo maximo de llegada
		if [ $tiempo -gt $tMaxEspera ] #corregi tiempo y tMaxEspera por $tiempo y $tMaxEspera
		then
			fecha=`date '+%Y%m%d%H%M%S'`
			mv -f $DIR_ARCH/$archProcesar $DIR_ARCH2/EXCEDIOTIEMPO_${archProcesar}_$fecha
			iniREGTIEMPO
			#echo "- El archivo excedio tiempo de llegada\n"
			msg="EL ARCHIVO EXCEDIO TIEMPO MAXIMO DE LLEGADA, FUE MOVIDO A $DIR_ARCH2/EXCEDIOTIEMPO_${archProcesar}_$fecha"
			estatus=42		# Colocar estatus adecuado
			registraEstatus $archProcesar $estatus "$msg"
                        $BITACORA "PROCESO DE CARGA" "ejecutaBCP.sh-$archProcesar" "C" "10042" "$msg"
			exit 0
		fi

		#Verificar que la ultima modificacion del archivo sea reciente
		minUltimaModif=`ls -l $DIR_ARCH |grep $archProcesar |tr -s ' ' |cut -d ' ' -f 8 |cut -c4-5`
		minActual=`date +%M`
		if [ $minUltimaModif -gt $minActual ]	#9
		then
			minActual=`expr $minActual + 60`
		fi										#x9
		tSinModif=`expr $minActual - $minUltimaModif`
		#echo "- Tiempo sin modificar: $tSinModif\n"
		if [ $tSinModif -gt $tMaxSinModif ]		#10
		then
			fecha=`date '+%Y%m%d%H%M%S'`
			mv -f $DIR_ARCH/$archProcesar $DIR_ARCH2/INCOMPLETO_${archProcesar}_$fecha
			iniREGTIEMPO
			#echo "- El archivo llego incompleto"
			msg="EL ARCHIVO LLEGO INCOMPLETO Y FUE MOVIDO A $DIR_ARCH2/INCOMPLETO_${archProcesar}_$fecha"
			estatus=20
			registraEstatus $archProcesar $estatus "$msg"
                        $BITACORA "PROCESO DE CARGA" "ejecutaBCP.sh-$archProcesar" "C" "10020" "$msg"
			exit 0
		fi										#x10
		#echo "- minUltimaModif: $minUltimaModif, minActual: $minActual\n"
	fi							#x6
	tiempo=`expr $tiempo + 1`
	echo $tiempo > $DIR_PARAM/REGTIEMPO
	compruebaErr
	echo "$tActual" >> $DIR_PARAM/REGTIEMPO
	compruebaErr
	#echo "- El archivo aun no llega completo, REGTIEMPO:\n`cat $DIR_PARAM/REGTIEMPO`\n"
fi							#x4


