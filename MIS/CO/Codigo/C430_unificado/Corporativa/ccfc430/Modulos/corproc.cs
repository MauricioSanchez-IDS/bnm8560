using Artinsoft.VB6.Utils; 
using Artinsoft.VB6.VB; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Diagnostics; 
using System.Drawing; 
using System.Runtime.InteropServices; 
using System.Text; 
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	class CORPROC
	{
	
		
		//Constantes para Impresión
		const int INT_MAX_LINEAS_H = 40; //Máximo número de Líneas horizontales
		const int INT_MAX_LINEAS_V = 80; //Máximo número de Líneas verticales
		const int INT_ESPACIOS_BLANCOS_H = 80;
		const int INT_ESPACIOS_BLANCOS_V = 60;
		//***** INICIO CODIGO ANTERIOR FSWBMX *****
		//Const INT_ESPACIOS_CABECERA = 5
		//***** FIN DE CODIGO ANTERIOR FSWBMX *****
		//***** INICIO CODIGO NUEVO FSWBMX *****
		const int INT_ESPACIOS_CABECERA = 7;
		//***** FIN DE CODIGO NUEVO FSWBMX *****
		
		//Variables para Impresión Texto de Reportes
		static int iMaxRenglones = 0;
		static int iMaxcolumnas = 0;
		static int iContRen = 0;
		static int iContCol = 0;
		static int iFlood = 0;
		static int iContLineas = 0;
		static int iLineasAImp = 0;
		static string ppszCadenaImp = String.Empty;
		static string ppszCadenaTemp = String.Empty;
		static int bColorCamb = 0;
		static string pszFecha = String.Empty;
		static string pszCadena1 = String.Empty;
		static string pszCadena2 = String.Empty;
		static string pszCadena3 = String.Empty;
		static string pszCadena4 = String.Empty;
		static string pszCadena5 = String.Empty;
		static string pszCadena6 = String.Empty;
		static string pszCadena7 = String.Empty;
		static string pszCadena8 = String.Empty;
		static string pszHeaderSS = String.Empty;
		static string pszTitRep = String.Empty;
		
		
		static public void  Abre_Word( string pszParametro)
		{
			
			int iResp = 0;
			string pszVentana = String.Empty;
			string pszRuta = String.Empty;
			
			Information.Err().Number = CORCONST.OK;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					int iError = CORCONST.OK;
					
					Information.Err().Number = CORCONST.OK;
					
					if (pszParametro == "Domicilio")
					{
						pszRuta = CORVAR.pszgblPathWordDom;
					} else
					{
						pszRuta = CORVAR.pszgblPathWordCred;
					}
					
					//verifica si existe el archivo
					string pszCadena = FileSystem.Dir(pszRuta, FileAttribute.Normal);
					
					//si existe el archivo
					if (pszCadena == CORVB.NULL_STRING)
					{
						MessageBox.Show("No existe el archivo " + pszRuta, Application.ProductName);
						return;
					}
					
					//UPGRADE_WARNING: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo
					ProcessStartInfo startInfo = new ProcessStartInfo(CORVAR.pszgblPathWord , pszRuta);
					startInfo.WindowStyle = ProcessWindowStyle.Normal;
					iError = Convert.ToInt32(Process.Start(startInfo).Id);
					
					Application.DoEvents();
					//  AppActivate iError
					
					switch(Information.Err().Number)
					{
						case CORCONST.INT_NO_APLICACION : 
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; 
							Cursor.Current = Cursors.Default; 
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
							iResp = (int) Interaction.MsgBox(CORSTR.ERR_PATH_DOC + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_CUESTIONA_OTRA_RUTA, (MsgBoxStyle) (CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT); 
							if (iResp == CORVB.IDYES)
							{
								pszRuta = Interaction.InputBox(CORSTR.STR_AVISO_ORDEN, CORSTR.STR_APP_TIT, pszRuta, 0, 0);
								if (pszRuta == CORVB.NULL_STRING)
								{
									return;
								} else
								{
									Information.Err().Number = CORCONST.OK;
								}
							} 
							break;
						case CORCONST.INT_NO_PATH : 
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; 
							Cursor.Current = Cursors.Default; 
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
							iResp = (int) Interaction.MsgBox(CORSTR.ERR_DDE_PATH_NOT_FOUND + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_CUESTIONA_INTRO, (MsgBoxStyle) (CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT); 
							if (iResp == CORVB.IDYES)
							{
								pszRuta = Interaction.InputBox(CORSTR.STR_AVISO_ORDEN, CORSTR.STR_APP_TIT, pszRuta, 0, 0);
								if (pszRuta == CORVB.NULL_STRING)
								{
									return;
								} else
								{
									Information.Err().Number = CORCONST.OK;
								}
							} 
							break;
						case CORCONST.INT_NO_MEMORIA : 
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; 
							Cursor.Current = Cursors.Default; 
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
							Interaction.MsgBox(CORSTR.ERR_DDE_NO_MEMORIA, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
							return;
						default:
							if (Information.Err().Number != CORCONST.OK && Information.Err().Number != 6)
							{
								CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
								Cursor.Current = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox(CORSTR.ERR_ERROR_DESC, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
							} 
							break;
					}
					
					//Controlamos Cualquier Error que se genere al abrir word
					//UPGRADE_NOTE: (7001) The following code block (empty try-catch) seems to be dead code
					//try
					//{
						//}
					//catch 
					//{
					//}
					
					
					
					
					if (Information.Err().Number != CORVB.NULL_INTEGER)
					{
						MessageBox.Show("Error # " + Conversion.Str(Information.Err().Number) + " se generó por " + Information.Err().Description, Application.ProductName);
						return;
					}
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
			
			
		}
		
		static public void  Activa_Aplicacion(ref  int iErr,  string pszVentana)
		{
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					if (iErr == CORCONST.INT_TIEMPO_TERM)
					{
						Information.Err().Number = CORCONST.OK;
						Interaction.AppActivate("Microsoft Excel");
						Application.DoEvents();
						if (Information.Err().Number == CORCONST.INT_LLAMADA_ILEGAL)
						{
							Interaction.AppActivate("Microsoft Excel - " + pszVentana);
							iErr = Information.Err().Number;
						}
					}
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
		}
		
		//****************************************************************************
		//**                                                                        **
		//**       Descripción: Crea un grupo por default si no existen Grupos      **
		//**                    en el Catálogo CMTCOR01                             **
		//**                                                                        **
		//**       Declaración: Sub Alta_GrupoDefault                               **
		//**                                                                        **
		//**       Paso de parámetros: Ninguno                                      **
		//**                                                                        **
		//**       Valor de Regreso: Ninguno                                        **
		//**                                                                        **
		//**       Variables globales que modifica :                                **
		//**           Al Proyecto :                                                **
		//**           A la forma : iErr                                            **
		//**                                                                        **
		//**       Ultima modificacion: 030594                                      **
		//**                                                                        **
		//****************************************************************************
		static public void  Alta_GrupoDefault(ref  int iErr,  int hConexion)
		{
			
			string pszSentencia = String.Empty;
			int hBufGrupo = 0;
			int iTempErr = 0;
			
			iErr = CORCONST.OK;
			//***** INICIO CODIGO ANTERIOR FSWBMX *****
			//  pszgblsql = "insert " + DB_SYB_COR + " values(" + Format$(igblBanco) + ",0,'[SIN GRUPO]','','',0,'','','')"
			//***** FIN DE CODIGO ANTERIOR FSWBMX *****
			//***** INICIO CODIGO NUEVO FSWBMX *****
			CORVAR.pszgblsql = "insert " + CORBD.DB_SYB_COR + " values(" + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + ",0,'[SIN GRUPO]','','',0,'','','',NULL,NULL,NULL)";
			//***** FIN DE CODIGO NUEVO FSWBMX *****
			
			if (CORPROC2.Modifica_Registro() != 0)
			{
			}
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			
		}
		
		
		
		static public void  Cambia_StatusOpciones( int bStatus)
		{
			CORMDIBN.DefInstance.IDM_IMP.Enabled = bStatus != 0;
			CORMDIBN.DefInstance.IDM_EXC.Enabled = bStatus != 0;
			CORMDIBN.DefInstance.IDM_TXT.Enabled = bStatus != 0;
			CORMDIBN.DefInstance.IDM_FMT.Enabled = bStatus != 0;
			//  CORMDIBN!IDM_DBS.Enabled = bStatus
			
		}
		
		//****************************************************************************
		//**                                                                        **
		//**   Descripción:                                                         **
		//**     Exporta los datos de un Spread Sheet a Excel                       **
		//**                                                                        **
		//**   Declaración:                                                         **
		//**     Sub DDE_Excel (cSpread as vaSpread)                             **
		//**                                                                        **
		//**   Paso de Parámetros: La forma y El vaSpread                        **
		//**                                                                        **
		//**   Variables globales que modifica: Ninguna                             **
		//**                                                                        **
		//****************************************************************************
		static public void  DDE_Excel( AxFPSpread.AxvaSpread cSpread)
		{
			
		/*	int iCountCol = 0;
			int iCountRow = 0;
			int iExcelCol = 0;
			int iTempCol = 0;
			int iTempRow = 0;
			string pszCell = String.Empty;
			int iResp = 0;
			int iFlood = 0;
			double dPauseTime = 0;
			double dStart = 0;
			
			
			Information.Err().Number = CORCONST.OK;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					string pszFullName = CORVB.NULL_STRING;
					int iError = CORCONST.OK;
					int bColorCambiado = 0;
					
					//Esconde el check box de solo lectura
					//ros  CORMDIBN!ID_COR_CMD.Flags = OFN_HIDEREADONLY Or OFN_OVERWRITEPROMPT Or OFN_SHOWHELP
					//ros  CORMDIBN!ID_COR_CMD.CancelError = True
					//ros  CORMDIBN!ID_COR_CMD.Filter = "Excel (*.xls)|*.xls"
					//ros  CORMDIBN!ID_COR_CMD.FilterIndex = 0
					//ros  CORMDIBN!ID_COR_CMD.DialogTitle = STR_MSG_EXP
					//ros  CORMDIBN!ID_COR_CMD.DefaultExt = "xls"
					//ros  CORMDIBN!ID_COR_CMD.Filename = NULL_STRING
					//ros
					//ros  Screen.MousePointer = DEFAULT
					//ros
					//ros  CORMDIBN!ID_COR_CMD.Action = DLG_FILE_SAVE
					
					//ros  If Err = CDERR_CANCEL Then
					//ros    Screen.MousePointer = DEFAULT
					//ros    Exit Sub
					//ros  End If
					
					//ros  Screen.MousePointer = HOURGLASS
					
					//ros  If Err <> OK Then
					//ros    Screen.MousePointer = DEFAULT
					//ros    Select Case Err
					//ros      Case INT_DISCO_LLENO
					//ros        MsgBox STR_DISCO_LLENO, MB_ICONSTOP + MB_OK, STR_APP_TIT
					//ros      Case INT_PERMISO_NEG
					//ros        MsgBox STR_PERMISO_NEG, MB_ICONSTOP + MB_OK, STR_APP_TIT
					//ros      Case INT_UNIDAD_NOLIS
					//ros        MsgBox STR_UNIDAD_NOLIS, MB_ICONSTOP + MB_OK, STR_APP_TIT
					//ros      Case INT_ERR_ACCPATHFILE
					//ros        MsgBox STR_ERR_ACCPATHFILE, MB_ICONSTOP + MB_OK, STR_APP_TIT
					//ros      Case INT_NO_PATH
					//ros        MsgBox STR_NO_PATH, MB_ICONSTOP + MB_OK, STR_APP_TIT
					//ros      Case INT_NO_MEMORIA
					//ros        MsgBox STR_NO_MEMORIA, MB_ICONSTOP + MB_OK, STR_APP_TIT
					//ros      Case Else
					//ros        MsgBox ERR_ERROR_DESC, MB_ICONSTOP + MB_OK, STR_APP_TIT
					//ros    End Select
					//ros    Exit Sub
					//ros  End If
					
					//ros  CORMDIBN!ID_COR_CMD.Action = NONE
					//ros  CORMDIBN!ID_COR_CMD.CancelError = False
					//ros  pszFullName = CORMDIBN!ID_COR_CMD.Filename
					//ros  pszVentana = CORMDIBN!ID_COR_CMD.FileTitle
					
					
					pszFullName = CORVAR.gblPathArchivo + ".xls";
					string pszVentana = pszFullName.Substring(pszFullName.Length - Math.Min(pszFullName.Length, 12));
					//DoEvents
					
					Cursor.Current = Cursors.WaitCursor;
					string pszFullPath = CORVB.NULL_STRING;
					
VuelveAIntentar: 
					//  pszFullPath = Obtiene_Path(pszFullPath)
					pszFullPath = CORVAR.pszgblPathEXCEL;
					//Se establece el status bar
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = CORVB.NONE;
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = false;
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK);
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORSTR.STR_CONECTANDO_EXCEL;
					//Un tiempo de Espera
					//UPGRADE_ISSUE: (2064) TextBox property .LinkTimeout was not upgraded.
					CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkTimeout = 150;
					//Trata de inicar la conección con Excel
					//UPGRADE_ISSUE: (2064) TextBox property .LinkMode was not upgraded.
					CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkMode = CORVB.LINK_NONE;
					//UPGRADE_ISSUE: (2064) TextBox property .LinkTopic was not upgraded.
					CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkTopic = "Excel|Libro1";
					//UPGRADE_ISSUE: (2064) TextBox property .LinkMode was not upgraded.
					CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkMode = CORVB.LINK_MANUAL;
					
					if (Information.Err().Number == CORCONST.INT_NO_APLICACION_DDE)
					{
						Information.Err().Number = CORCONST.OK;
						//UPGRADE_WARNING: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo
						iError = ((Process.Start(pszFullPath).Id > 31) ? -1: 0);
						Interaction.AppActivate("Microsoft Excel - Libro1");
						switch(Information.Err().Number)
						{
							case CORCONST.INT_NO_APLICACION : 
								CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; 
								Cursor.Current = Cursors.Default; 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								iResp = (int) Interaction.MsgBox(CORSTR.ERR_DDE_NO_APLICACION + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_CUESTIONA_OTRA_RUTA, (MsgBoxStyle) (CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT); 
								if (iResp == CORVB.IDYES)
								{
									pszFullPath = Interaction.InputBox(CORSTR.STR_AVISO_ORDEN, CORSTR.STR_APP_TIT, pszFullPath, 0, 0);
									if (pszFullPath == CORVB.NULL_STRING)
									{
										return;
									} else
									{
										Information.Err().Number = CORCONST.OK;
										goto VuelveAIntentar;
									}
								} 
								break;
							case CORCONST.INT_NO_PATH : 
								CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; 
								Cursor.Current = Cursors.Default; 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								iResp = (int) Interaction.MsgBox(CORSTR.ERR_DDE_PATH_NOT_FOUND + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_CUESTIONA_INTRO, (MsgBoxStyle) (CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT); 
								if (iResp == CORVB.IDYES)
								{
									pszFullPath = Interaction.InputBox(CORSTR.STR_AVISO_ORDEN, CORSTR.STR_APP_TIT, pszFullPath, 0, 0);
									if (pszFullPath == CORVB.NULL_STRING)
									{
										return;
									} else
									{
										//pszFullPath = Mid$(pszFullPath, Len(pszFullPath) - 6)
										Information.Err().Number = CORCONST.OK;
										goto VuelveAIntentar;
									}
								} 
								break;
							case CORCONST.INT_NO_MEMORIA : 
								CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; 
								Cursor.Current = Cursors.Default; 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								Interaction.MsgBox(CORSTR.ERR_DDE_NO_MEMORIA, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
								return;
							default:
								if (Information.Err().Number != CORCONST.OK)
								{
									CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
									Cursor.Current = Cursors.Default;
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
									Interaction.MsgBox(CORSTR.ERR_ERROR_DESC, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
									return;
								} 
								break;
						}
					}
					
					//Controlamos Cualquier Error que se genere al Exportar
					try
					{
                        //AIS-449
                        Microsoft.Office.Interop.Excel.Application excelApp;
                        Microsoft.Office.Interop.Excel.Workbook excelWorkbook;
                        Microsoft.Office.Interop.Excel.Worksheet excelWorksheet;
                        Microsoft.Office.Interop.Excel.Range excelCell;

                        //Instanciar el objeto y hacerlo visible
                        excelApp = new Excel.ApplicationClass();
                        excelApp.Visible = true;

                        //Crear nueva hoja de excel
                        excelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                        
                        


							//Inicializamos el error
							Information.Err().Number = CORCONST.OK;
							iError = CORCONST.OK;
							//Crea una nueva hoja y la graba
							//UPGRADE_ISSUE: (2064) TextBox property .LinkTopic was not upgraded.
							/*CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkTopic = "Excel|Libro1";
							//UPGRADE_ISSUE: (2064) TextBox property .LinkMode was not upgraded.
							CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkMode = CORVB.LINK_MANUAL;
							//UPGRADE_ISSUE: (2064) TextBox method .LinkExecute was not upgraded.
							CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkExecute("[New(1)]");
							//UPGRADE_ISSUE: (2064) TextBox method .LinkExecute was not upgraded.
							CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkExecute("[Save.As(" + "\"" + pszFullName + "\"" + ",1)]");
							
							//Se establece el status bar
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight;
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) CORVB.NULL_INTEGER;
							CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = CORSTR.STR_EXPORTANDO_EXCEL;
							CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;
							//Establece el tópico de comunicación
							iTempCol = cSpread.MaxCols;
							iTempRow = cSpread.MaxRows;
							CORMDIBN.DefInstance.ID_COR_DDE_EB.Text = CORVB.NULL_STRING;
							//UPGRADE_ISSUE: (2064) TextBox property .LinkTopic was not upgraded.
						//AIS-446 NGONZALEZ
                            excelWorkbook = excelApp.Workbooks.Open("Libro1", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        //CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkTopic = "Excel|" + pszFullName;
							
							dPauseTime = 5;
							dStart = DateTime.Now.TimeOfDay.TotalSeconds;
							
							while(DateTime.Now.TimeOfDay.TotalSeconds < dStart + dPauseTime)
							{
								Application.DoEvents();
							};
							
							//Iniciamos la comunicación con Excel
							//UPGRADE_ISSUE: (2064) TextBox property .LinkMode was not upgraded.
							CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkMode = CORVB.LINK_MANUAL;
							//UPGRADE_ISSUE: (2064) TextBox method .LinkExecute was not upgraded.
							CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkExecute("[Activate(" + "\"" + pszVentana + "\"" + ")]");
							//CORMDIBN!ID_COR_DDE_EB.LinkExecute "[Select.Special(12)]"
							//CORMDIBN!ID_COR_DDE_EB.LinkExecute "[Clear()]"
							iCountRow = CORVB.NULL_INTEGER;
							
							dPauseTime = 5;
							dStart = DateTime.Now.TimeOfDay.TotalSeconds;
							
							while(DateTime.Now.TimeOfDay.TotalSeconds < dStart + dPauseTime)
							{
								Application.DoEvents();
							};
							
							
							while((iCountRow <= iTempRow) && (iError == CORCONST.OK))
							{
								iExcelCol = 1;
								iCountCol = 1;
								
								while((iCountCol <= iTempCol) && (iError == CORCONST.OK))
								{
									if (cSpread.get_ColWidth(iCountCol) > CORVB.NULL_INTEGER)
									{
										cSpread.Col = iCountCol;
										cSpread.Row = iCountRow;
										CORMDIBN.DefInstance.ID_COR_DDE_EB.Text = cSpread.Text;
										pszCell = "L" + Conversion.Str(iCountRow + 1).TrimStart() + "C" + Conversion.Str(iExcelCol).TrimStart();
										//UPGRADE_ISSUE: (2064) TextBox property .LinkItem was not upgraded.
										CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkItem = pszCell;
										//CORMDIBN!ID_COR_DDE_EB.LinkMode = LINK_MANUAL
										//UPGRADE_ISSUE: (2064) TextBox method .LinkPoke was not upgraded.
										CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkPoke();
										//Se incrementa la columna de excel
										iExcelCol++;
									}
									//Se incrementa la Columna del Spread Sheet
									iCountCol++;
								};
								//Se incrementa el Renglon del spread Sheet
								iCountRow++;
								//Necesario para información del avance de la exportación
								iFlood = Convert.ToInt32(Math.Floor((iCountRow / ((double) iTempRow)) * 100));
								CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
								if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCambiado) != 0)
								{
									CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
									bColorCambiado = -1;
								}
								Application.DoEvents();
							};
							
							//Regresamos el status bar
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
							CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = false;
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = CORVB.NONE;
							
							if (iError != CORCONST.OK && iError != 30006)
							{
								Cursor.Current = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox(CORSTR.ERR_DDE_EXPORTA + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_AVISO_RECOM, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
							} else
							{
								//Guarda las modificaciones que se hicieron a la hoja
								//UPGRADE_ISSUE: (2064) TextBox method .LinkExecute was not upgraded.
								CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkExecute("[Save()]");
								Cursor.Current = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox(CORSTR.STR_EXP_EXITO, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
							}
							//Rompemos la comunicación con Excel
							//UPGRADE_ISSUE: (2064) TextBox property .LinkMode was not upgraded.
							CORMDIBN.DefInstance.ID_COR_DDE_EB.LinkMode = CORVB.LINK_NONE;
							return;
						}
					catch 
					{
						
						
						
						iError = Information.Err().Number;
						Activa_Aplicacion(ref iError, pszVentana);
						//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
						throw new Exception("Migration Exception: 'Resume Next' not supported");
					}
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			*/
		}
		
		
		
		
		static public void  Delay( int iSegundos)
		{
			
			object vInicio = null;
			
			//vInicio = TimeSerial(Hour(Now), Minute(Now), Second(Now))
			//Do
			//Loop Until TimeSerial(Hour(vInicio), Minute(vInicio), Second(vInicio) + iSegundos) = TimeSerial(Hour(Now), Minute(Now), Second(Now))
			
		}
		
		
		
		//****************************************************************************
		//**                                                                        **
		//** Descripción:                                                           **
		//**   Verifica que la aplicación que llame al Reporteador esté en ejecu-   **
		//**   cución, es decir que exista  un .EXE, esto se hace con la finalidad  **
		//**   de que no se pueda ejecutar desde el File Manager                    **
		//**                                                                        **
		//** Declaración:                                                           **
		//**   Sub DDE_Excel (Reporteador as form,cSpread As Control)               **
		//**                                                                        **
		//** Paso de Parámetros: La forma y El vaSpread                          **
		//**                                                                        **
		//** Variables globales que modifica: Ninguna                               **
		//**                                                                        **
		//****************************************************************************
		static public bool Esta_EnEjec()
		{
			
			int iTareaLargo = 0;
			int iTareaNomLargo = 0;
			int iTarea = 0;
			int bActivCum = 0;
			int iDiagonal = 0;
			string szExe = String.Empty;
			FixedLengthString szTempPath = new FixedLengthString(50);
			CORVAR.tagTASKSENTRY TE = new CORVAR.tagTASKSENTRY(); //Defnicion para verificar la execución de CORBNX32.EXE
			
			//UPGRADE_WARNING: (1041) Len has a new behavior.
			TE.dwSize = Marshal.SizeOf(TE);
			TE.szModule = new String(' ', 10);
			//  iTarea = TaskFirst(TE)
			
			
			while(iTarea != 0)
			{
				
				iTareaNomLargo = 260;
				szExe = new String(' ', iTareaNomLargo);
				//AIS-1182 NGONZALEZ
				iTareaLargo = API.KERNEL.GetModuleFileName(TE.hInst, szExe, iTareaNomLargo);
				if (iTareaLargo != 0)
				{
					szExe = szExe.Substring(0, Math.Min(szExe.Length, iTareaLargo));
					if (szExe.IndexOf('\\') >= 0)
					{
						do 
						{
							iDiagonal = (szExe.IndexOf('\\') + 1);
							szExe = Strings.Mid(szExe, iDiagonal + 1, szExe.Length);
						}
						while(iDiagonal != 0);
					}
					szExe = szExe.Trim();
					if (szExe == CORCONST.APLPATH)
					{
						return true;
					}
				}
				//    iTarea = TaskNext(TE)
			};
			
			return false;
			
		}
		
		
		
		static public void  Exporta_Excel()
		{
			
			switch(CORVAR.igblFormaActiva)
			{
				case CORCONST.INT_ACT_CEJ :  
					DDE_Excel(CORRPCEJ.DefInstance.ID_CEJ_REP_SS); 
					break;
				case CORCONST.INT_ACT_CGR :  
					DDE_Excel(CORRPCGR.DefInstance.ID_CGR_REP_SS); 
					break;
				case CORCONST.INT_ACT_ANG :  
					DDE_Excel(CORRPANG.DefInstance.ID_GIR_CON_SS); 
					break;
				case CORCONST.INT_ACT_DAT :  
					DDE_Excel(CORRPDAT.DefInstance.ID_CEJ_REP_SS); 
					break;
				case CORCONST.INT_ACT_DEJ :  
					DDE_Excel(CORRPDEJ.DefInstance.ID_CEJ_REP_SS); 
					break;
				case CORCONST.INT_ACT_EMA :  
					DDE_Excel(CORRPEM2.DefInstance.ID_EMA_REP_SS); 
					break;
				default:
					Cursor.Current = Cursors.Default; 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
					//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
					//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
					Interaction.MsgBox("No ha sido generado un reporte para exportar a Excel.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
					break;
			}
			
		}
		
		static public string Formatea_numerico(ref  string pszCadena)
		{
			
			StringBuilder pszTempCadena = new StringBuilder();
			pszTempCadena.Append(String.Empty);
			pszCadena = Strings.Mid(pszCadena, 2, pszCadena.Length);
			while (((pszCadena.IndexOf(',') + 1) != CORVB.NULL_INTEGER))
				{
				 //Or (InStr(pszCadena, ".") <> NULL_INTEGER)
					if ((pszCadena.IndexOf(',') + 1) != CORVB.NULL_INTEGER)
					{
						pszTempCadena.Append(Strings.Mid(pszCadena, 1, pszCadena.IndexOf(',')));
						pszCadena = Strings.Mid(pszCadena, (pszCadena.IndexOf(',') + 1) + 1, pszCadena.Length);
					}
				}
			pszTempCadena.Append(pszCadena.Trim());
			return pszTempCadena.ToString();
			
		}
		
		static public void  GetDataSources( Control listctrl)
		{
			int DataSourceLen = 0, DescriptionLen = 0;
			int RetCode = 0;
			int henv = 0;
			
			//  If SQLAllocEnv(henv) <> MOREROWS Then
			string DataSource = new string((char) 32, 32);
			string Description = new string((char) 32, 255);
			//get the first one
			//    RetCode = SQLDataSources(henv, 2, DataSource, Len(DataSource), DataSourceLen, Description, Len(Description), DescriptionLen)
			while (RetCode == 0 || RetCode == 1)
				{
				
					//UPGRADE_TODO: (1067) Member AddItem is not defined in type VB.Control.
					ReflectionHelper.Invoke(listctrl, "AddItem", new object[]{Strings.Mid(DataSource, 1, DataSourceLen)});
					DataSource = new string((char) 32, 32);
					Description = new string((char) 32, 255);
					//get all the others
					//      RetCode = SQLDataSources(henv, 1, DataSource, Len(DataSource), DataSourceLen, Description, Len(Description), DescriptionLen)
				}
			//  End If
			
		}
		
		static public void  Guarda_Encabezados()
		{
			
			FileSystem.PrintLine(1, new String(' ', Convert.ToInt32((pszHeaderSS.Length - pszTitRep.Length) / 2d)) + pszTitRep);
			FileSystem.PrintLine(1, CORVB.NULL_STRING);
			FileSystem.PrintLine(1, pszCadena1);
			FileSystem.PrintLine(1, pszCadena2);
			FileSystem.PrintLine(1, pszCadena3);
			FileSystem.PrintLine(1, pszCadena4);
			FileSystem.PrintLine(1, pszCadena5);
			FileSystem.PrintLine(1, pszCadena6);
			FileSystem.PrintLine(1, pszCadena7);
			FileSystem.PrintLine(1, pszCadena8);
			FileSystem.PrintLine(1, CORVB.NULL_STRING);
			
		}
		
		static public void  Guarda_Texto()
		{
			
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					if (CORVAR.igblFormaActiva == CORCONST.INT_ACT_CEJ || CORVAR.igblFormaActiva == CORCONST.INT_ACT_CGR || CORVAR.igblFormaActiva == CORCONST.INT_ACT_ANG || CORVAR.igblFormaActiva == CORCONST.INT_ACT_DAT || CORVAR.igblFormaActiva == CORCONST.INT_ACT_DEJ || CORVAR.igblFormaActiva == CORCONST.INT_ACT_EMA)
					{
					} else
					{
						Cursor.Current = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No existe un reporte para exportar a Texto.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
						return;
					}
					
					//ros  CORMDIBN!ID_COR_CMD.Flags = OFN_HIDEREADONLY Or OFN_OVERWRITEPROMPT Or OFN_SHOWHELP
					//ros  CORMDIBN!ID_COR_CMD.CancelError = True
					//ros  CORMDIBN!ID_COR_CMD.Filter = "Texto (*.txt)|*.txt"
					//ros  CORMDIBN!ID_COR_CMD.FilterIndex = 0
					//ros  CORMDIBN!ID_COR_CMD.DialogTitle = STR_MSG_EXP
					//ros  CORMDIBN!ID_COR_CMD.DefaultExt = "txt"
					//ros  CORMDIBN!ID_COR_CMD.Filename = NULL_STRING
					//ros  CORMDIBN!ID_COR_CMD.InitDir = pszgblPath
					
					//ros  Screen.MousePointer = DEFAULT
					
					//ros  CORMDIBN!ID_COR_CMD.Action = DLG_FILE_SAVE
					
					//ros  If Err = CDERR_CANCEL Then
					//ros    Screen.MousePointer = DEFAULT
					//ros    Exit Sub
					//ros  End If
					
					Cursor.Current = Cursors.WaitCursor;
					
					//ros  CORMDIBN!ID_COR_CMD.Action = NONE
					//ros  CORMDIBN!ID_COR_CMD.CancelError = False
					
					//ros  pszNombreCompleto = CORMDIBN!ID_COR_CMD.Filename
					
					string pszNombreCompleto = CORVAR.gblPathArchivo + ".TXT";
					
					Information.Err().Number = CORCONST.OK;
                    try
                    {
                        FileSystem.FileOpen(1, pszNombreCompleto, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                    }
                    catch {

                            Cursor.Current = Cursors.Default;
                            switch (Information.Err().Number)
                            {
                                case CORCTERR.INT_DISCO_LLENO:
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                    Interaction.MsgBox(CORSTR.STR_DISCO_LLENO, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    break;
                                case CORCTERR.INT_PERMISO_NEG:
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                    Interaction.MsgBox(CORSTR.STR_PERMISO_NEG, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    break;
                                case CORCTERR.INT_UNIDAD_NOLIS:
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                    Interaction.MsgBox(CORSTR.STR_UNIDAD_NOLIS, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    break;
                                case CORCTERR.INT_ERR_ACCPATHFILE:
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                    Interaction.MsgBox(CORSTR.STR_ERR_ACCPATHFILE, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    break;
                                case CORCONST.INT_NO_PATH:
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                    Interaction.MsgBox(CORSTR.STR_NO_PATH, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    break;
                                case CORCONST.INT_NO_MEMORIA:
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                    Interaction.MsgBox(CORSTR.STR_NO_MEMORIA, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    break;
                                default:
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                    Interaction.MsgBox(CORSTR.ERR_ERROR_DESC, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    break;
                            }
                            return;
                    }
					//Se establece el status bar
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) CORVB.NULL_INTEGER;
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight;
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;
					
					CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = CORSTR.STR_EXPORTANDO_TXT;
					CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;
					
					Cursor.Current = Cursors.WaitCursor;
					
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight; //Se establece el status bar
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) CORVB.NULL_INTEGER;
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK);
					CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = CORSTR.STR_EXPORTANDO_TXT;
					CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;
					
					switch(CORVAR.igblFormaActiva)
					{
						case CORCONST.INT_ACT_CEJ : 
							Obten_Encabezados(CORRPCEJ.DefInstance); 
							Guarda_Encabezados(); 
							Guarda_TXT(CORRPCEJ.DefInstance.ID_CEJ_REP_SS); 
							break;
						case CORCONST.INT_ACT_CGR : 
							Obten_Encabezados(CORRPCGR.DefInstance); 
							Guarda_Encabezados(); 
							Guarda_TXT(CORRPCGR.DefInstance.ID_CGR_REP_SS); 
							break;
						case CORCONST.INT_ACT_ANG : 
							Obten_Encabezados(CORRPANG.DefInstance); 
							Guarda_Encabezados(); 
							Guarda_TXT(CORRPANG.DefInstance.ID_GIR_CON_SS); 
							break;
						case CORCONST.INT_ACT_DAT : 
							Obten_Encabezados(CORRPDAT.DefInstance); 
							Guarda_Encabezados(); 
							Guarda_TXT(CORRPDAT.DefInstance.ID_CEJ_REP_SS); 
							break;
						case CORCONST.INT_ACT_DEJ : 
							Obten_Encabezados(CORRPDEJ.DefInstance); 
							Guarda_Encabezados(); 
							Guarda_TXT(CORRPDEJ.DefInstance.ID_CEJ_REP_SS); 
							break;
						case CORCONST.INT_ACT_EMA : 
							Obten_Encabezados(CORRPEM2.DefInstance); 
							Guarda_Encabezados(); 
							Guarda_TXT(CORRPEM2.DefInstance.ID_EMA_REP_SS); 
							break;
					}
					
					//Cerramos el Archivo
					FileSystem.FileClose(1);
					
					//Regresamos el status bar
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
					CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = false;
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = CORVB.NONE;
					
					Cursor.Current = Cursors.Default;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
		}
		
		static public void  Guarda_TXT( AxFPSpread.AxvaSpread cSpread)
		{
			
			int iCol = 0;
			int iError = 0;
			double dTemp = 0;
			int iEspacio = 0;
			int iResta = 0;
			
			try
			{
					
					iMaxRenglones = cSpread.MaxRows;
					iMaxcolumnas = cSpread.MaxCols;
					
					iFlood = CORVB.NULL_INTEGER;
					bColorCamb = 0;
					ppszCadenaImp = CORVB.NULL_STRING;
					
					switch(CORVAR.igblFormaActiva)
					{
						case CORCONST.INT_ACT_CEJ : 
							ppszCadenaImp = " Cuenta           Ejecutivo            Nómina    C. de Costos    Atrasos     Saldo Anterior    Consumos    Disp. Efvo.     Pagos     Comisiones   Gtos. Cobr.    I.V.A.       Saldo Nuevo    "; 
							break;
						case CORCONST.INT_ACT_CGR : 
							ppszCadenaImp = "    No.                   Empresa                 # Tarjs.  # Atras. Saldo Anterior    Consumos      Disp. Efvo.       Pagos       Comisiones     Gtos. Cobr.      I.V.A.       Saldo Nuevo  "; 
							break;
						case CORCONST.INT_ACT_ANG : 
							ppszCadenaImp = "                     Segmentos                             Monto        "; 
							break;
						case CORCONST.INT_ACT_DAT : 
							ppszCadenaImp = "  Número                 Empresa                  Tarjetas     Transac.   Monto de Compras  Monto de Disp.   Saldos Vencidos "; 
							break;
						case CORCONST.INT_ACT_DEJ : 
							ppszCadenaImp = " Cuenta         Ejecutivo         # Nómina    C.de Costos   Vencidos     Saldo Anterior    Consumos    Disp. Efvo.     Pagos     Comisiones   Gtos. Cobr.    I.V.A.       Saldo Nuevo    "; 
							break;
						case CORCONST.INT_ACT_EMA : 
							ppszCadenaImp = "  Número                 Empresa                  Tarjetas     Transacc.  Ctas Activas   Facturación     Prom. Pagar     Prom. Tarjs.    Saldos Venc.  "; 
							break;
					}
					
					FileSystem.PrintLine(1, ppszCadenaImp);
					FileSystem.PrintLine(1, CORVB.NULL_STRING);
					
					for (int iContRen = 1; iContRen <= iMaxRenglones; iContRen++)
					{
						
						//iFlood = iContRen * 100 / iMaxRenglones
						iFlood = (Convert.ToInt32((iContRen / ((double) iMaxRenglones)) * 100));
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
						if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCamb) != 0)
						{
							CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
							bColorCamb = -1;
						}
						
						cSpread.Row = iContRen;
						ppszCadenaImp = CORVB.NULL_STRING;
						
						for (int iCont = 1; iCont <= iMaxcolumnas; iCont++)
						{
							iError = 0;
							cSpread.Col = iCont;
							
							if (cSpread.Text.IndexOf('.') >= 0)
							{
								if (((cSpread.Text.IndexOf('.') + 1) & ((((int) Strings.Mid(cSpread.Text, cSpread.Text.IndexOf('.'), 1)[0]) > 47 && ((int) Strings.Mid(cSpread.Text, cSpread.Text.IndexOf('.'), 1)[0]) < 58) ? -1: 0)) != 0)
								{
									dTemp = Double.Parse(cSpread.Text);
									if (iError == (0))
									{
										ppszCadenaImp = ppszCadenaImp + new String(' ', Convert.ToInt32((cSpread.get_ColWidth(iCont) + 3) - cSpread.Text.Trim().Length)) + cSpread.Text.Trim();
									} else
									{
										ppszCadenaImp = ppszCadenaImp + cSpread.Text.Trim() + new String(' ', Convert.ToInt32((cSpread.get_ColWidth(iCont) + 3) - cSpread.Text.Trim().Length));
									}
								}
							} else
							{
								if (cSpread.Text.Trim().Length < 28)
								{
									ppszCadenaImp = ppszCadenaImp + cSpread.Text.Trim() + new String(' ', Convert.ToInt32((cSpread.get_ColWidth(iCont) + 3) - cSpread.Text.Trim().Length));
								} else
								{
									iResta = cSpread.Text.Trim().Length - (cSpread.Text.Trim().Length - 27);
									ppszCadenaImp = ppszCadenaImp + Strings.Mid(cSpread.Text.Trim(), 1, 27) + new String(' ', Convert.ToInt32(cSpread.get_ColWidth(iCont) + 3) - iResta);
								}
							}
						}
						
						FileSystem.PrintLine(1, ppszCadenaImp);
                        if (ppszCadenaImp == "0142     JUAN GERARDO ARANCIVIA GOME 14600205              50,000.006            0                        -15.96    11,179.96     7,015.00         0.00         0.00         0.00         0.00         18,179.00")
                        {
                            ppszCadenaImp = ppszCadenaImp + "";
                        }
					}
					
					if (iError == (0))
					{
						Cursor.Current = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox(CORSTR.STR_EXP_EXITO, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
					}
				}
			catch 
			{
				
				
				iError = -1;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
				throw new Exception("Migration Exception: 'Resume Next' not supported");
			}
			
			
		}
		
		static public void  Imprime_ANG( AxFPSpread.AxvaSpread cSpread)
		{
			
			iMaxRenglones = cSpread.MaxRows;
			iMaxcolumnas = cSpread.MaxCols;
			
			iFlood = CORVB.NULL_INTEGER;
			bColorCamb = 0;
			PrinterHelper.Printer.FontBold = false;
			
			for (int iContRen = 1; iContRen <= iMaxRenglones; iContRen++)
			{
				
				//iFlood = iContRen * 100 / iMaxRenglones
				iFlood = Convert.ToInt32(Math.Floor((iContRen / ((double) iMaxRenglones)) * 100));
				CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
				if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCamb) != 0)
				{
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
					bColorCamb = -1;
				}
				cSpread.Row = iContRen;
				
				cSpread.Col = 1; //Segmentos
				ppszCadenaImp = new String(' ', 5) + Strings.Mid(cSpread.Text.Trim(), 1, 30) + new String(' ', 35 - Strings.Mid(cSpread.Text.Trim(), 1, 30).Length);
				cSpread.Col = 2; //Monto
				ppszCadenaImp = ppszCadenaImp + new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim();
				
				PrinterHelper.Printer.Print(ppszCadenaImp);
				
				iContLineas++;
				if (iContLineas > INT_MAX_LINEAS_H)
				{ //Se completó la página
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
					PrinterHelper.Printer.NewPage();
					Lineas_EnBlanco(INT_ESPACIOS_CABECERA);
					Imprime_Encabezados();
					iContLineas = CORVB.NULL_INTEGER;
				}
				PrinterHelper.Printer.FontBold = false;
				
			}
			
			Lineas_EnBlanco(INT_MAX_LINEAS_H - iContLineas);
			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
			
		}
		
		static public void  Imprime_CEJ( AxFPSpread.AxvaSpread cSpread)
		{
			int ilComienzo = 0;
			iMaxRenglones = cSpread.MaxRows;
			iMaxcolumnas = cSpread.MaxCols;
			
			iFlood = CORVB.NULL_INTEGER;
			bColorCamb = 0;
			PrinterHelper.Printer.FontBold = false;
			
			for (int iContRen = 1; iContRen <= iMaxRenglones; iContRen++)
			{
				//iFlood = iContRen * 100 / iMaxRenglones
				iFlood = Convert.ToInt32(Math.Floor((iContRen / ((double) iMaxRenglones)) * 100));
				CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
				if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCamb) != 0)
				{
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
					bColorCamb = -1;
				}
				
				cSpread.Row = iContRen;
				
				//***************************************************************************************************
				// 15/Nov/1995 Se sustiuyo el siguiente código por la continuación del mismo
				// debido al cambio que sufrió para meter el saldo deudor y acreedor en el reporte.
				// Manuel Alderete Lezama
				//***************************************************************************************************
				//If iContRen < iMaxRenglones Then
				//  'Cuenta
				//  ppszCadenaImp = Space(4) + Trim$(cSpread.Text) + Space(2)
				//  cSpread.Col = 2 'Ejecutivo
				//  ppszCadenaImp = ppszCadenaImp + Left$(Trim$(cSpread.Text), 25) + Space(27 - Len(Left$(Trim$(cSpread.Text), 25)))
				//  cSpread.Col = 3 'Nomina
				//  ppszCadenaImp = ppszCadenaImp + Trim$(cSpread.Text) + Space(7)
				//  cSpread.Col = 4 'C Costos
				//  ppszCadenaImp = ppszCadenaImp + Left$(Trim$(cSpread.Text), 5) + Space(7 - Len(Left$(Trim$(cSpread.Text), 5)))
				//  cSpread.Col = 5 'Atrasos
				//  ppszCadenaImp = ppszCadenaImp + Space(3 - Len(Trim$(cSpread.Text))) + Trim$(cSpread.Text) + Space(2)
				//Else
				//  ppszCadenaImp = Space$(4) + Trim$(cSpread.Text) + Space(54)
				//End If
				//***************************************************************************************************
				
				ppszCadenaImp = new String(' ', 180);
				cSpread.Col = 1; //Cuenta
				ilComienzo = 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				
				cSpread.Col = 2; //Ejecutivo
				ilComienzo = ilComienzo + Formato.igLongitudEjecutivo + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				
				cSpread.Col = 3; //Nomina
				ilComienzo = ilComienzo + 20 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 26, cSpread.Text.Trim());
				
				cSpread.Col = 4; //Límite de Crédito
				ilComienzo = ilComienzo + 8 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 35, new String(' ', 13 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 5; //Centro de Costos
				ilComienzo = ilComienzo + 13 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 49, cSpread.Text.Trim());
				
				cSpread.Col = 6; //Atrasos
				ilComienzo = ilComienzo + 10 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 60, new String(' ', 3 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 7; //Saldo Anterior
				ilComienzo = ilComienzo + 3 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 64, new String(' ', 13 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 8; //Consumos
				ilComienzo = ilComienzo + 13 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 78, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 9; //Disposiciones en Efectivo
				ilComienzo = ilComienzo + 14 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 93, new String(' ', 13 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 10; //Pagos
				ilComienzo = ilComienzo + 13 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 107, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 11; //Comisiones
				ilComienzo = ilComienzo + 14 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 122, new String(' ', 13 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 12; //Gastos por Cobrar
				ilComienzo = ilComienzo + 13 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 136, new String(' ', 13 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 13; //iva
				ilComienzo = ilComienzo + 13 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 150, new String(' ', 10 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 14; //Saldo Nuevo
				ilComienzo = ilComienzo + 10 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 161, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				//'    Printer.FontName = "Courier New"
				//    Printer.FontBold = False
				//    Printer.FontSize = 10
				
				PrinterHelper.Printer.Print(ppszCadenaImp);
				
				iContLineas++;
				if (iContLineas > INT_MAX_LINEAS_H)
				{ //Se completó la página
					PrinterHelper.Printer.FontBold = true;
					PrinterHelper.Printer.Print();
					if (Strings.Mid(CORRPCEJ.DefInstance.ID_CEJ_CRE_EB.Tag.ToString(), 1, 1) == "A")
					{
						PrinterHelper.Printer.Print(CORRPCEJ.DefInstance.ID_CEJ_MSG_TXT.Text);
					}
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
					PrinterHelper.Printer.NewPage();
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//      Lineas_EnBlanco INT_ESPACIOS_CABECERA + 2
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					Lineas_EnBlanco(INT_ESPACIOS_CABECERA);
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					Imprime_Encabezados();
					iContLineas = CORVB.NULL_INTEGER;
				}
				PrinterHelper.Printer.FontBold = false;
			}
			
			Lineas_EnBlanco(INT_MAX_LINEAS_H - iContLineas);
			
			PrinterHelper.Printer.FontBold = true;
			PrinterHelper.Printer.Print();
			if (Strings.Mid(CORRPCEJ.DefInstance.ID_CEJ_CRE_EB.Tag.ToString(), 1, 1) == "A")
			{
				PrinterHelper.Printer.Print(CORRPCEJ.DefInstance.ID_CEJ_MSG_TXT.Text);
			}
			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
			
		}
		
		static public void  Imprime_CGR( AxFPSpread.AxvaSpread cSpread)
		{
			int ilComienzo = 0;
			iMaxRenglones = cSpread.MaxRows;
			iMaxcolumnas = cSpread.MaxCols;
			
			iFlood = CORVB.NULL_INTEGER;
			bColorCamb = 0;
			PrinterHelper.Printer.FontBold = false;
			
			
			for (int iContRen = 1; iContRen <= iMaxRenglones; iContRen++)
			{
				
				//iFlood = iContRen * 100 / iMaxRenglones
				iFlood = Convert.ToInt32(Math.Floor((iContRen / ((double) iMaxRenglones)) * 100));
				CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
				if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCamb) != 0)
				{
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
					bColorCamb = -1;
				}
				cSpread.Row = iContRen;
				ppszCadenaImp = new String(' ', 180);
				cSpread.Col = 1; //No. Empresa
				ilComienzo = 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				//    If iContRen < iMaxRenglones Then
				cSpread.Col = 2; //Nombre
				//      ppszCadenaImp = ppszCadenaImp + Trim$(Mid$(cSpread.Text, 1, 32)) + Space(34 - Len(Trim$(Mid$(cSpread.Text, 1, 32))))
				//      ppszCadenaImp = ppszCadenaImp + Trim$(Mid$(cSpread.Text, 1, 25)) + Space(28 - Len(Trim$(Mid$(cSpread.Text, 1, 25))))
				//      Mid$(ppszCadenaImp, 9, 25) = Trim$(cSpread.Text)
				//    Else
				ilComienzo = ilComienzo + Formato.igLongitudEmpresa + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				//    End If
				
				cSpread.Col = 3; //# de Tarjetas
				ilComienzo = ilComienzo + 25 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 4 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 4; //Credito
				ilComienzo = ilComienzo + 4 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 5; //# de Tarjetas Atrasadas
				ilComienzo = ilComienzo + 14 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 3 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 6; //Saldo Anterior
				ilComienzo = ilComienzo + 3 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 7; //Consumos
				ilComienzo = ilComienzo + 14 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 8; //Disposiciones en Efectivo
				ilComienzo = ilComienzo + 14 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 9; //Pagos
				ilComienzo = ilComienzo + 14 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 10; //Comisiones
				ilComienzo = ilComienzo + 14 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 11; //Intereses moratorios
				ilComienzo = ilComienzo + 14 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				//    cSpread.Col = 12  'IVA
				//
				ppszCadenaImp = ppszCadenaImp + new String(' ', 12 - cSpread.Text.Trim().Length) + cSpread.Text.Trim() + new String(' ', 1);
				cSpread.Col = 12; //Saldo Nuevo
				ilComienzo += 16;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				PrinterHelper.Printer.Print(ppszCadenaImp);
				iContLineas++;
				if (iContLineas > INT_MAX_LINEAS_H)
				{ //Se completó la página
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
					PrinterHelper.Printer.NewPage();
					Lineas_EnBlanco(INT_ESPACIOS_CABECERA - 2);
					PrinterHelper.Printer.Print(CORVB.NULL_STRING);
					PrinterHelper.Printer.Print(CORVB.NULL_STRING);
					Obten_Encabezados(CORRPCGR.DefInstance);
					Imprime_Encabezados();
					iContLineas = CORVB.NULL_INTEGER;
				}
				PrinterHelper.Printer.FontBold = false;
				
			}
			
			Lineas_EnBlanco(INT_MAX_LINEAS_H - iContLineas);
			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
			
		}
		
		static public void  Imprime_DAT( AxFPSpread.AxvaSpread cSpread)
		{
			int ilComienzo = 0;
			int iCont = 0;
			int iEnter = 0;
			string pszLeyenda = String.Empty;
			
			iMaxRenglones = cSpread.MaxRows;
			iMaxcolumnas = cSpread.MaxCols;
			
			iFlood = CORVB.NULL_INTEGER;
			bColorCamb = 0;
			PrinterHelper.Printer.FontBold = false;
			
			for (int iContRen = 1; iContRen <= iMaxRenglones; iContRen++)
			{
				//iFlood = iContRen * 100 / iMaxRenglones
				iFlood = Convert.ToInt32(Math.Floor((iContRen / ((double) iMaxRenglones)) * 100));
				CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
				if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCamb) != 0)
				{
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
					bColorCamb = -1;
				}
				
				cSpread.Row = iContRen;
				cSpread.Col = 1;
				
				if (iContRen < iMaxRenglones)
				{
					//Cuenta
					ppszCadenaImp = new String(' ', 4) + cSpread.Text.Trim() + new String(' ', 4);
					if (ppszCadenaImp.Length > 11)
					{
						ppszCadenaImp = Strings.Mid(ppszCadenaImp, (ppszCadenaImp.Length - 11) / 2, 11);
					}
					
					cSpread.Col = 2; //Ejecutivo
					ppszCadenaImp = ppszCadenaImp + Strings.Mid(cSpread.Text.Trim(), 1, 25) + new String(' ', 27 - Strings.Mid(cSpread.Text.Trim(), 1, 25).Length);
					
					cSpread.Col = 3; //Nomina
					ppszCadenaImp = ppszCadenaImp + cSpread.Text.Trim() + new String(' ', 4);
					
					cSpread.Col = 4; //C Costos
					ppszCadenaImp = ppszCadenaImp + Strings.Mid(cSpread.Text.Trim(), 1, 9) + new String(' ', 10 - Strings.Mid(cSpread.Text.Trim(), 1, 9).Length);
					
					cSpread.Col = 5; //Atrasos
					ppszCadenaImp = ppszCadenaImp + new String(' ', 3 - cSpread.Text.Trim().Length) + cSpread.Text.Trim() + new String(' ', 2);
				} else
				{
					ppszCadenaImp = new String(' ', 4) + cSpread.Text.Trim() + new String(' ', 55);
				}
				
				cSpread.Col = 6; //Saldo Anterior
				ppszCadenaImp = ppszCadenaImp + new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim() + new String(' ', 2);
				
				cSpread.Col = 7; //Consumos
				ppszCadenaImp = ppszCadenaImp + new String(' ', 11 - cSpread.Text.Trim().Length) + cSpread.Text.Trim() + new String(' ', 2);
				
				cSpread.Col = 8; //Disposiciones en Efectivo
				ppszCadenaImp = ppszCadenaImp + new String(' ', 11 - cSpread.Text.Trim().Length) + cSpread.Text.Trim() + new String(' ', 2);
				
				cSpread.Col = 9; //Pagos
				ppszCadenaImp = ppszCadenaImp + new String(' ', 11 - cSpread.Text.Trim().Length) + cSpread.Text.Trim() + new String(' ', 2);
				
				cSpread.Col = 10; //Comisiones
				ppszCadenaImp = ppszCadenaImp + new String(' ', 10 - cSpread.Text.Trim().Length) + cSpread.Text.Trim() + new String(' ', 2);
				
				cSpread.Col = 11; //IVA
				ppszCadenaImp = ppszCadenaImp + new String(' ', Convert.ToInt32(Math.Max(0, 9 - cSpread.Text.Trim().Length))) + cSpread.Text.Trim() + new String(' ', 2);
				
				cSpread.Col = 12; //Intereses moratorios
				ppszCadenaImp = ppszCadenaImp + new String(' ', 9 - cSpread.Text.Trim().Length) + cSpread.Text.Trim() + new String(' ', 1);
				
				cSpread.Col = 13; //Saldo Nuevo
				ppszCadenaImp = ppszCadenaImp + new String(' ', 14 - cSpread.Text.Trim().Length) + cSpread.Text.Trim();
				
				PrinterHelper.Printer.Print(ppszCadenaImp);
				
				iContLineas++;
				if (iContLineas == INT_MAX_LINEAS_H)
				{ //Se completó la página
					PrinterHelper.Printer.FontBold = true;
					PrinterHelper.Printer.Print();
					//Busca cuantos renglones debe imprimir  en la leyenda
					CORVAR.pszgblLeyenda = CORVAR.pszgblLeyenda.TrimEnd();
					if (CORVAR.pszgblLeyenda.TrimEnd().Length != 0)
					{
						iEnter = 1;
						for (iCont = 1; iCont <= CORVAR.pszgblLeyenda.Length; iCont++)
						{
							if (Strings.Mid(CORVAR.pszgblLeyenda, iCont, 1) == "\r")
							{
								PrinterHelper.Printer.Print(new String(' ', 10) + Strings.Mid(CORVAR.pszgblLeyenda, iEnter, iCont - 1));
								iEnter = iCont + 2;
								iCont += 2;
							}
						}
						PrinterHelper.Printer.Print(new String(' ', 10) + Strings.Mid(CORVAR.pszgblLeyenda, iEnter, iCont));
					}
					PrinterHelper.Printer.Print(new String(' ', 140) + "CUENTA DE CHEQUES:  " + CORRPDAT.DefInstance.ID_DAT_CUE_TXT[0].Tag.ToString());
					PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
					PrinterHelper.Printer.NewPage();
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//     Lineas_EnBlanco INT_ESPACIOS_CABECERA + 2
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					Lineas_EnBlanco(INT_ESPACIOS_CABECERA);
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					Imprime_Encabezados();
					iContLineas = CORVB.NULL_INTEGER;
				}
				PrinterHelper.Printer.FontBold = false;
			}
			
			Lineas_EnBlanco(INT_MAX_LINEAS_H - iContLineas);
			
			PrinterHelper.Printer.FontBold = true;
			PrinterHelper.Printer.Print();
			
			//Busca cuantos renglones debe imprimir  en la leyenda
			CORVAR.pszgblLeyenda = CORVAR.pszgblLeyenda.TrimEnd();
			if (CORVAR.pszgblLeyenda.TrimEnd().Length != 0)
			{
				iEnter = 1;
				for (iCont = 1; iCont <= CORVAR.pszgblLeyenda.Length; iCont++)
				{
					if (Strings.Mid(CORVAR.pszgblLeyenda, iCont, 1) == "\r")
					{
						PrinterHelper.Printer.Print(new String(' ', 10) + Strings.Mid(CORVAR.pszgblLeyenda, iEnter, iCont - 1));
						iEnter = iCont + 2;
						iCont += 2;
					}
				}
				PrinterHelper.Printer.Print(new String(' ', 10) + Strings.Mid(CORVAR.pszgblLeyenda, iEnter, iCont));
			}
			
			PrinterHelper.Printer.Print(new String(' ', 140) + "CUENTA DE CHEQUES:  " + CORRPDAT.DefInstance.ID_DAT_CUE_TXT[0].Tag.ToString());
			PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
			
		}
		
		static public void  Imprime_DEJ( AxFPSpread.AxvaSpread cSpread)
		{
			int ilComienzo = 0;
			
			iMaxRenglones = cSpread.MaxRows;
			iMaxcolumnas = cSpread.MaxCols;
			
			iFlood = CORVB.NULL_INTEGER;
			bColorCamb = 0;
			PrinterHelper.Printer.FontBold = false;
			
			for (int iContRen = 1; iContRen <= iMaxRenglones; iContRen++)
			{
				
				//iFlood = iContRen * 100 / iMaxRenglones
				iFlood = Convert.ToInt32(Math.Floor((iContRen / ((double) iMaxRenglones)) * 100));
				CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
				if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCamb) != 0)
				{
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
					bColorCamb = -1;
				}
				cSpread.Row = iContRen;
				//    ppszCadenaImp = NULL_STRING
				
				
				ppszCadenaImp = new String(' ', 180);
				cSpread.Col = 1; //numero
				ilComienzo = 3;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				
				cSpread.Col = 2; //empresa
				ilComienzo = ilComienzo + Formato.igLongitudEmpresa + 2;
				if (iContRen < iMaxRenglones)
				{
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				} else
				{
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				}
				
				cSpread.Col = 3; //credito total
				ilComienzo = ilComienzo + 25 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 18 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 4; //credito acumulado
				ilComienzo = ilComienzo + 18 + 3;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 18 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 5; //fecha de vencimiento de credito
				ilComienzo = ilComienzo + 18 + 3;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 79, cSpread.Text.Trim());
				
				cSpread.Col = 6; //# tarjetas
				ilComienzo = ilComienzo + 12 + 3;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 7 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 7; //# transacciones
				ilComienzo = ilComienzo + 7 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 7 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 8; //Compra
				ilComienzo = ilComienzo + 7 + 3;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 18 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 9; //disposiciones de efectivo
				ilComienzo = ilComienzo + 18 + 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 18 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 10; //saldos vencidos
				ilComienzo = ilComienzo + 18 + 4;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 154, new String(' ', 18 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				
				PrinterHelper.Printer.Print(ppszCadenaImp);
				
				iContLineas++;
				if (iContLineas > INT_MAX_LINEAS_H)
				{ //Se completó la página
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
					PrinterHelper.Printer.NewPage();
					Lineas_EnBlanco(INT_ESPACIOS_CABECERA);
					Imprime_Encabezados();
					iContLineas = CORVB.NULL_INTEGER;
				}
				PrinterHelper.Printer.FontBold = false;
				
			}
			
			Lineas_EnBlanco(INT_MAX_LINEAS_H - iContLineas);
			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
			
		}
		
		static public void  Imprime_EMA( AxFPSpread.AxvaSpread cSpread)
		{
			int ilComienzo = 0;
			iMaxRenglones = cSpread.MaxRows;
			iMaxcolumnas = cSpread.MaxCols;
			
			iFlood = CORVB.NULL_INTEGER;
			bColorCamb = 0;
			PrinterHelper.Printer.FontBold = false;
			
			for (int iContRen = 1; iContRen <= iMaxRenglones; iContRen++)
			{
				
				//iFlood = iContRen * 100 / iMaxRenglones
				iFlood = Convert.ToInt32(Math.Floor((iContRen / ((double) iMaxRenglones)) * 100));
				CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
				if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCamb) != 0)
				{
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
					bColorCamb = -1;
				}
				cSpread.Row = iContRen;
				ppszCadenaImp = CORVB.NULL_STRING;
				
				ppszCadenaImp = new String(' ', 180);
				cSpread.Col = 1; //Empresa
				ilComienzo = 2;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				
				cSpread.Col = 2; //Nombre
				ilComienzo = ilComienzo + Formato.igLongitudEmpresa + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, cSpread.Text.Trim());
				
				cSpread.Col = 3; //# Tarjetas
				ilComienzo = ilComienzo + 25 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 5 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 4; //Cuentas Activas
				ilComienzo = ilComienzo + 5 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 5 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 5; //Facturacion
				ilComienzo = ilComienzo + 5 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 17 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 6; //Prom Tarjs
				ilComienzo = ilComienzo + 17 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 17 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 7; //# Tarjetas con 1 mes vencidas
				ilComienzo = ilComienzo + 17 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 4 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 8; //Saldos con 1 mes de vencimiento
				ilComienzo = ilComienzo + 4 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 18 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 9; //# Tarjetas con 2 meses vencidas
				ilComienzo = ilComienzo + 18 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 4 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 10; //Saldos con 2 meses de vencimiento
				ilComienzo = ilComienzo + 4 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 18 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 11; //# Tarjetas con 3 meses vencidas
				ilComienzo = ilComienzo + 18 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 4 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 12; //Saldos con 3 meses de vencimiento
				ilComienzo = ilComienzo + 4 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 18 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				cSpread.Col = 13; //Saldo vencidos
				ilComienzo = ilComienzo + 18 + 1;
				ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, ilComienzo, new String(' ', 19 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				
				PrinterHelper.Printer.Print(ppszCadenaImp);
				
				iContLineas++;
				if (iContLineas > INT_MAX_LINEAS_H)
				{ //Se completó la página
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
					PrinterHelper.Printer.NewPage();
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//      Lineas_EnBlanco INT_ESPACIOS_CABECERA + 2
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					Lineas_EnBlanco(INT_ESPACIOS_CABECERA);
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					Imprime_Encabezados();
					iContLineas = CORVB.NULL_INTEGER;
				}
				PrinterHelper.Printer.FontBold = false;
			}
			
			Lineas_EnBlanco(INT_MAX_LINEAS_H - iContLineas);
			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
			
		}
		
		
		static public void  Imprime_Encabezados()
		{
			object BF = null;
			
			iContLineas = CORVB.NULL_INTEGER;
			
			//Printer.FontName = Printer.Fonts(1)
			PrinterHelper.Printer.FontName = "Courier New";
			PrinterHelper.Printer.FontSize = 10;
			PrinterHelper.Printer.FontBold = true;
			
			PrinterHelper.Printer.Print(new String(' ', Convert.ToInt32((120 - pszTitRep.Length) / 2d)) + pszTitRep.ToUpper());
			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.Print(pszCadena1);
			PrinterHelper.Printer.Print(pszCadena2);
			PrinterHelper.Printer.Print(pszCadena3);
			PrinterHelper.Printer.Print(pszCadena4);
			PrinterHelper.Printer.Print(pszCadena5);
			PrinterHelper.Printer.Print(pszCadena6);
			PrinterHelper.Printer.Print(pszCadena7);
			PrinterHelper.Printer.Print(pszCadena8);

            PrinterHelper.Printer.FontName = "LinePrinter";
			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.Print(pszHeaderSS);
			//AIS-1149 NGONZALEZ
            PrinterHelper.Printer.Line(new PointF(100, 1800), new PointF(15000, 1900), Color.Black, false, false, true, true);

            PrinterHelper.Printer.Line(new PointF(100, 3800), new PointF(15000, 3850), Color.Gray, false, false, true, true);

            PrinterHelper.Printer.Line(new PointF(100, 4150), new PointF(15000, 4200), Color.Gray, false, false, true, true);

            

			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.FontBold = false;
			
			//
			//  iContLineas = NULL_INTEGER
			//
			//'  Printer.FontName = Printer.Fonts(1)
			//  Printer.FontName = "Courier New"
			//  Printer.FontSize = 10
			//  Printer.FontBold = True
			//
			//  Printer.Print Space((120 - Len(pszTitRep)) / 2) + UCase$(pszTitRep)
			//  Printer.Print
			//  Printer.Print pszCadena1
			//  Printer.Print pszCadena2
			//  Printer.Print pszCadena3
			//  Printer.Print pszCadena4
			//  Printer.Print pszCadena5
			//  Printer.Print pszCadena6
			//  Printer.Print pszCadena7
			//  Printer.Print pszCadena8
			//
			//  'Printer.FontName = "Courier New"
			//  Printer.FontName = "Courier New"
			//  Printer.Print
			//
			//'  Printer.FontName = "Courier New"
			//'  Printer.FontSize = 10
			//  Printer.FontBold = True
			//  Printer.Print pszHeaderSS
			//
			//  Printer.Line (100, 1500)-(15000, 1600), QBColor(0), BF
			//  Printer.Line (100, 3500)-(15000, 3550), QBColor(8), BF
			//  Printer.Line (100, 3850)-(15000, 3900), QBColor(8), BF
			//
			//  'Printer.FontName = "Courier New"
			//  Printer.FontName = "Courier New"
			//  Printer.Print
			//  Printer.FontBold = False
			//
			//'  Printer.FontName = "Courier New"
			//'  Printer.FontSize = 10
			//'  Printer.FontBold = False
		}
		
		static public void  Imprime_REN( AxFPSpread.AxvaSpread cSpread)
		{
			int ilComienzo = 0;
			iMaxRenglones = cSpread.MaxRows;
			iMaxcolumnas = cSpread.MaxCols;
			
			iFlood = CORVB.NULL_INTEGER;
			bColorCamb = 0;
			PrinterHelper.Printer.FontBold = false;
			
			for (int iContRen = 1; iContRen <= iMaxRenglones; iContRen++)
			{
				
				//iFlood = iContRen * 100 / iMaxRenglones
				iFlood = Convert.ToInt32(Math.Floor((iContRen / ((double) iMaxRenglones)) * 100));
				CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) iFlood;
				if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1: 0) &  ~bColorCamb) != 0)
				{
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
					bColorCamb = -1;
				}
				cSpread.Row = iContRen;
				ppszCadenaImp = CORVB.NULL_STRING;
				ppszCadenaImp = new String(' ', 180);
				
				if (CORCTREN.DefInstance.Tag.ToString() == "Detalle" || CORCTREN.DefInstance.Tag.ToString() == "Detalle_Rango")
				{
					cSpread.Col = 1; //numero de cuaenta
					ilComienzo = 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 2, cSpread.Text.Trim());
					
					cSpread.Col = 2; //Nombre
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 22, cSpread.Text.Trim());
					
					cSpread.Col = 3; //facturacuion
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 70, new String(' ', 25 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
					cSpread.Col = 4; //cartera
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 95, new String(' ', 25 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
					cSpread.Col = 5; //totl rentabilkodda
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 125, new String(' ', 25 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
					if (CORCTREN.DefInstance.Tag.ToString() == "Detalle_Rango")
					{
						cSpread.Col = 6; //mes
						ilComienzo = ilComienzo + 18 + 2;
						ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 155, new String(' ', 20 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					}
					
				} else if (CORMNREN.DefInstance.sprRepRenta.MaxCols != 7) { 
					cSpread.Col = 1; //Empresa
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 2, cSpread.Text.Trim());
					
					cSpread.Col = 2; //Nombre
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 9, cSpread.Text.Trim());
					
					cSpread.Col = 3; //grupo
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 58, cSpread.Text.Trim());
					
					cSpread.Col = 4; //facturacuion
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 92, new String(' ', 20 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
					cSpread.Col = 5; //cartera
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 112, new String(' ', 20 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
					cSpread.Col = 6; //total rentabilkodda
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 142, new String(' ', 22 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
				} else
				{
					cSpread.Col = 1; //Empresa
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 2, cSpread.Text.Trim());
					
					cSpread.Col = 2; //Nombre
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 10, cSpread.Text.Trim());
					
					cSpread.Col = 4; //facturacuion
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 50, new String(' ', 25 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
					cSpread.Col = 5; //cartera
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 85, new String(' ', 25 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
					cSpread.Col = 6; //totl rentabilkodda
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 115, new String(' ', 25 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
					
					cSpread.Col = 7; //mes
					ilComienzo = ilComienzo + 18 + 2;
					ppszCadenaImp = StringsHelper.MidAssignment(ppszCadenaImp, 145, new String(' ', 20 - cSpread.Text.Trim().Length) + cSpread.Text.Trim());
				}
				
				if (iContRen == iMaxRenglones)
				{
					PrinterHelper.Printer.Print();
					iContLineas++;
					if (iContLineas > INT_MAX_LINEAS_H)
					{ //Se completó la página
						PrinterHelper.Printer.Print();
						PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
						PrinterHelper.Printer.NewPage();
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						//         Lineas_EnBlanco INT_ESPACIOS_CABECERA + 2
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO NUEVO FSWBMX *****
						Lineas_EnBlanco(INT_ESPACIOS_CABECERA);
						//***** FIN DE CODIGO NUEVO FSWBMX *****
						Imprime_Encabezados();
						iContLineas = CORVB.NULL_INTEGER;
					}
					PrinterHelper.Printer.FontBold = false;
				}
				
				PrinterHelper.Printer.Print(ppszCadenaImp);
				
				iContLineas++;
				if (iContLineas > INT_MAX_LINEAS_H)
				{ //Se completó la página
					PrinterHelper.Printer.Print();
					PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
					PrinterHelper.Printer.NewPage();
					Lineas_EnBlanco(INT_ESPACIOS_CABECERA + 2);
					Imprime_Encabezados();
					iContLineas = CORVB.NULL_INTEGER;
				}
				PrinterHelper.Printer.FontBold = false;
			}
			
			Lineas_EnBlanco(INT_MAX_LINEAS_H - iContLineas);
			PrinterHelper.Printer.Print();
			PrinterHelper.Printer.Print(new String(' ', INT_ESPACIOS_BLANCOS_H) + "Pág. #" + PrinterHelper.Printer.Page.ToString());
			
		}
		
		
		//****************************************************************************
		//**                                                                        **
		//**       Descripción: Imprime en la Impresora por defecto el contenido    **
		//**                    del reporte en cuestión; Datos generales, Resu -    **
		//**                    men y Desgloses en el Spread Sheet                  **
		//**                                                                        **
		//**       Declaración: sub Manda_Impresora()                               **
		//**                                                                        **
		//**       Paso de parámetros: fForm - La forma del Reporte                 **
		//**                           cSpread - El Spread Sheet del Reporte        **
		//**                                                                        **
		//**       Valor de Regreso: Ninguno                                        **
		//**                                                                        **
		//**       Variables globales que modifica :                                **
		//**           Al Proyecto :                                                **
		//**           A la forma :                                                 **
		//**                                                                        **
		//**       Ultima modificación: 300594                                      **
		//**                                                                        **
		//****************************************************************************
		static public void  Imprime_Reporte()
		{
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					if (CORVAR.igblFormaActiva != 0)
					{
						Cursor.Current = Cursors.WaitCursor;
						
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight; //Se establece el status bar
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short) CORVB.NULL_INTEGER;
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK);
						//CORMDIBN.ID_COR_MSG_TXT.Caption = STR_EXPORTANDO_TXT
						CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;
						if (CORVAR.igblFormaActiva == CORCONST.INT_ACT_DEJ)
						{ //yuriaOr igblFormaActiva = INT_ACT_CGR Then
							Lineas_EnBlanco(INT_ESPACIOS_CABECERA - 1);
						} else
						{
							Lineas_EnBlanco(INT_ESPACIOS_CABECERA); //Imprimimos 7 Líneas en Blanco
						}
					} else
					{
						Cursor.Current = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No existe reporte para ser impreso.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
					}
					
					switch(CORVAR.igblFormaActiva)
					{
						case CORCONST.INT_ACT_CEJ : 
							Obten_Encabezados(CORRPCEJ.DefInstance); 
							Imprime_Encabezados(); 
							Imprime_CEJ(CORRPCEJ.DefInstance.ID_CEJ_REP_SS); 
							break;
						case CORCONST.INT_ACT_CGR : 
							Obten_Encabezados(CORRPCGR.DefInstance); 
							Imprime_Encabezados(); 
							Imprime_CGR(CORRPCGR.DefInstance.ID_CGR_REP_SS); 
							break;
						case CORCONST.INT_ACT_ANG : 
							Obten_Encabezados(CORRPANG.DefInstance); 
							Imprime_Encabezados(); 
							Imprime_ANG(CORRPANG.DefInstance.ID_GIR_CON_SS); 
							break;
						case CORCONST.INT_ACT_DAT : 
							Obten_Encabezados(CORRPDAT.DefInstance); 
							Imprime_Encabezados();
                            //AIS-Bug 5410 FSABORIO. Try..catch added to emulate the on error resume next
                            try { Imprime_DAT(CORRPDAT.DefInstance.ID_CEJ_REP_SS); }
                            catch { }
							break;
						case CORCONST.INT_ACT_DEJ : 
							Obten_Encabezados(CORRPDEJ.DefInstance); 
							Imprime_Encabezados(); 
							Imprime_DEJ(CORRPDEJ.DefInstance.ID_CEJ_REP_SS); 
							break;
						case CORCONST.INT_ACT_EMA : 
							Obten_Encabezados(CORRPEM2.DefInstance); 
							Imprime_Encabezados(); 
							Imprime_EMA(CORRPEM2.DefInstance.ID_EMA_REP_SS); 
							break;
						case CORCONST.INT_ACT_REN :  //RENTABILIDAD 
							Obten_Encabezados(CORMNREN.DefInstance); 
							Imprime_Encabezados(); 
							Imprime_REN(CORMNREN.DefInstance.sprRepRenta); 
							 
							break;
					}
					
					//Cerramos el trabajo de Impresión
					PrinterHelper.Printer.EndDoc();
					
					//Regresamos el status bar
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
					CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = false;
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = CORVB.NONE;
					
					Cursor.Current = Cursors.Default;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
		}
		
		
		static public void  Inserta_Meses( ComboBox cControl)
		{
			
			double dTemp = 0;
			string pszMesTemp = String.Empty;
			int iDiaTemp = 0;
			int iMesTemp = 0;
			int iAñoTemp = 0;
			int bCambio = 0;
			
			
			//Ordena el Arreglo de Fechas
			for (int iCont2 = 0; iCont2 <= CORVAR.dArrMesAño.GetUpperBound(0) - 1; iCont2++)
			{
				for (int iCont = iCont2; iCont <= CORVAR.dArrMesAño.GetUpperBound(0); iCont++)
				{
					if (CORVAR.dArrMesAño[iCont2] < CORVAR.dArrMesAño[iCont])
					{
						dTemp = CORVAR.dArrMesAño[iCont2];
						CORVAR.dArrMesAño[iCont2] = CORVAR.dArrMesAño[iCont];
						CORVAR.dArrMesAño[iCont] = dTemp;
					}
				}
			}
			
			//Obtenemos el nombre del Mes y Año en el Arreglo
			for (int iCont = 0; iCont <= CORVAR.dArrMesAño.GetUpperBound(0); iCont++)
			{
				iAñoTemp = DateTime.FromOADate(CORVAR.dArrMesAño[iCont]).Year;
				iDiaTemp = DateAndTime.Day(DateTime.FromOADate(CORVAR.dArrMesAño[iCont]));
                iMesTemp = DateAndTime.Month(DateTime.FromOADate(CORVAR.dArrMesAño[iCont])); //AIS-1233 echasiquiza
				switch(iMesTemp)
				{
					case 1 :  
						pszMesTemp = "Enero"; 
						break;
					case 2 :  
						pszMesTemp = "Febrero"; 
						break;
					case 3 :  
						pszMesTemp = "Marzo"; 
						break;
					case 4 :  
						pszMesTemp = "Abril"; 
						break;
					case 5 :  
						pszMesTemp = "Mayo"; 
						break;
					case 6 :  
						pszMesTemp = "Junio"; 
						break;
					case 7 :  
						pszMesTemp = "Julio"; 
						break;
					case 8 :  
						pszMesTemp = "Agosto"; 
						break;
					case 9 :  
						pszMesTemp = "Septiembre"; 
						break;
					case 10 :  
						pszMesTemp = "Octubre"; 
						break;
					case 11 :  
						pszMesTemp = "Noviembre"; 
						break;
					case 12 :  
						pszMesTemp = "Diciembre"; 
						break;
				}
				
				//ros    cControl.AddItem pszMesTemp + "  " + Right$(Format$(iAñoTemp), 2)
				cControl.Items.Add(new ListBoxItem(pszMesTemp + "  " + iAñoTemp.ToString(), Convert.ToInt32(Conversion.Val(iMesTemp.ToString() + iDiaTemp.ToString()))));
			}
			
		}
		
		static public void  Lineas_EnBlanco( int iLineas)
		{
			
			//** Esta rutina manda iLineas en Blanco a la Impresora
			
			for (int iLineasl = 1; iLineasl <= iLineas; iLineasl++)
			{
				PrinterHelper.Printer.Print(CORVB.NULL_STRING);
			}
			
		}
		
		
		static public int ModuloEnUso( string pszModulo)
		{
			
			
			int bExiste = 0;
            String tmpStr = "0";
            IntPtr intPtr = API.USER.FindWindow(tmpStr, pszModulo);
            if (intPtr.ToInt32() != 0)
			{
				bExiste = -1;
			}
			
			return bExiste;
			
		}
		
		static public string Muestra_Mensaje( string sMensaje)
		{
			//función que muestra el mensaje que envia el s111
			//quitando los caracteres raros y no imprimibles
			string result = String.Empty;
			string pszCaracter = String.Empty;
			
			result = CORVB.NULL_STRING;
			for (int I = 1; I <= sMensaje.Length; I++)
			{
				pszCaracter = Strings.Mid(sMensaje, I, 1);
				if ((((int) pszCaracter[0]) >= 32 && ((int) pszCaracter[0]) <= 63) || (((int) pszCaracter[0]) >= 65 && ((int) pszCaracter[0]) <= 125))
				{
					result = result + pszCaracter;
				}
			}
			
			return result;
		}
		
		//****************************************************************************
		//**                                                                        **
		//**       Descripción: Toma los encabezados de Cada reporte y los dis -    e*
		//**                    tribuye de tal manera que se centren en la Im  -    **
		//**                    presión                                             **
		//**                                                                        **
		//**       Declaración: Sub Distribuye_Espacios()                           **
		//**                                                                        **
		//**       Paso de parámetros: cSpread   - El Spread Sheet del Reporte      **
		//**                           fForm     - La forma del Reporte             **
		//**                           pszCadenaena1 - El primer encabezado             **
		//**                                                                        **
		//**       Valor de Regreso: Los encabezados del Reporte (1 a 8)            **
		//**                                                                        **
		//**       Variables globales que modifica :                                **
		//**           Al Proyecto :                                                **
		//**           A la forma :                                                 **
		//**                                                                        **
		//**       Ultima modificación: 300594                                      **
		//**                                                                        **
		//****************************************************************************
		static public void  Obten_Encabezados( Form fForm,  int ipPrefijo,  int ipBanco,  int lpEmpresa)
		{
			
			string pszDiasGra = String.Empty;
			string pszDiasFes = String.Empty;
			int iNumChar = 0;
			//AIS-1178 NGONZALEZ
			CORVAR.DiasFestivos[] iArrDiasF = new CORVAR.DiasFestivos[0];// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
			int iNumDiasF = 0;
			int iContApu = 0;
			int iCont = 0;
			int bDiaInhabil = 0;
			string pszTitulo = String.Empty;
			int iLen = 0;
			string pszFecha = String.Empty;
			string pszFechaAño = String.Empty;
			
			//***** JPU *****
			int ilCont = 0;
			
			pszCadena1 = CORVB.NULL_STRING;
			pszCadena2 = CORVB.NULL_STRING;
			pszCadena3 = CORVB.NULL_STRING;
			pszCadena4 = CORVB.NULL_STRING;
			pszCadena5 = CORVB.NULL_STRING;
			pszCadena6 = CORVB.NULL_STRING;
			pszCadena7 = CORVB.NULL_STRING;
			pszCadena8 = CORVB.NULL_STRING;
			pszHeaderSS = CORVB.NULL_STRING;
			pszTitRep = CORVB.NULL_STRING;
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					//Obtener días y plazo de Gracia (Pendiente)
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_plazo_gracia";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();
					
					if (CORPROC2.Cuenta_Registros() > 0)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
							{
								pszDiasGra = Conversion.Str(VBSQL.SqlData(CORVAR.hgblConexion, 1));
							}
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					} else
					{
						Cursor.Current = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró el Plazo de Gracia dentro de la Empresa. Esto generará problemas en los cálculos de Límites de Pago.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					
					//Obtener los dias festivos
					CORVAR.pszgblsql = "select";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " dfe_dia,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " dfe_mes";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCDFE01";
					
					if (CORPROC2.Cuenta_Registros() > 0)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							ilCont = 0;
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								if (ilCont == 0)
								{
									pszDiasFes = StringsHelper.Format(Conversion.Str(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "00") + "/" + StringsHelper.Format(Conversion.Str(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "00");
									ilCont = 1;
								} else
								{
									pszDiasFes = pszDiasFes + "," + StringsHelper.Format(Conversion.Str(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "00") + "/" + StringsHelper.Format(Conversion.Str(VBSQL.SqlData(CORVAR.hgblConexion, 2)), "00");
								}
							};
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						iNumDiasF = -1;
						iContApu = 1;
						for (iCont = 1; iCont <= pszDiasFes.Length; iCont++)
						{
							if (Strings.Mid(pszDiasFes, iCont, 1) == "/")
							{
								iNumDiasF++;
								iArrDiasF = ArraysHelper.RedimPreserve<CORVAR.DiasFestivos[]>(iArrDiasF, new int[]{iNumDiasF + 1});
								iArrDiasF[iNumDiasF].iDia = Convert.ToInt32(Conversion.Val(Strings.Mid(pszDiasFes, iContApu, 2)));
								iContApu = iCont + 1;
							} else if (Strings.Mid(pszDiasFes, iCont, 1) == ",") { 
								iArrDiasF[iNumDiasF].iMes = Convert.ToInt32(Conversion.Val(Strings.Mid(pszDiasFes, iContApu, 2)));
								iContApu = iCont + 1;
							}
						}
						iArrDiasF[iNumDiasF].iMes = Convert.ToInt32(Conversion.Val(Strings.Mid(pszDiasFes, iContApu, 2)));
						iContApu = iCont + 1;
					} else
					{
						Cursor.Current = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						CORVAR.igblErr = (int) Interaction.MsgBox("No se encontraron los Días Festivos dentro de la Base de Datos.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					
					//10.01.2002 Extraer fecha de corte, acorde a la empresa
					int iDiaActual = CORVAR.igblMesCorte % 100;
					int iMesActual = CORVAR.igblMesCorte / 100;
					double dFechaActual = Convert.ToDouble(DateAndTime.DateSerial(CORVAR.igblAñoCorte, iMesActual, iDiaActual).ToOADate());
					
					int iDiaPago = CORVAR.igblMesCorte % 100;
					int iMesPago = CORVAR.igblMesCorte / 100;
					double dFechaPago = Convert.ToDouble(DateAndTime.DateSerial(CORVAR.igblAñoCorte, iMesPago, iDiaPago).AddDays(Conversion.Val(pszDiasGra)).ToOADate());
					
					do 
					{
						bDiaInhabil = -1;
						//Verifica si es sabado o domingo para sumarle un dia a la fecha de pago
						iDiaPago = DateAndTime.Weekday(DateTime.Parse(DateAndTime.Day(DateTime.FromOADate(dFechaPago)).ToString() + "/" + DateTime.FromOADate(dFechaPago).Month.ToString() + "/" + DateTime.FromOADate(dFechaPago).Year.ToString()), FirstDayOfWeek.Sunday);
						if (iDiaPago == 1 || iDiaPago == 7)
						{
							dFechaPago++;
							bDiaInhabil = 0;
						}
						//Verifica es un dia festivo para sumarle un dia a la fecha de pago
						foreach (CORVAR.DiasFestivos iArrDiasF_item in iArrDiasF)
						{
							if (DateTime.FromOADate(dFechaPago) == DateAndTime.DateSerial(CORVAR.igblAñoCorte, iArrDiasF_item.iMes, iArrDiasF_item.iDia))
							{
								dFechaPago++;
								bDiaInhabil = 0;
								break;
							}
						}
					}
					while(bDiaInhabil != (-1));
					
					int iFechaPago = DateTime.FromOADate(dFechaPago).Month * 100 + DateAndTime.Day(DateTime.FromOADate(dFechaPago));
					
					switch(CORVAR.igblFormaActiva)
					{
						case CORCONST.INT_ACT_CEJ :
                            CORRPCEJ CORRPCEJ1 = (CORRPCEJ)fForm;
							pszCadena1 = new String(' ', 92); 
							pszCadena1 = StringsHelper.MidAssignment(pszCadena1, 3, CORRPCEJ1.ID_CEJ_EMP_LBL.Text.Trim()); 
							pszCadena1 = StringsHelper.MidAssignment(pszCadena1, 53, CORRPCEJ1.ID_CEJ_ETI_TXT[0].Text.Trim()); 
							pszCadena1 = StringsHelper.MidAssignment(pszCadena1, 73, new String(' ', 20 - CORRPCEJ1.ID_CEJ_RES_TXT[0].Text.Trim().Length) + CORRPCEJ1.ID_CEJ_RES_TXT[0].Text.Trim());
                            pszCadena2 = new String(' ', 92); 
							pszCadena2 = StringsHelper.MidAssignment(pszCadena2, 3, CORRPCEJ1.ID_CEJ_DI1_LBL.Text.Trim()); 
							pszCadena2 = StringsHelper.MidAssignment(pszCadena2, 53, CORRPCEJ1.ID_CEJ_ETI_TXT[1].Text.Trim()); 
							pszCadena2 = StringsHelper.MidAssignment(pszCadena2, 73, new String(' ', 20 - CORRPCEJ1.ID_CEJ_RES_TXT[1].Text.Trim().Length) + CORRPCEJ1.ID_CEJ_RES_TXT[1].Text.Trim());
                            pszCadena3 = new String(' ', 92); 
							pszCadena3 = StringsHelper.MidAssignment(pszCadena3, 3, CORRPCEJ1.ID_CEJ_DI2_LBL.Text.Trim()); 
							pszCadena3 = StringsHelper.MidAssignment(pszCadena3, 53, CORRPCEJ1.ID_CEJ_ETI_TXT[2].Text.Trim()); 
							pszCadena3 = StringsHelper.MidAssignment(pszCadena3, 73, new String(' ', 20 - CORRPCEJ1.ID_CEJ_RES_TXT[2].Text.Trim().Length) + CORRPCEJ1.ID_CEJ_RES_TXT[2].Text.Trim()); 
							pszCadena4 = new String(' ', 92); 
							pszCadena4 = StringsHelper.MidAssignment(pszCadena4, 3, CORRPCEJ1.ID_CEJ_DI3_LBL.Text.Trim()); 
							pszCadena4 = StringsHelper.MidAssignment(pszCadena4, 53, CORRPCEJ1.ID_CEJ_ETI_TXT[3].Text.Trim()); 
							pszCadena4 = StringsHelper.MidAssignment(pszCadena4, 73, new String(' ', 20 - CORRPCEJ1.ID_CEJ_RES_TXT[3].Text.Trim().Length) + CORRPCEJ1.ID_CEJ_RES_TXT[3].Text.Trim()); 
							pszCadena5 = new String(' ', 92); 
							pszCadena5 = StringsHelper.MidAssignment(pszCadena5, 3, CORRPCEJ1.ID_CEJ_CP_LBL.Text.Trim()); 
							pszCadena5 = StringsHelper.MidAssignment(pszCadena5, 53, CORRPCEJ1.ID_CEJ_ETI_TXT[4].Text.Trim()); 
							pszCadena5 = StringsHelper.MidAssignment(pszCadena5, 73, new String(' ', 20 - CORRPCEJ1.ID_CEJ_RES_TXT[4].Text.Trim().Length) + CORRPCEJ1.ID_CEJ_RES_TXT[4].Text.Trim()); 
							pszCadena6 = new String(' ', 92); 
							//      Mid$(pszCadena6, 3, 30) = Trim$(fForm.ID_DAT_CRE_TXT) 
							//      Mid$(pszCadena6, 33, 20) = Space$(14 - Len(Trim$(fForm.ID_CEJ_CRE_EB))) + Trim$(fForm.ID_CEJ_CRE_EB) 
							pszCadena6 = StringsHelper.MidAssignment(pszCadena6, 53, CORRPCEJ1.ID_CEJ_ETI_TXT[5].Text.Trim()); 
							pszCadena6 = StringsHelper.MidAssignment(pszCadena6, 73, new String(' ', 20 - CORRPCEJ1.ID_CEJ_RES_TXT[5].Text.Trim().Length) + CORRPCEJ1.ID_CEJ_RES_TXT[5].Text.Trim()); 
							pszCadena7 = new String(' ', 92); 
							//      Mid$(pszCadena7, 3, 30) = Trim$(fForm.ID_DAT_CRE_ACU_TXT) 
							//      Mid$(pszCadena7, 33, 20) = Space$(14 - Len(Trim$(fForm.ID_CEJ_CRE_ACU_EB))) + Trim$(fForm.ID_CEJ_CRE_ACU_EB) 
							pszCadena7 = StringsHelper.MidAssignment(pszCadena7, 53, CORRPCEJ1.ID_CEJ_ETI_TXT[6].Text.Trim()); 
							pszCadena7 = StringsHelper.MidAssignment(pszCadena7, 73, new String(' ', 20 - CORRPCEJ1.ID_CEJ_RES_TXT[6].Text.Trim().Length) + CORRPCEJ1.ID_CEJ_RES_TXT[6].Text.Trim()); 
							 
							pszCadena8 = new String(' ', 92); 
							//      Mid$(pszCadena8, 3, 30) = Trim$(fForm.ID_DAT_FEC_CRE_TXT) 
							//      Mid$(pszCadena8, 33, 20) = Space$(14 - Len(Trim$(fForm.ID_CEJ_FEC_CRE_EB))) + Trim$(fForm.ID_CEJ_FEC_CRE_EB) 
							pszCadena8 = StringsHelper.MidAssignment(pszCadena8, 53, CORRPCEJ1.ID_CEJ_ETI_TXT[7].Text.Trim()); 
							pszCadena8 = StringsHelper.MidAssignment(pszCadena8, 73, new String(' ', 20 - CORRPCEJ1.ID_CEJ_RES_TXT[7].Text.Trim().Length) + CORRPCEJ1.ID_CEJ_RES_TXT[7].Text.Trim()); 
							// 
							pszHeaderSS = new String(' ', 180); 
							pszTitulo = "CTA";  
							iLen = Formato.igLongitudEjecutivo; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 1, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "EJECUTIVO";  
							iLen = 20; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 5, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "NOMINA";  
							iLen = 8; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 26, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "LIM. CRED.";  
							iLen = 12; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 35, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "C.  COSTOS";  
							iLen = 10; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 49, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "ATR";  
							iLen = 3; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 60, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SDO.ANTERIOR";  
							iLen = 13; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 64, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "CONSUMOS";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 78, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "DISP.EFVO.";  
							iLen = 13; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 93, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "PAGOS";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 107, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "COMISIONES";  
							iLen = 13; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 122, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "GTOS. COBR.";  
							iLen = 13; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 136, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "I.V.A.";  
							iLen = 10; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 150, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SALDO NUEVO";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 161, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							 
							break;
						case CORCONST.INT_ACT_CGR :
                            CORRPCGR CORRPCGR1 = (CORRPCGR)fForm;
							pszCadena1 = new String(' ', 92); 
							pszCadena1 = StringsHelper.MidAssignment(pszCadena1, 3, CORRPCGR1.ID_CGR_EMP_LBL.Text.Trim()); 
							pszCadena1 = StringsHelper.MidAssignment(pszCadena1, 53, CORRPCGR1.ID_CGR_ETI_TXT[0].Text.Trim()); 
							pszCadena1 = StringsHelper.MidAssignment(pszCadena1, 73, new String(' ', 20 - CORRPCGR1.ID_CGR_RES_TXT[0].Text.Trim().Length) + CORRPCGR1.ID_CGR_RES_TXT[0].Text.Trim()); 							 
							pszCadena2 = new String(' ', 92); 
							pszCadena2 = StringsHelper.MidAssignment(pszCadena2, 3, CORRPCGR1.ID_CGR_DI1_LBL.Text.Trim()); 
							pszCadena2 = StringsHelper.MidAssignment(pszCadena2, 53, CORRPCGR1.ID_CGR_ETI_TXT[1].Text.Trim()); 
							pszCadena2 = StringsHelper.MidAssignment(pszCadena2, 73, new String(' ', 20 - CORRPCGR1.ID_CGR_RES_TXT[1].Text.Trim().Length) + CORRPCGR1.ID_CGR_RES_TXT[1].Text.Trim()); 
							pszCadena3 = new String(' ', 92); 
							pszCadena3 = StringsHelper.MidAssignment(pszCadena3, 3, CORRPCGR1.ID_CGR_DI2_LBL.Text.Trim()); 
							pszCadena3 = StringsHelper.MidAssignment(pszCadena3, 53, CORRPCGR1.ID_CGR_ETI_TXT[2].Text.Trim()); 
							pszCadena3 = StringsHelper.MidAssignment(pszCadena3, 73, new String(' ', 20 - CORRPCGR1.ID_CGR_RES_TXT[2].Text.Trim().Length) + CORRPCGR1.ID_CGR_RES_TXT[2].Text.Trim()); 
							pszCadena4 = new String(' ', 92); 
							pszCadena4 = StringsHelper.MidAssignment(pszCadena4, 3, CORRPCGR1.ID_CGR_DI3_LBL.Text.Trim()); 
							pszCadena4 = StringsHelper.MidAssignment(pszCadena4, 53, CORRPCGR1.ID_CGR_ETI_TXT[3].Text.Trim()); 
							pszCadena4 = StringsHelper.MidAssignment(pszCadena4, 73, new String(' ', 20 - CORRPCGR1.ID_CGR_RES_TXT[3].Text.Trim().Length) + CORRPCGR1.ID_CGR_RES_TXT[3].Text.Trim()); 
							pszCadena5 = new String(' ', 92); 
							pszCadena5 = StringsHelper.MidAssignment(pszCadena5, 3, CORRPCGR1.ID_CGR_CP_LBL.Text.Trim()); 
							pszCadena5 = StringsHelper.MidAssignment(pszCadena5, 53, CORRPCGR1.ID_CGR_ETI_TXT[4].Text.Trim()); 
							pszCadena5 = StringsHelper.MidAssignment(pszCadena5, 73, new String(' ', 20 - CORRPCGR1.ID_CGR_RES_TXT[4].Text.Trim().Length) + CORRPCGR1.ID_CGR_RES_TXT[4].Text.Trim()); 
							 
							pszCadena6 = new String(' ', 92); 
							//      Mid$(pszCadena6, 3, 30) = Trim$(fForm.ID_CGR_CRED_LBL) 
							//      Mid$(pszCadena6, 33, 20) = Space$(14 - Len(Trim$(fForm.ID_CGR_CRE_TOT_LBL))) + Trim$(fForm.ID_CGR_CRE_TOT_LBL) 
							pszCadena6 = StringsHelper.MidAssignment(pszCadena6, 53, CORRPCGR1.ID_CGR_ETI_TXT[5].Text.Trim()); 
							//UPGRADE_ISSUE: (2072) Control ID_CGR_RES_TXT could not be resolved because it was within the generic namespace Form. 
							pszCadena6 = StringsHelper.MidAssignment(pszCadena6, 73, new String(' ', 20 - CORRPCGR1.ID_CGR_RES_TXT[5].Text.Trim().Length) + CORRPCGR1.ID_CGR_RES_TXT[5].Text.Trim()); 
							 
							pszCadena7 = new String(' ', 92); 
							//      Mid$(pszCadena7, 3, 30) = Trim$(fForm.ID_CGR_ACUM_LBL) 
							//      Mid$(pszCadena7, 33, 20) = Space$(14 - Len(Trim$(fForm.ID_CGR_CRE_ACU_LBL))) + Trim$(fForm.ID_CGR_CRE_ACU_LBL) 
							pszCadena7 = StringsHelper.MidAssignment(pszCadena7, 53, CORRPCGR1.ID_CGR_ETI_TXT[6].Text.Trim()); 
                            pszCadena7 = StringsHelper.MidAssignment(pszCadena7, 73, new String(' ', 20 - CORRPCGR1.ID_CGR_RES_TXT[6].Text.Trim().Length) + CORRPCGR1.ID_CGR_RES_TXT[6].Text.Trim()); 
							 
							pszCadena8 = new String(' ', 92); 
							//      Mid$(pszCadena8, 3, 30) = Trim$(fForm.ID_CGR_FEC_LBL) 
							//      Mid$(pszCadena8, 33, 20) = Space$(14 - Len(Trim$(fForm.ID_CGR_FEC_CRED_LBL))) + Trim$(fForm.ID_CGR_FEC_CRED_LBL) 
							pszCadena8 = StringsHelper.MidAssignment(pszCadena8, 53, CORRPCGR1.ID_CGR_ETI_TXT[7].Text.Trim()); 
							pszCadena8 = StringsHelper.MidAssignment(pszCadena8, 73, new String(' ', 20 - CORRPCGR1.ID_CGR_RES_TXT[7].Text.Trim().Length) + CORRPCGR1.ID_CGR_RES_TXT[7].Text.Trim()); 
							 
							pszHeaderSS = new String(' ', 180); 
							pszTitulo = "NO.";  
							iLen = 5; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 2, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "NOMBRE";  
							iLen = 25; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 9, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "TARJ";  
							iLen = 4; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 35, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "CREDITO";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 41, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "ATR";  
							iLen = 3; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 57, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SDO. ANTERIOR";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 62, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "CONSUMOS";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 78, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "DISP.EFVO.";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 94, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "PAGOS";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 110, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "COMISIONES";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 126, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "GTOS.COBR.";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 142, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SDO.NUEVO";  
							iLen = 14; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 158, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							
							
							 
							break;
						case CORCONST.INT_ACT_ANG :
                            CORRPANG CORRPANG1 = (CORRPANG)fForm;
							pszCadena1 = new String(' ', 2) + CORRPANG1.ID_ACG_DEM_TXT[0].Text.Trim() + new String(' ', 50 - CORRPANG1.ID_ACG_DEM_TXT[0].Text.Trim().Length) + CORRPANG1.ID_ACG_ETI_TXT[0].Text.Trim() + new String(' ', 25 - CORRPANG1.ID_ACG_ETI_TXT[0].Text.Trim().Length) + new String(' ', 15 - CORRPANG1.ID_ACG_RES_TXT[0].Text.Trim().Length) + CORRPANG1.ID_ACG_RES_TXT[0].Text.Trim(); 
							pszCadena2 = new String(' ', 2) + CORRPANG1.ID_ACG_DEM_TXT[1].Text.Trim() + new String(' ', 50 - CORRPANG1.ID_ACG_DEM_TXT[1].Text.Trim().Length) + CORRPANG1.ID_ACG_ETI_TXT[1].Text.Trim() + new String(' ', 25 - CORRPANG1.ID_ACG_ETI_TXT[1].Text.Trim().Length) + new String(' ', 15 - CORRPANG1.ID_ACG_RES_TXT[1].Text.Trim().Length) + CORRPANG1.ID_ACG_RES_TXT[1].Text.Trim(); 
							pszCadena3 = new String(' ', 2) + CORRPANG1.ID_ACG_DEM_TXT[2].Text.Trim() + new String(' ', 50 - CORRPANG1.ID_ACG_DEM_TXT[2].Text.Trim().Length) + CORRPANG1.ID_ACG_ETI_TXT[2].Text.Trim() + new String(' ', 25 - CORRPANG1.ID_ACG_ETI_TXT[2].Text.Trim().Length) + new String(' ', 15 - CORRPANG1.ID_ACG_RES_TXT[2].Text.Trim().Length) + CORRPANG1.ID_ACG_RES_TXT[2].Text.Trim(); 
							pszCadena4 = new String(' ', 2) + CORRPANG1.ID_ACG_DEM_TXT[3].Text.Trim() + new String(' ', 50 - CORRPANG1.ID_ACG_DEM_TXT[3].Text.Trim().Length) + CORRPANG1.ID_ACG_ETI_TXT[3].Text.Trim() + new String(' ', 25 - CORRPANG1.ID_ACG_ETI_TXT[3].Text.Trim().Length) + new String(' ', 15 - CORRPANG1.ID_ACG_RES_TXT[3].Text.Trim().Length) + CORRPANG1.ID_ACG_RES_TXT[3].Text.Trim(); 
							pszCadena5 = new String(' ', 2) + CORRPANG1.ID_ACG_DEM_TXT[4].Text.Trim() + new String(' ', 50 - CORRPANG1.ID_ACG_DEM_TXT[4].Text.Trim().Length) + CORRPANG1.ID_ACG_ETI_TXT[4].Text.Trim() + new String(' ', 25 - CORRPANG1.ID_ACG_ETI_TXT[4].Text.Trim().Length) + new String(' ', 15 - CORRPANG1.ID_ACG_RES_TXT[4].Text.Trim().Length) + CORRPANG1.ID_ACG_RES_TXT[4].Text.Trim(); 
							pszCadena6 = new String(' ', 2) + CORRPANG1.ID_ACG_DEM_TXT[5].Text.Trim() + new String(' ', 50 - CORRPANG1.ID_ACG_DEM_TXT[5].Text.Trim().Length) + CORRPANG1.ID_ACG_ETI_TXT[5].Text.Trim() + new String(' ', 25 - CORRPANG1.ID_ACG_ETI_TXT[5].Text.Trim().Length) + new String(' ', 15 - CORRPANG1.ID_ACG_RES_TXT[5].Text.Trim().Length) + CORRPANG1.ID_ACG_RES_TXT[5].Text.Trim(); 
							pszCadena7 = new String(' ', 52) + CORRPANG1.ID_ACG_ETI_TXT[6].Text.Trim() + new String(' ', 25 - CORRPANG1.ID_ACG_ETI_TXT[6].Text.Trim().Length) + new String(' ', 15 - CORRPANG1.ID_ACG_RES_TXT[6].Text.Trim().Length) + CORRPANG1.ID_ACG_RES_TXT[6].Text.Trim(); 
							pszCadena8 = new String(' ', 52) + CORRPANG1.ID_ACG_ETI_TXT[7].Text.Trim() + new String(' ', 25 - CORRPANG1.ID_ACG_ETI_TXT[7].Text.Trim().Length) + new String(' ', 15 - CORRPANG1.ID_ACG_RES_TXT[7].Text.Trim().Length) + CORRPANG1.ID_ACG_RES_TXT[7].Text.Trim(); 
							pszHeaderSS = new String(' ', 10) + "SEGMENTOS" + new String(' ', 28) + "MONTO"; 
							 
							break;
						case CORCONST.INT_ACT_DAT :
                            CORRPDAT CORRPDAT1 = (CORRPDAT)fForm; 
							pszCadena1 = new String(' ', 2) + CORRPDAT1.ID_DAT_DEM_TXT[0].Text.Trim() + new String(' ', 50 - CORRPDAT1.ID_DAT_DEM_TXT[0].Text.Trim().Length) + CORRPDAT1.ID_DAT_ETI_TXT[0].Text.Trim() + new String(' ', 25 - CORRPDAT1.ID_DAT_ETI_TXT[0].Text.Trim().Length) + new String(' ', 15 - CORRPDAT1.ID_DAT_RES_TXT[0].Text.Trim().Length) + CORRPDAT1.ID_DAT_RES_TXT[0].Text.Trim();
                            pszCadena2 = new String(' ', 2) + CORRPDAT1.ID_DAT_DEM_TXT[1].Text.Trim() + new String(' ', 50 - CORRPDAT1.ID_DAT_DEM_TXT[1].Text.Trim().Length) + CORRPDAT1.ID_DAT_ETI_TXT[1].Text.Trim() + new String(' ', 25 - CORRPDAT1.ID_DAT_ETI_TXT[1].Text.Trim().Length) + new String(' ', 15 - CORRPDAT1.ID_DAT_RES_TXT[1].Text.Trim().Length) + CORRPDAT1.ID_DAT_RES_TXT[1].Text.Trim(); 
							pszCadena3 = new String(' ', 2) + CORRPDAT1.ID_DAT_DEM_TXT[2].Text.Trim() + new String(' ', 50 - CORRPDAT1.ID_DAT_DEM_TXT[2].Text.Trim().Length) + CORRPDAT1.ID_DAT_ETI_TXT[2].Text.Trim() + new String(' ', 25 - CORRPDAT1.ID_DAT_ETI_TXT[2].Text.Trim().Length) + new String(' ', 15 - CORRPDAT1.ID_DAT_RES_TXT[2].Text.Trim().Length) + CORRPDAT1.ID_DAT_RES_TXT[2].Text.Trim(); 
							pszCadena4 = new String(' ', 2) + CORRPDAT1.ID_DAT_DEM_TXT[3].Text.Trim() + new String(' ', 50 - CORRPDAT1.ID_DAT_DEM_TXT[3].Text.Trim().Length) + CORRPDAT1.ID_DAT_ETI_TXT[3].Text.Trim() + new String(' ', 25 - CORRPDAT1.ID_DAT_ETI_TXT[3].Text.Trim().Length) + new String(' ', 15 - CORRPDAT1.ID_DAT_RES_TXT[3].Text.Trim().Length) + CORRPDAT1.ID_DAT_RES_TXT[3].Text.Trim(); 
							pszCadena5 = new String(' ', 2) + CORRPDAT1.ID_DAT_DEM_TXT[4].Text.Trim() + new String(' ', 50 - CORRPDAT1.ID_DAT_DEM_TXT[4].Text.Trim().Length) + CORRPDAT1.ID_DAT_ETI_TXT[4].Text.Trim() + new String(' ', 25 - CORRPDAT1.ID_DAT_ETI_TXT[4].Text.Trim().Length) + new String(' ', 15 - CORRPDAT1.ID_DAT_RES_TXT[4].Text.Trim().Length) + CORRPDAT1.ID_DAT_RES_TXT[4].Text.Trim(); 
							pszCadena6 = new String(' ', 2) + CORRPDAT1.ID_DAT_DEM_TXT[5].Text.Trim() + new String(' ', 50 - CORRPDAT1.ID_DAT_DEM_TXT[5].Text.Trim().Length) + CORRPDAT1.ID_DAT_ETI_TXT[5].Text.Trim() + new String(' ', 25 - CORRPDAT1.ID_DAT_ETI_TXT[5].Text.Trim().Length) + new String(' ', 15 - CORRPDAT1.ID_DAT_RES_TXT[5].Text.Trim().Length) + CORRPDAT1.ID_DAT_RES_TXT[5].Text.Trim(); 
							pszCadena7 = new String(' ', 52) + CORRPDAT1.ID_DAT_ETI_TXT[6].Text.Trim() + new String(' ', 20 - CORRPDAT1.ID_DAT_ETI_TXT[6].Text.Trim().Length) + new String(' ', 20 - CORRPDAT1.ID_DAT_RES_TXT[6].Text.Trim().Length) + CORRPDAT1.ID_DAT_RES_TXT[6].Text.Trim(); 
							pszCadena8 = new String(' ', 52) + CORRPDAT1.ID_DAT_ETI_TXT[7].Text.Trim() + new String(' ', 20 - CORRPDAT1.ID_DAT_ETI_TXT[7].Text.Trim().Length) + new String(' ', 20 - CORRPDAT1.ID_DAT_RES_TXT[7].Text.Trim().Length) + CORRPDAT1.ID_DAT_RES_TXT[7].Text.Trim(); 
							pszHeaderSS = new String(' ', 4) + "CUENTA" + new String(' ', 8) + "EJECUTIVO" + new String(' ', 11) + "NOMINA" + new String(' ', 3) + "C.  COSTOS" + new String(' ', 3) + "ATR" + new String(' ', 3) + "SALDO ANTERIOR" + new String(' ', 3) + "CONSUMOS" + new String(' ', 3) + "DISP.EFVO." + new String(' ', 6) + "PAGOS" + new String(' ', 4) + "COMISIONES" + new String(' ', 3) + "GTOS COBR." + new String(' ', 6) + "IVA" + new String(' ', 5) + "SALDO NUEVO"; 
							 
							break;
						case CORCONST.INT_ACT_DEJ :
                            CORRPDEJ CORRPDEJ1 = (CORRPDEJ)fForm; 
							
							pszCadena1 = new String(' ', 2) + CORRPDEJ1.ID_DAT_DEM_TXT[0].Text.Trim() + new String(' ', 50 - CORRPDEJ1.ID_DAT_DEM_TXT[0].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_ETI_TXT[0].Text.Trim() + new String(' ', 25 - CORRPDEJ1.ID_DEJ_ETI_TXT[0].Text.Trim().Length) + new String(' ', 15 - CORRPDEJ1.ID_DEJ_RES_TXT[0].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_RES_TXT[0].Text.Trim(); 
							pszCadena2 = new String(' ', 2) + CORRPDEJ1.ID_DAT_DEM_TXT[1].Text.Trim() + new String(' ', 50 - CORRPDEJ1.ID_DAT_DEM_TXT[1].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_ETI_TXT[1].Text.Trim() + new String(' ', 25 - CORRPDEJ1.ID_DEJ_ETI_TXT[1].Text.Trim().Length) + new String(' ', 15 - CORRPDEJ1.ID_DEJ_RES_TXT[1].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_RES_TXT[1].Text.Trim(); 
							pszCadena3 = new String(' ', 2) + CORRPDEJ1.ID_DAT_DEM_TXT[2].Text.Trim() + new String(' ', 50 - CORRPDEJ1.ID_DAT_DEM_TXT[2].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_ETI_TXT[2].Text.Trim() + new String(' ', 25 - CORRPDEJ1.ID_DEJ_ETI_TXT[2].Text.Trim().Length) + new String(' ', 15 - CORRPDEJ1.ID_DEJ_RES_TXT[2].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_RES_TXT[2].Text.Trim(); 
							pszCadena4 = new String(' ', 2) + CORRPDEJ1.ID_DAT_DEM_TXT[3].Text.Trim() + new String(' ', 50 - CORRPDEJ1.ID_DAT_DEM_TXT[3].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_ETI_TXT[3].Text.Trim() + new String(' ', 25 - CORRPDEJ1.ID_DEJ_ETI_TXT[3].Text.Trim().Length) + new String(' ', 15 - CORRPDEJ1.ID_DEJ_RES_TXT[3].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_RES_TXT[3].Text.Trim(); 
							pszCadena5 = new String(' ', 2) + CORRPDEJ1.ID_DAT_DEM_TXT[4].Text.Trim() + new String(' ', 50 - CORRPDEJ1.ID_DAT_DEM_TXT[4].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_ETI_TXT[4].Text.Trim() + new String(' ', 25 - CORRPDEJ1.ID_DEJ_ETI_TXT[4].Text.Trim().Length) + new String(' ', 15 - CORRPDEJ1.ID_DEJ_RES_TXT[4].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_RES_TXT[4].Text.Trim(); 
							pszCadena6 = new String(' ', 2) + CORRPDEJ1.ID_DAT_DEM_TXT[5].Text.Trim() + new String(' ', 50 - CORRPDEJ1.ID_DAT_DEM_TXT[5].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_ETI_TXT[5].Text.Trim() + new String(' ', 25 - CORRPDEJ1.ID_DEJ_ETI_TXT[5].Text.Trim().Length) + new String(' ', 15 - CORRPDEJ1.ID_DEJ_RES_TXT[5].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_RES_TXT[5].Text.Trim(); 
							pszCadena7 = new String(' ', 52) + CORRPDEJ1.ID_DEJ_ETI_TXT[6].Text.Trim() + new String(' ', 25 - CORRPDEJ1.ID_DEJ_ETI_TXT[6].Text.Trim().Length) + new String(' ', 15 - CORRPDEJ1.ID_DEJ_RES_TXT[6].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_RES_TXT[6].Text.Trim(); 
                            pszCadena8 = new String(' ', 52) + CORRPDEJ1.ID_DEJ_ETI_TXT[7].Text.Trim() + new String(' ', 25 - CORRPDEJ1.ID_DEJ_ETI_TXT[7].Text.Trim().Length) + new String(' ', 15 - CORRPDEJ1.ID_DEJ_RES_TXT[6].Text.Trim().Length) + CORRPDEJ1.ID_DEJ_RES_TXT[7].Text.Trim(); 
							pszHeaderSS = new String(' ', 180); 
							pszTitulo = "NUMERO";  
							iLen = 6; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 3, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "EMPRESA";  
							iLen = 25; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 10, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "CRED. TOT.";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 37, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "CRED. ACUM.";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 58, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "FEC. VEN.";  
							iLen = 12; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 79, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "#TARJ";  
							iLen = 7; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 94, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "#TRANS";  
							iLen = 7; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 103, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "COMPRAS";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 113, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "DISP.EFVO.";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 133, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SALD. VENC.";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 154, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							
							
							 
							//      pszHeaderSS = Space$(4) + "NUMERO" + Space(14) + "EMPRESA" + Space(24) + "# TARJETAS" + Space(3) + "# TRANSAC" + Space(4) + "COMPRAS" + Space(6) + "DISP. EN EFVO." + Space(2) + "SALDOS VENCIDOS" 
							 
							break;
						case CORCONST.INT_ACT_EMA :
                            CORRPEM2 CORRPEM21 = (CORRPEM2)fForm;
                            pszCadena1 = new String(' ', 2) + CORRPEM21.ID_DAT_DEM_TXT[0].Text.Trim() + new String(' ', 47 - CORRPEM21.ID_DAT_DEM_TXT[0].Text.Trim().Length) + CORRPEM21.ID_DAT_ETI_TXT[0].Text.Trim() + new String(' ', 25 - CORRPEM21.ID_DAT_ETI_TXT[0].Text.Trim().Length) + new String(' ', 18 - CORRPEM21.ID_DAT_RES_TXT[0].Text.Trim().Length) + CORRPEM21.ID_DAT_RES_TXT[0].Text.Trim();
                            pszCadena2 = new String(' ', 2) + CORRPEM21.ID_DAT_DEM_TXT[1].Text.Trim() + new String(' ', 47 - CORRPEM21.ID_DAT_DEM_TXT[1].Text.Trim().Length) + CORRPEM21.ID_DAT_ETI_TXT[1].Text.Trim() + new String(' ', 25 - CORRPEM21.ID_DAT_ETI_TXT[1].Text.Trim().Length) + new String(' ', 18 - CORRPEM21.ID_DAT_RES_TXT[1].Text.Trim().Length) + CORRPEM21.ID_DAT_RES_TXT[1].Text.Trim();
                            pszCadena3 = new String(' ', 2) + CORRPEM21.ID_DAT_DEM_TXT[2].Text.Trim() + new String(' ', 47 - CORRPEM21.ID_DAT_DEM_TXT[2].Text.Trim().Length) + CORRPEM21.ID_DAT_ETI_TXT[2].Text.Trim() + new String(' ', 25 - CORRPEM21.ID_DAT_ETI_TXT[2].Text.Trim().Length) + new String(' ', 18 - CORRPEM21.ID_DAT_RES_TXT[2].Text.Trim().Length) + CORRPEM21.ID_DAT_RES_TXT[2].Text.Trim();
                            pszCadena4 = new String(' ', 2) + CORRPEM21.ID_DAT_DEM_TXT[3].Text.Trim() + new String(' ', 47 - CORRPEM21.ID_DAT_DEM_TXT[3].Text.Trim().Length) + CORRPEM21.ID_DAT_ETI_TXT[3].Text.Trim() + new String(' ', 25 - CORRPEM21.ID_DAT_ETI_TXT[3].Text.Trim().Length) + new String(' ', 18 - CORRPEM21.ID_DAT_RES_TXT[3].Text.Trim().Length) + CORRPEM21.ID_DAT_RES_TXT[3].Text.Trim();
                            pszCadena5 = new String(' ', 2) + CORRPEM21.ID_DAT_DEM_TXT[4].Text.Trim() + new String(' ', 47 - CORRPEM21.ID_DAT_DEM_TXT[4].Text.Trim().Length) + CORRPEM21.ID_DAT_ETI_TXT[4].Text.Trim() + new String(' ', 25 - CORRPEM21.ID_DAT_ETI_TXT[4].Text.Trim().Length) + new String(' ', 18 - CORRPEM21.ID_DAT_RES_TXT[4].Text.Trim().Length) + CORRPEM21.ID_DAT_RES_TXT[4].Text.Trim();
                            pszCadena6 = new String(' ', 49) + CORRPEM21.ID_DAT_ETI_TXT[5].Text.Trim() + new String(' ', 22 - CORRPEM21.ID_DAT_ETI_TXT[5].Text.Trim().Length) + new String(' ', 21 - CORRPEM21.ID_DAT_RES_TXT[5].Text.Trim().Length) + CORRPEM21.ID_DAT_RES_TXT[5].Text.Trim();
                            pszCadena7 = new String(' ', 49) + CORRPEM21.ID_DAT_ETI_TXT[6].Text.Trim() + new String(' ', 22 - CORRPEM21.ID_DAT_ETI_TXT[6].Text.Trim().Length) + new String(' ', 21 - CORRPEM21.ID_DAT_RES_TXT[6].Text.Trim().Length) + CORRPEM21.ID_DAT_RES_TXT[6].Text.Trim();
                            pszCadena8 = new String(' ', 49) + CORRPEM21.ID_DAT_ETI_TXT[7].Text.Trim() + new String(' ', 22 - CORRPEM21.ID_DAT_ETI_TXT[7].Text.Trim().Length) + new String(' ', 21 - CORRPEM21.ID_DAT_RES_TXT[7].Text.Trim().Length) + CORRPEM21.ID_DAT_RES_TXT[7].Text.Trim(); 
							pszHeaderSS = new String(' ', 180); 
							pszTitulo = "No.";  
							iLen = 5; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 2, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "EMPRESA";  
							iLen = 25; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 8, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "TARJ";  
							iLen = 4; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 34, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "ACT.";  
							iLen = 4; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 39, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "FACTURACION";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 44, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "PROM.TARJ.";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 63, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "1M.V.";  
							iLen = 4; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 82, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SDO. 1M.V.";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 87, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "2M.V.";  
							iLen = 4; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 106, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SDO. 2M.V.";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 111, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "3M.V.";  
							iLen = 4; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 130, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SDO. 3M.V.";  
							iLen = 18; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 134, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							pszTitulo = "SALDOS VENC.";  
							iLen = 19; 
							pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 153, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2)); 
							 
							break;
						case CORCONST.INT_ACT_REN :  //rentabilidad 
                            CORMNREN CORMNREN1 = (CORMNREN)fForm;
							pszCadena1 = new String(' ', 92); 
							pszCadena5 = new String(' ', 92); 
							pszCadena6 = new String(' ', 92); 
							 
							pszCadena2 = new String(' ', 92); 
							pszCadena2 = StringsHelper.MidAssignment(pszCadena2, 3, new String(' ', Convert.ToInt32((92 - CORMNREN1.lblTitulo.Text.Trim().Length) / 2d)) + CORMNREN1.lblTitulo.Text.Trim()); 	 
							pszCadena4 = new String(' ', 92); 
							pszCadena4 = StringsHelper.MidAssignment(pszCadena4, 3, new String(' ', Convert.ToInt32((92 - CORMNREN1.lblTituloEmp.Text.Trim().Length) / 2d)) + CORMNREN1.lblTituloEmp.Text.Trim()); 
							pszCadena6 = new String(' ', 92); 
							if (CORMNREN1.lblRenPro.Visible)
							{
								pszCadena6 = StringsHelper.MidAssignment(pszCadena6, 50, CORMNREN1.lblRenPro.Text.Trim());
								pszCadena6 = StringsHelper.MidAssignment(pszCadena6, 72, new String(' ', 20 - CORMNREN1.lblRenPromedio.Text.Trim().Length) + CORMNREN1.lblRenPromedio.Text.Trim());
							} 
							pszCadena7 = new String(' ', 92); 
							pszCadena7 = StringsHelper.MidAssignment(pszCadena7, 3, CORMNREN1.lblFecha.Text.Trim()); 
							pszCadena7 = StringsHelper.MidAssignment(pszCadena7, 20, CORMNREN1.lblFechaRes.Text.Trim()); 
							pszCadena7 = StringsHelper.MidAssignment(pszCadena7, 50, CORMNREN1.lblRentaMin.Text.Trim()); 
							pszCadena7 = StringsHelper.MidAssignment(pszCadena7, 72, new String(' ', 20 - CORMNREN1.lblMinResp.Text.Trim().Length) + CORMNREN1.lblMinResp.Text.Trim()); 
							pszCadena8 = new String(' ', 92); 
							if (CORMNREN1.lblFecFinR.Visible)
							{
								pszCadena8 = StringsHelper.MidAssignment(pszCadena8, 3, CORMNREN1.lblFecFin.Text.Trim());
								pszCadena8 = StringsHelper.MidAssignment(pszCadena8, 20, CORMNREN1.lblFecFinR.Text.Trim());
							} 
							pszCadena8 = StringsHelper.MidAssignment(pszCadena8, 50, CORMNREN1.lblRentaMax.Text.Trim()); 
							pszCadena8 = StringsHelper.MidAssignment(pszCadena8, 72, new String(' ', 20 - CORMNREN1.lblMaxResp.Text.Trim().Length) + CORMNREN1.lblMaxResp.Text.Trim()); 
							pszHeaderSS = new String(' ', 180); 
							if (CORCTREN.DefInstance.Tag.ToString() == "Detalle" || CORCTREN.DefInstance.Tag.ToString() == "Detalle_Rango")
							{
								pszTitulo = " No. Cuenta";
								iLen = 18;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 2, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "Nombre";
								iLen = 10;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 22, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "INGRESOS";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 70, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "EGRESOS";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 95, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "TOTAL DE RENTABILIDAD";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 125, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								
								if (CORCTREN.DefInstance.Tag.ToString() == "Detalle_Rango")
								{
									pszTitulo = "   MES";
									iLen = 20;
									pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 148, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								}
								
							} else if (CORMNREN.DefInstance.sprRepRenta.MaxCols != 7) { 
								pszTitulo = "No.";
								iLen = 5;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 2, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "EMPRESA";
								iLen = 45;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 9, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "Grupo";
								iLen = 30;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 58, new String(' ', 3) + pszTitulo);
								pszTitulo = "INGRESOS";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 92, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "EGRESOS";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 112, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "TOTAL DE RENTABILIDAD";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 142, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
							} else
							{
								pszTitulo = "No.";
								iLen = 8;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 2, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "EMPRESA";
								iLen = 45;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 10, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "INGRESOS";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 50, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "EGRESOS";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 85, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "TOTAL DE RENTABILIDAD";
								iLen = 25;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 115, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
								pszTitulo = "MES";
								iLen = 20;
								pszHeaderSS = StringsHelper.MidAssignment(pszHeaderSS, 145, new String(' ', (iLen - pszTitulo.Length) / 2) + pszTitulo + new String(' ', (iLen - pszTitulo.Length) / 2));
							} 
							 
							break;
					}
					
					switch(CORCONST.INT_ACT_CEJ)
					{
						//Case X
						
						default:
							if (CORVAR.igblFormaActiva != CORCONST.INT_ACT_REN)
							{
								pszCadena1 = pszCadena1 + new String(' ', 8) + "    Fecha:    " + StringsHelper.Format(DateAndTime.Day(DateTime.Now), "00") + " " + Strings.Mid(Obten_Mes((DateTime.Now.Month * 100) + 1), 4, 3) + " " + DateTime.Now.Year.ToString();
								//10.01.2002 Obtener el día de corte
								pszCadena2 = pszCadena2 + new String(' ', 8) + "    Corte:    " + Strings.Mid(Obten_Mes(CORVAR.igblMesCorte), 1, 6) + " " + CORVAR.igblAñoCorte.ToString();
								pszCadena3 = pszCadena3 + new String(' ', 8) + "Lím. Pago:    " + Strings.Mid(Obten_Mes(iFechaPago), 1, 6) + " " + DateTime.FromOADate(dFechaPago).Year.ToString();
							} 
							break;
					}
					
					switch(CORVAR.igblFormaActiva)
					{
						case CORCONST.INT_ACT_DAT : 
							pszTitRep = fForm.Text + new String(' ', 20) + "Cuenta : " + CORRPDAT.DefInstance.ID_DAT_NUM_TXT[0].Text; 
							break;
						case CORCONST.INT_ACT_CEJ :
                            CORRPCEJ CORRPCEJ1 = (CORRPCEJ)fForm;
							pszFecha = Strings.Mid(CORRPCEJ1.ID_CEJ_FEC_CRE_EB.Text, 4, 2) + Strings.Mid(CORRPCEJ1.ID_CEJ_FEC_CRE_EB.Text, 1, 2); 
							pszFechaAño = Strings.Mid(CORRPCEJ1.ID_CEJ_FEC_CRE_EB.Text, 7, 4); 
							pszTitRep = fForm.Text + new String(' ', 20) + "Cuenta : " + CORRPCEJ.DefInstance.ID_DAT_NUM_TXT[0].Text; 
							if (pszFecha != CORVB.NULL_STRING)
							{
								pszCadena6 = pszCadena6 + new String(' ', 3) + " Venc. Crédito:    " + Strings.Mid(Obten_Mes(Convert.ToInt32(Conversion.Val(pszFecha))), 1, 6) + " " + Conversion.Val(pszFechaAño).ToString();
							} else
							{
								pszCadena6 = pszCadena6 + new String(' ', 3) + " Venc. Crédito:    ";
							} 
							pszCadena7 = pszCadena7 + new String(' ', 2) + "Créd. Acumulado: " + new String(' ', 14 - CORRPCEJ1.ID_CEJ_CRE_ACU_EB.Text.Trim().Length) + CORRPCEJ1.ID_CEJ_CRE_ACU_EB.Text.Trim(); 
                            pszCadena8 = pszCadena8 + new String(' ', 3) + "Créd. Otorgado: " + new String(' ', 14 - CORRPCEJ1.ID_CEJ_CRE_EB.Text.Trim().Length) + CORRPCEJ1.ID_CEJ_CRE_EB.Text.Trim(); 
							break;
						case CORCONST.INT_ACT_CGR :
                            CORRPCGR CORRPCGR1 = (CORRPCGR)fForm;
							pszTitRep = new String(' ', 45) + fForm.Text; 
							pszFecha = Strings.Mid(CORRPCGR1.ID_CGR_FEC_CRED_LBL.Text, 4, 2) + Strings.Mid(CORRPCGR1.ID_CGR_FEC_CRED_LBL.Text, 1, 2); 
							pszFechaAño = Strings.Mid(CORRPCGR1.ID_CGR_FEC_CRED_LBL.Text, 7, 4); 
							if (pszFecha != CORVB.NULL_STRING)
							{
								pszCadena6 = pszCadena6 + new String(' ', 3) + " Venc. Crédito:    " + Strings.Mid(Obten_Mes(Convert.ToInt32(Conversion.Val(pszFecha))), 1, 6) + " " + Conversion.Val(pszFechaAño).ToString();
							} else
							{
								pszCadena6 = pszCadena6 + new String(' ', 3) + " Venc. Crédito:    ";
							} 
							pszCadena7 = pszCadena7 + new String(' ', 2) + "Créd. Otorgado: " + new String(' ', 14 - CORRPCGR1.ID_CGR_CRE_TOT_LBL.Text.Trim().Length) + CORRPCGR1.ID_CGR_CRE_TOT_LBL.Text.Trim(); 
							pszCadena8 = pszCadena8 + new String(' ', 3) + "Créd. Acumulado: " + new String(' ', 14 - CORRPCGR1.ID_CGR_CRE_ACU_LBL.Text.Trim().Length) + CORRPCGR1.ID_CGR_CRE_ACU_LBL.Text.Trim(); 
							 
							break;
						default:
							pszTitRep = fForm.Text; 
							break;
					}
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
		}
		
		static public void  Obten_Encabezados( Form fForm,  int ipPrefijo,  int ipBanco)
		{
			Obten_Encabezados(fForm, ipPrefijo, ipBanco, 0);
		}
		
		static public void  Obten_Encabezados( Form fForm,  int ipPrefijo)
		{
			Obten_Encabezados(fForm, ipPrefijo, 0, 0);
		}
		
		static public void  Obten_Encabezados( Form fForm)
		{
			Obten_Encabezados(fForm, 0, 0, 0);
		}
		
		static public string Obten_Mes( int iFecha)
		{
			
			
			string pszMes = Strings.Mid(StringsHelper.Format(iFecha, "0000"), 1, 2);
			string pszDia = Strings.Mid(StringsHelper.Format(iFecha, "0000"), 3, 2);
			string pszMesTxt = CORVB.NULL_STRING;
            //AIS-119 NGONZALEZ
			int switchVar = Convert.ToInt32(pszMes);
			switch(switchVar)
			{
				case 1 :  
					pszMesTxt = "Enero"; 
					break;
				case 2 :  
					pszMesTxt = "Febrero"; 
					break;
				case 3 :  
					pszMesTxt = "Marzo"; 
					break;
				case 4 :  
					pszMesTxt = "Abril"; 
					break;
				case 5 :  
					pszMesTxt = "Mayo"; 
					break;
				case 6 :  
					pszMesTxt = "Junio"; 
					break;
				case 7 :  
					pszMesTxt = "Julio"; 
					break;
				case 8 :  
					pszMesTxt = "Agosto"; 
					break;
				case 9 :  
					pszMesTxt = "Septiembre"; 
					break;
				case 10 :  
					pszMesTxt = "Octubre"; 
					break;
				case 11 :  
					pszMesTxt = "Noviembre"; 
					break;
				case 12 :  
					pszMesTxt = "Diciembre"; 
					break;
			}
			
			if (Conversion.Val(pszDia) > CORVB.NULL_INTEGER && Conversion.Val(pszMes) > CORVB.NULL_INTEGER)
			{
				return pszDia + " " + pszMesTxt;
			} else
			{
				return "";
			}
			
		}
		
		static public void  Obten_Meses( Form fForm, ref  ComboBox cControl)
		{
			
			int hConexion = 0;
			int hBufMeses = 0;
			int iMesDia = 0;
			string pszMes = String.Empty;
			int iTempErr = 0;
			int iRegs = 0;
			int iMesTemp = 0;
			int iAñoTemp = 0;
			int iDiaTemp = 0;
			string pszSentencia = String.Empty;
			int iCont = 0;
			int lAñoMesDia = 0;
			int iAñoMesDia = 0;
			
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					
					Cursor.Current = Cursors.WaitCursor;
					
					CORVAR.igblErr = CORCONST.OK;
					int iIndice = CORVB.NULL_INTEGER;
					
					int iMesActual = StringsHelper.IntValue(DateTime.Now.ToString("MM"));
					int iAñoActual = StringsHelper.IntValue(DateTime.Now.ToString("yyyy"));
					
					CORVAR.pszgblsql = "select hih_corte_md,hih_corte_a from " + CORBD.DB_SYB_MES + " order by hih_corte_md";
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							iMesDia = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							iAñoMesDia = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
							if (iMesDia < CORVB.NULL_INTEGER)
							{
								Cursor.Current = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								Interaction.MsgBox("No se obtuvieron meses de operación válidos de la tabla del histórico, consulte a su administrador de la base de datos.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
								//AIS-1182 NGONZALEZ
								CORVAR.igblErr = API.USER.PostMessage(fForm.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
							} else
							{
								if (iMesDia > CORVB.NULL_INTEGER)
								{
									CORVAR.dArrMesAño = ArraysHelper.RedimPreserve<double[]>(CORVAR.dArrMesAño, new int[]{iIndice + 1});
									iMesTemp = Convert.ToInt32(Conversion.Val(StringsHelper.Format(iMesDia, "0000").Substring(0, Math.Min(StringsHelper.Format(iMesDia, "0000").Length, 2))));
									iDiaTemp = Convert.ToInt32(Conversion.Val(StringsHelper.Format(iMesDia, "0000").Substring(StringsHelper.Format(iMesDia, "0000").Length - Math.Min(StringsHelper.Format(iMesDia, "0000").Length, 2))));
									iAñoTemp = iAñoMesDia;
									CORVAR.dArrMesAño[iIndice] = Convert.ToDouble(DateAndTime.DateSerial(iAñoTemp, iMesTemp, iDiaTemp).ToOADate());
									iIndice++;
								}
							}
						};
						Inserta_Meses(cControl);
					}
					
					if (cControl.Items.Count != 0)
					{
						cControl.SelectedIndex = CORVB.NULL_INTEGER;
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					Cursor.Current = Cursors.Default;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
		}
		
		static public void  Obten_Paths_Globales()
		{
			
			string pszSeccion = String.Empty;


            //SE agregan las siguientes líneas para leer parámetros del RAGISTRY del WINDOWS
            
            CORVAR.pszgblPathFirmas = mdlParametros.valorRegistro(2, "SOFTWARE\\C430_001\\TarjetaCorporativa\\Rutas", "Firmas").Trim();
            CORVAR.pszgblPathRepEmpresas = mdlParametros.valorRegistro(2, "SOFTWARE\\C430_001\\TarjetaCorporativa\\Rutas", "ReportesEmp").Trim();
            CORVAR.pszgblPathCorpo = mdlParametros.valorRegistro(2, "SOFTWARE\\C430_001\\TarjetaCorporativa\\Rutas", "ReportesCorp").Trim();
            CORVAR.pszgblPathRepCorporativo=CORVAR.pszgblPathCorpo;
            CORVAR.pszgblPathEXCEL = mdlParametros.valorRegistro(2, "SOFTWARE\\C430_001\\TarjetaCorporativa\\Rutas", "Excel").Trim();
            string pszIva = mdlParametros.valorRegistro(2, "SOFTWARE\\C430_001\\TarjetaCorporativa\\Parametros", "Iva").Trim();
            CORVAR.dgblIva = Conversion.Val(pszIva) / 100;  //cuando se lee el valor Iva del Registry de Windows se garantiza que tenga valor y que no sea blanco
            /*			//Obtiene el Servidor de Corporativa
			string pszDataSource = CORPROC2.Obten_Dato_Ini("Corporativa", "Servidor");
			if (pszDataSource == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable del Servidor en el Corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//Obtiene la direccion del DataSource
			string pszValor = CORPROC2.Obten_Dato_Ini("Corporativa", "DataSource");
			if (pszValor == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable de la Dirección del DataSource en el Corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			
			
			//Escribe el DataSource en el achivo Win.ini para hacer el acceso al servidor
            //AIS-1182 NGONZALEZ
            StringBuilder str = new StringBuilder("SQLSERVER");
            StringBuilder str1 = new StringBuilder(pszDataSource);
            StringBuilder str2 = new StringBuilder(pszValor);
            CORVAR.igblErr = API.KERNEL.WriteProfileString(str, str1, str2);
            */

            /*

			//Directorio del Sistema de Corporativa
			CORVAR.pszgblPathCorpo = CORPROC2.Obten_Dato_Ini("Corporativa", "Corbnx");
			if (CORVAR.pszgblPathCorpo == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//Directorio de Firmas
			CORVAR.pszgblPathFirmas = CORPROC2.Obten_Dato_Ini("Corporativa", "Firmas");
			if (CORVAR.pszgblPathFirmas == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontraron las variables de inicialización dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el erorr.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//Directorio de Reportes de Empresas
			CORVAR.pszgblPathRepEmpresas = CORPROC2.Obten_Dato_Ini("Corporativa", "ReportesEmp");
			if (CORVAR.pszgblPathRepEmpresas == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable de Reportes de Empresas dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			CORVAR.pszgblPathRepCorporativo = CORPROC2.Obten_Dato_Ini("Corporativa", "ReportesCorp");
			if (CORVAR.pszgblPathRepCorporativo == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable de Reportes de Corporativos dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//obtiene el valor del directorio de reportes de Crystal report
			CORVAR.pszgblPathRepCrystal = CORPROC2.Obten_Dato_Ini("Corporativa", "ReportesCR");
			if (CORVAR.pszgblPathRepCrystal == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable de Reportes de Crystal dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			
			//Valor del IVA
			string pszIva = CORPROC2.Obten_Dato_Ini("Corporativa", "Iva");
			if (pszIva == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontraron la variable del valor del IVA Corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			} else
			{
				CORVAR.dgblIva = Conversion.Val(pszIva) / 100;
			}
			
			//Obtiene el Servidor de Corporativa
			string pszDataSource = CORPROC2.Obten_Dato_Ini("Corporativa", "Servidor");
			if (pszDataSource == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable del Servidor en el Corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//Obtiene la direccion del DataSource
			string pszValor = CORPROC2.Obten_Dato_Ini("Corporativa", "DataSource");
			if (pszValor == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable de la Dirección del DataSource en el Corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			
			
			//Escribe el DataSource en el achivo Win.ini para hacer el acceso al servidor
            //AIS-1182 NGONZALEZ
            StringBuilder str = new StringBuilder("SQLSERVER");
            StringBuilder str1 = new StringBuilder(pszDataSource);
            StringBuilder str2 = new StringBuilder(pszValor);
            CORVAR.igblErr = API.KERNEL.WriteProfileString(str, str1, str2);
			
			
			//obtiene el valor del directorio deL COMDRIVE
			CORVAR.pszgblPathComDrive = CORPROC2.Obten_Dato_Ini("Corporativa", "ComDrive");
			if (CORVAR.pszgblPathComDrive == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable del ComDrive dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//obtiene el valor del directorio deL WORD
			CORVAR.pszgblPathWord = CORPROC2.Obten_Dato_Ini("Corporativa", "Word");
			if (CORVAR.pszgblPathWord == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable del Word dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//obtiene el valor del directorio deL WORD de domicilio
			CORVAR.pszgblPathWordDom = CORPROC2.Obten_Dato_Ini("Corporativa", "WordDom");
			if (CORVAR.pszgblPathWordDom == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable del WordDom dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//obtiene el valor del directorio deL WORD de credito
			CORVAR.pszgblPathWordCred = CORPROC2.Obten_Dato_Ini("Corporativa", "WordCred");
			if (CORVAR.pszgblPathWordCred == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable del WordCred dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			//obtiene el valor del directorio de excel
			CORVAR.pszgblPathEXCEL = CORPROC2.Obten_Dato_Ini("Corporativa", "EXCEL");
			if (CORVAR.pszgblPathEXCEL == CORVB.NULL_STRING)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró la variable de Excel dentro del Archivo corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
				return;
			}
			
			*/
			
			
		}
		
		static public string Obtiene_Path( string pszPath)
		{
			
			if (pszPath != CORVB.NULL_STRING)
			{
				if (Strings.Mid(pszPath, pszPath.Length) == "\\")
				{
					return pszPath + "Excel";
				} else
				{
					return pszPath + "\\Excel";
				}
			} else
			{
				return "c:\\MSOFFICE\\Excel\\Excel";
			}
			
		}
		
		static public void  Obtiene_Status( int lNumEmp, ref  int lCtasAct, ref  int lCtasCong,  int htEMPConexion)
		{
			
			string pszSQL = String.Empty;
			int hBufStatus = 0;
			int iTempErr = 0;
			
			CORVAR.pszgblsql = "select count(ths_situacion_cta) from " + CORBD.DB_SYB_THS + " where ths_situacion_cta = ''  and emp_num=" + lNumEmp.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
			if (CORPROC2.Obtiene_Registros() != 0)
			{
				lCtasAct = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
				CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				CORVAR.pszgblsql = "select count(ths_situacion_cta) from " + CORBD.DB_SYB_THS + " where ths_situacion_cta = 'W' and emp_num=" + lNumEmp.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
				CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				if (CORPROC2.Obtiene_Registros() != 0)
				{
					lCtasCong = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				} else
				{
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				}
			} else
			{
				CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			}
			
		}
		
		//****************************************************************************
		//**                                                                        **
		//**       Descripción: Opera la baja de la empresa señalada en el   -      **
		//**                    listBox de un grupo determinado                     **
		//**                                                                        **
		//**       Declaración: Funcion Opera_Baja_Empresa() as integer             **
		//**                                                                        **
		//**       Paso de parámetros: pszempresa - La empresa a dar de baja        **
		//**                                                                        **
		//**       Valor de Regreso: El número de registros modificados             **
		//**                                                                        **
		//**       Variables globales que modifica :                                **
		//**           Al Proyecto :                                                **
		//**           A la forma : iErr                                            **
		//**                                                                        **
		//**       Ultima modificacion: 030594                                      **
		//**                                                                        **
		//****************************************************************************'
		static public int Opera_BajaEmpresa( int lNumEmpresa, ref  int iErr)
		{
			
			int result = 0;
			string pszSentencia = String.Empty;
			int hBufEmpresa = 0; //Apuntador a la sentencia SQL
			int htEMPConexion = 0; //La conexion a la base de datos
			int iNumEmpresa = 0; //La empresa a dar de Baja
			int iTempErr = 0; //Control local
			
			Cursor.Current = Cursors.WaitCursor;
			iErr = CORCONST.OK;
			int iRegsModif = CORVB.NULL_INTEGER; //Los registros modificados
			
			
			CORVAR.pszgblsql = "delete from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and emp_num =" + lNumEmpresa.ToString();
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and (select count(*) from " + CORBD.DB_SYB_EJE + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and emp_num = " + lNumEmpresa.ToString() + ")  = 0";
			
			if (CORPROC2.Modifica_Registro() != 0)
			{
				CORVAR.pszgblsql = "delete from MTCBRP01 where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and emp_num =" + lNumEmpresa.ToString();
				if (CORPROC2.Modifica_Registro() != 0)
				{
					Cursor.Current = Cursors.Default;
				}
				Cursor.Current = Cursors.Default;
				result = 1;
			} else
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("No se pudo realizar la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = 0;
			}
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			
			
			Cursor.Current = Cursors.Default;
			
			return result;
		}
		
		//****************************************************************************
		//**                                                                        **
		//**       Descripción: Opera la baja del Catálogo de Grupos Corpora -      **
		//**                    tivos al Grupos señalado en el List Box             **
		//**                                                                        **
		//**       Declaración: function Opera_BajaGrupo                            **
		//**                                                                        **
		//**       Paso de parámetros: Byval pszGrupo : El grupo a dar de baja      **
		//**                                                                        **
		//**       Valor de Regreso: El número de registros modificados             **
		//**                                                                        **
		//**       Variables globales que modifica :                                **
		//**           Al Proyecto :                                                **
		//**           A la forma : iErr                                            **
		//**                                                                        **
		//**       Ultima modificacion: 030594                                      **
		//**                                                                        **
		//****************************************************************************
		static public int Opera_BajaGrupo( int iNumGrupo, ref  int iErr)
		{
			
			int result = 0;
			int hBufGrupo = 0; //El apuntador a la sentencia SQL
			int htEMPConexion = 0; //La conexión a la base de datos
			int iTempErr = 0; //Control local
			string pszSentencia = String.Empty;
			
			Cursor.Current = Cursors.WaitCursor;
			iErr = CORCONST.OK;
			int iRegsModif = CORVB.NULL_INTEGER; //Los registros modificados
			
			
			CORVAR.pszgblsql = "delete from " + CORBD.DB_SYB_COR + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + iNumGrupo.ToString();
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and (select count(*) from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num = " + iNumGrupo.ToString() + ") = 0";
			
			
			if (CORPROC2.Modifica_Registro() != 0)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("Se realizó con éxito la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = 1;
			} else
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("No se pudo realizar la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = 0;
			}
			
			
			
			Cursor.Current = Cursors.Default;
			
			return result;
		}
		
		
		static public string Valida_Comilla( string pszCadena)
		{
			
			
			StringBuilder pszCadenaValida = new StringBuilder();
			pszCadenaValida.Append(CORVB.NULL_STRING);
			pszCadena = pszCadena.Trim();
			
			if (pszCadena.Length != 0)
			{
				for (int iCont = 1; iCont <= pszCadena.Length; iCont++)
				{
					if (Strings.Mid(pszCadena, iCont, 1) == "'")
					{
						pszCadenaValida.Append(new String(' ', 1));
					} else
					{
						pszCadenaValida.Append(Strings.Mid(pszCadena, iCont, 1));
					}
				}
			}
			
			return pszCadenaValida.ToString();
			
		}
		
		static public string Valida_Path()
		{
			
			string result = String.Empty;
			result = (true).ToString();
			Cursor.Current = Cursors.WaitCursor;
            //AIS-525 NGONZALEZ
            if (!System.IO.Directory.Exists(CORVAR.pszgblPathCorpo))
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("No existe el directorio " + CORVAR.pszgblPathCorpo + " No puede continuar la aplicación. ", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = (false).ToString();
			}
            //AIS-525 NGONZALEZ
            if (!System.IO.Directory.Exists(CORVAR.pszgblPathFirmas))
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("No existe el directorio " + CORVAR.pszgblPathFirmas + " No puede continuar la aplicación. ", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = (false).ToString();
			}
			//AIS-525 NGONZALEZ
			if (!System.IO.Directory.Exists(CORVAR.pszgblPathRepEmpresas))
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("No existe el directorio " + CORVAR.pszgblPathRepEmpresas + " No puede continuar la aplicación. ", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = (false).ToString();
			}

            //AIS-525 NGONZALEZ
            if (!System.IO.Directory.Exists(CORVAR.pszgblPathRepCorporativo))
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("No existe el directorio " + CORVAR.pszgblPathRepCorporativo + " No puede continuar la aplicación. ", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = (false).ToString();
			}
            //AIS-525 NGONZALEZ
            /*if (!System.IO.Directory.Exists(CORVAR.pszgblPathRepCrystal))
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("No existe el directorio " + CORVAR.pszgblPathRepCrystal + " No puede continuar la aplicación. ", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = (false).ToString();
			}*/
			
			
			return result;
		}
		
		
		static public void  Encripta_Sybase( string varPass)
		{
			//**************************************************     FSWBMX
			//Fábrica de Software Banamex.                           FSWBMX
			//rutina para encriptar password de usuario antes de     FSWBMX
			//accesar tablas de Sybase                               FSWBMX
			//**************************************************     FSWBMX
			FixedLengthString varEncrypt = new FixedLengthString(50);
			double varTmp = 0;
			for (int I = 1; I <= varPass.Length; I++)
			{
				varTmp = (int) Strings.Mid(varPass, I, 1)[0];
				varEncrypt.Value = Conversion.Str((((varTmp * 1.5d) / 2.1113d) * 1.111119d) * I);
			}
			MessageBox.Show("recibí [" + varPass + "] encripto a: >>" + varEncrypt.Value + "<<", Application.ProductName);
		}
		
		static public byte Opera_BajaGrupo_par( int iNumGrupo,  object ipref_fsw,  object ibanco_fsw, ref  int iErr)
		{
			
			byte result = 0;
			int hBufGrupo = 0; //El apuntador a la sentencia SQL
			int htEMPConexion = 0; //La conexión a la base de datos
			int iTempErr = 0; //Control local
			string pszSentencia = String.Empty;
			
			Cursor.Current = Cursors.WaitCursor;
			iErr = CORCONST.OK;
			int iRegsModif = CORVB.NULL_INTEGER; //Los registros modificados
			
			
			//UPGRADE_WARNING: (1068) ibanco_fsw of type Variant is being forced to Scalar.
			//UPGRADE_WARNING: (1068) ipref_fsw of type Variant is being forced to Scalar.
			CORVAR.pszgblsql = "delete from " + CORBD.DB_SYB_COR + " where eje_prefijo=" + ipref_fsw.ToString() + " and gpo_banco=" + ibanco_fsw.ToString() + " and gpo_num =" + iNumGrupo.ToString();
			//UPGRADE_WARNING: (1068) ibanco_fsw of type Variant is being forced to Scalar.
			//UPGRADE_WARNING: (1068) ipref_fsw of type Variant is being forced to Scalar.
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and (select count(*) from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + ipref_fsw.ToString() + " and gpo_banco=" + ibanco_fsw.ToString() + " and gpo_num = " + iNumGrupo.ToString() + ") = 0";
			
			
			if (CORPROC2.Modifica_Registro() != 0)
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("Se realizó con éxito la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = 1;
			} else
			{
				Cursor.Current = Cursors.Default;
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox("No se pudo realizar la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
				result = 0;
			}
			
			Cursor.Current = Cursors.Default;
			
			return result;
		}
		
		
		static public int Calcula_digito_verif(ref  string Cta)
		{
			// Esta funcion recibe en Cta el numero de cuenta de tarjeta de credito, sin
			// digito verificador, es decir, el digito de la extrema derecha, lo calcula
			// y regresa el numero de cuenta incluyendo el digito verificador.
			// Nota.- Cuando el numero de digitos del numero de tarjeta (incluyendo el
			// digito verificador) es impar, el algoritmo inicia multiplicando por 1;
			// cuando es par inicia con 2.
			const string CEROS = "0000000000000000";
			
			int FacIni = 0;
			int FacFin = 0;
			int J = 0;
			int d = 0;
			int s = 0;
			int Suma = 0;
			string aux = String.Empty;
			string NCta = String.Empty;
			
			try
			{
					
					Suma = 0;
					
					if ((Cta.Length % 2) == 0)
					{
						FacIni = 1;
						FacFin = 2;
					} else
					{
						FacIni = 2;
						FacFin = 1;
					}
					
					NCta = Cta;
					Cta = Cta + Strings.Mid(CEROS, 1, 15 - Cta.Length);
					
					for (int I = 1; I <= Cta.Length; I++)
					{
						d = StringsHelper.IntValue(Strings.Mid(Cta, I, 1));
						if ((I % 2) == 0)
						{
							J = FacFin;
						} else
						{
							J = FacIni;
						}
						d *= J;
						if (J == 2)
						{
							aux = Conversion.Str(d);
							if (aux.Length > 2)
							{
								aux = Strings.Mid(aux, 2, 2);
							}
							d = 0;
							for (int k = 1; k <= 2; k++)
							{
								if (Strings.Mid(aux, k, 1) == " ")
								{
									aux = StringsHelper.MidAssignment(aux, k, "0");
								}
								s = StringsHelper.IntValue(Strings.Mid(aux, k, 1));
								d += s;
							}
						} // fin If j = 2
						Suma += d;
					}
					
					s = Suma % 10;
					if (s == 0)
					{
						d = 0;
					} else
					{
						d = 10 - s;
					}
					aux = Conversion.Str(d);
					aux = Strings.Mid(aux, 2, aux.Length - 1);
					
					return Int32.Parse(aux);
				}
			catch (Exception e)
			{

                //AIS-1133 NGONZALEZ
				MessageBox.Show("EN DIGVER_ADITC: " + e.Message.ToString() + ". ", "NEXUS (Digver).", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				
				//  Dim iCont           As Integer
				//  Dim pszValor        As String
				//  Dim iNumVerif       As Integer
				//  ReDim iArrSumas(20) As Integer
				//
				//  pszCuenta = Trim$(pszCuenta)
				//  For iCont = 1 To Len(pszCuenta)
				//    If (iCont Mod 2) = 0 Then
				//      pszValor = Mid$(pszCuenta, iCont, 1)
				//    Else
				//      pszValor = Str$(Val(Mid$(pszCuenta, iCont, 1)) * 2)
				//    End If
				//    If Len(Trim$(pszValor)) > 1 Then
				//      iArrSumas(iCont - 1) = (Val(Mid$(Trim$(pszValor), 1, 1)) + Val(Mid$(Trim$(pszValor), 2, 1)))
				//    Else
				//      iArrSumas(iCont - 1) = Val(pszValor)
				//    End If
				//  Next
				//
				//  For iCont = 0 To 14
				//    iNumVerif = iArrSumas(iCont) + iNumVerif
				//  Next
				//
				//  If Val(Right$(Str$(iNumVerif), 1)) = 0 Then
				//    iNumVerif = NULL_INTEGER
				//  Else
				//    iNumVerif = Abs(Val(Right(Str(iNumVerif), 1)) - 10)
				//  End If
				//  Calcula_digito_verif = iNumVerif
			}
			return 0;
		}
		
		//Function DigVer_Valida_DigVer_cta(ICta As Integer, Cta As String) As Integer
		//' Esta funcion valida el digito verificador del numero de cuenta Cta, de
		//' acuerdo con el tipo de esta, el cual es indicado en ICta. ICta=1 para
		//' tarjeta de credito, ICta=2 para cuenta de cheques, ICta=3 para cuenta de
		//' ahorros, ICta=4 para valores, ICta=5 para numero de negocio afiliado a
		//' BANAMEX o sucursal BANAMEX. Regresa True si el digito verificador es
		//' correcto y False en caso contrario.
		//
		// Dim aux As String
		//
		// On Error GoTo DIGVALDIGCTA
		//
		// aux = Mid$(Cta, 1, Len(Cta) - 1)
		// Select Case ICta
		//  Case 1
		//   aux = Digver_AdiTC(aux)
		//  Case 2
		//   'aux = Digver_AdiChe(aux)
		//  Case 5
		//   'aux = Digver_Adig_Neg_Suc(aux)
		// End Select
		// If Cta = aux Then
		//    DigVer_Valida_DigVer_cta = True
		// Else
		//    DigVer_Valida_DigVer_cta = False
		// End If
		//
		//Exit Function
		//
		//DIGVALDIGCTA:
		//    MsgBox "EN DIGVER_VALIDA_DIGVER_CTA: " & Error$ & ". ", 48, "NEXUS (Digver)."
		//End Function
		//
	}
}