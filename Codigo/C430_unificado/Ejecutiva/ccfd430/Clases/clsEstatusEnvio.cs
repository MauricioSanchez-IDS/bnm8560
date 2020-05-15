using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsEstatusEnvio
	{
	
		
		private int mvarPrefijoL = 0;
		private int mvarBancoL = 0;
		private int mvarEmpresaL = 0;
		private string mvarNombreEmpresaS = String.Empty;
		private int mvarArchivoPendienteEnvioL = 0;
		private int mvarArchivoNoTransmitidoL = 0;
		private string mvarFechaS = String.Empty;
		private int mvarArchivoTransmitidoL = 0;
		
		public enum iEstatusEnvio
		 {
			Transmitido = 0 ,
			Pendiente = 2 ,
			NoTransmitido = 10
		}
		
		
		public int ArchivoTransmitidoL
		{
			get
			{
				return mvarArchivoTransmitidoL;
			}
			set
			{
				mvarArchivoTransmitidoL = value;
			}
		}
		
		
		
		public string FechaS
		{
			get
			{
				return mvarFechaS;
			}
			set
			{
				mvarFechaS = value;
			}
		}
		
		
		
		public int ArchivoNoTransmitidoL
		{
			get
			{
				return mvarArchivoNoTransmitidoL;
			}
			set
			{
				mvarArchivoNoTransmitidoL = value;
			}
		}
		
		
		
		public int ArchivoPendienteEnvioL
		{
			get
			{
				return mvarArchivoPendienteEnvioL;
			}
			set
			{
				mvarArchivoPendienteEnvioL = value;
			}
		}
		
		
		
		public string NombreEmpresaS
		{
			get
			{
				return mvarNombreEmpresaS;
			}
			set
			{
				mvarNombreEmpresaS = value;
			}
		}
		
		
		
		public int EmpresaL
		{
			get
			{
				return mvarEmpresaL;
			}
			set
			{
				mvarEmpresaL = value;
			}
		}
		
		
		
		public int BancoL
		{
			get
			{
				return mvarBancoL;
			}
			set
			{
				mvarBancoL = value;
			}
		}
		
		
		
		public int PrefijoL
		{
			get
			{
				return mvarPrefijoL;
			}
			set
			{
				mvarPrefijoL = value;
			}
		}
		
	}
}