#!/usr/bin/ksh
## Este shell automatiza la desinstalacion del shell transferencia
## Autor: Gerardo Uriel Gamez Torres
## Fecha: 15 de mayo 2014.
##
## Modificaciones:
##

##############################################################################
# Parametros de entrada:
#
#	Este shell no recibe parametros.
##############################################################################

## Se declaran las variables que se utilizaran en el Script.
hn=`hostname`
user=`id -u -n`
INSTDIR=`pwd`

#   ############################################################################
#         Validación de instalación previa
#   ############################################################################

if [ ! -a $INSTDIR/ssh_intelar/.instala_ssh ]; then
  echo "#########################################################################"
  echo "No se encuentra  instalado el shell de transferencia"
  echo "#########################################################################"
  exit 1
fi

#   ############################################################################
#         Validación del usuario, nunca deberá ser root
#   ############################################################################
if [ $user = "root" ]; then
  echo "#########################################################################"
  echo "NOTA IMPORTANTE: La instalación no se debe realizar con el usuario root"
  echo "#########################################################################"
  exit 0
fi

echo "%"
echo "%----------------------------------------------------------%"
echo "%       Desinstalador de Infraestructura Intelar c617         %"
echo "%----------------------------------------------------------%"
echo "%"
echo "%---------------------------------------------------------%"
echo "  Desinstalando en: "$hn
echo "  Con el usuario: "$user
echo ""

#   #############################################################################
# 		Se eliminan componentes
#   #############################################################################

    rm -r $INSTDIR/ssh_intelar/conf >/dev/null 2>&1
    rm -r $INSTDIR/ssh_intelar >/dev/null 2>&1
    
echo ""
echo "  Termina desinstalacion..." 
echo "  La instalacion se efectuo en la siguiente fecha:"
date "+  FECHA: %m/%d/%y%n  HORA: %H:%M:%S"
echo ""
echo "%----------------------------------------------------------%"
exit 0
