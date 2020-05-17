#! /bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 07 BIN)
# Procedimiento: sumaHIS.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:
# Modificaciones: 21 de mayo del 2000
# proposito: Adecuar a directorios estandar
# Autor: G. Antonio Villegas Ydu&ate

DIR_ARCH=$(paths.sh 07 DEP)

total=0
cut -c50-63 $DIR_ARCH/$1 | \
  while read valor
  do
    total=`echo "$total+$valor" | bc`
  done
echo $total
