using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmReenvioEmp
		: System.Windows.Forms.Form
		{
		
			private void  frmReenvioEmp_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			colReenvioEmp gdteEmpresa = null;
			public int igNumeroGrupo = 0;
			private void  cmdConsIndividual_Click( Object eventSender,  EventArgs eventArgs)
			{
					try
					{
							
							gdteEmpresa = null;
							gdteEmpresa = new colReenvioEmp();
							gdteEmpresa.igNumeroGrupo = igNumeroGrupo;
							ConsultaMTCIND(vspmEmpresas, gdteEmpresa);
							cmdReenvio.Enabled = gdteEmpresa.Count > 0;
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvioEjecutivo (cmdConsIndividual)",e );
							this.Cursor = Cursors.Default;
						}
					}
			}
            private void ConsultaMTCIND(Softtek.Util.Win.Spread.SpreadWrapper vsplGrid, colReenvioEmp colReenvioEmp)
			{
					string sDatos = String.Empty;
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							vsplGrid.DisplayRowHeaders = false;
							colReenvioEmp.prCargarDatos();
							
							vsplGrid.Row = 1;
							vsplGrid.Col = 1;
							vsplGrid.Row2 = vsplGrid.MaxRows;
							vsplGrid.Col2 = vsplGrid.MaxCols;
							vsplGrid.BlockMode = true;
							vsplGrid.Clear();
							vsplGrid.BlockMode = false;
							Application.DoEvents();
							for (int iCont = 1; iCont <= colReenvioEmp.Count; iCont++)
							{
								vsplGrid.SetText(1, iCont, colReenvioEmp[iCont.ToString().Trim()].imPrefijo.ToString());
								vsplGrid.SetText(2, iCont, colReenvioEmp[iCont.ToString().Trim()].pszBanco);
								vsplGrid.SetText(3, iCont, colReenvioEmp[iCont.ToString().Trim()].slNumEmpresa.ToString());
								vsplGrid.SetText(4, iCont, colReenvioEmp[iCont.ToString().Trim()].pszNomEmpresa);
								vsplGrid.SetText(5, iCont, colReenvioEmp[iCont.ToString().Trim()].ilStatus_reg.ToString());
							}
							for (int iCont = 1; iCont <= 5; iCont++)
							{
								vsplGrid.set_ColWidth(iCont,(int)vsplGrid.get_MaxTextColWidth(iCont)+25);
							}
							this.Cursor = Cursors.Default;
							
							if (colReenvioEmp.Count == 0)
							{
								cmdReenvio.Enabled = false;
							}
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo (ConsultaMTCIND)",e );
							this.Cursor = Cursors.Default;
							return;
						}
					}
					
			}
			private bool fncReenvioEjecutivosB( int iIndxItem,  colReenvioEmp colReenvioEmp)
			{
					bool result = false;
					CRSDialogo.DatosDialogo dlgAlta = CRSDialogo.DatosDialogo.CreateInstance();
					
					result = true;
					clsReenvioEmpresas lEmpReenvio = new clsReenvioEmpresas();
					clsAltaEmpresa lAltaEmp = new clsAltaEmpresa();
					clsCliente lcteCliente = new clsCliente();
					//lAltaEmp.EmpgdteEmpresa = dlgAlta
					lAltaEmp.pszNumGrupo = colReenvioEmp[iIndxItem.ToString().Trim()].pszNumGrupo; //ok
					lAltaEmp.pszNomEmpresa = colReenvioEmp[iIndxItem.ToString().Trim()].pszNomEmpresa; //ok
					lAltaEmp.pszNomCorto = colReenvioEmp[iIndxItem.ToString().Trim()].pszNomCorto; //ok
					lAltaEmp.pszRFC = colReenvioEmp[iIndxItem.ToString().Trim()].pszRFC; //ok
					lAltaEmp.pszCartera = colReenvioEmp[iIndxItem.ToString().Trim()].pszCartera; //ok
					lAltaEmp.pszSector = colReenvioEmp[iIndxItem.ToString().Trim()].pszSector; //ok
					lAltaEmp.pszAccionista = colReenvioEmp[iIndxItem.ToString().Trim()].pszAccionista; //ok
					lAltaEmp.pszSucursal = colReenvioEmp[iIndxItem.ToString().Trim()].pszSucursal; //ok
					lAltaEmp.pszCreditoGlobal = colReenvioEmp[iIndxItem.ToString().Trim()].pszCreditoGlobal; //ok
					lAltaEmp.pszTelefono = colReenvioEmp[iIndxItem.ToString().Trim()].pszTelefono; //ok
					lAltaEmp.pszLada = colReenvioEmp[iIndxItem.ToString().Trim()].pszLada; //ok
					lAltaEmp.pszFax = colReenvioEmp[iIndxItem.ToString().Trim()].pszFax;
					lAltaEmp.pszEmail = colReenvioEmp[iIndxItem.ToString().Trim()].pszEmail; //ok
					lAltaEmp.pszInternet = colReenvioEmp[iIndxItem.ToString().Trim()].pszInternet; //ok
					lAltaEmp.pszTonoPul = colReenvioEmp[iIndxItem.ToString().Trim()].pszTonoPul; //ok
					lAltaEmp.pszFaxLada = colReenvioEmp[iIndxItem.ToString().Trim()].pszFaxLada; //ok
					lAltaEmp.pszTelExt = colReenvioEmp[iIndxItem.ToString().Trim()].pszTelExt; //ok
					lAltaEmp.pszCalleFis = colReenvioEmp[iIndxItem.ToString().Trim()].pszCalleFis; //ok
					lAltaEmp.pszColoniaFis = colReenvioEmp[iIndxItem.ToString().Trim()].pszColoniaFis; //ok
					lAltaEmp.pszCiudadFis = colReenvioEmp[iIndxItem.ToString().Trim()].pszCiudadFis; //ok
					lAltaEmp.pszPoblacionFis = colReenvioEmp[iIndxItem.ToString().Trim()].pszPoblacionFis; //ok
					lAltaEmp.pszEstadoFis = colReenvioEmp[iIndxItem.ToString().Trim()].pszEstadoFis; //ok
					lAltaEmp.pszCpFis = colReenvioEmp[iIndxItem.ToString().Trim()].pszCpFis; //ok
					lAltaEmp.pszCalleEnv = colReenvioEmp[iIndxItem.ToString().Trim()].pszCalleEnv; //ok
					lAltaEmp.pszColoniaEnv = colReenvioEmp[iIndxItem.ToString().Trim()].pszColoniaEnv; //ok
					lAltaEmp.pszCiudadEnv = colReenvioEmp[iIndxItem.ToString().Trim()].pszCiudadEnv; //ok
					lAltaEmp.pszPoblacionEnv = colReenvioEmp[iIndxItem.ToString().Trim()].pszPoblacionEnv; //ok
					lAltaEmp.pszEstadoEnv = colReenvioEmp[iIndxItem.ToString().Trim()].pszEstadoEnv; //ok
					lAltaEmp.pszCpEnv = colReenvioEmp[iIndxItem.ToString().Trim()].pszCpEnv; //ok
					lAltaEmp.pszTipoPago = colReenvioEmp[iIndxItem.ToString().Trim()].pszTipoPago; //ok
					lAltaEmp.pszTipoEnv = colReenvioEmp[iIndxItem.ToString().Trim()].pszTipoEnv; //ok
					lAltaEmp.pszCtaCaptacion = colReenvioEmp[iIndxItem.ToString().Trim()].pszCtaCaptacion; //ok
					lAltaEmp.pszNominaEjeBNX = colReenvioEmp[iIndxItem.ToString().Trim()].pszNominaEjeBNX; //ok
					lAltaEmp.pszFecVenCred = colReenvioEmp[iIndxItem.ToString().Trim()].pszFecVenCred; //ok
					lAltaEmp.ilDiaCorte = colReenvioEmp[iIndxItem.ToString().Trim()].ilDiaCorte; //ok
					lAltaEmp.ilPlazoGracia = colReenvioEmp[iIndxItem.ToString().Trim()].ilPlazoGracia; //ok
					lAltaEmp.ilPlazoNoCobro = colReenvioEmp[iIndxItem.ToString().Trim()].ilPlazoNoCobro; //ok
					lAltaEmp.slTipoFactura = colReenvioEmp[iIndxItem.ToString().Trim()].slTipoFactura; //ok
					lAltaEmp.slEsquemaPago = colReenvioEmp[iIndxItem.ToString().Trim()].slEsquemaPago; //ok
					lAltaEmp.slTipoProducto = colReenvioEmp[iIndxItem.ToString().Trim()].slTipoProducto; //ok
					lAltaEmp.llEstructuraGastos = colReenvioEmp[iIndxItem.ToString().Trim()].llEstructuraGastos;
					lAltaEmp.ilMesFiscal = colReenvioEmp[iIndxItem.ToString().Trim()].ilMesFiscal; //ok
					lAltaEmp.ilMontoPorciento = colReenvioEmp[iIndxItem.ToString().Trim()].ilMontoPorciento; //ok
					lAltaEmp.dlFacturacionMinima = colReenvioEmp[iIndxItem.ToString().Trim()].dlFacturacionMinima;
					lAltaEmp.slCuentaContable = colReenvioEmp[iIndxItem.ToString().Trim()].slCuentaContable; //ok
					lAltaEmp.ilSkipPayment = colReenvioEmp[iIndxItem.ToString().Trim()].ilSkipPayment; //ok
					//lAltaEmp.ilTablaMCCCambio = colReenvioEmp.Item(Trim(CStr(iIndxItem))).ilTablaMCCCambio
					lAltaEmp.ilTablaMCC = colReenvioEmp[iIndxItem.ToString().Trim()].ilTablaMCC; //ok
					lAltaEmp.slUsuarioCambio = colReenvioEmp[iIndxItem.ToString().Trim()].slUsuarioCambio; //ok
					lAltaEmp.msNombreR1 = colReenvioEmp[iIndxItem.ToString().Trim()].msNombreR1; //ok
					lAltaEmp.msPuestoR1 = colReenvioEmp[iIndxItem.ToString().Trim()].msPuestoR1; //ok
					lAltaEmp.msTelR1 = colReenvioEmp[iIndxItem.ToString().Trim()].msTelR1; //ok
					lAltaEmp.msExtR1 = colReenvioEmp[iIndxItem.ToString().Trim()].msExtR1; //ok
					lAltaEmp.msFaxR1 = colReenvioEmp[iIndxItem.ToString().Trim()].msFaxR1; //ok
					lAltaEmp.msNombreR2 = colReenvioEmp[iIndxItem.ToString().Trim()].msNombreR2; //ok
					lAltaEmp.msPuestoR2 = colReenvioEmp[iIndxItem.ToString().Trim()].msPuestoR2; //ok
					lAltaEmp.msTelR2 = colReenvioEmp[iIndxItem.ToString().Trim()].msTelR2; //ok
					lAltaEmp.msExtR2 = colReenvioEmp[iIndxItem.ToString().Trim()].msExtR2; //ok
					lAltaEmp.msFaxR2 = colReenvioEmp[iIndxItem.ToString().Trim()].msFaxR2; //ok
					lAltaEmp.msNombreR3 = colReenvioEmp[iIndxItem.ToString().Trim()].msNombreR3; //ok
					lAltaEmp.msPuestoR3 = colReenvioEmp[iIndxItem.ToString().Trim()].msPuestoR3; //ok
					lAltaEmp.msTelR3 = colReenvioEmp[iIndxItem.ToString().Trim()].msTelR3; //ok
					lAltaEmp.msExtR3 = colReenvioEmp[iIndxItem.ToString().Trim()].msExtR3; //ok
					lAltaEmp.msFaxR3 = colReenvioEmp[iIndxItem.ToString().Trim()].msFaxR3; //ok
					lAltaEmp.mskDiaCorte = colReenvioEmp[iIndxItem.ToString().Trim()].mskDiaCorte; //ok
					lAltaEmp.slNacionalidad = colReenvioEmp[iIndxItem.ToString().Trim()].slNacionalidad; //ok
					lAltaEmp.slIndCtaControl = colReenvioEmp[iIndxItem.ToString().Trim()].slIndCtaControl; //ok
					lAltaEmp.imEmpTipoBloqueo = colReenvioEmp[iIndxItem.ToString().Trim()].imEmpTipoBloqueo.ToString(); //ok
					lAltaEmp.imPrefijo = colReenvioEmp[iIndxItem.ToString().Trim()].imPrefijo; //ok
					lAltaEmp.pszBanco = colReenvioEmp[iIndxItem.ToString().Trim()].pszBanco;
					lAltaEmp.imBanco = Int32.Parse(colReenvioEmp[iIndxItem.ToString().Trim()].pszBanco);
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
					lAltaEmp.ilGenArchivoCDF = (CheckState) colReenvioEmp[iIndxItem.ToString().Trim()].ilGenArchivoCDF; //ok
					//lAltaEmp.bmblModFirma = colReenvioEmp.Item(Trim(CStr(iIndxItem))).bmblModFirma
					//lAltaEmp.smblPathRepEmpresas = colReenvioEmp.Item(Trim(CStr(iIndxItem))).smblPathRepEmpresas
					lAltaEmp.illNumEmpresa = colReenvioEmp[Conversion.Str(iIndxItem).Trim()].slNumEmpresa;
					lAltaEmp.illIncremento = colReenvioEmp[Conversion.Str(iIndxItem).Trim()].slIncremento;
					lAltaEmp.illDigitoVer = colReenvioEmp[Conversion.Str(iIndxItem).Trim()].iDigitoVer;
					lcteCliente.ProductoPRD.PrefijoL = colReenvioEmp[Conversion.Str(iIndxItem).Trim()].emp_cliente_prefijol;
					lcteCliente.ProductoPRD.BancoL = colReenvioEmp[Conversion.Str(iIndxItem).Trim()].emp_cliente_bancol;
					lcteCliente.EmpresaL = colReenvioEmp[Conversion.Str(iIndxItem).Trim()].emp_cliente_empresal;
					lcteCliente.ClienteL = colReenvioEmp[Conversion.Str(iIndxItem).Trim()].emp_cliente_clientel;
					lAltaEmp.EmplcteCliente = lcteCliente;
					int ilStatus = colReenvioEmp[iIndxItem.ToString().Trim()].ilStatus_reg;
					
					
					dlgAlta.iFechaAlta = Convert.ToInt32(Conversion.Val(DateTime.Today.ToString("yyyyMMdd")));
					dlgAlta.sCuenta = colReenvioEmp[iIndxItem.ToString().Trim()].sCuentaEjecutivo0;
					dlgAlta.iDiaCorte = colReenvioEmp[iIndxItem.ToString().Trim()].mskDiaCorte;
					dlgAlta.sNombreGrabacion = Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszNomCorto, "'", "").Trim();
					dlgAlta.sApellidoPaterno = Strings.Mid(Seguridad.fncsSustituir(Seguridad.fncsSustituir(Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszNomEmpresa, ",", ""), ".", ""), "'", ""), 1, 30);
					dlgAlta.sApellidoMaterno = Strings.Mid(Seguridad.fncsSustituir(Seguridad.fncsSustituir(Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszNomEmpresa, ",", ""), ".", ""), "'", ""), 31, 30);
					dlgAlta.sSexo = "F";
					dlgAlta.iSucTransmisora = 137;
					dlgAlta.iSucPromotora = 137;
					if (colReenvioEmp[iIndxItem.ToString().Trim()].slTipoFactura == CRSParametros.cteIndividual)
					{
						dlgAlta.lLimiteCredito = 0;
					} else if (colReenvioEmp[iIndxItem.ToString().Trim()].slTipoFactura == CRSParametros.cteCorporativo) { 
						dlgAlta.lLimiteCredito = colReenvioEmp[iIndxItem.ToString().Trim()].pszCreditoGlobal;
					}
					dlgAlta.sDomicilio = Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszCalleEnv, "'", "").Trim();
					dlgAlta.sColonia = Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszColoniaEnv, "'", "").Trim();
					dlgAlta.sPoblacion = Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszPoblacionEnv, "'", "").Trim();
					dlgAlta.sEstado = Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszEstadoEnv, "'", "").Trim();
					dlgAlta.iZonaPostal = 0;
					dlgAlta.lCP = Int32.Parse(colReenvioEmp[iIndxItem.ToString().Trim()].pszCpEnv);
					dlgAlta.iASActi = 0;
					dlgAlta.lTelOficina = StringsHelper.DoubleValue(Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszTelefono, "'", "").Trim());
					dlgAlta.lTelParticular = StringsHelper.DoubleValue(Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszTelefono, "'", "").Trim());
					dlgAlta.lExtension = Convert.ToInt32(StringsHelper.DoubleValue(Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszTelExt, "'", "").Trim()));
					dlgAlta.sRFC = Seguridad.fncsSustituir(colReenvioEmp[iIndxItem.ToString().Trim()].pszRFC, "'", "").Trim();
					dlgAlta.iGeneraPinPlastico = (int) CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN;
					dlgAlta.sTipoCta = CRSParametros.cteEmpresa;
					dlgAlta.iSkipPayment = colReenvioEmp[iIndxItem.ToString().Trim()].ilSkipPayment;
					dlgAlta.iIdTablaMCC = colReenvioEmp[iIndxItem.ToString().Trim()].ilTablaMCC;
					dlgAlta.sCuentaReferencia = StringsHelper.Format(colReenvioEmp[iIndxItem.ToString().Trim()].pszSucursal, new string('0', 4)) + StringsHelper.Format(colReenvioEmp[iIndxItem.ToString().Trim()].pszCtaCaptacion, new string('0', 12));
					dlgAlta.sTipoFacturacion = colReenvioEmp[iIndxItem.ToString().Trim()].slTipoFactura;
					
					
					CRSDialogo.gdteDatosEmpresa = dlgAlta;
					lAltaEmp.EmpgdteEmpresa();
					lEmpReenvio.mObjetoAlta = lAltaEmp;
                    //lEmpReenvio.EjeStatusS = ilStatus.ToString();
                    lEmpReenvio.EjeStatusSComDrv = ilStatus.ToString();
                    return !lEmpReenvio.resultado;
			}

			private void  cmdReenvio_Click( Object eventSender,  EventArgs eventArgs)
			{
					//Reenvia las altas de las empresas, una por una
					int iContOK = 0;
					
					try
					{
							iContOK = 0;
							sspnlPorcentaje.FloodPercent = 0;
							cmdConsIndividual.Enabled = false;
							for (int iCont = 1; iCont <= gdteEmpresa.Count; iCont++)
							{
								if (fncReenvioEjecutivosB(iCont, gdteEmpresa))
								{
									iContOK++;
								}
								sspnlPorcentaje.FloodPercent = Convert.ToInt16((iCont * 100) / ((double) gdteEmpresa.Count));
								Application.DoEvents();
							}
							if (gdteEmpresa.Count == iContOK)
							{
								MessageBox.Show("Se re enviaron todos los ejecutivos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
							} else
							{
								MessageBox.Show("Se re enviaron " + iContOK.ToString() + " ejecutivos de " + gdteEmpresa.Count.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							cmdReenvio.Enabled = false;
							prLimpiaGrid(vspmEmpresas);
							cmdConsIndividual.Enabled = true;
							sspnlPorcentaje.FloodPercent = 0;
						}
                    catch (Exception e)
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
                            CRSGeneral.prObtenError(this.GetType().Name + "(cmdReenvio_Click)", e);
							this.Cursor = Cursors.Default;
							cmdReenvio.Enabled = false;
							prLimpiaGrid(vspmEmpresas);
							cmdConsIndividual.Enabled = true;
							return;
						}
					}
					
			}
            private void prLimpiaGrid(Softtek.Util.Win.Spread.SpreadWrapper vsplGrid)
			{
					try
					{
							
							vsplGrid.Row = 1;
							vsplGrid.Col = 1;
							vsplGrid.Row2 = vsplGrid.MaxRows;
							vsplGrid.Col2 = vsplGrid.MaxCols + 1;
                            vsplGrid.BlockMode = true;
							vsplGrid.Clear();
							vsplGrid.BlockMode = false;
							Application.DoEvents();
						}
					catch 
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							this.Cursor = Cursors.Default;
							return;
						}
					}
					
			}
			
			
			private void  cmdSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					gdteEmpresa = null;
					this.Close();
			}
			
			
			
			
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					gdteEmpresa = new colReenvioEmp();
					cmdReenvio.Enabled = false;
					cmdConsIndividual.Enabled = true;
			}
			private void  frmReenvioEmp_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}