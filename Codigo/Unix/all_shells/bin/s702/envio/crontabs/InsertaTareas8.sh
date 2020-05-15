#!/bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

#SHELL PARA INSERTAR TAREAS EN MTCPLAN01
#               VARIAVLES DE AMBIENTE PARA SYBASE
PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS
PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 08 CRO):$(paths.sh 08 BIN)
export PATH

exec 1>>$(paths.sh 08 LOG)/InsertaTareas8.log
exec 2>&1

GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=ucadmty1
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)
export  SYBASE DSQUERY USER

inserta(){
sqlcmd=$(echo sp_AgregaTarea "'"`whoami`"'", "'"$comando"'")
isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
$sqlcmd
go 
EOF
}

# Depura bitacora del proceso Maestro
rm $(paths.sh 08 LOG)/masterc430.log
comando="/opt/c430/000/bin/s702/envio/crontabs/C430TransCCF.sh 0"
export comando
inserta   

