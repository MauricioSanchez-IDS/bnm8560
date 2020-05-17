#!/bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema		: Reportes
# Descripcion	: Preparar las variables de ambiente para la generacion de reportes
# Fecha			: 25 de enero del 2008
# Version		: 1.0
# Autor			: Angel Perez Quintanar
# Modificacion -- HP --  26-junio-2012    HRC
#set -x
#LANG=en_US
PATH=$PATH:/opt/c430/000/bin:/optware/sybase/ase157sp104/OCS-15_0/lib:/optware/sybase/ase157sp104/OCS-15_0/lib/libsybct64.so

SYBASE_OCS=OCS-15_0
export SYBASE_OCS

if [ "${10}" = "C" ]
then
 exec 1>>$(paths.sh 03 LOG)/GeneraRepsCredito.log
 exec 2>&1
else
 if [ "${10}" = "D" ]                              
 then                                               
  exec 1>>$(paths.sh 03 LOG)/GeneraRepsDebito.log
  exec 2>&1                                       
 fi
fi

TUXDIR=$tuxedo.sh; export TUXDIR
HOSTNAME=$hostname; export HOSTNAME
APPDIR=$appdir.sh; export APPDIR
DIRTC617=$dirtc617.sh
DIRTC430=$dirtc430.sh
TUXCONFIG=$DIRTC617/bin/tuxconfig-${HOSTNAME}-D1
BDMCONFIG=$DIRTC617/bin/bdmconfig-${HOSTNAME}-D1
export TUXCONFIG BDMCONFIG
FLDTBLDIR32=$fldtbldir32.sh
FIELDTBLS32=$fieldtbls32.sh
export FLDTBLDIR32 FIELDTBLS32

PATH=$PATH:$sybase.sh/OCS-15_0/bin:$(paths.sh 03 CRO):$(paths.sh 03 BIN):$TUXDIR/bin
export PATH

################################################################
#	P r o d u c c i o n
################################################################
# Variables de ambiente para las rutas de archivo
DIR_ARCH=$(paths.sh 03 DEP)
DIR_ARCH2=$(paths.sh 03 RES)
DIR_CARGA=$(paths.sh 03 BIN)
DIR_PARAM=$(paths.sh 03 PAR)
DIR_LOGS=$(paths.sh 03 LOG)
DIR_BACK=$(paths.sh 03 RES)
DIR_TEMP=$(paths.sh 03 TMP)
export DIR_ARCH DIR_ARCH2 DIR_CARGA DIR_PARAM DIR_LOGS DIR_BACK DIR_TEMP

# Variables de ambiente de Sybase
GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=hyper
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME

# Variables de ambiente de Sybase
SYBASE=$(sybase.sh)
#DSQUERY=$(servidor.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)
export SYBASE DSQUERY USER

SHLIB_PATH=/usr/lib:/usr/lib/Motif1.2:$TUXDIR:$TUXDIR/bin:$TUXDIR/include:$TUXDIR/lib:${SYBASE}/OCS-15_0/lib
export SHLIB_PATH


################################################################
# Variables de ambiente para los rangos de fecha
################################################################
DIA_CORTE=$1
TIPO_EJEC=$2
FECHA_INI=$3
FECHA_FIN=$4
FECHA_ACT=$5
EMPRESA_I=$6
EMPRESA_F=$7
REPORTE_I=$8
REPORTE_F=$9 
TIPO_PROD=${10}
B_TOTALES="0"

if  [[ -z DIA_CORTE ]]
then
        echo "Error en parametro DIA_CORTE primer parametro"
fi
if  [[ -z TIPO_EJE ]]
then
        echo "Error en parametro TIPO_EJEC segundo parametro"   
fi
if  [[ -z FECHA_INI ]]
then
        echo "Error en parametro FECHA_INI tercer parametro"
fi
if  [[ -z FECHA_FIN ]]
then
        echo "Error en parametro FECHA_FIN cuarto parametro"
fi
if  [[ -z FECHA_ACT ]]
then
        echo "Error en parametro FECHA_ACT quinto parametro"
fi
if  [[ -z TIPO_PROD ]]                                        
then                                                          
        echo "Error en parametro TIPO_PROD quinto parametro"  
fi                                                            

echo "Parametros:"
echo "DIA_CORTE=$DIA_CORTE"
echo "TIPO_EJEC=$TIPO_EJEC"
echo "FECHA_INI=$FECHA_INI"
echo "FECHA_FIN=$FECHA_FIN"
echo "FECHA_ACT=$FECHA_ACT"
echo "EMPRESA_I=$EMPRESA_I"
echo "EMPRESA_F=$EMPRESA_F"
echo "REPORTE_I=$REPORTE_I"
echo "REPORTE_F=$REPORTE_F"
echo "TIPO_PROD=$TIPO_PROD"

export DIA_CORTE TIPO_EJEC TIPO_PROD FECHA_INI FECHA_FIN FECHA_ACT
export EMPRESA_I EMPRESA_F REPORTE_I REPORTE_F B_TOTALES

echo "entrara en el proceso ejecutable"

# Ejecuta el proceso
/opt/c430/000/bin/inte/envio/bin/C430Reps
