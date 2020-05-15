using Artinsoft.VB6.Gui; 
using Microsoft.VisualBasic; 
using System; 
using System.ComponentModel; 
using System.Diagnostics; 
using System.IO; 
using System.Runtime.InteropServices; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORSGPRE
		: System.Windows.Forms.Form
		{
		
			private void  CORSGPRE_Activated( Object eventSender,  EventArgs eventArgs)
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
			//**       Descripción: Forma de Presentacion temporal del sistema que      **
			//**                    se presenta mientras carga la forma MDI             **
			//**                                                                        **
			//**       Responsable: Felipe Zacarias Jimenez                             **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 09/Diciembre/2003                  **
			//**                                                                        **
			//** Se agregan Apis que compara que la version del archivo SqlSrv32.dll no
			//** haya sido modificado por algun programa de actualización masiva ya que
			//** el driver de odbc de las nuevas versiones no soporta a sybase, por lo que
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			static readonly int VS_FFI_SIGNATURE = unchecked((int) 0xFEEF04BD);
			const int VS_FFI_STRUCVERSION = 0x10000;
			const int VS_FFI_FILEFLAGSMASK = 0x3F;
			const int VS_FF_DEBUG = 0x1;
			const int VS_FF_PRERELEASE = 0x2;
			const int VS_FF_PATCHED = 0x4;
			const int VS_FF_PRIVATEBUILD = 0x8;
			const int VS_FF_INFOINFERRED = 0x10;
			const int VS_FF_SPECIALBUILD = 0x20;
			const int VOS_UNKNOWN = 0x0;
			const int VOS_DOS = 0x10000;
			const int VOS_OS216 = 0x20000;
			const int VOS_OS232 = 0x30000;
			const int VOS_NT = 0x40000;
			const int VOS__BASE = 0x0;
			const int VOS__WINDOWS16 = 0x1;
			const int VOS__PM16 = 0x2;
			const int VOS__PM32 = 0x3;
			const int VOS__WINDOWS32 = 0x4;
			const int VOS_DOS_WINDOWS16 = 0x10001;
			const int VOS_DOS_WINDOWS32 = 0x10004;
			const int VOS_OS216_PM16 = 0x20002;
			const int VOS_OS232_PM32 = 0x30003;
			const int VOS_NT_WINDOWS32 = 0x40004;
			const int VFT_UNKNOWN = 0x0;
			const int VFT_APP = 0x1;
			const int VFT_DLL = 0x2;
			const int VFT_DRV = 0x3;
			const int VFT_FONT = 0x4;
			const int VFT_VXD = 0x5;
			const int VFT_STATIC_LIB = 0x7;
			const int VFT2_UNKNOWN = 0x0;
			const int VFT2_DRV_PRINTER = 0x1;
			const int VFT2_DRV_KEYBOARD = 0x2;
			const int VFT2_DRV_LANGUAGE = 0x3;
			const int VFT2_DRV_DISPLAY = 0x4;
			const int VFT2_DRV_MOUSE = 0x5;
			const int VFT2_DRV_NETWORK = 0x6;
			const int VFT2_DRV_SYSTEM = 0x7;
			const int VFT2_DRV_INSTALLABLE = 0x8;
			const int VFT2_DRV_SOUND = 0x9;
			const int VFT2_DRV_COMM = 0xA;
			private struct VS_FIXEDFILEINFO
			{
				public int dwSignature;
				public int dwStrucVersionl; //  e.g. = &h0000 = 0
				public int dwStrucVersionh; //  e.g. = &h0042 = .42
				public int dwFileVersionMSl; //  e.g. = &h0003 = 3
				public int dwFileVersionMSh; //  e.g. = &h0075 = .75
				public int dwFileVersionLSl; //  e.g. = &h0000 = 0
				public int dwFileVersionLSh; //  e.g. = &h0031 = .31
				public int dwProductVersionMSl; //  e.g. = &h0003 = 3
				public int dwProductVersionMSh; //  e.g. = &h0010 = .1
				public int dwProductVersionLSl; //  e.g. = &h0000 = 0
				public int dwProductVersionLSh; //  e.g. = &h0031 = .31
				public int dwFileFlagsMask; //  = &h3F for version "0.42"
				public int dwFileFlags; //  e.g. VFF_DEBUG Or VFF_PRERELEASE
				public int dwFileOS; //  e.g. VOS_DOS_WINDOWS16
				public int dwFileType; //  e.g. VFT_DRIVER
				public int dwFileSubtype; //  e.g. VFT2_DRV_KEYBOARD
				public int dwFileDateMS; //  e.g. 0
				public int dwFileDateLS; //  e.g. 0
			}
			//AIS-1182 NGONZALEZ
			
			string Directory = String.Empty, Filename = String.Empty, FullFileName = String.Empty;
			string FileVer = String.Empty, StrucVer = String.Empty, ProdVer = String.Empty;
			string FileType = String.Empty, FileFlags = String.Empty, FileOS = String.Empty, FileSubType = String.Empty;
			
			private string WindowsSystemDir()
			{
					//Create a buffer
					string sSave = new String(' ', 255);
					//Get the system directory
                    //AIS-1182 NGONZALEZ
					int Ret = API.KERNEL.GetSystemDirectory(sSave, 255);
					//Remove all unnecessary chr$(0)'s
					sSave = sSave.Substring(0, Math.Min(sSave.Length, Ret));
					//Show the windows directory
					return sSave;
			}
			
			private void  DisplayVerInfo()
			{
					int lDummy = 0;
					int lVerPointer = 0;
					VS_FIXEDFILEINFO udtVerBuffer = new VS_FIXEDFILEINFO();
					int lVerbufferLen = 0;
					
					//*** Get size ****
					int lBufferLen = API.Version.GetFileVersionInfoSize(FullFileName, lDummy);
					if (lBufferLen < 1)
					{
						//MsgBox "No Version Info available!"
						FileVer = "";
						ProdVer = "";
						return;
					}
					
					//**** Store info to udtVerBuffer struct ****
					byte[] sBuffer = new byte[lBufferLen + 1];
                    //AIS-1182 NGONZALEZ
                    int rc = API.Version.GetFileVersionInfo(FullFileName, 0, lBufferLen, sBuffer[0]);
                    //AIS-1182 NGONZALEZ
					rc = API.Version.VerQueryValue(sBuffer[0], "\\", lVerPointer, lVerbufferLen);
					//UPGRADE_WARNING: (1041) Len has a new behavior.
					//UPGRADE_WARNING: (1068) udtVerBuffer of type CORSGPRE.VS_FIXEDFILEINFO is being forced to Any.
					//AIS-1182 NGONZALEZ
                    API.KERNEL.MoveMemory(udtVerBuffer, lVerPointer, Marshal.SizeOf(udtVerBuffer));
					
					//**** Determine Structure Version number - NOT USED ****
					StrucVer = udtVerBuffer.dwStrucVersionh.ToString() + "." + udtVerBuffer.dwStrucVersionl.ToString();
					
					//**** Determine File Version number ****
					FileVer = udtVerBuffer.dwFileVersionMSh.ToString() + "." + udtVerBuffer.dwFileVersionMSl.ToString() + "." + udtVerBuffer.dwFileVersionLSh.ToString() + "." + udtVerBuffer.dwFileVersionLSl.ToString();
					
					//**** Determine Product Version number ****
					ProdVer = udtVerBuffer.dwProductVersionMSh.ToString() + "." + udtVerBuffer.dwProductVersionMSl.ToString() + "." + udtVerBuffer.dwProductVersionLSh.ToString() + "." + udtVerBuffer.dwProductVersionLSl.ToString();
					
					//**** Determine Boolean attributes of File ****
					FileFlags = "";
					if ((udtVerBuffer.dwFileFlags & VS_FF_DEBUG) != 0)
					{
						FileFlags = "Debug ";
					}
					if ((udtVerBuffer.dwFileFlags & VS_FF_PRERELEASE) != 0)
					{
						FileFlags = FileFlags + "PreRel ";
					}
					if ((udtVerBuffer.dwFileFlags & VS_FF_PATCHED) != 0)
					{
						FileFlags = FileFlags + "Patched ";
					}
					if ((udtVerBuffer.dwFileFlags & VS_FF_PRIVATEBUILD) != 0)
					{
						FileFlags = FileFlags + "Private ";
					}
					if ((udtVerBuffer.dwFileFlags & VS_FF_INFOINFERRED) != 0)
					{
						FileFlags = FileFlags + "Info ";
					}
					if ((udtVerBuffer.dwFileFlags & VS_FF_SPECIALBUILD) != 0)
					{
						FileFlags = FileFlags + "Special ";
					}
					if ((udtVerBuffer.dwFileFlags & VFT2_UNKNOWN) != 0)
					{
						FileFlags = FileFlags + "Unknown ";
					}
					
					//**** Determine OS for which file was designed ****
					switch(udtVerBuffer.dwFileOS)
					{
						case VOS_DOS_WINDOWS16 : 
							FileOS = "DOS-Win16"; 
							break;
						case VOS_DOS_WINDOWS32 : 
							FileOS = "DOS-Win32"; 
							break;
						case VOS_OS216_PM16 : 
							FileOS = "OS/2-16 PM-16"; 
							break;
						case VOS_OS232_PM32 : 
							FileOS = "OS/2-16 PM-32"; 
							break;
						case VOS_NT_WINDOWS32 : 
							FileOS = "NT-Win32"; 
							//Case other 
							// FileOS = "Unknown" 
							break;
					}
					switch(udtVerBuffer.dwFileType)
					{
						case VFT_APP : 
							FileType = "App"; 
							break;
						case VFT_DLL : 
							FileType = "DLL"; 
							break;
						case VFT_DRV : 
							FileType = "Driver"; 
							switch(udtVerBuffer.dwFileSubtype)
							{
								case VFT2_DRV_PRINTER : 
									FileSubType = "Printer drv"; 
									break;
								case VFT2_DRV_KEYBOARD : 
									FileSubType = "Keyboard drv"; 
									break;
								case VFT2_DRV_LANGUAGE : 
									FileSubType = "Language drv"; 
									break;
								case VFT2_DRV_DISPLAY : 
									FileSubType = "Display drv"; 
									break;
								case VFT2_DRV_MOUSE : 
									FileSubType = "Mouse drv"; 
									break;
								case VFT2_DRV_NETWORK : 
									FileSubType = "Network drv"; 
									break;
								case VFT2_DRV_SYSTEM : 
									FileSubType = "System drv"; 
									break;
								case VFT2_DRV_INSTALLABLE : 
									FileSubType = "Installable"; 
									break;
								case VFT2_DRV_SOUND : 
									FileSubType = "Sound drv"; 
									break;
								case VFT2_DRV_COMM : 
									FileSubType = "Comm drv"; 
									break;
								case VFT2_UNKNOWN : 
									FileSubType = "Unknown"; 
									break;
							} 
							//      Case VFT_FONT 
							//         FileType = "Font" 
							//         Select Case udtVerBuffer.dwFileSubtype 
							//            Case VFT_FONT_RASTER 
							//               FileSubType = "Raster Font" 
							//            Case VFT_FONT_VECTOR 
							//               FileSubType = "Vector Font" 
							//            Case VFT_FONT_TRUETYPE 
							//               FileSubType = "TrueType Font" 
							//         End Select 
							break;
						case VFT_VXD : 
							FileType = "VxD"; 
							break;
						case VFT_STATIC_LIB : 
							FileType = "Lib"; 
							break;
						default:
							FileType = "Unknown"; 
							break;
					}
			}
			private bool ComparaVersiones( string pStrArchivoOrigen,  string PStrArchivoDestino)
			{
					string[] strFileVersion = new string[]{String.Empty, String.Empty, String.Empty};
					
					FullFileName = pStrArchivoOrigen;
					DisplayVerInfo();
					strFileVersion[0] = FileVer;
					FullFileName = PStrArchivoDestino;
					DisplayVerInfo();
					strFileVersion[1] = FileVer;
					return strFileVersion[1] == strFileVersion[0];
			}
			
			
			private void  CORSGPRE_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					this.Hide();
					this.Close();
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					string strDllSqlOrigen = String.Empty;
					string strDllSqlDestino = String.Empty;
					try
					{
							this.Left = (int) VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
							this.Top = (int) VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(Screen.PrimaryScreen.Bounds.Height) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
							mdlParametros.ES_DEBUG = Interaction.Command().Trim().ToUpper() == "DEBUG";
							if (mdlParametros.ES_DEBUG)
							{
								if (! mdlSeguridad.InicializarLog())
								{
									Environment.Exit(0);
								}
							}
							strDllSqlOrigen = Path.GetDirectoryName(Application.ExecutablePath);
							if (! strDllSqlOrigen.EndsWith("\\"))
							{
								strDllSqlOrigen = strDllSqlOrigen + "\\";
							}
							strDllSqlOrigen = strDllSqlOrigen + "sqlsrv32.dll";
							strDllSqlDestino = WindowsSystemDir();
							if (! strDllSqlDestino.EndsWith("\\"))
							{
								strDllSqlDestino = strDllSqlDestino + "\\";
							}
							strDllSqlDestino = strDllSqlDestino + "Sqlsrv32.dll";
							if (! ComparaVersiones(strDllSqlDestino, strDllSqlOrigen))
							{
								File.Copy(strDllSqlOrigen, strDllSqlDestino);
							}
							
							ID_PRE_VER_TXT.Text = "Version: " + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMajorPart.ToString() + "." + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMinorPart.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
							this.Refresh();
							
							if (CORPROC.ModuloEnUso("Tarjeta Corporativa Banamex") != 0)
							{
								//AIS-1182 NGONZALEZ
								CORVAR.igblErr = API.USER.PostMessage(CORSGPRE.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
								return;
							} else
							{
								this.Show();
								this.Refresh();
							}
						}
					catch 
					{
						
						if (Information.Err().Number == 75)
						{
							MdlCambioMasivo.MsgError("Su sistema operativo no pudo ser actualizado" + "\r\n" + "Verifique que el archivo : " + "\r\n" + "\r\n" + strDllSqlDestino + "\r\n" + "\r\n" + "No este dañado o que tenga permisos adecuados");
							Environment.Exit(0);
						} else
						{
							if (MdlCambioMasivo.fnGetError())
							{
								//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
								throw new Exception("Migration Exception: 'Resume' not supported");
							}
						}
					}
					
					
			}
			
			private void  CORSGPRE_Closing( Object eventSender,  CancelEventArgs eventArgs)
			{
					int Cancel = (eventArgs.Cancel) ? -1: 0;
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							if (CORPROC.ModuloEnUso("Tarjeta Corporativa Banamex") != 0)
							{
								Interaction.AppActivate("Tarjeta Corporativa Banamex");
								//AIS-1182 NGONZALEZ
								CORVAR.igblErr = API.USER.PostMessage(CORSGPRE.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
								return;
							} else
							{
								CORMDIBN.DefInstance.Show();
							}
							ID_MDI_TIM_TMR.Enabled = false;
							eventArgs.Cancel = Cancel != 0;
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
			}
			
			static int iCiclos_ID_MDI_TIM_TMR_Tick = 0;
			private void  ID_MDI_TIM_TMR_Tick( Object eventSender,  EventArgs eventArgs)
			{
					iCiclos_ID_MDI_TIM_TMR_Tick++;
					//Carga la forma MDI mientras la pantalla de presentación esta presente
					if (iCiclos_ID_MDI_TIM_TMR_Tick >= 1000)
					{
						ID_MDI_TIM_TMR.Enabled = false;
						this.Close();
					}
					if (iCiclos_ID_MDI_TIM_TMR_Tick == 1)
					{
						CORMDIBN tempLoadForm = CORMDIBN.DefInstance;
					}
					//DoEvents
			}
			private void  CORSGPRE_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}