using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsTablaMCC
	{
	
		
		private int mvarValorI = 0;
		private string mvarDescripcionS = String.Empty;
		
		
		public string DescripcionS
		{
			get
			{
				return mvarDescripcionS;
			}
			set
			{
				mvarDescripcionS = value;
			}
		}
		
		
		
		public int ValorI
		{
			get
			{
				return mvarValorI;
			}
			set
			{
				mvarValorI = value;
			}
		}
		
	}
}