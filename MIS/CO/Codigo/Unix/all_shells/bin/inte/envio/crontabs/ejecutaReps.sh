#!/bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 03 CRO)
# Procedimiento: ejecutaReps.sh
# Descripción:
# Versión y fecha: 1.0
# Autor: APQ    28/01/2008
# Modificaciones:
# proposito: Ejecutar Reportes desde el cron y verificar que llego la carga

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 03 LOG)/ejecutaReps.log
exec 2>>$(paths.sh 03 LOG)/ejecutaRepserror.log

DIR_RES7=$(paths.sh 07 RES)
DIR_CRO=$(paths.sh 03 CRO)

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 03 CRO)
export DIR_CRO DIR_RES7

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

ANIOHOY=$(date '+%Y')
MESHOY=$(date '+%m')
DIAHOY=$(date '+%d')
fechoyD=$(date '+%d')
fechoyM=$(date '+%m')
fechoyA=$(date '+%Y')
fechoyMD=$(date '+%m%d')
fechoyAMD=$(date '+%Y%m%d')

RestaUnDia ()
{
if [ "$DIAHOY" = "01" -a "$MESHOY" = "01" ]
then
 ANIOHOY=`expr $ANIOHOY - 1 `
 MESHOY="12"
 DIAHOY="31"
 echo "$ANIOHOY$MESHOY$DIAHOY"
else
  if [ "$DIAHOY" = "01" ]
  then
     if [ "$MESHOY" = "02" -o "$MESHOY" = "04" -o "$MESHOY" = "06" -o "$MESHOY" = "08" -o "$MESHOY" = "09" -o "$MESHOY" = "11" ]
     then
       DIAHOY="31"
     else
        if [ "$MESHOY" = "05" -o "$MESHOY" = "07" -o "$MESHOY" = "10" -o "$MESHOY" = "12" ]
        then
          DIAHOY="30"
        else
          if [ "$MESHOY" = "03" ]
          then
            aniobisiesto=`expr $ANIOHOY % 4 `
            if [ $aniobisiesto -eq 0 ]
            then
              DIAHOY="29"
            else
              DIAHOY="28"
            fi
         else
            echo "ERROR en fecha dia=$DIAHOY mes=$MESHOY aqo=$ANIOHOY "
            exit
         fi
       fi
     fi
     MESHOY=`expr $MESHOY - 1 `
     MESHOY=`printf %0.2d $MESHOY `
  else
    DIAHOY=`expr $DIAHOY - 1 `
  fi
fi
DIAHOY=`printf %0.2d $DIAHOY `
fechaMD=$MESHOY$DIAHOY
fechaAMD=$ANIOHOY$MESHOY$DIAHOY
}

