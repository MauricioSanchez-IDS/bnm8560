using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class ConsulUni
		: System.Windows.Forms.Form
		{
		
			private void  ConsulUni_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  Command2_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.unit_id,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " b.unit_name";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUCT01 a, MTCUNI01 b";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = b.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = b.unit_id";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.cat_id = " + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by a.unit_id";
					
					LS_UNIDADES.Items.Clear();
					
					if (CORPROC2.Cuenta_Registros() >= 1)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								LS_UNIDADES.Items.Add(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "00000") + new String(' ', 15) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
							};
						}
					} else
					{
						//MsgBox "No se encontro ninguna Unidad ligada a la Categoría: " & Format(Val(Mid(CORCTCATS.ID_CAT_LB.Text, 7, 4)), "0000"), vbInformation + vbOKOnly, "Tarjeta Corporativa"
						Formato.bgForma = false;
						return;
					}
					
					this.Height = (int) VB6.TwipsToPixelsY(2640);
					this.Width = (int) VB6.TwipsToPixelsX(5355);
					this.Top = (int) VB6.TwipsToPixelsY(2835);
					this.Left = (int) VB6.TwipsToPixelsX(4860);
					
					Formato.bgForma = true;
					
			}
			private void  ConsulUni_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}