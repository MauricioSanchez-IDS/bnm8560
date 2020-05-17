#!/usr/bin/ksh
## SHELL PARA ENVIOS A INTELAR POR SSH
## El presente shell efectua el envio de un archivo o recepcion de un archivo y
## asi como el contenido de un buzon de intelar. Para ello puede recibir los
## comandos put(PUT), get(GET) y list(LIST), respectivamente.
## AUTHOR: GONZALEZ GARCIA NOE     GOGN
## Modifico: Gerardo Uriel Gamez Torres
## Fecha: 20/Oct/2011
##
## Modificaciones:
## 1.- Se incluye registro de las diferentes actividades del shell a archivo.
## 2.- Adicion de algoritmo de depurado del log, a un tamaño fijo establecido.
## 3.- Documentacion de codigo.
## 4.- Control de la salida y error estandares.
## 5.- Personalizacion de mensajes de salida segun la actividad realizada.
## 6.- Se activa el reintento de conexion a servidor alterno.
##

###############################################################################
##  Parametros de entrada:
##	Este shell recibe cuatro parametros que se especifican a continuación.
# $1: Buzon destino a donde se enviara o de donde se recibira.
# $2: Comando, especifica el tipo de actividad a realizar put, get y list.
# $3: Archivo que sera enviado/recibido.
# $4: Nombre del archivo a enviar/recibir.
##    Este parametro en caso del comando list será el nombre del archivo que 
##    contendra el contenido del buzon.
##############################################################################

#   ############################################################################
#         Definicion de variables 
#   ############################################################################
CONFIL=$PWD/conf/ini.conf			#Archivo de configuracion
FECHA=`date +%Y/%m/%d`				#Fecha del proceso
HORA=`date +%I:%M:%S`				#Hora del proceso
FORMATOINI="ssh_intelar"			#Formato inicial para el log
TMP=$PWD/temp.txt				#Archivo temporal 1
TMP1=$PWD/temp2.txt				#Archivo temporal 2
ErrStd=$PWD/errstd.txt				#Archivo para error estandar
SalStd=$PWD/salstd.txt				#Archivo para salida estandar
LogIntelar=$PWD/ssh_intelar.log 		#Archivo para el log
FOUND=0						#Bandera para determinacion de intento
NUM_REG=0					#Numero de registro del archivo de configuracion
USER=c4300008					#Usuario de acceso
DEST=intelar					#Bandera para determinacion de intento
BUZON=/$1					#Buzon destino/origen, 1er parametro del shell
COMANDO=`echo $2|awk '{ print tolower($1)}'`
						#Comando a ejecutar put, get o list
						#Puede recibir Mayuscula o minusculas
						#2o parametro del shell
FILE=$3						#Archivo a transferir/recibir
						#3er parametro del shell
FILEDES=$4					#Nombre con que se transferira/recibira
						#En list nombre del archivo de salida
retc=0						#Contiene valor de regreso de las ejecuciones
TAMMAXIMOLOG=25000				#Maximo de registros permitidos en el log.

						#Los siguientes parametros se toman del archivo 
						#de configuracion (ver CONFIL)
ORI=						#Origen para control de intentos
IP=						#IP o alias del servidor destino primario
IPORIG=						#Idem a la anterior se usa para mensaje
IP2="vacio"					#IP o alias del servidor destino alterno
PTO=						#Puerto de conexion al CE

echo "-----------------------------------------------------------------------">>$LogIntelar
echo "$FORMATOINI $FECHA $HORA INICIA PROCESO">>$LogIntelar
echo "$FORMATOINI Transferencias de archivos">>$LogIntelar

