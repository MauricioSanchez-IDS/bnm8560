using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System;
using System.IO; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Text;
using Microsoft.Win32; /*se agrega para lectura del Registry de Windows 23/09/09*/

namespace TCd430
{
	class mdlParametros
	{

        static public string pathDeposito = string.Empty; /*lectura del Registry de Windows 23/09/09*/
        static public string pathReportes = string.Empty; /*lectura del Registry de Windows 23/09/09*/
        static public string pathLogs = string.Empty; /*lectura del Registry de Windows 23/09/09*/

        static private RegistryKey mobjRegistro; /*lectura del Registry de Windows 23/09/09*/
        static public string strValor = string.Empty; /*lectura del Registry de Windows 23/09/09*/

		
		//Function para milisegundos
		
		static public bool bgCamLimCred = false;
		
		//Clases Globales
		static public clsProducto gprdProducto = null;
		static public clsCorporativo gcrpCorporativo = null;
		static public clsEmpresa gempEmpresa = null;
		static public clsUnidad guniUnidad = null;
		static public clsReporte grepReporte = null;
		static public clsDialogo gdlgDialogo = null;
		static public clsPerfil gperPerfil = null;
		
		//Clase para utilizar en Altas masivas JRGD 19/Nov/2002
		static public clsArchivo garcAltasMasivas = null;
		
		//Colecciones Globales
		static public colEstatusEnvio gcestResumen = null;
		static public colCatCorporativos gccrpCorporativo = null;
		static public colCatEmpresas gcempEmpresa = null;
		static public colCatUnidades gcuniUnidad = null;
		static public colCatReporte gcrepReporte = null;
		static public colcatEstado gcestEstado = null;
		static public colEjecutivoBanamex gcejxEjecutivoBanamex = null;
		//Global xcnn As ADODB.Connection 'Ado Connection para el manejo de imagenes debido a error en funcion readtext de sybase! 29_Agosto_2003
		//Coleccion para utilizar en Altas Masivas JRGD 19/Nov/2002
		static public colcatArchivo gcarcAltasMasivas = null;
		
		//Coleccion para el envio de Limite de Credito
		static public clsLimite glimEnvioLimite = null;
		static public colcatLimite gclimEnvioLimite = null;
		
		//Coleccion para pantallas de SBF
		static public colcatSBFC430Empresa gcsbfEmpresaSBF = null;
		static public colcatSBFC430Empresa gcsbfEmpresaC430 = null;
		
		static public colcatSBFEjecutivo gcsbfEjecutivoSBF = null;
		static public colcatSBFEjecutivo gcsbfEjecutivoC430 = null;
		static public colcatSBFTransaccion gcsbfTransaccionSBF = null;
		static public colcatSBFTransaccion gcsbfTransaccionC430 = null;
		
		//Costantes de Respuesta de Diálogo
		public const int cteiAltaS111OK = 1; //Se realizó el alta satisfactoriamente en el S111
		public const int cteiAltaS016OK = 2; //Se realizó el alta satisfactoriamente en el S016
		public const int cteiAltaOK = 3;
		public const int cteiAltaS111NO = 5; //No se realizó el alta en el S111
		public const int cteiAltaS016NO = 6; //No se realizó el alta en el S016
		public const int cteiConsultaS111OK = 0; //Se realizó la consulta al S111 satistfactoriamente
		public const int cteiConsultaS111NO = 1; //No se realizó la consulta al S111 satisfactoriamente
		public const int cteiErrorComunicaciones = -1; //Indica que no se puede enlazar un diálogo
		
		//Global cnngM111 As New ADODB.Connection
		public const int ctelCorporativo = 4;
		public const string ctesMaskCorporativo = "0000";
		public const int ctelUnidades = 5;
		public const string ctesUnidades = "00000";
		public const string ctesSeparador = "   ";
		public const int ctelMascaraRep = 3;
		public const string ctesMascaraRep = "000";
		public const string ctesPrefijoReporte = "rpt";
		public const string ctesSeparadorRFC = "-";
		
		public const string ctesC430 = "c430";
		public const string ctesS111 = "S111";
		public const string ctesS016 = "S016";
		public const string ctesTandem = "tandem";
		
