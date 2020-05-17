Use M111
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep7') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenDatosRep7
    IF OBJECT_ID('dbo.sp_ObtenDatosRep7') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep7 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep7 >>>'
END
go
create proc sp_ObtenDatosRep7(@Prefijo int, @Banco smallint, @Empresa int, @Unidad varchar(15), @FechaAct varchar(8))
as
    DECLARE     @sql             varchar(16384),
                @Pagina                     int

Begin
select @Pagina=1

select @sql=" declare @Ctapapa varchar(16), @NomEmp varchar(35) "
select @sql=@sql +  " select e.eje_prefijo, e.gpo_banco, e.emp_num, e.eje_num, eje_nombre, ths_ant_saldo, ths_vencidos_pagos_por_mes1,"
select @sql=@sql +  "  ths_vencidos_pagos_por_mes2, ths_vencidos_pagos_por_mes3, ths_vencidos_pagos_por_mes4, "
select @sql=@sql +  "  ths_vencidos_pagos_por_mes5, ths_vencidos_pagos_por_mes6, "
select @sql=@sql +  "  (ths_vencidos_pagos_por_mes1 + ths_vencidos_pagos_por_mes2 + ths_vencidos_pagos_por_mes3 + "
select @sql=@sql +  "   ths_vencidos_pagos_por_mes4 + ths_vencidos_pagos_por_mes5 + ths_vencidos_pagos_por_mes6)as total_past_due, "
select @sql=@sql +  " convert(char(16), convert(char(4), t.eje_prefijo) + convert(char(2), t.gpo_banco) + "
select @sql=@sql +  " replicate('0', ( select pgs_long_emp from MTCPGS01 a "
select @sql=@sql +  " where a.pgs_rep_prefijo = t.eje_prefijo and "
select @sql=@sql +  " a.pgs_rep_banco = t.gpo_banco) "
select @sql=@sql +  " -char_length(ltrim(rtrim(str(t.emp_num)))))+ "
select @sql=@sql +  " ltrim(rtrim(str(t.emp_num)))+ "
select @sql=@sql +  " replicate('0', (select pgs_long_eje from MTCPGS01 b "
select @sql=@sql +  " where b.pgs_rep_prefijo = t.eje_prefijo and "
select @sql=@sql +  " b.pgs_rep_banco = t.gpo_banco) "
select @sql=@sql +  " -char_length(ltrim(rtrim(str(t.eje_num)))))+ "
select @sql=@sql +  " ltrim(rtrim(str(t.eje_num)))+ "
select @sql=@sql +  " convert(char(1),t.eje_roll_over) + convert(char(1),t.eje_digit)) as eje_cuenta "
select @sql=@sql +  " into #mtcejeths "
select @sql=@sql +  " from MTCEJE01 e, MTCTHS01 t "
select @sql=@sql +  " where e.eje_prefijo = " + convert(char(4),@Prefijo) 
select @sql=@sql +  " and e.gpo_banco = " + convert(char(2),@Banco)
select @sql=@sql +  " and e.emp_num = " + convert(char(5),@Empresa)
select @sql=@sql +  " and e.eje_prefijo = t.eje_prefijo "
select @sql=@sql +  " and e.gpo_banco = t.gpo_banco "
select @sql=@sql +  " and e.emp_num = t.emp_num "
select @sql=@sql +  " and e.eje_num = t.eje_num "
select @sql=@sql +  " and ths_vencidos_pagos_por_mes1 > 0 "

select @sql=@sql +  " select @NomEmp=eje_nombre, @Ctapapa=eje_cuenta from #mtcejeths "
select @sql=@sql +  " where eje_prefijo = " + convert(char(4),@Prefijo) 
select @sql=@sql +  " and gpo_banco = " + convert(char(2),@Banco) 
select @sql=@sql +  " and emp_num = " + convert(char(5),@Empresa) 
select @sql=@sql +  " and eje_num = 0 "

