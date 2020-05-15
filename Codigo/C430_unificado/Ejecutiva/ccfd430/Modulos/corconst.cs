using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class CORCONST
	{
	
		//---------------------------------------------------------------------------
		//                         DECLARACION DE CONSTANTES
		//---------------------------------------------------------------------------
		//Constantes para control de Sentencias SQL
		public const int OK = 0;
		public const int NO = -3;
		
		//Constantes para la Identificación de una Alta,de una Baja y de un Cambio
		public const string TAG_ALTA = "A";
		public const string TAG_CONSULTA = "B";
		public const string TAG_CAMBIO = "C";
		public const string TAG_BAJA = "J";
		public const string TAG_GRAFICA = "GRAF";
		public const string TAG_CATALOGO = "CAT";
		public const string TAG_CONSULTAS111 = "B";
		public const string SPC_TRES = "   ";
		
		//Uso de Visual Basic Gráficas
		public static readonly GraphLib.GraphTypeConstants INT_PAS_DOS_DIM = GraphLib.GraphTypeConstants.gphPie2D;
		public static readonly GraphLib.GraphTypeConstants INT_PAS_TRES_DIM = GraphLib.GraphTypeConstants.gphPie3D;
		public static readonly GraphLib.GraphTypeConstants INT_BAR_DOS_DIM = GraphLib.GraphTypeConstants.gphBar2D;
		public static readonly GraphLib.GraphTypeConstants INT_BAR_TRES_DIM = GraphLib.GraphTypeConstants.gphBar3D;
		//UPGRADE_ISSUE: (2070) Constant vbNotMergePen was not upgraded.
		//UPGRADE_ISSUE: (2068) DrawModeConstants object was not upgraded.
        //AIS-1159 NGONZALEZ
        public static readonly GraphLib.DrawModeConstants INT_MODO_RED = GraphLib.DrawModeConstants.gphDraw;
		
		//globales para la detección de errores
		public const int INT_NO_APLICACION = 53;
		public const int INT_NO_PATH = 76;
		public const int INT_NO_MEMORIA = 7;
		
		//Constantes para la Exportacion de Archivos en relación a la forma activa
		public const int INT_ACT_CEJ = 1;
		public const int INT_ACT_CGR = 2;
		public const int INT_ACT_ANG = 3;
		public const int INT_ACT_DAT = 4;
		public const int INT_ACT_DEJ = 5;
		public const int INT_ACT_EMA = 6;
		public const int INT_ACT_ENV = 7;
		public const int INT_ACT_MOV = 8;
		public const int INT_ACT_REN = 9;
		
		//Identifican los Sectores ó Subactividades
		public const string STR_SEC_IND = "01 Industrial";
		public const string STR_SEC_CMR = "02 Comercial";
		public const string STR_SEC_SER = "03 Servicios";
		public const string STR_SEC_COM = "04 Financiero";
		public const string STR_SEC_TRA = "05 Sector Público";
		public const string STR_SEC_FIN = "06 Gobierno Federal";
		public const string STR_SEC_TNF = "07 Gobierno Estatal y Municipal";
		public const string STR_SEC_OTR = "08 Otros";
		
		//Constante para la comunicación a Excel
		public const string TOPIC = "Excel|System";
		
		//Constantes de Errores para DDE
		public const int INT_NO_APLICACION_DDE = 282;
		public const int INT_TIEMPO_TERM = 286;
		public const int INT_LLAMADA_ILEGAL = 5;
		
		//Maximo numero de niveles de acceso del sistema
		public const int MAX_NIVELES = 41;
		
		//Constantes para definir los niveles de la bitacora
		public const int NIV_ESP = 0;
		public const int NIV_FOR = 1;
		public const int NIV_PAR = 1;
		public const int NIV_INTD = 2;
		public const int NIV_LIM = 3;
		public const int NIV_SEG = 4;
		public const int NIV_USU = 5;
		public const int NIV_GRU = 6;
		public const int NIV_BCO = 7;
		public const int NIV_OPE = 8;
		public const int NIV_TRR = 9;
		public const int NIV_DEP = 10;
		public const int NIV_CAT = 11;
		public const int NIV_COR = 12;
		public const int NIV_EMP = 13;
		public const int NIV_EJE = 14;
		public const int NIV_BAN = 15;
		public const int NIV_DIV = 16;
		public const int NIV_REG = 17;
		public const int NIV_CTA = 18;
		public const int NIV_CON = 19;
		public const int NIV_CEJ = 20;
		public const int NIV_CEM = 21;
		public const int NIV_ANA = 22;
		public const int NIV_DET = 23;
		public const int NIV_ATR = 24;
		public const int NIV_DEJ = 25;
		public const int NIV_AFI = 26;
		public const int NIV_GER = 27;
		public const int NIV_GRA = 28;
		public const int NIV_GBI = 29;
		public const int NIV_GCO = 30;
		public const int NIV_GEM = 31;
		public const int NIV_GAC = 32;
		public const int NIV_GSI = 33;
		public const int NIV_GCR = 34;
		public const int NIV_GAN = 35;
		public const int NIV_GVE = 36;
		public const int NIV_GCM = 37;
		public const int NIV_OPC = 38;
		public const int NIV_IMP = 39;
		public const int NIV_ACL = 39;
		public const int NIV_CAP = 40;
		
		public const int NIV_CFG = 41;
		public const int NIV_EXC = 42;
		public const int NIV_TXT = 43;
		public const int NIV_DBS = 44;
		public const int NIV_CCI = 45;
		
		//menus que no estan activos
		public const int NIV_HIS = 50;
		public const int NIV_AVE = 51;
		public const int NIV_RPT = 52;
		public const int NIV_FMT = 53;
		public const int NIV_DIA = 12;
		public const int NIV_REP = 13;
		public const int NIV_CAM = 14;
		public const int NIV_ENV = 15;
		public const int NIV_MEN = 8;
		public const int NIV_TRF = 9;
		public const int NIV_INT = 10;
		
		
		
		//Constantes para el control de la Bitácora
		public const int MAX_MENUS = 8;
		public const int BIT_CONFIGURAR = 1;
		public const int BIT_INTERFASES = 2;
		public const int BIT_ARCHIVOS = 3;
		public const int BIT_CONSULTA = 4;
		public const int BIT_OPCIONES = 5;
		public const int BIT_GRAFICAS = 6;
		public const int BIT_ACLARACIONES = 7;
		public const int BIT_REPORTEADOR = 8;
		
		//Costantes de Image Man
		public const int IMM_SIN_ESCALA = 0;
		public const int IMM_PORC_MAG = 21;
		public const int IMM_PORC_GUA = 4;
		
		//Constante para la impresion de Firmas de ImageMan
		public const int IMG_TWIPS = 1440;
		
		//Constantes para el acceso al sistema
		public const string ADM_USU_CVE = "admon1";
		public const string STR_USUARIO = "M111";
		public const string STR_PASSWORD = "tarjetas";
		
		//Constante para buscar si la aplicacion ya está activa
		public const string APLPATH = "CORBNX32.EXE";
		
		//Columnas
		public const int FIRST_COL = 1;
		public const int SECOND_COL = 2;
		public const int THIRD_COL = 3;
		public const int FOURTH_COL = 4;
		public const int FIFTH_COL = 5;
		public const int SIXTH_COL = 6;
		public const int SEVENTH_COL = 7;
		public const int EIGTH_COL = 8;
		public const int NINETH_COL = 9;
		public const int TEN_COL = 10;
		public const int ELEVEN_COL = 11;
		public const int TWELVE_COL = 12;
		public const int THIRTEEN_COL = 13;
		
		//constante de modificacion del comdrive
		public const string MODIFICA_EMPRESA_MASIVOS = "5199";
		public const string MODIFICA_NOMBRE_EN_LINEA = "5330";
		public const string MODIFICA_CREDITO_EN_LINEA = "316";


        //public const string MODIFICA_CREDITO_EN_EJE = "5117";
        public const string MODIFICA_CREDITO_EN_EJE = "316";
        public const string CVE_ACCESO_MODIFICA_S111 = "004101      FIRMA";
		public const string FINALIZA_S111 = "004101      ADIOS";
		
		//Global Const CVE_ACCESO_MODIFICA_S111 = "010000HOLA" se modifico 15/09/99
		//Global Const FINALIZA_S111 = "010000FIN" se modificó 15/09/99
	}
}