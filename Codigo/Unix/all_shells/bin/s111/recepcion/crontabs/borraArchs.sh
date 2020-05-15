#! /bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: $(paths.sh 07 CRO)
# Procedimiento: borraarchs.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:  YMF    03/11/97
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

#exec 1>>$(paths.sh 07 LOG)/borraarchs.log
#exec 2>&1

DIR_PARAM=$(paths.sh 07 PAR)
DIR_ARCH2=$(paths.sh 07 RES)


PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 07 CRO)
export DIR_PARAM DIR_ARCH2 PATH

SERVIDOR=$(servidor.sh)
USUARIO=$(usuario.sh)
PASSWD=$(password.sh)

export SERVIDOR USUARIO PASSWD

# Variables de Sybase
	SYBASE=$(sybase.sh)
	DSQUERY=$(servidor.sh)
	USER=$(base.sh)
export SYBASE DSQUERY USER

#depura registros de MTCPRO01 

AAAAMMDD=`date +'%Y%m%d'`                                  
echo ' SE DEPURA TABLA MTCPRO01 EL DIA DE HOY:'  $AAAAMMDD 
isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_PARAM/depuraMTCPRO01.txt
echo ' SE DEPURA TABLA MTCPRO02 EL DIA DE HOY:'  $AAAAMMDD 
isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_PARAM/depuraMTCPRO02.txt
echo ' SE DEPURA TABLA MTCENV01 EL DIA DE HOY:'  $AAAAMMDD 
isql -U${USUARIO} -P${PASSWD} -D$(base.sh) -S${SERVIDOR} -i $DIR_PARAM/depuraMTCENV01.txt



cat $DIR_PARAM/arch.list  | \
while read arch_s111
do
  echo " $arch_s111"
  #Checa que existan archivos
  arch_s111=`echo "$arch_s111" | cut -c2-100 `
  if [ -f $DIR_ARCH2/$arch_s111???? ]
  then
    total=0
    ls -t $DIR_ARCH2/$arch_s111???? | \
    while read nom_arch
    do
      #Checa que el archivo tenga permisos para ser borrado
      #y que no sea de los cuatro archivos mas recientes
      if [ -w $nom_arch -a  $total -gt 2 ]
      then
        #borra archivos atrasados
echo "rm $nom_arch*"
        rm $nom_arch*
      fi
      total=`expr $total + 1`
    done
  fi
done
