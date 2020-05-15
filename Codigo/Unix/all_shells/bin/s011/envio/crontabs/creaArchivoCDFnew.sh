#!/usr/bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: $(paths.sh 04 CRO)
# Procedimiento: creaArchivoCDF.sh
# Descripción: ejecuta los programas para generar el archivo cdf a enviar a MC
# Versión y fecha: 2.0   21/jul/2003
# Autor:  Jose Ramon Gonzalez Diaz (EISSA)
#             
#                BITACORA:            
# Modificacion:SE Corrigen Errores en la Obtencion de la Fecha de Corte 30/Mar/2004 Jose Alberto Garcia
# Modificacion:SE Corrigen Errores de Sintaxis 30/Mar/2004 Jose Alberto Garcia
# Modificacion:SE Adiciona Validacion para Generacion del CDF DIARIO 30/May/2004 Jose Alberto Garcia
# Modificacion:SE Modifican Mensajes de Error en la tabla MTCPRO02  3/jun/2004 Jose Alberto Garcia
# Modificacion:SE Se adiciona variable v5000 30/Mar/2004 Jose Alberto Garcia
# Fecha de Modificacion:   Jun / 2012 -- HP -- Se Reviso para Migracion HRC


echo `date`
variable_fecha=`date`


PATH=$PATH:/opt/c430/000/bin:.
export PATH

# Variables de Sybase produccion
SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
SYBASE_OCS=OCS-15_0

export  SYBASE DSQUERY 
export SYBASE_OCS

#exec 1>>$(paths.sh 04 LOG)/creaArchivoCDF.log
#exec 2>&1

set -x

PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 04 CRO):$(paths.sh 04 BIN)
export PATH
export LD_LIBRARY_PATH=${LD_LIBRARY_PATH}:${SYBASE}/${SYBASE_OCS}/lib

# Genera variables de ambiente para manejo de las rutas de envio en produccion
DIR_ARCH2=$(paths.sh 04 RES)
DIR_ARCH=$(paths.sh 04 DEP)
DIR_CARGA=$(paths.sh 04 BIN)
DIR_PARAM=$(paths.sh 04 PAR)
DIR_LOGS=$(paths.sh 04 LOG)
DIR_BACK=$(paths.sh 04 RES)
DIR_TEMP=$(paths.sh 04 TMP)

export DIR_ARCH DIR_BACK DIR_CARGA DIR_PARAM DIR_ARCH2 DIR_LOGS DIR_TEMP PATH

#Genera variables de ambiente de Sybase
GE_USER=$(usuario.sh)        
#GE_PASSWORD=$(password.sh)  
GE_PASSWORD=FnPSDk2J
GE_DBASE=$(base.sh)       
GE_SERVER=$(servidor.sh)     
#GE_HOSTNAME=`uname -n`
#GE_HOSTNAME=qrdblvmsyb3p
GE_HOSTNAME=QRDBLVMSYB3P

export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME 


# La variable fechacorte se obtine de la fecha del sistema  
# se enviara por corte y variables prefijo, banco,
# se utilizan en esta parte del proceso.

# Las variables fechainicial y fechafinal son para ser utilizadas
# en la generacion del archivo para envio diario 

# Se crea una variable llamada v5000 para indicar como se genera el
# archivo CDF.

# Si la varaible v5000 lleva un 1 indicara que el archivo se genera
# normalmente  se incluyen los registros 1000, 4000, 4100, 4200,
# 4300, 5000, 9999, si la  variable v5000 lleva un 0 indicara que solo se
# incluyan en el archivo a generar los registros que se regeneraron
# que es el proceso diario.

v5000=0
vgenarch=0
lim=0

# Se crean las variables para indicar el prefijo, banco, fecha de corte
# si esta en necesaria se pasara como argumento de este programa.

prefijo=$1
banco=$2
empresa=$3

echo "Inicio del proceso para la generacion del archivo CDF"
fechaproceso=`date`
echo $fechaproceso


# Se obtiene la fecha del sistema
 ayo=`date +%Y`
 fecha=`date +%Y%m%d`
 fechados=`date +%y%m%d`
 fechalogico=`date +%Y%m%d`
 nombrelogico=$fechalogico
 nombrearch='OS011CDF.F'          
 nomarchcomp=${nombrearch}${fechados}

 echo $ayo
 echo $fecha
 echo $fechados
 echo $fechalogico
 echo $nombrelogico
 echo $nombrearch
 echo $nomarchcomp

banderasigue=0

