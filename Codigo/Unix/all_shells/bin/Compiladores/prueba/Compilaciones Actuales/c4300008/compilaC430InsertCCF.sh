#!/bin/ksh
#_HP_Changes for LinuxMigration -Start Added /bin/ksh -End
#. /opt/c430/000/fuentes/CCF/.variables


echo "*** entra a compilar " $SYBASE
${SYBASE}/OCS-15_0/bin/cpre64 C430InsertCCF.cp
${SYBASE}/OCS-15_0/bin/cpre64 C430ErrHandle.cp

cc -m64 -g -DSYB_LP64 -o C430InsertCCF -I. -I${SYBASE}/OCS-15_0/include \
            -L${SYBASE}/OCS-15_0/lib -lsybct64 -lsybcs64 -lsybtcl64 \
            -lsybcomn64 -lsybintl64 -lsybdb64 -lm -ldl \
            ${SYBASE}/OCS-15_0/include/sybesql.c C430InsertCCF.c \
            C430ErrHandle.c
