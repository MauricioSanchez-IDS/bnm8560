using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsLimite
	{
	
		
		private clsProducto mvarLimProductoPRD = null;
		private string mvarLimCtaBnxS = String.Empty;
		private int mvarLimCredAntL = 0;
		private int mvarLimCredPostL = 0;
		private string mvarLimUsuMakerS = String.Empty;
		private string mvarLimNomMakerS = String.Empty;
		private int mvarLimFechaMakerL = 0;
		private int mvarLimHoraMakerL = 0;
		private string mvarLimUsuCheckerS = String.Empty;
		private string mvarLimNomCheckers = String.Empty;
		private int mvarLimFechaCheckerL = 0;
		private int mvarLimHoraCheckerL = 0;
		
		
		public int LimHoraCheckerL
		{
			get
			{
				return mvarLimHoraCheckerL;
			}
			set
			{
				mvarLimHoraCheckerL = value;
			}
		}
		
		
		
		public int LimFechaCheckerL
		{
			get
			{
				return mvarLimFechaCheckerL;
			}
			set
			{
				mvarLimFechaCheckerL = value;
			}
		}
		
		
		
		public string LimNomCheckerS
		{
			get
			{
				return mvarLimNomCheckers;
			}
			set
			{
				mvarLimNomCheckers = value;
			}
		}
		
		
		
		public string LimUsuCheckerS
		{
			get
			{
				return mvarLimUsuCheckerS;
			}
			set
			{
				mvarLimUsuCheckerS = value;
			}
		}
		
		
		
		public int LimHoraMakerL
		{
			get
			{
				return mvarLimHoraMakerL;
			}
			set
			{
				mvarLimHoraMakerL = value;
			}
		}
		
		
		
		public int LimFechaMakerL
		{
			get
			{
				return mvarLimFechaMakerL;
			}
			set
			{
				mvarLimFechaMakerL = value;
			}
		}
		
		
		
		public string LimNomMakerS
		{
			get
			{
				return mvarLimNomMakerS;
			}
			set
			{
				mvarLimNomMakerS = value;
			}
		}
		
		
		
		public string LimUsuMakerS
		{
			get
			{
				return mvarLimUsuMakerS;
			}
			set
			{
				mvarLimUsuMakerS = value;
			}
		}
		
		
		
		public int LimCredPostL
		{
			get
			{
				return mvarLimCredPostL;
			}
			set
			{
				mvarLimCredPostL = value;
			}
		}
		
		
		
		public int LimCredAntL
		{
			get
			{
				return mvarLimCredAntL;
			}
			set
			{
				mvarLimCredAntL = value;
			}
		}
		
		
		
		public string LimCtaBnxS
		{
			get
			{
				return mvarLimCtaBnxS;
			}
			set
			{
				mvarLimCtaBnxS = value;
			}
		}
		
		
		
		public clsProducto LimProductoPRD
		{
			get
			{
				return mvarLimProductoPRD;
			}
			set
			{
				mvarLimProductoPRD = value;
			}
		}
		
		
		public clsLimite(){
			LimProductoPRD = mdlParametros.gprdProducto;
		}
}
}