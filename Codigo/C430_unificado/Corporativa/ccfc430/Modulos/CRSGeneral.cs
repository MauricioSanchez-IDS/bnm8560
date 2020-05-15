using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Runtime.InteropServices;

namespace TCc430
{
	class CRSGeneral
	{
	
		static public string[, ] asgEstados = null;
		static public string[, ] asgUnidades = null;
		
		public enum cteJustificado
		 {
			cteIzquierda = 0 ,
			cteDerecha = 1 ,
			cteCentrado = 2
		}
		
		public enum dlgDialogos
		 {
			dlgAbrir = 0 , //ShowOpen
			dlgGuardar = 1 , //ShowSave
			dlgColor = 2 , //ShowColor
			dlgFuente = 3 , //ShowFont
			dlgImprimir = 4 , //ShowPrinter
			dlgAyuda = 5 //ShowHelp
		}
		
		public enum cteValidaciones
		 {
			cteValAlfabetico = 0 , //Solo letras
			cteValAlfaNumerico = 1 , //Números y letras
			cteValCaracter = 2 , //Sólo un caracter
			cteValEntero = 3 , //Sólo Enteros
			cteValFecha = 4 , //Solo Fechas
			cteValPuntoFlotante = 5 , //Números con punto decimal
			cteValTelefonico = 6 , //Sólo números, Guiones y Parétesis
			cteValCorreoElectrónico = 7 , //Números, Letras y @ y "_"
			cteValRFC = 8 , //Números, Letras y " "
			cteValMemo = 9 , //Campo Memo (Todos los caracteres incluyendo salto de línea)
			cteValHora = 10 , //Formato de Hora
			cteValUniversal = 11 , //Permite todos los caracteres
			cteValAlfabetoSignos = 12 , //Permite caracteres alfabéticos y signos de puntuación
			cteValDigitos = 13 , //Permite exclusivamente Digitos
			cteValNombre = 14 , //Valida Caracteres de los Nombres Grabados
			cteValEspecial = 99 //Permite Los caracteres que se especifique por separado
		}
		
		
		
		static public void  prCargaMesesEnCombo( ComboBox cboCombo)
		{
			try
			{
					for (int ilMeses = 0; ilMeses <= 12; ilMeses++)
					{
						if (ilMeses == 0)
						{
							cboCombo.Items.Add("NINGUNO");
							VB6.SetItemData(cboCombo, 0, ilMeses);
						} else
						{
							cboCombo.Items.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(ilMeses).ToUpper());
							VB6.SetItemData(cboCombo, ilMeses, ilMeses);
						}
					}
				}
			catch 
			{
				
				prObtenError("CargaMesesEnCombo");
			}
		}


        static public void prObtenError(string slRutina, Exception e)
        {
            //***************************************************************
            //*  Descripción     :   Notifica el error que ha sucedido
            //*  Autor           :   Héctor Vázquez Vázquez
            //*  Fecha           :   22 de Octubre de 1999
            //***************************************************************
            Cursor.Current = Cursors.Default;
            string slMensaje = String.Empty;
           
                //UPGRADE_ISSUE: (1040) IsMissing function is not supported.
                //AIS-1123 NGONZALEZ
                if (!String.Empty.Equals(slRutina))
                {
                    //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                    if (slRutina != "" && !String.IsNullOrEmpty(slRutina))
                    {
                        if (e is COMException)
                        {
                            COMException ecom = (COMException)e;
                            slMensaje = slMensaje + "Se ha presentado el error " + ecom.ErrorCode + " en la rutina " + slRutina + " derivado de un objeto " + ecom.Source + "\r" + "\n" + "Descripción: " + e.Message;
                        }
                        else {

                            slMensaje = slMensaje + "Se ha presentado un error en la rutina " + slRutina + " derivado de un objeto " + e.Source + "\r" + "\n" + "Descripción: " + e.Message;
                        }
                    }
                }
                MessageBox.Show(slMensaje, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Information.Err().Number != 0)
                {
                    Information.Err().Clear();
                }
                Cursor.Current = Cursors.Default;
            
        }
		
