#!/bin/ksh    

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

PATH=$PATH:/opt/c430/000/bin:. ; export PATH
SYBASE_OCS=OCS-15_0; export SYBASE_OCS
PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 08 CRO):$(paths.sh 08 BIN); export PATH
GE_USER=$(usuario.sh) 
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER 
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)

export  SYBASE DSQUERY

DIR_TEMP=$(paths.sh 08 TMP)

case $# in                                                     
   1) ;;   # No. de Parametros Correcto.                       
   *) print "Parametros incorrectos, Use: C430SendCCF.sh <rutaYnomArch> "
      exit 1 ;;                                                
esac                                                           

#       FUNCION PARA EXECUTAR UN COMANDO SQL POR PARAMETRO 
ExecSQL(){                   
isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE -b<<EOF
set nocount on
go
$*
go
EOF
}

fechaBorrar=`ExecSQL " SELECT convert(char(4),datepart(yy,dateadd(dd,-5,getdate())))+ replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(mm,dateadd(dd,-5,getdate())))))))+ltrim(rtrim(convert(char(2),datepart(mm,dateadd(dd,-5,getdate())))))+replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(dd,dateadd(dd,-5,getdate())))))))+ltrim(rtrim(convert(char(2),datepart(dd,dateadd(dd,-5,getdate()))))) " `
ls $DIR_TEMP | grep ^C430SendCCF | \
while read nom_log
do
fechaArch=`echo $nom_log | cut -c12-19 `
#Checa que el archivo tenga permisos para ser borrado         
#y que no sea de los ultimos cinco dias                        
if [ -w $DIR_TEMP/$nom_log -a  $fechaArch -le $fechaBorrar ]
then                                                          
   #borra archivos de log atrasados
   rm $DIR_TEMP/$nom_log
fi
done

fechaYhora=`date +'%Y%m%d%H%M%S'`
exec 1>>$DIR_TEMP/C430SendCCF$fechaYhora.log  
exec 2>&1                                      

#sftp -oPort=10022 -v b430s03x@10.221.94.90 <<EOF #ACYP
#sftp -oPort=10022 -v b430s03x@10.221.166.2 <<EOF #DESARROLLO
#sftp -oPort=10022 -v b430s03x@10.221.30.225 <<EOF #PRODUCCION
#pwd
#ls
#put $1 43003e01.CCDDLTQX.NDMFILES.TEST0002 #ACYP
#put $1 43003e01.CCDDLTQX.NDMFILES.TEST0001 #DESARROLLO
#put $1 43003e01.CCDDLPQX.BMX.CCF.IN #PRODUCCION
#ls
#quit
#EOF
DIR_ICEP=/opt/c617/402/icep/bin
export DIR_ICEP
                                                                                
#$DIR_ICEP/icep.sh intelarintmx1 gunix b430s03x send ma $1 43003e01.CCDDLTQX.NDMFILES.TEST0001

#$DIR_ICEP/icep.sh intelarintmx1 gunix b430s03x send ma $1 43003e01.CCDDLPQX.BMX.CCF.IN

cd /opt/c430/000/bin/s702/envio/crontabs/ssh_intelar

./ssh_intelar.sh b430s03x put $1 43003e01.CCDDLPQX.BMX.CCF.IN

rslt=$?

echo "rslt: "$rslt

if (test $rslt -eq 0)  then
  echo "el Archivo 43003e01.CCDDLPQX.BMX.CCF.IN transmitio correctamente"
  return 0
else
  echo "ERROR el 43003e01.CCDDLPQX.BMX.CCF.IN NO se transmitio "
  return $rslt
fi
