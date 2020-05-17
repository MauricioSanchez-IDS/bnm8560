using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORGRVEN
		: System.Windows.Forms.Form
		{
		
			private void  CORGRVEN_Activated( Object eventSender,  EventArgs eventArgs)
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
			//**       --------------------------------------------------------         **
			//**                                                                        **
			//**       Descripción: Grafica los Productos por meses de vencido,         **
			//**                    las Empresas por meses vencidos           ,         **
			//**                    y la Cartera vigente y la vencida                   **
			//**                                                                        **
			//**       Responsable: Hugo L. Morales Garcia                              **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 06/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			int iErr = 0; //Error Local
			//AIS-1178 NGONZALEZ
			CORVAR.DatosCorpo[] iArrParamPMV;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});; //Arreglo donde se guardan los Datos a Graficar
			//AIS-1178 NGONZALEZ
			CORVAR.DatosCorpo[] iArrParamEMV;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});; //Arreglo donde se guardan los Datos a Graficar
			double dCarteraVig = 0; //Arreglo donde se guardan los Datos a Graficar
			double dCarteraVen = 0;
			string pszSQL = String.Empty;
			int iNumPoints = 0;
			string pszEmpCve = String.Empty;
			int hConexion = 0;
			string pszTempEmp = String.Empty;
			
			int lTotalEMV = 0;
			int lTotalPMV = 0;
			
			//Para maximizar las Gráficas
			int bGrafMax = 0;
			int iTop = 0;
			int iLeft = 0;
			int iWidth = 0;
			int iHeight = 0;
			
			const string STR_ONCEAVO = "11  OTROS";
			const string STR_COMPLEMENTO = "OTROS";
			const string STR_COMPLEMENTO_MES = "MAS DE 6 MESES";
			//
			const string STR_LEFTTIT_TARHAB = "Tarjetas";
			const string STR_BOTTOMTIT_PMV = "Meses Vencidos";
			
			const string STR_GRAPHTIT_PMV = "Producto por Meses Vencidos";
			
			const string STR_BOTTOMTIT_EMV = "Empresas";
			const string STR_GRAPHTIT_EMV = "Empresas por Meses vencidos";
			
			const string STR_BOTTOMTIT_CVV = "Cartera Vigente";
			const string STR_BOTTOMTIT_CVN = "Cartera Vencida";
			
			const string STR_LEGEND_CVV = "Minimo a Pagar";
			const string STR_LEGEND_CVN = "Saldos Vencidos";
			
			const string STR_LEFT_CVV = "Importe (miles de pesos)";
			
			const string STR_GRAPHTIT_CVV = "Cartera Vigente / Vencida";
			
			const int INT_FONTSIZE_TIT = 150;
			const int INT_FONTSIZE_OTROS = 100;
			const int INT_MAX_PARAM = 10;
			const int INT_MAX_GRUPOS = 999;
			
			private int Carga_Empresas()
			{
					
					int hEmpresa = 0;
					int lEmpresa = 0;
					string pszEmpDesc = String.Empty;
					string pszEmp = String.Empty;
					string pszGrupo = String.Empty;
					
					ID_CRE_EMP_COB.Items.Clear();
					
					int iEmpresa = CORVB.NULL_INTEGER;
					
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = "SELECT emp_num, emp_nom FROM " + DB_SYB_EMP + " WHERE gpo_banco = " + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "SELECT emp_num, emp_nom FROM " + CORBD.DB_SYB_EMP + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							lEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
							pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL);
							//EISSA 03-10-2001. Cambio para el formateo del número de empresa.
							ID_CRE_EMP_COB.Items.Add(StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
							iEmpresa++;
						};
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					if (ID_CRE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
					{
						ID_CRE_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
						pszEmp = VB6.GetItemString(ID_CRE_EMP_COB, CORVB.NULL_INTEGER);
						pszEmpCve = Conversion.Val(Strings.Mid(pszEmp, 1, pszEmp.IndexOf(' '))).ToString();
					}
					
					return iEmpresa;
					
			}
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga los Datos necesarios para graficar Carte-     **
			//**                    ras vencidas y vigentes; luego los arroja a un      **
			//**                    arreglo para sucesivas redibujadas                  **
			//**                                                                        **
			//**       Declaración: Function Datos_Cartera()                            **   **
			//**                                                                        **
			//**       Paso de parámetros: Ninguno                                      **
			//**                                                                        **
			//**       Valor de Regreso: True si existieron datos                       **
			//**                         False si no existieron
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : pszSQL - Cadena de SQL                          **
			//**                        iErr   - Error generado                         **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private int Datos_Cartera()
			{
					
					int hBufCartera = 0;
					int iTempErr = 0;
					string pszNomEmpresa = String.Empty;
					int iCont = 0;
					
					iErr = CORCONST.OK;
					
					this.Cursor = Cursors.WaitCursor;
					
					CORVAR.pszgblsql = "select sum(ths_ant_minimo_pagar) from " + CORBD.DB_SYB_THS;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = pszgblsql + " where gpo_banco=" + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = CORVAR.pszgblsql + " union select sum(ths_vencidos_pagos_por_mes1 + ths_vencidos_pagos_por_mes2 + ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ths_vencidos_pagos_por_mes3 + ths_vencidos_pagos_por_mes4 + ths_vencidos_pagos_por_mes5 + ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ths_vencidos_pagos_por_mes6) from " + CORBD.DB_SYB_THS;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = pszgblsql + " where gpo_banco=" + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						//Obtenemos el minimo a pagar de las Carteras Vigentes
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							dCarteraVig = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) / 1000;
						}
						//Obtenemos el total de los Saldos vencidos
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							dCarteraVen = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) / 1000;
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						return -1;
					} else
					{
						this.Cursor = Cursors.Default;
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						return 0;
					}
					
					//  Screen.MousePointer = DEFAULT
					
			}
			
			private int Datos_EmpMV()
			{
					
					int hBufTHS = 0;
					int iTempErr = 0;
					FixedLengthString szNomEmpresa = new FixedLengthString(45);
					int iCont = 0;
					int iIndice = 0;
					
					iErr = CORCONST.OK;
					
					//ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = "exec graven_total_ven " + Format$(igblBanco) + "," + Format$(lgblTempNumEmp)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "exec graven_total_ven " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblTempNumEmp.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					int lRegs = CORPROC2.Cuenta_Registros();
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (lRegs != 0)
						{
							//***** Inicio Codigo Anterior FSWBMX *****
							//       ReDim iArrParamEMV(6)
							//***** FIN DE CODIGO Anterior FSWBMX *****
							//***** Inicio Codigo Nuevo FSWBMX *****
							//UPGRADE_WARNING: (1042) Array iArrParamEMV may need to have individual elements initialized.
							iArrParamEMV = new CORVAR.DatosCorpo[51];
							//***** FIN DE CODIGO Anterior FSWBMX *****
						} else
						{
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							return lRegs;
						}
						lTotalEMV = CORVB.NULL_INTEGER;
						
						while(! (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS && iCont < INT_MAX_PARAM))
						{
							iIndice = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							if (iIndice != 0)
							{
								iArrParamEMV[iIndice - 1].iCantidad = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
								lTotalEMV += iArrParamEMV[iIndice - 1].iCantidad;
							}
						};
						
						if (lTotalEMV == CORVB.NULL_INTEGER)
						{
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							return CORVB.NULL_INTEGER;
						}
						
						iArrParamEMV[0].pszDescripcion = "UN MES";
						iArrParamEMV[1].pszDescripcion = "DOS MESES";
						iArrParamEMV[2].pszDescripcion = "TRES MESES";
						iArrParamEMV[3].pszDescripcion = "CUATRO MESES";
						iArrParamEMV[4].pszDescripcion = "CINCO MESES";
						iArrParamEMV[5].pszDescripcion = "SEIS MESES";
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						//    pszgblsql = "exec graven_cuenta_ven " + Format$(igblBanco)
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO NUEVO FSWBMX *****
						CORVAR.pszgblsql = "exec graven_cuenta_ven " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
							{
								//***** Inicio Codigo Anterior FSWBMX *****
								//       iArrParamEMV(6).pszDescripcion = STR_COMPLEMENTO_MES
								//       iArrParamEMV(6).iCantidad = Val(SqlData(hgblConexion, 1))
								//***** FIN DE CODIGO Anterior FSWBMX *****
								//***** Inicio Codigo Nuevo FSWBMX *****
								iArrParamEMV[50].pszDescripcion = STR_COMPLEMENTO_MES;
								iArrParamEMV[50].iCantidad = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
								//***** FIN DE CODIGO Nuevo FSWBMX *****
							}
							//***** Inicio Codigo Anterior FSWBMX *****
							//     lTotalEMV = lTotalEMV + iArrParamEMV(6).iCantidad
							//***** FIN DE CODIGO Anterior FSWBMX *****
							//***** Inicio Codigo Nuevo FSWBMX *****
							lTotalEMV += iArrParamEMV[50].iCantidad;
							//***** FIN DE CODIGO Nuevo FSWBMX *****
						} else
						{
							this.Cursor = Cursors.Default;
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					} else
					{
						this.Cursor = Cursors.Default;
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					
					return lRegs;
					
			}
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga los Datos necesarios para graficar Produc-    **
			//**                    to por Meses de vencido                             **
			//**                                                                        **
			//**       Declaración: Function Datos_ProdMV()                             **
			//**                                                                        **
			//**       Paso de parámetros: Ninguno                                      **
			//**                                                                        **
			//**       Valor de Regreso:                                                **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : pszSQL - Cadena de SQL                          **
			//**                        iErr   - Error generado                         **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private int Datos_ProdMV()
			{
					
					int hBufTHS = 0;
					int iTempErr = 0;
					string pszNomEmpresa = String.Empty;
					int iCont = 0;
					int iIndice = 0;
					
					iErr = CORCONST.OK;
					
					//ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = "exec graven_carga_ven " + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "exec graven_carga_ven " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					int lRegs = CORVB.NULL_INTEGER;
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						//***** Inicio Codigo Anterior FSWBMX *****
						//ReDim iArrParamPMV(6)    COMENTARIO por instrucciones de yuria MAPEREZR
						//***** FIN DE CODIGO Anterior FSWBMX *****
						//***** Inicio Codigo Nuevo FSWBMX *****
						//UPGRADE_WARNING: (1042) Array iArrParamPMV may need to have individual elements initialized.
						iArrParamPMV = new CORVAR.DatosCorpo[51]; //modificacion por instrucciones de yuria MAPEREZR
						//***** FIN DE CODIGO Nuevo FSWBMX *****
						lTotalPMV = CORVB.NULL_INTEGER;
						
						
						while(! (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS && iCont < INT_MAX_PARAM))
						{
							lRegs++;
							iIndice = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							if (iIndice != 0)
							{
								iArrParamPMV[iIndice - 1].iCantidad = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
								lTotalPMV += iArrParamPMV[iIndice - 1].iCantidad;
							}
						};
						
						if (lTotalPMV == CORVB.NULL_INTEGER)
						{
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							return CORVB.NULL_INTEGER;
						}
						
						iArrParamPMV[0].pszDescripcion = "UN MES";
						iArrParamPMV[1].pszDescripcion = "DOS MESES";
						iArrParamPMV[2].pszDescripcion = "TRES MESES";
						iArrParamPMV[3].pszDescripcion = "CUATRO MESES";
						iArrParamPMV[4].pszDescripcion = "CINCO MESES";
						iArrParamPMV[5].pszDescripcion = "SEIS MESES";
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						//    pszgblsql = "exec graven_cuenta_ven " + Format$(igblBanco)
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO NUEVO FSWBMX *****
						CORVAR.pszgblsql = "exec graven_cuenta_ven " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
						//***** FIN DE CODIGO NUEVO FSWBMX *****
						
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
							{
								//***** Inicio Codigo Anterior FSWBMX *****
								//       iArrParamPMV(6).pszDescripcion = STR_COMPLEMENTO_MES
								//       iArrParamPMV(6).iCantidad = Val(SqlData(hgblConexion, 1))
								//***** FIN DE CODIGO Anterior FSWBMX *****
								//***** Inicio Codigo Nuevo FSWBMX *****
								iArrParamPMV[50].pszDescripcion = STR_COMPLEMENTO_MES;
								iArrParamPMV[50].iCantidad = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
								//***** FIN DE CODIGO Nuevo FSWBMX *****
							}
							//***** Inicio Codigo Anterior FSWBMX *****
							//      lTotalPMV = iArrParamPMV(6).iCantidad + lTotalPMV
							//***** FIN DE CODIGO Anterior FSWBMX *****
							//***** Inicio Codigo Nuevo FSWBMX *****
							lTotalPMV = iArrParamPMV[50].iCantidad + lTotalPMV;
							//***** FIN DE CODIGO Nuevo FSWBMX *****
						} else
						{
							this.Cursor = Cursors.Default;
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					} else
					{
						this.Cursor = Cursors.Default;
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					
					return lRegs;
					
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					int lEmpresa = 0;
					
					//Posicionamos la forma
					Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(Width))) / 2);
					Top = (int) VB6.TwipsToPixelsY(1250);
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					
					
					
					ID_GRA_PAR_COB.Items.Add("Meses Vencidos por Producto");
					ID_GRA_PAR_COB.Items.Add("Meses Vencidos por Empresas");
					ID_GRA_PAR_COB.Items.Add("Cartera Vigente-Vencida");
					ID_GRA_PAR_COB.SelectedIndex = CORVB.NULL_INTEGER;
					
					int lEmpresas = Carga_Empresas(); //Se cargan para el detalle
					if (iErr == CORCONST.OK)
					{
						if (lEmpresas != 0)
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 1, -1);
						} else
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 1, 0);
						}
					} else
					{
						//AIS-1182 NGONZALEZ
						iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
						return;
					}
					
					int iProducto = Datos_ProdMV();
					if (iErr == CORCONST.OK)
					{
						if (iProducto != 0)
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 0, -1);
						} else
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 0, 0);
						}
					} else
					{
						//AIS-1182 NGONZALEZ
						iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
						return;
					}
					
					int iCartera = Datos_Cartera();
					if (iErr == CORCONST.OK)
					{
						if (iCartera != 0)
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 2, -1);
						} else
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 2, 0);
						}
					} else
					{
						//AIS-1182 NGONZALEZ
						iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
						return;
					}
					
					if (iProducto != 0)
					{
						ID_GRA_PAR_COB.SelectedIndex = 0;
					} else if (lEmpresa != 0) { 
						ID_GRA_PAR_COB.SelectedIndex = 1;
					} else if (iCartera != 0) { 
						ID_GRA_PAR_COB.SelectedIndex = 2;
					} else
					{
						this.Cursor = Cursors.WaitCursor;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						//AIS-1182 NGONZALEZ
						iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
						return;
					}
					
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
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					
					this.Cursor = Cursors.Default;
					
					bGrafMax = 0;
					
					
					
			}
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga a la gráfica(el objeto) los datos necesarios  **
			//**                    guardados en el arreglo correspondiente             **
			//**                                                                        **
			//**       Declaración: Function Grafica_Param()                            **
			//**                                                                        **
			//**       Paso de parámetros: iArrDatos() - El arreglo a graficar          **
			//**                                                                        **
			//**       Valor de Regreso:                                                **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : pszSQL - Cadena de SQL                          **
			//**                        iErr   - Error generado                         **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private void  Grafica_Param( CORVAR.DatosCorpo[] iArrDatos)
			{
					
					string pszLeftTitle = String.Empty;
					
					ID_GRA_GPH.NumPoints = (short) (iArrDatos.GetUpperBound(0) + 1);
					ID_GRA_GPH.ThisPoint = 1;
					for (int iCont = 0; iCont <= iArrDatos.GetUpperBound(0); iCont++)
					{
						ID_GRA_GPH.GraphData = iArrDatos[iCont].iCantidad;
					}
					
					ID_GRA_GPH.ThisPoint = 1;
					for (int iCont = 0; iCont <= iArrDatos.GetUpperBound(0); iCont++)
					{
						ID_GRA_GPH.LegendText = StringsHelper.Format(iCont + 1, "00") + "  " + iArrDatos[iCont].pszDescripcion.ToUpper();
					}
					
			}
			
			private void  ID_CRE_EMP_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					
					//  Screen.MousePointer = DEFAULT
					
			}
			
			private void  ID_GRA_B3D_GPB_ClickEvent( Object eventSender,  AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
			{
					int Index = Array.IndexOf(ID_GRA_B3D_GPB, eventSender);

                    //AIS-1095 NGONZALEZ
					if (eventArgs.value != 0)
					{
						switch(Index)
						{
							case 0 : 
								ID_GRA_GPH.GraphType = CORVB.G_BAR2D; 
								ID_GRA_GPH.GraphStyle = 0; 
								break;
							case 1 : 
								ID_GRA_GPH.GraphType = CORVB.G_BAR3D; 
								ID_GRA_GPH.GraphStyle = 0; 
								break;
							case 2 : 
								ID_GRA_GPH.GraphType = CORVB.G_PIE2D; 
								ID_GRA_GPH.GraphStyle = 4; 
								break;
							case 3 : 
								ID_GRA_GPH.GraphType = CORVB.G_PIE3D; 
								ID_GRA_GPH.GraphStyle = 4; 
								break;
						}
						Pon_Titulos();
						//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
						ID_GRA_GPH.DrawMode = CORVB.G_DRAW;
					}
					
			}
			
			private void  ID_GRA_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					this.Close();
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_GRA_GFC_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_GRA_TIPO_PNL.Enabled = true;
                    try
                    {


                        switch (ID_GRA_PAR_COB.SelectedIndex)
                        {
                            case 0:
                                if (VB6.GetItemData(ID_GRA_PAR_COB, 0) != 0)
                                {
                                    Grafica_Param(iArrParamPMV);
                                    if (ID_GRA_GPH.GraphType == CORVB.G_BAR2D || ID_GRA_GPH.GraphType == CORVB.G_BAR3D)
                                    {
                                        ID_GRA_GPH.GraphStyle = 0;
                                        ID_GRA_GPH.BottomTitle = "Meses Vencidos";
                                    }
                                    else
                                    {
                                        ID_GRA_GPH.GraphStyle = 4;
                                        ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
                                    }
                                    Pon_Titulos();
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_DRAW;
                                    ID_GRA_PPL_PNL.Enabled = true;
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
                                    ID_GRA_TIPO_PNL.Enabled = false;
                                }

                                break;
                            case 1:

                                if (VB6.GetItemData(ID_GRA_PAR_COB, 1) != 0)
                                {

                                    CORVAR.lgblTempNumEmp = CORVB.NULL_INTEGER;

                                    if (ID_CRE_IRA_CHK.Value)
                                    {
                                        this.Cursor = Cursors.WaitCursor;
                                        CORIREMP.DefInstance.Tag = "CORGRVEN";
                                        //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                                        CORIREMP.DefInstance.ShowDialog();
                                        Refresh();
                                    }
                                    else
                                    {
                                        if (ID_CRE_EMP_COB.Items.Count != 0)
                                        {
                                            //EISSA 05-10-2001. Cambio para obtener la longitud del número de empresa.
                                            CORVAR.lgblTempNumEmp = StringsHelper.IntValue(ID_CRE_EMP_COB.Text.Substring(0, Math.Min(ID_CRE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)));
                                        }
                                        else
                                        {
                                            this.Cursor = Cursors.Default;
                                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                            Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                            ID_GRA_TIPO_PNL.Enabled = false;
                                            return;
                                        }
                                    }

                                    if (CORVAR.lgblTempNumEmp > CORVB.NULL_INTEGER)
                                    {
                                        if (Datos_EmpMV() > CORVB.NULL_INTEGER)
                                        {

                                            pszTempEmp = Nombre_Empresa();
                                            if (iErr != CORCONST.OK)
                                            {
                                                //AIS-1182 NGONZALEZ
                                                iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                                                return;
                                            }

                                            Grafica_Param(iArrParamEMV);

                                            if (ID_GRA_GPH.GraphType == CORVB.G_BAR2D || ID_GRA_GPH.GraphType == CORVB.G_BAR3D)
                                            {
                                                ID_GRA_GPH.GraphStyle = 0;
                                                ID_GRA_GPH.BottomTitle = "Meses Vencidos   " + ID_CRE_EMP_COB.Text.Trim();
                                            }
                                            else
                                            {
                                                ID_GRA_GPH.GraphStyle = 4;
                                                ID_GRA_GPH.BottomTitle = ID_CRE_EMP_COB.Text.Trim();
                                            }
                                            Pon_Titulos();
                                            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                            ID_GRA_GPH.DrawMode = CORVB.G_DRAW;
                                            ID_GRA_PPL_PNL.Enabled = true;
                                        }
                                        else
                                        {
                                            this.Cursor = Cursors.Default;
                                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                            Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                            ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
                                            ID_GRA_TIPO_PNL.Enabled = false;
                                        }
                                    }

                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
                                    ID_GRA_TIPO_PNL.Enabled = false;
                                }
                                break;
                            case 2:

                                if (VB6.GetItemData(ID_GRA_PAR_COB, 2) != 0)
                                {

                                    ID_GRA_GPH.NumPoints = 2;

                                    ID_GRA_GPH.ThisPoint = 1;
                                    ID_GRA_GPH.GraphData = (float)dCarteraVen;
                                    ID_GRA_GPH.ThisPoint = 2;
                                    ID_GRA_GPH.GraphData = (float)dCarteraVig;

                                    ID_GRA_GPH.ThisPoint = 1;
                                    ID_GRA_GPH.LegendText = STR_BOTTOMTIT_CVV + "  " + STR_LEGEND_CVV;
                                    ID_GRA_GPH.ThisPoint = 2;
                                    ID_GRA_GPH.LegendText = STR_BOTTOMTIT_CVN + "  " + STR_LEGEND_CVN;

                                    if (ID_GRA_GPH.GraphType == CORVB.G_BAR2D || ID_GRA_GPH.GraphType == CORVB.G_BAR3D)
                                    {
                                        ID_GRA_GPH.GraphStyle = 0;
                                        ID_GRA_GPH.BottomTitle = "Carteras";
                                    }
                                    else
                                    {
                                        ID_GRA_GPH.GraphStyle = 4;
                                        ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
                                    }
                                    Pon_Titulos();
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_DRAW;
                                    ID_GRA_PPL_PNL.Enabled = true;
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
                                    ID_GRA_TIPO_PNL.Enabled = false;
                                }

                                break;
                        }

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fallo operación ID_GRA_GFC_PB_Click " + exc.Message, "Error Corgrven", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {

                        this.Cursor = Cursors.Default; //****
                    }
					
			}
			
			private void  ID_GRA_GPH_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.Visible = false;
					ID_GRA_IMP_PB.Visible = false;
					Refresh();
					
					if (bGrafMax != 0)
					{
						ID_GRA_IMP_PB.Left = (int) VB6.TwipsToPixelsX(6150);
						ID_GRA_GFC_PB.Visible = true;
						ID_GRA_CAN_PB.Visible = true;
						ID_GRA_GPH.Top = (int) VB6.TwipsToPixelsY(iTop);
						ID_GRA_GPH.Left = (int) VB6.TwipsToPixelsX(iLeft);
						ID_GRA_GPH.Width = (int) VB6.TwipsToPixelsX(iWidth);
						ID_GRA_GPH.Height = (int) VB6.TwipsToPixelsY(iHeight);
						bGrafMax = 0;
					} else
					{
						ID_GRA_IMP_PB.Left = (int) VB6.TwipsToPixelsX(300);
						ID_GRA_GFC_PB.Visible = false;
						ID_GRA_CAN_PB.Visible = false;
						
						iTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_GPH.Top));
						iLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_GPH.Left));
						iWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_GPH.Width));
						iHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_GPH.Height));
						
						ID_GRA_GPH.Top = (int) VB6.TwipsToPixelsY(-15);
						ID_GRA_GPH.Left = (int) VB6.TwipsToPixelsX(-15);
						ID_GRA_GPH.Width = (int) Width;
						ID_GRA_GPH.Height = (int) VB6.TwipsToPixelsY(((float) VB6.PixelsToTwipsY(Height)) - 300);
						bGrafMax = -1;
						ID_GRA_IMP_PB.BringToFront();
						Refresh();
						
					}
					ID_GRA_GFC_PB.Visible = true;
					ID_GRA_IMP_PB.Visible = true;
					ID_GRA_GPH.Visible = true;
					
			}
			
			private void  ID_GRA_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_PRINT;
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_GRA_PAR_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					//ros**  ID_GRA_PPL_PNL.Enabled = False
					ID_GRA_TIPO_PNL.Enabled = false;
					
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
					
					ID_GRA_GPH.Visible = true; //ros**
					//Screen.MousePointer = DEFAULT
					
			}
			
			private string Nombre_Empresa()
			{
					
					string result = String.Empty;
					string pszEmpresa = String.Empty;
					int hBufEmpresa = 0;
					int iTempErr = 0;
					
					CORVAR.pszgblsql = "select emp_nom from " + CORBD.DB_SYB_EMP;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = pszgblsql + " where gpo_banco=" + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + CORVAR.lgblTempNumEmp.ToString();
					
					iErr = CORCONST.OK;
					
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 1);
							result = pszEmpresa;
						} else
						{
							result = CORVB.NULL_STRING;
						}
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					this.Cursor = Cursors.Default;
					
					return result;
			}
			
			private void  Pon_Titulos()
			{
					
					switch(ID_GRA_PAR_COB.SelectedIndex)
					{
						
						case 0 : 
							ID_GRA_GPH.GraphTitle = STR_GRAPHTIT_PMV; 
							if (ID_GRA_GPH.GraphStyle == 4)
							{
								ID_GRA_GPH.LeftTitle = "Total = " + lTotalPMV.ToString() + " Meses Vencidos";
								ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
							} else
							{
								ID_GRA_GPH.LeftTitle = STR_LEFTTIT_TARHAB;
								ID_GRA_GPH.BottomTitle = "Meses Vencidos";
							} 
							 
							break;
						case 1 : 
							ID_GRA_GPH.GraphTitle = STR_GRAPHTIT_EMV; 
							if (ID_GRA_GPH.GraphStyle == 4)
							{
								ID_GRA_GPH.LeftTitle = "Total = " + lTotalEMV.ToString() + " Meses Vencidos";
								ID_GRA_GPH.BottomTitle = ID_CRE_EMP_COB.Text.Trim();
							} else
							{
								ID_GRA_GPH.LeftTitle = STR_LEFTTIT_TARHAB;
								ID_GRA_GPH.BottomTitle = "Meses Vencidos   " + ID_CRE_EMP_COB.Text.Trim();
							} 
							 
							break;
						case 2 : 
							 
							ID_GRA_GPH.GraphTitle = STR_GRAPHTIT_CVV; 
							ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
							if (ID_GRA_GPH.GraphStyle == 4)
							{
								ID_GRA_GPH.LeftTitle = "Total = " + StringsHelper.Format(dCarteraVig + dCarteraVen, "$###,###,###.00") + " (Miles de Pesos)";
								ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
							} else
							{
								ID_GRA_GPH.LeftTitle = STR_LEFT_CVV;
								ID_GRA_GPH.BottomTitle = "Carteras";
							} 
							 
							break;
					}
			}
			private void  CORGRVEN_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}