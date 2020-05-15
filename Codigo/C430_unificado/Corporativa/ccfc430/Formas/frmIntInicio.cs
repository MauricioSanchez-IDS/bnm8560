using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmIntInicio
		: System.Windows.Forms.Form
		{
		
			private void  frmIntInicio_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private void  cmdIntinicio_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					try
					{
                            //AIS-541 NGONZALEZ
                        mdlParametros.gcestResumen = new colEstatusEnvio();
							this.Height = (int) VB6.TwipsToPixelsY(4595);//4485
							this.Width = (int) VB6.TwipsToPixelsX(10965);
							this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
							this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
							mdlParametros.gcestResumen.prBuscaIntResumen();
							prLlenaSpreadIntResumen();
						}
					catch 
					{
						
						string tempRefParam = "FrmIntInicio_Load";
						if (MdlCambioMasivo.fnGetError(ref tempRefParam))
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume' not supported");
						}
					}
			}
			
			private void  prLlenaSpreadIntResumen()
			{
					int llCont = 0;
					
					sprIntInicio.MaxRows = mdlParametros.gcestResumen.Count;
					
					for (int llRow = 1; llRow <= mdlParametros.gcestResumen.Count; llRow++)
					{
						sprIntInicio.Row = llRow;
						//        For llCol = 1 To 4
						for (int llCol = 1; llCol <= 3; llCol++)
						{
							sprIntInicio.Col = llCol;
							switch(llCol)
							{
								case 1 : 
									sprIntInicio.Text = StringsHelper.Format(mdlParametros.gcestResumen[llRow].EmpresaL, mdlParametros.gprdProducto.MascaraEmpresaS); 
									break;
								case 2 : 
									sprIntInicio.Text = mdlParametros.gcestResumen[llRow].NombreEmpresaS; 
									break;
								case 3 : 
									sprIntInicio.Text = (mdlParametros.gcestResumen[llRow].ArchivoPendienteEnvioL + mdlParametros.gcestResumen[llRow].ArchivoNoTransmitidoL).ToString(); 
									//                Case 4 
									//                    sprIntInicio.Text = gcestResumen.Item(llRow).ArchivoNoTransmitidoL 
									break;
							}
						}
					}
			}
			private void  frmIntInicio_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}