#!/usr/bin/ksh
## Este shell pretende automatizar la instalacion del shell que
## que se utilizara para los envios, listados y extracciones de
## archivos de los buzones de Intelar SUPERDOME.
## Autor: Gabriel Hurtado Romero.
## Fecha: 03 de Octubre.
## Modifico: Gerardo Uriel Gamez Torres
## Fecha: 21 de Octubre.
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
## 21/oct/2011 inicio
## - Se establece permisos 700 para el directorio .ssh
## 21/oct/2011 fin
##

##############################################################################
# Parametros de entrada:
#
#	Este shell recibe dos parametros que se especifican a continuación.
# $1:	Tipo de ambiente Desarrollo(dev), Pruebas(uat), Producción(pro) o Cob(cob)
# $2: Usuario de Intelar.
##############################################################################


respaldo=0

#   ############################################################################
#         Validación de instalación previa
#   ############################################################################

if [ -a $HOME/ssh_intelar/instala_ssh ]; then
  echo "#########################################################################"
  echo "Ya fue instalado este shell"
  echo "#########################################################################"
  exit 1
fi

#   ############################################################################
#         Se establece permisos 700 al directorio .ssh
#   ############################################################################

chmod 700 .ssh >/dev/null 2>&1

#   ############################################################################
#         Respaldo del archivo known_hosts
#   ############################################################################


if [ -a $HOME/.ssh/known_hosts ]; then
  mkdir $HOME/ssh_intelar/resp
  cp $HOME/.ssh/known_hosts $HOME/ssh_intelar/resp/known_hosts
  respaldo=1
fi

## Se declaran las variables que se utilizaran en el Script.
ambiente=$1
rsd=$2
#cd $HOME
hn=`hostname`
user=`id -u -n`

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
    echo "     dev, uat, pro o cob"
    echo "  -  En donde usuario Intelar corresponde al usuario que se utilizara para "
    echo "     conectarse a los servidores de Intelar."    
    echo ""
    echo "     Es decir por ejemplo que para una instalacion en el ambiente de Desarrollo"
    echo "     se debera ejecutar el shell de instalacion de la siguiente manera:"
    echo ""
    echo "     install.sh dev usuario"
    echo ""
  echo "#########################################################################"
    exit 0
fi

#   #############################################################################
# 						Se configura ambiente de Desarrollo
#   #############################################################################
if (test $ambiente = dev) then
    echo "    \"SE INSTALA EN EL AMBIENTE DE DESARROLLO\""
    echo ""
    echo "   Se valida la existencia del archivo known_hosts"
    if (test -f $HOME/ssh_intelar/conf/known_hosts.ucadmty5 ); then
        echo "   Se encontro archivo known_hosts para su instalacion."
        cat $HOME/ssh_intelar/conf/known_hosts.ucadmty5>>$HOME/.ssh/known_hosts
        if (test $? -eq 0) then
            echo "   Archivo known_hosts instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo known_hosts."
			if [ $respaldo = 1 ];then
				mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
				rmdir $HOME/ssh_intelar/resp
			fi
            exit 0
        fi
		rm $HOME/ssh_intelar/conf/k* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo known_hosts para su instalacion."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
        exit 0
    fi
    echo ""
    echo "   Se valida la existencia del archivo ini.conf"
    if (test -f $HOME/ssh_intelar/conf/ini.conf.desa ); then
        echo "   Se encontro archivo ini.conf para su instalacion."
        cp -p $HOME/ssh_intelar/conf/ini.conf.desa $HOME/ssh_intelar/conf/ini.conf
        if (test $? -eq 0) then
            echo "   Archivo ini.conf instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo ini.conf."
			if [ $respaldo = 1 ];then
				mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
				rmdir $HOME/ssh_intelar/resp
			fi
            exit 0
        fi
		rm $HOME/ssh_intelar/conf/ini.conf.* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo ini.conf para su instalacion."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
        exit 0
    fi
#   #############################################################################
# 						Se configura ambiente de Pruebas UAT (uat)
#   #############################################################################
elif (test $ambiente = uat) then
    echo "    \"SE INSTALA EN EL AMBIENTE DE UAT\""
    echo ""
    echo "   Se valida la existencia del archivo known_hosts"
    if (test -f $HOME/ssh_intelar/conf/known_hosts.svc_intelar_gen_acyp); then
        echo "   Se encontro archivo known_hosts para su instalacion."
        cat $HOME/ssh_intelar/conf/known_hosts.svc_intelar_gen_acyp >> $HOME/.ssh/known_hosts
        if (test $? -eq 0) then
            echo "   Archivo known_hosts instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo known_hosts."
			if [ $respaldo = 1 ];then
				mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
				rmdir $HOME/ssh_intelar/resp
			fi
            exit 0
        fi
		rm $HOME/ssh_intelar/conf/k* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo known_hosts para su instalacion."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
        exit 0
    fi
    echo ""
    echo "   Se valida la existencia del archivo ini.conf"
    if (test -f $HOME/ssh_intelar/conf/ini.conf.acyp ); then
        echo "   Se encontro archivo ini.conf para su instalacion."
        cp -p $HOME/ssh_intelar/conf/ini.conf.acyp $HOME/ssh_intelar/conf/ini.conf
        if (test $? -eq 0) then
            echo "   Archivo ini.conf instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo ini.conf."
			if [ $respaldo = 1 ];then
				mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
				rmdir $HOME/ssh_intelar/resp
			fi
            exit 0
        fi
		rm $HOME/ssh_intelar/conf/ini.conf.* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo ini.conf para su instalacion."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
        exit 0
    fi
