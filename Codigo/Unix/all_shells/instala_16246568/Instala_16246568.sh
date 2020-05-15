#!/usr/bin/ksh
#***************************************************************************#
#DESCRIPCION:	INSTALADOR DE PROCESOS PARA MIGRACION HP-UNIX
#FECHA: 		Septiembre 2012
#          
# ***************************************************************************#

RFC=16246568
DIRBASE=`pwd`
TARNAME=${RFC}.tar
TARNAMELL=${RFC}n.tar
# BORRA TODA EVIDENCIA DE DIRRAIZ 
#DIRRAIZ=/opt/c430/000/PRUEBA
DIRAPP=${DIRRAIZ}/opt/c430/000
DIRINSTAL=${DIRAPP}/instala_${RFC}
DIRRESPAL=${DIRINSTAL}/respaldos
DIRFUENTE=${DIRINSTAL}/FUENTES
PERL=/usr/bin/perl

# RUTAS PRINCIPALES PARA CADA HOME DIRECTORY
RUTA[1]=${DIRAPP}/bin                            #c4300001 
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


Preparacion() {

if [ ! -d ${DIRINSTAL} ];then

    echo "Creando directorios de instalacion del equipo `hostname`:"

    mkdir -p ${DIRINSTAL} && echo "Creacion de ${DIRINSTAL} [OK]"
    mkdir -p ${DIRFUENTE} && echo "Creacion de ${DIRFUENTE} [OK]"
    mkdir -p ${DIRRESPAL} && echo "Creacion de ${DIRRESPAL} [OK]"

    mv ${DIRBASE}/${TARNAME} ${DIRFUENTE} && echo "Se movio ${TARNAME} exitosamente"
    mv ${DIRBASE}/${TARNAMELL} ${DIRFUENTE} && echo "Se movio ${TARNAMELL} exitosamente"

    echo "\n\n[Enter] para continuar"
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
    if [ ! -f ${DIRINSTAL}/.instala.${RFC} -a -f ${DIRFUENTE}/${TARNAME} ];then
        echo "Proceso de instalacion iniciado"  
        > ${DIRINSTAL}/.instala.${RFC}
        SERVIDOR=`uname -n` 

        echo '************************************************************' >> $DIRINSTAL/log.txt
        echo 'FECHA DE INSTALACION' `date "+%d of %B %H:%M:%S"` >> $DIRINSTAL/log.txt
        echo '************************************************************' >> $DIRINSTAL/log.txt

########################
##Copiamos archivos            
        mkdir -p ${DIRAPP}/bin && echo "[OK] Directorio ${DIRAPP}/bin se creo correctamente"
        mkdir -p ${DIRAPP}/tmp && echo "[OK] Directorio ${DIRAPP}/tmp se creo correctamente"
        mkdir -p ${DIRAPP}/crontabs && echo "[OK] Directorio ${DIRAPP}/crontabs se creo correctamente"

	mkdir -p ${DIRAPP}/var/log/ibm && echo "[OK] Directorio ${DIRAPP}/var/log/ibm se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/ibm/envio && echo "[OK] Directorio ${DIRAPP}/var/log/ibm/envio se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/inte && echo "[OK] Directorio ${DIRAPP}/var/log/inte se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/inte/envio && echo "[OK] Directorio ${DIRAPP}/var/log/inte/envio se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/s011 && echo "[OK] Directorio ${DIRAPP}/var/log/s011 se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/s011/envio && echo "[OK] Directorio ${DIRAPP}/var/log/s011/envio se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/s011/recepcion && echo "[OK] Directorio ${DIRAPP}/var/log/s011/recepcion se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/s111 && echo "[OK] Directorio ${DIRAPP}/var/log/s111 se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/s111/envio && echo "[OK] Directorio ${DIRAPP}/var/log/s111/envio se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/s111/recepcion && echo "[OK] Directorio ${DIRAPP}/var/log/s111/recepcion se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/s702 && echo "[OK] Directorio ${DIRAPP}/var/log/s702 se creo correctamente "
	mkdir -p ${DIRAPP}/var/log/s702/envio && echo "[OK] Directorio ${DIRAPP}/var/log/s702/envio se creo correctamente "

	chown -Rh c4300001:c430 ${DIRAPP}/var
	chown -Rh c4300001:c430 ${DIRAPP}/tmp
	chown -Rh c4300001:c430 ${DIRAPP}/crontabs
        chown -Rh c4300001:c430 ${DIRINSTAL} 

	cd ${DIRAPP}/bin
        tar -xof ${DIRFUENTE}/${TARNAME} && echo "Extraccion de Items [OK]"

        chmod -R 775 ${DIRAPP}/var/log && echo "[OK] Asignacion de premisos Nuevos Directorios" 2> /dev/null

	chmod -R 775 ${DIRAPP}/bin && echo "[OK] Asignacion de permisos Items" 2> /dev/null

        sed 's/Maquina_Destino.*/Maquina_Destino='`hostname`'/' /opt/c430/000/bin/parametrosSAPUF.txt > /opt/c430/000/xx.txt
	mv /opt/c430/000/xx.txt /opt/c430/000/bin/parametrosSAPUF.txt

	cd ${DIRFUENTE}
        tar -xf ${TARNAMELL} && echo "Extraccion de Items Intelar [OK]"

        for USER in c4300001 c4300002 c4300003 c4300004 c4300005 c4300006 c4300007 c4300008
        do
	    NRT=`echo $USER|awk '{print substr($0,8,1)}'`
            cd ${RUTA[${NRT}]}
            cp ${DIRFUENTE}/${RFC}/Transf${NRT}/c430_000u${NRT}.llaves.intelar.tar .
            echo "##########################################################"
            echo "Instalando Archivos de seguridad para el usuario ${USER}"
            tar -xvf c430_000u${NRT}.llaves.intelar.tar
            if [ ${SERVIDOR} = "hux02mx" ] 
            then 
                mv .ssh*PRO/* .ssh
                if [ ${USER} = "c4300001" ]; then
                    sftp -oPort=10022 ${USER}@svc_intelar_gen_mty << EOF
bye
EOF
                    sftp -oPort=10022 ${USER}@svc_intelar_gen_mex << EOF
bye
EOF
                else
                    cp ${RUTA[1]}/.ssh/known_hosts ${RUTA[${NRT}]}/.ssh/.
                fi
                cp ${DIRFUENTE}/${RFC}/ini.conf.prod.mx ${RUTA[${NRT}]}/ssh_intelar/conf/ini.conf 
            else
                if [ ${SERVIDOR} = "v1h03mxt" ]
                then
                    mv .ssh*UAT/* .ssh
                    if [ ${USER} = "c4300001" ]; then
                        sftp -oPort=10022 ${USER}@svc_intelar_gen_acyp << EOF
bye
EOF
                    else
                        cp ${RUTA[1]}/.ssh/known_hosts ${RUTA[${NRT}]}/.ssh/.
                    fi
                    cp ${DIRFUENTE}/${RFC}/ini.conf.acyp  ${RUTA[${NRT}]}/ssh_intelar/conf/ini.conf
                else
                    mv .ssh*DEV/* .ssh
                    if [ ${USER} = "c4300001" ]; then
                        sftp -oPort=10022 ${USER}@ucadmty5 << EOF
bye
EOF
                    else
                        cp ${RUTA[1]}/.ssh/known_hosts ${RUTA[${NRT}]}/.ssh/.
                    fi
                    cp ${DIRFUENTE}/${RFC}/ini.conf.desa  ${RUTA[${NRT}]}/ssh_intelar/conf/ini.conf
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

            echo "Asignacion de Permisos y Propiedad para el Usuario ${USER} \c"
            RUTATMP=`echo ${RUTA[${NRT}]}|sed 's/\/crontabs//'`
            chmod -R 755 ${RUTATMP}
            chmod 744 ${RUTA[${NRT}]}/.ssh/*
            chmod 700 ${RUTA[${NRT}]}/.ssh/id_dsa
	    chown -R ${USER}:c430 ${RUTA[${NRT}]}/.ssh/* && echo ".....\c"
            chmod 700 ${RUTA[${NRT}]}/.ssh
	    chown -R ${USER}:c430 ${RUTAVAR[${NRT}]} && echo ".....\c"
	    chown -Rh ${USER}:c430 ${RUTATMP}  && echo "[OK]"
            echo "Para activar cron de ${USER} proporcione \c"
            su - ${USER} -c "/usr/bin/crontab ${DIRAPP}/crontabs/${USER}.cron" && echo "Cron de ${USER} instalado"

        done
        
        echo "\n\n[Enter] para continuar"
        read
   else
        echo "Ya existe una instalacion previa o Falta Arvhivo ${TARNAME}"
        echo "\n\n[Enter] para continuar"
        read
   fi
}
#----------------------------------------------------------------------------
#                        INICIO DE DESINSTALACION
#----------------------------------------------------------------------------
desinstalacion()
{
    clear
    if [ -f ${DIRINSTAL}/.instala.${RFC} ];then
        echo "Proceso de desinstalacion iniciado"
#Preparacion
        echo '************************************************************' >> $DIRINSTAL/log.txt
        echo ' FECHA DE DESINSTALACION' `date "+%d of %B %H:%M:%S"` >> $DIRINSTAL/log.txt
        echo '************************************************************' >> $DIRINSTAL/log.txt
#Restaurar los archivos
        OPC=N
        echo "#################################################"
        echo "##                                             ##"
        echo "##     FAVOR DE TOMAR EN CUENTA QUE LA         ##"
        echo "##      DESINSTALACION COMENZARA POR EL        ##"
        echo "##        USUARIO 8 y TERMINARA CON EL         ##"
        echo "##                 USUARIO 1                   ##"
        echo "##      TENER CUIDADO AL INTRODUCIR LOS        ##"
        echo "##                  PASSWORD                   ##"
        echo "##                                             ##"
        echo "#################################################"
        echo "Presiona S (mayuscula) para continuar"; read OPC
        while [ "${OPC}" != "S" ]
        do
            echo "Tecleo $OPC"
            echo "Presiona S (mayuscula) para continuar"; read OPC
        done 
        echo "Se dan de baja los crones"
        for USER in c4300008 c4300007 c4300006 c4300005 c4300004 c4300003 c4300002 c4300001
        do
            echo "Para bajar el cron de ${USER} proporcione \c"
            su - ${USER} -c "/usr/bin/crontab -r" && echo "Cron de ${USER} Desinstalado"
        done

        echo "#################################################"
        echo "##                                             ##"
        echo "##              SE ELIMINAN ITEMS              ##"
        echo "##                                             ##"
        echo "#################################################"
        for USER in c4300008 c4300007 c4300006 c4300005 c4300004 c4300003 c4300002 c4300001
        do
            echo "Para desinstalar elementos de ${USER} proporcione \c"
            
            su - ${USER} -c "chmod -R 777 ${DIRAPP}/var ${DIRAPP}/bin > /dev/null 2>&1"
        done

        rm -rf ${DIRAPP}/tmp ${DIRAPP}/crontabs ${DIRAPP}/bin ${DIRAPP}/var > /dev/null 2>&1

        echo 'Proceso completo'
        read
        rm ${DIRINSTAL}/.instala.${RFC}
    else
        echo "NO existe una instalacion previa"
        echo "\n\n[Enter] para continuar"
        read
    fi
	
}

#----------------------------------------------------------------------------
#            Menu de instalacion
#----------------------------------------------------------------------------
menu()
{
  clear 
  echo "MENU PRINCIPAL. RFC " $( echo ${TARNAME} | cut -d"." -f1 );  echo
  echo "[1] Instalacion Binarios"
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


