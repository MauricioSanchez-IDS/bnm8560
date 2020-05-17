#!/usr/bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: (paths.sh 04 CRO) 
# Procedimiento: ejecutaRespCDF.sh
# Descripción: procesa la respuesta del archivo CDF que envia Master Card     
# Versión y fecha: 1.0
# Autor: 
#             
# Modificacion :
# Autor y fecha:

PATH=$PATH:/opt/c430/000/bin:.
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

#exec 1>>$(paths.sh 05 LOG)/ejecutaRespCDF.log
#exec 2>&1

set -x

PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 05 CRO):$(paths.sh 05 BIN)


# Genera variables de ambiente para manejo de las rutas de envio    
DIR_ARCH2=$(paths.sh 05 RES)
DIR_ARCH=$(paths.sh 05 DEP)
DIR_CARGA=$(paths.sh 05 BIN)
DIR_PARAM=$(paths.sh 05 PAR)
DIR_LOGS=$(paths.sh 05 LOG)
DIR_BACK=$(paths.sh 05 RES)
DIR_TEMP=$(paths.sh 05 TMP)

export DIR_ARCH DIR_BACK DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS DIR_TEMP PATH

# Genera variables de ambiente de Sybase
GE_USER=$(usuario.sh)
#GE_PASSWORD=$(password.sh)
GE_PASSWORD=ojE83CEb
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=ucadmty1

export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME 

#Variables de Sybase
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
USER=$(base.sh)

export SYBASE DSQUERY USER

##### Inicia proceso para validar respuesta de Master Card #####
fecha_proceso=`date '+%Y/%m/%d %H:%M:%S'`
terminaPrograma=0
insertaMTCPRO02=0
fh_horaProceso=`date '+%Y%j%H%M'`
fecha_hoyJuliana=`date '+%Y%j'`
fecha_hoy=`date '+%Y%m%d'`

