using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORCTREN
		: System.Windows.Forms.Form
		{
		
			private void  CORCTREN_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			int iErr = 0;
			int iTop = 0;
			int iLeft = 0;
			
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción:                                                     **
			//**                   Valida el rango de fechas seleccionadas              **
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
			
			private bool Valida_Fechas()
			{
					//valida fechas
					
					bool result = false;
					
					if (optPeriodo[0].Checked)
					{
						if (CORVAR.gbllAñoCorteFin < CORVAR.igblAñoCorte)
						{
							MessageBox.Show(" La fecha fin no puede ser menor a la fecha de inicio", Application.ProductName);
							return true;
						} else if (CORVAR.gbllAñoCorteFin == CORVAR.igblAñoCorte) { 
							if (CORVAR.gbllAñoMesFin < CORVAR.gbllAñoMesIni)
							{
								MessageBox.Show(" La fecha fin no puede ser menor a la fecha de inicio", Application.ProductName);
								return true;
							}
						}
						
					}
					
					return result;
			}
			
			private void  cmdAdd_Click( Object eventSender,  EventArgs eventArgs)
			{
					//Pasa un Intermediario
					if (ListBoxHelper.GetSelectedIndex(lstEmpresas) >= CORVB.NULL_INTEGER)
					{
						lstSeleccion.Items.Add(VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)));
						lstEmpresas.Items.RemoveAt((short) ListBoxHelper.GetSelectedIndex(lstEmpresas));
					} else
					{
						Interaction.Beep();
					}
					
					if ((optEmpresas[3].Checked || optEmpresas[4].Checked || optEmpresas[5].Checked) && lstSeleccion.Items.Count > 0)
					{
						
						cmdAdd.Enabled = false;
					} else
					{
						cmdAdd.Enabled = true;
					}
					
			}
			
			private void  cmdAll_Click( Object eventSender,  EventArgs eventArgs)
			{
					//Pasa todos los Intermediarios
					while ((lstEmpresas.Items.Count > CORVB.NULL_INTEGER))
						{
						
							//verifica que no existean en la lista de seleccion
							
							lstEmpresas.SelectedIndex = CORVB.NULL_INTEGER;
							lstSeleccion.Items.Add(VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)));
							lstEmpresas.Items.RemoveAt((short) ListBoxHelper.GetSelectedIndex(lstEmpresas));
						}
					
					//si es por grupo
					cboGrupo.Enabled = ! optEmpresas[2].Checked;
					
					
			}
			
			private void  cmdDel_Click( Object eventSender,  EventArgs eventArgs)
			{
					//Regresa un Intermediario
					if (ListBoxHelper.GetSelectedIndex(lstSeleccion) >= CORVB.NULL_INTEGER)
					{
						//      lstEmpresas.AddItem lstSeleccion.List(lstSeleccion.ListIndex)
						lstSeleccion.Items.RemoveAt((short) ListBoxHelper.GetSelectedIndex(lstSeleccion));
						
						Obten_Empresas();
					} else
					{
						Interaction.Beep();
					}
					
					if (optEmpresas[3].Checked || optEmpresas[4].Checked || optEmpresas[5].Checked)
					{
						cmdAdd.Enabled = true;
					}
					
					
			}
			
			private void  cmdDelAll_Click( Object eventSender,  EventArgs eventArgs)
			{
					//Pasa todos los Intermediarios
					while ((lstSeleccion.Items.Count > CORVB.NULL_INTEGER))
						{
						
							lstSeleccion.SelectedIndex = CORVB.NULL_INTEGER;
							lstEmpresas.Items.Add(VB6.GetItemString(lstSeleccion, ListBoxHelper.GetSelectedIndex(lstSeleccion)));
							lstSeleccion.Items.RemoveAt((short) ListBoxHelper.GetSelectedIndex(lstSeleccion));
						}
					
					//si es por grupo
					if (optEmpresas[2].Checked)
					{
						cboGrupo.Enabled = true;
					}
					
					if (optEmpresas[3].Checked || optEmpresas[4].Checked || optEmpresas[5].Checked)
					{
						cmdAdd.Enabled = true;
					}
					
					Obten_Empresas();
			}
			
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					int iGrupos = 0;
					
					iErr = CORCONST.OK;

                    this.Left = (CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2;
                    this.Top = (CORMDIBN.DefInstance.ClientRectangle.Height -
                        CORMDIBN.DefInstance.ID_COR_BHER.Height -
                        CORMDIBN.DefInstance.ID_COR_BEDO.Height - this.Height) / 2;

					
					//this.SetBounds(Convert.ToInt32((float) VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float) VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
					this.Show();
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORSTR.STR_LEE_BD;
					
					
					
					//  Me.Move (CORMDIBN.ScaleWidth - Width) / 2, (CORMDIBN.ScaleHeight - Height) / 2
					//Llena el combo box con los meses disponibles en El Histórico
					
					ComboBox tempRefParam = cboFecha;
					CORPROC.Obten_Meses(this, ref tempRefParam);
					cboFecha = tempRefParam;
					ComboBox tempRefParam2 = cboFechaFin;
					CORPROC.Obten_Meses(this, ref tempRefParam2);
					cboFechaFin = tempRefParam2;
					
					//inabilita los siguinees controles
					lblPeriodo[1].Visible = false;
					cboFechaFin.Visible = false;
					lblPeriodo[0].Text = "Fecha";
					optPeriodo[0].Enabled = false;
					
					//obtiene el grupop y la empresa
					do 
					{
						iGrupos = Carga_Grupos();
						if (iErr == CORCONST.OK)
						{
							if (cboGrupo.Items.Count == CORVB.NULL_INTEGER)
							{
								this.Cursor = Cursors.Default;
								MessageBox.Show("No existen Grupos en catálogo ", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
								this.Cursor = Cursors.WaitCursor;
								break;
							}
						} else
						{
							//AIS-1182 NGONZALEZ
							//iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                            flag = true;
                            break;
						}
					}
					while((cboGrupo.Items.Count | ((iErr != CORCONST.OK) ? -1: 0)) == 0);
					
					//si la opción es para todas las empresas se inhabilita el con¿mbox de grupo y empresa
					if (optEmpresas[0].Checked)
					{
						cboGrupo.Enabled = false;
						lstEmpresas.Enabled = false;
					}
					
					optEmpresas_CheckedChanged(optEmpresas[0], new EventArgs());
					
			}
        public bool flag = false;
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga los Grupos corporativos existentes en el      **
			//**                    Catálogo de Grupos (CMTCOR01) a un Combo Box -      **
			//**                    y que posteriormente sirve para seleccionar  a      **
			//**                    las empresas del Grupo correspondiente              **
			//**                                                                        **
			//**                                                                        **
			//**       Paso de parámetros: Ninguno                                      **
			//**                                                                        **
			//**       Valor de Regreso: El número de registros leídos                  **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 26nov98                                      **
			//**                                                                        **
			//****************************************************************************
			private int Carga_Grupos()
			{
					
					string pszNomGrupo = String.Empty; //El grupo a obtener
					int iNumGrupo = 0; //El consecutivo del grupo
					int iTempErr = 0; //Para control local
					int iCont = 0;
					
					this.Cursor = Cursors.WaitCursor;
					iErr = CORCONST.OK;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//
					//  pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco=" + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
					//***** FIN  CODIGO NUEVO  FSWBMX *****
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						cboGrupo.Items.Clear();
						iCont = CORVB.NULL_INTEGER;
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							cboGrupo.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
							iCont++;
						};
						//Colocamos a un grupo por default
						if (cboGrupo.Items.Count != 0)
						{
							cboGrupo.SelectedIndex = CORVB.NULL_INTEGER;
						}
					} else
					{
						this.Cursor = Cursors.Default;
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					
					this.Cursor = Cursors.Default;
					
					return 0;
			}
			
			
			private void  cmdCalcular_Click( Object eventSender,  EventArgs eventArgs)
			{
					string pszMsg = String.Empty;
					int lEmpresa = 0;
					int lGrupo = 0;
					
					string pszMesCorte = CORVB.NULL_STRING;
					int iMesCorte = CORVB.NULL_INTEGER;
					
					//verifica el tipo de rentabiliodad
					if (optEmpresas[0].Checked)
					{
						this.Tag = "Todas";
					} else if (optEmpresas[1].Checked) { 
						this.Tag = "Seleccion";
					} else if (optEmpresas[2].Checked) { 
						this.Tag = "Tope";
						if (Conversion.Val(txtMaxima.Text) == CORVB.NULL_INTEGER)
						{
							MessageBox.Show("Capture el valor máximo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
							txtMaxima.Focus();
							return;
						}
					} else if (optEmpresas[3].Checked) { 
						this.Tag = "Una";
					} else if (optEmpresas[4].Checked) { 
						this.Tag = "Detalle";
					} else if (optEmpresas[5].Checked) { 
						this.Tag = "Detalle_Rango";
					}
					
					//obtiene la fecha de rentabilidad
					CORVAR.igblAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(cboFecha.Text.Trim(), (cboFecha.Text.Trim().IndexOf(' ') + 1) + 1)));
					pszMesCorte = Strings.Mid(cboFecha.Text.Trim(), 1, cboFecha.Text.Trim().IndexOf(' ') + 1);
					iMesCorte = CORPROC2.Obtiene_Mes_Numerico(pszMesCorte);
					CORVAR.gbllAñoMesIni = Convert.ToInt32(Conversion.Val(Conversion.Str(CORVAR.igblAñoCorte) + StringsHelper.Format(Conversion.Str(iMesCorte), "00")));
					
					if (optPeriodo[0].Checked)
					{ //rango de fechas
						pszMesCorte = Strings.Mid(cboFechaFin.Text.Trim(), 1, cboFechaFin.Text.Trim().IndexOf(' ') + 1);
						iMesCorte = CORPROC2.Obtiene_Mes_Numerico(pszMesCorte);
						CORVAR.gbllAñoCorteFin = Convert.ToInt32(Conversion.Val(Strings.Mid(cboFechaFin.Text.Trim(), (cboFechaFin.Text.Trim().IndexOf(' ') + 1) + 1)));
						CORVAR.gbllAñoMesFin = Convert.ToInt32(Conversion.Val(Conversion.Str(CORVAR.gbllAñoCorteFin) + StringsHelper.Format(Conversion.Str(iMesCorte), "00")));
					} else
					{
						//una fecha
						CORVAR.gbllAñoMesFin = CORVB.NULL_INTEGER;
						CORVAR.gbllAñoCorteFin = CORVB.NULL_INTEGER;
					}
					
					if (Valida_Fechas())
					{
						return;
					}
					
					//todas las empresas y tope maximo
					if (optEmpresas[0].Checked || optEmpresas[2].Checked)
					{
					//AIS-1199 NGONZALEZ
                        this.Cursor = Cursors.WaitCursor;
                        this.Parent.Cursor = Cursors.WaitCursor;
						CORMNREN.DefInstance.ShowDialog(this);
                        this.Cursor = Cursors.Default;
                        this.Parent.Cursor = Cursors.Default;
						//VB6.ShowForm(CORMNREN.DefInstance, (int) CORVB.MODAL, this);
					} else
					{
						if (lstSeleccion.Items.Count > CORVB.NULL_INTEGER)
						{
						 //AIS-1199 NGONZALEZ
							//VB6.ShowForm(CORMNREN.DefInstance, (int) CORVB.MODAL, this);
							CORMNREN.DefInstance.ShowDialog(this);
						} else
						{
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("Seleccione la Empresa a consultar", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
						}
					}
					
			}
			
			
			
			private void  lstEmpresas_DoubleClick( Object eventSender,  EventArgs eventArgs)
			{
					
					if (optEmpresas[0].Checked || optEmpresas[1].Checked || optEmpresas[2].Checked)
					{
						cmdAdd_Click(cmdAdd, new EventArgs());
					}
					
			}
			
			
			private void  lstSeleccion_DoubleClick( Object eventSender,  EventArgs eventArgs)
			{
					cmdDel_Click(cmdDel, new EventArgs());
			}
			
			
			private bool isInitializingComponent;
			private void  optEmpresas_CheckedChanged( Object eventSender,  EventArgs eventArgs)
			{
					if (isInitializingComponent)
					{
						return;
					}
					if (((RadioButton) eventSender).Checked)
					{
						
						// todas las empresas
						if (optEmpresas[0].Checked)
						{ //todas las empresa
							cmdAdd.Enabled = false;
							cmdDel.Enabled = false;
							cmdDelAll.Enabled = false;
							cmdAll.Enabled = false;
							cboGrupo.Enabled = false;
							lstEmpresas.Enabled = false;
							lstSeleccion.Enabled = false;
							optPeriodo[0].Enabled = false;
							optPeriodo[1].Enabled = true;
							optPeriodo[1].Checked = true;
							optPeriodo_CheckedChanged(optPeriodo[1], new EventArgs());
							txtMaxima.Visible = false;
							lstSeleccion.Items.Clear();
							Obten_Empresas();
						}
						
						//empresas
						if (optEmpresas[1].Checked)
						{
							cmdAdd.Enabled = true;
							cmdDel.Enabled = true;
							cmdAll.Enabled = true;
							cmdDelAll.Enabled = true;
							cboGrupo.Enabled = true;
							lstEmpresas.Enabled = true;
							lstSeleccion.Enabled = true;
							optPeriodo[0].Enabled = false;
							optPeriodo[1].Enabled = true;
							optPeriodo[1].Checked = true;
							optPeriodo_CheckedChanged(optPeriodo[1], new EventArgs());
							txtMaxima.Visible = false;
							lstSeleccion.Items.Clear();
							Obten_Empresas();
						}
						
						//por tope
						if (optEmpresas[2].Checked)
						{
							cmdAdd.Enabled = false;
							cmdDel.Enabled = false;
							cmdAll.Enabled = false;
							cmdDelAll.Enabled = false;
							cboGrupo.Enabled = false;
							lstEmpresas.Enabled = false;
							lstSeleccion.Enabled = false;
							optPeriodo[0].Enabled = false;
							optPeriodo[1].Enabled = true;
							optPeriodo[1].Checked = true;
							optPeriodo_CheckedChanged(optPeriodo[1], new EventArgs());
							txtMaxima.Visible = true;
							lstSeleccion.Items.Clear();
							Obten_Empresas();
							txtMaxima.Focus();
						}
						
						//por una empresa o detalle a un rango
						if (optEmpresas[3].Checked || optEmpresas[5].Checked)
						{
							cmdAdd.Enabled = true;
							cmdDel.Enabled = true;
							cmdAll.Enabled = false;
							cboGrupo.Enabled = true;
							lstEmpresas.Enabled = true;
							lstSeleccion.Enabled = true;
							optPeriodo[1].Enabled = false;
							optPeriodo[0].Enabled = true;
							optPeriodo[0].Checked = true;
							optPeriodo[1].Checked = false;
							optPeriodo_CheckedChanged(optPeriodo[1], new EventArgs());
							txtMaxima.Visible = false;
							lstSeleccion.Items.Clear();
							Obten_Empresas();
						}
						
						//o detalle a un fecha
						if (optEmpresas[4].Checked)
						{
							cmdAdd.Enabled = true;
							cmdDel.Enabled = true;
							cmdAll.Enabled = false;
							cboGrupo.Enabled = true;
							lstEmpresas.Enabled = true;
							lstSeleccion.Enabled = true;
							optPeriodo[0].Enabled = false;
							optPeriodo[1].Enabled = true;
							optPeriodo[1].Checked = true;
							optPeriodo[0].Checked = false;
							optPeriodo_CheckedChanged(optPeriodo[1], new EventArgs());
							txtMaxima.Visible = false;
							lstSeleccion.Items.Clear();
							Obten_Empresas();
						}
						
						
						
						
						
					}
			}
			
			private void  cboGrupo_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					int lEmpresas = Obten_Empresas(); //Obtiene las empresas del Grupo
					if (iErr != CORCONST.OK)
					{
						//AIS-1182 NGONZALEZ
						iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        flag = true;
                    }
			}
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga las empresas de un determinado grupo   -      **
			//**                    Corporativo a un ListBox                            **
			//**                                                                        **
			//**                                                                        **
			//**       Paso de parámetros: Ninguno                                      **
			//**                                                                        **
			//**       Valor de Regreso:                                                **
			//**           True: Si existieron empresas                                 **
			//**           False: Si no los hubo                                        **
			//**                                                                        **
			//**                                                                        **
			//**       Ultima modificacion: 26nov98                                     **
			//**                                                                        **
			//****************************************************************************
			private int Obten_Empresas()
			{
					
					int result = 0;
					int iTempErr = 0; //Control local
					string pszEmpresa = String.Empty; //La empresa a obtener
					int iNumEmpresa = 0; //El consecutivo de la empresa
					int iCont = 0;
					
					this.Cursor = Cursors.WaitCursor;
					iErr = CORCONST.OK;
					int iNumGrupo = Convert.ToInt32(Conversion.Val(cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 4)))); //El grupo de quien se trata
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_banco=" + Format$(igblBanco) + " and gpo_num =" + Format$(iNumGrupo)
					//***** INICIO CODIGO NUEVO  FSWBMX *****
					CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + iNumGrupo.ToString();
					//***** FIN  CODIGO NUEVO FSWBMX *****
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						lstEmpresas.Items.Clear();
						iCont = CORVB.NULL_INTEGER;
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							iNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							//EISSA 03-10-2001. Cambio para modificar número de empresa.
							lstEmpresas.Items.Add(StringsHelper.Format(iNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
							iCont++;
						};
						
						if (lstEmpresas.Items.Count != 0)
						{
							lstEmpresas.SelectedIndex = CORVB.NULL_INTEGER;
							result = -1;
						} else
						{
							result = 0;
						}
					} else
					{
						//si no obtiene empresas limpia el control
						lstEmpresas.Items.Clear();
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					
					this.Cursor = Cursors.Default;
					
					return result;
			}
			
			
			
			
			private void  cmdSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			
			private void  optPeriodo_CheckedChanged( Object eventSender,  EventArgs eventArgs)
			{
					if (isInitializingComponent)
					{
						return;
					}
					if (((RadioButton) eventSender).Checked)
					{
						
						
						
						if (optPeriodo[1].Checked)
						{
							lblPeriodo[1].Visible = false;
							cboFechaFin.Visible = false;
							lblPeriodo[0].Text = "Fecha";
						} else
						{
							lblPeriodo[1].Visible = true;
							cboFechaFin.Visible = true;
							lblPeriodo[0].Text = "Fecha Inicio";
						}
						
						if (optEmpresas[2].Checked)
						{
							lblPeriodo[1].Visible = true;
							lblPeriodo[1].Text = "Valor Máximo";
						} else
						{
							lblPeriodo[1].Text = "Fecha Fin";
						}
						
					}
			}
			
			
			private void  txtMaxima_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
                    if (KeyAscii == 13)
                    {
                        cmdCalcular.PerformClick();
                        return;
                    }
					if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
					{
						//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
						KeyAscii = CORVB.NULL_INTEGER;
					}
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			private void  CORCTREN_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}