using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsConfiguracionSBF
	{
	
		
		private int mvarCodigoI = 0;
		private bool mvarArchivoCorteB = false;
		private bool mvarArchivoDiarioB = false;
		private bool mvarReporteDerivadoB = false;
		
		public bool fncValidaGeneracionSbfB()
		{
			//OJO que se tiene que hacer
			return false;
		}
		
		//UPGRADE_NOTE: (7001) The following declaration (fncValidaUnidadesB) seems to be dead code
		//private bool fncValidaUnidadesB()
		//{
				//OJO que se tiene que hacer
				//return false;
		//}
		
		
		public bool ReporteDerivadoB
		{
			get
			{
				return mvarReporteDerivadoB;
			}
			set
			{
				mvarReporteDerivadoB = value;
			}
		}
		
		
		
		public bool ArchivoDiarioB
		{
			get
			{
				return mvarArchivoDiarioB;
			}
			set
			{
				mvarArchivoDiarioB = value;
			}
		}
		
		
		
		public bool ArchivoCorteB
		{
			get
			{
				return mvarArchivoCorteB;
			}
			set
			{
				mvarArchivoCorteB = value;
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