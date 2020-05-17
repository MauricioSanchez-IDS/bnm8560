using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
    //AIS-1157 NGONZALEZ
	internal class colCatCorporativos
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		public void  prObtenCorporativos(ref  clsProducto prdpProducto)
		{
			
			int llCorporativo = 0;
			string slNombre = String.Empty;
			int llIndice = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_nom";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCOR01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + prdpProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + prdpProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by gpo_num";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							llCorporativo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							slNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
							//llIndice = Me.fncBuscaCorporativoL(prdpProducto, llCorporativo)
							//If llIndice = 0 Then
							this.Add(prdpProducto, llCorporativo, slNombre);
							//End If
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenCorporativos)",e );
				return;
			}
			
		}
		
		public int fncBuscaCorporativoL( clsProducto prdpProducto,  int lpCorporativo)
		{
			int result = 0;
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
                        //AIS-1135 NGONZALEZ
						if (this[llCont].ProductoPRD.PrefijoL == prdpProducto.PrefijoL && this[llCont].ProductoPRD.BancoL == prdpProducto.BancoL && this[llCont].CorporativoL == lpCorporativo)
						{
							result = llCont;
							break;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaCorporativo)",e );
				return result;
			}
			
			return result;
		}
		
		public clsCorporativo Add( clsProducto ProductoPRD,  int CorporativoL,  string NombreS, ref  colCatEmpresas colCatEmpresas, ref  string sKey)
		{
			clsCorporativo result = new clsCorporativo();
			clsCorporativo objNewMember = null;
			
			try
			{
					
					objNewMember = new clsCorporativo();
					
					if (colCatEmpresas == null || false)
					{
						colCatEmpresas = new colCatEmpresas();
					}
					
					//set the properties passed into the method
					if (Information.IsReference(ProductoPRD))
					{
						objNewMember.ProductoPRD = ProductoPRD;
						if (objNewMember.ProductoPRD == null)
						{
							objNewMember.ProductoPRD = new clsProducto();
						}
					} else
					{
						objNewMember.ProductoPRD = ProductoPRD;
					}
					objNewMember.CorporativoL = CorporativoL;
					objNewMember.NombreS = NombreS;
					objNewMember.colCatEmpresas = colCatEmpresas;
					if (sKey.Length == 0)
					{
						mCol.Add(objNewMember, null, null, null);
					} else
					{
						mCol.Add(objNewMember, sKey, null, null);
					}
					
					
					//return the object created
					result = objNewMember;
					objNewMember = null;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(AddcolCatCorporativo)",e );
				return result;
			}
			
			return result;
		}
		
		public clsCorporativo Add( clsProducto ProductoPRD,  int CorporativoL,  string NombreS, ref  colCatEmpresas colCatEmpresas)
		{
			string tempRefParam = "";
			return Add(ProductoPRD, CorporativoL, NombreS, ref colCatEmpresas, ref tempRefParam);
		}
		
		public clsCorporativo Add( clsProducto ProductoPRD,  int CorporativoL,  string NombreS)
		{
			colCatEmpresas tempRefParam2 = null;
			string tempRefParam3 = "";
			return Add(ProductoPRD, CorporativoL, NombreS, ref tempRefParam2, ref tempRefParam3);
		}
		
		public clsCorporativo this[object vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsCorporativo) mCol[Convert.ToInt32(vntIndexKey)];
			}
		}
		
		
		
		
		public int Count
		{
			get
			{
				//used when retrieving the number of elements in the
				//collection. Syntax: Debug.Print x.Count
				return mCol.Count;
			}
		}
		
		
		
		
		public IEnumerator GetEnumerator()
		{
			//this property allows you to enumerate
			//this collection with the For...Each syntax
			return mCol.GetEnumerator();
		}
		
		
		public void  Remove( string vntIndexKey)
		{
			//used when removing an element from the collection
			//vntIndexKey contains either the Index or Key, which is why
			//it is declared as a Variant
			//Syntax: x.Remove(xyz)
			
			//AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
			mCol.Remove(vntIndexKey.ToString());
            else
                //AIS-1172 NGONZALEZ
            mCol.Remove(Convert.ToInt32(vntIndexKey));
		}
		
		
		public colCatCorporativos(){
			//creates the collection when this class is created
		}
	
	
	~colCatCorporativos(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}