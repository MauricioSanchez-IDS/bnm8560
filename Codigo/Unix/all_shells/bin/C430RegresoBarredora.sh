#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Desinstala Barredora del C430 de Tarjeta Corporativa
# Version               : 1.0
# Autor                 :


PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 01 CRO)
DIR_TEMP=$(paths.sh 01 TMP)
export PATH DIR_TEMP       

exec 1>>$(paths.sh 01 LOG)/C430RegresoBarredora.log 
exec 2>&1                                 

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export  SYBASE DSQUERY 

echo Inicia Desinstalacion de la Barredora Tarjeta Corporativa ...

isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -b <<EOF
print 'Vacia MTCURP01'
truncate table MTCURP01
go

print 'Vacia MTCUNI01'
truncate table MTCUNI01
go

print 'Vacia MTCCLI01'
truncate table MTCCLI01
go

print 'Vacia MTCBRP01'
truncate table MTCBRP01
go

print 'Vacia MTCEJE01'
truncate table MTCEJE01
go

print 'Vacia MTCEMP01'
truncate table MTCEMP01
go
EOF

echo Inicia Carga de Tablas ...

./C430ConTai.sh MTCURP01 $DIR_TEMP/urp01r.txt
./C430ConTai.sh MTCUNI01 $DIR_TEMP/uni01r.txt
./C430ConTai.sh MTCCLI01 $DIR_TEMP/cli01r.txt
./C430ConTai.sh MTCBRP01 $DIR_TEMP/brp01r.txt
./C430ConTai.sh MTCEJE01 $DIR_TEMP/eje01r.txt
./C430ConTai.sh MTCEMP01 $DIR_TEMP/emp01r.txt

echo Finaliza Carga de Tablas

echo Finaliza Desinstalacion de la Barredora Tarjeta Corporativa

