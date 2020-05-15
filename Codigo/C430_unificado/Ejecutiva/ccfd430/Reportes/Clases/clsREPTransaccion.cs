using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsREPTransaccion
	{
	
		
		private int mvarEjePrefijoI = 0;
		private int mvarGpoBancoI = 0;
		private int mvarEmpNumI = 0;
		private int mvarEjeNumI = 0;
		private string mvarNumeroCuentaS = String.Empty;
		private string mvarNombreEjecutivoS = String.Empty;
		private string mvarFechaProcesoS = String.Empty;
		private string mvarFechaTransaccionS = String.Empty;
		private double mvarImporteD = 0;
		private string mvarNegocioS = String.Empty;
		private string mvarReferenciaS = String.Empty;
		private string mvarPaisS = String.Empty;
		private string mvarCiudadS = String.Empty;
		
		
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
		
		
		
		public string FechaProcesoS
		{
			get
			{
				return mvarFechaProcesoS;
			}
			set
			{
				mvarFechaProcesoS = value;
			}
		}
		
		
		
		public string FechaTransaccionS
		{
			get
			{
				return mvarFechaTransaccionS;
			}
			set
			{
				mvarFechaTransaccionS = value;
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
		
		
		
		public string NegocioS
		{
			get
			{
				return mvarNegocioS;
			}
			set
			{
				mvarNegocioS = value;
			}
		}
		
		
		
		public string ReferenciaS
		{
			get
			{
				return mvarReferenciaS;
			}
			set
			{
				mvarReferenciaS = value;
			}
		}
		
		
		
		public string PaisS
		{
			get
			{
				return mvarPaisS;
			}
			set
			{
				mvarPaisS = value;
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
		
		
		public clsREPTransaccion(){
			EjePrefijoI = 0;
			GpoBancoI = 0;
			EmpNumI = 0;
			EjeNumI = 0;
			NumeroCuentaS = "";
			NombreEjecutivoS = "";
			FechaProcesoS = "";
			FechaTransaccionS = "";
			ImporteD = 0d;
			NegocioS = "";
			ReferenciaS = "";
			PaisS = "";
			CiudadS = "";
		}
}
}