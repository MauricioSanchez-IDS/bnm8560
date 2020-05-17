using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class MCC
		: System.Windows.Forms.Form
		{
		
			private void  MCC_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private void  CM_CAN_MCC_Click( Object eventSender,  EventArgs eventArgs)
			{
					Formato.bPrimeraVez = false;
					this.Close();
			}
			
			private void  CM_SEL_MCC_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					if (ListBoxHelper.GetSelectedIndex(ID_MCC_GRP_LB) != -1)
					{
						Formato.dMCC = Conversion.Val(Strings.Mid(ID_MCC_GRP_LB.Text, 1, 6));
						Formato.bPrimeraVez = true;
						this.Close();
					} else
					{
						MessageBox.Show("No ha seleccionado ningun valor de MCC", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						Formato.bPrimeraVez = false;
						return;
					}
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Height = (int) VB6.TwipsToPixelsY(3300);
					this.Width = (int) VB6.TwipsToPixelsX(6555);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					
					Formato.bPrimeraVez = false;
					
					ID_MCC_GRP_LB.Items.Clear();
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " b06_acd_num_acd,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " b06_acd_des_acd";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCACT01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by b06_acd_num_acd";
					
					if (CORPROC2.Cuenta_Registros() >= 1)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								ID_MCC_GRP_LB.Items.Add(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "000000") + new String(' ', 15) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
							};
						}
						ID_MCC_GRP_LB.SelectedIndex = 0;
					}
					
			}
			private void  MCC_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}