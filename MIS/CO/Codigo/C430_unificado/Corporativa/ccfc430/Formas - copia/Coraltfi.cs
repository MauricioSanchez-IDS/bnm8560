//AIS-1070 NGONZALEZ
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.IO; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORALTFI
		: System.Windows.Forms.Form
		{
		
			
			
			//****************************************************************************
			//**                                                                        **
			//**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
			//**                                                                        **
			//**       --------------------------------------------------------         **
			//**                                                                        **
			//**       Descripción: Captura de Firmas para Ejecutivos Banamex           **
			//**                                                                        **
			//**       Responsable: Felipe Zacarias Jimenez                             **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 06/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			int lAltoImagen = 0;
			int lAnchoImagen = 0;
			
			public int ClipboardWidth = 0;
			public int ClipboardHeight = 0;
			public int ClipboardBitsPerPixel = 0;
			
			int bDirty = 0;
			int hALTConexion = 0;
			
			private void  Carga_Firma()
			{
					
					int hFirma = 0;
					int iCiclos = 0;
					int iPos = 0;
					int lLongitud = 0;
					string pszFirma = String.Empty;
					FixedLengthString szEmpFirma = new FixedLengthString(5000);
					string pszNomEjx = String.Empty;
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_FIR_GUA_IMM.ClearImage = true;
					
					//Obtiene firma de Ejecutivo Banamex
					IMAGEN.LeerImagen(ID_FIR_GUA_IMM, "MTCEJX01", "ejx_firma", " where ejx_numero = " + CORVAR.lgblEjxCve.ToString());
					
					this.Cursor = Cursors.Default;
					
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Top = (int) VB6.TwipsToPixelsY(1880);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(Width))) / 2);
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_FIR_GUA_IMM.ClearImage = true;
					ID_FIR_PAG_IMM.ClearImage = true;
					ID_FIR_OK_IMM.ClearImage = true;
					
					ID_FIR_PAG_IMM.SelectEvent = 1;
					
					if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_CAMBIO)
					{
						Carga_Firma();
					} else
					{
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  CORALTFI_Closed( Object eventSender,  EventArgs eventArgs)
			{
					
					CORVAR.bgblFirma = -1;
					
					
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			
			private void  ID_FIR_ACE_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					int lArchiLong = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					CORVAR.bgblModFirma = 0;
					
					if (FileSystem.Dir(CORVAR.pszgblPathFirmas + "firma.pcx", FileAttribute.Normal) != CORVB.NULL_STRING)
					{
						lArchiLong = (int) (new FileInfo(CORVAR.pszgblPathFirmas + "firma.pcx")).Length;
						
						if (lArchiLong > 16000)
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("La firma del Ejecutivo Banamex es demasiado grande. Favor de minimizarla.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
							IMAGEN.nomArchivo = "";
						} else
						{
							ID_FIR_OK_IMM.DelImage = true;
							ID_FIR_PAG_IMM.DelImage = true;
							
							IMAGEN.nomArchivo = CORVAR.pszgblPathFirmas + "firma.pcx";
							
							this.Close();
							
							CORVAR.bgblModFirma = -1;
							
							this.Cursor = Cursors.Default;
						}
						
					} else
					{
						
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No existe una firma para el Ejecutivo. Favor realizar el escaneo nuevamente.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
						
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_FIR_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					this.Close();
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_FIR_GUA_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_FIR_ACE_PB.Enabled = true;
					
					ID_FIR_OK_IMM.ClipboardCopy = true;
					
					ID_FIR_GUA_IMM.ClipboardPaste = true;
					ID_FIR_GUA_IMM.FitMethod = 1;
					
					ID_FIR_OK_IMM.SaveFormat = GEAR.IG_SAVE_BMP_UNCOMP; //IG_SAVE_PCX
					ID_FIR_OK_IMM.SaveImage = CORVAR.pszgblPathFirmas + "firma.pcx";
					ID_FIR_OK_IMM.SaveQuality = 55;
					
					
					
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_FIR_INS_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_FIR_OK_IMM.ScanOpenSource = true;
					
			}
            //AIS-1070 NGONZALEZ
			private void  ID_FIR_PAG_IMM_SelectEvent( Object eventSender,  AxGEARLib._DGearEvents_SelectEventEvent eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					//para realizar el rectangulo o area seleccionada
					ID_FIR_PAG_IMM.ImageRectLeft = eventArgs.lplLeft;
					ID_FIR_PAG_IMM.ImageRectTop = eventArgs.lplTop;
					ID_FIR_PAG_IMM.ImageRectRight = eventArgs.lplRight;
					ID_FIR_PAG_IMM.ImageRectBottom = eventArgs.lplBottom;
					
					lAltoImagen = eventArgs.lplBottom - eventArgs.lplTop;
					lAnchoImagen = eventArgs.lplRight - eventArgs.lplLeft;
					
					ID_FIR_PAG_IMM.ScanShowUI = false;
					
					ID_FIR_OK_IMM.ScanLeft = 0;
					ID_FIR_OK_IMM.ScanRight = eventArgs.lplRight - eventArgs.lplLeft;
					ID_FIR_OK_IMM.ScanTop = 0;
					ID_FIR_OK_IMM.ScanBottom = eventArgs.lplBottom - eventArgs.lplTop;
					
					ID_FIR_OK_IMM.ClearImage = true;
					
					//Copy the image seleccionada al clipboard
					ID_FIR_PAG_IMM.ClipboardCopy = true;
					ID_FIR_OK_IMM.ClipboardPaste = true;
					
					ID_FIR_OK_IMM.FitMethod = 3;
					ID_FIR_OK_IMM.ZoomLevel = 30;
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_FIR_SCA_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_FIR_GUA_PB.Enabled = true;
					
					ID_FIR_PAG_IMM.ScanShowUI = true;
					
					//limpio los controles
					ID_FIR_PAG_IMM.ClearImage = false;
					ID_FIR_OK_IMM.ClearImage = false;
					
					ID_FIR_PAG_IMM.ErrCount = CORVB.NULL_INTEGER;
					
					//abre la ventana para escanear
					ID_FIR_PAG_IMM.ScanAcquire = true;
					
					if (ID_FIR_PAG_IMM.ErrCount != CORVB.NULL_INTEGER)
					{
						
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("El Escaner seleccionado no está instalado. ", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
						return;
						
					}
					//  ID_FIR_PAG_IMM.SelectEvent = 1
					ID_FIR_PAG_IMM.FitMethod = 3;
					ID_FIR_PAG_IMM.ZoomLevel = 30;
					
					ID_FIR_PAG_IMM.Focus();
					
					this.Cursor = Cursors.Default;
					
			}
		}
}