# obtiene el estatus y el nombre logico para definir que tipo de generacion de archivo CDf se llevara a cabo.
variable=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/consEstatus.txt | sed '1,2d;$d'` 
#arriba asigna el resultado en variable, y en seguida se da el mismo comando  
#para que el sistema operativo determine si el programa termino exitosamente  
isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/consEstatus.txt
if [ $? -gt 0 ] #si el resultado del ultimo comando es mayor que 0
then
  errores="Error en el programa creaArchivoCDF.sh No se obtuvo estatus"
  echo "Fecha proceso:$nombrelogico"
  echo "NombreArchivo:$nomarchcomp"
  echo "Programa: creaArchivoCDF.sh"
  echo "Error: $errores"
  fecha_proceso=$nombrelogico                                                 
  nombre_archivo=$nomarchcomp                                                 
  exit
else
  banderasigue=0
  pro_nomLogi=`echo $variable | cut -f2 -d'|'`
  pro_nomFisi=`echo $variable | cut -f3 -d'|'`
  pro_fecha=`echo $variable | cut -f4 -d'|'`
  pro_estatus=`echo $variable | cut -f5 -d'|'`
  pro_fechacorte=`echo $variable | cut -f8 -d'|'`
  pro_nomLogico=$pro_nomLogi
  pro_nomFisico=$pro_nomFisi
  pro_fechas=$pro_fecha
  pro_status=$pro_estatus
  pro_fechacortes=$pro_fechacorte
  echo "pro_nomLogico: $pro_nomLogico"   
  echo "pro_nomFisico: $pro_nomFisico"
  echo "pro_fechas: $pro_fechas "
  echo "pro_status: $pro_status "
  echo "pro_fechacortes: $pro_fechacortes "
fi

if [ $banderasigue -eq 0 ]
then
  # Valida el numero en el campo estatus, para estatus permitidos # 
  if [ $pro_status -eq "1" -o $pro_status -eq "3" -o $pro_status -eq "20" -o $pro_status -eq "31" -o $pro_status -eq "12" ]
  then 
    banderasigue=0 
  else
   if [ $pro_status -eq "6"]
   then
     banderasigue=0
   else
    errores="El estatus leido no tiene derechos para ejecutar el programa creaArchivoCDF.sh" 
    echo "Fecha proceso:$nombrelogico"                                    
    echo "NombreArchivo:$nomarchcomp"                                     
    echo "Programa: creaArchivoCDF.sh"                                    
    echo "Error: $errores"
    fecha_proceso=$nombrelogico
    nombre_archivo=$nomarchcomp
    exit
   fi
  fi
fi

if [ $banderasigue -eq 0 ] ####### if valida bandera para continuar #######
then  
 
                     
      ####### if valida estatus para proceso normal #######
      if [ $pro_status -eq "1" -o $pro_status -eq "3" -o $pro_status -eq "12" -o $pro_status -eq "6" ]
      then

          # VALIDA LA CARGA DEL SISTEMA S111  #2004-04-11 JAGG##
          valida.sh
          if [[ $? -eq 0 ]]
          then
                echo "###Se enciende bandera para proceso genera archivoCDF ok##########"
                banderasigue=0  
          else
                banderasigue=1
                errores="No se puede generar el archivo CDF, Falta Completar la Carga del sistema S111"
                archivo="creaArchivoCDF.sh"
          fi

            if [ $banderasigue -eq 0 ]
            then
                if [ $prefijo -eq 0 -a $banco -eq 0 -a $empresa -eq 0 ]
                then
                  echo "declare  " > $DIR_CARGA/obtenDiaCorte.txt 
                  echo "@FecIni datetime, " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "@FecFin datetime  " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "create table #MESES (Mes varchar(2)) " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "insert into #MESES " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "select distinct  case when colid >= 10 then " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "convert(varchar(2),colid) " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "else '0' + convert(varchar(1),colid) end " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "from syscolumns where colid <=12 " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select  @FecIni = convert(datetime,max(pro_nomLogi)) from MTCPRO02  " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select  @FecFin = dateadd(day, -1,getdate()) " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo " " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "if @FecIni > @FecFin " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "begin " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select @FecFin = @FecIni " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "select @FecIni = dateadd(day, -1,getdate()) " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "end " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select convert(varchar(8),@FecIni,112) , 'I' " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "union " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select distinct " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "convert(varchar(8),convert(varchar(4), " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "datepart(yy,getdate())) + Mes +  " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " RIGHT('00' + convert(varchar(2), EMP.emp_dia_corte),2)) , 'C' " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "from MTCEMP01 EMP, #MESES " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "where EMP.emp_gen_CDF=1 " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "and convert(datetime,convert(varchar(8), " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "convert(varchar(4),datepart(yy,getdate())) + Mes + " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo " RIGHT('00' + convert(varchar(2), EMP.emp_dia_corte),2))) " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "between @FecIni and @FecFin " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "union " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select convert(varchar(8),@FecFin,112) , 'F' " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "order by 1 " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "drop table #MESES " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " " >> $DIR_CARGA/obtenDiaCorte.txt         
                  echo "go" >> $DIR_CARGA/obtenDiaCorte.txt
                else
                  echo "declare " > $DIR_CARGA/obtenDiaCorte.txt 
                  echo "@FecIni datetime, " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "@FecFin datetime " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "create table #MESES (Mes varchar(2)) " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "insert into #MESES " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "select distinct  case when colid >= 10 then " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "convert(varchar(2),colid) " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "else '0' + convert(varchar(1),colid) end " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "from syscolumns where colid <=12 " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "  " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select  @FecIni = convert(datetime,max(pro_nomLogi)) from MTCPRO02 " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "  " >> $DIR_CARGA/obtenDiaCorte.txt    
                  echo "select  @FecFin = dateadd(day, -1,getdate()) " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " " >> $DIR_CARGA/obtenDiaCorte.txt    
                  echo "if @FecIni > @FecFin " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "begin " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select @FecFin = @FecIni " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "select @FecIni = dateadd(day, -1,getdate()) " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "end " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select convert(varchar(8),@FecIni,112) , 'I' " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "union " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select distinct " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "convert(varchar(8),convert(varchar(4), " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "datepart(yy,getdate())) + Mes + " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " RIGHT('00' + convert(varchar(2), EMP.emp_dia_corte),2)) , 'C' " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "from MTCEMP01 EMP, MTCPGS01 PGS , #MESES " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "where PGS.pgs_rep_prefijo=EMP.eje_prefijo " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "and PGS.pgs_rep_banco=EMP.gpo_banco " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "and EMP.emp_gen_CDF=1 " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "and EMP.eje_prefijo=$prefijo " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "and EMP.gpo_banco=$banco " >> $DIR_CARGA/obtenDiaCorte.txt    
                  echo "and EMP.emp_num=$empresa " >> $DIR_CARGA/obtenDiaCorte.txt    
                  echo "and convert(datetime,convert(varchar(8), " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "convert(varchar(4),datepart(yy,getdate())) + Mes + " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo " RIGHT('00' + convert(varchar(2), EMP.emp_dia_corte),2))) " >> $DIR_CARGA/obtenDiaCorte.txt 
                  echo "between @FecIni and @FecFin " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "union " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "select convert(varchar(8),@FecFin,112) , 'F' " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "order by 1 " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo "drop table #MESES " >> $DIR_CARGA/obtenDiaCorte.txt
                  echo " " >> $DIR_CARGA/obtenDiaCorte.txt         
                  echo "go" >> $DIR_CARGA/obtenDiaCorte.txt
                fi

                variable=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/obtenDiaCorte.txt | grep '[0-9]' | egrep -v '\(.*\)' | sed 's/ //g'`                
                # En la sentecia de Arriba se asigna el resultado en variable, 
                # y en seguida se da el mismo comando
                # para que el sistema operativo determine si el programa 
                # termino exitosamente o no termino exiosamente
                 echo "$variable   ######################################" 


                isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/obtenDiaCorte.txt
                if [ $? -gt 0 ] #si el resultado del ultimo comando es mayor que 0
                then
                   mensaje="Error en consulta numero de Corte asignado a las empresas"
                   echo "Fecha Proceso:$fecha"
                else
                   numDiaCorte=""
                   primero=0
                   for fecprocesar in `echo $variable`
                   do
                     echo "fecprocesar: $fecprocesar"
                     
                     tipo=`echo $fecprocesar | awk '{ print substr($0,9,1) }'`
                     echo "tipo: $tipo "
             
                     if [ $tipo = "I" ]
                     then
                       fechainicial=`echo $fecprocesar |awk '{ print substr($0,1,8) }'`
                       echo "fechainicial: $fechainicial"
                       #banderacorte=1
                       banderasigue=0
                       fechacorte=0   
                     fi
                     
                     if [ $tipo = "C" ]
                     then
                        mesdiacorte=`echo $fecprocesar |awk '{ print substr($0,5,4) }'`
                        echo "valor en mesdiacorte:$mesdiacorte"
                        if [ $primero -eq 0 ]                                       
                        then
                           numDiaCorte=`echo $numDiaCorte$mesdiacorte`                
                           primero=1 
                           v5000=1              #Es corte                                
                        else                                                        
                           numDiaCorte=`echo $numDiaCorte,$mesdiacorte`
                        fi                                                          
                        echo "Numero de Dia de Corte:$numDiaCorte"
                        #banderacorte=0
                        banderasigue=0
                        pro_fec_corte=`echo $fecprocesar |awk '{ print substr($0,1,8) }'`
                        echo "pro_fec_corte: $pro_fec_corte"   
                        fechacorte=`echo $numDiaCorte`
                        fechacortepro=$pro_fec_corte 
                     fi                  
                     
                     if [ $tipo = "F" ]
                     then
                       fechafinal=`echo $fecprocesar |awk '{ print substr($0,1,8) }'`
                       echo "fechafinal: $fechafinal"
                     fi
                     fecprocesar=""
                   done                                                          
                   numDiaCorte=`echo "$numDiaCorte" `                           
                   echo "numDiaCorte:$numDiaCorte "                              
                fi
            fi

            if [ $banderasigue -eq 0 ]
            then
                echo "fecha: $fecha"
                echo "pro_nomLogico: $pro_nomLogico "
                banderacorte=1
                banderasigue=0
                if [ $fecha -gt $pro_nomLogico ]
                then
                  banderacorte=0
                  banderasigue=0
                else   
                  banderasigue=1
                  errores="Con la fecha a procesar ya se genero un archivo"
                  archivo="creaArchivoCDF.sh"
                fi
            fi

            if [ $banderasigue -eq 0 ]
            then
              echo "fecha inicial:$fechainicial"
              echo "fecha final:$fechafinal"    
              echo "fecha de corte: $fechacorte"
              echo "fechacortepro : $fechacortepro"  
              echo "prefijo:$prefijo"
              echo "banco :$banco"
              echo "empresa:$empresa"
            fi
      fi  ####### Fin del if de los estatus para proceso normal #######
