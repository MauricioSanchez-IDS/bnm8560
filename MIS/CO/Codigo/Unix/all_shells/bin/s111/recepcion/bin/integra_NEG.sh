#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 07 BIN)
# Procedimiento: integra_NEG.sh
# Descripcion:
# Version y fecha: 1.0 20 de mayo del 2000
# Autor:

# Modificaciones: 21 de mayo del 2000
# proposito: Adecuar a directorios estandar
# Autor: G. Antonio Villegas Ydu&ate

# Modificaciones: 28 de junio del 2001
# proposito: Adicionar el proceos para actualizacion de negocios
# Autor: Ing. Jose Ramon Gonzalez Diaz

DIR_ARCH2=$(paths.sh 07 RES)
DIR_CARGA=$(paths.sh 07 BIN)
DIR_PARAM=$(paths.sh 07 PAR)
DIR_LOGS=$(paths.sh 07 LOG)

#--- Si no existe el archivo de datos, envia un error y termina la
#    integracion
if [ ! -f $DIR_ARCH2/$1 ]
then
    echo "sp_GeneraErrorArch $1" > $DIR_CARGA/error_arch.sh
    echo "go"       >> $DIR_CARGA/error_arch.sh
    echo "EOF"      >> $DIR_CARGA/error_arch.sh

    isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_arch.sh
    exit 0
fi

#--- Si no existe el archivo de formato, envia un error y termina la integracion
if [ ! -f $DIR_PARAM/NEG.fmt ]
then
    echo "sp_GeneraErrorArch $1" > $DIR_CARGA/error_fmt.sh
    echo "go"       >> $DIR_CARGA/error_fmt.sh
    echo "EOF"      >> $DIR_CARGA/error_fmt.sh

    isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_fmt.sh
    exit 0
fi

#--- Crea el archivo shell de la 1a. Fase de Integracion
echo "sp_IntegracionFase1_NEG $1" > $DIR_CARGA/inteNEG1.sh
echo "go"       >> $DIR_CARGA/inteNEG1.sh
echo "EOF"      >> $DIR_CARGA/inteNEG1.sh
#Ejecuta el Stored Procedure de 1a. Fase de Integracisn, que incluye:
#   1. Realiza un dump a los logs
#   2. Si existe la tabla de CARGA, la borra
#   3. Crea la estructura de la tabla NEG
proc_OK=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/inteNEG1.sh  | grep -c "return status = 0" `

if [ $proc_OK = 0 ]
then
    #---Si hubo error al procesar la Fase, se sale del proceso y graba el error
    echo "sp_GeneraErrorFase1 $1" > $DIR_CARGA/error_fmt.sh
    echo "go"       >> $DIR_CARGA/error_fmt.sh
    echo "EOF"      >> $DIR_CARGA/error_fmt.sh
    isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_fmt.sh
    exit 0
fi

#--- Ejecuta el BulkCopy usando:
#    1. El archivo de datos (debe existir en la ruta de carga)
#    2. El archivo de formato (debe existir en la ruta de pNEGm)
#    3. El archivo de errores (se genera si hay alguna inconsistencia en el archivo de datos )

#_HP_Changes for Linux Migration -Start
#Changed bcp to bcp64 with flag -Jroman8

#bcp $(base.sh)..CARNEG01 in $DIR_ARCH2/$1 -Q -f$DIR_PARAM/NEG.fmt -U$USUARIO -P$PASSWD -S$SERVIDOR -e$DIR_LOGS/error.txt
bcp64 $(base.sh)..CARNEG01 in $DIR_ARCH2/$1 -Q -f$DIR_PARAM/NEG.fmt -U$USUARIO -P$PASSWD -S$SERVIDOR -e$DIR_LOGS/error.txt -Jroman8
#_HP_Changes for Linux Migration -End

#--- Si hubo error en el BulkCopy, se genera el archivo error.txt en la ruta de logs
if [ -f $DIR_LOGS/error.txt ]
then
    #--- Crea el archivo que genera un error de BulkCopy en la tabla MTCPRO01
    echo "sp_GeneraError $1" > $DIR_CARGA/error.sh
    echo "go"       >> $DIR_CARGA/error.sh
    echo "EOF"      >> $DIR_CARGA/error.sh
    #--- Graba el registro de error de BulkCopy en la tabla MTCPRO01
    isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error.sh
    #--- Elimina el archivo de errores
    rm $DIR_LOGS/error.txt
else #---------- Si no hubo error
    if [ -f $DIR_PARAM/cargaInicialNEG ]
    then
        busca=`grep -c ^1 $DIR_PARAM/cargaInicialNEG`
	echo $busca 
        if [ $busca -eq 1 ]
        then
            #--- Crea el archivo shell de la 2a. Fase de Integracion
            echo "sp_IntegracionFase2_NEG $1" > $DIR_CARGA/inteNEG2.sh
            echo "go"       >> $DIR_CARGA/inteNEG2.sh
            echo "EOF"      >> $DIR_CARGA/inteNEG2.sh

            #--- Ejecuta el Stored Procedure de 2a. Fase de Integracion,
            #    que incluye:
            #    1. Si existe la tabla de PRODUCCION MTCNEG01, la borra
            #    2. Renombra la de CARGA por la de PRODUCCION MTCNEG01
            #    3. Crea los mndices y las llaves primarias o secundarias, si
            #       existen
            proc_OK=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/inteNEG2.sh  | grep -c "return status = 0" ` 
        else
            #--- Crea el archivo shell de la 2a. Fase de Integracion Actualizacion
            echo "sp_ActIntegracionFase2_NEG $1" > $DIR_CARGA/inteNEG2.sh
            echo "go"       >> $DIR_CARGA/inteNEG2.sh
            echo "EOF"      >> $DIR_CARGA/inteNEG2.sh
            #--- Ejecuta el Store Procedure actualizacion de 2a. Fase de
            #    Integracion, que incluye:
            #    1. Carga la tabla CARNEG01.
            #    2. Busca los registros de CARNEG01 en MTCNEG01, si el registro
            #       existe lo actualiza, si no existe lo inserta.
            proc_OK=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/inteNEG2.sh | grep -c "return status = 0" `
        fi
    else
        #--- Si hubo error al procesar la Fase, se sale del proceso y graba el error
        echo "sp_GeneraErrorFase2 $1" > $DIR_CARGA/error_fmt.sh
        echo "go"       >> $DIR_CARGA/error_fmt.sh
        echo "EOF"      >> $DIR_CARGA/error_fmt.sh
        isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_fmt.sh
        exit 0
    fi
fi

if [ $proc_OK = 0 ]
then
    #--- Si hubo error al procesar la Fase, se sale del proceso y graba el error
    echo "sp_GeneraErrorFase2 $1" > $DIR_CARGA/error_fmt.sh
    echo "go"       >> $DIR_CARGA/error_fmt.sh
    echo "EOF"      >> $DIR_CARGA/error_fmt.sh

    isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_CARGA/error_fmt.sh
    exit 0
fi

