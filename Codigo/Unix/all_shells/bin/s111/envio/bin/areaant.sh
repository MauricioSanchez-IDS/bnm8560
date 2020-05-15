# Sistema: c430
# Directorio: 
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Procedimiento: area.sh
# Descripción:
# Versión y fecha: 1.0 20 de mayo del 2000
# Autor:
# Modificaciones: 21 de mayo del 2000
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC

isql -U $USUARIO -P $PASSWORD -D$(base.sh) -S $SERVIDOR -i $DIR_CARGA/area.sql > $DIR_TEMP/area1.txt
#se eliminan lineas de inicio y fin
sed -e '1,2 d' -e '/./!d' -e '$d' $DIR_TEMP/area1.txt | cut -c2-55 > $DIR_TEMP/area3.txt

registro=`wc -l < $DIR_TEMP/area3.txt`
tr -d "\012" < $DIR_TEMP/area3.txt > $DIR_TEMP/area1.txt
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
nomArch=`echo "ABNX$mes$dia"`
total=`echo "$registro+1" | bc`
variable=`printf "%s%s%.12d%.4d" HEADER $fecha $total 54`
printf "%-54s" $variable > $DIR_TEMP/area2.txt
cat $DIR_TEMP/area2.txt $DIR_TEMP/area1.txt > $DIR_TEMP/area.txt
cp $DIR_TEMP/area.txt $DIR_ARCH/$nomArch
