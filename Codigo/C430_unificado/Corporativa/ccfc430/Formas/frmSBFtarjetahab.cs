using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frm_SBF_tarjetahab
		: System.Windows.Forms.Form
		{
		
			bool blbandera = false;
			
			private void  cmdConsTran_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Cursor = Cursors.WaitCursor;
					//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
					frmSBFtransacciones.DefInstance.ShowDialog();
			}
			
			private void  cmdSBFsalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			private void  frm_SBF_tarjetahab_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						
						if (! blbandera)
						{
							this.Close();
						}
						
					}
			}
			
			private void  Form_Initialize_Renamed()
			{
					this.Cursor = Cursors.WaitCursor;
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					//---Ariadna---
					//Cuando el envío de SBF es diario:
					if (mdlParametros.IgEnvioSBF == 2)
					{
						sprSBFtarjetahab.Col = 4;
						sprSBFtarjetahab.ColHidden = true;
						sprSBFtarjetahab.Col = 5;
						sprSBFtarjetahab.ColHidden = true;
						
						sprSBFtarjetahab.Width = (int) VB6.TwipsToPixelsX(9000);
						sprSBFtarjetahab.Left = (int) VB6.TwipsToPixelsX(1000);
					}
					
					mdlParametros.gccrpCorporativo = new colCatCorporativos();
					mdlParametros.gcrpCorporativo = new clsCorporativo();
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcestResumen = new colEstatusEnvio();
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcsbfEjecutivoSBF = new colcatSBFEjecutivo();
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcsbfEjecutivoC430 = new colcatSBFEjecutivo();
					
					mdlParametros.gcsbfEjecutivoSBF.prObtenEjecutivo(clsSBFEjecutivo.enuTipoSBFEjecutivo.tsbfEjecutivoSBF);
					mdlParametros.gcsbfEjecutivoC430.prObtenEjecutivo(clsSBFEjecutivo.enuTipoSBFEjecutivo.tsbfEjecutivoC430);
					
					this.Height = (int) VB6.TwipsToPixelsY(4485);
					this.Width = (int) VB6.TwipsToPixelsX(10965);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					
					prLlenaSpreadTh();
					
					this.Cursor = Cursors.Default;
			}
			
			private void  prLlenaSpreadTh()
			{
					bool bRegC430Existe = false, bContinuaLlenado = false, bRegSBFExiste = false;
					string sCuentaSBF = String.Empty, sCuentaC430 = String.Empty;
					
					if ((mdlParametros.gcsbfEjecutivoSBF.Count > 0) || (mdlParametros.gcsbfEjecutivoC430.Count > 0))
					{
						bContinuaLlenado = true;
						blbandera = true;
					} else
					{
						bContinuaLlenado = false;
					}
					int llRow = 1;
					int iContSBF = 1;
					int iContC430 = 1;
					sprSBFtarjetahab.MaxRows = 0;
					
					while(bContinuaLlenado)
					{
						bRegSBFExiste = iContSBF <= mdlParametros.gcsbfEjecutivoSBF.Count;
						bRegC430Existe = iContC430 <= mdlParametros.gcsbfEjecutivoC430.Count;
						sprSBFtarjetahab.MaxRows++;
						sprSBFtarjetahab.Row = llRow;
						if (bRegSBFExiste && bRegC430Existe)
						{
							sCuentaSBF = mdlParametros.gprdProducto.PrefijoL.ToString() + mdlParametros.gprdProducto.BancoL.ToString() + StringsHelper.Format(mdlParametros.gcsbfEjecutivoSBF[iContSBF].EmpNumL, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(mdlParametros.gcsbfEjecutivoSBF[iContSBF].EjeNumL, Formato.sMascara(Formato.iTipo.Ejecutivo)) + mdlParametros.gcsbfEjecutivoSBF[iContSBF].RollOverI.ToString() + mdlParametros.gcsbfEjecutivoSBF[iContSBF].DigitoVerifI.ToString();
							sCuentaC430 = mdlParametros.gprdProducto.PrefijoL.ToString() + mdlParametros.gprdProducto.BancoL.ToString() + StringsHelper.Format(mdlParametros.gcsbfEjecutivoC430[iContC430].EmpNumL, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(mdlParametros.gcsbfEjecutivoC430[iContC430].EjeNumL, Formato.sMascara(Formato.iTipo.Ejecutivo)) + mdlParametros.gcsbfEjecutivoC430[iContC430].RollOverI.ToString() + mdlParametros.gcsbfEjecutivoC430[iContC430].DigitoVerifI.ToString();
							if (sCuentaSBF == sCuentaC430)
							{
								for (int llCol = 1; llCol <= 5; llCol++)
								{
									sprSBFtarjetahab.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFtarjetahab.Text = "SBF"; 
											break;
										case 2 : 
											sprSBFtarjetahab.Text = sCuentaSBF;  //CStr(gprdProducto.PrefijoL) + CStr(gprdProducto.BancoL) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EmpNumL, sMascara(Empresa))) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EjeNumL, sMascara(Ejecutivo))) + CStr(gcsbfEjecutivoSBF.Item(ilItem).RollOverI) & CStr(gcsbfEjecutivoSBF.Item(ilItem).DigitoVerifI) 
											break;
										case 3 : 
											sprSBFtarjetahab.Text = mdlParametros.gcsbfEjecutivoSBF[iContSBF].EjeNomS; 
											break;
										case 4 : 
											sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoSBF[iContSBF].SaldoActualD, ".00"); 
											break;
										case 5 : 
											sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoSBF[iContSBF].SaldoAnteriorD, ".00"); 
											break;
									}
								}
								llRow++;
								sprSBFtarjetahab.MaxRows++;
								sprSBFtarjetahab.Row = llRow;
								for (int llCol = 1; llCol <= 5; llCol++)
								{
									sprSBFtarjetahab.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFtarjetahab.Text = "C430"; 
											break;
										case 2 : 
											sprSBFtarjetahab.Text = sCuentaC430;  //CStr(gprdProducto.PrefijoL) + CStr(gprdProducto.BancoL) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EmpNumL, sMascara(Empresa))) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EjeNumL, sMascara(Ejecutivo))) + CStr(gcsbfEjecutivoSBF.Item(ilItem).RollOverI) & CStr(gcsbfEjecutivoSBF.Item(ilItem).DigitoVerifI) 
											break;
										case 3 : 
											sprSBFtarjetahab.Text = mdlParametros.gcsbfEjecutivoC430[iContC430].EjeNomS; 
											break;
										case 4 : 
											sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoC430[iContC430].SaldoActualD, ".00"); 
											break;
										case 5 : 
											sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoC430[iContC430].SaldoAnteriorD, ".00"); 
											break;
									}
								}
								iContSBF++;
								iContC430++;
							} else if (String.CompareOrdinal(sCuentaSBF, sCuentaC430) < 0) { 
								for (int llCol = 1; llCol <= 5; llCol++)
								{
									sprSBFtarjetahab.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFtarjetahab.Text = "SBF"; 
											break;
										case 2 : 
											sprSBFtarjetahab.Text = sCuentaSBF;  //CStr(gprdProducto.PrefijoL) + CStr(gprdProducto.BancoL) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EmpNumL, sMascara(Empresa))) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EjeNumL, sMascara(Ejecutivo))) + CStr(gcsbfEjecutivoSBF.Item(ilItem).RollOverI) & CStr(gcsbfEjecutivoSBF.Item(ilItem).DigitoVerifI) 
											break;
										case 3 : 
											sprSBFtarjetahab.Text = mdlParametros.gcsbfEjecutivoSBF[iContSBF].EjeNomS; 
											break;
										case 4 : 
											sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoSBF[iContSBF].SaldoActualD, ".00"); 
											break;
										case 5 : 
											sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoSBF[iContSBF].SaldoAnteriorD, ".00"); 
											break;
									}
								}
								iContSBF++;
							} else if (String.CompareOrdinal(sCuentaSBF, sCuentaC430) > 0) { 
								for (int llCol = 1; llCol <= 5; llCol++)
								{
									sprSBFtarjetahab.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFtarjetahab.Text = "C430"; 
											break;
										case 2 : 
											sprSBFtarjetahab.Text = sCuentaC430;  //CStr(gprdProducto.PrefijoL) + CStr(gprdProducto.BancoL) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EmpNumL, sMascara(Empresa))) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EjeNumL, sMascara(Ejecutivo))) + CStr(gcsbfEjecutivoSBF.Item(ilItem).RollOverI) & CStr(gcsbfEjecutivoSBF.Item(ilItem).DigitoVerifI) 
											break;
										case 3 : 
											sprSBFtarjetahab.Text = mdlParametros.gcsbfEjecutivoC430[iContC430].EjeNomS; 
											break;
										case 4 : 
											sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoC430[iContC430].SaldoActualD, ".00"); 
											break;
										case 5 : 
											sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoC430[iContC430].SaldoAnteriorD, ".00"); 
											break;
									}
								}
								iContC430++;
							}
							
						} else if (bRegSBFExiste) { 
							for (int llCol = 1; llCol <= 5; llCol++)
							{
								sprSBFtarjetahab.Col = llCol;
								switch(llCol)
								{
									case 1 : 
										sprSBFtarjetahab.Text = "SBF"; 
										break;
									case 2 : 
										sprSBFtarjetahab.Text = sCuentaSBF;  //CStr(gprdProducto.PrefijoL) + CStr(gprdProducto.BancoL) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EmpNumL, sMascara(Empresa))) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EjeNumL, sMascara(Ejecutivo))) + CStr(gcsbfEjecutivoSBF.Item(ilItem).RollOverI) & CStr(gcsbfEjecutivoSBF.Item(ilItem).DigitoVerifI) 
										break;
									case 3 : 
										sprSBFtarjetahab.Text = mdlParametros.gcsbfEjecutivoSBF[iContSBF].EjeNomS; 
										break;
									case 4 : 
										sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoSBF[iContSBF].SaldoActualD, ".00"); 
										break;
									case 5 : 
										sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoSBF[iContSBF].SaldoAnteriorD, ".00"); 
										break;
								}
							}
							iContSBF++;
						} else if (bRegC430Existe) { 
							for (int llCol = 1; llCol <= 5; llCol++)
							{
								sprSBFtarjetahab.Col = llCol;
								switch(llCol)
								{
									case 1 : 
										sprSBFtarjetahab.Text = "C430"; 
										break;
									case 2 : 
										sprSBFtarjetahab.Text = sCuentaC430;  //CStr(gprdProducto.PrefijoL) + CStr(gprdProducto.BancoL) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EmpNumL, sMascara(Empresa))) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EjeNumL, sMascara(Ejecutivo))) + CStr(gcsbfEjecutivoSBF.Item(ilItem).RollOverI) & CStr(gcsbfEjecutivoSBF.Item(ilItem).DigitoVerifI) 
										break;
									case 3 : 
										sprSBFtarjetahab.Text = mdlParametros.gcsbfEjecutivoC430[iContC430].EjeNomS; 
										break;
									case 4 : 
										sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoC430[iContC430].SaldoActualD, ".00"); 
										break;
									case 5 : 
										sprSBFtarjetahab.Text = StringsHelper.Format(mdlParametros.gcsbfEjecutivoC430[iContC430].SaldoAnteriorD, ".00"); 
										break;
								}
							}
							iContC430++;
						} else if (! bRegSBFExiste && ! bRegC430Existe) { 
							bContinuaLlenado = false;
						}
						llRow++;
					};
					
					//Dim llRow As Long
					//Dim llCol As Long
					//Dim ilRes, ilItem, ilItemAux As Integer
					//
					//
					//    llRow = 1
					//    ilItem = 1
					//
					//    ilItemAux = 1
					//
					//    sprSBFtarjetahab.MaxRows = 0
					//
					//    ilRes = gcsbfEjecutivoSBF.Count + gcsbfEjecutivoC430.Count + 1
					//
					//
					//
					//'    If (gcsbfEjecutivoSBF.Count <> gcsbfEjecutivoC430.Count) Then
					//'        MsgBox "No concuerda el número de registros entre SBF y C430 con respecto a los ejecutivos de la empresa elegida", vbInformation + vbOKOnly, App.Title
					//'        blbandera = False
					//'    Else
					//
					//        If gcsbfEjecutivoSBF.Count > 0 Then
					//            blbandera = True
					//
					//            Do Until llRow = ilRes
					//
					//
					//'                If (gcsbfEjecutivoSBF.Item(ilItem).EmpNumL = sgFiltroEmpresa Or _
					//''                gcsbfEjecutivoC430.Item(ilItemAux).EmpNumL = sgFiltroEmpresa) Then
					//
					//
					//                    sprSBFtarjetahab.MaxRows = sprSBFtarjetahab.MaxRows + 1
					//
					//                    sprSBFtarjetahab.Row = llRow
					//
					//        '            If ilItem > gcsbfEjecutivoSBF.Count Then
					//        '                Exit Do
					//        '            End If
					//                    If ((llRow Mod 2 = 0) And (llRow / 2 <= gcsbfEjecutivoC430.Count)) Or ((llRow Mod 2 <> 0) And (llRow / 2 <= gcsbfEjecutivoSBF.Count)) Then
					//                        For llCol = 1 To 5
					//                            sprSBFtarjetahab.Col = llCol
					//
					//                            Select Case llCol
					//                                Case 1
					//                                    If llRow Mod 2 <> 0 Then
					//                                        sprSBFtarjetahab.Text = "SBF"
					//                                    End If
					//                                    If llRow Mod 2 = 0 Then
					//                                        sprSBFtarjetahab.Text = "C430"
					//                                    End If
					//                                Case 2
					//                                    If llRow Mod 2 <> 0 Then
					//                                        sprSBFtarjetahab.Text = CStr(gprdProducto.PrefijoL) + CStr(gprdProducto.BancoL) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EmpNumL, sMascara(Empresa))) + CStr(Format(gcsbfEjecutivoSBF.Item(ilItem).EjeNumL, sMascara(Ejecutivo))) + CStr(gcsbfEjecutivoSBF.Item(ilItem).RollOverI) & CStr(gcsbfEjecutivoSBF.Item(ilItem).DigitoVerifI)
					//                                    End If
					//                                    If llRow Mod 2 = 0 Then
					//                                        sprSBFtarjetahab.Text = CStr(gprdProducto.PrefijoL) + CStr(gprdProducto.BancoL) + CStr(Format(gcsbfEjecutivoC430.Item(ilItem).EmpNumL, sMascara(Empresa))) + CStr(Format(gcsbfEjecutivoC430.Item(ilItem).EjeNumL, sMascara(Ejecutivo))) + CStr(gcsbfEjecutivoC430.Item(ilItem).RollOverI) & CStr(gcsbfEjecutivoC430.Item(ilItem).DigitoVerifI)
					//                                    End If
					//                                Case 3
					//                                    If llRow Mod 2 <> 0 Then
					//                                        sprSBFtarjetahab.Text = gcsbfEjecutivoSBF.Item(ilItem).EjeNomS
					//                                    End If
					//                                    If llRow Mod 2 = 0 Then
					//                                        sprSBFtarjetahab.Text = gcsbfEjecutivoC430.Item(ilItem).EjeNomS
					//                                    End If
					//                                Case 4
					//                                    If llRow Mod 2 <> 0 Then
					//                                        sprSBFtarjetahab.Text = Format(gcsbfEjecutivoSBF.Item(ilItem).SaldoActualD, ".00")
					//                                    End If
					//                                    If llRow Mod 2 = 0 Then
					//                                        sprSBFtarjetahab.Text = Format(gcsbfEjecutivoC430.Item(ilItem).SaldoActualD, ".00")
					//                                    End If
					//                                Case 5
					//                                    If llRow Mod 2 <> 0 Then
					//                                        sprSBFtarjetahab.Text = Format(gcsbfEjecutivoSBF.Item(ilItem).SaldoAnteriorD, ".00")
					//                                    End If
					//                                    If llRow Mod 2 = 0 Then
					//                                        sprSBFtarjetahab.Text = Format(gcsbfEjecutivoC430.Item(ilItem).SaldoAnteriorD, ".00")
					//                                    End If
					//                            End Select
					//                        Next llCol
					//
					//    '                End If
					//
					//                        If llRow Mod 2 = 0 Then
					//                            ilItem = ilItem + 1
					//                            ilItemAux = ilItemAux + 1
					//                        End If
					//                    End If
					//                    llRow = llRow + 1
					//            Loop
					//        Else
					//            MsgBox "No existe información acerca de los tarjetahabientes pertenecientes a la empresa elegida", vbInformation + vbOKOnly, App.Title
					//            blbandera = False
					//
					//        End If
					//
					//'    End If
					
			}
			
			
			private void  frm_SBF_tarjetahab_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}

            private void fpSBFtarjetahab_Click(object sender, EventArgs e)
            {
                int llCol = sprSBFtarjetahab.ActiveColumn;
                int llRow = sprSBFtarjetahab.ActiveRow;
                cmdConsTran.Enabled = true;

                object tempRefParam = mdlParametros.vgFiltroEje;
                sprSBFtarjetahab.GetText(2, llRow, ref tempRefParam);
                object tempRefParam2 = mdlParametros.vgNombreEje;
                sprSBFtarjetahab.GetText(3, llRow, ref tempRefParam2);

                int IlPrefijo = mdlParametros.gprdProducto.LongitudPrefijoL;
                int IlBanco = mdlParametros.gprdProducto.LongitudBancoL;
                int IlLongEmp = mdlParametros.gprdProducto.LongitudEmpresaI;
                int IlLongEje = mdlParametros.gprdProducto.LongitudEjecutivoI;

                mdlParametros.sgFiltroEjecutivo = Conversion.Val(Strings.Mid(mdlParametros.vgFiltroEje, IlPrefijo + IlBanco + IlLongEmp + 1, IlLongEje)).ToString();
                Label1.Text = mdlParametros.sgFiltroEjecutivo;
					
            }
		}
}