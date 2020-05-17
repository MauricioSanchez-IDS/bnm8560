using Artinsoft.VB6.Gui; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmPwdTelnet
		: System.Windows.Forms.Form
		{
		
			private void  frmPwdTelnet_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			public bool LoginSucceeded = false;
			
			private void  cmdCancel_Click( Object eventSender,  EventArgs eventArgs)
			{
					//set the global var to false
					//to denote a failed login
					LoginSucceeded = false;
					this.Hide();
			}
			
			private void  cmdOK_Click( Object eventSender,  EventArgs eventArgs)
			{
					//check for correct password
					if (txtPassword.Text != "password")
					{
						//place code to here to pass the
						//success to the calling sub
						//setting a global var is the easiest
						LoginSucceeded = true;
						this.Hide();
					} else
					{
						MessageBox.Show("El password no puede estar vacio!", "Login");
						txtPassword.Focus();
						
					}
			}
		}
}