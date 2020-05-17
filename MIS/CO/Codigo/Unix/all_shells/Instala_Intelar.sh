#!/usr/bin/ksh
#***************************************************************************#
#DESCRIPCION:   INSTALADOR DE PROCESOS PARA MIGRACION LINUX
#FECHA:                          Marzo 2015
#          
# ***************************************************************************#
#set -x
RFC=CR
DIRBASE=`pwd`
TARNAME=${RFC}.tar
TARNAMELL=${RFC}n.tar
# BORRA TODA EVIDENCIA DE DIRRAIZ 
#DIRRAIZ=/opt/c430/000/PRUEBA
#DIRAPP=${DIRRAIZ}/opt/c430/000
DIRAPP=/opt/c430/000
DIRINSTAL=${DIRAPP}/instala_${RFC}
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
RUTAVAR[2]=${DIRAPP}/var/log/ibm                 #c4300002 
RUTAVAR[3]=${DIRAPP}/var/log/inte                #c4300003 
RUTAVAR[4]=${DIRAPP}/var/log/s011/envio          #c4300004 
RUTAVAR[5]=${DIRAPP}/var/log/s011/recepcion      #c4300005 
RUTAVAR[6]=${DIRAPP}/var/log/s111/envio          #c4300006 
RUTAVAR[7]=${DIRAPP}/var/log/s111/recepcion      #c4300007 
RUTAVAR[8]=${DIRAPP}/var/log/s702                #c4300008 


Preparacion() 
{

if [ ! -d ${DIRINSTAL} ];then

    clear
    echo "Creando directorios de instalacion del equipo `hostname`:"

    mkdir -p ${DIRINSTAL} && echo "Creacion de ${DIRINSTAL} [OK]"
    mkdir -p ${DIRFUENTE} && echo "Creacion de ${DIRFUENTE} [OK]"

    mv ${DIRBASE}/${TARNAMELL} ${DIRFUENTE} && echo "Se movio ${TARNAMELL} exitosamente"

    echo " "
    echo "[Enter] para continuar"
    read
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
    if [ ! -f ${DIRINSTAL}/.instala.${RFC} -a -f ${DIRFUENTE}/${TARNAMELL} ];then
        echo "Proceso de instalacion iniciado"  
        > ${DIRINSTAL}/.instala.${RFC}
        SERVIDOR=`uname -n` 

        echo '************************************************************' >> $DIRINSTAL/log.txt
        echo 'FECHA DE INSTALACION' `date "+%d of %B %H:%M:%S"` >> $DIRINSTAL/log.txt
        echo '************************************************************' >> $DIRINSTAL/log.txt

########################

        chown -Rh c4300001:c430000 ${DIRINSTAL} 

        cd ${DIRFUENTE}
        tar -xf ${TARNAMELL} && echo "Extraccion de Items Intelar [OK]"

        chown -Rh c4300001:c430000 ${DIRFUENTE}

        for USER in c4300001 c4300002 c4300003 c4300004 c4300005 c4300006 c4300007 c4300008
        do
            NRT=`echo $USER|awk '{print substr($0,8,1)}'`
            cd ${RUTA[${NRT}]}
            #cp ${DIRFUENTE}/${RFC}/Transf${NRT}/c430_000u${NRT}.llaves.intelar.tar .
            cp ${DIRFUENTE}/16246568/Transf${NRT}/c430_000u${NRT}.llaves.intelar.tar .
            chown c430000${NRT}:c430000 ${RUTA[${NRT}]}/c430_000u${NRT}.llaves.intelar.tar
            chmod 755 ${RUTA[${NRT}]}/c430_000u${NRT}.llaves.intelar.tar
            echo "##########################################################"
            echo "Instalando Archivos de seguridad para el usuario ${USER}"

            tar -xvf c430_000u${NRT}.llaves.intelar.tar
            
            if [ ${SERVIDOR} = "gtdblvmsyb3p" ] 
            then 
                mv .ssh*PRO/* .ssh
                if [ ${USER} = "c4300001" ]; then
                    sftp -P 10022 ${USER}@svc_intelar_gen_mty << EOF
bye
EOF
                    sftp -P 10022 ${USER}@svc_intelar_gen_mex << EOF
bye
EOF
                else
                    cp ${RUTA[1]}/.ssh/known_hosts ${RUTA[${NRT}]}/.ssh/.
                fi
                cp ${DIRFUENTE}/16246568/ini.conf.prod.mx ${RUTA[${NRT}]}/ssh_intelar/conf/ini.conf 
            else
                if [ ${SERVIDOR} = "gtdblvmsyb3u" ]
                then
                    mv .ssh*UAT/* .ssh
                    if [ ${USER} = "c4300001" ]; then
                        sftp -P 10022 ${USER}@svc_intelar_gen_acyp << EOF
bye
EOF
                    else
                        cp ${RUTA[1]}/.ssh/known_hosts ${RUTA[${NRT}]}/.ssh/.
                    fi
                    cp ${DIRFUENTE}/16246568/ini.conf.acyp  ${RUTA[${NRT}]}/ssh_intelar/conf/ini.conf
                else
                    if [ ${SERVIDOR} = "vm-de3d-772f" -o ${SERVIDOR} = "vm-2d9b-6102" ]
                    then
                        mv .ssh*DEV/* .ssh
                        if [ ${USER} = "c4300001" ]; then
                            sftp -P 10022 ${USER}@ucadmty5 << EOF
bye
EOF
                        else
                            cp ${RUTA[1]}/.ssh/known_hosts ${RUTA[${NRT}]}/.ssh/.
                        fi
                        cp ${DIRFUENTE}/16246568/ini.conf.desa  ${RUTA[${NRT}]}/ssh_intelar/conf/ini.conf
                    fi
                fi  
            fi 
        done

        echo "#################################################"
        echo "##                                             ##"
        echo "##          ASIGNACION DE PERMISOS             ##"
        echo "##                                             ##"
        echo "#################################################"

        for USER in c4300001 c4300002 c4300003 c4300004 c4300005 c4300006 c4300007 c4300008
        do
            NRT=`echo $USER|awk '{print substr($0,8,1)}'`

            echo "Asignacion de Permisos y Propiedad para el Usuario ${USER} "
            chmod 744 ${RUTA[${NRT}]}/.ssh/*
            chmod 700 ${RUTA[${NRT}]}/.ssh/id_dsa
            chown -R ${USER}:c430000 ${RUTA[${NRT}]}/.ssh/* && echo "....."
            chmod 700 ${RUTA[${NRT}]}/.ssh
            echo "[OK]"

        done
         
        echo " " 
        echo "[Enter] para continuar"
        read
    else
        echo "Ya existe una instalacion previa o Falta Arvhivo ${TARNAME}"
        echo " "
        echo "[Enter] para continuar"
        read
    fi

}

desinstalacion()
{

   mv ${DIRFUENTE}/${TARNAMELL} ${DIRBASE} && echo "Se movio ${TARNAMELL} exitosamente"
   rm -rf ${DIRINSTAL}
   echo "Directorio de Intalacion Eliminado"
   echo "[Enter] para continuar"
   read
}
#----------------------------------------------------------------------------
#            Menu de instalacion
#----------------------------------------------------------------------------
menu()
{
  clear 
  echo "MENU PRINCIPAL. CR " $( echo ${TARNAME} | cut -d"." -f1 );  echo
  echo "[1] Instalacion Intelar"
  echo "[2] Desinstalacion Intelar"
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


