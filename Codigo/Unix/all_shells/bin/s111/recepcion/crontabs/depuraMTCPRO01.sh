#!/usr/bin/ksh
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 07 CRO)
# Procedimiento: depuraMTCPRO01.sh
# Descripción:
# Versión y fecha: 1.0
# Autor: YMF    26/10/05
# Modificaciones: 
# proposito: 

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS


DIR_ARCH2=$(paths.sh 07 RES)
DIR_ARCH=$(paths.sh 07 DEP) 
DIR_CARGA=$(paths.sh 07 BIN)
DIR_PARAM=$(paths.sh 07 PAR)
DIR_LOGS=$(paths.sh 07 LOG)
DIR_TEMP=$(paths.sh 07 TMP)
DIR_BIN=$(paths.sh 01 BIN)


PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 07 CRO)
export DIR_ARCH DIR_TEMP DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS PATH

SERVIDOR=$(servidor.sh)
USUARIO=$(usuario.sh)
PASSWD=$(password.sh)

export SERVIDOR USUARIO PASSWD

# Variables de Sybase
	SYBASE=$(sybase.sh)
	DSQUERY=$(servidor.sh)
	USER=$(base.sh)
export SYBASE DSQUERY USER

isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_PARAM/depuraMTCPRO01.txt
