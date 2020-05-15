using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using Microsoft.VisualBasic.Compatibility.VB6; 
using System; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class CORGRCOR
		: System.Windows.Forms.Form
		{
		
			private void  CORGRCOR_Activated( Object eventSender,  EventArgs eventArgs)
			{
					if (ActivateHelper.myActiveForm != this)
					{
						ActivateHelper.myActiveForm = this;
					}
			}
			//****************************************************************************
			//**                                                                        **
			//**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
			//**                                                                        **
			//**       --------------------------------------------------------         **
			//**                                                                        **
			//**       Descripción: Grafica los Productos por meses de vencido,         **
			//**                    las Empresas por meses vencidos           ,         **
			//**                    y la Cartera vigente y la vencida                   **
			//**                                                                        **
			//**       Responsable: Hugo L. Morales Garcia                              **
			//**                                                                        **
			//**       Ultima Fecha de Modificación: 06/Junio/1994                      **
			//**                                                                        **
			//**       NOTA: Esta forma necesita Visual Basic 3.0                       **
			//**                                                                        **
			//****************************************************************************
			
			int iErr = 0; //Error Local
			//AIS-1178 NGONZALEZ
			CORVAR.DatosCorpo[] iArrParamEJEG;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});; //Arreglo donde se guardan los Datos a Graficar
			//AIS-1178 NGONZALEZ
			CORVAR.DatosCorpo[] iArrParamEMPG;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});; //Arreglo donde se guardan los Datos a Graficar
			//AIS-1178 NGONZALEZ
			CORVAR.DatosCorpo[] iArrParamDETG;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});; //Arreglo donde se guardan los Datos a Graficar
			int hConexion = 0;
			int hBufGrupos = 0; //Apunta al SQL de hGrupos
			string pszSQL = String.Empty;
			int iGruposRestantes = 0;
			int iTotalGrupos = 0;
			
			int lTotalRegEJEG = 0; //El parámetro que se empareja al INT_MAX_PARAM0%
			int lRegsLeidosEJEG = 0; //Los Registros que conforman los NumPoints
			int lDatosGrafEJEG = 0; //El que resta por Graficar
			
			int lTotalRegEMPG = 0;
			int lRegsLeidosEMPG = 0;
			int lDatosGrafEMPG = 0;
			
			int lContador = 0;
			
			int lTotalRegDETG = 0;
			int lRegsLeidosDETG = 0;
			int lDatosGrafDETG = 0;
			
			int bGrafMax = 0;
			int iTop = 0;
			int iLeft = 0;
			int iWidth = 0;
			int iHeight = 0;
			
			const string STR_ONCEAVO = "11  OTROS";
			const string STR_COMPLEMENTO = "OTROS";
			const string STR_LEFTTIT_EJEGRU_C = "Ejecutivos";
			const string STR_BOTTOMTIT_EJEGRU = "Corporativos";
			const string STR_GRAPHTIT_EJEGRU = "Corporativo - Ejecutivos";
			const string STR_LEFTTIT_EMPGRU_C = "Empresas";
			const string STR_BOTTOMTIT_EJEGRU_C = "Empresas";
			const string STR_GRAPHTIT_EMPGRU = "Corporativo - Empresas";
			const int INT_FONTSIZE_TIT = 150;
			const int INT_FONTSIZE_OTROS = 100;
			const int INT_MAX_PARAM = 10;
			const int INT_MAX_GRUPOS = 999;
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga los Grupos corporativos existentes en el      **
			//**                    Catálogo de Grupos (CMTCOR01) a un Combo Box -      **
			//**                    y que se utilizaran para Gráficas
			//**                                                                        **
			//**       Declaración: Function Carga_Grupos() as integer                  **
			//**                                                                        **
			//**       Paso de parámetros: Ninguno                                      **
			//**                                                                        **
			//**       Valor de Regreso: El número de registros leídos                  **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : iErr                                            **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private int Carga_Grupos()
			{
					
					string pszNomGrupo = String.Empty; //El grupo a obtener
					int iNumGrupo = 0; //El consecutivo del grupo
					int iTempErr = 0; //Para control local
					int iCont = 0;
					
					this.Cursor = Cursors.WaitCursor;
					iErr = CORCONST.OK;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					// pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco=" + Format$(igblBanco) + " order by gpo_num "
					//*****  FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " order by gpo_num ";
					//*****  FIN DE CODIGO NUEVO FSWBMX *****
					
					//ros iTotalGrupos = Cuenta_Registros
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						ID_GRA_GRU_COB.Items.Clear();
						iCont = CORVB.NULL_INTEGER;
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS && iCont < INT_MAX_GRUPOS)
						{
							iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							ID_GRA_GRU_COB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
							iCont++;
						};
						//Colocamos a un grupo por default
						if (ID_GRA_GRU_COB.Items.Count != 0)
						{
							ID_GRA_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
						}
					} else
					{
						this.Cursor = Cursors.Default;
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					//ros  iGruposRestantes = iTotalGrupos - iCont
					return iCont;
					
			}
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga a la gráfica(el objeto) los datos necesarios  **
			//**                    guardados en el arreglo correspondiente             **
			//**                                                                        **
			//**       Declaración: Function Grafica_Param()                            **
			//**                                                                        **
			//**       Paso de parámetros: iArrDatos() - El arreglo a graficar          **
			//**                                                                        **
			//**       Valor de Regreso: lRegsLeidosPMV - registros leídos              **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : pszSQL - Cadena de SQL                          **
			//**                        iErr   - Error generado                         **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private void  Grafica_Param( CORVAR.DatosCorpo[] iArrDatos)
			{
					
					
					Pon_Titulos();
					
					if (iArrDatos.GetUpperBound(0) > 0)
					{
						ID_GRA_GPH.NumPoints = (short) (iArrDatos.GetUpperBound(0) + 1);
					} else
					{
						ID_GRA_GPH.NumPoints = 2;
					}
					
					ID_GRA_GPH.ThisPoint = 1;
					for (int iCont = 0; iCont <= iArrDatos.GetUpperBound(0); iCont++)
					{
						ID_GRA_GPH.GraphData = iArrDatos[iCont].iCantidad;
					}
					
					ID_GRA_GPH.ThisPoint = 1;
					for (int iCont = 0; iCont <= iArrDatos.GetUpperBound(0); iCont++)
					{
						ID_GRA_GPH.LegendText = StringsHelper.Format(iCont + 1, "00") + "  " + iArrDatos[iCont].pszDescripcion.ToUpper();
					}
					
			}
			
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga los Datos correspondientes para Graficar      **
			//**                    los Ejecutivos por cada empresa de cada grupo       **
			//**                                                                        **
			//**       Declaración: Function Carga_DetGrupo() as integer                **
			//**                                                                        **
			//**       Paso de parámetros: iNumGrupo - El grupo a graficar              **
			//**                                                                        **
			//**       Valor de Regreso: El número de registros leídos                  **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : pszSQL - La cadena SQL                          **
			//**                      : iErr   - La cadena SQL                          **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private int Datos_DetGrupo( int iNumGrupo)
			{
					
					int result = 0;
					int hBufEjecEmp = 0;
					int iTempErr = 0;
					FixedLengthString szNomEmpresa = new FixedLengthString(45);
					int iCont = 0;
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							Cursor = Cursors.WaitCursor;
							
							iErr = CORCONST.OK;
							
							//ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
							//***** INICIO CODIGO ANTERIOR FSWBMX *****
							// pszgblsql = "exec carga_emp " + Format$(igblBanco) + "," + Format$(iNumGrupo)
							//*****  FIN DE CODIGO ANTERIOR FSWBMX *****
							//***** INICIO CODIGO NUEVO FSWBMX *****
							CORVAR.pszgblsql = "exec carga_emp " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + iNumGrupo.ToString();
							//*****  FIN DE CODIGO NUEVO FSWBMX *****
							
							
							lRegsLeidosDETG = CORPROC2.Cuenta_Registros();
							if (CORPROC2.Obtiene_Registros() != 0)
							{
								if (lRegsLeidosDETG != 0)
								{
									//UPGRADE_WARNING: (1042) Array iArrParamDETG may need to have individual elements initialized.
									iArrParamDETG = new CORVAR.DatosCorpo[lRegsLeidosDETG + 1]; //
								} else
								{
									Cursor = Cursors.Default;
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
									return lRegsLeidosDETG;
								}
								
								iCont = CORVB.NULL_INTEGER;
								lDatosGrafDETG = CORVB.NULL_INTEGER;
								
								
								while(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS && iCont < INT_MAX_PARAM)
								{
									//Obtenemos y los asignamos al arreglo correspondiente
									iArrParamDETG[iCont].iCantidad = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
									//Acumulamos para sacar despues la diferencia contra los otros
									lDatosGrafDETG += iArrParamDETG[iCont].iCantidad;
									szNomEmpresa.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
									iArrParamDETG[iCont].pszDescripcion = szNomEmpresa.Value.Trim();
									iCont++;
								};
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								
								//Sacamos el total de los ejecutivos
								//***** INICIO CODIGO ANTERIOR FSWBMX *****
								//   pszgblsql = "select emp_num from " + DB_SYB_EJE + " where gpo_banco=" + Format$(igblBanco)
								//*****  FIN DE CODIGO ANTERIOR FSWBMX *****
								//***** INICIO CODIGO NUEVO FSWBMX *****
								CORVAR.pszgblsql = "select emp_num from " + CORBD.DB_SYB_EJE + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
								//***** FIN DE CODIGO NUEVO FSWBMX *****
								
								lTotalRegDETG = CORPROC2.Cuenta_Registros();
								if (CORPROC2.Obtiene_Registros() != 0)
								{
									if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
									{
									}
									CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
								}
							} else
							{
								CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							}
							
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
							//Asignamos lo que corresponde a las otras empresas)
							iArrParamDETG[iArrParamDETG.GetUpperBound(0)].iCantidad = lTotalRegDETG - lDatosGrafDETG;
							iArrParamDETG[iArrParamDETG.GetUpperBound(0)].pszDescripcion = STR_COMPLEMENTO;
							
							result = lRegsLeidosDETG;
							
							this.Cursor = Cursors.Default;
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
					return result;
			}
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga los Datos correspondientes para Graficar      **
			//**                    en proporción a cada empresa de cada grupo          **
			//**                                                                        **
			//**       Declaración: Function Datos_EjecGrupo() as integer               **
			//**                                                                        **
			//**       Paso de parámetros: Ninguno                                      **
			//**                                                                        **
			//**       Valor de Regreso: El número de registros leídos                  **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : pszSQL - La cadena SQL                          **
			//**                      : iErr   - La cadena SQL                          **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private int Datos_EjecGrupo()
			{
					
					int hBufEjecEmp = 0;
					int iTempErr = 0;
					string pszNomEmpresa = String.Empty;
					int iCont = 0;
					
					iErr = CORCONST.OK;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					// pszgblsql = "exec carga_grupos " + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "exec carga_grupos " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					lRegsLeidosEJEG = CORPROC2.Cuenta_Registros();
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (lRegsLeidosEJEG != 0)
						{
							//UPGRADE_WARNING: (1042) Array iArrParamEJEG may need to have individual elements initialized.
							iArrParamEJEG = new CORVAR.DatosCorpo[lRegsLeidosEJEG];
						} else
						{
							this.Cursor = Cursors.Default;
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							return lRegsLeidosEJEG;
						}
						iCont = CORVB.NULL_INTEGER;
						lDatosGrafEJEG = CORVB.NULL_INTEGER;
						
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{ //And iCont < INT_MAX_PARAM
							//Los agrupados por renglon
							iArrParamEJEG[iCont].iCantidad = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							//El acumulado para complementar
							lDatosGrafEJEG += iArrParamEJEG[iCont].iCantidad;
							pszNomEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							//La descripción del Elemento
							iArrParamEJEG[iCont].pszDescripcion = pszNomEmpresa.Trim();
							iCont++;
						};
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						
						//Sacamos el total de los ejecutivos88
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						//   pszgblsql = "select emp_num from " + DB_SYB_EJE + " where gpo_banco=" + Format$(igblBanco)
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						CORVAR.pszgblsql = "select emp_num from " + CORBD.DB_SYB_EJE + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						
						lTotalRegEJEG = CORPROC2.Cuenta_Registros();
						if (CORPROC2.Obtiene_Registros() != 0)
						{
							if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
							{
							}
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					} else
					{
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					//  If lRegsLeidosEMPG > INT_MAX_PARAM Then
					//    ReDim Preserve iArrParamEJEG(INT_MAX_PARAM)
					//    'Asignamos lo que corresponde a las otras empresas)
					//    iArrParamEJEG(INT_MAX_PARAM).iCantidad = lTotalRegEJEG - lDatosGrafEJEG
					//    iArrParamEJEG(INT_MAX_PARAM).pszDescripcion = STR_COMPLEMENTO
					//  End If
					
					return lRegsLeidosEJEG;
					
			}
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga los Datos correspondientes para Graficar      **
			//**                    las empresas de Cada Grupo                          **
			//**                                                                        **
			//**       Declaración: Function Datos_EjecGrupo() as integer               **
			//**                                                                        **
			//**       Paso de parámetros: Ninguno                                      **
			//**                                                                        **
			//**       Valor de Regreso: El número de registros leídos                  **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : pszSQL - La cadena SQL                          **
			//**                      : iErr   - La cadena SQL                          **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private int Datos_EmpGrupo()
			{
					
					int hBufEjecEmp = 0;
					int iTempErr = 0;
					FixedLengthString szNomEmpresa = new FixedLengthString(45);
					int iCont = 0;
					
					iErr = CORCONST.OK;
					//***** INICIO CODIGO ANTERIOR FSWBMX *****
					// pszgblsql = "exec carga_nom_grupos " + Format$(igblBanco)
					//***** FIN DE CODIGO ANTERIOR FSWBMX *****
					//***** INICIO CODIGO NUEVO FSWBMX *****
					CORVAR.pszgblsql = "exec carga_nom_grupos " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
					//***** FIN DE CODIGO NUEVO FSWBMX *****
					
					lRegsLeidosEMPG = CORPROC2.Cuenta_Registros();
					
					if (CORPROC2.Obtiene_Registros() != 0)
					{
						if (lRegsLeidosEMPG != 0)
						{
							//UPGRADE_WARNING: (1042) Array iArrParamEMPG may need to have individual elements initialized.
							iArrParamEMPG = new CORVAR.DatosCorpo[lRegsLeidosEMPG];
						} else
						{
							this.Cursor = Cursors.Default;
							CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							return lRegsLeidosEMPG;
						}
						iCont = CORVB.NULL_INTEGER;
						lDatosGrafEMPG = CORVB.NULL_INTEGER;
						
						while(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
						{ //And iCont < INT_MAX_PARAM
							iArrParamEMPG[iCont].iCantidad = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
							lDatosGrafEMPG += iArrParamEMPG[iCont].iCantidad;
							szNomEmpresa.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
							iArrParamEMPG[iCont].pszDescripcion = szNomEmpresa.Value.Trim();
							iCont++;
						};
						
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
						//Sacamos el total de las Empresas
						//***** INICIO CODIGO ANTERIOR FSWBMX *****
						//   pszgblsql = "select emp_num from " + DB_SYB_EMP + " where gpo_banco=" + Format$(igblBanco)
						//***** FIN DE CODIGO ANTERIOR FSWBMX *****
						//***** INICIO CODIGO NUEVO FSWBMX *****
						CORVAR.pszgblsql = "select emp_num from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
						//***** FIN DE CODIGO NUEVO FSWBMX *****
						
						
						lTotalRegEMPG = CORPROC2.Cuenta_Registros();
						
						if (CORPROC2.Obtiene_Registros() != 0)
						{
						}
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					} else
					{
						CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					}
					
					CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
					
					//  If lRegsLeidosEMPG > INT_MAX_PARAM Then
					//    ReDim Preserve iArrParamEMPG(INT_MAX_PARAM)
					//    'Asignamos lo que corresponde a las otras empresas)
					//    iArrParamEMPG(INT_MAX_PARAM).iCantidad = lTotalRegDETG - lDatosGrafDETG
					//    iArrParamEMPG(INT_MAX_PARAM).pszDescripcion = STR_COMPLEMENTO
					//  End If
					
					return lRegsLeidosEMPG;
					
			}
			
			private void  Grafica_Param_Mas( CORVAR.DatosCorpo[] iArrDatos,  int lTotRegLeidos)
			{
					
					int iCont = 0;
					
					Pon_Titulos();
					
					//se fija el numero de barras
					ID_GRA_GPH.NumPoints = 10;
					
					ID_GRA_GPH.ThisPoint = 1;
					for (iCont = lContador; iCont <= lContador + 9; iCont++)
					{
						if (iCont >= lTotRegLeidos)
						{
							ID_GRA_GPH.GraphData = 0;
						} else
						{
							ID_GRA_GPH.GraphData = iArrDatos[iCont].iCantidad;
						}
						
					}
					
					ID_GRA_GPH.ThisPoint = 1;
					for (iCont = lContador; iCont <= lContador + 9; iCont++)
					{
						if (iCont >= lTotRegLeidos)
						{
							ID_GRA_GPH.LegendText = CORVB.NULL_STRING;
						} else
						{
							ID_GRA_GPH.LegendText = StringsHelper.Format(iCont, "000") + "  " + iArrDatos[iCont].pszDescripcion.ToUpper();
						}
					}
					
					if (iCont >= lTotRegLeidos)
					{
					} else
					{
						lContador += 10;
					}
					
			}
        public bool flag = false;
			
			//UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
			private void  Form_Load()
			{
					
					
					//Posicionamos la forma
					Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(Width))) / 2);
					Top = (int) VB6.TwipsToPixelsY(1250);
					
					this.Refresh();
					
					this.Cursor = Cursors.WaitCursor;
					
					
					ID_GRA_PAR_COB.Items.Add("Corporativo - Ejecutivos");
					ID_GRA_PAR_COB.Items.Add("Corporativo - Empresas");
					ID_GRA_PAR_COB.Items.Add("Detalle de Corporativos");
					
					int iGrupos = Carga_Grupos(); //Se cargan para el detalle
					
					if (iErr == CORCONST.OK)
					{
						if (iGrupos != 0)
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 2, -1);
						} else
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 2, 0);
						}
					} else
					{
						//AIS-1182 NGONZALEZ
						//iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        flag = true;
                        return;
					}
					
					int iEjecutivos = Datos_EjecGrupo();
					if (iErr == CORCONST.OK)
					{
						if (iEjecutivos != 0)
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 0, -1);
						} else
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 1, 0);
						}
					} else
					{
						//AIS-1182 NGONZALEZ
						//iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        flag = true;
                        return;
					}
					
					int iEmpresas = Datos_EmpGrupo();
					if (iErr == CORCONST.OK)
					{
						if (iEmpresas != 0)
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 1, -1);
						} else
						{
							VB6.SetItemData(ID_GRA_PAR_COB, 1, 0);
						}
					} else
					{
						//AIS-1182 NGONZALEZ
						//iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        flag = true;
                        return;
					}
					
					if (iEjecutivos != 0)
					{
						ID_GRA_PAR_COB.SelectedIndex = 0;
					} else if (iEmpresas != 0) { 
						ID_GRA_PAR_COB.SelectedIndex = 1;
					} else if (iGrupos != 0) { 
						ID_GRA_PAR_COB.SelectedIndex = 2;
					} else
					{
						this.Cursor = Cursors.Default;
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
						//UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
						Interaction.MsgBox("No existe conceptos con datos para graficar.", (MsgBoxStyle) (((int) CORVB.MB_ICONINFORMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
						//AIS-1182 NGONZALEZ
						//iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        flag = true;
                        return;
					}
					
					ID_GRA_GPH.FontUse = CORVB.G_USE_ALL;
					ID_GRA_GPH.FontFamily = CORVB.G_FONT_SWISS;
					ID_GRA_GPH.FontStyle = CORVB.G_STYLE_DEFAULT;
					
					//Se definen para el Título
					ID_GRA_GPH.FontUse = CORVB.G_USE_DEFAULT;
					ID_GRA_GPH.Font = VB6.FontChangeSize(ID_GRA_GPH.Font, INT_FONTSIZE_TIT);
					
					//Se definen para los Títulos de la Izquierda y de Pie de Gráfica
					ID_GRA_GPH.FontUse = CORVB.G_USE_OTHER;
					ID_GRA_GPH.Font = VB6.FontChangeSize(ID_GRA_GPH.Font, INT_FONTSIZE_OTROS);
					
					//Se definen para los legend Text (los de la derecha)
					ID_GRA_GPH.FontUse = CORVB.G_USE_LEGEND;
					ID_GRA_GPH.Font = VB6.FontChangeSize(ID_GRA_GPH.Font, INT_FONTSIZE_OTROS);
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					
					this.Cursor = Cursors.Default;
					
					bGrafMax = 0;
					
					
					
			}
			
			//****************************************************************************
			//**                                                                        **
			//**       Descripción: Carga a la gráfica(el objeto) los datos necesarios  **
			//**                    guardados en el arreglo correspondiente             **
			//**                                                                        **
			//**       Declaración: Function Grafica_Param()                            **
			//**                                                                        **
			//**       Paso de parámetros: iArrDatos() - El arreglo a graficar          **
			//**                                                                        **
			//**       Valor de Regreso: lRegsLeidosPMV - registros leídos              **
			//**                                                                        **
			//**       Variables globales que modifica :                                **
			//**           Al Proyecto :                                                **
			//**           A la forma : pszSQL - Cadena de SQL                          **
			//**                        iErr   - Error generado                         **
			//**                                                                        **
			//**       Ultima modificacion: 060694                                      **
			//**                                                                        **
			//****************************************************************************
			private void  Grafica_Param_GE( CORVAR.DatosCorpo[] iArrDatos)
			{
					
					
					//UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
					try
					{
							
							Pon_Titulos();
							
							ID_GRA_GPH.NumPoints = 10;
							
							
							ID_GRA_GPH.ThisPoint = 1;
							for (int iCont = 0; iCont <= 9; iCont++)
							{
								ID_GRA_GPH.GraphData = iArrDatos[iCont].iCantidad;
							}
							
							ID_GRA_GPH.ThisPoint = 1;
							for (int iCont = 0; iCont <= 9; iCont++)
							{
								ID_GRA_GPH.LegendText = StringsHelper.Format(iCont, "000") + "  " + iArrDatos[iCont].pszDescripcion.ToUpper();
							}
						}
					catch (Exception exc)
					{
						throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
					}
					
			}
			
			
			private void  ID_GRA_B3D_GPB_ClickEvent( Object eventSender,  AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
			{
					int Index = Array.IndexOf(ID_GRA_B3D_GPB, eventSender);
                    //AIS-1095 NGONZALEZ
					if (eventArgs.value != 0)
					{
						
						switch(Index)
						{
							case 0 : 
								ID_GRA_GPH.GraphType = CORVB.G_BAR2D; 
								ID_GRA_GPH.GraphStyle = 0; 
								if (ID_GRA_PAR_COB.SelectedIndex == 2)
								{
									ID_GRA_GPH.BottomTitle = "Grupos Corporativos" + "   " + ID_GRA_GRU_COB.Text.Trim();
								} else
								{
									ID_GRA_GPH.BottomTitle = "Grupos Corporativos";
								} 
								break;
							case 1 : 
								ID_GRA_GPH.GraphType = CORVB.G_BAR3D; 
								ID_GRA_GPH.GraphStyle = 0; 
								if (ID_GRA_PAR_COB.SelectedIndex == 2)
								{
									ID_GRA_GPH.BottomTitle = "Grupos Corporativos" + "   " + ID_GRA_GRU_COB.Text.Trim();
								} else
								{
									ID_GRA_GPH.BottomTitle = "Grupos Corporativos";
								} 
								break;
							case 2 : 
								ID_GRA_GPH.GraphType = CORVB.G_PIE2D; 
								ID_GRA_GPH.GraphStyle = 4; 
								if (ID_GRA_PAR_COB.SelectedIndex == 2)
								{
									ID_GRA_GPH.BottomTitle = "   " + ID_GRA_GRU_COB.Text.Trim();
								} else
								{
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
								} 
								break;
							case 3 : 
								ID_GRA_GPH.GraphType = CORVB.G_PIE3D; 
								ID_GRA_GPH.GraphStyle = 4; 
								if (ID_GRA_PAR_COB.SelectedIndex == 2)
								{
									ID_GRA_GPH.BottomTitle = "   " + ID_GRA_GRU_COB.Text.Trim();
								} else
								{
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
								} 
								break;
						}
						
						Pon_Titulos();
						
						//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
						ID_GRA_GPH.DrawMode = CORVB.G_DRAW;
						
					}
					
			}
			
			private void  ID_GRA_CAN_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					this.Close();
					
			}
			
			private void  ID_GRA_GFC_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					int iTempNGrupo = 0;
					
					this.Cursor = Cursors.WaitCursor;
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					lContador = CORVB.NULL_INTEGER;

                    try
                    {
                        switch (ID_GRA_PAR_COB.SelectedIndex)
                        {
                            case 0:
                                if (VB6.GetItemData(ID_GRA_PAR_COB, 0) != 0)
                                {
                                    ID_GRA_GRU_COB.Visible = false;
                                    ID_GRA_IRA_3CKB.Visible = false;
                                    ID_GRA_TIPO_PNL.Enabled = true;

                                    Grafica_Param_GE(iArrParamEJEG);
                                    if (ID_GRA_GPH.GraphType == CORVB.G_BAR2D || ID_GRA_GPH.GraphType == CORVB.G_BAR3D)
                                    {
                                        ID_GRA_GPH.GraphStyle = 0;
                                        ID_GRA_GPH.BottomTitle = "Grupos Corporativos";
                                    }
                                    else
                                    {
                                        ID_GRA_GPH.GraphStyle = 4;
                                        ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
                                    }
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_DRAW;

                                    lContador = 10;
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
                                    ID_GRA_TIPO_PNL.Enabled = false;
                                }

                                break;
                            case 1:
                                if (VB6.GetItemData(ID_GRA_PAR_COB, 1) != 0)
                                {
                                    ID_GRA_GRU_COB.Visible = false;
                                    ID_GRA_IRA_3CKB.Visible = false;
                                    ID_GRA_TIPO_PNL.Enabled = true;

                                    Grafica_Param_GE(iArrParamEMPG);
                                    if (ID_GRA_GPH.GraphType == CORVB.G_BAR2D || ID_GRA_GPH.GraphType == CORVB.G_BAR3D)
                                    {
                                        ID_GRA_GPH.GraphStyle = 0;
                                        ID_GRA_GPH.BottomTitle = "Grupos Corporativos";
                                    }
                                    else
                                    {
                                        ID_GRA_GPH.GraphStyle = 4;
                                        ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
                                    }
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_DRAW;
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                    //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                    ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
                                    ID_GRA_TIPO_PNL.Enabled = false;
                                }

                                lContador = 10;


                                break;
                            case 2:

                                if (ID_GRA_IRA_3CKB.Value)
                                {
                                    CORIRGRU.DefInstance.Tag = "CORGRCOR";
                                    CORIRGRU.DefInstance.ShowDialog();
                                    iTempNGrupo = CORVAR.igblNumGrupo;
                                }
                                else
                                {
                                    iTempNGrupo = StringsHelper.IntValue(ID_GRA_GRU_COB.Text.Substring(0, Math.Min(ID_GRA_GRU_COB.Text.Length, 4)));
                                }

                                if (iTempNGrupo >= CORVB.NULL_INTEGER)
                                {
                                    //Posiciona el combo de Grupos
                                    for (int iCont = 1; iCont <= ID_GRA_GRU_COB.Items.Count; iCont++)
                                    {
                                        if (Conversion.Val(Strings.Mid(VB6.GetItemString(ID_GRA_GRU_COB, iCont - 1), 1, 4)) == iTempNGrupo)
                                        {
                                            ID_GRA_GRU_COB.SelectedIndex = iCont - 1;
                                            break;
                                        }
                                    }

                                    if (Datos_DetGrupo(iTempNGrupo) > CORVB.NULL_INTEGER)
                                    {
                                        ID_GRA_TIPO_PNL.Enabled = true;
                                        Grafica_Param(iArrParamDETG);

                                        if (ID_GRA_GPH.GraphType == CORVB.G_BAR2D || ID_GRA_GPH.GraphType == CORVB.G_BAR3D)
                                        {
                                            ID_GRA_GPH.GraphStyle = 0;
                                            ID_GRA_GPH.BottomTitle = "Grupos Corporativos" + "   " + ID_GRA_GRU_COB.Text.Trim();
                                        }
                                        else
                                        {
                                            ID_GRA_GPH.GraphStyle = 4;
                                            ID_GRA_GPH.BottomTitle = "   " + ID_GRA_GRU_COB.Text.Trim();
                                        }
                                        //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                        ID_GRA_GPH.DrawMode = CORVB.G_DRAW;
                                        ID_GRA_TIPO_PNL.Enabled = true;
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                        //UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
                                        ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
                                        ID_GRA_TIPO_PNL.Enabled = false;
                                    }


                                }
                                break;
                        }

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Fallo operación ID_GRA_GFC_PB_Click " + exc.Message, "Error Corgrcor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default; //****
                    }
					
			}
			
			private void  ID_GRA_GPH_DblClick( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.Visible = false;
					ID_GRA_IMP_PB.Visible = false;
					Refresh();
					
					if (bGrafMax != 0)
					{
						ID_GRA_IMP_PB.Left = (int) VB6.TwipsToPixelsX(5800);
						ID_GRA_GFC_PB.Visible = true;
						ID_GRA_CAN_PB.Visible = true;
						ID_GRA_GPH.Top = (int) VB6.TwipsToPixelsY(iTop);
						ID_GRA_GPH.Left = (int) VB6.TwipsToPixelsX(iLeft);
						ID_GRA_GPH.Width = (int) VB6.TwipsToPixelsX(iWidth);
						ID_GRA_GPH.Height = (int) VB6.TwipsToPixelsY(iHeight);
						bGrafMax = 0;
					} else
					{
						ID_GRA_IMP_PB.Left = (int) VB6.TwipsToPixelsX(300);
						ID_GRA_GFC_PB.Visible = false;
						ID_GRA_CAN_PB.Visible = false;
						
						iTop = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_GPH.Top));
						iLeft = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_GPH.Left));
						iWidth = Convert.ToInt32((float) VB6.PixelsToTwipsX(ID_GRA_GPH.Width));
						iHeight = Convert.ToInt32((float) VB6.PixelsToTwipsY(ID_GRA_GPH.Height));
						
						ID_GRA_GPH.Top = (int) VB6.TwipsToPixelsY(-15);
						ID_GRA_GPH.Left = (int) VB6.TwipsToPixelsX(-15);
						ID_GRA_GPH.Width = (int) Width;
						ID_GRA_GPH.Height = (int) VB6.TwipsToPixelsY(((float) VB6.PixelsToTwipsY(Height)) - 300);
						bGrafMax = -1;
						ID_GRA_IMP_PB.BringToFront();
						Refresh();
						
					}
					
					ID_GRA_IMP_PB.Visible = true;
					ID_GRA_GPH.Visible = true;
					
			}
			
			private void  ID_GRA_GRU_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_GRA_TIPO_PNL.Enabled = false;
					
			}
			
			private void  ID_GRA_IMP_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					//ros**  MousePointer = HOURGLASS
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_PRINT;
					//ros**  MousePointer = DEFAULT
					
			}
			
			
			private void  ID_GRA_MAS_PB_Click( Object eventSender,  EventArgs eventArgs)
			{
					
					
					if (lContador != CORVB.NULL_INTEGER)
					{
						switch(ID_GRA_PAR_COB.SelectedIndex)
						{
							case 0 : 
								Grafica_Param_Mas(iArrParamEJEG, lRegsLeidosEJEG); 
								 
								if (ID_GRA_GPH.GraphType == CORVB.G_BAR2D || ID_GRA_GPH.GraphType == CORVB.G_BAR3D)
								{
									ID_GRA_GPH.GraphStyle = 0;
									ID_GRA_GPH.BottomTitle = "Grupos Corporativos";
								} else
								{
									ID_GRA_GPH.GraphStyle = 4;
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
								} 
								//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded. 
								ID_GRA_GPH.DrawMode = CORVB.G_DRAW; 
								 
								break;
							case 1 :  //por grupo empresa 
								Grafica_Param_Mas(iArrParamEMPG, lRegsLeidosEMPG); 
								 
								if (ID_GRA_GPH.GraphType == CORVB.G_BAR2D || ID_GRA_GPH.GraphType == CORVB.G_BAR3D)
								{
									ID_GRA_GPH.GraphStyle = 0;
									ID_GRA_GPH.BottomTitle = "Grupos Corporativos";
								} else
								{
									ID_GRA_GPH.GraphStyle = 4;
									ID_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
								} 
								//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded. 
								ID_GRA_GPH.DrawMode = CORVB.G_DRAW; 
								break;
						}
					}
					
			}
			
			private void  ID_GRA_PAR_COB_SelectedIndexChanged( Object eventSender,  EventArgs eventArgs)
			{
					
					ID_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
					//UPGRADE_ISSUE: (2069) VBControlExtender method ID_GRA_GPH.DrawMode was not upgraded.
					ID_GRA_GPH.DrawMode = CORVB.G_CLEAR;
					ID_GRA_TIPO_PNL.Enabled = false;
					
					lContador = CORVB.NULL_INTEGER;
					
					if (ID_GRA_PAR_COB.SelectedIndex == 2)
					{
						ID_GRA_GRU_COB.Visible = true;
						ID_GRA_IRA_3CKB.Visible = true;
						ID_BIT_GRU_TXT.Visible = true;
						ID_GRA_TIPO_PNL.Enabled = false;
						ID_GRA_MAS_PB.Visible = false;
						ID_GRA_MAS_PB.Enabled = false;
					} else
					{
						ID_GRA_GRU_COB.Visible = false;
						ID_GRA_IRA_3CKB.Visible = false;
						ID_BIT_GRU_TXT.Visible = false;
						ID_GRA_IRA_3CKB.Value = false;
						ID_GRA_TIPO_PNL.Enabled = true;
						ID_GRA_MAS_PB.Visible = true;
						ID_GRA_MAS_PB.Enabled = true;
					}
					
					ID_GRA_GPH.Visible = true; //ros**
					this.Cursor = Cursors.Default;
					//ros**  Me.MousePointer = DEFAULT
					
			}
			
			private void  Pon_Titulos()
			{
					
					switch(ID_GRA_PAR_COB.SelectedIndex)
					{
						
						case 0 : 
							ID_GRA_GPH.GraphTitle = STR_GRAPHTIT_EJEGRU; 
							if (ID_GRA_GPH.GraphStyle == 4)
							{
								ID_GRA_GPH.LeftTitle = "Total = " + lTotalRegEJEG.ToString() + " Ejecutivos";
							} else
							{
								ID_GRA_GPH.LeftTitle = STR_LEFTTIT_EJEGRU_C;
							} 
							break;
						case 1 : 
							ID_GRA_GPH.GraphTitle = STR_GRAPHTIT_EMPGRU; 
							if (ID_GRA_GPH.GraphStyle == 4)
							{
								ID_GRA_GPH.LeftTitle = "Total = " + lTotalRegEMPG.ToString() + " Empresas";
							} else
							{
								ID_GRA_GPH.LeftTitle = STR_LEFTTIT_EMPGRU_C;
							} 
							break;
						case 2 : 
							ID_GRA_GPH.GraphTitle = STR_GRAPHTIT_EJEGRU; 
							if (ID_GRA_GPH.GraphStyle == 4)
							{
								ID_GRA_GPH.LeftTitle = "Total = " + lTotalRegDETG.ToString() + " Ejecutivos";
							} else
							{
								ID_GRA_GPH.LeftTitle = STR_LEFTTIT_EJEGRU_C;
							} 
							break;
					}
					
			}
			private void  CORGRCOR_Closed( Object eventSender,  EventArgs eventArgs)
			{
					GC.Collect();
					GC.WaitForPendingFinalizers();
			}
		}
}