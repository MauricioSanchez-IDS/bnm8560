IF OBJECT_ID('dbo.sp_ObtenDatosRep14') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenDatosRep14
    IF OBJECT_ID('dbo.sp_ObtenDatosRep14') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep14 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep14 >>>'
END
go
create proc sp_ObtenDatosRep14(@Prefijo int,@Banco smallint, @Empresa int,
                               @Por_Grupo smallint, @Grupo int, @Unidad varchar(15), @FechaAct varchar(8))
as
    DECLARE     @sql      varchar(16384),
                @Empresas varchar(16384),
                @CadUnids varchar(16384),
                @UnidadPadre varchar(15),
                @EmpresaMenor        int
Begin

  if @Por_Grupo = 1
   begin
    select @Empresas=NULL
    select @EmpresaMenor=0
    exec sp_ObtenEmpresasxGpo @Prefijo,@Banco,@Grupo,@Empresas output,@EmpresaMenor output
    select @CadUnids=NULL
    select @UnidadPadre=NULL
    exec sp_ObtenUnidadesxEmpresa @Prefijo,@Banco,@EmpresaMenor,@Unidad,@CadUnids output,@UnidadPadre output
   end
  else
   begin
    select @CadUnids=NULL
    select @UnidadPadre=NULL
    exec sp_ObtenUnidadesxEmpresa @Prefijo,@Banco,@Empresa,@Unidad,@CadUnids output,@UnidadPadre output
   end

  select @sql=@sql +  " select "
  select @sql=@sql +  " case when c.eje_centro_c = NULL then '" + ltrim(rtrim(@UnidadPadre)) + "' "
  select @sql=@sql +  " when convert(int, convert(char(6),c.eje_centro_c)) = 0 then '" + ltrim(rtrim(@UnidadPadre)) + "'"
  select @sql=@sql +  " else c.eje_centro_c end unidad, d.nivel_num nivel, "
  select @sql=@sql +  " convert(char(16),convert(varchar(4),a.eje_prefijo)+convert(varchar(2),a.gpo_banco)+ "
  select @sql=@sql +  " replicate('0',(select pgs_long_emp from MTCPGS01 g  "
  select @sql=@sql +  " where g.pgs_rep_prefijo = a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco) "
  select @sql=@sql +  " -char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num)))+ "
  select @sql=@sql +  " replicate('0',(select pgs_long_eje from MTCPGS01 g  "
  select @sql=@sql +  " where g.pgs_rep_prefijo = a.eje_prefijo and g.pgs_rep_banco = a.gpo_banco) "
  select @sql=@sql +  " -char_length(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num)))+ "
  select @sql=@sql +  " convert(varchar(1),a.eje_roll_over)+convert(varchar(1),a.eje_digit)) cuenta, "
  select @sql=@sql +  " convert(char(24),c.eje_nombre) nombre, isnull(ltrim(c.eje_num_nom),' ') nomina, "
  select @sql=@sql +  " c.eje_tipo_fac, c.eje_gen_pin_pla, c.eje_tipo_bloqueo, c.eje_tabla_mcc, "
  select @sql=@sql +  " c.eje_lim_dis_efec, c.eje_skip_payment into #mtcths01 "
  select @sql=@sql +  " from MTCTHS01 a, MTCEJE01 c, MTCUNI01 d "
  select @sql=@sql +  " where a.eje_prefijo = " + convert(char(4),@Prefijo)
  select @sql=@sql +  " and a.gpo_banco = " + convert(char(2),@Banco)
  if @Por_Grupo = 1
   begin
    select @sql=@sql + " and a.emp_num in " + ltrim(rtrim(@Empresas))
   end
  else
   begin
    select @sql=@sql + " and a.emp_num = " + convert(char(5),@Empresa)
   end
  select @sql=@sql +  " and a.eje_prefijo = c.eje_prefijo "
  select @sql=@sql +  " and a.gpo_banco = c.gpo_banco "
  select @sql=@sql +  " and a.emp_num = c.emp_num "
  select @sql=@sql +  " and a.eje_num = c.eje_num "


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

  select @sql=@sql +  " order by a.eje_prefijo,a.gpo_banco,a.emp_num,nivel,a.eje_num "

  select @sql=@sql +  " update  #mtcths01 set cuenta=map_cta_citi from #mtcths01, MTCMAP01 "
  select @sql=@sql +  " where convert(char(14),cuenta)=convert(char(14),map_cta_bnx) and map_estatus = ' ' "


  select @sql=@sql +  " select 'Grupo: " + convert(char(5),@Grupo)
  select @sql=@sql +  "                                                            REPORTE DE CALIFICACION"
  select @sql=@sql +  "                                                        Fec. Gen : " + @FechaAct
  select @sql=@sql +  " ' detalle into #Salida  "
  select @sql=@sql +  " insert #Salida values ('Empresa: " + convert(char(5),@Empresa)
  select @sql=@sql +  "                                                       Productos Comerciales Banamex') "
  if ((@Unidad is NULL) or (@Unidad = @UnidadPadre) or (@CadUnids = '()'))
   begin
     select @sql=@sql +  " insert #Salida values ('Unidad: " + convert(char(6),@UnidadPadre)
   end
  else
   begin
     select @sql=@sql +  " insert #Salida values ('Unidad: " + convert(char(6),@Unidad)
   end
  select @sql=@sql +  "                                                         Una Empresa de Citigroup"
  select @sql=@sql +  "                                                      Ident. Reporte: Rep14') "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida values (' UNIDAD NIVEL CUENTA           NOMBRE                     "
  select @sql=@sql +  "NOMINA          TIPO FACT    GENERACION PLASTICO   TIPO BLOQUEO   TABLA DE BLOQUEO  % DISPOSICION   SKIP PAYMENT') "
  select @sql=@sql +  " insert #Salida values ('------------------------------------------------------------"
  select @sql=@sql +  "--------------------------------------------------------------------------------------------------------------') "
  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql +  " select ' ' + convert(char(6),unidad) + ' ' + case when nivel = NULL then '     ' else "
  select @sql=@sql +  " ltrim(convert(char(5),nivel)) + replicate(' ',5 - char_length(ltrim(convert(char(5),nivel)))) end + ' ' + "
  select @sql=@sql +  " cuenta + ' ' + nombre + '   ' + convert(char(15),nomina) + ' ' + eje_tipo_fac + '            ' + "
  select @sql=@sql +  " convert(char(10),eje_gen_pin_pla) + '            ' + convert(char(14),eje_tipo_bloqueo) + ' ' + "
  select @sql=@sql +  " convert(char(17),eje_tabla_mcc) + ' ' + convert(char(15),eje_lim_dis_efec) + ' ' + convert(char(1),eje_skip_payment) "
  select @sql=@sql +  " from #mtcths01 "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida values ('EOF')"
  select @sql=@sql +  " select * from #Salida "

  EXECUTE (@sql)

end
go
EXEC sp_procxmode 'dbo.sp_ObtenDatosRep14','unchained'
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep14') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_ObtenDatosRep14 >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_ObtenDatosRep14 >>>'
go