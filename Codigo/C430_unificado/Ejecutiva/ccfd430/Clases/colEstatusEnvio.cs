using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
    //AIS-1157 NGONZALEZ
	internal class colEstatusEnvio
	: IEnumerable
	{
	
		
		private Collection mCol = new Collection();
		
		public void  prBuscaIntResumen()
		{
			
			int llEmpresa = 0;
			string slNombre = String.Empty;
			int ilEstatus = 0;
			int llTotal = 0;
			int llIndice = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " B.emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " A.emp_nom,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " count(B.rep_id),";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " B.env_estatus";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01 A, MTCENV01 B";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " A.eje_prefijo = B.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and A.gpo_banco = B.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and A.emp_num = B.emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and B.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and B.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and B.env_estatus <> 0";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and B.dest_id = 1";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " group by  B.eje_prefijo, A.eje_prefijo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " B.gpo_banco, A.gpo_banco,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " B.emp_num, A.emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " A.emp_nom , B.env_estatus";
					
					if (CORPROC2.Cuenta_Registros() > 0)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							this.prClear();
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								
								llEmpresa = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
								slNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
								llTotal = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
								ilEstatus = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
								
								llIndice = this.fncBuscaEmpresaL(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, llEmpresa);
								
								if (llIndice == 0)
								{
									if (ilEstatus == ((int) clsEstatusEnvio.iEstatusEnvio.Transmitido))
									{
										this.Add(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, llEmpresa, slNombre, 0, 0, "", llTotal);
									} else if (ilEstatus == ((int) clsEstatusEnvio.iEstatusEnvio.Pendiente)) { 
										this.Add(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, llEmpresa, slNombre, llTotal, 0, "", 0);
									} else if (ilEstatus == ((int) clsEstatusEnvio.iEstatusEnvio.NoTransmitido)) { 
										this.Add(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, llEmpresa, slNombre, 0, llTotal, "", 0);
									}
								} else
								{
									if (ilEstatus == ((int) clsEstatusEnvio.iEstatusEnvio.Transmitido))
									{
										this[llIndice].ArchivoTransmitidoL = llTotal;
									} else if (ilEstatus == ((int) clsEstatusEnvio.iEstatusEnvio.Pendiente)) { 
										this[llIndice].ArchivoPendienteEnvioL = llTotal;
									} else if (ilEstatus == ((int) clsEstatusEnvio.iEstatusEnvio.NoTransmitido)) { 
										this[llIndice].ArchivoNoTransmitidoL = llTotal;
									}
								}
							};
						}
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaIntResumen)",e );
				return;
			}
		}
		
		public int fncBuscaEmpresaL( int lpPrefijo,  int lpBanco,  int lpEmpresa)
		{
			int result = 0;
			
			for (int llCont = 1; llCont <= this.Count; llCont++)
			{
                //AIS-1135 NGONZALEZ
				if (this[llCont].PrefijoL == lpPrefijo && this[llCont].BancoL == lpBanco && this[llCont].EmpresaL == lpEmpresa)
				{
					result = llCont;
					break;
				}
			}
			
			return result;
		}
		
		public void  prClear()
		{
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
						this.Remove(llCont.ToString());
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(Clear)",e );
				return;
			}
			
			
		}
		
		public clsEstatusEnvio Add( int PrefijoL,  int BancoL,  int EmpresaL,  string NombreEmpresaS,  int ArchivoPendienteEnvioL,  int ArchivoNoTransmitidoL,  string FechaS,  int ArchivoTransmitidoL, ref  string sKey)
		{
			
			
			clsEstatusEnvio objNewMember = new clsEstatusEnvio();
			
			objNewMember.PrefijoL = PrefijoL;
			objNewMember.BancoL = BancoL;
			objNewMember.EmpresaL = EmpresaL;
			objNewMember.NombreEmpresaS = NombreEmpresaS;
			objNewMember.ArchivoPendienteEnvioL = ArchivoPendienteEnvioL;
			objNewMember.ArchivoNoTransmitidoL = ArchivoNoTransmitidoL;
			objNewMember.FechaS = FechaS;
			objNewMember.ArchivoTransmitidoL = ArchivoTransmitidoL;
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			return objNewMember;
			
		}
		
		public clsEstatusEnvio Add( int PrefijoL,  int BancoL,  int EmpresaL,  string NombreEmpresaS,  int ArchivoPendienteEnvioL,  int ArchivoNoTransmitidoL,  string FechaS,  int ArchivoTransmitidoL)
		{
			string tempRefParam = "";
			return Add(PrefijoL, BancoL, EmpresaL, NombreEmpresaS, ArchivoPendienteEnvioL, ArchivoNoTransmitidoL, FechaS, ArchivoTransmitidoL, ref tempRefParam);
		}
		
		public clsEstatusEnvio this[object vntIndexKey]
		{
			get
			{
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsEstatusEnvio) mCol[Convert.ToInt32(vntIndexKey)];
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
		
		public void  Remove( string vntIndexKey)
		{
            //AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
                mCol.Remove(vntIndexKey.ToString());
            else
                //AIS-1172 NGONZALEZ
                mCol.Remove(Convert.ToInt32(vntIndexKey));
		}
		
		
		~colEstatusEnvio(){
			mCol = null;
		}
}
}