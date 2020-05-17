#!/bin/ksh                                                                 

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000             
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs                
# Descripcion           : Compacta y envia los reportes de deposito a Intelar  
# Version               : 1.0                                                  
# Autor                 :                                                      

PATH=$PATH:/opt/c430/000/bin         
export PATH                          
SYBASE_OCS=OCS-15_0                  
export SYBASE_OCS                    
PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:
export PATH                          

exec 1>>$(paths.sh 03 LOG)/C430EnviaRepInt.log
exec 2>&1                  

# Genera variables de ambiente para manejo de las rutas de envio            
DIR_DEPOSITO=$(paths.sh 03 DEP)
DIR_TMP=$(paths.sh 03 TMP)
BITACORA=$DIR_BIN/bitacoraITO.sh
DIR_ICEP=/opt/c617/402/icep/bin

export DIR_DEPOSITO DIR_BIN DIR_ICEP

anio=`date +%Y`    
mes=`date +%m`     
dia=`date +%d`     
fecha=$anio$mes$dia

echo "Inicia generacion de archivo de reportes...."
cd $DIR_TMP
tar -cvf C430_000.reportes.tar $DIR_DEPOSITO/*
echo "Termina generacion de archivo de reportes."

echo "Inicia envio de archivo de reportes a Intelar...."
##$DIR_ICEP/icep.sh intelarintmx1 gunix xunix send mb C430_000.reportes.tar C430_000.$fecha.reportes.tar
cd /opt/c430/000/bin/inte/envio/crontabs/ssh_intelar
./ssh_intelar.sh xunix put $DIR_TMP/C430_000.reportes.tar C430_000.$fecha.reportes.tar
rslt=$?
if (test $rslt -eq 0)  then
  echo "el Archivo C430_000.$fecha.reportes.tar se transmitio correctamente"
  return 0                                                                    
else
  echo "ERROR el archivo C430_000.$fecha.reportes.tar NO se transmitio "
  return $rslt
fi

