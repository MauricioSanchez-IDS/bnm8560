using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Text;


namespace TCc430
{
	internal partial class CORSGACC
		: System.Windows.Forms.Form
		{
            //****************************************************************************
            //**                                                                        **
            //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
            //**                                                                        **
            //**       ---------------------------------------------------------        **
            //**                                                                        **
            //**       Descripción: Forma que captura el servidor, el banco, el usuario **
            //**                    y el password para permitir el accesos a los niveles**
            //**                    asignados                                           **
            //**                                                                        **
            //**       Responsable: Felipe Zacarias Jimenez                             **
            //**                                                                        **
            //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
            //**                                                                        **
            //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
            //**                                                                        **
            //****************************************************************************

            const string STR_SEG_NOT_BAN = "No existen bancos para acceso al sistema. Consulte al Administrador del Sistema.";
            const string STR_SEG_NOT_CON = "La conexión a las bases de datos es invalida. Consulte al Administrador del Sistema.";
            const string STR_SEG_NOT_LOG = "Verifique el usuario o la clave personal, no coinciden.";
            const string STR_ACC_NOT_CVE = "La nomina no ha sido proporcionado. Favor de asignarlo.";
            const string STR_ACC_NOT_USU = "La clave personal no ha sido proporcionada. Favor de asignarla.";
            const string STR_ACC_NOT_NIV = "El grupo asignado al usuario no tiene niveles de acceso. Deberán ser asignados por el Administrador del Sistema.";
            const string STR_ACC_NOT_ACC = "Verifique el usuario o la clave personal, no coinciden.";
            const string STR_ACC_NOT_EXI = "El usuario no ha sido dado de alta en el sistema. Consulte al Administrador del Sistema.";
            const string STR_ACC_NOT_MEM = "No hay suficiente memoria para realizar la Conección. Inicialice su Computadora.";
            const string STR_ACC_NOT_SER = "No existen servisores instalados.";

            string pszGrupo = String.Empty;

            private void Activa_Nivel(string sOpcion, string sValor)
            {

                //Se deshabilitan todos los menús

                if ((sValor.Trim().ToUpper() == "TRUE") || (sValor.Trim().ToUpper() == "VERDADERO"))
                {
                    switch (sOpcion.Trim())
                    {
                        case "IDM_PAR":  //parametros 
                            CORMDIBN.DefInstance.IDM_PAR.Enabled = true;
                            break;
                        case "IDM_INTD":  //integración 
                            CORMDIBN.DefInstance.IDM_INTD.Enabled = true;
                            break;
                        case "IDM_CAMM":  //cambios masivos 
                            CORMDIBN.DefInstance.IDM_CAMM.Enabled = true;
                            break;
                        case "IDM_LIM":  //limites de crédito 
                            //CORMDIBN.DefInstance.IDM_LIM.Enabled = true;
                            break;
                        case "IDM_SEG":  //seguridad 
                            CORMDIBN.DefInstance.IDM_SEG.Enabled = true;
                            break;
                        case "IDM_USU":  //seguridad/usuarios 
                            CORMDIBN.DefInstance.IDM_USU.Enabled = true;
                            break;
                        case "IDM_GRU":  //seguridad/grupos 
                            CORMDIBN.DefInstance.IDM_GRU.Enabled = true;
                            break;
                        case "IDM_BCO":  //banco de operación 
                            CORMDIBN.DefInstance.IDM_BCO.Enabled = true;
                            break;
                        case "IDM_OPE":  //interfaces 
                            CORMDIBN.DefInstance.IDM_OPE.Enabled = true;
                            break;
                        case "IDM_TRR":  //intserfaces/transmisión de repórtes 
                            CORMDIBN.DefInstance.IDM_TRR.Enabled = true;
                            break;
                        case "IDM_DEP":  //interfaces/depuración 
                            //CORMDIBN.DefInstance.IDM_DEP.Enabled = true;
                            break;
                        case "IDM_CAT":  //archivo 
                            CORMDIBN.DefInstance.IDM_CAT.Enabled = true;
                            break;
                        case "Estructuras_Gastos":  //archivo/Estructuras Gastos 
                            //CORMDIBN.DefInstance.Estructuras_Gastos.Enabled = true;
                            break;
                        case "IDM_COR":  //archivo/corportaivos 
                            CORMDIBN.DefInstance.IDM_COR.Enabled = true;
                            break;
                        case "IDM_EMP":  //archivos/empresas 
                            CORMDIBN.DefInstance.IDM_EMP.Enabled = true;
                            break;
                        case "mnu_unidades":  //archivos/unidades 
                            CORMDIBN.DefInstance.mnu_unidades.Enabled = true;
                            break;
                        case "mnu_reportes":  //archivos/unidades 
                            CORMDIBN.DefInstance.mnu_reportes.Enabled = true;
                            break;
                        case "mnu_categorias":  //archivos/unidades 
                            //CORMDIBN.DefInstance.mnu_categorias.Enabled = true;
                            break;
                        case "IDM_EJE":  //archivos/tarjetahabientes 
                            CORMDIBN.DefInstance.IDM_EJE.Enabled = true;
                            break;
                        case "IDM_BAN":  //archivos/jejcutivos banaex 
                            CORMDIBN.DefInstance.IDM_BAN.Enabled = true;
                            break;
                        case "IDM_CCI":  //archivos/jejcutivos banaex 
                            CORMDIBN.DefInstance.IDM_CCI.Enabled = true;
                            break;
                        case "IDM_DIV":  //archivos/divisiones 
                            CORMDIBN.DefInstance.IDM_DIV.Enabled = true;
                            break;
                        case "IDM_REG":  //archivos/regiones 
                            CORMDIBN.DefInstance.IDM_REG.Enabled = true;
                            break;
                        case "IDM_ALTAS_MASIVAS":  //archivos/altas masivas 
                            //CORMDIBN.DefInstance.IDM_ALTAS_MASIVAS.Enabled = true;
                            break;
                        case "mnuEnvioTope":  //archivos/envio Autorización de Límites de Uso 
                            CORMDIBN.DefInstance.mnuEnvioTope.Enabled = true;
                            break;
                        case "mnuArcRevisionCanc":  //archivos/Revisión de Cancelaciones
                            CORMDIBN.DefInstance.mnuArcRevisionCanc.Enabled = true;
                            break;
                        case "mnuCamMasivos":  //archivos/Cambios Masivos de Ejecutivo
                            CORMDIBN.DefInstance.mnuCamMasivos.Enabled = true;
                            break;
                        case "mnuArchAutCancelaciones":  //archivos/Autorización de Cancelaciones
                            CORMDIBN.DefInstance.mnuArchAutCancelaciones.Enabled = true;
                            break;
                        case "mnuAutAltasMasivas":  //archivos/Autorización de Altas Masivas
                            CORMDIBN.DefInstance.mnuAutAltasMasivas.Enabled = true;
                            break;
                        case "EstructurasAltas":
                            CORVAR.OpcionesAcceso[0].sOpcion = "Estructuras";
                            CORVAR.OpcionesAcceso[0].bAltas = false;
                            break;
                        case "EstructurasBajas":
                            CORVAR.OpcionesAcceso[0].sOpcion = "Estructuras";
                            CORVAR.OpcionesAcceso[0].bBajas = false;
                            break;
                        case "EstructurasCambios":
                            CORVAR.OpcionesAcceso[0].sOpcion = "Estructuras";
                            CORVAR.OpcionesAcceso[0].bCambios = false;
                            break;
                        case "EstructurasConsultas":
                            CORVAR.OpcionesAcceso[0].sOpcion = "Estructuras";
                            CORVAR.OpcionesAcceso[0].bConsultas = false;
                            break;
                        case "CorporativoAltas":
                            CORVAR.OpcionesAcceso[1].sOpcion = "Corporativos";
                            CORVAR.OpcionesAcceso[1].bAltas = true;
                            break;
                        case "CorporativoBajas":
                            CORVAR.OpcionesAcceso[1].sOpcion = "Corporativos";
                            CORVAR.OpcionesAcceso[1].bBajas = true;
                            break;
                        case "CorporativoCambios":
                            CORVAR.OpcionesAcceso[1].sOpcion = "Corporativos";
                            CORVAR.OpcionesAcceso[1].bCambios = true;
                            break;
                        case "CorporativoConsultas":
                            CORVAR.OpcionesAcceso[1].sOpcion = "Corporativos";
                            CORVAR.OpcionesAcceso[1].bConsultas = true;
                            break;
                        case "EmpresasAltas":
                            CORVAR.OpcionesAcceso[2].sOpcion = "Empresas";
                            CORVAR.OpcionesAcceso[2].bAltas = true;
                            break;
                        case "EmpresasBajas":
                            CORVAR.OpcionesAcceso[2].sOpcion = "Empresas";
                            CORVAR.OpcionesAcceso[2].bBajas = true;
                            break;
                        case "EmpresasCambios":
                            CORVAR.OpcionesAcceso[2].sOpcion = "Empresas";
                            CORVAR.OpcionesAcceso[2].bCambios = true;
                            break;
                        case "EmpresasConsultas":
                            CORVAR.OpcionesAcceso[2].sOpcion = "Empresas";
                            CORVAR.OpcionesAcceso[2].bConsultas = true;
                            break;
                        case "UnidadesAltas":
                            CORVAR.OpcionesAcceso[3].sOpcion = "Unidades";
                            CORVAR.OpcionesAcceso[3].bAltas = true;
                            break;
                        case "UnidadesBajas":
                            CORVAR.OpcionesAcceso[3].sOpcion = "Unidades";
                            CORVAR.OpcionesAcceso[3].bBajas = true;
                            break;
                        case "UnidadesCambios":
                            CORVAR.OpcionesAcceso[3].sOpcion = "Unidades";
                            CORVAR.OpcionesAcceso[3].bCambios = true;
                            break;
                        case "UnidadesConsultas":
                            CORVAR.OpcionesAcceso[3].sOpcion = "Unidades";
                            CORVAR.OpcionesAcceso[3].bConsultas = true;
                            break;
                        case "ReportesAltas":
                            CORVAR.OpcionesAcceso[8].sOpcion = "Reportes";
                            CORVAR.OpcionesAcceso[8].bAltas = false;
                            break;
                        case "ReportesBajas":
                            CORVAR.OpcionesAcceso[8].sOpcion = "Reportes";
                            CORVAR.OpcionesAcceso[8].bBajas = false;
                            break;
                        case "ReportesCambios":
                            CORVAR.OpcionesAcceso[8].sOpcion = "Reportes";
                            CORVAR.OpcionesAcceso[8].bCambios = false;
                            break;
                        case "ReportesConsultas":
                            CORVAR.OpcionesAcceso[8].sOpcion = "Reportes";
                            CORVAR.OpcionesAcceso[8].bConsultas = false;
                            break;
                        case "CategoriasAltas":
                            CORVAR.OpcionesAcceso[9].sOpcion = "Categorias";
                            CORVAR.OpcionesAcceso[9].bAltas = false;
                            break;
                        case "CategoriasBajas":
                            CORVAR.OpcionesAcceso[9].sOpcion = "Categorias";
                            CORVAR.OpcionesAcceso[9].bBajas = false;
                            break;
                        case "CategoriasCambios":
                            CORVAR.OpcionesAcceso[9].sOpcion = "Categorias";
                            CORVAR.OpcionesAcceso[9].bCambios = false;
                            break;
                        case "CategoriasConsultas":
                            CORVAR.OpcionesAcceso[9].sOpcion = "Categorias";
                            CORVAR.OpcionesAcceso[9].bConsultas = false;
                            break;
                        case "TarjetahabientesAltas":
                            CORVAR.OpcionesAcceso[4].sOpcion = "Tarjetahabientes";
                            CORVAR.OpcionesAcceso[4].bAltas = true;
                            break;
                        case "TarjetahabientesBajas":
                            CORVAR.OpcionesAcceso[4].sOpcion = "Tarjetahabientes";
                            CORVAR.OpcionesAcceso[4].bBajas = true;
                            break;
                        case "TarjetahabientesCambios":
                            CORVAR.OpcionesAcceso[4].sOpcion = "Tarjetahabientes";
                            CORVAR.OpcionesAcceso[4].bCambios = true;
                            break;
                        case "TarjetahabientesConsultas":
                            CORVAR.OpcionesAcceso[4].sOpcion = "Tarjetahabientes";
                            CORVAR.OpcionesAcceso[4].bConsultas = true;
                            break;
                        case "EjecutivosAltas":
                            CORVAR.OpcionesAcceso[5].sOpcion = "Ejecutivos";
                            CORVAR.OpcionesAcceso[5].bAltas = true;
                            break;
                        case "EjecutivosBajas":
                            CORVAR.OpcionesAcceso[5].sOpcion = "Ejecutivos";
                            CORVAR.OpcionesAcceso[5].bBajas = true;
                            break;
                        case "EjecutivosCambios":
                            CORVAR.OpcionesAcceso[5].sOpcion = "Ejecutivos";
                            CORVAR.OpcionesAcceso[5].bCambios = true;
                            break;
                        case "EjecutivosConsultas":
                            CORVAR.OpcionesAcceso[5].sOpcion = "Ejecutivos";
                            CORVAR.OpcionesAcceso[5].bConsultas = true;
                            break;
                        case "DivisionesAltas":
                            CORVAR.OpcionesAcceso[6].sOpcion = "Divisiones";
                            CORVAR.OpcionesAcceso[6].bAltas = true;
                            break;
                        case "DivisionesBajas":
                            CORVAR.OpcionesAcceso[6].sOpcion = "Divisiones";
                            CORVAR.OpcionesAcceso[6].bBajas = true;
                            break;
                        case "DivisionesCambios":
                            CORVAR.OpcionesAcceso[6].sOpcion = "Divisiones";
                            CORVAR.OpcionesAcceso[6].bCambios = true;
                            break;
                        case "DivisionesConsultas":
                            CORVAR.OpcionesAcceso[6].sOpcion = "Divisiones";
                            CORVAR.OpcionesAcceso[6].bConsultas = true;
                            break;
                        case "RegionesAltas":
                            CORVAR.OpcionesAcceso[7].sOpcion = "Regiones";
                            CORVAR.OpcionesAcceso[7].bAltas = true;
                            break;
                        case "RegionesBajas":
                            CORVAR.OpcionesAcceso[7].sOpcion = "Regiones";
                            CORVAR.OpcionesAcceso[7].bBajas = true;
                            break;
                        case "RegionesCambios":
                            CORVAR.OpcionesAcceso[7].sOpcion = "Regiones";
                            CORVAR.OpcionesAcceso[7].bCambios = true;
                            break;
                        case "RegionesConsultas":
                            CORVAR.OpcionesAcceso[7].sOpcion = "Regiones";
                            CORVAR.OpcionesAcceso[7].bConsultas = true;
                            break;
                        case "IDM_CTA":  //consultas 
                            CORMDIBN.DefInstance.IDM_CTA.Enabled = true;
                            break;
                        case "IDM_CON":  //consultas/concentrado 
                            CORMDIBN.DefInstance.IDM_CON.Enabled = true;
                            break;
                        case "IDM_CEJ":  //empresas/ejecutivos 
                            CORMDIBN.DefInstance.IDM_CEJ.Enabled = true;
                            break;
                        case "IDM_CEM":  //grupo/empresas 
                            CORMDIBN.DefInstance.IDM_CEM.Enabled = true;
                            break;
                        case "IDM_ANA":  //consumos por giro 
                            CORMDIBN.DefInstance.IDM_ANA.Enabled = true;
                            break;
                        case "IDM_DET":  //detalle 
                            CORMDIBN.DefInstance.IDM_DET.Enabled = true;
                            break;
                        case "IDM_ATR":  //atrasos por ejecutivo 
                            //CORMDIBN.DefInstance.IDM_ATR.Enabled = true;
                            break;
                        case "IDM_DEJ":  //ejecutivos banamex 
                            CORMDIBN.DefInstance.IDM_DEJ.Enabled = true;
                            break;
                        case "IDM_AFI":  //empresa afiliadas 
                            CORMDIBN.DefInstance.IDM_AFI.Enabled = true;
                            break;
                        case "IDM_GER":  //crystal report 
                            //CORMDIBN.DefInstance.IDM_GER.Enabled = true;
                            break;
                        //case "IDM_EER":  //estatus envio reportes 
                        //    CORMDIBN.DefInstance.IDM_EER.Enabled = true;
                        //    break;
                        //case "mnu_envio_sbf":  //Envio SBF 
                        //    CORMDIBN.DefInstance.mnu_envio_sbf.Enabled = true;
                        //    break;
                        case "IDM_REN":  //rentabilidad 
                            //CORMDIBN.DefInstance.IDM_REN.Enabled = true;
                            break;
                        case "IDM_BNX":  //ejecutivos banamex 
                            //if (CORVAR.igblBanco == 80)
                            //{ CORMDIBN.DefInstance.IDM_BNX.Enabled = true; }
                            //else
                            //{ CORMDIBN.DefInstance.IDM_BNX.Enabled = false; }
                            break;
                        case "IDM_GRA":  //graficas 
                            //CORMDIBN.DefInstance.IDM_GRA.Enabled = true;
                            break;
                        case "IDM_GBIT":  //bitacoras 
                            //CORMDIBN.DefInstance.IDM_GBIT.Enabled = true;
                            break;
                        case "IDM_GCOR":  //corporativos 
                            //CORMDIBN.DefInstance.IDM_GCOR.Enabled = true;
                            break;
                        case "IDM_GEMP":  //empresas 
                            //CORMDIBN.DefInstance.IDM_GEMP.Enabled = true;
                            break;
                        case "IDM_GACL":  //aclaraciones 
                            //CORMDIBN.DefInstance.IDM_GACL.Enabled = false;  //Deshabilitado permanentemente 
                            break;
                        case "IDM_GSIT":  //situación de la cta 
                            //CORMDIBN.DefInstance.IDM_GSIT.Enabled = true;
                            break;
                        case "IDM_GCRE":  //creditos 
                            //CORMDIBN.DefInstance.IDM_GCRE.Enabled = true;
                            break;
                        case "IDM_GANT":  //antiguedad de la cta 
                            //CORMDIBN.DefInstance.IDM_GANT.Enabled = true;
                            break;
                        case "IDM_GVEN":  //vencidos 
                            //CORMDIBN.DefInstance.IDM_GVEN.Enabled = true;
                            break;
                        case "IDM_GCOM":  //comparativos 
                            //CORMDIBN.DefInstance.IDM_GCOM.Enabled = true;
                            break;
                        case "IDM_OPC":  //opciones 
                            CORMDIBN.DefInstance.IDM_OPC.Enabled = true;
                            break;
                        case "IDM_ACL":  //aclaraciones 
                            //CORMDIBN.DefInstance.IDM_ACL.Enabled = true;
                            break;
                        case "IDM_CAP":  //emulador 
                            //CORMDIBN.DefInstance.IDM_CAP.Enabled = true;
                            break;
                    }
                }

            }

            private void Carga_Admin_ABCC()
            {


                CORVAR.tArrNiveles = new CORVAR.Acceso[CORCONST.MAX_NIVELES + 1];
                //AIS-1176 NGONZALEZ
                for (int iCont = 0; iCont < CORVAR.tArrNiveles.Length; iCont++)
                {
                    CORVAR.tArrNiveles[iCont].iAlta = -1;
                    CORVAR.tArrNiveles[iCont].iBaja = -1;
                    CORVAR.tArrNiveles[iCont].iCambio = -1;
                    CORVAR.tArrNiveles[iCont].iConsulta = -1;
                }
            }

            private int Carga_Bancos()
            {

                int result = 0;
                int iErr = 0;
                int hBanco = 0;
                int iBancoCve = 0;

                //***** INICIO CODIGO NUEVO FSWBMX *****
                int iBancoPref = 0;
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                string pszBancoDes = String.Empty;
                FixedLengthString pszCad = new FixedLengthString(256);

                result = -1;

                ID_ACC_BAN_COB.Items.Clear();

                if (CORVAR.hgblConexion != 0)
                {

                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " con_pref,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " con_banco,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " con_ban_des";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCON01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where con_tipo_prod = 'D'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY con_banco";
                    //***** FIN DE CODIGO NUEVO FSWBMX *****

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {


                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            //***** INICIO CODIGO NUEVO FSWBMX *****
                            iBancoPref = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                            iBancoCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
                            pszBancoDes = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL);
                            ID_ACC_BAN_COB.Items.Add(iBancoPref.ToString() + " - " + iBancoCve.ToString() + " - " + pszBancoDes.Trim().ToUpper());
                            //***** FIN DE CODIGO NUEVO FSWBMX *****
                        };
                    }
                    else
                    {
                        //AIS-1182 NGONZALEZ
                        CORVAR.igblErr = API.USER.PostMessage(CORSGACC.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        return 0;
                    }

                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    if (ID_ACC_BAN_COB.Items.Count != 0)
                    {
                        ID_ACC_BAN_COB.SelectedIndex = CORVB.NULL_INTEGER;
                    }
                    else
                    {
                        //Si la aplicacion no contiene bancos
                        this.Cursor = Cursors.Default;
                        //MsgBox STR_SEG_NOT_BAN, MB_ICONSTOP + MB_OK, STR_APP_TIT
                        return 0;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return 0;
                }

                return result;
            }

            private void Carga_Path()
            {

                string pszPath = String.Empty;
                int hParam = 0;

                CORVAR.pszgblsql = "SELECT pgs_path FROM " + CORBD.DB_SYB_PGS;

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        pszPath = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL);
                        if (FileSystem.Dir(pszPath, FileAttribute.Normal) != CORVB.NULL_STRING)
                        {
                            CORVAR.pszgblPath = pszPath.Trim();
                        }
                        else
                        {
                            CORVAR.pszgblPath = Directory.GetCurrentDirectory();
                        }
                    }
                    else
                    {
                        CORVAR.pszgblPath = Directory.GetCurrentDirectory();
                    }
                }
                else
                {
                    //AIS-1182 NGONZALEZ
                    CORVAR.igblErr = API.USER.PostMessage(CORSGACC.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return;
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            }

            //UPGRADE_NOTE: (7001) The following declaration (Checa_Acceso) seems to be dead code
            private int Checa_Acceso()
            {
            
            int result = 0;
            int iErr = 0;
            int hAcceso = 0;
            int hGrupo = 0;
            string ppszNivel = String.Empty;
            string pszAcceso = String.Empty;
            string sMenu = String.Empty;
            string sValor = String.Empty;
            
            //Inicializa variales locales
            int bExisteUsu = 0;
            int bAccesaUsu = 0;
            string pszGrupo = CORVB.NULL_STRING;
            string pszUsuEncrip = CORVB.NULL_STRING;
            pszUsuEncrip = Seguridad.Encripta(ID_ACC_USU_EB.Text.Trim().ToLower(), 2);
            string pszCvePer = Seguridad.Encripta(ID_ACC_CVE_EB.Text.Trim().ToLower(), 2);
            
            //Si es el Admon del Sistema...
            if (Seguridad.Encripta(CORCONST.ADM_USU_CVE, 2) == pszUsuEncrip.Trim())
            {
            //Es el administrador del sistema
            CORVAR.bgblAdmin = -1;
            } else
            {
            //No es el administrador del sistema
            CORVAR.bgblAdmin = 0;
            }
            
            //Si existe conexión...
            if (CORVAR.hgblConexion != 0)
            {
            //Arma la sentencia para buscer el grupo del usuario
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_grupo";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_clave = '" + pszUsuEncrip.Trim() + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_tipo_prod = 'D'";
            
            if (CORPROC2.Obtiene_Registros() != 0)
            {
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_grupo,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_nombre,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_ape_pat,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_ape_mat";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_clave = '" + pszUsuEncrip.Trim() + "'";
            //CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_cve_per = '" + pszCvePer.Trim() + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_tipo_prod = 'D'";
            
            //Busca el grupo al que pertenece el usuario
            if (CORPROC2.Obtiene_Registros() != 0)
            {
            
            while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
            {
            pszGrupo = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL);
            pszGrupo = Seguridad.DesEncripta(pszGrupo);
            CRSParametros.sgUserName = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim()).ToUpper() + " " + Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim()).ToUpper() + " " + Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim()).ToUpper();
            bExisteUsu = -1;
            mdlBitacora.sgClaveTransaccion = "ACCESO C430";
            mdlBitacora.sgClaveResolucion = "ACCESO EXITOSO";
            mdlBitacora.prInsertaBitacora(mdlBitacora.enuTipoBitacora.tbitTransacciones);
            };
            } else
            {
            this.Cursor = Cursors.Default;
            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            Interaction.MsgBox("El password es incorrecto. Verifíquelo!", (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            mdlBitacora.sgTipoViolacion = "ACCESSO";
            mdlBitacora.sgDescViolacion = "PASSWORD INCORRECTO";
            mdlBitacora.prInsertaBitacora(mdlBitacora.enuTipoBitacora.tbitViolaciones);
            return result;
            }
            } else
            {
            this.Cursor = Cursors.Default;
            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            Interaction.MsgBox("El usuario es incorrecto. Verifíquelo!", (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            mdlBitacora.sgTipoViolacion = "ACCESSO";
            mdlBitacora.sgDescViolacion = "USUARIO INCORRECTO";
            mdlBitacora.prInsertaBitacora(mdlBitacora.enuTipoBitacora.tbitViolaciones);
            return result;
            }
            
            
            //Cierra la sentencia
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            
            //Si el usuario existe...
            if (bExisteUsu != 0)
            {
            //Verifica que el usuario sea el Administrador
            if (CORVAR.bgblAdmin != 0)
            {
            Habilita_Admin();
            Carga_Admin_ABCC();
            bAccesaUsu = -1;
            result = bAccesaUsu;
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            return result;
            } else
            {
            //Realiza el select de la tabla de menu
            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_menu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_valor";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_gpo_clave = " + pszGrupo;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and men_tipo_prod = 'D'";
            
            if (CORPROC2.Obtiene_Registros() != 0)
            {
            
            while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
            {
            sMenu = VBSQL.SqlData(CORVAR.hgblConexion, 1);
            sValor = VBSQL.SqlData(CORVAR.hgblConexion, 2);
            //activa el menu
            Activa_Nivel(sMenu, sValor);
            switch(sMenu.Trim())
            {
            case "IDM_COR" : 
            CORMDIBN.DefInstance.IDT_GPB[2].Enabled = true; 
            break;
            case "IDM_EMP" : 
            CORMDIBN.DefInstance.IDT_GPB[0].Enabled = true; 
            break;
            case "IDM_EJE" : 
            CORMDIBN.DefInstance.IDT_GPB[1].Enabled = true; 
            break;
            }
            bAccesaUsu = -1;
            };
            
            //Si no tiene niveles de grupo...
            if ( ~bAccesaUsu != 0)
            {
            //No tiene acceso
            this.Cursor = Cursors.Default;
            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            Interaction.MsgBox(STR_ACC_NOT_NIV, (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            } else
            {
            //No tiene acceso el usuario
            //AIS-1182 NGONZALEZ
            CORVAR.igblErr = API.USER.PostMessage(CORSGACC.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            this.Cursor = Cursors.Default;
            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            Finaliza_Sesion();
            }
            
            //Cierra la sentencia
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            
            }
            //Si no existe el usuario
            } else
            {
            //Envia mensaje de 'No esta dado de alta el ususario'
            this.Cursor = Cursors.Default;
            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            Interaction.MsgBox(STR_ACC_NOT_EXI, (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            //Si no hay conexión ...
            } else
            {
            //Cierra la forma
            //AIS-1182 NGONZALEZ
            iErr = API.USER.PostMessage(CORSGACC.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            this.Cursor = Cursors.Default;
            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
            Interaction.MsgBox(STR_SEG_NOT_CON, (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            Finaliza_Sesion();
            }
            
            //Regresa el estatus del acceso
            return bAccesaUsu;
            
            }

            private void Elimina_TMP()
            {

                //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
                try
                {

                    FileSystem.Kill("c:\\windows\\~imv*.tmp");
                }
                catch (Exception e) { }
                try
                {
                    File.Delete("c:\\windows\\~rms*.tmp");
                }
                catch (Exception e1) { }
                try
                {
                    File.Delete("c:\\windows\\~qe*.tmp");
                }
                catch (Exception e2) { }
            }

            private void Finaliza_Sesion()
            {

                VBSQL.SqlExit();
                VBSQL.SqlWinExit();
                this.Cursor = Cursors.Default;
                Environment.Exit(0);

            }

            public string Obten_Valor_Ini(string pszModulo)
            {

                StringBuilder pszCadena = new StringBuilder(255);
                string pszValor = String.Empty;
                //AIS-1182 NGONZALEZ
                int iNumChar = API.KERNEL.GetPrivateProfileString("Corporativa", pszModulo, "", pszCadena, (short)pszCadena.Length, "corbnx32.ini");

                if (pszModulo == CORVB.NULL_STRING)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox("No se encontraron las variables de inicialización dentro del Archivo Corbnx32.ini. Esto puede generar problemas posteriores dentro del Sistema. Consulte a su Administrador del Sistema para corregir el error.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                    return String.Empty;
                }
                else
                {
                    pszValor = pszCadena.ToString().Substring(0, Math.Min(pszCadena.Length, iNumChar));
                }

                return pszValor;

            }

            private void CORSGACC_Activated(Object eventSender, EventArgs eventArgs)
            {
                if (ActivateHelper.myActiveForm != eventSender)
                {
                    ActivateHelper.myActiveForm = (Form)eventSender;

                    ID_ACC_USU_EB.Text = CORVB.NULL_STRING;
                    ID_ACC_CAN_PB.Enabled = true;
                    ID_ACC_USU_EB.Focus();

                    this.Refresh();

                }
            }

            //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
            private void Form_Load()
            {
                int iRetorna = 0;
                int hConn = 0;

                Seguridad.usugUsuario = new prySeguridadS041.clsUsuario(); //EISSA:HVV 25.02.2005 - Se inicializa una instancia de Usuario.

                this.Width = 434;
                this.Height = 350; // 313
                this.Left = (int)VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
                this.Top = (int)VB6.TwipsToPixelsY(300);
                this.Show();
                this.Refresh();

                this.Cursor = Cursors.WaitCursor;

                //*****JPU*****
                mdlParametros.gprdProducto = new clsProducto();
                //*****JPU*****

                //Obten_Server ID_ACC_SER_COB
                ID_ACC_SER_COB.Items.Add("Corporativa");
                if (ID_ACC_SER_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_ACC_SER_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }

                //Carga los path y variables del Corbnx32.ini
                CORPROC.Obten_Paths_Globales();

                //Obtiene Bancos
                if (~Carga_Bancos() != 0)
                {
                    CORDBLIB.gsMsg = "No existen Bancos en la Base de Datos.";
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORDBLIB.gsMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    this.Cursor = Cursors.Default;
                    Environment.Exit(0);
                }

                if (ID_ACC_BAN_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_ACC_ACE_PB.Enabled = true;
                }

                //EISSA Fin Conexión para Formateo de Empresa y Ejecutivo
                this.Refresh();
                Application.DoEvents();
                // Se comenta 2/03/08 según petición de Angel Pérez CORSGPRE.DefInstance.Close();

                //si los path del archivo corbnx32.ini no estan creados
                //se cerra la aplicación.
                if (!Boolean.Parse(CORPROC.Valida_Path()))
                {
                    Environment.Exit(0);
                }

                this.Cursor = Cursors.Default;

            }

            //UPGRADE_NOTE: (7001) The following declaration (Habilita_Niveles) seems to be dead code
            private void  Habilita_Niveles( int iNivel)
            {
            
            switch(iNivel)
            {
            case CORVB.NULL_INTEGER : 
             
            break;
            case 1 : 
            CORMDIBN.DefInstance.IDM_PAR.Enabled = true; 
            break;
            case 2 : 
            CORMDIBN.DefInstance.IDM_INTD.Enabled = true; 
            break;
            case 3 : 
            //CORMDIBN.DefInstance.IDM_LIM.Enabled = true; 
            break;
            case 4 : 
            CORMDIBN.DefInstance.IDM_SEG.Enabled = true; 
            break;
            case 5 : 
            CORMDIBN.DefInstance.IDM_USU.Enabled = true; 
            break;
            case 6 : 
            CORMDIBN.DefInstance.IDM_GRU.Enabled = true; 
            break;
            case 7 : 
            CORMDIBN.DefInstance.IDM_BCO.Enabled = true; 
            break;
            case 8 : 
            CORMDIBN.DefInstance.IDM_OPE.Enabled = true; 
            break;
            case 9 : 
            CORMDIBN.DefInstance.IDM_TRR.Enabled = true; 
            break;
            case 10 : 
            //CORMDIBN.DefInstance.IDM_DEP.Enabled = true; 
            break;
            case 11 : 
            CORMDIBN.DefInstance.IDM_CAT.Enabled = true; 
            break;
            case 12 : 
            CORMDIBN.DefInstance.IDM_COR.Enabled = true; 
            CORMDIBN.DefInstance.IDT_GPB[2].Enabled = true; 
            break;
            case 13 : 
            CORMDIBN.DefInstance.IDM_EMP.Enabled = true; 
            CORMDIBN.DefInstance.IDT_GPB[0].Enabled = true; 
             
            break;
            case 14 : 
            CORMDIBN.DefInstance.IDM_EJE.Enabled = true; 
            CORMDIBN.DefInstance.IDT_GPB[1].Enabled = true; 
            break;
            case 15 : 
            CORMDIBN.DefInstance.IDM_BAN.Enabled = true; 
            break;
            case 16 : 
            CORMDIBN.DefInstance.IDM_DIV.Enabled = true; 
            break;
            case 17 : 
            CORMDIBN.DefInstance.IDM_REG.Enabled = true; 
            break;
            case 18 : 
            CORMDIBN.DefInstance.IDM_CTA.Enabled = true; 
            break;
            case 19 : 
            CORMDIBN.DefInstance.IDM_CON.Enabled = true; 
            break;
            case 20 : 
            CORMDIBN.DefInstance.IDM_CEJ.Enabled = true; 
            break;
            case 21 : 
            CORMDIBN.DefInstance.IDM_CEM.Enabled = true; 
            break;
            case 22 : 
            CORMDIBN.DefInstance.IDM_ANA.Enabled = true; 
            break;
            case 23 : 
            CORMDIBN.DefInstance.IDM_DET.Enabled = true; 
            break;
            case 24 : 
            //CORMDIBN.DefInstance.IDM_ATR.Enabled = false; 
            break;
            case 25 : 
            CORMDIBN.DefInstance.IDM_DEJ.Enabled = true; 
            break;
            case 26 : 
            CORMDIBN.DefInstance.IDM_AFI.Enabled = true; 
            break;
            case 27 : 
            //CORMDIBN.DefInstance.IDM_GER.Enabled = true; 
            break;
            case 28 : 
            //CORMDIBN.DefInstance.IDM_GRA.Enabled = true; 
            break;
            case 29 : 
            //CORMDIBN.DefInstance.IDM_GBIT.Enabled = true; 
            break;
            case 30 : 
            //CORMDIBN.DefInstance.IDM_GCOR.Enabled = true; 
            break;
            case 31 : 
            //CORMDIBN.DefInstance.IDM_GEMP.Enabled = true; 
            break;
            case 32 : 
            //CORMDIBN.DefInstance.IDM_GACL.Enabled = false;  //permanentemente 
            break;
            case 33 : 
            //CORMDIBN.DefInstance.IDM_GSIT.Enabled = true; 
            break;
            case 34 : 
            //CORMDIBN.DefInstance.IDM_GCRE.Enabled = true; 
            break;
            case 35 : 
            //CORMDIBN.DefInstance.IDM_GANT.Enabled = true; 
            break;
            case 36 : 
            //CORMDIBN.DefInstance.IDM_GVEN.Enabled = true; 
            break;
            case 37 : 
            //CORMDIBN.DefInstance.IDM_GCOM.Enabled = true; 
            break;
            case 38 : 
            //CORMDIBN.DefInstance.IDM_OPC.Enabled = true; 
            break;
            case 39 : 
            //CORMDIBN.DefInstance.IDM_ACL.Enabled = true; 
            break;
            case 40 : 
            //CORMDIBN.DefInstance.IDM_CAP.Enabled = true; 
            break;
            }
            
            CORMDIBN.DefInstance.IDM_ESP.Enabled = true;
            CORMDIBN.DefInstance.IDM_SAL.Enabled = true;
            CORMDIBN.DefInstance.IDM_IND.Enabled = true;
            CORMDIBN.DefInstance.IDM_BAS.Enabled = true;
            CORMDIBN.DefInstance.IDM_UAY.Enabled = true;
            CORMDIBN.DefInstance.IDM_ACE.Enabled = true;
            CORMDIBN.DefInstance.IDT_GPB[7].Enabled = true;
            CORMDIBN.DefInstance.IDM_AYU.Enabled = true;
            CORMDIBN.DefInstance.ID_COR_BHER.Enabled = true;
            
            }

            private void Habilita_Admin()
            {

                //1er. Menu
                    CORMDIBN.DefInstance.IDM_ESP.Enabled = true;
                    CORMDIBN.DefInstance.IDM_PAR.Enabled = true;
                    CORMDIBN.DefInstance.IDM_INTD.Enabled = true;
                    //CORMDIBN.DefInstance.IDM_CDF.Enabled = false;
                    CORMDIBN.DefInstance.IDM_ENV.Enabled = false;
                    CORMDIBN.DefInstance.IDM_CAMM.Enabled = true;
                    //CORMDIBN.DefInstance.IDM_LIM.Visible = false;
                    //CORMDIBN.DefInstance.IDM_LIM.Enabled = false;
                    CORMDIBN.DefInstance.IDM_SEG.Enabled = true;
                    CORMDIBN.DefInstance.IDM_USU.Enabled = true;
                    CORMDIBN.DefInstance.IDM_GRU.Enabled = true;
                    CORMDIBN.DefInstance.IDM_BCO.Enabled = true;
                    CORMDIBN.DefInstance.IDM_SAL.Enabled = true;
                //'
                //'    '2o. Menu
                    CORMDIBN.DefInstance.IDM_OPE.Enabled = false;
                    CORMDIBN.DefInstance.IDM_TRR.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_DEP.Enabled = false;
                //
                //'    '3er. Menu
                    CORMDIBN.DefInstance.IDM_CAT.Enabled = true;
                    //CORMDIBN.DefInstance.Estructuras_Gastos.Enabled = false;
                    CORMDIBN.DefInstance.IDM_COR.Enabled = true;
                    CORMDIBN.DefInstance.IDM_EMP.Enabled = true;
                    CORMDIBN.DefInstance.mnu_unidades.Enabled = true;
                    CORMDIBN.DefInstance.mnu_reportes.Enabled = true;
                    //CORMDIBN.DefInstance.mnu_categorias.Enabled = false;
                    CORMDIBN.DefInstance.IDM_EJE.Enabled = true;
                    CORMDIBN.DefInstance.IDM_BAN.Enabled = true;
                    CORMDIBN.DefInstance.IDM_CCI.Enabled = true;
                    CORMDIBN.DefInstance.IDM_DIV.Enabled = true;
                    CORMDIBN.DefInstance.IDM_REG.Enabled = true;
                //'
                //'    '4o. Menu
                    CORMDIBN.DefInstance.IDM_CTA.Enabled = true;
                    CORMDIBN.DefInstance.IDM_CON.Enabled = true;
                    CORMDIBN.DefInstance.IDM_CEJ.Enabled = true;
                    CORMDIBN.DefInstance.IDM_CEM.Enabled = true;
                    CORMDIBN.DefInstance.IDM_ANA.Enabled = true;
                    CORMDIBN.DefInstance.IDM_DET.Enabled = true;
                    //CORMDIBN.DefInstance.IDM_ATR.Enabled = false;
                    CORMDIBN.DefInstance.IDM_DEJ.Enabled = true;
                    CORMDIBN.DefInstance.IDM_AFI.Enabled = true;
                    //CORMDIBN.DefInstance.IDM_GER.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_REN.Enabled = true;
                    //if (CORVAR.igblBanco == 80)
                    //{CORMDIBN.DefInstance.IDM_BNX.Enabled = false;}
                    //else
                    //{CORMDIBN.DefInstance.IDM_BNX.Enabled = false;}

                    //CORMDIBN.DefInstance.IDM_GRA.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GBIT.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GCOR.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GEMP.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GACL.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GSIT.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GCRE.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GANT.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GVEN.Enabled = false;
                    //CORMDIBN.DefInstance.IDM_GCOM.Enabled = false;
                    CORMDIBN.DefInstance.IDM_OPC.Enabled = true;
                //
                //    '5o. menu
                    //CORMDIBN.DefInstance.IDM_ACL.Enabled = true;
                    //CORMDIBN.DefInstance.IDM_CAP.Enabled = true;
                    //CORMDIBN.DefInstance.IDM_HIS.Enabled = true;
                    //CORMDIBN.DefInstance.IDM_AVE.Enabled = true;
                //
                //Botones
                CORMDIBN.DefInstance.IDT_GPB[0].Enabled = true;
                CORMDIBN.DefInstance.IDT_GPB[1].Enabled = true;
                CORMDIBN.DefInstance.IDT_GPB[2].Enabled = true;

            }

            private void ID_ACC_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
            {

                string pszBanco = String.Empty;
                int iPos = 0;

                try
                {

                    //OJO
                    Habilita_Admin();
                    //OJO

                    mdlSeguridad.objSeguridad = new COMDRV32.TcpServer();
                    mdlSeguridad.objSeguridad.Connect();

                    if (ID_ACC_USU_EB.Text.Trim() == CORVB.NULL_STRING)
                    { //Valido que el campo de usuario tenga un valor
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(STR_ACC_NOT_CVE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        ID_ACC_USU_EB.Focus();
                        return;
                    }

                    if (ID_ACC_CVE_EB.Text.Trim() == CORVB.NULL_STRING)
                    { //Valido que el campo de clave tenga un valor
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(STR_ACC_NOT_USU, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        ID_ACC_CVE_EB.Focus();
                        return;
                    }

                    this.Cursor = Cursors.WaitCursor;
                    Seguridad.usugUsuario.NominaS = ID_ACC_USU_EB.Text; //EISSA:HVV 25.12.2004 -> Seguridad para uso exclusivo de Maker Cheker
                    Seguridad.usugUsuario.PasswordS = ID_ACC_CVE_EB.Text; //EISSA:HVV 25.12.2004 -> Seguridad para uso exclusivo de Maker Cheker
                    //Define el nivel del modulo 4022 al usuario 3260151
                    // ya que el usuario no ha sido dado de alta en el sistema
                    //S041
                    //FSWB NR TESTER Comentarizar el if para permitir acceso sin firma validada en s041
                    string tempRefParam2 = ID_ACC_USU_EB.Text.Trim();
                    if (mdlSeguridad.fncFirmaS041B(ref tempRefParam2, ID_ACC_CVE_EB.Text.Trim(), ID_ACC_TOK_EB.Text.Trim(), mdlSeguridad.enuTipoDlgSeguridad.tFirmaConModuloS041))
                    {

                        mdlParametros.gperPerfil.ModulosPermisosS = mdlSeguridad.sgDlgSeguridad;
                        mdlParametros.gperPerfil.prHabilitaAcciones(CORMDIBN.DefInstance);

                        Seguridad.usugUsuario.NombreS = CRSParametros.sgUserName;
                        TransS111.EnumTipoFirma enDesFirma = TransS111.EnumTipoFirma.EnDesFirma;
                        //AIS- NGONZALEZ
                        Seguridad.usugUsuario.SesionS041_SGR.set_TipoFirma(ref enDesFirma); //EISSA:HVV 30.12.2004 -> Seguridad para uso exclusivo de Maker Cheker
                        string tempRefParam = "";
                        mdlSeguridad.fncFirmaS041B(ref tempRefParam, "", "", mdlSeguridad.enuTipoDlgSeguridad.tDesfirmaS041);
                        mdlSeguridad.objSeguridad.Disconnect();
                        mdlSeguridad.objSeguridad = null;


                        MessageBox.Show("                                            ADVERTENCIA" + "\r\n" +
                                        "Ud. esta autorizado para usar este Sistema unicamente para propositos" + "\r\n" +
                                        "aprobados del negocio. Esta prohibido su uso para cualquier otro" + "\r\n" +
                                        "proposito. Todos los registros de transacciones, reportes, correo" + "\r\n" +
                                        "electronico e-mail, programas y otros datos generados o residentes en" + "\r\n" +
                                        "este Sistema son propiedad de Grupo Financiero Banamex, Subsidiarias y" + "\r\n" +
                                        "Afiliadas de Mexico y pueden ser usados por Grupo Financiero Banamex," + "\r\n" +
                                        "Subsidiarias y Afiliadas de Mexico para cualquier proposito. Las" + "\r\n" +
                                        "actividades autorizadas y no autorizadas pueden ser monitoreadas.", "Seguridad Banamex", MessageBoxButtons.OK);

                        Carga_Path();
                        Elimina_TMP();
                        if (ID_ACC_BAN_COB.Items.Count > CORVB.NULL_INTEGER)
                        { //Asigna el banco seleccionado por el usuario a la variable global
                            pszBanco = VB6.GetItemString(ID_ACC_BAN_COB, ID_ACC_BAN_COB.SelectedIndex);
                            if (pszBanco.Trim().Length != 0)
                            {
                                iPos = Strings.Mid(pszBanco, 1, pszBanco.IndexOf(' ')).Length + 3;
                                mdlParametros.gprdProducto.prConfiguraProducto(Convert.ToInt32(Conversion.Val(Strings.Mid(pszBanco, 1, pszBanco.IndexOf(' ')))), Convert.ToInt32(Conversion.Val(Strings.Mid(pszBanco, iPos, pszBanco.IndexOf(' ')))));
                                CORVAR.igblPref = mdlParametros.gprdProducto.PrefijoL;
                                CORVAR.igblBanco = mdlParametros.gprdProducto.BancoL;
                                CORMDIBN.DefInstance.Text = "Tarjeta de Debito Ejecutiva " + "[ " + pszBanco + " ]";
                                //CORMDIBN.DefInstance.IDM_BNX.Enabled = CORVAR.igblBanco == 80;
                            }
                        }

                        this.Close();

                        CORMENIN tempLoadForm = CORMENIN.DefInstance;
                        CORMENIN.DefInstance.Close();

                        //Load CORMECDF
                        //Unload CORMECDF

                        //Load frmIntInicio
                        //AIS-541 NGONZALEZ
                        mdlParametros.gcestEstado = new colcatEstado();
                        mdlParametros.gcestEstado.prObtenEstado();

                        mdlParametros.prObtenPathsIni();
                        //AIS-541 NGONZALEZ
                        mdlParametros.gcejxEjecutivoBanamex = new colEjecutivoBanamex();
                        mdlParametros.gcejxEjecutivoBanamex.prObtenEjecutivoBanamex();

                        Formato.prConfiguraLongEmpEje(CORVAR.igblPref, CORVAR.igblBanco);
                        CORMDIBN.DefInstance.sspPanel[0].Caption = CRSParametros.sgUserID;

                        //FSWB NR TESTER Para evitar firma comentarizar el else completo y endif
                    }
                    else
                    {
                        mdlSeguridad.objSeguridad.Disconnect();
                        mdlSeguridad.objSeguridad = null;
                    }

                    this.Cursor = Cursors.Default;
                }
                catch (Exception excep)
                {

                    MdlCambioMasivo.MsgError("Se Provoco el siguiente error: " + "\r\n" +
                                             "No. Error        :" + Information.Err().Number.ToString() + "\r\n" +
                                             "Descripcion      : " + excep.Message + "\r\n" +
                                             "Origen del Error : " + excep.Source);
                }


            }

            private bool isInitializingComponent;
            //UPGRADE_WARNING: (2074) ComboBox event ID_ACC_BAN_COB.Change was upgraded to ID_ACC_BAN_COB.TextChanged which has a new behavior.
            private void ID_ACC_BAN_COB_TextChanged(Object eventSender, EventArgs eventArgs)
            {
                if (isInitializingComponent)
                {
                    return;
                }

                //ID_ACC_PRI_PNL.Refresh();

            }

            private void ID_ACC_BAN_COB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
            {
                int KeyAscii = (int)eventArgs.KeyChar;

                switch (KeyAscii)
                {
                    case 13:
                        ID_ACC_ACE_PB_Click(ID_ACC_ACE_PB, new EventArgs());
                        break;
                }

                if (KeyAscii == 0)
                {
                    eventArgs.Handled = true;
                }
                eventArgs.KeyChar = Convert.ToChar(KeyAscii);
            }

            private void ID_ACC_BAN_COB_Leave(Object eventSender, EventArgs eventArgs)
            {

                this.Refresh();
                Application.DoEvents();

            }

            private void ID_ACC_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
            {

                CORMDIBN.DefInstance.Close();

            }

            private void ID_ACC_CVE_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
            {
                int KeyAscii = (int)eventArgs.KeyChar;

                //  KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

                if ((KeyAscii < 48 || KeyAscii > 57) && (KeyAscii < 65 || KeyAscii > 122) && KeyAscii != CORVB.KEY_TAB && KeyAscii != CORVB.KEY_RETURN && KeyAscii != CORVB.KEY_BACK)
                {
                    KeyAscii = 0;
                }

                switch (KeyAscii)
                {
                    case 39:
                        KeyAscii = 32;
                        break;
                    case 13:
                        if (ID_ACC_BAN_COB.Items.Count > CORVB.NULL_INTEGER)
                        {
                            ID_ACC_BAN_COB.Focus();
                        }
                        break;
                }

                if (KeyAscii == 0)
                {
                    eventArgs.Handled = true;
                }
                eventArgs.KeyChar = Convert.ToChar(KeyAscii);
            }

            private void ID_ACC_CVE_EB_Leave(Object eventSender, EventArgs eventArgs)
            {

                //  ID_ACC_CVE_EB.Text = UCase$(ID_ACC_CVE_EB.Text)

            }

            private void ID_ACC_SER_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
            {
                string tmpStr = new string(' ', 255);
                string tmpStr1 = new string(' ', 255);
                StringBuilder szNomSer = new StringBuilder(tmpStr);
                StringBuilder szNomDB = new StringBuilder(tmpStr1);
                string pszServer = String.Empty;
                int iLong = 0;

                if (ID_ACC_SER_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    pszServer = VB6.GetItemString(ID_ACC_SER_COB, ID_ACC_SER_COB.SelectedIndex).Trim();

                    //Obtiene el nombre del servidor
                    //szNomSer.Insert(0,' ', 255);
                    //AIS-1182 NGONZALEZ
                    iLong = API.KERNEL.GetPrivateProfileString(pszServer, "Server", "", szNomSer, (short)szNomSer.Length, "ODBC.INI");
                    CORVAR.pszgblServer = Strings.Mid(szNomSer.ToString(), 1, iLong);

                    //szNomDB.Append((char) 32, 255);
                    //AIS-1182 NGONZALEZ
                    iLong = API.KERNEL.GetPrivateProfileString(pszServer, "Database", "", szNomDB, (short)szNomDB.Length, "ODBC.INI");
                    CORVAR.pszgblDB = Strings.Mid(szNomDB.ToString(), 1, iLong);

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(STR_ACC_NOT_SER, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    Finaliza_Sesion();
                }

            }

            private void ID_ACC_USU_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
            {
                int KeyAscii = (int)eventArgs.KeyChar;

                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

                if ((KeyAscii < 48 || KeyAscii > 57) && (KeyAscii < 65 || KeyAscii > 122) && KeyAscii != CORVB.KEY_TAB && KeyAscii != CORVB.KEY_RETURN && KeyAscii != CORVB.KEY_BACK)
                {
                    KeyAscii = 0;
                }

                switch (KeyAscii)
                {
                    case 39:
                        KeyAscii = 32;
                        break;
                    case 13:
                        ID_ACC_CVE_EB.Focus();
                        break;
                }

                if (KeyAscii == 0)
                {
                    eventArgs.Handled = true;
                }
                eventArgs.KeyChar = Convert.ToChar(KeyAscii);
            }

            private void ID_ACC_USU_EB_Leave(Object eventSender, EventArgs eventArgs)
            {
                ID_ACC_USU_EB.Text = ID_ACC_USU_EB.Text.ToUpper();
                CRSParametros.sgUserID = ID_ACC_USU_EB.Text;
            }

            //UPGRADE_NOTE: (7001) The following declaration (Obten_Server) seems to be dead code
            //private void  Obten_Server( Control ctrlCombo)
            //{
            
            //int pszDataSourceLong = 0;
            //int pszDescripcionLong = 0;
            //int hEnvio = 0;
            //
            //  If SQLAllocEnv(hEnvio) <> -1 Then
            //string pszDataSource = new string((char) 32, 32);
            //string pszDescripcion = new string((char) 32, 255);
            //
            //obten el primero
            //    igblErr = SQLDataSources(hEnvio, 2, pszDataSource, Len(pszDataSource), pszDataSourceLong, pszDescripcion, Len(pszDescripcion), pszDescripcionLong)
            //
            //while (CORVAR.igblErr == CORVB.NULL_INTEGER || CORVAR.igblErr == 1)
            //{
            //
            ////UPGRADE_TODO: (1067) Member AddItem is not defined in type VB.Control.
            //ReflectionHelper.Invoke(ctrlCombo, "AddItem", new object[]{Strings.Mid(pszDataSource, 1, pszDataSourceLong).ToUpper()});
            //pszDataSource = new string((char) 32, 32);
            //pszDescripcion = new string((char) 32, 255);
            //      igblErr = SQLDataSources(hEnvio, 1, pszDataSource, Len(pszDataSource), pszDataSourceLong, pszDescripcion, Len(pszDescripcion), pszDescripcionLong)
            //}
            //  End If
            //
            //}

            //UPGRADE_NOTE: (7001) The following declaration (Obten_Servidores) seems to be dead code
            //private void Obten_Servidores()
            //{

            //    FixedLengthString szServer = new FixedLengthString(100);

            //    CORVAR.igblErr = CORVB.GetPrivateProfileString("ITB9000", "Server", " ", szServer.Value, szServer.Value.Length, "ODBC.ini");

            //}

            private void CORSGACC_Closed(Object eventSender, EventArgs eventArgs)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

    }
}