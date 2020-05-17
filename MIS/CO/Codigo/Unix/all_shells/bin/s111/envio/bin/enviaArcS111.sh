#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC
DIR_ARCH=$(paths.sh 06 DEP)
export DIR_ARCH

arc=$1

dia=`date '+%d'`                  
mes=`date '+%m'`                  
if [ $dia -gt 0 -a  $dia -lt 28 ] 
then                              
  dia=15                          
else                              
  dia=28                          
fi                                
nomArch=`echo "$arc$mes$dia"`     

DIR_ICEP=/opt/c617/402/icep/bin
export DIR_ICEP

rutades='$DATA02.S111MAFI'

rutaprod='$DATA59.S111FI02'
 
#$DIR_ICEP/icep.sh intelarintmx1 gunix xunix send mb $DIR_ARCH/$nomArch C430_000.$rutades.$nomArch  #Desarrollo
#$DIR_ICEP/icep.sh intelarintmx1 gunix xunix send mb $DIR_ARCH/$nomArch C430_000.$rutaprod.$nomArch #Produccion

cd /opt/c430/000/bin/s111/envio/crontabs/ssh_intelar
##./ssh_intelar.sh xunix put ${DIR_ARCH}/${nomArch} C430_000.${rutades}.${nomArch}
./ssh_intelar.sh xunix put ${DIR_ARCH}/${nomArch} C430_000.${rutaprod}.${nomArch}

rslt=$?                                                                         
if (test $rslt -eq 0)  then                                                     
   echo "Se envio el archivo $DIR_ARCH/$nomArch"                         
else                                                                            
   echo "Error : $rslt  en el envio del archivo $DIR_ARCH/$nomArch"      
fi                                                                              

