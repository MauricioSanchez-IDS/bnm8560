#!/usr/bin/ksh
#***************************************************************************#
#DESCRIPCION:   INSTALADOR DE PROCESOS PARA MIGRACION A FORTIDB
#FECHA:                          Marzo 2019
#          
# ***************************************************************************#
#set -x

SERVIDOR=`uname -n`
USR=$(whoami)
NUSR=$( echo $USR | cut -c8-8)
#DIRBASE=`pwd`
DIRBASE=/opt/c430/000
TARNAME=PzasFortiDB.tar
# BORRA TODA EVIDENCIA DE DIRRAIZ 
#DIRRAIZ=/opt/c430/000/PRUEBA
#DIRAPP=${DIRRAIZ}/opt/c430/000
#DIRAPP=/opt/c430/000/PRUEBA
DIRAPP=/opt/c430/000
DIRINSTAL=${DIRAPP}/instala
DIRFUENTE=${DIRINSTAL}/FUENTES

# RUTAS PRINCIPALES PARA CADA HOME DIRECTORY
RUTA[1]=${DIRAPP}/bin                       #c4300001 
RUTA[2]=${DIRAPP}/bin/ibm/envio/bin         #c4300002 
RUTA[3]=${DIRAPP}/bin/inte/envio/bin        #c4300003 
RUTA[4]=${DIRAPP}/bin/s011/envio/bin        #c4300004 
RUTA[5]=${DIRAPP}/bin/s011/recepcion/bin    #c4300005 


