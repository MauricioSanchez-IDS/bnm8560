using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORGRANT
		: System.Windows.Forms.Form
		{
		
			private void  CORGRANT_Activated( Object eventSender,  EventArgs eventArgs)
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
			//**       Descripción: Grafica de Antiguedad de las Empresas               **
			//**                    agrupades por grupos                                **
			//**                                                                        **
			//**       Responsable:                                                     **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			int lTotEmp = 0;
			int lSumCred = 0;
			int iErr = 0;
			//AIS-1178 NGONZALEZ
			CORVAR.DatEmpresa[] iArrNumEjec;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
			int lEmpCve = 0;
			int iIntervalo = 0;
			
			//Variables para controlar la Maximización y Minimización de la Gráfica
			int bMaximizada = 0;
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
			
			const int INT_FONTSIZE_TIT = 150;
			const int INT_FONTSIZE_OTROS = 100;
			
			const int INT_MAX_GRUPOS = 999;
			const int INT_MAX_EMPRESAS = 999;
			
			int iGruposRestantes = 0;
			int iEmpresasRestantes = 0;
			
			int hConexion = 0;
			int hGrupo = 0;
			int hEjeEmpresa = 0;
			
			private void  Antiguedad_Empresa()
			{
					
					int hBufEjecEmp = 0;
					int iTempErr = 0;
					int iNumRegs = 0;
					string pszMesInicio = String.Empty;
					int lNumEmp = 0;
					int iCont = 0;
					int iMes = 0; //**
					int iMesFinal = 0;
					int iMesInicio = 0;
					int iPeriodo = 0;
					int iAñoFinal = 0;
					int iAñoInicio = 0;
					int iDifAño = 0;
					int iAño = 0;
					int iMeses = 0;
					int lSumEmp = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					if (ID_CRE_IRA_CHK.Value)
					{
						CORIREMP.DefInstance.Tag = "CORGRANT";
						//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
						CORIREMP.DefInstance.ShowDialog();
						lEmpCve = CORVAR.lgblTempNumEmp;
						this.Refresh();
					} else
					{
						
						//EISSA 03-10-2001. Cambio para obtener la longitud del número de empresa
						//Obtiene la Empresa a analizar
						lEmpCve = Convert.ToInt32(Conversion.Val(ID_GRA_EMP_COB.Text.Substring(0, Math.Min(ID_GRA_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
						if (lEmpCve < CORVB.NULL_INTEGER || ID_GRA_EMP_COB.Items.Count == CORVB.NULL_INTEGER)
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
							ID_GRA_GRP_PNL.Enabled = false;
							return;
						}
					}
					
					if (lEmpCve > CORVB.NULL_INTEGER)
					{
						//Inicializa variables
						lSumEmp = CORVB.NULL_INTEGER;
						iCont = CORVB.NULL_INTEGER;
						
						//Calcula los rangos de meses o años
						Calcula_Intervalo();
						
						iMes = Convert.ToInt32(Conversion.Val(ID_GRA_AIN_MEB.CtlText + StringsHelper.Format(ID_GRA_MIN_MEB.CtlText, "00")));
						iAño = Convert.ToInt32(Conversion.Val(ID_GRA_AIN_MEB.CtlText));
						iIntervalo++;
						
						//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
						iArrNumEjec = new CORVAR.DatEmpresa[iIntervalo + 1];
						
						//Verifica si se desea graficar por meses o por año
						if (iIntervalo <= 12)
						{
							
							lTotEmp = CORVB.NULL_INTEGER;
							
							while (iPeriodo < iIntervalo)
								{
								
									//***** INICIO CODIGO ANTERIOR FSWBMX *****
									//        pszgblsql = "grafiant2 " + Format$(iMes) + "," + Format$(lEmpCve) + "," + Format$(igblBanco)
									//***** FIN DE CODIGO ANTERIOR FSWBMX *****
									//***** INICIO CODIGO NUEVO FSWBMX *****
									CORVAR.pszgblsql = "grafiant2 " + iMes.ToString() + "," + lEmpCve.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
									//***** FIN DE CODIGO NUEVO FSWBMX *****
									
									if (CORPROC2.Obtiene_Registros() != 0)
									{
										if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
										{
											lNumEmp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
											//Obtiene el total de empresas
											iArrNumEjec[iCont].lNumEmpresa = lNumEmp;
											lTotEmp += lNumEmp;
											iArrNumEjec[iCont].pszMesInicio = Cambia_FormatoMes(iMes);
											if (Conversion.Val(Strings.Mid(iMes.ToString(), 5)) == 12)
											{
												iMes = Convert.ToInt32(Conversion.Val((iAño + 1).ToString() + "00"));
											}
											iCont++;
										}
										iMes++;
										iPeriodo++;
									} else
									{
										CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
										this.Cursor = Cursors.Default;
										return;
									}
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								}
							if (lTotEmp != 0)
							{
								//Formatea y llena gráfica
								ID_GRA_GPH.GraphTitle = "Antigüedad por Empresa (En Meses)";
								if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
								{
									ID_GRA_GPH.LeftTitle = "Total  = " + lTotEmp.ToString() + " tarjetas";
									ID_GRA_GPH.BottomTitle = ID_GRA_EMP_COB.Text.Trim();
								} else
								{
									ID_GRA_GPH.LeftTitle = "Número de tarjetas";
									ID_GRA_GPH.BottomTitle = "Meses   " + ID_GRA_EMP_COB.Text.Trim();
								}
								ID_GRA_GPH.NumPoints = (short) iArrNumEjec.GetUpperBound(0);
								ID_GRA_GPH.ThisPoint = 1;
								for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
								{
									ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
								}
								ID_GRA_GPH.ThisPoint = 1;
								for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
								{
									ID_GRA_GPH.LegendText = (iCont + 1).ToString() + " - " + iArrNumEjec[iCont].pszMesInicio;
								}
								//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
								ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw;
								ID_GRA_GRP_PNL.Enabled = true;
							} else
							{
								this.Cursor = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
								ID_GRA_GRP_PNL.Enabled = false;
							}
						} else
						{
							iCont = CORVB.NULL_INTEGER;
							iMeses = Convert.ToInt32(Conversion.Val(ID_GRA_MIN_MEB.CtlText));
							//Convierte intervalo a diferencia de años
							iIntervalo = Convert.ToInt32(Conversion.Val(ID_GRA_AFI_MEB.CtlText) - Conversion.Val(ID_GRA_AIN_MEB.CtlText) + 1);
							//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
							iArrNumEjec = new CORVAR.DatEmpresa[iIntervalo + 1];
							while (iCont < iIntervalo)
								{
								
									//***** INICIO CODIGO ANTERIOR FSWBMX *****
									//        pszgblsql = "grafiant2 " + Format$(iMes) + "," + Format$(lEmpCve) + "," + Format$(igblBanco)
									//***** FIN DE CODIGO ANTERIOR FSWBMX *****
									//***** INICIO CODIGO NUEVO FSWBMX *****
									CORVAR.pszgblsql = "grafiant2 " + iMes.ToString() + "," + lEmpCve.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
									//***** FIN DE CODIGO NUEVO FSWBMX *****
									if (CORPROC2.Obtiene_Registros() != 0)
									{
										if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
										{
											lNumEmp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
											lSumEmp += lNumEmp;
											//Verifica si es año final
											if (iAño == Conversion.Val(ID_GRA_AFI_MEB.CtlText))
											{
												if (iMeses == Conversion.Val(ID_GRA_MFI_MEB.CtlText))
												{
													iArrNumEjec[iCont].lNumEmpresa = lSumEmp;
													lTotEmp += lSumEmp;
													iArrNumEjec[iCont].pszMesInicio = iAño.ToString();
													iCont++;
												}
											} else
											{
												if (iMeses == 12)
												{
													iArrNumEjec[iCont].lNumEmpresa = lSumEmp;
													iArrNumEjec[iCont].pszMesInicio = iAño.ToString();
													lTotEmp += lSumEmp;
													iMeses = CORVB.NULL_INTEGER;
													lSumEmp = CORVB.NULL_INTEGER;
													iAño++;
													iCont++;
													iMes = Convert.ToInt32(Conversion.Val(iAño.ToString() + "00") + 1);
												}
											}
										}
										iMeses++;
										iMes++;
									} else
									{
										CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
										this.Cursor = Cursors.Default;
										return;
									}
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								}
							
							if (lTotEmp != 0)
							{
								ID_GRA_GPH.GraphTitle = "Antigüedad por Empresa (En años)";
								if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
								{
									ID_GRA_GPH.LeftTitle = "Total  = " + lTotEmp.ToString() + " tarjetas";
									ID_GRA_GPH.BottomTitle = ID_GRA_EMP_COB.Text.Trim();
								} else
								{
									ID_GRA_GPH.LeftTitle = "Número de tarjetas";
									ID_GRA_GPH.BottomTitle = "Años   " + ID_GRA_EMP_COB.Text.Trim();
								}
								ID_GRA_GPH.NumPoints = (short) iArrNumEjec.GetUpperBound(0);
								ID_GRA_GPH.ThisPoint = 1;
								for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
								{
									ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
								}
								ID_GRA_GPH.ThisPoint = 1;
								for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
								{
									ID_GRA_GPH.LegendText = (iCont + 1).ToString() + " - " + iArrNumEjec[iCont].pszMesInicio;
								}
								//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
								ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw;
								ID_GRA_GRP_PNL.Enabled = true;
							} else
							{
								this.Cursor = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
								ID_GRA_GRP_PNL.Enabled = false;
							}
						}
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  Antiguedad_Producto()
			{
					
					int hBufEjecEmp = 0;
					int iTempErr = 0;
					int iNumRegs = 0;
					string pszMesInicio = String.Empty;
					int lNumEmp = 0;
					int iMesFinal = 0;
					int iMesInicio = 0;
					int iPeriodo = 0;
					int iAñoFinal = 0;
					int iAñoInicio = 0;
					int iDifAño = 0;
					int iMeses = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					int lSumEmp = CORVB.NULL_INTEGER;
					int iCont = CORVB.NULL_INTEGER;
					
					Calcula_Intervalo();
					
					int iMes = Convert.ToInt32(Conversion.Val(ID_GRA_AIN_MEB.CtlText + StringsHelper.Format(ID_GRA_MIN_MEB.CtlText, "00")));
					int iAño = Convert.ToInt32(Conversion.Val(ID_GRA_AIN_MEB.CtlText));
					
					if (iIntervalo < CORVB.NULL_INTEGER)
					{
						iIntervalo += 12;
					}
					iIntervalo++;
					
					//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
					iArrNumEjec = new CORVAR.DatEmpresa[iIntervalo + 1];
					if (iIntervalo <= 12)
					{
						while (iPeriodo < iIntervalo)
							{
							
								
								//ros      igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
								//***** INICIO CODIGO ANTERIOR FSWBMX *****
								//      pszgblsql = "grafiant " + Format$(iMes) + ", " + Format$(igblBanco)
								//***** FIN DE CODIGO ANTERIOR FSWBMX *****
								//***** INICIO CODIGO NUEVO FSWBMX *****
								CORVAR.pszgblsql = "grafiant " + iMes.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
								//***** FIN DE CODIGO ANTERIOR FSWBMX *****
								
								if (CORPROC2.Obtiene_Registros() != 0)
								{
									
									if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
									{
										lNumEmp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
										lTotEmp += lNumEmp;
										iArrNumEjec[iCont].lNumEmpresa = lNumEmp;
										iArrNumEjec[iCont].pszMesInicio = Cambia_FormatoMes(iMes);
										if (Conversion.Val(Strings.Mid(iMes.ToString(), 5)) == 12)
										{
											iMes = Convert.ToInt32(Conversion.Val((iAño + 1).ToString() + "00"));
										}
										iCont++;
									}
									iMes++;
									iPeriodo++;
								} else
								{
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
									this.Cursor = Cursors.Default;
									return;
								}
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							}
						
						ID_GRA_GPH.GraphTitle = "Antigüedad por Producto (En meses)";
						if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
						{
							ID_GRA_GPH.LeftTitle = "Total  = " + lTotEmp.ToString() + " tarjetas";
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
						} else
						{
							ID_GRA_GPH.LeftTitle = "Número de tarjetas";
							ID_GRA_GPH.BottomTitle = "Meses";
						}
						ID_GRA_GPH.NumPoints = (short) iArrNumEjec.GetUpperBound(0);
						ID_GRA_GPH.ThisPoint = 1;
						for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
						{
							ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
						}
						ID_GRA_GPH.ThisPoint = 1;
						for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
						{
							ID_GRA_GPH.LegendText = (iCont + 1).ToString() + " - " + iArrNumEjec[iCont].pszMesInicio;
						}
						//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
						ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw;
						ID_GRA_GRP_PNL.Enabled = true;
					} else
					{
						iCont = CORVB.NULL_INTEGER;
						iMeses = Convert.ToInt32(Conversion.Val(ID_GRA_MIN_MEB.CtlText));
						iIntervalo = Convert.ToInt32(Conversion.Val(ID_GRA_AFI_MEB.CtlText) - Conversion.Val(ID_GRA_AIN_MEB.CtlText) + 1);
						//UPGRADE_WARNING: (1042) Array iArrNumEjec may need to have individual elements initialized.
						iArrNumEjec = new CORVAR.DatEmpresa[iIntervalo + 1];
						while (iCont < iIntervalo)
							{
							
								//***** INICIO CODIGO ANTERIOR FSWBMX *****
								//      pszgblsql = "grafiant " + Format$(iMes) + ", " + Format$(igblBanco)
								//***** FIN DE CODIGO ANTERIOR FSWBMX *****
								//***** INICIO CODIGO NUEVO FSWBMX *****
								CORVAR.pszgblsql = "grafiant " + iMes.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
								//***** FIN DE CODIGO NUEVO FSWBMX *****
								if (CORPROC2.Obtiene_Registros() != 0)
								{
									if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
									{
										lNumEmp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
										lSumEmp += lNumEmp;
										if (iAño == Conversion.Val(ID_GRA_AFI_MEB.CtlText))
										{
											if (iMeses == Conversion.Val(ID_GRA_MFI_MEB.CtlText))
											{
												iArrNumEjec[iCont].lNumEmpresa = lSumEmp;
												lTotEmp += lSumEmp;
												iArrNumEjec[iCont].pszMesInicio = iAño.ToString();
												iCont++;
											}
										} else
										{
											if (iMeses == 12)
											{
												iArrNumEjec[iCont].lNumEmpresa = lSumEmp;
												iArrNumEjec[iCont].pszMesInicio = iAño.ToString();
												iMeses = CORVB.NULL_INTEGER;
												lTotEmp += lSumEmp;
												lSumEmp = CORVB.NULL_INTEGER;
												iAño++;
												iCont++;
												iMes = Convert.ToInt32(Conversion.Val(iAño.ToString() + "00") - 1);
											}
										}
									}
									iMeses++;
									iMes++;
								} else
								{
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								}
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							}
						
						if (lTotEmp != 0)
						{
							ID_GRA_GPH.GraphTitle = "Antigüedad por Producto (En Años)";
							if (ID_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
							{
								ID_GRA_GPH.LeftTitle = "Total  = " + lTotEmp.ToString() + " tarjetas";
								ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
							} else
							{
								ID_GRA_GPH.LeftTitle = "Número de Tarjetas";
								ID_GRA_GPH.BottomTitle = "Años";
							}
							ID_GRA_GPH.NumPoints = (short) iArrNumEjec.GetUpperBound(0);
							ID_GRA_GPH.ThisSet = 1;
							ID_GRA_GPH.ThisPoint = 1;
							for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							}
							for (iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.LegendText = (iCont + 1).ToString() + " - " + iArrNumEjec[iCont].pszMesInicio;
							}
							//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
							ID_GRA_GPH.DrawMode = GraphLib.DrawModeConstants.gphDraw;
							ID_GRA_GRP_PNL.Enabled = true;
						} else
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
							ID_GRA_GRP_PNL.Enabled = false;
						}
						
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  Calcula_Intervalo()
			{
					
					int iPeriodo = 0;
					int iDiferencia = 0;
					
					int iAñoFinal = Convert.ToInt32(Conversion.Val(ID_GRA_AFI_MEB.CtlText));
					int iAñoInicio = Convert.ToInt32(Conversion.Val(ID_GRA_AIN_MEB.CtlText));
					
					int iDifAño = iAñoFinal - iAñoInicio;
					
					int iMesInicio = Convert.ToInt32(Conversion.Val(ID_GRA_MIN_MEB.CtlText));
					int iMesFinal = Convert.ToInt32(Conversion.Val(ID_GRA_MFI_MEB.CtlText));
					
					int iDifMes = iMesFinal - iMesInicio;
					
					if (iDifAño <= CORVB.NULL_INTEGER)
					{
						iIntervalo = iDifMes;
					} else
					{
						if (iDifMes < 0)
						{
							iIntervalo = (12 * (iDifAño - 1)) + (iDifMes + 12);
						} else
						{
							iIntervalo = (12 * iDifAño) + iDifMes;
						}
					}
					
					
			}
			
			private string Cambia_FormatoMes( int iMes)
			{
					
					
					string result = String.Empty;
					int iAñoInicio = Convert.ToInt32(Conversion.Val(Strings.Mid(iMes.ToString(), 1, 4)));
					int iMesInicio = Convert.ToInt32(Conversion.Val(Strings.Mid(iMes.ToString(), 5)));
					
					switch(iMesInicio)
					{
						case 1 : 
							result = "Ene " + iAñoInicio.ToString(); 
							break;
						case 2 : 
							result = "Feb " + iAñoInicio.ToString(); 
							break;
						case 3 : 
							result = "Mar " + iAñoInicio.ToString(); 
							break;
						case 4 : 
							result = "Abr " + iAñoInicio.ToString(); 
							break;
						case 5 : 
							result = "May " + iAñoInicio.ToString(); 
							break;
						case 6 : 
							result = "Jun " + iAñoInicio.ToString(); 
							break;
						case 7 : 
							result = "Jul " + iAñoInicio.ToString(); 
							break;
						case 8 : 
							result = "Ago " + iAñoInicio.ToString(); 
							break;
						case 9 : 
							result = "Sep " + iAñoInicio.ToString(); 
							break;
						case 10 : 
							result = "Oct " + iAñoInicio.ToString(); 
							break;
						case 11 : 
							result = "Nov " + iAñoInicio.ToString(); 
							break;
						case 12 : 
							result = "Dic " + iAñoInicio.ToString(); 
							break;
					}
					
					return result;
			}
			
			private void  Carga_Combo()
			{
					
					//Carga combo de Tipo de Gráfica
					ID_GRA_TIP_COB.Items.Add("Antigüedad por Producto");
					ID_GRA_TIP_COB.Items.Add("Antigüedad por Empresa");
					ID_GRA_TIP_COB.SelectedIndex = CORVB.NULL_INTEGER;
					
			}
			
			private void  Carga_Empresas()
			{
					
					int iError = 0;
					string pszEmpDesc = String.Empty;
					int iValor = 0;
					int iCorCve = 0;
					int iCont = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_GRA_EMP_COB.Items.Clear();
					
					this.Cursor = Cursors.WaitCursor;
					//Obtiene los Campos de la tabla de Ejecutivos Banamex
					//ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_banco =" + Str(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo =" + Conversion.Str(CORVAR.igblPref) + " and gpo_banco =" + Conversion.Str(CORVAR.igblBanco);
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							lEmpCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							//EISSA 03-10-2001. Cambio para formatear el número de empresa.
							ID_GRA_EMP_COB.Items.Add(StringsHelper.Format(lEmpCve, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
							iCont++;
						};
						if (ID_GRA_EMP_COB.Items.Count != 0)
						{
							ID_GRA_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
						}
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					
					this.Cursor = Cursors.Default;
					
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY(1250);
					
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
					
					Carga_Combo();
					Carga_Empresas();
					
					//Inicializa las variables de Fechas
					ID_GRA_AFI_MEB.CtlText = DateTime.Now.Year.ToString();
					ID_GRA_AIN_MEB.CtlText = DateTime.Now.Year.ToString();
					ID_GRA_MFI_MEB.CtlText = DateTime.Now.Month.ToString();
					ID_GRA_MIN_MEB.CtlText = DateTime.Now.Month.ToString();
					
					this.Cursor = Cursors.Default;
					
			}
			
			
			
			private void  ID_CEE_GRA_GPB_ClickEvent( Object eventSender,  AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
			{
					int Index = Array.IndexOf(ID_CEE_GRA_GPB, eventSender);
					
					int iCont = 0;
					double dCredito = 0;
					
					Opciones_Empresa(Index);
					
			}
			
			private void  ID_GRA_AFI_MEB_Change( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_GRA_GRP_PNL.Enabled = false;
					
			}
			
			
			private void  ID_GRA_AFI_MEB_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
					
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (ID_GRA_AIN_MEB_InvalidData) seems to be dead code
			//private void  ID_GRA_AIN_MEB_InvalidData( int NextWnd)
			//{
					//
					//ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					////UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					//ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					//ID_GRA_GRP_PNL.Enabled = false;
					//
			//}
			
			
			private void  ID_GRA_AIN_MEB_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
					
			}
			
			private void  ID_GRA_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					this.Close();
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_GRA_EMP_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_GRA_GRP_PNL.Enabled = false;
					
					this.Cursor = Cursors.Default;
					
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
						ID_GRA_CAN_PB.Visible = true;
						ID_GRA_IMP_PB.Visible = true;
						ID_GRA_OK_PB.Visible = true;
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
						ID_GRA_OK_PB.Visible = false;
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
			
			private void  ID_GRA_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_PRINT;
					
					this.Cursor = Cursors.Default;
					
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (ID_GRA_MFI_MEB_InvalidData) seems to be dead code
			//private void  ID_GRA_MFI_MEB_InvalidData( int NextWnd)
			//{
					//
					//ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					////UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					//ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					//ID_GRA_GRP_PNL.Enabled = false;
					//
			//}
			
			private void  ID_GRA_MFI_MEB_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
					
			}
			
			private void  ID_GRA_MIN_MEB_Change( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_GRA_GRP_PNL.Enabled = false;
					
			}
			
			private void  ID_GRA_MIN_MEB_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
					
			}
			
			private void  ID_GRA_OK_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_CEE_GRA_GPB[0].Enabled = true;
					ID_CEE_GRA_GPB[1].Enabled = true;
					ID_CEE_GRA_GPB[2].Enabled = true;
					ID_CEE_GRA_GPB[3].Enabled = true;
					
					int iAñoFinal = Convert.ToInt32(Conversion.Val(ID_GRA_AFI_MEB.CtlText));
					int iAñoInicio = Convert.ToInt32(Conversion.Val(ID_GRA_AIN_MEB.CtlText));
					int iMesInicio = Convert.ToInt32(Conversion.Val(ID_GRA_MIN_MEB.CtlText));
					int iMesFinal = Convert.ToInt32(Conversion.Val(ID_GRA_MFI_MEB.CtlText));
					
					int iDifAño = iAñoFinal - iAñoInicio;
					int iDifMes = iMesFinal - iMesInicio;
					
					lTotEmp = CORVB.NULL_INTEGER;
					
					if (iDifAño < CORVB.NULL_INTEGER)
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("El año de inicio es mayor que el año final", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						return;
					} else if (iDifAño == CORVB.NULL_INTEGER) { 
						if (iDifMes < CORVB.NULL_INTEGER)
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("El mes de inicio es mayor que el mes final", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
							return;
						} else if (iDifMes == CORVB.NULL_INTEGER) { 
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("El periodo de inicio es igual al periodo final", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
							return;
						}
					}
					
					switch(ID_GRA_TIP_COB.SelectedIndex)
					{
						case 0 :  
							Antiguedad_Producto(); 
							break;
						case 1 :  
							Antiguedad_Empresa(); 
							break;
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_GRA_TIP_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					int hEjeEmp = 0;
					int iError = 0;
					int iCorCve = 0;
					int iValor = 0;
					string pszCorDesc = String.Empty;
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_GRA_GRP_PNL.Enabled = false;
					
					if (ID_GRA_TIP_COB.SelectedIndex != CORVB.NULL_INTEGER)
					{
						ID_GRA_GPO_TXT[2].Visible = true;
						ID_CRE_IRA_CHK.Visible = true;
						ID_GRA_EMP_COB.Visible = true;
					} else
					{
						ID_GRA_GPO_TXT[2].Visible = false;
						ID_CRE_IRA_CHK.Visible = false;
						ID_CRE_IRA_CHK.Value = false;
						ID_GRA_EMP_COB.Visible = false;
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  Opciones_Empresa( int iIndex)
			{
					
					
					switch(iIndex)
					{
						case 0 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_DOS_DIM; 
							ID_GRA_GPH.GraphStyle = 0; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Número de Tarjetas"; 
							Calcula_Intervalo(); 
							if (iIntervalo <= 12)
							{
								if (ID_GRA_TIP_COB.SelectedIndex == 0)
								{
									ID_GRA_GPH.BottomTitle = "Meses";
								} else
								{
									ID_GRA_GPH.BottomTitle = "Meses   " + ID_GRA_EMP_COB.Text.Trim();
								}
							} else
							{
								ID_GRA_GPH.BottomTitle = "Años" + ID_GRA_EMP_COB.Text.Trim();
							} 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							} 
							break;
						case 1 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_BAR_TRES_DIM; 
							ID_GRA_GPH.GraphStyle = 0; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Número de Tarjetas"; 
							Calcula_Intervalo(); 
							if (iIntervalo <= 12)
							{
								if (ID_GRA_TIP_COB.SelectedIndex == 0)
								{
									ID_GRA_GPH.BottomTitle = "Meses";
								} else
								{
									ID_GRA_GPH.BottomTitle = "Meses   " + ID_GRA_EMP_COB.Text.Trim();
								}
							} else
							{
								ID_GRA_GPH.BottomTitle = "Años" + ID_GRA_EMP_COB.Text.Trim();
							} 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							} 
							break;
						case 2 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_DOS_DIM; 
							ID_GRA_GPH.GraphStyle = 4; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Total = " + lTotEmp.ToString() + " tarjetas"; 
							if (ID_GRA_TIP_COB.SelectedIndex == 0)
							{
								ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
							} else
							{
								ID_GRA_GPH.BottomTitle = ID_GRA_EMP_COB.Text.Trim();
							} 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							} 
							break;
						case 3 : 
							ID_GRA_GPH.GraphType = CORCONST.INT_PAS_TRES_DIM; 
							ID_GRA_GPH.GraphStyle = 4; 
							ID_GRA_GPH.ThisPoint = 1; 
							ID_GRA_GPH.LeftTitle = "Total = " + lTotEmp.ToString() + " tarjetas"; 
							if (ID_GRA_TIP_COB.SelectedIndex == 0)
							{
								ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
							} else
							{
								ID_GRA_GPH.BottomTitle = ID_GRA_EMP_COB.Text.Trim();
							} 
							for (int iCont = 0; iCont <= iArrNumEjec.GetUpperBound(0) - 1; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrNumEjec[iCont].lNumEmpresa;
							} 
							break;
					}
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORCONST.INT_MODO_RED;
					
			}
			private void  CORGRANT_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}