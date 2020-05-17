using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.IO; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Runtime.InteropServices;

namespace TCd430
{
	internal class clsAltaEmpresa
	{
	
		
		
		//*****************************************************************************
		//**                                                                         **
		//**                     EISSA / Banamex - Sistemas                          **
		//**                                                                         **
		//**       -----------------------------------------------------------       **
		//**                                                                         **
		//**       Descripción:  Lleva el control de los Estados dentro de           **
		//**                     la alta de los Ejecutivos                           **
		//**                                                                         **
		//**                                                                         **
		//**                                                                         **
		//**       Responsables: Marcos Garcia Cruz                                  **
		//**                                                                         **
		//**       Fecha de Modificación:  9 de Octubre del 2003                     **
		//**                                                                         **
		//**             NOTA: Esta clase esta hecha en Visual Basic 6.0             **
		//**                                                                         **
		//*****************************************************************************
		
		
		CRSDialogo.DatosDialogo gdteEmpresa = CRSDialogo.DatosDialogo.CreateInstance();
		clsCliente lcteCliente = null;
		string smTablaTemporal = String.Empty;
		
		//Variable para el dialogo
		clsDialogo gdlgDialogoS016 = null;
		clsDialogo gdlgDialogoS111 = null;
		//Variables para las conexiones
	    /*	private OLERut.Conexion _cnxConexionRut = null;
		    OLERut.Conexion cnxConexionRut
		    {
			    get
			    {
				    if (_cnxConexionRut == null)
				    {
					    _cnxConexionRut = new OLERut.Conexion();
				    }
				    return _cnxConexionRut;
			    }
			    set
			    {
				    _cnxConexionRut = value;
			    }
		    }*/
        [DllImport("RUT.dll")]
        public extern static int RUT_Connect(string pcHostName, string pcService, bool bVal);
        [DllImport("RUT.dll")]
        public extern static int RUT_Disconnect(bool bVal);
        [DllImport("RUT.dll")]
        public extern static int RUT_WriteRead(string pcServerName, string pcRequest, ushort uRequestSize, [MarshalAs(UnmanagedType.VBByRefStr)] ref string pcReply, [MarshalAs(UnmanagedType.U2)] ref ushort puReplySize, bool bDisplayError);
	
		//Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
		clsDatosEmpresa gdteEmpExists = null;
		string slCuentaEjecutivo0 = String.Empty;
		int ilDigitoVer = 0;
		
		CRSDialogo.mtcEjecutivo mtcEjecutivo0 = CRSDialogo.mtcEjecutivo.CreateInstance();
		int hBufEmpresa = 0;
		int hBufconsec = 0;
		int iTempErr = 0;
		string pszConcBco = String.Empty;
		int iResp = 0;
		int iIncremento = 0;
		
		//'*********
		//
		string EmppszBanco = String.Empty;
		string EmppszConsecEmp = String.Empty;
		//
		//'Campos del catalogo
		string EmppszNumGrupo = String.Empty;
		string EmppszNomEmpresa = String.Empty;
		string EmppszNomCorto = String.Empty; //
		string EmppszRFC = String.Empty;
		string EmppszCartera = String.Empty;
		string EmppszSector = String.Empty;
		string EmppszAccionista = String.Empty;
		string EmppszSucursal = String.Empty;
		int EmppszCreditoGlobal = 0;
		string EmppszTelefono = String.Empty;
		string EmppszLada = String.Empty;
		string EmppszFax = String.Empty;
		string EmppszEmail = String.Empty;
		string EmppszInternet = String.Empty;
		string EmppszTonoPul = String.Empty;
		string EmppszFaxLada = String.Empty;
		string EmppszTelExt = String.Empty;
		//
		//'Domicilio Fiscal
		string EmppszCalleFis = String.Empty;
		string EmppszColoniaFis = String.Empty;
		string EmppszCiudadFis = String.Empty;
		string EmppszPoblacionFis = String.Empty;
		string EmppszEstadoFis = String.Empty;
		string EmppszCpFis = String.Empty;
		//
		//'Domicilio de envío
		string EmppszCalleEnv = String.Empty;
		string EmppszColoniaEnv = String.Empty;
		string EmppszCiudadEnv = String.Empty;
		string EmppszPoblacionEnv = String.Empty;
		string EmppszEstadoEnv = String.Empty;
		string EmppszCpEnv = String.Empty;
		string EmppszTipoPago = String.Empty;
		string EmppszTipoEnv = String.Empty;
		string EmppszCtaCaptacion = String.Empty;
		string EmppszNominaEjeBNX = String.Empty;
		string EmppszFecVenCred = String.Empty;
		int EmpilDiaCorte = 0;
		int EmpilPlazoGracia = 0;
		int EmpilPlazoNoCobro = 0;
		string EmpslTipoFactura = String.Empty;
		string EmpslEsquemaPago = String.Empty;
		string EmpslTipoProducto = String.Empty;
		int EmpllEstructuraGastos = 0;
		int EmpilMesFiscal = 0;
		int EmpilMontoPorciento = 0;
		double EmpdlFacturacionMinima = 0;
		string EmpslCuentaContable = String.Empty;
		int EmpilSkipPayment = 0;
		int EmpilTablaMCCCambio = 0;
		int EmpilTablaMCC = 0;
		string EmpslUsuarioCambio = String.Empty;
		
		string EmpmsNombreR1 = String.Empty;
		string EmpmsPuestoR1 = String.Empty;
		string EmpmsTelR1 = String.Empty;
		string EmpmsExtR1 = String.Empty;
		string EmpmsFaxR1 = String.Empty;
		string EmpmsNombreR2 = String.Empty;
		string EmpmsPuestoR2 = String.Empty;
		string EmpmsTelR2 = String.Empty;
		string EmpmsExtR2 = String.Empty;
		string EmpmsFaxR2 = String.Empty;
		string EmpmsNombreR3 = String.Empty;
		string EmpmsPuestoR3 = String.Empty;
		string EmpmsTelR3 = String.Empty;
		string EmpmsExtR3 = String.Empty;
		string EmpmsFaxR3 = String.Empty;
		int lNumEmpresa = 0;
		int lIncremento = 0;
		int EmpmskDiaCorte = 0;
		string EmpslNacionalidad = String.Empty;
		string EmpslIndCtaControl = String.Empty;
		int EmpimEmpTipoBloqueo = 0;
		int EmpimPrefijo = 0;
		int EmpimBanco = 0;
		CheckState EmpilGenArchivoCDF = (CheckState) 0;
		bool EmpbgblModFirma = false;
		string EmpsmblPathRepEmpresas = String.Empty;
		string EmpimAtencionA = String.Empty; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
		int EmppszPersona = 0;
		string EmppszAtencionA = String.Empty;
		int EmpimPersona = 0; //FSWB NR 20070223

        string EmppszSucTransmisora = String.Empty;
        string EmppszSucPromotora = String.Empty;

        public string pszSucTransmisora
        {
            set
            {
                EmppszSucTransmisora = value;
            }
        }

        public string pszSucPromotora
        {
            set
            {
                EmppszSucPromotora = value;
            }
        }
		
		public string pszBanco
		{
			set
			{
				EmppszBanco = value;
			}
		}
		
		//FSWB NR 20070226
		public string pszAtencionA
		{
			set
			{
				EmppszAtencionA = value;
			}
		}
		
		//FSWB NR 20070226
		public int pszPersona
		{
			set
			{
				EmppszPersona = value;
			}
		}
		
		public string pszNumGrupo
		{
			set
			{
				EmppszNumGrupo = value;
			}
		}
		
		public string pszNomEmpresa
		{
			set
			{
				EmppszNomEmpresa = value;
			}
		}
		
		public string pszNomCorto
		{
			set
			{
				EmppszNomCorto = value;
			}
		}
		
		public string pszRFC
		{
			set
			{
				EmppszRFC = value;
			}
		}
		
		public string pszCartera
		{
			set
			{
				EmppszCartera = value;
			}
		}
		
		public string pszSector
		{
			set
			{
				EmppszSector = value;
			}
		}
		
		public string pszAccionista
		{
			set
			{
				EmppszAccionista = value;
			}
		}
		
		public string pszSucursal
		{
			set
			{
				EmppszSucursal = value;
			}
		}
		
		public int pszCreditoGlobal
		{
			set
			{
				EmppszCreditoGlobal = value;
			}
		}
		
		public string pszTelefono
		{
			set
			{
				EmppszTelefono = value;
			}
		}
		
		public string pszLada
		{
			set
			{
				EmppszLada = value;
			}
		}
		
		public string pszFax
		{
			set
			{
				EmppszFax = value;
			}
		}
		
		public string pszEmail
		{
			set
			{
				EmppszEmail = value;
			}
		}
		
		public string pszInternet
		{
			set
			{
				EmppszInternet = value;
			}
		}
		
		public string pszTonoPul
		{
			set
			{
				EmppszTonoPul = value;
			}
		}
		
		public string pszFaxLada
		{
			set
			{
				EmppszFaxLada = value;
			}
		}
		
		public string pszTelExt
		{
			set
			{
				EmppszTelExt = value;
			}
		}
		
		public string pszCalleFis
		{
			set
			{
				EmppszCalleFis = value;
			}
		}
		
		public string pszColoniaFis
		{
			set
			{
				EmppszColoniaFis = value;
			}
		}
		
		public string pszCiudadFis
		{
			set
			{
				EmppszCiudadFis = value;
			}
		}
		
		public string pszPoblacionFis
		{
			set
			{
				EmppszPoblacionFis = value;
			}
		}
		
		public string pszEstadoFis
		{
			set
			{
				EmppszEstadoFis = value;
			}
		}
		
		public string pszCpFis
		{
			set
			{
				EmppszCpFis = value;
			}
		}
		
		public string pszCalleEnv
		{
			set
			{
				EmppszCalleEnv = value;
			}
		}
		
		public string pszColoniaEnv
		{
			set
			{
				EmppszColoniaEnv = value;
			}
		}
		
		public string pszCiudadEnv
		{
			set
			{
				EmppszCiudadEnv = value;
			}
		}
		
		public string pszPoblacionEnv
		{
			set
			{
				EmppszPoblacionEnv = value;
			}
		}
		
		public string pszEstadoEnv
		{
			set
			{
				EmppszEstadoEnv = value;
			}
		}
		
		public string pszCpEnv
		{
			set
			{
				EmppszCpEnv = value;
			}
		}
		
		public string pszTipoPago
		{
			set
			{
				EmppszTipoPago = value;
			}
		}
		