		public const string ctesProcesoAltaS111 = "001";
		public const string ctesProcesoAltaS016 = "016";
		public const string ctesTipoAlta = "01";
		public const string ctesTipoTramite = "01";
		public const string ctesTipoTransaccion = "5181";
		public const string ctesTipoOrigen = "E";
		public const string ctesProcesoConsulta = "002";
		public const string ctesTransaccionConsulta = "3377";
		
		public const string ctesModificaEmpresaMasivos = "5199";
		public const string ctesModificaNombre = "5330";
		public const string ctesModificaCredito = "316";
		public const string ctesModificaCreditoEje = "5117";
		public const string ctesCveAccesoModificaS111 = "004101      FIRMA";
		public const string ctesFinalizaS111 = "004101      ADIOS";
		
		public const string ctesEmpresa = "E";
		public const string ctesCorporativo = "C";
		public const string ctesIndividual = "I";
		
		//Variables para la funcion de la Pantalla
		public const string ctesTagAlta = "A";
		public const string ctesTagConsulta = "B";
		public const string ctesTagCambio = "C";
		
		public const string ctesActividad = "03";
		
		static public bool bgCancela = false;
		
		static public int igNumGrupo = 0;
		static public string sgNomGrupo = String.Empty;
		
		static public int lgNumEmpresa = 0;
		static public string sgNomEmpresa = String.Empty;
		
		static public bool bgModFirma = false;
		static public bool bgFirma1 = false;
		static public bool bgFirma2 = false;
		static public bool bgFirma3 = false;
		
        static public string sgEquipoUnix= String.Empty;
        static public string sgPuertoTandem=String.Empty;
		static public string sgPathFirmas = String.Empty;
		static public string sgPathRepEmpresas = String.Empty;
		static public string sgPathRepCrystal = String.Empty;
		static public string sgPathRepCorporativo = String.Empty;
		static public string sgPathComDrive = String.Empty;
		static public string sgPathWord = String.Empty;
		static public string sgPathWordDom = String.Empty;
		static public string sgPathWordCred = String.Empty;
		//static public string sgPathEXCEL = String.Empty;
        static public string sgPathLogs = String.Empty;
		
		static public int igReintentos = 0;
		static public int igContador = 0;
		
		//Variables para pantallas de envío SBF
		
		static public string sgFiltroEmpresa = String.Empty;
		static public string sgFiltroEjecutivo = String.Empty;
		static public int IgEnvioSBF = 0;
		static public string sgDescArch = String.Empty;
		
		static public string vgFiltroEje = String.Empty;
		static public string vgNombreEje = String.Empty;
		static public bool ES_DEBUG = false;

