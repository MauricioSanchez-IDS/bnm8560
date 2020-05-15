using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Drawing; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class CORRPEM2
		: System.Windows.Forms.Form
		{
		
			
			int hConexion = 0;
			int lRetorna = 0;
			
			int lNumEmpresa = 0;
			string pszNomEmpresa = String.Empty;
			int lNumTarjetas = 0;
			int lTransacciones = 0;
			int lCtasActivas = 0;
			double dFacturacion = 0;
			double dPromPagare = 0;
			double dPromTarjeta = 0;
			int lCtasCongeladas = 0;
			double dSaldosVencidos = 0;
			
			int lTotNumEmp = 0;
			int lTotNumTarj = 0;
			int lTotNumTransac = 0;
			int lTotCtaActi = 0;
			int lTotCtaCong = 0;
			double dTotFactura = 0;
			double dTotPromPag = 0;
			double dTotPromTar = 0;
			double dTotSaldos = 0;
			//VARIABLES PARA ALMACENAR EL DETALLE DE LOS SALDOS VENCIDOS
			double dSaldoVenc1mes = 0;
			double dSaldoVenc2mes = 0;
			double dSaldoVenc3mes = 0;
			int lNumTarjVenc1 = 0;
			int lNumTarjVenc2 = 0;
			int lNumTarjVenc3 = 0;
			int lTotTarjVenc1 = 0;
			int lTotTarjVenc2 = 0;
			int lTotTarjVenc3 = 0;
			double dTotVenc1mes = 0;
			double dTotVenc2mes = 0;
			double dTotVenc3mes = 0;
			int iNumMes1 = 0;
			int iNumMes2 = 0;
			int iNumMes3 = 0;
			int iCtasActivas = 0;
			double dPromTarjetas = 0;
			
			int intCont = 0;
			
			private int Carga_Reporte()
			{
					
					int result = 0;
					string pszCadena = String.Empty;
					int hBufDetalle = 0; //El apuntador a la sentencia SQL
					int hBufDetalle2 = 0; //El apuntador a la sentencia SQL
					int hBufDetalle3 = 0; //El apuntador a la sentencia SQL
					int iErr = 0; //Control local
					string pszSQL = String.Empty;
					
					int iPosIni = 0;
					int iPosFin = 0;
					int lRegistros = 0;
					double dCompras = 0;
					int lNumCompras = 0;
					double dDispEfvo = 0;
					int lNumDispEfvo = 0;
					string pszPath = String.Empty;
					string pszCadTemp = String.Empty;
					
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							Llena_Concentrado();
							
							this.Cursor = Cursors.WaitCursor;
							
							lTotNumEmp = CORVB.NULL_INTEGER;
							lTotNumTarj = CORVB.NULL_INTEGER;
							lTotNumTransac = CORVB.NULL_INTEGER;
							lTotCtaActi = CORVB.NULL_INTEGER;
							dTotFactura = CORVB.NULL_INTEGER;
							dTotPromPag = CORVB.NULL_INTEGER;
							dTotPromTar = CORVB.NULL_INTEGER;
							dTotSaldos = CORVB.NULL_INTEGER;
							double dComisiones = CORVB.NULL_INTEGER;
							lTotCtaActi = CORVB.NULL_INTEGER;
							//DETALLE DE SALDOS VENCIDOS
							lTotTarjVenc1 = CORVB.NULL_INTEGER;
							lTotTarjVenc2 = CORVB.NULL_INTEGER;
							lTotTarjVenc3 = CORVB.NULL_INTEGER;
							dTotVenc1mes = CORVB.NULL_INTEGER;
							dTotVenc2mes = CORVB.NULL_INTEGER;
							dTotVenc3mes = CORVB.NULL_INTEGER;
							
							
							//Obtiene Numero,Nombre,Tarjetas
							//***** INICIO CODIGO ANTERIOR FSWBMX *****
							//pszgblsql = "exec reporte_afi_emp " + Format$(igblBanco)
							//***** FIN DE CODIGO ANTERIOR FSWBMX *****
							//***** INICIO CODIGO NUEVO FSWBMX *****

                            CORVAR.pszgblsql = "exec spdbrp_emp_afi_detalle " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + ", " + Formato.ifncMes(CORVAR.igblMesDiaDEA) + ", " + Conversion.Str(CORVAR.igblAñoCorte);
							//***** FIN DE CODIGO NUEVO FSWBMX *****
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{ //Ocurrio algun error en la ejecución SQL
								
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{ //Obtenemos los Registros regresados por el Select
									
									lNumEmpresa = CORVB.NULL_INTEGER;
									pszCadena = CORVB.NULL_STRING;
									pszNomEmpresa = CORVB.NULL_STRING;
									lNumTarjetas = CORVB.NULL_INTEGER;
									dSaldosVencidos = CORVB.NULL_INTEGER;
									dFacturacion = CORVB.NULL_INTEGER;
									lTransacciones = CORVB.NULL_INTEGER;
									dPromPagare = CORVB.NULL_INTEGER;
									dPromTarjeta = CORVB.NULL_INTEGER;
									//DETALLE DE SALDOS VENCIDOS
									dSaldoVenc1mes = CORVB.NULL_INTEGER;
									dSaldoVenc2mes = CORVB.NULL_INTEGER;
									dSaldoVenc3mes = CORVB.NULL_INTEGER;
									lNumTarjVenc1 = CORVB.NULL_INTEGER;
									lNumTarjVenc2 = CORVB.NULL_INTEGER;
									lNumTarjVenc3 = CORVB.NULL_INTEGER;
									lNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
									pszCadena = VBSQL.SqlData(CORVAR.hgblConexion, 2);
									pszNomEmpresa = pszCadena;
									
									lNumTarjetas = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
									//  lTotNumTarj = lTotNumTarj + lNumTarjetas
									
									dSaldosVencidos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
									//  dTotSaldos = dTotSaldos + dSaldosVencidos
									
									//OBTIENE EL DETALLE DE LOS SALDOS VENCIDOS
									//MONTO DE SALDOS = A 1 MES O CON MAS DE 2 MESES
									dSaldoVenc1mes = CORVB.NULL_INTEGER;
									dSaldoVenc2mes = CORVB.NULL_INTEGER;
									dSaldoVenc3mes = CORVB.NULL_INTEGER;
									lNumTarjVenc1 = CORVB.NULL_INTEGER;
									lNumTarjVenc2 = CORVB.NULL_INTEGER;
									lNumTarjVenc3 = CORVB.NULL_INTEGER;
									dCompras = CORVB.NULL_INTEGER;
									lNumCompras = CORVB.NULL_INTEGER;
									dDispEfvo = CORVB.NULL_INTEGER;
									lNumDispEfvo = CORVB.NULL_INTEGER;
									dComisiones = CORVB.NULL_INTEGER;
									lCtasActivas = CORVB.NULL_INTEGER;

									lNumTarjVenc1 = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
									dSaldoVenc1mes = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6));
									lNumTarjVenc2 = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7)));
									dSaldoVenc2mes = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8));
									lNumTarjVenc3 = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 9)));
									dSaldoVenc3mes = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10));
									dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11));
									lNumCompras = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12)));
									dDispEfvo = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 13));
									lNumDispEfvo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 14)));
                                    dComisiones = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 15)));

									//Asigna las transacciones y las cantidades respectivas
									lTransacciones = lNumDispEfvo + lNumCompras;
									lTotNumTransac += lTransacciones;
									//Total de disposiciones,compras y comisiones
									dFacturacion = dDispEfvo + dCompras + dComisiones;
									lCtasActivas = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 16)));
									
									if (lCtasActivas != 0)
									{
										dPromTarjeta = dFacturacion / lCtasActivas;
									} else
									{
										dPromTarjeta = 0;
									}
									
									Llena_Detalle();
								};
								
								Coloca_totales();
								
							} else
							{
								this.Cursor = Cursors.Default;
							}
							
							FileSystem.FileClose(1);
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query
							
							this.Cursor = Cursors.Default;
							
							if (lTotNumEmp != 0)
							{
								result = -1;
							} else
							{
								result = 0;
							}
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
					return result;
			}
			
			
			//UPGRADE_NOTE: (7001) The following declaration (Carga_Reportes) seems to be dead code
			//private int Carga_Reportes()
			//{
					//proceso modificado
					//
					//string pszCadena = String.Empty;
					//int hBufDetalle = 0; //El apuntador a la sentencia SQL
					//int hBufDetalle2 = 0; //El apuntador a la sentencia SQL
					//int hBufDetalle3 = 0; //El apuntador a la sentencia SQL
					//int iErr = 0; //Control local
					//string pszSQL = String.Empty;
					//
					//int iPosIni = 0;
					//int iPosFin = 0;
					//int lRegistros = 0;
					//double dCompras = 0;
					//double dComisiones = 0;
					//int lNumCompras = 0;
					//double dDispEfvo = 0;
					//int lNumDispEfvo = 0;
					//string pszPath = String.Empty;
					//string pszCadTemp = String.Empty;
					//int iAnio = 0;
					//
					//
					//
					//Llena_Concentrado();
					//
					//string pszFecha = StringsHelper.Format(CORVAR.igblAñoCorte, "0000") + StringsHelper.Format(CORVAR.igblMesCorte, "0000");
					//
					//this.Cursor = Cursors.WaitCursor;
					//
					//lTotNumEmp = CORVB.NULL_INTEGER;
					//lTotNumTarj = CORVB.NULL_INTEGER;
					//lTotCtaActi = CORVB.NULL_INTEGER;
					//dTotFactura = CORVB.NULL_INTEGER;
					//dTotPromTar = CORVB.NULL_INTEGER;
					//lTotTarjVenc1 = CORVB.NULL_INTEGER;
					//dTotVenc1mes = CORVB.NULL_INTEGER;
					//lTotTarjVenc2 = CORVB.NULL_INTEGER;
					//dTotVenc2mes = CORVB.NULL_INTEGER;
					//lTotTarjVenc3 = CORVB.NULL_INTEGER;
					//dTotVenc3mes = CORVB.NULL_INTEGER;
					//dTotSaldos = CORVB.NULL_INTEGER;
					//
					//
					//obtiene numero,empresa, #tarjetas,pagos vencidos y total saldo vencido
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//pszgblsql = "exec empresas_afiliadas " + pszFecha + "," + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					//CORVAR.pszgblsql = "exec empresas_afiliadas " + pszFecha + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					//if (CORPROC2.Obtiene_Registros() != 0)
					//{ //Ocurrio algun error en la ejecución SQL
						//
						//
						//while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						//{ //Obtenemos los Registros regresados por el Select
							//
							//lNumEmpresa = CORVB.NULL_INTEGER;
							//pszNomEmpresa = CORVB.NULL_STRING;
							//lNumTarjetas = CORVB.NULL_INTEGER;
							//iNumMes1 = CORVB.NULL_INTEGER;
							//iNumMes2 = CORVB.NULL_INTEGER;
							//iNumMes3 = CORVB.NULL_INTEGER;
							//dSaldoVenc1mes = CORVB.NULL_INTEGER;
							//dSaldoVenc2mes = CORVB.NULL_INTEGER;
							//dSaldoVenc3mes = CORVB.NULL_INTEGER;
							//dSaldosVencidos = CORVB.NULL_INTEGER;
							//dFacturacion = CORVB.NULL_INTEGER;
							//iCtasActivas = CORVB.NULL_INTEGER;
							//dPromTarjetas = CORVB.NULL_INTEGER;
							//
							//lNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							//pszNomEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							//lNumTarjetas = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
							//iNumMes1 = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
							//dSaldoVenc1mes = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
							//iNumMes2 = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
							//dSaldoVenc2mes = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7));
							//iNumMes3 = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8)));
							//dSaldoVenc3mes = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 9));
							//dSaldosVencidos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10));
							//
							//if (dSaldoVenc1mes == 0)
							//{
								//iNumMes1 = 0;
							//}
							//if (dSaldoVenc2mes == 0)
							//{
								//iNumMes2 = 0;
							//}
							//if (dSaldoVenc3mes == 0)
							//{
								//iNumMes3 = 0;
							//}
							//
							//      If lNumEmpresa = 17700 Then
							//        lNumEmpresa = lNumEmpresa
							//      End If
							//OBTIENE la facturacion
							//***** INICIO CODIGO ANTERIOR FSWBMX *****
							//pszgblSql2 = "exec empresa_facturacion " + Format$(lNumEmpresa) + "," + Format$(igblBanco) + "," + Format$(pszFecha)
							//***** FIN DE CODIGO ANTERIOR FSWBMX *****
							//***** INICIO CODIGO NUEVO FSWBMX *****
							//CORVAR.pszgblSql2 = "exec empresa_facturacion " + lNumEmpresa.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + pszFecha.ToString();
							//***** FIN DE CODIGO NUEVO FSWBMX *****
							//if (CORPROC2.Consulta_Registros() != 0)
							//{
								//if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
								//{
									//dFacturacion = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
								//}
							//} else
							//{
								//this.Cursor = Cursors.Default;
							//}
							//lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2); //Realiza fin de Query
							//
							//OBTIENE las cuentas activas
							//***** INICIO CODIGO ANTERIOR FSWBMX *****
							//pszgblSql2 = "exec empresa_ctas_activas  " + Format$(lNumEmpresa) + "," + Format$(igblBanco)
							//***** FIN DE CODIGO ANTERIOR FSWBMX *****
							//***** INICIO CODIGO NUEVO FSWBMX *****
							//CORVAR.pszgblSql2 = "exec empresa_ctas_activas  " + lNumEmpresa.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
							//***** FIN DE CODIGO NUEVO FSWBMX *****
							//if (CORPROC2.Consulta_Registros() != 0)
							//{
								//if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
								//{
									//iCtasActivas = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
								//}
							//} else
							//{
								//this.Cursor = Cursors.Default;
							//}
							//lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2); //Realiza fin de Query
							//if (iCtasActivas != 0)
							//{
								//dPromTarjeta = dFacturacion / iCtasActivas;
							//} else
							//{
								//dPromTarjeta = 0;
							//}
							//
							//Llena_Detalle();
						//};
						//
						//Coloca_totales();
						//
					//} else
					//{
						//this.Cursor = Cursors.Default;
					//}
					//
					//FileSystem.FileClose(1);
					//
					//CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query
					//
					//this.Cursor = Cursors.Default;
					//
					//if (lTotNumEmp != 0)
					//{
						//return -1;
					//} else
					//{
						//return 0;
					//}
					//
			//}
			
			private void  Coloca_totales()
			{
					
					
					ID_EMA_REP_SS.MaxRows++;
					//Asigna el máximo de renglones
					ID_EMA_REP_SS.Row = ID_EMA_REP_SS.MaxRows;
					
					//Formatea ultimo renglon
					for (int iCont = 1; iCont <= 13; iCont++)
					{
						ID_EMA_REP_SS.Col = iCont;
						ID_EMA_REP_SS.BackColor = Color.Silver;
					}
					
					ID_EMA_REP_SS.Col = 1;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					ID_EMA_REP_SS.Text = "Total";
					
					//Empresas en Total
					ID_EMA_REP_SS.Col = 2;
					ID_EMA_REP_SS.TypeHAlign = 0;
					ID_EMA_REP_SS.Text = new String(' ', 2) + lTotNumEmp.ToString() + " Empresa(s)";
					
					//Total de Tarjetas
					ID_EMA_REP_SS.Col = 3;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					ID_EMA_REP_SS.Text = lTotNumTarj.ToString();
					
					
					//Total del Monto de Compras
					ID_EMA_REP_SS.Col = 4;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					ID_EMA_REP_SS.Text = lTotCtaActi.ToString();
					
					//Total de los saldos vencidos
					ID_EMA_REP_SS.Col = 5;
                    ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dTotFactura, "##,###,###,##0.00");
					
					//Total de los saldos vencidos
					ID_EMA_REP_SS.Col = 6;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dTotPromTar, "##,###,###,##0.00");
					
					//Total de Tarjetas con 1 mes vencido
					ID_EMA_REP_SS.Col = 7;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					ID_EMA_REP_SS.Text = lTotTarjVenc1.ToString();
					
					//Total de los saldos vencidos 1 mes
					ID_EMA_REP_SS.Col = 8;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dTotVenc1mes, "##,###,###,##0.00");
					
					ID_EMA_REP_SS.Col = 9;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					ID_EMA_REP_SS.Text = lTotTarjVenc2.ToString();
					
					
					//Total de los saldos vencidos 2 meses
					ID_EMA_REP_SS.Col = 10;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dTotVenc2mes, "##,###,###,##0.00");
					
					//Total de Tarjetas
					ID_EMA_REP_SS.Col = 11;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					ID_EMA_REP_SS.Text = lTotTarjVenc3.ToString();
					
					
					//Total de los saldos vencidos 2 meses
					ID_EMA_REP_SS.Col = 12;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dTotVenc3mes, "##,###,###,##0.00");
					
					//Total de los saldos vencidos
					ID_EMA_REP_SS.Col = 13;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dTotSaldos, "##,###,###,##0.00");
					
			}
			
			private void  CORRPEM2_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						
						CORVAR.igblFormaActiva = CORCONST.INT_ACT_EMA;
						CORPROC.Cambia_StatusOpciones(-1);
						
					}
			}
			
			//UPGRADE_WARNING: (2065) Form event CORRPEM2.Deactivate has a new behavior.
			private void  CORRPEM2_Deactivate( Object eventSender,  EventArgs eventArgs)
			{
					
					CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
					CORPROC.Cambia_StatusOpciones(0);
					
			}
			
			private void  CORRPEM2_KeyPress( Object eventSender,  KeyPressEventArgs eventArgs)
			{
					int KeyAscii = (int) eventArgs.KeyChar;
					
					if (KeyAscii == CORVB.KEY_ESCAPE)
					{
						this.Close();
					}
					
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
			public bool flag = false;
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					//this.Left = (int) VB6.TwipsToPixelsX(CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2;
					//this.Top = (int) VB6.TwipsToPixelsY(CORMDIBN.DefInstance.ClientRectangle.Height - this.Height) / 2;
					
					this.Cursor = Cursors.WaitCursor;
					
					
					intCont = CORDBLIB.Segunda_ConexionServidor();
					
					if (intCont != 0)
					{
						CORVAR.igblMesCorte = CORVAR.igblMesDiaDEA;
						
						Formatea_Spread();
						if ( ~Carga_Reporte() != 0)
						{
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
							//AIS-1182 NGONZALEZ
						//	CORVAR.igblErr = API.USER.PostMessage(CORRPEM2.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                            this.flag = true;
                        }
					} else
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
						//AIS-1182 NGONZALEZ
                        this.flag = true;
						//CORVAR.igblErr = API.USER.PostMessage(CORRPEM2.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
						
					}
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  CORRPEM2_Closed( Object eventSender,  EventArgs eventArgs)
			{
					
					VBSQL.SqlClose(CORVAR.hgblConexion2);
					CORVAR.hgblConexion2 = CORVB.NULL_INTEGER;
					VBSQL.subCanConRec(ref intCont);
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			
			private void  Formatea_Spread()
			{
					
                    //int iCont = 0;
					
                    //ID_EMA_REP_SS.ReDraw = false;
					
                    ////  ID_EMA_REP_SS.AllowSelBlock = False
                    ////  ID_EMA_REP_SS.AllowResize = False
					
                    //ID_EMA_REP_SS.Row = CORVB.NULL_INTEGER;
					
                    //ID_EMA_REP_SS.Col = 1;
                    //ID_EMA_REP_SS.set_ColWidth(1, 7);
                    //ID_EMA_REP_SS.Text = "Número";
					
                    //ID_EMA_REP_SS.Col = 2;
                    //ID_EMA_REP_SS.set_ColWidth(2, 35);
                    //ID_EMA_REP_SS.Text = "Empresa";
					
                    //ID_EMA_REP_SS.Col = 3;
                    //ID_EMA_REP_SS.set_ColWidth(3, 10);
                    //ID_EMA_REP_SS.Text = "Tarjetas";
					
					
                    //ID_EMA_REP_SS.Col = 4;
                    //ID_EMA_REP_SS.set_ColWidth(4, 10);
                    //ID_EMA_REP_SS.Text = "Ctas Activas";
					
                    //ID_EMA_REP_SS.Col = 5;
                    //ID_EMA_REP_SS.set_ColWidth(5, 18);
                    //ID_EMA_REP_SS.Text = "Facturación";
					
					
                    //ID_EMA_REP_SS.Col = 6;
                    //ID_EMA_REP_SS.set_ColWidth(6, 13);
                    //ID_EMA_REP_SS.Text = "Prom. Tarjs.";
					
                    //ID_EMA_REP_SS.Col = 7;
                    //ID_EMA_REP_SS.set_ColWidth(7, 10);
                    //ID_EMA_REP_SS.Text = "# Tarjs. 1 M.V.";
					
					
                    //ID_EMA_REP_SS.Col = 8;
                    //ID_EMA_REP_SS.set_ColWidth(8, 18);
                    //ID_EMA_REP_SS.Text = "Sdos 1 M.V.";
					
                    //ID_EMA_REP_SS.Col = 9;
                    //ID_EMA_REP_SS.set_ColWidth(9, 10);
                    //ID_EMA_REP_SS.Text = "# Tarjs. 2 M.V.";
					
					
                    //ID_EMA_REP_SS.Col = 10;
                    //ID_EMA_REP_SS.set_ColWidth(10, 18);
                    //ID_EMA_REP_SS.Text = "Sdos 2 M.V.";
					
                    //ID_EMA_REP_SS.Col = 11;
                    //ID_EMA_REP_SS.set_ColWidth(11, 10);
                    //ID_EMA_REP_SS.Text = "# Tarjs. >= 3 M.V.";
					
					
                    //ID_EMA_REP_SS.Col = 12;
                    //ID_EMA_REP_SS.set_ColWidth(12, 18);
                    //ID_EMA_REP_SS.Text = "Sdos >= 3 M.V.";
					
					
                    //ID_EMA_REP_SS.Col = 13;
                    //ID_EMA_REP_SS.set_ColWidth(13, 18);
                    //ID_EMA_REP_SS.Text = "Saldos Venc.";
					
                    //ID_EMA_REP_SS.MaxRows = 1;
					
			}
			
			private void  ID_CEJ_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					CORPROC.Imprime_Reporte();
			}
			
			private void  ID_CEJ_SAL_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					this.Close();
					
					this.Cursor = Cursors.Default;
					
			}
			
			private void  Llena_Concentrado()
			{
					
					int hBufANG = 0; //El apuntador a la sentencia SQL
					int iTempErr = 0; //Control local
					double dSaldoAnt = 0;
					double dPagosyAbonos = 0;
					double dComisiones = 0;
					double dIntereses = 0;
					double dIva = 0;
					double dCompras = 0;
					double dDisposiciones = 0;
					int iMes = 0;
					int iAño = 0;
					string pszTempMA = String.Empty;
					string pszSentencia = String.Empty;
					
					CORVAR.igblErr = CORCONST.OK;
					
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//pszgblsql = "exec reporte_afi_saldos " + Format$(igblBanco) + "," + Format$(igblMesDiaDEA)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//12.11.2001 Inicio Código Anterior
					//***** INICIO CODIGO NUEVO FSWBMX *****
					//  pszgblsql = "exec reporte_afi_saldos " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaDEA)
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					//12.11.2001 Fin Código Anterior
					//EISSA 12.11.2001 Código Nuevo Cambio de parámetros de los Sp's, ahora sólo se requiere utilizar el mes actual

                    CORVAR.pszgblsql = "exec spdbrp_emp_afi_conc " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesDiaDEA).ToString() + "," + Conversion.Str(CORVAR.igblAñoCorte);
					//EISSA 12.11.2001 Fin de Código Nuevo
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							dSaldoAnt = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							dPagosyAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));
							dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3));
							dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
							dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
							dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;

							dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6));
							dDisposiciones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7));
						}
						
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL
						
					} else
					{
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL
					}
					
					ID_DAT_RES_TXT[0].Text = StringsHelper.Format(dSaldoAnt, "$##,###,###,##0.00");
					ID_DAT_RES_TXT[1].Text = StringsHelper.Format(dCompras, "$##,###,###,##0.00");
					ID_DAT_RES_TXT[2].Text = StringsHelper.Format(dDisposiciones, "$##,###,###,##0.00");
					ID_DAT_RES_TXT[3].Text = StringsHelper.Format(dPagosyAbonos, "$##,###,###,##0.00");
					ID_DAT_RES_TXT[4].Text = StringsHelper.Format(dComisiones, "$##,###,###,##0.00");
					ID_DAT_RES_TXT[5].Text = StringsHelper.Format(dIntereses, "$##,###,###,##0.00");
					ID_DAT_RES_TXT[6].Text = StringsHelper.Format(dIva, "$##,###,##0.00");
					ID_DAT_RES_TXT[7].Text = StringsHelper.Format(dSaldoAnt - dCompras - dDisposiciones + dPagosyAbonos - dComisiones - dIntereses - dIva, "$##,###,###,##0.00");
					
			}
			
			private void  Llena_Detalle()
			{
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_EMA_REP_SS.Row = ID_EMA_REP_SS.MaxRows;
					
					//Cuenta del empresa
					ID_EMA_REP_SS.Col = 1;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//***** Código Anterior     ***********
					//  ID_EMA_REP_SS.Text = Format$(lNumEmpresa, "00000")
					//***** Fin Código Anterior ***********
					//EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
					ID_EMA_REP_SS.Text = StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
					//EISSA 05.10.2001 FIN
					lTotNumEmp++;
					
					//Nombre del empresa
					ID_EMA_REP_SS.Col = 2;
					ID_EMA_REP_SS.Text = pszNomEmpresa.Trim();
					
					//No de Tarjetas
					ID_EMA_REP_SS.Col = 3;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					ID_EMA_REP_SS.Text = lNumTarjetas.ToString();
					lTotNumTarj += lNumTarjetas;
					
					//No. Ctas Activas
					ID_EMA_REP_SS.Col = 4;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					ID_EMA_REP_SS.Text = lCtasActivas.ToString();
					lTotCtaActi += lCtasActivas;
					
					//Facturacion
					ID_EMA_REP_SS.Col = 5;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dFacturacion, "##,###,###,##0.00");
					dTotFactura += dFacturacion;
					
					//Promedio de Tarjetas
					ID_EMA_REP_SS.Col = 6;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dPromTarjeta, "##,###,###,##0.00");
					dTotPromTar += dPromTarjeta;
					
					//No. Ctas Vencidas con 1mes
					ID_EMA_REP_SS.Col = 7;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//  ID_EMA_REP_SS.Text = Format$(iNumMes1)
					//  lTotTarjVenc1 = lTotTarjVenc1 + iNumMes1
					ID_EMA_REP_SS.Text = lNumTarjVenc1.ToString();
					lTotTarjVenc1 += lNumTarjVenc1;
					
					//Saldos Vencidos con 1 mes
					ID_EMA_REP_SS.Col = 8;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dSaldoVenc1mes, "##,###,###,##0.00");
					dTotVenc1mes += dSaldoVenc1mes;
					
					//No. Ctas Vencidas con 2 meses
					ID_EMA_REP_SS.Col = 9;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//  ID_EMA_REP_SS.Text = Format$(iNumMes2)
					//  lTotTarjVenc2 = lTotTarjVenc2 + iNumMes2
					ID_EMA_REP_SS.Text = lNumTarjVenc2.ToString();
					lTotTarjVenc2 += lNumTarjVenc2;
					
					//Saldos Vencidos con 2 meses
					ID_EMA_REP_SS.Col = 10;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dSaldoVenc2mes, "##,###,###,##0.00");
					dTotVenc2mes += dSaldoVenc2mes;
					
					//No. Ctas Vencidas con 3 o mas meses
					ID_EMA_REP_SS.Col = 11;
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
					//  ID_EMA_REP_SS.Text = Format$(iNumMes3)
					//  lTotTarjVenc3 = lTotTarjVenc3 + iNumMes3
					ID_EMA_REP_SS.Text = lNumTarjVenc3.ToString();
					lTotTarjVenc3 += lNumTarjVenc3;
					
					//Saldos Vencidos con 3 o mas meses
					ID_EMA_REP_SS.Col = 12;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
					ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dSaldoVenc3mes, "##,###,###,##0.00");
					dTotVenc3mes += dSaldoVenc3mes;
					
					//Saldos Vencidos
					ID_EMA_REP_SS.Col = 13;
					ID_EMA_REP_SS.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                    ID_EMA_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
					ID_EMA_REP_SS.Text = StringsHelper.Format(dSaldosVencidos, "##,###,###,##0.00");
					dTotSaldos += dSaldosVencidos;
					
					ID_EMA_REP_SS.MaxRows++;
					
			}

        private void CORRPEM2_Load(object sender, EventArgs e)
        {

        }
		}
}