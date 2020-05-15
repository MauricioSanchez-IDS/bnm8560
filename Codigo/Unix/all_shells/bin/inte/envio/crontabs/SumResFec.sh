# Shell para que apartir de una fecha se reste o sume dias
# Tambien para que apartir de un fecha se reste o sume un mes
##__HP changes for Linux migration - start -change /usr/bin/ksh to /bin/ksh -end

#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end
# Los Parametros son los siguientes:
#
# $1 = Fecha en el formato AAAAMMDD
# $2 = Identificador de mes = M o dia = D
# $3 = Num de dias o meses si son hacia atras deberan ser negativos ej. -1 o -10
#

#echo "** Parametros de Entrada **"
#echo Fecha Entrada AAAAMMDD : $1
#echo Indicador de Dia o Mes : $2
#echo Numero de dias o meses : $3
#set -x

LD_LIBRARY_PATH=/optware/sybase/ase157sp104/ASE-15_0/lib:/optware/sybase/ase157sp104/DataAccess64/ODBC/lib:/optware/sybase/ase157sp104/DataAccess/ODBC/lib:/optware/sybase/ase157sp104/OCS-15_0/lib:/optware/sybase/ase157sp104/OCS-15_0/lib3p64:/optware/sybase/ase157sp104/OCS-15_0/lib3p::/opt/c046/105/lib

export LD_LIBRARY_PATH

isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -X -o fecSal.txt <<EOF

declare @fec       datetime
declare @fechapdt  datetime
declare @fechapst  varchar(8)
declare @fechast   varchar(8)
declare @indicador varchar(1)
declare @salida    varchar(25)
declare @diaomes   int

select @fechapst=convert(char(8),"$1")
select @indicador=convert(char(1),"$2")
select @diaomes=convert(int,$3)

select @fechapdt=convert(datetime,@fechapst)
if @indicador = "D" 
 begin
   select @fec=dateadd(dd,@diaomes,@fechapdt)
 end
else
  if @indicador = "M" 
   begin
    select @fec=dateadd(mm,@diaomes,@fechapdt)
   end
  else
   begin
     return
   end

select @fechast=convert(char(4),datepart(yy,@fec))+
replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(mm,@fec))))))+
ltrim(rtrim(convert(char(2),datepart(mm,@fec))))+
replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(dd,@fec))))))+
ltrim(rtrim(convert(char(2),datepart(dd,@fec))))
select @salida="FecSal=" + @fechast
select @salida
go
EOF

fechaSal=`cat fecSal.txt | grep FecSal | cut -c9-`
if [ "$fechaSal" = "" -o "$fechaSal" = "        " ]
then
  echo "00000000"
else
  echo $fechaSal
fi

