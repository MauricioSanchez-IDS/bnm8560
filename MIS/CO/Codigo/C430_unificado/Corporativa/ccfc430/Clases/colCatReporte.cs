using Microsoft.VisualBasic; 
using System; 
using System.Collections; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    //AIS-1157 NGONZALEZ
	internal class colCatReporte
	: IEnumerable
	{
	
		
		//local variable to hold collection
		private Collection mCol = new Collection();
		
		public string fncBuscaNombreReporteS(ref  string spIdReporteOrigen)
		{
			string result = String.Empty;
			int llCounter = 0;
			for (llCounter = 1; llCounter <= this.Count; llCounter++)
			{
				if (spIdReporteOrigen.IndexOf(this[llCounter].ReporteIdS) >= 0)
				{
					result = this[llCounter].NombreS;
					break;
				}
			}
			if (llCounter > this.Count)
			{
				MessageBox.Show("El reporte " + spIdReporteOrigen + " no es válido." + "\r\n" + "Reportelo a Sistemas.", "Reporte no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			return result;
		}
		
		public void  prObtenReportes()
		{
			
			int ilReportId = 0;
			string slReportId = String.Empty;
			string slNombre = String.Empty;
			
			
			int llIndice = 0;
			
			try
			{
					
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct convert(int,report_id) as ReporteId,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " report_id,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " report_name";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCREP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by ReporteId";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							ilReportId = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							slReportId = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
							slNombre = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
							llIndice = this.fncBuscaReporteL(ilReportId);
							if (llIndice == 0)
							{
								this.Add(ilReportId, slReportId, mdlParametros.grepReporte.MascaraS, slNombre);
							}
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(ObtenReportes)",e );
				return;
			}
			
		}
		
		public int fncBuscaReporteL( int ipReportId)
		{
			int result = 0;
			
			try
			{
					
					for (int llCont = 1; llCont <= this.Count; llCont++)
					{
                        //AIS-1135 NGONZALEZ
						if (this[llCont].ReporteIdI == ipReportId)
						{
							result = llCont;
							break;
						}
					}
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError(this.GetType().Name + "(BuscaReporteL)",e );
				return result;
			}
			
			return result;
		}
		
		public clsReporte Add( int ReporteIdI,  string ReporteIdS,  string MascaraS,  string NombreS, ref  string sKey)
		{
			//create a new object
			clsReporte objNewMember = new clsReporte();
			
			
			//set the properties passed into the method
			objNewMember.ReporteIdI = ReporteIdI;
			objNewMember.ReporteIdS = ReporteIdS;
			objNewMember.MascaraS = MascaraS;
			objNewMember.NombreS = NombreS;
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
		
		public clsReporte Add( int ReporteIdI,  string ReporteIdS,  string MascaraS,  string NombreS)
		{
			string tempRefParam = "";
			return Add(ReporteIdI, ReporteIdS, MascaraS, NombreS, ref tempRefParam);
		}
		
		public clsReporte this[object vntIndexKey]
		{
			get
			{
				//used when referencing an element in the collection
				//vntIndexKey contains either the Index or Key to the collection,
				//this is why it is declared as a Variant
				//Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
				//UPGRADE_WARNING: (1068) vntIndexKey of type Variant is being forced to int.
				return (clsReporte) mCol[Convert.ToInt32(vntIndexKey)];
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
		
		
		public void  Remove( string vntIndexKey)
		{
			//used when removing an element from the collection
			//vntIndexKey contains either the Index or Key, which is why
			//it is declared as a Variant
			//Syntax: x.Remove(xyz)


            //AIS-435 NGONZALEZ
            if (vntIndexKey is string || vntIndexKey is String)
                mCol.Remove(vntIndexKey.ToString());
            else
                //AIS-1172 NGONZALEZ
                mCol.Remove(Convert.ToInt32(vntIndexKey));
		}
		
		
		public colCatReporte(){
			//creates the collection when this class is created
		}
	
	
	~colCatReporte(){
		//destroys collection when this class is terminated
		mCol = null;
	}
}
}