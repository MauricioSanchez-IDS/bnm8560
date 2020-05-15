#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: 
# Procedimiento: emp.sh
# Descripción:
# Versión y fecha: 1.0 21 de mayo del 2000
# Autor:
# Modificaciones: 21 de mayo del 2000
# proposito: adeuar a directorios estandar

# Modificaciones: Feb/2007 Nelly Rdz FSWB Mty
# Se incluye llamado al archivo emp6.sql, para generar archivo incluyendo los campos emp_rfc, emp_tipo_persona y emp_atn_a de la tabla MTCEMP01. 
# Además se modifica header con nueva longitud de registro
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

DIR_TRAB=$(paths.sh 06 BIN)

isql -U $USUARIO -P $PASSWORD -D$(base.sh) -S $SERVIDOR -i $DIR_TRAB/emp1.sql -Jroman8 > $DIR_TEMP/emp1.txt
isql -U $USUARIO -P $PASSWORD -D$(base.sh) -S $SERVIDOR -i $DIR_TRAB/emp2.sql -Jroman8 > $DIR_TEMP/emp2.txt
isql -U $USUARIO -P $PASSWORD -D$(base.sh) -S $SERVIDOR -i $DIR_TRAB/emp3.sql -Jroman8 > $DIR_TEMP/emp3.txt
isql -U $USUARIO -P $PASSWORD -D$(base.sh) -S $SERVIDOR -i $DIR_TRAB/emp6.sql -Jroman8 > $DIR_TEMP/emp6.txt

sed -e '1,2d' -e '$d' $DIR_TEMP/emp1.txt | sed '$d' |cut -c2-77 > $DIR_TEMP/emp1_2.txt
sed -e '1,2d' -e '$d' $DIR_TEMP/emp2.txt | sed '$d' |cut -c2-72 > $DIR_TEMP/emp2_2.txt
sed -e '1,2d' -e '$d' $DIR_TEMP/emp3.txt | sed '$d' |cut -c2-61 > $DIR_TEMP/emp3_2.txt
sed -e '1,2d' -e '$d' $DIR_TEMP/emp6.txt | sed '$d' |cut -c2-62 > $DIR_TEMP/emp6_2.txt  

paste $DIR_TEMP/emp1_2.txt $DIR_TEMP/emp2_2.txt $DIR_TEMP/emp3_2.txt $DIR_TEMP/emp6_2.txt> $DIR_TEMP/emp.txt

tr -d "\011" < $DIR_TEMP/emp.txt > $DIR_TEMP/emp4.txt #elimina tabuladores
#tr -s "\012" < $DIR_TEMP/emp4.txt > $DIR_TEMP/emp5.txt
registro=`wc -l < $DIR_TEMP/emp4.txt`
tr -d "\012" < $DIR_TEMP/emp4.txt > $DIR_TEMP/empfin.txt #elimina retornoslinea
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
nomArch=`echo "EMPR$mes$dia"`
total=`echo "$registro+1" | bc`
variable=`printf "%s%s%.12d%.4d" HEADER $fecha $total 268`
printf "%-268s" $variable > $DIR_TEMP/empHEADER.txt
cat $DIR_TEMP/empHEADER.txt $DIR_TEMP/empfin.txt > $DIR_TEMP/empresa.txt
cp $DIR_TEMP/empresa.txt $DIR_ARCH/$nomArch
