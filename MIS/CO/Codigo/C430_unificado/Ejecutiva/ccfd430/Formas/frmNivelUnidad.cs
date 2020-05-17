using Artinsoft.VB6.Gui; 
using System; 
using System.Drawing; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmNivelUnidad
		: System.Windows.Forms.Form
		{
		
			private void  frmNivelUnidad_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  cmdConsultaTH_Click( Object eventSender,  EventArgs eventArgs)
			{
					//Checo qué renglón esta seleccionado
					if (LsvUnidades.ListItems.Count > 0)
					{
						object tempRefParam = 1;
						CCFmodGeneral.UNIDAD_SEL = LsvUnidades.SelectedItem.ListSubItems.get_Item(ref tempRefParam).Text.Trim();
						if (CCFmodGeneral.UNIDAD_SEL == "")
						{
							MessageBox.Show("Debe seleccionar una Unidad.", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
						} else
						{
							//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
							frmNivelTH.DefInstance.ShowDialog();
						}
					} else
					{
						MessageBox.Show("No existen Unidades disponibles.", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
			}
			private void  cmdGeneraRepo_Click( Object eventSender,  EventArgs eventArgs)
			{
					CCFmodGeneral.ReportCCF(LsvUnidades, CCFmodGeneral.NOMBRE_ARCHIVO, "DETALLE DE UNIDADES");
			}
			private void  cmdSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			private void  LlenaLista()
			{
					ADODB.Recordset rs = null;
					//Llenar header
					LsvUnidades.GridLines = true;
					
					object tempRefParam = Type.Missing;
					object tempRefParam2 = Type.Missing;
					object tempRefParam3 = "Origen";
					object tempRefParam4 = Type.Missing;
					object tempRefParam5 = Type.Missing;
					object tempRefParam6 = Type.Missing;
					LsvUnidades.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					object tempRefParam7 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam7).Width = (float) VB6.TwipsToPixelsX(45 * VB6.TwipsPerPixelX());
					object tempRefParam8 = Type.Missing;
					object tempRefParam9 = Type.Missing;
					object tempRefParam10 = "Unidad";
					object tempRefParam11 = Type.Missing;
					object tempRefParam12 = Type.Missing;
					object tempRefParam13 = Type.Missing;
					LsvUnidades.ColumnHeaders.Add(ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12, ref tempRefParam13);
					object tempRefParam14 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam14).Width =  (float) VB6.TwipsToPixelsX( 70 * VB6.TwipsPerPixelX());
					object tempRefParam15 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam15).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
					object tempRefParam16 = Type.Missing;
					object tempRefParam17 = Type.Missing;
					object tempRefParam18 = "Nombre";
					object tempRefParam19 = Type.Missing;
					object tempRefParam20 = Type.Missing;
					object tempRefParam21 = Type.Missing;
					LsvUnidades.ColumnHeaders.Add(ref tempRefParam16, ref tempRefParam17, ref tempRefParam18, ref tempRefParam19, ref tempRefParam20, ref tempRefParam21);
					object tempRefParam22 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam22).Width = (float) VB6.TwipsToPixelsX( 300 * VB6.TwipsPerPixelX());
					object tempRefParam23 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam23).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
					object tempRefParam24 = Type.Missing;
					object tempRefParam25 = Type.Missing;
					object tempRefParam26 = "Tarjetahabientes";
					object tempRefParam27 = Type.Missing;
					object tempRefParam28 = Type.Missing;
					object tempRefParam29 = Type.Missing;
					LsvUnidades.ColumnHeaders.Add(ref tempRefParam24, ref tempRefParam25, ref tempRefParam26, ref tempRefParam27, ref tempRefParam28, ref tempRefParam29);
					object tempRefParam30 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam30).Width = (float) VB6.TwipsToPixelsX(100 * VB6.TwipsPerPixelX());
					object tempRefParam31 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam31).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					object tempRefParam32 = Type.Missing;
					object tempRefParam33 = Type.Missing;
					object tempRefParam34 = "Transacciones";
					object tempRefParam35 = Type.Missing;
					object tempRefParam36 = Type.Missing;
					object tempRefParam37 = Type.Missing;
					LsvUnidades.ColumnHeaders.Add(ref tempRefParam32, ref tempRefParam33, ref tempRefParam34, ref tempRefParam35, ref tempRefParam36, ref tempRefParam37);
					object tempRefParam38 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam38).Width =  (float) VB6.TwipsToPixelsX(100 * VB6.TwipsPerPixelX());
					object tempRefParam39 = LsvUnidades.ColumnHeaders.Count;
					LsvUnidades.ColumnHeaders.get_Item(ref tempRefParam39).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					
					
					if (VBSQL.OpenConn(11) == 0)
					{ // se Conecto a la base
						object tempRefParam40 = ADODB.AffectEnum.adAffectAllChapters;
						rs = VBSQL.gConn[11].Execute("exec sp_CCFConsulta 4, '" + CCFmodGeneral.NOMBRE_ARCHIVO + "', '" + CCFmodGeneral.EMPRESA_SEL.Substring(0, Math.Min(CCFmodGeneral.EMPRESA_SEL.Length, 6)) + "', null, null", out tempRefParam40, -1);
						
						if (! (rs.BOF && rs.EOF))
						{
							rs.MoveFirst();
							LsvUnidades.ListItems.Clear();
							LsvUnidades.Sorted = false;
							
							
							while(! rs.EOF)
							{
								object tempRefParam41 = Type.Missing;
								object tempRefParam42 = "k" + Convert.ToString(rs.Fields["unit_id"].Value);
								object tempRefParam43 = rs.Fields["origen"];
								object tempRefParam44 = Type.Missing;
								object tempRefParam45 = Type.Missing;
								LsvUnidades.ListItems.Add(ref tempRefParam41, ref tempRefParam42, ref tempRefParam43, ref tempRefParam44, ref tempRefParam45);
								object tempRefParam46 = LsvUnidades.ListItems.Count;
								LsvUnidades.ListItems.get_Item(ref tempRefParam46).set_SubItems(1, Convert.ToString(rs.Fields["unit_id"].Value));
								object tempRefParam47 = LsvUnidades.ListItems.Count;
								LsvUnidades.ListItems.get_Item(ref tempRefParam47).set_SubItems(2, Convert.ToString(rs.Fields["unit_name"].Value));
								object tempRefParam48 = LsvUnidades.ListItems.Count;
								LsvUnidades.ListItems.get_Item(ref tempRefParam48).set_SubItems(3, Convert.ToString(rs.Fields["num_th"].Value));
								object tempRefParam49 = LsvUnidades.ListItems.Count;
								LsvUnidades.ListItems.get_Item(ref tempRefParam49).set_SubItems(4, Convert.ToString(rs.Fields["num_trans"].Value));
								
								// Cambia Color a Unidades Con Transaccion
								if (Convert.ToDouble(rs.Fields["num_trans"].Value) >= 1)
								{
									object tempRefParam50 = LsvUnidades.ListItems.Count;
									LsvUnidades.ListItems.get_Item(ref tempRefParam50).Bold = true;
									object tempRefParam51 = LsvUnidades.ListItems.Count;
                                    //AIS-380 NGONZALEZ
									LsvUnidades.ListItems.get_Item(ref tempRefParam51).ForeColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Blue));
									
									object tempRefParam52 = LsvUnidades.ListItems.Count;
									for (int i = 1; i <= LsvUnidades.ListItems.get_Item(ref tempRefParam52).ListSubItems.Count; i++)
									{
										object tempRefParam53 = i;
										
										object tempRefParam54 = LsvUnidades.ListItems.Count;

										LsvUnidades.ListItems.get_Item(ref tempRefParam54).ListSubItems.get_ControlDefault(ref tempRefParam53).Bold = true;
										object tempRefParam55 = i;
										object tempRefParam56 = LsvUnidades.ListItems.Count;
										//AIS-380 NGONZALEZ
										LsvUnidades.ListItems.get_Item(ref tempRefParam56).ListSubItems.get_ControlDefault(ref tempRefParam55).ForeColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Blue));										
									}
								} else
								{

									object tempRefParam57 = LsvUnidades.ListItems.Count;
									//AIS-380 NGONZALEZ
                                    //ais-1591 chidalgo
                                    LsvUnidades.ListItems.get_Item(ref tempRefParam57).ForeColor = 0x80000012;
									
									object tempRefParam58 = LsvUnidades.ListItems.Count;
									for (int i = 1; i <= LsvUnidades.ListItems.get_Item(ref tempRefParam58).ListSubItems.Count; i++)
									{
										object tempRefParam59 = i;
										object tempRefParam60 = LsvUnidades.ListItems.Count;
										//AIS-380 NGONZALEZ
                                        //ais-1591 chidalgo
                                        LsvUnidades.ListItems.get_Item(ref tempRefParam60).ListSubItems.get_ControlDefault(ref tempRefParam59).ForeColor = 0x80000012;
									}
								}
								
								rs.MoveNext();
								
								
								
							};
						} else
						{
							MessageBox.Show("No Exsten Unidades para la Empresa seleccionada", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						
						rs.Close();
						rs = null;
						VBSQL.gConn[11].Close();
						
						
					} else
					{
						MessageBox.Show("Existio un error al cargar los datos" + "\r" + "Favor de Verificar con el Administrador del Sistema", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					
			}
			
			
			
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					this.Cursor = Cursors.WaitCursor;
					txtEmpresa.Text = CCFmodGeneral.EMPRESA_SEL;
					txtFechaProceso.Text = CCFmodGeneral.FECHA_PROCESO.Substring(CCFmodGeneral.FECHA_PROCESO.Length - Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 2)) + "/" + CCFmodGeneral.FECHA_PROCESO.Substring(0, Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 6)).Substring(CCFmodGeneral.FECHA_PROCESO.Substring(0, Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 6)).Length - Math.Min(CCFmodGeneral.FECHA_PROCESO.Substring(0, Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 6)).Length, 2)) + "/" + CCFmodGeneral.FECHA_PROCESO.Substring(0, Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 4));
					//    If TIPO_PERIODO = 0 Then
					this.Text = this.Text + ".  CONSULTA DE UNIDADES";
					txtFechaFinal.Text = frmNivelEmpresa.DefInstance.txtFechaFinal.Text;
					txtFechaInicial.Text = frmNivelEmpresa.DefInstance.txtFechaInicial.Text;
					LlenaLista();
					//       AddHeaderLst Me.LsvUnidades, 8, gsUnidad(), giUnidad()
					//       pszgblsql = "exec sp_CCFConsulta 4, '" & NOMBRE_ARCHIVO & "', '" & EMPRESA_SEL & "', null, null"
					//       LlenaLst LsvUnidades, 8, pszgblsql
					//    End If
					this.Cursor = Cursors.Default;
			}
			
			private void  LsvUnidades_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					cmdConsultaTH_Click(cmdConsultaTH, new EventArgs());
			}
			private void  frmNivelUnidad_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}