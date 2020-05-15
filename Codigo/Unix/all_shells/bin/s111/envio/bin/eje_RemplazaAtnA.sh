#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema                       : C430_000
# Directorio                    : 
# Nombre:       : eje_RemplazaAtnA.sh
# Descripcion           : Inicializa valor del campo emp_atn_a en tabla MTCEJE01
# Version y fecha       : 1.0   Feb 2007
# Autor                         : Rosa Nelly Rdz FSWB Mty

# Propósito: Actualizar valor del campo eje_atn_a con el nombre dede grabación del Ejecutivo. 


PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 02 CRO)
DIR_TEMP=$(paths.sh 06 TMP)
export PATH DIR_TEMP

DIR_TRAB=$(paths.sh 06 BIN)
export PATH DIR_TRAB

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)
export  SYBASE DSQUERY USER


echo Inicio Actualizacion del campo eje_atn_a ...

isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh)  -D$(base.sh)  -i $DIR_TRAB/eje_RemplazaAtnA.sql > $DIR_TEMP/eje_RemplazaAtnA.log

echo La Tabla MTCEJE01 ha sido actualizada
