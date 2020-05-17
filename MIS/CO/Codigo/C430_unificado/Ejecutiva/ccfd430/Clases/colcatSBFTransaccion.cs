using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
    //AIS-1157 NGONZALEZ
	internal class colcatSBFTransaccion
	: IEnumerable
	{
	
		
		private Collection mCol = new Collection();
		
		public void  prObtenTransaccion( clsSBFTransaccion.enuTipoSBFTransaccion ipTipoSBF)
		{
			
			int llEmpNum = 0;
			int llEjeNum = 0;
			int ilFProceso = 0;
			int ilFValor = 0;
			string slCveTrans = String.Empty;
			string slDescTrans = String.Empty;
			double dlImporte = 0;
			
			try
			{
					
					if (ipTipoSBF == clsSBFTransaccion.enuTipoSBFTransaccion.tsbfTransaccionSBF)
					{
						
						CORVAR.pszgblsql = "select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.eje_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.fecha_proceso,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.fecha_valor,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.codigo_tran,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.descripcion,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.monto_pesos";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " from";
						
						
						if (mdlParametros.IgEnvioSBF == 3)
						{
							// Quitar comentario cuando se revisen las tablas
							//pszgblsql = pszgblsql & " RESPALDO_SBF01 t"
							CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCSBF01 t";
						} else
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCSBF05 t";
						}
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and t.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and t.emp_num = " + mdlParametros.sgFiltroEmpresa;
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and t.eje_num = " + mdlParametros.sgFiltroEjecutivo;
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " order by";
						//        pszgblsql = pszgblsql & " t.eje_prefijo,"
						//        pszgblsql = pszgblsql & " t.gpo_banco,"
						//        pszgblsql = pszgblsql & " t.emp_num,"
						//        pszgblsql = pszgblsql & " t.eje_num,"
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.fecha_proceso,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.descripcion,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " t.monto_pesos";
						
						
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							this.prClear();
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								llEmpNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								llEjeNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								ilFProceso = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 5));
								ilFValor = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 6));
								slCveTrans = VBSQL.SqlData(CORVAR.hgblConexion, 7);
								slDescTrans = VBSQL.SqlData(CORVAR.hgblConexion, 8);
								dlImporte = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 9));
								this.Add(mdlParametros.gprdProducto, llEmpNum, llEjeNum, ilFProceso, ilFValor, slCveTrans, slDescTrans, dlImporte);
								
							};
						}
						
					} else if (ipTipoSBF == clsSBFTransaccion.enuTipoSBFTransaccion.tsbfTransaccionC430) { 
						
						CORVAR.pszgblsql = "select";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.gpo_banco,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.emp_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_num,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.fecha_proceso,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.fecha_valor,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.codigo_tran,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.descripcion,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.monto_pesos";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " from";
						
						
						if (mdlParametros.IgEnvioSBF == 3)
						{
							
							//Descomentar esta línea -y comentar la siguiente- para ver un ejemplo
							//pszgblsql = pszgblsql & " RESPALDO_tabla_a a"
							
							CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCSBF03 a";
						} else
						{
							CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCSBF07 a";
						}
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + mdlParametros.sgFiltroEmpresa;
						CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num = " + mdlParametros.sgFiltroEjecutivo;
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " order by";
						//        pszgblsql = pszgblsql & " a.eje_prefijo,"
						//        pszgblsql = pszgblsql & " a.gpo_banco,"
						//        pszgblsql = pszgblsql & " a.emp_num,"
						//        pszgblsql = pszgblsql & " a.eje_num,"
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.fecha_proceso,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.descripcion,";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " a.monto_pesos";
						
						
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							this.prClear();
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								llEmpNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								llEjeNum = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								ilFProceso = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 5));
								ilFValor = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 6));
								slCveTrans = VBSQL.SqlData(CORVAR.hgblConexion, 7);
								slDescTrans = VBSQL.SqlData(CORVAR.hgblConexion, 8);
								dlImporte = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 9));
								this.Add(mdlParametros.gprdProducto, llEmpNum, llEjeNum, ilFProceso, ilFValor, slCveTrans, slDescTrans, dlImporte);
							};
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenTransaccion)",e );
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
		
		public int fncBuscaTransaccionI( int lpEmpNum)
		{
			
			int result = 0;
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
                        //AIS-1135 NGONZALEZ
						if (this[llCont].EmpNumL == lpEmpNum)
						{
							result = llCont;
							break;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaTransaccion)",e );
				return result;
			}
			
			return result;
		}
		
		public clsSBFTransaccion Add( clsProducto productoPRD,  int EmpNumL,  int EjeNumL,  int FProcesoL,  int FValorL,  string CveTransS,  string DescTransS,  double ImporteD, ref  string sKey)
		{
			
			
			clsSBFTransaccion objNewMember = new clsSBFTransaccion();
			
			if (Information.IsReference(productoPRD))
			{
				objNewMember.ProductoPRD = productoPRD;
			} else
			{
				objNewMember.ProductoPRD = productoPRD;
			}
			
			objNewMember.EmpNumL = EmpNumL;
			objNewMember.EjeNumL = EjeNumL;
			objNewMember.FProcesoL = FProcesoL;
			objNewMember.FValorL = FValorL;
			objNewMember.CveTransS = CveTransS;
			objNewMember.DescTransS = DescTransS;
			objNewMember.ImporteD = ImporteD;
			
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			return objNewMember;
			
		}
		
		public clsSBFTransaccion Add( clsProducto productoPRD,  int EmpNumL,  int EjeNumL,  int FProcesoL,  int FValorL,  string CveTransS,  string DescTransS,  double ImporteD)
		{
			string tempRefParam = "";
			return Add(productoPRD, EmpNumL, EjeNumL, FProcesoL, FValorL, CveTransS, DescTransS, ImporteD, ref tempRefParam);
		}
		
		public clsSBFTransaccion this[int vntIndexKey]
		{
			get
			{
				return (clsSBFTransaccion) mCol[vntIndexKey];
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
            //AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
                mCol.Remove(vntIndexKey.ToString());
            else
                mCol.Remove((int)vntIndexKey);
		}
		
		
		~colcatSBFTransaccion(){
			mCol = null;
		}
}
}