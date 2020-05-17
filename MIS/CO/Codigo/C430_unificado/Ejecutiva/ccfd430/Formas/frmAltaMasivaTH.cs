using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmAltaMasivaTH
		: System.Windows.Forms.Form
		{
		
			private void  frmAltaMasivaTH_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			string slArchivo = String.Empty;
			
			private void  cmdArchivo_Click( Object eventSender,  EventArgs eventArgs)
			{
					slArchivo = CRSGeneral.fncsAbrirArchivo(cdlDialogo, String.Empty, CRSGeneral.dlgDialogos.dlgAbrir);
					txtArchivo.Text = slArchivo;
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					//Obtiene las longitudes para el formateo de datos
					CRSDialogo.prLongitudes();
					//Cargar todos los registros a la forma
					prCargaRegAltasMas();
					//
					CRSGeneral.prAsignaScrollBar(scrScroll, picPicture, lstLista);
			}
			
			
			private void  prCargaRegAltasMas()
			{
					StringBuilder slRenglon = new StringBuilder();
					slRenglon.Append(String.Empty);
					try
					{
							
							lstLista.Items.Clear();
							//UPGRADE_WARNING: (2074) ListBox property lstLista.Columns was upgraded to lstLista.ColumnWidth which has a new behavior.
							lstLista.ColumnWidth = lstLista.ClientSize.Width / 5;
							
							CORVAR.pszgblsql = "select eje_prefijo";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_banco";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_num";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_num";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_roll_over";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_digit";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_nombre";
							
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_fecha_alta";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_usu_cam";
							
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", alt_status";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", alt_mensaje";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", alt_fecha_alta";
							
							CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCALT01";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_banco";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_num";
							CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_num";
							CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
									{
									
										//Cuenta
										slRenglon = new StringBuilder(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "0000"));
										slRenglon.Append(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)), "00"));
										slRenglon.Append(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)), new string('0', CRSDialogo.ifncLongitudEmpresa(Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))), Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)))))));
										slRenglon.Append(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)), new string('0', CRSDialogo.ifncLongitudEjecutivo(Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))), Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)))))));
										slRenglon.Append(StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 5), "0"));
										slRenglon.Append(StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 6), "0"));
										slRenglon.Append("\t");
										//Nombre
										slRenglon.Append(VBSQL.SqlData(CORVAR.hgblConexion, 7));
										slRenglon.Append("\t");
										//Status
										slRenglon.Append(VBSQL.SqlData(CORVAR.hgblConexion, 10));
										slRenglon.Append("\t");
										slRenglon.Append(VBSQL.SqlData(CORVAR.hgblConexion, 11));
										slRenglon.Append("\t");
										slRenglon.Append(VBSQL.SqlData(CORVAR.hgblConexion, 12));
										lstLista.Items.Add(slRenglon.ToString());
									}
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
                        catch (Exception e)
					{
						
						CRSGeneral.prObtenError("CargaRegAltasMas",e);
					}
					
			}
			
			//UPGRADE_WARNING: (2065) HScrollBar event scrScroll.Change has a new behavior.
			private void  scrScroll_Change( int newScrollValue)
			{
					CRSGeneral.prScrollBar(scrScroll, lstLista);
			}
			private void  frmAltaMasivaTH_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			private void  scrScroll_Scroll( Object eventSender,  ScrollEventArgs eventArgs)
			{
					switch(eventArgs.Type)
					{
						case ScrollEventType.EndScroll : 
							scrScroll_Change(eventArgs.NewValue); 
							break;
					}
			}
		}
}