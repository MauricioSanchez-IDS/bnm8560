using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsTelefono
	{
	
		
		//local variable(s) to hold property value(s)
		private string mvarNumeroTelefonicoS = String.Empty; //local copy
		private string mvarTelefonoS = String.Empty; //local copy
		private string mvarAccesoServicioS = String.Empty; //local copy
		private string mvarIdRegionS = String.Empty; //local copy
		private string mvarSeparadorS = String.Empty; //local copy
		private string mvarMascaraS = String.Empty; //local copy
		private string mvarExtensionS = String.Empty; //local copy
		
		
		public string ExtensionS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.ExtensionS
				return mvarExtensionS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.ExtensionS = 5
				mvarExtensionS = value;
			}
		}
		
		
		
		
		
		
		public string MascaraS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.MascaraS
				return mvarMascaraS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.MascaraS = 5
				mvarMascaraS = value;
			}
		}
		
		
		
		
		
		
		public string SeparadorS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SeparadorS
				return mvarSeparadorS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SeparadorS = 5
				mvarSeparadorS = value;
			}
		}
		
		
		
		
		
		
		public string IdRegionS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.IdRegionS
				return mvarIdRegionS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.IdRegionS = 5
				mvarIdRegionS = value;
			}
		}
		
		
		
		
		
		
		public string AccesoServicioS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.AccesoServicioS
				return mvarAccesoServicioS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.AccesoServicioS = 5
				mvarAccesoServicioS = value;
			}
		}
		
		
		
		
		
		
		public string TelefonoS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TelefonoS
				return mvarTelefonoS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TelefonoS = 5
				mvarTelefonoS = value;
			}
		}
		
		
		
		
		
		
		public string NumeroTelefonicoS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NumeroTelefonicoS
				return mvarNumeroTelefonicoS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NumeroTelefonicoS = 5
				mvarNumeroTelefonicoS = value;
			}
		}
		
	}
}