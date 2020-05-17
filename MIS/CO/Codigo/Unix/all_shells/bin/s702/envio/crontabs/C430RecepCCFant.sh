#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# SHELL PARA PROCESAR EL ARCHIVO DE RESPUESTA DEL CCF
#
# Fecha:  15-07-2004
# Autor: YMF
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC
##############################################################

################# VARIABLES DE AMBIENTE PARA SYBASE y CONEXION A LA B.D.
PATH=$PATH:/opt/c430/000/bin:. ; export PATH
SYBASE_OCS=OCS-15_0; export SYBASE_OCS
PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 08 CRO2):$(paths.sh 08 BIN2); export PATH
GE_USER=$(usuario.sh) 
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=ucadmty1
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME

DSQUERY=$(servidor.sh)
SYBASE=$(sybase.sh)
export  SYBASE DSQUERY 

DIR_ARCH=$(paths.sh 08 DEP2)
DIR_DEP2=$(paths.sh 08 DEP2)
DIR_LOGS=$(paths.sh 08 LOG)
DIR_CRON1=$(paths.sh 08 CRO)
DIR_CRON=$(paths.sh 08 CRO2)
DIR_BACK1=$(paths.sh 08 RES)
DIR_BACK2=$(paths.sh 08 RES2)
DIR_TEMP=$(paths.sh 08 TMP2)
DIR_BIN2=$(paths.sh 08 BIN2)
DIR_BIN=$(paths.sh 01 BIN)

BITACORA=$DIR_BIN/bitacoraITO.sh

#       FUNCION PARA EXECUTAR UN COMANDO SQL POR PARAMETRO 
ExecSQL(){                   
isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE -b<<EOF
set nocount on
go
$*
go
EOF
}

#Valida que no existe una instancia del C430RecepCCF.sh 
procESP=`ps -fea  ` 
proc=`ps -fea | grep C430RecepCCF  | grep "sh -c" | grep -v grep | wc -l ` 
if [[ $proc > 1 ]]                                                         
then
   echo " $procESP " > $DIR_LOGS/EstatusRecep.log
   exit 1           
fi


#Borra archivos CCF que Delaware ya haya confirmado de mas de 5 dias
#ExecSQL " SELECT nom_archivo from MTCCCF01 where fecha_confirmacion < dateadd(dd,-5,GETDATE()) and estatus=8 " | \
#while read arch_CCF
#do
#  if [ -f $DIR_BACK1/$arch_CCF ] 
#  then
#    rm $DIR_BACK1/$arch_CCF 
#  fi
#done

numArch=`ls $DIR_ARCH | grep ^CCFR | head -1 | wc -l`

if [ $numArch -ne 1 ]
then
  #echo "- No  existe archivo a procesar"
    msg="No existe archivo a procesar C430RecepCCF.sh"
    echo $msg
    echo "$msg" >> $DIR_LOGS/C430RecepCCF.log
  exit 0
fi

ExecSQL "select getdate()" > /dev/null  #valida conexion a Sybase
if [ $? -ne 0 ]
then
    msg="FALLO LA CONEXION A SYBASE DEL PROCESO C430RecepCCF.sh"
    echo $msg
    echo "$msg" >> $DIR_LOGS/C430RecepCCF.log
    $BITACORA "PROCESO CCF" "C430RecepCCF.sh - $arch_CCF" "C" "10811" "$msg"
    exit -1
fi

#Borra archivos CCF que Delaware ya haya confirmado de mas de 5 dias
ExecSQL " SELECT nom_archivo from MTCCCF01 where fecha_confirmacion < dateadd(dd,-5,GETDATE()) and estatus=8 " | \
while read arch_CCF
do
  MMDDCCF=`echo $arch_CCF | cut -c4-7 `
  if [ -f $DIR_BACK1/$arch_CCF ] 
  then
    $DIR_CRON1/C430LimpCCF.sh $MMDDCCF
    #rm $DIR_BACK1/$arch_CCF  El archivo CCF de respaldo se borra arriba
  fi
