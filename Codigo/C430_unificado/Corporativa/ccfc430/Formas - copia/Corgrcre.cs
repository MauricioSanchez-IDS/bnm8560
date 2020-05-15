using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORGRCRE
		: System.Windows.Forms.Form
		{
		
			private void  CORGRCRE_Activated( Object eventSender,  EventArgs eventArgs)
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
			//**       Descripción: Grafica los créditos otorgados por producto         **
			//**                    o por empresa con limites de créditos o compa-      **
			//**                    rando lo otorgado contra lo consumido               **
			//**                                                                        **
			//**       Responsable: Felipe Zacarias Jimenez                             **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			const int INT_MAX_EMPRESAS = 5;
			const int INT_MAX_GRUPOS = 5;
			
			const int MAX_RANGOS = 9;
			
			const int INT_FONTSIZE_TIT = 150;
			const int INT_FONTSIZE_OTROS = 100;
			
			double[, ] dArrRangos = new double[MAX_RANGOS + 1, 2];
			double[] dArrCredito = new double[MAX_RANGOS + 1];
			int iNumPoints = 0;
			int iGrafica = 0;
			string pszEmpCve = String.Empty;
			double dTotalOtorgado = 0;
			double dTotalReal = 0;
			double dMax = 0;
			
			//Variables para las conexiones a la Base de Datos
			int hConexion = 0;
			
			//Variables para los handels a grupos y a empresas
			int hGrupos = 0;
			int hEmpresas = 0;
			
			//Variables del Total de Elementos de los Combos
			int lTotalGrupos = 0;
			int lTotalEmpresas = 0;
			
			//Variable para controlar el numero de Grupos y Empresas Restantes
			int lGruposRestantes = 0;
			int lEmpresasRestantes = 0;
			
			//Variable para almacenar el número de Empresa elegida
			string pszEmpresa = String.Empty;
			
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
			
			private void  Actualiza_Rangos()
			{
					
					int hRango = 0;
					int hInserta = 0;
					int iPoints = 0;
					
					CORVAR.pszgblsql = "DELETE FROM " + CORBD.DB_SYB_INT;
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
						
						iPoints = CORVB.NULL_INTEGER;
						if (dArrRangos != null)
						{
							Array.Clear(dArrRangos, 0, dArrRangos.Length);
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						
						for (int iCont = dArrRangos.GetLowerBound(0); iCont <= dArrRangos.GetUpperBound(0); iCont++)
						{
							if (! (Conversion.Val(ID_CRE_MIN_FTB[iCont].CtlText) == CORVB.NULL_INTEGER && Conversion.Val(ID_CRE_MAX_FTB[iCont].CtlText) == CORVB.NULL_INTEGER))
							{
								CORVAR.pszgblsql = "INSERT INTO " + CORBD.DB_SYB_INT + " (int_numero,int_minimo,int_maximo) VALUES (" + (iCont + 1).ToString() + "," + ID_CRE_MIN_FTB[iCont].CtlText + "," + ID_CRE_MAX_FTB[iCont].CtlText + ")";
								
								if (CORPROC2.Modifica_Registro() != 0)
								{
									dArrRangos[iCont, 0] = Conversion.Val(ID_CRE_MIN_FTB[iCont].CtlText);
									dArrRangos[iCont, 1] = Conversion.Val(ID_CRE_MAX_FTB[iCont].CtlText);
									iPoints++;
								}
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							}
						}
						
						iNumPoints = iPoints;
					} else
					{
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					
			}
			
			private void  Asigna_A_Grafica()
			{
					
					int bGrafica = 0;
					double dFactor = 0;
					string pszTitulo = String.Empty;
					string pszLabel1 = String.Empty;
					string pszLabel2 = String.Empty;
					
					dMax = CORVB.NULL_INTEGER;
					
					switch(iGrafica)
					{
						case 1 : case 2 : 
							bGrafica = 0; 
							for (int iCont = CORVB.NULL_INTEGER; iCont <= iNumPoints - 1; iCont++)
							{
								if (dArrCredito[iCont] != 0)
								{
									bGrafica = -1;
								}
							} 
							break;
						case 3 : case 4 : 
							if (dTotalOtorgado == CORVB.NULL_INTEGER && dTotalReal == CORVB.NULL_INTEGER)
							{
								bGrafica = 0;
							} else
							{
								bGrafica = -1;
							} 
							break;
					}
					
					switch(iGrafica)
					{
						case 1 : case 2 : 
							ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA; 
							ID_CRE_GRA_GPH.NumSets = 1; 
							 
							if (iNumPoints > 1)
							{
								ID_CRE_GRA_GPH.NumPoints = (short) iNumPoints;
							} 
							 
							for (int iCont = CORVB.NULL_INTEGER; iCont <= iNumPoints - 1; iCont++)
							{
								ID_CRE_GRA_GPH.ThisPoint = (short) (iCont + 1);
								ID_CRE_GRA_GPH.ThisSet = 1;
								ID_CRE_GRA_GPH.GraphData = (float) dArrCredito[iCont]; // \ dFactor
								ID_CRE_GRA_GPH.LegendText = dArrRangos[iCont, 0].ToString() + "-" + dArrRangos[iCont, 1].ToString();
								dMax += dArrCredito[iCont];
							} 
							 
							ID_CRE_GRA_GPH.LeftTitle = pszTitulo; 
							 
							break;
						case 3 : case 4 : 
							ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA; 
							ID_CRE_GRA_GPH.NumSets = 1; 
							ID_CRE_GRA_GPH.NumPoints = 2; 
							 
							//Asigna los Valores 
							ID_CRE_GRA_GPH.ThisSet = 1; 
							ID_CRE_GRA_GPH.ThisPoint = 1; 
							if (ID_CRE_GRA_GPH.GraphStyle == 3 || ID_CRE_GRA_GPH.GraphStyle == 4)
							{
								ID_CRE_GRA_GPH.GraphData = (float) (dTotalOtorgado - dTotalReal);
							} else
							{
								ID_CRE_GRA_GPH.GraphData = (float) dTotalOtorgado;
							} 
							 
							ID_CRE_GRA_GPH.ThisSet = 1; 
							ID_CRE_GRA_GPH.ThisPoint = 2; 
							if (ID_CRE_GRA_GPH.GraphStyle == 3 || ID_CRE_GRA_GPH.GraphStyle == 4)
							{
								ID_CRE_GRA_GPH.GraphData = (float) dTotalReal; //\ dFactor
							} else
							{
								ID_CRE_GRA_GPH.GraphData = (float) dTotalReal; //\ dFactor
							} 
							 
							if ((ID_CRE_TIP_SSR[0].Value) || (ID_CRE_TIP_SSR[1].Value))
							{
								ID_CRE_GRA_GPH.ThisSet = 1;
								ID_CRE_GRA_GPH.ThisPoint = 1;
								ID_CRE_GRA_GPH.LabelText = pszLabel1;
								
								ID_CRE_GRA_GPH.ThisSet = 1;
								ID_CRE_GRA_GPH.ThisPoint = 2;
								ID_CRE_GRA_GPH.LabelText = pszLabel2;
							} 
							break;
					}
					
					if (ID_CRE_GRA_GPH.GraphStyle == 4)
					{
						switch(iGrafica)
						{
							case 1 : case 2 : 
								ID_CRE_GRA_GPH.LeftTitle = "Total = " + dMax.ToString() + " Tarjetahabientes"; 
								ID_CRE_GRA_GPH.GraphTitle = ID_CRE_TIP_COB.Text; 
								break;
							case 3 : case 4 : 
								ID_CRE_GRA_GPH.LeftTitle = "Total = " + dTotalOtorgado.ToString() + " Créditos"; 
								ID_CRE_GRA_GPH.GraphTitle = "Asignado vs. Disponible"; 
								ID_CRE_GRA_GPH.ThisSet = 1; 
								ID_CRE_GRA_GPH.ThisPoint = 1; 
								ID_CRE_GRA_GPH.LegendText = "1 - Disponible"; 
								 
								ID_CRE_GRA_GPH.ThisSet = 1; 
								ID_CRE_GRA_GPH.ThisPoint = 2; 
								ID_CRE_GRA_GPH.LegendText = "2 - Utilizado";  //Asignado 
								break;
						}
						
						switch(iGrafica)
						{
							case 2 : case 4 : 
								ID_CRE_GRA_GPH.BottomTitle = ID_CRE_EMP_COB.Text.Trim(); 
								break;
							default:
								ID_CRE_GRA_GPH.BottomTitle = CORVB.NULL_STRING; 
								break;
						}
					} else
					{
						switch(iGrafica)
						{
							case 1 : case 2 : 
								ID_CRE_GRA_GPH.LeftTitle = "Tarjeta - habientes"; 
								ID_CRE_GRA_GPH.GraphTitle = ID_CRE_TIP_COB.Text; 
								if (iGrafica == 1)
								{
									ID_CRE_GRA_GPH.BottomTitle = "Rangos";
								} else
								{
									ID_CRE_GRA_GPH.BottomTitle = "Rangos   " + ID_CRE_EMP_COB.Text.Trim();
								} 
								break;
							case 3 : case 4 : 
								ID_CRE_GRA_GPH.LeftTitle = "Total de Créditos"; 
								ID_CRE_GRA_GPH.GraphTitle = "Asignado vs. Utilizado"; 
								 
								ID_CRE_GRA_GPH.ThisSet = 1; 
								ID_CRE_GRA_GPH.ThisPoint = 1; 
								ID_CRE_GRA_GPH.LegendText = "1 - Asignado"; 
								 
								ID_CRE_GRA_GPH.ThisSet = 1; 
								ID_CRE_GRA_GPH.ThisPoint = 2; 
								ID_CRE_GRA_GPH.LegendText = "2 - Utilizado"; 
								if (iGrafica == 3)
								{
									ID_CRE_GRA_GPH.BottomTitle = "Usos";
								} else
								{
									ID_CRE_GRA_GPH.BottomTitle = "Usos   " + ID_CRE_EMP_COB.Text.Trim();
								} 
								break;
						}
					}
					
					if (bGrafica != 0)
					{
						//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
						ID_CRE_GRA_GPH.DrawMode = CORVB.G_DRAW;
					} else
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
						//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
						ID_CRE_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					}
					
			}
			
			private void  Carga_Creditos( int iCond)
			{
					
					string pszSQL = String.Empty;
					int hOtorgado = 0;
					int hConsumo = 0;
					
					dTotalOtorgado = CORVB.NULL_INTEGER;
					dTotalReal = CORVB.NULL_INTEGER;
					
					if (iCond != 0)
					{
						if (pszEmpresa.Length == CORVB.NULL_INTEGER)
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("No existen empresas a consultar", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
							CORVAR.igblCancela = 0;
							return;
						}
					}
					
					//Otorgado----------------------------------------
					if ( ~iCond != 0)
					{
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						//   pszgblsql = "credito_otorgado " + Format$(igblBanco)
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO NUEVO FSWBMX *****
						CORVAR.pszgblsql = "credito_otorgado " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
						//***** FIN DE CODIGO NUEVO FSWBMX *****
						
					} else
					{
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						//   pszgblsql = "credito_otor_emp " + Format$(igblBanco) + "," + pszEmpresa
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO NUEVO FSWBMX *****
						CORVAR.pszgblsql = "credito_otor_emp " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + pszEmpresa;
						//***** FIN DE CODIGO NUEVO FSWBMX *****
					}
					
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							dTotalOtorgado = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL));
						}
					} else
					{
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					//Real--------------------------------------------
					if ( ~iCond != 0)
					{
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						//    pszgblsql = "credito_consumo " + Format$(igblBanco)
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO NUEVO FSWBMX *****
						CORVAR.pszgblsql = "credito_consumo " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
						//***** FIN DE CODIGO NUEVO FSWBMX *****
					} else
					{
						//***** INICIO CODIGO ANTERIOR FSWBMX  *****
						//    pszgblsql = "credito_cons_emp " + Format$(igblBanco) + "," + pszEmpresa
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO NUEVO FSWBMX *****
						CORVAR.pszgblsql = "credito_cons_emp " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + pszEmpresa;
						//***** FIN DE OCDIGO NUEVO FSWBMX *****
					}
					
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							dTotalReal = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL));
						}
					} else
					{
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
			}
			
			private void  Carga_Ejecutivos( int iCond)
			{
					
					int hEjecutivo = 0;
					double dTotalCredito = 0;
					string pszSQL = String.Empty;
					
					if (dArrCredito != null)
					{
						Array.Clear(dArrCredito, 0, dArrCredito.Length);
					}
					
					int bRangos = 0;
					for (int iCont = dArrRangos.GetLowerBound(0); iCont <= dArrRangos.GetUpperBound(0); iCont++)
					{
						if (dArrRangos[iCont, 0] != CORVB.NULL_INTEGER && dArrRangos[iCont, 1] != CORVB.NULL_INTEGER)
						{
							bRangos = -1;
						}
					}
					
					if ( ~bRangos != 0)
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No existen rangos para realizar la gráfica. Favor de capturarlos", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						CORVAR.igblCancela = 0;
						return;
					}
					
					if (iCond != 0)
					{
						if (pszEmpresa.Length == CORVB.NULL_INTEGER)
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("No existen empresas a consultar", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
							CORVAR.igblCancela = 0;
							return;
						}
					}
					
					for (int iCont = dArrRangos.GetLowerBound(0); iCont <= dArrRangos.GetUpperBound(0); iCont++)
					{
						if (! (dArrRangos[iCont, 0] == CORVB.NULL_INTEGER && dArrRangos[iCont, 1] == CORVB.NULL_INTEGER))
						{
							
							dTotalCredito = CORVB.NULL_INTEGER;
							if ( ~iCond != 0)
							{
								//***** INICIO CODIGO ANTERIOR FSWBMX *****
								//       pszgblsql = "credito_ejecutivo " + Format$(dArrRangos(iCont, 0)) + "," + Format$(dArrRangos(iCont, 1)) + "," + Format$(igblBanco)
								//***** FIN DE CODIGO ANTERIOR FSWBMX *****
								//***** INICIO CODIGO NUEVO FSWBMX *****
								CORVAR.pszgblsql = "credito_ejecutivo " + dArrRangos[iCont, 0].ToString() + "," + dArrRangos[iCont, 1].ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
								//***** FIN DE CODIGO NUEVO FSWBMX *****
							} else
							{
								//***** INICIO CODIGO ANTERIOR FSWBMX *****
								//       pszgblsql = "credito_ejecutivo_cond " + Format$(dArrRangos(iCont, 0)) + "," + Format$(dArrRangos(iCont, 1)) + "," + Format$(igblBanco) + "," + pszEmpresa
								//***** FIN DE CODIGO ANTERIOR FSWBMX *****
								//***** INICIO CODIGO NUEVO FSWBMX *****
								CORVAR.pszgblsql = "credito_ejecutivo_cond " + dArrRangos[iCont, 0].ToString() + "," + dArrRangos[iCont, 1].ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + pszEmpresa;
								//***** FIN DE CODIGO NUEVO FSWBMX *****
							}
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
								{
									dTotalCredito = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
									dArrCredito[iCont] = dTotalCredito;
								}
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
					}
					
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (Carga_Empresas) seems to be dead code
			//private void  Carga_Empresas()
			//{
					//
					//int hEmpresa = 0;
					//int lEmpresa = 0;
					//string pszEmpDesc = String.Empty;
					//string pszEmp = String.Empty;
					//string pszGrupo = String.Empty;
					//
					//ID_CRE_EMP_COB.Items.Clear();
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					// pszgblsql = "SELECT emp_num, emp_nom FROM " + DB_SYB_EMP + " WHERE gpo_banco=" + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					//CORVAR.pszgblsql = "SELECT emp_num, emp_nom FROM " + CORBD.DB_SYB_EMP + " WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " ANDS gpo_banco=" + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					//
					//if (CORPROC2.Obtiene_Registros() != 0)
					//{
						//
						//while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						//{
							//lEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
							//pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL);
							//EISSA 03-10-2001. Cambios para formatear el número de empresa.
							//ID_CRE_EMP_COB.Items.Add(StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
						//};
					//}
					//
					//CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					//
					//if (ID_CRE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
					//{
						//pszEmp = VB6.GetItemString(ID_CRE_EMP_COB, CORVB.NULL_INTEGER);
						//pszEmpCve = Conversion.Val(Strings.Mid(pszEmp, 1, pszEmp.IndexOf(' '))).ToString();
					//}
					//
			//}
			
			private void  Carga_Rangos()
			{
					
					int hRango = 0;
					int iNumRan = 0;
					int iCont = 0;
					double dMinimo = 0;
					double dMaximo = 0;
					
					CORVAR.pszgblsql = "SELECT int_numero,int_minimo,int_maximo FROM " + CORBD.DB_SYB_INT;
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						iCont = CORVB.NULL_INTEGER;
						if (dArrRangos != null)
						{
							Array.Clear(dArrRangos, 0, dArrRangos.Length);
						}
						
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							iNumRan = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
							dMinimo = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL));
							dMaximo = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL));
							dArrRangos[iNumRan - 1, 0] = dMinimo;
							dArrRangos[iNumRan - 1, 1] = dMaximo;
							iCont++;
						};
						iNumPoints = iCont;
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
			}
			
			private void  CORGRCRE_KeyDown( Object eventSender,  KeyEventArgs eventArgs)
			{
					int KeyCode = (int) eventArgs.KeyCode;
					int Shift = (int) eventArgs.KeyData / 0x10000;
					
					if (KeyCode == CORVB.KEY_F6)
					{
						ID_CRE_GRA_GPH_DblClick(ID_CRE_GRA_GPH, new EventArgs());
					}
					
			}
			
			private void  CORGRCRE_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					
					if (KeyAscii == CORVB.KEY_ESCAPE)
					{
						this.Close();
					}
					
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY(1250);
					
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					
					
					iNumPoints = CORVB.NULL_INTEGER;
					
					Inicializa_Combo_Tipo();
					
					bMaximizada = 0;
					
					Carga_Rangos();
					//  igblErr = Obten_Empresas()
					
					iGrafica = 1;
					
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
					
			}
			
			private void  Habilita_Combos( int bStatus)
			{
					
					ID_CRE_EMP_COB.Visible = bStatus != 0;
					
					ID_CRE_ETI_TXT[3].Visible = bStatus != 0;
					ID_CRE_EMP_COB.Visible = bStatus != 0;
					
					ID_CRE_IRA_CHK.Visible = bStatus != 0;
					
					if ( ~bStatus != 0)
					{
						ID_CRE_IRA_CHK.Value = bStatus != 0;
					}
					
			}
			
			private void  ID_CRE_ACT_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					if (Valida_Rangos())
					{
						Actualiza_Rangos();
					} else
					{
						return;
					}
					
					ID_CRE_PRI_PNL.Enabled = true;
					ID_CRE_PRI1_PNL.Enabled = true;
					ID_CRE_RAN_PNL.Visible = false;
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_CRE_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_CRE_PRI_PNL.Enabled = true;
					ID_CRE_PRI1_PNL.Enabled = true;
					ID_CRE_RAN_PNL.Visible = false;
					
			}
			
			private void  ID_CRE_EMP_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_CRE_TIP_PNL.Enabled = false;
					
			}
			
			private void  ID_CRE_GRA_GPH_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					
					if (bMaximizada != 0)
					{ //Minimiza
						
						ID_CRE_IMP_PB.Visible = false;
						ID_CRE_GRA_GPH.Visible = false;
						ID_CRE_PRI1_PNL.Visible = false;
						this.Refresh();
						
						//Guardamos las Medidas Originales del Panel de la Gráfica
						ID_CRE_PRI1_PNL.Top = (int) VB6.TwipsToPixelsY(iPnlTop);
						ID_CRE_PRI1_PNL.Left = (int) VB6.TwipsToPixelsX(iPnlLeft);
						ID_CRE_PRI1_PNL.Height = (int) VB6.TwipsToPixelsY(iPnlHeight);
						ID_CRE_PRI1_PNL.Width = (int) VB6.TwipsToPixelsX(iPnlWidth);
						
						//Guardamos las Medidas Originales de la Gráfica
						ID_CRE_GRA_GPH.Top = (int) VB6.TwipsToPixelsY(iGphTop);
						ID_CRE_GRA_GPH.Left = (int) VB6.TwipsToPixelsX(iGphLeft);
						ID_CRE_GRA_GPH.Height = (int) VB6.TwipsToPixelsY(iGphHeight);
						ID_CRE_GRA_GPH.Width = (int) VB6.TwipsToPixelsX(iGphWidth);
						
						ID_CRE_IMP_PB.Top = (int) VB6.TwipsToPixelsY(iImpTop);
						ID_CRE_IMP_PB.Left = (int) VB6.TwipsToPixelsX(iImpLeft);
						
						ID_CRE_PRI1_PNL.Visible = true;
						ID_CRE_PRI_PNL.Visible = true;
						ID_CRE_TIP_PNL.Visible = true;
						ID_CRE_SAL_PB.Visible = true;
						ID_CRE_IMP_PB.Visible = true;
						ID_CRE_GRA_PB.Visible = true;
						ID_CRE_RAN_PB.Visible = true;
						this.Refresh();
						ID_CRE_GRA_GPH.Visible = true;
						bMaximizada = 0;
						
					} else
					{
						//Ocultamos todos los controles
						ID_CRE_GRA_GPH.Visible = false;
						ID_CRE_PRI1_PNL.Visible = false;
						ID_CRE_PRI_PNL.Visible = false;
						ID_CRE_TIP_PNL.Visible = false;
						ID_CRE_RAN_PB.Visible = false;
						ID_CRE_GRA_PB.Visible = false;
						ID_CRE_IMP_PB.Visible = false;
						ID_CRE_SAL_PB.Visible = false;
						this.Refresh();
						
						//Guardamos las Medidas Originales de la Gráfica
						iGphTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_CRE_GRA_GPH.Top));
						iGphLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_CRE_GRA_GPH.Left));
						iGphHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_CRE_GRA_GPH.Height));
						iGphWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_CRE_GRA_GPH.Width));
						
						//Guardamos las Medidas Originales del Panel de la Gráfica
						iPnlTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_CRE_PRI1_PNL.Top));
						iPnlLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_CRE_PRI1_PNL.Left));
						iPnlHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_CRE_PRI1_PNL.Height));
						iPnlWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_CRE_PRI1_PNL.Width));
						
						//Guardamos las Medidas Originales del Boton de Imprimir
						iImpTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_CRE_IMP_PB.Top));
						iImpLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_CRE_IMP_PB.Left));
						
						//Ajustamos las Medidas del Panel de la Gráfica
						ID_CRE_PRI1_PNL.Top = (int) ID_CRE_PRI_PNL.Top;
						ID_CRE_PRI1_PNL.Left = (int) ID_CRE_PRI_PNL.Left;
						ID_CRE_PRI1_PNL.Height = (int) (ID_CRE_PRI_PNL.Height + ID_CRE_PRI1_PNL.Height);
						ID_CRE_PRI1_PNL.Width = (int) ID_CRE_PRI_PNL.Width;
						
						//Ajustamos las Medidas de la Gráfica
						ID_CRE_GRA_GPH.Top = (int) ID_CRE_PRI1_PNL.Top;
						ID_CRE_GRA_GPH.Left = (int) ID_CRE_PRI1_PNL.Left;
						ID_CRE_GRA_GPH.Height = (int) ID_CRE_PRI1_PNL.Height;
						ID_CRE_GRA_GPH.Width = (int) ID_CRE_PRI1_PNL.Width;
						
						ID_CRE_IMP_PB.Top = (int) (ID_CRE_GRA_GPH.Height - VB6.TwipsToPixelsY(((float) VB6.PixelsToTwipsY(ID_CRE_IMP_PB.Height)) * 1.3d));
						ID_CRE_IMP_PB.Left = (int) VB6.TwipsToPixelsX(((float) VB6.PixelsToTwipsX(ID_CRE_IMP_PB.Width)) * 0.2d);
						ID_CRE_IMP_PB.BringToFront();
						this.Refresh();
						
						ID_CRE_IMP_PB.Visible = true;
						ID_CRE_GRA_GPH.Visible = true;
						ID_CRE_PRI1_PNL.Visible = true;
						bMaximizada = -1;
						
					}
					
			}
			
			private void  ID_CRE_GRA_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
                    try
                    {

                        CORVAR.bgblIrExiste = 0;
                        switch (iGrafica)
                        {
                            case 1:  //Producto por limite de Credito 
                                Carga_Ejecutivos(0);
                                ID_CRE_TIP_PNL.Enabled = true;
                                Asigna_A_Grafica();
                                break;
                            case 2:  //Empresa por limite de Credito 
                                if (ID_CRE_IRA_CHK.Value)
                                {
                                    //UPGRADE_ISSUE: (2070) Constant vbBlackness was not upgraded.
                                    CORVAR.igblAccion = 1;
                                    CORIREMP.DefInstance.Tag = "CORGRCRE";
                                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                                    CORIREMP.DefInstance.ShowDialog();
                                    pszEmpresa = CORVAR.lgblTempNumEmp.ToString();
                                    CORVAR.bgblIrExiste = -1;
                                    this.Refresh();
                                }
                                else
                                {
                                    if (ID_CRE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
                                    {
                                        pszEmpresa = ID_CRE_EMP_COB.Text.Substring(0, Math.Min(ID_CRE_EMP_COB.Text.Length, 5));
                                        CORVAR.bgblIrExiste = -1;
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("No existen empresa para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                                    }
                                }

                                if (CORVAR.bgblIrExiste == (-1))
                                {
                                    if (Conversion.Val(pszEmpresa) > CORVB.NULL_INTEGER)
                                    {
                                        CORVAR.igblCancela = -1;
                                        Carga_Ejecutivos(-1);
                                        if (CORVAR.igblCancela != 0)
                                        {
                                            Asigna_A_Grafica();
                                            ID_CRE_TIP_PNL.Enabled = true;
                                        }
                                    }
                                }
                                break;
                            case 3:  //Otorgado vs. Consumido por Producto 
                                Carga_Creditos(0);
                                ID_CRE_TIP_PNL.Enabled = true;
                                Asigna_A_Grafica();
                                break;
                            case 4:  //Otorgado vs. Consumido por Empresa 
                                if (ID_CRE_IRA_CHK.Value)
                                {
                                    CORIREMP.DefInstance.Tag = "CORGRCRE";
                                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                                    CORIREMP.DefInstance.ShowDialog();
                                    pszEmpresa = CORVAR.lgblTempNumEmp.ToString();
                                    CORVAR.bgblIrExiste = -1;
                                    this.Refresh();
                                }
                                else
                                {
                                    if (ID_CRE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
                                    {
                                        pszEmpresa = ID_CRE_EMP_COB.Text.Substring(0, Math.Min(ID_CRE_EMP_COB.Text.Length, 5));
                                        CORVAR.bgblIrExiste = -1;
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("No existen empresa para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                                    }
                                }

                                if (CORVAR.bgblIrExiste == (-1))
                                {
                                    if (Conversion.Val(pszEmpresa) > CORVB.NULL_INTEGER)
                                    {
                                        CORVAR.igblCancela = -1;
                                        Carga_Creditos(-1);
                                        if (CORVAR.igblCancela != 0)
                                        {
                                            Asigna_A_Grafica();
                                            ID_CRE_TIP_PNL.Enabled = true;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fallo operación ID_CRE_GRA_PB_Click " + exc.Message, "Error Corgrcre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
			}
			
			private void  ID_CRE_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_PRINT;
					
					this.Cursor = Cursors.Default;
					
			}
			
			
			//UPGRADE_NOTE: (7001) The following declaration (ID_CRE_MAX_FTB_InvalidData) seems to be dead code
			//private void  ID_CRE_MAX_FTB_InvalidData( int Index,  int NextWnd)
			//{
					//
					//dArrRangos[Index, 1] = Conversion.Val(ID_CRE_MAX_FTB[Index].CtlText);
					//
			//}
			
			private void  ID_CRE_MAX_FTB_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
                //AIS-1094 NGONZALEZ
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
			}
			
			private void  ID_CRE_MIN_FTB_Change( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(ID_CRE_MIN_FTB, eventSender);
					
					dArrRangos[Index, 0] = Conversion.Val(ID_CRE_MIN_FTB[Index].CtlText);
					
			}
			
			private void  ID_CRE_MIN_FTB_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
                //AIS-1094 NGONZALEZ
					if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
					{
						eventArgs.keyAscii = 0;
					}
			}
			
			private void  ID_CRE_RAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					
					this.Cursor = Cursors.WaitCursor;
					
					Carga_Rangos();
					
					for (int iCont = dArrRangos.GetLowerBound(0); iCont <= dArrRangos.GetUpperBound(0); iCont++)
					{
						if (! (dArrRangos[iCont, 0] == CORVB.NULL_INTEGER && dArrRangos[iCont, 1] == CORVB.NULL_INTEGER))
						{
							ID_CRE_MIN_FTB[iCont].CtlText = dArrRangos[iCont, 0].ToString();
							ID_CRE_MAX_FTB[iCont].CtlText = dArrRangos[iCont, 1].ToString();
						}
					}
					
					ID_CRE_RAN_PNL.Visible = true;
					ID_CRE_RAN_PNL.Enabled = true;
					//  ID_CRE_PRI_PNL.Enabled = False
					//  ID_CRE_PRI1_PNL.Enabled = False
					
					Refresh();
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_CRE_SAL_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					this.Close();
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_CRE_TIP_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_CRE_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_CRE_GRA_GPH.DrawMode was not upgraded.
					ID_CRE_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_CRE_TIP_PNL.Enabled = false;
					
					switch(ID_CRE_TIP_COB.SelectedIndex)
					{
						
						case 0 :  //Producto por Límite de Crédito 
							iGrafica = 1; 
							ID_CRE_GRA_PB.Enabled = true; 
							ID_CRE_RAN_PB.Enabled = true; 
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); 
							Habilita_Combos(0); 
							 
							break;
						case 1 :  //Empresa por Límite de Crédito 
							iGrafica = 2; 
							 
							ID_CRE_GRA_PB.Enabled = true; 
							ID_CRE_RAN_PB.Enabled = true; 
							 
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); 
							Habilita_Combos(-1); 
							if (Obten_Empresas() == (0))
							{
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox("No existen empresas en el Sistema", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
								return;
							} 
							 
							break;
						case 2 :  //Otorgado vs. Consumido por Producto 
							iGrafica = 3; 
							 
							ID_CRE_GRA_PB.Enabled = true; 
							ID_CRE_RAN_PB.Enabled = false; 
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); 
							Habilita_Combos(0); 
							 
							break;
						case 3 :  //Otorgado vs. Consumido por Empresa 
							iGrafica = 4; 
							 
							ID_CRE_GRA_PB.Enabled = true; 
							ID_CRE_RAN_PB.Enabled = false; 
							 
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); 
							Habilita_Combos(-1); 
							 
							break;
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_CRE_TIP_SSR_ClickEvent( Object eventSender,  AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
			{
					int Index = Array.IndexOf(ID_CRE_TIP_SSR, eventSender);
					
					switch(Index)
					{
						case 0 : 
							ID_CRE_GRA_GPH.GraphType = CORVB.G_BAR2D; 
							ID_CRE_GRA_GPH.GraphStyle = 0; 
							ID_CRE_GRA_GPH.GraphTitle = ID_CRE_TIP_COB.Text; 
							break;
						case 1 : 
							ID_CRE_GRA_GPH.GraphType = CORVB.G_BAR3D; 
							ID_CRE_GRA_GPH.GraphStyle = 0; 
							ID_CRE_GRA_GPH.GraphTitle = ID_CRE_TIP_COB.Text; 
							break;
						case 2 : 
							ID_CRE_GRA_GPH.GraphType = CORVB.G_PIE2D; 
							ID_CRE_GRA_GPH.GraphStyle = 4; 
							ID_CRE_GRA_GPH.GraphTitle = "Asignado vs. Utilizado"; 
							break;
						case 3 : 
							ID_CRE_GRA_GPH.GraphType = CORVB.G_PIE3D; 
							ID_CRE_GRA_GPH.GraphStyle = 4; 
							ID_CRE_GRA_GPH.GraphTitle = "Asignado vs. Utilizado"; 
							break;
					}
					
					Asigna_A_Grafica();
					
			}
			
			private void  Inicializa_Combo_Tipo()
			{
					
					ID_CRE_TIP_COB.Items.Add("Límite de Crédito por Producto");
					ID_CRE_TIP_COB.Items.Add("Límite de Crédito por Empresa");
					ID_CRE_TIP_COB.Items.Add("Asignado vs. Utilizado por Producto");
					ID_CRE_TIP_COB.Items.Add("Asignado vs. Utilizado por Empresa");
					
					ID_CRE_TIP_COB.SelectedIndex = CORVB.NULL_INTEGER;
					
			}
			
			//**                                                                        **
			//**       Descripción: Carga las empresas de un determinado grupo   -      **
			//**                    Corporativo a un ComboBox                           **
			//**                                                                        **
			//**       Declaración: Funcion Obten_Empresas() as integer                 **
			//**                                                                        **
			//**       Paso de parámetros: Ninguno                                      **
			//**                                                                        **
			//**       Valor de Regreso:                                                **
			//**           True: Si existieron empresas                                 **
			//**           False: Si no los hubo                                        **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma :                                                 **
			//**                                                                        **
			//**       Ultima modificacion:                                             **
			//**                                                                        **
			//****************************************************************************
			private int Obten_Empresas()
			{
					
					int result = 0;
					string pszEmpresa = String.Empty; //La empresa
					int lNumEmpresa = 0; //El consecutivo de la empresa
					string pszSentencia = String.Empty;
					int lEmpresas = 0;
					string pszGrupo = String.Empty;
					
					this.Cursor = Cursors.WaitCursor;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					// pszgblsql = "SELECT emp_num, emp_nom FROM " + DB_SYB_EMP + " WHERE gpo_banco=" + Format$(igblBanco) + " order by emp_num "
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "SELECT emp_num, emp_nom FROM " + CORBD.DB_SYB_EMP + " WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " AND gpo_banco=" + CORVAR.igblBanco.ToString() + " order by emp_num ";
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						ID_CRE_EMP_COB.Items.Clear();
						
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							lNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							//EISSA 03-10-2001. Cambios para formatear el número de empresa
							ID_CRE_EMP_COB.Items.Add(StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
						};
						
						
						if (ID_CRE_EMP_COB.Items.Count != 0)
						{
							ID_CRE_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
							result = -1;
						} else
						{
							result = 0;
						}
						
						this.Cursor = Cursors.Default;
						
					} else
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("Ocurrio un error al intentar obtener las Empresas. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					
					return result;
			}
			
			private bool Valida_Rangos()
			{
					
					int iRangos = 0;
					
					int bValida = -1;
					
					//Valida que los rangos sean capturados el menor del lado izquierdo y el mayor al lado derecho
					for (int iCont = dArrRangos.GetLowerBound(0); iCont <= dArrRangos.GetUpperBound(0); iCont++)
					{
						if (Conversion.Val(ID_CRE_MAX_FTB[iCont].CtlText) < Conversion.Val(ID_CRE_MIN_FTB[iCont].CtlText))
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("Alguno de los valores mínimos es mayor a su máximo correspondiente.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
							bValida = 0;
							break;
						}
					}
					
					if (bValida != 0)
					{
						iRangos = CORVB.NULL_INTEGER;
						for (int iCont = dArrRangos.GetLowerBound(0); iCont <= dArrRangos.GetUpperBound(0); iCont++)
						{
							if (dArrRangos[iCont, 0] != CORVB.NULL_INTEGER || dArrRangos[iCont, 1] != CORVB.NULL_INTEGER)
							{
								iRangos++;
							}
						}
						
						if (iRangos >= 2)
						{
							bValida = -1;
						} else
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("Los rangos definidos deberán ser más de UNO", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
							bValida = 0;
						}
					}
					
					return bValida != 0;
					
			}
			private void  CORGRCRE_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}