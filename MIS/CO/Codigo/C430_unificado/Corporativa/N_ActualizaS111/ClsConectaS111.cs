//using Artinsoft.Silverlight.Client.Compatibility;
using Microsoft.VisualBasic;
using System;

//using VB6 = Artinsoft.Silverlight.Client.Utils.Support;

namespace N_ActualizaS111
{
    //using Artinsoft.Silverlight.Client.Form;
    //using Artinsoft.Silverlight.Client.UI;
	public class ClsConectaS111
	{

		//

		//



		//##ModelId=4051EBE00071
		private const string ERRMSG = " Método:";
		//##ModelId=4051EBE000E0
		private const int CTEERRORCANCEL = -500;
		//##ModelId=4051EBE00162
		private const string MSGERRORCANCEL = "Proceso Cancelado por el Usuario";
		public enum EnuDialogo
		{
			EnActualizaDir = 1 ,
			EnActualizaLimiteCredito = 2 ,
			EnActualizaMcc = 3
		}
		//##ModelId=4051EBE001EE
        //private FrmFirmaS111 objFrmFirma = null;
		//##ModelId=4051EBE0027C
		//UPGRADE_ISSUE: (2068) ClsSeguridad object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx
		private N_TransS111.ClsSeguridad objSeguridad = null;
		//##ModelId=4051EBE00298
		//UPGRADE_ISSUE: (2068) ClsConsulta object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx
        private N_TransS111.ClsConsulta objConsulta = null;
		//##ModelId=4051EBE002A2
		public string StrNoCuenta = String.Empty;
		public string StrIdTransaccion = String.Empty;
		public string StrParametrosAdicionales = String.Empty;
		private string StrUsuario = String.Empty;
		private bool BolEsChecker = false;

		private string msRespuesta = String.Empty;

		public string strUsuarioMaker = String.Empty;


