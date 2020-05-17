#!/bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 03 CRO)
# Procedimiento: C430EjReC.sh
# Descripción:
# Versión y fecha: 1.0
# Autor: YMF    02/02/08
# Modificaciones:
# proposito: Verifica si llegaron archivos del S111 de L-2 y
#            Ejecuta reportes de Credito
# Modificacion :  Jun / 2012  --- Hp - RSP -  Migracion 
#set -x
#locale

LD_LIBRARY_PATH=/optware/sybase/ase157sp104/ASE-15_0/lib:/optware/sybase/ase157sp104/DataAccess64/ODBC/lib:/optware/sybase/ase157sp104/DataAccess/ODBC/lib:/optware/sybase/ase157sp104/OCS-15_0/lib:/optware/sybase/ase157sp104/OCS-15_0/lib3p64:/optware/sybase/ase157sp104/OCS-15_0/lib3p::/opt/c046/105/lib

export LD_LIBRARY_PATH

PATH=$PATH:/opt/c430/000/bin
export PATH
# Variables de Sybase
	SYBASE=$(sybase.sh)
	DSQUERY=$(servidor.sh)
        SYBASE_OCS=${SYBASE}/OCS-15_0
#	LD_LIBRARY_PATH=${LD_LIBRARY_PATH}:${SYBASE_OCS}/lib
export SYBASE DSQUERY
export SYBASE_OCS
#DVD descomentar las 2 lineas siguientes
exec 1>>$(paths.sh 03 LOG)/C430EjReC.log
exec 2>>$(paths.sh 03 LOG)/C430EjReCerror.log

DIR_ARCH2=$(paths.sh 03 RES)
DIR_CRON3=$(paths.sh 03 CRO)
DIR_ARCH=$(paths.sh 03 DEP)
DIR_RES7=$(paths.sh 07 RES)
DIR_CARGA=$(paths.sh 03 BIN)
DIR_PARAM=$(paths.sh 03 PAR)
DIR_LOGS=$(paths.sh 03 LOG)
DIR_TEMP=$(paths.sh 03 TMP)
DIR_BIN=$(paths.sh 01 BIN)

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 03 CRO)
export DIR_ARCH DIR_TEMP DIR_CARGA DIR_CRON3 DIR_PARAM DIR_ARCH2 DIR_LOGS PATH

GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=`uname -n`
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME


HORA=$(date '+%H:%M:%S')


# Verifica que no haya otros procesos levantados
# ps -fe | grep -v grep | grep C430EjReC | grep ksh | grep -c C430EjReC
## DVD
##programa=`ps -fe | grep -v grep | grep C430EjReC | grep ksh | grep -c C430EjReC `
programa=`ps -fe | awk 'BEGIN {a=0}; ($9 ~ /C430EjReC/){a++}; END {print a}'`
#echo "- Numero de procesos levantados $programa\n"
if [ $programa -ne 1 ] #Se sale si hay otro proceso levantado
then
        #echo "- Salida: Hay otro proceso levantado\n"
        exit 0
fi

DIAHOY=$(date '+%d')
fechaHOY=$(date '+%Y%m%d')

#Verifica si ya corrio reportes de Credito de HOY
generoRepCred=`$DIR_CARGA/C430RevisaCredHoy.sh $fechaHOY`
if [ generoRepCred -eq 1 ]
then
  #termina porque ya genero los reportes de hoy
  echo " termina porque ya genero reportes de hoy"
  exit 0
fi

