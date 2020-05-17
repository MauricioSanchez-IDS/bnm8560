using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsREPResumenUnidad
	{
	
		
		private colREPResumenTH mTotalesTH = new colREPResumenTH();
		private clsREPTotales mTotal = new clsREPTotales();
		
		
		public clsREPTotales Total
		{
			get
			{
				return mTotal;
			}
			set
			{
				mTotal = value;
			}
		}
		
		
		
		public colREPResumenTH TotalesTH
		{
			get
			{
				return mTotalesTH;
			}
			set
			{
                //AIS-541 NGONZALEZ
				mTotalesTH = value;
			}
		}
		
		
		public bool obtenerTotalesTH( int iEjePrefijo,  int iGpoBanco,  int iEmpNum,  string sIDunidad,  int iMes,  int iAnio)
		{
			
			try
			{
					
					int EjePrefijoI = 0;
					int GpoBancoI = 0;
					int EmpNumI = 0;
					int EjeNumI = 0;
					string NumeroCuentaS = String.Empty;
					string NombreEjecutivoS = String.Empty;
					string NumeroNominaS = String.Empty;
					double LimiteCreditoD = 0;
					string CentroCostosI = String.Empty;
					int MesesVencidosI = 0;
					double SaldoAnteriorD = 0;
					double ComprasD = 0;
					double DisposicionesD = 0;
					double PagosAbonosD = 0;
					double ComisionesD = 0;
					double GastosCobrosD = 0;
					double IvaD = 0;
					double SaldoNuevoD = 0;
					string CuentaContableS = String.Empty;
					int iCont = 0;
					
					iCont = 0;
					
					CORVAR.pszgblsql = "exec accountCycleDetalle ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iEjePrefijo) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iGpoBanco) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iEmpNum) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + Conversion.Str(sIDunidad).Trim() + "', ";
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
									NumeroNominaS = VBSQL.SqlData(CORVAR.hgblConexion, 7);
									LimiteCreditoD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8));
									CentroCostosI = VBSQL.SqlData(CORVAR.hgblConexion, 9);
									MesesVencidosI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 10));
									SaldoAnteriorD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11));
									ComprasD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12));
									DisposicionesD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 13));
									PagosAbonosD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 14));
									ComisionesD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 15));
									GastosCobrosD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 16));
									IvaD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 17));
									SaldoNuevoD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 18));
									CuentaContableS = VBSQL.SqlData(CORVAR.hgblConexion, 19);
									
									string tempRefParam = Conversion.Str(iCont);
									mTotalesTH.Add(sIDunidad.Trim(), CuentaContableS.Trim(), ref tempRefParam);
									iCont++;
									
									mTotalesTH[iCont].Totales.EjePrefijoI = EjePrefijoI;
									mTotalesTH[iCont].Totales.GpoBancoI = GpoBancoI;
									mTotalesTH[iCont].Totales.EmpNumI = EmpNumI;
									mTotalesTH[iCont].Totales.EjeNumI = EjeNumI;
									mTotalesTH[iCont].Totales.NumeroCuentaS = NumeroCuentaS;
									mTotalesTH[iCont].Totales.NombreEjecutivoS = NombreEjecutivoS;
									mTotalesTH[iCont].Totales.NumeroNominaS = NumeroNominaS;
									mTotalesTH[iCont].Totales.LimiteCreditoD = LimiteCreditoD;
									mTotalesTH[iCont].Totales.CentroCostosI = CentroCostosI.Trim();
									mTotalesTH[iCont].Totales.MesesVencidosI = MesesVencidosI;
									mTotalesTH[iCont].Totales.SaldoAnteriorD = SaldoAnteriorD;
									mTotalesTH[iCont].Totales.ComprasD = ComprasD;
									mTotalesTH[iCont].Totales.DisposicionesD = DisposicionesD;
									mTotalesTH[iCont].Totales.PagosAbonosD = PagosAbonosD;
									mTotalesTH[iCont].Totales.ComisionesD = ComisionesD;
									mTotalesTH[iCont].Totales.GastosCobrosD = GastosCobrosD;
									mTotalesTH[iCont].Totales.IvaD = IvaD;
									mTotalesTH[iCont].Totales.SaldoNuevoD = SaldoNuevoD;
									
									// Calcula totales para la unidad
									mTotal.CentroCostosI = CentroCostosI;
									mTotal.SaldoAnteriorD += SaldoAnteriorD;
									mTotal.ComprasD += ComprasD;
									mTotal.DisposicionesD += DisposicionesD;
									mTotal.PagosAbonosD += PagosAbonosD;
									mTotal.ComisionesD += ComisionesD;
									mTotal.GastosCobrosD += GastosCobrosD;
									mTotal.IvaD += IvaD;
									mTotal.SaldoNuevoD += SaldoNuevoD;
									
								}
						}
						while(VBSQL.SqlResults(CORVAR.hgblConexion) != 2);
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("obtenerTotalesTH",e );
			}
			return false;
		}
		
		public bool obtenerTotal( int iEjePrefijo,  int iGpoBanco,  int iEmpNum,  string sIDunidad,  int iMes,  int iAnio)
		{
			
			try
			{
					
					double SaldoAnteriorD = 0;
					double ComprasD = 0;
					double DisposicionesD = 0;
					double PagosAbonosD = 0;
					double ComisionesD = 0;
					double GastosCobrosD = 0;
					double IvaD = 0;
					double SaldoNuevoD = 0;
					int iCont = 0;
					
					iCont = 0;
					
					CORVAR.pszgblsql = "exec accountCycleResumen ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iEjePrefijo) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iGpoBanco) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(iEmpNum) + ", ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + Conversion.Str(sIDunidad).Trim() + "', ";
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
								
									SaldoAnteriorD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8));
									ComprasD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 9));
									DisposicionesD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10));
									PagosAbonosD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11));
									ComisionesD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12));
									GastosCobrosD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 13));
									IvaD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 14));
									SaldoNuevoD = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 15));
									
									iCont++;
									
									// Calcula totales para la unidad
									mTotal.SaldoAnteriorD = SaldoAnteriorD;
									mTotal.ComprasD = ComprasD;
									mTotal.DisposicionesD = DisposicionesD;
									mTotal.PagosAbonosD = PagosAbonosD;
									mTotal.ComisionesD = ComisionesD;
									mTotal.GastosCobrosD = GastosCobrosD;
									mTotal.IvaD = IvaD;
									mTotal.SaldoNuevoD = SaldoNuevoD;
								}
						}
						while(VBSQL.SqlResults(CORVAR.hgblConexion) != 2);
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("obtenerTotal",e );
			}
			return false;
		}
		
		
		~clsREPResumenUnidad(){
            //AIS-541 NGONZALEZ
			mTotalesTH = null;
			mTotal = null;
		}
}
}