		//##ModelId=4051EBE0034E
		//UPGRADE_ISSUE: (2068) EnumEstadosFirma object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx
        public N_TransS111.ClsSeguridad.EnumEstadosFirma EnCausaErrorFirma = default(N_TransS111.ClsSeguridad.EnumEstadosFirma);
        //##ModelId=4051EBE0036B
        //public Artinsoft.Silverlight.Data.Connection objConnDb = null;
        //##ModelId=4051EFB6027C
		public ClsConectaS111()
		{
#if DebugMode

			//UPGRADE_TODO: (1035) #If #EndIf block was not upgraded because the expression DebugMode did not evaluate to True or was not evaluated. More Information: http://www.vbtonet.com/ewis/ewi1035.aspx
			'get the next available class ID, and print out
			'that the class was created successfully
			mlClassDebugID = GetNextClassDebugID()
			Debug.Print "'" & TypeName(Me) & "' instance " & CStr(mlClassDebugID) & " created"
#endif
			BolEsChecker = false; //El usuario es maker
			strUsuarioMaker = ""; //Maker no está definido

		}
        //##ModelId=4051EBE00375
        //public bool FnPreguntaPwd()
        //{
        //    bool result = false;
        //    object EnFirmaAceptada = null;
        //    TransS111.ClsSeguridad.EnumTipoFirma EnFirmaConModulos = TransS111.ClsSeguridad.EnumTipoFirma.EnFirmaConModulos;
        //    object EnPasswordInvalido = null;
        //    object EnUsuarioInvalido = null;
        //    const int MaxReintentos = 3;
        //    string strError = String.Empty;
        //    int lngError = 0;
        //    bool bolReintentar = false;
        //    int IntReintentos = 0;
        //    try
        //    {
        //        UIAccessExtensions.DoUI(() => 
        //        {
        //            objSeguridad = new TransS111.ClsSeguridad();
        //            objConsulta = new TransS111.ClsConsulta();
        //            //UPGRADE_WARNING: (1068) objSeguridad of type ClsSeguridad is being forced to Scalar. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
        //            //UPGRADE_TODO: (1067) Member ConexionSeguridad is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
        //            objConsulta.ConexionSeguridad = objSeguridad;
        //            objFrmFirma = new FrmFirmaS111();
        //        }
        //        );
        //        IntReintentos = 0;
        //        do
        //        {
        //            IntReintentos++;
        //            UIAccessExtensions.DoUI(() => 
        //            {
        //                ((System.Windows.FrameworkElement)System.Windows.Application.Current.RootVisual).Cursor = System.Windows.Input.Cursors.Arrow;
        //                if (BolEsChecker && strUsuarioMaker.Trim() == "")
        //                {
        //                //Cuando el Usuario es Cheker Then
        //                //Usuario que hace el maker es obligatorio
        //                //UPGRADE_WARNING: (1037) Couldn't resolve default property of object EnCausaErrorFirma. More Information: http://www.vbtonet.com/ewis/ewi1037.aspx
        //                //UPGRADE_WARNING: (1068) EnUsuarioInvalido of type Variant is being forced to EnumEstadosFirma. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
        //                EnCausaErrorFirma = TransS111.ClsSeguridad.EnumEstadosFirma.EnUsuarioInvalido;
        //                MdlError.RaiseError(-11, this.GetType().Name, "El usuario maker no se ha definido");
        //                }
        //                objFrmFirma.TxtUsuario.SetText(StrUsuario);
        //                objFrmFirma.TxtUsuario.IsEnabled = StrUsuario.Trim() == "";
        //            }
        //            );
        //            //UPGRADE_WARNING: (7009) Multiple invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions More Information: http://www.vbtonet.com/ewis/ewi7009.aspx
        //            objFrmFirma.ShowModal();
        //            UIAccessExtensions.DoUI(() => 
        //            {
        //                ((System.Windows.FrameworkElement)System.Windows.Application.Current.RootVisual).Cursor = System.Windows.Input.Cursors.Wait;
        //                if (objFrmFirma.mEstadoFirma)
        //                {
        //                    //Enviará el Dialogo al S111 para firmarse
        //                    //UPGRADE_TODO: (1067) Member Usuario is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
        //                    objSeguridad.Usuario = objFrmFirma.TxtUsuario.GetText();
        //                    //UPGRADE_TODO: (1067) Member Password is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
        //                    objSeguridad.Password = objFrmFirma.TxtPwd.GetText();
        //                    //UPGRADE_TODO: (1067) Member Token is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
        //                    objSeguridad.Token = objFrmFirma.TxtToken.GetText();
        //                    //UPGRADE_TODO: (1067) Member TipoFirma is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
        //                    //UPGRADE_WARNING: (1068) EnFirmaConModulos of type Variant is being forced to Scalar. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
        //                    objSeguridad.TipoFirma = EnFirmaConModulos;
        //                    //El usuario de maker no puede ser el mismo que el cheker
        //                    //UPGRADE_TODO: (1067) Member Usuario is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
        //                    if (!(BolEsChecker && System.Convert.ToString(objSeguridad.Usuario) == strUsuarioMaker.Trim())){
        //                        //El usuario proporcionado no puede ser aceptado
        //                        //ya que está siendo utilizado para hacer el chequer
        //                        //UPGRADE_TODO: (1067) Member fncFirmaS041B is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
        //                        if ( ~System.Convert.ToInt32(objSeguridad.fncFirmaS041B(ref EnCausaErrorFirma)) != 0){
        //                            if (EnCausaErrorFirma == TransS111.ClsSeguridad.EnumEstadosFirma.EnPasswordInvalido){
        //                                if (IntReintentos <= MaxReintentos)
        //                                {
        //                                    bolReintentar = System.Windows.MessageBox.Show("Password Invalido ¿ Desea Reintentar la operación ? ",this.GetType().Name,System.Windows.MessageBoxButton.OKCancel) == System.Windows.MessageBoxResult.OK;
        //                                    if (!bolReintentar)
        //                                    {
        //                                        MdlError.RaiseError(-10, this.GetType().Name, "Proceso cancelado por el usuario");
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    //MsgBox "Ha Superado el Número de Reintentos de firma", TypeName(Me) + vbCritical
        //                                    bolReintentar = false;
        //                                    MdlError.RaiseError(-20, this.GetType().Name, "Ha Superado el Número de Reintentos de firma");
        //                                }
        //                            }
        //                            else
        //                            {
        //                                bolReintentar = false;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            bolReintentar = false;
        //                        }
        //                    }
        //                    else
        //                    {
        //                    //UPGRADE_WARNING: (1037) Couldn't resolve default property of object EnCausaErrorFirma. More Information: http://www.vbtonet.com/ewis/ewi1037.aspx
        //                    //UPGRADE_WARNING: (1068) EnUsuarioInvalido of type Variant is being forced to EnumEstadosFirma. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
        //                    EnCausaErrorFirma = TransS111.ClsSeguridad.EnumEstadosFirma.EnUsuarioInvalido;
        //                    bolReintentar = false;
        //                    MdlError.RaiseError(-20, this.GetType().Name, "El usuario es invalido para enviar transacciones al S111");
        //                    }
        //                }
        //                else
        //                {
        //                    result = false;
        //                    throw new System.Exception(CTEERRORCANCEL.ToString() + ", " + String.Empty + ", " + MSGERRORCANCEL);


