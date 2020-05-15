#define DebugMode
//using Artinsoft.Silverlight.Client.Compatibility;
using Microsoft.VisualBasic;
using System;

using System.IO;
//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;



namespace N_TransS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
    //using Artinsoft.Silverlight.Client.Application;
	public class ClsConsulta
	{

		//
		 //Establecer a cero para eliminar la opción de debug
#if DebugMode

		//local variable to hold the serialized class ID that was created in Class_Initialize
		//##ModelId=4002D3490054
		private int mlClassDebugID = 0;
#endif
		public struct tpPropiedad
		{ //Estructura para leer el archivo de control para generar los objetos dinamicos
			public string strNombrePropiedad; //Nombre de la propiedad
			public object strValorPropiedad; //Valor almacenado por la propiedad
			public string strDelimitadorInicial; //Delimitador Inicial de cada campo segun la respuesta del S111
			public string StrDelimitadorFinal; //Delimitador Final de  cada campo segun la respuiesta del S111
			public int IntPosInicial; //Posición Inicial del Campo cuando no se define el delimitador inicial
			public int Longitud; //Longitud del campo cuando no se define el delimitador final
			public static tpPropiedad CreateInstance()
			{
					tpPropiedad result = new tpPropiedad();
					result.strNombrePropiedad = String.Empty;
					result.strDelimitadorInicial = String.Empty;
					result.StrDelimitadorFinal = String.Empty;
					return result;
			}
		}
		private const string MCTMSGERROR = ": Método: ";
		private const int CTEERRORTRANSACCIONINVALIDA = -50;
		private const int CTEERRORARCHIVOCTLINEXISTENTE = 1;
		private const int CTEPROPIEDADINEXISTENTE = 5;
		private const int CTEESTADOERRONEO = -40;
		private const int CTEOBJETOFIRMANOESTABLECIDO = -30;

		private N_TransS111.ClsSeguridad ObjFirma = null; //Instancia para el objeto encargado de realizar la firma al S041
		private ClsTransaccion objTransaccion = null; //Instancia para enviar las transaccion al S111
		private ClsPropiedad ObjPropiedad = null; //Instancia al objeto de propiedades dinamicas
		private string strRespuesta = String.Empty; //Respuesta recibida del S111
		private tpPropiedad[] ArrPropiedades = null; //Arreglo que contiene la estructura del archivo de control

		//##ModelId=4002D215021E
		public void Enviar(string pStrCuenta, ref string pAdicionales)
		{
			//Objetivo: Enviar el dialogo al S111
			//Parametros de entrada :
			//PstrCuenta: NoCuenta que se quiere hacer la transaccion

			//PAdicionales: Parametros adicionales que forman parte del dialogo
			//Por ejemplo Transaccion 377 Requiere: cuenta identicador valor
			//           377 4943887920000098

			string strDialogo = String.Empty;
			N_TransS111.ClsSeguridad.EnumEstadosFirma EnEstadosFirma = (N_TransS111.ClsSeguridad.EnumEstadosFirma)0;
			bool BolReenviarTrans = false;
			try
			{
				if (false)
				{
					pAdicionales = "";
				}

                //if (ObjFirma == null)
                //{
                //    //Determina si la propiedad del objeto de firma ha sido establecido
                //    //con el objetivo de que si al enviar la transaccion
                //    //se encuentrá con el caso de que no este firmado al S041
                //    //Se vuelva a firmar
                //    modErrorHandling.RaiseError(CTEOBJETOFIRMANOESTABLECIDO, this.GetType().Name + MCTMSGERROR + "Enviar", "La transacción no puede ser enviada cuando el objeto de firma está cerrado o no ha sido establecido");
                //}
                //else
                //{
					do
					{
						strDialogo = objTransaccion.IdTransaccion + " " + pStrCuenta + " " + pAdicionales;
                        //modErrorHandling.GrabaLog(this.GetType().Name + " Transaccion:" + strDialogo);
						objTransaccion.Transaccion = strDialogo; //Dialogo que se enviará al S111
						objTransaccion.EnviaTransaccionS111(); //Envia la transaccion al S11
						switch(objTransaccion.Estado)
						{
							case ClsTransaccion.EnumRespTransaccion.EnRespTransaccionAceptada : case ClsTransaccion.EnumRespTransaccion.EnRespDesconocida :
								BolReenviarTrans = false;

								if (objTransaccion.RespTransaccion != "")
								{
									if (!FnActualizarValorPropiedades())
									{
										//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
										modErrorHandling.RaiseError(Information.Err().Number, MCTMSGERROR + "Enviar", Information.Err().Description);
									}
								}
								break;
							case ClsTransaccion.EnumRespTransaccion.EnRespDarseAlta :
								ObjFirma.TipoFirma = N_TransS111.ClsSeguridad.EnumTipoFirma.EnFirmaConModulos;
                                //if (ObjFirma.fncFirmaS041B(ref EnEstadosFirma))
                                //{
                                //    BolReenviarTrans = true;
                                //    //Se logró firmar exitosamente por lo tanto reenvia la transaccion actual
                                //}
                                //else
                                //{
                                //    BolReenviarTrans = !(EnEstadosFirma == N_TransS111.ClsSeguridad.EnumEstadosFirma.EnPasswordInvalido || EnEstadosFirma == TransS111.ClsSeguridad.EnumEstadosFirma.EnRespuestaDesconocida || EnEstadosFirma == TransS111.ClsSeguridad.EnumEstadosFirma.EnSinRespuesta);
                                ////Se provoco un error inesperado por lo tanto no se logro firma al S111
                                //}
								break;
							default:
								BolReenviarTrans = false;
								break;
						}
                    //    modErrorHandling.GrabaLog(this.GetType().Name + " Estado:" + ((int) objTransaccion.Estado).ToString());
                    //    modErrorHandling.GrabaLog(this.GetType().Name + " Resp:" + objTransaccion.RespTransaccion);
                    }
					while(BolReenviarTrans);
				}
            //}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
				modErrorHandling.RaiseError(Information.Err().Number, this.GetType().Name + MCTMSGERROR + "Enviar", excep.Message);
			}
			
			
		}

		public void Enviar(string pStrCuenta)
		{
			string tempRefParam = String.Empty;
			Enviar(pStrCuenta, ref tempRefParam);
		}

		public ClsConsulta()
		{
			#if DebugMode

			//get the next available class ID, and print out
			//that the class was created successfully
			mlClassDebugID = modClassIDGenerator.GetNextClassDebugID();
			System.Diagnostics.Debug.WriteLine("'" + this.GetType().Name + "' instance " + mlClassDebugID.ToString() + " created");
			#endif
			
			
		}

		//##ModelId=4002D34902E9
		~ClsConsulta()
		{
#if DebugMode

			//the class is being destroyed
			System.Diagnostics.Debug.WriteLine("'" + this.GetType().Name + "' instance " + mlClassDebugID.ToString() + " is terminating");
#endif
			//Libera la memoria utilizada por los objetos
			//privados
			objTransaccion = null;
			ObjPropiedad = null;
			ObjFirma = null;

		}

