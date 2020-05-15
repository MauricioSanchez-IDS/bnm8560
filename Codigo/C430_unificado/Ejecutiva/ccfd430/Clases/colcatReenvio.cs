using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
    //AIS-1157 NGONZALEZ
	internal class colcatReenvio
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		public bool fncCargaDatosMTCIND01()
		{
			int emp_num = 0;
			int eje_num = 0;
			int eje_roll_over = 0;
			int eje_digit = 0;
			string eje_nombre = String.Empty;
			clsRFC eje_rfc = null;
			int eje_sueldo = 0;
			string eje_num_nom = String.Empty;
			string eje_centro_c = String.Empty;
			int eje_nivel = 0;
			string eje_nom_gra = String.Empty;
			clsDomicilio eje_dom_part = null;
			string eje_tel_dom = String.Empty;
			string eje_tel_ofi = String.Empty;
			string eje_ext = String.Empty;
			string eje_fax = String.Empty;
			int eje_limcred = 0;
			int reg_num = 0;
			string eje_status = String.Empty;
			string eje_cuenta_bnx = String.Empty;
			string eje_sexo = String.Empty;
			string eje_suc_trans = String.Empty;
			string eje_suc_prom = String.Empty;
			string eje_origen = String.Empty;
			string eje_acti_subacti = String.Empty;
			clsDomicilio eje_dom_envio = null;
			string eje_email = String.Empty;
			string eje_cta_contable = String.Empty;
			int eje_gen_pin_pla = 0;
			int eje_lim_dis_efec = 0;
			string eje_tipo_cuenta = String.Empty;
			string eje_tipo_fac = String.Empty;
			CheckState eje_skip_payment = (CheckState) 0;
			int eje_tabla_mcc = 0;
			string eje_ind_lim_disp = String.Empty;
			string eje_ind_cta_ctrl = String.Empty;
			string eje_nacionalidad = String.Empty;
			int eje_status_reg = 0;
			int emp_sector = 0;
			string emp_tipo_envio = String.Empty;
			string emp_tipo_fac = String.Empty;
			string emp_tipo_producto = String.Empty;
			int emp_dia_corte = 0;
			string cuenta = String.Empty;
			string cuenta_referencia = String.Empty;
			
			try
			{
					
					//pszgblsql = "select "
					//pszgblsql = pszgblsql & "b.emp_sector, "
					//pszgblsql = pszgblsql & "b.emp_tipo_envio, "
					//pszgblsql = pszgblsql & "b.emp_tipo_fac, "
					//pszgblsql = pszgblsql & "b.emp_tipo_producto, "
					//pszgblsql = pszgblsql & "b.emp_dia_corte"
					//pszgblsql = pszgblsql & "from MTCEMP01 b"
					//pszgblsql = pszgblsql & " where b.eje_prefijo = " & gprdProducto.PrefijoL
					//pszgblsql = pszgblsql & " and b.gpo_banco = " & gprdProducto.BancoL
					
					CORVAR.pszgblsql = "select ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_roll_over,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_digit,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_nombre,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_rfc,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_sueldo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_num_nom,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_centro_c,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_nivel,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_nom_gra,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_calle,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_col,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_pob,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_edo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_cp,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_zp,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tel_dom,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tel_ofi,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_ext,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_fax,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_limcred,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.reg_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_status,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_cuenta_bnx,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_sexo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_suc_trans,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_suc_prom,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_origen,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_acti_subacti,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_dom_calle,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_dom_col,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_dom_ciu,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_dom_pob,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_dom_edo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_dom_cp,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_email,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_cta_contable,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_gen_pin_pla,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_lim_dis_efec,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tipo_cuenta,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tipo_fac,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_skip_payment,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tabla_mcc,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_ind_lim_disp,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_ind_cta_ctrl,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_nacionalidad,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_status_reg, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "b.emp_sector, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "b.emp_tipo_envio, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "b.emp_tipo_fac, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "b.emp_tipo_producto, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "b.emp_dia_corte ";
					
					//pszgblsql = pszgblsql & "from MTCIND02 a"
					//pszgblsql = pszgblsql & " where a.eje_prefijo = " & gprdProducto.PrefijoL
					//pszgblsql = pszgblsql & " and a.gpo_banco = " & gprdProducto.BancoL
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCIND02 a, MTCEMP01 b";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo = b.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = b.emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							if (VBSQL.SqlData(CORVAR.hgblConexion, 1) == "")
							{
								emp_num = 0;
							} else
							{
								emp_num = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 2) == "")
							{
								eje_num = 0;
							} else
							{
								eje_num = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 3) == "")
							{
								eje_roll_over = 0;
							} else
							{
								eje_roll_over = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 4) == "")
							{
								eje_digit = 0;
							} else
							{
								eje_digit = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
							}
							eje_nombre = VBSQL.SqlData(CORVAR.hgblConexion, 5);
							eje_rfc = new clsRFC();
							eje_rfc.RFCS = VBSQL.SqlData(CORVAR.hgblConexion, 6);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 7) == "")
							{
								eje_sueldo = 0;
							} else
							{
								eje_sueldo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 7));
							}
							eje_num_nom = VBSQL.SqlData(CORVAR.hgblConexion, 8);
							eje_centro_c = VBSQL.SqlData(CORVAR.hgblConexion, 9);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 10) == "")
							{
								eje_nivel = 0;
							} else
							{
								eje_nivel = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 10));
							}
							eje_nom_gra = VBSQL.SqlData(CORVAR.hgblConexion, 11);
							//inicia domicilio
							eje_dom_part = new clsDomicilio();
							eje_dom_part.DomicilioS = VBSQL.SqlData(CORVAR.hgblConexion, 12);
							eje_dom_part.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 13);
							eje_dom_part.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 14);
							eje_dom_part.EstadoEST.EstadoS = VBSQL.SqlData(CORVAR.hgblConexion, 15);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 16) == "")
							{
								eje_dom_part.CPL = 0;
							} else
							{
								eje_dom_part.CPL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 16));
							}
							eje_dom_part.CiudadS = VBSQL.SqlData(CORVAR.hgblConexion, 17);
							//termina domicilio. ¿es particular?
							eje_tel_dom = VBSQL.SqlData(CORVAR.hgblConexion, 18);
							eje_tel_ofi = VBSQL.SqlData(CORVAR.hgblConexion, 19);
							eje_ext = VBSQL.SqlData(CORVAR.hgblConexion, 20);
							eje_fax = VBSQL.SqlData(CORVAR.hgblConexion, 21);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 22) == "")
							{
								eje_limcred = 0;
							} else
							{
								eje_limcred = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 22));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 23) == "")
							{
								reg_num = 0;
							} else
							{
								reg_num = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 23));
							}
							eje_status = VBSQL.SqlData(CORVAR.hgblConexion, 24);
							eje_cuenta_bnx = VBSQL.SqlData(CORVAR.hgblConexion, 25);
							eje_sexo = VBSQL.SqlData(CORVAR.hgblConexion, 26);
							eje_suc_trans = VBSQL.SqlData(CORVAR.hgblConexion, 27);
							eje_suc_prom = VBSQL.SqlData(CORVAR.hgblConexion, 28);
							eje_origen = VBSQL.SqlData(CORVAR.hgblConexion, 29);
							eje_acti_subacti = VBSQL.SqlData(CORVAR.hgblConexion, 30);
							//inicia domicilio
							eje_dom_envio = new clsDomicilio();
							eje_dom_envio.DomicilioS = VBSQL.SqlData(CORVAR.hgblConexion, 31);
							eje_dom_envio.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 32);
							eje_dom_envio.CiudadS = VBSQL.SqlData(CORVAR.hgblConexion, 33);
							eje_dom_envio.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 34);
							eje_dom_envio.EstadoEST.EstadoS = VBSQL.SqlData(CORVAR.hgblConexion, 35);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 36) == "")
							{
								eje_dom_envio.CPL = 0;
							} else
							{
								eje_dom_envio.CPL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 36));
							}
							//Termina domicilio. ¿es de envio?
							eje_email = VBSQL.SqlData(CORVAR.hgblConexion, 37);
							eje_cta_contable = VBSQL.SqlData(CORVAR.hgblConexion, 38);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 39) == "")
							{
								eje_gen_pin_pla = 0;
							} else
							{
								eje_gen_pin_pla = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 39));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 40) == "")
							{
								eje_lim_dis_efec = 0;
							} else
							{
								eje_lim_dis_efec = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 40));
							}
							eje_tipo_cuenta = VBSQL.SqlData(CORVAR.hgblConexion, 41);
							eje_tipo_fac = VBSQL.SqlData(CORVAR.hgblConexion, 42);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 43) == "")
							{
								eje_skip_payment = CheckState.Unchecked;
							} else
							{
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								eje_skip_payment = (CheckState) Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 43));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 44) == "")
							{
								eje_tabla_mcc = 0;
							} else
							{
								eje_tabla_mcc = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 44));
							}
							eje_ind_lim_disp = VBSQL.SqlData(CORVAR.hgblConexion, 45);
							eje_ind_cta_ctrl = VBSQL.SqlData(CORVAR.hgblConexion, 46);
							eje_nacionalidad = VBSQL.SqlData(CORVAR.hgblConexion, 47);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 48) == "")
							{
								eje_status_reg = 0;
							} else
							{
								eje_status_reg = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 48));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 49) == "")
							{
								emp_sector = 0;
							} else
							{
								emp_sector = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 49));
							}
							emp_tipo_envio = VBSQL.SqlData(CORVAR.hgblConexion, 50);
							emp_tipo_fac = VBSQL.SqlData(CORVAR.hgblConexion, 51);
							emp_tipo_producto = VBSQL.SqlData(CORVAR.hgblConexion, 52);
							if (VBSQL.SqlData(CORVAR.hgblConexion, 53) == "")
							{
								emp_dia_corte = 1;
							} else
							{
								emp_dia_corte = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 53));
							}
							
							cuenta_referencia = "";
							cuenta = "";
							
							this.Add(mdlParametros.gprdProducto, emp_num, eje_num, eje_roll_over, eje_digit, eje_nombre, eje_rfc, eje_sueldo, eje_num_nom, eje_centro_c, eje_nivel, eje_nom_gra, eje_dom_envio, eje_dom_part, eje_tel_dom, eje_tel_ofi, eje_ext, eje_fax, eje_limcred, reg_num, eje_status, eje_cuenta_bnx, eje_sexo, eje_suc_trans, eje_suc_prom, eje_origen, eje_acti_subacti, eje_email, eje_cta_contable, eje_gen_pin_pla, eje_lim_dis_efec, eje_tipo_cuenta, eje_tipo_fac, eje_skip_payment, eje_tabla_mcc, eje_ind_lim_disp, eje_ind_cta_ctrl, eje_nacionalidad, cuenta, emp_dia_corte, cuenta_referencia, emp_tipo_envio, emp_tipo_fac, emp_tipo_producto, emp_sector);
						};
					} else
					{
						MessageBox.Show("No se encontro ningun Ejecutivo que se necesite reenviar", Application.ProductName);
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				
				
				CRSGeneral.prObtenError(this.GetType().Name + "(CargaReenvioEje)",e );
				return false;
			}
			
			return false;
		}
		
		public clsDatosEjecutivo Add( clsProducto EjeProductoPRD,  int EjeEmpNumL,  int EjeNumL,  int EjeRolloverI,  int EjeDigitI,  string EjeNomS,  clsRFC EjeRfcRFC,  int EjeSueldoL,  string EjeNumNomS,  string EjeCentroCostS,  int EjeNivelI,  string EjeNomGrabaS,  clsDomicilio EjeDomEnvioDMC,  clsDomicilio EjeDomPartDMC,  string EjeTelDomS,  string EjeTelOfiS,  string EjeExtensionS,  string EjeFaxS,  int EjeLimCredL,  int EjeRegNumL,  string EjeEstatusS,  string EjeCuentaBnxS,  string EjeSexoS,  string EjeSucTransS,  string EjeSucPromS,  string EjeOrigenS,  string EjeActiSubactiS,  string EjeEmailS,  string EjeCtaContableS,  int EjeGenPinPlaI,  int EjeLimDisEfecL,  string EjeTipoCuentaS,  string EjeTipoFactS,  CheckState EjeSkipPaymentL,  int EjeTablaMCCL,  string EjeIndLimDispS,  string EjeIndCtaCtrlS,  string EjeNacionalidadS,  string EjeCuentaS,  int EjeDiaCorteI,  string EjeCuentaReferenciaS,  string EjeEmpTipoEnvioS,  string EjeEmpTipoFactS,  string EjeEmpTipoProductoS,  int EjeEmpSectorI, ref  string sKey)
		{
			
			//create a new object
			clsDatosEjecutivo objNewMember = new clsDatosEjecutivo();
			
			
			//set the properties passed into the method
			if (Information.IsReference(EjeProductoPRD))
			{
				objNewMember.EjeProductoPRD = EjeProductoPRD;
			} else
			{
				objNewMember.EjeProductoPRD = EjeProductoPRD;
			}
			objNewMember.EjeEmpNumL = EjeEmpNumL;
			objNewMember.EjeNumL = EjeNumL;
			objNewMember.EjeRolloverI = EjeRolloverI;
			objNewMember.EjeDigitI = EjeDigitI;
			objNewMember.EjeNomS = EjeNomS;
			if (Information.IsReference(EjeRfcRFC))
			{
				objNewMember.EjeRfcRFC = EjeRfcRFC;
			} else
			{
				objNewMember.EjeRfcRFC = EjeRfcRFC;
			}
			objNewMember.EjeSueldoL = EjeSueldoL;
			objNewMember.EjeNumNomS = EjeNumNomS;
			objNewMember.EjeCentroCostS = EjeCentroCostS;
			objNewMember.EjeNivelI = EjeNivelI;
			objNewMember.EjeNomGrabaS = EjeNomGrabaS;
			if (Information.IsReference(EjeDomEnvioDMC))
			{
				objNewMember.EjeDomEnvioDMC = EjeDomEnvioDMC;
			} else
			{
				objNewMember.EjeDomEnvioDMC = EjeDomEnvioDMC;
			}
			if (Information.IsReference(EjeDomPartDMC))
			{
				objNewMember.EjeDomPartDMC = EjeDomPartDMC;
			} else
			{
				objNewMember.EjeDomPartDMC = EjeDomPartDMC;
			}
			objNewMember.EjeTelDomS = EjeTelDomS;
			objNewMember.EjeTelOfiS = EjeTelOfiS;
			objNewMember.EjeExtensionS = EjeExtensionS;
			objNewMember.EjeFaxS = EjeFaxS;
			objNewMember.EjeLimCredL = EjeLimCredL;
			objNewMember.EjeRegNumL = EjeRegNumL;
			objNewMember.EjeEstatusS = EjeEstatusS;
			objNewMember.EjeCuentaBnxS = EjeCuentaBnxS;
			objNewMember.EjeSexoS = EjeSexoS;
			objNewMember.EjeSucTransS = EjeSucTransS;
			objNewMember.EjeSucPromS = EjeSucPromS;
			objNewMember.EjeOrigenS = EjeOrigenS;
			objNewMember.EjeActiSubactiS = EjeActiSubactiS;
			objNewMember.EjeEmailS = EjeEmailS;
			objNewMember.EjeCtaContableS = EjeCtaContableS;
			objNewMember.EjeGenPinPlaI = EjeGenPinPlaI;
			objNewMember.EjeLimDisEfecL = EjeLimDisEfecL;
			objNewMember.EjeTipoCuentaS = EjeTipoCuentaS;
			objNewMember.EjeTipoFactS = EjeTipoFactS;
			objNewMember.EjeSkipPaymentL = (int) EjeSkipPaymentL;
			objNewMember.EjeTablaMCCL = EjeTablaMCCL;
			objNewMember.EjeIndLimDispS = EjeIndLimDispS;
			objNewMember.EjeIndCtaCtrlS = EjeIndCtaCtrlS;
			objNewMember.EjeNacionalidadS = EjeNacionalidadS;
			objNewMember.EjeCuentaS = EjeCuentaS;
			objNewMember.EjeDiaCorteI = EjeDiaCorteI;
			objNewMember.EjeCuentaReferenciaS = EjeCuentaReferenciaS;
			objNewMember.EjeEmpTipoEnvioS = EjeEmpTipoEnvioS;
			objNewMember.EjeEmpTipoFactS = EjeEmpTipoFactS;
			objNewMember.EjeEmpTipoProductoS = EjeEmpTipoProductoS;
			objNewMember.EjeEmpSectorI = EjeEmpSectorI;
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			
			//return the object created
			return objNewMember;
			
			
		}
		
		public clsDatosEjecutivo Add( clsProducto EjeProductoPRD,  int EjeEmpNumL,  int EjeNumL,  int EjeRolloverI,  int EjeDigitI,  string EjeNomS,  clsRFC EjeRfcRFC,  int EjeSueldoL,  string EjeNumNomS,  string EjeCentroCostS,  int EjeNivelI,  string EjeNomGrabaS,  clsDomicilio EjeDomEnvioDMC,  clsDomicilio EjeDomPartDMC,  string EjeTelDomS,  string EjeTelOfiS,  string EjeExtensionS,  string EjeFaxS,  int EjeLimCredL,  int EjeRegNumL,  string EjeEstatusS,  string EjeCuentaBnxS,  string EjeSexoS,  string EjeSucTransS,  string EjeSucPromS,  string EjeOrigenS,  string EjeActiSubactiS,  string EjeEmailS,  string EjeCtaContableS,  int EjeGenPinPlaI,  int EjeLimDisEfecL,  string EjeTipoCuentaS,  string EjeTipoFactS,  CheckState EjeSkipPaymentL,  int EjeTablaMCCL,  string EjeIndLimDispS,  string EjeIndCtaCtrlS,  string EjeNacionalidadS,  string EjeCuentaS,  int EjeDiaCorteI,  string EjeCuentaReferenciaS,  string EjeEmpTipoEnvioS,  string EjeEmpTipoFactS,  string EjeEmpTipoProductoS,  int EjeEmpSectorI)
		{
			string tempRefParam = "";
			return Add(EjeProductoPRD, EjeEmpNumL, EjeNumL, EjeRolloverI, EjeDigitI, EjeNomS, EjeRfcRFC, EjeSueldoL, EjeNumNomS, EjeCentroCostS, EjeNivelI, EjeNomGrabaS, EjeDomEnvioDMC, EjeDomPartDMC, EjeTelDomS, EjeTelOfiS, EjeExtensionS, EjeFaxS, EjeLimCredL, EjeRegNumL, EjeEstatusS, EjeCuentaBnxS, EjeSexoS, EjeSucTransS, EjeSucPromS, EjeOrigenS, EjeActiSubactiS, EjeEmailS, EjeCtaContableS, EjeGenPinPlaI, EjeLimDisEfecL, EjeTipoCuentaS, EjeTipoFactS, EjeSkipPaymentL, EjeTablaMCCL, EjeIndLimDispS, EjeIndCtaCtrlS, EjeNacionalidadS, EjeCuentaS, EjeDiaCorteI, EjeCuentaReferenciaS, EjeEmpTipoEnvioS, EjeEmpTipoFactS, EjeEmpTipoProductoS, EjeEmpSectorI, ref tempRefParam);
		}
		
		public clsDatosEjecutivo this[object vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsDatosEjecutivo) mCol[Convert.ToInt32(vntIndexKey)];
			}
		}
		
		
		
		
		public int Count
		{
			get
			{
				//used when retrieving the number of elements in the
				//collection. Syntax: Debug.Print x.Count
				return mCol.Count;
			}
		}
		
		
		
		
		public IEnumerator GetEnumerator()
		{
			//this property allows you to enumerate
			//this collection with the For...Each syntax
			return mCol.GetEnumerator();
		}
		
		
		public void  Remove( string vntIndexKey)
		{
			//used when removing an element from the collection
			//vntIndexKey contains either the Index or Key, which is why
			//it is declared as a Variant
			//Syntax: x.Remove(xyz)


            //AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
                mCol.Remove(vntIndexKey.ToString());
            else
                //AIS-1172 NGONZALEZ
                mCol.Remove(Convert.ToInt32(vntIndexKey));
		}
		
		
		public colcatReenvio(){
			//creates the collection when this class is created
		}
	
	
	~colcatReenvio(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}