		static public void  prObtenError( string slRutina)
		{
			//***************************************************************
			//*  Descripción     :   Notifica el error que ha sucedido
			//*  Autor           :   Héctor Vázquez Vázquez
			//*  Fecha           :   22 de Octubre de 1999
			//***************************************************************
			Cursor.Current = Cursors.Default;
			string slMensaje = String.Empty;
			if (Information.Err().Number != 0)
			{
				//UPGRADE_ISSUE: (1040) IsMissing function is not supported.
                //AIS-1123 NGONZALEZ
				if (! String.Empty.Equals(slRutina))
				{
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
					if (slRutina != "" && ! String.IsNullOrEmpty(slRutina))
					{
						slMensaje = slMensaje + "Se ha presentado el error " + Information.Err().Number.ToString() + " en la rutina " + slRutina + " derivado de un objeto " + Information.Err().Source + "\r" + "\n" + "Descripción: " + Information.Err().Description;
					}
				}
				MessageBox.Show(slMensaje, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				if (Information.Err().Number != 0)
				{
					Information.Err().Clear();
				}
				Cursor.Current = Cursors.Default;
			}
		}
		
		static public void  prObtenError()
		{
			prObtenError("");
		}
		
		static public void  prPreparaConsulta(ref  int lpConexion)
		{
			if (VBSQL.SqlCmdRow(ref lpConexion) > 0)
			{
				VBSQL.SqlCancel(lpConexion);
			}
		}


        static public void prValidaCaracter(ref  int ipKeyAscii, cteValidaciones ipTipo, bool bpMayusculas, bool bpAceptaEspacios, string spCadenaEspecial, string spExcepcion)
		{
			//**********************************************************************************************************************
			//*  Descripción     :   Evalua un caracter KeyAscii, segun el tipo de ipTipo, para aceptarlo u omitirlo desde el teclado
			//*                      y la función KeyPress
			//*  Autor           :   Héctor Vázquez Vázquez
			//*  Fecha           :   28 Febrero 2001
			//**********************************************************************************************************************
			//Caracteres de Alfabéticos
			const string slAlfabetico = "abcdefghiíjklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			const string slAlfabeticoEspecial = "áéíóúñÁÉÍÓÚÑ";
			const string slSignosPuntuacion = ".:,;!¡?¿{}[]'_/" + "\"";
			const string slSignosPuntuacionResumidos = ".,-_;";
			const string slEspacio = " ";
			//Caracteres numéricos involucrados
			const string slNumeros = "0123456789";
			const string slSeparadorDecimal = ".";
			const string slSeparadorMiles = ",";
			const string slPuntoFlotante = "-" + slSeparadorDecimal + slSeparadorMiles + slNumeros;
			const string slDinero = "$" + slPuntoFlotante;
			const string slSeparadorFecha = "/-.";
			const string slNumericoEntero = slNumeros + ",";
			const string slTelefono = slNumeros + "-" + slEspacio;
			//Caracteres involucrados en las fechas
			const string slFechaCorta = slNumeros + slSeparadorFecha;
			const string slFechaLarga = slNumeros + slAlfabetico;
			const string slHora = slNumeros + ":apmAPM";
			//Conjunto de caracteres especiales
			const string slCaracteresEspeciales = "#$%&@";
			const string slOperadores = "-+/*=<>()[]{}";
			//Correo electrónico
			const string slEMail = "@" + slAlfabetico + slNumeros + ".-_";
			//Caracteres válidos para RFC
			const string slRFC = slAlfabetico + slNumeros;
			
			//*************************************************
			string slCadena = String.Empty;
			
			try
			{
					//Verifica caractéres válidos (Caracteres de  Control)
					//Caracteres No Validos.
					if (ipKeyAscii >= 0 && ipKeyAscii <= 31)
					{ //Caracteres de Control
						switch(ipKeyAscii)
						{
							case 8 : 
								//SendKeys "{BACKSPACE}" 
								break;
							case 9 : 
								//                        SendKeys "{TAB}" 
								break;
							case 10 : 
								//                        SendKeys "" 
								break;
							case 13 : 
								//                        SendKeys "{ENTER}" 
								break;
							default:
								ipKeyAscii = 0; 
								break;
						}
					} else if (ipKeyAscii == 94 || ipKeyAscii == 96 || ipKeyAscii == 124 || ipKeyAscii >= 126 && ipKeyAscii <= 192 || ipKeyAscii >= 193 && ipKeyAscii <= 200 || ipKeyAscii >= 202 && ipKeyAscii <= 204 || ipKeyAscii >= 206 && ipKeyAscii <= 208 || ipKeyAscii >= 212 && ipKeyAscii <= 217 || ipKeyAscii == 219 || ipKeyAscii >= 221 && ipKeyAscii <= 224 || ipKeyAscii >= 226 && ipKeyAscii <= 232 || ipKeyAscii >= 234 && ipKeyAscii <= 236 || ipKeyAscii >= 238 && ipKeyAscii <= 240 || ipKeyAscii == 242 || ipKeyAscii >= 244 && ipKeyAscii <= 249 || ipKeyAscii == 251 || ipKeyAscii > 253) { 
						ipKeyAscii = 0;
					} else
					{
						//Convierte a mayúsculas los caracteres correspondientes
						if (bpMayusculas)
						{
							ipKeyAscii = (int) Strings.Chr(ipKeyAscii).ToString().ToUpper()[0];
						}
						//Valida segun tipo
						switch(ipTipo)
						{
							case cteValidaciones.cteValAlfabetico : 
								if (! bpAceptaEspacios)
								{
									slCadena = slAlfabetico + slAlfabeticoEspecial + spCadenaEspecial;
								} else
								{
									slCadena = slAlfabetico + slAlfabeticoEspecial + slEspacio + spCadenaEspecial;
								} 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValAlfaNumerico : 
								if (! bpAceptaEspacios)
								{
									slCadena = slAlfabetico + slNumeros + slAlfabeticoEspecial + spCadenaEspecial;
								} else
								{
									slCadena = slAlfabetico + slNumeros + slAlfabeticoEspecial + slEspacio + spCadenaEspecial;
								} 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValCaracter : 
								if (ipKeyAscii == 8)
								{
									return;
								} 
								break;
							case cteValidaciones.cteValCorreoElectrónico : 
								slCadena = slEMail + spCadenaEspecial; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if (VB6.GetActiveControl() is TextBox)
								{
									//UPGRADE_ISSUE: (2072) Control Text could not be resolved because it was within the generic namespace ActiveControl.
									if (Convert.ToString(VB6.GetActiveControl().Text).IndexOf(Strings.Chr(64).ToString()) >= 0)
									{
										if (ipKeyAscii == 64)
										{
											ipKeyAscii = 0;
										}
									}
									if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
									{
										ipKeyAscii = 0;
									} else
									{
										ipKeyAscii = (int) Strings.Chr(ipKeyAscii).ToString().ToLower()[0];
									}
								} 
								break;
							case cteValidaciones.cteValEntero : 
								slCadena = slNumeros + "-"; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValFecha : 
								slCadena = slFechaCorta; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValPuntoFlotante : 
								slCadena = slPuntoFlotante; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValRFC : 
								if (VB6.GetActiveControl() is TextBox)
								{
									if (Strings.Len(VB6.GetActiveControl().ToString()) >= 0 && Strings.Len(VB6.GetActiveControl().ToString()) <= 3)
									{
										slCadena = slAlfabetico;
									} else if (Strings.Len(VB6.GetActiveControl().ToString()) >= 4 && Strings.Len(VB6.GetActiveControl().ToString()) <= 9) { 
										slCadena = slNumeros;
									} else if (Strings.Len(VB6.GetActiveControl().ToString()) >= 10 && Strings.Len(VB6.GetActiveControl().ToString()) <= 14) { 
										slCadena = slRFC;
									}
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValTelefonico : 
								slCadena = slTelefono; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = Int32.Parse("0" + spCadenaEspecial);
								} 
								break;
							case cteValidaciones.cteValUniversal : 
								slCadena = slAlfabetico + slAlfabeticoEspecial + slSignosPuntuacion + slEspacio + slNumeros + slSeparadorMiles + slSeparadorDecimal + spCadenaEspecial; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValAlfabetoSignos : 
								slCadena = slAlfabetico + slAlfabeticoEspecial + slSignosPuntuacionResumidos + slEspacio + slNumeros + spCadenaEspecial; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValDigitos : 
								slCadena = slNumeros; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
							case cteValidaciones.cteValEspecial : 
								slCadena = spCadenaEspecial; 
								if (spExcepcion.Trim() != "" && ! false)
								{
									slCadena = sfncEliminaCaracteresDeUnaCadenaEnOtra(ref slCadena, spExcepcion.Trim());
								} 
								if ((slCadena.IndexOf(Strings.Chr(ipKeyAscii).ToString()) + 1) == 0)
								{
									ipKeyAscii = 0;
								} 
								break;
						}
					}
				}
			catch 
			{
				
				prObtenError("ValidaCaracter");
			}
		}
        //AIS-1120 NGONZALEZ
        static public void prValidaCaracter(ref  short ipKeyAscii, cteValidaciones ipTipo, bool bpMayusculas, bool bpAceptaEspacios, string spCadenaEspecial, string spExcepcion)
        {
            int aux = (int)ipKeyAscii;
            prValidaCaracter(ref aux, ipTipo, bpMayusculas, bpAceptaEspacios, spCadenaEspecial, spExcepcion);
            ipKeyAscii = (short)aux;
        }

        static public void prValidaCaracter(ref  int ipKeyAscii, cteValidaciones ipTipo, bool bpMayusculas, bool bpAceptaEspacios, string spCadenaEspecial)
		{
			prValidaCaracter(ref ipKeyAscii, ipTipo, bpMayusculas, bpAceptaEspacios, spCadenaEspecial, "");
		}
        //AIS-1120 NGONZALEZ
        static public void prValidaCaracter(ref  short ipKeyAscii, cteValidaciones ipTipo, bool bpMayusculas, bool bpAceptaEspacios, string spCadenaEspecial)
        {
            int aux = (int)ipKeyAscii;
            prValidaCaracter(ref aux, ipTipo, bpMayusculas, bpAceptaEspacios, spCadenaEspecial, "");
            ipKeyAscii = (short)aux;
        }

        //AIS-1120 NGONZALEZ
        static public void prValidaCaracter(ref  short ipKeyAscii, cteValidaciones ipTipo, bool bpMayusculas, bool bpAceptaEspacios)
        {
            int aux = (int)ipKeyAscii;
            prValidaCaracter(ref aux, ipTipo, bpMayusculas, bpAceptaEspacios, "", "");
            ipKeyAscii = (short) aux;
        }
		
		static public void  prValidaCaracter(ref  int ipKeyAscii,  cteValidaciones ipTipo,  bool bpMayusculas,  bool bpAceptaEspacios)
		{
			prValidaCaracter(ref ipKeyAscii, ipTipo, bpMayusculas, bpAceptaEspacios, "", "");
		}

        static public void prValidaCaracter(ref  int ipKeyAscii, cteValidaciones ipTipo, bool bpMayusculas)
		{
			prValidaCaracter(ref ipKeyAscii, ipTipo, bpMayusculas, false, "", "");
		}
        //AIS-1120 NGONZALEZ
        static public void prValidaCaracter(ref  short ipKeyAscii, cteValidaciones ipTipo)
        {
            int aux = (int)ipKeyAscii;
            prValidaCaracter(ref aux, ipTipo, false, false, "", "");
            ipKeyAscii = (short)aux;
        }

        static public void prValidaCaracter(ref  int ipKeyAscii, cteValidaciones ipTipo)
		{
			prValidaCaracter(ref ipKeyAscii, ipTipo, false, false, "", "");
		}
		
		
		static public string fncsObtenerElementoDeCadena(ref  string spCadena,  int ipElemento,  string spSeparador)
		{
			//**********************************************************************************************
			//*  Descripción     :   Obtiene el elemento ipElemento, de la cadena spCadena, basado
			//*  Autor           :   Héctor Vázquez Vázquez
			//*  Fecha           :   05 de Enero de 2002
			//**********************************************************************************************
			int ilPosicionInicial = 0;
			int ilPosicionFinal = 0;
			string slParametro = String.Empty;
			string slCadenaAux = String.Empty;
			try
			{
					
					//UPGRADE_ISSUE: (1040) IsMissing function is not supported.
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                    //AIS-1123 NGONZALEZ
                    if (String.IsNullOrEmpty(spSeparador) || String.Empty.Equals(spSeparador))
					{
						spSeparador = ",";
					}
					ilPosicionInicial = 0;
					ilPosicionFinal = Strings.InStr(ilPosicionInicial + 1, spCadena, spSeparador, CompareMethod.Binary);
					if (ipElemento > 1 && ilPosicionFinal == 0)
					{
						slParametro = "";
					} else
					{
						if (ipElemento < 0)
						{
							return String.Empty;
						} else if (ipElemento == 1) { 
							if (ilPosicionFinal == 0)
							{
								slParametro = spCadena;
							} else
							{
								slParametro = spCadena.Substring(0, Math.Min(spCadena.Length, ilPosicionFinal - 1));
							}
						} else if (ipElemento > 1) { 
							if (ilPosicionFinal == 0)
							{
								slParametro = spCadena.Substring(spCadena.Length - Math.Min(spCadena.Length, spCadena.Length - ilPosicionInicial));
								ipElemento = 1;
							} else
							{
								ipElemento--;
								slCadenaAux = spCadena.Substring(spCadena.Length - Math.Min(spCadena.Length, spCadena.Length - ilPosicionFinal));
								slParametro = fncsObtenerElementoDeCadena(ref slCadenaAux, ipElemento, spSeparador);
							}
						}
					}
					return slParametro;
				}
			catch 
			{
				
				
				prObtenError("ObtenerElementoDeCadena");
			}
			return String.Empty;
		}
		
		static public string fncsObtenerElementoDeCadena(ref  string spCadena,  int ipElemento)
		{
			return fncsObtenerElementoDeCadena(ref spCadena, ipElemento, "");
		}
		
		static public int fnciCuentaCadenas( string spCadena, ref  string spCadenaABuscar)
		{
			int ilPosicionInicial = 0;
			int ilCounter = 0;
			int ilPosicionFinal = 0;
			
			try
			{
					ilCounter = 0;
					ilPosicionFinal = 1;
					ilPosicionInicial = 1;
					while (ilPosicionFinal > 0)
						{
						
							ilPosicionInicial = Strings.InStr(ilPosicionInicial + 1, spCadena, spCadenaABuscar, CompareMethod.Binary);
							ilPosicionFinal = Strings.InStr(ilPosicionInicial + 1, spCadena, spCadenaABuscar, CompareMethod.Binary);
							ilCounter++;
						}
					
					return ilCounter;
				}
			catch 
			{
				
				prObtenError("CuentaCadenas");
			}
			return 0;
		}
		
		
		
		
		static public int lfncFechaNacimiento( string spRFC)
		{
			string slAño = String.Empty;
			string slMes = String.Empty;
			string slDia = String.Empty;
			System.DateTime dlFecha = DateTime.FromOADate(0);
			try
			{
					spRFC = Seguridad.fncsSustituir(spRFC.Trim(), "-", "");
					double dbNumericTemp = 0;
					if (Double.TryParse(Strings.Mid(spRFC, 4, 1), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
					{
						slAño = Strings.Mid(spRFC, 4, 2);
						slMes = Strings.Mid(spRFC, 6, 2);
						slDia = Strings.Mid(spRFC, 8, 2);
					} else
					{
						slAño = Strings.Mid(spRFC, 5, 2);
						slMes = Strings.Mid(spRFC, 7, 2);
						slDia = Strings.Mid(spRFC, 9, 2);
					}
					return StringsHelper.IntValue(DateTime.Parse(slDia + "/" + slMes + "/" + slAño).ToString("yyyyMMdd"));
				}
			catch 
			{
				
				prObtenError("FechaNacimiento");
			}
			return 0;
		}
		
		static public void  prCargaEstados()
		{
			int ilIndice = 0;
			try
			{
					//Carga los estados de la república mexicana en un arreglo
					CORVAR.pszgblsql = "Select edo_cve_edo, edo_descripcion from MTCEDO01 ORDER BY edo_descripcion";
					prPreparaConsulta(ref CORVAR.hgblConexion);
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						ilIndice = 0;
						while (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
							{
							
								asgEstados = ArraysHelper.RedimPreserve<string[, ]>(asgEstados, new int[]{2, ilIndice + 1});
								asgEstados[0, ilIndice] = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
								asgEstados[1, ilIndice] = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
								ilIndice++;
							}
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
			catch 
			{
				
				prObtenError("CargaEstados");
			}
		}
		
		static public void  prCargaEstadoEnCombo( ComboBox cboCombo)
		{
			try
			{
					for (int ilIndice = 0; ilIndice <= asgEstados.GetUpperBound(1); ilIndice++)
					{
						cboCombo.Items.Add(asgEstados[1, ilIndice]);
					}
				}
			catch 
			{
				
				prObtenError("CargaEstadoEnCombo");
			}
		}
		
		static public string sfncEstado( ComboBox cboCombo)
		{
			try
			{
					if (cboCombo.SelectedIndex >= 0)
					{
						return asgEstados[0, cboCombo.SelectedIndex];
					} else
					{
						return "";
					}
				}
			catch 
			{
				
				prObtenError("Estado");
			}
			return String.Empty;
		}
		static public void  prBuscaEstado( ComboBox cboCombo,  string spEstado)
		{
			try
			{
					for (int ilIndice = 0; ilIndice <= asgEstados.GetUpperBound(1); ilIndice++)
					{
						if (spEstado.Trim().ToUpper() == asgEstados[0, ilIndice].ToUpper())
						{
							cboCombo.SelectedIndex = ilIndice;
							return;
					}
				}
				}
			catch 
			{
				
				prObtenError("BuscaEstado");
			}
		}
		static public void  prBuscaUnidad( ComboBox cboCombo,  string spUnidad)
		{
			try
			{
					for (int ilIndice = 0; ilIndice <= asgUnidades.GetUpperBound(1); ilIndice++)
					{
						if (spUnidad.ToUpper() == asgUnidades[0, ilIndice].ToUpper())
						{
							if (cboCombo.Items.Count > 0)
							{
								cboCombo.SelectedIndex = ilIndice;
							}
							return;
						}
					}
				}
			catch 
			{
				
				prObtenError("BuscaUnidad");
			}
		}
		
		
		static public string fncsAbrirArchivo( AxMSComDlg.AxCommonDialog dlgDialogo,  string slFiltro,  dlgDialogos ilOpcion)
		{
			string result = String.Empty;
			try
			{
					//Selecciona el Filtro
					if (slFiltro.Trim() == "")
					{
						slFiltro = "Altas Masivas Tarjetahabiente(*.amt;*.amt)|*.amt";
						slFiltro = slFiltro + "|" + "Todos los Archivo (*.*)|*.*";
					}
					// Establecer CancelError a True
					dlgDialogo.CancelError = false;
					dlgDialogo.DialogTitle = "Seleccionar Archivo";
					//Establecer los indicadores
					dlgDialogo.Flags = (int) MSComDlg.FileOpenConstants.cdlOFNHideReadOnly;
					//Establecer los filtros
					dlgDialogo.Filter = slFiltro;
					//Especificar el filtro predeterminado
					dlgDialogo.FilterIndex = 1;
					//Presentar el cuadro de diálogo Abrir
					switch(ilOpcion)
					{
						case dlgDialogos.dlgAbrir : 
							dlgDialogo.ShowOpen(); 
							break;
						case dlgDialogos.dlgAyuda :
                            //AIS- NGONZALEZ este cambio no lo ingrese al share point por que parece ser que no es necesario
                            throw new Exception("ShowHelp not support");
                            //helpComponent1.ShowHelp(); 
                            //AIS-http://bnx.artinsoft.net/Wiki%20Pages/Ayuda%20a%20través%20del%20control%20Microsoft%20Windows%20Common%20Dialog.aspx NGONZALEZ
                            Artinsoft.VB6.Help.HelpSupportComponent dgl = new Artinsoft.VB6.Help.HelpSupportComponent();
                            dgl.ShowHelp();
							break;
						case dlgDialogos.dlgColor : 
							dlgDialogo.ShowColor(); 
							break;
						case dlgDialogos.dlgFuente : 
							dlgDialogo.ShowFont(); 
							break;
						case dlgDialogos.dlgGuardar : 
							dlgDialogo.ShowSave(); 
							break;
						case dlgDialogos.dlgImprimir : 
							dlgDialogo.ShowPrinter(); 
							break;
					}
					//Presentar el nombre del archivo seleccionado
					if (ilOpcion == dlgDialogos.dlgAbrir || ilOpcion == dlgDialogos.dlgGuardar)
					{
						result = dlgDialogo.FileName;
					} else if (ilOpcion == dlgDialogos.dlgAyuda) { 
					} else if (ilOpcion == dlgDialogos.dlgColor) { 
					} else if (ilOpcion == dlgDialogos.dlgFuente) { 
					} else if (ilOpcion == dlgDialogos.dlgImprimir) { 
					}
				}
			catch 
			{
				
				
				// El usuario ha hecho clic en el botón Cancelar
				switch(Information.Err().Number)
				{
					case 32755 : 
						break;
					default:
						prObtenError("AbrirArchivo"); 
						break;
				}
			}
			return result;
		}
		
		static public string fncsAbrirArchivo( AxMSComDlg.AxCommonDialog dlgDialogo,  string slFiltro)
		{
			return fncsAbrirArchivo(dlgDialogo, slFiltro, dlgDialogos.dlgAbrir);
		}
		
		static public string fncsAbrirArchivo( AxMSComDlg.AxCommonDialog dlgDialogo)
		{
			return fncsAbrirArchivo(dlgDialogo, "", dlgDialogos.dlgAbrir);
		}
		
		
		static public void  prScrollBar( HScrollBar scrpScroll,  ListBox lstLista)
		{
			string ScrollBar = String.Empty;
			try
			{
					lstLista.SetBounds(Convert.ToInt32((float) VB6.TwipsToPixelsX(scrpScroll.Value)), 0, 0, 0, BoundsSpecified.X);
				}
			catch 
			{
				
				prObtenError(ScrollBar);
			}
		}
		//AIS-1162 NGONZALEZ
		static public void  prAsignaScrollBar( HScrollBar scrpScroll,  Panel pbxPictureBox,  ListBox lstLista)
		{
			int NewLargeChange = 0;
			try
			{
					scrpScroll.Top = (int) (pbxPictureBox.Top + pbxPictureBox.Height);
					scrpScroll.Left = (int) pbxPictureBox.Left;
					scrpScroll.Width = (int) pbxPictureBox.Width;
					scrpScroll.Maximum = (Convert.ToInt32(((float) VB6.PixelsToTwipsX(pbxPictureBox.Width)) - ((float) VB6.PixelsToTwipsX(lstLista.Width))) + scrpScroll.LargeChange - 1);
					scrpScroll.SmallChange = 1000;
					NewLargeChange = 2000;
					scrpScroll.Maximum = scrpScroll.Maximum + NewLargeChange - scrpScroll.LargeChange;
					scrpScroll.LargeChange = NewLargeChange;
					scrpScroll.Minimum = 0;
				}
			catch 
			{
				
				prObtenError("AsignaScrollBar");
			}
		}
		
		static public void  prCargaEmpresa( ComboBox cboCombo,  int lpCorporativo)
		{
			try
			{
					Cursor.Current = Cursors.WaitCursor;
					CORVAR.pszgblsql = "SELECT emp_num, emp_nombre FROM MTCEMP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
					if (! false)
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + lpCorporativo.ToString();
					}
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
							
								cboCombo.Items.Add(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)), Formato.sMascara(Formato.iTipo.Empresa)) + "\t" + VBSQL.SqlData(CORVAR.hgblConexion, 2));
							}
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				prObtenError("CargaEmpresa");
			}
		}
		