DepuraReportes ()
{
  echo DepuraReportes
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch="Ejecuta Reportes" and pro_fecha="${fechoyAMD}"
go
EOF`
  var=`echo $var | grep "(1 row affected)" | wc -l`
  if [ $var -eq 1 ]
  then
    echo Ya inicio a ejecutarse reportes hoy por lo que ya no ejecuto Depuracion de Reportes
  else
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch="Depura Reportes" and pro_fecha="${fechoyAMD}" and pro_estatus = 2
go
EOF`
    var=`echo $var | grep "(1 row affected)" | wc -l`
    if [ $var -eq 1 ] # Ya corrio Depura Reportes
    then
      echo Ya corrio Depura Reportes el dia de hoy
    else
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch="Depura Reportes" and pro_fecha = "${fechoyAMD}" and pro_estatus = 1
go
EOF`
      var=`echo $var | grep "(1 row affected)" | wc -l`
      if [ $var -eq 0 ]
      then
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
insert MTCPRO03 values
("${fechoyAMD}","${HORA}","Depura Reportes",1,"Inicio proceso de Depuracion de Reportes")
go
EOF`
        var=`echo $var | grep "(1 row affected)" | wc -l`
        if [ $var -eq 1 ]
        then
          echo Se Inicia proceso de Depuracion de reportes de hoy : $fechoyAMD

          rm -R /opt/c430/000/bin/inte/envio/deposito/*
          ll /opt/c430/000/bin/inte/envio/deposito

          HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
update MTCPRO03 set pro_estatus=2, pro_hora="${HORA}", pro_mensaje="Termino proceso de Depuracion de Reportes"
where pro_nomarch="Depura Reportes" and pro_fecha = "${fechoyAMD}"
go
EOF`
          var=`echo $var | grep "(1 row affected)" | wc -l`
          if [ $var -eq 0 ]
          then
            echo Fallo Update de Termino de Depuracion de Reportes en MTCPRO03
          else
            echo Termino proceso de Depuracion de Reportes
          fi
        else
          echo Fallo Insert de Inicio de proceso Depuracion en MTCPRO03
        fi
      else
        echo Se Reinicia proceso de Depuracion de reportes de hoy : $fechoyAMD

        rm -R /opt/c430/000/bin/inte/envio/deposito/*
        ll /opt/c430/000/bin/inte/envio/deposito


        HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
update MTCPRO03 set pro_estatus=2, pro_hora="${HORA}", pro_mensaje="Termino proceso de Depuracion de Reportes"
where pro_nomarch="Depura Reportes" and pro_fecha = "${fechoyAMD}"
go
EOF`
        var=`echo $var | grep "(1 row affected)" | wc -l`
        if [ $var -eq 0 ]
        then
          echo Fallo Update de Termino de Depuracion de Reportes en MTCPRO03
        else
          echo Termino proceso de Depuracion de Reportes
        fi
      fi
    fi
  fi
}


BuscaEjecRepsHoy ()
{
  echo BuscaEjecRepsHoy
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch="Ejecuta Reportes" and pro_fecha="${fechoyAMD}" and pro_estatus = 2
go
EOF`
  var=`echo $var | grep "(1 row affected)" | wc -l`
  if [ $var -eq 1 ]
  then
    EjecReps=2 # Ejecuta Reportes de hoy ya corrio
  else
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch="Ejecuta Reportes" and pro_fecha = "${fechoyAMD}" and pro_estatus = 1
go
EOF`
    var=`echo $var | grep "(1 row affected)" | wc -l`
    if [ $var -eq 0 ]
    then
      if [ "$CargaCreditoHoy" = "SI" -o "$CargaDebitoHoy" = "SI" ]
      then
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
insert MTCPRO03 values
("${fechoyAMD}","${HORA}","Ejecuta Reportes",1,"Inicio proceso de generacion de Reportes")
go
EOF`
        var=`echo $var | grep "(1 row affected)" | wc -l`
        if [ $var -eq 1 ]
        then
          EjecReps=0 # Ejecuta Reportes de hoy no ha corrido
          echo Se Inicia proceso de generacion de reportes de hoy : $fechoyAMD
        else
          echo Fallo Insert de Inicio de proceso en MTCPRO03
        fi
      else
        ###   Verificamos si hay procesos de reportes corriendo   ###

        p1=$(ps -fe | grep -v grep | grep c4300003 | grep C430Reps | wc -l)
        p2=$(ps -fe | grep -v grep | grep c4300003 | grep repGen | wc -l)
        p3=$(ps -fe | grep -v grep | grep c4300003 | grep DerSBF | wc -l)
        p4=$(ps -fe | grep -v grep | grep c4300003 | grep addRetLinea | wc -l)
        p5=$(ps -fe | grep -v grep | grep c4300003 | grep C430EnviaRepInt | wc -l)
        p6=$(ps -fe | grep -v grep | grep c4300003 | grep icep | wc -l)
        p7=$(ps -fe | grep -v grep | grep c4300003 | grep intelar | wc -l)
        p8=$(ps -fe | grep -v grep | grep c4300003 | grep isql | wc -l)
        if [ $p1 -eq 0 -a $p2 -eq 0 -a $p3 -eq 0 -a $p4 -eq 0 -a $p5 -eq 0 -a $p6 -eq 0 -a $p7 -eq 0 -a $p8 -eq 0 ]
        then
          EjecReps=0 # Ningun proceso de reportes esta corriendo por lo que se reinicia reproceso
          echo Se Reinicia proceso de generacion de reportes de hoy : $fechoyAMD
        else
          EjecReps=1 # Ejecuta Reportes de hoy esta corriendo
        fi
      fi
    else
      ###   Verificamos si hay procesos de reportes corriendo   ###

      p1=$(ps -fe | grep -v grep | grep c4300003 | grep C430Reps | wc -l)
      p2=$(ps -fe | grep -v grep | grep c4300003 | grep repGen | wc -l)
      p3=$(ps -fe | grep -v grep | grep c4300003 | grep DerSBF | wc -l)
      p4=$(ps -fe | grep -v grep | grep c4300003 | grep addRetLinea | wc -l)
      p5=$(ps -fe | grep -v grep | grep c4300003 | grep C430EnviaRepInt | wc -l)
      p6=$(ps -fe | grep -v grep | grep c4300003 | grep icep | wc -l)
      p7=$(ps -fe | grep -v grep | grep c4300003 | grep intelar | wc -l)
      p8=$(ps -fe | grep -v grep | grep c4300003 | grep isql | wc -l)
      if [ $p1 -eq 0 -a $p2 -eq 0 -a $p3 -eq 0 -a $p4 -eq 0 -a $p5 -eq 0 -a $p6 -eq 0 -a $p7 -eq 0 -a $p8 -eq 0 ]
      then
        EjecReps=0 # Ningun proceso de reportes esta corriendo por lo que se reinicia reproceso
        echo Se Reinicia proceso de generacion de reportes de hoy : $fechoyAMD
      else
        EjecReps=1 # Ejecuta Reportes de hoy esta corriendo
      fi
    fi
  fi
}


CierraEjeRepsHoy ()
{
  echo CierraEjeRepsHoy
  HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
update MTCPRO03 set pro_estatus=2, pro_hora="${HORA}", pro_mensaje="Termino proceso de generacion de Reportes"
where pro_nomarch="Ejecuta Reportes" and pro_fecha = "${fechoyAMD}"
go
EOF`
  var=`echo $var | grep "(1 row affected)" | wc -l`
  if [ $var -eq 0 ]
  then
    echo Fallo Update de Termino de Reps Diarios en MTCPRO03
  else
    echo Termino proceso de generacion de Reportes
  fi
}


BuscaCargaCredito ()
{
 echo BuscaCargaCredito
 CargaCreditoHoy="NO"
 EncontroC="NO"
 n=0
 while [ "$EncontroC" = "NO" -a $n -ne 5 ]
 do
  RestaUnDia
  let n=n+1
  if [ -f $DIR_RES7/EHIS$fechaMD -a -f $DIR_RES7/EPLA$fechaMD -a -f $DIR_RES7/ETHS$fechaMD -a -f $DIR_RES7/EHIH$fechaMD ]
  then
var1=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SEVER -D$GE_BASE <<EOF
select distinct pro_nomarch from MTCPRO01
where
(pro_nomarch="EHIS$fechaMD" and pro_estatus=0) or
(pro_nomarch="EHIH$fechaMD" and pro_estatus=0) or
(pro_nomarch="EPLA$fechaMD" and pro_estatus=0) or
(pro_nomarch="ETHS$fechaMD" and pro_estatus=0)
go
EOF`
    var1=`echo $var1 | grep "(4 rows affected)" | wc -l`
    if [ $var1 -eq 1 ] #si estan los cuatro archivos
    then
     if [ $n -eq 1 ]
     then
      echo Si Hay carga de Credito el dia de hoy
      CargaCreditoHoy="SI"
     else
      echo Se encontro ultima carga de credito en : $fechaMD
     fi
     EncontroC="SI"
     fecCgaAMD=$ANIOHOY$MESHOY$DIAHOY
    fi
  else
   echo No se encontraron archivos de carga de Credito de $fechaMD
  fi
 done
}

BuscaCargaDebito ()
{
 echo BuscaCargaDebito
 ANIOHOY=$fechoyA
 MESHOY=$fechoyM
 DIAHOY=$fechoyD
 CargaDebitoHoy="NO"
 EncontroD="NO"
 n=0
 while [ "$EncontroD" = "NO" -a $n -ne 5 ]
 do
  RestaUnDia
  let n=n+1
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
    var1=`echo $var1 | grep "(4 rows affected)" | wc -l`
    if [ $var1 -eq 1 ] #si estan los cuatro archivos
    then
     if [ $n -eq 1 ]
     then
      echo Si Hay carga de Debito el dia de hoy
      CargaDebitoHoy="SI"
     else
      echo Se encontro ultima carga de Debito en : $fechaMD
     fi
     EncontroD="SI"
     fecCgaAMD=$ANIOHOY$MESHOY$DIAHOY
    fi
  else
   echo No se encontraron archivos de carga de Debito de $fechaMD
  fi
 done
}

ProcesoDiario ()
{
 echo ProcesoDiario
 ANIOHOY=$fechoyA
 MESHOY=$fechoyM
 DIAHOY=$fechoyD
 for x in 1 2 3 4 5
 do
  fecGenRepAMD=$ANIOHOY$MESHOY$DIAHOY
  RestaUnDia
  fecArcAMD=$ANIOHOY$MESHOY$DIAHOY
  if [ "$fecArcAMD" -lt "$fecCgaAMD" -o "$fecArcAMD" -eq "$fecCgaAMD"  ]
  then
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch ="Reps Diarios Cred${fechaAMD}" and pro_estatus = 2
go
EOF`
    var=`echo $var | grep "(1 row affected)" | wc -l`
    if [ $var -eq 0 ]
    then
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch ="Reps Diarios Cred${fechaAMD}" and pro_estatus = 1
go
EOF`
      var=`echo $var | grep "(1 row affected)" | wc -l`
      if [ $var -eq 0 ]
      then
        HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
insert MTCPRO03 values
('$fechoyAMD','$HORA','Reps Diarios Cred${fechaAMD}',1,'Inicio Generacion de Reportes Diarios')
go
EOF`
        var=`echo $var | grep "(1 row affected)" | wc -l`
        if [ $var -eq 0 ]
        then
          echo Fallo Insert de Inicio de Reps Diarios en MTCPRO03
        else
          echo Inicio proceso de los reportes diarios de $fechaAMD
        fi
      else
        echo Inicio Reproceso de los reportes diarios de $fechaAMD
      fi

      $DIR_CRO/C430Reps.sh 0000 DAILY $fechaAMD $fechaAMD $fecGenRepAMD 1 99999 25 25 C
      SeGenReps="SI"

      HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
update MTCPRO03 set pro_estatus=2, pro_hora="${HORA}", pro_mensaje="Termino Generacion de Reportes Diarios"
where pro_nomarch="Reps Diarios Cred${fechaAMD}"
go
EOF`
      var=`echo $var | grep "(1 row affected)" | wc -l`
      if [ $var -eq 0 ]
      then
       echo Fallo Update de Termino de Reps Diarios en MTCPRO03
      fi
    else
      if [ $x -eq 1 ]  # Se generaron reportes diarios hoy
      then
        SeGenReps="SI"
      fi
    fi
  else
    if [ $x -eq 5 ]
    then
      echo No se encontraron reportes diarios de Credito a procesar
    fi
  fi
 done
}

ProcesoCorteCredito ()
{
 echo ProcesoCorteCredito
 ANIOHOY=$fechoyA
 MESHOY=$fechoyM
 DIAHOY=$fechoyD
 HayCorteC="NO"
 i=0
 while [ $HayCorteC = "NO" -a $i -ne 5 ]
 do
  RestaUnDia
  let i=i+1
  if [ $DIAHOY -eq 6 -o $DIAHOY -eq 18 -o $DIAHOY -eq 22 ]
  then
    HayCorteC="SI"
    if [ $DIAHOY -eq 6 ]
    then
     DiaAux="05"
    else
     if [ $DIAHOY -eq 18 ]
     then
      DiaAux="17"
     else
      if [ $DIAHOY -eq 22 ]
      then
       DiaAux="21"
      fi
     fi
    fi
    fechaAuxAMD=$ANIOHOY$MESHOY$DiaAux
    fechaMD=$MESHOY$DiaAux
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch="Reps Corte Cred${fechaAuxAMD}" and pro_estatus = 2
go
EOF`
    var=`echo $var | grep "(1 row affected)" | wc -l`
    if [ $var -eq 1 ]
    then
      if [ $i -eq 1 ]  # Se generaron reportes del corte de credito hoy
      then
        SeGenReps="SI"
      fi
      echo Ya se proceso corte de Credito : $fechaAuxAMD
    else
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch ="Reps Corte Cred${fechaAuxAMD}" and pro_estatus = 1
go
EOF`
      var=`echo $var | grep "(1 row affected)" | wc -l`
      if [ $var -eq 0 ]
      then
        HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
insert MTCPRO03 values
('$fechoyAMD','$HORA','Reps Corte Cred${fechaAuxAMD}',1,'Inicio Generacion de Reportes del Corte')
go
EOF`
        var=`echo $var | grep "(1 row affected)" | wc -l`
        if [ $var -eq 0 ]
        then
          echo Fallo Insert de Inicio de Reps del Corte de Credito en MTCPRO03
        else
          echo Inicio proceso de los reportes del Corte de Credito de $fechaAuxAMD
        fi
      else
        echo Inicio Reproceso de los reportes del Corte de Credito de $fechaAuxAMD
      fi

      $DIR_CRO/C430Reps.sh $fechaMD CYCLE 00000000 00000000 $fechaAMD 1 99999 18 26 C
#      $DIR_CRO/procRepEsp_man.sh $fechaAMD
      $DIR_CRO/C430Reps.sh $fechaMD CYCLE 00000000 00000000 $fechaAMD 1 99999 2 7 C
      $DIR_CRO/genDerSBF_man.sh 0 0 0 $MESHOY $ANIOHOY

      SeGenReps="SI"

      HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
update MTCPRO03 set pro_estatus=2, pro_hora="${HORA}", pro_mensaje="Termino Generacion de Reportes del Corte"
where pro_nomarch="Reps Corte Cred${fechaAuxAMD}"
go
EOF`
      var=`echo $var | grep "(1 row affected)" | wc -l`
      if [ $var -eq 0 ]
      then
        echo Fallo Update de Termino de Reps del Corte de Credito en MTCPRO03
      fi
    fi
  else
    if [ $i -eq 5 ]
    then
      echo No se encontro un Corte de Credito pendiente de procesar
    fi
  fi
 done
}


ProcesoCorteDebito ()
{
 echo ProcesaCorteDebito
 ANIOHOY=$fechoyA
 MESHOY=$fechoyM
 DIAHOY=$fechoyD
 HayCorteD="NO"
 i=0
 while [ $HayCorteD = "NO" -a $i -ne 5 ]
 do
  RestaUnDia
  let i=i+1
  if [ $DIAHOY -eq 6 -o $DIAHOY -eq 26 ]
  then
    HayCorteD="SI"
    if [ $DIAHOY -eq 6 ]
    then
     DiaAux="05"
    else
     if [ $DIAHOY -eq 26 ]
     then
      DiaAux="25"
     fi
    fi
    fechaAuxAMD=$ANIOHOY$MESHOY$DiaAux
    fechaMD=$MESHOY$DiaAux
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch="Reps Corte Debi${fechaAuxAMD}" and pro_estatus = 2
go
EOF`
    var=`echo $var | grep "(1 row affected)" | wc -l`
    if [ $var -eq 1 ]
    then
      if [ $i -eq 1 ]  # Se generaron reportes del corte de credito hoy
      then
        SeGenReps="SI"
      fi
      echo Ya se proceso corte de Debito : $fechaMD
    else
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch ="Reps Corte Debi${fechaAuxAMD}" and pro_estatus = 1
go
EOF`
      var=`echo $var | grep "(1 row affected)" | wc -l`
      if [ $var -eq 0 ]
      then
       HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
insert MTCPRO03 values
('$fechoyAMD','$HORA','Reps Corte Debi${fechaAuxAMD}',1,'Inicio Generacion de Reportes del Corte')
go
EOF`
       var=`echo $var | grep "(1 row affected)" | wc -l`
       if [ $var -eq 0 ]
       then
         echo Fallo Insert de Inicio de Reps del Corte de Debito en MTCPRO03
       else
         echo Inicio proceso de los reportes del Corte de Debito de $fechaAMD
       fi
      else
        echo Inicio Reproceso de los reportes del Corte de Debito de $fechaAMD
      fi

      $DIR_CRO/C430Reps.sh $fechaMD CYCLE 00000000 00000000 $fechaAMD 1 99999 18 24 D
      SeGenReps="SI"

      HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
update MTCPRO03 set pro_estatus=2, pro_hora="${HORA}", pro_mensaje="Termino Generacion de Reportes del Corte"
where pro_nomarch="Reps Corte Debi${fechaAuxAMD}"
go
EOF`
      var=`echo $var | grep "(1 row affected)" | wc -l`
      if [ $var -eq 0 ]
      then
        echo Fallo Update de Termino de Reps del Corte de Debito en MTCPRO03
      fi
    fi
  else
    if [ $i -eq 5 ]
    then
      echo No se encontro un Corte de Debito pendiente de procesar
    fi
  fi
 done
}

ProcesoIntelar ()
{
  echo ProcesoIntelar
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch="Reportes Intelar ${fechoyAMD}" and pro_estatus = 2
go
EOF`
  var=`echo $var | grep "(1 row affected)" | wc -l`
  if [ $var -eq 1 ]
  then
    echo Ya se proceso el Intelar de hoy
  else
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch ="Reportes Intelar ${fechoyAMD}" and pro_estatus = 1
go
EOF`
    var=`echo $var | grep "(1 row affected)" | wc -l`
    if [ $var -eq 0 ]
    then
     HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
insert MTCPRO03 values
('${fechoyAMD}','${HORA}','Reportes Intelar ${fechoyAMD}',1,'Inicio proceso de Intelar')
go
EOF`
     var=`echo $var | grep "(1 row affected)" | wc -l`
     if [ $var -eq 0 ]
     then
       echo Fallo Insert de Inicio de proceso Intelar en MTCPRO03
     else
       echo Inicio proceso de Intelar de $fechoyAMD
     fi
    else
      echo Inicio Reproceso de Intelar de $fechoyAMD
    fi

    $DIR_CRO/addRetLinea.sh
    $DIR_CRO/C430EnviaRepInt.sh
    $DIR_CRO/intelar.sh

    HORA=$(date '+%H:%M:%S')
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
update MTCPRO03 set pro_estatus=2, pro_hora="${HORA}", pro_mensaje="Termino proceso de Intelar"
where pro_nomarch="Reportes Intelar ${fechoyAMD}"
go
EOF`
    var=`echo $var | grep "(1 row affected)" | wc -l`
    if [ $var -eq 0 ]
    then
      echo Fallo Update de Termino de proceso Intelar en MTCPRO03
    fi
  fi
}


# Rutina Principal

echo
echo Fecha Corrida : $fechoyAMD
echo Hora Inicio   : ${HORA}
hora=$(date '+%H')
#if [ $fechoyD -eq 1 -a $hora -eq 0 ]
if [ $fechoyD -eq 1 ]
then
   DepuraReportes
fi
SeGenReps="NO"
BuscaCargaCredito
if [ $n -eq 5 -a "$EncontroC" = "NO"]
then
  echo Se buscaron 5 dias de atraso de la carga de Credito y no se encontro
  BuscaCargaDebito
  if [ $n -eq 5 -a "$EncontroD" = "NO"]
  then
    echo Se buscaron 5 dias de atraso de la carga de Debito y no se encontro
  else
    BuscaEjecRepsHoy
    if [ $EjecReps -eq 0 ]
    then
      ProcesoCorteDebito
      if [ "$SeGenReps" = "SI" ]
      then
        hora=$(date '+%H')
        if [ "$CargaDebitoHoy" = "SI" -a $hora -gt 19 ]
        then
          ProcesoIntelar
          CierraEjeRepsHoy
        else
          if [ "$EncontroD" = "SI" -a $hora -gt 19 ]
          then
            ProcesoIntelar
          fi
        fi
      else
        if [ "$CargaCreditoHoy" = "SI" -o "$CargaDebitoHoy" = "SI" ]
        then
          CierraEjeRepsHoy
        fi
      fi
    else
     if [ $EjecReps -eq 2 ]
     then
       echo El proceso de generacion de reportes de hoy ya corrio
     else
      if [ $EjecReps -eq 1 ]
      then
        echo El proceso de generacion de reportes de hoy esta corriendo
      fi
     fi
    fi
  fi
else
  BuscaEjecRepsHoy
  if [ $EjecReps -eq 0 ]
  then
    ProcesoDiario
    ProcesoCorteCredito
    BuscaCargaDebito
    if [ $n -eq 5 -a "$EncontroD" = "NO"]
    then
      echo Se buscaron 5 dias de atraso de la carga de Debito y no se encontro
    else
      ProcesoCorteDebito
    fi
    if [ "$SeGenReps" = "SI" ]
    then
      if [ "$CargaCreditoHoy" = "SI" -a "$CargaDebitoHoy" = "SI" ]
      then
        ProcesoIntelar
        CierraEjeRepsHoy
      else
        hora=$(date '+%H')
        if [ "$CargaCreditoHoy" = "SI" -a "$CargaDebitoHoy" = "NO" -a $hora -gt 09 ]
        then
          ProcesoIntelar
          CierraEjeRepsHoy
        else
          hora=$(date '+%H')
          if [ "$CargaCreditoHoy" = "NO" -a "$CargaDebitoHoy" = "SI" -a $hora -gt 19 ]
          then
            ProcesoIntelar
            CierraEjeRepsHoy
          else
            if [ "$EncontroC" = "SI" -o "$EncontroD" = "SI" ]
            then
              hora=$(date '+%H')
              if [ $hora -gt 19 ]
              then
                ProcesoIntelar
              fi
            fi
          fi
        fi
      fi
    else
      if [ "$CargaCreditoHoy" = "SI" -o "$CargaDebitoHoy" = "SI" ]
      then
        CierraEjeRepsHoy
      fi
    fi
  else
   if [ $EjecReps -eq 2 ]
   then
     echo El proceso de generacion de reportes de hoy ya corrio
   else
    if [ $EjecReps -eq 1 ]
    then
      echo El proceso de generacion de reportes de hoy esta corriendo
    fi
   fi
  fi
fi
HORA=$(date '+%H:%M:%S')
echo Hora Termino  : ${HORA}
