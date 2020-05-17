#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

/*# Sistema: c430
# Directorio: $(paths.sh 07 BIN)
# Procedimiento: inteBNX1.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:  */

sp_IntegracionFase1_BNX EBNX0106
go
EOF
