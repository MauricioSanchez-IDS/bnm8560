using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    class mdlSeguridad
    {


        //AIS-1182 NGONZALEZ
        //#######SAPUF se incorporan el 18/05/06

        static public COMDRV32.TcpServer objSeguridad = null;
        static public int llNuevoCredito = 0;

        static public string sgDlgSeguridad = String.Empty;
        static public bool bgSeguridadS041 = false;

        static public bool bgChecaUser = false;
        static public int LogHandler = 0;

        public struct TDSeguridad
        {
            public string NominaS;
            public string PasswordS;
            public string VersionI;
            public static TDSeguridad CreateInstance()
            {
                TDSeguridad result = new TDSeguridad();
                result.NominaS = String.Empty;
                result.PasswordS = String.Empty;
                result.VersionI = String.Empty;
                return result;
            }
        }
        static public TDSeguridad tgSeguridad = mdlSeguridad.TDSeguridad.CreateInstance();

        public enum enuTipoDlgSeguridad
        {
            tFirmaConModuloS041 = 1,
            tFirmaSinModuloS041 = 2,
            tDesfirmaS041 = 3
        }

        //UPGRADE_NOTE: (7001) The following declaration (prWait) seems to be dead code
        //private void  prWait( int lpWait)
        //{
        //
        //
        //int llEnd = Environment.TickCount + lpWait;
        //do 
        //{
        //}
        //while(Environment.TickCount < llEnd);
        //
        //}

        static public bool fncCargaComdriveB()
        {

            bool result = false;
            try
            {
                if (mdlParametros.ES_DEBUG)
                {
                    EnviaLog("Se va a Inicializar Comdrv32");
                }
                objSeguridad = new COMDRV32.TcpServer();

                if (mdlParametros.ES_DEBUG)
                {
                    EnviaLog("Inicializado Comdrv32");
                }

                objSeguridad.Connect();
                if (mdlParametros.ES_DEBUG)
                {
                    EnviaLog("Conectado");
                }


                return true;
            }
            catch (Exception excep)
            {

                if (Information.Err().Number == 0x80072AFC)
                {
                    MessageBox.Show(Information.Err().Number.ToString() + " direccion ip erronea", Application.ProductName);
                    //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, Application.ProductName);
                    result = false;
                }
            }
            return result;
        }

        static public bool fncDescargaComdriveB()
        {

            bool result = false;
            try
            {
                if (mdlParametros.ES_DEBUG)
                {
                    MdlCambioMasivo.MsgInfo("Decargando Comdvr32");
                }
                objSeguridad.Disconnect();
                objSeguridad = null;

                return true;
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("mdlSeguridad (DescargaComdrive)", e);
                result = false;
            }
            return result;
        }

        static public string fncEncripPassS(string spPassword, string spCadena, ref  int ipVersion, int ipOpcion)
        {

            string result = String.Empty;
            int ilRes = 0;
            string slPass = String.Empty;
            string slRespuesta = String.Empty;
            string slResp2 = String.Empty;
            int ilVersion = 0;

            try
            {

                if (mdlParametros.ES_DEBUG)
                {
                    EnviaLog("Llamando a FncEncripPassS spPassword:" + spPassword +
                             " spCadena:" + spCadena + " ipVersion:" + ipVersion.ToString() + " ipOpcion:" + ipOpcion.ToString());

                }

                switch (ipOpcion)
                {
                    case 1:
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Inicia_Encripcion(\", 0)");
                        }
                        //AIS-1182 NGONZALEZ
                        ilRes = API.Encryption.Inicia_Encripcion("", 0);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("ilRes :" + ilRes.ToString());
                        }

                        slPass = spPassword.Trim();
                        slRespuesta = new string((char)255, 8);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("slRespuesta:" + slRespuesta);
                            EnviaLog("E3Des( " + slPass + "," + slRespuesta + "," + ipVersion.ToString() + ")");
                        }
                        //AIS-1182 NGONZALEZ
                        short tmpShort = (short)ipVersion;
                        ilRes = API.Encryption.E3Des(slPass, ref slRespuesta, ref tmpShort);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("slRespuesta:" + slRespuesta);
                        }
                        result = slRespuesta;

                        break;
                    case 2:
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Inicia_Encripcion(" + spCadena + "," + ipVersion.ToString() + ")");
                        }
                        //AIS-1182 NGONZALEZ
                        ilRes = API.Encryption.Inicia_Encripcion(spCadena, (short)ipVersion);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("ilRes:" + ilRes.ToString());
                        }

                        slPass = spPassword.Trim();
                        slResp2 = new string((char)255, 8);
                        ilVersion = ipVersion;
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("slPass:" + slPass + "\r\n" +
                                     "slResp2:" + slResp2 + "\r\n" +
                                     "ilVersion:" + ilVersion.ToString() + "\r\n" +
                                     "ilRes = E3Des(" + slPass + "," + slResp2 + "," + ilVersion.ToString() + ")");

                        }
                        //AIS-1182 NGONZALEZ
                        tmpShort = (short)ipVersion;
                        ilRes = API.Encryption.E3Des(slPass, ref slResp2, ref tmpShort);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("fncEncripPassS = " + slResp2);
                        }
                        result = slResp2;
                        break;
                }
                if (mdlParametros.ES_DEBUG)
                {
                    EnviaLog("Salida Normal de la funcion fncEcripPassS");
                }
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("mdlSeguridad (EncriptaDato)", e);
                if (mdlParametros.ES_DEBUG)
                {
                    EnviaLog("Salida Erronea de la funcion fncEcripPassS");
                }
                return result;
            }
            return result;
        }

        static public string fncGenDlgSegS(string spNomina, string spPassword, int ipVersion, string spToken, enuTipoDlgSeguridad ipTipoDialogo)
        {

            string result = String.Empty;
            string slDialogo = String.Empty;

            try
            {

                EnviaLog("Iniciado generacion de Dialogo de Seguridad ");

                if (spToken.Length < 6)
                { spToken = "      "; }

                switch (ipTipoDialogo)
                {
                    case enuTipoDlgSeguridad.tFirmaConModuloS041:
                        slDialogo = "D";
                        slDialogo = slDialogo + "004104";  //Destino 
                        slDialogo = slDialogo + new String(' ', 6);  //Origen 
                        //slDialogo = slDialogo + "70025"; //Accion (Firma Con Modulos)
                        slDialogo = slDialogo + "70027"; //Accion (Firma Con Modulos)
                        slDialogo = slDialogo + StringsHelper.Format(spNomina, "00000000");  //Nomina 
                        slDialogo = slDialogo + spPassword;  //Password 
                        slDialogo = slDialogo + StringsHelper.Format(ipVersion, "0000");  //Version 
                        slDialogo = slDialogo + spToken; //Token
                        slDialogo = slDialogo + Strings.Chr(3).ToString();
                        break;
                    case enuTipoDlgSeguridad.tFirmaSinModuloS041:
                        slDialogo = "D";
                        slDialogo = slDialogo + "004104";  //Destino 
                        slDialogo = slDialogo + new String(' ', 6);  //Origen 
                        //slDialogo = slDialogo + "70020"; //Accion (Firma Sin Modulos)
                        slDialogo = slDialogo + "70022"; //Accion (Firma Sin Modulos)
                        slDialogo = slDialogo + StringsHelper.Format(spNomina, "00000000");  //Nomina 
                        slDialogo = slDialogo + spPassword;  //Password 
                        slDialogo = slDialogo + StringsHelper.Format(ipVersion, "0000");  //Version 
                        slDialogo = slDialogo + spToken; //Token
                        slDialogo = slDialogo + Strings.Chr(3).ToString();

                        break;
                    case enuTipoDlgSeguridad.tDesfirmaS041:
                        slDialogo = "D";
                        slDialogo = slDialogo + "004104";  //Destino 
                        slDialogo = slDialogo + new String(' ', 6);  //Origen 
                        slDialogo = slDialogo + "70030";  //Accion (Desfirma) 
                        slDialogo = slDialogo + Strings.Chr(3).ToString();

                        break;
                }
                result = slDialogo;
                //If ES_DEBUG Then
                EnviaLog("Dialogo de Seguridad Generado:" + "\r\n" +
                         slDialogo);
                // End If
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("mdlSeguridad (GenDlgSeg)", e);
                return "";
            }


            return result;
        }

        static public bool fncFirmaS041B(ref  string spNomina, string spPassword, string spToken, enuTipoDlgSeguridad ipTipoFirma)
        {

            bool result = false;
            bool blContinue = false;

            string slPassEncr = String.Empty;
            string slDialogo = String.Empty;
            string slPassEncr2 = String.Empty;
            string slDialogo2 = String.Empty;
            string slRespuesta = String.Empty;
            string slVersion = String.Empty;
            string slCadena = String.Empty;
            string slBloque = String.Empty;
            string slCausaError = String.Empty;

            int ilVersion = 0;
            int ilPosicionInicial = 0;
            int ilCont = 0;
            int ilLongitudMsg = 0;
            int ilResultado = 0;
            try
            {
                if (mdlParametros.ES_DEBUG)
                {
                    EnviaLog("Iniciando FncFirmaS041B" + "\r\n" + "Vaciando Buffer del TcpServer");
                }

                fncPreparaEnvioB(); //Limpia el buffer del tcp server
                //antes de iniciar el mecanismo de firma

                EnviaLog("Buffer Vaciado");
                switch (ipTipoFirma)
                {
                    case enuTipoDlgSeguridad.tFirmaConModuloS041:  //***** Aqui se va a firmar para obtener los modulos 
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Firmandosé con modulos");
                        }
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Encriptando Password desde FncFirmaS041");
                        }

                        int tempRefParam = 0;
                        slPassEncr = fncEncripPassS(StringsHelper.Format(spPassword, "00000000"), "", ref tempRefParam, 1);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Inciando funcion para Generar Dialogo(fnFirmaS041B)");
                        }

                        slDialogo = fncGenDlgSegS(spNomina, slPassEncr, 0, spToken, enuTipoDlgSeguridad.tFirmaConModuloS041);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Enviando el dialogo");
                        }

                        objSeguridad.SendRequest(StringsHelper.StrConv(slDialogo, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo.Length);

                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Dialogo Enviado" + "\r\n" + "Esperando Respuesta del TCPServer");
                        }

                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;

                        do
                        {
                            slBloque = "";
                            //try
                            //{
                            slBloque = StringsHelper.StrConv(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("Bloque Recibido: " + "\r\n" + slBloque);
                            }
                            //AIS- NGONZALEZ SE CAMBIO 13 POR 12 YA QUE LA CADENA  DEVUELTA NO TIENE EL FIN DE LINEA ENTOCES EL LENGTH ES MENOR EN .NET
                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }
                            slRespuesta = slRespuesta + slBloque;
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("slRespuesta : " + "\r\n" + slRespuesta);
                            }
                            //}
                            //catch (COMException er)
                            //{
                            //    Information.Err().Number = er.ErrorCode;
                            //    Information.Err().Description = er.Message;
                            //    if (Information.Err().Number != 0)
                            //    {

                            //        ilResultado = Information.Err().Number;
                            //        slCausaError = Information.Err().Description;
                            //        blContinue = false;
                            //        if (mdlParametros.ES_DEBUG)
                            //        {
                            //            EnviaLog("slCausaError : " + "\r\n" + slCausaError);
                            //        }

                            //    }
                            //}
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Respuesta del dialogo: " + "\r\n" + slRespuesta);
                        }


                        while ((slRespuesta.IndexOf("NO ESTA FIRMADA LA TERMINAL.") + 1) > 1)
                        {
                            do
                            {
                                slBloque = "";
                                slBloque = StringsHelper.StrConv(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                                if (mdlParametros.ES_DEBUG)
                                {
                                    EnviaLog("Recibiendo Bloque: " + "\r\n" + slBloque);
                                }

                                if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                                {
                                    slRespuesta = "";
                                    ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                    ilCont = 0;
                                }
                                slRespuesta = slRespuesta + slBloque;
                                if (mdlParametros.ES_DEBUG)
                                {
                                    EnviaLog("slRespuesta : " + "\r\n" + slRespuesta);
                                }

                                if (Information.Err().Number != 0)
                                {
                                    ilResultado = Information.Err().Number;
                                    slCausaError = Information.Err().Description;
                                    blContinue = false;
                                    if (mdlParametros.ES_DEBUG)
                                    {
                                        EnviaLog("slCausaError : " + "\r\n" + slCausaError);
                                    }

                                }
                                Information.Err().Clear();
                                ilCont++;
                            }
                            while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        };
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Respuesta: " + "\r\n" + slRespuesta);
                        }

                        if (Strings.InStr(22, slRespuesta, "SEG;", CompareMethod.Binary) > 0)
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, (slRespuesta.IndexOf("SEG;") + 1) + 4, 80).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }
                        else if (!(Strings.InStr(22, slRespuesta, "SEG:", CompareMethod.Binary) > 0))
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, (slRespuesta.IndexOf("SEG;") + 1) + 4, 80).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }

                        //Version 
                        ilPosicionInicial = Strings.InStr(22, slRespuesta, "SEG:", CompareMethod.Binary);
                        ilPosicionInicial += 84;
                        if (slRespuesta.Length + 1 < ilPosicionInicial + 4)
                        {
                            MessageBox.Show("Favor de reintentar su firma debido a una falla en la conexión.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Se confirma la encripcion de la firma y se reintenta");
                        }

                        if (slRespuesta.IndexOf("CONFIRMANDO ENCRIPCION, REINTENTE FIRMA", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {

                            slVersion = Strings.Mid(slRespuesta, ilPosicionInicial, 4);
                            ilVersion = Int32.Parse(slVersion);
                        }
                        else
                        {
                            string tempRefParam2 = "Tarjeta Ejecutiva:FnFrimaS041B";
                            MdlCambioMasivo.MsgInfo("Respuesta del S041 Invalida: " + slRespuesta, ref tempRefParam2);

                            return false;
                        }

                        //Cadena 
                        ilPosicionInicial += 4;
                        if (slRespuesta.Length + 1 < ilPosicionInicial + 24)
                        {
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("Valida cadena invalida para reintentar la firma");
                            }

                            MessageBox.Show("Favor de reintentar su firma debido a una falla en la conexión.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }

                        slCadena = Strings.Mid(slRespuesta, ilPosicionInicial, 24);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("slCadena :" + slCadena + "\r\n" +
                                     "Se inicia proceso de reencripcion de la firma");
                        }

                        slPassEncr2 = fncEncripPassS(StringsHelper.Format(spPassword, "00000000"), slCadena, ref ilVersion, 2);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Finaliza Encripcion 2 " + "\r\n" +
                                     "Generando Dialogo");
                        }

                        slDialogo2 = fncGenDlgSegS(spNomina, slPassEncr2, ilVersion, spToken, enuTipoDlgSeguridad.tFirmaConModuloS041);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Enviando Dialogo");
                        }


                        objSeguridad.SendRequest(StringsHelper.StrConv(slDialogo2, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo2.Length);
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Dialogo Enviado");
                        }

                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;
                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Obteniendo respuesta del dialogo");
                        }

                        do
                        {
                            slBloque = "";
                            //try
                            //{
                            slBloque = StringsHelper.StrConv(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("SlBloque: " + slBloque);
                            }

                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }

                            slRespuesta = slRespuesta + slBloque;
                            if (mdlParametros.ES_DEBUG)
                            {
                                EnviaLog("slRespuesta: " + slRespuesta);
                            }
                            //}
                            //catch (COMException e1)
                            //{
                            //    Information.Err().Number = e1.ErrorCode;
                            //    Information.Err().Description = e1.Message;

                            //    if (Information.Err().Number != 0)
                            //    {
                            //        ilResultado = Information.Err().Number;
                            //        slCausaError = Information.Err().Description;
                            //        blContinue = false;
                            //        if (mdlParametros.ES_DEBUG)
                            //        {
                            //            EnviaLog("slCausaError : " + slCausaError);
                            //        }

                            //    }
                            //}
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);

                        if (mdlParametros.ES_DEBUG)
                        {
                            EnviaLog("Repuesta Final del Dialogo:" + slRespuesta);
                        }

                        if (StringsHelper.IntValue(Strings.Mid(slRespuesta, 3, 4)) == 13)
                        {
                            slRespuesta = Strings.Mid(slRespuesta, 14);
                        }

                        if (slRespuesta.IndexOf("Expira su clave", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            MessageBox.Show("Su clave secreta está a punto de expirar cambiela antes de continuar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            result = false;
                            slRespuesta = "";
                        }
                        //if (Strings.Mid(slRespuesta, 23, 4) == "SEG:")
                        if (Strings.Mid(slRespuesta, 33, 4) == "SEG:")
                            {
                            CRSParametros.sgUserName = Strings.Mid(slRespuesta, 27, Strings.InStr(27, slRespuesta, ",", CompareMethod.Binary) - 27);
                            EnviaLog("sgUserName:" + CRSParametros.sgUserName);
                            sgDlgSeguridad = slRespuesta;
                            EnviaLog("sgDlgSeguridad :" + sgDlgSeguridad);
                            CRSParametros.sgUserID = spNomina;
                            EnviaLog("sgUserID :" + CRSParametros.sgUserID);
                            result = true;

                        }
                        //else if (Strings.Mid(slRespuesta, 23, 4) == "SEG;")
                        else if (Strings.Mid(slRespuesta, 33, 4) == "SEG;")
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, 27, 80).Trim(), "Tajeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            result = false;

                        }
                        EnviaLog("Se va a limpiar el buffer");




                        break;
                    case enuTipoDlgSeguridad.tFirmaSinModuloS041:  //Aqui se va a firmar sin obtener los modulos 
                        EnviaLog("Firmandose sin dialogos" + "\r\n" + "Encriptando Pwd");

                        int tempRefParam3 = 0;
                        slPassEncr = fncEncripPassS(StringsHelper.Format(spPassword, "00000000"), "", ref tempRefParam3, 1);
                        EnviaLog("Encriptado" + "\r\n" + "Generando Dialogo");
                        slDialogo = fncGenDlgSegS(spNomina, slPassEncr, 0, spToken, enuTipoDlgSeguridad.tFirmaSinModuloS041);
                        EnviaLog("Dialogo Generado.... Enviando:" + "\r\n" + slDialogo);
                        objSeguridad.SendRequest(StringsHelper.StrConv(slDialogo, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo.Length);
                        EnviaLog("Enviado");
                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;
                        EnviaLog("Recibiendo Respuesta");
                        do
                        {


                            slBloque = "";
                            //try
                            //{
                            slBloque = StringsHelper.StrConv(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            EnviaLog("slBloque: " + slBloque);


                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }
                            slRespuesta = slRespuesta + slBloque;
                            EnviaLog("slRespuesta: " + slRespuesta);
                            //}
                            //catch (COMException e2)
                            //{
                            //    Information.Err().Number = e2.ErrorCode;
                            //    Information.Err().Description = e2.Message;

                            //    if (Information.Err().Number != 0)
                            //    {
                            //        ilResultado = Information.Err().Number;
                            //        slCausaError = Information.Err().Description;
                            //        blContinue = false;
                            //        if (mdlParametros.ES_DEBUG)
                            //        {
                            //            EnviaLog("slCausaError: " + slCausaError);
                            //        }
                            //    }
                            //}
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        EnviaLog("Respuesta Final del Dialogo: " + slRespuesta);



                        while ((slRespuesta.IndexOf("NO ESTA FIRMADA LA TERMINAL.") + 1) > 1)
                        {
                            do
                            {

                                slBloque = "";
                                //try
                                //{
                                slBloque = StringsHelper.StrConv(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                                EnviaLog("slBloque: " + slBloque);

                                if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                                {
                                    slRespuesta = "";
                                    ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                    ilCont = 0;
                                }
                                slRespuesta = slRespuesta + slBloque;
                                EnviaLog("slRespuesta: " + slRespuesta);
                                //}
                                //catch (COMException e3)
                                //{
                                //    Information.Err().Number = e3.ErrorCode;
                                //    Information.Err().Description = e3.Message;

                                //    if (Information.Err().Number != 0)
                                //    {
                                //        ilResultado = Information.Err().Number;
                                //        slCausaError = Information.Err().Description;
                                //        blContinue = false;
                                //    }
                                //}
                                Information.Err().Clear();
                                ilCont++;
                            }
                            while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        };
                        EnviaLog("Respuesta Final del Dialogo" + slRespuesta);
                        if (Strings.InStr(22, slRespuesta, "SEG;", CompareMethod.Binary) > 0)
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, (slRespuesta.IndexOf("SEG;") + 1) + 4, 80).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }
                        else if (!(Strings.InStr(22, slRespuesta, "SEG:", CompareMethod.Binary) > 0))
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, (slRespuesta.IndexOf("SEG;") + 1) + 4, 80).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";

                            return false;
                        }

                        //Version 
                        ilPosicionInicial = Strings.InStr(22, slRespuesta, "SEG:", CompareMethod.Binary);
                        ilPosicionInicial += 84;
                        if (slRespuesta.Length + 1 < ilPosicionInicial + 4)
                        {
                            MessageBox.Show("Favor de reintentar su firma debido a una falla en la conexión.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }

                        if (slRespuesta.IndexOf("CONFIRMANDO ENCRIPCION, REINTENTE FIRMA", StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            EnviaLog("Reintentando Encripcion");
                            slVersion = Strings.Mid(slRespuesta, ilPosicionInicial, 4);
                            ilVersion = Int32.Parse(slVersion);
                            EnviaLog("version: " + ilVersion.ToString());

                        }
                        else
                        {
                            string tempRefParam4 = "Tarjeta Ejecutiva:FnFirmaS041B";
                            MdlCambioMasivo.MsgError("Mensaje Invalido: " + "\r\n" + slRespuesta, ref tempRefParam4);
                        }
                        //Cadena 
                        ilPosicionInicial += 4;
                        if (slRespuesta.Length + 1 < ilPosicionInicial + 24)
                        {
                            MessageBox.Show("Favor de reintentar su firma debido a una falla en la conexión.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sgDlgSeguridad = "";
                            return false;
                        }

                        slCadena = Strings.Mid(slRespuesta, ilPosicionInicial, 24);
                        EnviaLog("slCadena;" + slCadena);

                        slPassEncr = fncEncripPassS(StringsHelper.Format(spPassword, "00000000"), slCadena, ref ilVersion, 2);
                        EnviaLog("slPassEncr ;" + slPassEncr);

                        slDialogo = fncGenDlgSegS(spNomina, slPassEncr, ilVersion, spToken, enuTipoDlgSeguridad.tFirmaSinModuloS041);
                        EnviaLog("slDialogo ;" + slDialogo + "\r\n" + "Enviando Dialogo");

                        objSeguridad.SendRequest(StringsHelper.StrConv(slDialogo, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo.Length);
                        EnviaLog("Dialogo Enviado");
                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;
                        do
                        {
                            slBloque = "";
                            //try
                            //{
                            slBloque = StringsHelper.StrConv(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            EnviaLog("SlBloque:" + slBloque);

                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }
                            slRespuesta = slRespuesta + slBloque;

                            //}
                            //catch (COMException e4)
                            //{
                            //    Information.Err().Number = e4.ErrorCode;
                            //    Information.Err().Description = e4.Message;
                            //    if (Information.Err().Number != 0)
                            //    {
                            //        ilResultado = Information.Err().Number;
                            //        slCausaError = Information.Err().Description;
                            //        blContinue = false;
                            //        EnviaLog("slcausaerror: " + slCausaError);
                            //    }
                            //}
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);
                        EnviaLog("Respueta Final del Dialogo:" + slRespuesta);

                        if (Strings.Mid(slRespuesta, 23, 4) == "SEG:")
                        {
                            result = true;

                        }
                        else if (Strings.Mid(slRespuesta, 36, 4) == "SEG:")
                        {
                            result = true;

                        }
                        else if (Strings.Mid(slRespuesta, 23, 4) == "SEG;")
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, 27, 80).Trim(), "Tajeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = false;

                        }
                        else if (Strings.Mid(slRespuesta, 36, 4) == "SEG;")
                        {
                            MessageBox.Show(Strings.Mid(slRespuesta, 40, 80).Trim(), "Tajeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            result = false;
                        }




                        break;
                    case enuTipoDlgSeguridad.tDesfirmaS041:  //Aqui se va a desfirmar 

                        EnviaLog("Desfirmandose ");


                        if (objSeguridad == null)
                        {
                            return result;
                        }

                        slDialogo = fncGenDlgSegS(spNomina, slPassEncr, 0, spToken, enuTipoDlgSeguridad.tDesfirmaS041);
                        //If ES_DEBUG Then 
                        EnviaLog("Enviando Dialogo: " + slDialogo);
                        //End If 
                        objSeguridad.SendRequest(StringsHelper.StrConv(slDialogo, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slDialogo.Length);

                        blContinue = true;
                        ilCont = 0;
                        slRespuesta = "";
                        ilLongitudMsg = 10000;
                        do
                        {

                            slBloque = "";
                            //try
                            //{
                            slBloque = StringsHelper.StrConv(objSeguridad.ReceiveResponse(mdlParametros.igTimeComDrive), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                            EnviaLog(slBloque);
                            if (Strings.Mid(slBloque, 1, 1) == "H" && slBloque.Length != 12)
                            {
                                slRespuesta = "";
                                ilLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(slBloque, 3, 4)));
                                ilCont = 0;
                            }
                            slRespuesta = slRespuesta + slBloque;
                            //}
                            //catch (COMException e5)
                            //{
                            //    Information.Err().Number = e5.ErrorCode;
                            //    Information.Err().Description = e5.Message;

                            //    if (Information.Err().Number != 0)
                            //    {
                            //        ilResultado = Information.Err().Number;
                            //        slCausaError = Information.Err().Description;
                            //        blContinue = false;
                            //    }
                            //}
                            Information.Err().Clear();
                            ilCont++;
                        }
                        while (blContinue && ilLongitudMsg > slRespuesta.Length + 1);

                        EnviaLog("Respuesta del Dialogo: " + slRespuesta);


                        if (Strings.InStr(22, slRespuesta, "SEG;", CompareMethod.Binary) > 0)
                        {
                            result = false;
                        }
                        else if (!(Strings.InStr(22, slRespuesta, "SEG:", CompareMethod.Binary) > 0))
                        {
                            result = false;
                        }
                        break;
                }
                EnviaLog("Limpiando el Buffer");
                fncPreparaEnvioB();
                EnviaLog("Buffer Limpiado" + "\r\n" + "Saliendo de la funcion FncFirmaS041B");
            }
            catch (COMException er)
            {
                //Resume
                MdlCambioMasivo.MsgError("Se provoco el siguiente error en la funcion fnFirmaS041B" + "\r\n" +
                                         "Número de Error: " + er.ErrorCode + "\r\n" +
                                         "Decripcion: " + er.Message +
                                         "Fuente del Error: " + er.Source);
                EnviaLog("Salida Erronea de la funcion");


            }
            catch (Exception excep)
            {

                //Resume
                MdlCambioMasivo.MsgError("Se provoco el siguiente error en la funcion fnFirmaS041B" + "\r\n" +
                                         "Número de Error: " + Information.Err().Number.ToString() + "\r\n" +
                                         "Decripcion: " + excep.Message +
                                         "Fuente del Error: " + excep.Source);
                EnviaLog("Salida Erronea de la funcion");
            }

            return result;
        }

        static public bool fncPreparaEnvioB()
        {

            bool result = false;
            int ilResultado = 0;
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                int ilCont = 0;
                bool blContinue = true;


                while (blContinue)
                {
                    Information.Err().Clear();
                    try
                    {
                        objSeguridad.ReceiveResponse(500);
                    }
                    catch (COMException e)
                    {
                        Information.Err().Number = e.ErrorCode;

                        if (Information.Err().Number == -2147014836)
                        {
                            blContinue = false;
                        }
                        else if (Information.Err().Number == -2147014839 && ilCont == 0)
                        {
                            Information.Err().Clear();
                            objSeguridad.Connect();
                            if (Information.Err().Number != 0)
                            {
                                ilResultado = Information.Err().Number;
                                blContinue = false;
                            }
                            else
                            {
                                blContinue = true;
                            }
                        }
                        else if (Information.Err().Number != 0)
                        {
                            ilResultado = Information.Err().Number;
                            blContinue = false;
                        }
                    }

                    Information.Err().Clear();
                    ilCont++;
                };

                result = true;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }
        static public bool InicializarLog()
        {
            bool result = false;
            try
            {
                string lsFile = String.Empty;
                LogHandler = FileSystem.FreeFile();
                lsFile = Interaction.Environ("temp");
                if (!lsFile.EndsWith("\\"))
                {
                    lsFile = lsFile + "\\";
                }
                lsFile = lsFile + "c430.log";
                FileSystem.FileOpen(LogHandler, lsFile, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                return true;
            }
            catch
            {

                result = false;
                if (MdlCambioMasivo.fnGetError())
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    FileSystem.FileClose(LogHandler);
                }
            }

            return result;
        }
        static public bool EnviaLog(string strMensaje)
        {
            if (mdlParametros.ES_DEBUG)
            {
                FileSystem.PrintLine(LogHandler, strMensaje);
            }
            return false;
        }
        static public void CerrarLog()
        {
            FileSystem.FileClose(LogHandler);
        }
    }
}