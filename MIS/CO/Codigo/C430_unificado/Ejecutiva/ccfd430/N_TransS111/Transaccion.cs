#define DebugMode
//using Artinsoft.Silverlight.Client.Compatibility;
using System;
using System.IO;
using System.Runtime.InteropServices;
//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;
using Microsoft.VisualBasic;
using Artinsoft.VB6.Utils;


namespace N_TransS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
	//UPGRADE_NOTE: (1043) Class instancing was changed to public. More Information: http://www.vbtonet.com/ewis/ewi1043.aspx 
	public class ClsTransaccion
	{

		//
		//set this to 0 to disable debug code in this class
#if DebugMode

		//local variable to hold the serialized class ID that was created in Class_Initialize
		//##ModelId=4002D34603A3
		private int mlClassDebugID = 0;
#endif
		//##ModelId=4002CCB2008B
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: http://www.vbtonet.com/ewis/ewi2041.aspx
		//[DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int GetPrivateProfileString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, System.IntPtr lpKeyName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDefault, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpReturnedString, int nSize, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: http://www.vbtonet.com/ewis/ewi2041.aspx
		//[DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int WritePrivateProfileString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, System.IntPtr lpKeyName, System.IntPtr lpString, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);

		public enum EnumRespTransaccion
		{
			EnRespIniciado = -1 ,
			EnRespTransaccionAceptada = 0 , //La transaccion fue aceptada por el S111
			EnRespConfirmar = 1 , //Se OBtuvo respuesta para confirmar la tranzaccion
			EnRespDarseAlta = 2 , //El Sistema ha devuelto que se vuelva a firmar
			EnRespSinRespuesta = 3 , //No hay respuesta del S111
			EnRespTerminalSinFirmar = 4 , //NO ESTA FIRMADA LA TERMINAL
			EnRespOperacionNegada = 5 , //Operacion Negada
			EnRespError = 6 , //El S111 ha devuelto un codigo de error
			EnRespDesconocida = 7 //Respuesta desconocida
		}
		const string CTEMSGERROR = " Método ";
		const int CTEPROPIEDADINEXISTENTE = 5;
		const string CTEARCHIVOINI = "corbnx32.ini";

		public string Nombre = String.Empty; //Nombre de la propiedad a generar
		public string IdTransaccion = String.Empty; //Indetificador unico de la transaccion
		private string mStrTrans = String.Empty; //Transaccion a Enviar al S111
		private string mStrRespuestaTransaccion = String.Empty; //Respuesta Enviada por la transaccion al S111
		private ClsPropiedad ObjPropiedad = null; //Propiedades que forman parte de la transaccion
		private Collection ColPropiedades = null; //Colexion que almacena las propiedades existentes del objeto

		private EnumRespTransaccion mEnEstadoTrans = (EnumRespTransaccion) 0; //Almacena el estado de la transaccion actual

        //public string FnStrLeeIni(ref string StrSeccion, string StrClave, ref string StrDefault, ref string strArchivo)
        //{
        //    string result = String.Empty;
        //    try
        //    {
        //                int LngPos = 0;
        //                Artinsoft.Silverlight.Client.Utils.FixedLengthString strContenido1 = new Artinsoft.Silverlight.Client.Utils.FixedLengthString(255);
        //                if (false || strArchivo.Trim() == "")
        //        {
        //            //El nombre del archivo a procesar no ha sido proporcionado
        //            strArchivo = Artinsoft.Silverlight.Client.VB.Interaction.Environ("windir").Trim();
        //                    if (Strings.Right(strArchivo, 1) != "\\")
        //            {
        //                strArchivo = strArchivo + "\\";
        //            }
        //                    strArchivo = strArchivo + CTEARCHIVOINI;
        //                }
						
        //                if (false || StrDefault.Trim() == "")
        //        {
        //            StrDefault = "";
        //        }
						
        //                result = StrDefault;
        //                var manager = Artinsoft.Silverlight.Client.Utils.SettingsManager.GetSettingsManager().OpenSubKey(StrSeccion);
        //                if (manager == null){
        //            throw new System.Exception("1, " + String.Empty + ", " + "El Archivo: " + strArchivo + ":" + " No Existe");
        //        }
                
        //        //        string tempRefParam = strContenido1.Value;

        //        //        if (!int.TryParse(manager.GetValue(StrClave).ToString(), out LngPos))
        //        //        {
        //        //            LngPos = -1;
        //        //        }
        //        //        strContenido1.Value = tempRefParam;
        //        //        if (LngPos > 0)
        //        //{
        //        //    return Strings.Left(strContenido1.Value, LngPos);
        //        //}
        //                    return manager.GetValue(StrClave).ToString();
        //        //else
        //        //{
        //        //    return StrDefault;
        //        //}
						
						
        //            }
        //    catch
        //    {
        //    }

        //    //Se ha provocado un error en el componente
        //    //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //    modErrorHandling.RaiseError(Information.Err().Number, this.GetType().Name + CTEMSGERROR + "FnStrLeeIni", Information.Err().Description);

        //    return result;
        //}

        //public string FnStrLeeIni(ref string StrSeccion, string StrClave, ref string StrDefault)
        //{
        //    string tempRefParam = String.Empty;
        //    return FnStrLeeIni(ref StrSeccion, StrClave, ref StrDefault, ref tempRefParam);
        //}

        //public string FnStrLeeIni(ref string StrSeccion, string StrClave)
        //{
        //    string tempRefParam2 = String.Empty;
        //    string tempRefParam3 = String.Empty;
        //    return FnStrLeeIni(ref StrSeccion, StrClave, ref tempRefParam2, ref tempRefParam3);
        //}

		//##ModelId=4002CFE101AF

		public void AgregarPropiedad(ClsPropiedad mPropiedad)
		{
			try
			{
				ColPropiedades.Add(mPropiedad, mPropiedad.Nombre, null, null);
				ObjPropiedad = mPropiedad;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
				modErrorHandling.RaiseError(Information.Err().Number, this.GetType().Name + CTEMSGERROR + "AgregarPropiedad", excep.Message);
			}
		}

		public void ActualizarPropiedad(ClsPropiedad mPropiedad)
		{
			try
			{
				//Asigna la propidad por su nombre
				ObjPropiedad = (ClsPropiedad) ColPropiedades[mPropiedad.Nombre];
			}
			catch (System.Exception excep)
			{
				modErrorHandling.RaiseError(System.Convert.ToInt32(Double.Parse(excep.Message)),this.GetType().Name + CTEMSGERROR + "ActualizarPropiedad",excep.Message);
					}
				}
				//##ModelId=4002D09B00A8
		public int Contar
		{
			get
			{
				return ColPropiedades.Count;
			}
		}
				public ClsPropiedad this[object pIndex]
		{
			get
			{
				//Obtiene un objeto de la propiedad ya sea por su nombre o por el indice
				ClsPropiedad result = null;
				int intPropiedades = 0;
				try
				{
					ObjPropiedad = null;
					ObjPropiedad = (ClsPropiedad) ColPropiedades[pIndex]; //Lee el valor de la colexion y lo asigna
					//al objetto propiedad para poderlo leer con
					//la propiedad PropiedadTrans //La propiedad Item Asigna al objeto

					return ObjPropiedad;
				}
				catch (System.Exception excep)
				{
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
					if (Information.Err().Number == CTEPROPIEDADINEXISTENTE)
					{
						modErrorHandling.RaiseError(CTEPROPIEDADINEXISTENTE, this.GetType().Name + CTEMSGERROR + "Property Item Get", "El elemento selecionado no existe");
					}
					else
					{
						//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
						modErrorHandling.RaiseError(Information.Err().Number, this.GetType().Name + CTEMSGERROR + "Property Item Get", excep.Message);
					}
					return result;
				}
			}
		}
				public string Transaccion
		{
			get
			{
				//Determina la transaccion a enviar al TcpServer
				return mStrTrans;
			}
			set
			{
				//Asigna la transaccion a enviar al TcpServer
				mStrTrans = value;
			}
		}
				public string RespTransaccion
		{
			get
			{
				//Determina la respuesta de la transaccion del Tcp/Server
				return mStrRespuestaTransaccion;
			}
		}
				//##ModelId=4002D3470066
		public int ClassDebugID
		{
			get
			{
				//if we are in debug mode, surface this property that consumers can query
				return mlClassDebugID;
			}
		}
				public EnumRespTransaccion Estado
		{
			get
			{
				return mEnEstadoTrans; //Determina el estado actual de la transaccion
			}
			set
			{
				mEnEstadoTrans = value; //Asigna unimente el estado en modo de lectura
			}
		}
				//##ModelId=4002D3470214
		internal ClsTransaccion()
		{
					#if DebugMode

			//get the next available class ID, and print out
			//that the class was created successfully
			mlClassDebugID = modClassIDGenerator.GetNextClassDebugID();
					System.Diagnostics.Debug.WriteLine("'" + this.GetType().Name + "' instance " + mlClassDebugID.ToString() + " created");
					#endif
					
					ColPropiedades = new Collection(); //Inicializa la colexion de propiedades
					
					Estado = EnumRespTransaccion.EnRespIniciado;
					
				}
				//##ModelId=4002D347028C
		~ClsTransaccion()
		{
#if DebugMode

			//the class is being destroyed
					System.Diagnostics.Debug.WriteLine("'" + this.GetType().Name + "' instance " + mlClassDebugID.ToString() + " is terminating");
#endif
			ObjPropiedad = null;
			ColPropiedades = null; //Libera la colexion de propiedades
		}

		public bool EnviaTransaccionS111()
		{
			bool result = false;
			try
			{
				int ilError = 0;
				int rsRespError = 0;
				string sCausaError = String.Empty;
				string strRespTemp = String.Empty; //Respuesta enviada por el tcpserver
				EnumRespTransaccion EnRespuesta = (EnumRespTransaccion) 0; //Valor que determina la validez de la respuesta de la transaccion
				bool bolReintentar = false;
				int IntReintentos = 0;
				int lngRetardoConsultas = 0;
				int intMaxReintentos = 0;
				lngRetardoConsultas = 15;
				//string tempRefParam = "Comdrv32";
                string tempRefParam = @"SOFTWARE\BANAMEX\C430_001\TARJETACORPORATIVA\COMDRV32";
				string tempRefParam2 = lngRetardoConsultas.ToString();
                //lngRetardoConsultas = System.Convert.ToInt32(Double.Parse(this.FnStrLeeIni(ref tempRefParam, "RetardoConsultas", ref tempRefParam2)));
				intMaxReintentos = 3; //Valor por defecto para los reintentos de la operación
				//string tempRefParam3 = "Comdrv32";
                string tempRefParam3 = @"SOFTWARE\Banamex\C430_001\TarjetaCorporativa\Comdrv32";
				string tempRefParam4 = intMaxReintentos.ToString();
				//intMaxReintentos = System.Convert.ToInt32(Double.Parse(this.FnStrLeeIni(ref tempRefParam3, "ReintentosTcpServer", ref tempRefParam4)));
				//La transaccion no se ha enviado
                

				if (Conectar())
				{ //Se conecto al TcpServer
					if (this.Transaccion == "")
					{
						//No Hay un mensaje definido para enviar la transasaccion
						throw new System.Exception("-10, " + CTEMSGERROR + "EnviaTransaccionS111" + ", No hay un mensaje a enviar");
					}
					else
					{
						EnRespuesta = EnumRespTransaccion.EnRespIniciado;
						bolReintentar = true;
						IntReintentos = 0;
						do
						{
							switch(EnRespuesta)
							{
								case EnumRespTransaccion.EnRespSinRespuesta : case EnumRespTransaccion.EnRespConfirmar : case EnumRespTransaccion.EnRespIniciado :

									IntReintentos = System.Convert.ToInt32(IntReintentos + Math.Abs((EnRespuesta != EnumRespTransaccion.EnRespConfirmar) ? -1 : 0));
											//Solo incrementará el numero de reintentos cuando la respuesta 
									//no sea EnRespConfirmar 

									if (IntReintentos <= intMaxReintentos)
									{
										if (EnRespuesta == EnumRespTransaccion.EnRespSinRespuesta)
										{
											//Cuando no hay respuesta del S111
											//espera un tiempo antes de reintentar la operación
											prDelay(lngRetardoConsultas);
										}

										strRespTemp = EnviaMensajeSM(this.Transaccion, ref ilError, ref sCausaError);
										EnRespuesta = ValidaRespTransaccion(strRespTemp);
									}
									else
									{
										bolReintentar = false;
									}
											break;
										case EnumRespTransaccion.EnRespDarseAlta :
									strRespTemp = "";
									bolReintentar = false;
									break;
										case EnumRespTransaccion.EnRespTerminalSinFirmar :
									bolReintentar = false;  //La terminal no esta firmada por lo que el usuario debe darse de alta al S041 
									break;
										case EnumRespTransaccion.EnRespDesconocida : case EnumRespTransaccion.EnRespTransaccionAceptada : case EnumRespTransaccion.EnRespOperacionNegada : case EnumRespTransaccion.EnRespError :
									bolReintentar = false;

									break;
									}
								}
								while(bolReintentar);
								mStrRespuestaTransaccion = strRespTemp;
								Estado = EnRespuesta;
							//El resultado del mensaje enviado es asignado a la respuesta de la transaccion
							}
							return true; //La transaccion ya fue enviada
						}
						else
				{
					return false;
				}
					}
					catch(Exception e)
			{
                Err.LoadError(e);
			}
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
			if (Information.Err().Number == 1)
			{
				//El arcivo ini no exite por lo que continua con el siguiente paso
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
                //Artinsoft.Silverlight.Client.Compatibility.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			else
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
				modErrorHandling.RaiseError(Information.Err().Number, this.GetType().Name + CTEMSGERROR + "EnviaTrasaccionS111", Information.Err().Description);
			}
					return result;
				}
				//======================================================================
		// EN ESTA SECCION SE ENCUENTRAN LAS FUNCIONES PARA REALIZAR LAS CONSULTAS AL S111
		//======================================================================
        private string EnviaMensajeSM(string strCadena, ref int iResult, ref string sCausaError)
        {
            // Primero debe limpiar el buffer de mensajes previos, Si hay un error diferente de TimeOut, detiene el proceso y regresa.
            string sBloque = String.Empty;
            int iLongitudMsg = 0;
            string sRespuestaTmp = String.Empty;
            int intResultado = 0;
            //int lngTimeOut = 1500;
            int lngTimeOut = 3000;
            string tempRefParam = "COMDRV32";
            string tempRefParam2 = String.Empty;
            bool bContinue = true;
            string sCadenaRespuesta = "";
            int i = 0;
            //    Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(
            //() => {tempRefParam2 = lngTimeOut.ToString();},
            //() => {lngTimeOut = System.Convert.ToInt32(Double.Parse(this.FnStrLeeIni(ref tempRefParam, "TimeOutTcpServer", ref tempRefParam2)));
            //    }
            //    );
            //        while(bContinue)
            //{
            //        //    Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(
            //        //() => {Information.Err().Clear();},
            //        //() => {
            //            Information.Err().Clear();
            //            try
            //            {
            //                modClassIDGenerator.objSeguridad.ReceiveResponse(lngTimeOut);
            //            }
            //            catch (Exception e)
            //            {
            //                Err.LoadError(e);
            //            }
            //    //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
            //    //if (Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNextExpr<bool>(() => {return Information.Err().Number == -2147014836;}))
            //    if (Information.Err().Number == -2147014836)
            //    {
            //            bContinue = false;
            //        }
            //        else if (Information.Err().Number == -2147014839 && i == 0)
            //        {
            //                System.Exception ex = null;
            //                //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(ref ex,  //No hay una conexión establecida. Intentará establecerla.
            //                //() => {Information.Err().Clear();},
            //                //() => {modClassIDGenerator.objSeguridad.Connect();});

            //                Information.Err().Clear();
            //                modClassIDGenerator.objSeguridad.Connect();
            //                if (ex != null)
            //               {
            //                string sCausaErrorTmp = sCausaError;
            //                    Err.LoadError(ex);
            //                    //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext( //Se generó un error al inicializar la operación
            //                    //    //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
            //                    //() => {intResultado = Information.Err().Number;},
            //                    //() => {sCausaErrorTmp = Information.Err().Description;});

            //                intResultado = Information.Err().Number;
            //                sCausaErrorTmp = Information.Err().Description;
            //                sCausaError = sCausaErrorTmp;
            //                bContinue = false;

            //              }
            //            else
            //            {
            //                bContinue = true;
            //            }
            //            }
            //            else if (Information.Err().Number != 0)
            //        {
            //            string sCausaErrorTmp = sCausaError;
            //                //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(
            //                //    //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
            //                //() => {intResultado = Information.Err().Number;},
            //                //() => {sCausaErrorTmp = Information.Err().Description;});

            //            intResultado = Information.Err().Number;
            //            sCausaErrorTmp = Information.Err().Description;
            //            sCausaError = sCausaErrorTmp;
            //            bContinue = false;

            //        }

            //            //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(
            //            //() => {Information.Err().Clear();},
            //            //() => {i++;});

            //            Information.Err().Clear();
            //            i++;

            //        }

            //;
            if (intResultado == 0)
            {
                System.Exception ex_2 = null;
                //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(ref ex_2,
                //() => {strCadena = "P" + strCadena + Strings.Chr(3).ToString();
                //}
                //,() => {modClassIDGenerator.objSeguridad.SendRequest(Artinsoft.Silverlight.Client.Utils.StringsHelper.StrConv(strCadena,Artinsoft.Silverlight.Client.Utils.StringsHelper.VbStrConvEnum.vbFromUnicode,0), (short) strCadena.Length);}
                //);

                strCadena = "P" + strCadena + Strings.Chr(3).ToString();
                modClassIDGenerator.objSeguridad.SendRequest(StringsHelper.StrConv(strCadena, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)strCadena.Length);

                if (ex_2 != null)
                {
                    string sCausaErrorTmp = sCausaError;
                    //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(
                    //    //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                    //() => {intResultado = Information.Err().Number;},
                    //() => {sCausaErrorTmp = Information.Err().Description;});

                    intResultado = Information.Err().Number;
                    sCausaErrorTmp = Information.Err().Description;
                    sCausaError = sCausaErrorTmp;
                    sCadenaRespuesta = "";

                }
                else
                {
                    try
                    {
                        Information.Err().Clear();
                        i++;
                    }
                    catch
                    {
                    }
                    bContinue = true;
                    i = 0;
                    sRespuestaTmp = "";
                    iLongitudMsg = 10000;
                    do
                    {
                        System.Exception ex_3 = null;
                        sBloque = "";
                        //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(ref ex_3,
                        //() => {sBloque = Artinsoft.Silverlight.Client.Utils.StringsHelper.StrConv(modClassIDGenerator.objSeguridad.ReceiveResponse(lngTimeOut),Artinsoft.Silverlight.Client.Utils.StringsHelper.VbStrConvEnum.vbUnicode,0);});
                        sBloque = StringsHelper.StrConv(modClassIDGenerator.objSeguridad.ReceiveResponse(lngTimeOut), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                        // Si se recibe un bloque de 13 caracteres de longitud, se asume que es una cadena Chr(13) & Chr(10) & Chr(3)
                        // no la cadena esperada. Por lo tanto, continuará con la recepción.
                        //if (Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNextExpr<bool>(() => {return Strings.Mid(sBloque, 1, 1) == "H" && sBloque.Length != 13;})){
                        //if (Strings.Mid(sBloque, 1, 1) == "H" && sBloque.Length != 13)
                        //{

                        //    sRespuestaTmp = "";
                        //    //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(ref ex_3,
                        //    //    () => {iLongitudMsg = System.Convert.ToInt32(Conversion.Val(Strings.Mid(sBloque, 3, 4)));
                        //    //}
                        //    //);
                        //    iLongitudMsg = System.Convert.ToInt32(Conversion.Val(Strings.Mid(sBloque, 3, 4)));
                        //    i = 0;

                        //}


                        ////Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(ref ex_3,
                        ////    () => {sRespuestaTmp = sRespuestaTmp + sBloque;});
                        //sRespuestaTmp = sRespuestaTmp + sBloque;
                        //if (ex_3 != null)
                        //{
                        //    string sCausaErrorTmp = sCausaError;
                        //    //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(
                        //    //        //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                        //    //    () => {intResultado = Information.Err().Number;},
                        //    //    () => {sCausaErrorTmp = Information.Err().Description;});

                        //    intResultado = Information.Err().Number;
                        //    sCausaErrorTmp = Information.Err().Description;
                        //    sCausaError = sCausaErrorTmp;
                        //    bContinue = false;

                        //}

                        ////Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(
                        ////    () => {Information.Err().Clear();},
                        ////    () => {i++;});
                        //Information.Err().Clear();
                        //i++;

                        // Si se recibe un bloque de 13 caracteres de longitud, se asume que es una cadena Chr(13) & Chr(10) & Chr(3)
                        // no la cadena esperada. Por lo tanto, continuará con la recepción.
                        if (Strings.Mid(sBloque, 1, 1) == "H" && sBloque.Length != 12)
                        {
                            sRespuestaTmp = "";
                            iLongitudMsg = System.Convert.ToInt32(Conversion.Val(Strings.Mid(sBloque, 3, 4))) - 1;
                            iLongitudMsg = iLongitudMsg == 57 ? 58 : iLongitudMsg;
                            i = 0;
                        }
                        sRespuestaTmp = sRespuestaTmp + sBloque;
                        if (Information.Err().Number != 0)
                        {
                            intResultado = Information.Err().Number;
                            sCausaError = Information.Err().Description;
                            bContinue = false;
                        }
                        Information.Err().Clear();
                        i++;


                    }
                    while (bContinue && iLongitudMsg > sRespuestaTmp.Length);
                    try
                    { //continuará mientras no haya un error y no se haya
                        // recibido la cadena completa.
                        sCadenaRespuesta = Strings.Mid(sRespuestaTmp, 11);
                        sCadenaRespuesta = !sCadenaRespuesta[0].Equals('\0') ? sCadenaRespuesta : string.Empty;
                    }
                    catch
                    {
                    }
                    if (intResultado == 0)
                    {
                        try
                        {
                            intResultado = sRespuestaTmp.Length;
                        }
                        catch
                        {
                        }
                    }
                }
            }

            try
            {
                iResult = intResultado;
            }
            catch
            {
            }

            return sCadenaRespuesta;

        }

				#if DebugMode

				#endif
				private bool Conectar()
				{
						bool result = false;
						int ErrNo = 0;
						string strError = String.Empty;

						try
						{
                            //modErrorHandling.GrabaLog(this.GetType().Name + ".-Método Conectar:Iniciado");
							if (modClassIDGenerator.objSeguridad == null)
							{
                                //modErrorHandling.GrabaLog(this.GetType().Name + ".-Método Conectar:Intentando Inicializar el Comdrv32.exe");
								modClassIDGenerator.objSeguridad = new COMDRV32.TcpServer();
                                //modErrorHandling.GrabaLog(this.GetType().Name + ".-Método Conectar:Comdrv32.exe Inicializado" + "Llamando Comdrv32.Connect");
								modClassIDGenerator.objSeguridad.Connect();
							}
							result = true;
                            //modErrorHandling.GrabaLog(this.GetType().Name + ":Comdrv32 Conectado Exitosamente");
							return result;
						}
						catch (System.Exception excep)
						{
							result = false;
							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
							ErrNo = Information.Err().Number;
							strError = excep.Message;
                            //modErrorHandling.GrabaLog(this.GetType().Name + "Se ha provocado un error: " + ErrNo.ToString() + " " + strError);
							modClassIDGenerator.objSeguridad = null;
							modErrorHandling.RaiseError(ErrNo, this.GetType().Name + CTEMSGERROR + "Conectar", strError + System.Environment.NewLine + "Mientras se intento comunicar con Comdrv32.exe");
							return result;
						}
				}
				public bool Desconectar()
				{
					bool result = false;
					System.Exception ex = null;
					result = true;
                    //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(ref ex,
                    //        () => {modClassIDGenerator.objSeguridad.Disconnect();},
                    //        () => {modClassIDGenerator.objSeguridad = null;});

                    modClassIDGenerator.objSeguridad.Disconnect();
                    modClassIDGenerator.objSeguridad = null;

					if (ex != null)
						{
							try
							{ //Se generó un error al terminar la conexión
								//MsgBox "Error " & Err.Number & ": " & Err.Description
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
								modErrorHandling.RaiseError(Information.Err().Number, CTEMSGERROR + "Conectar", Information.Err().Description + System.Environment.NewLine + "Mientras se intento comunicar  con Comdrv32.exe");
							}
							catch
							{
							}
							result = false;
						}
					
					Information.Err().Clear();
					return result;
					
				}
				private EnumRespTransaccion ValidaRespTransaccion(string pStrRespTransS111)
				{
						const string CTESINRESPUESTA = "";
						const string CTEREPITATRANSACCION = "Repita transaccion";
						const string CTEDARSEALTA = "DARSE DE ALTA";
						const string CTEACEPTADA = "Transaccion aceptada";
						const string CTETERMINALSINFIRMAR = "NO ESTA FIRMADA LA TERMINAL";
						const string CTEOPERACIONNEGADA = "OPERACION NEGADA";
						const string CTEERROR = "ERROR";
						do
						{
							pStrRespTransS111 = Strings.Replace(pStrRespTransS111, new String(' ', 2), new String(' ', 1), 1, -1, CompareMethod.Text) ?? string.Empty;
						}
						while(pStrRespTransS111.IndexOf(new String(' ', 2), StringComparison.CurrentCultureIgnoreCase) >= 0);
						if (pStrRespTransS111 == CTESINRESPUESTA || pStrRespTransS111 == "\r" + "\n" + Strings.ChrW(3).ToString()){
							//No hay respuesta del S111
							return EnumRespTransaccion.EnRespSinRespuesta;
						}
					else if (pStrRespTransS111.IndexOf(CTEREPITATRANSACCION, StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							return EnumRespTransaccion.EnRespConfirmar;
						}
						else if (pStrRespTransS111.IndexOf(CTEDARSEALTA, StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							return EnumRespTransaccion.EnRespDarseAlta;
						}
						else if (pStrRespTransS111.IndexOf(CTEACEPTADA, StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							return EnumRespTransaccion.EnRespTransaccionAceptada;
						}
						else if (pStrRespTransS111.IndexOf(CTETERMINALSINFIRMAR, StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							return EnumRespTransaccion.EnRespTerminalSinFirmar;
						}
						else if (pStrRespTransS111.IndexOf(CTEOPERACIONNEGADA, StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							return EnumRespTransaccion.EnRespOperacionNegada;
						}
						else if (pStrRespTransS111.IndexOf(CTEERROR, StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							return EnumRespTransaccion.EnRespError;
						}
						else
						{
							return EnumRespTransaccion.EnRespDesconocida;
						}
				}
				//Private Sub RaiseError(pLngNoError As Long, pStrFuenteError As String, pStrDescripcion As String)
				//    Err.Raise pLngNoError, pStrFuenteError, pStrDescripcion
				//End Sub

				private void prDelay(int pLngTiempo)
				{
						//Retardo de tiempo en segundos
						int LngHoraFinal = 0;
						int LngHoraInicio = System.Convert.ToInt32(DateTime.Now.TimeOfDay.TotalSeconds);
					do
						{
							LngHoraFinal = System.Convert.ToInt32(DateTime.Now.TimeOfDay.TotalSeconds);
						if (LngHoraFinal < LngHoraInicio)
							{
								//La hora calculada es de un nuevo dia por lo tanto debe reasignar la nueva final
								//para calcular la diferencia real
								LngHoraFinal = 86400 + LngHoraFinal;
							}
					}
					while((LngHoraFinal - LngHoraInicio) < pLngTiempo);
				}
	}
}