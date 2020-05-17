using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORRPANG
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**          CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas          **
        //**                                                                        **
        //**       -----------------------------------------------------------      **
        //**                                                                        **
        //**       Descripción: Obtiene los consumos por giro                       **
        //**                                                                        **
        //**       Responsable: Hugo L. Morales Garcia                              **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 28/Abril/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************
        public bool FormNeedsToClose = false;
        int hConexion = 0; //La conexion a la base de datos
        string pszSentencia = String.Empty;
        int iErr = 0;
        string[] pszArrClaves = null;
        //EISSA 06.11.2001 Variables para manejo de Fecha de corte correspondiente a la empresa actual
        int ilDiaCorte = 0;
        int ilCicloCorte = 0;

        FarPoint.Win.Spread.CellType.EditBaseCellType CorpangCell = new FarPoint.Win.Spread.CellType.EditBaseCellType();

        //EISSA Fin de declaración de variables

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Obtiene los datos principales de la empresa en      **
        //**                    Consulta para desplegarlos en el Reporte            **
        //**                                                                        **
        //**       Declaración: Sub Datos_Empresa()                                 **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr - Error generado                           **
        //**                                                                        **
        //**       Ultima modificacion: 060694                                      **
        //**                                                                        **
        //****************************************************************************
        private void Datos_Empresa()
        {

            string pszNomEmpresa = String.Empty;
            string pszCalleFis = String.Empty;
            string pszColoniaFis = String.Empty;
            string pszCiudadFis = String.Empty;
            string pszPoblacionFis = String.Empty;
            string pszEstadoFis = String.Empty;
            int lCpFis = 0;
            int hBufDatEmp = 0;
            int iTempErr = 0;

            iErr = CORCONST.OK;

            CORVAR.pszgblsql = "select emp_nom, emp_fiscal_calle, emp_fiscal_col, emp_fiscal_cp, emp_fiscal_ciu, emp_fiscal_pob, emp_fiscal_edo";
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = pszgblsql + " from " + DB_SYB_EMP + " where  gpo_banco=" + Format$(igblBanco) + " and emp_num =" + Format$(lgblNumEmpresaR)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYB_EMP + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and  gpo_banco=" + CORVAR.igblBanco.ToString() + " and emp_num =" + CORVAR.lgblNumEmpresaR.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****


            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {

                    pszNomEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    ID_ACG_DEM_TXT[0].Text = pszNomEmpresa.ToUpper();
                    pszCalleFis = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_ACG_DEM_TXT[1].Text = pszCalleFis.ToUpper();
                    pszColoniaFis = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    ID_ACG_DEM_TXT[2].Text = "COL. " + pszColoniaFis.ToUpper();
                    lCpFis = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
                    pszCiudadFis = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                    pszEstadoFis = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                    ID_ACG_DEM_TXT[3].Text = pszCiudadFis.Trim().ToUpper() + ",  " + pszEstadoFis.Trim();
                    //iTempErr = qeValCharBuf(hBufDatEmp, pszPoblacionFis, 6, NULL_STRING, LNG_EMP_FISCALPOB)
                    //ID_ACG_DEM_TXT(4) = UCase$(pszPoblacionFis)

                    ID_ACG_DEM_TXT[4].Text = "C.P. " + StringsHelper.Format(lCpFis, "00000");

                }
            }
            else
            {
                //AIS-1182 NGONZALEZ
                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                FormNeedsToClose = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Obtiene la información correspondiente a los        **
        //**                    gastos de la empresa en Consulta                    **
        //**                                                                        **
        //**       Declaración: Sub Datos_Empresa()                                 **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr - Error generado                           **
        //**                                                                        **
        //**       Ultima modificacion: 060694                                      **
        //**                                                                        **
        //****************************************************************************
        private void Detalle_Giro()
        {

            int hBufANG = 0; //El apuntador a la sentencia SQL
            int iTempErr = 0; //Control local
            FixedLengthString szCadena = new FixedLengthString(50);
            int iCont = 0;
            int iMes = 0;
            int iAño = 0;
            string pszTempMA = String.Empty;
            string pszINNumSGO = String.Empty;
            string pszINNumARA = String.Empty;
            int iPos = 0;
            double dTotal = 0;

            string pszSegmento = String.Empty;


            iErr = CORCONST.OK;

            //Cantidades que el numero del negocio es <> 0
            //ros  igblErr = qeSetSelectOptions(hconexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "reporte_anal_giro " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //06.11.2001  EISSA Código Anterior
            //  pszgblsql = "reporte_anal_giro " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
            //06.11.2001  EISSA Fin de Código Anterior
            //EISSA 09.11.2001  Código Nuevo, para enviar el parámetro de fecha de corte personalizado por empresa
            CORVAR.pszgblsql = "reporte_anal_giro " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
            //EISSA 09.11.2001  Fin de Código Nuevo

            //***** FIN DE CODIGO NUEVO FSWBMX *****

            int iRegs = CORPROC2.Cuenta_Registros();

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                iCont = CORVB.NULL_INTEGER;
                if (iRegs != CORVB.NULL_INTEGER)
                {
                    pszArrClaves = ArraysHelper.InitializeArray<string[]>(new int[] { iRegs }, new int[] { 0 });

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        dTotal = CORVB.NULL_INTEGER;
                        szCadena.Value = CORVB.NULL_STRING;

                        iCont++;
                        ID_GIR_CON_SS.MaxRows = iCont;

                        szCadena.Value = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                        dTotal = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));

                        if (dTotal != CORVB.NULL_INTEGER)
                        {
                            ID_GIR_CON_SS.Row = iCont;
                            ID_GIR_CON_SS.Col = 1;
                            ID_GIR_CON_SS.Text = szCadena.Value;
                            ID_GIR_CON_SS.Col = 2;
                            ID_GIR_CON_SS.CellType = CorpangCell;
                            ID_GIR_CON_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                            ID_GIR_CON_SS.TypeFloatSeparator = true;
                            ID_GIR_CON_SS.Text = StringsHelper.Format(dTotal, "##,###,###,##0.00");

                            pszArrClaves[iCont - 1] = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString() + "*";
                            pszArrClaves[iCont - 1] = pszArrClaves[iCont - 1] + Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)).ToString();
                        }
                    };
                }
                else
                {
                    iErr = -1; //No hay registros
                }
            }
            else
            {
                iErr = -1; //No hay registros
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //Cargos con numero de negocio = 0
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "anal_giro_cargos " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //15.10.2001 EISSA Código Anterior
            //  pszgblsql = "anal_giro_cargos " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
            //15.10.2001 EISSA Fin de Código Anterior
            //EISSA 09.11.2001   Código Nuevo, para enviar el parámetro de fecha personalizado por empresa
            //CORVAR.pszgblsql = "anal_giro_cargos " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
            //EISSA 09.11.2001   Fin de Código Nuevo
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //if (CORPROC2.Obtiene_Registros() != 0)
            //{
            //    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
            //    {
            //        dTotal = CORVB.NULL_INTEGER;
            //        dTotal = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));

            //        if (dTotal > CORVB.NULL_INTEGER)
            //        {
            //            iCont++;
            //            ID_GIR_CON_SS.MaxRows = iCont;

            //            ID_GIR_CON_SS.Row = iCont;
            //            ID_GIR_CON_SS.Col = 1;
            //            ID_GIR_CON_SS.Text = "OTROS CARGOS";
            //            ID_GIR_CON_SS.Col = 2;
            //            ID_GIR_CON_SS.CellType = (FPSpreadADO.CellTypeConstants)1;
            //            ID_GIR_CON_SS..TypeHAlign = (FPSpreadADO.TypeHAlignConstants)1;;
            //            ID_GIR_CON_SS.TypeFloatSeparator = true;
            //            ID_GIR_CON_SS.Text = StringsHelper.Format(dTotal, "##,###,###,##0.00");
            //        }
            //    } else
            //    {
            //        iErr = -1; //No hay registros
            //    }
            //} else
            //{
            //    iErr = -1; //No hay registros
            //}
            //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //Pagos y Abonos con numero de negocio = 0
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "anal_giro_abonos " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //15.10.2001 EISSA Código Anterior
            //  pszgblsql = "anal_giro_abonos " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
            //15.10.2001 EISSA Fin de Código Anterior
            //EISSA 09.11.2001   Código Nuevo, para enviar el parámetro de fecha personalizado por empresa
            CORVAR.pszgblsql = "anal_giro_abonos " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
            //EISSA 09.11.2001   Fin de Código Nuevo
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    dTotal = CORVB.NULL_INTEGER;
                    dTotal = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));

                    if (dTotal > CORVB.NULL_INTEGER)
                    {
                        iCont++;
                        ID_GIR_CON_SS.MaxRows = iCont;

                        ID_GIR_CON_SS.Row = iCont;
                        ID_GIR_CON_SS.Col = 1;
                        ID_GIR_CON_SS.Text = "OTROS PAGOS Y ABONOS";
                        ID_GIR_CON_SS.Col = 2;
                        ID_GIR_CON_SS.CellType = CorpangCell;
                        ID_GIR_CON_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        ID_GIR_CON_SS.TypeFloatSeparator = true;
                        ID_GIR_CON_SS.Text = StringsHelper.Format(dTotal, "##,###,###,##0.00");
                    }
                }
                else
                {
                    iErr = -1; //No hay registros
                }
            }
            else
            {
                iErr = -1; //No hay registros
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void CORRPANG_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                CORVAR.igblFormaActiva = CORCONST.INT_ACT_ANG;
                CORPROC.Cambia_StatusOpciones(-1);

            }
        }

        //UPGRADE_WARNING: (2065) Form event CORRPANG.Deactivate has a new behavior.
        private void CORRPANG_Deactivate(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            CORPROC.Cambia_StatusOpciones(0);

        }

        private void CORRPANG_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {


            int bExisten = -1;
            CORVAR.igblMesCorte = CORVAR.igblMesDiaACG;

            Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2);
            Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(Height))) / 2);

            this.Cursor = Cursors.WaitCursor;

            Formatea_SS();
            Detalle_Giro();
            if (iErr == CORCONST.OK)
            {
                Datos_Empresa();
                if (iErr == CORCONST.OK)
                {
                    if (ID_GIR_CON_SS.MaxRows == CORVB.NULL_INTEGER)
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        bExisten = 0;
                        //AIS-1182 NGONZALEZ
                        //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        FormNeedsToClose = true;
                    }
                    else
                    {
                        Resumen_Giro();
                        if (iErr != CORCONST.OK)
                        {
                            this.Cursor = Cursors.Default;
                            //AIS-1182 NGONZALEZ
                            //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                            FormNeedsToClose = true;
                        }
                    }
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                bExisten = 0;
                FormNeedsToClose = true;
                //AIS-1182 NGONZALEZ
                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                return;
            }

        }

        private void CORRPANG_Closed(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            CORPROC.Cambia_StatusOpciones(0);

            this.Cursor = Cursors.Default;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Asigna títulos, Anchuras y tipos de datos a las     **
        //**                    celdas del Spread                                   **
        //**                                                                        **
        //**       Declaración: Sub formatea_SS                                     **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma :                                                 **
        //**                                                                        **
        //**       Ultima modificacion: 060694                                      **
        //**                                                                        **
        //****************************************************************************
        private void Formatea_SS()
        {

            ID_GIR_CON_SS.set_ColWidth(1, 48 * 5);
            ID_GIR_CON_SS.set_ColWidth(2, 18 * 5);

            ID_GIR_CON_SS.Row = 0;
            ID_GIR_CON_SS.Col = 1;
            ID_GIR_CON_SS.Text = "Segmentos";
            ID_GIR_CON_SS.Col = 2;
            ID_GIR_CON_SS.Text = "Monto";

            ID_GIR_CON_SS.Row = -1;
            ID_GIR_CON_SS.CellType = CorpangCell;

            ID_GIR_CON_SS.Col = -1;
            ID_GIR_CON_SS.Row = -1;
            //  ID_GIR_CON_SS.AllowSelBlock = False
            //  ID_GIR_CON_SS.AllowResize = False

        }

        private void ID_GIR_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                CORPROC.Imprime_Reporte();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "()", e);
            }
        }

        private void ID_GIR_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Obtiene el estado de resultados de la empresa       **
        //**                    en consulta                                         **
        //**                                                                        **
        //**       Declaración: Sub Resumen_Giro()                                  **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr - Error generado                           **
        //**                                                                        **
        //**       Ultima modificacion: 060694                                      **
        //**                                                                        **
        //****************************************************************************
        private void Resumen_Giro()
        {

            int hBufANG = 0; //El apuntador a la sentencia SQL
            int iTempErr = 0; //Control local
            double dSaldoAnt = 0;
            double dPagosyAbonos = 0;
            double dComisiones = 0;
            double dIntereses = 0;
            double dIva = 0;
            double dCompras = 0;
            double dDisposiciones = 0;
            int iMes = 0;
            int iAño = 0;
            string pszTempMA = String.Empty;

            iErr = CORCONST.OK;

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "exec reporte_anal_saldos " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //Código Anterior comentado 06.10.2001
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //  pszgblsql = "exec reporte_anal_saldos " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //Fin de Código Anterior
            //EISSA 09.11.2001   Código Nuevo, para enviar el parámetro de fecha personalizado por empresa
            CORVAR.pszgblsql = "exec reporte_anal_saldos " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
            //EISSA 09.11.2001   Fin de Código Nuevo

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    dSaldoAnt = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                    dPagosyAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));
                    dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3));
                    dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
                    dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                    dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL

                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //    pszgblsql = "exec reporte_anal_compras " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX *****
                //    pszgblsql = "exec reporte_anal_compras " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                //EISSA 07.11.2001 Cambio para extraer la Fecha de Corte a partir de cada Empresa
                CORVAR.pszgblsql = "exec reporte_anal_compras " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
                //EISSA 07.11.2001 Fin de Cambio

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL

                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //      pszgblsql = "exec reporte_anal_disposiciones " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //Código Anterior Comentador por EISSA 07.11.2001
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    //      pszgblsql = "exec reporte_anal_disposiciones " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
                    //***** FIN DE CODIGO NUEVO FSWBMX *****
                    //Fin Código Anterior Comentador por EISSA 07.11.2001
                    //EISSA 07.11.2001 Cambio para extraer la Fecha de Corte a partir de cada Empresa y su respectivo ciclo de corte
                    CORVAR.pszgblsql = "exec reporte_anal_disposiciones " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
                    //EISSA 07.11.2001 Fin de Cambio

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            dDisposiciones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL
                    }
                    else
                    {
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL
                        //AIS-1182 NGONZALEZ
                        //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        FormNeedsToClose = true;
                    }
                }
                else
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL
                    //AIS-1182 NGONZALEZ
                    //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    FormNeedsToClose = true;
                }
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL
                //AIS-1182 NGONZALEZ
                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                FormNeedsToClose = true;
            }

            ID_ACG_RES_TXT[0].Text = StringsHelper.Format(dSaldoAnt, "$##,###,###,##0.00");
            ID_ACG_RES_TXT[1].Text = StringsHelper.Format(dCompras, "$##,###,###,##0.00");
            ID_ACG_RES_TXT[2].Text = StringsHelper.Format(dDisposiciones, "$##,###,###,##0.00");
            ID_ACG_RES_TXT[3].Text = StringsHelper.Format(dPagosyAbonos, "$##,###,###,##0.00");
            ID_ACG_RES_TXT[4].Text = StringsHelper.Format(dComisiones, "$##,###,###,##0.00");
            ID_ACG_RES_TXT[5].Text = StringsHelper.Format(dIntereses, "$##,###,###,##0.00");
            ID_ACG_RES_TXT[6].Text = StringsHelper.Format(dIva, "$##,###,##0.00");
            ID_ACG_RES_TXT[7].Text = StringsHelper.Format(dSaldoAnt + dCompras + dDisposiciones - dPagosyAbonos + dComisiones + dIntereses + dIva, "$##,###,###,##0.00");

            this.Cursor = Cursors.Default;


        }
    }
}