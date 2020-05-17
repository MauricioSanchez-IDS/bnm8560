# Sistema: c430
# Directorio: /opt/c430/000/bin/s111/recepcion/crontabs
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Procedimiento: bcpHISaMano.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:
# Modificaciones: 21 de mayo del 2000
# proposito: Adecuar a directorios estandar
# Autor: G. Antonio Villegas Ydu&ate

#__HP changes for Linux migration - start
#Change bcp to bcp64 with flag -Jroman8
bcp64 $(base.sh)..MTCHIS01 in $(paths.sh 07 DEP)/EHIS0317 -f $(paths.sh 07 PAR)/his.fmt -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -Jroman8
#__HP changes for Linux migration - End