#!/usr/bin/ksh
#***************************************************************************#
#DESCRIPCION:   INSTALADOR DE PROCESOS PARA MIGRACION LINUX
#FECHA:                          Julio 2015
#          
# ***************************************************************************#
#set -x

SERVIDOR=`uname -n`
USR=$(whoami)
NUSR=$( echo $USR | cut -c8-8)
#DIRBASE=`pwd`
DIRBASE=/opt/c430/000
TARNAME=Usr${NUSR}.tar
# BORRA TODA EVIDENCIA DE DIRRAIZ 
#DIRRAIZ=/opt/c430/000/PRUEBA
#DIRAPP=${DIRRAIZ}/opt/c430/000
#DIRAPP=/opt/c430/000/PRUEBA
DIRAPP=/opt/c430/000
DIRINSTAL=${DIRAPP}/instala
DIRFUENTE=${DIRINSTAL}/FUENTES

# RUTAS PRINCIPALES PARA CADA HOME DIRECTORY
RUTA[1]=${DIRAPP}/bin                            #c4300001 
RUTA[2]=${DIRAPP}/bin/ibm/envio/crontabs         #c4300002 
RUTA[3]=${DIRAPP}/bin/inte/envio/crontabs        #c4300003 
RUTA[4]=${DIRAPP}/bin/s011/envio/crontabs        #c4300004 
RUTA[5]=${DIRAPP}/bin/s011/recepcion/crontabs    #c4300005 
RUTA[6]=${DIRAPP}/bin/s111/envio/crontabs        #c4300006 
RUTA[7]=${DIRAPP}/bin/s111/recepcion/crontabs    #c4300007 
RUTA[8]=${DIRAPP}/bin/s702/envio/crontabs        #c4300008 
RUTA[9]=${DIRAPP}/bin/s702/recepcion/crontabs    #c4300008
RUTATMP=
RUTAVAR[1]=${DIRAPP}/var                         #c4300001 
RUTAVAR[2]=${DIRAPP}/var/log/ibm/envio           #c4300002 
RUTAVAR[3]=${DIRAPP}/var/log/inte/envio          #c4300003 
RUTAVAR[4]=${DIRAPP}/var/log/s011/envio          #c4300004 
RUTAVAR[5]=${DIRAPP}/var/log/s011/recepcion      #c4300005 
RUTAVAR[6]=${DIRAPP}/var/log/s111/envio          #c4300006 
RUTAVAR[7]=${DIRAPP}/var/log/s111/recepcion      #c4300007 
RUTAVAR[8]=${DIRAPP}/var/log/s702/envio          #c4300008 

DIR[1]=
DIR[2]=ibm
DIR[3]=inte
DIR[4]=s011
DIR[5]=s011
DIR[6]=s111
DIR[7]=s111
DIR[8]=s702



Preparacion() 
{

if [ ! -d ${DIRINSTAL} ];then

    clear
    SERVER=`uname -n`
    echo "Creando directorios de instalacion del equipo ${SERVER} :"

    mkdir -p ${DIRINSTAL} && echo "Creacion de ${DIRINSTAL} [OK]"
    mkdir -p ${DIRFUENTE} && echo "Creacion de ${DIRFUENTE} [OK]"

    chmod -R 770 ${DIRINSTAL}

    cp ${DIRBASE}/${TARNAME} ${DIRFUENTE} && echo "Se copio exitosamente ${TARNAME} "

    echo " "
    echo "[Enter] para continuar"
    read

else

    cp ${DIRBASE}/${TARNAME} ${DIRFUENTE} 

fi
}

#------------------------------------------------------------------------------
#    PREPARACION DE LA INSTALACION / DESEMPAQUETA Y CREA DIRECTORIOS TEMPORALES
#---------------------------------------------------------------------------


