using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colcatSBFEjecutivo
	: IEnumerable
	{
	
		
		private Collection mCol = new Collection();
		
		public void  prObtenEjecutivo( clsSBFEjecutivo.enuTipoSBFEjecutivo ipTipoSBF)
		{
			
			int llEmpNum = 0;
			int llEjeNum = 0;
			int ilRollOver = 0;
			int ilDigitoVerif = 0;
			string slEjeNom = String.Empty;
			double dlSaldoActual = 0;
			double dlSaldoAnterior = 0;
			
			try
			{
					
					if (ipTipoSBF == clsSBFEjecutivo.enuTipoSBFEjecutivo.tsbfEjecutivoSBF)
					{
						
						CORVAR.pszgblsql = "select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_roll_over,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_digit,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_nombre,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.sbf_saldo_previo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.sbf_saldo_actual";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " from";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCEJE01 a,";
						
						
						if (mdlParametros.IgEnvioSBF == 3)
						{
							//Descomentar esta línea -y comentar la siguiente- para ver un ejemplo
							//pszgblsql = pszgblsql & " RESPALDO_SBF02 b"
							
							CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCSBF02 b";
						} else
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCSBF06 b";
						}
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + mdlParametros.sgFiltroEmpresa;
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = b.sbf_eje_prefijo";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.sbf_gpo_banco";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = b.sbf_emp_num";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num = b.sbf_eje_num";
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " order by";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_num";
						
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							this.prClear();
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								llEmpNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								llEjeNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								ilRollOver = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 5));
								ilDigitoVerif = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 6));
								slEjeNom = VBSQL.SqlData(CORVAR.hgblConexion, 7);
								dlSaldoAnterior = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 8));
								dlSaldoActual = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 9));
								this.Add(mdlParametros.gprdProducto, llEmpNum, llEjeNum, ilRollOver, ilDigitoVerif, slEjeNom, dlSaldoActual, dlSaldoAnterior);
							};
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
						
					} else if (ipTipoSBF == clsSBFEjecutivo.enuTipoSBFEjecutivo.tsbfEjecutivoC430) { 
						
						CORVAR.pszgblsql = "select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_roll_over,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_digit,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_nombre,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.sbf_saldo_previo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " b.sbf_saldo_actual";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " from";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCEJE01 a,";
						
						
						if (mdlParametros.IgEnvioSBF == 3)
						{
							//Descomentar esta línea -y comentar la siguiente- para ver un ejemplo
							//pszgblsql = pszgblsql & " RESPALDO_tabla_b b"
							
							CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCSBF04 b";
						} else
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCSBF08 b";
						}
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + mdlParametros.sgFiltroEmpresa;
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = b.sbf_eje_prefijo";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = b.sbf_gpo_banco";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = b.sbf_emp_num";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num = b.sbf_eje_num";
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " order by";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_num";
						
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							this.prClear();
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								llEmpNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								llEjeNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								ilRollOver = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 5));
								ilDigitoVerif = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 6));
								slEjeNom = VBSQL.SqlData(CORVAR.hgblConexion, 7);
								dlSaldoAnterior = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 8));
								dlSaldoActual = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 9));
								this.Add(mdlParametros.gprdProducto, llEmpNum, llEjeNum, ilRollOver, ilDigitoVerif, slEjeNom, dlSaldoActual, dlSaldoAnterior);
							};
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenEjecutivo)",e );
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
		
		public int fncBuscaEjecutivoI( int lpEmNum)
		{
			
			int result = 0;
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
                        //AIS-1135 NGONZALEZ
						if (this[llCont].EmpNumL == lpEmNum)
						{
							result = llCont;
							break;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaEjecutivo)",e );
				return result;
			}
			
			return result;
		}
		
		public clsSBFEjecutivo Add( clsProducto productoPRD,  int EmpNumL,  int EjeNumL,  int RollOverI,  int DigitoVerifI,  string EjeNomS,  double SaldoActualD,  double SaldoAnteriorD, ref  string sKey)
		{
			
			
			clsSBFEjecutivo objNewMember = new clsSBFEjecutivo();
			
			if (Information.IsReference(productoPRD))
			{
				objNewMember.ProductoPRD = productoPRD;
			} else
			{
				objNewMember.ProductoPRD = productoPRD;
			}
			
			objNewMember.EmpNumL = EmpNumL;
			objNewMember.EjeNumL = EjeNumL;
			objNewMember.RollOverI = RollOverI;
			objNewMember.DigitoVerifI = DigitoVerifI;
			objNewMember.EjeNomS = EjeNomS;
			objNewMember.SaldoActualD = SaldoActualD;
			objNewMember.SaldoAnteriorD = SaldoAnteriorD;
			
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			return objNewMember;
			
		}
		
		public clsSBFEjecutivo Add( clsProducto productoPRD,  int EmpNumL,  int EjeNumL,  int RollOverI,  int DigitoVerifI,  string EjeNomS,  double SaldoActualD,  double SaldoAnteriorD)
		{
			string tempRefParam = "";
			return Add(productoPRD, EmpNumL, EjeNumL, RollOverI, DigitoVerifI, EjeNomS, SaldoActualD, SaldoAnteriorD, ref tempRefParam);
		}
		
		public clsSBFEjecutivo this[int vntIndexKey]
		{
			get
			{
				return (clsSBFEjecutivo) mCol[vntIndexKey];
			}
		}
		
		
		public int Count
		{
			get
			{
				return mCol.Count;
			}
		}
		
		
		
		public IEnumerator GetEnumerator()
		{
			return mCol.GetEnumerator();
		}
		
		public void  Remove( int vntIndexKey)
		{
                mCol.Remove((int)vntIndexKey);
		}
		
		
		~colcatSBFEjecutivo(){
			mCol = null;
		}
}
}