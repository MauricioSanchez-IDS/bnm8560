#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: 
# Procedimiento: eje.sh
# Descripción: Realiza el query para obtener de todos los ejecutivos en Tarjeta Corporativa
# numero de cuenta, nomina, sirh, subdivision, division, dga
# para los ejecutivos que no son del banco pone ceros en sub, div, y dga
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:

# Modificaciones: Feb/2007 Nelly Rdz FSWB Mty
# Se en generacion de archivo incluyendo los campos eje_tipo_persona y eje_atn_a de la tabla MTCEJE01. 
# Además se modifica header con nueva longitud de registro
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

DIR_TRAB=$(paths.sh 06 BIN)

isql -U $USUARIO -P $PASSWORD -D$(base.sh) -S $SERVIDOR -i $DIR_TRAB/eje.sql > $DIR_TEMP/eje1.txt
isql -U $USUARIO -P $PASSWORD -D$(base.sh) -S $SERVIDOR -i $DIR_TRAB/eje2.sql > $DIR_TEMP/eje2.txt

# elimina todos los renglones que no son datos ejemplo: (55050 rows affected)
# con las siguientes instrucciones se borran 12 registros al principio y 2 al final
sed -e '1,6d' -e '$,3d' $DIR_TEMP/eje1.txt | cut -c2-50 > $DIR_TEMP/eje1_2.txt
sed -e '1,6d' -e '$,3d' $DIR_TEMP/eje2.txt | cut -c2-62 > $DIR_TEMP/eje2_2.txt

#junta archivos con resultados
paste $DIR_TEMP/eje1_2.txt $DIR_TEMP/eje2_2.txt > $DIR_TEMP/eje.txt
tr -d "\011" < $DIR_TEMP/eje.txt > $DIR_TEMP/ejepre.txt #elimina tabuladores

registro=`tr -s '\012' < $DIR_TEMP/ejepre.txt | wc -l `
tr -d "\012" < $DIR_TEMP/ejepre.txt > $DIR_TEMP/ejefin.txt
dia=`date '+%d'`
mes=`date '+%m'`
anio=`date '+%Y'`
if [ $dia -gt 0 -a  $dia -lt 28 ]
then
  dia=15
else
  dia=28
fi
fecha=`echo $dia$mes$anio`
nomArch=`echo "EJEC$mes$dia"`
total=`echo "$registro+1" | bc`
echo "fecha $fecha archivo $nomArch"
echo "$total"
variable=`printf "%s%s%.12d%.4d" HEADER $fecha $total 110`
printf "%-110s" $variable > $DIR_TEMP/ejeHEADER.txt
cat $DIR_TEMP/ejeHEADER.txt $DIR_TEMP/ejefin.txt > $DIR_TEMP/ejecutivo.txt
cp $DIR_TEMP/ejecutivo.txt $DIR_ARCH/$nomArch
