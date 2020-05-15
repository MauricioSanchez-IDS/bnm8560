using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class CORSTR
	{
	
		//****************************************************************************
		//* Descripción: Modulo de constantes para mensajes utilizados por el Sistema*
		//*              en General                                                  *
		//*                                                                          *
		//****************************************************************************
		
		
		//----------------------------------------------------------------------------
		//                       Mensajes que indican Pregunta
		//----------------------------------------------------------------------------
		public const string STR_CONF_BAJA = "¿Realmente desea dar de baja ";
		public const string STR_CANCELA_EXPORTACION = "¿Realmente desea Cancelar la Exportación...?'";
		public const string STR_CUESTIONA_INTRO = "Desea introducirla Ud. ?";
		public const string STR_CUESTIONA_OTRA_RUTA = "Desea reintentarlo con otra Ruta de Acceso ?";
		
		//----------------------------------------------------------------------------
		//                     Mensajes que indican advertencia y/o solución
		//----------------------------------------------------------------------------
		public const string STR_NO_EXIS_ELE = "No existen elementos a seleccionar";
		public const string STR_NO_SEL_ELEM = "Debe seleccionar el elemento a borrar";
		public const string STR_INT_CVE_DIV = "Debe teclear la Clave y la Descripción de la División";
		public const string STR_INT_CVE_REG = "Debe teclear la Clave y la Descripción de la Región";
		public const string STR_MSG_SOLUCION = "Consulte a Soporte Técnico";
		public const string STR_NO_CONEXION = "No se pudo realizar Conexión. Consulte a su Administrador del Sistema.";
		public const string STR_NO_DESCONEXION = "No se pudo realizar Desconexión.Consulte a su Administrador del Sistema.";
		public const string ERR_DDE_NO_APLICACION = "No se encontró el archivo de Excel";
		public const string ERR_DDE_PATH_NOT_FOUND = "Ruta de Acceso Incorrecta ";
		public const string ERR_DDE_EXT_INC = "La extensión es incorrecta";
		public const string ERR_DDE_NO_MEMORIA = "Memoria insuficiente para abrir Excel";
		public const string STR_AVISO_RECOM = "Antes de Exportar de Nuevo estabilice Excel, cerrando todos sus archivos abiertos o cerrrandolo totalmente";
		public const string ERR_DDE_EXPORTA = "Error al exportar datos, Probablemente intenta salvar el Archivo sobre uno abierto";
		public const string STR_AVISO_ORDEN = "Teclee SOLAMENTE la Ruta de Acceso a Excel";
		public const string STR_NO_APLICACION = "Archivo No Encontrado";
		public const string STR_NO_PATH = "Ruta de Acceso No Encontrada";
		public const string STR_NO_MEMORIA = "Insuficiente memoria para ejecutar Aplicación";
		public const string STR_DISCO_LLENO = "No existe espacio en Disco";
		public const string STR_PERMISO_NEG = "Acceso denegado a la Ruta correspondiente";
		public const string STR_UNIDAD_NOLIS = "Unidad de disco no Lista";
		public const string STR_ERR_ACCPATHFILE = "Error al Accesar Ruta y/o Archivo";
		public const string ERR_ERROR_DESC = "Error desconocido, Consulte a Soporte Técnico";
		public const string STR_CON_ADMIN = "Consulte a su Administrador del Sistema";
		public const string ERR_PATH_DOC = "No se encontro el docuemento de Word";
		
		//----------------------------------------------------------------------------
		//                     Mensajes que indican acción
		//----------------------------------------------------------------------------
		public const string STR_CONECTANDO_EXCEL = "Conectando a Excel...";
		public const string STR_EXPORTANDO_EXCEL = "Exportando a Excel";
		public const string STR_EXPORTANDO_TXT = "Exportando a Archivo Texto...";
		public const string STR_EXP_EXITO = "La exportación de datos se realizó con éxito";
		public const string STR_IMP_GPH = "Imprimiendo Gráfica...";
		public const string STR_LEE_BD = "Accesando la Base de Datos...";
		public const string STR_ACC_BOTON = "Click o Return en el botón <Graficar>";
		
		//----------------------------------------------------------------------------
		//                     Mensajes que indican uso general
		//----------------------------------------------------------------------------
		public const string STR_APP_TIT = "Tarjeta Ejecutiva";
		public const string STR_DDE_APL_CAPTION = "Microsoft Excel";
		public const string STR_MSG_EXP = "Nombre para Exportar";
	}
}