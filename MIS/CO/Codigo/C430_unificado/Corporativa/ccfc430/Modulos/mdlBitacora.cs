using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class mdlBitacora
	{
	
		
		public enum enuTipoBitacora
		 {
			tbitAdmonUsu = 0 ,
			tbitTransacciones = 1 ,
			tbitViolaciones = 2
		}

        
		static public string sgTipoViolacion = String.Empty;
		static public string sgDescViolacion = String.Empty;
		static public string sgClaveTransaccion = String.Empty;
		static public string sgClaveResolucion = String.Empty;
		
		static public void  prInsertaBitacora( enuTipoBitacora ipTipoBit)
		{
			
			try
			{
					
					switch(ipTipoBit)
					{
						case enuTipoBitacora.tbitAdmonUsu : 
							break;
						case enuTipoBitacora.tbitTransacciones : 
							CORVAR.pszgblsql = "exec spAltaBitacora "; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + CRSParametros.sgUserID + "',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + ((CRSParametros.sgUserName.Trim() == "") ? "NULL": "'" + CRSParametros.sgUserName.Trim() + "'") + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'C430',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sgClaveTransaccion + "',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sgClaveResolucion + "',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'C',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'T'"; 
							 
							break;
						case enuTipoBitacora.tbitViolaciones : 
							CORVAR.pszgblsql = "exec spAltaBitacora "; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + CRSParametros.sgUserID + "',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + ((CRSParametros.sgUserName.Trim() == "") ? "NULL": "'" + CRSParametros.sgUserName.Trim() + "'") + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sgTipoViolacion + "',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sgDescViolacion + "',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'C430',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL" + ","; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'C',"; 
							CORVAR.pszgblsql = CORVAR.pszgblsql + "'V'"; 
							 
							break;
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
						return;
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlBitacora (InsertaBitacora)",e );
				return;
			}
			
		}
	}
}