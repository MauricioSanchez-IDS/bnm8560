#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 07 BIN)
# Procedimiento: IntegraArchS111.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:
# Modificaciones: septiembre de 2002
# proposito: Adecuar a directorios estandar
# Autor: YMF 

DIR_ARCH=$(paths.sh 07 DEP)
DIR_ARCH2=$(paths.sh 07 RES)
DIR_PARAM=$(paths.sh 07 PAR)
DIR_BIN=$(paths.sh 01 BIN)
BITACORA=$DIR_BIN/bitacoraITO.sh

set -x


primero=`echo "$1" | cut -c1`
id=`echo "$1" | cut -c2-4`
fecha2=`date '+%Y%m%d%H%M%S'`
fechaSQL=`date '+%Y/%m/%d %H:%M:%S'`

msg="" #variables para determinar el estatus de la carga
#estatus=30 # El valor 30 es para cuando el archivo se tarda mucho en transmitir

# Actualiza mensajes en el servidor
# La siguiente instruccion actualiza un error de problemas de espacio
#que se grabo con estatus=2 en el proceso ejecutaBCP.sh
#cuando logro pasar al proceso integraArchS111.sh es porque ya resolvieron
#el problema con espacio, por lo que le pone estatus=3 en lugar
#de 2 para que el cliente ya no reporte el problema de espacio y
#solo tome los demas registro de carga correcta
isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_PARAM/cambiaEstatus.txt

# checaArchivo
# mueve archivo y cargalo

#####################

header=`head -1 $DIR_ARCH/$1  | grep "HEADER"  | cut -c1-6  `
fecha=`head -1 $DIR_ARCH/$1   | grep "HEADER"  | cut -c7-14  `
nombre=`head -1 $DIR_ARCH/$1  | grep "HEADER"  | cut -c15-25  `
lonreg=`head -1 $DIR_ARCH/$1  | grep "HEADER"  | cut -c26-29  `
ini=`head -1 $DIR_ARCH/$1     | grep "HEADER"  | cut -c30-33  `
fin=`head -1 $DIR_ARCH/$1     | grep "HEADER"  | cut -c34-37  `

#echo "- ${primero}${id}\n"

lonregBASE=`cat $DIR_PARAM/arch.config  | grep "${primero}${id}" | cut -d: -f2 `
iniBASE=`cat $DIR_PARAM/arch.config     | grep "${primero}${id}" | cut -d: -f3 `
finBASE=`cat $DIR_PARAM/arch.config     | grep "${primero}${id}" | cut -d: -f4 `

trailer=`tail -1 $DIR_ARCH/$1  | grep "TRAILER" | cut -c1-7 `
total=`tail -1 $DIR_ARCH/$1    | grep "TRAILER" | cut -c8-19 `
suma=`tail -1 $DIR_ARCH/$1     | grep "TRAILER" | cut -c20-36 `

#echo "header $header fecha $fecha nombre $nombre long $lonreg ini $ini fin $fin"
#echo "trailer $trailer total $total suma $suma"


