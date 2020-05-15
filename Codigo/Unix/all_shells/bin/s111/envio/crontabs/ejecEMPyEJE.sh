#! /bin/ksh
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end


# Sistema: c430
# Directorio: $(paths.sh 06 CRO)
# Procedimiento: ejecEMPyEJE.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor: YMF    03/11/97
# Modificaciones: 21 de mayo del 2000
#    Proposito: Adecuar a directorios estandar
#    Autor: G. Antonio Villegas Ydu&ate
#FSB: uso ejecEmpyEJE.sh <USUARIO> <PASSWD> <USER>
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 06 LOG)/ejecEMPyEJE.log
exec 2>&1

DIR_ARCH=$(paths.sh 06 DEP)
DIR_CARGA=$(paths.sh 06 BIN)
DIR_LOGS=$(paths.sh 06 LOG)
DIR_PARAM=$(paths.sh 06 PAR)
DIR_TEMP=$(paths.sh 06 TMP)
SERVIDOR=$(servidor.sh)
USUARIO="$(usuario.sh)"                                                        
PASSWORD="$(password.sh)"                                                      
                                                                               
export DIR_ARCH DIR_CARGA DIR_PARAM DIR_LOGS SERVIDOR DIR_TEMP USUARIO PASSWORD

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 06 CRO)

# Variables de Sybase
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
#USER=$(base.sh)
export SYBASE DSQUERY 

$DIR_CARGA/emp.sh
$DIR_CARGA/eje.sh
$DIR_CARGA/area.sh

$DIR_CARGA/enviaArcS111.sh EJEC 
$DIR_CARGA/enviaArcS111.sh EMPR
$DIR_CARGA/enviaArcS111.sh ABNX

