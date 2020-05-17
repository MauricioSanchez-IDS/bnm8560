using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class CORBD
	{
	
		
		//----------------------------------------------------------------------------
		//             CONSTANTES PARA LA BASE DE DATOS EN SYBASE
		//----------------------------------------------------------------------------
		
		//Constantes que identifican el nombre de las Tablas
		public const string DB_SYB_COR = "MTCCOR01";
		public const string DB_SYB_EMP = "MTCEMP01";
		public const string DB_SYB_EJE = "MTCEJE01";
		public const string DB_SYB_DIV = "MTCDIV01";
		public const string DB_SYB_REG = "MTCREG01";
		public const string DB_SYB_EJX = "MTCEJX01";
		public const string DB_SYB_PGS = "MTCPGS01";
		public const string DB_SYB_CON = "MTCCON01";
		public const string DB_SYB_USU = "MTCUSU01";
		//Global Const DB_SYB_GRU = "MTCGRU01"
		public const string DB_SYB_FMT = "MTCFMT01";
		public const string DB_SYB_THS = "MTCTHS01";
		public const string DB_SYB_HIS = "MTCHIS01";
		public const string DB_SYB_HIH = "MTCHIH01";
		public const string DB_SYB_PLA = "MTCPLA01";
		public const string DB_SYB_ARA = "MTCARA01";
		public const string DB_SYB_SGO = "MTCSEG01";
		public const string DB_SYB_ACD = "MTCACT01";
		public const string DB_SYB_NEG = "MTCNEG01";
		public const string DB_SYB_ACL = "MTCACL01";
		public const string DB_SYB_CMA = "MTCCMA01";
		public const string DB_SYB_BIT = "MTCBIT01";
		public const string DB_SYB_MSG = "MTCMSG01";
		public const string DB_SYB_INT = "MTCINT01";
		public const string DB_SYB_SYS = "sysusers";
		public const string DB_SYB_LOC = "MTCLOC01";
		public const string DB_SYB_MES = "MTCMES01";
		public const string DB_SYS_CAM = "MTCCAM01";
		public const string DB_SYS_COST = "MTCCOST01";
		public const string DB_SYB_BRP = "MTCBRP01";
		public const string DB_SYB_NRP = "MTCNRP01";
		public const string DB_SYB_UNI = "MTCUNI01";
		public const string DB_SYB_NIV = "MTCNIV01";
		public const string DB_SYB_EST = "MTCEST01";
		
		//Constantes de las Longitudes de los campos de Grupos Corporativos
		public const int LNG_COR_NOM = 45;
		public const int LNG_COR_CALLE = 35;
		public const int LNG_COR_COL = 25;
		public const int LNG_COR_CP = 5;
		public const int LNG_COR_CIU = 25;
		public const int LNG_COR_POB = 25;
		public const int LNG_COR_EDO = 15;
		
		//Constantes de las Longitudes de los campos de THS
		public const int LNG_THS_NOM = 26;
		public const int LNG_THS_CALLE = 35;
		public const int LNG_THS_COL = 25;
		public const int LNG_THS_POB = 25;
		public const int LNG_THS_ZP = 1;
		public const int LNG_THS_EJX = 16;
		
		//Constantes de las Longitudes de los campos de Empresas
		public const int LNG_EMP_CVE = 5;
		public const int LNG_EMP_NOM = 45;
		public const int LNG_EMP_NOMGRABA = 24;
		public const int LNG_EMP_RFC = 13;
		public const int LNG_EMP_PRINCACC = 35;
		public const int LNG_EMP_CONMU = 15;
		public const int LNG_EMP_FISCALCALLE = 35;
		public const int LNG_EMP_FISCALCOL = 25;
		public const int LNG_EMP_FISCALCP = 5;
		public const int LNG_EMP_FISCALCIU = 25;
		public const int LNG_EMP_FISCALPOB = 25;
		public const int LNG_EMP_FISCALEDO = 25;
		public const int LNG_EMP_ENVIOCALLE = 35;
		public const int LNG_EMP_ENVIOCOL = 25;
		public const int LNG_EMP_ENVIOCIU = 25;
		public const int LNG_EMP_ENVIOPOB = 25;
		public const int LNG_EMP_ENVIOEDO = 15;
		public const int LNG_EMP_NOMR1 = 35;
		public const int LNG_EMP_PUER1 = 15;
		public const int LNG_EMP_TEL1 = 15;
		public const int LNG_EMP_EXT1 = 8;
		public const int LNG_EMP_FAX1 = 15;
		public const int LNG_EMP_NOMR2 = 35;
		public const int LNG_EMP_PUER2 = 15;
		public const int LNG_EMP_TEL2 = 15;
		public const int LNG_EMP_EXT2 = 8;
		public const int LNG_EMP_FAX2 = 15;
		public const int LNG_EMP_NOMR3 = 35;
		public const int LNG_EMP_PUER3 = 15;
		public const int LNG_EMP_TEL3 = 15;
		public const int LNG_EMP_EXT3 = 8;
		public const int LNG_EMP_FAX3 = 15;
		public const int LNG_EMP_STA = 1;
		public const int LNG_EMP_TPGO = 1;
		
		//Constantes de las Longitudes de los campos de Ejecutivos de la Empresa
		public const int LNG_EJE_NOM = 45;
		public const int LNG_EJE_CALLE = 35;
		public const int LNG_EJE_COL = 25;
		public const int LNG_EJE_CP = 5;
		public const int LNG_EJE_CIU = 25;
		public const int LNG_EJE_POB = 25;
		public const int LNG_EJE_EDO = 15;
		public const int LNG_EJE_CC = 18;
		public const int LNG_EJE_RFC = 15;
		public const int LNG_EJE_TDO = 15;
		public const int LNG_EJE_TOF = 15;
		public const int LNG_EJE_TFA = 15;
		public const int LNG_EJE_EXT = 8;
		public const int LNG_EJE_ZP = 18;
		public const int LNG_EJE_STAT = 1;
		public const int LNG_EJE_NOMGRA = 26;
		public const int LNG_EJE_CTA = 16;
		public const int LNG_EJE_STATUS = 1; //Longitud del Status
		public const int LNG_EMP_TENV = 1; //Longitud del Tipo de Envio
		
		//Constantes de las Longitudes de los campos de Ejecutivos Banamex
		public const int LNG_EJX_NOM = 45;
		public const int LNG_EJX_CALLE = 35;
		public const int LNG_EJX_COL = 25;
		public const int LNG_EJX_CP = 5;
		public const int LNG_EJX_CIU = 25;
		public const int LNG_EJX_POB = 25;
		public const int LNG_EJX_EDO = 15;
		public const int LNG_EJX_PTO = 15;
		public const int LNG_EJX_TEL = 15;
		public const int LNG_EJX_EXT = 8;
		public const int LNG_EJX_FAX = 15;
		
		//Constantes de las Longitudes de los campos de la Tabla de Cambios Masivos
		public const int LNG_CMA_CALLE = 35;
		public const int LNG_CMA_COL = 25;
		public const int LNG_CMA_CP = 5;
		public const int LNG_CMA_CIU = 25;
		public const int LNG_CMA_POB = 25;
		public const int LNG_CMA_EDO = 15;
		
		//Constantes de las Longitudes de los campos del THS
		public const int LNG_THS_NOMBRE = 26;
		
		//Constantes de las Longitudes de los campos de Divisiones
		public const int LNG_DIV_DESC = 25;
		//Constantes de las Longitudes de los campos de Regiones
		public const int LNG_REG_DESC = 25;
		
		//Constantes de las Longitudes de los campos de la Tabla de Leyendas
		public const int LNG_MSG_FORMA = 8;
		public const int LNG_MSG_RENGLON = 240;
		
		public const int LNG_DES_SGO = 30;
		
		//Constantes de las Longitudes de los campos del catálogo de usuarios
		public const int LEN_USU_CVE = 8;
		public const int LEN_USU_NOM = 20;
		public const int LEN_USU_PAT = 20;
		public const int LEN_USU_MAT = 20;
		public const int LEN_USU_PER = 8;
		
		//Constantes de las Longitudes de los campos del catálogo de grupos
		public const int LEN_GRU_CVE = 3;
		public const int LEN_GRU_DES = 20;
		public const int LEN_GRU_NIV = 2;
		public const int LEN_GRU_ALT = 2;
		public const int LEN_GRU_BAJ = 2;
		public const int LEN_GRU_CAM = 2;
		public const int LEN_GRU_CON = 2;
		
		//Constantes de las Longitudes de la descripción del banco
		public const int LEN_BAN_DES = 25;
		
		//Constantes de las Longitudes de los campos de Parámetros Generales
		public const int LEN_PAR_EMP = 50;
		public const int LEN_PAR_PATH = 50;
		public const int LEN_PAR_THS = 8;
		public const int LEN_PAR_PLA = 8;
		public const int LEN_PAR_HIS = 8;
		public const int LEN_PAR_ARA = 8;
		public const int LEN_PAR_SGO = 8;
		public const int LEN_PAR_NEG = 8;
		public const int LEN_PAR_ACT = 8;
		public const int LEN_PAR_ACL = 8;
		
		//Constantes de las Longitudes de los campos del catálogo del Formato de las archivos del S111
		public const int LEN_FMT_ARC = 8;
		public const int LEN_FMT_MNE = 30;
		public const int LEN_FMT_DES = 30;
		public const int LEN_FMT_TIP = 13;
		
		//Constantes para las Longitudes de los campos de la Tabla de Aclaraciones
		public const int LEN_ACL_STA = 1;
		
		//Constantes para las Longitudes de los campos de la Tabla de Bitácora
		public const int LEN_BIT_DESC = 30;
		
		//----------------------------------------------------------------------------
		//             CONSTANTES PARA LA BASE DE DATOS EN BTRIEVE
		//----------------------------------------------------------------------------
		
		public const string DB_BTR_INI = "DATOSALT.INI";
		public const string DB_BTR_ALT = "DATOSALT.DTA";
		public const string DB_BTR_RES = "RESALTA.DTA";
		public const string DB_BTR_CAM = "DATOSCAM.DTA";
		public const string DB_BTR_CERR = "CATERROR.DTA";
		
		//Constantes de las Longitudes del Archivo de Resultados (RESALTA.DTA)
		public const int INT_LON_FOLIO = 8;
		public const int INT_LON_NCTA = 16;
		public const int INT_LON_STATUS = 2;
		public const int INT_LON_ERROR = 150;
		
		//Constantes de las Longitudes del Archivo de Altas (DATOSALT.DTA)
		public const int INT_LON_PREFBCO = 6;
		public const int INT_LON_SERIE = 10;
		
		//Constantes de las Longitudes del Archivo de Catálogo de Errores (CATERROR.DTA)
		public const int INT_LON_DESCR = 60;
		
		//Constante de la longitud de la situacion de la cuenta deTHS
		public const int LEN_THS_CTA = 1;
		
		//Constante de la longitud del dia de corte de parametros generales
		public const int LEN_PGS_COR = 2;
		
		//Para el manejo de los tiempos de respuesta de la BD
		public const int INT_TIMEOUT_MODI = 5;
		public const int INT_TIMEOUT_DEFACTO = 30;
		
		//Constantes para el envio al tandem por medio del rut
		public const string PROCESO_ALTA = "001";
		public const string PROCESO_ALTA_S016 = "016";
		public const string TIPO_ALTA = "01";
		public const string TIPO_TRAMITE = "01";
		public const string TIPO_TRANSACCION = "5181";
		public const string TIPO_ORIGEN = "E";
		public const string PROCESO_CONSULTA = "002";
		public const string TRANSACCION_CONSULTA = "3377";
	}
}