        //                }
        //            }
        //            );
                	
        //        }
        //        while((bolReintentar));
        //        UIAccessExtensions.DoUI(() => objFrmFirma.Close());
        //        objFrmFirma = null;
        //        return EnCausaErrorFirma == TransS111.ClsSeguridad.EnumEstadosFirma.EnFirmaAceptada;
                
        //    }
        //    catch (System.Exception excep)
        //    {
        //        //UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
        //        lngError = Information.Err().Number;
        //        strError = excep.Message;
        //        result = false;
        //        //Set objSeguridad = Nothing 'Paso un Error mientras se firmaba
        //        objConsulta = null; //por lo tanto libera los objetos creados
        		
        //        UIAccessExtensions.DoUI(() => 
        //        {
        //            if (objFrmFirma != null)
        //            {
        //                objFrmFirma.Close();
        //                objFrmFirma = null;
        //            }
        //        }
        //        );
        //        MdlError.RaiseError(lngError, this.GetType().Name + ERRMSG + "FnPreguntaPwd", strError);
        //        return result;
        		
        //    }
        	
        	
        //}
        //##ModelId=4051EBE003D9
		~ClsConectaS111()
		{
            //Artinsoft.Silverlight.Client.Compatibility.ErrorHandlingHelper.ResumeNext(
            //    () => {FnDesconectarS111();},
            //    () => {objFrmFirma = null;},
            //    () => {objConsulta = null;});

           FnDesconectarS111();
           //objFrmFirma = null;
		   objConsulta = null;

			objSeguridad = null;
		}
        //Public Property Get NoCuenta() As String
		//    Dim lsSql As String
		//    On Error GoTo Handler
		//    'Objetivo: Validar si la cuenta asignada
		//    '          al Sistema esta mapeada o no y entonces devuelve
		//    '          la cuenta mapeada.
		//    Dim RsCuenta As ADODB.Recordset
		//    lsSql = "Select map_cta_city from MTCMAP01 Where map_cta_bnx='" & mStrNoCuenta & "' and rtrim(ltrim(map_status)) is null"
		//    Set RsCuenta = New ADODB.Recordset
		//    RsCuenta.Open lsSql, objConnDb
		//    If RsCuenta.BOF And RsCuenta.EOF Then
		//        NoCuenta = mNoCuenta
		//    Else
		//        NoCuenta = RsCuenta!map_cta_bnx
		//    End If
		//    RsCuenta.Close
		//    Set RsCuenta = Nothing
		//Handler:
		//    RaiseError Err, TypeName(Me) & "Propiedad: Get_NoCuenta", Error
		//End Property


