using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class CORGRREN
		: System.Windows.Forms.Form
		{
		
			private void  CORGRREN_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			int iErr = 0;
			//AIS-1178 NGONZALEZ
			CORVAR.DatRentabilidad[] iArrRentabilidad;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
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
			double mdTotalRen = 0;
			int mlTotalReg = 0;
			bool mbTermino = false;
			
			const int INT_FONTSIZE_TIT = 150;
			const int INT_FONTSIZE_OTROS = 100;
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción:                                                     **
			//**                   Identifica la grafica a diseñar                      **
			//**                                                                        **
			//**       Paso de parámetros:                                              **
			//**                                                                        **
			//**       Valor de Regreso:                                                **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 26nov98                                     **
			//**                                                                        **
			//****************************************************************************
			//
			//
			private void  Carga_Grafica()
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					//carga los datos del spread de la forma CORMNREN a la grafica
					
					//lee el spread
					if (CORCTREN.DefInstance.Tag.ToString() == "Una")
					{
						Grafica_Una_Empresa();
						cbdMas.Visible = false;
						cbdMenos.Visible = false;
					} else
					{
						Grafica_General();
						cbdMas.Visible = true;
						cbdMenos.Visible = true;
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción:                                                     **
			//**                   Proceso utilizado para graficar a todas las empresas **
			//**                   o un rango de empresas seleccionadas a un periodo    **
			//**                                                                        **
			//**       Paso de parámetros:                                              **
			//**                                                                        **
			//**       Valor de Regreso:                                                **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 26nov98                                     **
			//**                                                                        **
			//****************************************************************************
			//
			private void  Grafica_General()
			{
					
					
					int lBloque = 0;
					
					lContador = CORVB.NULL_INTEGER;
					mbTermino = false;
					
					
					//UPGRADE_WARNING: (1042) Array iArrRentabilidad may need to have individual elements initialized.
					iArrRentabilidad = new CORVAR.DatRentabilidad[CORMNREN.DefInstance.sprRepRenta.MaxRows];
					
					mlTotalReg = CORMNREN.DefInstance.sprRepRenta.MaxRows - 1;
					if (mlTotalReg <= 10)
					{
						lBloque = iArrRentabilidad.GetUpperBound(0);
						cbdMas.Enabled = false;
						cbdMenos.Enabled = false;
					} else
					{
						lBloque = 10;
						cbdMas.Enabled = true;
						cbdMenos.Enabled = true;
					}
					
					for (int lRenglon = 1; lRenglon <= CORMNREN.DefInstance.sprRepRenta.MaxRows - 1; lRenglon++)
					{
						CORMNREN.DefInstance.sprRepRenta.Row = lRenglon;
						CORMNREN.DefInstance.sprRepRenta.Col = 1;
						if (CORMNREN.DefInstance.sprRepRenta.Text != "Total" && CORMNREN.DefInstance.sprRepRenta.Text != CORVB.NULL_STRING)
						{
							iArrRentabilidad[lRenglon].lNoEmpresa = Int32.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
							CORMNREN.DefInstance.sprRepRenta.Col = 2;
							iArrRentabilidad[lRenglon].sNomEmpresa = CORMNREN.DefInstance.sprRepRenta.Text;
							CORMNREN.DefInstance.sprRepRenta.Col = 6;
							iArrRentabilidad[lRenglon].dRenTot = Double.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
						} else
						{
							if (CORMNREN.DefInstance.sprRepRenta.Text == "Total")
							{
								CORMNREN.DefInstance.sprRepRenta.Col = 6;
								mdTotalRen = Double.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
							}
						}
					}
					
					gphGraficaRen.GraphTitle = "Rentabilidad";
					gphGraficaRen.LeftTitle = "Rentabilidad";
					
					if (lBloque == 1)
					{
						gphGraficaRen.NumPoints = (short) (lBloque + 1);
					} else
					{
						gphGraficaRen.NumPoints = (short) lBloque;
					}
					
					gphGraficaRen.ThisPoint = 1;
					for (int iCont = 1; iCont <= lBloque; iCont++)
					{ //10 ' UBound(iArrRentabilidad)
						gphGraficaRen.GraphData = (float) iArrRentabilidad[iCont].dRenTot;
					}
					gphGraficaRen.ThisPoint = 1;
					for (int iCont = 1; iCont <= lBloque; iCont++)
					{ //10 'UBound(iArrRentabilidad)
						if (iArrRentabilidad[iCont].lNoEmpresa != CORVB.NULL_INTEGER)
						{
							gphGraficaRen.LegendText = iArrRentabilidad[iCont].lNoEmpresa.ToString() + " " + Strings.Mid(iArrRentabilidad[iCont].sNomEmpresa, 1, 25);
						}
					}
					
					if (gphGraficaRen.GraphType == CORCONST.INT_PAS_DOS_DIM || gphGraficaRen.GraphType == CORCONST.INT_PAS_TRES_DIM)
					{
						gphGraficaRen.LeftTitle = "Total  = " + StringsHelper.Format(mdTotalRen, "###,###,###,##0.00") + " de Rentabilidad";
						gphGraficaRen.BottomTitle = CORVB.NULL_STRING;
					} else
					{
						gphGraficaRen.LeftTitle = "Rentabilidad";
						gphGraficaRen.BottomTitle = "Empresas";
					}
					
					lContador = 10;
					
					
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method gphGraficaRen.DrawMode was not upgraded.
					gphGraficaRen.DrawMode = GraphLib.DrawModeConstants.gphDraw;
					
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (Grafica_Divide) seems to be dead code
			//private void  Grafica_Divide()
			//{
					//int lBloque = 0;
					//
					//lContador = CORVB.NULL_INTEGER;
					//mbTermino = false;
					//
					//
					////UPGRADE_WARNING: (1042) Array iArrRentabilidad may need to have individual elements initialized.
					//iArrRentabilidad = new CORVAR.DatRentabilidad[CORMNREN.DefInstance.sprRepRenta.MaxRows];
					//
					//mlTotalReg = CORMNREN.DefInstance.sprRepRenta.MaxRows - 1;
					//if (mlTotalReg <= 10)
					//{
						//lBloque = iArrRentabilidad.GetUpperBound(0);
					//} else
					//{
						//lBloque = 10;
					//}
					//
					//for (int lRenglon = 1; lRenglon <= CORMNREN.DefInstance.sprRepRenta.MaxRows - 1; lRenglon++)
					//{
						//CORMNREN.DefInstance.sprRepRenta.Row = lRenglon;
						//CORMNREN.DefInstance.sprRepRenta.Col = 1;
						//if (CORMNREN.DefInstance.sprRepRenta.Text != "Total" && CORMNREN.DefInstance.sprRepRenta.Text != CORVB.NULL_STRING)
						//{
							//iArrRentabilidad[lRenglon].lNoEmpresa = Int32.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
							//CORMNREN.DefInstance.sprRepRenta.Col = 2;
							//iArrRentabilidad[lRenglon].sNomEmpresa = CORMNREN.DefInstance.sprRepRenta.Text;
							//CORMNREN.DefInstance.sprRepRenta.Col = 6;
							//iArrRentabilidad[lRenglon].dRenTot = Double.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
						//} else
						//{
							//if (CORMNREN.DefInstance.sprRepRenta.Text == "Total")
							//{
								//CORMNREN.DefInstance.sprRepRenta.Col = 6;
								//mdTotalRen = Double.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
							//}
						//}
					//}
					//
					//gphGraficaRen.GraphTitle = "Rentabilidad";
					//gphGraficaRen.LeftTitle = "Rentabilidad";
					//
					//gphGraficaRen.YAxisStyle = GraphLib.YAxisStyleConstants.gphUserDefined; //definido por el usuario
					//gphGraficaRen.YAxisMax = Single.Parse(CORMNREN.DefInstance.lblMaxResp.Text);
					//gphGraficaRen.YAxisMin = Single.Parse(CORMNREN.DefInstance.lblMinResp.Text);
					//gphGraficaRen.YAxisTicks = Convert.ToInt16((Conversion.Val(CORMNREN.DefInstance.lblMaxResp.Text) - Conversion.Val(CORMNREN.DefInstance.lblMinResp.Text)) / 15);
					//
					//gphGraficaRen.NumPoints = 10; //UBound(iArrRentabilidad)
					//
					//gphGraficaRen.ThisPoint = 1;
					//for (int iCont = 1; iCont <= lBloque; iCont++)
					//{ //10 ' UBound(iArrRentabilidad)
						//gphGraficaRen.GraphData = (float) iArrRentabilidad[iCont].dRenTot;
					//}
					//gphGraficaRen.ThisPoint = 1;
					//for (int iCont = 1; iCont <= lBloque; iCont++)
					//{ //10 'UBound(iArrRentabilidad)
						//if (iArrRentabilidad[iCont].lNoEmpresa != CORVB.NULL_INTEGER)
						//{
							//gphGraficaRen.LegendText = iArrRentabilidad[iCont].lNoEmpresa.ToString() + " " + Strings.Mid(iArrRentabilidad[iCont].sNomEmpresa, 1, 25);
						//}
					//}
					//
					//if (gphGraficaRen.GraphType == CORCONST.INT_PAS_DOS_DIM || gphGraficaRen.GraphType == CORCONST.INT_PAS_TRES_DIM)
					//{
						//gphGraficaRen.LeftTitle = "Total  = " + StringsHelper.Format(mdTotalRen, "###,###,###,##0.00") + " de Rentabilidad";
						//gphGraficaRen.BottomTitle = CORVB.NULL_STRING;
					//} else
					//{
						//gphGraficaRen.LeftTitle = "Rentabilidad";
						//gphGraficaRen.BottomTitle = "Empresas";
					//}
					//
					//lContador = 10;
					//
					////UPGRADE_ISSUE: (2069) VBControlExtender method gphGraficaRen.DrawMode was not upgraded.
					//gphGraficaRen.DrawMode = GraphLib.DrawModeConstants.gphDraw;
					//
					//
			//}
			
			private void  Grafica_Param_Menos( CORVAR.DatRentabilidad[] iArrDatos,  int lTotReg)
			{
					
					gphGraficaRen.NumPoints = 10;
					
					
					lContador -= 20;
					
					if (lContador <= CORVB.NULL_INTEGER)
					{
						lContador = 1;
						cbdMenos.Enabled = false;
					} else
					{
						if (lContador != 1)
						{
							lContador++;
						} else
						{
							cbdMenos.Enabled = false;
						}
					}
					
					cbdMas.Enabled = true;
					//  cbdMenos.Enabled = False
					mbTermino = false;
					
					
					gphGraficaRen.ThisPoint = 1;
					for (int iCont = lContador; iCont <= lContador + 9; iCont++)
					{
						if (iCont >= lTotReg)
						{
							gphGraficaRen.GraphData = CORVB.NULL_INTEGER;
							gphGraficaRen.LegendText = CORVB.NULL_STRING;
							cbdMas.Enabled = false;
						} else
						{
							if (iArrDatos[iCont].lNoEmpresa != CORVB.NULL_INTEGER)
							{
								gphGraficaRen.GraphData = (float) iArrDatos[iCont].dRenTot;
							} else
							{
								gphGraficaRen.GraphData = CORVB.NULL_INTEGER;
								mbTermino = true;
							}
						}
					}
					
					gphGraficaRen.ThisPoint = 1;
					for (int iCont = lContador; iCont <= lContador + 9; iCont++)
					{
						if (iCont >= lTotReg)
						{
							gphGraficaRen.LegendText = CORVB.NULL_STRING;
						} else
						{
							if (iArrDatos[iCont].lNoEmpresa != CORVB.NULL_INTEGER)
							{
								//EISSA 03-10-2001. Cambios para el formateo del número de empresa.
								gphGraficaRen.LegendText = StringsHelper.Format(iArrDatos[iCont].lNoEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "  " + Strings.Mid(iArrDatos[iCont].sNomEmpresa.ToUpper(), 1, 25);
							} else
							{
								gphGraficaRen.LegendText = CORVB.NULL_STRING;
								mbTermino = true;
							}
						}
					}
					
					if (! mbTermino)
					{
						//ros    If iCont >= lTotReg Then
						//ros     MsgBox " "
						//ros    Else
						//ros      lContador = lContador + 9
						//ros    End If
						lContador += 9;
					} else
					{
						lContador += 9;
						cbdMas.Enabled = false;
					}
					
					
			}
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción:                                                     **
			//**                   grafica los datos de una empresa con mas de un periodo **
			//**                                                                        **
			//**       Paso de parámetros:                                              **
			//**                                                                        **
			//**       Valor de Regreso:                                                **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 26nov98                                     **
			//**                                                                        **
			//****************************************************************************
			//
			private void  Grafica_Una_Empresa()
			{
					int iColumna = 0;
					
					
					//redimensiona el arreglo
					//  If CORMNREN!sprRepRenta.MaxRows < 9 Then
					//    ReDim iArrRentabilidad(9)
					//  Else
					//UPGRADE_WARNING: (1042) Array iArrRentabilidad may need to have individual elements initialized.
					iArrRentabilidad = new CORVAR.DatRentabilidad[CORMNREN.DefInstance.sprRepRenta.MaxRows];
					//  End If
					
					for (int lRenglon = 1; lRenglon <= CORMNREN.DefInstance.sprRepRenta.MaxRows; lRenglon++)
					{ //- 1
						CORMNREN.DefInstance.sprRepRenta.Row = lRenglon;
						CORMNREN.DefInstance.sprRepRenta.Col = 1;
						iColumna = 1;
						if (CORMNREN.DefInstance.sprRepRenta.Text != "Total" && CORMNREN.DefInstance.sprRepRenta.Text != CORVB.NULL_STRING)
						{
							iArrRentabilidad[lRenglon].lNoEmpresa = Int32.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
							CORMNREN.DefInstance.sprRepRenta.Col = 6;
							iColumna = 6;
							iArrRentabilidad[lRenglon].dRenTot = Double.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
							CORMNREN.DefInstance.sprRepRenta.Col = 7;
							iColumna = 7;
							iArrRentabilidad[lRenglon].smes = CORMNREN.DefInstance.sprRepRenta.Text.Trim();
						} else
						{
							if (CORMNREN.DefInstance.sprRepRenta.Text == "Total")
							{
								CORMNREN.DefInstance.sprRepRenta.Col = 6;
								mdTotalRen = Double.Parse(CORMNREN.DefInstance.sprRepRenta.Text);
							}
						}
					}
					
					
					gphGraficaRen.GraphTitle = "Rentabilidad";
					gphGraficaRen.LeftTitle = "Rentabilidad";
					
					gphGraficaRen.NumPoints = (short) iArrRentabilidad.GetUpperBound(0);
					
					gphGraficaRen.ThisPoint = 1;
					for (int iCont = 1; iCont <= iArrRentabilidad.GetUpperBound(0); iCont++)
					{
						gphGraficaRen.GraphData = (float) iArrRentabilidad[iCont].dRenTot;
					}
					gphGraficaRen.ThisPoint = 1;
					for (int iCont = 1; iCont <= iArrRentabilidad.GetUpperBound(0); iCont++)
					{
						if (iArrRentabilidad[iCont].lNoEmpresa != CORVB.NULL_INTEGER)
						{
							gphGraficaRen.LegendText = iArrRentabilidad[iCont].smes;
						}
					}
					
					if (gphGraficaRen.GraphType == CORCONST.INT_PAS_DOS_DIM || gphGraficaRen.GraphType == CORCONST.INT_PAS_TRES_DIM)
					{
						//    gphGraficaRen.LeftTitle = "Total  = " + Format$(lSumEjec) + " ejecutivos"
						//    gphGraficaRen.BottomTitle = NULL_STRING
					} else
					{
						gphGraficaRen.LeftTitle = "Rentabilidad";
						gphGraficaRen.BottomTitle = "Meses";
					}
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method gphGraficaRen.DrawMode was not upgraded.
					gphGraficaRen.DrawMode = GraphLib.DrawModeConstants.gphDraw;
					
			}
			
			
			
			private void  cbdMas_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					if (lContador != CORVB.NULL_INTEGER)
					{
						
						gphGraficaRen.GraphTitle = "Rentabilidad";
						gphGraficaRen.LeftTitle = "Rentabilidad";
						
						Grafica_Param_Mas(iArrRentabilidad, mlTotalReg);
						
						if (gphGraficaRen.GraphType == CORCONST.INT_PAS_DOS_DIM || gphGraficaRen.GraphType == CORCONST.INT_PAS_TRES_DIM)
						{
							gphGraficaRen.LeftTitle = "Total  = " + StringsHelper.Format(mdTotalRen, "###,###,###,##0.00") + " de Rentabilidad";
							gphGraficaRen.BottomTitle = CORVB.NULL_STRING;
						} else
						{
							gphGraficaRen.LeftTitle = "Rentabilidad";
							gphGraficaRen.BottomTitle = CORVB.NULL_STRING;
						}
						
						//UPGRADE_ISSUE: (2069) VBControlExtender method gphGraficaRen.DrawMode was not upgraded.
						gphGraficaRen.DrawMode = GraphLib.DrawModeConstants.gphDraw;
						
					}
					
			}
			
			private void  cbdMenos_Click( Object eventSender,  EventArgs eventArgs)
			{
					if (lContador != CORVB.NULL_INTEGER)
					{
						
						gphGraficaRen.GraphTitle = "Rentabilidad";
						gphGraficaRen.LeftTitle = "Rentabilidad";
						
						Grafica_Param_Menos(iArrRentabilidad, mlTotalReg);
						
						if (gphGraficaRen.GraphType == CORCONST.INT_PAS_DOS_DIM || gphGraficaRen.GraphType == CORCONST.INT_PAS_TRES_DIM)
						{
							gphGraficaRen.LeftTitle = "Total  = " + StringsHelper.Format(mdTotalRen, "###,###,###,##0.00") + " de Rentabilidad";
							gphGraficaRen.BottomTitle = CORVB.NULL_STRING;
						} else
						{
							gphGraficaRen.LeftTitle = "Rentabilidad";
							gphGraficaRen.BottomTitle = CORVB.NULL_STRING;
						}
						
						//UPGRADE_ISSUE: (2069) VBControlExtender method gphGraficaRen.DrawMode was not upgraded.
						gphGraficaRen.DrawMode = GraphLib.DrawModeConstants.gphDraw;
						
					}
			}
			
			
			private void  cmdImprimir_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method gphGraficaRen.DrawMode was not upgraded.
					gphGraficaRen.DrawMode = CORVB.G_PRINT;
					gphGraficaRen.PrintStyle = GraphLib.PrintStyleConstants.gphColor;
			}
			
			private void  cmdSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY(1350);
					
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					cbdMenos.Enabled = false;
					
					
					
					gphGraficaRen.FontUse = CORVB.G_USE_ALL;
					gphGraficaRen.FontFamily = CORVB.G_FONT_SWISS;
					gphGraficaRen.FontStyle = CORVB.G_STYLE_DEFAULT;
					//Se definen para el Título
					gphGraficaRen.FontUse = CORVB.G_USE_DEFAULT;
					gphGraficaRen.Font = VB6.FontChangeSize(gphGraficaRen.Font, INT_FONTSIZE_TIT);
					
					//Se definen para los Títulos de la Izquierda y de Pie de Gráfica
					gphGraficaRen.FontUse = CORVB.G_USE_OTHER;
					gphGraficaRen.Font = VB6.FontChangeSize(gphGraficaRen.Font, INT_FONTSIZE_OTROS);
					
					//Se definen para los legend Text (los de la derecha)
					gphGraficaRen.FontUse = CORVB.G_USE_LEGEND;
					gphGraficaRen.Font = VB6.FontChangeSize(gphGraficaRen.Font, INT_FONTSIZE_OTROS);
					
					Carga_Grafica();
					
					//  gphGraficaRen.DataReset = G_ALL_DATA
					//  gphGraficaRen.DrawMode = G_CLEAR
					
					this.Cursor = Cursors.Default;
			}
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción:                                                     **
			//**                   Proceso utilizado para la grafivcageneral, muestra   **
			//**                   las demás empresas restattes                         **
			//**                                                                        **
			//**       Paso de parámetros:arreglo de datos,totalde registros leidos     **
			//**                                                                        **
			//**       Valor de Regreso:                                                **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 26nov98                                     **
			//**                                                                        **
			//****************************************************************************
			//
			private void  Grafica_Param_Mas( CORVAR.DatRentabilidad[] iArrDatos,  int lTotReg)
			{
					
					
					cbdMenos.Enabled = true;
					
					gphGraficaRen.NumPoints = 10;
					
					lContador++;
					
					gphGraficaRen.ThisPoint = 1;
					for (int iCont = lContador; iCont <= lContador + 9; iCont++)
					{
						if (iCont > lTotReg)
						{
							gphGraficaRen.GraphData = CORVB.NULL_INTEGER;
							//       gphGraficaRen.LegendText = NULL_STRING
							cbdMas.Enabled = false;
						} else
						{
							if (iArrDatos[iCont].lNoEmpresa != CORVB.NULL_INTEGER)
							{
								gphGraficaRen.GraphData = (float) iArrDatos[iCont].dRenTot;
							} else
							{
								gphGraficaRen.GraphData = CORVB.NULL_INTEGER;
								mbTermino = true;
							}
						}
					}
					
					gphGraficaRen.ThisPoint = 1;
					for (int iCont = lContador; iCont <= lContador + 9; iCont++)
					{
						if (iCont > lTotReg)
						{
							gphGraficaRen.LegendText = CORVB.NULL_STRING;
						} else
						{
							if (iArrDatos[iCont].lNoEmpresa != CORVB.NULL_INTEGER)
							{
								//EISSA 03-10-2001. Cambios para el formateo del número de empresa.
								gphGraficaRen.LegendText = StringsHelper.Format(iArrDatos[iCont].lNoEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "  " + Strings.Mid(iArrDatos[iCont].sNomEmpresa.ToUpper(), 1, 25);
							} else
							{
								gphGraficaRen.LegendText = CORVB.NULL_STRING;
								mbTermino = true;
							}
						}
					}
					
					if (! mbTermino)
					{
						//    If iCont >= lTotReg Then
						//      MsgBox " "
						//    Else
						lContador += 9;
						//    End If
					} else
					{
						lContador += 9;
						cbdMas.Enabled = false;
					}
					
			}
			
			
			
			private void  CORGRREN_Closed( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			
			private void  gpbGraf_ClickEvent( Object eventSender,  AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
			{
					int Index = Array.IndexOf(gpbGraf, eventSender);
                    //AIS-1095 NGONZALEZ
                    if (eventArgs.value != 0)
					{
						switch(Index)
						{
							case 0 : 
								gphGraficaRen.GraphType = CORVB.G_BAR2D; 
								gphGraficaRen.GraphStyle = 0; 
								gphGraficaRen.LeftTitle = "Rentabilidad"; 
								break;
							case 1 : 
								gphGraficaRen.GraphType = CORVB.G_BAR3D; 
								gphGraficaRen.GraphStyle = 0; 
								gphGraficaRen.LeftTitle = "Rentabilidad"; 
								break;
							case 2 : 
								gphGraficaRen.GraphType = CORVB.G_PIE2D; 
								gphGraficaRen.GraphStyle = 4; 
								gphGraficaRen.LeftTitle = "Total  = " + StringsHelper.Format(mdTotalRen, "###,###,###,##0.00") + " de Rentabilidad"; 
								gphGraficaRen.BottomTitle = CORVB.NULL_STRING; 
								break;
							case 3 : 
								gphGraficaRen.GraphType = CORVB.G_PIE3D; 
								gphGraficaRen.GraphStyle = 4; 
								gphGraficaRen.LeftTitle = "Total  = " + StringsHelper.Format(mdTotalRen, "###,###,###,##0.00") + " de Rentabilidad"; 
								gphGraficaRen.BottomTitle = CORVB.NULL_STRING; 
								break;
						}
						//UPGRADE_ISSUE: (2069) VBControlExtender method gphGraficaRen.DrawMode was not upgraded.
						gphGraficaRen.DrawMode = CORVB.G_DRAW;
					}
			}
			
			private void  gphGraficaRen_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					if (bMaximizada != 0)
					{ //Minimiza
						
						cmdImprimir.Visible = false;
						gphGraficaRen.Visible = false;
						pnlSegundo.Visible = false;
						this.Refresh();
						
						//Guardamos las Medidas Originales del Panel de la Gráfica
						pnlSegundo.Top = (int) VB6.TwipsToPixelsY(iPnlTop);
						pnlSegundo.Left = (int) VB6.TwipsToPixelsX(iPnlLeft);
						pnlSegundo.Height = (int) VB6.TwipsToPixelsY(iPnlHeight);
						pnlSegundo.Width = (int) VB6.TwipsToPixelsX(iPnlWidth);
						
						//Guardamos las Medidas Originales de la Gráfica
						gphGraficaRen.Top = (int) VB6.TwipsToPixelsY(iGphTop);
						gphGraficaRen.Left = (int) VB6.TwipsToPixelsX(iGphLeft);
						gphGraficaRen.Height = (int) VB6.TwipsToPixelsY(iGphHeight);
						gphGraficaRen.Width = (int) VB6.TwipsToPixelsX(iGphWidth);
						
						cmdImprimir.Top = (int) VB6.TwipsToPixelsY(iImpTop);
						cmdImprimir.Left = (int) VB6.TwipsToPixelsX(iImpLeft);
						
						pnlSegundo.Visible = true;
						pnlPrincipal.Visible = true;
						pnlTercero.Visible = true;
						//    ID_EMP_GRA_PB.Visible = True
						cmdSalir.Visible = true;
						cmdImprimir.Visible = true;
						this.Refresh();
						gphGraficaRen.Visible = true;
						bMaximizada = 0;
						
					} else
					{
						//Ocultamos todos los controles
						gphGraficaRen.Visible = false;
						pnlSegundo.Visible = false;
						pnlPrincipal.Visible = false;
						pnlTercero.Visible = false;
						cmdImprimir.Visible = false;
						//    ID_EMP_GRA_PB.Visible = False
						cmdSalir.Visible = false;
						this.Refresh();
						
						//Guardamos las Medidas Originales de la Gráfica
						iGphTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(gphGraficaRen.Top));
						iGphLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(gphGraficaRen.Left));
						iGphHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(gphGraficaRen.Height));
						iGphWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(gphGraficaRen.Width));
						
						//Guardamos las Medidas Originales del Panel de la Gráfica
						iPnlTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(pnlSegundo.Top));
						iPnlLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(pnlSegundo.Left));
						iPnlHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(pnlSegundo.Height));
						iPnlWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(pnlSegundo.Width));
						
						//Guardamos las Medidas Originales del Boton de Imprimir
						iImpTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(cmdImprimir.Top));
						iImpLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(cmdImprimir.Left));
						
						//Ajustamos las Medidas del Panel de la Gráfica
						pnlSegundo.Top = (int) pnlPrincipal.Top;
						pnlSegundo.Left = (int) pnlPrincipal.Left;
						pnlSegundo.Height = (int) (pnlPrincipal.Height + pnlSegundo.Height);
						pnlSegundo.Width = (int) pnlPrincipal.Width;
						
						//Ajustamos las Medidas de la Gráfica
						gphGraficaRen.Top = (int) pnlSegundo.Top;
						gphGraficaRen.Left = (int) pnlSegundo.Left;
						gphGraficaRen.Height = (int) pnlSegundo.Height;
						gphGraficaRen.Width = (int) pnlSegundo.Width;
						this.Refresh();
						
						cmdImprimir.Top = (int) (gphGraficaRen.Height - VB6.TwipsToPixelsY(((float) VB6.PixelsToTwipsY(cmdImprimir.Height)) * 1.5d));
						cmdImprimir.Left = (int) VB6.TwipsToPixelsX(((float) VB6.PixelsToTwipsX(cmdImprimir.Width)) * 0.2d);
						cmdImprimir.BringToFront();
						this.Refresh();
						
						cmdImprimir.Visible = true;
						gphGraficaRen.Visible = true;
						pnlSegundo.Visible = true;
						bMaximizada = -1;
						
					}
			}
		}
}