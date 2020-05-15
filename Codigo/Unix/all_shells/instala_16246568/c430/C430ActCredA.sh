#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Actualiza el campo de credito acumulado de la empresa 
# Version               : 1.0
# Autor                 :


PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 01 CRO)
DIR_TEMP=$(paths.sh 01 TMP)
export PATH DIR_TEMP

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export  SYBASE DSQUERY


echo  Se actualiza el prefijo y banco : $1 $2

isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -b<<EOF
update MTCEMP01 set emp_acum_cred = 
((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a 
where a.eje_prefijo = MTCEMP01.eje_prefijo
and a.gpo_banco = MTCEMP01.gpo_banco
and a.emp_num = MTCEMP01.emp_num and a.eje_num > 0) - 
(select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d 
where c.eje_prefijo = MTCEMP01.eje_prefijo
and c.gpo_banco = MTCEMP01.gpo_banco
and c.emp_num = MTCEMP01.emp_num and c.eje_num > 0 and
c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco
and c.emp_num=d.emp_num and c.eje_num=d.eje_num and
(d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) 
where eje_prefijo = $1 and gpo_banco = $2
go
EOF

