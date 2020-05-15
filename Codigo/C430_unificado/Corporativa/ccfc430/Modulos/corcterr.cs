using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class CORCTERR
	{
	
		//****************************************************************************
		//* Descripción: Modulo de constantes para el manejo de errores dentro de la *
		//*              Aplicación                                                  *
		//*                                                                          *
		//****************************************************************************
		
		
		//----------------------------------------------------------------------------
		//                     Constantes Numéricas de Errores Críticos
		//Numeración :  del 001 al 300
		//----------------------------------------------------------------------------
		
		
		//----------------------------------------------------------------------------
		//                   Constantes Numéricas de Errores No Críticos
		//Numeración :  del 301 al 600
		//----------------------------------------------------------------------------
		
		
		//----------------------------------------------------------------------------
		//                  Constantes Numéricas de Errores Predecibles
		//Numeración :  del 601 al 999
		//----------------------------------------------------------------------------
		
		//----------------------------------------------------------------------------
		//                     Constantes Numéricas de Errores
		//----------------------------------------------------------------------------
		public const int INT_DISCO_LLENO = 61;
		public const int INT_PERMISO_NEG = 70;
		public const int INT_UNIDAD_NOLIS = 71;
		public const int INT_ERR_ACCPATHFILE = 75;
	}
}