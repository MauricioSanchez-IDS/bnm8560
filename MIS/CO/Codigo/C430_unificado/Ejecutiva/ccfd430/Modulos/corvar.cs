using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Runtime.InteropServices; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class CORVAR
	{
	
		//**********************************************************
		//*Estandares de Nomenclatura de variables, constantes, etc.,
		//*utilizados en el Proyecto TARJETA CORPORATIVA.
		//**********************************************************
		//
		// VARIABLES:
		//
		// El nombre de los identificadores deberá componerse de las
		// siguientes partes:
		//
		//     tipo + nombre
		//
		// Tipo: Indica las características  de la información alma-
		// cenada siendo denotada por letras minúsculas. Los tipos
		// que se utilizarán en los identificadores de las varia-
		// bles, son los siguientes:
		//
		// Letra     Tipo
		//
		//   i   Entero
		//   l       Entero largo
		//  f       Flotante
		//  d       Doble Flotante
		//        psz     Cadena de caracteres de tamaño variable
		//  sz    Cadena de caracteres de tamaño fijo
		//  b   Entero que se utiliza como variable
		//    booleana
		//
		// Para la declaración de arreglos se debe agregar a la
		//letra que define el tipo de dato de que será el arreglo,
		//las letras arr, por ejemplo, un arreglo de enteros sería
		//el siguiente:
		//
		//       iArrNombres
		//
		//  En el caso de utilizarse varibles globales, se debe a-
		//gregar igual que en el caso anterior, las letras gbl, por
		//ejemplo, una variable global de tipo cadena fija sería
		//la siguiente:
		//
		//       szgblNonmbre
		//
		//  Como se puede observar el nombre específico de la varia-
		//ble debe empezar con mayúsculas.
		//
		//CONSTANTES
		//
		//  Los nombres de las constantes deben estar compùestos de
		//sólo mayúsculas y separado por el caracter "_".como se
		//muestra en el siguiente ejemplo:
		//
		//   NOMBRE_BANCO
		//
		//**********************************************************
		
		
		//Arreglo para almacenar datos de la gráfica
		public struct DatosEmpresa
		{
			public string pszNomEmpresa;
			public int iTotalEjec;
			public static DatosEmpresa CreateInstance()
			{
					DatosEmpresa result = new DatosEmpresa();
					result.pszNomEmpresa = String.Empty;
					return result;
			}
		}
		
		//Arreglo para Gráfica de Corporativo
		public struct DatosCorpo
		{
			public string pszDescripcion;
			public int iCantidad;
			public static DatosCorpo CreateInstance()
			{
					DatosCorpo result = new DatosCorpo();
					result.pszDescripcion = String.Empty;
					return result;
			}
		}
		
		//Arreglo para el acceso a los niveles de Alta Baja Cambio y Consulta
		public struct Acceso
		{
			public int iAlta;
			public int iBaja;
			public int iCambio;
			public int iConsulta;
		}
		
		//Arreglo para los Dias Festivos
		public struct DiasFestivos
		{
			public int iDia;
			public int iMes;
		}
		
		//Tipo de Formatos
		public struct tyFormatos
		{
			public string pszCampo;
			public string pszLong;
			public string pszDecimal;
			public string pszFormato;
			public static tyFormatos CreateInstance()
			{
					tyFormatos result = new tyFormatos();
					result.pszCampo = String.Empty;
					result.pszLong = String.Empty;
					result.pszDecimal = String.Empty;
					result.pszFormato = String.Empty;
					return result;
			}
		}
		
		//Arreglo para almacenar datos de la gráfica
		public struct DatEmpresa
		{
			public int lNumEmpresa;
			public string pszNomEmpresa;
			public int lCredTotal;
			public int iTotalEjec;
			public string pszNomDivision;
			public int iTotalSect;
			public string pszMesInicio;
			public static DatEmpresa CreateInstance()
			{
					DatEmpresa result = new DatEmpresa();
					result.pszNomEmpresa = String.Empty;
					result.pszNomDivision = String.Empty;
					result.pszMesInicio = String.Empty;
					return result;
			}
		}
		
		//Registro para el Task List
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
		public struct tagTASKSENTRY
		{
			public int dwSize;
			public int hTask;
			public int hTaskParent;
			public int hInst;
			public int hModule;
			public int wSS;
			public int wSP;
			public int wStackTop;
			public int wStackMinimum;
			public int wStackBottom;
			public int wcEvents;
			public int hQueue;
			public int wPSPOffset;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr,SizeConst=10)] public string szModule;
			public int hNext;
		}
		
		//arreglo para la grafica de rentabilidad
		public struct DatRentabilidad
		{
			public int lNoEmpresa;
			public string sNomEmpresa;
			public string sGrupo;
			public double dFactura;
			public double dCartera;
			public double dRenTot;
			public string smes;
			public static DatRentabilidad CreateInstance()
			{
					DatRentabilidad result = new DatRentabilidad();
					result.sNomEmpresa = String.Empty;
					result.sGrupo = String.Empty;
					result.smes = String.Empty;
					return result;
			}
		}
		
		//arreglo para el acceso de nivel
		public struct AccesoNivel
		{
			public string sProceso;
			public bool bAltas;
			public bool bConsultas;
			public bool bBajas;
			public bool bCambios;
			public static AccesoNivel CreateInstance()
			{
					AccesoNivel result = new AccesoNivel();
					result.sProceso = String.Empty;
					return result;
			}
		}
		
		public struct AccesoOpciones
		{
			public string sOpcion;
			public bool bAltas;
			public bool bConsultas;
			public bool bBajas;
			public bool bCambios;
			public static AccesoOpciones CreateInstance()
			{
					AccesoOpciones result = new AccesoOpciones();
					result.sOpcion = String.Empty;
					return result;
			}
		}
		
		
		
		//---------------------------------------------------------------------------
		//                         DECLARACION DE VARIABLES
		//---------------------------------------------------------------------------
		static public int bgblInteg = 0;
		static public int bgblExpoCam = 0;
		static public int bgblCieMens = 0;
		static public int igblMsgboxRes = 0;
		
		//Variable para Obtener los numeros de error en cualquier operación
		static public int igblErr = 0;
		
		//Variables para Conexión a la Base de Datos
		static public int hgblConexion = 0;
		static public string pszgblConexion = String.Empty;
		static public string pszgblServer = String.Empty;
		static public string pszgblDB = String.Empty;
		static public string pszgblsql = String.Empty;
		static public int igblRetorna = 0; //Recibe el estado de regreso de una función
		
		static public int hgblConexion2 = 0;
		static public string pszgblSql2 = String.Empty;
		
		//Variables para las firmas
		static public int igblPicture = 0;
		
		//Variables globales para el catálogo de Division Regional
		static public int igblDivCve = 0;
		static public int igblTempDivCve = 0;
		static public FixedLengthString szgblDivDesc = new FixedLengthString(CORBD.LNG_DIV_DESC);
		static public int bgblDivActiva = 0;
		static public string pszgblDivCve = String.Empty;
		static public string pszgblDivDesc = String.Empty;
		
		//Variables globales para el catálogo de Ejecutivos Banamex
		static public int lgblEjxCve = 0;
		static public string pszgblEjxDesc = String.Empty;
		static public int lgblTempEjxCve = 0;
		static public int igblTempEjxDiv = 0;
		static public FixedLengthString szgblEjxDesc = new FixedLengthString(CORBD.LNG_EJX_NOM);
		static public int bgblEjxActiva = 0;
		static public int bgblModFirma = 0;
		static public int bgblModFir1 = 0;
		static public int bgblModFir2 = 0;
		static public int bgblModFir3 = 0;
		static public int bgblFirma = 0;
		static public int bgblAbreFir = 0;
		
		//Variables globales para el catálogo de Regiones Geográficas
		static public int igblRegCve = 0;
		static public string pszgblRegDesc = String.Empty;
		static public int igblTempRegCve = 0;
		static public int bgblRegActiva = 0;
		
		//Variables para la seguridad del sistema
		static public int bgblAdmin = 0;
		static public string szgblUsuNom = String.Empty;
		static public string szgblUsuClave = String.Empty;
		//UPGRADE_ISSUE: (2068) DrawModeConstants object was not upgraded.
        //AIS-1159 NGONZALEZ
        static public int igblAccion = 0;
		
		//Variable para almacenar el Banco con el cual se va a trabajar
		static public int igblBanco = 0;
		//***** INICIO CODIGO NUEVO FSWBMX *****
		static public int igblPref = 0;
		//***** FIN DE CODIGO NUEVO FSWBMX *****
		
		//Variable para almacenar el Prefijo del Banco con el cual se va a trabajar
		static public int igblPrefijo = 0;
		
		//Variable para almacenar el valor del IVA
		static public double dgblIva = 0;
		
		//Variables globales al catálogo de Empresas
		static public int lgblNumEmpresa = 0;
		static public int igblNumGrupo = 0;
		static public string pszgblNomEmpresA = String.Empty;
		static public string pszgblNomGrupo = String.Empty;
		static public int bgblFirma1 = 0;
		static public int bgblFirma2 = 0;
		static public int bgblFirma3 = 0;
		
		//Variables globales al catálogo de Ejecutivos de Empresas
		static public int igblEjeCve = 0;
		static public FixedLengthString szgblEjeDesc = new FixedLengthString(CORBD.LNG_EJE_NOM);
		static public string pszgblEmpDesc = String.Empty;
		static public int lgblEmpCve = 0;
		static public int bgblEjeActiva = 0;
		static public FixedLengthString szgblRegDesc = new FixedLengthString(CORBD.LNG_REG_DESC);
		static public int igblMesCorte = 0;
		static public int igblAñoCorte = 0;
		static public int igblEjeNum = 0;
		static public int igblFolio = 0;
		static public int bgblIrExiste = 0;
		static public int bgblCerrar = 0;
		static public int lgblGpoCve = 0; //**********
		
        //'*** INI:OLV NOV0304 ***
        static public string igblEjeEstatus = String.Empty;
        //'*** FIN:OLV NOV0304 ***

		//Variables para el Reporte de Empresas Afiliadas
		static public int igblCancela = 0;
		static public string pszgblMesCorte = String.Empty;
		
		//Variables para Reporte de Analisis de Consumo por Giro
		static public int lgblNumEmpresaR = 0;
		static public int igblMesDiaACG = 0;
		
		//Variables para Reporte de Detalle de Empresas Afiliadas
		static public int igblMesDiaDEA = 0;
		
		//Variables para Reporte de Detalle de Ejecutivos Banamex
		static public int lgblNumEjeBnx = 0;
		static public string pszgblLeyenda = String.Empty;
		static public int igblNumEjx = 0;
		static public int bgblValida = 0;
		static public int bgblCambio = 0;
		
		//Nos guarda fechas Temporales en Formato Serial
		static public double[] dArrMesAño = null;
		
		//Variable para almacenar la forma activa con el fin de manipular la impresión y la exportación
		static public int igblFormaActiva = 0;
		
		//Variable para almacenar el path de trabajo global obtenida de la tabla de Parámetros Generales
		static public string pszgblPath = String.Empty;
		
		//Arreglo que guarda los niveles de acceso por alta, baja, cambio, y consulta
		//AIS-1178 NGONZALEZ
		static public Acceso[] tArrNiveles;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
		
		//Variable para almacenar el nivel activa con el fin de opciones Alta,Baja,Cambio.Consulta
		static public int igblNivelActivo = 0;
		
		//Variables globales para obtener los paths necesarios para la exportación
		static public string pszgblPathMalta = String.Empty;
		static public string pszgblPathBtrieve = String.Empty;
		static public string pszgblPathFirmas = String.Empty;
		static public string pszgblPathCorpo = String.Empty;
		static public string pszgblPathRep = String.Empty;
		static public string pszgblPathCYDD = String.Empty;
		static public string pszgblPathRepEmpresas = String.Empty;
		static public string pszgblPathRepCrystal = String.Empty;
		static public string pszgblPathRepCorporativo = String.Empty;
		static public string pszgblPathComDrive = String.Empty;
		static public string pszgblPathWord = String.Empty;
		static public string pszgblPathWordDom = String.Empty;
		static public string pszgblPathWordCred = String.Empty;
		static public string pszgblPathEXCEL = String.Empty;
		
		
		//Variables utilizadas en el Módulo de Bitácora
        //AIS-1072 NGONZALEZ
		static public int[,] iArrBitacora = null;
		//AIS-1072 NGONZALEZ
        static public string[,] pszArrBitForma = null;
		
		//Variables para la Gráfica de Comparativo
		static public int lgblTempNumEmp = 0;
		static public int lgblTempNumGpo = 0;
		
		//Variables de Deteccion de Scan
		static public int bgblScanActivo = 0;
		
		//variables para el reporte de Crystal Report
		static public int iPorComp = 0;
		static public int iPorDisp = 0;
		static public int iDiaCorte = 0;
		
		
		//variables para la forma de resportes de crystal report
		static public double dgblParametroRep = 0;
		static public double dgblParametroRep1 = 0;
		
		//variables de la cancelación de envio de archivos de texto
		static public string gblCancelaEnvio = String.Empty;
		
		//variable para detectar el nombre del archivpo a convertir en formato
		static public string gblPathArchivo = String.Empty;
		
		//variable para verificar que si hubo cambios masivos en tarjetahabientes
		static public bool gblCamMasivos = false;
		
		static public int lAcceso = 0;
		
		//variables para la rentabilidad
		static public int gbllAñoMesFin = 0;
		static public int gbllAñoCorteFin = 0;
		static public int gbllAñoMesIni = 0;
		
		//arreglo para el acceso de usuarios
		//son 6 debido a que hay seis catalogos en el menu de archivos
		//UPGRADE_WARNING: (1042) Array OpcionesAcceso may need to have individual elements initialized.
		static public AccesoOpciones[] OpcionesAcceso = ArraysHelper.InitializeArray<AccesoOpciones[]>(new int[]{10});		
		static public string glstrLimCred = String.Empty;
        static public int FileNumber = 0;
	}
}