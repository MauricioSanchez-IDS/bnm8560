#!/bin/ksh                                                                 

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000             
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs                
# Descripcion           : Compacta y envia los reportes de deposito a Intelar - BancaNet 
# Version               : 1.0                                                  
# Autor                 :                                                      

#set -x

PATH=$PATH:/opt/c430/000/bin         
export PATH                          
SYBASE_OCS=OCS-15_0                  
export SYBASE_OCS                    
PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:
export PATH                          

exec 1>>$(paths.sh 03 LOG)/C430EnviaRepBcaNet.log
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

if (test $1 -eq 1) then
    carpeta=Corporativa
else
   if (test $1 -eq 2) then
      carpeta=Ejecutiva
   else
      echo "Error en Parametro 1"
      return 99
   fi
fi

echo "Inicia generacion de archivo de reportes para BancaNet....$carpeta"
cd $DIR_TMP/$carpeta
tar -cvf C430_000.reportesBcaNet.$1.tar *TC??$mes$dia*.TXT
echo "Termina generacion de archivo de reportes para BancaNet."

echo "Inicia envio de archivo de reportes a Intelar-BancaNet....$carpeta"
cd /opt/c430/000/bin/inte/envio/crontabs/ssh_intelar
./ssh_intelar.sh ic430001 put $DIR_TMP/$carpeta/C430_000.reportesBcaNet.$1.tar 43007e01.C430_000.$fecha.reportesBcaNet.$1.tar
rslt=$?
if (test $rslt -eq 0)  then
  echo "el Archivo C430_000.$fecha.reportesBcaNet.$1.tar se transmitio correctamente"
  cd $DIR_TMP
  rm -f *.TXT
  return 0                                                                    
else
  echo "ERROR el archivo C430_000.$fecha.reportesBcaNet.$1.tar NO se transmitio "
  return $rslt
fi

