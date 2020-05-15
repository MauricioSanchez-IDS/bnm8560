using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsREPUnidad
	{
	
		public enum cteNivelProfundidad
		 {
			cteNivelUnidad = 1 ,
			cteNivelTarjetaHabiente = 2 ,
			cteNivelTransaccion = 3
		}
		public int PeriodoCorteI = DateTime.Today.Month;
		public int AñoCorteI = DateTime.Today.Year;
		private string mvarNombreS = String.Empty;
		private int mvarPrefijoL = 0;
		private int mvarBancoL = 0;
		private int mvarEmpresaL = 0;
		private int mvarGrupoL = 0;
		private string mvarIdS = String.Empty;
		private string mvarIdPadreS = String.Empty;
		private int mvarNivelI = 1;
		private string mvarCalleS = String.Empty;
		private string mvarColoniaS = String.Empty;
		private string mvarCiudadS = String.Empty;
		private string mvarPoblacionS = String.Empty;
		private string mvarEstadoS = String.Empty;
		private int mvarCodigoPostalL = 0;
		private string mvarTelefonoS = String.Empty;
		private string mvarFaxS = String.Empty;
		private string mvarCelularS = String.Empty;
		private string mvarCorreoElectronicoS = String.Empty;
		private string mvarPaisS = String.Empty;
		private clsREPResumenUnidad mvarResumenRUN = new clsREPResumenUnidad();
		private colREPUnidades mvarcolUnidades = new colREPUnidades();
		
		public clsREPUnidad unifncBuscaUnidadHijo(ref  string spUnidad)
		{
			clsREPUnidad result = new clsREPUnidad();
			try
			{
					if (colUnidades.Count > 0)
					{
						for (int ilUnidad = 1; ilUnidad <= colUnidades.Count; ilUnidad++)
						{
							if (colUnidades[ilUnidad].IdS == spUnidad.Trim())
							{
								result = colUnidades[ilUnidad].unifncBuscaUnidadHijo(ref spUnidad);
								break;
							}
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("BuscaUnidadHijo",e );
			}
			return result;
		}
		
		public void  ActualizaUnidades(ref  cteNivelProfundidad nvlDetalle)
		{
			//Actualiza los datos de la unidad dependiendo del nivel de profundidad (nvlDetalle)
			
			try
			{
					//  If colUnidades.Count = 0 Then
					switch(nvlDetalle)
					{
						case cteNivelProfundidad.cteNivelUnidad : 
							ResumenRUN.obtenerTotal(PrefijoL, BancoL, EmpresaL, IdS, PeriodoCorteI, AñoCorteI); 
							break;
						case cteNivelProfundidad.cteNivelTarjetaHabiente : 
							ResumenRUN.obtenerTotalesTH(PrefijoL, BancoL, EmpresaL, IdS, PeriodoCorteI, AñoCorteI); 
							break;
						case cteNivelProfundidad.cteNivelTransaccion : 
							if (ResumenRUN.TotalesTH.Count == 0)
							{
								ResumenRUN.obtenerTotalesTH(PrefijoL, BancoL, EmpresaL, IdS, PeriodoCorteI, AñoCorteI);
							} 
							for (int ilTajetahabientes = 1; ilTajetahabientes <= ResumenRUN.TotalesTH.Count; ilTajetahabientes++)
							{
								ResumenRUN.TotalesTH[ilTajetahabientes].obtenerTransacciones(PrefijoL, BancoL, EmpresaL, ResumenRUN.TotalesTH[ilTajetahabientes].Totales.EjeNumI, PeriodoCorteI, AñoCorteI);
								Application.DoEvents();
							} 
							break;
					}
					//  Else
					for (int ilUnidades = 1; ilUnidades <= colUnidades.Count; ilUnidades++)
					{
						cteNivelProfundidad tempRefParam = nvlDetalle;
						colUnidades[ilUnidades].ActualizaUnidades(ref tempRefParam);
						Application.DoEvents();
					}
					//  End If
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("ActualizaUnidades",e );
			}
		}
		
		public void  GeneraTotales()
		{
			//Calcula los totales a nivel Unidad, tomando en cuenta todos los hijos que tiene
			try
			{
					//Analizar si la coleccion colUnidades tiene elementos
					if (colUnidades.Count > 0 && NivelI != 1)
					{
						for (int ilUnidad = 1; ilUnidad <= colUnidades.Count; ilUnidad++)
						{
							colUnidades[ilUnidad].GeneraTotales();
							ResumenRUN.Total.SaldoAnteriorD += colUnidades[ilUnidad].ResumenRUN.Total.SaldoAnteriorD;
							ResumenRUN.Total.ComprasD += colUnidades[ilUnidad].ResumenRUN.Total.ComprasD;
							ResumenRUN.Total.DisposicionesD += colUnidades[ilUnidad].ResumenRUN.Total.DisposicionesD;
							ResumenRUN.Total.PagosAbonosD += colUnidades[ilUnidad].ResumenRUN.Total.PagosAbonosD;
							ResumenRUN.Total.ComisionesD += colUnidades[ilUnidad].ResumenRUN.Total.ComisionesD;
							ResumenRUN.Total.GastosCobrosD += colUnidades[ilUnidad].ResumenRUN.Total.GastosCobrosD;
							ResumenRUN.Total.IvaD += colUnidades[ilUnidad].ResumenRUN.Total.IvaD;
							ResumenRUN.Total.SaldoNuevoD += colUnidades[ilUnidad].ResumenRUN.Total.SaldoNuevoD;
						}
					} else
					{
						ResumenRUN.obtenerTotal(PrefijoL, BancoL, EmpresaL, IdS, PeriodoCorteI, AñoCorteI);
						for (int ilUnidad = 1; ilUnidad <= colUnidades.Count; ilUnidad++)
						{
							colUnidades[ilUnidad].GeneraTotales();
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("ErrGeneraTotales",e );
			}
		}
		
		
		
		public colREPUnidades colUnidades
		{
			get
			{
				if (mvarcolUnidades == null)
                {//AIS-541 NGONZALEZ
					mvarcolUnidades = new colREPUnidades();
				}
				return mvarcolUnidades;
			}
			set
            {//AIS-541 NGONZALEZ
				mvarcolUnidades = value;
			}
		}
		
		
		
		public clsREPResumenUnidad ResumenRUN
		{
			get
			{
				return mvarResumenRUN;
			}
			set
			{
				mvarResumenRUN = value;
			}
		}
		
		
		
		public string PaisS
		{
			get
			{
				return mvarPaisS;
			}
			set
			{
				mvarPaisS = value;
			}
		}
		
		
		public string CorreoElectronicoS
		{
			get
			{
				return mvarCorreoElectronicoS;
			}
			set
			{
				mvarCorreoElectronicoS = value;
			}
		}
		
		
		
		
		public string CelularS
		{
			get
			{
				return mvarCelularS;
			}
			set
			{
				mvarCelularS = value;
			}
		}
		
		
		
		
		
		
		public string FaxS
		{
			get
			{
				return mvarFaxS;
			}
			set
			{
				mvarFaxS = value;
			}
		}
		
		
		
		
		
		
		public string TelefonoS
		{
			get
			{
				return mvarTelefonoS;
			}
			set
			{
				mvarTelefonoS = value;
			}
		}
		
		
		
		
		
		
		public int CodigoPostalL
		{
			get
			{
				return mvarCodigoPostalL;
			}
			set
			{
				mvarCodigoPostalL = value;
			}
		}
		
		
		
		
		
		
		public string EstadoS
		{
			get
			{
				return mvarEstadoS;
			}
			set
			{
				mvarEstadoS = value;
			}
		}
		
		
		
		
		
		
		public string PoblacionS
		{
			get
			{
				return mvarPoblacionS;
			}
			set
			{
				mvarPoblacionS = value;
			}
		}
		
		
		
		
		
		
		public string CiudadS
		{
			get
			{
				return mvarCiudadS;
			}
			set
			{
				mvarCiudadS = value;
			}
		}
		
		
		
		
		
		
		public string ColoniaS
		{
			get
			{
				return mvarColoniaS;
			}
			set
			{
				mvarColoniaS = value;
			}
		}
		
		
		
		
		
		
		public string CalleS
		{
			get
			{
				return mvarCalleS;
			}
			set
			{
				mvarCalleS = value;
			}
		}
		
		
		
		
		
		
		public int NivelI
		{
			get
			{
				return mvarNivelI;
			}
			set
			{
				mvarNivelI = value;
			}
		}
		
		
		
		
		
		
		public string IdPadreS
		{
			get
			{
				return mvarIdPadreS;
			}
			set
			{
				mvarIdPadreS = value;
			}
		}
		
		
		
		public string IdS
		{
			get
			{
				return mvarIdS;
				
			}
			set
			{
				mvarIdS = value;
			}
		}
		
		
		
		
		public int GrupoL
		{
			get
			{
				return mvarGrupoL;
			}
			set
			{
				mvarGrupoL = value;
			}
		}
		
		
		
		
		
		
		public int EmpresaL
		{
			get
			{
				return mvarEmpresaL;
			}
			set
			{
				mvarEmpresaL = value;
			}
		}
		
		
		
		
		
		
		public int BancoL
		{
			get
			{
				return mvarBancoL;
			}
			set
			{
				mvarBancoL = value;
			}
		}
		
		
		
		
		public int PrefijoL
		{
			get
			{
				return mvarPrefijoL;
			}
			set
			{
				mvarPrefijoL = value;
			}
		}
		
		
		
		
		
		
		public string NombreS
		{
			get
			{
				return mvarNombreS;
			}
			set
			{
				mvarNombreS = value;
			}
		}
		
		
		
		~clsREPUnidad(){
            //AIS-541 NGONZALEZ
			mvarcolUnidades = null;
			mvarResumenRUN = null;
		}
}
}