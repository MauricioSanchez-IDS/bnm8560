#!/bin/ksh
minutos30=1800000000
minutos10=600000000
echo "Voy a usleep $minutos10"
date
usleep $minutos10 
date
echo "Sali de usleep $minutos10"

echo "Voy a usleep $minutos30"
date
usleep $minutos30
date
echo "Sali de usleep $minutos30"

