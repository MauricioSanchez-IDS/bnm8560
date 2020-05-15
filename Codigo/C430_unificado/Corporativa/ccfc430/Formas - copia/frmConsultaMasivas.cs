using Artinsoft.VB6.Gui; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmConsultaMasivas
		: System.Windows.Forms.Form
		{
		
			private void  frmConsultaMasivas_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  cmdSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					int llRegistros = 0;
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							CORVAR.pszgblsql = "select eje_prefijo, gpo_banco, emp_num, eje_nombre, eje_rfc ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCMSV01";
							
							llRegistros = CORPROC2.Cuenta_Registros();
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
							if (llRegistros > 0)
							{
								sprConsAltasMasivas.VisibleRows = llRegistros;
								sprConsAltasMasivas.MaxRows = llRegistros;
							} else
							{
								return;
							}
							
							if (CORPROC2.Obtiene_Registros() == (-1))
							{
								for (int llRow = 1; llRow <= llRegistros; llRow++)
								{
									if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS)
									{
										break;
									}
									sprConsAltasMasivas.Row = llRow;
									for (int llCol = 1; llCol <= 5; llCol++)
									{
										sprConsAltasMasivas.Col = llCol;
										sprConsAltasMasivas.Text = VBSQL.SqlData(CORVAR.hgblConexion, llCol);
									}
									
								}
							}
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
							this.Cursor = Cursors.Default;
						}
                        catch (Exception e)
					{
						
						
						CRSGeneral.prObtenError(this.GetType().Name + "(Consulta Altas Masivas)",e ); // Termino con Error el Proceso de Consultar Informacion
					}
					
					
			}
			private void  frmConsultaMasivas_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}