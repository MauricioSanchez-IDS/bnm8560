#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema       : C430
# Directorio	: /opt/c430/ibm/recepcion/crontabs
# Descripcion   : Preparar las variables de ambiente para crear el archivo ALFA
# Version       : 2.0
# Autor         : Ing. Ivan Troy Santaella Martinez

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 02 CRO)
export PATH

#_HP_Changes for Linux Migration -Start
#Change in Sybase path
#export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:/opt/sybase15/OCS-15_0/lib
export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:/optware/sybase/ase157sp104/OCS-15_0/lib
#_HP_Changes for Linux Migration -End

exec 1>>$(paths.sh 02 LOG)/generaALFA.log
exec 2>&1

#set -x
#locale

# Variables de ambiente para las rutas de archivo
DIR_ARCH=$(paths.sh 02 DEP)
DIR_CARGA=$(paths.sh 02 BIN)
DIR_HOME=$(paths.sh 02 CRO)
DIR_LOGS=$(paths.sh 02 LOG)
DIR_PARAM=$(paths.sh 02 PAR)
DIR_BACK=$(paths.sh 02 RES)
DIR_TEMP=$(paths.sh 02 TMP)
export DIR_ARCH DIR_CARGA DIR_LOGS DIR_PARAM DIR_BACK DIR_TEMP DIR_HOME

# Variables de ambiente para los nombres de archivo
NOM_ARCH_R1=regtipo1.dat
NOM_ARCH_R3=regtipo3.dat
NOM_ARCH_R4=regtipo4.dat
NOM_ARCH_ALFA=C430-ALFA.DAT
NOM_ARCH_LOG=C430-ALFA.LOG
TIPO_ARCH=$1
export NOM_ARCH_R1 NOM_ARCH_R3 NOM_ARCH_R4
export NOM_ARCH_ALFA NOM_ARCH_LOG TIPO_ARCH

if [[ -z $1 ]]
then
	echo "\nUso: $0 CARGA|DIARIO\n"
	exit
fi

# Variables de ambiente del proceso
GE_USER=$(usuario.sh)
GE_PASSWORD=ojE83CEb
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=ux
GE_APPNAME=alfa
#GE_HOSTNAME=vm-2d9b-6102
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME GE_APPNAME

# Variables de ambiente de Sybase
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export SYBASE DSQUERY 


# Variables de ambiente para los rangos de fecha
DIA=`date '+%d' | sed 's/^0//g'`
NUMERO=`date '+%u'`

DIA_MES=`date '+%m%d'`
FESTIVO=`grep ^$DIA_MES$ dias_festivos.txt | wc -l`

if [ $FESTIVO -eq 1 ]
then
	echo "DIA FESTIVO"
	exit
fi

if [ $NUMERO -eq 6 ]
then
	echo "SABADO"
	exit
fi

if [ $NUMERO -eq 7 ]
then
	echo "DOMINGO"
	exit
fi

if [ $NUMERO -eq 1 ]
then
	echo "LUNES"

DIA_ANT=`expr "$DIA_MES" - 3`
FESTIVO=`grep ^$DIA_ANT$ dias_festivos.txt | wc -l`

	if [ $FESTIVO -eq 1 ]
	then

echo "select f='|'+convert(char(8),dateadd(day,-4,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_INI=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`
echo "select f='|'+convert(char(8),dateadd(day,-1,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_FIN=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`

	else

echo "select f='|'+convert(char(8),dateadd(day,-3,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_INI=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`
echo "select f='|'+convert(char(8),dateadd(day,-1,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_FIN=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`

	fi

else

	if [ $NUMERO -eq 2 ]
	then
		echo "MARTES"

DIA_ANT=`expr "$DIA_MES" - 1`
FESTIVO=`grep ^$DIA_ANT$ dias_festivos.txt | wc -l`

		if [ $FESTIVO -eq 1 ]
		then

echo "select f='|'+convert(char(8),dateadd(day,-4,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_INI=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`
echo "select f='|'+convert(char(8),dateadd(day,-1,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_FIN=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`

		else

echo "select f='|'+convert(char(8),dateadd(day,-1,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_INI=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`
echo "select f='|'+convert(char(8),dateadd(day,-1,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_FIN=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`
		fi

	else
		echo "MIERCOLES-VIERNES"

DIA_ANT=`expr "$DIA_MES" - 1`
FESTIVO=`grep ^$DIA_ANT$ dias_festivos.txt | wc -l`

		if [ $FESTIVO -eq 1 ]
		then

echo "select f='|'+convert(char(8),dateadd(day,-2,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_INI=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`
echo "select f='|'+convert(char(8),dateadd(day,-1,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_FIN=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`

		else

echo "select f='|'+convert(char(8),dateadd(day,-1,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_INI=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`
echo "select f='|'+convert(char(8),dateadd(day,-1,getdate()),112)+'|'" > a.sql
echo "go" >> a.sql
FECHA_FIN=`isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i a.sql | grep "|" | cut -f2 -d'|'`

		fi
	fi
fi

FECHA_ACTUAL=`date '+%Y%m%d'`

###################
#FECHA_INI=20070412
#FECHA_FIN=20070414
###################

echo "\nPROCESO 1"
echo "FECHA_ACTUAL=$FECHA_ACTUAL"
echo "FECHA_INI=$FECHA_INI"
echo "FECHA_FIN=$FECHA_FIN"
echo "TIPO_ARCH=$TIPO_ARCH"

export FECHA_ACTUAL FECHA_INI FECHA_FIN

# Ejecuta el proceso
$DIR_CARGA/creaALFA

cp ${DIR_HOME}/${NOM_ARCH_ALFA} ${DIR_ARCH}

# Envia el archivo 1
echo "Enviando archivo hacia ALFA"

##DIR_ICEP=/opt/c617/402/icep/bin                                      
##export DIR_ICEP

#$DIR_ICEP/icep.sh intelarintmx1 gunix xunix send mb $NOM_ARCH_ALFA C430_000.CITSGRAL.OS254100.TARJETA    #Produccion
cd /opt/c430/000/bin/ibm/envio/crontabs/ssh_intelar
./ssh_intelar.sh  c254s03e  put $DIR_ARCH/$NOM_ARCH_ALFA c254_000.orac254!filesbmx!ap!tarjeta 

rslt=$?                                                                         
if (test $rslt -eq 0)  then                                                     
   echo "Se envio el archivo CITSGRAL.OS254100.TARJETA"
else                                                                            
   echo "Error : $rslt  en el envio del archivo CITSGRAL.OS254100.TARJETA"
fi                                                                              

#/usr/bin/ftp -i -n <<EOF
#open 10.221.21.1
#user SFZPFTP SFZPFTP1
#site lrecl=180
#lcd $DIR_ARCH
#put $NOM_ARCH_ALFA 'CITSGRAL.OS254100.TARJETA'
#prompt
#close
#bye
#EOF
