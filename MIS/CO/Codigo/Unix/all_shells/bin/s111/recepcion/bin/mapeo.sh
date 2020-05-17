# !/usr/bin/ksh

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: 
# Procedimiento: mapeo.sh
# Descripcion: Ejecuta el programa para generar archivos de cuentas mapeadas
#              con citi o cuentas sin mapeo con citi 
# Version y fecha: 1.0   29/01/2003
# Autor:  Jose Ramon Gonzalez Diaz
#                                                                               
# Modificacion :                                                                
# Autor y fecha:                                                                

#PATH=$PATH:$(sybase.sh)/OCS-12_5/bin
PATH=$PATH:$(sybase.sh)/OCS-15_0/bin
                                                                                
export PATH   

#Genera variables de ambiente de Sybase de produccion
GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=I50


export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME

# Variables de Sybase
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)

export SYBASE DSQUERY USER

clear
echo "\nGenerando archivo de mapeo."
echo "\nINICIA `date +%H:%M:%S`"

#mapeo 5473 80 0 13800 # Una empresa en especifico
mapeo 0 0 0 0 # Todo el banco

echo "\nTERMINA `date +%H:%M:%S`"
exit
