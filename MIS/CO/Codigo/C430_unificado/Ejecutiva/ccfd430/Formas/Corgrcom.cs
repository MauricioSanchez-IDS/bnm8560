using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORGRCOM
        : System.Windows.Forms.Form
    {

        private void CORGRCOM_Activated(Object eventSender, EventArgs eventArgs)
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
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Grafica comparativa de empresas en base             **
        //**                    a un periodo y a un tipo                            **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        const int INT_FONTSIZE_TIT = 150;
        const int INT_FONTSIZE_OTROS = 100;

        //Arreglo para almacenar los doce meses atras a la Fecha
        int[] iArrMesAño = null;

        //Arreglo para almacenar los valores de las fechas a sumarizar dependiendo del periodo
        string[,] pszArrMesAño = null;

        //Arreglo para almacenar los importes de cada columna de la gráfica
        double[] dArrImportes = null;

        //Variable para la conexion a la Base de Datos
        int hConexion = 0;

        //Variables para los handels a grupos y a empresas
        int hGrupos = 0;
        int hEmpresas = 0;

        //Variables del Total de Elementos de los Combos
        int lTotalGrupos = 0;
        int lTotalEmpresas = 0;

        //Variable para controlar el numero de Grupos y Empresas Restantes
        int lGruposRestantes = 0;
        int lEmpresasRestantes = 0;

        //Variables para los textos de la Gráfica
        string pszTitulo = String.Empty;
        string pszPie = String.Empty;

        //Variables para Mes y Año global a la forma
        int iMesalDia = 0;
        int iAñoalDia = 0;
        int iAñoAnt = 0;
        int iMenAct = 0;
        int iBimAct = 0;
        int iTrimAct = 0;
        int iSemAct = 0;

        //Variables para controlar la Maximización y Minimización de la Gráfica
        int bMaximizada = 0;
        int iPnlTop = 0;
        int iPnlLeft = 0;
        int iPnlHeight = 0;
        int iPnlWidth = 0;
        int iGphTop = 0;
        int iGphLeft = 0;
        int iGphHeight = 0;
        int iGphWidth = 0;
        int iImpTop = 0;
        int iImpLeft = 0;

        private void Carga_Graf_por_Empresa()
        {

            string pszFechaMes = String.Empty;
            string pszFechaAño = String.Empty;
            int hStmt = 0;
            string pszEmpresas = String.Empty;
            double dComisiones = 0;
            double dIva = 0;

            Obten_Fecha_Act();
            Obten_Periodo();

            string pszSelect = CORVB.NULL_STRING;
            string pszSentencia = CORVB.NULL_STRING;

            pszSelect = Obten_Concepto();

            dArrImportes = new double[pszArrMesAño.GetUpperBound(0)];

            for (int iCont = 1; iCont <= pszArrMesAño.GetUpperBound(0); iCont++)
            {
                switch (ID_COM_CON_COB.SelectedIndex)
                {
                    case 0:
                        CORVAR.pszgblsql = " SELECT count(*) ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIS;
                        //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                        //        pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                        //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                        //***** INICIO CODIGO NUEVO  FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_mes_y_ciclo_corte/100 in (" + pszArrMesAño[iCont, 1] + ")";
                        //atr 980108        pszgblSql = pszgblSql + " and his_transaccion in (5550,5556,5800,5805,5808,5810,5830,5351,5358,5840,5851,5852,5853,5854,5855,5856,5870,5900,5905,5910,5930,5352,5970,6600)" 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_transaccion in (select cve_transaccion from MTCTRA01 where tip_transaccion = 'dispo' or tip_transaccion = 'compra')";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblTempNumEmp.ToString();
                        break;
                    case 2:
                        CORVAR.pszgblsql = " SELECT count(*) ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIS;
                        //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                        //        pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                        //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                        //***** INICIO CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_mes_y_ciclo_corte/100 in (" + pszArrMesAño[iCont, 1] + ")";
                        //atr 980108        pszgblSql = pszgblSql + " and his_transaccion not in (5550,5556,5800,5805,5808,5810,5830,5351,5358,5840,5851,5852,5853,5854,5855,5856,5870,5900,5905,5910,5930,5352,5970,6600)" 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_transaccion not in (select cve_transaccion from MTCTRA01 where tip_transaccion = 'dispo' or tip_transaccion = 'compra')";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblTempNumEmp.ToString();
                        break;
                    default:
                        CORVAR.pszgblsql = pszSelect;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIH;
                        //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                        //        pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                        //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                        //***** INICIO CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblTempNumEmp.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and hih_corte_a = " + pszArrMesAño[iCont, 2];
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and hih_corte_md/100 in (" + pszArrMesAño[iCont, 1] + ")";
                        break;
                }


                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        switch (ID_COM_CON_COB.SelectedIndex)
                        {
                            case 5:
                                dArrImportes[iCont] = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dArrImportes[iCont])) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                                dArrImportes[iCont] = Convert.ToInt32(((dArrImportes[iCont] - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                                break;
                            default:
                                dArrImportes[iCont] = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                        }
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Ocurrio algún Error al tratar de Obtener la Información para la Gráfica. " + "\n" + "Probablemente no Existe alguno de los campos a consultar en la Tabla." + "\n" + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    break;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            if (~Existen_Importes() != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                ID_COM_GRP_PNL.Enabled = false;
            }
            else
            {
                ID_COM_GRP_PNL.Enabled = true;
                Carga_Grafica();
            }

        }

        private void Carga_Graf_por_Grupo()
        {

            string pszFechaMes = String.Empty;
            string pszFechaAño = String.Empty;
            int hStmt = 0;
            double dComisiones = 0;
            double dIva = 0;

            Obten_Fecha_Act();
            Obten_Periodo();

            string pszSelect = CORVB.NULL_STRING;
            CORVAR.pszgblsql = CORVB.NULL_STRING;

            pszSelect = Obten_Concepto();

            string pszEmpresas = Obten_Emp_del_Gpo();

            dArrImportes = new double[pszArrMesAño.GetUpperBound(0)];

            if (pszEmpresas != CORVB.NULL_STRING)
            {
                for (int iCont = 1; iCont <= pszArrMesAño.GetUpperBound(0); iCont++)
                {
                    switch (ID_COM_CON_COB.SelectedIndex)
                    {
                        case 0:
                            CORVAR.pszgblsql = " SELECT count(*) ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIS;
                            //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                            //          pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                            //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                            //***** INICIO CODIGO NUEVO FSWBMX ***** 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_mes_y_ciclo_corte/100 in (" + pszArrMesAño[iCont, 1] + ")";
                            //atr 980108          pszgblSql = pszgblSql + " and his_transaccion in (5550,5556,5800,5805,5808,5810,5830,5351,5358,5840,5851,5852,5853,5854,5855,5856,5870,5900,5905,5910,5930,5352,5970,6600)" 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_transaccion in (select cve_transaccion from MTCTRA01 where tip_transaccion = 'dispo' or tip_transaccion = 'compra')";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num in (" + pszEmpresas + ")";
                            break;
                        case 2:
                            CORVAR.pszgblsql = " SELECT count(*) ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIS;
                            //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                            //          pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                            //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                            //***** INICIO CODIGO NUEVO FSWBMX ***** 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_mes_y_ciclo_corte/100 in (" + pszArrMesAño[iCont, 1] + ")";
                            //atr 980108          pszgblSql = pszgblSql + " and his_transaccion not in (5550,5556,5800,5805,5808,5810,5830,5351,5358,5840,5851,5852,5853,5854,5855,5856,5870,5900,5905,5910,5930,5352,5970,6600)" 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_transaccion not in (select cve_transaccion from MTCTRA01 where tip_transaccion = 'dispo' or tip_transaccion = 'compra')";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num in (" + pszEmpresas + ")";
                            break;
                        default:
                            CORVAR.pszgblsql = pszSelect;
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIH;
                            //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                            //          pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                            //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                            //***** INICIO CODIGO NUEVO FSWBMX ***** 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num in (" + pszEmpresas + ")";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and hih_corte_a = " + pszArrMesAño[iCont, 2];
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and hih_corte_md/100 in (" + pszArrMesAño[iCont, 1] + ")";
                            break;
                    }

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            switch (ID_COM_CON_COB.SelectedIndex)
                            {
                                case 5:
                                    dArrImportes[iCont] = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                    dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                    dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dArrImportes[iCont])) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                                    dArrImportes[iCont] = Convert.ToInt32(((dArrImportes[iCont] - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                                    break;
                                default:
                                    dArrImportes[iCont] = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                    break;
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Ocurrio algún Error al tratar de Obtener la Información para la Gráfica. " + "\n" + "Probablemente no Existe alguno de los campos a consultar en la Tabla." + "\n" + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        break;
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                }

                if (~Existen_Importes() != 0)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    ID_COM_GRP_PNL.Enabled = false;
                }
                else
                {
                    ID_COM_GRP_PNL.Enabled = true;
                    Carga_Grafica();
                }
            }
            else
            {
                ID_COM_GRP_PNL.Enabled = false;
            }

        }

        private void Carga_Graf_por_Producto()
        {

            string pszFechaMes = String.Empty;
            string pszFechaAño = String.Empty;
            int hStmt = 0;
            double dIva = 0;
            double dComisiones = 0;

            Obten_Fecha_Act();
            Obten_Periodo();
            string pszSelect = CORVB.NULL_STRING;
            CORVAR.pszgblsql = CORVB.NULL_STRING;

            pszSelect = Obten_Concepto();

            dArrImportes = new double[pszArrMesAño.GetUpperBound(0)];
            for (int iCont = 1; iCont <= pszArrMesAño.GetUpperBound(0); iCont++)
            {
                switch (ID_COM_CON_COB.SelectedIndex)
                {
                    case 0:
                        CORVAR.pszgblsql = " SELECT count(*) ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIS;
                        //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                        //        pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                        //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                        //***** INICIO CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_mes_y_ciclo_corte/100 in (" + pszArrMesAño[iCont, 1] + ")";
                        //atr 980108        pszgblSql = pszgblSql + " and his_transaccion in (5550,5556,5800,5805,5808,5810,5830,5351,5358,5840,5851,5852,5853,5854,5855,5856,5870,5900,5905,5910,5930,5352,5970,6600)" 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_transaccion in (select cve_transaccion from MTCTRA01 where tip_transaccion = 'dispo' or tip_transaccion = 'compra')";
                        break;
                    case 2:
                        CORVAR.pszgblsql = " SELECT count(*) ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIS;
                        //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                        //        pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                        //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                        //***** INICIO CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_mes_y_ciclo_corte/100 in (" + pszArrMesAño[iCont, 1] + ")";
                        //atr 980108        pszgblSql = pszgblSql + " and his_transaccion not in (5550,5556,5800,5805,5808,5810,5830,5351,5358,5840,5851,5852,5853,5854,5855,5856,5870,5900,5905,5910,5930,5352,5970,6600)" 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_transaccion not in (select cve_transaccion from MTCTRA01 where tip_transaccion = 'dispo' or tip_transaccion = 'compra')";
                        break;
                    default:
                        CORVAR.pszgblsql = pszSelect;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " From " + CORBD.DB_SYB_HIH;
                        //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                        //        pszgblsql = pszgblsql + " Where gpo_banco = " + Format$(igblBanco) 
                        //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                        //***** INICIO CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and hih_corte_a = " + pszArrMesAño[iCont, 2];
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and hih_corte_md/100 in (" + pszArrMesAño[iCont, 1] + ")";
                        break;
                }

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        switch (ID_COM_CON_COB.SelectedIndex)
                        {
                            case 5:
                                dArrImportes[iCont] = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                dComisiones = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                dIva = Convert.ToInt32((((CORVAR.dgblIva * dComisiones) + (CORVAR.dgblIva * dArrImportes[iCont])) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                                dArrImportes[iCont] = Convert.ToInt32(((dArrImportes[iCont] - (CORVAR.dgblIva * dComisiones)) / (1 + CORVAR.dgblIva)) * 100) / 100d;
                                break;
                            default:
                                dArrImportes[iCont] = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                        }
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Ocurrio algún Error al tratar de Obtener la Información para la Gráfica. " + "\n" + "Probablemente no Existe alguno de los campos a consultar en la Tabla." + "\n" + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    break;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            if (~Existen_Importes() != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                ID_COM_GRP_PNL.Enabled = false;
                if (ID_COM_GRA_GPB[1].Value)
                {
                }
                else
                {
                    ID_COM_GRA_GPB[1].Value = true;
                }
            }
            else
            {
                ID_COM_GRP_PNL.Enabled = true;
                Carga_Grafica();
            }

        }

        private void Carga_Grafica()
        {

            string pszTitIzq = String.Empty;

            double dTotal = CORVB.NULL_INTEGER;

            ID_COM_GPH.DataReset = CORVB.G_ALL_DATA;

            ID_COM_GPH.NumPoints = (short)pszArrMesAño.GetUpperBound(0);
            ID_COM_GPH.ThisPoint = 1;
            for (int iCont = pszArrMesAño.GetUpperBound(0); iCont >= 1; iCont--)
            {
                ID_COM_GPH.GraphData = (float)Math.Abs(dArrImportes[iCont]);
                dTotal += dArrImportes[iCont];
            }

            if ((ID_COM_GRA_GPB[0].Value) || (ID_COM_GRA_GPB[1].Value))
            {
                ID_COM_GPH.GraphStyle = (short)CORVB.NULL_INTEGER;
                ID_COM_GPH.ThisPoint = 1;
                for (int iCont = pszArrMesAño.GetUpperBound(0); iCont >= 1; iCont--)
                {
                    ID_COM_GPH.LabelText = pszArrMesAño[iCont, 3].ToString() + pszArrMesAño[iCont, 2].ToString();
                }
                pszTitIzq = CORVB.NULL_STRING;
            }

            if ((ID_COM_GRA_GPB[2].Value) || (ID_COM_GRA_GPB[3].Value))
            {
                ID_COM_GPH.GraphStyle = (short)CORVB.G_PERCENTAGE;
                for (int iCont = pszArrMesAño.GetUpperBound(0); iCont >= 1; iCont--)
                {
                    ID_COM_GPH.LegendText = pszArrMesAño[iCont, 3].ToString() + pszArrMesAño[iCont, 2].ToString();
                }
                pszTitIzq = "Total = " + StringsHelper.Format(dTotal, "##,###,##0;(##,###,##0)");
            }

            switch (ID_COM_NIV_COB.SelectedIndex)
            {
                case 1:
                case 2:
                    if ((ID_COM_GRA_GPB[0].Value) || (ID_COM_GRA_GPB[1].Value))
                    {
                        ID_COM_GPH.BottomTitle = pszPie + "   " + ID_COM_INF_COB.Text.Trim();
                    }
                    else
                    {
                        ID_COM_GPH.BottomTitle = ID_COM_INF_COB.Text.Trim();
                    }
                    break;
                default:
                    ID_COM_GPH.BottomTitle = pszPie;
                    break;
            }

            ID_COM_GPH.GraphTitle = pszTitulo;
            ID_COM_GPH.LeftTitle = pszTitIzq;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_COM_GPH.DrawMode was not upgraded.
            ID_COM_GPH.DrawMode = CORVB.G_DRAW;

        }

        private int Existen_Importes()
        {

            int result = 0;

            result = 0;

            for (int iCont = 1; iCont <= pszArrMesAño.GetUpperBound(0); iCont++)
            {
                if (dArrImportes[iCont] != CORVB.NULL_INTEGER)
                {
                    result = -1;
                    break;
                }
            }

            return result;
        }

        private void CORGRCOM_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;

            if (KeyCode == CORVB.KEY_F6)
            {
                ID_COM_GPH_DblClick(ID_COM_GPH, new EventArgs());
            }

        }


        private void CORGRCOM_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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

            //Posicionamos la forma
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY(1250);

            this.Cursor = Cursors.WaitCursor;

            Inicializa_Combo_Nivel();
            Inicializa_Combo_Concepto();
            Inicializa_Combo_Periodo();

            bMaximizada = 0;

            ID_COM_GPH.FontUse = CORVB.G_USE_ALL;
            ID_COM_GPH.FontFamily = CORVB.G_FONT_SWISS;
            ID_COM_GPH.FontStyle = CORVB.G_STYLE_DEFAULT;
            //Se definen para el Título
            ID_COM_GPH.FontUse = CORVB.G_USE_DEFAULT;
            ID_COM_GPH.Font = VB6.FontChangeSize(ID_COM_GPH.Font, INT_FONTSIZE_TIT);

            //Se definen para los Títulos de la Izquierda y de Pie de Gráfica
            ID_COM_GPH.FontUse = CORVB.G_USE_OTHER;
            ID_COM_GPH.Font = VB6.FontChangeSize(ID_COM_GPH.Font, INT_FONTSIZE_OTROS);

            //Se definen para los legend Text (los de la derecha)
            ID_COM_GPH.FontUse = CORVB.G_USE_LEGEND;
            ID_COM_GPH.Font = VB6.FontChangeSize(ID_COM_GPH.Font, INT_FONTSIZE_OTROS);

            ID_COM_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_COM_GPH.DrawMode was not upgraded.
            ID_COM_GPH.DrawMode = CORVB.G_CLEAR;

            this.Cursor = Cursors.Default;

        }

        private void ID_COM_CON_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            ID_COM_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_COM_GPH.DrawMode was not upgraded.
            ID_COM_GPH.DrawMode = CORVB.G_CLEAR;
            ID_COM_GRP_PNL.Enabled = false;

            this.Cursor = Cursors.Default;

        }

        private void ID_COM_GPH_DblClick(Object eventSender, EventArgs eventArgs)
        {

            if (bMaximizada != 0)
            { //Minimiza

                ID_COM_IMP_PB.Visible = false;
                ID_COM_GPH.Visible = false;
                ID_COM_PRI1_PNL.Visible = false;
                this.Refresh();

                //Guardamos las Medidas Originales del Panel de la Gráfica
                ID_COM_PRI1_PNL.Top = (int)VB6.TwipsToPixelsY(iPnlTop);
                ID_COM_PRI1_PNL.Left = (int)VB6.TwipsToPixelsX(iPnlLeft);
                ID_COM_PRI1_PNL.Height = (int)VB6.TwipsToPixelsY(iPnlHeight);
                ID_COM_PRI1_PNL.Width = (int)VB6.TwipsToPixelsX(iPnlWidth);

                //Guardamos las Medidas Originales de la Gráfica
                ID_COM_GPH.Top = (int)VB6.TwipsToPixelsY(iGphTop);
                ID_COM_GPH.Left = (int)VB6.TwipsToPixelsX(iGphLeft);
                ID_COM_GPH.Height = (int)VB6.TwipsToPixelsY(iGphHeight);
                ID_COM_GPH.Width = (int)VB6.TwipsToPixelsX(iGphWidth);

                ID_COM_IMP_PB.Top = (int)VB6.TwipsToPixelsY(iImpTop);
                ID_COM_IMP_PB.Left = (int)VB6.TwipsToPixelsX(iImpLeft);

                ID_COM_PRI1_PNL.Visible = true;
                ID_COM_PRI_PNL.Visible = true;
                ID_COM_GRP_PNL.Visible = true;
                ID_COM_SAL_PB.Visible = true;
                ID_COM_IMP_PB.Visible = true;
                ID_COM_GRA_PB.Visible = true;
                this.Refresh();
                ID_COM_GPH.Visible = true;
                bMaximizada = 0;

            }
            else
            {
                //Ocultamos todos los controles
                ID_COM_GPH.Visible = false;
                ID_COM_PRI1_PNL.Visible = false;
                ID_COM_PRI_PNL.Visible = false;
                ID_COM_GRP_PNL.Visible = false;
                ID_COM_GRA_PB.Visible = false;
                ID_COM_IMP_PB.Visible = false;
                ID_COM_SAL_PB.Visible = false;
                this.Refresh();

                //Guardamos las Medidas Originales de la Gráfica
                iGphTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_COM_GPH.Top));
                iGphLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_COM_GPH.Left));
                iGphHeight = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_COM_GPH.Height));
                iGphWidth = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_COM_GPH.Width));

                //Guardamos las Medidas Originales del Panel de la Gráfica
                iPnlTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_COM_PRI1_PNL.Top));
                iPnlLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_COM_PRI1_PNL.Left));
                iPnlHeight = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_COM_PRI1_PNL.Height));
                iPnlWidth = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_COM_PRI1_PNL.Width));

                //Guardamos las Medidas Originales del Boton de Imprimir
                iImpTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_COM_IMP_PB.Top));
                iImpLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_COM_IMP_PB.Left));

                //Ajustamos las Medidas del Panel de la Gráfica
                ID_COM_PRI1_PNL.Top = (int)ID_COM_PRI_PNL.Top;
                ID_COM_PRI1_PNL.Left = (int)ID_COM_PRI_PNL.Left;
                ID_COM_PRI1_PNL.Height = (int)(ID_COM_PRI_PNL.Height + ID_COM_PRI1_PNL.Height);
                ID_COM_PRI1_PNL.Width = (int)ID_COM_PRI_PNL.Width;

                //Ajustamos las Medidas de la Gráfica
                ID_COM_GPH.Top = (int)ID_COM_PRI1_PNL.Top;
                ID_COM_GPH.Left = (int)ID_COM_PRI1_PNL.Left;
                ID_COM_GPH.Height = (int)ID_COM_PRI1_PNL.Height;
                ID_COM_GPH.Width = (int)ID_COM_PRI1_PNL.Width;
                this.Refresh();

                ID_COM_IMP_PB.Top = (int)(ID_COM_GPH.Height - VB6.TwipsToPixelsY(((float)VB6.PixelsToTwipsY(ID_COM_IMP_PB.Height)) * 1.5d));
                ID_COM_IMP_PB.Left = (int)VB6.TwipsToPixelsX(((float)VB6.PixelsToTwipsX(ID_COM_IMP_PB.Width)) * 0.2d);
                ID_COM_IMP_PB.BringToFront();
                this.Refresh();

                ID_COM_IMP_PB.Visible = true;
                ID_COM_GPH.Visible = true;
                ID_COM_PRI1_PNL.Visible = true;
                bMaximizada = -1;

            }

        }

        private void ID_COM_GRA_GPB_ClickEvent(Object eventSender, AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
        {
            int Index = Array.IndexOf(ID_COM_GRA_GPB, eventSender);

            //AIS-1095 NGONZALEZ
            if (eventArgs.value != 0)
            {

                switch (Index)
                {
                    case 0:
                        ID_COM_GPH.GraphType = CORVB.G_BAR2D;
                        break;
                    case 1:
                        ID_COM_GPH.GraphType = CORVB.G_BAR3D;
                        break;
                    case 2:
                        ID_COM_GPH.GraphType = CORVB.G_PIE2D;
                        break;
                    case 3:
                        ID_COM_GPH.GraphType = CORVB.G_PIE3D;
                        break;
                }
                this.Refresh();

                Carga_Grafica();

            }

        }

        private void ID_COM_GRA_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                if (ID_COM_INF_CKB.Value)
                { //Se selecciono Ir a
                    switch (ID_COM_NIV_COB.SelectedIndex)
                    {
                        case 1:  //Grupo 
                            CORMDIBN.DefInstance.Enabled = false;
                            CORIRGRU.DefInstance.Tag = "CORGRCOM";
                            CORIRGRU.DefInstance.ShowDialog();
                            this.Refresh();
                            if (CORVAR.lgblTempNumGpo >= 0)
                            {
                                for (int iCont = 1; iCont <= ID_COM_INF_COB.Items.Count; iCont++)
                                {
                                    if (Conversion.Val(Strings.Mid(VB6.GetItemString(ID_COM_INF_COB, iCont - 1), 1, 5)) == CORVAR.lgblTempNumGpo)
                                    {
                                        ID_COM_INF_COB.SelectedIndex = iCont - 1;
                                        break;
                                    }
                                }
                                this.Cursor = Cursors.WaitCursor;
                                Carga_Graf_por_Grupo();
                            }

                            break;
                        case 2:  //Empresa 
                            CORMDIBN.DefInstance.Enabled = false;
                            CORIREMP.DefInstance.Tag = "CORGRCOM";
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
                            CORIREMP.DefInstance.ShowDialog();
                            this.Refresh();
                            if (CORVAR.lgblTempNumEmp >= 0)
                            {
                                for (int iCont = 1; iCont <= ID_COM_INF_COB.Items.Count; iCont++)
                                {
                                    //EISSA 03-10-2001. Cambios para obtener la longitud del número de empresa
                                    if (Conversion.Val(Strings.Mid(VB6.GetItemString(ID_COM_INF_COB, iCont - 1), 1, Formato.sMascara(Formato.iTipo.Empresa).Length)) == CORVAR.lgblTempNumEmp)
                                    {
                                        ID_COM_INF_COB.SelectedIndex = iCont - 1;
                                        break;
                                    }
                                }
                                this.Cursor = Cursors.WaitCursor;
                                Carga_Graf_por_Empresa();
                            }
                            break;
                    }

                }
                else
                {
                    //No selecciono Ir a
                    this.Cursor = Cursors.WaitCursor;
                    switch (ID_COM_NIV_COB.SelectedIndex)
                    {
                        case 0:  //Producto 
                            Carga_Graf_por_Producto();
                            break;
                        case 1:  //Grupo 
                            CORVAR.lgblTempNumGpo = Convert.ToInt32(Conversion.Val(ID_COM_INF_COB.Text.Substring(0, Math.Min(ID_COM_INF_COB.Text.Length, 4))));
                            Carga_Graf_por_Grupo();
                            break;
                        case 2:  //Empresa 
                            //EISSA 03-10-2001. Cambio para obtener el número de empresa. 
                            CORVAR.lgblTempNumEmp = Convert.ToInt32(Conversion.Val(ID_COM_INF_COB.Text.Substring(0, Math.Min(ID_COM_INF_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                            Carga_Graf_por_Empresa();
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_COM_GRA_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_COM_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_COM_GPH.DrawMode was not upgraded.
            ID_COM_GPH.DrawMode = CORVB.G_PRINT;

        }

        private void ID_COM_INF_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            ID_COM_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_COM_GPH.DrawMode was not upgraded.
            ID_COM_GPH.DrawMode = CORVB.G_CLEAR;
            ID_COM_GRP_PNL.Enabled = false;

            this.Cursor = Cursors.Default;

        }

        private void ID_COM_NIV_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            ID_COM_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_COM_GPH.DrawMode was not upgraded.
            ID_COM_GPH.DrawMode = CORVB.G_CLEAR;
            ID_COM_GRP_PNL.Enabled = false;

            switch (ID_COM_NIV_COB.SelectedIndex)
            {
                case 0:  //Producto 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    ID_COM_INF_COB.Items.Clear();
                    ID_COM_ETI_TXT[2].Text = CORVB.NULL_STRING;
                    ID_COM_INF_COB.Visible = false;
                    ID_COM_INF_CKB.Visible = false;
                    ID_COM_INF_CKB.Value = false;
                    ID_COM_INF_COB.Visible = false;
                    ID_COM_INF_CKB.Value = false;
                    ID_COM_GRA_PB.Enabled = true;

                    break;
                case 1:  //Grupo 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    ID_COM_INF_COB.Visible = true;
                    ID_COM_INF_CKB.Visible = true;
                    ID_COM_INF_COB.Visible = true;

                    CORVAR.igblErr = Obten_Grupos();  //Obtiene los Grupos que pertenecen a Tarjeta Corporativa 

                    break;
                case 2:  //Empresa 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    ID_COM_INF_COB.Visible = true;
                    ID_COM_INF_CKB.Visible = true;
                    ID_COM_INF_COB.Visible = true;

                    CORVAR.igblErr = Obten_Empresas();  //Obtiene las Empresas que pertenecen a Tarjeta Corporativa 

                    break;
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_COM_PER_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            ID_COM_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_COM_GPH.DrawMode was not upgraded.
            ID_COM_GPH.DrawMode = CORVB.G_CLEAR;
            ID_COM_GRP_PNL.Enabled = false;

            this.Cursor = Cursors.Default;

        }

        private void ID_COM_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //ros  If hGrupos <> NULL_INTEGER Then
            //ros    hGrupos = qeEndSQL(hGrupos)
            //ros  End If

            //ros  If hEmpresas <> NULL_INTEGER Then
            //ros    hEmpresas = qeEndSQL(hEmpresas)
            //ros  End If

            if (CORVAR.igblRetorna != CORVB.NULL_INTEGER)
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            this.Close();

        }

        private void Inicializa_Combo_Concepto()
        {

            ID_COM_CON_COB.Items.Add("# de Comp. y Disp.");
            ID_COM_CON_COB.Items.Add("Imp. de Comp. y Disp.");
            ID_COM_CON_COB.Items.Add("# de Pagos y Abonos");
            ID_COM_CON_COB.Items.Add("Imp. de Pagos y Abonos");
            ID_COM_CON_COB.Items.Add("Comisiones");
            ID_COM_CON_COB.Items.Add("Gastos de Cobranza");

            ID_COM_CON_COB.SelectedIndex = CORVB.NULL_INTEGER;

        }

        private void Inicializa_Combo_Nivel()
        {

            ID_COM_NIV_COB.Items.Add("Producto");
            ID_COM_NIV_COB.Items.Add("Grupo");
            ID_COM_NIV_COB.Items.Add("Empresa");

            ID_COM_NIV_COB.SelectedIndex = CORVB.NULL_INTEGER;

        }

        private void Inicializa_Combo_Periodo()
        {

            ID_COM_PER_COB.Items.Add("Mensual");
            ID_COM_PER_COB.Items.Add("Bimestral");
            ID_COM_PER_COB.Items.Add("Trimestral");
            ID_COM_PER_COB.Items.Add("Semestral");

            ID_COM_PER_COB.SelectedIndex = CORVB.NULL_INTEGER;

        }

        //UPGRADE_NOTE: (7001) The following declaration (Limpia_Arreglo_Importes) seems to be dead code
        //private void  Limpia_Arreglo_Importes()
        //{
        //
        //
        //for (int iCont = 1; iCont <= pszArrMesAño.GetUpperBound(0); iCont++)
        //{
        //dArrImportes[iCont] = CORVB.NULL_INTEGER;
        //}
        //
        //}

        private string Obten_Concepto()
        {

            string result = String.Empty;
            switch (ID_COM_CON_COB.SelectedIndex)
            {
                case 0:
                    result = "";
                    pszTitulo = "Número de Compras y Disposiciones";
                    break;
                case 1:
                    result = "Select sum(hih_compras_y_disp) ";
                    pszTitulo = "Importe de Compras y Disposiciones";
                    break;
                case 2:
                    result = "";
                    pszTitulo = "Número de Pagos y Abonos";
                    break;
                case 3:
                    result = "Select sum(hih_pagos_y_abonos) ";
                    pszTitulo = "Importe de Pagos y Abonos";
                    break;
                case 4:
                    result = "Select sum(hih_comisiones) ";
                    pszTitulo = "Importe de Comisiones";
                    break;
                case 5:
                    result = "Select sum(hih_intereses),sum(hih_comisiones) ";
                    pszTitulo = "Importe de Gastos de Cobranza";
                    break;
            }

            return result;
        }

        private string Obten_Emp_del_Gpo()
        {

            string result = String.Empty;
            int lEmp = 0;
            int hStmt = 0;

            string pszEmpresas = CORVB.NULL_STRING;

            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "Select emp_num From " + DB_SYB_EMP + " Where gpo_banco=" + Format$(igblBanco) + " and gpo_num=" + Format$(lgblTempNumGpo)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "Select emp_num From " + CORBD.DB_SYB_EMP + " Where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and gpo_num=" + CORVAR.lgblTempNumGpo.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****


            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lEmp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    //EISSA 03-10-2001. Cambio para obtener el número de empresa.
                    pszEmpresas = pszEmpresas + StringsHelper.Format(lEmp, Formato.sMascara(Formato.iTipo.Empresa)) + ",";
                };
                pszEmpresas = Strings.Mid(pszEmpresas, 1, pszEmpresas.Length - 1);
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            }

            result = pszEmpresas;
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return result;
        }

        //**                                                                        **
        //**       Descripción: Carga las empresas de un determinado grupo   -      **
        //**                    Corporativo a un ComboBox                           **
        //**                                                                        **
        //**       Declaración: Funcion Obten_Empresas() as integer                 **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**           True: Si existieron empresas                                 **
        //**           False: Si no los hubo                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma :                                                 **
        //**                                                                        **
        //**       Ultima modificacion:                                             **
        //**                                                                        **
        //****************************************************************************
        private int Obten_Empresas()
        {

            string pszEmpresa = String.Empty; //La empresa
            int iNumEmpresa = 0; //El consecutivo de la empresa
            int lContEmp = 0;
            string pszSentencia = String.Empty;
            int lEmpresas = 0;

            this.Cursor = Cursors.WaitCursor;

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "Select emp_num, emp_nom From " + DB_SYB_EMP + " Where gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "Select emp_num, emp_nom From " + CORBD.DB_SYB_EMP + " Where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_COM_INF_COB.Items.Clear();
                lContEmp = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    //EISSA 03-10-2001. Cambio para obtener el número de empresa.
                    ID_COM_INF_COB.Items.Add(StringsHelper.Format(iNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
                    lContEmp++;
                };
                //Colocamos a una Empresa por default
                if (ID_COM_INF_COB.Items.Count != 0)
                {
                    ID_COM_INF_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }

                lEmpresas = lContEmp;
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Ocurrio un error al intentar obtener las Empresas. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                lEmpresas = -5;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (lEmpresas == CORVB.NULL_INTEGER)
            {
                ID_COM_ETI_TXT[2].Text = CORVB.NULL_STRING;
                ID_COM_INF_COB.Enabled = false;
                ID_COM_INF_CKB.Value = false;
                ID_COM_INF_CKB.Enabled = false;
                ID_COM_GRA_PB.Enabled = false;
                this.Cursor = Cursors.Default;
                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //    MsgBox "No existen Empresas para el Banco " + Format$(igblBanco) + ". ", MB_OK + MB_ICONINFORMATION, STR_APP_TIT
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX *****
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen Empresas para el Banco " + CORVAR.igblPref.ToString() + " - " + CORVAR.igblBanco.ToString() + ". ", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                //***** FIN DE CODIGO NUEVO FSWBMX *****
            }
            else if (lEmpresas > CORVB.NULL_INTEGER)
            {
                ID_COM_ETI_TXT[2].Text = "&Empresa";
                ID_COM_INF_COB.Enabled = true;
                ID_COM_INF_CKB.Value = false;
                ID_COM_INF_CKB.Enabled = true;
                ID_COM_GRA_PB.Enabled = true;
            }
            else
            {
                ID_COM_ETI_TXT[2].Text = CORVB.NULL_STRING;
                ID_COM_INF_COB.Enabled = false;
                ID_COM_INF_CKB.Value = false;
                ID_COM_INF_CKB.Enabled = false;
                ID_COM_GRA_PB.Enabled = false;
            }

            return lEmpresas;

        }

        private void Obten_Fecha_Act()
        {


            int iMesAct = DateTime.Now.Month;
            //ros**  iAñoAct = Val(Mid$(Format$(Year(Now)), 3, 2))
            int iAñoAct = Convert.ToInt32(Conversion.Val(DateTime.Now.Year.ToString()));
            iMesalDia = iMesAct;
            iAñoalDia = iAñoAct;

            //Obtenemos el Año anterior en caso de ser necesario
            //ros**  If iAñoAct = NULL_INTEGER Then  'en caso de ser el año 2000
            //ros**    iAñoAnt = 99                  'regresamos al año de 1999
            //ros**  Else                            'en otro caso
            iAñoAnt = iAñoAct - 1; //restamos 1 al año
            //ros**  End If

            switch (iMesAct)
            {
                case 1:
                    iMenAct = 1;
                    iBimAct = 1;
                    iTrimAct = 1;
                    iSemAct = 1;
                    break;
                case 2:
                    iMenAct = 2;
                    iBimAct = 1;
                    iTrimAct = 1;
                    iSemAct = 1;
                    break;
                case 3:
                    iMenAct = 3;
                    iBimAct = 2;
                    iTrimAct = 1;
                    iSemAct = 1;
                    break;
                case 4:
                    iMenAct = 4;
                    iBimAct = 2;
                    iTrimAct = 2;
                    iSemAct = 1;
                    break;
                case 5:
                    iMenAct = 5;
                    iBimAct = 3;
                    iTrimAct = 2;
                    iSemAct = 1;
                    break;
                case 6:
                    iMenAct = 6;
                    iBimAct = 3;
                    iTrimAct = 2;
                    iSemAct = 1;
                    break;
                case 7:
                    iMenAct = 7;
                    iBimAct = 4;
                    iTrimAct = 3;
                    iSemAct = 2;
                    break;
                case 8:
                    iMenAct = 8;
                    iBimAct = 4;
                    iTrimAct = 3;
                    iSemAct = 2;
                    break;
                case 9:
                    iMenAct = 9;
                    iBimAct = 5;
                    iTrimAct = 3;
                    iSemAct = 2;
                    break;
                case 10:
                    iMenAct = 10;
                    iBimAct = 5;
                    iTrimAct = 4;
                    iSemAct = 2;
                    break;
                case 11:
                    iMenAct = 11;
                    iBimAct = 6;
                    iTrimAct = 4;
                    iSemAct = 2;
                    break;
                case 12:
                    iMenAct = 12;
                    iBimAct = 6;
                    iTrimAct = 4;
                    iSemAct = 2;
                    break;
            }

        }

        private int Obten_Grupos()
        {

            string pszNomGrupo = String.Empty; //El grupo a obtener
            int iNumGrupo = 0; //El consecutivo del grupo
            int lContGpo = 0;
            string pszSentencia = String.Empty;
            int lGrupos = 0;

            this.Cursor = Cursors.WaitCursor;

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "Select gpo_num, gpo_nom From " + DB_SYB_COR + " Where gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "Select gpo_num, gpo_nom From " + CORBD.DB_SYB_COR + " Where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****



            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_COM_INF_COB.Items.Clear();
                lContGpo = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_COM_INF_COB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
                    lContGpo++;
                };
                //Colocamos a un grupo por default
                if (ID_COM_INF_COB.Items.Count != 0)
                {
                    ID_COM_INF_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }

                lGrupos = lContGpo;
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Ocurrio un error al intentar obtener los Grupos. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                lGrupos = -5;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (lGrupos == CORVB.NULL_INTEGER)
            {
                ID_COM_ETI_TXT[2].Text = CORVB.NULL_STRING;
                ID_COM_INF_COB.Enabled = false;
                ID_COM_INF_CKB.Value = false;
                ID_COM_INF_CKB.Enabled = false;
                ID_COM_GRA_PB.Enabled = false;
                this.Cursor = Cursors.Default;
                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //    MsgBox "No existen Grupos para el Banco " + Format$(igblBanco) + ". ", MB_OK + MB_ICONINFORMATION, STR_APP_TIT
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX *****
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen Grupos para el Banco" + CORVAR.igblPref.ToString() + " - " + CORVAR.igblBanco.ToString() + ". ", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                //***** FIN DE CODIGO NUEVO FSWBMX *****

            }
            else if (lGrupos > CORVB.NULL_INTEGER)
            {
                ID_COM_ETI_TXT[2].Text = "&Grupo";
                ID_COM_INF_COB.Enabled = true;
                ID_COM_INF_CKB.Value = false;
                ID_COM_INF_CKB.Enabled = true;
                ID_COM_GRA_PB.Enabled = true;
            }
            else
            {
                ID_COM_ETI_TXT[2].Text = CORVB.NULL_STRING;
                ID_COM_INF_COB.Enabled = false;
                ID_COM_INF_CKB.Value = false;
                ID_COM_INF_CKB.Enabled = false;
                ID_COM_GRA_PB.Enabled = false;
            }

            return lGrupos;

        }

        private void Obten_Periodo()
        {

            switch (ID_COM_PER_COB.SelectedIndex)
            {
                case 0:
                    pszPie = "Mensual";
                    pszArrMesAño = ArraysHelper.InitializeArray<string[,]>(new int[] { 12, 3 }, new int[] { 0, 0 });
                    switch (iMenAct)
                    {
                        case 1:  //Reporte en periodo Mensual 
                            pszArrMesAño[1, 1] = "1";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Ene ";
                            pszArrMesAño[2, 1] = "12";
                            pszArrMesAño[2, 2] = iAñoAnt.ToString();
                            pszArrMesAño[2, 3] = "Dic ";
                            pszArrMesAño[3, 1] = "11";
                            pszArrMesAño[3, 2] = iAñoAnt.ToString();
                            pszArrMesAño[3, 3] = "Nov ";
                            pszArrMesAño[4, 1] = "10";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "Oct ";
                            pszArrMesAño[5, 1] = "9";
                            pszArrMesAño[5, 2] = iAñoAnt.ToString();
                            pszArrMesAño[5, 3] = "Sep ";
                            pszArrMesAño[6, 1] = "8";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "Ago ";
                            pszArrMesAño[7, 1] = "7";
                            pszArrMesAño[7, 2] = iAñoAnt.ToString();
                            pszArrMesAño[7, 3] = "Jul ";
                            pszArrMesAño[8, 1] = "6";
                            pszArrMesAño[8, 2] = iAñoAnt.ToString();
                            pszArrMesAño[8, 3] = "Jun ";
                            pszArrMesAño[9, 1] = "5";
                            pszArrMesAño[9, 2] = iAñoAnt.ToString();
                            pszArrMesAño[9, 3] = "May ";
                            pszArrMesAño[10, 1] = "4";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "Abr ";
                            pszArrMesAño[11, 1] = "3";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Mar ";
                            pszArrMesAño[12, 1] = "2";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Feb ";
                            break;
                        case 2:
                            pszArrMesAño[1, 1] = "2";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Feb ";
                            pszArrMesAño[2, 1] = "1";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Ene ";
                            pszArrMesAño[3, 1] = "12";
                            pszArrMesAño[3, 2] = iAñoAnt.ToString();
                            pszArrMesAño[3, 3] = "Dic ";
                            pszArrMesAño[4, 1] = "11";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "Nov ";
                            pszArrMesAño[5, 1] = "10";
                            pszArrMesAño[5, 2] = iAñoAnt.ToString();
                            pszArrMesAño[5, 3] = "Oct ";
                            pszArrMesAño[6, 1] = "9";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "Sep ";
                            pszArrMesAño[7, 1] = "8";
                            pszArrMesAño[7, 2] = iAñoAnt.ToString();
                            pszArrMesAño[7, 3] = "Ago ";
                            pszArrMesAño[8, 1] = "7";
                            pszArrMesAño[8, 2] = iAñoAnt.ToString();
                            pszArrMesAño[8, 3] = "Jul ";
                            pszArrMesAño[9, 1] = "6";
                            pszArrMesAño[9, 2] = iAñoAnt.ToString();
                            pszArrMesAño[9, 3] = "Jun ";
                            pszArrMesAño[10, 1] = "5";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "May ";
                            pszArrMesAño[11, 1] = "4";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Abr ";
                            pszArrMesAño[12, 1] = "3";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Mar ";
                            break;
                        case 3:
                            pszArrMesAño[1, 1] = "3";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Mar ";
                            pszArrMesAño[2, 1] = "2";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Feb ";
                            pszArrMesAño[3, 1] = "1";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Ene ";
                            pszArrMesAño[4, 1] = "12";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "Dic ";
                            pszArrMesAño[5, 1] = "11";
                            pszArrMesAño[5, 2] = iAñoAnt.ToString();
                            pszArrMesAño[5, 3] = "Nov ";
                            pszArrMesAño[6, 1] = "10";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "Oct ";
                            pszArrMesAño[7, 1] = "9";
                            pszArrMesAño[7, 2] = iAñoAnt.ToString();
                            pszArrMesAño[7, 3] = "Sep ";
                            pszArrMesAño[8, 1] = "8";
                            pszArrMesAño[8, 2] = iAñoAnt.ToString();
                            pszArrMesAño[8, 3] = "Ago ";
                            pszArrMesAño[9, 1] = "7";
                            pszArrMesAño[9, 2] = iAñoAnt.ToString();
                            pszArrMesAño[9, 3] = "Jul ";
                            pszArrMesAño[10, 1] = "6";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "Jun ";
                            pszArrMesAño[11, 1] = "5";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "May ";
                            pszArrMesAño[12, 1] = "4";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Abr ";
                            break;
                        case 4:
                            pszArrMesAño[1, 1] = "4";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Abr ";
                            pszArrMesAño[2, 1] = "3";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Mar ";
                            pszArrMesAño[3, 1] = "2";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Feb ";
                            pszArrMesAño[4, 1] = "1";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "Ene ";
                            pszArrMesAño[5, 1] = "12";
                            pszArrMesAño[5, 2] = iAñoAnt.ToString();
                            pszArrMesAño[5, 3] = "Dic ";
                            pszArrMesAño[6, 1] = "11";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "Nov ";
                            pszArrMesAño[7, 1] = "10";
                            pszArrMesAño[7, 2] = iAñoAnt.ToString();
                            pszArrMesAño[7, 3] = "Oct ";
                            pszArrMesAño[8, 1] = "9";
                            pszArrMesAño[8, 2] = iAñoAnt.ToString();
                            pszArrMesAño[8, 3] = "Sep ";
                            pszArrMesAño[9, 1] = "8";
                            pszArrMesAño[9, 2] = iAñoAnt.ToString();
                            pszArrMesAño[9, 3] = "Ago ";
                            pszArrMesAño[10, 1] = "7";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "Jul ";
                            pszArrMesAño[11, 1] = "6";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Jun ";
                            pszArrMesAño[12, 1] = "5";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "May ";
                            break;
                        case 5:
                            pszArrMesAño[1, 1] = "5";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "May ";
                            pszArrMesAño[2, 1] = "4";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Abr ";
                            pszArrMesAño[3, 1] = "3";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Mar ";
                            pszArrMesAño[4, 1] = "2";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "Feb ";
                            pszArrMesAño[5, 1] = "1";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "Ene ";
                            pszArrMesAño[6, 1] = "12";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "Dic ";
                            pszArrMesAño[7, 1] = "11";
                            pszArrMesAño[7, 2] = iAñoAnt.ToString();
                            pszArrMesAño[7, 3] = "Nov ";
                            pszArrMesAño[8, 1] = "10";
                            pszArrMesAño[8, 2] = iAñoAnt.ToString();
                            pszArrMesAño[8, 3] = "Oct ";
                            pszArrMesAño[9, 1] = "9";
                            pszArrMesAño[9, 2] = iAñoAnt.ToString();
                            pszArrMesAño[9, 3] = "Sep ";
                            pszArrMesAño[10, 1] = "8";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "Ago ";
                            pszArrMesAño[11, 1] = "7";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Jul ";
                            pszArrMesAño[12, 1] = "6";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Jun ";
                            break;
                        case 6:
                            pszArrMesAño[1, 1] = "6";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Jun ";
                            pszArrMesAño[2, 1] = "5";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "May ";
                            pszArrMesAño[3, 1] = "4";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Abr ";
                            pszArrMesAño[4, 1] = "3";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "Mar ";
                            pszArrMesAño[5, 1] = "2";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "Feb ";
                            pszArrMesAño[6, 1] = "1";
                            pszArrMesAño[6, 2] = iAñoalDia.ToString();
                            pszArrMesAño[6, 3] = "Ene ";
                            pszArrMesAño[7, 1] = "12";
                            pszArrMesAño[7, 2] = iAñoAnt.ToString();
                            pszArrMesAño[7, 3] = "Dic ";
                            pszArrMesAño[8, 1] = "11";
                            pszArrMesAño[8, 2] = iAñoAnt.ToString();
                            pszArrMesAño[8, 3] = "Nov ";
                            pszArrMesAño[9, 1] = "10";
                            pszArrMesAño[9, 2] = iAñoAnt.ToString();
                            pszArrMesAño[9, 3] = "Oct ";
                            pszArrMesAño[10, 1] = "9";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "Sep ";
                            pszArrMesAño[11, 1] = "8";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Ago ";
                            pszArrMesAño[12, 1] = "7";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Jul ";
                            break;
                        case 7:
                            pszArrMesAño[1, 1] = "7";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Jul ";
                            pszArrMesAño[2, 1] = "6";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Jun ";
                            pszArrMesAño[3, 1] = "5";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "May ";
                            pszArrMesAño[4, 1] = "4";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "Abr ";
                            pszArrMesAño[5, 1] = "3";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "Mar ";
                            pszArrMesAño[6, 1] = "2";
                            pszArrMesAño[6, 2] = iAñoalDia.ToString();
                            pszArrMesAño[6, 3] = "Feb ";
                            pszArrMesAño[7, 1] = "1";
                            pszArrMesAño[7, 2] = iAñoalDia.ToString();
                            pszArrMesAño[7, 3] = "Ene ";
                            pszArrMesAño[8, 1] = "12";
                            pszArrMesAño[8, 2] = iAñoAnt.ToString();
                            pszArrMesAño[8, 3] = "Dic ";
                            pszArrMesAño[9, 1] = "11";
                            pszArrMesAño[9, 2] = iAñoAnt.ToString();
                            pszArrMesAño[9, 3] = "Nov ";
                            pszArrMesAño[10, 1] = "10";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "Oct ";
                            pszArrMesAño[11, 1] = "9";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Sep ";
                            pszArrMesAño[12, 1] = "8";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Ago ";
                            break;
                        case 8:
                            pszArrMesAño[1, 1] = "8";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Ago ";
                            pszArrMesAño[2, 1] = "7";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Jul ";
                            pszArrMesAño[3, 1] = "6";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Jun ";
                            pszArrMesAño[4, 1] = "5";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "May ";
                            pszArrMesAño[5, 1] = "4";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "Abr ";
                            pszArrMesAño[6, 1] = "3";
                            pszArrMesAño[6, 2] = iAñoalDia.ToString();
                            pszArrMesAño[6, 3] = "Mar ";
                            pszArrMesAño[7, 1] = "2";
                            pszArrMesAño[7, 2] = iAñoalDia.ToString();
                            pszArrMesAño[7, 3] = "Feb ";
                            pszArrMesAño[8, 1] = "1";
                            pszArrMesAño[8, 2] = iAñoalDia.ToString();
                            pszArrMesAño[8, 3] = "Ene ";
                            pszArrMesAño[9, 1] = "12";
                            pszArrMesAño[9, 2] = iAñoAnt.ToString();
                            pszArrMesAño[9, 3] = "Dic ";
                            pszArrMesAño[10, 1] = "11";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "Nov ";
                            pszArrMesAño[11, 1] = "10";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Oct ";
                            pszArrMesAño[12, 1] = "9";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Sep ";
                            break;
                        case 9:
                            pszArrMesAño[1, 1] = "9";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Sep ";
                            pszArrMesAño[2, 1] = "8";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Ago ";
                            pszArrMesAño[3, 1] = "7";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Jul ";
                            pszArrMesAño[4, 1] = "6";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "Jun ";
                            pszArrMesAño[5, 1] = "5";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "May ";
                            pszArrMesAño[6, 1] = "4";
                            pszArrMesAño[6, 2] = iAñoalDia.ToString();
                            pszArrMesAño[6, 3] = "Abr ";
                            pszArrMesAño[7, 1] = "3";
                            pszArrMesAño[7, 2] = iAñoalDia.ToString();
                            pszArrMesAño[7, 3] = "Mar ";
                            pszArrMesAño[8, 1] = "2";
                            pszArrMesAño[8, 2] = iAñoalDia.ToString();
                            pszArrMesAño[8, 3] = "Feb ";
                            pszArrMesAño[9, 1] = "1";
                            pszArrMesAño[9, 2] = iAñoalDia.ToString();
                            pszArrMesAño[9, 3] = "Ene ";
                            pszArrMesAño[10, 1] = "12";
                            pszArrMesAño[10, 2] = iAñoAnt.ToString();
                            pszArrMesAño[10, 3] = "Dic ";
                            pszArrMesAño[11, 1] = "11";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Nov ";
                            pszArrMesAño[12, 1] = "10";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Oct ";
                            break;
                        case 10:
                            pszArrMesAño[1, 1] = "10";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Oct ";
                            pszArrMesAño[2, 1] = "9";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Sep ";
                            pszArrMesAño[3, 1] = "8";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Ago ";
                            pszArrMesAño[4, 1] = "7";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "Jul ";
                            pszArrMesAño[5, 1] = "6";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "Jun ";
                            pszArrMesAño[6, 1] = "5";
                            pszArrMesAño[6, 2] = iAñoalDia.ToString();
                            pszArrMesAño[6, 3] = "May ";
                            pszArrMesAño[7, 1] = "4";
                            pszArrMesAño[7, 2] = iAñoalDia.ToString();
                            pszArrMesAño[7, 3] = "Abr ";
                            pszArrMesAño[8, 1] = "3";
                            pszArrMesAño[8, 2] = iAñoalDia.ToString();
                            pszArrMesAño[8, 3] = "Mar ";
                            pszArrMesAño[9, 1] = "2";
                            pszArrMesAño[9, 2] = iAñoalDia.ToString();
                            pszArrMesAño[9, 3] = "Feb ";
                            pszArrMesAño[10, 1] = "1";
                            pszArrMesAño[10, 2] = iAñoalDia.ToString();
                            pszArrMesAño[10, 3] = "Ene ";
                            pszArrMesAño[11, 1] = "12";
                            pszArrMesAño[11, 2] = iAñoAnt.ToString();
                            pszArrMesAño[11, 3] = "Dic ";
                            pszArrMesAño[12, 1] = "11";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Nov ";
                            break;
                        case 11:
                            pszArrMesAño[1, 1] = "11";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Nov ";
                            pszArrMesAño[2, 1] = "10";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Oct ";
                            pszArrMesAño[3, 1] = "9";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Sep ";
                            pszArrMesAño[4, 1] = "8";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "Ago ";
                            pszArrMesAño[5, 1] = "7";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "Jul ";
                            pszArrMesAño[6, 1] = "6";
                            pszArrMesAño[6, 2] = iAñoalDia.ToString();
                            pszArrMesAño[6, 3] = "Jun ";
                            pszArrMesAño[7, 1] = "5";
                            pszArrMesAño[7, 2] = iAñoalDia.ToString();
                            pszArrMesAño[7, 3] = "May ";
                            pszArrMesAño[8, 1] = "4";
                            pszArrMesAño[8, 2] = iAñoalDia.ToString();
                            pszArrMesAño[8, 3] = "Abr ";
                            pszArrMesAño[9, 1] = "3";
                            pszArrMesAño[9, 2] = iAñoalDia.ToString();
                            pszArrMesAño[9, 3] = "Mar ";
                            pszArrMesAño[10, 1] = "2";
                            pszArrMesAño[10, 2] = iAñoalDia.ToString();
                            pszArrMesAño[10, 3] = "Feb ";
                            pszArrMesAño[11, 1] = "1";
                            pszArrMesAño[11, 2] = iAñoalDia.ToString();
                            pszArrMesAño[11, 3] = "Ene ";
                            pszArrMesAño[12, 1] = "12";
                            pszArrMesAño[12, 2] = iAñoAnt.ToString();
                            pszArrMesAño[12, 3] = "Dic ";
                            break;
                        case 12:
                            pszArrMesAño[1, 1] = "12";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "Dic ";
                            pszArrMesAño[2, 1] = "11";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "Nov ";
                            pszArrMesAño[3, 1] = "10";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "Oct ";
                            pszArrMesAño[4, 1] = "9";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "Sep ";
                            pszArrMesAño[5, 1] = "8";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "Ago ";
                            pszArrMesAño[6, 1] = "7";
                            pszArrMesAño[6, 2] = iAñoalDia.ToString();
                            pszArrMesAño[6, 3] = "Jul ";
                            pszArrMesAño[7, 1] = "6";
                            pszArrMesAño[7, 2] = iAñoalDia.ToString();
                            pszArrMesAño[7, 3] = "Jun ";
                            pszArrMesAño[8, 1] = "5";
                            pszArrMesAño[8, 2] = iAñoalDia.ToString();
                            pszArrMesAño[8, 3] = "May ";
                            pszArrMesAño[9, 1] = "4";
                            pszArrMesAño[9, 2] = iAñoalDia.ToString();
                            pszArrMesAño[9, 3] = "Abr ";
                            pszArrMesAño[10, 1] = "3";
                            pszArrMesAño[10, 2] = iAñoalDia.ToString();
                            pszArrMesAño[10, 3] = "Mar ";
                            pszArrMesAño[11, 1] = "2";
                            pszArrMesAño[11, 2] = iAñoalDia.ToString();
                            pszArrMesAño[11, 3] = "Feb ";
                            pszArrMesAño[12, 1] = "1";
                            pszArrMesAño[12, 2] = iAñoalDia.ToString();
                            pszArrMesAño[12, 3] = "Ene ";
                            break;
                    }
                    break;
                case 1:  //Reporte en periodo Bimestral 
                    pszPie = "Bimestral";
                    pszArrMesAño = ArraysHelper.InitializeArray<string[,]>(new int[] { 6, 3 }, new int[] { 0, 0 });
                    switch (iBimAct)
                    {
                        case 1:
                            pszArrMesAño[1, 1] = "1,2";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "1er Bim ";
                            pszArrMesAño[2, 1] = "11,12";
                            pszArrMesAño[2, 2] = iAñoAnt.ToString();
                            pszArrMesAño[2, 3] = "6o Bim ";
                            pszArrMesAño[3, 1] = "9,10";
                            pszArrMesAño[3, 2] = iAñoAnt.ToString();
                            pszArrMesAño[3, 3] = "5o Bim ";
                            pszArrMesAño[4, 1] = "7,8";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "4o Bim ";
                            pszArrMesAño[5, 1] = "5,6";
                            pszArrMesAño[5, 2] = iAñoAnt.ToString();
                            pszArrMesAño[5, 3] = "3er Bim ";
                            pszArrMesAño[6, 1] = "3,4";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "2o Bim ";
                            break;
                        case 2:
                            pszArrMesAño[1, 1] = "3,4";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "2o Bim ";
                            pszArrMesAño[2, 1] = "1,2";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "1er Bim ";
                            pszArrMesAño[3, 1] = "11,12";
                            pszArrMesAño[3, 2] = iAñoAnt.ToString();
                            pszArrMesAño[3, 3] = "6o Bim ";
                            pszArrMesAño[4, 1] = "9,10";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "5o Bim ";
                            pszArrMesAño[5, 1] = "7,8";
                            pszArrMesAño[5, 2] = iAñoAnt.ToString();
                            pszArrMesAño[5, 3] = "4o Bim ";
                            pszArrMesAño[6, 1] = "5,6";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "3er Bim ";
                            break;
                        case 3:
                            pszArrMesAño[1, 1] = "5,6";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "3er Bim ";
                            pszArrMesAño[2, 1] = "3,4";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "2o Bim ";
                            pszArrMesAño[3, 1] = "1,2";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "1er Bim ";
                            pszArrMesAño[4, 1] = "11,12";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "6o Bim ";
                            pszArrMesAño[5, 1] = "9,10";
                            pszArrMesAño[5, 2] = iAñoAnt.ToString();
                            pszArrMesAño[5, 3] = "5o Bim ";
                            pszArrMesAño[6, 1] = "7,8";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "4o Bim ";
                            break;
                        case 4:
                            pszArrMesAño[1, 1] = "7,8";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "4o Bim ";
                            pszArrMesAño[2, 1] = "5,6";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "3er Bim ";
                            pszArrMesAño[3, 1] = "3,4";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "2o Bim ";
                            pszArrMesAño[4, 1] = "1,2";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "1er Bim ";
                            pszArrMesAño[5, 1] = "11,12";
                            pszArrMesAño[5, 2] = iAñoAnt.ToString();
                            pszArrMesAño[5, 3] = "6o Bim ";
                            pszArrMesAño[6, 1] = "9,10";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "5o Bim ";
                            break;
                        case 5:
                            pszArrMesAño[1, 1] = "9,10";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "5o Bim ";
                            pszArrMesAño[2, 1] = "7,8";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "4o Bim ";
                            pszArrMesAño[3, 1] = "5,6";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "3er Bim ";
                            pszArrMesAño[4, 1] = "3,4";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "2o Bim ";
                            pszArrMesAño[5, 1] = "1,2";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "1er Bim ";
                            pszArrMesAño[6, 1] = "11,12";
                            pszArrMesAño[6, 2] = iAñoAnt.ToString();
                            pszArrMesAño[6, 3] = "6o Bim ";
                            break;
                        case 6:
                            pszArrMesAño[1, 1] = "11,12";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "6o Bim ";
                            pszArrMesAño[2, 1] = "9,10";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "5o Bim ";
                            pszArrMesAño[3, 1] = "7,8";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "4o Bim ";
                            pszArrMesAño[4, 1] = "5,6";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "3er Bim ";
                            pszArrMesAño[5, 1] = "3,4";
                            pszArrMesAño[5, 2] = iAñoalDia.ToString();
                            pszArrMesAño[5, 3] = "2o Bim ";
                            pszArrMesAño[6, 1] = "1,2";
                            pszArrMesAño[6, 2] = iAñoalDia.ToString();
                            pszArrMesAño[6, 3] = "1er Bim ";
                            break;
                    }
                    break;
                case 2:  //Reporte en periodo Trimestral 
                    pszPie = "Trimestral";
                    pszArrMesAño = ArraysHelper.InitializeArray<string[,]>(new int[] { 4, 3 }, new int[] { 0, 0 });
                    switch (iTrimAct)
                    {
                        case 1:
                            pszArrMesAño[1, 1] = "1,2,3";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "1er Trim ";
                            pszArrMesAño[2, 1] = "10,11,12";
                            pszArrMesAño[2, 2] = iAñoAnt.ToString();
                            pszArrMesAño[2, 3] = "4o Trim ";
                            pszArrMesAño[3, 1] = "7,8,9";
                            pszArrMesAño[3, 2] = iAñoAnt.ToString();
                            pszArrMesAño[3, 3] = "3er Trim ";
                            pszArrMesAño[4, 1] = "4,5,6";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "2o Trim ";
                            break;
                        case 2:
                            pszArrMesAño[1, 1] = "4,5,6";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "2o Trim ";
                            pszArrMesAño[2, 1] = "1,2,3";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "1er Trim ";
                            pszArrMesAño[3, 1] = "10,11,12";
                            pszArrMesAño[3, 2] = iAñoAnt.ToString();
                            pszArrMesAño[3, 3] = "4o Trim ";
                            pszArrMesAño[4, 1] = "7,8,9";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "3er Trim ";
                            break;
                        case 3:
                            pszArrMesAño[1, 1] = "7,8,9";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "3er Trim ";
                            pszArrMesAño[2, 1] = "4,5,6";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "2o Trim ";
                            pszArrMesAño[3, 1] = "1,2,3";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "1er Trim ";
                            pszArrMesAño[4, 1] = "10,11,12";
                            pszArrMesAño[4, 2] = iAñoAnt.ToString();
                            pszArrMesAño[4, 3] = "4o Trim ";
                            break;
                        case 4:
                            pszArrMesAño[1, 1] = "10,11,12";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "4o Trim ";
                            pszArrMesAño[2, 1] = "7,8,9";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "3er Trim ";
                            pszArrMesAño[3, 1] = "4,5,6";
                            pszArrMesAño[3, 2] = iAñoalDia.ToString();
                            pszArrMesAño[3, 3] = "2o Trim ";
                            pszArrMesAño[4, 1] = "1,2,3";
                            pszArrMesAño[4, 2] = iAñoalDia.ToString();
                            pszArrMesAño[4, 3] = "1er Trim ";
                            break;
                    }
                    break;
                case 3:  //Reporte en periodo Semestral 
                    pszPie = "Semestral";
                    pszArrMesAño = ArraysHelper.InitializeArray<string[,]>(new int[] { 2, 3 }, new int[] { 0, 0 });
                    switch (iSemAct)
                    {
                        case 1:
                            pszArrMesAño[1, 1] = "1,2,3,4,5,6";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "1er Sem ";
                            pszArrMesAño[2, 1] = "7,8,9,10,11,12";
                            pszArrMesAño[2, 2] = iAñoAnt.ToString();
                            pszArrMesAño[2, 3] = "2o Sem ";
                            break;
                        case 2:
                            pszArrMesAño[1, 1] = "7,8,9,10,11,12";
                            pszArrMesAño[1, 2] = iAñoalDia.ToString();
                            pszArrMesAño[1, 3] = "2o Sem ";
                            pszArrMesAño[2, 1] = "1,2,3,4,5,6";
                            pszArrMesAño[2, 2] = iAñoalDia.ToString();
                            pszArrMesAño[2, 3] = "1er Sem ";
                            break;
                    }
                    break;
            }

        }
        private void CORGRCOM_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}