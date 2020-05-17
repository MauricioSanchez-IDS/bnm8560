#!/usr/bin/ksh
## Este shell pretende automatizar la instalacion del shell que
## que se utilizara para los envios, listados y extracciones de
## archivos de los buzones de Intelar SUPERDOME.
## Autor: Gabriel Hurtado Romero.
## Fecha: 03 de Octubre.
## Modifico: Gerardo Uriel Gamez Torres
## Fecha: 19 de sept 2014.
##
## Modificaciones:
## 04/oct/2011 inicio
## - Validacion de instalacion por medio de un archivo bandera, el cual solo se
##  crea si el shell concluye exitosamente.
## - Restriccion para que el shell no se ejecute con root.
## - Adición de comentarios en el shell en general.
## - Realización de respaldo del archivo known_hosts, esto con la finalidad de 
##  que en caso de falla se regrese la version original, si existe. Al final del
##  shell no se elimina el respaldo por si hay necesidad de ese archivo.
## - se comenta el comando cd $HOME, ya que se usan trayectorias absolutas.
## - En la parte de selección de ambiente se incluye la estructura if - elseif,
##  ya que los ambientes son mutuamente excluyentes.
## - En la edición del shell ssh_intelar.sh al hacer la sustitución del usuario
##  el comando mv se le adiciona la opción -f para forzar la ejecución.
## 04/oct/2011 fin
## 19/sept/2014 inicio
## - Eliminacion de manejo de archivos ssh, ya que se utiliza sistema centralizado de llaves
## - Adecuacion a ambiente Linux RH 6.4
## 19/sept/2014 fin
##

##############################################################################
# Parametros de entrada:
#
#	Este shell recibe dos parametros que se especifican a continuación.
# $1:	Tipo de ambiente SIT(sit), Pruebas(uat), Producción(mx Valle, qro Queretaro)
# $2: 	Usuario de Intelar.
##############################################################################

## Se declaran las variables que se utilizaran en el Script.
ambiente=$1
rsd=$2
hn=`hostname`
user=`id -u -n`
INSTDIR=`pwd`

#   ############################################################################
#         Validación de instalación previa
#   ############################################################################

if [ -a $INSTDIR/ssh_intelar/.instala_ssh ]; then
  echo "#########################################################################"
  echo "Ya fue instalado este shell"
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
echo "%       Instalador de Infraestructura Intelar c617         %"
echo "%----------------------------------------------------------%"
echo "%"
echo "%---------------------------------------------------------%"
echo "  Instalando en: "$hn
echo "  Instalando con el usuario: "$user
echo ""

#   ###########################################################################
#   En caso de "NO" ingresar los parametros de ambiente y rsd sucedera lo siguiente:
#   ############################################################################
if (test -z "$ambiente" -o -z "$rsd") then
  echo "#########################################################################"
    echo "               PARAMETROS INVALIDOS"
    echo "\n Usage: install.sh <ambiente> <usuario Intelar>"
    echo ""
    echo "  -  En donde ambiente puede tener cualquiera de los siguientes valores:"      
    echo "     sit, uat, mx o qro"
    echo "  -  En donde usuario Intelar corresponde al usuario que se utilizara para "
    echo "     conectarse a los servidores de Intelar."    
    echo ""
    echo "     Es decir por ejemplo que para una instalacion en el ambiente de UAT"
    echo "     se debera ejecutar el shell de instalacion de la siguiente manera:"
    echo ""
    echo "     install.sh uat usuario_intelar"
    echo ""
  echo "#########################################################################"
    exit 0
fi

#   #############################################################################
# 		Se configura ambiente de SIT
#   #############################################################################
if (test $ambiente = sit) then
    echo "    \"SE INSTALA EN EL AMBIENTE DE SIT\""
    echo ""
    #echo "   Se valida la existencia del archivo ini.conf"
    if (test -f $INSTDIR/ssh_intelar/conf/ini.conf.sit ); then
        #echo "   Se encontro archivo ini.conf para su instalacion."
        cp -p $INSTDIR/ssh_intelar/conf/ini.conf.sit $INSTDIR/ssh_intelar/conf/ini.conf
        if (test $? -eq 0) then
            echo "   Archivo ini.conf instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo ini.conf."
            exit 0
        fi
	rm $INSTDIR/ssh_intelar/conf/ini.conf.* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo ini.conf para su instalacion."
        exit 0
    fi
