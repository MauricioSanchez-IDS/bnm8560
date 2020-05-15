using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.IO; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class CORRPDA1
		: System.Windows.Forms.Form
		{
		
			private void  CORRPDA1_Activated( Object eventSender,  EventArgs eventArgs)
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
			//**       Descripción: Catalogo para el reporte de atrasos concentrados    **
			//**                    por ejecutivo a la fecha de corte                       **
			//**                                                                        **
			//**       Responsable:                                                     **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			int hConexion = 0;
			
			//UPGRADE_NOTE: (7001) The following declaration (Envia_Error) seems to be dead code
			//private void  Envia_Error( int hStmt)
			//{
					//
					//CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
					//this.Cursor = Cursors.Default;
					////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
					////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
					////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
					//Interaction.MsgBox("Error de Lectura en la Base de Datos. Consulte a su Administrador del Sistema y Vuelva a Intentar", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
					//AIS-1182 NGONZALEZ
					//CORVAR.igblErr = API.USER.PostMessage(CORRPDA1.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
					//
			//}
			
			private void  CORRPDA1_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
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
					
					int iError = 0;
					int hEjeEmp = 0;
					int iCorCve = 0;
					string pszCorDesc = String.Empty;
					string pszEmpDesc = String.Empty;
					int iValor = 0;
					int iCorte = 0;
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					
					this.Show();
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					//Limpia el ListBox y los Combo Box
					ID_DA1_EMP_LB.Items.Clear();
					ID_DA1_MES_COB.Items.Clear();
					ID_DA1_GRU_COB.Items.Clear();
					
					this.Cursor = Cursors.WaitCursor;
					
					//Obtiene los Campos de la tabla de Ejecutivos Banamex
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco = " + Format(igblBanco) + " order by gpo_num"
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " order by gpo_num";
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					if (CORPROC2.Obtiene_Registros() != 0)
					{ //Ocurrio algun error en la ejecución SQL
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							iCorCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							pszCorDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							ID_DA1_GRU_COB.Items.Add(StringsHelper.Format(iCorCve, "0000") + CORCONST.SPC_TRES + pszCorDesc.Trim());
						};
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query
						
						ComboBox tempRefParam = ID_DA1_MES_COB;
						CORPROC.Obten_Meses(this, ref tempRefParam);
						ID_DA1_MES_COB = tempRefParam;
						
						//Posiciona en el Primer Elemento del ComboBox de Grupos
						if (ID_DA1_GRU_COB.Items.Count > CORVB.NULL_INTEGER)
						{
							ID_DA1_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
							
							//Posiciona en el Primer Elemento del ComboBox de Empresas
							if (ID_DA1_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
							{
								ID_DA1_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
							}
						}
					} else
					{
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query
					}
					
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_DA1_ALT_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							int lEmpresas = 0;
							
							this.Cursor = Cursors.WaitCursor;
							if (ID_DA1_MES_COB.Items.Count > 0)
							{
								CORVAR.igblMesDiaACG = VB6.GetItemData(ID_DA1_MES_COB, ID_DA1_MES_COB.SelectedIndex);
								CORVAR.igblAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_DA1_MES_COB.Text.Trim(), (ID_DA1_MES_COB.Text.Trim().IndexOf(' ') + 1) + 1)));
							}
							
							if (ID_DA1_IRA_CKB.Value)
							{
								CORMDIBN.DefInstance.Enabled = false;
								CORIREMP.DefInstance.Tag = "CORRPDAT";
								CORIREMP.DefInstance.Show();
							} else
							{
								if (ID_DA1_EMP_LB.Items.Count != 0)
								{
									CORVAR.lgblNumEmpresaR = Convert.ToInt32(Conversion.Val(ID_DA1_EMP_LB.Text.Substring(0, Math.Min(ID_DA1_EMP_LB.Text.Length, 5))));
									CORVAR.lgblGpoCve = Convert.ToInt32(Conversion.Val(ID_DA1_GRU_COB.Text.Substring(0, Math.Min(ID_DA1_GRU_COB.Text.Length, 4))));
									CORRPDAT.DefInstance.Show();
                                    if (CORRPDAT.DefInstance.flag)
                                        CORRPDAT.DefInstance.Close();

								}
							}
							
							//las siguientes lineas arman el nombre del archivo cuando se dese guardarlo en algún formato.
							CORVAR.gblPathArchivo = CORVAR.pszgblPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + Conversion.Str(CORVAR.lgblNumEmpresaR).Trim();
							
							if (FileSystem.Dir(CORVAR.gblPathArchivo, FileAttribute.Directory) == CORVB.NULL_STRING)
							{
								Directory.CreateDirectory(CORVAR.gblPathArchivo);
							}
							
							CORVAR.gblPathArchivo = CORVAR.gblPathArchivo + "\\" + Conversion.Str(CORVAR.igblAñoCorte).Trim() + Strings.Mid(StringsHelper.Format(CORVAR.igblMesCorte, "0000"), 1, 2).Trim() + "DA";
							
							
							this.Cursor = Cursors.Default;
						}
					catch (Exception exc)
					{
                        CRSGeneral.prObtenError(this.GetType().Name + "(ID_DA1_ALT_PB_Click)", exc);
						//throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			private void  ID_DA1_CER_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					this.Close();
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_DA1_GRU_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					int hEjeEmp = 0;
					int iError = 0;
					string pszEmpDesc = String.Empty;
					int iValor = 0;
					int iCorCve = 0;
					int iContador = 0;
					int lEmpCve = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_DA1_EMP_LB.Items.Clear(); //Limpiamos el List Box
					
					int iCorNum = Convert.ToInt32(Conversion.Val(ID_DA1_GRU_COB.Text.Substring(0, Math.Min(ID_DA1_GRU_COB.Text.Length, 4))));
					
					
					//Obtiene los Campos de la tabla de Ejecutivos Banamex
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_num = " + Format$(iCorNum) + " and gpo_banco =" + Format$(igblBanco) + " order by emp_num"
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_num = " + iCorNum.ToString() + " and gpo_banco =" + CORVAR.igblBanco.ToString() + " order by emp_num";
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{ //Ocurrio algun error en la ejecución SQL
						
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							lEmpCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							
							//***** Código Anterior     ***********
							//      ID_DA1_EMP_LB.AddItem (Format(lEmpCve, "00000") + SPC_TRES + Trim$(pszEmpDesc))
							//***** Fin Código Anterior ***********
							//EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
							ID_DA1_EMP_LB.Items.Add(StringsHelper.Format(lEmpCve, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
							//EISSA 05.10.2001 FIN
							
						};
						if (ID_DA1_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
						{
							ID_DA1_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
						}
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					
					this.Cursor = Cursors.Default;
					
			}
			private void  CORRPDA1_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}