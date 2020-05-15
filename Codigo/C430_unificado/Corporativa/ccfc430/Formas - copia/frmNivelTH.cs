using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using System; 
using System.Drawing; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmNivelTH
		: System.Windows.Forms.Form
		{
		
			private void  frmNivelTH_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  cmdConsultaTrans_Click( Object eventSender,  EventArgs eventArgs)
			{
					//Obtengo el numero de cuenta
					if (LsvTarjeta.ListItems.Count > 0)
					{
						object tempRefParam = 2;
						CCFmodGeneral.TH_SEL = LsvTarjeta.SelectedItem.ListSubItems.get_Item(ref tempRefParam).Text;
						object tempRefParam2 = 1;
						CCFmodGeneral.NUM_CUENTA = LsvTarjeta.SelectedItem.ListSubItems.get_Item(ref tempRefParam2).Text;
						if (CCFmodGeneral.NUM_CUENTA == "")
						{
							MessageBox.Show("Debe seleccionar un Tarjetahabiente.", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						} else
						{
							frmNivelTrans tempLoadForm = frmNivelTrans.DefInstance;
							//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
							frmNivelTrans.DefInstance.ShowDialog();
						}
					} else
					{
						MessageBox.Show("No existen Tarjetahabientes disponibles.", "TC C430", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
			}
			private void  cmdGeneraRepo_Click( Object eventSender,  EventArgs eventArgs)
			{
					CCFmodGeneral.ReportCCF(LsvTarjeta, CCFmodGeneral.NOMBRE_ARCHIVO, "DETALLE DE CUENTAS");
			}
			private void  cmdSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					this.Cursor = Cursors.WaitCursor;
					txtEmpresa.Text = CCFmodGeneral.EMPRESA_SEL;
					txtFechaProceso.Text = CCFmodGeneral.FECHA_PROCESO.Substring(CCFmodGeneral.FECHA_PROCESO.Length - Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 2)) + "/" + CCFmodGeneral.FECHA_PROCESO.Substring(0, Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 6)).Substring(CCFmodGeneral.FECHA_PROCESO.Substring(0, Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 6)).Length - Math.Min(CCFmodGeneral.FECHA_PROCESO.Substring(0, Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 6)).Length, 2)) + "/" + CCFmodGeneral.FECHA_PROCESO.Substring(0, Math.Min(CCFmodGeneral.FECHA_PROCESO.Length, 4));
					txtUnidad.Text = CCFmodGeneral.UNIDAD_SEL;
					//    If TIPO_PERIODO = 0 Then
					this.Text = this.Text + ".  CONSULTA DE TARJETAHABIENTES";
					LlenaLista();
					//            AddHeaderLst Me.LsvTarjeta, 6, gsTarjeta(), giTarjeta()
					//            pszgblsql = "exec sp_CCFConsulta 7, '" & NOMBRE_ARCHIVO & "', '" & EMPRESA_SEL & "', '" & Trim(UNIDAD_SEL) & "', null"
					//            LlenaLst LsvTarjeta, 6, pszgblsql
					//    End If
					this.Cursor = Cursors.Default;
			}
			
			
			private void  LlenaLista()
			{
					ADODB.Recordset rs = null;
					//Llenar header
					LsvTarjeta.GridLines = true;
					
					object tempRefParam = Type.Missing;
					object tempRefParam2 = Type.Missing;
					object tempRefParam3 = "Origen";
					object tempRefParam4 = Type.Missing;
					object tempRefParam5 = Type.Missing;
					object tempRefParam6 = Type.Missing;
					LsvTarjeta.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					object tempRefParam7 = LsvTarjeta.ColumnHeaders.Count;
                    //ais-1592 chidalgo
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam7).Width = 1;
					object tempRefParam8 = Type.Missing;
					object tempRefParam9 = Type.Missing;
					object tempRefParam10 = "Cuenta TH";
					object tempRefParam11 = Type.Missing;
					object tempRefParam12 = Type.Missing;
					object tempRefParam13 = Type.Missing;
					LsvTarjeta.ColumnHeaders.Add(ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12, ref tempRefParam13);
					object tempRefParam14 = LsvTarjeta.ColumnHeaders.Count;
                    //ais-1592 chidalgo
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam14).Width = 120;
					object tempRefParam15 = LsvTarjeta.ColumnHeaders.Count;
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam15).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
					object tempRefParam16 = Type.Missing;
					object tempRefParam17 = Type.Missing;
					object tempRefParam18 = "Nombre Tarjetahabiente";
					object tempRefParam19 = Type.Missing;
					object tempRefParam20 = Type.Missing;
					object tempRefParam21 = Type.Missing;
					LsvTarjeta.ColumnHeaders.Add(ref tempRefParam16, ref tempRefParam17, ref tempRefParam18, ref tempRefParam19, ref tempRefParam20, ref tempRefParam21);
					object tempRefParam22 = LsvTarjeta.ColumnHeaders.Count;
                    //ais-1592 chidalgo
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam22).Width = 240;
					object tempRefParam23 = LsvTarjeta.ColumnHeaders.Count;
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam23).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
					object tempRefParam24 = Type.Missing;
					object tempRefParam25 = Type.Missing;
					object tempRefParam26 = "Trans";
					object tempRefParam27 = Type.Missing;
					object tempRefParam28 = Type.Missing;
					object tempRefParam29 = Type.Missing;
					LsvTarjeta.ColumnHeaders.Add(ref tempRefParam24, ref tempRefParam25, ref tempRefParam26, ref tempRefParam27, ref tempRefParam28, ref tempRefParam29);
					object tempRefParam30 = LsvTarjeta.ColumnHeaders.Count;
                    //ais-1592 chidalgo
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam30).Width = 50;
					object tempRefParam31 = LsvTarjeta.ColumnHeaders.Count;
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam31).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					object tempRefParam32 = Type.Missing;
					object tempRefParam33 = Type.Missing;
					object tempRefParam34 = "Saldo Anterior";
					object tempRefParam35 = Type.Missing;
					object tempRefParam36 = Type.Missing;
					object tempRefParam37 = Type.Missing;
					LsvTarjeta.ColumnHeaders.Add(ref tempRefParam32, ref tempRefParam33, ref tempRefParam34, ref tempRefParam35, ref tempRefParam36, ref tempRefParam37);
					object tempRefParam38 = LsvTarjeta.ColumnHeaders.Count;
                    //ais-1592 chidalgo
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam38).Width = 80;
					object tempRefParam39 = LsvTarjeta.ColumnHeaders.Count;
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam39).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnRight;
					object tempRefParam40 = Type.Missing;
					object tempRefParam41 = Type.Missing;
					object tempRefParam42 = "Saldo Actual";
					object tempRefParam43 = Type.Missing;
					object tempRefParam44 = Type.Missing;
					object tempRefParam45 = Type.Missing;
					LsvTarjeta.ColumnHeaders.Add(ref tempRefParam40, ref tempRefParam41, ref tempRefParam42, ref tempRefParam43, ref tempRefParam44, ref tempRefParam45);
					object tempRefParam46 = LsvTarjeta.ColumnHeaders.Count;
                    //ais-1592 chidalgo
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam46).Width = 80;
					object tempRefParam47 = LsvTarjeta.ColumnHeaders.Count;
					LsvTarjeta.ColumnHeaders.get_Item(ref tempRefParam47).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnRight;
					
					
					
					if (VBSQL.OpenConn(11) == 0)
					{ // se Conecto a la base
						object tempRefParam48 = ADODB.AffectEnum.adAffectAllChapters;
						rs = VBSQL.gConn[11].Execute("exec sp_CCFConsulta 7, '" + CCFmodGeneral.NOMBRE_ARCHIVO + "', '" + CCFmodGeneral.EMPRESA_SEL.Substring(0, Math.Min(CCFmodGeneral.EMPRESA_SEL.Length, 6)) + "', '" + CCFmodGeneral.UNIDAD_SEL.Trim() + "', null", out tempRefParam48, -1);
						
						if (! (rs.BOF && rs.EOF))
						{
							rs.MoveFirst();
							LsvTarjeta.ListItems.Clear();
							LsvTarjeta.Sorted = false;
							
							
							while(! rs.EOF)
							{
								object tempRefParam49 = Type.Missing;
								object tempRefParam50 = "k" + Convert.ToString(rs.Fields["account_number"].Value);
								object tempRefParam51 = rs.Fields["origen"];
								object tempRefParam52 = Type.Missing;
								object tempRefParam53 = Type.Missing;
								LsvTarjeta.ListItems.Add(ref tempRefParam49, ref tempRefParam50, ref tempRefParam51, ref tempRefParam52, ref tempRefParam53);
								object tempRefParam54 = LsvTarjeta.ListItems.Count;
								LsvTarjeta.ListItems.get_Item(ref tempRefParam54).set_SubItems(1, Convert.ToString(rs.Fields["account_number"].Value));
								object tempRefParam55 = LsvTarjeta.ListItems.Count;
								LsvTarjeta.ListItems.get_Item(ref tempRefParam55).set_SubItems(2, Convert.ToString(rs.Fields["eje_nom"].Value));
								object tempRefParam56 = LsvTarjeta.ListItems.Count;
								LsvTarjeta.ListItems.get_Item(ref tempRefParam56).set_SubItems(3, Convert.ToString(rs.Fields["num_trans"].Value));
								object tempRefParam57 = LsvTarjeta.ListItems.Count;
								LsvTarjeta.ListItems.get_Item(ref tempRefParam57).set_SubItems(4, Convert.ToString(rs.Fields["saldo_anterior"].Value));
								object tempRefParam58 = LsvTarjeta.ListItems.Count;
								LsvTarjeta.ListItems.get_Item(ref tempRefParam58).set_SubItems(5, Convert.ToString(rs.Fields["saldo_actual"].Value));
								object tempRefParam59 = LsvTarjeta.ListItems.Count;
								LsvTarjeta.ListItems.get_Item(ref tempRefParam59).set_SubItems(4, StringsHelper.Format(rs.Fields["saldo_anterior"].Value, CRSParametros.cteMascaraDinero));
								object tempRefParam60 = LsvTarjeta.ListItems.Count;
								LsvTarjeta.ListItems.get_Item(ref tempRefParam60).set_SubItems(5, StringsHelper.Format(rs.Fields["saldo_actual"].Value, CRSParametros.cteMascaraDinero));
								
								if (Convert.ToDouble(rs.Fields["num_trans"].Value) > 0)
								{
									object tempRefParam61 = LsvTarjeta.ListItems.Count;
									LsvTarjeta.ListItems.get_Item(ref tempRefParam61).Bold = true;
									object tempRefParam62 = LsvTarjeta.ListItems.Count;
                                    //AIS-380 NGONZALEZ
                                    LsvTarjeta.ListItems.get_Item(ref tempRefParam62).ForeColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Blue));
									
									
									object tempRefParam63 = LsvTarjeta.ListItems.Count;
									for (int i = 1; i <= LsvTarjeta.ListItems.get_Item(ref tempRefParam63).ListSubItems.Count; i++)
									{
										object tempRefParam64 = i;
										object tempRefParam65 = LsvTarjeta.ListItems.Count;
										LsvTarjeta.ListItems.get_Item(ref tempRefParam65).ListSubItems.get_ControlDefault(ref tempRefParam64).Bold = true;
										object tempRefParam66 = i;
										object tempRefParam67 = LsvTarjeta.ListItems.Count;
										//AIS-380 NGONZALEZ
										LsvTarjeta.ListItems.get_Item(ref tempRefParam67).ListSubItems.get_ControlDefault(ref tempRefParam66).ForeColor = Convert.ToUInt32(ColorTranslator.ToOle(Color.Blue));
										
									}
								} else
								{
									object tempRefParam68 = LsvTarjeta.ListItems.Count;
									//AIS-380 NGONZALEZ
                                    //ais-1591
                                    LsvTarjeta.ListItems.get_Item(ref tempRefParam68).ForeColor = 0x80000012;
									
									object tempRefParam69 = LsvTarjeta.ListItems.Count;
									for (int i = 1; i <= LsvTarjeta.ListItems.get_Item(ref tempRefParam69).ListSubItems.Count; i++)
									{
										object tempRefParam70 = i;
										object tempRefParam71 = LsvTarjeta.ListItems.Count;
										//AIS-380 NGONZALEZ
                                        //ais-1591
                                        LsvTarjeta.ListItems.get_Item(ref tempRefParam71).ListSubItems.get_ControlDefault(ref tempRefParam70).ForeColor = 0x80000012;
									}
								}
								
								
								
								rs.MoveNext();
								
							};
						} else
						{
							MessageBox.Show("No Existen Tarjetahabientes para esta unidad que Selecciono", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						
						rs.Close();
						rs = null;
						VBSQL.gConn[11].Close();
						
						
					} else
					{
						
						MessageBox.Show("Existio un error al cargar los datos" + "\r" + "Favor de Verificar con el Administrador del Sistema", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Error);
						
					}
					
			}
			
			
			
			
			
			private void  LsvTarjeta_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					cmdConsultaTrans_Click(cmdConsultaTrans, new EventArgs());
			}
			private void  frmNivelTH_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}