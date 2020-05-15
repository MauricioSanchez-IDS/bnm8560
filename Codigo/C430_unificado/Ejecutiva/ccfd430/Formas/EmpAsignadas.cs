using Artinsoft.VB6.Gui; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class EmpAsig
		: System.Windows.Forms.Form
		{
		
			private void  EmpAsig_Activated( Object eventSender,  EventArgs eventArgs)
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
					
					this.Height = (int) VB6.TwipsToPixelsY(3120);
					this.Width = (int) VB6.TwipsToPixelsX(5190);
					this.Top = (int) VB6.TwipsToPixelsY(2790);
					this.Left = (int) VB6.TwipsToPixelsX(4920);
					
					EMPRESA_ESTRUCT_LB.Items.Clear();
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " replicate('0',(select pgs_long_emp from MTCPGS01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where pgs_rep_prefijo = a.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and pgs_rep_banco = a.gpo_banco)-char_length(ltrim(str(a.emp_num))))+";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ltrim(str(a.emp_num)),";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.emp_nom , a.emp_estruct_gastos, b.exp_struc_id";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01 a,MTCEST01 b";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where a.eje_prefijo = b.exp_eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.exp_gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_estruct_gastos = b.exp_struc_id";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_estruct_gastos = " + Conversion.Val(Formato.IdEstruct).ToString();
					
					if (CORPROC2.Cuenta_Registros() >= 1)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								switch(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length)
								{
									case 1 : 
										EMPRESA_ESTRUCT_LB.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 8) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim()); 
										break;
									case 2 : 
										EMPRESA_ESTRUCT_LB.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 7) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim()); 
										break;
									case 3 : 
										EMPRESA_ESTRUCT_LB.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 6) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim()); 
										break;
									case 4 : 
										EMPRESA_ESTRUCT_LB.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim()); 
										break;
									case 5 : 
										EMPRESA_ESTRUCT_LB.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim()); 
										break;
									case 6 : 
										EMPRESA_ESTRUCT_LB.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 3) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim()); 
										break;
								}
							};
						}
						EMPRESA_ESTRUCT_LB.SelectedIndex = CORVB.NULL_INTEGER;
					} else
					{
						MessageBox.Show("No se encontro ninguna Empresa Ligada a la Estructura: " + Conversion.Val(Formato.IdEstruct).ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						Formato.bgForma = false;
						return;
					}
					
					this.Cursor = Cursors.Default;
					Formato.bgForma = true;
					
			}
			private void  EmpAsig_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}