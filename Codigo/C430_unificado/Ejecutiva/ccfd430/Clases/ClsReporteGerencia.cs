using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class ClsReporteGerencia
	{
	
		private int lngCol = 0;
		private int lngRow = 0;
		private int intReporte = 0;
		private string strId = String.Empty;
		private string strFrecuencia = String.Empty;
		
		public int Col
		{
			get
			{
				return lngCol;
			}
			set
			{
				lngCol = value;
			}
		}
		
		
		public int Row
		{
			get
			{
				return lngRow;
			}
			set
			{
				lngRow = value;
			}
		}
		
		
		public int Reporte
		{
			get
			{
				return intReporte;
			}
			set
			{
				intReporte = value;
			}
		}
		
		
		public string Id
		{
			get
			{
				return strId;
			}
			set
			{
				strId = value;
			}
		}
		
		public string Frecuencia
		{
			get
			{
				return strFrecuencia;
			}
			set
			{
				strFrecuencia = value;
			}
		}
		
	}
}