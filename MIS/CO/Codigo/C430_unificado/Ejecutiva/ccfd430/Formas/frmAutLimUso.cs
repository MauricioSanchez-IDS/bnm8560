using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using System.Windows.Forms;
using System.Configuration;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmAutLimUso
		: System.Windows.Forms.Form
		{
		
			private void  frmAutLimUso_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			//*:********************************************************************************
			//*:                        EISSA / Banamex - Sistemas                            **
			//*:------------------------------------------------------------------------------**
			//*: Responsable:                Vázquez Vázquez Héctor (HVV)                     **
			//*: Fecha de Creacion:          03 de enero de 2005                              **
			//*: Versión:                    1.0.0                                            **
			//*: Plataforma de Desarrollo:   Visual Basic 6.0                                 **
			//*:                                                                              **
			//*: Descripción:    Pantalla para autorización (cheker) de cambios de límites    **
			//*:                 de Crédito para tarjetahabientes.                                **
			//*:********************************************************************************
			clsCuenta ctaCuenta = null;
			
			private bool mfnCargarMallaB()
			{
					bool result = false;
					bool ErrCargarMalla = false;
					string slCuenta = String.Empty;
					try
					{
							ErrCargarMalla = true;
							
							lvwCuentas.ListItems.Clear();
							lvwCuentas.Sorted = false;
							lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwDescending;
							
							//*:-------------------- 1 ------- 2 ---------- 3 ---------- 4 ------------ 5 --------
                            //CORVAR.pszgblsql = "select ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_cta_bnx, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_cred_ant, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_cred_post, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_usu_maker, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_nom_maker, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(datetime, convert(varchar, lim_fecha_maker) + ' ' + substring(replicate('0',  4 - char_length(convert(varchar, lim_hora_maker))) + convert(varchar, lim_hora_maker),1,2) + ':' + substring(replicate('0',  4 - char_length(convert(varchar,lim_hora_maker))) + convert(varchar, lim_hora_maker),3,2)) as lim_fecha_maker, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_hora_maker, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_usu_checker, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_nom_checker, ";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " case";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " when lim_fecha_checker = null then ''";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " Else";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(varchar,convert(datetime, convert(varchar, isnull(lim_fecha_checker, 0)) + ' ' + substring(replicate('0',  4 - char_length(convert(varchar, isnull(lim_hora_checker,0)))) + convert(varchar, isnull(lim_hora_checker,0)),1,2) + ':' + substring(replicate('0',  4 - char_length(convert(varchar,isnull(lim_hora_checker,0)))) + convert(varchar, isnull(lim_hora_checker,0)),3,109)))";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " end  As lim_fecha_checker";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCLIM01";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " Where";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_usu_checker in (NULL,' ')";
                            //CORVAR.pszgblsql = CORVAR.pszgblsql + " order by lim_fecha_maker, lim_hora_maker";

                            CORVAR.pszgblsql = "select ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_id, ";      //1
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo, "; //2
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco, ";   //3
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num, ";     //4
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_num, ";     //5
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_roll_over, "; //6
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_digit, ";     //7
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_cred_ant, ";  //8
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_cred_nvo, ";  //9
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_nomina_maker, ";//10
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_nombre_maker, ";//11
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(datetime, lim_fecha_maker, 103) as lim_fecha_maker, ";//12
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_nomina_checker, ";//13
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_nombre_checker, ";//14
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(datetime, lim_fecha_checker, 103) as lim_fecha_checker, ";//15
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_est_lim_uso";//16
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCLIM02";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " Where";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_est_lim_uso = 0";

							CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									slCuenta = StringsHelper.Format(mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 2), "-1"), mdlParametros.gprdProducto.MascaraPrefijoS);
                                    slCuenta = slCuenta + StringsHelper.Format(mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 3), "-1"),mdlParametros.gprdProducto.MascaraBancoS);
                                    slCuenta = slCuenta + StringsHelper.Format(mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 4), "-1"),mdlParametros.gprdProducto.MascaraEmpresaS);
                                    slCuenta = slCuenta + StringsHelper.Format(mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 5), "-1"), mdlParametros.gprdProducto.MascaraEjecutivoS);
                                    slCuenta = slCuenta + Conversion.Val(mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 6), "9"));
                                    slCuenta = slCuenta + Conversion.Val(mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 7), "0"));
									//UPGRADE_WARNING: (1068) Nvl(SqlData(hgblConexion, 3), -1) of type Variant is being forced to string.
									object tempRefParam = Type.Missing;
									object tempRefParam2 = "K" + Convert.ToString(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 1), -1));
									object tempRefParam3 = slCuenta;
									object tempRefParam4 = Type.Missing;
									object tempRefParam5 = Type.Missing;
                                    MSComctlLib.ListItem ListItem = lvwCuentas.ListItems.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5);
									object tempRefParam6 = lvwCuentas.ListItems.Count;
                                    ListItem.set_SubItems(1, StringsHelper.Format(mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 8), "0"), "$ ###,###,###,##0.00"));
									object tempRefParam7 = lvwCuentas.ListItems.Count;
                                    ListItem.set_SubItems(2, StringsHelper.Format(mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 9), "0"), "$ ###,###,###,##0.00"));
									object tempRefParam8 = lvwCuentas.ListItems.Count;
                                    ListItem.set_SubItems(3, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 10), "-1").Trim());
									object tempRefParam9 = lvwCuentas.ListItems.Count;
                                    ListItem.set_SubItems(4, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 11), "-1").Trim());
									object tempRefParam10 = lvwCuentas.ListItems.Count;
                                    ListItem.set_SubItems(5, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 12), ""));

									//Se construye la colección de Objetos ID que deben estar ocultos
								};
								
								object tempRefParam11 = 1;
								lvwCuentas.ListItems.get_ControlDefault(ref tempRefParam11).Selected = true;
								result = true;
							} else
							{
								MessageBox.Show("No existen Solicitudes de Cambio de Límite de Uso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
								result = false;
							}
							
							VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
					catch (Exception excep)
					{
						if (! ErrCargarMalla)
						{
							throw excep;
						}
						//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
						//ais-1599 chidalgo
                        //throw new Exception("Migration Exception: 'Resume' not supported");
						if (ErrCargarMalla)
						{
							
							MessageBox.Show("Ocurrió el siguiente error en el proceso:" + "\n" + "Número: " + Information.Err().Number.ToString() + "\n" + 
							                "Descripcion: " + excep.Message + "\n" + "Origen: " + excep.Source + "\n" + 
							                "Módulo: frmAutLimUso::mfnCargaMalla", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
							result = false;
						}
					}
					return result;
			}
			
			
			private void  frmAutLimUso_Closed( Object eventSender,  EventArgs eventArgs)
			{
					this.Cursor = Cursors.WaitCursor;
					ctaCuenta = null;
					this.Cursor = Cursors.Default;
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			
			//---------- PROCEDIMIENTOS Y FUNCIONES DE MANEJO DE LISTVIEW -----------------------------------------
			private void  lvwCuentas_ColumnClick( Object eventSender,  AxMSComctlLib.ListViewEvents_ColumnClickEvent eventArgs)
			{
					lvwCuentas.Sorted = true;
					
					if (lvwCuentas.SortKey == eventArgs.columnHeader.SubItemIndex)
					{
						if (lvwCuentas.SortOrder == MSComctlLib.ListSortOrderConstants.lvwAscending)
						{
							lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwDescending;
						} else
						{
							lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwAscending;
						}
					} else
					{
						lvwCuentas.SortKey = (short) eventArgs.columnHeader.SubItemIndex;
						lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwAscending;
					}
					
					if (lvwCuentas.ListItems.Count > 0)
					{
						lvwCuentas.SelectedItem.EnsureVisible();
					}
			}
			private void  Encabezado()
			{
					object tempRefParam = Type.Missing;
					object tempRefParam2 = Type.Missing;
					object tempRefParam3 = "Cuenta";
					object tempRefParam4 = Type.Missing;
					object tempRefParam5 = Type.Missing;
					object tempRefParam6 = Type.Missing;
                    MSComctlLib.ColumnHeader ColumnHeader  = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					
					object tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int) VB6.TwipsToPixelsX(1950);
					object tempRefParam8 = Type.Missing;
					object tempRefParam9 = Type.Missing;
					object tempRefParam10 = "Limite Anterior";
					object tempRefParam11 = Type.Missing;
					object tempRefParam12 = Type.Missing;
					object tempRefParam13 = Type.Missing;
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12, ref tempRefParam13);
					object tempRefParam14 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int) VB6.TwipsToPixelsX(1300);
					object tempRefParam15 = Type.Missing;
					object tempRefParam16 = Type.Missing;
					object tempRefParam17 = "Límite Nuevo";
					object tempRefParam18 = Type.Missing;
					object tempRefParam19 = Type.Missing;
					object tempRefParam20 = Type.Missing;
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam15, ref tempRefParam16, ref tempRefParam17, ref tempRefParam18, ref tempRefParam19, ref tempRefParam20);
					object tempRefParam21 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int) VB6.TwipsToPixelsX(1300);
					object tempRefParam22 = Type.Missing;
					object tempRefParam23 = Type.Missing;
					object tempRefParam24 = "Nómina Maker";
					object tempRefParam25 = Type.Missing;
					object tempRefParam26 = Type.Missing;
					object tempRefParam27 = Type.Missing;
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam22, ref tempRefParam23, ref tempRefParam24, ref tempRefParam25, ref tempRefParam26, ref tempRefParam27);
					object tempRefParam28 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int) VB6.TwipsToPixelsX(1300);
					object tempRefParam29 = Type.Missing;
					object tempRefParam30 = Type.Missing;
					object tempRefParam31 = "Nombre Maker";
					object tempRefParam32 = Type.Missing;
					object tempRefParam33 = Type.Missing;
					object tempRefParam34 = Type.Missing;
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam29, ref tempRefParam30, ref tempRefParam31, ref tempRefParam32, ref tempRefParam33, ref tempRefParam34);
					object tempRefParam35 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int) VB6.TwipsToPixelsX(3000);
					object tempRefParam36 = Type.Missing;
					object tempRefParam37 = Type.Missing;
					object tempRefParam38 = "Fecha Maker";
					object tempRefParam39 = Type.Missing;
					object tempRefParam40 = Type.Missing;
					object tempRefParam41 = Type.Missing;
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam36, ref tempRefParam37, ref tempRefParam38, ref tempRefParam39, ref tempRefParam40, ref tempRefParam41);
					object tempRefParam42 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int) VB6.TwipsToPixelsX(1900);
			}
			
			//---------- PROCEDIMIENTOS Y FUNCIONES DE MANEJO DE LISTVIEW -----------------------------------------
			
			//---------- PROCEDIMIENTOS Y FUNCIONES DE MANEJO VISUAL ----------------------------------------------
			private bool isInitializingComponent;
			private void  frmAutLimUso_Resize( Object eventSender,  EventArgs eventArgs)
			{
					if (isInitializingComponent)
					{
						return;
					}
					lvwCuentas.Width = (int) VB6.TwipsToPixelsX(Math.Abs(((float) VB6.PixelsToTwipsX(this.Width)) - 400));
					lvwCuentas.Height = (int) VB6.TwipsToPixelsY(Math.Abs(((float) VB6.PixelsToTwipsY(this.Height)) - 3500));
					txtLog.Width = (int) lvwCuentas.Width;
                    txtLog.Top = (int)VB6.TwipsToPixelsX((float)VB6.PixelsToTwipsY(lvwCuentas.Height) + 600);
					txtLog.Height = (int) VB6.TwipsToPixelsY(Math.Abs(((float) VB6.PixelsToTwipsY(this.Height)) - ((float) VB6.PixelsToTwipsY(lvwCuentas.Height)) - 1500));
			}
			
			
			private void  DeselTodos()
			{
					for (int i = 1; i <= lvwCuentas.ListItems.Count; i++)
					{
						object tempRefParam = i;
						lvwCuentas.ListItems.get_Item(ref tempRefParam).Checked = false;
					}
			}
			
			private void  SelTodos()
			{
					for (int i = 1; i <= lvwCuentas.ListItems.Count; i++)
					{
						object tempRefParam = i;
						lvwCuentas.ListItems.get_Item(ref tempRefParam).Checked = true;
					}
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (mprLog) seems to be dead code
			//private void  mprLog( string asMsg)
			//{
					//txtLog.Text = txtLog.Text + asMsg;
			//}
			//---------- FIN DE PROCEDIMIENTOS Y FUNCIONES DE MANEJO VISUAL ---------------------------------------
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					bool VAD = false;
					try
					{
							VAD = true;
							this.Cursor = Cursors.WaitCursor;
							//this.Left = (int) VB6.TwipsToPixelsX(CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2;
							//this.Top = (int) VB6.TwipsToPixelsY(CORMDIBN.DefInstance.ClientRectangle.Height - this.Height) / 2;
							txtLog.Text = "";
							
							Encabezado();
							
							if (! mfnCargarMallaB())
							{
								this.Cursor = Cursors.Default;
								return;
							}
							
							this.Cursor = Cursors.Default;
						}
					catch (Exception excep)
					{
						if (! VAD)
						{
							throw excep;
						}
						//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                        //ais-1599 chidalgo
                        //throw new Exception("Migration Exception: 'Resume' not supported");
						if (VAD)
						{
							
							MessageBox.Show("Ocurrió el siguiente error en el proceso:" + "\n" + "Número: " + Information.Err().Number.ToString() + "\n" + 
							                "Descripcion: " + excep.Message + "\n" + "Origen: " + excep.Source + "\n" + 
							                "Módulo: frmCancAutoriz::Load()", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
							this.Cursor = Cursors.Default;
							this.Close();
						}
					}
			}
			
			
			private void  tbrStandar_ButtonClick(Object eventSender,  AxMSComctlLib.IToolbarEvents_ButtonClickEvent eventArgs)
			{
					prySeguridadS041.clsAccion accAccion = null;
					switch(eventArgs.button.Key.ToUpper())
					{
						case "TODO" : 
							this.Cursor = Cursors.WaitCursor; 
							SelTodos(); 
							this.Cursor = Cursors.Default; 
							break;
						case "NINGUNO" : 
							this.Cursor = Cursors.WaitCursor; 
							DeselTodos(); 
							this.Cursor = Cursors.Default; 
							break;
						case "ENVIAR" : 
							this.Cursor = Cursors.WaitCursor; 
							txtLog.Text = String.Empty; 
							if (RevisaSelB())
							{
								accAccion = new prySeguridadS041.clsAccion();
								accAccion.idAccionI = 2;
								accAccion.NombreS = "Autoriza Limite Uso";
								accAccion.DescripcionS = "Autoriza y actualiza Límite de Uso en C430 y S111.";
								accAccion.ModuloS = "Modulo de Ejecutivo"; //Implementar en Seguridad
								accAccion.HabilitarB = true;
								accAccion.MakerCheckerE = prySeguridadS041.mchTiposMakerChecker.tmcMancomunado;
								accAccion.NivelE = prySeguridadS041.etaAcciones.accAutChecker;
								accAccion.OperacionI = 1;
								accAccion.UsuarioUSU = Seguridad.usugUsuario;
								ctaCuenta = new clsCuenta();
								if (ctaCuenta.ConectarS111B(Seguridad.usugUsuario))
								{
                                    txtLog.Text = txtLog.Text + "\r\n" + ctaCuenta.LogS;
									if (mdlADO.fncVerificaConexionM111b())
									{
										for (int ilCounter = 1; ilCounter <= lvwCuentas.ListItems.Count; ilCounter++)
										{
											object tempRefParam4 = ilCounter;
											if (lvwCuentas.ListItems.get_Item(ref tempRefParam4).Checked)
											{
												ctaCuenta.productoPRD = mdlParametros.gprdProducto;
												object tempRefParam = ilCounter;
												ctaCuenta.CuentaS = lvwCuentas.ListItems.get_Item(ref tempRefParam).Default;
												object tempRefParam2 = ilCounter;
												ctaCuenta.LimiteCredC = Decimal.Parse(lvwCuentas.ListItems.get_Item(ref tempRefParam2).get_SubItems(1), NumberStyles.Currency);
												object tempRefParam3 = ilCounter;
												ctaCuenta.ActualizaLimiteCredI(accAccion, Decimal.Parse(lvwCuentas.ListItems.get_Item(ref tempRefParam3).get_SubItems(2), NumberStyles.Currency), prySeguridadS041.topTipoOperMakerChecker.topChecker);
                                                txtLog.Text = txtLog.Text + "\r\n" + ctaCuenta.LogS;

                                               
											}
											Application.DoEvents();
										}
										mfnCargarMallaB();
										mdlADO.fncDesconectaM111b();
										ctaCuenta.fnDesconectarB();
									}
								}
							} 
                            else
							{
								MessageBox.Show("Debe seleccionar alguna solicitud a enviar.", "Autorización de Límites de Uso", MessageBoxButtons.OK, MessageBoxIcon.Information);
							} 
							this.Cursor = Cursors.Default; 
							break;
						case "DECLINAR" : 
							this.Cursor = Cursors.WaitCursor; 
							txtLog.Text = String.Empty; 
							if (RevisaSelB())
							{
								if (mdlADO.fncVerificaConexionM111b())
								{
									for (int ilCounter = 1; ilCounter <= lvwCuentas.ListItems.Count; ilCounter++)
									{
										ctaCuenta = new clsCuenta();
										object tempRefParam7 = ilCounter;
										if (lvwCuentas.ListItems.get_Item(ref tempRefParam7).Checked)
										{
											ctaCuenta.productoPRD = mdlParametros.gprdProducto;
											object tempRefParam5 = ilCounter;
											ctaCuenta.CuentaS = lvwCuentas.ListItems.get_Item(ref tempRefParam5).Default;
											object tempRefParam6 = ilCounter;
											ctaCuenta.LimiteCredC = Decimal.Parse(lvwCuentas.ListItems.get_Item(ref tempRefParam6).get_SubItems(1), NumberStyles.Currency);
											ctaCuenta.EliminaMakerI(VBSQL.gConn[10]);
										}
										Application.DoEvents();
									}
									mfnCargarMallaB();
									mdlADO.fncDesconectaM111b();
								}
							} else
							{
								MessageBox.Show("Debe seleccionar al menos un registro por declinar.", "Autorización de Límites de Uso", MessageBoxButtons.OK, MessageBoxIcon.Information);
							} 
							this.Cursor = Cursors.Default; 
							break;
						case "ACTUALIZAR" : 
							this.Cursor = Cursors.WaitCursor; 
							mfnCargarMallaB(); 
							txtLog.Text = String.Empty; 
							this.Cursor = Cursors.Default; 
							break;
					}
			
            }
			
			
			private bool RevisaSelB()
			{
					bool result = false;
					for (int ilCounter = 1; ilCounter <= lvwCuentas.ListItems.Count; ilCounter++)
					{
						object tempRefParam = ilCounter;
						if (lvwCuentas.ListItems.get_Item(ref tempRefParam).Checked)
						{
							result = true;
							break;
						}
					}
					return result;
			}
		}
}