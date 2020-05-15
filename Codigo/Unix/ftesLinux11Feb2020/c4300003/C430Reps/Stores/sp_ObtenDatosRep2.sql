IF OBJECT_ID('dbo.sp_ObtenDatosRep2') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenDatosRep2
    IF OBJECT_ID('dbo.sp_ObtenDatosRep2') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep2 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep2 >>>'
END
go
create proc sp_ObtenDatosRep2(@Prefijo int, @Banco smallint, @Empresa int, @Unidad varchar(15), @FechaAct varchar(8))
as
    DECLARE     @sql             varchar(16384),
                @Pagina                     int

Begin
select @Pagina=1

select @sql=" declare @Ctapapa varchar(16), @NomEmp varchar(35) "
select @sql=@sql +  " select c.eje_prefijo, c.gpo_banco, c.emp_num, c.eje_num, eje_nombre, eje_calle, eje_col, eje_pob, eje_cp,"
select @sql=@sql +  "  eje_limcred, eje_centro_c, "
select @sql=@sql +  " case when ths_situacion_cta = ' ' then 'Activa       ' "
select @sql=@sql +  "      when ths_situacion_cta = 'C' then 'Cancelada c/S' "
select @sql=@sql +  "      when ths_situacion_cta = 'E' then 'Cancelada s/S' "
select @sql=@sql +  "      when ths_situacion_cta = 'O' then 'Sobregiro    ' "
select @sql=@sql +  "      when ths_situacion_cta = 'P' then 'Prob Cobro   ' "
select @sql=@sql +  "      when ths_situacion_cta = 'D' then 'Atrasada     ' "
select @sql=@sql +  " else "
select @sql=@sql +  "      'No Identificad' "
select @sql=@sql +  " end "
select @sql=@sql +  " as eje_estatus, "
select @sql=@sql +  " convert(char(16), convert(char(4), d.eje_prefijo) + convert(char(2), d.gpo_banco) + "
select @sql=@sql +  " replicate('0', ( select pgs_long_emp from MTCPGS01 a "
select @sql=@sql +  " where a.pgs_rep_prefijo = d.eje_prefijo and "
select @sql=@sql +  " a.pgs_rep_banco = d.gpo_banco) "
select @sql=@sql +  " -char_length(ltrim(rtrim(str(d.emp_num)))))+ "
select @sql=@sql +  " ltrim(rtrim(str(d.emp_num)))+ "
select @sql=@sql +  " replicate('0', (select pgs_long_eje from MTCPGS01 b "
select @sql=@sql +  " where b.pgs_rep_prefijo = d.eje_prefijo and "
select @sql=@sql +  " b.pgs_rep_banco = d.gpo_banco) "
select @sql=@sql +  " -char_length(ltrim(rtrim(str(d.eje_num)))))+ "
select @sql=@sql +  " ltrim(rtrim(str(d.eje_num)))+ "
select @sql=@sql +  " convert(char(1),d.eje_roll_over) + convert(char(1),d.eje_digit)) as eje_cuenta "
select @sql=@sql +  " into #mtcejeths "
select @sql=@sql +  " from MTCEJE01 c, MTCTHS01 d "
select @sql=@sql +  " where c.eje_prefijo = " + convert(char(4),@Prefijo) 
select @sql=@sql +  " and c.gpo_banco = " + convert(char(2),@Banco)
select @sql=@sql +  " and c.emp_num = " + convert(char(5),@Empresa)
select @sql=@sql +  " and c.eje_prefijo = d.eje_prefijo "
select @sql=@sql +  " and c.gpo_banco = d.gpo_banco "
select @sql=@sql +  " and c.emp_num = d.emp_num "
select @sql=@sql +  " and c.eje_num = d.eje_num "

select @sql=@sql +  " select @NomEmp=eje_nombre, @Ctapapa=eje_cuenta from #mtcejeths "
select @sql=@sql +  " where eje_prefijo = " + convert(char(4),@Prefijo) 
select @sql=@sql +  " and gpo_banco = " + convert(char(2),@Banco) 
select @sql=@sql +  " and emp_num = " + convert(char(5),@Empresa) 
select @sql=@sql +  " and eje_num = 0 "

select @sql=@sql +  " select convert(char(16),@Ctapapa) + '    - ' + convert(char(35),@NomEmp) + '      "
select @sql=@sql +  "CITIBANK CARD CENTRE                 FILE DATE-" + @FechaAct + " PAGE:     " + convert(char(5),@Pagina)
select @sql=@sql +  "' + replicate (' ',125) detalle into #Salida "
select @sql=@sql +  " insert #Salida values ('" + convert(char(15),@Unidad) + "  - ' + convert(char(35),@NomEmp) + '        "
select @sql=@sql +  "ACCOUNT LISTING REPORT                PROC DATE-" + @FechaAct + " ERDR0202 ')" 
select @sql=@sql +  " insert #Salida values ('       NAME                                          ADDRESS"
select @sql=@sql +  "                        CREDIT LIMIT         UNIT ID      ACCT      ') "
select @sql=@sql +  " insert #Salida values ('       ACCT NBR                                                        "
select @sql=@sql +  "                                               STATUS     ') "
select @sql=@sql +  " insert #Salida values ('  ---------------------------------------------------------------------"
select @sql=@sql +  "-------------------------------------------------------------') "
select @sql=@sql +  " insert #Salida (detalle) "
select @sql=@sql +  " select '  ' + convert(char(35),eje_nombre) + '      ' + convert(char(35),eje_calle) + '      ' + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(9),eje_limcred))),9) + '.00           ' + "
select @sql=@sql +  " convert(char(5),eje_centro_c) + '     ' + convert(char(13),eje_estatus) + char(10) + "
select @sql=@sql +  " '  ' + eje_cuenta + '                         ' + eje_col + char(10) + "
select @sql=@sql +  " replicate (char(9),5) + '   ' + rtrim(eje_pob) + ', ' + convert(char(5),eje_cp) "
select @sql=@sql +  " + char(10) + '  ' + char(10) from #mtcejeths "
select @sql=@sql +  " insert #Salida values (' ')"
select @sql=@sql +  " insert #Salida values ('EOF')"
select @sql=@sql +  " select * from #Salida "

EXECUTE (@sql)

end
go
EXEC sp_procxmode 'dbo.sp_ObtenDatosRep2','unchained'
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep2') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_ObtenDatosRep2 >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_ObtenDatosRep2 >>>'
go

