#!/bin/ksh
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end

# Sistema               : C430_000
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Ejecuta cualquier comando en formato libre 
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


echo Inicia Accion ...


comando="insert into MTCEJE01 select a.eje_prefijo, a.gpo_banco, a.emp_num, a.eje_num, a.eje_roll_over, a.eje_digit, a.ths_nombre, '$5', 0, '$6', ' ', 0, a.ths_nombre, a.ths_direccion_1, a.ths_direccion_2, a.ths_direccion_3, a.ths_zona_postal, a.ths_codigo_postal, convert(char(10),a.ths_tel_particular), convert(char(10),a.ths_tel_oficina), convert(char(8),a.ths_tel_extension) , '0', a.ths_limite_credito, 1, 'T', ' ', ths_sexo, convert(char(4),ths_sucursal), convert(char(4),ths_sucursal_promotora), 'E', convert(char(4),ths_act_subact), 'DF', '', '', '', '', '', 0, '', '', convert(int,ths_ind_gen_pla), ths_porc_disp, 'I', '$7', convert(int,ths_skip_payment), ths_tabla_mcc, 'P', ' ', '1', 'USUFORZ', convert(int,convert(char(20), getdate(),112)), convert(int,convert(char(20), getdate(),112)), 1200, $8, 0, '', 2 from MTCTHS01 a where a.eje_prefijo=$1 and a.gpo_banco=$2 and a.emp_num=$3 and a.eje_num=$4 "

ActualizaTabla ()
{
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -b<<EOF
$comando
go
EOF
}

ActualizaTabla

echo Finaliza Accion

