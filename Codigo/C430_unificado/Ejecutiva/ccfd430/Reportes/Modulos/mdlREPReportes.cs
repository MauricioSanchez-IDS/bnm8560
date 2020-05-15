using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class mdlREPReportes
	{
	
		public enum cteTipoReporte
		 {
			cteAccountCycleSummaryUnit = 1 ,
			cteAccountCycleSummaryTH = 2 ,
			cteAccountCycleDetailTransaction = 3
		}
		
		static public void  prGenerarReporte(ref  clsREPReporte rptpReporte, ref  clsREPUnidad unipUnidad, ref  cteTipoReporte ipTipoReporte, ref  string spSeparador,  bool bCuentaContableOnOff)
		{
			string slLinea = String.Empty;
			string slSep = String.Empty;
			try
			{
					if (rptpReporte == null)
					{
						rptpReporte = new clsREPReporte();
					}
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
					if (spSeparador.Length == 0 || String.IsNullOrEmpty(spSeparador) || false)
					{
						spSeparador = new string(' ', 1);
					}
					if (unipUnidad != null)
					{
						//GeneraCuerpo
						switch(ipTipoReporte)
						{
							case cteTipoReporte.cteAccountCycleSummaryUnit : 
								//Genera el resumen de Unidad 
								prGeneraDetalle(unipUnidad, rptpReporte, spSeparador); 
								//Pregunta si tiene Hijos (Si tiene entonces) 
								if (unipUnidad.colUnidades.Count > 0)
								{
									for (int llHijos = 1; llHijos <= unipUnidad.colUnidades.Count; llHijos++)
									{
										clsREPUnidad tempRefParam = unipUnidad.colUnidades[llHijos];
										cteTipoReporte tempRefParam2 = ipTipoReporte;
										prGenerarReporte(ref rptpReporte, ref tempRefParam, ref tempRefParam2);
									}
								} 
								break;
							case cteTipoReporte.cteAccountCycleSummaryTH : 
								prAgregaTHaReporte(ref rptpReporte, unipUnidad, false, spSeparador, bCuentaContableOnOff); 
								if (unipUnidad.colUnidades.Count > 0)
								{
									for (int llHijos = 1; llHijos <= unipUnidad.colUnidades.Count; llHijos++)
									{
										clsREPUnidad tempRefParam3 = unipUnidad.colUnidades[llHijos];
										cteTipoReporte tempRefParam4 = ipTipoReporte;
										prGenerarReporte(ref rptpReporte, ref tempRefParam3, ref tempRefParam4, ref spSeparador, bCuentaContableOnOff);
									}
								} 
								break;
							case cteTipoReporte.cteAccountCycleDetailTransaction : 
								for (int llTarjetahabientes = 1; llTarjetahabientes <= unipUnidad.ResumenRUN.TotalesTH.Count; llTarjetahabientes++)
								{
									//          rptpReporte.clsCuerpo.LineasREN.Add rptpReporte.ColumnasPorPaginaI, _
									//'          unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.NumeroCuentaS & _
									//'          spSeparador & unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.NombreEjecutivoS, cteIzquierda, "Arial"
									prAgregaTransaccionATHRep(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes], ref rptpReporte, spSeparador, unipUnidad.IdS);
								} 
								if (unipUnidad.colUnidades.Count > 0)
								{
									for (int llHijos = 1; llHijos <= unipUnidad.colUnidades.Count; llHijos++)
									{
										clsREPUnidad tempRefParam5 = unipUnidad.colUnidades[llHijos];
										cteTipoReporte tempRefParam6 = ipTipoReporte;
										prGenerarReporte(ref rptpReporte, ref tempRefParam5, ref tempRefParam6);
									}
								} 
								break;
						}
					} else
					{
						MessageBox.Show("Especifíque la unidad, para generar el reporte.", "Genera Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("GenerarReporte",e );
			}
		}
		
		static public void  prGenerarReporte(ref  clsREPReporte rptpReporte, ref  clsREPUnidad unipUnidad, ref  cteTipoReporte ipTipoReporte, ref  string spSeparador)
		{
			prGenerarReporte(ref rptpReporte, ref unipUnidad, ref ipTipoReporte, ref spSeparador, false);
		}
		
		static public void  prGenerarReporte(ref  clsREPReporte rptpReporte, ref  clsREPUnidad unipUnidad, ref  cteTipoReporte ipTipoReporte)
		{
			string tempRefParam37 = "";
			prGenerarReporte(ref rptpReporte, ref unipUnidad, ref ipTipoReporte, ref tempRefParam37, false);
		}
		
		
		static public void  prConstruyeJerarquia( string spUnidad, ref  clsREPUnidad unipUnidadPadre)
		{
			string slSQL = String.Empty;
			clsREPUnidad unilUnidad = null;
			
			try
			{
					CORVAR.pszgblsql = "select ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo   As Prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_banco   as Banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_num   as Empresa";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_num   as Grupo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_id     as Id";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_parent_id  as PadreID";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", nivel_num   as Nivel";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_name   as Nombre";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_calle  as Calle";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_col    as Colonia";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_pob  as Poblacion";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_zip    as CodigoPostal";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_city as Ciudad";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_state  as Estado";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_ctry as Pais";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_ph   as Telefono";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_ext    as Extension";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_fax    as Fax";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_cel    as Celular";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_email  as Email";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_head_name as Encabezado";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_receipient_name as NombreRecepient";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCUNI01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + unipUnidadPadre.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND gpo_banco = " + unipUnidadPadre.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND emp_num = " + unipUnidadPadre.EmpresaL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND nivel_num > " + unipUnidadPadre.NivelI.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Order By";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num ASC,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id";
					
					//Obtiene Recordset de las jerarquias
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						while (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
							{
							
								//Configura la unidad
								unilUnidad = new clsREPUnidad();
								if (unipUnidadPadre == null)
								{
									unipUnidadPadre = new clsREPUnidad();
								}
								unilUnidad.PrefijoL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
								unilUnidad.BancoL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
								unilUnidad.EmpresaL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								unilUnidad.GrupoL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								unilUnidad.IdS = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
								unilUnidad.IdPadreS = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
								unilUnidad.NivelI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 7));
								unilUnidad.NombreS = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
								unilUnidad.CalleS = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
								unilUnidad.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim();
								unilUnidad.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
								unilUnidad.CodigoPostalL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 12));
								unilUnidad.CiudadS = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
								unilUnidad.EstadoS = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
								unilUnidad.PaisS = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
								unilUnidad.TelefonoS = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim() + ((VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim() != "") ? " Ext " + VBSQL.SqlData(CORVAR.hgblConexion, 17): "");
								unilUnidad.FaxS = VBSQL.SqlData(CORVAR.hgblConexion, 18).Trim();
								unilUnidad.CelularS = VBSQL.SqlData(CORVAR.hgblConexion, 19).Trim();
								unilUnidad.CorreoElectronicoS = VBSQL.SqlData(CORVAR.hgblConexion, 20).Trim();
								unilUnidad.PeriodoCorteI = unipUnidadPadre.PeriodoCorteI;
								unilUnidad.AñoCorteI = unipUnidadPadre.AñoCorteI;
								if (unilUnidad.NivelI > unipUnidadPadre.NivelI)
								{
									//Busca su padre y lo anexa a su padre correspondiente
									bfncAsignaHijoAPadre(unipUnidadPadre, ref unilUnidad);
								}
							}
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("ConstruyeJerarquia",e );
			}
			
		}
		
		static public bool bfncAsignaHijoAPadre( clsREPUnidad unipPadre, ref  clsREPUnidad unipHijo)
		{
			bool result = false;
			try
			{
					if (unipPadre == null)
					{
						MessageBox.Show("La unidad padre no se ha definido", "Asigna Hijo a Padre.", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					if (unipHijo == null)
					{
						MessageBox.Show("La unidad hijo no se ha definido correctamente", "Asigna Hijo a Padre.", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					if (unipHijo.IdPadreS == unipPadre.IdS)
					{
						unipPadre.colUnidades.Add(unipHijo.NombreS, unipHijo.PrefijoL, unipHijo.BancoL, unipHijo.EmpresaL, unipHijo.GrupoL, unipHijo.IdS, unipHijo.IdPadreS, unipHijo.NivelI, unipHijo.CalleS, unipHijo.ColoniaS, unipHijo.CiudadS, unipHijo.PoblacionS, unipHijo.EstadoS, unipHijo.CodigoPostalL, unipHijo.TelefonoS, unipHijo.FaxS, unipHijo.CelularS, unipHijo.CorreoElectronicoS, unipHijo.PaisS, unipHijo.ResumenRUN, unipHijo.colUnidades, unipHijo.AñoCorteI, unipHijo.PeriodoCorteI);
						result = true;
					} else
					{
						for (int llItem = 1; llItem <= unipPadre.colUnidades.Count; llItem++)
						{
							result = bfncAsignaHijoAPadre(unipPadre.colUnidades[llItem], ref unipHijo);
							if (result)
							{
								break;
							}
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("AsignaHijoAPadre",e );
			}
			
			return result;
		}
		
		
		static public clsREPUnidad unifncObtieneUnidadPrincipal( int lpPrefijo,  int lpBanco,  int lpEmpresa)
		{
			string slSQL = String.Empty;
			clsREPUnidad unilUnidad = null;
			
			try
			{
					CORVAR.pszgblsql = "select ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo   As Prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_banco   as Banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_num   as Empresa";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_num   as Grupo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_id     as Id";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_parent_id  as PadreID";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", nivel_num   as Nivel";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_name   as Nombre";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_calle  as Calle";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_col    as Colonia";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_pob  as Poblacion";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_zip    as CodigoPostal";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_city as Ciudad";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_state  as Estado";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_ctry as Pais";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_ph   as Telefono";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_ext    as Extension";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_fax    as Fax";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_cel    as Celular";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_email  as Email";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_head_name as Encabezado";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", unit_receipient_name as NombreRecepient";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCUNI01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + lpPrefijo.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND gpo_banco = " + lpBanco.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND emp_num = " + lpEmpresa.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND nivel_num = 1";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Order By";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num ASC,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id";
					
					//Obtiene Recordset de las jerarquias
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						while (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
							{
							
								//Configura la unidad
								unilUnidad = new clsREPUnidad();
								unilUnidad.PrefijoL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
								unilUnidad.BancoL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
								unilUnidad.EmpresaL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								unilUnidad.GrupoL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								unilUnidad.IdS = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
								unilUnidad.IdPadreS = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
								unilUnidad.NivelI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 7));
								unilUnidad.NombreS = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
								unilUnidad.CalleS = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
								unilUnidad.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim();
								unilUnidad.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
								unilUnidad.CodigoPostalL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 12));
								unilUnidad.CiudadS = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
								unilUnidad.EstadoS = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
								unilUnidad.PaisS = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
								unilUnidad.TelefonoS = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim() + ((VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim() != "") ? " Ext " + VBSQL.SqlData(CORVAR.hgblConexion, 17): "");
								unilUnidad.FaxS = VBSQL.SqlData(CORVAR.hgblConexion, 18).Trim();
								unilUnidad.CelularS = VBSQL.SqlData(CORVAR.hgblConexion, 19).Trim();
								unilUnidad.CorreoElectronicoS = VBSQL.SqlData(CORVAR.hgblConexion, 20).Trim();
							}
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					return unilUnidad;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("ConstruyeJerarquia",e );
			}
			return null;
		}
		
		
		static public void  prAgregaTHaReporte(ref  clsREPReporte rptpReporte,  clsREPUnidad unipUnidad,  bool bpDetalleTransacciones,  string spSeparador,  bool bpCuentaContable)
		{
			string slCadena = String.Empty;
			try
			{
					if (rptpReporte == null)
					{
						rptpReporte = new clsREPReporte();
					}
					//UPGRADE_ISSUE: (1040) IsMissing function is not supported.
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                    //AIS-1123 NGONZALEZ
					if (spSeparador.Length == 0 || String.IsNullOrEmpty(spSeparador) || String.Empty.Equals(spSeparador))
					{
						spSeparador = new string(' ', 1);
					}
					if (unipUnidad.ResumenRUN.TotalesTH.Count > 0)
					{
						for (int llTarjetahabientes = 1; llTarjetahabientes <= unipUnidad.ResumenRUN.TotalesTH.Count; llTarjetahabientes++)
						{
							//Orden de datos del TarjetaHabiente
							//Cuenta  Ejecutivo Nómina  Crédito C. de Costos  Atrasos Saldo Anterior Consumos  Disp. Efvo. Pagos Comisiones  Gtos. Cobr. I.V.A.  Saldo Nuevo
							if (! bpDetalleTransacciones)
							{
								int tempRefParam = 16;
								string tempRefParam2 = " ";
								slCadena = CRSGeneral.sfncJustificar(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.NumeroCuentaS, CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam, ref tempRefParam2);
								int tempRefParam3 = 10;
								string tempRefParam4 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(unipUnidad.IdS.Trim(), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam3, ref tempRefParam4);
								int tempRefParam5 = 20;
								string tempRefParam6 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.NombreEjecutivoS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam5, ref tempRefParam6);
								int tempRefParam7 = 15;
								string tempRefParam8 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.NumeroNominaS.Trim(), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam7, ref tempRefParam8);
								int tempRefParam9 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam10 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.LimiteCreditoD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam9, ref tempRefParam10);
								int tempRefParam11 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam12 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.SaldoAnteriorD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam11, ref tempRefParam12);
								int tempRefParam13 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam14 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.ComprasD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam13, ref tempRefParam14);
								int tempRefParam15 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam16 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.DisposicionesD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam15, ref tempRefParam16);
								int tempRefParam17 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam18 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.PagosAbonosD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam17, ref tempRefParam18);
								int tempRefParam19 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam20 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.ComisionesD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam19, ref tempRefParam20);
								int tempRefParam21 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam22 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.GastosCobrosD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam21, ref tempRefParam22);
								int tempRefParam23 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam24 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.IvaD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam23, ref tempRefParam24);
								int tempRefParam25 = CRSParametros.cteMascaraDinero.Length;
								string tempRefParam26 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].Totales.SaldoNuevoD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam25, ref tempRefParam26);
								int tempRefParam27 = 6;
								string tempRefParam28 = " ";
								slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(unipUnidad.NivelI.ToString()), "00"), CRSGeneral.cteJustificado.cteCentrado, ref tempRefParam27, ref tempRefParam28);
								if (bpCuentaContable)
								{
									int tempRefParam29 = 40;
									string tempRefParam30 = " ";
									slCadena = slCadena + spSeparador + CRSGeneral.sfncJustificar(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes].CuentaContableS, CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam29, ref tempRefParam30);
								}
								rptpReporte.clsCuerpo.LineasREN.Add(rptpReporte.ColumnasPorPaginaI, slCadena, CRSGeneral.cteJustificado.cteCentrado, "Arial");
								
								//        rptpReporte.clsCuerpo.LineasREN.Add _
								//'        rptpReporte.ColumnasPorPaginaI, _
								//'                        sfncJustificar(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.NumeroCuentaS, ctederecha, 16, " ") _
								//'        & spSeparador & sfncJustificar(Trim(unipUnidad.IdS), cteIzquierda, 10, " ") _
								//'        & spSeparador & sfncJustificar(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.NombreEjecutivoS, cteIzquierda, 20, " ") _
								//'        & spSeparador & sfncJustificar(Trim(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.NumeroNominaS), cteIzquierda, 15, " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.LimiteCreditoD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.SaldoAnteriorD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.ComprasD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.DisposicionesD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.PagosAbonosD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.ComisionesD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.GastosCobrosD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.IvaD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " ") _
								//'        & spSeparador & sfncJustificar(Format(Val(unipUnidad.ResumenRUN.TotalesTH.Item(llTarjetahabientes).Totales.SaldoNuevoD), cteMascaraDinero), ctederecha, Len(cteMascaraDinero), " "), _
								//'        cteIzquierda, "Arial"
							} else
							{
								prAgregaTransaccionATHRep(unipUnidad.ResumenRUN.TotalesTH[llTarjetahabientes], ref rptpReporte, spSeparador);
							}
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("AgregaTHaRepoorte",e );
			}
		}
		
		static public void  prAgregaTHaReporte(ref  clsREPReporte rptpReporte,  clsREPUnidad unipUnidad,  bool bpDetalleTransacciones,  string spSeparador)
		{
			prAgregaTHaReporte(ref rptpReporte, unipUnidad, bpDetalleTransacciones, spSeparador, false);
		}
		
		static public void  prAgregaTHaReporte(ref  clsREPReporte rptpReporte,  clsREPUnidad unipUnidad,  bool bpDetalleTransacciones)
		{
			prAgregaTHaReporte(ref rptpReporte, unipUnidad, bpDetalleTransacciones, "", false);
		}
		
		static public void  prAgregaEncabezadoTHaReporte( clsREPUnidad uniUnidad,  clsREPReporte repReporte, ref  string spCuenta, ref  string spEmpresa, ref  string spSeparador,  bool bpCtaCon)
		{
			string sEncabezado = String.Empty;
			
			try
			{
					
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
					if (spSeparador.Length == 0 || String.IsNullOrEmpty(spSeparador) || false)
					{
						spSeparador = new string(' ', 1);
					}
					
					sEncabezado = "";
					int tempRefParam = 16;
					string tempRefParam2 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(spCuenta, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam, ref tempRefParam2) + spSeparador;
					int tempRefParam3 = spEmpresa.Length;
					string tempRefParam4 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(spEmpresa, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam3, ref tempRefParam4) + spSeparador;
					repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
					
					sEncabezado = "";
					int tempRefParam5 = 5;
					string tempRefParam6 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(uniUnidad.IdS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam5, ref tempRefParam6) + spSeparador;
					int tempRefParam7 = 20;
					string tempRefParam8 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(uniUnidad.NombreS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam7, ref tempRefParam8) + spSeparador;
					repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
					
					sEncabezado = "";
					int tempRefParam9 = 16;
					string tempRefParam10 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("NUMERO CUENTA", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam9, ref tempRefParam10) + spSeparador;
					int tempRefParam11 = 10;
					string tempRefParam12 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("UNIDAD", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam11, ref tempRefParam12) + spSeparador;
					int tempRefParam13 = 20;
					string tempRefParam14 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("NOMBRE EJECUTIVO", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam13, ref tempRefParam14) + spSeparador;
					int tempRefParam15 = 15;
					string tempRefParam16 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("NUMERO NOMINA", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam15, ref tempRefParam16) + spSeparador;
					int tempRefParam17 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam18 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("LIMITE CREDITO", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam17, ref tempRefParam18) + spSeparador;
					int tempRefParam19 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam20 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("SALDO ANTERIOR", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam19, ref tempRefParam20) + spSeparador;
					int tempRefParam21 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam22 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("COMPRAS", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam21, ref tempRefParam22) + spSeparador;
					int tempRefParam23 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam24 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("DISPOSICIONES", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam23, ref tempRefParam24) + spSeparador;
					int tempRefParam25 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam26 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("PAGOS Y ABONOS", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam25, ref tempRefParam26) + spSeparador;
					int tempRefParam27 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam28 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("COMISIONES", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam27, ref tempRefParam28) + spSeparador;
					int tempRefParam29 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam30 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("GASTOS Y COB", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam29, ref tempRefParam30) + spSeparador;
					int tempRefParam31 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam32 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("IVA", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam31, ref tempRefParam32) + spSeparador;
					int tempRefParam33 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam34 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("SALDO NUEVO", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam33, ref tempRefParam34) + spSeparador;
					int tempRefParam35 = 6;
					string tempRefParam36 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("NIVEL", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam35, ref tempRefParam36) + spSeparador;
					if (bpCtaCon)
					{
						int tempRefParam37 = 30;
						string tempRefParam38 = " ";
						sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("CUENTA CONTABLE", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam37, ref tempRefParam38) + spSeparador;
					}
					repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError("AgregaEncabezadoTHaReporte",e );
			}
			
		}
		
		static public void  prAgregaEncabezadoTHaReporte( clsREPUnidad uniUnidad,  clsREPReporte repReporte, ref  string spCuenta, ref  string spEmpresa, ref  string spSeparador)
		{
			prAgregaEncabezadoTHaReporte(uniUnidad, repReporte, ref spCuenta, ref spEmpresa, ref spSeparador, false);
		}
		
		static public void  prAgregaEncabezadoTHaReporte( clsREPUnidad uniUnidad,  clsREPReporte repReporte, ref  string spCuenta, ref  string spEmpresa)
		{
			string tempRefParam38 = "";
			prAgregaEncabezadoTHaReporte(uniUnidad, repReporte, ref spCuenta, ref spEmpresa, ref tempRefParam38, false);
		}
		
		static public void  prAgregaTransaccionATHRep( clsREPResumenTH rthpTarjetaHabiente, ref  clsREPReporte rptpReporte,  string spSeparador,  string spUnidad)
		{
			string slCadena = String.Empty;
			try
			{
					if (rptpReporte == null)
					{
						rptpReporte = new clsREPReporte();
					}
					//UPGRADE_ISSUE: (1040) IsMissing function is not supported.
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                    //AIS-1123 NGONZALEZ
					if (spSeparador.Length == 0 || String.IsNullOrEmpty(spSeparador) || String.Empty.Equals(spSeparador))
					{
						spSeparador = new string(' ', 1);
					}
					for (int llTransacciones = 1; llTransacciones <= rthpTarjetaHabiente.Transacciones.Count; llTransacciones++)
					{
						int tempRefParam = 16;
						string tempRefParam2 = " ";
						int tempRefParam3 = 10;
						string tempRefParam4 = " ";
						int tempRefParam5 = 20;
						string tempRefParam6 = " ";
						int tempRefParam7 = 8;
						string tempRefParam8 = " ";
						int tempRefParam9 = 8;
						string tempRefParam10 = " ";
						int tempRefParam11 = 20;
						string tempRefParam12 = " ";
						int tempRefParam13 = 3;
						string tempRefParam14 = " ";
						int tempRefParam15 = 14;
						string tempRefParam16 = " ";
						int tempRefParam17 = 20;
						string tempRefParam18 = " ";
						int tempRefParam19 = CRSParametros.cteMascaraDinero.Length;
						string tempRefParam20 = " ";
						rptpReporte.clsCuerpo.LineasREN.Add(rptpReporte.ColumnasPorPaginaI, CRSGeneral.sfncJustificar(rthpTarjetaHabiente.Transacciones[llTransacciones].NumeroCuentaS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam, ref tempRefParam2) + spSeparador + CRSGeneral.sfncJustificar(spUnidad, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam3, ref tempRefParam4) + spSeparador + CRSGeneral.sfncJustificar(rthpTarjetaHabiente.Transacciones[llTransacciones].NombreEjecutivoS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam5, ref tempRefParam6) + spSeparador + CRSGeneral.sfncJustificar(rthpTarjetaHabiente.Transacciones[llTransacciones].FechaProcesoS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam7, ref tempRefParam8) + spSeparador + CRSGeneral.sfncJustificar(rthpTarjetaHabiente.Transacciones[llTransacciones].FechaTransaccionS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam9, ref tempRefParam10) + spSeparador + CRSGeneral.sfncJustificar(rthpTarjetaHabiente.Transacciones[llTransacciones].NegocioS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam11, ref tempRefParam12) + spSeparador + CRSGeneral.sfncJustificar(rthpTarjetaHabiente.Transacciones[llTransacciones].PaisS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam13, ref tempRefParam14) + spSeparador + CRSGeneral.sfncJustificar(rthpTarjetaHabiente.Transacciones[llTransacciones].CiudadS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam15, ref tempRefParam16) + spSeparador + CRSGeneral.sfncJustificar(rthpTarjetaHabiente.Transacciones[llTransacciones].ReferenciaS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam17, ref tempRefParam18) + spSeparador + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(rthpTarjetaHabiente.Transacciones[llTransacciones].ImporteD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam19, ref tempRefParam20), CRSGeneral.cteJustificado.cteIzquierda, "arial");
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("AgregaTransaccionATHRep",e );
			}
		}
		
		static public void  prAgregaTransaccionATHRep( clsREPResumenTH rthpTarjetaHabiente, ref  clsREPReporte rptpReporte,  string spSeparador)
		{
			prAgregaTransaccionATHRep(rthpTarjetaHabiente, ref rptpReporte, spSeparador, "");
		}
		
		static public void  prAgregaTransaccionATHRep( clsREPResumenTH rthpTarjetaHabiente, ref  clsREPReporte rptpReporte)
		{
			prAgregaTransaccionATHRep(rthpTarjetaHabiente, ref rptpReporte, "", "");
		}
		
		static public void  prAgregaEncabezadoTransaccionATHRep( clsREPUnidad uniUnidad,  clsREPReporte repReporte, ref  string spCuenta, ref  string spEmpresa, ref  string spSeparador)
		{
			string sEncabezado = String.Empty;
			
			try
			{
					
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
					if (spSeparador.Length == 0 || String.IsNullOrEmpty(spSeparador) || false)
					{
						spSeparador = new string(' ', 1);
					}
					
					sEncabezado = "";
					int tempRefParam = 16;
					string tempRefParam2 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(spCuenta, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam, ref tempRefParam2) + spSeparador;
					int tempRefParam3 = spEmpresa.Length;
					string tempRefParam4 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(spEmpresa, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam3, ref tempRefParam4) + spSeparador;
					repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
					
					sEncabezado = "";
					int tempRefParam5 = 5;
					string tempRefParam6 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(uniUnidad.IdS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam5, ref tempRefParam6) + spSeparador;
					int tempRefParam7 = 20;
					string tempRefParam8 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(uniUnidad.NombreS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam7, ref tempRefParam8) + spSeparador;
					repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
					
					sEncabezado = "";
					int tempRefParam9 = 16;
					string tempRefParam10 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("NUMERO CUENTA", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam9, ref tempRefParam10) + spSeparador;
					int tempRefParam11 = 10;
					string tempRefParam12 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("UNIDAD", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam11, ref tempRefParam12) + spSeparador;
					int tempRefParam13 = 20;
					string tempRefParam14 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("EJECUTIVO", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam13, ref tempRefParam14) + spSeparador;
					int tempRefParam15 = 8;
					string tempRefParam16 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("FEC PROC", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam15, ref tempRefParam16) + spSeparador;
					int tempRefParam17 = 8;
					string tempRefParam18 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("FEC TRAN", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam17, ref tempRefParam18) + spSeparador;
					int tempRefParam19 = 20;
					string tempRefParam20 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("NEGOCIO", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam19, ref tempRefParam20) + spSeparador;
					int tempRefParam21 = 3;
					string tempRefParam22 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("PAIS", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam21, ref tempRefParam22) + spSeparador;
					int tempRefParam23 = 14;
					string tempRefParam24 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("CIUDAD", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam23, ref tempRefParam24) + spSeparador;
					int tempRefParam25 = 20;
					string tempRefParam26 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("REFERENCIA", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam25, ref tempRefParam26) + spSeparador;
					int tempRefParam27 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam28 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("IMPORTE", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam27, ref tempRefParam28) + spSeparador;
					repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError("AgregaEncabezadoTransaccionATHRep",e );
			}
			
		}
		
		static public void  prAgregaEncabezadoTransaccionATHRep( clsREPUnidad uniUnidad,  clsREPReporte repReporte, ref  string spCuenta, ref  string spEmpresa)
		{
			string tempRefParam39 = "";
			prAgregaEncabezadoTransaccionATHRep(uniUnidad, repReporte, ref spCuenta, ref spEmpresa, ref tempRefParam39);
		}
		
		static public void  prGeneraEncabezado( clsREPUnidad uniUnidad,  clsREPReporte repReporte, ref  string spCuenta, ref  string spEmpresa,  string spSeparador)
		{
			
			string sEncabezado = "";
			int tempRefParam = 16;
			string tempRefParam2 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(spCuenta, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam, ref tempRefParam2) + spSeparador;
			int tempRefParam3 = spEmpresa.Length;
			string tempRefParam4 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(spEmpresa, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam3, ref tempRefParam4) + spSeparador;
			repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
			
			sEncabezado = "";
			int tempRefParam5 = 5;
			string tempRefParam6 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(uniUnidad.IdS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam5, ref tempRefParam6) + spSeparador;
			int tempRefParam7 = 20;
			string tempRefParam8 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(uniUnidad.NombreS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam7, ref tempRefParam8) + spSeparador;
			repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
			
			sEncabezado = "";
			int tempRefParam9 = 5;
			string tempRefParam10 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam9, ref tempRefParam10) + spSeparador;
			int tempRefParam11 = 20;
			string tempRefParam12 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam11, ref tempRefParam12) + spSeparador;
			int tempRefParam13 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam14 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("SALDO ANTERIOR", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam13, ref tempRefParam14) + spSeparador;
			int tempRefParam15 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam16 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("COMPRAS", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam15, ref tempRefParam16) + spSeparador;
			int tempRefParam17 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam18 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("DISPOSICIONES", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam17, ref tempRefParam18) + spSeparador;
			int tempRefParam19 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam20 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("PAGOS Y ABONOS", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam19, ref tempRefParam20) + spSeparador;
			int tempRefParam21 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam22 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("COMISIONES", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam21, ref tempRefParam22) + spSeparador;
			int tempRefParam23 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam24 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("GASTOS Y COB", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam23, ref tempRefParam24) + spSeparador;
			int tempRefParam25 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam26 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("IVA", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam25, ref tempRefParam26) + spSeparador;
			int tempRefParam27 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam28 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("SALDO NUEVO", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam27, ref tempRefParam28) + spSeparador;
			int tempRefParam29 = 6;
			string tempRefParam30 = " ";
			sEncabezado = sEncabezado + CRSGeneral.sfncJustificar("NIVEL", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam29, ref tempRefParam30) + spSeparador;
			
			repReporte.clsEncabezado.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
		}
		
		static public void  prGeneraEncabezado( clsREPUnidad uniUnidad,  clsREPReporte repReporte, ref  string spCuenta, ref  string spEmpresa)
		{
			prGeneraEncabezado(uniUnidad, repReporte, ref spCuenta, ref spEmpresa, "");
		}
		
		static public void  prGeneraDetalle( clsREPUnidad uniUnidad,  clsREPReporte repReporte,  string spSeparador)
		{
			
			string sDetalle = "";
			int tempRefParam = 5;
			string tempRefParam2 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(uniUnidad.IdS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam, ref tempRefParam2) + spSeparador;
			int tempRefParam3 = 20;
			string tempRefParam4 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(uniUnidad.NombreS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam3, ref tempRefParam4) + spSeparador;
			int tempRefParam5 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam6 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.SaldoAnteriorD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam5, ref tempRefParam6) + spSeparador;
			int tempRefParam7 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam8 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.ComprasD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam7, ref tempRefParam8) + spSeparador;
			int tempRefParam9 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam10 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.DisposicionesD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam9, ref tempRefParam10) + spSeparador;
			int tempRefParam11 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam12 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.PagosAbonosD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam11, ref tempRefParam12) + spSeparador;
			int tempRefParam13 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam14 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.ComisionesD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam13, ref tempRefParam14) + spSeparador;
			int tempRefParam15 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam16 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.GastosCobrosD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam15, ref tempRefParam16) + spSeparador;
			int tempRefParam17 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam18 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.IvaD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam17, ref tempRefParam18) + spSeparador;
			int tempRefParam19 = CRSParametros.cteMascaraDinero.Length;
			string tempRefParam20 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.SaldoNuevoD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam19, ref tempRefParam20) + spSeparador;
			int tempRefParam21 = 6;
			string tempRefParam22 = " ";
			sDetalle = sDetalle + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.NivelI.ToString()), "00"), CRSGeneral.cteJustificado.cteCentrado, ref tempRefParam21, ref tempRefParam22) + spSeparador;
			
			repReporte.clsCuerpo.LineasREN.Add(repReporte.ColumnasPorPaginaI, sDetalle, CRSGeneral.cteJustificado.cteIzquierda, "arial");
		}
		
		static public void  prGeneraDetalle( clsREPUnidad uniUnidad,  clsREPReporte repReporte)
		{
			prGeneraDetalle(uniUnidad, repReporte, "");
		}
		
		static public void  prGeneraPiePagina( clsREPUnidad uniUnidad,  clsREPReporte repReporte,  cteTipoReporte spTipRep,  string spSeparador)
		{
			string sUnidadTitulo = String.Empty;
			
			string sEncabezado = "";
			string sCadena = "TOTALES UNIDAD " + uniUnidad.IdS.Trim() + " : ";
			
			if (spTipRep == cteTipoReporte.cteAccountCycleSummaryUnit)
			{
				
				sUnidadTitulo = sCadena;
				int tempRefParam = 26;
				string tempRefParam2 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(sUnidadTitulo, CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam, ref tempRefParam2) + spSeparador;
				
				int tempRefParam3 = CRSParametros.cteMascaraDinero.Length;
				string tempRefParam4 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.SaldoAnteriorD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam3, ref tempRefParam4) + spSeparador;
				int tempRefParam5 = CRSParametros.cteMascaraDinero.Length;
				string tempRefParam6 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.ComprasD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam5, ref tempRefParam6) + spSeparador;
				int tempRefParam7 = CRSParametros.cteMascaraDinero.Length;
				string tempRefParam8 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.DisposicionesD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam7, ref tempRefParam8) + spSeparador;
				int tempRefParam9 = CRSParametros.cteMascaraDinero.Length;
				string tempRefParam10 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.PagosAbonosD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam9, ref tempRefParam10) + spSeparador;
				int tempRefParam11 = CRSParametros.cteMascaraDinero.Length;
				string tempRefParam12 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.ComisionesD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam11, ref tempRefParam12) + spSeparador;
				int tempRefParam13 = CRSParametros.cteMascaraDinero.Length;
				string tempRefParam14 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.GastosCobrosD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam13, ref tempRefParam14) + spSeparador;
				int tempRefParam15 = CRSParametros.cteMascaraDinero.Length;
				string tempRefParam16 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.IvaD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam15, ref tempRefParam16) + spSeparador;
				int tempRefParam17 = CRSParametros.cteMascaraDinero.Length;
				string tempRefParam18 = " ";
				sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.SaldoNuevoD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam17, ref tempRefParam18) + spSeparador;
			} else
			{
				
				if (spTipRep == cteTipoReporte.cteAccountCycleSummaryTH)
				{
					
					int tempRefParam19 = 51;
					string tempRefParam20 = " ";
					sEncabezado = new String(' ', 28) + CRSGeneral.sfncJustificar(sCadena, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam19, ref tempRefParam20) + spSeparador;
					int tempRefParam21 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam22 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.SaldoAnteriorD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam21, ref tempRefParam22) + spSeparador;
					int tempRefParam23 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam24 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.ComprasD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam23, ref tempRefParam24) + spSeparador;
					int tempRefParam25 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam26 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.DisposicionesD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam25, ref tempRefParam26) + spSeparador;
					int tempRefParam27 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam28 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.PagosAbonosD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam27, ref tempRefParam28) + spSeparador;
					int tempRefParam29 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam30 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.ComisionesD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam29, ref tempRefParam30) + spSeparador;
					int tempRefParam31 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam32 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.GastosCobrosD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam31, ref tempRefParam32) + spSeparador;
					int tempRefParam33 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam34 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.IvaD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam33, ref tempRefParam34) + spSeparador;
					int tempRefParam35 = CRSParametros.cteMascaraDinero.Length;
					string tempRefParam36 = " ";
					sEncabezado = sEncabezado + CRSGeneral.sfncJustificar(StringsHelper.Format(Conversion.Val(uniUnidad.ResumenRUN.Total.SaldoNuevoD.ToString()), CRSParametros.cteMascaraDinero), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam35, ref tempRefParam36) + spSeparador;
					
				}
			}
			
			repReporte.clsPiePagina.LineasREN.Add(repReporte.ColumnasPorPaginaI, sEncabezado, CRSGeneral.cteJustificado.cteIzquierda, "arial");
		}
	}
}