using Microsoft.VisualBasic; 
using System; 
using System.IO; 
using System.Runtime.InteropServices; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class mdlTuxedo
	{
	
		
		static public string GsDNS = String.Empty;
		static public string GsDB = String.Empty;
		static public string GsUSER = String.Empty;
		static public string GsPWDS = String.Empty;
		static public string GsNomina = String.Empty;
		static public string GsIP = String.Empty;
		
		static public string PsRegistro = String.Empty;
		static public int GiMinutos = 0; //Tiempo Inicial
		static public int GiTFin = 0; //Tiempo Final
		
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//Variables para Valores de los Campos FML32 de CI
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		static public string G_ID_DDE = String.Empty;
		static public int G_ID_OPERADOR = 0;
		static public string G_PSW_OPERADOR = String.Empty;
		static public int G_NUM_SESION = 0;
		static public int G_OFITRABAJO_OPE = 0;
		static public string G_NOMBRE_OPERADOR = String.Empty;
		static public int G_CODIGO_RESPUESTA = 0;
		static public string G_MENS_RESPUESTA = String.Empty;
		static public string IP_CI_INI = String.Empty;
		static public string IP_WS_INI = String.Empty;
		static public string G_WSINTOPPRE71 = String.Empty;
		static public int GiAmbiente = 0;
		static public string i_Clave_Operacion = String.Empty;
		static public string i_Importe_Operacion = String.Empty;
		
		
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//Flag values used with TPINIT
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		public const int TPU_MASK = 7;
		public const int TPU_SIG = 1;
		public const int TPU_DIP = 2;
		public const int TPU_IGN = 4;
		public const int TPSA_FASTPATH = 8;
		public const int TPSA_PROTECTED = 16;
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//Flag values used when calling ATMI functions
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		public const int TPNOBLOCK = 1;
		public const int TPSIGRSTRT = 2;
		public const int TPNOREPLY = 4;
		public const int TPNOTRAN = 8;
		public const int TPTRAN = 16;
		public const int TPNOTIME = 32;
		public const int TPABSOLUTE = 64;
		public const int TPGETANY = 128;
		public const int TPNOCHANGE = 256;
		public const int TPCONV = 1024;
		public const int TPSENDONLY = 2048;
		public const int TPRECVONLY = 4096;
		public const int TPACK = 8192;
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//Conversations Events
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		public const int TPEV_DISCONIMM = 1;
		public const int TPEV_SVCERR = 2;
		public const int TPEV_SVCFAIL = 4;
		public const int TPEV_SVCSUCC = 8;
		public const int TPEV_SENDONLY = 32;
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		// Definitions for ATMI functions
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//AIS-1182 NGONZALEZ
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//  Buffer
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		public struct tuxbuf
		{
			public IntPtr bufptr;
		}
		
		static public tuxbuf Cadena = new tuxbuf();
		static public tuxbuf respuesta = new tuxbuf();
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//Campos FML32 para el Secuenciador CI
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//Global Const F_TYPE = 601
		//Global Const F_DATA = 602
		public const int F_TYPE = 167772761;
		public const int F_DATA = 167772762;
		
		public const int LEN_TYPE = 4;
		public const int LEN_DATA = 256;
		
		//AIS-1182 NGONZALEZ
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//RESERVACION DE MEMORIA
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		static public void  reserva_libera( int i)
		{
			try
			{
					if (i != 0)
					{//AIS-1182 NGONZALEZ
						Cadena.bufptr =(IntPtr) API.libwsc.tpalloc("FML32", "", 4096);
                        //AIS-1182 NGONZALEZ
                        respuesta.bufptr = (IntPtr)API.libwsc.tpalloc("FML32", "", 4096);
						
						if ((int)Cadena.bufptr == 0)
						{
							string tempRefParam = "Reservando Memoria para Envío";
							TuxError(ref tempRefParam);
						}
						if ((int)respuesta.bufptr == 0)
						{
							string tempRefParam2 = "Reservando Memoria para Respuesta";
							TuxError(ref tempRefParam2);
						}
						
					} else
                    {//AIS-1182 NGONZALEZ
						API.Tux.tpfree(Cadena.bufptr);
                        API.Tux.tpfree(respuesta.bufptr);
					}
				}
			catch 
			{
			}
			
			
			
		}
		
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//MENSAJES DE ERROR DE LAS VARIABLES DE TUXEDO
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		static public void  TuxError(ref  string StrTitle)
		{
			string tuxstr = String.Empty, msg = String.Empty;
			//AIS-1182 NGONZALEZ
			int tperrno = API.libwsc.gettperrno();
			switch(tperrno)
			{
				case 0 : 
					tuxstr = "TPMINVAL"; 
					break;
				case 1 : 
					tuxstr = "TPEABORT"; 
					break;
				case 2 : 
					tuxstr = "TPEBADDESC"; 
					break;
				case 3 : 
					tuxstr = "TPEBLOCK"; 
					break;
				case 4 : 
					tuxstr = "TPEINVAL"; 
					break;
				case 5 : 
					tuxstr = "TPELIMIT"; 
					break;
				case 6 : 
					tuxstr = "TPENOENT "; 
					break;
				case 7 : 
					tuxstr = "TPEOS"; 
					break;
				case 8 : 
					tuxstr = "TPEPERM"; 
					break;
				case 9 : 
					tuxstr = "TPEPROTO"; 
					break;
				case 10 : 
					tuxstr = "TPESVCERR"; 
					break;
				case 11 : 
					tuxstr = "TPESVCFAIL"; 
					break;
				case 12 : 
					tuxstr = "TPESYSTEM"; 
					break;
				case 13 : 
					tuxstr = "TPETIME"; 
					break;
				case 14 : 
					tuxstr = "TPETRAN"; 
					break;
				case 15 : 
					tuxstr = "TPGOTSIG"; 
					break;
				case 16 : 
					tuxstr = "TPERMERR"; 
					break;
				case 17 : 
					tuxstr = "TPEITYPE"; 
					break;
				case 18 : 
					tuxstr = "TPEOTYPE"; 
					break;
				case 19 : 
					tuxstr = "TPERELEASE"; 
					break;
				case 20 : 
					tuxstr = "TPEHAZARD"; 
					break;
				case 21 : 
					tuxstr = "TPEHEURISTIC"; 
					break;
				case 22 : 
					tuxstr = "TPEEVENT"; 
					break;
				case 23 : 
					tuxstr = "TPEMATCH"; 
					break;
				case 24 : 
					tuxstr = "TPEDIAGNOSTIC"; 
					break;
				case 25 : 
					tuxstr = "TPMAXVAL"; 
					break;
				default:
					tuxstr = "TPERROR"; 
					break;
			}
			
			//msg$ = "TuxError " + Str$(tperrno%) + ": " + tuxstr$
			//MsgBox msg$, vbCritical, StrTitle
			EscribeLog(tperrno, tuxstr, "TUXEDO", StrTitle);
			
		}
		
		static public void  EscribeLog( int NumErr,  string msjErr,  string TIPO,  string Title)
		{
			
			string valfech = String.Empty;

            string NomArch = Path.GetDirectoryName(Environment.SpecialFolder.ApplicationData.ToString()) + "\\ULOG." + DateTime.Now.ToString("MMddyy");
			FileSystem.FileOpen(1, NomArch, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
			string msgBit = DateTime.Now.ToString("HHNmSs") + ":" + Title + ": " + TIPO + ": " + "ERROR " + NumErr.ToString() + ": " + msjErr;
			FileSystem.PrintLine(1, msgBit);
			FileSystem.FileClose(1);
			
		}
		
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//MENSAJES DE ERROR DE LAS FUNCIONES DE LOS BUFFER FML32
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		static public void  Fml32Error( string StrTitle)
		{
			string tuxstr = String.Empty, msg = String.Empty;
			//AIS-1182 NGONZALEZ
			int f32errno = API.FML.getFerror32();
			switch(f32errno)
			{
				case 0 : 
					tuxstr = "FMINVAL"; 
					break;
				case 1 : 
					tuxstr = "FALIGNERR-Fielded buffer not aligned."; 
					break;
				case 2 : 
					tuxstr = "FNOTFLD-Buffer not fielded."; 
					break;
				case 3 : 
					tuxstr = "FNOSPACE-No space in fielded buffer."; 
					break;
				case 4 : 
					tuxstr = "FNOTPRES-Field not present."; 
					break;
				case 5 : 
					tuxstr = "FBADFLD-Unknown field number or type."; 
					break;
				case 6 : 
					tuxstr = "FTYPERR-Illegal field type."; 
					break;
				case 7 : 
					tuxstr = "FEUNIX-UNIX system call error."; 
					break;
				case 8 : 
					tuxstr = "FBADNAME-Unknown field name."; 
					break;
				case 9 : 
					tuxstr = "FMALLOC-Malloc failed."; 
					break;
				case 10 : 
					tuxstr = "FSYNTAX-Bad syntax in boolean expression."; 
					break;
				case 11 : 
					tuxstr = "FFTOPEN-Cannont find or open field table"; 
					break;
				case 12 : 
					tuxstr = "FFTSYNTAX-Syntax error in field table"; 
					break;
				case 13 : 
					tuxstr = "FEINVAL-Invalid argument to function"; 
					break;
				case 14 : 
					tuxstr = "FBADTBL-Destructive concurrent access to field table"; 
					break;
				case 15 : 
					tuxstr = "FBADVIEW-Cannot find or get view"; 
					break;
				case 16 : 
					tuxstr = "FVFSYNTAX-Syntax error in viewfile."; 
					break;
				case 17 : 
					tuxstr = "FVFOPEN-Cannot find or open viewfile."; 
					break;
				case 18 : 
					tuxstr = "FBADACM-ACM contains negative value."; 
					break;
				case 19 : 
					tuxstr = "FNOCNAME-Cname not found."; 
					break;
				case 20 : 
					tuxstr = "FMAXVAL"; 
					break;
				default:
					tuxstr = "FMLERROR"; 
					break;
			}
			
			string tempRefParam = "Cobranza Pemex";
			SSSErr(f32errno, tuxstr, ref tempRefParam);
			
		}
		
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//MENSAJES DE ERROR DEL SECUENCIADOR CI
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		static public void  SSSErr( int NumErr,  string StrErr, ref  string StrTitle)
		{
			string msg = "SSSError " + Conversion.Str(NumErr) + ": " + StrErr;
			MessageBox.Show(msg, StrTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//CARGA DE LAS VARIABLES DE AMBIENTE
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		static public bool Inicia_VarEnv()
		{
			bool result = false;
			bool Err_Inicia_VarEnv = false;
			string lsWSNADDR = String.Empty, lsLIB = String.Empty, lsTUXDIR = String.Empty, lsAPPDIR = String.Empty, lsINCLUDE = String.Empty, lsWSTYPE = String.Empty;
			string TuxDirIni = String.Empty, IP_CI = String.Empty;
			bool InVaIni = false;
			try
			{
					Err_Inicia_VarEnv = true;
					result = false;
					
					
					//lsWSNADDR = "//10.110.86.14:4025"
					lsWSNADDR = Interaction.Environ("WSNADDR");
                    //AIS-1182 NGONZALEZ
                     if (API.Tux.tuxputenv("WSNADDR=" + lsWSNADDR) == -1)
					{
						string tempRefParam = "Variables de Ambiente";
						TuxError(ref tempRefParam);
						return result;
					}
					//lsAPPDIR = "C:\apps\c430"
					lsAPPDIR = Interaction.Environ("APPDIR");
                    //AIS-1182 NGONZALEZ
					if (API.Tux.tuxputenv("APPDIR=" + lsAPPDIR) == -1)
					{
						string tempRefParam2 = "Variables de Ambiente";
						TuxError(ref tempRefParam2);
						return result;
					}
					
					lsWSTYPE = "PC";
                    //AIS-1182 NGONZALEZ
					if (API.Tux.tuxputenv("WSTYPE=" + lsWSTYPE) == -1)
					{
						string tempRefParam3 = "Variables de Ambiente";
						TuxError(ref tempRefParam3);
						return result;
					}
                //AIS-1182 NGONZALEZ
					if (API.Tux.tuxputenv("ULOGPFX=" + Path.GetDirectoryName(Application.ExecutablePath) + "\\ULOG") == -1)
					{
						string tempRefParam4 = "Variables de Ambiente";
						TuxError(ref tempRefParam4);
						return result;
					}
					G_WSINTOPPRE71 = "Y";
                    //AIS-1182 NGONZALEZ
					if (API.Tux.tuxputenv("WSINTOPPRE71=" + G_WSINTOPPRE71) == -1)
					{
						string tempRefParam5 = "Variables de Ambiente";
						TuxError(ref tempRefParam5);
						return result;
					}
					return true;
				}
			catch (Exception excep)
			{
				if (! Err_Inicia_VarEnv)
				{
					throw excep;
				}
				//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
				throw new Exception("Migration Exception: 'Resume' not supported");
				if (Err_Inicia_VarEnv)
				{
					
					MessageBox.Show(Information.Err().Number.ToString() + ":" + excep.Message, Application.ProductName);
				}
			}
			return result;
		}
		
		static public string GetIniFile( string section,  string key,  string file)
		{
			string result = String.Empty;
			result = "unknown";
			string tmpStr = new string((char) 0, 255);
            StringBuilder retval = new StringBuilder(tmpStr);
            //AIS-1182 NGONZALEZ
			int worked = API.KERNEL.GetPrivateProfileString(section, key, "", retval,(short) retval.Length, file);
			if (worked == 0)
			{
				return "unknown";
			} else
			{
				return retval.ToString().Substring(0, Math.Min(retval.Length, retval.ToString().IndexOf(Strings.Chr(0).ToString())));
			}
		}
		
		
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//CONEXION TUXEDO
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		static public bool Conecta_Tuxedo()
		{
			bool result = false;
            //AIS-1182 NGONZALEZ
			int rc = API.libwsc.tpinit(0);
			if (rc < 0)
			{
				string tempRefParam = "Conexión Tuxedo";
				TuxError(ref tempRefParam);
				return false;
			} else
			{
				result = true;
			}
			return result;
		}
		
		
		static public string ClsStr( string str_Renamed)
		{
			string result = String.Empty;
			StringBuilder LsStr = new StringBuilder();
			LsStr.Append(String.Empty);
			string LsChr = String.Empty;
			
			try
			{
					
					LsStr = new StringBuilder("");
					for (int i = 1; i <= str_Renamed.Length; i++)
					{
						LsChr = Strings.Mid(str_Renamed, i, 1);
						if (((int) LsChr[0]) == ((int) '.'))
						{
							return LsStr.ToString();
						}
						
						if (((int) LsChr[0]) >= ((int) '0') && ((int) LsChr[0]) <= ((int) '9'))
						{
							LsStr.Append(LsChr);
						}
						
						if (((int) LsChr[0]) >= ((int) 'a') && ((int) LsChr[0]) <= ((int) 'z'))
						{
							LsStr.Append(LsChr);
						}
						
						if (((int) LsChr[0]) >= ((int) 'A') && ((int) LsChr[0]) <= ((int) 'Z'))
						{
							LsStr.Append(LsChr);
						}
						
						if (((int) LsChr[0]) == ((int) '_'))
						{
							LsStr.Append(LsChr);
						}
						
						
					}
					return LsStr.ToString();
				}
			catch 
			{
				
				result = str_Renamed;
			}
			return result;
		}
		
		
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		//DESCONEXION TUXEDO
		//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		static public bool Desconecta_Tuxedo()
		{
			
			bool result = false;
			int rc =API.libwsc.tpterm();
			if (rc < 0)
			{
				string tempRefParam = "Desconexión Tuxedo";
				TuxError(ref tempRefParam);
				Environment.Exit(0);
			} else
			{
				result = true;
			}
			
			return result;
		}
	}
}