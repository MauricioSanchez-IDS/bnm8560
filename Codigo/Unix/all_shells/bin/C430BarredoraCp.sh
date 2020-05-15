#!/bin/ksh
#__HP changes for Linux migration - start
# echo on linux disable interpretation of backslash escape so honor the backslash
alias echo="echo -e"
#__HP changes for linux migration - end


# Sistema               : C430_000
# Directorio            : /opt/c430/000/bin/inte/envio/crontabs
# Descripcion           : Barredora del C430 de Tarjeta Corporativa
# Version               : 1.0
# Autor                 :


PATH=$PATH:/opt/c430/000/bin
export PATH
SYBASE_OCS=OCS-15_0
export SYBASE_OCS

PATH=$PATH:$(sybase.sh)/OCS-15_0/bin:$(paths.sh 01 CRO)
DIR_TEMP=$(paths.sh 01 TMP)
export PATH DIR_TEMP       

exec 1>>$(paths.sh 01 LOG)/C430BarredoraC.log  
exec 2>&1                                  

SYBASE=$(sybase.sh)
DSQUERY=$(servidor.sh)
export  SYBASE DSQUERY 

echo Inicia Barredora Tarjeta Corporativa ...

echo Inicia Respaldo de Tablas ...

./C430ContenidoT.sh MTCEMP01 $DIR_TEMP/emp01r.txt
./C430ContenidoT.sh MTCEJE01 $DIR_TEMP/eje01r.txt
./C430ContenidoT.sh MTCURP01 $DIR_TEMP/urp01r.txt
./C430ContenidoT.sh MTCUNI01 $DIR_TEMP/uni01r.txt
./C430ContenidoT.sh MTCCLI01 $DIR_TEMP/cli01r.txt
./C430ContenidoT.sh MTCBRP01 $DIR_TEMP/brp01r.txt

echo Finaliza Respaldo de Tablas 

isql -U$(usuario.sh) -P$(password.sh) -S$(servidor.sh) -D$(base.sh) -b -w 132 -o $DIR_TEMP/SalBarredoraC.txt <<EOF

declare @fec        datetime
declare @fechahoy   datetime
declare @fechaint   int
declare @fechast    varchar(8)
select @fechahoy=getdate()
select @fechahoy
select @fec=dateadd(dd,-3,@fechahoy)
select @fechast=convert(char(4),datepart(yy,@fec))+
replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(mm,@fec))))))+
ltrim(rtrim(convert(char(2),datepart(mm,@fec))))+
replicate('0',2-char_length(ltrim(rtrim(convert(char(2),datepart(dd,@fec))))))+
ltrim(rtrim(convert(char(2),datepart(dd,@fec))))
select @fechaint=convert(int,@fechast)
select @fechaint

print 'Crea Tabla temporal con ctas concatenadas de Tarjetahabientes (C430) en MTCEJE01'
select
(convert(char(4),a.eje_prefijo)+convert(char(2),a.gpo_banco)+
replicate('0',(select pgs_long_emp from MTCPGS01 h
where h.pgs_rep_prefijo=a.eje_prefijo and h.pgs_rep_banco=a.gpo_banco)
-char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num)))+
replicate('0',(select pgs_long_eje from MTCPGS01 h
where h.pgs_rep_prefijo=a.eje_prefijo and h.pgs_rep_banco=a.gpo_banco)
-char_length(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num))))
as Num_Cuenta, a.eje_prefijo,a.gpo_banco,a.emp_num,a.eje_num,a.eje_roll_over,
a.eje_digit,a.eje_nombre,a.eje_nom_gra into #CTAS_EJE from MTCEJE01 a
Where (a.eje_prefijo <> 5584 and a.gpo_banco <> 26) and
      (a.eje_prefijo <> 4074 and a.gpo_banco <> 58) and
      (a.eje_prefijo <> 4807 and a.gpo_banco <> 90) and
      a.eje_fecha_alta < @fechaint
go