        static public string valorRegistro(int seccion, string psDirectorio, string psLlave)
        {/*lectura del Registry de Windows 23/09/09*/
            try
            {
                switch (seccion)
                {

                    case 1:
                        mobjRegistro = Registry.CurrentUser;
                        break;

                    case 2:
                        mobjRegistro = Registry.LocalMachine;
                        break;

                    default:
                        strValor = "Opción Inválida";
                        break;

                }
                mobjRegistro = mobjRegistro.OpenSubKey(psDirectorio);
                if (mobjRegistro != null)
                {
                    strValor = mobjRegistro.GetValue(psLlave).ToString();
                    if (strValor == "")
                    {
                        MessageBox.Show("Se encontró la instancia " + psLlave + "en el Registry de Windows pero esta vacía", "C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(0);
                    }
                    else
                    {
                        return strValor;
                    }
                }
                else
                {
                    MessageBox.Show("NO se encontró la instancia " + psLlave + "en el Registry", "C430", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(0);
                }

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError("mdlParametros - No se pudo leer Registry de Windows llave=" + psLlave, e);
                Environment.Exit(0);
            }
            return strValor;
        }
		
		public struct TDConsultaS016
		{
			public string NumClienteS;
			public string NumCuentaS;
			public static TDConsultaS016 CreateInstance()
			{
					TDConsultaS016 result = new TDConsultaS016();
					result.NumClienteS = String.Empty;
					result.NumCuentaS = String.Empty;
					return result;
			}
		}
		
		public struct TDConsultaS111
		{
			public string NumCuentaS;
			public static TDConsultaS111 CreateInstance()
			{
					TDConsultaS111 result = new TDConsultaS111();
					result.NumCuentaS = String.Empty;
					return result;
			}
		}
		
		public struct TDCambioS111
		{
			public string NumCuentaS;
			public int MccL;
			public int SkipPaymentI;
			public int PorcentajeDispI;
			public int PinPlaI;
			public int BloqueoI;
			public static TDCambioS111 CreateInstance()
			{
					TDCambioS111 result = new TDCambioS111();
					result.NumCuentaS = String.Empty;
					return result;
			}
		}
		
		public struct TDCveAccesoConComdrive
		{
			public string NominaS;
			public string ClaveS;
			public static TDCveAccesoConComdrive CreateInstance()
			{
					TDCveAccesoConComdrive result = new TDCveAccesoConComdrive();
					result.NominaS = String.Empty;
					result.ClaveS = String.Empty;
					return result;
			}
		}
		
		public struct TDCambioLimCred
		{
			public string CtaBnxS;
			public int LimCredL;
			public static TDCambioLimCred CreateInstance()
			{
					TDCambioLimCred result = new TDCambioLimCred();
					result.CtaBnxS = String.Empty;
					return result;
			}
		}
		
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
		
		static public TDConsultaS016 tgConsultaS016 = mdlParametros.TDConsultaS016.CreateInstance();
		static public TDConsultaS111 tgConsultaS111 = mdlParametros.TDConsultaS111.CreateInstance();
		static public TDCambioS111 tgCambioS111 = mdlParametros.TDCambioS111.CreateInstance();
		static public TDCveAccesoConComdrive tgCveAccesoConComdrive = mdlParametros.TDCveAccesoConComdrive.CreateInstance();
		static public TDCambioLimCred tgCambioLimCred = mdlParametros.TDCambioLimCred.CreateInstance();
		static public TDSeguridad tgSeguridad = mdlParametros.TDSeguridad.CreateInstance();
		
		public enum enuGeneraPlastico
		 {
			gplaSiPlasticoSiPIN = 0 ,
			gplaNoPlasticoNoPIN = 1 ,
			gplaSiPlasticoNoPIN = 2
		}
		
		//Variables para Tipo de Bloqueo
		static public int igIndAltaCteOK = 0;
		static public int igEmpTipoBloqueo = 0;
		
		//Variable para el Dialogo
		static public string sgDialogo = String.Empty;
		
		//Variable para el Tiempo del Comdrive32
		static public int igTimeComDrive = 0;
		
		//Variable para el Nombre de Usuario que realizo el cambio de Limite de Credito
		static public string sgUserCamLimCred = String.Empty;
		
		//*********************************************************************************************
		//*********************************Variables para Altas Masivas********************************
		//*********************************************************************************************
		static public string slctaref = String.Empty;
		static public int llfecarch = 0;
		static public int llmontCred = 0;
		static public int llNumFile = 0;
		static public int llNumFileErr = 0;
		static public string slCadenaValidar = String.Empty;
		static public int llContReg = 0;
		static public int llPos = 0;
		static public string[, ] slRegs = null;
		static public int ilIndice = 0;
		static public int ilIndiceA = 0;
		static public int ilIndiceB = 0;
		static public string slCadena = String.Empty;
		static public string slCaracter = String.Empty;
		static public int ilNumero = 0;
		static public bool blResValidacion = false;
		static public int llConColumna = 0;
		static public int ilTotalColumnas = 0;
		static public int lleje_prefijo = 0;
		static public int llgpo_banco = 0;
		static public int llemp_num = 0;
		static public int llgpo_num = 0;
		static public int llemp_cred_tot = 0;
		static public string slemp_envio_calle = String.Empty;
		static public string slemp_envio_col = String.Empty;
		static public string slemp_envio_ciu = String.Empty;
		static public string slemp_envio_pob = String.Empty;
		static public string slemp_envio_edo = String.Empty;
		static public string slemp_envio_cp = String.Empty;
		static public string slemp_tipo_envio = String.Empty;
		static public string slemp_tipo_fac = String.Empty;
		static public int llemp_skip_payment = 0;
		static public int llemp_tabla_mcc = 0;
		static public int llemp_sector = 0;
		static public int llemp_roll_over = 0;
		static public int llemp_digit = 0;
		static public bool blGrabarMTCMVS01 = false;
		static public string slSubActividad = String.Empty;
		static public int llZonaPos = 0;
		static public bool bColorCambiado = false;
		static public int ilpgs_long_emp = 0;
		static public string[] slUnit = null;
		static public int llRegUnit = 0;
		//*********************************************************************************************
		//*********************************Variables para Altas Masivas********************************
		//*********************************************************************************************
		
		static public void  prWriteIni( string spSection,  string spKeyword,  string spValue)
		{
			try
			{
					
					string slFileName = "Corbnx32.ini";
                    //AIS-1182 NGONZALEZ
					int llSize = API.KERNEL.WritePrivateProfileString(spSection, spKeyword, spValue, slFileName);
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
		}
		
        //static public string fncReadIniS( string spSection,  string spKeyword)
        //{
			
        //    string result = String.Empty;
        //    const int ctelSize = 10240;
        //    const string ctesDefault = "";

        //    StringBuilder slReturnedString = new StringBuilder(ctelSize);
        //    try
        //    {
					
        //            string slFileName = "Corbnx32.ini";
        //            //AIS-1182 NGONZALEZ
        //            int llSize = API.KERNEL.GetPrivateProfileString(spSection, spKeyword, ctesDefault, slReturnedString, ctelSize, slFileName);
        //            result = slReturnedString.ToString().Substring(0, Math.Min(slReturnedString.ToString().Length, llSize));
        //        }
        //    catch (Exception exc)
        //    {
        //        throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //    }
			
        //    return result;
        //}
		
		static public void  prObtenPathsIni()
		{
			
            ////Path Firmas
            //sgPathFirmas = fncReadIniS("Corporativa", "Firmas");
            //if (sgPathFirmas == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path Firmas", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Path Rep. Empresas
            //sgPathRepEmpresas = fncReadIniS("Corporativa", "ReportesEmp");
            //if (sgPathRepEmpresas == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path Rep. Empresas", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Path Rep. Crystal
            //sgPathRepCrystal = fncReadIniS("Corporativa", "ReportesCR");
            //if (sgPathRepCrystal == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path Rep. Crystal", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Path Rep. Corporativos
            //sgPathRepCorporativo = fncReadIniS("Corporativa", "ReportesCorp");
            //if (sgPathRepCorporativo == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path Rep. Corporativos", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Path ComDrive
            //sgPathComDrive = fncReadIniS("Corporativa", "ComDrive");
            //if (sgPathComDrive == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path ComDrive", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Path Word
            //sgPathWord = fncReadIniS("Corporativa", "Word");
            //if (sgPathWord == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path Word", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Path WordDom
            //sgPathWordDom = fncReadIniS("Corporativa", "WordDom");
            //if (sgPathWordDom == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path WordDom", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Path WordCred
            //sgPathWordCred = fncReadIniS("Corporativa", "WordCred");
            //if (sgPathWordCred == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path WordCred", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Path Excel
            //sgPathEXCEL = fncReadIniS("Corporativa", "EXCEL");
            //if (sgPathEXCEL == "")
            //{
            //    MessageBox.Show("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()) + " - Path EXCEL", MessageBoxButtons.OK);
            //    return;
            //}
			
            ////Numero de Reintentos
            //igReintentos = Int32.Parse(fncReadIniS("Corporativa", "Reintentos"));
            //if (igReintentos == 0)
            //{
            //    igReintentos = 5;
            //}
            string rubro = "PATH";
            string path_completo = Environment.GetEnvironmentVariable("PATH");
            string dirExe = Path.GetDirectoryName(Application.ExecutablePath);
            path_completo = path_completo + ";" + dirExe;
            Environment.SetEnvironmentVariable(rubro, path_completo);
            string a = Environment.GetEnvironmentVariable("PATH"); //si se quiere revisar como queda variable de ambiente PATH
            sgEquipoUnix = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Datos", "equipoUNIX").Trim();
            sgPathLogs = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Rutas", "Logs").Trim();
            sgPuertoTandem = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Datos", "puertoTandem").Trim();
            sgPathFirmas = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Rutas", "Firmas").Trim();
            sgPathRepEmpresas = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Rutas", "ReportesEmp").Trim();
            sgPathRepCorporativo = sgPathRepEmpresas;
            //sgPathRepCorporativo = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Rutas", "ReportesCorp").Trim();
            //sgPathEXCEL = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Rutas", "Excel").Trim();
            igReintentos = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Rutas", "Reintentos").Trim());
            if (!Directory.Exists(sgPathLogs))
            {
                Directory.CreateDirectory(sgPathLogs);
            }
            if (!Directory.Exists(sgPathFirmas))
            {
                Directory.CreateDirectory(sgPathFirmas);
            }
            if (!Directory.Exists(sgPathRepEmpresas))
            {
                Directory.CreateDirectory(sgPathRepEmpresas);
            }
		}
		
		static public string fncObtenMesInglesS( int ipMes)
		{
			
			string result = String.Empty;
			switch(ipMes)
			{
				case 1 :  
					result = "Jan"; 
					break;
				case 2 :  
					result = "Feb"; 
					break;
				case 3 :  
					result = "Mar"; 
					break;
				case 4 :  
					result = "Apr"; 
					break;
				case 5 :  
					result = "May"; 
					break;
				case 6 :  
					result = "Jun"; 
					break;
				case 7 :  
					result = "Jul"; 
					break;
				case 8 :  
					result = "Aug"; 
					break;
				case 9 :  
					result = "Sep"; 
					break;
				case 10 :  
					result = "Oct"; 
					break;
				case 11 :  
					result = "Nov"; 
					break;
				case 12 :  
					result = "Dec"; 
					break;
			}
			
			return result;
		}
		
		static public string fncValorOmisionV( string vlDato,  string vlOmision)
		{
			
			try
			{
					
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
					
					if (Convert.IsDBNull(vlDato) || vlDato == "")
					{
						return vlOmision;
					} else
					{
						return vlDato;
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlParametros (ValorOmision)",e );
				return String.Empty;
			}
			return String.Empty;
		}
		
		static public void  prBuscaNombreArch( int IpEnvioSBF)
		{
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " vap_descripcion";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCVAP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where par_id = " + IpEnvioSBF.ToString();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							sgDescArch = VBSQL.SqlData(CORVAR.hgblConexion, 1);
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlParametros (BuscaNombreArch)",e );
				return;
			}
			
			
		}
		
		static public bool fncBuscaGenSbfB()
		{
			
			string slFecha = String.Empty;
			
			try
			{
					
					slFecha = DateTime.Today.ToString("yyyyMMdd");
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_fecha,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_hora,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_estatus";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCPRO03";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where pro_fecha = '" + slFecha + "'";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch = '" + sgDescArch + "'";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_estatus = 13";
					
					
					return CORPROC2.Cuenta_Registros() > 0;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlParametros (BuscaGenSbf)",e );
				return false;
			}
			
			return false;
		}
		
		static public void  prQuitaObjetos()
		{
			//***************************************************************
			//*  Descripción     :   Elimina los objetos en pantalla
			//*  Autor           :   José Ramón González Díaz
			//*  Fecha           :   14 de Noviembre de 2002
			//***************************************************************
			
			try
			{
					
					frmAltasMasivas.DefInstance.pnlProgProceso[0].Visible = false;
					frmAltasMasivas.DefInstance.pnlProgProceso[1].Visible = false;
					
					frmAltasMasivas.DefInstance.lblCamp.Visible = false;
					frmAltasMasivas.DefInstance.lblNumCampo[0].Visible = false;
					frmAltasMasivas.DefInstance.Label1[0].Visible = false;
					frmAltasMasivas.DefInstance.lblNumCampo[1].Visible = false;
					
					frmAltasMasivas.DefInstance.lblRegistro.Visible = false;
					frmAltasMasivas.DefInstance.lblNumRegistro[0].Visible = false;
					frmAltasMasivas.DefInstance.Label1[1].Visible = false;
					frmAltasMasivas.DefInstance.lblNumRegistro[1].Visible = false;
					
					frmAltasMasivas.DefInstance.lblMensaje.Visible = false;
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError("(ValidaInformacion, QuitaObjetos)",e );
			}
			
			
			
		}
		
		
		static public void  Llena_subactividad( int iSector)
		{
			switch(iSector)
			{
				case 1 : 
					slSubActividad = CORCONST.STR_SEC_IND; 
					break;
				case 2 : 
					slSubActividad = CORCONST.STR_SEC_CMR; 
					break;
				case 3 : 
					slSubActividad = CORCONST.STR_SEC_SER; 
					break;
				case 4 : 
					slSubActividad = CORCONST.STR_SEC_COM; 
					break;
				case 5 : 
					slSubActividad = CORCONST.STR_SEC_TRA; 
					break;
				case 6 : 
					slSubActividad = CORCONST.STR_SEC_FIN; 
					break;
				case 7 : 
					slSubActividad = CORCONST.STR_SEC_TNF; 
					break;
				case 8 : 
					slSubActividad = CORCONST.STR_SEC_OTR; 
					break;
			}
		}
		
		static public void  prInsertaLimCred( int lpLimAnterior,  int lpLimNuevo,  string spCtaBnx)
		{
			
			try
			{
                    //CORVAR.pszgblsql = "insert into MTCLIM01 ";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + "(eje_prefijo";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_banco";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",lim_cta_bnx";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",lim_cred_ant";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",lim_cred_post";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",lim_usu_maker";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",lim_nom_maker";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",lim_fecha_maker";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",lim_hora_maker)";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + gprdProducto.PrefijoL.ToString();
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gprdProducto.BancoL.ToString();
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + spCtaBnx + "'";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + lpLimAnterior.ToString();
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + lpLimNuevo.ToString();
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserID + "'";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserName + "'";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",convert(int,convert(char(20),getdate(),112))";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate())))";

                    CORVAR.pszgblsql = "declare @limite_uso_ant int" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "declare @ID int" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "SELECT" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "    @limite_uso_ant = eje_limcred" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "From MTCEJE01" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "Where emp_num = " + spCtaBnx.Substring(6,5).ToString() + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "And eje_num = " + spCtaBnx.Substring(11, 3).ToString() + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "And eje_prefijo = " + spCtaBnx.Substring(0, 4).ToString() + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "And gpo_banco = " + spCtaBnx.Substring(4, 2).ToString() + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "SELECT @ID = isnull(MAX(lim_id),0) +1 from MTCLIM02" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "INSERT INTO MTCLIM02" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(lim_id," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_prefijo," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_roll_over," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_digit," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "lim_cred_ant," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "lim_cred_nvo," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "lim_nomina_maker," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "lim_nombre_maker," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "lim_fecha_maker," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "lim_est_lim_uso)" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "Values" + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(@ID," + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + spCtaBnx.Substring(0, 4).ToString() + ", " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + spCtaBnx.Substring(4, 2).ToString() + ", " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + spCtaBnx.Substring(6, 5).ToString() + ", " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + spCtaBnx.Substring(11, 3).ToString() + ", " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + spCtaBnx.Substring(14, 1).ToString() + ", " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + spCtaBnx.Substring(15, 1).ToString() + ", " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "@limite_uso_ant, " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + lpLimNuevo.ToString() + ", " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + CRSParametros.sgUserID + "', " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + CRSParametros.sgUserName + "', " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "getdate(), " + "\r\n";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "0)";

					if (CORPROC2.Modifica_Registro() != 0)
					{
						return;
					} else
					{
						MessageBox.Show("No se pudo insertar el registro de cambio del Limite de Credito", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlParametros (InsertaLimCred)",e );
				return;
			}
			
		}
		
		//Public Sub prActualizaTablaLim(lpIndice As Long)
		static public void  prActualizaTablaLim()
		{
			
			try
			{
					
					Cursor.Current = Cursors.WaitCursor;
					
					CORVAR.pszgblsql = "update";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCLIM01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " set";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_usu_checker = '" + CRSParametros.sgUserID + "', ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_nom_checker = '" + CRSParametros.sgUserName + "', ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_fecha_checker= convert(int,convert(char(20),getdate(),112)), ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_hora_checker = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where lim_cta_bnx = '" + tgCambioLimCred.CtaBnxS + "'";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_cred_post = " + tgCambioLimCred.LimCredL.ToString();
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
					}
					Application.DoEvents();
					Cursor.Current = Cursors.Default;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("frmEnvioLimCred (ActualizaTablaLim)",e );
				Cursor.Current = Cursors.Default;
				return;
			}
			
		}
	}
}