fi  ####### Fin if validacion de bandera para continuar #######


if [ $banderasigue -eq 0 ]   
then
  # Valida el numero en el campo estatus para encender las banderas
  # de proceso completo o unicamente los regxxxx
  if [ $pro_status -eq "3" -o $pro_status -eq "1" -o $pro_status -eq "12" ]
  then 
    banestatus3ok=0
    banestatus2ok=1
    echo $pro_status
    fecha_proceso=$nombrelogico
    nombre_archivo=$nomarchcomp
    estatus=5
    estatuspro=0
    mensaje="Se esta generando archivo CDF"
    echo "insert into MTCPRO02(pro_nomLogi,pro_nomFisi,pro_fecha,pro_estatus,pro_est_usu,pro_mensaje)" > $DIR_CARGA/insertaestatus.txt
    echo " values ('$fecha_proceso', '$nombre_archivo',getdate(), $estatus,$estatuspro, '$mensaje')" >> $DIR_CARGA/insertaestatus.txt
    echo "go" >> $DIR_CARGA/insertaestatus.txt
    checainsert=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertaestatus.txt`
    if [ "$checainsert" != "(1 row affected)" ]
    then
      banderasigue=1
      errores="No se puede actualizar la tabla MTCPRO02 el campo pro_estatus con el valor 5. "
      archivo="creaArchivoCDF.sh"
      mensaje="Error al generar archivo CDF"
    else
      banderasigue=0
    fi
  else 
    if [ $pro_status -eq "20" -o $pro_status -eq "31" ]
    then
      echo $pro_status
      banestatus2ok=0
      banestatus3ok=1 
      fecha_proceso=$nombrelogico
      nombre_archivo=$nomarchcomp
      estatus=35
      estatuspro=0
      mensaje="Se esta generando archivo CDF"
      echo "insert into MTCPRO02(pro_nomLogi,pro_nomFisi,pro_fecha,pro_estatus,pro_est_usu,pro_mensaje)" > $DIR_CARGA/insertaestatus.txt
      echo " values ('$pro_nomLogi', '$nombre_archivo',getdate(), $estatus,$estatuspro, '$mensaje')" >> $DIR_CARGA/insertaestatus.txt
      echo "go" >> $DIR_CARGA/insertaestatus.txt
      checainsert=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertaestatus.txt`
      if [ "$checainsert" != "(1 row affected)" ]
      then
        banderasigue=1
        errores="No se puede actualizar la tabla MTCPRO02 el campo pro_estatuscon el valor 35. "
        archivo="creaArchivoCDF.sh"
      else
        banderasigue=0
      fi
    else
      banderasigue=1
      errores="En el programa creaArchivoCDF.sh obtuvo un estatus erroneo"
      archivo="creaArchivoCDF.sh"
    fi
  fi
