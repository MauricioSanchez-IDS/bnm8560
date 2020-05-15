#!/bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 03 CRO)
# Procedimiento: C430EjReD.sh
# Descripción:
# Versión y fecha: 1.0
# Autor: YMF    02/02/08
# Modificaciones:
# proposito: Verifica si llegaron archivos del S111 de L-1 y
#            Ejecuta reportes de Debito
# Modificacion : Jun / 2012 --- HP - RSP --- Migracion B11.23
# set -x
PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS
# DVD Descomentar las siguientes 2 lineas, RSP se descomentan 
exec 1>>$(paths.sh 03 LOG)/C430EjReD.log
exec 2>>$(paths.sh 03 LOG)/C430EjReDerror.log


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


# Variables de Sybase
	SYBASE=$(sybase.sh)
	DSQUERY=$(servidor.sh)
export SYBASE DSQUERY

HORA=$(date '+%H:%M:%S')


# Verifica que no haya otros procesos levantados
#ps -fe | grep -v grep | grep C430EjReD | grep ksh | grep -c C430EjReD
##DVD
##programa=`ps -fe | grep -v grep | grep C430EjReD | grep ksh | grep -c C430EjReD `
programa=`ps -fe | awk 'BEGIN {a=0}; ($9 ~ /C430EjReC/){a++}; END {print a}'`
#echo "- Numero de procesos levantados $programa\n"
if [ $programa -ne 1 ] #Se sale si hay otro proceso levantado
then
        #echo "- Salida: Hay otro proceso levantado\n"
        exit 0
fi

DIAHOY=$(date '+%d')
fechaHOY=$(date '+%Y%m%d')

#Verifica si ya corrio reportes de Debito de HOY
generoRepDeb=`$DIR_CARGA/C430RevisaDebHoy.sh $fechaHOY`
if [ generoRepDeb -eq 1 ]
then
  #termina porque ya genero los reportes de hoy
  echo " termina porque ya genero reportes Debitode hoy $DIAHOY $fechaHOY"
  exit 0
fi

fechaUnDiaAntes=`${DIR_CRON3}/SumResFec.sh ${fechaHOY} D -1` #resta 1 dia a hoy
fechaMD=`echo $fechaUnDiaAntes | cut -c5-8`

fecha4diasAtras=`${DIR_CRON3}/SumResFec.sh ${fechaHOY} D -4` #resta 4 dias a hoy

if [ -f $DIR_RES7/DHST$fechaMD -a -f $DIR_RES7/DPLS$fechaMD -a -f $DIR_RES7/DTAR$fechaMD -a -f $DIR_RES7/DHEA$fechaMD ]
then
var1=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SEVER -D$GE_BASE <<EOF
select distinct pro_nomarch from MTCPRO01
where
(pro_nomarch="DHST$fechaMD" and pro_estatus=0) or
(pro_nomarch="DHEA$fechaMD" and pro_estatus=0) or
(pro_nomarch="DPLS$fechaMD" and pro_estatus=0) or
(pro_nomarch="DTAR$fechaMD" and pro_estatus=0)
go
EOF`
echo "var1 $var1"
var1=`echo $var1 | grep "(4 rows affected)" | wc -l`
if [ $var1 -eq 1 ] #si estan los cuatro archivos
then
  #SI LLEGO LA CARGA INICIA A GENERAR REPORTES DEBITO
  echo "INICIA PROCESO REPORTES DEBITO $fechaHOY $HORA "
  fechaQueRevisa=$fecha4diasAtras
  contador=0
  segeneroAlgo=0
  while [ $contador -lt 5 ]
  do
    let contador=contador+1
    faltaRep=`$DIR_CARGA/C430RevisaDebHoy.sh $fechaQueRevisa`
    if [ $faltaRep -eq 0 ]
    then
      DIA=`echo $fechaQueRevisa | cut -c7-8`
      MES=`echo $fechaQueRevisa | cut -c5-6`
      ANIO=`echo $fechaQueRevisa | cut -c1-4`
      DCORTE=`expr "$DIA" - 1` #tener en cuenta que no debe haber corte=1
      CORTE=0
      CORTE=`grep ^$DCORTE$ ${DIR_CRON3}/DiasCorteDebito.txt | wc -l`
      if [ $CORTE -eq 1 ]
      then
        segeneroAlgo=1
        fechaProceso=`${DIR_CRON3}/SumResFec.sh ${fechaQueRevisa} D -1` #menos1dia
        fechaCorte=`echo $fechaProceso | cut -c5-8`
        echo "$DIR_CRON3/C430Reps.sh $fechaCorte CYCLE 00000000 00000000 $fechaQueRevisa 1 99999 18 26 D"
        $DIR_CRON3/C430Reps.sh $fechaCorte CYCLE 00000000 00000000 $fechaQueRevisa 1 99999 18 26 D
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
        echo "$DIR_CRON3/intelarD.sh    "
        $DIR_CRON3/intelarD.sh
        fechaQueRevisa=$fecha4diasAtras
        contador=0
        while [ $contador -lt 5 ]
        do
          let contador=contador+1
          DIA=`echo $fechaQueRevisa | cut -c7-8`
          DCORTE=`expr "$DIA" - 1` #tener en cuenta que no debe haber corte=1
          CORTE=0
          CORTE=`grep ^$DCORTE$ ${DIR_CRON3}/DiasCorteDebito.txt | wc -l`
          if [ $CORTE -eq 1 ]
          then
            faltaRep=`$DIR_CARGA/C430RevisaDebHoy.sh $fechaQueRevisa`
            if [ $faltaRep -eq 0 ]
            then
              programa=`$DIR_CARGA/C430InsertaDebHoy.sh $fechaQueRevisa`
              if [ $programa -eq 0 ]
              then
                echo "No pudo grabar en MTCPRO03 que ya corrio Reportes Debito $fechaQueRevisa "
              fi
            fi
          else
            echo "NO genera nada porque no es dia de CORTE Reportes Debito $fechaQueRevisa "
          fi
          fechaQueRevisa=`${DIR_CRON3}/SumResFec.sh ${fechaQueRevisa} D 1` #suma 1 dias a hoy
        done
        HORA1=$(date '+%H:%M:%S')
        fechaActual=$(date '+%Y%m%d')
        echo "TERMINA PROCESO REPORTES DEBITO  $fechaActual $HORA1 "
      else
        HORA1=$(date '+%H:%M:%S')
        fechaActual=$(date '+%Y%m%d')
        echo "Ya no lanza intelar $HORA $HORA1"
        echo "Ya no lanza intelar diaInicial $fechaHOY y diaActual $fechaActual"
        echo "TERMINA PROCESO REPORTES CREDITO $fechaActual $HORA1 "
      fi
  fi
  else
    echo " $fechaHOY$HORA NO estan registrados con estatus de 0 archivos DEBITO en MTCPRO01"
  fi
else
  echo "$fechaHOY$HORA NO estan los 4 archivos de hoy DHST,DHEA,DPLS Y DTAR"
  echo "$fechaHOY$HORA fecha -4 dias= $fecha4diasAtras"
fi
