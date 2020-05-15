IF OBJECT_ID('dbo.sp_ObtenDatosRep13') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenDatosRep13
    IF OBJECT_ID('dbo.sp_ObtenDatosRep13') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep13 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep13 >>>'
END
go
create proc sp_ObtenDatosRep13(@Prefijo int,@Banco smallint, @Empresa int,
                               @Por_Grupo smallint, @Grupo int, @FechaAct varchar(8))
as
    DECLARE     @sql           varchar(16384),
                @Empresas      varchar(16384),
                @CadUnids      varchar(16384),
                @Unidad           varchar(15),
                @UnidadPadre      varchar(15),
                @EmpresaMenor             int,
                @Result                   int

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
    select @Unidad=NULL
    select @UnidadPadre=NULL
    exec sp_ObtenUnidadesxEmpresa @Prefijo,@Banco,@Empresa,@Unidad,@CadUnids output,@UnidadPadre output
    if @CadUnids = '()'
     begin
        Return 2
     end
   end

  select @sql=" declare @numregs int "
  select @sql=@sql +  " select a.eje_num, "
  select @sql=@sql +  " convert(char(16),convert(varchar(4),a.eje_prefijo)+convert(varchar(2),a.gpo_banco)+ "
  select @sql=@sql +  " replicate('0',(select pgs_long_emp from MTCPGS01 g  "
  select @sql=@sql +  " where g.pgs_rep_prefijo = a.eje_prefijo "
  select @sql=@sql +  " and g.pgs_rep_banco = a.gpo_banco) "
  select @sql=@sql +  " -char_length(ltrim(rtrim(str(a.emp_num)))))+ltrim(rtrim(str(a.emp_num)))+ "
  select @sql=@sql +  " replicate('0',(select pgs_long_eje from MTCPGS01 g  "
  select @sql=@sql +  " where g.pgs_rep_prefijo = a.eje_prefijo "
  select @sql=@sql +  " and g.pgs_rep_banco = a.gpo_banco) "
  select @sql=@sql +  " -char_length(ltrim(rtrim(str(a.eje_num)))))+ltrim(rtrim(str(a.eje_num)))+ "
  select @sql=@sql +  " convert(varchar(1),a.eje_roll_over)+convert(varchar(1),a.eje_digit)) cuenta, "
  select @sql=@sql +  " convert(char(24),c.eje_nombre) nombre, "
  select @sql=@sql +  " isnull(ltrim(c.eje_num_nom),' ') nomina, "
  select @sql=@sql +  " c.eje_centro_c, "
  select @sql=@sql +  " d.nivel_num nivel "
  select @sql=@sql +  " into #mtcths01 "
  select @sql=@sql +  " from MTCTHS01 a, MTCEJE01 c, MTCUNI01 d "
  select @sql=@sql +  " where a.eje_prefijo = " + convert(char(4), @Prefijo)
  select @sql=@sql +  " and a.gpo_banco = " + convert(char(2), @Banco)
  if @Por_Grupo = 1
   begin
    select @sql=@sql + " and a.emp_num in " + @Empresas
   end
  else
   begin
    select @sql=@sql + " and a.emp_num = " + convert(char(5), @Empresa)
   end
  select @sql=@sql +  " and a.eje_prefijo = c.eje_prefijo "
  select @sql=@sql +  " and a.gpo_banco = c.gpo_banco "
  select @sql=@sql +  " and a.emp_num = c.emp_num "
  select @sql=@sql +  " and a.eje_num = c.eje_num "
  select @sql=@sql +  " and d.eje_prefijo =* c.eje_prefijo "
  select @sql=@sql +  " and d.gpo_banco =* c.gpo_banco "
  select @sql=@sql +  " and d.emp_num =* c.emp_num "
  select @sql=@sql +  " and d.unit_id =* c.eje_centro_c "
  select @sql=@sql +  " order by a.eje_prefijo,a.gpo_banco,a.emp_num,nivel,a.eje_num "
  select @sql=@sql +  " select @numregs=@@rowcount "

  select @sql=@sql +  " if @numregs > 0 "
  select @sql=@sql +  " begin "
  select @sql=@sql +  " update  #mtcths01 set cuenta=map_cta_citi "
  select @sql=@sql +  " from #mtcths01, MTCMAP01 "
  select @sql=@sql +  " where convert(char(14),cuenta)=convert(char(14),map_cta_bnx) "
  select @sql=@sql +  " and map_estatus = ' ' "

  select @sql=@sql +  " select 'Grupo: " + convert(char(5),@Grupo) + "            ' +"
  select @sql=@sql +  " 'REPORTE DE ASIGNACION DE UNIDADES             Fec. Gen : " + @FechaAct
  select @sql=@sql +  " ' detalle into #Salida  "
  select @sql=@sql +  " insert #Salida values ('Empresa: " + convert(char(5),@Empresa) + "            ' +"
  select @sql=@sql +  " 'Productos Comerciales Banamex') "
  select @sql=@sql +  " insert #Salida values ('Unidad: " + convert(char(6),@UnidadPadre)
  select @sql=@sql +  "               Una Empresa de Citigroup               Ident. Reporte: Rep13') "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida values (' EJECUTIVO   CUENTA            NOMBRE                      ' +"
  select @sql=@sql +  " 'NOMINA           UNIDAD  NIVEL') "
  select @sql=@sql +  " insert #Salida values ('----------------------------------------------------------' +"
  select @sql=@sql +  " '-------------------------------') "
  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql +  " select ' ' + convert(char(10),eje_num) + '  ' + cuenta + '  ' + nombre + '    ' + convert(char(15),nomina) +"
  select @sql=@sql +  " '  ' + convert(char(6),eje_centro_c) + '  ' + convert(char(5),nivel) from #mtcths01 "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida values ('EOF')"
  select @sql=@sql +  " select * from #Salida "
  select @sql=@sql +  " end "

  EXECUTE (@sql)

end
go
EXEC sp_procxmode 'dbo.sp_ObtenDatosRep13','unchained'
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep13') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_ObtenDatosRep13 >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_ObtenDatosRep13 >>>'
go