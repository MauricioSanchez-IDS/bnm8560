# /bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 03 CRO)
# Procedimiento: genera archivo derivado del SBF 
# Descripción: ejecuta los programas para generar  archivo SBF
# Versión y fecha: 1.0   3/01/2002
# Autor:  YMF
#             
# Modificacion :
# Autor y fecha:
PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 03 LOG)/procRepEsp.log
exec 2>&1

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 03 CRO):$(paths.sh 03 BIN)

# Genera variables de ambiente para manejo de las rutas de envio    
DIR_ARCH2=$(paths.sh 03 RES)
DIR_ARCH=$(paths.sh 03 DEP)
DIR_CARGA=$(paths.sh 03 BIN)
DIR_PARAM=$(paths.sh 03 PAR)
DIR_LOGS=$(paths.sh 03 LOG)
DIR_BACK=$(paths.sh 03 RES)
DIR_TEMP=$(paths.sh 03 TMP)

export DIR_ARCH DIR_BACK DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS DIR_TEMP PATH

#Genera variables de ambiente de Sybase
GE_USER=$(usuario.sh)        
GE_PASSWORD=$(password.sh)  
GE_DBASE=$(base.sh)       
GE_SERVER=$(servidor.sh)    
GE_HOSTNAME=I50

export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME 

# Variables de Sybase
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)

export  SYBASE DSQUERY USER

# Se crean las variables para indicar el prefijo, banco, fecha de corte
# si esta en necesaria se pasara como argumento de este programa.

# Se obtiene la fecha del sistema
 ayo=`date +%Y`
 fecha=`date +%Y%m%d`
 fechados=`date +%y%m%d`
 fechalogico=`date +%Y%m%d`
 nombrelogico=$fechalogico
 nombrearch='OS011CDF.F'          
 nomarchcomp=${nombrearch}${fechados}

banderasigue=0

# Valida el numero en el campo estatus, para estatus permitidos # 

#if [ $banderasigue -eq 0 ]
#then
  ## se valida que se hayan recibido los archivos del s111 
  ##numeroarchivos=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_PARAM/checaArchS111.ddl`
  #echo $numeroarchivos
#fi

FECHA_GEN=`date -u +%Y%m%d`
export FECHA_GEN


$DIR_CARGA/repGen $FECHA_GEN 
