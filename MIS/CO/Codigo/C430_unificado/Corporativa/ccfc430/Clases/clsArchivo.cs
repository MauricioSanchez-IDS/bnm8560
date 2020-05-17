using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsArchivo
	{
	
		private clsProducto mvarArchEjeProductoPRD = null;
		private int mvarArchEjeNumEmpL = 0;
		private int mvarArchEjeNumeroL = 0;
		private int mvarArchEjeRollOverI = 0;
		private int mvarArchEjeDigitoI = 0;
		private string mvarArchEjeNombreS = String.Empty;
		private clsRFC mvarArchEjeRFC = null;
		private int mvarArchEjeSueldoL = 0;
		private string mvarArchEjeNumNominaS = String.Empty;
		private string mvarArchEjeCenCosS = String.Empty;
		private int mvarArchEjeNivelI = 0;
		private string mvarArchEjeNomGrabaS = String.Empty;
		private clsDomicilio mvarArchEjeDomEnvioDMC = null;
		private string mvarArchEjeTelDomS = String.Empty;
		private string mvarArchEjeTelOfiS = String.Empty;
		private string mvarArchEjeExtS = String.Empty;
		private string mvarArchEjeFaxS = String.Empty;
		private int mvarArchEjeLimCredL = 0;
		private int mvarArchRegNumI = 0;
		private string mvarArchEjeStatusS = String.Empty;
		private string mvarArchEjeCtaBnxS = String.Empty;
		private string mvarArchEjeSexoS = String.Empty;
		private string mvarArchEjeSucTransS = String.Empty;
		private string mvarArchEjeSucPromS = String.Empty;
		private string mvarArchEjeOrigenS = String.Empty;
		private string mvarArchEjeActSubActiS = String.Empty;
		private string mvarArchEjeEdoS = String.Empty;
		private clsDomicilio mvarArchEjeDomPartDMC = null;
		private string mvarArchEjeEmailS = String.Empty;
		private string mvarArchEjeCtaContableS = String.Empty;
		private int mvarArchEjeGenPinPlaI = 0;
		private int mvarArchEjeLimDisEfecI = 0;
		private string mvarArchEjeTipoCtaS = String.Empty;
		private string mvarArchEjeTipoFactS = String.Empty;
		private int mvarArchEjeSkipPaymentI = 0;
		private int mvarArchEjeTablaMccL = 0;
		private string mvarArchEjeIndLimDispS = String.Empty;
		private string mvarArchEjeIndCtaCtrlS = String.Empty;
		private string mvarArchEjeNacionalS = String.Empty;
		private int mvarArchEjeStatusRegI = 0;
		private int mvarArchEjeTipoBloqueoI = 0;
		//FSWB NR 20070222
		private string mvarArchEjeAtencionA = String.Empty; //FSWB NR 20070222 Se incluyen campos Atencion A y Persona
		private string mvarArchEjePersona = String.Empty; //FSWB NR 20070222
		//FSWB NR 20070222
		//FSWB NR 20070222
		public string ArchEjeAtencionA
		{
			get
			{
				return mvarArchEjeAtencionA;
			}
			set
			{
				mvarArchEjeAtencionA = value;
			}
		}
		
		//FSWB NR 20070222
		//FSWB NR 20070222
		public int ArchEjePersona
		{
			get
			{
				return Int32.Parse(mvarArchEjePersona);
			}
			set
			{
				mvarArchEjePersona = value.ToString();
			}
		}
		
		
		
		public int ArchEjeTipoBloqueoI
		{
			get
			{
				return mvarArchEjeTipoBloqueoI;
			}
			set
			{
				mvarArchEjeTipoBloqueoI = value;
			}
		}
		
		
		
		public int ArchEjeStatusRegI
		{
			get
			{
				return mvarArchEjeStatusRegI;
			}
			set
			{
				mvarArchEjeStatusRegI = value;
			}
		}
		
		
		
		public string ArchEjeNacionalS
		{
			get
			{
				return mvarArchEjeNacionalS;
			}
			set
			{
				mvarArchEjeNacionalS = value;
			}
		}
		
		
		
		public string ArchEjeIndCtaCtrlS
		{
			get
			{
				return mvarArchEjeIndCtaCtrlS;
			}
			set
			{
				mvarArchEjeIndCtaCtrlS = value;
			}
		}
		
		
		
		public string ArchEjeIndLimDispS
		{
			get
			{
				return mvarArchEjeIndLimDispS;
			}
			set
			{
				mvarArchEjeIndLimDispS = value;
			}
		}
		
		
		
		public int ArchEjeTablaMccL
		{
			get
			{
				return mvarArchEjeTablaMccL;
			}
			set
			{
				mvarArchEjeTablaMccL = value;
			}
		}
		
		
		
		public int ArchEjeSkipPaymentI
		{
			get
			{
				return mvarArchEjeSkipPaymentI;
			}
			set
			{
				mvarArchEjeSkipPaymentI = value;
			}
		}
		
		
		
		public string ArchEjeTipoFactS
		{
			get
			{
				return mvarArchEjeTipoFactS;
			}
			set
			{
				mvarArchEjeTipoFactS = value;
			}
		}
		
		
		
		public string ArchEjeTipoCtaS
		{
			get
			{
				return mvarArchEjeTipoCtaS;
			}
			set
			{
				mvarArchEjeTipoCtaS = value;
			}
		}
		
		
		
		public int ArchEjeLimDisEfecI
		{
			get
			{
				return mvarArchEjeLimDisEfecI;
			}
			set
			{
				mvarArchEjeLimDisEfecI = value;
			}
		}
		
		
		
		public int ArchEjeGenPinPlaI
		{
			get
			{
				return mvarArchEjeGenPinPlaI;
			}
			set
			{
				mvarArchEjeGenPinPlaI = value;
			}
		}
		
		
		
		public string ArchEjeCtaContableS
		{
			get
			{
				return mvarArchEjeCtaContableS;
			}
			set
			{
				mvarArchEjeCtaContableS = value;
			}
		}
		
		
		
		public string ArchEjeEmailS
		{
			get
			{
				return mvarArchEjeEmailS;
			}
			set
			{
				mvarArchEjeEmailS = value;
			}
		}
		
		
		
		public clsDomicilio ArchEjeDomPartDMC
		{
			get
			{
				return mvarArchEjeDomPartDMC;
			}
			set
			{
				mvarArchEjeDomPartDMC = value;
			}
		}
		
		
		
		public string ArchEjeActSubActiS
		{
			get
			{
				return mvarArchEjeActSubActiS;
			}
			set
			{
				mvarArchEjeActSubActiS = value;
			}
		}
		
		
		
		public string ArchEjeOrigenS
		{
			get
			{
				return mvarArchEjeOrigenS;
			}
			set
			{
				mvarArchEjeOrigenS = value;
			}
		}
		
		
		
		public string ArchEjeSucPromS
		{
			get
			{
				return mvarArchEjeSucPromS;
			}
			set
			{
				mvarArchEjeSucPromS = value;
			}
		}
		
		
		
		public string ArchEjeSucTransS
		{
			get
			{
				return mvarArchEjeSucTransS;
			}
			set
			{
				mvarArchEjeSucTransS = value;
			}
		}
		
		
		
		public string ArchEjeSexoS
		{
			get
			{
				return mvarArchEjeSexoS;
			}
			set
			{
				mvarArchEjeSexoS = value;
			}
		}
		
		
		
		public string ArchEjeCtaBnxS
		{
			get
			{
				return mvarArchEjeCtaBnxS;
			}
			set
			{
				mvarArchEjeCtaBnxS = value;
			}
		}
		
		
		
		public string ArchEjeStatusS
		{
			get
			{
				return mvarArchEjeStatusS;
			}
			set
			{
				mvarArchEjeStatusS = value;
			}
		}
		
		
		
		public int ArchRegNumI
		{
			get
			{
				return mvarArchRegNumI;
			}
			set
			{
				mvarArchRegNumI = value;
			}
		}
		
		
		
		public int ArchEjeLimCredL
		{
			get
			{
				return mvarArchEjeLimCredL;
			}
			set
			{
				mvarArchEjeLimCredL = value;
			}
		}
		
		
		
		public string ArchEjeFaxS
		{
			get
			{
				return mvarArchEjeFaxS;
			}
			set
			{
				mvarArchEjeFaxS = value;
			}
		}
		
		
		
		public string ArchEjeExtS
		{
			get
			{
				return mvarArchEjeExtS;
			}
			set
			{
				mvarArchEjeExtS = value;
			}
		}
		
		
		
		public string ArchEjeTelOfiS
		{
			get
			{
				return mvarArchEjeTelOfiS;
			}
			set
			{
				mvarArchEjeTelOfiS = value;
			}
		}
		
		
		
		public string ArchEjeTelDomS
		{
			get
			{
				return mvarArchEjeTelDomS;
			}
			set
			{
				mvarArchEjeTelDomS = value;
			}
		}
		
		
		
		public clsDomicilio ArchEjeDomEnvioDMC
		{
			get
			{
				return mvarArchEjeDomEnvioDMC;
			}
			set
			{
				mvarArchEjeDomEnvioDMC = value;
			}
		}
		
		
		
		public string ArchEjeNomGrabaS
		{
			get
			{
				return mvarArchEjeNomGrabaS;
			}
			set
			{
				mvarArchEjeNomGrabaS = value;
			}
		}
		
		
		
		public int AchEjeNivelI
		{
			get
			{
				int mvarAchEjeNivelI = 0;
				return mvarAchEjeNivelI;
			}
			set
			{
				int mvarAchEjeNivelI = value;
			}
		}
		
		
		
		public string ArchEjeCenCosS
		{
			get
			{
				return mvarArchEjeCenCosS;
			}
			set
			{
				mvarArchEjeCenCosS = value;
			}
		}
		
		
		
		public string ArchEjeNumNominaS
		{
			get
			{
				return mvarArchEjeNumNominaS;
			}
			set
			{
				mvarArchEjeNumNominaS = value;
			}
		}
		
		
		
		public int ArchEjeSueldoL
		{
			get
			{
				return mvarArchEjeSueldoL;
			}
			set
			{
				mvarArchEjeSueldoL = value;
			}
		}
		
		
		
		public clsRFC ArchEjeRFC
		{
			get
			{
				return mvarArchEjeRFC;
			}
			set
			{
				mvarArchEjeRFC = value;
			}
		}
		
		
		
		public string ArchEjeNombreS
		{
			get
			{
				return mvarArchEjeNombreS;
			}
			set
			{
				mvarArchEjeNombreS = value;
			}
		}
		
		
		
		public int ArchEjeDigitoI
		{
			get
			{
				return mvarArchEjeDigitoI;
			}
			set
			{
				mvarArchEjeDigitoI = value;
			}
		}
		
		
		
		public int ArchEjeRollOverI
		{
			get
			{
				return mvarArchEjeRollOverI;
			}
			set
			{
				mvarArchEjeRollOverI = value;
			}
		}
		
		
		
		public int ArchEjeNumeroL
		{
			get
			{
				return mvarArchEjeNumeroL;
			}
			set
			{
				mvarArchEjeNumeroL = value;
			}
		}
		
		
		
		public int ArchEjeNumEmpL
		{
			get
			{
				return mvarArchEjeNumEmpL;
			}
			set
			{
				mvarArchEjeNumEmpL = value;
			}
		}
		
		
		
		public clsProducto ArchEjeProductoPRD
		{
			get
			{
				return mvarArchEjeProductoPRD;
			}
			set
			{
				mvarArchEjeProductoPRD = value;
			}
		}
		
		
		public clsArchivo(){
			ArchEjeProductoPRD = mdlParametros.gprdProducto;
			ArchEjeRFC = new clsRFC();
			ArchEjeDomEnvioDMC = new clsDomicilio();
			ArchEjeDomPartDMC = new clsDomicilio();
		}
	
	~clsArchivo(){
		ArchEjeProductoPRD = null;
		ArchEjeRFC = null;
		ArchEjeDomEnvioDMC = null;
		ArchEjeDomPartDMC = null;
	}
}
}