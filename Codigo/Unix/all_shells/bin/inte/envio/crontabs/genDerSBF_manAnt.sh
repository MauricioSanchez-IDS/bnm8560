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
# Autor:  JRGD
#             
# Modificacion :
# Autor y fecha:
# Modificacion -- HP --  26-junio-2012     HRC

PATH=$PATH:/opt/c430/000/bin:/optware/sybase/ase157sp104/OCS-15_0/lib:/optware/sybase/ase157sp104/OCS-15_0/lib/libsybct64.so

export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 03 LOG)/genDerSBF.log
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
 anio=`date +%Y`
 mes=`date +%m`
 pre=$1
 ban=$2
 emp=$3
 mes=$4
 anio=$5
 
 echo "$pre"
 echo "$ban"
 echo "$emp"
 echo "$mes"
 echo "$anio"

# Si desea obtener el reporte de todas las empresas calificadas para este reporte ej: sh genDerSBF.sh 0 0 0 

# Si desea obtener el reporte de todas las empresas de un solo banco y que esten calificadas para este reporte ej: sh genDerSBF.sh 4943 88 0 

# Si desea obtener el reporte de una sola empresa que este calificada para este reporte, capturar el numero de la empresa a procesar ej: sh genDerSBF.sh 4943 88 640 

if [ -n $pre -a -n $ban -a -n $emp ]
then
   # $DIR_CARGA/creaDerSBF $mes $anio $emp SE ANEXARON MAS PARAMETROS 
   $DIR_CARGA/creaDerSBF $pre $ban $emp $mes $anio 
else
   echo 'Debe proporcionar un parametro'
   echo ' ej: si desea todas las empresas calificadas'
   echo 'correr el shell como sigue sh genDerSBF.sh 0 '
   echo 'o ej: si desea una empresa en especifico '
   echo 'correr el shell como sigue sh genDerSBF.sh 4943 88 640(numero de empresa) 12 2002'
   exit 1
fi
