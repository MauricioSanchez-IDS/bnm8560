#!/bin/ksh
#_Hp_Changes for Linux MIgration -Start Added /bin/ksh -End
#. /opt/c430/000/fuentes/CCF/.variables


echo "*** entra a compilar " $SYBASE
${SYBASE}/OCS-15_0/bin/cpre64 C430TransCCF.cp
${SYBASE}/OCS-15_0/bin/cpre64 C430ErrHandle.cp

cc -std=c99 -o C430TransCCF -I. -I${SYBASE}/OCS-15_0/include \
            -L${SYBASE}/OCS-15_0/lib -lsybct64 -lsybcs64 -lsybtcl64 \
            -lsybcomn64 -lsybintl64 -lsybdb64  -lm -ldl -DSYB_LP64 \
            ${SYBASE}/OCS-15_0/include/sybesql.c  -g C430TransCCF.c \
            C430ErrHandle.c
