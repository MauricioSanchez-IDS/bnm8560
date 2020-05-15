using Microsoft.VisualBasic; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal class clsREPReporte
	{
	
		public string slSaltoPagina = String.Empty;
		private clsREPEncabezado mvarclsEncabezado = new clsREPEncabezado();
		private clsREPCuerpo mvarclsCuerpo = new clsREPCuerpo();
		private clsREPPiePagina mvarclsPiePagina = new clsREPPiePagina();
		//local variable(s) to hold property value(s)
		private string mvarNombreS = String.Empty; //local copy
		private int mvarTotalPaginasL = 0; //local copy
		private int mvarRenglonesPorPaginaI = 0; //local copy
		private int mvarColumnasPorPaginaI = 0; //local copy
		private bool mvarSeparadorB = false; //local copy
		//local variable(s) to hold property value(s)
		private string mvarCadenaSeparadorS = String.Empty; //local copy
		
		
		public string CadenaSeparadorS
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.CadenaSeparadorS
				return mvarCadenaSeparadorS;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.CadenaSeparadorS = 5
				mvarCadenaSeparadorS = value;
			}
		}
		
		
		
		
		public bool SeparadorB
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.SeparadorB
				return mvarSeparadorB;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.SeparadorB = 5
				mvarSeparadorB = value;
			}
		}
		
		
		
		
		
		
		public int ColumnasPorPaginaI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.ColumnasPorPaginaI
				return mvarColumnasPorPaginaI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.ColumnasPorPaginaI = 5
				mvarColumnasPorPaginaI = value;
				clsCuerpo.ColumnasI = mvarColumnasPorPaginaI;
				clsEncabezado.ColumnasI = mvarColumnasPorPaginaI;
				clsPiePagina.ColumnasI = mvarColumnasPorPaginaI;
			}
		}
		
		
		
		
		
		
		public int RenglonesPorPaginaI
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.RenglonesPorPaginaI
				return mvarRenglonesPorPaginaI;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.RenglonesPorPaginaI = 5
				mvarRenglonesPorPaginaI = value;
			}
		}
		
		
		
		
		
		
		public int TotalPaginasL
		{
			get
			{
				//used when retrieving value of a property, on the right side of an assignment.
				//Syntax: Debug.Print X.TotalPaginasL
				return mvarTotalPaginasL;
			}
			set
			{
				//used when assigning a value to the property, on the left side of an assignment.
				//Syntax: X.TotalPaginasL = 5
				mvarTotalPaginasL = value;
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
		
		
		
		
		
		
		
		
		public clsREPPiePagina clsPiePagina
		{
			get
			{
				return mvarclsPiePagina;
			}
			set
			{
				mvarclsPiePagina = value;
			}
		}
		
		
		
		
		
		
		public clsREPCuerpo clsCuerpo
		{
			get
			{
				return mvarclsCuerpo;
			}
			set
			{
				mvarclsCuerpo = value;
			}
		}
		
		
		
		
		
		public clsREPEncabezado clsEncabezado
		{
			get
			{
				return mvarclsEncabezado;
			}
			set
			{
				mvarclsEncabezado = value;
			}
		}
		
		
		public void  InicializaEncabezado()
		{
			clsEncabezado = new clsREPEncabezado();
		}
		
		public void  InicializaCuerpo()
		{
			clsCuerpo = new clsREPCuerpo();
		}
		
		public void  InicializaPiePagina()
		{
			clsPiePagina = new clsREPPiePagina();
		}
		
		
		
		public void  prGenerarReporte( string spArchivo,  int lpPaginaInicial,  int lpPaginaFinal,  bool bpValidaSaltoPagina)
		{
			int ilRenglonePorPagina = 0;
			int ilRegistros = 0;
			string ilRenglonesCuerpo = String.Empty;
			int ilIndicePiePagina = 0;
			int ilArchivoDisponible = 0;
			try
			{
					Cursor.Current = Cursors.WaitCursor;
					//Obten Lineas de Encabezado
					//  Me.clsEncabezado.RenglonesI
					//Obten Lineas de Pie de Página
					//  Me.clsPiePagina.RenglonesI
					//Analiza si se solicita un separador
					//Determina que se abra correctamente el archivo
					ilArchivoDisponible = FileSystem.FreeFile();
					if (SeparadorB)
					{
						ilRenglonesCuerpo = (RenglonesPorPaginaI - this.clsEncabezado.RenglonesI - this.clsPiePagina.RenglonesI - 2).ToString();
					} else
					{
						ilRenglonesCuerpo = (RenglonesPorPaginaI - this.clsEncabezado.RenglonesI - this.clsPiePagina.RenglonesI).ToString();
					}
					//Determina el número de renglones que se requiere para el cuerpo de cada reporte
					if (bpValidaSaltoPagina)
					{
						ilRenglonesCuerpo = (Double.Parse(ilRenglonesCuerpo) - 2).ToString();
					}
					FileSystem.FileOpen(ilArchivoDisponible, spArchivo, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
					//    For ilRegistros = 1 To clsCuerpo.RenglonesI
					//Imprime en Archivo Encabezado
					for (int ilIndiceEncabezado = 1; ilIndiceEncabezado <= clsEncabezado.LineasREN.Count; ilIndiceEncabezado++)
					{
						FileSystem.PrintLine(ilArchivoDisponible, clsEncabezado.LineasREN[ilIndiceEncabezado].ContenidoS);
					}
					//Analiza si requiere separador
					//      If SeparadorB = True Then
					FileSystem.PrintLine(ilArchivoDisponible, CadenaSeparadorS);
					//      End If
					for (int ilRenglones = 1; ilRenglones <= clsCuerpo.LineasREN.Count; ilRenglones++)
					{
						//Analiza la linea si es salto de página regresa al bloque anterior (BA)
						//        If InStr(1, slSaltoPagina, clsCuerpo.LineasREN.Item(ilRenglones)) <> 0 Then
						//        'Rellena los renglones que hacen falta
						//          While ilRenglones <= ilRenglonesCuerpo
						//            Print #ilArchivoDisponible, ""
						//            ilRenglones = ilRenglones + 1
						//          Wend
						//        Else
						//Imprime la siguiente linea y almacena el indice
						FileSystem.PrintLine(ilArchivoDisponible, clsCuerpo.LineasREN[ilRenglones].ContenidoS);
						//        End If
						//      Next
						//Analiza si requiere separador
						//      If SeparadorB = True Then
						//        Print #ilArchivoDisponible, CadenaSeparadorS
						//      End If
						//Imprime Pie Pagina
					}
					FileSystem.PrintLine(ilArchivoDisponible, CadenaSeparadorS);
					for (int ilIndiceEncabezado = 1; ilIndiceEncabezado <= clsPiePagina.RenglonesI; ilIndiceEncabezado++)
					{
						FileSystem.PrintLine(ilArchivoDisponible, clsPiePagina.LineasREN[ilIndiceEncabezado].ContenidoS);
					}
					FileSystem.FileClose(ilArchivoDisponible);
					Cursor.Current = Cursors.Default;
				}
                catch (Exception e)
			{
				
				CRSGeneral.prObtenError("GenerarReporte",e );
			}
		}
		
		public void  prGenerarReporte( string spArchivo,  int lpPaginaInicial,  int lpPaginaFinal)
		{
			prGenerarReporte(spArchivo, lpPaginaInicial, lpPaginaFinal, true);
		}
		
		public void  prGenerarReporte( string spArchivo,  int lpPaginaInicial)
		{
			prGenerarReporte(spArchivo, lpPaginaInicial, 0, true);
		}
		
		public void  prGenerarReporte( string spArchivo)
		{
			prGenerarReporte(spArchivo, 0, 0, true);
		}
		
		
		
		public clsREPReporte(){
			//create the mclsEncabezado object when the clsReporte class is created
			//create the mclsCuerpo object when the clsReporte class is created
			//create the mclsPiePagina object when the clsReporte class is created
		}
	~clsREPReporte(){
		mvarclsPiePagina = null;
		mvarclsCuerpo = null;
		mvarclsEncabezado = null;
	}
}
}