using Microsoft.VisualBasic; 
using System; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class MdlCambioMasivo
	{
	
		
		
		
		public const string TRANS_SKIP_PAYMENT = "S";
		public const string TRANS_PORC_DISP = "D";
		public const string TRANS_PIN_PLASTICO = "P";
		public const string TRANS_TIPO_BLOQUEO = "Q";
		public const string TRANS_CAMBIO_TABLAMCC = "M";
		static public object Nvl( object Valor,  object Default_Renamed)
		{
			//Elimina los nulos si es que existen y devuelve un valor por defecto
			//UPGRADE_WARNING: (1068) Valor of type Variant is being forced to string.
           object aux = null;
           if (Valor is ADODB.InternalField)
           {
               ADODB.InternalField ado = (ADODB.InternalField)Valor;
               if (Convert.ToString(ado.Value) + "" == "")
               {
                   return Default_Renamed;
               }
               else
               {
                   try
                   {
                       aux = ado.Value;
                   }
                   catch { }
                   return aux;
               }
           
           }
           else if (Convert.ToString(Valor) + "" == "")
           {
               return Default_Renamed;
           }
           else
           {

               try
               {
                   aux = Valor;
               }
               catch { }
               return aux;
           }
		}
		static public bool fnGetError(ref  string strModulo)
		{
			bool result = false;
			//UPGRADE_ISSUE: (1040) IsMissing function is not supported.
            //AIS-1123 NGONZALEZ
			if (strModulo == null)
			{
				strModulo = "";
			}
			
			StringBuilder strError = new StringBuilder();
			if (VBSQL.gConn[10] != null)
			{
				for (int intErrors = 0; intErrors <= VBSQL.gConn[10].Errors.Count - 1; intErrors++)
				{
					strError.Append("Número:" + VBSQL.gConn[10].Errors[intErrors].Number.ToString() + "\r");
					strError.Append("Fuente:" + VBSQL.gConn[10].Errors[intErrors].Source + "\r");
					strError.Append("Descripción:" + VBSQL.gConn[10].Errors[intErrors].Description + "\r");
				}
			}
			if (strError.ToString() == "")
			{
				MsgInfo("Se provoco el siguiente error " + 
				        "\r" + "Numero:" + Information.Err().Number.ToString() + 
				        "\r" + "Descripción:" + Information.Err().Description, ref strModulo);
				
			} else
			{
				
				MsgInfo("Se provoco un error de base de datos " + "\r" + strError.ToString(), ref strModulo);
			}
			
			return result;
		}
		
		static public bool fnGetError()
		{
			string tempRefParam = "";
			return fnGetError(ref tempRefParam);
		}
		static public void  MsgInfo( string strMensaje, ref  string strTitulo)
		{
			//UPGRADE_ISSUE: (1040) IsMissing function is not supported.
            //AIS-1123 NGONZALEZ
            if (strTitulo == "")
			{
				strTitulo = "Tarjeta Corporativa";
			}
			MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		
		static public void  MsgInfo( string strMensaje)
		{
			string tempRefParam2 = "" ;
			MsgInfo(strMensaje, ref tempRefParam2);
		}
		
		static public bool FnMsgYesno( string strMensaje, ref  string strTitulo, ref  MsgBoxStyle btnDefault)
		{
            bool result = false;
			if (btnDefault == MsgBoxStyle.OkOnly)
			{
				btnDefault = MsgBoxStyle.DefaultButton2;
			}
			
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
			//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
			//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            //AIS-1144 NGONZALEZ
            return Interaction.MsgBox(strMensaje, (MsgBoxStyle)(((int)MsgBoxStyle.YesNo) + ((int)MsgBoxStyle.Question) + ((int)btnDefault)), strTitulo) == MsgBoxResult.Yes;
		}
		
		static public bool FnMsgYesno( string strMensaje, ref  string strTitulo)
		{
            //AIS-1141 NGONZALEZ
            MsgBoxStyle msgBoxStyle = MsgBoxStyle.OkOnly;
            return FnMsgYesno(strMensaje, ref strTitulo, ref msgBoxStyle);
		}
		
		static public bool FnMsgYesno( string strMensaje)
		{
			string tempRefParam3 = typeof(MdlCambioMasivo).Assembly.GetName().Name;
            //AIS-1141 NGONZALEZ
            MsgBoxStyle OKonly = MsgBoxStyle.OkOnly;
            //ais-1618 chidalgo
            return FnMsgYesno(strMensaje, ref tempRefParam3, ref OKonly);

		}
		
		
		
		static public void  MsgError( string strMensaje, ref  string strTitulo)
		{
			//UPGRADE_ISSUE: (1040) IsMissing function is not supported.
            //AIS-1123 NGONZALEZ
			if (strTitulo == String.Empty)
			{
				strTitulo = "Tarjeta Corporativa";
			}
			MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}
		
		static public void  MsgError( string strMensaje)
		{
			string tempRefParam4 = "";
			MsgError(strMensaje, ref tempRefParam4);
		}
	}
}