#!/bin/ksh
# Sistema: c430
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Directorio: $(paths.sh 01 BIN)
# Procedimiento: valida.sh
# Versisn y fecha: 1.0
# Autor: Jose Alberto Garcia Garcia    03/11/2003
# proposito: Shell para consultar la carga diaria de archivos al sistema c430

CargaS111 () {
isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -X <<EOF
declare @mesDia char(4)
select @mesDia = substring(convert(char(8),dateadd(dd, -1, getdate()),112),5,4)
select $1 from MTCPRO01
where pro_nomarch in
('EHIS'+@mesDia,'EHIH'+@mesDia,'ETHS'+@mesDia,'EPLA'+@mesDia)
and pro_estatus = 0
go
EOF
}
resultado=`CargaS111 "count(distinct pro_nomarch)" | sed -n '/^ *[0-9]/s/ //gp'`
case "$resultado" in 
	0)	echo "LA CARGA NO SE HA REALIZADO AUN"
		Res=2
                ;;
	4)	echo "LA CARGA SE HA REALIZADO CORRECTAMENTE"
                Res=0 
                ;;
	1|2|3)
		echo "LA CARGA NO SE HA REALIZADO COMPLETAMENTE"
                CargaS111 "pro_mensaje" | sed '1,2d;$d'
                Res=1 
                ;;
	*)	echo "NO SE HA PODIDO CONSULTAR LA BASE DE DATOS"
		Res=3 
                ;;
esac
exit $Res