variable=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -w1200 -i $DIR_CARGA/checaUltEstatus.txt | grep '[0-9]' | egrep -v '\(.*\)'`
checa=`echo $variable | grep -c "|"`
if [ $checa -ne 1 ]
then
  errores="No se pudo consultar la tabla MTCPRO02"
  echo "Fecha proceso:  $fecha_proceso"
  echo "Nombre archivo: "
  echo "Programa:       "
  echo "Error: $errores"
  terminaPrograma=1
else
  nombreLogico=`echo $variable | cut -f2 -d'|'`
  nombreFisico=`echo $variable | cut -f3 -d'|'`
  fecha=`echo $variable | cut -f4 -d'|'`
  estatus=`echo $variable | cut -f5 -d'|'`
  estatusUsu=`echo $variable | cut -f6 -d'|'`
  mensaje=`echo $variable | cut -f7 -d'|'`
  accion=`echo $variable | cut -f8 -d'|'`
  fecha_JulReg=`echo $variable | cut -f9 -d'|' | sed 's/ //g'`
  ref_num1=`echo $variable | cut -f10 -d'|' | awk '{ print $1 }'`
  ref_num2=`echo $variable | cut -f10 -d'|' | awk '{ print $2 }'`
  ref_num="$ref_num1   $ref_num2"
  fh_horaReg=`echo $variable | cut -f11 -d'|'`   

  nombreLogicoIns="$nombreLogico" 
  nombreFisicoIns="$nombreFisico" 
  estatusIns="$estatus"           
  estatusUsuIns="$estatusUsu"     
  mensajeIns="$mensaje"           
  accionIns="$accion"             
  ref_numIns="$ref_num"           

  echo "$nombreLogicoIns"
  echo "$nombreFisicoIns"
  echo "$estatusIns"
  echo "$estatusUsuIns"
  echo "$mensajeIns"
  echo "$accionIns"
  echo "$fecha_JulReg"
  echo "$ref_numIns"

  if [ $fecha_hoyJuliana -lt $fecha_JulReg ]
  then
    errores="La fecha sistema es menor a la fecha del registro en MTCPRO02"
    echo "Fecha proceso:  $fecha_proceso"
    echo "Nombre archivo: "
    echo "Programa:       "
    echo "Error: $errores"
    terminaPrograma=1
  fi
fi


#Valida si existe copia de este proceso ejecutandose
EstaCorriendoProc=`ps -fea | grep -c -f $DIR_PARAM/procRespCDF.list`
echo "Esta Corriendo $EstaCorriendoProc"
if [ $EstaCorriendoProc -eq 1 ] && [ $terminaPrograma -eq 0 ]
then
  if [ $estatus -eq 4 -o $estatus -eq 34 ]
  then
    LimRespCDF=`grep -F lapsoRespCDF $DIR_PARAM/parametros | cut -f2 -d'|'`
    LapsoProceso=`diffTime $fh_horaReg $fh_horaProceso`
    # echo " fh_horaReg    = $fh_horaReg"
    # echo " fh_horaProceso= $fh_horaProceso"
    # echo " LimRespCDF    = $LimRespCDF"
    # echo " LapsoProceso  = $LapsoProceso"
    # echo " EstaCorriendoPro= $EstaCorriendoProc"
    if [ $LapsoProceso -gt $LimRespCDF ]
    then
      insertaMTCPRO02=1
      accionIns=""
      if [ $estatus -eq 4 ]
      then
        estatusIns=11
        estatusUsuIns=8
        mensajeIns='Ya se tardo mucho en procesar respuesta de MC'
      else
        estatusIns=41
        estatusUsuIns=38
        mensajeIns='Ya se tardo mucho en reprocesar respuesta de MC'
      fi
    fi
  fi
  if [ $estatus -eq 5 -o $estatus -eq 35 ]
  then
    LimGeneCDF=`grep -F lapsoGeneCDF $DIR_PARAM/parametros | cut -f2 -d'|'`
    LapsoProceso=`diffTime $fh_horaReg $fh_horaProceso`
    # echo " fh_horaReg    = $fh_horaReg"
    # echo " fh_horaProceso= $fh_horaProceso"
    # echo " LimGeneCDF    = $LimGeneCDF"
    # echo " LapsoProceso  = $LapsoProceso"
    # echo " EstaCorriendoProc= $EstaCorriendoProc"
    if [ $LapsoProceso -gt $LimGeneCDF ]
    then
      insertaMTCPRO02=1
      accionIns=""
      if [ $estatus -eq 5 ]
      then
        estatusIns=14
        estatusUsuIns=6
        mensajeIns='Ya se tardo mucho en generar archivo CDF'
      else
        estatusIns=44
        estatusUsuIns=36
        mensajeIns='Ya se tardo mucho en generar archivo CDF reproceso'
      fi
    fi
  fi
else
  if [ $estatus -eq 4 -o $estatus -eq 5 -o $estatus -eq 34 -o $estatus -eq 35 ] && [ $terminaPrograma -eq 0 ]
  then 
    if [ $fecha_JulReg -lt $fecha_hoyJuliana ]
    then 
      insertaMTCPRO02=1 
    fi
  else
    if [ $terminaPrograma -eq 0 ]
    then
      echo "Entro a ejecuar el programa shell $DIR_CARGA/procRespCDF.sh"
      $DIR_CARGA/procRespCDF.sh
    fi
  fi
fi

if [ $insertaMTCPRO02 -eq 1 ]
then
  echo "insert MTCPRO02          " > $DIR_CARGA/insertEstatus.txt
  echo " (pro_nomLogi            " >> $DIR_CARGA/insertEstatus.txt
  echo " ,pro_nomFisi            " >> $DIR_CARGA/insertEstatus.txt
  echo " ,pro_fecha              " >> $DIR_CARGA/insertEstatus.txt
  echo " ,pro_estatus            " >> $DIR_CARGA/insertEstatus.txt
  echo " ,pro_est_usu            " >> $DIR_CARGA/insertEstatus.txt
  echo " ,pro_mensaje            " >> $DIR_CARGA/insertEstatus.txt
  echo " ,pro_accion             " >> $DIR_CARGA/insertEstatus.txt
  echo " ,pro_ref_num)           " >> $DIR_CARGA/insertEstatus.txt
  echo "values('$nombreLogicoIns'" >> $DIR_CARGA/insertEstatus.txt
  echo "      ,'$nombreFisicoIns'" >> $DIR_CARGA/insertEstatus.txt
  echo "      ,getdate()         " >> $DIR_CARGA/insertEstatus.txt
  echo "      ,$estatusIns       " >> $DIR_CARGA/insertEstatus.txt
  echo "      ,$estatusUsuIns    " >> $DIR_CARGA/insertEstatus.txt
  echo "      ,'$mensajeIns'     " >> $DIR_CARGA/insertEstatus.txt
  echo "      ,'$accionIns'      " >> $DIR_CARGA/insertEstatus.txt
  echo "      ,'$ref_numIns')    " >> $DIR_CARGA/insertEstatus.txt
  echo "go                       " >> $DIR_CARGA/insertEstatus.txt

  checaTabla=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertEstatus.txt`

  if [ "$checaTabla" != "(1 row affected)" ]
  then
    errores="No se puede actualizar la tabla MTCPRO02"
    echo "Fecha proceso:  $fecha_proceso"
    echo "Nombre archivo: $nombreFisicoIns"
    echo "Programa:       "
    echo "Error: $errores"
  fi
fi
