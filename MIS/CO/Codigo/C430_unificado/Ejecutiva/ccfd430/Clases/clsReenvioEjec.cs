using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsReenvioEjec
	{
	
		
		//local variable(s) to hold property value(s)
		private clsProducto mvarEjeProductoPRD = null; //local copy
		private int mvarNumEmpL = 0; //local copy
		private int mvarEjeNumeroL = 0; //local copy
		private int mvarEjeRolloverI = 0; //local copy
		private int mvarEjeDigitoI = 0; //local copy
		private string mvarEjeNombreS = String.Empty; //local copy
		private clsRFC mvarEjeRFC = null; //local copy
		private int mvarEjeSueldoL = 0; //local copy
		private string mvarEjeNumNominaS = String.Empty; //local copy
		private string mvarEjeCenCosS = String.Empty; //local copy
		private int mvarEjeNivelI = 0; //local copy
		private string mvarEjeNomGrabaS = String.Empty; //local copy
		private clsDomicilio mvarEjeDomEnvioDMC = null; //local copy
		private string mvarEjeTelDomS = String.Empty; //local copy
		private string mvarEjeTelOficS = String.Empty; //local copy
		private string mvarEjeExtS = String.Empty; //local copy
		private string mvarEjeFaxS = String.Empty; //local copy
		private int mvarEjeLimCredL = 0; //local copy
		private int mvarRegNumL = 0; //local copy
		private string mvarEjeEstatusS = String.Empty; //local copy
		private string mvarEjeCtaBmxS = String.Empty; //local copy
		private string mvarEjeSexoS = String.Empty; //local copy
		private string mvarEjeSucTransS = String.Empty; //local copy
		private string mvarEjeSucPromS = String.Empty; //local copy
		private string mvarEjeOrigenS = String.Empty; //local copy
		private string mvarEjeActSubActiS = String.Empty; //local copy
		private clsDomicilio mvarEjeDomPartDMC = null; //local copy
		private string mvarEjeEmailS = String.Empty; //local copy
		private string mvarEjeCtaContableS = String.Empty; //local copy
		private int mvarEjeGenPinPlaI = 0; //local copy
		private int mvarEjeLimDisEfecL = 0; //local copy
		private string mvarEjeTipoCtaS = String.Empty; //local copy
		private string mvarEjeTipoFactS = String.Empty; //local copy
		private int mvarEjeSkipPagmentL = 0; //local copy
		private int mvarEjeTablaMCCL = 0; //local copy
		private string mvarEjeIndLimDispS = String.Empty; //local copy
		private string mvarEjeIndCtasCtrlS = String.Empty; //local copy
		private string mvarEjeNacionalS = String.Empty; //local copy
		private int mvarEjeStatusRegI = 0; //local copy
		//Datos de empresa
		private int mvarEmpSectorI = 0;
		private string mvarEmpTipoEnvioS = String.Empty;
		private string mvarEmpTipoFactS = String.Empty;
		private string mvarEmpTipoProductoS = String.Empty;
		private int mvarEmpDiaCorteI = 0;
		private string mvarCuentaS = String.Empty;
		private string mvarCuentaReferenciaS = String.Empty;
		private int mvarEjeTipoBloqueoI = 0;
		private string mvarEjeAtencionA = String.Empty; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
		private int mvarEjePersona = 0; //FSWB NR 20070222
		//FSWB NR 20070222
		//FSWB NR 20070222
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
		
		//FSWB NR 20070222
		//FSWB NR 20070222
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
		
		
		
		public string CuentaReferenciaS
		{
			get
			{
				
				return mvarCuentaReferenciaS;
			}
			set
			{
				
				mvarCuentaReferenciaS = value;
			}
		}
		
		
		
		public string CuentaS
		{
			get
			{
				
				return mvarCuentaS;
			}
			set
			{
				
				mvarCuentaS = value;
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
		
		
		
		public string EmpTipoFactS
		{
			get
			{
				
				return mvarEmpTipoFactS;
			}
			set
			{
				
				mvarEmpTipoFactS = value;
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
		
		
		
		public int EjeStatusRegI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.StatusRegI
				return mvarEjeStatusRegI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.StatusRegI = 5
				mvarEjeStatusRegI = value;
			}
		}
		
		
		
		public string EjeNacionalS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NacionalS
				return mvarEjeNacionalS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NacionalS = 5
				mvarEjeNacionalS = value;
			}
		}
		
		
		
		public string EjeIndCtasCtrlS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.IndCtasCtrlS
				return mvarEjeIndCtasCtrlS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.IndCtasCtrlS = 5
				mvarEjeIndCtasCtrlS = value;
			}
		}
		
		
		
		public string EjeIndLimDispS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.IndLimDispS
				return mvarEjeIndLimDispS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.IndLimDispS = 5
				mvarEjeIndLimDispS = value;
			}
		}
		
		
		
		public int EjeTablaMCCL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TablaMCCL
				return mvarEjeTablaMCCL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TablaMCCL = 5
				mvarEjeTablaMCCL = value;
			}
		}
		
		
		
		public int EjeSkipPaymentL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SkipPagmentI
				return mvarEjeSkipPagmentL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SkipPagmentI = 5
				mvarEjeSkipPagmentL = value;
			}
		}
		
		
		
		public string EjeTipoFactS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TipoFactS
				return mvarEjeTipoFactS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TipoFactS = 5
				mvarEjeTipoFactS = value;
			}
		}
		
		
		
		public string EjeTipoCtaS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TipoCtaS
				return mvarEjeTipoCtaS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TipoCtaS = 5
				mvarEjeTipoCtaS = value;
			}
		}
		
		
		
		public int EjeLimDisEfecL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.LimDisEfecI
				return mvarEjeLimDisEfecL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.LimDisEfecI = 5
				mvarEjeLimDisEfecL = value;
			}
		}
		
		
		
		public int EjeGenPinPlaI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.GenPinPlaI
				return mvarEjeGenPinPlaI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.GenPinPlaI = 5
				mvarEjeGenPinPlaI = value;
			}
		}
		
		
		
		public string EjeCtaContableS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.CtaContableS
				return mvarEjeCtaContableS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.CtaContableS = 5
				mvarEjeCtaContableS = value;
			}
		}
		
		
		
		public string EjeEmailS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.EmailS
				return mvarEjeEmailS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.EmailS = 5
				mvarEjeEmailS = value;
			}
		}
		
		
		
		public clsDomicilio EjeDomPartDMC
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.DomPartDMC
				return mvarEjeDomPartDMC;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.DomPartDMC = Form1
				mvarEjeDomPartDMC = value;
			}
		}
		
		
		
		public string EjeActSubActiS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.ActSubActiS
				return mvarEjeActSubActiS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.ActSubActiS = 5
				mvarEjeActSubActiS = value;
			}
		}
		
		
		
		public string EjeOrigenS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.OrigenS
				return mvarEjeOrigenS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.OrigenS = 5
				mvarEjeOrigenS = value;
			}
		}
		
		
		
		public string EjeSucPromS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SucPromS
				return mvarEjeSucPromS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SucPromS = 5
				mvarEjeSucPromS = value;
			}
		}
		
		
		
		public string EjeSucTransS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SucTransS
				return mvarEjeSucTransS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SucTransS = 5
				mvarEjeSucTransS = value;
			}
		}
		
		
		
		public string EjeSexoS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SexoS
				return mvarEjeSexoS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SexoS = 5
				mvarEjeSexoS = value;
			}
		}
		
		
		
		public string EjeCtaBmxS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.CtaBmxS
				return mvarEjeCtaBmxS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.CtaBmxS = 5
				mvarEjeCtaBmxS = value;
			}
		}
		
		
		
		public string EjeEstatusS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.EstatusS
				return mvarEjeEstatusS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.EstatusS = 5
				mvarEjeEstatusS = value;
			}
		}
		
		
		
		public int RegNumL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.RegNumI
				return mvarRegNumL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.RegNumI = 5
				mvarRegNumL = value;
			}
		}
		
		
		
		public int EjeLimCredL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.LinCredL
				return mvarEjeLimCredL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.LinCredL = 5
				mvarEjeLimCredL = value;
			}
		}
		
		
		
		public string EjeFaxS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.FaxS
				return mvarEjeFaxS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.FaxS = 5
				mvarEjeFaxS = value;
			}
		}
		
		
		
		public string EjeExtS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.ExtS
				return mvarEjeExtS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.ExtS = 5
				mvarEjeExtS = value;
			}
		}
		
		
		
		public string EjeTelOficS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TelOficS
				return mvarEjeTelOficS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TelOficS = 5
				mvarEjeTelOficS = value;
			}
		}
		
		
		
		public string EjeTelDomS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TelDomS
				return mvarEjeTelDomS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TelDomS = 5
				mvarEjeTelDomS = value;
			}
		}
		
		
		
		public clsDomicilio EjeDomEnvioDMC
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.DomEnvioDMC
				return mvarEjeDomEnvioDMC;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.DomEnvioDMC = Form1
				mvarEjeDomEnvioDMC = value;
			}
		}
		
		
		
		public string EjeNomGrabaS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NomGrabaS
				return mvarEjeNomGrabaS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NomGrabaS = 5
				mvarEjeNomGrabaS = value;
			}
		}
		
		
		
		public int EjeNivelI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NivelI
				return mvarEjeNivelI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NivelI = 5
				mvarEjeNivelI = value;
			}
		}
		
		
		
		public string EjeCenCosS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.CenCosS
				return mvarEjeCenCosS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.CenCosS = 5
				mvarEjeCenCosS = value;
			}
		}
		
		
		
		public string EjeNumNominaS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NumNominaS
				return mvarEjeNumNominaS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NumNominaS = 5
				mvarEjeNumNominaS = value;
			}
		}
		
		
		
		public int EjeSueldoL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SueldoL
				return mvarEjeSueldoL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SueldoL = 5
				mvarEjeSueldoL = value;
			}
		}
		
		
		
		public clsRFC EjeRFC
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.RFC
				return mvarEjeRFC;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.RFC = Form1
				mvarEjeRFC = value;
			}
		}
		
		
		
		public string EjeNombreS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NombreS
				return mvarEjeNombreS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NombreS = 5
				mvarEjeNombreS = value;
			}
		}
		
		
		
		public int EjeDigitoI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.DigitoI
				return mvarEjeDigitoI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.DigitoI = 5
				mvarEjeDigitoI = value;
			}
		}
		
		
		
		public int EjeRolloverI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.RolloverI
				return mvarEjeRolloverI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.RolloverI = 5
				mvarEjeRolloverI = value;
			}
		}
		
		
		
		public int EjeNumeroL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NumeroL
				return mvarEjeNumeroL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NumeroL = 5
				mvarEjeNumeroL = value;
			}
		}
		
		
		
		public int NumEmpL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NumEmpL
				return mvarNumEmpL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NumEmpL = 5
				mvarNumEmpL = value;
			}
		}
		
		
		
		public clsProducto EjeProductoPRD
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.EjeProductoPRD
				return mvarEjeProductoPRD;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.EjeProductoPRD = Form1
				mvarEjeProductoPRD = value;
			}
		}
		
	}
}