fi      

if [ $banderasigue -eq 0 ]
then
#  espacio=`bdf 2>/dev/null | grep "/opt/c430/000$" | tr -s ' ' | cut -d' ' -f4`
  espacio=`df -k . | grep "/" | tr -s ' ' | cut -d' ' -f4`
  espacio=`echo "${espacio}/2" | bc`
  espacio=`echo "${espacio}*1024" | bc`
  espacio=`echo "${espacio}-1024" | bc`
  echo "$espacio"
  tamano2=52428800
  mayor=`expr $espacio \< $tamano2`
  echo "$mayor"
  if [ $mayor -eq 0 ]
  then
    echo "existe suficiente espacio"
    banderasigue=0
  else
    echo "$espacio"
    banderasigue=1
    errores="No existe espacio suficiente para la aplicacion que genera el archivoCDF"
    archivo="creaArchivoCDF.sh"
  fi
fi

if [ $banderasigue -eq 1 ] 
then
    echo "Fecha proceso:$nombrelogico"
    echo "NombreArchivo:$nomarchcomp"
    echo "Programa: $archivo"
    echo "Error: $errores"
    fecha_proceso=$nombrelogico
    nombre_archivo=$nomarchcomp 
    if [[ "$errores" = "No se puede generar el archivo CDF, Falta Completar la Carga del sistema S111" ]]
    then
        estatus=12
    else
        estatus=6 
    fi
    estatuspro=6
    mensaje=$errores
    accion="Avisar a ingenieria"
    echo "insert into MTCPRO02(pro_nomLogi,pro_nomFisi,pro_fecha,pro_estatus,pro_est_usu,pro_mensaje,pro_accion)" > $DIR_CARGA/insertaerror.txt
    echo " values ('$fecha_proceso', '$nombre_archivo',getdate(), $estatus,$estatuspro, '$mensaje','$accion')" >> $DIR_CARGA/insertaerror.txt
    echo "go" >> $DIR_CARGA/insertaerror.txt 
    checainsert=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertaerror.txt`
    if [ "$checainsert" != "(1 row affected)" ]
    then
        errores=" No se puede actualizar la tabla MTCPRO02."
        echo "Fecha proceso:$nombrelogico"
        echo "NombreArchivo:$nomarchcomp"
        echo "Programa: creaArchivoCDF.sh"
        echo "Error: $errores"
        exit
    else
        # si inserto en MTCPRO02 
        exit
    fi
fi

# Procesos para generar informacion para formar los registro  
# Recuerda incluir validacion de las fechas inicial y final   
# para el proceso de generado diario                          

if [ $banestatus3ok -eq 0 -o $pro_status -eq "6" ]
then
  echo "Entro generar archivo CDF"
  echo $nombrelogico $nomarchcomp $fechacorte $fechainicial $fechafinal
  
  if [ $banderacorte -eq 0 ]
  then
    echo "$DIR_CARGA/r1000 $nomarchcomp"
    $DIR_CARGA/r1000 $nomarchcomp
    if [ $? -gt 0 ] 
    then
    # Se ejecuto mal el programa r1000.c
      banderasigue=1
      archivo="r1000"
      errores="Se produjo un error en el programa creaArchivoCDF-r1000"
    else
      echo " select '|'+fileReferenceNumber+'|' " > $DIR_CARGA/numrefar.txt
      echo " from REG1000 " >> $DIR_CARGA/numrefar.txt
      echo "go" >> $DIR_CARGA/numrefar.txt
      numrefarch=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/numrefar.txt | sed '1d' | sed '1d;$d' `
      numrefarchivo=`echo "$numrefarch" | cut -f2 -d'|'`
      echo "numero de referencia: $numrefarchivo"
      banderasigue=0
    fi                                                            
  fi

