#!/usr/bin/ksh
#***************************************************************************#
#DESCRIPCION:   GENERA LLAVES DE INTELAR PARA EL C430 LINUX
#FECHA:                         Mayo 2015
#          
# ***************************************************************************#
#set -x
CR=
DIRBASE=`pwd`
USUARIO=c430000
RUTAKEYS=/etc/opt/SSHtectia/keys
RUTAGENKEYS=/opt/tectia/util

#-----------------------------------------------------------------------
#                              INICIO DE INSTALACION
#----------------------------------------------------------------------------
instalacion()
{
    clear

    SERVIDOR=`uname -n`

    echo "Inicio Instalacion en el Servidor : ${SERVIDOR}"
    echo " "

    cd ${RUTAKEYS} 

    DIRKEYS=${RUTAKEYS}/${USUARIO}

    if [ ! -d ${DIRKEYS}2 -a ! -d ${DIRKEYS}8 ];then 

        cd ${RUTAGENKEYS} 

        for i in 2 3 4 5 6 7 8
        do
            USER=${USUARIO}${i}

            echo " "
            echo "Creando llaves para el usuario : ${USER}"
            echo " "

            ./generate_keys ${USER}

            echo "Llaves creadas para el usuario : ${USER}"

        done

        tar -cvf keysC430.tar ${RUTAKEYS}/${USUARIO}*/*.pub

        echo " "
        echo "Intalacion Completa " 
        echo "Pasar el archivo ${RUTAGENKEYS}/keysC430.tar a la PC"
        echo " "
        echo "[Enter] para continuar"
        read
    else
        echo "Ya existe una instalacion previa"
        echo " "
        echo "[Enter] para continuar"
        read
    fi

}

desinstalacion()
{

   cd ${RUTAKEYS}

   DIRKEYS=${RUTAKEYS}/${USUARIO}

   if [ -d ${DIRKEYS}2 -a -d ${DIRKEYS}8 ];then

      rm -rf ${USUARIO}*
      rm ${RUTAGENKEYS}/keysC430.tar
      echo "Llaves de Intalacion Eliminadas"
      echo "[Enter] para continuar"
      read

   else
      echo "No existe una instalacion previa"
      echo " "
      echo "[Enter] para continuar"
      read
  fi
}
#----------------------------------------------------------------------------
#            Menu de instalacion
#----------------------------------------------------------------------------
menu()
{
  clear 
  echo "MENU PRINCIPAL. CR ${CR} ";  echo
  echo "[1] Instalacion Llaves de Intelar"
  echo "[2] Desinstalacion Llaves de Intelar"
  echo "[3] Salir"
  echo; echo
}
#----------------------------------------------------------------------------

while true
do
   menu
   read OPCION
   
   case $OPCION in
        1) instalacion;;
        2) desinstalacion;;
        3) break;;
   esac
done
#----------------------------------------------------------------------------


