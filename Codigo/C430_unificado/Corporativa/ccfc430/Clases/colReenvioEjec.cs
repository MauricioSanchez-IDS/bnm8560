using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colReenvioEjec
	: IEnumerable
	{
	
		string CuentaReferenciaS = String.Empty;
		int NumEmpL = 0;
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		private void  prObtenCtasReferencia()
		{
			int lNumEmp = 0;
			string sCtaPadre = String.Empty;
			
			
			if (this.Count > 0)
			{
				lNumEmp = this[1].NumEmpL;
				sCtaPadre = fncCuentaPadreS(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, this[1].NumEmpL);
				for (int iCont = 1; iCont <= this.Count; iCont++)
				{
					if (lNumEmp != this[iCont].NumEmpL)
					{
						sCtaPadre = fncCuentaPadreS(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, this[iCont].NumEmpL);
					}
					this[iCont].CuentaReferenciaS = sCtaPadre;
				}
			}
			return;
			
			
			
			if (Information.Err().Number == 91)
			{
				Information.Err().Clear();
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
				throw new Exception("Migration Exception: 'Resume Next' not supported");
			} else
			{
				Cursor.Current = Cursors.Default;
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenCtasReferencia)");
				return;
			}
			
		}
		public bool fncCargaDatosMTCMSV01B()
		{
			bool result = false;
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
			int eje_skip_payment = 0;
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
			int tipo_bloqueo = 0;
			string eje_atn_a = String.Empty; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
			int eje_tipo_persona = 0; //FSWB NR 20070222
			
			try
			{
					
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
					CORVAR.pszgblsql = CORVAR.pszgblsql + "b.emp_dia_corte, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tipo_bloqueo, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_atn_a, "; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tipo_persona "; //FSWB NR 20070222
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMSV01 a, MTCEMP01 b";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo = b.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = b.emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_status_reg < 12";
					//pszgblsql = pszgblsql & " and a.eje_num <> 0"
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblEmpCve.ToString();
					
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
							eje_nombre = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
							eje_rfc = new clsRFC();
							eje_rfc.RFCS = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 7) == "")
							{
								eje_sueldo = 0;
							} else
							{
								eje_sueldo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 7));
							}
							eje_num_nom = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
							eje_centro_c = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 10) == "")
							{
								eje_nivel = 0;
							} else
							{
								eje_nivel = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 10));
							}
							eje_nom_gra = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
							//****************
							//inicia domicilio envio
							eje_dom_envio = new clsDomicilio();
							eje_dom_envio.DomicilioS = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim();
							eje_dom_envio.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
							eje_dom_envio.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
							eje_dom_envio.EstadoEST.AbreviaturaS = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 16) == "")
							{
								eje_dom_envio.CPL = 0;
							} else
							{
								eje_dom_envio.CPL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 16));
							}
							//eje_dom_envio.CiudadS = CStr(SqlData(hgblConexion, 17))
							//****************
							eje_tel_dom = VBSQL.SqlData(CORVAR.hgblConexion, 18).Trim();
							eje_tel_ofi = VBSQL.SqlData(CORVAR.hgblConexion, 19).Trim();
							eje_ext = VBSQL.SqlData(CORVAR.hgblConexion, 20).Trim();
							eje_fax = VBSQL.SqlData(CORVAR.hgblConexion, 21).Trim();
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
							eje_status = VBSQL.SqlData(CORVAR.hgblConexion, 24).Trim();
							eje_cuenta_bnx = VBSQL.SqlData(CORVAR.hgblConexion, 25).Trim();
							eje_sexo = VBSQL.SqlData(CORVAR.hgblConexion, 26).Trim();
							eje_suc_trans = VBSQL.SqlData(CORVAR.hgblConexion, 27).Trim();
							eje_suc_prom = VBSQL.SqlData(CORVAR.hgblConexion, 28).Trim();
							eje_origen = VBSQL.SqlData(CORVAR.hgblConexion, 29).Trim();
							eje_acti_subacti = VBSQL.SqlData(CORVAR.hgblConexion, 30).Trim();
							//****************
							//inicia domicilio particular
							eje_dom_part = new clsDomicilio();
							eje_dom_part.DomicilioS = VBSQL.SqlData(CORVAR.hgblConexion, 31).Trim();
							eje_dom_part.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 32).Trim();
							eje_dom_part.CiudadS = VBSQL.SqlData(CORVAR.hgblConexion, 33).Trim();
							eje_dom_part.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 34).Trim();
							eje_dom_part.EstadoEST.AbreviaturaS = VBSQL.SqlData(CORVAR.hgblConexion, 35).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 36) == "")
							{
								eje_dom_part.CPL = 0;
							} else
							{
								eje_dom_part.CPL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 36));
							}
							//****************
							eje_email = VBSQL.SqlData(CORVAR.hgblConexion, 37).Trim();
							eje_cta_contable = VBSQL.SqlData(CORVAR.hgblConexion, 38).Trim();
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
							eje_tipo_cuenta = VBSQL.SqlData(CORVAR.hgblConexion, 41).Trim();
							eje_tipo_fac = VBSQL.SqlData(CORVAR.hgblConexion, 42).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 43) == "")
							{
								eje_skip_payment = 0;
							} else
							{
								eje_skip_payment = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 43));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 44) == "")
							{
								eje_tabla_mcc = 0;
							} else
							{
								eje_tabla_mcc = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 44));
							}
							eje_ind_lim_disp = VBSQL.SqlData(CORVAR.hgblConexion, 45).Trim();
							eje_ind_cta_ctrl = VBSQL.SqlData(CORVAR.hgblConexion, 46).Trim();
							eje_nacionalidad = VBSQL.SqlData(CORVAR.hgblConexion, 47).Trim();
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
							emp_tipo_envio = VBSQL.SqlData(CORVAR.hgblConexion, 50).Trim();
							emp_tipo_fac = VBSQL.SqlData(CORVAR.hgblConexion, 51).Trim();
							emp_tipo_producto = VBSQL.SqlData(CORVAR.hgblConexion, 52).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 53) == "")
							{
								emp_dia_corte = 0;
							} else
							{
								emp_dia_corte = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 53));
							}
							
							tipo_bloqueo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 54));
							
							eje_atn_a = VBSQL.SqlData(CORVAR.hgblConexion, 55).Trim(); //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
							eje_tipo_persona = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 56)); //FSWB NR 20070222
							
							cuenta_referencia = "";
							cuenta = "";
							
							this.Add(mdlParametros.gprdProducto, emp_num, eje_num, eje_roll_over, eje_digit, eje_nombre, eje_rfc, eje_sueldo, eje_num_nom, eje_centro_c, eje_nivel, eje_nom_gra, eje_dom_envio, eje_tel_dom, eje_tel_ofi, eje_ext, eje_fax, eje_limcred, reg_num, eje_status, eje_cuenta_bnx, eje_sexo, eje_suc_trans, eje_suc_prom, eje_origen, eje_acti_subacti, eje_dom_part, eje_email, eje_cta_contable, eje_gen_pin_pla, eje_lim_dis_efec, eje_tipo_cuenta, eje_tipo_fac, eje_skip_payment, eje_tabla_mcc, eje_ind_lim_disp, eje_ind_cta_ctrl, eje_nacionalidad, eje_status_reg, emp_sector, emp_tipo_envio, emp_tipo_fac, emp_tipo_producto, emp_dia_corte, cuenta, cuenta_referencia, tipo_bloqueo, eje_atn_a, eje_tipo_persona); //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
						};
					} else
					{
						MessageBox.Show("No se encontro ningun Ejecutivo que se necesite reenviar", Application.ProductName);
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					prObtenCtasReferencia();
				}
                catch (Exception e)
			{
				
				
				if (Information.Err().Number == 91)
				{
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
					throw new Exception("Migration Exception: 'Resume Next' not supported");
				} else
				{
					CRSGeneral.prObtenError(this.GetType().Name + " (CargaDatosMTCMSV01)",e );
					result = false;
					Cursor.Current = Cursors.Default;
					return result;
				}
			}
			
			return result;
		}
		
		public bool fncCargaDatosMTCIND01B()
		{
			bool result = false;
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
			int eje_skip_payment = 0;
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
			int tipo_bloqueo = 0;
			
			string eje_atn_a = String.Empty; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
			int eje_tipo_persona = 0; //FSWB NR 20070222
			
			
			try
			{
					
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
					CORVAR.pszgblsql = CORVAR.pszgblsql + "b.emp_dia_corte, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tipo_bloqueo, ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_atn_a,"; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
					CORVAR.pszgblsql = CORVAR.pszgblsql + "a.eje_tipo_persona"; //FSWB NR 20070222
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCIND01 a, MTCEMP01 b";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo = b.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = b.emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_status_reg < 12";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblEmpCve.ToString();
					
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
							eje_nombre = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
							eje_rfc = new clsRFC();
							eje_rfc.RFCS = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 7) == "")
							{
								eje_sueldo = 0;
							} else
							{
								eje_sueldo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 7));
							}
							eje_num_nom = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
							eje_centro_c = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 10) == "")
							{
								eje_nivel = 0;
							} else
							{
								eje_nivel = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 10));
							}
							eje_nom_gra = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
							//****************
							//inicia domicilio envio
							eje_dom_envio = new clsDomicilio();
							eje_dom_envio.DomicilioS = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim();
							eje_dom_envio.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
							eje_dom_envio.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
							eje_dom_envio.EstadoEST.AbreviaturaS = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 16) == "")
							{
								eje_dom_envio.CPL = 0;
							} else
							{
								eje_dom_envio.CPL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 16));
							}
							//eje_dom_envio.CiudadS = CStr(SqlData(hgblConexion, 17))
							//****************
							eje_tel_dom = VBSQL.SqlData(CORVAR.hgblConexion, 18).Trim();
							eje_tel_ofi = VBSQL.SqlData(CORVAR.hgblConexion, 19).Trim();
							eje_ext = VBSQL.SqlData(CORVAR.hgblConexion, 20).Trim();
							eje_fax = VBSQL.SqlData(CORVAR.hgblConexion, 21).Trim();
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
							eje_status = VBSQL.SqlData(CORVAR.hgblConexion, 24).Trim();
							eje_cuenta_bnx = VBSQL.SqlData(CORVAR.hgblConexion, 25).Trim();
							eje_sexo = VBSQL.SqlData(CORVAR.hgblConexion, 26).Trim();
							eje_suc_trans = VBSQL.SqlData(CORVAR.hgblConexion, 27).Trim();
							eje_suc_prom = VBSQL.SqlData(CORVAR.hgblConexion, 28).Trim();
							eje_origen = VBSQL.SqlData(CORVAR.hgblConexion, 29).Trim();
							eje_acti_subacti = VBSQL.SqlData(CORVAR.hgblConexion, 30).Trim();
							//****************
							//inicia domicilio particular
							eje_dom_part = new clsDomicilio();
							eje_dom_part.DomicilioS = VBSQL.SqlData(CORVAR.hgblConexion, 31).Trim();
							eje_dom_part.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 32).Trim();
							eje_dom_part.CiudadS = VBSQL.SqlData(CORVAR.hgblConexion, 33).Trim();
							eje_dom_part.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 34).Trim();
							eje_dom_part.EstadoEST.AbreviaturaS = VBSQL.SqlData(CORVAR.hgblConexion, 35).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 36) == "")
							{
								eje_dom_part.CPL = 0;
							} else
							{
								eje_dom_part.CPL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 36));
							}
							//****************
							eje_email = VBSQL.SqlData(CORVAR.hgblConexion, 37).Trim();
							eje_cta_contable = VBSQL.SqlData(CORVAR.hgblConexion, 38).Trim();
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
							eje_tipo_cuenta = VBSQL.SqlData(CORVAR.hgblConexion, 41).Trim();
							eje_tipo_fac = VBSQL.SqlData(CORVAR.hgblConexion, 42).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 43) == "")
							{
								eje_skip_payment = 0;
							} else
							{
								eje_skip_payment = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 43));
							}
							if (VBSQL.SqlData(CORVAR.hgblConexion, 44) == "")
							{
								eje_tabla_mcc = 0;
							} else
							{
								eje_tabla_mcc = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 44));
							}
							eje_ind_lim_disp = VBSQL.SqlData(CORVAR.hgblConexion, 45).Trim();
							eje_ind_cta_ctrl = VBSQL.SqlData(CORVAR.hgblConexion, 46).Trim();
							eje_nacionalidad = VBSQL.SqlData(CORVAR.hgblConexion, 47).Trim();
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
							emp_tipo_envio = VBSQL.SqlData(CORVAR.hgblConexion, 50).Trim();
							emp_tipo_fac = VBSQL.SqlData(CORVAR.hgblConexion, 51).Trim();
							emp_tipo_producto = VBSQL.SqlData(CORVAR.hgblConexion, 52).Trim();
							if (VBSQL.SqlData(CORVAR.hgblConexion, 53) == "")
							{
								emp_dia_corte = 0;
							} else
							{
								emp_dia_corte = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 53));
							}
							cuenta_referencia = "";
							cuenta = "";
							
							tipo_bloqueo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 54));
							
							eje_atn_a = VBSQL.SqlData(CORVAR.hgblConexion, 55).Trim(); //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
							eje_tipo_persona = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 56)); //FSWB NR 20070222
							
							
							this.Add(mdlParametros.gprdProducto, emp_num, eje_num, eje_roll_over, eje_digit, eje_nombre, eje_rfc, eje_sueldo, eje_num_nom, eje_centro_c, eje_nivel, eje_nom_gra, eje_dom_envio, eje_tel_dom, eje_tel_ofi, eje_ext, eje_fax, eje_limcred, reg_num, eje_status, eje_cuenta_bnx, eje_sexo, eje_suc_trans, eje_suc_prom, eje_origen, eje_acti_subacti, eje_dom_part, eje_email, eje_cta_contable, eje_gen_pin_pla, eje_lim_dis_efec, eje_tipo_cuenta, eje_tipo_fac, eje_skip_payment, eje_tabla_mcc, eje_ind_lim_disp, eje_ind_cta_ctrl, eje_nacionalidad, eje_status_reg, emp_sector, emp_tipo_envio, emp_tipo_fac, emp_tipo_producto, emp_dia_corte, cuenta, cuenta_referencia, tipo_bloqueo, eje_atn_a, eje_tipo_persona); //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
						};
					} else
					{
						MessageBox.Show("No se encontro ningun Ejecutivo que se necesite reenviar", Application.ProductName);
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					prObtenCtasReferencia();
				}
                catch (Exception e)
			{
				
				
				if (Information.Err().Number == 91)
				{
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
					throw new Exception("Migration Exception: 'Resume Next' not supported");
				} else
				{
					CRSGeneral.prObtenError(this.GetType().Name + " (CargaDatosMTCIND01)",e );
					result = false;
					Cursor.Current = Cursors.Default;
					return result;
				}
			}
			
			return result;
		}
		
		public clsReenvioEjec Add( clsProducto EjeProductoPRD,  int NumEmpL,  int EjeNumeroL,  int EjeRolloverI,  int EjeDigitoI,  string EjeNombreS,  clsRFC EjeRFC,  int EjeSueldoL,  string EjeNumNominaS,  string EjeCenCosS,  int EjeNivelI,  string EjeNomGrabaS,  clsDomicilio EjeDomEnvioDMC,  string EjeTelDomS,  string EjeTelOficS,  string EjeExtS,  string EjeFaxS,  int EjeLimCredL,  int RegNumL,  string EjeEstatusS,  string EjeCtaBmxS,  string EjeSexoS,  string EjeSucTransS,  string EjeSucPromS,  string EjeOrigenS,  string EjeActSubActiS,  clsDomicilio EjeDomPartDMC,  string EjeEmailS,  string EjeCtaContableS,  int EjeGenPinPlaI,  int EjeLimDisEfecL,  string EjeTipoCtaS,  string EjeTipoFactS,  int EjeSkipPaymentL,  int EjeTablaMCCL,  string EjeIndLimDispS,  string EjeIndCtasCtrlS,  string EjeNacionalS,  int EjeStatusRegI,  int EmpSectorI,  string EmpTipoEnvioS,  string EmpTipoFactS,  string EmpTipoProductoS,  int EmpDiaCorteI,  string CuentaS,  string CuentaReferenciaS,  int EjeTipoBloqueoI,  string EjeAtencionA,  int EjePersona, ref  string sKey)
		{ //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
			
			//create a new object
			clsReenvioEjec objNewMember = new clsReenvioEjec();
			
			//set the properties passed into the method
			if (Information.IsReference(EjeProductoPRD))
			{
				objNewMember.EjeProductoPRD = EjeProductoPRD;
			} else
			{
				objNewMember.EjeProductoPRD = EjeProductoPRD;
			}
			objNewMember.NumEmpL = NumEmpL;
			objNewMember.EjeNumeroL = EjeNumeroL;
			objNewMember.EjeRolloverI = EjeRolloverI;
			objNewMember.EjeDigitoI = EjeDigitoI;
			objNewMember.EjeNombreS = EjeNombreS;
			if (Information.IsReference(EjeRFC))
			{
				objNewMember.EjeRFC = EjeRFC;
			} else
			{
				objNewMember.EjeRFC = EjeRFC;
			}
			objNewMember.EjeSueldoL = EjeSueldoL;
			objNewMember.EjeNumNominaS = EjeNumNominaS;
			objNewMember.EjeCenCosS = EjeCenCosS;
			objNewMember.EjeNivelI = EjeNivelI;
			objNewMember.EjeNomGrabaS = EjeNomGrabaS;
			if (Information.IsReference(EjeDomEnvioDMC))
			{
				objNewMember.EjeDomEnvioDMC = EjeDomEnvioDMC;
			} else
			{
				objNewMember.EjeDomEnvioDMC = EjeDomEnvioDMC;
			}
			objNewMember.EjeTelDomS = EjeTelDomS;
			objNewMember.EjeTelOficS = EjeTelOficS;
			objNewMember.EjeExtS = EjeExtS;
			objNewMember.EjeFaxS = EjeFaxS;
			objNewMember.EjeLimCredL = EjeLimCredL;
			objNewMember.RegNumL = RegNumL;
			objNewMember.EjeEstatusS = EjeEstatusS;
			objNewMember.EjeCtaBmxS = EjeCtaBmxS;
			objNewMember.EjeSexoS = EjeSexoS;
			objNewMember.EjeSucTransS = EjeSucTransS;
			objNewMember.EjeSucPromS = EjeSucPromS;
			objNewMember.EjeOrigenS = EjeOrigenS;
			objNewMember.EjeActSubActiS = EjeActSubActiS;
			if (Information.IsReference(EjeDomPartDMC))
			{
				objNewMember.EjeDomPartDMC = EjeDomPartDMC;
			} else
			{
				objNewMember.EjeDomPartDMC = EjeDomPartDMC;
			}
			objNewMember.EjeEmailS = EjeEmailS;
			objNewMember.EjeCtaContableS = EjeCtaContableS;
			objNewMember.EjeGenPinPlaI = EjeGenPinPlaI;
			objNewMember.EjeLimDisEfecL = EjeLimDisEfecL;
			objNewMember.EjeTipoCtaS = EjeTipoCtaS;
			objNewMember.EjeTipoFactS = EjeTipoFactS;
			objNewMember.EjeSkipPaymentL = EjeSkipPaymentL;
			objNewMember.EjeTablaMCCL = EjeTablaMCCL;
			objNewMember.EjeIndLimDispS = EjeIndLimDispS;
			objNewMember.EjeIndCtasCtrlS = EjeIndCtasCtrlS;
			objNewMember.EjeNacionalS = EjeNacionalS;
			objNewMember.EjeStatusRegI = EjeStatusRegI;
			objNewMember.EmpSectorI = EmpSectorI;
			objNewMember.EmpTipoEnvioS = EmpTipoEnvioS;
			objNewMember.EmpTipoFactS = EmpTipoFactS;
			objNewMember.EmpTipoProductoS = EmpTipoProductoS;
			objNewMember.EmpDiaCorteI = EmpDiaCorteI;
			objNewMember.CuentaS = CuentaS;
			objNewMember.CuentaReferenciaS = CuentaReferenciaS;
			objNewMember.EjeTipoBloqueoI = EjeTipoBloqueoI;
			
			objNewMember.EjeAtencionA = EjeAtencionA; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
			objNewMember.EjePersona = EjePersona; //FSWB NR 20070222
			
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
		
		public clsReenvioEjec Add( clsProducto EjeProductoPRD,  int NumEmpL,  int EjeNumeroL,  int EjeRolloverI,  int EjeDigitoI,  string EjeNombreS,  clsRFC EjeRFC,  int EjeSueldoL,  string EjeNumNominaS,  string EjeCenCosS,  int EjeNivelI,  string EjeNomGrabaS,  clsDomicilio EjeDomEnvioDMC,  string EjeTelDomS,  string EjeTelOficS,  string EjeExtS,  string EjeFaxS,  int EjeLimCredL,  int RegNumL,  string EjeEstatusS,  string EjeCtaBmxS,  string EjeSexoS,  string EjeSucTransS,  string EjeSucPromS,  string EjeOrigenS,  string EjeActSubActiS,  clsDomicilio EjeDomPartDMC,  string EjeEmailS,  string EjeCtaContableS,  int EjeGenPinPlaI,  int EjeLimDisEfecL,  string EjeTipoCtaS,  string EjeTipoFactS,  int EjeSkipPaymentL,  int EjeTablaMCCL,  string EjeIndLimDispS,  string EjeIndCtasCtrlS,  string EjeNacionalS,  int EjeStatusRegI,  int EmpSectorI,  string EmpTipoEnvioS,  string EmpTipoFactS,  string EmpTipoProductoS,  int EmpDiaCorteI,  string CuentaS,  string CuentaReferenciaS,  int EjeTipoBloqueoI,  string EjeAtencionA,  int EjePersona)
		{
			string tempRefParam = "";
			return Add(EjeProductoPRD, NumEmpL, EjeNumeroL, EjeRolloverI, EjeDigitoI, EjeNombreS, EjeRFC, EjeSueldoL, EjeNumNominaS, EjeCenCosS, EjeNivelI, EjeNomGrabaS, EjeDomEnvioDMC, EjeTelDomS, EjeTelOficS, EjeExtS, EjeFaxS, EjeLimCredL, RegNumL, EjeEstatusS, EjeCtaBmxS, EjeSexoS, EjeSucTransS, EjeSucPromS, EjeOrigenS, EjeActSubActiS, EjeDomPartDMC, EjeEmailS, EjeCtaContableS, EjeGenPinPlaI, EjeLimDisEfecL, EjeTipoCtaS, EjeTipoFactS, EjeSkipPaymentL, EjeTablaMCCL, EjeIndLimDispS, EjeIndCtasCtrlS, EjeNacionalS, EjeStatusRegI, EmpSectorI, EmpTipoEnvioS, EmpTipoFactS, EmpTipoProductoS, EmpDiaCorteI, CuentaS, CuentaReferenciaS, EjeTipoBloqueoI, EjeAtencionA, EjePersona, ref tempRefParam);
		}
		
		public clsReenvioEjec this[int vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				return (clsReenvioEjec) mCol[vntIndexKey];
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
                mCol.Remove(Convert.ToInt32(vntIndexKey));
		}
		
		public colReenvioEjec(){
			//creates the collection when this class is created
		}
	
	~colReenvioEjec(){
		//destroys collection when this class is terminated
		mCol = null;
	}

private string fncCuentaPadreS( int lpPrefijo,  int lpBanco,  int lpEmpresa)
{
		string result = String.Empty;
		string slCuenta = String.Empty;
		ADODB.Recordset adorst = null;
		string strCuentaPadre = String.Empty;
		string strCuentaCiti = String.Empty;
		
		try
		{
			
			if (VBSQL.OpenConn(10) != 0)
			{
				VBSQL.gConn[10].Close();
			} else
			{
				VBSQL.gConn[10].Close();
			}
			
			if (VBSQL.OpenConn(10) == 0)
			{
				adorst = new ADODB.Recordset();
				
				CORVAR.pszgblsql = "select convert(char(4), c.eje_prefijo) + ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(char(2),c.gpo_banco) + ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', (select i.pgs_long_emp from MTCPGS01 i ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "Where i.pgs_rep_prefijo = c.eje_prefijo ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "and i.pgs_rep_banco = c.gpo_banco) - char_length(ltrim(rtrim(str(c.emp_num))))) + ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(rtrim(str(c.emp_num))) + ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', (select i.pgs_long_eje from MTCPGS01 i ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "Where i.pgs_rep_prefijo = c.eje_prefijo ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "and i.pgs_rep_banco = c.gpo_banco) - char_length(ltrim(rtrim(str(c.eje_num))))) + ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(rtrim(str(c.eje_num))) + convert(char(1),c.eje_roll_over) + ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(char(1),c.eje_digit) ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "From  MTCEJE01 c  Where c.eje_prefijo = " + lpPrefijo.ToString() + " and c.gpo_banco = " + lpBanco.ToString();
				CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + lpEmpresa.ToString() + " and c.eje_num = 0";
				
				adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
				
				if (! adorst.EOF && ! adorst.BOF)
				{
					strCuentaPadre = Convert.ToString(adorst.Fields[0].Value);
				}
				
				adorst.Close();
				
				CORVAR.pszgblsql = "select map_cta_citi ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + "From MTCMAP01  where map_cta_bnx = '" + strCuentaPadre + "' ";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " and map_estatus = ''";
				
				adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
				
				if (! adorst.EOF && ! adorst.BOF)
				{
					strCuentaCiti = Convert.ToString(adorst.Fields[0].Value);
				}
				
				adorst.Close();
				adorst = null;
				
				if (strCuentaCiti == "")
				{
					result = strCuentaPadre;
				} else
				{
					result = strCuentaCiti;
				}
				
				if (VBSQL.gConn[10].State == 1)
				{
					VBSQL.gConn[10].Close();
				}
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
		Cursor.Current = Cursors.Default;
		result = "";
		CRSGeneral.prObtenError(this.GetType().Name + "(CuentaPadre)",e );
		
		if (adorst.State != 0)
		{
		adorst.Close();
		}
		
		if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
		{
		VBSQL.gConn[10].Close();
		}
		
		return result;
		}
		}
		
		return result;
}
}
}