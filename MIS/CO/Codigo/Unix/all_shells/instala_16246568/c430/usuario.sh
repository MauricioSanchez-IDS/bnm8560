#!/bin/ksh
##__HP changes for Linux migration - start -Added /bin/ksh -end

cat /opt/c430/000/bin/parametros.txt | sed 's/ //' | awk 'BEGIN {FS="="} /^USUARIO/ {print $2}'
