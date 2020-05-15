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
    internal partial class CORRPDAT
        : System.Windows.Forms.Form
    {

        //'**********************************************************
        //*
        //*    Descripción : Módulo de Reporte de Concetrado
        //*                  por ejecutivos de empresas.
        //*
        //*    Fecha de Inicio : 2/05/94
        //*
        //*    Responsable: Alfonso Chaparro Rojas
        //*
        //**********************************************************
        public bool flag = false;
        int iEjePrefijo = 0;
        int iGpoBanco = 0;
        int lEmpNum = 0;
        int lEjeNum = 0;
        int iEjeRollOver = 0;
        int iEjeDigit = 0;
        int iEjeNum = 0;
        int lEjeNumNom = 0;
        int iNumMesesVenc = 0;
        int iAñoMesVenc = 0;
        FixedLengthString szCentroCostos = new FixedLengthString(CORBD.LNG_EJE_CC);
        string pszCuenta = String.Empty;
        FixedLengthString szEjeNombre = new FixedLengthString(CORBD.LNG_EJE_NOM);
        FixedLengthString szNomGraEje = new FixedLengthString(CORBD.LNG_THS_NOMBRE);
        double dSaldoAnterior = 0;
        double dPagosAbonos = 0;
        double dDispEfec = 0;
        double dSaldoNuevo = 0;
        double dSaldoAnt = 0;
        double dCompras = 0;
        double dDisposiciones = 0;
        double dPagosyAbonos = 0;
        double dComisiones = 0;
        double dIntereses = 0;
        double dIva = 0;

        //Variables para totales
        double dTotSaldoAnt = 0;
        double dTotPagos = 0;
        double dTotComisiones = 0;
        double dTotIntereses = 0;
        double dTotCompras = 0;
        double dTotDispEfec = 0;
        double dTotIva = 0;
        double dTotSaldoNuevo = 0;

        //Variables requeridas para la conexión a Sybase
        int hConexion = 0;
        int igblRetorna2 = 0;

        FixedLengthString szLeyenda = new FixedLengthString(CORBD.LNG_MSG_RENGLON);

        int intCont = 0;

        FarPoint.Win.Spread.CellType.EditBaseCellType CorpdatCell = new FarPoint.Win.Spread.CellType.EditBaseCellType();

        private void Carga_Leyenda()
        {

            int hStmt = 0;
            string pszSentencia = String.Empty;

            CORVAR.pszgblLeyenda = CORVB.NULL_STRING;

            CORVAR.pszgblsql = "Select msg_renglon from " + CORBD.DB_SYB_MSG;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where msg_forma ='CORRPDEJ'";

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    szLeyenda.Value = CORVB.NULL_STRING;
                    szLeyenda.Value = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    CORVAR.pszgblLeyenda = CORVAR.pszgblLeyenda + szLeyenda.Value;
                };
            }
            else
            {
                //Ocurrio algun error en la ejecución SQL
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Ocurrio un error al tratar de obtener las Leyendas de la Base de Datos. Consulte a su Administrador del Sistema y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                return; //Salimos de la función
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void Carga_Reporte()
        {

            int hEjeEmp1 = 0;
            int hEjeEmp2 = 0;
            string pszTempCuenta = String.Empty;
            double dInterTemp = 0;
            string pszTempCad1 = String.Empty;
            string pszTempCad2 = String.Empty;
            string pszTempCad3 = String.Empty;
            int iPosicion1 = 0;
            int iPosicion2 = 0;

            //Realiza Conexión
            this.Cursor = Cursors.WaitCursor;

            //Inicializamos las variables que almacenaran los datos
            Inicializa_Variables();
            CORPROC2.Libera_Memoria(CORVAR.hgblConexion); //Limpia el buffer antes de ejecutar alguna instrucciòn por si las dudas

            //Obtiene los Campos de la tabla de Ejecutivos de la Empresa
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "spS_Detalle_Atrazo  " + Str(lgblNumEmpresaR) + "," + Str(igblMesDiaACG) + "," + Format$(iAñoMesVenc) + "," + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //  pszgblsql = "spS_Detalle_Atrazo  " + Str(lgblNumEmpresaR) + "," + Str(igblMesDiaACG) + "," + Format$(iAñoMesVenc) + "," + Format$(igblPref) + "," + Format$(igblBanco)
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //EISSA 09.11.2001 Código Nuevo Cambio de parámetros de los Sp's, ahora sólo se requiere utilizar el mes actual
            CORVAR.pszgblsql = "spS_Detalle_Atrazo  " + Conversion.Str(CORVAR.lgblNumEmpresaR) + "," + Formato.ifncMes(CORVAR.igblMesDiaACG).ToString() + "," + iAñoMesVenc.ToString() + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
            //EISSA 09.11.2001 Fin de Código Nuevo

            if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
            {
                do
                {
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        //Obtenemos los Registros regresados por el Select
                        dSaldoAnterior = CORVB.NULL_INTEGER;
                        dCompras = CORVB.NULL_INTEGER;
                        dDispEfec = CORVB.NULL_INTEGER;
                        dPagosAbonos = CORVB.NULL_INTEGER;
                        dComisiones = CORVB.NULL_INTEGER;
                        dIntereses = CORVB.NULL_INTEGER;
                        dIva = CORVB.NULL_INTEGER;
                        dSaldoNuevo = CORVB.NULL_INTEGER;

                        iEjePrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        iGpoBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                        lEmpNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                        lEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
                        iEjeRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
                        iEjeDigit = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
                        szEjeNombre.Value = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                        lEjeNumNom = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8)));
                        szCentroCostos.Value = VBSQL.SqlData(CORVAR.hgblConexion, 9);
                        iNumMesesVenc = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10)));
                        dSaldoAnterior = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 13));
                        dPagosAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 14));
                        dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 15));
                        dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 16));
                        dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                        dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;

                        //Damos Formato a la cuenta obtenida
                        //***** Código Anterior     ***********
                        //      pszTempCuenta = Format(iEjePrefijo, "0000") + Format(iGpoBanco, "00") + Format(lEmpNum, "00000") + Format(lEjeNum, "000") + Format(iEjeRollOver, "0") + Format(iEjeDigit, "0")
                        //***** Fin Código Anterior ***********
                        //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
                        pszTempCuenta = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iGpoBanco, "00") + StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(lEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iEjeRollOver, "0") + StringsHelper.Format(iEjeDigit, "0");
                        //EISSA 05.10.2001 FIN

                        pszCuenta = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 9, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 13, 4);

                        //***** Código Anterior     ***********
                        //      ID_DAT_NUM_TXT(0).Caption = Mid$(pszTempCuenta, 1, 4) + Space$(1) + Mid$(pszTempCuenta, 5, 7)
                        //***** Fin Código Anterior ***********
                        //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
                        ID_DAT_NUM_TXT[0].Text = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 2) + StringsHelper.Format(Strings.Mid(pszTempCuenta, 7, Formato.sMascara(Formato.iTipo.Empresa).Length), Formato.sMascara(Formato.iTipo.Empresa));
                        //EISSA 05.10.2001 FIN

                        //Obtiene el nombre de grabación del Ejecutivo del THS
                        szNomGraEje.Value = CORVB.NULL_STRING;
                        szNomGraEje.Value = VBSQL.SqlData(CORVAR.hgblConexion, 12);
                        iPosicion1 = (szNomGraEje.Value.IndexOf(',') + 1);
                        iPosicion2 = (szNomGraEje.Value.IndexOf('/') + 1);
                        if (iPosicion1 == 0 || iPosicion2 == 0)
                        {
                            szNomGraEje.Value = "";
                        }
                        else
                        {
                            pszTempCad1 = szNomGraEje.Value.Substring(0, Math.Min(szNomGraEje.Value.Length, iPosicion1 - 1));
                            pszTempCad2 = Strings.Mid(szNomGraEje.Value, iPosicion1 + 1, (iPosicion2 - iPosicion1) - 1);
                            pszTempCad3 = Strings.Mid(szNomGraEje.Value, iPosicion2 + 1, CORBD.LNG_THS_NOM);
                            szNomGraEje.Value = pszTempCad1.Trim() + " " + pszTempCad2.Trim() + " " + pszTempCad3.Trim();
                        }

                        //Obtiene las compras ó consumos de la tabla Histórico Detalle
                        dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 17));

                        //Obtiene las disposiciones de la tabla Histórico Detalle
                        dDispEfec = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 18));

                        //Calcula el nuevo saldo
                        dSaldoNuevo = dSaldoAnterior + dCompras + dDispEfec + dComisiones + dIntereses + dIva - dPagosAbonos;

                        //Calcula el nuevo saldo Total
                        dTotSaldoNuevo += dSaldoNuevo;

                        Llena_Detalle(); //Llena spread de detalle de ejecutivos

                    }
                }
                while (VBSQL.SqlResults(CORVAR.hgblConexion) != 2);

                //igblRetorna = SqlCancel(hgblConexion)  'Realiza fin de Query
                CORPROC2.Libera_Memoria(CORVAR.hgblConexion); //Limpia el buffer antes de ejecutar alguna instrucciòn por si las dudas

                Coloca_totales(); //Calcula totales del Datalle

                if (~Datos_Empresa() != 0)
                { //Obtiene los Datos de la Empresa
                    return;
                }

                //Resumen_Giro                   'Obtine el Resumen concentrado

                Llena_Concentrado(); //Llena el Resumen concentrado

                ID_CEJ_REP_SS.ReDraw = true;
                ID_CEJ_REP_SS.Visible = true;
                this.Cursor = Cursors.Default;

            }
            else
            {
                this.Cursor = Cursors.Default;
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORRPDAT.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
                return; //Salimos de la función
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


        }

        private void Coloca_totales()
        {


            //Asigna el máximo de renglones
            ID_CEJ_REP_SS.MaxRows++;
            ID_CEJ_REP_SS.Row = ID_CEJ_REP_SS.MaxRows;

            //Formatea ultimo renglon
            for (int iCont = 1; iCont <= 13; iCont++)
            {
                ID_CEJ_REP_SS.Col = iCont;
                ID_CEJ_REP_SS.BackColor = Color.Silver;
            }

            ID_CEJ_REP_SS.Col = 1;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CEJ_REP_SS.Text = "Total";

            //Saldo Anterior
            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotSaldoAnt, "##,###,###,##0.00");

            //Consumos
            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotCompras, "##,###,###,##0.00");

            //Disposición de Efectivo
            ID_CEJ_REP_SS.Col = 8;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotDispEfec, "##,###,###,##0.00");

            //Pagos y Abonos
            ID_CEJ_REP_SS.Col = 9;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotPagos, "##,###,###,##0.00");

            //Comisiones
            ID_CEJ_REP_SS.Col = 10;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotComisiones, "##,###,###,##0.00");

            //Intereses
            ID_CEJ_REP_SS.Col = 11;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotIntereses, "##,###,###,##0.00");

            //IVA
            ID_CEJ_REP_SS.Col = 12;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotIva, "##,###,###,##0.00");

            //Saldo Nuevo
            ID_CEJ_REP_SS.Col = 13;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotSaldoNuevo, "##,###,###,##0.00");

        }

        private int Datos_Empresa()
        {

            int result = 0;
            string pszNomEmpresa = String.Empty;
            string pszCalleFis = String.Empty;
            string pszColoniaFis = String.Empty;
            string pszCiudadFis = String.Empty;
            string pszPoblacionFis = String.Empty;
            string pszEstadoFis = String.Empty;
            int lCpFis = 0;
            int hBufDatEmp = 0;
            string pszSentencia = String.Empty;

            CORVAR.pszgblsql = "select emp_nom, emp_fiscal_calle, emp_fiscal_col, emp_fiscal_cp, emp_fiscal_ciu, emp_fiscal_pob, emp_fiscal_edo,emp_cta_capt";
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = pszgblsql + " from " + DB_SYB_EMP + " where emp_num =" + Format$(lgblNumEmpresaR) + " and gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //pszgblsql = pszgblsql + " from " + DB_SYB_EMP + " where emp_num =" + Format$(lgblNumEmpresaR) + " and eje_prefijo=" + Format$(igblPref) + " and gpo_banco=" + Format$(igblBanco)
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYB_EMP + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and emp_num=" + CORVAR.lgblNumEmpresaR.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {

                    pszNomEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    ID_DAT_DEM_TXT[0].Text = pszNomEmpresa.ToUpper();
                    pszCalleFis = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_DAT_DEM_TXT[1].Text = pszCalleFis.ToUpper();
                    pszColoniaFis = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    ID_DAT_DEM_TXT[2].Text = "COL. " + pszColoniaFis.ToUpper();
                    lCpFis = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
                    pszCiudadFis = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                    pszPoblacionFis = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                    pszEstadoFis = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                    ID_DAT_DEM_TXT[3].Text = pszCiudadFis.Trim().ToUpper() + ", " + pszEstadoFis;
                    ID_DAT_DEM_TXT[4].Text = "C.P. " + StringsHelper.Format(lCpFis, "00000");
                    ID_DAT_DEM_TXT[5].Text = CORVB.NULL_STRING;
                    //Guarda la cuenta de cheques para imprimirse en la leyenda del reporte
                    ID_DAT_CUE_TXT[0].Tag = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8)).ToString();
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
                    //CORVAR.igblErr = API.USER.PostMessage(CORRPDAT.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
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

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query

            return -1;

        }

        //UPGRADE_NOTE: (7001) The following declaration (Envia_Error) seems to be dead code
        //private void  Envia_Error( int hStmt)
        //{
        //
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
        //
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("Error de Lectura en la Base de Datos. Consulte a su Administrador del Sistema y Vuelva a Intentar", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
        //AIS-1182 NGONZALEZ
        //CORVAR.igblErr = API.USER.PostMessage(CORRPDAT.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
        //
        //}


        private void CORRPDAT_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                CORVAR.igblFormaActiva = CORCONST.INT_ACT_DAT;
                CORPROC.Cambia_StatusOpciones(-1);

            }
        }

        //UPGRADE_WARNING: (2065) Form event CORRPDAT.Deactivate has a new behavior.
        private void CORRPDAT_Deactivate(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            CORPROC.Cambia_StatusOpciones(0);

        }

        private void CORRPDAT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            intCont = CORDBLIB.Segunda_ConexionServidor();

            if (intCont != 0)
            {
                CORVAR.igblMesCorte = CORVAR.igblMesDiaACG;
                iAñoMesVenc = CORVAR.igblAñoCorte;

                Formatea_Spread();
                Carga_Reporte();
                Carga_Leyenda();
                VBSQL.subCanConRec(ref intCont);
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORRPDEJ.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

        }

        private void CORRPDAT_Closed(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            CORPROC.Cambia_StatusOpciones(0);
            //Realiza Desconexión
            VBSQL.SqlClose(CORVAR.hgblConexion2);

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
            ID_CEJ_REP_SS.set_ColWidth(1, 6 * 9);
            ID_CEJ_REP_SS.Text = "Cuenta";

            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.set_ColWidth(2, 20 * 3);
            ID_CEJ_REP_SS.Text = "Ejecutivo";

            ID_CEJ_REP_SS.Col = 3;
            ID_CEJ_REP_SS.set_ColWidth(3, 10 * 6);
            ID_CEJ_REP_SS.Text = "# Nómina";

            ID_CEJ_REP_SS.Col = 4;
            ID_CEJ_REP_SS.set_ColWidth(4, 10 * 6);
            ID_CEJ_REP_SS.Text = "C. Costos";

            ID_CEJ_REP_SS.Col = 5;
            ID_CEJ_REP_SS.set_ColWidth(5, 10 * 6);
            ID_CEJ_REP_SS.Text = "Atrasos";

            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.set_ColWidth(6, 15 * 6);
            ID_CEJ_REP_SS.Text = "Saldo Anterior";

            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.set_ColWidth(7, 10 * 7);
            ID_CEJ_REP_SS.Text = "Consumos";

            ID_CEJ_REP_SS.Col = 8;
            ID_CEJ_REP_SS.set_ColWidth(8, 10 * 7);
            ID_CEJ_REP_SS.Text = "Disp. Efvo.";

            ID_CEJ_REP_SS.Col = 9;
            ID_CEJ_REP_SS.set_ColWidth(9, 10 * 6);
            ID_CEJ_REP_SS.Text = "Pagos";

            ID_CEJ_REP_SS.Col = 10;
            ID_CEJ_REP_SS.set_ColWidth(10, 10 * 7);
            ID_CEJ_REP_SS.Text = "Comisiones";

            ID_CEJ_REP_SS.Col = 11;
            ID_CEJ_REP_SS.set_ColWidth(11, 10 * 7);
            ID_CEJ_REP_SS.Text = "Gtos. Cobr.";

            ID_CEJ_REP_SS.Col = 12;
            ID_CEJ_REP_SS.set_ColWidth(12, 10 * 6);
            ID_CEJ_REP_SS.Text = "I.V.A.";

            ID_CEJ_REP_SS.Col = 13;
            ID_CEJ_REP_SS.set_ColWidth(13, 15 * 6);
            ID_CEJ_REP_SS.Text = "Saldo Nuevo";

            //Da Tipo de Celda a las celdas que lo requieran
            ID_CEJ_REP_SS.MaxRows = 1;

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

        private void ID_CEJ_LEY_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORLEYEN.DefInstance.ShowDialog();

            this.Cursor = Cursors.Default;

        }

        private void ID_CEJ_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Close();

            this.Cursor = Cursors.Default;

        }

        private void Inicializa_Variables()
        {

            dTotSaldoAnt = CORVB.NULL_INTEGER;
            dTotCompras = CORVB.NULL_INTEGER;
            dTotDispEfec = CORVB.NULL_INTEGER;
            dTotPagos = CORVB.NULL_INTEGER;
            dTotComisiones = CORVB.NULL_INTEGER;
            dTotIntereses = CORVB.NULL_INTEGER;
            dTotIva = CORVB.NULL_INTEGER;
            dTotSaldoNuevo = CORVB.NULL_INTEGER;

        }

        private void Llena_Concentrado()
        {

            int hEmpGpo1 = 0;
            int hEmpGpo3 = 0;
            int hEmpGpo4 = 0;
            int lEmpNum = 0;
            int hEjeEmp1 = 0;
            int hEjeEmp2 = 0;
            int hEjeEmp3 = 0;
            string pszTempCuenta = String.Empty;
            int iError = 0;

            dTotSaldoAnt = CORVB.NULL_INTEGER;
            dTotCompras = CORVB.NULL_INTEGER;
            dTotDispEfec = CORVB.NULL_INTEGER;
            dTotPagos = CORVB.NULL_INTEGER;
            dTotComisiones = CORVB.NULL_INTEGER;
            dTotIntereses = CORVB.NULL_INTEGER;
            dTotIva = CORVB.NULL_INTEGER;
            dTotSaldoNuevo = CORVB.NULL_INTEGER;

            //**************************************************************
            //* Se modifico con motivo de la forma de extraer los concentra-
            //* dos para los casos en que el grupo fuera cero
            //* 19/Nov/96
            //**************************************************************

            if (CORVAR.lgblGpoCve != 0)
            {
                //Obtiene los Campos de la tabla de Ejecutivos Banamex
                //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //pszgblsql = "reporte_empresa " + Str(lgblGpoCve) + "," + Str(igblBanco) + "," + Str(igblMesCorte)
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //09.11.2001 EISSA Inicio Código Anterior
                //  '***** INICIO CODIGO NUEVO FSWBMX *****
                //   pszgblsql = "reporte_empresa " + Str(lgblGpoCve) + "," + Str(igblPref) + "," + Str(igblBanco) + "," + Str(igblMesCorte)
                //  '***** FIN DE CODIGO NUEVO FSWBMX *****
                //09.11.2001 EISSA Fin Código Anterior
                //EISSA 09.11.2001 Código Nuevo Cambio de parámetro de periodo de los SP's
                CORVAR.pszgblsql = "reporte_eje_empresa " + Conversion.Str(CORVAR.lgblNumEmpresaR) + "," + Conversion.Str(CORVAR.igblPref) + "," + Conversion.Str(CORVAR.igblBanco) + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString();
                //EISSA 09.11.2001 Fin de Código Nuevo

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    //Permite obtener registros

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        dSaldoAnterior = CORVB.NULL_INTEGER;
                        dCompras = CORVB.NULL_INTEGER;
                        dDispEfec = CORVB.NULL_INTEGER;
                        dPagosAbonos = CORVB.NULL_INTEGER;
                        dComisiones = CORVB.NULL_INTEGER;
                        dIntereses = CORVB.NULL_INTEGER;
                        dIva = CORVB.NULL_INTEGER;
                        dSaldoNuevo = CORVB.NULL_INTEGER;

                        lEmpNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        dSaldoAnterior = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3));
                        dPagosAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
                        dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
                        dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6));
                        dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                        dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;

                        //Obtiene los Campos de la tabla de Ejecutivos Banamex
                        //***** INICIO CODIGO ANTERIOR FSWBMX *****
                        //pszgblSql2 = "exec reporte_anal_compras " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpNum)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                        //09.11.2001 EISSA Código Anterior
                        //      '***** INICIO CODIGO NUEVO FSWBMX *****
                        //      pszgblSql2 = "exec reporte_anal_compras " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpNum)
                        //      '***** FIN DE CODIGO NUEVO FSWBMX *****
                        //09.11.2001 EISSA Fin de código anterior
                        //EISSA 09.11.2001 Inicio de Código nuevo para envío de los parámetros hacia los SP's, para enviar sólo el correspondiente al mes
                        CORVAR.pszgblSql2 = "exec reporte_anal_compras " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + Conversion.Str(lEmpNum);
                        //EIISA 09.11.2001 Fin de Código Nuevo
                        if (CORPROC2.Obtiene_Datos() != 0)
                        {
                            if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                            {
                                dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                        }
                        //Realiza fin de Query
                        igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                        //Obtiene los Campos
                        //***** INICIO CODIGO ANTERIOR FSWBMX *****
                        //pszgblSql2 = "exec reporte_anal_disposiciones " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpNum)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****

                        //09.11.2001 EISSA Código Anterior
                        //      '***** INICIO CODIGO NUEVO FSWBMX *****
                        //      pszgblSql2 = "exec reporte_anal_disposiciones " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpNum)
                        //      '***** FIN DE CODIGO NUEVO FSWBMX *****
                        //09.11.2001 EISSA Fin de código anterior
                        //EISSA 09.11.2001 Inicio de Código nuevo para envío de los parámetros hacia los SP's, para enviar sólo el correspondiente al mes
                        CORVAR.pszgblSql2 = "exec reporte_anal_disposiciones " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + Conversion.Str(lEmpNum);
                        //EIISA 09.11.2001 Fin de Código Nuevo

                        if (CORPROC2.Obtiene_Datos() != 0)
                        {
                            if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                            {
                                dDispEfec = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                        }
                        //Realiza fin de Query
                        igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                        dSaldoNuevo = dSaldoAnterior + dCompras + dDispEfec + dComisiones + dIntereses + dIva - dPagosAbonos;

                        dTotSaldoAnt += dSaldoAnterior;
                        dTotCompras += dCompras;
                        dTotDispEfec += dDispEfec;
                        dTotPagos += dPagosAbonos;
                        dTotComisiones += dComisiones;
                        dTotIntereses += dIntereses;
                        dTotIva += dIva;
                        dTotSaldoNuevo += dSaldoNuevo;
                    };
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    //AIS-1182 NGONZALEZ
                    //CORVAR.igblErr = API.USER.PostMessage(CORRPDAT.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    flag = true;
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            else
            {
                //Obtiene los Campos de la tabla de Ejecutivos Banamex
                //ros    igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //pszgblsql = "reporte_eje_empresa " + Str(lgblNumEmpresaR) + "," + Str(igblBanco) + "," + Str(igblMesCorte)
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //09.11.2001 EISSA Inicio de Código Anterior
                //    '***** INICIO CODIGO NUEVO FSWBMX *****
                //    pszgblsql = "reporte_eje_empresa " & Str(lgblNumEmpresaR) & "," & Str(igblPref) & "," & Str(igblBanco) & "," & igblMesCorte
                //    '***** FIN DE CODIGO NUEVO FSWBMX *****
                //09.11.2001 Fin de código Anterior
                //EISSA 09.11.2001 Código Nuevo Cambio de parámetro de periodo de los SP's
                CORVAR.pszgblsql = "reporte_eje_empresa " + Conversion.Str(CORVAR.lgblNumEmpresaR) + "," + Conversion.Str(CORVAR.igblPref) + "," + Conversion.Str(CORVAR.igblBanco) + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString();
                //EISSA 09.11.2001 Fin de Código Nuevo

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        dSaldoAnterior = CORVB.NULL_INTEGER;
                        dCompras = CORVB.NULL_INTEGER;
                        dDispEfec = CORVB.NULL_INTEGER;
                        dPagosAbonos = CORVB.NULL_INTEGER;
                        dComisiones = CORVB.NULL_INTEGER;
                        dIntereses = CORVB.NULL_INTEGER;
                        dIva = CORVB.NULL_INTEGER;
                        dSaldoNuevo = CORVB.NULL_INTEGER;

                        iEjePrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        iGpoBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                        lEmpNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                        iEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
                        iEjeRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
                        iEjeDigit = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
                        dSaldoAnterior = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10));
                        dPagosAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11));
                        dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12));
                        dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 13));
                        dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                        dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;

                        //Calcula cuenta con formato
                        //***** Código Anterior     ***********
                        //        pszTempCuenta = Format(iEjePrefijo, "0000") + Format(iGpoBanco, "00") + Format(lEmpNum, "00000") + Format(iEjeNum, "000") + Format(iEjeRollOver, "0") + Format(iEjeDigit, "0")
                        //***** Fin Código Anterior ***********
                        //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
                        pszTempCuenta = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iGpoBanco, "00") + StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(iEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iEjeRollOver, "0") + StringsHelper.Format(iEjeDigit, "0");
                        //EISSA 05.10.2001 FIN

                        pszCuenta = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 9, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 13, 4);

                        //Incrementa el contador de los registros
                        //iRegistro = iRegistro + 1

                        //***** INICIO CODIGO ANTERIOR FSWBMX *****
                        //pszgblSql2 = "exec reporte_eje_compras " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpNum) + "," + Str(iEjeNum)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                        //09.11.2001 Inicio Comentado por EISSA
                        //***** INICIO CODIGO NUEVO FSWBMX *****
                        //        pszgblSql2 = "exec reporte_eje_compras " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpNum) + "," + Str(iEjeNum)
                        //***** FIN DE CODIGO NUEVO FSWBMX *****
                        //09.11.2001 Inicio Comentado por EISSA
                        //EISSA 09.11.2001 Inicio Código nuevo para fecha de periodo de corte variable
                        CORVAR.pszgblSql2 = "exec reporte_eje_compras " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + Conversion.Str(lEmpNum) + "," + Conversion.Str(iEjeNum);
                        //EISSA 09.11.2001 Fin de Código Nuevo


                        if (CORPROC2.Consulta_Registros() != 0)
                        {
                            if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                            {
                                dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                        }
                        //Realiza fin de Query
                        igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                        //Obtiene los Campos
                        //***** INICIO CODIGO ANTERIOR FSWBMX *****
                        //pszgblSql2 = "exec reporte_eje_disp " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpNum) + "," + Str(iEjeNum)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                        //09.11.2001 Código anterior comentado por EISSA
                        //        '***** INICIO CODIGO NUEVO FSWBMX *****
                        //        pszgblSql2 = "exec reporte_eje_disp " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpNum) + "," + Str(iEjeNum)
                        //        '***** FIN DE CODIGO NUEVO FSWBMX *****
                        //09.11.2001 Fin de Código anterior comentado por EISSA
                        //EISSA 09.11.2001 Inicio Código nuevo para fecha de periodo de corte variable
                        CORVAR.pszgblSql2 = "exec reporte_eje_disp " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + Conversion.Str(lEmpNum) + "," + Conversion.Str(iEjeNum);
                        //EISSA 09.11.2001 Fin de Código nuevo
                        if (CORPROC2.Consulta_Registros() != 0)
                        {
                            if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                            {
                                dDispEfec = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                        }
                        //Realiza fin de Query
                        igblRetorna2 = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                        //Calcula el nuevo saldo
                        dSaldoNuevo = dSaldoAnterior + dCompras + dDispEfec + dComisiones + dIntereses + dIva - dPagosAbonos;
                        dTotSaldoAnt += dSaldoAnterior;
                        dTotCompras += dCompras;
                        dTotDispEfec += dDispEfec;
                        dTotPagos += dPagosAbonos;
                        dTotComisiones += dComisiones;
                        dTotIntereses += dIntereses;
                        dTotIva += dIva;
                        dTotSaldoNuevo += dSaldoNuevo;
                    };
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            ID_DAT_RES_TXT[0].Text = StringsHelper.Format(dTotSaldoAnt, "$##,###,##0.00;($##,###,##0.00)");
            ID_DAT_RES_TXT[1].Text = StringsHelper.Format(dTotCompras, "$##,###,##0.00;($##,###,##0.00)");
            ID_DAT_RES_TXT[2].Text = StringsHelper.Format(dTotDispEfec, "$##,###,##0.00;($##,###,##0.00)");
            ID_DAT_RES_TXT[3].Text = StringsHelper.Format(dTotPagos, "$##,###,##0.00;($##,###,##0.00)");
            ID_DAT_RES_TXT[4].Text = StringsHelper.Format(dTotComisiones, "$##,###,##0.00;($##,###,##0.00)");
            ID_DAT_RES_TXT[5].Text = StringsHelper.Format(dTotIntereses, "$##,###,##0.00;($##,###,##0.00)");
            ID_DAT_RES_TXT[6].Text = StringsHelper.Format(dTotIva, "$##,###,##0.00;($##,###,##0.00)");
            ID_DAT_RES_TXT[7].Text = StringsHelper.Format(dTotSaldoNuevo, "$##,###,##0.00;($##,###,##0.00)");

        }

        private void Llena_Detalle()
        {
            //EISSA 05.10.2001   Auxiliar para obtener Número de Ejecutivo

            this.Cursor = Cursors.WaitCursor;

            ID_CEJ_REP_SS.Row = ID_CEJ_REP_SS.MaxRows;

            //Cuenta del Ejecutivo
            ID_CEJ_REP_SS.Col = 1;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            //***** Código Anterior     ***********
            //  ID_CEJ_REP_SS.Text = Format$(Mid$(Trim$(pszCuenta), 14, 1) + Mid$(Trim$(pszCuenta), 16, 2), "000")
            //***** Fin Código Anterior ***********
            //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
            string slCuenta = Strings.Mid(pszCuenta, 1, 4) + Strings.Mid(pszCuenta, 6, 4) + Strings.Mid(pszCuenta, 11, 4) + Strings.Mid(pszCuenta, 16, 4);
            ID_CEJ_REP_SS.Text = StringsHelper.Format(Strings.Mid(slCuenta, 7 + Formato.sMascara(Formato.iTipo.Empresa).Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length), Formato.sMascara(Formato.iTipo.Ejecutivo));
            //EISSA 05.10.2001 FIN

            //Nombre del Ejecutivo
            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.Text = szNomGraEje.Value.Trim();

            //# de Nomina
            ID_CEJ_REP_SS.Col = 3;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(lEjeNumNom, "0000000");

            //Centro de Costos
            ID_CEJ_REP_SS.Col = 4;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CEJ_REP_SS.Text = szCentroCostos.Value.Trim();

            //Meses de Atraso
            ID_CEJ_REP_SS.Col = 5;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(iNumMesesVenc, "#0");

            //Saldo Anterior
            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dSaldoAnterior, "##,###,###,##0.00");
            dTotSaldoAnt += dSaldoAnterior;

            //Consumos
            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dCompras, "##,###,###,##0.00");
            dTotCompras += dCompras;

            //Disposición de Efectivo
            ID_CEJ_REP_SS.Col = 8;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dDispEfec, "##,###,###,##0.00");
            dTotDispEfec += dDispEfec;

            //Pagos y Abonos
            ID_CEJ_REP_SS.Col = 9;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dPagosAbonos, "##,###,###,##0.00");
            dTotPagos += dPagosAbonos;

            //Comisiones
            ID_CEJ_REP_SS.Col = 10;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dComisiones, "##,###,###,##0.00");
            dTotComisiones += dComisiones;

            //Intereses
            ID_CEJ_REP_SS.Col = 11;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dIntereses, "##,###,###,##0.00");
            dTotIntereses += dIntereses;

            //IVA
            ID_CEJ_REP_SS.Col = 12;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dIva, "##,###,###,##0.00");
            dTotIva += dIva;

            //Saldo Nuevo
            ID_CEJ_REP_SS.Col = 13;
            ID_CEJ_REP_SS.CellType = CorpdatCell;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dSaldoNuevo, "##,###,###,##0.00");
            dSaldoNuevo += dSaldoNuevo;

            ID_CEJ_REP_SS.MaxRows++;

        }

        //UPGRADE_NOTE: (7001) The following declaration (Obten_Nombre_Eje) seems to be dead code
        //private void  Obten_Nombre_Eje(ref  string szNombre)
        //{
        //
        //int hEjeEmp4 = 0;
        //int iValor = 0;
        //int iError = 0;
        //
        //string pszTempNombre = String.Empty;
        //string pszTempCad1 = String.Empty;
        //string pszTempCad2 = String.Empty;
        //string pszTempCad3 = String.Empty;
        //
        //int iPosicion1 = 0;
        //int iPosicion2 = 0;
        //int iLongitud = 0;
        //
        //CORVAR.pszgblsql = "select ths_nombre from MTCTHS01 where eje_prefijo= " + iEjePrefijo.ToString() + " and gpo_banco= " + iGpoBanco.ToString() + " and emp_num = " + Conversion.Str(CORVAR.lgblNumEmpresaR) + " and eje_num = " + Conversion.Str(lEjeNum);
        //hEjeEmp4 = qeExecSQL(hConexion, "select ths_nombre from MTCTHS01 where gpo_banco =" + Format$(igblBanco) + " and emp_num= " + Str(iEmpNum) + " and eje_num=" + Str(iEjeNum))
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
        //{
        //pszTempNombre = VBSQL.SqlData(CORVAR.hgblConexion, 1);
        //iPosicion1 = (pszTempNombre.IndexOf(',') + 1);
        //iPosicion2 = (pszTempNombre.IndexOf('/') + 1);
        //if (iPosicion1 == 0 || iPosicion2 == 0)
        //{
        //szNombre = "";
        //} else
        //{
        //pszTempCad1 = pszTempNombre.Substring(0, Math.Min(pszTempNombre.Length, iPosicion1 - 1));
        //pszTempCad2 = Strings.Mid(pszTempNombre, iPosicion1 + 1, (iPosicion2 - iPosicion1) - 1);
        //pszTempCad3 = Strings.Mid(pszTempNombre, iPosicion2 + 1, CORBD.LNG_THS_NOM);
        //szNombre = pszTempCad1.Trim() + " " + pszTempCad2.Trim() + " " + pszTempCad3.Trim();
        //}
        //}
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //}
        //Realiza fin de Query
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //
        //}

        //UPGRADE_NOTE: (7001) The following declaration (Resumen_Giro) seems to be dead code
        //private void  Resumen_Giro()
        //{
        //int hBufANG = 0; //El apuntador a la sentencia SQL
        //int iTempErr = 0; //Control local
        //string pszSentencia = String.Empty;
        //
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //pszgblsql = " exec reporte_anal_saldos " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = " exec reporte_anal_saldos " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesDiaACG).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
        //{
        //dSaldoAnt = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
        //dPagosyAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));
        //dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3));
        //dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
        //dIva = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
        //}
        //
        //igblRetorna = SqlCancel(hgblConexion)                'Terminamos el SQL
        //CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
        //
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //pszgblsql = "exec reporte_anal_compras " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = "exec reporte_anal_compras " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesDiaACG).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
        //{
        //dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
        //}
        //igblRetorna = SqlCancel(hgblConexion)                 'Terminamos el SQL
        //CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //pszgblsql = "exec reporte_anal_disposiciones " + Format$(igblBanco) + "," + Format$(igblMesDiaACG) + "," + Format$(lgblNumEmpresaR)
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = "exec reporte_anal_disposiciones " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesDiaACG).ToString() + "," + CORVAR.lgblNumEmpresaR.ToString();
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
        //{
        //dDisposiciones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Terminamos el SQL
        //} else
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //return; //Salimos de la función
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //} else
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //return; //Salimos de la función
        //}
        //
        //} else
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //return; //Salimos de la función
        //}
        //CORPROC2.Libera_Memoria(CORVAR.hgblConexion);
        //}
    }
}