		static public void  prCargaEmpresa( ComboBox cboCombo)
		{
			prCargaEmpresa(cboCombo, 0);
		}
		
		
		static public int lfncCargaUnidades( Control opObjeto,  int lpCorporativo,  int lpEmpresa)
		{
			int result = 0;
			int ilIndice = 0;
			try
			{
					Cursor.Current = Cursors.WaitCursor;
					Formato.pszgblSql3 = "SELECT unit_id, unit_name FROM MTCUNI01";
					Formato.pszgblSql3 = Formato.pszgblSql3 + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString();
					Formato.pszgblSql3 = Formato.pszgblSql3 + " and gpo_banco = " + CORVAR.igblBanco.ToString();
					//        If Not IsMissing(lpCorporativo) Then
					//            pszgblSql3 = pszgblSql3 & " and gpo_num = " & lpCorporativo
					//        End If
					if (! false)
					{
						Formato.pszgblSql3 = Formato.pszgblSql3 + " and emp_num = " + lpEmpresa.ToString();
					}
					
					if (opObjeto != null)
					{
						if (opObjeto is ComboBox || opObjeto is ListBox)
						{
				//UPGRADE_TODO: (1067) Member Clear is not defined in type object.
                            //AIS-1153 NGONZALEZ
                            if (opObjeto is ComboBox)
                            ((ComboBox)opObjeto).Items.Clear();
                            else if(opObjeto is ListBox)
                            ((ListBox)opObjeto).Items.Clear();

							if (Formato.ifncObtiene_Registros() != 0)
							{
								ilIndice = 0;
								while (VBSQL.SqlNextRow(Formato.hgblConexion3) != VBSQL.NOMOREROWS)
									{
									
										asgUnidades = ArraysHelper.RedimPreserve<string[, ]>(asgUnidades, new int[]{2, ilIndice + 1});
										if (opObjeto is ComboBox)
										{
											((ComboBox) opObjeto).Items.Add(Conversion.Val(VBSQL.SqlData(Formato.hgblConexion3, 1)).ToString() + CRSParametros.cteSeparador + VBSQL.SqlData(Formato.hgblConexion3, 2));
										} else
										{
											//UPGRADE_TODO: (1067) Member AddItem is not defined in type object.
											//opObjeto.AddItem(Conversion.Val(VBSQL.SqlData(Formato.hgblConexion3, 1)).ToString() + "\t" + VBSQL.SqlData(Formato.hgblConexion3, 2));
                                            //AIS-1153 NGONZALEZ
                                            if (opObjeto is ComboBox)
                                                ((ComboBox)opObjeto).Items.Add(Conversion.Val(VBSQL.SqlData(Formato.hgblConexion3, 1)).ToString() + "\t" + VBSQL.SqlData(Formato.hgblConexion3, 2));
                                            else if (opObjeto is ListBox)
                                                ((ListBox)opObjeto).Items.Add(Conversion.Val(VBSQL.SqlData(Formato.hgblConexion3, 1)).ToString() + "\t" + VBSQL.SqlData(Formato.hgblConexion3, 2));
                                        }
										asgUnidades[0, ilIndice] = Conversion.Val(VBSQL.SqlData(Formato.hgblConexion3, 1)).ToString();
										asgUnidades[1, ilIndice] = Conversion.Val(VBSQL.SqlData(Formato.hgblConexion3, 2)).ToString();
										ilIndice++;
									}
							} else
							{
								asgUnidades = ArraysHelper.RedimPreserve<string[, ]>(asgUnidades, new int[]{2, ilIndice + 1});
							}
							CORVAR.igblRetorna = VBSQL.SqlCancel(Formato.hgblConexion3);
						}
					} else
					{
						prPreparaConsulta(ref Formato.hgblConexion3);
						if (Formato.ifncObtiene_Registros() == (-1))
						{
							while (VBSQL.SqlNextRow(Formato.hgblConexion3) == VBSQL.MOREROWS)
								{
								
									result++;
								}
						}
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(Formato.hgblConexion3);
					}
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				
				prObtenError("CargaUnidades");
			}
			return result;
		}
		
