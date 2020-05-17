using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colcatEstado
	: IEnumerable
	{
	
		
		private Collection mCol = new Collection();
		
		public void  prObtenEstado()
		{
			
			int ilEstado = 0;
			string slClaveEdo = String.Empty;
			string slDescripcionEdo = String.Empty;
			int llIndice = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " edo_id,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " edo_cve_edo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " edo_descripcion";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEDO01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by edo_descripcion asc";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						this.prClear();
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							ilEstado = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							slClaveEdo = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim().ToUpper();
							slDescripcionEdo = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim().ToUpper();
							this.Add(ilEstado, slDescripcionEdo, slClaveEdo);
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e) 
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenEstado)",e );
				return;
			}
			
		}
		
		public void  prClear()
		{
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
						this.Remove(llCont);
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(Clear)",e );
				return;
			}
			
			
		}
		
		public int fncBuscaEstadoI( string spEstado)
		{
			int result = 0;
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
                        //AIS-1135 NGONZALEZ
						if (this[llCont].EstadoS == spEstado.Trim() || this[llCont].AbreviaturaS == spEstado.Trim())
						{
							result = llCont;
							break;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaEstado)",e );
				return result;
			}
			
			return result;
		}
		
		public clsEstado Add( int CodigoI,  string EstadoS,  string AbreviaturaS, ref  string sKey)
		{
			
			
			clsEstado objNewMember = new clsEstado();
			objNewMember.CodigoI = CodigoI;
			objNewMember.EstadoS = EstadoS;
			objNewMember.AbreviaturaS = AbreviaturaS;
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			return objNewMember;
			
		}
		
		public clsEstado Add( int CodigoI,  string EstadoS,  string AbreviaturaS)
		{
			string tempRefParam = "";
			return Add(CodigoI, EstadoS, AbreviaturaS, ref tempRefParam);
		}
		
		public clsEstado this[object vntIndexKey]
		{
			get
			{
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsEstado) mCol[Convert.ToInt32(vntIndexKey)];
			}
		}
		
		
		public int Count
		{
			get
			{
				return mCol.Count;
			}
		}
		
		
		
		public IEnumerator GetEnumerator()
		{
			return mCol.GetEnumerator();
		}
		
		public void  Remove( int vntIndexKey)
		{
                mCol.Remove((int)vntIndexKey);
		}
		
		
		~colcatEstado(){
			mCol = null;
		}
}
}