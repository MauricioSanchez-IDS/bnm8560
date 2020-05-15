#!/usr/bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: $(paths.sh 04 CRO)
# Procedimiento: preparaRepCDF.sh
# Descripción:Borra el contenido de las tablas REG para que el proceso empiece de cero 
# Versión y fecha: 2.0   21/jul/2003
# Autor:  
#             

PATH=$PATH:/opt/c430/000/bin:
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS


PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 04 CRO):$(paths.sh 04 BIN)
export PATH

# Genera variables de ambiente para manejo de las rutas de envio en produccion
DIR_ARCH2=$(paths.sh 04 RES)
DIR_ARCH=$(paths.sh 04 DEP)
DIR_CARGA=$(paths.sh 04 BIN)
DIR_PARAM=$(paths.sh 04 PAR)
DIR_LOGS=$(paths.sh 04 LOG)
DIR_BACK=$(paths.sh 04 RES)
DIR_TEMP=$(paths.sh 04 TMP)

export DIR_ARCH DIR_BACK DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS DIR_TEMP PATH

#Genera variables de ambiente de Sybase
GE_USER=$(usuario.sh)        
GE_PASSWORD=$(password.sh)  
GE_DBASE=$(base.sh)       
GE_SERVER=$(servidor.sh)     
GE_HOSTNAME=`uname -a`

export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME 

# Variables de Sybase produccion
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)

export  SYBASE DSQUERY USER
exec 1>>$(paths.sh 04 LOG)/preparaReproCDF.log   
exec 2>&1                                  

# Borra las tablas REG1000, REG4000, REG4100, REG4200,
# REG4300, REG5000, REG9999
echo "use M111" > $DIR_TEMP/preparaReproCDF.txt    
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG1000" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG3000" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG4000" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG4100" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG4200" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG4300" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG5000" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG9999" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete REG1100" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
echo "delete MTCPRO02" >> $DIR_TEMP/preparaReproCDF.txt
echo "where pro_nomLogi='$1'" >> $DIR_TEMP/preparaReproCDF.txt
echo "go" >> $DIR_TEMP/preparaReproCDF.txt
more $DIR_TEMP/preparaReproCDF.txt
isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -i $DIR_TEMP/preparaReproCDF.txt
if [ $? -gt 0 ] 
then
 echo "Existio un error al intentar borrar las tablas REG del CDF"
fi

