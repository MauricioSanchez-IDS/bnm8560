IF OBJECT_ID('dbo.sp_ObtenDatosRep24') IS NOT NULL
BEGIN

    DROP PROCEDURE dbo.sp_ObtenDatosRep24
    IF OBJECT_ID('dbo.sp_ObtenDatosRep24') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep24 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep24 >>>'
END
go
create proc sp_ObtenDatosRep24(@Prefijo int,@Banco smallint, @Empresa int, @Por_Tot smallint, @Por_Grupo smallint,
                               @Grupo int, @Unidad varchar(15), @fechaIniAMD varchar(8), @fechaFinAMD varchar(8),
                               @fechaCorteMD varchar(4), @FechaAct varchar(8))
as
    DECLARE     @sql      varchar(16384),
                @Empresas varchar(16384),
                @CadUnids varchar(16384),
                @UnidadPadre varchar(15),
                @EmpresaMenor        int,
                @Result              int
Begin

  select @sql= " select  "
  select @sql=@sql + "convert(char(16),  "
  select @sql=@sql + "convert(char(4),x.eje_prefijo)+  "
  select @sql=@sql + "convert(char(2),x.gpo_banco)+  "
  select @sql=@sql + "replicate('0',(SELECT pgs_long_emp  "
  select @sql=@sql + "FROM MTCPGS01 a  "
  select @sql=@sql + "WHERE a.pgs_rep_prefijo = x.eje_prefijo and  "
  select @sql=@sql + "a.pgs_rep_banco = x.gpo_banco)  "
  select @sql=@sql + "-char_length(ltrim(rtrim(str(x.emp_num)))))+  "
  select @sql=@sql + "ltrim(rtrim(str(x.emp_num)))+  "
  select @sql=@sql + "replicate('0',(SELECT pgs_long_eje  "
  select @sql=@sql + "FROM MTCPGS01 b  "
  select @sql=@sql + "WHERE b.pgs_rep_prefijo = x.eje_prefijo and  "
  select @sql=@sql + "b.pgs_rep_banco = x.gpo_banco)  "
  select @sql=@sql + "-char_length(ltrim(rtrim(str(x.eje_num)))))+  "
  select @sql=@sql + "ltrim(rtrim(str(x.eje_num)))+  "
  select @sql=@sql + "convert(char(1),x.eje_roll_over)+  "
  select @sql=@sql + "convert(char(1),x.eje_digit)) as cuenta,  "
  select @sql=@sql + "x.b01_neg_num_neg,  "
  select @sql=@sql + "convert(money, x.his_importe) as his_importe,  "
  select @sql=@sql + "x.his_proceso_amd  "
  select @sql=@sql + "into #TMP1_REPORTEMA  "
  select @sql=@sql + "from MTCHIS01 x  "
  select @sql=@sql + "where  "
  select @sql=@sql + "x.eje_prefijo = " + convert(char(4), @Prefijo)
  select @sql=@sql + " and x.gpo_banco = " + convert(char(2), @Banco)

  if @Por_Grupo = 1
   begin
    select @Empresas=NULL
    select @EmpresaMenor=0
    exec sp_ObtenEmpresasxGpo @Prefijo,@Banco,@Grupo,@Empresas output,@EmpresaMenor output
    select @sql=@sql + " and x.emp_num in " + @Empresas
   end
  else
   begin
    select @sql=@sql + " and x.emp_num = " + convert(char(5), @Empresa)
    select @EmpresaMenor=@Empresa
   end

  if ((convert(numeric,@fechaIniAMD) <> 0) and (convert(numeric,@fechaFinAMD) <> 0))
   begin
    select @sql=@sql + " and x.his_proceso_amd between " + convert(char(8),@fechaIniAMD)
    select @sql=@sql + " and " + convert(char(8),@fechaFinAMD)
   end

  if(convert(numeric,@fechaCorteMD) <> 0)
   begin
    select @sql=@sql + " and x.his_mes_y_ciclo_corte = " + convert(char(4),@fechaCorteMD)
   end

  select @sql=@sql + " and x.his_transaccion in  "
  select @sql=@sql + "(select cve_transaccion from MTCTRA01  "
  select @sql=@sql + "where  "
  select @sql=@sql + "tip_transaccion = 'compra')  "
  select @sql=@sql + "order by b01_neg_num_neg  "

  select @CadUnids=NULL
  select @UnidadPadre=NULL
  exec sp_ObtenUnidadesxEmpresa @Prefijo,@Banco,@EmpresaMenor,@Unidad,@CadUnids output,@UnidadPadre output

  select @sql=@sql + " select  "
  select @sql=@sql + "convert(char(16),  "
  select @sql=@sql + "convert(char(4),eje.eje_prefijo)+  "
  select @sql=@sql + "convert(char(2),eje.gpo_banco)+  "
  select @sql=@sql + "replicate('0',(SELECT pgs_long_emp  "
  select @sql=@sql + "FROM MTCPGS01 a  "
  select @sql=@sql + "WHERE a.pgs_rep_prefijo = eje.eje_prefijo and  "
  select @sql=@sql + "a.pgs_rep_banco = eje.gpo_banco)  "
  select @sql=@sql + "-char_length(ltrim(rtrim(str(eje.emp_num)))))+  "
  select @sql=@sql + "ltrim(rtrim(str(eje.emp_num)))+  "
  select @sql=@sql + "replicate('0',(SELECT pgs_long_eje  "
  select @sql=@sql + "FROM MTCPGS01 b  "
  select @sql=@sql + "WHERE b.pgs_rep_prefijo = eje.eje_prefijo and  "
  select @sql=@sql + "b.pgs_rep_banco = eje.gpo_banco)  "
  select @sql=@sql + "-char_length(ltrim(rtrim(str(eje.eje_num)))))+  "
  select @sql=@sql + "ltrim(rtrim(str(eje.eje_num)))+  "
  select @sql=@sql + "convert(char(1),ths.eje_roll_over)+  "
  select @sql=@sql + "convert(char(1),ths.eje_digit)) as cuenta,  "
  select @sql=@sql + "eje.eje_nombre,  "
  select @sql=@sql + " case when eje.eje_centro_c = NULL then '" + ltrim(rtrim(@UnidadPadre)) + "'"
  select @sql=@sql + " when convert(int, convert(char(6),eje.eje_centro_c)) = 0 then '" + ltrim(rtrim(@UnidadPadre)) + "'"
  select @sql=@sql + " else eje.eje_centro_c end eje_centro_c,  "
  select @sql=@sql + "ltrim(rtrim(eje.eje_num_nom)) as eje_num_nom,   "
  select @sql=@sql + "eje.eje_prefijo,   "
  select @sql=@sql + "eje.gpo_banco,   "
  select @sql=@sql + "eje.emp_num   "
  select @sql=@sql + "into #TMP2_REPORTEMA  "
  select @sql=@sql + "from MTCEJE01 eje, MTCTHS01 ths  "
  select @sql=@sql + "where  "
  select @sql=@sql + "eje.eje_prefijo = " + convert(char(4), @Prefijo)
  select @sql=@sql + " and eje.gpo_banco = " + convert(char(2), @Banco)

  if @Por_Grupo = 1
   begin
    select @sql=@sql + " and eje.emp_num in " + @Empresas
   end
  else
   begin
    select @sql=@sql + " and eje.emp_num = " + convert(char(5), @Empresa)
   end
  select @sql=@sql + " and eje.eje_num <> 0  "

  select @sql=@sql + " and eje.eje_prefijo = ths.eje_prefijo "
  select @sql=@sql + " and eje.gpo_banco = ths.gpo_banco "
  select @sql=@sql + " and eje.emp_num  = ths.emp_num "
  select @sql=@sql + " and eje.eje_num  = ths.eje_num "

  select @sql=@sql + " select  "
  select @sql=@sql + "neg.b06_acd_num_acd,  "
  select @sql=@sql + "act.b06_acd_des_acd,  "
  select @sql=@sql + "eje.eje_centro_c,  "
  select @sql=@sql + "uni.nivel_num,  "
  select @sql=@sql + "eje.cuenta,  "
  select @sql=@sql + "eje.eje_nombre,  "
  select @sql=@sql + "eje.eje_num_nom,  "
  select @sql=@sql + "his.his_proceso_amd,  "
  select @sql=@sql + "neg.b01_neg_nom_neg,  "
  select @sql=@sql + "his.his_importe  "
  select @sql=@sql + "into #TMP_REP_MERCHANTANALYSIS  "
  select @sql=@sql + "from #TMP1_REPORTEMA his, #TMP2_REPORTEMA eje, MTCNEG01 neg, MTCUNI01 uni, MTCACT01 act "
  select @sql=@sql + "where  "
  select @sql=@sql + "neg.b01_neg_num_neg = his.b01_neg_num_neg and  "
  select @sql=@sql + "substring(eje.cuenta,1,14) = substring(his.cuenta,1,14) and  "

  if ((@Unidad is NULL) or (@Unidad = @UnidadPadre) or (@CadUnids = '()'))
   begin
     select @sql=@sql +  " uni.eje_prefijo =* eje.eje_prefijo "
     select @sql=@sql +  " and uni.gpo_banco =* eje.gpo_banco "
     select @sql=@sql +  " and uni.emp_num =* eje.emp_num "
     select @sql=@sql +  " and uni.unit_id =* eje.eje_centro_c "
   end
  else
   begin
     select @sql=@sql +  " uni.eje_prefijo = eje.eje_prefijo "
     select @sql=@sql +  " and uni.gpo_banco = eje.gpo_banco "
     select @sql=@sql +  " and uni.emp_num = eje.emp_num "
     select @sql=@sql +  " and uni.unit_id = eje.eje_centro_c "
     select @sql=@sql +  " and eje.eje_centro_c in " + ltrim(rtrim(@CadUnids))
   end

  select @sql=@sql + " and neg.b06_acd_num_acd *= act.b06_acd_num_acd  "

  select @sql=@sql + "update #TMP_REP_MERCHANTANALYSIS  "
  select @sql=@sql + "set cuenta = map.map_cta_citi  "
  select @sql=@sql + "from #TMP_REP_MERCHANTANALYSIS tmp, MTCMAP01 map  "
  select @sql=@sql + "where convert(char(14),tmp.cuenta)=convert(char(14),map.map_cta_bnx) and map.map_estatus = ' '  "

  select @sql=@sql +  " select 'Grupo: " + convert(char(5),@Grupo) + "' + replicate(' ',64) + "
  select @sql=@sql +  " 'REPORTE DE NEGOCIOS POR CATEGORIA' + replicate(' ',56) + 'Fec. Gen : " + @FechaAct
  select @sql=@sql +  " ' detalle into #Salida  "
  select @sql=@sql +  " insert #Salida values ('Empresa: " + convert(char(5),@Empresa) + "' + replicate(' ',64) + "
  select @sql=@sql +  "'Productos Comerciales Banamex') "
  select @sql=@sql +  " insert #Salida values ('Unidad: " + convert(char(6),@UnidadPadre) + "' + replicate(' ',67) + "
  select @sql=@sql +  "'Una Empresa de Citigroup' + replicate(' ',58) + 'Ident. Reporte: Rep24') "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida values (' SIC    DESCRIPCION SIC                UNIDAD NIVEL CUENTA           NOMBRE"
  select @sql=@sql +  "                                   NOMINA      FECHA PRO    NEGOCIO                                   MONTO') "
  select @sql=@sql +  " insert #Salida values ('--------------------------------------------------------------------"
  select @sql=@sql +  "--------------------------------------------------------------------------------------------------------------------') "
  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql +  " select ' ' + convert(char(6),b06_acd_num_acd) + ' ' + isnull(convert(char(30),b06_acd_des_acd),'                              ') + ' ' + "
  select @sql=@sql +  " convert(char(6),eje_centro_c) + ' ' + case when nivel_num = NULL then '     ' else "
  select @sql=@sql +  " ltrim(convert(char(5),nivel_num)) + replicate(' ',5 - char_length(ltrim(convert(char(5),nivel_num)))) end + ' ' + cuenta + ' ' + "
  select @sql=@sql +  " convert(char(40),eje_nombre) + ' ' + isnull(convert(char(12),eje_num_nom),'            ') "
  select @sql=@sql +  " + ' ' + convert(char(8),his_proceso_amd) + '    ' + convert(char(36),b01_neg_nom_neg) + ' ' + "
  select @sql=@sql +  " convert(char(12),his_importe) "
  select @sql=@sql +  " from #TMP_REP_MERCHANTANALYSIS order by b06_acd_num_acd, nivel_num, eje_centro_c, cuenta "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida values ('TOTALES:')"
  select @sql=@sql +  " insert #Salida values (' SIC    DESCRIPCION SIC                # TRANSACCIONES       MONTO TOTAL')"
  select @sql=@sql +  " insert #Salida values ('------------------------------------------------------------------------')"
  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql +  " select distinct ' ' + convert(char(6),b06_acd_num_acd) + ' ' + "
  select @sql=@sql +  " isnull(convert(char(30),b06_acd_des_acd),'                              ') + '    ' + "
  select @sql=@sql +  " right('       '+(rtrim(convert(char(7),count(b06_acd_num_acd)))),7) + '          ' + convert(char(12),sum(his_importe)) "
  select @sql=@sql +  " from #TMP_REP_MERCHANTANALYSIS group by b06_acd_num_acd order by b06_acd_num_acd"
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql +  " select ' GRAN TOTAL:' + replicate(' ',30) + "
  select @sql=@sql +  " right('       '+(rtrim(convert(char(7),count(cuenta)))),7) + '          ' + convert(char(12),sum(his_importe)) "
  select @sql=@sql +  " from #TMP_REP_MERCHANTANALYSIS  "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida values ('EOF')"
  select @sql=@sql +  " select * from #Salida "

  EXECUTE (@sql)

end
go
EXEC sp_procxmode 'dbo.sp_ObtenDatosRep24','unchained'
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep24') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_ObtenDatosRep24 >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_ObtenDatosRep24 >>>'
go