using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmNivelEmpresa
		: System.Windows.Forms.Form
		{
		
			private void  frmNivelEmpresa_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  LlenaLista()
			{
					ADODB.Recordset rs = null;
					int i = 0;
					
					//Llenar header
					LsvEmpresa.GridLines = true;
					
					object tempRefParam = Type.Missing;
					object tempRefParam2 = Type.Missing;
					object tempRefParam3 = "Origen";
					object tempRefParam4 = Type.Missing;
					object tempRefParam5 = Type.Missing;
					object tempRefParam6 = Type.Missing;
					LsvEmpresa.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					object tempRefParam7 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam7).Width = (float) VB6.TwipsToPixelsX( 45 * VB6.TwipsPerPixelX());
					object tempRefParam8 = Type.Missing;
					object tempRefParam9 = Type.Missing;
					object tempRefParam10 = "Empresa";
					object tempRefParam11 = Type.Missing;
					object tempRefParam12 = Type.Missing;
					object tempRefParam13 = Type.Missing;
					LsvEmpresa.ColumnHeaders.Add(ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12, ref tempRefParam13);
					object tempRefParam14 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam14).Width = (float) VB6.TwipsToPixelsX(300 * VB6.TwipsPerPixelX());
					object tempRefParam15 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam15).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					object tempRefParam16 = Type.Missing;
					object tempRefParam17 = Type.Missing;
					object tempRefParam18 = "Tarjetahabientes";
					object tempRefParam19 = Type.Missing;
					object tempRefParam20 = Type.Missing;
					object tempRefParam21 = Type.Missing;
					LsvEmpresa.ColumnHeaders.Add(ref tempRefParam16, ref tempRefParam17, ref tempRefParam18, ref tempRefParam19, ref tempRefParam20, ref tempRefParam21);
					object tempRefParam22 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam22).Width = (float) VB6.TwipsToPixelsX(100 * VB6.TwipsPerPixelX());
					object tempRefParam23 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam23).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					object tempRefParam24 = Type.Missing;
					object tempRefParam25 = Type.Missing;
					object tempRefParam26 = "Tipo Fact.";
					object tempRefParam27 = Type.Missing;
					object tempRefParam28 = Type.Missing;
					object tempRefParam29 = Type.Missing;
					LsvEmpresa.ColumnHeaders.Add(ref tempRefParam24, ref tempRefParam25, ref tempRefParam26, ref tempRefParam27, ref tempRefParam28, ref tempRefParam29);
					object tempRefParam30 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam30).Width = (float) VB6.TwipsToPixelsX( 80 * VB6.TwipsPerPixelX());
					object tempRefParam31 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam31).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					object tempRefParam32 = Type.Missing;
					object tempRefParam33 = Type.Missing;
					object tempRefParam34 = "Unidades";
					object tempRefParam35 = Type.Missing;
					object tempRefParam36 = Type.Missing;
					object tempRefParam37 = Type.Missing;
					LsvEmpresa.ColumnHeaders.Add(ref tempRefParam32, ref tempRefParam33, ref tempRefParam34, ref tempRefParam35, ref tempRefParam36, ref tempRefParam37);
					object tempRefParam38 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam38).Width = (float) VB6.TwipsToPixelsX( 70 * VB6.TwipsPerPixelX());
					object tempRefParam39 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam39).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					object tempRefParam40 = Type.Missing;
					object tempRefParam41 = Type.Missing;
					object tempRefParam42 = "Transacciones";
					object tempRefParam43 = Type.Missing;
					object tempRefParam44 = Type.Missing;
					object tempRefParam45 = Type.Missing;
					LsvEmpresa.ColumnHeaders.Add(ref tempRefParam40, ref tempRefParam41, ref tempRefParam42, ref tempRefParam43, ref tempRefParam44, ref tempRefParam45);
					object tempRefParam46 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam46).Width = (float) VB6.TwipsToPixelsX( 100 * VB6.TwipsPerPixelX());
					object tempRefParam47 = LsvEmpresa.ColumnHeaders.Count;
					LsvEmpresa.ColumnHeaders.get_Item(ref tempRefParam47).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					
					
					if (VBSQL.OpenConn(11) == 0)
					{ // se Conecto a la base
						object tempRefParam48 = ADODB.AffectEnum.adAffectAllChapters;
						rs = VBSQL.gConn[11].Execute("exec sp_CCFConsulta 2, '" + CCFmodGeneral.NOMBRE_ARCHIVO + "', null, null, null", out tempRefParam48, -1);
						
						if (! (rs.BOF && rs.EOF))
						{
							rs.MoveFirst();
							LsvEmpresa.ListItems.Clear();
							LsvEmpresa.Sorted = false;
							
							
							while(! rs.EOF)
							{
								object tempRefParam49 = Type.Missing;
								object tempRefParam50 = rs.Fields["emp_num"];
								object tempRefParam51 = rs.Fields["origen"];
								object tempRefParam52 = Type.Missing;
								object tempRefParam53 = Type.Missing;
								LsvEmpresa.ListItems.Add(ref tempRefParam49, ref tempRefParam50, ref tempRefParam51, ref tempRefParam52, ref tempRefParam53);
								object tempRefParam54 = LsvEmpresa.ListItems.Count;
								LsvEmpresa.ListItems.get_Item(ref tempRefParam54).set_SubItems(1, Convert.ToString(rs.Fields["emp_num"].Value));
								object tempRefParam55 = LsvEmpresa.ListItems.Count;
								LsvEmpresa.ListItems.get_Item(ref tempRefParam55).set_SubItems(2, Convert.ToString(rs.Fields["num_th"].Value));
								object tempRefParam56 = LsvEmpresa.ListItems.Count;
								LsvEmpresa.ListItems.get_Item(ref tempRefParam56).set_SubItems(3, Convert.ToString(rs.Fields["tipo_fac"].Value));
								object tempRefParam57 = LsvEmpresa.ListItems.Count;
								LsvEmpresa.ListItems.get_Item(ref tempRefParam57).set_SubItems(4, Convert.ToString(rs.Fields["num_unidades"].Value));
								object tempRefParam58 = LsvEmpresa.ListItems.Count;
								LsvEmpresa.ListItems.get_Item(ref tempRefParam58).set_SubItems(5, Convert.ToString(rs.Fields["num_trans"].Value));
								rs.MoveNext();
							};
						} else
						{
							MessageBox.Show("No Existen Empresas con transacciones para el archivo Solicitado" + "\r" + "Favor de Verificar", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						
						rs.Close();
						rs = null;
						object tempRefParam59 = ADODB.AffectEnum.adAffectAllChapters;
						rs = VBSQL.gConn[11].Execute("exec sp_CCFConsulta 3, '" + CCFmodGeneral.NOMBRE_ARCHIVO + "', null, null, null", out tempRefParam59, -1);
						if (! (rs.BOF && rs.EOF))
						{
							rs.MoveFirst();
							txtFechaInicial.Text = StringsHelper.Format(rs.Fields["fecha_ini"].Value, CRSParametros.cteFormatoFecha);
							txtFechaFinal.Text = StringsHelper.Format(rs.Fields["fecha_fin"].Value, CRSParametros.cteFormatoFecha);
							rs.Close();
							
						} else
						{
							MessageBox.Show("Error al cargar las Fechas del Proceso solictado para el CCF", "Reporte del CCF", MessageBoxButtons.OK, MessageBoxIcon.Error);
							this.Close();
							
						}
						
						
						rs = null;
						VBSQL.gConn[11].Close();
						
						
					} else
					{
						MessageBox.Show("Existio un error al cargar los datos" + "\r" + "Favor de Verificar con el Administrador del Sistema", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					
			}
			
			
			private void  cmdError_Click( Object eventSender,  EventArgs eventArgs)
			{
					DialogResult respuesta = MessageBox.Show("¿Confirma que desea Rechazar el archivo CCF?", "TC C430", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (respuesta == System.Windows.Forms.DialogResult.Yes)
					{
						CORVAR.pszgblsql = "exec sp_CCFConsulta 6, '" + CCFmodGeneral.NOMBRE_ARCHIVO + "', null, null, null";
						if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
						{
							MessageBox.Show("No se modificó el status del archivo debido a un error en la Base de Datos", "Error CCF", MessageBoxButtons.OK, MessageBoxIcon.Error);
						} else
						{
							MessageBox.Show("Ha sido rechazado el Archivo CCF", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
							cmdVistoBueno.Enabled = false;
							cmdError.Enabled = false;
						}
					}
			}
			private void  cmdGeneraRepo_Click( Object eventSender,  EventArgs eventArgs)
			{
					CCFmodGeneral.ReportCCF(LsvEmpresa, CCFmodGeneral.NOMBRE_ARCHIVO, "DETALLE DE EMPRESAS");
			}
			private void  cmdSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
					//Call frmArchivosPendientes.Carga_lsv
			}
			
			private void  cmdUnidad_Click( Object eventSender,  EventArgs eventArgs)
			{
					//Checo qué renglón esta seleccionado
					if (LsvEmpresa.ListItems.Count > 0)
					{
						//EMPRESA_SEL = Left(LsvEmpresa.SelectedItem.ListSubItems.Item(1).Text, 6)
						object tempRefParam = 1;
						CCFmodGeneral.EMPRESA_SEL = LsvEmpresa.SelectedItem.ListSubItems.get_Item(ref tempRefParam).Text;
						if (CCFmodGeneral.EMPRESA_SEL == "")
						{
							MessageBox.Show("Debe elegir una empresa", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
						} else
						{
							//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
							frmNivelUnidad.DefInstance.ShowDialog();
						}
					} else
					{
						MessageBox.Show("No existen Empresas disponibles.", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
			}
			
			private void  cmdVistoBueno_Click( Object eventSender,  EventArgs eventArgs)
			{
					DialogResult respuesta = MessageBox.Show("¿Confirma que desea validar el archivo CCF?", "TC C430", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (respuesta == System.Windows.Forms.DialogResult.Yes)
					{
						CORVAR.pszgblsql = "exec sp_CCFConsulta 5, '" + CCFmodGeneral.NOMBRE_ARCHIVO + "', null, null, null";
						if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
						{
							MessageBox.Show("No se modificó el status del archivo debido a un error en la Base de Datos", "Error CCF", MessageBoxButtons.OK, MessageBoxIcon.Error);
						} else
						{
							MessageBox.Show("Ha sido validado el Archivo CCF", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
							cmdVistoBueno.Enabled = false;
							cmdError.Enabled = false;
						}
					}
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					int ilcont = 0;
					this.Cursor = Cursors.WaitCursor;
					txtNombreArchivo.Text = CCFmodGeneral.NOMBRE_ARCHIVO;
					//If TIPO_PERIODO = 0 Then
					//    Me.Caption = Me.Caption & ".  PROCESO DIARIO"
					
					LlenaLista();
					
					
					//    AddHeaderLst Me.LsvEmpresa, 8, gsEmpresa(), giEmpresa()
					//    pszgblsql = "exec sp_CCFConsulta 2, '" & NOMBRE_ARCHIVO & "', null, null, null"
					//    LlenaLst Me.LsvEmpresa, 8, pszgblsql
					//    pszgblsql = "exec sp_CCFConsulta 3, '" & NOMBRE_ARCHIVO & "', null, null, null"
					//    ilcont = 0
					//    If ObtieneRegistros(pszgblsql) Then
					//        Do Until SqlNextRow(hgblConexion) = NOMOREROWS
					//            txtFechaInicial.Text = SqlData(hgblConexion, 1)
					//            txtFechaFinal.Text = SqlData(hgblConexion, 2)
					//            If SqlData(hgblConexion, 2) = vbNullString Then
					//                ilcont = 1
					//                MsgBox "No hay Empresas Con TRansacciones", vbInformation
					//            End If
					//        Loop
					//    End If
					//    igblRetorna = SqlCancel(hgblConexion)
					//End If
					if (CCFmodGeneral.ESTATUS_ARCHIVO == "Pendiente" && ilcont == 0)
					{
						cmdError.Enabled = true;
						cmdVistoBueno.Enabled = true;
					} else if (CCFmodGeneral.ESTATUS_ARCHIVO == "Pendiente" && ilcont == 1) { 
						cmdError.Enabled = true;
						cmdVistoBueno.Enabled = false;
						cmdGeneraRepo.Enabled = false;
						cmdUnidad.Enabled = false;
					} else
					{
						cmdVistoBueno.Enabled = false;
						cmdError.Enabled = false;
					}
					this.Cursor = Cursors.Default;
			}
			private void  LsvEmpresa_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					cmdUnidad_Click(cmdUnidad, new EventArgs());
			}
			private void  frmNivelEmpresa_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}