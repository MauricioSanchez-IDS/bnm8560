using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
    //AIS-1157 NGONZALEZ
	internal class colEjecutivoBanamex
	: IEnumerable
	{
	
		
		private Collection mCol = new Collection();
		
		public void  prObtenEjecutivoBanamex()
		{
			
			int llNomina = 0; //Número de Nómina del Ejecutivo Banamex
			string slNombre = String.Empty; //Nombre del Ejecutivo Banamex
			int llIndice = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ejx_numero,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ejx_nombre";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJX01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by ejx_nombre";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						this.prClear();
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							llNomina = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							slNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
							this.Add(llNomina, slNombre);
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenEjecutivoBanamex)",e );
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
		
		public int fncBuscaEjecutivoBanamexL( int lpNomina)
		{
			int result = 0;
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
                        //AIS-1135 NGONZALEZ
						if (this[llCont].NominaL == lpNomina)
						{
							result = llCont;
							break;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaEjecutivoBanamex)",e );
				return result;
			}
			
			return result;
		}
		
		public clsEjecutivoBanamex Add( int NominaL,  string NombreS, ref  string sKey)
		{
			
			clsEjecutivoBanamex objNewMember = new clsEjecutivoBanamex();
			objNewMember.NominaL = NominaL;
			objNewMember.NombreS = NombreS;
			
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			return objNewMember;
			
		}
		
		public clsEjecutivoBanamex Add( int NominaL,  string NombreS)
		{
			string tempRefParam = "";
			return Add(NominaL, NombreS, ref tempRefParam);
		}
		
		public clsEjecutivoBanamex this[object vntIndexKey]
		{
			get
			{
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsEjecutivoBanamex) mCol[Convert.ToInt32(vntIndexKey)];
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
            //AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
                mCol.Remove(vntIndexKey.ToString());
            else
                mCol.Remove((int)vntIndexKey);
		}
		
		
		~colEjecutivoBanamex(){
			mCol = null;
		}
}
}