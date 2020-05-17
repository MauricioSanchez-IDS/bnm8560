using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colREPUnidades
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		public clsREPUnidad Add( string NombreS,  int PrefijoL,  int BancoL,  int EmpresaL,  int GrupoL,  string IdS,  string IdPadreS,  int NivelI,  string CalleS,  string ColoniaS,  string CiudadS,  string PoblacionS,  string EstadoS,  int CodigoPostalL,  string TelefonoS,  string FaxS,  string CelularS,  string CorreoElectronicoS,  string PaisS,  clsREPResumenUnidad ResumenRUN,  colREPUnidades colUnidades,  int ipAño,  int ipPeriodo, ref  string sKey)
		{
			
			//Create a new object
			clsREPUnidad objNewMember = new clsREPUnidad();
			//set the properties passed into the method
			objNewMember.NombreS = NombreS;
			objNewMember.PrefijoL = PrefijoL;
			objNewMember.BancoL = BancoL;
			objNewMember.EmpresaL = EmpresaL;
			objNewMember.GrupoL = GrupoL;
			objNewMember.IdS = IdS;
			objNewMember.IdPadreS = IdPadreS;
			objNewMember.NivelI = NivelI;
			objNewMember.CalleS = CalleS;
			objNewMember.ColoniaS = ColoniaS;
			objNewMember.CiudadS = CiudadS;
			objNewMember.PoblacionS = PoblacionS;
			objNewMember.EstadoS = EstadoS;
			objNewMember.CodigoPostalL = CodigoPostalL;
			objNewMember.TelefonoS = TelefonoS;
			objNewMember.FaxS = FaxS;
			objNewMember.CelularS = CelularS;
			objNewMember.CorreoElectronicoS = CorreoElectronicoS;
			objNewMember.PaisS = PaisS;
			objNewMember.PeriodoCorteI = ipPeriodo;
			objNewMember.AñoCorteI = ipAño;
			
			if (Information.IsReference(ResumenRUN))
			{
				objNewMember.ResumenRUN = ResumenRUN;
			} else
			{
				objNewMember.ResumenRUN = ResumenRUN;
			}
            //AIS-1170 NGONZALEZ
			objNewMember.colUnidades = colUnidades;
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
		
		public clsREPUnidad Add( string NombreS,  int PrefijoL,  int BancoL,  int EmpresaL,  int GrupoL,  string IdS,  string IdPadreS,  int NivelI,  string CalleS,  string ColoniaS,  string CiudadS,  string PoblacionS,  string EstadoS,  int CodigoPostalL,  string TelefonoS,  string FaxS,  string CelularS,  string CorreoElectronicoS,  string PaisS,  clsREPResumenUnidad ResumenRUN,  colREPUnidades colUnidades,  int ipAño,  int ipPeriodo)
		{
			string tempRefParam = "";
			return Add(NombreS, PrefijoL, BancoL, EmpresaL, GrupoL, IdS, IdPadreS, NivelI, CalleS, ColoniaS, CiudadS, PoblacionS, EstadoS, CodigoPostalL, TelefonoS, FaxS, CelularS, CorreoElectronicoS, PaisS, ResumenRUN, colUnidades, ipAño, ipPeriodo, ref tempRefParam);
		}
		
		public clsREPUnidad this[int vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				return (clsREPUnidad) mCol[vntIndexKey];
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
		
		
		public colREPUnidades(){
			//creates the collection when this class is created
		}
	
	
	~colREPUnidades(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}