#   #############################################################################
# 						Se configura ambiente de Producción (pro)
#   #############################################################################
elif (test $ambiente = pro) then
    echo "    \"SE INSTALA EN EL AMBIENTE DE PRODUCCION\""
    echo ""
    echo "   Se valida la existencia del archivo known_hosts"
    if (test -f $HOME/ssh_intelar/conf/known_hosts.svc_intelar_gen); then
        echo "   Se encontro archivo known_hosts para su instalacion."
        cat $HOME/ssh_intelar/conf/known_hosts.svc_intelar_gen >> $HOME/.ssh/known_hosts
        if (test $? -eq 0) then
            echo "   Archivo known_hosts instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo known_hosts."
			if [ $respaldo = 1 ];then
				mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
				rmdir $HOME/ssh_intelar/resp
			fi
            exit 0
        fi
		rm $HOME/ssh_intelar/conf/k* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo known_hosts para su instalacion."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
        exit 0
    fi
    echo ""
    echo "   Se valida la existencia del archivo ini.conf"
    if (test -f $HOME/ssh_intelar/conf/ini.conf.prod.mx); then
        echo "   Se encontro archivo ini.conf para su instalacion."
        cp -p $HOME/ssh_intelar/conf/ini.conf.prod.mx $HOME/ssh_intelar/conf/ini.conf
        if (test $? -eq 0) then
            echo "   Archivo ini.conf instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo ini.conf."
			if [ $respaldo = 1 ];then
				mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
				rmdir $HOME/ssh_intelar/resp
			fi
            exit 0
        fi
		rm $HOME/ssh_intelar/conf/ini.conf.* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo ini.conf para su instalacion."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
        exit 0
    fi
#   #############################################################################
# 						Se configura ambiente de Cob (cob)
#   #############################################################################
elif (test $ambiente = cob) then
    echo "    \"SE INSTALA EN EL AMBIENTE DE PRODUCCION COB\""
    echo ""
    echo "   Se valida la existencia del archivo known_hosts"
    if (test -f $HOME/ssh_intelar/conf/known_hosts.svc_intelar_gen); then
        echo "   Se encontro archivo known_hosts para su instalacion."
        cat $HOME/ssh_intelar/conf/known_hosts.svc_intelar_gen >> $HOME/.ssh/known_hosts
        if (test $? -eq 0) then
            echo "   Archivo known_hosts instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo known_hosts."
			if [ $respaldo = 1 ];then
				mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
				rmdir $HOME/ssh_intelar/resp
			fi
            exit 0
        fi
		rm $HOME/ssh_intelar/conf/k* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo known_hosts para su instalacion."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
        exit 0
    fi
    echo ""
    echo "   Se valida la existencia del archivo ini.conf"
    if (test -f $HOME/ssh_intelar/conf/ini.conf.prod.my); then
        echo "   Se encontro archivo ini.conf para su instalacion."
        cp -p $HOME/ssh_intelar/conf/ini.conf.prod.my $HOME/ssh_intelar/conf/ini.conf
        if (test $? -eq 0) then
            echo "   Archivo ini.conf instalado correctamente."
          else
            echo "   ERROR!!!"
            echo "   No pudo realizar la instalacion del archivo ini.conf."
			if [ $respaldo = 1 ];then
				mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
				rmdir $HOME/ssh_intelar/resp
			fi
            exit 0
        fi
		rm $HOME/ssh_intelar/conf/ini.conf.* >/dev/null 2>&1
      else
        echo "   ERROR!!!"
        echo "   No se encontro archivo ini.conf para su instalacion."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
        exit 0
    fi
fi

#   #############################################################################
#    Modificación al shell ssh_intelar.sh
#   #############################################################################
echo ""
echo "   Se valida la existencia del shell ssh_intelar.sh"
if (test -f $HOME/ssh_intelar/ssh_intelar.sh); then
    echo "   Se encontro el shell ssh_intelar.sh para su instalacion."
    grep "USER=xtest" $HOME/ssh_intelar/ssh_intelar.sh
    if (test $? -eq 0) then
       echo "   Se instala el usuario sobre el shell ssh_intelar.sh."
       sed "s/USER=xtest/USER=$rsd/" $HOME/ssh_intelar/ssh_intelar.sh > $HOME/ssh_intelar/ssh_intelar.sh.TMP
       mv -f $HOME/ssh_intelar/ssh_intelar.sh.TMP $HOME/ssh_intelar/ssh_intelar.sh
       if (test $? -eq 0) then
          echo "   Shell ssh_intelar.sh instalado correctamente."
          chmod 755 $HOME/ssh_intelar/ssh_intelar.sh
        else
          echo "   ERROR!!!"
          echo "   No pudo realizar la instalacion en el shell ssh_intelar.sh."
		if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
		fi
          exit 0
       fi
     else
       echo "   ERROR!!!"
       echo "   No es posible instalar el usuario sobre el shell"
       echo "   ssh_intelar.sh, por no ser el shell original."
	   if [ $respaldo = 1 ];then
			mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
			rmdir $HOME/ssh_intelar/resp
	   fi
       exit 0
    fi
  else
    echo "   ERROR!!!"
    echo "   No se encontro el shell ssh_intelar.sh para su instalacion."
	if [ $respaldo = 1 ];then
		mv -f $HOME/ssh_intelar/resp/known_hosts $HOME/.ssh/known_hosts
		rmdir $HOME/ssh_intelar/resp
	fi
    exit 0
fi

#   ############################################################################
#   Se crea archivo instala_ssh que nos indica si ya se realizó la instalacion
#   ############################################################################
>$HOME/ssh_intelar/instala_ssh

echo ""
echo "  Termina instalacion..." 
echo "  La instalacion se efectuo en la siguiente fecha:"
date "+  FECHA: %m/%d/%y%n  HORA: %H:%M:%S"
echo ""
echo "%----------------------------------------------------------%"
exit 0
