using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colCatEmpresas
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		public void  prObtenEmpresa(ref  clsCorporativo crppCorporativo)
		{
			
			int llEmpresa = 0;
			string slNombre = String.Empty;
			int llIndice = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCEMP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + crppCorporativo.ProductoPRD.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + crppCorporativo.ProductoPRD.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + crppCorporativo.CorporativoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by emp_num";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						this.prClear();
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							llEmpresa = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							slNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
							//llIndice = Me.fncBuscaEmpresaL(crppCorporativo.ProductoPRD, crppCorporativo, llEmpresa)
							//If llIndice = 0 Then
							this.Add(crppCorporativo.ProductoPRD, crppCorporativo, llEmpresa, slNombre);
							//End If
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenEmpresa)",e );
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
		
		public int fncBuscaEmpresaL( clsProducto prdpProducto,  clsCorporativo crppCorporativo,  int lpEmpresa)
		{
			int result = 0;
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
                        //AIS-1135 NGONZALEZ
						if (this[llCont].ProductoPRD.PrefijoL == prdpProducto.PrefijoL && this[llCont].ProductoPRD.BancoL == prdpProducto.BancoL && this[llCont].CorporativoCRP.CorporativoL == crppCorporativo.CorporativoL && this[llCont].EmpresaL == lpEmpresa)
						{
							result = llCont;
							break;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenEmpresa)",e);
				return result;
			}
			
			return result;
		}
		
		public clsEmpresa Add( clsProducto ProductoPRD,  clsCorporativo CorporativoCRP,  int EmpresaL,  string NombreS,  clsUnidad UnidadUNI, ref  string sKey)
		{
			clsEmpresa result = new clsEmpresa();
			clsEmpresa objNewMember = null;
			
			try
			{
					
					objNewMember = new clsEmpresa();
					
					//set the properties passed into the method
					if (Information.IsReference(CorporativoCRP))
					{
						objNewMember.CorporativoCRP = CorporativoCRP;
						if (objNewMember.CorporativoCRP == null)
						{
							objNewMember.CorporativoCRP = new clsCorporativo();
						}
					} else
					{
						objNewMember.CorporativoCRP = CorporativoCRP;
					}
					
					if (Information.IsReference(ProductoPRD))
					{
						objNewMember.ProductoPRD = ProductoPRD;
						if (objNewMember.ProductoPRD == null)
						{
							objNewMember.ProductoPRD = CorporativoCRP.ProductoPRD;
						}
					} else
					{
						objNewMember.ProductoPRD = ProductoPRD;
					}
					
					objNewMember.EmpresaL = EmpresaL;
					objNewMember.NombreS = NombreS;
					if (Information.IsReference(UnidadUNI))
					{
						objNewMember.UnidadUNI = UnidadUNI;
					} else
					{
						objNewMember.UnidadUNI = UnidadUNI;
					}
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
				
				CRSGeneral.prObtenError(this.GetType().Name + "(AddcolcatEmpresas)",e );
				return result;
			}
			
			return result;
		}
		
		public clsEmpresa Add( clsProducto ProductoPRD,  clsCorporativo CorporativoCRP,  int EmpresaL,  string NombreS,  clsUnidad UnidadUNI)
		{
			string tempRefParam = "";
			return Add(ProductoPRD, CorporativoCRP, EmpresaL, NombreS, UnidadUNI, ref tempRefParam);
		}
		
		public clsEmpresa Add( clsProducto ProductoPRD,  clsCorporativo CorporativoCRP,  int EmpresaL,  string NombreS)
		{
			string tempRefParam2 = "";
			return Add(ProductoPRD, CorporativoCRP, EmpresaL, NombreS, null, ref tempRefParam2);
		}
		
		public clsEmpresa this[int vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				return (clsEmpresa) mCol[vntIndexKey];
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
		
		
		public void  Remove( int vntIndexKey)
		{
			//used when removing an element from the collection
			//vntIndexKey contains either the Index or Key, which is why
			//it is declared as a Variant
			//Syntax: x.Remove(xyz)
                mCol.Remove((int)vntIndexKey);
		}
		
		
		public colCatEmpresas(){
			//creates the collection when this class is created
		}
	
	
	~colCatEmpresas(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}