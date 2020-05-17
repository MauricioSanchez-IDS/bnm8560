using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmEnvioLimCred
		: System.Windows.Forms.Form
		{
		
			private void  frmEnvioLimCred_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private Conecta.ConexionesHost _ConComDrive = null;
			Conecta.ConexionesHost ConComDrive
			{
				get
				{
					if (_ConComDrive == null)
					{
						_ConComDrive = new Conecta.ConexionesHost();
					}
					return _ConComDrive;
				}
				set
				{
					_ConComDrive = value;
				}
			}
			
			
			bool bmPrimTran = false;
			
			private void  cmdEliminar_Click( Object eventSender,  EventArgs eventArgs)
			{
					MSComctlLib.ListItem LstItemCuenta = null;
					int intPref = 0, intBanco = 0;
					
					try
					{
							this.Cursor = Cursors.WaitCursor;
							LstItemCuenta = (MSComctlLib.ListItem) LstvLimiteCredito.SelectedItem;
							mdlParametros.tgCambioLimCred.CtaBnxS = LstItemCuenta.Text;
							if (MdlCambioMasivo.FnMsgYesno("Eliminar la cuenta: " + mdlParametros.tgCambioLimCred.CtaBnxS))
							{
								
								mdlParametros.bgCamLimCred = true;
								
								if (VBSQL.OpenConn(10) != 0)
								{
									VBSQL.gConn[10].Close();
								} else
								{
									VBSQL.gConn[10].Close();
								}
								
								if (VBSQL.OpenConn(10) == 0)
								{
									
									CORVAR.pszgblsql = "DELETE ";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "From  MTCLIM01 Where lim_cta_bnx = '" + mdlParametros.tgCambioLimCred.CtaBnxS + "' ";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_usu_checker in (NULL,' ') ";
									object tempRefParam = "CreditoAnterior";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_cred_ant = " + Conversion.Val(StringsHelper.Format(Int32.Parse(LstItemCuenta.get_SubItems((short) LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam).SubItemIndex)), "############")).ToString();
									object tempRefParam2 = "CreditoActual";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_cred_post = " + Conversion.Val(StringsHelper.Format(Int32.Parse(LstItemCuenta.get_SubItems((short) LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam2).SubItemIndex)), "############")).ToString();
									object tempRefParam3 = "NominaEjecutivo";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_usu_maker = '" + LstItemCuenta.get_SubItems((short) LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam3).SubItemIndex) + "'";
									object tempRefParam4 = "NombreEjecutivo";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_nom_maker = '" + LstItemCuenta.get_SubItems((short) LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam4).SubItemIndex) + "'";
									object tempRefParam5 = "FechaCambio";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_fecha_maker = " + Conversion.Val(LstItemCuenta.get_SubItems((short) LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam5).SubItemIndex)).ToString();
									object tempRefParam6 = "HoraCambio";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_hora_maker = " + Conversion.Val(LstItemCuenta.get_SubItems((short) LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam6).SubItemIndex)).ToString();
									
									object tempRefParam7 = Type.Missing;
									VBSQL.gConn[10].Execute(CORVAR.pszgblsql, out tempRefParam7, -1);
									
									if (VBSQL.gConn[10].State == 1)
									{
										VBSQL.gConn[10].Close();
									}
								}
								
								this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
								this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
							}
							
							//    Me.LstvLimiteCredito.ListItems.Clear
                            //AIS-541 NGONZALEZ
                            mdlParametros.gclimEnvioLimite = null;
                            //AIS-541 NGONZALEZ
                            mdlParametros.gclimEnvioLimite = new colcatLimite();
							
							mdlParametros.gclimEnvioLimite.prObtenLimite();
							if (mdlParametros.gclimEnvioLimite.Count > 0)
							{
								prLlenaLista();
							} else
							{
								MessageBox.Show("No existen cambios de Limite de Credito para el producto seleccionado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
							
							this.Cursor = Cursors.Default;
						}
					catch 
					{
						//    prEnviaLimCred
						//    DoEvents
						//    Set gclimEnvioLimite = New colcatLimite
						//    lstLimiteCred.Clear
						//    gclimEnvioLimite.prObtenLimite
						//    If gclimEnvioLimite.Count > 0 Then
						//        prLlenaLista
						//        Set gclimEnvioLimite = Nothing
						//    Else
						//        MsgBox "No existen cambios de Limite de Credito para el producto seleccionado.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
						//        Set gclimEnvioLimite = Nothing
						//        Exit Sub
						//    End If
						
						string tempRefParam8 = "Tarjeta Corporativa.- cmdEnviaCred_Click";
						if (MdlCambioMasivo.fnGetError(ref tempRefParam8))
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume' not supported");
						}
						
						if (VBSQL.gConn[10].State == 1)
						{
							VBSQL.gConn[10].Close();
						}
					}
					
			}
			
			private void  cmdEnviaCred_Click( Object eventSender,  EventArgs eventArgs)
			{
					MSComctlLib.ListItem LstItemCuenta = null;
					
					try
					{
							this.Cursor = Cursors.WaitCursor;
							LstItemCuenta = (MSComctlLib.ListItem) LstvLimiteCredito.SelectedItem;
							mdlParametros.tgCambioLimCred.CtaBnxS = LstItemCuenta.Text;
							if (MdlCambioMasivo.FnMsgYesno("Aplicar el cambio para la cuenta: " + mdlParametros.tgCambioLimCred.CtaBnxS))
							{
								
								CORVAR.lgblEmpCve = StringsHelper.IntValue(Strings.Mid(mdlParametros.tgCambioLimCred.CtaBnxS, 7, mdlParametros.gprdProducto.LongitudEmpresaI));
								CORVAR.igblEjeNum = StringsHelper.IntValue(Strings.Mid(mdlParametros.tgCambioLimCred.CtaBnxS, 7 + mdlParametros.gprdProducto.LongitudEmpresaI, mdlParametros.gprdProducto.LongitudEjecutivoI));
								//UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to int.
								object tempRefParam = "CreditoActual";
								mdlParametros.tgCambioLimCred.LimCredL = Convert.ToInt32(MdlCambioMasivo.Nvl(LstItemCuenta.get_SubItems((short) LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam).SubItemIndex), 0));
								
								//tgCambioLimCred.LimCredL = CLng(Mid(lstLimiteCred.Text, 60, 20))
								object tempRefParam2 = "NominaEjecutivo";
								mdlParametros.sgUserCamLimCred = LstItemCuenta.get_SubItems((short) LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam2).SubItemIndex).Trim();
								mdlParametros.bgCamLimCred = true;
								CORMNEJE.DefInstance.Tag = "CAMBIO LIMITE DE CREDITO";
								CORMNEJE tempLoadForm = CORMNEJE.DefInstance;
								CORMNEJE.DefInstance.FormBorderStyle = FormBorderStyle.None;
								CORMNEJE.DefInstance.WindowState = FormWindowState.Minimized;
								//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
								CORMNEJE.DefInstance.ShowDialog();
                                //AIS-541 NGONZALEZ
                                mdlParametros.gclimEnvioLimite = null;
                                //AIS-541 NGONZALEZ
                                mdlParametros.gclimEnvioLimite = new colcatLimite();
								
								this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
								this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
								mdlParametros.gclimEnvioLimite.prObtenLimite();
							}
							
							if (mdlParametros.gclimEnvioLimite.Count > 0)
							{
								prLlenaLista();
							} else
							{
								MessageBox.Show("No existen cambios de Limite de Credito para el producto seleccionado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return;
							}
							
							this.Cursor = Cursors.Default;
						}
					catch 
					{
						//    prEnviaLimCred
						//    DoEvents
						//    Set gclimEnvioLimite = New colcatLimite
						//    lstLimiteCred.Clear
						//    gclimEnvioLimite.prObtenLimite
						//    If gclimEnvioLimite.Count > 0 Then
						//        prLlenaLista
						//        Set gclimEnvioLimite = Nothing
						//    Else
						//        MsgBox "No existen cambios de Limite de Credito para el producto seleccionado.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
						//        Set gclimEnvioLimite = Nothing
						//        Exit Sub
						//    End If
						
						string tempRefParam3 = "Tarjeta Corporativa.- cmdEnviaCred_Click";
						if (MdlCambioMasivo.fnGetError(ref tempRefParam3))
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume' not supported");
						}
					}
					
					
			}
			
			private void  cmdSalirCred_Click( Object eventSender,  EventArgs eventArgs)
			{
                //AIS-541 NGONZALEZ
                mdlParametros.gclimEnvioLimite = null;
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
                //AIS-541 NGONZALEZ
                mdlParametros.gclimEnvioLimite = new colcatLimite();
					
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					
					mdlParametros.gclimEnvioLimite.prObtenLimite();
					if (mdlParametros.gclimEnvioLimite.Count > 0)
					{
						prLlenaLista();
					} else
					{
						MessageBox.Show("No existen cambios de Limite de Credito para el producto seleccionado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					
					mdlParametros.gperPerfil.prHabilitaAcciones(frmEnvioLimCred.DefInstance);
			}
			
			private void  prLlenaLista()
			{
					
					string slCadenaIns = String.Empty;
					int llContador = 0;
					int llIndice = 0;
					MSComctlLib.ListItem LstItemCuenta = null;
					
					try
					{
							
							//lstLimiteCred.Clear
							llContador = 1;
							llIndice = 0;
							PrInicializaLCtrl();
							Application.DoEvents();
							if (mdlParametros.gclimEnvioLimite != null)
							{
								
								while(llContador <= mdlParametros.gclimEnvioLimite.Count)
								{
									object tempRefParam = Type.Missing;
									object tempRefParam2 = Type.Missing;
									object tempRefParam3 = Type.Missing;
									object tempRefParam4 = Type.Missing;
									object tempRefParam5 = Type.Missing;
									LstItemCuenta = (MSComctlLib.ListItem) LstvLimiteCredito.ListItems.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5);
									
									LstItemCuenta.Text = mdlParametros.gclimEnvioLimite[llContador].LimCtaBnxS;
									object tempRefParam6 = "CreditoAnterior";
									LstItemCuenta.set_SubItems(LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam6).SubItemIndex, StringsHelper.Format(mdlParametros.gclimEnvioLimite[llContador].LimCredAntL, "###,##0.00"));
									object tempRefParam7 = "CreditoActual";
									LstItemCuenta.set_SubItems(LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam7).SubItemIndex, StringsHelper.Format(mdlParametros.gclimEnvioLimite[llContador].LimCredPostL, "###,##0.00"));
									object tempRefParam8 = "NominaEjecutivo";
									LstItemCuenta.set_SubItems(LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam8).SubItemIndex, mdlParametros.gclimEnvioLimite[llContador].LimUsuMakerS);
									object tempRefParam9 = "NombreEjecutivo";
									LstItemCuenta.set_SubItems(LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam9).SubItemIndex, mdlParametros.gclimEnvioLimite[llContador].LimNomMakerS);
									object tempRefParam10 = "FechaCambio";
									LstItemCuenta.set_SubItems(LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam10).SubItemIndex, mdlParametros.gclimEnvioLimite[llContador].LimFechaMakerL.ToString());
									object tempRefParam11 = "HoraCambio";
									LstItemCuenta.set_SubItems(LstvLimiteCredito.ColumnHeaders.get_ControlDefault(ref tempRefParam11).SubItemIndex, mdlParametros.gclimEnvioLimite[llContador].LimHoraMakerL.ToString());
									Application.DoEvents();
									
									llContador++;
									llIndice++;
								};
							}
						}
                        catch (Exception e)
					{
						
						CRSGeneral.prObtenError("frmEnvioLimCred (LlenaLista)",e );
						return;
					}
			}
			
			//Private Sub prEnviaLimCred()
			//
			//On Error GoTo ErrEnviaLimCred
			//
			//'***** Nueva Conexion al S111 *****
			//    If ValidaCambioS111 = True Then
			//        Screen.MousePointer = DEFAULT
			//        If fncCargaComdriveB = True Then
			//            bgChecaUser = bgCamLimCred
			//            frmSeguridad.Show vbModal
			//        End If
			//    End If
			//'***** Nueva Conexion al S111 *****
			//
			//    If bgSeguridadS041 = True Then      'Si se pudo conectar
			//
			//        slDialogo = MODIFICA_CREDITO_EN_EJE & " "                   '5117
			//        slDialogo = slDialogo & tgCambioLimCred.CtaBnxS             'Numero de cuenta
			//        slDialogo = slDialogo & Str$(CCur(tgCambioLimCred.LimCredL))     'Limite de credito
			//
			//        pszMensaje = "Cambio de línea de crédito"
			//        CORMDIBN!ID_COR_MSG_TXT.Caption = "Realizando Cambio de Límite de Crédito"
			//
			//        slDialogo = "D" & slDialogo & Chr(3)
			//
			//        objSeguridad.SendRequest StrConv(slDialogo, vbFromUnicode), Len(slDialogo)
			//
			//        blContinue = True
			//        ilCont = 0
			//        slRespuesta = ""
			//        ilLongitudMsg = 10000
			//        Do
			//            slBloque = ""
			//            slBloque = StrConv(objSeguridad.ReceiveResponse(igTimeComDrive), vbUnicode)
			//
			//            If Mid(slBloque, 1, 1) = "H" And Len(slBloque) <> 13 Then
			//                slRespuesta = ""
			//                ilLongitudMsg = Val(Mid(slBloque, 3, 4))
			//                ilCont = 0
			//            End If
			//            slRespuesta = slRespuesta & slBloque
			//            If Err.Number <> 0 Then
			//                ilResultado = Err.Number
			//                slCausaError = Err.Description
			//                blContinue = False
			//            End If
			//            Err.Clear
			//            ilCont = ilCont + 1
			//        Loop While blContinue And ilLongitudMsg > Len(slRespuesta)
			//
			//        If CInt(Mid(slRespuesta, 3, 4)) = 13 Then
			//            slRespuesta = Mid(slRespuesta, 14)
			//        End If
			//
			//        Screen.MousePointer = DEFAULT
			//
			//        pszRegresaS111 = slRespuesta
			//
			//        If (InStr(pszRegresaS111, "Confirmado,Repita Transaccion") <> 0) Then
			//            mbPrimTran = True
			//            EnviaCambioS111 = False
			//            Exit Function
			//'        ElseIf Trim(pszRegresaS111) = "" Then
			//'            mbPrimTran = True
			//'            EnviaCambioS111 = False
			//'            Exit Function
			//        End If
			//
			//        If (InStr(pszRegresaS111, "TRANSACCION ACEPTADA") <> 0) Or _
			//'            (InStr(pszRegresaS111, "TRANSACCION  ACEPTADA") <> 0) Or _
			//'            (InStr(pszRegresaS111, "LINEA DE CREDITO ACTUALIZADA A") <> 0) Then
			//
			//            If (InStr(pszRegresaS111, "LINEA DE CREDITO ACTUALIZADA A") <> 0) Then
			//                MsgBox " " & Trim(Mid(pszRegresaS111, 11, 80)), vbExclamation, Me.Caption
			//            Else
			//                MsgBox "Transacción aceptada en S111 en " & pszMensaje, vbExclamation, Me.Caption
			//            End If
			//
			//        Else
			//            MsgBox "No se realizó la transacción en el S111 en " & pszMensaje & " " & Trim(Mid(pszRegresaS111, 11, 80)), vbCritical, Me.Caption
			//            EnviaCambioS111 = True
			//        End If
			//'    End If
			//
			//    Screen.MousePointer = HOURGLASS
			//
			//
			//
			//'    If fncVerificaConexionB(tcnxConComDriver) = True Then
			//'        CORACCOM.Show 1
			//'        If CORACCOM.Tag = "Aceptar" Then
			//'            llPassword = CLng(Trim(CORACCOM.ID_ACC_NOM_TXT.Text))
			//'            slUserName = Trim(CORACCOM.ID_ACC_CVE_TXT.Text)
			//'            If fncObtenNominaPassB(llPassword, slUserName) = True Then
			//'                Unload CORACCOM
			//'                If fncRealizaConexionB(tcnxConComDriver) = True Then
			//'                    If lstLimiteCred.ListIndex <> -1 Then
			//'                        tgCambioLimCred.CtaBnxS = CStr(Left(lstLimiteCred.Text, 16))
			//'                        tgCambioLimCred.LimCredL = CLng(Mid(lstLimiteCred.Text, 60, 20))
			//'                        If fncEnviaCambioLimCredB = True Then
			//'                            Exit Sub
			//'                        End If
			//'                    End If
			//'                Else
			//'                    Screen.MousePointer = vbDefault
			//'                    Exit Sub
			//'                End If
			//'            Else
			//'                Screen.MousePointer = vbDefault
			//'                Exit Sub
			//'            End If
			//'        Else
			//'            MsgBox "No se capturaron datos.", vbCritical + vbOKOnly, "Conexión S016"
			//'            Screen.MousePointer = vbDefault
			//'            Exit Sub
			//'        End If
			//'    Else
			//'        Screen.MousePointer = vbDefault
			//'        Exit Sub
			//'    End If
			//
			//
			//
			//
			//'*****  CODIGO CON CLASES  *****
			//'    llContador = 0
			//'    llIndice = 1
			//'    If fncVerificaConexionB(tcnxConComDriver) = True Then
			//'        CORACCOM.Show 1
			//'        If CORACCOM.Tag = "Aceptar" Then
			//'            If fncObtenNominaPassB(CLng(Trim(CORACCOM.ID_ACC_NOM_TXT.Text)), Trim(CORACCOM.ID_ACC_CVE_TXT.Text)) = True Then
			//'                Unload CORACCOM
			//'                If fncRealizaConexionB(tcnxConComDriver) = True Then
			//'                    Screen.MousePointer = vbHourglass
			//'                    MsgBox "Cont Coleccion " & gclimEnvioLimite.Count
			//'                    Do While llContador <= gclimEnvioLimite.Count - 1
			//'                        If lstLimiteCred.Selected(llContador) = True Then
			//'                            If fncEnviaCambioLimCredB(llIndice) = True Then
			//'                                MsgBox "Salida de fncEnviaCambioLimCredB"
			//'                                If fncActualizaLimCredB(llIndice) = True Then
			//'                                    MsgBox "Salida de fncActualizaLimCredB"
			//'                                    prActualizaTablaLim (llIndice)
			//'                                    llContador = llContador + 1
			//'                                    llIndice = llIndice + 1
			//'                                End If
			//'                            Else
			//'                                If bmPrimTran = True Then
			//'                                    bmPrimTran = False
			//'                                Else
			//'                                    llContador = llContador + 1
			//'                                    llIndice = llIndice + 1
			//'                                End If
			//'                            End If
			//'                        Else
			//'                            llContador = llContador + 1
			//'                            llIndice = llIndice + 1
			//'                        End If
			//'                    Loop
			//'                    prEliminaCnxConComDriveB taejAltaIndividual
			//'                    cnhConComDrive.Termina_Conexion
			//'                    Screen.MousePointer = vbDefault
			//'                Else
			//'                    Screen.MousePointer = vbDefault
			//'                    Exit Sub
			//'                End If
			//'            Else
			//'                Screen.MousePointer = vbDefault
			//'                Exit Sub
			//'            End If
			//'        Else
			//'            MsgBox "No se capturaron datos.", vbCritical + vbOKOnly, "Conexión S016"
			//'            Screen.MousePointer = vbDefault
			//'            Exit Sub
			//'        End If
			//'    Else
			//'        Screen.MousePointer = vbDefault
			//'        Exit Sub
			//'    End If
			//'*****  CODIGO CON CLASES  *****
			//
			//Exit Sub
			//ErrEnviaLimCred:
			//    prObtenError "frmEnvioLimCred (EnviaLimCred)"
			//    Exit Sub
			//End Sub
			
			//Private Function fncEnviaCambioLimCredB(lpIndice As Long) As Boolean
			//Private Function fncEnviaCambioLimCredB() As Boolean
			//
			//Dim slRespuestaS111 As String
			//Dim slCadena As String * 100
			//Dim slDialogoConComDrive    As String
			//Dim llID            As Long
			//
			//Dim slRespuestaCon  As String
			//Dim slRespAcc       As String
			//Dim slMensajeCon    As String
			//Dim ilPos           As Integer
			//
			//Dim blConexion      As Boolean
			//
			//Dim slRespConComDrive   As String
			//Dim slMensConComDrive   As String
			//Dim slDialogo           As String
			//
			//
			//On Error GoTo ErrEnviaCambioLimCred
			//
			//    fncEnviaCambioLimCredB = True
			//
			//    'Dialogo para la conexion
			//    Set gdlgConexionConComDrive = New clsDialogo
			//    gdlgConexionConComDrive.prGeneraDlg Nothing, tConexionConComdrive
			//    DoEvents
			//    slDialogoConComDrive = gdlgConexionConComDrive.DialogoS
			//    Set gdlgConexionConComDrive = Nothing
			//
			//    'Dialogo del Cambio de Limite de Credito
			//    Set gdlgDialogo = New clsDialogo
			//    DoEvents
			//    gdlgDialogo.prGeneraDlg Nothing, tCambioLimCredEjecutivos
			//    DoEvents
			//    slCadena = gdlgDialogo.DialogoS
			//    Set gdlgDialogo = Nothing
			//
			//    llID = Shell(sgPathComDrive, vbMinimizedNoFocus)
			//
			//    'ConComDrive.Class_Initialize
			//    ConComDrive.Tiempo = 15
			//
			//    If ConComDrive.Inicia_Conexion = True Then
			//        DoEvents
			//
			//        slRespuestaCon = ConComDrive.Envia_Mensaje(slDialogoConComDrive)
			//        DoEvents
			//        slMensajeCon = fncGeneraMensajeS(slRespuestaCon)
			//        ilPos = InStr(slRespuestaCon, "SEG:")
			//        If ilPos > 0 Then
			//            MsgBox " " & slMensajeCon, vbOKOnly + vbExclamation, "Tarjeta Corporativa"
			//            slRespuestaS111 = ConComDrive.Envia_Mensaje(slCadena)
			//            DoEvents
			//            If slRespuestaS111 = "" Then
			//                slRespuestaS111 = ConComDrive.Envia_Mensaje(slCadena)
			//                DoEvents
			//            End If
			//            slRespuestaS111 = fncGeneraMensajeS(slRespuestaS111)
			//            If (InStr(slRespuestaS111, "VUELVA A DARSE DE ALTA") <> 0) Or (InStr(slRespuestaS111, " FAVOR DE DARSE DE ALTA ") <> 0) Or (InStr(slRespuestaS111, "SERVICIO NO EXISTE") <> 0) Then
			//                If (InStr(slRespuestaS111, "SERVICIO NO EXISTE") <> 0) Then
			//                    MsgBox " " & slRespuestaS111 & " AVISE A SISTEMAS.", vbCritical, Me.Caption
			//                    fncEnviaCambioLimCredB = False
			//                Else
			//                    MsgBox " " & slRespuestaS111 & " E INICIE NUEVAMENTE EL PROCESO.", vbCritical, Me.Caption
			//                    fncEnviaCambioLimCredB = False
			//                End If
			//                fncEnviaCambioLimCredB = False
			//            End If
			//
			//            If (InStr(slRespuestaS111, "Confirmado,Repita Transaccion") <> 0) Then
			//                slRespuestaS111 = ConComDrive.Envia_Mensaje(slCadena)
			//                DoEvents
			//                If slRespuestaS111 = "" Then
			//                    slRespuestaS111 = ConComDrive.Envia_Mensaje(slCadena)
			//                    DoEvents
			//                End If
			//                slRespuestaS111 = fncGeneraMensajeS(slRespuestaS111)
			//                If (InStr(slRespuestaS111, "VUELVA A DARSE DE ALTA") <> 0) Or (InStr(slRespuestaS111, " FAVOR DE DARSE DE ALTA ") <> 0) Or (InStr(slRespuestaS111, "SERVICIO NO EXISTE") <> 0) Then
			//                    If (InStr(slRespuestaS111, "SERVICIO NO EXISTE") <> 0) Then
			//                        slDialogo = ctesFinalizaS111
			//                        slRespConComDrive = ConComDrive.Envia_Mensaje(slDialogo)
			//                        slMensConComDrive = fncGeneraMensajeS(slRespConComDrive)
			//                        DoEvents
			//                        DoEvents
			//                        If InStr(slMensConComDrive, "VUELVA A DARSE DE ALTA") <> 0 Then
			//                            MsgBox " " & slMensConComDrive, vbCritical, Me.Caption
			//                        End If
			//                        DoEvents
			//                        ConComDrive.Termina_Conexion
			//                        DoEvents
			//                        MsgBox " " & slRespuestaS111 & " AVISE A SISTEMAS.", vbCritical, Me.Caption
			//                        fncEnviaCambioLimCredB = False
			//                    Else
			//                        slDialogo = ctesFinalizaS111
			//                        slRespConComDrive = ConComDrive.Envia_Mensaje(slDialogo)
			//                        slMensConComDrive = fncGeneraMensajeS(slRespConComDrive)
			//                        DoEvents
			//                        DoEvents
			//                        If InStr(slMensConComDrive, "VUELVA A DARSE DE ALTA") <> 0 Then
			//                            MsgBox " " & slMensConComDrive, vbCritical, Me.Caption
			//                        End If
			//                        DoEvents
			//                        ConComDrive.Termina_Conexion
			//                        DoEvents
			//                        MsgBox " " & slRespuestaS111 & " E INICIE NUEVAMENTE EL PROCESO.", vbCritical, Me.Caption
			//                        fncEnviaCambioLimCredB = False
			//                    End If
			//                    fncEnviaCambioLimCredB = False
			//                End If
			//                If (InStr(slRespuestaS111, "LINEA DE CREDITO ACTUALIZADA A") <> 0) Then
			//                    MsgBox " " & slRespuestaS111 & " de la Cuenta " & tgCambioLimCred.CtaBnxS, vbExclamation, Me.Caption
			//                    If fncActualizaLimCredB = True Then
			//                        prActualizaTablaLim
			//                        slDialogo = ctesFinalizaS111
			//                        slRespConComDrive = ConComDrive.Envia_Mensaje(slDialogo)
			//                        slMensConComDrive = fncGeneraMensajeS(slRespConComDrive)
			//                        DoEvents
			//                        If InStr(slMensConComDrive, "VUELVA A DARSE DE ALTA") <> 0 Then
			//                            MsgBox " " & slMensConComDrive, vbCritical, Me.Caption
			//                        End If
			//                        ConComDrive.Termina_Conexion
			//                        DoEvents
			//                        lstLimiteCred.SetFocus
			//                    End If
			//                Else
			//                    slDialogo = ctesFinalizaS111
			//                    slRespConComDrive = ConComDrive.Envia_Mensaje(slDialogo)
			//                    slMensConComDrive = fncGeneraMensajeS(slRespConComDrive)
			//                    DoEvents
			//                    DoEvents
			//                    If InStr(slMensConComDrive, "VUELVA A DARSE DE ALTA") <> 0 Then
			//                        MsgBox " " & slMensConComDrive, vbCritical, Me.Caption
			//                    End If
			//                    DoEvents
			//                    ConComDrive.Termina_Conexion
			//                    DoEvents
			//                    MsgBox "No se realizó la transacción en el S111 en el Limite de Credito " & slRespuestaS111, vbCritical, Me.Caption
			//                    fncEnviaCambioLimCredB = False
			//                End If
			//            End If
			//            Exit Function
			//        Else
			//            MsgBox " " & slMensajeCon & Chr(13) & " FIN DEL PROCESO.", vbCritical + vbOKOnly, "Conexión ConComdrive"
			//            ConComDrive.Termina_Conexion
			//            DoEvents
			//            Exit Function
			//        End If
			//    Else
			//        MsgBox "No hay conexión, intente mas tarde. ", vbCritical + vbOKOnly, "Conexión S016"
			//        ConComDrive.Termina_Conexion
			//        DoEvents
			//        Exit Function
			//    End If
			//
			//
			//'    Else
			//'        fncEnviaCambioLimCredB = False
			//'        cnhConComDrive.Termina_Conexion
			//'        DoEvents
			//'    End If
			//
			//
			//'*****  CODIGO CON CLASES  *****
			//'    Screen.MousePointer = vbHourglass
			//
			//'    Set gdlgDialogo = New clsDialogo
			//
			//'    tgCambioLimCred.CtaBnxS = gclimEnvioLimite(lpIndice).LimCtaBnxS
			//'    tgCambioLimCred.LimCredL = gclimEnvioLimite(lpIndice).LimCredPostL
			//
			//'    gdlgDialogo.prGeneraDlg Nothing, tCambioLimCredEjecutivos
			//'    slCadena = gdlgDialogo.DialogoS
			//
			//'    slRespuestaS111 = cnhConComDrive.Envia_Mensaje(slCadena)
			//'    If slRespuestaS111 = "" Then
			//'        slRespuestaS111 = cnhConComDrive.Envia_Mensaje(slCadena)
			//'    End If
			//'    slRespuestaS111 = fncGeneraMensajeS(slRespuestaS111)
			//'    If (InStr(slRespuestaS111, "VUELVA A DARSE DE ALTA") <> 0) Or (InStr(slRespuestaS111, " FAVOR DE DARSE DE ALTA ") <> 0) Or (InStr(slRespuestaS111, "SERVICIO NO EXISTE") <> 0) Then
			//'        If (InStr(slRespuestaS111, "SERVICIO NO EXISTE") <> 0) Then
			//'            Set gdlgDialogo = Nothing
			//'            MsgBox " " & slRespuestaS111 & " AVISE A SISTEMAS.", vbCritical, Me.Caption
			//'            fncEnviaCambioLimCredB = False
			//'            Screen.MousePointer = vbDefault
			//'            Exit Function
			//'        Else
			//'            Set gdlgDialogo = Nothing
			//'            MsgBox " " & slRespuestaS111 & " E INICIE NUEVAMENTE EL PROCESO.", vbCritical, Me.Caption
			//'            fncEnviaCambioLimCredB = False
			//'            Screen.MousePointer = vbDefault
			//'            Exit Function
			//'        End If
			//'        Set gdlgDialogo = Nothing
			//'        fncEnviaCambioLimCredB = False
			//'        Screen.MousePointer = vbDefault
			//'        Exit Function
			//'    End If
			//'
			//'    If (InStr(slRespuestaS111, "Confirmado,Repita Transaccion") <> 0) Then
			//'        Set gdlgDialogo = Nothing
			//'        bmPrimTran = True
			//'        fncEnviaCambioLimCredB = False
			//'        Screen.MousePointer = vbDefault
			//'        Exit Function
			//'    End If
			//'
			//'    If (InStr(slRespuestaS111, "LINEA DE CREDITO ACTUALIZADA A") <> 0) Then
			//'        Set gdlgDialogo = Nothing
			//'        MsgBox " " & slRespuestaS111 & " de la Cuenta " & tgCambioLimCred.CtaBnxS, vbExclamation, Me.Caption
			//'        fncEnviaCambioLimCredB = True
			//'        Screen.MousePointer = vbDefault
			//'        Exit Function
			//'    Else
			//'        Set gdlgDialogo = Nothing
			//'        MsgBox "No se realizó la transacción en el S111 en el Limite de Credito " & slRespuestaS111, vbCritical, Me.Caption
			//'        fncEnviaCambioLimCredB = False
			//'        Screen.MousePointer = vbDefault
			//'        Exit Function
			//'    End If
			//'*****  CODIGO CON CLASES  *****
			//
			//Exit Function
			//ErrEnviaCambioLimCred:
			//    prObtenError "frmEnvioLimCred (EnviaCambioLimCred)"
			//    fncEnviaCambioLimCredB = False
			//    Exit Function
			//End Function
			
			//Public Function fncActualizaLimCredB(lpIndice As Long) As Boolean
			public bool fncActualizaLimCredB()
			{
					
					bool result = false;
					string slempresa = String.Empty;
					string slEje = String.Empty;
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							slempresa = Strings.Mid(mdlParametros.tgCambioLimCred.CtaBnxS, 7, mdlParametros.gprdProducto.LongitudEmpresaI);
							slEje = Strings.Mid(mdlParametros.tgCambioLimCred.CtaBnxS, 7 + mdlParametros.gprdProducto.LongitudEmpresaI, mdlParametros.gprdProducto.LongitudEjecutivoI);
							
							CORVAR.pszgblsql = "exec spUCamMasivosLimCred " + Conversion.Str(mdlParametros.tgCambioLimCred.LimCredL) + ",";
							CORVAR.pszgblsql = CORVAR.pszgblsql + mdlParametros.gprdProducto.PrefijoL.ToString() + "," + mdlParametros.gprdProducto.BancoL.ToString() + "," + slempresa + ",";
							CORVAR.pszgblsql = CORVAR.pszgblsql + slEje + ",'" + CRSParametros.sgUserID + "'";
							
							
							//*****  CODIGO CON CLASES  *****
							//    slEmpresa = Mid$(gclimEnvioLimite(lpIndice).LimCtaBnxS, 7, gprdProducto.LongitudEmpresaI)
							//    slEje = Mid$(gclimEnvioLimite(lpIndice).LimCtaBnxS, 7 + gprdProducto.LongitudEmpresaI, gprdProducto.LongitudEjecutivoI)
							
							//    pszgblsql = " Exec spUCamMasivosLimCred " & Str$(CCur(gclimEnvioLimite(lpIndice).LimCredPostL)) & ","
							//    pszgblsql = pszgblsql & gprdProducto.PrefijoL & "," & gprdProducto.BancoL & "," & slEmpresa & ","
							//    pszgblsql = pszgblsql & slEje & ",'" & sgUserID & "'"
							//*****  CODIGO CON CLASES  *****
							
							if (CORPROC2.Modifica_Registro() != 0)
							{
								Application.DoEvents();
								result = true;
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								this.Cursor = Cursors.Default;
								return result;
							} else
							{
								MessageBox.Show("No se modificó el Limite de Credito del ejecutivo " + StringsHelper.Format(slEje, mdlParametros.gprdProducto.MascaraEjecutivoS) + " en el M111", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								result = false;
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								this.Cursor = Cursors.Default;
								return result;
							}
						}
                        catch (Exception e)
					{
						
						CRSGeneral.prObtenError("frmEnvioLimCred (ActualizaLimCred)",e );
						result = false;
						this.Cursor = Cursors.Default;
						return result;
					}
					
					return result;
			}
			
			//Public Sub prActualizaTablaLim(lpIndice As Long)
			//
			//On Error GoTo ActualizaTablaLim
			//
			//    Screen.MousePointer = vbHourglass
			//
			//    pszgblsql = "update"
			//    pszgblsql = pszgblsql & " MTCLIM01"
			//    pszgblsql = pszgblsql & " set"
			//    pszgblsql = pszgblsql & " lim_usu_checker = '" & sgUserID & "', "
			//    pszgblsql = pszgblsql & " lim_nom_checker = '" & sgUserName & "', "
			//    pszgblsql = pszgblsql & " lim_fecha_checker= convert(int,convert(char(20),getdate(),112)), "
			//    pszgblsql = pszgblsql & " lim_hora_checker = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))"
			//    pszgblsql = pszgblsql & " where lim_cta_bnx = '" & tgCambioLimCred.CtaBnxS & "'"
			//    pszgblsql = pszgblsql & " and lim_cred_post = " & tgCambioLimCred.LimCredL
			//
			//    If Modifica_Registro Then
			//    End If
			//
			//    Screen.MousePointer = vbDefault
			//
			//Exit Sub
			//ActualizaTablaLim:
			//    prObtenError "frmEnvioLimCred (ActualizaTablaLim)"
			//    Screen.MousePointer = vbDefault
			//    Exit Sub
			//End Sub
			//
			private void  PrInicializaLCtrl()
			{
					LstvLimiteCredito.View = MSComctlLib.ListViewConstants.lvwReport;
					LstvLimiteCredito.GridLines = false;
					LstvLimiteCredito.MultiSelect = false;
					LstvLimiteCredito.FullRowSelect = true;
					LstvLimiteCredito.ColumnHeaders.Clear();
					LstvLimiteCredito.LabelWrap = true;
					
					object tempRefParam = Type.Missing;
					object tempRefParam2 = "NoCuenta";
					object tempRefParam3 = "No. de Cuenta";
					object tempRefParam4 = VB6.PixelsToTwipsX(CreateGraphics().MeasureString(new string('M', 16), Font).Width);
					object tempRefParam5 = Type.Missing;
					object tempRefParam6 = Type.Missing;
					LstvLimiteCredito.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					object tempRefParam7 = Type.Missing;
					object tempRefParam8 = "CreditoAnterior";
					object tempRefParam9 = "Limite de Credito Anterior";
					object tempRefParam10 = VB6.PixelsToTwipsX(CreateGraphics().MeasureString("Limite de Credito Anterior", Font).Width) + 5;
					object tempRefParam11 = 1;
					object tempRefParam12 = Type.Missing;
					LstvLimiteCredito.ColumnHeaders.Add(ref tempRefParam7, ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12);
					object tempRefParam13 = Type.Missing;
					object tempRefParam14 = "CreditoActual";
					object tempRefParam15 = "Limite de Credito Nuevo";
					object tempRefParam16 = VB6.PixelsToTwipsX(CreateGraphics().MeasureString("Limite de Credito Nuevo", Font).Width) + 5;
					object tempRefParam17 = 1;
					object tempRefParam18 = Type.Missing;
					LstvLimiteCredito.ColumnHeaders.Add(ref tempRefParam13, ref tempRefParam14, ref tempRefParam15, ref tempRefParam16, ref tempRefParam17, ref tempRefParam18);
					object tempRefParam19 = Type.Missing;
					object tempRefParam20 = "NominaEjecutivo";
					object tempRefParam21 = "Nomina del Ejecutivo";
					object tempRefParam22 = VB6.PixelsToTwipsX(CreateGraphics().MeasureString("Nomina del Ejecutivo", Font).Width) + 5;
					object tempRefParam23 = Type.Missing;
					object tempRefParam24 = Type.Missing;
					LstvLimiteCredito.ColumnHeaders.Add(ref tempRefParam19, ref tempRefParam20, ref tempRefParam21, ref tempRefParam22, ref tempRefParam23, ref tempRefParam24);
					object tempRefParam25 = Type.Missing;
					object tempRefParam26 = "NombreEjecutivo";
					object tempRefParam27 = "Nombre del Ejecutivo";
					object tempRefParam28 = VB6.PixelsToTwipsX(CreateGraphics().MeasureString("Nombre del Ejecutivo", Font).Width) + 5;
					object tempRefParam29 = Type.Missing;
					object tempRefParam30 = Type.Missing;
					LstvLimiteCredito.ColumnHeaders.Add(ref tempRefParam25, ref tempRefParam26, ref tempRefParam27, ref tempRefParam28, ref tempRefParam29, ref tempRefParam30);
					object tempRefParam31 = Type.Missing;
					object tempRefParam32 = "FechaCambio";
					object tempRefParam33 = "Fecha de Cambio";
					object tempRefParam34 = VB6.PixelsToTwipsX(CreateGraphics().MeasureString("Fecha de Cambio", Font).Width) + 5;
					object tempRefParam35 = Type.Missing;
					object tempRefParam36 = Type.Missing;
					LstvLimiteCredito.ColumnHeaders.Add(ref tempRefParam31, ref tempRefParam32, ref tempRefParam33, ref tempRefParam34, ref tempRefParam35, ref tempRefParam36);
					object tempRefParam37 = Type.Missing;
					object tempRefParam38 = "HoraCambio";
					object tempRefParam39 = "Hora de Cambio";
					object tempRefParam40 = VB6.PixelsToTwipsX(CreateGraphics().MeasureString("Hora de Cambio", Font).Width) + 5;
					object tempRefParam41 = Type.Missing;
					object tempRefParam42 = Type.Missing;
					LstvLimiteCredito.ColumnHeaders.Add(ref tempRefParam37, ref tempRefParam38, ref tempRefParam39, ref tempRefParam40, ref tempRefParam41, ref tempRefParam42);
					LstvLimiteCredito.ListItems.Clear();
					
			}
			
			private void  LstvLimiteCredito_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					KeyAscii = 0;
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			private void  frmEnvioLimCred_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}