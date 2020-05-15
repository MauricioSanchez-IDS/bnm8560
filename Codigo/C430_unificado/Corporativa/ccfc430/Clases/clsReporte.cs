using Artinsoft.VB6.Utils; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsReporte
	{
	
		private int mvarReporteIdI = 0; //local copy
		private string mvarReporteIdS = String.Empty; //local copy
		private string mvarMascaraS = String.Empty; //local copy
		private string mvarNombreS = String.Empty; //local copy
		
		
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
		
		
		
		public string MascaraS
		{
			get
			{
				return mvarMascaraS;
			}
			set
			{
				mvarMascaraS = value;
			}
		}
		
		
		
		public string ReporteIdS
		{
			get
			{
				mvarReporteIdS = mdlParametros.ctesPrefijoReporte + StringsHelper.Format(ReporteIdI, MascaraS);
				return mvarReporteIdS;
			}
			set
			{
				mvarReporteIdS = value;
			}
		}
		
		
		
		public int ReporteIdI
		{
			get
			{
				return mvarReporteIdI;
			}
			set
			{
				mvarReporteIdI = value;
			}
		}
		
		
		public clsReporte(){
			MascaraS = mdlParametros.ctesMascaraRep;
		}
}
}