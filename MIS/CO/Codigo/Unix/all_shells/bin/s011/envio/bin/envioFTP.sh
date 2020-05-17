#==============================================================================
# VARIABLES DE ENTORNO
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
#==============================================================================

PATH=$PATH:/opt/c430/000/bin:.
DIR_BIN=$(paths.sh 01 BIN)      
DIR_LOGS=$(paths.sh 04 LOG)
BITACORA=$DIR_BIN/bitacoraITO.sh
RUTA=$(paths.sh 04 DEP) 

export DIR_BIN DIR_LOGS BITACORA RUTA 

#==============================================================================
# VALIDA QUE EL ARCHIVO EXISTA
#==============================================================================

echo "\n\n"
archivo=`date '+OS011CDF.F%y%m%d'`
export archivo
cd $RUTA
if [ -f $archivo ] 
then
  cp $archivo 43002s01.$archivo
  archivo2=43002s01.$archivo
  export archivo2
  echo "==============================================================="
  echo "OK EL ARCHIVO  $archivo EXISTE"
  echo "==============================================================="
else
  echo "==============================================================="
  echo "EL ARCHIVO  $archivo NO EXISTE"
  echo "==============================================================="
  exit 1
fi

#============================================================================== 
# VALIDA QUE EL TAMAQO DEL ARCHIVO SEA MAYOR QUE 0                              
#============================================================================== 
#tam1=`ll $RUTA/$archivo | awk '{print $5}'`                                     
tam1=`ls -ltr $RUTA/$archivo | awk '{print $5}'`
if test $tam1 -eq 0                                                             
then                                                                            
  echo "\n\n"                                                                   
  echo "==============================================================="        
  echo "EL ARCHIVO $archivo Es de 0 kb "                                        
  echo "==============================================================="        
  exit 1                                                                        
fi                  
                                                            
#==============================================================================
# FUNCION QUE EJECUTA LOS COMANDOS
#==============================================================================

#DIR_ICEP=/opt/c617/402/icep/bin                                                 
#export DIR_ICEP
#$DIR_ICEP/icep.sh intelarintmx1 gunix b430s02s send ma $archivo 43002s01.$archivo

cd /opt/c430/000/bin/s011/envio/crontabs/ssh_intelar
./ssh_intelar.sh xbuzgene put ${RUTA}/${archivo} C430000002.$archivo



rslt=$?                                                                         
if (test $rslt -eq 0)  then                                                     
   echo "Se envio el archivo $archivo"                         
else                                                                            
   echo "Error : $rslt  en el envio del archivo $archivo"      
fi                                                                              

