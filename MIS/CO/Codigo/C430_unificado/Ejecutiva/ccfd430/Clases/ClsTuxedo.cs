using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.IO; 
using System.Runtime.InteropServices; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class ClsTuxedo
	{
	
		//AIS-1182 NGONZALEZ
		
		//Private objTuxedo As Tuxdriver.servicio
		const int MAX_LONG_ARCHIVO_DESTINO = 150;
		
		private struct ControlArchivo
		{
			public string strContenidoArchivo;
			public string strEstado;
			public string strDescEstado;
			public static ControlArchivo CreateInstance()
			{
					ControlArchivo result = new ControlArchivo();
					result.strContenidoArchivo = String.Empty;
					result.strEstado = String.Empty;
					result.strDescEstado = String.Empty;
					return result;
			}
		}
		
		public enum enEstadoTuxedo
		 {
			EnEstadoError = -1 ,
			EnEstadoInicializado = 0 ,
			EnEstadoProcesando = 1 ,
			EnEstadoProcesoCancelado = 2 ,
			EnEstadoFinProceso = 3
		}
		
		private string strNombreArchivoCte = String.Empty; //Archivo a enviar a cliente de VB
		private string strArchivoBuffer = String.Empty; //Archivo temporarl creado en els server de tuxedo para generar el reporte
		private string strArchivoControl = String.Empty; //Archivo Generado por c:\apps\c430\tuxdll.dll para indicar el resultado de la ejecucion del reporte
		
		private enEstadoTuxedo EstadoActual = (enEstadoTuxedo) 0;
		
		
		//#Const DebugMode = 1
#if DebugMode==true
		
		//UPGRADE_TODO: (1035) #If #EndIf block was not upgraded because the expression DebugMode = 1 did not evaluate to True or was not evaluated.
		Const DEBUG_RPT = "DEBUG"
#else
		
		const string DEBUG_RPT = " ";
#endif
		
		public event ErrorHandler Error;
		public delegate void ErrorHandler(ref  int NumeroError, ref  string Descripcion); //Evento que sirva para enviar un codigo de error para el objeto
		public ClsTuxedo(){
			string strEstado = String.Empty;
			string strError = String.Empty;
			int lngError = 0;
			//Dim strEstado As String
			
			try
			{
					strEstado = "";
				}
			catch (Exception excep)
			{
				
				strEstado = "0";
				lngError = Information.Err().Number;
				strError = excep.Message;
				
				int tempRefParam = 0;
				if (Error != null)
				{
					Error(ref tempRefParam, ref strError);
				}
			}
			
		}
	
	
	
	public bool FnGenera_ReporteTux( string Prefijo,  string Banco,  string Empresa,  string Unidad,  string Reporte,  string Frecuencia,  string LongEmpresa,  string LongEjecutivo,  string LongUnidad,  string LongReporte,  string Por_Grupo, ref  string NivelIni, ref  string NivelFin,  string strCicloReporte,  string strFechaIni,  string strFechaFin)
	{
			bool result = false;
			string PorGrupo = String.Empty;
			string strFechaCorte = String.Empty;
			string EmpresaMenor = String.Empty;
			string fecha1 = String.Empty;
			object serv_rep = null;
			string SqlCmd = String.Empty;
			ADODB.Recordset rs1 = null;
			string strCmdShell = String.Empty;
			string strFecha = String.Empty;
			string mstrFechaIni = String.Empty;
			string mstrFechaFin = String.Empty;
			string mstrFechaCorte = String.Empty;
			string strError = String.Empty;
			int lngError = 0;
			string datosRep = String.Empty;
			bool estadoProc = false;
			
			try
			{
					
					
					
					
					result = false;
					
					if (Conversion.Val(Por_Grupo) == 1)
					{
						//Determina si el reporte generado es por grupo o por empresa
						//Por lo que determinará el número de empresa menor para que
						//el reporte lleve ese nombre
						
						if (VBSQL.OpenConn(10) != 0)
						{
							VBSQL.gConn[10].Close();
						} else
						{
							VBSQL.gConn[10].Close();
						}
						
						if (VBSQL.OpenConn(10) == 0)
						{
							SqlCmd = "select distinct emp_num from MTCUNI01 where gpo_num = ";
							SqlCmd = SqlCmd + Empresa + " order by emp_num";
							rs1 = new ADODB.Recordset();
							rs1.Open(SqlCmd, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, -1);
							rs1.MoveFirst();
							EmpresaMenor = Convert.ToString(rs1.Fields["emp_num"].Value);
							rs1.Close();
							rs1 = null;
							VBSQL.gConn[10].Close();
						}
					} else
					{
						EmpresaMenor = Empresa;
					}
					
					if (Unidad.Length <= 5)
					{
						//Determina que la unidad no exceda del maximo permitido
						//para poder continuar con el proceso
						if (strCicloReporte == "C")
						{
							//El reporte se va a hacer al dia de corte
							//strFechaIni = Format(DateAdd("m", -1, Now), "yyyymmdd") 'Regresa el calendario un mes
							//strFechaCorte = Format(DateAdd("d", -1, Now), "mmdd") 'Regresa el calendario un dia y lo deja en el formato mmdd
							
							strFechaCorte = Strings.Mid(strFechaIni, 1, 2) + Strings.Mid(strFechaIni, 4, 2);
							
							if (String.CompareOrdinal(Strings.Mid(strFechaIni, 1, 2), StringsHelper.Format(DateTime.Now.Month, "00")) > 0)
							{
								mstrFechaFin = StringsHelper.Format(DateTime.Now.Year - 1, "0000") + "/" + StringsHelper.Format(Strings.Mid(strFechaIni, 1, 2), "00") + "/" + StringsHelper.Format(Strings.Mid(strFechaIni, 4, 2), "00");
								
							} else
							{
								mstrFechaFin = StringsHelper.Format(DateTime.Now.Year, "0000") + "/" + StringsHelper.Format(Strings.Mid(strFechaIni, 1, 2), "00") + "/" + StringsHelper.Format(Strings.Mid(strFechaIni, 4, 2), "00");
							}
							
							//Regresa el calendario de la fecha calculada un mes
							//para determinar la fecha inicial
							mstrFechaIni = DateTime.Parse(mstrFechaFin).AddMonths(-1).ToString("yyyy/MM/dd");
							mstrFechaIni = DateTime.Parse(mstrFechaIni).AddDays(1).ToString("yyyyMMdd");
							//Formatea la fecha fin
							System.DateTime TempDate = DateTime.FromOADate(0);
							mstrFechaFin = (DateTime.TryParse(mstrFechaFin, out TempDate)) ? TempDate.ToString("yyyyMMdd"): mstrFechaFin;
							//strFechaCorte = strFechaIni
						} else
						{
							//El reporte se va a hacer al dia de ayer
							
							//strFechaIni = Format(DateAdd("d", -1, Now), "yyyymmdd")
							strFechaCorte = "0";
							System.DateTime TempDate2 = DateTime.FromOADate(0);
							mstrFechaIni = (DateTime.TryParse(strFechaIni, out TempDate2)) ? TempDate2.ToString("yyyyMMdd"): strFechaIni;
							System.DateTime TempDate3 = DateTime.FromOADate(0);
							mstrFechaFin = (DateTime.TryParse(strFechaFin, out TempDate3)) ? TempDate3.ToString("yyyyMMdd"): strFechaFin;
						}
						
						strFecha = DateTime.Now.ToString("yyyyMMdd");
						//strFechaFin = Format(DateAdd("d", -1, Now), "yyyymmdd") 'La fecha de finalización del reporte es al dia de ayer
						
						
						//strNombreArchivo =  Prefijo & Banco _
						//& Format(Val(EmpresaMenor), String(Val(LongEmpresa), "0")) _
						//& "/" & strFecha & "." & Format(Val(Unidad), String(Val(LongUnidad), "0")) _
						//& ".rpt" & Format(Val(Reporte), String(Val(LongReporte), "0")) & ".TXT"
						if (! Directory.GetCurrentDirectory().EndsWith("\\"))
						{
							strNombreArchivoCte = Directory.GetCurrentDirectory() + "\\";
						} else
						{
							strNombreArchivoCte = Directory.GetCurrentDirectory();
						}
						//Variable que indica el nombre del reporte generado y es el que enviará al cliente del FTP
						strNombreArchivoCte = strNombreArchivoCte + strFecha + "." + StringsHelper.Format(Conversion.Val(Unidad), new string('0', Convert.ToInt32(Conversion.Val(LongUnidad)))) + ".rpt" + StringsHelper.Format(Conversion.Val(Reporte), new string('0', Convert.ToInt32(Conversion.Val(LongReporte)))) + ".txt";
						//Validará que el nombre del archivo generado no exceda del maximo permitido
						if (strNombreArchivoCte.Length > MAX_LONG_ARCHIVO_DESTINO)
						{
							int tempRefParam = 1;
							string tempRefParam2 = "El nombre del archivo destino excede del maximo permitido:" + MAX_LONG_ARCHIVO_DESTINO.ToString();
							if (Error != null)
							{
								Error(ref tempRefParam, ref tempRefParam2);
							}
							return result;
						} else
						{
							if (FileSystem.Dir(strNombreArchivoCte, FileAttribute.Archive) != "")
							{
								//Borra el archivo destino si es que existe
								File.Delete(strNombreArchivoCte);
							}
						}
					} else
					{
						return result;
					}
					if ((Double.Parse(Reporte) == 13) || (Double.Parse(Reporte) == 14))
					{
						mstrFechaIni = "00000000";
						mstrFechaFin = "00000000";
						//UPGRADE_WARNING: (1068) Nvl(NivelFin, 0) of type Variant is being forced to string.
						//UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
						datosRep = Reporte + " Rep" + Reporte + " " + strFecha + " " + Prefijo + " " + Banco + " " + Empresa + " " + Unidad + " " + mstrFechaIni + " " + mstrFechaFin + " " + strFechaCorte + " " + Convert.ToString(MdlCambioMasivo.Nvl(NivelIni, "0")) + " " + Convert.ToString(MdlCambioMasivo.Nvl(NivelFin, "0")) + " " + this.strBuffer + " " + PorGrupo;
						MessageBox.Show(datosRep, Application.ProductName);
					}
					if ((Double.Parse(Reporte) == 18) || (Double.Parse(Reporte) == 20) || (Double.Parse(Reporte) == 22) || (Double.Parse(Reporte) == 24) || (Double.Parse(Reporte) == 26))
					{
						mstrFechaIni = "00000000";
						mstrFechaFin = "00000000";
						//UPGRADE_WARNING: (1068) Nvl(NivelFin, 0) of type Variant is being forced to string.
						//UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
						datosRep = Reporte + " Rep" + Reporte + " " + strFecha + " " + Prefijo + " " + Banco + " " + Empresa + " " + Unidad + " " + strFechaCorte + " " + Convert.ToString(MdlCambioMasivo.Nvl(NivelIni, "0")) + " " + Convert.ToString(MdlCambioMasivo.Nvl(NivelFin, "0")) + " " + this.strBuffer + " " + Por_Grupo + " " + "0";
						MessageBox.Show(datosRep, Application.ProductName);
					}
					if ((Double.Parse(Reporte) == 15) || (Double.Parse(Reporte) == 16) || (Double.Parse(Reporte) == 23) || (Double.Parse(Reporte) == 25))
					{
						strFechaCorte = "0000";
					}
					if (this.strBuffer != "")
					{
						Estado = enEstadoTuxedo.EnEstadoInicializado; //Inicializa el estado
						//del objeto para disparar el
						//el evento asyncrono de tuxedo
						if (Estado == enEstadoTuxedo.EnEstadoInicializado)
						{ //El objeto se logro inicializar
							//datosRep$ = Reporte & " Rep" & Reporte & " " & strFecha & " " & Prefijo & " " & Banco & " " & Empresa & " " & Unidad & " " & mstrFechaIni & " " & mstrFechaFin & " " & strFechaCorte & " 0 0 " & Me.strBuffer & "0"
							//datosRep$ = Reporte & " Rep" & Reporte & " " & strFecha & " " & Prefijo & " " & Banco & " " & Empresa & " " & Unidad & " " & strFechaCorte & " 0 9 " & Me.strBuffer & " " & "0 " & "0"
							mdlTuxedo.Inicia_VarEnv();
							mdlTuxedo.Conecta_Tuxedo();
							mdlTuxedo.reserva_libera(2);
							//        FnGenera_ReporteTux = Envia(datosRep$, strNombreArchivoCte)
							estadoProc = mdlConectividad.Envia(datosRep, strNombreArchivoCte) != 0;
							mdlTuxedo.Desconecta_Tuxedo();
							//datosRep$ = "18 REP_18 20050918 4943 88 747 1304 917 0 9 file_c.tmp 0 0"
							//                   INICIA BLOQUE ANTERIOR quitó Yuria 14/02/06
							//Call setbGrupo(Por_Grupo)
							//Call setPrefijo(Prefijo)
							//Call setBanco(Banco)
							//Call setEmpresa(Empresa)
							//Call setFecha(strFecha)
							//Call setFechaCorteMD(strFechaCorte)
							//Call setFechaIniAMD(mstrFechaIni)
							//Call setFechaFinAMD(mstrFechaFin)
							//Call setFrecuencia(Frecuencia)
							//Call setNivelIni(Nvl(NivelIni, "0"))
							//Call setNivelFin(Nvl(NivelFin, "0"))
							//Call setNombreRep("Rep" & Reporte)
							//Call setReporte(Trim(Reporte))
							//Call setUnidad(Unidad)
							//Call setArchivoDisco(strNombreArchivoCte) 'Archivo que se va a generar en el cliente
							//Call setArchivoTemp(Me.strBuffer) 'Archivo que se va a generar en el server de tuxedo
							//Call setbTotales("0")
							
							
							//If Me.strBuffer <> "" Then
							//    Estado = EnEstadoInicializado 'Inicializa el estado
							//                                     'del objeto para disparar el
							//                                     'el evento asyncrono de tuxedo
							//    If Estado = EnEstadoInicializado Then 'El objeto se logro inicializar
							//        Call ejecuta(DEBUG_RPT)
							//        Do
							//            DoEvents
							//            Estado = EnEstadoProcesando 'Indica que el estado actual del tuxedo es procesando
							//        Loop While Estado = EnEstadoProcesando 'Verifica el estado del archivo mientras no ocurra un error o el proceso finalice
							//        FnGenera_ReporteTux = Estado = EnEstadoFinProceso 'Verifica que el estado actual no sea error
							result = Estado != enEstadoTuxedo.EnEstadoInicializado == estadoProc;
						}
					}
					//                   FIN BLOQUE ANTERIOR quitó Yuria 14/02/06
				}
			catch (Exception excep)
			{
				
				//    Resume
				EstadoActual = enEstadoTuxedo.EnEstadoError;
				strError = excep.Message;
				lngError = Information.Err().Number;
				if (Error != null)
				{
					Error(ref lngError, ref strError);
				}
				
				if (rs1.State != 0)
				{
					rs1.Close();
				}
				
				if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
				{
					VBSQL.gConn[10].Close();
				}
			}
			
			return result;
	}
	
	public bool FnGenera_ReporteTux( string Prefijo,  string Banco,  string Empresa,  string Unidad,  string Reporte,  string Frecuencia,  string LongEmpresa,  string LongEjecutivo,  string LongUnidad,  string LongReporte,  string Por_Grupo, ref  string NivelIni, ref  string NivelFin,  string strCicloReporte,  string strFechaIni)
	{
			return FnGenera_ReporteTux(Prefijo, Banco, Empresa, Unidad, Reporte, Frecuencia, LongEmpresa, LongEjecutivo, LongUnidad, LongReporte, Por_Grupo, ref NivelIni, ref NivelFin, strCicloReporte, strFechaIni, "");
	}
	
	public string strArchivoGenerado
	{
		get
		{
		//Determina el nombre del archivo generado por el componente de tuxedo
		return strNombreArchivoCte;
		}
	}
	
	public string strBuffer
	{
		get
		{
		return strArchivoBuffer;
		}
		set
		{
		strArchivoBuffer = value;
		}
	}
	
	public enEstadoTuxedo Estado
	{
		get
		{
		return EstadoActual; //Cuando el estado es "-1"
		//quiere decir que hubo un
		//error al inicializar el objeto
		}
		set
		{
		//Dim mStrArchivoCtrl As String
		int mLngNoError = 0;
		string mStrDescError = String.Empty;
		
		try
		{
			if (value == enEstadoTuxedo.EnEstadoInicializado)
			{
				strArchivoControl = Directory.GetCurrentDirectory();
				if (! strArchivoControl.EndsWith("\\"))
				{
					strArchivoControl = strArchivoControl + "\\";
				}
				strArchivoControl = strArchivoControl + "received.ctl";
				
				
				if (FileSystem.Dir(strArchivoControl, FileAttribute.Archive) != "")
				{
					File.Delete(strArchivoControl);
				}
			} else if (value == enEstadoTuxedo.EnEstadoProcesando || value == enEstadoTuxedo.EnEstadoFinProceso) { 
				//Cuando el estado actual es procesando
				//verifica que el archivo de control exista
				//de sera así cambia su estado a fin de proceso
				if (EstadoActual == enEstadoTuxedo.EnEstadoInicializado || EstadoActual == enEstadoTuxedo.EnEstadoProcesando || EstadoActual == enEstadoTuxedo.EnEstadoFinProceso)
				{
					if (FileSystem.Dir(strArchivoControl, FileAttribute.Archive) == "")
					{
						EstadoActual = enEstadoTuxedo.EnEstadoProcesando;
					} else
					{
						EstadoActual = enEstadoTuxedo.EnEstadoFinProceso;
					}
				}
			} else
			{
				EstadoActual = value;
				
			}
			}
		catch (Exception excep)
		{
		
		mLngNoError = Information.Err().Number;
		mStrDescError = "Descripción: " + excep.Message + "\r\n" + "Fuente del Error:" + excep.Source + "\r\n" + "Objeto: ClsTuxedo.Estado";
		
		
		
		EstadoActual = enEstadoTuxedo.EnEstadoError;
		if (Error != null)
		{
		Error(ref mLngNoError, ref mStrDescError);
		}
		}
		}
	}
	
	
	public void  PrDetenerReporte()
	{
			Estado = enEstadoTuxedo.EnEstadoProcesoCancelado; //Mueve el estado a Proceso Cancelado
	}
	public void  PrResultadoRpt(ref  string PStrResultado, ref  string PStrDescResultado)
	{
			int mintFreeFile = 0;
			string mStrContenidoFile = String.Empty;
			int mLngError = 0;
			string mStrDescError = String.Empty;
			//UPGRADE_WARNING: (1042) Array ArrControlArchivo may need to have individual elements initialized.
			ControlArchivo[] ArrControlArchivo = ArraysHelper.InitializeArray<ControlArchivo[]>(new int[]{4});
			bool mBolEncontrado = false;
			
			
			try
			{
					ArrControlArchivo[0].strContenidoArchivo = "Cancel";
					ArrControlArchivo[0].strEstado = "0";
					ArrControlArchivo[0].strDescEstado = "Cancelado Por el Usuario";
					
					ArrControlArchivo[1].strContenidoArchivo = "Success";
					ArrControlArchivo[1].strEstado = "1";
					ArrControlArchivo[1].strDescEstado = "Reporte Exitoso";
					
					ArrControlArchivo[2].strContenidoArchivo = "Failure";
					ArrControlArchivo[2].strEstado = "2";
					ArrControlArchivo[2].strDescEstado = "Reporte Fallo";
					
					ArrControlArchivo[3].strContenidoArchivo = "Warning";
					ArrControlArchivo[3].strEstado = "3";
					ArrControlArchivo[3].strDescEstado = "Sin datos";
					
					if (this.Estado != enEstadoTuxedo.EnEstadoProcesoCancelado)
					{
						
						
						mintFreeFile = FileSystem.FreeFile();
						PStrResultado = "-1"; //Valores a enviar cuando
						PStrDescResultado = "Error Desconocido "; //El archivo este vacio o
						//El contenido del archivo no este dentro del arreglo
						
						FileSystem.FileOpen(mintFreeFile, strArchivoControl, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
						
						while(! FileSystem.EOF(mintFreeFile))
						{
							FileSystem.Input(mintFreeFile, ref mStrContenidoFile);
							if (mStrContenidoFile.Trim() != "")
							{
								mBolEncontrado = false;
								for (int mIntCadenasControl = 1; mIntCadenasControl <= ArrControlArchivo.GetUpperBound(0); mIntCadenasControl++)
								{
									//Barre el contenido de las cadenas de control para saber el resultado del reporte
									if (mStrContenidoFile.IndexOf(ArrControlArchivo[mIntCadenasControl].strContenidoArchivo, StringComparison.CurrentCultureIgnoreCase) >= 0)
									{
										//La cadena de control ya se encontro
										//por lo tanto este es el estado enviado al cliente
										PStrResultado = ArrControlArchivo[mIntCadenasControl].strEstado;
										PStrDescResultado = ArrControlArchivo[mIntCadenasControl].strDescEstado;
										mBolEncontrado = true;
										break; //Sale del ciclo y para dejar de leer el contenido del archivo
									}
									
								}
								if (! mBolEncontrado)
								{
									//Envia el contenido del archivo al cliente ya que es un error no controlado
									PStrResultado = "-1";
									PStrDescResultado = PStrDescResultado + new String(' ', 5) + mStrContenidoFile;
								} else
								{
									break; //Deja de barrer el contenido del archivo de datos
								}
							}
						};
						FileSystem.FileClose(mintFreeFile);
					} else
					{
						PStrResultado = ArrControlArchivo[0].strEstado; //Estado de error indicando que el proceso fue cancelado
						PStrDescResultado = ArrControlArchivo[0].strDescEstado; //Por el usuario
					}
				}
			catch (Exception excep)
			{
				
				
				mLngError = Information.Err().Number;
				mStrDescError = excep.Message;
				if (Error != null)
				{
					Error(ref mLngError, ref mStrDescError);
				}
			}
			
	}
}
}