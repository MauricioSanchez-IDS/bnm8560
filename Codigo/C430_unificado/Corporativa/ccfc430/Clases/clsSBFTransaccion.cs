using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsSBFTransaccion
	{
	
		
		public enum enuTipoSBFTransaccion
		 {
			tsbfTransaccionSBF = 1 ,
			tsbfTransaccionC430 = 2
		}
		
		private clsProducto mvarProductoPRD = null;
		private int mvarEmpNumL = 0;
		private int mvarEjeNumL = 0;
		private string mvarCveTransS = String.Empty;
		private string mvarDescTransS = String.Empty;
		private double mvarImporteD = 0;
		private int mvarFProcesoL = 0;
		private int mvarFValorL = 0;
		
		
		public int FValorL
		{
			get
			{
				return mvarFValorL;
			}
			set
			{
				mvarFValorL = value;
			}
		}
		
		
		
		public int FProcesoL
		{
			get
			{
				return mvarFProcesoL;
			}
			set
			{
				mvarFProcesoL = value;
			}
		}
		
		
		
		public double ImporteD
		{
			get
			{
				return mvarImporteD;
			}
			set
			{
				mvarImporteD = value;
			}
		}
		
		
		
		public string DescTransS
		{
			get
			{
				return mvarDescTransS;
			}
			set
			{
				mvarDescTransS = value;
			}
		}
		
		
		
		public string CveTransS
		{
			get
			{
				return mvarCveTransS;
			}
			set
			{
				mvarCveTransS = value;
			}
		}
		
		
		
		public int EjeNumL
		{
			get
			{
				return mvarEjeNumL;
			}
			set
			{
				mvarEjeNumL = value;
			}
		}
		
		
		
		public int EmpNumL
		{
			get
			{
				return mvarEmpNumL;
			}
			set
			{
				mvarEmpNumL = value;
			}
		}
		
		
		
		public clsProducto ProductoPRD
		{
			get
			{
				return mvarProductoPRD;
			}
			set
			{
				mvarProductoPRD = value;
			}
		}
		
	}
}