		public string pszTipoEnv
		{
			set
			{
				EmppszTipoEnv = value;
			}
		}
		
		public string pszCtaCaptacion
		{
			set
			{
				EmppszCtaCaptacion = value;
			}
		}
		
		public string pszNominaEjeBNX
		{
			set
			{
				EmppszNominaEjeBNX = value;
			}
		}
		
		public string pszFecVenCred
		{
			set
			{
				EmppszFecVenCred = value;
			}
		}
		
		public int ilDiaCorte
		{
			set
			{
				EmpilDiaCorte = value;
			}
		}
		
		public int ilPlazoGracia
		{
			set
			{
				EmpilPlazoGracia = value;
			}
		}
		
		public int ilPlazoNoCobro
		{
			set
			{
				EmpilPlazoNoCobro = value;
			}
		}
		
		public string slTipoFactura
		{
			set
			{
				EmpslTipoFactura = value;
			}
		}
		
		public string slEsquemaPago
		{
			set
			{
				EmpslEsquemaPago = value;
			}
		}
		
		public string slTipoProducto
		{
			set
			{
				EmpslTipoProducto = value;
			}
		}
		
		public int llEstructuraGastos
		{
			set
			{
				EmpllEstructuraGastos = value;
			}
		}
		
		public int ilMesFiscal
		{
			set
			{
				EmpilMesFiscal = value;
			}
		}
		
		public int ilMontoPorciento
		{
			set
			{
				EmpilMontoPorciento = value;
			}
		}
		
		public double dlFacturacionMinima
		{
			set
			{
				EmpdlFacturacionMinima = value;
			}
		}
		
		public string slCuentaContable
		{
			set
			{
				EmpslCuentaContable = value;
			}
		}
		
		public int ilSkipPayment
		{
			set
			{
				EmpilSkipPayment = value;
			}
		}
		
		public int ilTablaMCCCambio
		{
			set
			{
				EmpilTablaMCCCambio = value;
			}
		}
		
		public int ilTablaMCC
		{
			set
			{
				EmpilTablaMCC = value;
			}
		}
		
		public string slUsuarioCambio
		{
			set
			{
				EmpslUsuarioCambio = value;
			}
		}
		
		public string msNombreR1
		{
			set
			{
				EmpmsNombreR1 = value;
			}
		}
		
		public string msPuestoR1
		{
			set
			{
				EmpmsPuestoR1 = value;
			}
		}
		
		public string msTelR1
		{
			set
			{
				EmpmsTelR1 = value;
			}
		}
		
		public string msExtR1
		{
			set
			{
				EmpmsExtR1 = value;
			}
		}
		
		public string msFaxR1
		{
			set
			{
				EmpmsFaxR1 = value;
			}
		}
		
		public string msNombreR2
		{
			set
			{
				EmpmsNombreR2 = value;
			}
		}
		
		public string msPuestoR2
		{
			set
			{
				EmpmsPuestoR2 = value;
			}
		}
		
		public string msTelR2
		{
			set
			{
				EmpmsTelR2 = value;
			}
		}
		
		public string msExtR2
		{
			set
			{
				EmpmsExtR2 = value;
			}
		}
		
		public string msFaxR2
		{
			set
			{
				EmpmsFaxR2 = value;
			}
		}
		
		public string msNombreR3
		{
			set
			{
				EmpmsNombreR3 = value;
			}
		}
		
		public string msPuestoR3
		{
			set
			{
				EmpmsPuestoR3 = value;
			}
		}
		
		public string msTelR3
		{
			set
			{
				EmpmsTelR3 = value;
			}
		}
		
		public string msExtR3
		{
			set
			{
				EmpmsExtR3 = value;
			}
		}
		
		public string msFaxR3
		{
			set
			{
				EmpmsFaxR3 = value;
			}
		}
		
		public int mskDiaCorte
		{
			set
			{
				EmpmskDiaCorte = value;
			}
		}
		
		public string slNacionalidad
		{
			set
			{
				EmpslNacionalidad = value;
			}
		}
		
		public string slIndCtaControl
		{
			set
			{
				EmpslIndCtaControl = value;
			}
		}
		
		public string imEmpTipoBloqueo
		{
			set
			{
				EmpimEmpTipoBloqueo = Int32.Parse(value);
			}
		}
		
		public int imPrefijo
		{
			set
			{
				EmpimPrefijo = value;
			}
		}
		
		public int imBanco
		{
			set
			{
				EmpimBanco = value;
			}
		}
		
		public CheckState ilGenArchivoCDF
		{
			set
			{
				EmpilGenArchivoCDF = value;
			}
		}
		
		public bool bmblModFirma
		{
			set
			{
				EmpbgblModFirma = value;
			}
		}
		
		public string smblPathRepEmpresas
		{
			set
			{
				EmpsmblPathRepEmpresas = value;
			}
		}
	

        
        
        
        
        
        
        
        public int illIncremento
		{
			set
			{
				lIncremento = value;
			}
		}
		
		public int illDigitoVer
		{
			set
			{
				ilDigitoVer = value;
			}
		}
		
		//FSWB NR 20070223
		public string slAtencionA
		{
			set
			{
				EmpimAtencionA = value;
			}
		}
		
		//FSWB NR 20070223
		public int ilPersona
		{
			set
			{
				EmpimPersona = value;
			}
		}
		
		public clsCliente EmplcteCliente
		{
			set
			{
				lcteCliente = value;
			}
		}
		
		public string Temporal
		{
			set
			{
			}
		}

        public int illNumEmpresa
        {
            get
            {
                return lNumEmpresa;
            }
            set
            {
                lNumEmpresa = value;
            }
        }
	
		
		public bool fncObtenNumB()
		{
			
			//Obtiene el Consecutivo
			bool result = false;
			result = true;
            //CORVAR.pszgblsql = "select con_emp from MTCCON01";
            //CORVAR.pszgblsql = CORVAR.pszgblsql + " where con_pref = " + EmpimPrefijo.ToString().Trim();
            //CORVAR.pszgblsql = CORVAR.pszgblsql + " and con_banco = " + EmpimBanco.ToString().Trim();
            //if (CORPROC2.Obtiene_Registros() != 0)
            //{
            //    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
            //        {
					
            //            lNumEmpresa = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
            //        }
            //}
            //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            //if (lNumEmpresa <= 0)
            //{
            //    MessageBox.Show("Se ha generado un número de empresa no valida, por favor intentelo nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    result = false;
            //    Cursor.Current = Cursors.Default;
            //    return result;
            //}
            //lcteCliente.EmpresaL = StringsHelper.IntValue(StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)));
			
            //CORVAR.pszgblsql = "select pgs_incremento from MTCPGS01 holdlock ";
            //CORVAR.pszgblsql = CORVAR.pszgblsql + " where pgs_rep_prefijo = " + EmpimPrefijo.ToString().Trim();
            //CORVAR.pszgblsql = CORVAR.pszgblsql + " and pgs_rep_banco = " + EmpimBanco.ToString().Trim();
            //if (CORPROC2.Obtiene_Registros() != 0)
            //{
            //    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
            //        {
					
            //            lIncremento = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
            //        }
            //}
            //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            //if (lIncremento <= 0)
            //{
            //    MessageBox.Show("Se ha generado un número de empresa no valida, por favor intentelo nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    result = false;
            //    Cursor.Current = Cursors.Default;
            //    return result;
            //}
			slCuentaEjecutivo0 = StringsHelper.Format(EmpimPrefijo, "0000") + StringsHelper.Format(EmpimBanco, "00") + StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(0, Formato.sMascara(Formato.iTipo.Ejecutivo)) + "9";
			ilDigitoVer = CORPROC.Calcula_digito_verif(ref slCuentaEjecutivo0);
			slCuentaEjecutivo0 = slCuentaEjecutivo0 + ilDigitoVer.ToString();
			gdteEmpresa.sCuenta = slCuentaEjecutivo0;
			
			return result;
		}

		public string fncEnviaDialogoLocalPrimeraS(ref  string spRespuesta,  bool bpReAlta)
		{
			//Dim pszMensajeS111      As String
			string result = String.Empty;
			string slDialogo = String.Empty;
			int ilRespuestaEnvio = 0;
			string slRespMensaje = String.Empty;
			string slClaveResultadoTransaccion = String.Empty;
			string slClaveTransaccionAlta = String.Empty;
			string slRespuestaTransaccion = String.Empty;
			string slTextoError = String.Empty;
		
			try
			{
					CRSDialogo.Dialogo(ref slDialogo, gdteEmpresa, CRSDialogo.TipoAlta.cteAltaS111);
					
					//cnxConexionRut.Termina_Conexion();
                    RUT_Disconnect(false);
					//if (! cnxConexionRut.Inicia_Conexion())
                    int iresult = RUT_Connect(mdlParametros.sgEquipoUnix, mdlParametros.sgPuertoTandem, false);
                    if (iresult != 0)
					{
						MessageBox.Show("No hay conexion al S111. Avise a sistemas.", "Conexión S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
						Cursor.Current = Cursors.Default;
						return "ErrorConexion";
					}
					
					//NumArchivo = FreeFile()
					//Open App.Path & "\DialogoLocalPrimera.txt" For Append As #NumArchivo
					//Print #NumArchivo, "mensaje enviado:"
					//Print #NumArchivo, slDialogo
					mdlSeguridad.EnviaLog("Mensaje Enviado al RUT: " + "\r\n" + slDialogo);
                    FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje a enviar a Rut:" + "\r\n" + slDialogo);
					string tempRefParam = "S753-CONALTAS";
					//ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
                    ushort tamsal = 1654;
                    string slDialogSal = new String(' ', tamsal);
                    ilRespuestaEnvio = RUT_WriteRead(tempRefParam, slDialogo, (ushort)slDialogo.Length, ref slDialogSal, ref tamsal, false);
                    slDialogo = slDialogSal;	
				

					//Print #NumArchivo, "mensaje recibido:"
					//Print #NumArchivo, slDialogo
					//Close NumArchivo
					//
					mdlSeguridad.EnviaLog("Mensaje Recibido del RUT: " + "\r\n" + slDialogo);
                    FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje Recibido de Rut:" + "\r\n" + slDialogo);
					Application.DoEvents();
					//cnxConexionRut.Termina_Conexion();
                    RUT_Disconnect(false);
					slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");
					if (ilRespuestaEnvio != 0)
					{
						MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
						result = "ErrorConexion";
						spRespuesta = slRespMensaje;
						return result;
					}
					if (slRespMensaje.IndexOf("error on RUT") >= 0)
					{
						MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
						result = "ErrorRut";
						spRespuesta = slRespMensaje;
						return result;
					}
					slClaveResultadoTransaccion = Strings.Mid(slRespMensaje, 32, 2);
					slClaveTransaccionAlta = Strings.Mid(slRespMensaje, 34, 4);
					slRespuestaTransaccion = Strings.Mid(slRespMensaje, 38, 30);
					slTextoError = Strings.Mid(slRespMensaje, 68, 60).Trim();
					
					spRespuesta = slTextoError;
					if (lcteCliente.fncExtraerClienteL(slRespMensaje) != 0)
					{
						lcteCliente.ClienteL = lcteCliente.fncExtraerClienteL(slRespMensaje);
					}
					if (slClaveResultadoTransaccion == "00" || slClaveResultadoTransaccion == "02" || slClaveResultadoTransaccion == "05" || slClaveResultadoTransaccion == "06" || slClaveResultadoTransaccion == "35")
					{
						return slClaveResultadoTransaccion;
					}
					if (slClaveResultadoTransaccion == "07")
					{
						if (slTextoError.ToUpper().IndexOf("OK DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR TIMEOUT DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR COMUNICACION CON UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DATOS DE CALL DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO HAY DRIVERS EN DCRED") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN CSI-DESTINO") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN VALOR DE TIMEOUT") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 31 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 32 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 33 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DCRED EN CAMPO COMPUTER") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO CALIFICADO....") >= 0 || slTextoError.ToUpper().IndexOf("ERROR CODIGO RESPUESTA DESCONOCIDO") >= 0)
						{
							result = slClaveResultadoTransaccion + "error";
						} 
                        else
						{
							result = slClaveResultadoTransaccion + "errorx";
						}
						Cursor.Current = Cursors.Default;
						return result;
					}
				}
			catch 
			{
				
				result = "ErrorConexion";
				spRespuesta = "Error de Conexion";
			}
			return result;
		}

