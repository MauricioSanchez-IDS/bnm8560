#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema			: C430LimpCCF.sh
# Directorio		: /opt/c430/000/bin/s702/envio/crontabs
# Descripcion		: Borra todo los residuos de una corrida de un dia    
# Version			: 1.0
# Autor				: MYF
PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 08 CRO)
export PATH


exec 1>>$(paths.sh 08 LOG)/LimpiaTodoCCF.log
exec 2>&1

#Variables de ambiente para las rutas de archivo
DIR_ARCH=$(paths.sh 08 DEP)
DIR_CARGA=$(paths.sh 08 BIN)
DIR_LOGS=$(paths.sh 08 LOG)
DIR_PARAM=$(paths.sh 08 PAR)
DIR_BACK=$(paths.sh 08 RES)
DIR_TEMP=$(paths.sh 08 TMP)
DIR_BIN=$(paths.sh 01 BIN)

export DIR_ARCH DIR_CARGA DIR_LOGS DIR_PARAM DIR_BACK DIR_TEMP DIR_BIN BITACORA ESTATUS


# Variables de ambiente del proceso
GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER 


# Recibe la fecha del dia que desean reprocesar   

rm -f $DIR_TEMP/CCF*D.txt
rm -f $DIR_ARCH/CCF*D.txt
rm -f $DIR_BACK/CCF*D.txt

echo "use M111" > $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete MTCCCF01  ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF0000  ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF1000 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF1001 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF2000 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF2001 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF5000 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF9000 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCFEMP01 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCFUNI01 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCFTHS01 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCFHIS01 ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'drop table MTCTEST ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql

isql -U$GE_USER -S$GE_SERVER -P$GE_PASSWORD -i $DIR_TEMP/limpiaCCF.sql 