		//'##ModelId=
		//Public Property Let NoCuenta(pStrNoCuenta As String)
		//    mStrNoCuenta = pStrNoCuenta
		//End Property
		//

		//##ModelId=4051EBE10073

        public N_TransS111.ClsTransaccion.EnumRespTransaccion FnEnviarTransaccion(String pStrIdTransaccion, String pStrCuenta, String pStrValoresAdicionales)
		{
            objConsulta = new N_TransS111.ClsConsulta();
			//UPGRADE_ISSUE: (2068) EnumRespTransaccion object was not upgraded. More Information: http://www.vbtonet.com/ewis/ewi2068.aspx
            N_TransS111.ClsTransaccion.EnumRespTransaccion result = default(N_TransS111.ClsTransaccion.EnumRespTransaccion);
            N_TransS111.ClsTransaccion.EnumRespTransaccion EnRespError = default(N_TransS111.ClsTransaccion.EnumRespTransaccion);
			//Objetivo: Enviar una transaccion al S111
			//          Dado los parametros opcionales de Identidicador de la transaccion, Numero de Cuena y pStrValoresAdicionales

			try
			{
				string mStrIdTransaccion = String.Empty;
				string mStrNumCuenta = String.Empty;
				string mStrParametrosAdicionales = String.Empty;
				// ********* Veriifca la entrada de parametros opcionales **********
				if (false || pStrIdTransaccion == "")
				{
					mStrIdTransaccion = StrIdTransaccion; //Leerá el valor asignado a la propiedad
				}
				else
				{
					mStrIdTransaccion = pStrIdTransaccion; //Leera el valor asignado al parametro
				}

				if (false || pStrCuenta == "")
				{
					mStrNumCuenta = StrNoCuenta;
				}
				else
				{
					mStrNumCuenta = pStrCuenta;
				}

				if (false || pStrValoresAdicionales == "")
				{
					mStrParametrosAdicionales = StrParametrosAdicionales;

				}
				else
				{
					mStrParametrosAdicionales = pStrValoresAdicionales;
				}
				//UPGRADE_TODO: (1067) Member prIdTransaccion is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				objConsulta.prIdTransaccion(mStrIdTransaccion);
				//UPGRADE_TODO: (1067) Member Enviar is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				objConsulta.Enviar(mStrNumCuenta, ref mStrParametrosAdicionales);
				//UPGRADE_TODO: (1067) Member Estado is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				result = objConsulta.Estado;
				//UPGRADE_TODO: (1067) Member RespuestaTransS111 is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				msRespuesta = System.Convert.ToString(objConsulta.RespuestaTransS111);
            	return result;
            }
            catch (System.Exception excep)
			{
				result = EnRespError;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: http://www.vbtonet.com/ewis/ewi2081.aspx
				MdlError.RaiseError(Information.Err().Number, this.GetType().Name + ERRMSG + "FnEnviarTransaccion", excep.Message);
				return result;
			}
        }
        public N_TransS111.ClsTransaccion.EnumRespTransaccion FnEnviarTransaccion(string pStrIdTransaccion, string pStrCuenta)
		{
			return FnEnviarTransaccion(pStrIdTransaccion, pStrCuenta, String.Empty);
		}
        public N_TransS111.ClsTransaccion.EnumRespTransaccion FnEnviarTransaccion(string pStrIdTransaccion)
		{
			return FnEnviarTransaccion(pStrIdTransaccion, String.Empty, String.Empty);
		}
        public N_TransS111.ClsTransaccion.EnumRespTransaccion FnEnviarTransaccion()
		{
			return FnEnviarTransaccion(String.Empty, String.Empty, String.Empty);
		}
        public bool FnDesconectarS111()
		{
        	N_TransS111.ClsSeguridad.EnumTipoFirma EnDesFirma = N_TransS111.ClsSeguridad.EnumTipoFirma.EnDesFirma;
        	//UPGRADE_TODO: (1067) Member TipoFirma is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			//UPGRADE_WARNING: (1068) EnDesFirma of type Variant is being forced to Scalar. More Information: http://www.vbtonet.com/ewis/ewi1068.aspx
			//objSeguridad.TipoFirma = EnDesFirma;
        	//UPGRADE_TODO: (1067) Member fncFirmaS041B is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
			//objSeguridad.fncFirmaS041B();
        	return false;
        }
        public string get_Msgerror(ref bool pBolDescCorta)
        {
            return GetMsgerror(ref pBolDescCorta);
        }
        public string GetMsgerror(ref bool pBolDescCorta)
		{
			string result = String.Empty;
			// pBolDescCorta : Indica si el mensaje de error es descripcion corta el valor por defecto es falso
			if (false)
			{
				pBolDescCorta = false;
			}
			string strMsgError = String.Empty;
			//UPGRADE_TODO: (1067) Member Estado is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
            if (objConsulta.Estado == N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespDesconocida || objConsulta.Estado == N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespError || objConsulta.Estado == N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespOperacionNegada)
			{
				//UPGRADE_TODO: (1067) Member RespuestaTransS111 is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				strMsgError = System.Convert.ToString(objConsulta.RespuestaTransS111);
            }
            else if (objConsulta.Estado == N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespSinRespuesta)
			{
				strMsgError = "Sin Respuesta";
			}
            else if (objConsulta.Estado == N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespTerminalSinFirmar)
			{
				strMsgError = "La terminal no está firmada";
			}
            else if (objConsulta.Estado == N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespTransaccionAceptada)
			{
				strMsgError = "Transacción Aceptada";
			}
            else if (objConsulta.Estado == N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespDarseAlta)
			{
				strMsgError = "Darse de alta nuevamente en el S111";
			}
			else if (objConsulta.Estado == N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespConfirmar)
			{
				strMsgError = "Debe Confirmar La Transacción en el S111";
			}
			else
			{
				//UPGRADE_TODO: (1067) Member RespuestaTransS111 is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				strMsgError = System.Convert.ToString(objConsulta.RespuestaTransS111);
            }
            //UPGRADE_TODO: (1067) Member Estado is not defined in type ClsConsulta. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
            if (objConsulta.Estado != N_TransS111.ClsTransaccion.EnumRespTransaccion.EnRespTransaccionAceptada)
			{
				if (!pBolDescCorta)
				{
					result = "La transacción en el S111 no fue aceptada" + System.Environment.NewLine + "Por la siguiente causa:" + System.Environment.NewLine + strMsgError;
				}
				else
				{
					result = strMsgError;
				}
			}
            return result;
        }
        public string GetMsgerror()
		{
			bool tempRefParam = false;
			return GetMsgerror(ref tempRefParam);
		}
        public bool PrCheker
		{
			set
			{
				// BolEsChecker = pBolEsCheker
				BolEsChecker = value;
			}
		}
        public string Usuario
		{
			set
			{
				StrUsuario = value;
			}
		}
        //*:***************************************************************
		//*: MRG EISSA 2004-12-20
		public string NominaS
		{
			get
			{
				//UPGRADE_TODO: (1067) Member Usuario is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				return System.Convert.ToString(objSeguridad.Usuario);
        	}
        }
        public string NombreS
		{
			get
			{
				//UPGRADE_TODO: (1067) Member NombreS is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				return System.Convert.ToString(objSeguridad.NombreS);
        	}
        }
        public string LeyendaS
		{
			get
			{
				//UPGRADE_TODO: (1067) Member LeyendaS is not defined in type ClsSeguridad. More Information: http://www.vbtonet.com/ewis/ewi1067.aspx
				return System.Convert.ToString(objSeguridad.LeyendaS);
        	}
        }
        public string RespuestaS
		{
			get
			{
				return msRespuesta;
			}
		}
        public void set_Usuario(ref string p)
        {
            throw new NotImplementedException();
        }
	//*: Fin: MRG EISSA 2004-12-20
	//*:***************************************************************
	}
}