#  Se Quita Validacion para Corte y Diario, Diario Viajan Todos los Registros  
#  if [ $banderasigue -eq 0 -a $v5000 -eq 1 ]  #Solo si es corte se incluyen 3000, 4000, 4100, 4200, 4300
  if [ $banderasigue -eq 0 ]  
  then                      
    echo "$DIR_CARGA/r3000 $nomarchcomp"
    $DIR_CARGA/r3000 $nomarchcomp
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r3000.c  
      banderasigue=1
      archivo="r3000"
      errores="Se produjo un error en el programa creaArchivoCDF-r3000"
    fi
  fi

  if [ $banderasigue -eq 0 ]                                           
  then
    echo "$DIR_CARGA/r5000 $nomarchcomp    $prefijo    $banco     $empresa     $fechainicial    $fechafinal 0"
    $DIR_CARGA/r5000 $nomarchcomp    $prefijo    $banco     $empresa     $fechainicial    $fechafinal 0
#    gdb $DIR_CARGA/r5000
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r5000.c
      banderasigue=1                                                   
      archivo="r5000" 
      echo " $DIR_CARGA/r5000 $nomarchcomp $prefijo $banco $empresa $fechainicial $fechafinal 0"
      echo " -$nomarchcomp-    -$prefijo-      -$banco-       - $empresa-   -$fechainicial- -$fechafinal- 0 "
      errores="Se produjo un error en programa creaArchivoCDF-r5000(Transacciones)"     
    fi                                                                 
  fi                                                                   

  if [ $banderasigue -eq 0 ]                                      
  then                                                            
    echo "$DIR_CARGA/r4300 $nomarchcomp $prefijo $banco $empresa 0 0 $fechacorte"
    $DIR_CARGA/r4300 $nomarchcomp    $prefijo        $banco     $empresa      0        0        $fechacorte
    if [ $? -gt 0 ]                                               
    then                                                          
      # Se produjo un error en el programa r4300.c                
      banderasigue=1                                              
      archivo="r4300"                                             
      errores="Se produjo un error en programa creaArchivoCDF-r4300"
    fi                                                            
  fi                                                               

  if [ $banderasigue -eq 0 ]
  then                      
    echo "$DIR_CARGA/r4100 $nomarchcomp $prefijo $banco $empresa"
    $DIR_CARGA/r4100 $nomarchcomp $prefijo $banco $empresa
      if [ $? -gt 0 ] 
      then
        # Se produjo un error en el programa r4100.c
        banderasigue=1
        archivo="r4100"
        errores="Se produjo un error en programa creaArchivoCDF-r4100"
      fi
    fi
    
  if [ $banderasigue -eq 0 ] 
  then                       
    echo "$DIR_CARGA/r4000 $nomarchcomp $prefijo $banco $empresa"
    $DIR_CARGA/r4000 $nomarchcomp $prefijo $banco $empresa
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r4000.c
      banderasigue=1
      archivo="r4000" 
      errores="Se produjo un error en programa creaArchivoCDF-r4000"  
    fi
  fi
    
  if [ $banderasigue -eq 0 ]
  then                     
    echo "$DIR_CARGA/r4200 $nomarchcomp $prefijo $banco $empresa"
    $DIR_CARGA/r4200 $nomarchcomp $prefijo $banco $empresa
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r4200.c
      banderasigue=1
      archivo="r4200"
      errores="Se produjo un error en programa creaArchivoCDF-r4200"
    fi
  fi

  if [ $banderasigue -eq 0 ]
  then                     
    $DIR_CARGA/r9999 $nomarchcomp
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r9999.c
      banderasigue=1
      archivo="r9999" 
      errores="Se produjo un error en programa creaArchivoCDF-r9999" 
    fi
  fi
  
  if [ $banderasigue -eq 0 ]
  then                     
    echo "$DIR_CARGA/genarchb ${nombrelogico} ${nomarchcomp} ${vgenarch}"
    $DIR_CARGA/genarchb ${nombrelogico} ${nomarchcomp} ${vgenarch}
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa genarchb.c
      banderasigue=1
      archivo="genarchb"
      errores="Se produjo un error en programa genarchb"
    fi
  fi
 
    # Programa para validar el contenido del archivo CDF
    #if [ $banderasigue -eq 0 ]
    #then                     
    #  echo 'Espere ejecutando programa validaArchivoCDF'
    #  $DIR_CARGA/validaArchivoCDF $DIR_TEMP/${nomarchcomp}
    #  if [ $? -gt 0 ] 
    #  then
    #    # Se produjo un error en el programa validaArchivoCDF
    #    banderasigue=1
    #    archivo="validaArchivoCDF"
    #    errores="Se produjo un error en el programa validaArchivoCDF"
    #  fi
    #fi
    
    # Programa para revisar la estructura del archivo, dependencia entre
    # registros, consecutivos, este programa debera llevar un parametro que
    # es el nombre del archivo.
    # Se ejecuta el programa validaEstructuraCDF
    if [ $banderasigue -eq 0 ]
    then                     
      echo 'Espere ejecutando programa validaEstrucCDF'
      echo "$DIR_CARGA/validaEstructCDF $DIR_TEMP/${nomarchcomp}"
      $DIR_CARGA/validaEstructCDF $DIR_TEMP/${nomarchcomp}
      if [ $? -gt 0 ] 
      then
        # Se produjo un error en el programa validaEstructCDF  
        banderasigue=1
        archivo="validaEstructCDF"
        errores="Se produjo un error en el programa validaEstructCDF"  
      fi 
    fi

    if [ $banderasigue -eq 1 ] 
    then
       echo "Fecha proceso:$nombrelogico"
       echo "NombreArchivo:$nomarchcomp"
       echo "Programa: $archivo"
       echo "Error: $errores"
       fecha_proceso=$nombrelogico
       nombre_archivo=$nomarchcomp 
       estatus=6 
       estatuspro=6
       mensaje=${errores:-"Error al generar Archivo CDF"}
       accion="Avisar a ingenieria"
       echo "insert into MTCPRO02(pro_nomLogi,pro_nomFisi,pro_fecha,pro_estatus,pro_est_usu,pro_mensaje,pro_accion)" > $DIR_CARGA/insertaerror.txt
       echo " values ('$fecha_proceso', '$nombre_archivo',getdate(), $estatus,$estatuspro, '$mensaje','$accion')" >> $DIR_CARGA/insertaerror.txt
       echo "go" >> $DIR_CARGA/insertaerror.txt 
       checainsert=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertaerror.txt`
       if [ "$checainsert" != "(1 row affected)" ]
       then
          errores=" No se puede actualizar la tabla MTCPRO02."
          echo "Fecha proceso:$nombrelogico"
          echo "NombreArchivo:$nomarchcomp"
          echo "Programa: creaArchivoCDF.sh"
          echo "Error: $errores"
          exit
       else
          # si inserto en MTCPRO02 
          exit
       fi
    fi

    echo `mv $DIR_TEMP/${nomarchcomp} $DIR_ARCH/${nomarchcomp}` 
    echo "touch $DIR_ARCH/control${fechados}.ctrl"
    touch $DIR_ARCH/control${fechados}.ctrl
    echo "Termino satisfactoriamente la creacion del archivo CDF $fechacortepro"
    fechaproceso=`date`                                         
    echo $fechaproceso                                          
    fecha_proceso=$nombrelogico
    nombre_archivo=$nomarchcomp 
    estatus=0 
    estatuspro=0
    mensaje="Archivo CDF se genero correctamente "
    echo "$fecha_proceso"
    echo "$nombre_archivo"
    echo "$estatus"
    echo "$estatuspror"
    echo "$mensaje"
    echo "$fechacortepro"
    echo "$numrefarchivo" 
    
    $DIR_CARGA/envioFTP.sh 

    echo "insert into MTCPRO02(pro_nomLogi,pro_nomFisi,pro_fecha," > $DIR_CARGA/insertaestatus.txt
    echo "pro_estatus,pro_est_usu,pro_mensaje,pro_fec_corte, pro_ref_num)" >> $DIR_CARGA/insertaestatus.txt
    echo " values ('$fecha_proceso', '$nombre_archivo',getdate(), $estatus,$estatuspro, '$mensaje','$fechacortepro','$numrefarchivo')" >> $DIR_CARGA/insertaestatus.txt
    echo "go" >> $DIR_CARGA/insertaestatus.txt  
    checainsert=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertaestatus.txt`
    if [ "$checainsert" != "(1 row affected)" ]
    then
      errores=" No se puede actualizar la tabla MTCPRO02."
      echo "Fecha proceso:$nombrelogico"
      echo "NombreArchivo:$nomarchcomp"
      echo "Programa: creaArchivoCDF.sh"
      echo "Error: $errores"

      echo "Comence "$variable_fecha
      echo "Termine "`date`
      exit
    else
      # si inserto en MTCPRO02 

          echo "Comence "$variable_fecha
          echo "Termine "`date`
      exit
    fi

