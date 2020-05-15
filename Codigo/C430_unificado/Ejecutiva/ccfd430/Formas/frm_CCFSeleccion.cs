using Artinsoft.VB6.Gui; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frm_CCFSeleccion
		: System.Windows.Forms.Form
		{
		
			private void  frm_CCFSeleccion_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  Command1_Click( Object eventSender,  EventArgs eventArgs)
			{
					if (opt_CCF.Checked)
					{
						CRSParametros.giccftipo = 1;
					} else if (opt_SBF.Checked) { 
						CRSParametros.giccftipo = 2;
					} else
					{
						CRSParametros.giccftipo = 3;
					}
					Command2_Click(Command2, new EventArgs());
			}
			
			private void  Command2_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					CRSParametros.giccftipo = 0;
			}
		}
}