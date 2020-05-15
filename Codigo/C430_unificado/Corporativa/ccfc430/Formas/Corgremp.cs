using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORGREMP
		: System.Windows.Forms.Form
		{
		
			private void  CORGREMP_Activated( Object eventSender,  EventArgs eventArgs)
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
			//**       Descripción: Grafica de Empresas                                 **
			//**                                                                        **
			//**       Responsable:                                                     **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			int iErr = 0;
			//AIS-1178 NGONZALEZ
			CORVAR.DatEmpresa[] iArrNumEjec;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
			int lSumCred = 0;
			int lSumEmp = 0;
			int lSumEjec = 0;
			int lSumSect = 0;
			int bMaximizada = 0;
			//Variables para controlar la Maximización y Minimización de la Gráfica
			int iPnlTop = 0;
			int iPnlLeft = 0;
			int iPnlHeight = 0;
			int iPnlWidth = 0;
			int iGphTop = 0;
			int iGphLeft = 0;
			int iGphHeight = 0;
			int iGphWidth = 0;
			int iImpTop = 0;
			int iImpLeft = 0;
			int hConexion = 0;
			int iNumRegsEMPEJE = 0;
			int lContador = 0;
			int lNumRegsCred = 0;
			
			const int INT_FONTSIZE_TIT = 150;
			const int INT_FONTSIZE_OTROS = 100;
			
			private int Carga_Combo()
			{
					
					ID_CEE_EMP_COB.Items.Add("Empresa-Ejecutivos");
					ID_CEE_EMP_COB.Items.Add("Empresa-Credito");
					ID_CEE_EMP_COB.Items.Add("Empresas por Sector");
					ID_CEE_EMP_COB.Items.Add("Empresas por División");
					ID_CEE_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
					
					return 0;
			}
			
			private int Empresa_Credito()
			{
					
					int hBufEjecEmp = 0;
					int iTempErr = 0;
					int iNumRegs = 0;
					FixedLengthString szNomEmpresa = new FixedLengthString(45);
					int lNumEmp = 0;
					int lCredTot = 0;
					int iCont = 0;
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							//***** INICIO CODIGO ANTERIOR FSWBMX *****
							//pszgblsql = "select gpo_banco, emp_num, emp_nom, emp_cred_tot from " + DB_SYB_EMP + " where gpo_banco=" + Format$(igblBanco) + " order by emp_cred_tot desc "
							//***** FIN DE CODIGO ANTERIOR FSWBMX *****
							//***** INICIO CODIGO NUEVO FSWBMX *****
							CORVAR.pszgblsql = "select gpo_banco, emp_num, emp_nom, emp_cred_tot from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " order by emp_cred_tot desc ";
							//***** FIN DE CODIGO NUEVO FSWBMX *****
							
							lNumRegsCred = CORPROC2.Cuenta_Registros();
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								if (lNumRegsCred != 0)
								{
									//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
									iArrNumEjec = new CORVAR.DatEmpresa[lNumRegsCred];
									//    Else
									//      ReDim iArrNumEjec(10)
								}
								iCont = CORVB.NULL_INTEGER;
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									lNumEmp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
									iArrNumEjec[iCont].lNumEmpresa += lNumEmp;
									szNomEmpresa.Value = VBSQL.SqlData(CORVAR.hgblConexion, 3);
									lCredTot = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
									lCredTot = lCredTot; /// 1000
									lSumCred += lCredTot;
									
									//      If iCont >= 9 Then
									
									//        iArrNumEjec(iCont).pszNomEmpresa = "Otras"
									//        iArrNumEjec(iCont).lCredTotal = iArrNumEjec(iCont).lCredTotal + lCredTot
									//      Else
									iArrNumEjec[iCont].pszNomEmpresa = szNomEmpresa.Value.Trim();
									iArrNumEjec[iCont].lCredTotal = lCredTot;
									iCont++;
									//      End If
								};
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								
								//asigna titulos a la grafica
								ID_GRA_GPH.GraphTitle = "Empresa - Credito";
								ID_GRA_GPH.LeftTitle = "Credito Asignado ";
								
								//  If UBound(iArrNumEjec) > 1 Then
								//    ID_GRA_GPH.NumPoints = UBound(iArrNumEjec)
								//  Else
								//    ID_GRA_GPH.NumPoints = 2
								//  End If
								
								ID_GRA_GPH.NumPoints = 10;
								
								ID_GRA_GPH.ThisPoint = 1;
								for (iCont = 0; iCont <= 9; iCont++)
								{ //UBound(iArrNumEjec) - 1
									ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lCredTotal;
								}
								ID_GRA_GPH.ThisPoint = 1;
								for (iCont = 0; iCont <= 9; iCont++)
								{ //UBound(iArrNumEjec) - 1
									ID_GRA_GPH.LegendText = StringsHelper.Format(iCont, "000") + "  " + Strings.Mid(iArrNumEjec[iCont].pszNomEmpresa.ToUpper(), 1, 25);
								}
								if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
								{
									ID_GRA_GPH.LeftTitle = "Total  = " + StringsHelper.Format(lSumCred, "###,###,###,#00.00");
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
								} else
								{
									ID_GRA_GPH.LeftTitle = "Crédito total ";
									ID_GRA_GPH.BottomTitle = "Empresas";
								}
							} else
							{
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox("No existen Registros a Graficar.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
							}
							
							//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
							ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw;
							
							lContador = 10;
							
							this.Cursor = Cursors.Default;
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
					return 0;
			}
			
			private int Empresa_Ejecutivos()
			{
					
					int hBufEjecEmp = 0;
					int iTempErr = 0;
					int iNumRegs = 0;
					FixedLengthString szNomEmpresa = new FixedLengthString(45);
					int iTotEjec = 0;
					int iCont = 0;
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							//***** INICIO CODIGO ANTERIOR FSWBMX *****
							//pszgblsql = "exec graemp_carga_emp " + Format$(igblBanco)
							//***** FIN DE CODIGO ANTERIOR FSWBMX *****
							//***** INICIO CODIGO NUEVO FSWBMX *****
							CORVAR.pszgblsql = "exec graemp_carga_emp " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
							//***** FIN DE CODIGO NUEVO FSWBMX *****
							
							iNumRegsEMPEJE = CORPROC2.Cuenta_Registros();
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								if (iNumRegsEMPEJE != 0)
								{
									//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
									iArrNumEjec = new CORVAR.DatEmpresa[iNumRegsEMPEJE];
									//      ReDim iArrNumEjec(iNumRegs)
									//    Else
									//      ReDim iArrNumEjec(10)
								}
								iCont = CORVB.NULL_INTEGER;
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									iTotEjec = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
									lSumEjec += iTotEjec;
									szNomEmpresa.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
									//      If iCont >= 9 Then
									//        iArrNumEjec(iCont).pszNomEmpresa = "Otras"
									//        iArrNumEjec(iCont).iTotalEjec = iArrNumEjec(iCont).iTotalEjec + iTotEjec
									//      Else
									iArrNumEjec[iCont].pszNomEmpresa = szNomEmpresa.Value.Trim();
									iArrNumEjec[iCont].iTotalEjec = iTotEjec;
									iCont++;
									//      End If
								};
								
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								
								ID_GRA_GPH.GraphTitle = "Empresa - Ejecutivos";
								ID_GRA_GPH.LeftTitle = "Número de Ejecutivos";
								
								//  If UBound(iArrNumEjec) > 1 Then
								//    ID_GRA_GPH.NumPoints = UBound(iArrNumEjec)
								//  Else
								//    ID_GRA_GPH.NumPoints = 2
								//  End If
								
								ID_GRA_GPH.NumPoints = 10;
								
								ID_GRA_GPH.ThisPoint = 1;
								for (iCont = 0; iCont <= 9; iCont++)
								{ //UBound(iArrNumEjec) - 1
									ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalEjec;
								}
								ID_GRA_GPH.ThisPoint = 1;
								for (iCont = 0; iCont <= 9; iCont++)
								{ //UBound(iArrNumEjec) - 1
									ID_GRA_GPH.LegendText = StringsHelper.Format(iCont, "000") + "  " + Strings.Mid(iArrNumEjec[iCont].pszNomEmpresa.ToUpper(), 1, 25);
								}
								
								if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
								{
									ID_GRA_GPH.LeftTitle = "Total  = " + lSumEjec.ToString() + " ejecutivos";
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
								} else
								{
									ID_GRA_GPH.LeftTitle = "Número de Ejecutivos";
									ID_GRA_GPH.BottomTitle = "Empresas";
								}
								
								//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
								ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw;
								
								lContador = 10;
							} else
							{
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox("No existen Registros a Graficar.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
							}
							this.Cursor = Cursors.Default;
							ID_GRA_GPH.Refresh();
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					return 0;
			}
			
			private int Empresas_Division()
			{
					
					int hBufEjecEmp = 0;
					int hBufEjecEmp2 = 0;
					int iTempErr = 0;
					int lNumEmp = 0;
					FixedLengthString szNomDivision = new FixedLengthString(45);
					int lNumEjx = 0;
					int lCredTot = 0;
					int iCont = 0;
					string pszSQL = String.Empty;
					
					this.Cursor = Cursors.WaitCursor;
					
					//ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//pszgblsql = "exec graemp_carga_div " + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "exec graemp_carga_div " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					int iNumRegs = CORPROC2.Cuenta_Registros();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						if (iNumRegs < 10)
						{
							//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
							iArrNumEjec = new CORVAR.DatEmpresa[iNumRegs + 1];
						} else
						{
							//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
							iArrNumEjec = new CORVAR.DatEmpresa[11];
						}
						
						iCont = CORVB.NULL_INTEGER;
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							szNomDivision.Value = VBSQL.SqlData(CORVAR.hgblConexion, 1);
							lNumEmp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
							lSumEmp += lNumEmp;
							iArrNumEjec[iCont].lNumEmpresa = lNumEmp;
							if (iCont >= 9)
							{
								iArrNumEjec[iCont].pszNomDivision = "Otras";
								iArrNumEjec[iCont].lNumEmpresa += lNumEmp;
							} else
							{
								iArrNumEjec[iCont].pszNomDivision = szNomDivision.Value.Trim();
								iCont++;
							}
						};
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						
						if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
						{
							ID_GRA_GPH.LeftTitle = "Total  = " + lSumEmp.ToString() + " empresas";
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
						} else
						{
							ID_GRA_GPH.LeftTitle = "Número de Empresas";
							ID_GRA_GPH.BottomTitle = "Empresas";
						}
						
						ID_GRA_GPH.GraphTitle = "Empresas por Divisiones";
						if (iArrNumEjec.GetUpperBound(0) < 2)
						{
							ID_GRA_GPH.NumPoints = 2;
						} else
						{
							ID_GRA_GPH.NumPoints = (short) iArrNumEjec.GetUpperBound(0);
						}
						ID_GRA_GPH.ThisPoint = 1;
						for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
						{
							ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
						}
						ID_GRA_GPH.ThisPoint = 1;
						for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
						{
							ID_GRA_GPH.LegendText = iArrNumEjec[iCont].pszNomDivision;
						}
						
						//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
						ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw;
					} else
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No existen Registros a Graficar.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
					}
					this.Cursor = Cursors.Default;
					
					return 0;
			}
			
			private int Empresas_Sector()
			{
					
					int hBufEjecEmp = 0;
					int iTempErr = 0;
					FixedLengthString szNomEmpresa = new FixedLengthString(45);
					int iEmpSector = 0;
					int iTotSect = 0;
					int lCredTot = 0;
					int iCont = 0;
					
					
					this.Cursor = Cursors.WaitCursor;
					
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//pszgblsql = "exec graemp_carga_sec " + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "exec graemp_carga_sec " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					int iNumRegs = CORPROC2.Cuenta_Registros();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
						iArrNumEjec = new CORVAR.DatEmpresa[iNumRegs + 1];
						iCont = CORVB.NULL_INTEGER;
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							iEmpSector = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							/*switch(iEmpSector)
							{
								case 1 : 
									iArrNumEjec[iCont].pszNomEmpresa = CORCONST.STR_SEC_IND; 
									break;
								case 2 : 
									iArrNumEjec[iCont].pszNomEmpresa = CORCONST.STR_SEC_CMR; 
									break;
								case 3 : 
									iArrNumEjec[iCont].pszNomEmpresa = CORCONST.STR_SEC_SER; 
									break;
								case 4 : 
									iArrNumEjec[iCont].pszNomEmpresa = CORCONST.STR_SEC_COM; 
									break;
								case 5 : 
									iArrNumEjec[iCont].pszNomEmpresa = CORCONST.STR_SEC_TRA; 
									break;
								case 6 : 
									iArrNumEjec[iCont].pszNomEmpresa = CORCONST.STR_SEC_FIN; 
									break;
								case 7 : 
									iArrNumEjec[iCont].pszNomEmpresa = CORCONST.STR_SEC_TNF; 
									break;
								case 8 : 
									iArrNumEjec[iCont].pszNomEmpresa = CORCONST.STR_SEC_OTR; 
									break;
							}*/
							iArrNumEjec[iCont].pszNomEmpresa=CORCONST.arregloSectorEmpresa[iEmpSector];
                            
							iTotSect = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
							lSumSect += iTotSect;
							iArrNumEjec[iCont].iTotalSect = iTotSect;
							iCont++;
							
						};
						
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						
						ID_GRA_GPH.GraphTitle = "Empresas por Sector";
						
						if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
						{
							ID_GRA_GPH.LeftTitle = "Total  = " + lSumSect.ToString() + " empresas";
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
						} else
						{
							ID_GRA_GPH.LeftTitle = "Número de Empresas";
							ID_GRA_GPH.BottomTitle = "Empresas";
						}
						
						if (iArrNumEjec.GetUpperBound(0) > 1)
						{
							ID_GRA_GPH.NumPoints = (short) iArrNumEjec.GetUpperBound(0);
						} else
						{
							ID_GRA_GPH.NumPoints = 2;
						}
						ID_GRA_GPH.ThisPoint = 1;
						for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
						{
							ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalSect;
						}
						ID_GRA_GPH.ThisPoint = 1;
						for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
						{
							ID_GRA_GPH.LegendText = iArrNumEjec[iCont].pszNomEmpresa;
						}
						//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
						ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw;
					} else
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No existen Registros a Graficar.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
					}
					
					this.Cursor = Cursors.Default;
					
					return 0;
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY(1250);
					
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					
					
					ID_GRA_GPH.FontUse = CORVB.G_USE_ALL;
					ID_GRA_GPH.FontFamily = CORVB.G_FONT_SWISS;
					ID_GRA_GPH.FontStyle = CORVB.G_STYLE_DEFAULT;
					//Se definen para el Título
					ID_GRA_GPH.FontUse = CORVB.G_USE_DEFAULT;
					ID_GRA_GPH.Font = VB6.FontChangeSize(ID_GRA_GPH.Font, INT_FONTSIZE_TIT);
					
					//Se definen para los Títulos de la Izquierda y de Pie de Gráfica
					ID_GRA_GPH.FontUse = CORVB.G_USE_OTHER;
					ID_GRA_GPH.Font = VB6.FontChangeSize(ID_GRA_GPH.Font, INT_FONTSIZE_OTROS);
					
					//Se definen para los legend Text (los de la derecha)
					ID_GRA_GPH.FontUse = CORVB.G_USE_LEGEND;
					ID_GRA_GPH.Font = VB6.FontChangeSize(ID_GRA_GPH.Font, INT_FONTSIZE_OTROS);
					
					ID_GRA_MEMP_PB.Visible = false;
					
					int iOpcion = Carga_Combo();
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_CEE_EMP_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_GRA_GRP_PNL.Enabled = false;
					
			}

            private void ID_EMP_GRA_PB_Click(Object eventSender, EventArgs eventArgs)
            {

                int iOpcion = 0;

                lSumCred = CORVB.NULL_INTEGER;
                lSumEmp = CORVB.NULL_INTEGER;
                lSumEjec = CORVB.NULL_INTEGER;
                lSumSect = CORVB.NULL_INTEGER;
                lContador = CORVB.NULL_INTEGER;

                ID_GRA_GRP_PNL.Enabled = true;

                try
                {



                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                    ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphClear;
                    switch (ID_CEE_EMP_COB.SelectedIndex)
                    {
                        case 0:
                            iOpcion = Empresa_Ejecutivos();
                            ID_GRA_MEMP_PB.Visible = true;
                            break;
                        case 1:
                            iOpcion = Empresa_Credito();
                            ID_GRA_MEMP_PB.Visible = true;
                            break;
                        case 2:
                            iOpcion = Empresas_Sector();
                            ID_GRA_MEMP_PB.Visible = false;
                            break;
                        case 3:
                            iOpcion = Empresas_Division();
                            ID_GRA_MEMP_PB.Visible = false;
                            break;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Fallo operación ID_EMP_GRA_PB_Click " + exc.Message, "Error Corgremp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
			
			private void  ID_GRA_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Close();
					
			}
			
			private void  ID_GRA_GPH_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					
					if (bMaximizada != 0)
					{ //Minimiza
						
						ID_GRA_IMP_PB.Visible = false;
						ID_GRA_GPH.Visible = false;
						ID_GRA_PRI1_PNL.Visible = false;
						this.Refresh();
						
						//Guardamos las Medidas Originales del Panel de la Gráfica
						ID_GRA_PRI1_PNL.Top = (int) VB6.TwipsToPixelsY(iPnlTop);
						ID_GRA_PRI1_PNL.Left = (int) VB6.TwipsToPixelsX(iPnlLeft);
						ID_GRA_PRI1_PNL.Height = (int) VB6.TwipsToPixelsY(iPnlHeight);
						ID_GRA_PRI1_PNL.Width = (int) VB6.TwipsToPixelsX(iPnlWidth);
						
						//Guardamos las Medidas Originales de la Gráfica
						ID_GRA_GPH.Top = (int) VB6.TwipsToPixelsY(iGphTop);
						ID_GRA_GPH.Left = (int) VB6.TwipsToPixelsX(iGphLeft);
						ID_GRA_GPH.Height = (int) VB6.TwipsToPixelsY(iGphHeight);
						ID_GRA_GPH.Width = (int) VB6.TwipsToPixelsX(iGphWidth);
						
						ID_GRA_IMP_PB.Top = (int) VB6.TwipsToPixelsY(iImpTop);
						ID_GRA_IMP_PB.Left = (int) VB6.TwipsToPixelsX(iImpLeft);
						
						ID_GRA_PRI1_PNL.Visible = true;
						ID_GRA_PRI_PNL.Visible = true;
						ID_GRA_GRP_PNL.Visible = true;
						ID_EMP_GRA_PB.Visible = true;
						ID_GRA_CAN_PB.Visible = true;
						ID_GRA_IMP_PB.Visible = true;
						this.Refresh();
						ID_GRA_GPH.Visible = true;
						bMaximizada = 0;
						
					} else
					{
						//Ocultamos todos los controles
						ID_GRA_GPH.Visible = false;
						ID_GRA_PRI1_PNL.Visible = false;
						ID_GRA_PRI_PNL.Visible = false;
						ID_GRA_GRP_PNL.Visible = false;
						ID_GRA_IMP_PB.Visible = false;
						ID_EMP_GRA_PB.Visible = false;
						ID_GRA_CAN_PB.Visible = false;
						this.Refresh();
						
						//Guardamos las Medidas Originales de la Gráfica
						iGphTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_GPH.Top));
						iGphLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_GPH.Left));
						iGphHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_GPH.Height));
						iGphWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_GPH.Width));
						
						//Guardamos las Medidas Originales del Panel de la Gráfica
						iPnlTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_PRI1_PNL.Top));
						iPnlLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_PRI1_PNL.Left));
						iPnlHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_PRI1_PNL.Height));
						iPnlWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_PRI1_PNL.Width));
						
						//Guardamos las Medidas Originales del Boton de Imprimir
						iImpTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_IMP_PB.Top));
						iImpLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_IMP_PB.Left));
						
						//Ajustamos las Medidas del Panel de la Gráfica
						ID_GRA_PRI1_PNL.Top = (int) ID_GRA_PRI_PNL.Top;
						ID_GRA_PRI1_PNL.Left = (int) ID_GRA_PRI_PNL.Left;
						ID_GRA_PRI1_PNL.Height = (int) (ID_GRA_PRI_PNL.Height + ID_GRA_PRI1_PNL.Height);
						ID_GRA_PRI1_PNL.Width = (int) ID_GRA_PRI_PNL.Width;
						
						//Ajustamos las Medidas de la Gráfica
						ID_GRA_GPH.Top = (int) ID_GRA_PRI1_PNL.Top;
						ID_GRA_GPH.Left = (int) ID_GRA_PRI1_PNL.Left;
						ID_GRA_GPH.Height = (int) ID_GRA_PRI1_PNL.Height;
						ID_GRA_GPH.Width = (int) ID_GRA_PRI1_PNL.Width;
						this.Refresh();
						
						ID_GRA_IMP_PB.Top = (int) (ID_GRA_GPH.Height - VB6.TwipsToPixelsY(((float) VB6.PixelsToTwipsY(ID_GRA_IMP_PB.Height)) * 1.5d));
						ID_GRA_IMP_PB.Left = (int) VB6.TwipsToPixelsX(((float) VB6.PixelsToTwipsX(ID_GRA_IMP_PB.Width)) * 0.2d);
						ID_GRA_IMP_PB.BringToFront();
						this.Refresh();
						
						ID_GRA_IMP_PB.Visible = true;
						ID_GRA_GPH.Visible = true;
						ID_GRA_PRI1_PNL.Visible = true;
						bMaximizada = -1;
						
					}
					
			}
			
			private void  ID_GRA_GRA_GPB_ClickEvent( Object eventSender,  AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
			{
					int Index = Array.IndexOf(ID_GRA_GRA_GPB, eventSender);
					
					switch(ID_CEE_EMP_COB.SelectedIndex)
					{
						case 0 : 
							Opciones_Ejecutivos(Index); 
							break;
						case 1 : 
							Opciones_Credito(Index); 
							break;
						case 2 : 
							Opciones_Sector(Index); 
							break;
						case 3 : 
							Opciones_Division(Index); 
							break;
					}
					
			}
			
			private void  ID_GRA_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_PRINT;
					this.Cursor = Cursors.Default;
					
			}
			
			private void  Opciones_Credito( int indice)
			{
					
					double dCredito = 0;
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							ID_GRA_GPH.NumPoints = 10; //UBound(iArrNumEjec)
							switch(indice)
							{
								case 0 : 
									ID_GRA_GPH.GraphType = CORCONST.INT_BAR_DOS_DIM; 
									ID_GRA_GPH.GraphStyle = 0; 
									ID_GRA_GPH.ThisPoint = 1; 
									ID_GRA_GPH.LeftTitle = "Credito Asignado "; 
									ID_GRA_GPH.BottomTitle = "Empresas"; 
									for (int iCont = 0; iCont <= 9; iCont++)
									{ //UBound(iArrNumEjec) - 1
										ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lCredTotal;
									} 
									break;
								case 1 : 
									ID_GRA_GPH.GraphType = CORCONST.INT_BAR_TRES_DIM; 
									ID_GRA_GPH.GraphStyle = 0; 
									ID_GRA_GPH.ThisPoint = 1; 
									ID_GRA_GPH.LeftTitle = "Credito Asignado "; 
									ID_GRA_GPH.BottomTitle = "Empresas"; 
									for (int iCont = 0; iCont <= 9; iCont++)
									{ //UBound(iArrNumEjec) - 1
										ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lCredTotal;
									} 
									break;
								case 2 : 
									ID_GRA_GPH.GraphType = CORCONST.INT_PAS_DOS_DIM; 
									ID_GRA_GPH.GraphStyle = 4; 
									ID_GRA_GPH.ThisPoint = 1; 
									ID_GRA_GPH.LeftTitle = "Total  = " + StringsHelper.Format(lSumCred, "###,###,#00.00"); 
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
									for (int iCont = 0; iCont <= 9; iCont++)
									{ //UBound(iArrNumEjec) - 1
										ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lCredTotal;
									} 
									break;
								case 3 : 
									ID_GRA_GPH.GraphType = CORCONST.INT_PAS_TRES_DIM; 
									ID_GRA_GPH.GraphStyle = 4; 
									ID_GRA_GPH.ThisPoint = 1; 
									ID_GRA_GPH.LeftTitle = "Total  = " + StringsHelper.Format(lSumCred, "###,###,#00.00"); 
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
									for (int iCont = 0; iCont <= 9; iCont++)
									{ //UBound(iArrNumEjec) - 1
										ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lCredTotal;
									} 
									break;
							}
							
							//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
							ID_GRA_GPH.DrawMode = CORCONST.INT_MODO_RED;
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			private void  Opciones_Division( int indice)
			{
					
					
					switch(indice)
					{
						case 0 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_DOS_DIM; 
							ID_GRA_GPH.GraphStyle = 0; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Número de Empresas"; 
							ID_GRA_GPH.BottomTitle = "Empresas"; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							} 
							break;
						case 1 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_TRES_DIM; 
							ID_GRA_GPH.GraphStyle = 0; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Número de Empresas"; 
							ID_GRA_GPH.BottomTitle = "Empresas"; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							} 
							break;
						case 2 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_DOS_DIM; 
							ID_GRA_GPH.GraphStyle = 4; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Total  = " + lSumEmp.ToString() + " empresas"; 
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							} 
							break;
						case 3 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_TRES_DIM; 
							ID_GRA_GPH.GraphStyle = 4; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Total  = " + lSumEmp.ToString() + " empresas"; 
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							} 
							break;
					}
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORCONST.INT_MODO_RED;
					
			}
			
			private void  Opciones_Ejecutivos( int indice)
			{
					
					double dEjecutivos = 0;
					
					switch(indice)
					{
						case 0 :  
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_DOS_DIM; 
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_DOS_DIM; 
							ID_GRA_GPH.GraphStyle = 0; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Número de Ejecutivos"; 
							ID_GRA_GPH.BottomTitle = "Empresas"; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalEjec;
							} 
							 
							break;
						case 1 :  
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_DOS_DIM; 
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_TRES_DIM; 
							ID_GRA_GPH.GraphStyle = 0; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Número de Ejecutivos"; 
							ID_GRA_GPH.BottomTitle = "Empresas"; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalEjec;
							} 
							 
							break;
						case 2 :  
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_DOS_DIM; 
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_DOS_DIM; 
							ID_GRA_GPH.GraphStyle = 4; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Total  = " + lSumEjec.ToString() + " ejecutivos"; 
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalEjec;
							} 
							 
							break;
						case 3 :  
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_TRES_DIM; 
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_TRES_DIM; 
							ID_GRA_GPH.GraphStyle = 4; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Total  = " + lSumEjec.ToString() + " ejecutivos"; 
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalEjec;
							} 
							 
							break;
					}
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORCONST.INT_MODO_RED;
					
			}
			
			private void  Opciones_Sector( int indice)
			{
					
					double dSectores = 0;
					
					switch(indice)
					{
						case 0 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_DOS_DIM; 
							ID_GRA_GPH.GraphStyle = 0; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Empresas por Sector"; 
							ID_GRA_GPH.BottomTitle = "Empresas"; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalSect;
							} 
							break;
						case 1 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_TRES_DIM; 
							ID_GRA_GPH.GraphStyle = 0; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Empresas por Sector"; 
							ID_GRA_GPH.BottomTitle = "Empresas"; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalSect;
							} 
							break;
						case 2 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_DOS_DIM; 
							ID_GRA_GPH.GraphStyle = 4; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Total  = " + lSumSect.ToString() + " empresas"; 
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalSect;
							} 
							break;
						case 3 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_TRES_DIM; 
							ID_GRA_GPH.GraphStyle = 4; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Total  = " + lSumSect.ToString() + " empresas"; 
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].iTotalSect;
							} 
							break;
					}
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORCONST.INT_MODO_RED;
					
			}
			
			private void  ID_GRA_MEMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					if (lContador != CORVB.NULL_INTEGER)
					{
						switch(ID_CEE_EMP_COB.SelectedIndex)
						{
							case 0 : 
								 
								ID_GRA_GPH.GraphTitle = "Empresa - Ejecutivos"; 
								ID_GRA_GPH.LeftTitle = "Número de Ejecutivos"; 
								 
								Grafica_Param_Mas(iArrNumEjec, iNumRegsEMPEJE, "iTotalEjec"); 
								 
								if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
								{
									ID_GRA_GPH.LeftTitle = "Total  = " + lSumEjec.ToString() + " ejecutivos";
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
								} else
								{
									ID_GRA_GPH.LeftTitle = "Número de Ejecutivos";
									ID_GRA_GPH.BottomTitle = "Empresas";
								} 
								 
								//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded. 
								ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw; 
								 
								break;
							case 1 : 
								Grafica_Param_Mas(iArrNumEjec, lNumRegsCred, "lCredTotal"); 
								 
								if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
								{
									ID_GRA_GPH.LeftTitle = "Total  = " + StringsHelper.Format(lSumCred, "###,###,###,#00.00");
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
								} else
								{
									ID_GRA_GPH.LeftTitle = "Crédito total ";
									ID_GRA_GPH.BottomTitle = "Empresas";
								} 
								 
								//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded. 
								ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw; 
								 
								break;
						}
					}
					
					
					
			}
			
			
			private void  Grafica_Param_Mas( CORVAR.DatEmpresa[] iArrDatos,  int lTotRegLeidos,  string pszCampo)
			{
					
					int iCont = 0;
					
					ID_GRA_GPH.NumPoints = 10;
					
					ID_GRA_GPH.ThisPoint = 1;
					for (iCont = lContador; iCont <= lContador + 9; iCont++)
					{
						if (iCont >= lTotRegLeidos)
						{
							ID_GRA_GPH.GraphData = 0;
						} else
						{
							if (pszCampo == "iTotalEjec")
							{
								ID_GRA_GPH.GraphData = iArrDatos[iCont].iTotalEjec;
							} else
							{
								ID_GRA_GPH.GraphData = iArrDatos[iCont].lCredTotal;
							}
						}
						
					}
					
					ID_GRA_GPH.ThisPoint = 1;
					for (iCont = lContador; iCont <= lContador + 9; iCont++)
					{
						if (iCont >= lTotRegLeidos)
						{
							ID_GRA_GPH.LegendText = CORVB.NULL_STRING;
						} else
						{
							ID_GRA_GPH.LegendText = StringsHelper.Format(iCont, "000") + "  " + Strings.Mid(iArrDatos[iCont].pszNomEmpresa.ToUpper(), 1, 25);
						}
					}
					
					if (iCont >= lTotRegLeidos)
					{
					} else
					{
						lContador += 10;
					}
					
			}
			private void  CORGREMP_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}