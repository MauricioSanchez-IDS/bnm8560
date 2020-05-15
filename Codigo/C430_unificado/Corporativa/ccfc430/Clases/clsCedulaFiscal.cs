using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsCedulaFiscal
	{
	
		
		private string mvarRazonSocialS = String.Empty;
		private clsRFC mvarrfcRFC = null;
		private clsDomicilio mvarDomicilioFiscalDMC = null;
		private string mvarNombreS = String.Empty;
		
		public bool fncValidaDatosB( bool bpRazonSocial,  bool bpRFC,  bool bpDomicilioFiscal,  bool bpNombre)
		{
			//Se va a validar que traigan TRUE los parametros para despues validarlos
			return false;
		}
		
		public bool fncValidaDatosB( bool bpRazonSocial,  bool bpRFC,  bool bpDomicilioFiscal)
		{
			return fncValidaDatosB(bpRazonSocial, bpRFC, bpDomicilioFiscal, false);
		}
		
		public bool fncValidaDatosB( bool bpRazonSocial,  bool bpRFC)
		{
			return fncValidaDatosB(bpRazonSocial, bpRFC, false, false);
		}
		
		public bool fncValidaDatosB( bool bpRazonSocial)
		{
			return fncValidaDatosB(bpRazonSocial, false, false, false);
		}
		
		public bool fncValidaDatosB()
		{
			return fncValidaDatosB(false, false, false, false);
		}
		
		
		public string NombreS
		{
			get
			{
				return mvarNombreS;
			}
			set
			{
				mvarNombreS = value;
			}
		}
		
		
		
		public clsDomicilio DomicilioFiscalDMC
		{
			get
			{
				return mvarDomicilioFiscalDMC;
			}
			set
			{
				mvarDomicilioFiscalDMC = value;
			}
		}
		
		
		
		public clsRFC rfcRFC
		{
			get
			{
				return mvarrfcRFC;
			}
			set
			{
				mvarrfcRFC = value;
			}
		}
		
		
		
		public string RazonSocialS
		{
			get
			{
				return mvarRazonSocialS;
			}
			set
			{
				mvarRazonSocialS = value;
			}
		}
		
	}
}