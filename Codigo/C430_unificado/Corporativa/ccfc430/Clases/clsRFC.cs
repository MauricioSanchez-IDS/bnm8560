using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsRFC
	{
	
		
		public enum enuTipoPersona
		 {
			tprPersonaFisica = 1 ,
			tprPersonaMoral = 2
		}
		
		private enuTipoPersona mvarTipoPersonaI = (enuTipoPersona) 0;
		private string mvarSiglasS = String.Empty;
		private int mvarAñoI = 0;
		private int mvarMesI = 0;
		private int mvarDiaI = 0;
		private string mvarHomoclaveS = String.Empty;
		private string mvarRFCS = String.Empty;
		private string mvarSeparadorS = String.Empty;
		//Private mvarNoProductLineB As Boolean
        //AIS- NGONZALEZ
		private bool mvarNoProductLineB;
		
		private bool FnEsProductLineB()
		{
			bool result = false;
			ADODB.Recordset rs = null;
			string strMsg = String.Empty;
			try
			{
					string strSql = String.Empty;
					
					if (VBSQL.OpenConn(10) != 0)
					{
						VBSQL.gConn[10].Close();
					} else
					{
						VBSQL.gConn[10].Close();
					}
					
					if (VBSQL.OpenConn(10) == 0)
					{
						rs = new ADODB.Recordset();
						strSql = "Select con_product_line From  MTCCON01  where con_pref = " + CORVAR.igblPref.ToString() + " And con_banco = " + CORVAR.igblBanco.ToString();
						rs.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
						if (rs.EOF && rs.BOF)
						{
							result = Convert.ToDouble(rs.Fields["con_product_line"].Value) == 1;
						} else
						{
							result = false;
						}
						rs.Close();
						rs = null;
						VBSQL.gConn[10].Close();
					}
				}
			catch 
			{
				
				if (VBSQL.gConn[10].Errors.Count > 0)
				{
					strMsg = "Se ha provocado el siguiente error de base de datos";
					for (int intNoError = 0; intNoError <= VBSQL.gConn[10].Errors.Count - 1; intNoError++)
					{
						strMsg = strMsg + "Native Error: " + VBSQL.gConn[10].Errors[intNoError].NativeError.ToString();
						strMsg = strMsg + "Descripcion: " + VBSQL.gConn[10].Errors[intNoError].Description;
					}
					MessageBox.Show(strMsg, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				} else
				{
					MessageBox.Show("Error:" + Information.Err().Number.ToString() + "\r" + Conversion.ErrorToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				
				if (rs.State != 0)
				{
					rs.Close();
				}
				
				if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
				{
					VBSQL.gConn[10].Close();
				}
			}
			
			return result;
		}
		
		public void  prDesglosaRFC( string spRFC,  enuTipoPersona ipTipoPersona)
		{
			
			this.RFCS = spRFC;
			this.TipoPersonaI = ipTipoPersona;
			this.RFCS = fncPreparaRFCS(this.RFCS, "-", "");
			
			double dbNumericTemp = 0;
			if (! Double.TryParse(Strings.Mid(this.RFCS, 4, 1), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
			{
				this.TipoPersonaI = enuTipoPersona.tprPersonaFisica;
			} else
			{
				this.TipoPersonaI = enuTipoPersona.tprPersonaMoral;
			}
			
			if (fncValidaRFCB(this.RFCS, TipoPersonaI))
			{
				if (TipoPersonaI == enuTipoPersona.tprPersonaFisica)
				{
					SiglasS = RFCS.Substring(0, Math.Min(RFCS.Length, 4));
					AñoI = StringsHelper.IntValue(Strings.Mid(RFCS, 5, 2));
					MesI = StringsHelper.IntValue(Strings.Mid(RFCS, 7, 2));
					DiaI = StringsHelper.IntValue(Strings.Mid(RFCS, 9, 2));
					if (Strings.Mid(RFCS, 11, 3) != "")
					{
						HomoclaveS = Strings.Mid(RFCS, 11, 3);
					}
				} else if (TipoPersonaI == enuTipoPersona.tprPersonaMoral) { 
					SiglasS = RFCS.Substring(0, Math.Min(RFCS.Length, 3));
					AñoI = StringsHelper.IntValue(Strings.Mid(RFCS, 4, 2));
					MesI = StringsHelper.IntValue(Strings.Mid(RFCS, 6, 2));
					DiaI = StringsHelper.IntValue(Strings.Mid(RFCS, 8, 2));
					HomoclaveS = Strings.Mid(RFCS, 10, 3);
				}
			}
			
		}
		
		public bool fncValidaRFCB( string spRFC,  enuTipoPersona ipTipoPersona)
		{
			
			this.RFCS = spRFC;
			this.TipoPersonaI = ipTipoPersona;
			this.RFCS = fncPreparaRFCS(this.RFCS, "-", "").Trim();
			
			if (this.TipoPersonaI == enuTipoPersona.tprPersonaFisica)
			{
				if (Strings.Len(this.RFCS) == 10 || Strings.Len(this.RFCS) == 13)
				{
					for (int ilCont = 1; ilCont <= 4; ilCont++)
					{
						if (ilCont != 4)
						{
							double dbNumericTemp = 0;
							if (Double.TryParse(Strings.Mid(this.RFCS, ilCont, 1), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) || Strings.Mid(this.RFCS, ilCont, 1).Trim() == "")
							{
								MessageBox.Show("RFC invalido. Verifique que las siglas del RFC sean solo letras.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return false;
							}
						} else
						{
							//El cuarto caracter del RFC es opcional cuando el producto es product line
							double dbNumericTemp2 = 0;
							if (Double.TryParse(Strings.Mid(this.RFCS, ilCont, 1), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2) || (Strings.Mid(this.RFCS, ilCont, 1).Trim() == "" && mvarNoProductLineB))
							{
								MessageBox.Show("RFC invalido. Verifique que las siglas del RFC sean solo letras.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return false;
							}
						}
					}
				} else
				{
					MessageBox.Show("RFC invalido. Verifique la longitud del RFC.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
				if (! Information.IsDate(StringsHelper.Format(Strings.Mid(this.RFCS, 9, 2), "00") + "/" + StringsHelper.Format(Strings.Mid(this.RFCS, 7, 2), "00") + "/" + StringsHelper.Format(Strings.Mid(this.RFCS, 5, 2), "00")))
				{
					if (Strings.Mid(this.RFCS, 7, 2).Trim() == "")
					{
						MessageBox.Show("RFC invalido. Verifique el Mes del RFC.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
					
					if (StringsHelper.IntValue(StringsHelper.Format(Strings.Mid(this.RFCS, 7, 2), "00")) < 1 || StringsHelper.IntValue(StringsHelper.Format(Strings.Mid(this.RFCS, 7, 2), "00")) > 12)
					{
						MessageBox.Show("RFC invalido. Verifique el Mes del RFC.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					} else
					{
						MessageBox.Show("RFC invalido. Verifique el Dia del RFC.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				
			} else if (this.TipoPersonaI == enuTipoPersona.tprPersonaMoral) { 
				if (Strings.Len(this.RFCS) == 12)
				{
					for (int ilCont = 1; ilCont <= 3; ilCont++)
					{
						if (ilCont == 1)
						{
							double dbNumericTemp3 = 0;
							if (Double.TryParse(Strings.Mid(this.RFCS, ilCont, 1), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
							{
								MessageBox.Show("RFC invalido. Verifique que las siglas del RFC sean solo letras.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
								return false;
							}
						}
					}
				} else
				{
					MessageBox.Show("RFC invalido. Verifique la longitud del RFC.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
				if (! Information.IsDate(StringsHelper.Format(Strings.Mid(this.RFCS, 8, 2), "00") + "/" + StringsHelper.Format(Strings.Mid(this.RFCS, 6, 2), "00") + "/" + StringsHelper.Format(Strings.Mid(this.RFCS, 4, 2), "00")))
				{
					if (StringsHelper.IntValue(StringsHelper.Format(Strings.Mid(this.RFCS, 6, 2), "00")) < 1 || StringsHelper.IntValue(StringsHelper.Format(Strings.Mid(this.RFCS, 6, 2), "00")) > 12)
					{
						MessageBox.Show("RFC invalido. Verifique el Mes del RFC.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					} else
					{
						MessageBox.Show("RFC invalido. Verifique el Dia del RFC.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				}
				if (Strings.Mid(this.RFCS, 10, 3) == "")
				{
					MessageBox.Show("RFC invalido. Verifique que tenga homoclave el RFC.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
			}
			return true;
			
		}
		
		public string fncConstruyeRfcS( bool bpSeparador)
		{
			
			string result = String.Empty;
			prDesglosaRFC(this.RFCS, this.TipoPersonaI);
			if (! bpSeparador)
			{
				if (HomoclaveS != "")
				{
					result = SiglasS + StringsHelper.Format(AñoI, "00") + StringsHelper.Format(MesI, "00") + StringsHelper.Format(DiaI, "00") + HomoclaveS;
				} else if (HomoclaveS == "") { 
					result = SiglasS + StringsHelper.Format(AñoI, "00") + StringsHelper.Format(MesI, "00") + StringsHelper.Format(DiaI, "00");
				}
			} else
			{
				if (HomoclaveS != "")
				{
					result = SiglasS + mdlParametros.ctesSeparadorRFC + StringsHelper.Format(AñoI, "00") + StringsHelper.Format(MesI, "00") + StringsHelper.Format(DiaI, "00") + mdlParametros.ctesSeparadorRFC + HomoclaveS;
				} else if (HomoclaveS == "") { 
					result = SiglasS + mdlParametros.ctesSeparadorRFC + StringsHelper.Format(AñoI, "00") + StringsHelper.Format(MesI, "00") + StringsHelper.Format(DiaI, "00") + mdlParametros.ctesSeparadorRFC;
				}
			}
			
			return result;
		}
		
		private string fncPreparaRFCS( string spCadena,  string spCadenaActual,  string spNuevaCadena)
		{
			
			string slCadena1 = String.Empty;
			string slCadena2 = String.Empty;
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
					if (Convert.IsDBNull(spCadena) || spCadena == "")
					{
						return String.Empty;
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
					if (Convert.IsDBNull(spCadenaActual) || spCadenaActual == "")
					{
						return String.Empty;
					}
					int ilPosicion = 0;
					int ilTerminacion = 0;
					if (! (((spCadenaActual.IndexOf(spNuevaCadena, StringComparison.CurrentCultureIgnoreCase) + 1) & ((spNuevaCadena != "") ? -1: 0)) != 0))
					{
						
						ilPosicion = (spCadena.IndexOf(spCadenaActual, StringComparison.CurrentCultureIgnoreCase) + 1);
						ilTerminacion = ilPosicion + spCadenaActual.Length;
						if (ilPosicion > 0)
						{
							slCadena1 = spCadena.Substring(0, Math.Min(spCadena.Length, ilPosicion - 1));
							slCadena2 = Strings.Mid(spCadena, ilTerminacion, spCadena.Length);
							spCadena = slCadena1 + spNuevaCadena + slCadena2;
							spCadena = fncPreparaRFCS(spCadena, spCadenaActual, spNuevaCadena);
						}
						
					}
					
					
					return spCadena;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
			return String.Empty;
		}
		
		
		public string SeparadorS
		{
			get
			{
				return mvarSeparadorS;
			}
			set
			{
				mvarSeparadorS = value;
			}
		}
		
		
		
		public string RFCS
		{
			get
			{
				return mvarRFCS;
			}
			set
			{
				mvarRFCS = value;
			}
		}
		
		
		
		public string HomoclaveS
		{
			get
			{
				return mvarHomoclaveS;
			}
			set
			{
				mvarHomoclaveS = value;
			}
		}
		
		
		
		public int DiaI
		{
			get
			{
				return mvarDiaI;
			}
			set
			{
				mvarDiaI = value;
			}
		}
		
		
		
		public int MesI
		{
			get
			{
				return mvarMesI;
			}
			set
			{
				mvarMesI = value;
			}
		}
		
		
		
		public int AñoI
		{
			get
			{
				return mvarAñoI;
			}
			set
			{
				mvarAñoI = value;
			}
		}
		
		
		
		public string SiglasS
		{
			get
			{
				return mvarSiglasS;
			}
			set
			{
				mvarSiglasS = value;
			}
		}
		
		
		
		public enuTipoPersona TipoPersonaI
		{
			get
			{
				return mvarTipoPersonaI;
			}
			set
			{
				mvarTipoPersonaI = value;
			}
		}
		
		
		public clsRFC(){
			
			//UPGRADE_WARNING: (6021) Casting 'byte' to Enum may cause different behaviour.
			TipoPersonaI = (enuTipoPersona) 0;
			SiglasS = "";
			AñoI = 0;
			MesI = 0;
			DiaI = 0;
			HomoclaveS = "";
			RFCS = "";
			SeparadorS = mdlParametros.ctesSeparadorRFC;
			//Indica si el valor de la cuenta bancaria es un product line
			//por lo que el 4/o caracter del rfc es opcional
		}
	
	~clsRFC(){
		
		//UPGRADE_WARNING: (6021) Casting 'byte' to Enum may cause different behaviour.
		TipoPersonaI = (enuTipoPersona) 0;
		SiglasS = "";
		AñoI = 0;
		MesI = 0;
		DiaI = 0;
		HomoclaveS = "";
		RFCS = "";
		SeparadorS = mdlParametros.ctesSeparadorRFC;
		
	}
}
}