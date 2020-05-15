using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class CORDBLIB
	{
	
		// Global declarations for Visual Basic to DB-Library translation dll.
		// Used by all apps linking with the SOINSQL DLL (SNAPSQL.VBX)
		
		// Global return values for all RETCODE type functions
		//Global Const SUCCEED% = 1
		//Global Const FAIL% = 0
		
		// return values permitted in error handlers
		public const int INTEXIT = 0;
		//Global Const INTCONTINUE% = 1
		public const int INTCANCEL = 2;
		
		//Global Const MOREROWS = -1
		//Global Const NOMOREROWS = -2
		public const int REGROW = -1;
		public const int BUFFULL = -3;
		
		// Status code for dbresults(). Possible return values are
		// SUCCEED, FAIL, and NO_MORE_RESULTS.
		
		public const int NOMORERESULTS = 2;
		
		
		
		// option values permitted in option setting/querying/clearing
		// used by SqlSetOpt%(), SqlIsOpt%(), and SqlClrOpt%().
		
		public const int SQLBUFFER = 0;
		public const int SQLOFFSET = 1;
		public const int SQLROWCOUNT = 2;
		public const int SQLSTAT = 3;
		public const int SQLTEXTLIMIT = 4;
		public const int SQLTEXTSIZE = 5;
		public const int SQLARITHABORT = 6;
		public const int SQLARITHIGNORE = 7;
		public const int SQLNOAUTOFREE = 8;
		public const int SQLNOCOUNT = 9;
		public const int SQLNOEXEC = 10;
		public const int SQLPARSEONLY = 11;
		public const int SQLSHOWPLAN = 12;
		public const int SQLSTORPROCID = 13;
		
		// Data type token values.  Used for datatype determination for a column.
		
		public const int SQLTEXT = 0x23;
		public const int SQLARRAY = 0x24;
		public const int SQLVARBINARY = 0x25;
		public const int SQLINTN = 0x26;
		public const int SQLVARCHAR = 0x27;
		public const int SQLBINARY = 0x2D;
		public const int SQLIMAGE = 0x22;
		public const int SQLCHAR = 0x2F;
		public const int SQLINT1 = 0x30;
		public const int SQLBIT = 0x32;
		public const int SQLINT2 = 0x34;
		public const int SQLINT4 = 0x38;
		public const int SQLMONEY = 0x3C;
		public const int SQLDATETIME = 0x3D;
		public const int SQLFLT8 = 0x3E;
		public const int SQLFLTN = 0x6D;
		public const int SQLFLT4 = 0x3B;
		public const int SQLMONEYN = 0x6E;
		public const int SQLDATETIMN = 0x6F;
		public const int SQLAOPCNT = 0x4B;
		public const int SQLAOPSUM = 0x4D;
		public const int SQLAOPAVG = 0x4F;
		public const int SQLAOPMIN = 0x51;
		public const int SQLAOPMAX = 0x52;
		public const int SQLAOPANY = 0x53;
		public const int SQLAOPNOOP = 0x56;
		public const int SQLMONEY4 = 0x7A;
		public const int SQLDATETIM4 = 0x3A;
		
		
		
		// error numbers VBSQL error codes that are passed to local error
		// handler
		
		public const int SQLEMEM = 10000;
		public const int SQLENULL = 10001;
		public const int SQLENLOG = 10002;
		public const int SQLEPWD = 10003;
		public const int SQLECONN = 10004;
		public const int SQLEDDNE = 10005;
		public const int SQLNULLO = 10006;
		public const int SQLESMSG = 10007;
		public const int SQLEBTOK = 10008;
		public const int SQLENSPE = 10009;
		public const int SQLEREAD = 10010;
		public const int SQLECNOR = 10011;
		public const int SQLETSIT = 10012;
		public const int SQLEPARM = 10013;
		public const int SQLEAUTN = 10014;
		public const int SQLECOFL = 10015;
		public const int SQLERDCN = 10016;
		public const int SQLEICN = 10017;
		public const int SQLECLOS = 10018;
		public const int SQLENTXT = 10019;
		public const int SQLEDNTI = 10020;
		public const int SQLETMTD = 10021;
		public const int SQLEASEC = 10022;
		public const int SQLENTLL = 10023;
		public const int SQLETIME = 10024;
		public const int SQLEWRIT = 10025;
		public const int SQLEMODE = 10026;
		public const int SQLEOOB = 10027;
		public const int SQLEITIM = 10028;
		public const int SQLEDBPS = 10029;
		public const int SQLEIOPT = 10030;
		public const int SQLEASNL = 10031;
		public const int SQLEASUL = 10032;
		public const int SQLENPRM = 10033;
		public const int SQLEDBOP = 10034;
		public const int SQLENSIP = 10035;
		public const int SQLECNULL = 10036;
		public const int SQLESEOF = 10037;
		public const int SQLERPND = 10038;
		public const int SQLECSYN = 10039;
		public const int SQLENONET = 10040;
		public const int SQLEBTYP = 10041;
		public const int SQLEABNC = 10042;
		public const int SQLEABMT = 10043;
		public const int SQLEABNP = 10044;
		public const int SQLEBNCR = 10045;
		public const int SQLEAAMT = 10046;
		public const int SQLENXID = 10047;
		public const int SQLEIFNB = 10048;
		public const int SQLEKBCO = 10049;
		public const int SQLEBBCI = 10050;
		public const int SQLEKBCI = 10051;
		public const int SQLEBCWE = 10052;
		public const int SQLEBCNN = 10053;
		public const int SQLEBCOR = 10054;
		public const int SQLEBCPI = 10055;
		public const int SQLEBCPN = 10056;
		public const int SQLEBCPB = 10057;
		public const int SQLEVDPT = 10058;
		public const int SQLEBIVI = 10059;
		public const int SQLEBCBC = 10060;
		public const int SQLEBCFO = 10061;
		public const int SQLEBCVH = 10062;
		public const int SQLEBCUO = 10063;
		public const int SQLEBUOE = 10064;
		public const int SQLEBWEF = 10065;
		public const int SQLEBTMT = 10066;
		public const int SQLEBEOF = 10067;
		public const int SQLEBCSI = 10068;
		public const int SQLEPNUL = 10069;
		public const int SQLEBSKERR = 10070;
		public const int SQLEBDIO = 10071;
		public const int SQLEBCNT = 10072;
		public const int SQLEMDBP = 10073;
		public const int SQLEINIT = 10074;
		public const int SQLCRSINV = 10075;
		public const int SQLCRSCMD = 10076;
		public const int SQLCRSNOIND = 10077;
		public const int SQLCRSDIS = 10078;
		public const int SQLCRSAGR = 10079;
		public const int SQLCRSORD = 10080;
		public const int SQLCRSMEM = 10081;
		public const int SQLCRSBSKEY = 10082;
		public const int SQLCRSNORES = 10083;
		public const int SQLCRSVIEW = 10084;
		public const int SQLCRSBUFR = 10085;
		public const int SQLCRSFROWN = 10086;
		public const int SQLCRSBROL = 10087;
		public const int SQLCRSFRAND = 10088;
		public const int SQLCRSFLAST = 10089;
		public const int SQLCRSRO = 10090;
		public const int SQLCRSTAB = 10091;
		public const int SQLCRSUPDTAB = 10092;
		public const int SQLCRSUPDNB = 10093;
		public const int SQLCRSVIIND = 10094;
		public const int SQLCRSNOUPD = 10095;
		public const int SQLCRSOS2 = 10096;
		public const int SQLEBCSA = 10097;
		public const int SQLEBCRO = 10098;
		public const int SQLEBCNE = 10099;
		public const int SQLEBCSK = 10100;
		
		// The severity levels are defined here for error handlers
		
		public const int EXINFO = 1;
		public const int EXUSER = 2;
		public const int EXNONFATAL = 3;
		public const int EXCONVERSION = 4;
		public const int EXSERVER = 5;
		public const int EXTIME = 6;
		public const int EXPROGRAM = 7;
		public const int EXRESOURCE = 8;
		public const int EXCOMM = 9;
		public const int EXFATAL = 10;
		public const int EXCONSISTENCY = 11;
		
		// Length of text timestamp and text pointer
		//Global Const SQLTXTSLEN% = 8          ' length of text timestamp
		//Global Const SQLTXPLEN% = 16          ' length of text pointer
		
		public const int OFF_SELECT = 0x16D;
		public const int OFF_FROM = 0x14F;
		public const int OFF_ORDER = 0x165;
		public const int OFF_COMPUTE = 0x139;
		public const int OFF_TABLE = 0x173;
		public const int OFF_PROCEDURE = 0x16A;
		public const int OFF_STATEMENT = 0x1CB;
		public const int OFF_PARAM = 0x1C4;
		public const int OFF_EXEC = 0x12C;
		
		// Bulk Copy Definitions (bcp)
		
		public const int DBIN = 1; // transfer from client to server
		public const int DBOUT = 2; // transfer from server to client
		
		public const int BCPMAXERRS = 1; // SqlBcpControl parameter
		public const int BCPFIRST = 2; // SqlBcpControl parameter
		public const int BCPLAST = 3; // SqlBcpControl parameter
		public const int BCPBATCH = 4; // SqlBcpControl parameter
		
		// Cursor related constants
		
		// Following flags are used in the concuropt parameter in the
		// SqlCursorOpen function
		
		public const int CURREADONLY = 1; // Read only cursor, no data modifications
		public const int CURLOCKCC = 2; // Intent to update, all fetched data locked
		// when dbcursorfetch is called inside a
		// transaction block
		public const int CUROPTCC = 3; // Optimistic concurrency control, data
		// modifications succeed only if the row
		// hasn't been updated since the last fetch
		public const int CUROPTCCVAL = 4; // Optimistic concurrency control based on
		// selected column values
		
		// Following flags are used in the scrollopt parameter in the
		// SqlCursorOpen function
		
		public const int CURFORWARD = 0; // Forward only scrolling
		public const int CURKEYSET = -1; // Keyset driven scrolling
		public const int CURDYNAMIC = 1; // Fully dynamic
		
		// Any other number indicates mixed scrolling. (Keyset driven within the given
		// number, dynamic outside)
		
		// Following flags define the fetchtype in the SqlCursorFetch function
		
		public const int FETCHFIRST = 1; // Fetch first n rows
		public const int FETCHNEXT = 2; // Fetch next n rows
		public const int FETCHPREV = 3; // Fetch previous n rows
		public const int FETCHRANDOM = 4; // Fetch n rows beginning with given row#
		public const int FETCHRELATIVE = 5; // Fetch relative to previous fetch row #
		public const int FETCHLAST = 6; // Fetch the last n rows
		
		// Following flags define the per row status as filled by SqlCursorFetch
		
		public const int FTCSUCCEED = 0x1; // Fetch succeeded, (failed if not set)
		public const int FTCMISSING = 0x2; // The row is missing
		public const int FTCENDOFKEYSET = 0x4; // End of the keyset reached
		public const int FTCENDOFRESULTS = 0x8; // End of results set reached
		
		// Following flags define the operator types for the SqlCursor function
		
		public const int CRSUPDATE = 1; // Update operation
		public const int CRSDELETE = 2; // Delete operation
		public const int CRSINSERT = 3; // Insert operation
		public const int CRSREFRESH = 4; // Refetch given row
		public const int CRSLOCKCC = 5; // Lock given row (if only inside a transaction)
		
		// Remote Procedure Call function options
		public const int SQLRPCRECOMPILE = 1; // recompile the stored procedure
		public const int SQLRPCRETURN = 1; // return parameter
		
		//Constante que define el tiempo máximo de espera para conexion a la BD
		public const int INT_QUERYTIMEOUT = 360;
		
		
		
		//----------------------------------------------------------------------------
		//Variables de uso general de la aplicación
		//----------------------------------------------------------------------------
		
		//Global gsQuery              As String           'Contiene sentencia SQL ¡importante inicializarlo!
		//Global hgblConexion         As Integer          'Guarda la conexión a la base de datos
		static public int gbAcceso = 0; //Valida la primera vez que se carga la forma
		static public string gsMsg = String.Empty; //Útil para msgbox con mensajes largos
		
		static public string gsDbLibActiva = String.Empty; //Guarda la inicialización de la librería
		static public string gsServidor = String.Empty; //Servidor de datos
		static public string gsPuerto = String.Empty; //Va a almacenar el puerto de la base de Datos para ADO
		
		static public string gsRutaSistema = String.Empty; //Ruta del Sistema
		static public string gsRutaContratos = String.Empty; //Ruta de los Contratos
		static public string gsRutaFotos = String.Empty; //Ruta de las Fotos
		static public string gsRutaBmp = String.Empty; //Ruta de los bitmaps
		static public string gsUsuario = String.Empty; //Usuario
		static public string gsPassword = String.Empty; //Password del Usuario
		static public string gsCveEmplUsuario = String.Empty; //Clave de Empleado del Usuario
		static public string gsCveEmplJefeUsuario = String.Empty; //Clave de Empleado del Jefe del Usuario
		
		static public string gsClaveColaborador = String.Empty; //Clave del Colaborador
		
		static public string gsCveFabrica = String.Empty; //Clave de la Fábrica
		static public string gsNombreFabrica = String.Empty; //Nombre de la Fábrica
		
		static public string gsBaseDatos = String.Empty; //la base de datos
		static public int giError = 0; //Guarda el error en número
		static public string gsError = String.Empty; //Guarda el error en cadena
		//Global giRetorna            As Integer          'Recibe el estado de regreso de una función
		static public int gbExisteTransaccion = 0; //Bandera para el control de las transacciones
		
		static public string gsGrupoUsu = String.Empty; //Grupo al que pertenece el Usuario del Sistema
		static public int giNivelUsu = 0; //Nivel del Usuario del Sistema
		static public int giNivelInfUsu = 0; //Siguiente Nivel inferior al del Usuario
		
		//Variables de uso para la busqueda de elementos de la forma frmBusca
		static public string gsBusClave = String.Empty; //Clave del elemento elegido
		static public string gsBusDesc = String.Empty; //Descripción del elemento elegido
		static public string gsFormaBusca = String.Empty; //Nombre de la forma que llamó a la forma de busca
		
		static public int gbOprimioALT = 0; //Bandera para saber si oprimió un acelerador
		//**------------------------------------------------------------------------**
		//**                                                                        **
		//**       Descripción   : Se conecta al servidor de la BD                  **
		//**                                                                        **
		//**       Parámetros    : 1. La conexión al servidor                       **
		//**                       2. El mensaje de error posible                   **
		//**                       3. La gravedad del error posible                 **
		//**                                                                        **
		//**       Valor de Regreso    : 1. La conexión al servidor                 **
		//**                             2. El mensaje de error                     **
		//**                             3. La gravedad del error                   **
		//**                                                                        **
		//**--------------------------------------------------------------------------
		static public int Conexion_Servidor()
		{
			
			int result = 0;
			int lRetorna = 0;
			int iLogin = 0;
			int hConn = 0;
			int intErrors = 0;
			string strError = String.Empty;
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					int bConexion = VBSQL.SUCCEED;
					
					gsDbLibActiva = VBSQL.SqlInit();
					
					//Verifica el éxito de iniciar la librería
					if (gsDbLibActiva != CORVB.NULL_STRING)
					{
						
						if (hConn != CORVB.NULL_INTEGER)
						{
							//ya existían conexiones, por lo tanto se cierran
							VBSQL.SqlClose(hConn);
						}
						
						//Pone el tiempo de espera para Login
						lRetorna = VBSQL.SqlSetLoginTime(10);
						
						//Realiza la conexión
						//hgblConexion = SqlOpenConnection(gsServidor, gsUsuario, gsPassword, NULL_STRING, NULL_STRING)
						hConn = VBSQL.SqlLogin();
						lRetorna = VBSQL.SqlSetLUser(hConn, gsUsuario);
						lRetorna = VBSQL.SqlSetLPwd(hConn, gsPassword);
						CORVAR.hgblConexion = VBSQL.SqlOpen(hConn, gsServidor);
						
						if (CORVAR.hgblConexion != 0)
						{
							//Tiempo de espera para los queries
							lRetorna = VBSQL.SqlSetTime(INT_QUERYTIMEOUT);
							
							//Verifica si es la base de datos requerida
							if (VBSQL.SqlName(CORVAR.hgblConexion) != gsBaseDatos)
							{
								
								if (VBSQL.SqlUse(CORVAR.hgblConexion, gsBaseDatos) != VBSQL.SUCCEED)
								{
									//No hubo éxito en el cambio de base de datos
									bConexion = VBSQL.FAIL;
									return bConexion;
								}
								
							}
						} else
						{
							bConexion = VBSQL.FAIL;
						}
					} else
					{
						bConexion = VBSQL.FAIL;
					}
					
					result = bConexion;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
			return result;
		}
		
		//**------------------------------------------------------------------------**
		//** Realiza una segunada conexión al sevidor para algunos consultas        **
		//**       Descripción   : Se conecta al servidor de la BD                  **
		//**                                                                        **
		//**       Parámetros    : 1. La conexión al servidor                       **
		//**                       2. El mensaje de error posible                   **
		//**                       3. La gravedad del error posible                 **
		//**                                                                        **
		//**       Valor de Regreso    : 1. La conexión al servidor                 **
		//**                             2. El mensaje de error                     **
		//**                             3. La gravedad del error                   **
		//**                                                                        **
		//**--------------------------------------------------------------------------
		static public int Segunda_ConexionServidor()
		{
			
			int result = 0;
			int lRetorna = 0;
			int iLogin = 0;
			int hConn = 0;
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					int bConexion = VBSQL.SUCCEED;
					
					gsDbLibActiva = VBSQL.SqlInit();
					
					//Verifica el éxito de iniciar la librería
					if (gsDbLibActiva != CORVB.NULL_STRING)
					{
						
						if (hConn != CORVB.NULL_INTEGER)
						{
							//ya existían conexiones, por lo tanto se cierran
							VBSQL.SqlClose(hConn);
						}
						
						//Pone el tiempo de espera para Login
						lRetorna = VBSQL.SqlSetLoginTime(10);
						
						//Realiza la conexión
						//hgblConexion = SqlOpenConnection(gsServidor, gsUsuario, gsPassword, NULL_STRING, NULL_STRING)
						hConn = VBSQL.SqlLogin();
						lRetorna = VBSQL.SqlSetLUser(hConn, gsUsuario);
						lRetorna = VBSQL.SqlSetLPwd(hConn, gsPassword);
						CORVAR.hgblConexion2 = VBSQL.SqlOpen(hConn, gsServidor);
						
						if (CORVAR.hgblConexion2 != 0)
						{
							//Tiempo de espera para los queries
							lRetorna = VBSQL.SqlSetTime(INT_QUERYTIMEOUT);
							
							//Verifica si es la base de datos requerida
							if (VBSQL.SqlName(CORVAR.hgblConexion2) != gsBaseDatos)
							{
								
								if (VBSQL.SqlUse(CORVAR.hgblConexion2, gsBaseDatos) != VBSQL.SUCCEED)
								{
									//No hubo éxito en el cambio de base de datos
									bConexion = VBSQL.FAIL;
								}
								
							}
						} else
						{
							bConexion = VBSQL.FAIL;
						}
					} else
					{
						bConexion = VBSQL.FAIL;
					}
					
					//Segunda_ConexionServidor = bConexion
					result = CORVAR.hgblConexion2;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
			return result;
		}
	}
}