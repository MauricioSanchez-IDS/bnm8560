using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmNivelTrans
		: System.Windows.Forms.Form
		{
		
			private void  frmNivelTrans_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			private void  cmdGeneraRepo_Click( Object eventSender,  EventArgs eventArgs)
			{
					CCFmodGeneral.ReportCCF(LsvTran, CCFmodGeneral.NOMBRE_ARCHIVO, "DETALLE DE TRANSACCIONES");
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
					txtUnidad.Text = CCFmodGeneral.UNIDAD_SEL;
					txtNumCuenta.Text = CCFmodGeneral.NUM_CUENTA;
					txtTH.Text = CCFmodGeneral.TH_SEL;
					//    If TIPO_PERIODO = 0 Then
					this.Text = this.Text + ".  CONSULTA DE TRANSACCIONES";
					LlenaLista();
					//            AddHeaderLst Me.LsvTran, 6, gsTransac(), giTransac()
					//            pszgblsql = "exec sp_CCFConsulta 8, '" & NOMBRE_ARCHIVO & "', '" & Left(EMPRESA_SEL, 6) & "',null,  '" & Trim(NUM_CUENTA) & "'"
					//            LlenaLst LsvTran, 6, pszgblsql
					//    End If
					this.Cursor = Cursors.Default;
			}
			
			
			
			private void  LlenaLista()
			{
					ADODB.Recordset rs = null;
					
					int con = 1;
					//Llenar header
					
					LsvTran.GridLines = true;
					
					object tempRefParam = Type.Missing;
					object tempRefParam2 = Type.Missing;
					object tempRefParam3 = "Origen";
					object tempRefParam4 = Type.Missing;
					object tempRefParam5 = Type.Missing;
					object tempRefParam6 = Type.Missing;
					LsvTran.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					object tempRefParam7 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam7).Width = 1;
					object tempRefParam8 = Type.Missing;
					object tempRefParam9 = Type.Missing;
					object tempRefParam10 = "Fecha Trans.";
					object tempRefParam11 = Type.Missing;
					object tempRefParam12 = Type.Missing;
					object tempRefParam13 = Type.Missing;
					LsvTran.ColumnHeaders.Add(ref tempRefParam8, ref tempRefParam9, ref tempRefParam10, ref tempRefParam11, ref tempRefParam12, ref tempRefParam13);
					object tempRefParam14 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam14).Width = 90 ;
					object tempRefParam15 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam15).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
					object tempRefParam16 = Type.Missing;
					object tempRefParam17 = Type.Missing;
					object tempRefParam18 = "Fecha Proceso";
					object tempRefParam19 = Type.Missing;
					object tempRefParam20 = Type.Missing;
					object tempRefParam21 = Type.Missing;
					LsvTran.ColumnHeaders.Add(ref tempRefParam16, ref tempRefParam17, ref tempRefParam18, ref tempRefParam19, ref tempRefParam20, ref tempRefParam21);
					object tempRefParam22 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam22).Width = 90;
					object tempRefParam23 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam23).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
					object tempRefParam24 = Type.Missing;
					object tempRefParam25 = Type.Missing;
					object tempRefParam26 = "Transaccion Id";
					object tempRefParam27 = Type.Missing;
					object tempRefParam28 = Type.Missing;
					object tempRefParam29 = Type.Missing;
					LsvTran.ColumnHeaders.Add(ref tempRefParam24, ref tempRefParam25, ref tempRefParam26, ref tempRefParam27, ref tempRefParam28, ref tempRefParam29);
					object tempRefParam30 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam30).Width = 65;
					object tempRefParam31 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam31).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnCenter;
					object tempRefParam32 = Type.Missing;
					object tempRefParam33 = Type.Missing;
					object tempRefParam34 = "descripcion";
					object tempRefParam35 = Type.Missing;
					object tempRefParam36 = Type.Missing;
					object tempRefParam37 = Type.Missing;
					LsvTran.ColumnHeaders.Add(ref tempRefParam32, ref tempRefParam33, ref tempRefParam34, ref tempRefParam35, ref tempRefParam36, ref tempRefParam37);
					object tempRefParam38 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam38).Width = 300;
					object tempRefParam39 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam39).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
					object tempRefParam40 = Type.Missing;
					object tempRefParam41 = Type.Missing;
					object tempRefParam42 = "Monto";
					object tempRefParam43 = Type.Missing;
					object tempRefParam44 = Type.Missing;
					object tempRefParam45 = Type.Missing;
					LsvTran.ColumnHeaders.Add(ref tempRefParam40, ref tempRefParam41, ref tempRefParam42, ref tempRefParam43, ref tempRefParam44, ref tempRefParam45);
					object tempRefParam46 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam46).Width = 80;
					object tempRefParam47 = LsvTran.ColumnHeaders.Count;
					LsvTran.ColumnHeaders.get_Item(ref tempRefParam47).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnRight;
					
					
					
					if (VBSQL.OpenConn(11) == 0)
					{ // se Conecto a la base
						object tempRefParam48 = ADODB.AffectEnum.adAffectAllChapters;
						rs = VBSQL.gConn[11].Execute("exec sp_CCFConsulta 8, '" + CCFmodGeneral.NOMBRE_ARCHIVO + "', '" + CCFmodGeneral.EMPRESA_SEL.Substring(0, Math.Min(CCFmodGeneral.EMPRESA_SEL.Length, 6)) + "',null,  '" + CCFmodGeneral.NUM_CUENTA.Trim() + "'", out tempRefParam48, -1);
						
						if (! (rs.BOF && rs.EOF))
						{
							rs.MoveFirst();
							LsvTran.ListItems.Clear();
							LsvTran.Sorted = false;
							//& rs("origen")
							
							while(! rs.EOF)
							{
								object tempRefParam49 = Type.Missing;
								object tempRefParam50 = "k" + con.ToString();
								object tempRefParam51 = rs.Fields["origen"];
								object tempRefParam52 = Type.Missing;
								object tempRefParam53 = Type.Missing;
								LsvTran.ListItems.Add(ref tempRefParam49, ref tempRefParam50, ref tempRefParam51, ref tempRefParam52, ref tempRefParam53);
								object tempRefParam54 = LsvTran.ListItems.Count;
								LsvTran.ListItems.get_Item(ref tempRefParam54).set_SubItems(1, Convert.ToString(rs.Fields["trans_date"].Value));
								object tempRefParam55 = LsvTran.ListItems.Count;
								LsvTran.ListItems.get_Item(ref tempRefParam55).set_SubItems(2, Convert.ToString(rs.Fields["post_date"].Value));
								object tempRefParam56 = LsvTran.ListItems.Count;
								LsvTran.ListItems.get_Item(ref tempRefParam56).set_SubItems(3, Convert.ToString(rs.Fields["trans_id"].Value));
								object tempRefParam57 = LsvTran.ListItems.Count;
								LsvTran.ListItems.get_Item(ref tempRefParam57).set_SubItems(4, Convert.ToString(rs.Fields["trans_desc"].Value));
								object tempRefParam58 = LsvTran.ListItems.Count;
								LsvTran.ListItems.get_Item(ref tempRefParam58).set_SubItems(5, Convert.ToString(rs.Fields["monto_trans"].Value));
								
								object tempRefParam59 = LsvTran.ListItems.Count;
								LsvTran.ListItems.get_Item(ref tempRefParam59).set_SubItems(1, (Convert.ToDateTime(rs.Fields["trans_date"].Value) != DateAndTime.DateSerial(1900, 1, 1)) ? StringsHelper.Format(rs.Fields["trans_date"].Value, CRSParametros.cteFormatoFecha): "");
								object tempRefParam60 = LsvTran.ListItems.Count;
								LsvTran.ListItems.get_Item(ref tempRefParam60).set_SubItems(2, (Convert.ToDateTime(rs.Fields["post_date"].Value) != DateAndTime.DateSerial(1900, 1, 1)) ? StringsHelper.Format(rs.Fields["post_date"].Value, CRSParametros.cteFormatoFecha): "");
								object tempRefParam61 = LsvTran.ListItems.Count;
								LsvTran.ListItems.get_Item(ref tempRefParam61).set_SubItems(5, StringsHelper.Format(rs.Fields["monto_trans"].Value, CRSParametros.cteMascaraDinero));
								rs.MoveNext();
								con++;
							};
						} else
						{
							MessageBox.Show("No Existen Transacciones para el Tarjetahabiente que selecciono", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						
						rs.Close();
						rs = null;
						VBSQL.gConn[11].Close();
						
						
					} else
					{
						MessageBox.Show("Existio un error al cargar los datos" + "\r" + "Favor de Verificar con el Administrador del Sistema", "CCF C430", MessageBoxButtons.OK, MessageBoxIcon.Error);
						
					}
					
			}
			private void  frmNivelTrans_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}