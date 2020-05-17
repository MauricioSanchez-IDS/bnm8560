
using Microsoft.VisualBasic;
using System;

using System.Runtime.InteropServices;
//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

namespace N_TransS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
    //using Artinsoft.Silverlight.Client.Compatibility;
	public class ClsSeguridad
	{


		//UPGRADE_NOTE: (2041) The following line was commented. More Information: http://www.vbtonet.com/ewis/ewi2041.aspx
		//[DllImport("C:\\apps\\comdrv32\\des32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static short Inicia_Encripcion([MarshalAs(UnmanagedType.VBByRefStr)] ref string Cadena, short version);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: http://www.vbtonet.com/ewis/ewi2041.aspx
		//[DllImport("C:\\apps\\comdrv32\\des32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static short E3Des([MarshalAs(UnmanagedType.VBByRefStr)] ref string Cad_en_claro, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Cad_encrip, short version);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: http://www.vbtonet.com/ewis/ewi2041.aspx
		//[DllImport("C:\\apps\\comdrv32\\des32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static short D3Des([MarshalAs(UnmanagedType.VBByRefStr)] ref string Cad_encrip, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Cad_en_claro);
		//Private clsError As New clsConsultaS111
		public enum EnumEstadosFirma
		{
			EnUsuarioInvalido = -1 ,
			EnFirmaAceptada = 0 ,
			EnSolicitafirma = 1 ,
			EnReenviaPassword = 2 ,
			EnPasswordInvalido = 3 ,
			EnSinRespuesta = 4 ,
			EnDesconectado = 5 ,
			EnRespuestaDesconocida = 6
		}

		public enum EnumTipoFirma
		{
			EnFirmaSinModulos = 1 ,
			EnFirmaConModulos = 2 ,
			EnDesFirma = 3
		}

		public enum prmModalidades
		{
			mddInicializar = 0 ,
			mddAgregar = 1
		}

		private string mStrUsuario = String.Empty; //Usuario Actual
		private string mStrPassword = String.Empty; //Password Actualizado
		private string mStrToken = String.Empty; //Token Actualizado

		private EnumTipoFirma mEnTipoFirma = (EnumTipoFirma) 0;
		private ClsTransaccion objTransaccion = null; //Objeto de Transaccion  para poder enviar el dialogo al S111
		const int CTEERRUSARI0INVALIDO = 10;
		const string CTENOMBRECLASE = "ClsSeguridad: Método .- ";

		private clsModulosCMDL mcmdlModulos = null;
		private string msLeyenda = String.Empty;
		private string msOrigen = String.Empty;
		private string msDestino = String.Empty;
		//local variable(s) to hold property value(s)
		private string mvarNombreS = String.Empty; //local copy

		public string NombreS
		{
			get
			{
				return mvarNombreS;
			}
		}


		public string DestinoS
		{
			get
			{
				return msDestino;
			}
			set
			{
				msDestino = value;
			}
		}


		public string OrigenS
		{
			get
			{
				return msOrigen;
			}
			set
			{
				msOrigen = value;
			}
		}


		public string LeyendaS
		{
			get
			{
				return msLeyenda;
			}
			set
			{
				msLeyenda = value;
			}
		}


		public clsModulosCMDL ModulosCMDL
		{
			get
			{
				return mcmdlModulos;
			}
			set
			{
				mcmdlModulos = value;
			}
		}


		public string Usuario
		{
			get
			{
				return mStrUsuario;
			}
			set
			{
				mStrUsuario = value;
			}
		}



		public string Password
		{
			get
			{
				return mStrPassword;
			}
			set
			{
				mStrPassword = value;
			}
		}


		public string Token
		{
			get
			{
				return mStrToken;
			}
			set
			{
				mStrToken = value;
			}
		}




		public EnumTipoFirma TipoFirma
		{
			get
			{
				return mEnTipoFirma;
			}
			set
			{
				mEnTipoFirma = value;
			}
		}





		//===========================================================================================================
		// EN ESTA SECCION SE ENCUENTRAN TODAS LAS FUNCIONES NECESARIAS PARA REALIZAR LA CONEXION AL S111
		//===========================================================================================================


        //private string fncEncripPassS(string spPassword, ref string spCadena, int ipVersion, int ipOpcion)
        //{
        //    string result = String.Empty;
        //    int ilRes = 0;
        //    string slPass = String.Empty;
        //    string slRespuesta = String.Empty;
        //    string slResp2 = String.Empty;
        //    int ilVersion = 0;
        //    int lngError = 0;
        //    string strError = String.Empty;

        //    try
        //    {

        //        switch(ipOpcion)
        //        {
        //            case 1 :
        //                string tempRefParam = "";
        //                ilRes = API.Encryption.Inicia_Encripcion("", 0);
        //                slPass = spPassword.Trim();
        //                slRespuesta = new string((char) 255, 8);
        //                short tempRefParam2 = (short) ipVersion;
        //                ilRes = API.Encryption.E3Des(slPass, ref slRespuesta, ref tempRefParam2);
        //                ipVersion = tempRefParam2;
        //                result = slRespuesta;

        //                break;
        //            case 2 :
        //                modErrorHandling.GrabaLog("Inicia_Encripcion:( " + spCadena + "," + ipVersion.ToString() + ")");
        //                ilRes = API.Encryption.Inicia_Encripcion(spCadena, (short) ipVersion);
        //                modErrorHandling.GrabaLog("ilRes:" + ilRes.ToString());
        //                modErrorHandling.GrabaLog("Se ve a asignar el password");
        //                slPass = spPassword.Trim();
        //                modErrorHandling.GrabaLog("slPass :" + slPass);
        //                slResp2 = new string((char) 255, 8);
        //                modErrorHandling.GrabaLog("slResp2:" + slResp2);
        //                modErrorHandling.GrabaLog("Asignando IlVersion");
        //                ilVersion = ipVersion;
        //                modErrorHandling.GrabaLog("IlVersion:" + ilVersion.ToString());
        //                modErrorHandling.GrabaLog("se va Llamar: E3Des(" + slPass + "," + slResp2 + "," + ilVersion.ToString() + ")");
        //                short tempRefParam3 = (short)ilVersion;
        //                ilRes = API.Encryption.E3Des(slPass, ref slResp2, ref tempRefParam3);
        //                ilVersion = tempRefParam3;
        //                modErrorHandling.GrabaLog("Llamada Exitosa");
        //                result = slResp2;
        //                modErrorHandling.GrabaLog("fncEncripPassS :" + result);
        //                break;
        //        }

        //        return result;
        //    }
        //    catch (System.Exception excep)
        //    {
        //        //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //        lngError = Information.Err().Number;
        //        strError = excep.Message;
        //        modErrorHandling.GrabaLog("fncEncripPassS ***** Error **** " + lngError.ToString() + ":" + strError);
        //        throw new System.Exception(lngError.ToString() + ", " + CTENOMBRECLASE + "FnEncripPass" + ", " + strError);

        //        return result;
        //    }
        //}

        //private string fncGenDlgSegS(string spNomina, string spPassword, int ipVersion, ref string spToken, EnumTipoFirma ipTipoDialogo)
        //{
        //    string slDialogo = String.Empty;
        //    try
        //    {
        //        if (spToken.Length < 6)
        //        {
        //            spToken = "      ";
        //        }
        //        switch(ipTipoDialogo)
        //        {
        //            case EnumTipoFirma.EnFirmaConModulos :
        //                //slDialogo = "D" 
        //                slDialogo = slDialogo + "004104";  //Destino 
        //                slDialogo = slDialogo + new String(' ', 6);  //Origen 
        //                //slDialogo = slDialogo & "70025"                         'Accion (Firma Con Modulos) 
        //                slDialogo = slDialogo + "70027";  //Accion (Firma Con Modulos) 
        //                slDialogo = slDialogo + Artinsoft.Silverlight.Client.Utils.StringsHelper.Format(spNomina, "00000000");//Nomina 
        //                slDialogo = slDialogo + spPassword;  //Password 
        //                slDialogo = slDialogo + Artinsoft.Silverlight.Client.Utils.StringsHelper.Format(ipVersion, "0000");//Version 
        //                slDialogo = slDialogo + spToken;  //Token 
        //                slDialogo = slDialogo + Strings.ChrW(3).ToString();
        //                break;
        //            case EnumTipoFirma.EnFirmaSinModulos :
        //                //slDialogo = "D" 
        //                slDialogo = slDialogo + "004104";  //Destino 
        //                slDialogo = slDialogo + new String(' ', 6);  //Origen 
        //                //slDialogo = slDialogo & "70020"                         'Accion (Firma Sin Modulos) 
        //                slDialogo = slDialogo + "70022";  //Accion (Firma Sin Modulos) 
        //                slDialogo = slDialogo + Artinsoft.Silverlight.Client.Utils.StringsHelper.Format(spNomina, "00000000");//Nomina 
        //                slDialogo = slDialogo + spPassword;  //Password 
        //                slDialogo = slDialogo + Artinsoft.Silverlight.Client.Utils.StringsHelper.Format(ipVersion, "0000");//Version 
        //                slDialogo = slDialogo + spToken;  //Token 
        //                slDialogo = slDialogo + Strings.ChrW(3).ToString();
        //                break;
        //            case EnumTipoFirma.EnDesFirma :
        //                //slDialogo = "D" 
        //                slDialogo = slDialogo + "004104";  //Destino 
        //                slDialogo = slDialogo + new String(' ', 6);  //Origen 
        //                slDialogo = slDialogo + "70030";  //Accion (Desfirma) 
        //                slDialogo = slDialogo + Strings.ChrW(3).ToString();
        //                break;
        //        }
        //        return slDialogo;
        //    }
        //    catch
        //    {
        //        //clsError.ErrorX "[fncGenDlgSegS]", Err.Number, Err.Description

        //        return "";
        //    }
        //}
        //public bool fncFirmaS041B(ref EnumEstadosFirma intCausaError)
        //{
        //    //Objetivo: Realiza la conexion al Sistema 041 via el Comdrv
        //    //Modifo: Clemente Muñoz

        //    //Parametros:
        //    //   spNomina: No. Nomina a Firmar
        //    //   SpPassword: Clave Secreta del usuario
        //    //   ipTipoFirma : Tipo de Firma al S041:
        //    //                 1:Firma Con Modulos
        //    //                 2: Firma Sin Modulos
        //    //                 3: Desfirma del Sistema
        //    //   intCausaError: Devuelve la Causa del Error por la que el usuario no se logra firmar
        //    //Valor Devuelto: Verdadero:=Conexion Exitosa
        //    //                Falso:=Conexion Fallida (Vease intCausaError Para determina la causa del error fallido)

        //    bool result = false;
        //    bool blContinue = false;
        //    string slPassEncr = String.Empty;
        //    string slDialogo = String.Empty;
        //    string slPassEncr2 = String.Empty;
        //    string slDialogo2 = String.Empty;
        //    string slRespuesta = String.Empty;
        //    string slVersion = String.Empty;
        //    string slCadena = String.Empty;
        //    string slBloque = String.Empty;
        //    string slCausaError = String.Empty;
        //    string sgDlgSeguridad = String.Empty;
        //    int ilVersion = 0;
        //    int ilPosicionInicial = 0;
        //    int ilCont = 0;
        //    int ilLongitudMsg = 0;
        //    int ilResultado = 0;
        //    int igTimeComDrive = 0;
        //    EnumEstadosFirma idPaso = (EnumEstadosFirma) 0;
        //    bool bolValidaFirma = false;
        //    int intReintentosFirma = 0;
        //    int intMaxReintentosFirma = 0;
        //    string strContArchivo = String.Empty;

        //    string spNomina = String.Empty;
        //    string spPassword = String.Empty;

        //    const int cteREINTENTOSFIRMA = 3; //Determina El numero veces que el sistema reintentará la firma por defecto
        //    try
        //    {
        //        if (this.Usuario == "" && this.TipoFirma != EnumTipoFirma.EnDesFirma)
        //        {
        //            //Valida que se haya suministrado el usuario
        //            //para firmarse al S041
        //            modErrorHandling.RaiseError(CTEERRUSARI0INVALIDO, CTENOMBRECLASE + "FncFirmaS041B", "Nombre de Usuario Invalido");
        //        }

        //        if (false)
        //        {
        //            intCausaError = EnumEstadosFirma.EnSolicitafirma;
        //        }
        //        intMaxReintentosFirma = cteREINTENTOSFIRMA;

        //        string tempRefParam = @"SOFTWARE\Banamex\C430_001\TarjetaCorporativa\Rutas";
        //        string tempRefParam2 = intMaxReintentosFirma.ToString();
        //        strContArchivo = objTransaccion.FnStrLeeIni(ref tempRefParam, "Reintentos", ref tempRefParam2);
        //        // 06.12.2004 EISSA: HVV - Inicializa los módulos cada vez que se firma un usuario
        //        mcmdlModulos = null;
        //        mcmdlModulos = new clsModulosCMDL();
        //        string tempRefParam3 = @"SOFTWARE\Banamex\C430_001\TarjetaCorporativa\Comdrv32";
        //        string tempRefParam4 = "";
        //        mcmdlModulos.FiltroS = objTransaccion.FnStrLeeIni(ref tempRefParam3, "Modulos", ref tempRefParam4);

        //        double dbNumericTemp = 0;
        //        if (Double.TryParse(strContArchivo,System.Globalization.NumberStyles.Number,System.Globalization.CultureInfo.CurrentCulture.NumberFormat,out dbNumericTemp))
        //        {
        //            intMaxReintentosFirma = System.Convert.ToInt32(Double.Parse(strContArchivo));
        //        }
        //        else
        //        {
        //            intMaxReintentosFirma = cteREINTENTOSFIRMA;
        //        }
        //        igTimeComDrive = 15000;
        //        objTransaccion = new ClsTransaccion();
        //        bolValidaFirma = false;
        //        idPaso = EnumEstadosFirma.EnSolicitafirma;
        //        intReintentosFirma = 0;
        //        do
        //        {
        //            bolValidaFirma = false;
        //            switch(idPaso)
        //            { //Identifica el Estado Actual del proceso de Firma
        //                case EnumEstadosFirma.EnSolicitafirma :
        //                    intReintentosFirma++;
        //                    if (intReintentosFirma <= intMaxReintentosFirma)
        //                    {
        //                        slPassEncr = "";
        //                        if (this.TipoFirma != EnumTipoFirma.EnDesFirma)
        //                        {
        //                            string tempRefParam5 = "";
        //                            slPassEncr = fncEncripPassS(Artinsoft.Silverlight.Client.Utils.StringsHelper.Format(this.Password, "00000000"),ref tempRefParam5,0,1);
        //                            modErrorHandling.GrabaLog(Artinsoft.Silverlight.Client.Compatibility.DateTimeHelper.ToString(DateTime.Now) + " Trs111  : " + slPassEncr);
        //                        }
        //                        string tempRefParam6 = this.Token;
        //                        slDialogo = fncGenDlgSegS(this.Usuario, slPassEncr, 0, ref tempRefParam6, this.TipoFirma);
        //                        modErrorHandling.GrabaLog(Artinsoft.Silverlight.Client.Compatibility.DateTimeHelper.ToString(DateTime.Now) + " Trs111  :Nomina " + Usuario);
        //                        modErrorHandling.GrabaLog(Artinsoft.Silverlight.Client.Compatibility.DateTimeHelper.ToString(DateTime.Now) + " Trs111  :Dialogo " + slDialogo);
        //                        objTransaccion.Transaccion = slDialogo;
        //                        if (objTransaccion.EnviaTransaccionS111())
        //                        {
        //                            //La transaccion se realizo Exitosamente
        //                            slRespuesta = objTransaccion.RespTransaccion;
        //                            modErrorHandling.GrabaLog(Artinsoft.Silverlight.Client.Compatibility.DateTimeHelper.ToString(DateTime.Now) + " Trs111  :Respuesta " + slRespuesta);
        //                            // AIS-SL Lloria: el objeto modClassIDGenerator.objSeguridad debería estar asignado, por esa razon
        //                            //no se hace una verificación de si modClassIDGenerator.objSeguridad es nulo.
        //                            idPaso = modClassIDGenerator.objSeguridad.EjecutarComdrv ? ValidaRespSeguridad(ref slRespuesta) : EnumEstadosFirma.EnFirmaAceptada;
        //                        }
        //                        else
        //                        {
        //                            //No se logro enviar el mensaje al S111
        //                            break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        break;
        //                    }
        //                    break;
        //                case EnumEstadosFirma.EnReenviaPassword :
        //                    ilPosicionInicial = (slRespuesta.IndexOf("SEG:") + 1);
        //                    ilPosicionInicial += 84;
        //                    if (slRespuesta.Length < ilPosicionInicial + 4)
        //                    {
        //                        //MsgBox "Favor de reintentar su firma debido a una falla en la conexión.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
        //                        modErrorHandling.GrabaLog("Favor de reintentar su firma debido a una falla en la conexión.");
        //                        sgDlgSeguridad = "";
        //                        return false;
        //                    }

        //                    slVersion = Strings.Mid(slRespuesta, ilPosicionInicial, 4);
        //                    ilVersion = System.Convert.ToInt32(Double.Parse(slVersion));
        //                    ilPosicionInicial += 4;
        //                    modErrorHandling.GrabaLog("Version: " + ilVersion.ToString() + System.Environment.NewLine + " Posicion Inicial : " + ilPosicionInicial.ToString());
        //                    if (slRespuesta.Length < ilPosicionInicial + 24)
        //                    {
        //                        modErrorHandling.GrabaLog("Favor de reintentar su firma debido a una falla en la conexión.");
        //                        //MsgBox "Favor de reintentar su firma debido a una falla en la conexión.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
        //                        sgDlgSeguridad = "";
        //                        return false;
        //                    }
        //                    slCadena = Strings.Mid(slRespuesta, ilPosicionInicial, 24);
        //                    modErrorHandling.GrabaLog("slCadena:" + slCadena);
        //                    slPassEncr2 = fncEncripPassS(Artinsoft.Silverlight.Client.Utils.StringsHelper.Format(this.Password, "00000000"),ref slCadena,ilVersion,2);
        //                    modErrorHandling.GrabaLog("slPassEncr2 :" + slPassEncr2);
        //                    modErrorHandling.GrabaLog("Llamando fncGenDlgSegS");
        //                    string tempRefParam7 = this.Token;
        //                    slDialogo2 = fncGenDlgSegS(this.Usuario, slPassEncr2, ilVersion, ref tempRefParam7, mEnTipoFirma);
        //                    modErrorHandling.GrabaLog("slDialogo2:" + slDialogo2);
        //                    objTransaccion.Transaccion = slDialogo2;
        //                    modErrorHandling.GrabaLog(this.GetType().Name + ".-Metodo(FncFirmaS041B):objTransaccion.Transacion:" + objTransaccion.Transaccion);
        //                    modErrorHandling.GrabaLog("Transaccion a Enviar: " + slDialogo2);
        //                    if (objTransaccion.EnviaTransaccionS111())
        //                    {
        //                        modErrorHandling.GrabaLog("Transaccion a Enviada Exitosa ");
        //                        slRespuesta = objTransaccion.RespTransaccion;
        //                    }
        //                    else
        //                    {
        //                        modErrorHandling.GrabaLog("El Envio de la transaccion Fallo");
        //                    }
        //                    modErrorHandling.GrabaLog("Respuesta Transaccion: " + slRespuesta + System.Environment.NewLine + "Validando Respuesta de seguridad");
        //                    //slRespuesta = objTransaccion.EnviaMensajeSM(slDialogo2, ilResultado, slCausaError) 
        //                    idPaso = ValidaRespSeguridad(ref slRespuesta);
        //                    modErrorHandling.GrabaLog("Fin de la validacion: idPaso" + ((int) idPaso).ToString());
        //                    break;
        //                case EnumEstadosFirma.EnPasswordInvalido :
        //                    //Como el password es invalido 
        //                    //Debe enviar un mensaje a cliente indicando que 
        //                    //que el password es invalido 
        //                    //y debe mandar el password correcto 
        //                    bolValidaFirma = false;
        //                    break;
        //                case EnumEstadosFirma.EnSinRespuesta :
        //                    bolValidaFirma = false;
        //                    idPaso = EnumEstadosFirma.EnSolicitafirma;  //Como no recibio respuesta del S111 
        //                    //Reintenta la operación 
        //                    break;
        //                case EnumEstadosFirma.EnFirmaAceptada :
        //                    bolValidaFirma = true;
        //                    if (mEnTipoFirma == EnumTipoFirma.EnFirmaConModulos)
        //                    {
        //                        ObtenPermisos(slRespuesta, prmModalidades.mddInicializar); //06.12.2004 HVV Llamado para recuperar los permisos del S041, una vez que se firmo el usuario.
        //                    }
        //                    return result;
        //                case EnumEstadosFirma.EnRespuestaDesconocida :
        //                    bolValidaFirma = false;
        //                    modErrorHandling.RaiseError((int) EnumEstadosFirma.EnRespuestaDesconocida, "ClsSeguridad: Método FncFirmaS041B", "Se ha recibido una respuesta Desconocida del S111" + System.Environment.NewLine + "Usuario:" + this.Usuario + System.Environment.NewLine + "Respuesta del S111 :" + System.Environment.NewLine + slRespuesta);
        //                    break;
        //                    break;
        //                case EnumEstadosFirma.EnDesconectado :

        //                    if (this.TipoFirma == EnumTipoFirma.EnDesFirma)
        //                    {
        //                        bolValidaFirma = true;
        //                        objTransaccion.Desconectar(); //Desconecta del S111 cuando lo solicite
        //                        //explicitamente
        //                        return true;
        //                        //Cuano Explictamente se solice la desfirma
        //                        //saldra devolverá un true
        //                    }
        //                    else
        //                    {
        //                        idPaso = EnumEstadosFirma.EnSolicitafirma;
        //                        //Inicia el proceso de firma
        //                    }


        //                    break;
        //            }
        //        }
        //        while(idPaso != EnumEstadosFirma.EnPasswordInvalido);
        //        intCausaError = idPaso; //Determina la razon por la que no se logro conectar al sistema
        //        result = bolValidaFirma;
        //        //UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
        //        if (String.IsNullOrEmpty(msLeyenda.Trim()))
        //        {
        //            msLeyenda = slRespuesta;
        //        }
        //        return result;
        //    }
        //    catch (System.Exception excep)
        //    {
        //        //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //        switch(Information.Err().Number)
        //        {
        //            case 1 :  //El Archivo de comfiguracion no existe 
        //                //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx 
        //                Artinsoft.Silverlight.Client.Compatibility.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
        //                break;
        //            case (int) EnumEstadosFirma.EnRespuestaDesconocida :
        //                intCausaError = idPaso;  //Determina la razon por la que no se logro conectar al sistema 
        //                result = bolValidaFirma;
        //                //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx 
        //                modErrorHandling.RaiseError(Information.Err().Number, excep.GetSource(), excep.Message);
        //                break;
        //            case CTEERRUSARI0INVALIDO :
        //                intCausaError = EnumEstadosFirma.EnUsuarioInvalido;
        //                result = false;
        //                //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx 
        //                modErrorHandling.RaiseError(Information.Err().Number, excep.GetSource(), excep.Message);
        //                break;
        //            default:
        //                modErrorHandling.RaiseError(10, CTENOMBRECLASE + "FnFirmaS041B", "No se Logro Firmar al sistema por las siguientes causas:" + "\r" + "Descripción:" + excep.Message + "\r" + "Fuente Error:" + excep.GetSource());

        //                break;
        //        }
        //        return result;
        //    }
        //}
        //public bool fncFirmaS041B()
        //{
        //    EnumEstadosFirma tempRefParam = EnumEstadosFirma.EnUsuarioInvalido;
        //    return fncFirmaS041B(ref tempRefParam);
        //}
        //private EnumEstadosFirma ValidaRespSeguridad(ref string mstrRespuesta)
        //{
        //    //Objetivo: Valida la respuesta del mensaje enviado al S111
        //    //           a la solicitud de conexion al sistema S041
        //    //Valor Devuelto: La accion a realizar para continuar con el proceso
        //    //                de firma al S041
        //    //

        //    const string mcteVACIO = "";
        //    const string mcteBIENVENIDO = "Bienvenido";
        //    const string mcteCONFIRMAENCRIPCION = "CONFIRMANDO ENCRIPCION, REINTENTE FIRMA";
        //    const string mctePASSWORDINVALIDO = "CLAVE SECRETA INVALIDA";
        //    const string mcteTERMINALNOFIRMADA = "NO ESTA FIRMADA LA TERMINAL";
        //    const string mcteDesconectado = "HASTA LUEGO";

        //    EnumEstadosFirma midPaso = (EnumEstadosFirma) 0;
        //    if (mstrRespuesta == mcteVACIO || mstrRespuesta.IndexOf(mcteTERMINALNOFIRMADA, StringComparison.CurrentCultureIgnoreCase) >= 0)
        //    {
        //        midPaso = EnumEstadosFirma.EnSolicitafirma;
        //        //No se recibio respuesta del S111 o en su caso envia el mensaje de
        //        //no esta firmada la terminal

        //    }
        //    else if (mstrRespuesta.IndexOf(mcteBIENVENIDO, StringComparison.CurrentCultureIgnoreCase) >= 0)
        //    {
        //        midPaso = EnumEstadosFirma.EnFirmaAceptada;
        //    }
        //    else if (mstrRespuesta.IndexOf(mcteCONFIRMAENCRIPCION, StringComparison.CurrentCultureIgnoreCase) >= 0)
        //    {
        //        midPaso = EnumEstadosFirma.EnReenviaPassword;
        //    }
        //    else if (mstrRespuesta.IndexOf(mctePASSWORDINVALIDO, StringComparison.CurrentCultureIgnoreCase) >= 0)
        //    {
        //        midPaso = EnumEstadosFirma.EnPasswordInvalido;
        //    }
        //    else if (mstrRespuesta.IndexOf(mcteDesconectado, StringComparison.CurrentCultureIgnoreCase) >= 0)
        //    {
        //        midPaso = EnumEstadosFirma.EnDesconectado;
        //    }
        //    else
        //    {
        //        midPaso = EnumEstadosFirma.EnRespuestaDesconocida;
        //    }
        //    return midPaso;

        //}
		public ClsSeguridad()
		{
            //modErrorHandling.GrabaLog(this.GetType().Name + "Inicializado");
			objTransaccion = new ClsTransaccion();
			mcmdlModulos = new clsModulosCMDL();
			//mEnTipoFirma = EnFirmaConModulos
		}
		~ClsSeguridad()
		{
            //modErrorHandling.GrabaLog(this.GetType().Name + "Finalizado");
			objTransaccion = null;
			mcmdlModulos = null;
		}
		//*** EISSA - HVV 06.12.2004 ********************************************************
		// OBJETIVO: Adecuaciones para desglose de módulos y niveles de usuario.
		//*** EISSA - HVV 06.12.2004 ********************************************************

        //private void ObtenPermisos(string spRespuestaS041, prmModalidades epModalidad)
        //{
        //    string slModulo = String.Empty;
        //    int ilNivel = 0;
        //    int ilPosIni = 0;

        //    if (spRespuestaS041.Length == 1487)
        //    {
        //        spRespuestaS041 = "H11497CMDD" + spRespuestaS041;
        //    }

        //    if (epModalidad == prmModalidades.mddInicializar)
        //    {
        //        mcmdlModulos.Clear();
        //    }
        //    //UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2080.aspx
        //    if (!String.IsNullOrEmpty(spRespuestaS041.Trim()))
        //    {
        //        msDestino = Strings.Mid(spRespuestaS041, 1, 6);
        //        msOrigen = Strings.Mid(spRespuestaS041, 7, 6);
        //        msLeyenda = Strings.Mid(spRespuestaS041, 27, 80).Trim();
        //        mvarNombreS = Strings.Mid(msLeyenda,1,System.Convert.ToInt32(Math.Abs(msLeyenda.IndexOf(", BIENVENIDO A LA RED BANAMEX.")))).Trim();
        //        mcmdlModulos.TotalModulosI = System.Convert.ToInt32(Conversion.Val(Strings.Mid(spRespuestaS041, 111, 4)));
        //        ilPosIni = 115;
        //        int tempForVar = mcmdlModulos.TotalModulosI;
        //        for (int i = 1; i <= tempForVar; i++)
        //        {
        //            slModulo = Strings.Mid(spRespuestaS041, ilPosIni, 5);
        //            ilNivel = System.Convert.ToInt32(Conversion.Val(Strings.Mid(spRespuestaS041, ilPosIni + 5, 2)));
        //            ilPosIni += 7;
        //            mcmdlModulos.Add(slModulo, slModulo, ilNivel, 0, 0, true);
        //        }
        //    }
        //}
        //private void ObtenPermisos(string spRespuestaS041)
        //{
        //    ObtenPermisos(spRespuestaS041, prmModalidades.mddInicializar);
        //}
	}
}