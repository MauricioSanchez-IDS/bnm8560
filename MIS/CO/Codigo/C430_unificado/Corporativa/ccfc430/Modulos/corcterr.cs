using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class CORCTERR
	{
	
		//****************************************************************************
		//* Descripci�n: Modulo de constantes para el manejo de errores dentro de la *
		//*              Aplicaci�n                                                  *
		//*                                                                          *
		//****************************************************************************
		
		
		//----------------------------------------------------------------------------
		//                     Constantes Num�ricas de Errores Cr�ticos
		//Numeraci�n :  del 001 al 300
		//----------------------------------------------------------------------------
		
		
		//----------------------------------------------------------------------------
		//                   Constantes Num�ricas de Errores No Cr�ticos
		//Numeraci�n :  del 301 al 600
		//----------------------------------------------------------------------------
		
		
		//----------------------------------------------------------------------------
		//                  Constantes Num�ricas de Errores Predecibles
		//Numeraci�n :  del 601 al 999
		//----------------------------------------------------------------------------
		
		//----------------------------------------------------------------------------
		//                     Constantes Num�ricas de Errores
		//----------------------------------------------------------------------------
		public const int INT_DISCO_LLENO = 61;
		public const int INT_PERMISO_NEG = 70;
		public const int INT_UNIDAD_NOLIS = 71;
		public const int INT_ERR_ACCPATHFILE = 75;
	}
}