using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsDatosEmpresa
	{
	
		
		private int mvarEmpNumL = 0;
		private string mvarEmpNomS = String.Empty;
		private string mvarEmpNomGrabaS = String.Empty;
		private double mvarEmpNumCarteraD = 0;
		private string mvarEmpPrincAccS = String.Empty;
		private int mvarEmpSectorI = 0;
		private int mvarEmpCredTotL = 0;
		private int mvarEmpAcumCredL = 0;
		private string mvarEmpFecVencCredS = String.Empty;
		private int mvarEmpGpoNumL = 0;
		private string mvarEmpTelefonoS = String.Empty;
		private string mvarEmpExtensionS = String.Empty;
		private string mvarEmpTelLadaS = String.Empty;
		private string mvarEmpFaxS = String.Empty;
		private string mvarEmpFaxLadaS = String.Empty;
		private string mvarEmpEmailS = String.Empty;
		private string mvarEmpInternetS = String.Empty;
		private double mvarEmpCtaEjeD = 0;
		private int mvarEmpSucEjeL = 0;
		private string mvarEmpTipoPagoS = String.Empty;
		private string mvarEmpTipoEnvioS = String.Empty;
		private int mvarEmpConEjeI = 0;
		private int mvarEmpDiaCorteI = 0;
		private int mvarEmpPlazoGraciaI = 0;
		private int mvarEmpPlazoNoCobI = 0;
		private int mvarEmpGenSbfI = 0;
		private string mvarEmpTipoFacS = String.Empty;
		private string mvarEmpEsquemaPagoS = String.Empty;
		private string mvarEmpTipoProductoS = String.Empty;
		private int mvarEmpEstructGastosL = 0;
		private int mvarEmpMesFiscalI = 0;
		private int mvarEmpLimDisEfecI = 0;
		private double mvarEmpMinFactD = 0;
		private string mvarEmpCtaContableS = String.Empty;
		private CheckState mvarEmpSkipPaymentI = (CheckState) 0;
		private int mvarEmpTablaMccL = 0;
		private string mvarEmpCuentaS = String.Empty;
		private clsDomicilio mvarEmpDomFiscalDMC = null;
		private clsDomicilio mvarEmpDomEnvioDMC = null;
		private clsRFC mvarEmpRfcRFC = null;
		private clsRepresentante mvarEmpRep1RPR = null;
		private clsRepresentante mvarEmpRep2RPR = null;
		private clsRepresentante mvarEmpRep3RPR = null;
		private clsEjecutivoBanamex mvarEmpEjecutivoBanamexEJX = null;
		private clsProducto mvarEmpProductoPRD = null;
		private int mvarEmpFechaAltaL = 0;
		private string mvarEmpApellidoPaternoS = String.Empty;
		private string mvarEmpApellidoMaternoS = String.Empty;
		private string mvarEmpSexoS = String.Empty;
		private int mvarEmpSucTransmisora = 0;
		private int mvarEmpSucPromotora = 0;
		private int mvarEmpZonaPostalI = 0;
		private int mvarEmpASActiI = 0;
		
		public clsProducto EmpProductoPRD
		{
			get
			{
				return mvarEmpProductoPRD;
			}
			set
			{
				mvarEmpProductoPRD = value;
			}
		}
		
		
		
		public clsEjecutivoBanamex EmpEjecutivoBanamexEJX
		{
			get
			{
				return mvarEmpEjecutivoBanamexEJX;
			}
			set
			{
				mvarEmpEjecutivoBanamexEJX = value;
			}
		}
		
		
		
		public clsRepresentante EmpRep3RPR
		{
			get
			{
				return mvarEmpRep3RPR;
			}
			set
			{
				mvarEmpRep3RPR = value;
			}
		}
		
		
		
		public clsRepresentante EmpRep2RPR
		{
			get
			{
				return mvarEmpRep2RPR;
			}
			set
			{
				mvarEmpRep2RPR = value;
			}
		}
		
		
		
		public clsRepresentante EmpRep1RPR
		{
			get
			{
				return mvarEmpRep1RPR;
			}
			set
			{
				mvarEmpRep1RPR = value;
			}
		}
		
		
		
		public clsRFC EmpRfcRFC
		{
			get
			{
				return mvarEmpRfcRFC;
			}
			set
			{
				mvarEmpRfcRFC = value;
			}
		}
		
		
		
		public clsDomicilio EmpDomEnvioDMC
		{
			get
			{
				return mvarEmpDomEnvioDMC;
			}
			set
			{
				mvarEmpDomEnvioDMC = value;
			}
		}
		
		
		
		public clsDomicilio EmpDomFiscalDMC
		{
			get
			{
				return mvarEmpDomFiscalDMC;
			}
			set
			{
				mvarEmpDomFiscalDMC = value;
			}
		}
		
		
		
		public string EmpCuentaS
		{
			get
			{
				return mvarEmpCuentaS;
			}
			set
			{
				mvarEmpCuentaS = value;
			}
		}
		
		
		
		public int EmpTablaMccL
		{
			get
			{
				return mvarEmpTablaMccL;
			}
			set
			{
				mvarEmpTablaMccL = value;
			}
		}
		
		
		
		public int EmpSkipPaymentI
		{
			get
			{
				return (int) mvarEmpSkipPaymentI;
			}
			set
			{
				mvarEmpSkipPaymentI = (CheckState) value;
			}
		}
		
		
		
		public string EmpCtaContableS
		{
			get
			{
				return mvarEmpCtaContableS;
			}
			set
			{
				mvarEmpCtaContableS = value;
			}
		}
		
		
		
		public double EmpMinFactD
		{
			get
			{
				return mvarEmpMinFactD;
			}
			set
			{
				mvarEmpMinFactD = value;
			}
		}
		
		
		
		public int EmpLimDisEfecI
		{
			get
			{
				return mvarEmpLimDisEfecI;
			}
			set
			{
				mvarEmpLimDisEfecI = value;
			}
		}
		
		
		
		public int EmpMesFiscalI
		{
			get
			{
				return mvarEmpMesFiscalI;
			}
			set
			{
				mvarEmpMesFiscalI = value;
			}
		}
		
		
		
		public int EmpEstructGastosL
		{
			get
			{
				return mvarEmpEstructGastosL;
			}
			set
			{
				mvarEmpEstructGastosL = value;
			}
		}
		
		
		
		public string EmpTipoProductoS
		{
			get
			{
				return mvarEmpTipoProductoS;
			}
			set
			{
				mvarEmpTipoProductoS = value;
			}
		}
		
		
		
		public string EmpEsquemaPagoS
		{
			get
			{
				return mvarEmpEsquemaPagoS;
			}
			set
			{
				mvarEmpEsquemaPagoS = value;
			}
		}
		
		
		
		public string EmpTipoFacS
		{
			get
			{
				return mvarEmpTipoFacS;
			}
			set
			{
				mvarEmpTipoFacS = value;
			}
		}
		
		
		
		public int EmpGenSbfI
		{
			get
			{
				return mvarEmpGenSbfI;
			}
			set
			{
				mvarEmpGenSbfI = value;
			}
		}
		
		
		
		public int EmpPlazoNoCobI
		{
			get
			{
				return mvarEmpPlazoNoCobI;
			}
			set
			{
				mvarEmpPlazoNoCobI = value;
			}
		}
		
		
		
		public int EmpPlazoGraciaI
		{
			get
			{
				return mvarEmpPlazoGraciaI;
			}
			set
			{
				mvarEmpPlazoGraciaI = value;
			}
		}
		
		
		
		public int EmpDiaCorteI
		{
			get
			{
				return mvarEmpDiaCorteI;
			}
			set
			{
				mvarEmpDiaCorteI = value;
			}
		}
		
		
		
		public int EmpConEjeI
		{
			get
			{
				return mvarEmpConEjeI;
			}
			set
			{
				mvarEmpConEjeI = value;
			}
		}
		
		
		
		public string EmpTipoEnvioS
		{
			get
			{
				return mvarEmpTipoEnvioS;
			}
			set
			{
				mvarEmpTipoEnvioS = value;
			}
		}
		
		
		
		public string EmpTipoPagoS
		{
			get
			{
				return mvarEmpTipoPagoS;
			}
			set
			{
				mvarEmpTipoPagoS = value;
			}
		}
		
		
		
		public int EmpSucEjeL
		{
			get
			{
				return mvarEmpSucEjeL;
			}
			set
			{
				mvarEmpSucEjeL = value;
			}
		}
		
		
		
		public double EmpCtaEjeD
		{
			get
			{
				return mvarEmpCtaEjeD;
			}
			set
			{
				mvarEmpCtaEjeD = value;
			}
		}
		
		
		
		public string EmpInternetS
		{
			get
			{
				return mvarEmpInternetS;
			}
			set
			{
				mvarEmpInternetS = value;
			}
		}
		
		
		
		public string EmpEmailS
		{
			get
			{
				return mvarEmpEmailS;
			}
			set
			{
				mvarEmpEmailS = value;
			}
		}
		
		
		
		public string EmpFaxLadaS
		{
			get
			{
				return mvarEmpFaxLadaS;
			}
			set
			{
				mvarEmpFaxLadaS = value;
			}
		}
		
		
		
		public string EmpFaxS
		{
			get
			{
				return mvarEmpFaxS;
			}
			set
			{
				mvarEmpFaxS = value;
			}
		}
		
		
		
		public string EmpTelLadaS
		{
			get
			{
				return mvarEmpTelLadaS;
			}
			set
			{
				mvarEmpTelLadaS = value;
			}
		}
		
		
		
		public string EmpExtensionS
		{
			get
			{
				return mvarEmpExtensionS;
			}
			set
			{
				mvarEmpExtensionS = value;
			}
		}
		
		
		
		public string EmpTelefonoS
		{
			get
			{
				return mvarEmpTelefonoS;
			}
			set
			{
				mvarEmpTelefonoS = value;
			}
		}
		
		
		
		public int EmpGpoNumL
		{
			get
			{
				return mvarEmpGpoNumL;
			}
			set
			{
				mvarEmpGpoNumL = value;
			}
		}
		
		
		
		public string EmpFecVencCredS
		{
			get
			{
				return mvarEmpFecVencCredS;
			}
			set
			{
				mvarEmpFecVencCredS = value;
			}
		}
		
		
		
		public int EmpAcumCredL
		{
			get
			{
				return mvarEmpAcumCredL;
			}
			set
			{
				mvarEmpAcumCredL = value;
			}
		}
		
		
		
		public int EmpCredTotL
		{
			get
			{
				return mvarEmpCredTotL;
			}
			set
			{
				mvarEmpCredTotL = value;
			}
		}
		
		
		
		public int EmpSectorI
		{
			get
			{
				return mvarEmpSectorI;
			}
			set
			{
				mvarEmpSectorI = value;
			}
		}
		
		
		
		public string EmpPrincAccS
		{
			get
			{
				return mvarEmpPrincAccS;
			}
			set
			{
				mvarEmpPrincAccS = value;
			}
		}
		
		
		
		public double EmpNumCarteraD
		{
			get
			{
				return mvarEmpNumCarteraD;
			}
			set
			{
				mvarEmpNumCarteraD = value;
			}
		}
		
		
		
		public string EmpNomGrabaS
		{
			get
			{
				return mvarEmpNomGrabaS;
			}
			set
			{
				mvarEmpNomGrabaS = value;
			}
		}
		
		
		
		public string EmpNomS
		{
			get
			{
				return mvarEmpNomS;
			}
			set
			{
				mvarEmpNomS = value;
			}
		}
		
		
		
		public int EmpNumL
		{
			get
			{
				return mvarEmpNumL;
			}
			set
			{
				mvarEmpNumL = value;
			}
		}
		
		public int EmpFechaAltaL
		{
			set
			{
				mvarEmpFechaAltaL = value;
			}
		}
		
		public string EmpApellidoPaternoS
		{
			set
			{
				mvarEmpApellidoPaternoS = value;
			}
		}
		
		public string EmpApellidoMaternoS
		{
			set
			{
				mvarEmpApellidoMaternoS = value;
			}
		}
		
		public string EmpSexoS
		{
			set
			{
				mvarEmpSexoS = value;
			}
		}
		
		public int EmpSucTransmisora
		{
			set
			{
				mvarEmpSucTransmisora = value;
			}
		}
		
		public int EmpSucPromotora
		{
			set
			{
				mvarEmpSucPromotora = value;
			}
		}
		
		public int EmpZonaPostalI
		{
			set
			{
				mvarEmpZonaPostalI = value;
			}
		}
		
		public int EmpASActiI
		{
			set
			{
				mvarEmpASActiI = value;
			}
		}
		
		public clsDatosEmpresa(){
			EmpProductoPRD = mdlParametros.gprdProducto;
			EmpDomFiscalDMC = new clsDomicilio();
			EmpDomEnvioDMC = new clsDomicilio();
			EmpDomFiscalDMC.EstadoEST = new clsEstado();
			EmpDomEnvioDMC.EstadoEST = new clsEstado();
			EmpRfcRFC = new clsRFC();
			EmpRep1RPR = new clsRepresentante();
			EmpRep2RPR = new clsRepresentante();
			EmpRep3RPR = new clsRepresentante();
			EmpEjecutivoBanamexEJX = new clsEjecutivoBanamex();
		}
}
}