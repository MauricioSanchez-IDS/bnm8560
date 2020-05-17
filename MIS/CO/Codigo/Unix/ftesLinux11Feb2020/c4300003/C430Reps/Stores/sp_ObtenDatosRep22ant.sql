IF OBJECT_ID('dbo.sp_ObtenDatosRep22') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenDatosRep22
    IF OBJECT_ID('dbo.sp_ObtenDatosRep22') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep22 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep22 >>>'
END
go
create proc sp_ObtenDatosRep22(@Prefijo int,@Banco smallint, @Empresa int, @Por_Tot smallint, @Por_Grupo smallint,
                               @Grupo int, @Unidad varchar(15), @FechaCorteMD varchar(4), @FechaAct varchar(8))
as
    DECLARE     @sql      varchar(16384),
                @Empresas varchar(16384),
                @CadUnids varchar(16384),
                @UnidadPadre varchar(15),
                @EmpresaMenor        int

Begin

  select @sql=" declare @numregs int "
  select @sql=@sql + " select "
  select @sql=@sql + " eje.eje_centro_c unidad, "
  select @sql=@sql + " uni.nivel_num as nivel,"
  select @sql=@sql + " convert(char(16), convert(char(4), eje.eje_prefijo)+"
  select @sql=@sql + " convert(char(2),eje.gpo_banco)+"
  select @sql=@sql + " replicate('0', ("
  select @sql=@sql + " select pgs_long_emp from MTCPGS01 a"
  select @sql=@sql + " where a.pgs_rep_prefijo = eje.eje_prefijo"
  select @sql=@sql + " and a.pgs_rep_banco = eje.gpo_banco)"
  select @sql=@sql + " -char_length(ltrim(rtrim(str(eje.emp_num)))))+"
  select @sql=@sql + " ltrim(rtrim(str(eje.emp_num)))+"
  select @sql=@sql + " replicate('0', ("
  select @sql=@sql + " select pgs_long_eje from MTCPGS01 b"
  select @sql=@sql + " where b.pgs_rep_prefijo = eje.eje_prefijo and"
  select @sql=@sql + " b.pgs_rep_banco = eje.gpo_banco)"
  select @sql=@sql + " -char_length(ltrim(rtrim(str(eje.eje_num)))))+"
  select @sql=@sql + " ltrim(rtrim(str(eje.eje_num)))+"
  select @sql=@sql + " convert(char(1),ths.eje_roll_over)+"
  select @sql=@sql + " convert(char(1),ths.eje_digit))     as cuenta,"
  select @sql=@sql + " eje.eje_nombre as nombre_ejecutivo,"
  select @sql=@sql + " ltrim(eje.eje_num_nom) as nomina,"
  select @sql=@sql + " ths.ths_limite_credito as limite,"
  select @sql=@sql + " ths.ths_situacion_cta + replicate(' ',9)    as situacion,"
  select @sql=@sql + " convert(money, (ths_vencidos_pagos_por_mes1 +"
  select @sql=@sql + " ths_vencidos_pagos_por_mes2 +"
  select @sql=@sql + " ths_vencidos_pagos_por_mes3 +"
  select @sql=@sql + " ths_vencidos_pagos_por_mes4 +"
  select @sql=@sql + " ths_vencidos_pagos_por_mes5 +"
  select @sql=@sql + " ths_vencidos_pagos_por_mes6)) as atrasos,"

  if @Por_Tot = 1
   begin
      select @sql=@sql + " convert(money, tot.sdo_ant) as saldo_anterior,"
      select @sql=@sql + " tot.pagos_abonos_hih as pagos,"
      select @sql=@sql + " convert(money, tot.sdo_nvo_hih ) as saldo_nuevo,"
      select @sql=@sql + " eje.emp_num, eje.eje_num, "
   end
  else
   begin
      select @sql=@sql + " convert(money, hih.hih_saldo_anterior) as saldo_anterior,"
      select @sql=@sql + " hih.hih_pagos_y_abonos as pagos,"

      if (@Prefijo = 5584 and @Banco = 26)
       begin
        select @sql=@sql + " convert(money, (hih.hih_saldo_anterior +"
        select @sql=@sql + " hih.hih_compras_y_disp + hih.hih_comisiones -"
        select @sql=@sql + " hih.hih_intereses + "
        select @sql=@sql + " ((-1) * hih.hih_pagos_y_abonos))) as saldo_nuevo, "
       end
      else
       begin
        select @sql=@sql + " convert(money, (hih.hih_saldo_anterior +"
        select @sql=@sql + " hih.hih_compras_y_disp + hih.hih_comisiones +"
        select @sql=@sql + " hih.hih_intereses "
        select @sql=@sql + " - hih.hih_pagos_y_abonos)) as saldo_nuevo,"
       end

      select @sql=@sql + " eje.emp_num, eje.eje_num, "
   end

  select @sql=@sql + " convert(numeric(12,2), 0.00) as consumos,"
  select @sql=@sql + " convert(numeric(12,2), 0.00) as disposiciones,"
  select @sql=@sql + " convert(numeric(12,2), 0.00) as comisiones,"
  select @sql=@sql + " convert(numeric(12,2), 0.00) as gastos,"
  select @sql=@sql + " convert(numeric(12,2), 0.00) as iva"

  select @sql=@sql + " into #TMP_REP_22"
  if @Por_Tot = 1
   begin
       select @sql=@sql + " from MTCTHS01 ths, MTCEJE01 eje, MTCTOT01 tot , MTCUNI01 uni"
   end
  else
   begin
       select @sql=@sql + " from MTCTHS01 ths, MTCEJE01 eje, MTCHIH01 hih , MTCUNI01 uni"
   end
  select @sql=@sql + " where eje.eje_prefijo = " + convert(char(4), @Prefijo)
  select @sql=@sql + " and eje.gpo_banco = " + convert(char(2), @Banco)

  if @Por_Grupo = 1
   begin
      select @Empresas=NULL
      select @EmpresaMenor=0
      exec sp_ObtenEmpresasxGpo @Prefijo,@Banco,@Grupo,@Empresas output,@EmpresaMenor output

      select @sql=@sql + " and eje.emp_num in " + @Empresas
   end
  else
   begin
      select @sql=@sql + " and eje.emp_num = " + convert(char(5), @Empresa)
      select @EmpresaMenor=@Empresa
   end


  select @sql=@sql + " and eje.eje_prefijo = ths.eje_prefijo"
  select @sql=@sql + " and eje.gpo_banco   = ths.gpo_banco"
  select @sql=@sql + " and eje.emp_num     = ths.emp_num"
  select @sql=@sql + " and eje.eje_num     = ths.eje_num"

  if @Por_Tot = 1
   begin
         select @sql=@sql + " and eje.eje_prefijo = tot.eje_prefijo"
         select @sql=@sql + " and eje.gpo_banco   = tot.gpo_banco"
         select @sql=@sql + " and eje.emp_num     = tot.emp_num"
         select @sql=@sql + " and eje.eje_num     = tot.eje_num"
   end
  else
   begin
         select @sql=@sql + " and eje.eje_prefijo = hih.eje_prefijo"
         select @sql=@sql + " and eje.gpo_banco   = hih.gpo_banco"
         select @sql=@sql + " and eje.emp_num     = hih.emp_num"
         select @sql=@sql + " and eje.eje_num     = hih.eje_num"
   end

  select @CadUnids=NULL
  select @UnidadPadre=NULL
  exec sp_ObtenUnidadesxEmpresa @Prefijo,@Banco,@EmpresaMenor,@Unidad,@CadUnids output,@UnidadPadre output

  if ((@Unidad is NULL) or (@Unidad = @UnidadPadre) or (@CadUnids = '()'))
   begin
     select @sql=@sql +  " and uni.eje_prefijo =* eje.eje_prefijo "
     select @sql=@sql +  " and uni.gpo_banco =* eje.gpo_banco "
     select @sql=@sql +  " and uni.emp_num =* eje.emp_num "
     select @sql=@sql +  " and uni.unit_id =* eje.eje_centro_c "
   end
  else
   begin
     select @sql=@sql +  " and uni.eje_prefijo = eje.eje_prefijo "
     select @sql=@sql +  " and uni.gpo_banco = eje.gpo_banco "
     select @sql=@sql +  " and uni.emp_num = eje.emp_num "
     select @sql=@sql +  " and uni.unit_id = eje.eje_centro_c "
     select @sql=@sql +  " and eje.eje_centro_c in " + ltrim(rtrim(@CadUnids))
   end

  select @sql=@sql + " and hih.hih_corte_md = " + @FechaCorteMD

  select @sql=@sql + " order by nivel, unidad, cuenta"
  select @sql=@sql + " select @numregs=@@rowcount "

  select @sql=@sql + " if @numregs > 0 "
  select @sql=@sql + " begin "
  select @sql=@sql + " select emp_num, eje_num, his_importe, tip_transaccion "
  select @sql=@sql + " into #tmp_his"
  select @sql=@sql + " from MTCHIS01, MTCTRA01"
  select @sql=@sql + " where eje_prefijo = " + convert(char(4), @Prefijo)
  select @sql=@sql + " and gpo_banco = " + convert(char(2), @Banco)

  if @Por_Grupo = 1
   begin
     select @sql=@sql + " and emp_num in " + @Empresas
   end
  else
   begin
     select @sql=@sql + " and emp_num = " + convert(char(5), @Empresa)
   end

  select @sql=@sql + " and his_transaccion = cve_transaccion"
  select @sql=@sql + " and tip_transaccion in ('compra', 'dispo', 'comis', 'gastCob', 'iva', 'interes' )"
  select @sql=@sql + " and his_mes_y_ciclo_corte = " + @FechaCorteMD

  select @sql=@sql + " select emp_num, eje_num, convert(money, sum(his_importe)) as consumos"
  select @sql=@sql + " into #consumos from #tmp_his where tip_transaccion = 'compra'"
  select @sql=@sql + " group by emp_num, eje_num"

  select @sql=@sql + " select emp_num, eje_num, convert(money, sum(his_importe)) as disposiciones"
  select @sql=@sql + " into #disposiciones from #tmp_his where tip_transaccion = 'dispo'"
  select @sql=@sql + " group by emp_num, eje_num"

  select @sql=@sql + " select emp_num, eje_num, convert(money, sum(his_importe)) as comisiones"
  select @sql=@sql + " into #comisiones from #tmp_his where tip_transaccion = 'comis'"
  select @sql=@sql + " group by emp_num, eje_num"

  select @sql=@sql + " select emp_num, eje_num, convert(money, sum(his_importe)) as gastos"
  select @sql=@sql + " into #gastos from #tmp_his where tip_transaccion = 'gastCob'"
  select @sql=@sql + " group by emp_num, eje_num"

  select @sql=@sql + " select emp_num, eje_num, convert(money, sum(his_importe)) as iva"
  select @sql=@sql + " into #iva from #tmp_his where tip_transaccion = 'iva'"
  select @sql=@sql + " group by emp_num, eje_num"

  select @sql=@sql + " update #TMP_REP_22 set #TMP_REP_22.consumos = #consumos.consumos"
  select @sql=@sql + " from #TMP_REP_22, #consumos where #TMP_REP_22.emp_num = #consumos.emp_num"
  select @sql=@sql + " and #TMP_REP_22.eje_num = #consumos.eje_num"

  select @sql=@sql + " update #TMP_REP_22 set #TMP_REP_22.disposiciones = #disposiciones.disposiciones"
  select @sql=@sql + " from #TMP_REP_22, #disposiciones where #TMP_REP_22.emp_num = #disposiciones.emp_num"
  select @sql=@sql + " and #TMP_REP_22.eje_num = #disposiciones.eje_num"

  select @sql=@sql + " update #TMP_REP_22 set #TMP_REP_22.comisiones = #comisiones.comisiones"
  select @sql=@sql + " from #TMP_REP_22, #comisiones where #TMP_REP_22.emp_num = #comisiones.emp_num"
  select @sql=@sql + " and #TMP_REP_22.eje_num = #comisiones.eje_num"

  select @sql=@sql + " update #TMP_REP_22 set #TMP_REP_22.gastos = #gastos.gastos"
  select @sql=@sql + " from #TMP_REP_22, #gastos where #TMP_REP_22.emp_num = #gastos.emp_num"
  select @sql=@sql + " and #TMP_REP_22.eje_num = #gastos.eje_num"

  select @sql=@sql + " update #TMP_REP_22 set #TMP_REP_22.iva = #iva.iva"
  select @sql=@sql + " from #TMP_REP_22, #iva where #TMP_REP_22.emp_num = #iva.emp_num"
  select @sql=@sql + " and #TMP_REP_22.eje_num = #iva.eje_num"

  select @sql=@sql + " update #TMP_REP_22 set cuenta = map_cta_citi from #TMP_REP_22, MTCMAP01 where "
  select @sql=@sql + " convert(char(14),cuenta) = convert(char(14),map_cta_bnx) and map_estatus = ' '"

  select @sql=@sql + " update #TMP_REP_22 set situacion = 'NORMAL' from #TMP_REP_22 where situacion = ' '"
  select @sql=@sql + " update #TMP_REP_22 set situacion = 'CANCEL CS' from #TMP_REP_22 where situacion = 'C'"
  select @sql=@sql + " update #TMP_REP_22 set situacion = 'CANCEL SS' from #TMP_REP_22 where situacion = 'E'"
  select @sql=@sql + " update #TMP_REP_22 set situacion = 'SOBREGIRO' from #TMP_REP_22 where situacion = 'O'"
  select @sql=@sql + " update #TMP_REP_22 set situacion = 'PROB COBRO' from #TMP_REP_22 where situacion = 'P'"
  select @sql=@sql + " update #TMP_REP_22 set situacion = 'ATRASADA' from #TMP_REP_22 where situacion = 'D'"

  select @sql=@sql +  " select 'Grupo: " + convert(char(5),@Grupo) + "' + "
  select @sql=@sql +  " replicate (' ',84) + 'CONCENTRADO EMPRESA EJECUTIVO' + "
  select @sql=@sql +  " replicate (' ',80) + 'Fec. Gen : " + @FechaAct + " ' detalle into #Salida  "
  select @sql=@sql +  " insert #Salida values ('Empresa: " + convert(char(5),@Empresa) + "' + "
  select @sql=@sql +  " replicate (' ',82) + 'Productos Comerciales Banamex') "

  if ((@Unidad is NULL) or (@Unidad = @UnidadPadre) or (@CadUnids = '()'))
   begin
     select @sql=@sql +  " insert #Salida values ('Unidad: " + convert(char(6),@UnidadPadre) + "' + "
   end
  else
   begin
     select @sql=@sql +  " insert #Salida values ('Unidad: " + convert(char(6),@Unidad) + "' + "
   end
  select @sql=@sql +  " replicate (' ',84) + 'Una Empresa de Citigroup' + "
  select @sql=@sql +  " replicate (' ',81) + 'Ident. Reporte: Rep22') "
  select @sql=@sql +  " insert #Salida values (' ')"
  if (@Prefijo = 5584 and @Banco = 26)
   begin
    select @sql=@sql +  " insert #Salida values (' UNIDAD NIVEL CUENTA           NOMBRE                                   NOMINA           LI"
    select @sql=@sql +  "MITE DE GASTOS        SC     ATRASOS   SALDO ANT    CONSUMOS    DISP EFE       PAGOS    COMISION RENDIMIENTO         IVA   SAL NUEVO') "
   end
  else
   begin
    select @sql=@sql +  " insert #Salida values (' UNIDAD NIVEL CUENTA           NOMBRE EJECUTIVO                         NOMINA             "
    select @sql=@sql +  "LIMITE CREDITO        SC     ATRASOS   SALDO ANT    CONSUMOS    DISP EFE       PAGOS    COMISION    GAST COB         IVA   SAL NUEVO') "
   end
  select @sql=@sql +  " insert #Salida values ('-------------------------------------------------------------------------------------------"
  select @sql=@sql +  "-------------------------------------------------------------------------------------------------------------------------------------') "
  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql +  " select ' ' + convert(char(6),unidad) + ' ' + + case when nivel = NULL then '     ' else "
  select @sql=@sql +  " ltrim(convert(char(5),nivel)) + replicate(' ',5 - char_length(ltrim(convert(char(5),nivel)))) end + ' ' + cuenta + ' ' + "
  select @sql=@sql +  " convert(char(45),nombre_ejecutivo) + isnull(convert(char(14),nomina),'              ') "
  select @sql=@sql +  " + ' ' + right('               '+(rtrim(convert(char(15),limite))),15) + right('          '+(rtrim(situacion)),10) + "
  select @sql=@sql +  " convert(char(12),atrasos) + convert(char(12),saldo_anterior) + convert(char(12),convert(money,consumos)) + "
  select @sql=@sql +  " convert(char(12),convert(money,disposiciones)) + convert(char(12),convert(money,pagos)) + "
  select @sql=@sql +  " convert(char(12),convert(money,comisiones)) + convert(char(12),convert(money,gastos)) + "
  select @sql=@sql +  " convert(char(12),convert(money,iva)) + convert(char(12),saldo_nuevo)"
  select @sql=@sql +  " from #TMP_REP_22 order by nivel, unidad, cuenta"
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql + " select '       TOTALES PARA UNIDAD: ' + convert(char(6),unidad) + replicate (' ',82) + "
  select @sql=@sql +  " convert(char(12),sum(atrasos)) + convert(char(12),sum(saldo_anterior)) + convert(char(12),convert(money,sum(consumos))) + "
  select @sql=@sql +  " convert(char(12),convert(money,sum(disposiciones))) + convert(char(12),convert(money,sum(pagos))) + "
  select @sql=@sql +  " convert(char(12),convert(money,sum(comisiones))) + convert(char(12),convert(money,sum(gastos))) + "
  select @sql=@sql +  " convert(char(12),convert(money,sum(iva))) + convert(char(12),sum(saldo_nuevo))"
  select @sql=@sql +  " from #TMP_REP_22 group by nivel,unidad "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql + " select '       TOTALES DEL REPORTE: " + convert(char(6),@UnidadPadre) + "' + replicate (' ',82) + "
  select @sql=@sql +  " convert(char(12),sum(atrasos)) + convert(char(12),sum(saldo_anterior)) + convert(char(12),convert(money,sum(consumos))) + "
  select @sql=@sql +  " convert(char(12),convert(money,sum(disposiciones))) + convert(char(12),convert(money,sum(pagos))) + "
  select @sql=@sql +  " convert(char(12),convert(money,sum(comisiones))) + convert(char(12),convert(money,sum(gastos))) + "
  select @sql=@sql +  " convert(char(12),convert(money,sum(iva))) + convert(char(12),sum(saldo_nuevo))"
  select @sql=@sql +  " from #TMP_REP_22 "
  select @sql=@sql +  " insert #Salida values ('EOF')"
  select @sql=@sql +  " select * from #Salida "
  select @sql=@sql +  " end "

  EXECUTE (@sql)

end
go
EXEC sp_procxmode 'dbo.sp_ObtenDatosRep22','unchained'
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep22') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_ObtenDatosRep22 >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_ObtenDatosRep22 >>>'
go