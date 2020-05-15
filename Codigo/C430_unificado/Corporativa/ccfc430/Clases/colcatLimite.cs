using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colcatLimite
	: IEnumerable
	{
	
		
		private Collection mCol = new Collection();
		
		public void  prObtenLimite()
		{
			
			string slCtaBnx = String.Empty;
			int llLimAnt = 0;
			int llLimPost = 0;
			string slUsuMaker = String.Empty;
			string slNomMaker = String.Empty;
			int llFecMaker = 0;
			int llHorMaker = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_cta_bnx,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_cred_ant,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_cred_post,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_usu_maker,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_nom_maker,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_fecha_maker,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " lim_hora_maker";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCLIM01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and lim_usu_checker in (NULL,' ')";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by lim_fecha_maker, lim_hora_maker";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						this.prClear();
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							slCtaBnx = VBSQL.SqlData(CORVAR.hgblConexion, 1);
							llLimAnt = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
							llLimPost = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
							slUsuMaker = VBSQL.SqlData(CORVAR.hgblConexion, 4);
							slNomMaker = VBSQL.SqlData(CORVAR.hgblConexion, 5);
							llFecMaker = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 6));
							llHorMaker = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 7));
							this.Add(mdlParametros.gprdProducto, slCtaBnx, llLimAnt, llLimPost, slUsuMaker, slNomMaker, llFecMaker, llHorMaker);
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenLimite)",e);
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
		
		public clsLimite Add( clsProducto LimProductoPRD,  string LimCtaBnxS,  int LimCredAntL,  int LimCredPostL,  string LimUsuMakerS,  string LimNomMakerS,  int LimFechaMakerL,  int LimHoraMakerL,  string LimUsuCheckerS,  string LimNomCheckerS,  int LimFechaCheckerL,  int LimHoraCheckerL, ref  string sKey)
		{
			
			
			clsLimite objNewMember = new clsLimite();
			
			if (Information.IsReference(LimProductoPRD))
			{
				objNewMember.LimProductoPRD = LimProductoPRD;
			} else
			{
				objNewMember.LimProductoPRD = LimProductoPRD;
			}
			
			objNewMember.LimCtaBnxS = LimCtaBnxS;
			objNewMember.LimCredAntL = LimCredAntL;
			objNewMember.LimCredPostL = LimCredPostL;
			objNewMember.LimUsuMakerS = LimUsuMakerS;
			objNewMember.LimNomMakerS = LimNomMakerS;
			objNewMember.LimFechaMakerL = LimFechaMakerL;
			objNewMember.LimHoraMakerL = LimHoraMakerL;
			
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
			if (! Convert.IsDBNull(LimUsuCheckerS))
			{
				objNewMember.LimUsuCheckerS = LimUsuCheckerS;
			} else
			{
				objNewMember.LimUsuCheckerS = "";
			}
			
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
			if (! Convert.IsDBNull(LimNomCheckerS))
			{
				objNewMember.LimNomCheckerS = LimNomCheckerS;
			} else
			{
				objNewMember.LimNomCheckerS = "";
			}
			
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
			if (! Convert.IsDBNull(LimFechaCheckerL))
			{
				objNewMember.LimFechaCheckerL = LimFechaCheckerL;
			} else
			{
				objNewMember.LimFechaCheckerL = 0;
			}
			
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
			if (! Convert.IsDBNull(LimHoraCheckerL))
			{
				objNewMember.LimHoraCheckerL = LimHoraCheckerL;
			} else
			{
				objNewMember.LimHoraCheckerL = 0;
			}
			
			if (sKey.Length == 0)
			{
				mCol.Add(objNewMember, null, null, null);
			} else
			{
				mCol.Add(objNewMember, sKey, null, null);
			}
			
			return objNewMember;
			
		}
		
		public clsLimite Add( clsProducto LimProductoPRD,  string LimCtaBnxS,  int LimCredAntL,  int LimCredPostL,  string LimUsuMakerS,  string LimNomMakerS,  int LimFechaMakerL,  int LimHoraMakerL,  string LimUsuCheckerS,  string LimNomCheckerS,  int LimFechaCheckerL,  int LimHoraCheckerL)
		{
			string tempRefParam = "";
			return Add(LimProductoPRD, LimCtaBnxS, LimCredAntL, LimCredPostL, LimUsuMakerS, LimNomMakerS, LimFechaMakerL, LimHoraMakerL, LimUsuCheckerS, LimNomCheckerS, LimFechaCheckerL, LimHoraCheckerL, ref tempRefParam);
		}
		
		public clsLimite Add( clsProducto LimProductoPRD,  string LimCtaBnxS,  int LimCredAntL,  int LimCredPostL,  string LimUsuMakerS,  string LimNomMakerS,  int LimFechaMakerL,  int LimHoraMakerL,  string LimUsuCheckerS,  string LimNomCheckerS,  int LimFechaCheckerL)
		{
			string tempRefParam2 = "";
			return Add(LimProductoPRD, LimCtaBnxS, LimCredAntL, LimCredPostL, LimUsuMakerS, LimNomMakerS, LimFechaMakerL, LimHoraMakerL, LimUsuCheckerS, LimNomCheckerS, LimFechaCheckerL, 0, ref tempRefParam2);
		}
		
		public clsLimite Add( clsProducto LimProductoPRD,  string LimCtaBnxS,  int LimCredAntL,  int LimCredPostL,  string LimUsuMakerS,  string LimNomMakerS,  int LimFechaMakerL,  int LimHoraMakerL,  string LimUsuCheckerS,  string LimNomCheckerS)
		{
			string tempRefParam3 = "";
			return Add(LimProductoPRD, LimCtaBnxS, LimCredAntL, LimCredPostL, LimUsuMakerS, LimNomMakerS, LimFechaMakerL, LimHoraMakerL, LimUsuCheckerS, LimNomCheckerS, 0, 0, ref tempRefParam3);
		}
		
		public clsLimite Add( clsProducto LimProductoPRD,  string LimCtaBnxS,  int LimCredAntL,  int LimCredPostL,  string LimUsuMakerS,  string LimNomMakerS,  int LimFechaMakerL,  int LimHoraMakerL,  string LimUsuCheckerS)
		{
			string tempRefParam4 = "";
			return Add(LimProductoPRD, LimCtaBnxS, LimCredAntL, LimCredPostL, LimUsuMakerS, LimNomMakerS, LimFechaMakerL, LimHoraMakerL, LimUsuCheckerS, "", 0, 0, ref tempRefParam4);
		}
		
		public clsLimite Add( clsProducto LimProductoPRD,  string LimCtaBnxS,  int LimCredAntL,  int LimCredPostL,  string LimUsuMakerS,  string LimNomMakerS,  int LimFechaMakerL,  int LimHoraMakerL)
		{
			string tempRefParam5 = "";
			return Add(LimProductoPRD, LimCtaBnxS, LimCredAntL, LimCredPostL, LimUsuMakerS, LimNomMakerS, LimFechaMakerL, LimHoraMakerL, "", "", 0, 0, ref tempRefParam5);
		}
		
		public clsLimite this[int vntIndexKey]
		{
			get
			{
				return (clsLimite) mCol[vntIndexKey];
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
		
		public void  Remove( object vntIndexKey)
		{
            //AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
                mCol.Remove(vntIndexKey.ToString());
            else
                mCol.Remove((int)vntIndexKey);
		}
		
		
		~colcatLimite(){
			mCol = null;
		}
}
}