echo "Comence "$variable_fecha
echo "Termine "`date`

 exit
fi

#***********   Proceso de regeneracion del archivo CDF   **********************

echo "Proceso de regeneracion de archivo CDF "
sleep 10
vgenarch=1
if [ $banderasigue -eq 0 ]   
then                         
  if [ $banestatus2ok -eq 0 ]
  then
    echo "Entro a regeneracion del archivo CDF"
    $DIR_CARGA/r1000 $nomarchcomp
    if [ $? -gt 0 ] 
    then
      # Se produjo un error en el programa r1000.c
      banderasigue=1
      archivo="r1000"
      errores="Se produjo un error en el programa r1000.c"
    else
      echo "select '|'+fileReferenceNumber+'|'" > $DIR_CARGA/numrefar.txt
      echo " from REG1000" >> $DIR_CARGA/numrefar.txt
      echo "go" >> $DIR_CARGA/numrefar.txt
      numrefarch=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/numrefar.txt | sed '1 d' | sed '1 d' `
      numrefarchivo=`echo "$numrefarch" | cut -f2 -d'|'`
      banderasigue=0
    fi
  
    if [ $banderasigue -eq 0 ] 
    then
      $DIR_CARGA/r9999 $nomarchcomp
      if [ $? -gt 0 ] 
      then
        # Se produjo un error en el programa r9999.c
        banderasigue=1
        archivo="r9999"
        errores="Se produjo un error en el programa r9999.c"
      fi
    fi
   
    if [ $banderasigue -eq 0 ] 
    then
      echo "$DIR_CARGA/genarchb ${nombrelogico} ${nomarchcomp} ${vgenarch}"
      $DIR_CARGA/genarchb ${nombrelogico} ${nomarchcomp} ${vgenarch}
      if [ $? -gt 0 ] 
      then
        # Se produjo un error en el programa genarchb.c
        bandrasigue=1
        archivo="genarchb"
        errores="Se produjo un error en el programa genarchb.c"
      fi
    fi
 
    # Programa para validar el contenido del archivo CDF a enviar a MC      
    # este programa debera llevar un parametro que es el nombre del archivo.
                                                                       
    # Se ejecuta el programa validaArchivoCDF
    echo 'Espere ejecutando programa validaArchivoCDF'
    if [ $banderasigue -eq 0 ] 
    then
      $DIR_CARGA/validaArchivoCDF $DIR_TEMP/${nomarchcomp}
      if [ $? -gt 0 ] 
      then
        # Se produjo un error en el programa validaArchivoCDF.c
        banderasigue=1
        archivo="validaArchivoCDF"
        errores="Se produjo un error en el programa validaArchivoCDF.c"
      fi
    fi

    # Programa para revisar la estructura del archivo, dependencia entre    
    # registros, consecutivos, este programa debera llevar un parametro que 
    # es el nombre del archivo.                                             
                                                                        
    # Se ejecuta el programa validaEstructCDF
    echo 'Espere ejecutando programa validaEstrucCDF'                       
    if [ $banderasigue -eq 0 ] 
    then
      $DIR_CARGA/validaEstructCDF $DIR_TEMP/${nomarchcomp}                    
      if [ $? -gt 0 ]
      then
        # Se produjo un error en el programa validaEstructCDF.c
        banderasigue=1
        archivo="validaEstructCDF"
        errores="Se produjo un error en el programa validaEstructCDF.c"
      fi
    fi
  
    if [ $banderasigue -eq 1 ] 
    then
      echo "Fecha proceso:$nombrelogico"
      echo "NombreArchivo:$nomarchcomp"
      echo "Programa: $archivo"
      echo "Error: $errores"
      fecha_proceso=$nombrelogico
      nombre_archivo=$nomarchcomp 
      estatus=36 
      estatuspro=36
      mensaje=${errores:-"Error al generar Archivo CDF"}
      accion="Avisar a ingenieria"
      echo "insert into MTCPRO02(pro_nomLogi,pro_nomFisi,pro_fecha,pro_estatus,pro_est_usu,pro_mensaje,pro_accion)" > $DIR_CARGA/insertaerror.txt
      echo " values ('$fecha_proceso', '$nombre_archivo',getdate(), $estatus,$estatuspro, '$mensaje','$accion')" >> $DIR_CARGA/insertaerror.txt
      echo "go" >> $DIR_CARGA/insertaerror.txt 
      checainsert=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertaerror.txt`
      if [ "$checainsert" != "(1 row affected)" ]
      then
        errores=" no se puede actualizar la tabla MTCPRO02."
        echo "Fecha proceso:$nombrelogico"
        echo "NombreArchivo:$nomarchcomp"
        echo "Programa: creaArchivoCDF.sh"
        echo "Error: $errores"
        exit
      else
        # si inserto en MTCPRO02 
        exit
      fi
    fi
 
    echo "mv $DIR_TEMP/${nomarchcomp} $DIR_ARCH/${nomarchcomp}"
    echo `mv $DIR_TEMP/${nomarchcomp} $DIR_ARCH/${nomarchcomp}`
    echo "touch $DIR_ARCH/control${fechados}.ctrl"
    touch $DIR_ARCH/control${fechados}.ctrl
    echo "Termino satisfactoriamente la creacion del archivo CDF con modificaciones "
    fechaproceso=`date`
    echo $fechaproceso
    fecha_proceso=$nombrelogico
    nombre_archivo=$nomarchcomp
    estatus=30
    estatuspro=0
    mensaje="Archivo CDF se genero correctamente "
    # ENVIO DEL ARCHIVO A INTELAR

    $DIR_CARGA/envioFTP.sh 

    echo "insert into MTCPRO02(pro_nomLogi,pro_nomFisi,pro_fecha,pro_estatus,pro_est_usu,pro_mensaje,pro_ref_num)" > $DIR_CARGA/insertaestatus.txt
    echo " values ('$pro_nomLogi', '$nombre_archivo',getdate(), $estatus,$estatuspro, '$mensaje','$numrefarchivo')" >> $DIR_CARGA/insertaestatus.txt
    echo "go" >> $DIR_CARGA/insertaestatus.txt  
    checainsert=`isql -U${GE_USER} -P${GE_PASSWORD} -D$(base.sh) -S${GE_SERVER} -i $DIR_CARGA/insertaestatus.txt`
    if [ "$checainsert" != "(1 row affected)" ]
    then
      errores=" no se puede actualizar la tabla MTCPRO02."
      echo "Fecha proceso:$nombrelogico"
      echo "NombreArchivo:$nomarchcomp"
      echo "Programa: creaArchivoCDF.sh"
      echo "Error: $errores"
      exit
    else
      # si inserto en MTCPRO02 
      exit
    fi
    exit
  fi
fi
