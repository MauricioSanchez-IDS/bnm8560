using Artinsoft.VB6.Gui; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class FrmRptCambioMasivo
		: System.Windows.Forms.Form
		{
		
			private void  FrmRptCambioMasivo_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  BtnSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			private bool isInitializingComponent;
			private void  FrmRptCambioMasivo_Resize( Object eventSender,  EventArgs eventArgs)
			{
					if (isInitializingComponent)
					{
						return;
					}
					LstReporte.Height = (int) (this.Height - VB6.TwipsToPixelsY(1500));
					LstReporte.Width = (int) (this.Width - VB6.TwipsToPixelsX(350));
			}
		}
}