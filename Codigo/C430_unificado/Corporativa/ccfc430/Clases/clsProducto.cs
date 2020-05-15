using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsProducto
	{
	
		
		private int mvarPrefijoL = 0;
		private int mvarBancoL = 0;
		private int mvarLongitudPrefijoL = 0;
		private int mvarLongitudBancoL = 0;
		private string mvarProductoS = String.Empty;
		private int mvarLongitudEmpresaI = 0;
		private int mvarLongitudEjecutivoI = 0;
		private string mvarDescripcionS = String.Empty;
		private string mvarMascaraPrefijoS = String.Empty;
		private string mvarMascaraBancoS = String.Empty;
		private string mvarMascaraEmpresaS = String.Empty;
		private string mvarMascaraEjecutivoS = String.Empty;
		private string mvarTipoProductoS = String.Empty;
		
		
		public void  prConfiguraProducto( int lpPrefijo,  int lpBanco)
		{
			
			//Dim rstlConfiguraProducto As ADODB.Recordset
			
			try
			{
					
					prInicializaPropiedades();
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_prefijo,"; //Prefijo
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_banco,"; //Banco
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_emp,"; //Longitud de Empresa
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_eje,"; //Longitud de Ejecutivo
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_emp,"; //Descripcion
					CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_tipo_prod"; //Tipo de Producto
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCPGS01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where pgs_rep_prefijo = " + lpPrefijo.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and pgs_rep_banco = " + lpBanco.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and pgs_tipo_prod = 'C'";
					
					//    Set rstlConfiguraProducto = fncEjecutaSqlRST(pszgblsql, cnngM111)
					//
					//    If rstlConfiguraProducto.RecordCount <> 0 Then
					//        PrefijoL = CLng(rstlConfiguraProducto.Fields(0).Value)              'Prefijo
					//        BancoL = CLng(rstlConfiguraProducto.Fields(1).Value)                'Banco
					//        LongitudEmpresaI = Val(rstlConfiguraProducto.Fields(2).Value)       'Longitud Empresa
					//        LongitudEjecutivoI = Val(rstlConfiguraProducto.Fields(3).Value)     'Longitud Ejecutivo
					//        DescripcionS = Trim(rstlConfiguraProducto.Fields(4).Value)          'Descripcion
					//        LongitudPrefijoL = Len(Trim(PrefijoL))                              'Longitud Prefijo
					//        LongitudBancoL = Len(Trim(BancoL))                                  'Longitud Banco
					//        MascaraPrefijoS = String(LongitudPrefijoL, "0")                     'Mascara Prefijo
					//        MascaraBancoS = String(LongitudBancoL, "0")                         'Mascara Banco
					//        MascaraEmpresaS = String(LongitudEmpresaI, "0")                     'Mascara Empresa
					//        MascaraEjecutivoS = String(LongitudEjecutivoI, "0")                 'Mascara Ejecutivo
					//        TipoProductoS = Trim(rstlConfiguraProducto.Fields(5).Value)         'Tipo Producto
					//    Else
					//        MsgBox "", vbInformation + vbOKOnly, App.ProductName
					//        Exit Sub
					//    End If
					
					if (CORPROC2.Cuenta_Registros() > 0)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								PrefijoL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)); //Eje_prefijo
								BancoL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2)); //Gpo_Banco
								LongitudEmpresaI = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3))); //Longitud Empresa
								LongitudEjecutivoI = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4))); //Longitud Ejecutivo
								DescripcionS = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim(); //Descripcion
								TipoProductoS = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim(); //Tipo Producto
							};
							LongitudPrefijoL = PrefijoL.ToString().Trim().Length; //Longitud Prefijo
							LongitudBancoL = BancoL.ToString().Trim().Length; //Longitud Banco
							MascaraPrefijoS = new string('0', LongitudPrefijoL); //Mascara Prefijo
							MascaraBancoS = new string('0', LongitudBancoL); //Mascara Banco
							MascaraEmpresaS = new string('0', LongitudEmpresaI); //Mascara Empresa
							MascaraEjecutivoS = new string('0', LongitudEjecutivoI); //Mascara Ejecutivo
						}
					}
				}
                catch (Exception e) 
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ConfiguraProducto)",e );
				return;
			}
			
		}
		
		public string fncConstruyeProductoS()
		{
			
			try
			{
					
					
					return StringsHelper.Format(PrefijoL.ToString().Trim(), MascaraPrefijoS) + StringsHelper.Format(BancoL.ToString().Trim(), MascaraBancoS);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ConstruyeProductoS)",e );
				return "";
			}
			
		}
		
		private void  prInicializaPropiedades()
		{
			PrefijoL = 0; //Eje_prefijo
			BancoL = 0; //Gpo_Banco
			LongitudEmpresaI = 0; //Longitud Empresa
			LongitudEjecutivoI = 0; //Longitud Ejecutivo
			DescripcionS = ""; //Descripcion
			LongitudPrefijoL = 0; //Longitud Prefijo
			LongitudBancoL = 0; //Longitud Banco
			MascaraPrefijoS = ""; //Mascara Prefijo
			MascaraBancoS = ""; //Mascara Banco
			MascaraEmpresaS = ""; //Mascara Empresa
			MascaraEjecutivoS = ""; //Mascara Ejecutivo
			TipoProductoS = ""; //Tipo Producto
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
		
		
		
		public int LongitudPrefijoL
		{
			get
			{
				return mvarLongitudPrefijoL;
			}
			set
			{
				mvarLongitudPrefijoL = value;
			}
		}
		
		
		
		public int LongitudBancoL
		{
			get
			{
				return mvarLongitudBancoL;
			}
			set
			{
				mvarLongitudBancoL = value;
			}
		}
		
		
		public string ProductoS
		{
			get
			{
				mvarProductoS = fncConstruyeProductoS();
				return mvarProductoS;
			}
		}
		
		
		
		public int LongitudEmpresaI
		{
			get
			{
				return mvarLongitudEmpresaI;
			}
			set
			{
				mvarLongitudEmpresaI = value;
			}
		}
		
		
		
		public int LongitudEjecutivoI
		{
			get
			{
				return mvarLongitudEjecutivoI;
			}
			set
			{
				mvarLongitudEjecutivoI = value;
			}
		}
		
		
		
		public string DescripcionS
		{
			get
			{
				return mvarDescripcionS;
			}
			set
			{
				mvarDescripcionS = value;
			}
		}
		
		
		
		public string MascaraPrefijoS
		{
			get
			{
				return mvarMascaraPrefijoS;
			}
			set
			{
				mvarMascaraPrefijoS = value;
			}
		}
		
		
		
		public string MascaraBancoS
		{
			get
			{
				return mvarMascaraBancoS;
			}
			set
			{
				mvarMascaraBancoS = value;
			}
		}
		
		
		
		public string MascaraEmpresaS
		{
			get
			{
				return mvarMascaraEmpresaS;
			}
			set
			{
				mvarMascaraEmpresaS = value;
			}
		}
		
		
		
		public string MascaraEjecutivoS
		{
			get
			{
				return mvarMascaraEjecutivoS;
			}
			set
			{
				mvarMascaraEjecutivoS = value;
			}
		}
		
		
		
		public string TipoProductoS
		{
			get
			{
				return mvarTipoProductoS;
			}
			set
			{
				mvarTipoProductoS = value;
			}
		}
		
		
		public clsProducto(){
			prInicializaPropiedades();
		}
}
}