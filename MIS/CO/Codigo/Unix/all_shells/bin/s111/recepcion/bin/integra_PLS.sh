#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 07 BIN)
# Procedimiento: integra_PLS.sh
# Descripción:
# Versión y fecha:  12 Enero 2002
# Autor: YMF

DIR_ARCH2=$(paths.sh 07 RES)
DIR_TEMP=$(paths.sh 07 TMP)
DIR_PARAM=$(paths.sh 07 PAR)
DIR_LOGS=$(paths.sh 07 LOG)

#---------- Si no existe el archivo de datos, envia un error y termina la integracisn
if [ ! -f $DIR_ARCH2/$1 ]
then
      echo "sp_GeneraErrorArch $1" > $DIR_TEMP/error_arch.sql
      echo "go"       >> $DIR_TEMP/error_arch.sql
      echo "EOF"      >> $DIR_TEMP/error_arch.sql

      isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/error_arch.sql
	exit 0
fi

#---------- Si no existe el archivo de formato, envia un error y termina la integracisn
if [ ! -f $DIR_PARAM/PLS.fmt ]
then
      echo "sp_GeneraErrorArch $1" > $DIR_TEMP/error_fmt.sql
      echo "go"       >> $DIR_TEMP/error_fmt.sql
      echo "EOF"      >> $DIR_TEMP/error_fmt.sql

      isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/error_fmt.sql
      exit 0
fi

#---------- Crea el archivo shell de la 1a. Fase de Integracisn
echo "sp_IntegracionFase1_PLS $1" > $DIR_TEMP/intePLS1.sql
echo "go"       >> $DIR_TEMP/intePLS1.sql
echo "EOF"      >> $DIR_TEMP/intePLS1.sql

