using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmSBFEmpresa
		: System.Windows.Forms.Form
		{
		
			
			
			string smfecha = String.Empty;
			string smhora = String.Empty;
			bool blbandera = false;
			string slFechaIni = String.Empty;
			string slFechaFin = String.Empty;
			
			private void  cmdConsultaTarj_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Cursor = Cursors.WaitCursor;
					//UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
					frm_SBF_tarjetahab.DefInstance.ShowDialog();
					
			}
			
			private void  cmdSBFerror_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					string slNomArch = String.Empty;
					bool blInserta = false;
					
					try
					{
							if (MessageBox.Show("¿ Confirma que desea rechazar el archivo SBF ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
							{
								
								//---Ariadna---
								//Query para buscar el estatus 15 en el día de hoy
								//que corresponda a corte o a diario
								
								this.Cursor = Cursors.WaitCursor;
								
								smfecha = DateTime.Today.ToString("yyyyMMdd");
								smhora = DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss");
								
								CORVAR.pszgblsql = "select";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_nomarch";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCPRO03";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " where pro_fecha = '" + smfecha + "'";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch = '" + mdlParametros.sgDescArch + "'";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_estatus = 15";
								
								blInserta = ! (CORPROC2.Cuenta_Registros() > 0);
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								
								//---Ariadna---
								//Si no se encuentra ningún estatus 15 del día de hoy, se inserta un registro indicando dicho estatus, así como el mensaje, el nombre de archivo la fecha y hora
								if (blInserta)
								{
									
									CORVAR.pszgblsql = "insert into MTCPRO03";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "(pro_fecha,";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "pro_hora,";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "pro_nomarch,";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "pro_estatus,";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "pro_mensaje)";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " values ('" + smfecha + "'";
									CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + smhora + "'";
									CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mdlParametros.sgDescArch + "'";
									CORVAR.pszgblsql = CORVAR.pszgblsql + ",15";
									CORVAR.pszgblsql = CORVAR.pszgblsql + ",'EL ARCHIVO SBF FUE RECHAZADO POR EL USUARIO')";
									
									if (CORPROC2.Modifica_Registro() != 0)
									{
										MessageBox.Show("Ha sido rechazado el Archivo: " + mdlParametros.sgDescArch, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
										cmdSBFvobo.Enabled = false;
										cmdSBFerror.Enabled = false;
									}
									
									//---Ariadna---
									//Si ya existe un estatus 15 en la tabla, se le indica al usuario que el
									//archivo ya fue rechazado
								} else
								{
									MessageBox.Show("El Archivo: " + mdlParametros.sgDescArch + ", ya fue rechazado.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									cmdSBFvobo.Enabled = false;
									cmdSBFerror.Enabled = false;
								}
								this.Cursor = Cursors.Default;
							}
						}
                        catch (Exception e)
					{
						
						
						CRSGeneral.prObtenError("frmSBFEmpresa (SBFerror)",e );
						this.Cursor = Cursors.Default;
						return;
					}
			}
			
			private void  cmdSBFsalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			private void  prObtenFecha()
			{
					
					//---Ariadna---
					//Procedimiento para obtener la fecha inicial y la fecha final
					//dependiendo si sgDescArch es corte o diario
					
					try
					{
							
							smfecha = DateTime.Today.ToString("yyyyMMdd");
							
							CORVAR.pszgblsql = " select";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_fecha_inicial,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_fecha_final";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCPRO04";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " Where";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_fecha = '" + smfecha + "'";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch = '" + mdlParametros.sgDescArch + "'";
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									slFechaIni = VBSQL.SqlData(CORVAR.hgblConexion, 1);
									slFechaFin = VBSQL.SqlData(CORVAR.hgblConexion, 2);
								};
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							}
						}
                        catch (Exception e)
					{
						
						
						CRSGeneral.prObtenError("frmSBFEmpresa (ObtenFecha)",e );
						return;
					}
					
			}
			private void  cmdSBFvobo_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					string slNomArch = String.Empty;
					bool blInserta = false;
					
					try
					{
							
							if (MessageBox.Show("¿ Confirma que desea dar su visto bueno al archivo SBF ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
							{
								
								//---Ariadna---
								//Si se valida el archivo, primero se busca un estatus 14 del día de hoy
								//que corresponda a corte o diario
								
								this.Cursor = Cursors.WaitCursor;
								
								smfecha = DateTime.Today.ToString("yyyyMMdd");
								smhora = DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss");
								
								CORVAR.pszgblsql = "select";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_nomarch";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCPRO03";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " where pro_fecha = '" + smfecha + "'";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch = '" + mdlParametros.sgDescArch + "'";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_estatus = 14";
								
								blInserta = ! (CORPROC2.Cuenta_Registros() > 0);
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								
								//---Ariadna---
								//Si no se ha validado aún el archivo, se inserta un registro con estatus 14,
								//la hora y el nombre del archivo (corte o diario)
								
								if (blInserta)
								{
									
									CORVAR.pszgblsql = "insert into MTCPRO03";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "(pro_fecha,";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "pro_hora,";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "pro_nomarch,";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "pro_estatus,";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "pro_mensaje)";
									CORVAR.pszgblsql = CORVAR.pszgblsql + " values ('" + smfecha + "'";
									CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + smhora + "'";
									CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mdlParametros.sgDescArch + "'";
									CORVAR.pszgblsql = CORVAR.pszgblsql + ",14";
									CORVAR.pszgblsql = CORVAR.pszgblsql + ",'EL ARCHIVO SBF FUE VALIDADO POR EL USUARIO')";
									
									if (CORPROC2.Modifica_Registro() != 0)
									{
										MessageBox.Show("El visto bueno ha sido aceptado. El Archivo SBF: " + mdlParametros.sgDescArch + " es correcto.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
										cmdSBFerror.Enabled = false;
										cmdSBFvobo.Enabled = false;
									}
									
									//---Ariadna---
									//Cuando ya existe algún estatus 14, sólo se le indica al usuario que el
									//archivo (ya sea corte o diario) ya fue validado
								} else
								{
									MessageBox.Show("El Archivo: " + mdlParametros.sgDescArch + ", ya fue validado.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									cmdSBFerror.Enabled = false;
									cmdSBFvobo.Enabled = false;
								}
								
								this.Cursor = Cursors.Default;
							}
						}
                        catch (Exception e)
					{
						
						
						CRSGeneral.prObtenError("frmSBFEmpresa (SBFvobo)",e );
						this.Cursor = Cursors.Default;
						return;
					}
			}
			
			private void  frmSBFEmpresa_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						if (! blbandera)
						{
							this.Close();
						}
					}
			}
			
			private void  Form_Initialize_Renamed()
			{
					
					this.Cursor = Cursors.WaitCursor;
					
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					mdlParametros.gperPerfil.prHabilitaAcciones(frmSBFEmpresa.DefInstance);
					prObtenFecha();
					prHabilitaBotones();
					
					//---Ariadna---
					//Cuando el envío de SBF es diario
					if (mdlParametros.IgEnvioSBF == 2)
					{
						sprSBFEmpresa1.Col = 3;
						sprSBFEmpresa1.ColHidden = true;
						sprSBFEmpresa1.Col = 4;
						sprSBFEmpresa1.ColHidden = true;
						sprSBFEmpresa1.set_ColWidth(5, 80);
						sprSBFEmpresa1.set_ColWidth(6, 80);
						sprSBFEmpresa1.set_ColWidth(7, 80);
						
						sprSBFEmpresa1.Width = (int) VB6.TwipsToPixelsX(9000);
						sprSBFEmpresa1.Left = (int) VB6.TwipsToPixelsX(1000);
						
						LBL_FECHA[0].Text = "Fecha inicial";
						LBL_FECHA[1].Text = slFechaIni.Substring(0, Math.Min(slFechaIni.Length, 4)) + "/" + Strings.Mid(slFechaIni, 5, 2) + "/" + slFechaIni.Substring(slFechaIni.Length - Math.Min(slFechaIni.Length, 2));
						LBL_FECHA[2].Text = "Fecha final";
						LBL_FECHA[3].Text = slFechaFin.Substring(0, Math.Min(slFechaFin.Length, 4)) + "/" + Strings.Mid(slFechaFin, 5, 2) + "/" + slFechaFin.Substring(slFechaFin.Length - Math.Min(slFechaFin.Length, 2));
						LBL_FECHA[2].Visible = true;
						LBL_FECHA[3].Visible = true;
						
						//---Ariadna---
						//Si el envío de SBF es por corte
					} else
					{
						LBL_FECHA[0].Text = "Fecha de corte";
						LBL_FECHA[1].Text = slFechaFin.Substring(0, Math.Min(slFechaFin.Length, 4)) + "/" + Strings.Mid(slFechaFin, 5, 2) + "/" + slFechaFin.Substring(slFechaFin.Length - Math.Min(slFechaFin.Length, 2));
					}
					
					//---Ariadna---
					//Se crean instancias de la colección colcatSBFC430Empresa
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcsbfEmpresaSBF = new colcatSBFC430Empresa();
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcsbfEmpresaC430 = new colcatSBFC430Empresa();
					
					//---Ariadna---
					//Llamada al procedimiento prObtenerEmpresa de la colección colcatSBFC430Empresa
					//donde se realizan los queries  para SBF y C430
					mdlParametros.gcsbfEmpresaSBF.prObtenerEmpresa(clsSBFC430Empresa.enuTipoSBFC430Empresa.tsbfc430EmpresaSBF);
					mdlParametros.gcsbfEmpresaC430.prObtenerEmpresa(clsSBFC430Empresa.enuTipoSBFC430Empresa.tsbfc430EmpresaC430);
					
					prLlenaSpreadEmp();
					
					this.Cursor = Cursors.Default;
					
			}
			private void  prHabilitaBotones()
			{
					
					//---Ariadna---
					//Procedimiento que se encarga de determinar si el archivo ya fue validado o
					//rechazado para deshabilitar los botones correspondientes al momento de cargar la forma
					
					try
					{
							
							smfecha = DateTime.Today.ToString("yyyyMMdd");
							smhora = DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss");
							
							CORVAR.pszgblsql = "select";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " *";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCPRO03";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where pro_fecha = '" + smfecha + "'";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch = '" + mdlParametros.sgDescArch + "'";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_estatus = 15";
							
							if (CORPROC2.Cuenta_Registros() > 0)
							{
								cmdSBFvobo.Enabled = false;
								cmdSBFerror.Enabled = false;
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
							CORVAR.pszgblsql = "select";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " *";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCPRO03";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where pro_fecha = '" + smfecha + "'";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch = '" + mdlParametros.sgDescArch + "'";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_estatus = 14";
							
							if (CORPROC2.Cuenta_Registros() > 0)
							{
								cmdSBFvobo.Enabled = false;
								cmdSBFerror.Enabled = false;
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
                        catch (Exception e)
					{
						
						
						CRSGeneral.prObtenError("frmSBFEmpresa (HabilitaBotones)",e );
						return;
					}
					
			}
			
			private void  prLlenaSpreadEmp()
			{
					bool bRegC430Existe = false, bContinuaLlenado = false, bRegSBFExiste = false;
					int lNumEmpSBF = 0, lNumEmpC430 = 0;
					
					if ((mdlParametros.gcsbfEmpresaSBF.Count > 0) || (mdlParametros.gcsbfEmpresaC430.Count > 0))
					{
						bContinuaLlenado = true;
						blbandera = true;
					} else
					{
						bContinuaLlenado = false;
					}
					int llRow = 1;
					int iContSBF = 1;
					int iContC430 = 1;
					sprSBFEmpresa1.MaxRows = 0;
					
					while(bContinuaLlenado)
					{
						bRegSBFExiste = iContSBF <= mdlParametros.gcsbfEmpresaSBF.Count;
						bRegC430Existe = iContC430 <= mdlParametros.gcsbfEmpresaC430.Count;
						sprSBFEmpresa1.MaxRows++;
						sprSBFEmpresa1.Row = llRow;
						if (bRegSBFExiste && bRegC430Existe)
						{
							lNumEmpSBF = mdlParametros.gcsbfEmpresaSBF[iContSBF].EmpNumL;
							lNumEmpC430 = mdlParametros.gcsbfEmpresaC430[iContC430].EmpNumL;
							if (lNumEmpSBF == lNumEmpC430)
							{
								for (int llCol = 1; llCol <= 7; llCol++)
								{
									sprSBFEmpresa1.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFEmpresa1.Text = "SBF"; 
											break;
										case 2 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].EmpNumL.ToString() + " - " + (mdlParametros.gcsbfEmpresaSBF[iContSBF].EmpNumNomS); 
											break;
										case 3 : 
											sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaSBF[iContSBF].SaldoAnteriorD, ".00"); 
											break;
										case 4 : 
											sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaSBF[iContSBF].SaldoActualD, ".00"); 
											break;
										case 5 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].THSNumL.ToString(); 
											break;
										case 6 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].TransNumL.ToString(); 
											break;
										case 7 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].TipoFactS; 
											break;
									}
								}
								llRow++;
								sprSBFEmpresa1.MaxRows++;
								sprSBFEmpresa1.Row = llRow;
								for (int llCol = 1; llCol <= 7; llCol++)
								{
									sprSBFEmpresa1.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFEmpresa1.Text = "C430"; 
											break;
										case 2 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].EmpNumL.ToString() + " - " + (mdlParametros.gcsbfEmpresaC430[iContC430].EmpNumNomS); 
											break;
										case 3 : 
											sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaC430[iContC430].SaldoAnteriorD, ".00"); 
											break;
										case 4 : 
											sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaC430[iContC430].SaldoActualD, ".00"); 
											break;
										case 5 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].THSNumL.ToString(); 
											break;
										case 6 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].TransNumL.ToString(); 
											break;
										case 7 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].TipoFactS; 
											break;
									}
								}
								iContSBF++;
								iContC430++;
							} else if (lNumEmpSBF < lNumEmpC430) { 
								for (int llCol = 1; llCol <= 7; llCol++)
								{
									sprSBFEmpresa1.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFEmpresa1.Text = "SBF"; 
											break;
										case 2 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].EmpNumL.ToString() + " - " + (mdlParametros.gcsbfEmpresaSBF[iContSBF].EmpNumNomS); 
											break;
										case 3 : 
											sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaSBF[iContSBF].SaldoAnteriorD, ".00"); 
											break;
										case 4 : 
											sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaSBF[iContSBF].SaldoActualD, ".00"); 
											break;
										case 5 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].THSNumL.ToString(); 
											break;
										case 6 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].TransNumL.ToString(); 
											break;
										case 7 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].TipoFactS; 
											break;
									}
								}
								iContSBF++;
							} else if (lNumEmpSBF > lNumEmpC430) { 
								for (int llCol = 1; llCol <= 7; llCol++)
								{
									sprSBFEmpresa1.Col = llCol;
									switch(llCol)
									{
										case 1 : 
											sprSBFEmpresa1.Text = "C430"; 
											break;
										case 2 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].EmpNumL.ToString() + " - " + (mdlParametros.gcsbfEmpresaC430[iContC430].EmpNumNomS); 
											break;
										case 3 : 
											sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaC430[iContC430].SaldoAnteriorD, ".00"); 
											break;
										case 4 : 
											sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaC430[iContC430].SaldoActualD, ".00"); 
											break;
										case 5 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].THSNumL.ToString(); 
											break;
										case 6 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].TransNumL.ToString(); 
											break;
										case 7 : 
											sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].TipoFactS; 
											break;
									}
								}
								iContC430++;
							}
							
						} else if (bRegSBFExiste) { 
							for (int llCol = 1; llCol <= 7; llCol++)
							{
								sprSBFEmpresa1.Col = llCol;
								switch(llCol)
								{
									case 1 : 
										sprSBFEmpresa1.Text = "SBF"; 
										break;
									case 2 : 
										sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].EmpNumL.ToString() + " - " + (mdlParametros.gcsbfEmpresaSBF[iContSBF].EmpNumNomS); 
										break;
									case 3 : 
										sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaSBF[iContSBF].SaldoAnteriorD, ".00"); 
										break;
									case 4 : 
										sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaSBF[iContSBF].SaldoActualD, ".00"); 
										break;
									case 5 : 
										sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].THSNumL.ToString(); 
										break;
									case 6 : 
										sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].TransNumL.ToString(); 
										break;
									case 7 : 
										sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaSBF[iContSBF].TipoFactS; 
										break;
								}
							}
							iContSBF++;
						} else if (bRegC430Existe) { 
							for (int llCol = 1; llCol <= 7; llCol++)
							{
								sprSBFEmpresa1.Col = llCol;
								switch(llCol)
								{
									case 1 : 
										sprSBFEmpresa1.Text = "C430"; 
										break;
									case 2 : 
										sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].EmpNumL.ToString() + " - " + (mdlParametros.gcsbfEmpresaC430[iContC430].EmpNumNomS); 
										break;
									case 3 : 
										sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaC430[iContC430].SaldoAnteriorD, ".00"); 
										break;
									case 4 : 
										sprSBFEmpresa1.Text = StringsHelper.Format(mdlParametros.gcsbfEmpresaC430[iContC430].SaldoActualD, ".00"); 
										break;
									case 5 : 
										sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].THSNumL.ToString(); 
										break;
									case 6 : 
										sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].TransNumL.ToString(); 
										break;
									case 7 : 
										sprSBFEmpresa1.Text = mdlParametros.gcsbfEmpresaC430[iContC430].TipoFactS; 
										break;
								}
							}
							iContC430++;
						} else if (! bRegSBFExiste && ! bRegC430Existe) { 
							bContinuaLlenado = false;
						}
						llRow++;
					};
					
					//'---Ariadna---
					//'Procedimiento que se encarga de llenar el Spread con los registros obtenidos tanto de SBF como de C430
					//'estos registros son presentados de manera intercalada
					//
					//Dim llRow As Long
					//Dim llCol As Long
					//Dim ilRes, ilItem As Integer
					//
					//    llRow = 1
					//    ilItem = 1
					//    sprSBFEmpresa1.MaxRows = 0
					//
					//
					//    ilRes = gcsbfEmpresaSBF.Count + gcsbfEmpresaC430.Count + 1
					//
					//'    If (gcsbfEmpresaSBF.Count <> gcsbfEmpresaC430.Count) Then
					//'        MsgBox "No concuerda el número de registros entre SBF y C430", vbInformation + vbOKOnly, App.Title
					//'        blbandera = False
					//'    Else
					//
					//        If gcsbfEmpresaSBF.Count > 0 Then
					//
					//            blbandera = True
					//
					//            Do Until llRow = ilRes
					//
					//                sprSBFEmpresa1.MaxRows = sprSBFEmpresa1.MaxRows + 1
					//
					//                sprSBFEmpresa1.Row = llRow
					//
					//    '            If ilItem > gcsbfEmpresaSBF.Count Then
					//    '                Exit Do
					//    '            End If
					//
					//                For llCol = 1 To 7
					//                    sprSBFEmpresa1.Col = llCol
					//                    Select Case llCol
					//                        Case 1
					//                            If llRow Mod 2 <> 0 Then
					//                                sprSBFEmpresa1.Text = "SBF"
					//                            End If
					//                            If llRow Mod 2 = 0 Then
					//                                sprSBFEmpresa1.Text = "C430"
					//                            End If
					//                        Case 2
					//                            If llRow Mod 2 <> 0 Then
					//                                'Pruebas
					//                                'sprSBFEmpresa1.Text = CStr(gcsbfEmpresaSBF.Item(ilItem).EmpNumL) & " - " & (gcsbfEmpresaSBF.Item(ilItem).EmpNomS)
					//                                sprSBFEmpresa1.Text = CStr(gcsbfEmpresaSBF.Item(ilItem).EmpNumL) & " - " & (gcsbfEmpresaSBF.Item(ilItem).EmpNumNomS)
					//
					//                            End If
					//                            If llRow Mod 2 = 0 Then
					//                                'Pruebas
					//                                'sprSBFEmpresa1.Text = CStr(gcsbfEmpresaC430.Item(ilItem).EmpNumL) & " - " & (gcsbfEmpresaC430.Item(ilItem).EmpNomS)
					//                                sprSBFEmpresa1.Text = CStr(gcsbfEmpresaC430.Item(ilItem).EmpNumL) & " - " & (gcsbfEmpresaC430.Item(ilItem).EmpNumNomS)
					//                            End If
					//                        Case 3
					//                            If llRow Mod 2 <> 0 Then
					//                                sprSBFEmpresa1.Text = Format(gcsbfEmpresaSBF.Item(ilItem).SaldoAnteriorD, ".00")
					//                            End If
					//                            If llRow Mod 2 = 0 Then
					//                                sprSBFEmpresa1.Text = Format(gcsbfEmpresaC430.Item(ilItem).SaldoAnteriorD, ".00")
					//                            End If
					//                        Case 4
					//                            If llRow Mod 2 <> 0 Then
					//                                sprSBFEmpresa1.Text = Format(gcsbfEmpresaSBF.Item(ilItem).SaldoActualD, ".00")
					//                            End If
					//                            If llRow Mod 2 = 0 Then
					//                                sprSBFEmpresa1.Text = Format(gcsbfEmpresaC430.Item(ilItem).SaldoActualD, ".00")
					//                            End If
					//                        Case 5
					//                            If llRow Mod 2 <> 0 Then
					//                                sprSBFEmpresa1.Text = gcsbfEmpresaSBF.Item(ilItem).THSNumL
					//                            End If
					//                            If llRow Mod 2 = 0 Then
					//                                sprSBFEmpresa1.Text = gcsbfEmpresaC430.Item(ilItem).THSNumL
					//                            End If
					//                        Case 6
					//                            If llRow Mod 2 <> 0 Then
					//                                sprSBFEmpresa1.Text = gcsbfEmpresaSBF.Item(ilItem).TransNumL
					//                            End If
					//                            If llRow Mod 2 = 0 Then
					//                                sprSBFEmpresa1.Text = gcsbfEmpresaC430.Item(ilItem).TransNumL
					//                            End If
					//                        Case 7
					//                            If llRow Mod 2 <> 0 Then
					//                                sprSBFEmpresa1.Text = gcsbfEmpresaSBF.Item(ilItem).TipoFactS
					//                            End If
					//                            If llRow Mod 2 = 0 Then
					//                                sprSBFEmpresa1.Text = gcsbfEmpresaC430.Item(ilItem).TipoFactS
					//                            End If
					//
					//                    End Select
					//                Next llCol
					//
					//                If llRow Mod 2 = 0 Then
					//                    ilItem = ilItem + 1
					//                End If
					//
					//                llRow = llRow + 1
					//
					//            Loop
					//        Else
					//            MsgBox "La información acerca de las empresas no se encuentra disponible", vbInformation + vbOKOnly, App.Title
					//            blbandera = False
					//
					//        End If
					//'    End If
			}
			private void  prBorraTablasTemp()
			{
					
					CORVAR.pszgblsql = " drop table #resultado1 ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " drop table #resultado2 ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " drop table #resultado3 ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " drop table #resultado4 ";
					
					CORPROC2.Ejecuta_sentencia();
					
			}
			
			private void  frmSBFEmpresa_Closed( Object eventSender,  EventArgs eventArgs)
			{
					prBorraTablasTemp();
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}			
			

            private void fpSBFEmpresa1_Click(object sender, EventArgs e)
            {
                string vlFiltroEmp = String.Empty;

                int llCol = sprSBFEmpresa1.ActiveColumn;
                int llRow = sprSBFEmpresa1.ActiveRow;
                cmdConsultaTarj.Enabled = true;

                object tempRefParam = vlFiltroEmp;
                sprSBFEmpresa1.GetText(2, llRow, ref tempRefParam);
                int IlLongEmp = mdlParametros.gprdProducto.LongitudEmpresaI;

                //---Ariadna---
                //sgFiltroEmpresa almacena el número de empresa perteneciente a la fila donde
                //se dió click
                mdlParametros.sgFiltroEmpresa = Conversion.Val(Strings.Mid(vlFiltroEmp, 1, IlLongEmp)).ToString();
                Label5.Text = mdlParametros.sgFiltroEmpresa;
            }
		}
}