#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Busca los registros de una Tabla bajo condicion o no 
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

echo "$1" > $DIR_TEMP/file1.txt
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
p1=`cat $DIR_TEMP/file2.txt`
                               
echo "$3" > $DIR_TEMP/file3.txt
cat - << EOF | ed -s $DIR_TEMP/file3.txt
1,$ s/{{/(/g
1,$ s/}}/)/g
1,$ s/{/"/g
1,$ s/}/ /g
1,$ s/!/</g
1,$ s/?/>/g
w $DIR_TEMP/file4.txt
q
EOF
p3=`cat $DIR_TEMP/file4.txt`


if [ "$p3" = '""' ]
then
comando="select $p1 from $2"
else
comando="select $p1 from $2 where $p3"
fi

echo Inicia Accion ...

BuscaReg ()
{
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -b<<EOF
$comando
go
EOF
}

BuscaReg > $4

echo Finaliza Accion

