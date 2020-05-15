using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsEstado
	{
	
		
		private int mvarCodigoI = 0;
		private string mvarEstadoS = String.Empty;
		private string mvarAbreviaturaS = String.Empty;
		
		
		public string AbreviaturaS
		{
			get
			{
				return mvarAbreviaturaS;
			}
			set
			{
				mvarAbreviaturaS = value;
			}
		}
		
		
		
		public string EstadoS
		{
			get
			{
				return mvarEstadoS;
			}
			set
			{
				mvarEstadoS = value;
			}
		}
		
		
		
		public int CodigoI
		{
			get
			{
				return mvarCodigoI;
			}
			set
			{
				mvarCodigoI = value;
			}
		}
		
	}
}