IF OBJECT_ID('dbo.sp_ObtenDatosRep18') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sp_ObtenDatosRep18
    IF OBJECT_ID('dbo.sp_ObtenDatosRep18') IS NOT NULL
        PRINT '<<< FAILED DROPPING PROCEDURE dbo.sp_ObtenDatosRep18 >>>'
    ELSE
        PRINT '<<< DROPPED PROCEDURE dbo.sp_ObtenDatosRep18 >>>'
END
go
create proc sp_ObtenDatosRep18(@Prefijo int,@Banco smallint, @Empresa int, @Por_Tot smallint,
                               @Por_Grupo smallint, @Grupo int, @Unidad varchar(15), @FechaAct varchar(8))
as
    DECLARE     @sql      varchar(16384),
                @Empresas varchar(16384),
                @CadUnids varchar(16384),
                @UnidadPadre varchar(15),
                @EmpresaMenor        int,
                @Result              int
Begin

  select @sql=       " select "
  select @sql=@sql + " eje.eje_centro_c unidad, "
  select @sql=@sql + " ths.eje_prefijo, "
  select @sql=@sql + " ths.gpo_banco, "
  select @sql=@sql + " ths.emp_num, "
  select @sql=@sql + " ths.eje_num, "
  select @sql=@sql + " ths.eje_roll_over, "
  select @sql=@sql + " ths.eje_digit, "
  select @sql=@sql + " eje.eje_nombre as nombre_ejecutivo, "
  select @sql=@sql + " ltrim(rtrim(eje.eje_num_nom)) as nomina, "
  select @sql=@sql + " ths.ths_situacion_cta  + replicate(' ',19) as sc, "
  select @sql=@sql + " replicate(' ',35) as status, "
  select @sql=@sql + " str(ths.ths_limite_credito,12,0) as limite, "
  select @sql=@sql + " eje.eje_tipo_fac as tipo_de_facturacion "
  select @sql=@sql + " into #ejeths "
  select @sql=@sql + " from MTCTHS01 ths, MTCEJE01 eje "
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
  select @sql=@sql + " and eje.eje_prefijo = ths.eje_prefijo "
  select @sql=@sql + " and eje.gpo_banco = ths.gpo_banco "
  select @sql=@sql + " and eje.emp_num  = ths.emp_num "
  select @sql=@sql + " and eje.eje_num  = ths.eje_num "

  select @sql=@sql + " select "
  select @sql=@sql + " unidad, "
  select @sql=@sql + " et.eje_prefijo, "
  select @sql=@sql + " et.gpo_banco, "
  select @sql=@sql + " et.emp_num, "
  select @sql=@sql + " et.eje_num, "
  select @sql=@sql + " et.eje_roll_over, "
  select @sql=@sql + " et.eje_digit, "
  select @sql=@sql + " nombre_ejecutivo, "
  select @sql=@sql + " nomina, "
  select @sql=@sql + " sc, "
  select @sql=@sql + " status, "
  select @sql=@sql + " limite, "
  select @sql=@sql + " tipo_de_facturacion, "
  select @sql=@sql + " pla.pla_vencimiento as fh_expiracion, "
  select @sql=@sql + " pla.pla_reparto_ubicacion, "
  select @sql=@sql + " pla.pla_reparto_referencia, "
  select @sql=@sql + " pla.pla_pin, "
  select @sql=@sql + " pla.pla_grabacion_causa, "
  select @sql=@sql + " pla.pla_grabacion_ind "
  select @sql=@sql + " into #ejethspla "
  select @sql=@sql + " from #ejeths et, MTCPLA01 pla "
  select @sql=@sql + " where et.eje_prefijo = " + convert(char(4), @Prefijo)
  select @sql=@sql + " and et.gpo_banco = " + convert(char(2), @Banco)
  if @Por_Grupo = 1
   begin
    select @sql=@sql + " and et.emp_num in " + @Empresas
   end
  else
   begin
    select @sql=@sql + " and et.emp_num = " + convert(char(5), @Empresa)
   end
  select @sql=@sql + " and et.eje_prefijo = pla.eje_prefijo "
  select @sql=@sql + " and et.gpo_banco = pla.gpo_banco "
  select @sql=@sql + " and et.emp_num  = pla.emp_num "
  select @sql=@sql + " and et.eje_num  = pla.eje_num "
  select @sql=@sql + " and et.eje_roll_over  = pla.eje_roll_over "

  select @sql=@sql + " select "
  select @sql=@sql + " unidad, "
  select @sql=@sql + " uni.nivel_num as nivel, "
  select @sql=@sql + " convert(char(16), convert(char(4), etp.eje_prefijo)+ "
  select @sql=@sql + " convert(char(2),etp.gpo_banco)+ "
  select @sql=@sql + " replicate('0', ( select pgs_long_emp from MTCPGS01 a "
  select @sql=@sql + " where a.pgs_rep_prefijo = etp.eje_prefijo and "
  select @sql=@sql + " a.pgs_rep_banco = etp.gpo_banco) "
  select @sql=@sql + " -char_length(ltrim(rtrim(str(etp.emp_num)))))+ "
  select @sql=@sql + " ltrim(rtrim(str(etp.emp_num)))+ "
  select @sql=@sql + " replicate('0', (select pgs_long_eje from MTCPGS01 b "
  select @sql=@sql + " where b.pgs_rep_prefijo = etp.eje_prefijo and "
  select @sql=@sql + " b.pgs_rep_banco = etp.gpo_banco) "
  select @sql=@sql + " -char_length(ltrim(rtrim(str(etp.eje_num)))))+ "
  select @sql=@sql + " ltrim(rtrim(str(etp.eje_num)))+ "
  select @sql=@sql + " convert(char(1),etp.eje_roll_over)+ "
  select @sql=@sql + " convert(char(1),etp.eje_digit)) as cuenta, "
  select @sql=@sql + " nombre_ejecutivo, "
  select @sql=@sql + " nomina, "
  select @sql=@sql + " sc, "
  select @sql=@sql + " status, "
  select @sql=@sql + " limite, "
  select @sql=@sql + " fh_expiracion, "
  select @sql=@sql + " pla_reparto_ubicacion, "
  select @sql=@sql + " pla_reparto_referencia, "
  select @sql=@sql + " pla_pin, "
  select @sql=@sql + " pla_grabacion_causa, "
  select @sql=@sql + " pla_grabacion_ind, "
  select @sql=@sql + " tipo_de_facturacion, "
  select @sql=@sql + " etp.eje_num "
  select @sql=@sql + " into #TMP_REP_18 "
  select @sql=@sql + " from #ejethspla etp, MTCUNI01 uni "
  select @sql=@sql + " where etp.eje_prefijo = " + convert(char(4), @Prefijo)
  select @sql=@sql + " and etp.gpo_banco = " + convert(char(2), @Banco)
  if @Por_Grupo = 1
   begin
    select @sql=@sql + " and etp.emp_num in " + @Empresas
   end
  else
   begin
    select @sql=@sql + " and etp.emp_num = " + convert(char(5), @Empresa)
   end

  exec sp_ObtenUnidadesxEmpresa @Prefijo,@Banco,@EmpresaMenor,@Unidad,@CadUnids output,@UnidadPadre output


  if ((@Unidad is NULL) or (@Unidad = @UnidadPadre) or (@CadUnids = '()'))
   begin
     select @sql=@sql + " and uni.eje_prefijo =* etp.eje_prefijo  "
     select @sql=@sql + " and uni.gpo_banco =* etp.gpo_banco  "
     select @sql=@sql + " and uni.emp_num =* etp.emp_num  "
     select @sql=@sql + " and uni.unit_id =* etp.unidad  "
   end
  else
   begin
     select @sql=@sql + " and etp.eje_prefijo = uni.eje_prefijo  "
     select @sql=@sql + " and etp.gpo_banco = uni.gpo_banco  "
     select @sql=@sql + " and etp.emp_num = uni.emp_num  "
     select @sql=@sql + " and etp.unidad = uni.unit_id "
     select @sql=@sql + " and etp.unidad in " + @CadUnids
   end

  select @sql=@sql + " order by nivel, unidad, cuenta "
  select @sql=@sql + " update #TMP_REP_18 set status = 'ACUSE RECIBIDO' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'A' "
  select @sql=@sql + " and convert(int,substring(str(pla_reparto_referencia),1,2)) <> 99 "
  select @sql=@sql + " and convert(int,substring(str(pla_reparto_referencia),1,2)) <> 98 "

  select @sql=@sql + " update #TMP_REP_18 set status = 'PLASTICO RECIBIDO' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'A' "
  select @sql=@sql + " and (convert(int,substring(str(pla_reparto_referencia),1,2)) = 99 "
  select @sql=@sql + " or convert(int,substring(str(pla_reparto_referencia),1,2)) = 98) "

  select @sql=@sql + " update #TMP_REP_18 set status = 'PLASTICO EN BOVEDA' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'B' "

  select @sql=@sql + " update #TMP_REP_18  set status = 'ENVIO ESPECIAL' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'E' "

  select @sql=@sql + " update #TMP_REP_18 set status = 'MENSAJERIA ESPECIAL' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'M' "

  select @sql=@sql + " update #TMP_REP_18 set status = 'ENTREGADO Y ACTIVO' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'S' "
  select @sql=@sql + " and pla_pin = 0 and pla_grabacion_causa in ('A','B','E','L','N') "

  select @sql=@sql + " update #TMP_REP_18 set status = 'ENTREGA NO CONFIRMADA' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'S' "
  select @sql=@sql + " and pla_pin = 0 and pla_grabacion_causa in ('W','C','Y','T','Z') "

  select @sql=@sql + " update #TMP_REP_18 set status = 'NO SE GRABO, ERROR EN DATOS' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'W' "
  select @sql=@sql + " and pla_grabacion_causa in ('D','Z') "

  select @sql=@sql + " update #TMP_REP_18 set status = 'NO LLEGO A GRABACION' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'W' and pla_grabacion_ind >= 50 "

  select @sql=@sql + " update #TMP_REP_18 set status = 'SE GRABO, ENTREGA NO CONFIRMADA' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'W' and pla_grabacion_causa not in ('D','Z') "
  select @sql=@sql + " and pla_grabacion_ind < 50 "

  select @sql=@sql + " update #TMP_REP_18 set status = 'ASIGNADO A MENSAJERIA' from #TMP_REP_18 "
  select @sql=@sql + " where pla_reparto_ubicacion = 'R' "

  select @sql=@sql + " update #TMP_REP_18 set status = 'STATUS NO PARAMETRIZADO' from #TMP_REP_18 "
  select @sql=@sql + " where status = ' ' "

  select @sql=@sql + " update #TMP_REP_18 set status = 'NO GENERA PLASTICO' from #TMP_REP_18 "
  select @sql=@sql + " where eje_num = 0 "

  select @sql=@sql + "update #TMP_REP_18 set sc = 'NORMAL' from #TMP_REP_18 where sc = ' ' "
  select @sql=@sql + "update #TMP_REP_18 set sc = 'CANCEL CS' from #TMP_REP_18 where sc = 'C' "
  select @sql=@sql + "update #TMP_REP_18 set sc = 'CANCEL SS' from #TMP_REP_18 where sc = 'E' "
  select @sql=@sql + "update #TMP_REP_18 set sc = 'SOBREGIRO' from #TMP_REP_18 where sc = 'O' "
  select @sql=@sql + "update #TMP_REP_18 set sc = 'PROB COBRO' from #TMP_REP_18 where sc = 'P' "
  select @sql=@sql + "update #TMP_REP_18 set sc = 'ATRASADO' from #TMP_REP_18 where sc = 'D' "

  select @sql=@sql + "update #TMP_REP_18 set cuenta = map.map_cta_citi from #TMP_REP_18 tmp, MTCMAP01 map "
  select @sql=@sql + "where convert(char(14),tmp.cuenta)=convert(char(14),map.map_cta_bnx) and map.map_estatus = ' ' "

  if (@Prefijo = 5584 and @Banco = 26)
   begin
    select @sql=@sql +  " select 'Grupo: " + convert(char(5),@Grupo)
    select @sql=@sql +  "                                                   ESTATUS GRABACION DE PLASTICO"
    select @sql=@sql +  "                                           Fec. Gen : " + @FechaAct
    select @sql=@sql +  " ' detalle into #Salida  "
    select @sql=@sql +  " insert #Salida values ('Empresa: " + convert(char(5),@Empresa)
    select @sql=@sql +  "                                                 Productos Comerciales Banamex') "
   end
  else
   begin
    select @sql=@sql +  " select 'Grupo: " + convert(char(5),@Grupo)
    select @sql=@sql +  "                                                           ESTATUS GRABACION DE PLASTICO"
    select @sql=@sql +  "                                                   Fec. Gen : " + @FechaAct
    select @sql=@sql +  " ' detalle into #Salida  "
    select @sql=@sql +  " insert #Salida values ('Empresa: " + convert(char(5),@Empresa)
    select @sql=@sql +  "                                                         Productos Comerciales Banamex') "
   end


  if ((@Unidad is NULL) or (@Unidad = @UnidadPadre) or (@CadUnids = '()'))
   begin
     select @sql=@sql +  " insert #Salida values ('Unidad: " + convert(char(6),@UnidadPadre)
   end
  else
   begin
     select @sql=@sql +  " insert #Salida values ('Unidad: " + convert(char(6),@Unidad)
   end

  if (@Prefijo = 5584 and @Banco = 26)
   begin
    select @sql=@sql +  "                                                   Una Empresa de Citigroup"
    select @sql=@sql +  "                                            Ident. Reporte: Rep18') "
    select @sql=@sql +  " insert #Salida values (' ')"
    select @sql=@sql +  " insert #Salida values (' UNIDAD    NIVEL       CUENTA        NOMBRE                                       "
    select @sql=@sql +  "NOMINA      FH EXPIRA      SC     ESTATUS                            ') "
    select @sql=@sql +  " insert #Salida values ('------------------------------------------------------------"
    select @sql=@sql +  "----------------------------------------------------------------------------------------------') "
   end
  else
   begin
    select @sql=@sql +  "                                                           Una Empresa de Citigroup"
    select @sql=@sql +  "                                                    Ident. Reporte: Rep18') "
    select @sql=@sql +  " insert #Salida values (' ')"
    select @sql=@sql +  " insert #Salida values (' UNIDAD    NIVEL       CUENTA        NOMBRE                                       "
    select @sql=@sql +  "NOMINA      FH EXPIRA      SC     ESTATUS                                      LIMITE') "
    select @sql=@sql +  " insert #Salida values ('------------------------------------------------------------"
    select @sql=@sql +  "--------------------------------------------------------------------------------------------------------------') "
   end

  select @sql=@sql +  " insert #Salida (detalle) "
  select @sql=@sql +  " select ' ' + right('       '+(rtrim(unidad)),7) + ' ' + right('      '+(rtrim(str(nivel))),6) + '  '"
  select @sql=@sql +  " + cuenta + '   ' + convert(char(40),nombre_ejecutivo) + '     ' + isnull(convert(char(15),nomina),'               ') "
  select @sql=@sql +  " + ' ' + convert(char(6),fh_expiracion) + '     ' + convert(char(10),sc) + ' ' + "

  if (@Prefijo = 5584 and @Banco = 26)
   begin
    select @sql=@sql +  " convert(char(35),status) "
   end
  else
   begin
    select @sql=@sql +  " convert(char(35),status) + ' ' + right('               '+(rtrim(limite)),15) "
   end

  select @sql=@sql +  " from #TMP_REP_18 order by nivel, unidad, cuenta "
  select @sql=@sql +  " insert #Salida values (' ')"
  select @sql=@sql +  " insert #Salida (detalle) "

  if (@Prefijo = 5584 and @Banco = 26)
   begin
    select @sql=@sql +  " select '      ' + convert(char(35),status) + ' : ' + convert(char(6),count(status)) from #TMP_REP_18 group by status "
    select @sql=@sql +  " insert #Salida values (' ')"
    select @sql=@sql +  " insert #Salida (detalle) "
    select @sql=@sql +  " select '      TOTAL DE CUENTAS                    : ' + convert(char(6),count(sc)) from #TMP_REP_18 "
   end
  else
   begin
    select @sql=@sql +  " select '      ' + convert(char(16),sc) + ' : ' + convert(char(6),count(sc)) from #TMP_REP_18 group by sc "
    select @sql=@sql +  " insert #Salida values (' ')"
    select @sql=@sql +  " insert #Salida (detalle) "
    select @sql=@sql +  " select '      TOTAL DE CUENTAS : ' + convert(char(6),count(sc)) from #TMP_REP_18 "
   end

  select @sql=@sql +  " insert #Salida values ('EOF')"
  select @sql=@sql +  " select * from #Salida "

  EXECUTE (@sql)

end
go
EXEC sp_procxmode 'dbo.sp_ObtenDatosRep18','unchained'
go
IF OBJECT_ID('dbo.sp_ObtenDatosRep18') IS NOT NULL
    PRINT '<<< CREATED PROCEDURE dbo.sp_ObtenDatosRep18 >>>'
ELSE
    PRINT '<<< FAILED CREATING PROCEDURE dbo.sp_ObtenDatosRep18 >>>'
go