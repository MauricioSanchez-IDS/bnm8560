IF OBJECT_ID('dbo.sp_ObtenDatosRep26') IS NOT NULL
BEGIN

    DROP PROCEDURE dbo.sp_ObtenDatosRep26
    IF OBJECT_ID('dbo.sp_ObtenDatosRep26') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep26 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep26 >>>'
END
go
create proc sp_ObtenDatosRep26(@Prefijo int,@Banco smallint, @Empresa int, @Por_Grupo smallint, @Grupo int,
                               @Unidad varchar(15), @fechaIniAMD varchar(8), @fechaFinAMD varchar(8),
                               @fechaCorteMD varchar(4), @FechaAct varchar(8))
as
    DECLARE     @sql      varchar(16384),
                @Empresas varchar(16384),
                @CadUnids varchar(16384),
                @UnidadPadre varchar(15),
                @EmpresaMenor        int,
                @rep25               int,
                @mcc1         varchar(4),
                @mcc2         varchar(4),
                @mcc3         varchar(4)

Begin

  select @mcc1="6011"
  select @mcc2="6010"
  select @mcc3="0000"

  select @sql= " select  "
  select @sql=@sql + " a.eje_prefijo,  "
  select @sql=@sql + " a.gpo_banco,  "
  select @sql=@sql + " a.emp_num,  "
  select @sql=@sql + " a.eje_num,  "
  select @sql=@sql + " c.eje_centro_c unidad,  "
  select @sql=@sql + " d.nivel_num nivel,  "
  select @sql=@sql + " convert(char(16),convert(varchar(4),a.eje_prefijo)+convert(varchar(2),a.gpo_banco)+  "
  select @sql=@sql + " replicate('0',(select pgs_long_emp from MTCPGS01 g   "
  select @sql=@sql + " where g.pgs_rep_prefijo = a.eje_prefijo  "
  select @sql=@sql + " and g.pgs_rep_banco = a.gpo_banco)  "
  select @sql=@sql + " -char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num)))+  "
  select @sql=@sql + " replicate('0',(select pgs_long_eje from MTCPGS01 g   "
  select @sql=@sql + " where g.pgs_rep_prefijo = a.eje_prefijo  "
  select @sql=@sql + " and g.pgs_rep_banco = a.gpo_banco)  "
  select @sql=@sql + " -char_length(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num)))+  "
  select @sql=@sql + " convert(varchar(1),a.eje_roll_over)+convert(varchar(1),a.eje_digit)) cuenta,  "
  select @sql=@sql + " substring(c.eje_nombre,1,24) nombre,  "
  select @sql=@sql + " isnull(ltrim(rtrim(c.eje_num_nom)),'0') nomina,  "
  select @sql=@sql + " isnull(c.eje_cta_contable, ' ') cta_contable,  "
  select @sql=@sql + " '   ' as ciudad, "
  select @sql=@sql + " '   ' as estado "
  select @sql=@sql + " into #mtcths01  "
  select @sql=@sql + " from MTCTHS01 a, MTCEJE01 c, MTCUNI01 d  "
  select @sql=@sql + " where a.eje_prefijo= " + convert(char(4), @Prefijo)
  select @sql=@sql + " and a.gpo_banco = " + convert(char(2), @Banco)
  if @Por_Grupo = 1
   begin
    select @Empresas=NULL
    select @EmpresaMenor=0
    exec sp_ObtenEmpresasxGpo @Prefijo,@Banco,@Grupo,@Empresas output,@EmpresaMenor output
    select @sql=@sql + " and a.emp_num in " + @Empresas
   end
  else
   begin
    select @sql=@sql + " and a.emp_num = " + convert(char(5), @Empresa)
    select @EmpresaMenor=@Empresa
   end
  select @sql=@sql + " and a.eje_prefijo = c.eje_prefijo  "
  select @sql=@sql + " and a.gpo_banco = c.gpo_banco  "
  select @sql=@sql + " and a.emp_num = c.emp_num  "
  select @sql=@sql + " and a.eje_num = c.eje_num  "

  select @CadUnids=NULL
  select @UnidadPadre=NULL
  exec sp_ObtenUnidadesxEmpresa @Prefijo,@Banco,@EmpresaMenor,@Unidad,@CadUnids output,@UnidadPadre output

  if ((@Unidad is NULL) or (@Unidad = @UnidadPadre) or (@CadUnids = '()'))
   begin
     select @sql=@sql +  " and d.eje_prefijo =* c.eje_prefijo "
     select @sql=@sql +  " and d.gpo_banco =* c.gpo_banco "
     select @sql=@sql +  " and d.emp_num =* c.emp_num "
     select @sql=@sql +  " and d.unit_id =* c.eje_centro_c "
   end
  else
   begin
     select @sql=@sql +  " and d.eje_prefijo = c.eje_prefijo "
     select @sql=@sql +  " and d.gpo_banco = c.gpo_banco "
     select @sql=@sql +  " and d.emp_num = c.emp_num "
     select @sql=@sql +  " and d.unit_id = c.eje_centro_c "
     select @sql=@sql +  " and c.eje_centro_c in " + ltrim(rtrim(@CadUnids))
   end

  select @sql=@sql + " order by a.eje_prefijo,a.gpo_banco,a.emp_num,nivel,a.eje_num  "

  select @sql=@sql + " select  "
  select @sql=@sql + " d.unidad,  "
  select @sql=@sql + " d.nivel,  "
  select @sql=@sql + " d.cuenta,  "
  select @sql=@sql + " d.nombre,  "
  select @sql=@sql + " d.nomina,  "
  select @sql=@sql + " d.cta_contable,  "
  select @sql=@sql + " a.his_valor_amd fecha_valor,  "
  select @sql=@sql + " a.his_proceso_amd fecha_proceso,  "
  select @sql=@sql + " isnull(a.his_negocio_leyenda,' ') nombre_negocio,  "
  select @sql=@sql + " substring(right('000000'+rtrim(convert(char(6),  "
  select @sql=@sql + " isnull(b.b06_acd_num_acd,0))),6),3,4) mcc,  "
  select @sql=@sql + " str(isnull(a.his_importe,0),12,2) pesos,  "
  select @sql=@sql + " str(isnull(a.his_dolares,0),12,2) dolares,  "
  select @sql=@sql + " isnull(a.his_pais,' ') pais,  "
  select @sql=@sql + " d.ciudad ciudad,  "
  select @sql=@sql + " d.estado estado,  "
  select @sql=@sql + " 'M' valor_M,  "
  select @sql=@sql + " convert(char(4),isnull(a.his_transaccion,0)) as tra,  "
  select @sql=@sql + " substring(str(a.his_referencia_a,7,0),5, 1) pos_5,  "
  select @sql=@sql + " substring(str(a.his_referencia_a,7,0),6, 2) pos_67,  "
  select @sql=@sql + " a.his_referencia_a,  "
  select @sql=@sql + " c.signo_transaccion,  "
  select @sql=@sql + " isnull(b.b01_neg_num_neg,0) numero_negocio,  "
  select @sql=@sql + " c.tip_transaccion tip_trans  "
  select @sql=@sql + " into #TMP_REP_DIACYCLE  "
  select @sql=@sql + " from MTCHIS01 a, MTCNEG01 b, MTCTRA01 c, #mtcths01 d  "
  select @sql=@sql + " where a.eje_prefijo= " + convert(char(4), @Prefijo)
  select @sql=@sql + " and a.gpo_banco= " + convert(char(2), @Banco)
  if @Por_Grupo = 1
   begin
    select @sql=@sql + " and a.emp_num in " + @Empresas
   end
  else
   begin
    select @sql=@sql + " and a.emp_num = " + convert(char(5), @Empresa)
    select @EmpresaMenor=@Empresa
   end
  select @sql=@sql + " and a.eje_prefijo=d.eje_prefijo  "
  select @sql=@sql + " and a.gpo_banco=d.gpo_banco  "
  select @sql=@sql + " and a.emp_num=d.emp_num  "
  select @sql=@sql + " and a.eje_num = d.eje_num  "

  if ((convert(numeric,@fechaIniAMD) <> 0) and (convert(numeric,@fechaFinAMD) <> 0))
   begin
    select @sql=@sql + " and a.his_proceso_amd between " + convert(char(8),@fechaIniAMD)
    select @sql=@sql + " and " + convert(char(8),@fechaFinAMD)
   end

  if (convert(numeric,@fechaCorteMD) <> 0)
   begin
    select @sql=@sql + " and a.his_mes_y_ciclo_corte = " + convert(char(4),@fechaCorteMD)
   end

  select @sql=@sql + " and a.b01_neg_num_neg *= b.b01_neg_num_neg  "
  select @sql=@sql + " and a.his_transaccion = c.cve_transaccion  "
  select @sql=@sql + " order by d.nivel,convert(float,substring(d.unidad,1,5)), d.eje_num  "

  select @sql=@sql + " update #TMP_REP_DIACYCLE set mcc= '"
  select @sql=@sql + @mcc1
  select @sql=@sql + "' where (pais='MEX' or pais='') and tip_trans='dispo'  "

  select @sql=@sql + " update #TMP_REP_DIACYCLE set mcc= '"
  select @sql=@sql + @mcc2
  select @sql=@sql + "' where  "
  select @sql=@sql + " ( (pais='MEX' or pais='') and tip_trans='dispo' ) and  "
  select @sql=@sql + " ( (pos_5 = '0') or ((pos_5 != '0') and (pos_67  = '96')) )  "

  select @sql=@sql + " update #TMP_REP_DIACYCLE set mcc= '"
  select @sql=@sql + @mcc3
  select @sql=@sql + "' where  "
  select @sql=@sql + " ( (pais='MEX' or pais='') and   "
  select @sql=@sql + "   (tip_trans='abono' or tip_trans='devolucion' or   "
  select @sql=@sql + "    (numero_negocio = 0 and tip_trans !='dispo') ) )  "

  select @sql=@sql + " update #TMP_REP_DIACYCLE set estado=pais, pais='USA'  "
  select @sql=@sql + " where char_length (pais) = 2  "
  select @sql=@sql + " and pais <> '   '  "
  select @sql=@sql + " and pais <> 'MEX'  "

  select @sql=@sql + " update #TMP_REP_DIACYCLE set mcc=substring(nombre_negocio,23,4)  "
  select @sql=@sql + " where (pais <> 'MEX' and pais <> '')  "

  select @sql=@sql + " update #TMP_REP_DIACYCLE set mcc= '"
  select @sql=@sql + @mcc2
  select @sql=@sql + "' where (pais <> 'MEX' and pais <> '') and   "
  select @sql=@sql + " ( mcc = '0000' or (mcc <> '0000' and tip_trans='dispo') )  "

  select @sql=@sql + " update #TMP_REP_DIACYCLE set mcc= '"
  select @sql=@sql + @mcc3
  select @sql=@sql + "' where (pais <> 'MEX' and pais <> '') and   "
  select @sql=@sql + " (mcc <> '0000' and tip_trans='devolucion')   "

  select @sql=@sql + " update  #TMP_REP_DIACYCLE  set pesos = str(convert(float,pesos) * -1,12,2),   "
  select @sql=@sql + " dolares=str(convert(float,dolares) * -1,12,2)  "
  select @sql=@sql + " where signo_transaccion='C'  "

  select @sql=@sql + " select 'Unidad          Nivel Numero de Cuenta Nombre                   "
  select @sql=@sql + "Nomina          Cuenta Contable                          Fec.Tra. Fec.Pro. "
  select @sql=@sql + "Merchant                   SIC  Monto Pesos  Monto Dolar  Pais Cd  Edo $ Tran' "
  select @sql=@sql +  " detalle into #Salida  "
  select @sql=@sql + " insert #Salida (detalle) "
  select @sql=@sql + " select convert(char(6),unidad) + replicate(' ',10) + case when nivel = NULL then '     ' else "
  select @sql=@sql +  " ltrim(convert(char(5),nivel)) + replicate(' ',5 - char_length(ltrim(convert(char(5),nivel)))) end + ' ' + "
  select @sql=@sql + " cuenta + ' ' + convert(char(24),nombre) + ' ' + convert(char(15),nomina) + ' ' + "
  select @sql=@sql + " convert(char(40),cta_contable) + ' ' + convert(char(8),fecha_valor) + ' ' +  "
  select @sql=@sql + " convert(char(8),fecha_proceso) + ' ' + convert(char(26),nombre_negocio) + ' ' + "
  select @sql=@sql + " convert(char(4),mcc) + ' ' + convert(char(12),pesos) + ' ' +  convert(char(12),dolares)"
  select @sql=@sql + " + ' ' + convert(char(3),pais) + '  ' + convert(char(3),ciudad) + ' ' +  "
  select @sql=@sql + " convert(char(3),estado) + ' ' + convert(char(1),valor_M) + ' ' + convert(char(4),tra) "
  select @sql=@sql + " from #TMP_REP_DIACYCLE order by nivel,convert(float,substring(unidad,1,5)),cuenta,fecha_proceso,fecha_valor "
  select @sql=@sql + " insert #Salida values (' ')"
  select @sql=@sql + " insert #Salida values ('EOF')"
  select @sql=@sql + " select * from #Salida "

  EXECUTE (@sql)

end
go
EXEC sp_procxmode 'dbo.sp_ObtenDatosRep26','unchained'
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep26') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_ObtenDatosRep26 >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_ObtenDatosRep26 >>>'
go