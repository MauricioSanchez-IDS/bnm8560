using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class ClsTcpIp
	{
	
		private string strUsuario = String.Empty;
		private string strPwd = String.Empty;
		private frmPwdTelnet FrmPassword = null;
		//UPGRADE_NOTE: (7001) The following declaration (FrmPassword_DescargarForma) seems to be dead code
		//private void  FrmPassword_DescargarForma( bool FrmDescargar)
		//{
				//FrmPassword.Close();
				//FrmPassword = null;
		//}
		
		~ClsTcpIp(){
			if (FrmPassword != null)
			{
				FrmPassword.Close();
			}
			FrmPassword = null;
			
		}
	
	//Private Sub PrValoresIniciales()
	//    'Lee del archivo ini de la aplicacion
	//    strUsuario = fncReadIniS("Corporativa", "UserTelnet") 'Determina el usuario con el que se conectará al sistema.
	//   ' strDireccionIp = fncReadIniS("Corporativa", "HostTelnet")
	//
	//End Sub
	
	
	public void  PrPreguntaPassword( string strTitulo)
	{
			FrmPassword = frmPwdTelnet.CreateInstance();
			FrmPassword.Text = "Tarjeta Corporativa";
			FrmPassword.LblMensaje.Text = strTitulo;
			FrmPassword.Refresh();
			Cursor.Current = Cursors.Default;
			FrmPassword.ShowDialog();
			if (FrmPassword.LoginSucceeded)
			{
				strPwd = FrmPassword.txtPassword.Text;
			} else
			{
				strPwd = "";
			}
			FrmPassword.Close();
			FrmPassword = null;
	}
	
	public string Password
	{
		get
		{
		//Password = strPwd   'Lee el valor proporcionado en la pantalla de password del telnet
		//Password = "uc430ftp" 'ya nose utilizará YURIA 26/05/06
		return String.Empty;
		}
	}
	
	public string Host
	{
		get
		{
		return mdlParametros.fncReadIniS("Corporativa", "HostTuxedo");
		}
	}
	
	public string User
	{
		get
		{
		//User = fncReadIniS("Corporativa", "UserTuxedo")
		//User = "c4300009" ya no se utilizará YURIA 26/05/06
		return String.Empty;
		}
	}
	
	
	public int get_Puerto( string strServicio)
	{
			//Recibe como parametro el servicio al que se desea conectar FTP o Telnet
			
			if (Boolean.Parse((strServicio == "FTP").ToString().ToUpper()))
			{
				double dbNumericTemp = 0;
				if (Double.TryParse(mdlParametros.fncReadIniS("Corporativa", "PuertoFtp"), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
				{
					return Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "PuertoFtp"));
				} else
				{
					return 21; //El valor por defecto de un puerto Ftp es el 21
				}
			} else
			{
				double dbNumericTemp2 = 0;
				if (Double.TryParse(mdlParametros.fncReadIniS("Corporativa", "PuertoTelnet"), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
				{
					return Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "PuertoTelnet"));
				} else
				{
					return 23; //El valor por defecto de un puerto ftp es 21
				}
			}
	}
	
	public string DirRemotoFtp
	{
		get
		{
		string strDirRemoto = mdlParametros.fncReadIniS("Corporativa", "DirRemotoFtp");
		if (strDirRemoto == "")
		{
		MdlCambioMasivo.MsgInfo("La variable DirRemotoFtp " + "\r" + 
		                        "No fue encontrado en el archivo de configuración" + "\r" + 
		                        "Se tomará por defecto el directorio raiz");
		strDirRemoto = "/";
		}
		strDirRemoto = Strings.Replace(strDirRemoto, "\\", "/", 1, -1, CompareMethod.Binary); //Elimina el "\" por que en unix no es recomendable
		if (! strDirRemoto.EndsWith("/"))
		{
		strDirRemoto = strDirRemoto + "/";
		}
		return strDirRemoto;
		}
	}
	
	public string DirLocalCte
	{
		get
		{
		string strDirLocal = mdlParametros.fncReadIniS("Corporativa", "DirLocalFtp");
		if (strDirLocal == "")
		{
		MdlCambioMasivo.MsgInfo("La variable DirLocalFtp " + "\r" + 
		                        "No fue encontrado en el archivo de configuración" + "\r" + 
		                        "Se tomará por defecto el directorio raiz");
		strDirLocal = "c:\\";
		}
		strDirLocal = Strings.Replace(strDirLocal, "/", "\\", 1, -1, CompareMethod.Binary); //Elimina el "/" por que en windows  no es recomendable
		if (! strDirLocal.EndsWith("\\"))
		{
		strDirLocal = strDirLocal + "\\";
		}
		return strDirLocal;
		
		}
	}
	
}
}