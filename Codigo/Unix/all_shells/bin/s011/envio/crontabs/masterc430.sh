#!/usr/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 04 LOG)/masterc430.log
exec 2>&1

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin
export PATH

# Variables de ambiente del proceso
GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=HYPER
GE_APPNAME=Monitor
GE_USERUNIX=$(whoami) 
THREAD_DELAY=10
DELAY_MONITOR=60
DATE_LOAD=`date '+%Y%m%d'`
LOGMONITOR=$(paths.sh 04 LOG)/Monitorcambios.log
export GE_USERUNIX GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME GE_APPNAME
export THREAD_DELAY DELAY_MONITOR DATE_LOAD
export PLANIFICADOR LOGMONITOR

# Variables de ambiente de Sybase
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export SYBASE DSQUERY 

# Ejecuta el proceso
###$(paths.sh 01 BIN)/masterc430
$(paths.sh 04 CRO)/masterc430_new.sh

