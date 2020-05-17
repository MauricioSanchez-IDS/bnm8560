using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colREPResumenTH
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		public clsREPResumenTH Add( string CentroCostoS,  string CuentaContableS, ref  string sKey)
		{
			//create a new object
			clsREPResumenTH objNewMember = new clsREPResumenTH();
			
			
			//set the properties passed into the method
			
			objNewMember.CuentaContableS = CuentaContableS;
			objNewMember.CentroCostoS = CentroCostoS;
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
		
		public clsREPResumenTH Add( string CentroCostoS,  string CuentaContableS)
		{
			string tempRefParam = "";
			return Add(CentroCostoS, CuentaContableS, ref tempRefParam);
		}
		
		public clsREPResumenTH this[int vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				return (clsREPResumenTH) mCol[vntIndexKey];
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
                mCol.Remove((Convert.ToInt32(vntIndexKey)));
		}
		
		
		public colREPResumenTH(){
			//creates the collection when this class is created
		}
	
	
	~colREPResumenTH(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}