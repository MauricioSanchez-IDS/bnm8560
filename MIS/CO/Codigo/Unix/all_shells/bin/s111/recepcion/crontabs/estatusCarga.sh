#!/usr/bin/ksh

##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Procedimiento: estatusCarga.sh
# Descripcion: EJECUTA LA VALIDACION DE LA CARGA DESPUES DE VERIFICAR QUE
#              EXISTAN LAS CONDICIONES NECESARIAS
# Version y fecha: 1.0   ene/2003


PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS


PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 07 CRO):$(paths.sh 07 BIN)

#=== Genera variables de ambiente para manejo de las rutas
DIR_CARGA=$(paths.sh 07 BIN)/validaCarga/bin
DIR_TEMP=$(paths.sh 07 BIN)/validaCarga/bin/temp
DIR_PARAM=$(paths.sh 07 BIN)/validaCarga/param

#=== Genera variables de ambiente de Sybase de produccion
GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)

export GE_USER GE_PASSWORD GE_DBASE GE_SERVERGE_USER GE_PASSWORD GE_DBASE GE_SERVER

archFecha=$DIR_PARAM/fecha.txt

### FUNCIONES

#=== REVISA QUE LOS ARCHIVOS DE HIS, HIH, THS Y PLA A VALIDAR SE HAYAN CARGADO
CargaS111 () {
isql -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -D${GE_DBASE} <<EOF

declare @mesDia char(4)
select @mesDia = substring(convert(char(8),dateadd(dd, -1, getdate()),112),5,4)
select count(*) from MTCPRO01
where pro_nomarch in ('EHIS'+@mesDia,'EHIH'+@mesDia,'ETHS'+@mesDia,'EPLA'+@mesDia)
and pro_estatus = 0
go

EOF
}

#=== OBTIENE TODOS LOS DIAS DE CORTE EN MTCEMP01
diasCorte () {
isql -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -D${GE_DBASE} <<EOF

select distinct rtrim(ltrim(convert(char(2),emp_dia_corte))) from MTCEMP01
go

EOF
}

#=== OBTIENE EL NUMERO DE REGISTROS EN VALEMP01 DEL DIA
consValEmp () {
isql -U${GE_USER} -P${GE_PASSWORD} -S${GE_SERVER} -D${GE_DBASE} <<EOF

select  count(*) from VALEMP01
where convert(char(8),fecha_hora,112) = convert(char(8),getdate(),112)
go

EOF
}

### FIN FUNCIONES

dia=`date +%d |awk '{print --$1}'`
mes=`date +%m`
anio=`date +%Y`
fecha=`date +%Y%m%d`

#=== VERIFICA QUE NO HAYA OTROS PROCESOS LEVANTADOS
procesos=`ps -fe | grep -v grep | grep -c validaCarga.sh`
if [ $procesos -gt 1 ] #Se sale si hay otro proceso levantado
then
  exit 0
fi

#=== VERIFICA QUE LOS ARCHIVOS HIS, HIH, THS Y PLA ESTEN CARGADOS (4)
numArchCarga=`CargaS111 |grep -v '('|grep [0-9]|awk '{ print $1}'`
if [ numArchCarga -lt 4 ]
then
  exit 0
fi

#=== VERIFICA QUE TIPO DE VALIDACION HACER (CORTE-DIARIA)
ejecutaCorte=0
for i in `diasCorte |grep -v '('|grep [0-9]|awk '{ print $1}'`
do
  if [ $i -eq $dia ]
  then
    ejecutaCorte=1
  fi
done

#== VERIFICAR QUE LA VALIDACION DEL DIA NO SE HAYA EJECUTADO
#== EN VALEMP01
estatus1=0
estatus2=0

estatus1=`consValEmp |grep -v '('|grep [0-9]|awk '{ print $1}'`

#== EN EL ARCHIVO DE FECHA (REGISTRO DE VALIDACION DE DIARIO)
if [ -r $archFecha ]
then
  ultimaValidacion=`cat $archFecha`
  if [ $ultimaValidacion -eq $fecha ]
  then
    estatus2=1
  fi
fi

#=== SI LOS REGISTROS TANTO DE LA TABLA COMO DE ARCHIVO ESTAN
#=== ACTUALIZADOS, LA VALIDACION YA FUE HECHA (CORTE Y DIARIO)
if [ $estatus1 -ne 0 -a $estatus2 -ne 0 ]
then
  exit 0
fi

#=== EJECUTAR VALIDACION (CORTE O CORTE-DIARIA)
if [ $ejecutaCorte -eq 1 ]
then
  $DIR_CARGA/validaCarga.sh $fecha >$DIR_TEMP/estatusDetalleDiario.log
  $DIR_CARGA/validaCarga.sh $mes$dia $anio >$DIR_TEMP/estatusDetalleCorte.log
  echo $fecha > $archFecha
else
  if [ $estatus2 -eq 0 ]
  then
    $DIR_CARGA/validaCarga.sh $fecha >$DIR_TEMP/estatusDetalleDiario.log
    echo $fecha > $archFecha
  fi
fi

return 0