#-----------------------------------------------------------------------
#                              INICIO DE INSTALACION
#----------------------------------------------------------------------------
instalacion()
{
    clear
    if [ -f ${DIRFUENTE}/${TARNAME} ];then
        echo "Proceso de instalacion iniciado"  

########################
##Copiamos archivos            
        
        if [ ${USR} = "c4300001" ]
        then

          rm -rf ${DIRAPP}/bin

          mkdir -p ${DIRAPP}/bin && echo "[OK] Directorio ${DIRAPP}/bin se creo correctamente"
          mkdir -p ${DIRAPP}/tmp && echo "[OK] Directorio ${DIRAPP}/tmp se creo correctamente"
          mkdir -p ${DIRAPP}/crontabs && echo "[OK] Directorio ${DIRAPP}/crontabs se creo correctamente"
          mkdir -p ${DIRAPP}/bin/ibm && echo "[OK] Directorio ${DIRAPP}/bin/ibm se creo correctamente"
          mkdir -p ${DIRAPP}/bin/inte && echo "[OK] Directorio ${DIRAPP}/bin/inte se creo correctamente"
          mkdir -p ${DIRAPP}/bin/s011 && echo "[OK] Directorio ${DIRAPP}/bin/s011 se creo correctamente"
          mkdir -p ${DIRAPP}/bin/s111 && echo "[OK] Directorio ${DIRAPP}/bin/s111 se creo correctamente"
          mkdir -p ${DIRAPP}/bin/s702 && echo "[OK] Directorio ${DIRAPP}/bin/s702 se creo correctamente"
 
          mkdir -p ${DIRAPP}/var/log/ibm && echo "[OK] Directorio ${DIRAPP}/var/log/ibm se creo correctamente "
          mkdir -p ${DIRAPP}/var/log/inte && echo "[OK] Directorio ${DIRAPP}/var/log/inte se creo correctamente "
          mkdir -p ${DIRAPP}/var/log/s011 && echo "[OK] Directorio ${DIRAPP}/var/log/s011 se creo correctamente "
          mkdir -p ${DIRAPP}/var/log/s111 && echo "[OK] Directorio ${DIRAPP}/var/log/s111 se creo correctamente "
          mkdir -p ${DIRAPP}/var/log/s702 && echo "[OK] Directorio ${DIRAPP}/var/log/s702 se creo correctamente "

          chown -Rh c4300001:c430000 ${DIRAPP}/var
          chown -Rh c4300001:c430000 ${DIRAPP}/tmp
          chown -Rh c4300001:c430000 ${DIRAPP}/crontabs
          chown -Rh c4300001:c430000 ${DIRINSTAL} 
          chown -Rh c4300001:c430000 ${DIRAPP}

        else

          mkdir -p ${RUTAVAR[${NUSR}]} && echo "[OK] Directorio ${RUTAVAR[${NUSR}]} se creo correctamente "

        fi

        cd ${DIRAPP}/bin/${DIR[${NUSR}]}

        tar -xof ${DIRFUENTE}/${TARNAME} && echo "Extraccion de Items [OK]"

        if [ ${USR} = "c4300001" ]
        then

          chmod -R 775 ${DIRAPP}/bin && echo "[OK] Asignacion de permisos Items" 2> /dev/null

          sed 's/Maquina_Destino.*/Maquina_Destino='`hostname`'/' ${DIRAPP}/bin/parametrosSAPUF.txt > ${DIRAPP}/xx.txt
          mv ${DIRAPP}/xx.txt ${DIRAPP}/bin/parametrosSAPUF.txt
          chown c4300001:c430000 ${DIRAPP}/bin/parametrosSAPUF.txt

          mv ${DIRAPP}/bin/profile ${DIRAPP}/bin/.profile

          cp ${DIRAPP}/bin/crontabs/* ${DIRAPP}/crontabs

          rm -rf ${DIRAPP}/bin/crontabs

        else

          if [ ${SERVIDOR} = "gtdblvmsyb3u" ]
          then

             cp ${DIRBASE}/ini.conf.acyp ${RUTA[${NUSR}]}/ssh_intelar/conf/ini.conf
   
             chown -R ${USR}:c430000 ${RUTA[${NUSR}]}/ssh_intelar/conf/ini.conf

             chmod 640 ${RUTA[${NUSR}]}/ssh_intelar/conf/ini.conf

          fi

          if [ ${SERVIDOR} = "qrdblvmsyb3p" ]
          then 

             cp ${DIRBASE}/ini.conf.prod ${RUTA[${NUSR}]}/ssh_intelar/conf/ini.conf
   
             chown -R ${USR}:c430000 ${RUTA[${NUSR}]}/ssh_intelar/conf/ini.conf

             chmod 640 ${RUTA[${NUSR}]}/ssh_intelar/conf/ini.conf

          fi
 
        fi

        echo "#################################################"
        echo "##                                             ##"
        echo "##          ASIGNACION DE PERMISOS             ##"
        echo "##                                             ##"
        echo "#################################################"

        echo "Asignacion de Permisos y Propiedad para el Usuario ${USR} "
        RUTATMP=`echo ${RUTA[${NUSR}]}|sed 's/\/crontabs//'`
        chmod -R 755 ${RUTATMP}

        if [ ${NUSR} = 4 -o ${NUSR} = 5 -o ${NUSR} = 6 -o ${NUSR} = 7 ]
        then
             chown -R ${USR}:c430000 ${RUTAVAR[${NUSR}]} && echo "....."
        fi

        chown -Rh ${USR}:c430000 ${RUTATMP}  && echo "[OK]"

        if [ ${USR} = "c4300001" ]
        then

          chmod -R 770 ${DIRAPP}/bin/ibm
          chmod -R 770 ${DIRAPP}/bin/inte
          chmod -R 770 ${DIRAPP}/bin/s011
          chmod -R 770 ${DIRAPP}/bin/s111
          chmod -R 770 ${DIRAPP}/bin/s702
          chmod -R 770 ${DIRAPP}/var/log/ibm
          chmod -R 770 ${DIRAPP}/var/log/inte
          chmod -R 770 ${DIRAPP}/var/log/s011
          chmod -R 770 ${DIRAPP}/var/log/s111
          chmod -R 770 ${DIRAPP}/var/log/s702

        fi

        crontab ${DIRAPP}/crontabs/${USR}.cron && echo "Cron de ${USR} instalado"
         
        echo " " 
        echo "[Enter] para continuar"
        read
    else
        echo "Falta Archivo ${TARNAME}"
        echo " "
        echo "[Enter] para continuar"
        read
    fi

}
#----------------------------------------------------------------------------
#                        INICIO DE DESINSTALACION
#----------------------------------------------------------------------------
desinstalacion()
{
    clear 
    if [ -d ${DIRINSTAL} ];then
        echo "Proceso de desinstalacion iniciado"
        OPC=N
        echo "#################################################"
        echo "##                                             ##"
        echo "##     FAVOR DE TOMAR EN CUENTA QUE LA         ##"
        echo "##   DESINSTALACION DEBE COMENZAR POR EL       ##"
        echo "##        USUARIO 8 y TERMINARA CON EL         ##"
        echo "##                 USUARIO 1                   ##"
        echo "##                                             ##"
        echo "#################################################"
        echo "Presiona S (mayuscula) para continuar"; read OPC
        while [ "${OPC}" != "S" ]
        do
            echo "Tecleo $OPC"
            echo "Presiona S (mayuscula) para continuar"; read OPC
        done 

        echo "Se dan de baja el cron"
        crontab -r
        echo "Cron de ${USR} Desinstalado"

        echo "#################################################"
        echo "##                                             ##"
        echo "##              SE ELIMINAN ITEMS              ##"
        echo "##                                             ##"
        echo "#################################################"

        RUTATMP=`echo ${RUTA[${NUSR}]}|sed 's/\/crontabs//'`
        rm -rf ${RUTATMP}

        if [ ${USR} = "c4300001" ]
        then
            rm -rf ${DIRAPP}
        else
            rm -rf ${RUTAVAR[${NUSR}]}
        fi

        if [ ${USR} = "c4300008" ]
        then

            RUTATMP=`echo ${RUTA[9]}|sed 's/\/crontabs//'`
            rm -rf ${RUTATMP}
        
        fi
        
        echo 'Proceso completo'
        echo " "
        echo "[Enter] para continuar"
        read
    else
        echo "NO existe una instalacion previa"
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
  echo "Equipo ${SERVIDOR}  Usuario ${USR}"
  echo "--------------------------------------- "
  echo "MENU PRINCIPAL "
  echo "[1] Instalacion Binarios "
  echo "[2] Desinstalacion"
  echo "[3] Salir"
  echo; echo
}
#----------------------------------------------------------------------------


Preparacion

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


