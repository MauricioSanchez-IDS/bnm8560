using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsEmpresa
	{
	
		
		private clsProducto mvarProductoPRD = null; //local copy
		private clsCorporativo mvarCorporativoCRP = null; //local copy
		private int mvarEmpresaL = 0; //local copy
		private string mvarNombreS = String.Empty; //local copy
		private clsUnidad mvarUnidadUNI = null; //local copy
		
		public void  prUnidadPadre( int lpEmpresa)
		{
			string slUnidad = String.Empty;
			string slNombre = String.Empty;
			string slUnidadPadre = String.Empty;
			int ilNivel = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCUNI01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lpEmpresa.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and nivel_num = 1";
					
					if (CORPROC2.Cuenta_Registros() > 0)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							this.UnidadUNI = null;
							this.UnidadUNI = new clsUnidad();
							
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								
								slUnidad = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
								slNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
								slUnidadPadre = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
								ilNivel = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								
								this.UnidadUNI.UnidadS = slUnidad;
								this.UnidadUNI.NombreS = slNombre;
								this.UnidadUNI.NivelI = ilNivel;
								this.UnidadUNI.EmpresaEMP = this;
								
							};
						}
					}
				}
                catch (Exception e)
			{
				CRSGeneral.prObtenError(this.GetType().Name + "(UnidadPadre)",e );
				return;
			}
		}

        public clsUnidad UnidadUNI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.UnidadUNI
				return mvarUnidadUNI;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.UnidadUNI = Form1
				mvarUnidadUNI = value;
			}
		}
		
		public string NombreS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NombreS
				return mvarNombreS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NombreS = 5
				mvarNombreS = value;
			}
		}
		
		public int EmpresaL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.EmpresaL
				return mvarEmpresaL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.EmpresaL = 5
				mvarEmpresaL = value;
			}
		}
		
		public clsCorporativo CorporativoCRP
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.CorporativoCRP
				return mvarCorporativoCRP;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.CorporativoCRP = Form1
				mvarCorporativoCRP = value;
			}
		}

        public clsProducto ProductoPRD
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.ProductoPRD
				return mvarProductoPRD;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.ProductoPRD = Form1
				mvarProductoPRD = value;
			}
		}	
	}
}