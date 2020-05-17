using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsCiudad
	{
	
		
		private string mvarCodigoS = String.Empty;
		private string mvarCiudadS = String.Empty;
		private clsEstado mvarEstadoEST = null;
		
		
		public clsEstado EstadoEST
		{
			get
			{
				return mvarEstadoEST;
			}
			set
			{
				mvarEstadoEST = value;
			}
		}
		
		
		
		public string CiudadS
		{
			get
			{
				return mvarCiudadS;
			}
			set
			{
				mvarCiudadS = value;
			}
		}
		
		
		
		public string CodigoS
		{
			get
			{
				return mvarCodigoS;
			}
			set
			{
				mvarCodigoS = value;
			}
		}
		
	}
}