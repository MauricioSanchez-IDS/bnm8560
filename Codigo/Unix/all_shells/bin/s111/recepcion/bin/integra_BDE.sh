#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 07 BIN)
# Procedimiento: integra_bde.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:
# Modificaciones: 21 de mayo del 2000
# proposito: Adecuar a directorios estandar
# Autor: G. Antonio Villegas Ydu&ate

DIR_ARCH2=$(paths.sh 07 RES)
DIR_CARGA=$(paths.sh 07 BIN)
DIR_PARAM=$(paths.sh 07 PAR)
DIR_LOGS=$(paths.sh 07 LOG)

#---------- Si no existe el archivo de datos, envia un error y termina la integracisn
if [ ! -f $DIR_ARCH2/$1 ]
then
      echo "sp_GeneraErrorArch $1" > $DIR_CARGA/error_arch.sh
      echo "go"       >> $DIR_CARGA/error_arch.sh
      echo "EOF"      >> $DIR_CARGA/error_arch.sh

      isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_arch.sh
	exit 0
fi

#---------- Si no existe el archivo de formato, envia un error y termina la integracisn
if [ ! -f $DIR_PARAM/BDE.fmt ]
then
      echo "sp_GeneraErrorArch $1" > $DIR_CARGA/error_fmt.sh
      echo "go"       >> $DIR_CARGA/error_fmt.sh
      echo "EOF"      >> $DIR_CARGA/error_fmt.sh

      isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_fmt.sh
	exit 0
fi

#---------- Crea el archivo shell de la 1a. Fase de Integracisn
echo "sp_IntegracionFase1_BDE $1" > $DIR_CARGA/inteBDE1.sh
echo "go"       >> $DIR_CARGA/inteBDE1.sh
echo "EOF"      >> $DIR_CARGA/inteBDE1.sh

#---------- Ejecuta el Stored Procedure de 1a. Fase de Integracisn, que incluye:
#     1. Realiza un dump a los logs
# 	2. Si existe la tabla de CARGA, la borra
#	3. Crea la estructura de la tabla BDE
proc_OK=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/inteBDE1.sh  | grep -c "return status = 0" `

if [ $proc_OK = 0 ]
then

#-----Si hubo error al procesar la Fase, se sale del proceso y graba el error
      echo "sp_GeneraErrorFase1 $1" > $DIR_CARGA/error_fmt.sh
      echo "go"       >> $DIR_CARGA/error_fmt.sh
      echo "EOF"      >> $DIR_CARGA/error_fmt.sh

      isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_fmt.sh
	exit 0

fi

#---------- Ejecuta el BulkCopy usando:
#     1. El archivo de datos (debe existir en la ruta de carga)
#     2. El archivo de formato (debe existir en la ruta de param)
#     3. El archivo de errores (se genera si hay alguna inconsistencia en el archivo de datos )

#_HP_Changes for Linux Migration -Start
#Changed bcp to bcp64 with flag -Jroman8

#bcp $(base.sh)..CARBDE01 in $DIR_ARCH2/$1 -Q -f$DIR_PARAM/BDE.fmt -U$USUARIO -P$PASSWD -S$SERVIDOR -e$DIR_LOGS/error.txt
bcp64 $(base.sh)..CARBDE01 in $DIR_ARCH2/$1 -Q -f$DIR_PARAM/BDE.fmt -U$USUARIO -P$PASSWD -S$SERVIDOR -e$DIR_LOGS/error.txt -Jroman8
#_HP_Changes for Linux Migration -End

#---------- Si hubo error en el BulkCopy, se genera el archivo error.txt en la ruta de logs
if [ -f $DIR_LOGS/error.txt ]
then

#---------- Crea el archivo que genera un error de BulkCopy en la tabla MTCPRO01
echo "sp_GeneraError $1" > $DIR_CARGA/error.sh
echo "go"       >> $DIR_CARGA/error.sh
echo "EOF"      >> $DIR_CARGA/error.sh

#---------- Graba el registro de error de BulkCopy en la tabla MTCPRO01
isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error.sh

#---------- Elimina el archivo de errores
rm $DIR_LOGS/error.txt

#---------- Si no hubo error
else

#---------- Crea el archivo shell de la 2a. Fase de Integracisn
echo "sp_IntegracionFase2_BDE $1" > $DIR_CARGA/inteBDE2.sh
echo "go"       >> $DIR_CARGA/inteBDE2.sh
echo "EOF"      >> $DIR_CARGA/inteBDE2.sh

#---------- Ejecuta el Stored Procedure de 2a. Fase de Integracisn, que incluye:
# 	1. Si existe la tabla de PRODUCCION MTCBDE01, la borra
#     2. Renombra la de CARGA por la de PRODUCCION MTCBDE01
#	3. Crea los mndices y las llaves primarias o secundarias, si existen
proc_OK=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/inteBDE2.sh  | grep -c "return status = 0" `

fi

if [ $proc_OK = 0 ]
then

#-----Si hubo error al procesar la Fase, se sale del proceso y graba el error
      echo "sp_GeneraErrorFase2 $1" > $DIR_CARGA/error_fmt.sh
      echo "go"       >> $DIR_CARGA/error_fmt.sh
      echo "EOF"      >> $DIR_CARGA/error_fmt.sh

      isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_fmt.sh
	exit 0

fi

