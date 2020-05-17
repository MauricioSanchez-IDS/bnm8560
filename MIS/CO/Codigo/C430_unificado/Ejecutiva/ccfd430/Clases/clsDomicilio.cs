using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsDomicilio
	{
	
		
		private string mvarDomicilioS = String.Empty;
		private string mvarColoniaS = String.Empty;
		private string mvarPoblacionS = String.Empty;
		private string mvarCiudadS = String.Empty;
		private int mvarCPL = 0;
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
		
		
		
		public int CPL
		{
			get
			{
				return mvarCPL;
			}
			set
			{
				mvarCPL = value;
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
		
		
		
		public string PoblacionS
		{
			get
			{
				return mvarPoblacionS;
			}
			set
			{
				mvarPoblacionS = value;
			}
		}
		
		
		
		public string ColoniaS
		{
			get
			{
				return mvarColoniaS;
			}
			set
			{
				mvarColoniaS = value;
			}
		}
		
		
		
		public string DomicilioS
		{
			get
			{
				return mvarDomicilioS;
			}
			set
			{
				mvarDomicilioS = value;
			}
		}
		
		
		public clsDomicilio(){
			EstadoEST = new clsEstado();
		}
	
	~clsDomicilio(){
		EstadoEST = null;
	}
}
}