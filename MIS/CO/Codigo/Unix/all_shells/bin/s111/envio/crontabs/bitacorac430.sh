#!/bin/ksh
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430                                                                
# Directorio:                            
# Procedimiento: bitacorac430.sh
# Descripcion: crea tres archivos de bitacora diaria:
#              bitacora de violaciones (c430MMDDv.txt)
#              bitacora de admin. de usuarios (c430MMDDa.txt)
#              bitacora de transacciones (c430MMDDt.txt) 
# Version y fecha: 1.0   6/dic/2002                                            
# Autor:  Ing. Jose Ramon Gonzalez Diaz (EISSA)                                
#                                                                              
# Modificacion :                                                               
# Autor y fecha:                                                               

PATH=$PATH:/opt/c430/000/bin
export PATH
#SYBASE_OCS=OCS-15_5
SYBASE_OCS=OCS-15_0
export SYBASE_OCS


exec 1>>$(paths.sh 06 LOG)/bitacorac430.log
exec 2>&1

#PATH=$PATH:/opt/sybase125/OCS-15_5/bin:
PATH=$PATH:/optware/sybase/ase157sp104/OCS-15_0/bin:

# Genera variables de ambiente para manejo de las rutas de envio produccion y pruebas desarrollo    
export PATH

DIR_ARCH=$(paths.sh 06 DEP)
DIR_CARGA=$(paths.sh 06 BIN)
DIR_LOGS=$(paths.sh 06 LOG)
DIR_PARAM=$(paths.sh 06 PAR)
DIR_TEMP=$(paths.sh 06 TMP)
GE_SERVER=$(servidor.sh)
GE_USER="$(usuario.sh)"
GE_PASSWORD="$(password.sh)"

export DIR_ARCH DIR_CARGA DIR_PARAM DIR_LOGS GE_SERVER DIR_TEMP GE_USER GE_PASSWORD

#Variables de sybase
SYBASE=$(sybase.sh)
DSQUERY=$(base.sh) 

export SYBASE DSQUERY 
   
banderasigue=0

# Se obtiene la fecha del sistema      
 mes=`date +%m`
 dia=`date +%d`
 fecha=$mes$dia

 echo "Dia:$dia"
 echo "Mes:$mes"
 echo "Fecha:$fecha"

 echo "Espere un momento se estan generando los archivos de Bitacora..."

$DIR_CARGA/actnombres.sql $GE_USER $GE_PASSWORD $GE_SERVER > $DIR_CARGA/resactnombres.txt
resultado=`grep -c "rows affected" $DIR_CARGA/resactnombres.txt`
echo "El resultado de la actualizacion es: $resultado"
if [ $resultado -gt 0 -o $resultado -eq 0 ]
then
  echo "Entro al if del resulado actualiza nombres"
  resultado=0
  # Consulta Administracion de Usuarios
  $DIR_CARGA/adminusu.sql $GE_USER $GE_PASSWORD $GE_SERVER > $DIR_CARGA/resadminusu.txt
  resultado=`grep -c "rows affected" $DIR_CARGA/resadminusu.txt`
  echo "El resultado de la consulta de admon Usarios es:$resultado"
  if [ $resultado -gt 0 ]
  then
    echo "Si hubo registros en admon Usuarios"
    banderasigue=1
    banderasigueadmusu=1
    resultado=0
  else
    echo "No hubo registros en admon Usuarios"
    touch $DIR_ARCH/c430${fecha}a.txt
    resultado=0
  fi

  #Consulta Transacciones
  $DIR_CARGA/transacc.sql $GE_USER $GE_PASSWORD $GE_SERVER > $DIR_CARGA/restransacc.txt
  resultado=`grep -c "rows affected" $DIR_CARGA/restransacc.txt`
  echo "El resultado de la consulta de transacciones es:$resultado"
  if [ $resultado -gt 0 ]                            
  then                                               
    echo "Si hubo registros en Transacciones"
    banderasigue=1
    banderasiguetran=1
    resultado=0
  else                             
    echo "No hubo registros en Transacciones"
    touch $DIR_ARCH/c430${fecha}t.txt                                  
    resultado=0
  fi                     

  #Consulta de Violaciones                            
  $DIR_CARGA/violacion.sql $GE_USER $GE_PASSWORD $GE_SERVER > $DIR_CARGA/resviolacion.txt
  resultado=`grep -c "rows affected" $DIR_CARGA/resviolacion.txt`
  echo "El resultado de la consulta de violaciones es:$resultado"
  if [ $resultado -gt 0 ]                            
  then                                               
    echo "Si hubo registros en violaciones"
    banderasigue=1
    banderasigueviola=1
    resultado=0
  else
    echo "No hubo registros en violaciones"
    touch $DIR_ARCH/c430${fecha}v.txt                                   
    resultado=0
  fi

  if [ $banderasigue -gt 0 ]
  then
    echo "Entro al if del bcp"
    
    if [ $banderasigueadmusu -eq 1 ]
    then
      bcp M111..mtcbitadmusers out $DIR_ARCH/salidac430${fecha}a.txt -c -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER
    `sed -e "s/	/;/g" $DIR_ARCH/salidac430${fecha}a.txt > $DIR_ARCH/c430${fecha}a.txt`
    fi
    
    if [ $banderasiguetran -eq 1 ]
    then
      bcp M111..mtcbittransacc out $DIR_ARCH/salidac430${fecha}t.txt -c -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER
    `sed -e "s/	/;/g" $DIR_ARCH/salidac430${fecha}t.txt > $DIR_ARCH/c430${fecha}t.txt`
    fi
    
    if [ $banderasigueviola -eq 1 ]
    then
      bcp M111..mtcbitviolacion out $DIR_ARCH/salidac430${fecha}v.txt -c -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER
     `sed -e "s/	/;/g" $DIR_ARCH/salidac430${fecha}v.txt > $DIR_ARCH/c430${fecha}v.txt`
     fi

    $DIR_CARGA/borratablas.sql $GE_USER $GE_PASSWORD $GE_SERVER > $DIR_CARGA/resborratablas.txt

    resultado=`grep -c "Cannot drop the table" $DIR_CARGA/resborratablas.txt`
    echo "El resultado del borrado e las tablas es:$resultado"               
    if [ $resultado -gt 0 ]                                                  
    then                                                                     
      echo "No se borraron las tablas, porque no existen"                    
    else                                                                     
      echo "Si se borraron las tablas"                                       
    fi                                                                       

    rm $DIR_CARGA/res*.txt
    rm $DIR_ARCH/salida*.txt

    # echo "Se esta conectando al host de envio de archivos"
    # echo "Se estan transmitiendo los archivos de BITACORA"              
    # /usr/bin/ftp -i -v -n <<EOF
    # open 10.200.105.242                                               
    # user s111crec c43008
    # cd ..
    # cd deposito
    # ascii
    # mput c430*.txt
    # bye
    # EOF
  fi # Fin del if de banderasigue
fi # fin de actualiza nombres
