using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.IO; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	class CORPROC2
	{
	
		//---------------------------------------------------------------------------------
		//**                                                                             **
		//**                    CopyRight DDEMESIS 1997                                  **
		//**                    ---------------------------------                        **
		//**                                                                             **
		//**       Módulo:      GENERAL.BAS - Funciones y rutinas del SIPJ.              **
		//**                                                                             **
		//**       Descripción: Funciones y rutinas generales al Siatema.                **
		//**                                                                             **
		//**       Autores:     Carlos León Moreno                                       **
		//**                                                                             **
		//**       Uso:         Sistema Integral de Personal para Jefes                  **
		//**                                                                             **
		//**       Última Fecha de Actualización:                                        **
		//**                    Carlos León Moreno      23 de Julio de 1997              **
		//**                                                                             **
		//---------------------------------------------------------------------------------
		
		public struct tyEjecutivo
		{
			
			public int iPrefijo;
			public int iBanco;
			public int lEmpresa;
			public int lNumero;
			public string pszNombre;
			public string pszCalle;
			public string pszColonia;
			public string pszPoblacion;
			public int iZP;
			public int lCP;
			public string pszTelDom;
			public string pszTelOfi;
			public string pszExt;
			public int iRollOver;
			public int iDigito;
			public double dCredito;
			public string pszRepSta;
			
			public static tyEjecutivo CreateInstance()
			{
					tyEjecutivo result = new tyEjecutivo();
					result.pszNombre = String.Empty;
					result.pszCalle = String.Empty;
					result.pszColonia = String.Empty;
					result.pszPoblacion = String.Empty;
					result.pszTelDom = String.Empty;
					result.pszTelOfi = String.Empty;
					result.pszExt = String.Empty;
					result.pszRepSta = String.Empty;
					return result;
			}
		}
		
		
		
		
		//****************************************************************************
		//**                                                                        **
		//**       Descripción:                                                     **
		//**                   Genera los archivos para cambios masivos             **
		//**                   si existe el archivo agrega, si no lo crea           **
		//**       Paso de parámetros:Nombre del archivo,identificador de operación,**
		//**                          proceso que lo genera, tipo de archivo        **
		//**                                                                        **
		//**       Valor de Regreso:                                                **
		//**                                                                        **
		//**                                                                        **
		//**       Ultima modificacion: 12oct98                                     **
		//**                                                                        **
		//****************************************************************************'
		static public void  Genera_Achivos_Cambios( string pszNomArchivo, ref  string pszParametroC, ref  string pszProceso,  string pszTipoArch)
		{
			//proceso que genera los archivos de cambios masivos
			int iNumArchivo = 0;
			string pszNombreArchivo = String.Empty;
			string pszDirectorio = String.Empty;
			string pszCadena = String.Empty;
			string pszNomNuevo = String.Empty;
			int iResp = 0;
			string pszFecha = String.Empty;
			string pszAccion = String.Empty;
			int i = 0;
			string pszCad = String.Empty;
			
			try
			{
					
					Cursor.Current = Cursors.WaitCursor;
					
					iNumArchivo = FileSystem.FreeFile();
					
					Information.Err().Number = CORCONST.OK;
					
					//crea el directorio si no existe de cambios masivos
					pszDirectorio = CORVAR.pszgblPathCorpo + "CamMasiv\\";
					
					if (FileSystem.Dir(pszDirectorio, FileAttribute.Directory) == CORVB.NULL_STRING)
					{
						Directory.CreateDirectory(pszDirectorio);
					}
					
					pszNombreArchivo = pszDirectorio + pszNomArchivo;
					
					//verifica si existe el archivo
					pszCadena = FileSystem.Dir(pszNombreArchivo, FileAttribute.Normal);
					
					//si existe el archivo
					if (pszCadena != CORVB.NULL_STRING)
					{
						
						//obtiene la fecha y hora del archivo
						pszFecha = (new FileInfo(pszNombreArchivo)).LastWriteTime.ToString();
						
						//obtiene solo la fecha
						i = (pszFecha.IndexOf(' ') + 1);
						if (i != CORVB.NULL_INTEGER)
						{
							pszCad = Strings.Mid(pszFecha, 1, i - 1);
							pszFecha = pszCad;
						}
						
						//si las fechas son diferentes aplatara al archivo existente
						if (DateTime.Parse(pszFecha) != DateTime.Today)
						{
							FileSystem.FileOpen(iNumArchivo, pszNombreArchivo, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
							pszAccion = "Abre";
						} else
						{
							// si las fechas son iguales abre al archivo para aggregar
							FileSystem.FileOpen(iNumArchivo, pszNombreArchivo, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
							pszAccion = "Agrega";
						}
					} else
					{
						FileSystem.FileOpen(iNumArchivo, pszNombreArchivo, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
						pszAccion = "Abre";
					}
					
					//verifica los errores de apertura
					if (Information.Err().Number != CORCONST.OK)
					{
						Cursor.Current = Cursors.Default;
						switch(Information.Err().Number)
						{
							case CORCTERR.INT_DISCO_LLENO : 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								Interaction.MsgBox(CORSTR.STR_DISCO_LLENO, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
								break;
							case CORCTERR.INT_PERMISO_NEG : 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								Interaction.MsgBox(CORSTR.STR_PERMISO_NEG, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
								break;
							case CORCTERR.INT_UNIDAD_NOLIS : 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								Interaction.MsgBox(CORSTR.STR_UNIDAD_NOLIS, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
								break;
							case CORCTERR.INT_ERR_ACCPATHFILE : 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								Interaction.MsgBox(CORSTR.STR_ERR_ACCPATHFILE, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
								break;
							case CORCONST.INT_NO_PATH : 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								Interaction.MsgBox(CORSTR.STR_NO_PATH, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
								break;
							case CORCONST.INT_NO_MEMORIA : 
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								Interaction.MsgBox(CORSTR.STR_NO_MEMORIA, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
								break;
							default:
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
								Interaction.MsgBox(CORSTR.ERR_ERROR_DESC, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT); 
								break;
						}
						return;
					}
					
					//verifica el tipo de archivo
					if (pszTipoArch == "Excel")
					{
						Genera_Arch_CamMasivos_Excel(iNumArchivo, pszProceso, pszParametroC, ref pszAccion);
					} else
					{
						Lee_Tabla_Cambios_Masivos(iNumArchivo, pszParametroC, pszProceso, pszAccion);
					}
					
					//cierrra el archivo
					FileSystem.FileClose(iNumArchivo);
				}
			catch 
			{
			}
			
			
			switch(Information.Err().Number)
			{
				case 70 : 
					if (pszTipoArch == "Excel")
					{
						MessageBox.Show(" " + Information.Err().Description + ". El archivo se esta utilizando. Cierre Word", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
						//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
						throw new Exception("Migration Exception: 'Resume' not supported");
					} else
					{
						MessageBox.Show(" " + Information.Err().Description + ",vbCritical", Application.ProductName);
					} 
					break;
				case 0 : 
					break;
				default:
					MessageBox.Show(" " + Information.Err().Description, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error); 
					return;
			}
			
		}
		
		
		
		
		//****************************************************************************
		//**                                                                        **
		//**       Descripción:                                                     **
		//**                   Genera los archivos para excel                       **
		//**                   en el procveso de cambios masivos                    **
		//**       Paso de parámetros:No. de arch,proceso que lo genera, identificador**
		//**                          accion(agregar,abrir)                        **
		//**                                                                        **
		//**       Valor de Regreso:                                                **
		//**                                                                        **
		//**                                                                        **
		//**       Ultima modificacion: 12oct98                                     **
		//**                                                                        **
		//****************************************************************************''
		static public void  Genera_Arch_CamMasivos_Excel( int iNumArchivo,  string pszProceso,  string pszParametroC, ref  string pszAccion)
		{
			
			string pszPrefijo = String.Empty;
			string pszBanco = String.Empty;
			string pszEmpresa = String.Empty;
			string pszEje = String.Empty;
			string pszDigito = String.Empty;
			string pszRollOver = String.Empty;
			string pszNombre = String.Empty;
			string pszMensaje = String.Empty;
			string pszNumCuenta = String.Empty;
			StringBuilder pszImprimeCadena = new StringBuilder();
			pszImprimeCadena.Append(String.Empty);
			string pszNomEmp = String.Empty;
			string pszCalle = String.Empty;
			string pszCol = String.Empty;
			string pszPob = String.Empty;
			string pszTelOfi = String.Empty;
			string pszExt = String.Empty;
			string pszTelDom = String.Empty;
			string pszFecha = String.Empty;
			string pszEdo = String.Empty;
			string pszCredito = String.Empty;
			string pszActi = String.Empty;
			string pszCalleEmp = String.Empty;
			string pszColEmp = String.Empty;
			string pszPobEmp = String.Empty;
			string pszCPEmp = String.Empty;
			string pszSueldo = String.Empty;
			int iPos = 0;
			string pszCP = String.Empty;
			
			if (pszProceso == "DomicilioEmp" || pszProceso == "DomicilioT")
			{
				//genera el archivo de registros procesados
				if (pszProceso == "DomicilioEmp")
				{
					CORVAR.pszgblsql = "select eje_prefijo,gpo_banco,emp_num,eje_num,eje_digit,eje_roll_over,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nombre,cam_nombre_emp,cam_calle_emp,cam_col_emp,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_pob_emp, cam_tel_ofi,cam_ext,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_tel_dom,cam_fecha, cam_cp_emp,cam_estado_emp";
				} else
				{
					CORVAR.pszgblsql = "select eje_prefijo,gpo_banco,emp_num,eje_num,eje_digit,eje_roll_over,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nombre,cam_nombre_emp,cam_calle,cam_col,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_pob, cam_tel_ofi,cam_ext,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_tel_dom,cam_fecha,cam_cp";
				}
				CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYS_CAM;
				CORVAR.pszgblsql = CORVAR.pszgblsql + " where cam_estado = '" + pszParametroC + "'";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = '" + pszProceso + "'";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_mensaje = ''";
				
				if (Obtiene_Registros() != 0)
				{
					
					while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
					{
						
						if (pszAccion == "Abre")
						{
							//imprime la cadena del archivo por unica vez
							pszImprimeCadena = new StringBuilder("pszNumCuenta;pszFecha;pszNombre;pszNomEmp;pszCalle;pszCol;pszPob;pszEdo;pszCP;pszTelOfi;pszExt;pszTelDom");
							FileSystem.PrintLine(iNumArchivo, pszImprimeCadena.ToString());
							pszAccion = CORVB.NULL_STRING;
						}
						
						
						pszPrefijo = VBSQL.SqlData(CORVAR.hgblConexion, 1);
						pszBanco = VBSQL.SqlData(CORVAR.hgblConexion, 2);
						pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 3);
						pszEje = VBSQL.SqlData(CORVAR.hgblConexion, 4);
						pszDigito = VBSQL.SqlData(CORVAR.hgblConexion, 5);
						pszRollOver = VBSQL.SqlData(CORVAR.hgblConexion, 6);
						pszNombre = VBSQL.SqlData(CORVAR.hgblConexion, 7);
						pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion, 8);
						pszCalle = VBSQL.SqlData(CORVAR.hgblConexion, 9);
						pszCol = VBSQL.SqlData(CORVAR.hgblConexion, 10);
						pszPob = VBSQL.SqlData(CORVAR.hgblConexion, 11);
						pszTelOfi = VBSQL.SqlData(CORVAR.hgblConexion, 12);
						pszExt = VBSQL.SqlData(CORVAR.hgblConexion, 13);
						pszTelDom = VBSQL.SqlData(CORVAR.hgblConexion, 14);
						pszFecha = VBSQL.SqlData(CORVAR.hgblConexion, 15);
						pszCP = VBSQL.SqlData(CORVAR.hgblConexion, 16);
						
						if (pszProceso == "DomicilioEmp")
						{
							pszEdo = VBSQL.SqlData(CORVAR.hgblConexion, 17);
						}
						
						if (pszProceso == "DomicilioT")
						{
							pszNomEmp = CORVB.NULL_STRING;
						}
						
						//arma el numero de cuenta del ejecutivo
						//EISSA 03-10-2001. Cambio para formateo de número de empresa y número de ejecutivo.
						pszNumCuenta = pszPrefijo + pszBanco + StringsHelper.Format(pszEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(Conversion.Str(pszEje).Trim(), Formato.sMascara(Formato.iTipo.Ejecutivo)) + Conversion.Str(pszRollOver).Trim() + Conversion.Str(pszDigito).Trim();
						//cp
						pszCP = StringsHelper.Format(pszCP, "00000");
						
						System.DateTime TempDate = DateTime.FromOADate(0);
						pszImprimeCadena = new StringBuilder(pszNumCuenta.Trim() + ";" + ((DateTime.TryParse(pszFecha, out TempDate)) ? TempDate.ToString("dd/MM/yyyy"): pszFecha) + ";");
						pszImprimeCadena.Append(pszNombre.Trim() + ";" + pszNomEmp.Trim() + ";");
						pszImprimeCadena.Append(pszCalle.Trim() + ";" + pszCol.Trim() + ";");
						pszImprimeCadena.Append(pszPob.Trim() + ";" + pszEdo.Trim() + ";");
						pszImprimeCadena.Append(pszCP.Trim() + ";" + pszTelOfi.Trim() + ";");
						pszImprimeCadena.Append(pszExt.Trim() + ";" + pszTelDom.Trim());
						
						FileSystem.PrintLine(iNumArchivo, pszImprimeCadena.ToString());
						
					};
				} else
				{
					if (pszAccion == "Abre")
					{
						//imprime la cadena del archivo por unica vez
						pszImprimeCadena = new StringBuilder("pszNumCuenta;pszFecha;pszNombre;pszNomEmp;pszCalle;pszCol;pszPob;pszEdo;pszCP;pszTelOfi;pszExt;pszTelDom");
						FileSystem.PrintLine(iNumArchivo, pszImprimeCadena.ToString());
						pszAccion = CORVB.NULL_STRING;
					}
				}
				
				CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			}
			
			//limite
			if (pszProceso == "Limite")
			{
				//genera el archivo de registros procesados
				CORVAR.pszgblsql = "select eje_prefijo,gpo_banco,emp_num,eje_num,eje_digit,eje_roll_over,";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nombre,cam_nombre_emp,cam_calle,cam_col,";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_pob, cam_tel_ofi,cam_ext,";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_tel_dom,cam_fecha,cam_cred_soli,cam_actividad,cam_calle_emp,";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_col_emp,cam_pob_emp,cam_cp_emp,cam_sueldo";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYS_CAM;
				CORVAR.pszgblsql = CORVAR.pszgblsql + " where cam_estado = '" + pszParametroC + "'";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = '" + pszProceso + "'";
				CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_mensaje = ''";
				
				if (Obtiene_Registros() != 0)
				{
					
					while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
					{
						
						if (pszAccion == "Abre")
						{
							//imprime la cadena del archivo por unica vez
							pszImprimeCadena = new StringBuilder("pszFecha;pszCredito;pszNumCuenta;pszNombre;pszTelDom;pszCalle;pszCol;pszPob;pszCP;");
							pszImprimeCadena.Append("pszNomEmp;pszActi;pszCalleEmp;pszColEmp;pszPobEmp;pszCPEmp;pszTelOfi;pszSueldo");
							
							FileSystem.PrintLine(iNumArchivo, pszImprimeCadena.ToString());
							
							pszAccion = CORVB.NULL_STRING;
						}
						
						//        pszImprimeCadena = Space(337)
						pszPrefijo = VBSQL.SqlData(CORVAR.hgblConexion, 1);
						pszBanco = VBSQL.SqlData(CORVAR.hgblConexion, 2);
						pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 3);
						pszEje = VBSQL.SqlData(CORVAR.hgblConexion, 4);
						pszDigito = VBSQL.SqlData(CORVAR.hgblConexion, 5);
						pszRollOver = VBSQL.SqlData(CORVAR.hgblConexion, 6);
						pszNombre = VBSQL.SqlData(CORVAR.hgblConexion, 7);
						pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion, 8);
						pszCalle = VBSQL.SqlData(CORVAR.hgblConexion, 9);
						pszCol = VBSQL.SqlData(CORVAR.hgblConexion, 10);
						pszPob = VBSQL.SqlData(CORVAR.hgblConexion, 11);
						pszTelOfi = VBSQL.SqlData(CORVAR.hgblConexion, 12);
						pszExt = VBSQL.SqlData(CORVAR.hgblConexion, 13);
						pszTelDom = VBSQL.SqlData(CORVAR.hgblConexion, 14);
						pszFecha = VBSQL.SqlData(CORVAR.hgblConexion, 15);
						pszCredito = VBSQL.SqlData(CORVAR.hgblConexion, 16);
						pszActi = VBSQL.SqlData(CORVAR.hgblConexion, 17);
						pszCalleEmp = VBSQL.SqlData(CORVAR.hgblConexion, 18);
						pszColEmp = VBSQL.SqlData(CORVAR.hgblConexion, 19);
						pszPobEmp = VBSQL.SqlData(CORVAR.hgblConexion, 20);
						pszCPEmp = VBSQL.SqlData(CORVAR.hgblConexion, 21);
						pszSueldo = VBSQL.SqlData(CORVAR.hgblConexion, 22);
						
						//EISSA 03-10-2001. Cambio para formatear el número de empresa y el número de ejecutivo.
						//arma el numero de cuenta del ejecutivo
						pszNumCuenta = pszPrefijo + pszBanco + StringsHelper.Format(pszEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(pszEje.Trim(), Formato.sMascara(Formato.iTipo.Ejecutivo)) + Conversion.Str(pszRollOver).Trim() + Conversion.Str(pszDigito).Trim();
						
						//cp
						pszCP = StringsHelper.Format(pszCP, "00000");
						
						System.DateTime TempDate2 = DateTime.FromOADate(0);
						pszImprimeCadena = new StringBuilder(((DateTime.TryParse(pszFecha, out TempDate2)) ? TempDate2.ToString("dd/MM/yyyy"): pszFecha) + ";" + StringsHelper.Format(pszCredito, "###,###,###,###.00"));
						pszImprimeCadena.Append(";" + pszNumCuenta.Trim() + ";" + pszNombre.Trim());
						pszImprimeCadena.Append(";" + pszTelDom.Trim() + ";" + pszCalle.Trim());
						pszImprimeCadena.Append(";" + pszCol.Trim() + ";" + pszPob.Trim());
						pszImprimeCadena.Append(";" + pszCP.Trim() + ";" + pszNomEmp.Trim());
						pszImprimeCadena.Append(";" + pszActi.Trim() + ";" + pszCalleEmp.Trim());
						pszImprimeCadena.Append(";" + pszColEmp.Trim() + ";" + pszPobEmp.Trim());
						pszImprimeCadena.Append(";" + pszCPEmp.Trim() + ";" + pszTelOfi.Trim());
						pszImprimeCadena.Append(";" + StringsHelper.Format(pszSueldo, "###,###.00"));
						
						FileSystem.PrintLine(iNumArchivo, pszImprimeCadena.ToString());
						
					};
				} else
				{
					if (pszAccion == "Abre")
					{
						//imprime la cadena del archivo por unica vez
						pszImprimeCadena = new StringBuilder("pszFecha;pszCredito;pszNumCuenta;pszNombre;pszTelDom;pszCalle;pszCol;pszPob;pszCP;");
						pszImprimeCadena.Append("pszNomEmp;pszActi;pszCalleEmp;pszColEmp;pszPobEmp;pszCPEmp;pszTelOfi;pszSueldo");
						
						FileSystem.PrintLine(iNumArchivo, pszImprimeCadena.ToString());
						
						pszAccion = CORVB.NULL_STRING;
					}
				}
				
				CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				
			}
			
		}
		
		
		//****************************************************************************
		//**                                                                        **
		//**       Descripción:                                                     **
		//**                   Lee la tabla de cambios maivos para Genera los archivos
		//**       Paso de parámetros:No. del archivo,identificador de operación,**
		//**                          proceso que lo genera, accion                 **
		//**                                                                        **
		//**       Valor de Regreso:                                                **
		//**                                                                        **
		//**                                                                        **
		//**       Ultima modificacion: 12oct98                                     **
		//**                                                                        **
		//****************************************************************************''
		static private void  Lee_Tabla_Cambios_Masivos( int iNumArchivo,  string pszParametroC,  string pszProceso,  string pszAccion)
		{
			
			string pszPrefijo = String.Empty;
			string pszBanco = String.Empty;
			string pszEmpresa = String.Empty;
			string pszEje = String.Empty;
			string pszDigito = String.Empty;
			string pszRollOver = String.Empty;
			string pszNombre = String.Empty;
			string pszMensaje = String.Empty;
			string pszNumCuenta = String.Empty;
			
			
			
			//solo si se cambiaron datos por empresa
			string pszImprimeCadena = new String(' ', 80);
			
			if (pszAccion == "Abre")
			{
				
				//imprime fecha,hora y encabezado
				pszImprimeCadena = "Fecha: " + DateTime.Today.ToShortDateString();
				FileSystem.PrintLine(iNumArchivo, pszImprimeCadena);
				pszImprimeCadena = new String(' ', 23) + "C A M B I O S     M A S I V O S" + new String(' ', 23);
				FileSystem.PrintLine(iNumArchivo, pszImprimeCadena);
				
				//estus del proceso
				switch(pszParametroC)
				{
					case "Procesado" : 
						pszImprimeCadena = new String(' ', 23) + "REPORTE DE REGISTROS ACTUALIZADOS" + new String(' ', 23); 
						break;
					case "No Cambio" : 
						pszImprimeCadena = new String(' ', 22) + "REPORTE DE REGISTROS QUE NO CAMBIARON" + new String(' ', 22); 
						break;
					case "No Proce" : 
						pszImprimeCadena = new String(' ', 20) + "REPORTE DE REGISTROS QUE ESTAN PENDIENTES" + new String(' ', 21); 
						break;
				}
				
				FileSystem.PrintLine(iNumArchivo, pszImprimeCadena);
				
				//proceso
				switch(pszProceso)
				{
					case "DomicilioEmp" : 
						pszImprimeCadena = new String(' ', 25) + "CAMBIO DE DOMICILIO DE EMPRESA" + new String(' ', 25); 
						break;
					case "Nombre" : 
						pszImprimeCadena = new String(' ', 26) + "CAMBIO DE NOMBRE" + new String(' ', 27); 
						break;
					case "DomicilioT" : 
						pszImprimeCadena = new String(' ', 20) + "CAMBIO DE DOMICILIO DE TARJETAHABIENTE" + new String(' ', 21); 
						break;
					case "Limite" : 
						pszImprimeCadena = new String(' ', 17) + "CAMBIO DE LIMITE DE CREDITO DE TARJETAHABIENTE" + new String(' ', 17); 
						break;
				}
				
				FileSystem.PrintLine(iNumArchivo, pszImprimeCadena);
				
			}
			
			//genera el archivo de registros procesados
			CORVAR.pszgblsql = "select eje_prefijo,gpo_banco,emp_num,eje_num,eje_digit,eje_roll_over,eje_nombre,cam_mensaje";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYS_CAM;
			CORVAR.pszgblsql = CORVAR.pszgblsql + " where cam_estado = '" + pszParametroC + "'";
			CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = '" + pszProceso + "'";
			if (pszParametroC != "No Proce")
			{
				CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_mensaje = ''";
			}
			
			if (Obtiene_Registros() != 0)
			{
				
				while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
				{
					pszImprimeCadena = new String(' ', 80);
					pszPrefijo = VBSQL.SqlData(CORVAR.hgblConexion, 1);
					pszBanco = VBSQL.SqlData(CORVAR.hgblConexion, 2);
					pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 3);
					pszEje = VBSQL.SqlData(CORVAR.hgblConexion, 4);
					pszDigito = VBSQL.SqlData(CORVAR.hgblConexion, 5);
					pszRollOver = VBSQL.SqlData(CORVAR.hgblConexion, 6);
					pszNombre = VBSQL.SqlData(CORVAR.hgblConexion, 7);
					pszMensaje = VBSQL.SqlData(CORVAR.hgblConexion, 8);
					
					//arma el numero de cuenta del ejecutivo
					pszNumCuenta = pszPrefijo + pszBanco + StringsHelper.Format(pszEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(Conversion.Str(pszEje).Trim(), Formato.sMascara(Formato.iTipo.Ejecutivo)) + Conversion.Str(pszRollOver).Trim() + Conversion.Str(pszDigito).Trim();
					
					pszImprimeCadena = StringsHelper.MidAssignment(pszImprimeCadena, 1, pszNombre.Trim());
					pszImprimeCadena = StringsHelper.MidAssignment(pszImprimeCadena, 30, pszNumCuenta.Trim());
					pszImprimeCadena = StringsHelper.MidAssignment(pszImprimeCadena, 50, pszMensaje.Trim());
					FileSystem.PrintLine(iNumArchivo, pszImprimeCadena);
					
				};
			}
			
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			
		}
		
		
		static public int Obtiene_Mes_Numerico( string pszMes)
		{
			
			int result = 0;
			switch(pszMes.Trim())
			{
				case "Enero" : 
					result = 1; 
					break;
				case "Febrero" : 
					result = 2; 
					break;
				case "Marzo" : 
					result = 3; 
					break;
				case "Abril" : 
					result = 4; 
					break;
				case "Mayo" : 
					result = 5; 
					break;
				case "Junio" : 
					result = 6; 
					break;
				case "Julio" : 
					result = 7; 
					break;
				case "Agosto" : 
					result = 8; 
					break;
				case "Septiembre" : 
					result = 9; 
					break;
				case "Octubre" : 
					result = 10; 
					break;
				case "Noviembre" : 
					result = 11; 
					break;
				case "Diciembre" : 
					result = 12; 
					break;
			}
			return result;
		}
		
		//----------------------------------------------------------------------------------
		//
		//Descripción   : Ejecuta un sentecia SQL
		//
		//Declaración   : Function ObtieneRegistros (hgblConexion As Integer, rsSQL As String) As Integer
		//
		//Parámetros    : hgblConexion. La conexión a la BD
		//                        rsSQL. La sentecia SQL a ejecutar
		//
		// Valor de Regreso    : 1. Verdadero o falso
		//
		//--------------------------------------------------------------------------
		static public int ObtieneRegistros(ref  string rsSQL)
		{
			
			CORDBLIB.giError = CORCONST.OK; //Inicializa la variable global de error
			
			//giErrorSybase = OK                                                     'Inicializa la variable global que guarda el número de error de sybase
			
			Libera_Memoria(CORVAR.hgblConexion); //Limpia el buffer antes de ejecutar alguna instrucciòn por si las dudas
			
			if (VBSQL.SqlCmd(CORVAR.hgblConexion, rsSQL) == VBSQL.FAIL)
			{
				return 0;
			} //Si falla la asignación de memoria del Query entonces  termina la función.
			
			if (VBSQL.SqlExec(CORVAR.hgblConexion) == VBSQL.SUCCEED)
			{ //Ejecuta las sentencias preparadas anteriormente.
				
				CORVAR.igblErr = VBSQL.SqlResults(CORVAR.hgblConexion); //Posiciona el apuntador de resultados al inicio del bloque de información extraído.
				
				while (CORVAR.igblErr != 2)
					{
					 //Si existen más resultados entonces...
						
						if (VBSQL.SqlRows(CORVAR.hgblConexion) != 0)
						{ //Si obtuvo registros el query ejecutado entonces
							 //Regresa verdadero la función
							
							return -1; //Abandona la función
							
						}
						
						CORVAR.igblErr = VBSQL.SqlResults(CORVAR.hgblConexion); //Posiciona el apuntador de resultados al inicio del bloque de información extraído.
						
					}
				
			}
			
			return 0;
		}
		
		static public void  Libera_Memoria( object ghConexion)
		{
			
			//UPGRADE_WARNING: (1068) ghConexion of type Variant is being forced to int.
			CORVAR.igblErr = VBSQL.SqlCanQuery(Convert.ToInt32(ghConexion)); //Libera el buffer utilizado por el query
			
			//UPGRADE_WARNING: (1068) ghConexion of type Variant is being forced to int.
			CORVAR.igblErr = VBSQL.SqlCancel(Convert.ToInt32(ghConexion)); //Libera el buffer de datos
			
			//UPGRADE_WARNING: (1068) ghConexion of type Variant is being forced to int.
			VBSQL.SqlFreeBuf(Convert.ToInt32(ghConexion)); //Libera el buffer nuevamente debido a problemas en V 4.0
			
		}
		
		
        //static public string Obten_Dato_Ini( string pszModulo,  string pszSeccion)
        //{
			
			
        //    string result = String.Empty;
        //    StringBuilder pszFormato = new StringBuilder(255);
        //    //AIS-1182 NGONZALEZ
        //    int iNumChar = API.KERNEL.GetPrivateProfileString(pszModulo, pszSeccion, "", pszFormato, 255, "corbnx32.ini");
			
        //    if (iNumChar == 0)
        //    {
        //        Cursor.Current = Cursors.Default;
        //        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        //        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        //        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //        CORVAR.igblErr = (int) Interaction.MsgBox("No se encontró el módulo en el Archivo .INI.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
        //        return result;
        //    } else
        //    {
        //        result = pszFormato.ToString().Substring(0, Math.Min(pszFormato.Length, iNumChar));
        //    }
			
        //    return result;
        //}
		
		
		//-----------------------------------------------------------------------------------------------
		//
		// Descripción:
		//             Abre una transacción.
		//             Utiliza la varible global gbExisteTransaccion.
		//
		// Parámetros:
		//             Ninguno.
		//
		//-----------------------------------------------------------------------------------------------
		static public int Abre_Transaccion()
		{
			
			int result = 0;
			result = 0;
			
			//Si esta abierta alguna transacción
			if (CORDBLIB.gbExisteTransaccion == (-1))
			{
				
				result = -1;
				
			} else
			{
				
				//Abre transacción
				CORDBLIB.giError = CORCONST.OK;
				CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, "Begin Transaction");
				CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
				
				//Si hubo éxito...
				if (CORVAR.igblRetorna == VBSQL.SUCCEED)
				{
					result = -1;
					CORDBLIB.gbExisteTransaccion = -1;
				}
				
				CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
				
			}
			
			return result;
		}
		
		
		
		//-----------------------------------------------------------------------------------------------
		//
		// Descripción:
		//             Confirma la ejecución de una transacción.
		//             Utiliza la varible global gbExisteTransaccion.
		//
		// Parámetros:
		//             Ninguno.
		//
		//-----------------------------------------------------------------------------------------------
		static public int Confirma_Transaccion()
		{
			
			int result = 0;
			result = 0;
			
			//Ejecuta el Commit
			CORDBLIB.giError = CORCONST.OK;
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, "Commit Transaction");
			CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
			
			//Si hubo éxito...
			if (CORVAR.igblRetorna == VBSQL.SUCCEED)
			{
				result = -1;
			}
			
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			
			//Apaga la bandera de la transacción
			CORDBLIB.gbExisteTransaccion = 0;
			
			return result;
		}
		
		//-----------------------------------------------------------------------------------------------
		//
		// Descripción:
		//             Envía el mensaje de la varible gsMsg.
		//
		// Parámetros:
		//             viIconos        = Íconos a mostrar.
		//             viMousePointer  = Estatus del apuntador del Mouse.
		//             iRespuesta      = Resultado obtenido del mensaje.
		//                               Cuando se desee utilizar debe ser true.
		//
		//-----------------------------------------------------------------------------------------------
		static public void  Envia_Mensaje( MsgBoxStyle viIconos,  int viMousePointer, ref  int iRespuesta)
		{
			
			Cursor.Current = Cursors.Default;
			
			//Despliega el mensaje
			if (iRespuesta == (-1))
			{
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				iRespuesta = (int) Interaction.MsgBox(CORDBLIB.gsMsg, viIconos, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			} else
			{
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
				//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
				Interaction.MsgBox(CORDBLIB.gsMsg, viIconos, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			
			CORDBLIB.gsMsg = CORVB.NULL_STRING;
			
			//UPGRADE_ISSUE: (2036) Screen property Screen.MousePointer does not support custom mousepointers.
            Cursor.Current = Cursors.Default;
			
		}
		
		//------------------------------------------------------------------------------------------------
		//
		// Descripción       Ejecuta una sentencia query de consulta a la BD.
		//                   Utiliza las variables globales hgblConexion y pszgblSQL.
		//
		// Parámetros        Ninguno.
		//
		// Valor de Regreso  Verdadero si se ejecuta correctamente y encuentra información.
		//                   Falso si ocurre un error o no encuentra información.
		//
		//------------------------------------------------------------------------------------------------
		static public int Existe_Dato()
		{
			
			int result = 0;
			result = 0;
			
			//Ejecuta la sentencia
			CORDBLIB.giError = CORCONST.OK;
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
			CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
			
			if (CORVAR.igblRetorna == VBSQL.SUCCEED)
			{
				//Si ejecutó correctamente
				CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);
				
				if (VBSQL.SqlRows(CORVAR.hgblConexion) != 0)
				{
					//Si obtiene registros
					result = -1;
				}
				
			}
			
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			
			CORVAR.pszgblsql = CORVB.NULL_STRING;
			
			return result;
		}
		
		
		//-----------------------------------------------------------------------------------------------
		//
		// Descripción:
		//             Ejecuta el query enviado y llena el control (ListBox o ComboBox) con los
		//             resultados, colocando el segundo campo en
		//
		//             Utiliza las variables globales hgblConexion y pszgblSQL.
		//
		// Parámetros:
		//             ctlControl    = Nombre del control a llenar
		//             vsFormato  = Formato del primer campo
		//
		//-----------------------------------------------------------------------------------------------
		static public void  Llena_Control( Control ctlControl,  string vsFormato)
		{
			
			//Limpiamos el Combo box o ListBox
			//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control.
			ReflectionHelper.Invoke(ctlControl, "Clear", new object[]{});
			
			//Se ejecuta el query
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
			CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
			
			//Si se tiene éxito
			if (CORVAR.igblRetorna == VBSQL.SUCCEED)
			{
				CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);
				//Se obtienen los datos y se van agregando al control
				
				while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
				{
					//UPGRADE_TODO: (1067) Member AddItem is not defined in type VB.Control.
					ReflectionHelper.Invoke(ctlControl, "AddItem", new object[]{StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), vsFormato) + new String(' ', 100) + VBSQL.SqlData(CORVAR.hgblConexion, 2)});
				};
			}
			
			//Limpia el Buffer de la Base
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			
		}
		
		
		//------------------------------------------------------------------------------------------------
		// Descripción : Esta subrutina selecciona todos los caracteres de un control.
		//
		//
		// Parámetros :  ctlControl  = Control que se seleccionará
		//
		//------------------------------------------------------------------------------------------------
		static public void  Marca_Texto( Control ctlControl)
		{
			
			//UPGRADE_TODO: (1067) Member SelStart is not defined in type VB.Control.
			ReflectionHelper.SetMember(ctlControl, "SelStart", CORVB.NULL_INTEGER); //Indica la posición inicial de la selección
			//UPGRADE_TODO: (1067) Member SelLength is not defined in type VB.Control.
			//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control.
			ReflectionHelper.SetMember(ctlControl, "SelLength", Strings.Len(Convert.ToString(ctlControl.Text))); //Indica la longitud total de la selección
			
		}
		
		//--------------------------------------------------------------------------------
		//
		//   Descripción       :
		//                         Realiza una operación de inserción, actualización
		//                         o borrado a la BD
		//
		//   Parámetros        :   Ninguno.
		//
		//   Valor de Regreso  :   El número de registros modificados
		//
		//--------------------------------------------------------------------------------
		static public int Modifica_Registro()
		{
			
			int result = 0;
			CORDBLIB.giError = CORCONST.OK;
			result = CORVB.NULL_INTEGER;
			
			//Se ejecuta el query
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
			CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
			
			//Si hubo éxito...
			if (CORVAR.igblRetorna == VBSQL.SUCCEED)
			{
				CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);
				result = VBSQL.SqlCount(CORVAR.hgblConexion);
				CORDBLIB.giError = CORCONST.OK;
			}
			
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			
			return result;
		}
		
		
		//--------------------------------------------------------------------------------
		//
		//   Descripción       :
		//                         Realiza una operación de inserción, actualización
		//                         o borrado a la BD
		//
		//   Parámetros        :   Ninguno.
		//
		//   Valor de Regreso  :   El número de registros modificados
		//
		//--------------------------------------------------------------------------------
		static public int Modifica_Registro_SegConex()
		{
			int result = 0;
			CORDBLIB.giError = CORCONST.OK;
			result = CORVB.NULL_INTEGER;
			//Se ejecuta el query
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion2, CORVAR.pszgblsql);
			CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion2);
			//Si hubo éxito...
			if (CORVAR.igblRetorna == VBSQL.SUCCEED)
			{
				CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion2);
				result = VBSQL.SqlCount(CORVAR.hgblConexion2);
				CORDBLIB.giError = CORCONST.OK;
			}
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
			return result;
		}
		
		
		static public int Actualiza_Limites_Credito()
		{
			
			CORVAR.pszgblsql = "sp_Actualiza_Limites_Credito";
			
			if (Modifica_Registro() != 0)
			{
			} else
			{
				//Finalizamos la ejecución del SQL
				return 0;
			}
			
			return -1;
			
		}
		
		
		//------------------------------------------------------------------------------------------------
		//
		// Descripción       Ejecuta una sentencia query de consulta a la BD
		//                   Utiliza las variables locales de la forma hConexion y pszsql
		//
		// Parámetros        Ninguno
		//
		// Valor de Regreso  Verdadero si se ejecuta correctamente y encuentra información,
		//                   Falso si ocurre un error o no encuentra información.
		//
		//------------------------------------------------------------------------------------------------
		static public int Consulta_Registros()
		{
			int result = 0;
			int lRetorna = 0;
			
			result = 0;
			
			CORDBLIB.giError = CORCONST.OK;
			
			//Ejecuta la sentencia
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion2, CORVAR.pszgblSql2);
			CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion2);
			
			if (CORVAR.igblRetorna == VBSQL.SUCCEED)
			{
				//Si ejecutó correctamente
				CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion2);
				
				if (VBSQL.SqlRows(CORVAR.hgblConexion2) != 0)
				{
					//Si obtiene registros
					result = -1;
				} else
				{
					lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
				}
				
			} else
			{
				lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
			}
			
			return result;
		}
		//------------------------------------------------------------------------------------------------
		//
		// Descripción       Ejecuta una sentencia query de consulta a la BD
		//                   Utiliza las variables globales hgblConexion y pszgblSQL.
		//
		// Parámetros        Ninguno
		//
		// Valor de Regreso  Verdadero si se ejecuta correctamente y encuentra información,
		//                   Falso si ocurre un error o no encuentra información.
		//
		//------------------------------------------------------------------------------------------------
		static public int Obtiene_Datos()
		{
			
			int result = 0;
			result = 0;
			
			CORDBLIB.giError = CORCONST.OK;
			
			//Ejecuta la sentencia
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion2, CORVAR.pszgblSql2);
			CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion2);
			
			if (CORVAR.igblRetorna == VBSQL.SUCCEED)
			{
				//Si ejecutó correctamente
				CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion2);
				
				if (VBSQL.SqlRows(CORVAR.hgblConexion2) != 0)
				{
					//Si obtiene registros
					result = -1;
				} else
				{
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
				}
				
			} else
			{
				CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
			}
			
			return result;
		}
		
		
		
		//------------------------------------------------------------------------------------------------
		//
		// Descripción       Ejecuta una sentencia query de consulta a la BD
		//                   Utiliza las variables globales hgblConexion y pszgblSQL.
		//
		// Parámetros        Ninguno
		//
		// Valor de Regreso  Verdadero si se ejecuta correctamente y encuentra información,
		//                   Falso si ocurre un error o no encuentra información.
		//
		//------------------------------------------------------------------------------------------------
		static public int Obtiene_Registros()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			int result = 0;
			try
			{
					result = 0;
					
					CORDBLIB.giError = CORCONST.OK;
					
					
					//Ejecuta la sentencia
					CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
					CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
					
					if (CORVAR.igblRetorna == VBSQL.SUCCEED)
					{
						//Si ejecutó correctamente
						CORVAR.igblErr = VBSQL.SqlResults(CORVAR.hgblConexion);
						
						if (VBSQL.SqlRows(CORVAR.hgblConexion) != 0)
						{
							//Si obtiene registros
							result = -1;
						} else
						{
							CORVAR.igblErr = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
						
					} else
					{
						CORVAR.igblErr = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			return result;
		}
		
		static public int Ejecuta_sentencia()
		{
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			int result = 0;
			try
			{
					result = 0;
					
					CORDBLIB.giError = CORCONST.OK;
					
					
					//Ejecuta la sentencia
					CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
					CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
					
					if (CORVAR.igblRetorna == VBSQL.SUCCEED)
					{
						//Si ejecutó correctamente
						CORVAR.igblErr = VBSQL.SqlResults(CORVAR.hgblConexion);
						
						if (VBSQL.SqlRows(CORVAR.hgblConexion) != 0)
						{
							result = -1;
						} else
						{
							CORVAR.igblErr = VBSQL.SqlCancel(CORVAR.hgblConexion);
						}
						
					} else
					{
						CORVAR.igblErr = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			return result;
		}
		
		//----------------------------------------------------------------------------
		// Descripción:  Esta función quita el RETURN de una cadena de caracteres.
		//
		// Parámetros:
		//               sCadena --> La cadena a la que se desea quitar el RETURN
		//
		// Valor que regresa:
		//               Regresa la nueva cadena sin el RETURN.
		//
		//----------------------------------------------------------------------------
		static public string Quita_Return( string sCadena)
		{
			
			
			string sCadenaTemp = sCadena.Trim();
			int iInicio = 1;
			int iPos = CORVB.NULL_INTEGER;
			StringBuilder sCadenaFinal = new StringBuilder();
			sCadenaFinal.Append(CORVB.NULL_STRING);
			
			//Busca el KEY_RETURN
			
			while(sCadenaTemp.Length != CORVB.NULL_INTEGER)
			{
				
				//Busca el RETURN
				iPos = Strings.InStr(iInicio, sCadenaTemp, Strings.Chr(CORVB.KEY_RETURN).ToString(), CompareMethod.Binary);
				
				if (iPos > CORVB.NULL_INTEGER)
				{
					//Arma la cadena reeplazando el KEY_RETURN por un espacio
					sCadenaFinal.Append(Strings.Mid(sCadenaTemp.Trim(), iInicio, iPos - 1) + new String(' ', 1));
					//La nueva cadena temporal es la parte final después del KEY_RETURN encontrado
					sCadenaTemp = Strings.Mid(sCadenaTemp.Trim(), iPos + 1);
				} else
				{
					
					//Arma la cadena uniendo la final con la temporal con un espacio
					if (sCadenaFinal.ToString().Length > CORVB.NULL_INTEGER)
					{
						sCadenaFinal.Append(new String(' ', 1) + sCadenaTemp);
					} else
					{
						sCadenaFinal = new StringBuilder(sCadenaTemp);
					}
					
					//La cadena temporal se queda vacía
					sCadenaTemp = CORVB.NULL_STRING;
				}
				
			};
			
			sCadenaTemp = sCadenaFinal.ToString();
			iInicio = 1;
			iPos = CORVB.NULL_INTEGER;
			sCadenaFinal = new StringBuilder(CORVB.NULL_STRING);
			
			//Busca el 10
			
			while(sCadenaTemp.Length != CORVB.NULL_INTEGER)
			{
				
				//Busca el 10
				iPos = Strings.InStr(iInicio, sCadenaTemp, "\n", CompareMethod.Binary);
				
				if (iPos > CORVB.NULL_INTEGER)
				{
					//Arma la cadena reeplazando el 10 por un espacio
					sCadenaFinal.Append(Strings.Mid(sCadenaTemp.Trim(), iInicio, iPos - 1) + new String(' ', 1));
					//La nueva cadena temporal es la parte final después del 10 encontrado
					sCadenaTemp = Strings.Mid(sCadenaTemp.Trim(), iPos + 1);
				} else
				{
					
					//Arma la cadena uniendo la final con la temporal con un espacio
					if (sCadenaFinal.ToString().Length > CORVB.NULL_INTEGER)
					{
						sCadenaFinal.Append(new String(' ', 1) + sCadenaTemp);
					} else
					{
						sCadenaFinal = new StringBuilder(sCadenaTemp);
					}
					
					//La cadena temporal se queda vacía
					sCadenaTemp = CORVB.NULL_STRING;
				}
				
			};
			
			return sCadenaFinal.ToString();
			
		}
		
		//-----------------------------------------------------------------------------------------------
		//
		// Descripción:
		//             Hace el rollback de la transacción.
		//
		// Parámetros:
		//             Ninguno.
		//
		//-----------------------------------------------------------------------------------------------
		static public int Revoca_Transaccion()
		{
			
			int result = 0;
			result = 0;
			
			//Ejecuta el RollBack
			CORDBLIB.giError = CORCONST.OK;
			CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, "RollBack Transaction");
			CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
			
			//Si hubo éxito...
			if (CORVAR.igblRetorna == VBSQL.SUCCEED)
			{
				result = -1;
			}
			
			CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
			
			//Apaga la bandera de la transacción
			CORDBLIB.gbExisteTransaccion = 0;
			
			return result;
		}
		
		
		//--------------------------------------------------------------------------------
		//
		//   Descripción       :
		//                         Cuenta el número de registros
		//
		//   Parámetros        :   Ninguno.
		//
		//   Valor de Regreso  :   El número de registros afectados por el query
		//
		//--------------------------------------------------------------------------------
		
		static public int Cuenta_Registros()
		{
			
			int result = 0;
			int lContador = 0;
			//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
			try
			{
					CORDBLIB.giError = CORCONST.OK;
					result = CORVB.NULL_INTEGER;
					
					//Se ejecuta el query
					CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
					CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
					
					//Si hubo éxito...
					if (CORVAR.igblRetorna == VBSQL.SUCCEED)
					{
						//Si ejecutó correctamente
						CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							lContador++;
						};
						
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					result = lContador;
				}
			catch (Exception exc)
			{
				throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
			}
			
			return result;
		}
		
		static public string Fecha_2000_Fin( int fecha)
		{
			
			
			string iAño = fecha.ToString();
			int iLongAño = iAño.Length;
			if (iLongAño <= 7)
			{ //se lee aammdd
				iAño = Strings.Mid(StringsHelper.Format(iAño, "00000"), 5);
			} else
			{
				//se lee el formato aaaammdd
				iAño = Strings.Mid(iAño.ToString(), 1, 4);
			}
			iLongAño = iAño.Length;
			if (iLongAño == 1)
			{
				iAño = "9" + iAño;
			}
			if (iLongAño < 4)
			{ //es de dos digitos
				if (String.CompareOrdinal(iAño, "99") < 0 && String.CompareOrdinal(iAño, "50") > 0)
				{
					iAño = "19" + iAño;
				} else
				{
					iAño = "20" + iAño;
				}
			}
			
			return iAño;
			
		}
		
		static public string Fecha_2000_Ini( int fecha)
		{
			
			
			string iAño = fecha.ToString();
			int iLongAño = iAño.Length;
			if (iLongAño <= 7)
			{ //se lee aammdd
				iAño = Strings.Mid(StringsHelper.Format(iAño, "00000"), 1, 2);
			} else
			{
				//se lee el formato aaaammdd
				iAño = Strings.Mid(iAño.ToString(), 1, 4);
			}
			iLongAño = iAño.Length;
			if (iLongAño == 1)
			{
				iAño = "9" + iAño;
			}
			if (iLongAño < 4)
			{ //es de dos digitos
				if (String.CompareOrdinal(iAño, "99") < 0 && String.CompareOrdinal(iAño, "50") > 0)
				{
					iAño = "19" + iAño;
				} else
				{
					iAño = "20" + iAño;
				}
			}
			return iAño;
			
			
		}
		
		
		static public string Fecha_2000( int fecha)
		{
			
			string iAño = String.Empty;
			string iMes = String.Empty;
			string iDia = String.Empty;
			
			string pszFecha = fecha.ToString();
			int iLongAño = pszFecha.Length;
			if (iLongAño <= 6)
			{ //se lee aammdd
				iAño = Strings.Mid(StringsHelper.Format(pszFecha, "000000"), 1, 2);
				iMes = Strings.Mid(StringsHelper.Format(pszFecha, "000000"), 3, 2);
				iDia = Strings.Mid(StringsHelper.Format(pszFecha, "000000"), 5, 2);
			} else
			{
				//se lee el formato aaaammdd
				iAño = Strings.Mid(pszFecha.ToString(), 1, 4);
				iMes = Strings.Mid(pszFecha.ToString(), 5, 2);
				iDia = Strings.Mid(pszFecha.ToString(), 7, 2);
			}
			iLongAño = iAño.Length;
			if (iLongAño == 1)
			{
				iAño = "9" + iAño;
			}
			if (iLongAño < 4)
			{ //es de dos digitos
				if (String.CompareOrdinal(iAño, "99") < 0 && String.CompareOrdinal(iAño, "50") > 0)
				{
					iAño = "19" + iAño;
				} else
				{
					iAño = "20" + iAño;
				}
			}
			
			
			return iAño + iMes + iDia;
			
			
		}
		static public string Obten_Mes_Ingles( int iMes)
		{
			
			string pszMesIngles = String.Empty;
			
			switch(iMes)
			{
				case 1 :  
					pszMesIngles = "Jan"; 
					break;
				case 2 :  
					pszMesIngles = "Feb"; 
					break;
				case 3 :  
					pszMesIngles = "Mar"; 
					break;
				case 4 :  
					pszMesIngles = "Apr"; 
					break;
				case 5 :  
					pszMesIngles = "May"; 
					break;
				case 6 :  
					pszMesIngles = "Jun"; 
					break;
				case 7 :  
					pszMesIngles = "Jul"; 
					break;
				case 8 :  
					pszMesIngles = "Aug"; 
					break;
				case 9 :  
					pszMesIngles = "Sep"; 
					break;
				case 10 :  
					pszMesIngles = "Oct"; 
					break;
				case 11 :  
					pszMesIngles = "Nov"; 
					break;
				case 12 :  
					pszMesIngles = "Dec"; 
					break;
			}
			return pszMesIngles;
			
		}
	}
}