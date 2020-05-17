using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsEjecutivoBanamex
	{
	
		
		private int mvarNominaL = 0;
		private string mvarNombreS = String.Empty;
		
		
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
		
		
		
		public int NominaL
		{
			get
			{
				return mvarNominaL;
			}
			set
			{
				mvarNominaL = value;
			}
		}
		
	}
}