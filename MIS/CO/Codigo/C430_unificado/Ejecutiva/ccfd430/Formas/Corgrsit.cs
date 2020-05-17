using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class CORGRSIT
		: System.Windows.Forms.Form
		{
		
			private void  CORGRSIT_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			//****************************************************************************
			//**                                                                        **
			//**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
			//**                                                                        **
			//**       ---------------------------------------------------------        **
			//**                                                                        **
			//**       Descripción: Grafica la sitacion actual de las cuentas           **
			//**                    por cada grupo y empresa                            **
			//**                                                                        **
			//**       Responsable: Felipe Zacarias Jimenez                             **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			string[, ] pszArrCuentas = null;
			int iNumPoints = 0;
			string pszGruCve = String.Empty;
			string pszEmpCve = String.Empty;
			
			int iTop = 0;
			int iLeft = 0;
			int iHeight = 0;
			int iWidth = 0;
			
			int hConexion = 0;
			int bGrafMax = 0;
			
			int lTotalProductos = 0;
			int lTotalCuentas = 0;
			
			const int INT_FONTSIZE_TIT = 150;
			const int INT_FONTSIZE_OTROS = 100;
			
			private void  Asigna_A_Grafica()
			{
					
					double dMax = 0;
					double dFactor = 0;
					string pszTitulo = String.Empty;
					double dCuentas = 0;
					
					ID_CRE_GRA_GPH.NumSets = 1;
					
					if (pszArrCuentas.GetUpperBound(0) > 0)
					{
						ID_CRE_GRA_GPH.NumPoints = (short) (pszArrCuentas.GetUpperBound(0) + 1);
					} else
					{
						ID_CRE_GRA_GPH.NumPoints = 2;
					}
					
					ID_CRE_GRA_GPH.ThisPoint = 1;
					for (int iCont = 1; iCont <= pszArrCuentas.GetUpperBound(0); iCont++)
					{
						if (iCont <= 10)
						{
							ID_CRE_GRA_GPH.GraphData = Single.Parse(pszArrCuentas[iCont, 2]);
						} else
						{
							dCuentas += Conversion.Val(pszArrCuentas[iCont, 2]);
							ID_CRE_GRA_GPH.GraphData = (float) dCuentas;
						}
					}
					
					for (int iCont = 1; iCont <= pszArrCuentas.GetUpperBound(0); iCont++)
					{
						if (iCont <= 10)
						{
							ID_CRE_GRA_GPH.LegendText = iCont.ToString() + " - " + Desc_Cuenta(pszArrCuentas[iCont, 1]);
						} else
						{
							ID_CRE_GRA_GPH.LegendText = iCont.ToString() + " - Otras";
						}
					}
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_DRAW;
					
			}
			
			private double Carga_Cuentas()
			{
					
					double result = 0;
					int hCuenta = 0;
					int iCont = 0;
					int iTotalCta = 0;
					FixedLengthString szCuenta = new FixedLengthString(CORBD.LEN_THS_CTA);
					
					string pszEmpresa = VB6.GetItemString(ID_CRE_EMP_COB, ID_CRE_EMP_COB.SelectedIndex);
					pszEmpresa = Strings.Mid(pszEmpresa, 1, Strings.InStr(2, pszEmpresa, " ", CompareMethod.Binary)).Trim();
					
					if (pszEmpresa.Length == CORVB.NULL_INTEGER)
					{
						CORVAR.igblCancela = 0;
						return result;
					}
					
					CORVAR.igblErr = CORCONST.OK;
					
					//ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = "sit_cuenta " + Format$(igblBanco) + "," + Format$(Val(pszEmpresa))
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "sit_cuenta " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Conversion.Val(pszEmpresa).ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					iNumPoints = CORPROC2.Cuenta_Registros();
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						iCont = CORVB.NULL_INTEGER;
						if (pszArrCuentas != null)
						{
							Array.Clear(pszArrCuentas, 0, pszArrCuentas.Length);
						}
						pszArrCuentas = ArraysHelper.InitializeArray<string[, ]>(new int[]{iNumPoints, 2}, new int[]{0, 0});
						
						lTotalCuentas = CORVB.NULL_INTEGER;
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							iCont++;
							szCuenta.Value = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL);
							iTotalCta = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
							pszArrCuentas[iCont, 1] = szCuenta.Value;
							pszArrCuentas[iCont, 2] = iTotalCta.ToString();
							lTotalCuentas += iTotalCta;
						};
					} else
					{
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						//igblErr = PostMessage(CORGRSIT.hWnd, WM_CLOSE, NULL_INTEGER, NULL_INTEGER)
					}
					
					result = iNumPoints;
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					return result;
			}
			
			private void  Carga_Empresas()
			{
					
					int hEmpresa = 0;
					int lEmpresa = 0;
					string pszEmpDesc = String.Empty;
					string pszEmp = String.Empty;
					
					ID_CRE_EMP_COB.Items.Clear();
					
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					// pszgblsql = "SELECT emp_num, emp_nom FROM " + DB_SYB_EMP + " WHERE gpo_banco=" + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "SELECT emp_num, emp_nom FROM " + CORBD.DB_SYB_EMP + " Where eje_prefijo= " + CORVAR.igblPref.ToString() + " AND gpo_banco=" + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							lEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
							pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL);
							//EISSA 03-10-2001. Cambio para el formateo del número de empresa.
							ID_CRE_EMP_COB.Items.Add(StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
						};
						if (ID_CRE_EMP_COB.Items.Count != 0)
						{
							ID_CRE_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
							pszEmp = VB6.GetItemString(ID_CRE_EMP_COB, CORVB.NULL_INTEGER);
							pszEmpCve = Conversion.Val(Strings.Mid(pszEmp, 1, pszEmp.IndexOf(' '))).ToString();
						}
						//igblErr = PostMessage(CORGRSIT.hWnd, WM_CLOSE, NULL_INTEGER, NULL_INTEGER)
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					
			}
			
			private int Carga_Productos()
			{
					
					int result = 0;
					int iCont = 0;
					int hProducto = 0;
					int iTotalCta = 0;
					int iTotalProd = 0;
					string pszCuenta = String.Empty;
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							iNumPoints = CORVB.NULL_INTEGER;
							
							//ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
							//***** INICIO CODIGO ANTERIOR FSWBMX *****
							//  pszgblsql = "sit_producto " + Format$(igblBanco)
							//***** FIN DE CODIGO ANTERIOR FSWBMX *****
							//***** INICIO CODIGO NUEVO FSWBMX *****
							CORVAR.pszgblsql = "sit_producto " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
							//***** FIN DE CODIGO NUEVO FSWBMX *****
							iNumPoints = CORPROC2.Cuenta_Registros();
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								iCont = CORVB.NULL_INTEGER;
								if (pszArrCuentas != null)
								{
									Array.Clear(pszArrCuentas, 0, pszArrCuentas.Length);
								}
								pszArrCuentas = ArraysHelper.InitializeArray<string[, ]>(new int[]{iNumPoints, 2}, new int[]{0, 0});
								
								lTotalProductos = CORVB.NULL_INTEGER;
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									iCont++;
									pszCuenta = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL);
									iTotalProd = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
									pszArrCuentas[iCont, 1] = pszCuenta;
									pszArrCuentas[iCont, 2] = iTotalProd.ToString();
									lTotalProductos += iTotalProd;
								};
							} else
							{
								//igblErr = PostMessage(CORGRSIT.hWnd, WM_CLOSE, NULL_INTEGER, NULL_INTEGER)
							}
							
							result = iNumPoints;
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
					return result;
			}
			
			private string Desc_Cuenta( string pszCuenta)
			{
					
					string pszDescripcion = String.Empty;
					
					switch(pszCuenta)
					{
						case " " :  
							pszDescripcion = "Situación Normal"; 
							break;
						case "A" :  
							pszDescripcion = "Autorización Prohibida"; 
							break;
						case "B" :  
							pszDescripcion = "Inicio de Etapa de Crédito"; 
							break;
						case "C" :  
							pszDescripcion = "Cancelada sin Saldo"; 
							break;
						case "D" :  
							pszDescripcion = "Delincuente"; 
							break;
						case "E" :  
							pszDescripcion = "Cancelada con Saldo"; 
							break;
						case "F" :  
							pszDescripcion = "Cancelada con Saldo y Cobro"; 
							break;
						case "H" :  
							pszDescripcion = "Crédito Otorgado"; 
							break;
						case "I" :  
							pszDescripcion = "Prestamo Consumido"; 
							break;
						case "J" :  
							pszDescripcion = "Etapa de Crédito"; 
							break;
						case "W" :  
							pszDescripcion = "Congelada"; 
							break;
						case "U" :  
							pszDescripcion = "Robada"; 
							break;
						case "L" :  
							pszDescripcion = "Extraviada"; 
							break;
						case "S" :  
							pszDescripcion = "Reporte en Sucursal Por Robo o Extravío"; 
							break;
						case "P" :  
							pszDescripcion = "Problema de Cobro"; 
							break;
						case "T" :  
							pszDescripcion = "Redocumetada"; 
							break;
						case "V" :  
							pszDescripcion = "Restaurada"; 
							break;
						case "G" :  
							pszDescripcion = "Traspaso de Crédito"; 
							break;
						case "R" :  
							pszDescripcion = "Crédito Especial"; 
							break;
						case "Z" :  
							pszDescripcion = "Crédito Especial"; 
							break;
						default: 
							pszDescripcion = "Sin Registrar"; 
							break;
					}
					
					return pszDescripcion;
					
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					int iGrupos = 0;
					int iCuentas = 0;
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY(1250);
					
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					iNumPoints = CORVB.NULL_INTEGER;
					
					Carga_Empresas();
					
					ID_GRA_PAR_COB.Items.Add("Por Producto");
					ID_GRA_PAR_COB.Items.Add("Por Empresa");
					ID_GRA_PAR_COB.SelectedIndex = CORVB.NULL_INTEGER;
					
					ID_CRE_GRA_GPH.FontUse = CORVB.G_USE_ALL;
					ID_CRE_GRA_GPH.FontFamily = CORVB.G_FONT_SWISS;
					ID_CRE_GRA_GPH.FontStyle = CORVB.G_STYLE_DEFAULT;
					//Se definen para el Título
					ID_CRE_GRA_GPH.FontUse = CORVB.G_USE_DEFAULT;
					ID_CRE_GRA_GPH.Font = VB6.FontChangeSize(ID_CRE_GRA_GPH.Font, INT_FONTSIZE_TIT);
					
					//Se definen para los Títulos de la Izquierda y de Pie de Gráfica
					ID_CRE_GRA_GPH.FontUse = CORVB.G_USE_OTHER;
					ID_CRE_GRA_GPH.Font = VB6.FontChangeSize(ID_CRE_GRA_GPH.Font, INT_FONTSIZE_OTROS);
					
					//Se definen para los legend Text (los de la derecha)
					ID_CRE_GRA_GPH.FontUse = CORVB.G_USE_LEGEND;
					ID_CRE_GRA_GPH.Font = VB6.FontChangeSize(ID_CRE_GRA_GPH.Font, INT_FONTSIZE_OTROS);
					
					ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					
					this.Cursor = Cursors.Default;
					
					bGrafMax = 0;
					
			}
			
			private void  ID_CRE_EMP_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_CRE_TIP_PNL.Enabled = false;
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_CRE_GRA_GPH_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_CRE_GRA_GPH.Visible = false;
					ID_GRA_IMP_PB.Visible = false;
					Refresh();
					
					if (bGrafMax != 0)
					{
						ID_GRA_IMP_PB.Left = (int) VB6.TwipsToPixelsX(5865);
						ID_CRE_GRA_PB.Visible = true;
						ID_CRE_SAL_PB.Visible = true;
						ID_CRE_GRA_GPH.Top = (int) VB6.TwipsToPixelsY(iTop);
						ID_CRE_GRA_GPH.Left = (int) VB6.TwipsToPixelsX(iLeft);
						ID_CRE_GRA_GPH.Width = (int) VB6.TwipsToPixelsX(iWidth);
						ID_CRE_GRA_GPH.Height = (int) VB6.TwipsToPixelsY(iHeight);
						bGrafMax = 0;
					} else
					{
						ID_GRA_IMP_PB.Left = (int) VB6.TwipsToPixelsX(300);
						ID_CRE_GRA_PB.Visible = false;
						ID_CRE_SAL_PB.Visible = false;
						
						iTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_CRE_GRA_GPH.Top));
						iLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_CRE_GRA_GPH.Left));
						iWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_CRE_GRA_GPH.Width));
						iHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_CRE_GRA_GPH.Height));
						
						ID_CRE_GRA_GPH.Top = (int) VB6.TwipsToPixelsY(-15);
						ID_CRE_GRA_GPH.Left = (int) VB6.TwipsToPixelsX(-15);
						ID_CRE_GRA_GPH.Width = (int) Width;
						ID_CRE_GRA_GPH.Height = (int) VB6.TwipsToPixelsY(((float) VB6.PixelsToTwipsY(Height)) - 300);
						bGrafMax = -1;
						ID_GRA_IMP_PB.BringToFront();
						Refresh();
						
					}
					
					ID_GRA_IMP_PB.Visible = true;
					ID_CRE_GRA_GPH.Visible = true;
					
			}
			
			private void  ID_CRE_GRA_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					int iProductos = 0;
					int iCuentas = 0;
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							this.Cursor = Cursors.WaitCursor;
							
							ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
							
							ID_CRE_GRA_GPH.GraphTitle = "Situación de la Cuenta " + ID_GRA_PAR_COB.Text;
							
							if (ID_GRA_PAR_COB.SelectedIndex == 0)
							{
								CORVAR.igblCancela = -1;
								iProductos = Carga_Productos();
								if (iProductos != CORVB.NULL_INTEGER)
								{
									if (CORVAR.igblCancela != 0)
									{
										ID_CRE_TIP_PNL.Enabled = true;
										if (ID_CRE_GRA_GPH.GraphStyle == 4)
										{
											ID_CRE_GRA_GPH.LeftTitle = "Total = " + lTotalProductos.ToString() + " Tarjetas";
											ID_CRE_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
										} else
										{
											ID_CRE_GRA_GPH.LeftTitle = "Tarjetas";
											ID_CRE_GRA_GPH.BottomTitle = "Situaciones";
										}
										Asigna_A_Grafica();
									}
								} else
								{
									this.Cursor = Cursors.Default;
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
									Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
									//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
									ID_CRE_GRA_GPH.DrawMode = CORVB.G_CLEAR;
									ID_CRE_TIP_PNL.Enabled = false;
									return;
								}
							} else
							{
								if (ID_CRE_IRA_CHK.Value)
								{
                                    //AIS-(INT) NGONZALEZ
									CORVAR.igblAccion = (int) CORVB.G_DRAW;
									CORIREMP.DefInstance.Tag = "CORGRSIT";
									//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
									CORIREMP.DefInstance.ShowDialog();
									this.Refresh();
								} else
								{
									//EISSA 03-10-2001. Cambio para obtener la longitud del número de empresa.
									CORVAR.lgblTempNumEmp = Convert.ToInt32(Conversion.Val(Strings.Mid(VB6.GetItemString(ID_CRE_EMP_COB, ID_CRE_EMP_COB.SelectedIndex), 1, Formato.sMascara(Formato.iTipo.Empresa).Length)));
								}
								
								if (CORVAR.lgblTempNumEmp > CORVB.NULL_INTEGER)
								{
									CORVAR.igblCancela = -1;
									ID_CRE_TIP_PNL.Enabled = true;
									if (ID_CRE_GRA_GPH.GraphStyle == 4)
									{
										ID_CRE_GRA_GPH.LeftTitle = "Total = " + lTotalCuentas.ToString() + " Tarjetas";
										ID_CRE_GRA_GPH.BottomTitle = CORVB.NULL_STRING + ID_CRE_EMP_COB.Text.Trim();
									} else
									{
										ID_CRE_GRA_GPH.LeftTitle = "Tarjetas";
										ID_CRE_GRA_GPH.BottomTitle = "Situaciones   " + ID_CRE_EMP_COB.Text.Trim();
									}
									iCuentas = Convert.ToInt32(Carga_Cuentas());
									
									//      If igblErr = OK Then
									if (iCuentas != 0)
									{
										if (CORVAR.igblCancela != 0)
										{
											Asigna_A_Grafica();
										}
									} else
									{
										this.Cursor = Cursors.Default;
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
										//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
										//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
										Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
										//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
										ID_CRE_GRA_GPH.DrawMode = CORVB.G_CLEAR;
										ID_CRE_TIP_PNL.Enabled = false;
										return;
									}
									//      Else
									//        igblErr = PostMessage(hwnd, WM_CLOSE, NULL_INTEGER, NULL_INTEGER)
									//        Exit Sub
									//      End If
								}
							}
							
							this.Cursor = Cursors.Default;
						}
					catch (Exception exc)
					{
                        CRSGeneral.prObtenError(this.GetType().Name + "()", exc);
						//throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			private void  ID_CRE_SAL_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Close();
					
			}
			
			private void  ID_CRE_TIP_SSR_ClickEvent( Object eventSender,  AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
			{
					int Index = Array.IndexOf(ID_CRE_TIP_SSR, eventSender);
					
					string pszConcepto = String.Empty;
					switch(Index)
					{
						case 0 : 
							ID_CRE_GRA_GPH.GraphType = CORVB.G_BAR2D; 
							ID_CRE_GRA_GPH.GraphStyle = 0; 
							break;
						case 1 : 
							ID_CRE_GRA_GPH.GraphType = CORVB.G_BAR3D; 
							ID_CRE_GRA_GPH.GraphStyle = 0; 
							break;
						case 2 : 
							ID_CRE_GRA_GPH.GraphType = CORVB.G_PIE2D; 
							ID_CRE_GRA_GPH.GraphStyle = 4; 
							break;
						case 3 : 
							ID_CRE_GRA_GPH.GraphType = CORVB.G_PIE3D; 
							ID_CRE_GRA_GPH.GraphStyle = 4; 
							break;
					}
					
					if (ID_GRA_PAR_COB.SelectedIndex != 0)
					{
						pszConcepto = lTotalCuentas.ToString();
					} else
					{
						pszConcepto = lTotalProductos.ToString();
					}
					
					if (ID_CRE_GRA_GPH.GraphStyle == 4)
					{
						ID_CRE_GRA_GPH.LeftTitle = "Total = " + pszConcepto + " Tarjetas";
						if (ID_GRA_PAR_COB.SelectedIndex == 0)
						{
							ID_CRE_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
						} else
						{
							ID_CRE_GRA_GPH.BottomTitle = ID_CRE_EMP_COB.Text.Trim();
						}
					} else
					{
						ID_CRE_GRA_GPH.LeftTitle = "Tarjetas";
						if (ID_GRA_PAR_COB.SelectedIndex == 0)
						{
							ID_CRE_GRA_GPH.BottomTitle = "Situaciones";
						} else
						{
							ID_CRE_GRA_GPH.BottomTitle = "Situaciones   " + ID_CRE_EMP_COB.Text.Trim();
						}
					}
					
					Refresh();
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_DRAW;
					
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (ID_GRA_GRA_GPB_Click) seems to be dead code
			//private void  ID_GRA_GRA_GPB_Click( int Index,  int Value)
			//{
					//
			//}
			
			private void  ID_GRA_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_PRINT;
					
			}
			
			private void  ID_GRA_PAR_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_CRE_TIP_PNL.Enabled = false;
					
					if (ID_GRA_PAR_COB.SelectedIndex == 1)
					{
						ID_CRE_EMP_TXT.Visible = true;
						ID_CRE_EMP_COB.Visible = true;
						ID_CRE_IRA_CHK.Visible = true;
					} else
					{
						ID_CRE_EMP_TXT.Visible = false;
						ID_CRE_EMP_COB.Visible = false;
						ID_CRE_IRA_CHK.Visible = false;
						ID_CRE_IRA_CHK.Value = false;
					}
					
					ID_CRE_GRA_GPH.Visible = true;
					
					this.Cursor = Cursors.Default;
					
			}
			private void  CORGRSIT_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}