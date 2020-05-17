using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORGRACL
        : System.Windows.Forms.Form
    {


        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Grafica de aclaraciones capturadas en multerm       **
        //**                    e integradas                                        **
        //**                                                                        **
        //**       Responsable: Felipe Zacarias Jimenez                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        const int INT_FONTSIZE_TIT = 150;
        const int INT_FONTSIZE_OTROS = 100;

        //Arreglo para almacenar los cantidades de Aclaraciones para cada columna de la gráfica
        int[] lArrCantidades = null;

        //Arreglo para almacenar los nombres de las Empresas que presentan Aclaraciones
        string[] pszArrNomEmp = null;

        //Arreglo para almacenar el numero de Aclaraciones que existen para los Tipos de Aclaraciones que se manejan
        int[,] lArrTipAcl = null;

        //Arreglo para almacenar las descripciones de los Tipos de Aclaraciones que se manejan
        string[] pszArrTipAcl = null;

        //Arreglo para almacenar el numero de Status las Aclaraciones
        int[] lArrStatAcl = null;

        //Arreglo para almacenar las descripciones de los Status de Aclaraciones que se manejan
        string[] pszArrStatAcl = null;

        //Arreglo para almacenar el numero de Aclaraciones con cierto Origen
        int[] lArrOrigAcl = null;

        //Arreglo para almacenar las descripciones de los Origenes de las Aclaraciones que se manejan
        string[] pszArrOrigAcl = null;

        //Variables para las conexiones a la Base de Datos
        int hConexion = 0;

        //Variables para el handel a empresas
        int hEmpresas = 0;

        //Variables del Total de Elementos de los Combos
        int lTotalEmpresas = 0;

        //Variable para controlar el numero de Grupos y Empresas Restantes
        int lEmpresasRestantes = 0;

        //Variables para los textos de la Gráfica
        string pszTitulo = String.Empty;
        string pszPie = String.Empty;

        //Variable para indicar si se Despliegan los LabelText de la Gráfica
        int bExistenDat = 0;

        //Variable para Almacenar el ultimo Tipo de Gráfica Activa
        int iTipoAct = 0;

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

        private void Cambia_Status_Botones(int bExistAcl)
        {

            if (~bExistAcl != 0)
            {
                bExistenDat = 0; //No mostrar Leyend Text
                ID_ACL_GRP_PNL.Enabled = false;
            }
            else
            {
                bExistenDat = -1; //Mostrar Leyend Text
                ID_ACL_GRP_PNL.Enabled = true;
                Carga_Grafica();
            }

        }

        private void Carga_Acl_Emp()
        {

            int iCont = 0;
            int hStmt = 0;
            int lTotEmp = 0;
            string pszNomEmp = String.Empty;
            string ppszNomEmp = String.Empty;

            pszTitulo = "Número de Aclaraciones por Empresa"; //Titulo para la Gráfica

            lArrCantidades = new int[2];
            pszArrNomEmp = new string[] { String.Empty, String.Empty };

            string pszSentencia = CORVB.NULL_STRING;

            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "exec graacl_carga_emp " + Format$(igblBanco) + "," + Format$(lgblTempNumEmp)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "exec graacl_carga_emp " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblTempNumEmp.ToString();
            //***** FIN DE CODIGO FIN FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    lArrCantidades[1] = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    ppszNomEmp = pszNomEmp;
                    pszArrNomEmp[1] = ppszNomEmp.Trim();
                }

                if (~Existen_Aclaraciones() != 0)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    Cambia_Status_Botones(0);
                }
                else
                {
                    Cambia_Status_Botones(-1);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No hay información para esta grafica.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                Cambia_Status_Botones(0);
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void Carga_Grafica()
        {

            int iCont = 0;
            int lTotal = 0;
            int lTotalAcl = 0;
            string pszTitAba = String.Empty;

            ID_ACL_GPH.DataReset = CORVB.G_ALL_DATA;
            string pszTitIzq = CORVB.NULL_STRING;

            switch (ID_ACL_TIP_COB.SelectedIndex)
            {
                case 0:
                    if (lArrCantidades.GetUpperBound(0) <= 1)
                    {
                        ID_ACL_GPH.NumPoints = 2;
                    }
                    else
                    {
                        ID_ACL_GPH.NumPoints = (short)lArrCantidades.GetUpperBound(0);
                    }
                    ID_ACL_GPH.ThisPoint = 1;
                    for (iCont = 1; iCont <= lArrCantidades.GetUpperBound(0); iCont++)
                    {
                        ID_ACL_GPH.GraphData = lArrCantidades[iCont];
                        lTotal += lArrCantidades[iCont];
                    }

                    if (bExistenDat != 0)
                    {
                        if ((ID_ACL_GRA_GPB[0].Value) || (ID_ACL_GRA_GPB[1].Value))
                        {
                            ID_ACL_GPH.GraphStyle = (short)CORVB.NULL_INTEGER;
                            ID_ACL_GPH.ThisPoint = 1;
                            for (iCont = 1; iCont <= pszArrNomEmp.GetUpperBound(0); iCont++)
                            {
                                ID_ACL_GPH.LegendText = iCont.ToString() + " - " + pszArrNomEmp[iCont];
                            }
                        }
                    }

                    if ((ID_ACL_GRA_GPB[2].Value) || (ID_ACL_GRA_GPB[3].Value))
                    {
                        ID_ACL_GPH.GraphStyle = (short)CORVB.G_PERCENTAGE;
                        for (iCont = 1; iCont <= pszArrNomEmp.GetUpperBound(0); iCont++)
                        {
                            ID_ACL_GPH.LegendText = iCont.ToString() + " - " + pszArrNomEmp[iCont];
                        }
                    }

                    if (ID_ACL_GPH.GraphType == CORVB.G_PIE3D || ID_ACL_GPH.GraphType == CORVB.G_PIE2D)
                    {
                        pszTitIzq = "Total Aclaraciones = " + StringsHelper.Format(lTotal, "#######0");
                        pszTitAba = CORVB.NULL_STRING;
                    }
                    else
                    {
                        pszTitIzq = "Aclaraciones";
                        pszTitAba = "Empresas";
                    }

                    break;
                case 1:
                case 2:
                    if (lArrTipAcl.GetUpperBound(0) > 10)
                    {
                        ID_ACL_GPH.NumPoints = 11;
                    }
                    else
                    {
                        ID_ACL_GPH.NumPoints = (short)lArrTipAcl.GetUpperBound(0);
                    }

                    lTotalAcl = CORVB.NULL_INTEGER;
                    ID_ACL_GPH.ThisPoint = 1;
                    for (iCont = 1; iCont <= lArrTipAcl.GetUpperBound(0); iCont++)
                    {
                        if (iCont <= 10)
                        {
                            ID_ACL_GPH.GraphData = lArrTipAcl[iCont, 1];
                        }
                        else
                        {
                            lTotalAcl += lArrTipAcl[iCont, 1];
                        }
                        lTotal += lArrTipAcl[iCont, 1];
                    }
                    if (iCont > 10)
                    {
                        ID_ACL_GPH.GraphData = lTotalAcl;
                    }

                    if (bExistenDat != 0)
                    {
                        if ((ID_ACL_GRA_GPB[0].Value) || (ID_ACL_GRA_GPB[1].Value))
                        {
                            ID_ACL_GPH.GraphStyle = (short)CORVB.NULL_INTEGER;
                            ID_ACL_GPH.ThisPoint = 1;
                            for (iCont = 1; iCont <= pszArrTipAcl.GetUpperBound(0); iCont++)
                            {
                                if (iCont <= 10)
                                {
                                    ID_ACL_GPH.LegendText = iCont.ToString() + " - " + lArrTipAcl[iCont, 2].ToString() + " " + pszArrTipAcl[iCont];
                                }
                            }
                            if (iCont > 10)
                            {
                                ID_ACL_GPH.LegendText = "11 - Otros";
                            }
                        }
                    }

                    if ((ID_ACL_GRA_GPB[2].Value) || (ID_ACL_GRA_GPB[3].Value))
                    {
                        ID_ACL_GPH.GraphStyle = (short)CORVB.G_PERCENTAGE;
                        for (iCont = 1; iCont <= pszArrTipAcl.GetUpperBound(0); iCont++)
                        {
                            if (iCont <= 10)
                            {
                                ID_ACL_GPH.LegendText = iCont.ToString() + " - " + lArrTipAcl[iCont, 2].ToString() + " " + pszArrTipAcl[iCont];
                            }
                        }
                        if (iCont > 10)
                        {
                            ID_ACL_GPH.LegendText = "11 - Otros";
                        }
                    }

                    if (ID_ACL_GPH.GraphType == CORVB.G_PIE3D || ID_ACL_GPH.GraphType == CORVB.G_PIE2D)
                    {
                        pszTitIzq = "Total Aclaraciones = " + StringsHelper.Format(lTotal, "#######0");
                        pszTitAba = CORVB.NULL_STRING;
                    }
                    else
                    {
                        pszTitIzq = "Aclaraciones";
                        pszTitAba = "Tipos de Aclaraciones";
                    }

                    break;
                case 3:
                case 4:
                    ID_ACL_GPH.NumPoints = (short)lArrStatAcl.GetUpperBound(0);
                    ID_ACL_GPH.ThisPoint = 1;
                    for (iCont = 1; iCont <= lArrStatAcl.GetUpperBound(0); iCont++)
                    {
                        ID_ACL_GPH.GraphData = lArrStatAcl[iCont];
                        lTotal += lArrStatAcl[iCont];
                    }

                    if (bExistenDat != 0)
                    {
                        if ((ID_ACL_GRA_GPB[0].Value) || (ID_ACL_GRA_GPB[1].Value))
                        {
                            ID_ACL_GPH.GraphStyle = (short)CORVB.NULL_INTEGER;
                            ID_ACL_GPH.ThisPoint = 1;
                            for (iCont = 1; iCont <= pszArrStatAcl.GetUpperBound(0); iCont++)
                            {
                                ID_ACL_GPH.LegendText = iCont.ToString() + " - " + pszArrStatAcl[iCont];
                            }
                        }
                    }

                    if ((ID_ACL_GRA_GPB[2].Value) || (ID_ACL_GRA_GPB[3].Value))
                    {
                        ID_ACL_GPH.GraphStyle = (short)CORVB.G_PERCENTAGE;
                        for (iCont = 1; iCont <= pszArrStatAcl.GetUpperBound(0); iCont++)
                        {
                            ID_ACL_GPH.LegendText = iCont.ToString() + " - " + pszArrStatAcl[iCont];
                        }
                    }

                    if (ID_ACL_GPH.GraphType == CORVB.G_PIE3D || ID_ACL_GPH.GraphType == CORVB.G_PIE2D)
                    {
                        pszTitIzq = "Total Aclaraciones = " + StringsHelper.Format(lTotal, "#######0");
                        pszTitAba = CORVB.NULL_STRING;
                    }
                    else
                    {
                        pszTitIzq = "Aclaraciones";
                        pszTitAba = "Status de Aclaraciones";
                    }

                    break;
                case 5:
                case 6:
                    ID_ACL_GPH.NumPoints = (short)lArrOrigAcl.GetUpperBound(0);
                    ID_ACL_GPH.ThisPoint = 1;
                    for (iCont = 1; iCont <= lArrOrigAcl.GetUpperBound(0); iCont++)
                    {
                        ID_ACL_GPH.GraphData = lArrOrigAcl[iCont];
                        lTotal += lArrOrigAcl[iCont];
                    }

                    if (bExistenDat != 0)
                    {
                        if ((ID_ACL_GRA_GPB[0].Value) || (ID_ACL_GRA_GPB[1].Value))
                        {
                            ID_ACL_GPH.GraphStyle = (short)CORVB.NULL_INTEGER;
                            ID_ACL_GPH.ThisPoint = 1;
                            for (iCont = 1; iCont <= pszArrOrigAcl.GetUpperBound(0); iCont++)
                            {
                                ID_ACL_GPH.LegendText = iCont.ToString() + " - " + pszArrOrigAcl[iCont];
                            }
                        }
                    }

                    if ((ID_ACL_GRA_GPB[2].Value) || (ID_ACL_GRA_GPB[3].Value))
                    {
                        ID_ACL_GPH.GraphStyle = (short)CORVB.G_PERCENTAGE;
                        for (iCont = 1; iCont <= pszArrOrigAcl.GetUpperBound(0); iCont++)
                        {
                            ID_ACL_GPH.LegendText = iCont.ToString() + " - " + pszArrOrigAcl[iCont];
                        }
                    }

                    if (ID_ACL_GPH.GraphType == CORVB.G_PIE3D || ID_ACL_GPH.GraphType == CORVB.G_PIE2D)
                    {
                        pszTitIzq = "Total Aclaraciones = " + StringsHelper.Format(lTotal, "#######0");
                        pszTitAba = CORVB.NULL_STRING;
                    }
                    else
                    {
                        pszTitIzq = "Aclaraciones";
                        pszTitAba = "Origen de la Aclaración";
                    }
                    break;
            }

            switch (ID_ACL_TIP_COB.SelectedIndex)
            {
                case 0:
                case 2:
                case 4:
                case 6:
                    pszTitAba = pszTitAba + "   " + ID_ACL_INF_COB.Text.Trim();
                    break;
            }

            ID_ACL_GPH.GraphTitle = pszTitulo;
            ID_ACL_GPH.LeftTitle = pszTitIzq;
            ID_ACL_GPH.BottomTitle = pszTitAba;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_ACL_GPH.DrawMode was not upgraded.
            ID_ACL_GPH.DrawMode = CORVB.G_DRAW;

        }

        private void Carga_por_Orig_Acl()
        {

            int hStmt = 0;

            Inicializa_Orig_Acl();

            string pszCondicion = CORVB.NULL_STRING;
            string pszSentencia = CORVB.NULL_STRING;

            switch (ID_ACL_TIP_COB.SelectedIndex)
            {
                case 5:  //Status de Aclaración Global 
                    //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                    //      pszgblsql = "exec graacl_carga_redi " + Format$(igblBanco) 
                    //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                    //***** INICIO CODIGO NUEVO FSWBMX ***** 
                    CORVAR.pszgblsql = "exec graacl_carga_redi " + CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                    pszTitulo = "Origen de Aclaración por Producto";
                    break;
                case 6:  //Status de Aclaración por Empresa 
                    //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                    //      pszgblsql = "exec graacl_carga_red " + Format$(igblBanco) + "," + Format$(lgblTempNumEmp) + " " 
                    //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                    //***** INICIO CODIGO NUEVO FSWBMX ***** 
                    CORVAR.pszgblsql = "exec graacl_carga_red " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblTempNumEmp.ToString() + " ";
                    //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                    pszTitulo = "Origen de Aclaración por Empresa";
                    break;
            }


            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    Separa_Orig_Aclaracion(hStmt);
                };
                if (~Existen_Aclaraciones() != 0)
                { //No Existe por lo menos un importe mayor a cero
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    Cambia_Status_Botones(0);
                }
                else
                {
                    //Existe por lo menos un importe mayor a cero
                    Cambia_Status_Botones(-1);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Ocurrio un error al intentar obtener la Información para la Gráfica. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                Cambia_Status_Botones(0);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void Carga_por_Stat_Acl()
        {

            int hStmt = 0;

            Inicializa_Stat_Acl();

            string pszCondicion = CORVB.NULL_STRING;
            string pszSentencia = CORVB.NULL_STRING;

            switch (ID_ACL_TIP_COB.SelectedIndex)
            {
                case 3:  //Status de Aclaración Global 
                    //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                    //      pszgblsql = "exec graacl_carga_stat " + Format$(igblBanco) 
                    //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                    //***** INICIO CODIGO NUEVO FSWBMX ***** 
                    CORVAR.pszgblsql = "exec graacl_carga_stat " + CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                    pszTitulo = "Status de Aclaración por Producto";
                    break;
                case 4:  //Status de Aclaración por Empresa 
                    //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                    //      pszgblsql = "exec graacl_carga_sta " + Format$(igblBanco) + "," + Format$(lgblTempNumEmp) + " " 
                    //***** FIN  CODIGO ANTERIOR FSWBMX ***** 
                    //***** INICIO CODIGO NUEVO FSWBMX ***** 
                    CORVAR.pszgblsql = "exec graacl_carga_sta " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblTempNumEmp.ToString() + " ";
                    //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                    pszTitulo = "Status de Aclaración por Empresa";
                    break;
            }

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    Separa_Stat_Aclaracion(hStmt);
                };
                //Carga_Grafica
                if (~Existen_Aclaraciones() != 0)
                { //No Existe por lo menos un importe mayor a cero
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    Cambia_Status_Botones(0);
                }
                else
                {
                    //Existe por lo menos un importe mayor a cero
                    Cambia_Status_Botones(-1);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Ocurrio un error al intentar obtener la Información para la Gráfica. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                Cambia_Status_Botones(0);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private void Carga_por_Tipo_Acl()
        {

            int hStmt = 0;

            Inicializa_Tip_Acl();

            string pszCondicion = CORVB.NULL_STRING;
            string pszSentencia = CORVB.NULL_STRING;
            switch (ID_ACL_TIP_COB.SelectedIndex)
            {
                case 1:  //Tipo de Aclaración Global 
                    //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                    //      pszgblsql = "exec graacl_carga_tipo " + Format$(igblBanco) 
                    //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                    //***** INICIO CODIGO NUEVO FSWBMX ***** 
                    CORVAR.pszgblsql = "exec graacl_carga_tipo " + CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                    pszTitulo = "Tipo de Aclaración por Producto";  //Titulo para la Gráfica 
                    break;
                case 2:  //Tipo de Aclaración por Empresa 
                    //***** INICIO CODIGO ANTERIOR FSWBMX ***** 
                    //     pszgblsql = "exec graacl_carga_tip " + Format$(igblBanco) + "," + Format$(lgblTempNumEmp) 
                    //***** FIN DE CODIGO ANTERIOR FSWBMX ***** 
                    //***** INICIO CODIGO NUEVO FSWBMX ***** 
                    CORVAR.pszgblsql = "exec graacl_carga_tip " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblTempNumEmp.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX ***** 
                    pszTitulo = "Tipo de Aclaración por Empresa";  //Titulo para la Gráfica 
                    break;
            }

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    Separa_Tip_Aclaracion(hStmt);
                };
                if (~Existen_Aclaraciones() != 0)
                { //No Existe por lo menos un importe mayor a cero
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    Cambia_Status_Botones(0);
                }
                else
                {
                    //Existe por lo menos un importe mayor a cero
                    Cambia_Status_Botones(-1);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Ocurrio un error al intentar obtener la Información para la Gráfica. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                Cambia_Status_Botones(0);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private int Existen_Aclaraciones()
        {

            int result = 0;

            result = 0;

            switch (ID_ACL_TIP_COB.SelectedIndex)
            {
                case 0:
                    for (int iCont = 1; iCont <= lArrCantidades.GetUpperBound(0); iCont++)
                    {
                        if (lArrCantidades[iCont] != CORVB.NULL_INTEGER)
                        {
                            result = -1;
                            break;
                        }
                    }

                    break;
                case 1:
                case 2:
                    for (int iCont = 1; iCont <= lArrTipAcl.GetUpperBound(0); iCont++)
                    {
                        if (lArrTipAcl[iCont, 1] != CORVB.NULL_INTEGER)
                        {
                            result = -1;
                            break;
                        }
                    }

                    break;
                case 3:
                case 4:
                    for (int iCont = 1; iCont <= lArrStatAcl.GetUpperBound(0); iCont++)
                    {
                        if (lArrStatAcl[iCont] != CORVB.NULL_INTEGER)
                        {
                            result = -1;
                            break;
                        }
                    }

                    break;
                case 5:
                case 6:
                    for (int iCont = 1; iCont <= lArrOrigAcl.GetUpperBound(0); iCont++)
                    {
                        if (lArrOrigAcl[iCont] != CORVB.NULL_INTEGER)
                        {
                            result = -1;
                            break;
                        }
                    }

                    break;
            }

            return result;
        }

        private void CORGRACL_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                //ID_ACL_GPH.DataReset = G_ALL_DATA
                //ID_ACL_GPH.DrawMode = G_CLEAR

            }
        }

        private void CORGRACL_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;

            if (KeyCode == CORVB.KEY_F6)
            {
                ID_ACL_GPH_DblClick(ID_ACL_GPH, new EventArgs());
            }

        }

        private void CORGRACL_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY(1250);

            this.Refresh();

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblErr = Obten_Empresas();

            Inicializa_Combo_Tipo();

            iTipoAct = CORVB.NULL_INTEGER;
            bMaximizada = 0;

            ID_ACL_GPH.FontUse = CORVB.G_USE_ALL;
            ID_ACL_GPH.FontFamily = CORVB.G_FONT_SWISS;
            ID_ACL_GPH.FontStyle = CORVB.G_STYLE_DEFAULT;
            //Se definen para el Título
            ID_ACL_GPH.FontUse = CORVB.G_USE_DEFAULT;
            ID_ACL_GPH.Font = VB6.FontChangeSize(ID_ACL_GPH.Font, INT_FONTSIZE_TIT);

            //Se definen para los Títulos de la Izquierda y de Pie de Gráfica
            ID_ACL_GPH.FontUse = CORVB.G_USE_OTHER;
            ID_ACL_GPH.Font = VB6.FontChangeSize(ID_ACL_GPH.Font, INT_FONTSIZE_OTROS);

            //Se definen para los legend Text (los de la derecha)
            ID_ACL_GPH.FontUse = CORVB.G_USE_LEGEND;
            ID_ACL_GPH.Font = VB6.FontChangeSize(ID_ACL_GPH.Font, INT_FONTSIZE_OTROS);

            ID_ACL_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_ACL_GPH.DrawMode was not upgraded.
            ID_ACL_GPH.DrawMode = CORVB.G_CLEAR;

            this.Cursor = Cursors.Default;

        }

        private void ID_ACL_GPH_DblClick(Object eventSender, EventArgs eventArgs)
        {

            if (bMaximizada != 0)
            { //Minimiza

                ID_ACL_IMP_PB.Visible = false;
                ID_ACL_GPH.Visible = false;
                ID_ACL_PRI1_PNL.Visible = false;
                this.Refresh();

                //Guardamos las Medidas Originales del Panel de la Gráfica
                ID_ACL_PRI1_PNL.Top = (int)VB6.TwipsToPixelsY(iPnlTop);
                ID_ACL_PRI1_PNL.Left = (int)VB6.TwipsToPixelsX(iPnlLeft);
                ID_ACL_PRI1_PNL.Height = (int)VB6.TwipsToPixelsY(iPnlHeight);
                ID_ACL_PRI1_PNL.Width = (int)VB6.TwipsToPixelsX(iPnlWidth);

                //Guardamos las Medidas Originales de la Gráfica
                ID_ACL_GPH.Top = (int)VB6.TwipsToPixelsY(iGphTop);
                ID_ACL_GPH.Left = (int)VB6.TwipsToPixelsX(iGphLeft);
                ID_ACL_GPH.Height = (int)VB6.TwipsToPixelsY(iGphHeight);
                ID_ACL_GPH.Width = (int)VB6.TwipsToPixelsX(iGphWidth);

                ID_ACL_IMP_PB.Top = (int)VB6.TwipsToPixelsY(iImpTop);
                ID_ACL_IMP_PB.Left = (int)VB6.TwipsToPixelsX(iImpLeft);

                ID_ACL_PRI1_PNL.Visible = true;
                ID_ACL_PRI_PNL.Visible = true;
                ID_ACL_GRP_PNL.Visible = true;
                ID_ACL_SAL_PB.Visible = true;
                ID_ACL_IMP_PB.Visible = true;
                ID_ACL_GRA_PB.Visible = true;
                this.Refresh();
                ID_ACL_GPH.Visible = true;
                bMaximizada = 0;

            }
            else
            {
                //Ocultamos todos los controles
                ID_ACL_GPH.Visible = false;
                ID_ACL_PRI1_PNL.Visible = false;
                ID_ACL_PRI_PNL.Visible = false;
                ID_ACL_GRP_PNL.Visible = false;
                ID_ACL_GRA_PB.Visible = false;
                ID_ACL_IMP_PB.Visible = false;
                ID_ACL_SAL_PB.Visible = false;
                this.Refresh();

                //Guardamos las Medidas Originales de la Gráfica
                iGphTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_ACL_GPH.Top));
                iGphLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_ACL_GPH.Left));
                iGphHeight = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_ACL_GPH.Height));
                iGphWidth = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_ACL_GPH.Width));

                //Guardamos las Medidas Originales del Panel de la Gráfica
                iPnlTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_ACL_PRI1_PNL.Top));
                iPnlLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_ACL_PRI1_PNL.Left));
                iPnlHeight = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_ACL_PRI1_PNL.Height));
                iPnlWidth = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_ACL_PRI1_PNL.Width));

                //Guardamos las Medidas Originales del Boton de Imprimir
                iImpTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_ACL_IMP_PB.Top));
                iImpLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_ACL_IMP_PB.Left));

                //Ajustamos las Medidas del Panel de la Gráfica
                ID_ACL_PRI1_PNL.Top = (int)ID_ACL_PRI_PNL.Top;
                ID_ACL_PRI1_PNL.Left = (int)ID_ACL_PRI_PNL.Left;
                ID_ACL_PRI1_PNL.Height = (int)(ID_ACL_PRI_PNL.Height + ID_ACL_PRI1_PNL.Height);
                ID_ACL_PRI1_PNL.Width = (int)ID_ACL_PRI_PNL.Width;

                //Ajustamos las Medidas de la Gráfica
                ID_ACL_GPH.Top = (int)ID_ACL_PRI1_PNL.Top;
                ID_ACL_GPH.Left = (int)ID_ACL_PRI1_PNL.Left;
                ID_ACL_GPH.Height = (int)ID_ACL_PRI1_PNL.Height;
                ID_ACL_GPH.Width = (int)ID_ACL_PRI1_PNL.Width;
                this.Refresh();

                ID_ACL_IMP_PB.Top = (int)(ID_ACL_GPH.Height - VB6.TwipsToPixelsY(((float)VB6.PixelsToTwipsY(ID_ACL_IMP_PB.Height)) * 1.3d));
                ID_ACL_IMP_PB.Left = (int)VB6.TwipsToPixelsX(((float)VB6.PixelsToTwipsX(ID_ACL_IMP_PB.Width)) * 0.2d);
                ID_ACL_IMP_PB.BringToFront();
                this.Refresh();

                ID_ACL_IMP_PB.Visible = true;
                ID_ACL_GPH.Visible = true;
                ID_ACL_PRI1_PNL.Visible = true;
                bMaximizada = -1;

            }

        }

        private void ID_ACL_GRA_GPB_ClickEvent(Object eventSender, AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
        {
            int Index = Array.IndexOf(ID_ACL_GRA_GPB, eventSender);
            //AIS-1095 NGONZALEZ
            if (eventArgs.value != 0)
            {

                switch (Index)
                {
                    case 0:
                        ID_ACL_GPH.GraphType = CORVB.G_BAR2D;
                        ID_ACL_GPH.GraphStyle = 0;
                        break;
                    case 1:
                        ID_ACL_GPH.GraphType = CORVB.G_BAR3D;
                        ID_ACL_GPH.GraphStyle = 0;
                        break;
                    case 2:
                        ID_ACL_GPH.GraphType = CORVB.G_PIE2D;
                        ID_ACL_GPH.GraphStyle = 4;
                        break;
                    case 3:
                        ID_ACL_GPH.GraphType = CORVB.G_PIE3D;
                        ID_ACL_GPH.GraphStyle = 4;
                        break;
                }
                this.Refresh();

                Carga_Grafica();
            }

        }

        private void ID_ACL_GRA_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                if (ID_ACL_INF_CKB.Value)
                { //Se selecciono Ir a
                    CORMDIBN.DefInstance.Enabled = false;
                    CORIREMP.DefInstance.Tag = "CORGRACL";
                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    CORIREMP.DefInstance.ShowDialog();
                    this.Refresh();

                    if (CORVAR.lgblTempNumEmp >= 0)
                    {
                        switch (ID_ACL_TIP_COB.SelectedIndex)
                        {
                            case 0:
                                iTipoAct = 0;
                                Carga_Acl_Emp();
                                break;
                            case 2:  //Tipo de Aclaración por Empresa 
                                if (CORVAR.lgblTempNumEmp >= 0)
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    iTipoAct = 2;
                                    Carga_por_Tipo_Acl();
                                }
                                break;
                            case 4:  //Status de Aclaración por Empresa 
                                if (CORVAR.lgblTempNumEmp >= 0)
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    iTipoAct = 4;
                                    Carga_por_Stat_Acl();
                                }
                                break;
                            case 6:  //Origen de Aclaración por Empresa 
                                if (CORVAR.lgblTempNumEmp >= 0)
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    iTipoAct = 6;
                                    Carga_por_Orig_Acl();
                                }
                                break;
                        }
                    }
                }
                else
                {
                    //No selecciono Ir a
                    this.Cursor = Cursors.WaitCursor;
                    switch (ID_ACL_TIP_COB.SelectedIndex)
                    {
                        case 0:  //Aclaraciones por Empresa 
                            iTipoAct = 0;
                            //EISSA 05-10-2001. Cambio para traer la longitud del número de empresa. 
                            CORVAR.lgblTempNumEmp = Convert.ToInt32(Conversion.Val(ID_ACL_INF_COB.Text.Substring(0, Math.Min(ID_ACL_INF_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                            Carga_Acl_Emp();
                            break;
                        case 1:  //Tipo de Aclaración Global 
                            iTipoAct = 1;
                            Carga_por_Tipo_Acl();
                            break;
                        case 2:  //Tipo de Aclaración por Empresa 
                            iTipoAct = 2;
                            CORVAR.lgblTempNumEmp = Convert.ToInt32(Conversion.Val(ID_ACL_INF_COB.Text.Substring(0, Math.Min(ID_ACL_INF_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                            Carga_por_Tipo_Acl();
                            break;
                        case 3:  //Status de Aclaración Global 
                            iTipoAct = 3;
                            Carga_por_Stat_Acl();
                            break;
                        case 4:  //Status de Aclaración por Empresa 
                            iTipoAct = 4;
                            CORVAR.lgblTempNumEmp = Convert.ToInt32(Conversion.Val(ID_ACL_INF_COB.Text.Substring(0, Math.Min(ID_ACL_INF_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                            Carga_por_Stat_Acl();
                            break;
                        case 5:  //Origen de Aclaración Global 
                            iTipoAct = 5;
                            Carga_por_Orig_Acl();
                            break;
                        case 6:  //Origen de Aclaración por Empresa 
                            iTipoAct = 6;
                            CORVAR.lgblTempNumEmp = Convert.ToInt32(Conversion.Val(ID_ACL_INF_COB.Text.Substring(0, Math.Min(ID_ACL_INF_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                            Carga_por_Orig_Acl();
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_ACL_GRA_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_ACL_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_ACL_GPH.DrawMode was not upgraded.
            ID_ACL_GPH.DrawMode = CORVB.G_PRINT;

        }

        private void ID_ACL_INF_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            ID_ACL_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_ACL_GPH.DrawMode was not upgraded.
            ID_ACL_GPH.DrawMode = CORVB.G_CLEAR;

            this.Cursor = Cursors.Default;

        }

        private void ID_ACL_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void ID_ACL_TIP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            ID_ACL_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_ACL_GPH.DrawMode was not upgraded.
            ID_ACL_GPH.DrawMode = CORVB.G_CLEAR;

            if (ID_ACL_TIP_COB.SelectedIndex == iTipoAct)
            {
                ID_ACL_GRP_PNL.Enabled = bExistenDat != 0;
            }
            else
            {
                ID_ACL_GRP_PNL.Enabled = false;
            }

            switch (ID_ACL_TIP_COB.SelectedIndex)
            {
                case 0:  //Aclaraciones por Empresa 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    ID_ACL_ETI_TXT[2].Visible = true;
                    ID_ACL_INF_COB.Visible = true;
                    ID_ACL_INF_CKB.Visible = true;
                    ID_ACL_GRA_PB.Enabled = true;

                    break;
                case 1:  //Tipo de Aclaración Global 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    ID_ACL_ETI_TXT[2].Visible = false;
                    ID_ACL_INF_COB.Visible = false;
                    ID_ACL_INF_CKB.Visible = false;
                    ID_ACL_INF_CKB.Value = false;
                    ID_ACL_GRA_PB.Enabled = true;
                    break;
                case 2:  //Tipo de Aclaración por Empresa 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    ID_ACL_ETI_TXT[2].Visible = true;
                    ID_ACL_INF_COB.Visible = true;
                    ID_ACL_INF_CKB.Visible = true;
                    //igblErr = Obten_Empresas()      'Obtiene los Grupos que pertenecen a Tarjeta Corporativa 
                    break;
                case 3:  //Status de Aclaración Global 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    ID_ACL_ETI_TXT[2].Visible = false;
                    ID_ACL_INF_COB.Visible = false;
                    ID_ACL_INF_CKB.Visible = false;
                    ID_ACL_INF_CKB.Value = false;
                    ID_ACL_GRA_PB.Enabled = true;
                    break;
                case 4:  //Status de Aclaración por Empresa 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    ID_ACL_ETI_TXT[2].Visible = true;
                    ID_ACL_INF_COB.Visible = true;
                    ID_ACL_INF_CKB.Visible = true;
                    //igblErr = Obten_Empresas()      'Obtiene los Grupos que pertenecen a Tarjeta Corporativa 
                    break;
                case 5:  //Origen de Aclaración Global 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    ID_ACL_ETI_TXT[2].Visible = false;
                    ID_ACL_INF_COB.Visible = false;
                    ID_ACL_INF_CKB.Visible = false;
                    ID_ACL_INF_CKB.Value = false;
                    ID_ACL_GRA_PB.Enabled = true;
                    break;
                case 6:  //Origen de Aclaración por Empresa 
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    ID_ACL_ETI_TXT[2].Visible = true;
                    ID_ACL_INF_COB.Visible = true;
                    ID_ACL_INF_CKB.Visible = true;
                    //igblErr = Obten_Empresas()      'Obtiene los Grupos que pertenecen a Tarjeta Corporativa 
                    break;
            }

            this.Cursor = Cursors.Default;

        }

        private void Inicializa_Combo_Tipo()
        {

            ID_ACL_TIP_COB.Items.Add("Aclaraciones por Empresa");
            ID_ACL_TIP_COB.Items.Add("Tipo de Aclaración por Producto");
            ID_ACL_TIP_COB.Items.Add("Tipo de Aclaración por Empresa");
            ID_ACL_TIP_COB.Items.Add("Status de Aclaración por Producto");
            ID_ACL_TIP_COB.Items.Add("Status de Aclaración por Empresa");
            ID_ACL_TIP_COB.Items.Add("Origen de Aclaración por Producto");
            ID_ACL_TIP_COB.Items.Add("Origen de Aclaración por Empresa");

            ID_ACL_TIP_COB.SelectedIndex = CORVB.NULL_INTEGER;

        }

        private void Inicializa_Orig_Acl()
        {

            lArrOrigAcl = new int[3];
            pszArrOrigAcl = new string[] { String.Empty, String.Empty, String.Empty };

            pszArrOrigAcl[1] = "Interno Banamex";
            pszArrOrigAcl[2] = "Externo Nacional";
            pszArrOrigAcl[3] = "Internacional";

        }

        private void Inicializa_Stat_Acl()
        {

            lArrStatAcl = new int[4];
            pszArrStatAcl = new string[] { String.Empty, String.Empty, String.Empty, String.Empty };

            pszArrStatAcl[1] = "En Proceso";
            pszArrStatAcl[2] = "Resuelta a Favor del Banco";
            pszArrStatAcl[3] = "Vencida a Favor del Cliente";
            pszArrStatAcl[4] = "Resuelta a Favor del Cliente";

        }

        private void Inicializa_Tip_Acl()
        {

            lArrTipAcl = new int[17, 2];
            pszArrTipAcl = ArraysHelper.InitializeArray<string>(17);

            pszArrTipAcl[1] = "No Reconoce Cargo";
            lArrTipAcl[1, 2] = 1;
            pszArrTipAcl[2] = "Cargo Duplicado";
            lArrTipAcl[2, 2] = 2;
            pszArrTipAcl[3] = "Pagaré Alterado en Importe";
            lArrTipAcl[3, 2] = 3;
            pszArrTipAcl[4] = "Cargos Multiples";
            lArrTipAcl[4, 2] = 4;
            pszArrTipAcl[5] = "Cargo Diferido";
            lArrTipAcl[5, 2] = 5;
            pszArrTipAcl[6] = "Cargo Promoción";
            lArrTipAcl[6, 2] = 6;
            pszArrTipAcl[7] = "Pago no Aplicado";
            lArrTipAcl[7, 2] = 20;
            pszArrTipAcl[8] = "Pago Aplicado Extemporaneo";
            lArrTipAcl[8, 2] = 21;
            pszArrTipAcl[9] = "Devolución de Mercancía no Aplicada";
            lArrTipAcl[9, 2] = 22;
            pszArrTipAcl[10] = "Pagare por Rechazos";
            lArrTipAcl[10, 2] = 30;
            pszArrTipAcl[11] = "Pagare Otro Emisor";
            lArrTipAcl[11, 2] = 31;
            pszArrTipAcl[12] = "Pagare Tramite Legal";
            lArrTipAcl[12, 2] = 32;
            pszArrTipAcl[13] = "Pagare Extemporaneo";
            lArrTipAcl[13, 2] = 33;
            pszArrTipAcl[14] = "Pagare";
            lArrTipAcl[14, 2] = 34;
            pszArrTipAcl[15] = "Acuse de Recibo de Tarjeta";
            lArrTipAcl[15, 2] = 35;
            pszArrTipAcl[16] = "Estado de Cuenta Extemporaneo";
            lArrTipAcl[16, 2] = 36;
            pszArrTipAcl[17] = "Contrato";
            lArrTipAcl[17, 2] = 37;

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
            //  pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_banco=" + Format$(igblBanco) + " ORDER BY emp_num"
            //***** FIN  CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " ORDER BY emp_num";
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            //ros lTotalEmpresas = Cuenta_Registros

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_ACL_INF_COB.Items.Clear();
                lContEmp = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    //EISSA 03-10-2001. Cambio para formatear el número de empresa
                    ID_ACL_INF_COB.Items.Add(StringsHelper.Format(iNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
                    lContEmp++;
                };

                //Colocamos a una Empresa por default
                if (ID_ACL_INF_COB.Items.Count != 0)
                {
                    ID_ACL_INF_COB.SelectedIndex = CORVB.NULL_INTEGER;
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
                ID_ACL_ETI_TXT[2].Visible = false;
                ID_ACL_INF_COB.Visible = false;
                ID_ACL_INF_CKB.Visible = false;
                ID_ACL_GRA_PB.Enabled = false;
                this.Cursor = Cursors.Default;
                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //    MsgBox "No existen Empresas para el Banco." + Format$(igblBanco) + ". ", MB_OK + MB_ICONINFORMATION, STR_APP_TIT
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX *****
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen Empresas para el Banco." + CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + ". ", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                //***** FIN DE CODIGO NUEVO FSWBMX *****
            }
            else if (lEmpresas > CORVB.NULL_INTEGER)
            {
                ID_ACL_ETI_TXT[2].Visible = true;
                ID_ACL_INF_COB.Visible = true;
                ID_ACL_INF_CKB.Visible = true;
                ID_ACL_GRA_PB.Enabled = true;
            }
            else
            {
                ID_ACL_ETI_TXT[2].Visible = false;
                ID_ACL_INF_COB.Visible = false;
                ID_ACL_INF_CKB.Visible = false;
                ID_ACL_GRA_PB.Enabled = false;
            }

            return lEmpresas;

        }

        private void Separa_Orig_Aclaracion(int hStmt)
        {


            int lSumOrigAcl = CORVB.NULL_INTEGER;

            //ros  iOrigAcl = qeValInt(hStmt, 1)
            //ros  lSumOrigAcl = qeValLong(hStmt, 2)
            int iOrigAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
            lSumOrigAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));

            switch (iOrigAcl)
            {
                case 1:
                    lArrOrigAcl[1] = lSumOrigAcl;
                    break;
                case 2:
                    lArrOrigAcl[2] = lSumOrigAcl;
                    break;
                case 3:
                    lArrOrigAcl[3] = lSumOrigAcl;
                    break;
            }

        }

        private void Separa_Stat_Aclaracion(int hStmt)
        {


            double dImpCorrecto = CORVB.NULL_INTEGER;
            int lSumStatAcl = CORVB.NULL_INTEGER;

            int iStatAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
            dImpCorrecto = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2));
            lSumStatAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));

            if (iStatAcl >= 100 && iStatAcl <= 899)
            {
                lArrStatAcl[1] += lSumStatAcl;
            }
            else if (iStatAcl == 902)
            {
                if (dImpCorrecto > CORVB.NULL_INTEGER)
                {
                    lArrStatAcl[2] += lSumStatAcl;
                }
                else
                {
                    lArrStatAcl[3] += lSumStatAcl;
                }
            }
            else if (iStatAcl >= 903)
            {
                lArrStatAcl[4] += lSumStatAcl;
            }

        }

        private void Separa_Tip_Aclaracion(int hStmt)
        {


            int iTipoAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
            int lSumTipAcl = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));

            switch (iTipoAcl)
            {
                case 1:
                    lArrTipAcl[1, 1] = lSumTipAcl;
                    break;
                case 2:
                    lArrTipAcl[2, 1] = lSumTipAcl;
                    break;
                case 3:
                    lArrTipAcl[3, 1] = lSumTipAcl;
                    break;
                case 4:
                    lArrTipAcl[4, 1] = lSumTipAcl;
                    break;
                case 5:
                    lArrTipAcl[5, 1] = lSumTipAcl;
                    break;
                case 6:
                    lArrTipAcl[6, 1] = lSumTipAcl;
                    break;
                case 20:
                    lArrTipAcl[7, 1] = lSumTipAcl;
                    break;
                case 21:
                    lArrTipAcl[8, 1] = lSumTipAcl;
                    break;
                case 22:
                    lArrTipAcl[9, 1] = lSumTipAcl;
                    break;
                case 30:
                    lArrTipAcl[10, 1] = lSumTipAcl;
                    break;
                case 31:
                    lArrTipAcl[11, 1] = lSumTipAcl;
                    break;
                case 32:
                    lArrTipAcl[12, 1] = lSumTipAcl;
                    break;
                case 33:
                    lArrTipAcl[13, 1] = lSumTipAcl;
                    break;
                case 34:
                    lArrTipAcl[14, 1] = lSumTipAcl;
                    break;
                case 35:
                    lArrTipAcl[15, 1] = lSumTipAcl;
                    break;
                case 36:
                    lArrTipAcl[16, 1] = lSumTipAcl;
                    break;
                case 37:
                    lArrTipAcl[17, 1] = lSumTipAcl;
                    break;
            }

        }
        private void CORGRACL_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}