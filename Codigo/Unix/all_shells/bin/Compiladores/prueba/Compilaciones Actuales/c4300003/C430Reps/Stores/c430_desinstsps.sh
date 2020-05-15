#! /bin/ksh

if [[ $(whoami) = "c4300001" ]]                                 
then                                                        
:                                                           
else                                                        
    echo "DEBE DE FIRMARSE CON c4300001 PARA CORRER ESTE DESINSTALADOR"     
    exit 1                                                  
fi

DSQUERY=SYB_C430
export DSQUERY

echo Inicia Desinstalador de Sps para Reportes ... 
echo
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep13ant.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep14ant.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep18ant.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep22ant.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep24ant.sql
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -i sp_ObtenDatosRep26ant.sql
echo
echo Desinstalacion Completa de Sps para Reportes                                         
