using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class Formato
	{
	
		static public string sgUni = String.Empty;
		static public int hgblConexion3 = 0;
		static public string pszgblSql3 = String.Empty;
		static public int igLongitudEmpresa = 0;
		static public int igLongitudEjecutivo = 0;
		
		static public bool bgForma = false; //Variable para confirmar que pueda abrir la pantalla de Unidades
		static public string sgForma = String.Empty; //Variable para la Pantalla de Unidades
		static public double igNumUnit = 0; //Variable que almacena el Numero de Unidad para la Pantalla de Unidades
		static public string sgUnit_ID = String.Empty; //Variable que almacena la Unidad de la pantalla CORIRUNI
		static public string sgName_Unit = String.Empty; //Variable que almacena el Nombre de la pantalla CORIRUNI
		
		static public bool bPrimeraVez = false;
		
		const string csCaracterRelleno = "0";
		
		static public string lProdCve = String.Empty;
		static public string lgblprod = String.Empty;
		static public string IdEstruct = String.Empty;
		static public string NomEstruct = String.Empty;
		static public string Identificadorest = String.Empty;
		static public string Nombreest = String.Empty;
		static public string pszAccion = String.Empty;
		static public string idCategoria = String.Empty;
		static public string NomCategoria = String.Empty;
		static public double dMCC = 0;
		static public int columna = 0;
		static public int renglon = 0;
		static public bool primvez = false;
		
		//Estructura para definir la máscara
		public enum iTipo
		 {
			Empresa = 0 ,
			Ejecutivo = 1 ,
			Unidad = 2
		}
		
		
		static public string formato_emp_ejec( string cadena,  string carRell,  string carJus,  int lonFin)
		{
			string formatocuenta = String.Empty;
			int lon = lonFin - cadena.Length;
			switch(carJus)
			{
				case "I" : 
					formatocuenta = new string(carRell[0], lon) + cadena; 
					break;
				case "D" : 
					formatocuenta = cadena + new string(carRell[0], lon); 
					break;
			}
			return formatocuenta;
		}
		
		
		static public string sMascara( iTipo Tipo)
		{
			//------------------------------------------------------------------------------------------------
			//Objetivo:  Obtiene la mascara para Empresa y Ejecutivo
			//Fecha:     03.Octubre.2001
			//Desarrolló:HVV
			//Ultima Modificación:
			//Modificó:
			//------------------------------------------------------------------------------------------------
			string result = String.Empty;
			int iLonguitud = 0;
			int long_Emp = 0;
			int long_eje = 0;
			
			switch(Tipo)
			{
				case iTipo.Empresa : 
					result = new string(csCaracterRelleno[0], igLongitudEmpresa); 
					break;
				case iTipo.Ejecutivo : 
					result = new string(csCaracterRelleno[0], igLongitudEjecutivo); 
					break;
				case iTipo.Unidad : 
					result = new string(csCaracterRelleno[0], 15); 
					break;
			}
			return result;
		}
		
		static public void  prConfiguraLongEmpEje( int ipPrefijo,  int ipBanco)
		{
			//------------------------------------------------------------------------------------------------
			//Objetivo:  Obtiene las longitudes para el formatos de Empresa y Ejecutivo
			//Fecha:     04.Octubre.2001
			//Desarrolló:HVV
			//Ultima Modificación:
			//Modificó:
			//------------------------------------------------------------------------------------------------
			
			pszgblSql3 = "SELECT pgs_long_emp, pgs_long_eje";
			pszgblSql3 = pszgblSql3 + " from MTCPGS01";
			pszgblSql3 = pszgblSql3 + " WHERE pgs_rep_prefijo = " + ipPrefijo.ToString() + " and pgs_rep_banco = " + ipBanco.ToString();
			pszgblSql3 = pszgblSql3 + " and pgs_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";
			if (ifncObtiene_Registros() != 0)
			{
				
				while(VBSQL.SqlNextRow(hgblConexion3) != VBSQL.NOMOREROWS)
				{
					igLongitudEmpresa = Int32.Parse(VBSQL.SqlData(hgblConexion3, 1));
					igLongitudEjecutivo = Int32.Parse(VBSQL.SqlData(hgblConexion3, 2));
				};
			}
			CORVAR.igblRetorna = VBSQL.SqlCancel(hgblConexion3);
		}
		
		
		
		static public int ifncConexionFormato()
		{
			int result = 0;
			int lRetorna = 0;
			int iLogin = 0;
			int hConn = 0;
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					int bConexion = VBSQL.SUCCEED;
					
					CORDBLIB.gsDbLibActiva = VBSQL.SqlInit();
					
					//Verifica el éxito de iniciar la librería
					if (CORDBLIB.gsDbLibActiva != CORVB.NULL_STRING)
					{
						
						if (hConn != CORVB.NULL_INTEGER)
						{
							//ya existían conexiones, por lo tanto se cierran
							VBSQL.SqlClose(hConn);
						}
						
						//Pone el tiempo de espera para Login
						lRetorna = VBSQL.SqlSetLoginTime(10);
						
						//Realiza la conexión
						//hgblConexion = SqlOpenConnection(gsServidor, gsUsuario, gsPassword, NULL_STRING, NULL_STRING)
						hConn = VBSQL.SqlLogin();
						lRetorna = VBSQL.SqlSetLUser(hConn, CORDBLIB.gsUsuario);
						lRetorna = VBSQL.SqlSetLPwd(hConn, CORDBLIB.gsPassword);
						hgblConexion3 = VBSQL.SqlOpen(hConn, CORDBLIB.gsServidor);
						
						if (hgblConexion3 != 0)
						{
							//Tiempo de espera para los queries
							lRetorna = VBSQL.SqlSetTime(CORDBLIB.INT_QUERYTIMEOUT);
							
							//Verifica si es la base de datos requerida
							if (VBSQL.SqlName(hgblConexion3) != CORDBLIB.gsBaseDatos)
							{
								
								if (VBSQL.SqlUse(hgblConexion3, CORDBLIB.gsBaseDatos) != VBSQL.SUCCEED)
								{
									//No hubo éxito en el cambio de base de datos
									bConexion = VBSQL.FAIL;
								}
								
							}
						} else
						{
							bConexion = VBSQL.FAIL;
						}
					} else
					{
						bConexion = VBSQL.FAIL;
					}
					
					result = bConexion;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			return result;
		}
		
		
		static public int ifncObtiene_Registros()
		{
			//------------------------------------------------------------------------------------------------
			//
			// Descripción       Ejecuta una sentencia query de consulta a la BD
			//                   Utiliza las variables globales hgblConexion3 y pszgblSQL.
			//
			// Parámetros        Ninguno
			//
			// Valor de Regreso  Verdadero si se ejecuta correctamente y encuentra información,
			//                   Falso si ocurre un error o no encuentra información.
			//
			//------------------------------------------------------------------------------------------------
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			int result = 0;
			try
			{
					result = 0;
					
					CORDBLIB.giError = CORCONST.OK;
					
					//Ejecuta la sentencia
					CORVAR.igblRetorna = VBSQL.SqlCmd(hgblConexion3, pszgblSql3);
					CORVAR.igblRetorna = VBSQL.SqlExec(hgblConexion3);
					
					if (CORVAR.igblRetorna == VBSQL.SUCCEED)
					{
						//Si ejecutó correctamente
						CORVAR.igblErr = VBSQL.SqlResults(hgblConexion3);
						
						if (VBSQL.SqlRows(hgblConexion3) != 0)
						{
							//Si obtiene registros
							result = -1;
						} else
						{
							CORVAR.igblErr = VBSQL.SqlCancel(hgblConexion3);
						}
						
					} else
					{
						CORVAR.igblErr = VBSQL.SqlCancel(hgblConexion3);
					}
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			return result;
		}
		
		
		static public int lfncDiaCorte( int lpEjePrefijo,  int lpGpoBanco,  int lpNumEmpresa)
		{
			//------------------------------------------------------------------------------------------------
			//Objetivo:  Obtener el valor del día de corte del emp_dia_corte con el prefijo lpEjePrefijo y el número de empresa lpNumEmpresa
			//Fecha:     12.Octubre.2001
			//Desarrolló:HVV
			//Ultima Modificación:
			//Modificó:
			//------------------------------------------------------------------------------------------------
			int result = 0;
			int ilDia = 0;
			pszgblSql3 = "SELECT emp_dia_corte AS DiaCorte";
			pszgblSql3 = pszgblSql3 + " from MTCEMP01";
			pszgblSql3 = pszgblSql3 + " WHERE eje_prefijo = " + lpEjePrefijo.ToString() + " and ";
			pszgblSql3 = pszgblSql3 + " gpo_banco = " + lpGpoBanco.ToString() + " and ";
			pszgblSql3 = pszgblSql3 + " emp_num = " + lpNumEmpresa.ToString();
			if (ifncObtiene_Registros() != 0)
			{
				
				while(VBSQL.SqlNextRow(hgblConexion3) != VBSQL.NOMOREROWS)
				{
					result = Int32.Parse(VBSQL.SqlData(hgblConexion3, 1));
				};
			} else
			{
				result = 0;
			}
			CORVAR.igblRetorna = VBSQL.SqlCancel(hgblConexion3);
			return result;
		}
		
		
		static public int ifncCicloMesDía( int ipCicloMesDíaOrig,  int ipNuevoDia)
		{
			//Valida que sea un a fecha menor a 31 de Diciembre y mayor que el 01 de Enero
			int result = 0;
			if (ipCicloMesDíaOrig <= 1231 && ipCicloMesDíaOrig > 0)
			{
				if (ipNuevoDia > 0 && ipNuevoDia <= 31)
				{ //Verifica que el día no sea mayor al 31, ni menor que 1
					ipCicloMesDíaOrig -= (ipCicloMesDíaOrig % 100);
					result = ipCicloMesDíaOrig + ipNuevoDia;
				} else
				{
					MessageBox.Show("Parámetro de día incorrecto", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} else
			{
				MessageBox.Show("Parámetro de Ciclo Corte Original incorrecto", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return result;
		}
		
		static public int ifncMes( int ipCicloMesDia)
		{
			return ipCicloMesDia / 100;
		}
		
		static public int lfncTop( int ipLongitudCampo)
		{
			return IntValue(new string('9', ipLongitudCampo));
		}

        public static int IntValue(String value)
        {
            int iValue;
            double dValue;

            try
            {
                iValue = Int32.Parse(value);
                if (!Int32.TryParse(value, out iValue))
                {
                    if (double.TryParse(value, out dValue))
                    {
                        try
                        {
                            iValue = Convert.ToInt32(dValue);
                        }
                        catch
                        {
                            iValue = Int32.MinValue;
                        }
                    }
                    else
                        iValue = Int32.MinValue;
                }
            }
            catch (Exception er) {
                iValue = Int32.MinValue;
                throw er; }

            return iValue;
        }

		
		static public string Formato_Cad_Roll_Digit()
		{
			int int_Roll = 0;
			int int_Digit = 0;
			
			CORVAR.pszgblsql = "select eje_roll_over, eje_digit from MTCEJE01";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = 0";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();
			if (CORPROC2.Obtiene_Registros() != 0)
			{
				
				while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
				{
					int_Roll = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))); //Roll
					int_Digit = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2))); //Digit
				};
			}
			
			return int_Roll.ToString() + int_Digit.ToString();
			
		}
	}
}