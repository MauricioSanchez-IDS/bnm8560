using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Drawing;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORRPCGR
        : System.Windows.Forms.Form
    {

        //'**********************************************************
        //*
        //*    Descripción : Módulo de Reporte de Concetrado
        //*                  por empresas de un grupo.
        //*
        //*    Fecha de Inicio : 2/05/94
        //*
        //*    Responsable: Abraham Ramírez Basurto
        //*
        //**********************************************************

        int iGpoBanco = 0;
        int lEmpresas = 0;
        FixedLengthString szEmpDesc = new FixedLengthString(CORBD.LNG_EMP_NOM);
        int iNumTarjetas = 0;
        int iNumTarAtr = 0;
        double dSaldoAnterior = 0;
        double dPagosAbonos = 0;
        double dComisiones = 0;
        double dIntereses = 0;
        double dCompras = 0;
        double dDispEfec = 0;
        double dIva = 0;
        double dSaldoNuevo = 0;
        //Variable que guarda el número de renglones
        int iMaxRenglon = 0;
        //Variables para totales
        double dTotSaldoAnt = 0;
        double dTotPagos = 0;
        double dTotComisiones = 0;
        double dTotIntereses = 0;
        double dTotCompras = 0;
        double dTotDispEfec = 0;
        double dTotIva = 0;
        double dTotSaldoNuevo = 0;
        int lTotTarjetas = 0;
        int lTotTarAtr = 0;
        int iCred = 0;
        double dTotCredAsig = 0;

        int lRetorna = 0;
        int hConexion = 0;


        int intCont = 0;


        private void Calcula_totales(int iMaxRenglones)
        {


            //Asigna el máximo de renglones
            ID_CGR_REP_SS.MaxRows = iMaxRenglones;
            ID_CGR_REP_SS.Row = iMaxRenglones;

            //Formatea ultimo renglon
            for (int iCont = 1; iCont <= 14; iCont++)
            {
                ID_CGR_REP_SS.Col = iCont;
                ID_CGR_REP_SS.BackColor = Color.Silver;
            }

            //Totales
            ID_CGR_REP_SS.Col = 2;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            ID_CGR_REP_SS.Text = "Total";

            //Tarjetas
            ID_CGR_REP_SS.Col = 3;
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CGR_REP_SS.Text = lTotTarjetas.ToString();

            //credito asignado
            ID_CGR_REP_SS.Col = 4;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotCredAsig, "##,###,###,##0.00");


            //Tarjetas ATRASADAS
            ID_CGR_REP_SS.Col = 5;
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CGR_REP_SS.Text = lTotTarAtr.ToString();

            //Saldo Anterior
            ID_CGR_REP_SS.Col = 6;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotSaldoAnt, "##,###,###,##0.00");

            //Consumos
            ID_CGR_REP_SS.Col = 7;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotCompras, "##,###,###,##0.00");

            //Disposición de Efectivo
            ID_CGR_REP_SS.Col = 8;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotDispEfec, "##,###,###,##0.00");

            //Pagos y Abonos
            ID_CGR_REP_SS.Col = 9;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotPagos, "##,###,###,##0.00");

            //Comisiones
            ID_CGR_REP_SS.Col = 10;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotComisiones, "##,###,###,##0.00");

            //Intereses
            ID_CGR_REP_SS.Col = 11;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotIntereses, "##,###,###,##0.00");

            //IVA
            ID_CGR_REP_SS.Col = 12;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotIva, "##,###,###,##0.00");

            //Saldo Nuevo
            ID_CGR_REP_SS.Col = 12;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dTotSaldoNuevo, "##,###,###,##0.00");

        }

        private void Carga_Encabezado()
        {

            int iCorNum = 0;
            int hEjeEmp = 0;
            int iError = 0;
            string pszEmpNombre = String.Empty;
            int iValor = 0;
            string pszGrupoCalle = String.Empty;
            string pszGrupoCol = String.Empty;
            string pszGrupoPob = String.Empty;
            string pszGrupoEdo = String.Empty;
            int lGrupoCP = 0;
            int lCredTot = 0;
            int lCredAcum = 0;
            string pszFecCred = String.Empty;


            this.Cursor = Cursors.WaitCursor;
            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "select gpo_nom, gpo_calle, gpo_col, gpo_pob, gpo_edo, gpo_cp, gpo_cred_tot, gpo_acum_cred,convert(varchar(10),gpo_fec_venc_cred,103) from " + DB_SYB_COR + " where gpo_num = " + Format$(lgblGpoCve) + " and gpo_banco = " + Str(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_nom, gpo_calle, gpo_col, gpo_pob, gpo_edo, gpo_cp, gpo_cred_tot, gpo_acum_cred,convert(varchar(10),gpo_fec_venc_cred,103) from " + CORBD.DB_SYB_COR + " where gpo_num = " + CORVAR.lgblGpoCve.ToString() + " and eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                //Obtiene datos
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    pszEmpNombre = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    pszGrupoCalle = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    pszGrupoCol = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    pszGrupoPob = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                    pszGrupoEdo = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                    lGrupoCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
                    lCredTot = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7)));
                    lCredAcum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8)));
                    pszFecCred = VBSQL.SqlData(CORVAR.hgblConexion, 9);

                    ID_CGR_EMP_LBL.Text = pszEmpNombre;

                    //      If lgblGpoCve > NULL_INTEGER Then
                    ID_CGR_DI1_LBL.Text = pszGrupoCalle;
                    ID_CGR_DI2_LBL.Text = "COL. " + pszGrupoCol.Trim();
                    ID_CGR_DI3_LBL.Text = pszGrupoPob.Trim() + ", " + pszGrupoEdo.Trim();
                    ID_CGR_CP_LBL.Text = "C.P. " + StringsHelper.Format(lGrupoCP, "00000");
                    ID_CGR_CRE_TOT_LBL.Text = StringsHelper.Format(lCredTot, "$##,###,###,##0.00");
                    //        ID_CGR_CRE_ACU_LBL.Caption = Format$(lCredAcum, "$##,###,###,##0.00")
                    ID_CGR_CRE_ACU_LBL.Text = StringsHelper.Format(dTotCredAsig, "$##,###,###,##0.00");
                    ID_CGR_FEC_CRED_LBL.Text = pszFecCred;
                    //      End If
                }
            }
            //Realiza fin de Query
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

        }

        private void Carga_Reporte()
        {
            int iError = 0;
            int hEmpGpo1 = 0;
            int hEmpGpo2 = 0;
            int hEmpGpo3 = 0;
            int hEmpGpo4 = 0;
            int iValor = 0;
            int iRegistro = 0;
            string pszTempCuenta = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            lTotTarAtr = CORVB.NULL_INTEGER;
            lTotTarjetas = CORVB.NULL_INTEGER;
            dTotSaldoAnt = CORVB.NULL_INTEGER;
            dTotCompras = CORVB.NULL_INTEGER;
            dTotDispEfec = CORVB.NULL_INTEGER;
            dTotPagos = CORVB.NULL_INTEGER;
            dTotComisiones = CORVB.NULL_INTEGER;
            dTotIntereses = CORVB.NULL_INTEGER;
            dTotIva = CORVB.NULL_INTEGER;
            dTotSaldoNuevo = CORVB.NULL_INTEGER;
            dTotCredAsig = CORVB.NULL_INTEGER;


            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "reporte_empresa " + Str(lgblGpoCve) + "," + Str(igblBanco) + "," + Str(igblMesCorte)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //08.11.2001 Código Anterior Comentado por EISSA
            //    'Concentrado por Grupo
            //    pszgblsql = "reporte_empresa " + Str(lgblGpoCve) + "," + Str(igblPref) + "," + Str(igblBanco) + "," + Str(igblMesCorte)
            //  '***** FIN DE CODIGO NUEVO FSWBMX *****
            //08.11.2001 Fin de Código Anterior
            //EISSA 08.11.2001 Código modificado, para enviar como parámetro el mes y no el cicloMesDía
            CORVAR.pszgblsql = "reporte_empresa " + Conversion.Str(CORVAR.lgblGpoCve) + "," + Conversion.Str(CORVAR.igblPref) + "," + Conversion.Str(CORVAR.igblBanco) + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString();
            //EISSA 08.11.2001 Fin de Código Nuevo


            if (CORPROC2.Obtiene_Registros() != 0)
            {
                //Permite obtener registros

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumTarAtr = CORVB.NULL_INTEGER;
                    iNumTarjetas = CORVB.NULL_INTEGER;
                    dSaldoAnterior = CORVB.NULL_INTEGER;
                    dCompras = CORVB.NULL_INTEGER;
                    dDispEfec = CORVB.NULL_INTEGER;
                    dPagosAbonos = CORVB.NULL_INTEGER;
                    dComisiones = CORVB.NULL_INTEGER;
                    dIntereses = CORVB.NULL_INTEGER;
                    dIva = CORVB.NULL_INTEGER;
                    dSaldoNuevo = CORVB.NULL_INTEGER;
                    iCred = CORVB.NULL_INTEGER;

                    lEmpresas = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));

                    szEmpDesc.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    iCred = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                    dSaldoAnterior = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
                    dPagosAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
                    dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6));
                    dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7));
                    dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                    dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;

                    //Incrementa el contador de los registros
                    iRegistro++;

                    //Obtiene los Campos de la tabla de Ejecutivos Banamex
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //pszgblSql2 = "exec reporte_gpo_empresas " + Format$(igblBanco) + "," + Format(lEmpresas)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    CORVAR.pszgblSql2 = "exec reporte_gpo_empresas " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + lEmpresas.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX *****
                    if (CORPROC2.Consulta_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                        {
                            iNumTarjetas = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
                        }
                    }
                    //Realiza fin de Query
                    lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                    //Obtiene los ejecutivo atrasados
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //pszgblSql2 = "exec reporte_gpo_atrasos " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpresas)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //08.11.2001   EISSA Código Anterior
                    //        '***** INICIO CODIGO NUEVO FSWBMX *****
                    //        pszgblSql2 = "exec reporte_gpo_atrasos " + Format$(igblPref) + "," + Format$(igblBanco) + "," & Str(igblMesCorte) & "," + Str(lEmpresas)
                    //        '***** FIN DE CODIGO NUEVO FSWBMX *****
                    //08.11.2001   EISSA Fin de Código Anterior
                    //EISSA 08.11.2001   Código Nuevo, para enviar sólo el mes al SP
                    CORVAR.pszgblSql2 = "exec reporte_gpo_atrasos " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + Conversion.Str(lEmpresas);
                    //EISSA 15.10.2001   Fin de Código Nuevo
                    if (CORPROC2.Consulta_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                        {
                            iNumTarAtr = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1)));
                        }
                    }
                    //Realiza fin de Query
                    lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                    //Obtiene los Campos de la tabla de Ejecutivos Banamex
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //pszgblSql2 = "exec reporte_gpo_compras " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpresas)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //08.11.2001   EISSA Código Anterior
                    //        '***** INICIO CODIGO NUEVO FSWBMX *****
                    //        pszgblSql2 = "exec reporte_gpo_compras " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpresas)
                    //        '***** FIN DE CODIGO NUEVO FSWBMX *****
                    //08.11.2001   EISSA Fin de Código Anterior
                    //EISSA 08.11.2001   Código Nuevo, para enviar el parámetro de fecha personalizado por empresa
                    CORVAR.pszgblSql2 = "exec reporte_gpo_compras " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + Conversion.Str(lEmpresas);
                    //EISSA 08.11.2001   Fin de Código Nuevo

                    if (CORPROC2.Consulta_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                        {
                            dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                        }
                    }
                    //Realiza fin de Query
                    lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                    //Obtiene los Campos
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //pszgblSql2 = "exec reporte_gpo_disposiciones " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpresas)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //08.11.2001   EISSA Código Anterior
                    //        '***** INICIO CODIGO NUEVO FSWBMX *****
                    //        pszgblSql2 = "exec reporte_gpo_disposiciones " + Format$(igblPref) + "," + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpresas)
                    //        '***** FIN DE CODIGO NUEVO FSWBMX *****
                    //08.11.2001   EISSA Fin de Código Anterior
                    //EISSA 08.11.2001   Código Nuevo, para enviar el parámetro del mes al SP
                    CORVAR.pszgblSql2 = "exec reporte_gpo_disposiciones " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Formato.ifncMes(CORVAR.igblMesCorte).ToString() + "," + Conversion.Str(lEmpresas);
                    //EISSA 08.11.2001   Fin de Código Nuevo
                    if (CORPROC2.Consulta_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                        {
                            dDispEfec = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
                        }
                    }
                    //Realiza fin de Query
                    lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);

                    //Calcula el nuevo saldo
                    dSaldoNuevo = Math.Truncate(dSaldoAnterior) + dCompras + dDispEfec + dComisiones + dIntereses + dIva - dPagosAbonos;
                    dTotSaldoNuevo += Math.Truncate(dSaldoNuevo);
                    //Llena spread de detalle de ejecutivos
                    Llena_Detalle(iRegistro);
                    Application.DoEvents();
                    this.Cursor = Cursors.WaitCursor;
                    this.Parent.Cursor = Cursors.WaitCursor;
                };
                this.Parent.Cursor = Cursors.Default;
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                iMaxRenglon = iRegistro + 2;
                Calcula_totales(iMaxRenglon);
                Carga_Encabezado();
                Llena_Concentrado();
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                //AIS-1182 NGONZALEZ
                flag = true;
                //iError = API.USER.PostMessage(CORRPCGR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                this.Cursor = Cursors.Default;
            }
            //Realiza fin de Query
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

        }

        private void CORRPCGR_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                CORVAR.igblFormaActiva = CORCONST.INT_ACT_CGR;
                CORPROC.Cambia_StatusOpciones(-1);

            }
        }

        //UPGRADE_WARNING: (2065) Form event CORRPCGR.Deactivate has a new behavior.
        private void CORRPCGR_Deactivate(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            CORPROC.Cambia_StatusOpciones(0);

        }



        private void CORRPCGR_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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
            //AIS-1624 FSABORIO
            this.Left = (CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2;
            this.Top = (CORMDIBN.DefInstance.ClientRectangle.Height -
                CORMDIBN.DefInstance.ID_COR_BHER.Height -
                CORMDIBN.DefInstance.ID_COR_BEDO.Height - this.Height) / 2;

            this.Cursor = Cursors.WaitCursor;

            hConexion = CORVB.NULL_INTEGER;

            intCont = CORDBLIB.Segunda_ConexionServidor();

            if (intCont != 0)
            {
                Carga_Reporte();
                Formatea_Spread();
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORRPCGR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

        }

        private void CORRPCGR_Closed(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            CORPROC.Cambia_StatusOpciones(0);

            VBSQL.SqlClose(CORVAR.hgblConexion2);
            hConexion = CORVB.NULL_INTEGER;


            VBSQL.subCanConRec(ref intCont);

            //  If GColRec.Item(CLng(intCont)).State > 0 Then
            //      GColRec.Item(CLng(intCont)).Close
            //  Else
            //      GColRec.Remove intCont
            //  End If
            //  gConn(intCont).Close

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Formatea_Spread()
        {

            int iCont = 0;

            ID_CGR_REP_SS.Col = 1;
            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 8 * 10);
            ID_CGR_REP_SS.Text = "  No.  ";

            ID_CGR_REP_SS.Col = 2;
            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 25 * 8);
            ID_CGR_REP_SS.Text = "Empresa";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 3;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 7 * 10);
            ID_CGR_REP_SS.Text = "# Tarjs.";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 4;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 10);
            ID_CGR_REP_SS.Text = "Crédito";


            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 5;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 7 * 8);
            ID_CGR_REP_SS.Text = "# Atras.";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 6;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 8);
            ID_CGR_REP_SS.Text = "Saldo Anterior";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 7;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 8);
            ID_CGR_REP_SS.Text = "Consumos";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 8;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 8);
            ID_CGR_REP_SS.Text = "Disp. Efvo.";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 9;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 8);
            ID_CGR_REP_SS.Text = "Pagos";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 10;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 8);
            ID_CGR_REP_SS.Text = "Comisiones";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 11;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 8);
            ID_CGR_REP_SS.Text = "Gtos. Cobr.";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 12;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 8);
            ID_CGR_REP_SS.Text = "I.V.A.";

            ID_CGR_REP_SS.Row = 0;
            ID_CGR_REP_SS.Col = 12;
            ID_CGR_REP_SS.set_ColWidth(ID_CGR_REP_SS.Col, 12 * 8);
            ID_CGR_REP_SS.Text = "Saldo Nuevo";

        }

        private void ID_CGR_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                CORPROC.Imprime_Reporte();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CGR_IMP_PB_Click)", e);
            }
        }

        private void ID_CGR_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void Llena_Concentrado()
        {

            ID_CGR_RES_TXT[0].Text = StringsHelper.Format(dTotSaldoAnt, "$##,###,###,##0.00");
            ID_CGR_RES_TXT[1].Text = StringsHelper.Format(dTotCompras, "$##,###,###,##0.00");
            ID_CGR_RES_TXT[2].Text = StringsHelper.Format(dTotDispEfec, "$##,###,###,##0.00");
            ID_CGR_RES_TXT[3].Text = StringsHelper.Format(dTotPagos, "$##,###,###,##0.00");
            ID_CGR_RES_TXT[4].Text = StringsHelper.Format(dTotComisiones, "$##,###,###,##0.00");
            ID_CGR_RES_TXT[5].Text = StringsHelper.Format(dTotIntereses, "$##,###,###,##0.00");
            ID_CGR_RES_TXT[6].Text = StringsHelper.Format(dTotIva, "$##,###,###,##0.00");
            ID_CGR_RES_TXT[7].Text = StringsHelper.Format(dTotSaldoNuevo, "$##,###,###,##0.00");

        }

        private void Llena_Detalle(int iRenglon)
        {

            object iCont = null;
            object iSaldoAnterior = null;
            object iConsumos = null;
            object iDispEfvo = null;
            object iPagos = null;
            object iComisiones = null;
            object iIntMorat = null;
            object iIva = null;
            object iSaldoNvo = null;

            //Variables para formateo 02-10-2001 HVV
            int long_Emp = 0;
            int long_eje = 0;
            string num_empresa = String.Empty;
            string num_ejecutivo = String.Empty;
            string paso = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            ID_CGR_REP_SS.MaxRows = iRenglon;
            ID_CGR_REP_SS.Row = iRenglon;

            //Datos de la Primera Columna
            ID_CGR_REP_SS.Col = 1;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            //***** Inicio Código Anterior para Formateo de Empresa y Ejecutivo
            //ID_CGR_REP_SS.Text = Space(1) + Format(lEmpresas, "00000") 'Cuenta del Ejecutivo
            //****** Fin de Código Anterior para Formateo de Empresa y Ejecutivo

            //EISSA Inicio Código Nuevo para Formateo de Empresa y Ejecutivo
            ID_CGR_REP_SS.Text = new String(' ', 1) + StringsHelper.Format(lEmpresas, Formato.sMascara(Formato.iTipo.Empresa)); //Cuenta del Ejecutivo
            //EISSA Fin de Código Nuevo para Formateo de Empresa y Ejecutivo


            //Nombre de la Empresa
            ID_CGR_REP_SS.Col = 2;
            ID_CGR_REP_SS.Text = new String(' ', 1) + szEmpDesc.Value.Trim();

            //# de Tarjetas
            ID_CGR_REP_SS.Col = 3;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CGR_REP_SS.Text = iNumTarjetas.ToString();
            lTotTarjetas += iNumTarjetas;

            //Credito Asignado
            ID_CGR_REP_SS.Col = 4;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(iCred, "##,###,###,##0.00");
            dTotCredAsig += iCred;

            //numero de tarj atrasadas
            ID_CGR_REP_SS.Col = 5;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CGR_REP_SS.Text = iNumTarAtr.ToString();
            lTotTarAtr += iNumTarAtr;


            //Saldo Anterior
            ID_CGR_REP_SS.Col = 6;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(Math.Truncate(dSaldoAnterior), "##,###,###,##0.00");
            dTotSaldoAnt += Math.Truncate(dSaldoAnterior);

            //Consumos
            ID_CGR_REP_SS.Col = 7;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dCompras, "##,###,###,##0.00");
            dTotCompras += dCompras;

            //Disposición de Efectivo
            ID_CGR_REP_SS.Col = 8;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dDispEfec, "##,###,###,##0.00");
            dTotDispEfec += dDispEfec;

            //Pagos y Abonos
            ID_CGR_REP_SS.Col = 9;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dPagosAbonos, "##,###,###,##0.00");
            dTotPagos += dPagosAbonos;

            //Comisiones
            ID_CGR_REP_SS.Col = 10;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dComisiones, "##,###,###,##0.00");
            dTotComisiones += dComisiones;

            //Intereses
            ID_CGR_REP_SS.Col = 11;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dIntereses, "##,###,###,##0.00");
            dTotIntereses += dIntereses;

            //IVA 
            ID_CGR_REP_SS.Col = 12;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(dIva, "##,###,###,##0.00");
            dTotIva += dIva;

            //Saldo Nuevo
            ID_CGR_REP_SS.Col = 12;
            ID_CGR_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CGR_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CGR_REP_SS.TypeFloatSeparator = true;
            ID_CGR_REP_SS.Text = StringsHelper.Format(Math.Truncate(dSaldoNuevo), "##,###,###,##0.00");
            dSaldoNuevo += Math.Truncate(dSaldoNuevo);

        }

        //UPGRADE_NOTE: (7001) The following declaration (Llena_Reporte) seems to be dead code
        //private void  Llena_Reporte()
        //{
        //
        //string iSaldoAnterior = String.Empty;
        //string iConsumos = String.Empty;
        //string iDispEfvo = String.Empty;
        //string iPagos = String.Empty;
        //string iComisiones = String.Empty;
        //string iIntMorat = String.Empty;
        //string iIva = String.Empty;
        //string iSaldoNvo = String.Empty;
        //
        //this.Cursor = Cursors.WaitCursor;
        //
        //Formatea ultimo renglon
        //ID_CGR_REP_SS.Row = 5;
        //for (double iCont = 1; iCont <= 13; iCont++)
        //{
        //ID_CGR_REP_SS.Col = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.BackColor = Color.Silver;
        //}
        //
        //Datos de la Primera Columna
        //ID_CGR_REP_SS.Col = 1;
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.set_ColWidth(1, 7);
        //ID_CGR_REP_SS.Text = "No. Cia.";
        //ID_CGR_REP_SS.Col = 1;
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 1;
        //ID_CGR_REP_SS.Text = "00" + Conversion.Str(iCont).Trim();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.Text = "Total";
        //
        //ID_CGR_REP_SS.Col = 2;
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.set_ColWidth(2, 15);
        //ID_CGR_REP_SS.Text = "Nombre Cia.";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.Text = "Compañía" + Conversion.Str(iCont).Trim();
        //}
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 3;
        //ID_CGR_REP_SS.set_ColWidth(3, 10);
        //ID_CGR_REP_SS.Text = "# Tarjetas";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 1;
        //ID_CGR_REP_SS.Text = (2 + iCont).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 4;
        //ID_CGR_REP_SS.set_ColWidth(4, 10);
        //ID_CGR_REP_SS.Text = "Saldo Anterior";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = (2000 + iCont).ToString();
        //iSaldoAnterior = (StringsHelper.DoubleValue(iSaldoAnterior) + Conversion.Val(ID_CGR_REP_SS.Text)).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = iSaldoAnterior;
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 5;
        //ID_CGR_REP_SS.set_ColWidth(5, 10);
        //ID_CGR_REP_SS.Text = "Consumos";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = (1500 + iCont).ToString();
        //iConsumos = (StringsHelper.DoubleValue(iConsumos) + Conversion.Val(ID_CGR_REP_SS.Text)).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = iConsumos;
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 6;
        //ID_CGR_REP_SS.set_ColWidth(6, 10);
        //ID_CGR_REP_SS.Text = "Disp. Efvo.";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = (3000 + iCont).ToString();
        //iDispEfvo = (StringsHelper.DoubleValue(iDispEfvo) + Conversion.Val(ID_CGR_REP_SS.Text)).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = iDispEfvo;
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 7;
        //ID_CGR_REP_SS.set_ColWidth(7, 10);
        //ID_CGR_REP_SS.Text = "Pagos";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = (1600 + iCont).ToString();
        //iPagos = (StringsHelper.DoubleValue(iPagos) + Conversion.Val(ID_CGR_REP_SS.Text)).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = iPagos;
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 8;
        //ID_CGR_REP_SS.set_ColWidth(8, 10);
        //ID_CGR_REP_SS.Text = "Comisiones";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = (200 + iCont).ToString();
        //iComisiones = (StringsHelper.DoubleValue(iComisiones) + Conversion.Val(ID_CGR_REP_SS.Text)).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = iComisiones;
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 9;
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.set_ColWidth(9, 10);
        //ID_CGR_REP_SS.Text = "Int. Morat.";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = (52 + iCont).ToString();
        //iIntMorat = (StringsHelper.DoubleValue(iIntMorat) + Conversion.Val(ID_CGR_REP_SS.Text)).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = iIntMorat;
        //
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 10;
        //ID_CGR_REP_SS.set_ColWidth(10, 10);
        //ID_CGR_REP_SS.Text = "I.V.A.";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = (250 + iCont).ToString();
        //iIva = (StringsHelper.DoubleValue(iIva) + Conversion.Val(ID_CGR_REP_SS.Text)).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = iIva;
        //
        //
        //ID_CGR_REP_SS.Row = 0;
        //ID_CGR_REP_SS.Col = 11;
        //ID_CGR_REP_SS.set_ColWidth(11, 10);
        //ID_CGR_REP_SS.Text = "Saldo Nuevo";
        //
        //for (double iCont = 1; iCont <= 3; iCont++)
        //{
        //ID_CGR_REP_SS.Row = Convert.ToInt32(iCont);
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = (4500 + iCont).ToString();
        //iSaldoNvo = (StringsHelper.DoubleValue(iSaldoNvo) + Conversion.Val(ID_CGR_REP_SS.Text)).ToString();
        //}
        //
        //ID_CGR_REP_SS.Row = 5;
        //ID_CGR_REP_SS.CellType = (FPSpreadADO.CellTypeConstants) 2;
        //ID_CGR_REP_SS.Text = iSaldoNvo;
        //
        //this.Cursor = Cursors.Default;
        //
        //}
    }
}