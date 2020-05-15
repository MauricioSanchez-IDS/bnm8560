using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsSBFEmpresa
	{
	
		
		public enum enuTipoSBFEmpresa
		 {
			tsbfEmpresaSBF = 1 ,
			tsbfEmpresaC430 = 2
		}
		
		private int mvarEmpNumL = 0;
		private string mvarEmpNomS = String.Empty;
		private string mvarTipoFactS = String.Empty;
		private int mvarTHSNumL = 0;
		private int mvarTransNumL = 0;
		private double mvarSaldoAnteriorD = 0;
		private double mvarSaldoActualD = 0;
		private clsProducto mvarproductoPRD = null;
		
		
		public clsProducto productoPRD
		{
			get
			{
				return mvarproductoPRD;
			}
			set
			{
				mvarproductoPRD = value;
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
		
		
		
		public int TransNumL
		{
			get
			{
				return mvarTransNumL;
			}
			set
			{
				mvarTransNumL = value;
			}
		}
		
		
		
		public int THSNumL
		{
			get
			{
				return mvarTHSNumL;
			}
			set
			{
				mvarTHSNumL = value;
			}
		}
		
		
		
		public string TipoFactS
		{
			get
			{
				return mvarTipoFactS;
			}
			set
			{
				mvarTipoFactS = value;
			}
		}
		
		
		
		public string EmpNomS
		{
			get
			{
				return mvarEmpNomS;
			}
			set
			{
				mvarEmpNomS = value;
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
		
	}
}