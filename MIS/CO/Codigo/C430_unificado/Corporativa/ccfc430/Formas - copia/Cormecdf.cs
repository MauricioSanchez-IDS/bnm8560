using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORMECDF
		: System.Windows.Forms.Form
		{
		
			
			private void  CORMECDF_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						this.Cursor = Cursors.Default;
					}
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					this.Cursor = Cursors.WaitCursor;
					this.Left = (int) VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					Muestra_Datos();
					this.Cursor = Cursors.Default;
			}
			
			private void  Muestra_Datos()
			{
					
					string pszNomArch = String.Empty;
					int iEstatus = 0;
					string pszMensaje = String.Empty;
					string pszAccion = String.Empty;
					string pszSituacion = String.Empty;
					string pszCadena = String.Empty;
					try
					{
							
							ID_MEN_MEN_LIB.Items.Clear();
							this.Hide();
							pszNomArch = "";
							iEstatus = 0;
							pszMensaje = "";
							pszAccion = "";
							
							CORVAR.pszgblsql = "select";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_nomFisi,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_est_usu";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCPRO02";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where substring(convert(char(20),pro_fecha),1,12) = substring(convert(char(20),getdate()),1,12)";
							
							if (CORPROC2.Cuenta_Registros() >= 1)
							{
								if (CORPROC2.Obtiene_Registros() != 0)
								{
									
									while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
									{
										pszCadena = "";
										pszCadena = new String(' ', 95);
										pszNomArch = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().ToUpper();
										iEstatus = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
										
										if (pszNomArch.Substring(0, Math.Min(pszNomArch.Length, 4)) == "S011")
										{
											if (iEstatus == 0)
											{
												pszSituacion = "OK";
												pszMensaje = "Se ejecuto CDF correctamente";
												pszAccion = "";
											} else if (iEstatus == 1) { 
												pszSituacion = "ERROR";
												pszMensaje = "Proceso CDF con problemas";
												pszAccion = "Avisar a Ing. de Sistemas";
											}
											pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 16, " ");
											pszCadena = StringsHelper.MidAssignment(pszCadena, 17, pszSituacion);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 27, pszMensaje);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 58, " ");
											pszCadena = StringsHelper.MidAssignment(pszCadena, 59, pszAccion);
										} else if (pszNomArch.Substring(0, Math.Min(pszNomArch.Length, 3)) == "SBF") { 
											if (iEstatus == 0)
											{
												pszSituacion = "OK";
												pszMensaje = "Se ejecuto SBF correctamente";
												pszAccion = "";
											} else if (iEstatus == 1) { 
												pszSituacion = "ERROR";
												pszMensaje = "Proceso SBF con problemas";
												pszAccion = "Avisar a Ing. de Sistemas";
											}
											pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 16, " ");
											pszCadena = StringsHelper.MidAssignment(pszCadena, 17, pszSituacion);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 27, pszMensaje);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 58, " ");
											pszCadena = StringsHelper.MidAssignment(pszCadena, 59, pszAccion);
										} else
										{
											if (iEstatus == 0)
											{
												pszSituacion = "OK";
												pszMensaje = "Se ejecuto Reporte correctamente";
												pszAccion = "";
											} else if (iEstatus == 1) { 
												pszSituacion = "ERROR";
												pszMensaje = "Proceso Reporte con problemas";
												pszAccion = "Avisar a Ing. de Sistemas";
											}
											pszCadena = StringsHelper.MidAssignment(pszCadena, 1, pszNomArch);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 16, " ");
											pszCadena = StringsHelper.MidAssignment(pszCadena, 17, pszSituacion);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 27, pszMensaje);
											pszCadena = StringsHelper.MidAssignment(pszCadena, 58, " ");
											pszCadena = StringsHelper.MidAssignment(pszCadena, 59, pszAccion);
										}
										ID_MEN_MEN_LIB.Items.Add(pszCadena);
									};
								}
							} else
							{
								//MsgBox "No se encontro ningun registro del CDF, SBF y Reportes en la Base de Datos", vbInformation + vbOKOnly, "Tarjeta Corporativa"
								//Exit Sub
							}
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
							this.ShowDialog();
						}
                        catch (Exception e)
					{
						
						CRSGeneral.prObtenError("Muestra_Datos",e );
					}
					
			}
			
			private void  ID_MEN_SAL_CB_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Hide();
			}
			private void  CORMECDF_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}