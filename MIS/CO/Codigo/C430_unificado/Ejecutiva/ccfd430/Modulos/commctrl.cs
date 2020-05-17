using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.IO; 
using System.Runtime.InteropServices; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class COMMCTRL
	{
	
		
		
		
		static public int ZModOpts = 0, TransOpts = 0;
		static public string DownloadDir = String.Empty, UploadDir = String.Empty;
		
		
		public const int ZMODEM_RESUME = 0;
		public const int ZMODEM_SKIP = 1;
		public const int ZMODEM_RENAME = 2;
		public const int ZMODEM_OVERWRITE = 3;
		
		public const int TRANS_CANCEL = 0;
		public const int TRANS_RENAME = 1;
		public const int TRANS_OVERWRITE = 2;
		
		//-- Notification Property
		public const int PDQ_NOTIFICATION_MANUAL = 0;
		public const int PDQ_NOTIFICATION_DRIVER = 1;
		
		
		//--------------------------- MODEMWARE ROUTINES ----------------------------
		
		//-- ModemWare Copyright (c) 1992 - 1994 Crescent Software.
		//   Written by Carl Franklin with help from and thanks to Bill Conley.
		
		//-- Global flags. Set or read these in your application:
		static public int MW_CancelFlag = 0; //-- Setting to True cancels any ModemWare routine.
		static public int MW_DisplayFlag = 0; //-- Setting to True displays all received data.
		static public int MW_CurRoutine = 0; //-- Returns a value indicating the ModemWare
		//   routine currently being processed. See the
		//   MW_PROC_XXXX constants below.
		static public int MW_Capturing = 0; //-- Returns True if capturing to a file.
		static public int MW_ScriptRecording = 0; //-- Returns True when recording a script file.
		static public int MW_ScriptPlaying = 0; //-- Returns True when playing a script file.
		
		static public int MW_SetupFlag = 0; //-- Internal Flag used by GetModemIndex
		
		//-- Global reference to a comm control. used by ModemWare routines
		//   that use VB forms (MWPORT.FRM, etc).
		static public Control MW_Global_Comm1 = null;
		
		static public int MW_Init = 0;
		
		//-- Left over data from WaitFor routine
		static public string MW_LeftOver = String.Empty;
		
		//-- The ModemWare internal error variable.
		
		//-- File transfer variables
		static public int MW_TransferType = 0;
		static public int MW_TransferProtocol = 0;
		static public string MW_FileToTransfer = String.Empty;
		
		static int MW_ErrCode = 0;
		
		//-- API Calls & constants used by ModemWare.
		//-- They are Aliased to avoid confusion with other modules that may use them.
		public const int SWP_NOMOVE = 0x2;
		public const int SWP_NOSIZE = 0x1;
		
#if Win32
		
		
		public struct POINT
		{
			public int X;
			public int Y;
		}
		
		//AIS-1182 NGONZALEZ
#else
		
		//UPGRADE_TODO: (1035) #If #EndIf block was not upgraded because the expression Else did not evaluate to True or was not evaluated.
		Declare Sub MWSetWindowPos Lib "User" Alias "SetWindowPos" (ByVal hwnd%, ByVal hWndInsertAfter%, ByVal X%, ByVal Y%, ByVal cx%, ByVal cy%, ByVal wFlags%)
		Declare Function MWMoveTo& Lib "GDI" Alias "MoveTo" (ByVal hDC%, ByVal X%, ByVal Y%)
		Declare Function MWLineTo Lib "GDI" Alias "LineTo" (ByVal hDC%, ByVal X%, ByVal Y%) As Integer
		Declare Function MWGetWinDir Lib "Kernel" Alias "GetWindowsDirectory" (ByVal lpBuffer As String, ByVal nSize As Integer) As Integer
		Declare Function MWGetConfigString Lib "Kernel" Alias "GetPrivateProfileString" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
		Declare Function MWPutConfigString Lib "Kernel" Alias "WritePrivateProfileString" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lplFileName As String) As Integer
		Declare Function MWGetConfigInt Lib "Kernel" Alias "GetPrivateProfileInt" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer
#endif
		//-- These values are used all the time in comm programming. They are
		//   automatically set when you call any ModemWare routine.
		static public string MW_CR = String.Empty; //-- Carriage return
		static public string MW_LF = String.Empty; //-- Line feed
		static public string MW_CRLF = String.Empty; //-- Carriage return / Line feed
		static public string MW_ESC = String.Empty; //-- Escape character
		static public string MW_BS = String.Empty; //-- BackSpace Character
		static public string MW_SP = String.Empty; //-- Space Character
		
		//-- Result Codes (from the modem)
		public const int MW_RESULT_OK = -1000; //-- OK
		public const int MW_RESULT_CARRIER = -1001; //-- TIMEOUT
		public const int MW_RESULT_CONNECT = -1002; //-- CONNECT
		public const int MW_RESULT_RING = -1003; //-- RING
		public const int MW_RESULT_NO_CARRIER = -1004; //-- NO CARRIER
		public const int MW_RESULT_ERROR = -1005; //-- ERROR
		public const int MW_RESULT_NO_DIALTONE = -1006; //-- NO DIALTONE
		public const int MW_RESULT_BUSY = -1007; //-- BUSY
		public const int MW_RESULT_NO_ANSWER = -1008; //-- NO ANSWER
		public const int MW_RESULT_TIMEOUT = -1009; //-- TIMEOUT
		
		//-- Status Messages
		public const int MW_STAT_SCRIPT_INITIALIZING = 5201; //-- Script: Initializing the Port or Settings.
		public const int MW_STAT_SCRIPT_WAITFOR = 5202; //-- Script: Waiting for a string.
		public const int MW_STAT_SCRIPT_SEND = 5203; //-- Script: Sending a string.
		public const int MW_STAT_SCRIPT_PORTSET = 5204; //-- Script: Settings have been specified.
		public const int MW_STAT_SCRIPT_CAPTURING = 5205; //-- Script: Capturing to a file.
		public const int MW_STAT_SCRIPT_DIALING = 5206; //-- Script: Dialing a number.
		public const int MW_STAT_SCRIPT_HANGUP = 5207; //-- Script: Hanging up.
		public const int MW_STAT_SCRIPT_UPLOAD = 5208; //-- Script: Uploading
		public const int MW_STAT_SCRIPT_DOWNLOAD = 5209; //-- Script: Downloading
		public const int MW_STAT_SCRIPT_REDIALING = 5210; //-- Script: Redialing a number
		public const int MW_STAT_SCRIPT_INPUT = 5211; //-- Script: Waiting for input
		public const int MW_STAT_PHBOOK_DIALING = 5301; //-- Phonebook: Dialing a number
		public const int MW_STAT_PHBOOK_REDIAL = 5302; //-- Phonebook: Redialing a number
		
		//-- Value of MW_CurRoutine (Currently excecuting routine).
		public const int MW_PROC_NONE = 0; //-- No ModemWare routines are executing
		public const int MW_PROC_ASCIISEND = -50; //-- AsciiSend
		public const int MW_PROC_HANGUP = -51; //-- Hangup
		public const int MW_PROC_INITMODEM = -52; //-- InitModem
		public const int MW_PROC_MWEND = -56; //-- MWEnd
		public const int MW_PROC_MWPAUSE = -57; //-- MWPause
		public const int MW_PROC_OPENPORT = -58; //-- OpenPort
		public const int MW_PROC_PLACECALL = -59; //-- PlaceCall
		public const int MW_PROC_SENDMODEMCMD = -60; //-- SendModemCmd
		public const int MW_PROC_WAITFOR = -61; //-- WaitFor         Note: This is only set if YOU
		//                         call WaitFor directly.
		public const int MW_PROC_WAITFORA = -62; //-- WaitForA        Note: This is only set if YOU
		//                         call WaitForA directly.
		public const int MW_PROC_WAITFORCALL = -63; //-- WaitForCall
		public const int MW_PROC_SETMODEMSETTINGS = -64;
		public const int MW_PROC_LOADPORTSETTINGS = -65;
		public const int MW_PROC_SETPORTSETTINGS = -66;
		public const int MW_PROC_OPENMODEMPORT = -67;
		public const int MW_PROC_END = -70;
		
		//File transfer constants
		public const int MW_XFER_DOWNLOAD = 1;
		public const int MW_XFER_UPLOAD = 2;
		public const int MW_XFER_NONE = 3;
		
		
		//-- General errors returned by some modemware routines
		public const int MW_ER_CANCELED = -102; //-- The process was Canceled by the user setting
		//   MW_CancelFlag to True.
		public const int MW_ER_LOST_CARRIER = -103; //-- Carrier was lost. The call was disconnected.
		public const int MW_ER_PORTCLOSED = -104; //-- The specified port does not exist
		public const int MW_ER_CTRLERROR = -105; //-- The specified port can not be accessed
		public const int MW_ER_TIMEOUT = -106; //-- Timeout
		public const int MW_ER_FILE_ERR = -107;
		
		//-- AsciiSend
		public const int MW_ASCIISEND_OK = 100; //-- File sent ok.
		public const int MW_ASCIISEND_NOTFOUND = 101; //-- File not found.
		public const int MW_ASCIISEND_FILE_ERR = 102; //-- Error reading file.
		
		//-- GetCommMessage errors
		//Global Const MW_GETMSG_OK = 200             '-- Valid CRESCENT MESSAGE
		//Global Const MW_GETMSG_INVALID_MSG = 201    '-- Invalid CRESCENT MESSAGE
		
		//-- GetModemIndex errors
		public const int MW_GETMODEMINDEX_ERROR = 250; //-- No Current Modems, call GetModemSettings
		
		//-- Hangup Errors
		public const int MW_HANGUP_OK = 300; //-- Modem disconnected
		public const int MW_HANGUP_ERROR = 301; //-- Modem could not be disconnected
		public const int MW_HANGUP_OFFLINE = 302; //-- Modem is already hung up
		
		//-- InitModem Errors
		public const int MW_INITMODEM_OK = 400; //-- Modem initialized OK.
		public const int MW_INITMODEM_NO_MODEM = 401; //-- No modem found.
		public const int MW_INITMODEM_ONLINE = 402; //-- Modem is online and cannot be initialized.
		public const int MW_INITMODEM_BAD_PORT = 403; //-- Invalid Port number specified
		public const int MW_INITMODEM_BAD_SETTINGS = 404; //-- Invalid Settings specified
		public const int MW_INITMODEM_BAUD_DRIVER = 405; //-- Specified baud rate is not supported by the comm control/driver.
		public const int MW_INITMODEM_BAUD_MODEM = 406; //-- Specified baud rate is not supported by your modem.
		
		//-- OpenPort Errors
		public const int MW_OPENPORT_OK = 500; //-- Port opened ok
		public const int MW_OPENPORT_ERROR = 501; //-- No ports are avaiable
		public const int MW_OPENPORT_SETTINGS = 502; //-- The specified settings are invalid.
		
		//-- PlaceCall Errors
		public const int MW_PLACECALL_OK = 600; //-- A valid result code was returned. Check Result
		public const int MW_PLACECALL_ERROR = 601; //-- The modem reported an error
		public const int MW_PLACECALL_NO_ANSWER = 602; //-- There is no answer
		public const int MW_PLACECALL_NO_PORT = 603; //-- There is no answer
		
		//-- SendCommMsg Errors
		public const int MW_SENDMSG_OK = 700; //-- Valid CRESCENT MESSAGE sent.
		
		//-- SendModemCmd Errors
		public const int MW_SENDMODEMCMD_OK = 800; //-- Command sent ok.
		public const int MW_SENDMODEMCMD_NOCMD = 801; //-- No command was specified.
		
		//-- WaitFor Errors
		public const int MW_WAITFOR_OK = 900; //-- The wait string was received
		public const int MW_WAITFOR_CONTINUE = 901; //-- Buffer was filled waiting
		
		//-- WaitForCall Errors
		public const int MW_WAITFORCALL_OK = 1000; //-- WaitForCall returned OK, caller is connected.
		
		//-------------------------- Modem Database Stuff ---------------------------
		
		//-- MW_ModemInfo is an array of this type which contains modem data
		//   for more more than 400 modems. Read from MODEMS.DAT
		//   There is a 4 byte header on MODEMS.DAT which contains the number of
		//   records in the database.
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		public struct MW_ModemInfoType
		{
			public int DeletedFlag;
			public int LinkRecord;
			public int ModemNumber;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=25)] public string VendorName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=40)] public string ModemName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=128)] public string InitString;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=30)] public string Attention;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=50)] public string Hangup;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=30)] public string Reset_Renamed;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=30)] public string Answer;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=30)] public string Dial;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=30)] public string Busy;
			public int HighestBaud;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=40)] public string Connect;
		}
		
		//-- Length of the MW_ModemInfoType structure.
		public const int LenModemType = 447;
		
		//-- MW_CurModem contains the current modem's information.
		//AIS-1178 NGONZALEZ
		static public MW_ModemInfoType[] MW_CurModem;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		
		//-- MW_CurModemIndex contains the Tag properties of each of the
		//   comm controls in your project.
		static public string[] MW_CurModemIndex = null;
		static public int MW_HighModemNumber = 0;
		
		//---------------------------- Script Stuff -----------------------------
		
		//-- Internal: Length of each recorded "WAITFOR" String
		//   when recording a script.
		static public int MW_ScriptWaitLen = 0;
		
		//-- Internal: Used to store script variables.
		public struct MW_ScriptVariableType
		{
			public string Variable;
			public string Value;
			public static MW_ScriptVariableType CreateInstance()
			{
					MW_ScriptVariableType result = new MW_ScriptVariableType();
					result.Variable = String.Empty;
					result.Value = String.Empty;
					return result;
			}
		}
		//AIS-1178 NGONZALEZ
		static public MW_ScriptVariableType[] MW_ScriptVars;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		
		//-- Used to store script labels.
		public struct MW_ScriptLabelType
		{
			public string Label;
			public int LineNum;
			public static MW_ScriptLabelType CreateInstance()
			{
					MW_ScriptLabelType result = new MW_ScriptLabelType();
					result.Label = String.Empty;
					return result;
			}
		}
		//AIS-1178 NGONZALEZ
		static public MW_ScriptLabelType[] MW_ScriptLabel;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		
		//-- Script data is stored in an array of this type.
		public struct MW_ScriptDataType
		{
			public string Cmd;
			public string Dat;
			public static MW_ScriptDataType CreateInstance()
			{
					MW_ScriptDataType result = new MW_ScriptDataType();
					result.Cmd = String.Empty;
					result.Dat = String.Empty;
					return result;
			}
		}
		//AIS-1178 NGONZALEZ
		static public MW_ScriptDataType[] MW_RecScriptData;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		
		//-- Script Commands
		public const int MW_SCRIPT_CMD_PORT = 5000; //-- Set the port number.
		public const int MW_SCRIPT_CMD_SETTINGS = 5001; //-- Set the settings.
		public const int MW_SCRIPT_CMD_DIAL = 5002; //-- Dial a number.
		public const int MW_SCRIPT_CMD_TIMEOUT = 5003; //-- Set the Timeout value.
		public const int MW_SCRIPT_CMD_WAITFOR = 5004; //-- Wait for a string.
		public const int MW_SCRIPT_CMD_SEND = 5005; //-- Send a string.
		public const int MW_SCRIPT_CMD_HANGUP = 5006; //-- Hang up the phone.
		public const int MW_SCRIPT_CMD_PROTOCOL = 5007; //-- Set the protocol.
		public const int MW_SCRIPT_CMD_UPLOAD = 5008; //-- Upload (send) a file.
		public const int MW_SCRIPT_CMD_DOWNLOAD = 5009; //-- Download (receive) a file.
		public const int MW_SCRIPT_CMD_PAUSE = 5010; //-- Pause for a number of timer ticks.
		public const int MW_SCRIPT_CMD_STop = 5011; //-- Stops execution of your app (for debugging).
		public const int MW_SCRIPT_CMD_END = 5012; //-- Ends the script.
		public const int MW_SCRIPT_CMD_INPUT = 5013; //-- Asks the user to enter a variable.
		public const int MW_SCRIPT_CMD_CAPTURE = 5014; //-- Captures data to a disk file.
		public const int MW_SCRIPT_CMD_CLOSECAPTURE = 5015; //-- Closes the capture file
		public const int MW_SCRIPT_CMD_LABEL = 5016; //-- Defines a label. I.E. ":JumpHere"
		public const int MW_SCRIPT_CMD_ONTIMEOUTGOTO = 5017; //-- Determines where to branch if a timeout occurs.
		
		//-- ScriptPlay Errors
		public const int MW_SCRIPTPLAY_OK = 5100; //-- Script file ended normally.
		public const int MW_SCRIPTPLAY_BAD_FILE = 5101; //-- An invalid script filename was specified.
		public const int MW_SCRIPTPLAY_BAD_PORT = 5102; //-- An Invalid port was specified.
		public const int MW_SCRIPTPLAY_BAD_SETTINGS = 5103; //-- Invalid settings were specified.
		public const int MW_SCRIPTPLAY_BAD_PROTOCOL = 5104; //-- An invalid protocol was specified.
		public const int MW_SCRIPTPLAY_BAD_XFERFILE = 5105; //-- An invalid filename was specified to Upload or Download.
		public const int MW_SCRIPTPLAY_BAD_COMMAND = 5106; //-- An invalid script command was specified
		public const int MW_SCRIPTPLAY_NOTSUP = 5107; //-- The specified command is not supported by the comm control
		public const int MW_SCRIPTPLAY_NO_PORT = 5108; //-- No port was specified.
		public const int MW_SCRIPTPLAY_NOPROTOCOL = 5109; //-- Tried to transfer a file with no protocol set.
		
		//Used to determine if OK or Cancel was pressed on modally displayed
		//forms. Set to true before showing form, set to false in click event
		//of form's cancel button.
		static public int MW_OkFlag = 0;
		
		//-- Used to temporarily hold Comm settings and phone book entries.
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		public struct MWSettings
		{
			public string SessionName;
			public string SessionNumber;
			public string SessionScript;
			public int CommPort;
			public string Baud;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=1)] public string DataBits;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=1)] public string Parity;
			public string StopBits;
			public int Handshaking;
			public int DTREnable;
			public int RTSEnable;
			public int ParityReplace; //Not currently used
			public string AnswerBack;
			public int AutoScroll;
			public int Emulation;
			public int Backspace;
			public int Echo;
			public int ForeColor;
			public int BackColor;
			public int ColorFilter;
			public int Rows;
			public int Columns;
			public int ScrollRows;
			public string FontName;
			public float FontSize;
			public string FontBold;
			public string FontItalic;
			public int CursorType;
			public static MWSettings CreateInstance()
			{
					MWSettings result = new MWSettings();
					result.SessionName = String.Empty;
					result.SessionNumber = String.Empty;
					result.SessionScript = String.Empty;
					result.Baud = String.Empty;
					result.StopBits = String.Empty;
					result.AnswerBack = String.Empty;
					result.FontName = String.Empty;
					result.FontBold = String.Empty;
					result.FontItalic = String.Empty;
					return result;
			}
		}
		
		//Used to temporarily hold Comm settings set by forms.
		static public MWSettings TempSettings = COMMCTRL.MWSettings.CreateInstance();
		
		//-- ModemWare Copyright (c) 1992 - 1994 Crescent Software.
		//   Written by Carl Franklin with help from and thanks to Bill Conley.
		
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		public struct MW_LinkRecordsType
		{
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=25)] public string VendorName;
			public int Record;
		}
		
		//AIS-1178 NGONZALEZ
		static public MW_ModemInfoType[] MW_ModemInfo;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		static public int CurRec = 0;
		static public string DataFile = String.Empty;
		static public int NumBrands = 0;
		//AIS-1178 NGONZALEZ
		static public MW_LinkRecordsType[] MW_LinkRecords;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		static public int MW_NumRecords = 0;
		
		//-- ModemWare Copyright (c) 1992 - 1994 Crescent Software.
		//   Written by Carl Franklin with help from and thanks to Bill Conley.
		
		static public void  AddToRecScriptData( string Cmd,  string Dat)
		{
			//-- This routine is called by all modemware routines
			//   that wish to log action to the script. If you have custom programmed
			//   actions that you wish to log, you can do so by calling this routine.
			//   The only restriction is that Cmd$ must be a valid script command.
			
			int NewScript = MW_RecScriptData.GetUpperBound(0) + 1;
			//UPGRADE_WARNING: (1042) Array MW_RecScriptData may need to have individual elements initialized.
			MW_RecScriptData = ArraysHelper.RedimPreserve<MW_ScriptDataType[]>(MW_RecScriptData, new int[]{NewScript});
			MW_RecScriptData[NewScript].Cmd = Cmd;
			MW_RecScriptData[NewScript].Dat = Dat;
			
		}
		
		
		static string Last_StatusPrint = String.Empty;
		static public void  StatusPrint( string Msg)
		{
			//-- This routine prints a message in the status box
			//   at the bottom of the form.
			
			//UPGRADE_ISSUE: (2064) PictureBox method Status.Cls was not upgraded.
            //AIS-1167 NGONZALEZ
            CORTRAMO.DefInstance.Status.Text = String.Empty;
			
			if (Msg.Length == 0)
			{
				//UPGRADE_ISSUE: (2064) PictureBox method Status.Print was not upgraded.
                //AIS-1167 NGONZALEZ
                CORTRAMO.DefInstance.Status.Text = " " + Last_StatusPrint;
			} else
			{
				//UPGRADE_ISSUE: (2064) PictureBox method Status.Print was not upgraded.
                //AIS-1167 NGONZALEZ
                CORTRAMO.DefInstance.Status.Text = " " + Msg;
			}
			
			Last_StatusPrint = Msg;
			
		}
		
		static public int BInstr( int Start, ref  string Source, ref  string Search)
		{
			
			int Last = 0;
			
			int Current = Start;
			do 
			{
				Current = Strings.InStr(Current, Source, Search, CompareMethod.Binary);
				if (Current == 0)
				{
					break;
				}
				Last = Current;
				Current++;
			}
			while(true);
			return Last;
			
		}
		
		static public int Script2Cmd( string NextLine)
		{
			//-- Internal function that converts a script command (string) to
			//   a script command code.
			
			int result = 0;
			int T = 0;
			string Cmd = String.Empty;
			
			string Temp = NextLine.ToUpper();
			int Sp = (Temp.IndexOf(' ') + 1);
			if (Sp != 0)
			{
				Cmd = Temp.Substring(0, Math.Min(Temp.Length, Sp - 1));
			} else
			{
				T = (Temp.IndexOf("\t") + 1);
				if (T > 1)
				{
					Cmd = Temp.Substring(0, Math.Min(Temp.Length, T - 1));
				} else
				{
					if (NextLine.Length != 0)
					{
						Cmd = NextLine;
					}
				}
			}
			
			switch(Cmd)
			{
				case "PORT" : 
					result = MW_SCRIPT_CMD_PORT; 
					break;
				case "SETTINGS" : 
					result = MW_SCRIPT_CMD_SETTINGS; 
					break;
				case "DIAL" : 
					result = MW_SCRIPT_CMD_DIAL; 
					break;
				case "TIMEOUT" : 
					result = MW_SCRIPT_CMD_TIMEOUT; 
					break;
				case "WAITFOR" : 
					result = MW_SCRIPT_CMD_WAITFOR; 
					break;
				case "SEND" : 
					result = MW_SCRIPT_CMD_SEND; 
					break;
				case "HANGUP" : 
					result = MW_SCRIPT_CMD_HANGUP; 
					break;
				case "PROTOCOL" : 
					result = MW_SCRIPT_CMD_PROTOCOL; 
					break;
				case "UPLOAD" : 
					result = MW_SCRIPT_CMD_UPLOAD; 
					break;
				case "DOWNLOAD" : 
					result = MW_SCRIPT_CMD_DOWNLOAD; 
					break;
				case "PAUSE" : 
					result = MW_SCRIPT_CMD_PAUSE; 
					break;
				case "STop" : 
					result = MW_SCRIPT_CMD_STop; 
					break;
				case "END" : 
					result = MW_SCRIPT_CMD_END; 
					break;
				case "INPUT" : 
					result = MW_SCRIPT_CMD_INPUT; 
					break;
				case "CAPTURE" : 
					result = MW_SCRIPT_CMD_CAPTURE; 
					break;
				case "CLOSECAPTURE" : 
					result = MW_SCRIPT_CMD_CLOSECAPTURE; 
					break;
				case "ON_TIMEOUT_GOTO" : 
					result = MW_SCRIPT_CMD_ONTIMEOUTGOTO; 
					 
					break;
			}
			
			return result;
		}
		
		static public void  ScriptRaw2File( string ScriptFileName)
		{
			//-- Internal: This subroutine writes recorded script data to the file
			//   specified by ScriptRecord.
			
			int LastIndex = 0;
			int Comma = 0;
			string Dat = String.Empty, LastCmd = String.Empty, Cmd = String.Empty, Out_Renamed = String.Empty;
			StringBuilder Pressed = new StringBuilder();
			Pressed.Append(String.Empty);
			
			int Total = MW_RecScriptData.GetUpperBound(0);
			
			//-- Convert IN and OUT to WAITFOR and SEND
			//   and take out Waitfors that wait for keys pressed
			
			for (int I = 1; I <= Total; I++)
			{
				if (MW_RecScriptData[I].Cmd == "IN")
				{
					MW_RecScriptData[I].Cmd = "WAITFOR";
				}
				if (MW_RecScriptData[I].Cmd == "OUT")
				{
					MW_RecScriptData[I].Cmd = "SEND";
				}
				
				if (MW_RecScriptData[I].Cmd.Length != 0)
				{
					switch(MW_RecScriptData[I].Cmd)
					{
						case "WAITFOR" : 
							do 
							{
								if (Pressed.ToString().Length == 0)
								{
									break;
								}
								if (MW_RecScriptData[I].Dat.Substring(0, Math.Min(MW_RecScriptData[I].Dat.Length, 1)).ToUpper() == Pressed.ToString().Substring(0, Math.Min(Pressed.ToString().Length, 1)))
								{
									MW_RecScriptData[I].Dat = MW_RecScriptData[I].Dat.Substring(MW_RecScriptData[I].Dat.Length - (MW_RecScriptData[I].Dat.Length - 1));
								}
								Pressed = new StringBuilder(Pressed.ToString().Substring(Pressed.ToString().Length - (Pressed.ToString().Length - 1)));
							}
							while(true); 
							if (MW_RecScriptData[I].Dat.Length == 0)
							{
								MW_RecScriptData[I].Cmd = "";
							} 
							break;
						case "SEND" : 
							Pressed.Append(MW_RecScriptData[I].Dat.ToUpper()); 
							break;
					}
				}
			}
			
			//-- Concatonate IN and OUT commands that occur sequentially
			for (int I = 1; I <= Total; I++)
			{
				
				if (MW_RecScriptData[I].Cmd.Length != 0)
				{
					if (MW_RecScriptData[I].Cmd == "WAITFOR" || MW_RecScriptData[I].Cmd == "SEND")
					{
						if (MW_RecScriptData[I].Cmd == LastCmd)
						{
							MW_RecScriptData[LastIndex].Dat = MW_RecScriptData[LastIndex].Dat + MW_RecScriptData[I].Dat;
							MW_RecScriptData[I].Cmd = "";
						} else
						{
							LastCmd = MW_RecScriptData[I].Cmd;
							LastIndex = I;
						}
					} else
					{
						LastCmd = MW_RecScriptData[I].Cmd;
						LastIndex = I;
					}
				}
			}
			
			//-- write to the file
			int FileNum = FileSystem.FreeFile();
			FileSystem.FileOpen(FileNum, ScriptFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
			
			for (int I = 1; I <= Total; I++)
			{
				if (MW_RecScriptData[I].Cmd.Length != 0)
				{
					if (MW_RecScriptData[I].Cmd == "WAITFOR")
					{
						if (MW_ScriptWaitLen != 0)
						{
							MW_RecScriptData[I].Dat = MW_RecScriptData[I].Dat.Substring(MW_RecScriptData[I].Dat.Length - Math.Min(MW_RecScriptData[I].Dat.Length, MW_ScriptWaitLen));
						}
					}
					Cmd = AddCaret(MW_RecScriptData[I].Cmd);
					Dat = AddCaret(MW_RecScriptData[I].Dat);
					Out_Renamed = Cmd + " ";
					switch(Cmd)
					{
						case "WAITFOR" : case "SEND" : case "PROTOCOL" : case "SETTINGS" : case "DOWNLOAD" : case "UPLOAD" : case "CAPTURE" : 
							Out_Renamed = Out_Renamed + "\"" + Dat + "\""; 
							break;
						case "DIAL" : 
							string tempRefParam = ","; 
							Comma = BInstr(1, ref Dat, ref tempRefParam); 
							if (Comma != 0)
							{
								Out_Renamed = Out_Renamed + "\"" + Dat.Substring(0, Math.Min(Dat.Length, Comma - 1)) + "\"" + Strings.Mid(Dat, Comma);
							} else
							{
								Out_Renamed = Out_Renamed + "\"" + Dat + "\"";
							} 
							break;
						default:
							Out_Renamed = Out_Renamed + Dat; 
							break;
					}
					
					FileSystem.PrintLine(FileNum, Out_Renamed);
				}
			}
			FileSystem.PrintLine(FileNum, ":TIMEOUT");
			FileSystem.PrintLine(FileNum, "END");
			FileSystem.FileClose(FileNum);
			
		}
		//''''
		//''''Sub ScriptRecord(Comm1 As Control, Filename$, Length)
		//'''''-- This routine opens a script file to be recorded.
		//'''''   All ModemWare routines write their actions to a script
		//'''''   array if a script is being recorded. It's built in!
		//''''
		//''''    Static OldAutoProcess, OldRThreshold, ScriptFileName$
		//''''    If Len(Filename$) = 0 Then
		//''''        If MW_ScriptRecording Then
		//''''            CORTRAMO!Comm1.AutoProcess = OldAutoProcess
		//''''            CORTRAMO!Comm1.RThreshold = OldRThreshold
		//''''            MW_ScriptRecording = False
		//''''            Call ScriptRaw2File(ScriptFileName$)
		//''''            ScriptFileName$ = ""
		//''''        Else
		//''''            MsgBox "Error - ScriptRecord called with "" when no script was being recorded"
		//''''        End If
		//''''        Exit Sub
		//''''    Else
		//''''        ScriptFileName$ = Filename$
		//''''        MW_ScriptWaitLen = Length
		//''''        OldAutoProcess = CORTRAMO!Comm1.AutoProcess
		//''''        OldRThreshold = CORTRAMO!Comm1.RThreshold
		//''''        ReDim MW_RecScriptData(1 To 3) As MW_ScriptDataType
		//''''        MW_RecScriptData(1).Cmd$ = "PORT"
		//''''        MW_RecScriptData(1).Dat$ = Trim$(Str$(CORTRAMO!Comm1.CommPort))
		//''''        MW_RecScriptData(2).Cmd$ = "TIMEOUT"
		//''''        MW_RecScriptData(2).Dat$ = "60"
		//''''        MW_RecScriptData(3).Cmd$ = "ON_TIMEOUT_GOTO"
		//''''        MW_RecScriptData(3).Dat$ = ":TIMEOUT"
		//''''
		//''''        CORTRAMO!Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
		//''''        CORTRAMO!Comm1.RThreshold = 1
		//''''        MW_ScriptRecording = True
		//''''    End If
		//''''
		//''''End Sub
		//''''
		//''''
		//''''
		//''''
		//''''Sub InitModemWare()
		//'''''-- Called by all ModemWare routines
		//''''
		//''''    MW_CR$ = Chr$(13)
		//''''    MW_LF$ = Chr$(10)
		//''''     MW_CRLF$ = Chr$(13) & Chr$(10)
		//''''    MW_ESC$ = Chr$(27)
		//''''    MW_BS$ = Chr$(8)
		//''''    MW_SP$ = Chr$(32)
		//''''    MW_Init = True
		//''''
		//''''End Sub
		
		static public int MWError()
		{
			//-- Returns the current ModemWare error.
			
			return MW_ErrCode;
			
		}
		
		//''''
		//''''Function MWErrorMsg$()
		//'''''-- Returns an error string based on the current ModemWare Error
		//''''
		//''''    Select Case MWError()
		//''''        '-- General Errors
		//''''        Case MW_ER_CANCELED
		//''''            MWErrorMsg$ = "Process Canceled By User"
		//''''        Case MW_ER_LOST_CARRIER
		//''''            MWErrorMsg$ = "Carrier Lost. The Call Has Been Disconnected"
		//''''        Case MW_ER_PORTCLOSED
		//''''            MWErrorMsg$ = "The Specified Port Is Not Open"
		//''''        Case MW_ER_CTRLERROR
		//''''            MWErrorMsg$ = "The Specified Comm Control Can Not Be Accessed"
		//''''        Case MW_ER_TIMEOUT
		//''''            MWErrorMsg$ = "Timeout Error"
		//''''
		//''''        '-- AsciiSend Errors
		//''''        Case MW_ASCIISEND_OK
		//''''            MWErrorMsg$ = "File sent ok."
		//''''        Case MW_ASCIISEND_NOTFOUND
		//''''            MWErrorMsg$ = "File not found."
		//''''        Case MW_ASCIISEND_FILE_ERR
		//''''            MWErrorMsg$ = "Error reading file."
		//''''
		//''''        '-- GetModemIndex Errors
		//''''        Case MW_GETMODEMINDEX_ERROR
		//''''            MWErrorMsg$ = "No Current Modems. Please configure your modem."
		//''''
		//''''        '-- GetCommMessage Errors
		//''''        'Case MW_GETMSG_OK
		//''''        '    MWErrorMsg$ = "Valid Message Received"
		//''''        'Case MW_GETMSG_INVALID_MSG
		//''''        '    MWErrorMsg$ = "Invalid Message Received"
		//''''
		//''''        '-- Hangup Errors
		//''''        Case MW_HANGUP_OK
		//''''            MWErrorMsg$ = "Modem Disconnected"
		//''''        Case MW_HANGUP_ERROR
		//''''            MWErrorMsg$ = "Modem Could Not Be Disconnected"
		//''''        Case MW_HANGUP_OFFLINE
		//''''            MWErrorMsg$ = "Modem Is Not Online"
		//''''            If CORTRAMO!Comm1.PortOpen = True Then
		//''''              CORTRAMO!Comm1.Output = "ATH" + Chr$(13) + Chr$(10)
		//''''              CORTRAMO!Comm1.SThreshold = 0
		//''''            End If
		//''''        '-- InitModem Errors
		//''''        Case MW_INITMODEM_OK
		//''''            MWErrorMsg$ = "Modem Initialized"
		//''''        Case MW_INITMODEM_NO_MODEM
		//''''            MWErrorMsg$ = "Invalid Baud Rate, No Modem Found, Or Modem Is Turned Off Or Not Connected"
		//''''        Case MW_INITMODEM_ONLINE
		//''''            MWErrorMsg$ = "Modem Is Online And Cannot Be Initialized"
		//''''        Case MW_INITMODEM_BAD_PORT
		//''''            MWErrorMsg$ = "Invalid Port number Specified"
		//''''        Case MW_INITMODEM_BAD_SETTINGS
		//''''            MWErrorMsg$ = "Invalid Settings Specified"
		//''''        Case MW_INITMODEM_BAUD_DRIVER
		//''''            MWErrorMsg$ = "Specified baud rate is not supported by the comm control/driver"
		//''''        Case MW_INITMODEM_BAUD_MODEM
		//''''            MWErrorMsg$ = "Specified baud rate is not supported by your modem"
		//''''
		//''''        '-- OpenPort Errors
		//''''        Case MW_OPENPORT_OK
		//''''            MWErrorMsg$ = "Port opened ok"
		//''''        Case MW_OPENPORT_ERROR
		//''''            MWErrorMsg$ = "No ports are avaiable"
		//''''        Case MW_OPENPORT_SETTINGS
		//''''            MWErrorMsg$ = "The specified settings are invalid"
		//''''
		//''''        '-- PlaceCall Errors
		//''''        Case MW_PLACECALL_OK
		//''''            MWErrorMsg$ = "A valid result code was returned. Check Result"
		//''''
		//''''        '-- ScriptPlay Errors
		//''''        Case MW_SCRIPTPLAY_OK
		//''''            MWErrorMsg$ = "Script Completed"
		//''''        Case MW_SCRIPTPLAY_BAD_FILE
		//''''            MWErrorMsg$ = "An invalid script filename was specified."
		//''''        Case MW_SCRIPTPLAY_BAD_PORT
		//''''            MWErrorMsg$ = "An Invalid port was specified."
		//''''        Case MW_SCRIPTPLAY_BAD_SETTINGS
		//''''            MWErrorMsg$ = "Invalid settings were specified."
		//''''        Case MW_SCRIPTPLAY_BAD_PROTOCOL
		//''''            MWErrorMsg$ = "An invalid protocol was specified."
		//''''        Case MW_SCRIPTPLAY_BAD_XFERFILE
		//''''            MWErrorMsg$ = "An invalid transfer filename was specified."
		//''''        Case MW_SCRIPTPLAY_BAD_COMMAND
		//''''            MWErrorMsg$ = "Invalid script command, or syntax error."
		//''''        Case MW_SCRIPTPLAY_NOTSUP
		//''''            MWErrorMsg$ = "The specified command is not supported by the comm control."
		//''''        Case MW_PLACECALL_NO_PORT
		//''''            MWErrorMsg$ = "No port was specified."
		//''''        Case MW_SCRIPTPLAY_NOPROTOCOL
		//''''            MWErrorMsg$ = "Tried to transfer a file with no protocol set."
		//''''
		//''''        '-- SendCommMsg Errors
		//''''        Case MW_SENDMSG_OK
		//''''            MWErrorMsg$ = "Valid CRESCENT MESSAGE sent."
		//''''        Case MW_SENDMODEMCMD_NOCMD
		//''''            MWErrorMsg$ = "No command was specified."
		//''''
		//''''        '-- SendModemCmd Errors
		//''''        Case MW_SENDMODEMCMD_OK
		//''''            MWErrorMsg$ = "Command sent ok."
		//''''
		//''''        '-- WaitFor Errors
		//''''        Case MW_WAITFOR_OK
		//''''            MWErrorMsg$ = "The wait string was received"
		//''''
		//''''        '-- WaitForCall Errors
		//''''        Case MW_WAITFORCALL_OK
		//''''            MWErrorMsg$ = "Caller Is Connected"
		//''''    End Select
		//''''
		//''''End Function
		
		static public void  MWPause( float Secs)
		{
			//-- Pauses for a number of seconds (or fractions of a second)
			
			
			//-- Tell everybody where we are
			int PrevRoutine = MW_CurRoutine;
			MW_CurRoutine = MW_PROC_HANGUP;
			
			float Start = (float) DateTime.Now.TimeOfDay.TotalSeconds;
			float EndTime = Start + Secs;
			
			
			while(DateTime.Now.TimeOfDay.TotalSeconds <= EndTime)
			{
				Application.DoEvents();
				if (Start > DateTime.Now.TimeOfDay.TotalSeconds)
				{
					//-- Adjust for Midnight
					EndTime -= 24 * 60 * 60;
				}
			}; //Until Timer >= EndTime!
			
			MW_CurRoutine = PrevRoutine;
			
		}
		
		
		static public void  MWSetError( int Code)
		{
			//-- Sets the current ModemWare error
			
			MW_ErrCode = Code;
			
		}
		
		
		static public void  MWStatus( int StatusCode,  string ExtraData)
		{
			//-- This subroutine is called by ModemWare periodically to let the
			//   programmer know what's happenning.
			
			//   StatusCode contains a value, which is used to derive a status message string.
			
			//   ExtraData$ holds different information depending on the StatusCode.
			//   See the PDQComm for Windows documentation for a table of codes and meanings
			
			//   This routine serves as a handy way to update a status bar, but it also
			//   allow you to trap the code for your own purposes, be they debugging or
			//   development.
			
			string Msg = String.Empty;
			
			switch(StatusCode)
			{
				case MW_STAT_SCRIPT_INITIALIZING : 
					Msg = "Script: Initializing the port.."; 
					break;
				case MW_STAT_SCRIPT_WAITFOR : 
					Msg = "Script: Waiting For " + ExtraData; 
					break;
				case MW_STAT_SCRIPT_SEND : 
					Msg = "Script: Sending " + ExtraData; 
					break;
				case MW_STAT_SCRIPT_PORTSET : 
					Msg = "Script: Port is set at " + ExtraData; 
					break;
				case MW_STAT_SCRIPT_CAPTURING : 
					Msg = "Script: Capturing to " + ExtraData; 
					break;
				case MW_STAT_SCRIPT_DIALING : 
					Msg = "Script: Dialing " + ExtraData; 
					break;
				case MW_STAT_SCRIPT_HANGUP : 
					Msg = "Script: Hanging up"; 
					break;
				case MW_STAT_SCRIPT_UPLOAD : 
					Msg = "Script: Uploading " + ExtraData; 
					break;
				case MW_STAT_SCRIPT_DOWNLOAD : 
					Msg = "Script: Downloading " + ExtraData; 
					break;
				case MW_STAT_SCRIPT_REDIALING : 
					Msg = "Script: Redial #" + ExtraData; 
					break;
				case MW_STAT_PHBOOK_DIALING : 
					Msg = "Dialing " + ExtraData; 
					break;
				case MW_STAT_PHBOOK_REDIAL : 
					Msg = "Redial Attempt # " + ExtraData; 
					break;
				case 0 : 
					//-- If StatusCode is zero, just print the ExtraData$ 
					Msg = ExtraData; 
					break;
			}
			
			//-- StatusPrint is a routine in CTRLDEMO.BAS that prints a message on the CTRLDEMO
			//   status bar. You can change this line to print the message anywhere, or just
			//   comment it out. We advise that you write your own StatusPrint subroutine.
			
			StatusPrint(Msg);
			
		}
		//''''Function OpenPort(Comm1 As Control, PortNum, BaudRate&, Settings$)
		//''''
		//''''Dim First As Integer, i As Integer, OP As Integer
		//''''
		//'''''-- This routine opens the first available comm port.
		//''''
		//''''    '-- Settings
		//''''    On Error Resume Next
		//''''    CORTRAMO!Comm1.Settings = LTrim$(Str$(BaudRate&)) & "," & Settings$
		//''''    If Err Then
		//''''        MWSetError MW_OPENPORT_SETTINGS
		//''''        Exit Function
		//''''    End If
		//''''    On Error GoTo 0
		//''''
		//''''    '-- Tell everybody where we are
		//''''    If Not MW_CurRoutine Then
		//''''        MW_CurRoutine = MW_PROC_OPENPORT
		//''''    End If
		//''''
		//''''    '-- Was PortNum not specified?
		//''''    If PortNum = 0 Then
		//''''        First = 1
		//''''    Else
		//''''        First = PortNum
		//''''    End If
		//''''
		//''''    On Error Resume Next
		//''''    OP = 0
		//''''    For i = First To 9
		//''''        DoEvents
		//''''        If MW_CancelFlag Then
		//''''            MWSetError MW_ER_CANCELED
		//''''            GoTo OPExit
		//''''        End If
		//''''
		//''''        '-- Check ports 1 through 9
		//''''        CORTRAMO!Comm1.CommPort = i
		//''''        '-- Trap VB errors
		//''''        '-- Try to open the port
		//''''        CORTRAMO!Comm1.PortOpen = True
		//''''        If Err = 0 Then
		//''''            OP = i
		//''''            MWSetError MW_OPENPORT_OK
		//''''            Exit For
		//''''        Else
		//''''            Err = 0
		//''''        End If
		//''''    Next
		//''''    If OP = 0 Then
		//''''        MWSetError MW_OPENPORT_ERROR
		//''''    End If
		//''''    OpenPort = OP
		//''''
		//''''OPExit:
		//''''    MW_CurRoutine = MW_PROC_NONE
		//''''    On Error GoTo 0
		//''''
		//''''End Function
		
		
		//Accepts a string containing settings (e.g. "9600,N,8,1") and extracts individual components.
		//Returns False if there was an error, and True if settings are OK.
		static public int ParseSettings( string Settings, ref  string Baud, ref  string Parity, ref  string DataBits, ref  string StopBits)
		{
			
			
			//Since we check each component, it doesn't matter if Settings is too
			//short. We don't want to quit if Mid$ and Left$ generate an error.
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			int result = 0;
			try
			{
					
					//Find the first comma.
					int Comma = (Settings.IndexOf(',') + 1);
					if (Comma == 0)
					{
						goto InvalidSettings;
					}
					
					//Get and check the baud rate.
					Baud = Settings.Substring(0, Math.Min(Settings.Length, Comma - 1));
					switch(Baud)
					{
						case "110" : case "300" : case "600" : case "1200" : case "2400" : case "4800" : case "9600" : case "14400" : case "19200" : case "28800" : case "38400" : case "57600" : case "115200" : case "230400" : 
							//It's OK. 
							break;
						default:
							goto InvalidSettings; 
							break;
					}
					
					//Get and check the parity.
					Parity = Strings.Mid(Settings, Comma + 1, 1);
					Parity = Parity.ToUpper();
					switch(Parity)
					{
						case "E" : case "O" : case "N" : case "S" : case "M" : 
							//It's OK. 
							break;
						default:
							goto InvalidSettings; 
							break;
					}
					
					//Get and check the data bits.
					DataBits = Strings.Mid(Settings, Comma + 3, 1);
					switch(DataBits)
					{
						case "4" : case "5" : case "6" : case "7" : case "8" : 
							//It's OK. 
							break;
						default:
							goto InvalidSettings; 
							break;
					}
					
					//Get and check the stop bits.
					StopBits = Strings.Mid(Settings, Comma + 5);
					switch(StopBits)
					{
						case "1" : case "1.5" : case "2" : 
							//It's OK. 
							break;
						default:
							goto InvalidSettings; 
							break;
					}
					
					//If we got here, everything must be OK.
					return -1;
					
InvalidSettings: 
					result = 0;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
			return result;
		}
		
		
		static public string RemoveCaret(ref  string CaretString)
		{
			//-- Translates caret codes into ascii characters
			
			int Caret = 0, L = 0;
			string Char_Renamed = String.Empty;
			StringBuilder Temp = new StringBuilder();
			Temp.Append(String.Empty);
			int CheckCharVal = 0;
			
			do 
			{
				Caret = (CaretString.IndexOf('^') + 1);
				L = CaretString.Length;
				if (Caret != 0)
				{
					if (Caret < L)
					{
						
						//Fixed 6-30-95 WM
						//*** This is the original line of code. It didn't check the validity of the control character.
						//Char$ = Chr$(Asc(Mid$(CaretString$, Caret + 1, 1)) - 64)
						
						//*** Replaced with the following block of code, which does validate the code.
						
						//Get the ASCII value of the character following the caret.
						CheckCharVal = ((int) Strings.Mid(CaretString, Caret + 1, 1).ToUpper()[0]) - 64;
						
						//Make sure only characters from 1 to 31 are returned.
						if ((CheckCharVal > 0) && (CheckCharVal < 32))
						{
							
							//It's in range, so convert it to a character.
							Char_Renamed = Strings.Chr(CheckCharVal).ToString();
							
						} else
						{
							
							//It's out of range, and would create a "junk" character, so just skip it.
							Char_Renamed = "";
							
						}
						
						//*** End of new code.
						
						Temp = new StringBuilder(CaretString.Substring(0, Math.Min(CaretString.Length, Caret - 1)) + Char_Renamed);
						if (Caret + 2 <= L)
						{
							Temp.Append(Strings.Mid(CaretString, Caret + 2));
						}
						CaretString = Temp.ToString();
					}
				} else
				{
					break;
				}
			}
			while(true);
			return CaretString;
			
		}
		//''''
		//''''
		//''''Function WaitFor$(Comm1 As Control, Wait$, TimeOut%, CDFlag%, ExcludeFlag%)
		//'''''-- Waits X number of seconds to receive a string or character.
		//'''''   This can be used with any hardware, not just modems, as a means of
		//'''''   receiving a particular string. For example, if you are connected to
		//'''''   a machine that sends a string ending in a Chr$(13), you can call WaitFor
		//'''''   with Wait$ = Chr$(13). It will return all data received up to the Chr$(13).
		//''''
		//''''Dim Test As Integer, AutoP As Integer, RT As Integer, OldLen As Integer, There As Integer
		//''''Dim LastInLen As Integer
		//''''Dim Start!, EndTime!, NewData$, Work$, DispStr$, CurTime!
		//''''
		//''''On Error Resume Next
		//''''
		//''''
		//''''    '-- Test Comm port validity
		//''''    On Error Resume Next
		//''''    Test = CORTRAMO!Comm1.CommPort
		//''''    If Err Then
		//''''        '-- Port can not be accessed
		//''''        MWSetError MW_ER_CTRLERROR
		//''''        Exit Function
		//''''    Else
		//''''        If CORTRAMO!Comm1.PortOpen = False Then
		//''''            '-- Port it closed
		//''''            MWSetError MW_ER_PORTCLOSED
		//''''            Exit Function
		//''''        End If
		//''''    End If
		//''''    On Error GoTo 0
		//''''
		//''''    '-- InitModemWare initializes MW_CR$, MW_LF$, etc.
		//''''    Call InitModemWare
		//''''
		//''''    '-- Initialize MW_CancelFlag
		//''''    MW_CancelFlag = False
		//''''
		//''''    '-- Tell everybody where we are
		//''''    If Not MW_CurRoutine Then
		//''''        MW_CurRoutine = MW_PROC_WAITFOR
		//''''    End If
		//''''
		//''''    '-- Turn Off AutoProcess & RThreshold
		//''''    AutoP = CORTRAMO!Comm1.AutoProcess
		//''''    If AutoP Then
		//''''        CORTRAMO!Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
		//''''    End If
		//''''    RT = CORTRAMO!Comm1.RThreshold
		//''''    If RT Then
		//''''        CORTRAMO!Comm1.RThreshold = 0
		//''''    End If
		//''''
		//''''    '-- Display without emulation?
		//''''    If MW_DisplayFlag Then
		//''''        If CORTRAMO!Comm1.Emulation = 0 Then
		//''''            MW_DisplayFlag = False
		//''''        End If
		//''''    End If
		//''''
		//''''    '-- InputLen must be 1
		//''''    OldLen = CORTRAMO!Comm1.InputLen
		//''''    If OldLen <> 0 Then
		//''''        CORTRAMO!Comm1.InputLen = 0
		//''''    End If
		//''''
		//''''    '-- Initialize variables just in case they were passed in
		//''''    MWSetError False
		//''''    Work$ = MW_LeftOver$
		//''''    LastInLen = 0
		//''''
		//''''    Start! = Timer
		//''''    EndTime! = Start! + TimeOut
		//''''    '-- Check for time to wrap around midnight
		//'''''   If Timer + TimeOut > 86400 Then
		//'''''        EndTime! = TimeOut - (86400 - Timer)
		//'''''    Else
		//'''''        EndTime! = Start! + TimeOut
		//'''''    End If
		//''''
		//''''    '-- And they're off!
		//''''    Do
		//'''''        If lAcceso = 1 Then
		//'''''          Exit Function
		//'''''          Exit Do
		//'''''        End If
		//''''        If Len(Work$) <> LastInLen Then
		//''''            '-- Did we get what we're waiting for?
		//''''            There = InStr(Work$, Wait$)
		//''''            If There Then
		//''''                If MW_DisplayFlag Then
		//''''                    CORTRAMO!Comm1.Disp = DispStr$
		//''''                    DoEvents
		//''''                End If
		//''''                If ExcludeFlag Then
		//''''                    WaitFor$ = Left$(Work$, There - 1)
		//''''                Else
		//''''                    WaitFor$ = Left$(Work$, There + Len(Wait$))
		//''''                End If
		//''''                MW_LeftOver$ = Mid$(Work$, There + Len(Wait$))
		//''''                MWSetError MW_WAITFOR_OK
		//''''                Exit Do
		//''''            End If
		//''''            LastInLen = Len(Work$)
		//''''        End If
		//''''        '-- Have we received any data?
		//''''           If CORTRAMO!Comm1.InBufferCount Then
		//''''               '-- Get the data
		//''''               MWPause 0.5
		//''''               NewData$ = CORTRAMO!Comm1.Input
		//''''               If Err = 91 Then
		//''''                 MsgBox "   "
		//''''               End If
		//''''               DoEvents
		//''''               '-- Add it to Work$
		//''''               Work$ = Work$ & NewData$
		//''''
		//''''               '-- Add it to a display string (if MW_DisplayFlag)
		//''''               If MW_DisplayFlag Then
		//''''                   DispStr$ = DispStr$ & NewData$
		//''''                   If Len(DispStr$) > 32 Then
		//''''                       CORTRAMO!Comm1.Disp = DispStr$
		//''''                       DoEvents
		//''''                       DispStr$ = ""
		//''''                   End If
		//''''               End If
		//''''
		//''''
		//''''               '-- Is Work$ getting too big?
		//''''               If Len(Work$) > 16384 Then
		//''''                   '-- Trim it
		//''''                   WaitFor$ = Work$
		//''''                   MW_LeftOver$ = ""
		//''''                   MWSetError MW_WAITFOR_CONTINUE
		//''''                   Exit Do
		//''''               End If
		//''''           Else
		//''''               '-- No new data, display DispStr$
		//''''               If Len(DispStr$) Then
		//''''                   CORTRAMO!Comm1.Disp = DispStr$
		//''''                   DoEvents
		//''''                   DispStr$ = ""
		//''''               End If
		//''''           End If
		//''''
		//''''        '-- Have we been Canceled?
		//''''        If MW_CancelFlag Then
		//''''            MW_CancelFlag = False
		//''''            MWSetError MW_ER_CANCELED
		//''''            WaitFor$ = Work$
		//''''            Exit Do
		//''''        End If
		//''''
		//''''        '-- Check Carrier
		//''''        If CDFlag Then
		//''''            If CORTRAMO!Comm1.CDHolding = False Then
		//''''                MWSetError MW_ER_LOST_CARRIER
		//''''                WaitFor$ = Work$
		//''''                Exit Do
		//''''            End If
		//''''        End If
		//''''
		//''''        '-- Are we out of time
		//''''        CurTime! = Timer
		//''''        If CurTime! < Start! Then
		//''''            CurTime! = CurTime! + 86400!
		//''''        End If
		//''''        If CurTime! >= EndTime! Then
		//''''            MWSetError MW_ER_TIMEOUT
		//''''            WaitFor$ = Work$
		//''''            Exit Do
		//''''        End If
		//''''
		//''''        DoEvents
		//''''
		//''''    Loop
		//''''
		//''''    '-- Reset InputLen
		//''''    If OldLen Then
		//''''        CORTRAMO!Comm1.InputLen = OldLen
		//''''    End If
		//''''
		//''''WFExit:
		//''''
		//''''    '-- Reset AutoProcess and RThreshold
		//''''    If AutoP Then
		//''''        CORTRAMO!Comm1.AutoProcess = AutoP
		//''''    End If
		//''''    If RT Then
		//''''        CORTRAMO!Comm1.RThreshold = RT
		//''''    End If
		//''''
		//''''    MW_CurRoutine = MW_PROC_NONE
		//''''
		//End Function
		//''''
		//''''
		//''''Function WaitForA$(Comm1 As Control, Wait$(), TimeOut, CDFlag, ExcludeFlag, Found)
		//'''''-- Same as WaitFor$ (See WaitFor$) but accepts an array as an argument.
		//'''''   WaitForA$ returns when it finds any one of the specified strings.
		//''''
		//''''Dim Test As Integer, AutoP As Integer, RT As Integer, NumEls As Integer
		//''''Dim FirstEl As Integer, OldLen As Integer, i As Integer, There As Integer
		//''''Dim LastInLen As Integer
		//''''Dim NewData$, T$, Work$, DispStr$, Start!, EndTime!, CurTime!
		//''''
		//''''    '-- Test Comm port validity
		//''''    On Error Resume Next
		//''''    Test = CORTRAMO!Comm1.CommPort
		//''''    If Err Then
		//''''        '-- Port can not be accessed
		//''''        MWSetError MW_ER_CTRLERROR
		//''''        Exit Function
		//''''    Else
		//''''        If CORTRAMO!Comm1.PortOpen = False Then
		//''''            '-- Port it closed
		//''''            MWSetError MW_ER_PORTCLOSED
		//''''            Exit Function
		//''''        End If
		//''''    End If
		//''''    On Error GoTo 0
		//''''
		//''''    '-- InitModemWare initializes MW_CR$, MW_LF$, etc.
		//''''    Call InitModemWare
		//''''
		//''''    '-- Initialize MW_CancelFlag
		//''''    MW_CancelFlag = False
		//''''
		//''''    '-- Tell everybody where we are
		//''''    If Not MW_CurRoutine Then
		//''''        MW_CurRoutine = MW_PROC_WAITFORA
		//''''    End If
		//''''
		//''''    '-- Turn Off AutoProcess & RThreshold
		//''''    AutoP = CORTRAMO!Comm1.AutoProcess
		//''''    If AutoP Then
		//''''        CORTRAMO!Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
		//''''    End If
		//''''    RT = CORTRAMO!Comm1.RThreshold
		//''''    If RT Then
		//''''        CORTRAMO!Comm1.RThreshold = 0
		//''''    End If
		//''''
		//''''    '-- Number of strings
		//''''    On Error Resume Next
		//''''    If Err Then GoTo WFAExit
		//''''    NumEls = UBound(Wait$)
		//''''    FirstEl = LBound(Wait$)
		//''''
		//''''    '-- Display without emulation?
		//''''    If MW_DisplayFlag Then
		//''''        If CORTRAMO!Comm1.Emulation = 0 Then
		//''''            MW_DisplayFlag = False
		//''''        End If
		//''''    End If
		//''''
		//''''    '-- InputLen must be 1
		//''''    OldLen = CORTRAMO!Comm1.InputLen
		//''''    If OldLen <> 0 Then
		//''''        CORTRAMO!Comm1.InputLen = 0
		//''''    End If
		//''''
		//''''    '-- Initialize variables just in case they were passed in
		//''''    MWSetError False
		//''''    Found = -1
		//''''
		//''''    Start! = Timer
		//''''    EndTime! = Start! + TimeOut
		//''''    '-- Check for time to wrap around midnight
		//'''''    If Timer + TimeOut > 86400 Then
		//'''''        EndTime! = TimeOut - (86400 - Timer)
		//'''''    Else
		//'''''        EndTime! = Start! + TimeOut
		//'''''    End If
		//''''
		//''''    '-- And they're off!
		//''''    LastInLen = 0
		//''''    Work$ = MW_LeftOver$
		//''''    Do
		//''''        If Len(Work$) <> LastInLen Then
		//''''            '-- Did we get what we're waiting for?
		//''''            For i = FirstEl To NumEls
		//''''                There = InStr(Work$, Wait$(i))
		//''''                If There Then Exit For
		//''''            Next
		//''''            If There Then
		//''''                If MW_DisplayFlag Then
		//''''                    CORTRAMO!Comm1.Disp = DispStr$
		//''''                    DoEvents
		//''''                End If
		//''''                If ExcludeFlag Then
		//''''                    WaitForA$ = Left$(Work$, There - 1)
		//''''                Else
		//''''                    WaitForA$ = Left$(Work$, There + Len(Wait$(i)) - 1)
		//''''                End If
		//''''                MW_LeftOver$ = Mid$(Work$, There + Len(Wait$(i)))
		//''''                Found = i
		//''''                MWSetError MW_WAITFOR_OK
		//''''                Exit Do
		//''''            End If
		//''''            LastInLen = Len(Work$)
		//''''        End If
		//''''        '-- Have we received any data?
		//''''        If CORTRAMO!Comm1.InBufferCount Then
		//''''            '-- Get the data
		//''''            DoEvents
		//''''            NewData$ = CORTRAMO!Comm1.Input
		//''''            '-- Add it to Work$
		//''''            Work$ = Work$ & NewData$
		//''''
		//''''            '-- Add it to a display string (if MW_DisplayFlag)
		//''''            If MW_DisplayFlag Then
		//''''                DispStr$ = DispStr$ & NewData$
		//''''                If Len(DispStr$) > 32 Then
		//''''                    CORTRAMO!Comm1.Disp = DispStr$
		//''''                    DoEvents
		//''''                    DispStr$ = ""
		//''''                End If
		//''''            End If
		//''''
		//''''
		//''''            '-- Is Work$ getting too big?
		//''''            If Len(Work$) > 16384 Then
		//''''                WaitForA$ = Work$
		//''''                MW_LeftOver$ = ""
		//''''                MWSetError MW_WAITFOR_CONTINUE
		//''''                Exit Do
		//''''            End If
		//''''
		//''''        Else
		//''''            '-- No new data, display DispStr$
		//''''            If Len(DispStr$) Then
		//''''                CORTRAMO!Comm1.Disp = DispStr$
		//''''                DoEvents
		//''''                DispStr$ = ""
		//''''            End If
		//''''
		//''''        End If
		//''''
		//''''        '-- Have we been Canceled?
		//''''        If MW_CancelFlag Then
		//''''            MW_CancelFlag = False
		//''''            MWSetError MW_ER_CANCELED
		//''''            Exit Do
		//''''        End If
		//''''
		//''''        '-- Check Carrier
		//''''        If CDFlag Then
		//''''            If CORTRAMO!Comm1.CDHolding = False Then
		//''''                MWSetError MW_ER_LOST_CARRIER
		//''''                Exit Do
		//''''            End If
		//''''        End If
		//''''
		//''''        '-- Are we out of time
		//''''        CurTime! = Timer
		//''''        If CurTime! < Start! Then
		//''''            CurTime! = CurTime! + 86400!
		//''''        End If
		//''''        If CurTime! >= EndTime! Then
		//''''            MWSetError MW_ER_TIMEOUT
		//''''            WaitForA$ = Work$
		//''''            Exit Do
		//''''        End If
		//''''
		//''''        '-- Most important
		//''''        DoEvents
		//''''
		//''''    Loop
		//''''
		//''''    '-- Reset InputLen
		//''''    If OldLen Then
		//''''        CORTRAMO!Comm1.InputLen = OldLen
		//''''    End If
		//''''
		//''''WFAExit:
		//''''
		//''''    '-- Reset AutoProcess and RThreshold
		//''''    If AutoP Then
		//''''        CORTRAMO!Comm1.AutoProcess = AutoP
		//''''    End If
		//''''    If RT Then
		//''''        CORTRAMO!Comm1.RThreshold = RT
		//''''    End If
		//''''
		//''''    MW_CurRoutine = MW_PROC_NONE
		//''''
		//''''End Function
		
		
		//Returns False if there was an error, and True if settings are OK.
		static public int CondenseSettings(ref  string Settings,  string Baud, ref  string Parity,  string DataBits,  string StopBits)
		{
			
			//Check the baud rate.
			switch(Baud)
			{
				case "110" : case "300" : case "600" : case "1200" : case "2400" : case "4800" : case "9600" : case "14400" : case "19200" : case "28800" : case "38400" : case "57600" : case "115200" : case "230400" : 
					//It's OK. 
					break;
				default:
					goto InvalidSettings; 
					break;
			}
			
			//Check the parity.
			Parity = Parity.ToUpper();
			switch(Parity)
			{
				case "E" : case "O" : case "N" : case "S" : case "M" : 
					//It's OK. 
					break;
				default:
					goto InvalidSettings; 
					break;
			}
			
			//Check the data bits.
			switch(DataBits)
			{
				case "4" : case "5" : case "6" : case "7" : case "8" : 
					//It's OK. 
					break;
				default:
					goto InvalidSettings; 
					break;
			}
			
			//Check the stop bits.
			switch(StopBits)
			{
				case "1" : case "1.5" : case "2" : 
					//It's OK. 
					break;
				default:
					goto InvalidSettings; 
					break;
			}
			
			//If we got here, then all the settings are OK. Condense them into one string.
			Settings = Baud + "," + Parity + "," + DataBits + "," + StopBits;
			return -1;
			
InvalidSettings: 
			return 0;
			
		}
		
		
		static public string AddCaret( string ConvertString)
		{
			
			int CharVal = 0;
			string Char_Renamed = String.Empty;
			StringBuilder Temp = new StringBuilder();
			Temp.Append(String.Empty);
			
			//-- This function translates caret codes into ascii characters
			
			for (int I = 1; I <= ConvertString.Length; I++)
			{
				Char_Renamed = Strings.Mid(ConvertString, I, 1);
				CharVal = (int) Char_Renamed.ToUpper()[0];
				if (CharVal < 32 && CharVal > 0)
				{
					Temp.Append("^" + Strings.Chr(CharVal + 64).ToString());
				} else
				{
					Temp.Append(Char_Renamed);
				}
			}
			
			return Temp.ToString();
			
		}
		
		static public string GetConfigFileName()
		{
			//-- This routine returns your app's INI File name
			
			
			string AppName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			int Period = (AppName.IndexOf('.') + 1);
			if (Period != 0)
			{
				AppName = AppName.Substring(0, Math.Min(AppName.Length, Period - 1));
			}
			
			return AppName + ".INI";
			
		}
		//''''
		//''''
		//''''Function ZTrim$(St$)
		//'''''-- Trims trailing null bytes, tabs, carriage returns, and line feeds from a string,
		//'''''   as well as trailing and leading spaces. Also converts embedded nulls to spaces.
		//''''
		//''''Dim L As Integer, i As Integer
		//''''Dim Z$, T$, CR$, LF$, S$, Tilde$
		//''''
		//''''    Z$ = Chr$(0)
		//''''    T$ = Chr$(9)
		//''''    CR$ = Chr$(13)
		//''''    LF$ = Chr$(10)
		//''''    S$ = Chr$(32)
		//''''    Tilde$ = "~"
		//''''
		//''''    L = Len(St$)
		//''''
		//''''    For i = 1 To L
		//''''        Select Case Right$(St$, 1)
		//''''            Case Z$, T$, CR$, LF$, S$
		//''''                If L > 1 Then
		//''''                    St$ = Left$(St$, L - 1)
		//''''                    L = L - 1
		//''''                Else
		//''''                    St$ = ""
		//''''                End If
		//''''            Case Else
		//''''                Exit For
		//''''        End Select
		//''''    Next
		//''''
		//''''    '-- Replace imbedded Chr$(0)s
		//''''    L = Len(St$)
		//''''    For i = 1 To L
		//''''        If Mid$(St$, i, 1) = Z$ Then
		//''''            Mid$(St$, i, 1) = S$
		//''''        End If
		//''''    Next
		//''''
		//''''    '-- Replace Tildes
		//''''    L = Len(St$)
		//''''    For i = 1 To L
		//''''        If Mid$(St$, i, 1) = Tilde$ Then
		//''''            Mid$(St$, i, 1) = S$
		//''''        End If
		//''''    Next
		//''''
		//''''    ZTrim$ = Trim$(St$)
		//''''
		//''''End Function
		//'''''''''Function GetModemIndex(Comm1 As Control)
		//'''''''''
		//'''''''''Dim NumModems As Integer, i As Integer
		//'''''''''Dim T$
		//'''''''''
		//'''''''''    On Error Resume Next
		//'''''''''    NumModems = UBound(MW_CurModemIndex)
		//'''''''''    If NumModems Then
		//'''''''''        T$ = CORTRAMO!Comm1.Tag
		//'''''''''        For i = 1 To NumModems
		//'''''''''            If T$ = MW_CurModemIndex(i) Then
		//'''''''''                GetModemIndex = i
		//'''''''''                Exit Function
		//'''''''''            End If
		//'''''''''        Next
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- This control is not registered in the MWCurModemIndex array.
		//'''''''''    '   So add it.
		//'''''''''    NumModems = NumModems + 1
		//'''''''''    ReDim Preserve MW_CurModemIndex(1 To NumModems) As String
		//'''''''''    ReDim Preserve MW_CurModem(1 To NumModems) As MW_ModemInfoType
		//'''''''''    MW_CurModemIndex(NumModems) = CORTRAMO!Comm1.Tag
		//'''''''''    GetModemIndex = NumModems
		//'''''''''
		//'''''''''End Function
		//'''''''''
		//'''''''''
		//'''''''''Sub Hangup(Comm1 As Control, Attempts%, UseDTR%)
		//''''''''''-- Hangs up (disconnects) the modem.
		//'''''''''Dim Test%, AutoP%, RT%, i%, CDFlag%, ExcludeFlag%, NoGood%
		//'''''''''Dim ModemNum%, Result%
		//'''''''''Dim Received$, HangUpCmd$
		//'''''''''
		//'''''''''    On Error Resume Next
		//'''''''''    Test = CORTRAMO!Comm1.CommPort
		//'''''''''    If Err Then
		//'''''''''        '-- Port can not be accessed
		//'''''''''        MWSetError MW_ER_CTRLERROR
		//'''''''''        Exit Sub
		//'''''''''    Else
		//'''''''''        If CORTRAMO!Comm1.PortOpen = False Then
		//'''''''''            '-- Port it closed
		//'''''''''            MWSetError MW_ER_PORTCLOSED
		//'''''''''            Exit Sub
		//'''''''''        End If
		//'''''''''        If CORTRAMO!Comm1.CDHolding = False Then
		//'''''''''            MWSetError MW_HANGUP_OFFLINE
		//'''''''''            Exit Sub
		//'''''''''        End If
		//'''''''''    End If
		//'''''''''    On Error GoTo 0
		//'''''''''
		//'''''''''    '-- InitModemWare initializes MW_CR$, MW_LF$, etc.
		//'''''''''    Call InitModemWare
		//'''''''''
		//'''''''''    '-- Initialize return variables
		//'''''''''    MWSetError 0
		//'''''''''
		//'''''''''    '-- Tell everybody where we are
		//'''''''''    If Not MW_CurRoutine Then
		//'''''''''        MW_CurRoutine = MW_PROC_HANGUP
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Turn Off AutoProcess & RThreshold
		//'''''''''    AutoP = CORTRAMO!Comm1.AutoProcess
		//'''''''''    If AutoP Then
		//'''''''''        CORTRAMO!Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
		//'''''''''    End If
		//'''''''''    RT = CORTRAMO!Comm1.RThreshold
		//'''''''''    If RT Then
		//'''''''''        CORTRAMO!Comm1.RThreshold = 0
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Are we recording a script?
		//'''''''''    If MW_ScriptRecording Then
		//'''''''''        AddToRecScriptData "HANGUP", ""
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Status print
		//'''''''''    MWStatus 0, "Hanging Up..."
		//'''''''''
		//'''''''''    '-- Use DTR?
		//'''''''''    If UseDTR Then
		//'''''''''        CORTRAMO!Comm1.DTREnable = False
		//'''''''''        MWPause 15
		//'''''''''        CORTRAMO!Comm1.DTREnable = True
		//'''''''''        MWPause 15
		//'''''''''        If CORTRAMO!Comm1.CDHolding Then
		//'''''''''            MWSetError MW_HANGUP_ERROR
		//'''''''''        Else
		//'''''''''            MWSetError MW_HANGUP_OK
		//'''''''''        End If
		//'''''''''        GoTo HUExit
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Was 0 passed in?
		//'''''''''    If Attempts = 0 Then Attempts = 1
		//'''''''''
		//'''''''''    For i = 1 To Attempts
		//'''''''''        '-- Send the escape sequence
		//'''''''''        CORTRAMO!Comm1.OutBufferCount = 0
		//'''''''''        MWPause 2
		//'''''''''        CORTRAMO!Comm1.Output = "+++"
		//'''''''''        MWPause 2
		//'''''''''
		//'''''''''        '-- Wait For 'OK' from the modem
		//'''''''''        CDFlag = True
		//'''''''''        ExcludeFlag = True
		//'''''''''        Received$ = WaitFor$(CORTRAMO!Comm1, "OK", 2, CDFlag, ExcludeFlag)
		//'''''''''
		//'''''''''        Select Case MWError()
		//'''''''''            Case MW_ER_TIMEOUT, MW_ER_CANCELED
		//'''''''''                GoTo HUExit
		//'''''''''            Case MW_ER_LOST_CARRIER
		//'''''''''                MWSetError MW_HANGUP_OK
		//'''''''''                GoTo HUExit
		//'''''''''            Case MW_WAITFOR_OK
		//'''''''''                Exit For
		//'''''''''            Case Else
		//'''''''''                If i = Attempts Then
		//'''''''''                    NoGood = True
		//'''''''''                End If
		//'''''''''        End Select
		//'''''''''    Next
		//'''''''''
		//'''''''''    If NoGood Then
		//'''''''''        MWSetError MW_HANGUP_ERROR
		//'''''''''        GoTo HUExit
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Get the current modem index
		//'''''''''    ModemNum = GetModemIndex(CORTRAMO!Comm1)
		//'''''''''    If ModemNum = 0 Then
		//'''''''''        MsgBox "HANGUP: " & MWErrorMsg$()
		//'''''''''        Exit Sub
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Send the Hangup command and return the result code
		//'''''''''    HangUpCmd$ = RemoveCaret$(ZTrim$(MW_CurModem(ModemNum).Hangup))
		//'''''''''
		//'''''''''    Call SendModemCmd(CORTRAMO!Comm1, HangUpCmd$, Attempts, 5, Result)
		//'''''''''
		//'''''''''    '-- Check Result Code
		//'''''''''    If Result <> MW_RESULT_OK Then
		//'''''''''        MWSetError MW_HANGUP_ERROR
		//'''''''''    Else
		//'''''''''        MWSetError MW_HANGUP_OK
		//'''''''''    End If
		//'''''''''
		//'''''''''HUExit:
		//'''''''''
		//'''''''''    '-- Reset AutoProcess and RThreshold
		//'''''''''    If AutoP Then
		//'''''''''        CORTRAMO!Comm1.AutoProcess = AutoP
		//'''''''''    End If
		//'''''''''    If RT Then
		//'''''''''        CORTRAMO!Comm1.RThreshold = RT
		//'''''''''    End If
		//'''''''''
		//'''''''''    MW_CurRoutine = MW_PROC_NONE
		//'''''''''
		//'''''''''End Sub
		//'''''''''
		//'''''''''Sub MWEnd(Comm1 As Control)
		//''''''''''-- Safely closes the port.
		//'''''''''
		//'''''''''Dim OutBufferCount As Integer, Tries As Integer
		//'''''''''
		//''''''''''   You should call this routine in your main Form_Unload event.
		//''''''''''   To end your program, unload your main form. ex: Unload Form1
		//'''''''''
		//'''''''''    '-- Tell everyone where we are.
		//'''''''''    If Not MW_CurRoutine Then
		//'''''''''        MW_CurRoutine = MW_PROC_END
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Cancel the current operation
		//'''''''''    MW_CancelFlag = True
		//'''''''''    MWPause 0.5
		//'''''''''
		//'''''''''    '-- This routine makes sure your modem is disconnected and your comm port is closed.
		//'''''''''    If CORTRAMO!Comm1.PortOpen Then
		//'''''''''        Do
		//'''''''''            OutBufferCount = CORTRAMO!Comm1.OutBufferCount
		//'''''''''            DoEvents
		//'''''''''            If OutBufferCount = CORTRAMO!Comm1.OutBufferCount Then
		//'''''''''                Tries = Tries + 1
		//'''''''''            Else
		//'''''''''                Tries = 0
		//'''''''''            End If
		//'''''''''        Loop Until OutBufferCount = 0 Or Tries > 9
		//'''''''''        Hangup CORTRAMO!Comm1, 1, False  '-- Don't Use DTR
		//'''''''''        If MWError() = MW_HANGUP_ERROR Then
		//'''''''''            Hangup CORTRAMO!Comm1, 1, True   '-- Use DTR
		//'''''''''        End If
		//'''''''''    End If
		//'''''''''
		//'''''''''    MW_CurRoutine = MW_PROC_NONE
		//'''''''''
		//'''''''''    '-- Are we recording a script?
		//'''''''''    If MW_ScriptRecording Then
		//'''''''''        AddToRecScriptData "END", ""
		//'''''''''        Call ScriptRecord(CORTRAMO!Comm1, "", 10)
		//'''''''''    End If
		//'''''''''
		//'''''''''End Sub
		//'''''''''
		//'''''''''
		//'''''''''Function OpenModemPort(Comm1 As Control, PortNum, BaudRate&, Settings$)
		//'''''''''
		//'''''''''Dim First As Integer, i As Integer, Port As Integer, Result As Integer, OMP As Integer
		//'''''''''
		//''''''''''-- This routine opens the first available comm port with a modem attached.
		//'''''''''
		//'''''''''    '-- Tell everybody where we are
		//'''''''''    If Not MW_CurRoutine Then
		//'''''''''        MW_CurRoutine = MW_PROC_OPENMODEMPORT
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Was PortNum not specified?
		//'''''''''    If PortNum = 0 Then
		//'''''''''        First = 1
		//'''''''''    Else
		//'''''''''        First = PortNum
		//'''''''''    End If
		//'''''''''
		//'''''''''    On Error Resume Next
		//'''''''''    OMP = 0
		//'''''''''    For i = First To 9
		//'''''''''        Port = OpenPort(CORTRAMO!Comm1, i, BaudRate&, Settings$)
		//'''''''''        Select Case MWError()
		//'''''''''            Case MW_OPENPORT_SETTINGS, MW_ER_CANCELED, MW_OPENPORT_ERROR
		//'''''''''                GoTo OMPExit
		//'''''''''            Case MW_OPENPORT_OK
		//'''''''''                SendModemCmd CORTRAMO!Comm1, "AT", 1, 2, Result
		//'''''''''                If Result = MW_RESULT_OK Then
		//'''''''''                    OMP = Port
		//'''''''''                    MWSetError MW_OPENPORT_OK
		//'''''''''                    Exit For
		//'''''''''                Else
		//'''''''''                    CORTRAMO!Comm1.PortOpen = False
		//'''''''''                End If
		//'''''''''        End Select
		//'''''''''
		//'''''''''    Next
		//'''''''''    If OMP = 0 Then
		//'''''''''        MWSetError MW_OPENPORT_ERROR
		//'''''''''    End If
		//'''''''''    OpenModemPort = OMP
		//'''''''''
		//'''''''''OMPExit:
		//'''''''''    MW_CurRoutine = MW_PROC_NONE
		//'''''''''    On Error GoTo 0
		//'''''''''
		//'''''''''End Function
		//'''''''''
		//'''''''''
		//'''''''''Sub PlaceCall(Comm1 As Control, PhoneNum$, Attempts%, TimeOut%, Result%, ModemBaud&, RealBaud&, Mode$)
		//''''''''''-- Dials a phone number and returns the result.
		//'''''''''Dim Test%, AutoP%, RT%, ModemNum%, i%, CDFlag%, ExcludeFlag%
		//'''''''''Dim CARRIER_Pos%, CrPos%, CONNECT_Pos%, L%, LenBaud%, AscVal%
		//'''''''''Dim S$, DialCmd$, Connect$, Temp$, DialStr$, Received$
		//'''''''''Dim BaudStr$
		//'''''''''
		//'''''''''    '-- Test Comm port validity
		//'''''''''    On Error Resume Next
		//'''''''''
		//'''''''''    Test = CORTRAMO!Comm1.CommPort
		//'''''''''    If Err Then
		//'''''''''        '-- Port can not be accessed
		//'''''''''        MWSetError MW_ER_CTRLERROR
		//'''''''''        Exit Sub
		//'''''''''    Else
		//'''''''''        If CORTRAMO!Comm1.PortOpen = False Then
		//'''''''''            '-- Port it closed
		//'''''''''            MWSetError MW_ER_PORTCLOSED
		//'''''''''            Exit Sub
		//'''''''''        End If
		//'''''''''    End If
		//'''''''''    On Error GoTo 0
		//'''''''''
		//'''''''''    '-- Initialize MW_CancelFlag
		//'''''''''    MW_CancelFlag = False
		//'''''''''
		//'''''''''    '-- Tell everybody where we are
		//'''''''''    If Not MW_CurRoutine Then
		//'''''''''        MW_CurRoutine = MW_PROC_PLACECALL
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Turn Off AutoProcess & RThreshold
		//'''''''''    CORTRAMO!Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
		//'''''''''    'AutoP = CORTRAMO!Comm1.AutoProcess
		//'''''''''    'If AutoP <> 0 Then
		//'''''''''    '    CORTRAMO!Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
		//'''''''''    'End If
		//'''''''''    RT = CORTRAMO!Comm1.RThreshold
		//'''''''''    If RT Then
		//'''''''''        CORTRAMO!Comm1.RThreshold = 0
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Are we recording a script?
		//'''''''''    If MW_ScriptRecording Then
		//'''''''''        S$ = CORTRAMO!Comm1.Settings
		//'''''''''        AddToRecScriptData "SETTINGS", UCase$(S$)
		//'''''''''        DialCmd$ = Trim$(PhoneNum$)
		//'''''''''        If Attempts Then
		//'''''''''            DialCmd$ = DialCmd$ & "," & Str$(Attempts)
		//'''''''''        End If
		//'''''''''        AddToRecScriptData "DIAL", DialCmd$
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Initialize Variables
		//'''''''''    ModemBaud& = 0
		//'''''''''    RealBaud& = 0
		//'''''''''    Mode$ = ""
		//'''''''''    Result = 0
		//'''''''''    MWSetError 0
		//'''''''''
		//'''''''''    '-- Get the current modem index
		//'''''''''    ModemNum = GetModemIndex(CORTRAMO!Comm1)
		//'''''''''    If ModemNum = 0 Then
		//'''''''''        MsgBox "PLACECALL: " & MWErrorMsg$()
		//'''''''''        Exit Sub
		//'''''''''    End If
		//'''''''''
		//'''''''''    Connect$ = ZTrim$(MW_CurModem(ModemNum).Connect)
		//'''''''''    If Len(Connect$) = 0 Then
		//'''''''''        Connect$ = "CONNECT"
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Create the dial string
		//'''''''''    Temp$ = ZTrim$(MW_CurModem(ModemNum).Dial)
		//'''''''''    If Len(Temp$) Then
		//'''''''''        DialStr$ = Temp$ & Trim$(PhoneNum$) & MW_CR$
		//'''''''''    Else
		//'''''''''        DialStr$ = "ATDT" & Trim$(PhoneNum$) & MW_CR$
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Status print
		//'''''''''    MWStatus 0, "Dialing..."
		//'''''''''
		//'''''''''    For i = 1 To Attempts
		//'''''''''
		//'''''''''        '-- Flush the receive buffer and send the AT command
		//'''''''''        CORTRAMO!Comm1.InBufferCount = 0
		//'''''''''        CORTRAMO!Comm1.Output = DialStr$
		//'''''''''
		//'''''''''        Do
		//'''''''''
		//'''''''''        '-- Wait for the modem to connect.
		//'''''''''        CDFlag = False
		//'''''''''        ExcludeFlag = True
		//'''''''''
		//'''''''''        '-- Wait for a carriage return/linefeed
		//'''''''''        Received$ = WaitFor$(CORTRAMO!Comm1, MW_CRLF$, TimeOut, CDFlag, ExcludeFlag)
		//'''''''''
		//''''''''''        If lAcceso = 1 Then
		//''''''''''          Exit Sub
		//''''''''''        End If
		//'''''''''
		//'''''''''        Select Case MWError()
		//'''''''''            Case MW_ER_CANCELED    '-- Are we Canceled?
		//'''''''''                '-- Send a character to abort the call
		//'''''''''                CORTRAMO!Comm1.Output = " "
		//'''''''''                Exit For
		//'''''''''            Case MW_ER_TIMEOUT     '-- Did we get something else?
		//'''''''''                '-- Send a character to abort the call
		//'''''''''
		//'''''''''                If CORTRAMO!Comm1.PortOpen = False Then
		//'''''''''                    '-- Port it closed
		//'''''''''                    MWSetError MW_ER_PORTCLOSED
		//'''''''''                    Exit Sub
		//'''''''''                'End If
		//'''''''''
		//'''''''''                CORTRAMO!Comm1.Output = " "
		//'''''''''                Do
		//'''''''''                    Received$ = WaitFor$(CORTRAMO!Comm1, MW_CRLF$, 2, CDFlag, ExcludeFlag)
		//'''''''''                    Result = MWError()
		//'''''''''                    If Result = MW_ER_TIMEOUT Then
		//'''''''''                        Result = MW_RESULT_TIMEOUT
		//'''''''''                        Exit Do
		//'''''''''                    End If
		//'''''''''                    Result = Str2Result(CORTRAMO!Comm1, Received$)
		//'''''''''                Loop Until Result
		//'''''''''                End If
		//'''''''''                Exit For
		//'''''''''            Case MW_WAITFOR_OK
		//'''''''''                '-- Have we received something from the modem?
		//'''''''''                If Len(Received$) Then
		//'''''''''                    Result = Str2Result(CORTRAMO!Comm1, Received$)
		//'''''''''                    Select Case Result
		//'''''''''                        Case MW_RESULT_CARRIER
		//'''''''''                            CARRIER_Pos = InStr(Received$, "CARRIER")
		//'''''''''                            If CARRIER_Pos Then
		//'''''''''                                BaudStr$ = Mid$(Received$, CARRIER_Pos + 8)
		//'''''''''                                CrPos = InStr(BaudStr$, MW_CR$)
		//'''''''''                                If CrPos Then
		//'''''''''                                    RealBaud& = Val(Left$(BaudStr$, CrPos - 1))
		//'''''''''                                Else
		//'''''''''                                    RealBaud& = Val(BaudStr$)
		//'''''''''                                End If
		//'''''''''                            End If
		//'''''''''                        Case MW_RESULT_CONNECT
		//'''''''''                            CONNECT_Pos = InStr(Received$, Connect$)
		//'''''''''                            If Len(Received$) < 8 Then
		//'''''''''                                ModemBaud& = 300
		//'''''''''                            Else
		//'''''''''                                BaudStr$ = Mid$(Received$, CONNECT_Pos + 8)
		//'''''''''                                '-- Find position of first non-numeric character
		//'''''''''                                L = Len(BaudStr$)
		//'''''''''                                For LenBaud = 1 To L
		//'''''''''                                    AscVal = Asc(Mid$(BaudStr$, LenBaud, 1))
		//'''''''''                                    If AscVal < 48 Or AscVal > 57 Then
		//'''''''''                                        Exit For
		//'''''''''                                    End If
		//'''''''''                                Next
		//'''''''''                                '-- Get ModemBaud&
		//'''''''''                                If LenBaud > L Then
		//'''''''''                                    ModemBaud& = Val(BaudStr$)
		//'''''''''                                Else
		//'''''''''                                    ModemBaud& = Val(Left$(BaudStr$, LenBaud))
		//'''''''''                                    '-- Get the rest as Mode$
		//'''''''''                                    Mode$ = Mid$(BaudStr$, LenBaud + 1)
		//'''''''''                                End If
		//'''''''''                            End If
		//'''''''''                            If CARRIER_Pos Then
		//'''''''''                                If RealBaud& = 0 Then
		//'''''''''                                    RealBaud& = ModemBaud&
		//'''''''''                                End If
		//'''''''''                            End If
		//'''''''''                            MWSetError MW_PLACECALL_OK
		//'''''''''                            '-- If 2400 baud, you have to pause for a few
		//'''''''''                            '   seconds to let the modem handshaking complete.
		//'''''''''                            If ModemBaud& <= 2400 Then
		//'''''''''                                MWPause 8
		//'''''''''                            End If
		//'''''''''                            GoTo PCExit:
		//'''''''''                        Case MW_RESULT_RING
		//'''''''''                            '-- Just a phone ring, keep waiting
		//'''''''''                        Case MW_RESULT_BUSY
		//'''''''''                            '-- Busy, Redial
		//'''''''''                            MWSetError MW_PLACECALL_OK
		//'''''''''                            Exit Do
		//'''''''''                        Case MW_RESULT_NO_CARRIER, MW_RESULT_TIMEOUT, MW_RESULT_NO_ANSWER, MW_RESULT_ERROR, MW_RESULT_NO_DIALTONE
		//'''''''''                            MWSetError MW_PLACECALL_OK
		//'''''''''                            Exit For
		//'''''''''                        Case 0
		//'''''''''                            '-- No Known Result Code.. Continue waiting
		//'''''''''                        Case Else
		//'''''''''                            '-- Valid result code, not CONNECT, Continue waiting
		//'''''''''                    End Select
		//'''''''''                End If
		//'''''''''        End Select
		//'''''''''
		//'''''''''        DoEvents
		//'''''''''        Loop
		//'''''''''
		//'''''''''    DoEvents
		//'''''''''    Next
		//'''''''''
		//'''''''''PCExit:
		//'''''''''
		//'''''''''    '-- Reset AutoProcess and RThreshold
		//'''''''''    'If AutoP Then
		//'''''''''    '    CORTRAMO!Comm1.AutoProcess = AutoP
		//'''''''''    'End If
		//'''''''''    If RT Then
		//'''''''''        CORTRAMO!Comm1.RThreshold = RT
		//'''''''''    End If
		//'''''''''
		//'''''''''    MW_CurRoutine = MW_PROC_NONE
		//'''''''''End Sub
		//'''''''''
		//'''''''''
		//'''''''''
		//'''''''''Sub SendModemCmd(Comm1 As Control, Cmd$, Attempts%, TimeOut%, Result%)
		//''''''''''-- Sends a command to your modem. You can use this to send your own
		//''''''''''   initialization strings or setup strings to your modem. Returns
		//''''''''''   the result code.
		//'''''''''
		//'''''''''Dim Test As Integer, AutoP As Integer, RT As Integer, Index As Integer, OldRoutine As Integer
		//'''''''''Dim i As Integer, CDFlag As Integer, ExcludeFlag As Integer, Found As Integer
		//'''''''''Dim Attention$, ResultStr$
		//'''''''''
		//'''''''''    '-- Test Comm port validity
		//'''''''''    On Error Resume Next
		//'''''''''    Test = CORTRAMO!Comm1.CommPort
		//'''''''''    If Err Then
		//'''''''''        '-- Port can not be accessed
		//'''''''''        MWSetError MW_ER_CTRLERROR
		//'''''''''        Exit Sub
		//'''''''''    Else
		//'''''''''        If CORTRAMO!Comm1.PortOpen = False Then
		//'''''''''            '-- Port it closed
		//'''''''''            MWSetError MW_ER_PORTCLOSED
		//'''''''''            Exit Sub
		//'''''''''        End If
		//'''''''''    End If
		//'''''''''    On Error GoTo 0
		//'''''''''
		//'''''''''    '-- InitModemWare initializes MW_CR$, MW_LF$, etc.
		//'''''''''    If MW_Init = 0 Then Call InitModemWare
		//'''''''''
		//'''''''''    '-- Tell everybody where we are
		//'''''''''    OldRoutine = MW_CurRoutine
		//'''''''''    MW_CurRoutine = MW_PROC_SENDMODEMCMD
		//'''''''''
		//'''''''''    '-- Initialize MW_CancelFlag
		//'''''''''    MW_CancelFlag = False
		//'''''''''
		//'''''''''    '-- Initialize variables
		//'''''''''    Result = 0
		//'''''''''    MWSetError 0
		//'''''''''
		//'''''''''    '-- Turn Off AutoProcess & RThreshold
		//'''''''''    AutoP = CORTRAMO!Comm1.AutoProcess
		//'''''''''    If AutoP Then
		//'''''''''        CORTRAMO!Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
		//'''''''''    End If
		//'''''''''    RT = CORTRAMO!Comm1.RThreshold
		//'''''''''    If RT Then
		//'''''''''        CORTRAMO!Comm1.RThreshold = 0
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Create an array for WaitForA$
		//'''''''''    ReDim WaitArray$(1 To 2)
		//'''''''''    WaitArray$(1) = MW_CRLF$
		//'''''''''    WaitArray$(2) = MW_CR$
		//'''''''''
		//'''''''''    '-- Get the current modem index
		//'''''''''    Index = GetModemIndex(CORTRAMO!Comm1)
		//'''''''''    If Index = 0 Then
		//'''''''''        MsgBox "SENDMODEMCMD: " & MWErrorMsg$()
		//'''''''''        Exit Sub
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Make sure that the command is semi-valid
		//'''''''''    If Len(Cmd$) = 0 Then
		//'''''''''        MWSetError MW_SENDMODEMCMD_NOCMD
		//'''''''''        GoTo SMCExit
		//'''''''''    Else
		//'''''''''        Attention$ = RemoveCaret$(ZTrim$(MW_CurModem(Index).Attention))
		//'''''''''        '-- Starts with attention string?
		//'''''''''        If UCase$(Left$(Cmd$, 2)) <> Attention$ Then
		//'''''''''            Cmd$ = Attention$ & Cmd$
		//'''''''''        End If
		//'''''''''        '-- Ends in CR?
		//'''''''''        If Right$(Cmd$, 1) <> MW_CR$ Then
		//'''''''''            Cmd$ = Cmd$ & MW_CR$
		//'''''''''        End If
		//'''''''''        '-- Starts with a quote?
		//'''''''''        If Left$(Cmd$, 1) = Chr$(34) Then
		//'''''''''            Cmd$ = Mid$(Cmd$, 2)
		//'''''''''        End If
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Are we recording a script?
		//'''''''''    If MW_ScriptRecording Then
		//'''''''''        AddToRecScriptData "SEND", Cmd$
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Flush the receive buffer
		//'''''''''    CORTRAMO!Comm1.InBufferCount = 0
		//'''''''''
		//'''''''''    If Attempts = 0 Then Attempts = 1
		//'''''''''
		//'''''''''    MW_LeftOver$ = ""
		//'''''''''    For i = 1 To Attempts
		//'''''''''        '-- Send the command
		//'''''''''        CORTRAMO!Comm1.Output = Cmd$
		//'''''''''        '-- Wait for the result code
		//'''''''''        Do
		//'''''''''            If Len(MW_LeftOver$) Then
		//'''''''''                If Asc(MW_LeftOver$) = 10 Then MW_LeftOver$ = Mid$(MW_LeftOver$, 2)
		//'''''''''            End If
		//'''''''''            CDFlag = False
		//'''''''''            ExcludeFlag = False
		//'''''''''            ResultStr$ = WaitForA$(CORTRAMO!Comm1, WaitArray$(), TimeOut, CDFlag, ExcludeFlag, Found)
		//'''''''''            Select Case MWError()
		//'''''''''                Case MW_ER_TIMEOUT, MW_ER_CANCELED
		//'''''''''                    GoTo SMCExit
		//'''''''''                Case MW_WAITFOR_OK
		//'''''''''                    If Len(ResultStr$) Then
		//'''''''''                        '-- Get the result code
		//'''''''''                        Result = Str2Result(CORTRAMO!Comm1, ResultStr$)
		//'''''''''                        If Result Then
		//'''''''''                            '-- Got a legitimate result
		//'''''''''
		//'''''''''                            Exit For
		//'''''''''                        End If
		//'''''''''                    End If
		//'''''''''            End Select
		//'''''''''        Loop
		//'''''''''        '-- Pause 1 second
		//'''''''''        MWPause 1
		//'''''''''    Next
		//'''''''''
		//'''''''''    '-- Return OK
		//'''''''''    MWSetError MW_SENDMODEMCMD_OK
		//'''''''''
		//'''''''''SMCExit:
		//'''''''''
		//'''''''''    '-- Reset AutoProcess and RThreshold
		//'''''''''    If AutoP Then
		//'''''''''        CORTRAMO!Comm1.AutoProcess = AutoP
		//'''''''''    End If
		//'''''''''    If RT Then
		//'''''''''        CORTRAMO!Comm1.RThreshold = RT
		//'''''''''    End If
		//'''''''''
		//'''''''''    MW_CurRoutine = OldRoutine
		//'''''''''
		//'''''''''End Sub
		//'''''''''
		//'''''''''Sub SetModemSettings(Comm1 As Control)
		//''''''''''-- Lets the user set up their comm ports for ModemWare applications.
		//'''''''''
		//'''''''''Dim PortWasOpen As Integer, AutoP As Integer, Dummy As Integer
		//'''''''''Dim T$, OldSetting$
		//'''''''''
		//'''''''''    '-- Make sure the port is closed
		//'''''''''    If CORTRAMO!Comm1.PortOpen Then
		//'''''''''        PortWasOpen = True
		//'''''''''        OldSetting$ = CORTRAMO!Comm1.Settings
		//'''''''''        CORTRAMO!Comm1.PortOpen = False
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- MW_Global_CORTRAMO!Comm1 is a global object that can be accessed by
		//'''''''''    '   the Modem setup forms.
		//'''''''''    Set MW_Global_Comm1 = CORTRAMO!Comm1
		//'''''''''
		//'''''''''    '-- Tell everybody where we are
		//'''''''''    If Not MW_CurRoutine Then MW_CurRoutine = MW_PROC_SETMODEMSETTINGS
		//'''''''''
		//'''''''''    '-- Set The Caption
		//''''''''''    MWModem.Caption = CORTRAMO!Comm1.Tag & " Modem Settings"
		//'''''''''
		//'''''''''    '-- Show the modem configuration window
		//''''''''''    MWModem.Show 1
		//'''''''''
		//'''''''''    '-- Was the cancel button pressed?
		//''''''''''    T$ = MWModem.Tag
		//'''''''''    If Len(T$) = 0 Then
		//'''''''''        '-- Turn On AutoProcess
		//'''''''''        If AutoP Then CORTRAMO!Comm1.AutoProcess = AutoP
		//'''''''''        If PortWasOpen Then CORTRAMO!Comm1.PortOpen = True
		//'''''''''        Exit Sub
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Re-open the port if it was opened.
		//'''''''''    If PortWasOpen Then
		//'''''''''        CORTRAMO!Comm1.Settings = OldSetting$
		//'''''''''        CORTRAMO!Comm1.PortOpen = True
		//'''''''''        PortWasOpen = GetModemIndex(CORTRAMO!Comm1)
		//'''''''''        'The next line of code previously used PortWasOpen where Dummy is now. This worked in VB3,
		//'''''''''        'but VB4 stops with "Subscript out of range" because PortWasOpen comes back as -1000.
		//'''''''''        Call SendModemCmd(CORTRAMO!Comm1, MW_CurModem(PortWasOpen).Attention, 1, 1, Dummy)
		//'''''''''    End If
		//'''''''''
		//'''''''''End Sub
		//''''
		//''''Function Str2Result(Comm1 As Control, ResultStr$)
		//'''''-- Internal: This function converts a result code string to
		//'''''   it's code number
		//''''
		//''''Dim ModemNum As Integer, A As Integer, B As Integer, C As Integer, D As Integer
		//''''Dim E As Integer, F As Integer, G As Integer, H As Integer, i As Integer, J As Integer
		//''''Dim Busy$, Connect$
		//''''
		//''''    '-- Get the current modem index
		//''''    ModemNum = GetModemIndex(CORTRAMO!Comm1)
		//''''    If ModemNum = 0 Then
		//''''        MsgBox "STR2RESULT: " & MWErrorMsg$()
		//''''        Exit Function
		//''''    End If
		//''''
		//''''    Busy$ = ZTrim$(MW_CurModem(ModemNum).Busy)
		//''''    If Len(Busy$) = 0 Then
		//''''        Busy$ = "BUSY"
		//''''    End If
		//''''
		//''''    Connect$ = ZTrim$(MW_CurModem(ModemNum).Connect)
		//''''    If Len(Connect$) = 0 Then
		//''''        Connect$ = "CONNECT"
		//''''    End If
		//''''
		//''''    A = InStr(ResultStr$, "OK")
		//''''    B = InStr(ResultStr$, Connect$)
		//''''    C = InStr(ResultStr$, "RING")
		//''''    D = InStr(ResultStr$, "NO CARRIER")
		//''''    E = InStr(ResultStr$, "ERROR")
		//''''    F = InStr(ResultStr$, "NO DIALTONE")
		//''''    G = InStr(ResultStr$, Busy$)
		//''''    H = InStr(ResultStr$, "NO ANSWER")
		//''''    i = InStr(ResultStr$, "TIMEOUT")
		//''''    J = InStr(ResultStr$, "CARRIER")
		//''''
		//''''    If A Then
		//''''        Str2Result = MW_RESULT_OK
		//''''    ElseIf B Then
		//''''        Str2Result = MW_RESULT_CONNECT
		//''''    ElseIf C Then
		//''''        Str2Result = MW_RESULT_RING
		//''''    ElseIf D Then
		//''''        Str2Result = MW_RESULT_NO_CARRIER
		//''''    ElseIf E Then
		//''''        Str2Result = MW_RESULT_ERROR
		//''''    ElseIf F Then
		//''''        Str2Result = MW_RESULT_NO_DIALTONE
		//''''    ElseIf G Then
		//''''        Str2Result = MW_RESULT_BUSY
		//''''    ElseIf H Then
		//''''        Str2Result = MW_RESULT_NO_ANSWER
		//''''    ElseIf i Then
		//''''        Str2Result = MW_RESULT_TIMEOUT
		//''''    ElseIf J Then
		//''''        Str2Result = MW_RESULT_CARRIER
		//''''    End If
		//''''
		//''''End Function
		//'''''''''
		//'''''''''Sub WaitForCall(Comm1 As Control, NumRings, ModemBaud&, RealBaud&, Mode$)
		//''''''''''-- Waits for a call and connects the modem. This is host mode made easy.
		//''''''''''   Just call this routine, and it will return when a caller has connected.
		//'''''''''Dim Test%, ModemNum%, AutoP%, RT%, TimeOut%, NumTries%, Result%, CDFlag%
		//'''''''''Dim ExcludeFlag%, CARRIER_Pos%, CONNECT_Pos%, L%, LenBaud%, AscVal%
		//'''''''''Dim Connect$, Attention$, InitString$, Received$, BaudStr$
		//'''''''''
		//'''''''''    '-- Test Comm port validity
		//'''''''''    On Error Resume Next
		//'''''''''    Test = CORTRAMO!Comm1.CommPort
		//'''''''''    If Err Then
		//'''''''''        '-- Port can not be accessed
		//'''''''''        MWSetError MW_ER_CTRLERROR
		//'''''''''        Exit Sub
		//'''''''''    Else
		//'''''''''        If CORTRAMO!Comm1.PortOpen = False Then
		//'''''''''            '-- Port it closed
		//'''''''''            MWSetError MW_ER_PORTCLOSED
		//'''''''''            Exit Sub
		//'''''''''        End If
		//'''''''''    End If
		//'''''''''    On Error GoTo 0
		//'''''''''
		//'''''''''    '-- InitModemWare initializes MW_CR$, MW_LF$, etc.
		//'''''''''    Call InitModemWare
		//'''''''''
		//'''''''''    '-- Initialize MW_CancelFlag
		//'''''''''    MW_CancelFlag = False
		//'''''''''
		//'''''''''    '-- Tell everybody where we are
		//'''''''''    If Not MW_CurRoutine Then
		//'''''''''        MW_CurRoutine = MW_PROC_WAITFORCALL
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Initialize and validate variables
		//'''''''''    ModemBaud& = 0
		//'''''''''    RealBaud& = 0
		//'''''''''    Mode$ = ""
		//'''''''''    MWSetError 0
		//'''''''''    If NumRings = 0 Then
		//'''''''''        NumRings = 1
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Get the current modem index
		//'''''''''    ModemNum = GetModemIndex(CORTRAMO!Comm1)
		//'''''''''    If ModemNum = 0 Then
		//'''''''''        MsgBox "WAITFORCALL: " & MWErrorMsg$()
		//'''''''''        Exit Sub
		//'''''''''    End If
		//'''''''''
		//'''''''''    Connect$ = ZTrim$(MW_CurModem(ModemNum).Connect)
		//'''''''''    If Len(Connect$) = 0 Then
		//'''''''''        Connect$ = "CONNECT"
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Turn Off AutoProcess & RThreshold
		//'''''''''    AutoP = CORTRAMO!Comm1.AutoProcess
		//'''''''''    If AutoP Then
		//'''''''''        CORTRAMO!Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
		//'''''''''    End If
		//'''''''''    RT = CORTRAMO!Comm1.RThreshold
		//'''''''''    If RT Then
		//'''''''''        CORTRAMO!Comm1.RThreshold = 0
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Are we recording a script?
		//'''''''''    If MW_ScriptRecording Then
		//'''''''''        AddToRecScriptData "WAITFORCALL", ""
		//'''''''''    End If
		//'''''''''
		//'''''''''    '-- Initialize the modem and wait up to 5 seconds for an OK
		//'''''''''    TimeOut = 5
		//'''''''''    NumTries = 3
		//'''''''''    Attention$ = RemoveCaret$(ZTrim$(MW_CurModem(ModemNum).Attention))
		//'''''''''    InitString$ = Attention$ & "S0=" & LTrim$(Str$(NumRings)) & MW_CR$
		//'''''''''    Call SendModemCmd(CORTRAMO!Comm1, InitString$, NumTries, TimeOut, Result)
		//'''''''''
		//'''''''''    Select Case MWError()
		//'''''''''        '-- Are we Canceled or timed out?
		//'''''''''        Case MW_ER_CANCELED, MW_ER_TIMEOUT
		//'''''''''            GoTo WFCExit:
		//'''''''''    End Select
		//'''''''''
		//'''''''''    '-- Status Print
		//'''''''''    MWStatus 0, "Waiting For a Call..."
		//'''''''''
		//'''''''''    '-- Wait for the modem to connect.
		//'''''''''    Do
		//'''''''''
		//'''''''''        TimeOut = 3600
		//'''''''''        CDFlag = False
		//'''''''''        ExcludeFlag = True
		//'''''''''        Received$ = WaitFor$(CORTRAMO!Comm1, MW_CR$, TimeOut, CDFlag, ExcludeFlag)
		//'''''''''
		//'''''''''        Select Case MWError()
		//'''''''''            Case MW_ER_CANCELED    '-- Are we Canceled?
		//'''''''''                '-- Send an ATS0=0
		//'''''''''                Call SendModemCmd(CORTRAMO!Comm1, Attention$ & "S0=0", 2, 10, Result)
		//'''''''''                MWSetError MW_ER_CANCELED
		//'''''''''                GoTo WFCExit:
		//'''''''''            Case MW_WAITFOR_OK
		//'''''''''                '-- Have we received something from the modem?
		//'''''''''                If Len(Received$) Then
		//'''''''''                    Result = Str2Result(CORTRAMO!Comm1, Received$)
		//'''''''''                    Select Case Result
		//'''''''''                        Case MW_RESULT_CARRIER
		//'''''''''                            CARRIER_Pos = InStr(Received$, "CARRIER")
		//'''''''''                            If CARRIER_Pos Then
		//'''''''''                                BaudStr$ = Mid$(Received$, CARRIER_Pos + 8)
		//'''''''''                                RealBaud& = Val(BaudStr$)
		//'''''''''                            End If
		//'''''''''                        Case MW_RESULT_CONNECT
		//'''''''''                            CONNECT_Pos = InStr(Received$, Connect$)
		//'''''''''                            If Len(Received$) < 8 Then
		//'''''''''                                ModemBaud& = 300
		//'''''''''                            Else
		//'''''''''                                BaudStr$ = Mid$(Received$, CONNECT_Pos + 8)
		//'''''''''                                '-- Find position of first non-numeric character
		//'''''''''                                L = Len(BaudStr$)
		//'''''''''                                For LenBaud = 1 To L
		//'''''''''                                    AscVal = Asc(Mid$(BaudStr$, LenBaud, 1))
		//'''''''''                                    If AscVal < 48 Or AscVal > 57 Then
		//'''''''''                                        Exit For
		//'''''''''                                    End If
		//'''''''''                                Next
		//'''''''''                                '-- Get ModemBaud&
		//'''''''''                                If LenBaud > L Then
		//'''''''''                                    ModemBaud& = Val(BaudStr$)
		//'''''''''                                Else
		//'''''''''                                    ModemBaud& = Val(Left$(BaudStr$, LenBaud))
		//'''''''''                                    '-- Get the rest as Mode$
		//'''''''''                                    Mode$ = Mid$(BaudStr$, LenBaud + 1)
		//'''''''''                                End If
		//'''''''''                            End If
		//'''''''''                            If CARRIER_Pos Then
		//'''''''''                                If RealBaud& = 0 Then
		//'''''''''                                    RealBaud& = ModemBaud&
		//'''''''''                                End If
		//'''''''''                            End If
		//'''''''''                            MWSetError MW_WAITFORCALL_OK
		//'''''''''                            '-- If 2400 baud, you have to pause for a few
		//'''''''''                            '   seconds to let the modem handshaking complete.
		//'''''''''                            If ModemBaud& <= 2400 Then
		//'''''''''                                MWPause 9
		//'''''''''                            End If
		//'''''''''                            Exit Do
		//'''''''''                        Case MW_RESULT_RING
		//'''''''''                            '-- Just a phone ring, keep waiting
		//'''''''''                            MWStatus 0, "Incomming Call... Answering"
		//'''''''''                        Case MW_RESULT_BUSY
		//'''''''''                            '-- Busy.
		//'''''''''                            MWSetError MW_WAITFORCALL_OK
		//'''''''''                            Exit Do
		//'''''''''                        Case MW_RESULT_ERROR
		//'''''''''                            MWSetError MW_WAITFORCALL_OK
		//'''''''''                            Exit Do
		//'''''''''                        Case 0
		//'''''''''                            '-- No Known Result Code.. Continue waiting
		//'''''''''                        Case Else
		//'''''''''                            '-- Valid result code, not CONNECT, Continue waiting
		//'''''''''                    End Select
		//'''''''''                End If
		//'''''''''        End Select
		//'''''''''    Loop
		//'''''''''
		//'''''''''WFCExit:
		//'''''''''
		//'''''''''    '-- Reset AutoProcess and RThreshold
		//'''''''''    If AutoP Then
		//'''''''''        CORTRAMO!Comm1.AutoProcess = AutoP
		//'''''''''    End If
		//'''''''''    If RT Then
		//'''''''''        CORTRAMO!Comm1.RThreshold = RT
		//'''''''''    End If
		//'''''''''
		//'''''''''    MW_CurRoutine = MW_PROC_NONE
		//'''''''''
		//'''''''''End Sub
		//'''''''''
		//'''''''''
	}
}