print 'Crea Tabla temporal con ctas concatenadas de Tarjetahabientes (S111) en MTCTHS01'
select
(convert(char(4),a.eje_prefijo)+convert(char(2),a.gpo_banco)+
replicate('0',(select pgs_long_emp from MTCPGS01 h
where h.pgs_rep_prefijo=a.eje_prefijo and h.pgs_rep_banco=a.gpo_banco)
-char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num)))+
replicate('0',(select pgs_long_eje from MTCPGS01 h
where h.pgs_rep_prefijo=a.eje_prefijo and h.pgs_rep_banco=a.gpo_banco)
-char_length(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num))))
as Num_Cuenta into #CTAS_THS from MTCTHS01 a
Where (a.eje_prefijo <> 5584 and a.gpo_banco <> 26) and                       
      (a.eje_prefijo <> 4074 and a.gpo_banco <> 58) and
      (a.eje_prefijo <> 4807 and a.gpo_banco <> 90)                             
go

print 'Crea Tabla temporal CTAS_A_BORRAR con cuentas a Borrar'
select a.Num_Cuenta,a.eje_prefijo,a.gpo_banco,a.emp_num,a.eje_num,a.eje_roll_over,
a.eje_digit,a.eje_nombre,a.eje_nom_gra into #CTAS_A_BORRAR from #CTAS_EJE a
where a.Num_Cuenta not in (select b.Num_Cuenta from #CTAS_THS b)
go

print 'Elimina ctas de Tarjetahabientes en MTCEJE01'
delete MTCEJE01 from #CTAS_A_BORRAR a, MTCEJE01 b
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco and  
a.emp_num=b.emp_num and a.eje_num=b.eje_num and a.eje_num <> 0
go

print 'Cuentas de Empresas que no se eliminaron por tener cuentas hijas'     
select distinct convert(char(14),a.Num_Cuenta)+convert(char(1),a.eje_roll_over)+
convert(char(1),a.eje_digit) from #CTAS_A_BORRAR a, MTCEJE01 b                  
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco                   
and a.emp_num=b.emp_num and a.eje_num=0 and b.eje_num <> 0                      
go                                                                              

print 'Elimina ctas de Empresas de CTAS_A_BORRAR que todavia tienen ctas hijas en MTCEJE01'
delete #CTAS_A_BORRAR from #CTAS_A_BORRAR a, MTCEJE01 b
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco 
and a.emp_num=b.emp_num and a.eje_num=0 and b.eje_num <> 0
go

print 'Elimina ctas de Empresas de MTCEJE01 que estan en CTAS_A_BORRAR'
delete MTCEJE01 from #CTAS_A_BORRAR a, MTCEJE01 b
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco 
and a.emp_num=b.emp_num and a.eje_num=b.eje_num and a.eje_num=0
go

print 'Elimina Empresas de Unidades'
delete MTCUNI01 from #CTAS_A_BORRAR a, MTCUNI01 b
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco 
and a.emp_num=b.emp_num and a.eje_num=0
go

print 'Elimina Empresas de Reportes'
delete MTCURP01 from #CTAS_A_BORRAR a, MTCURP01 b
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco 
and a.emp_num=b.emp_num and a.eje_num=0
go

print 'Elimina Empresas de Clientes Bancanet'
delete MTCCLI01 from #CTAS_A_BORRAR a, MTCCLI01 b
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco 
and a.emp_num=b.emp_num and a.eje_num=0
go

print 'Elimina Empresas de BRP'
delete MTCBRP01 from #CTAS_A_BORRAR a, MTCBRP01 b
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco 
and a.emp_num=b.emp_num and a.eje_num=0
go

print 'Elimina cuentas de Empresas'
delete MTCEMP01 from #CTAS_A_BORRAR a, MTCEMP01 b
where a.eje_prefijo=b.eje_prefijo and a.gpo_banco=b.gpo_banco 
and a.emp_num=b.emp_num and a.eje_num=0
go

print ' '
print '                         REPORTE DE CUENTAS ELIMINADAS'
print ' '
print ' Num. Cuenta      Afinid Nom. Largo                                    Nom. Corto'
select convert(char(14),a.Num_Cuenta)+convert(char(1),a.eje_roll_over)+
convert(char(1),a.eje_digit)+" "+
convert(char(6),replicate('0',(select pgs_long_emp from MTCPGS01 h
where h.pgs_rep_prefijo=a.eje_prefijo and h.pgs_rep_banco=a.gpo_banco)
-char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num))))+" "+
convert(char(45),a.eje_nombre)+" "+convert(char(26),a.eje_nom_gra) from #CTAS_A_BORRAR a
go

EOF

echo Finaliza Barredora Tarjeta Corporativa