#if DebugMode

		//##ModelId=4002D34900EB
		public int ClassDebugID
		{
			get
			{
				//if we are in debug mode, surface this property that consumers can query
				return mlClassDebugID;
			}
		}

		public ClsTransaccion.EnumRespTransaccion Estado
		{
			get
			{
				return objTransaccion.Estado;
			}
		}

		public ClsPropiedad get_Propiedades(object pIndex)
		{
			return GetPropiedades(pIndex);
		}
		public ClsPropiedad GetPropiedades(object pIndex)
		{
			ClsPropiedad result = null;
			ClsTransaccion.EnumRespTransaccion enEstado = this.Estado;
			if (enEstado == ClsTransaccion.EnumRespTransaccion.EnRespTransaccionAceptada || enEstado == ClsTransaccion.EnumRespTransaccion.EnRespDesconocida)
			{
				result = objTransaccion[pIndex];
			}
			else
			{
				modErrorHandling.RaiseError(CTEESTADOERRONEO, MCTMSGERROR + "Propiedades", "Se ha encontrado un estado invalido de la transaccion");
			}

			return result;
		}

		public int ContarPropiedades
		{
			get
			{
				int intPropiedades = 0;
				return objTransaccion.Contar;
			}
		}


		public string RespuestaTransS111
		{
			get
			{
				return objTransaccion.RespTransaccion;
			}
		}


		public N_TransS111.ClsSeguridad ConexionSeguridad
		{
			set
			{
				ObjFirma = value;
			}
		}

