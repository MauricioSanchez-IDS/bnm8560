#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: 
# Procedimiento: emp_GEmpSinRep.sh
# Descripción: Genera archivo de Empresas Sin Representante
# Versión y fecha: 1.0 Febrero 2007
# Autor: FSWB Mty Rosa Nelly Rdz

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 02 CRO)
DIR_TEMP=$(paths.sh 06 TMP)
DIR_ARCH=$(paths.sh 06 DEP)
#(paths.sh 02 TMP)
export PATH DIR_TEMP DIR_ARCH

DIR_TRAB=$(paths.sh 06 BIN)
export PATH DIR_TRAB

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)
export  SYBASE DSQUERY USER


echo Inicio Genera archivo de Empresas Sin Representante

echo "Cuenta           NombreLargo                                  NombreGrabacion                              FechaVenceCreditoTotal  CreditoAcum  NominaEjec NombreEjecBnx                           NumeroEmpresa" > /opt/c430/000/bin/inte/envio/deposito/GEmpSinRep.txt

isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh)  -D$(base.sh)  -i $DIR_TRAB/emp_GEmpSinRep.sql  -w213 >> /opt/c430/000/bin/inte/envio/deposito/GEmpSinRep.txt


