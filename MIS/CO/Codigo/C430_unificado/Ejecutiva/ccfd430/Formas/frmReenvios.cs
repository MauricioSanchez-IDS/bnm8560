using Artinsoft.VB6.Gui; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmReenvios
		: System.Windows.Forms.Form
		{
		
			private void  frmReenvios_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  frmReenvios_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}