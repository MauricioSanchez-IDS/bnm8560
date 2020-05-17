using Artinsoft.VB6.Gui; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmAccesoBancanet
		: System.Windows.Forms.Form
		{
		
			private void  frmAccesoBancanet_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			public string sgModoSalida = String.Empty;
			
			private void  cmdmAceptar_Click( Object eventSender,  EventArgs eventArgs)
			{
					if (fncValidaEntradaB())
					{
						sgModoSalida = "aceptar";
						this.Hide();
					}
			}
			
			private void  cmdmSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					sgModoSalida = "cancelar";
					this.Hide();
			}
			
			private bool fncValidaEntradaB()
			{
					bool result = false;
					result = true;
					if (txtmUsuario.Text.Trim() == CORVB.NULL_STRING)
					{
						MessageBox.Show("Introduzca su Nomina", Application.ProductName);
						return false;
					}
					if (txtmPassword.Text.Trim() == CORVB.NULL_STRING)
					{
						MessageBox.Show("Introduzca su Clave", Application.ProductName);
						return false;
					}
					if (txtmUsuario.Text.IndexOf(' ') >= 0)
					{
						result = false;
						txtmUsuario.Text = "";
					}
					if (txtmPassword.Text.IndexOf(' ') >= 0)
					{
						txtmPassword.Text = "";
						return false;
					}
					if (! fncValidaTxt(txtmUsuario.Text))
					{
						txtmUsuario.Text = "";
						result = false;
					}
					if (! fncValidaTxt(txtmPassword.Text))
					{
						txtmPassword.Text = "";
						result = false;
					}
					
					return result;
			}
			private bool fncValidaTxt( string spTexto)
			{
					string slCadena = spTexto.Trim();
					
					if (slCadena == "")
					{
						return false;
					}
					if (slCadena.IndexOf(' ') >= 0)
					{
						return false;
					}
					for (int ilContador = 1; ilContador <= slCadena.Length; ilContador++)
					{
						if (! fncCaracterValidoB(Strings.Mid(slCadena, ilContador, 1)))
						{
							return false;
						}
					}
					return true;
			}
			
			private bool fncCaracterValidoB( string spCaracter)
			{
					int ilCaracter = (int) spCaracter[0];
					if (ilCaracter >= 48 && ilCaracter <= 57)
					{
						return true;
					}
					if (ilCaracter >= 65 && ilCaracter <= 90)
					{
						return true;
					}
					if (ilCaracter >= 97 && ilCaracter <= 122)
					{
						return true;
					}
					if (ilCaracter == 241)
					{
						return true;
					}
					if (ilCaracter == 209)
					{
						return true;
					}
					return false;
			}
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					//txtmUsuario.SetFocus
					int iResp = 0;
					int iGrupos = 0;
					
					this.Width = (int) VB6.TwipsToPixelsX(5880);
					this.Height = (int) VB6.TwipsToPixelsY(2310);
					int iLeft = Convert.ToInt32((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(Width))) / 2);
					int iTop = Convert.ToInt32((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(Height))) / 2);
					this.SetBounds(Convert.ToInt32((float) VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float) VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
					
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (prInicializa) seems to be dead code
			//private void  prInicializa()
			//{
					//txtmUsuario.Text = "";
					//txtmPassword.Text = "";
			//}
			
			private void  txtmPassword_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int keyascii = (int) eventArgs.KeyChar;
					if (keyascii == 13)
					{
						cmdmAceptar.Focus();
					} else
					{
						//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
						keyascii = fncValidaEntrada(ref keyascii, txtmPassword);
					}
					if (keyascii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(keyascii);
			}
			
			private void  txtmUsuario_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int keyascii = (int) eventArgs.KeyChar;
					if (keyascii == 13)
					{
						txtmPassword.Focus();
					} else
					{
						//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
						keyascii = fncValidaEntrada(ref keyascii, txtmUsuario);
					}
					if (keyascii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(keyascii);
			}
			private int fncValidaEntrada(ref  int keyascii,  TextBox txtpNumero)
			{
					if (keyascii == 8)
					{
						return 8;
					}
					if (txtpNumero.Text.Trim().Length >= 12)
					{
						keyascii = 0;
						return 0;
					}
					if (keyascii >= 97 && keyascii <= 122)
					{
						return keyascii;
					}
					if (keyascii >= 65 && keyascii <= 90)
					{
						return keyascii;
					}
					if (keyascii >= 48 && keyascii <= 57)
					{
						return keyascii;
					}
					
					return 0;
			}
			private void  frmAccesoBancanet_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}