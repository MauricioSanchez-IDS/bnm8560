#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Actualiza el campo de credito acumulado de los Bines
#                       : de Tarjeta Corporativa 
# Version               : 1.0
# Autor                 :


PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 01 CRO)
DIR_TEMP=$(paths.sh 01 TMP)
export PATH DIR_TEMP

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export  SYBASE DSQUERY


echo Inicia Accion ...

./C430ActCredA.sh 5475 14
./C430ActCredA.sh 5405 33
./C430ActCredA.sh 4859 42
./C430ActCredA.sh 4859 43
./C430ActCredA.sh 4074 58
./C430ActCredA.sh 5473 70
./C430ActCredA.sh 5473 80
./C430ActCredA.sh 5587 84
./C430ActCredA.sh 4943 88
./C430ActCredA.sh 4807 90

echo Finaliza Accion

