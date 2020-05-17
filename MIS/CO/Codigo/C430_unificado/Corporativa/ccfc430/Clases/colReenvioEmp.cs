using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class colReenvioEmp
	{
	
		private Collection mCol = new Collection();
		public int igNumeroGrupo = 0;
		private void  prArmaConsutaEmpresas()
		{
			CORVAR.pszgblsql = " Select " + "\r\n";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo     , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco      , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num       , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_num       , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " ejx_numero     , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom_graba    , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_rfc         , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num_cartera, " + "\r\n"; //float
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_princ_acc , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_sector    , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cred_tot   , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_acum_cred, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fec_venc_cred, " + "\r\n"; //smalldatetime
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_calle, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_col , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_ciu, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_pob, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_edo , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_cp, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_telefono     , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_extension   , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tel_lada   , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax       ,  " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax_lada , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_param_modem, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_vel_transmis, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_email        , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_internet    , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_calle, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_col ,  " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_ciu, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_pob  , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_edo, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_cp     , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cta_capt    , " + "\r\n"; //float
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_sucur      , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_pago , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_envio, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom_r1     , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_pues_r1, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tel_r1       , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_ext_r1      , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax_r1     , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fir_r1    , " + "\r\n"; //image
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom_r2    , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_pues_r2    , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tel_r2, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_ext_r2       , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax_r2      , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fir_r2     , " + "\r\n"; //image
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom_r3    , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_pues_r3   , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tel_r3     , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_ext_r3, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax_r3       , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fir_r3      , " + "\r\n"; //image
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_con_eje    , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_dia_corte , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_plazo_gracia, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_plazo_no_cob, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_gen_SBF, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_fac     , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_esquema_pago, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_producto, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_estruct_gastos, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_mes_fiscal   , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_lim_dis_efec, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_min_factura, " + "\r\n"; //float
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cta_contable, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_skip_payment , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tabla_mcc   , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam    , " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fech_alta, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fech_cam     , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_hora_cam    , " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_bloqueo, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_status_reg, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_gen_CDF, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_mskDiaCorte, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nacionalidad, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_digito_ver, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cuenta_ejecutivo0, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_bloqueo_eje, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_IndCtaControl, " + "\r\n"; //char
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_incremento, " + "\r\n"; //int
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cliente_prefijol, " + "\r\n";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cliente_bancol, " + "\r\n";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cliente_empresal, " + "\r\n";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cliente_clientel " + "\r\n";
			//FSWB NR CAMBIO ?
			CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCINE01 " + "\r\n";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " " + "\r\n";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " " + "\r\n";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + igNumeroGrupo.ToString() + " " + "\r\n";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " order by emp_num ";
		}
		public void  prCargarDatos()
		{
			string ilContador = String.Empty;
			prArmaConsutaEmpresas();
			
			clsReenvioemp objNewMember = null;
			if (CORPROC2.Obtiene_Registros() != 0)
			{
				ilContador = "1";
				
				while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
				{
					objNewMember = new clsReenvioemp();
					objNewMember.imPrefijo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
					objNewMember.pszBanco = VBSQL.SqlData(CORVAR.hgblConexion, 2);
					objNewMember.slNumEmpresa = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
					objNewMember.pszNumGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 4);
					objNewMember.pszNominaEjeBNX = VBSQL.SqlData(CORVAR.hgblConexion, 5);
					objNewMember.pszNomEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 6);
					objNewMember.pszNomCorto = VBSQL.SqlData(CORVAR.hgblConexion, 7);
					objNewMember.pszRFC = VBSQL.SqlData(CORVAR.hgblConexion, 8);
					objNewMember.pszCartera = VBSQL.SqlData(CORVAR.hgblConexion, 9);
					objNewMember.pszAccionista = VBSQL.SqlData(CORVAR.hgblConexion, 10);
					objNewMember.pszSector = VBSQL.SqlData(CORVAR.hgblConexion, 11);
					objNewMember.pszCreditoGlobal = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 12));
					//      objNewMember.x = SqlData(hgblConexion, 13)
					objNewMember.pszFecVenCred = VBSQL.SqlData(CORVAR.hgblConexion, 14);
					objNewMember.pszCalleFis = VBSQL.SqlData(CORVAR.hgblConexion, 15);
					objNewMember.pszColoniaFis = VBSQL.SqlData(CORVAR.hgblConexion, 16);
					objNewMember.pszCiudadFis = VBSQL.SqlData(CORVAR.hgblConexion, 17);
					objNewMember.pszPoblacionFis = VBSQL.SqlData(CORVAR.hgblConexion, 18);
					objNewMember.pszEstadoFis = VBSQL.SqlData(CORVAR.hgblConexion, 19);
					objNewMember.pszCpFis = VBSQL.SqlData(CORVAR.hgblConexion, 20);
					objNewMember.pszTelefono = VBSQL.SqlData(CORVAR.hgblConexion, 21);
					objNewMember.pszTelExt = VBSQL.SqlData(CORVAR.hgblConexion, 22);
					objNewMember.pszLada = VBSQL.SqlData(CORVAR.hgblConexion, 23);
					objNewMember.pszFax = VBSQL.SqlData(CORVAR.hgblConexion, 24);
					objNewMember.pszFaxLada = VBSQL.SqlData(CORVAR.hgblConexion, 25);
					objNewMember.pszTonoPul = VBSQL.SqlData(CORVAR.hgblConexion, 26);
					//      objNewMember.x = SqlData(hgblConexion, 27)
					objNewMember.pszEmail = VBSQL.SqlData(CORVAR.hgblConexion, 28);
					objNewMember.pszInternet = VBSQL.SqlData(CORVAR.hgblConexion, 29);
					objNewMember.pszCalleEnv = VBSQL.SqlData(CORVAR.hgblConexion, 30);
					objNewMember.pszColoniaEnv = VBSQL.SqlData(CORVAR.hgblConexion, 31);
					objNewMember.pszCiudadEnv = VBSQL.SqlData(CORVAR.hgblConexion, 32);
					objNewMember.pszPoblacionEnv = VBSQL.SqlData(CORVAR.hgblConexion, 33);
					objNewMember.pszEstadoEnv = VBSQL.SqlData(CORVAR.hgblConexion, 34);
					objNewMember.pszCpEnv = VBSQL.SqlData(CORVAR.hgblConexion, 35);
					objNewMember.pszCtaCaptacion = VBSQL.SqlData(CORVAR.hgblConexion, 36);
					objNewMember.pszSucursal = VBSQL.SqlData(CORVAR.hgblConexion, 37);
					objNewMember.pszTipoPago = VBSQL.SqlData(CORVAR.hgblConexion, 38);
					objNewMember.pszTipoEnv = VBSQL.SqlData(CORVAR.hgblConexion, 39);
					objNewMember.msNombreR1 = VBSQL.SqlData(CORVAR.hgblConexion, 40);
					objNewMember.msPuestoR1 = VBSQL.SqlData(CORVAR.hgblConexion, 41);
					objNewMember.msTelR1 = VBSQL.SqlData(CORVAR.hgblConexion, 42);
					objNewMember.msExtR1 = VBSQL.SqlData(CORVAR.hgblConexion, 43);
					objNewMember.msFaxR1 = VBSQL.SqlData(CORVAR.hgblConexion, 44);
					//      objNewMember.x = SqlData(hgblConexion, 45)
					objNewMember.msNombreR2 = VBSQL.SqlData(CORVAR.hgblConexion, 46);
					objNewMember.msPuestoR2 = VBSQL.SqlData(CORVAR.hgblConexion, 47);
					objNewMember.msTelR2 = VBSQL.SqlData(CORVAR.hgblConexion, 48);
					objNewMember.msExtR2 = VBSQL.SqlData(CORVAR.hgblConexion, 49);
					objNewMember.msFaxR2 = VBSQL.SqlData(CORVAR.hgblConexion, 50);
					//      objNewMember.x = SqlData(hgblConexion, 51)
					objNewMember.msNombreR3 = VBSQL.SqlData(CORVAR.hgblConexion, 52);
					objNewMember.msPuestoR3 = VBSQL.SqlData(CORVAR.hgblConexion, 53);
					objNewMember.msTelR3 = VBSQL.SqlData(CORVAR.hgblConexion, 54);
					objNewMember.msExtR3 = VBSQL.SqlData(CORVAR.hgblConexion, 55);
					objNewMember.msFaxR3 = VBSQL.SqlData(CORVAR.hgblConexion, 56);
					//      objNewMember.x = SqlData(hgblConexion, 57)
					//      objNewMember.x = SqlData(hgblConexion, 58)
					objNewMember.ilDiaCorte = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 59));
					objNewMember.ilPlazoGracia = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 60));
					objNewMember.ilPlazoNoCobro = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 61));
					//      objNewMember.x = SqlData(hgblConexion, 62)
					objNewMember.slTipoFactura = VBSQL.SqlData(CORVAR.hgblConexion, 63);
					objNewMember.slEsquemaPago = VBSQL.SqlData(CORVAR.hgblConexion, 64);
					objNewMember.slTipoProducto = VBSQL.SqlData(CORVAR.hgblConexion, 65);
					objNewMember.llEstructuraGastos = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 66));
					objNewMember.ilMesFiscal = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 67));
					objNewMember.ilMontoPorciento = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 68));
					objNewMember.dlFacturacionMinima = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 69));
					objNewMember.slCuentaContable = VBSQL.SqlData(CORVAR.hgblConexion, 70);
					objNewMember.ilSkipPayment = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 71));
					objNewMember.ilTablaMCC = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 72));
					objNewMember.slUsuarioCambio = VBSQL.SqlData(CORVAR.hgblConexion, 73);
					//      objNewMember.x = SqlData(hgblConexion, 74)
					//      objNewMember.x = SqlData(hgblConexion, 75)
					//      objNewMember.x = SqlData(hgblConexion, 76)
					//      objNewMember.x = SqlData(hgblConexion, 77)
					objNewMember.ilStatus_reg = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 78));
					objNewMember.ilGenArchivoCDF = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 79));
					objNewMember.mskDiaCorte = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 80));
					objNewMember.slNacionalidad = VBSQL.SqlData(CORVAR.hgblConexion, 81);
					objNewMember.iDigitoVer = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 82));
					objNewMember.sCuentaEjecutivo0 = VBSQL.SqlData(CORVAR.hgblConexion, 83);
					objNewMember.imEmpTipoBloqueo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 84));
					objNewMember.slIndCtaControl = VBSQL.SqlData(CORVAR.hgblConexion, 85);
					objNewMember.slIncremento = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 86));
					objNewMember.emp_cliente_prefijol = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 87));
					objNewMember.emp_cliente_bancol = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 88));
					objNewMember.emp_cliente_empresal = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 89));
					objNewMember.emp_cliente_clientel = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 90));
					
					mCol.Add(objNewMember, ilContador.Trim(), null, null);
					ilContador = (Double.Parse(ilContador) + 1).ToString();
				};
				
			} else
			{
				MessageBox.Show("No se encontro ninguna Empresa se necesite reenviar.", Application.ProductName);
				CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			}
		}
		public clsReenvioemp this[object vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsReenvioemp) mCol[Convert.ToInt32(vntIndexKey)];
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
		public void  Delete()
		{
			int ilNumElementos = Count;
			for (int ilContador = 1; ilContador <= ilNumElementos; ilContador++)
			{
				Remove(ilContador.ToString().Trim());
			}
		}
		
		
		~colReenvioEmp(){
			//destroys collection when this class is terminated
			Delete();
			mCol = null;
		}
}
}