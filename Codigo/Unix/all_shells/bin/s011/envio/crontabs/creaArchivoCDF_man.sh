#!/usr/bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: $(paths.sh 04 CRO)
# Procedimiento: creaArchivoCDF_man.sh
# Descripción: ejecuta los programas para generar el archivo cdf a enviar a MC
# Versión y fecha: 2.0   21/jul/2003
# Autor:  Jose Ramon Gonzalez Diaz (EISSA)
#             
#                BITACORA:            
# Modificacion:SE Corrigen Errores en la Obtencion de la Fecha de Corte 30/Mar/2004 Jose Alberto Garcia
# Modificacion:SE Corrigen Errores de Sintaxis 30/Mar/2004 Jose Alberto Garcia
# Modificacion:SE Adiciona Validacion para Generacion del CDF DIARIO 30/May/2004 Jose Alberto Garcia
# Modificacion:SE Modifican Mensajes de Error en la tabla MTCPRO02  3/jun/2004 Jose Alberto Garcia
# Modificacion:SE Se adiciona variable v5000 30/Mar/2004 Jose Alberto Garcia
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC


echo `date`
variable_fecha=`date`


PATH=$PATH:/opt/c430/000/bin:.
export PATH

# Variables de Sybase produccion
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
SYBASE_OCS=OCS-15_0

export  SYBASE DSQUERY 
export SYBASE_OCS

#exec 1>>$(paths.sh 04 LOG)/creaArchivoCDF_man.log
#exec 2>&1

set -x

PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 04 CRO):$(paths.sh 04 BIN)
export PATH
export LD_LIBRARY_PATH=${LD_LIBRARY_PATH}:${SYBASE}/${SYBASE_OCS}/lib:/lib64

# Genera variables de ambiente para manejo de las rutas de envio en produccion
DIR_ARCH2=$(paths.sh 04 RES)
DIR_ARCH=$(paths.sh 04 DEP)
DIR_CARGA=$(paths.sh 04 BIN)
DIR_PARAM=$(paths.sh 04 PAR)
DIR_LOGS=$(paths.sh 04 LOG)
DIR_BACK=$(paths.sh 04 RES)
DIR_TEMP=$(paths.sh 04 TMP)

export DIR_ARCH DIR_BACK DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS DIR_TEMP PATH

#Genera variables de ambiente de Sybase
GE_USER=$(usuario.sh)        
#GE_PASSWORD=$(password.sh)  
GE_PASSWORD=ojE83CEb
GE_DBASE=$(base.sh)       
GE_SERVER=$(servidor.sh)     
GE_HOSTNAME=`uname -n`

export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME 


# La variable fechacorte se obtine de la fecha del sistema  
# se enviara por corte y variables prefijo, banco,
# se utilizan en esta parte del proceso.

# Las variables fechainicial y fechafinal son para ser utilizadas
# en la generacion del archivo para envio diario 

# Se crea una variable llamada v5000 para indicar como se genera el
# archivo CDF.

# Si la varaible v5000 lleva un 1 indicara que el archivo se genera
# normalmente  se incluyen los registros 1000, 4000, 4100, 4200,
# 4300, 5000, 9999, si la  variable v5000 lleva un 0 indicara que solo se
# incluyan en el archivo a generar los registros que se regeneraron
# que es el proceso diario.

v5000=0
vgenarch=0
lim=0

# Se crean las variables para indicar el prefijo, banco, fecha de corte
# si esta en necesaria se pasara como argumento de este programa.

prefijo=$1
banco=$2
empresa=$3

echo "Inicio del proceso para la generacion del archivo CDF"
fechaproceso=`date`
echo $fechaproceso


# Se obtiene la fecha del sistema
 consecutivo=1
 ayo=`date +%Y`
 fecha=`date +%Y%m%d`
 fechados=`date +%y%m%d`
 fechalogico=`date +%Y%m%d`
 nombrelogico=$fechalogico
 nombrearch='OS011CDF.F'          
 nomarchcomp=${nombrearch}${fechados}

 echo $ayo
 echo $fecha
 echo $fechados
 echo $fechalogico
 echo $nombrelogico
 echo $nombrearch
 echo $nomarchcomp

banderasigue=0

fechacorte=0   

if [ $banderasigue -eq 0 ]
then
#  espacio=`bdf 2>/dev/null | grep "/opt/c430/000$" | tr -s ' ' | cut -d' ' -f4`
  espacio=`df -k . | grep "/" | tr -s ' ' | cut -d' ' -f4`
  espacio=`echo "${espacio}/2" | bc`
  espacio=`echo "${espacio}*1024" | bc`
  espacio=`echo "${espacio}-1024" | bc`
  echo "$espacio"
  tamano2=52428800
  mayor=`expr $espacio \< $tamano2`
  echo "$mayor"
  if [ $mayor -eq 0 ]
  then
    echo "existe suficiente espacio"
    banderasigue=0
  else
    echo "$espacio"
    banderasigue=1
    errores="No existe espacio suficiente para la aplicacion que genera el archivoCDF"
    archivo="creaArchivoCDF.sh"
  fi
