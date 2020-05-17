using Microsoft.VisualBasic; 
using System; 
using System.Runtime.InteropServices; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	 class VBSQL
	{
	
		// Global declarations for Visual Basic to DB-Library translation dll.
		// Used by all apps linking with the VBSQL DLL (VBSQL.OCX)
		
		// Global return values for all RETCODE type functions
		public const int SUCCEED = 1;
		public const int FAIL = 0;
		
		// return values permitted in error handlers
		public const int INTEXIT = 0;
		public const int INTCONTINUE = 1;
		public const int INTCANCEL = 2;
		
		public const int MOREROWS = -1;
		public const int NOMOREROWS = -2;
		public const int REGROW = -1;
		public const int BUFFULL = -3;
		
		// Status code for dbresults(). Possible return values are
		// SUCCEED, FAIL, and NO_MORE_RESULTS.
		
		public const int NOMORERESULTS = 2;
		public const int NOMORERPCRESULTS = 3;
		
		// versions for SQLSetLVersion
		
		public const int SQLVER42 = 8;
		public const int SQLVER60 = 9;
		
		// option values permitted in option setting/querying/clearing
		// used by SqlSetOpt&(), SqlIsOpt&(), and SqlClrOpt&().
		
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
		public const int SQLANSItoOEM = 14;
		public const int SQLCLIENTCURSORS = 16;
		public const int SQLQUOTEDIDENT = 18;
		
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
		public const int SQLDECIMAL = 0x6A;
		public const int SQLNUMERIC = 0x6C;
		
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
		public const int SQLEUVBF = 10101;
		public const int SQLEBIHC = 10102;
		public const int SQLEBWFF = 10103;
		
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
		public const int SQLTXTSLEN = 8; // length of text timestamp
		public const int SQLTXPLEN = 16; // length of text pointer
		
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
		public const int BCPKEEPNULLS = 5; // SqlBcpControl parameter
		
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
		public const int CURINSENSITIVE = -2; // Server-side cursors only
		
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
		
		public const int FTCEMPTY = 0x0; // No row available
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
		
		// Following define row information type requested from SqlColInfo
		public const int SQLCI_REGULAR = 1; // regular row
		public const int SQLCI_ALTERNATE = 2; // compute row
		public const int SQLCI_CURSOR = 3; // cursor row
		
		// Following are values returned to ColInfo Usertype Type field for Cursors
		public const int CU_CLIENT = 0x1;
		public const int CU_SERVER = 0x2;
		public const int CU_KEYSET = 0x4;
		public const int CU_MIXED = 0x8;
		public const int CU_DYNAMIC = 0x10;
		public const int CU_FORWARD = 0x20;
		public const int CU_INSENSITIVE = 0x40;
		public const int CU_READONLY = 0x80;
		public const int CU_LOCKCC = 0x100;
		public const int CU_OPTCC = 0x200;
		public const int CU_OPTCCVAL = 0x400;
		
		//  Following are values returned to ColInfo Usertype Status field forCursors
		public const int CU_FILLING = 0x1;
		public const int CU_FILLED = 0x2;
		
		
		// Remote Procedure Call function options
		public const int SQLRPCRECOMPILE = 0x1; // recompile the stored procedure
		public const int SQLRPCRESET = 0x4; // reset rpc processing
		public const int SQLRPCRETURN = 1; // return parameter
		
		// The following values are passed to SqlServerEnum for searching criteria.
		public const int NETSEARCH = 1;
		public const int LOCSEARCH = 2;
		
		
		// These constants are the possible return values from SqlServerEnum.
		public const int ENUMSUCCESS = 0;
		public const int MOREDATA = 1;
		public const int NETNOTAVAIL = 2;
		public const int OUTOFMEMORY = 4;
		public const int NOTSUPPORTED = 8;
		public const int ENUMINVALIDPARAM = 16;
		
		// These constants are passed to SqlUpdateText for setting update type
		public const int UTTEXTPTR = 0x1;
		public const int UTTEXT = 0x2;
		public const int UTMORETEXT = 0x4;
		public const int UTDELETEONLY = 0x8;
		public const int UTLOG = 0x10;
		
		
		// These constants are used by SqlProcInfo
		public const int SERVTYPEUNKNOWN = 0;
		public const int SERVTYPEMICROSOFT = 1;
		
		
		// State unknown in SqlColInfo
		public const int SQLUNKNOWN = 2;
		
		// User defined data type for SqlGetColumnInfo
		public struct ColumnData
		{
			public int Coltype;
			public int Collen;
			public string Colname;
			public string ColSqlType;
			public static ColumnData CreateInstance()
			{
					ColumnData result = new ColumnData();
					result.Colname = String.Empty;
					result.ColSqlType = String.Empty;
					return result;
			}
		}
		
		// User defined data type for SqlGetAltColInfo
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		public struct AltColumnData
		{
			public int ColID;
			public int DataType;
			public int maxlen;
			public int AggType;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=31)] public string AggOpName;
		}
		
		// User defined data type for SqlBcpColumnFormat
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		public struct BcpColData
		{
			public int FType;
			public int FPLen;
			public int fColLen;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=31)] public string FTerm;
			public int FTLen;
			public int TCol;
		}
		
		// User defined data type for SqlDateCrack
		public struct DateInfo
		{
			public int Year_Renamed;
			public int Quarter;
			public int Month_Renamed;
			public int DayOfYear;
			public int Day_Renamed;
			public int Week;
			public int WeekDay_Renamed;
			public int Hour_Renamed;
			public int Minute_Renamed;
			public int Second_Renamed;
			public int Millisecond;
		}
		
		// User defined data type for SqlColInfo
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		public struct ColInfo
		{
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=31)] public string Name;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=31)] public string ActualName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=31)] public string TableName;
			public int CType;
			public int UserType;
			public int MaxLength;
			public int Precision;
			public int Scale;
			public int VarLength;
			public int Null_Renamed;
			public int CaseSensitive;
			public int Updatable;
			public int Identity;
		}
		
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		public struct ProcInfo
		{
			public int ServerType;
			public int ServerMajor;
			public int ServerMinor;
			public int ServerRevision;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=31)] public string ServerName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=31)] public string NetLibName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=256)] public string NetLibConnStr;
		}
		
		public struct SqlCursorInfo
		{
			public int TotCols;
			public int TotRows;
			public int CurRow;
			public int TotRowsFetched;
			public int CursorType;
			public int Status;
		}
		
		//AIS-1182 NGONZALEZ
		
		// Function/Sub declarations for Visual Basic App Global module
		static public VBSQLdll.clsLogin Glogin = null;
		static public VBSQLdll.ColRec GColRec = null;
		static public Collection ColQry = null;
		static public Collection ColFirst = null;
		static public ADODB.Connection[] gConn = new ADODB.Connection[12];
		static public string gStrCon = String.Empty;
		
		static public string SqlInit()
		{
			if (GColRec == null)
			{
				GColRec = new VBSQLdll.ColRec();
			}
			
			if (ColQry == null)
			{
				ColQry = new Collection();
			}
			
			if (ColFirst == null)
			{
				ColFirst = new Collection();
			}
			
			if (Glogin == null)
			{
                //AIS-1194 NGONZALEZ
                Glogin =  VBSQL.CreateInstanceClsLogin();
			}
			return "DB-Library version 6.50.201";
		}
         //AIS-1194 NGONZALEZ
        public static VBSQLdll.clsLogin CreateInstanceClsLogin()
        {
            VBSQLdll.clsLogin ClsLogin = new VBSQLdll.clsLogin();
            ClsLogin.sAPP = String.Empty;
            ClsLogin.sBase = String.Empty;
            ClsLogin.sHost = String.Empty;
            ClsLogin.sPWD = String.Empty;
            ClsLogin.sServer = String.Empty;
            ClsLogin.sUser = String.Empty;
            return ClsLogin;
        }

		
		static public int SqlLogin()
		{
			return 100;
		}
		
		static public int SqlSetLUser( int Login,  string sUser)
		{
			if (Glogin == null)
			{
				return 0;
			} else
			{
				Glogin.sUser = sUser;
				return 1;
			}
		}
		
		static public int SqlSetLPwd( int Login,  string Pwd)
		{
			if (Glogin == null)
			{
				return 0;
			} else
			{
				Glogin.sPWD = Pwd;
				return 1;
			}
		}
		
		static public int SqlSetLApp( int Login,  string App)
		{
			if (Glogin == null)
			{
				return 0;
			} else
			{
				Glogin.sAPP = App;
				Glogin.sBase = CORDBLIB.gsBaseDatos;
				return 1;
			}
		}
		
		static public int SqlSetLoginTime( int Seconds)
		{
			if (Glogin == null)
			{
				return 0;
			} else
			{
				Glogin.iTimeout = 0;
				return 1;
			}
		}
		
		static public int SqlSetLHost( int Login,  string Host)
		{
			if (Glogin == null)
			{
				return 0;
			} else
			{
				return 1;
			}
		}
		
		static public int SqlSetLSecure( int Login)
		{
			if (Glogin == null)
			{
				return 0;
			} else
			{
				return 1;
			}
		}
		
		static public int SqlOpen( int Login,  string Server)
		{
			int result = 0;
			int ilcont = 0;
			int contador = 0, ConnDisp = 0;
			ADODB.Recordset lRST = null;
			try
			{
					
					result = 0;
					ilcont = 0;
					lRST = new ADODB.Recordset();
					if (GColRec == null)
					{
						return result;
					} else
					{
						ilcont = GColRec.Count;
						ConnDisp = 0;
						for (contador = 1; contador <= ilcont; contador++)
						{
							//If GColRec.Item(CLng(Contador)).State = 0 Then
							if (gConn[contador].State == 0)
							{
								ConnDisp = contador;
								break;
							}
						}
						
						if (ConnDisp == 0)
						{
							ilcont++;
						} else if (contador == ilcont && contador != ConnDisp) { 
							ilcont = ilcont;
						} else
						{
							ilcont = ConnDisp;
						}
						
						Glogin.sServer = CORDBLIB.gsServidor;
						if (OpenConn(ilcont) == 0)
						{
							string tempRefParam = Conversion.Str(ilcont);
							lRST = GColRec.add(ref tempRefParam);
							result = ilcont;
						}
					}
					lRST = null;
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error al abrir la conexion :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int SqlUse( int SqlConn,  string DataBase)
		{
			int result = 0;
			try
			{
					result = 0;
					if (gConn[SqlConn].State == 1)
					{
						if (gConn[SqlConn].DefaultDatabase != DataBase)
						{
							object tempRefParam = Type.Missing;
							gConn[SqlConn].Execute("use " + DataBase, out tempRefParam, -1);
						}
						result = 1;
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error intentar usar la base de datos :" + DataBase + " : " + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int SqlCmd( int SqlConn,  string Cmd)
		{
			int result = 0;
			try
			{
					Collection ColQry2 = null;
					Collection ColFirst2 = null;
					
					result = 0;
					ColQry2 = new Collection();
					ColFirst2 = new Collection();
					if (ColQry == null)
					{
						return 0;
					} else
					{
						if (ColQry.Count < SqlConn)
						{
							ColQry.Add(Cmd, null, null, null);
							ColFirst.Add(1, null, null, null);
							return 1;
						} else
						{
							for (int icon = 1; icon <= ColQry.Count; icon++)
							{
								if (icon == SqlConn)
								{
									ColQry2.Add(Cmd, null, null, null);
									ColFirst2.Add(1, null, null, null);
								} else
								{
									ColQry2.Add(ColQry[icon], null, null, null);
									ColFirst2.Add(ColFirst[icon], null, null, null);
								}
							}
							ColQry = null;
							ColFirst = null;
							ColFirst = ColFirst2;
							ColQry = ColQry2;
							return 1;
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show(excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int OpenConn( int intIndCon)
		{
			int result = 0;
			try
			{
					result = -1;
					if (gConn[intIndCon] == null)
					{
						gConn[intIndCon] = new ADODB.Connection();
					}
					if (gConn[intIndCon].State == ((int) ADODB.ObjectStateEnum.adStateClosed))
					{
						if (Glogin.sBase == "")
						{
                            //gStrCon = "DSN=" + Glogin.sServer + ";UID=" +
                            //          Glogin.sUser + ";PWD=" + Glogin.sPWD;
                           gStrCon = "DSN=" + Glogin.sServer + ";UID=" +
                           Glogin.sUser + ";PWD=" + Glogin.sPWD + ";keeporgmultibyte=1" + ";EncryptPassword=1";
                           //Glogin.sUser + ";PWD=" + Glogin.sPWD + ";keeporgmultibyte=1";

							//gStrCon = "DSN=" + Glogin.sServer + ";UID=" +
                            //          Glogin.sUser + ";PWD=" + Glogin.sPWD + ";charset=ServerDefault;keeporgmultibyte=1";
						} else
						{
							//gStrCon = "DSN=" + Glogin.sServer + ";UID=" + 
							//          Glogin.sUser + ";PWD=" + Glogin.sPWD + ";DATABASE=" + Glogin.sBase;
                            gStrCon = "DSN=" + Glogin.sServer + ";UID=" +
                            Glogin.sUser + ";PWD=" + Glogin.sPWD + ";DATABASE=" + Glogin.sBase + ";keeporgmultibyte=1" + ";EncryptPassword=1";
                            //Glogin.sUser + ";PWD=" + Glogin.sPWD + ";DATABASE=" + Glogin.sBase + ";keeporgmultibyte=1";

                            //gStrCon = "DSN=" + Glogin.sServer + ";UID=" +
                            //          Glogin.sUser + ";PWD=" + Glogin.sPWD + ";DATABASE=" + Glogin.sBase+ ";charset=ServerDefault;keeporgmultibyte=1" ;
						}
						
						gConn[intIndCon].ConnectionString = gStrCon;
						
						if (Glogin.sServer != "" && Glogin.sUser != "" && Glogin.sPWD != "")
						{
							gConn[intIndCon].ConnectionTimeout = 0;
							gConn[intIndCon].CommandTimeout = 0;
							 gConn[intIndCon].Mode = ADODB.ConnectModeEnum.adModeReadWrite;
							gConn[intIndCon].Open("", "", "", -1);
							result = 0;
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error al abrir la conexion :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int SqlExec( int SqlConn)
		{
			int result = 0;
			string Qry = String.Empty;
			ADODB.Recordset Rstl = null;
			try
			{
					if (Glogin == null)
					{
						result = 0;
					} else
					{
						if (GColRec == null)
						{
							result = 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								result = 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (ColQry == null)
								{
									result = 0;
								} else
								{
									if (ColQry.Count < SqlConn)
									{
										result = 0;
									} else
									{
										if (SqlConn > 0)
										{
											//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
											Qry = Convert.ToString(ColQry[SqlConn]);
											if (GColRec.get_Item(ref SqlConn).State == 1)
											{
												GColRec.get_Item(ref SqlConn).Close();
											}
											
											
											GColRec.RstExec(ref SqlConn, ref gConn[SqlConn], ref Qry);
											//GColRec.Item(SqlConn).Open Qry, gConn(SqlConn), adOpenDynamic, adLockBatchOptimistic
											result = 1;
											
											if (SqlConn > 5)
											{
												gConn[SqlConn].Close();
											}
											
										}
									}
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error al abrir ejecutar :" + Qry + " : " + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int SqlNextRow( int SqlConn)
		{
			int result = 0;
			Collection ColFirst2 = null;
			try
			{
					
					if (Glogin == null)
					{
						return -2;
					} else
					{
						if (GColRec == null)
						{
							return -2;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return -2;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										result = -2;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return -2;
									} else
									{
										if (GColRec.get_Item(ref SqlConn).EOF && GColRec.get_Item(ref SqlConn).BOF)
										{
											return -2;
										} else
										{
											//UPGRADE_WARNING: (1068) ColFirst.Item(SqlConn) of type Variant is being forced to double.
											if (Convert.ToDouble(ColFirst[SqlConn]) == 1)
											{ //'Si es el Primer registro NO AVANZA
												ColFirst2 = new Collection();
												for (int icon = 1; icon <= ColQry.Count; icon++)
												{
													if (icon == SqlConn)
													{
														ColFirst2.Add(2, null, null, null);
													} else
													{
														ColFirst2.Add(ColFirst[icon], null, null, null);
													}
												}
												ColFirst = null;
												ColFirst = ColFirst2;
											} else
											{
												if (! GColRec.get_Item(ref SqlConn).EOF && ! GColRec.get_Item(ref SqlConn).BOF)
												{
													GColRec.get_Item(ref SqlConn).MoveNext();
												}
											}
											if (GColRec.get_Item(ref SqlConn).EOF)
											{
												return -2;
											} else
											{
												return -1;
											}
										}
									}
								} else
								{
									return -2;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public string SqlData( int SqlConn,  int Column)
		{
			try
			{
					if (Glogin == null)
					{
						return "";
					} else
					{
						if (GColRec == null)
						{
							return "";
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return "";
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return "";
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return "";
									} else
									{
										if (GColRec.get_Item(ref SqlConn).Fields.Count > (Column - 1))
										{
											if (! GColRec.get_Item(ref SqlConn).EOF && ! GColRec.get_Item(ref SqlConn).BOF)
											{
												return (Convert.IsDBNull(GColRec.get_Item(ref SqlConn).Fields[Column - 1].Value)) ? "": Convert.ToString(GColRec.get_Item(ref SqlConn).Fields[Column - 1].Value);
											} else
											{
												return "";
											}
										} else
										{
											return "";
										}
									}
								} else
								{
									return "";
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return String.Empty;
		}
		
		static public int SqlFirstRow( int SqlConn)
		{
			try
			{
					if (Glogin == null)
					{
						return 0;
					} else
					{
						if (GColRec == null)
						{
							return 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return 0;
									} else
									{
										if (GColRec.get_Item(ref SqlConn).EOF && GColRec.get_Item(ref SqlConn).BOF)
										{
											return 0;
										} else
										{
											GColRec.get_Item(ref SqlConn).MoveFirst();
											return 1;
										}
									}
								} else
								{
									return 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return 0;
		}
		
		static public int SqlResults( int SqlConn)
		{
			int result = 0;
			ADODB.Recordset rstlRecordSet = null;
			try
			{
					result = 0;
					if (Glogin == null)
					{
						result = 0;
					} else
					{
						if (GColRec == null)
						{
							result = 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								result = 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return 2;
									} else
									{
										if (GColRec.get_Item(ref SqlConn).BOF && GColRec.get_Item(ref SqlConn).EOF)
										{
											result = 2;
										} else if (GColRec.get_Item(ref SqlConn).EOF) { 
											result = 2;
										} else
										{
											result = 1;
										}
									}
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public void  SqlClose( int SqlConn)
		{
			try
			{
					if (GColRec == null)
					{
						return;
					} else
					{
						if (GColRec.Count >= SqlConn && SqlConn > 0)
						{
							if (GColRec.get_Item(ref SqlConn).State == 1)
							{
								GColRec.get_Item(ref SqlConn).Close();
								
								return;
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
		}
		
		static public void  SqlExit()
		{
			try
			{
					if (GColRec == null)
					{
						return;
					} else
					{
						for (int i = 1; i <= GColRec.Count; i++)
						{
							if (GColRec.get_Item(ref i).State == 1)
							{
								GColRec.get_Item(ref i).Close();
								ColQry.Remove(1);
								ColFirst.Remove(1);
							}
							
							if (gConn[i].State == 1)
							{
								gConn[i].Close();
							}
						}
						GColRec.Clear();
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
		}
		
		static public void  SqlWinExit()
		{
			//   Set gConn = Nothing
			//   Set ColQry = Nothing
			//   Set GColRec = Nothing
			//   Set ColFirst = Nothing
		}
		
		static public string SqlName( int SqlConn)
		{
			string result = String.Empty;
			try
			{
					result = "";
					if (Glogin == null)
					{
						result = "";
					} else
					{
						if (GColRec == null)
						{
							result = "";
						} else
						{
							if (gConn[SqlConn] == null)
							{
								result = "";
							} else
							{
								if (OpenConn(SqlConn) == 0)
								{
									if (GColRec.Count >= SqlConn)
									{
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
										result = (Convert.IsDBNull(gConn[SqlConn].DefaultDatabase)) ? "": gConn[SqlConn].DefaultDatabase;
									} else
									{
										result = "";
									}
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int SqlSetTime( int Seconds)
		{
			return 1;
		}
		
		static public int SqlCancel( int SqlConn)
		{
			int result = 0;
			try
			{
					result = 0;
					if (GColRec == null)
					{
						return result;
					} else
					{
						if (GColRec.Count >= SqlConn)
						{
							if (GColRec.get_Item(ref SqlConn).State == 1)
							{
								GColRec.get_Item(ref SqlConn).Close();
								result = 1;
							} else
							{
								result = 1;
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int SqlOpenConnection( string Server,  string LoginID,  string Pwd,  string WorkStation,  string Application)
		{
			int result = 0;
			int ilcont = 0;
			ADODB.Recordset lRST = null;
			try
			{
					ilcont = 0;
					Glogin.sAPP = Application;
					Glogin.sHost = WorkStation;
					Glogin.iTimeout = 0;
					Glogin.sBase = CORDBLIB.gsBaseDatos;
					Glogin.sPWD = Pwd;
					Glogin.sServer = Server;
					Glogin.sUser = LoginID;
					
					result = 0;
					lRST = new ADODB.Recordset();
					if (GColRec == null)
					{
						return result;
					} else
					{
						ilcont = GColRec.Count;
						ilcont++;
						if (OpenConn(ilcont) == 0)
						{
							string tempRefParam = Conversion.Str(ilcont);
							lRST = GColRec.add(ref tempRefParam);
							result = ilcont;
						}
					}
					lRST = null;
				}
			catch (Exception excep)
			{
				//AIS-1163 NGONZALEZ
				MessageBox.Show("Error al abrir la conexion :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, System.Windows.Forms.Application.ProductName);
			}
			return result;
		}
		
		static public int SqlCount( int SqlConn)
		{
			int lngNumRegs = 0;
			try
			{
					
					if (Glogin == null)
					{
						return 0;
					} else
					{
						if (GColRec == null)
						{
							return 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
										if (((Convert.ToString(ColQry[SqlConn]).IndexOf("delete", StringComparison.CurrentCultureIgnoreCase) + 1) | (Convert.ToString(ColQry[SqlConn]).IndexOf("exec", StringComparison.CurrentCultureIgnoreCase) + 1) | (Convert.ToString(ColQry[SqlConn]).IndexOf("insert", StringComparison.CurrentCultureIgnoreCase) + 1) | (Convert.ToString(ColQry[SqlConn]).IndexOf("update", StringComparison.CurrentCultureIgnoreCase) + 1)) != 0)
										{
											return 1;
										}
										return 0;
									} else
									{
										if (GColRec.get_Item(ref SqlConn).RecordCount == -1)
										{
											lngNumRegs = 0;
											
											if (GColRec.get_Item(ref SqlConn).BOF && GColRec.get_Item(ref SqlConn).EOF)
											{
												//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
												if ((Convert.ToString(ColQry[SqlConn]).IndexOf("exec", StringComparison.CurrentCultureIgnoreCase) + 1) != 0)
												{
													return 1;
												} else
												{
													return 0;
												}
											} else
											{
												GColRec.get_Item(ref SqlConn).MoveFirst();
											}
											
											while (! GColRec.get_Item(ref SqlConn).EOF)
												{
												
													lngNumRegs++;
													GColRec.get_Item(ref SqlConn).MoveNext();
												}
											GColRec.get_Item(ref SqlConn).MoveFirst();
											return lngNumRegs;
										} else
										{
											return GColRec.get_Item(ref SqlConn).RecordCount;
										}
									}
								} else
								{
									return 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return 0;
		}
		
		static public int SqlstrLen( int SqlConn)
		{
			string strQry = String.Empty;
			
			try
			{
					
					if (Glogin == null)
					{
						return 0;
					} else
					{
						if (GColRec == null)
						{
							return 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return 0;
									} else
									{
										//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
										strQry = Convert.ToString(ColQry[SqlConn]);
										return strQry.Length;
									}
								} else
								{
									return 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return 0;
		}
		
		static public int SqlStrCpy( int SqlConn,  int Start,  int numbytes, ref  string Buffer)
		{
			
			int result = 0;
			try
			{
					
					if (Glogin == null)
					{
						result = 0;
					} else
					{
						if (GColRec == null)
						{
							result = 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								result = 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return 0;
									} else
									{
										//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
										if (Start < 0)
										{
											result = 0;
										} else if (Start > Strings.Len(Convert.ToString(ColQry[SqlConn]))) { 
											Buffer = "";
											result = 1;
										} else if (numbytes < 0) { 
											//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
											Buffer = Convert.ToString(ColQry[SqlConn]);
											result = 1;
										} else if (numbytes == 0) { 
											Buffer = "";
											result = 1;
										} else if (numbytes > 0) { 
											//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
											Buffer = Convert.ToString(ColQry[SqlConn]);
											Buffer = Strings.Mid(Buffer, Start + 1, numbytes);
											result = 1;
										}
									}
								} else
								{
									result = 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int SqlNumCols( int SqlConn)
		{
			try
			{
					if (Glogin == null)
					{
						return 0;
					} else
					{
						if (GColRec == null)
						{
							return 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return 0;
									} else
									{
										return GColRec.get_Item(ref SqlConn).Fields.Count;
									}
								} else
								{
									return 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return 0;
		}
		
		static public int SqlRows( int SqlConn)
		{
			int lngNumRegs = 0;
			
			try
			{
					
					if (Glogin == null)
					{
						return 0;
					} else
					{
						if (GColRec == null)
						{
							return 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return 0;
									} else
									{
                                        
                                        if (GColRec.get_Item(ref SqlConn).BOF && GColRec.get_Item(ref SqlConn).EOF)
                                        {
											//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
											if ((Convert.ToString(ColQry[SqlConn]).IndexOf("exec", StringComparison.CurrentCultureIgnoreCase) + 1) != 0)
											{
												return 1;
											} else
											{
												return 0;
											}
                                        } else
										{
											return 1;
										}
									}
								} else
								{
									return 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return 0;
		}
		
		static public int SqlDead( int SqlConn)
		{
			int result = 0;
			int lngNumRegs = 0;
			
			try
			{
					result = 1;
					if (Glogin == null)
					{
						return 1;
					} else
					{
						if (GColRec == null)
						{
							return 1;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return 1;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									return 1;
								} else
								{
									return 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public int SqlCanQuery( int SqlConn)
		{
			try
			{
					if (Glogin == null)
					{
						return 0;
					} else
					{
						if (GColRec == null)
						{
							return 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return 0;
									} else
									{
										while (! GColRec.get_Item(ref SqlConn).EOF && ! GColRec.get_Item(ref SqlConn).BOF)
											{
											
												GColRec.get_Item(ref SqlConn).MoveNext();
											}
										return 1;
									}
								} else
								{
									return 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return 0;
		}
		
		static public void  SqlFreeBuf( int SqlConn)
		{
			
			
			Collection ColQry2 = new Collection();
			Collection ColFirst2 = new Collection();
			if (ColQry == null)
			{
			} else
			{
				if (ColQry.Count < SqlConn)
				{
					
				} else
				{
					for (int icon = 1; icon <= ColQry.Count; icon++)
					{
						if (icon == SqlConn)
						{
							ColQry2.Add("", null, null, null);
							ColFirst2.Add(SqlConn, null, null, null);
						} else
						{
							ColQry2.Add(ColQry[icon], null, null, null);
							ColFirst2.Add(ColFirst[icon], null, null, null);
						}
					}
					ColQry = null;
					ColFirst = null;
					ColFirst = ColFirst2;
					ColQry = ColQry2;
				}
			}
		}
		
		static public int SqlCmdRow(ref  int SqlConn)
		{
			int result = 0;
			try
			{
					string slqry = String.Empty;
					
					result = 0;
					if (Glogin == null)
					{
						return 0;
					} else
					{
						if (GColRec == null)
						{
							return 0;
						} else
						{
							if (gConn[SqlConn] == null)
							{
								return 0;
							} else
							{
								if (gConn[SqlConn].State == 0)
								{
									if (OpenConn(SqlConn) != 0)
									{
										return 0;
									}
								}
								if (GColRec.Count >= SqlConn && SqlConn > 0)
								{
									if (GColRec.get_Item(ref SqlConn).State == 0)
									{
										return 0;
									} else
									{
										//UPGRADE_WARNING: (1068) ColQry.Item() of type Variant is being forced to string.
										slqry = Convert.ToString(ColQry[SqlConn]);
										if (((slqry.IndexOf("select", StringComparison.CurrentCultureIgnoreCase) + 1) | (slqry.IndexOf("exec", StringComparison.CurrentCultureIgnoreCase) + 1)) != 0)
										{
											return 1;
										} else
										{
											return 0;
										}
									}
								} else
								{
									return 0;
								}
							}
						}
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
			return result;
		}
		
		static public void  subCanConRec(ref  int intCont)
		{
			try
			{
					if (intCont == 0)
					{
						return;
					} //FSWB NR 20070323
					int tempRefParam3 = intCont;
					if (GColRec.get_Item(ref tempRefParam3).State > 0)
					{
						int tempRefParam = intCont;
						GColRec.get_Item(ref tempRefParam).Close();
					} else
					{
						object tempRefParam2 = intCont;
						GColRec.Remove(ref tempRefParam2);
					}
					gConn[intCont].Close();
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("Error  :" + excep.Message + " : " + Information.Err().Number.ToString() + " : " + excep.Source, Application.ProductName);
			}
		}
	}
}