#---------- Ejecuta el Stored Procedure de 1a. Fase de Integracisn, que incluye:
# 1. Realiza un dump a los logs
# 2. Si existe la tabla de CARGA, la borra
# 3. Crea la estructura de la tabla PLS
proc_Res=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/intePLS1.sql  | grep -c "return status = 0" `

if [ $proc_Res -eq 0 ] #cuando es 0 hubo error
then

#-----Si hubo error al procesar la Fase, se sale del proceso y graba el error
      echo "sp_GeneraErrorFase1 $1" > $DIR_TEMP/error_fmt.sql
      echo "go"       >> $DIR_TEMP/error_fmt.sql
      echo "EOF"      >> $DIR_TEMP/error_fmt.sql

      isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/error_fmt.sql
      exit 0
fi

#---------- Divide el archivo original en varios archivos                
# 1. Se divide el archivo original DPLSMMDD en varios archivos con csplit
# 2. se genera un archivo por cada producto ejem: DPLSMMDD01, DPLSMMDD02, etc.
# 3. Se genera un formato de carga para cada uno de estos archivos a partir
#    del original PLS.fmt, ejem: PLS01.fmt, PLS02.fmt, etc.

#se arma el comando de acuerdo al numero de productos que trae el archivo orig.
comando="csplit -f$1 $DIR_ARCH2/$1 " 
cd $DIR_ARCH2
cont=0
#es muy importante que el archivo original venga ordenado por numero de cuenta
#porque el csplit solo puede separar cuando pasamos los patrones en 
#el mismo orden en el que aparecen en el archivo ej: /^547370/ /^547380/.. etc
cut -c1-6 $DIR_ARCH2/$1 | uniq > $DIR_TEMP/bin.txt
cat $DIR_TEMP/bin.txt | \
while read bin
do
  cont=`echo $cont + 1 | bc`
  consecutivo=`printf "%.2d" $cont`
  comando="$comando /^$bin/"
  pref=`echo $bin | cut -c1-4`
  bco=`echo $bin | cut -c5-6`
  echo "select convert(char(1),pgs_long_eje)+     "  > $DIR_TEMP/busPref.sql
  echo "convert(char(1),pgs_long_emp)             "  >> $DIR_TEMP/busPref.sql
  echo "from MTCPGS01 where pgs_rep_prefijo=$pref "  >> $DIR_TEMP/busPref.sql
  echo "and pgs_rep_banco=$bco                    "  >> $DIR_TEMP/busPref.sql
  echo "go                                        "  >> $DIR_TEMP/busPref.sql
  # Validacion de conexion correcta por isql EISSA LGJ
  resultado=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/busPref.sql`
  if [ $? -ne 0 ]
  then
    resultado=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/busPref.sql`
  fi
  proc_Res=`echo $resultado | grep -c "(1 row affected)"`
  echo $proc_Res # yuria
  #si no encontro el bin en la tabla MTCPGS01 graba error en proceso de carga 
  if [ $proc_Res -eq 0 ]
  then
     echo "insert into MTCPRO01 values('$1', getdate(),19,  " > $DIR_TEMP/error.sql
     echo "'NO EXISTE EL PRODUCTO $pref $bco en MTCPGS01')" >> $DIR_TEMP/error.sql
     echo "go         " >> $DIR_TEMP/error.sql
     echo "EOF        " >> $DIR_TEMP/error.sql
     isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/error.sql
     exit 0
  fi
  eje=`echo $resultado | cut -c4-4`
  emp=`echo $resultado | cut -c5-5`
  awk -v emp=$emp -v eje=$eje -f $DIR_CARGA/cambia.awk <$DIR_PARAM/PLS.fmt >$DIR_TEMP/PLS$consecutivo.fmt
done

#se ejecuta el csplit 
$comando
if [ $? -ne 0 ] #valida que el comando anterior se haya ejecutado correctamente
then
  echo "insert into MTCPRO01 values('$1', getdate(),19,  " > $DIR_TEMP/error.sql
  echo "'HUBO ERROR EN EL COMANDO csplit' )            " >> $DIR_TEMP/error.sql
  echo "go         " >> $DIR_TEMP/error.sql
  echo "EOF        " >> $DIR_TEMP/error.sql
  isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/error.sql
  exit 0
fi

#---------- Ejecuta el Bulck copy del archivo                            
# 1. hace un bulk copy por cada uno de los archi: DPLSMMDD01, DPLSMMDD02, etc.
# 3. considera los formatos correspondientes:  PLS01.fmt, PLS02.fmt, etc.
cont2=0
while [ $cont -gt 0  ] # $cont trae el numero de productos encontrados arriba
do
   cont2=`echo $cont2 + 1 | bc`
   cont=`echo $cont - 1 | bc`
   consecutivo=`printf "%.2d" $cont2 `
#_HP_Changes for Linux Migration -Start
#Changed bcp to bcp64 with flag -Jroman8

#bcp $(base.sh)..CARPLS01 in $DIR_ARCH2/${1}${consecutivo} -Q -f$DIR_TEMP/PLS${consecutivo}.fmt -U$USUARIO -P$PASSWD -S$SERVIDOR -e$DIR_LOGS/error.txt
bcp64 $(base.sh)..CARPLS01 in $DIR_ARCH2/${1}${consecutivo} -Q -f$DIR_TEMP/PLS${consecutivo}.fmt -U$USUARIO -P$PASSWD -S$SERVIDOR -e$DIR_LOGS/error.txt -Jroman8

#_HP_Changes for Linux Migration -End
   #En caso de error graba en la tabla y no continua con las demas instrucciones
   if [ $? -ne 0 -o -f $DIR_LOGS/error.txt ]
   then
     # Crea el archivo que genera un error de BulkCopy en la tabla MTCPRO01
     echo "sp_GeneraError $1" > $DIR_TEMP/error.sql
     echo "go"       >> $DIR_TEMP/error.sql
     echo "EOF"      >> $DIR_TEMP/error.sql

     # Graba el registro de error de BulkCopy en la tabla MTCPRO01
     isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/error.sql
     if [ -f $DIR_LOGS/error.txt ]
     then
       rm $DIR_LOGS/error.txt
     fi
     exit 0
   fi
done 

#---------- Crea el archivo shell de la 2a. Fase de Integracisn
echo "sp_IntegracionFase2_PLS $1" > $DIR_TEMP/intePLS2.sql
echo "go"       >> $DIR_TEMP/intePLS2.sql
echo "EOF"      >> $DIR_TEMP/intePLS2.sql

#---------- Ejecuta el Stored Procedure de 2a. Fase de Integracisn, que incluye:
#1. Si existe la tabla de PRODUCCION MTCPLS01, la borra
#2. Renombra la de CARGA por la de PRODUCCION MTCPLS01
#3. Crea los mndices y las llaves primarias o secundarias, si existen
proc_Res=`isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/intePLS2.sql  | grep -c "return status = 0" `

if [ $proc_Res -eq 0 ]  # Si el resultado es 0 hubo error
then

#-----Si hubo error al procesar la Fase, se sale del proceso y graba el error
      echo "sp_GeneraErrorFase2 $1" > $DIR_TEMP/error_fmt.sql
      echo "go"       >> $DIR_TEMP/error_fmt.sql
      echo "EOF"      >> $DIR_TEMP/error_fmt.sql
      isql -U$USUARIO -P$PASSWD -D$(base.sh) -S$SERVIDOR -i $DIR_TEMP/error_fmt.sql
      exit 0
fi

