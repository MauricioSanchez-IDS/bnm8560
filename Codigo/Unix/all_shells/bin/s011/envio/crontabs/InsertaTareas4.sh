#!/usr/bin/ksh
#SHELL PARA INSERTAR TAREAS EN MTCPLAN01
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
#Fecha de Creacion 09-07-2004  Jose Alberto Garcia Garcia
#Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

#               VARIAVLES DE AMBIENTE PARA SYBASE
PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS
PATH=$PATH:$(sybase.sh)/OCS-15_0/bin
export PATH

exec 1>>$(paths.sh 04 LOG)/InsertaTareas4.log
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
echo "COMANDO -> $sqlcmd"
echo isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE 
isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
$sqlcmd
go 
EOF
}

comando="/opt/c430/000/bin/s011/envio/crontabs/creaArchivoCDF.sh 0 0 0"
export comando
inserta
