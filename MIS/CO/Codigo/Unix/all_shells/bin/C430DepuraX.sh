#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : Reportes
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Elimina los registros de una Tabla bajo una condicion 
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

echo "$2" > $DIR_TEMP/file1.txt
cat - << EOF | ed -s $DIR_TEMP/file1.txt
1,$ s/{{/(/g
1,$ s/}}/)/g
1,$ s/{/"/g
1,$ s/}/ /g
1,$ s/!/</g
1,$ s/?/>/g
w $DIR_TEMP/file2.txt
q
EOF
p2=`cat $DIR_TEMP/file2.txt`

#echo Tabla : $1
#echo Condicion : $p2

comando="delete $1 where $p2 "
#echo $comando

echo Inicia Accion ...

BorraReg ()
{
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -b<<EOF
$comando
go
EOF
}

BorraReg

echo Finaliza Accion

