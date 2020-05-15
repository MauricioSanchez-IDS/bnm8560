#!/bin/ksh

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Elimina todos los registros de una tabla 
# Version               : 1.0
# Autor                 : 

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 01 CRO)
export PATH

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export  SYBASE DSQUERY

case $1 in
"MTCEMP01") echo $1 Invalida
            exit;;
"MTCURP01") echo $1 Invalida
            exit;;
"MTCCLI01") echo $1 Invalida
            exit;;
"MTCBRP01") echo $1 Invalida
            exit;;
"MTCEJE01") echo $1 Invalida
            exit;;
"MTCUNI01") echo $1 Invalida
            exit;;
"MTCCON01") echo $1 Invalida
            exit;;
"MTCPGS01") echo $1 Invalida
            exit;;
"MTCCOR01") echo $1 Invalida
            exit;;
*)          echo $1 valida;;
esac

echo Inicia Accion ...

function DepuraTabla
{
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -b<<EOF
declare @s varchar(100)         
declare @t varchar(50)          
select @t='$1'
select @s='truncate table ' + @t 
execute(@s)                     
go
EOF
}

DepuraTabla $1
echo Finaliza Accion

