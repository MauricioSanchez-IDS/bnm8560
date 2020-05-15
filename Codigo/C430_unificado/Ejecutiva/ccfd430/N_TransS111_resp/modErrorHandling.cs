#define DebugDll
using System;
using System.IO;

//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

using Microsoft.VisualBasic;

namespace N_TransS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
    //using Artinsoft.Silverlight.Client.Application;
	internal static class modErrorHandling
	{

		//

		// Define your custom errors here.  Be sure to use numbers
		// greater than 512, to avoid conflicts with OLE error numbers.
		public const int MyObjectError1 = 1000;
		public const int MyObjectError2 = 1010;
		public const int MyObjectErrorN = 1234;
		public const int MyUnhandledError = 9999;




		// This function will retrieve an error description from a resource
		// file (.RES).  The ErrorNum is the index of the string
		// in the resource file.  Called by RaiseError
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
		internal static void RaiseError(int ErrorNumber, string Source, string Descripcion)
		{
			string strErrorText = String.Empty;
			//Devuelve un error al cliente
			throw new System.Exception(ErrorNumber.ToString() + ", " + Source + ", " + Descripcion);

		}

		static int ArchivoCreado_GrabaLog = 0;
//        internal static object GrabaLog(string psMensaje)
//        {
//            // Funcion que escribe en el LOG
//            System.IO.StreamWriter intArch    ;
//            string lsArchivo = String.Empty;
//#if DebugDll!=true

//            //UPGRADE_TODO: (1035) #If #EndIf block was not upgraded because the expression DebugDll <> 1 did not evaluate to True or was not evaluated. More Information: http://www.vbtonet.com/ewis/ewi1035.aspx
//            Exit Function
//#endif
//            try
//            {
//                lsArchivo = Artinsoft.Silverlight.Client.VB.Interaction.Environ("Temp");
//                                     if (lsArchivo == "")
//                {
//                    lsArchivo = Path.GetDirectoryName(System.Windows.Application.Current.GetExecutablePath());
//                }
//                //AIS-SL mrojas Added the following line to make sure that the directory exist or create if it doesnt.
//                System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().CreateDirectory(lsArchivo);
//                                     if (Strings.Right(lsArchivo, 1) != "\\")
//                {
//                    lsArchivo = lsArchivo + "\\";
//                }
//                                     lsArchivo = lsArchivo + "TransS111.log";
//                                     intArch = null;
//                                     if (ArchivoCreado_GrabaLog == 1)
//                {
//                                        intArch = new System.IO.StreamWriter(System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().OpenFile(lsArchivo,System.IO.FileMode.OpenOrCreate));
//                                     }
//                                     else
//                {
//                                        intArch = new System.IO.StreamWriter(System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().OpenFile(lsArchivo,System.IO.FileMode.OpenOrCreate));
//                                        ArchivoCreado_GrabaLog = 1;
//                                     }
//                                     intArch.WriteLine(Artinsoft.Silverlight.Client.Compatibility.DateTimeHelper.ToString(DateTime.Now) + ":  " + psMensaje);
//                                     intArch.Close();
//            }
//            catch
//            {
//                lsArchivo = Path.GetDirectoryName(System.Windows.Application.Current.GetExecutablePath());
//                if (Strings.Right(lsArchivo, 1) != "\\")
//                {
//                    lsArchivo = lsArchivo + "\\";
//                }
//                lsArchivo = lsArchivo + "TransS111.log";
//                if (ArchivoCreado_GrabaLog == 1)
//                {
//                                        intArch = new System.IO.StreamWriter(System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().OpenFile(lsArchivo,System.IO.FileMode.OpenOrCreate));
//                                     }
//                                     else
//                {
//                                        intArch = new System.IO.StreamWriter(System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().OpenFile(lsArchivo,System.IO.FileMode.OpenOrCreate));
//                                     }
//                                     intArch.WriteLine(psMensaje);
//                                     intArch.Close();
//            }
//            return null;
//        }
	}
}