		public string fncEnviaDialogoLocalSegundaS(ref  string spRespuesta,  bool bpReAlta)
		{
			string result = String.Empty;
			string slDialogo = String.Empty;
			int ilRespuestaEnvio = 0;
			string slRespMensaje = String.Empty;
			string slClaveResultadoTransaccion = String.Empty;
			string slClaveTransaccionAlta = String.Empty;
			string slRespuestaTransaccion = String.Empty;
			string slTextoError = String.Empty;
			int NumArchivo = 0;
			
			try
			{
					CRSDialogo.Dialogo(ref slDialogo, gdteEmpresa, CRSDialogo.TipoAlta.cteAltaS016);
					
					//cnxConexionRut.Termina_Conexion();
                    RUT_Disconnect(false);
					//if (! cnxConexionRut.Inicia_Conexion())
                    int iresult = RUT_Connect(mdlParametros.sgEquipoUnix, mdlParametros.sgPuertoTandem, false);
                    if (iresult != 0)
					{
						MessageBox.Show("No hay conexion al S111. Avise a sistemas.", "Conexión S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
						Cursor.Current = Cursors.Default;
						return "ErrorConexion";
					}
					NumArchivo = FileSystem.FreeFile();
					//Open App.Path & "\DialogoLocalSegunda.txt" For Append As #NumArchivo
					//Print #NumArchivo, "mensaje enviado:"
					//Print #NumArchivo, slDialogo
					mdlSeguridad.EnviaLog("Mensaje Enviado al Rut: " + "\r\n" + slDialogo);
					
					string tempRefParam = "S753-CONALTAS";
                    ushort tamsal = 1654;
                    string slDialogSal = new String(' ', tamsal);
                    ilRespuestaEnvio = RUT_WriteRead(tempRefParam, slDialogo, (ushort)slDialogo.Length, ref slDialogSal, ref tamsal, false);
                    slDialogo = slDialogSal;
                    //ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
				
					Application.DoEvents();
					//cnxConexionRut.Termina_Conexion();
                    RUT_Disconnect(false);
					mdlSeguridad.EnviaLog("Mensaje Recibido del Rut: " + "\r\n" + slDialogo);
					
					slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");
					if (ilRespuestaEnvio != 0)
					{
						MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
						result = "ErrorConexion";
						spRespuesta = slRespMensaje;
						return result;
					}
					if (slRespMensaje.IndexOf("error on RUT") >= 0)
					{
						MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
						result = "ErrorRut";
						spRespuesta = slRespMensaje;
						return result;
					}
					slClaveResultadoTransaccion = Strings.Mid(slRespMensaje, 32, 2);
					slClaveTransaccionAlta = Strings.Mid(slRespMensaje, 34, 4);
					slRespuestaTransaccion = Strings.Mid(slRespMensaje, 38, 30);
					slTextoError = Strings.Mid(slRespMensaje, 68, 60).Trim();
					
					spRespuesta = slTextoError;
					if (lcteCliente.fncExtraerClienteL(slRespMensaje) != 0)
					{
						lcteCliente.ClienteL = lcteCliente.fncExtraerClienteL(slRespMensaje);
					}
					if (slClaveResultadoTransaccion == "00" || slClaveResultadoTransaccion == "02" || slClaveResultadoTransaccion == "05" || slClaveResultadoTransaccion == "06" || slClaveResultadoTransaccion == "35")
					{
						return slClaveResultadoTransaccion;
					}
					if (slClaveResultadoTransaccion == "07")
					{
						if (slTextoError.ToUpper().IndexOf("OK DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR TIMEOUT DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR COMUNICACION CON UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DATOS DE CALL DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO HAY DRIVERS EN DCRED") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN CSI-DESTINO") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN VALOR DE TIMEOUT") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 31 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 32 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 33 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DCRED EN CAMPO COMPUTER") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO CALIFICADO....") >= 0 || slTextoError.ToUpper().IndexOf("ERROR CODIGO RESPUESTA DESCONOCIDO") >= 0)
						{
							result = slClaveResultadoTransaccion + "error";
						} 
                        else
						{
							result = slClaveResultadoTransaccion + "errorx";
						}
						Cursor.Current = Cursors.Default;
						return result;
					}
				}
			catch 
			{
				
				MessageBox.Show("No hay conexion al S111. Avise a sistemas.", "Conexión S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Cursor.Current = Cursors.Default;
				result = "ErrorConexion";
			}
			return result;
		}
		private string fncPonComillasVaciasS( string spCampo)
		{
			string slCampo = spCampo.Trim();
			if (slCampo == "")
			{
				slCampo = "''";
			} 
            else
			{
				if (slCampo == "'")
				{
					slCampo = "''";
				} 
                else
				{
					if (! slCampo.StartsWith("'"))
					{
						slCampo = "'" + slCampo;
					}
					if (! slCampo.EndsWith("'"))
					{
						slCampo = slCampo + "'";
					}
				}
			}
			return slCampo;
		}
		public bool fncGrabaTablaRespB()
		{
			bool result = false;
			try
			{
					
					CORVAR.pszgblsql = " insert MTCINE02 (" + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo     , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco      , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num       , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_num       , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ejx_numero     , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom_graba    , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_rfc         , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num_cartera, " + "\r\n"; //float
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_princ_acc , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_sector    , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cred_tot   , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_acum_cred, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fec_venc_cred, " + "\r\n"; //smalldatetime
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_calle, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_col , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_ciu, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_pob, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_edo , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fiscal_cp, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_telefono     , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_extension   , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tel_lada   , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax       ,  " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax_lada , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_param_modem, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_vel_transmis, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_email        , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_internet    , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_calle, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_col ,  " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_ciu, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_pob  , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_edo, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_cp     , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cta_capt    , " + "\r\n"; //float
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_sucur      , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_pago , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_envio, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom_r1     , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_pues_r1, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tel_r1       , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_ext_r1      , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax_r1     , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fir_r1    , " + "\r\n"; //image
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom_r2    , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_pues_r2    , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tel_r2, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_ext_r2       , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax_r2      , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fir_r2     , " + "\r\n"; //image
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom_r3    , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_pues_r3   , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tel_r3     , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_ext_r3, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fax_r3       , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fir_r3      , " + "\r\n"; //image
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_con_eje    , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_dia_corte , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_plazo_gracia, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_plazo_no_cob, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_gen_SBF, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_fac     , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_esquema_pago, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_producto, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_estruct_gastos, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_mes_fiscal   , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_lim_dis_efec, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_min_factura, " + "\r\n"; //float
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cta_contable, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_skip_payment , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tabla_mcc   , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam    , " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fech_alta, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_fech_cam     , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_hora_cam    , " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_bloqueo, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_status_reg, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_gen_CDF, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_mskDiaCorte, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nacionalidad, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_digito_ver, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cuenta_ejecutivo0, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_bloqueo_eje, " + "\r\n"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_IndCtaControl, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_incremento, " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cliente_prefijol, " + "\r\n"; //long
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cliente_bancol, " + "\r\n"; //long
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cliente_empresal, " + "\r\n"; //long
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cliente_clientel, " + "\r\n"; //long
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_suc_prom, " + "\r\n"; //char
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_suc_tran " + "\r\n"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ) " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " values (        " + EmpimPrefijo.ToString() + "        , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmppszBanco + "    , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + lNumEmpresa.ToString().Trim() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmppszNumGrupo + ",   " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmppszNominaEjeBNX + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszNomEmpresa) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszNomCorto) + "  , " + "\r\n"; //dlgAlta.sNombreGrabacion & vbCrLf
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszRFC) + "    , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " 0.00, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszAccionista) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmppszSector + "  ,   " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + Conversion.Str(EmppszCreditoGlobal) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + Conversion.Str(0) + ", " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " getdate(), " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszCalleFis) + "    , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszColoniaFis) + " , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszCiudadFis) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszPoblacionFis) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszEstadoFis) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmppszCpFis + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszTelefono) + "    , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszTelExt) + "   , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszLada) + " , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszFax) + "     , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszFaxLada) + "  , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszTonoPul) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + Conversion.Str(0) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszEmail) + "   , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszInternet) + "    , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszCalleEnv) + "     , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszColoniaEnv) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszCiudadEnv) + "  , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszPoblacionEnv) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszEstadoEnv) + " ,  " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmppszCpEnv + "   , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmppszCtaCaptacion + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmppszSucursal + "   , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszTipoPago) + " , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszTipoEnv) + "    , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsNombreR1) + "             , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsPuestoR1) + "           , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsTelR1) + "        , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsExtR1) + "         , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsFaxR1) + "         , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " 0x0        , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsNombreR2) + "        , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsPuestoR2) + "       , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsTelR2) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsExtR2) + "        , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsFaxR2) + "         , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " 0x0         , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsNombreR3) + "        , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsPuestoR3) + "        , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsTelR3) + "       , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsExtR3) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpmsFaxR3) + "        , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " 0x0         , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " 1       , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpilDiaCorte.ToString() + "     , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpilPlazoGracia.ToString() + " , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpilPlazoNoCobro.ToString() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + "0" + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpslTipoFactura) + "   , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpslEsquemaPago) + "  , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpslTipoProducto) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpllEstructuraGastos.ToString() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpilMesFiscal.ToString() + "    , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpilMontoPorciento.ToString() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpdlFacturacionMinima.ToString() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpslCuentaContable) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpilSkipPayment.ToString() + "  , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpilTablaMCC.ToString() + "     , " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpslUsuarioCambio) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(int,convert(char(20), getdate(),112)), " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(int,convert(char(20), getdate(),112)), " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate())), " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpimEmpTipoBloqueo.ToString().Trim() + ", " + "\r\n"; //INGRESA EL TIPO DE BLOQUEO PUESTO EN LA PANTALLA
					CORVAR.pszgblsql = CORVAR.pszgblsql + " 0, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + ((int) EmpilGenArchivoCDF).ToString() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpmskDiaCorte.ToString().Trim() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + EmpslNacionalidad + "', " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + ilDigitoVer.ToString().Trim() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(slCuentaEjecutivo0) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + EmpimEmpTipoBloqueo.ToString().Trim() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmpslIndCtaControl) + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + lIncremento.ToString().Trim() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + lcteCliente.ProductoPRD.PrefijoL.ToString().Trim() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + lcteCliente.ProductoPRD.BancoL.ToString().Trim() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + lcteCliente.EmpresaL.ToString().Trim() + ", " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " " + lcteCliente.ClienteL.ToString().Trim() + ", " + "\r\n";

                    CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszSucPromotora) + ", " + "\r\n"; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " " + fncPonComillasVaciasS(EmppszSucTransmisora) + " " + "\r\n"; //FSWB NR 20070223
					
					CORVAR.pszgblsql = CORVAR.pszgblsql + ") " + "\r\n";
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
						result = true;
						Cursor.Current = Cursors.Default;
						
					} 
                    else
					{
						MessageBox.Show("No se pudo insertar el registro en la tabla de respaldo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						result = false;
						Cursor.Current = Cursors.Default;
						return result;
					}
					if (EmpbgblModFirma)
					{
						//····· Inicia el proceso de guardar las imagenes ·····
						IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR1_IMM, "MTCINE02", "emp_fir_r1", " eje_prefijo = " + EmpimPrefijo.ToString() + " and gpo_banco = " + EmppszBanco.ToString() + " AND emp_num = " + lNumEmpresa.ToString().Trim());
						IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR2_IMM, "MTCINE02", "emp_fir_r2", " eje_prefijo = " + EmpimPrefijo.ToString() + " and gpo_banco = " + EmppszBanco.ToString() + " AND emp_num = " + lNumEmpresa.ToString().Trim());
						IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR3_IMM, "MTCINE02", "emp_fir_r3", " eje_prefijo = " + EmpimPrefijo.ToString() + " and gpo_banco = " + EmppszBanco.ToString() + " AND emp_num = " + lNumEmpresa.ToString().Trim());
					}
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				result = false;
				Cursor.Current = Cursors.Default;
			}
			
			return result;
		}
		
		
		public bool fncActualizaConsecutivoB()
		{
			bool result = false;
			try
			{
					CORVAR.pszgblsql = "exec sp_ActualizaConsecutivoB " + lNumEmpresa.ToString() + "," + lIncremento.ToString() + "," + EmpimPrefijo.ToString() + "," + EmppszBanco;
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
						result = true;
						Cursor.Current = Cursors.Default;
						return result;
					} 
                    else
					{
						MessageBox.Show("No se pudo modificar el consecutivo de las empresas ", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
						result = false;
						Cursor.Current = Cursors.Default;
						return result;
					}
				}
			catch 
			{
				
				
				result = false;
				Cursor.Current = Cursors.Default;
			}
			return result;
		}
		public bool fncActualizaEstatusTemporalB( int ipEstatus)
		{
			bool result = false;
			try
			{
					CORVAR.pszgblsql = " UPDATE MTCINE02 set ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_status_reg = " + ipEstatus.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + EmpimPrefijo.ToString() + 
					                   " and gpo_banco = " + EmpimBanco.ToString() + " AND emp_num = " + lNumEmpresa.ToString();
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
						Cursor.Current = Cursors.Default;
						return true;
					} 
                    else
					{
						MessageBox.Show("No se actualizó el estatus de la Empresa en la tabla de Respaldo ", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						result = false;
						Cursor.Current = Cursors.Default;
						return result;
					}
				}
			catch 
			{
				result = false;
				Cursor.Current = Cursors.Default;
			}
			return result;
		}
		
		public string fncConsultaS111S()
		{
			//Lo que hace la función es ver si el ejecutivo se dió de alta correctamente dentro del S111
			//y si lo que se encuentra dado de alta realmente coincide con los datos que se capturaron
			
			string result = String.Empty;
			CRSDialogo.DatosEjecutivo ejelEjecutivo111 = CRSDialogo.DatosEjecutivo.CreateInstance();
			int ilResConS111 = 0;
			string slConS111 = String.Empty;
			string slCausaS111 = String.Empty;
			string slConsulta = String.Empty;
			string slCadena1 = String.Empty;
			string slCadena2 = String.Empty;
			string slCadena3 = String.Empty;
			string slFolio = String.Empty;
			string slCampo = String.Empty;
			int lpNumNom = 0;
			string spMensaje = String.Empty;
			string slRespMensaje = String.Empty;
			string slDialogo = String.Empty;
			CRSDialogo.DatosEjecutivo ejelEjecutivo = CRSDialogo.DatosEjecutivo.CreateInstance();
			
			try
			{
					lpNumNom = 333999;
					slFolio = lpNumNom.ToString(); //al slFolio se le asigna el número de nomina
					spMensaje = "";
					spMensaje = new String(' ', 55);
					spMensaje = StringsHelper.MidAssignment(spMensaje, 1, "C430"); //Sistema
					spMensaje = StringsHelper.MidAssignment(spMensaje, 5, CORBD.PROCESO_CONSULTA); //clave de proceso
					spMensaje = StringsHelper.MidAssignment(spMensaje, 8, "00"); //clave tipo de alta
					spMensaje = StringsHelper.MidAssignment(spMensaje, 10, CORBD.TIPO_TRAMITE); //clave tipo de tramite
					spMensaje = StringsHelper.MidAssignment(spMensaje, 12, StringsHelper.Format(slFolio, "00000000")); //numero de slFolio
					spMensaje = StringsHelper.MidAssignment(spMensaje, 20, StringsHelper.Format(Conversion.Str(CORVB.NULL_INTEGER), "000000000000")); //numero de nomina
					spMensaje = StringsHelper.MidAssignment(spMensaje, 32, CORBD.TRANSACCION_CONSULTA); //Transacción
					spMensaje = StringsHelper.MidAssignment(spMensaje, 36, gdteEmpresa.sCuenta); //cuenta
					
					slDialogo = spMensaje;
					//cnxConexionRut.Termina_Conexion();
                    RUT_Disconnect(false);
					//if (! cnxConexionRut.Inicia_Conexion())
                    int iresult = RUT_Connect(mdlParametros.sgEquipoUnix, mdlParametros.sgPuertoTandem, false);
                    if (iresult != 0)
					{
						MessageBox.Show("No hay conexion al S111. Avise a sistemas.", "Conexión S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
						Cursor.Current = Cursors.Default;
						return "ErrorConexion";
					}
					
					string tempRefParam = "S753-CONALTAS";
					//ilResConS111 = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
                    ushort tamsal = 1654;
                    string slDialogSal = new String(' ', tamsal);
                    int ilRespuestaEnvio = RUT_WriteRead(tempRefParam, slDialogo, (ushort)slDialogo.Length, ref slDialogSal, ref tamsal, false);
                    slDialogo = slDialogSal;
					Application.DoEvents();
					//cnxConexionRut.Termina_Conexion();
                    RUT_Disconnect(false);
					
					if (ilResConS111 != CORVB.NULL_INTEGER)
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("ERROR EN EL ENVIO DE LA INFORMACION ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						result = "ErrorConexion";
						Cursor.Current = Cursors.Default;
						return result;
					}
					if (slDialogo.IndexOf("Error on SEND") >= 0)
					{
						result = "ErrorConexion";
						Cursor.Current = Cursors.Default;
						return result;
					}
					if (slDialogo.IndexOf("RSC error on RUT") >= 0)
					{
						result = "ErrorConexion";
						Cursor.Current = Cursors.Default;
						return result;
					}
					slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");
					//If slRespMensaje <> 0 Then
					//   fncConsultaS111S = "ErrorConexion"
					//   this.Cursor = Cursors.Default
					//   Exit Function
					//End If
				
					//Obtengo los datos del S111
					slCadena1 = Strings.Mid(slRespMensaje, 1243, 151).Trim();
					slCadena2 = Strings.Mid(slRespMensaje, 38, 371).Trim();
					slCadena3 = Strings.Mid(slRespMensaje, 1608, 31).Trim();
					
					if (slCadena1.Trim() == "")
					{
						MessageBox.Show("Error en el envio de la informacion.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
						result = "NoEncontrado";
						Cursor.Current = Cursors.Default;
						return result;
					}
					
					ejelEjecutivo111.sNombre = Strings.Mid(slCadena1, 1, 26).Trim();
					ejelEjecutivo111.sCalle = Strings.Mid(slCadena1, 46, 35).Trim();
					ejelEjecutivo111.sColonia = Strings.Mid(slCadena1, 81, 25).Trim();
					ejelEjecutivo111.sCiudad = Strings.Mid(slCadena1, 106, 25).Trim();
					
					ejelEjecutivo111.sCP = Strings.Mid(slCadena1, 133, 5).Trim();
					if (Strings.Mid(slCadena1, 138, 1).Trim() == "1")
					{
						ejelEjecutivo111.sTipoCuenta = "       Básica       ";
					}
					if (Strings.Mid(slCadena1, 138, 1).Trim() == "2")
					{
						ejelEjecutivo111.sTipoCuenta = "      Adicional     ";
					}
					if (Strings.Mid(slCadena1, 138, 1).Trim() == "3")
					{
						ejelEjecutivo111.sTipoCuenta = "Básica con Adicional";
					}
					
					
					ejelEjecutivo111.sSucursal = Strings.Mid(slCadena1, 139, 4).Trim();
					ejelEjecutivo111.sCorte = Strings.Mid(slCadena1, 143, 2).Trim();
					ejelEjecutivo111.sSexo = Strings.Mid(slCadena1, 144, 1).Trim();
					ejelEjecutivo111.sTelDomicilio = Strings.Mid(slCadena1, 27, 7).Trim();
					ejelEjecutivo111.sTelOficina = Strings.Mid(slCadena1, 34, 7).Trim();
					ejelEjecutivo111.sExt = Strings.Mid(slCadena1, 41, 4).Trim();
					slCausaS111 = Strings.Mid(slCadena3, 1, 19).Trim();
					ejelEjecutivo111.sFecAlta = Strings.Mid(slCadena3, 20, 6).Trim();
					ejelEjecutivo111.sFecModificacion = Strings.Mid(slCadena3, 26, 6).Trim();
					ejelEjecutivo111.sLimiteCredito = Strings.Mid(slCadena2, 21, 9).Trim();
					
					
					ejelEjecutivo.sNombre = gdteEmpresa.sNombreGrabacion;
					ejelEjecutivo.sCalle = gdteEmpresa.sDomicilio;
					ejelEjecutivo.sColonia = gdteEmpresa.sColonia;
					ejelEjecutivo.sCiudad = gdteEmpresa.sPoblacion;
					ejelEjecutivo.sTipoCuenta = gdteEmpresa.sTipoCta;
					ejelEjecutivo.sSucursal = gdteEmpresa.iSucTransmisora.ToString();
					ejelEjecutivo.sCorte = gdteEmpresa.iDiaCorte.ToString();
					ejelEjecutivo.sSexo = gdteEmpresa.sSexo;
					ejelEjecutivo.sTelDomicilio = Conversion.Val(gdteEmpresa.lTelParticular.ToString().Trim()).ToString();
					ejelEjecutivo.sTelOficina = Conversion.Val(gdteEmpresa.lTelOficina.ToString().Trim()).ToString();
					ejelEjecutivo.sExt = Conversion.Val(gdteEmpresa.lExtension.ToString()).ToString();
					ejelEjecutivo.sFecAlta = Strings.Mid(gdteEmpresa.iFechaAlta.ToString(), 3, 6).Trim();
					
					//MsgBox "" + slCuentaEjecutivo0, MB_ICONEXCLAMATION, ""
					//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
					//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
					Interaction.MsgBox("" + gdteEmpresa.sCuenta, CORVB.MB_ICONEXCLAMATION, "");
					
					slCampo = CRSDialogo.sfncValidaDatos(ejelEjecutivo111, ejelEjecutivo);
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
					
					if (String.IsNullOrEmpty(slCampo.Trim()))
					{
						return "Coinciden";
					} 
                    else
					{
						return "NoCoinciden";
					}
				}
			catch 
			{
				
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("ERROR EN EL ENVIO DE LA INFORMACION ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
				result = "ErrorConexion";
				Cursor.Current = Cursors.Default;
			}
			return result;
		}

        public string fncConsultaS111SComDrv(string slCuenta, out string slConsulta)
        {
            //Consulta con Trans. 5001 si existe en S111

            string result = String.Empty;
            string slDialogo = String.Empty;
            mdlParametros.igIndAltaCteOK = 0;

            Cursor.Current = Cursors.WaitCursor;
            //string slDialogo = gdlgDialogoS111.DialogoS;
            string gvRecive = String.Empty;
            string gvRecive5566_01 = String.Empty;
            bool resultOk = false;

            if (slCuenta == "")
            {
                slDialogo = "5001 " + gdteEmpresa.sCuenta + " ";
            }
            else
            {
                slDialogo = "5001 " + slCuenta + " ";
            }

            gvRecive = funConComdrv(slDialogo);

            if (gvRecive.IndexOf("SEG;") >= 0 || gvRecive.IndexOf("SEG:") >= 0)
            {
                ///////////////////////////////
                
                MessageBox.Show("Necesita firmarse para dar el alta");
                
                frmLoginS53 frmFirma = new frmLoginS53();
                frmFirma.ShowDialog();
                 

                gvRecive = funConComdrv(slDialogo);

                int intIntentos = 1;

                while (Strings.Mid(gvRecive, 1, 4) != "5001" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {

                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {

                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }
            }
            else
            {
                gvRecive = funConComdrv(slDialogo);
                int intIntentos = 1;
                while (Strings.Mid(gvRecive, 1, 4) != "5001" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {
                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {

                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }
            }

            if (gvRecive.ToUpper().IndexOf("S111-CONSUL-NOM") >= 0)
            {
                slConsulta = " ";
                return "ErrorConexion";
            }
            else
                if (gvRecive.ToUpper().IndexOf("DIRECCION") >= 0)
                {
                    slConsulta = gvRecive;
                    lcteCliente.ClienteL = StringsHelper.IntValue(Strings.Mid(gvRecive, 525, 12));
                    return "Coinciden";
                }
                else
                {
                    slConsulta = " ";
                    return "NoCoinciden";
                }

        }

        public string fncConsultaTemporal()
        {

            string result = String.Empty;
            int lContador = 0;
            try
            {
                lContador = 0;
                Cursor.Current = Cursors.WaitCursor;

                CORVAR.pszgblsql = " select eje_prefijo,  " + "\r\n";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,  " + "\r\n";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num  " + "\r\n";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCINE01" + "  " + "\r\n";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "where eje_prefijo = " + EmpimPrefijo.ToString().Trim() + "\r\n";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_banco = " + EmpimBanco.ToString().Trim() + " and emp_num = " + lNumEmpresa.ToString().Trim() + "\r\n";

                CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
                CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
                //Si hubo éxito...
                if (CORVAR.igblRetorna == VBSQL.SUCCEED)
                {
                    //Si ejecutó correctamente
                    CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        lContador++;
                    };
                    if (lContador >= 1)
                    {
                        return "Coinciden";
                    }
                    else
                    {
                        return "NoCoinciden";
                    }
                }
                else
                {
                    return "ErrorConexion";
                }
            }
            catch
            {

                result = "ErrorConexion";
            }
            return result;
        }

		public string fncConsultac430S()
		{
			
			string result = String.Empty;
			int lContador = 0;
			try
			{
					lContador = 0;
					Cursor.Current = Cursors.WaitCursor;
					
					CORVAR.pszgblsql = " select eje_prefijo,  " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,  " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num  " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYB_EMP + "  " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "where eje_prefijo = " + EmpimPrefijo.ToString().Trim() + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_banco = " + EmpimBanco.ToString().Trim() + " and emp_num = " + lNumEmpresa.ToString().Trim() + "\r\n";
					
					CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
					CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
					//Si hubo éxito...
					if (CORVAR.igblRetorna == VBSQL.SUCCEED)
					{
						//Si ejecutó correctamente
						CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							lContador++;
						};
						if (lContador >= 1)
						{
							return "Coinciden";
						} 
                        else
						{
							return "NoCoinciden";
						}
					} else
					{
						return "ErrorConexion";
					}
				}
			catch 
			{
				
				result = "ErrorConexion";
			}
			return result;
		}
		public string fncConsultac430EjeS()
		{
			string result = String.Empty;
			int lContador = 0;
			
			try
			{
					lContador = 0;
					Cursor.Current = Cursors.WaitCursor;
					CORVAR.pszgblsql = " select eje_prefijo, gpo_banco, emp_num   " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJE01    " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + EmpimPrefijo.ToString().Trim() + "   " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + EmpimBanco.ToString().Trim() + "   " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lNumEmpresa.ToString().Trim() + "  " + "\r\n";
					
					CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
					CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
					//Si hubo éxito...
					if (CORVAR.igblRetorna == VBSQL.SUCCEED)
					{
						//Si ejecutó correctamente
						CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							lContador++;
						};
						if (lContador >= 1)
						{
							return "Coinciden";
						} 
                        else
						{
							return "NoCoinciden";
						}
					} 
                    else
					{
						return "ErrorConexion";
					}
				}
			catch 
			{
				
				result = "ErrorConexion";
			}
			return result;
		}
		
		public bool fncInsertaM111BEMP()
		{
			bool result = false;
			try
			{
					
					CORVAR.pszgblsql = " exec InsertaM111BEMP2 " + EmpimPrefijo.ToString() + "," + EmppszBanco + "," + lNumEmpresa.ToString().Trim();
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
						result = true;
						Cursor.Current = Cursors.Default;
						return result;
					} 
                    else
					{
						MessageBox.Show("No se pudo insertar el registro en la tabla de respaldo", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Error);
						result = false;
						Cursor.Current = Cursors.Default;
						return result;
					}
				}
			catch 
			{
				
				result = false;
				Cursor.Current = Cursors.Default;
			}
			
			return result;
		}
		public bool fncInsertaM111BEJE0()
		{
			bool result = false;
			try
			{
					CORVAR.pszgblsql = "INSERT into MTCEJE01 ( " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_num, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_roll_over, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_digit, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nombre, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_rfc, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_sueldo, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_num_nom, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_centro_c, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nivel, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nom_gra, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_calle, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_col, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_pob, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_zp, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_cp, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tel_dom, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tel_ofi, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_ext, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_fax, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_limcred, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " reg_num, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_status, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_cuenta_bnx, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_sexo, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_suc_trans, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_suc_prom, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_origen, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_acti_subacti, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_edo, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_dom_calle, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_dom_col, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_dom_ciu, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_dom_pob, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_dom_edo, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_dom_cp, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_email, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_cta_contable, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_gen_pin_pla, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_lim_dis_efec, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tipo_cuenta, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tipo_fac, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_skip_payment, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tabla_mcc, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_ind_lim_disp, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_ind_cta_ctrl, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nacionalidad, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_fecha_alta, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_fecha_cam, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_hora_cam, " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tipo_bloqueo, " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " ejx_numero, " + "\r\n";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_atn_a, " + "\r\n"; //FSWB 20070222 NR Se incluyen campos Atencion A y Persona
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tipo_persona " + "\r\n"; //FSWB NR 20070223
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ) VALUES (";
					CORVAR.pszgblsql = CORVAR.pszgblsql + EmpimPrefijo.ToString().Trim(); //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmpimBanco.ToString().Trim(); //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + lNumEmpresa.ToString().Trim(); //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "0"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "9"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilDigitoVer.ToString(); //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszNomEmpresa); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszRFC); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "0"; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", '0'"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", '0000000'"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", 0 "; //int nivel
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszNomEmpresa); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszCalleEnv); // char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszColoniaEnv); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszPoblacionEnv); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", 0"; //int             'eje_zp
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmppszCpEnv; //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszTelefono); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszTelefono); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszTelExt); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszFax); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmppszCreditoGlobal.ToString(); //int                     'Limite de Crédito
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", 1 "; //int              'Region
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'N' "; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", '' "; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'F' "; //char
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + EmppszSucTransmisora.Trim() + "'"; //& Trim(pszSucursal) & "'" ' char
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + EmppszSucPromotora.Trim() + "'"; //& Trim(pszSucursal) & "'" ' char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'E'"; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", '03'"; //char                               'Actividad / Subactividad
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszEstadoEnv); //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszCalleEnv); //char                   'Domicilio Calle
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszColoniaEnv); //char                   'Colonia
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszCiudadEnv); //char                   'Ciudad
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszPoblacionEnv); //char                   'Población
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszEstadoEnv); //char                   'Estado
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmppszCpEnv; //int                   'CP
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmppszEmail); //char                   'Mail
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + StringsHelper.Format(EmpslCuentaContable, new string('#', 40)) + "'"; //Cuenta Contable 'char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ((int) CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN).ToString(); //int                'Generación de PIN Plástico
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "0"; //int                     'Limite de disposición de Efectivo
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(CRSParametros.cteEmpresa) + " "; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmpslTipoFactura) + " "; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmpilSkipPayment.ToString(); //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmpilTablaMCC.ToString(); //int
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'P'"; //char
					//                   En CRSDialogo también están cambiadas indctacontrol y nacionalidad
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmpslNacionalidad) + " "; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(EmpslIndCtaControl) + " "; //char
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + fncPonComillasVaciasS(CRSParametros.sgUserID) + " ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20), getdate(),112))";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20), getdate(),112))";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmpimEmpTipoBloqueo.ToString().Trim();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmppszNominaEjeBNX.Trim();
					CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + EmpimAtencionA.Trim() + "'"; //FSWB 20070223 NR Se incluyen campos Atencion A y Persona
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + EmpimPersona.ToString().Trim() + ")"; //FSWB NR 20070223
					//EmpimEmpTipoBloqueo gdteEmpresa.sCuenta
					if (CORPROC2.Modifica_Registro() != 0)
					{
						//MsgBox "Se ha generado la cuenta " & slCuentaEjecutivo0 & " para la empresa " & Trim(CStr(lNumEmpresa)), vbInformation, ""
						MessageBox.Show("Se ha generado la cuenta " + gdteEmpresa.sCuenta + " para la empresa " + lNumEmpresa.ToString().Trim(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = true;
						Cursor.Current = Cursors.Default;
					} 
                    else
					{
						//MsgBox "No se pudo generar la cuenta " & slCuentaEjecutivo0 & " para la empresa " & Trim(CStr(lNumEmpresa)), vbInformation, ""
						MessageBox.Show("No se pudo generar la cuenta " + gdteEmpresa.sCuenta + " para la empresa " + lNumEmpresa.ToString().Trim(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						Cursor.Current = Cursors.Default;
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
			catch 
			{
				
				//MsgBox "No se pudo generar la cuenta " & slCuentaEjecutivo0 & " para la empresa " & Trim(CStr(lNumEmpresa)), vbInformation, ""
				MessageBox.Show("No se pudo generar la cuenta " + gdteEmpresa.sCuenta + " para la empresa " + lNumEmpresa.ToString().Trim(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				result = false;
				Cursor.Current = Cursors.Default;
			}
			return result;
		}
		//Private Function fncActualizaFirmaB() As Boolean
		//'····· Inicia el proceso de guardar la imagen ·····
		//   GrabarImagen CORREGFI!ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " eje_prefijo = " + Format$(igblPref) + " and gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
		//   GrabarImagen CORREGFI!ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " eje_prefijo = " + Format$(igblPref) + " and gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
		//   GrabarImagen CORREGFI!ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " eje_prefijo = " + Format$(igblPref) + " and gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
		//End Function
		//Public Function fncInsertaM111B() As Boolean
		//
		//fncInsertaM111B = fncInsertaM111BEMP()
		//Dim slNumEmpresa As String
		//
		//fncInsertaM111BEJE0
		//slNumEmpresa = CStr(lNumEmpresa)
		//Crea_Directorio_Emp CStr(lNumEmpresa)
		//
		//End Function
		public bool fncActualizaCredAcumB()
		{
			bool result = false;
			try
			{
					CORVAR.pszgblsql = "UPDATE MTCCOR01 set gpo_acum_cred = (select sum(emp_cred_tot) from MTCEMP01 ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + EmpimPrefijo.ToString() + " and gpo_banco = " + EmppszBanco.ToString() + " and   gpo_num = " + EmppszNumGrupo + ")";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + EmpimPrefijo.ToString() + " and gpo_banco = " + EmppszBanco.ToString() + " and   gpo_num = " + EmppszNumGrupo;
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
						result = true;
						Cursor.Current = Cursors.Default;
						return result;
					} 
                    else
					{
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No se actualizó el crédito acumulado del grupo: " + EmppszNumGrupo, (MsgBoxStyle) (((int) CORVB.MB_ICONINFORMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
						result = false;
						Cursor.Current = Cursors.Default;
						return result;
					}
				}
			catch 
			{
				
				result = false;
				Cursor.Current = Cursors.Default;
			}
			return result;
		}
		//UPGRADE_NOTE: (7001) The following declaration (fncValidaDatosS) seems to be dead code
		//private string fncValidaDatosS( mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
		//{
		//return String.Empty;
		//}
		public void  EmpgdteEmpresa()
		{
			gdteEmpresa = CRSDialogo.gdteDatosEmpresa;
		}
		public bool fncEliminaRespB()
		{
			bool result = false;
			try
			{
					CORVAR.pszgblsql = " DELETE FROM MTCINE02 ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + EmpimPrefijo.ToString() + 
					                   " and gpo_banco = " + EmpimBanco.ToString() + " AND emp_num = " + lNumEmpresa.ToString();
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
						result = true;
						Cursor.Current = Cursors.Default;
						return result;
					} 
                    else
					{
						MessageBox.Show("No se pudo eliminar el respaldo de la empresa.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						result = false;
						Cursor.Current = Cursors.Default;
						return result;
					}
				}
			catch 
			{
				
				result = false;
				Cursor.Current = Cursors.Default;
			}
			
			return result;
		}
		
		private string fncValidaResultadoS( string slRespuesta)
		{
			return slRespuesta.Trim();
		}
		public void  prRegistraLog( string slRespuesta)
		{
			
			string Cadena = String.Empty;
			string slResultado = fncValidaResultadoS(slRespuesta);
			string slMensajesS = fncObtenMensajesS(slResultado);
			frm_error_envio tempLoadForm = frm_error_envio.DefInstance;
			frm_error_envio.DefInstance.lblMensajeError.Text = "Se encontró un error al registrar el Alta.";
			frm_error_envio.DefInstance.txt_error.Text = slResultado;
			frm_error_envio.DefInstance.ShowDialog();
			string slRuta = fncCreaRutaS();
			string slArchivo = fncCreaNombreArchivoS(slRuta);
			int num_archivo = FileSystem.FreeFile();

            if (! fncRevisaCarpetaB(slRuta))
			{
				prCreaCarpeta(slRuta);
				FileSystem.FileOpen(num_archivo, slArchivo, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
			} 
            else
			{
				if (! fncRevisaArchivoB(slArchivo))
				{
					FileSystem.FileOpen(num_archivo, slArchivo, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
				} 
                else
				{
					FileSystem.FileOpen(num_archivo, slArchivo, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
				}
			}
			FileSystem.PrintLine(num_archivo, slMensajesS);
			FileSystem.FileClose(num_archivo);
		}
		private string fncObtenMensajesS( string plRespuesta)
		{
			//Se arma el mensaje de error que va a se introducido dentro del archivo
			string slMensaje = " Empresa:" + gdteEmpresa.sNombre;
			slMensaje = slMensaje + " RFC:" + gdteEmpresa.sRFC;
			slMensaje = slMensaje + " Nombre Grabado:" + gdteEmpresa.sNombreGrabacion;
			slMensaje = slMensaje + " Domicilio Envio:" + gdteEmpresa.sDomicilio;
			slMensaje = slMensaje + " Estado Envio:" + gdteEmpresa.sEstado + "\r\n";
			slMensaje = slMensaje + plRespuesta;
			return slMensaje;
		}
		public void  prRegistraCliente()
		{
			if (lcteCliente.ClienteL != 0)
			{
				if (! lcteCliente.fncAlmacenaClienteB())
				{
					MessageBox.Show("No se dio de alta el Cliente", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		private string fncCreaNombreArchivoS( string spRuta)
		{
			return spRuta + Strings.Chr(92).ToString() + "MensajesError.txt";
		}
		private string fncCreaRutaS()
		{
            //return Path.GetDirectoryName(Application.ExecutablePath) + Strings.Chr(92).ToString() + "MensajesError";

            string CarpetaMensajesError = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "MensajesError";

            if (Directory.Exists(CarpetaMensajesError))
            {
                System.IO.Directory.CreateDirectory(CarpetaMensajesError);
            }
            return CarpetaMensajesError;
        }

        public bool fncDialogoComdrv(string slMensaje, ref  string slRespuesta)
        {
            bool result = false;
            COMDRV32.TcpServer objProxy = null;
            string slArgumento = String.Empty;
            bool blSalir = false;
            string slContestacion = String.Empty;
            try
            {
                if (pfCargaTcpServerB(ref objProxy))
                {
                    slArgumento = "";
                    //Captura el mensaje enviado por el TCPSERVER
                    slArgumento = "D" + slMensaje.Trim() + Strings.Chr(3).ToString();
                    objProxy.SendRequest(StringsHelper.StrConv(slArgumento, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slArgumento.Length);
                    blSalir = false;
                    while (!blSalir)
                    {

                        slContestacion = StringsHelper.StrConv(objProxy.ReceiveResponse(60000), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                    }
                    slRespuesta = slContestacion;
                    prDescargaTcpServer(ref objProxy);
                    result = true;
                }
                else
                {
                    MessageBox.Show("Error al cargar al objeto", Application.ProductName);
                }
            }
            catch (Exception excep)
            {

                if (Information.Err().Number == -2147014836)
                {
                    blSalir = true;
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    MessageBox.Show(excep.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                result = true;
            }
            return result;
        }


        private bool pfCargaTcpServerB(ref  COMDRV32.TcpServer objProxy)
        {
            try
            {
                objProxy = new COMDRV32.TcpServer();
                objProxy.Connect();
                return true;
            }
            catch (Exception excep)
            {

                if (Information.Err().Number == 0x80072AFC)
                {
                    MessageBox.Show(Information.Err().Number.ToString() + " direccion ip erronea", Application.ProductName);
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, Application.ProductName);
                }
                return false;
            }
        }
        private void prDescargaTcpServer(ref  COMDRV32.TcpServer objProxy)
        {
            //Desconecta al cobjeto comdvr y lo destruye
            objProxy.Disconnect();
        }

        public string fncEnviaDialogoLocalPrimeraSComdrv(ref  string spRespuesta, bool bpReAlta)
        {
            //Envia el diálogo S753

            string result = String.Empty;
            string slDialogo = String.Empty;
            mdlParametros.igIndAltaCteOK = 0;

            CRSDialogo.DialogoComDrv(ref slDialogo, gdteEmpresa, CRSDialogo.TipoAlta.cteAltaS111ComDrv);

            Cursor.Current = Cursors.WaitCursor;
            string gvRecive = String.Empty;
            string gvRecive5566_01 = String.Empty;
            bool resultOk = false;

            // 04-05-2018 / LMHR & CMET: Se agregan lineas para registro del dialogo de la transaccion en el log  
            mdlSeguridad.EnviaLog("Mensaje Envio de Comdrv:" + "\r\n" + slDialogo);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje a enviar a Comdrv:" + "\r\n" + slDialogo);

            gvRecive = funConComdrv(slDialogo);

            if (gvRecive.IndexOf("SEG;") >= 0 || gvRecive.IndexOf("SEG:") >= 0)
            {
                ///////////////////////////////
                MessageBox.Show("Necesita firmarse para dar el alta");

                frmLoginS53 frmFirma = new frmLoginS53();
                var regreso = frmFirma.ShowDialog();

                gvRecive = funConComdrv(slDialogo);

                int intIntentos = 1;

                while (Strings.Mid(gvRecive, 1, 4) != "5566" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {
                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {
                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }

                //////segunda parte verifica errores

                if (Strings.Mid(gvRecive, 1, 4) == "5566" && Strings.Mid(gvRecive, 6, 2) == "01")
                {
                    //Validar respuesta sea OK (0)
                    if (Strings.Mid(gvRecive, 45, 2) == "00")// && Strings.Mid(gvRecive, 24, 8) == estHeaderAltas.strHDFolInterno.Value)
                    {
                        gvRecive5566_01 = gvRecive;
                        resultOk = true;
                    }
                    else
                    {
                        Interaction.Beep();
                        if (gvRecive.Trim().Length == 0)
                        {
                            string tempRefParam7 = "Respuesta erronea de Tandem o se acabó el tiempo de espera. Por favor reintente.";
                            MessageBox.Show(tempRefParam7, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (gvRecive.IndexOf("CONTRATO A DAR DE ALTA YA EXISTE") >= 0)
                            {
                                gvRecive5566_01 = gvRecive;
                                resultOk = true;
                            }
                            else
                            {
                                string tempRefParam9 = Strings.Mid(gvRecive, 47, 50) + "\n" + "\r" + Strings.Mid(gvRecive, 223, 72).Trim();
                                MessageBox.Show(tempRefParam9, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        //resultOk = false;
                    }
                }
                else
                {
                    Interaction.Beep();
                    string tempRefParam11 = Strings.Mid(gvRecive, 1, 50);
                    MessageBox.Show(tempRefParam11, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultOk = false;
                }
            }
            else
            {
                int intIntentos = 1;
                while (Strings.Mid(gvRecive, 1, 4) != "5566" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {
                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {
                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }

                //////segunda parte verifica errores

                if (Strings.Mid(gvRecive, 1, 4) == "5566" && Strings.Mid(gvRecive, 6, 2) == "01")
                {
                    //Validar respuesta sea OK (0)
                    if (Strings.Mid(gvRecive, 45, 2) == "00")// && Strings.Mid(gvRecive, 24, 8) == estHeaderAltas.strHDFolInterno.Value)
                    {
                        gvRecive5566_01 = gvRecive;
                        resultOk = true;
                    }
                    else
                    {
                        Interaction.Beep();
                        if (gvRecive.Trim().Length == 0)
                        {
                            string tempRefParam7 = "Respuesta erronea de Tandem o se acabó el tiempo de espera. Por favor reintente.";
                            MessageBox.Show(tempRefParam7, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (gvRecive.IndexOf("CONTRATO A DAR DE ALTA YA EXISTE") >= 0)
                            {
                                gvRecive5566_01 = gvRecive;
                                resultOk = true;
                            }
                            else
                            {
                                string tempRefParam9 = Strings.Mid(gvRecive, 47, 50) + "\n" + "\r" + Strings.Mid(gvRecive, 223, 72).Trim();
                                MessageBox.Show(tempRefParam9, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        //resultOk = false;
                    }
                }
                else
                {
                    Interaction.Beep();
                    string tempRefParam11 = Strings.Mid(gvRecive, 1, 50);
                    MessageBox.Show(tempRefParam11, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultOk = false;
                }
            }


            if (resultOk)
            {
                result = "00";

                if (lcteCliente.fncExtraerClienteL(gvRecive) != 0)
                {
                    lcteCliente.ClienteL = lcteCliente.fncExtraerClienteL(gvRecive);
                }

            }
            else
            {
                result = gvRecive;
            }


            // 04-05-2018 / LMHR & CMET: Se agregan lineas para registro de la respuesta de la transaccion en el log
            mdlSeguridad.EnviaLog("Mensaje Recibido de Comdrv:" + "\r\n" + gvRecive);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje Recibido de Comdrv:" + "\r\n" + gvRecive);

            return result;

        }

        public string fncEnviaDialogoLocalSegundaSComdrv(ref  string spRespuesta, bool bpReAlta)
        {
            //Envia el diálogo S753

            string result = String.Empty;
            string slDialogo = String.Empty;
            mdlParametros.igIndAltaCteOK = 1;

            CRSDialogo.DialogoComDrv(ref slDialogo, gdteEmpresa, CRSDialogo.TipoAlta.cteAltaS016ComDrv);

            Cursor.Current = Cursors.WaitCursor;
            string gvRecive = String.Empty;
            string gvRecive5566_01 = String.Empty;
            bool resultOk = false;

            // 04-05-2018 / LMHR & CMET: Se agregan lineas para registro del dialogo de la transaccion en el log  
            mdlSeguridad.EnviaLog("Mensaje Envio de Comdrv:" + "\r\n" + slDialogo);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje a enviar a Comdrv:" + "\r\n" + slDialogo);

            gvRecive = funConComdrv(slDialogo);

            if (gvRecive.IndexOf("SEG;") >= 0 || gvRecive.IndexOf("SEG:") >= 0)
            {
                ///////////////////////////////
                MessageBox.Show("Necesita firmarse para dar el alta");

                frmLoginS53 frmFirma = new frmLoginS53();
                var regreso = frmFirma.ShowDialog();

                gvRecive = funConComdrv(slDialogo);

                int intIntentos = 1;

                while (Strings.Mid(gvRecive, 1, 4) != "5566" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {

                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {

                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }

                //////segunda parte verifica errores

                if (Strings.Mid(gvRecive, 1, 4) == "5566" && Strings.Mid(gvRecive, 6, 2) == "01")
                {
                    //Validar respuesta sea OK (0)
                    if (Strings.Mid(gvRecive, 45, 2) == "00")// && Strings.Mid(gvRecive, 24, 8) == estHeaderAltas.strHDFolInterno.Value)
                    {
                        gvRecive5566_01 = gvRecive;
                        resultOk = true;
                    }
                    else
                    {
                        Interaction.Beep();
                        if (gvRecive.Trim().Length == 0)
                        {
                            string tempRefParam7 = "Respuesta erronea de Tandem o se acabó el tiempo de espera. Por favor reintente.";
                            MessageBox.Show(tempRefParam7, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (gvRecive.IndexOf("CONTRATO A DAR DE ALTA YA EXISTE") >= 0)
                            {
                                gvRecive5566_01 = gvRecive;
                                resultOk = true;
                            }
                            else
                            {
                                string tempRefParam9 = Strings.Mid(gvRecive, 47, 50) + "\n" + "\r" + Strings.Mid(gvRecive, 223, 72).Trim();
                                MessageBox.Show(tempRefParam9, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        //resultOk = false;
                    }
                }
                else
                {
                    Interaction.Beep();
                    string tempRefParam11 = Strings.Mid(gvRecive, 1, 50);
                    MessageBox.Show(tempRefParam11, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultOk = false;
                }
            }
            else
            {
                int intIntentos = 1;
                while (Strings.Mid(gvRecive, 1, 4) != "5566" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {
                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {
                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }

                //////segunda parte verifica errores

                if (Strings.Mid(gvRecive, 1, 4) == "5566" && Strings.Mid(gvRecive, 6, 2) == "01")
                {
                    //Validar respuesta sea OK (0)
                    if (Strings.Mid(gvRecive, 45, 2) == "00")// && Strings.Mid(gvRecive, 24, 8) == estHeaderAltas.strHDFolInterno.Value)
                    {
                        gvRecive5566_01 = gvRecive;
                        resultOk = true;
                    }
                    else
                    {
                        Interaction.Beep();
                        if (gvRecive.Trim().Length == 0)
                        {
                            string tempRefParam7 = "Respuesta erronea de Tandem o se acabó el tiempo de espera. Por favor reintente.";
                            MessageBox.Show(tempRefParam7, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (gvRecive.IndexOf("CONTRATO A DAR DE ALTA YA EXISTE") >= 0)
                            {
                                gvRecive5566_01 = gvRecive;
                                resultOk = true;
                            }
                            else
                            {
                                string tempRefParam9 = Strings.Mid(gvRecive, 47, 50) + "\n" + "\r" + Strings.Mid(gvRecive, 223, 72).Trim();
                                MessageBox.Show(tempRefParam9, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        //resultOk = false;
                    }
                }
                else
                {
                    Interaction.Beep();
                    string tempRefParam11 = Strings.Mid(gvRecive, 1, 50);
                    MessageBox.Show(tempRefParam11, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultOk = false;
                }
            }

            if (resultOk)
            {
                result = "00";

                if (lcteCliente.fncExtraerClienteL(gvRecive) != 0)
                {
                    lcteCliente.ClienteL = lcteCliente.fncExtraerClienteL(gvRecive);
                }

            }
            else
            {
                result = gvRecive;
            }

            // 04-05-2018 / LMHR & CMET: Se agregan lineas para registro de la respuesta de la transaccion en el log
            mdlSeguridad.EnviaLog("Mensaje Recibido de Comdrv:" + "\r\n" + gvRecive);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje Recibido de Comdrv:" + "\r\n" + gvRecive);

            return result;

        }


        //Art. 115 Conexion Comdrv 15092013

        static private COMDRV32.TcpServer _objProxy = null;

        static public COMDRV32.TcpServer objProxy
        {
            get
            {
                if (_objProxy == null)
                {
                    _objProxy = new COMDRV32.TcpServer();
                }
                return _objProxy;
            }
            set
            {
                _objProxy = value;
            }
        }

        static public string funConComdrv(string strMensaje)
        {
            string strCadPaso = String.Empty;
            strCadPaso = "D" + strMensaje.Trim() + Strings.Chr(3).ToString(); ;
            objProxy.SendRequest(StringsHelper.StrConv4(strCadPaso, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)strCadPaso.Length);
            int intTM = 0;
            string s = String.Empty;
            bool bContinue = false;
            intTM = 0;
            s = "";
            bContinue = true;
            while (bContinue)
            {
                try
                {
                    innerFunCON(ref s, ref intTM, ref strMensaje, ref bContinue);
                }

                catch (Exception e)
                {
                    objProxy = null;
                    objProxy = new COMDRV32.TcpServer();
                    objProxy.Connect();
                    objProxy.SendRequest(StringsHelper.StrConv4(strCadPaso, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)strCadPaso.Length);
                    bContinue = true;
                }
            }
            if (s.IndexOf("SEG;") >= 0 || s.IndexOf("SEG:") >= 0)
            {
                return Strings.Mid(s, 11);
            }
            else
            {
                return Strings.Mid(funDepuraMensaje(ref s), 11);
            }
        }


        private static void innerFunCON(ref string s, ref int intTM, ref string strMensaje, ref bool bContinue)
        {

            s = s + StringsHelper.StrConv4(objProxy.ReceiveResponse(100000), StringsHelper.VbStrConvEnum.vbUnicode, 0) + Strings.Chr(3).ToString();

            if (s.Length > 13)
            {
                if (s.IndexOf("H10013CMDD") >= 0)
                { //Evitamos el mensaje para el ADMWIN
                    s = Strings.Mid(s, s.IndexOf("H10013CMDD") + 14);
                }
                //Checa si al reposicionarnos hay cadena válida
                if (Strings.Mid(s, 1, 2) == "H1" && Strings.Mid(s, 7, 4) == "CMDD")
                {
                    if (intTM == 0)
                    {
                        intTM = StringsHelper.IntValue(Strings.Mid(s, 3, 4)); //Toma la longitud de la cadena
                    }
                    if (s.Length >= intTM - 1)
                    {
                        //Para sincronizar el mensaje (se asegura de que sea el que pidió).
                        if (Strings.Mid(s, 11, 4) == "5447" || Strings.Mid(s, 11, 4) == "5448" || Strings.Mid(s, 11, 4) == "5449")
                        {
                            if (Strings.Mid(strMensaje, 1, 4) == Strings.Mid(s, 11, 4))
                            {
                                bContinue = false;
                            }
                        }
                        else
                        {
                            bContinue = false;
                        }
                    }
                }
            }

        }

        static public string funDepuraMensaje(ref  string vRecive)
        {
            //*****************************************************************************************************
            //* Propósito:  depura mensaje
            //* Entradas: vRecive-> mensaje recibido
            //****************************************************************************************************
            const byte gbFS = 28;
            const byte gbESC = 27;
            const byte gbHOME = 30;
            const byte gbCR = 10;
            const byte gbLF = 13;
            const byte gbEOT = 3;
            const byte gbNULO = 0;
            const byte gbTAB = 9;
            bool gbolEstaSeg = false;
            for (int intvIndice = 1; intvIndice <= vRecive.Length; intvIndice++)
            {

                if (Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbFS).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbEOT).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbLF).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbTAB).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbNULO).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbESC).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbHOME).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbCR).ToString())
                {
                    //Se tuvo que cambiar para evitar los primeros caracteres
                    //y sustituir los intermedio por espacios, en lugar de quitarlos.
                    if (intvIndice > 5)
                    {
                        vRecive = Strings.Mid(vRecive, 1, intvIndice - 1) + " " + Strings.Mid(vRecive, intvIndice + 1);
                    }
                    else
                    {
                        vRecive = Strings.Mid(vRecive, 1, intvIndice - 1) + Strings.Mid(vRecive, intvIndice + 1);
                        intvIndice--;
                    }
                }
            }
            if (vRecive.IndexOf("SEG:") >= 0)
            {
                gbolEstaSeg = true;
            }
            else if (vRecive.IndexOf("SEG;") >= 0)
            {
                gbolEstaSeg = false;
            }

            return vRecive;
        }

		private void  prCreaCarpeta( string spCarpeta)
		{
            string CarpetaMensajesError = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "MensajesError";
            try
            {
                System.IO.Directory.CreateDirectory(CarpetaMensajesError);
            }
            catch
			{
				
				MessageBox.Show("No fue posible crear la carpeta de mensajes.", Application.ProductName);
			}
		}
		private bool fncRevisaArchivoB( string spArchivo)
		{
			Scripting.FileSystemObject fs = new Scripting.FileSystemObject();
			return fs.FileExists(spArchivo);
		}
		private bool fncRevisaCarpetaB( string spCarpeta)
		{
			Scripting.FileSystemObject fs = new Scripting.FileSystemObject();
			return fs.FolderExists(spCarpeta);
		}
		public void  prMensajeEmpresaAlta()
		{
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
			//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
			//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
			Interaction.MsgBox("La empresa " + EmppszNomEmpresa.Trim() + " fué dada de Alta con el Número " + StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)), (MsgBoxStyle) (((int) CORVB.MB_ICONINFORMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
		}
		public bool fncCrea_Directorio_EmpB()
		{
			bool result = false;
			string slempresa = String.Empty;
			string pszDirEmp = String.Empty;
			try
			{
					slempresa = lNumEmpresa.ToString().Trim();
					if (FileSystem.Dir(EmpsmblPathRepEmpresas, FileAttribute.Directory) != CORVB.NULL_STRING)
					{
						pszDirEmp = EmpsmblPathRepEmpresas + EmpimPrefijo.ToString() + "_" + EmppszBanco + "_" + slempresa;
						result = false;
						if (FileSystem.Dir(pszDirEmp, FileAttribute.Directory) == CORVB.NULL_STRING)
						{
							Directory.CreateDirectory(pszDirEmp);
							return true;
						} 
                        else
						{
							return true;
						}
					} 
                    else
					{
						Directory.CreateDirectory(EmpsmblPathRepEmpresas);
						return true;
					}
				}
			catch 
			{
				
				result = false;
			}
			return result;
		}

        public bool fncValidaNumEmpresa(int lpNumEmp)
        {

            string slCuenta;

            try
            {
                if (lpNumEmp <= 0)
                {
                    //MsgBox "No se puede asignar este Numero de Empresa", vbOKOnly + vbInformation, App.Title
                    Interaction.MsgBox("No se puede asignar este Numero de Empresa", (MsgBoxStyle)Int32.Parse(((int)CORVB.MB_OK).ToString() + ((int)CORVB.MB_ICONEXCLAMATION).ToString()), CORSTR.STR_APP_TIT);
                    return false;
                }
                else
                {
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lpNumEmp;

                    if (CORPROC2.Cuenta_Registros() >= 1)
                    {
                        //MsgBox "No se puede utilizar este Numero de Empresa porque ya fue asignado", vbOKOnly + vbInformation, App.Title
                        Interaction.MsgBox("No se puede utilizar este Numero de Empresa porque ya fue asignado", (MsgBoxStyle)Int32.Parse(((int)CORVB.MB_OK).ToString() + ((int)CORVB.MB_ICONEXCLAMATION).ToString()), CORSTR.STR_APP_TIT);
                        return false;
                    }
                    else
                    {
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " a.gpo_banco,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " a.emp_num,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_num,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_roll_over,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_digit";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01 a, MTCEJE01 b";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = b.eje_prefijo";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.gpo_banco";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = b.emp_num";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + mdlParametros.gprdProducto.BancoL;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + lpNumEmp;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_num = 0";

                        if (CORPROC2.Cuenta_Registros() >= 1)
                        {

                            if (CORPROC2.Obtiene_Registros() != 0)
                            {
                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    slCuenta = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                                    slCuenta = slCuenta + VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                    slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 3), mdlParametros.gprdProducto.MascaraEmpresaS);
                                    slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 4), mdlParametros.gprdProducto.MascaraEjecutivoS);
                                    slCuenta = slCuenta + VBSQL.SqlData(CORVAR.hgblConexion, 5);
                                    slCuenta = slCuenta + VBSQL.SqlData(CORVAR.hgblConexion, 6);
                                }
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                            //MsgBox "No se puede utilizar este Numero de Empresa porque ya existe la cuenta " & slCuenta, vbOKOnly + vbInformation, App.Title
                            Interaction.MsgBox("No se puede utilizar este Numero de Empresa porque ya existe la cuenta ", (MsgBoxStyle)Int32.Parse(((int)CORVB.MB_OK).ToString() + ((int)CORVB.MB_ICONEXCLAMATION).ToString()), CORSTR.STR_APP_TIT);

                            return false;
                        }
                        else
                        { return true; }
                    }
                }
            }
            catch
            {
                CRSGeneral.prObtenError("Alta Empresa - fncValidaNumEmpresa");
                return false;
            }
        }
	}
}