select @sql=@sql +  " select convert(char(16),@Ctapapa) + '    - ' + convert(char(35),@NomEmp) + '      "
select @sql=@sql +  "CITIBANK CARD CENTRE                 FILE DATE-" + @FechaAct + " PAGE:     " + convert(char(5),@Pagina)
select @sql=@sql +  "' + replicate(' ',125) detalle into #Salida "
select @sql=@sql +  " insert #Salida values ('" + convert(char(15),@Unidad) + "  - ' + convert(char(35),@NomEmp) + '         "
select @sql=@sql +  "ACCOUNT AGING REPORT                 PROC DATE-" + @FechaAct + " ERDR0504 ')" 
select @sql=@sql +  " insert #Salida values ('                                              >>----------------------------- "
select @sql=@sql +  "  AMOUNT PAST DUE  -----------------------------  << ') "
select @sql=@sql +  " insert #Salida values ('NAME/                      CURRENT BALANCE       1 STMNT        2 STMNT"
select @sql=@sql +  "        3 STMNT        4 STMNT        5 STMNT        6 STMNT') "
select @sql=@sql +  " insert #Salida values ('ACCOUNT NUMBER                                                         "
select @sql=@sql +  "                                              TOTAL PAST DUE') "
select @sql=@sql +  " insert #Salida values ('-----------------------------------------------------------------------"
select @sql=@sql +  "------------------------------------------------------------') "
select @sql=@sql +  " insert #Salida (detalle) "
select @sql=@sql +  " select ' ' + convert(char(27),eje_nombre) + ' ' + convert(char(12),convert(money,ths_ant_saldo)) + '   ' +" 
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),ths_vencidos_pagos_por_mes1))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),ths_vencidos_pagos_por_mes2))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),ths_vencidos_pagos_por_mes3))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),ths_vencidos_pagos_por_mes4))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),ths_vencidos_pagos_por_mes5))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),ths_vencidos_pagos_por_mes6))),12) + "
select @sql=@sql +  " char(10) + ' ' + eje_cuenta + replicate(char(9),12) + '       ' + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),total_past_due))),12) "
select @sql=@sql +  " + char(10) + '  ' + char(10) from #mtcejeths "
select @sql=@sql +  " insert #Salida values (' ')"
select @sql=@sql +  " insert #Salida (detalle) "
select @sql=@sql +  " select 'TOTAL FOR :                  ' + convert(char(12),convert(money,sum(ths_ant_saldo))) + '   ' +" 
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),sum(ths_vencidos_pagos_por_mes1)))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),sum(ths_vencidos_pagos_por_mes2)))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),sum(ths_vencidos_pagos_por_mes3)))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),sum(ths_vencidos_pagos_por_mes4)))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),sum(ths_vencidos_pagos_por_mes5)))),12) + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),sum(ths_vencidos_pagos_por_mes6)))),12) + "
select @sql=@sql +  " char(10) + convert(char(35),@NomEmp) + replicate(char(9),10) + '       ' + "
select @sql=@sql +  " right('         '+(rtrim(convert(char(12),(sum(ths_vencidos_pagos_por_mes1)+sum(ths_vencidos_pagos_por_mes2)+"
select @sql=@sql +  " sum(ths_vencidos_pagos_por_mes3)+sum(ths_vencidos_pagos_por_mes4)+sum(ths_vencidos_pagos_por_mes5)+"
select @sql=@sql +  " sum(ths_vencidos_pagos_por_mes6))))),12) "
select @sql=@sql +  " + char(10) + '  ' + char(10) from #mtcejeths "
select @sql=@sql +  " insert #Salida values ('                                                      ********  END OF REPORT  ********')"
select @sql=@sql +  " select * from #Salida "

EXECUTE (@sql)

end
go
EXEC sp_procxmode 'dbo.sp_ObtenDatosRep7','unchained'
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep7') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_ObtenDatosRep7 >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_ObtenDatosRep7 >>>'
go

