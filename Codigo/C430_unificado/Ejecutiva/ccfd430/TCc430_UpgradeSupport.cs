using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class UpgradeSupport
	{
	
		private static RDO.rdoEngine m_RDOrdoEngine_definst = new RDO.rdoEngine();
		internal static RDO.rdoEngine RDOrdoEngine_definst
		{
			get
			{
				return m_RDOrdoEngine_definst;
			}
		}
		
	}
}