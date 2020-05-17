#!/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# SHELL PARA MONITOREAR LA AUTORIZACION DEL CCF 
# Y ENVIAR A DELAWERE ATRAVEZ DE INTELAR
#
# Fecha:  15-07-2004
# Autor: Jose Alberto Garcia Garcia
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC
##############################################################

################# VARIABLES DE AMBIENTE PARA SYBASE y CONEXION A LA B.D.
PATH=$PATH:/opt/c430/000/bin:. ; export PATH
SYBASE_OCS=OCS-15_0; export SYBASE_OCS
PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 08 CRO):$(paths.sh 08 BIN); export PATH
GE_USER=$(usuario.sh) ; GE_PASSWORD=$(password.sh); GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh); GE_HOSTNAME=ucadmty1; export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME
SYBASE=$(sybase.sh); DSQUERY=$(servidor.sh);  export  SYBASE DSQUERY 


#exec 1>>$(paths.sh 08 LOG)/C430MonitorCCF.log 
#exec 2>&1                                
DIR_ARCH=$(paths.sh 08 DEP)
DIR_LOGS=$(paths.sh 08 LOG)
DIR_CRON=$(paths.sh 08 CRO)
DIR_BACK=$(paths.sh 08 RES)
DIR_TEMP=$(paths.sh 08 TMP)
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

#Valida que no existe una instancia del C430MonitorCCF.sh 
procESP=`ps -fea `
proc=`ps -fea | grep C430MonitorCC | grep "sh -c" | grep -v grep | wc -l `
if [[ $proc > 1 ]]
then
   echo " $procESP " > $DIR_LOGS/EstatusProc.log
   exit 1           
fi

if [[ -z $1 ]]
then
   ProcessDate=$(date +'%Y%m%d')
else
   ProcessDate=$1
fi
mmddArch=`echo $ProcessDate | cut -c5-8`
fecha=$(date +'%Y%m%d')
fechaYhora=$(date +'%Y%m%d%H%M%S')
echo "C430MonitorCCF.sh $fechaYhora" >> $DIR_LOGS/C430MonitorCCF.log
#echo "Proceso $ProcessDate fecha envio $mmddArch"
ExecSQL "select getdate()" > /dev/null  #valida conexion a Sybase
if [ $? -ne 0 ]
then
    echo "FALLO LA CONEXION A SYBASE EN PROCESO MONITOR CCF"
    msg="FALLO LA CONEXION A SYBASE EN PROCESO MONITOR CCF"
    echo "$msg" >> $DIR_LOGS/C430MonitorCCF.log
    $BITACORA "PROCESO CCF" "C430MonitorCCF.sh - $arch_CCF" "C" "10806" "$msg"
    exit -1
fi
#Idetifica si existen archivo que se validaron el dia de hoy
ExecSQL " SELECT nom_archivo from MTCCCF01 where convert(char(4),datepart(yy,fecha_VoBo))+ replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(mm,fecha_VoBo))))))+ltrim(rtrim(convert(char(2),datepart(mm,fecha_VoBo))))+ replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(dd,fecha_VoBo))))))+ltrim(rtrim(convert(char(2),datepart(dd,fecha_VoBo))))='$ProcessDate' and estatus=5 " | \
while read arch_CCF
do
  #Checa que el archivo exista
  if [ -w $DIR_ARCH/$arch_CCF ]
  then
    tamanio=`ls -l ${DIR_ARCH}/$arch_CCF | tr -s ' ' | cut -d' ' -f5` 
exec 1>>$(paths.sh 08 LOG)/C430MonitorCCF.log 
exec 2>&1                                
    echo " tamanio $tamanio"
    $DIR_CRON/C430SendCCF.sh $DIR_ARCH/$arch_CCF 
    if (test $? -eq 0)  then    
      ExecSQL "update MTCCCF01 set estatus=7, fecha_envio=getdate(),tamanio=$tamanio where nom_archivo='$arch_CCF' and estatus=5 "
       if [ $? -eq 0 ]
       then
         msg="EL ARCHIVO $arch_CCF SE TRANSMITIO CORRECTAMENTE"
         #echo "$msg" >> $DIR_LOGS/C430MonitorCCF.log
         echo "$msg"
         $BITACORA "PROCESO CCF" "C430MonitorCCF.sh - $arch_CCF" "C" "10807" "$msg"
       else
         msg="ERROR EL ARCHIVO $arch_CCF SI SE TRANSMITIO NO EN TABLA MTCCCF01 "
         echo "$msg"
         #echo "$msg" >> $DIR_LOGS/C430MonitorCCF.log
         $BITACORA "PROCESO CCF" "C430MonitorCCF.sh - $arch_CCF" "C" "10808" "$msg"
       fi
       #Borra los archivos por empresa que deja el proceso
       mmdd=`echo $arch_CCF | cut -c4-7 `
       if [ -f $DIR_BACK/CCF??????*${mmdd}D.txt ] 
       then
          rm $DIR_BACK/CCF??????*${mmdd}D.txt
       fi
       #Copia el archivo a respaldo
       mv $DIR_ARCH/$arch_CCF $DIR_BACK/$arch_CCF
    else                                                                     
       msg="ERROR EL ARCHIVO CCF $arch_CCF NO SE PUDO TRANSMIR"
       echo "$msg" >> $DIR_LOGS/C430MonitorCCF.log
       $BITACORA "PROCESO CCF" "C430MonitorCCF.sh - $arch_CCF" "C" "10809" "$msg"
    fi                                                                      
   else
    msg="EL ARCHIVO CCF $arch_CCF NO EXISTE O NO TIENE PERMISOS DE LECTURA"
    echo "$msg" >> $DIR_LOGS/C430MonitorCCF.log
    $BITACORA "PROCESO CCF" "C430MonitorCCF.sh - $arch_CCF" "C" "10810" "$msg"
   fi
done
