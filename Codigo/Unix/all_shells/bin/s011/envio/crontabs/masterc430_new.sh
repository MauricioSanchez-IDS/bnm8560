#!/usr/bin/ksh
# SHELL PARA EJECUAR EL PROCESO DE CREAARCHIOVOSCDF
##__HP changes for Linux migration - start -change /bin/sh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
#
# Fecha:  27/11/2012
# Autor: Rafael Sosa Pozos         
##############################################################
exec 1>>$(paths.sh 04 LOG)/masterc430_new.log
exec 2>&1

################# VARIABLES DE AMBIENTE PARA SYBASE y CONEXION A LA B.D.
PATH=$PATH:/opt/c430/bin:. ; export PATH
SYBASE_OCS=OCS-15_0; export SYBASE_OCS
PATH=$PATH:.:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 02 CRO):$(paths.sh 02 BIN); export PATH
GE_USER=$(usuario.sh) ; 
GE_PASSWORD=$(password.sh); 
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh); 
GE_HOSTNAME=`hostname`; 
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME
SYBASE=$(sybase.sh); 
DSQUERY=$(servidor.sh); 
USER=$(base.sh); 
export  SYBASE DSQUERY USER

creaarchivo="$(paths.sh 04 CRO)/creaArchivoCDF.sh"
# extrae la Fecha del Sistema

FechaHoy=`date "+%Y%m%d"`
#FechaHoy="20121031"

echo " La fecha del Dia de hoy es : $FechaHoy"

#       FUNCION PARA EXECUTAR UN COMANDO SQL POR PARAMETRO 

ExecSQL(){                   
isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE -b<<EOF
set nocount on
go
$*
go
EOF
}

proc=`ps -fea | grep -v 'grep' | grep -c creaArchivoCDF.sh`
if [ $proc -gt 0 ]
then
   echo " El proceso creaArchivoCDF.sh se encuentra en ejecucion "
   exit 1           
fi

#while [ 1 ]
#do
	ExecSQL "select getdate()" > /dev/null  #valida conexion a Sybase
	if [ $? -ne 0 ]
	then
		    echo "FALLO LA CONEXION A SYBASE VERIFIQUE VARIABLES DE AMBIENTE"
		    exit -1
	fi

	Archivos=`ExecSQL "SELECT count(*) FROM MTCPRO02 \
			   where pro_nomLogi = '$FechaHoy' \
			   and pro_estatus in ( 0, 4, 5, 7, 10 )"`

	if [ $Archivos -gt 0 ]
	then
                    Fecha=`date "+%Y%m%d:%H%M"`
		    echo "$Fecha : El PROCESO YA HA SIDO EJECUTADO "
		    exit
	else
	            echo "En Ejecucion ........."
                    Fecha=`date "+%Y%m%d:%H%M"`
	            echo "${Fecha} : Se Ejecuta el Proceso ${creaarchivo} 0 0 0 "
		    ${creaarchivo} 0 0 0
	fi

#done
