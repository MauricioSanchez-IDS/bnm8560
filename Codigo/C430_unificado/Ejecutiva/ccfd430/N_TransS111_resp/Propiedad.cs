#define DebugMode
using System;

//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

namespace N_TransS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
	public class ClsPropiedad
	{

		//
		//set this to 0 to disable debug code in this class
#if DebugMode

		//local variable to hold the serialized class ID that was created in Class_Initialize
		//##ModelId=4002D3740133
		private int mlClassDebugID = 0;
#endif
		private string mStrNombre = String.Empty; //Determina el nombre de la propiedad a buscar
		private string mVarValor = String.Empty; //Determina el valor almancenado por la propiedad
		//##ModelId=4002D37402D7
		public ClsPropiedad()
		{
			#if DebugMode

			//get the next available class ID, and print out
			//that the class was created successfully
			mlClassDebugID = modClassIDGenerator.GetNextClassDebugID();
			System.Diagnostics.Debug.WriteLine("'" + this.GetType().Name + "' instance " + mlClassDebugID.ToString() + " created");
			#endif
			
			
		}

		//##ModelId=4002D3740331
		~ClsPropiedad()
		{
#if DebugMode

			//the class is being destroyed
			System.Diagnostics.Debug.WriteLine("'" + this.GetType().Name + "' instance " + mlClassDebugID.ToString() + " is terminating");
#endif
		}

#if DebugMode

		//##ModelId=4002D37401BF
		public int ClassDebugID
		{
			get
			{
				//if we are in debug mode, surface this property that consumers can query
				return mlClassDebugID;
			}
		}

		public string Nombre
		{
			get
			{
				//Nombre de la propiedad actual
				return mStrNombre;
			}
			set
			{
				mStrNombre = value;
			}
		}

		public string Valor
		{
			get
			{
				//Valor Almacenado en la propiedad actual
				return mVarValor;
			}
			set
			{
				//Asigna el valor actual de la propiedad
				mVarValor = value;
			}
		}

#endif
	}
}