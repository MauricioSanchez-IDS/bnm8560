using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Runtime.InteropServices; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsCambiosMasivos
	{
	
		//Objetivo: Clase encargada de realizar los cambios masivos de una empresa y sus ejecutivos
		//           Aplicando los cambios tanto a todos los ejecutivos de una empresa en cuestion
		//           Asi como a la lista de cuentas proporcionadas por un archivo
		//
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		private struct tpCambioMasivo
		{
			public clsDialogo.enuTipoDialogo IdTipo;
			public string Descripcion;
			public int ValorInicial;
			public int ValorFinal;
			public Collection ListaValores;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=4)] public string ConstDialogo;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=1)] public string DlgTipoTransaccion;
			public bool BlAplicaEmpresa;
			
			public static tpCambioMasivo CreateInstance()
			{
					tpCambioMasivo result = new tpCambioMasivo();
					result.Descripcion = String.Empty;
					return result;
			}
		}
		
		private int lngNoEmpresa = 0;
		private int IdCambioMasivo = 0;
		//Private strDialogo111 As String
		private string strNoCuenta = String.Empty;
		private int dblValorEnviar = 0;
		//Private strDialogo As String
		//UPGRADE_WARNING: (1042) Array ArrCambioMasivo may need to have individual elements initialized.
		private tpCambioMasivo[] ArrCambioMasivo = ArraysHelper.InitializeArray<tpCambioMasivo[]>(new int[]{5});
		private int intNoCambioActual = 0;
		private clsDialogo DlgDialogoS111 = new clsDialogo();
		
		public int indice
		{
			get
			{
				return intNoCambioActual;
			}
			set
			{
				intNoCambioActual = value;
			}
		}
		
		public int NoEmpresa
		{
			get
			{
				return lngNoEmpresa;
			}
			set
			{
				lngNoEmpresa = value;
			}
		}	
		
		public int TipoCambioMasivo
		{
			set
			{
				IdCambioMasivo = value;
			}
		}
			
		public string NoCuentaBanco
		{
			get
			{
				return strNoCuenta;
				
			}
			set
			{
				//Objetivo: Determina si la cuenta actual está mapeada
				//           y actualiza el valor tgCambioS111.NumCuentaS
				//           ya que esta variable es la que utiliza la clase clsdialog
				//          para generar el dialogo correspondentie
				
				string strSql = String.Empty;
				ADODB.Recordset rsCtaMapeada = null;
				
				try
				{
						if (VBSQL.OpenConn(9) != 0)
						{
							VBSQL.gConn[9].Close();
						} 
                        else
						{
							VBSQL.gConn[9].Close();
						}
						
						if (VBSQL.OpenConn(9) == 0)
						{
							strSql = "Select map_cta_citi from MTCMAP01 Where map_cta_bnx = '" + value + "'";
							strSql = strSql + " and map_estatus = ''";
							
							rsCtaMapeada = new ADODB.Recordset();
							rsCtaMapeada.Open(strSql, VBSQL.gConn[9], ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, -1);
							
							if (! rsCtaMapeada.EOF)
							{
								//La cuenta está mapeada
								//UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
								mdlParametros.tgCambioS111.NumCuentaS = Convert.ToString(MdlCambioMasivo.Nvl(rsCtaMapeada.Fields["map_cta_citi"].Value , "0"));
							} else
							{
								//La cuenta no esta mapeada
								mdlParametros.tgCambioS111.NumCuentaS = value;
							}
							rsCtaMapeada.Close();
							rsCtaMapeada = null;
							
							strNoCuenta = mdlParametros.tgCambioS111.NumCuentaS;
							VBSQL.gConn[9].Close();
						}
					}
				catch 
				{	
					if (rsCtaMapeada.State != 0)
					{
						rsCtaMapeada.Close();
					}
					if (VBSQL.gConn[9].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
					{
						VBSQL.gConn[9].Close();
					}
				}
			}
		}	
		
		public int ValorModificar
		{
			get
			{
				return dblValorEnviar;
			}
			set
			{
				dblValorEnviar = value;
				clsDialogo.enuTipoDialogo intIdTrans = this.get_IdTransaccion(intNoCambioActual);
				switch(intIdTrans)
				{
					case clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111 : 
						mdlParametros.tgCambioS111.PorcentajeDispI = value; 
						break;
					case clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111 : 
						mdlParametros.tgCambioS111.PinPlaI = value; 
						break;
					case clsDialogo.enuTipoDialogo.tCambioTipoBloqueoEjecutivoS111 : 
						mdlParametros.tgCambioS111.BloqueoI = value; 
						 
						break;
					case clsDialogo.enuTipoDialogo.tCambioSkipEjecutivoS111 : 
						mdlParametros.tgCambioS111.SkipPaymentI = value; 
						 
						break;
					case clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111 : 
						mdlParametros.tgCambioS111.MccL = value; 
						 
						break;
				}
			}
		}
		
		
		public string get_Descripcion( int indice)
		{
			return ArrCambioMasivo[indice].Descripcion;
		}
		
		public clsDialogo.enuTipoDialogo get_IdTransaccion( int indice)
		{
			return ArrCambioMasivo[indice].IdTipo;
		}
		
		public string get_DlgTransaccion( int indice)
		{
			return ArrCambioMasivo[indice].DlgTipoTransaccion;
		}
		public int ValorMaximo
		{
			get
			{
				return ArrCambioMasivo[intNoCambioActual].ValorFinal;
			}
		}
		
		
		public clsCambiosMasivos(){
			Collection colValores = null;
			//Genera los valores Iniciales y de parametrización de la clase
			
			
			ArrCambioMasivo[0].IdTipo = clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111;
			ArrCambioMasivo[0].Descripcion = "Generación de Pin y Plastico";
			ArrCambioMasivo[0].ValorInicial = 0;
			ArrCambioMasivo[0].ValorFinal = 2;
			ArrCambioMasivo[0].ConstDialogo = "5368";
			ArrCambioMasivo[0].DlgTipoTransaccion = MdlCambioMasivo.TRANS_PIN_PLASTICO;
			ArrCambioMasivo[0].BlAplicaEmpresa = false;
			
			
			ArrCambioMasivo[1].IdTipo = clsDialogo.enuTipoDialogo.tCambioSkipEjecutivoS111;
			ArrCambioMasivo[1].Descripcion = "Skyp Payment";
			ArrCambioMasivo[1].ValorInicial = 0;
			ArrCambioMasivo[1].ValorFinal = 1;
			ArrCambioMasivo[1].ConstDialogo = "5368";
			ArrCambioMasivo[1].DlgTipoTransaccion = MdlCambioMasivo.TRANS_SKIP_PAYMENT;
			ArrCambioMasivo[1].BlAplicaEmpresa = true;
			
			ArrCambioMasivo[2].IdTipo = clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111;
			ArrCambioMasivo[2].Descripcion = "Porcentaje de Disposicion";
			ArrCambioMasivo[2].ValorInicial = 0;
			ArrCambioMasivo[2].ValorFinal = 100;
			ArrCambioMasivo[2].ConstDialogo = "5368";
			ArrCambioMasivo[2].DlgTipoTransaccion = MdlCambioMasivo.TRANS_PORC_DISP;
			ArrCambioMasivo[2].BlAplicaEmpresa = false;
			
			ArrCambioMasivo[3].IdTipo = clsDialogo.enuTipoDialogo.tCambioTipoBloqueoEjecutivoS111;
			ArrCambioMasivo[3].Descripcion = "Tipo de Bloqueo";
			ArrCambioMasivo[3].ValorInicial = 0;
			ArrCambioMasivo[3].ValorFinal = 2;
			ArrCambioMasivo[3].ConstDialogo = "5368";
			ArrCambioMasivo[3].DlgTipoTransaccion = MdlCambioMasivo.TRANS_TIPO_BLOQUEO;
			ArrCambioMasivo[3].BlAplicaEmpresa = false;
			ArrCambioMasivo[4].IdTipo = clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111;
			ArrCambioMasivo[4].Descripcion = "Tabla MCC/Número de Negocio";
			ArrCambioMasivo[4].ValorInicial = 0;
			ArrCambioMasivo[4].ValorFinal = 9999;
			ArrCambioMasivo[4].ConstDialogo = "5368";
			ArrCambioMasivo[4].DlgTipoTransaccion = MdlCambioMasivo.TRANS_CAMBIO_TABLAMCC;
			ArrCambioMasivo[4].BlAplicaEmpresa = false;
			this.indice = -1;
			
		}
	public int fnCount()
	{
			return ArrCambioMasivo.GetUpperBound(0);
	}
    public bool fnEnviarDialogo(string sResp, N_ActualizaS111.ClsConectaS111 ObjConexionS111)
	{
			bool result = false;
			TransS111.EnumRespTransaccion enEstadoTransS111 = (TransS111.EnumRespTransaccion) 0;
			
			//    Dim sResp As String
			int iCodigoError = 0;
			string sRespError = String.Empty;
			int intIntentos = 0;
			int iTimeout = 5000;
			//sEnvio = strDialogo111
			//Para aplicar el valor correspondiente al dialogo
			//el procedimiento valida que la propiedad Indice Exista.
			
			if (this.indice == -1)
			{
				MessageBox.Show("Error: No ha elegido un Tipo de dialogo correcto", "Tarjeta Corporativa.- ClsCambiosMasivos:FnEnviarDialogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return result;
			}
			
			DlgDialogoS111.prGeneraDlg(this, this.get_IdTransaccion(this.indice)); //Metodo para generar el dialogo solicitado
			string sEnvio = DlgDialogoS111.DialogoS; //Lee el resultado del dialogo a procesar
			
			ObjConexionS111.StrIdTransaccion = DlgDialogoS111.mIdTransaccionS;
			ObjConexionS111.StrNoCuenta = DlgDialogoS111.mNumCuentaS;
			ObjConexionS111.StrParametrosAdicionales = DlgDialogoS111.DialogoS;
            //ObjConexionS111.LeyendaS = String.Empty;
            //ObjConexionS111.NombreS = mdlSeguridad.Stdl_ope_id;
            //ObjConexionS111.NominaS = mdlSeguridad.Stdl_ope_id;
        
            //AIS-1119 NGONZALEZ
            String tempString = String.Empty;

               var ResultaCmdrv = ObjConexionS111.FnEnviarTransaccion(tempString, tempString, tempString);


            switch ((TransS111.EnumRespTransaccion)ResultaCmdrv)
            {

                case TransS111.EnumRespTransaccion.EnRespTransaccionAceptada:
                case TransS111.EnumRespTransaccion.EnRespDesconocida:
                    return true;
                default:
                    return false;

            }


          
	}

	public string EnviaMensajeSM( string StrCadena, ref  int iResult, ref  string sCausaError)
	{
			
			// Primero debe limpiar el buffer de mensajes previos, Si hay un error diferente de TimeOut, detiene el proceso y regresa.
			string result = String.Empty;
			int i = 0;
			string sBloque = String.Empty;
			int iLongitudMsg = 0;
			string sRespuestaTmp = String.Empty;
			int intResultado = 0;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					bool bContinue = true;
					string sCadenaRespuesta = "";
					if ( ~ValorValido() != 0)
					{
						//El valor que se está enviando desde el dialogo está fuerá del rango indicado por la clase
						sCadenaRespuesta = "Valor Proporcionado Invalido";
						intResultado = 1;
					} else
					{
						intResultado = 0;
					}
					
					if (intResultado == 0)
					{
						StrCadena = StrCadena + Strings.Chr(3).ToString();
						mdlSeguridad.objSeguridad.SendRequest(StringsHelper.StrConv(StrCadena, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short) StrCadena.Length);
						if (Information.Err().Number != 0)
						{
							intResultado = Information.Err().Number;
							sCausaError = Information.Err().Description;
						} else
						{
							Information.Err().Clear();
							bContinue = true;
							i = 0;
							sRespuestaTmp = "";
							iLongitudMsg = 10000;
							do 
							{
								sBloque = "";
								sBloque = StringsHelper.StrConv(mdlSeguridad.objSeguridad.ReceiveResponse(30000), StringsHelper.VbStrConvEnum.vbUnicode, 0);
								// Si se recibe un bloque de 13 caracteres de longitud, se asume que es una cadena Chr(13) & Chr(10) & Chr(3)
								// no la cadena esperada. Por lo tanto, continuará con la recepción.
								if (Strings.Mid(sBloque, 1, 1) == "H" && sBloque.Length != 13)
								{
									sRespuestaTmp = "";
									iLongitudMsg = Convert.ToInt32(Conversion.Val(Strings.Mid(sBloque, 3, 4)));
									i = 0;
								}
								sRespuestaTmp = sRespuestaTmp + sBloque;
								//Validar que siempre en la primer transaccion manda un "confiramado " repita transaccion
								
								if (Information.Err().Number != 0)
								{
									intResultado = Information.Err().Number;
									sCausaError = Information.Err().Description;
									bContinue = false;
								}
								Information.Err().Clear();
								i++;
							}
							while(bContinue && iLongitudMsg > sRespuestaTmp.Length); //continuará mientras no haya un error y no se haya
							// recibido la cadena completa.
							sCadenaRespuesta = Strings.Mid(sRespuestaTmp, 11);
							if (intResultado == 0)
							{
								intResultado = sRespuestaTmp.Length;
							}
						}
					}
					iResult = intResultado;
					result = sCadenaRespuesta;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			return result;
	}
	public int ValorValido()
	{
			return (ArrCambioMasivo[intNoCambioActual].ValorInicial <= dblValorEnviar && ArrCambioMasivo[intNoCambioActual].ValorFinal >= dblValorEnviar) ? -1: 0;
	}
	
	~clsCambiosMasivos(){
		DlgDialogoS111 = null;
	}
}
}