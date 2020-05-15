using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORGRBIT
        : System.Windows.Forms.Form
    {

        private void CORGRBIT_Activated(Object eventSender, EventArgs eventArgs)
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
        //**       Descripción: Grafica los estados actuales de los accesos         **
        //**                    por menu al sistema almacenadas en una bitacora     **
        //**                    de accesos. Estan agrapados por los accesos mas     **
        //**                    comunes.
        //**                                                                        **
        //**       Responsable: Felipe Zacarias Jimenez                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int iPoints = 0;
        string[,] pszArrBitacora = null;

        int bMaximizada = 0;
        int hConexion = 0;

        //Variables para controlar la Maximización y Minimización de la Gráfica
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
        int lTotAcc = 0;

        const int INT_FONTSIZE_TIT = 150;
        const int INT_FONTSIZE_OTROS = 100;

        private void Busca_Niveles(int iClave)
        {

            int iCont = 0;
            int hBitacora = 0;
            int iAccesos = 0;
            int iMaxAcc = 0;
            int iGrupo = 0;
            string pszSQL = String.Empty;
            string pszFormaDesc = String.Empty;

            lTotAcc = CORVB.NULL_INTEGER;

            if (iClave > CORVB.NULL_INTEGER)
            {
                CORVAR.pszgblsql = "SELECT bit_desc,bit_accesos FROM " + CORBD.DB_SYB_BIT + " WHERE bit_grupo = " + iClave.ToString();
            }
            else
            {
                CORVAR.pszgblsql = "SELECT sum(bit_accesos),bit_grupo FROM " + CORBD.DB_SYB_BIT + " GROUP BY bit_grupo ORDER BY bit_grupo";
            }

            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            iPoints = CORPROC2.Cuenta_Registros();

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                iCont = CORVB.NULL_INTEGER;

                if (pszArrBitacora != null)
                {
                    Array.Clear(pszArrBitacora, 0, pszArrBitacora.Length);
                }
                pszArrBitacora = ArraysHelper.InitializeArray<string[,]>(new int[] { iPoints, 2 }, new int[] { 0, 0 });

                if (iPoints == 0)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    return;
                }


                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iCont++;
                    pszFormaDesc = CORVB.NULL_STRING;

                    if (iClave > CORVB.NULL_INTEGER)
                    {
                        pszFormaDesc = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL);
                        iAccesos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
                        pszArrBitacora[iCont, 0] = pszFormaDesc;
                        pszArrBitacora[iCont, 1] = iAccesos.ToString();
                    }
                    else
                    {
                        iAccesos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                        iGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
                        pszArrBitacora[iCont, 0] = iGrupo.ToString();
                        pszArrBitacora[iCont, 1] = iAccesos.ToString();
                    }
                    lTotAcc += iAccesos;
                };

            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                //AIS-1182 NGONZALEZ
                //CORVAR.igblErr = API.USER.PostMessage(CORGRBIT.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }
        public bool flag = false;

        private void Define_Fonts()
        {

            ID_BIT_GRA_GPH.FontUse = CORVB.G_USE_ALL;
            ID_BIT_GRA_GPH.FontFamily = CORVB.G_FONT_SWISS;
            ID_BIT_GRA_GPH.FontStyle = CORVB.G_STYLE_DEFAULT;
            //Se definen para el Título
            ID_BIT_GRA_GPH.FontUse = CORVB.G_USE_DEFAULT;
            ID_BIT_GRA_GPH.Font = VB6.FontChangeSize(ID_BIT_GRA_GPH.Font, INT_FONTSIZE_TIT);

            //Se definen para los Títulos de la Izquierda y de Pie de Gráfica
            ID_BIT_GRA_GPH.FontUse = CORVB.G_USE_OTHER;
            ID_BIT_GRA_GPH.Font = VB6.FontChangeSize(ID_BIT_GRA_GPH.Font, INT_FONTSIZE_OTROS);

            //Se definen para los legend Text (los de la derecha)
            ID_BIT_GRA_GPH.FontUse = CORVB.G_USE_LEGEND;
            ID_BIT_GRA_GPH.Font = VB6.FontChangeSize(ID_BIT_GRA_GPH.Font, INT_FONTSIZE_OTROS);

        }

        private void Define_Grafica(int iClave)
        {

            string szFormaDesc = String.Empty;

            double dMax = CORVB.NULL_INTEGER;

            ID_BIT_GRA_GPH.DataReset = CORVB.G_ALL_DATA;

            if (iPoints > CORVB.NULL_INTEGER)
            {
                for (int iCont = pszArrBitacora.GetLowerBound(0); iCont <= pszArrBitacora.GetUpperBound(0); iCont++)
                {
                    if (Conversion.Val(pszArrBitacora[iCont, 1]) > dMax)
                    {
                        dMax = Conversion.Val(pszArrBitacora[iCont, 1]);
                    }
                }

                if (pszArrBitacora.GetUpperBound(0) <= 1)
                {
                    ID_BIT_GRA_GPH.NumPoints = 2;
                }
                else
                {
                    ID_BIT_GRA_GPH.NumPoints = (short)pszArrBitacora.GetUpperBound(0);
                }
                ID_BIT_GRA_GPH.NumSets = 1;

                if (iClave == CORVB.NULL_INTEGER)
                {
                    for (int iCont = pszArrBitacora.GetLowerBound(0); iCont <= pszArrBitacora.GetUpperBound(0); iCont++)
                    {
                        //AIS-119 NGONZALEZ
                        int switchVar = Convert.ToInt32(pszArrBitacora[iCont, 0]);
                        switch (switchVar)
                        {
                            case 1:
                                szFormaDesc = "Configurar";
                                break;
                            case 2:
                                szFormaDesc = "Interfases";
                                break;
                            case 3:
                                szFormaDesc = "Archivos";
                                break;
                            case 4:
                                szFormaDesc = "Consultas";
                                break;
                            case 5:
                                szFormaDesc = "Opc/Consulta";
                                break;
                            case 6:
                                szFormaDesc = "Gráficas";
                                break;
                            case 7:
                                szFormaDesc = "Aclaraciones";
                                break;
                            case 8:
                                szFormaDesc = "Reporteador";
                                break;
                        }
                        ID_BIT_GRA_GPH.ThisSet = 1;
                        ID_BIT_GRA_GPH.ThisPoint = (short)iCont;
                        ID_BIT_GRA_GPH.GraphData = (float)Conversion.Val(pszArrBitacora[iCont, 1]);
                        ID_BIT_GRA_GPH.LegendText = iCont.ToString() + " - " + szFormaDesc;
                    }

                }
                else if (iClave >= 1)
                {
                    for (int iCont = pszArrBitacora.GetLowerBound(0); iCont <= pszArrBitacora.GetUpperBound(0); iCont++)
                    {
                        ID_BIT_GRA_GPH.ThisSet = 1;
                        ID_BIT_GRA_GPH.ThisPoint = (short)iCont;
                        ID_BIT_GRA_GPH.GraphData = (float)Conversion.Val(pszArrBitacora[iCont, 1]);
                        ID_BIT_GRA_GPH.LegendText = iCont.ToString() + " - " + pszArrBitacora[iCont, 0];
                    }
                }
                ID_GRA_GRP_PNL.Enabled = true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No se obtuvieron registros para graficar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                ID_BIT_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
                //UPGRADE_ISSUE: (2069) VBControlExtender method ID_BIT_GRA_GPH.DrawMode was not upgraded.
                ID_BIT_GRA_GPH.DrawMode = CORVB.G_CLEAR;
                ID_GRA_GRP_PNL.Enabled = false;
                return;
            }

            if (ID_BIT_GRA_GPH.GraphType == CORCONST.INT_PAS_DOS_DIM || ID_BIT_GRA_GPH.GraphType == CORCONST.INT_PAS_TRES_DIM)
            {
                ID_BIT_GRA_GPH.LeftTitle = " Total  =  " + lTotAcc.ToString();
            }
            else
            {
                ID_BIT_GRA_GPH.BottomTitle = "Grupos de Acceso";
                ID_BIT_GRA_GPH.LeftTitle = "Accesos";
            }

            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_BIT_GRA_GPH.DrawMode was not upgraded.
            ID_BIT_GRA_GPH.DrawMode = CORVB.G_DRAW;

        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY(1250);

            this.Refresh();

            this.Cursor = Cursors.WaitCursor;


            ID_BIT_GRA_GPH.FontUse = CORVB.G_USE_ALL;
            ID_BIT_GRA_GPH.FontFamily = CORVB.G_FONT_SWISS;
            ID_BIT_GRA_GPH.FontStyle = CORVB.G_STYLE_DEFAULT;
            //Se definen para el Título
            ID_BIT_GRA_GPH.FontUse = CORVB.G_USE_DEFAULT;
            ID_BIT_GRA_GPH.Font = VB6.FontChangeSize(ID_BIT_GRA_GPH.Font, INT_FONTSIZE_TIT);

            //Se definen para los Títulos de la Izquierda y de Pie de Gráfica
            ID_BIT_GRA_GPH.FontUse = CORVB.G_USE_OTHER;
            ID_BIT_GRA_GPH.Font = VB6.FontChangeSize(ID_BIT_GRA_GPH.Font, INT_FONTSIZE_OTROS);

            //Se definen para los legend Text (los de la derecha)
            ID_BIT_GRA_GPH.FontUse = CORVB.G_USE_LEGEND;
            ID_BIT_GRA_GPH.Font = VB6.FontChangeSize(ID_BIT_GRA_GPH.Font, INT_FONTSIZE_OTROS);

            Llena_Grupos();

            ID_BIT_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_BIT_GRA_GPH.DrawMode was not upgraded.
            ID_BIT_GRA_GPH.DrawMode = CORVB.G_CLEAR;

            this.Cursor = Cursors.Default;

        }

        private void ID_BIT_GRA_GPH_DblClick(Object eventSender, EventArgs eventArgs)
        {

            if (bMaximizada != 0)
            { //Minimiza

                ID_GRA_IMP_PB.Visible = false;
                ID_BIT_GRA_GPH.Visible = false;
                ID_GRA_PRI1_PNL.Visible = false;
                this.Refresh();

                //Guardamos las Medidas Originales del Panel de la Gráfica
                ID_GRA_PRI1_PNL.Top = (int)VB6.TwipsToPixelsY(iPnlTop);
                ID_GRA_PRI1_PNL.Left = (int)VB6.TwipsToPixelsX(iPnlLeft);
                ID_GRA_PRI1_PNL.Height = (int)VB6.TwipsToPixelsY(iPnlHeight);
                ID_GRA_PRI1_PNL.Width = (int)VB6.TwipsToPixelsX(iPnlWidth);

                //Guardamos las Medidas Originales de la Gráfica
                ID_BIT_GRA_GPH.Top = (int)VB6.TwipsToPixelsY(iGphTop);
                ID_BIT_GRA_GPH.Left = (int)VB6.TwipsToPixelsX(iGphLeft);
                ID_BIT_GRA_GPH.Height = (int)VB6.TwipsToPixelsY(iGphHeight);
                ID_BIT_GRA_GPH.Width = (int)VB6.TwipsToPixelsX(iGphWidth);

                ID_GRA_IMP_PB.Top = (int)VB6.TwipsToPixelsY(iImpTop);
                ID_GRA_IMP_PB.Left = (int)VB6.TwipsToPixelsX(iImpLeft);

                ID_GRA_PRI1_PNL.Visible = true;
                ID_GRA_PRI_PNL.Visible = true;
                ID_GRA_GRP_PNL.Visible = true;
                ID_GRA_CAN_PB.Visible = true;
                ID_GRA_IMP_PB.Visible = true;
                ID_BIT_GRA_PB.Visible = true;
                this.Refresh();
                ID_BIT_GRA_GPH.Visible = true;
                bMaximizada = 0;

            }
            else
            {
                //Ocultamos todos los controles
                ID_BIT_GRA_GPH.Visible = false;
                ID_GRA_PRI1_PNL.Visible = false;
                ID_GRA_PRI_PNL.Visible = false;
                ID_GRA_GRP_PNL.Visible = false;
                ID_GRA_IMP_PB.Visible = false;
                ID_BIT_GRA_PB.Visible = false;
                ID_GRA_CAN_PB.Visible = false;
                this.Refresh();

                //Guardamos las Medidas Originales de la Gráfica
                iGphTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_BIT_GRA_GPH.Top));
                iGphLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_BIT_GRA_GPH.Left));
                iGphHeight = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_BIT_GRA_GPH.Height));
                iGphWidth = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_BIT_GRA_GPH.Width));

                //Guardamos las Medidas Originales del Panel de la Gráfica
                iPnlTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_GRA_PRI1_PNL.Top));
                iPnlLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_GRA_PRI1_PNL.Left));
                iPnlHeight = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_GRA_PRI1_PNL.Height));
                iPnlWidth = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_GRA_PRI1_PNL.Width));

                //Guardamos las Medidas Originales del Boton de Imprimir
                iImpTop = Convert.ToInt32((float)VB6.PixelsToTwipsY(ID_GRA_IMP_PB.Top));
                iImpLeft = Convert.ToInt32((float)VB6.PixelsToTwipsX(ID_GRA_IMP_PB.Left));

                //Ajustamos las Medidas del Panel de la Gráfica
                ID_GRA_PRI1_PNL.Top = (int)ID_GRA_PRI_PNL.Top;
                ID_GRA_PRI1_PNL.Left = (int)ID_GRA_PRI_PNL.Left;
                ID_GRA_PRI1_PNL.Height = (int)(ID_GRA_PRI_PNL.Height + ID_GRA_PRI1_PNL.Height);
                ID_GRA_PRI1_PNL.Width = (int)ID_GRA_PRI_PNL.Width;

                //Ajustamos las Medidas de la Gráfica
                ID_BIT_GRA_GPH.Top = (int)ID_GRA_PRI1_PNL.Top;
                ID_BIT_GRA_GPH.Left = (int)ID_GRA_PRI1_PNL.Left;
                ID_BIT_GRA_GPH.Height = (int)ID_GRA_PRI1_PNL.Height;
                ID_BIT_GRA_GPH.Width = (int)ID_GRA_PRI1_PNL.Width;
                this.Refresh();

                ID_GRA_IMP_PB.Top = (int)(ID_BIT_GRA_GPH.Height - VB6.TwipsToPixelsY(((float)VB6.PixelsToTwipsY(ID_GRA_IMP_PB.Height)) * 1.5d));
                ID_GRA_IMP_PB.Left = (int)VB6.TwipsToPixelsX(((float)VB6.PixelsToTwipsX(ID_GRA_IMP_PB.Width)) * 0.2d);
                ID_GRA_IMP_PB.BringToFront();
                this.Refresh();

                ID_GRA_IMP_PB.Visible = true;
                ID_BIT_GRA_GPH.Visible = true;
                ID_GRA_PRI1_PNL.Visible = true;
                bMaximizada = -1;

            }

        }

        private void ID_BIT_GRA_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            ID_GRA_GRP_PNL.Enabled = true;
            try
            {
                if (ID_BIT_GRU_COB.SelectedIndex == ID_BIT_GRU_COB.Items.Count - 1)
                {
                    Busca_Niveles(CORVB.NULL_INTEGER);
                    Define_Grafica(CORVB.NULL_INTEGER);
                }
                else
                {
                    Busca_Niveles(VB6.GetItemData(ID_BIT_GRU_COB, ID_BIT_GRU_COB.SelectedIndex));
                    Define_Grafica(VB6.GetItemData(ID_BIT_GRU_COB, ID_BIT_GRU_COB.SelectedIndex));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_BIT_GRA_PB_Click " + exc.Message, "Error Corgrbit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_BIT_GRU_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            ID_BIT_GRA_GPH.DataReset = CORVB.G_ALL_DATA;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_BIT_GRA_GPH.DrawMode was not upgraded.
            ID_BIT_GRA_GPH.DrawMode = CORVB.G_CLEAR;
            ID_GRA_GRP_PNL.Enabled = false;

        }

        private void ID_CRE_TIP_SSR_ClickEvent(Object eventSender, AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
        {
            int Index = Array.IndexOf(ID_CRE_TIP_SSR, eventSender);

            switch (Index)
            {
                case 0:
                    ID_BIT_GRA_GPH.GraphType = CORVB.G_BAR2D;
                    ID_BIT_GRA_GPH.GraphStyle = 0;
                    ID_BIT_GRA_GPH.LeftTitle = "Accesos";
                    ID_BIT_GRA_GPH.BottomTitle = "Grupos de Acceso";
                    break;
                case 1:
                    ID_BIT_GRA_GPH.GraphType = CORVB.G_BAR3D;
                    ID_BIT_GRA_GPH.GraphStyle = 0;
                    ID_BIT_GRA_GPH.LeftTitle = "Accesos";
                    ID_BIT_GRA_GPH.BottomTitle = "Grupos de Acceso";
                    break;
                case 2:
                    ID_BIT_GRA_GPH.GraphType = CORVB.G_PIE2D;
                    ID_BIT_GRA_GPH.GraphStyle = 4;
                    ID_BIT_GRA_GPH.LeftTitle = "Total = " + lTotAcc.ToString();
                    ID_BIT_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
                    break;
                case 3:
                    ID_BIT_GRA_GPH.GraphType = CORVB.G_PIE3D;
                    ID_BIT_GRA_GPH.GraphStyle = 4;
                    ID_BIT_GRA_GPH.LeftTitle = "Total = " + lTotAcc.ToString();
                    ID_BIT_GRA_GPH.BottomTitle = CORVB.NULL_STRING;
                    break;
            }

            this.Refresh();
            Define_Fonts();
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_BIT_GRA_GPH.DrawMode was not upgraded.
            ID_BIT_GRA_GPH.DrawMode = CORCONST.INT_MODO_RED;

        }

        private void ID_GRA_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }

        private void ID_GRA_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            //UPGRADE_ISSUE: (2069) VBControlExtender method ID_BIT_GRA_GPH.DrawMode was not upgraded.
            ID_BIT_GRA_GPH.DrawMode = CORVB.G_PRINT;
            this.Cursor = Cursors.Default;

        }

        private void Llena_Grupos()
        {

            ID_BIT_GRU_COB.Items.Clear();
            ID_BIT_GRU_COB.Items.Add(new ListBoxItem("Configurar", 1));
            ID_BIT_GRU_COB.Items.Add(new ListBoxItem("Interfases", 2));
            ID_BIT_GRU_COB.Items.Add(new ListBoxItem("Archivos", 3));
            ID_BIT_GRU_COB.Items.Add(new ListBoxItem("Consultas", 4));
            ID_BIT_GRU_COB.Items.Add(new ListBoxItem("Opc/Consulta", 5));
            ID_BIT_GRU_COB.Items.Add(new ListBoxItem("Gráficas", 6));
            ID_BIT_GRU_COB.Items.Add(new ListBoxItem("Aclaraciones", 7));
            //  ID_BIT_GRU_COB.AddItem "Reporteador"
            //  ID_BIT_GRU_COB.ItemData(ID_BIT_GRU_COB.NewIndex) = 8
            ID_BIT_GRU_COB.Items.Add(new ListBoxItem("Todos los Grupos", 8));

            ID_BIT_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;

        }
        private void CORGRBIT_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}