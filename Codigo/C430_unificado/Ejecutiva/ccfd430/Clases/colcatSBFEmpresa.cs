using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
    //AIS-1157 NGONZALEZ
	internal class colcatSBFEmpresa
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		
		public void  prObtenerEmpresa( colcatSBFEjecutivo sbfpEjecutivo,  colcatSBFTransaccion sbfpTransaccion)
		{
			
			int llEmpresaNumero = 0;
			string slEmpresaNombre = String.Empty;
			string slEmpresaTipoFact = String.Empty;
			int llEmpNumL = 0;
			string slEmpNomS = String.Empty;
			string slTipoFactS = String.Empty;
			int llTHSNumL = 0;
			int llTransNumL = 0;
			double dlSaldoAnteriorD = 0;
			double dlSaldoActualD = 0;
			//mvarProductoPRD recuerda que en el add esta variable se envia con gprdProducto
			
			try
			{
					
					CORVAR.pszgblsql = "select a.emp_num, a.emp_nom, a.emp_tipo_fac";
					
					//Descomentar esta línea -y comentar la siguiente- para ver un ejemplo
					//pszgblsql = pszgblsql & " from RESPALDO_EMP a"
					
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01 a";
					
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = ";
					CORVAR.pszgblsql = CORVAR.pszgblsql + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_gen_SBF in (2,3,4,5)";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " a.emp_num";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						this.prClear();
						
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							llTHSNumL = 0;
							llTransNumL = 0;
							dlSaldoAnteriorD = 0;
							dlSaldoActualD = 0;
							llEmpresaNumero = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							slEmpresaNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							slEmpresaTipoFact = VBSQL.SqlData(CORVAR.hgblConexion, 3);
							
							for (int llcontador = 1; llcontador <= sbfpEjecutivo.Count; llcontador++)
							{
								if (llEmpresaNumero == sbfpEjecutivo[llcontador].EmpNumL)
								{
									llTHSNumL++;
									dlSaldoAnteriorD += sbfpEjecutivo[llcontador].SaldoAnteriorD;
									dlSaldoActualD += sbfpEjecutivo[llcontador].SaldoActualD;
								}
							}
							
							for (int llcontador2 = 1; llcontador2 <= sbfpTransaccion.Count; llcontador2++)
							{
								if (llEmpresaNumero == sbfpTransaccion[llcontador2].EmpNumL)
								{
									llTransNumL++;
								}
							}
							
							this.Add(llEmpresaNumero, slEmpresaNombre, slEmpresaTipoFact, llTHSNumL, llTransNumL, dlSaldoAnteriorD, dlSaldoActualD, mdlParametros.gprdProducto);
							
						};
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenerEmpresa)",e );
				return;
			}
			
			
			
		}
		
		public void  prClear()
		{
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
						this.Remove(llCont);
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(Clear)",e );
				return;
			}
			
			
		}
		
		public int fncBuscaEmpresaI( int lpEmpresa)
		{
			
			int result = 0;
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
                        //AIS-1135 NGONZALEZ
						if (this[llCont].EmpNumL == lpEmpresa)
						{
							result = llCont;
							break;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaEmpresa)",e);
				return result;
			}
			
			return result;
		}
		
		public clsSBFEmpresa Add( int EmpNumL,  string EmpNomS,  string TipoFactS,  int THSNumL,  int TransNumL,  double SaldoAnteriorD,  double SaldoActualD,  clsProducto productoPRD, ref  string sKey)
		{
			//create a new object
			clsSBFEmpresa objNewMember = new clsSBFEmpresa();
			
			
			//set the properties passed into the method
			objNewMember.EmpNumL = EmpNumL;
			objNewMember.EmpNomS = EmpNomS;
			objNewMember.TipoFactS = TipoFactS;
			objNewMember.THSNumL = THSNumL;
			objNewMember.TransNumL = TransNumL;
			objNewMember.SaldoAnteriorD = SaldoAnteriorD;
			objNewMember.SaldoActualD = SaldoActualD;
			if (Information.IsReference(productoPRD))
			{
				objNewMember.productoPRD = productoPRD;
			} else
			{
				objNewMember.productoPRD = productoPRD;
			}
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			
			//return the object created
			return objNewMember;
			
			
		}
		
		public clsSBFEmpresa Add( int EmpNumL,  string EmpNomS,  string TipoFactS,  int THSNumL,  int TransNumL,  double SaldoAnteriorD,  double SaldoActualD,  clsProducto productoPRD)
		{
			string tempRefParam = "";
			return Add(EmpNumL, EmpNomS, TipoFactS, THSNumL, TransNumL, SaldoAnteriorD, SaldoActualD, productoPRD, ref tempRefParam);
		}
		
		public clsSBFEmpresa this[object vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsSBFEmpresa) mCol[Convert.ToInt32(vntIndexKey)];
			}
		}
		
		
		
		
		public int Count
		{
			get
			{
				//used when retrieving the number of elements in the
				//collection. Syntax: Debug.Print x.Count
				return mCol.Count;
			}
		}
		
		
		
		
		public IEnumerator GetEnumerator()
		{
			//this property allows you to enumerate
			//this collection with the For...Each syntax
			return mCol.GetEnumerator();
		}
		
		
		public void  Remove( int vntIndexKey)
		{
			//used when removing an element from the collection
			//vntIndexKey contains either the Index or Key, which is why
			//it is declared as a Variant
			//Syntax: x.Remove(xyz)


            //AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
                mCol.Remove(vntIndexKey.ToString());
            else
                mCol.Remove((int)vntIndexKey);
		}
		
		
		public colcatSBFEmpresa(){
			//creates the collection when this class is created
		}
	
	
	~colcatSBFEmpresa(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}