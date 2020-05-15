using Artinsoft.VB6.Gui; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORACCOM
		: System.Windows.Forms.Form
		{
		
			string msCveAcc = String.Empty;
			
			private void  CORACCOM_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						
						//UPGRADE_TODO: (1065) Error handling statement (On Error Resume Next) could not be converted properly. A throw statement was generated instead.
						throw new Exception("Migration Exception: 'On Error Resume Next' not supported");
						this.Cursor = Cursors.Default;
						ID_ACC_NOM_TXT.Text = CORVB.NULL_STRING;
						ID_ACC_CVE_TXT.Text = CORVB.NULL_STRING;
						ID_ACC_NOM_TXT.Focus();
						msCveAcc = CORVB.NULL_STRING;
						
					}
			}
			
			private void  ID_ACC_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					CORACCOM.DefInstance.Tag = "Cancelar";
					this.Hide();
					
			}
			
			private void  ID_ACC_CVE_TXT_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					
					//    If (KeyAscii < 48 Or KeyAscii > 57) And KeyAscii <> 8 Then
					//        KeyAscii = NULL_INTEGER
					//    End If
					msCveAcc = msCveAcc + Strings.Chr(KeyAscii).ToString();
					
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			
			private void  ID_ACC_NOM_TXT_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					
					if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
					{
						//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
						KeyAscii = CORVB.NULL_INTEGER;
					}
					
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			
			private void  ID_ACC_OK_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							if (ID_ACC_NOM_TXT.Text == CORVB.NULL_STRING || ID_ACC_CVE_TXT.Text == CORVB.NULL_STRING)
							{
								MessageBox.Show("Se requiere capturar ambos datos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							} else
							{
								CORACCOM.DefInstance.Tag = "Aceptar";
								ID_ACC_CVE_TXT.Text = msCveAcc;
								this.Hide();
							}
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			private void  CORACCOM_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}