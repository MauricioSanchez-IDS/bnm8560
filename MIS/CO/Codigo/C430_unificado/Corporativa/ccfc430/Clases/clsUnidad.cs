using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal class clsUnidad
	{
	
		
		private clsEmpresa mvarEmpresaEMP = null; //local copy
		private string mvarUnidadS = String.Empty; //local copy
		private string mvarNombreS = String.Empty; //local copy
		private clsUnidad mvarUnidadPadreUNI = null; //local copy
		private colCatUnidades mvarcolCatUnidades = null;
		//local variable(s) to hold property value(s)
		private int mvarNivelI = 0; //local copy
		public colCatUnidades ListaCUNI = null;
		
		public void  prConstruyeLista()
		{
			ListaCUNI = fncListaUnidadesCUNI(this, ref ListaCUNI);
		}
		
		public colCatUnidades fncListaUnidadesCUNI( clsUnidad unipUnidad, ref  colCatUnidades cunipLista)
		{
			colCatUnidades result = new colCatUnidades();
			if (cunipLista == null)
			{
				cunipLista = new colCatUnidades();
			}
			cunipLista.Add(this.EmpresaEMP, this.UnidadS, this.NombreS, this.NivelI, this.UnidadPadreUNI, this.colCatUnidades);
			if (this.colCatUnidades != null)
			{
				if (this.colCatUnidades.Count == 0)
				{
					result = cunipLista;
				} else
				{
					for (int llCont = 1; llCont <= this.colCatUnidades.Count; llCont++)
					{
						result = this.colCatUnidades[llCont].fncListaUnidadesCUNI(this.colCatUnidades[llCont], ref cunipLista);
					}
				}
			} else
			{
				result = cunipLista;
			}
			return result;
		}
		
		public void  prConstruyeJerarquia()
		{
			clsUnidad unilUnidadAux = null;
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
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + this.EmpresaEMP.ProductoPRD.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + this.EmpresaEMP.ProductoPRD.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + this.EmpresaEMP.EmpresaL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and nivel_num > " + this.NivelI.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_parent_id <> ''";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by nivel_num, unit_id, unit_parent_id";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						mdlParametros.gcuniUnidad.prClear();
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							unilUnidadAux = null;
							unilUnidadAux = new clsUnidad();
							
							slUnidad = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
							slNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
							slUnidadPadre = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
							ilNivel = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
							
							unilUnidadAux.UnidadS = slUnidad;
							unilUnidadAux.NombreS = slNombre;
							unilUnidadAux.NivelI = ilNivel;
							unilUnidadAux.EmpresaEMP = this.EmpresaEMP;
							
							fncAsignaHijoAPadreB(ref slUnidadPadre, ref unilUnidadAux);
							
						};
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ConstruyeJerarquia)",e );
				return;
			}
			
		}
		
		public bool fncAsignaHijoAPadreB(ref  string spUnidadPadre, ref  clsUnidad unipHijo)
		{
			bool result = false;
			try
			{
					//UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
					if (String.IsNullOrEmpty(spUnidadPadre.Trim()))
					{
						MessageBox.Show("La unidad padre no se ha definido", this.GetType().Name + "(Asigna Hijo a Padre)", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					if (unipHijo == null)
					{
						MessageBox.Show("La unidad hijo no se ha definido correctamente", this.GetType().Name + "(Asigna Hijo a Padre)", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					if (spUnidadPadre.Trim() == this.UnidadS.Trim())
					{
						this.colCatUnidades.Add(unipHijo.EmpresaEMP, unipHijo.UnidadS, unipHijo.NombreS, unipHijo.NivelI, this, unipHijo.colCatUnidades);
						result = true;
					} else
					{
						for (int llItem = 1; llItem <= this.colCatUnidades.Count; llItem++)
						{
							result = this.colCatUnidades[llItem].fncAsignaHijoAPadreB(ref spUnidadPadre, ref unipHijo);
							if (result)
							{
								break;
							}
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(AsignaHijoAPadre)",e );
				return result;
			}
			
			return result;
		}
		
		
		
		public colCatUnidades colCatUnidades
		{
			get
			{
				if (mvarcolCatUnidades == null)
				{
					mvarcolCatUnidades = new colCatUnidades();
				}
				
				
				return mvarcolCatUnidades;
			}
			set
			{
				mvarcolCatUnidades = value;
			}
		}
		
		
		
		
		
		
		public clsUnidad UnidadPadreUNI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.UnidadPadreUNI
				return mvarUnidadPadreUNI;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.UnidadPadreUNI = Form1
				mvarUnidadPadreUNI = value;
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
		
		
		
		
		
		
		public string UnidadS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.UnidadS
				return mvarUnidadS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.UnidadS = 5
				mvarUnidadS = value;
			}
		}
		
		
		
		
		
		
		public clsEmpresa EmpresaEMP
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.EmpresaEMP
				return mvarEmpresaEMP;
			}
			set
			{
				//used when assigning an Object to the property, on the left side of a Set statement.
				//Syntax: Set x.EmpresaEMP = Form1
				mvarEmpresaEMP = value;
			}
		}
		
		
		
		
		public int NivelI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.NivelI
				return mvarNivelI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.NivelI = 5
				mvarNivelI = value;
			}
		}
		
		~clsUnidad(){
			mvarcolCatUnidades = null;
		}
}
}