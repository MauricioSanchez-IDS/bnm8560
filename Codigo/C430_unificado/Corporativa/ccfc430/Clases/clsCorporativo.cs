using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsCorporativo
	{
	
		
		//local variable(s) to hold property value(s)
		private clsProducto mvarProductoPRD = null; //local copy
		private int mvarCorporativoL = 0; //local copy
		private string mvarNombreS = String.Empty; //local copy
		private colCatEmpresas mvarcolCatEmpresas = null;
		
		
		
		
		public colCatEmpresas colCatEmpresas
		{
			get
			{
				if (mvarcolCatEmpresas == null)
				{
					mvarcolCatEmpresas = new colCatEmpresas();
				}
				
				
				return mvarcolCatEmpresas;
			}
			set
			{
				mvarcolCatEmpresas = value;
			}
		}
		
		
		
		
		
		
		public string NombreS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NombreS
				return mvarNombreS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NombreS = 5
				mvarNombreS = value;
			}
		}
		
		
		
		
		
		
		public int CorporativoL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.CorporativoL
				return mvarCorporativoL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.CorporativoL = 5
				mvarCorporativoL = value;
			}
		}
		
		
		
		
		
		
		public clsProducto ProductoPRD
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.ProductoPRD
				return mvarProductoPRD;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.ProductoPRD = Form1
				mvarProductoPRD = value;
			}
		}
		
		~clsCorporativo(){
			mvarcolCatEmpresas = null;
		}
}
}