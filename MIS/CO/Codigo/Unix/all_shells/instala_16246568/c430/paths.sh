#!/usr/bin/ksh
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# JAGG EISSA 26-08-2004
# RSP  HP    Junio / 2012   Revision para Migracion 
# SHELL PARA RECUPERERAR LAS RUTAS DE LAS APLICACIONES, LOGS, TMP, ETC
# PARAMETROS: 1 UsuariO(01-09),  2 i	Tipo de Path(BIN,PAR,RES,DEP,TMP,LOG,CRO)
# EJEMPLO: 	x=$(paths.sh 01 BIN)    
          
if [[ -z $1 && -z $2 ]]
then
  exit -1 
fi
PATRON=PATH_$2_$1
cat /opt/c430/000/bin/parametros.txt | grep "^$PATRON" | awk 'BEGIN {FS="="} {print $2}'