		static public int lfncCargaUnidades( Control opObjeto,  int lpCorporativo)
		{
			return lfncCargaUnidades(opObjeto, lpCorporativo, 0);
		}
		
		static public int lfncCargaUnidades( Control opObjeto)
		{
			return lfncCargaUnidades(opObjeto, 0, 0);
		}
		
		static public int lfncCargaUnidades()
		{
			return lfncCargaUnidades(null, 0, 0);
		}
		
		
		static public void  prGenerarEjecutivos0( string spArchivoSalida)
		{
			int ilIndice = 0;
			StringBuilder slRenglon = new StringBuilder();
			slRenglon.Append(String.Empty);
			string slCuenta = String.Empty;
			int ilArchivoDisponible = 0;
			string slNombreEmpresa = String.Empty;
			string slIzquierda = String.Empty;
			string slDerecha = String.Empty;
			
			try
			{
					Cursor.Current = Cursors.WaitCursor;
					CRSDialogo.prLongitudes();
					CORVAR.pszgblsql = "SELECT eje_prefijo ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_nom";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCEMP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER by eje_prefijo,gpo_banco,emp_num";
					prPreparaConsulta(ref CORVAR.hgblConexion);
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						ilArchivoDisponible = FileSystem.FreeFile();
						ilIndice = 0;
						FileSystem.FileOpen(ilArchivoDisponible, spArchivoSalida, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
						while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
							
								slCuenta = VBSQL.SqlData(CORVAR.hgblConexion, 1);
								slCuenta = slCuenta + VBSQL.SqlData(CORVAR.hgblConexion, 2);
								slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 3), new string('0', CRSDialogo.ifncLongitudEmpresa(Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2)))));
								slCuenta = slCuenta + StringsHelper.Format(0, new string('0', CRSDialogo.ifncLongitudEjecutivo(Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2)))));
								slCuenta = slCuenta + "9";
								slCuenta = slCuenta + CORPROC.Calcula_digito_verif(ref slCuenta).ToString();
								
								slRenglon = new StringBuilder(slCuenta);
								
								slNombreEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 4);
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, ",", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "(", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, ")", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "-", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "/", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, ".", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "0", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "1", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "2", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "3", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "4", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "5", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "6", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "7", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "8", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "9", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "[", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "]", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "&", "");
								
								slIzquierda = Strings.Mid(slNombreEmpresa, 1, slNombreEmpresa.IndexOf(' '));
								slDerecha = slNombreEmpresa.Substring(slNombreEmpresa.Length - Math.Min(slNombreEmpresa.Length, slNombreEmpresa.Length - slIzquierda.Length)).TrimStart();
								slNombreEmpresa = slIzquierda + "," + slDerecha;
								
								if (slNombreEmpresa.IndexOf(' ') >= 0)
								{
									slIzquierda = Strings.Mid(slNombreEmpresa, 1, slNombreEmpresa.IndexOf(' '));
								} else
								{
									slIzquierda = slNombreEmpresa;
								}
								slDerecha = slNombreEmpresa.Substring(slNombreEmpresa.Length - Math.Min(slNombreEmpresa.Length, slNombreEmpresa.Length - slIzquierda.Length)).TrimStart();
								slNombreEmpresa = slIzquierda + "/" + slDerecha;
								
								slRenglon.Append("\t" + slNombreEmpresa);
								
								ilIndice++;
								FileSystem.PrintLine(ilArchivoDisponible, slRenglon.ToString());
							}
						FileSystem.FileClose(ilArchivoDisponible);
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				prObtenError("GenerarEjecutivos0");
			}
		}
		
		
		static public bool bfncValidaFecha( AxMSMask.AxMaskEdBox mskMaskedit,  int ipOpcion, ref  string spTitulo)
		{
			bool result = false;
			try
			{
					if (Information.IsDate(mskMaskedit.CtlText))
					{
						switch(ipOpcion)
						{
							case 0 : 
								if (DateTime.Parse(mskMaskedit.CtlText) <= StringsHelper.DateValue(DateTime.Now.ToString("dd/MM/yyyy")))
								{
									MessageBox.Show("La fecha no puede ser menor o igual al día actual, verifiquela.", spTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
									mskMaskedit.SelStart = 0;
									mskMaskedit.SelLength = Strings.Len(mskMaskedit.CtlText);
									mskMaskedit.Focus();
									result = false;
								} else
								{
									result = true;
								} 
								break;
							default:
								break;
						}
					} else
					{
						MessageBox.Show("Fecha no válida, verifique.", spTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
						mskMaskedit.SelStart = 0;
						mskMaskedit.SelLength = Strings.Len(mskMaskedit.CtlText);
						mskMaskedit.Focus();
						result = false;
					}
				}
			catch 
			{
				
				prObtenError("ValidaFecha");
			}
			
			return result;
		}
		
		
		static public string sfncJustificar( string spDato,  cteJustificado jstpJustificado, ref  int ipLongitud, ref  string spCaracterRelleno)
		{
			string result = String.Empty;
			string slCadenaAuxiliar = String.Empty;
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
					
					switch(jstpJustificado)
					{
						case cteJustificado.cteIzquierda : 
							result = (spDato + new string(spCaracterRelleno[0], ipLongitud)).Substring(0, Math.Min((spDato + new string(spCaracterRelleno[0], ipLongitud)).Length, ipLongitud)); 
							break;
						case cteJustificado.cteDerecha : 
							result = (new string(spCaracterRelleno[0], ipLongitud) + spDato).Substring((new string(spCaracterRelleno[0], ipLongitud) + spDato).Length - Math.Min((new string(spCaracterRelleno[0], ipLongitud) + spDato).Length, ipLongitud)); 
							break;
						case cteJustificado.cteCentrado : 
							slCadenaAuxiliar = new string(spCaracterRelleno[0], ipLongitud) + spDato + new string(spCaracterRelleno[0], ipLongitud); 
							result = Strings.Mid(slCadenaAuxiliar, (slCadenaAuxiliar.Length - (ipLongitud / 2 - spDato.Length / 2)) / 2, ipLongitud); 
							break;
					}
				}
			catch 
			{
				
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
				throw new Exception("Migration Exception: 'Resume Next' not supported");
				prObtenError("Justificar");
			}
			return result;
		}
		
		static public string sfncJustificar( string spDato,  cteJustificado jstpJustificado, ref  int ipLongitud)
		{
			string tempRefParam = "";
			return sfncJustificar(spDato, jstpJustificado, ref ipLongitud, ref tempRefParam);
		}
		
		
		
		
		static public void  prGenerarRelacionEjeCorp( TextBox spArchivoSalida)
		{
			string slArchivo = String.Empty;
			int ilIndice = 0;
			string slRenglon = String.Empty;
			string slCuenta = String.Empty;
			int ilArchivoDisponible = 0;
			string slNombreEmpresa = String.Empty;
			string slIzquierda = String.Empty;
			string slDerecha = String.Empty;
			
			try
			{
					Cursor.Current = Cursors.WaitCursor;
					CRSDialogo.prLongitudes();
					CORVAR.pszgblsql = "SELECT eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_roll_over";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_digit";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCEJE01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo <> 4943 AND gpo_banco <> 88";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY eje_prefijo, gpo_banco, emp_num, eje_num";
					
					prPreparaConsulta(ref CORVAR.hgblConexion);
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						ilArchivoDisponible = FileSystem.FreeFile();
						ilIndice = 0;
						FileSystem.FileOpen(ilArchivoDisponible, spArchivoSalida.Text, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
						while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
							
								ilIndice++;
								//Cuenta Padre o empresarial
								int tempRefParam = 5;
								string tempRefParam2 = "0";
								slCuenta = sfncJustificar(ilIndice.ToString(), cteJustificado.cteDerecha, ref tempRefParam, ref tempRefParam2) + " ";
								slCuenta = VBSQL.SqlData(CORVAR.hgblConexion, 1);
								slCuenta = slCuenta + VBSQL.SqlData(CORVAR.hgblConexion, 2);
								slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 3), new string('0', CRSDialogo.ifncLongitudEmpresa(Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2)))));
								slCuenta = slCuenta + StringsHelper.Format(0, new string('0', CRSDialogo.ifncLongitudEjecutivo(Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2)))));
								slCuenta = slCuenta + "9";
								slCuenta = slCuenta + CORPROC.Calcula_digito_verif(ref slCuenta).ToString();
								slRenglon = slCuenta;
								//Cuenta Individual o Ejecutivo
								slCuenta = "";
								slCuenta = VBSQL.SqlData(CORVAR.hgblConexion, 1);
								slCuenta = slCuenta + VBSQL.SqlData(CORVAR.hgblConexion, 2);
								slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 3), new string('0', CRSDialogo.ifncLongitudEmpresa(Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2)))));
								slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 4), new string('0', CRSDialogo.ifncLongitudEjecutivo(Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2)))));
								slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 5), "0");
								slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 6), "0");
								slRenglon = slRenglon.Trim() + slCuenta;
								FileSystem.PrintLine(ilArchivoDisponible, slRenglon);
							}
						MessageBox.Show("Se almacenaron " + ilIndice.ToString() + " registros en el archivo " + slArchivo, "Relación Empresa - Tarjetahabientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
						FileSystem.FileClose(ilArchivoDisponible);
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				prObtenError("GenerarRelacionEjeCorp");
			}
		}
		
		
		
		
		
		
		static public void  prGenerarCuentasCorp( TextBox spArchivoSalida)
		{
			string slArchivo = String.Empty;
			int ilIndice = 0;
			StringBuilder slRenglon = new StringBuilder();
			slRenglon.Append(String.Empty);
			string slCuenta = String.Empty;
			int ilArchivoDisponible = 0;
			string slNombreEmpresa = String.Empty;
			string slIzquierda = String.Empty;
			string slDerecha = String.Empty;
			string slCadenaAuxiliar = String.Empty;
			
			try
			{
					Cursor.Current = Cursors.WaitCursor;
					CRSDialogo.prLongitudes();
					CORVAR.pszgblsql = "select ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  emp_nom";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_nom_graba";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_sucur";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_rfc";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_sector";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_fiscal_calle";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_fiscal_col";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_fiscal_ciu";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_fiscal_pob";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_fiscal_edo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_fiscal_cp";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tel_lada";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_telefono";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_extension";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_calle";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_col";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_ciu";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_pob";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_edo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_cp";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_dia_corte";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_sucur";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_cta_capt";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCEMP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo <> 4943 AND gpo_banco <> 88";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY eje_prefijo, gpo_banco, emp_num";
					
					prPreparaConsulta(ref CORVAR.hgblConexion);
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						ilArchivoDisponible = FileSystem.FreeFile();
						ilIndice = 0;
						FileSystem.FileOpen(ilArchivoDisponible, spArchivoSalida.Text, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
						while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
							
								ilIndice++;
								//Cuenta Padre o empresarial
								slCuenta = VBSQL.SqlData(CORVAR.hgblConexion, 21);
								slCuenta = slCuenta + VBSQL.SqlData(CORVAR.hgblConexion, 22);
								slCuenta = slCuenta + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 23), new string('0', CRSDialogo.ifncLongitudEmpresa(Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 21)), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 22)))));
								slCuenta = slCuenta + StringsHelper.Format(0, new string('0', CRSDialogo.ifncLongitudEjecutivo(Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 21)), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 22)))));
								slCuenta = slCuenta + "9";
								slCuenta = slCuenta + CORPROC.Calcula_digito_verif(ref slCuenta).ToString();
								
								slNombreEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, ",", " ");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "(", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, ")", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "-", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "/", " ");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, ".", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "0", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "1", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "2", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "3", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "4", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "5", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "6", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "7", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "8", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "9", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "[", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "]", "");
								slNombreEmpresa = Seguridad.fncsSustituir(slNombreEmpresa, "&", "");
								
								if (slNombreEmpresa.IndexOf(' ') >= 0)
								{
									slIzquierda = Strings.Mid(slNombreEmpresa, 1, slNombreEmpresa.IndexOf(' '));
								} else
								{
									slIzquierda = slNombreEmpresa;
								}
								slDerecha = slNombreEmpresa.Substring(slNombreEmpresa.Length - Math.Min(slNombreEmpresa.Length, slNombreEmpresa.Length - slIzquierda.Length)).TrimStart();
								slNombreEmpresa = slIzquierda + "," + slDerecha;
								
								if (slNombreEmpresa.IndexOf(' ') >= 0)
								{
									slIzquierda = Strings.Mid(slNombreEmpresa, 1, slNombreEmpresa.IndexOf(' '));
								} else
								{
									slIzquierda = slNombreEmpresa;
								}
								slDerecha = slNombreEmpresa.Substring(slNombreEmpresa.Length - Math.Min(slNombreEmpresa.Length, slNombreEmpresa.Length - slIzquierda.Length)).TrimStart();
								slNombreEmpresa = slIzquierda + "/" + slDerecha;
								
								slRenglon = new StringBuilder(" "); // INT-A-OPCION       PIC  X(01).
								int tempRefParam = 4;
								string tempRefParam2 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteIzquierda, ref tempRefParam, ref tempRefParam2)); // INT-A-TRANSACCION  PIC  9(04).
								int tempRefParam3 = 12;
								string tempRefParam4 = " ";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteIzquierda, ref tempRefParam3, ref tempRefParam4)); // INT-A-CLIENTE      PIC  X(12).
								int tempRefParam5 = 55;
								string tempRefParam6 = " ";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 1), cteJustificado.cteIzquierda, ref tempRefParam5, ref tempRefParam6)); // INT-A-NOMBRE-COMPLETO          PIC  X(55).
								int tempRefParam7 = 26;
								string tempRefParam8 = " ";
								slRenglon.Append(sfncJustificar(slNombreEmpresa, cteJustificado.cteIzquierda, ref tempRefParam7, ref tempRefParam8)); // INT-A-NOMBRE-PERSONALIZACION   PIC  X(26).
								
								int tempRefParam9 = 4;
								string tempRefParam10 = "0";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 3), cteJustificado.cteDerecha, ref tempRefParam9, ref tempRefParam10)); // INT-A-SUCURSAL     PIC  9(04).
								
								slCadenaAuxiliar = VBSQL.SqlData(CORVAR.hgblConexion, 4);
								slCadenaAuxiliar = Seguridad.fncsSustituir(slCadenaAuxiliar, "-", "");
								slCadenaAuxiliar = Seguridad.fncsSustituir(slCadenaAuxiliar, " ", "");
								int tempRefParam11 = 15;
								string tempRefParam12 = " ";
								slRenglon.Append(sfncJustificar(slCadenaAuxiliar, cteJustificado.cteIzquierda, ref tempRefParam11, ref tempRefParam12)); // INT-A-RFC         PIC  X(15).
								
								int tempRefParam13 = 2;
								string tempRefParam14 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam13, ref tempRefParam14)); // INT-A-TIPO-PERS    PIC  9(02).
								int tempRefParam15 = 2;
								string tempRefParam16 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam15, ref tempRefParam16)); // INT-A-NACIONAL     PIC  9(02).
								int tempRefParam17 = 2;
								string tempRefParam18 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam17, ref tempRefParam18)); // INT-A-SEXO         PIC  9(02).
								int tempRefParam19 = 2;
								string tempRefParam20 = "0";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 5), cteJustificado.cteDerecha, ref tempRefParam19, ref tempRefParam20)); // INT-A-SECTOR       PIC  9(02).
								int tempRefParam21 = 5;
								string tempRefParam22 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam21, ref tempRefParam22)); // INT-A-OCUPACION    PIC  9(05).
								int tempRefParam23 = 2;
								string tempRefParam24 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam23, ref tempRefParam24)); // INT-A-SEGMENTO     PIC  9(02).
								int tempRefParam25 = 2;
								string tempRefParam26 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam25, ref tempRefParam26)); // INT-A-TIPO-DOM1    PIC  9(02).
								int tempRefParam27 = 36;
								string tempRefParam28 = " ";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 6), cteJustificado.cteIzquierda, ref tempRefParam27, ref tempRefParam28)); // INT-A-CALLE1       PIC  X(36).
								int tempRefParam29 = 24;
								string tempRefParam30 = " ";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 7), cteJustificado.cteIzquierda, ref tempRefParam29, ref tempRefParam30)); // INT-A-COLONIA1     PIC  X(24).2
								int tempRefParam31 = 20;
								string tempRefParam32 = " ";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 9), cteJustificado.cteIzquierda, ref tempRefParam31, ref tempRefParam32)); // INT-A-POBLACION1   PIC  X(20).
								//Aplicar Proceso de conversión de clave de estado
								slCadenaAuxiliar = ifncNumEstado(VBSQL.SqlData(CORVAR.hgblConexion, 10)).ToString();
								int tempRefParam33 = 2;
								string tempRefParam34 = "0";
								slRenglon.Append(sfncJustificar(Conversion.Val(slCadenaAuxiliar).ToString(), cteJustificado.cteDerecha, ref tempRefParam33, ref tempRefParam34)); // INT-A-EDO1         PIC  9(02).
								
								int tempRefParam35 = 6;
								string tempRefParam36 = "0";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 11), cteJustificado.cteDerecha, ref tempRefParam35, ref tempRefParam36)); // INT-A-COD-POS1     PIC  9(06).
								int tempRefParam37 = 10;
								string tempRefParam38 = "0";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 13), cteJustificado.cteDerecha, ref tempRefParam37, ref tempRefParam38)); // INT-A-TELEFONO1    PIC  9(10).
								int tempRefParam39 = 6;
								string tempRefParam40 = "0";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 14), cteJustificado.cteDerecha, ref tempRefParam39, ref tempRefParam40)); // INT-A-EXTENSION1   PIC  9(06).
								int tempRefParam41 = 2;
								string tempRefParam42 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam41, ref tempRefParam42)); // INT-A-TIPO-DOM2    PIC  9(02).
								int tempRefParam43 = 36;
								string tempRefParam44 = " ";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 15), cteJustificado.cteIzquierda, ref tempRefParam43, ref tempRefParam44)); // INT-A-CALLE2       PIC  X(36).
								int tempRefParam45 = 24;
								string tempRefParam46 = " ";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 16), cteJustificado.cteIzquierda, ref tempRefParam45, ref tempRefParam46)); // INT-A-COLONIA2     PIC  X(24).
								int tempRefParam47 = 20;
								string tempRefParam48 = " ";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 18), cteJustificado.cteIzquierda, ref tempRefParam47, ref tempRefParam48)); // INT-A-POBLACION2   PIC  X(20).
								
								//Aplicar Proceso de conversión de clave de estado
								slCadenaAuxiliar = ifncNumEstado(VBSQL.SqlData(CORVAR.hgblConexion, 19)).ToString();
								int tempRefParam49 = 2;
								string tempRefParam50 = "0";
								slRenglon.Append(sfncJustificar(Conversion.Val(slCadenaAuxiliar).ToString(), cteJustificado.cteDerecha, ref tempRefParam49, ref tempRefParam50)); // INT-A-EDO2         PIC  9(02).
								
								int tempRefParam51 = 6;
								string tempRefParam52 = " ";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 20), cteJustificado.cteIzquierda, ref tempRefParam51, ref tempRefParam52)); // INT-A-COD-POS2     PIC  9(06).
								int tempRefParam53 = 10;
								string tempRefParam54 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam53, ref tempRefParam54)); // INT-A-TELEFONO2    PIC  9(10).
								int tempRefParam55 = 6;
								string tempRefParam56 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam55, ref tempRefParam56)); // INT-A-EXTENSION2   PIC  9(06).
								int tempRefParam57 = 8;
								string tempRefParam58 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam57, ref tempRefParam58)); // INT-A-FEC-ALTA-CLI PIC  9(08).
								int tempRefParam59 = 2;
								string tempRefParam60 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam59, ref tempRefParam60)); // INT-A-STATUS-CLI   PIC  9(02).
								int tempRefParam61 = 4;
								string tempRefParam62 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam61, ref tempRefParam62)); // INT-A-NUM-PROD     PIC  9(04).
								int tempRefParam63 = 4;
								string tempRefParam64 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam63, ref tempRefParam64)); // INT-A-NUM-INST     PIC  9(04).
								slRenglon.Append(slCuenta); // INT-A-PLASTICO     PIC  9(16).
								
								int tempRefParam65 = 2;
								string tempRefParam66 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam65, ref tempRefParam66)); // INT-A-MONEDA       PIC  9(02).
								int tempRefParam67 = 2;
								string tempRefParam68 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam67, ref tempRefParam68)); // INT-A-MANEJO       PIC  9(02).
								int tempRefParam69 = 1;
								string tempRefParam70 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam69, ref tempRefParam70)); // INT-A-USO-CTA      PIC  9(01).
								int tempRefParam71 = 2;
								string tempRefParam72 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam71, ref tempRefParam72)); // INT-A-BCA-ELECT    PIC  9(02).
								int tempRefParam73 = 4;
								string tempRefParam74 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam73, ref tempRefParam74)); // INT-A-ENVIO-CORR   PIC  9(04).
								int tempRefParam75 = 2;
								string tempRefParam76 = "0";
								slRenglon.Append(sfncJustificar(VBSQL.SqlData(CORVAR.hgblConexion, 24), cteJustificado.cteDerecha, ref tempRefParam75, ref tempRefParam76)); // INT-A-CORTE        PIC  9(02).
								int tempRefParam77 = 8;
								string tempRefParam78 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam77, ref tempRefParam78)); // INT-A-FEC-ALTA-CTA PIC  9(08).
								int tempRefParam79 = 2;
								string tempRefParam80 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam79, ref tempRefParam80)); // INT-A-STATUS-CTA   PIC  9(02).
								int tempRefParam81 = 8;
								string tempRefParam82 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam81, ref tempRefParam82)); // INT-A-FEC-NACIM    PIC  9(08).
								
								int tempRefParam83 = 4;
								string tempRefParam84 = "0";
								slCadenaAuxiliar = sfncJustificar(StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 25), "####"), cteJustificado.cteDerecha, ref tempRefParam83, ref tempRefParam84);
								int tempRefParam85 = 12;
								string tempRefParam86 = "0";
								slCadenaAuxiliar = slCadenaAuxiliar + sfncJustificar(StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 26), "############"), cteJustificado.cteDerecha, ref tempRefParam85, ref tempRefParam86);
								int tempRefParam87 = 16;
								string tempRefParam88 = "0";
								slRenglon.Append(sfncJustificar(slCadenaAuxiliar, cteJustificado.cteDerecha, ref tempRefParam87, ref tempRefParam88)); // INT-A-TARJ-REFER1  PIC  9(16).
								
								int tempRefParam89 = 16;
								string tempRefParam90 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam89, ref tempRefParam90)); // INT-A-TARJ-REFER2  PIC  9(16).
								int tempRefParam91 = 10;
								string tempRefParam92 = "0";
								slRenglon.Append(sfncJustificar("0", cteJustificado.cteDerecha, ref tempRefParam91, ref tempRefParam92)); // INT-A-NOMINA       PIC  9(10).
								int tempRefParam93 = 3;
								string tempRefParam94 = " ";
								slRenglon.Append(sfncJustificar(" ", cteJustificado.cteIzquierda, ref tempRefParam93, ref tempRefParam94)); // INT-A-TPO-OPER     PIC  X(03).
								int tempRefParam95 = 6;
								string tempRefParam96 = " ";
								slRenglon.Append(sfncJustificar(" ", cteJustificado.cteIzquierda, ref tempRefParam95, ref tempRefParam96)); // FILLER             PIC  X(06).
								//Cuenta Individual o Ejecutivo
								FileSystem.PrintLine(ilArchivoDisponible, slRenglon.ToString());
							}
						MessageBox.Show("Se almacenaron " + ilIndice.ToString() + " registros en el archivo " + slArchivo, "Tarjetas Corporativas", MessageBoxButtons.OK, MessageBoxIcon.Information);
						FileSystem.FileClose(ilArchivoDisponible);
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				
				prObtenError("GenerarCuentasCorp");
			}
		}
		
		static public int ifncNumEstado( string spEstado)
		{
			int result = 0;
			string[, ] aslEstados = ArraysHelper.InitializeArray<string[, ]>(new int[]{2, 33}, new int[]{0, 0});
			try
			{
					aslEstados[1, 0] = "DF ";
					aslEstados[0, 0] = "1";
					aslEstados[1, 1] = "AGS";
					aslEstados[0, 1] = "2";
					aslEstados[1, 2] = "BCN";
					aslEstados[0, 2] = "3";
					aslEstados[1, 3] = "BCS";
					aslEstados[0, 3] = "4";
					aslEstados[1, 4] = "CAM";
					aslEstados[0, 4] = "5";
					aslEstados[1, 5] = "COA";
					aslEstados[0, 5] = "6";
					aslEstados[1, 6] = "COL";
					aslEstados[0, 6] = "7";
					aslEstados[1, 7] = "CHS";
					aslEstados[0, 7] = "8";
					aslEstados[1, 8] = "CHI";
					aslEstados[0, 8] = "9";
					aslEstados[1, 9] = "DGO";
					aslEstados[0, 9] = "10";
					aslEstados[1, 10] = "GTO";
					aslEstados[0, 10] = "11";
					aslEstados[1, 11] = "GRO";
					aslEstados[0, 11] = "12";
					aslEstados[1, 12] = "HGO";
					aslEstados[0, 12] = "13";
					aslEstados[1, 13] = "JAL";
					aslEstados[0, 13] = "14";
					aslEstados[1, 14] = "EM ";
					aslEstados[0, 14] = "15";
					aslEstados[1, 15] = "MCH";
					aslEstados[0, 15] = "16";
					aslEstados[1, 16] = "MOR";
					aslEstados[0, 16] = "17";
					aslEstados[1, 17] = "NAY";
					aslEstados[0, 17] = "18";
					aslEstados[1, 18] = "NL ";
					aslEstados[0, 18] = "19";
					aslEstados[1, 19] = "OAX";
					aslEstados[0, 19] = "20";
					aslEstados[1, 20] = "PUE";
					aslEstados[0, 20] = "21";
					aslEstados[1, 21] = "QRO";
					aslEstados[0, 21] = "22";
					aslEstados[1, 22] = "QROO";
					aslEstados[0, 22] = "23";
					aslEstados[1, 23] = "SLP";
					aslEstados[0, 23] = "24";
					aslEstados[1, 24] = "SIN";
					aslEstados[0, 24] = "25";
					aslEstados[1, 25] = "SON";
					aslEstados[0, 25] = "26";
					aslEstados[1, 26] = "TAB";
					aslEstados[0, 26] = "27";
					aslEstados[1, 27] = "TAM";
					aslEstados[0, 27] = "28";
					aslEstados[1, 28] = "TLX";
					aslEstados[0, 28] = "29";
					aslEstados[1, 29] = "VER";
					aslEstados[0, 29] = "30";
					aslEstados[1, 30] = "YUC";
					aslEstados[0, 30] = "31";
					aslEstados[1, 31] = "ZAC";
					aslEstados[0, 31] = "32";
					aslEstados[1, 32] = "   ";
					aslEstados[0, 32] = "33";
					for (mdlParametros.ilIndice = 0; mdlParametros.ilIndice <= aslEstados.GetUpperBound(1); mdlParametros.ilIndice++)
					{
						if (aslEstados[1, mdlParametros.ilIndice].Trim().ToUpper() == spEstado.Trim().ToUpper())
						{
							result = Int32.Parse(aslEstados[0, mdlParametros.ilIndice]);
							break;
						}
					}
				}
			catch 
			{
				
				prObtenError("NumEstado");
			}
			return result;
		}
		
		static public bool bfncValidaRFC( string spRFC)
		{
			bool result = false;
			int ilDia = 0;
			int ilMes = 0;
			int ilAño = 0;
			string slHomoclave = String.Empty;
			string slSiglas = String.Empty;
			string slTitulo = String.Empty;
			try
			{
					spRFC = Seguridad.fncsSustituir(spRFC.Trim(), "-", "");
					slTitulo = "RFC Incorrecto";
					switch(spRFC.Length)
					{
						case 10 :  //AAAA800101 Persona Fisica sin Homoclave 
							slSiglas = Strings.Mid(spRFC, 1, 4).Trim(); 
							ilDia = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 9, 2).Trim())); 
							ilMes = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 7, 2).Trim())); 
							ilAño = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 5, 2).Trim())); 
							slHomoclave = ""; 
							//  Case 11 'AAAA-800101 
							//    slSiglas = Trim(Mid(spRFC, 1, 4)) 
							//    ilDia = Val(Trim(Mid(spRFC, 10, 2))) 
							//    ilMes = Val(Trim(Mid(spRFC, 8, 2))) 
							//    ilAño = Val(Trim(Mid(spRFC, 6, 2))) 
							//    slHomoclave = "" 
							break;
						case 12 :  //AAA800101YYY  Persona Moral 
							slSiglas = Strings.Mid(spRFC, 1, 3).Trim(); 
							ilDia = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 8, 2).Trim())); 
							ilMes = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 6, 2).Trim())); 
							ilAño = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 4, 2).Trim())); 
							slHomoclave = Strings.Mid(spRFC, 10, 3).Trim(); 
							break;
						case 13 :  //AAAA800101UUU  Persona Física con homoclave 
							slSiglas = Strings.Mid(spRFC, 1, 4).Trim(); 
							ilDia = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 9, 2).Trim())); 
							ilMes = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 7, 2).Trim())); 
							ilAño = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 5, 2).Trim())); 
							slHomoclave = Strings.Mid(spRFC, 11, 3).Trim(); 
							//  Case 14 'AAA-800101-YYY  Persona Moral con homoclave y separadores 
							//    slSiglas = Trim(Mid(spRFC, 1, 3)) 
							//    ilDia = Val(Trim(Mid(spRFC, 9, 2))) 
							//    ilMes = Val(Trim(Mid(spRFC, 7, 2))) 
							//    ilAño = Val(Trim(Mid(spRFC, 5, 2))) 
							//    slHomoclave = Trim(Mid(spRFC, 12, 3)) 
							//  Case 15 'AAAA-800101-YYY  Persona Física con homoclave y separadores 
							//    slSiglas = Trim(Mid(spRFC, 1, 4)) 
							//    ilDia = Val(Trim(Mid(spRFC, 10, 2))) 
							//    ilMes = Val(Trim(Mid(spRFC, 8, 2))) 
							//    ilAño = Val(Trim(Mid(spRFC, 6, 2))) 
							//    slHomoclave = Trim(Mid(spRFC, 13, 3)) 
							break;
						default:
							MessageBox.Show("RFC incompleto" + "\r\n" + "Verifique el RFC.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information); 
							return false;
					}
					//Valida Siglas
					for (int ilIndice = 1; ilIndice <= slSiglas.Length; ilIndice++)
					{
						int switchVar = (int) Strings.Mid(slSiglas, ilIndice, 1).ToUpper()[0];
						if (switchVar >= 65 && switchVar <= 90)
						{
							slSiglas = StringsHelper.MidAssignment(slSiglas, ilIndice, Strings.Mid(slSiglas, ilIndice, 1).ToUpper());
						} else
						{
							MessageBox.Show("RFC incorrecto" + "\r\n" + "Caracter no valido en las siglas del RFC", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
					}
					
					//Valida Año
					if (! (ilAño >= 0 && ilAño <= 99))
					{
						MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el Año.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					//Valida Mes
					if (! (ilMes > 0 && ilMes <= 12))
					{
						MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el Mes.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					
					//Valida el Día del RFC
					if (ilMes == 1 || ilMes == 3 || ilMes == 5 || ilMes == 7 || ilMes == 8 || ilMes == 10 || ilMes == 12)
					{
						if (ilDia >= 1 && ilDia <= 31)
						{
						} else
						{
							MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el día.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
					} else if (ilMes == 4 || ilMes == 6 || ilMes == 9 || ilMes == 11) { 
						if (ilDia >= 1 && ilDia <= 30)
						{
						} else
						{
							MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el día.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
					} else if (ilMes == 2) { 
						if (ilDia >= 1 && ilDia <= 29)
						{
							if (! Information.IsDate(StringsHelper.Format(ilDia, "00") + "/" + StringsHelper.Format(ilMes, "00") + "/" + StringsHelper.Format(ilAño, "00")))
							{
								MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el día.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
								return false;
							}
						} else
						{
							MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el día.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
					}
					
					//Valida la Homoclave
					if (slHomoclave.Trim() == "" && Seguridad.fncsSustituir(spRFC, "-", "").Trim().Length == 10)
					{
						if (MessageBox.Show("RFC incompleto" + "\r\n" + "No ha especificado la homoclave." + "\r\n" + "¿Desea continuar?", slTitulo, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							result = true;
						} else
						{
							return false;
						}
					}
					if (slHomoclave.Length != 3)
					{
						if (! result)
						{
							MessageBox.Show("RFC incorrecto" + "\r\n" + "Homoclave incompleta o no válida.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
							return false;
						}
					}
					return true;
				}
			catch 
			{
				
				prObtenError("ValidaRFC");
			}
			return result;
		}
		
		
		static public bool bfncValidaMail( string spMail)
		{
			try
			{
					//Valida que exista una Arrboba (@) en un texto tipo mail
					
					if ((spMail.IndexOf('@') + 1) == 0)
					{
						return false;
					} else
					{
						return true;
					}
				}
			catch 
			{
				
				prObtenError("ValidaMail");
			}
			return false;
		}
		
		static public string sfncEliminaCaracteresDeUnaCadenaEnOtra(ref  string spCadenaOriginal,  string spCaracteresAEliminar)
		{
			//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
			if (! String.IsNullOrEmpty(spCaracteresAEliminar.Trim()) || spCaracteresAEliminar.Trim() != "")
			{
				for (int ilIndice = 1; ilIndice <= spCaracteresAEliminar.Trim().Length; ilIndice++)
				{
					spCadenaOriginal = Seguridad.fncsSustituir(spCadenaOriginal, Strings.Mid(spCaracteresAEliminar, ilIndice, 1), "");
				}
			}
			return spCadenaOriginal;
		}
		
		
		
		static public void  prCargaSQLCombo( string spSQL,  ComboBox cboCombo,  string spSeparador,  int ilColIndice,  int ilColDescripcion)
		{
			int ilIndice = 0;
			try
			{
					//Carga los estados de la república mexicana en un arreglo
					Cursor.Current = Cursors.WaitCursor;
					CORVAR.pszgblsql = spSQL;
					prPreparaConsulta(ref CORVAR.hgblConexion);
					
					if (spSQL.Trim() == "")
					{
						return;
					}
					if (cboCombo.Items.Count > 0)
					{
						cboCombo.Items.Clear();
					}
					if (spSeparador.Trim() == "")
					{
						spSeparador = CRSParametros.cteSeparador;
					}
					if (Conversion.Val(ilColIndice.ToString()) < 1)
					{
						ilColIndice = 1;
					}
					if (Conversion.Val(ilColDescripcion.ToString()) < 1)
					{
						ilColDescripcion = 2;
					}
					
					if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
					{
						do 
						{
							while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
								
									cboCombo.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, ilColIndice).Trim() + spSeparador + VBSQL.SqlData(CORVAR.hgblConexion, ilColDescripcion).Trim());
								}
						}
						while(VBSQL.SqlResults(CORVAR.hgblConexion) != 2);
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
					}
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				prObtenError("CargaSQLCombo");
			}
		}
		
		static public void  prCargaSQLCombo( string spSQL,  ComboBox cboCombo,  string spSeparador,  int ilColIndice)
		{
			prCargaSQLCombo(spSQL, cboCombo, spSeparador, ilColIndice, 0);
		}
		
		
		
		
		static public string vfncVPO( string vlDato,  string vlOmision)
		{
			//***************************************************************
			//*  Descripción     :   Evalua un valor nulo, en caso de encontrarlo devuelve un valor por omisión.
			//*  Autor           :   Héctor Vázquez Vázquez
			//*  Fecha           :   22 de Octubre de 1999
			//***************************************************************
			try
			{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
					if (Convert.IsDBNull(vlDato) || vlDato == "")
					{
						return vlOmision;
					} else
					{
						return vlDato;
					}
				}
			catch 
			{
				
				
				prObtenError("VPO");
			}
			return String.Empty;
		}
	}
}