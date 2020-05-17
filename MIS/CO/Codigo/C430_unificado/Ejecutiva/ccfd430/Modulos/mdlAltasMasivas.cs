using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class mdlAltasMasivas
	{
	
		
		//Variable global del objeto datos ejecutivo
		static public clsDatosEjecutivo gdteAltasMasivas = null;
		
		//Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
		static clsDatosEjecutivo gdteEjeExists = null;
		
		//Variable para el dialogo
		static clsDialogo gdlgDialogoS016 = null;
		static clsDialogo gdlgDialogoS111 = null;
		
		static public int igDiaCorte = 0; //Esta variable se tiene que quitar

        static public string[] slCuentasAutorizar = null;
		
		static public bool fncAsignaValoresAltaMasivaB( int lpItem,  string sctaref)
		{
			
			bool result = false;
			try
			{
					
					Cursor.Current = Cursors.WaitCursor;
					
					gdteAltasMasivas = null;
					gdteAltasMasivas = new clsDatosEjecutivo();
					
					gdteAltasMasivas.EjeProductoPRD = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeProductoPRD;
					gdteAltasMasivas.EjeEmpNumL = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeNumEmpL;
					gdteAltasMasivas.EjeNomS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeNombreS;
					gdteAltasMasivas.EjeRfcRFC = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeRFC;
					gdteAltasMasivas.EjeSueldoL = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeSueldoL;
					gdteAltasMasivas.EjeNumNomS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeNumNominaS;
					gdteAltasMasivas.EjeCentroCostS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeCenCosS;
					gdteAltasMasivas.EjeNivelI = mdlParametros.gcarcAltasMasivas[lpItem].AchEjeNivelI;
					gdteAltasMasivas.EjeNomGrabaS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeNomGrabaS;
					gdteAltasMasivas.EjeDomEnvioDMC = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeDomEnvioDMC;
					gdteAltasMasivas.EjeDomEnvioDMC.EstadoEST = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeDomEnvioDMC.EstadoEST;
					gdteAltasMasivas.EjeDomPartDMC = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeDomPartDMC;
					gdteAltasMasivas.EjeDomPartDMC.EstadoEST = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeDomPartDMC.EstadoEST;
					gdteAltasMasivas.EjeTelDomS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeTelDomS;
					gdteAltasMasivas.EjeTelOfiS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeTelOfiS;
					gdteAltasMasivas.EjeExtensionS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeExtS;
					gdteAltasMasivas.EjeFaxS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeFaxS;
					gdteAltasMasivas.EjeLimCredL = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeLimCredL;
					gdteAltasMasivas.EjeEstatusS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeStatusS;
					gdteAltasMasivas.EjeSexoS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeSexoS;
					gdteAltasMasivas.EjeActiSubactiS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeActSubActiS;
					gdteAltasMasivas.EjeEmailS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeEmailS;
					gdteAltasMasivas.EjeCtaContableS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeCtaContableS;
					gdteAltasMasivas.EjeGenPinPlaI = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeGenPinPlaI;
					gdteAltasMasivas.EjeLimDisEfecL = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeLimDisEfecI;
					gdteAltasMasivas.EjeTipoFactS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeTipoFactS;
					gdteAltasMasivas.EjeSkipPaymentL = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeSkipPaymentI;
					gdteAltasMasivas.EjeTablaMCCL = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeTablaMccL;
					gdteAltasMasivas.EjeIndCtaCtrlS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeIndCtaCtrlS;
					gdteAltasMasivas.EjeNacionalidadS = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeNacionalS;
					gdteAltasMasivas.EjeTipoBloqueoI = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeTipoBloqueoI;
					gdteAltasMasivas.EjeDiaCorteI = igDiaCorte;
					// sctaref = slctaref 'FSWB NR 20070330 Se comentarizó porque se perdia valor pasado por parametro
					gdteAltasMasivas.EjeCuentaReferenciaS = sctaref; //FSWB NR 20070330
					gdteAltasMasivas.EjeAtencionA = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjeAtencionA; //FSWB NR 20070222 Se incluyen campos Atencion A y Persona
					gdteAltasMasivas.EjePersona = mdlParametros.gcarcAltasMasivas[lpItem].ArchEjePersona; //FSWB NR 20070222
					result = true;
					
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				if (Information.Err().Number == 91)
				{
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
					throw new Exception("Migration Exception: 'Resume Next' not supported");
				} else
				{
					return false;
				}
			}
			
			return result;
		}
		
		static public void  prObtenDiaCorte( int lpEmpresa)
		{
			
			try
			{
					
					Cursor.Current = Cursors.WaitCursor;
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_dia_corte";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lpEmpresa.ToString();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							igDiaCorte = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
						};
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					Cursor.Current = Cursors.Default;
				}
			catch 
			{
				
				Cursor.Current = Cursors.Default;
				return;
			}
			
		}
		static public string fncCuentaMapeada( string strNoCta)
		{
			//Objetivo: Determina si la cuenta actual está mapeada
			//           y actualiza el valor tgCambioS111.NumCuentaS
			//           ya que esta variable es la que utiliza la clase clsdialog
			//          para generar el dialogo correspondentie
			
			string result = String.Empty;
			string strSql = String.Empty;
			ADODB.Recordset rsCtaMapeada = null;
			
			try
			{
					strSql = "Select map_cta_citi from MTCMAP01 Where map_cta_bnx = '" + strNoCta + "'";
					strSql = strSql + " and map_estatus = ''";
					
					if (VBSQL.OpenConn(10) != 0)
					{
						VBSQL.gConn[10].Close();
					} else
					{
						VBSQL.gConn[10].Close();
					}
					
					if (VBSQL.OpenConn(10) == 0)
					{
						rsCtaMapeada = new ADODB.Recordset();
						rsCtaMapeada.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, -1);
						
						if (! rsCtaMapeada.EOF)
						{
							//La cuenta está mapeada
							//UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
							result = Convert.ToString(MdlCambioMasivo.Nvl(rsCtaMapeada.Fields["map_cta_citi"].Value , "0"));
						} else
						{
							//La cuenta no esta mapeada
							result = strNoCta;
						}
						rsCtaMapeada.Close();
						rsCtaMapeada = null;
						VBSQL.gConn[10].Close();
					}
				}
			catch 
			{ //FSWB NR 20070330
				
				
				
				if (rsCtaMapeada.State != 0)
				{
					rsCtaMapeada.Close();
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