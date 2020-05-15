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

case $# in
   1) ;;   # No. de Parametros Correcto. 
   *) print "Le faltan parametros Use: C430LimpCCF.sh <mmdd>  "
      exit 1 ;;                                                                 
esac

exec 1>>$(paths.sh 08 LOG)/LimpiaCCF.log
exec 2>&1

#Variables de ambiente para las rutas de archivo
DIR_ARCH=$(paths.sh 08 DEP)
DIR_CARGA=$(paths.sh 08 BIN)
DIR_LOGS=$(paths.sh 08 LOG)
DIR_PARAM=$(paths.sh 08 PAR)
DIR_BACK=$(paths.sh 08 RES)
DIR_TEMP=$(paths.sh 08 TMP)
DIR_BIN=$(paths.sh 01 BIN)
BITACORA=$DIR_BIN/bitacoraITO.sh
ESTATUS=$DIR_BIN/estatus_c430.sh

export DIR_ARCH DIR_CARGA DIR_LOGS DIR_PARAM DIR_BACK DIR_TEMP DIR_BIN BITACORA ESTATUS


# Variables de ambiente del proceso
GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=ux_srvr
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME

# Variables de ambiente de Sybase
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export SYBASE DSQUERY 

# Recibe la fecha del dia que desean reprocesar   
fechProc=$1

rm $DIR_TEMP/CCF*${fechProc}D.txt
rm $DIR_ARCH/CCF*${fechProc}D.txt
rm $DIR_BACK/CCF*${fechProc}D.txt

echo "use M111" > $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete MTCCCF01 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF0000 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF1000 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF1001 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF2000 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF2001 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF5000 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCF9000 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCFEMP01 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCFUNI01 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCFTHS01 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'delete CCFHIS01 where nom_archivo="CCF'$fechProc'D.txt" ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql
echo 'drop table MTCTEST ' >> $DIR_TEMP/limpiaCCF.sql
echo "go" >> $DIR_TEMP/limpiaCCF.sql

isql -U$(usuario.sh) -D$(base.sh) -S$(servidor.sh) -P$(password.sh) -i $DIR_TEMP/limpiaCCF.sql 

