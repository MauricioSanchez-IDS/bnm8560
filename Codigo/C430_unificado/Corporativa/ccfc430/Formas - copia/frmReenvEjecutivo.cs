using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
	internal partial class frmReenvEjecutivo
		: System.Windows.Forms.Form
		{
		
			private void  frmReenvEjecutivo_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			
			//Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
			clsDatosEjecutivo gdteEjeExists = null;
			
			//Variable global del objeto datos ejecutivo
			clsDatosEjecutivo gdteEjecutivo = null;
			
			//Variable para el dialogo
			clsDialogo gdlgDialogoS016 = null;
			clsDialogo gdlgDialogoS111 = null;
			
			colReenvioEjec colReenv_Eje = null;
			/*private OLERut.Conexion _cnxConexionRut = null;
			OLERut.Conexion cnxConexionRut
			{
				get
				{
					if (_cnxConexionRut == null)
					{
						_cnxConexionRut = new OLERut.Conexion();
					}
					return _cnxConexionRut;
				}
				set
				{
					_cnxConexionRut = value;
				}
			}*/
			 
			string sTipConsulta = String.Empty;
			//Variable para la tabla temporal, status de la alta
			
			
			private string fncValidaDatosS( mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
			{
					
					string result = String.Empty;
					if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS016)
					{
						if (gdteEjeExists.EjeNomGrabaS != gdteEjecutivo.EjeNomGrabaS)
						{
							result = "Nombre de Grabación";
						} else if (gdteEjeExists.EjeRfcRFC.RFCS != gdteEjecutivo.EjeRfcRFC.RFCS) { 
							result = "RFC";
						}
						
					} else if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS111) { 
						if (gdteEjeExists.EjeNomGrabaS != gdteEjecutivo.EjeNomGrabaS)
						{
							result = "Nombre";
						} else if (gdteEjeExists.EjeDomEnvioDMC.DomicilioS != gdteEjecutivo.EjeDomEnvioDMC.DomicilioS) { 
							result = "Calle";
						} else if (gdteEjeExists.EjeDomEnvioDMC.ColoniaS != gdteEjecutivo.EjeDomEnvioDMC.ColoniaS) { 
							result = "Colonia";
						} else if (gdteEjeExists.EjeDomEnvioDMC.PoblacionS != gdteEjecutivo.EjeDomEnvioDMC.PoblacionS) { 
							result = "Población";
						} else if (gdteEjeExists.EjeSexoS != gdteEjecutivo.EjeSexoS) { 
							result = "Sexo";
						} else if (gdteEjeExists.EjeTipoCuentaS != "       Básica       ") { 
							result = "Tipo de Cuenta";
						} else if (gdteEjeExists.EjeSucTransS != gdteEjecutivo.EjeSucTransS) { 
							result = "Sucursal";
						}
					}
					
					return result;
			}
			
			private string fncObtenErrorDialogoS( int ipError,  mdlConexiones.enuTipoSistema ipTipoSistema)
			{
					
					string result = String.Empty;
					string slSistema = String.Empty;
					string slMensaje = String.Empty;
					
					try
					{
							
							if (((int) ipTipoSistema) == ((int) mdlConexiones.enuTipoSistema.tsistSistemaTandem))
							{
								slSistema = CRSDialogo.cteTandem;
							} else if (((int) ipTipoSistema) == ((int) mdlConexiones.enuTipoSistema.tsistSistemaS111)) { 
								slSistema = CRSDialogo.cteS111;
							} else if (((int) ipTipoSistema) == ((int) mdlConexiones.enuTipoSistema.tsistSistemaS016)) { 
								slSistema = CRSDialogo.cteS016;
							}
							
							CORVAR.pszgblsql = "select";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " err_desc";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCERR01";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where err_cve = " + ipError.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and err_origen = '" + slSistema + "'";
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
								{
									slMensaje = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
								}
							} else
							{
								slMensaje = "No se encuentra registrado este Error en la base de datos.";
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
							
							return mdlParametros.fncValorOmisionV(slMensaje, "Error Desconocido");
						}
                        catch (Exception e)
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo  (ObtenErrorDialogo)",e );
							result = "Error Desconocido";
							this.Cursor = Cursors.Default;
							return result;
						}
					}
					return result;
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (fncEliminaEjecutivoRespB) seems to be dead code
			//private bool fncEliminaEjecutivoRespB()
			//{
					//
					//bool result = false;
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//CORVAR.pszgblsql = "delete ";
							//if (sTipConsulta == "MTCMSV01")
							//{
								//CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCMSV01 ";
							//} else
							//{
								//CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCIND01 ";
							//}
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "where eje_status_reg = 11";
							//
							//if (CORPROC2.Modifica_Registro() != 0)
							//{
								//result = true;
								//this.Cursor = Cursors.Default;
								//return result;
							//} else
							//{
								//MessageBox.Show("No se pudo eliminar el respaldo del ejecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								//result = false;
								//this.Cursor = Cursors.Default;
								//return result;
							//}
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (EliminaEjecutivoResp)");
							//result = false;
							//this.Cursor = Cursors.Default;
							//return result;
						//}
					//}
					//
					//return result;
			//}
			
			//UPGRADE_NOTE: (7001) The following declaration (fncConsultaEjecutivoM111B) seems to be dead code
			//private bool fncConsultaEjecutivoM111B()
			//{
					//
					//bool result = false;
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//CORVAR.pszgblsql = "select ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_num,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_roll_over,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_digit ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJE01 ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + gdteEjecutivo.EjeNumL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_nom_gra = '" + gdteEjecutivo.EjeNomGrabaS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";
							//
							//if (CORPROC2.Cuenta_Registros() >= 1)
							//{
								//result = true;
								//this.Cursor = Cursors.Default;
								//return result;
							//} else
							//{
								//MessageBox.Show("No se encontro el ejecutivo en el M111", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								//result = false;
								//this.Cursor = Cursors.Default;
								//return result;
							//}
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (ConsultaEjecutivoM111)");
							//result = false;
							//this.Cursor = Cursors.Default;
							//return result;
						//}
					//}
					//
					//return result;
			//}
			
			//UPGRADE_NOTE: (7001) The following declaration (fncActualizaCredAcumEmpB) seems to be dead code
			//private bool fncActualizaCredAcumEmpB()
			//{
					//
					//bool result = false;
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//    pszgblsql = "update MTCEMP01 "
							//    pszgblsql = pszgblsql & " set emp_acum_cred = "
							//    pszgblsql = pszgblsql & " (select isnull(sum(eje_limcred),0) "
							//    pszgblsql = pszgblsql & " from MTCEJE01 "
							//    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
							//    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
							//    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
							//    pszgblsql = pszgblsql & " and eje_num > 0 "
							//    pszgblsql = pszgblsql & " group by eje_prefijo, gpo_banco, emp_num),"
							//    pszgblsql = pszgblsql & " emp_usu_cam = '" & sgUserID & "' "
							//    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
							//    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
							//    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
							// Modif. 18/Jun/2007 Calc Lim Real
							//CORVAR.pszgblsql = "update MTCEMP01 ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_acum_cred = ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )), ";
							//    pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )), "
							//
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "' ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
							//
							//if (CORPROC2.Modifica_Registro() != 0)
							//{
								//result = true;
								//this.Cursor = Cursors.Default;
								//return result;
							//} else
							//{
								//MessageBox.Show("No se pudo actualizar el credito acumulado de la empresa: " + gdteEjecutivo.EjeEmpNumL.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								//result = false;
								//this.Cursor = Cursors.Default;
								//return result;
							//}
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (ActualizaCredAcumEmp)");
							//result = false;
							//this.Cursor = Cursors.Default;
							//return result;
						//}
					//}
					//
					//return result;
			//}
			
			//UPGRADE_NOTE: (7001) The following declaration (fncInsertaEjecutivoM111B) seems to be dead code
			//private bool fncInsertaEjecutivoM111B()
			//{
					//
					//bool result = false;
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//gdteEjecutivo.EjeCuentaBnxS = (StringsHelper.Format(gdteEjecutivo.EjeProductoPRD.PrefijoL, gdteEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(gdteEjecutivo.EjeProductoPRD.BancoL, gdteEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(gdteEjecutivo.EjeNumL, gdteEjecutivo.EjeProductoPRD.MascaraEjecutivoS) + gdteEjecutivo.EjeRolloverI.ToString().Trim() + gdteEjecutivo.EjeDigitI.ToString().Trim()).Trim();
							//
							//CORVAR.pszgblsql = "exec spAltaEjecutivo ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeProductoPRD.BancoL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeEmpNumL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeNumL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeRolloverI.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeDigitI.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeNomS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeRfcRFC.RFCS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeSueldoL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeNumNomS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeCentroCostS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeNivelI.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeNomGrabaS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomEnvioDMC.DomicilioS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomEnvioDMC.ColoniaS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomEnvioDMC.PoblacionS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "0,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeDomEnvioDMC.CPL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeTelDomS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeTelOfiS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeExtensionS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeFaxS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeLimCredL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeRegNumL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeEstatusS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeCuentaBnxS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeSexoS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeSucTransS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeSucPromS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeOrigenS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeActiSubactiS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.DomicilioS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.ColoniaS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.CiudadS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.PoblacionS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.EstadoEST.AbreviaturaS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeDomPartDMC.CPL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeEmailS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeCtaContableS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeGenPinPlaI.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeLimDisEfecL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeTipoCuentaS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeTipoFactS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeSkipPaymentL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeTablaMCCL.ToString() + ",";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeIndLimDispS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeIndCtaCtrlS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeNacionalidadS + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + CRSParametros.sgUserID + "',";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeTipoBloqueoI.ToString();
							//
							//if (CORPROC2.Modifica_Registro() != 0)
							//{
								//result = true;
								//this.Cursor = Cursors.Default;
								//return result;
							//} else
							//{
								//MessageBox.Show("No se pudo insertar el ejecutivo: " + gdteEjecutivo.EjeEmpNumL.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								//result = false;
								//this.Cursor = Cursors.Default;
								//return result;
							//}
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (InsertaEjecutivoM111)");
							//result = false;
							//this.Cursor = Cursors.Default;
							//return result;
						//}
					//}
					//
					//return result;
			//}
			
			private bool fncActualizaConsecutivoB()
			{
					
					bool result = false;
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							CORVAR.pszgblsql = "update MTCEMP01";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_con_eje = " + ((gdteEjecutivo.EjeNumL + 1).ToString()) + ",";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
							
							if (CORPROC2.Modifica_Registro() != 0)
							{
								result = true;
								this.Cursor = Cursors.Default;
								return result;
							} else
							{
								MessageBox.Show("No se pudo modificar el consecutivo de ejecutivo de la empresa: " + gdteEjecutivo.EjeEmpNumL.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								result = false;
								this.Cursor = Cursors.Default;
								return result;
							}
						}
                        catch (Exception e)
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo  (ActualizaConsecutivo)",e );
							result = false;
							this.Cursor = Cursors.Default;
							return result;
						}
					}
					
					return result;
			}
			
			private void  prActualizaEstatus( int lpEstatus)
			{
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							if (sTipConsulta == "")
							{
								return;
							}
							switch(lpEstatus)
							{
								case 3 : case 4 : case 12 : 
									if (sTipConsulta == "MTCMSV01")
									{
										CORVAR.pszgblsql = "update MTCMSV01";
									} else
									{
										CORVAR.pszgblsql = "update MTCIND01";
									} 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_num = " + gdteEjecutivo.EjeNumL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " ,eje_digit = " + gdteEjecutivo.EjeDigitI.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " ,eje_status_reg = " + lpEstatus.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'"; 
									 
									break;
								default:
									if (sTipConsulta == "MTCMSV01")
									{
										CORVAR.pszgblsql = "update MTCMSV01";
									} else
									{
										CORVAR.pszgblsql = "update MTCIND01";
									} 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_status_reg = " + lpEstatus.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString(); 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_nom_gra = '" + gdteEjecutivo.EjeNomGrabaS + "'"; 
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'"; 
									break;
							}
							
							if (CORPROC2.Modifica_Registro() != 0)
							{
								this.Cursor = Cursors.Default;
								return;
							} else
							{
								MessageBox.Show("No se actualizo el estatus del Ejecutivo en la tabla de Respaldo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								this.Cursor = Cursors.Default;
								return;
							}
							
							this.Cursor = Cursors.Default;
						}
                        catch (Exception e)
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo  (ActualizaEstatus)",e );
							this.Cursor = Cursors.Default;
							return;
						}
					}
					
			}
			
			//UPGRADE_NOTE: (7001) The following declaration (fncGrabaTablaRespB) seems to be dead code
			//private bool fncGrabaTablaRespB()
			//{
					//
					//bool result = false;
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//if (sTipConsulta == "MTCMSV01")
							//{
								//CORVAR.pszgblsql = "insert into MTCMSV01 ";
							//} else
							//{
								//CORVAR.pszgblsql = "insert into MTCIND01 ";
							//}
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "(eje_prefijo,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_roll_over,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nombre,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_rfc,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_sueldo,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num_nom,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_centro_c,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nivel,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nom_gra,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_calle,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_col,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_pob,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_edo,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_zp,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cp,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_dom,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_ofi,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ext,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_fax,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_limcred,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "reg_num,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cuenta_bnx,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_sexo,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_suc_trans,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_suc_prom,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_origen,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_acti_subacti,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_calle,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_col,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_ciu,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_pob,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_edo,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_cp,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_email,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cta_contable,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_gen_pin_pla,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_lim_dis_efec,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_cuenta,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_fac,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_skip_payment,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tabla_mcc,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ind_lim_disp,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ind_cta_ctrl,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nacionalidad,";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status_reg) ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "values (" + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeEmpNumL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeRolloverI.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeNomS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeSueldoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeNumNomS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeCentroCostS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeNivelI.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeNomGrabaS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomEnvioDMC.DomicilioS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomEnvioDMC.ColoniaS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomEnvioDMC.PoblacionS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeDomEnvioDMC.CPL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeTelDomS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeTelOfiS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeExtensionS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeFaxS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeLimCredL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeRegNumL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeEstatusS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeCuentaBnxS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeSexoS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeSucTransS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeSucPromS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeOrigenS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeActiSubactiS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.DomicilioS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.ColoniaS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.CiudadS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.PoblacionS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.EstadoEST.AbreviaturaS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeDomPartDMC.CPL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeEmailS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeCtaContableS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeGenPinPlaI.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeLimDisEfecL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeTipoCuentaS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeTipoFactS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeSkipPaymentL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeTablaMCCL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeIndLimDispS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeIndCtaCtrlS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeNacionalidadS + "'";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + ",0)";
							//
							//if (CORPROC2.Modifica_Registro() != 0)
							//{
								//result = true;
								//this.Cursor = Cursors.Default;
								//return result;
							//} else
							//{
								//MessageBox.Show("No se pudo insertar el registro en la tabla de respaldo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
								//result = false;
								//this.Cursor = Cursors.Default;
								//return result;
							//}
							//
							//this.Cursor = Cursors.Default;
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (GrabaTablaResp)");
							//result = false;
							//this.Cursor = Cursors.Default;
							//return result;
						//}
					//}
					//
					//return result;
			//}
			
			//UPGRADE_NOTE: (7001) The following declaration (fncObtenEjeNumB) seems to be dead code
			//private bool fncObtenEjeNumB()
			//{
					//bool result = false;
					//string slCuenta = String.Empty;
					//
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//CORVAR.pszgblsql = "select";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_con_eje";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
							//
							//if (CORPROC2.Obtiene_Registros() != 0)
							//{
								//
								//while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								//{
									//gdteEjecutivo.EjeNumL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
								//};
							//} else
							//{
								//MessageBox.Show("No se logro obtener el consecutivo de la empresa: " + StringsHelper.Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								//result = false;
								//this.Cursor = Cursors.Default;
								//return result;
							//}
							//CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							//
							//slCuenta = (StringsHelper.Format(gdteEjecutivo.EjeProductoPRD.PrefijoL, gdteEjecutivo.EjeProductoPRD.MascaraPrefijoS) + 
							//           StringsHelper.Format(gdteEjecutivo.EjeProductoPRD.BancoL, gdteEjecutivo.EjeProductoPRD.MascaraBancoS) + 
							//           StringsHelper.Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS) + 
							//           StringsHelper.Format(gdteEjecutivo.EjeNumL, gdteEjecutivo.EjeProductoPRD.MascaraEjecutivoS) + 
							//           gdteEjecutivo.EjeRolloverI.ToString()).Trim();
							//
							//gdteEjecutivo.EjeDigitI = CORPROC.Calcula_digito_verif(ref slCuenta);
							//result = true;
							//
							//this.Cursor = Cursors.Default;
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (ObtenEjeNum)");
							//result = false;
							//this.Cursor = Cursors.Default;
							//return result;
						//}
					//}
					//
					//return result;
			//}
			
			//UPGRADE_NOTE: (7001) The following declaration (fncVerificaCreditoB) seems to be dead code
			//private bool fncVerificaCreditoB()
			//{
					//
					//bool result = false;
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//EISSA 01.09.2004 - Cambio para realizar una excepción de un BIN
							//If gdteEjecutivo.EjeProductoPRD.PrefijoL = 4943 And gdteEjecutivo.EjeProductoPRD.BancoL = 88 Then
							//    If bfncExcepcionCredito = True Then
							//        fncVerificaCreditoB = True
							//        Screen.MousePointer = vbDefault
							//        Exit Function
							//    Else
							//if ((mdlEjecutivo.lmEmpCredAcum + gdteEjecutivo.EjeLimCredL) > mdlEjecutivo.lmEmpCredTot)
							//{
								//result = false;
								//MessageBox.Show("Se ha sobrepasado el crédito de la Empresa." + "\r\n" + 
								//                "Crédito dispuesto: " + Conversion.Str(mdlEjecutivo.lmEmpCredTot - mdlEjecutivo.lmEmpCredAcum), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								//this.Cursor = Cursors.Default;
								//return result;
							//} else
							//{
								//result = true;
								//this.Cursor = Cursors.Default;
								//return result;
							//}
							//    End If
							//
							//this.Cursor = Cursors.Default;
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (VerificaCredito)");
							//result = false;
							//this.Cursor = Cursors.Default;
							//return result;
						//}
					//}
					//
					//return result;
			//}
			
			//Private Function fncExcepcionCreditoB() As Boolean
			//
			//On Error GoTo ErrExcepcionCredito
			//   'EISSA 01.09.2004 - Cambio para realizar una excepción de un BIN
			//    If (gdteEjecutivo.EjeProductoPRD.PrefijoL = 4943 And gdteEjecutivo.EjeProductoPRD.BancoL = 88) Or (gdteEjecutivo.EjeProductoPRD.PrefijoL = 4859 And gdteEjecutivo.EjeProductoPRD.BancoL = 42) Then
			//        fncExcepcionCreditoB = True
			//    Else
			//        fncExcepcionCreditoB = False
			//    End If
			//
			//Exit Function
			//ErrExcepcionCredito:
			//    If Err.Number = 91 Then
			//        Err.Clear
			//        Resume Next
			//    Else
			//        prObtenError "frmReenvEjecutivo  (ExcepcionCredito)"
			//        Exit Function
			//    End If
			//End Function
			
			//UPGRADE_NOTE: (7001) The following declaration (prObtenCredEmp) seems to be dead code
			//private void  prObtenCredEmp()
			//{
					//
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//CORVAR.pszgblsql = "select";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cred_tot,";
							//    pszgblsql = pszgblsql & " emp_acum_cred"
							// Modif. 18/Jun/2007 Calc Lim Real
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = MTCEMP01.eje_prefijo ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = MTCEMP01.gpo_banco ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = MTCEMP01.emp_num ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c,MTCTHS01 d ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = MTCEMP01.eje_prefijo ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = MTCEMP01.gpo_banco ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = MTCEMP01.emp_num ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) as emp_acum_cred ";
							//    pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred "
							//
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							//CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
							//
							//if (CORPROC2.Obtiene_Registros() != 0)
							//{
								//
								//while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								//{
									//mdlEjecutivo.lmEmpCredTot = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
									//mdlEjecutivo.lmEmpCredAcum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
								//};
							//}
							//CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							//
							//this.Cursor = Cursors.Default;
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (ObtenCredEmp)");
							//mdlEjecutivo.lmEmpCredTot = 0;
							//mdlEjecutivo.lmEmpCredAcum = 0;
							//return;
						//}
					//}
					//
			//}
			
			//UPGRADE_NOTE: (7001) The following declaration (fncValidaInfB) seems to be dead code
			//private bool fncValidaInfB()
			//{
					//
					//bool result = false;
					//try
					//{
							//
							//this.Cursor = Cursors.WaitCursor;
							//
							//if (gdteEjecutivo.EjeNomS.Trim() == "")
							//{
								//result = false;
								//mdlEjecutivo.smValidaInf = "NOMBRE DEL EJECUTIVO";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeNomGrabaS.Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "NOMBRE DE GRABACIÓN";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeRfcRFC.RFCS.Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "RFC";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeLimCredL.ToString().Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "LIMITE DE CREDITO INCORRECTO";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeSexoS.Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "SEXO";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeDomEnvioDMC.DomicilioS.Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "CALLE Y NÚMERO";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeDomEnvioDMC.ColoniaS.Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "COLONIA";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeDomEnvioDMC.PoblacionS.Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "POBLACIÓN";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.EstadoS.Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "ESTADO";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeDomEnvioDMC.CPL.ToString().Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "CÓDIGO POSTAL";
								//this.Cursor = Cursors.Default;
								//return result;
							//} else if (gdteEjecutivo.EjeTelOfiS.Trim() == "") { 
								//result = false;
								//mdlEjecutivo.smValidaInf = "TEL. OFICINA";
								//this.Cursor = Cursors.Default;
								//return result;
							//}
							//
							//result = true;
							//
							//this.Cursor = Cursors.Default;
						//}
					//catch 
					//{
						//
						//if (Information.Err().Number == 91)
						//{
							////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							//throw new Exception("Migration Exception: 'Resume Next' not supported");
						//} else
						//{
							//CRSGeneral.prObtenError("frmReenvEjecutivo  (ValidaInf)");
							//result = false;
							//this.Cursor = Cursors.Default;
							//return result;
						//}
					//}
					//
					//return result;
			//}
			
			private bool fncValidarConsecutivoB()
			{
					bool result = false;
					int llConsecutivo = 0;
					int llConsecutivoTope = 0;
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							CORVAR.pszgblsql = "select";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_con_eje";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									llConsecutivo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)) - 1;
									llConsecutivoTope = StringsHelper.IntValue(new string('9', gdteEjecutivo.EjeProductoPRD.LongitudEjecutivoI));
								};
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
							if (llConsecutivo >= llConsecutivoTope)
							{
								result = false;
								MessageBox.Show("Se deberá crear una nueva empresa para los siguientes ejecutivos." + "\r\n" + 
								                "Se ha llegado al límite de " + (llConsecutivoTope + 1).ToString() + " tarjetahabientes.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								this.Cursor = Cursors.Default;
								return result;
							} else
							{
								result = true;
								this.Cursor = Cursors.Default;
								return result;
							}
							
							this.Cursor = Cursors.Default;
						}
                        catch (Exception e)
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo  (ValidarConsecutivo)",e );
							result = false;
							this.Cursor = Cursors.Default;
							return result;
						}
					}
					
					return result;
			}
			
			
			/*private bool fncVerificaConsultaB( mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
			{
					
					bool result = false;
					int ilResConS111 = 0;
					string slConS111 = String.Empty;
					string slCausaS111 = String.Empty;
					string slConsulta = String.Empty;
					string slCadena1 = String.Empty;
					string slCadena2 = String.Empty;
					string slCadena3 = String.Empty;
					string slFolio = String.Empty;
					string slCampo = String.Empty;
					int ilRespuestaEnvio = 0;
					string slFecAlta = String.Empty;
					string slFecModificacion = String.Empty;
					string slValidacion = String.Empty;
					string slRespuestaS016 = String.Empty;
					string slNombreGraba = String.Empty;
					string slRFC = String.Empty;
					string slDialogoConsulta = String.Empty;
					string slRespMensaje = String.Empty;
					string slDialogo = String.Empty;
					int ilcont = 0;
					
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS111)
							{ //***** CONSULTA S111 *****
								
								gdlgDialogoS111 = new clsDialogo();
								
								gdlgDialogoS111.prGeneraDlg(gdteEjecutivo, clsDialogo.enuTipoDialogo.tConsEjecutivoS111);
								
								slDialogo = gdlgDialogoS111.DialogoS;
								gdlgDialogoS111 = null;
								
								string tempRefParam = "S753-CONALTAS";
								ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
								Application.DoEvents();
								
								cnxConexionRut.Termina_Conexion();
								
								slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");
								
								if (ilRespuestaEnvio != 0)
								{
									prActualizaEstatus(7);
									MessageBox.Show("Error en el envio de la informacion.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
									result = false;
									this.Cursor = Cursors.Default;
									return result;
								} else
								{
									slCadena1 = Strings.Mid(slRespMensaje, 1243, 151).Trim();
									slCadena2 = Strings.Mid(slRespMensaje, 38, 371).Trim();
									slCadena3 = Strings.Mid(slRespMensaje, 1608, 31).Trim();
									
									gdteEjeExists = null;
									gdteEjeExists = new clsDatosEjecutivo();
									
									gdteEjeExists.EjeNomGrabaS = Strings.Mid(slCadena1, 1, 26).Trim();
									gdteEjeExists.EjeDomEnvioDMC.DomicilioS = Strings.Mid(slCadena1, 46, 35).Trim();
									gdteEjeExists.EjeDomEnvioDMC.ColoniaS = Strings.Mid(slCadena1, 81, 25).Trim();
									gdteEjeExists.EjeDomEnvioDMC.PoblacionS = Strings.Mid(slCadena1, 106, 19).Trim();
									
									switch(Strings.Mid(slCadena1, 138, 1).Trim())
									{
										case "1" : 
											gdteEjeExists.EjeTipoCuentaS = "       Básica       "; 
											break;
										case "2" : 
											gdteEjeExists.EjeTipoCuentaS = "      Adicional     "; 
											break;
										case "3" : 
											gdteEjeExists.EjeTipoCuentaS = "Básica con Adicional"; 
											break;
									}
									
									gdteEjeExists.EjeSucTransS = Strings.Mid(slCadena1, 139, 4).Trim();
									gdteEjeExists.EjeSexoS = Strings.Mid(slCadena1, 145, 1).Trim();
									slCausaS111 = Strings.Mid(slCadena3, 1, 19).Trim();
									slFecAlta = Strings.Mid(slCadena3, 20, 6).Trim();
									slFecModificacion = Strings.Mid(slCadena3, 26, 6).Trim();
									slValidacion = fncValidaDatosS(mdlEjecutivo.enuTipoAltaSistema.tasAltaS111);
									
									if (slValidacion == "")
									{
										result = true;
										this.Cursor = Cursors.Default;
										return result;
									} else
									{
										MessageBox.Show("Hay Inconsistencia de Datos en el S111 en el campo " + slValidacion, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
										result = false;
										this.Cursor = Cursors.Default;
										return result;
									}
								}
							} else
							{
							}
							
							this.Cursor = Cursors.Default;
						}
                        catch (Exception e)
					{
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo (VerificaConsultaS111)",e );
							result = false;
							this.Cursor = Cursors.Default;
							return result;
						}
					}
					
					return result;
			}
			*/

            private void ConsultaMTCMSV(Softtek.Util.Win.Spread.SpreadWrapper Grid)
			{
					string sDatos = String.Empty;
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							Grid.DisplayRowHeaders = false;
							colReenv_Eje.fncCargaDatosMTCMSV01B();
							
							Grid.Row = 1;
							Grid.Col = 1;
							Grid.Row2 = Grid.MaxRows;
							Grid.Col2 = Grid.MaxCols;
							Grid.BlockMode = true;
							Grid.Clear();
							Grid.BlockMode = false;
							Application.DoEvents();
							for (int iCont = 1; iCont <= colReenv_Eje.Count; iCont++)
							{
								Grid.SetText(1, iCont, colReenv_Eje[iCont].EjeProductoPRD.PrefijoL.ToString());
								Grid.SetText(2, iCont, colReenv_Eje[iCont].EjeProductoPRD.BancoL.ToString());
								Grid.SetText(3, iCont, colReenv_Eje[iCont].NumEmpL.ToString());
								Grid.SetText(4, iCont, colReenv_Eje[iCont].EjeNombreS);
								Grid.SetText(5, iCont, colReenv_Eje[iCont].EjeStatusRegI.ToString());
							}
							for (int iCont = 1; iCont <= 5; iCont++)
							{
								Grid.set_ColWidth(iCont, (int) Grid.get_MaxTextColWidth(iCont) * 3);
							}
							this.Cursor = Cursors.Default;
							
							if (colReenv_Eje.Count == 0)
							{
								cmdReenvio.Enabled = false;
							}
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo (ConsultaMTCMSV)",e );
							this.Cursor = Cursors.Default;
							return;
						}
					}
					
			}

            private void ConsultaMTCIND(Softtek.Util.Win.Spread.SpreadWrapper Grid, colReenvioEjec colReenvioEjecutivo)
			{
					string sDatos = String.Empty;
					
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							Grid.DisplayRowHeaders = false;
							colReenvioEjecutivo.fncCargaDatosMTCIND01B();
							
							Grid.Row = 1;
							Grid.Col = 1;
							Grid.Row2 = Grid.MaxRows;
							Grid.Col2 = Grid.MaxCols;
							Grid.BlockMode = true;
							Grid.Clear();
							Grid.BlockMode = false;
							Application.DoEvents();
							for (int iCont = 1; iCont <= colReenvioEjecutivo.Count; iCont++)
							{
								Grid.SetText(1, iCont, colReenvioEjecutivo[iCont].EjeProductoPRD.PrefijoL.ToString());
								Grid.SetText(2, iCont, colReenvioEjecutivo[iCont].EjeProductoPRD.BancoL.ToString());
								Grid.SetText(3, iCont, colReenvioEjecutivo[iCont].NumEmpL.ToString());
								Grid.SetText(4, iCont, colReenvioEjecutivo[iCont].EjeNombreS);
								Grid.SetText(5, iCont, colReenvioEjecutivo[iCont].EjeStatusRegI.ToString());
							}
							for (int iCont = 1; iCont <= 5; iCont++)
							{
								Grid.set_ColWidth(iCont,(int)Grid.get_MaxTextColWidth(iCont) * 3);
							}
							this.Cursor = Cursors.Default;
							
							if (colReenvioEjecutivo.Count == 0)
							{
								cmdReenvio.Enabled = false;
							}
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo (ConsultaMTCIND)",e );
							this.Cursor = Cursors.Default;
							return;
						}
					}
					
			}
			
			private void  cmdConsMasivo_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					try
					{
                        //AIS-541 NGONZALEZ
							colReenv_Eje = new colReenvioEjec();
							gdteEjecutivo = new clsDatosEjecutivo();                       
							ConsultaMTCMSV(gridRegistros); // REMEDIACIÓN JULIO2014
							if (colReenv_Eje.Count > 0)
							{
								cmdReenvio.Enabled = true;
								sTipConsulta = "MTCMSV01";
							} else
							{
								cmdReenvio.Enabled = false;
							}
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvioEjecutivo (cmdConsMasivo)",e );
							this.Cursor = Cursors.Default;
						}
					}
					
					
			}
			
			private void  cmdReenvio_Click( Object eventSender,  EventArgs eventArgs)
			{
					int iContOK = 0;
					
					try
					{
							iContOK = 0;
							sspnlPorcentaje.FloodPercent = 0;
							cmdConsIndividual.Enabled = false;
							cmdConsMasivo.Enabled = false;
							for (int iCont = 1; iCont <= colReenv_Eje.Count; iCont++)
							{
								if (fncReenvioEjecutivosB(iCont))
								{
									iContOK++;
								}
								sspnlPorcentaje.FloodPercent = Convert.ToInt16((iCont * 100) / ((double) colReenv_Eje.Count));
								Application.DoEvents();
							}
							if (colReenv_Eje.Count == iContOK)
							{
								MessageBox.Show("Se re enviaron todos los ejecutivos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
							} else
							{
								MessageBox.Show("Se re enviaron " + iContOK.ToString() + " ejecutivos de " + colReenv_Eje.Count.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							cmdReenvio.Enabled = false;
							prLimpiaGrid();
							cmdConsIndividual.Enabled = true;
							cmdConsMasivo.Enabled = true;
							sspnlPorcentaje.FloodPercent = 0;
							sTipConsulta = "";
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo (cmdReenvio)",e );
							this.Cursor = Cursors.Default;
							cmdReenvio.Enabled = false;
							prLimpiaGrid();
							cmdConsIndividual.Enabled = true;
							cmdConsMasivo.Enabled = true;
							return;
						}
					}
					
			}
			private void  prLimpiaGrid()
			{
					
					try
					{

                            gridRegistros.Row = 1; // REMEDIACIÓN JULIO2014 aqui se utilizaba fpgridRegistros
							gridRegistros.Col = 1;
							gridRegistros.Row2 = gridRegistros.MaxRows;
							gridRegistros.Col2 = gridRegistros.MaxCols;
							gridRegistros.BlockMode = true;
							gridRegistros.Clear();
							gridRegistros.BlockMode = false;
							Application.DoEvents();
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo (LimpiaGrid)",e );
							this.Cursor = Cursors.Default;
							return;
						}
					}
					
			}
			
			private void  cmdSalir_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					try
					{
                        //AIS-541 NGONZALEZ
							colReenv_Eje = null;
							this.Close();
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvEjecutivo (cmdSalir)",e );
							this.Cursor = Cursors.Default;
							return;
						}
					}
					
			}
			
			private void  cmdConsIndividual_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					try
                    {//AIS-541 NGONZALEZ
					    colReenv_Eje = null;
                        //AIS-541 NGONZALEZ
							colReenv_Eje = new colReenvioEjec();
                            ConsultaMTCIND(gridRegistros, colReenv_Eje); // REMEDIACIÓN JULIO2014 aqui se utilizaba fpgridRegistros
							if (colReenv_Eje.Count > 0)
							{
								cmdReenvio.Enabled = true;
								sTipConsulta = "MTCIND01";
							} else
							{
								cmdReenvio.Enabled = false;
							}
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvioEjecutivo (cmdConsIndividual)",e );
							this.Cursor = Cursors.Default;
						}
					}
					
					
			}
			private bool fncVerificaCreditoAcumuladoB()
			{
					//Lo que hace esta funcion es devolver verdadero en caso de que el credito acumulado de
					//la empresa más el crédito del ejecutivo no sobrepasen o igualen el crédito total de la
					//empresa.
					bool result = false;
					int llEmpCredTot = 0;
					int llEmpCredAcum = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cred_tot,";
					//pszgblsql = pszgblsql & " emp_acum_cred"
					// Modif. 18/Jun/2007 Calc Lim Real
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = MTCEMP01.eje_prefijo ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = MTCEMP01.gpo_banco ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = MTCEMP01.emp_num ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c,MTCTHS01 d ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = MTCEMP01.eje_prefijo ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = MTCEMP01.gpo_banco ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = MTCEMP01.emp_num ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) as emp_acum_cred ";
					//pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred "
					
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							llEmpCredTot = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							llEmpCredAcum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
						};
						
						//EISSA 01.09.2004 - Cambio para realizar una excepción de un BIN
						//If gdteEjecutivo.EjeProductoPRD.PrefijoL = 4943 And gdteEjecutivo.EjeProductoPRD.BancoL = 88 Then
						//   If bfncExcepcionCredito = True Then
						//      fncVerificaCreditoAcumuladoB = True
						//   Else
						if ((llEmpCredAcum + gdteEjecutivo.EjeLimCredL) > llEmpCredTot)
						{
							result = false;
							MessageBox.Show("Se ha sobrepasado el crédito de la Empresa." + "\r\n" + 
							                "Crédito dispuesto: " + Conversion.Str(mdlEjecutivo.lmEmpCredTot - mdlEjecutivo.lmEmpCredAcum), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						} else
						{
							result = true;
						}
						//   End If
					} else
					{
						result = false;
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					this.Cursor = Cursors.Default;
					return result;
			}
			
			private bool fncReenvioEjecutivosB( int iIndxItem)
			{
					bool result = false;
					string slExistePath = String.Empty;
					string slDialogoFirma = String.Empty;
					string slRespuestaFirma = String.Empty;
					string slCadenaFirma = String.Empty;
					string slRespAccFirma = String.Empty;
					string slMensajeFirma = String.Empty;
					int ilPosFirma = 0;
					int llID = 0;
					int Estatus = 0;
					string smValidaInf = String.Empty;
					//Dim slTablaTemporal         As String
					//Dim lEjeReenvio As clsReenvioTarjetahabientes
					clsReenvioTarjetahabientes lEjeReenvio = null;
					clsAltaTarjetahabiente lAltaEje = null;
					//Dim slTablaTemporal As String
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							gdteEjecutivo = null;
							gdlgDialogoS016 = null;
							gdlgDialogoS111 = null;
							
							gdteEjecutivo = new clsDatosEjecutivo();
							gdlgDialogoS016 = new clsDialogo();
							gdlgDialogoS111 = new clsDialogo();
							
							//*** Datos de ejecutivo
							gdteEjecutivo.EjeActiSubactiS = colReenv_Eje[iIndxItem].EjeActSubActiS;
							gdteEjecutivo.EjeCentroCostS = colReenv_Eje[iIndxItem].EjeCenCosS;
							gdteEjecutivo.EjeCtaContableS = colReenv_Eje[iIndxItem].EjeCtaContableS;
							gdteEjecutivo.EjeCuentaBnxS = colReenv_Eje[iIndxItem].EjeCtaBmxS;
							gdteEjecutivo.EjeDigitI = colReenv_Eje[iIndxItem].EjeDigitoI;
							gdteEjecutivo.EjeDomEnvioDMC = colReenv_Eje[iIndxItem].EjeDomEnvioDMC;
							gdteEjecutivo.EjeDomPartDMC = colReenv_Eje[iIndxItem].EjeDomPartDMC;
							gdteEjecutivo.EjeEmailS = colReenv_Eje[iIndxItem].EjeEmailS;
							gdteEjecutivo.EjeEmpNumL = colReenv_Eje[iIndxItem].NumEmpL;
							gdteEjecutivo.EjeExtensionS = colReenv_Eje[iIndxItem].EjeExtS;
							gdteEjecutivo.EjeFaxS = colReenv_Eje[iIndxItem].EjeFaxS;
							gdteEjecutivo.EjeGenPinPlaI = colReenv_Eje[iIndxItem].EjeGenPinPlaI;
							gdteEjecutivo.EjeIndCtaCtrlS = colReenv_Eje[iIndxItem].EjeIndCtasCtrlS;
							gdteEjecutivo.EjeLimCredL = colReenv_Eje[iIndxItem].EjeLimCredL;
							gdteEjecutivo.EjeLimDisEfecL = colReenv_Eje[iIndxItem].EjeLimDisEfecL;
							gdteEjecutivo.EjeNacionalidadS = colReenv_Eje[iIndxItem].EjeNacionalS;
							gdteEjecutivo.EjeNivelI = colReenv_Eje[iIndxItem].EjeNivelI;
							gdteEjecutivo.EjeNomGrabaS = colReenv_Eje[iIndxItem].EjeNomGrabaS;
							gdteEjecutivo.EjeNomS = colReenv_Eje[iIndxItem].EjeNombreS;
							gdteEjecutivo.EjeNumL = colReenv_Eje[iIndxItem].EjeNumeroL;
							gdteEjecutivo.EjeNumNomS = colReenv_Eje[iIndxItem].EjeNumNominaS;
							gdteEjecutivo.EjeRegNumL = colReenv_Eje[iIndxItem].RegNumL;
							gdteEjecutivo.EjeRfcRFC = colReenv_Eje[iIndxItem].EjeRFC;
							gdteEjecutivo.EjeSexoS = colReenv_Eje[iIndxItem].EjeSexoS;
							gdteEjecutivo.EjeSkipPaymentL = colReenv_Eje[iIndxItem].EjeSkipPaymentL;
							gdteEjecutivo.EjeSueldoL = colReenv_Eje[iIndxItem].EjeSueldoL;
							gdteEjecutivo.EjeTablaMCCL = colReenv_Eje[iIndxItem].EjeTablaMCCL;
							gdteEjecutivo.EjeTelDomS = colReenv_Eje[iIndxItem].EjeTelDomS;
							gdteEjecutivo.EjeTelOfiS = colReenv_Eje[iIndxItem].EjeTelOficS;
							gdteEjecutivo.EjeTipoFactS = colReenv_Eje[iIndxItem].EjeTipoFactS;
							//*** Datos que no se requieren por que son fijos.
							//gdteEjecutivo.EjeRolloverI = colReenv_Eje(iIndxItem).EjeRolloverI
							//gdteEjecutivo.EjeOrigenS = colReenv_Eje(iIndxItem).EjeOrigenS
							//gdteEjecutivo.EjeIndLimDispS = colReenv_Eje(iIndxItem).EjeIndLimDispS
							//gdteEjecutivo.EjeEstatusS = colReenv_Eje(iIndxItem).EjeEstatusS
							//gdteEjecutivo.EjeSucPromS = colReenv_Eje(iIndxItem).EjeSucPromS
							//gdteEjecutivo.EjeSucTransS = colReenv_Eje(iIndxItem).EjeSucTransS
							//gdteEjecutivo.EjeTipoCuentaS = colReenv_Eje(iIndxItem).EjeTipoCtaS
							//*** Datos de empresa
							gdteEjecutivo.EjeCuentaReferenciaS = colReenv_Eje[iIndxItem].CuentaReferenciaS;
							gdteEjecutivo.EjeCuentaS = colReenv_Eje[iIndxItem].CuentaS;
							gdteEjecutivo.EjeDiaCorteI = colReenv_Eje[iIndxItem].EmpDiaCorteI;
							gdteEjecutivo.EjeEmpSectorI = colReenv_Eje[iIndxItem].EmpSectorI;
							gdteEjecutivo.EjeEmpTipoEnvioS = colReenv_Eje[iIndxItem].EmpTipoEnvioS;
							gdteEjecutivo.EjeEmpTipoFactS = colReenv_Eje[iIndxItem].EmpTipoFactS;
							gdteEjecutivo.EjeEmpTipoProductoS = colReenv_Eje[iIndxItem].EmpTipoProductoS;
							gdteEjecutivo.EjeTipoBloqueoI = colReenv_Eje[iIndxItem].EjeTipoBloqueoI;
							
							gdteEjecutivo.EjeAtencionA = colReenv_Eje[iIndxItem].EjeAtencionA; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
							gdteEjecutivo.EjePersona = colReenv_Eje[iIndxItem].EjePersona; //FSWB NR 20070222
							
							Estatus = colReenv_Eje[iIndxItem].EjeStatusRegI;
							if (sTipConsulta.Trim() == "")
							{
								return false;
							}
							if (Estatus == 0)
							{
								if (fncValidarConsecutivoB())
								{
									if (fncVerificaCreditoAcumuladoB())
									{
										//         Set lEjeReenvio = New clsReenvioTarjetahabientes
										//         Set lEjeReenvio.EjegdteEjecutivo = gdteEjecutivo
										//         lEjeReenvio.Temporal = sTipConsulta
										//         lEjeReenvio.EjeStatusS = 0
										//         fncReenvioEjecutivosB = Not lEjeReenvio.Resultado
										//         Set lEjeReenvio = Nothing
										lEjeReenvio = new clsReenvioTarjetahabientes();
										lAltaEje = new clsAltaTarjetahabiente();
										lAltaEje.EjegdteEjecutivo = gdteEjecutivo;
										//slTablaTemporal = "MTCIND01"
										lAltaEje.Temporal = sTipConsulta;
										lEjeReenvio.mObjetoAlta = lAltaEje;

										//lEjeReenvio.EjeStatusS = "0";
                                        lEjeReenvio.EjeStatusSComdrv = "0";

										result = ! lEjeReenvio.resultado;
										lAltaEje = null;
										lEjeReenvio = null;
									} else
									{
										result = false;
									}
								}
							} else
							{
								if (Estatus == 1 || Estatus == 2 || Estatus == 3 || Estatus == 4 || Estatus == 5 || Estatus == 7)
								{
									//      Set lEjeReenvio = New clsReenvioTarjetahabientes
									//      Set lEjeReenvio.EjegdteEjecutivo = gdteEjecutivo
									//      lEjeReenvio.Temporal = sTipConsulta
									//      lEjeReenvio.EjeStatusS = Estatus
									//      fncReenvioEjecutivosB = Not lEjeReenvio.Resultado
									//      Set lEjeReenvio = Nothing
									lEjeReenvio = new clsReenvioTarjetahabientes();
									lAltaEje = new clsAltaTarjetahabiente();
									lAltaEje.EjegdteEjecutivo = gdteEjecutivo;
									//slTablaTemporal = "MTCIND01"
									lAltaEje.Temporal = sTipConsulta;
									lEjeReenvio.mObjetoAlta = lAltaEje;

                                    //lEjeReenvio.EjeStatusS = Estatus.ToString(); //16092013
                                    lEjeReenvio.EjeStatusSComdrv = Estatus.ToString();//Aqui que va a pasar con los que no tengan Estatu 5

									result = ! lEjeReenvio.resultado;
									lAltaEje = null;
									lEjeReenvio = null;
								} else
								{
									result = false;
								}
							}
							this.Cursor = Cursors.Default;
							
						}
                        catch (Exception e)
					{
						
						
						if (Information.Err().Number == 91)
						{
							//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
							throw new Exception("Migration Exception: 'Resume Next' not supported");
						} else
						{
							CRSGeneral.prObtenError("frmReenvioEjecutivo (ReenvioEjecutivos)",e );
							result = false;
							this.Cursor = Cursors.Default;
							return result;
						}
					}
					
					return result;
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					gdteEjecutivo = new clsDatosEjecutivo();
					cmdReenvio.Enabled = false;
					sTipConsulta = "";
					
			}
			
			private void  frmReenvEjecutivo_Closed( Object eventSender,  EventArgs eventArgs)
			{
                    //AIS-541 NGONZALEZ
					colReenv_Eje = null ;
					
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}