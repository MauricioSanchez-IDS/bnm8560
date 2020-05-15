#! /bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 07 BIN)
# Procedimiento: insertMTPCPRO01.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:
# Modificaciones: 21 de mayo del 2000
# proposito: Adecuar a directorios estandar
# Autor: G. Antonio Villegas Ydu&ate
DIR_CARGA=$(paths.sh 07 BIN)

isql -U$(usuario.sh) -P$(password.sh) -D$(base.sh) -S$(servidor.sh) -i $DIR_CARGA/insertMTCPRO01.txt
