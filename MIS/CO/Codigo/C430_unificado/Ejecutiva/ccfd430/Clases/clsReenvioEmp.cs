using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsReenvioemp
	{
	
		
		int EmpimPrefijo = 0;
		string EmppszBanco = String.Empty;
		int lNumEmpresa = 0;
		int lIncremento = 0;
		string EmppszNumGrupo = String.Empty;
		string EmppszNominaEjeBNX = String.Empty;
		string EmppszNomEmpresa = String.Empty;
		string EmppszNomCorto = String.Empty;
		string EmppszRFC = String.Empty;
		string EmppszCartera = String.Empty;
		string EmppszAccionista = String.Empty;
		string EmppszSector = String.Empty;
		int EmppszCreditoGlobal = 0;
		string EmppszFecVenCred = String.Empty;
		string EmppszCalleFis = String.Empty;
		string EmppszColoniaFis = String.Empty;
		string EmppszCiudadFis = String.Empty;
		string EmppszPoblacionFis = String.Empty;
		string EmppszEstadoFis = String.Empty;
		string EmppszCpFis = String.Empty;
		string EmppszTelefono = String.Empty;
		string EmppszTelExt = String.Empty;
		string EmppszLada = String.Empty;
		string EmppszFax = String.Empty;
		string EmppszFaxLada = String.Empty;
		string EmppszTonoPul = String.Empty;
		string EmppszEmail = String.Empty;
		string EmppszInternet = String.Empty;
		string EmppszCalleEnv = String.Empty;
		string EmppszColoniaEnv = String.Empty;
		string EmppszCiudadEnv = String.Empty;
		string EmppszPoblacionEnv = String.Empty;
		string EmppszCpEnv = String.Empty;
		string EmppszCtaCaptacion = String.Empty;
		string EmppszEstadoEnv = String.Empty;
		string EmppszSucursal = String.Empty;
		string EmppszTipoPago = String.Empty;
		string EmppszTipoEnv = String.Empty;
		string EmpmsNombreR1 = String.Empty;
		string EmpmsPuestoR1 = String.Empty;
		string EmpmsTelR1 = String.Empty;
		string EmpmsExtR1 = String.Empty;
		string EmpmsFaxR1 = String.Empty;
		string EmpmsNombreR2 = String.Empty;
		string EmpmsPuestoR2 = String.Empty;
		string EmpmsTelR2 = String.Empty;
		string EmpmsExtR2 = String.Empty;
		string EmpmsFaxR2 = String.Empty;
		string EmpmsNombreR3 = String.Empty;
		string EmpmsPuestoR3 = String.Empty;
		string EmpmsTelR3 = String.Empty;
		string EmpmsExtR3 = String.Empty;
		string EmpmsFaxR3 = String.Empty;
		int EmpilDiaCorte = 0;
		int EmpilPlazoGracia = 0;
		int EmpilPlazoNoCobro = 0;
		string EmpslTipoFactura = String.Empty;
		string EmpslEsquemaPago = String.Empty;
		string EmpslTipoProducto = String.Empty;
		int EmpllEstructuraGastos = 0;
		int EmpilMesFiscal = 0;
		int EmpilMontoPorciento = 0;
		double EmpdlFacturacionMinima = 0;
		string EmpslCuentaContable = String.Empty;
		int EmpilSkipPayment = 0;
		int EmpilTablaMCC = 0;
		string EmpslUsuarioCambio = String.Empty;
		int EmpilStatus_reg = 0;
		int EmpilGenArchivoCDF = 0;
		int EmpmskDiaCorte = 0;
		string EmpslNacionalidad = String.Empty;
		int ilDigitoVer = 0;
		string slCuentaEjecutivo0 = String.Empty;
		int EmpimEmpTipoBloqueo = 0;
		string EmpimAtencionA = String.Empty; //FSWB NR 20070226 Se incluyen campos Atencion y Persona
		int EmpimPersona = 0; //FSWB NR 20070226
		
		string EmpslIndCtaControl = String.Empty;
		int Empemp_cliente_prefijol = 0;
		int Empemp_cliente_bancol = 0;
		int Empemp_cliente_empresal = 0;
		int Empemp_cliente_clientel = 0;
		
        string Empemp_Suc_Promotora = String.Empty;
        string Empemp_Suc_Transmisora = String.Empty;

        public string pszSucPromotora
        {
            get
            {
                return Empemp_Suc_Promotora;
            }
            set
            {
                Empemp_Suc_Promotora = value;
            }
        }

        public string pszSucTransmisora
        {
            get
            {
                return Empemp_Suc_Transmisora;
            }
            set
            {
                Empemp_Suc_Transmisora = value;
            }
        }
		
		public int imPrefijo
		{
			get
			{
				return EmpimPrefijo;
			}
			set
			{
				EmpimPrefijo = value;
			}
		}
		
		
		public string pszBanco
		{
			get
			{
				return EmppszBanco;
			}
			set
			{
				EmppszBanco = value;
			}
		}
		
		
		public int slNumEmpresa
		{
			get
			{
				return lNumEmpresa;
			}
			set
			{
				lNumEmpresa = value;
			}
		}
		
		
		public int slIncremento
		{
			get
			{
				return lIncremento;
			}
			set
			{
				lIncremento = value;
			}
		}
		
		
		public string pszNumGrupo
		{
			get
			{
				return EmppszNumGrupo;
			}
			set
			{
				EmppszNumGrupo = value;
			}
		}
		
		
		public string pszNominaEjeBNX
		{
			get
			{
				return EmppszNominaEjeBNX;
			}
			set
			{
				EmppszNominaEjeBNX = value;
			}
		}
		
		
		public string pszNomEmpresa
		{
			get
			{
				return EmppszNomEmpresa;
			}
			set
			{
				EmppszNomEmpresa = value;
			}
		}
		
		
		public string pszNomCorto
		{
			get
			{
				return EmppszNomCorto;
			}
			set
			{
				EmppszNomCorto = value;
			}
		}
		
		
		public string pszRFC
		{
			get
			{
				return EmppszRFC;
			}
			set
			{
				EmppszRFC = value;
			}
		}
		
		
		public string pszCartera
		{
			get
			{
				return EmppszCartera;
			}
			set
			{
				EmppszCartera = value;
			}
		}
		
		
		public string pszAccionista
		{
			get
			{
				return EmppszAccionista;
			}
			set
			{
				EmppszAccionista = value;
			}
		}
		
		
		public string pszSector
		{
			get
			{
				return EmppszSector;
			}
			set
			{
				EmppszSector = value;
			}
		}
		
		
		public int pszCreditoGlobal
		{
			get
			{
				return EmppszCreditoGlobal;
			}
			set
			{
				EmppszCreditoGlobal = value;
			}
		}
		
		
		public string pszFecVenCred
		{
			get
			{
				return EmppszFecVenCred;
			}
			set
			{
				EmppszFecVenCred = value;
			}
		}
		
		
		public string pszCalleFis
		{
			get
			{
				return EmppszCalleFis;
			}
			set
			{
				EmppszCalleFis = value;
			}
		}
		
		
		public string pszColoniaFis
		{
			get
			{
				return EmppszColoniaFis;
			}
			set
			{
				EmppszColoniaFis = value;
			}
		}
		
		
		public string pszCiudadFis
		{
			get
			{
				return EmppszCiudadFis;
			}
			set
			{
				EmppszCiudadFis = value;
			}
		}
		
		
		public string pszPoblacionFis
		{
			get
			{
				return EmppszPoblacionFis;
			}
			set
			{
				EmppszPoblacionFis = value;
			}
		}
		
		
		public string pszEstadoFis
		{
			get
			{
				return EmppszEstadoFis;
			}
			set
			{
				EmppszEstadoFis = value;
			}
		}
		
		
		public string pszCpFis
		{
			get
			{
				return EmppszCpFis;
			}
			set
			{
				EmppszCpFis = value;
			}
		}
		
		
		public string pszTelefono
		{
			get
			{
				return EmppszTelefono;
			}
			set
			{
				EmppszTelefono = value;
			}
		}
		
		
		public string pszTelExt
		{
			get
			{
				return EmppszTelExt;
			}
			set
			{
				EmppszTelExt = value;
			}
		}
		
		
		public string pszLada
		{
			get
			{
				return EmppszLada;
			}
			set
			{
				EmppszLada = value;
			}
		}
		
		
		public string pszFaxLada
		{
			get
			{
				return EmppszFaxLada;
			}
			set
			{
				EmppszFaxLada = value;
			}
		}
		
		
		public string pszFax
		{
			get
			{
				return EmppszFax;
			}
			set
			{
				EmppszFax = value;
			}
		}
		
		
		
		public string pszTonoPul
		{
			get
			{
				return EmppszTonoPul;
			}
			set
			{
				EmppszTonoPul = value;
			}
		}
		
		
		public string pszEmail
		{
			get
			{
				return EmppszEmail;
			}
			set
			{
				EmppszEmail = value;
			}
		}
		
		
		public string pszInternet
		{
			get
			{
				return EmppszInternet;
			}
			set
			{
				EmppszInternet = value;
			}
		}
		
		
		public string pszCalleEnv
		{
			get
			{
				return EmppszCalleEnv;
			}
			set
			{
				EmppszCalleEnv = value;
			}
		}
		
		
		public string pszColoniaEnv
		{
			get
			{
				return EmppszColoniaEnv;
			}
			set
			{
				EmppszColoniaEnv = value;
			}
		}
		
		
		public string pszCiudadEnv
		{
			get
			{
				return EmppszCiudadEnv;
			}
			set
			{
				EmppszCiudadEnv = value;
			}
		}
		
		
		public string pszPoblacionEnv
		{
			get
			{
				return EmppszPoblacionEnv;
			}
			set
			{
				EmppszPoblacionEnv = value;
			}
		}
		
		
		public string pszCpEnv
		{
			get
			{
				return EmppszCpEnv;
			}
			set
			{
				EmppszCpEnv = value;
			}
		}
		
		
		public string pszCtaCaptacion
		{
			get
			{
				return EmppszCtaCaptacion;
			}
			set
			{
				EmppszCtaCaptacion = value;
			}
		}
		
		
		public string pszEstadoEnv
		{
			get
			{
				return EmppszEstadoEnv;
			}
			set
			{
				EmppszEstadoEnv = value;
			}
		}
		
		
		public string pszSucursal
		{
			get
			{
				return EmppszSucursal;
			}
			set
			{
				EmppszSucursal = value;
			}
		}
		
		
		public string pszTipoPago
		{
			get
			{
				return EmppszTipoPago;
			}
			set
			{
				EmppszTipoPago = value;
			}
		}
		
		
		public string pszTipoEnv
		{
			get
			{
				return EmppszTipoEnv;
			}
			set
			{
				EmppszTipoEnv = value;
			}
		}
		
		
		public string msNombreR1
		{
			get
			{
				return EmpmsNombreR1;
			}
			set
			{
				EmpmsNombreR1 = value;
			}
		}
		
		
		public string msPuestoR1
		{
			get
			{
				return EmpmsPuestoR1;
			}
			set
			{
				EmpmsPuestoR1 = value;
			}
		}
		
		
		public string msTelR1
		{
			get
			{
				return EmpmsTelR1;
			}
			set
			{
				EmpmsTelR1 = value;
			}
		}
		
		
		public string msExtR1
		{
			get
			{
				return EmpmsExtR1;
			}
			set
			{
				EmpmsExtR1 = value;
			}
		}
		
		
		public string msFaxR1
		{
			get
			{
				return EmpmsFaxR1;
			}
			set
			{
				EmpmsFaxR1 = value;
			}
		}
		
		
		public string msNombreR2
		{
			get
			{
				return EmpmsNombreR2;
			}
			set
			{
				EmpmsNombreR2 = value;
			}
		}
		
		
		public string msPuestoR2
		{
			get
			{
				return EmpmsPuestoR2;
			}
			set
			{
				EmpmsPuestoR2 = value;
			}
		}
		
		
		public string msTelR2
		{
			get
			{
				return EmpmsTelR1;
			}
			set
			{
				EmpmsTelR2 = value;
			}
		}
		
		
		public string msExtR2
		{
			get
			{
				return EmpmsExtR1;
			}
			set
			{
				EmpmsExtR2 = value;
			}
		}
		
		
		public string msFaxR2
		{
			get
			{
				return EmpmsFaxR2;
			}
			set
			{
				EmpmsFaxR2 = value;
			}
		}
		
		
		public string msNombreR3
		{
			get
			{
				return EmpmsNombreR3;
			}
			set
			{
				EmpmsNombreR3 = value;
			}
		}
		
		
		public string msPuestoR3
		{
			get
			{
				return EmpmsPuestoR3;
			}
			set
			{
				EmpmsPuestoR3 = value;
			}
		}
		
		
		public string msTelR3
		{
			get
			{
				return EmpmsTelR3;
			}
			set
			{
				EmpmsTelR3 = value;
			}
		}
		
		
		public string msExtR3
		{
			get
			{
				return EmpmsExtR3;
			}
			set
			{
				EmpmsExtR3 = value;
			}
		}
		
		
		public string msFaxR3
		{
			get
			{
				return EmpmsFaxR3;
			}
			set
			{
				EmpmsFaxR3 = value;
			}
		}
		
		
		public int ilDiaCorte
		{
			get
			{
				return EmpilDiaCorte;
			}
			set
			{
				EmpilDiaCorte = value;
			}
		}
		
		
		public int ilPlazoGracia
		{
			get
			{
				return EmpilPlazoGracia;
			}
			set
			{
				EmpilPlazoGracia = value;
			}
		}
		
		
		public int ilPlazoNoCobro
		{
			get
			{
				return EmpilPlazoNoCobro;
			}
			set
			{
				EmpilPlazoNoCobro = value;
			}
		}
		
		
		public string slTipoFactura
		{
			get
			{
				return EmpslTipoFactura;
			}
			set
			{
				EmpslTipoFactura = value;
			}
		}
		
		
		public string slEsquemaPago
		{
			get
			{
				return EmpslEsquemaPago;
			}
			set
			{
				EmpslEsquemaPago = value;
			}
		}
		
		
		public string slTipoProducto
		{
			get
			{
				return EmpslTipoProducto;
			}
			set
			{
				EmpslTipoProducto = value;
			}
		}
		
		
		public int llEstructuraGastos
		{
			get
			{
				return EmpllEstructuraGastos;
			}
			set
			{
				EmpllEstructuraGastos = value;
			}
		}
		
		
		public int ilMesFiscal
		{
			get
			{
				return EmpilMesFiscal;
			}
			set
			{
				EmpilMesFiscal = value;
			}
		}
		
		
		public int ilMontoPorciento
		{
			get
			{
				return EmpilMontoPorciento;
			}
			set
			{
				EmpilMontoPorciento = value;
			}
		}
		
		
		public double dlFacturacionMinima
		{
			get
			{
				return EmpdlFacturacionMinima;
			}
			set
			{
				EmpdlFacturacionMinima = value;
			}
		}
		
		
		public string slCuentaContable
		{
			get
			{
				return EmpslCuentaContable;
			}
			set
			{
				EmpslCuentaContable = value;
			}
		}
		
		
		public int ilSkipPayment
		{
			get
			{
				return EmpilSkipPayment;
			}
			set
			{
				EmpilSkipPayment = value;
			}
		}
		
		
		public int ilTablaMCC
		{
			get
			{
				return EmpilTablaMCC;
			}
			set
			{
				EmpilTablaMCC = value;
			}
		}
		
		
		
		public string slUsuarioCambio
		{
			get
			{
				return EmpslUsuarioCambio;
			}
			set
			{
				EmpslUsuarioCambio = value;
			}
		}
		
		
		
		
		public int ilStatus_reg
		{
			get
			{
				return EmpilStatus_reg;
			}
			set
			{
				EmpilStatus_reg = value;
			}
		}
		
		
		public int ilGenArchivoCDF
		{
			get
			{
				return EmpilGenArchivoCDF;
			}
			set
			{
				EmpilGenArchivoCDF = value;
			}
		}
		
		
		public int mskDiaCorte
		{
			get
			{
				return EmpmskDiaCorte;
			}
			set
			{
				EmpmskDiaCorte = value;
			}
		}
		
		
		public string slNacionalidad
		{
			get
			{
				return EmpslNacionalidad;
			}
			set
			{
				EmpslNacionalidad = value;
			}
		}
		
		
		public int iDigitoVer
		{
			get
			{
				return ilDigitoVer;
			}
			set
			{
				ilDigitoVer = value;
			}
		}
		
		
		public string sCuentaEjecutivo0
		{
			get
			{
				return slCuentaEjecutivo0;
			}
			set
			{
				slCuentaEjecutivo0 = value;
			}
		}
		
		//FSWB NR 20070226
		//FSWB NR 20070226
		public string imEmpAtencionA
		{
			get
			{
				return EmpimAtencionA;
			}
			set
			{
				EmpimAtencionA = value;
			}
		}
		
		//FSWB NR 20070226
		//FSWB NR 20070226
		public int imEmpPersona
		{
			get
			{
				return EmpimPersona;
			}
			set
			{
				EmpimPersona = value;
			}
		}
		
		public int imEmpTipoBloqueo
		{
			get
			{
				return EmpimEmpTipoBloqueo;
			}
			set
			{
				EmpimEmpTipoBloqueo = value;
			}
		}
		
		
		public string slIndCtaControl
		{
			get
			{
				return EmpslIndCtaControl;
			}
			set
			{
				EmpslIndCtaControl = value;
			}
		}
		
		
		public int emp_cliente_prefijol
		{
			get
			{
				return Empemp_cliente_prefijol;
			}
			set
			{
				Empemp_cliente_prefijol = value;
			}
		}
		
		
		public int emp_cliente_bancol
		{
			get
			{
				return Empemp_cliente_bancol;
			}
			set
			{
				Empemp_cliente_bancol = value;
			}
		}
		
		
		public int emp_cliente_empresal
		{
			get
			{
				return Empemp_cliente_empresal;
			}
			set
			{
				Empemp_cliente_empresal = value;
			}
		}
		
		
		public int emp_cliente_clientel
		{
			get
			{
				return Empemp_cliente_clientel;
			}
			set
			{
				Empemp_cliente_clientel = value;
			}
		}
		
	}
}