using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsRepresentante
	{
	
		
		private string mvarNombreS = String.Empty;
		private string mvarPuestoS = String.Empty;
		private string mvarTelefonoS = String.Empty;
		private string mvarExtensionS = String.Empty;
		private string mvarFaxS = String.Empty;
		private bool mvarFirmaB = false;
		
		
		public bool FirmaB
		{
			get
			{
				return mvarFirmaB;
			}
			set
			{
				mvarFirmaB = value;
			}
		}
		
		
		
		public string FaxS
		{
			get
			{
				return mvarFaxS;
			}
			set
			{
				mvarFaxS = value;
			}
		}
		
		
		
		public string ExtensionS
		{
			get
			{
				return mvarExtensionS;
			}
			set
			{
				mvarExtensionS = value;
			}
		}
		
		
		
		public string TelefonoS
		{
			get
			{
				return mvarTelefonoS;
			}
			set
			{
				mvarTelefonoS = value;
			}
		}
		
		
		
		public string PuestoS
		{
			get
			{
				return mvarPuestoS;
			}
			set
			{
				mvarPuestoS = value;
			}
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
		
	}
}