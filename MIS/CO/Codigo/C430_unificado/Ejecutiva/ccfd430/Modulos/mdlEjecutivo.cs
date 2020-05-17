using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class mdlEjecutivo
	{
	
		
		//Variable global del objeto datos ejecutivo
		//Global gdteEjecutivo    As clsDatosEjecutivo
		
		//Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
		//Global gdteEjeExists    As clsDatosEjecutivo
		
		//Variable para la Validacion de Informacion
		static public string smValidaInf = String.Empty;
		static public int lmEmpCredTot = 0;
		static public int lmEmpCredAcum = 0;
		
		//Variable para el dialogo
		//Global gdlgDialogoS016          As clsDialogo
		//Global gdlgDialogoS111          As clsDialogo
		
		public enum enuTipoConsultaEjecutivo
		 {
			tcneConsultaAlta = 0 ,
			tcneConsultaCambio = 1 ,
			tcneConsultaConsulta = 2
		}
		
		public enum enuTipoAltaEjecutivo
		 {
			taejAltaIndividual = 0 ,
			taejAltaMasiva = 1
		}
		
		public enum enuTipoAltaSistema
		 {
			tasAltaS016 = 0 ,
			tasAltaS111 = 1
		}
		
		//Variables para Limite de Credito
		static public clsDialogo gdlgConexionConComDrive = null;
		
		static public string fncCuentaPadreS( int lpPrefijo,  int lpBanco,  int lpEmpresa)
		{
			string result = String.Empty;
			string slCuenta = String.Empty;
			ADODB.Recordset adorst = null;
			string strCuentaPadre = String.Empty;
			string strCuentaCiti = String.Empty;
			
			try
			{
					
					result = "000000000000000";
					
					if (VBSQL.OpenConn(10) != 0)
					{
						VBSQL.gConn[10].Close();
					} else
					{
						VBSQL.gConn[10].Close();
					}
					
					if (VBSQL.OpenConn(10) == 0)
					{
						adorst = new ADODB.Recordset();
						
						CORVAR.pszgblsql = "select convert(char(4), c.eje_prefijo) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(char(2),c.gpo_banco) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', (select i.pgs_long_emp from MTCPGS01 i ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "Where i.pgs_rep_prefijo = c.eje_prefijo ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "and i.pgs_rep_banco = c.gpo_banco) - char_length(ltrim(rtrim(str(c.emp_num))))) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(rtrim(str(c.emp_num))) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', (select i.pgs_long_eje from MTCPGS01 i ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "Where i.pgs_rep_prefijo = c.eje_prefijo ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "and i.pgs_rep_banco = c.gpo_banco) - char_length(ltrim(rtrim(str(c.eje_num))))) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(rtrim(str(c.eje_num))) + convert(char(1),c.eje_roll_over) + ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(char(1),c.eje_digit) as Cta ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "From  MTCEJE01 c  Where c.eje_prefijo = " + lpPrefijo.ToString() + " and c.gpo_banco = " + lpBanco.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + lpEmpresa.ToString() + " and c.eje_num = 0";
						
						adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
						
						if (! adorst.EOF && ! adorst.BOF)
						{
							strCuentaPadre = Convert.ToString(adorst.Fields["Cta"].Value);
						}
						
						adorst.Close();
						
						CORVAR.pszgblsql = "select map_cta_citi ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "From MTCMAP01  where map_cta_bnx = '" + strCuentaPadre + "' ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and map_estatus = ''";
						
						
						adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
						
						if (! adorst.EOF && ! adorst.BOF)
						{
							strCuentaCiti = Convert.ToString(adorst.Fields["map_cta_citi"].Value);
						}
						
						adorst.Close();
						adorst = null;
						
						if (strCuentaCiti == "")
						{
							result = strCuentaPadre;
						} else
						{
							result = strCuentaCiti;
						}
						
						if (VBSQL.gConn[10].State == 1)
						{
							VBSQL.gConn[10].Close();
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEjecutivo (CuentaPadre)",e );
				if (adorst.State != 0)
				{
					adorst.Close();
				}
				
				if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
				{
					VBSQL.gConn[10].Close();
				}
				
				return result;
			}
			
			return result;
		}
		
		static public bool fncObtenNominaPassB( int lpNomina,  string spPassword)
		{
			
			bool result = false;
			int ilEdo = 0;
			FixedLengthString slNomina = new FixedLengthString(4);
			FixedLengthString slPassword = new FixedLengthString(8);
			
			try
			{
					
					Cursor.Current = Cursors.WaitCursor;
					
					slNomina.Value = new string((char) 0, 4);
					slPassword.Value = new string((char) 255, 8);
					//AIS-1182 NGONZALEZ
					ilEdo = API.Encryption.iCompactaNomina(lpNomina, slNomina.Value);
                    //AIS-1182 NGONZALEZ
                    ilEdo = API.Encryption.iCompactaPasswd(spPassword, slPassword.Value);
					
					mdlParametros.tgCveAccesoConComdrive.NominaS = slNomina.Value;
					mdlParametros.tgCveAccesoConComdrive.ClaveS = slPassword.Value;
					
					result = true;
					
					Cursor.Current = Cursors.Default;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEjecutivo (ObtenNominaPass)",e );
				result = false;
				Cursor.Current = Cursors.Default;
				return result;
			}
			
			return result;
		}
		
		static public string fncSucursalS( int lpPrefijo,  int lpBanco,  int lpEmpresa)
		{
			string result = String.Empty;
			string slCuenta = String.Empty;
			ADODB.Recordset adorst = null;
			
			try
			{
					
					if (VBSQL.OpenConn(10) != 0)
					{
						VBSQL.gConn[10].Close();
					} else
					{
						VBSQL.gConn[10].Close();
					}
					
					if (VBSQL.OpenConn(10) == 0)
					{
						adorst = new ADODB.Recordset();
						
						CORVAR.pszgblsql = "SELECT emp_sucur ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCEMP01 ";
						CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE eje_prefijo = " + lpPrefijo.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + "AND gpo_banco = " + lpBanco.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + "AND emp_num = " + lpEmpresa.ToString();
						
						adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);
						
						if (! adorst.EOF && ! adorst.BOF)
						{
							result = Convert.ToString(adorst.Fields["emp_sucur"].Value);
						}
						
						adorst.Close();
						
						adorst = null;
						
						if (VBSQL.gConn[10].State == 1)
						{
							VBSQL.gConn[10].Close();
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("mdlEjecutivo (Sucursal)",e );
				if (adorst.State != 0)
				{
					adorst.Close();
				}
				
				if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
				{
					VBSQL.gConn[10].Close();
				}
			}
			
			return result;
		}
	}
}