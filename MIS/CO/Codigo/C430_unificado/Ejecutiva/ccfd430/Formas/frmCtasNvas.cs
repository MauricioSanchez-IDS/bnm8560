using Artinsoft.VB6.Gui; 
using Microsoft.VisualBasic; 
using System; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmCtasNvas
		: System.Windows.Forms.Form
		{
		
			private void  frmCtasNvas_Activated( Object eventSender,  EventArgs eventArgs)
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
								
								CORVAR.pszgblsql = "select (select convert(char(4), a.eje_prefijo)+ convert(char(2),a.gpo_banco)+ ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " replicate ('0', (select i.pgs_long_emp from MTCPGS01 i Where i.pgs_rep_prefijo = a.eje_prefijo ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and i.pgs_rep_banco = a.gpo_banco) - char_length(ltrim(rtrim(str(a.emp_num))))) + ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " ltrim(rtrim(str(a.emp_num))) + replicate ('0', (select i.pgs_long_eje from MTCPGS01 i ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " Where i.pgs_rep_prefijo = a.eje_prefijo and i.pgs_rep_banco = a.gpo_banco) - char_length(ltrim(rtrim(str(a.eje_num))))) + ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " ltrim(rtrim(str(a.eje_num))) + convert(char(1),a.eje_roll_over) + ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(char(1),a.eje_digit)) Cta, a.ths_limite_credito , ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " a.ths_nombre,isnull(b.eje_usuario_cam,'-') usuario,isnull(b.eje_fecha_alta,0) fecalta ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " From  MTCTHS01 a, MTCEJE01 b, MTCPGS01 c ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo*=b.eje_prefijo and a.gpo_banco*=b.gpo_banco ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num*= b.emp_num and a.eje_num*=b.eje_num and a.eje_prefijo=c.pgs_rep_prefijo ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco=c.pgs_rep_banco and c.pgs_tipo_prod='C'";
								int tempRefParam = 2;
								string tempRefParam2 = "0";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and ths_inicio_credito_aamm between " + Convert.ToString(DTPicInicial.Year) + CRSGeneral.sfncJustificar(Convert.ToString(DTPicInicial.Month), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam, ref tempRefParam2);
								int tempRefParam3 = 2;
								string tempRefParam4 = "0";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and " + Convert.ToString(DTPicFinal.Year) + CRSGeneral.sfncJustificar(Convert.ToString(DTPicFinal.Month), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam3, ref tempRefParam4);
								CORVAR.pszgblsql = CORVAR.pszgblsql + " order by a.eje_prefijo, a.gpo_banco,a.emp_num,a.eje_num ";
								
								
								//pszgblsql = "select (select convert(char(4), a.eje_prefijo)+ convert(char(2),a.gpo_banco)+  replicate ('0', (select i.pgs_long_emp from MTCPGS01 i Where i.pgs_rep_prefijo = a.eje_prefijo  and i.pgs_rep_banco = a.gpo_banco) - char_length(ltrim(rtrim(str(a.emp_num))))) +  ltrim(rtrim(str(a.emp_num))) + replicate ('0', (select i.pgs_long_eje from MTCPGS01 i  Where i.pgs_rep_prefijo = a.eje_prefijo and i.pgs_rep_banco = a.gpo_banco) - char_length(ltrim(rtrim(str(a.eje_num))))) +  ltrim(rtrim(str(a.eje_num))) + convert(char(1),a.eje_roll_over) +  convert(char(1),a.eje_digit)) Cta, a.ths_limite_credito ,  a.ths_nombre,isnull(b.eje_usuario_cam,'-') usuario,isnull(b.eje_fecha_alta,0) fecalta  From  MTCTHS01 a, MTCEJE01 b, MTCPGS01 c  where a.eje_prefijo*=b.eje_prefijo and a.gpo_banco*=b.gpo_banco  and a.emp_num*= b.emp_num and a.eje_num*=b.eje_num and a.eje_prefijo=c.pgs_rep_prefijo  and a.gpo_banco=c.pgs_rep_banco and c.pgs_tipo_prod='C' and ths_inicio_credito_aamm between 200412 and 200412 "
								//pszgblsql = pszgblsql & "order by a.eje_prefijo, a.gpo_banco,a.emp_num,a.eje_num"
								
								
								//           MsgBox pszgblsql
								
								adorst = new ADODB.Recordset();
								
								adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, -1);
								
								if (! adorst.BOF && ! adorst.EOF)
								{
									intFile = FileSystem.FreeFile();
									
									strfile = mdlParametros.sgPathFirmas + "RepCtasNvas" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
									//pszgblPathRepCrystal
									FileSystem.FileOpen(intFile, strfile, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
									
									int tempRefParam5 = 2;
									string tempRefParam6 = "0";
									int tempRefParam7 = 2;
									string tempRefParam8 = "0";
									StrCadena = new StringBuilder("Reporte de Cuentas Nuevas con Rango inicial " + Convert.ToString(DTPicInicial.Year) + CRSGeneral.sfncJustificar(Convert.ToString(DTPicInicial.Month), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam5, ref tempRefParam6) + " y Rango Final " + Convert.ToString(DTPicFinal.Year) + CRSGeneral.sfncJustificar(Convert.ToString(DTPicFinal.Month), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam7, ref tempRefParam8));
									FileSystem.PrintLine(intFile, StrCadena.ToString());
									StrCadena = new StringBuilder(" ");
									FileSystem.PrintLine(intFile, StrCadena.ToString());
									StrCadena = new StringBuilder(DateTime.Today.ToShortDateString());
									FileSystem.PrintLine(intFile, StrCadena.ToString());
									StrCadena = new StringBuilder(" ");
									FileSystem.PrintLine(intFile, StrCadena.ToString());
									int tempRefParam9 = 20;
									string tempRefParam10 = " ";
									StrCadena = new StringBuilder("Número de Cuenta       Línea de Crédito     Nombre del Ejecutivo     " + CRSGeneral.sfncJustificar(" ", CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam9, ref tempRefParam10) + "Número de Nómina     Fecha Alta");
									FileSystem.PrintLine(intFile, StrCadena.ToString());
									int tempRefParam11 = 130;
									string tempRefParam12 = "-";
									StrCadena = new StringBuilder(CRSGeneral.sfncJustificar("-", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam11, ref tempRefParam12));
									FileSystem.PrintLine(intFile, StrCadena.ToString());
									
									//sfncJustificar()
									while (! adorst.EOF)
										{
										
											
											int tempRefParam13 = 18;
											string tempRefParam14 = " ";
											StrCadena = new StringBuilder(CRSGeneral.sfncJustificar(Convert.ToString(adorst.Fields["Cta"].Value), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam13, ref tempRefParam14));
											int tempRefParam15 = 20;
											string tempRefParam16 = " ";
											StrCadena.Append(CRSGeneral.sfncJustificar(Convert.ToString(adorst.Fields["ths_limite_credito"].Value), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam15, ref tempRefParam16));
											int tempRefParam17 = 45;
											string tempRefParam18 = " ";
											StrCadena.Append("       " + CRSGeneral.sfncJustificar(Convert.ToString(adorst.Fields["ths_nombre"].Value), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam17, ref tempRefParam18));
											int tempRefParam19 = 20;
											string tempRefParam20 = " ";
											StrCadena.Append(CRSGeneral.sfncJustificar(Convert.ToString(adorst.Fields["usuario"].Value), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam19, ref tempRefParam20));
											int tempRefParam21 = 10;
											string tempRefParam22 = " ";
											StrCadena.Append(CRSGeneral.sfncJustificar(Convert.ToString(adorst.Fields["fecalta"].Value), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam21, ref tempRefParam22));
											
											FileSystem.PrintLine(intFile, StrCadena.ToString());
											
											adorst.MoveNext();
										}
									
									int tempRefParam23 = 130;
									string tempRefParam24 = "-";
									StrCadena = new StringBuilder(CRSGeneral.sfncJustificar("-", CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam23, ref tempRefParam24));
									FileSystem.PrintLine(intFile, StrCadena.ToString());
									
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
						
						string tempRefParam25 = "Tarjeta Corporativa.- cmdReporte_Click";
						if (MdlCambioMasivo.fnGetError(ref tempRefParam25))
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
					//ais-1248 chidalgo
                    bin = true;
					//DTPicFinal.MaxDate = DateTime.Now; //AIS-1248 echasiquiza
					//DTPicInicial.MaxDate = DateTime.Now; //AIS-1248 echasiquiza
					//UPGRADE_WARNING: (1037) Couldn't resolve default property of object DTPicFinal.Value.
					//DTPicFinal.Value = DateTime.Now; //AIS-1248 echasiquiza
					//UPGRADE_WARNING: (1037) Couldn't resolve default property of object DTPicInicial.Value.
					//DTPicInicial.Value = DateTime.Now; //AIS-1248 echasiquiza
					mdlParametros.gperPerfil.prHabilitaAcciones(frmCtasNvas.DefInstance);
			}
			private void  frmCtasNvas_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
        private static bool bin = true;
        private void frmCtasNvas_VisibleChanged(object sender, EventArgs e)
        {
            if (bin)
            {
                bin = false;
                DTPicFinal.MaxDate = DateTime.Now;
                DTPicInicial.MaxDate = DateTime.Now;
                DTPicFinal.Value = DateTime.Now;
                DTPicInicial.Value = DateTime.Now;
            }
        }
		}
}