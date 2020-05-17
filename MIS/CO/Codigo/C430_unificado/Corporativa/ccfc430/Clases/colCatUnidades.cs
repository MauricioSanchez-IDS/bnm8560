using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colCatUnidades
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
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
		
		public clsUnidad Add( clsEmpresa EmpresaEMP,  string UnidadS,  string NombreS,  int NivelI,  clsUnidad UnidadPadreUNI,  colCatUnidades colCatUnidades, ref  string sKey)
		{
			//create a new object
			clsUnidad objNewMember = new clsUnidad();
			
			
			//set the properties passed into the method
			if (Information.IsReference(EmpresaEMP))
			{
				objNewMember.EmpresaEMP = EmpresaEMP;
				if (objNewMember.EmpresaEMP == null)
				{
					if (UnidadPadreUNI != null)
					{
						if (UnidadPadreUNI.EmpresaEMP == null)
						{
							if (objNewMember.EmpresaEMP == null)
							{
								objNewMember.EmpresaEMP = new clsEmpresa();
							}
						} else
						{
							objNewMember.EmpresaEMP = UnidadPadreUNI.EmpresaEMP;
						}
					} else
					{
						objNewMember.EmpresaEMP = new clsEmpresa();
					}
				}
			} else
			{
				objNewMember.EmpresaEMP = EmpresaEMP;
			}
			if (objNewMember.EmpresaEMP.ProductoPRD == null)
			{
				objNewMember.EmpresaEMP.ProductoPRD = UnidadPadreUNI.EmpresaEMP.ProductoPRD;
				if (objNewMember.EmpresaEMP.ProductoPRD == null)
				{
					objNewMember.EmpresaEMP.ProductoPRD = UnidadPadreUNI.EmpresaEMP.CorporativoCRP.ProductoPRD;
					if (objNewMember.EmpresaEMP.ProductoPRD == null)
					{
						objNewMember.EmpresaEMP.ProductoPRD = new clsProducto();
					}
				}
			}
			objNewMember.UnidadS = UnidadS;
			objNewMember.NombreS = NombreS;
			objNewMember.NivelI = NivelI;
			if (Information.IsReference(UnidadPadreUNI))
			{
				objNewMember.UnidadPadreUNI = UnidadPadreUNI;
				if (objNewMember.UnidadPadreUNI == null)
				{
					objNewMember.UnidadPadreUNI = new clsUnidad();
				}
			} else
			{
				objNewMember.UnidadPadreUNI = UnidadPadreUNI;
			}
			objNewMember.colCatUnidades = colCatUnidades;
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			//return the object created
			return objNewMember;
			
			
		}
		
		public clsUnidad Add( clsEmpresa EmpresaEMP,  string UnidadS,  string NombreS,  int NivelI,  clsUnidad UnidadPadreUNI,  colCatUnidades colCatUnidades)
		{
			string tempRefParam = "";
			return Add(EmpresaEMP, UnidadS, NombreS, NivelI, UnidadPadreUNI, colCatUnidades, ref tempRefParam);
		}
		
		public clsUnidad this[int vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				return (clsUnidad) mCol[vntIndexKey];
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
		
		
		public colCatUnidades(){
			//creates the collection when this class is created
		}
	
	
	~colCatUnidades(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}