#   ############################################################################
#         Validación de parametros de entrada
#   ############################################################################
if [ $# != 4 ]; then		#****** VALIDA PARAMETROS DE ENTRADA **********
	echo "$FORMATOINI [ERROR]Parametros recibidos $#">>$LogIntelar
	echo "$FORMATOINI [ERROR]Numero incorrecto de argumentos">>$LogIntelar
	echo "$FORMATOINI USO:">>$LogIntelar
	echo "$FORMATOINI ssh_intelar.sh <buzon> <comando> <arch_orig> <arch_dest>">>$LogIntelar
	echo "$FORMATOINI $FECHA $HORA PROCESO TERMINADO">>$LogIntelar
	echo "-----------------------------------------------------------------------">>$LogIntelar
	rm -f $TMP $TMP1 $SalStd $ErrStd >/dev/null 2>&1
	exit -1
fi

echo "$FORMATOINI Se procesa comando : $COMANDO">>$LogIntelar
echo "$FORMATOINI Medio              : SFTP">>$LogIntelar
echo "$FORMATOINI Usuario            : $USER">>$LogIntelar

#   ############################################################################
#	ASIGNA PARAMETROS DE EJECUCION
#   ############################################################################

if [ $COMANDO != "list" ]; then
	if [ $COMANDO = "get" ]; then
		MODO="recibe          "
		FUENTE="origen       "
	elif [ $COMANDO = "put" ]; then
		MODO="transfiere      "
		FUENTE="destino      "
	else
		echo "$FORMATOINI [ERROR] Comando ($COMANDO) desconocido ">>$LogIntelar
		echo "$FORMATOINI $FECHA $HORA PROCESO TERMINADO">>$LogIntelar
		echo "-----------------------------------------------------------------------">>$LogIntelar
		rm -f $TMP $TMP1 $SalStd $ErrStd >/dev/null 2>&1
		exit -1
	fi
	echo "$FORMATOINI Se $MODO: $FILE">>$LogIntelar
	echo "$FORMATOINI Con el nombre      : $FILEDES">>$LogIntelar
	echo "$FORMATOINI Buzon $FUENTE: $BUZON">>$LogIntelar
fi

if [ ! -r $CONFIL ]; then			#****** VALIDA ARCHIVO INI.CONF **********
	echo "$FORMATOINI [ERROR] No existe el archivo de configuración.">>$LogIntelar
	echo "$FORMATOINI $FECHA $HORA PROCESO TERMINADO">>$LogIntelar
	echo "-----------------------------------------------------------------------">>$LogIntelar
	rm -f $TMP $TMP1 $SalStd $ErrStd >/dev/null 2>&1
	exit -1
fi

#   ############################################################################
#	RECUPERA PARAMETROS DE ARCHIVO INI.CONF
#   ############################################################################

for registro in `cat "$CONFIL"`
  do
	new_reg=`echo "$registro" | awk 'BEGIN {FS=",[ \t]*|[ \t]+"} {print $1,$2,$3,$4}'`
	NUM_REG=`expr $NUM_REG + 1`

	ORI=`echo "$new_reg" | awk '{print $1}'`
	IP=`echo "$new_reg" | awk '{print $2}'`	
	PTO=`echo "$new_reg" | awk '{print $3}'`
	COMMENT=`echo "$new_reg" | awk '{print $4}'`

	field1=`echo "$ORI" | awk '{print substr($1,1,1)}'`
	field2=`echo "$IP" | awk '{print substr($1,1,1)}'`
	field3=`echo "$PTO" | awk '{print substr($1,1,1)}'`
	field4=`echo "$COMMENT" | awk '{print substr($1,1,1)}'`

	if [ $DEST = $ORI ]; then
		FOUND=1
		if (test "$field2" = "#") then
			echo "$FORMATOINI [ERROR] Valor de IP comentado, registro $NUM_REG">>$LogIntelar
			echo "$FORMATOINI $FECHA $HORA PROCESO TERMINADO">>$LogIntelar
			echo "-----------------------------------------------------------------------">>$LogIntelar
			rm -f $TMP $TMP1 $SalStd $ErrStd >/dev/null 2>&1
			exit -1
		fi
		IPORIG=$IP
	else
		IP2=`echo "$new_reg" | awk '{print $2}'`
	fi
done

echo "$FORMATOINI Host $FUENTE : $IPORIG">>$LogIntelar

if [ $FOUND -eq 0 ]; then
	echo "$FORMATOINI [ERROR] Destino NO encontrado, se termina proceso.">>$LogIntelar
	echo "$FORMATOINI Verifique Archivo de Configuracion $CONFIL ">>$LogIntelar
	echo "$FORMATOINI $FECHA $HORA PROCESO TERMINADO">>$LogIntelar
	echo "-----------------------------------------------------------------------">>$LogIntelar
	rm -f $TMP $TMP1 $SalStd $ErrStd >/dev/null 2>&1
	exit -1
fi

#   ############################################################################
#	VALIDA COMANDO Y ASIGNA PARAMETROS DE ENVIO
#   ############################################################################

echo "cd $BUZON" > $TMP
if [ $COMANDO = "put" ]; then
		echo "sput $FILE $FILEDES" >> $TMP	#Asigna comando de Envio
		TIPOOPER="Uploading"
elif [ $COMANDO = "get" ]; then
		echo "sget $FILE $FILEDES" >> $TMP	#Asigna comando de Recepcion
		TIPOOPER="Fetching"
elif [ $COMANDO = "list" ]; then
		echo "dir" >> $TMP
else
	echo "$FORMATOINI [ERROR] Comando ($COMANDO) desconocido, en valida">>$LogIntelar
	echo "$FORMATOINI $FECHA $HORA PROCESO TERMINADO">>$LogIntelar
	echo "-----------------------------------------------------------------------">>$LogIntelar
	rm -f $TMP $TMP1 $SalStd $ErrStd >/dev/null 2>&1
	exit -1
fi
echo "quit" >> $TMP

#   ############################################################################
#	EJECUTA SFTP CON COMANDO ASIGNADO
#   ############################################################################

if [ $COMANDO = "list" ]; then
	#sftp -P10022 -B$TMP $USER@$IPORIG >$FILEDES 2>$ErrStd
	sftp -P$PTO -B$TMP $USER@$IPORIG >$FILEDES 2>$ErrStd
	retc=$?
	if [ $retc -eq 0 ]; then
		echo $FORMATOINI Contenido del buzon: $BUZON>>$LogIntelar
		cat "$FILEDES" |grep -v sftp>>$LogIntelar
	else
		cat $FILEDES > $SalStd
	fi
else
	#sftp -P10022 -B$TMP $USER@$IPORIG >$SalStd 2>$ErrStd
	sftp -P$PTO -B$TMP $USER@$IPORIG >$SalStd 2>$ErrStd
	retc=$?
fi

if [ $retc -ne 0 ]; then
	echo "$FORMATOINI [ERROR] Codigo de retorno [$retc]:">>$LogIntelar
	echo "$FORMATOINI Se hace reintento">>$LogIntelar
	cat $SalStd>>$LogIntelar
	cat $ErrStd|grep -v "Banamex">>$LogIntelar
fi

#   ############################################################################
#	REINTENTA TOMANDO EL SERVIDOR ALTERNO
#   ############################################################################

if [ $retc -ne 0 ]; then
    if [ $IP2 = "vacio" ]; then
	echo "$FORMATOINI No hay servidor alterno">>$LogIntelar
        continue
    else
	echo "$FORMATOINI Reintento          : de $IPORIG a $IP2">>$LogIntelar
        if [ $COMANDO = "list" ]; then
            #sftp -P10022 -B$TMP $USER@$IPORIG >$FILEDES 2>$ErrStd
	    sftp -P$PTO -B$TMP $USER@$IPORIG >$FILEDES 2>$ErrStd
            retc=$?
			if [ $retc -eq 0 ]; then
				echo $FORMATOINI Contenido del buzon: $BUZON>>$LogIntelar
				cat $FILEDES |grep -v sftp>>$LogIntelar 
			else
				cat $FILEDES > $SalStd
			fi
        else
            #sftp -P10022 -B$TMP $USER@$IPORIG >$SalStd 2>$ErrStd
	    sftp -P$PTO -B$TMP $USER@$IPORIG >$SalStd 2>$ErrStd
            retc=$?
        fi
     fi
fi

#   ############################################################################
#	DESPLIEGA ESTADO FINAL
#   ############################################################################

if [ $retc -ne 0 ]; then
	if [ $retc -eq 1 ]; then
		echo "$FORMATOINI [ERROR][$retc] Comando desconocido">>$LogIntelar
	else
		if [ $retc -eq 2 ]; then
			echo "$FORMATOINI [ERROR][$retc] No existe eldirectorio o no se tienen permisos">>$LogIntelar
		else
			if [ $retc -eq 4 ]; then
				echo "$FORMATOINI [ERROR][$retc] Error en conexión - no existe servidor o puerto incorrecto o usuario incorrecto">>$LogIntelar
			else
				if [ $retc -eq 6 ]; then
					echo "$FORMATOINI [ERROR][$retc] Archivo no encontrado">>$LogIntelar
				else
					echo "$FORMATOINI [ERROR][$retc] Error desconocido">>$LogIntelar
				fi
			fi
		fi
	fi
	cat $SalStd>>$LogIntelar
	cat $ErrStd|grep -v "Banamex">>$LogIntelar
else
	if [ $COMANDO != list ]; then
		#grep $TIPOOPER $SalStd>>$LogIntelar
		#if [ $? = 0 ]; then
			#echo "$FORMATOINI Transferencia exitosa" >>$LogIntelar
		#fi

		echo "$FORMATOINI Transferencia exitosa" >>$LogIntelar
	fi
fi
echo "$FORMATOINI $FECHA $HORA PROCESO TERMINADO">>$LogIntelar
echo "-----------------------------------------------------------------------">>$LogIntelar

#   ############################################################################
#	DEPURA LOG
#   ############################################################################

TAMACTUAL=`wc -l $LogIntelar | cut -f1 -d" "`

if [ $TAMACTUAL -gt $TAMMAXIMOLOG ]; then
	tail -$TAMMAXIMOLOG $LogIntelar >tempU
	mv -f tempU $LogIntelar
fi

#   ############################################################################
#	DEPURA ARCHIVOS TEMPORALES
#   ############################################################################

rm -f $TMP $TMP1 $SalStd $ErrStd >/dev/null 2>&1

#   ############################################################################
#	DEVUELVE CODIGO DE ERROR COMO RETORNO 
#   ############################################################################
exit $retc
