#!/bin/ksh
#_HP_Changes for Linux Migration -Start Added /bin/ksh -End
#. /opt/c430/000/fuentes/CCF/.variables


echo "*** entra a compilar " $SYBASE
${SYBASE}/OCS-15_0/bin/cpre64 C430TransCCF_rangos.cp
${SYBASE}/OCS-15_0/bin/cpre64 C430ErrHandle.cp

cc -std=c99 -m64 -g -DSYB_LP64 -o C430TransCCF_rangos -I. -I${SYBASE}/OCS-15_0/include \
            -L/usr/lib64 -L${SYBASE}/OCS-15_0/lib -lsybct64 -lsybcs64 -lsybtcl64 \
            -lsybcomn64 -lsybintl64 -lsybdb64 -lnsl -lm -ldl \
            ${SYBASE}/OCS-15_0/include/sybesql.c C430TransCCF_rangos.c \
            C430ErrHandle.c
