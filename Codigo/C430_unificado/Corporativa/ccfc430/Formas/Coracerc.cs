using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORACERC
		: System.Windows.Forms.Form
		{
		
			private void  CORACERC_Activated( Object eventSender,  EventArgs eventArgs)
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
			//**       --------------------------------------------------------         **
			//**                                                                        **
			//**       Descripción: Presentacion de la informacion de los recursos      **
			//**                    del sistema y de la version                         **
			//**                                                                        **
			//**       Responsable: Felipe Zacarias Jimenez                             **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 06/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			//atr
			//Declare Function GetFreeSpace Lib "Kernel" (ByVal wFlags) As Long
			//Declare Function GetWinFlags Lib "Kernel" () As Long
			
			const int WF_STANDARD = 0x10;
			const int WF_ENHANCED = 0x20;
			const int WF_80x87 = 0x400;
			
			public double Carga_Version()
			{
					
					int hConexion = 0;
					int hStmt = 0;
					double dVersion = 0;
					
					CORVAR.pszgblsql = "Select pgs_ver From " + CORBD.DB_SYB_PGS;
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							dVersion = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					
					return dVersion;
					
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code
			//private void  Command1_Click()
			//{
					//this.Cursor = Cursors.WaitCursor;
					//CRSGeneral.prGenerarRelacionEjeCorp((TextBox) "C:\\Windows\\Escritorio\\Relación Empresa - Ejecutivos.txt");
					//CRSGeneral.prGenerarCuentasCorp((TextBox) "C:\\Windows\\Escritorio\\Tarjetas Corporativas.txt");
					//this.Cursor = Cursors.Default;
			//}
			
			//UPGRADE_NOTE: (7001) The following declaration (recursiva) seems to be dead code
			//static int Y_recursiva = 0;
			//private int recursiva( int Numero)
			//{
					//
					//for (int X = 1; X <= 10; X++)
					//{
						//Debug.Print Y
						//Y_recursiva++;
						//recursiva(X);
					//}
					//return 0;
			//}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			public void  Form_Load()
			{
					int WinFlags = 0;
					string Mode = String.Empty, Processor = String.Empty;
                    API.KERNEL.MEMORYSTATUS YourMemory = new API.KERNEL.MEMORYSTATUS();
                    API.KERNEL.SystemInfo YourSystem = new API.KERNEL.SystemInfo();
					
					string CRLF = "\r" + "\n";
					
					ID_ACE_ETI3_TXT.Text = ID_ACE_ETI3_TXT.Text + " " + StringsHelper.Format(Carga_Version(), "##0.00");
					
					SetBounds(Convert.ToInt32((float) VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float) VB6.PixelsToTwipsX(Width))) / 2)), Convert.ToInt32((float) VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(Screen.PrimaryScreen.Bounds.Height) - ((float) VB6.PixelsToTwipsY(Height))) / 2)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
					
					// toma la Configuración actual de Windows
					//  WinFlags = GetWinFlags()
					//  WinFlags = GetDesktopWindow()
                    //AIS-1182 NGONZALEZ

                    API.KERNEL.GlobalMemoryStatus(ref YourMemory);
                    //AIS-1182 NGONZALEZ
                    API.KERNEL.GetSystemInfo(ref YourSystem);

					ID_ACE_ETI1_TXT.Text = "Modo: " + CRLF + " Memoria Libre: " + CRLF + " Co-procesador Matemático: ";
					//  If WinFlags And WF_80x87 Then Processor = "Presente" Else Processor = "Ninguno"
					Mode = ((WinFlags & WF_ENHANCED) != 0) ? "Extendido": "Estándar";
					//  ID_ACE_ETI2_TXT.Caption = Mode + CRLF + Format$(GetFreeSpace(0) \ 1024) + " KB" + CRLF + Processor
                    ID_ACE_ETI2_TXT.Text = Mode + CRLF + Conversion.Str(YourMemory.dwMemoryLoad) + " %" + CRLF + Conversion.Str(YourSystem.dwProcessorType);
					
					this.Cursor = Cursors.Default;
					
			}
			
			public void  CORACERC_Closed( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Close();
					
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			
			public void  ID_ACE_OK_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}

        private void CORACERC_Load(object sender, EventArgs e)
        {

        }
		}
}