using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
    //AIS-1157 NGONZALEZ
	internal class colcatSBFC430Empresa
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		public void  prObtenerEmpresa( clsSBFC430Empresa.enuTipoSBFC430Empresa ipTipoSBF)
		{
			
			int llEmpresaNum = 0;
			string slEmpresaNombre = String.Empty;
			string slEmpresaTipoFact = String.Empty;
			int llTHSNumL = 0;
			int llTransNumL = 0;
			double dlSaldoAnteriorD = 0;
			double dlSaldoActualD = 0;
			
			try
			{
					
					if (ipTipoSBF == clsSBFC430Empresa.enuTipoSBFC430Empresa.tsbfc430EmpresaSBF)
					{
						
						CORVAR.pszgblsql = "select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " sum(a.sbf_saldo_previo) as saldo_previo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " sum(a.sbf_saldo_actual) as saldo_actual,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " count(a.sbf_eje_num) as numero_th";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " into    #resultado1";
						
						//pszgblsql = pszgblsql & " from RESPALDO_SBF02 a"
						//pszgblsql = pszgblsql & " from MTCSBF02 a"
						
						if (mdlParametros.IgEnvioSBF == 3)
						{
							//pszgblsql = pszgblsql & " from RESPALDO_SBF02 t"
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCSBF02 a";
						} else
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCSBF06 a";
						}
						
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Where a.sbf_emp_num! = 0";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Group By";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_emp_num";
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + "     select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " count(b.eje_num) numero_tran";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " into    #resultado2";
						
						//pszgblsql = pszgblsql & " from RESPALDO_SBF01 b"
						//pszgblsql = pszgblsql & " from MTCSBF01 b"
						
						if (mdlParametros.IgEnvioSBF == 3)
						{
							//pszgblsql = pszgblsql & " from RESPALDO_SBF01 t"
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCSBF01 b";
						} else
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCSBF05 b";
						}
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Where b.emp_num! = 0";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Group By";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.emp_num";
						
						CORPROC2.Obtiene_Registros();
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						
						CORVAR.pszgblsql = "     select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " e.emp_nom as Empresa,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.saldo_previo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.saldo_actual,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.numero_th,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.numero_tran,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " e.emp_tipo_fac";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " From #resultado1 a,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " #resultado2 b,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCEMP01 e";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Where";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.sbf_gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.sbf_emp_num = b.emp_num";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.sbf_emp_num = e.emp_num";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and e.emp_gen_SBF in (2,3,4,5)";
						
						
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							this.prClear();
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								llEmpresaNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
								slEmpresaNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
								dlSaldoAnteriorD = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								dlSaldoActualD = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								llTHSNumL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 5));
								llTransNumL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 6));
								slEmpresaTipoFact = VBSQL.SqlData(CORVAR.hgblConexion, 7);
								
								this.Add(llEmpresaNum, slEmpresaNombre, mdlParametros.gprdProducto, dlSaldoAnteriorD, dlSaldoActualD, llTHSNumL, llTransNumL, slEmpresaTipoFact);
							};
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
						
					} else if (ipTipoSBF == clsSBFC430Empresa.enuTipoSBFC430Empresa.tsbfc430EmpresaC430) { 
						
						CORVAR.pszgblsql = "select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " sum(a.sbf_saldo_previo) as saldo_previo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " sum(a.sbf_saldo_actual) as saldo_actual,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " count(a.sbf_eje_num) as numero_th";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " into    #resultado3";
						
						//pszgblsql = pszgblsql & " from RESPALDO_tabla_b a"
						//pszgblsql = pszgblsql & " from MTCSBF04 a"
						
						if (mdlParametros.IgEnvioSBF == 3)
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCSBF04 a";
						} else
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCSBF08 a";
						}
						
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Where a.sbf_emp_num! = 0";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Group By";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_emp_num";
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + "     select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " count(b.eje_num) numero_tran";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " into    #resultado4";
						
						//pszgblsql = pszgblsql & " from RESPALDO_tabla_a b"
						//pszgblsql = pszgblsql & " from MTCSBF03 b"
						
						if (mdlParametros.IgEnvioSBF == 3)
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCSBF03 b";
						} else
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCSBF07 b";
						}
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Where b.emp_num! = 0";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Group By";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.emp_num";
						
						CORPROC2.Obtiene_Registros();
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						
						CORVAR.pszgblsql = "     select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " e.emp_nom as Empresa,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.saldo_previo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.saldo_actual,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.numero_th,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.numero_tran,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " e.emp_tipo_fac";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " From #resultado3 a,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " #resultado4 b,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCEMP01 e";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " Where";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.sbf_eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.sbf_gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.sbf_emp_num = b.emp_num";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.sbf_emp_num = e.emp_num";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and e.emp_gen_SBF in (2,3,4,5)";
						
						
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							this.prClear();
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								llEmpresaNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
								slEmpresaNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
								dlSaldoAnteriorD = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								dlSaldoActualD = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								llTHSNumL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 5));
								llTransNumL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 6));
								slEmpresaTipoFact = VBSQL.SqlData(CORVAR.hgblConexion, 7);
								
								this.Add(llEmpresaNum, slEmpresaNombre, mdlParametros.gprdProducto, dlSaldoAnteriorD, dlSaldoActualD, llTHSNumL, llTransNumL, slEmpresaTipoFact);
							};
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
						
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenEmpresa)",e);
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
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaEmpresa)",e );
				return result;
			}
			
			return result;
		}
		
		
		public clsSBFC430Empresa Add( int EmpNumL,  string EmpNumNomS,  clsProducto productoPRD,  double SaldoAnteriorD,  double SaldoActualD,  int THSNumL,  int TransNumL,  string TipoFactS, ref  string sKey)
		{
			//create a new object
			clsSBFC430Empresa objNewMember = new clsSBFC430Empresa();
			
			
			//set the properties passed into the method
			//    If IsObject(EmpNumNomS) Then
			//        Set objNewMember.EmpNumNomS = EmpNumNomS
			//    Else
			
			objNewMember.EmpNumL = EmpNumL;
			
			objNewMember.EmpNumNomS = EmpNumNomS;
			//    End If
			if (Information.IsReference(productoPRD))
			{
				objNewMember.productoPRD = productoPRD;
			} else
			{
				objNewMember.productoPRD = productoPRD;
			}
			objNewMember.SaldoAnteriorD = SaldoAnteriorD;
			objNewMember.SaldoActualD = SaldoActualD;
			objNewMember.THSNumL = THSNumL;
			objNewMember.TransNumL = TransNumL;
			objNewMember.TipoFactS = TipoFactS;
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
		
		public clsSBFC430Empresa Add( int EmpNumL,  string EmpNumNomS,  clsProducto productoPRD,  double SaldoAnteriorD,  double SaldoActualD,  int THSNumL,  int TransNumL,  string TipoFactS)
		{
			string tempRefParam = "";
			return Add(EmpNumL, EmpNumNomS, productoPRD, SaldoAnteriorD, SaldoActualD, THSNumL, TransNumL, TipoFactS, ref tempRefParam);
		}
		
		public clsSBFC430Empresa this[object vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsSBFC430Empresa) mCol[Convert.ToInt32(vntIndexKey)];
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
		
		
		public colcatSBFC430Empresa(){
			//creates the collection when this class is created
		}
	
	
	~colcatSBFC430Empresa(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}