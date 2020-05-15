using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Diagnostics; 
using System.IO; 
using System.Runtime.InteropServices; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class FrmFtp
		: System.Windows.Forms.Form
		{
		
			private const int ftpDIR = 0;
			private const int ftpPUT = 1;
			private const int ftpget = 2;
			private const int ftpDEL = 3;
			
			
			private int iLastFTP = 0;
			//AIS-1182 NGONZALEZ
			private string Ls_CurrentDirectory = String.Empty;
			string dirinit = String.Empty;
			int mget = 0;
			int minuto = 0;
			int banget = 0;
			ClsTcpIp objTcpIp = null; //Objeto que se utiliza para leer los valores de configuración del protocolo de tcpip
			
			private struct RECT
			{
				public int Left_Renamed;
				public int Top_Renamed;
				public int Right_Renamed;
				public int Bottom_Renamed;
			}
			
			private void  BtnDirNuevo_Click( Object eventSender,  EventArgs eventArgs)
			{
					try
					{
							string strDirNuevo = String.Empty;
							//strDirNuevo = CurDir()
							
							if (txtDirNuevo.Text.Trim().EndsWith("\\"))
							{
								strDirNuevo = txtDirNuevo.Text.Trim().Substring(0, txtDirNuevo.Text.Trim().Length - 1);
							} else
							{
								strDirNuevo = txtDirNuevo.Text.Trim();
							}
							
							if (strDirNuevo.Trim().Substring(0, Math.Min(strDirNuevo.Trim().Length, 1)) == "\\")
							{
								strDirNuevo = strDirNuevo.Trim();
								//AIS-esta linea se migro mal pq en vb6 se programo mal ngonzalez
                                //strDirNuevo.Substring[0, Math.Min(strDirNuevo.Length, 1)] = "";
								
								
							}
							if (! Directory.GetCurrentDirectory().EndsWith("\\"))
							{
								strDirNuevo = Directory.GetCurrentDirectory() + "\\" + strDirNuevo;
							} else
							{
								strDirNuevo = Directory.GetCurrentDirectory() + strDirNuevo;
							}
							Directory.CreateDirectory(strDirNuevo);
							DirLocal.Refresh();
						}
					catch (Exception excep)
					{
						
						MdlCambioMasivo.MsgInfo(excep.Message);
					}
					
					
					
			}
			
			private void  BtnRecibir_ClickEvent( Object eventSender,  EventArgs eventArgs)
			{
					
					object tempRefParam = 1;
					DirRemote.Nodes.get_Item(ref tempRefParam).Checked = true;
					FrmFtp.DefInstance.Cursor = Cursors.WaitCursor;
					BtnRecibir.Enabled = false;
					CmdDisconnect.Enabled = false;
					DrvLocal.Enabled = false;
					DirRemote.Enabled = false;
					DirLocal.Enabled = false;
					FilLocal.Enabled = false;
					BtnRecibir.Tag = "-1";
					int ret = 0;
					string ls_file = String.Empty;
					mget = 1;
					this.Enabled = false;
					object tempRefParam3 = 1;
					string tempRefParam2 = DirRemote.Nodes.get_Item(ref tempRefParam3).Key;
					Recorre_Tree(ref tempRefParam2);
					Application.DoEvents();
					banget = 1;
					DirRemote.Checkboxes = false;
					mget = 0;
					//DirRemote.Nodes.Item(1).Checked = False
					for (int cont = 0; cont <= List1.Items.Count - 1; cont++)
					{
						if (FileSystem.Dir(Directory.GetCurrentDirectory() + "\\" + Strings.Replace(ls_file.Trim(), "/", "\\", 1, -1, CompareMethod.Binary) + 
						                   Strings.Replace(Strings.Replace(VB6.GetItemString(List1, cont), dirinit, "", 1, -1, CompareMethod.Binary), "/", "\\", 1, -1, CompareMethod.Binary), FileAttribute.Archive) == "")
						{
							ls_file = Strings.Replace(VB6.GetItemString(List1, cont), dirinit, "", 1, -1, CompareMethod.Binary);
							string tempRefParam4 = VB6.GetItemString(List1, cont).Trim();
							string tempRefParam5 = Directory.GetCurrentDirectory().Trim() + "\\" + Strings.Replace(ls_file.Trim(), "/", "\\", 1, -1, CompareMethod.Binary);
							DownLoadFile(ref tempRefParam4, ref tempRefParam5);
							Application.DoEvents();
							FilLocal.Refresh();
							DirLocal.Refresh();
						}
					}
					List1.Items.Clear();
					FrmFtp.DefInstance.Cursor = Cursors.Default;
					banget = 0;
					BtnRecibir.Enabled = true;
					CmdDisconnect.Enabled = true;
					DrvLocal.Enabled = true;
					DirLocal.Enabled = true;
					FilLocal.Enabled = true;
					this.Enabled = true;
					DirRemote.Checkboxes = true;
					DirRemote.Enabled = true;
			}
			
			private void  cmdConnect_ClickEvent( Object eventSender,  EventArgs eventArgs)
			{
					string AppName = String.Empty;
					string TxtPort = String.Empty;
					try
					{
							//UPGRADE_ISSUE: (2064) VBControlExtender property Inet1.Cancel was not upgraded.
							Inet1.Cancel();
						}
					catch 
					{
					}
					try
					{
							object tempRefParam = "amarillo";
                            //AIS-CASTING System.Drawing.Image NGONZALEZ
							cmdConnect.Picture = (System.Drawing.Image) ImageList1.ListImages.get_ControlDefault(ref tempRefParam).Picture;
							this.Cursor = Cursors.WaitCursor;
							objTcpIp = new ClsTcpIp();
							
							
							//.PrPreguntaPassword "Password Autorizado"
							//.Password = " "
							
							if (objTcpIp.Password != "")
							{
								TxtUrl.Text = objTcpIp.Host;
								TxtPassword.Text = objTcpIp.Password;
								TxtUserName.Text = objTcpIp.User;
								TxtPort = objTcpIp.get_Puerto("FTP").ToString();
								TxtDir.Text = objTcpIp.DirRemotoFtp;
								
								
								if (! Directory.Exists(objTcpIp.DirLocalCte))
								{
									Directory.CreateDirectory(objTcpIp.DirLocalCte);
								}
								DirLocal.Path = objTcpIp.DirLocalCte;
								DrvLocal.Drive = objTcpIp.DirLocalCte;
								CmdDisconnect.Enabled = false;
								this.Cursor = Cursors.Default;
								banget = 0;
								minuto = 0;
								Timer1.Interval = 65535;
								Timer1.Enabled = true;
								mget = 0;
								this.Text = AppName + "(Cliente de FTP)";
								//UPGRADE_WARNING: (1037) Couldn't resolve default property of object DirRemote.ImageList.
								//AIS- NGONZALEZ
                                DirRemote.ImageList = ImageList1.GetOcx();
								DirRemote.Style = MSComctlLib.TreeStyleConstants.tvwTreelinesPlusMinusPictureText;
							} else
							{
								MdlCambioMasivo.MsgInfo("Proceso Cancelado por el usuario");
								this.Tag = "0";
								return;
							}
							
							Inet1.URL = TxtUrl.Text;
							Inet1.UserName = TxtUserName.Text;
							Inet1.Password = TxtPassword.Text;
							Inet1.Protocol = InetCtlsObjects.ProtocolConstants.icFTP;
							iLastFTP = ftpDIR;
							dirinit = TxtDir.Text;
							Ls_CurrentDirectory = dirinit;
							Inet1.Execute(Inet1.URL, "cd " + Ls_CurrentDirectory, Type.Missing, Type.Missing);
							do 
							{
								FrmFtp.DefInstance.Cursor = Cursors.WaitCursor;
								Application.DoEvents();
							}
							while(Inet1.StillExecuting);
							FrmFtp.DefInstance.Cursor = Cursors.Default;
							Inet1.Execute(Inet1.URL, "DIR", Type.Missing, Type.Missing);
							TxtUrl.Enabled = false;
							TxtUserName.Enabled = false;
							TxtPassword.Enabled = false;
							cmdConnect.Enabled = false;
							CmdDisconnect.Enabled = true;
							TxtDir.Enabled = false;
							Timer1.Enabled = true;
							DirLocal.Refresh();
							FilLocal.Refresh();
							FrmConectado.Visible = true;
							
							object tempRefParam2 = "verde";
                            //AIS-CASTING System.Drawing.Image NGONZALEZ
                            cmdConnect.Picture = (System.Drawing.Image)ImageList1.ListImages.get_ControlDefault(ref tempRefParam2).Picture;
							FrmFtp tempRefParam3 = this;
							CenterForma(ref tempRefParam3);
							this.Cursor = Cursors.Default;
						}
					catch 
					{
						
						ErrObject tempRefParam4 = Information.Err();
						if (GetError(ref tempRefParam4))
						{
							MessageBox.Show("Error: " + Conversion.ErrorToString(), Application.ProductName);
							if (Inet1.StillExecuting)
							{
								FrmFtp.DefInstance.Cursor = Cursors.WaitCursor;
								//UPGRADE_ISSUE: (2064) VBControlExtender property Inet1.Cancel was not upgraded.
								Inet1.Cancel();
							}
							FrmFtp.DefInstance.Cursor = Cursors.Default;
						}
						object tempRefParam5 = "verde";
                        //AIS-CASTING System.Drawing.Image NGONZALEZ
                        cmdConnect.Picture = (System.Drawing.Image)ImageList1.ListImages.get_ControlDefault(ref tempRefParam5).Picture;
					}
					
			}
			
			
			private void  CmdDisconnect_ClickEvent( Object eventSender,  EventArgs eventArgs)
			{
					try
					{
							//UPGRADE_ISSUE: (2064) VBControlExtender property Inet1.Cancel was not upgraded.
							Inet1.Cancel();
							do 
							{
								Application.DoEvents();
								FrmFtp.DefInstance.Cursor = Cursors.WaitCursor;
							}
							while(Inet1.StillExecuting);
							FrmFtp.DefInstance.Cursor = Cursors.Default;
							TxtUrl.Enabled = true;
							TxtUserName.Enabled = true;
							TxtPassword.Enabled = true;
							TxtDir.Enabled = true;
							CmdDisconnect.Enabled = false;
							cmdConnect.Enabled = true;
							DirRemote.Nodes.Clear();
							FrmConectado.Visible = false;
							Timer1.Enabled = false;
						}
					catch 
					{
						
						ErrObject tempRefParam = Information.Err();
						string tempRefParam2 = "cmddisconnect_click";
						if (GetError(ref tempRefParam, ref tempRefParam2))
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume' not supported");
						}
					}
			}
			//UPGRADE_NOTE: (7001) The following declaration (CmdRptenLinea_Click) seems to be dead code
			//private void  CmdRptenLinea_Click()
			//{
					//
					////UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
					//FrmTuxedo.DefInstance.ShowDialog();
			//}
			
			
			private void  DirRemote_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					if (banget != 0)
					{
						return;
					}
					this.Cursor = Cursors.WaitCursor;
					DirRemote.Enabled = false;
					string ls_Temp = String.Empty;
					MSComctlLib.Node CurrentDirectory = null;
					MSComctlLib.Node Subdir = null;
					try
					{
							if ((DirRemote.SelectedItem._ObjectDefault.IndexOf('/') + 1) == 0)
							{
								this.Cursor = Cursors.Default;
								DirRemote.Enabled = true;
								return;
							}
							CurrentDirectory = (MSComctlLib.Node) DirRemote.SelectedItem;
							if (CurrentDirectory != null)
							{
								ls_Temp = CurrentDirectory.Key;
								if (Convert.ToString(CurrentDirectory.Image) == "closed")
								{
									CurrentDirectory.Image = "open";
									CerrarCarpetas(ref ls_Temp);
								} else if (Convert.ToString(CurrentDirectory.Image) == "open") { 
									CurrentDirectory.Image = "closed";
									CurrentDirectory.Sorted = true;
									CurrentDirectory.Expanded = false; //Cierra la carpeta
									if (CurrentDirectory.Children > 0)
									{
										//Existen subdirectorios
										for (int ll_i = 0; ll_i <= CurrentDirectory.Children - 1; ll_i++)
										{
											object tempRefParam = CurrentDirectory.Child.Index;
											DirRemote.Nodes.Remove(ref tempRefParam);
										}
									}
								}
								if (ls_Temp == dirinit)
								{
									Inet1.Execute(Inet1.URL, "CD " + dirinit, Type.Missing, Type.Missing);
									do 
									{
										Application.DoEvents();
									}
									while(Inet1.StillExecuting);
									object tempRefParam2 = dirinit;
									DirRemote.Nodes.Remove(ref tempRefParam2);
								} else
								{
									if (Strings.Mid(ls_Temp, 2, ls_Temp.Length).IndexOf('/') >= 0)
									{
										Inet1.Execute(Inet1.URL, "CD " + "\"" + ls_Temp + "\"", Type.Missing, Type.Missing);
										do 
										{
											Application.DoEvents();
										}
										while(Inet1.StillExecuting);
									}
								}
								iLastFTP = ftpDIR;
								Ls_CurrentDirectory = CurrentDirectory.Key;
								do 
								{
									Application.DoEvents();
								}
								while(Inet1.StillExecuting);
								Inet1.Execute(Inet1.URL, "DIR", Type.Missing, Type.Missing);
								do 
								{
									Application.DoEvents();
								}
								while(Inet1.StillExecuting);
							}
							this.Cursor = Cursors.Default;
							DirRemote.Enabled = true;
						}
					catch 
					{
						
						ErrObject tempRefParam3 = Information.Err();
						if (GetError(ref tempRefParam3))
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume' not supported");
							Application.DoEvents();
							if (Inet1.StillExecuting)
							{
								Application.DoEvents();
								Application.DoEvents();
								//UPGRADE_ISSUE: (2064) VBControlExtender property Inet1.Cancel was not upgraded.
								Inet1.Cancel();
							}
							FrmFtp.DefInstance.Cursor = Cursors.Default;
							this.Cursor = Cursors.Default;
						}
						DirRemote.Enabled = true;
					}
			}
			
			private void  FrmFtp_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						if (this.Tag.ToString() == "0")
						{
							this.Close();
						}
						
					}
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					string AppName = String.Empty;
					string TxtPort = String.Empty;
					MSComctlLib.ListImage imgI = null;
					string ls_Files = String.Empty;
					int Li_handler = 0;
					string ls_ContFile = String.Empty;
					//If Dir(smArchivoIni, vbArchive) = "" Then
					this.Width = (int) VB6.TwipsToPixelsX(10020);
					this.Tag = "";
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					
					
					
					objTcpIp = new ClsTcpIp();
					
					
					//.PrPreguntaPassword "Password Autorizado"
					//.Password = " "
					//If .Password <> "" Then
					TxtUrl.Text = objTcpIp.Host;
					TxtPassword.Text = objTcpIp.Password;
					TxtUserName.Text = objTcpIp.User;
					TxtPort = objTcpIp.get_Puerto("FTP").ToString();
					TxtDir.Text = objTcpIp.DirRemotoFtp;
					
					
					if (! Directory.Exists(objTcpIp.DirLocalCte))
					{
						Directory.CreateDirectory(objTcpIp.DirLocalCte);
					}
					DirLocal.Path = objTcpIp.DirLocalCte;
					DrvLocal.Drive = objTcpIp.DirLocalCte;
					CmdDisconnect.Enabled = false;
					this.Cursor = Cursors.Default;
					banget = 0;
					minuto = 0;
					Timer1.Interval = 65535;
					Timer1.Enabled = true;
					mget = 0;
					this.Text = AppName + "(Cliente de FTP)";
                    //AIS-GetOcx() NGONZALEZ
					DirRemote.ImageList = ImageList1.GetOcx();
					DirRemote.Style = MSComctlLib.TreeStyleConstants.tvwTreelinesPlusMinusPictureText;
					//Else
					//MsgInfo "Proceso Cancelado por el usuario"
					//Me.Tag = "0"
					//End If
					
			}
			
			private void  FrmFtp_MouseDown( Object eventSender,  MouseEventArgs eventArgs)
			{
					int Button = (int) eventArgs.Button;
					int Shift = (int) Control.ModifierKeys / 0x10000;
					float X = (float) VB6.PixelsToTwipsX(eventArgs.X);
					float Y = (float) VB6.PixelsToTwipsY(eventArgs.Y);
					//UPGRADE_ISSUE: (2072) Control Name could not be resolved because it was within the generic namespace ActiveControl.
					if (this.ActiveControl.Name == "DirLocal")
					{
						if (Button == 2)
						{
							MdlCambioMasivo.MsgInfo("Pulso el boton derecho");
						}
					}
			}
			
			
			
			private bool isInitializingComponent;
			private void  FrmFtp_Resize( Object eventSender,  EventArgs eventArgs)
			{
					if (isInitializingComponent)
					{
						return;
					}
					Frm_Status.Width = (int) (this.Width - VB6.TwipsToPixelsX(100));
					SbFTp.Width = (int) (Frm_Status.Width - VB6.TwipsToPixelsX(100));
			}
			
			private void  FrmFtp_Closed( Object eventSender,  EventArgs eventArgs)
			{
					if (Inet1.StillExecuting)
					{
						do 
						{
							//UPGRADE_WARNING: Untranslated statement in Form_Unload. Please check source code.
							FrmFtp.DefInstance.Cursor = Cursors.WaitCursor;
						}
						while(! Inet1.StillExecuting);
						FrmFtp.DefInstance.Cursor = Cursors.Default;
					}
					CmdDisconnect_ClickEvent(CmdDisconnect, new EventArgs());
					objTcpIp = null;
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			
			private void  Inet1_StateChanged( Object eventSender,  AxInetCtlsObjects.DInetEvents_StateChangedEvent eventArgs)
			{
					if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icNone))
					{
						object tempRefParam = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam).Text = "";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icResolvingHost)) { 
						object tempRefParam2 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam2).Text = "Buscando Servidor";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icHostResolved)) { 
						object tempRefParam3 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam3).Text = "Servidor Encontrado";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icConnecting)) { 
						object tempRefParam4 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam4).Text = "Conectando...";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icConnected)) { 
						object tempRefParam5 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam5).Text = "Conectado!";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icRequesting)) { 
						object tempRefParam6 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam6).Text = "Solicitando Respuesta...";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icRequestSent)) { 
						object tempRefParam7 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam7).Text = "Solicitano Enviar Archivo";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icReceivingResponse)) { 
						object tempRefParam8 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam8).Text = "Recibiendo Respuesta...";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icResponseReceived)) { 
						object tempRefParam9 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam9).Text = "Respuesta Recibida!";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icDisconnecting)) { 
						object tempRefParam10 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam10).Text = "Desconectando...";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icDisconnected)) { 
						object tempRefParam11 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam11).Text = "Desconectado";
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icError)) { 
						object tempRefParam12 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam12).Text = "Error! " + Inet1.ResponseCode.ToString().Trim() + ": " + Inet1.ResponseInfo;
					} else if (eventArgs.state == ((short) InetCtlsObjects.StateConstants.icResponseCompleted)) { 
						object tempRefParam13 = "status";
						SbFTp.Panels.get_ControlDefault(ref tempRefParam13).Text = "Respuesta Completada!";
						ReactToResponse(iLastFTP);
					}
			}
			
			public int ReactToResponse( int iLastCommand)
			{
					object BtnEnviarTodo = null;
					switch(iLastCommand)
					{
						case ftpDIR : 
							ShowRemoteFileList(); 
							break;
						case ftpPUT : 
							//UPGRADE_NOTE: (7004) Member access to a non initialized variable. Variable BtnEnviarTodo Member Tag. 
							if (Convert.ToString(ReflectionHelper.GetMember(BtnEnviarTodo, "Tag")) != "-1")
							{
								MessageBox.Show("Archivo Enviado desde " + "\r" + Directory.GetCurrentDirectory(), Application.ProductName);
							} 
							break;
						case ftpget : 
							if (BtnRecibir.Tag.ToString() != "-1")
							{
								MessageBox.Show("Archivo Recibido en: " + "\r" + Directory.GetCurrentDirectory(), Application.ProductName);
							} 
							break;
						case ftpDEL : 
							MessageBox.Show("Archivo Elimnado", Application.ProductName); 
							break;
					}
					return 0;
			}
			
			public int ShowRemoteFileList()
			{
					string sFileList = String.Empty;
					Application.DoEvents();
					int p = 0;
					string ls_elemento = String.Empty;
					Application.DoEvents();
					//UPGRADE_WARNING: (1068) Inet1.GetChunk() of type Variant is being forced to string.
					int tempRefParam = 1024;
					string sTemp = Convert.ToString(Inet1.GetChunk(ref tempRefParam, Type.Missing));
					
					while(sTemp.Length > 0)
					{
						Application.DoEvents();
						sFileList = sFileList + sTemp;
						//UPGRADE_WARNING: (1068) Inet1.GetChunk() of type Variant is being forced to string.
						int tempRefParam2 = 1024;
						sTemp = Convert.ToString(Inet1.GetChunk(ref tempRefParam2, Type.Missing));
					};
					
					while(String.CompareOrdinal(sFileList, "") > 0)
					{
						Application.DoEvents();
						p = (sFileList.IndexOf("\r\n") + 1);
						if (p > 0)
						{
							ls_elemento = sFileList.Substring(0, Math.Min(sFileList.Length, p - 1));
							if (ls_elemento.IndexOf('/') >= 0)
							{ //Se trata de un Subdirectorio
								AxMSComctlLib.AxTreeView tempRefParam3 = DirRemote;
								ShowRemoteDirectory(ref tempRefParam3, ref Ls_CurrentDirectory, ref ls_elemento);
								DirRemote = tempRefParam3;
								if (sFileList.Length > (p + 2))
								{
									sFileList = Strings.Mid(sFileList, p + 2);
								} else
								{
									sFileList = "";
								}
							} else
							{
								//Se trata de un archivo
								AxMSComctlLib.AxTreeView tempRefParam4 = DirRemote;
								ShowRemoteFile(ref tempRefParam4, ref Ls_CurrentDirectory, ref ls_elemento);
								DirRemote = tempRefParam4;
								if (sFileList.Length > (p + 2))
								{
									sFileList = Strings.Mid(sFileList, p + 2);
								} else
								{
									sFileList = "";
								}
							}
						}
						Application.DoEvents();
					};
					return 0;
			}
			private void  DirLocal_Change( Object eventSender,  EventArgs eventArgs)
			{
					FilLocal.Path = DirLocal.Path;
					FilLocal.Refresh();
					Directory.SetCurrentDirectory(FilLocal.Path);
					Application.DoEvents();
			}
			
			private void  DrvLocal_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					FileSystem.ChDrive(DrvLocal.Drive);
					DirLocal.Path = DrvLocal.Drive;
					DirLocal.Refresh();
					FilLocal.Refresh();
			}
			
			private void  FilLocal_DoubleClick( Object eventSender,  EventArgs eventArgs)
			{
					string arch = FilLocal.Path + "\\" + FilLocal.FileName;
					//UPGRADE_WARNING: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo
					ProcessStartInfo startInfo = new ProcessStartInfo("write.exe " + arch);
					startInfo.WindowStyle = ProcessWindowStyle.Maximized;
					Process.Start(startInfo);
			}
			private void  ShowRemoteDirectory(ref  AxMSComctlLib.AxTreeView Directorio, ref  string ls_Padre, ref  string ls_Nodo)
			{
					MSComctlLib.Node Subdir = null;
					if (Directorio.Nodes.Count == 0)
					{
						object tempRefParam = Type.Missing;
						object tempRefParam2 = Type.Missing;
						object tempRefParam3 = dirinit;
						object tempRefParam4 = dirinit;
						object tempRefParam5 = "root";
						object tempRefParam6 = Type.Missing;
						Subdir = (MSComctlLib.Node) Directorio.Nodes.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					}
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							object tempRefParam7 = ls_Padre;
							object tempRefParam8 = 4;
							object tempRefParam9 = ls_Padre + ls_Nodo;
							object tempRefParam10 = ls_Nodo;
							object tempRefParam11 = "closed";
							object tempRefParam12 = Type.Missing;
							Subdir = (MSComctlLib.Node) Directorio.Nodes.Add(ref tempRefParam7, ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12);
							Subdir.EnsureVisible();
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
			}
			
			private void  ShowRemoteFile(ref  AxMSComctlLib.AxTreeView File, ref  string ls_Padre, ref  string ls_Nodo)
			{
					MSComctlLib.Node Subdir = null;
					if (File.Nodes.Count == 0)
					{
						object tempRefParam = Type.Missing;
						object tempRefParam2 = Type.Missing;
						object tempRefParam3 = dirinit;
						object tempRefParam4 = dirinit;
						object tempRefParam5 = "root";
						object tempRefParam6 = Type.Missing;
						Subdir = (MSComctlLib.Node) File.Nodes.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					}
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							object tempRefParam7 = ls_Padre;
							object tempRefParam8 = 4;
							object tempRefParam9 = ls_Padre + ls_Nodo;
							object tempRefParam10 = ls_Nodo;
							object tempRefParam11 = "file";
							object tempRefParam12 = Type.Missing;
							Subdir = (MSComctlLib.Node) File.Nodes.Add(ref tempRefParam7, ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12);
							Subdir.EnsureVisible();
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
			}
			
			
			private void  CerrarCarpetas(ref  string ls_NodoActual)
			{
					//El objetivo es Cerrar las carpetas del directorio remoto
					Application.DoEvents();
					Application.DoEvents();
					object tempRefParam = ls_NodoActual;
					MSComctlLib.Node L_Node = (MSComctlLib.Node) DirRemote.Nodes.get_Item(ref tempRefParam);
					MSComctlLib.Node l_NodePadre = (MSComctlLib.Node) L_Node.Parent;
					for (int li_node = 1; li_node <= DirRemote.Nodes.Count; li_node++)
					{
						object tempRefParam2 = li_node;
						L_Node = (MSComctlLib.Node) DirRemote.Nodes.get_Item(ref tempRefParam2);
						if (Convert.ToString(L_Node.Image) == "open" && L_Node.Key != l_NodePadre.Key)
						{
							if (L_Node.Key != ls_NodoActual)
							{
								L_Node.Image = "closed";
								L_Node.Expanded = false;
							}
						}
						Application.DoEvents();
					}
					return;
			}
			private void  Recorre_Tree(ref  string ls_NodoActual)
			{
					MSComctlLib.Node T_Node = null;
					int X = 0;
					object tempRefParam = ls_NodoActual;
					MSComctlLib.Node L_Node = (MSComctlLib.Node) DirRemote.Nodes.get_Item(ref tempRefParam);
					object tempRefParam2 = ls_NodoActual;
					for (int li_node = 2; li_node <= DirRemote.Nodes.get_Item(ref tempRefParam2).Children + 1; li_node++)
					{
						object tempRefParam3 = li_node;
						L_Node = (MSComctlLib.Node) DirRemote.Nodes.get_Item(ref tempRefParam3);
						if ((L_Node.Key.LastIndexOf("/") + 1) == Strings.Len(L_Node.Key))
						{
							if (L_Node.Checked)
							{
								string tempRefParam4 = L_Node.Text;
								if (FnCrearDirectorio(ref tempRefParam4))
								{
									Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "\\" + Strings.Replace(L_Node.Text, "/", "", 1, -1, CompareMethod.Binary));
								}
								Directory.SetCurrentDirectory("..");
								object tempRefParam5 = li_node;
								DirRemote.Nodes.get_Item(ref tempRefParam5).Selected = true;
								Application.DoEvents();
								Application.DoEvents();
								Application.DoEvents();
								DirRemote_DblClick(DirRemote, new EventArgs());
								Application.DoEvents();
								Application.DoEvents();
								Application.DoEvents();
								string tempRefParam6 = L_Node.Key;
								Checked_Tree(ref tempRefParam6);
								L_Node.Checked = false;
								string tempRefParam7 = L_Node.Key;
								Recorre_Tree(ref tempRefParam7);
								L_Node.Checked = false;
							} else
							{
								if (L_Node.Children != 0)
								{
									X = L_Node.Children;
									T_Node = (MSComctlLib.Node) L_Node.Child;
									for (int Node = 1; Node <= X; Node++)
									{
										if (T_Node.Checked)
										{
											T_Node.Checked = false;
											if ((mget & ((T_Node.Parent.Checked) ? -1: 0)) != 0)
											{
												List1.Items.Add(T_Node.Key);
											} else if (((mget & ((! T_Node.Parent.Checked) ? -1: 0)) != 0)) { 
												string tempRefParam8 = T_Node.Parent.Text;
												if (FnCrearDirectorio(ref tempRefParam8))
												{
													Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "\\" + Strings.Replace(T_Node.Parent.Text, "/", "", 1, -1, CompareMethod.Binary));
												}
												Directory.SetCurrentDirectory("..");
												List1.Items.Add(T_Node.Key);
											}
										}
										T_Node = (MSComctlLib.Node) T_Node.Next;
									}
								}
							}
						} else
						{
							if (L_Node.Checked)
							{
								if ((mget & ((L_Node.Parent.Checked) ? -1: 0)) != 0)
								{
									List1.Items.Add(L_Node.Key);
								}
								L_Node.Checked = false;
							}
						}
					}
			}
			private void  Checked_Tree(ref  string Nodo)
			{
					object tempRefParam = Nodo;
					MSComctlLib.Node L_Node = (MSComctlLib.Node) DirRemote.Nodes.get_Item(ref tempRefParam);
					int X = L_Node.Children;
					L_Node = (MSComctlLib.Node) L_Node.Child;
					for (int Node = 1; Node <= X; Node++)
					{
						L_Node.Checked = L_Node.Parent.Checked;
						if (mget == 1 && L_Node.Parent.Checked)
						{
							if ((L_Node.Key.LastIndexOf("/") + 1) != Strings.Len(L_Node.Key))
							{
								List1.Items.Add(L_Node.Key);
							}
						} else
						{
							if (L_Node.Children != 0)
							{
								string tempRefParam2 = L_Node.Key;
								Checked_Tree(ref tempRefParam2);
							}
						}
						L_Node = (MSComctlLib.Node) L_Node.Next;
					}
					
			}
			private void  DirRemote_NodeCheck( Object eventSender,  AxMSComctlLib.ITreeViewEvents_NodeCheckEvent eventArgs)
			{
					if (eventArgs.node.Key != dirinit)
					{
						if (! eventArgs.node.Checked && eventArgs.node.Parent.Key != dirinit)
						{
							eventArgs.node.Parent.Checked = false;
						}
					}
					if (eventArgs.node.Children != 0)
					{
						if ((eventArgs.node.Key.LastIndexOf("/") + 1) == Strings.Len(eventArgs.node.Key))
						{
							string tempRefParam = eventArgs.node.Key;
							Checked_Tree(ref tempRefParam);
						} else if ((eventArgs.node.Key == dirinit)) { 
							string tempRefParam2 = eventArgs.node.Key;
							Checked_Tree(ref tempRefParam2);
						}
					} else
					{
						if ((eventArgs.node.Key.LastIndexOf("/") + 1) == Strings.Len(eventArgs.node.Key))
						{
							object tempRefParam3 = eventArgs.node.Key;
							DirRemote.Nodes.get_Item(ref tempRefParam3).Selected = true;
							Application.DoEvents();
							Application.DoEvents();
							Application.DoEvents();
							DirRemote_DblClick(DirRemote, new EventArgs());
							Application.DoEvents();
							Application.DoEvents();
							Application.DoEvents();
							string tempRefParam4 = eventArgs.node.Key;
							Checked_Tree(ref tempRefParam4);
						} else if ((eventArgs.node.Key == dirinit)) { 
							object tempRefParam5 = eventArgs.node.Key;
							DirRemote.Nodes.get_Item(ref tempRefParam5).Selected = true;
							Application.DoEvents();
							Application.DoEvents();
							Application.DoEvents();
							DirRemote_DblClick(DirRemote, new EventArgs());
							Application.DoEvents();
							Application.DoEvents();
							Application.DoEvents();
							string tempRefParam6 = eventArgs.node.Key;
							Checked_Tree(ref tempRefParam6);
						}
					}
			}
			private bool FnCrearDirectorio(ref  string strPath)
			{
					bool result = false;
					string strTemp = Strings.Replace(strPath, "/", "", 1, -1, CompareMethod.Binary);
					if (! Directory.Exists(strTemp))
					{
						//Crear directorio
						Directory.CreateDirectory(strTemp);
						return true;
					} else
					{
						return true;
					}
					return result;
			}
			public void  DownLoadFile(ref  string SourceFile, ref  string DestFile)
			{
					try
					{
							iLastFTP = ftpget;
							Inet1.Execute(Type.Missing, "GET " + SourceFile + " " + DestFile, Type.Missing, Type.Missing);
							
							while(Inet1.StillExecuting)
							{
								Application.DoEvents();
							};
						}
					catch 
					{
						
						//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
						throw new Exception("Migration Exception: 'Resume' not supported");
					}
			}
			
			
			
			//UPGRADE_NOTE: (7001) The following declaration (SSCommand1_Click) seems to be dead code
			//private void  SSCommand1_Click()
			//{
					//
			//}
			
			private void  Timer1_Tick( Object eventSender,  EventArgs eventArgs)
			{
					minuto++;
					if (minuto == 3)
					{
						minuto = 0;
						if (Inet1.StillExecuting)
						{
							Application.DoEvents();
						} else
						{
							Inet1.Execute(Inet1.URL, "DIR", Type.Missing, Type.Missing);
							do 
							{
								Application.DoEvents();
							}
							while(Inet1.StillExecuting);
							iLastFTP = ftpDIR;
						}
					}
			}
			private void  CenterForma(ref  FrmFtp Frm)
			{
					int SPI_GETWORKAREA = 0;
					RECT R = new RECT();
					int lW = 0, lH = 0;
					//UPGRADE_WARNING: (1068) R of type FrmFtp.RECT is being forced to Any.
                    //AIS-1182 NGONZALEZ
					int lRes = API.USER.SystemParametersInfo(SPI_GETWORKAREA, 0, R, 0);
					if (lRes != 0)
					{
						R.Left_Renamed = Convert.ToInt32(VB6.TwipsPerPixelX() * R.Left_Renamed);
						R.Top_Renamed = Convert.ToInt32(VB6.TwipsPerPixelY() * R.Top_Renamed);
						R.Right_Renamed = Convert.ToInt32(VB6.TwipsPerPixelX() * R.Right_Renamed);
						R.Bottom_Renamed = Convert.ToInt32(VB6.TwipsPerPixelY() * R.Bottom_Renamed);
						lW = R.Right_Renamed - R.Left_Renamed;
						lH = R.Bottom_Renamed - R.Top_Renamed;
						Frm.SetBounds(Convert.ToInt32((float) VB6.TwipsToPixelsX(R.Left_Renamed + (lW - ((float) VB6.PixelsToTwipsX(Frm.Width))) / 2)), Convert.ToInt32((float) VB6.TwipsToPixelsY(R.Top_Renamed + (lH - ((float) VB6.PixelsToTwipsY(Frm.Height))) / 2)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
					}
			}
			private bool GetError(ref  ErrObject NumError, ref  string Modulo)
			{
					bool result = false;
					string tempRefParam = "Se ha provocado el siguiente error" + 
					                      "\r" + Conversion.ErrorToString();
					MsgError(ref tempRefParam);
					return result;
			}
			
			private bool GetError(ref  ErrObject NumError)
			{
					string tempRefParam = "";
					return GetError(ref NumError, ref tempRefParam);
			}
			private void  MsgError(ref  string ls_error, ref  string Modulo)
			{
					string AppName = String.Empty;
					//UPGRADE_ISSUE: (1040) IsMissing function is not supported.
                    //AIS-1123 NGONZALEZ
					if (Modulo == null)
					{
						Modulo = AppName;
					} else
					{
						Modulo = AppName + " (" + Modulo + ") ";
					}
					Application.DoEvents();
					MessageBox.Show(ls_error, Modulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.DoEvents();
			}
			
			private void  MsgError(ref  string ls_error)
			{
					string tempRefParam2 = "";
					MsgError(ref ls_error, ref tempRefParam2);
			}
			//UPGRADE_NOTE: (7001) The following declaration (Reloj) seems to be dead code
			//private void  Reloj(ref  int Pointer)
			//{
					////UPGRADE_ISSUE: (2036) Screen property Screen.MousePointer does not support custom mousepointers.
					//this.Cursor = Pointer;
			//}
			//UPGRADE_NOTE: (7001) The following declaration (LeeStringIni) seems to be dead code
			//private string LeeStringIni(ref  string LLave, ref  string Buscar, ref  string Archivo)
			//{
					//FixedLengthString ls_Temp = new FixedLengthString(255);
					//If FileExists(Archivo) Then
					//int LI_TEMP = FrmFtp.DefInstance.GetPrivateProfileString(LLave, Buscar, "", ls_Temp.Value, ls_Temp.Value.Length, Archivo);
					//if (LI_TEMP > 0)
					//{
						//if (ls_Temp.Value.IndexOf(Strings.Chr(0).ToString()) >= 0)
						//{
							//return ls_Temp.Value.Substring(0, Math.Min(ls_Temp.Value.Length, ls_Temp.Value.IndexOf(Strings.Chr(0).ToString()))).Trim();
						//} else
						//{
							//return ls_Temp.Value.Trim();
						//}
					//} else
					//{
						//return "";
					//}
					//Else
					//
					//End If
			//}
			public int FileExists( string strPathName)
			{
					int result = 0;
					string gstrSEP_DIR = String.Empty;
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							strPathName = strUnQuoteString(strPathName);
							if (strPathName.Substring(strPathName.Length - Math.Min(strPathName.Length, 1)) == gstrSEP_DIR)
							{
								strPathName = strPathName.Substring(0, strPathName.Length - 1);
							}
							int intFileNum = FileSystem.FreeFile();
							FileSystem.FileOpen(intFileNum, strPathName, OpenMode.Input, OpenAccess.Default, OpenShare.Shared, -1);
							result = (Information.Err().Number == 0) ? -1: 0;
							FileSystem.FileClose(intFileNum);
							Information.Err().Clear();
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					return result;
			}
			
			public string strUnQuoteString( string strQuotedString)
			{
					string gstrQUOTE = String.Empty;
					strQuotedString = strQuotedString.Trim();
					if (Strings.Mid(strQuotedString, 1, 1) == gstrQUOTE && strQuotedString.Substring(strQuotedString.Length - Math.Min(strQuotedString.Length, 1)) == gstrQUOTE)
					{
						strQuotedString = Strings.Mid(strQuotedString, 2, strQuotedString.Length - 2);
					}
					return strQuotedString;
			}
			
			private void  txtDirNuevo_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					if (("?*/\\+$").IndexOf(Strings.Chr(KeyAscii).ToString()) >= 0)
					{
						KeyAscii = 0;
					}
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}
}