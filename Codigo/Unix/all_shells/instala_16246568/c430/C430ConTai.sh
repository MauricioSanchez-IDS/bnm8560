#!/bin/ksh
#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Extrae el contenido de una Tabla a un archivo de texto
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

echo Inicia Accion 
#_HP_Changes for Linux Migration -Start
#Changed bcp to bcp64 with flag -Jroman8

#bcp M111..$1 in $2 -c -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh)
bcp64 M111..$1 in $2 -c -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -Jroman8

#_HP_Changes for Linux Migration -End

echo Finaliza Accion