if [ $DIAHOY -eq 1 ] #los dias primeros de cada mes tiene que depurar deposito
then
  revisaDepHoy=`$DIR_CARGA/C430RevisaDepuHoy.sh $fechaHOY`
  if [ $revisaDepHoy -eq 0 ]
  then
    # Verifica si esta corriendo el proceso de debito
    programa=`ps -fe | grep -v grep | grep C430EjReD | grep ksh | grep -c C430EjReD `
    if [ $programa -gt 0 ]
    then
        # SI esta corriendo debito solo elimina lo del dia de hoy de credito
        $DIR_CRON3/depuraRepsC.sh
        programa=`$DIR_CARGA/C430InsertaDepuHoy.sh $fechaHOY`
        if [ $programa -eq 0 ]
        then
           echo "No pudo grabar en MTCPRO03 que ya corrio la depuracion de Repo"
        fi
    else
       generoRepDeb=`$DIR_CARGA/C430RevisaDebHoy.sh $fechaHOY`
       if [ generoRepDeb -eq 1 ]
       then
        #solo depura lo que tiene fecha diferente de HOY
        $DIR_CRON3/depuraRepsC.sh
        $DIR_CRON3/depuraRepsD.sh
        programa=`$DIR_CARGA/C430InsertaDepuHoy.sh $fechaHOY`
        if [ $programa -eq 0 ]
        then
           echo "No pudo grabar en MTCPRO03 que ya corrio la depuracion de Repo"
        fi
       else
        #elimina todo lo que esta en deposito NO ha corrido ni credito ni debito
        rm -fR /opt/c430/000/bin/inte/envio/deposito/*
        programa=`$DIR_CARGA/C430InsertaDepuHoy.sh $fechaHOY`
        if [ $programa -eq 0 ]
        then
           echo "No pudo grabar en MTCPRO03 que ya corrio la depuracion de Repo"
        fi
       fi
    fi #termina verifica Rep Debito
  fi # si ya se depuro hoy, ya no intenta depurar
fi


fechaUnDiaAntes=`${DIR_CRON3}/SumResFec.sh ${fechaHOY} D -1` #resta 1 dia a hoy
echo " fechaUnDiaAntes = $fechaUnDiaAntes "
fechaMD=`echo $fechaUnDiaAntes | cut -c5-8`

fecha4diasAtras=`${DIR_CRON3}/SumResFec.sh ${fechaHOY} D -4` #resta 4 dias a hoy
echo " fecha4diasAtras = $fecha4diasAtras "

if [ -f $DIR_RES7/EHIS$fechaMD -a -f $DIR_RES7/EPLA$fechaMD -a -f $DIR_RES7/ETHS$fechaMD -a -f $DIR_RES7/EHIH$fechaMD ]
then
var1=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE -X<<EOF
select distinct pro_nomarch from MTCPRO01
where
(pro_nomarch="EHIS$fechaMD" and pro_estatus=0) or
(pro_nomarch="EHIH$fechaMD" and pro_estatus=0) or
(pro_nomarch="EPLA$fechaMD" and pro_estatus=0) or
(pro_nomarch="ETHS$fechaMD" and pro_estatus=0)
go
EOF`
echo "var1 $var1"
var1=`echo $var1 | grep "(4 rows affected)" | wc -l`
if [ $var1 -eq 1 ] #si estan los cuatro archivos
then
  # Hace un delay de 30 mins para empezar a generar reportes
  usleep 1800000000

  #SI LLEGO LA CARGA INICIA A GENERAR REPORTES CREDITO
  echo "INICIA PROCESO REPORTES CREDITO $fechaHOY $HORA "
  fechaQueRevisa=$fecha4diasAtras
  contador=0
  segeneroAlgo=0
  while [ $contador -lt 5 ]
  do
    let contador=contador+1
    faltaRep=`$DIR_CARGA/C430RevisaCredHoy.sh $fechaQueRevisa`
    if [ $faltaRep -eq 0 ]
    then
      segeneroAlgo=1
      #Ejecuta reportes con fecha fechasAnteriores
      fechaProceso=`${DIR_CRON3}/SumResFec.sh ${fechaQueRevisa} D -1` #menos1dia
      echo "       $DIR_CRON3/C430Reps.sh 0000 DAILY $fechaProceso $fechaProceso $fechaQueRevisa 1 99999 25 25 C"
      $DIR_CRON3/C430Reps.sh 0000 DAILY $fechaProceso $fechaProceso $fechaQueRevisa 1 99999 25 25 C
      DIA=`echo $fechaQueRevisa | cut -c7-8`
      MES=`echo $fechaQueRevisa | cut -c5-6`
      ANIO=`echo $fechaQueRevisa | cut -c1-4`
      DCORTE=`expr "$DIA" - 1` #tener en cuenta que no debe haber corte=1
      CORTE=0
      CORTE=`grep ^$DCORTE$ ${DIR_CRON3}/DiasCorteCredito.txt | wc -l`
      if [ $CORTE -eq 1 ]
      then
        fechaCorte=`echo $fechaProceso | cut -c5-8`
        echo "$DIR_CRON3/C430Reps.sh $fechaCorte CYCLE 00000000 00000000 $fechaQueRevisa 1 99999 2 7 C"
        $DIR_CRON3/C430Reps.sh $fechaCorte CYCLE 00000000 00000000 $fechaQueRevisa 1 99999 2 7 C

        echo "$DIR_CRON3/C430Reps.sh $fechaCorte CYCLE 00000000 00000000 $fechaQueRevisa 1 99999 18 26 C"
	$DIR_CRON3/C430Reps.sh $fechaCorte CYCLE 00000000 00000000 $fechaQueRevisa 1 99999 18 26 C

#        echo " $DIR_CRON3/procRepEsp_man.sh $fechaQueRevisa               "
#        $DIR_CRON3/procRepEsp_man.sh $fechaQueRevisa
        echo " $DIR_CRON3/genDerSBF_man.sh 0 0 0 $MES $ANIO  "
        $DIR_CRON3/genDerSBF_man.sh 0 0 0 $MES $ANIO
      fi
    else
      echo "ya se genero esta fecha $fechaQueRevisa"
    fi # fin del if Ejecuta reportes con fecha $fechaQueRevisa
    fechaQueRevisa=`${DIR_CRON3}/SumResFec.sh ${fechaQueRevisa} D 1` #suma1dia
  done  #termina de revisar si habia dias pendientes incluyendo hoy
  if [ $segeneroAlgo -eq 1 ]
  then
      echo "$DIR_CRON3/addRetLinea.sh         "
      $DIR_CRON3/addRetLinea.sh
      HORA1=$(date '+%H:%M:%S')
      fechaActual=$(date '+%Y%m%d')
      if [ $fechaHOY -eq $fechaActual ] #Si ya cambio de dia ya no lanza intelar
      then
        echo "$DIR_CRON3/C430EnviaRepInt.sh     "
        $DIR_CRON3/C430EnviaRepInt.sh
        echo "$DIR_CRON3/intelarC.sh    "
        $DIR_CRON3/intelarC.sh
        fechaQueRevisa=$fecha4diasAtras
        contador=0
        while [ $contador -lt 5 ]
        do
          let contador=contador+1
          faltaRep=`$DIR_CARGA/C430RevisaCredHoy.sh $fechaQueRevisa`
          if [ $faltaRep -eq 0 ]
          then
            programa=`$DIR_CARGA/C430InsertaCredHoy.sh $fechaQueRevisa`
            if [ $programa -eq 0 ]
            then
              echo "No pudo grabar en MTCPRO03 que ya corrio Reportes Credito $fechaQueRevisa "
            fi
          fi
          fechaQueRevisa=`${DIR_CRON3}/SumResFec.sh ${fechaQueRevisa} D 1` #suma 1 dias a hoy
        done
        HORA1=$(date '+%H:%M:%S')
        fechaActual=$(date '+%Y%m%d')
        echo "TERMINA PROCESO REPORTES CREDITO $fechaActual $HORA1 "
      else
        HORA1=$(date '+%H:%M:%S')
        fechaActual=$(date '+%Y%m%d')
        echo "Ya no lanza intelar $HORA $HORA1"
        echo "Ya no lanza intelar diaInicial $fechaHOY y diaActual $fechaActual"
        echo "TERMINA PROCESO REPORTES CREDITO $fechaActual $HORA1 "
      fi
  fi
  else
    echo " $fechaHOY$HORA NO estan registrados con estatus de 0 los cuatro archivos en MTCPRO01"
  fi
else
  echo "$fechaHOY$HORA NO estan los 4 archivos de hoy EHIS,EHIH,EPLA Y ETHS"
  echo "$fechaHOY$HORA fecha -4 dias= $fecha4diasAtras"
fi