fi


while [ -f ${DIR_ARCH}/${nomarchcomp} ]
do   
   if [ -f ${DIR_ARCH}/${nomarchcomp}_${consecutivo} ];then
      let consecutivo=consecutivo+1  
   else
      mv ${DIR_ARCH}/${nomarchcomp} ${DIR_ARCH}/${nomarchcomp}_${consecutivo} 
      mv ${DIR_ARCH}/43002s01.${nomarchcomp} ${DIR_ARCH}/43002s01.${nomarchcomp}_${consecutivo}
      mv $DIR_ARCH/control${fechados}.ctrl $DIR_ARCH/control${fechados}_${consecutivo}.ctrl
      echo "Se renombro ${nomarchcomp} como ${nomarchcomp}_${consecutivo}"
   fi
done


# Procesos para generar informacion para formar los registro  
# Recuerda incluir validacion de las fechas inicial y final   
# para el proceso de generado diario                          

fechainicial=$4
fechafinal=$5

if [ $banderasigue -eq 0 ]
then
  echo "Entro generar archivo CDF"
  echo $nombrelogico $nomarchcomp $fechacorte $fechainicial $fechafinal
  
#  if [ $banderacorte -eq 0 ]
#  then
    echo "$DIR_CARGA/r1000 $nomarchcomp"
    $DIR_CARGA/r1000 $nomarchcomp
    if [ $? -gt 0 ] 
    then
    # Se ejecuto mal el programa r1000.c
      banderasigue=1
      archivo="r1000"
      echo "Se produjo un error en el programa creaArchivoCDF-r1000"
    else
      echo " select '|'+fileReferenceNumber+'|' " > $DIR_CARGA/numrefar.txt
      echo " from REG1000 " >> $DIR_CARGA/numrefar.txt
      echo "go" >> $DIR_CARGA/numrefar.txt
      numrefarch=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/numrefar.txt | sed '1d' | sed '1d;$d' `
      numrefarchivo=`echo "$numrefarch" | cut -f2 -d'|'`
      echo "numero de referencia: $numrefarchivo"
      banderasigue=0
    fi                                                            
#  fi

#  Se Quita Validacion para Corte y Diario, Diario Viajan Todos los Registros  
#  if [ $banderasigue -eq 0 -a $v5000 -eq 1 ]  #Solo si es corte se incluyen 3000, 4000, 4100, 4200, 4300
  if [ $banderasigue -eq 0 ]  
  then                      
    echo "$DIR_CARGA/r3000 $nomarchcomp"
    $DIR_CARGA/r3000 $nomarchcomp
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r3000.c  
      banderasigue=1
      archivo="r3000"
      echo "Se produjo un error en el programa creaArchivoCDF-r3000"
    fi
  fi

  if [ $banderasigue -eq 0 ]                                           
  then
    echo "$DIR_CARGA/r5000 $nomarchcomp    $prefijo    $banco     $empresa     $fechainicial    $fechafinal 0"
#    $DIR_CARGA/r5000 $nomarchcomp    $prefijo    $banco     $empresa     $fechainicial    $fechafinal 0
    gdb $DIR_CARGA/r5000
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r5000.c
      banderasigue=1                                                   
      archivo="r5000" 
      echo " $DIR_CARGA/r5000 $nomarchcomp $prefijo $banco $empresa $fechainicial $fechafinal 0"
      echo " -$nomarchcomp-    -$prefijo-      -$banco-       - $empresa-   -$fechainicial- -$fechafinal- 0 "
      echo "Se produjo un error en programa creaArchivoCDF-r5000(Transacciones)"     
    fi                                                                 
  fi                                                                   

  if [ $banderasigue -eq 0 ]                                      
  then                                                            
    echo "$DIR_CARGA/r4300 $nomarchcomp $prefijo $banco $empresa 0 0 $fechacorte"
    $DIR_CARGA/r4300 $nomarchcomp    $prefijo        $banco     $empresa      0        0        $fechacorte
    if [ $? -gt 0 ]                                               
    then                                                          
      # Se produjo un error en el programa r4300.c                
      banderasigue=1                                              
      archivo="r4300"                                             
      echo "Se produjo un error en programa creaArchivoCDF-r4300"
    fi                                                            
  fi                                                               

  if [ $banderasigue -eq 0 ]
  then                      
    echo "$DIR_CARGA/r4100 $nomarchcomp $prefijo $banco $empresa"
    $DIR_CARGA/r4100 $nomarchcomp $prefijo $banco $empresa
      if [ $? -gt 0 ] 
      then
        # Se produjo un error en el programa r4100.c
        banderasigue=1
        archivo="r4100"
        echo "Se produjo un error en programa creaArchivoCDF-r4100"
      fi
    fi
    
  if [ $banderasigue -eq 0 ] 
  then                       
    echo "$DIR_CARGA/r4000 $nomarchcomp $prefijo $banco $empresa"
    $DIR_CARGA/r4000 $nomarchcomp $prefijo $banco $empresa
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r4000.c
      banderasigue=1
      archivo="r4000" 
      echo "Se produjo un error en programa creaArchivoCDF-r4000"  
    fi
  fi
    
  if [ $banderasigue -eq 0 ]
  then                     
    echo "$DIR_CARGA/r4200 $nomarchcomp $prefijo $banco $empresa"
    $DIR_CARGA/r4200 $nomarchcomp $prefijo $banco $empresa
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r4200.c
      banderasigue=1
      archivo="r4200"
      echo "Se produjo un error en programa creaArchivoCDF-r4200"
    fi
  fi

  if [ $banderasigue -eq 0 ]
  then                     
    $DIR_CARGA/r9999 $nomarchcomp
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r9999.c
      banderasigue=1
      archivo="r9999" 
      echo "Se produjo un error en programa creaArchivoCDF-r9999" 
    fi
  fi
  
  if [ $banderasigue -eq 0 ]
  then                     
    echo "$DIR_CARGA/genarchb ${nombrelogico} ${nomarchcomp} ${vgenarch}"
    $DIR_CARGA/genarchb ${nombrelogico} ${nomarchcomp} ${vgenarch}
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa genarchb.c
      banderasigue=1
      archivo="genarchb"
      echo "Se produjo un error en programa genarchb"
    fi
  fi
 
    # Programa para validar el contenido del archivo CDF
    #if [ $banderasigue -eq 0 ]
    #then                     
    #  echo 'Espere ejecutando programa validaArchivoCDF'
    #  $DIR_CARGA/validaArchivoCDF $DIR_TEMP/${nomarchcomp}
    #  if [ $? -gt 0 ] 
    #  then
    #    # Se produjo un error en el programa validaArchivoCDF
    #    banderasigue=1
    #    archivo="validaArchivoCDF"
    #    errores="Se produjo un error en el programa validaArchivoCDF"
    #  fi
    #fi
    
    # Programa para revisar la estructura del archivo, dependencia entre
    # registros, consecutivos, este programa debera llevar un parametro que
    # es el nombre del archivo.
    # Se ejecuta el programa validaEstructuraCDF
    if [ $banderasigue -eq 0 ]
    then                     
      echo 'Espere ejecutando programa validaEstrucCDF'
      echo "$DIR_CARGA/validaEstructCDF $DIR_TEMP/${nomarchcomp}"
      $DIR_CARGA/validaEstructCDF $DIR_TEMP/${nomarchcomp}
      if [ $? -gt 0 ] 
      then
        # Se produjo un error en el programa validaEstructCDF  
        banderasigue=1
        archivo="validaEstructCDF"
        echo "Se produjo un error en el programa validaEstructCDF"  
      fi 
    fi

    if [ $banderasigue -eq 1 ] 
    then
       echo "Fecha proceso:$nombrelogico"
       echo "NombreArchivo:$nomarchcomp"
       echo "Programa: $archivo"
       echo "Error: $errores"
       fecha_proceso=$nombrelogico
       nombre_archivo=$nomarchcomp 
       estatus=6 
       estatuspro=6
       echo ${errores:-"Error al generar Archivo CDF"}
       echo "Avisar a ingenieria"
       exit
    fi

    echo `mv $DIR_TEMP/${nomarchcomp} $DIR_ARCH/${nomarchcomp}` 
    echo "touch $DIR_ARCH/control${fechados}.ctrl"
    touch $DIR_ARCH/control${fechados}.ctrl
    echo "Termino satisfactoriamente la creacion del archivo CDF $fechacortepro"
    fechaproceso=`date`                                         
    echo $fechaproceso                                          
    fecha_proceso=$nombrelogico
    nombre_archivo=$nomarchcomp 
    estatus=0 
    estatuspro=0
    echo "Archivo CDF se genero correctamente "
    echo "$fecha_proceso"
    echo "$nombre_archivo"
    echo "$estatus"
    echo "$estatuspror"
    echo "$mensaje"
    echo "$fechacortepro"
    echo "$numrefarchivo" 
    
    $DIR_CARGA/envioFTP.sh 

echo "Comence "$variable_fecha
echo "Termine "`date`

 exit
fi

