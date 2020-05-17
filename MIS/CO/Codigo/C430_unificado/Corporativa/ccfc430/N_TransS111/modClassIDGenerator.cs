using System;
//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

namespace N_TransS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
	internal static class modClassIDGenerator
	{

        public static COMDRV32.TcpServer objSeguridad = null; //Objeto de Conexion al S111
		static int lClassDebugID_GetNextClassDebugID = 0;
		internal static int GetNextClassDebugID()
		{
			//class ID generator
			lClassDebugID_GetNextClassDebugID++;
			return lClassDebugID_GetNextClassDebugID;
		}
	}
}