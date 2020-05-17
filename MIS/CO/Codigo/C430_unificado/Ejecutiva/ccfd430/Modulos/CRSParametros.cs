using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class CRSParametros
	{
	
		//Parametro para la opcion de tipo de SBF
		static public int giccftipo = 0;
		
		//Parametros para la configuración de la empresa
		public const int cteLongitudEmpresaEjecutivo = 8;
		
		//Parámetros de Configuración
		public const string cteFormatoFecha = "dd/mm/yyyy";
		public const string cteFormatoHora = "hh:mm";
		public const string cteSeparadorFecha = "/";

        public enum enmStatusPaso
        {
            SPS_NO_ENCONTRADO = -1,
            SPS_GRABADO_PASO = 0,
            SPS_ALTA_S016_2 = 1,
            SPS_ALTA_S016_S111_1 = 2,
            SPS_ALTA_S016_S111_2 = 3,
            SPS_ALTA_C430 = 4,
            SPS_ALTA_S016_1 = 5,
            SPS_ALTA_FINAL = 7
        }

		
		//Constantes de Generación de Plástico
		public enum GeneracionPlastico
		 {
			cteSiPlasticoSiPIN = 0 ,
			cteNoPlasticoNoPIN = 1 ,
			cteSiPlasticoNoPIN = 2
		}
		
		//Constantes Globales de Generación de SBF
		public enum ValoresSBF
		 {
			cteNoGenerarSBFNoDerivado = 0 ,
			cteNoGenerarSBFSiDerivado = 1 ,
			cteSiGenerarSBFNoDerivado = 2 ,
			cteSiGenerarSBFSiDerivado = 3 ,
			cteSiGenerarSBFCycleDailySiDerivado = 4 ,
			cteSiGenerarSBFCycleDailyNoDerivado = 5
		}
		
		//Parámetros de Crédito
		public const int cteLimiteCredito = 999999999; 
		public const int cteDiaCorte = 17;
		public const int ctePlazoGracia = 15;
		public const string cteMascaraDinero = "###,###,##0.00";
		
		//Parámetro Generales del Sistema
		static public string sgUserID = String.Empty;
        static public string sgPasswd = String.Empty;
		static public string sgUserName = String.Empty;
        static public string sgTokenID = String.Empty;
		public const string cteSeparador = "   ";
		
		//Constantes Generales del Sistema
		public const string cteCorporativo = "C";
		public const string cteEmpresa = "E";
		public const string cteIndividual = "I";
		
		//Constantes para tipos de pago
		public const string ctePagoAutomatico = "A";
		public const string ctePagoIndividual = "I";
		public const string ctePagoLibre = "L";
		
		public const string cteTotal = "T";
		public const string cteMinimo = "M";
		
		public const string cteBusinessCard = "B";
		public const string ctePurchasingCard = "P";
		public const string cteDistributionLine = "D";
		
		//Constantes de la Cuenta
		public const string cteNoCuentaControl = "";
		public const string cteSiCuentaControl = "C";
		
		//Costantes de Nacionalidad
		public const string cteMexicana = "1";
		public const string cteExtranjera = "2";
		
		static public void  prCargaCombo(ref  string spSQL,  ComboBox cboCombo)
		{
			//*******************************************************************************************
			//Objetivo:  Carga un SQL dentro de un Combo, condicionado a que el primer campo sea la clave y el segundo la descripción o texto del combo
			//           contemplando que el primer campo sea numérico.
			//*******************************************************************************************
			try
			{
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
					if (! String.IsNullOrEmpty(spSQL))
					{
						cboCombo.Items.Clear();
						if (CORPROC2.ObtieneRegistros(ref spSQL) != 0)
						{
							cboCombo.Items.Add(new ListBoxItem("NINGUNA", 0));
							while (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
								{
								
									cboCombo.Items.Add(new ListBoxItem(VBSQL.SqlData(CORVAR.hgblConexion, 2), Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
								}
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("CargaCombo",e );
			}
		}
		
		static public int ifncBuscaEnCombo( int lpDato,  ComboBox cboCombo)
		{
			try
			{
					if (cboCombo.Items.Count > 0)
					{
						for (int ilItem = 0; ilItem <= cboCombo.Items.Count - 1; ilItem++)
						{
							if (lpDato == VB6.GetItemData(cboCombo, ilItem))
							{
								return ilItem;
							}
						}
						return -1;
					} else
					{
						return -1;
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("BuscaEnCombo",e );
			}
			return 0;
		}
		
		static public bool bfncExcepcionCredito()
        {
             try
             {
                if (mdlParametros.gprdProducto.PrefijoL == 5584 && 
                    mdlParametros.gprdProducto.BancoL == 26)
                { return true; }
		        else
                { return false; }
             }
             catch (Exception e)
             {
                CRSGeneral.prObtenError("ExcepcionCredito",e );
                return false;
             }
		}
	}
}