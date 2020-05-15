#! /bin/ksh

if [[ $(whoami) = "c4300001" ]]                                 
then                                                        
:                                                           
else                                                        
    echo "DEBE DE FIRMARSE CON c4300001 PARA CORRER ESTE INSTALADOR"     
    exit 1                                                  
fi

DSQUERY=SYB_C430
export DSQUERY

echo Inicia Instalador de Sps para Reportes ... 
echo
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep13.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep14.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep18.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep22.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep24.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep26.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i BorraTablsTemp.sql
echo
echo Instalacion Completa de Sps para Reportes                                         
