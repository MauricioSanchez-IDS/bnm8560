using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsReenvioEmpresas
	{
		
		//*****************************************************************************
		//**                                                                         **
		//**                     EISSA / Banamex - Sistemas                          **
		//**                                                                         **
		//**       -----------------------------------------------------------       **
		//**                                                                         **
		//**       Descripción:  Lleva el control de los Estados dentro de           **
		//**                     la alta de los Ejecutivos                           **
		//**                                                                         **
		//**                                                                         **
		//**                                                                         **
		//**       Responsables: Marcos Garcia Cruz                                  **
		//**                                                                         **
		//**       Fecha de Modificación:  11 de Septiembre del 2003                 **
		//**                                                                         **
		//**             NOTA: Esta forma esta hecha en Visual Basic 6.0             **
		//**                                                                         **
		//*****************************************************************************
		
		
		//Dim gObjetoAlta As Object
		clsAltaEmpresa gObjetoAlta = null;
		clsDatosEjecutivo gdteEjecutivo = null;
		bool bmError = false;
		string smTablaTemporal = String.Empty;
		//Variables para las conexiones
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
		
		
		//Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
		clsDatosEjecutivo gdteEjeExists = null;
		
		//Variable para el dialogo
		clsDialogo gdlgDialogoS016 = null;
		clsDialogo gdlgDialogoS111 = null;
		const string smArchivoLog = "F:\\Documentos\\mgarcia\\VisualBasic\\";
		//UPGRADE_NOTE: (7001) The following declaration (fncGrabaTablaRespB) seems to be dead code
		//private bool fncGrabaTablaRespB()
		//{
				//
				//bool result = false;
				//try
				//{
						//
						//Cursor.Current = Cursors.WaitCursor;
						//
						//CORVAR.pszgblsql = "insert into " + smTablaTemporal + " ";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "(eje_prefijo,";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco,";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num,";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num,";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_roll_over,";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_digit,";
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
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status_reg,";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_bloqueo) ";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "values (" + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeEmpNumL.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeNumL.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeRolloverI.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeDigitI.ToString();
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
						//CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeTipoBloqueoI.ToString() + ")";
						//
						//if (CORPROC2.Modifica_Registro() != 0)
						//{
							//result = true;
							//Cursor.Current = Cursors.Default;
							//return result;
						//} else
						//{
							//MessageBox.Show("No se pudo insertar el registro en la tabla de respaldo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							//result = false;
							//Cursor.Current = Cursors.Default;
							//return result;
						//}
						//
						//Cursor.Current = Cursors.Default;
					//}
				//catch 
				//{
					//
					//if (Information.Err().Number == 91)
					//{
						//throw new Exception("Migration Exception: 'Resume Next' not supported");
					//} else
					//{
						//CRSGeneral.prObtenError("frmEjecutivo (GrabaTablaResp)");
						//result = false;
						//Cursor.Current = Cursors.Default;
						//return result;
					//}
				//}
				//
				//return result;
		//}
		//UPGRADE_NOTE: (7001) The following declaration (fncValidaDatosS) seems to be dead code
		//private string fncValidaDatosS( mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
		//{
				//string result = String.Empty;
				//result = "";
				//if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS016)
				//{
					//if (gdteEjeExists.EjeNomGrabaS != gdteEjecutivo.EjeNomGrabaS)
					//{
						//result = "Nombre de Grabación";
					//} else if (gdteEjeExists.EjeRfcRFC.RFCS != gdteEjecutivo.EjeRfcRFC.RFCS) { 
						//result = "RFC";
					//}
					//
				//} else if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS111) { 
					//if (gdteEjeExists.EjeNomGrabaS != gdteEjecutivo.EjeNomGrabaS)
					//{
						//result = "Nombre de Grabación";
					//} else if (gdteEjeExists.EjeRfcRFC.RFCS != gdteEjecutivo.EjeRfcRFC.RFCS.Substring(0, Math.Min(gdteEjecutivo.EjeRfcRFC.RFCS.Length, 10))) { 
						//result = "RFC";
					//}
					//
				//}
				//
				//return result;
		//}
		
		//UPGRADE_NOTE: (7001) The following declaration (fncVerificaCreditoAcumuladoB) seems to be dead code
		//private bool fncVerificaCreditoAcumuladoB()
		//{
				//Lo que hace esta funcion es devolver verdadero en caso de que el credito acumulado de
				//la empresa más el crédito del ejecutivo no sobrepasen o igualen el crédito total de la
				//empresa.
				//bool result = false;
				//int llEmpCredTot = 0;
				//int llEmpCredAcum = 0;
				//
				//Cursor.Current = Cursors.WaitCursor;
				//
				//CORVAR.pszgblsql = "select";
				//CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cred_tot,";
				//pszgblsql = pszgblsql & " emp_acum_cred"
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
				//pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred "
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
						//llEmpCredTot = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
						//llEmpCredAcum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
					//};
					//
					//EISSA 01.09.2004 - Cambio para realizar una excepción de un BIN
					//If gdteEjecutivo.EjeProductoPRD.PrefijoL = 4943 And gdteEjecutivo.EjeProductoPRD.BancoL = 88 Then
					//    If bfncExcepcionCredito = True Then
					//        fncVerificaCreditoAcumuladoB = True
					//    Else
					//if ((llEmpCredAcum + gdteEjecutivo.EjeLimCredL) > llEmpCredTot)
					//{
						//result = false;
						//MessageBox.Show("Se ha sobrepasado el crédito de la Empresa." + "\r\n" + 
						//                "Crédito dispuesto: " + Conversion.Str(mdlEjecutivo.lmEmpCredTot - mdlEjecutivo.lmEmpCredAcum), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					//} else
					//{
						//result = true;
					//}
					//   End If
				//} else
				//{
					//result = false;
				//}
				//CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				//Cursor.Current = Cursors.Default;
				//return result;
		//}
		//UPGRADE_NOTE: (7001) The following declaration (fncActualizaEstatusTemporalB) seems to be dead code
		//private bool fncActualizaEstatusTemporalB( int ipEstatus)
		//{
				//ipEstatus es el estado dentro del diagrama de transicion que le corresponde y se graba dentro de
				//MTCIND01
				//bool result = false;
				//Cursor.Current = Cursors.WaitCursor;
				//
				//CORVAR.pszgblsql = "update " + smTablaTemporal + " ";
				//CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_status_reg = " + ipEstatus.ToString().Trim();
				//CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
				//CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
				//CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
				//CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_nom_gra = '" + gdteEjecutivo.EjeNomGrabaS + "'";
				//CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";
				//if (CORPROC2.Modifica_Registro() != 0)
				//{
					//Cursor.Current = Cursors.Default;
					//return true;
				//} else
				//{
					//MessageBox.Show("No se actualizó el estatus del Ejecutivo en la tabla de Respaldo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//result = false;
					//Cursor.Current = Cursors.Default;
					//return result;
				//}
				//return result;
		//}
		//UPGRADE_NOTE: (7001) The following declaration (fncEnviaDialogoLocalS) seems to be dead code
		//private string fncEnviaDialogoLocalS(ref  string spRespuesta,  bool bpReAlta)
		//{
				//envia el diálogo tanto al S016 como al S111
				//
				//si va a ser una alta al S111 porque ya se encuentra dentro del S016 se
				//pone igIndAltaCteOk a 1, si no se encuentra en ninguno de los dos
				//se pone igIndAltaCteOk a 0
				//
				//string result = String.Empty;
				//if (bpReAlta)
				//{
					//mdlParametros.igIndAltaCteOK = 1;
				//} else
				//{
					//mdlParametros.igIndAltaCteOK = 0;
				//}
				//
				//gdlgDialogoS111 = new clsDialogo();
				//gdlgDialogoS111.prGeneraDlg(gdteEjecutivo, clsDialogo.enuTipoDialogo.tAltaEjecutivoS111);
				//Cursor.Current = Cursors.WaitCursor;
				//string slDialogo = gdlgDialogoS111.DialogoS;
				//gdlgDialogoS111 = null;
				//cnxConexionRut.Termina_Conexion();
				//if (! cnxConexionRut.Inicia_Conexion())
				//{
					//MessageBox.Show("No hay conexion al S111. Avise a sistemas.", "Conexión S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//Cursor.Current = Cursors.Default;
					//return "ErrorConexion";
				//}
				//string tempRefParam = "S753-CONALTAS";
				//int ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
				//Application.DoEvents();
				//cnxConexionRut.Termina_Conexion();
				//string slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");
				//if (ilRespuestaEnvio != 0)
				//{
					//MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
					//result = "ErrorConexion";
					//spRespuesta = slRespMensaje;
					//return result;
				//}
				//if (slRespMensaje.IndexOf("error on RUT") >= 0)
				//{
					//MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
					//result = "ErrorRut";
					//spRespuesta = slRespMensaje;
					//return result;
				//}
				//string slClaveResultadoTransaccion = Strings.Mid(slRespMensaje, 32, 2);
				//string slClaveTransaccionAlta = Strings.Mid(slRespMensaje, 34, 4);
				//string slRespuestaTransaccion = Strings.Mid(slRespMensaje, 38, 30);
				//string slTextoError = Strings.Mid(slRespMensaje, 68, 60).Trim();
				//
				//spRespuesta = slTextoError;
				//if (slClaveResultadoTransaccion == "00" || slClaveResultadoTransaccion == "02" || slClaveResultadoTransaccion == "05" || slClaveResultadoTransaccion == "06" || slClaveResultadoTransaccion == "35")
				//{
					//return slClaveResultadoTransaccion;
				//}
				//if (slClaveResultadoTransaccion == "07")
				//{
					//
					//if (slTextoError.ToUpper().IndexOf("OK DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR TIMEOUT DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR COMUNICACION CON UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DATOS DE CALL DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO HAY DRIVERS EN DCRED") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN CSI-DESTINO") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN VALOR DE TIMEOUT") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 31 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 32 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 33 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DCRED EN CAMPO COMPUTER") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO CALIFICADO....") >= 0 || slTextoError.ToUpper().IndexOf("ERROR CODIGO RESPUESTA DESCONOCIDO") >= 0)
					//{
						//result = slClaveResultadoTransaccion + "error";
					//} else
					//{
						//result = slClaveResultadoTransaccion + "errorx";
					//}
					//Cursor.Current = Cursors.Default;
					//return result;
				//}
				//return slClaveResultadoTransaccion;
		//}
		//UPGRADE_NOTE: (7001) The following declaration (fncActualizaConsecutivoB) seems to be dead code
		//private bool fncActualizaConsecutivoB()
		//{
				//
				//bool result = false;
				//try
				//{
						//
						//Cursor.Current = Cursors.WaitCursor;
						//
						//CORVAR.pszgblsql = "update MTCEMP01";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_con_eje = " + ((gdteEjecutivo.EjeNumL + 1).ToString()) + ",";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
						//
						//if (CORPROC2.Modifica_Registro() != 0)
						//{
							//result = true;
							//Cursor.Current = Cursors.Default;
							//return result;
						//} else
						//{
							//MessageBox.Show("No se pudo modificar el consecutivo de ejecutivo de la empresa: " + gdteEjecutivo.EjeEmpNumL.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							//result = false;
							//Cursor.Current = Cursors.Default;
							//return result;
						//}
					//}
				//catch 
				//{
					//
					//if (Information.Err().Number == 91)
					//{
						//throw new Exception("Migration Exception: 'Resume Next' not supported");
					//} else
					//{
						//CRSGeneral.prObtenError("frmEjecutivo (ActualizaConsecutivo)");
						//result = false;
						//Cursor.Current = Cursors.Default;
						//return result;
					//}
				//}
				//
				//return result;
		//}
		
		private void  prEstado0()
		{
			//En este estado aún no se ha dado de alta al ejecutivo dentro del S016 ni en el S111 ni el
			//el c430.
			//Cuando fncEnviaDialogoLocal regresa 0 se registró exitosamente en el S016 y en el S111
			string slRespuesta = String.Empty;
			string slResultado = String.Empty;
			bmError = true;

            if (gObjetoAlta.fncObtenNumB()) //desomentó yuria 18/03/09
            {
          
            if (gObjetoAlta.fncValidaNumEmpresa(gObjetoAlta.illNumEmpresa))
            {
				slResultado = gObjetoAlta.fncEnviaDialogoLocalPrimeraS(ref slRespuesta, false);
				if (slResultado == "00")
				{
					if (gObjetoAlta.fncGrabaTablaRespB())
					{
                        //if (gObjetoAlta.fncActualizaConsecutivoB())
                        //{
							//imEstado = 1
							if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
							{
								bmError = false;
								prEstado1();
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
                        //} 
                        //else
                        //{
                        //    MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo actualizar el consecutivo.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
					} else
					{
						MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo grabar el respaldo.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else
				{
					if (slResultado == "05" || slResultado == "07alta")
					{
						if (gObjetoAlta.fncGrabaTablaRespB())
						{
                            //if (gObjetoAlta.fncActualizaConsecutivoB())
                            //{
								//imEstado = 5
								if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
								{
									MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
									bmError = false;
								} else
								{
									MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
                            //} 
                            //else
                            //{
                            //    MessageBox.Show("Ya se encuentra registrado en S016 pero no se actualizó el consecutivo.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
						} else
						{
							MessageBox.Show("Ya se encuentra dentro del S016, pero no se pudo grabar el respaldo.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "02" || slResultado == "35" || slResultado == "06" || slResultado == "07error")
						{
							MessageBox.Show(slRespuesta, "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
							//            If slResultado = "06" And slRespuesta = "CONTRATO A DAR DE ALTA YA EXISTE" Then
							//                gObjetoAlta.fncActualizaConsecutivoB
							//            End If
							
						} else
						{
							if (slResultado.Trim() == "ErrorConexion")
							{
								MessageBox.Show("Error en la conexion", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
								gObjetoAlta.prRegistraLog(slRespuesta); //Comentar en produccion
							} else
							{
								//Mandar la información a un archivo log con los datalles de
								//del ejecutivo.
								gObjetoAlta.prRegistraLog(slRespuesta);
							}
						}
					}
				}
            }
          }//descomentó yuria 18marz2009
		}
		
		private void  prEstado1()
		{
			//En este estado ya el ejecutivo se encuentra registrado dentro del S016 pero aún no se sabe
			//si se encuentra registrado en el S111
			bmError = true;
			string slResultado = gObjetoAlta.fncConsultaS111S();
			if (slResultado == "ErrorConexion")
			{
				MessageBox.Show("Error en la conexion.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//imEstado = 1
				if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
				{
					MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				if (slResultado == "NoCoinciden")
				{
					//Manda un error de alerta.
					//imEstado = 2
					gObjetoAlta.prRegistraLog(slResultado);
					if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
					{
						prEstado2();
					} else
					{
						MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else
				{
					if (slResultado == "Coinciden")
					{
						//imEstado = 2
						if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
						{
							bmError = false;
							prEstado2();
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "NoEncontrado")
						{
							//imEstado = 5
							if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
							{
								MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
				}
			}
		}
		private void  prEstado2()
		{
			//En este estado ya hay certidumbre de que el ejecutivo se encuentra tanto en el S016 como en
			//el S111
			bmError = true;
			
			string slResultado = gObjetoAlta.fncConsultac430S();
			if (slResultado == "Coinciden")
			{
				//imEstado = 3
				MessageBox.Show("La Empresa ya se encontraba registrada.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (! gObjetoAlta.fncActualizaEstatusTemporalB(3))
				{
					MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return;
			}
			if (gObjetoAlta.fncInsertaM111BEMP())
			{
				//imEstado = 3
				if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
				{
					bmError = false;
					mdlEmpresa.intReenvio = 0;
					prEstado3();
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				//imEstado = 2
				if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
				{
					MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		
		private void  prEstado3()
		{
			//En este estado el ejecutivo ya se encuentra dentro del S016 y el S111 pero no se sabe con certeza
			//si se encuentra dentro del c430 o no.
			bmError = true;
			string slResultado = gObjetoAlta.fncConsultac430S();
			if (slResultado == "ErrorConexion")
			{
				//imEstado = 3
				if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
				{
					MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				if (slResultado == "NoEsta")
				{
					//imEstado = 2
					if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
					{
						MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} else
					{
						MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else
				{
					if (slResultado == "NoCoinciden")
					{
						//imEstado = 2
						if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
						{
							MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							mdlEmpresa.intReenvio = 1;
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "Coinciden")
						{
							//imEstado = 4
							if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
							{
								bmError = false;
								prEstado8();
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
				}
			}
		}
		private void  prEstado4()
		{
			//En este estado el ejecutivo ya se encuentra dentro del S016, S111 y el c430.
			bmError = true;
			if (! gObjetoAlta.fncActualizaCredAcumB())
			{
				//imEstado = 4
				if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
				{
					MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				//imEstado = 7
				if (gObjetoAlta.fncActualizaEstatusTemporalB(7))
				{
					bmError = false;
					prEstado7();
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 7 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void  prEstado5()
		{
			//En este estado el ejecutivo ya se encuentra dentro del S016 pero no se encuentra dentro del
			//S111 ni dentro del c430.
			string slRespuesta = String.Empty;
			
			bmError = true;
			string slResultado = gObjetoAlta.fncEnviaDialogoLocalSegundaS(ref slRespuesta, true);
			if (slResultado == "00")
			{
				//imEstado = 1
				if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
				{
					bmError = false;
					prEstado1();
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				if (slResultado == "02" || slResultado == "05")
				{
					MessageBox.Show(slRespuesta, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//imEstado = 5
					if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
					{
						MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} else
					{
						MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else
				{
					//Hay que implementar una función que grabe en un archivo log el detalle del
					//tarjetahabitente.
					gObjetoAlta.prRegistraLog(slRespuesta);
					//imEstado = 5
					if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
					{
						MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} else
					{
						MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		private void  prEstado7()
		{
			//En este estado los datos del ejecutivo ya se encuentran dentro del S016, S111, c430 y ya se encuentra
			//calculado el crédito acumulado de la empresa.
			bmError = true;
			if (! gObjetoAlta.fncEliminaRespB())
			{
				MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else
			{
				bmError = false;
				gObjetoAlta.prRegistraCliente();
				gObjetoAlta.prMensajeEmpresaAlta();
			}
		}
		private void  prEstado8()
		{
			//Ya se verificó que esté dentro del c430 Empresas, ya se encuentran registrados en S016 y S111.
			bmError = true;
			
			string slResultado = gObjetoAlta.fncConsultac430EjeS();
			if (slResultado == "Coinciden")
			{
				MessageBox.Show("El ejecutivo0 para esta empresa ya se encontraba registrado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (! gObjetoAlta.fncActualizaEstatusTemporalB(9))
				{
					MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return;
			}
			if (gObjetoAlta.fncInsertaM111BEJE0())
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(9))
				{
					bmError = false;
					prEstado9();
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
				{
					MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void  prEstado9()
		{
			//Ya se encuentran en S016, S111 y c430 Empresas, ya se registró dentro de c430 Tarjetahabientes pero
			//no se ha verificado que esté ahí.
			bmError = true;
			string slResultado = gObjetoAlta.fncConsultac430EjeS();
			if (slResultado == "ErrorConexion")
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(9))
				{
					MessageBox.Show("Para terminar de registrar la alta de la empresa , reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				if (slResultado == "NoEsta")
				{
					if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
					{
						MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} else
					{
						MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} else
				{
					if (slResultado == "NoCoinciden")
					{
						//imEstado = 8
						if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
						{
							MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						} else
						{
							MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} else
					{
						if (slResultado == "Coinciden")
						{
							//imEstado = 10
							if (gObjetoAlta.fncActualizaEstatusTemporalB(10))
							{
								bmError = false;
								prEstado10();
							} else
							{
								MessageBox.Show("No se pudo actualizar el estado 10 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
				}
			}
		}
		private void  prEstado10()
		{
			//Ya se encuentran registrados dentro de S016, S111, c430 Tarjetahabientes y se ha creado el Directorio
			//de la Empresa.
			bmError = true;
			if (! gObjetoAlta.fncCrea_Directorio_EmpB())
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(10))
				{
					MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 10 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
				{
					bmError = false;
					prEstado4();
				} else
				{
					MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

        private void prEstadoComDrv0()
        {
            //En este estado aún no se ha dado de alta al ejecutivo dentro del S016 ni en el S111 ni el
            //el c430.
            //Cuando fncEnviaDialogoLocal regresa 0 se registró exitosamente en el S016 y en el S111
            string slRespuesta = String.Empty;
            string slResultado = String.Empty;
            bmError = true;
            if (gObjetoAlta.fncObtenNumB())
            {
                slResultado = gObjetoAlta.fncEnviaDialogoLocalPrimeraSComdrv(ref slRespuesta, false);
                if (slResultado == "00")
                {
                    if (gObjetoAlta.fncGrabaTablaRespB())
                    {
                        //if (gObjetoAlta.fncActualizaConsecutivoB())
                        //{
                            //imEstado = 1
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                            {
                                bmError = false;
                                prEstadoComDrv1();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo actualizar el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Ya se encuentra dentro del S016 y S111, pero no se pudo grabar el respaldo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    if (Strings.Mid(slResultado, 1, 4) == "5566" && Strings.Mid(slResultado, 6, 2) == "01")
                    {

                        if (Strings.Mid(slResultado, 45, 2) == "05" || Strings.Mid(slResultado, 45, 6) == "07alta" ||
                            Strings.Mid(slResultado, 45, 7) == "07error")
                        {
                            if (gObjetoAlta.fncGrabaTablaRespB())
                            {
                                //if (gObjetoAlta.fncActualizaConsecutivoB())
                                //{
                                    //imEstado = 5
                                    if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
                                    {
                                        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bmError = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Ya se encuentra registrado en S016 pero no se actualizó el consecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //}
                            }
                            else
                            {
                                MessageBox.Show("Ya se encuentra dentro del S016, pero no se pudo grabar el respaldo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (Strings.Mid(slResultado, 45, 2) == "02" || Strings.Mid(slResultado, 45, 2) == "35" ||
                                Strings.Mid(slResultado, 45, 2) == "06")
                            {
                                MessageBox.Show(slRespuesta, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                if (slResultado.Trim() == "ErrorConexion")
                                {
                                    MessageBox.Show("Error en la conexion", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else
                                {
                                    //Mandar la información a un archivo log con los datalles de
                                    //del ejecutivo.
                                    gObjetoAlta.prRegistraLog(slRespuesta);
                                }
                            }
                        }
                    }


                }
            }
        }

        private void prEstadoComDrv1()
        {
            //En este estado ya el ejecutivo se encuentra registrado dentro del S016 pero aún no se sabe
            //si se encuentra registrado en el S111
            bmError = true;
            string slCuenta = String.Empty;
            string slConsulta = String.Empty;
            //string slResultado = gObjetoAlta.fncConsultaS111S();
            string slResultado = gObjetoAlta.fncConsultaS111SComDrv(slCuenta, out slConsulta);
            if (slResultado == "ErrorConexion")
            {
                MessageBox.Show("Error en la conexion.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //imEstado = 1
                if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                {
                    MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 1 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (slResultado == "NoCoinciden")
                {
                    //Manda un error de alerta.
                    //imEstado = 2
                    gObjetoAlta.prRegistraLog(slResultado);
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                    {
                        prEstadoComDrv2();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (slResultado == "Coinciden")
                    {
                        //imEstado = 2
                        if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                        {
                            bmError = false;
                            prEstadoComDrv2();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (slResultado == "NoEncontrado")
                        {
                            //imEstado = 5
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
                            {
                                MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void prEstadoComDrv2()
        {
            //En este estado ya hay certidumbre de que el ejecutivo se encuentra tanto en el S016 como en
            //el S111
            bmError = true;

            string slResultado = gObjetoAlta.fncConsultac430S();
            if (slResultado == "Coinciden")
            {
                //imEstado = 3
                MessageBox.Show("La Empresa ya se encontraba registrada.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!gObjetoAlta.fncActualizaEstatusTemporalB(3))
                {
                    MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            if (gObjetoAlta.fncInsertaM111BEMP())
            {
                //imEstado = 3
                if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
                {
                    bmError = false;
                    mdlEmpresa.intReenvio = 0;
                    prEstadoComDrv3();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //imEstado = 2
                if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                {
                    MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void prEstadoComDrv3()
        {
            //En este estado el ejecutivo ya se encuentra dentro del S016 y el S111 pero no se sabe con certeza
            //si se encuentra dentro del c430 o no.
            bmError = true;
            string slResultado = gObjetoAlta.fncConsultac430S();
            if (slResultado == "ErrorConexion")
            {
                //imEstado = 3
                if (gObjetoAlta.fncActualizaEstatusTemporalB(3))
                {
                    MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 3 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (slResultado == "NoEsta")
                {
                    //imEstado = 2
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                    {
                        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (slResultado == "NoCoinciden")
                    {
                        //imEstado = 2
                        if (gObjetoAlta.fncActualizaEstatusTemporalB(2))
                        {
                            MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            mdlEmpresa.intReenvio = 1;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (slResultado == "Coinciden")
                        {
                            //imEstado = 4
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
                            {
                                bmError = false;
                                prEstadoComDrv8();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void prEstadoComDrv4()
        {
            //En este estado el ejecutivo ya se encuentra dentro del S016, S111 y el c430.
            bmError = true;
            if (!gObjetoAlta.fncActualizaCredAcumB())
            {
                //imEstado = 4
                if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
                {
                    MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //imEstado = 7
                if (gObjetoAlta.fncActualizaEstatusTemporalB(7))
                {
                    bmError = false;
                    prEstadoComDrv7();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 7 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void prEstadoComDrv5()
        {
            //En este estado el ejecutivo ya se encuentra dentro del S016 pero no se encuentra dentro del
            //S111 ni dentro del c430.
            string slRespuesta = String.Empty;

            bmError = true;
            string slResultado = gObjetoAlta.fncEnviaDialogoLocalSegundaSComdrv(ref slRespuesta, true);
            if (slResultado == "00")
            {
                //imEstado = 1
                if (gObjetoAlta.fncActualizaEstatusTemporalB(1))
                {
                    bmError = false;
                    prEstadoComDrv1();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 2 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (Strings.Mid(slResultado, 1, 4) == "5566" && Strings.Mid(slResultado, 6, 2) == "01")
                {
                    if (Strings.Mid(slResultado, 45, 2) == "02" || Strings.Mid(slResultado, 45, 2) == "05")
                    {
                        MessageBox.Show(slRespuesta, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //imEstado = 5
                        if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
                        {
                            MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //Hay que implementar una función que grabe en un archivo log el detalle del
                        //tarjetahabitente.
                        gObjetoAlta.prRegistraLog(slRespuesta);
                        //MsgBox slRespuesta, vbCritical + vbOKOnly, "Tarjeta Corporativa"
                        //imEstado = 5
                        if (gObjetoAlta.fncActualizaEstatusTemporalB(5))
                        {
                            MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado 5 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

            }
        }

        private void prEstadoComDrv7()
        {
            //En este estado los datos del ejecutivo ya se encuentran dentro del S016, S111, c430 y ya se encuentra
            //calculado el crédito acumulado de la empresa.
            bmError = true;
            if (!gObjetoAlta.fncEliminaRespB())
            {
                MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bmError = false;
                gObjetoAlta.prRegistraCliente();
                gObjetoAlta.prMensajeEmpresaAlta();
            }
        }

        private void prEstadoComDrv8()
        {
            //Ya se verificó que esté dentro del c430 Empresas, ya se encuentran registrados en S016 y S111.
            bmError = true;

            string slResultado = gObjetoAlta.fncConsultac430EjeS();
            if (slResultado == "Coinciden")
            {
                MessageBox.Show("El ejecutivo0 para esta empresa ya se encontraba registrado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!gObjetoAlta.fncActualizaEstatusTemporalB(9))
                {
                    MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            if (gObjetoAlta.fncInsertaM111BEJE0())
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(9))
                {
                    bmError = false;
                    prEstadoComDrv9();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
                {
                    MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void prEstadoComDrv9()
        {
            //Ya se encuentran en S016, S111 y c430 Empresas, ya se registró dentro de c430 Tarjetahabientes pero
            //no se ha verificado que esté ahí.
            bmError = true;
            string slResultado = gObjetoAlta.fncConsultac430EjeS();
            if (slResultado == "ErrorConexion")
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(9))
                {
                    MessageBox.Show("Para terminar de registrar la alta de la empresa , reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 9 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (slResultado == "NoEsta")
                {
                    if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
                    {
                        MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (slResultado == "NoCoinciden")
                    {
                        //imEstado = 8
                        if (gObjetoAlta.fncActualizaEstatusTemporalB(8))
                        {
                            MessageBox.Show("Para terminar de registrar la alta de la empresa, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el estado 8 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (slResultado == "Coinciden")
                        {
                            //imEstado = 10
                            if (gObjetoAlta.fncActualizaEstatusTemporalB(10))
                            {
                                bmError = false;
                                prEstadoComDrv10();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el estado 10 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void prEstadoComDrv10()
        {
            //Ya se encuentran registrados dentro de S016, S111, c430 Tarjetahabientes y se ha creado el Directorio
            //de la Empresa.
            bmError = true;
            if (!gObjetoAlta.fncCrea_Directorio_EmpB())
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(10))
                {
                    MessageBox.Show("Para terminar de registrar la alta del ejecutivo, reenviese.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 10 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (gObjetoAlta.fncActualizaEstatusTemporalB(4))
                {
                    bmError = false;
                    prEstadoComDrv4();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado 4 en Temporal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


		public string EjeStatusS
		{
			set
			{
				switch(value.Trim())
				{
					case "0" : 
						//imEstado = 0 
						prEstado0(); 
						break;
					case "1" : 
						//imEstado = 1 
						prEstado1(); 
						break;
					case "2" : 
						//imEstado = 2 
						prEstado2(); 
						break;
					case "3" : 
						//imEstado = 3 
						prEstado3(); 
						break;
					case "4" : 
						//imEstado = 4 
						prEstado4(); 
						break;
					case "5" : 
						//imEstado = 5 
						prEstado5(); 
						break;
					case "7" : 
						//imEstado = 7 
						prEstado7(); 
						break;
					case "8" : 
						//imEstado = 8 
						prEstado8(); 
						break;
					case "9" : 
						//imEstado = 9 
						prEstado9(); 
						break;
					case "10" : 
						//imEstado = 10 
						prEstado10(); 
						break;
					default:
						//imEstado = -1 
						break;
				}
				
			}
		}

        public string EjeStatusSComDrv
        {
            set
            {
                switch (value.Trim())
                {
                    case "0":
                        //imEstado = 0 
                        prEstadoComDrv0();
                        break;
                    case "1":
                        //imEstado = 1 
                        prEstadoComDrv1();
                        break;
                    case "2":
                        //imEstado = 2 
                        prEstadoComDrv2();
                        break;
                    case "3":
                        //imEstado = 3 
                        prEstadoComDrv3();
                        break;
                    case "4":
                        //imEstado = 4 
                        prEstadoComDrv4();
                        break;
                    case "5":
                        //imEstado = 5 
                        prEstadoComDrv5();
                        break;
                    case "7":
                        //imEstado = 7 
                        prEstadoComDrv7();
                        break;
                    case "8":
                        //imEstado = 8 
                        prEstadoComDrv8();
                        break;
                    case "9":
                        //imEstado = 9 
                        prEstadoComDrv9();
                        break;
                    case "10":
                        //imEstado = 10 
                        prEstadoComDrv10();
                        break;
                    //case "20":
                    //imEstado = 20 
                    //prEstadoComDrv20();
                    //break;
                    default:
                        //imEstado = -1 
                        break;
                }

            }
        }
		

		public bool resultado
		{
			get
			{
				return bmError;
			}
		}
		
		
		public clsAltaEmpresa mObjetoAlta
		{
			set
			{
				if (Information.IsReference(value))
				{
					gObjetoAlta = value;
				} else
				{
					gObjetoAlta = null;
				}
			}
		}
		
		
		~clsReenvioEmpresas(){
			gObjetoAlta = null;
		}
}
}