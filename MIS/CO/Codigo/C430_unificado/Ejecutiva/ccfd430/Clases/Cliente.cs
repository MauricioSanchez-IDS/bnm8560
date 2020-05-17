using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsCliente
	{
		private clsProducto mvarProductoPRD = null;
        private int mvarPrefijoL = 0;
        private int mvarBancoL = 0;
		private int mvarEmpresaL = 0;
		private int mvarClienteL = 0;
		
		public bool fncAlmacenaClienteB()
		{
			try
			{
					//If fncVerificaEmpresaB = True Then     'OJO Por el Momento se va a comentar esta linea OJO
					CORVAR.pszgblsql = "insert into MTCCLI01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " cliente_num)";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " values (";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ProductoPRD.PrefijoL.ToString() + ",";
					CORVAR.pszgblsql = CORVAR.pszgblsql + ProductoPRD.BancoL.ToString() + ",";
					CORVAR.pszgblsql = CORVAR.pszgblsql + this.EmpresaL.ToString() + ",";
					CORVAR.pszgblsql = CORVAR.pszgblsql + this.ClienteL.ToString() + ")";
					//Else
					//    fncAlmacenaClienteB = False
					//End If
					
					return CORPROC2.Modifica_Registro() >= 1;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(AlmacenaCliente)", e );
				return false;
			}
		}
		
		//UPGRADE_NOTE: (7001) The following declaration (fncVerificaEmpresaB) seems to be dead code
		//private bool fncVerificaEmpresaB()
		//{
				//
				//try
				//{
						//
						//CORVAR.pszgblsql = "select emp_num";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + ProductoPRD.PrefijoL.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + ProductoPRD.BancoL.ToString();
						//CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + this.EmpresaL.ToString();
						//
						//
						//return CORPROC2.Cuenta_Registros() > 0;
					//}
				//catch 
				//{
					//
					//CRSGeneral.prObtenError(this.GetType().Name + "(VerificaEmpresa)");
					//return false;
				//}
		//}
		
		public int fncObtenClienteL( clsProducto prdpProducto,  int lpEmpresa)
		{
    		int result = 0;
			try
			{
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " cliente_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCLI01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + prdpProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + prdpProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lpEmpresa.ToString();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							result = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenCliente)", e );
				return 0;
			}
			return result;
		}
		
		public int fncExtraerClienteL( string spDialogo)
		{			
			try
			{			
                    //return StringsHelper.IntValue(Strings.Mid(spDialogo, 20, 12));
                    return StringsHelper.IntValue(Strings.Mid(spDialogo, 177, 12));
				}
                catch (Exception e)
			{				
				CRSGeneral.prObtenError(this.GetType().Name + "(ExtraerCliente)", e);
				return 0;
			}
		}		
		
		public clsProducto ProductoPRD
		{
			get
			{
				return mvarProductoPRD;
			}
			set
			{
				mvarProductoPRD = value;
                mvarPrefijoL = value.PrefijoL;
                mvarBancoL = value.BancoL;
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
		
		public int ClienteL
		{
			get
			{
				return mvarClienteL;
			}
			set
			{
				mvarClienteL = value;
			}
		}
		
		public clsCliente(){
			this.ProductoPRD = mdlParametros.gprdProducto;
		}
    }
}