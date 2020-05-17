using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Collections; 
using System.Drawing; 
using System.IO; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colcatArchivo
	: IEnumerable
	{
	
		private Collection mCol = new Collection();
		double dlbMonto = 0;
		double dblMontoAcum = 0;
		
		public bool fncLlenaReenvioEjeB( mdlEjecutivo.enuTipoAltaEjecutivo ipTipoAltaEjecutivo)
		{
			
			try
			{
					
					if (ipTipoAltaEjecutivo == mdlEjecutivo.enuTipoAltaEjecutivo.taejAltaIndividual)
					{ //***** ALTA INDIVIDUAL *****
						CORVAR.pszgblsql = "select ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_roll_over,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_digit,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nombre,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_rfc,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_sueldo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num_nom,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_centro_c,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nivel,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nom_gra,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_calle,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_col,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_pob,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_zp,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cp,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_dom,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_ofi,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ext,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_fax,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_limcred,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "reg_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cuenta_bnx,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_sexo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_suc_trans,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_suc_prom,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_origen,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_acti_subacti,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_edo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_calle,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_col,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_ciu,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_pob,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_edo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_cp,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_email,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cta_contable,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_gen_pin_pla,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_lim_dis_efec,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_cuenta,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_fac,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_skip_payment,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tabla_mcc,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ind_lim_disp,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ind_cta_ctrl,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nacionalidad,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status_reg,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_bloqueo ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCIND01";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						
					} else if (ipTipoAltaEjecutivo == mdlEjecutivo.enuTipoAltaEjecutivo.taejAltaMasiva) {  //***** ALTA MASIVA *****
						CORVAR.pszgblsql = "select ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_roll_over,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_digit,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nombre,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_rfc,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_sueldo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num_nom,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_centro_c,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nivel,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nom_gra,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_calle,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_col,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_pob,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_edo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cp,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_zp,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_dom,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_ofi,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ext,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_fax,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_limcred,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "reg_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cuenta_bnx,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_sexo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_suc_trans,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_suc_prom,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_origen,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_acti_subacti,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_calle,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_col,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_ciu,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_pob,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_edo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_cp,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_email,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cta_contable,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_gen_pin_pla,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_lim_dis_efec,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_cuenta,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_fac,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_skip_payment,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tabla_mcc,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ind_lim_disp,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ind_cta_ctrl,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nacionalidad,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status_reg,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_bloqueo ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCMSV01";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						
					}
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							//llConsecutivo = CLng(SqlData(hgblConexion, 1)) - 1
							//llConsecutivoTope = CLng(String(gdteEjecutivo.EjeProductoPRD.LongitudEjecutivoI, "9"))
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
				
				CRSGeneral.prObtenError(this.GetType().Name + "(LlenaReenvioEje)",e );
				return false;
			}
			
			
			return false;
		}
		
		public clsArchivo Add( clsProducto ArchEjeProductoPRD,  int ArchEjeNumEmpL,  int ArchEjeNumeroL,  int ArchEjeRollOverI,  int ArchEjeDigitoI,  string ArchEjeNombreS,  clsRFC ArchEjeRFC,  int ArchEjeSueldoL,  string ArchEjeNumNominaS,  string ArchEjeCenCosS,  int AchEjeNivelI,  string ArchEjeNomGrabaS,  clsDomicilio ArchEjeDomEnvioDMC,  string ArchEjeTelDomS,  string ArchEjeTelOfiS,  string ArchEjeExtS,  string ArchEjeFaxS,  int ArchEjeLimCredL,  int ArchRegNumI,  string ArchEjeStatusS,  string ArchEjeCtaBnxS,  string ArchEjeSexoS,  string ArchEjeSucTransS,  string ArchEjeSucPromS,  string ArchEjeOrigenS,  string ArchEjeActSubActiS,  clsDomicilio ArchEjeDomPartDMC,  string ArchEjeEmailS,  string ArchEjeCtaContableS,  int ArchEjeGenPinPlaI,  int ArchEjeLimDisEfecI,  string ArchEjeTipoCtaS,  string ArchEjeTipoFactS,  int ArchEjeSkipPaymentI,  int ArchEjeTablaMccL,  string ArchEjeIndLimDispS,  string ArchEjeIndCtaCtrlS,  string ArchEjeNacionalS,  int ArchEjeStatusRegI,  int ArchEjeTipoBloqueoI,  string ArchEjeAtencionA,  int ArchEjePersona, ref  string sKey)
		{ //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
			
			clsArchivo objNewMember = new clsArchivo();
			
			if (Information.IsReference(ArchEjeProductoPRD))
			{
				objNewMember.ArchEjeProductoPRD = ArchEjeProductoPRD;
			} else
			{
				objNewMember.ArchEjeProductoPRD = ArchEjeProductoPRD;
			}
			objNewMember.ArchEjeNumEmpL = ArchEjeNumEmpL;
			objNewMember.ArchEjeNumeroL = ArchEjeNumeroL;
			objNewMember.ArchEjeRollOverI = ArchEjeRollOverI;
			objNewMember.ArchEjeDigitoI = ArchEjeDigitoI;
			objNewMember.ArchEjeNombreS = ArchEjeNombreS;
			if (Information.IsReference(ArchEjeRFC))
			{
				objNewMember.ArchEjeRFC = ArchEjeRFC;
			} else
			{
				objNewMember.ArchEjeRFC = ArchEjeRFC;
			}
			objNewMember.ArchEjeSueldoL = ArchEjeSueldoL;
			objNewMember.ArchEjeNumNominaS = ArchEjeNumNominaS;
			objNewMember.ArchEjeCenCosS = ArchEjeCenCosS;
			objNewMember.AchEjeNivelI = AchEjeNivelI;
			objNewMember.ArchEjeNomGrabaS = ArchEjeNomGrabaS;
			if (Information.IsReference(ArchEjeDomEnvioDMC))
			{
				objNewMember.ArchEjeDomEnvioDMC = ArchEjeDomEnvioDMC;
			} else
			{
				objNewMember.ArchEjeDomEnvioDMC = ArchEjeDomEnvioDMC;
			}
			objNewMember.ArchEjeTelDomS = ArchEjeTelDomS;
			objNewMember.ArchEjeTelOfiS = ArchEjeTelOfiS;
			objNewMember.ArchEjeExtS = ArchEjeExtS;
			objNewMember.ArchEjeFaxS = ArchEjeFaxS;
			objNewMember.ArchEjeLimCredL = ArchEjeLimCredL;
			objNewMember.ArchRegNumI = ArchRegNumI;
			objNewMember.ArchEjeStatusS = ArchEjeStatusS;
			objNewMember.ArchEjeCtaBnxS = ArchEjeCtaBnxS;
			objNewMember.ArchEjeSexoS = ArchEjeSexoS;
			objNewMember.ArchEjeSucTransS = ArchEjeSucTransS;
			objNewMember.ArchEjeSucPromS = ArchEjeSucPromS;
			objNewMember.ArchEjeOrigenS = ArchEjeOrigenS;
			objNewMember.ArchEjeActSubActiS = ArchEjeActSubActiS;
			if (Information.IsReference(ArchEjeDomPartDMC))
			{
				objNewMember.ArchEjeDomPartDMC = ArchEjeDomPartDMC;
			} else
			{
				objNewMember.ArchEjeDomPartDMC = ArchEjeDomPartDMC;
			}
			objNewMember.ArchEjeEmailS = ArchEjeEmailS;
			objNewMember.ArchEjeCtaContableS = ArchEjeCtaContableS;
			objNewMember.ArchEjeGenPinPlaI = ArchEjeGenPinPlaI;
			objNewMember.ArchEjeLimDisEfecI = ArchEjeLimDisEfecI;
			objNewMember.ArchEjeTipoCtaS = ArchEjeTipoCtaS;
			objNewMember.ArchEjeTipoFactS = ArchEjeTipoFactS;
			objNewMember.ArchEjeSkipPaymentI = ArchEjeSkipPaymentI;
			objNewMember.ArchEjeTablaMccL = ArchEjeTablaMccL;
			objNewMember.ArchEjeIndLimDispS = ArchEjeIndLimDispS;
			objNewMember.ArchEjeIndCtaCtrlS = ArchEjeIndCtaCtrlS;
			objNewMember.ArchEjeNacionalS = ArchEjeNacionalS;
			objNewMember.ArchEjeStatusRegI = ArchEjeStatusRegI;
			objNewMember.ArchEjeTipoBloqueoI = ArchEjeTipoBloqueoI;
			
			objNewMember.ArchEjeAtencionA = ArchEjeAtencionA; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
			objNewMember.ArchEjePersona = ArchEjePersona; //FSWB NR 20070222
			
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			return objNewMember;
			
		}
		
		public clsArchivo Add( clsProducto ArchEjeProductoPRD,  int ArchEjeNumEmpL,  int ArchEjeNumeroL,  int ArchEjeRollOverI,  int ArchEjeDigitoI,  string ArchEjeNombreS,  clsRFC ArchEjeRFC,  int ArchEjeSueldoL,  string ArchEjeNumNominaS,  string ArchEjeCenCosS,  int AchEjeNivelI,  string ArchEjeNomGrabaS,  clsDomicilio ArchEjeDomEnvioDMC,  string ArchEjeTelDomS,  string ArchEjeTelOfiS,  string ArchEjeExtS,  string ArchEjeFaxS,  int ArchEjeLimCredL,  int ArchRegNumI,  string ArchEjeStatusS,  string ArchEjeCtaBnxS,  string ArchEjeSexoS,  string ArchEjeSucTransS,  string ArchEjeSucPromS,  string ArchEjeOrigenS,  string ArchEjeActSubActiS,  clsDomicilio ArchEjeDomPartDMC,  string ArchEjeEmailS,  string ArchEjeCtaContableS,  int ArchEjeGenPinPlaI,  int ArchEjeLimDisEfecI,  string ArchEjeTipoCtaS,  string ArchEjeTipoFactS,  int ArchEjeSkipPaymentI,  int ArchEjeTablaMccL,  string ArchEjeIndLimDispS,  string ArchEjeIndCtaCtrlS,  string ArchEjeNacionalS,  int ArchEjeStatusRegI,  int ArchEjeTipoBloqueoI,  string ArchEjeAtencionA,  int ArchEjePersona)
		{
			string tempRefParam = "";
			return Add(ArchEjeProductoPRD, ArchEjeNumEmpL, ArchEjeNumeroL, ArchEjeRollOverI, ArchEjeDigitoI, ArchEjeNombreS, ArchEjeRFC, ArchEjeSueldoL, ArchEjeNumNominaS, ArchEjeCenCosS, AchEjeNivelI, ArchEjeNomGrabaS, ArchEjeDomEnvioDMC, ArchEjeTelDomS, ArchEjeTelOfiS, ArchEjeExtS, ArchEjeFaxS, ArchEjeLimCredL, ArchRegNumI, ArchEjeStatusS, ArchEjeCtaBnxS, ArchEjeSexoS, ArchEjeSucTransS, ArchEjeSucPromS, ArchEjeOrigenS, ArchEjeActSubActiS, ArchEjeDomPartDMC, ArchEjeEmailS, ArchEjeCtaContableS, ArchEjeGenPinPlaI, ArchEjeLimDisEfecI, ArchEjeTipoCtaS, ArchEjeTipoFactS, ArchEjeSkipPaymentI, ArchEjeTablaMccL, ArchEjeIndLimDispS, ArchEjeIndCtaCtrlS, ArchEjeNacionalS, ArchEjeStatusRegI, ArchEjeTipoBloqueoI, ArchEjeAtencionA, ArchEjePersona, ref tempRefParam);
		}
		
		public clsArchivo this[int vntIndexKey]
		{
			get
			{
				return (clsArchivo) mCol[vntIndexKey];
			}
		}
		
		
		public int Count
		{
			get
			{
				return mCol.Count;
			}
		}
		
		
		
		public IEnumerator GetEnumerator()
		{
			return mCol.GetEnumerator();
		}
		
		public void  Remove( string vntIndexKey)
		{
            //AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
                mCol.Remove(vntIndexKey.ToString());
            else
                //AIS-1172 NGONZALEZ
                mCol.Remove(Convert.ToInt32(vntIndexKey));
		}
		
		
		~colcatArchivo(){
			mCol = null;
		}
	
	
	public bool fncValidaInformacionB( string cadenaPathFile)
	{
			
			bool result = false;
			string slNombreErr = String.Empty;
			string slNombre = String.Empty;
			string slRfcProc = String.Empty;
			string slNumNomEje = String.Empty;
			string slCenCosEje = String.Empty;
			string slNomGra = String.Empty;
			string slCalleEnvio = String.Empty;
			string slColEnvio = String.Empty;
			string slPobEnvio = String.Empty;
			string slTelDomEjecutivo = String.Empty;
			string slTelOfnaEjecutivo = String.Empty;
			string slExtOfnaEjecutivo = String.Empty;
			string slTelFaxEjecutivo = String.Empty;
			string slSexo = String.Empty;
			string slEdoEnvio = String.Empty;
			string slDomCalleEje = String.Empty;
			string slDomColEje = String.Empty;
			string slDomCiuEje = String.Empty;
			string slDomPob = String.Empty;
			string slDomEdo = String.Empty;
			string slEMail = String.Empty;
			string slCtaCtble = String.Empty;
			string slNacional = String.Empty;
			string slejeStatus = String.Empty;
			string slCuentaControl = String.Empty;
			string Producto = String.Empty;
			string slCtaBnx = String.Empty;
			string slSucTrans = String.Empty;
			string slSucProm = String.Empty;
			string slOrig = String.Empty;
			string slTipoCta = String.Empty;
			string slIndLimDisp = String.Empty;
			bool blTransmitir = false;
			bool blResNumReg = false;
			bool blResGrabaArreglo = false;
			bool bColorCambiado = false;
			int ilEjeDigit = 0;
			int ilNivEje = 0;
			int ilLimDispoEfe = 0;
			int ilSkipPayment = 0;
			int ilGenPlaPin = 0;
			int ilCamposProcOk = 0;
			int ilRoll_Over = 0;
			int slReg = 0;
			int ilStatusRegistro = 0;
			int iCountRow = 0;
			int ilNumeroReg = 0;
			int llResUnit = 0;
			int iFlood_0 = 0;
			int iFlood_1 = 0;
			int iTempRow = 0;
			int iTempField = 0;
			int ilTipoBloqueo = 0;
			int llEjeNum = 0;
			int llCodPosEnvio = 0;
			int llLimCreEjecutivo = 0;
			int llDomCodPos = 0;
			int grbProducto = 0;
			int llRegistrosArch = 0;
			int llSueldoEje = 0;
			
			string slAtencionA = String.Empty; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
			int ilPersona = 0; //FSWB NR 20070222
			
			try
			{
					
					blTransmitir = true;
					
					result = false;
					
					//Asignando valores para el uso de la barra de progreso de campo
					bColorCambiado = true;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodType = Threed.enumFloodTypeConstants._LeftToRight;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodShowPct = true;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent = (short) CORVB.NULL_INTEGER;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].ForeColor = Color.Black;
					
					//Asignando valores para el uso de la barra de progreso de registro
					frmAltasMasivas.DefInstance.pnlProgProceso[1].FloodType = Threed.enumFloodTypeConstants._LeftToRight;
					frmAltasMasivas.DefInstance.pnlProgProceso[1].FloodShowPct = true;
					frmAltasMasivas.DefInstance.pnlProgProceso[1].FloodPercent = (short) CORVB.NULL_INTEGER;
					frmAltasMasivas.DefInstance.pnlProgProceso[1].ForeColor = Color.Black;
					
					
					//Constantes para el proceso de altas masivas
					slReg = 1; //Region
					slSucTrans = "137"; //Sucursal Transmisora
					slSucProm = "137"; //Sucursal Promotora
					slOrig = "E"; //Origen
					ilRoll_Over = 9; //RollOver
					ilNivEje = 0; //Nivel Ejecutivo
					mdlParametros.llZonaPos = 0; //Zona Postal
					slCtaBnx = new String(' ', 1); //Cuenta Banamex
					slTipoCta = "I"; //Tipo Cuenta
					slIndLimDisp = "P"; //Indicador Limite de Disposicion
					llEjeNum = 0; //Ejecutivo Numero se calcula al enviar el alta
					ilEjeDigit = 0; //Ejecutivo Digito se calcula al enviar el alta
					ilStatusRegistro = 0; //Estatus del registro se va en 0
					
					if (! blTransmitir)
					{
						slejeStatus = "T";
					} else
					{
						slejeStatus = "N";
					}
					
					mdlParametros.llNumFile = FileSystem.FreeFile(); //Archivo a validar
					
					//Se abre el archivo a validar registros.
					FileSystem.FileOpen(mdlParametros.llNumFile, cadenaPathFile, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
					
					mdlParametros.llNumFileErr = FileSystem.FreeFile(); //Archivo que contendra los errores
					
					// Se abre el archivo donde se grabaran los errores que se detectaron en el archivo de altas masivas
                    //FileSystem.FileOpen(mdlParametros.llNumFileErr, Path.GetDirectoryName(Application.ExecutablePath) + "\\Archivo_Errores.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                    FileSystem.FileOpen(mdlParametros.llNumFileErr, Path.GetDirectoryName(Application.LocalUserAppDataPath) + "\\Archivo_Errores.txt", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
					
					//Se inicializa el contador de registros
					mdlParametros.llContReg = 0;
					
					//Proceso para contar registros a procesar y validar
					mdlParametros.llContReg = fncCountRegProL(mdlParametros.llNumFile);
					
					//Asigno el # de registros a la variable que almacena el tope de regisros a procesar
					//Se restan 2 para eleminar el HEADER y TRAILER
					mdlParametros.llContReg -= 2;
					
					//Se asigna a la variable iTempRow el numero de registros a procesar para la barra de progreso.
					iTempRow = mdlParametros.llContReg;
					
					//Funcion que permite validar el numeo de registos a procesar con los contenidos en el TRAILER final
					blResNumReg = fncValidaNumRegB(ref mdlParametros.slCadenaValidar, mdlParametros.llContReg, mdlParametros.llNumFile);
					if (! blResNumReg)
					{
						MessageBox.Show("No es el mismo numero de registros que contienen el archivo: " + mdlParametros.llContReg.ToString() + " con el reportado en el TRAILER: " + llRegistrosArch.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						FileSystem.WriteLine(mdlParametros.llNumFileErr, "No es el mismo numero de registros que contienen el archivo: " + mdlParametros.llContReg.ToString() + " con el reportado en el TRAILER: " + llRegistrosArch.ToString());
						return false;
					}
					
					//Se redimenciona el arreglo que guardara los registros
					mdlParametros.slRegs = ArraysHelper.InitializeArray<string[, ]>(new int[]{mdlParametros.llContReg + 1, 33}, new int[]{0, 0}); //FSWB NR 20070222
					
					mdlParametros.llContReg = 0;
					
					mdlParametros.ilIndice = 0;
					
					//Se abre nuevamente el archivo para lectura
					FileSystem.FileOpen(mdlParametros.llNumFile, cadenaPathFile, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
					
					//Funcion para almacenar los registros leidos del archivo de texto en el arreglo slRegs
					blResGrabaArreglo = fncGrabaArregloRegB(mdlParametros.llNumFile);
					if (! blResGrabaArreglo)
					{
						MessageBox.Show("No se pudo crear el arreglo para procesar los registros de altas masivas", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
						FileSystem.WriteLine(mdlParametros.llNumFileErr, "No se pudo crear el arreglo para procesar los registros de altas masivas ");
						result = false;
						FileSystem.FileClose(mdlParametros.llNumFile);
						FileSystem.FileClose(mdlParametros.llNumFileErr);
						return result;
					}
					
					mdlParametros.ilNumero = 0;
					mdlParametros.ilIndiceA = 0;
					mdlParametros.ilIndiceB = 0;
					mdlParametros.llConColumna = 0;
					iCountRow = 0;
					
					mdlParametros.Llena_subactividad(mdlParametros.llemp_sector);
					
					frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = true;
					frmAltasMasivas.DefInstance.pnlProgProceso[1].Visible = true;
					
					mdlParametros.blGrabarMTCMVS01 = true;
					
					iTempField = 33; //FSWB NR 20070222 Se agregan 3 campos cambió de 31 a 33
					
					frmAltasMasivas.DefInstance.lblMensaje.Visible = false;
					
					frmAltasMasivas.DefInstance.lblCamp.Visible = true;
					frmAltasMasivas.DefInstance.lblNumCampo[0].Visible = true;
					frmAltasMasivas.DefInstance.Label1[0].Visible = true;
					frmAltasMasivas.DefInstance.lblNumCampo[1].Visible = true;
					frmAltasMasivas.DefInstance.lblRegistro.Visible = true;
					frmAltasMasivas.DefInstance.lblNumRegistro[0].Visible = true;
					frmAltasMasivas.DefInstance.Label1[1].Visible = true;
					frmAltasMasivas.DefInstance.lblNumRegistro[1].Visible = true;
					frmAltasMasivas.DefInstance.lblNumCampo[1].Text = iTempField.ToString();
					frmAltasMasivas.DefInstance.lblNumRegistro[1].Text = mdlParametros.slRegs.GetUpperBound(0).ToString();
					
					for (mdlParametros.ilIndiceA = 0; mdlParametros.ilIndiceA <= mdlParametros.slRegs.GetUpperBound(0) - 1; mdlParametros.ilIndiceA++)
					{
						ilNumeroReg = 1 + StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 1, 4));
						frmAltasMasivas.DefInstance.lblNumRegistro[0].Text = ilNumeroReg.ToString();
						iFlood_0 = 0;
						
						for (mdlParametros.llConColumna = 0; mdlParametros.llConColumna <= mdlParametros.ilTotalColumnas; mdlParametros.llConColumna++)
						{
							mdlParametros.ilNumero = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 5, 2));
							frmAltasMasivas.DefInstance.lblNumCampo[0].Text = (mdlParametros.ilNumero + 1).ToString();
							iFlood_0 = Convert.ToInt32(Math.Floor(((mdlParametros.ilNumero + 1) / ((double) iTempField)) * 100));
							frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent = (short) iFlood_0;
							if (frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent > 1)
							{
								frmAltasMasivas.DefInstance.pnlProgProceso[0].ForeColor = Color.White;
								bColorCambiado = true;
							}
							Application.DoEvents();
							
							switch(mdlParametros.ilNumero)
							{
								case 0 :  //Nombre ejecutivo 
									slNombreErr = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7); 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "@");
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Nombre ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 45)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Nombre ejecutivo no es valida es mayor a la establecido en la tabla que son 45 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slNombre = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 1 :  //RFC ejecutivo 
									mdlParametros.garcAltasMasivas.ArchEjeRFC = new clsRFC(); 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam2 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam2, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo RFC ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										slRfcProc = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7);
										if (! mdlParametros.garcAltasMasivas.ArchEjeRFC.fncValidaRFCB(slRfcProc, clsRFC.enuTipoPersona.tprPersonaFisica))
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " El Campo RFC ejecutivo no es valido");
											mdlParametros.blGrabarMTCMVS01 = false;
										} else
										{
											mdlParametros.garcAltasMasivas.ArchEjeRFC.RFCS = slRfcProc;
											ilCamposProcOk++;
										}
									} 
									 
									break;
								case 2 :  //Sueldo ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam3 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam3, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Sueldo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 6)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Sueldo ejecutivo no es valida es mayor a la establecido en la tabla que son 6 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										llSueldoEje = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim());
										ilCamposProcOk++;
									} 
									 
									break;
								case 3 :  // Num. Nomina ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam4 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam4, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Campo Num. Nomina ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 15)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Num. Nomina ejecutivo no es valida es mayor a la establecido en la tabla que son 15 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slNumNomEje = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 4 :  //Centro de Costo ejecutivo 
									 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1).Trim();
										//Clemente Muñoz: Se quito está validacion
										//porque si en el centro de costos aparece
										//un valor como 202 o algo parecido el sistema no lo envia
										
										//If slCaracter = "0" And Not blResValidacion Then
										
										//    slCenCosEje = ""
										//    blResValidacion = False
										//    ilCamposProcOk = ilCamposProcOk + 1
										//    Exit For
										//Else
										
										int tempRefParam5 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam5, CRSGeneral.cteValidaciones.cteValEntero, false, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Centro de costo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
										//End If
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 15)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Centro de Costo ejecutivo no es valida es mayor a la establecido en la tabla que son 15 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										System.DateTime TempDate = DateTime.FromOADate(0);
										slCenCosEje = (DateTime.TryParse(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim(), out TempDate)) ? TempDate.ToString(""): Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										//Quita los ceros a la izquierda que puedan existir
										llResUnit = 1;
										foreach (string slUnit_item in mdlParametros.slUnit)
										{
											if (slCenCosEje == slUnit_item)
											{
												llResUnit = 0;
												break;
											}
										}
										if (llResUnit > 0)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La unidad que contiene el registro no se encuentra dada de alta");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										ilCamposProcOk++;
									} 
									 
									break;
								case 5 :  //Nombre a grabar ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam6 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam6, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, ",/@");
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Nombre a grabar ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											ilCamposProcOk++;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										string tempRefParam7 = mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Trim();
										if (! fncVerificaNombreB(ref tempRefParam7))
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Nombre a grabar ejecutivo no cumple con el formato diseñado para este campo");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 26)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Nombre a grabar ejecutivo no es valida es mayor a la establecido en la tabla que son 26 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slNomGra = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 6 :  //Calle envio 
									mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC = new clsDomicilio(); 
									if (mdlParametros.slemp_tipo_envio == "E")
									{
										mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.DomicilioS = mdlParametros.slemp_envio_calle;
										ilCamposProcOk++;
									} else
									{
										for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
										{
											mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
											int tempRefParam8 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam8, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Calle envio ejecutivo contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
                                            Application.DoEvents();
										}
										if (mdlParametros.blResValidacion)
										{
											if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 35)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Calle envio ejecutivo no es valida es mayor a la establecido en la tabla que son 35 caracteres");
												mdlParametros.blGrabarMTCMVS01 = false;
											}
											mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.DomicilioS = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
											ilCamposProcOk++;
										}
									} 
									 
									break;
								case 7 :  //Colonia envio 
									if (mdlParametros.slemp_tipo_envio == "E")
									{
										mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.ColoniaS = mdlParametros.slemp_envio_col;
										ilCamposProcOk++;
									} else
									{
										for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
										{
											mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
											int tempRefParam9 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam9, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Colonia envio ejecutivo contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
                                            Application.DoEvents();
										}
										if (mdlParametros.blResValidacion)
										{
											if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 25)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Colonia envio ejecutivo no es valida es mayor a la establecido en la tabla que son 25 caracteres");
												mdlParametros.blGrabarMTCMVS01 = false;
											}
											mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.ColoniaS = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
											ilCamposProcOk++;
										}
									} 
									 
									break;
								case 8 :  //Poblacion envio 
									if (mdlParametros.slemp_tipo_envio == "E")
									{
										mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.PoblacionS = mdlParametros.slemp_envio_pob;
										ilCamposProcOk++;
									} else
									{
										for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
										{
											mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
											int tempRefParam10 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam10, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Poblacion envio ejecutivo contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
                                            Application.DoEvents();
										}
										if (mdlParametros.blResValidacion)
										{
											if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 25)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Poblacion envio ejecutivo no es valida es mayor a la establecido en la tabla que son 25 caracteres");
												mdlParametros.blGrabarMTCMVS01 = false;
											}
											mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.PoblacionS = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
											ilCamposProcOk++;
										}
									} 
									 
									break;
								case 9 :  //Codigo Postal envio 
									if (mdlParametros.slemp_tipo_envio == "E")
									{
										mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.CPL = Int32.Parse(mdlParametros.slemp_envio_cp);
										ilCamposProcOk++;
									} else
									{
										for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
										{
											mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
											int tempRefParam11 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam11, CRSGeneral.cteValidaciones.cteValEntero, false, false);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Codigo Postal envio ejecutivo contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
                                            Application.DoEvents();
										}
										if (mdlParametros.blResValidacion)
										{
											if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 5)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Codigo Postal envio ejecutivo no es valida es mayor a la establecido en la tabla que son 5 caracteres");
												mdlParametros.blGrabarMTCMVS01 = false;
											}
											mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.CPL = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7));
											ilCamposProcOk++;
										}
									} 
									 
									break;
								case 10 :  //Tel. Dom. ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam12 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam12, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Tel. Dom. ejecutivo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 10)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Tel. Dom. ejecutivo no es valida es mayor a la establecido en la tabla que son 10 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										} else
										{
											slTelDomEjecutivo = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
											ilCamposProcOk++;
										}
									} 
									 
									break;
								case 11 :  //Tel. Ofna. ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam13 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam13, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Tel. Ofna. ejecutivo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 10)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Tel. Ofna. ejecutivo no es valida es mayor a la establecido en la tabla que son 10 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slTelOfnaEjecutivo = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 12 :  //Ext. Ofna. ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam14 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam14, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Ext. Ofna. ejecutivo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 8)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Ext. Ofna. ejecutivo no es valida es mayor a la establecido en la tabla que son 8 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slExtOfnaEjecutivo = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 13 :  //Tel. Fax ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam15 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam15, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Tel. Fax ejecutivo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 15)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Tel. Fax ejecutivo no es valida es mayor a la establecido en la tabla que son 15 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slTelFaxEjecutivo = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7)).ToString();
										ilCamposProcOk++;
									} 
									 
									break;
								case 14 :  //Limite Credito ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam16 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam16, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Limite Credito ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 6)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Limite Credito ejecutivo no es valida es mayor a la establecido en la tabla que son 6 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										llLimCreEjecutivo = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7));
										ilCamposProcOk++;
									} 
									 
									break;
								case 15 :  //Sexo ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam17 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam17, CRSGeneral.cteValidaciones.cteValAlfabetico, true, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Sexo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 1)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Sexo ejecutivo no es valida es mayor a la establecido en la tabla que es 1 caracter");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slSexo = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 16 :  //Estado envio 
									if (mdlParametros.slemp_tipo_envio == "E")
									{
										slEdoEnvio = mdlParametros.slemp_envio_edo;
										mdlParametros.ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(slEdoEnvio);
										if (mdlParametros.ilIndice > 0)
										{
											mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.EstadoEST = mdlParametros.gcestEstado[mdlParametros.ilIndice];
											ilCamposProcOk++;
										}
									} else
									{
										for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
										{
											mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
											int tempRefParam18 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam18, CRSGeneral.cteValidaciones.cteValAlfabetico, true, false);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Estado envio ejecutivo contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
                                            Application.DoEvents();
										}
										if (mdlParametros.blResValidacion)
										{
											slEdoEnvio = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
											mdlParametros.ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(slEdoEnvio);
											if (mdlParametros.ilIndice > 0)
											{
												mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC.EstadoEST = mdlParametros.gcestEstado[mdlParametros.ilIndice];
											} else
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " El Campo Estado envio ejecutivo no es valido");
												mdlParametros.blGrabarMTCMVS01 = false;
											}
											ilCamposProcOk++;
										} else
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " El Campo Estado envio ejecutivo no es valido");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
									} 
									 
									break;
								case 17 :  //Dom. calle ejecutivo 
									mdlParametros.garcAltasMasivas.ArchEjeDomPartDMC = new clsDomicilio(); 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam19 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam19, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Dom. calle ejecutivo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 35)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Dom. calle ejecutivo no es valida es mayor a la establecido en la tabla que son 35 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slDomCalleEje = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										mdlParametros.garcAltasMasivas.ArchEjeDomPartDMC.DomicilioS = slDomCalleEje;
										ilCamposProcOk++;
									} 
									 
									break;
								case 18 :  //Dom. colonia ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam20 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam20, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Dom. colonia ejecutivo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 25)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Dom. colonia ejecutivo no es valida es mayor a la establecido en la tabla que son 25 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slDomColEje = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										mdlParametros.garcAltasMasivas.ArchEjeDomPartDMC.ColoniaS = slDomColEje;
										ilCamposProcOk++;
									} 
									 
									break;
								case 19 :  //Dom. ciudad ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam21 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam21, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Dom. ciudad ejecutivo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 25)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Dom. ciudad ejecutivo no es valida es mayor a la establecido en la tabla que son 25 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slDomCiuEje = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										mdlParametros.garcAltasMasivas.ArchEjeDomPartDMC.CiudadS = slDomCiuEje;
										ilCamposProcOk++;
									} 
									 
									break;
								case 20 :  //Dom. poblacion ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam22 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam22, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Dom. poblacion ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 25)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Dom. poblacion ejecutivo no es valida es mayor a la establecido en la tabla que son 25 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slDomPob = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										mdlParametros.garcAltasMasivas.ArchEjeDomPartDMC.PoblacionS = slDomPob;
										ilCamposProcOk++;
									} 
									 
									break;
								case 21 :  //Dom. estado ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam23 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam23, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Dom. estado ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										slDomEdo = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										mdlParametros.ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(slDomEdo);
										if (mdlParametros.ilIndice > 0)
										{
											mdlParametros.garcAltasMasivas.ArchEjeDomPartDMC.EstadoEST = mdlParametros.gcestEstado[mdlParametros.ilIndice];
										} else
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " El Campo Estado envio ejecutivo no es valido");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										ilCamposProcOk++;
									} else
									{
										FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " El Campo Estado envio ejecutivo no es valido");
										mdlParametros.blGrabarMTCMVS01 = false;
									} 
									 
									break;
								case 22 :  //Dom. codigo postal ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam24 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam24, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Dom. codigo postal ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 5)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Dom. codigo postal ejecutivo no es valida es mayor a la establecido en la tabla que son 5 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										llDomCodPos = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7));
										mdlParametros.garcAltasMasivas.ArchEjeDomPartDMC.CPL = llDomCodPos;
										ilCamposProcOk++;
									} 
									 
									break;
								case 23 :  //Limite Dispo. Efectivo ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam25 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam25, CRSGeneral.cteValidaciones.cteValEntero, true, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Limite Dispo. Efectivo ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 4)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Limite Dispo. Efectivo ejecutivo ejecutivo no es valida es mayor a la establecido en la tabla que es 4 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										ilLimDispoEfe = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7));
										ilCamposProcOk++;
									} 
									 
									break;
								case 24 :  //Nacionalidad ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam26 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam26, CRSGeneral.cteValidaciones.cteValEntero, false, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Nacionalidad ejecutivo contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 1)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Nacionalidad ejecutivo no es valida es mayor a la establecido en la tabla que es 1 caracter");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
                                        //AIS-119 NGONZALEZ
										switch(Convert.ToInt32(StringsHelper.DoubleValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim())))
										{
											case 1 : 
												slNacional = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim(); 
												ilCamposProcOk++; 
												break;
											case 2 : 
												slNacional = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim(); 
												ilCamposProcOk++; 
												break;
											default:
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " el Campo Nacionalidad ejecutivo no es valido pued ser 1 (Mexicana) ó 2 (Extranjero)"); 
												mdlParametros.blGrabarMTCMVS01 = false; 
												break;
										}
									} 
									 
									break;
								case 25 :  //Skip payment 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										if (Conversion.Val(mdlParametros.slCaracter) == 0 || Conversion.Val(mdlParametros.slCaracter) == 1)
										{
											int tempRefParam27 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam27, CRSGeneral.cteValidaciones.cteValEntero, false, false);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo skip payment  contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
										} else
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Skip Payment contiene valores no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (mdlParametros.slemp_tipo_fac == "C")
										{
											ilSkipPayment = 0;
										} else
										{
											ilSkipPayment = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7));
										}
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Length > 1)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Skip Payment no es valida es mayor a la establecido en la tabla que es 1 caracter");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										ilCamposProcOk++;
									} 
									 
									break;
								case 26 :  //Genera PIN/PLASTICO 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										if (Conversion.Val(mdlParametros.slCaracter) == 0 || Conversion.Val(mdlParametros.slCaracter) == 1 || Conversion.Val(mdlParametros.slCaracter) == 2)
										{
											int tempRefParam28 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam28, CRSGeneral.cteValidaciones.cteValEntero, false, false);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Genera PIN/PLASTICO  contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
										} else
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Genera PIN/PLASTICO contiene valores no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										switch(mdlParametros.slCaracter.Trim())
										{
											case "1" : 
												slCuentaControl = "C"; 
												ilGenPlaPin = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7)); 
												break;
											case "0" : 
												slCuentaControl = ""; 
												ilGenPlaPin = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7)); 
												break;
											case "2" : 
												slCuentaControl = ""; 
												ilGenPlaPin = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7)); 
												break;
										}
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Length > 1)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Genera PIN/PLASTICO no es valida es mayor a la establecido en la tabla que es 1 caracter");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										ilCamposProcOk++;
									} 
									 
									break;
								case 27 :  //Codigo MCC 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										int tempRefParam29 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam29, CRSGeneral.cteValidaciones.cteValEntero, false, false);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Codigo MCC contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 1)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Codigo MCC no es valida es mayor a la establecido en la tabla que es 1 caracter");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										mdlParametros.llemp_tabla_mcc = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7));
										ilCamposProcOk++;
									} 
									 
									break;
								case 28 :  //Email ejecutivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										if (mdlParametros.slCaracter == " ")
										{
											slEMail = mdlParametros.slCaracter;
											mdlParametros.blResValidacion = false;
											ilCamposProcOk++;
											break;
										} else
										{
											int tempRefParam30 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam30, CRSGeneral.cteValidaciones.cteValCorreoElectrónico, false, false);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Email ejecutivo contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 70)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Email ejecutivo no es valida es mayor a la establecido en la tabla que son 70 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slEMail = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 29 :  //Cuenta Ctble. ejecuivo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										if (mdlParametros.slCaracter == " ")
										{
											slCtaCtble = mdlParametros.slCaracter;
											mdlParametros.blResValidacion = false;
											ilCamposProcOk++;
											break;
										} else
										{
											int tempRefParam31 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam31, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Cuenta Ctble. ejecutivo contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 40)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Cuenta Ctble. ejecutivo no es valida es mayor a la establecido en la tabla que son 40 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slCtaCtble = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 30 :  //Tipo de Bloqueo 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										if (Conversion.Val(mdlParametros.slCaracter) == 0 || Conversion.Val(mdlParametros.slCaracter) == 1 || Conversion.Val(mdlParametros.slCaracter) == 2)
										{
											int tempRefParam32 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam32, CRSGeneral.cteValidaciones.cteValEntero, false, false);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Genera PIN/PLASTICO  contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
										} else
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Genera PIN/PLASTICO contiene valores no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										ilTipoBloqueo = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7));
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Length > 1)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Genera PIN/PLASTICO no es valida es mayor a la establecido en la tabla que es 1 caracter");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										ilCamposProcOk++;
									} 
									 
									//FSWB NR 20070222 Se agrego el leer valores de campos Atencion A y Persona, col. 31 y 32 
									//***** INICIO MODIF. FSWB NR 20070222 
									break;
								case 31 :  //Atencion A 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										//                    If slCaracter = " " Then 'FSWB NR 20070330 Se eliminó esta condición porque no permitia espacios
										//                        slAtencionA = slCaracter
										//                        blResValidacion = False
										//                        ilCamposProcOk = ilCamposProcOk + 1
										//                        Exit For
										//                    Else
										int tempRefParam33 = (int) mdlParametros.slCaracter[0];
										mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam33, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true);
										if (! mdlParametros.blResValidacion)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Atencion A contiene caracteres no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
										//                        End If
									} 
									if (mdlParametros.blResValidacion)
									{
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim().Length > 45)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Atencion A no es valida es mayor a la establecido en la tabla que son 45 caracteres");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										slAtencionA = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Trim();
										ilCamposProcOk++;
									} 
									 
									break;
								case 32 :  //Persona 
									for (mdlParametros.ilIndiceB = 7; mdlParametros.ilIndiceB <= mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna].Length; mdlParametros.ilIndiceB++)
									{
										mdlParametros.slCaracter = Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], mdlParametros.ilIndiceB, 1);
										if (Conversion.Val(mdlParametros.slCaracter) == 1 || Conversion.Val(mdlParametros.slCaracter) == 2 || Conversion.Val(mdlParametros.slCaracter) == 3)
										{
											int tempRefParam34 = (int) mdlParametros.slCaracter[0];
											mdlParametros.blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam34, CRSGeneral.cteValidaciones.cteValEntero, false, false);
											if (! mdlParametros.blResValidacion)
											{
												FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Persona  contiene caracteres no validos");
												mdlParametros.blGrabarMTCMVS01 = false;
												break;
											}
										} else
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " Campo Persona contiene valores no validos");
											mdlParametros.blGrabarMTCMVS01 = false;
											break;
										}
                                        Application.DoEvents();
									} 
									if (mdlParametros.blResValidacion)
									{
										ilPersona = StringsHelper.IntValue(Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7));
										if (Strings.Mid(mdlParametros.slRegs[mdlParametros.ilIndiceA, mdlParametros.llConColumna], 7).Length > 1)
										{
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "Numero de registro: " + ilNumeroReg.ToString().Trim() + " Nombre : " + slNombreErr + " La longitud del Campo Persona no es valida es mayor a la establecido en la tabla que es 1 caracter");
											mdlParametros.blGrabarMTCMVS01 = false;
										}
										ilCamposProcOk++;
									} 
									//***** FIN MODIF. FSWB NR 20070222 
									break;
							}
						}
						
						mdlParametros.slSubActividad = Strings.Mid(mdlParametros.slSubActividad, 1, 2);
						
						this.Add(mdlParametros.gprdProducto, mdlParametros.llemp_num, llEjeNum, ilRoll_Over, ilEjeDigit, slNombre, mdlParametros.garcAltasMasivas.ArchEjeRFC, llSueldoEje, slNumNomEje, slCenCosEje, ilNivEje, slNomGra, mdlParametros.garcAltasMasivas.ArchEjeDomEnvioDMC, slTelDomEjecutivo, slTelOfnaEjecutivo, slExtOfnaEjecutivo, slTelFaxEjecutivo, llLimCreEjecutivo, slReg, slejeStatus, slCtaBnx, slSexo, slSucTrans, slSucProm, slOrig, mdlParametros.slSubActividad, mdlParametros.garcAltasMasivas.ArchEjeDomPartDMC, slEMail, slCtaCtble, ilGenPlaPin, ilLimDispoEfe, slTipoCta, mdlParametros.slemp_tipo_fac, ilSkipPayment, mdlParametros.llemp_tabla_mcc, slIndLimDisp, slCuentaControl, slNacional, ilStatusRegistro, ilTipoBloqueo, slAtencionA, ilPersona); //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
						
						
						mdlParametros.llConColumna = 0;
						ilCamposProcOk = 0;
						
						//Limpio variables para proximo registro
						slNombre = "";
						slRfcProc = "";
						llSueldoEje = 0;
						slNumNomEje = "";
						slCenCosEje = "";
						slNomGra = "";
						slCalleEnvio = "";
						slColEnvio = "";
						slPobEnvio = "";
						llCodPosEnvio = 0;
						slTelDomEjecutivo = "";
						slTelOfnaEjecutivo = "";
						slExtOfnaEjecutivo = "";
						slTelFaxEjecutivo = "";
						llLimCreEjecutivo = 0;
						slSexo = "";
						slEdoEnvio = "";
						slDomCalleEje = "";
						slDomColEje = "";
						slDomCiuEje = "";
						slDomPob = "";
						slDomEdo = "";
						llDomCodPos = 0;
						slEMail = "";
						slCtaCtble = "";
						ilGenPlaPin = 0;
						ilLimDispoEfe = 0;
						ilSkipPayment = 0;
						slIndLimDisp = "";
						slCuentaControl = "";
						slNacional = "";
						ilStatusRegistro = 0;
						ilTipoBloqueo = 0;
						slAtencionA = ""; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
						ilPersona = 2; //Default persona fisica  'FSWB NR 20070222
						
						iCountRow = ilNumeroReg;
						
						iFlood_1 = Convert.ToInt32(Math.Floor((iCountRow / ((double) iTempRow)) * 100));
						frmAltasMasivas.DefInstance.pnlProgProceso[1].FloodPercent = (short) iFlood_1;
						if (frmAltasMasivas.DefInstance.pnlProgProceso[1].FloodPercent > 1)
						{
							frmAltasMasivas.DefInstance.pnlProgProceso[1].ForeColor = Color.White;
							bColorCambiado = true;
						}
						Application.DoEvents();
						
					}
					
					iFlood_0 = 0;
					iFlood_1 = 0;
					
					FileSystem.FileClose(mdlParametros.llNumFile);
					FileSystem.FileClose(mdlParametros.llNumFileErr);
					
					
					result = mdlParametros.blGrabarMTCMVS01;
					
					mdlParametros.prQuitaObjetos();
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ValidaInformacion)",e);
				result = false;
				FileSystem.FileClose(mdlParametros.llNumFile);
				FileSystem.FileClose(mdlParametros.llNumFileErr);
				
				mdlParametros.prQuitaObjetos();
				return result;
			}
			
			return result;
	}
	
	public bool fncValidaHeaderB(ref  string prCadenaValidar,  int prNumFileErr)
	{
			
			bool result = false;
			int llPos = 0;
			int ilIndice = 0;
			string slCadena = String.Empty;
			string slCaracter = String.Empty;
			int ilNumero = 0;
			bool blResValidacion = false;
			string slheader = String.Empty;
			int llRegistros = 0;
			int llLongCadena = 0;
			string slIndice = String.Empty;
			
			try
			{
					
					result = true;
					
					mdlParametros.ilpgs_long_emp = mdlParametros.gprdProducto.LongitudEmpresaI;
					llPos = 1;
					ilIndice = 0;
					
					string[] slRegsHea = new string[]{String.Empty};
					llLongCadena = prCadenaValidar.Length;
					
					while(prCadenaValidar != "")
					{
						slCadena = fncSubstraerInformationS(ref llPos, ref prCadenaValidar);
						if (slCadena != "")
						{
							slRegsHea = ArraysHelper.RedimPreserve<string[]>(slRegsHea, new int[]{ilIndice + 1});
							if (ilIndice.ToString().Length == 1)
							{
								slIndice = "0" + Conversion.Str(ilIndice).Trim();
							} else
							{
								slIndice = Conversion.Str(ilIndice);
							}
							slRegsHea[ilIndice] = slIndice + slCadena;
							ilIndice++;
						} else
						{
							break;
						}
					};
					
					foreach (string slRegsHea_item in slRegsHea)
					{
						ilNumero = StringsHelper.IntValue(Strings.Mid(slRegsHea_item, 1, 2));
						switch(ilNumero)
						{
							case 0 :  //HEADER 
								for (int ilIndiceB = 3; ilIndiceB <= slRegsHea_item.Length; ilIndiceB++)
								{
									slCaracter = Strings.Mid(slRegsHea_item, ilIndiceB, 1);
									int tempRefParam = (int) slCaracter[0];
									blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam, CRSGeneral.cteValidaciones.cteValAlfabetico, true, false);
									if (! blResValidacion)
									{
										FileSystem.WriteLine(prNumFileErr, " Campo header contiene caracteres no validos");
										break;
									}
								} 
								if (blResValidacion)
								{
									slheader = Strings.Mid(slRegsHea_item, 3);
								} 
								 
								break;
							case 1 :  //Cuenta referencia 
								for (int ilIndiceB = 3; ilIndiceB <= slRegsHea_item.Length; ilIndiceB++)
								{
									slCaracter = Strings.Mid(slRegsHea_item, ilIndiceB, 1);
									int tempRefParam2 = (int) slCaracter[0];
									blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam2, CRSGeneral.cteValidaciones.cteValEntero, false, false);
									if (! blResValidacion)
									{
										FileSystem.WriteLine(prNumFileErr, " Campo Cuenta referencia contiene caracteres no validos");
										break;
									}
								} 
								if (blResValidacion)
								{
									
									mdlParametros.slctaref = Strings.Mid(slRegsHea_item, 3);
								} 
								 
								break;
							case 2 :  //Fecha Archivo 
								for (int ilIndiceB = 3; ilIndiceB <= slRegsHea_item.Length; ilIndiceB++)
								{
									slCaracter = Strings.Mid(slRegsHea_item, ilIndiceB, 1);
									int tempRefParam3 = (int) slCaracter[0];
									blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam3, CRSGeneral.cteValidaciones.cteValFecha, false, false);
									if (! blResValidacion)
									{
										FileSystem.WriteLine(prNumFileErr, " Campo Fecha del Archivo contiene caracteres no validos");
										break;
									}
								} 
								if (blResValidacion)
								{
									mdlParametros.llfecarch = StringsHelper.IntValue(Strings.Mid(slRegsHea_item, 3));
								} 
								 
								break;
							case 3 :  // Monto limite de credito 
								for (int ilIndiceB = 3; ilIndiceB <= slRegsHea_item.Length; ilIndiceB++)
								{
									slCaracter = Strings.Mid(slRegsHea_item, ilIndiceB, 1);
									int tempRefParam4 = (int) slCaracter[0];
									blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam4, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
									if (! blResValidacion)
									{
										FileSystem.WriteLine(prNumFileErr, " Campo Monto Limite de Credito contiene caracteres no validos");
										break;
									}
								} 
								if (blResValidacion)
								{
									mdlParametros.llmontCred = StringsHelper.IntValue(Strings.Mid(slRegsHea_item, 3));
								} 
								break;
						}
					}
					
					if (StringsHelper.DoubleValue(Strings.Mid(mdlParametros.slctaref, 1, 4)) != mdlParametros.gprdProducto.PrefijoL)
					{
						MessageBox.Show("Eje prefijo leido de la linea HEADER del archivo no es igual al contenido en la aplicacion", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
						FileSystem.WriteLine(prNumFileErr, " Campo header contiene el producto: " + Strings.Mid(mdlParametros.slctaref, 1, 4) + " que no corresponde con el producto a procesar:" + mdlParametros.gprdProducto.PrefijoL.ToString());
						return false;
					}
					if (StringsHelper.DoubleValue(Strings.Mid(mdlParametros.slctaref, 5, 2)) != mdlParametros.gprdProducto.BancoL)
					{
						MessageBox.Show("Gpo banco leido de la linea HEADER del archivo no es igual al contenido en la aplicacion", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
						FileSystem.WriteLine(prNumFileErr, " Campo header contiene el banco: " + Strings.Mid(mdlParametros.slctaref, 5, 2) + " que no corresponde con el banco a procesar:" + mdlParametros.gprdProducto.BancoL.ToString());
						return false;
					}
					
					if (StringsHelper.DoubleValue(Strings.Mid(mdlParametros.slctaref, 7, mdlParametros.ilpgs_long_emp)) != CORVAR.lgblEmpCve)
					{
						MessageBox.Show("Numero de empresa leido de la linea HEADER del archivo no es igual al contenido en la aplicacion", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
						FileSystem.WriteLine(prNumFileErr, " Campo header contiene el numero de empresa: " + Strings.Mid(mdlParametros.slctaref, 7, mdlParametros.ilpgs_long_emp) + " que no corresponde con el numero de empresa a procesar:" + CORVAR.lgblEmpCve.ToString());
						return false;
					}
					
					
					return true;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ValidaInformacion,Validacion HEADER)",e );
				result = false;
				FileSystem.FileClose(mdlParametros.llNumFile);
				FileSystem.FileClose(mdlParametros.llNumFileErr);
				
				return result;
			}
			return result;
	}
	
	public bool fncValidaTrailerB(ref  string prCadena,  int prNumFileErr)
	{
			
			bool result = false;
			int llPos = 0;
			int ilIndice = 0;
			string slCadena = String.Empty;
			string slCaracter = String.Empty;
			int ilNumero = 0;
			bool blResValidacion = false;
			int llRegistros = 0;
			int llLongCadena = 0;
			string slIndice = String.Empty;
			string sltrailer = String.Empty;
			int llRegProc = 0;
			
			try
			{
					
					result = true;
					
					llPos = 1;
					ilIndice = 0;
					
					string[] slRegsTra = new string[]{String.Empty};
					llLongCadena = prCadena.Length;
					
					while(prCadena != "")
					{
						slCadena = fncSubstraerInformationS(ref llPos, ref prCadena);
						if (slCadena != "")
						{
							slRegsTra = ArraysHelper.RedimPreserve<string[]>(slRegsTra, new int[]{ilIndice + 1});
							if (ilIndice.ToString().Length == 1)
							{
								slIndice = "0" + Conversion.Str(ilIndice).Trim();
							} else
							{
								slIndice = Conversion.Str(ilIndice);
							}
							slRegsTra[ilIndice] = slIndice + slCadena;
							ilIndice++;
						} else
						{
							break;
						}
					};
					
					foreach (string slRegsTra_item in slRegsTra)
					{
						ilNumero = StringsHelper.IntValue(Strings.Mid(slRegsTra_item, 1, 2));
						switch(ilNumero)
						{
							case 0 :  //TRAILER 
								for (int ilIndiceB = 3; ilIndiceB <= slRegsTra_item.Length; ilIndiceB++)
								{
									slCaracter = Strings.Mid(slRegsTra_item, ilIndiceB, 1);
									int tempRefParam = (int) slCaracter[0];
									blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true);
									if (! blResValidacion)
									{
										FileSystem.WriteLine(prNumFileErr, " Campo Trailer contiene caracteres no validos");
										break;
									}
								} 
								if (blResValidacion)
								{
									sltrailer = Strings.Mid(slRegsTra_item, 3);
								} 
								break;
							case 1 :  //REGISTROS A PROCESAR 
								for (int ilIndiceB = 3; ilIndiceB <= slRegsTra_item.Length; ilIndiceB++)
								{
									slCaracter = Strings.Mid(slRegsTra_item, ilIndiceB, 1);
									int tempRefParam2 = (int) slCaracter[0];
									blResValidacion = fncValidaCaracterAltasMasivasB(ref tempRefParam2, CRSGeneral.cteValidaciones.cteValEntero, false, false);
									if (! blResValidacion)
									{
										FileSystem.WriteLine(prNumFileErr, " Campo Registros a procesar contiene caracteres no validos");
										break;
									}
								} 
								if (blResValidacion)
								{
									llRegProc = StringsHelper.IntValue(Strings.Mid(slRegsTra_item, 3));
								} 
								break;
						}
					}
					
					
					return true;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ValidaInformacion, Validacion TRAILER)",e );
				result = false;
				FileSystem.FileClose(mdlParametros.llNumFile);
				FileSystem.FileClose(mdlParametros.llNumFileErr);
				
				return result;
			}
			return result;
	}
	
	private int fncCountRegProL( int lpNumArch)
	{
			
			mdlParametros.llContReg = 0;
			
			while(! FileSystem.EOF(lpNumArch))
			{
				mdlParametros.slCadenaValidar = FileSystem.LineInput(lpNumArch);
				mdlParametros.llContReg++;
			};
			return mdlParametros.llContReg;
			
	}
	
	private bool fncValidaNumRegB(ref  string spCadena,  int lpRegistros,  int lpNumArch)
	{
			
			bool result = false;
			int ilPosicion = 0;
			int llRegistrosArch = 0;
			
			try
			{
					
					result = true;
					
					if (Strings.Mid(spCadena, 1, 7) == "TRAILER")
					{
						ilPosicion = (spCadena.IndexOf("\t") + 1);
						ilPosicion++;
						llRegistrosArch = Convert.ToInt32(Conversion.Val(Strings.Mid(spCadena, ilPosicion, 7)));
					}
					
					FileSystem.FileClose(lpNumArch);
					
					if (lpRegistros != llRegistrosArch)
					{
						result = false;
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ValidaInformacion, Valida Num. Registros)",e );
				result = false;
				FileSystem.FileClose(mdlParametros.llNumFile);
				FileSystem.FileClose(mdlParametros.llNumFileErr);
				
				return result;
			}
			
			return result;
	}
	
	private bool fncGrabaArregloRegB( int lpNumArch)
	{
			
			bool result = false;
			bool blResHeader = false;
			string slPrefijo = String.Empty;
			string slbanco = String.Empty;
			string slempresa = String.Empty;
			string slejedigit = String.Empty;
			bool blResTrailer = false;
			int llLongCadena = 0;
			string slContReg = String.Empty;
			string slColumna = String.Empty;
			
			try
			{
					
					result = true;
					
					dlbMonto = 0;
					
					
					while(! FileSystem.EOF(mdlParametros.llNumFile))
					{
						mdlParametros.slCadenaValidar = FileSystem.LineInput(mdlParametros.llNumFile);
						
						if (Strings.Mid(mdlParametros.slCadenaValidar, 1, 6) == "HEADER")
						{
							blResHeader = fncValidaHeaderB(ref mdlParametros.slCadenaValidar, mdlParametros.llNumFileErr);
							if (blResHeader)
							{
								slPrefijo = Strings.Mid(mdlParametros.slctaref, 1, 4).Trim();
								slbanco = Strings.Mid(mdlParametros.slctaref, 5, 2).Trim();
								slempresa = Strings.Mid(mdlParametros.slctaref, 7, mdlParametros.ilpgs_long_emp).Trim();
								slejedigit = mdlParametros.slctaref.Substring(mdlParametros.slctaref.Length - Math.Min(mdlParametros.slctaref.Length, 1));
								
								CORVAR.pszgblsql = "select a.eje_prefijo, a.gpo_banco, a.emp_num, a.gpo_num, a.emp_cred_tot,";
								CORVAR.pszgblsql = CORVAR.pszgblsql + "a.emp_envio_calle, a.emp_envio_col, a.emp_envio_ciu, a.emp_envio_pob,";
								CORVAR.pszgblsql = CORVAR.pszgblsql + "a.emp_envio_edo, a.emp_envio_cp, a.emp_tipo_envio, a.emp_tipo_fac,";
								//                pszgblsql = pszgblsql & "a.emp_skip_payment, a.emp_tabla_mcc, a.emp_sector, b.eje_roll_over, b.eje_digit, a.emp_acum_cred "
								// Modif. 18/Jun/2007 Calc Lim Real
								CORVAR.pszgblsql = CORVAR.pszgblsql + "a.emp_skip_payment, a.emp_tabla_mcc, a.emp_sector, b.eje_roll_over, b.eje_digit, ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(f.eje_limcred),0) from MTCEJE01 f ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " where f.eje_prefijo = " + slPrefijo;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and f.gpo_banco = " + slbanco;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and f.emp_num = " + slempresa;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and f.eje_num > 0) - ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = " + slPrefijo;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = " + slbanco;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + slempresa;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) as emp_acum_cred ";
								//                pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred "
								
								CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCEMP01 a, MTCEJE01 b ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + "where a.eje_prefijo=" + slPrefijo;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco= " + slbanco;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num=" + slempresa;
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo=b.eje_prefijo";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco=b.gpo_banco";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num=b.emp_num";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_num=0";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_digit= " + slejedigit;
								
								if (CORPROC2.Obtiene_Registros() == (-1))
								{
									
									while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
									{
										mdlParametros.lleje_prefijo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
										mdlParametros.llgpo_banco = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
										mdlParametros.llemp_num = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
										mdlParametros.llgpo_num = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
										mdlParametros.llemp_cred_tot = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 5));
										mdlParametros.slemp_envio_calle = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
										mdlParametros.slemp_envio_col = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim();
										mdlParametros.slemp_envio_ciu = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
										mdlParametros.slemp_envio_pob = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
										mdlParametros.slemp_envio_edo = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim();
										mdlParametros.slemp_envio_cp = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
										mdlParametros.slemp_tipo_envio = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim();
										mdlParametros.slemp_tipo_fac = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
										mdlParametros.llemp_skip_payment = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 14));
										mdlParametros.llemp_tabla_mcc = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 15));
										mdlParametros.llemp_sector = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 16));
										mdlParametros.llemp_roll_over = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 17));
										mdlParametros.llemp_digit = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 18));
										dblMontoAcum = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 19));
									};
									
									if (mdlParametros.llmontCred > mdlParametros.llemp_cred_tot)
									{
										MessageBox.Show("No se pueden dar altas masivas el monto del credito reportado en el archivo es mayor al de la Empresa", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
										FileSystem.WriteLine(mdlParametros.llNumFileErr, "No se pueden dar altas masivas el monto del credito reportado en el archivo es mayor al de la Empresa");
										return false;
									}
									
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
									
									CORVAR.pszgblsql = "select unit_id from MTCUNI01 ";
									CORVAR.pszgblsql = CORVAR.pszgblsql + "where eje_prefijo=" + slPrefijo;
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco= " + slbanco;
									CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + slempresa;
									CORVAR.pszgblsql = CORVAR.pszgblsql + " order by convert(float,unit_id)";
									
									mdlParametros.llRegUnit = CORPROC2.Cuenta_Registros();
									
									mdlParametros.slUnit = ArraysHelper.InitializeArray<string[]>(new int[]{mdlParametros.llRegUnit + 1}, new int[]{0});
									
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
									
									if (CORPROC2.Obtiene_Registros() == (-1))
									{
										for (int llcontador = 0; llcontador <= mdlParametros.slUnit.GetUpperBound(0); llcontador++)
										{
											VBSQL.SqlNextRow(CORVAR.hgblConexion);
											mdlParametros.slUnit[llcontador] = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
										}
									}
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
									
								} else
								{
									MessageBox.Show("No se pueden dar altas masivas no existe la Cuenta " + mdlParametros.slctaref, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
									FileSystem.WriteLine(mdlParametros.llNumFileErr, "No se pueden dar altas masivas no existe la Cuenta " + mdlParametros.slctaref);
									return false;
								}
							} else
							{
								return false;
							}
							
							//Se lee el siguiente registro despue el HEADER
							mdlParametros.slCadenaValidar = FileSystem.LineInput(mdlParametros.llNumFile);
						}
						
						if (Strings.Mid(mdlParametros.slCadenaValidar, 1, 7) == "TRAILER")
						{
							blResTrailer = fncValidaTrailerB(ref mdlParametros.slCadenaValidar, mdlParametros.llNumFileErr);
							break;
						}
						
						mdlParametros.llPos = 1;
						mdlParametros.llConColumna = 0;
						mdlParametros.ilTotalColumnas = 32; //FSWB NR 20070222 Se agregan 2 campos de 30 a 32
						llLongCadena = mdlParametros.slCadenaValidar.Length;
						
						
						while(mdlParametros.slCadenaValidar != "")
						{
							mdlParametros.slCadena = fncSubstraerInformationS(ref mdlParametros.llPos, ref mdlParametros.slCadenaValidar);
							if (mdlParametros.slCadena != "")
							{
								slContReg = StringsHelper.Format(Conversion.Str(mdlParametros.llContReg).Trim(), "0000");
								if (mdlParametros.llConColumna.ToString().Length == 1)
								{
									slColumna = "0" + Conversion.Str(mdlParametros.llConColumna).Trim();
								} else
								{
									slColumna = Conversion.Str(mdlParametros.llConColumna).Trim();
								}
								
								mdlParametros.slRegs[mdlParametros.ilIndice, mdlParametros.llConColumna] = slContReg + slColumna + mdlParametros.slCadena;
								for (mdlParametros.llConColumna = 1; mdlParametros.llConColumna <= mdlParametros.ilTotalColumnas; mdlParametros.llConColumna++)
								{
									mdlParametros.slCadena = fncSubstraerInformationS(ref mdlParametros.llPos, ref mdlParametros.slCadenaValidar);
									if (mdlParametros.llConColumna.ToString().Length == 1)
									{
										slColumna = "0" + Conversion.Str(mdlParametros.llConColumna).Trim();
									} else
									{
										slColumna = Conversion.Str(mdlParametros.llConColumna).Trim();
									}
									
									if (mdlParametros.llConColumna == 14)
									{
										dlbMonto += Double.Parse(mdlParametros.slCadena);
										
										//                        If Not ((slPrefijo = 4943 And slbanco = 88) Or (slPrefijo = 4859 And slbanco = 42)) Then
										if (dlbMonto > (mdlParametros.llemp_cred_tot - dblMontoAcum))
										{
											MessageBox.Show("No se pueden dar altas masivas la Suma de los Montos de los Ejecutivos sobrepasa la línea de Crédito " + mdlParametros.slctaref, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
											FileSystem.WriteLine(mdlParametros.llNumFileErr, "No se pueden dar altas masivas la Suma de los Montos de los Ejecutivos sobrepasa la línea de Crédito " + mdlParametros.slctaref);
											return false;
										}
										//                        End If
									}
									
									mdlParametros.slRegs[mdlParametros.ilIndice, mdlParametros.llConColumna] = slContReg + slColumna + mdlParametros.slCadena;
								}
								
								mdlParametros.ilIndice++;
							} else
							{
								mdlParametros.llContReg++;
								break;
							}
							Application.DoEvents();
						};
						Application.DoEvents();
					};
					
					
					return true;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ValidaInformacion, Genera Arreglo de Datos)",e );
				result = false;
				mdlParametros.prQuitaObjetos();
				FileSystem.FileClose(mdlParametros.llNumFile);
				FileSystem.FileClose(mdlParametros.llNumFileErr);
				return result;
			}
			return result;
	}
	
	public bool fncGrabaTablaMTCMSV01B()
	{
			
			bool result = false;
			int llcontador = 0;
			int iFlood_1 = 0;
			string slCuentaPadre = String.Empty; //20070330
			
			try
			{
					
					mdlParametros.bColorCambiado = true;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodType = Threed.enumFloodTypeConstants._LeftToRight;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodShowPct = true;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent = (short) CORVB.NULL_INTEGER;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].ForeColor = Color.Black;
					frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = true;
					
					llcontador = 0;
					mdlParametros.prQuitaObjetos();
					
					frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = true;
					frmAltasMasivas.DefInstance.lblRegistro.Visible = true;
					frmAltasMasivas.DefInstance.lblNumRegistro[0].Visible = true;
					frmAltasMasivas.DefInstance.Label1[1].Visible = true;
					frmAltasMasivas.DefInstance.lblNumRegistro[1].Visible = true;
					frmAltasMasivas.DefInstance.lblNumRegistro[1].Text = mdlParametros.gcarcAltasMasivas.Count.ToString();
					frmAltasMasivas.DefInstance.lblMensaje.Visible = true;
					frmAltasMasivas.DefInstance.lblMensaje.Text = "Espere, grabando registros en la tabla de Respaldo";
					
					//Se obtiene cuenta padre o espejo en caso de tenerla
					slCuentaPadre = mdlEjecutivo.fncCuentaPadreS(CORVAR.igblPref, CORVAR.igblBanco, CORVAR.lgblEmpCve); //FSWB NR 20070330
					
					if (mdlParametros.gcarcAltasMasivas.Count != 0)
					{
						llcontador = 1;
						
						while(llcontador <= mdlParametros.gcarcAltasMasivas.Count)
						{
							CORVAR.pszgblsql = "insert into MTCMSV01 values(" + mdlParametros.gprdProducto.PrefijoL.ToString() + " , " + mdlParametros.gprdProducto.BancoL.ToString() + " , ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeNumEmpL.ToString() + ",";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeNumeroL.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeRollOverI.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDigitoI.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeNombreS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeRFC.RFCS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeSueldoL.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeNumNominaS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeCenCosS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].AchEjeNivelI.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeNomGrabaS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomEnvioDMC.DomicilioS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomEnvioDMC.ColoniaS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomEnvioDMC.PoblacionS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.llZonaPos.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomEnvioDMC.CPL.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeTelDomS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeTelOfiS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeExtS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeFaxS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeLimCredL.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchRegNumI.ToString() + ", ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeStatusS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeCtaBnxS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeSexoS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeSucTransS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeSucPromS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeOrigenS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeActSubActiS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomEnvioDMC.EstadoEST.AbreviaturaS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomPartDMC.DomicilioS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomPartDMC.ColoniaS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomPartDMC.CiudadS + "', ";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomPartDMC.PoblacionS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomPartDMC.EstadoEST.AbreviaturaS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeDomPartDMC.CPL.ToString() + " ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeEmailS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeCtaContableS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeGenPinPlaI.ToString() + " ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeLimDisEfecI.ToString() + " ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeTipoCtaS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeTipoFactS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeSkipPaymentI.ToString() + " ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeTablaMccL.ToString() + " ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeIndLimDispS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeIndCtaCtrlS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeNacionalS + "' ,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeStatusRegI.ToString() + ",";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " " + mdlParametros.gcarcAltasMasivas[llcontador].ArchEjeTipoBloqueoI.ToString() + ")";
							
							if (CORPROC2.Modifica_Registro() == VBSQL.SUCCEED)
							{
								frmAltasMasivas.DefInstance.lblNumRegistro[0].Text = llcontador.ToString();
								iFlood_1 = Convert.ToInt32(Math.Floor((llcontador / ((double) mdlParametros.gcarcAltasMasivas.Count)) * 100));
								frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent = (short) iFlood_1;
								if (frmAltasMasivas.DefInstance.pnlProgProceso[0].FloodPercent > 1)
								{
									frmAltasMasivas.DefInstance.pnlProgProceso[0].ForeColor = Color.White;
									mdlParametros.bColorCambiado = true;
								}
								Application.DoEvents();
								llcontador++;
							} else
							{
								return false;
							}
						};
					}
					result = true;
					mdlParametros.prQuitaObjetos();
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ValidaInformacion, Insercion Tabla MTCMSV01)",e );
				result = false;
				mdlParametros.prQuitaObjetos();
				FileSystem.FileClose(mdlParametros.llNumFile);
				FileSystem.FileClose(mdlParametros.llNumFileErr);
				
				return result;
			}
			
			return result;
	}
	
	public bool fncValidaCaracterAltasMasivasB(ref  int ipCaracter,  CRSGeneral.cteValidaciones ipTipo,  bool bpMayusculas,  bool bpAceptaEspacios,  string spCadenaEspecial,  string spExcepcion)
	{
			
			bool result = false;
			const string slAlfabeticoAltasMasivas = "abcdefghiíjklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
			const string slAlfabeticoEspecialAltasMasivas = "áéíóúñÁÉÍÓÚÑ";
			const string slSignosPuntuacionAltasMasivas = ".:,;!¡?¿{}[]'_/" + "\"";
			const string slSignosPuntuacionResumidosAltasMasivas = ".,-_;";
			const string slEspacioAltasMasivas = " ";
			const string slNumerosAltasMasivas = "0123456789";
			const string slSeparadorDecimalAltasMasivas = ".";
			const string slSeparadorMilesAltasMasivas = ",";
			const string slPuntoFlotanteAltasMasivas = "-" + slSeparadorDecimalAltasMasivas + slSeparadorMilesAltasMasivas + slNumerosAltasMasivas;
			const string slDineroAltasMasivas = "$" + slPuntoFlotanteAltasMasivas;
			const string slSeparadorFechaAltasMasivas = "/-.";
			const string slNumericoEnteroAltasMasivas = slNumerosAltasMasivas + ",";
			const string slTelefonoAltasMasivas = slNumerosAltasMasivas + "-" + slEspacioAltasMasivas;
			const string slFechaCortaMasivas = slNumerosAltasMasivas + slSeparadorFechaAltasMasivas;
			const string slFechaLargaMasivas = slNumerosAltasMasivas + slAlfabeticoAltasMasivas;
			const string slHoraAltasMasivas = slNumerosAltasMasivas + ":apmAPM";
			const string slCaracteresEspecialesAltasMasivas = "#$%&@";
			const string slOperadoresAltasMasivas = "-+/*=<>()[]{}";
			const string slEMailAltasMasivas = "@" + slAlfabeticoAltasMasivas + slNumerosAltasMasivas + ".-_";
			const string slRFCAltasMasivas = slAlfabeticoAltasMasivas + slNumerosAltasMasivas;
			
			string slCadena = String.Empty;
			
			try
			{
					
					result = false;
					
					if (ipCaracter == 94 || ipCaracter == 96 || ipCaracter == 124 || ipCaracter >= 126 && ipCaracter <= 192 || ipCaracter >= 193 && ipCaracter <= 200 || ipCaracter >= 202 && ipCaracter <= 204 || ipCaracter >= 206 && ipCaracter <= 208 || ipCaracter >= 212 && ipCaracter <= 217 || ipCaracter == 219 || ipCaracter >= 221 && ipCaracter <= 224 || ipCaracter >= 226 && ipCaracter <= 232 || ipCaracter >= 234 && ipCaracter <= 236 || ipCaracter >= 238 && ipCaracter <= 240 || ipCaracter == 242 || ipCaracter >= 244 && ipCaracter <= 249 || ipCaracter == 251 || ipCaracter > 253)
					{
						ipCaracter = 0;
					} else
					{
						if (bpMayusculas)
						{
							ipCaracter = (int) Strings.Chr(ipCaracter).ToString().ToUpper()[0];
						}
						switch(ipTipo)
						{
							case CRSGeneral.cteValidaciones.cteValAlfabetico : 
								if (! bpAceptaEspacios)
								{
									slCadena = slAlfabeticoAltasMasivas + slAlfabeticoEspecialAltasMasivas + spCadenaEspecial;
								} else
								{
									slCadena = slAlfabeticoAltasMasivas + slAlfabeticoEspecialAltasMasivas + slEspacioAltasMasivas + spCadenaEspecial;
								} 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValAlfaNumerico : 
								if (! bpAceptaEspacios)
								{
									slCadena = slAlfabeticoAltasMasivas + slNumerosAltasMasivas + slAlfabeticoEspecialAltasMasivas + spCadenaEspecial;
								} else
								{
									slCadena = slAlfabeticoAltasMasivas + slNumerosAltasMasivas + slAlfabeticoEspecialAltasMasivas + slEspacioAltasMasivas + spCadenaEspecial;
								} 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValCaracter : 
								if (ipCaracter == 8)
								{
									return result;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValCorreoElectrónico : 
								slCadena = slEMailAltasMasivas + spCadenaEspecial; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValEntero : 
								slCadena = slNumerosAltasMasivas + "-"; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValFecha : 
								slCadena = slFechaCortaMasivas; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValPuntoFlotante : 
								slCadena = slPuntoFlotanteAltasMasivas; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValRFC : 
								if (VB6.GetActiveControl() is TextBox)
								{
									if (Strings.Len(VB6.GetActiveControl().ToString()) >= 0 && Strings.Len(VB6.GetActiveControl().ToString()) <= 3)
									{
										slCadena = slAlfabeticoAltasMasivas;
									} else if (Strings.Len(VB6.GetActiveControl().ToString()) >= 4 && Strings.Len(VB6.GetActiveControl().ToString()) <= 9) { 
										slCadena = slNumerosAltasMasivas;
									} else if (Strings.Len(VB6.GetActiveControl().ToString()) >= 10 && Strings.Len(VB6.GetActiveControl().ToString()) <= 14) { 
										slCadena = slRFCAltasMasivas;
									}
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValTelefonico : 
								slCadena = slTelefonoAltasMasivas; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = Int32.Parse("0" + spCadenaEspecial);
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValUniversal : 
								slCadena = slAlfabeticoAltasMasivas + slAlfabeticoEspecialAltasMasivas + slSignosPuntuacionAltasMasivas + slEspacioAltasMasivas + slNumerosAltasMasivas + slSeparadorMilesAltasMasivas + slSeparadorDecimalAltasMasivas + spCadenaEspecial; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValAlfabetoSignos : 
								slCadena = slAlfabeticoAltasMasivas + slAlfabeticoEspecialAltasMasivas + slSignosPuntuacionResumidosAltasMasivas + slEspacioAltasMasivas + slNumerosAltasMasivas + spCadenaEspecial; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValDigitos : 
								slCadena = slNumerosAltasMasivas; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
							case CRSGeneral.cteValidaciones.cteValEspecial : 
								slCadena = spCadenaEspecial; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = fncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipCaracter).ToString()) + 1) == 0)
								{
									ipCaracter = 0;
								} 
								break;
						}
					}
					
					
					if (ipCaracter == 0)
					{
						return false;
					} else
					{
						return true;
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("ValidaCaracter",e );
				return result;
			}
			return result;
	}
	
	public bool fncValidaCaracterAltasMasivasB(ref  int ipCaracter,  CRSGeneral.cteValidaciones ipTipo,  bool bpMayusculas,  bool bpAceptaEspacios,  string spCadenaEspecial)
	{
			return fncValidaCaracterAltasMasivasB(ref ipCaracter, ipTipo, bpMayusculas, bpAceptaEspacios, spCadenaEspecial, "");
	}
	
	public bool fncValidaCaracterAltasMasivasB(ref  int ipCaracter,  CRSGeneral.cteValidaciones ipTipo,  bool bpMayusculas,  bool bpAceptaEspacios)
	{
			return fncValidaCaracterAltasMasivasB(ref ipCaracter, ipTipo, bpMayusculas, bpAceptaEspacios, "", "");
	}
	
	public bool fncValidaCaracterAltasMasivasB(ref  int ipCaracter,  CRSGeneral.cteValidaciones ipTipo,  bool bpMayusculas)
	{
			return fncValidaCaracterAltasMasivasB(ref ipCaracter, ipTipo, bpMayusculas, false, "", "");
	}
	
	public bool fncValidaCaracterAltasMasivasB(ref  int ipCaracter,  CRSGeneral.cteValidaciones ipTipo)
	{
			return fncValidaCaracterAltasMasivasB(ref ipCaracter, ipTipo, false, false, "", "");
	}
	
	public string fncSubstraerInformationS(ref  int ipPos1, ref  string spDatos)
	{
			
			string result = String.Empty;
			int llLongitudDato = 0;
			
			if (Strings.InStr(ipPos1, spDatos, "\t", CompareMethod.Binary) != 0)
			{
				llLongitudDato = Strings.InStr(ipPos1, spDatos, "\t", CompareMethod.Binary) - ipPos1;
				result = Strings.Mid(spDatos, ipPos1, llLongitudDato);
				ipPos1 = ipPos1 + llLongitudDato + 1;
			} else
			{
				result = Strings.Mid(spDatos, ipPos1);
				ipPos1 = spDatos.Length + 1;
			}
			
			return result;
	}
	
	public string fncEliminaCaracteresDeUnaCadenaEnOtra(ref  string spCadenaOriginal,  string spCaracteresAEliminar)
	{
			
			//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
			if (! String.IsNullOrEmpty(spCaracteresAEliminar.Trim()) || spCaracteresAEliminar.Trim() != "")
			{
				for (int ilIndice = 1; ilIndice <= spCaracteresAEliminar.Trim().Length; ilIndice++)
				{
					spCadenaOriginal = Seguridad.fncsSustituir(spCadenaOriginal, Strings.Mid(spCaracteresAEliminar, ilIndice, 1), "");
				}
			}
			return spCadenaOriginal;
			
	}
	
	private bool fncVerificaNombreB(ref  string spEjeNom)
	{
			
			bool result = false;
			FixedLengthString slCaracter = new FixedLengthString(1);
			int ilPosComa = 0;
			int ilPosDiag = 0;
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					bool blComa = false;
					bool blDiagonal = false;
					
					for (int ilcont = 1; ilcont <= spEjeNom.Length; ilcont++)
					{
						slCaracter.Value = Strings.Mid(spEjeNom, ilcont, 1);
						if (slCaracter.Value == ",")
						{
							blComa = true;
						}
						if (blComa && slCaracter.Value == "/")
						{
							blDiagonal = true;
							break;
						}
					}
					
					if (blDiagonal)
					{
						ilPosComa = (spEjeNom.IndexOf(',') + 1);
						ilPosDiag = (spEjeNom.IndexOf('/') + 1);
						if (ilPosDiag - ilPosComa <= 1)
						{
							spEjeNom = Strings.Mid(spEjeNom, 1, ilPosComa - 1).Trim() + ",/" + Strings.Mid(spEjeNom, ilPosDiag + 1).Trim();
						} else
						{
							spEjeNom = Strings.Mid(spEjeNom, 1, ilPosComa - 1).Trim() + "," + Strings.Mid(spEjeNom, ilPosComa + 1, ilPosDiag - ilPosComa - 1).Trim() + "/" + Strings.Mid(spEjeNom, ilPosDiag + 1).Trim();
						}
					}
					result = blDiagonal;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
			return result;
	}
}
}