Preparacion() 
{

if [ ! -d ${DIRINSTAL} ];then

    clear
    SERVER=`uname -n`
    echo "Creando directorio de instalacion del equipo ${SERVER} :"

    mkdir -p ${DIRINSTAL} && echo "Creacion de ${DIRINSTAL} [OK]"
    chmod -R 770 ${DIRINSTAL}

    cp ${DIRBASE}/${TARNAME} ${DIRINSTAL} && echo "Se copio exitosamente ${TARNAME} "

    cd ${DIRINSTAL}

    tar -xof ${TARNAME} && echo "Extraccion de Items [OK]"

    echo " "
    echo "[Enter] para continuar"
    read

else

    cp ${DIRBASE}/${TARNAME} ${DIRINSTAL} 

    cd ${DIRINSTAL}

    tar -xof ${TARNAME}

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
    if [ -f ${DIRINSTAL}/${TARNAME} ];then
        echo "Proceso de instalacion iniciado"  

#        for USER in c4300001 c4300002 c4300003 c4300004 c4300005
#        do

#            echo "Por favor firmarse en el Usuario ${USER} : \c"
#            su - ${USER} -c && echo "Se firmo correctamente"

#            echo "Por favor firmarse en el Usuario ${USER} : "
#            exit
#            pbrun ${USER}

            NRT=`echo $USER|awk '{print substr($0,8,1)}'`
            cd ${RUTA[${NRT}]}

            crontab -r && echo "Cron de ${USER} Desinstalado"
            
            if [ ${USER} = "c4300001" ]
            then

                 mv sapuf sapuf_afdb 
                 cp ${DIRINSTAL}/sapuf .
                 chmod 755 sapuf 

            fi


            if [ ${USER} = "c4300002" ]
            then

                 mv creaALFA creaALFA_afdb 
                 cp ${DIRINSTAL}/creaALFA .
                 chmod 755 creaALFA 

            fi

            if [ ${USER} = "c4300003" ]
            then

                 mv addRetLinea addRetLinea_afdb 
                 mv C430Reps    C430Reps_afdb 
                 mv creaDerSBF  creaDerSBF_afdb 
                 mv depuraRepsC depuraRepsC_afdb 
                 mv depuraRepsD depuraRepsD_afdb 
                 mv intelarC    intelarC_afdb 
                 mv intelarD    intelarD_afdb 
                 mv repGen      repGen_afdb 

                 cp ${DIRINSTAL}/usr3.tar .
                 tar -xof usr3.tar

                 chmod 755 addRetLinea 
                 chmod 755 C430Reps 
                 chmod 755 creaDerSBF 
                 chmod 755 depuraRepsC 
                 chmod 755 depuraRepsD 
                 chmod 755 intelarC 
                 chmod 755 intelarD 
                 chmod 755 repGen 
         

            fi
        
            if [ ${USER} = "c4300004" ]
            then

                 mv genarchb         genarchb_afdb 
                 mv r1000            r1000_afdb 
                 mv r3000            r3000_afdb 
                 mv r4000            r4000_afdb 
                 mv r4100            r4100_afdb 
                 mv r4200            r4200_afdb 
                 mv r4300            r4300_afdb 
                 mv r5000            r5000_afdb 
                 mv r9999            r9999_afdb 
                 mv validaEstructCDF validaEstructCDF_afdb 

                 cp ${DIRINSTAL}/usr4.tar .
                 tar -xof usr4.tar

                 chmod 755 genarchb 
                 chmod 755 r1000 
                 chmod 755 r3000 
                 chmod 755 r4000 
                 chmod 755 r4100 
                 chmod 755 r4200 
                 chmod 755 r4300 
                 chmod 755 r5000 
                 chmod 755 r9999 
                 chmod 755 validaEstructCDF 

            fi

            if [ ${USER} = "c4300005" ]
            then

                 mv ActRech ActRech_afdb 
                 cp ${DIRINSTAL}/ActRech .
                 chmod 755 ActRech 

                 mv validaErrCDF validaErrCDF_afdb 
                 cp ${DIRINSTAL}/validaErrCDF .
                 chmod 755 validaErrCDF 

           fi

          echo "Archivos copiados... Completo"

           crontab ${DIRAPP}/crontabs/${USER}.cron && echo "Cron de ${USER} Instalado"

#        done

         
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
        echo "Proceso de Desinstalacion iniciado"
        OPC=N
        echo "Presiona S (mayuscula) para continuar"; read OPC
        while [ "${OPC}" != "S" ]
        do
            echo "Tecleo $OPC"
            echo "Presiona S (mayuscula) para continuar"; read OPC
        done 

#        for USER in c4300001 c4300002 c4300003 c4300004 c4300005
#        do

#            echo "Por favor firmarse en el Usuario ${USER} : \c"
#            su - ${USER} -c && echo "Se firmo correctamente"

#            echo "Por favor firmarse en el Usuario ${USER} : \c"
#            exit
#            pbrun ${USER}

            NRT=`echo $USER|awk '{print substr($0,8,1)}'`
            cd ${RUTA[${NRT}]}

            crontab -r && echo "Cron de ${USER} Desinstalado"
            
            if [ ${USER} = "c4300001" ]
            then
                 rm sapuf 
                 mv sapuf_afdb sapuf 
                 rm -R ${DIRINSTAL}
            fi


            if [ ${USER} = "c4300002" ]
            then
                 rm creaALFA
                 mv creaALFA_afdb creaALFA 
            fi

            if [ ${USER} = "c4300003" ]
            then
                 rm addRetLinea
                 rm C430Reps
                 rm creaDerSBF 
                 rm depuraRepsC 
                 rm depuraRepsD 
                 rm intelarC 
                 rm intelarD 
                 rm repGen 
                 rm usr3.tar

                 mv addRetLinea_afdb addRetLinea
                 mv C430Reps_afdb    C430Reps 
                 mv creaDerSBF_afdb  creaDerSBF 
                 mv depuraRepsC_afdb depuraRepsC 
                 mv depuraRepsD_afdb depuraRepsD 
                 mv intelarC_afdb    intelarC 
                 mv intelarD_afdb    intelarD 
                 mv repGen_afdb      repGen 
            fi
        
            if [ ${USER} = "c4300004" ]
            then
                 rm genarchb
                 rm r1000 
                 rm r3000 
                 rm r4000 
                 rm r4100 
                 rm r4200 
                 rm r4300 
                 rm r5000 
                 rm r9999 
                 rm validaEstructCDF 
                 rm usr4.tar

                 mv genarchb_afdb         genarchb 
                 mv r1000_afdb            r1000 
                 mv r3000_afdb            r3000 
                 mv r4000_afdb            r4000 
                 mv r4100_afdb            r4100 
                 mv r4200_afdb            r4200 
                 mv r4300_afdb            r4300 
                 mv r5000_afdb            r5000 
                 mv r9999_afdb            r9999 
                 mv validaEstructCDF_afdb validaEstructCDF 
            fi

            if [ ${USER} = "c4300005" ]
            then
                 rm ActRech 
                 mv ActRech_afdb ActRech 

                 rm validaErrCDF 
                 mv validaErrCDF_afdb validaErrCDF 
           fi

           echo "Programas Restaurados... Completo"

           crontab ${DIRAPP}/crontabs/${USER}.cron && echo "Cron de ${USER} Instalado"

#        done
        
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
  echo "[1] Instalacion de Binarios FortiDB "
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


