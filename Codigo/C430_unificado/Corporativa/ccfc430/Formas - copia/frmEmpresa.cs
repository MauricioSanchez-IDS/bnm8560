using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.ComponentModel; 
using System.IO; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
	internal partial class frmEmpresa
		: System.Windows.Forms.Form
		{
		
			//*****************************************************************************
			//**                                                                         **
			//**                     EISSA / Banamex - Sistemas                          **
			//**                                                                         **
			//**       -----------------------------------------------------------       **
			//**                                                                         **
			//**       Descripción: Realiza las Altas de las Empresas o en su ca -       **
			//**                    so, de los Ejecutivos Banamex (Llama a la for-       **
			//**                    ma)                                                  **
			//**                                                                         **
			//**       Responsable: Jaime Paz Uribe                                      **
			//**                                                                         **
			//**       Fecha de Modificación:                                            **
			//**                                                                         **
			//**             NOTA: Esta forma esta hecha en Visual Basic 6.0             **
			//**                                                                         **
			//*****************************************************************************
			
			private Conecta.ConexionesHost _cnhConComDrive = null;
			Conecta.ConexionesHost cnhConComDrive
			{
				get
				{
					if (_cnhConComDrive == null)
					{
						_cnhConComDrive = new Conecta.ConexionesHost();
					}
					return _cnhConComDrive;
				}
				set
				{
					_cnhConComDrive = value;
				}
			}
			    
			/*private OLERut.Conexion _cnxConexionRut = null;
			OLERut.Conexion cnxConexionRut
			{
				get
				{
					if (_cnxConexionRut == null)
					{
						_cnxConexionRut = new OLERut.Conexion();
					}
					return _cnxConexionRut;
				}
				set
				{
					_cnxConexionRut = value;
				}
			}*/
			
			
			clsCliente lcteCliente = null;
			clsDatosEmpresa ldteEmpresa = null;
			clsDialogo mdlgDialogo = null;
			
			//Private Function fncExcepcionCreditoB() As Boolean
			//   'EISSA 01.09.2004 - Cambio para realizar una excepción de un BIN
			//    If (gprdProducto.PrefijoL = 4943 And gprdProducto.BancoL = 88) Or (gprdProducto.PrefijoL = 4859 And gprdProducto.BancoL = 42) Then
			//        fncExcepcionCreditoB = True
			//    Else
			//        fncExcepcionCreditoB = False
			//    End If
			//
			//End Function
			
			private void  chkEmpresa_CheckStateChanged( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(chkEmpresa, eventSender);
					
					switch(Index)
					{
						case 0 :  //Skip Payment 
							ldteEmpresa.EmpSkipPaymentI = (int) chkEmpresa[Index].CheckState; 
							 
							break;
						case 1 :  //Estado de Cuenta al Corte SBF (Por corte) 
							if (chkEmpresa[Index].CheckState == CheckState.Checked)
							{
								if (mdlEmpresa.fncCuentaUnidadesI(mdlParametros.lgNumEmpresa) >= 1)
								{
									MessageBox.Show("No puede activar esta opción de SBF, porque esta empresa no tiene unidades asociadas." + "\r\n" + "Para generar SBF es necesario agregarle unidades a esta empresa.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									chkEmpresa[Index].CheckState = CheckState.Unchecked;
									chkEmpresa[2].Enabled = false;
									chkEmpresa[2].CheckState = CheckState.Unchecked;
								} else
								{
									chkEmpresa[2].Enabled = true;
									chkEmpresa[2].CheckState = CheckState.Unchecked;
									ldteEmpresa.EmpGenSbfI = mdlEmpresa.fncEstatusSBFI();
								}
							} 
							break;
						case 2 :  //Estado de Cuenta al Corte SBF (Diario) 
							if (chkEmpresa[Index].CheckState == CheckState.Checked)
							{
								if (chkEmpresa[0].CheckState == CheckState.Unchecked)
								{
									MessageBox.Show("No puede activar esta opción de SBF (Diario) porque no está activada la opción de Generar SBF(Por Corte)." + "\r\n" + "Para generar SBF Diario es necesario necesario activar la opción de Generar SBF (Por Corte).", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									chkEmpresa[Index].CheckState = CheckState.Unchecked;
									ldteEmpresa.EmpGenSbfI = mdlEmpresa.fncEstatusSBFI();
								} else
								{
									ldteEmpresa.EmpGenSbfI = mdlEmpresa.fncEstatusSBFI();
								}
							} 
							 
							break;
						case 3 :  //Estado de Cuenta al Corte SBF (Detalle de Movimientos) 
							if (chkEmpresa[Index].CheckState == CheckState.Checked)
							{
								if (mdlEmpresa.fncCuentaUnidadesI(mdlParametros.lgNumEmpresa) >= 1)
								{
									MessageBox.Show("No puede activar esta opción de Generador de Detalle de Movimientos, debido a que esta empresa no tiene unidades asociadas." + "\r\n" + "Para generar el derivado de movimientos es necesario agregarle unidades a esta empresa.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									chkEmpresa[Index].CheckState = CheckState.Unchecked;
								} else
								{
									ldteEmpresa.EmpGenSbfI = mdlEmpresa.fncEstatusSBFI();
								}
							} 
							break;
					}
					
			}
			
			private void  cmbEmpresa_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(cmbEmpresa, eventSender);
					
					switch(Index)
					{
						case 0 :  //Sector 
							ldteEmpresa.EmpSectorI = StringsHelper.IntValue(cmbEmpresa[Index].Text.Substring(0, Math.Min(cmbEmpresa[Index].Text.Length, 2))); 
							 
							break;
						case 3 :  //Ejecutivo Banamex (Nomina y Nombre) 
							ldteEmpresa.EmpEjecutivoBanamexEJX = mdlEmpresa.fncBuscaEjecutivoEmpresaEJX(Convert.ToInt32(Conversion.Val(cmbEmpresa[Index].Text.Substring(0, Math.Min(cmbEmpresa[Index].Text.Length, 7))))); 
							 
							break;
						case 4 :  //Mes Fiscal 
							if (cmbEmpresa[Index].SelectedIndex > -1)
							{
								ldteEmpresa.EmpMesFiscalI = VB6.GetItemData(cmbEmpresa[Index], cmbEmpresa[Index].SelectedIndex);
							} else
							{
								cmbEmpresa[Index].SelectedIndex = 0;
								ldteEmpresa.EmpMesFiscalI = VB6.GetItemData(cmbEmpresa[Index], cmbEmpresa[Index].SelectedIndex);
							} 
							 
							break;
						case 5 :  //Estructura de Gastos 
							if (cmbEmpresa[Index].SelectedIndex >= 0)
							{
								ldteEmpresa.EmpEstructGastosL = VB6.GetItemData(cmbEmpresa[Index], cmbEmpresa[Index].SelectedIndex);
							} else
							{
								ldteEmpresa.EmpEstructGastosL = 0;
							} 
							break;
					}
					
			}
			
			private void  cmbEmpresa_Validating( Object eventSender,  CancelEventArgs eventArgs)
			{
					bool Cancel = eventArgs.Cancel;
					int Index = Array.IndexOf(cmbEmpresa, eventSender);
					int ilIndice = 0;
					
					switch(Index)
					{
						case 1 :  //Domicilio Fiscal (Estado) 
							if (cmbEmpresa[Index].SelectedIndex < 0)
							{
								MessageBox.Show("Seleccione un estado para continuar.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								Cancel = true;
							} else
							{
								ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(cmbEmpresa[Index].Text.Trim());
								ldteEmpresa.EmpDomFiscalDMC.EstadoEST = mdlParametros.gcestEstado[ilIndice];
							} 
							 
							break;
						case 2 :  //Domicilio Envio (Estado) 
							if (cmbEmpresa[Index].SelectedIndex < 0)
							{
								MessageBox.Show("Seleccione un estado para continuar.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								Cancel = true;
							} else
							{
								ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(cmbEmpresa[Index].Text.Trim());
								ldteEmpresa.EmpDomEnvioDMC.EstadoEST = mdlParametros.gcestEstado[ilIndice];
							} 
							 
							break;
						case 3 :  //Ejecutivo Banamex (Nomina y Nombre) 
							ldteEmpresa.EmpEjecutivoBanamexEJX = mdlEmpresa.fncBuscaEjecutivoEmpresaEJX(Convert.ToInt32(Conversion.Val(cmbEmpresa[Index].Text.Substring(0, Math.Min(cmbEmpresa[Index].Text.Length, 7))))); 
							 
							break;
					}
					
					eventArgs.Cancel = Cancel;
			}
			
			private void  cmdEmpresa_Click( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(cmdEmpresa, eventSender);
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							switch(Index)
							{
								case 0 :  //Aceptar 
									//mdlgDialogo.prGeneraDlg ldteEmpresa, talEmpresaS016 
									 
									break;
								case 1 :  //Cancelar 
									this.Cursor = Cursors.WaitCursor; 
									File.Delete(mdlParametros.sgPathFirmas + "firma1.pcx"); 
									File.Delete(mdlParametros.sgPathFirmas + "firma2.pcx"); 
									File.Delete(mdlParametros.sgPathFirmas + "firma3.pcx"); 
									this.Close(); 
									this.Cursor = Cursors.Default; 
									break;
								case 2 :  //Imprimir 
									mdlEmpresa.prImprimirEmpresa(ldteEmpresa); 
									 
									break;
								case 3 :  //Borrar Representante 
									if (optEmpresa[0].Checked)
									{
										ldteEmpresa.EmpRep1RPR.NombreS = "";
										ldteEmpresa.EmpRep1RPR.PuestoS = "";
										ldteEmpresa.EmpRep1RPR.TelefonoS = "";
										ldteEmpresa.EmpRep1RPR.ExtensionS = "";
										ldteEmpresa.EmpRep1RPR.FaxS = "";
										ldteEmpresa.EmpRep1RPR.FirmaB = false;
										mdlEmpresa.prLimpiaRepresentanteEmp();
										File.Delete(mdlParametros.sgPathFirmas + "firma1.pcx");
										return;
									} else if (optEmpresa[1].Checked) { 
										ldteEmpresa.EmpRep2RPR.NombreS = "";
										ldteEmpresa.EmpRep2RPR.PuestoS = "";
										ldteEmpresa.EmpRep2RPR.TelefonoS = "";
										ldteEmpresa.EmpRep2RPR.ExtensionS = "";
										ldteEmpresa.EmpRep2RPR.FaxS = "";
										ldteEmpresa.EmpRep2RPR.FirmaB = false;
										mdlEmpresa.prLimpiaRepresentanteEmp();
										File.Delete(mdlParametros.sgPathFirmas + "firma2.pcx");
										return;
									} else if (optEmpresa[2].Checked) { 
										ldteEmpresa.EmpRep3RPR.NombreS = "";
										ldteEmpresa.EmpRep3RPR.PuestoS = "";
										ldteEmpresa.EmpRep3RPR.TelefonoS = "";
										ldteEmpresa.EmpRep3RPR.ExtensionS = "";
										ldteEmpresa.EmpRep3RPR.FaxS = "";
										ldteEmpresa.EmpRep3RPR.FirmaB = false;
										mdlEmpresa.prLimpiaRepresentanteEmp();
										File.Delete(mdlParametros.sgPathFirmas + "firma3.pcx");
										return;
									} 
									 
									break;
								case 4 :  //Capturar Firmas 
									if ((ldteEmpresa.EmpRep1RPR.NombreS.Trim() != "" && ldteEmpresa.EmpRep1RPR.PuestoS.Trim() != "") || (ldteEmpresa.EmpRep2RPR.NombreS.Trim() != "" && ldteEmpresa.EmpRep2RPR.PuestoS.Trim() != "") || (ldteEmpresa.EmpRep3RPR.NombreS.Trim() != "" && ldteEmpresa.EmpRep3RPR.PuestoS.Trim() != ""))
									{
										mdlParametros.bgModFirma = false;
										switch(this.Tag.ToString())
										{
											case "Alta" : 
												mdlParametros.bgCancela = true; 
												//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
												CORREGFI.DefInstance.ShowDialog(); 
												break;
										}
									} else
									{
										MessageBox.Show("No se han capturado los datos de los representantes.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
										return;
									} 
									 
									break;
								case 5 :  //Buscar Ejecutivo Banamex 
									ldteEmpresa.EmpEjecutivoBanamexEJX = mdlEmpresa.fncBuscaEjecutivoEmpresaEJX(Convert.ToInt32(Conversion.Val(txtEmpresa[21].Text))); 
									 
									break;
							}
						}
					catch (Exception exc)
					{
                        CRSGeneral.prObtenError(this.GetType().Name + "(cmdEmpresa_Click)", exc);
                        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			private void  frmEmpresa_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						
						int ilExisteEmpresa = 0;
						int ilExisteEjecutivo = 0;
						int ilRespuesta = 0;
						string slTempGrupo = String.Empty;
						
						//UPGRADE_TODO: (1065) Error handling statement (On Error Resume Next) could not be converted properly. A throw statement was generated instead.
						throw new Exception("Migration Exception: 'On Error Resume Next' not supported");
						
						this.Cursor = Cursors.WaitCursor;
						
						if (mdlParametros.bgCancela)
						{
							return;
						}
						this.Cursor = Cursors.WaitCursor;
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORSTR.STR_LEE_BD;
						int ilPos = (mdlParametros.sgNomGrupo.IndexOf(Strings.Chr(0).ToString()) + 1);
						if (ilPos > CORVB.NULL_INTEGER)
						{
							pnlEmpresa[1].Caption = Strings.Mid(mdlParametros.sgNomGrupo, 1, mdlParametros.sgNomGrupo.IndexOf((StringsHelper.DoubleValue(Strings.Chr(0).ToString()) - 1).ToString()) + 1).Trim();
						} else
						{
							pnlEmpresa[1].Caption = mdlParametros.sgNomGrupo;
						}
						prOrdenaTab(0);
						
						switch(this.Tag.ToString())
						{
							case "Alta" :  //Es un Alta de Empresa 
								pnlEmpresa[2].Caption = "Cuenta Nueva"; 
								chkEmpresa[0].Enabled = true;  //Skip Payment 
								chkEmpresa[1].Enabled = false;  //Estado de Cuenta al Corte SBF (Por Corte) 
								 
								chkEmpresa[3].Enabled = false;  //Estado de Cuenta al Corte SBF (Detalle de Movimientos) 
								mskEmpresa[7].CtlText = "50";  //Minimo a Facturar 
								optEmpresa[6].Checked = true;  //Tipo de Facturacion (Individual) 
								pnlEmpresa[5].Visible = false;  //Encabezado de Numero de Empresa 
								pnlEmpresa[6].Visible = false;  //Numero de Empresa 
								 
ObtieneEjecutivoBanamex:   
								if (mdlParametros.gcejxEjecutivoBanamex.Count != 0)
								{
									mdlCatalogos.prLlenaCombo(mdlParametros.gcejxEjecutivoBanamex, cmbEmpresa[3]);
								} else
								{
									if (MessageBox.Show("No existen Ejecutivos en Catalogos." + "\r\n" + "¿Desea dar de Alta Ejecutivos?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
									{
										//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
										CORMNEJB.DefInstance.ShowDialog();
										goto ObtieneEjecutivoBanamex;
									} else
									{
										this.Close();
										return;
									}
								} 
								 
								CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = ""; 
								 
								break;
							case CORCONST.TAG_CAMBIO :  //Cambio 
								break;
							case CORCONST.TAG_CONSULTA :  //Consulta 
								break;
						}
						
						this.Cursor = Cursors.Default;
						
					}
			}
			
			private void  frmEmpresa_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
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
					
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					
					lcteCliente = new clsCliente();
					ldteEmpresa = new clsDatosEmpresa();
					mdlgDialogo = new clsDialogo();
					
					mdlEmpresa.prLlenaEstruct(cmbEmpresa[5]);
					mdlEmpresa.prLlenaMeses(cmbEmpresa[4]);
					mdlEmpresa.prLlenaSector(cmbEmpresa[0]);
					mdlCatalogos.prLlenaCombo(mdlParametros.gcestEstado, cmbEmpresa[1]);
					mdlCatalogos.prLlenaCombo(mdlParametros.gcestEstado, cmbEmpresa[2]);
					prOrdenaTab(0);
					mskEmpresa[3].CtlText = DateTime.Now.ToString("dd/MM/yyyy");
					
			}
			
			private void  mskEmpresa_Enter( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(mskEmpresa, eventSender);
					
					switch(Index)
					{
						case 1 :  //RFC 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 2 :  //No. Cartera 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 3 :  //Vencimiento Credito 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 4 :  //Credito Total Asignado 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 5 :  //Credito Acumulado 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 6 :  //% Minimo de Pago 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 7 :  //Minimo a Facturar 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 8 :  //Dia de Corte 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 9 :  //Periodo de Gracia 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 10 :  //Plazo de no cobro de intereses 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 11 :  //Domicilio Fiscal (CP) 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 12 :  //Domicilio Envio (CP) 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 13 :  //Representante (Telefono) 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 14 :  //Representante (Ext.) 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 15 :  //Representante (Fax) 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 16 :  //Identificador Tabla MCC 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 17 :  //Cuenta Eje (Sucursal) 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
						case 18 :  //Cuenta Eje (Cuenta) 
							mskEmpresa[Index].SelStart = 0; 
							mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText); 
							break;
					}
					
					
			}
			
			private void  mskEmpresa_KeyPressEvent( Object eventSender,  AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
			{
					int Index = Array.IndexOf(mskEmpresa, eventSender);
					
					switch(Index)
					{
						case 1 :  //RFC 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-"); 
							break;
						case 2 :  //No. Cartera 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false); 
							break;
						case 4 :  //Credito Total Asignado 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false); 
							break;
						case 5 :  //Credito Acumulado 
                            //AIS-1094 NGONZALEZ
							if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8 && eventArgs.keyAscii != 46)
							{
                                //AIS-1094 NGONZALEZ
								eventArgs.keyAscii = CORVB.NULL_INTEGER;
							} 
							break;
						case 6 :  //% Minimo de Pago 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false); 
							break;
						case 7 :  //Minimo a Facturar 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, true); 
							break;
						case 8 :  //Dia de Corte 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false); 
							break;
						case 9 :  //Periodo de Gracia 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false); 
							break;
						case 10 :  //Plazo de no cobro de intereses 
                            //AIS-1094 NGONZALEZ
							if (eventArgs.keyAscii == ((int) "\t"[0]))
							{
								prOrdenaTab(1);
							} else
							{
                                //AIS-1094 NGONZALEZ
								//AIS-1096 NGONZALEZ
								CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
							} 
							break;
						case 11 :  //Domicilio Fiscal (CP) 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos); 
							break;
						case 12 :  //Domicilio Envio (CP) 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos);
                            //AIS-1094 NGONZALEZ
                            if (eventArgs.keyAscii == ((int) "\t"[0]))
							{
								prOrdenaTab(2);
							} 
							break;
						case 13 :  //Representante (Telefono) 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false); 
							break;
						case 14 :  //Representante (Ext.) 
                            //AIS-1094 NGONZALEZ
							//AIS-1096 NGONZALEZ
							CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false); 
							break;
						case 15 :  //Representante (Fax) 
                            //AIS-1094 NGONZALEZ
                            //AIS-1096 NGONZALEZ
                            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false); 
							break;
						case 17 :  //Cuenta Eje (Sucursal) 
                            //AIS-1094 NGONZALEZ
                            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != ((int) Keys.Back))
							{
                                //AIS-1094 NGONZALEZ
								eventArgs.keyAscii = 0;
							} 
							break;
						case 18 :  //Cuenta Eje (Cuenta) 
                            //AIS-1094 NGONZALEZ
							if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != ((int) Keys.Back))
							{
                                //AIS-1094 NGONZALEZ
								eventArgs.keyAscii = 0;
							} 
							break;
					}
					
			}
			
			private void  mskEmpresa_Leave( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(mskEmpresa, eventSender);
					
					switch(Index)
					{
						case 1 :  //RFC 
							ldteEmpresa.EmpRfcRFC.RFCS = mskEmpresa[Index].CtlText.Trim(); 
							 
							break;
						case 2 :  //No. Cartera 
							ldteEmpresa.EmpNumCarteraD = Double.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 3 :  //Vencimiento Credito 
							ldteEmpresa.EmpFecVencCredS = (mskEmpresa[Index].CtlText.Substring(0, Math.Min(mskEmpresa[Index].CtlText.Length, 3)) + mdlParametros.fncObtenMesInglesS(Convert.ToInt32(Conversion.Val(Strings.Mid(mskEmpresa[Index].CtlText, 4, 2)))) + mskEmpresa[Index].CtlText.Substring(mskEmpresa[Index].CtlText.Length - Math.Min(mskEmpresa[Index].CtlText.Length, 4))).Trim(); 
							 
							break;
						case 4 :  //Credito Total Asignado 
							ldteEmpresa.EmpCredTotL = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 5 :  //Credito Acumulado 
							ldteEmpresa.EmpAcumCredL = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 6 :  //% Minimo de Pago 
							ldteEmpresa.EmpLimDisEfecI = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 7 :  //Minimo a Facturar 
							ldteEmpresa.EmpMinFactD = Double.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 8 :  //Dia de Corte 
							ldteEmpresa.EmpDiaCorteI = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 9 :  //Periodo de Gracia 
							ldteEmpresa.EmpPlazoGraciaI = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 10 :  //Plazo de no cobro de intereses 
							ldteEmpresa.EmpPlazoNoCobI = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 11 :  //Domicilio Fiscal (CP) 
							ldteEmpresa.EmpDomFiscalDMC.CPL = Convert.ToInt32(Conversion.Val(mskEmpresa[Index].CtlText)); 
							 
							break;
						case 12 :  //Domicilio Envio (CP) 
							ldteEmpresa.EmpDomEnvioDMC.CPL = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 13 :  //Representante (Telefono) 
							if (optEmpresa[0].Checked)
							{ //Representante 1
								ldteEmpresa.EmpRep1RPR.TelefonoS = mskEmpresa[Index].CtlText.Trim();
							} else if (optEmpresa[1].Checked) {  //Representante 2
								ldteEmpresa.EmpRep2RPR.TelefonoS = mskEmpresa[Index].CtlText.Trim();
							} else if (optEmpresa[2].Checked) {  //Representante 3
								ldteEmpresa.EmpRep3RPR.TelefonoS = mskEmpresa[Index].CtlText.Trim();
							} 
							 
							break;
						case 14 :  //Representante (Ext.) 
							if (optEmpresa[0].Checked)
							{ //Representante 1
								ldteEmpresa.EmpRep1RPR.ExtensionS = mskEmpresa[Index].CtlText.Trim();
							} else if (optEmpresa[1].Checked) {  //Representante 2
								ldteEmpresa.EmpRep2RPR.ExtensionS = mskEmpresa[Index].CtlText.Trim();
							} else if (optEmpresa[2].Checked) {  //Representante 3
								ldteEmpresa.EmpRep3RPR.ExtensionS = mskEmpresa[Index].CtlText.Trim();
							} 
							 
							break;
						case 15 :  //Representante (Fax) 
							if (optEmpresa[0].Checked)
							{ //Representante 1
								ldteEmpresa.EmpRep1RPR.FaxS = mskEmpresa[Index].CtlText.Trim();
							} else if (optEmpresa[1].Checked) {  //Representante 2
								ldteEmpresa.EmpRep2RPR.FaxS = mskEmpresa[Index].CtlText.Trim();
							} else if (optEmpresa[2].Checked) {  //Representante 3
								ldteEmpresa.EmpRep3RPR.FaxS = mskEmpresa[Index].CtlText.Trim();
							} 
							 
							break;
						case 16 :  //Identificador Tabla MCC 
							ldteEmpresa.EmpTablaMccL = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 17 :  //Cuenta Eje (Sucursal) 
							ldteEmpresa.EmpSucEjeL = Int32.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
						case 18 :  //Cuenta Eje (Cuenta) 
							ldteEmpresa.EmpCtaEjeD = Double.Parse(mskEmpresa[Index].CtlText); 
							 
							break;
					}
					
			}
			
			private void  mskEmpresa_Validating( Object eventSender,  CancelEventArgs eventArgs)
			{
					bool Cancel = eventArgs.Cancel;
					int Index = Array.IndexOf(mskEmpresa, eventSender);
					
					switch(Index)
					{
						case 1 :  //RFC 
							if (! ldteEmpresa.EmpRfcRFC.fncValidaRFCB(mskEmpresa[Index].CtlText.Trim(), clsRFC.enuTipoPersona.tprPersonaMoral))
							{
								Cancel = true;
							} 
							 
							break;
						case 3 :  //Vencimiento Credito 
							if (Information.IsDate(mskEmpresa[Index].CtlText.Trim()))
							{
								if (DateTime.Parse(mskEmpresa[Index].CtlText) <= StringsHelper.DateValue(DateTime.Now.ToString("dd/MM/yyyy")))
								{
									MessageBox.Show("La fecha no puede ser menor o igual al día actual.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									mskEmpresa[Index].SelStart = 0;
									mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
									Cancel = true;
								}
							} else
							{
								MessageBox.Show("Fecha invalida.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} 
							 
							break;
						case 4 :  //Credito Total Asignado 
							if (Conversion.Val(mskEmpresa[Index].CtlText) > mdlEmpresa.ctelLimiteCredito)
							{
								MessageBox.Show("Importe mayor al permitido.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} else if (Conversion.Val(mskEmpresa[Index].CtlText) <= 0) { 
								MessageBox.Show("Importe menor al permitido.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].CtlText = "0";
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} 
							//            If fncExcepcionCreditoB = False Then 
							if (Conversion.Val(mskEmpresa[5].CtlText) > Conversion.Val(mskEmpresa[Index].CtlText))
							{
								MessageBox.Show("El monto mímino de crédito que puede especificar debe ser al menos el del acumulado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} 
							//            End If 
							 
							break;
						case 6 :  //% Minimo de Pago 
							if (Conversion.Val(mskEmpresa[Index].CtlText) < 0)
							{
								MessageBox.Show("El porcentaje mínimo de pago no puede ser menor al 0%.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].CtlText = "0";
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} else if (Conversion.Val(mskEmpresa[Index].CtlText) > 100) { 
								MessageBox.Show("El porcentaje mínimo de pago no debe exceder del 100%.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].CtlText = "100";
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} else if (Conversion.Val(mskEmpresa[Index].CtlText) == 100) { 
								ldteEmpresa.EmpEsquemaPagoS = mdlEmpresa.ctesTotal;
							} else if (Conversion.Val(mskEmpresa[Index].CtlText) > 100) { 
								ldteEmpresa.EmpEsquemaPagoS = mdlEmpresa.ctesMinimo;
							} 
							 
							break;
						case 7 :  //Minimo a Facturar 
							if (Conversion.Val(mskEmpresa[Index].CtlText) < 0)
							{
								MessageBox.Show("El valor no puede ser menor a 0.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].CtlText = "0";
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} 
							 
							break;
						case 8 :  //Dia de Corte 
							if (Conversion.Val(mskEmpresa[Index].CtlText) < 1 || Conversion.Val(mskEmpresa[Index].CtlText) > 28)
							{
								MessageBox.Show("Día de Corte no válido, este valor debe estar entre 1 y 28.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].CtlText = mdlEmpresa.cteiDiaCorte.ToString();
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} 
							 
							break;
						case 9 :  //Periodo de Gracia 
							if (Conversion.Val(mskEmpresa[Index].CtlText) < 1 || Conversion.Val(mskEmpresa[Index].CtlText) > 99)
							{
								MessageBox.Show("Período de gracia no válido, este valor debe estar entre 1 y 99.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].CtlText = mdlEmpresa.cteiPlazoGracia.ToString();
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} else
							{
								mskEmpresa[10].CtlText = mskEmpresa[Index].CtlText;
							} 
							 
							break;
						case 10 :  //Plazo de no cobro de intereses 
							if (Conversion.Val(mskEmpresa[Index].CtlText) < Conversion.Val(mskEmpresa[9].CtlText) || Conversion.Val(mskEmpresa[Index].CtlText) > 99)
							{
								MessageBox.Show("Plazo de no cobro de Interéses inválido, este valor debe estar entre " + Conversion.Val(mskEmpresa[9].CtlText).ToString() + " y 99.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								mskEmpresa[Index].SelStart = 0;
								mskEmpresa[Index].SelLength = Strings.Len(mskEmpresa[Index].CtlText);
								Cancel = true;
							} 
							 
							break;
					}
					
					eventArgs.Cancel = Cancel;
			}
			
			private bool isInitializingComponent;
			private void  optEmpresa_CheckedChanged( Object eventSender,  EventArgs eventArgs)
			{
					if (isInitializingComponent)
					{
						return;
					}
					if (((RadioButton) eventSender).Checked)
					{
						int Index = Array.IndexOf(optEmpresa, eventSender);
						
						switch(Index)
						{
							case 0 :  //Representante 1 
								if (ldteEmpresa.EmpRep1RPR.NombreS != "" || ldteEmpresa.EmpRep1RPR.PuestoS != "" || ldteEmpresa.EmpRep1RPR.TelefonoS != "" || ldteEmpresa.EmpRep1RPR.ExtensionS != "" || ldteEmpresa.EmpRep1RPR.FaxS != "")
								{
									mdlEmpresa.prLlenaRepresentanteEmp(1, ldteEmpresa.EmpRep1RPR);
								} else
								{
									mdlEmpresa.prLimpiaRepresentanteEmp();
								} 
								 
								break;
							case 1 :  //Representante 2 
								if (ldteEmpresa.EmpRep2RPR.NombreS != "" || ldteEmpresa.EmpRep2RPR.PuestoS != "" || ldteEmpresa.EmpRep2RPR.TelefonoS != "" || ldteEmpresa.EmpRep2RPR.ExtensionS != "" || ldteEmpresa.EmpRep2RPR.FaxS != "")
								{
									mdlEmpresa.prLlenaRepresentanteEmp(2, ldteEmpresa.EmpRep2RPR);
								} else
								{
									mdlEmpresa.prLimpiaRepresentanteEmp();
								} 
								 
								break;
							case 2 :  //Representante 3 
								if (ldteEmpresa.EmpRep3RPR.NombreS != "" || ldteEmpresa.EmpRep3RPR.PuestoS != "" || ldteEmpresa.EmpRep3RPR.TelefonoS != "" || ldteEmpresa.EmpRep3RPR.ExtensionS != "" || ldteEmpresa.EmpRep3RPR.FaxS != "")
								{
									mdlEmpresa.prLlenaRepresentanteEmp(3, ldteEmpresa.EmpRep3RPR);
								} else
								{
									mdlEmpresa.prLimpiaRepresentanteEmp();
								} 
								 
								break;
							case 3 :  //Envio Estado Cuenta (Empresa) 
								ldteEmpresa.EmpTipoEnvioS = mdlEmpresa.ctesEmpEmpresa; 
								 
								break;
							case 4 :  //Envio Estado Cuenta (Individual) 
								ldteEmpresa.EmpTipoEnvioS = mdlEmpresa.ctesEmpIndividual; 
								 
								break;
							case 5 :  //Tipo de Facturacion (Corporativo) 
								ldteEmpresa.EmpTipoFacS = mdlEmpresa.ctesEmpCorporativo; 
								 
								break;
							case 6 :  //Tipo de Facturacion (Individual) 
								ldteEmpresa.EmpTipoFacS = mdlEmpresa.ctesEmpIndividual; 
								 
								break;
							case 7 :  //Tipo de Pago (Automatico) 
								ldteEmpresa.EmpTipoPagoS = mdlEmpresa.ctesEmpAutomatico; 
								 
								break;
							case 8 :  //Tipo de Pago (Individual) 
								ldteEmpresa.EmpTipoPagoS = mdlEmpresa.ctesEmpIndividual; 
								 
								break;
							case 9 :  //Tipo de Pago (Libre) 
								ldteEmpresa.EmpTipoPagoS = mdlEmpresa.ctesEmpLibre; 
								 
								break;
							case 10 :  //Tipo de Producto (Business Card) 
								ldteEmpresa.EmpTipoProductoS = mdlEmpresa.ctesBusinessCard; 
								 
								break;
							case 11 :  //Tipo de Producto (Purchasing Card) 
								ldteEmpresa.EmpTipoProductoS = mdlEmpresa.ctesPurchasingCard; 
								 
								break;
							case 12 :  //Tipo de Producto (Distribution Line) 
								ldteEmpresa.EmpTipoProductoS = mdlEmpresa.ctesDistributionLine; 
								 
								break;
						}
						
					}
			}
			
			private void  txtEmpresa_TextChanged( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(txtEmpresa, eventSender);
					
					switch(Index)
					{
						case 0 :  //Nombre Largo 
							pnlEmpresa[4].Caption = txtEmpresa[Index].Text.Trim(); 
							 
							break;
					}
					
			}
			
			private void  txtEmpresa_Enter( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(txtEmpresa, eventSender);
					
					switch(Index)
					{
						case 0 :  //Nombre Largo 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 1 :  //Nombre Corto 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 2 :  //Principal Accionista 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 3 :  //Cuenta Contable 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 4 :  //Domicilio Fiscal (Domicilio Calle y Numero) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							prOrdenaTab(1); 
							break;
						case 5 :  //Domicilio Fiscal (Colonia) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 6 :  //Domicilio Fiscal (Pob. Del. Municipio) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 7 :  //Domicilio Fiscal (Ciudad) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 8 :  //Domicilio Envio (Domicilio Calle y Numero) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 9 :  //Domicilio Envio (Colonia) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 10 :  //Domicilio Envio (Pob. Del. Municipio) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 11 :  //Domicilio Envio (Ciudad) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 12 :  //Representante (Nombre) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 13 :  //Representante (Puesto) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 14 :  //Telefonos (Telefono) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 15 :  //Telefonos (Extension) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 16 :  //Telefonos (Lada) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 17 :  //Telefonos (Fax) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 18 :  //Telefonos (Fax Lada) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 19 :  //Telefonos (Email) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 20 :  //Telefonos (Internet) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
						case 21 :  //Ejecutivo Banamex (Numero de Nomina) 
							txtEmpresa[Index].SelectionStart = 0; 
							txtEmpresa[Index].SelectionLength = Strings.Len(txtEmpresa[Index].Text); 
							break;
					}
					
			}
			
			private void  txtEmpresa_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					int Index = Array.IndexOf(txtEmpresa, eventSender);
					
					switch(Index)
					{
						case 0 :  //Nombre Largo 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, ".,@"); 
							 
							break;
						case 1 :  //Nombre Corto 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "@"); 
							 
							break;
						case 2 :  //Principal Accionista 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true); 
							 
							break;
						case 3 :  //Cuenta Contable 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-"); 
							 
							break;
						case 4 :  //Domicilio Fiscal (Domicilio Calle y Numero) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "#,-."); 
							 
							break;
						case 5 :  //Domicilio Fiscal (Colonia) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "."); 
							 
							break;
						case 6 :  //Domicilio Fiscal (Pob. Del. Municipio) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, ",.-"); 
							 
							break;
						case 7 :  //Domicilio Fiscal (Ciudad) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true); 
							 
							break;
						case 8 :  //Domicilio Envio (Domicilio Calle y Numero) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "#,-."); 
							 
							break;
						case 9 :  //Domicilio Envio (Colonia) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "."); 
							 
							break;
						case 10 :  //Domicilio Envio (Pob. Del. Municipio) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, ",.-"); 
							 
							break;
						case 11 :  //Domicilio Envio (Ciudad) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true); 
							 
							break;
						case 12 :  //Representante (Nombre) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true); 
							 
							break;
						case 13 :  //Representante (Puesto) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true); 
							 
							break;
						case 14 :  //Telefonos (Telefono) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos); 
							 
							break;
						case 15 :  //Telefonos (Extension) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos); 
							 
							break;
						case 16 :  //Telefonos (Lada) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos); 
							 
							break;
						case 17 :  //Telefonos (Fax) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos); 
							 
							break;
						case 18 :  //Telefonos (Fax Lada) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos); 
							 
							break;
						case 19 :  //Telefonos (Email) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValCorreoElectrónico, false, false); 
							 
							break;
						case 20 :  //Telefonos (Internet) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, false, false, ".-_"); 
							 
							break;
						case 21 :  //Ejecutivo Banamex (Numero de Nomina) 
							CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValEntero); 
							 
							break;
					}
					
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			
			private void  txtEmpresa_Leave( Object eventSender,  EventArgs eventArgs)
			{
					int Index = Array.IndexOf(txtEmpresa, eventSender);
					
					switch(Index)
					{
						case 0 :  //Nombre Largo 
							ldteEmpresa.EmpNomS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 1 :  //Nombre Corto 
							ldteEmpresa.EmpNomGrabaS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 2 :  //Principal Accionista 
							ldteEmpresa.EmpPrincAccS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 3 :  //Cuenta Contable 
							ldteEmpresa.EmpCtaContableS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 4 :  //Domicilio Fiscal (Domicilio Calle y Numero) 
							ldteEmpresa.EmpDomFiscalDMC.DomicilioS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 5 :  //Domicilio Fiscal (Colonia) 
							ldteEmpresa.EmpDomFiscalDMC.ColoniaS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 6 :  //Domicilio Fiscal (Pob. Del. Municipio) 
							ldteEmpresa.EmpDomFiscalDMC.PoblacionS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 7 :  //Domicilio Fiscal (Ciudad) 
							ldteEmpresa.EmpDomFiscalDMC.CiudadS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 8 :  //Domicilio Envio (Domicilio Calle y Numero) 
							ldteEmpresa.EmpDomEnvioDMC.DomicilioS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 9 :  //Domicilio Envio (Colonia) 
							ldteEmpresa.EmpDomEnvioDMC.ColoniaS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 10 :  //Domicilio Envio (Pob. Del. Municipio) 
							ldteEmpresa.EmpDomEnvioDMC.PoblacionS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 11 :  //Domicilio Envio (Ciudad) 
							ldteEmpresa.EmpDomEnvioDMC.CiudadS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 12 :  //Representante (Nombre) 
							if (optEmpresa[0].Checked)
							{ //Representante 1
								ldteEmpresa.EmpRep1RPR.NombreS = txtEmpresa[Index].Text.Trim();
							} else if (optEmpresa[1].Checked) {  //Representante 2
								ldteEmpresa.EmpRep2RPR.NombreS = txtEmpresa[Index].Text.Trim();
							} else if (optEmpresa[2].Checked) {  //Representante 3
								ldteEmpresa.EmpRep3RPR.NombreS = txtEmpresa[Index].Text.Trim();
							} 
							 
							break;
						case 13 :  //Representante (Puesto) 
							if (optEmpresa[0].Checked)
							{ //Representante 1
								ldteEmpresa.EmpRep1RPR.PuestoS = txtEmpresa[Index].Text.Trim();
							} else if (optEmpresa[1].Checked) {  //Representante 2
								ldteEmpresa.EmpRep2RPR.PuestoS = txtEmpresa[Index].Text.Trim();
							} else if (optEmpresa[2].Checked) {  //Representante 3
								ldteEmpresa.EmpRep3RPR.PuestoS = txtEmpresa[Index].Text.Trim();
							} 
							 
							break;
						case 14 :  //Telefonos (Telefono) 
							ldteEmpresa.EmpTelefonoS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 15 :  //Telefonos (Extension) 
							ldteEmpresa.EmpExtensionS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 16 :  //Telefonos (Lada) 
							ldteEmpresa.EmpTelLadaS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 17 :  //Telefonos (Fax) 
							ldteEmpresa.EmpFaxS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 18 :  //Telefonos (Fax Lada) 
							ldteEmpresa.EmpFaxLadaS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 19 :  //Telefonos (Email) 
							ldteEmpresa.EmpEmailS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
						case 20 :  //Telefonos (Internet) 
							ldteEmpresa.EmpInternetS = txtEmpresa[Index].Text.Trim(); 
							 
							break;
					}
					
			}
			
			private void  txtEmpresa_Validating( Object eventSender,  CancelEventArgs eventArgs)
			{
					bool Cancel = eventArgs.Cancel;
					int Index = Array.IndexOf(txtEmpresa, eventSender);
					
					switch(Index)
					{
						case 0 :  //Nombre Largo 
							break;
						case 1 :  //Nombre Corto 
							break;
						case 2 :  //Principal Accionista 
							break;
						case 3 :  //Cuenta Contable 
							break;
						case 4 :  //Domicilio Fiscal (Domicilio Calle y Numero) 
							break;
						case 5 :  //Domicilio Fiscal (Colonia) 
							break;
						case 6 :  //Domicilio Fiscal (Pob. Del. Municipio) 
							break;
						case 7 :  //Domicilio Fiscal (Ciudad) 
							break;
						case 8 :  //Domicilio Envio (Domicilio Calle y Numero) 
							break;
						case 9 :  //Domicilio Envio (Colonia) 
							break;
						case 10 :  //Domicilio Envio (Pob. Del. Municipio) 
							break;
						case 11 :  //Domicilio Envio (Ciudad) 
							 
							break;
						case 12 :  //Representante (Nombre) 
							if (optEmpresa[0].Checked)
							{ //Representante 1
								ldteEmpresa.EmpRep1RPR.NombreS = txtEmpresa[Index].Text.Trim();
							} else if (optEmpresa[1].Checked) {  //Representante 2
								ldteEmpresa.EmpRep2RPR.NombreS = txtEmpresa[Index].Text.Trim();
							} else if (optEmpresa[2].Checked) {  //Representante 3
								ldteEmpresa.EmpRep3RPR.NombreS = txtEmpresa[Index].Text.Trim();
							} 
							 
							break;
						case 13 :  //Representante (Puesto) 
							if (optEmpresa[0].Checked)
							{ //Representante 1
								ldteEmpresa.EmpRep1RPR.PuestoS = txtEmpresa[Index].Text.Trim();
							} else if (optEmpresa[1].Checked) {  //Representante 2
								ldteEmpresa.EmpRep2RPR.PuestoS = txtEmpresa[Index].Text.Trim();
							} else if (optEmpresa[2].Checked) {  //Representante 3
								ldteEmpresa.EmpRep3RPR.PuestoS = txtEmpresa[Index].Text.Trim();
							} 
							 
							break;
						case 14 :  //Telefonos (Telefono) 
							break;
						case 15 :  //Telefonos (Extension) 
							break;
						case 16 :  //Telefonos (Lada) 
							break;
						case 17 :  //Telefonos (Fax) 
							break;
						case 18 :  //Telefonos (Fax Lada) 
							break;
						case 19 :  //Telefonos (Email) 
							if (Strings.Len(txtEmpresa[Index].Text) > 0)
							{
								if ((txtEmpresa[Index].Text.IndexOf('@') + 1) == 0 || (txtEmpresa[Index].Text.IndexOf('@') + 1) == 1 || (txtEmpresa[Index].Text.IndexOf('@') + 1) == Strings.Len(txtEmpresa[Index].Text))
								{
									Cancel = true;
									MessageBox.Show("Dirección de Correo electrónico incorrecta." + "\r\n" + "Verifique la dirección.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								}
							} 
							
							 
							break;
						case 20 :  //Telefonos (Internet) 
							break;
						case 21 :  //Ejecutivo Banamex (Numero de Nomina) 
							break;
					}
					
					
					eventArgs.Cancel = Cancel;
			}
			
			private void  prOrdenaTab( int ipIndice)
			{
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							switch(ipIndice)
							{
								case 0 :  //Tab "Datos Generales" 
									pnlEmpresa[0].Visible = true; 
									pnlEmpresa[1].Visible = true; 
									pnlEmpresa[2].Visible = true; 
									if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
									{
										txtEmpresa[0].Focus();
									} 
									tabEmpresa.SelectedIndex = ipIndice; 
									break;
								case 1 :  //Tab "Domicilio" 
									if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
									{
										txtEmpresa[4].Focus();
									} 
									tabEmpresa.SelectedIndex = ipIndice; 
									break;
								case 2 :  //Tab "Representantes" 
									if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
									{
										optEmpresa[0].Focus();
									} 
									tabEmpresa.SelectedIndex = ipIndice; 
									break;
								case 3 :  //Tab "Telefonos de la Empresa" 
									if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
									{
										txtEmpresa[14].Focus();
									} 
									tabEmpresa.SelectedIndex = ipIndice; 
									break;
								case 4 :  //Tab "Datos Adicionales" 
									if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
									{
										cmbEmpresa[4].Focus();
									} 
									tabEmpresa.SelectedIndex = ipIndice; 
									break;
							}
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			private void  frmEmpresa_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}