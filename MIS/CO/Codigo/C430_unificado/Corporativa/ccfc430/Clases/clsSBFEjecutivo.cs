using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsSBFEjecutivo
	{
	
		
		public enum enuTipoSBFEjecutivo
		 {
			tsbfEjecutivoSBF = 1 ,
			tsbfEjecutivoC430 = 2
		}
		
		private clsProducto mvarProductoPRD = null;
		private int mvarEmpNumL = 0;
		private int mvarEjeNumL = 0;
		private int mvarRollOverI = 0;
		private int mvarDigitoVerifI = 0;
		private string mvarEjeNomS = String.Empty;
		private double mvarSaldoActualD = 0;
		private double mvarSaldoAnteriorD = 0;
		
		
		public double SaldoAnteriorD
		{
			get
			{
				return mvarSaldoAnteriorD;
			}
			set
			{
				mvarSaldoAnteriorD = value;
			}
		}
		
		
		
		public double SaldoActualD
		{
			get
			{
				return mvarSaldoActualD;
			}
			set
			{
				mvarSaldoActualD = value;
			}
		}
		
		
		
		public string EjeNomS
		{
			get
			{
				return mvarEjeNomS;
			}
			set
			{
				mvarEjeNomS = value;
			}
		}
		
		
		
		public int DigitoVerifI
		{
			get
			{
				return mvarDigitoVerifI;
			}
			set
			{
				mvarDigitoVerifI = value;
			}
		}
		
		
		
		public int RollOverI
		{
			get
			{
				return mvarRollOverI;
			}
			set
			{
				mvarRollOverI = value;
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