#endif
		public void prIdTransaccion(string pVarIdTrans)
		{
			//Objetivo: Asignar un identificador a la transaccion y generar
			//          La colexión de Objetos e indicarle al objeto transacción que genere la colexion de propiedades
			//          En caso de que se haya definido un archivo de control
			//
			//Contador de las propiedades a generar
			try
			{
				//UPGRADE_NOTE: (1061) Erase was upgraded to System.Array.Clear. More Information: http://www.vbtonet.com/ewis/ewi1061.aspx
				if (ArrPropiedades != null)
				{
					Array.Clear(ArrPropiedades, 0, ArrPropiedades.Length);
				} //Borra el arreglo de propiedades
				ArrPropiedades = ArraysHelper.InitializeArray<tpPropiedad>(2);
				objTransaccion = null; //Libera la transaccion actual
				//para permitir cambiar el identificador
				//de sesion cuantas veces sea necesario

                objTransaccion = new ClsTransaccion();
				objTransaccion.IdTransaccion = pVarIdTrans; //Asigan el Identificador de la Transacion actual
				if (objTransaccion.IdTransaccion == "")
				{
					throw new System.Exception(CTEERRORTRANSACCIONINVALIDA.ToString() + ", " + MCTMSGERROR + "PrIdTransaccion" + ", Transacción Invalida");
					//Prova el error de que el usuario no envio transaccion valida
				}
				else
				{

                    //if (FnBolLeeArchCtrl())
                    //{
						//EL archivo de conctrol fue leido correctamente
						//y se ha determinado la nueva estructura
						//por lo que se procederá a agregar las propiedades

						//Valida que el arregglo este inicializado
						foreach (tpPropiedad ArrPropiedades_item in ArrPropiedades)
						{
                            if (ArrPropiedades_item.strNombrePropiedad != "")
							{
								ObjPropiedad = new ClsPropiedad();
                                ObjPropiedad.Nombre = ArrPropiedades_item.strNombrePropiedad;
								//UPGRADE_WARNING: (1068) ArrPropiedades().strValorPropiedad of type Variant is being forced to string. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
                                ObjPropiedad.Valor = System.Convert.ToString(ArrPropiedades_item.strValorPropiedad);
                                objTransaccion.AgregarPropiedad(ObjPropiedad); //Agrega la propiedad a la lista de propiedades
                            }
                        //}
					}
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
				modErrorHandling.RaiseError(Information.Err().Number, this.GetType().Name + MCTMSGERROR + "PrIdTransaccion", excep.Message);
			}
		}
        //private bool FnBolLeeArchCtrl()
        //{
        //    //Lee un archivo de control para determina la lista de propiedades
        //    //asi como sus identificadores
        //    bool result = false;
        //    const string ctePROPIEDAD = "Propiedad:=";
        //    const string ctePOSINI = "PosIni:="; //Identificador de la posicion Inicial
			
        //    const string CteLongitud = "Longitud:="; //Identificador de la Longitud Inicial
			
        //    const string CteDelimitadorInicial = "DelimitadorIni:="; //Identificador del Delimitador Inicial
			
        //    const string CteDelimitadorFinal = "DelimitadorFin:="; //Identificador del Delimitador Final
			
        //    const string CTEVALORINICIAL = "";
        //    string strArchControl = String.Empty;
        //    System.IO.StreamReader intHandlerArchCtl = null;
        //    string strContArchivo = String.Empty;
        //    int intLineasArchivo = 0;
        //    string StrPos = String.Empty;
        //    try
        //    {
        //        strArchControl = Path.GetDirectoryName(System.Windows.Application.Current.GetExecutablePath()); //Determina el valor inicial
        //        string tempRefParam = @"SOFTWARE\Banamex\C430_001\TarjetaCorporativa\Variables";
        //        strArchControl = objTransaccion.FnStrLeeIni(ref tempRefParam, "PathCtl", ref strArchControl); //La linea esta definida
        //        //Si Está definida una linea como
        //        //[TransS111]
        //        //PathCtl= C:\Apps\Atenea\
        //        //En caso de que la linea no este definida devolverá la ruta actual del programa

        //        if (Strings.Right(strArchControl, 1) != "\\")
        //        {
        //            strArchControl = strArchControl + "\\";
        //        }
        //        strArchControl = strArchControl + "Trans" + objTransaccion.IdTransaccion.Trim() + ".ctl";
        //        //Determina el nombre del archivo de control
        //        string filename = strArchControl;
        //        try { filename = (System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().FileExists(strArchControl) && System.IO.File.GetAttributes(strArchControl).HasFlag(System.IO.FileAttributes.Archive) ? strArchControl : ""); }
        //        catch (Exception ex) 
        //        {
        //            if (ex.Message == "La ruta de acceso especificada o el nombre de archivo (o ambos) son demasiado largos. El nombre de archivo completo debe ser inferior a 260 caracteres y el nombre del directorio debe ser inferior a 248.")
        //                filename = "";
        //            else
        //                filename = strArchControl;
        //        }
        //        if (filename != ""){
        //            //El archivo de conctrol existe entonces creará las propiedades dinamicas
        //            intHandlerArchCtl = null;
        //                                intHandlerArchCtl = new System.IO.StreamReader(System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().OpenFile(strArchControl,System.IO.FileMode.OpenOrCreate));
        //                                intLineasArchivo = 0;
        //                                while (!(intHandlerArchCtl.Peek() == -1))
        //            {
        //                                                        strContArchivo = intHandlerArchCtl.ReadEntry<string>();
        //                if (strContArchivo.Trim() != "" && (Strings.Left(strContArchivo.Trim(), 1) != "'" && Strings.Left(strContArchivo.Trim(), 1) != "#"))
        //                {
        //                    //La linea es un comentario
        //                    intLineasArchivo++;
        //                    ArrPropiedades = Artinsoft.Silverlight.Client.Utils.ArraysHelper.RedimPreserve(ArrPropiedades, new int[]{intLineasArchivo + 1});
        //                                                            strContArchivo = Strings.Replace(strContArchivo, ":= ", ":=", 1, -1, CompareMethod.Binary); //Quita los espacios Intermedios
        //                                                            strContArchivo = Strings.Replace(strContArchivo, " :=", ":=", 1, -1, CompareMethod.Binary); //que puedan existir entre
        //                                                            strContArchivo = Strings.Replace(strContArchivo, ": =", ":=", 1, -1, CompareMethod.Binary).Trim(); //: y =
        //                                                            if (Strings.Left(strContArchivo, 1) != "'" && Strings.Left(strContArchivo, 1) != "#")
        //                    { //La linea no está comentada
        //                        string tempRefParam2 = ctePOSINI;
        //                        string tempRefParam3 = "\t";
        //                        StrPos = FnBuscaPatron(ref strContArchivo, ref tempRefParam2, ref tempRefParam3);
        //                        double dbNumericTemp = 0;
        //                        if (Double.TryParse(StrPos,System.Globalization.NumberStyles.Number,System.Globalization.CultureInfo.CurrentCulture.NumberFormat,out dbNumericTemp))
        //                        {
        //                            ArrPropiedades[intLineasArchivo - 1].IntPosInicial = System.Convert.ToInt32(Double.Parse(StrPos));
        //                                                                }
        //                                                                else
        //                        {
        //                            ArrPropiedades[intLineasArchivo - 1].IntPosInicial = 0;
        //                        }
        //                                                                string tempRefParam4 = CteLongitud;
        //                                                                string tempRefParam5 = "\t";
        //                                                                StrPos = FnBuscaPatron(ref strContArchivo, ref tempRefParam4, ref tempRefParam5);
        //                                                                double dbNumericTemp2 = 0;
        //                                                                if (Double.TryParse(StrPos,System.Globalization.NumberStyles.Number,System.Globalization.CultureInfo.CurrentCulture.NumberFormat,out dbNumericTemp2))
        //                        {
        //                            ArrPropiedades[intLineasArchivo - 1].Longitud = System.Convert.ToInt32(Double.Parse(StrPos));
        //                                                                }
        //                                                                else
        //                        {
        //                            ArrPropiedades[intLineasArchivo - 1].Longitud = 0;
        //                        }
        //                                                                string tempRefParam6 = CteDelimitadorFinal;
        //                                                                string tempRefParam7 = "\t";
        //                                                                ArrPropiedades[intLineasArchivo - 1].StrDelimitadorFinal = FnBuscaPatron(ref strContArchivo, ref tempRefParam6, ref tempRefParam7);
        //                                                                if (ArrPropiedades[intLineasArchivo - 1].Longitud == 0 && ArrPropiedades[intLineasArchivo - 1].StrDelimitadorFinal == "")
        //                        {
        //                            ArrPropiedades[intLineasArchivo - 1].StrDelimitadorFinal = "\r"; //Cuando no se definen ninguno de los
        //                            //parametros tomará el salto de linea
        //                        }
        //                                                                string tempRefParam8 = CteDelimitadorInicial;
        //                                                                string tempRefParam9 = "\t";
        //                                                                ArrPropiedades[intLineasArchivo - 1].strDelimitadorInicial = FnBuscaPatron(ref strContArchivo, ref tempRefParam8, ref tempRefParam9);
        //                                                                string tempRefParam10 = ctePROPIEDAD;
        //                                                                string tempRefParam11 = "\t";
        //                                                                ArrPropiedades[intLineasArchivo - 1].strNombrePropiedad = FnBuscaPatron(ref strContArchivo, ref tempRefParam10, ref tempRefParam11);
        //                                                                //UPGRADE_WARNING: (1037) Couldn't resolve default property of object ArrPropiedades().strValorPropiedad. More Information: http://www.vbtonet.com/ewis/ewi1037.aspx
        //                        ArrPropiedades[intLineasArchivo - 1].strValorPropiedad = CTEVALORINICIAL;
        //                                                            }
        //                                                        }
        //                                }
        //                                intHandlerArchCtl.Close();
        //        }
        //        else
        //        {
        //            ArrPropiedades = Artinsoft.Silverlight.Client.Utils.ArraysHelper.InitializeArray<tpPropiedad>(2);//No existe el archivo de control por lo tanto
        //        //no hay propiedades definidas
        //        }
        //        return true;
        //    }
        //    catch (System.Exception e)
        //    {
        //        //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //        if (Information.Err().Number != CTEERRORARCHIVOCTLINEXISTENTE)
        //        {
        //            if (intHandlerArchCtl != null)
        //            {
        //                                     intHandlerArchCtl.Close();
        //            }
        //            //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //            modErrorHandling.RaiseError(Information.Err().Number, this.GetType().Name + MCTMSGERROR + "FnBolLeeArchCtrl", e.Message);
        //        }
        //        else
        //        {
        //            //El archivo de control no existe por lo tanto tomará los valores por defecto
        //            ////UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
        //            //Artinsoft.VB6.Utils.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
        //        }

        //        return result;
        //    }
			
			
        //}

		private string FnBuscaPatron(ref string strCadenaOrigen, ref string StrCadenaBusqueda, ref string Delimitador)
		{
			//Objetivo: Buscar un Patron de carateres exitentes en una cadena de caracteres
			//          Existentes entre dos cadenas de caracteres
			//          Las busquedas no son sensibles a mayusculas y minusculas
			//Parametros de Entrada:
			//                       StrCadenaOrigen:= Cadena en la que se va a realizar la busqueda
			//                       StrCadenaBusqueda:= Cadena que se va a buscar
			//                                           para obtener el inicio de
			//                                           la cadena resultante
			//                                           Si este parametro no se encuentra
			//                                           se devolverá una cadena vacia
			//                       Delimitador:= Parametro opcional en donde se
			//                                     determina el fin  de la cadena
			//                                     resultante
			//                                      Si este parametro no es suministrado
			//                                       se considerará un vbcrlf
			//                                      Si este parametro no es encontrado
			//                                      se devolverá el resto de la cadena


			string result = String.Empty;
			int intPosIni = 0;
			int intLongitud = 0;
			if (false)
			{
				Delimitador = System.Environment.NewLine;
			}
			result = "";
			if (strCadenaOrigen != "")
			{
				intPosIni = (strCadenaOrigen.IndexOf(StrCadenaBusqueda, StringComparison.CurrentCultureIgnoreCase) + 1);
				if (intPosIni > 0)
				{
					intLongitud = Strings.InStr(intPosIni, strCadenaOrigen, Delimitador, CompareMethod.Text);
					if (intLongitud > 0)
					{
						//Se encontro el delimitador
						result = Strings.Mid(strCadenaOrigen, intPosIni + StrCadenaBusqueda.Length, intLongitud - intPosIni - StrCadenaBusqueda.Length);
					}
					else
					{
						//No se encontro el delimitador
						//por lo tanto devuelve el resto de la cadena
						result = Strings.Mid(strCadenaOrigen, intPosIni + StrCadenaBusqueda.Length, strCadenaOrigen.Length);
					}


				}
			}
			return result.Trim();
		}
		private string FnBuscaPatron(ref string strCadenaOrigen, ref string StrCadenaBusqueda)
		{
			string tempRefParam2 = String.Empty;
			return FnBuscaPatron(ref strCadenaOrigen, ref StrCadenaBusqueda, ref tempRefParam2);
		}
		private bool FnActualizarValorPropiedades()
		{
			bool result = false;
			string strValorPropiedad = String.Empty;
			int intPropiedades = 0;
			int intPosIni = 0;
			int intLongitud = 0;
			string strRespuestaTmp = String.Empty;
			string[] ArrCadenasControl = new string[]{String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty};
			string StrCadenaBusqueda = String.Empty;

			ArrCadenasControl[0] = Strings.Chr(27).ToString() + " (";
			ArrCadenasControl[1] = Strings.Chr(27).ToString() + ")";
			ArrCadenasControl[2] = Strings.Chr(27).ToString() + "(";
			ArrCadenasControl[3] = Strings.Chr(27).ToString() + "G0";
			ArrCadenasControl[4] = Strings.Chr(27).ToString() + "G6";
			ArrCadenasControl[5] = Strings.Chr(3).ToString();
			ArrCadenasControl[6] = Strings.Chr(27).ToString() + "G8";
			ArrCadenasControl[7] = Strings.Chr(27).ToString() + "G@";
			//UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
            //Artinsoft.Silverlight.Client.Compatibility.NotUpgradedHelper.NotifyNotUpgradedElement("On Error Goto Label (Handler)");
			int tempForVar = objTransaccion.Contar;
			for (intPropiedades = 1; intPropiedades <= tempForVar; intPropiedades++)
			{
				//Debug.Print objTransaccion.Item(intPropiedades).Nombre
				objTransaccion[intPropiedades].Valor = "";
			}
			StrCadenaBusqueda = this.RespuestaTransS111;
			for (intPosIni = ArrCadenasControl.GetLowerBound(0); intPosIni <= ArrCadenasControl.GetUpperBound(0); intPosIni++)
			{
				//Elimina las cadenas de control que pudiesen existir
				StrCadenaBusqueda = Strings.Replace(StrCadenaBusqueda, ArrCadenasControl[intPosIni], "", 1, -1, CompareMethod.Text);
			}
			for (intPropiedades = ArrPropiedades.GetLowerBound(0) + 1; intPropiedades <= ArrPropiedades.GetUpperBound(0) + 1; intPropiedades++)
			{
				if (ArrPropiedades[intPropiedades - 1].strNombrePropiedad != "")
				{
					//La propiedad no tiene nombres por lo tanto no la
					//encontrara en la colexion

					strValorPropiedad = ""; //Inicializa el valor para evitar que se lleve basura en la siguiente propiedad
					
					System.Exception ex = null;//Evita que se genere un error debido a que el item no existe en la colexion origen

                    //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(ref ex,
                    //    () => { ObjPropiedad = objTransaccion[ArrPropiedades[intPropiedades - 1].strNombrePropiedad]; });

                    ObjPropiedad = objTransaccion[ArrPropiedades[intPropiedades - 1].strNombrePropiedad];
                    if (Information.Err().Number != CTEPROPIEDADINEXISTENTE && ex != null)
					{
                        //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext( //No logro leer la propiedad actual
                        //        //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
                        //    () => {modErrorHandling.RaiseError(Information.Err().Number, MCTMSGERROR + "FnActualizarValorPropiedades", Information.Err().Description);},
                        //    () => {Information.Err().Clear();});
                        modErrorHandling.RaiseError(Information.Err().Number, MCTMSGERROR + "FnActualizarValorPropiedades", Information.Err().Description);
                        Information.Err().Clear();
					}
					
					//UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted. More Information: http://www.vbtonet.com/ewis/ewi1065.aspx
                    //Artinsoft.Silverlight.Client.Compatibility.NotUpgradedHelper.NotifyNotUpgradedElement("On Error Goto Label (Handler)"); //Rehabilita el control de errores debido a que no se haya podido generar un valor
					
					if (ArrPropiedades[intPropiedades - 1].strDelimitadorInicial != "" && ArrPropiedades[intPropiedades - 1].StrDelimitadorFinal != "")
					{
						//Se han suministrado los dos patrones de busqueda
						//por lo tanto busca el valor del campo existente en medio de ambos valores
						strValorPropiedad = FnBuscaPatron(ref StrCadenaBusqueda, ref ArrPropiedades[intPropiedades - 1].strDelimitadorInicial, ref ArrPropiedades[intPropiedades - 1].StrDelimitadorFinal);
					}
					else
					{
						if (ArrPropiedades[intPropiedades - 1].strDelimitadorInicial != "")
						{
							//Se ha proporcionado el campo inicial
							intPosIni = (StrCadenaBusqueda.IndexOf(ArrPropiedades[intPropiedades - 1].strDelimitadorInicial, StringComparison.CurrentCultureIgnoreCase) + 1);
							if (intPosIni > 0)
							{
								intPosIni += ArrPropiedades[intPropiedades - 1].strDelimitadorInicial.Length;
							}
						}
						else
						{
							//No se ha definido el campo inicial por lo tanto valida
							//la posicion inicial
							intPosIni = ArrPropiedades[intPropiedades - 1].IntPosInicial;

						}

						if (ArrPropiedades[intPropiedades - 1].StrDelimitadorFinal != "")
						{
							//Se ha proporcionado el delimitador final
							//y valida que este exista en caso contrario devuelve como
							//longitud 0
							intLongitud = Strings.InStr(intPosIni, StrCadenaBusqueda, ArrPropiedades[intPropiedades - 1].StrDelimitadorFinal, CompareMethod.Text); //Determina la posicion en la cual está la cadena de control
							if (intLongitud > 0)
							{
								intLongitud = intLongitud - ArrPropiedades[intPropiedades - 1].StrDelimitadorFinal.Length - intPosIni + 1; //Determina la longitud final
							}
							else
							{
								intLongitud = 0;
							}

						}
						else
						{
							//No se ha definido el delimitador final por lo tanto
							//Asigna el valor de la Longitud
							intLongitud = ArrPropiedades[intPropiedades - 1].Longitud;
						}

						if (intPosIni > 0)
						{

							strValorPropiedad = Strings.Mid(StrCadenaBusqueda, intPosIni, intLongitud);
						}
						else
						{
							//El Identificador Inicial no se ha definido por lo tanto devolverá
							//una cadena vacia.
							strValorPropiedad = "";
						}

					}
					
					//Elimina los caracteres de control que pudiesen existir
					//sin importar si vienen en mayusculas o minusculas

					//            strValorPropiedad = Replace(strValorPropiedad, Chr(27) & " (", "", , , vbTextCompare)
					//            strValorPropiedad = Replace(strValorPropiedad, Chr(27) & ")", "", , , vbTextCompare)
					//            strValorPropiedad = Replace(strValorPropiedad, Chr(27) & "(", "", , , vbTextCompare)
					//            strValorPropiedad = Replace(strValorPropiedad, Chr(27) & "G0", "", , , vbTextCompare)
					//            strValorPropiedad = Replace(strValorPropiedad, Chr(27) & "G6", "", , , vbTextCompare)
					strValorPropiedad = Strings.Replace(strValorPropiedad, "\r", "", 1, -1, CompareMethod.Text);
					strValorPropiedad = Strings.Replace(strValorPropiedad, "\n", "", 1, -1, CompareMethod.Text);
					//            strValorPropiedad = Replace(strValorPropiedad, Chr(3), "", , , vbTextCompare)
					strValorPropiedad = strValorPropiedad.Trim();
					//Actualiza el valor de la propiedad valor del objeto seleccionado
					ObjPropiedad.Valor = strValorPropiedad;
					//Actualiza el objeto que proviene de la colexion
					objTransaccion.ActualizarPropiedad(ObjPropiedad);
					
				}

			}
			return true;
			Handler:
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
			if (Information.Err().Number == CTEPROPIEDADINEXISTENTE)
			{
				//El item no existe en la colexion por lo tanto
				//no hay dato que actualizar
				modErrorHandling.RaiseError(CTEPROPIEDADINEXISTENTE, MCTMSGERROR + "FnActualizarValorPropiuedades", "La propiedad: " + ArrPropiedades[intPropiedades - 1].strNombrePropiedad + "No Existe");
			}
			else
			{
				//    Resume
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
				modErrorHandling.RaiseError(Information.Err().Number, "ClsConsulta: Metodo FnActualizarValorPropiedades", Information.Err().Description);
			}
			return result;
		}
	}
}