#   #############################################################################
# 		Se configura ambiente de Pruebas UAT (uat)
#   #############################################################################
elif (test $ambiente = uat) then
    echo "    \"SE INSTALA EN EL AMBIENTE DE UAT\""
    echo ""
    #echo "   Se valida la existencia del archivo ini.conf"
    if (test -f $INSTDIR/ssh_intelar/conf/ini.conf.acyp ); then
        #echo "   Se encontro archivo ini.conf para su instalacion."
        cp -p $INSTDIR/ssh_intelar/conf/ini.conf.acyp $INSTDIR/ssh_intelar/conf/ini.conf
        if (test $? -eq 0) then
            echo "   Archivo ini.conf instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo ini.conf."
            exit 0
        fi
	rm $INSTDIR/ssh_intelar/conf/ini.conf.* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo ini.conf para su instalacion."
        exit 0
    fi
#   #############################################################################
# 		Se configura ambiente de Producción (mx)
#   #############################################################################
elif (test $ambiente = mx) then
    echo "    \"SE INSTALA EN EL AMBIENTE DE PRODUCCION Valle\""
    echo ""
    #echo "   Se valida la existencia del archivo ini.conf"
    if (test -f $INSTDIR/ssh_intelar/conf/ini.conf.prod.mx); then
        #echo "   Se encontro archivo ini.conf para su instalacion."
        cp -p $INSTDIR/ssh_intelar/conf/ini.conf.prod.mx $INSTDIR/ssh_intelar/conf/ini.conf
        if (test $? -eq 0) then
            echo "   Archivo ini.conf instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo ini.conf."
            exit 0
        fi
	rm $INSTDIR/ssh_intelar/conf/ini.conf.* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo ini.conf para su instalacion."
        exit 0
    fi
#   #############################################################################
# 		Se configura ambiente de Produccion (qro)
#   #############################################################################
elif (test $ambiente = qro) then
    echo "    \"SE INSTALA EN EL AMBIENTE DE PRODUCCION Queretaro\""
    echo ""
    #echo "   Se valida la existencia del archivo ini.conf"
    if (test -f $INSTDIR/ssh_intelar/conf/ini.conf.prod.qro); then
        #echo "   Se encontro archivo ini.conf para su instalacion."
        cp -p $INSTDIR/ssh_intelar/conf/ini.conf.prod.qro $INSTDIR/ssh_intelar/conf/ini.conf
        if (test $? -eq 0) then
            echo "   Archivo ini.conf instalado correctamente."
        else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo ini.conf."
            exit 0
        fi
	rm $INSTDIR/ssh_intelar/conf/ini.conf.* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo ini.conf para su instalacion."
        exit 0
    fi
fi

#   #############################################################################
#    Modificación al shell ssh_intelar.sh
#   #############################################################################
echo ""
#echo "   Se valida la existencia del shell ssh_intelar.sh"
if (test -f $INSTDIR/ssh_intelar/ssh_intelar.sh); then
    #echo "   Se encontro el shell ssh_intelar.sh para su instalacion."
    grep "USER=xtest" $INSTDIR/ssh_intelar/ssh_intelar.sh >/dev/null 2>&1
    if (test $? -eq 0) then
       echo "   Se instala el usuario "$rsd" sobre el shell ssh_intelar.sh."
       sed "s/USER=xtest/USER=$rsd/" $INSTDIR/ssh_intelar/ssh_intelar.sh > $INSTDIR/ssh_intelar/ssh_intelar.sh.TMP
       mv -f $INSTDIR/ssh_intelar/ssh_intelar.sh.TMP $INSTDIR/ssh_intelar/ssh_intelar.sh
       if (test $? -eq 0) then
          echo "   Shell ssh_intelar.sh instalado correctamente."
          chmod 755 $INSTDIR/ssh_intelar/ssh_intelar.sh
        else
          echo "   ERROR!!!"
          echo "   No pudo realizar la instalacion en el shell ssh_intelar.sh."
          exit 0
       fi
     else
       echo "   ERROR!!!"
       echo "   No es posible instalar el usuario sobre el shell"
       echo "   ssh_intelar.sh, por no ser el shell original."
       exit 0
    fi
  else
    echo "   ERROR!!!"
    echo "   No se encontro el shell ssh_intelar.sh para su instalacion."
    exit 0
fi

#   ############################################################################
#   Se crea archivo instala_ssh que nos indica si ya se realizó la instalacion
#   ############################################################################
>$INSTDIR/ssh_intelar/.instala_ssh

echo ""
echo "  Termina instalacion..." 
echo "  La instalacion se efectuo en la siguiente fecha:"
date "+  FECHA: %m/%d/%y%n  HORA: %H:%M:%S"
echo ""
echo "%----------------------------------------------------------%"
exit 0
