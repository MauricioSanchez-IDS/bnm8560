#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

##############################################################################################
#SHELL PARA GENERAR LAS BITACORAS GENERALES DEL SISTEMA DE ACUERDO A LOS NUEVOS ESTANDARES   #
#PARAMETROS:  1.-   NOMBRE DEL MODULO (O PROCESO)                                            #
#             2.-   NOMBRE DEL SUB-PROCESO                                                   #
#             3.-   SEVERIDAD (NORMAL, WARNING, MAJOR, CRITICA ) N,W,M,C                     #
#             4.-   NUMERO DE ERROR                                                          # 
#             5.-   DESCIPCION DEL ERROR                                                     #
#DESARROLLADO POR:   EISSA                                                                   #
#JOSE ALBERTO GARCIA GARCIA                                                                  #
#02-SEP-2004                                                                                 # 
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC                  #
##############################################################################################

# VARIABLES DE AMBIENTE GENERALES
PATH=$PATH:/opt/c430/000/bin
RUTA=/opt/c430/000/var/log
BITACORA=c430.log
SISTEMA=C430
FECHA=`date +%Y/%m/%d`
HORA=`date +%X`

if test $# -lt 5
then
  echo "EL NUMERO DE PARAMETROS ES INCORRECTO"
  exit 1
fi
# ESCRIBIENDO EN LA BITACORA 
echo "$FECHA, $HORA, $SISTEMA, $1, $2, $3, $4, $5" >>  $RUTA/$BITACORA
chmod 775 $RUTA/$BITACORA 
