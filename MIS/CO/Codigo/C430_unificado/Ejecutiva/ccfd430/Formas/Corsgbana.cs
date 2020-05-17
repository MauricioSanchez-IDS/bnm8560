//AIS-1196 NGONZALEZ
using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORSGBAN
		: System.Windows.Forms.Form
		{
		
			private void  CORSGBAN_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private void  Carga_Bancos()
			{
					
					int hBanco = 0;
					int iBancoPref = 0;
					int iBancoCve = 0;
					int iIndice = 0;
					string pszBancoDes = String.Empty;
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " con_pref,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " con_banco,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " con_ban_des";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCON01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where con_tipo_prod = 'C'";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by con_banco";
					
					int iContBancos = CORVB.NULL_INTEGER;
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							iBancoPref = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
							iBancoCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
							pszBancoDes = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL);
							ID_BAN_BAN_LB.Items.Add(StringsHelper.Format(iBancoPref, "0000") + " - " + StringsHelper.Format(iBancoCve, "00") + " - " + pszBancoDes.Trim());
							
							if (CORVAR.igblBanco == iBancoCve)
							{
								iIndice = iContBancos;
							}
							iContBancos++;
						};
					} else
					{
						//AIS-1182 NGONZALEZ
						CORVAR.igblErr = API.USER.PostMessage(CORSGBAN.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					if (ID_BAN_BAN_LB.Items.Count > CORVB.NULL_INTEGER)
					{
						ID_BAN_BAN_LB.SelectedIndex = iIndice;
					}
					
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					
					this.Cursor = Cursors.WaitCursor;
					
					Carga_Bancos();
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  ID_BAN_SAL_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					
					string pszBanco = VB6.GetItemString(ID_BAN_BAN_LB, ListBoxHelper.GetSelectedIndex(ID_BAN_BAN_LB));
					int iPos = Strings.Mid(pszBanco, 1, pszBanco.IndexOf(' ')).Length + 3;
					
					mdlParametros.gprdProducto.prConfiguraProducto(Convert.ToInt32(Conversion.Val(Strings.Mid(pszBanco, 1, pszBanco.IndexOf(' ')))), Convert.ToInt32(Conversion.Val(Strings.Mid(pszBanco, iPos, pszBanco.IndexOf(' ')))));
					CORVAR.igblPref = mdlParametros.gprdProducto.PrefijoL;
					CORVAR.igblBanco = mdlParametros.gprdProducto.BancoL;
					
					CORMDIBN.DefInstance.Text = "Tarjeta Corporativa Banamex Credito " + "[ " + pszBanco + " ]";
					
					if (CORVAR.igblBanco == 80)
					{
						//CORMDIBN.IDM_BNX.Enabled = True
					} else
					{
						//CORMDIBN.IDM_BNX.Enabled = False
					}
					
					Formato.prConfiguraLongEmpEje(CORVAR.igblPref, CORVAR.igblBanco);
					this.Close();
					
			}
			private void  CORSGBAN_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}