#!/usr/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 08 CRO)
# Procedimiento: ejecutaCCF.sh
# Descripción:
# Versión y fecha: 1.0
# Autor: YMF    01/11/07
# Modificaciones: 
# proposito: Ejecutar CCF desde el cron y verificar que llego la carga
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

exec 1>>$(paths.sh 08 LOG)/ejecutaCCF.log
exec 2>>$(paths.sh 08 LOG)/ejecutaCCFerror.log

#set -x

DIR_ARCH2=$(paths.sh 08 RES)
DIR_ARCH=$(paths.sh 08 DEP) 
DIR_RES7=$(paths.sh 07 RES) 
DIR_CARGA=$(paths.sh 08 BIN)
DIR_PARAM=$(paths.sh 08 PAR)
DIR_LOGS=$(paths.sh 08 LOG)
DIR_TEMP=$(paths.sh 08 TMP)
DIR_BIN=$(paths.sh 01 BIN)

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 08 CRO)
export DIR_ARCH DIR_TEMP DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS PATH

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

HORA=$(date '+%H:%M')

ANIOHOY=$(date '+%Y')
MESHOY=$(date '+%m')
DIAHOY=$(date '+%d')
#ANIOHOY=`echo $1 | cut -c1-4 ` 
#MESHOY=`echo $1 | cut -c5-6 `
#DIAHOY=`echo $1 | cut -c7-8 `

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
fechaMD=$MESHOY$DIAHOY #dia de ayer
fechaCCF=$(date '+%m%d')
fechaHOY=$(date '+%Y%m%d')

if [ -f $DIR_RES7/EHIS$fechaMD -a -f $DIR_RES7/EPLA$fechaMD -a -f $DIR_RES7/ETHS$fechaMD -a -f $DIR_RES7/EHIH$fechaMD ]		
then
var1=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SEVER -D$GE_BASE <<EOF
select distinct pro_nomarch from MTCPRO01
where
(pro_nomarch="EHIS$fechaMD" and pro_estatus=0) or
(pro_nomarch="EHIH$fechaMD" and pro_estatus=0) or
(pro_nomarch="EPLA$fechaMD" and pro_estatus=0) or
(pro_nomarch="EATM$fechaMD" and pro_estatus=0) or
(pro_nomarch="ETHS$fechaMD" and pro_estatus=0)
go
EOF`
echo "var1 $var1"
var1=`echo $var1 | grep "(4 rows affected)" | wc -l`
if [ $var1 -eq 1 ] #si estan los cuatro archivos, revisa si ya se genero CCF
then
var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCCCF01
where nom_archivo ="CCF${fechaCCF}D.txt"
go 
EOF`
echo "var $var"
var=`echo $var | grep "(1 row affected)" | wc -l`
      echo "var $var"
      if [ $var -eq 0 ]
      then
        /opt/c430/000/bin/s702/envio/crontabs/C430TransCCF.sh 0
      else
       echo "$fechaHOY$HORA Encontro que ya se genero archivo CCF${fechaCCF}D.txt"
      fi
  else
    echo " $fechaHOY$HORA NO estan registrados con estatus de 0 los cuatro archivos en MTCPRO01"
  fi
else
  echo "$fechaHOY$HORA NO estan los 4 archivos de hoy EHIS,EHIH,EPLA Y ETHS"
fi


