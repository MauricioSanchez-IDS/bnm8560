using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Artinsoft.VB6.VB; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Drawing; 
using System.Text; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORDEPUR
		: System.Windows.Forms.Form
		{
		
			//****************************************************************************
			//**                                                                        **
			//**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
			//**                                                                        **
			//**       ---------------------------------------------------------        **
			//**                                                                        **
			//**       Descripción: Depuracion de informacion aclaraciones bitacora     **
			//**                    y cuentas                                          **
			//**                                                                        **
			//**       Responsable:                                                     **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 24/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			//Constante que indica que el registro ya fue exportado
			const string STR_STATUS = "N";
			
			//Bandera para controlar la interrupción del proceso de exportación
			int bCanProc = 0;
			
			//Variable para la conexión a Sybase para depuración de cuentas
			int hDEPConexion = 0;
			
			//Variables para enviar la cuenta a Sybase
			int iEjePrefijo = 0;
			int iEjeBanco = 0;
			int lEjeEmpresa = 0;
			int lEjeNumero = 0;
			int iEjeRollOver = 0;
			int iEjeDigito = 0;
			FixedLengthString szEjeNombre = new FixedLengthString(CORBD.LNG_EJE_NOMGRA);
			FixedLengthString szEjeCalle = new FixedLengthString(CORBD.LNG_EJE_CALLE);
			FixedLengthString szEjeColonia = new FixedLengthString(CORBD.LNG_EJE_COL);
			FixedLengthString szEjePoblacion = new FixedLengthString(CORBD.LNG_EJE_POB);
			int iEjeZP = 0;
			int lEjeCP = 0;
			FixedLengthString szEjeTelDom = new FixedLengthString(CORBD.LNG_EJE_TDO);
			FixedLengthString szEjeTelOfi = new FixedLengthString(CORBD.LNG_EJE_TOF);
			FixedLengthString szEjeExt = new FixedLengthString(CORBD.LNG_EJE_EXT);
			double dEjeCredito = 0;
			FixedLengthString szEjeStatus = new FixedLengthString(CORBD.LNG_EMP_STA);
			
			int iTHSPrefijo = 0;
			int iTHSBanco = 0;
			int lTHSEmpresa = 0;
			int lTHSNumero = 0;
			FixedLengthString szTHSNombre = new FixedLengthString(CORBD.LNG_THS_NOM);
			FixedLengthString szTHSCalle = new FixedLengthString(CORBD.LNG_THS_CALLE);
			FixedLengthString szTHSColonia = new FixedLengthString(CORBD.LNG_THS_COL);
			FixedLengthString szTHSPoblacion = new FixedLengthString(CORBD.LNG_THS_POB);
			int iTHSZP = 0;
			int lTHSCP = 0;
			int lTHSTelDom = 0;
			int lTHSTelOfi = 0;
			int lTHSExt = 0;
			int iTHSRollOver = 0;
			int iTHSDigito = 0;
			double dTHSCredito = 0;
			FixedLengthString szTHSReposicion = new FixedLengthString(CORBD.LNG_THS_EJX);
			
			//AIS-1178 NGONZALEZ
			CORPROC2.tyEjecutivo[] pszArrEjeBor;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
			//AIS-1178 NGONZALEZ
			CORPROC2.tyEjecutivo[] pszArrEjeAct;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
			//AIS-1178 NGONZALEZ
			CORPROC2.tyEjecutivo[] pszArrTHSAct;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
			
			int intCont = 0;
			
			private int Actualiza_en_EJE()
			{
					
					int result = 0;
					int hStmt = 0;
					int hFinStmt = 0;
					
					int bActualiza = 0;
					result = -1;
					
					CORVAR.pszgblsql = "Update " + CORBD.DB_SYB_EJE + " SET ";
					
					if (iEjeRollOver != iTHSRollOver || iEjeDigito != iTHSDigito)
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_roll_over = " + iTHSRollOver.ToString() + ",";
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_digit = " + iTHSDigito.ToString() + ",";
						bActualiza = -1;
					}
					
					if (szEjeNombre.Value.Trim() != szTHSNombre.Value.Trim())
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nom_gra = '" + szTHSNombre.Value.Trim() + "',";
						bActualiza = -1;
					}
					
					if (szEjeCalle.Value.Trim() != szTHSCalle.Value.Trim())
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_calle = '" + szTHSCalle.Value.Trim() + "',";
						bActualiza = -1;
					}
					
					if (szEjeColonia.Value.Trim() != szTHSColonia.Value.Trim())
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_col = '" + szTHSColonia.Value.Trim() + "',";
						bActualiza = -1;
					}
					
					if (szEjePoblacion.Value.Trim() != szTHSPoblacion.Value.Trim())
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_pob = '" + szTHSPoblacion.Value.Trim() + "',";
						bActualiza = -1;
					}
					
					if (lEjeCP != lTHSCP)
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_cp = " + lTHSCP.ToString() + ",";
						bActualiza = -1;
					}
					
					if (Conversion.Val(szEjeTelDom.Value) != lTHSTelDom)
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tel_dom = '" + lTHSTelDom.ToString() + "',";
						bActualiza = -1;
					}
					
					if (Conversion.Val(szEjeTelOfi.Value) != lTHSTelOfi)
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tel_ofi = '" + lTHSTelOfi.ToString() + "',";
						bActualiza = -1;
					}
					
					if (Conversion.Val(szEjeExt.Value) != lTHSExt)
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_ext = '" + lTHSExt.ToString() + "',";
						bActualiza = -1;
					}
					
					if (dEjeCredito != dTHSCredito)
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_limcred = " + dTHSCredito.ToString() + ",";
						bActualiza = -1;
					}
					
					if (bActualiza != 0)
					{
						CORVAR.pszgblsql = Strings.Mid(CORVAR.pszgblsql, 1, CORVAR.pszgblsql.Length - 1);
						
						CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo =" + iEjePrefijo.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " AND gpo_banco =" + iEjeBanco.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " AND emp_num =" + lEjeEmpresa.ToString();
						CORVAR.pszgblsql = CORVAR.pszgblsql + " AND eje_num =" + lEjeNumero.ToString();
						
						if (CORPROC2.Modifica_Registro() != 0)
						{
						} else
						{
							return 0;
						}
					}
					
					return -1;
					
			}
			
			private int Borra_en_EJE()
			{
					
					string pszCadena = String.Empty;
					int hStmt = 0;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					//  pszgblsql = "baja_eje_emp " + Str(iEjeBanco) + "," + Str(lEjeEmpresa) + "," + Str(lEjeNumero) + ",T"
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "baja_eje_emp " + Conversion.Str(CORVAR.igblPref) + "," + Conversion.Str(iEjeBanco) + "," + Conversion.Str(lEjeEmpresa) + "," + Conversion.Str(lEjeNumero) + ",T";
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					if (CORPROC2.Modifica_Registro() != 0)
					{
					} else
					{
						return 0;
					}
					
					return -1;
					
			}
			
			private int Busca_Diferentes_THS()
			{
					
					int hStmt = 0;
					string pszCuenta = String.Empty;
					
					CORVAR.pszgblsql = "SELECT  T.eje_prefijo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.gpo_banco,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.eje_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_nombre,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_direccion_1,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_direccion_2,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_direccion_3,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_zona_postal,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_codigo_postal,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_tel_particular,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_tel_oficina,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_tel_extension,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.eje_roll_over,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.eje_digit,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_limite_credito,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_reposicion";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM  MTCTHS01 T";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where   not exists (select E.eje_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from  MTCEJE01 E";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where T.gpo_banco = E.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and T.eje_prefijo = E.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and T.emp_num = E.emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and T.eje_num = E.eje_num)";
					
					int lNumRegs = CORVB.NULL_INTEGER;
					
					int lTotRegs = CORPROC2.Cuenta_Registros();
					
					if (lTotRegs > CORVB.NULL_INTEGER)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								
								lNumRegs++;
								
								ID_DEP_PORC_PNL.FloodPercent = (short) (50 + ((lNumRegs * 100) / lTotRegs) / 2); //Actualizamos la Barra de Porcentaje
								
								Obten_Datos_THS(CORVAR.hgblConexion, 1);
								
								pszCuenta = iTHSPrefijo.ToString() + iTHSBanco.ToString() + StringsHelper.Format(lTHSEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(lTHSNumero, Formato.sMascara(Formato.iTipo.Ejecutivo));
								
								if (Conversion.Val(szTHSReposicion.Value) == 0)
								{ //No existe la cuenta y da una alta en Ejecutivos con datos de THS
									ID_DEP_THS_COB.Items.Add(pszCuenta + " Será dada de alta la reposición con datos de THS");
								} else
								{
									//Busca la cuenta en ejecutivos para dar de alta con los datos leidos de ejecutivos
									if (Existe_Cuenta_Eje(szTHSReposicion.Value) != 0)
									{ //Si existe la cuenta y da una alta en Ejecutivos con datos de Ejecutivos
										ID_DEP_THS_COB.Items.Add(pszCuenta + " Será dada de alta la reposición con datos de Ejecutivos  " + szTHSReposicion.Value);
									} else
									{
										ID_DEP_THS_COB.Items.Add(pszCuenta + " Existe inconsistencia con la cuenta" + szTHSReposicion.Value);
									}
								}
								
							};
							
						} else
						{
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
							return 0;
							
						}
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
						
					}
					
					return -1;
					
			}
			
			
			private void  Dep_Aclaraciones()
			{
					
					int hdbc = 0;
					int hStmt = 0;
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							this.Cursor = Cursors.Default;
							string pszFechaSeisMesAtras = Obten_Fecha();
							string pszMesaje = "La depuración borrará las aclaraciones menores a la fecha: " + Strings.Mid(pszFechaSeisMesAtras, 7, 2) + "/" + Strings.Mid(pszFechaSeisMesAtras, 5, 2) + "/" + Strings.Mid(pszFechaSeisMesAtras, 1, 4);
							pszMesaje = pszMesaje + "." + "\r" + "El proceso se tardará unos minutos.";
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							CORVAR.igblErr = (int) Interaction.MsgBox(pszMesaje, (MsgBoxStyle) (CORVB.MB_YESNO + CORVB.MB_ICONQUESTION), CORSTR.STR_APP_TIT);
							
							if (CORVAR.igblErr == CORVB.IDYES)
							{
								
								this.Cursor = Cursors.WaitCursor;
								
								CORVAR.pszgblsql = "DELETE " + CORBD.DB_SYB_ACL; //formato 941018
								CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE ";
								CORVAR.pszgblsql = CORVAR.pszgblsql + " acl_out_fec_venci < " + pszFechaSeisMesAtras;
								//***** INICIO CODIGO ANTERIOR FSWBMX *****
								//    pszgblsql = pszgblsql + " and gpo_banco=" + Format$(igblBanco)
								//***** FIN  CODIGO ANTERIOR FSWBMX *****
								//***** INICIO CODIGO NUEVO FSWBMX *****
								CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
								//***** FIN DE CODIGO NUEVO FSWBMX *****
								if (CORPROC2.Modifica_Registro() != 0)
								{
								}
								
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
								
								ID_DEP_PORC_PNL.FloodPercent = 100; //Actualizamos la Barra de Porcentaje
								
							}
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			private void  Dep_Bitacora()
			{
					
					int hdbc = 0;
					int hStmt = 0;
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							string pszMesaje = "Deseas realizar la Depuración de Bitácora.";
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							CORVAR.igblErr = (int) Interaction.MsgBox(pszMesaje, (MsgBoxStyle) (CORVB.MB_YESNO + CORVB.MB_ICONQUESTION), CORSTR.STR_APP_TIT);
							
							if (CORVAR.igblErr == CORVB.IDYES)
							{
								
								CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_BIT + " SET bit_accesos=" + CORVB.NULL_INTEGER.ToString();
								
								if (CORPROC2.Modifica_Registro() != 0)
								{
								} else
								{
									//Ocurrio algun error en la ejecución SQL
									this.Cursor = Cursors.Default;
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
									CORVAR.igblErr = (int) Interaction.MsgBox("No se pudo realizar la Depuración de la Bitácora. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
									bCanProc = 0;
									return;
								}
								
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
								
								ID_DEP_PORC_PNL.FloodPercent = 100; //Actualizamos la Barra de Porcentaje
								
							}
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			private void  Dep_Cuentas()
			{
					
					int iStatusTHS = 0;
					FixedLengthString szCadErr = new FixedLengthString(80);
					string pszCuenta = String.Empty;
					int lNumTHS = 0;
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							//UPGRADE_WARNING: (1042) Array pszArrEjeBor may need to have individual elements initialized.
							pszArrEjeBor = new CORPROC2.tyEjecutivo[CORVB.NULL_INTEGER + 1];
							//UPGRADE_WARNING: (1042) Array pszArrEjeAct may need to have individual elements initialized.
							pszArrEjeAct = new CORPROC2.tyEjecutivo[CORVB.NULL_INTEGER + 1];
							//UPGRADE_WARNING: (1042) Array pszArrTHSAct may need to have individual elements initialized.
							pszArrTHSAct = new CORPROC2.tyEjecutivo[CORVB.NULL_INTEGER + 1];
							
							int lCtasNoDep = CORVB.NULL_INTEGER;
							int lNumRegs = CORVB.NULL_INTEGER;
							
							if (Depura_Ejecutivos() < CORVB.NULL_INTEGER)
							{
								this.Cursor = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								CORVAR.igblErr = (int) Interaction.MsgBox("No se pudo realizar la Depuración de Cuentas. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
								return;
							}
							
							//Depura a los Ejecutivos borrando y actualizando
							int lTotReg = pszArrEjeBor.GetUpperBound(0) + pszArrEjeAct.GetUpperBound(0);
							
							//Elimina los Ejecutivos que sobran en THS
							for (int lCont = 1; lCont <= pszArrEjeBor.GetUpperBound(0); lCont++)
							{
								
								iEjePrefijo = pszArrEjeBor[lCont].iPrefijo;
								iEjeBanco = pszArrEjeBor[lCont].iBanco;
								lEjeEmpresa = pszArrEjeBor[lCont].lEmpresa;
								lEjeNumero = pszArrEjeBor[lCont].lNumero;
								
								lNumRegs++;
								//EISSA 03-10-2001. Formateo del número de empresa y del número de ejecutivo.
								pszCuenta = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iEjeBanco, "00") + StringsHelper.Format(lEjeEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(lEjeNumero, Formato.sMascara(Formato.iTipo.Ejecutivo));
								
								if ( ~Borra_en_EJE() != 0)
								{ //No pudo Borrar el Registro
									lCtasNoDep++;
									szCadErr.Value = pszCuenta + " Error al intentar borrar la tabla de Ejecutivos de la Empresa";
									FileSystem.FileOpen(1, CORVAR.pszgblPath + "Depura.err", OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1); //Abre el archivo para escribir la cuenta no depurada
									FileSystem.PrintLine(1, szCadErr.Value); //Escribe la cuenta
									FileSystem.FileClose(1); //Cierra el Archivo
								}
								
								ID_DEP_PORC_PNL.FloodPercent = Convert.ToInt16(((lNumRegs / ((double) (lTotReg))) * 100) / 2); //Actualizamos la Barra de Porcentaje
								
								if (ID_DEP_PORC_PNL.FloodPercent >= 49)
								{
									ID_DEP_PORC_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE); //Cambiamos el color de la letra de negro a blanco
									this.Refresh();
								}
								
							}
							
							//Se actualizan los campos diferentes entre THS y EJE
							for (int lCont = 1; lCont <= pszArrEjeAct.GetUpperBound(0); lCont++)
							{
								
								iEjePrefijo = pszArrEjeAct[lCont].iPrefijo;
								iEjeBanco = pszArrEjeAct[lCont].iBanco;
								lEjeEmpresa = pszArrEjeAct[lCont].lEmpresa;
								lEjeNumero = pszArrEjeAct[lCont].lNumero;
								iEjeRollOver = pszArrEjeAct[lCont].iRollOver;
								iEjeDigito = pszArrEjeAct[lCont].iDigito;
								szEjeNombre.Value = Convert.ToString(szEjeNombre.Value == pszArrEjeAct[lCont].pszNombre);
								szEjeCalle.Value = pszArrEjeAct[lCont].pszCalle;
								szEjeColonia.Value = pszArrEjeAct[lCont].pszColonia;
								szEjePoblacion.Value = pszArrEjeAct[lCont].pszPoblacion;
								iEjeZP = pszArrEjeAct[lCont].iZP;
								lEjeCP = pszArrEjeAct[lCont].lCP;
								szEjeTelDom.Value = pszArrEjeAct[lCont].pszTelDom;
								szEjeTelOfi.Value = pszArrEjeAct[lCont].pszTelOfi;
								szEjeExt.Value = pszArrEjeAct[lCont].pszExt;
								dEjeCredito = pszArrEjeAct[lCont].dCredito;
								szEjeStatus.Value = pszArrEjeAct[lCont].pszRepSta;
								
								iTHSPrefijo = pszArrTHSAct[lCont].iPrefijo;
								iTHSBanco = pszArrTHSAct[lCont].iBanco;
								lTHSEmpresa = pszArrTHSAct[lCont].lEmpresa;
								lTHSNumero = pszArrTHSAct[lCont].lNumero;
								iTHSRollOver = pszArrTHSAct[lCont].iRollOver;
								iTHSDigito = pszArrTHSAct[lCont].iDigito;
								szTHSNombre.Value = pszArrTHSAct[lCont].pszNombre;
								szTHSCalle.Value = pszArrTHSAct[lCont].pszCalle;
								szTHSColonia.Value = pszArrTHSAct[lCont].pszColonia;
								szTHSPoblacion.Value = pszArrTHSAct[lCont].pszPoblacion;
								iTHSZP = pszArrTHSAct[lCont].iZP;
								lTHSCP = pszArrTHSAct[lCont].lCP;
								lTHSTelDom = Convert.ToInt32(Conversion.Val(pszArrTHSAct[lCont].pszTelDom));
								lTHSTelOfi = Convert.ToInt32(Conversion.Val(pszArrTHSAct[lCont].pszTelOfi));
								lTHSExt = Convert.ToInt32(Conversion.Val(pszArrTHSAct[lCont].pszExt));
								dTHSCredito = pszArrTHSAct[lCont].dCredito;
								szTHSReposicion.Value = pszArrTHSAct[lCont].pszRepSta;
								
								lNumRegs++;
								//EISSA 03-10-2001. Formateo del número de empresa y del número de ejecutivo.
								pszCuenta = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iEjeBanco, "00") + StringsHelper.Format(lEjeEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(lEjeNumero, Formato.sMascara(Formato.iTipo.Ejecutivo));
								
								if ( ~Actualiza_en_EJE() != 0)
								{ //No pudo Actualizar el Registro
									lCtasNoDep++;
									szCadErr.Value = pszCuenta + " Error al intentar actualizar la tabla de Ejecutivos de la Empresa";
									FileSystem.FileOpen(1, CORVAR.pszgblPath + "Depura.err", OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1); //Abre el archivo para escribir la cuenta no depurada
									FileSystem.PrintLine(1, szCadErr.Value); //Escribe la cuenta
									FileSystem.FileClose(1); //Cierra el Archivo
								}
								
								ID_DEP_PORC_PNL.FloodPercent = Convert.ToInt16(((lNumRegs / ((double) (lTotReg + 1))) * 100) / 2); //Actualizamos la Barra de Porcentaje
								
								if (ID_DEP_PORC_PNL.FloodPercent >= 49)
								{
									ID_DEP_PORC_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE); //Cambiamos el color de la letra de negro a blanco
									this.Refresh();
								}
								
							}
							
							//Depuración en la Tabla THS
							Depura_THS();
							
							//Actualiza los Límites de Crédito de Empresas y Corporativos
							if ( ~CORPROC2.Actualiza_Limites_Credito() != 0)
							{
								
								//Se envía mensaje para verificar en archivo DEPURA.ERR
								this.Cursor = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								CORVAR.igblErr = (int) Interaction.MsgBox("No se actualizaron los Límites de Crédito.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
								
							}
							
							//Llena el indicador a 100% realizado
							ID_DEP_PORC_PNL.FloodPercent = 100;
							
							//Si hay cuentas que no se pudieron depurar...
							if (lCtasNoDep > CORVB.NULL_INTEGER)
							{
								
								//Se envía mensaje para verificar en archivo DEPURA.ERR
								this.Cursor = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								CORVAR.igblErr = (int) Interaction.MsgBox("Existieron cuentas no depuradas. Edite el archivo DEPURA.ERR para saber que cuentas no fueron depuradas.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
								
							}
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			
			private void  Depura_THS()
			{
					
					int hStmt = 0;
					string pszCuenta = String.Empty;
					int lCtasNoDep = 0;
					int lNumRegs = 0;
					FixedLengthString szCadErr = new FixedLengthString(80);
					
					//UPGRADE_WARNING: (1042) Array pszArrTHSAct may need to have individual elements initialized.
					pszArrTHSAct = new CORPROC2.tyEjecutivo[CORVB.NULL_INTEGER + 1];
					
					CORVAR.pszgblsql = "SELECT  T.eje_prefijo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.gpo_banco,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.eje_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_nombre,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_direccion_1,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_direccion_2,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_direccion_3,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_zona_postal,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_codigo_postal,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_tel_particular,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_tel_oficina,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_tel_extension,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.eje_roll_over,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.eje_digit,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_limite_credito,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "T.ths_reposicion";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM  MTCTHS01 T";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " where   not exists (select E.eje_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from  MTCEJE01 E";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " Where T.gpo_banco = E.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and T.eje_prefijo = E.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and T.emp_num = E.emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and T.eje_num = E.eje_num)";
					
					int lTotReg = CORPROC2.Cuenta_Registros();
					
					if (lTotReg > CORVB.NULL_INTEGER)
					{
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							
							
							while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
							{
								
								Obten_Datos_THS(CORVAR.hgblConexion, 1);
								
								//UPGRADE_WARNING: (1042) Array pszArrTHSAct may need to have individual elements initialized.
								pszArrTHSAct = ArraysHelper.RedimPreserve<CORPROC2.tyEjecutivo[]>(pszArrTHSAct, new int[]{pszArrTHSAct.GetUpperBound(0) + 2});
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iPrefijo = iTHSPrefijo;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iBanco = iTHSBanco;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].lEmpresa = lTHSEmpresa;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].lNumero = lTHSNumero;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iRollOver = iTHSRollOver;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iDigito = iTHSDigito;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszNombre = szTHSNombre.Value;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszCalle = szTHSCalle.Value;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszColonia = szTHSColonia.Value;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszPoblacion = szTHSPoblacion.Value;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iZP = iTHSZP;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].lCP = lTHSCP;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszTelDom = lTHSTelDom.ToString();
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszTelOfi = lTHSTelOfi.ToString();
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszExt = lTHSExt.ToString();
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].dCredito = dTHSCredito;
								pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszRepSta = szTHSReposicion.Value;
								
							};
							
						} else
						{
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
							return;
							
						}
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
						
						for (int lCont = 1; lCont <= pszArrTHSAct.GetUpperBound(0); lCont++)
						{
							
							iTHSPrefijo = pszArrTHSAct[lCont].iPrefijo;
							iTHSBanco = pszArrTHSAct[lCont].iBanco;
							lTHSEmpresa = pszArrTHSAct[lCont].lEmpresa;
							lTHSNumero = pszArrTHSAct[lCont].lNumero;
							iTHSRollOver = pszArrTHSAct[lCont].iRollOver;
							iTHSDigito = pszArrTHSAct[lCont].iDigito;
							szTHSNombre.Value = pszArrTHSAct[lCont].pszNombre;
							szTHSCalle.Value = pszArrTHSAct[lCont].pszCalle;
							szTHSColonia.Value = pszArrTHSAct[lCont].pszColonia;
							szTHSPoblacion.Value = pszArrTHSAct[lCont].pszPoblacion;
							iTHSZP = pszArrTHSAct[lCont].iZP;
							lTHSCP = pszArrTHSAct[lCont].lCP;
							lTHSTelDom = Convert.ToInt32(Conversion.Val(pszArrTHSAct[lCont].pszTelDom));
							lTHSTelOfi = Convert.ToInt32(Conversion.Val(pszArrTHSAct[lCont].pszTelOfi));
							lTHSExt = Convert.ToInt32(Conversion.Val(pszArrTHSAct[lCont].pszExt));
							dTHSCredito = pszArrTHSAct[lCont].dCredito;
							szTHSReposicion.Value = pszArrTHSAct[lCont].pszRepSta;
							
							//EISSA 03-10-2001. Cambio para formateo del número de empresa y del número de ejecutivo.
							pszCuenta = StringsHelper.Format(iTHSPrefijo, "0000") + StringsHelper.Format(iTHSBanco, "00") + StringsHelper.Format(lTHSEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(lTHSNumero, Formato.sMascara(Formato.iTipo.Ejecutivo));
							
							if (Conversion.Val(szTHSReposicion.Value) == 0)
							{ //No existe la cuenta y da una alta en Ejecutivos con datos de THS
								
								if ( ~Inserta_Cuenta("THS") != 0)
								{
									lCtasNoDep++;
									szCadErr.Value = pszCuenta + " Error al intentar insertar la cuenta a la tabla de ejecutivos";
									FileSystem.FileOpen(1, CORVAR.pszgblPath + "Depura.err", OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1); //Abre el archivo para escribir la cuenta no depurada
									FileSystem.PrintLine(1, szCadErr.Value); //Escribe la cuenta
									FileSystem.FileClose(1); //Cierra el Archivo
								}
								
							} else
							{
								//Busca la cuenta en ejecutivos para dar de alta con los datos leidos de ejecutivos
								
								if (Existe_Cuenta_Eje(szTHSReposicion.Value) != 0)
								{ //Si existe la cuenta y da una alta en Ejecutivos con datos de Ejecutivos
									if ( ~Inserta_Cuenta("EJE") != 0)
									{
										lCtasNoDep++;
										szCadErr.Value = pszCuenta + " Error al intentar insertar la cuenta a la tabla de ejecutivos";
										FileSystem.FileOpen(1, CORVAR.pszgblPath + "Depura.err", OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1); //Abre el archivo para escribir la cuenta no depurada
										FileSystem.PrintLine(1, szCadErr.Value); //Escribe la cuenta
										FileSystem.FileClose(1); //Cierra el Archivo
									}
								}
							}
							
							ID_DEP_PORC_PNL.FloodPercent = Convert.ToInt16(50 + ((lCont / ((double) (pszArrTHSAct.GetUpperBound(0) + 1))) * 100) / 2); //Actualizamos la Barra de Porcentaje
							
							if (ID_DEP_PORC_PNL.FloodPercent >= 49)
							{
								ID_DEP_PORC_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE); //Cambiamos el color de la letra de negro a blanco
								this.Refresh();
							}
							
						}
						
					} else
					{
						ID_DEP_PORC_PNL.FloodPercent = 100;
					}
					
			}
			
			
			private int Existe_Cuenta_Eje( string pszCuenta)
			{
					
					int hStmt1 = 0;
					
					//Realiza la segunda Conexion
					intCont = CORDBLIB.Segunda_ConexionServidor();
					
					if (intCont == 0)
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						CORVAR.igblErr = (int) Interaction.MsgBox("No se pudo realizar la Depuración de Cuentas. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
						VBSQL.SqlClose(CORVAR.hgblConexion2); //Realiza Desconexión
						return 0;
					}
					
					int hTemp = CORVAR.hgblConexion;
					CORVAR.hgblConexion = CORVAR.hgblConexion2;
					
					int bExiste = 0;
					
					string pszPrefijo = Strings.Mid(pszCuenta, 1, 4);
					string pszBanco = Strings.Mid(pszCuenta, 5, 2);
					string pszEmpresa = Conversion.Val(Strings.Mid(pszCuenta, 7, Formato.sMascara(Formato.iTipo.Empresa).Length)).ToString();
					string pszEjecutivo = Conversion.Val(Strings.Mid(pszCuenta, 7 + Formato.sMascara(Formato.iTipo.Empresa).Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length)).ToString();
					
					CORVAR.pszgblsql = "SELECT gpo_banco,eje_prefijo,emp_num,eje_num,eje_roll_over,eje_digit,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nom_gra,eje_calle,eje_col,eje_pob,eje_zp,eje_cp,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_dom,eje_tel_ofi,eje_ext,eje_limcred,eje_status";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM " + CORBD.DB_SYB_EJE;
					CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + pszPrefijo;
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND gpo_banco = " + pszBanco;
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND emp_num = " + pszEmpresa;
					CORVAR.pszgblsql = CORVAR.pszgblsql + " AND eje_num = " + pszEjecutivo;
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{
							Obten_Datos_Eje(CORVAR.hgblConexion);
							bExiste = -1;
						}
						
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					CORVAR.hgblConexion = hTemp;
					
					//Realiza Desconexión
					VBSQL.SqlClose(CORVAR.hgblConexion2);
					
					return bExiste;
					
			}
			
			public void  Imprime_Linea( string pszCadena)
			{
					
					
					string iPaginaAnt = Conversion.Val(PrinterHelper.Printer.Page.ToString()).ToString();
					
					PrinterHelper.Printer.Print(pszCadena);
					
					string iPaginaDesp = Conversion.Val(PrinterHelper.Printer.Page.ToString()).ToString();
					
					if (iPaginaAnt != iPaginaDesp)
					{
						
						//    Printer.FontName = "Courier New"
						PrinterHelper.Printer.FontSize = 7;
						PrinterHelper.Printer.Print("Página: " + PrinterHelper.Printer.Page.ToString());
						
					}
					
			}
			
			public int Depura_Ejecutivos()
			{
					
					
					//Busca los datos entre EJE y THS
					CORVAR.pszgblsql = "SELECT  E.gpo_banco,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_prefijo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_roll_over,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_digit,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_nom_gra,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_calle,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_col,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_pob,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_zp,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_cp,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_tel_dom,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_tel_ofi,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_ext,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_limcred,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_status,";
					//THS
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.eje_prefijo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.gpo_banco,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.eje_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_nombre,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_direccion_1,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_direccion_2,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_direccion_3,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_zona_postal,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_codigo_postal,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_tel_particular,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_tel_oficina,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_tel_extension,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.eje_roll_over,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.eje_digit,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_limite_credito,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_reposicion ";
					
					CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM   MTCEJE01 E,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "        MTCTHS01 T";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE  E.gpo_banco = " + CORVAR.igblBanco.ToString();
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and    E.gpo_banco *= T.gpo_banco";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and    E.eje_prefijo *= T.eje_prefijo";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and    E.emp_num *= T.emp_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " and    E.eje_num *= T.eje_num";
					
					CORVAR.pszgblsql = CORVAR.pszgblsql + " order by E.gpo_banco,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "        E.eje_prefijo,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "        E.emp_num,";
					CORVAR.pszgblsql = CORVAR.pszgblsql + "        E.eje_num";
					
					int lTotReg = CORPROC2.Cuenta_Registros();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						{
							
							Obten_Datos_Eje(CORVAR.hgblConexion);
							Obten_Datos_THS(CORVAR.hgblConexion, 18);
							
							//Si no hay registro para THS...
							if (iTHSPrefijo == CORVB.NULL_INTEGER && iTHSBanco == CORVB.NULL_INTEGER && lTHSEmpresa == CORVB.NULL_INTEGER && lTHSNumero == CORVB.NULL_INTEGER && szTHSNombre.Value.Trim() == CORVB.NULL_STRING && iTHSRollOver == CORVB.NULL_INTEGER && iTHSDigito == CORVB.NULL_INTEGER)
							{
								
								//UPGRADE_WARNING: (1042) Array pszArrEjeBor may need to have individual elements initialized.
								pszArrEjeBor = ArraysHelper.RedimPreserve<CORPROC2.tyEjecutivo[]>(pszArrEjeBor, new int[]{pszArrEjeBor.GetUpperBound(0) + 2});
								pszArrEjeBor[pszArrEjeBor.GetUpperBound(0)].iPrefijo = iEjePrefijo;
								pszArrEjeBor[pszArrEjeBor.GetUpperBound(0)].iBanco = iEjeBanco;
								pszArrEjeBor[pszArrEjeBor.GetUpperBound(0)].lEmpresa = lEjeEmpresa;
								pszArrEjeBor[pszArrEjeBor.GetUpperBound(0)].lNumero = lEjeNumero;
								
							} else
							{
								
								if (iEjeBanco != iTHSBanco || iEjePrefijo != iTHSPrefijo || lEjeEmpresa != lTHSEmpresa || lEjeNumero != lTHSNumero || iEjeRollOver != iTHSRollOver || iEjeDigito != iTHSDigito || szEjeNombre.Value != szTHSNombre.Value || szEjeCalle.Value != szTHSCalle.Value || szEjeColonia.Value != szTHSColonia.Value || szEjePoblacion.Value != szTHSPoblacion.Value || iEjeZP != iTHSZP || lEjeCP != lTHSCP || szEjeTelDom.Value.Trim() != lTHSTelDom.ToString() || szEjeTelOfi.Value.Trim() != lTHSTelOfi.ToString() || szEjeExt.Value.Trim() != lTHSExt.ToString() || dEjeCredito != dTHSCredito)
								{
									
									//UPGRADE_WARNING: (1042) Array pszArrEjeAct may need to have individual elements initialized.
									pszArrEjeAct = ArraysHelper.RedimPreserve<CORPROC2.tyEjecutivo[]>(pszArrEjeAct, new int[]{pszArrEjeAct.GetUpperBound(0) + 2});
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].iPrefijo = iEjePrefijo;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].iBanco = iEjeBanco;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].lEmpresa = lEjeEmpresa;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].lNumero = lEjeNumero;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].iRollOver = iEjeRollOver;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].iDigito = iEjeDigito;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].pszNombre = szEjeNombre.Value;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].pszCalle = szEjeCalle.Value;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].pszColonia = szEjeColonia.Value;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].pszPoblacion = szEjePoblacion.Value;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].iZP = iEjeZP;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].lCP = lEjeCP;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].pszTelDom = szEjeTelDom.Value;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].pszTelOfi = szEjeTelOfi.Value;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].pszExt = szEjeExt.Value;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].dCredito = dEjeCredito;
									pszArrEjeAct[pszArrEjeAct.GetUpperBound(0)].pszRepSta = szEjeStatus.Value;
									
									//UPGRADE_WARNING: (1042) Array pszArrTHSAct may need to have individual elements initialized.
									pszArrTHSAct = ArraysHelper.RedimPreserve<CORPROC2.tyEjecutivo[]>(pszArrTHSAct, new int[]{pszArrTHSAct.GetUpperBound(0) + 2});
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iPrefijo = iTHSPrefijo;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iBanco = iTHSBanco;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].lEmpresa = lTHSEmpresa;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].lNumero = lTHSNumero;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iRollOver = iTHSRollOver;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iDigito = iTHSDigito;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszNombre = szTHSNombre.Value;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszCalle = szTHSCalle.Value;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszColonia = szTHSColonia.Value;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszPoblacion = szTHSPoblacion.Value;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].iZP = iTHSZP;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].lCP = lTHSCP;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszTelDom = lTHSTelDom.ToString();
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszTelOfi = lTHSTelOfi.ToString();
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszExt = lTHSExt.ToString();
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].dCredito = dTHSCredito;
									pszArrTHSAct[pszArrTHSAct.GetUpperBound(0)].pszRepSta = szTHSReposicion.Value;
									
								}
								
							}
							
						};
						
					} else
					{
						
						if (Conversion.Val(CORVAR.igblRetorna.ToString()) != VBSQL.SUCCEED)
						{
							
							this.Cursor = Cursors.Default;
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
							//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
							CORVAR.igblErr = (int) Interaction.MsgBox("No se pudo realizar la Depuración de Cuentas. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
							return 0;
							
						}
						
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
					
					return lTotReg;
					
			}
			
			private void  CORDEPUR_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != eventSender)
					{
						ActivateHelper.myActiveForm = (Form) eventSender;
						this.Cursor = Cursors.Default;
					}
			}
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
					this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);
					
					bCanProc = 0; //Inicializamos a false la cancelacion del proceso de integracion
					object[] larrEmpresas = new object[CORVB.NULL_INTEGER + 1];
					
					
			}
			
			private void  CORDEPUR_Closed( Object eventSender,  EventArgs eventArgs)
			{
					VBSQL.subCanConRec(ref intCont);
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
			
			private void  ID_DEP_ACE_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					
					this.Cursor = Cursors.WaitCursor;
					
					//Hacemos visible el panel de porcentaje e invisibles los demas controles
					ID_DEP_PRI_FRM.Visible = false;
					ID_DEP_ACE_PB.Visible = false;
					ID_DEP_SAL_PB.Visible = false;
					ID_DEP_PORC_PNL.Visible = true;
					ID_DEP_CAN_PB.Visible = true;
					this.Refresh();
					
					ID_DEP_PORC_PNL.FloodPercent = 0; //Inicializamos la barra de Porcentaje del MDI al cero porciento
					ID_DEP_PORC_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight; //Indicamos que el porcentaje de avance será de izq. a der.
					
					if (ID_DEP_ARC_OPB[0].Value)
					{ //Depuración de Cuentas
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = "Realizando la Depuración de Cuentas";
						Application.DoEvents();
						Dep_Cuentas();
						
					} else if (ID_DEP_ARC_OPB[1].Value) {  //Depuración de Aclaraciones
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = "Realizando la Depuración de Aclaraciones";
						Application.DoEvents();
						Dep_Aclaraciones();
						
					} else if (ID_DEP_ARC_OPB[2].Value) {  //Depuración de Bitacora
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = "Realizando la Depuración de la Bitácora";
						Application.DoEvents();
						Dep_Bitacora();
						
					} else if (ID_DEP_ARC_OPB[3].Value) { 
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = "Realizando la Estadística de Cuentas";
						Application.DoEvents();
						ID_DEP_EST_PNL.Visible = true;
						
						Obten_Status_Cuentas();
						
					}
					
					Application.DoEvents();
					int hAccion = Application.OpenForms.Count; //Capturamos el evento cancelar
					
					if (bCanProc != 0)
					{
						
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = "La Exportación fué Interrumpida. Reintente";
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; //Limpiamos el Status Bar
						this.Close(); //Descargamos la forma
						return; //Terminamos el procedimiento
						
					} else
					{
						
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("Se realizó la operación con éxito.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
						
					}
					
					this.Refresh();
					
					if (ID_DEP_PORC_PNL.FloodPercent > CORVB.NULL_INTEGER)
					{
						ID_DEP_PORC_PNL.FloodPercent = 100; //Actualizamos la Barra de Porcentaje
						CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; //Limpiamos el Status Bar
						ID_DEP_PORC_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK); //Cambiamos el color de la letra de blanco a negro
					}
					
					//Hacemos visible el panel de porcentaje e invisibles los demas controles
					ID_DEP_PRI_FRM.Visible = true;
					ID_DEP_ACE_PB.Visible = true;
					ID_DEP_SAL_PB.Visible = true;
					ID_DEP_PORC_PNL.Visible = false;
					ID_DEP_CAN_PB.Visible = false;
					this.Refresh();
					
					this.Cursor = Cursors.Default;
					
			}
			
			
			private void  ID_DEP_ARC_OPB_ClickEvent( Object eventSender,  AxThreed.ISSRBCtrlEvents_ClickEvent eventArgs)
			{
					int Index = Array.IndexOf(ID_DEP_ARC_OPB, eventSender);
					
					if (Index != 3)
					{
						ID_DEP_EST_PNL.Visible = false;
						ID_DEP_IMP_PB.Visible = false;
					} else
					{
						ID_DEP_EST_PNL.Visible = true;
						ID_DEP_IMP_PB.Visible = true;
					}
					
			}
			
			private void  ID_DEP_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					bCanProc = -1;
					
			}
			
			private void  ID_DEP_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							this.Cursor = Cursors.WaitCursor;
							
							PrinterHelper.Printer.Orientation = (int) PrinterHelper.PrinterObjectConstants.vbPRORPortrait;
							//  Printer.FontName = "Courier New"
							PrinterHelper.Printer.FontBold = true;
							
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(new String(' ', 30) + "Reporte de Depuración de Cuentas");
							Imprime_Linea(new String(' ', 40) + DateTime.Now.ToString("dd/MMM/yy"));
							
							PrinterHelper.Printer.FontSize = 7;
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(new String(' ', 20) + "Cuenta           Descripción");
							PrinterHelper.Printer.FontBold = false;
							
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(new String(' ', 10) + new string('-', 20) + "Diferencia en el Roll Over");
							Imprime_Linea(CORVB.NULL_STRING);
							for (int iCont = CORVB.NULL_INTEGER; iCont <= ID_DEP_DIG_COB.Items.Count; iCont++)
							{
								Imprime_Linea(new String(' ', 10) + VB6.GetItemString(ID_DEP_DIG_COB, iCont - 1));
							}
							
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(new String(' ', 10) + new string('-', 20) + "Diferencia en Datos Generales");
							Imprime_Linea(CORVB.NULL_STRING);
							for (int iCont = CORVB.NULL_INTEGER; iCont <= ID_DEP_DUP_COB.Items.Count; iCont++)
							{
								Imprime_Linea(new String(' ', 10) + VB6.GetItemString(ID_DEP_DUP_COB, iCont - 1));
							}
							
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(new String(' ', 10) + new string('-', 20) + "Sobran en Ejecutivos");
							Imprime_Linea(CORVB.NULL_STRING);
							for (int iCont = CORVB.NULL_INTEGER; iCont <= ID_DEP_EJE_COB.Items.Count; iCont++)
							{
								Imprime_Linea(new String(' ', 10) + VB6.GetItemString(ID_DEP_EJE_COB, iCont - 1));
							}
							
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(new String(' ', 10) + new string('-', 20) + "Sobran en THS");
							Imprime_Linea(CORVB.NULL_STRING);
							for (int iCont = CORVB.NULL_INTEGER; iCont <= ID_DEP_THS_COB.Items.Count; iCont++)
							{
								Imprime_Linea(new String(' ', 10) + VB6.GetItemString(ID_DEP_THS_COB, iCont - 1));
							}
							
							Imprime_Linea(new String(' ', 10) + new string('-', 20));
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(CORVB.NULL_STRING);
							Imprime_Linea(new String(' ', 10) + "Registros leídos de la tabla de Ejecutivos =  " + ID_DEP_EST_TXT[6].Text);
							Imprime_Linea(new String(' ', 10) + "Registros leídos de la tabla de THS        =  " + ID_DEP_EST_TXT[7].Text);
							
							PrinterHelper.Printer.EndDoc();
							
							this.Cursor = Cursors.Default;
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			private void  ID_DEP_SAL_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
					this.Close();
					
			}
			
			private int Inserta_Cuenta( string pszTipo)
			{
					
					int hStmt = 0;
					
					int bInserta = 0;
					
					switch(pszTipo)
					{
						case "EJE" : 
							if (iEjeBanco != CORVB.NULL_INTEGER)
							{
								if (iEjePrefijo != CORVB.NULL_INTEGER)
								{
									if (lEjeEmpresa != CORVB.NULL_INTEGER)
									{
										if (lEjeNumero != CORVB.NULL_INTEGER)
										{
											if (iEjeRollOver >= CORVB.NULL_INTEGER)
											{
												if (iEjeDigito >= CORVB.NULL_INTEGER)
												{
													if (szEjeNombre.Value.Trim() != CORVB.NULL_STRING)
													{
														if (dEjeCredito != CORVB.NULL_INTEGER)
														{
															bInserta = -1;
															CORVAR.pszgblsql = "INSERT INTO " + CORBD.DB_SYB_EJE;
															CORVAR.pszgblsql = CORVAR.pszgblsql + " VALUES (";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSPrefijo.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSBanco.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + lTHSEmpresa.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + lTHSNumero.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSRollOver.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSDigito.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szEjeNombre.Value.Trim() + "','',0,0,'0',0,";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szEjeNombre.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szEjeCalle.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szEjeColonia.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szEjePoblacion.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iEjeZP.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + lEjeCP.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szEjeTelDom.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szEjeTelOfi.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szEjeExt.Value.Trim() + "','',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + dEjeCredito.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "1,'T','0',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'0','0','0','0','0'";
														}
													}
												}
											}
										}
									}
								}
							} 
							 
							break;
						case "THS" : 
							if (iTHSBanco != CORVB.NULL_INTEGER)
							{
								if (iTHSPrefijo != CORVB.NULL_INTEGER)
								{
									if (lTHSEmpresa != CORVB.NULL_INTEGER)
									{
										if (lTHSNumero != CORVB.NULL_INTEGER)
										{
											if (iTHSRollOver >= CORVB.NULL_INTEGER)
											{
												if (iTHSDigito >= CORVB.NULL_INTEGER)
												{
													if (szTHSNombre.Value.Trim() != CORVB.NULL_STRING)
													{
														if (dTHSCredito != CORVB.NULL_INTEGER)
														{
															bInserta = -1;
															CORVAR.pszgblsql = "INSERT INTO " + CORBD.DB_SYB_EJE;
															CORVAR.pszgblsql = CORVAR.pszgblsql + " VALUES (";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSPrefijo.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSBanco.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + lTHSEmpresa.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + lTHSNumero.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSRollOver.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSDigito.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szTHSNombre.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'Nada',0,0,'0',0,";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szTHSNombre.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szTHSCalle.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szTHSColonia.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szTHSPoblacion.Value.Trim() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + iTHSZP.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + lTHSCP.ToString() + ",";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + lTHSTelDom.ToString() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + lTHSTelOfi.ToString() + "',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + lTHSExt.ToString() + "','0',";
															CORVAR.pszgblsql = CORVAR.pszgblsql + dTHSCredito.ToString() + ",1,'T','0','0','0','0','0','0'";
														}
													}
												}
											}
										}
									}
								}
							} 
							break;
					}
					
					if (bInserta != 0)
					{
						CORVAR.pszgblsql = CORVAR.pszgblsql + ")";
						
						if (CORPROC2.Modifica_Registro() != 0)
						{
							return -1;
						} else
						{
							return 0;
						}
						
					} else
					{
						return 0;
					}
					
			}
			
			private void  Obten_Datos_Eje( int hStmtEje)
			{
					
					iEjeBanco = CORVB.NULL_INTEGER;
					iEjePrefijo = CORVB.NULL_INTEGER;
					lEjeEmpresa = CORVB.NULL_INTEGER;
					lEjeNumero = CORVB.NULL_INTEGER;
					iEjeRollOver = CORVB.NULL_INTEGER;
					iEjeDigito = CORVB.NULL_INTEGER;
					szEjeNombre.Value = CORVB.NULL_STRING;
					szEjeCalle.Value = CORVB.NULL_STRING;
					szEjeColonia.Value = CORVB.NULL_STRING;
					szEjePoblacion.Value = CORVB.NULL_STRING;
					iEjeZP = CORVB.NULL_INTEGER;
					lEjeCP = CORVB.NULL_INTEGER;
					szEjeTelDom.Value = CORVB.NULL_STRING;
					szEjeTelOfi.Value = CORVB.NULL_STRING;
					szEjeExt.Value = CORVB.NULL_STRING;
					dEjeCredito = CORVB.NULL_INTEGER;
					szEjeStatus.Value = CORVB.NULL_STRING;
					
					iEjeBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
					iEjePrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
					lEjeEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
					lEjeNumero = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
					iEjeRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
					iEjeDigito = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
					szEjeNombre.Value = VBSQL.SqlData(CORVAR.hgblConexion, 7);
					szEjeCalle.Value = VBSQL.SqlData(CORVAR.hgblConexion, 8);
					szEjeColonia.Value = VBSQL.SqlData(CORVAR.hgblConexion, 9);
					szEjePoblacion.Value = VBSQL.SqlData(CORVAR.hgblConexion, 10);
					iEjeZP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11)));
					lEjeCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12)));
					szEjeTelDom.Value = VBSQL.SqlData(CORVAR.hgblConexion, 13);
					szEjeTelOfi.Value = VBSQL.SqlData(CORVAR.hgblConexion, 14);
					szEjeExt.Value = VBSQL.SqlData(CORVAR.hgblConexion, 15);
					dEjeCredito = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 16));
					szEjeStatus.Value = VBSQL.SqlData(CORVAR.hgblConexion, 17);
					
			}
			
			private void  Obten_Datos_THS( int hStmtTHS,  int iPosIni)
			{
					
					iTHSPrefijo = CORVB.NULL_INTEGER;
					iTHSBanco = CORVB.NULL_INTEGER;
					lTHSEmpresa = CORVB.NULL_INTEGER;
					lTHSNumero = CORVB.NULL_INTEGER;
					szTHSNombre.Value = CORVB.NULL_STRING;
					szTHSCalle.Value = CORVB.NULL_STRING;
					szTHSColonia.Value = CORVB.NULL_STRING;
					szTHSPoblacion.Value = CORVB.NULL_STRING;
					iTHSZP = CORVB.NULL_INTEGER;
					lTHSCP = CORVB.NULL_INTEGER;
					lTHSTelDom = CORVB.NULL_INTEGER;
					lTHSTelOfi = CORVB.NULL_INTEGER;
					lTHSExt = CORVB.NULL_INTEGER;
					iTHSRollOver = CORVB.NULL_INTEGER;
					iTHSDigito = CORVB.NULL_INTEGER;
					dTHSCredito = CORVB.NULL_INTEGER;
					szTHSReposicion.Value = CORVB.NULL_STRING;
					
					iTHSPrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni)));
					iTHSBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 1)));
					lTHSEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 2)));
					lTHSNumero = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 3)));
					szTHSNombre.Value = VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 4);
					szTHSCalle.Value = VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 5);
					szTHSColonia.Value = VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 6);
					szTHSPoblacion.Value = VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 7);
					iTHSZP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 8)));
					lTHSCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 9)));
					lTHSTelDom = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 10)));
					lTHSTelOfi = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 11)));
					lTHSExt = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 12)));
					iTHSRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 13)));
					iTHSDigito = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 14)));
					dTHSCredito = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 15));
					szTHSReposicion.Value = VBSQL.SqlData(CORVAR.hgblConexion, iPosIni + 16);
					
			}
			
			private string Obten_Fecha()
			{
					
					
					int iDia = DateAndTime.Day(DateTime.Now);
					int iMesAct = DateTime.Now.Month;
					int iAñoAct = DateTime.Now.Year;
					
					double iFecha = Convert.ToDouble(DateAndTime.DateSerial(iAñoAct, iMesAct - 6, iDia).ToOADate());
					
					iDia = DateAndTime.Day(DateTime.FromOADate(iFecha));
					iMesAct = DateTime.FromOADate(iFecha).Month;
					iAñoAct = DateTime.FromOADate(iFecha).Year;
					
					string pszFechAnt = StringsHelper.Format(iAñoAct, "0000") + StringsHelper.Format(iMesAct, "00") + StringsHelper.Format(iDia, "00");
					return pszFechAnt;
					
			}
			
			private void  Obten_Status_Cuentas()
			{
					
					int hStmt = 0;
					int iStatusTHS = 0;
					int iCont = 0;
					string pszCuenta = String.Empty;
					StringBuilder pszCampos = new StringBuilder();
					pszCampos.Append(String.Empty);
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							ID_DEP_EJE_COB.Items.Clear();
							ID_DEP_DIG_COB.Items.Clear();
							ID_DEP_DUP_COB.Items.Clear();
							ID_DEP_THS_COB.Items.Clear();
							ID_DEP_EST_TXT[6].Text = CORVB.NULL_STRING;
							ID_DEP_EST_TXT[7].Text = CORVB.NULL_STRING;
							
							int lNumRegs = CORVB.NULL_INTEGER;
							
							//Busca los datos entre EJE y THS
							CORVAR.pszgblsql = "SELECT  E.gpo_banco,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_prefijo,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.emp_num,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_num,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_roll_over,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_digit,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_nom_gra,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_calle,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_col,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_pob,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_zp,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_cp,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_tel_dom,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_tel_ofi,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_ext,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_limcred,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  E.eje_status,";
							//THS
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.eje_prefijo,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.gpo_banco,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.emp_num,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.eje_num,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_nombre,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_direccion_1,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_direccion_2,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_direccion_3,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_zona_postal,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_codigo_postal,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_tel_particular,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_tel_oficina,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_tel_extension,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.eje_roll_over,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.eje_digit,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_limite_credito,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "  T.ths_reposicion ";
							
							CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM   MTCEJE01 E,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "        MTCTHS01 T";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE  E.gpo_banco = " + CORVAR.igblBanco.ToString();
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and    E.gpo_banco *= T.gpo_banco";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and    E.eje_prefijo *= T.eje_prefijo";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and    E.emp_num *= T.emp_num";
							CORVAR.pszgblsql = CORVAR.pszgblsql + " and    E.eje_num *= T.eje_num";
							
							CORVAR.pszgblsql = CORVAR.pszgblsql + " order by E.gpo_banco,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "        E.eje_prefijo,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "        E.emp_num,";
							CORVAR.pszgblsql = CORVAR.pszgblsql + "        E.eje_num";
							
							int lTotRegs = CORPROC2.Cuenta_Registros();
							
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
								{
									
									pszCampos = new StringBuilder(CORVB.NULL_STRING);
									
									Obten_Datos_Eje(CORVAR.hgblConexion);
									Obten_Datos_THS(CORVAR.hgblConexion, 18);
									
									//Si no hay registro para THS...
									if (iTHSPrefijo == CORVB.NULL_INTEGER && iTHSBanco == CORVB.NULL_INTEGER && lTHSEmpresa == CORVB.NULL_INTEGER && lTHSNumero == CORVB.NULL_INTEGER && szTHSNombre.Value.Trim() == CORVB.NULL_STRING && iTHSRollOver == CORVB.NULL_INTEGER && iTHSDigito == CORVB.NULL_INTEGER)
									{
										
										//No existe en THS
										iStatusTHS = CORVB.NULL_INTEGER;
									} else
									{
										//Existe en THS
										iStatusTHS = 1;
									}
									
									//EISSA 03-10-2001. Cambio para formateo de número de empresa y número de ejecutivo.
									pszCuenta = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iEjeBanco, "00") + StringsHelper.Format(lEjeEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(lEjeNumero, Formato.sMascara(Formato.iTipo.Ejecutivo));
									
									switch(iStatusTHS)
									{
										case CORVB.NULL_INTEGER : 
											 
											if (szEjeStatus.Value == "T")
											{
												ID_DEP_EJE_COB.Items.Add(pszCuenta + " Existe en Ejecutivos y no en THS. Será Borrado por Depuración");
											} else
											{
												ID_DEP_EJE_COB.Items.Add(pszCuenta + " Existe en Ejecutivos y no en THS.");
											} 
											 
											//Se encuentra el registro en el THS 
											break;
										case 1 : 
											 
											if (iEjeRollOver != iTHSRollOver)
											{
												ID_DEP_DIG_COB.Items.Add(pszCuenta + " Cambio del Roll Over de " + iEjeRollOver.ToString() + " a " + iTHSRollOver.ToString());
											} 
											//Veifica que campos cambiaron 
											if (szEjeNombre.Value.Trim() != szTHSNombre.Value.Trim())
											{
												pszCampos.Append("Nombre,");
											} 
											if (iEjeDigito != iTHSDigito)
											{
												pszCampos.Append("Digito Verificador,");
											} 
											if (szEjeCalle.Value.Trim() != szTHSCalle.Value.Trim())
											{
												pszCampos.Append("Calle,");
											} 
											if (szEjeColonia.Value.Trim() != szTHSColonia.Value.Trim())
											{
												pszCampos.Append("Colonia,");
											} 
											if (szEjePoblacion.Value.Trim() != szTHSPoblacion.Value.Trim())
											{
												pszCampos.Append("Población,");
											} 
											if (lEjeCP != lTHSCP)
											{
												pszCampos.Append("Código Postal,");
											} 
											if (Conversion.Val(szEjeTelDom.Value) != lTHSTelDom)
											{
												pszCampos.Append("Tel. Dom.,");
											} 
											if (Conversion.Val(szEjeTelOfi.Value) != lTHSTelOfi)
											{
												pszCampos.Append("Tel. Ofi.,");
											} 
											if (Conversion.Val(szEjeExt.Value) != lTHSExt)
											{
												pszCampos.Append("Extensión,");
											} 
											if (dEjeCredito != dTHSCredito)
											{
												pszCampos.Append("Crédito");
											} 
											 
											if (pszCampos.ToString().Length != 0)
											{
												ID_DEP_DUP_COB.Items.Add(pszCuenta + " Cambio de campos en: " + pszCampos.ToString());
											} 
											 
											//Ocurrio un error al obtener el registro 
											break;
										case -5 : 
											 
											CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); 
											return; 
											 
											break;
									}
									
									lNumRegs++;
									
									ID_DEP_PORC_PNL.FloodPercent = Convert.ToInt16(((lNumRegs * 100) / ((double) lTotRegs)) / 2); //Actualizamos la Barra de Porcentaje
									
									if (ID_DEP_PORC_PNL.FloodPercent >= 49)
									{
										ID_DEP_PORC_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE); //Cambiamos el color de la letra de negro a blanco
										this.Refresh();
									}
									
								};
								
							} else
							{
								
								if (Conversion.Val(CORVAR.igblRetorna.ToString()) != VBSQL.SUCCEED)
								{
									
									this.Cursor = Cursors.Default;
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
									//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
									CORVAR.igblErr = (int) Interaction.MsgBox("No se pudo realizar la Depuración de Cuentas. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
									bCanProc = 0;
									return;
									
								}
								
							}
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
							
							if ( ~Busca_Diferentes_THS() != 0)
							{
								this.Cursor = Cursors.Default;
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
								//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
								CORVAR.igblErr = (int) Interaction.MsgBox("No se pudo realizar la Depuración de Cuentas. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
								return;
							}
							
							//Arroja resultados
							ID_DEP_EST_TXT[6].Text = StringsHelper.Format(lNumRegs, "####0");
							ID_DEP_EST_TXT[7].Text = StringsHelper.Format(Obten_Num_THS(), "####0");
							
							//Llena el indicador a 100% realizado
							ID_DEP_PORC_PNL.FloodPercent = 100;
							
							//Coloca el apuntador al primero en ListBox
							if (ID_DEP_EJE_COB.Items.Count != 0)
							{
								ID_DEP_EJE_COB.SelectedIndex = CORVB.NULL_INTEGER;
							}
							
							if (ID_DEP_DIG_COB.Items.Count != 0)
							{
								ID_DEP_DIG_COB.SelectedIndex = CORVB.NULL_INTEGER;
							}
							
							if (ID_DEP_DUP_COB.Items.Count != 0)
							{
								ID_DEP_DUP_COB.SelectedIndex = CORVB.NULL_INTEGER;
							}
							
							if (ID_DEP_THS_COB.Items.Count != 0)
							{
								ID_DEP_THS_COB.SelectedIndex = CORVB.NULL_INTEGER;
							}
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			public int Obten_Num_THS()
			{
					
					CORVAR.pszgblsql = "SELECT eje_num";
					CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCTHS01";
					
					return CORPROC2.Cuenta_Registros();
					
			}
		}
}