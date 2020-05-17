using System;
//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

namespace pryActualizaS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
	internal static class modClassIDGenerator
	{

		static int lClassDebugID_GetNextClassDebugID = 0;
		internal static int GetNextClassDebugID()
		{
			//class ID generator
			lClassDebugID_GetNextClassDebugID++;
			return lClassDebugID_GetNextClassDebugID;
		}
	}
}