using Artinsoft.VB6.Gui; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frm_error_envio
		: System.Windows.Forms.Form
		{
		
			private void  frm_error_envio_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private void  cmdAceptar_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
			}
		}
}