if [ "$header" = "HEADER" ]			#2
then
	#echo "- Primeros 6 caracteres de header correctos\n"
	if [ $lonreg -ne $lonregBASE ]	#3
	then
		#echo "- Campo incorrecto en header: longitud\n"
    	msg="CAMPO INCORRECTO  EN HEADER (LONGITUD DE REGISTRO)."
    	estatus=08
  	    echo "$1:$fecha:$estatus:$msg" >> $DIR_LOGS/integraArchS111.log
  	fi								#x3
	if [ $ini -ne $iniBASE ]		#4
  	then	
		#echo "- Campo incorrecto en header: pos inicial\n"
    	msg="CAMPO INCORRECTO EN HEADER (POSICION INICIAL DE CAMPO A SUMAR)."
    	estatus=09
  	    echo "$1:$fecha:$estatus:$msg" >> $DIR_LOGS/integraArchS111.log
  	fi								#x4
	if [ $fin -ne $finBASE ]		#5
  	then
		#echo "- Campo incorrecto en header: final del campo a sumar\n"
    	msg="CAMPO INCORRECTO EN HEADER (FINAL DEL CAMPO A SUMAR)."
    	estatus=10
  	    echo "$1:$fecha:$estatus:$msg" >> $DIR_LOGS/integraArchS111.log
  	fi								#x5

  	totalRegistros=`wc -l < ${DIR_ARCH}/$1 `
  	checaRegistros=`expr $totalRegistros \= $total`

  	if [  $checaRegistros -eq 1  ]	#6
  	then
		#echo "- Numero de registros correcto\n"
    	lonreg=`expr $lonreg - 1`
    	comando=`echo "length < ${lonreg}" > ${DIR_LOGS}/checaArch.cmd `
    	lineasIncompletas=`awk -f ${DIR_LOGS}/checaArch.cmd ${DIR_ARCH}/$1 | wc -l `
    	if [ $lineasIncompletas -eq 0 ]	#7
    	then
			#echo "- lineas completas\n"
            msg="EL ARCHIVO COMPLETO ESTA CORRECTO."
            estatus=0
  	    	echo "$1:$fecha:$estatus:$msg" >> $DIR_LOGS/integraArchS111.log
    	else
			#echo "- registros incompletos\n"
      		msg="TIENE $lineasIncompletas REGISTROS INCOMPLETOS."
      		estatus=13
  	        echo "$1:$fecha:$estatus:$msg" >> $DIR_LOGS/integraArchS111.log
    	fi							#x7
  	else
		#echo "- Incompleto\n"
   		msg="INCOMPLETO, TIENE $totalRegistros Y DEBE TENER $total REGISTROS."
   		estatus=14
  	    echo "$1:$fecha:$estatus:$msg" >> $DIR_LOGS/integraArchS111.log
  	fi								#x6
else
	#echo "- incorrecto no tiene header\n"
	msg="ESTA INCORRECTO, NO TIENE HEADER."
	estatus=15
  	echo "$1:$fecha:$estatus:$msg" >> $DIR_LOGS/integraArchS111.log
fi									#x2

#####################

if [ $estatus -eq 0 ]				#9
then
	#echo "- Carga correcta\n"
  	#la carga es correcta
  	head -1 $DIR_ARCH/$1 > $DIR_ARCH2/$1_HEADER
  	tail -1 $DIR_ARCH/$1 > $DIR_ARCH2/$1_TRAILER
  	sed '1 d' $DIR_ARCH/$1 | sed '$ d' > $DIR_ARCH2/$1

  	rm -f $DIR_ARCH/$1
  	#echo "$1:$fecha:$estatus:$msg" >> $DIR_LOGS/integraArchS111.log
	#echo "- OK: $1\n"
        $DIR_CARGA/integra_${id}.sh $1
else    
        $BITACORA "PROCESO DE CARGA" "integraArchS111.sh $1" "C" "100$estatus" "$msg"
	#echo "- escribe en MTCPRO01"
  	echo "insert MTCPRO01                       " > $DIR_TEMP/insertMTCPRO01.txt
  	echo "values('$1','$fechaSQL',$estatus,'$msg') " >> $DIR_TEMP/insertMTCPRO01.txt
  	echo "go                                    " >> $DIR_TEMP/insertMTCPRO01.txt
  	mv -f $DIR_ARCH/$1 $DIR_ARCH2/${1}_${fecha2}
	#echo "- archivo movido"
  	checaTabla=`isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_TEMP/insertMTCPRO01.txt`
  	if [ "$checaTabla" != "(1 row affected)" ]		#12
  	then
   		errores="ERROR: NO SE PUEDE ACTUALIZAR LA TABLA MTCPRO01."
   		echo "$1:$fecha2:$errores" >> $DIR_LOGS/integraArchS111.log
  	fi						#x12
fi								#x9
