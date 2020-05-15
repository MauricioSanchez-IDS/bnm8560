using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsREPRenglon
	{
	
		public string CaracterRellenoS = " ";
		private int mvarLongitudI = 0; //local copy
		private string mvarContenidoS = String.Empty; //local copy
		private CRSGeneral.cteJustificado mvarJustificadoI = (CRSGeneral.cteJustificado) 0; //local copy
		private string mvarFuenteS = String.Empty; //local copy
		
		public void  Justificar()
		{
			if (LongitudI <= 0 || LongitudI == mvarContenidoS.Length)
			{
				return;
			}
			switch(JustificadoI)
			{
				case CRSGeneral.cteJustificado.cteIzquierda : 
					int tempRefParam = LongitudI; 
					ContenidoS = sfncJustificar(ContenidoS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam, ref CaracterRellenoS); 
					break;
				case CRSGeneral.cteJustificado.cteDerecha : 
					int tempRefParam2 = LongitudI; 
					ContenidoS = sfncJustificar(ContenidoS, CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam2, ref CaracterRellenoS); 
					break;
				case CRSGeneral.cteJustificado.cteCentrado : 
					int tempRefParam3 = LongitudI; 
					ContenidoS = sfncJustificar(ContenidoS, CRSGeneral.cteJustificado.cteCentrado, ref tempRefParam3, ref CaracterRellenoS); 
					break;
				default:
					int tempRefParam4 = LongitudI; 
					ContenidoS = sfncJustificar(ContenidoS, CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam4, ref CaracterRellenoS); 
					break;
			}
		}
		
		
		public string FuenteS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.FuenteS
				return mvarFuenteS;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.FuenteS = Form1
				mvarFuenteS = value;
			}
		}
		
		
		
		
		public CRSGeneral.cteJustificado JustificadoI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.JustificadoI
				return mvarJustificadoI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.JustificadoI = 5
				mvarJustificadoI = value;
			}
		}
		
		
		
		
		
		
		
		public string ContenidoS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.ContenidoS
				return mvarContenidoS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.ContenidoS = 5
				mvarContenidoS = value;
			}
		}
		
		
		
		
		
		
		public int LongitudI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.LongitudI
				return mvarLongitudI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.LongitudI = 5
				mvarLongitudI = value;
			}
		}
		
		
		
		internal string sfncJustificar( string spDato,  CRSGeneral.cteJustificado ipJustificado, ref  int ipLongitud, ref  string spCaracterRelleno)
		{
			string result = String.Empty;
			string slCadenaAuxiliar = String.Empty;
			int ilPosicionInicial = 0;
			try
			{
					if (false)
					{
						double dbNumericTemp = 0;
						if (Double.TryParse(spDato, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
						{
							spCaracterRelleno = "0";
						} else
						{
							spCaracterRelleno = " ";
						}
					}
					
					switch(ipJustificado)
					{
						case CRSGeneral.cteJustificado.cteIzquierda : 
							result = (spDato + new string(spCaracterRelleno[0], ipLongitud)).Substring(0, Math.Min((spDato + new string(spCaracterRelleno[0], ipLongitud)).Length, ipLongitud)); 
							break;
						case CRSGeneral.cteJustificado.cteDerecha : 
							result = (new string(spCaracterRelleno[0], ipLongitud) + spDato).Substring((new string(spCaracterRelleno[0], ipLongitud) + spDato).Length - Math.Min((new string(spCaracterRelleno[0], ipLongitud) + spDato).Length, ipLongitud)); 
							break;
						case CRSGeneral.cteJustificado.cteCentrado : 
							slCadenaAuxiliar = new string(spCaracterRelleno[0], ipLongitud) + spDato + new string(spCaracterRelleno[0], ipLongitud); 
							ilPosicionInicial = (slCadenaAuxiliar.Length / 2) - (ipLongitud / 2); 
							ilPosicionInicial++; 
							if (ilPosicionInicial > 0)
							{
								result = Strings.Mid(slCadenaAuxiliar, ilPosicionInicial, ipLongitud);
							} else
							{
								result = String.Empty;
							} 
							//      If ipLongitud - Len(spDato) > 0 Then 
							//        slCadenaAuxiliar = String((ipLongitud - Len(spDato)) \ 2, spCaracterRelleno) 
							//      Else 
							//        slCadenaAuxiliar = Empty 
							//      End If 
							//      sfncJustificar = Mid(slCadenaAuxiliar & spDato & slCadenaAuxiliar, 1, ipLongitud) 
							break;
					}
				}
			catch 
			{
				
				//  prObtenError "Justificar"
			}
			return result;
		}
		
		internal string sfncJustificar( string spDato,  CRSGeneral.cteJustificado ipJustificado, ref  int ipLongitud)
		{
			string tempRefParam = "";
			return sfncJustificar(spDato, ipJustificado, ref ipLongitud, ref tempRefParam);
		}
		
	}
}