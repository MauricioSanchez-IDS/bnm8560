#!/usr/bin/ksh
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# sistema               : C430
# Directorio            : /opt/c430/000/bin
# Descripcion           : ESTATUS GENERAL DEL SISTEMA C430
# Version               : 1.0
# Autor                 : Ing. Jose Alberto Garcia Garcia
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

##set -x

PATH=$PATH:/opt/c430/000/bin; export PATH
SYBASE_OCS=OCS-15_0; export SYBASE_OCS
PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin; export PATH

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)
export  SYBASE DSQUERY USER

TMPF=/opt/c430/000/tmp/tmp1
DIR_BIN=/opt/c430/000/bin
DIR_LOG=$(paths.sh 01 LOG)
USUARIO=$(usuario.sh)
PASSWD=$(password.sh)
SERVIDOR=$(servidor.sh)
BASE=$(base.sh)
BITACORA=$DIR_BIN/bitacoraITO.sh

#
echo " ** DIR_LOG" $DIR_LOG  >> /opt/c430/000/var/log/prueba.log
echo " **  USUARIO" $USUARIO >> /opt/c430/000/var/log/prueba.log 
echo " ** PASSWD" $PASSWD >> /opt/c430/000/var/log/prueba.log 
echo " ** SERVIDOR" $SERVIDOR >> /opt/c430/000/var/log/prueba.log
echo " ** BASE    " $BASE  >> /opt/c430/000/var/log/prueba.log
#

exec 1>>$(paths.sh 01 LOG)/estatus_c430.log
#exec 2>&1 
TODO_BIEN=0
MSG1="FALLO CONEXION A SYBASE"
MSG2="NO ESTA CORRIENDO EL SERVICIO DE TUXEDO MOVRepsGeneralesDebito"
MSG3="NO ESTA CORRIENDO EL SERVICIO DE TUXEDO MOVRepsGeneralesCredito"
MSG4="NO ESTA CORRIENDO EL SERVICIO DE RUT"
MSG5="NO ESTA CORRIENDO EL SERVICIO DE TUXEDO ecTCcorp"
MSG6="NO ESTA CORRIENDO EL SERVICIO DE TUXEDO repdt"

# FUNCION PARA EXECUTAR UN QUERY POR PARAMETRO 
function ExecSQL
{
echo "++++++++++FUNCION++++++++++++++++++++++++++"
isql -U$USUARIO -P$PASSWD -S$SERVIDOR -D$BASE -b<<EOF
set nocount on
go
$*
go
EOF
}
echo "+++++++++++++++++++++++++++++++++++++++++++"
## VALIDA LA CONEXION A LA BASE DE DATOS 
ExecSQL "select getdate()" > $TMPF 
echo "+++++++++++++++++++++++++++++++++++++++++++"
if [[ $? -ne 0 ]]
then
   Mensaje=$(cat $TMPF)
   $BITACORA "SYBASE" "SYB_C430" "C" "10001" "$MSG1 - $Mensaje"
   echo "$MSG1"
   TODO_BIEN=1

else 
   echo " se conecto a la base de datos"	 
fi


DEBITO=$(ps -fea | grep -v 'grep' | grep -c 'MOVRepsGeneralesDebito')
CREDITO=$(ps -fea | grep -v 'grep' | grep -c 'MOVRepsGeneralesCredito')
RUT1=$(ps -fea | grep -v 'grep' | grep 'c995050' | grep -c 'rutsvr')
RUT2=$(ps -fea | grep -v 'grep' | grep 'c995050' | grep -c 'rut -c')
ECTCCORP=$(ps -fea | grep -v 'grep' | grep -c 'ecTCcorp')
REPDT=$(ps -fea | grep -v 'grep' | grep -c 'repdt')

if [[ $REPDT -eq 0 ]]
then
  $BITACORA "TUXEDO" "repdt" "C" "10052" "$MSG6"
  echo "$MSG2"
  TODO_BIEN=1
fi

if [[ $ECTCCORP -lt 3 ]]
then
  $BITACORA "TUXEDO" "ecTCcorp" "C" "10053" "$MSG5"
  echo "$MSG2"
  TODO_BIEN=1
fi

if [[ $DEBITO -eq 0 ]]
then
  $BITACORA "TUXEDO" "MOVRepsGeneralesDebito" "C" "10002" "$MSG2"
  echo "$MSG2"
  TODO_BIEN=1
fi
if [[ $CREDITO -eq 0 ]]
then
  $BITACORA "TUXEDO" "MOVRepsGeneralesCredito" "C" "10003" "$MSG3"
  echo "$MSG3"
  TODO_BIEN=1
fi

if [[ $RUT1 -eq 0 || $RUT2 -eq 0 ]]
then
  $BITACORA "SVRRUT" "RUT" "C" "10004" "$MSG4"
  echo "$MSG4"
  TODO_BIEN=1
fi
if [[ -f $TMPF ]]
then
   rm $TMPF
fi
if [[ $TODO_BIEN -eq 0 ]]
then
  echo "EL SISTEMA C430 ESTA CORRIENDO AL 100%"
  chmod 775 $(paths.sh 01 LOG)/estatus_c430.log
  return 0  
else
  chmod 775 $(paths.sh 01 LOG)/estatus_c430.log
  return 1
fi
