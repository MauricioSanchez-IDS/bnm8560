#!/bin/ksh
#_HP_Changes for Linux Migration -Start Change Added /bin/ksh -End
#. /opt/c430/ibm/envio/param/.variables
#. /opt/c430/000/fuentes/CCF/.variables

echo "......................................."
${SYBASE}/OCS-15_0/bin/cpre64 C430GetCompanies.cp

${SYBASE}/OCS-15_0/bin/cpre64 C430ErrHandle.cp

cc -m64 -g -DSYB_LP64 -o C430GetCompanies -I. -I${SYBASE}/OCS-15_0/include \
            -L${SYBASE}/OCS-15_0/lib -lsybct64 -lsybcs64 -lsybtcl64 \
            -lsybcomn64 -lsybintl64 -lsybdb64 -lm -ldl \
            ${SYBASE}/OCS-15_0/include/sybesql.c C430GetCompanies.c \
            C430ErrHandle.c
