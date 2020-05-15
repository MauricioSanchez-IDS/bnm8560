using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsDatosEjecutivo
	{
	
		
		private clsProducto mvarEjeProductoPRD = null;
		private int mvarEjeEmpNumL = 0;
		private int mvarEjeNumL = 0;
		private int mvarEjeRolloverI = 0;
		private int mvarEjeDigitI = 0;
		private string mvarEjeNomS = String.Empty;
		private clsRFC mvarEjeRfcRFC = null;
		private int mvarEjeSueldoL = 0;
		private string mvarEjeNumNomS = String.Empty;
		private string mvarEjeCentroCostS = String.Empty;
		private int mvarEjeNivelI = 0;
		private string mvarEjeNomGrabaS = String.Empty;
		private clsDomicilio mvarEjeDomEnvioDMC = null;
		private clsDomicilio mvarEjeDomPartDMC = null;
		private string mvarEjeTelDomS = String.Empty;
		private string mvarEjeTelOfiS = String.Empty;
		private string mvarEjeExtensionS = String.Empty;
		private string mvarEjeFaxS = String.Empty;
		private int mvarEjeLimCredL = 0;
		private int mvarEjeRegNumL = 0;
		private string mvarEjeEstatusS = String.Empty;
		private string mvarEjeCuentaBnxS = String.Empty;
		private string mvarEjeSexoS = String.Empty;
		private string mvarEjeSucTransS = String.Empty;
		private string mvarEjeSucPromS = String.Empty;
		private string mvarEjeOrigenS = String.Empty;
		private string mvarEjeActiSubactiS = String.Empty;
		private string mvarEjeEmailS = String.Empty;
		private string mvarEjeCtaContableS = String.Empty;
		private int mvarEjeGenPinPlaI = 0;
		private int mvarEjeLimDisEfecL = 0;
		private string mvarEjeTipoCuentaS = String.Empty;
		private string mvarEjeTipoFactS = String.Empty;
		private CheckState mvarEjeSkipPaymentL = (CheckState) 0;
		private int mvarEjeTablaMCCL = 0;
		private string mvarEjeIndLimDispS = String.Empty;
		private string mvarEjeIndCtaCtrlS = String.Empty;
		private string mvarEjeNacionalidadS = String.Empty;
		private string mvarEjeCuentaS = String.Empty;
		private int mvarEjeDiaCorteI = 0;
		private string mvarEjeCuentaReferenciaS = String.Empty;
		private string mvarEjeEmpTipoEnvioS = String.Empty;
		private string mvarEjeEmpTipoFactS = String.Empty;
		private string mvarEjeEmpTipoProductoS = String.Empty;
		private int mvarEjeEmpSectorI = 0;
        private int mvarEjeTipoBloqueoI = 0;
        private int mvarEjeEjecBnx = 0;
		
		//FSWB Nelly Rdz Se agregaron campos Atencion A y Persona
		private string mvarEjeAtencionA = String.Empty;
		private int mvarEjePersona = 0;
		//FSWB Nelly Rdz Se agregaron campos Atencion A y Persona
		//FSWB Nelly Rdz Se agregaron campos Atencion A y Persona
		public string EjeAtencionA
		{
			get
			{
				return mvarEjeAtencionA;
			}
			set
			{
				mvarEjeAtencionA = value;
			}
		}
		
		//FSWB Nelly Rdz Se agregaron campos Atencion A y Persona
		//FSWB Nelly Rdz Se agregaron campos Atencion A y Persona
		public int EjePersona
		{
			get
			{
				return mvarEjePersona;
			}
			set
			{
				mvarEjePersona = value;
			}
		}
		
		
		
		
		public int EjeTipoBloqueoI
		{
			get
			{
				return mvarEjeTipoBloqueoI;
			}
			set
			{
				mvarEjeTipoBloqueoI = value;
			}
		}

        public int EjeEjecBnx
        {
            get
            {
                return mvarEjeEjecBnx;
            }
            set
            {
                mvarEjeEjecBnx = value;
            }
        }
		
		
		public int EjeEmpSectorI
		{
			get
			{
				return mvarEjeEmpSectorI;
			}
			set
			{
				mvarEjeEmpSectorI = value;
			}
		}
		
		
		
		public string EjeEmpTipoProductoS
		{
			get
			{
				return mvarEjeEmpTipoProductoS;
			}
			set
			{
				mvarEjeEmpTipoProductoS = value;
			}
		}
		
		
		
		public string EjeEmpTipoFactS
		{
			get
			{
				return mvarEjeEmpTipoFactS;
			}
			set
			{
				mvarEjeEmpTipoFactS = value;
			}
		}
		
		
		
		public string EjeEmpTipoEnvioS
		{
			get
			{
				return mvarEjeEmpTipoEnvioS;
			}
			set
			{
				mvarEjeEmpTipoEnvioS = value;
			}
		}
		
		
		
		public string EjeCuentaReferenciaS
		{
			get
			{
				return mvarEjeCuentaReferenciaS;
			}
			set
			{
				mvarEjeCuentaReferenciaS = value;
			}
		}
		
		
		
		public int EjeDiaCorteI
		{
			get
			{
				return mvarEjeDiaCorteI;
			}
			set
			{
				mvarEjeDiaCorteI = value;
			}
		}
		
		
		
		public string EjeCuentaS
		{
			get
			{
				return mvarEjeCuentaS;
			}
			set
			{
				mvarEjeCuentaS = value;
			}
		}
		
		
		
		public string EjeNacionalidadS
		{
			get
			{
				return mvarEjeNacionalidadS;
			}
			set
			{
				mvarEjeNacionalidadS = value;
			}
		}
		
		
		
		public string EjeIndCtaCtrlS
		{
			get
			{
				return mvarEjeIndCtaCtrlS;
			}
			set
			{
				mvarEjeIndCtaCtrlS = value;
			}
		}
		
		
		
		public string EjeIndLimDispS
		{
			get
			{
				return mvarEjeIndLimDispS;
			}
			set
			{
				mvarEjeIndLimDispS = value;
			}
		}
		
		
		
		public int EjeTablaMCCL
		{
			get
			{
				return mvarEjeTablaMCCL;
			}
			set
			{
				mvarEjeTablaMCCL = value;
			}
		}
		
		
		
		public int EjeSkipPaymentL
		{
			get
			{
				return (int) mvarEjeSkipPaymentL;
			}
			set
			{
				//UPGRADE_WARNING: (6021) Casting 'double' to Enum may cause different behaviour.
				mvarEjeSkipPaymentL = (CheckState) Convert.ToInt32(value);
			}
		}
		
		
		
		public string EjeTipoFactS
		{
			get
			{
				return mvarEjeTipoFactS;
			}
			set
			{
				mvarEjeTipoFactS = value;
			}
		}
		
		
		
		public string EjeTipoCuentaS
		{
			get
			{
				return mvarEjeTipoCuentaS;
			}
			set
			{
				mvarEjeTipoCuentaS = value;
			}
		}
		
		
		
		public int EjeLimDisEfecL
		{
			get
			{
				return mvarEjeLimDisEfecL;
			}
			set
			{
				mvarEjeLimDisEfecL = value;
			}
		}
		
		
		
		public int EjeGenPinPlaI
		{
			get
			{
				return mvarEjeGenPinPlaI;
			}
			set
			{
				mvarEjeGenPinPlaI = value;
			}
		}
		
		
		
		public string EjeCtaContableS
		{
			get
			{
				return mvarEjeCtaContableS;
			}
			set
			{
				mvarEjeCtaContableS = value;
			}
		}
		
		
		
		public string EjeEmailS
		{
			get
			{
				return mvarEjeEmailS;
			}
			set
			{
				mvarEjeEmailS = value;
			}
		}
		
		
		
		public string EjeActiSubactiS
		{
			get
			{
				return mvarEjeActiSubactiS;
			}
			set
			{
				mvarEjeActiSubactiS = value;
			}
		}
		
		
		
		public string EjeOrigenS
		{
			get
			{
				return mvarEjeOrigenS;
			}
			set
			{
				mvarEjeOrigenS = value;
			}
		}
		
		
		
		public string EjeSucPromS
		{
			get
			{
				return mvarEjeSucPromS;
			}
			set
			{
				mvarEjeSucPromS = value;
			}
		}
		
		
		
		public string EjeSucTransS
		{
			get
			{
				return mvarEjeSucTransS;
			}
			set
			{
				mvarEjeSucTransS = value;
			}
		}
		
		
		
		public string EjeSexoS
		{
			get
			{
				return mvarEjeSexoS;
			}
			set
			{
				mvarEjeSexoS = value;
			}
		}
		
		
		
		public string EjeCuentaBnxS
		{
			get
			{
				return mvarEjeCuentaBnxS;
			}
			set
			{
				mvarEjeCuentaBnxS = value;
			}
		}
		
		
		
		public string EjeEstatusS
		{
			get
			{
				return mvarEjeEstatusS;
			}
			set
			{
				mvarEjeEstatusS = value;
			}
		}
		
		
		
		public int EjeRegNumL
		{
			get
			{
				return mvarEjeRegNumL;
			}
			set
			{
				mvarEjeRegNumL = value;
			}
		}
		
		
		
		public int EjeLimCredL
		{
			get
			{
				return mvarEjeLimCredL;
			}
			set
			{
				mvarEjeLimCredL = value;
			}
		}
		
		
		
		public string EjeFaxS
		{
			get
			{
				return mvarEjeFaxS;
			}
			set
			{
				mvarEjeFaxS = value;
			}
		}
		
		
		
		public string EjeExtensionS
		{
			get
			{
				return mvarEjeExtensionS;
			}
			set
			{
				mvarEjeExtensionS = value;
			}
		}
		
		
		
		public string EjeTelOfiS
		{
			get
			{
				return mvarEjeTelOfiS;
			}
			set
			{
				mvarEjeTelOfiS = value;
			}
		}
		
		
		
		public string EjeTelDomS
		{
			get
			{
				return mvarEjeTelDomS;
			}
			set
			{
				mvarEjeTelDomS = value;
			}
		}
		
		
		
		public clsDomicilio EjeDomPartDMC
		{
			get
			{
				return mvarEjeDomPartDMC;
			}
			set
			{
				mvarEjeDomPartDMC = value;
			}
		}
		
		
		
		public clsDomicilio EjeDomEnvioDMC
		{
			get
			{
				return mvarEjeDomEnvioDMC;
			}
			set
			{
				mvarEjeDomEnvioDMC = value;
			}
		}
		
		
		
		public string EjeNomGrabaS
		{
			get
			{
				return mvarEjeNomGrabaS;
			}
			set
			{
				mvarEjeNomGrabaS = value;
			}
		}
		
		
		
		public int EjeNivelI
		{
			get
			{
				return mvarEjeNivelI;
			}
			set
			{
				mvarEjeNivelI = value;
			}
		}
		
		
		
		public string EjeCentroCostS
		{
			get
			{
				return mvarEjeCentroCostS;
			}
			set
			{
				mvarEjeCentroCostS = value;
			}
		}
		
		
		
		public string EjeNumNomS
		{
			get
			{
				return mvarEjeNumNomS;
			}
			set
			{
				mvarEjeNumNomS = value;
			}
		}
		
		
		
		public int EjeSueldoL
		{
			get
			{
				return mvarEjeSueldoL;
			}
			set
			{
				mvarEjeSueldoL = value;
			}
		}
		
		
		
		public clsRFC EjeRfcRFC
		{
			get
			{
				return mvarEjeRfcRFC;
			}
			set
			{
				mvarEjeRfcRFC = value;
			}
		}
		
		
		
		public string EjeNomS
		{
			get
			{
				return mvarEjeNomS;
			}
			set
			{
				mvarEjeNomS = value;
			}
		}
		
		
		
		public int EjeDigitI
		{
			get
			{
				return mvarEjeDigitI;
			}
			set
			{
				mvarEjeDigitI = value;
			}
		}
		
		
		
		public int EjeRolloverI
		{
			get
			{
				return mvarEjeRolloverI;
			}
			set
			{
				mvarEjeRolloverI = value;
			}
		}
		
		
		
		public int EjeNumL
		{
			get
			{
				return mvarEjeNumL;
			}
			set
			{
				mvarEjeNumL = value;
			}
		}
		
		
		
		public int EjeEmpNumL
		{
			get
			{
				return mvarEjeEmpNumL;
			}
			set
			{
				mvarEjeEmpNumL = value;
			}
		}
		
		
		
		public clsProducto EjeProductoPRD
		{
			get
			{
				return mvarEjeProductoPRD;
			}
			set
			{
				mvarEjeProductoPRD = value;
			}
		}
		
		
		public clsDatosEjecutivo(){
			EjeProductoPRD = mdlParametros.gprdProducto;
			EjeRfcRFC = new clsRFC();
			EjeDomEnvioDMC = new clsDomicilio();
			EjeDomPartDMC = new clsDomicilio();
			this.EjeSucPromS = "0342";
			this.EjeSucTransS = "0342";
			this.EjeOrigenS = "E";
			this.EjeIndLimDispS = "P";
			this.EjeRegNumL = 1;
			this.EjeRolloverI = 9;
			this.EjeTipoCuentaS = mdlParametros.ctesIndividual;
			this.EjeEstatusS = "T";
			
			//FSWB Nelly Rdz Se agregaron campos Atencion A y Persona
			//Me.EjeAtencionA = ""
			//Me.EjePersona = 2 'Default para Ejecutivos tarjetahabientes Persona Fisica
		}
	
	~clsDatosEjecutivo(){
		EjeProductoPRD = null;
		EjeRfcRFC = null;
		EjeDomEnvioDMC = null;
		EjeDomPartDMC = null;
	}
}
}