#!/bin/ksh
#__HP_Changes for Linux Migration -Start
#. /opt/c430/ibm/envio/param/.variables
#. /opt/c430/000/fuentes/CCF/.variables


echo "*** entra a compilar " $SYBASE
#${SYBASE}/OCS-15_0/bin/cpre C430CreateTempTables.cp
${SYBASE}/OCS-15_0/bin/cpre64 C430CreateTempTables.cp

#${SYBASE}/OCS-15_0/bin/cpre C430ErrHandle.cp
#__HP_Changes for Linux Migration -End
${SYBASE}/OCS-15_0/bin/cpre64 C430ErrHandle.cp

cc -m64 -g -DSYB_LP64 -o C430CreateTempTables -I. -I${SYBASE}/OCS-15_0/include \
            -L${SYBASE}/OCS-15_0/lib -lsybct64 -lsybcs64 -lsybtcl64 \
            -lsybcomn64 -lsybintl64 -lsybdb64 -lm -ldl -m64 \
            ${SYBASE}/OCS-15_0/include/sybesql.c C430CreateTempTables.c \
            C430ErrHandle.c
