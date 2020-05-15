using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Drawing;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORRPDEJ
        : System.Windows.Forms.Form
    {

        //'**********************************************************
        //*
        //*    Descripción     : Módulo de Reporte de Concentrado
        //*                      por ejecutivos de empresas.
        //*
        //*    Fecha de Inicio : 2/05/94
        //*
        //*    Responsable     : Alfonso Chaparro Rojas
        //*
        //**********************************************************

        int lEmpNum = 0;
        FixedLengthString szNomEmp = new FixedLengthString(CORBD.LNG_EMP_NOM);
        int lNumTarj = 0;
        int lNumTransac = 0;
        double dSaldoAnterior = 0;
        double dPagosAbonos = 0;
        double dComisiones = 0;
        double dIntereses = 0;
        double dIva = 0;
        double dCompras = 0;
        double dSaldoNuevo = 0;
        double dSaldosVencidos = 0;
        double dDispEfec = 0;

        //Variables para totales del Concentrado
        double dTotSaldoAnt = 0;
        double dTotCompras = 0;
        double dTotDispEfec = 0;
        double dTotPagos = 0;
        double dTotComisiones = 0;
        double dTotIntereses = 0;
        double dTotIva = 0;
        double dTotSaldoNuevo = 0;

        //Variables para totales del Detalle
        int lTotNumEmp = 0;
        int lTotNumTarj = 0;
        int lTotNumTransac = 0;
        double dTotMontoComp = 0;
        double dTotMontoDispEfvo = 0;
        double dTotSaldosVenc = 0;
        double dCredTot = 0;
        double dCredAcum = 0;
        string pszFecVenCred = String.Empty;

        //Variables requeridas para la conexión a Sybase
        int lRetorna = 0;
        int hConexion = 0;

        int intCont = 0;

        FarPoint.Win.Spread.CellType.EditBaseCellType CorpdejCell = new FarPoint.Win.Spread.CellType.EditBaseCellType();

        private void Carga_Reporte()
        {

            int hEjeEmp1 = 0;
            int hEjeEmp2 = 0;
            string pszTempCuenta = String.Empty;
            string pszCadena = String.Empty;
            int lNumCompras = 0;
            int lNumDispEfvo = 0;

            this.Cursor = Cursors.WaitCursor;

            //Inicializamos las variables que almacenaran los datos
            Inicializa_Variables();

            //Obtiene las Empresas que esten Asignadas a el Ejecutivo Banamex seleccionado en el List Box
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "reporte_eje_banamex " + Format$(igblBanco) + "," + Format$(lgblNumEjeBnx)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "reporte_eje_banamex " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblNumEjeBnx.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            { //Existieron Datos

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //Obtenemos los Registros regresados por el Select
                    dSaldoAnterior = CORVB.NULL_INTEGER;
                    dPagosAbonos = CORVB.NULL_INTEGER;
                    dComisiones = CORVB.NULL_INTEGER;
                    dIntereses = CORVB.NULL_INTEGER;
                    dIva = CORVB.NULL_INTEGER;
                    dCompras = CORVB.NULL_INTEGER;
                    dSaldoNuevo = CORVB.NULL_INTEGER;
                    dSaldosVencidos = CORVB.NULL_INTEGER;
                    dDispEfec = CORVB.NULL_INTEGER;
                    dCredTot = CORVB.NULL_INTEGER;
                    dCredAcum = CORVB.NULL_INTEGER;
                    pszFecVenCred = CORVB.NULL_STRING;

                    lEmpNum = CORVB.NULL_INTEGER;
                    lNumTarj = CORVB.NULL_INTEGER;
                    szNomEmp.Value = CORVB.NULL_STRING;

                    lEmpNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    szNomEmp.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    lNumTarj = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                    dCredTot = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
                    dCredAcum = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
                    pszFecVenCred = VBSQL.SqlData(CORVAR.hgblConexion, 6);

                    //Obtiene los Importes de saldo anterior, pagos y abonos, intereses, comisiones
                    if (~Obtiene_Imp_del_HIH() != 0)
                    {
                        return;
                    }

                    //Obtiene las compras ó consumos de la tabla Histórico Detalle
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //     pszgblSql2 = "exec reporte_dej_compras " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lEmpNum)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //12.11.2001 EISSA Inicio Código Anterior
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    //      pszgblSql2 = "exec reporte_dej_compras " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lEmpNum)
                    //***** FIN DE CODIGO NUEVO FSWBMX *****
                    //12.11.2001 EISSA Fin Código Anterior

                    //EISSA 09.11.2001 Código Nuevo Cambio de parámetros de los Sp's, ahora sólo se requiere utilizar el mes actual
                    CORVAR.pszgblSql2 = "exec reporte_dej_compras " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesDiaACG).ToString() + "," + lEmpNum.ToString();
                    //EISSA 09.11.2001 Fin de Código Nuevo

                    lNumCompras = CORVB.NULL_INTEGER;
                    if (CORPROC2.Consulta_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                        {
                            dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                            lNumCompras = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 2)));
                        }
                        dTotCompras += dCompras;
                        //      Else
                        //        lRetorna = SqlCancel(hgblConexion2)
                        //        Exit Sub                                  'Salimos de la función
                    }
                    lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2); //Realiza fin de Query


                    //Obtiene las disposiciones en Efectivo de la tabla Histórico Detalle
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //     pszgblSql2 = "exec reporte_dej_disposiciones " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lEmpNum)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //12.11.2001 EISSA Inicio Código Anterior
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    //      pszgblSql2 = "exec reporte_dej_disposiciones " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lEmpNum)
                    //***** FIN DE CODIGO NUEVO FSWBMX *****
                    //12.11.2001 EISSA Fin Código Anterior

                    //EISSA 09.11.2001 Código Nuevo Cambio de parámetros de los Sp's, ahora sólo se requiere utilizar el mes actual
                    CORVAR.pszgblSql2 = "exec reporte_dej_disposiciones " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesDiaACG).ToString() + "," + lEmpNum.ToString();
                    //EISSA 09.11.2001 Fin de Código Nuevo

                    lNumDispEfvo = CORVB.NULL_INTEGER;
                    if (CORPROC2.Consulta_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                        {
                            dDispEfec = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                            lNumDispEfvo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 2)));
                        }
                        dTotDispEfec += dDispEfec;
                        //      Else
                        //        lRetorna = SqlCancel(hgblConexion2)
                        //        Exit Sub                                  'Salimos de la función
                    }
                    lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2); //Realiza fin de Query

                    //Obtiene los Saldos Vencidos del THS
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //      pszgblSql2 = "exec reporte_dej_venci " + Format$(igblBanco) + "," + Format$(lEmpNum)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    CORVAR.pszgblSql2 = "exec reporte_dej_venci " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + lEmpNum.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX *****


                    if (CORPROC2.Consulta_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                        {
                            dSaldosVencidos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                        }
                        //      Else
                        //       lRetorna = SqlCancel(hgblConexion2)              'Realiza fin de Query
                        //        Exit Sub                                  'Salimos de la función
                    }
                    lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                    lNumTransac = CORVB.NULL_INTEGER;
                    lNumTransac = lNumCompras + lNumDispEfvo;

                    dSaldoNuevo = dSaldoAnterior + dCompras + dDispEfec + dComisiones + dIntereses + dIva - dPagosAbonos; //Calcula el nuevo saldo
                    dTotSaldoNuevo += dSaldoNuevo;

                    Llena_Detalle(); //Llena spread de detalle de ejecutivos

                };

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query
                Coloca_totales(); //Calcula totales del Datalle
                if (~Datos_Empresa() != 0)
                { //Obtiene los Datos de la Empresa
                    return;
                }
                Llena_Concentrado(); //Llena el Resumen concentrado
                ID_CEJ_REP_SS.ReDraw = true;
                ID_CEJ_REP_SS.Visible = true;
                this.Cursor = Cursors.Default;

            }
            else
            {
                //No Existieron Datos

                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query

                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORRPDEJ.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }



        }

        private void Coloca_totales()
        {


            ID_CEJ_REP_SS.MaxRows++;
            //Asigna el máximo de renglones
            ID_CEJ_REP_SS.Row = ID_CEJ_REP_SS.MaxRows;

            //Formatea ultimo renglon
            for (int iCont = 1; iCont <= 10; iCont++)
            {
                ID_CEJ_REP_SS.Col = iCont;
                ID_CEJ_REP_SS.BackColor = Color.Silver;
            }

            ID_CEJ_REP_SS.Col = 1;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CEJ_REP_SS.Text = "Total";

            //Empresas en Total
            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.TypeHAlign = 0;
            ID_CEJ_REP_SS.Text = new String(' ', 2) + lTotNumEmp.ToString() + " Empresa(s)";

            //Total de Tarjetas
            ID_CEJ_REP_SS.Col = 3;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.Text = lTotNumTarj.ToString();

            //Total de Transacciones
            ID_CEJ_REP_SS.Col = 4;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.Text = lTotNumTransac.ToString();

            //Total del Monto de Compras
            ID_CEJ_REP_SS.Col = 5;
            ID_CEJ_REP_SS.CellType = CorpdejCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotMontoComp, "##,###,###,##0.00");

            //Total del Monto de Disposiciones en Efectivo
            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.CellType = CorpdejCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotMontoDispEfvo, "##,###,###,##0.00");

            //Total de los saldos vencidos
            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.CellType = CorpdejCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotSaldosVenc, "##,###,###,##0.00");

        }

        private int Datos_Empresa()
        {

            int result = 0;
            string pszNomEjeBnx = String.Empty;
            string pszCalle = String.Empty;
            string pszCol = String.Empty;
            string pszPob = String.Empty;
            int lCP = 0;
            string pszEdo = String.Empty;
            string pszCiudad = String.Empty;
            int hStmt = 0;
            string pszSentencia = String.Empty;

            CORVAR.pszgblsql = "select ejx_nombre, ejx_calle, ejx_col, ejx_pob, ejx_cp, ejx_edo, ejx_ciu ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYB_EJX + " where ejx_numero = " + CORVAR.lgblNumEjeBnx.ToString();

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_DAT_DEM_TXT[0].Text = CORVB.NULL_STRING;
                ID_DAT_DEM_TXT[1].Text = CORVB.NULL_STRING;
                ID_DAT_DEM_TXT[2].Text = CORVB.NULL_STRING;
                ID_DAT_DEM_TXT[3].Text = CORVB.NULL_STRING;
                ID_DAT_DEM_TXT[4].Text = CORVB.NULL_STRING;
                ID_DAT_DEM_TXT[5].Text = CORVB.NULL_STRING;

                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {

                    pszNomEjeBnx = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    ID_DAT_DEM_TXT[0].Text = pszNomEjeBnx.ToUpper();
                    ID_DAT_DEM_TXT[1].Text = Nombre_de_Empresa().ToUpper();
                    pszCalle = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_DAT_DEM_TXT[2].Text = pszCalle.ToUpper();
                    pszCol = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    ID_DAT_DEM_TXT[3].Text = "COL. " + pszCol.ToUpper();
                    //igblErr = qeValCharBuf(hStmt, pszPob, 4, NULL_STRING, LNG_EJX_POB)
                    //ID_DAT_DEM_TXT(4) = UCase$(pszPob)
                    lCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
                    pszEdo = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                    pszCiudad = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                    ID_DAT_DEM_TXT[4].Text = "C.P. " + StringsHelper.Format(lCP, "00000") + "  " + pszCiudad.Trim() + ", " + pszEdo.Substring(0, Math.Min(pszEdo.Length, CORBD.LNG_EJX_EDO));
                }
                else
                {
                    result = 0;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se obtuvieron todos los datos necesarios para el reporte.Vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                    //AIS-1182 NGONZALEZ
                    CORVAR.igblErr = API.USER.PostMessage(CORRPDEJ.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    flag = true;
                    return result;
                }
            }
            else
            {
                result = 0;
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                return result; //Salimos de la función
            }

            result = -1;
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query

            return result;
        }

        //UPGRADE_NOTE: (7001) The following declaration (Envia_Error) seems to be dead code
        //private void  Envia_Error( int hStmt)
        //{
        //
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("Error de Lectura en la Base de Datos. Consulte a su Administrador del Sistema y Vuelva a Intentar", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
        //AIS-1182 NGONZALEZ
        //CORVAR.igblErr = API.USER.PostMessage(CORRPDEJ.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
        //
        //}

        private void CORRPDEJ_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                CORVAR.igblFormaActiva = CORCONST.INT_ACT_DEJ;
                CORPROC.Cambia_StatusOpciones(-1);

            }
        }

        //UPGRADE_WARNING: (2065) Form event CORRPDEJ.Deactivate has a new behavior.
        private void CORRPDEJ_Deactivate(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            CORPROC.Cambia_StatusOpciones(0);

        }

        private void CORRPDEJ_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            if (KeyAscii == CORVB.KEY_ESCAPE)
            {
                this.Close();
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        public bool flag = false;
        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);


            intCont = CORDBLIB.Segunda_ConexionServidor();

            if (intCont != 0)
            {
                CORVAR.igblMesCorte = CORVAR.igblMesDiaACG;
                Formatea_Spread();
                Carga_Reporte();
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                //AIS-1182 NGONZALEZ
                CORVAR.igblErr = API.USER.PostMessage(CORRPDEJ.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

        }

        private void CORRPDEJ_Closed(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;

            CORPROC.Cambia_StatusOpciones(0);

            VBSQL.SqlClose(CORVAR.hgblConexion2);
            CORVAR.hgblConexion2 = CORVB.NULL_INTEGER;
            VBSQL.subCanConRec(ref intCont);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Formatea_Spread()
        {

            int iCont = 0;

            ID_CEJ_REP_SS.ReDraw = false;
            ID_CEJ_REP_SS.Visible = false;

            //  ID_CEJ_REP_SS.AllowSelBlock = False
            //  ID_CEJ_REP_SS.AllowResize = False

            ID_CEJ_REP_SS.Row = 0;

            ID_CEJ_REP_SS.Col = 1;
            ID_CEJ_REP_SS.set_ColWidth(1, 7 * 8);
            ID_CEJ_REP_SS.Text = "Número";

            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.set_ColWidth(2, 35 * 8);
            ID_CEJ_REP_SS.Text = "Empresa";

            //ID_CEJ_REP_SS.Col = 3;
            //ID_CEJ_REP_SS.set_ColWidth(3, 15);
            //ID_CEJ_REP_SS.Text = "Crédito Total";

            //ID_CEJ_REP_SS.Col = 4;
            //ID_CEJ_REP_SS.set_ColWidth(4, 15);
            //ID_CEJ_REP_SS.Text = "Crédito Acumualdo";

            //ID_CEJ_REP_SS.Col = 5;
            //ID_CEJ_REP_SS.set_ColWidth(5, 15);
            //ID_CEJ_REP_SS.Text = "Fec. Ven. Cred.";

            ID_CEJ_REP_SS.Col = 3;
            ID_CEJ_REP_SS.set_ColWidth(3, 15 * 8);
            ID_CEJ_REP_SS.Text = "Tarjetas";

            ID_CEJ_REP_SS.Col = 4;
            ID_CEJ_REP_SS.set_ColWidth(4, 15 * 8);
            ID_CEJ_REP_SS.Text = "Transac.";

            ID_CEJ_REP_SS.Col = 5;
            ID_CEJ_REP_SS.set_ColWidth(5, 15 * 8);
            ID_CEJ_REP_SS.Text = "Monto de Compras";

            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.set_ColWidth(6, 14 * 8);
            ID_CEJ_REP_SS.Text = "Monto de Disp.";

            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.set_ColWidth(7, 14 * 8);
            ID_CEJ_REP_SS.Text = "Saldos Vencidos";

            //Inicializa el Numero de Renglones
            ID_CEJ_REP_SS.MaxRows = 1;

            ID_CEJ_REP_SS.Row = -1;
            ID_CEJ_REP_SS.Col = 3;
            //  ID_CEJ_REP_SS.TypeEditAlign = 1
            ID_CEJ_REP_SS.Col = 4;
            //  ID_CEJ_REP_SS.TypeEditAlign = 1
            ID_CEJ_REP_SS.Col = 5;
            //  ID_CEJ_REP_SS.TypeEditAlign = 1
            ID_CEJ_REP_SS.Col = 6;
            //  ID_CEJ_REP_SS.TypeEditAlign = 1
            ID_CEJ_REP_SS.Col = 7;
            //  ID_CEJ_REP_SS.TypeEditAlign = 1
            ID_CEJ_REP_SS.Col = 10;

        }

        private void ID_CEJ_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                CORPROC.Imprime_Reporte();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEJ_IMP_PB_Click)", e);
            }

        }

        private void ID_CEJ_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Close();

            this.Cursor = Cursors.Default;

        }

        private void Inicializa_Variables()
        {

            //Variables para totales del Concentrado
            dTotSaldoAnt = CORVB.NULL_INTEGER;
            dTotCompras = CORVB.NULL_INTEGER;
            dTotDispEfec = CORVB.NULL_INTEGER;
            dTotPagos = CORVB.NULL_INTEGER;
            dTotComisiones = CORVB.NULL_INTEGER;
            dTotIntereses = CORVB.NULL_INTEGER;
            dTotIva = CORVB.NULL_INTEGER;
            dTotSaldoNuevo = CORVB.NULL_INTEGER;

            //Variables para totales del Detalle
            lTotNumEmp = CORVB.NULL_INTEGER;
            lTotNumTarj = CORVB.NULL_INTEGER;
            lTotNumTransac = CORVB.NULL_INTEGER;
            dTotMontoComp = CORVB.NULL_INTEGER;
            dTotMontoDispEfvo = CORVB.NULL_INTEGER;
            dTotSaldosVenc = CORVB.NULL_INTEGER;

        }

        private void Llena_Concentrado()
        {

            ID_DEJ_RES_TXT[0].Text = StringsHelper.Format(dTotSaldoAnt, "$##,###,##0.00;($##,###,##0.00)");
            ID_DEJ_RES_TXT[1].Text = StringsHelper.Format(dTotCompras, "$##,###,##0.00;($##,###,##0.00)");
            ID_DEJ_RES_TXT[2].Text = StringsHelper.Format(dTotDispEfec, "$##,###,##0.00;($##,###,##0.00)");
            ID_DEJ_RES_TXT[3].Text = StringsHelper.Format(dTotPagos, "$##,###,##0.00;($##,###,##0.00)");
            ID_DEJ_RES_TXT[4].Text = StringsHelper.Format(dTotComisiones, "$##,###,##0.00;($##,###,##0.00)");
            ID_DEJ_RES_TXT[5].Text = StringsHelper.Format(dTotIntereses, "$##,###,##0.00;($##,###,##0.00)");
            ID_DEJ_RES_TXT[6].Text = StringsHelper.Format(dTotIva, "$##,###,##0.00;($##,###,##0.00)");
            ID_DEJ_RES_TXT[7].Text = StringsHelper.Format(dTotSaldoNuevo, "$##,###,##0.00;($##,###,##0.00)");

        }

        private void Llena_Detalle()
        {

            ID_CEJ_REP_SS.Row = ID_CEJ_REP_SS.MaxRows;

            //Numero de la Empresa
            ID_CEJ_REP_SS.Col = 1;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            //***** Código Anterior     ***********
            //  ID_CEJ_REP_SS.Text = Format$(lEmpNum, "00000")
            //***** Fin Código Anterior ***********

            //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
            ID_CEJ_REP_SS.Text = StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa));
            //EISSA 05.10.2001 FIN


            lTotNumEmp++; //Acumulamos el numero de empresas

            //Nombre de la Empresa
            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.Text = new String(' ', 1) + szNomEmp.Value.Trim();

            //Credito Total
            //ID_CEJ_REP_SS.Col = 3;
            //ID_CEJ_REP_SS..TypeHAlign = (FPSpreadADO.TypeHAlignConstants)1;;
            //ID_CEJ_REP_SS.CellType = CorpdejCell;
            //ID_CEJ_REP_SS..TypeHAlign = (FPSpreadADO.TypeHAlignConstants)1;;
            //ID_CEJ_REP_SS.Text = StringsHelper.Format(dCredTot, "##,###,###,##0.00");

            //Credito Acumulado
            //ID_CEJ_REP_SS.Col = 4;
            //ID_CEJ_REP_SS..TypeHAlign = (FPSpreadADO.TypeHAlignConstants)1;;
            //ID_CEJ_REP_SS.CellType = CorpdejCell;
            //ID_CEJ_REP_SS..TypeHAlign = (FPSpreadADO.TypeHAlignConstants)1;;
            //ID_CEJ_REP_SS.Text = StringsHelper.Format(dCredAcum, "##,###,###,##0.00");

            //Fecha de vencimiento de cREd
            //ID_CEJ_REP_SS.Col = 5;
            //ID_CEJ_REP_SS.TypeHAlign = 2;
            //ID_CEJ_REP_SS.Text = pszFecVenCred;

            //Número de Tarjetas
            ID_CEJ_REP_SS.Col = 3;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.Text = lNumTarj.ToString();
            lTotNumTarj += lNumTarj;

            //Número de Transacciones
            ID_CEJ_REP_SS.Col = 4;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.Text = lNumTransac.ToString();
            lTotNumTransac += lNumTransac;

            //Monto de Compras
            ID_CEJ_REP_SS.Col = 5;
            ID_CEJ_REP_SS.CellType = CorpdejCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dCompras, "##,###,###,##0.00");

            dTotMontoComp += dCompras;

            //Monto de Disposiciones en Efectivo
            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.CellType = CorpdejCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dDispEfec, "##,###,###,##0.00");
            dTotMontoDispEfvo += dDispEfec;

            //Consumos
            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.CellType = CorpdejCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dSaldosVencidos, "##,###,###,##0.00");
            dTotSaldosVenc += dSaldosVencidos;

            ID_CEJ_REP_SS.MaxRows++;

        }

        private string Nombre_de_Empresa()
        {

            int hStmt = 0;
            string pszNomEmp = String.Empty;

            CORVAR.pszgblSql2 = "Select pgs_emp From " + CORBD.DB_SYB_PGS;

            if (CORPROC2.Consulta_Registros() != 0)
            {
                pszNomEmp = CORVB.NULL_STRING;

                if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                {
                    pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion2, 1);
                }
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
                return String.Empty; //Salimos de la función
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2); //Realiza fin de Query

            string ppszNomEmp = pszNomEmp;
            ppszNomEmp = ppszNomEmp.Trim();
            return ppszNomEmp.ToUpper();

        }

        private int Obtiene_Imp_del_HIH()
        {

            int result = 0;
            int hEjeEmp2 = 0;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblSql2 = "reporte_eje_banamex2 " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lEmpNum)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //13.11.2001 Código anterior comentado por EISSA
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //  pszgblSql2 = "reporte_eje_banamex2 " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lEmpNum)
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //13.11.2001 Fin de Código anterior comentado por EISSA

            //EISSA 13.11.2001 Inicio de Código Nuevo para modificación de la fecha de corte
            CORVAR.pszgblSql2 = "reporte_eje_banamex2 " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesDiaACG).ToString() + "," + lEmpNum.ToString();
            //EISSA 13.11.2001 Fin de Código Nuevo

            if (CORPROC2.Obtiene_Datos() != 0)
            {
                dSaldoAnterior = CORVB.NULL_INTEGER;
                dPagosAbonos = CORVB.NULL_INTEGER;
                dComisiones = CORVB.NULL_INTEGER;
                dIntereses = CORVB.NULL_INTEGER;
                dIva = CORVB.NULL_INTEGER;

                if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                {
                    dSaldoAnterior = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                    dPagosAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 2));
                    dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 3));
                    dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 4));
                    dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                    dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                }

                dTotSaldoAnt += dSaldoAnterior;
                dTotPagos += dPagosAbonos;
                dTotComisiones += dComisiones;
                dTotIntereses += dIntereses;
                dTotIva += dIva;
            }
            else
            {
                result = 0;
                lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
                return result; //Salimos de la función
            }
            lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2); //Realiza fin de Query

            return -1;

        }

        //UPGRADE_NOTE: (7001) The following declaration (Select_de_Eje_Emp) seems to be dead code
        //private string Select_de_Eje_Emp()
        //{
        //
        //
        //string result = String.Empty;
        //result = CORVB.NULL_STRING;
        //
        //CORVAR.pszgblsql = "select MTCEJE01.emp_num,";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nombre,eje_num_nom,eje_centro_c,hih_corte_a,";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "sum(hih_saldo_anterior), sum(hih_pagos_y_abonos),";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " sum(hih_comisiones), sum(hih_intereses) ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCHIH01, MTCEJE01 ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "where MTCEJE01.eje_prefijo = " + Conversion.Str(CORVAR.igblPref);
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "and MTCEJE01.gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "and MTCEJE01.emp_num = " + Conversion.Str(CORVAR.lgblNumEmpresaR);
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and MTCHIH01.eje_num = MTCEJE01.eje_num ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "and MTCHIH01.emp_num = MTCEJE01.emp_num ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "and hih_corte_md = " + Conversion.Str(CORVAR.igblMesDiaACG);
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and hih_corte_a > 0 ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "group by MTCEJE01.eje_prefijo,MTCEJE01.gpo_banco,MTCEJE01.emp_num,MTCEJE01.eje_num,";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "MTCEJE01.eje_roll_over,MTCEJE01.eje_digit,";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "MTCEJE01.eje_nombre,";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "MTCEJE01.eje_num_nom, ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "MTCEJE01.eje_centro_c,hih_corte_a";
        //
        //return CORVAR.pszgblsql;
        //
        //}
    }
}