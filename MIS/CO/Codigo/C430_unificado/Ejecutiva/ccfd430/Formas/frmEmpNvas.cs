using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmEmpNvas
		: System.Windows.Forms.Form
		{
		
			private void  frmEmpNvas_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			private void  cmdReporte_Click( Object eventSender,  EventArgs eventArgs)
			{
					int intFile = 0;
					string strfile = String.Empty;
					StringBuilder StrCadena = new StringBuilder();
					StrCadena.Append(String.Empty);
					ADODB.Recordset adorst = null;
					string psFecha = String.Empty;
					System.DateTime pdFecha = DateTime.FromOADate(0);
					
					try
					{
							this.Cursor = Cursors.WaitCursor;
							
							mdlParametros.bgCamLimCred = true;
							
							if (VBSQL.OpenConn(10) != 0)
							{
								VBSQL.gConn[10].Close();
							} else
							{
								VBSQL.gConn[10].Close();
							}
							
							if (VBSQL.OpenConn(10) == 0)
							{
								CORVAR.pszgblsql = "SELECT emp_num, emp_nom, emp_fec_venc_cred, emp_cred_tot, ";
								//            pszgblsql = pszgblsql & "emp_acum_cred, emp_dia_corte "
								// Modif. 18/Jun/2007 Calc Lim Real
								//            pszgblsql = pszgblsql & "emp_acum_cred = "
								//            pszgblsql = pszgblsql & " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a "
								//            pszgblsql = pszgblsql & " where a.eje_prefijo = " & igblPref
								//            pszgblsql = pszgblsql & " and a.gpo_banco = " & igblBanco
								//            pszgblsql = pszgblsql & " and a.emp_num = MTCEMP01.emp_num "
								//            pszgblsql = pszgblsql & " and a.eje_num > 0) - "
								//            pszgblsql = pszgblsql & " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d "
								//            pszgblsql = pszgblsql & " where c.eje_prefijo = " & igblPref
								//            pszgblsql = pszgblsql & " and c.gpo_banco = " & igblBanco
								//            pszgblsql = pszgblsql & " and c.emp_num = MTCEMP01.emp_num "
								//            pszgblsql = pszgblsql & " and c.eje_num > 0 and "
								//            pszgblsql = pszgblsql & " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and "
								//            pszgblsql = pszgblsql & " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )), "
								//            pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )), "
								// Modif. 6/Jul/2007 Calc Lim Real
								CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_acum_cred = ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " (select isnull(sum(a.ths_limite_credito),0) from MTCTHS01 a ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = " + CORVAR.igblPref.ToString();
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = MTCEMP01.emp_num ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0  and ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " a.ths_situacion_cta <> 'C' and a.ths_situacion_cta <> 'E'), ";
								
								CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_dia_corte ";
								
								CORVAR.pszgblsql = CORVAR.pszgblsql + "From MTCEMP01 ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " AND gpo_banco=" + CORVAR.igblBanco.ToString() + " ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + "ORDER BY emp_num";
								//           MsgBox pszgblsql
								adorst = new ADODB.Recordset();
								
								adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, -1);
								
								if (! adorst.BOF && ! adorst.EOF)
								{
									intFile = FileSystem.FreeFile();
									
									strfile = mdlParametros.sgPathFirmas + "RepEmpNvas" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
									//pszgblPathRepCrystal
									FileSystem.FileOpen(intFile, strfile, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
									StrCadena = new StringBuilder("Número de Empresa" + "\t" + "Nombre" + "\t" + "Fecha de Vencimiento" + "\t");
									StrCadena.Append("Crédito Asignado" + "\t" + "Crédito Acumulado" + "\t" + "Día de Corte");
									StrCadena.Append("\t" + "Fecha de Alta");
									FileSystem.PrintLine(intFile, StrCadena.ToString());
									
									while (! adorst.EOF)
										{
										
											psFecha = Conversion.Str(adorst.Fields["emp_fech_alta"].Value).Trim();
											pdFecha = DateAndTime.DateSerial(StringsHelper.IntValue(Strings.Mid(psFecha, 1, 4)), StringsHelper.IntValue(Strings.Mid(psFecha, 5, 2)), StringsHelper.IntValue(Strings.Mid(psFecha, 7)));
											
											StrCadena = new StringBuilder(Convert.ToString(adorst.Fields["emp_num"].Value));
											StrCadena.Append("\t" + Convert.ToString(adorst.Fields["emp_nom"].Value).Trim());
											StrCadena.Append("\t" + DateTime.Parse(adorst.Fields["emp_fec_venc_cred"].Value.ToString()).ToString("d"));
											StrCadena.Append("\t" + Convert.ToString(adorst.Fields["emp_cred_tot"].Value));
											StrCadena.Append("\t" + Convert.ToString(adorst.Fields["emp_acum_cred"].Value));
											StrCadena.Append("\t" + Convert.ToString(adorst.Fields["emp_dia_corte"].Value));
											StrCadena.Append("\t" + DateTime.Parse(pdFecha.ToString()).ToString("d"));
											
											FileSystem.PrintLine(intFile, StrCadena.ToString());
											
											adorst.MoveNext();
										}
									FileSystem.FileClose(intFile);
									
									MessageBox.Show("Reporte Generado" + "\n" + "\r" + "Nombre:" + strfile, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								} else
								{
									MessageBox.Show("Reporte No Generado por falta de datos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								}
								
								
								if (adorst.State == 1)
								{
									adorst.Close();
								}
								
								if (VBSQL.gConn[10].State == 1)
								{
									VBSQL.gConn[10].Close();
								}
							}
							
							this.Cursor = Cursors.Default;
						}
					catch 
					{
						
						string tempRefParam = "Tarjeta Corporativa.- cmdReporte_Click";
						if (MdlCambioMasivo.fnGetError(ref tempRefParam))
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume' not supported");
						}
						
						if (adorst.State == 1)
						{
							adorst.Close();
						}
						
						if (VBSQL.gConn[10].State == 1)
						{
							VBSQL.gConn[10].Close();
						}
						this.Cursor = Cursors.Default;
					}
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					this.Width = (int) VB6.TwipsToPixelsX(5505);
					this.Height = (int) VB6.TwipsToPixelsY(1695);
					
					this.Left = (int) VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) / 2) - (((float) VB6.PixelsToTwipsX(this.Width)) / 2));
					this.Top = (int) (Screen.PrimaryScreen.Bounds.Height / 2 - this.Height);
					
					//UPGRADE_WARNING: (1037) Couldn't resolve default property of object DTPicFinal.Value.
					DTPicFinal.Value = DateTime.Now;
					//UPGRADE_WARNING: (1037) Couldn't resolve default property of object DTPicInicial.Value.
					DTPicInicial.Value = DateTime.Now;
					DTPicFinal.MaxDate = DateTime.Now;
					DTPicInicial.MaxDate = DateTime.Now;
					mdlParametros.gperPerfil.prHabilitaAcciones(frmEmpNvas.DefInstance);
			}
			private void  frmEmpNvas_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}