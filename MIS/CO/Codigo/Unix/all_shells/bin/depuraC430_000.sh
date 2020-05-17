#!/bin/ksh
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

################################################################################
#Sistema:                 c430
#Directorio:              /opt/c430/000/bin 
#Nombre del shell:        depuraC430_000.sh
#Descripcion:             Comprime y depura archivos .LOG y .log del directorio 
#                         /opt/c430/000/var/log  
#Fecha de Creacion:       02/Sep/2004
#Version:                 1.0
#Autor:                   Francisco Erick Lucas Romero 
#Modificacio:             Jose Alberto Garcia Garcia
#Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion RSP
#################################################################################

PATH=/opt/c430/000/bin:$PATH
exec 1>/dev/null
exec 2>&1

################################################################################
#DEFINICION DE PARAMETROS GENERALES
################################################################################

DIR_LOG=$(paths.sh 01 LOG)
DIR_RESP=$(paths.sh 02 RES)
DIR_UTIL=$(paths.sh 03 DEP)
DIR_DEP=$(paths.sh 04 DEP)
DIR_SALID=$(paths.sh 05 RES)
DIR_REP=$(paths.sh 05 CRO)
DIR_EST=$(paths.sh 06 DEP)

FECHA=`date '+%Y%m%d'`

if [[ $# -eq 0 ]]
then
   DIAS_LIMITE=5     
else
   DIAS_LIMITE=$1
fi
DIAS_EST=15  

################################################################################
#BUSQUEDA Y RENOMBRE DE ARCHIVOS ".LOG" Y ".log"
################################################################################

find $DIR_LOG -name "*.log" | sed 's/....$//g' | xargs -i mv -f {}.log {}.$FECHA.log
find $DIR_LOG -name "*.LOG" | sed 's/....$//g' | xargs -i mv -f {}.LOG {}.$FECHA.LOG

################################################################################
#COMPRESION DE ARCHIVOS ".LOG" Y ".log"   
################################################################################ 
find $DIR_LOG -name "*.log" -exec compress {} \; 
find $DIR_LOG -name "*.LOG" -exec compress {} \;

################################################################################
#ELIMITACION DE ARCHIVOS CON 5 DIAS DE ANTIGUEDAD
################################################################################

find $DIR_LOG -size 0c -type f -exec rm -f {} \;
find $DIR_LOG -name "*.Z" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;
find $DIR_LOG -name "*.LOG" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;
find $DIR_LOG -name "*.log" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;
find $DIR_RESP -name "*SBF*" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;
find $DIR_UTIL -name "*.TXT" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;
find $DIR_SALID -name "*.TXT" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;
find $DIR_SALID -name "*REP*" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;
find $DIR_DEP -name "*" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;
find $DIR_LOG -name "Rep*" -type f -atime +$DIAS_LIMITE -exec rm -f {} \;

find $DIR_EST -name "*.txt" -type f -atime +$DIAS_EST -exec rm -f {} \;
find $DIR_EST -name "EMPR*" -type f -atime +$DIAS_EST -exec rm -f {} \;
find $DIR_EST -name "EJEC*" -type f -atime +$DIAS_EST -exec rm -f {} \;
find $DIR_EST -name "ABNX*" -type f -atime +$DIAS_EST -exec rm -f {} \;

return 0
