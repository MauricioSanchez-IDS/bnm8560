#!/bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: 
# Procedimiento: procRespCDF.sh
# Descripción: procesa la respuesta del archivo CDF que envia Master Card     
# Versión y fecha: 1.0
# Autor: 
#             
# Modificacion :
# Autor y fecha:

PATH=$PATH:/opt/c430/000/bin:.
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 05 LOG)/ejecutaRespCDF.log
exec 2>&1


PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 05 CRO):$(paths.sh 05 BIN)

# Genera variables de ambiente para manejo de las rutas de envio    
DIR_ARCH2=$(paths.sh 05 RES)
DIR_ARCH=$(paths.sh 05 DEP)
DIR_CARGA=$(paths.sh 05 BIN)
DIR_PARAM=$(paths.sh 05 PAR)
DIR_LOGS=$(paths.sh 05 LOG)
DIR_BACK=$(paths.sh 05 RES)
DIR_TEMP=$(paths.sh 05 TMP)

export DIR_ARCH DIR_BACK DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS DIR_TEMP PATH

# Genera variables de ambiente de Sybase
GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=ucadmty1

export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME 

#Variables de Sybase
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)

export SYBASE DSQUERY USER

##### Inicia proceso para validar respuesta de Master Card #####

PATH=$PATH:/opt/c430/000/bin:.
export PATH


file_system="c430"
#Inicia las validaciones del estatus de la tabla MTCPRO02
fecha_proceso=`date '+%y%m%d'`  

terminaPrograma=0
insertaMTCPRO02=0 

nombreLogico=''
nombreFisico=''
fecha=''
estatus=0
estatusUsu=0
mensaje=''
accion=''
nombreLogicoIns=''
nombreFisicoIns=''
fechaIns=''
estatusIns=0
estatusUsuIns=0
mensajeIns=''
accionIns=''

valoraMTC REG3000 2 21 U
