using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsREPTotales
	{
	
		
		private int mvarEjePrefijoI = 0;
		private int mvarGpoBancoI = 0;
		private int mvarEmpNumI = 0;
		private int mvarEjeNumI = 0;
		private string mvarNumeroCuentaS = String.Empty;
		private string mvarNombreEjecutivoS = String.Empty;
		private string mvarNumeroNominaS = String.Empty;
		private double mvarLimiteCreditoD = 0;
		private string mvarCentroCostosI = String.Empty;
		private int mvarMesesVencidosI = 0;
		private double mvarSaldoAnteriorD = 0;
		private double mvarComprasD = 0;
		private double mvarDisposicionesD = 0;
		private double mvarPagosAbonosD = 0;
		private double mvarComisionesD = 0;
		private double mvarGastosCobrosD = 0;
		private double mvarIvaD = 0;
		private double mvarSaldoNuevoD = 0;
		
		// Los métodos Let son usados cuando se asigna un valor a la propiedad.
		// Los métodos Get son usados cuando se recupera el valor de la propiedad.
		
		
		public int EjePrefijoI
		{
			get
			{
				return mvarEjePrefijoI;
			}
			set
			{
				mvarEjePrefijoI = value;
			}
		}
		
		
		
		public int GpoBancoI
		{
			get
			{
				return mvarGpoBancoI;
			}
			set
			{
				mvarGpoBancoI = value;
			}
		}
		
		
		
		public int EmpNumI
		{
			get
			{
				return mvarEmpNumI;
			}
			set
			{
				mvarEmpNumI = value;
			}
		}
		
		
		
		public int EjeNumI
		{
			get
			{
				return mvarEjeNumI;
			}
			set
			{
				mvarEjeNumI = value;
			}
		}
		
		
		
		public string NumeroCuentaS
		{
			get
			{
				return mvarNumeroCuentaS;
			}
			set
			{
				mvarNumeroCuentaS = value;
			}
		}
		
		
		
		public string NombreEjecutivoS
		{
			get
			{
				return mvarNombreEjecutivoS;
			}
			set
			{
				mvarNombreEjecutivoS = value;
			}
		}
		
		
		
		public string NumeroNominaS
		{
			get
			{
				return mvarNumeroNominaS;
			}
			set
			{
				mvarNumeroNominaS = value;
			}
		}
		
		
		
		public double LimiteCreditoD
		{
			get
			{
				return mvarLimiteCreditoD;
			}
			set
			{
				mvarLimiteCreditoD = value;
			}
		}
		
		
		
		public string CentroCostosI
		{
			get
			{
				return mvarCentroCostosI;
			}
			set
			{
				mvarCentroCostosI = value;
			}
		}
		
		
		
		public int MesesVencidosI
		{
			get
			{
				return mvarMesesVencidosI;
			}
			set
			{
				mvarMesesVencidosI = value;
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
		
		
		
		public double ComprasD
		{
			get
			{
				return mvarComprasD;
			}
			set
			{
				mvarComprasD = value;
			}
		}
		
		
		
		public double DisposicionesD
		{
			get
			{
				return mvarDisposicionesD;
			}
			set
			{
				mvarDisposicionesD = value;
			}
		}
		
		
		
		public double PagosAbonosD
		{
			get
			{
				return mvarPagosAbonosD;
			}
			set
			{
				mvarPagosAbonosD = value;
			}
		}
		
		
		
		public double ComisionesD
		{
			get
			{
				return mvarComisionesD;
			}
			set
			{
				mvarComisionesD = value;
			}
		}
		
		
		
		public double GastosCobrosD
		{
			get
			{
				return mvarGastosCobrosD;
			}
			set
			{
				mvarGastosCobrosD = value;
			}
		}
		
		
		
		public double IvaD
		{
			get
			{
				return mvarIvaD;
			}
			set
			{
				mvarIvaD = value;
			}
		}
		
		
		
		public double SaldoNuevoD
		{
			get
			{
				return mvarSaldoNuevoD;
			}
			set
			{
				mvarSaldoNuevoD = value;
			}
		}
		
		
		public clsREPTotales(){
			EjePrefijoI = 0;
			GpoBancoI = 0;
			EmpNumI = 0;
			EjeNumI = 0;
			NumeroCuentaS = "";
			NombreEjecutivoS = "";
			NumeroNominaS = "";
			LimiteCreditoD = 0d;
			CentroCostosI = "";
			MesesVencidosI = 0;
			SaldoAnteriorD = 0d;
			ComprasD = 0d;
			DisposicionesD = 0d;
			PagosAbonosD = 0d;
			ComisionesD = 0d;
			GastosCobrosD = 0d;
			IvaD = 0d;
			SaldoNuevoD = 0d;
		}
}
}