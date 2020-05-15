#!/usr/bin/ksh
#***************************************************************************#
#DESCRIPCION:   INSTALADOR DE PROCESOS PARA MIGRACION LINUX
#FECHA:                          Marzo 2015
#          
# ***************************************************************************#
#set -x
USER=$1
RFC=CR
DIRBASE=`pwd`
TARNAME=${RFC}.tar
TARNAMELL=${RFC}n.tar
# BORRA TODA EVIDENCIA DE DIRRAIZ 
#DIRRAIZ=/opt/c430/000/PRUEBA
#DIRAPP=${DIRRAIZ}/opt/c430/000
DIRAPP=/opt/c430/000/PRUEBA
DIRINSTAL=${DIRAPP}/instala_${RFC}
DIRFUENTE=${DIRINSTAL}/FUENTES

# RUTAS PRINCIPALES PARA CADA HOME DIRECTORY
RUTA[1]=${DIRAPP}/bin/crontabs                   #c4300001 
RUTA[2]=${DIRAPP}/bin/ibm/envio/crontabs         #c4300002 
RUTA[3]=${DIRAPP}/bin/inte/envio/crontabs        #c4300003 
RUTA[4]=${DIRAPP}/bin/s011/envio/crontabs        #c4300004 
RUTA[5]=${DIRAPP}/bin/s011/recepcion/crontabs    #c4300005 
RUTA[6]=${DIRAPP}/bin/s111/envio/crontabs        #c4300006 
RUTA[7]=${DIRAPP}/bin/s111/recepcion/crontabs    #c4300007 
RUTA[8]=${DIRAPP}/bin/s702/envio/crontabs        #c4300008 
RUTATMP=
RUTAVAR[1]=${DIRAPP}/var                         #c4300001 
RUTAVAR[2]=${DIRAPP}/var/log/ibm                 #c4300002 
RUTAVAR[3]=${DIRAPP}/var/log/inte                #c4300003 
RUTAVAR[4]=${DIRAPP}/var/log/s011/envio          #c4300004 
RUTAVAR[5]=${DIRAPP}/var/log/s011/recepcion      #c4300005 
RUTAVAR[6]=${DIRAPP}/var/log/s111/envio          #c4300006 
RUTAVAR[7]=${DIRAPP}/var/log/s111/recepcion      #c4300007 
RUTAVAR[8]=${DIRAPP}/var/log/s702                #c4300008 
RUTATMPV=
RUTASC[1]=${DIRAPP}/bin
RUTASC[2]=${DIRAPP}/bin/ibm/envio
RUTASC[3]=${DIRAPP}/bin/inte/envio
RUTASC[4]=${DIRAPP}/bin/s011/envio
RUTASC[5]=${DIRAPP}/bin/s011/recepcion
RUTASC[6]=${DIRAPP}/bin/s111/envio
RUTASC[7]=${DIRAPP}/bin/s111/recepcion
RUTASC[8]=${DIRAPP}/bin/s702/envio


#------------------------------------------------------------------------------
#    PREPARACION DE LA INSTALACION / DESEMPAQUETA Y CREA DIRECTORIOS TEMPORALES
#---------------------------------------------------------------------------


#-----------------------------------------------------------------------
#                              INICIO DE INSTALACION
#----------------------------------------------------------------------------
instalacion()
{
    clear
        SERVIDOR=`uname -n` 

        echo '************************************************************' 
        echo 'FECHA DE INSTALACION' `date "+%d of %B %H:%M:%S"` 
        echo '************************************************************'

        echo "#################################################"
	echo "##                                             ##"
	echo "##          ASIGNACION DE PERMISOS             ##"
        echo "##                Equipo: ${SERVIDOR} "
	echo "##                Usuario: ${USER}            ##"
	echo "#################################################"
        echo "Presiona S (mayuscula) para continuar o N (mayuscula) para salir"; read OPC 
        while [ "${OPC}" != "S" && != "N" ]
        do
            echo "Tecleo $OPC"
            echo "Presiona S (mayuscula) para continuar o N (mayuscula) para salir"; read OPC
        done 

        if [ ${OPC} = "S" ]; then
            id user
            pwd

            NRT=`echo ${USER}|awk '{print substr($0,8,1)}'`

            crontab ${RUTA[${NRT}]}/${USER}.cron && echo "Cron de ${USER} instalado"

            echo "Asignacion de Permisos y Propiedad para el Usuario ${USER} "

            RUTATMP=${RUTASC[${NRT}]}

            RUTATMPV=${RUTAVAR[${NRT}]}

            chmod -R 755 ${RUTATMP}

            #chmod 744 ${RUTA[${NRT}]}/.ssh/*
            #chmod 700 ${RUTA[${NRT}]}/.ssh/id_dsa
            #chown -R ${USER}:c430000 ${RUTA[${NRT}]}/.ssh/* && echo ".....\c"
            #chmod 700 ${RUTA[${NRT}]}/.ssh

            chown -R ${USER}:c430000 ${RUTATMPV} && echo "....."
            chown -Rh ${USER}:c430000 ${RUTATMP}  && echo "[OK]"

            echo "Finaliza Instalacion con exito"
        else
            echo "Se rechaza peticion"
        fi

        echo " "
        echo " "
}

instalacion

#----------------------------------------------------------------------------


