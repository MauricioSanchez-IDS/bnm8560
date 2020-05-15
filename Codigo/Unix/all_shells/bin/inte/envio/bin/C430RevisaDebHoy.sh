#!/bin/ksh

##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema: c430
# Directorio: $(paths.sh 03 CRO)
# Procedimiento: C430RevisaDebHoy.sh
# Descripción:
# Versión y fecha: 1.0
# Autor: YMF    02/02/08
# Modificaciones: 
# proposito: Revisa si corrio el proceso de reportes de debito de HOY           
#            en la tabla MTCPRO03                                     
# Modificacion : Jun / 2012 --- HP - RSP --- Migracion a B11.23       

SYBASE_OCS=OCS-15_0
export SYBASE_OCS
PATH=$PATH:/opt/c430/000/bin
PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 03 CRO)
export PATH

GE_USER=$(usuario.sh)
GE_PASSWORD=$(password.sh)
GE_DBASE=$(base.sh)
GE_SERVER=$(servidor.sh)
GE_HOSTNAME=`uname -n`
export GE_USER GE_PASSWORD GE_DBASE GE_SERVER GE_HOSTNAME


# Variables de Sybase
	SYBASE=$(sybase.sh)
	DSQUERY=$(servidor.sh)
export SYBASE DSQUERY 

var=`isql -U$GE_USER -P$GE_PASSWORD -S$GE_SERVER -D$GE_DBASE <<EOF
select * from MTCPRO03
where pro_nomarch ="ReportesDebito$1"
go 
EOF`
var=`echo $var | grep "(1 row affected)" | wc -l`
echo $var
