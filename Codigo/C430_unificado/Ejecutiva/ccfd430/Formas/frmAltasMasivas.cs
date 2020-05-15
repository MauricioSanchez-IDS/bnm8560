using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Drawing; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Runtime.InteropServices;

namespace TCd430
{
	internal partial class frmAltasMasivas
		: System.Windows.Forms.Form
		{
		
			
			//Variables para las conexiones
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
			
			
			//Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
			clsDatosEjecutivo gdteEjeExists = null;
			
			//Variable para el dialogo
			clsDialogo gdlgDialogoS016 = null;
			clsDialogo gdlgDialogoS111 = null;
			bool PrimeraVez = false;
			
			private bool fncAltaEjecutivoB()
			{
					//Dim slTablaTemporal As String
					//Dim lEjeReenvio As clsReenvioTarjetahabientes
					bool result = false;
					clsReenvioTarjetahabientes lEjeReenvio = null;
					clsAltaTarjetahabiente lAltaEje = null;
					string slTablaTemporal = String.Empty;
					
					if (fncValidarConsecutivoB())
					{
						//ya con anterioridad se había validado el limite de crédito por empresa.
						//      Set lEjeReenvio = New clsReenvioTarjetahabientes
						//      Set lEjeReenvio.EjegdteEjecutivo = gdteAltasMasivas
						//      slTablaTemporal = "MTCMSV01"
						//      lEjeReenvio.Temporal = slTablaTemporal
						//      lEjeReenvio.EjeStatusS = 0
						//      fncAltaEjecutivoB = Not lEjeReenvio.Resultado
						//      Set lEjeReenvio = Nothing
						lEjeReenvio = new clsReenvioTarjetahabientes();
						lAltaEje = new clsAltaTarjetahabiente();
						lAltaEje.EjegdteEjecutivo = mdlAltasMasivas.gdteAltasMasivas;
						slTablaTemporal = "MTCMSV02";
						lAltaEje.Temporal = slTablaTemporal;
						lEjeReenvio.mObjetoAlta = lAltaEje;

                        //lEjeReenvio.EjeStatusS = "0";
                        lEjeReenvio.EjeStatusSComdrv = "0";

						result = ! lEjeReenvio.resultado;
						lAltaEje = null;
						lEjeReenvio = null;
					} else
					{
						result = false;
					}
					
					this.Cursor = Cursors.Default;
					
					
					return result;
			}
			
			
			private bool fncActualizaConsecutivoB()
			{
					
					bool result = false;
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							CORVAR.pszgblsql = "update MTCEMP01";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_con_eje = " + ((mdlAltasMasivas.gdteAltasMasivas.EjeNumL + 1).ToString()) + ",";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.PrefijoL.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.BancoL.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + mdlAltasMasivas.gdteAltasMasivas.EjeEmpNumL.ToString();
							
							if (CORPROC2.Modifica_Registro() != 0)
							{
								result = true;
								this.Cursor = Cursors.Default;
								return result;
							} else
							{
								result = false;
								this.Cursor = Cursors.Default;
								return result;
							}
						}
					catch 
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							result = false;
							this.Cursor = Cursors.Default;
							return result;
						}
					}
					
					return result;
			}
			
			private void  prActualizaEstatus( int lpEstatus)
			{
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							switch(lpEstatus)
							{
								case 3 : case 4 : 
									CORVAR.pszgblsql = "update MTCMSV02"; 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_num = " + mdlAltasMasivas.gdteAltasMasivas.EjeNumL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " ,eje_digit = " + mdlAltasMasivas.gdteAltasMasivas.EjeDigitI.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " ,eje_status_reg = " + lpEstatus.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.PrefijoL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.BancoL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + mdlAltasMasivas.gdteAltasMasivas.EjeEmpNumL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + mdlAltasMasivas.gdteAltasMasivas.EjeRfcRFC.RFCS + "'"; 
									 
									break;
								default:
									CORVAR.pszgblsql = "update MTCMSV02"; 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_status_reg = " + lpEstatus.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.PrefijoL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.BancoL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + mdlAltasMasivas.gdteAltasMasivas.EjeEmpNumL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_nom_gra = '" + mdlAltasMasivas.gdteAltasMasivas.EjeNomGrabaS + "'"; 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + mdlAltasMasivas.gdteAltasMasivas.EjeRfcRFC.RFCS + "'"; 
									break;
							}
							
							if (CORPROC2.Modifica_Registro() != 0)
							{
								this.Cursor = Cursors.Default;
								return;
							}
							
							this.Cursor = Cursors.Default;
						}
					catch 
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							this.Cursor = Cursors.Default;
							return;
						}
					}
					
			}
			
			
			private bool fncValidarConsecutivoB()
			{
					
					bool result = false;
					int llConsecutivo = 0;
					int llConsecutivoTope = 0;
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							CORVAR.pszgblsql = "select";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_con_eje";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.PrefijoL.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.BancoL.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + mdlAltasMasivas.gdteAltasMasivas.EjeEmpNumL.ToString();
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									llConsecutivo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)) - 1;
									llConsecutivoTope = StringsHelper.IntValue(new string('9', mdlAltasMasivas.gdteAltasMasivas.EjeProductoPRD.LongitudEjecutivoI));
								};
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
							if (llConsecutivo >= llConsecutivoTope)
							{
								result = false;
								MessageBox.Show("Se deberá crear una nueva empresa para los siguientes ejecutivos." + "\r\n" + 
								                "Se ha llegado al límite de " + (llConsecutivoTope + 1).ToString() + " tarjetahabientes.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								this.Cursor = Cursors.Default;
								return result;
							} else
							{
								result = true;
								this.Cursor = Cursors.Default;
								return result;
							}
							
							this.Cursor = Cursors.Default;
						}
                        catch (Exception e)
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmEjecutivo ValidarConsecutivo",e );
							result = false;
							this.Cursor = Cursors.Default;
							return result;
						}
					}
					
					return result;
			}
			
		
			/*
			private bool fncVerificaConsultaB( mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
			{
					
					bool result = false;
					int ilResConS111 = 0;
					string slConS111 = String.Empty;
					string slCausaS111 = String.Empty;
					string slConsulta = String.Empty;
					string slCadena1 = String.Empty;
					string slCadena2 = String.Empty;
					string slCadena3 = String.Empty;
					string slFolio = String.Empty;
					string slCampo = String.Empty;
					int ilRespuestaEnvio = 0;
					string slFecAlta = String.Empty;
					string slFecModificacion = String.Empty;
					string slValidacion = String.Empty;
					string slRespuestaS016 = String.Empty;
					string slNombreGraba = String.Empty;
					string slRFC = String.Empty;
					string slDialogoConsulta = String.Empty;
					string slRespMensaje = String.Empty;
					string slDialogo = String.Empty;
					int ilcont = 0;
					
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS111)
							{ //***** CONSULTA S111 *****
								
								gdlgDialogoS111 = new clsDialogo();
								
								gdlgDialogoS111.prGeneraDlg(mdlAltasMasivas.gdteAltasMasivas, clsDialogo.enuTipoDialogo.tConsEjecutivoS111);
								
								slDialogo = gdlgDialogoS111.DialogoS;
								gdlgDialogoS111 = null;
								
								string tempRefParam = "S753-CONALTAS";
								ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
								Application.DoEvents();
								
								cnxConexionRut.Termina_Conexion();
								
								slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");
								
								if (ilRespuestaEnvio != 0)
								{
									prActualizaEstatus(8);
									result = false;
									this.Cursor = Cursors.Default;
									return result;
								} else
								{
									slCadena1 = Strings.Mid(slRespMensaje, 1243, 151).Trim();
									slCadena2 = Strings.Mid(slRespMensaje, 38, 371).Trim();
									slCadena3 = Strings.Mid(slRespMensaje, 1608, 31).Trim();
									
									gdteEjeExists = null;
									gdteEjeExists = new clsDatosEjecutivo();
									
									gdteEjeExists.EjeNomGrabaS = Strings.Mid(slCadena1, 1, 26).Trim();
									gdteEjeExists.EjeDomEnvioDMC.DomicilioS = Strings.Mid(slCadena1, 46, 35).Trim();
									gdteEjeExists.EjeDomEnvioDMC.ColoniaS = Strings.Mid(slCadena1, 81, 25).Trim();
									gdteEjeExists.EjeDomEnvioDMC.PoblacionS = Strings.Mid(slCadena1, 106, 19).Trim();
									
									switch(Strings.Mid(slCadena1, 138, 1).Trim())
									{
										case "1" : 
											gdteEjeExists.EjeTipoCuentaS = "       Básica       "; 
											break;
										case "2" : 
											gdteEjeExists.EjeTipoCuentaS = "      Adicional     "; 
											break;
										case "3" : 
											gdteEjeExists.EjeTipoCuentaS = "Básica con Adicional"; 
											break;
									}
									
									gdteEjeExists.EjeSucTransS = Strings.Mid(slCadena1, 139, 4).Trim();
									gdteEjeExists.EjeSexoS = Strings.Mid(slCadena1, 145, 1).Trim();
									slCausaS111 = Strings.Mid(slCadena3, 1, 19).Trim();
									slFecAlta = Strings.Mid(slCadena3, 20, 6).Trim();
									slFecModificacion = Strings.Mid(slCadena3, 26, 6).Trim();
									slValidacion = fncValidaDatosS(mdlEjecutivo.enuTipoAltaSistema.tasAltaS111);
									
									if (slValidacion == "")
									{
										result = true;
										this.Cursor = Cursors.Default;
										return result;
									} else
									{
										result = false;
										this.Cursor = Cursors.Default;
										return result;
									}
								}
							} else
							{
							}
							
							this.Cursor = Cursors.Default;
						}
					catch 
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							result = false;
							this.Cursor = Cursors.Default;
							return result;
						}
					}
					
					return result;
			}
		*/	
			private string fncValidaDatosS( mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
			{
					
					string result = String.Empty;
					if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS016)
					{
						if (gdteEjeExists.EjeNomGrabaS != mdlAltasMasivas.gdteAltasMasivas.EjeNomGrabaS)
						{
							result = "Nombre de Grabación";
						} else if (gdteEjeExists.EjeRfcRFC.RFCS != mdlAltasMasivas.gdteAltasMasivas.EjeRfcRFC.RFCS) { 
							result = "RFC";
						}
						
					} else if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS111) { 
						if (gdteEjeExists.EjeNomGrabaS != mdlAltasMasivas.gdteAltasMasivas.EjeNomGrabaS)
						{
							result = "Nombre";
						} else if (gdteEjeExists.EjeDomEnvioDMC.DomicilioS != mdlAltasMasivas.gdteAltasMasivas.EjeDomEnvioDMC.DomicilioS) { 
							result = "Calle";
						} else if (gdteEjeExists.EjeDomEnvioDMC.ColoniaS != mdlAltasMasivas.gdteAltasMasivas.EjeDomEnvioDMC.ColoniaS) { 
							result = "Colonia";
						} else if (gdteEjeExists.EjeDomEnvioDMC.PoblacionS != mdlAltasMasivas.gdteAltasMasivas.EjeDomEnvioDMC.PoblacionS) { 
							result = "Población";
						} else if (gdteEjeExists.EjeSexoS != mdlAltasMasivas.gdteAltasMasivas.EjeSexoS) { 
							result = "Sexo";
						} else if (gdteEjeExists.EjeTipoCuentaS != "       Básica       ") { 
							result = "Tipo de Cuenta";
						} else if (gdteEjeExists.EjeSucTransS != mdlAltasMasivas.gdteAltasMasivas.EjeSucTransS) { 
							result = "Sucursal";
						}
					}
					
					return result;
			}
			
			
        public void activated()
        {
                bool blResultadoInsert = false;
                int llContOK = 0;
                int llcontador = 0;
                int iFlood_1 = 0;
                string sctaref = String.Empty;

                //UPGRADE_TODO: (1065) Error handling statement (On Error Resume Next) could not be converted properly. A throw statement was generated instead.
                //throw new Exception("Migration Exception: 'On Error Resume Next' not supported");
                if (!PrimeraVez)
                {
                    return;
                }
                PrimeraVez = false;
                mdlParametros.prQuitaObjetos();
                mdlAltasMasivas.prObtenDiaCorte(CORVAR.lgblEmpCve);

                cmnAltasMasivas.DefaultExt = "*.xmt";
                cmnAltasMasivas.Filter = "*.xmt";
                cmnAltasMasivas.FileName = "*.xmt";
                cmnAltasMasivas.Flags = 0x1000 | 0x4 | 0x400;
                try
                {
                    cmnAltasMasivas.ShowOpen();
                }
                catch (COMException e)
                {
                    if (e.ErrorCode != 0 && e.ErrorCode != -2146795533)
                        MessageBox.Show(e.ErrorCode.ToString() + e.Message, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                string final = ".xmt";

                if (cmnAltasMasivas.FileTitle == "")
                {
                    MessageBox.Show("No selecciono ningun archivo", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                else if ((cmnAltasMasivas.FileTitle.IndexOf(final) + 1) == 0)
                {
                    MessageBox.Show("Archivo con extensión errornea", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                string slPathfile = cmnAltasMasivas.FileName;
                this.Cursor = Cursors.WaitCursor;
                frmAltasMasivas.DefInstance.lblMensaje.Visible = true;
                Application.DoEvents();
                bool blResultado = mdlParametros.gcarcAltasMasivas.fncValidaInformacionB(slPathfile);
                Application.DoEvents();

                if (blResultado)
                {
                    Application.DoEvents();
                    frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = false;
                    frmAltasMasivas.DefInstance.pnlProgProceso[1].Visible = false;
                    //        blResultadoInsert = gcarcAltasMasivas.fncGrabaTablaMTCMSV01B()
                    //        If blResultadoInsert = True Then
                    mdlParametros.bColorCambiado = true;
                    llcontador = 1;
                    llContOK = 0;
                    frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodType = Threed.enumFloodTypeConstants._LeftToRight;
                    frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodShowPct = true;
                    frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent = (short)CORVB.NULL_INTEGER;
                    frmAltasMasivas.DefInstance.pnlProgProceso[0].ForeColor = Color.Black;
                    frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = true;
                    mdlParametros.prQuitaObjetos();
                    frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = true;
                    frmAltasMasivas.DefInstance.lblRegistro.Visible = true;
                    frmAltasMasivas.DefInstance.lblNumRegistro[0].Visible = true;
                    frmAltasMasivas.DefInstance.Label1[1].Visible = true;
                    frmAltasMasivas.DefInstance.lblNumRegistro[1].Visible = true;
                    frmAltasMasivas.DefInstance.lblNumRegistro[1].Text = mdlParametros.gcarcAltasMasivas.Count.ToString();
                    frmAltasMasivas.DefInstance.lblMensaje.Visible = true;
                    frmAltasMasivas.DefInstance.lblMensaje.Text = "Espere, dando de alta Ejecutivos";
                    frmAltasMasivas.DefInstance.lblNumRegistro[0].Text = llcontador.ToString();

                    mdlAltasMasivas.gdteAltasMasivas = null;
                    mdlAltasMasivas.gdteAltasMasivas = new clsDatosEjecutivo();
                    sctaref = mdlAltasMasivas.fncCuentaMapeada(mdlParametros.slctaref);

                    while (llcontador <= mdlParametros.gcarcAltasMasivas.Count)
                    {
                        if (mdlAltasMasivas.fncAsignaValoresAltaMasivaB(llcontador, sctaref))
                        {
                            if (fncAltaEjecutivoB())
                            {
                                llContOK++;
                            }
                        }
                        frmAltasMasivas.DefInstance.lblNumRegistro[0].Text = llcontador.ToString();
                        iFlood_1 = Convert.ToInt32(Math.Floor((llcontador / ((double)mdlParametros.gcarcAltasMasivas.Count)) * 100));
                        frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent = (short)iFlood_1;
                        if (frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent > 1)
                        {
                            frmAltasMasivas.DefInstance.pnlProgProceso[0].ForeColor = Color.White;
                            mdlParametros.bColorCambiado = true;
                        }
                        Application.DoEvents();
                        llcontador++;
                    };
                    //        Else
                    //            MsgBox "No se genero de forma correcta la tabla MTCMSV01", vbCritical
                    //        End If
                    Application.DoEvents();
                }
                else
                {
                    MessageBox.Show("Existen errores en los regisros del archivo que se proceso, revisar archivo Archivo_Errores.txt", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mdlParametros.prQuitaObjetos();
                    Application.DoEvents();
                }

                this.Cursor = Cursors.Default;
                this.Hide();
                MessageBox.Show("Se dieron de alta " + llContOK.ToString() + " Ejecutivos de " + mdlParametros.gcarcAltasMasivas.Count.ToString() + " que contiene el archivo", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
        }

			private void  frmAltasMasivas_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						
						bool blResultadoInsert = false;
						int llContOK = 0;
						int llcontador = 0;
						int iFlood_1 = 0;
						string sctaref = String.Empty;
						
						//UPGRADE_TODO: (1065) Error handling statement (On Error Resume Next) could not be converted properly. A throw statement was generated instead.
						//throw new Exception("Migration Exception: 'On Error Resume Next' not supported");
						if (! PrimeraVez)
						{
							return;
						}
						PrimeraVez = false;
						mdlParametros.prQuitaObjetos();
						mdlAltasMasivas.prObtenDiaCorte(CORVAR.lgblEmpCve);
						
						cmnAltasMasivas.DefaultExt = "*.xmt";
						cmnAltasMasivas.Filter = "*.xmt";
						cmnAltasMasivas.FileName = "*.xmt";
						cmnAltasMasivas.Flags = 0x1000 | 0x4 | 0x400;
                        try
                        {
                            cmnAltasMasivas.ShowOpen();
                        }
                        catch (COMException e) {
                            if(e.ErrorCode != 0 && e.ErrorCode != -2146795533)
                            MessageBox.Show(e.ErrorCode.ToString() + e.Message, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
						string final = ".xmt";

						if (cmnAltasMasivas.FileTitle == "")
						{
							MessageBox.Show("No selecciono ningun archivo", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
							this.Close();
							return;
						} else if ((cmnAltasMasivas.FileTitle.IndexOf(final) + 1) == 0) { 
							MessageBox.Show("Archivo con extensión errornea", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
							this.Close();
							return;
						}
						
						string slPathfile = cmnAltasMasivas.FileName;
						this.Cursor = Cursors.WaitCursor;
						frmAltasMasivas.DefInstance.lblMensaje.Visible = true;
                        Application.DoEvents();
						bool blResultado = mdlParametros.gcarcAltasMasivas.fncValidaInformacionB(slPathfile);
						Application.DoEvents();
						
						if (blResultado)
						{
							Application.DoEvents();
							frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = false;
							frmAltasMasivas.DefInstance.pnlProgProceso[1].Visible = false;
							//        blResultadoInsert = gcarcAltasMasivas.fncGrabaTablaMTCMSV01B()
							//        If blResultadoInsert = True Then
							mdlParametros.bColorCambiado = true;
							llcontador = 1;
							llContOK = 0;
							frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodType = Threed.enumFloodTypeConstants._LeftToRight;
							frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodShowPct = true;
							frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent = (short) CORVB.NULL_INTEGER;
							frmAltasMasivas.DefInstance.pnlProgProceso[0].ForeColor = Color.Black;
							frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = true;
							mdlParametros.prQuitaObjetos();
							frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = true;
							frmAltasMasivas.DefInstance.lblRegistro.Visible = true;
							frmAltasMasivas.DefInstance.lblNumRegistro[0].Visible = true;
							frmAltasMasivas.DefInstance.Label1[1].Visible = true;
							frmAltasMasivas.DefInstance.lblNumRegistro[1].Visible = true;
							frmAltasMasivas.DefInstance.lblNumRegistro[1].Text = mdlParametros.gcarcAltasMasivas.Count.ToString();
							frmAltasMasivas.DefInstance.lblMensaje.Visible = true;
							frmAltasMasivas.DefInstance.lblMensaje.Text = "Espere, dando de alta Ejecutivos";
							frmAltasMasivas.DefInstance.lblNumRegistro[0].Text = llcontador.ToString();
							
							mdlAltasMasivas.gdteAltasMasivas = null;
							mdlAltasMasivas.gdteAltasMasivas = new clsDatosEjecutivo();
							sctaref = mdlAltasMasivas.fncCuentaMapeada(mdlParametros.slctaref);
							
							while(llcontador <= mdlParametros.gcarcAltasMasivas.Count)
							{
								if (mdlAltasMasivas.fncAsignaValoresAltaMasivaB(llcontador, sctaref))
								{
									if (fncAltaEjecutivoB())
									{
										llContOK++;
									}
								}
								frmAltasMasivas.DefInstance.lblNumRegistro[0].Text = llcontador.ToString();
								iFlood_1 = Convert.ToInt32(Math.Floor((llcontador / ((double) mdlParametros.gcarcAltasMasivas.Count)) * 100));
								frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent = (short) iFlood_1;
								if (frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent > 1)
								{
									frmAltasMasivas.DefInstance.pnlProgProceso[0].ForeColor = Color.White;
									mdlParametros.bColorCambiado = true;
								}
								Application.DoEvents();
								llcontador++;
							};
							//        Else
							//            MsgBox "No se genero de forma correcta la tabla MTCMSV01", vbCritical
							//        End If
							Application.DoEvents();
						} else
						{
							MessageBox.Show("Existen errores en los regisros del archivo que se proceso, revisar archivo Archivo_Errores.txt", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							mdlParametros.prQuitaObjetos();
							Application.DoEvents();
						}
						
						this.Cursor = Cursors.Default;
						this.Hide();
						MessageBox.Show("Se dieron de alta " + llContOK.ToString() + " Ejecutivos de " + mdlParametros.gcarcAltasMasivas.Count.ToString() + " que contiene el archivo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						
					}
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					mdlParametros.garcAltasMasivas = null;
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcarcAltasMasivas = null;
					
					mdlParametros.garcAltasMasivas = new clsArchivo();
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcarcAltasMasivas = new colcatArchivo();
                    double dou = VB6.TwipsToPixelsX(19200);
                    //(CORMDIBN.ScaleHeight - Me.Height) / 2
					this.Top = (int) ((CORMDIBN.DefInstance.ClientRectangle.Height - this.Height) / 2);
					this.Left = (int) ((CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2);
					PrimeraVez = true;
			}
			private void  frmAltasMasivas_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}

        private void frmAltasMasivas_Shown(object sender, EventArgs e)
        {
            activated();
        }

        private void cmnAltasMasivas_Enter(object sender, EventArgs e)
        {

        }
		}
}