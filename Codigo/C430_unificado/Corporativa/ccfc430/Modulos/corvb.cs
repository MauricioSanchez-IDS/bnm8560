using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Runtime.InteropServices; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class CORVB
	{
	
		// Clipboard formats
		public const int CF_LINK = 0xBF00;
		public const int CF_TEXT = 1;
		public const int CF_BITMAP = 2;
		public const int CF_METAFILE = 3;
		public const int CF_DIB = 8;
		public const int CF_PALETTE = 9;
		
		public const int NULL_INTEGER = 0;
		public const string NULL_STRING = "";
		
		// DragOver
		public const int ENTER = 0;
		public const int LEAVE = 1;
		public const int OVER = 2;
		
		// Drag (controls)
		public const int Cancel = 0;
		public const int BEGIN_DRAG = 1;
		public const int END_DRAG = 2;
		
		// Show parameters
		public static readonly FormShowConstants MODAL = FormShowConstants.Modal;
		public const int MODELESS = 0;
		
		// Arrange Method
		// for MDI Forms
		public const int CASCADE = 0;
		public const int TILE_HORIZONTAL = 1;
		public const int TILE_VERTICAL = 2;
		public const int ARRANGE_ICONS = 3;
		
		//ZOrder Method
		public const int BRINGTOFRONT = 0;
		public const int SENDTOBACK = 1;
		
		// Key Codes
		public const int KEY_LBUTTON = 0x1;
		public const int KEY_RBUTTON = 0x2;
		public const int KEY_CANCEL = 0x3;
		public const int KEY_MBUTTON = 0x4; // NOT contiguous with L & RBUTTON
		public const int KEY_BACK = 0x8;
		public const int KEY_TAB = 0x9;
		public const int KEY_CLEAR = 0xC;
		public const int KEY_RETURN = 0xD;
		public const int KEY_SHIFT = 0x10;
		public const int KEY_CONTROL = 0x11;
		public const int KEY_MENU = 0x12;
		public const int KEY_PAUSE = 0x13;
		public const int KEY_CAPITAL = 0x14;
		public const int KEY_ESCAPE = 0x1B;
		public const int KEY_SPACE = 0x20;
		public const int KEY_PRIOR = 0x21;
		public const int KEY_NEXT = 0x22;
		public const int KEY_END = 0x23;
		public const int KEY_HOME = 0x24;
		public const int KEY_LEFT = 0x25;
		public const int KEY_UP = 0x26;
		public const int KEY_RIGHT = 0x27;
		public const int KEY_DOWN = 0x28;
		public const int KEY_SELECT = 0x29;
		public const int KEY_PRINT = 0x2A;
		public const int KEY_EXECUTE = 0x2B;
		public const int KEY_SNAPSHOT = 0x2C;
		public const int KEY_INSERT = 0x2D;
		public const int KEY_DELETE = 0x2E;
		public const int KEY_HELP = 0x2F;
		
		// KEY_A thru KEY_Z are the same as their ASCII equivalents: 'A' thru 'Z'
		// KEY_0 thru KEY_9 are the same as their ASCII equivalents: '0' thru '9'
		
		public const int KEY_NUMPAD0 = 0x60;
		public const int KEY_NUMPAD1 = 0x61;
		public const int KEY_NUMPAD2 = 0x62;
		public const int KEY_NUMPAD3 = 0x63;
		public const int KEY_NUMPAD4 = 0x64;
		public const int KEY_NUMPAD5 = 0x65;
		public const int KEY_NUMPAD6 = 0x66;
		public const int KEY_NUMPAD7 = 0x67;
		public const int KEY_NUMPAD8 = 0x68;
		public const int KEY_NUMPAD9 = 0x69;
		public const int KEY_MULTIPLY = 0x6A;
		public const int KEY_ADD = 0x6B;
		public const int KEY_SEPARATOR = 0x6C;
		public const int KEY_SUBTRACT = 0x6D;
		public const int KEY_DECIMAL = 0x6E;
		public const int KEY_DIVIDE = 0x6F;
		public const int KEY_F1 = 0x70;
		public const int KEY_F2 = 0x71;
		public const int KEY_F3 = 0x72;
		public const int KEY_F4 = 0x73;
		public const int KEY_F5 = 0x74;
		public const int KEY_F6 = 0x75;
		public const int KEY_F7 = 0x76;
		public const int KEY_F8 = 0x77;
		public const int KEY_F9 = 0x78;
		public const int KEY_F10 = 0x79;
		public const int KEY_F11 = 0x7A;
		public const int KEY_F12 = 0x7B;
		public const int KEY_F13 = 0x7C;
		public const int KEY_F14 = 0x7D;
		public const int KEY_F15 = 0x7E;
		public const int KEY_F16 = 0x7F;
		
		public const int KEY_NUMLOCK = 0x90;
		
		// Variant VarType tags
		
		public const int V_EMPTY = 0;
		public const int V_NULL = 1;
		public const int V_INTEGER = 2;
		public const int V_LONG = 3;
		public const int V_SINGLE = 4;
		public const int V_DOUBLE = 5;
		public const int V_CURRENCY = 6;
		public const int V_DATE = 7;
		public const int V_STRING = 8;
		
		
		// Event Parameters
		
		// ErrNum (LinkError)
		public const int WRONG_FORMAT = 1;
		public const int DDE_SOURCE_CLOSED = 6;
		public const int TOO_MANY_LINKS = 7;
		public const int DATA_TRANSFER_FAILED = 8;
		
		// QueryUnload
		public const int FORM_CONTROLMENU = 0;
		public const int FORM_CODE = 1;
		public const int APP_WINDOWS = 2;
		public const int APP_TASKMANAGER = 3;
		public const int FORM_MDIFORM = 4;
		
		// Properties
		
		// Colors
		public const int BLACK = 0x0;
		public const int RED = 0xFF;
		public const int GREEN = 0xFF00;
		public const int YELLOW = 0xFFFF;
		public const int BLUE = 0xFF0000;
		public const int MAGENTA = 0xFF00FF;
		public const int CYAN = 0xFFFF00;
		public const int WHITE = 0xFFFFFF;
		public const int GRAY = 0xC0C0C0;
		// System Colors
		public static readonly int SCROLL_BARS = unchecked((int) 0x80000000); // Scroll-bars gray area.
		public static readonly int DESKTOP = unchecked((int) 0x80000001); // Desktop.
		public static readonly int ACTIVE_TITLE_BAR = unchecked((int) 0x80000002); // Active window caption.
		public static readonly int INACTIVE_TITLE_BAR = unchecked((int) 0x80000003); // Inactive window caption.
		public static readonly int MENU_BAR = unchecked((int) 0x80000004); // Menu background.
		public static readonly int WINDOW_BACKGROUND = unchecked((int) 0x80000005); // Window background.
		public static readonly int WINDOW_FRAME = unchecked((int) 0x80000006); // Window frame.
		public static readonly int MENU_TEXT = unchecked((int) 0x80000007); // Text in menus.
		public static readonly int WINDOW_TEXT = unchecked((int) 0x80000008); // Text in windows.
		public static readonly int TITLE_BAR_TEXT = unchecked((int) 0x80000009); // Text in caption, size box, scroll-bar arrow box..
		public static readonly int ACTIVE_BORDER = unchecked((int) 0x8000000A); // Active window border.
		public static readonly int INACTIVE_BORDER = unchecked((int) 0x8000000B); // Inactive window border.
		public static readonly int APPLICATION_WORKSPACE = unchecked((int) 0x8000000C); // Background color of multiple document interface (MDI) applications.
		public static readonly int HIGHLIGHT = unchecked((int) 0x8000000D); // Items selected item in a control.
		public static readonly int HIGHLIGHT_TEXT = unchecked((int) 0x8000000E); // Text of item selected in a control.
		public static readonly int BUTTON_FACE = unchecked((int) 0x8000000F); // Face shading on command buttons.
		public static readonly int BUTTON_SHADOW = unchecked((int) 0x80000010); // Edge shading on command buttons.
		public static readonly int GRAY_TEXT = unchecked((int) 0x80000011); // Grayed (disabled) text.  This color is set to 0 if the current display driver does not support a solid gray color.
		public static readonly int BUTTON_TEXT = unchecked((int) 0x80000012); // Text on push buttons.
		
		// Enumerated Types
		
		// Align (picture box)
		public static readonly Threed.enumFloodTypeConstants NONE = Threed.enumFloodTypeConstants._None;
		public const int ALIGN_TOP = 1;
		public const int ALIGN_BOTTOM = 2;
		
		// Alignment
		public const int LEFT_JUSTIFY = 0; // 0 - Left Justify
		public const int RIGHT_JUSTIFY = 1; // 1 - Right Justify
		public const int CENTER = 2; // 2 - Center
		
		// BorderStyle (form)
		//Global Const NONE = 0          ' 0 - None
		public const int FIXED_SINGLE = 1; // 1 - Fixed Single
		public const int SIZABLE = 2; // 2 - Sizable (Forms only)
		public const int FIXED_DOUBLE = 3; // 3 - Fixed Double (Forms only)
		
		// BorderStyle (Shape and Line)
		public const int TRANSPARENT = 0; //0 - Transparent
		public const int SOLID = 1; //1 - Solid
		public const int DASH = 2; // 2 - Dash
		public const int DOT = 3; // 3 - Dot
		public const int DASH_DOT = 4; // 4 - Dash-Dot
		public const int DASH_DOT_DOT = 5; // 5 - Dash-Dot-Dot
		public const int INSIDE_SOLID = 6; // 6 - Inside Solid
		
		// MousePointer
		public const int DEFAULT_Renamed = 0; // 0 - Default
		public const int ARROW = 1; // 1 - Arrow
		public const int CROSSHAIR = 2; // 2 - Cross
		public const int IBEAM = 3; // 3 - I-Beam
		public const int ICON_POINTER = 4; // 4 - Icon
		public const int SIZE_POINTER = 5; // 5 - Size
		public const int SIZE_NE_SW = 6; // 6 - Size NE SW
		public const int SIZE_N_S = 7; // 7 - Size N S
		public const int SIZE_NW_SE = 8; // 8 - Size NW SE
		public const int SIZE_W_E = 9; // 9 - Size W E
		public const int UP_ARROW = 10; // 10 - Up Arrow
		public const int HOURGLASS = 11; // 11 - Hourglass
		public const int NO_DROP = 12; // 12 - No drop
		
		// DragMode
		public const int MANUAL = 0; // 0 - Manual
		public const int AUTOMATIC = 1; // 1 - Automatic
		
		// DrawMode
		public const int BLACKNESS = 1; // 1 - Blackness
		public const int NOT_MERGE_PEN = 2; // 2 - Not Merge Pen
		public const int MASK_NOT_PEN = 3; // 3 - Mask Not Pen
		public const int NOT_COPY_PEN = 4; // 4 - Not Copy Pen
		public const int MASK_PEN_NOT = 5; // 5 - Mask Pen Not
		public const int INVERT = 6; // 6 - Invert
		public const int XOR_PEN = 7; // 7 - Xor Pen
		public const int NOT_MASK_PEN = 8; // 8 - Not Mask Pen
		public const int MASK_PEN = 9; // 9 - Mask Pen
		public const int NOT_XOR_PEN = 10; // 10 - Not Xor Pen
		public const int NOP = 11; // 11 - Nop
		public const int MERGE_NOT_PEN = 12; // 12 - Merge Not Pen
		public const int COPY_PEN = 13; // 13 - Copy Pen
		public const int MERGE_PEN_NOT = 14; // 14 - Merge Pen Not
		public const int MERGE_PEN = 15; // 15 - Merge Pen
		public const int WHITENESS = 16; // 16 - Whiteness
		
		// DrawStyle
		//Global Const SOLID = 0        ' 0 - Solid
		//Global Const DASH = 1         ' 1 - Dash
		//Global Const DOT = 2          ' 2 - Dot
		//Global Const DASH_DOT = 3     ' 3 - Dash-Dot
		//Global Const DASH_DOT_DOT = 4 ' 4 - Dash-Dot-Dot
		//Global Const INVISIBLE = 5    ' 5 - Invisible
		//Global Const INSIDE_SOLID = 6 ' 6 - Inside Solid
		//
		// FillStyle
		// Global Const SOLID = 0           ' 0 - Solid
		//Global Const TRANSPARENT = 1       ' 1 - Transparent
		public const int HORIZONTAL_LINE = 2; // 2 - Horizontal Line
		public const int VERTICAL_LINE = 3; // 3 - Vertical Line
		public const int UPWARD_DIAGONAL = 4; // 4 - Upward Diagonal
		public const int DOWNWARD_DIAGONAL = 5; // 5 - Downward Diagonal
		public const int CROSS = 6; // 6 - Cross
		public const int DIAGONAL_CROSS = 7; // 7 - Diagonal Cross
		
		// LinkMode (forms and controls)
		public const int LINK_NONE = 0; // 0 - None
		public const int LINK_SOURCE = 1; // 1 - Source (forms only)
		public const int LINK_AUTOMATIC = 1; // 1 - Automatic (controls only)
		public const int LINK_MANUAL = 2; // 2 - Manual (controls only)
		public const int LINK_NOTIFY = 3; // 3 - Notify (controls only)
		
		// LinkMode (kept for VB1.0 compatibility, use new constants instead)
		public const int HOT = 1; // 1 - Hot (controls only)
		public const int Server = 1; // 1 - Server (forms only)
		public const int COLD = 2; // 2 - Cold (controls only)
		
		
		// ScaleMode
		public const int USER = 0; // 0 - User
		public const int TWIPS = 1; // 1 - Twip
		public const int POINTS = 2; // 2 - Point
		public const int PIXELS = 3; // 3 - Pixel
		public const int CHARACTERS = 4; // 4 - Character
		public const int INCHES = 5; // 5 - Inch
		public const int MILLIMETERS = 6; // 6 - Millimeter
		public const int CENTIMETERS = 7; // 7 - Centimeter
		
		// ScrollBar
		// Global Const NONE     = 0 ' 0 - None
		public const int HORIZONTAL = 1; // 1 - Horizontal
		public const int VERTICAL = 2; // 2 - Vertical
		public const int BOTH = 3; // 3 - Both
		
		// Shape
		public const int SHAPE_RECTANGLE = 0;
		public const int SHAPE_SQUARE = 1;
		public const int SHAPE_OVAL = 2;
		public const int SHAPE_CIRCLE = 3;
		public const int SHAPE_ROUNDED_RECTANGLE = 4;
		public const int SHAPE_ROUNDED_SQUARE = 5;
		
		// WindowState
		public const int NORMAL = 0; // 0 - Normal
		public const int MINIMIZED = 1; // 1 - Minimized
		public const int MAXIMIZED = 2; // 2 - Maximized
		
		// Check Value
		public const int UNCHECKED_Renamed = 0; // 0 - Unchecked
		public const int CHECKED_Renamed = 1; // 1 - Checked
		public const int GRAYED = 2; // 2 - Grayed
		
		// Shift parameter masks
		public const int SHIFT_MASK = 1;
		public const int CTRL_MASK = 2;
		public const int ALT_MASK = 4;
		
		// Button parameter masks
		public const int LEFT_BUTTON = 1;
		public const int RIGHT_BUTTON = 2;
		public const int MIDDLE_BUTTON = 4;
		
		// Function Parameters
		// MsgBox parameters
		public static readonly MsgBoxStyle MB_OK = MsgBoxStyle.OkOnly; // OK button only
		public const int MB_OKCANCEL = 1; // OK and Cancel buttons
		public const int MB_ABORTRETRYIGNORE = 2; // Abort, Retry, and Ignore buttons
		public const int MB_YESNOCANCEL = 3; // Yes, No, and Cancel buttons
		public const int MB_YESNO = 4; // Yes and No buttons
		public const int MB_RETRYCANCEL = 5; // Retry and Cancel buttons
		
		public static readonly MsgBoxStyle MB_ICONSTOP = MsgBoxStyle.Critical; // Critical message
		public const int MB_ICONQUESTION = 32; // Warning query
		public static readonly MsgBoxStyle MB_ICONEXCLAMATION = MsgBoxStyle.Exclamation; // Warning message
		public static readonly MsgBoxStyle MB_ICONINFORMATION = MsgBoxStyle.Information; // Information message
		
		public const int MB_APPLMODAL = 0; // Application Modal Message Box
		public const int MB_DEFBUTTON1 = 0; // First button is default
		public const int MB_DEFBUTTON2 = 256; // Second button is default
		public const int MB_DEFBUTTON3 = 512; // Third button is default
		public const int MB_SYSTEMMODAL = 4096; //System Modal
		
		// MsgBox return values
		public static readonly DialogResult IDOK = System.Windows.Forms.DialogResult.OK; // OK button pressed
		public const int IDCANCEL = 2; // Cancel button pressed
		public const int IDABORT = 3; // Abort button pressed
		public const int IDRETRY = 4; // Retry button pressed
		public const int IDIGNORE = 5; // Ignore button pressed
		public const int IDYES = 6; // Yes button pressed
		public const int IDNO = 7; // No button pressed
		
		// SetAttr, Dir, GetAttr functions
		public const int ATTR_NORMAL = 0;
		public const int ATTR_READONLY = 1;
		public const int ATTR_HIDDEN = 2;
		public const int ATTR_SYSTEM = 4;
		public const int ATTR_VOLUME = 8;
		public const int ATTR_DIRECTORY = 16;
		public const int ATTR_ARCHIVE = 32;
		
		//Grid
		//ColAlignment,FixedAlignment Properties
		public const int GRID_ALIGNLEFT = 0;
		public const int GRID_ALIGNRIGHT = 1;
		public const int GRID_ALIGNCENTER = 2;
		
		//Fillstyle Property
		public const int GRID_SINGLE = 0;
		public const int GRID_REPEAT = 1;
		
		
		//Data control
		//Error event Response arguments
		public const int DATA_ERRCONTINUE = 0;
		public const int DATA_ERRDISPLAY = 1;
		
		//Editmode property values
		public const int DATA_EDITNONE = 0;
		public const int DATA_EDITMODE = 1;
		public const int DATA_EDITADD = 2;
		
		// Options property values
		public const int DATA_DENYWRITE = 0x1;
		public const int DATA_DENYREAD = 0x2;
		public const int DATA_READONLY = 0x4;
		public const int DATA_APPENDONLY = 0x8;
		public const int DATA_INCONSISTENT = 0x10;
		public const int DATA_CONSISTENT = 0x20;
		public const int DATA_SQLPASSTHROUGH = 0x40;
		
		//Validate event Action arguments
		public const int DATA_ACTIONCANCEL = 0;
		public const int DATA_ACTIONMOVEFIRST = 1;
		public const int DATA_ACTIONMOVEPREVIOUS = 2;
		public const int DATA_ACTIONMOVENEXT = 3;
		public const int DATA_ACTIONMOVELAST = 4;
		public const int DATA_ACTIONADDNEW = 5;
		public const int DATA_ACTIONUPDATE = 6;
		public const int DATA_ACTIONDELETE = 7;
		public const int DATA_ACTIONFIND = 8;
		public const int DATA_ACTIONBOOKMARK = 9;
		public const int DATA_ACTIONCLOSE = 10;
		public const int DATA_ACTIONUNLOAD = 11;
		
		
		//OLE Client Control
		//Actions
		public const int OLE_CREATE_EMBED = 0;
		public const int OLE_CREATE_NEW = 0; //from ole1 control
		public const int OLE_CREATE_LINK = 1;
		public const int OLE_CREATE_FROM_FILE = 1; //from ole1 control
		public const int OLE_COPY = 4;
		public const int OLE_PASTE = 5;
		public const int OLE_UPDATE = 6;
		public const int OLE_ACTIVATE = 7;
		public const int OLE_CLOSE = 9;
		public const int OLE_DELETE = 10;
		public const int OLE_SAVE_TO_FILE = 11;
		public const int OLE_READ_FROM_FILE = 12;
		public const int OLE_INSERT_OBJ_DLG = 14;
		public const int OLE_PASTE_SPECIAL_DLG = 15;
		public const int OLE_FETCH_VERBS = 17;
		public const int OLE_SAVE_TO_OLE1FILE = 18;
		
		//OLEType
		public const int OLE_LINKED = 0;
		public const int OLE_EMBEDDED = 1;
		public const int OLE_NONE = 3;
		
		//OLETypeAllowed
		public const int OLE_EITHER = 2;
		
		//UpdateOptions
		public const int OLE_AUTOMATIC = 0;
		public const int OLE_FROZEN = 1;
		public const int OLE_MANUAL = 2;
		
		//AutoActivate modes
		//Note that OLE_ACTIVATE_GETFOCUS only applies to objects that
		//support "inside-out" activation.  See related Verb notes below.
		public const int OLE_ACTIVATE_MANUAL = 0;
		public const int OLE_ACTIVATE_GETFOCUS = 1;
		public const int OLE_ACTIVATE_DOUBLECLICK = 2;
		
		//SizeModes
		public const int OLE_SIZE_CLIP = 0;
		public const int OLE_SIZE_STRETCH = 1;
		public const int OLE_SIZE_AUTOSIZE = 2;
		
		//DisplayTypes
		public const int OLE_DISPLAY_CONTENT = 0;
		public const int OLE_DISPLAY_ICON = 1;
		
		//Update Event Constants
		public const int OLE_CHANGED = 0;
		public const int OLE_SAVED = 1;
		public const int OLE_CLOSED = 2;
		public const int OLE_RENAMED_Renamed = 3;
		
		//Special Verb Values
		public const int VERB_PRIMARY = 0;
		public const int VERB_SHOW = -1;
		public const int VERB_OPEN = -2;
		public const int VERB_HIDE = -3;
		public const int VERB_INPLACEUIACTIVATE = -4;
		public const int VERB_INPLACEACTIVATE = -5;
		//The last two verbs are for objects that support "inside-out" activation,
		//meaning they can be edited in-place, and that they support being left
		//in-place-active even when the input focus moves to another control or form.
		//These objects actually have 2 levels of being active.  "InPlace Active"
		//means that the object is ready for the user to click inside it and start
		//working with it.  "In-Place UI-Active" means that, in addition, if the object
		//has any other UI associated with it, such as floating palette windows,
		//that those windows are visible and ready for use.  Any number of objects
		//can be "In-Place Active" at a time, although only one can be
		//"InPlace UI-Active".
		
		//You can cause an object to move to either one of states programmatically by
		//setting the Verb property to the appropriate verb and setting
		//Action=OLE_ACTIVATE.
		
		//Also, if you set AutoActivate = OLE_ACTIVATE_GETFOCUS, the server will
		//automatically be put into "InPlace UI-Active" state when the user clicks
		//on or tabs into the control.
		
		//VerbFlag Bit Masks
		public const int VERBFLAG_GRAYED = 0x1;
		public const int VERBFLAG_DISABLED = 0x2;
		public const int VERBFLAG_CHECKED = 0x8;
		public const int VERBFLAG_SEPARATOR = 0x800;
		
		//MiscFlag Bits - Or these together as desired for special behaviors
		
		//MEMSTORAGE causes the control to use memory to store the object while
		//           it is loaded.  This is faster than the default (disk-tempfile),
		//           but can consume a lot of memory for objects whose data takes
		//           up a lot of space, such as the bitmap for a paint program.
		public const int OLE_MISCFLAG_MEMSTORAGE = 0x1;
		
		//DISABLEINPLACE overrides the control's default behavior of allowing
		//           in-place activation for objects that support it.  If you
		//           are having problems activating an object inplace, you can
		//           force it to always activate in a separate window by setting this
		//           bit
		public const int OLE_MISCFLAG_DISABLEINPLACE = 0x2;
		
		//Common Dialog Control
		//Action Property
		public const int DLG_FILE_OPEN = 1;
		public const int DLG_FILE_SAVE = 2;
		public const int DLG_COLOR = 3;
		public const int DLG_FONT = 4;
		public const int DLG_PRINT = 5;
		public const int DLG_HELP = 6;
		
		//File Open/Save Dialog Flags
		public const int OFN_READONLY = 0x1;
		public const int OFN_OVERWRITEPROMPT = 0x2;
		public const int OFN_HIDEREADONLY = 0x4;
		public const int OFN_NOCHANGEDIR = 0x8;
		public const int OFN_SHOWHELP = 0x10;
		public const int OFN_NOVALIDATE = 0x100;
		public const int OFN_ALLOWMULTISELECT = 0x200;
		public const int OFN_EXTENSIONDIFFERENT = 0x400;
		public const int OFN_PATHMUSTEXIST = 0x800;
		public const int OFN_FILEMUSTEXIST = 0x1000;
		public const int OFN_CREATEPROMPT = 0x2000;
		public const int OFN_SHAREAWARE = 0x4000;
		public const int OFN_NOREADONLYRETURN = 0x8000;
		
		//Color Dialog Flags
		public const int CC_RGBINIT = 0x1;
		public const int CC_FULLOPEN = 0x2;
		public const int CC_PREVENTFULLOPEN = 0x4;
		public const int CC_SHOWHELP = 0x8;
		
		//Fonts Dialog Flags
		public const int CF_SCREENFONTS = 0x1;
		public const int CF_PRINTERFONTS = 0x2;
		public const int CF_BOTH = 0x3;
		public const int CF_SHOWHELP = 0x4;
		public const int CF_INITTOLOGFONTSTRUCT = 0x40;
		public const int CF_USESTYLE = 0x80;
		public const int CF_EFFECTS = 0x100;
		public const int CF_APPLY = 0x200;
		public const int CF_ANSIONLY = 0x400;
		public const int CF_NOVECTORFONTS = 0x800;
		public const int CF_NOSIMULATIONS = 0x1000;
		public const int CF_LIMITSIZE = 0x2000;
		public const int CF_FIXEDPITCHONLY = 0x4000;
		public const int CF_WYSIWYG = 0x8000; //must also have CF_SCREENFONTS & CF_PRINTERFONTS
		public const int CF_FORCEFONTEXIST = 0x10000;
		public const int CF_SCALABLEONLY = 0x20000;
		public const int CF_TTONLY = 0x40000;
		public const int CF_NOFACESEL = 0x80000;
		public const int CF_NOSTYLESEL = 0x100000;
		public const int CF_NOSIZESEL = 0x200000;
		
		//Printer Dialog Flags
		public const int PD_ALLPAGES = 0x0;
		public const int PD_SELECTION = 0x1;
		public const int PD_PAGENUMS = 0x2;
		public const int PD_NOSELECTION = 0x4;
		public const int PD_NOPAGENUMS = 0x8;
		public const int PD_COLLATE = 0x10;
		public const int PD_PRINTTOFILE = 0x20;
		public const int PD_PRINTSETUP = 0x40;
		public const int PD_NOWARNING = 0x80;
		public const int PD_RETURNDC = 0x100;
		public const int PD_RETURNIC = 0x200;
		public const int PD_RETURNDEFAULT = 0x400;
		public const int PD_SHOWHELP = 0x800;
		public const int PD_USEDEVMODECOPIES = 0x40000;
		public const int PD_DISABLEPRINTTOFILE = 0x80000;
		public const int PD_HIDEPRINTTOFILE = 0x100000;
		
		//Help Constants
		public const int HELP_CONTEXT = 0x1; //Display topic in ulTopic
		public const int HELP_QUIT = 0x2; //Terminate help
		public const int HELP_INDEX = 0x3; //Display index
		public const int HELP_CONTENTS = 0x3;
		public const int HELP_HELPONHELP = 0x4; //Display help on using help
		public const int HELP_SETINDEX = 0x5; //Set the current Index for multi index help
		public const int HELP_SETCONTENTS = 0x5;
		public const int HELP_CONTEXTPOPUP = 0x8;
		public const int HELP_FORCEFILE = 0x9;
		public const int HELP_KEY = 0x101; //Display topic for keyword in offabData
		public const int HELP_COMMAND = 0x102;
		public const int HELP_PARTIALKEY = 0x105; //call the search engine in winhelp
		
		//Error Constants
		public const int CDERR_DIALOGFAILURE = -32768;
		
		public const int CDERR_GENERALCODES = 0x7FFF;
		public const int CDERR_STRUCTSIZE = 0x7FFE;
		public const int CDERR_INITIALIZATION = 0x7FFD;
		public const int CDERR_NOTEMPLATE = 0x7FFC;
		public const int CDERR_NOHINSTANCE = 0x7FFB;
		public const int CDERR_LOADSTRFAILURE = 0x7FFA;
		public const int CDERR_FINDRESFAILURE = 0x7FF9;
		public const int CDERR_LOADRESFAILURE = 0x7FF8;
		public const int CDERR_LOCKRESFAILURE = 0x7FF7;
		public const int CDERR_MEMALLOCFAILURE = 0x7FF6;
		public const int CDERR_MEMLOCKFAILURE = 0x7FF5;
		public const int CDERR_NOHOOK = 0x7FF4;
		
		//Added for CMDIALOG.VBX
		public const int CDERR_CANCEL = 0x7FF3;
		public const int CDERR_NODLL = 0x7FF2;
		public const int CDERR_ERRPROC = 0x7FF1;
		public const int CDERR_ALLOC = 0x7FF0;
		public const int CDERR_HELP = 0x7FEF;
		
		public const int PDERR_PRINTERCODES = 0x6FFF;
		public const int PDERR_SETUPFAILURE = 0x6FFE;
		public const int PDERR_PARSEFAILURE = 0x6FFD;
		public const int PDERR_RETDEFFAILURE = 0x6FFC;
		public const int PDERR_LOADDRVFAILURE = 0x6FFB;
		public const int PDERR_GETDEVMODEFAIL = 0x6FFA;
		public const int PDERR_INITFAILURE = 0x6FF9;
		public const int PDERR_NODEVICES = 0x6FF8;
		public const int PDERR_NODEFAULTPRN = 0x6FF7;
		public const int PDERR_DNDMMISMATCH = 0x6FF6;
		public const int PDERR_CREATEICFAILURE = 0x6FF5;
		public const int PDERR_PRINTERNOTFOUND = 0x6FF4;
		
		public const int CFERR_CHOOSEFONTCODES = 0x5FFF;
		public const int CFERR_NOFONTS = 0x5FFE;
		
		public const int FNERR_FILENAMECODES = 0x4FFF;
		public const int FNERR_SUBCLASSFAILURE = 0x4FFE;
		public const int FNERR_INVALIDFILENAME = 0x4FFD;
		public const int FNERR_BUFFERTOOSMALL = 0x4FFC;
		
		public const int FRERR_FINDREPLACECODES = 0x3FFF;
		public const int CCERR_CHOOSECOLORCODES = 0x2FFF;
		
		
		//---------------------------------------------------------
		//      Table of Contents for Visual Basic Professional
		//
		//       1.  3-D Controls
		//           (Frame/Panel/Option/Check/Command/Group Push)
		//       2.  Animated Button
		//       3.  Gauge Control
		//       4.  Graph Control Section
		//       5.  Key Status Control
		//       6.  Spin Button
		//       7.  MCI Control (Multimedia)
		//       8.  Masked Edit Control
		//       9.  Comm Control
		//       10. Outline Control
		//---------------------------------------------------------
		
		
		//-------------------------------------------------------------------
		//3D Controls
		//-------------------------------------------------------------------
		//Alignment (Check Box)
		public const int SSCB_TEXT_RIGHT = 0; //0 - Text to the right
		public const int SSCB_TEXT_LEFT = 1; //1 - Text to the left
		
		//Alignment (Option Button)
		public const int SSOB_TEXT_RIGHT = 0; //0 - Text to the right
		public const int SSOB_TEXT_LEFT = 1; //1 - Text to the left
		
		//Alignment (Frame)
		public const int SSFR_LEFT_JUSTIFY = 0; //0 - Left justify text
		public const int SSFR_RIGHT_JUSTIFY = 1; //1 - Right justify text
		public const int SSFR_CENTER = 2; //2 - Center text
		
		//Alignment (Panel)
		public const int SSPN_LEFT_TOP = 0; //0 - Text to left and top
		public const int SSPN_LEFT_MIDDLE = 1; //1 - Text to left and middle
		public const int SSPN_LEFT_BOTTOM = 2; //2 - Text to left and bottom
		public const int SSPN_RIGHT_TOP = 3; //3 - Text to right and top
		public const int SSPN_RIGHT_MIDDLE = 4; //4 - Text to right and middle
		public const int SSPN_RIGHT_BOTTOM = 5; //5 - Text to right and bottom
		public const int SSPN_CENTER_TOP = 6; //6 - Text to center and top
		public const int SSPN_CENTER_MIDDLE = 7; //7 - Text to center and middle
		public const int SSPN_CENTER_BOTTOM = 8; //8 - Text to center and bottom
		
		//Autosize (Command Button)
		public const int SS_AUTOSIZE_NONE = 0; //0 - No Autosizing
		public const int SSPB_AUTOSIZE_PICTOBUT = 1; //0 - Autosize Picture to Button
		public const int SSPB_AUTOSIZE_BUTTOPIC = 2; //0 - Autosize Button to Picture
		
		//Autosize (Ribbon Button)
		//Global Const SS_AUTOSIZE_NONE      = 0  '0 - No Autosizing
		public const int SSRI_AUTOSIZE_PICTOBUT = 1; //0 - Autosize Picture to Button
		public const int SSRI_AUTOSIZE_BUTTOPIC = 2; //0 - Autosize Button to Picture
		
		//Autosize (Panel)
		//Global Const SS_AUTOSIZE_NONE    = 0    '0 - No Autosizing
		public const int SSPN_AUTOSIZE_WIDTH = 1; //1 - Autosize Panel width to Caption
		public const int SSPN_AUTOSIZE_HEIGHT = 2; //2 - Autosize Panel height to Caption
		public const int SSPN_AUTOSIZE_CHILD = 3; //3 - Autosize Child to Panel
		
		//BevelInner (Panel)
		public const int SS_BEVELINNER_NONE = 0; //0 - No Inner Bevel
		public const int SS_BEVELINNER_INSET = 1; //1 - Inset Inner Bevel
		public const int SS_BEVELINNER_RAISED = 2; //2 - Raised Inner Bevel
		
		//BevelOuter (Panel)
		public const int SS_BEVELOUTER_NONE = 0; //0 - No Outer Bevel
		public const int SS_BEVELOUTER_INSET = 1; //1 - Inset Outer Bevel
		public const int SS_BEVELOUTER_RAISED = 2; //2 - Raised Outer Bevel
		
		//FloodType (Panel)
		public const int SS_FLOODTYPE_NONE = 0; //0 - No flood
		public const int SS_FLOODTYPE_L_TO_R = 1; //1 - Left to light
		public const int SS_FLOODTYPE_R_TO_L = 2; //2 - Right to left
		public const int SS_FLOODTYPE_T_TO_B = 3; //3 - Top to bottom
		public const int SS_FLOODTYPE_B_TO_T = 4; //4 - Bottom to top
		public const int SS_FLOODTYPE_CIRCLE = 5; //5 - Widening circle
		
		//Font3D (Panel, Command Button, Option Button, Check Box, Frame)
		public const int SS_FONT3D_NONE = 0; //0 - No 3-D text
		public const int SS_FONT3D_RAISED_LIGHT = 1; //1 - Raised with light shading
		public const int SS_FONT3D_RAISED_HEAVY = 2; //2 - Raised with heavy shading
		public const int SS_FONT3D_INSET_LIGHT = 3; //3 - Inset with light shading
		public const int SS_FONT3D_INSET_HEAVY = 4; //4 - Inset with heavy shading
		
		//PictureDnChange (Ribbon Button)
		public const int SS_PICDN_NOCHANGE = 0; //0 - Use 'Up'bitmap with no change
		public const int SS_PICDN_DITHER = 1; //1 - Dither 'Up'bitmap
		public const int SS_PICDN_INVERT = 2; //2 - Invert 'Up'bitmap
		
		//ShadowColor (Panel, Frame)
		public const int SS_SHADOW_DARKGREY = 0; //0 - Dark grey shadow
		public const int SS_SHADOW_BLACK = 1; //1 - Black shadow
		
		//ShadowStyle (Frame)
		public const int SS_SHADOW_INSET = 0; //0 - Shadow inset
		public const int SS_SHADOW_RAISED = 1; //1 - Shadow raised
		
		
		//---------------------------------------
		//Animated Button
		//---------------------------------------
		//Cycle property
		public const int ANI_ANIMATED = 0;
		public const int ANI_MULTISTATE = 1;
		public const int ANI_TWO_STATE = 2;
		
		//Click Filter property
		public const int ANI_ANYWHERE = 0;
		public const int ANI_IMAGE_AND_TEXT = 1;
		public const int ANI_IMAGE = 2;
		public const int ANI_TEXT = 3;
		
		//PicDrawMode Property
		public const int ANI_XPOS_YPOS = 0;
		public const int ANI_AUTOSIZE = 1;
		public const int ANI_STRETCH = 2;
		
		//SpecialOp Property
		public const int ANI_CLICK = 1;
		
		//TextPosition Property
		public const int ANI_CENTER = 0;
		public const int ANI_LEFT = 1;
		public const int ANI_RIGHT = 2;
		public const int ANI_BOTTON = 3;
		public const int ANI_TOP = 4;
		
		
		//---------------------------------------
		//GAUGE
		//---------------------------------------
		//Style Property
		public const int GAUGE_HORIZ = 0;
		public const int GAUGE_VERT = 1;
		public const int GAUGE_SEMI = 2;
		public const int GAUGE_FULL = 3;
		
		
		//----------------------------------------
		//Graph Control
		//----------------------------------------
		//General
		public const int G_NONE = 0;
		public const int G_DEFAULT = 0;
		
		public const int G_OFF = 0;
		public const int G_ON = 1;
		
		public const int G_MONO = 0;
		public const int G_COLOR = 1;
		
		//Graph Types
		public static readonly GraphLib.GraphTypeConstants G_PIE2D = GraphLib.GraphTypeConstants.gphPie2D;
		public static readonly GraphLib.GraphTypeConstants G_PIE3D = GraphLib.GraphTypeConstants.gphPie3D;
		public static readonly GraphLib.GraphTypeConstants G_BAR2D = GraphLib.GraphTypeConstants.gphBar2D;
		public static readonly GraphLib.GraphTypeConstants G_BAR3D = GraphLib.GraphTypeConstants.gphBar3D;
		public const int G_GANTT = 5;
		public const int G_LINE = 6;
		public const int G_LOGLIN = 7;
		public const int G_AREA = 8;
		public const int G_SCATTER = 9;
		public const int G_POLAR = 10;
		public const int G_HLC = 11;
		
		//Colors
		public const int G_BLACK = 0;
		public const int G_BLUE = 1;
		public const int G_GREEN = 2;
		public const int G_CYAN = 3;
		public const int G_RED = 4;
		public const int G_MAGENTA = 5;
		public const int G_BROWN = 6;
		public const int G_LIGHT_GRAY = 7;
		public const int G_DARK_GRAY = 8;
		public const int G_LIGHT_BLUE = 9;
		public const int G_LIGHT_GREEN = 10;
		public const int G_LIGHT_CYAN = 11;
		public const int G_LIGHT_RED = 12;
		public const int G_LIGHT_MAGENTA = 13;
		public const int G_YELLOW = 14;
		public const int G_WHITE = 15;
		public const int G_AUTOBW = 16;
		
		//Patterns
		public const int G_SOLID = 0;
		public const int G_HOLLOW = 1;
		public const int G_HATCH1 = 2;
		public const int G_HATCH2 = 3;
		public const int G_HATCH3 = 4;
		public const int G_HATCH4 = 5;
		public const int G_HATCH5 = 6;
		public const int G_HATCH6 = 7;
		public const int G_BITMAP1 = 16;
		public const int G_BITMAP2 = 17;
		public const int G_BITMAP3 = 18;
		public const int G_BITMAP4 = 19;
		public const int G_BITMAP5 = 20;
		public const int G_BITMAP6 = 21;
		public const int G_BITMAP7 = 22;
		public const int G_BITMAP8 = 23;
		public const int G_BITMAP9 = 24;
		public const int G_BITMAP10 = 25;
		public const int G_BITMAP11 = 26;
		public const int G_BITMAP12 = 27;
		public const int G_BITMAP13 = 28;
		public const int G_BITMAP14 = 29;
		public const int G_BITMAP15 = 30;
		public const int G_BITMAP16 = 31;
		
		//Symbols
		public const int G_CROSS_PLUS = 0;
		public const int G_CROSS_TIMES = 1;
		public const int G_TRIANGLE_UP = 2;
		public const int G_SOLID_TRIANGLE_UP = 3;
		public const int G_TRIANGLE_DOWN = 4;
		public const int G_SOLID_TRIANGLE_DOWN = 5;
		public const int G_SQUARE = 6;
		public const int G_SOLID_SQUARE = 7;
		public const int G_DIAMOND = 8;
		public const int G_SOLID_DIAMOND = 9;
		
		//Line Styles
		//Global Const G_SOLID = 0
		public const int G_DASH = 1;
		public const int G_DOT = 2;
		public const int G_DASHDOT = 3;
		public const int G_DASHDOTDOT = 4;
		
		//Grids
		public const int G_HORIZONTAL = 1;
		public const int G_VERTICAL = 2;
		
		//Statistics
		public const int G_MEAN = 1;
		public const int G_MIN_MAX = 2;
		public const int G_STD_DEV = 4;
		public const int G_BEST_FIT = 8;
		
		//Data Arrays
		public const int G_GRAPH_DATA = 1;
		public const int G_COLOR_DATA = 2;
		public const int G_EXTRA_DATA = 3;
		public const int G_LABEL_TEXT = 4;
		public const int G_LEGEND_TEXT = 5;
		public const int G_PATTERN_DATA = 6;
		public const int G_SYMBOL_DATA = 7;
		public const int G_XPOS_DATA = 8;
		public static readonly GraphLib.DataResetConstants G_ALL_DATA = GraphLib.DataResetConstants.gphAllData;
		
		//Draw Mode
		public const int G_NO_ACTION = 0;
		//UPGRADE_ISSUE: (2070) Constant vbBlackness was not upgraded.
		//UPGRADE_ISSUE: (2068) DrawModeConstants object was not upgraded.
        //AIS-1159 NGONZALEZ
        public static readonly GraphLib.DrawModeConstants G_CLEAR = GraphLib.DrawModeConstants.gphClear;
		//UPGRADE_ISSUE: (2070) Constant vbNotMergePen was not upgraded.
		//UPGRADE_ISSUE: (2068) DrawModeConstants object was not upgraded.
        //AIS-1159 NGONZALEZ
        public static readonly GraphLib.DrawModeConstants G_DRAW = GraphLib.DrawModeConstants.gphDraw;
		public const int G_BLIT = 3;
		public const int G_COPY = 4;
		//UPGRADE_ISSUE: (2070) Constant vbMaskPenNot was not upgraded.
		//UPGRADE_ISSUE: (2068) DrawModeConstants object was not upgraded.
        //AIS-1159 NGONZALEZ
        public static readonly GraphLib.DrawModeConstants G_PRINT = GraphLib.DrawModeConstants.gphPrint;
		public const int G_WRITE = 6;
		
		//Print Options
		public const int G_BORDER = 2;
		
		//Pie Chart Options             '
		public const int G_NO_LINES = 1;
		public const int G_COLORED = 2;
		public const int G_PERCENTS = 4;
		
		//Bar Chart Options             '
		//Global Const G_HORIZONTAL = 1
		public const int G_STACKED = 2;
		public const int G_PERCENTAGE = 4;
		public const int G_Z_CLUSTERED = 6;
		
		//Gantt Chart Options           '
		public const int G_SPACED_BARS = 1;
		
		//Line/Polar Chart Options      '
		public const int G_SYMBOLS = 1;
		public const int G_STICKS = 2;
		public const int G_LINES = 4;
		
		//Area Chart Options            '
		public const int G_ABSOLUTE = 1;
		public const int G_PERCENT = 2;
		
		//HLC Chart Options             '
		public const int G_NO_CLOSE = 1;
		public const int G_NO_HIGH_LOW = 2;
		
		//Constantes de Gráfica
		public static readonly GraphLib.FontStyleConstants G_STYLE_DEFAULT = GraphLib.FontStyleConstants.gphDefault;
		public const int G_STYLE_ITALIC = 1;
		public const int G_STYLE_BOLD = 2;
		public const int G_STYLE_BOLDITALIC = 3;
		public const int G_STYLE_UNDERLINED = 4;
		public const int G_STYLE_UNDERITALIC = 5;
		public const int G_STYLE_UNDERBOLD = 6;
		public const int G_STYLE_UNDERBOLDITALIC = 7;
		
		public static readonly GraphLib.FontUseConstants G_USE_DEFAULT = GraphLib.FontUseConstants.gphGraphTitle;
		public static readonly GraphLib.FontUseConstants G_USE_OTHER = GraphLib.FontUseConstants.gphOtherTitles;
		public const int G_USE_LABEL = 2;
		public static readonly GraphLib.FontUseConstants G_USE_LEGEND = GraphLib.FontUseConstants.gphLegend;
		public static readonly GraphLib.FontUseConstants G_USE_ALL = GraphLib.FontUseConstants.gphAllText;
		
		public const int G_FONT_DEFAULT = 0;
		public static readonly GraphLib.FontFamilyConstants G_FONT_SWISS = GraphLib.FontFamilyConstants.gphSwiss;
		public const int G_FONT_MODERN = 2;
		
		//---------------------------------------
		//Key Status Control
		//---------------------------------------
		//Style
		public const int KEYSTAT_CAPSLOCK = 0;
		public const int KEYSTAT_NUMLOCK = 1;
		public const int KEYSTAT_INSERT = 2;
		public const int KEYSTAT_SCROLLLOCK = 3;
		
		
		//---------------------------------------
		//MCI Control (Multimedia)
		//---------------------------------------
		//NOTE:
		//Please use the updated Multimedia constants
		//in the WINMMSYS.TXT file from the \VB\WINAPI
		//subdirectory.
		
		//Mode Property
		//Global Const MCI_MODE_NOT_OPEN = 11
		//Global Const MCI_MODE_STOP = 12
		//Global Const MCI_MODE_PLAY = 13
		//Global Const MCI_MODE_RECORD = 14
		//Global Const MCI_MODE_SEEK = 15
		//Global Const MCI_MODE_PAUSE = 16
		//Global Const MCI_MODE_READY = 17
		
		//NotifyValue Property
		//Global Const MCI_NOTIFY_SUCCESSFUL = 1
		//Global Const MCI_NOTIFY_SUPERSEDED = 2
		//Global Const MCI_ABORTED = 4
		//Global Const MCI_FAILURE = 8
		
		//Orientation Property
		//Global Const MCI_ORIENT_HORZ = 0
		//Global Const MCI_ORIENT_VERT = 1
		
		//RecordMode Porperty
		//Global Const MCI_RECORD_INSERT = 0
		//Global Const MCI_RECORD_OVERWRITE = 1
		
		//TimeFormat Property
		//Global Const MCI_FORMAT_MILLISECONDS = 0
		//Global Const MCI_FORMAT_HMS = 1
		//Global Const MCI_FORMAT_MSF = 2
		//Global Const MCI_FORMAT_FRAMES = 3
		//Global Const MCI_FORMAT_SMPTE_24 = 4
		//Global Const MCI_FORMAT_SMPTE_25 = 5
		//Global Const MCI_FORMAT_SMPTE_30 = 6
		//Global Const MCI_FORMAT_SMPTE_30DROP = 7
		//Global Const MCI_FORMAT_BYTES = 8
		//Global Const MCI_FORMAT_SAMPLES = 9
		//Global Const MCI_FORMAT_TMSF = 10
		
		
		//---------------------------------------
		//Spin Button
		//---------------------------------------
		//SpinOrientation
		public const int SPIN_VERTICAL = 0;
		public const int SPIN_HORIZONTAL = 1;
		
		
		//---------------------------------------
		//Masked Edit Control
		//---------------------------------------
		//ClipMode
		public const int ME_INCLIT = 0;
		public const int ME_EXCLIT = 1;
		
		
		//---------------------------------------
		//Comm Control
		//---------------------------------------
		//Handshaking
		public const int MSCOMM_HANDSHAKE_NONE = 0;
		public const int MSCOMM_HANDSHAKE_XONXOFF = 1;
		public const int MSCOMM_HANDSHAKE_RTS = 2;
		public const int MSCOMM_HANDSHAKE_RTSXONXOFF = 3;
		
		//Event constants
		public const int MSCOMM_EV_SEND = 1;
		public const int MSCOMM_EV_RECEIVE = 2;
		public const int MSCOMM_EV_CTS = 3;
		public const int MSCOMM_EV_DSR = 4;
		public const int MSCOMM_EV_CD = 5;
		public const int MSCOMM_EV_RING = 6;
		public const int MSCOMM_EV_EOF = 7;
		
		//Error code constants
		public const int MSCOMM_ER_BREAK = 1001;
		public const int MSCOMM_ER_CTSTO = 1002;
		public const int MSCOMM_ER_DSRTO = 1003;
		public const int MSCOMM_ER_FRAME = 1004;
		public const int MSCOMM_ER_OVERRUN = 1006;
		public const int MSCOMM_ER_CDTO = 1007;
		public const int MSCOMM_ER_RXOVER = 1008;
		public const int MSCOMM_ER_RXPARITY = 1009;
		public const int MSCOMM_ER_TXFULL = 1010;
		
		
		//---------------------------------------
		// MAPI SESSION CONTROL CONSTANTS
		//---------------------------------------
		//Action
		public const int SESSION_SIGNON = 1;
		public const int SESSION_SIGNOFF = 2;
		
		
		//---------------------------------------
		// MAPI MESSAGE CONTROL CONSTANTS
		//---------------------------------------
		//Action
		public const int MESSAGE_FETCH = 1; // Load all messages from message store
		public const int MESSAGE_SENDDLG = 2; // Send mail bring up default mapi dialog
		public const int MESSAGE_SEND = 3; // Send mail without default mapi dialog
		public const int MESSAGE_SAVEMSG = 4; // Save message in the compose buffer
		public const int MESSAGE_COPY = 5; // Copy current message to compose buffer
		public const int MESSAGE_COMPOSE = 6; // Initialize compose buffer (previous
		// data is lost
		public const int MESSAGE_REPLY = 7; // Fill Compose buffer as REPLY
		public const int MESSAGE_REPLYALL = 8; // Fill Compose buffer as REPLY ALL
		public const int MESSAGE_FORWARD = 9; // Fill Compose buffer as FORWARD
		public const int MESSAGE_DELETE = 10; // Delete current message
		public const int MESSAGE_SHOWADBOOK = 11; // Show Address book
		public const int MESSAGE_SHOWDETAILS = 12; // Show details of the current recipient
		public const int MESSAGE_RESOLVENAME = 13; // Resolve the display name of the recipient
		public const int RECIPIENT_DELETE = 14; // Fill Compose buffer as FORWARD
		public const int ATTACHMENT_DELETE = 15; // Delete current message
		
		
		//---------------------------------------
		//  ERROR CONSTANT DECLARATIONS (MAPI CONTROLS)
		//---------------------------------------
		public const int SUCCESS_SUCCESS = 32000;
		public const int MAPI_USER_ABORT = 32001;
		public const int MAPI_E_FAILURE = 32002;
		public const int MAPI_E_LOGIN_FAILURE = 32003;
		public const int MAPI_E_DISK_FULL = 32004;
		public const int MAPI_E_INSUFFICIENT_MEMORY = 32005;
		public const int MAPI_E_ACCESS_DENIED = 32006;
		public const int MAPI_E_TOO_MANY_SESSIONS = 32008;
		public const int MAPI_E_TOO_MANY_FILES = 32009;
		public const int MAPI_E_TOO_MANY_RECIPIENTS = 32010;
		public const int MAPI_E_ATTACHMENT_NOT_FOUND = 32011;
		public const int MAPI_E_ATTACHMENT_OPEN_FAILURE = 32012;
		public const int MAPI_E_ATTACHMENT_WRITE_FAILURE = 32013;
		public const int MAPI_E_UNKNOWN_RECIPIENT = 32014;
		public const int MAPI_E_BAD_RECIPTYPE = 32015;
		public const int MAPI_E_NO_MESSAGES = 32016;
		public const int MAPI_E_INVALID_MESSAGE = 32017;
		public const int MAPI_E_TEXT_TOO_LARGE = 32018;
		public const int MAPI_E_INVALID_SESSION = 32019;
		public const int MAPI_E_TYPE_NOT_SUPPORTED = 32020;
		public const int MAPI_E_AMBIGUOUS_RECIPIENT = 32021;
		public const int MAPI_E_MESSAGE_IN_USE = 32022;
		public const int MAPI_E_NETWORK_FAILURE = 32023;
		public const int MAPI_E_INVALID_EDITFIELDS = 32024;
		public const int MAPI_E_INVALID_RECIPS = 32025;
		public const int MAPI_E_NOT_SUPPORTED = 32026;
		
		public const int CONTROL_E_SESSION_EXISTS = 32050;
		public const int CONTROL_E_INVALID_BUFFER = 32051;
		public const int CONTROL_E_INVALID_READ_BUFFER_ACTION = 32052;
		public const int CONTROL_E_NO_SESSION = 32053;
		public const int CONTROL_E_INVALID_RECIPIENT = 32054;
		public const int CONTROL_E_INVALID_COMPOSE_BUFFER_ACTION = 32055;
		public const int CONTROL_E_FAILURE = 32056;
		public const int CONTROL_E_NO_RECIPIENTS = 32057;
		public const int CONTROL_E_NO_ATTACHMENTS = 32058;
		
		
		//---------------------------------------
		//  MISCELLANEOUS GLOBAL CONSTANT DECLARATIONS (MAPI CONTROLS)
		//---------------------------------------
		public const int RECIPTYPE_ORIG = 0;
		public const int RECIPTYPE_TO = 1;
		public const int RECIPTYPE_CC = 2;
		public const int RECIPTYPE_BCC = 3;
		
		public const int ATTACHTYPE_DATA = 0;
		public const int ATTACHTYPE_EOLE = 1;
		public const int ATTACHTYPE_SOLE = 2;
		
		
		//-------------------------------------------------
		//  Outline
		//-------------------------------------------------
		// PictureType
		public const int MSOUTLINE_PICTURE_CLOSED = 0;
		public const int MSOUTLINE_PICTURE_OPEN = 1;
		public const int MSOUTLINE_PICTURE_LEAF = 2;
		
		//Outline Control Error Constants
		public const int MSOUTLINE_BADPICFORMAT = 32000;
		public const int MSOUTLINE_BADINDENTATION = 32001;
		public const int MSOUTLINE_MEM = 32002;
		public const int MSOUTLINE_PARENTNOTEXPANDED = 32003;
		
		//Declare constants used by GetWindow
		public const int GW_HWNDFIRST = 0;
		public const int GW_HWNDNEXT = 2;
		
		//----------------------------------------------------------------------------
		//                           DECLARACION DE API´S
		//----------------------------------------------------------------------------
		//AIS-1182 NGONZALEZ
		
		
		
		//Constantes de SDK
		public const int SW_SHOW = 5;
		public const int WM_CLOSE = 0x10;
		public const int WM_USER = 0x400;
		public static readonly int LB_FINDSTRING = (WM_USER + 16);
		public static readonly int LB_ERR = (-1);
		public const int TODOS_ITEMS = -1;
		
		public const int MB_SINOCANCELAR = 0;
		public const int MB_SINO = 1;
		public const int MB_ACEPTARCANCELAR = 2;
		public const int MB_ACEPTAR = 3;
		
		public const int MB_ALTO = 1;
		public const int MB_INTER = 2;
		public const int MB_EXCLA = 0;
		public const int MB_INFOR = 3;
		
		public const int MSGSI = 1;
		public const int MSGNO = 2;
		public const int MSGACEPTAR = 1;
		public const int MSGCANCELAR = 3;
		
		
		public struct MemoryStatus
		{
			public int dwLength;
			public int dwMemoryLoad;
			public int dwTotalPhys;
			public int dwAvailPhys;
			public int dwTotalPageFile;
			public int dwAvailPageFile;
			public int dwTotalVirtual;
			public int dwAvailVirtual;
		}
		
		public struct SystemInfo
		{
			public int dwOemId;
			public int dwPageSize;
			public int lpMinimumApplicationAddress;
			public int lpMaximumApplicationAddress;
			public int dwActiveProcessorMask;
			public int dwNumberOfProcessors;
			public int dwProcessorType;
			public int dwAllocationGranularity;
			public int dwReserved;
		}
	}
}