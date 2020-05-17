using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Diagnostics; 
using System.Globalization; 
using System.IO; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class CCFmodGeneral
	{
	
		//Declaracion de variables generales
		//variables para los listviews
		static public string[] gsArchivo = ArraysHelper.InitializeArray<string>(16);
		static public string[] gsEmpresa = ArraysHelper.InitializeArray<string>(16);
		static public string[] gsUnidad = ArraysHelper.InitializeArray<string>(16);
		static public string[] gsTarjeta = ArraysHelper.InitializeArray<string>(16);
		static public string[] gsTransac = ArraysHelper.InitializeArray<string>(16);
		static public int[] giArchivo = new int[16];
		static public int[] giEmpresa = new int[16];
		static public int[] giUnidad = new int[16];
		static public int[] giTarjeta = new int[16];
		static public int[] giTransac = new int[16];
		
		//Estus del archivo seleccionado
		static public string ESTATUS_ARCHIVO = String.Empty;
		//Tamaño del archivo
		static public string TAMANIO_ARCHIVO = String.Empty;
		//TIPO_PERIODO es 0 si el periodo es diario es 1 si el periodo es al corte
		static public int TIPO_PERIODO = 0;
		//Variable para guardar el nombre del archivo a validar
		static public string NOMBRE_ARCHIVO = String.Empty;
		//Variable que guarda la fecha del proceso a efectuar
		static public string FECHA_PROCESO = String.Empty;
		//Variable para guardar la ruta donde se guardo el archivo
		static public string RUTA_ARCHIVO = String.Empty;
		//Variable para saber la empresa que ha sido seleccionada
		static public string EMPRESA_SEL = String.Empty;
		//Variable para saber qué unidad se ha seleccionado
		static public string UNIDAD_SEL = String.Empty;
		//Variable para saber qué TH se ha seleccionado
		static public string TH_SEL = String.Empty;
		//Variable para saber el número de cuenta
		static public string NUM_CUENTA = String.Empty;
		
		
		//'''CODIGO NUEVO ALBERTO
		static public void  IniciaHeaders()
		{
			gsArchivo[1] = "Nombre del Archivo";
			gsArchivo[2] = "Estatus";
			gsArchivo[3] = "Fec. VoBo";
			gsArchivo[4] = "Fec. Envio";
			gsArchivo[5] = "Fec. Confirmacion";
			gsArchivo[6] = "Tamaño (KB)";
			
			gsEmpresa[1] = "Origen";
			gsEmpresa[2] = "Empresa";
			gsEmpresa[3] = "Num. TH";
			gsEmpresa[4] = "Tipo Fac.";
			gsEmpresa[5] = "Num. Unidades";
			gsEmpresa[6] = "Saldo Anterior";
			gsEmpresa[7] = "Saldo Actual";
			gsEmpresa[8] = "Num. Tran";
			
			gsUnidad[1] = "Origen";
			gsUnidad[2] = "Unidad";
			gsUnidad[3] = "Nombre";
			gsUnidad[4] = "Num. TH";
			gsUnidad[5] = "Tipo Fac.";
			gsUnidad[6] = "Saldo Anterior";
			gsUnidad[7] = "Saldo Actual";
			gsUnidad[8] = "Num. Trans";
			
			gsTarjeta[1] = "Origen";
			gsTarjeta[2] = "Cuenta";
			gsTarjeta[3] = "Nombre Eje";
			gsTarjeta[4] = "Num. Tran";
			gsTarjeta[5] = "Saldo Anterior";
			gsTarjeta[6] = "Saldo Actual";
			
			gsTransac[1] = "Origen";
			gsTransac[2] = "Fecha Tran";
			gsTransac[3] = "Fecha Proceso";
			gsTransac[4] = "Clave Tran";
			gsTransac[5] = "Desc Tran";
			gsTransac[6] = "Importe";
			
			giArchivo[1] = 1600;
			giArchivo[2] = 1450;
			giArchivo[3] = 1750;
			giArchivo[4] = 1750;
			giArchivo[5] = 1750;
			giArchivo[6] = 1400;
			
			
			giEmpresa[1] = 700;
			giEmpresa[2] = 3000;
			giEmpresa[3] = 1000;
			giEmpresa[4] = 1000;
			giEmpresa[5] = 1500;
			giEmpresa[6] = 1500;
			giEmpresa[7] = 1500;
			giEmpresa[8] = 1500;
			
			giUnidad[1] = 700;
			giUnidad[2] = 1000;
			giUnidad[3] = 2500;
			giUnidad[4] = 1000;
			giUnidad[5] = 1000;
			giUnidad[6] = 1500;
			giUnidad[7] = 1500;
			giUnidad[8] = 1200;
			
			giTarjeta[1] = 700;
			giTarjeta[2] = 2000;
			giTarjeta[3] = 3000;
			giTarjeta[4] = 1000;
			giTarjeta[5] = 1400;
			giTarjeta[6] = 1400;
			
			giTransac[1] = 700;
			giTransac[2] = 1500;
			giTransac[3] = 1500;
			giTransac[4] = 1500;
			giTransac[5] = 2500;
			giTransac[6] = 1500;
		}
		
		static public void  AddHeaderLst( AxMSComctlLib.AxListView plst,  int piNumCol,  string[] psHeaders,  int[] piLong)
		{
			try
			{
					plst.View = MSComctlLib.ListViewConstants.lvwReport;
					plst.GridLines = true;
					plst.LabelEdit = MSComctlLib.ListLabelEditConstants.lvwManual;
					plst.ColumnHeaders.Clear();
					plst.ListItems.Clear();
					for (int ilcont = 1; ilcont <= piNumCol; ilcont++)
					{
						object tempRefParam = ilcont;
						object tempRefParam2 = psHeaders[ilcont];
						object tempRefParam3 = psHeaders[ilcont];
						object tempRefParam4 = piLong[ilcont];
						object tempRefParam5 = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
						object tempRefParam6 = Type.Missing;
						plst.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
					}
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("no se pudieron poner los encabezados : " + excep.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		static public void  LlenaLst( AxMSComctlLib.AxListView plst,  int piNumCol, ref  string psQry,  AxMSComctlLib.AxImageList pimglist)
		{

			MSComctlLib.IListItem nlnodo = null;
			try
			{
					int ikey = 0;
					int iCont = 0;
					bool bolCompleta = false;
					
					bolCompleta = false;
					ikey = 0;
					if (CORPROC2.ObtieneRegistros(ref psQry) != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							ikey++;
							object tempRefParam = ikey;
							object tempRefParam2 = "k" + ikey.ToString();
							object tempRefParam3 = VBSQL.SqlData(CORVAR.hgblConexion, 1);
							object tempRefParam4 = Type.Missing;
							object tempRefParam5 = Type.Missing;
                            //AIS-767 NGONZALEZ
							 nlnodo = plst.ListItems.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5);
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
							nlnodo.set_SubItems(1, (Convert.IsDBNull(VBSQL.SqlData(CORVAR.hgblConexion, 2))) ? "": VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
							for (double ilcont = 2; ilcont <= (piNumCol - 1); ilcont++)
							{
								double dbNumericTemp = 0;
								if (Double.TryParse(VBSQL.SqlData(CORVAR.hgblConexion, Convert.ToInt32(ilcont + 1)), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
								{
									if ((VBSQL.SqlData(CORVAR.hgblConexion, Convert.ToInt32(ilcont + 1)).Trim().IndexOf('.') + 1) > 1)
									{
										if ((VBSQL.SqlData(CORVAR.hgblConexion, Convert.ToInt32(ilcont + 1)).Trim().Length - (VBSQL.SqlData(CORVAR.hgblConexion, Convert.ToInt32(ilcont + 1)).Trim().IndexOf('.') + 1)) < 2)
										{
											bolCompleta = true;
											object tempRefParam6 = ilcont + 1;
											plst.ColumnHeaders.get_Item(ref tempRefParam6).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnRight;
										} else
										{
											object tempRefParam7 = ilcont + 1;
											plst.ColumnHeaders.get_Item(ref tempRefParam7).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnRight;
										}
									} else
									{
										object tempRefParam8 = ilcont + 1;
										plst.ColumnHeaders.get_Item(ref tempRefParam8).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnRight;
									}
								} else
								{
									object tempRefParam9 = ilcont + 1;
									plst.ColumnHeaders.get_Item(ref tempRefParam9).Alignment = MSComctlLib.ListColumnAlignmentConstants.lvwColumnLeft;
								}
								if (bolCompleta)
								{
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.

									nlnodo.set_SubItems((short)ilcont, (Convert.IsDBNull(VBSQL.SqlData(CORVAR.hgblConexion, Convert.ToInt32(ilcont + 1)))) ? "": VBSQL.SqlData(CORVAR.hgblConexion, Convert.ToInt32(ilcont + 1)).Trim() + "0");
								} else
								{
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
									nlnodo.set_SubItems((short)ilcont, (Convert.IsDBNull(VBSQL.SqlData(CORVAR.hgblConexion, Convert.ToInt32(ilcont + 1)))) ? "": VBSQL.SqlData(CORVAR.hgblConexion, Convert.ToInt32(ilcont + 1)).Trim());
								}
								bolCompleta = false;
							}
						};
					}
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("No se Pudo llenar el listview: " + excep.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		static public void  LlenaLst( AxMSComctlLib.AxListView plst,  int piNumCol, ref  string psQry)
		{
			LlenaLst(plst, piNumCol, ref psQry, null);
		}
		static public void  ReportCCF( AxMSComctlLib.AxListView plista,  string spFileName,  string spnameform)
		{
			int ilArch = 0;
			try
			{
					string slMensaje = String.Empty;
					string sldir = String.Empty;
					string slfile = String.Empty;
					
					ilArch = FileSystem.FreeFile();
					/*sldir = "c:\\APPS\\c430\\deposito\\";*/
                    sldir = mdlParametros.sgPathRepEmpresas;
					if (! Directory.Exists(sldir))
					{
						Directory.CreateDirectory(sldir);
					}
					
					slfile = sldir + spFileName;
					
					if (FileSystem.Dir(slfile, FileAttribute.Archive) != "")
					{
						//Borra el archivo destino si es que existe
						File.Delete(slfile);
					}
					
					FileSystem.FileOpen(ilArch, slfile, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
					FileSystem.PrintLine(ilArch, "Nombre : " + NOMBRE_ARCHIVO + " Tamaño: " + TAMANIO_ARCHIVO + " KB");
					slMensaje = "\r" + "\n" + "=================================================================================================================================================";
					slMensaje = slMensaje + "\r" + "\n" + "\t" + spnameform + "\r" + "\n" + "=================================================================================================================================================" + "\n";
					FileSystem.PrintLine(ilArch, slMensaje);
					object tempRefParam = 1;
					FileSystem.Print(ilArch, plista.ColumnHeaders.get_Item(ref tempRefParam).Text.ToUpper());
					for (int iContCol = 2; iContCol <= plista.ColumnHeaders.Count; iContCol++)
					{
						object tempRefParam2 = iContCol;
						FileSystem.Print(ilArch, FileSystem.TAB((short) ((iContCol - 1) * 20)), plista.ColumnHeaders.get_Item(ref tempRefParam2).Text.ToUpper());
					}
					FileSystem.PrintLine(ilArch);
					for (int iContReg = 1; iContReg <= plista.ListItems.Count; iContReg++)
					{
						object tempRefParam3 = iContReg;
						FileSystem.Print(ilArch, plista.ListItems.get_ControlDefault(ref tempRefParam3).Text);
						for (int iContCol = 1; iContCol <= (plista.ColumnHeaders.Count - 1); iContCol++)
						{
							object tempRefParam4 = iContCol;
							object tempRefParam5 = iContReg;
							FileSystem.Print(ilArch, FileSystem.TAB((short) (iContCol * 20)), Strings.Mid(plista.ListItems.get_ControlDefault(ref tempRefParam5).ListSubItems.get_ControlDefault(ref tempRefParam4).Default, 1, 18));
						}
						FileSystem.PrintLine(ilArch);
					}
					FileSystem.FileClose(ilArch);
					//UPGRADE_WARNING: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo
					ProcessStartInfo startInfo = new ProcessStartInfo("write.exe", slfile);
					startInfo.WindowStyle = ProcessWindowStyle.Normal;
					Process.Start(startInfo); //Muestra el Reporte
				}
			catch (Exception excep)
			{
				
				MessageBox.Show("No se Pudo Escribir el Reporte : " + excep.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				FileSystem.FileClose(ilArch);
			}
		}
		
		
		static public void  FunVerificaArchivoCCF( string LsNombreArchivo)
		{
			
		}

        static public String searchStr = "";
        static public void ListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListBox lst = sender as ListBox;

            CORMDIBN.DefInstance.timer1.Enabled = false;

            lock (searchStr)
            {
                searchStr += e.KeyChar;
            }

            int i = lst.FindString(searchStr);

            if (i != -1)

                lst.SetSelected(i, true);

            CORMDIBN.DefInstance.timer1.Enabled = true;

            e.Handled = true;


        }

        static public void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            CORMDIBN.DefInstance.timer1.Enabled = false;

            lock (searchStr)
            {
                searchStr += e.KeyChar;
            }

            int i = cbo.FindString(searchStr);

            if (i != -1)
                cbo.SelectedIndex = i;

            CORMDIBN.DefInstance.timer1.Enabled = true;

            e.Handled = true;
        }

	}
}