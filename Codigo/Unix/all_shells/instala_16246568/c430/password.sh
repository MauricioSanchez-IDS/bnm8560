#!/usr/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

########################################################
########################################################
##                                                    ##
##  SHELL PARA RECUPERAR EL PASSWORD DE SAPUF         ##
##                                                    ##
##  Version:1.0  Jose Alberto Garcia Garcia 3806928   ##
##                                                    ##
##  Creado: 13-01-2006                                ##
########################################################
########################################################
#set -x
DIR_SAPUF_CFG="/opt/c046/105/conf/sapufCentral40.cfg"
DIR_SAPUF_LOG="/opt/c430/000/var/log/c046Agente.log"
DIR_SAPUF_TMP="/opt/c430/000/var/log/c046Agente.tmp"
export DIR_SAPUF_CFG DIR_SAPUF_LOG DIR_SAPUF_TMP
DIR_SAPUF_BIN="/opt/c430/000/bin"
export DIR_SAPUF_BIN
LD_LIBRARY_PATH=/optware/sybase/ase157sp104/ASE-15_0/lib:/optware/sybase/ase157sp104//lib:/optware/sybase/ase157sp104/OCS-15_0/lib:/optware/sybase/ase157sp104/OCS-15_0/include:/usr/lib:/opt/c046/105/lib
export LD_LIBRARY_PATH

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin

export PATH 

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export  SYBASE DSQUERY 

exec 2>&1
integer Res=1
integer Cnt=0
#while ((Res == 1))
#do
 Valor=$($DIR_SAPUF_BIN/sapuf)
 Res=$?
#echo $Valor
# if [[ $Res -eq 1 ]]
# then
#    sleep 5
# fi
#done

if [[ $Res -eq 0 ]]
then
  echo "$Valor"
else
  echo "ERROR SAPUF - Reapuesta: $Valor ,  MATANDO AL SHELL PADRE" >> error.log
  kill $PPID
fi
