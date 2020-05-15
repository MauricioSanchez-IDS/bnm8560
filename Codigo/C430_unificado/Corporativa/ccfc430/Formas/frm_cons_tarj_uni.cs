using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frm_cons_tarj_uni
		: System.Windows.Forms.Form
		{
		
			private void  frm_cons_tarj_uni_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private void  CM_CAN_MCC_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					int I = 0;
					int iCont = 0;
					string lstrEmp = String.Empty;
					string s = String.Empty;
					int reg = 0;
					int iEjeNum = 0;
					string sEjeNom = String.Empty;
					
					this.Height = (int) VB6.TwipsToPixelsY(4605);
					this.Width = (int) VB6.TwipsToPixelsX(8370);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					
					CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
					mkbMaskebox[0].Enabled = false;
					mkbMaskebox[1].Enabled = false;
					mkbMaskebox[2].Enabled = false;
					mkbMaskebox[2].Format = "00";
					
					CORVAR.pszgblsql = "select ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.unit_id,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.unit_name,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.nivel_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_nombre";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01 a,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCEJE01 b";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = b.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = b.emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = b.eje_centro_c";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblEmpCve.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = '" + CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim() + "'";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by b.eje_num";
					
					ID_TARJ_UNI_LB.Items.Clear();
					if (CORPROC2.Cuenta_Registros() > 0)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								mkbMaskebox[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim(); //Unidad
								mkbMaskebox[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim(); //Nombre
								mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString(); //Nivel
								iEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4))); //Eje_Num
								sEjeNom = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim(); //Eje_Nombre
								ID_TARJ_UNI_LB.Items.Add(new String(' ', 20) + StringsHelper.Format(iEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + new String(' ', 25) + sEjeNom);
							};
						}
					} else
					{
						MessageBox.Show("No se encontraron datos de TarjetaHabientes Asignados a la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						Formato.bgForma = false;
						return;
					}
					this.Cursor = Cursors.Default;
					Formato.bgForma = true;
			}
			private void  frm_cons_tarj_uni_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}