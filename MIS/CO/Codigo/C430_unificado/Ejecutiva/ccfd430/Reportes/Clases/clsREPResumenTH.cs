using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsREPResumenTH
	{
	
		
		private string mCentroCostoS = String.Empty;
		private string mCuentaContableS = String.Empty;
		private clsREPTotales mTotales = new clsREPTotales();
		private colREPTransaccion mTransacciones = new colREPTransaccion();
		
		
		public string CentroCostoS
		{
			get
			{
				return mCentroCostoS;
			}
			set
			{
				mCentroCostoS = value;
			}
		}
		
		
		
		public string CuentaContableS
		{
			get
			{
				return mCuentaContableS;
			}
			set
			{
				mCuentaContableS = value;
			}
		}
		
		
		
		public clsREPTotales Totales
		{
			get
			{
				return mTotales;
			}
			set
			{
				mTotales = value;
			}
		}
		
		
		
		public colREPTransaccion Transacciones
		{
			get
			{
				return mTransacciones;
			}
			set
			{
                //AIS-541 NGONZALEZ
				mTransacciones = value;
			}
		}
		
		
		public bool obtenerTransacciones( int iEjePrefijo,  int iGpoBanco,  int iEmpNum,  int iEjeNum,  int iMes,  int iAnio)
		{
			
			try
			{
					
					int EjePrefijoI = 0;
					int GpoBancoI = 0;
					int EmpNumI = 0;
					int EjeNumI = 0;
					string NumeroCuentaS = String.Empty;
					string NombreEjecutivoS = String.Empty;
					string FechaProcesoS = String.Empty;
					string FechaTransaccionS = String.Empty;
					double ImporteD = 0;
					string NegocioS = String.Empty;
					string ReferenciaS = String.Empty;
					string PaisS = String.Empty;
					string CiudadS = String.Empty;
					int iCont = 0;
					
					iCont = 0;
					
					CORVAR.pszgblsql = "exec accountCycleDetMovs ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iEjePrefijo) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iGpoBanco) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iEmpNum) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iEjeNum) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iMes) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iAnio);
					
					CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
					
					if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
					{
						iCont = 0;
						do 
						{
							while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
								
									EjePrefijoI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
									GpoBancoI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
									EmpNumI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
									EjeNumI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
									NumeroCuentaS = VBSQL.SqlData(CORVAR.hgblConexion, 5);
									NombreEjecutivoS = VBSQL.SqlData(CORVAR.hgblConexion, 6);
									FechaProcesoS = VBSQL.SqlData(CORVAR.hgblConexion, 7);
									FechaTransaccionS = VBSQL.SqlData(CORVAR.hgblConexion, 8);
									ImporteD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 9));
									NegocioS = VBSQL.SqlData(CORVAR.hgblConexion, 10);
									ReferenciaS = VBSQL.SqlData(CORVAR.hgblConexion, 11);
									PaisS = VBSQL.SqlData(CORVAR.hgblConexion, 12);
									CiudadS = VBSQL.SqlData(CORVAR.hgblConexion, 13);
									
									string tempRefParam = iCont.ToString();
									mTransacciones.Add(PaisS, CiudadS, ReferenciaS, NegocioS, ImporteD, FechaTransaccionS, FechaProcesoS, NombreEjecutivoS, NumeroCuentaS, EjeNumI, EmpNumI, GpoBancoI, EjePrefijoI, ref tempRefParam);
									iCont++;
									
								}
						}
						while(VBSQL.SqlResults(CORVAR.hgblConexion) != 2);
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("obtenerTransacciones",e );
			}
			return false;
		}
		
		
		~clsREPResumenTH(){
			mTotales = null;
            //AIS-541 NGONZALEZ
			mTransacciones = null;
		}
}
}