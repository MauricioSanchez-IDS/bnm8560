using Artinsoft.VB6.Gui; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frm_Tran_Cat
		: System.Windows.Forms.Form
		{
		
			private void  frm_Tran_Cat_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private void  cmd_cancel_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					this.Height = (int) VB6.TwipsToPixelsY(5400);
					this.Width = (int) VB6.TwipsToPixelsX(11490);
			}
			private void  frm_Tran_Cat_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}