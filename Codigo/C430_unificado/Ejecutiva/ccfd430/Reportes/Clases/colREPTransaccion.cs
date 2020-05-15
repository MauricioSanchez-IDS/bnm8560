using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
    //AIS-1157 NGONZALEZ
	internal class colREPTransaccion
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		public clsREPTransaccion Add( string PaisS,  string CiudadS,  string ReferenciaS,  string NegocioS,  double ImporteD,  string FechaTransaccionS,  string FechaProcesoS,  string NombreEjecutivoS,  string NumeroCuentaS,  int EjeNumI,  int EmpNumI,  int GpoBancoI,  int EjePrefijoI, ref  string sKey)
		{
			//create a new object
			clsREPTransaccion objNewMember = new clsREPTransaccion();
			
			//set the properties passed into the method
			objNewMember.PaisS = PaisS;
			objNewMember.CiudadS = CiudadS;
			objNewMember.ReferenciaS = ReferenciaS;
			objNewMember.NegocioS = NegocioS;
			objNewMember.ImporteD = ImporteD;
			objNewMember.FechaTransaccionS = FechaTransaccionS;
			objNewMember.FechaProcesoS = FechaProcesoS;
			objNewMember.NombreEjecutivoS = NombreEjecutivoS;
			objNewMember.NumeroCuentaS = NumeroCuentaS;
			objNewMember.EjeNumI = EjeNumI;
			objNewMember.EmpNumI = EmpNumI;
			objNewMember.GpoBancoI = GpoBancoI;
			objNewMember.EjePrefijoI = EjePrefijoI;
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
		
		public clsREPTransaccion Add( string PaisS,  string CiudadS,  string ReferenciaS,  string NegocioS,  double ImporteD,  string FechaTransaccionS,  string FechaProcesoS,  string NombreEjecutivoS,  string NumeroCuentaS,  int EjeNumI,  int EmpNumI,  int GpoBancoI,  int EjePrefijoI)
		{
			string tempRefParam = "";
			return Add(PaisS, CiudadS, ReferenciaS, NegocioS, ImporteD, FechaTransaccionS, FechaProcesoS, NombreEjecutivoS, NumeroCuentaS, EjeNumI, EmpNumI, GpoBancoI, EjePrefijoI, ref tempRefParam);
		}
		
		public clsREPTransaccion this[int vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				return (clsREPTransaccion) mCol[vntIndexKey];
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
		
		public colREPTransaccion(){
			//creates the collection when this class is created
		}
	
	~colREPTransaccion(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}