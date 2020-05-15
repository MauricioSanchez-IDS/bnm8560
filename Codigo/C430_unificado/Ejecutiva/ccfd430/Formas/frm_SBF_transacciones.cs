using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmSBFtransacciones
		: System.Windows.Forms.Form
		{
		
			bool blbandera = false;
			
			private void  cmdSBFsalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			private void  frmSBFtransacciones_Activated( Object eventSender,  EventArgs eventArgs)
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
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					//    If IgEnvioSBF = 2 Then
					//        sprSBFtransacciones.Col = 6
					//        sprSBFtransacciones.ColHidden = True
					//
					//        sprSBFtransacciones.Width = 8000
					//        sprSBFtransacciones.Left = 800
					//
					//    End If
					
					mdlParametros.gccrpCorporativo = new colCatCorporativos();
					mdlParametros.gcrpCorporativo = new clsCorporativo();
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcestResumen = new colEstatusEnvio();

                    //AIS-541 NGONZALEZ
                    mdlParametros.gcsbfTransaccionSBF = new colcatSBFTransaccion();
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcsbfTransaccionC430 = new colcatSBFTransaccion();
					
					mdlParametros.gcsbfTransaccionSBF.prObtenTransaccion(clsSBFTransaccion.enuTipoSBFTransaccion.tsbfTransaccionSBF);
					mdlParametros.gcsbfTransaccionC430.prObtenTransaccion(clsSBFTransaccion.enuTipoSBFTransaccion.tsbfTransaccionC430);
					
					Label4.Text = mdlParametros.vgFiltroEje;
					Label2.Text = mdlParametros.vgNombreEje;
					
					
					this.Height = (int) VB6.TwipsToPixelsY(4485);
					this.Width = (int) VB6.TwipsToPixelsX(10965);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					
					prLlenaSpreadTran();
					
					this.Cursor = Cursors.Default;
			}
			
			private void  prLlenaSpreadTran()
			{
					bool bRegC430Existe = false, bContinuaLlenado = false, bRegSBFExiste = false;
					int lFecProcSBF = 0, lFecProcC430 = 0;
					
					if ((mdlParametros.gcsbfTransaccionSBF.Count > 0) || (mdlParametros.gcsbfTransaccionC430.Count > 0))
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
					sprSBFtransacciones.MaxRows = 0;
					
					while(bContinuaLlenado)
					{
						bRegSBFExiste = iContSBF <= mdlParametros.gcsbfTransaccionSBF.Count;
						bRegC430Existe = iContC430 <= mdlParametros.gcsbfTransaccionC430.Count;
						sprSBFtransacciones.MaxRows++;
						sprSBFtransacciones.Row = llRow;
						if (bRegSBFExiste && bRegC430Existe)
						{
							lFecProcSBF = mdlParametros.gcsbfTransaccionSBF[iContSBF].FProcesoL;
							lFecProcC430 = mdlParametros.gcsbfTransaccionC430[iContC430].FProcesoL;
							if (lFecProcSBF == lFecProcC430)
							{
								for (int llCol = 1; llCol <= 6; llCol++)
								{
									sprSBFtransacciones.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFtransacciones.Text = "SBF"; 
											break;
										case 2 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].FProcesoL.ToString(); 
											break;
										case 3 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].FValorL.ToString(); 
											break;
										case 4 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].CveTransS; 
											break;
										case 5 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].DescTransS; 
											break;
										case 6 : 
											sprSBFtransacciones.Text = StringsHelper.Format(mdlParametros.gcsbfTransaccionSBF[iContSBF].ImporteD, ".00"); 
											break;
									}
								}
								llRow++;
								sprSBFtransacciones.MaxRows++;
								sprSBFtransacciones.Row = llRow;
								for (int llCol = 1; llCol <= 6; llCol++)
								{
									sprSBFtransacciones.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFtransacciones.Text = "C430"; 
											break;
										case 2 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].FProcesoL.ToString(); 
											break;
										case 3 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].FValorL.ToString(); 
											break;
										case 4 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].CveTransS; 
											break;
										case 5 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].DescTransS; 
											break;
										case 6 : 
											sprSBFtransacciones.Text = StringsHelper.Format(mdlParametros.gcsbfTransaccionC430[iContC430].ImporteD, ".00"); 
											break;
									}
								}
								iContSBF++;
								iContC430++;
							} else if (lFecProcSBF < lFecProcC430) { 
								for (int llCol = 1; llCol <= 6; llCol++)
								{
									sprSBFtransacciones.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFtransacciones.Text = "SBF"; 
											break;
										case 2 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].FProcesoL.ToString(); 
											break;
										case 3 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].FValorL.ToString(); 
											break;
										case 4 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].CveTransS; 
											break;
										case 5 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].DescTransS; 
											break;
										case 6 : 
											sprSBFtransacciones.Text = StringsHelper.Format(mdlParametros.gcsbfTransaccionSBF[iContSBF].ImporteD, ".00"); 
											break;
									}
								}
								iContSBF++;
							} else if (lFecProcSBF > lFecProcC430) { 
								for (int llCol = 1; llCol <= 6; llCol++)
								{
									sprSBFtransacciones.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFtransacciones.Text = "C430"; 
											break;
										case 2 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].FProcesoL.ToString(); 
											break;
										case 3 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].FValorL.ToString(); 
											break;
										case 4 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].CveTransS; 
											break;
										case 5 : 
											sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].DescTransS; 
											break;
										case 6 : 
											sprSBFtransacciones.Text = StringsHelper.Format(mdlParametros.gcsbfTransaccionC430[iContC430].ImporteD, ".00"); 
											break;
									}
								}
								iContC430++;
							}
							
						} else if (bRegSBFExiste) { 
							for (int llCol = 1; llCol <= 6; llCol++)
							{
								sprSBFtransacciones.Col = llCol;
								switch(llCol)
								{
									case 1 : 
										sprSBFtransacciones.Text = "SBF"; 
										break;
									case 2 : 
										sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].FProcesoL.ToString(); 
										break;
									case 3 : 
										sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].FValorL.ToString(); 
										break;
									case 4 : 
										sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].CveTransS; 
										break;
									case 5 : 
										sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionSBF[iContSBF].DescTransS; 
										break;
									case 6 : 
										sprSBFtransacciones.Text = StringsHelper.Format(mdlParametros.gcsbfTransaccionSBF[iContSBF].ImporteD, ".00"); 
										break;
								}
							}
							iContSBF++;
						} else if (bRegC430Existe) { 
							for (int llCol = 1; llCol <= 6; llCol++)
							{
								sprSBFtransacciones.Col = llCol;
								switch(llCol)
								{
									case 1 : 
										sprSBFtransacciones.Text = "C430"; 
										break;
									case 2 : 
										sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].FProcesoL.ToString(); 
										break;
									case 3 : 
										sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].FValorL.ToString(); 
										break;
									case 4 : 
										sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].CveTransS; 
										break;
									case 5 : 
										sprSBFtransacciones.Text = mdlParametros.gcsbfTransaccionC430[iContC430].DescTransS; 
										break;
									case 6 : 
										sprSBFtransacciones.Text = StringsHelper.Format(mdlParametros.gcsbfTransaccionC430[iContC430].ImporteD, ".00"); 
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
					//Dim llCol, c As Long
					//Dim ilRes, ilItem As Integer
					//Dim blbanderaAux As Boolean
					//
					//    llRow = 1
					//    ilItem = 1
					//    sprSBFtransacciones.MaxRows = 0
					//    ilRes = gcsbfTransaccionSBF.Count + gcsbfTransaccionC430.Count + 1
					//
					//'    If (gcsbfTransaccionSBF.Count <> gcsbfTransaccionC430.Count) Then
					//'        MsgBox "No concuerda el número de registros entre SBF y C430 con respecto a las transacciones del ejecutivo elegido", vbInformation + vbOKOnly, App.Title
					//'        blbandera = False
					//'    Else
					//        If gcsbfTransaccionSBF.Count > 0 Then
					//            blbandera = True
					//
					//            Do Until llRow = ilRes
					//
					//'                If (gcsbfTransaccionSBF.Item(ilItem).EmpNumL = sgFiltroEmpresa _
					//''                And gcsbfTransaccionSBF.Item(ilItem).EjeNumL = sgFiltroEjecutivo) _
					//''                Or (gcsbfTransaccionC430.Item(ilItem).EmpNumL = sgFiltroEmpresa And _
					//''                gcsbfTransaccionC430.Item(ilItem).EjeNumL = sgFiltroEjecutivo) Then
					//
					//                    blbanderaAux = True
					//
					//                    sprSBFtransacciones.MaxRows = sprSBFtransacciones.MaxRows + 1
					//
					//                    sprSBFtransacciones.Row = llRow
					//
					//                    For llCol = 1 To 6
					//                        sprSBFtransacciones.Col = llCol
					//                        Select Case llCol
					//                            Case 1
					//                                If llRow Mod 2 <> 0 Then
					//                                    sprSBFtransacciones.Text = "SBF"
					//                                End If
					//                                If llRow Mod 2 = 0 Then
					//                                    sprSBFtransacciones.Text = "C430"
					//                                End If
					//                            Case 2
					//                                If llRow Mod 2 <> 0 Then
					//                                    sprSBFtransacciones.Text = gcsbfTransaccionSBF.Item(ilItem).FProcesoL
					//                                End If
					//                                If llRow Mod 2 = 0 Then
					//                                    sprSBFtransacciones.Text = gcsbfTransaccionC430.Item(ilItem).FProcesoL
					//                                End If
					//                            Case 3
					//                                If llRow Mod 2 <> 0 Then
					//                                    sprSBFtransacciones.Text = gcsbfTransaccionSBF.Item(ilItem).FValorL
					//                                End If
					//                                If llRow Mod 2 = 0 Then
					//                                    sprSBFtransacciones.Text = gcsbfTransaccionC430.Item(ilItem).FValorL
					//                                End If
					//                            Case 4
					//                                If llRow Mod 2 <> 0 Then
					//                                    sprSBFtransacciones.Text = gcsbfTransaccionSBF.Item(ilItem).CveTransS
					//                                End If
					//                                If llRow Mod 2 = 0 Then
					//                                    sprSBFtransacciones.Text = gcsbfTransaccionC430.Item(ilItem).CveTransS
					//                                End If
					//                            Case 5
					//                                If llRow Mod 2 <> 0 Then
					//                                    sprSBFtransacciones.Text = gcsbfTransaccionSBF.Item(ilItem).DescTransS
					//                                End If
					//                                If llRow Mod 2 = 0 Then
					//                                    sprSBFtransacciones.Text = gcsbfTransaccionC430.Item(ilItem).DescTransS
					//                                End If
					//                            Case 6
					//                                If llRow Mod 2 <> 0 Then
					//                                    sprSBFtransacciones.Text = Format(gcsbfTransaccionSBF.Item(ilItem).ImporteD, ".00")
					//                                End If
					//                                If llRow Mod 2 = 0 Then
					//                                    sprSBFtransacciones.Text = Format(gcsbfTransaccionC430.Item(ilItem).ImporteD, ".00")
					//                                End If
					//
					//                        End Select
					//                    Next llCol
					//'                Else
					//'                    blbanderaAux = False
					//'                End If
					//
					//                If llRow Mod 2 = 0 Then
					//                    ilItem = ilItem + 1
					//                End If
					//
					//                llRow = llRow + 1
					//
					//            Loop
					//        Else
					//            MsgBox "No existe información acerca de las transacciones que realizó el ejecutivo elegido", vbInformation + vbOKOnly, App.Title
					//            blbandera = False
					//        End If
					//'    End If
					//
					//    If Not (blbanderaAux) Then
					//        MsgBox "No existe información acerca de las transacciones que realizó el ejecutivo elegido", vbInformation + vbOKOnly, App.Title
					//        blbandera = False
					//    End If
					
			}
			private void  frmSBFtransacciones_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}