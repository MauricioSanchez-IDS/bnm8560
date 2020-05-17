using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsSBFC430Empresa
	{
	
		public enum enuTipoSBFC430Empresa
		 {
			tsbfc430EmpresaSBF = 1 ,
			tsbfc430EmpresaC430 = 2
		}
		
		//local variable(s) to hold property value(s)
		private int mvarEmpNumL = 0; //local copy
		private string mvarEmpNumNomS = String.Empty; //local copy
		private clsProducto mvarproductoPRD = null; //local copy
		private double mvarSaldoAnteriorD = 0; //local copy
		private double mvarSaldoActualD = 0; //local copy
		private int mvarTHSNumL = 0; //local copy
		private int mvarTransNumL = 0; //local copy
		private string mvarTipoFactS = String.Empty; //local copy
		
		
		public string TipoFactS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TipoFactS
				return mvarTipoFactS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TipoFactS = 5
				mvarTipoFactS = value;
			}
		}
		
		
		
		
		
		
		public int TransNumL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TransNumL
				return mvarTransNumL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TransNumL = 5
				mvarTransNumL = value;
			}
		}
		
		
		
		
		
		
		public int THSNumL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.THSNumL
				return mvarTHSNumL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.THSNumL = 5
				mvarTHSNumL = value;
			}
		}
		
		
		
		
		
		
		public double SaldoActualD
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SaldoActualD
				return mvarSaldoActualD;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SaldoActualD = 5
				mvarSaldoActualD = value;
			}
		}
		
		
		
		
		
		
		public double SaldoAnteriorD
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SaldoAnteriorD
				return mvarSaldoAnteriorD;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SaldoAnteriorD = 5
				mvarSaldoAnteriorD = value;
			}
		}
		
		
		
		
		
		
		public clsProducto productoPRD
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.productoPRD
				return mvarproductoPRD;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.productoPRD = Form1
				mvarproductoPRD = value;
			}
		}
		
		
		
		
		
		
		public string EmpNumNomS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.EmpNumNomS
				return mvarEmpNumNomS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.EmpNumNomS = 5
				mvarEmpNumNomS = value;
			}
		}
		
		
		
		
		public int EmpNumL
		{
			get
			{
				return mvarEmpNumL;
			}
			set
			{
				mvarEmpNumL = value;
			}
		}
		
	}
}