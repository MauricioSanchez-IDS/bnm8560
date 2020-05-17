
using Microsoft.VisualBasic;
using System;
//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

namespace N_ActualizaS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
	internal static class MdlError
	{

		//

		//

		// Define your custom errors here.  Be sure to use numbers
		// greater than 512, to avoid conflicts with OLE error numbers.
		//##ModelId=4051EBE2006A
		public const int MyObjectError1 = 1000;
		//##ModelId=4051EBE200C4
		public const int MyObjectError2 = 1010;
		//##ModelId=4051EBE20133
		public const int MyObjectErrorN = 1234;
		//##ModelId=4051EBE20197
		public const int MyUnhandledError = 9999;

		// This function will retrieve an error description from a resource
		// file (.RES).  The ErrorNum is the index of the string
		// in the resource file.  Called by RaiseError
		//##ModelId=4051EBE20205
		//UPGRADE_NOTE: (7001) The following declaration (GetErrorTextFromResource) seems to be dead code More Information: http://www.vbtonet.com/ewis/ewi7001.aspx
		//private string GetErrorTextFromResource(int ErrorNum)
		//{
				//string result = String.Empty;
				//try
				//{
					//string strMsg = String.Empty;
					//
					// get the string from a resource file
					//
					//return App.Resources.Resources.ResourceManager.GetString("str" + ErrorNum.ToString());
				//}
				//catch (Exception e)
				//{
					////UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
					//if (Information.Err().Number != 0)
					//{
						//result = "An unknown error has occurred!";
					//}
					//return result;
				//}
		//}

		//There are a number of methods for retrieving the error
		//message.  The following method uses a resource file to
		//retrieve strings indexed by the error number you are
		//raising.
		//##ModelId=4051EBE202E1
		internal static void RaiseError(int ErrorNumber, string Source, string Descripcion)
		{
			string strErrorText = String.Empty;
			//Devuelve un error al cliente
			throw new System.Exception(ErrorNumber.ToString() + ", " + Source + ", " + Descripcion);

		}

		//##ModelId=4051EBE300A8
        //internal static object GrabaLog(string psMensaje)
        //{
        //    // Funcion que escribe en el LOG
        //    System.IO.StreamWriter intArch    ;
        //    string lsarchivo = String.Empty;
        //    try
        //    {
        //        lsarchivo = "c:\\APPS\\Atenea\\pryRCons.log";
        //        intArch = null;
        //                            intArch = new System.IO.StreamWriter(System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().OpenFile(lsarchivo,System.IO.FileMode.OpenOrCreate));
        //                            intArch.WriteLine(Artinsoft.Silverlight.Client.Compatibility.DateTimeHelper.ToString(DateTime.Now) + ":  " + psMensaje);
        //                            intArch.Close();
        //    }
        //    catch
        //    {
        //                            intArch = new System.IO.StreamWriter(System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().OpenFile("C:\\Apps\\Atenea\\BitacoraS111.Log",System.IO.FileMode.OpenOrCreate));
        //                            intArch.WriteLine(psMensaje);
        //                            intArch.Close();
        //    }
        //    return null;
        //}
	}
}