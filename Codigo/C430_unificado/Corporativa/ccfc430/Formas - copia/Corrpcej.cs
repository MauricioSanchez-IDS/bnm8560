using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORRPCEJ
        : System.Windows.Forms.Form
    {

        //**********************************************************
        //*
        //*    Descripción : Módulo de Reporte de Concetrado
        //*                  por ejecutivos de empresas.
        //*
        //*    Fecha de Inicio : 2/05/94
        //*
        //*    Responsable: Abraham Ramírez Basurto
        //*
        //**********************************************************

        int iEjePrefijo = 0;
        int iGpoBanco = 0;
        int lEmpresas = 0;
        int iEjeNum = 0;
        int iEjeRollOver = 0;
        int iEjeDigit = 0;
        int iEjeMesesVencidos = 0;

        //*: ****************************************************************************
        //*: Cambio de tipo de la variable para permitir la generación de reporte
        //*: EISSA MRG 2005-03-28
        string sEjeNumNom = String.Empty; //lEjeNumNom As Long
        //*: Fin: Cambio de tipo de la variable para permitir la generación de reporte
        //*: ****************************************************************************

        FixedLengthString szCentroCostos = new FixedLengthString(CORBD.LNG_EJE_CC);
        FixedLengthString szEmpDesc = new FixedLengthString(CORBD.LNG_EMP_NOM);
        string pszCuenta = String.Empty;
        FixedLengthString szEjeNombre = new FixedLengthString(CORBD.LNG_EJE_NOM);
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
        int iTotMesesVencidos = 0;
        double dTotSaldoAnt = 0;
        double dTotPagos = 0;
        double dTotComisiones = 0;
        double dTotIntereses = 0;
        double dTotCompras = 0;
        double dTotDispEfec = 0;
        double dTotIva = 0;
        double dTotSaldoNuevo = 0;
        double dSumSalAcre = 0;
        double dSumSalDeud = 0;
        string pszCuentaBan = String.Empty;
        int iLimCred = 0;
        int dCredAcum = 0;
        double dTotCredAcum = 0;
        string slTipoFacturacion = String.Empty;


        int lRetorna = 0;
        int hConexion = 0;


        private void Calcula_totales(double iMaxRenglones)
        {
            //Asigna el máximo de renglones
            ID_CEJ_REP_SS.MaxRows = Convert.ToInt32(iMaxRenglones);

            //Formatea ultimos renglon
            for (int jCont = Convert.ToInt32(iMaxRenglones - 2); jCont <= Convert.ToInt32(iMaxRenglones); jCont++)
            {
                ID_CEJ_REP_SS.Row = jCont;
                for (int iCont = 1; iCont <= 14; iCont++)
                {
                    ID_CEJ_REP_SS.Col = iCont;
                    ID_CEJ_REP_SS.BackColor = Color.Silver;
                }
            }

            ID_CEJ_REP_SS.Row = Convert.ToInt32(iMaxRenglones - 2);

            //Totales
            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            ID_CEJ_REP_SS.Text = "Total";


            //Saldo Anterior
            ID_CEJ_REP_SS.Col = 4;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            //ID_CEJ_REP_SS.TypeFloatSeparator = True
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dCredAcum, "##,###,###,##0.00");


            //Meses Vencidos
            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(iTotMesesVencidos, "#0");

            //Saldo Anterior
            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotSaldoAnt, "##,###,###,##0.00");


            //Consumos
            ID_CEJ_REP_SS.Col = 8;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotCompras, "##,###,###,##0.00");


            //Disposición de Efectivo
            ID_CEJ_REP_SS.Col = 9;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotDispEfec, "##,###,###,##0.00");


            //Pagos y Abonos
            ID_CEJ_REP_SS.Col = 10;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotPagos, "##,###,###,##0.00");


            //Comisiones
            ID_CEJ_REP_SS.Col = 11;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotComisiones, "##,###,###,##0.00");


            //Intereses
            ID_CEJ_REP_SS.Col = 12;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotIntereses, "##,###,###,##0.00");


            //IVA
            ID_CEJ_REP_SS.Col = 13;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotIva, "##,###,###,##0.00");


            //Saldo Nuevo
            ID_CEJ_REP_SS.Col = 14;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dTotSaldoNuevo, "##,###,###,##0.00");


            //***************************************************************************************************
            // 15/Nov/1995 Se incremento el siguiente código
            // debido al cambio que sufrió para meter el saldo deudor y acreedor en el reporte.
            // Manuel Alderete Lezama
            //***************************************************************************************************

            ID_CEJ_REP_SS.Row = Convert.ToInt32(iMaxRenglones - 1);
            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            //  ID_CEJ_REP_SS.Text = "Total"
            //  ID_CEJ_REP_SS.Col = 2
            // ID_CEJ_REP_SS.TypeHAlign = (FPSpreadADO.TypeHAlignConstants)0
            ID_CEJ_REP_SS.Text = "Total Saldo Deudor";

            ID_CEJ_REP_SS.Col = 14;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dSumSalDeud, "##,###,###,##0.00");


            ID_CEJ_REP_SS.Row = Convert.ToInt32(iMaxRenglones);
            //  ID_CEJ_REP_SS.Col = 2
            //  ID_CEJ_REP_SS.TypeHAlign = (FPSpreadADO.TypeHAlignConstants)2
            //  ID_CEJ_REP_SS.Text = "Total"

            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            ID_CEJ_REP_SS.Text = "Total Saldo Acreedor";

            ID_CEJ_REP_SS.Col = 14;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dSumSalAcre, "##,###,###,##0.00");

        }

        private void Carga_Encabezado()
        {
            int iCorNum = 0;
            int hEjeEmp = 0;
            int iError = 0;
            string pszEmpNombre = String.Empty;
            int iValor = 0;
            string pszFiscalCalle = String.Empty;
            string szFiscalCol = String.Empty;
            string pszFiscalCiudad = String.Empty;
            string pszFiscalEdo = String.Empty;
            int lFiscalCP = 0;
            int lCuenta = 0;
            int lSucursal = 0;
            double dCredito = 0;
            double dCredAcum = 0;
            string pszFecCred = String.Empty;
            string pszTipoPago = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            CORVAR.pszgblsql = "select emp_nom, emp_fiscal_calle, emp_fiscal_col, emp_fiscal_edo, ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_ciu, emp_fiscal_cp,emp_cred_tot,emp_cta_capt,";
            //  pszgblsql = pszgblsql + "emp_tipo_pago,emp_sucur,emp_acum_cred, convert(varchar(10),emp_fec_venc_cred,103) "
            // Modif. 18/Jun/2007 Calc Lim Real
            CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tipo_pago,emp_sucur, ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblEmpCve.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + CORVAR.lgblEmpCve.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) as emp_acum_cred, ";
            //  pszgblsql = pszgblsql + " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred, "

            CORVAR.pszgblsql = CORVAR.pszgblsql + " convert(varchar(10),emp_fec_venc_cred,103) ";

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = pszgblsql + "from " + DB_SYB_EMP + " where emp_num = "
            // pszgblsql = pszgblsql + Format$(lgblEmpCve) + " and gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + "from " + CORBD.DB_SYB_EMP + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num =" + CORVAR.lgblEmpCve.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                //Obtiene datos
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    pszEmpNombre = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    pszFiscalCalle = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    szFiscalCol = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    pszFiscalCiudad = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                    pszFiscalEdo = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                    lFiscalCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
                    dCredito = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7));
                    lCuenta = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8)));
                    pszTipoPago = VBSQL.SqlData(CORVAR.hgblConexion, 9);
                    lSucursal = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10)));
                    dCredAcum = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11));
                    pszFecCred = VBSQL.SqlData(CORVAR.hgblConexion, 12);

                    //Llena encabezado
                    ID_CEJ_EMP_LBL.Text = pszEmpNombre;
                    ID_CEJ_DI1_LBL.Text = pszFiscalCalle;
                    ID_CEJ_DI2_LBL.Text = "COL. " + szFiscalCol;
                    ID_CEJ_DI3_LBL.Text = pszFiscalEdo.Trim() + ", " + pszFiscalCiudad.Trim();
                    ID_CEJ_CP_LBL.Text = "C.P. " + StringsHelper.Format(lFiscalCP, "00000");
                    ID_CEJ_CRE_EB.Text = StringsHelper.Format(dCredito, "##,###,###,##0.00");
                    //      ID_CEJ_CRE_ACU_EB.Caption = Format$(dCredAcum, "##,###,###,##0.00")
                    ID_CEJ_CRE_ACU_EB.Text = StringsHelper.Format(dTotCredAcum, "##,###,###,##0.00");
                    ID_CEJ_FEC_CRE_EB.Text = pszFecCred;
                    //Guarda el tipo de pago de la empresa para imprimirla en el reporte
                    ID_CEJ_CRE_EB.Tag = pszTipoPago.ToString();
                    //Guarda la cuenta de cheques de la empresa para imprimirla en el reporte
                    pszCuentaBan = lSucursal.ToString() + lCuenta.ToString();
                }
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        }

        //UPGRADE_NOTE: (7001) The following declaration (Carga_Reporte) seems to be dead code
        //private int Carga_Reporte()
        //{
        //int iError = 0;
        //int hEjeEmp1 = 0;
        //int hEjeEmp2 = 0;
        //int hEjeEmp3 = 0;
        //int iValor = 0;
        //string pszTempCuenta = String.Empty;
        //double dSumaSaldos = 0;
        //string pszSQL = String.Empty;
        //
        //
        //iTotMesesVencidos = CORVB.NULL_INTEGER;
        //dTotSaldoAnt = CORVB.NULL_INTEGER;
        //dTotCompras = CORVB.NULL_INTEGER;
        //dTotDispEfec = CORVB.NULL_INTEGER;
        //dTotPagos = CORVB.NULL_INTEGER;
        //dTotComisiones = CORVB.NULL_INTEGER;
        //dTotIntereses = CORVB.NULL_INTEGER;
        //dTotIva = CORVB.NULL_INTEGER;
        //dTotSaldoNuevo = CORVB.NULL_INTEGER;
        //dTotPagos = CORVB.NULL_INTEGER;
        //int iRegistro = CORVB.NULL_INTEGER;
        //dCredAcum = CORVB.NULL_INTEGER;
        //
        //this.Cursor = Cursors.WaitCursor;
        //Obtiene los Campos de la tabla de Ejecutivos Banamex
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        // pszgblsql = "reporte_eje_empresa " + Str(lgblEmpCve) + "," + Str(igblBanco) + "," + Str(igblMesCorte)
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = "reporte_eje_empresa " + Conversion.Str(CORVAR.lgblEmpCve) + "," + Conversion.Str(CORVAR.igblPref) + "," + Conversion.Str(CORVAR.igblBanco) + "," + Conversion.Str(CORVAR.igblMesCorte);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //
        //while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
        //{
        //iEjeMesesVencidos = CORVB.NULL_INTEGER;
        //dSaldoAnterior = CORVB.NULL_INTEGER;
        //dCompras = CORVB.NULL_INTEGER;
        //dDispEfec = CORVB.NULL_INTEGER;
        //dPagosAbonos = CORVB.NULL_INTEGER;
        //dComisiones = CORVB.NULL_INTEGER;
        //dIntereses = CORVB.NULL_INTEGER;
        //dIva = CORVB.NULL_INTEGER;
        //dSaldoNuevo = CORVB.NULL_INTEGER;
        //szEjeNombre.Value = CORVB.NULL_STRING; //ymf
        //iLimCred = CORVB.NULL_INTEGER;
        //
        //iEjePrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
        //iGpoBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
        //lEmpresas = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
        //iEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
        //iEjeRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
        //iEjeDigit = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
        //szEjeNombre.Value = VBSQL.SqlData(CORVAR.hgblConexion, 7);
        //*: ****************************************************************************
        //*: Cambio de tipo de la variable para permitir la generación de reporte
        //*: EISSA MRG 2005-03-28
        //sEjeNumNom = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim(); //lEjeNumNom = Val(SqlData(hgblConexion, 8))
        //*: Fin: Cambio de tipo de la variable para permitir la generación de reporte
        //*: ****************************************************************************
        //szCentroCostos.Value = VBSQL.SqlData(CORVAR.hgblConexion, 9);
        //dSaldoAnterior = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10));
        //dPagosAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11));
        //dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12));
        //dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 13));
        //iEjeMesesVencidos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 14)));
        //iLimCred = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 15)));
        //dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
        //dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
        //
        //***** Inicio Código Anterior para Formateo de Empresa y Ejecutivo
        //      pszTempCuenta = Format(iEjePrefijo, "0000") + Format(iGpoBanco, "00") + Format(lEmpresas, "00000") + Format(iEjeNum, "000") + Format(iEjeRollOver, "0") + Format(iEjeDigit, "0")
        //****** Fin de Código Anterior para Formateo de Empresa y Ejecutivo
        //EISSA Inicio Código Nuevo para Formateo de Empresa y Ejecutivo
        //pszTempCuenta = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iGpoBanco, "00") + StringsHelper.Format(lEmpresas, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(iEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iEjeRollOver, "0") + StringsHelper.Format(iEjeDigit, "0");
        //EISSA Fin de Código Nuevo para Formateo de Empresa y Ejecutivo
        //
        //pszCuenta = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 9, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 13, 4);
        //
        //***** Código Anterior     ***********
        //      ID_DAT_NUM_TXT(0).Caption = Mid$(pszTempCuenta, 1, 4) + Space$(1) + Mid$(pszTempCuenta, 5, 7)
        //***** Fin Código Anterior ***********
        //
        //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
        //ID_DAT_NUM_TXT[0].Text = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 2) + Strings.Mid(pszTempCuenta, 7, Formato.sMascara(Formato.iTipo.Empresa).Length);
        //EISSA 05.10.2001 FIN
        //
        //Incrementa el contador de los registros
        //iRegistro++;
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //     pszgblSql2 = "exec reporte_eje_compras " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpresas) + "," + Str(iEjeNum)
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblSql2 = "exec reporte_eje_compras " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Conversion.Str(CORVAR.igblMesCorte) + "," + Conversion.Str(lEmpresas) + "," + Conversion.Str(iEjeNum);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //if (CORPROC2.Consulta_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
        //{
        //dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
        //}
        //}
        //Realiza fin de Query
        //lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
        //
        //Busca el nombre del tarjetahabiente en la tabla MTCTHS01
        //cuando no se encuentra el la tabla MTCEJE01   ymf 29/04/97
        //if (szEjeNombre.Value.Trim() == "")
        //{
        //string tempRefParam = szEjeNombre.Value;
        //Obten_Nombre_Eje(ref tempRefParam);
        //}
        //
        //
        //Obtiene los Campos
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //     pszgblSql2 = "exec reporte_eje_disp " + Format$(igblBanco) + "," + Str(igblMesCorte) + "," + Str(lEmpresas) + "," + Str(iEjeNum)
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblSql2 = "exec reporte_eje_disp " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Conversion.Str(CORVAR.igblMesCorte) + "," + Conversion.Str(lEmpresas) + "," + Conversion.Str(iEjeNum);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //if (CORPROC2.Consulta_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
        //{
        //dDispEfec = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion2, 1));
        //}
        //}
        //Realiza fin de Query
        //lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
        //
        //Calcula el nuevo saldo
        //dSaldoNuevo = dSaldoAnterior + dCompras + dDispEfec + dComisiones + dIntereses + dIva - dPagosAbonos;
        //dTotSaldoNuevo += dSaldoNuevo;
        //Llena spread de detalle de ejecutivos
        //Llena_Detalle(iRegistro);
        //};
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //Suma los saldos deudores
        //dSumaSaldos = CORVB.NULL_INTEGER;
        //dSumSalAcre = CORVB.NULL_INTEGER;
        //dSumSalDeud = CORVB.NULL_INTEGER;
        //for (int iCont = 1; iCont <= ID_CEJ_REP_SS.MaxRows; iCont++)
        //{
        //ID_CEJ_REP_SS.Row = iCont;
        //ID_CEJ_REP_SS.Col = 14;
        //if (Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Text) > CORVB.NULL_INTEGER)
        //{
        //dSumaSaldos += Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Text);
        //dSumSalDeud += Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Text);
        //} else
        //{
        //dSumSalAcre += Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Text);
        //}
        //}
        //
        //iMaxRenglon = iRegistro + 4;
        //Calcula_totales(iMaxRenglon);
        //Carga_Encabezado();
        //Llena_Concentrado();
        //
        //Asigna el mesaje al edit box para que sea modificado por el usuario antes de imprimir
        //ID_CEJ_MSG_TXT.Text = new String(' ', 10) + "DE ACUERDO A LAS INSTRUCCIONES SE LE CARGARA AUTOMATICAMENTE LA CANTIDAD DE  " + StringsHelper.Format(dSumaSaldos, "###,###,###,##0.00") + "  EN SU CUENTA  " + pszCuentaBan;
        //
        //this.Cursor = Cursors.Default;
        //
        //} else
        //{
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //AIS-1182 NGONZALEZ
        //iError = API.USER.PostMessage(CORRPCEJ.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
        //}
        //Realiza fin de Query
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //return iRegistro;
        //
        //}

        private int Concen_Emp_Eje()
        {
            int iError = 0;
            int hEjeEmp1 = 0;
            int hEjeEmp2 = 0;
            int hEjeEmp3 = 0;
            int iValor = 0;
            string pszTempCuenta = String.Empty;
            double dSumaSaldos = 0;
            string pszSQL = String.Empty;
            iTotMesesVencidos = CORVB.NULL_INTEGER;
            dTotSaldoAnt = CORVB.NULL_INTEGER;
            dTotCompras = CORVB.NULL_INTEGER;
            dTotDispEfec = CORVB.NULL_INTEGER;
            dTotPagos = CORVB.NULL_INTEGER;
            dTotComisiones = CORVB.NULL_INTEGER;
            dTotIntereses = CORVB.NULL_INTEGER;
            dTotIva = CORVB.NULL_INTEGER;
            dTotSaldoNuevo = CORVB.NULL_INTEGER;
            dTotPagos = CORVB.NULL_INTEGER;
            int iRegistro = CORVB.NULL_INTEGER;
            dCredAcum = CORVB.NULL_INTEGER;

            CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

            this.Cursor = Cursors.WaitCursor;

            //15.10.2001 EISSA Código Anterior
            //  pszgblsql = "exec spS_Conce_Emp_Eje " + Str(lgblEmpCve) + "," + Str(igblPref) + "," + Str(igblBanco) + "," + Str(igblMesCorte)
            //15.10.2001 EISSA Fin de Código Anterior
            //EISSA 08.11.2001   Código Nuevo, para enviar el parámetro de fecha personalizado por empresa
            if (CORRPCE2.DefInstance.chkEmpresa[0].CheckState == CheckState.Checked)
            {
                CORVAR.pszgblsql = "exec spS_Conce_Emp_Eje " + Conversion.Str(CORVAR.igblPref) + "," + Conversion.Str(CORVAR.igblBanco) + ", " + Conversion.Str(CORVAR.lgblEmpCve) + ", null," + Formato.ifncMes(CORVAR.igblMesCorte).ToString();
            }
            else
            {
                if (CORRPCE2.DefInstance.lstLista.Items.Count > 0)
                {
                    CORVAR.pszgblsql = "exec spS_Conce_Emp_Eje " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + ", " + CORVAR.lgblEmpCve.ToString() + ",'" + Seguridad.fncsSustituir(Strings.Mid(CORRPCE2.DefInstance.lstLista.Text, 1, CORRPCE2.DefInstance.lstLista.Text.IndexOf("\t") + 1), "\t", "") + "'," + Formato.ifncMes(CORVAR.igblMesCorte).ToString();
                }
                else
                {
                    CORVAR.pszgblsql = "exec spS_Conce_Emp_Eje " + Conversion.Str(CORVAR.igblPref) + "," + Conversion.Str(CORVAR.igblBanco) + ", " + Conversion.Str(CORVAR.lgblEmpCve) + ", null," + Formato.ifncMes(CORVAR.igblMesCorte).ToString();
                }
            }
            //EISSA 08.11.2001   Fin de Código Nuevo

            //***** EL STORED PROCEDURE YA CONTEMPLA EL PREFIJO ***** FSWBMX
            if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
            {
                do
                {
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {

                        iEjeMesesVencidos = CORVB.NULL_INTEGER;
                        dSaldoAnterior = CORVB.NULL_INTEGER;
                        dCompras = CORVB.NULL_INTEGER;
                        dDispEfec = CORVB.NULL_INTEGER;
                        dPagosAbonos = CORVB.NULL_INTEGER;
                        dComisiones = CORVB.NULL_INTEGER;
                        dIntereses = CORVB.NULL_INTEGER;
                        dIva = CORVB.NULL_INTEGER;
                        dSaldoNuevo = CORVB.NULL_INTEGER;
                        szEjeNombre.Value = CORVB.NULL_STRING; //ymf
                        iLimCred = CORVB.NULL_INTEGER;
                        iEjePrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        iGpoBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                        lEmpresas = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                        iEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
                        iEjeRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
                        iEjeDigit = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
                        szEjeNombre.Value = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                        //*: ****************************************************************************
                        //*: Cambio de tipo de la variable para permitir la generación de reporte
                        //*: EISSA MRG 2005-03-28
                        sEjeNumNom = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim(); //lEjeNumNom = Val(SqlData(hgblConexion, 8))
                        //*: Fin: Cambio de tipo de la variable para permitir la generación de reporte
                        //*: ****************************************************************************
                        iLimCred = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 9)));
                        szCentroCostos.Value = VBSQL.SqlData(CORVAR.hgblConexion, 10);
                        iEjeMesesVencidos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11)));
                        dSaldoAnterior = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12));
                        dCompras = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 13));
                        dDispEfec = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 14));
                        dPagosAbonos = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 15));
                        dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 16));
                        dIntereses = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 17));

                        dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dIntereses)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                        dIntereses = Convert.ToInt32(((dIntereses - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;

                        //Calcula cuenta con formato
                        //***** Código Anterior     ***********
                        //      pszTempCuenta = Format(iEjePrefijo, "0000") + Format(iGpoBanco, "00") + Format(lEmpresas, "00000") + Format(iEjeNum, "000") + Format(iEjeRollOver, "0") + Format(iEjeDigit, "0")
                        //***** Fin Código Anterior ***********

                        //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
                        pszTempCuenta = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iGpoBanco, "00") + StringsHelper.Format(lEmpresas, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(iEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iEjeRollOver, "0") + StringsHelper.Format(iEjeDigit, "0");
                        //EISSA 05.10.2001 FIN


                        pszCuenta = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 9, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 13, 4);

                        ID_DAT_NUM_TXT[0].Text = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 2) + Strings.Mid(pszTempCuenta, 7, Formato.sMascara(Formato.iTipo.Empresa).Length);

                        //Incrementa el contador de los registros
                        iRegistro++;

                        dSaldoNuevo = dSaldoAnterior + dCompras + dDispEfec + dComisiones + dIntereses + dIva - dPagosAbonos;
                        if (slTipoFacturacion == CRSParametros.cteCorporativo)
                        {
                            if (iEjeNum == 0)
                            {
                                dTotSaldoNuevo += dSaldoNuevo;
                            }
                        }
                        else
                        {
                            dTotSaldoNuevo += dSaldoNuevo;
                        }
                        //Llena spread de detalle de ejecutivos
                        Llena_Detalle(iRegistro);


                    }

                }
                while (VBSQL.SqlResults(CORVAR.hgblConexion) != 2);
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                CORPROC2.Libera_Memoria(CORVAR.hgblConexion);

                //Suma los saldos deudores
                dSumaSaldos = CORVB.NULL_INTEGER;
                dSumSalAcre = CORVB.NULL_INTEGER;
                dSumSalDeud = CORVB.NULL_INTEGER;
                for (int iCont = 1; iCont <= ID_CEJ_REP_SS.MaxRows; iCont++)
                {
                    ID_CEJ_REP_SS.Row = iCont;
                    ID_CEJ_REP_SS.Col = 14;
                    if (Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Value.ToString()) > CORVB.NULL_INTEGER)
                    {
                        //Si el tipo de facturación es corporativa, entonces sólo toma la cuenta CERO
                        ID_CEJ_REP_SS.Col = 1;
                        if (slTipoFacturacion == "C")
                        {
                            double dbNumericTemp = 0;
                            if (Double.TryParse(ID_CEJ_REP_SS.Value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) && Double.Parse(ID_CEJ_REP_SS.Value.ToString()) == 0)
                            {
                                ID_CEJ_REP_SS.Col = 14;
                                dSumaSaldos += Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Value.ToString());
                                dSumSalDeud += Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Value.ToString());
                            }
                        }
                        else
                        {
                            ID_CEJ_REP_SS.Col = 14;
                            dSumaSaldos += Double.Parse(ID_CEJ_REP_SS.Value.ToString());
                            dSumSalDeud += Double.Parse(ID_CEJ_REP_SS.Value.ToString());
                        }
                    }
                    else
                    {
                        //Si el tipo de facturación es corporativa, entonces sólo toma la cuenta CERO
                        ID_CEJ_REP_SS.Col = 1;
                        if (slTipoFacturacion == "C")
                        {
                            double dbNumericTemp2 = 0;
                            if (Double.TryParse(ID_CEJ_REP_SS.Value.ToString(), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2) && Double.Parse(ID_CEJ_REP_SS.Value.ToString()) == 0)
                            {
                                ID_CEJ_REP_SS.Col = 14;
                                dSumSalAcre += Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Value.ToString());
                            }
                        }
                        else
                        {
                            ID_CEJ_REP_SS.Col = 14;
                            dSumSalAcre += Double.Parse(CORRPCEJ.DefInstance.ID_CEJ_REP_SS.Value.ToString());
                        }
                    }
                }

                iMaxRenglon = iRegistro + 4;
                Calcula_totales(iMaxRenglon);
                Carga_Encabezado();
                Llena_Concentrado();

                //Asigna el mesaje al edit box para que sea modificado por el usuario antes de imprimir
                ID_CEJ_MSG_TXT.Text = new String(' ', 10) + "DE ACUERDO A LAS INSTRUCCIONES SE LE CARGARA AUTOMATICAMENTE LA CANTIDAD DE  " + StringsHelper.Format(dSumaSaldos, "###,###,###,##0.00") + "  EN SU CUENTA  " + pszCuentaBan;

                this.Cursor = Cursors.Default;

            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                //AIS-1182 NGONZALEZ
                //iError = API.USER.PostMessage(CORRPCEJ.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }
            //Realiza fin de Query
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return iRegistro;

        }


        private void CORRPCEJ_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                CORVAR.igblFormaActiva = CORCONST.INT_ACT_CEJ;
                CORPROC.Cambia_StatusOpciones(-1);
            }
        }

        //UPGRADE_WARNING: (2065) Form event CORRPCEJ.Deactivate has a new behavior.
        private void CORRPCEJ_Deactivate(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblFormaActiva = CORVB.NULL_INTEGER;
            CORPROC.Cambia_StatusOpciones(0);

        }

        private void CORRPCEJ_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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
            slTipoFacturacion = "";
            //this.Left = (int) VB6.TwipsToPixelsX((((float) VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float) VB6.PixelsToTwipsX(this.Width))) / 2);
            //this.Top = (int) VB6.TwipsToPixelsY((((float) VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float) VB6.PixelsToTwipsY(this.Height))) / 2);

            this.Cursor = Cursors.WaitCursor;
            CORVAR.pszgblsql = "Select emp_tipo_fac from MTCEMP01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " Where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();
            if (CORPROC2.ObtieneRegistros(ref CORVAR.pszgblsql) != 0)
            {
                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {

                    slTipoFacturacion = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            Formatea_Spread();
            if (Concen_Emp_Eje() == CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORRPCEJ.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            this.Cursor = Cursors.Default;

        }

        private void CORRPCEJ_Closed(Object eventSender, EventArgs eventArgs)
        {

            CORPROC.Cambia_StatusOpciones(0);

            //Realiza Desconexión
            //   SqlClose (hgblConexion2)

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Formatea_Spread()
        {

            int iCont = 0;

            ID_CEJ_REP_SS.Col = 1;
            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.set_ColWidth(1, 6 * 8);
            ID_CEJ_REP_SS.Text = "Cuenta";

            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.set_ColWidth(2, 25 * 9);
            ID_CEJ_REP_SS.Text = "Ejecutivo";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 3;
            //ID_CEJ_REP_SS.set_ColWidth(3, 10);
            ID_CEJ_REP_SS.set_ColWidth(3, 15 * 4);//se corrige la longitud de el número de nómina
            ID_CEJ_REP_SS.Text = "Nómina";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 4;
            ID_CEJ_REP_SS.set_ColWidth(4, 15 * 5);
            ID_CEJ_REP_SS.Text = "Crédito";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 5;
            ID_CEJ_REP_SS.set_ColWidth(5, 10 * 9);
            ID_CEJ_REP_SS.Text = "C. de Costos";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.set_ColWidth(6, 10 * 7);
            ID_CEJ_REP_SS.Text = "Atrasos";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.set_ColWidth(7, 15 * 8);
            ID_CEJ_REP_SS.Text = "Saldo Anterior";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 8;
            ID_CEJ_REP_SS.set_ColWidth(8, 10 * 7);
            ID_CEJ_REP_SS.Text = "Consumos";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 9;
            ID_CEJ_REP_SS.set_ColWidth(9, 10 * 7);
            ID_CEJ_REP_SS.Text = "Disp. Efvo.";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 10;
            ID_CEJ_REP_SS.set_ColWidth(10, 10 * 7);
            ID_CEJ_REP_SS.Text = "Pagos";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 11;
            ID_CEJ_REP_SS.set_ColWidth(11, 10 * 7);
            ID_CEJ_REP_SS.Text = "Comisiones";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 12;
            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.set_ColWidth(12, 10 * 7);
            ID_CEJ_REP_SS.Text = "Gtos. Cobr.";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 13;
            ID_CEJ_REP_SS.set_ColWidth(13, 10 * 7);
            ID_CEJ_REP_SS.Text = "I.V.A.";

            ID_CEJ_REP_SS.Row = 0;
            ID_CEJ_REP_SS.Col = 14;
            ID_CEJ_REP_SS.set_ColWidth(14, 15 * 7);
            ID_CEJ_REP_SS.Text = "Saldo Nuevo";

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

        private void Llena_Concentrado()
        {

            ID_CEJ_RES_TXT[0].Text = StringsHelper.Format(dTotSaldoAnt, "$##,###,###,##0.00");
            ID_CEJ_RES_TXT[1].Text = StringsHelper.Format(dTotCompras, "$##,###,###,##0.00");
            ID_CEJ_RES_TXT[2].Text = StringsHelper.Format(dTotDispEfec, "$##,###,###,##0.00");
            ID_CEJ_RES_TXT[3].Text = StringsHelper.Format(dTotPagos, "$##,###,###,##0.00");
            ID_CEJ_RES_TXT[4].Text = StringsHelper.Format(dTotComisiones, "$##,###,###,##0.00");
            ID_CEJ_RES_TXT[5].Text = StringsHelper.Format(dTotIntereses, "$##,###,###,##0.00");
            ID_CEJ_RES_TXT[6].Text = StringsHelper.Format(dTotIva, "$##,###,###,##0.00");
            ID_CEJ_RES_TXT[7].Text = StringsHelper.Format(dTotSaldoNuevo, "$##,###,###,##0.00");

        }

        private void Llena_Detalle(double iRenglon)
        {
            this.Cursor = Cursors.WaitCursor;

            ID_CEJ_REP_SS.MaxRows = Convert.ToInt32(iRenglon);
            ID_CEJ_REP_SS.Row = Convert.ToInt32(iRenglon);

            //Cuenta del Ejecutivo
            ID_CEJ_REP_SS.Col = 1;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            string lsAuxCuenta = Strings.Mid(pszCuenta, 1, 4) + Strings.Mid(pszCuenta, 6, 4) + Strings.Mid(pszCuenta, 11, 4) + Strings.Mid(pszCuenta, 16, 4);
            //***** Inicio Código Anterior para Formateo de Ejecutivo
            //    ID_CEJ_REP_SS.Text = Space(1) + Format$(Mid$(Trim$(pszCuenta), 14, 1) + Mid$(Trim$(pszCuenta), 16, 2), "000")
            //****** Fin de Código Anterior para Formateo de Empresa y Ejecutivo
            //EISSA Inicio Código Nuevo para Formateo de Ejecutivo
            ID_CEJ_REP_SS.Text = new String(' ', 1) + StringsHelper.Format(Strings.Mid(lsAuxCuenta, 7 + Formato.sMascara(Formato.iTipo.Empresa).Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length), Formato.sMascara(Formato.iTipo.Ejecutivo));
            int llEjecutivo = Convert.ToInt32(Conversion.Val(ID_CEJ_REP_SS.Value));
            //EISSA Fin de Código Nuevo para Formateo de Empresa y Ejecutivo

            //Nombre del Ejecutivo
            ID_CEJ_REP_SS.Col = 2;
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            ID_CEJ_REP_SS.Text = new String(' ', 1) + szEjeNombre.Value.Trim();

            //# de Nomina
            ID_CEJ_REP_SS.Col = 3;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            //*: ****************************************************************************
            //*: Cambio de tipo de la variable para permitir la generación de reporte
            //*: EISSA MRG 2005-03-28
            ID_CEJ_REP_SS.Text = sEjeNumNom; //ID_CEJ_REP_SS.Text = Format(lEjeNumNom, "00000000")
            //*: Fin: Cambio de tipo de la variable para permitir la generación de reporte
            //*: ****************************************************************************

            //Limite de credito
            ID_CEJ_REP_SS.Col = 4;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(iLimCred, "##,###,###,##0.00");
            if (llEjecutivo > 0)
            {
                dCredAcum += iLimCred;
                dTotCredAcum = dCredAcum;
            }


            //Centro de Costos
            ID_CEJ_REP_SS.Col = 5;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CEJ_REP_SS.Text = szCentroCostos.Value.Trim();

            //# de Meses Vencidos
            ID_CEJ_REP_SS.Col = 6;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(iEjeMesesVencidos, "#0");
            iTotMesesVencidos += iEjeMesesVencidos;

            //Saldo Anterior
            ID_CEJ_REP_SS.Col = 7;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dSaldoAnterior, "##,###,###,##0.00");
            if (slTipoFacturacion == "C")
            {
                if (llEjecutivo == 0)
                {
                    dTotSaldoAnt += dSaldoAnterior;
                }
            }
            else
            {
                dTotSaldoAnt += dSaldoAnterior;
            }

            //Consumos
            ID_CEJ_REP_SS.Col = 8;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dCompras, "##,###,###,##0.00");
            if (slTipoFacturacion == "C")
            {
                if (llEjecutivo == 0)
                {
                    dTotCompras += dCompras;
                }
            }
            else
            {
                dTotCompras += dCompras;
            }

            //Disposición de Efectivo
            ID_CEJ_REP_SS.Col = 9;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dDispEfec, "##,###,###,##0.00");
            if (slTipoFacturacion == "C")
            {
                if (llEjecutivo == 0)
                {
                    dTotDispEfec += dDispEfec;
                }
            }
            else
            {
                dTotDispEfec += dDispEfec;
            }

            //Pagos y Abonos
            ID_CEJ_REP_SS.Col = 10;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dPagosAbonos, "##,###,###,##0.00");
            if (slTipoFacturacion == "C")
            {
                if (llEjecutivo == 0)
                {
                    dTotPagos += dPagosAbonos;
                }
            }
            else
            {
                dTotPagos += dPagosAbonos;
            }

            //Comisiones
            ID_CEJ_REP_SS.Col = 11;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dComisiones, "##,###,###,##0.00");
            if (slTipoFacturacion == "C")
            {
                if (llEjecutivo == 0)
                {
                    dTotComisiones += dComisiones;
                }
            }
            else
            {
                dTotComisiones += dComisiones;
            }

            //Intereses
            ID_CEJ_REP_SS.Col = 12;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dIntereses, "##,###,###,##0.00");
            if (slTipoFacturacion == "C")
            {
                if (llEjecutivo == 0)
                {
                    dTotIntereses += dIntereses;
                }
            }
            else
            {
                dTotIntereses += dIntereses;
            }

            //IVA
            ID_CEJ_REP_SS.Col = 13;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dIva, "##,###,###,##0.00");
            if (slTipoFacturacion == "C")
            {
                if (llEjecutivo == 0)
                {
                    dTotIva += dIva;
                }
            }
            else
            {
                dTotIva += dIva;
            }

            //Saldo Nuevo
            ID_CEJ_REP_SS.Col = 14;
            ID_CEJ_REP_SS.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
            ID_CEJ_REP_SS.TypeHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            ID_CEJ_REP_SS.TypeFloatSeparator = true;
            ID_CEJ_REP_SS.Text = StringsHelper.Format(dSaldoNuevo, "##,###,###,##0.00");
            if (slTipoFacturacion == "C")
            {
                if (llEjecutivo == 0)
                {
                    dSaldoNuevo += dSaldoNuevo;
                }
            }
            else
            {
                dSaldoNuevo += dSaldoNuevo;
            }

        }

        private void Obten_Nombre_Eje(ref  string szNombre)
        {

            int hEjeEmp4 = 0;
            int iValor = 0;
            int iError = 0;

            string pszTempNombre = String.Empty;
            string pszTempCad1 = String.Empty;
            string pszTempCad2 = String.Empty;
            string pszTempCad3 = String.Empty;

            int iPosicion1 = 0;
            int iPosicion2 = 0;
            int iLongitud = 0;

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //   pszgblSql2 = "select ths_nombre from MTCTHS01 where gpo_banco =" + Format$(igblBanco) + " and emp_num= " + Str(lEmpresas) + " and eje_num=" + Str(iEjeNum)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblSql2 = "select ths_nombre from MTCTHS01 where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco= " + Conversion.Str(CORVAR.igblBanco) + " and emp_num= " + Conversion.Str(lEmpresas) + " and eje_num=" + Conversion.Str(iEjeNum);
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Consulta_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion2) == VBSQL.MOREROWS)
                {
                    pszTempNombre = VBSQL.SqlData(CORVAR.hgblConexion2, 1);
                    iPosicion1 = (pszTempNombre.IndexOf(',') + 1);
                    iPosicion2 = (pszTempNombre.IndexOf('/') + 1);
                    if (iPosicion1 == 0 || iPosicion2 == 0)
                    {
                        szNombre = "";
                    }
                    else
                    {
                        pszTempCad1 = pszTempNombre.Substring(0, Math.Min(pszTempNombre.Length, iPosicion1 - 1));
                        pszTempCad2 = Strings.Mid(pszTempNombre, iPosicion1 + 1, (iPosicion2 - iPosicion1) - 1);
                        pszTempCad3 = Strings.Mid(pszTempNombre, iPosicion2 + 1, CORBD.LNG_THS_NOM);
                        szNombre = pszTempCad1.Trim() + " " + pszTempCad2.Trim() + " " + pszTempCad3.Trim();
                    }
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
            //Realiza fin de Query
            lRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);


        }
    }
}