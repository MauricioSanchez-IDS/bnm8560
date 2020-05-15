#!/bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema			: INTELAR
# Descripcion		: Preparar las variables de ambiente y parametros del
#                     proceso de envio de reportes a intelar.
# Version			: 1.0
# Autor				: Ing. Ivan Troy Santaella Martinez
# Modificacion  -- HP --   26-junio-2012    HRC

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 03 LOG)/intelar.log
exec 2>&1

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 03 CRO):$(paths.sh 03 BIN)
export PATH

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
#GE_SERVER=$(servidor.sh)
#GE_HOSTNAME=tarjcorp
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=I50
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME

# Variables de ambiente de Sybase
SYBASE=$(sybase.sh)
#DSQUERY=$(servidor.sh)
DSQUERY=$(servidor.sh)
export SYBASE DSQUERY 

# Configuracion de las diferentes modos de ejecucion
#	  
#	* Automatico
#	
#	REENVIO=FALSE
#	VAL_ESTATUS=FALSE
#	
#	* Reenvio total
#	
#	REENVIO=TRUE
#	VAL_ESTATUS=FALSE
#	
#	* Reenvio con validacion de estatus
#	
#	REENVIO=TRUE
#	VAL_ESTATUS=TRUE
#	ESTATUS=2

# Variables de ambiente de Sybase
REENVIO=FALSE
#REENVIO=TRUE
FECHA=`date "+%Y%m%d"`
#VAL_ESTATUS=FALSE
VAL_ESTATUS=FALSE
ESTATUS=2
ARCH_EXT=.TXT
export REENVIO FECHA ESTATUS VAL_ESTATUS ARCH_EXT

# Ejecuta el proceso
$DIR_CARGA/intelarD 1