done

fechaYhora=$(date +'%Y%m%d%H%M%S')
echo "C430RecepCCF.sh $fechaYhora" >> $DIR_LOGS/C430RecepCCF.log
primeraVez=0
cont=0
ExecSQL " SELECT nom_archivo+'|'+str((tamanio/1001)*1000,12,0)+'|'+convert(char(4),datepart(yy,fecha_envio))+ replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(mm,fecha_envio))))))+ltrim(rtrim(convert(char(2),datepart(mm,fecha_envio))))+ replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(dd,fecha_envio))))))+ltrim(rtrim(convert(char(2),datepart(dd,fecha_envio)))) from MTCCCF01 where fecha_confirmacion=NULL and estatus=7 order by fecha_envio" | \
while read datArchCCF
do
  nomArch=`echo $datArchCCF | cut -f1 -d'|'`
  tamanio=`echo $datArchCCF | cut -f2 -d'|'`
  fechaEnvio=`echo $datArchCCF | cut -f3 -d'|'`
  if [ $primeraVez -eq 0 ]
  then
    fechaEnvioAnt=$fechaEnvio
    primeraVez=1
  else
    if [ $fechaEnvio -ne $fechaEnvioAnt ]
     then
        cont=0
     else
        cont=`echo $cont + 1 | bc`        
    fi
  fi

ls $DIR_ARCH | grep ^CCFR | \
   while read archResp
   do
     if [  -r $DIR_ARCH/$archResp ]     
     then
       consecutivo=`printf "%.2d" $cont` 
       nomArchResp=`cat $DIR_ARCH/$archResp | cut -c1-50 `
       #consecResp=`$DIR_BIN2/c430pos $nomArchResp`
       consecResp=`echo $archResp | cut -c11-12 `
       fechaEnvioResp=`cat $DIR_ARCH/$archResp | cut -c51-58 `
       tamanioResp=`cat $DIR_ARCH/$archResp | cut -c85-100 `
       msg="$fechaYhora: $nomArch $consecutivo -eq $consecResp  -a  $fechaEnvio -eq $fechaEnvioResp  -a  $tamanio -eq $tamanioResp  "
       echo "$msg" >> $DIR_LOGS/C430RecepCCF.log
       if [ $consecutivo -eq $consecResp  -a  $fechaEnvio -eq $fechaEnvioResp -a  $tamanio -eq $tamanioResp  ]
       then
       ExecSQL "update MTCCCF01 set estatus=8, fecha_confirmacion=getdate() where nom_archivo='$nomArch' and estatus=7 "
       if [ $? -eq 0 ]
       then
         msg="EL ARCHIVO DE RESPUESTA $nomArch SE RECIBIO CORRECTAMENTE"
         echo "$msg" >> $DIR_LOGS/C430RecepCCF.log
         echo "$msg"
         $BITACORA "PROCESO CCF" "C430RecepCCF.sh - $arch_CCF" "C" "10812" "$msg"
         mv $DIR_ARCH/$archResp $DIR_BACK2/$archResp
       else
        msg="LA RESPUESTA $nomArch SE RECIBIO OK PERO NO ACTUALIZO TABLA MTCCCF01"
         echo "$msg"
         echo "$msg" >> $DIR_LOGS/C430RecepCCF.log
         $BITACORA "PROCESO CCF" "C430RecepCCF.sh - $arch_CCF" "C" "10813" "$msg"
       fi
       fi
     else
      msg="EL ARCHIVO DE RESPUESTA $archResp NO TIENE PERMISOS DE LECURA"
        echo "$msg"
        echo "$msg" >> $DIR_LOGS/C430RecepCCF.log
        $BITACORA "PROCESO CCF" "C430RecepCCF.sh - $arch_CCF" "C" "10814" "$msg"
     fi
     #Checa que el archivo exista
   done
   fechaEnvioAnt=$fechaEnvio
done
