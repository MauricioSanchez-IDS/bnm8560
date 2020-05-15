using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMNUNI
        : System.Windows.Forms.Form
    {

        private void CORMNUNI_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        const int INT_MAX_EDO = 999;
        int lEstruc_Gastos = 0;
        int lTotalEdo = 0;
        int iRenCat = 0;
        int iRenRep = 0;
        string sRep_ID = String.Empty;
        string sRep_Name = String.Empty;
        string sFreq = String.Empty;
        string sDetail = String.Empty;
        string sDepth = String.Empty;
        string sCat_Id = String.Empty;
        string sCat_Nombre = String.Empty;
        string sLimit = String.Empty;
        string sPor_Uso = String.Empty;
        bool bNivPadre = false;

        private bool bValidaNiv()
        {

            bool result = false;
            int iError = 0;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;
            int i_Cons_Niv = 0;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.pszgblsql = "select level_id from " + CORBD.DB_SYB_NIV;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + Conversion.Str(CORVAR.igblPref);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(CORVAR.lgblNumEmpresa);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and level_id = " + mkbMaskebox[2].CtlText;

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    i_Cons_Niv = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                };
            }
            if (i_Cons_Niv == 1)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se puede dar de alta la unidad " + mkbMaskebox[0].CtlText + " con el Nivel " + mkbMaskebox[2].CtlText + " porque No es valido el Nivel ", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else
            {
                result = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;
            return result;
        }

        private int validaNivPadre()
        {

            int result = 0;
            int iError = 0;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.pszgblsql = "select unit_id from " + CORBD.DB_SYB_UNI;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + Conversion.Str(CORVAR.igblPref);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(CORVAR.lgblNumEmpresa);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + Conversion.Str(CORVAR.igblNumGrupo);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and nivel_num = " + Conversion.Str(1);

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            result = CORPROC2.Cuenta_Registros();

            this.Cursor = Cursors.Default;

            return result;
        }

        private bool bValidaUniPadre()
        {
            bool result = false;
            int iError = 0;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.pszgblsql = "select unit_id from " + CORBD.DB_SYB_UNI;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + Conversion.Str(CORVAR.igblPref);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(CORVAR.lgblNumEmpresa);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + mkbMaskebox[1].CtlText;

            if (CORPROC2.Cuenta_Registros() <= 0)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se encontro la Unidad Padre " + mkbMaskebox[1].CtlText, CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else
            {
                result = true;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;
            return result;
        }

        private void CMB_CAT_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
        {
            if (CMB_CAT.Text == "")
            {
                CMB_CAT.Focus();
            }
            else
            {
                sCat_Id = VB6.GetItemData(CMB_CAT, CMB_CAT.SelectedIndex).ToString().Trim();
                mkbMaskebox_Cat[3].Focus();
            }
        }

        private void CMB_REPO_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(CMB_REPO, eventSender);
            int iCalif = 0;

            switch (Index)
            {
                case 0:
                    if (CMB_REPO[Index].Text == "")
                    {
                        CMB_REPO[Index].Focus();
                    }
                    else
                    {
                        sRep_ID = VB6.GetItemData(CMB_REPO[Index], CMB_REPO[Index].SelectedIndex).ToString().Trim();
                        sRep_Name = CMB_REPO[Index].Text.Trim();
                        CMB_REPO[1].Focus();
                    }

                    break;
                case 1:
                    if (CMB_REPO[Index].Text == "")
                    {
                        CMB_REPO[Index].Focus();
                    }
                    else
                    {
                        iCalif = Convert.ToInt32(Conversion.Val(VB6.GetItemData(CMB_REPO[Index], CMB_REPO[Index].SelectedIndex).ToString()));
                        switch (iCalif)
                        {
                            case 1:
                                sFreq = "Q";
                                break;
                            case 2:
                                sFreq = "M";
                                break;
                            case 3:
                                sFreq = "F";
                                break;
                            case 4:
                                sFreq = "Y";
                                break;
                            case 5:
                                sFreq = "C";
                                break;
                            case 6:
                                sFreq = "A";
                                break;
                        }
                        CMB_REPO[2].Focus();
                    }

                    break;
                case 2:
                    if (CMB_REPO[Index].Text == "")
                    {
                        CMB_REPO[Index].Focus();
                    }
                    else
                    {
                        iCalif = Convert.ToInt32(Conversion.Val(VB6.GetItemData(CMB_REPO[Index], CMB_REPO[Index].SelectedIndex).ToString()));
                        switch (iCalif)
                        {
                            case 1:
                                sDetail = "S";
                                break;
                            case 2:
                                sDetail = "D";
                                break;
                            case 3:
                                sDetail = "T";
                                break;
                        }
                        CMB_REPO[3].Focus();
                    }

                    break;
                case 3:
                    if (CMB_REPO[Index].Text == "")
                    {
                        CMB_REPO[Index].Focus();
                    }
                    else
                    {
                        iCalif = Convert.ToInt32(Conversion.Val(VB6.GetItemData(CMB_REPO[Index], CMB_REPO[Index].SelectedIndex).ToString()));
                        switch (iCalif)
                        {
                            case 1:
                                sDepth = "1";
                                break;
                            case 2:
                                sDepth = "2";
                                break;
                            case 3:
                                sDepth = "3";
                                break;
                        }
                    }
                    break;
            }
        }

        private void CMD_ACT_CAT_Click(Object eventSender, EventArgs eventArgs)
        {

            if (sCat_Id != "" && sLimit != "" && sPor_Uso != "")
            {
                for (int i = 0; i <= iRenCat - 1; i++)
                {
                    LST_CAT.SelectedIndex = i;
                    if (Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 3))) == Conversion.Val(sCat_Id))
                    {
                        sCat_Nombre = Strings.Mid(LST_CAT.Text, 7, 20);
                        LST_CAT.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_CAT));
                        if (Conversion.Val(sCat_Id) <= 9)
                        {
                            LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 5) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                        }
                        else if (Conversion.Val(sCat_Id) >= 10)
                        {
                            LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 4) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                        }
                    }
                }
                CMB_CAT.SelectedIndex = -1;
                LST_CAT.SelectedIndex = -1;
                mkbMaskebox_Cat[3].CtlText = "";
                mkbMaskebox_Cat[4].CtlText = "";
            }
            else
            {
                MessageBox.Show("No se pueden Actualizar los datos porque falta algun dato.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void CMD_ACT_REP_Click(Object eventSender, EventArgs eventArgs)
        {
            string s = String.Empty;
            int reg = 0;
            if (CHK_REP.CheckState == CheckState.Checked)
            {
                if (sRep_ID != "" && sRep_Name != "" && sFreq != "" && sDetail != "" && sDepth != "")
                {
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " report_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " report_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " supported_frequencies,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " supported_detail,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " supported_depth";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCREP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where report_id = '" + sRep_ID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and report_name = '" + sRep_Name + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and supported_detail = '" + sDetail + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and supported_depth = '" + sDepth + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and supported_frequencies = '" + sFreq + "'";

                    reg = CORPROC2.Cuenta_Registros();
                    if (reg >= 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                sRep_ID = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                sRep_Name = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                sFreq = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                                sDetail = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                sDepth = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                for (int i = 0; i <= iRenRep - 1; i++)
                                {
                                    LST_REPO[0].SelectedIndex = i;
                                    if (Conversion.Val(LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3))) == Conversion.Val(sRep_ID))
                                    {
                                        LST_REPO[0].Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_REPO[0]));
                                        if (Conversion.Val(sRep_ID) <= 9)
                                        {
                                            LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 5) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                        }
                                        else if (Conversion.Val(sRep_ID) >= 10)
                                        {
                                            LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 4) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                        }
                                    }
                                }
                            };
                        }
                        for (int i = 0; i <= 3; i++)
                        {
                            CMB_REPO[i].SelectedIndex = -1;
                        }
                        CMB_REPO[0].Focus();
                        LST_REPO[0].SelectedIndex = -1;
                        CHK_REP.CheckState = CheckState.Unchecked;
                    }
                    else if (reg <= 0)
                    {
                        MessageBox.Show("No se encontro ninguna Calificación Similar a la que elegiste para este tipo de Reporte.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se pueden Actualizar los datos porque falta algun dato.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (CHK_REP.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show("No se pueden actualizar los datos porque el Botón de Generar no esta activado.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void CHK_REP_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            if (CHK_REP.CheckState == CheckState.Checked)
            {
                CMD_ACT_REP.Enabled = true;
            }
            else if (CHK_REP.CheckState == CheckState.Unchecked)
            {
                CMD_ACT_REP.Enabled = false;
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int iCont = 0;
            string lstrEmp = String.Empty;
            string s = String.Empty;
            int reg = 0;

            this.Height = (int)VB6.TwipsToPixelsY(7245);
            this.Width = (int)VB6.TwipsToPixelsX(9465);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.tabStab[0].Top = (int)VB6.TwipsToPixelsY(105);
            this.tabStab[0].Left = (int)VB6.TwipsToPixelsX(345);
            this.ID_MEE_ALT_PB.Top = (int)VB6.ToPixelsUserY(6360, 0, 0, 0);
            this.ID_MEE_ALT_PB.Left = (int)VB6.ToPixelsUserX(2895, 0, 0, 0);
            this.ID_MEE_CER_PB.Top = (int)VB6.ToPixelsUserY(6360, 0, 0, 0);
            this.ID_MEE_CER_PB.Left = (int)VB6.ToPixelsUserX(4140, 0, 0, 0);
            this.ID_MEE_IMP_PB.Top = (int)VB6.ToPixelsUserY(6360, 0, 0, 0);
            this.ID_MEE_IMP_PB.Left = (int)VB6.ToPixelsUserX(5415, 0, 0, 0);
            CRSGeneral.prCargaEstadoEnCombo(cmbCombo[0]);

            switch (Formato.sgForma)
            {
                case "A":
                    txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto[0].Enabled = false;
                    txtTexto[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();
                    txtTexto[1].Enabled = false;
                    txtTexto_Rep[0].Text = txtTexto[0].Text;
                    txtTexto_Rep[0].Enabled = false;
                    txtTexto_Rep[1].Text = txtTexto[1].Text;
                    txtTexto_Rep[1].Enabled = false;
                    txtTexto_Cat[0].Text = txtTexto[0].Text;
                    txtTexto_Cat[0].Enabled = false;
                    txtTexto_Cat[1].Text = txtTexto[1].Text;
                    txtTexto_Cat[1].Enabled = false;

                    if (Strings.Len(txtTexto[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }
                    else
                    {
                        Formato.bgForma = true;
                    }

                    mkbMaskebox[0].Format = Formato.sMascara(Formato.iTipo.Unidad);
                    mkbMaskebox[1].Format = Formato.sMascara(Formato.iTipo.Unidad);
                    mkbMaskebox[2].Format = "00";
                    mkbMaskebox_Rep[0].Format = Formato.sMascara(Formato.iTipo.Unidad);
                    mkbMaskebox_Rep[2].Format = "00";
                    mkbMaskebox_Cat[0].Format = Formato.sMascara(Formato.iTipo.Unidad);
                    mkbMaskebox_Cat[2].Format = "00";

                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));

                    bNivPadre = true;
                    if (validaNivPadre() == 0)
                    {
                        bNivPadre = false;
                        mkbMaskebox[2].CtlText = "1";
                        mkbMaskebox[2].Enabled = false;
                        mkbMaskebox[1].Enabled = false;
                    }

                    CORVAR.pszgblsql = "select distinct convert(int,report_id),report_name from MTCREP01";
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {
                            iCont = 0;
                            iRenRep = 0;
                            CMB_REPO[0].Items.Clear();
                            LST_REPO[0].Items.Clear();

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                CMB_REPO[0].Items.Insert(iCont, VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                VB6.SetItemData(CMB_REPO[0], iCont, Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
                                if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                {
                                    LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                }
                                else if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) >= 10)
                                {
                                    LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                }
                                iCont++;
                                iRenRep++;
                            };
                        }
                    }
                    FRAM_REP[0].Enabled = false;
                    CMD_ACT_REP.Enabled = false;

                    CORVAR.pszgblsql = "select emp_estruct_gastos from MTCEMP01 where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                    LST_CAT.Items.Clear();
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                lEstruc_Gastos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            };
                            CORVAR.pszgblsql = "select exp_cat_id,exp_cat_name from MTCCAT01 where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and exp_struc_id =" + lEstruc_Gastos.ToString();
                            if (CORPROC2.Cuenta_Registros() > 0)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {
                                    iCont = 0;
                                    iRenCat = 0;
                                    LST_CAT.Items.Clear();

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        CMB_CAT.Items.Insert(iCont, VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                        VB6.SetItemData(CMB_CAT, iCont, Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
                                        if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length <= 9)
                                        {
                                            LST_CAT.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                        }
                                        else if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length >= 10)
                                        {
                                            LST_CAT.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                        }
                                        iCont++;
                                        iRenCat++;
                                    };
                                }
                            }
                            else
                            {
                                MessageBox.Show("La Estructura de Gastos de la Empresa:" + CORVAR.lgblNumEmpresa.ToString() + " no tiene Categorias.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Formato.bgForma = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        //MsgBox "No se encontro ninguna Estructura de Gastos de la Empresa:" & lgblNumEmpresa, vbInformation + vbOKOnly, "Tarjeta Corporativa"
                    }
                    FRAM_CAT.Enabled = false;

                    break;
                case "B":
                    txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();

                    if (Strings.Len(txtTexto[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }

                    Formato.bgForma = true;
                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                    mkbMaskebox[0].Format = Formato.sMascara(Formato.iTipo.Unidad);
                    mkbMaskebox[1].Format = Formato.sMascara(Formato.iTipo.Unidad);
                    mkbMaskebox[2].Format = "00";
                    txtTexto[0].Enabled = false;
                    txtTexto[1].Enabled = false;
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).ToString();
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                mkbMaskebox[0].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                mkbMaskebox[0].Enabled = false;
                                mkbMaskebox[1].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)).ToString();
                                mkbMaskebox[1].Enabled = false;
                                mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                mkbMaskebox[2].Enabled = false;
                                mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim();
                                mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
                                mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
                                CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim());
                                txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
                                mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim();
                                mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
                                mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
                                mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
                                mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim();
                                txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim();
                            };
                            mkbMaskebox[15].Enabled = false;
                            mkbMaskebox[16].Enabled = false;
                        }

                        txtTexto_Rep[0].Text = txtTexto[0].Text;
                        txtTexto_Rep[1].Text = txtTexto[1].Text;
                        mkbMaskebox_Rep[0].CtlText = mkbMaskebox[0].CtlText;
                        mkbMaskebox_Rep[1].CtlText = mkbMaskebox[3].CtlText;
                        mkbMaskebox_Rep[2].CtlText = mkbMaskebox[2].CtlText;
                        CORVAR.pszgblsql = "select distinct convert(int,report_id),report_name from MTCREP01";
                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {
                                iCont = 0;
                                iRenRep = 0;
                                CMB_REPO[0].Items.Clear();
                                LST_REPO[0].Items.Clear();

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    CMB_REPO[0].Items.Insert(iCont, VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                    VB6.SetItemData(CMB_REPO[0], iCont, Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
                                    if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                    {
                                        LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                    }
                                    else if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) >= 10)
                                    {
                                        LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                    }
                                    iCont++;
                                    iRenRep++;
                                };
                                CORVAR.pszgblsql = "select";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct (a.report_id),";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " b.report_name,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_gen,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_freq,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_details,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_depth";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCURP01 a,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCREP01 b";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.report_id = b.report_id";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.reporting_gen = 'Y'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo=" + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco=" + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id=" + mkbMaskebox[0].CtlText;

                                reg = CORPROC2.Cuenta_Registros();
                                if (reg >= 1)
                                {
                                    if (CORPROC2.Obtiene_Registros() != 0)
                                    {

                                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                        {
                                            sRep_ID = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                            sRep_Name = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                            sFreq = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                            sDetail = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                            sDepth = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                            for (int i = 0; i <= iRenRep - 1; i++)
                                            {
                                                LST_REPO[0].SelectedIndex = i;
                                                if (Conversion.Val(LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3))) == Conversion.Val(sRep_ID))
                                                {
                                                    LST_REPO[0].Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_REPO[0]));
                                                    if (Conversion.Val(sRep_ID) <= 9)
                                                    {
                                                        LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 5) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                                    }
                                                    else if (Conversion.Val(sRep_ID) >= 10)
                                                    {
                                                        LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 4) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                                    }
                                                }
                                            }
                                        };
                                    }
                                }
                            }
                        }
                        LST_REPO[0].SelectedIndex = -1;
                        CMD_ACT_REP.Enabled = false;

                        txtTexto_Cat[0].Text = txtTexto[0].Text;
                        txtTexto_Cat[1].Text = txtTexto[1].Text;
                        mkbMaskebox_Cat[0].CtlText = mkbMaskebox[0].CtlText;
                        mkbMaskebox_Cat[1].CtlText = mkbMaskebox[3].CtlText;
                        mkbMaskebox_Cat[2].CtlText = mkbMaskebox[2].CtlText;

                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_estruct_gastos";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + CORVAR.lgblNumEmpresa.ToString();

                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    lEstruc_Gastos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                                };
                                CORVAR.pszgblsql = "select";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_id,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_name";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id =" + lEstruc_Gastos.ToString();

                                if (CORPROC2.Cuenta_Registros() > 0)
                                {
                                    if (CORPROC2.Obtiene_Registros() != 0)
                                    {
                                        iCont = 0;
                                        iRenCat = 0;
                                        CMB_CAT.Items.Clear();
                                        LST_CAT.Items.Clear();

                                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                        {
                                            CMB_CAT.Items.Insert(iCont, VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                            VB6.SetItemData(CMB_CAT, iCont, Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
                                            if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                            {
                                                LST_CAT.Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                            }
                                            else if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length >= 10)
                                            {
                                                LST_CAT.Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                            }
                                            iCont++;
                                            iRenCat++;
                                        };
                                        CORVAR.pszgblsql = "select";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " a.cat_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " b.exp_cat_name,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " str(a.cat_limite_gasto,12,2),";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " a.cat_uso";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUCT01 a, MTCCAT01 b";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where b.exp_cat_id = a.cat_id";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_prefijo = a.eje_prefijo";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.gpo_banco = a.gpo_banco";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.exp_struc_id = " + lEstruc_Gastos.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = " + Conversion.Val(mkbMaskebox_Cat[0].CtlText).ToString();

                                        reg = CORPROC2.Cuenta_Registros();
                                        if (reg >= 1)
                                        {
                                            if (CORPROC2.Obtiene_Registros() != 0)
                                            {

                                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                                {
                                                    sCat_Id = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                                    sCat_Nombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                                    sLimit = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                                                    sPor_Uso = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                                    for (int i = 0; i <= iRenCat - 1; i++)
                                                    {
                                                        LST_CAT.SelectedIndex = i;
                                                        if (Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 3))) == Conversion.Val(sCat_Id))
                                                        {
                                                            LST_CAT.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_CAT));
                                                            if (Conversion.Val(sCat_Id) <= 9)
                                                            {
                                                                LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 5) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                            }
                                                            else if (Conversion.Val(sCat_Id) >= 10)
                                                            {
                                                                LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 4) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                            }
                                                        }
                                                    }
                                                };
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La Estructura de Gastos de la Empresa:" + CORVAR.lgblNumEmpresa.ToString() + " no tiene Categorias.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            //MsgBox "No se encontro ninguna Estructura de Gastos de la Empresa:" & lgblNumEmpresa, vbInformation + vbOKOnly, "Tarjeta Corporativa"
                        }
                        LST_CAT.SelectedIndex = -1;
                        CMD_ACT_CAT.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    this.Cursor = Cursors.Default;

                    break;
                case "C":
                    txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();
                    if (Strings.Len(txtTexto[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }
                    Formato.bgForma = true;
                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                    mkbMaskebox[0].Format = Formato.sMascara(Formato.iTipo.Unidad);
                    mkbMaskebox[1].Format = Formato.sMascara(Formato.iTipo.Unidad);
                    mkbMaskebox[2].Format = "00";
                    txtTexto[0].Enabled = false;
                    txtTexto[1].Enabled = false;
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).ToString();
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                mkbMaskebox[0].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                mkbMaskebox[1].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)).ToString();
                                mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim();
                                mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
                                mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
                                CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim());
                                txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
                                mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim();
                                mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
                                mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
                                mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
                                mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim();
                                txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim();
                            };
                            ID_MEE_ALT_PB.Visible = false;
                        }
                        Des_Habilita_Forma(2);

                        //Tab Reportes
                        txtTexto_Rep[0].Text = txtTexto[0].Text;
                        txtTexto_Rep[1].Text = txtTexto[1].Text;
                        mkbMaskebox_Rep[0].CtlText = mkbMaskebox[0].CtlText;
                        mkbMaskebox_Rep[1].CtlText = mkbMaskebox[3].CtlText;
                        mkbMaskebox_Rep[2].CtlText = mkbMaskebox[2].CtlText;
                        CORVAR.pszgblsql = "select distinct convert(int,report_id),report_name from MTCREP01";
                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {
                                iRenRep = 0;
                                LST_REPO[0].Items.Clear();

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                    {
                                        LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                    }
                                    else if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) >= 10)
                                    {
                                        LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                    }
                                    iRenRep++;
                                };
                                CORVAR.pszgblsql = "select";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct (a.report_id),";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " b.report_name,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_gen,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_freq,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_details,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_depth";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCURP01 a,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCREP01 b";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.report_id = b.report_id";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.reporting_gen = 'Y'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo=" + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco=" + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id=" + mkbMaskebox[0].CtlText;

                                reg = CORPROC2.Cuenta_Registros();
                                if (reg >= 1)
                                {
                                    if (CORPROC2.Obtiene_Registros() != 0)
                                    {

                                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                        {
                                            sRep_ID = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                            sRep_Name = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                            sFreq = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                            sDetail = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                            sDepth = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                            for (int i = 0; i <= iRenRep - 1; i++)
                                            {
                                                LST_REPO[0].SelectedIndex = i;
                                                if (Conversion.Val(LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3))) == Conversion.Val(sRep_ID))
                                                {
                                                    LST_REPO[0].Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_REPO[0]));
                                                    if (Conversion.Val(sRep_ID) <= 9)
                                                    {
                                                        LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 5) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                                    }
                                                    else if (Conversion.Val(sRep_ID) >= 10)
                                                    {
                                                        LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 4) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                                    }
                                                }
                                            }
                                        };
                                    }
                                }
                            }
                        }
                        FRAM_REP[0].Enabled = false;
                        LST_REPO[0].SelectedIndex = -1;
                        LST_REPO[0].Enabled = false;

                        txtTexto_Cat[0].Text = txtTexto[0].Text;
                        txtTexto_Cat[1].Text = txtTexto[1].Text;
                        mkbMaskebox_Cat[0].CtlText = mkbMaskebox[0].CtlText;
                        mkbMaskebox_Cat[1].CtlText = mkbMaskebox[3].CtlText;
                        mkbMaskebox_Cat[2].CtlText = mkbMaskebox[2].CtlText;

                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_estruct_gastos";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + CORVAR.lgblNumEmpresa.ToString();

                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    lEstruc_Gastos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                                };
                                CORVAR.pszgblsql = "select";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_id,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_name";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id =" + lEstruc_Gastos.ToString();

                                if (CORPROC2.Cuenta_Registros() > 0)
                                {
                                    if (CORPROC2.Obtiene_Registros() != 0)
                                    {
                                        iRenCat = 0;
                                        LST_CAT.Items.Clear();

                                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                        {
                                            if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                            {
                                                LST_CAT.Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                            }
                                            else if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length >= 10)
                                            {
                                                LST_CAT.Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                            }
                                            iRenCat++;
                                        };
                                        CORVAR.pszgblsql = "select";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " a.cat_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " b.exp_cat_name,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " str(a.cat_limite_gasto,12,2),";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " a.cat_uso";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUCT01 a, MTCCAT01 b";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where b.exp_cat_id = a.cat_id";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_prefijo = a.eje_prefijo";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.gpo_banco = a.gpo_banco";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.exp_struc_id = " + lEstruc_Gastos.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = " + Conversion.Val(mkbMaskebox_Cat[0].CtlText).ToString();

                                        reg = CORPROC2.Cuenta_Registros();
                                        if (reg >= 1)
                                        {
                                            if (CORPROC2.Obtiene_Registros() != 0)
                                            {

                                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                                {
                                                    sCat_Id = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                                    sCat_Nombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                                    sLimit = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                                                    sPor_Uso = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                                    for (int i = 0; i <= iRenCat - 1; i++)
                                                    {
                                                        LST_CAT.SelectedIndex = i;
                                                        if (Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 3))) == Conversion.Val(sCat_Id))
                                                        {
                                                            LST_CAT.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_CAT));
                                                            if (Conversion.Val(sCat_Id) <= 9)
                                                            {
                                                                LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 5) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                            }
                                                            else if (Conversion.Val(sCat_Id) >= 10)
                                                            {
                                                                LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 4) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                            }
                                                        }
                                                    }
                                                };
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La Estructura de Gastos de la Empresa:" + CORVAR.lgblNumEmpresa.ToString() + " no tiene Categorias.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            //MsgBox "No se encontro ninguna Estructura de Gastos de la Empresa:" & lgblNumEmpresa, vbInformation + vbOKOnly, "Tarjeta Corporativa"
                        }
                        FRAM_CAT.Enabled = false;
                        LST_CAT.SelectedIndex = -1;
                        LST_CAT.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    this.Cursor = Cursors.Default;

                    break;
                case "D":
                    if (Formato.bgForma)
                    {
                        txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                        txtTexto[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();
                        if (Strings.Len(txtTexto[1].Text) < 16)
                        {
                            Formato.bgForma = false;
                            return;
                        }
                        Formato.bgForma = true;
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                        mkbMaskebox[0].Format = Formato.sMascara(Formato.iTipo.Unidad);
                        mkbMaskebox[1].Format = Formato.sMascara(Formato.iTipo.Unidad);
                        mkbMaskebox[2].Format = "00";
                        txtTexto[0].Enabled = false;
                        txtTexto[1].Enabled = false;
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + Formato.sgUnit_ID;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_name = '" + Formato.sgName_Unit + "'";
                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    mkbMaskebox[0].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                    mkbMaskebox[1].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)).ToString();
                                    mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                    mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                    mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                    mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                    mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim();
                                    mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
                                    mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
                                    CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim());
                                    txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
                                    mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim();
                                    mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
                                    mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
                                    mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
                                    mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim();
                                    txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim();
                                };
                                ID_MEE_ALT_PB.Visible = false;
                            }
                            Des_Habilita_Forma(2);

                            txtTexto_Rep[0].Text = txtTexto[0].Text;
                            txtTexto_Rep[1].Text = txtTexto[1].Text;
                            mkbMaskebox_Rep[0].CtlText = mkbMaskebox[0].CtlText;
                            mkbMaskebox_Rep[1].CtlText = mkbMaskebox[3].CtlText;
                            mkbMaskebox_Rep[2].CtlText = mkbMaskebox[2].CtlText;
                            CORVAR.pszgblsql = "select distinct convert(int,report_id),report_name from MTCREP01";
                            if (CORPROC2.Cuenta_Registros() > 0)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {
                                    iRenRep = 0;
                                    LST_REPO[0].Items.Clear();

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                        {
                                            LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                        }
                                        else if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) >= 10)
                                        {
                                            LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                        }
                                        iRenRep++;
                                    };
                                    CORVAR.pszgblsql = "select";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct (a.report_id),";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " b.report_name,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_gen,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_freq,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_details,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_depth";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCURP01 a,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCREP01 b";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.report_id = b.report_id";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.reporting_gen = 'Y'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo=" + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco=" + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = " + Formato.sgUnit_ID;

                                    reg = CORPROC2.Cuenta_Registros();
                                    if (reg >= 1)
                                    {
                                        if (CORPROC2.Obtiene_Registros() != 0)
                                        {

                                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                            {
                                                sRep_ID = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                                sRep_Name = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                                sFreq = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                                sDetail = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                                sDepth = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                                for (int i = 0; i <= iRenRep - 1; i++)
                                                {
                                                    LST_REPO[0].SelectedIndex = i;
                                                    if (Conversion.Val(LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3))) == Conversion.Val(sRep_ID))
                                                    {
                                                        LST_REPO[0].Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_REPO[0]));
                                                        if (Conversion.Val(sRep_ID) <= 9)
                                                        {
                                                            LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 5) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                                        }
                                                        else if (Conversion.Val(sRep_ID) >= 10)
                                                        {
                                                            LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 4) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                                        }
                                                    }
                                                }
                                            };
                                        }
                                    }
                                }
                            }
                            FRAM_REP[0].Enabled = false;
                            LST_REPO[0].SelectedIndex = -1;
                            LST_REPO[0].Enabled = false;

                            txtTexto_Cat[0].Text = txtTexto[0].Text;
                            txtTexto_Cat[1].Text = txtTexto[1].Text;
                            mkbMaskebox_Cat[0].CtlText = mkbMaskebox[0].CtlText;
                            mkbMaskebox_Cat[1].CtlText = mkbMaskebox[3].CtlText;
                            mkbMaskebox_Cat[2].CtlText = mkbMaskebox[2].CtlText;

                            CORVAR.pszgblsql = "select";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_estruct_gastos";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + CORVAR.lgblNumEmpresa.ToString();

                            if (CORPROC2.Cuenta_Registros() > 0)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        lEstruc_Gastos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                                    };
                                    CORVAR.pszgblsql = "select";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_id,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_name";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id =" + lEstruc_Gastos.ToString();

                                    if (CORPROC2.Cuenta_Registros() > 0)
                                    {
                                        if (CORPROC2.Obtiene_Registros() != 0)
                                        {
                                            iRenCat = 0;
                                            LST_CAT.Items.Clear();

                                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                            {
                                                if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                                {
                                                    LST_CAT.Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                                }
                                                else if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length >= 10)
                                                {
                                                    LST_CAT.Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                                }
                                                iRenCat++;
                                            };
                                            CORVAR.pszgblsql = "select";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " a.cat_id,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " b.exp_cat_name,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " str(a.cat_limite_gasto,12,2),";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " a.cat_uso";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUCT01 a, MTCCAT01 b";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where b.exp_cat_id = a.cat_id";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_prefijo = a.eje_prefijo";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.gpo_banco = a.gpo_banco";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.exp_struc_id = " + lEstruc_Gastos.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = " + Conversion.Val(Formato.sgUnit_ID).ToString();

                                            reg = CORPROC2.Cuenta_Registros();
                                            if (reg >= 1)
                                            {
                                                if (CORPROC2.Obtiene_Registros() != 0)
                                                {

                                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                                    {
                                                        sCat_Id = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                                        sCat_Nombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                                        sLimit = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                                                        sPor_Uso = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                                        for (int i = 0; i <= iRenCat - 1; i++)
                                                        {
                                                            LST_CAT.SelectedIndex = i;
                                                            if (Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 3))) == Conversion.Val(sCat_Id))
                                                            {
                                                                LST_CAT.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_CAT));
                                                                if (Conversion.Val(sCat_Id) <= 9)
                                                                {
                                                                    LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 5) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                                }
                                                                else if (Conversion.Val(sCat_Id) >= 10)
                                                                {
                                                                    LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 4) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                                }
                                                            }
                                                        }
                                                    };
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("La Estructura de Gastos de la Empresa:" + CORVAR.lgblNumEmpresa.ToString() + " no tiene Categorias.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                //MsgBox "No se encontro ninguna Estructura de Gastos de la Empresa:" & lgblNumEmpresa, vbInformation + vbOKOnly, "Tarjeta Corporativa"
                            }
                            FRAM_CAT.Enabled = false;
                            LST_CAT.SelectedIndex = -1;
                            LST_CAT.Enabled = false;

                        }
                        else
                        {
                            MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        //MsgBox"No se encontro ninguna Unidad Similar",vbInformation +vbOKOnly ,"Tarjeta Corporativa"
                    }

                    break;
                case "E":
                    if (Formato.bgForma)
                    {
                        txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                        txtTexto[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();
                        if (Strings.Len(txtTexto[1].Text) < 16)
                        {
                            Formato.bgForma = false;
                            return;
                        }
                        Formato.bgForma = true;
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                        mkbMaskebox[0].Format = Formato.sMascara(Formato.iTipo.Unidad);
                        mkbMaskebox[1].Format = Formato.sMascara(Formato.iTipo.Unidad);
                        mkbMaskebox[2].Format = "00";
                        txtTexto[0].Enabled = false;
                        txtTexto[1].Enabled = false;
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + Formato.sgUnit_ID;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_name = '" + Formato.sgName_Unit + "'";
                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    mkbMaskebox[0].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                    mkbMaskebox[0].Enabled = false;
                                    mkbMaskebox[1].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)).ToString();
                                    mkbMaskebox[1].Enabled = false;
                                    mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                    mkbMaskebox[2].Enabled = false;
                                    mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                    mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                    mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                    mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim();
                                    mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
                                    mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
                                    CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim());
                                    txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
                                    mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim();
                                    mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
                                    mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
                                    mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
                                    mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim();
                                    txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim();
                                };
                            }

                            txtTexto_Rep[0].Text = txtTexto[0].Text;
                            txtTexto_Rep[1].Text = txtTexto[1].Text;
                            mkbMaskebox_Rep[0].CtlText = mkbMaskebox[0].CtlText;
                            mkbMaskebox_Rep[1].CtlText = mkbMaskebox[3].CtlText;
                            mkbMaskebox_Rep[2].CtlText = mkbMaskebox[2].CtlText;
                            CORVAR.pszgblsql = "select distinct convert(int,report_id),report_name from MTCREP01";
                            if (CORPROC2.Cuenta_Registros() > 0)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {
                                    iCont = 0;
                                    iRenRep = 0;
                                    CMB_REPO[0].Items.Clear();
                                    LST_REPO[0].Items.Clear();

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        CMB_REPO[0].Items.Insert(iCont, VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                        VB6.SetItemData(CMB_REPO[0], iCont, Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
                                        if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                        {
                                            LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                        }
                                        else if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) >= 10)
                                        {
                                            LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                                        }
                                        iCont++;
                                        iRenRep++;
                                    };
                                    CORVAR.pszgblsql = "select";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct (a.report_id),";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " b.report_name,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_gen,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_freq,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_details,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_depth";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCURP01 a,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " MTCREP01 b";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.report_id = b.report_id";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.reporting_gen = 'Y'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo=" + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco=" + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = " + Formato.sgUnit_ID;

                                    reg = CORPROC2.Cuenta_Registros();
                                    if (reg >= 1)
                                    {
                                        if (CORPROC2.Obtiene_Registros() != 0)
                                        {

                                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                            {
                                                sRep_ID = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                                sRep_Name = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                                sFreq = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                                sDetail = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                                sDepth = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                                for (int i = 0; i <= iRenRep - 1; i++)
                                                {
                                                    LST_REPO[0].SelectedIndex = i;
                                                    if (Conversion.Val(LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3))) == Conversion.Val(sRep_ID))
                                                    {
                                                        LST_REPO[0].Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_REPO[0]));
                                                        if (Conversion.Val(sRep_ID) <= 9)
                                                        {
                                                            LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 5) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                                        }
                                                        else if (Conversion.Val(sRep_ID) >= 10)
                                                        {
                                                            LST_REPO[0].Items.Insert(i, Conversion.Val(sRep_ID).ToString() + new String(' ', 4) + sRep_Name + new String(' ', 8) + "Y" + new String(' ', 8) + sFreq + new String(' ', 8) + sDetail + new String(' ', 8) + sDepth);
                                                        }
                                                    }
                                                }
                                            };
                                        }
                                    }
                                }
                            }
                            LST_REPO[0].SelectedIndex = -1;
                            CMD_ACT_REP.Enabled = false;

                            txtTexto_Cat[0].Text = txtTexto[0].Text;
                            txtTexto_Cat[1].Text = txtTexto[1].Text;
                            mkbMaskebox_Cat[0].CtlText = mkbMaskebox[0].CtlText;
                            mkbMaskebox_Cat[1].CtlText = mkbMaskebox[3].CtlText;
                            mkbMaskebox_Cat[2].CtlText = mkbMaskebox[2].CtlText;

                            CORVAR.pszgblsql = "select";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_estruct_gastos";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + CORVAR.lgblNumEmpresa.ToString();

                            if (CORPROC2.Cuenta_Registros() > 0)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        lEstruc_Gastos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                                    };
                                    CORVAR.pszgblsql = "select";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_id,";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_name";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id =" + lEstruc_Gastos.ToString();

                                    if (CORPROC2.Cuenta_Registros() > 0)
                                    {
                                        if (CORPROC2.Obtiene_Registros() != 0)
                                        {
                                            iCont = 0;
                                            iRenCat = 0;
                                            CMB_CAT.Items.Clear();
                                            LST_CAT.Items.Clear();

                                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                            {
                                                CMB_CAT.Items.Insert(iCont, VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                                VB6.SetItemData(CMB_CAT, iCont, Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
                                                if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                                                {
                                                    LST_CAT.Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                                }
                                                else if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length >= 10)
                                                {
                                                    LST_CAT.Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                                }
                                                iCont++;
                                                iRenCat++;
                                            };
                                            CORVAR.pszgblsql = "select";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " a.cat_id,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " b.exp_cat_name,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " str(a.cat_limite_gasto,12,2),";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " a.cat_uso";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUCT01 a, MTCCAT01 b";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where b.exp_cat_id = a.cat_id";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.eje_prefijo = a.eje_prefijo";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.gpo_banco = a.gpo_banco";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.exp_struc_id = " + lEstruc_Gastos.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = " + Conversion.Val(Formato.sgUnit_ID).ToString();

                                            reg = CORPROC2.Cuenta_Registros();
                                            if (reg >= 1)
                                            {
                                                if (CORPROC2.Obtiene_Registros() != 0)
                                                {

                                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                                    {
                                                        sCat_Id = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                                        sCat_Nombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                                        sLimit = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                                                        sPor_Uso = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                                        for (int i = 0; i <= iRenCat - 1; i++)
                                                        {
                                                            LST_CAT.SelectedIndex = i;
                                                            if (Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 3))) == Conversion.Val(sCat_Id))
                                                            {
                                                                LST_CAT.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_CAT));
                                                                if (Conversion.Val(sCat_Id) <= 9)
                                                                {
                                                                    LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 5) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                                }
                                                                else if (Conversion.Val(sCat_Id) >= 10)
                                                                {
                                                                    LST_CAT.Items.Insert(i, Conversion.Val(sCat_Id).ToString() + new String(' ', 4) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                                }
                                                            }
                                                        }
                                                    };
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("La Estructura de Gastos de la Empresa:" + CORVAR.lgblNumEmpresa.ToString() + " no tiene Categorias.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                //MsgBox "No se encontro ninguna Estructura de Gastos de la Empresa:" & lgblNumEmpresa, vbInformation + vbOKOnly, "Tarjeta Corporativa"
                            }
                            LST_CAT.SelectedIndex = -1;
                            CMD_ACT_CAT.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        //MsgBox"No se encontro ninguna Unidad Similar",vbInformation +vbOKOnly ,"Tarjeta Corporativa"
                    }


                    break;
            }
        }

        private void ID_MEE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            int modif = 0;
            string cad_Rep = String.Empty;
            string cad_Cat = String.Empty;
            try
            {

                switch (Formato.sgForma)
                {
                    case "A":
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "insert into MTCUNI01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_num,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_last_upd_userid,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_last_upd_date,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_last_upd_time) ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblNumGrupo.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mkbMaskebox[0].CtlText;
                            if (!bNivPadre)
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",NULL";
                            }
                            else if (bNivPadre)
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mkbMaskebox[1].CtlText;
                            }
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mkbMaskebox[2].CtlText;
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[3].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[4].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[5].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[6].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[7].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[8].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSGeneral.asgEstados[0, cmbCombo[0].SelectedIndex] + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + txtTexto[2].Text + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[9].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[10].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[11].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[12].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[13].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + txtTexto[3].Text + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserID + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20),getdate(),112))";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " + convert(int, datepart(mi,getdate())))";

                            if (CORPROC2.Modifica_Registro() == 1)
                            {
                                if (!bNivPadre)
                                {
                                    CORVAR.pszgblsql = "update MTCEJE01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_centro_c = '" + mkbMaskebox[0].CtlText.Trim() + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = 0";
                                    if (CORPROC2.Modifica_Registro() == 1)
                                    {
                                    }
                                }
                                for (int i = 0; i <= iRenRep - 1; i++)
                                {
                                    LST_REPO[0].SelectedIndex = i;
                                    cad_Rep = LST_REPO[0].Text;
                                    if (Strings.Mid(cad_Rep, 45, 1).Trim() == "Y")
                                    {
                                        CORVAR.pszgblsql = "insert into MTCURP01";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " report_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_gen,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_freq,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_details,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_depth,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_userid,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_date,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_time)";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(mkbMaskebox_Rep[0].CtlText).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3)).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 45, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 54, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 63, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 72, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserID + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20), getdate(),112))";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " + convert(int, datepart(mi,getdate())))";
                                    }
                                    else
                                    {
                                        CORVAR.pszgblsql = "insert into MTCURP01";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " report_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_gen,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_freq,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_details,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_depth,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_userid,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_date,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_time)";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(mkbMaskebox[0].CtlText).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3)).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 45, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", NULL";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", NULL";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", NULL";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserID + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20), getdate(),112))";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " + convert(int, datepart(mi,getdate())))";
                                    }
                                    if (CORPROC2.Modifica_Registro() != 1)
                                    {
                                        MessageBox.Show("No se pudo dar de alta el Reporte: " + Conversion.Val(mkbMaskebox_Rep[0].CtlText).ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                for (int i = 0; i <= iRenCat - 1; i++)
                                {
                                    LST_CAT.SelectedIndex = i;
                                    cad_Cat = LST_CAT.Text;
                                    if (Strings.Mid(LST_CAT.Text, 51, 10).Trim() != "")
                                    {
                                        CORVAR.pszgblsql = "insert into MTCUCT01";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_limite_gasto,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_uso)";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(mkbMaskebox[0].CtlText).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 5))).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Strings.Mid(cad_Cat, 51, 10).Trim();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(Strings.Mid(cad_Cat, 70, 10).Trim()).ToString() + ")";
                                    }
                                    else
                                    {
                                        CORVAR.pszgblsql = "insert into MTCUCT01";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_id,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_limite_gasto,";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_uso)";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(mkbMaskebox[0].CtlText).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 5))).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",NULL";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",NULL)";
                                    }
                                    if (CORPROC2.Modifica_Registro() != 1)
                                    {
                                        MessageBox.Show("No se pudo dar de alta la Categoría", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Se ha dado de alta la Unidad: " + mkbMaskebox[0].CtlText + " de la Unidad Padre: " + mkbMaskebox[1].CtlText, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CORCTUNI.DefInstance.ID_CEE_UNI_LB.Items.Add(StringsHelper.Format(mkbMaskebox[0].CtlText, Formato.sMascara(Formato.iTipo.Unidad)) + CORCONST.SPC_TRES + mkbMaskebox[3].CtlText.Trim());
                                Limpia_Forma();
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("No se pudo dar de alta la Unidad: " + mkbMaskebox[0].CtlText, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta algun dato o uno de los datos no es valido para poder dar de alta la Unidad", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Cursor = Cursors.Default;

                        break;
                    case "B":
                    case "E":
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "update MTCUNI01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " set unit_name = '" + mkbMaskebox[3].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_receipient_name = '" + mkbMaskebox[4].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_calle = '" + mkbMaskebox[5].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_col = '" + mkbMaskebox[6].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_pob = '" + mkbMaskebox[7].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_city = '" + mkbMaskebox[8].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_state = '" + CRSGeneral.asgEstados[0, cmbCombo[0].SelectedIndex] + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_ctry = '" + txtTexto[2].Text + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_zip = '" + mkbMaskebox[9].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_ph = '" + mkbMaskebox[10].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_ext = '" + mkbMaskebox[11].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_fax = '" + mkbMaskebox[12].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_cel = '" + mkbMaskebox[13].CtlText + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_email = '" + txtTexto[3].Text + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_last_upd_userid = '" + CRSParametros.sgUserID + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_last_upd_date = convert(int,convert(char(20), getdate(),112))";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_last_upd_time = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + mkbMaskebox[0].CtlText;
                            if (Conversion.Val(mkbMaskebox[1].CtlText) != 0)
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_parent_id = " + mkbMaskebox[1].CtlText;
                            }
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and nivel_num = " + mkbMaskebox[2].CtlText;

                            if (CORPROC2.Modifica_Registro() == 1)
                            {
                                for (int i = 0; i <= iRenRep - 1; i++)
                                {
                                    LST_REPO[0].SelectedIndex = i;
                                    cad_Rep = LST_REPO[0].Text;
                                    if (Strings.Mid(cad_Rep, 45, 1).Trim() == "Y")
                                    {
                                        CORVAR.pszgblsql = "update MTCURP01";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set reporting_gen = '" + Strings.Mid(cad_Rep, 45, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", reporting_freq = '" + Strings.Mid(cad_Rep, 54, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", reporting_details = '" + Strings.Mid(cad_Rep, 63, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", reporting_depth = '" + Strings.Mid(cad_Rep, 72, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_userid = '" + CRSParametros.sgUserID + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_date = convert(int,convert(char(20),getdate(),112))";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_time = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + Conversion.Val(mkbMaskebox[0].CtlText).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and report_id = '" + cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3)).Trim() + "'";
                                    }
                                    else
                                    {
                                        CORVAR.pszgblsql = "update MTCURP01";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set reporting_gen = '" + Strings.Mid(cad_Rep, 45, 1).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", reporting_freq = NULL ";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", reporting_details = NULL ";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", reporting_depth = NULL ";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_userid = '" + CRSParametros.sgUserID + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_date = convert(int,convert(char(20),getdate(),112))";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_time = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + Conversion.Val(mkbMaskebox[0].CtlText).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and report_id = '" + cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3)).Trim() + "'";
                                    }
                                    modif = CORPROC2.Modifica_Registro();
                                    if (modif != 1)
                                    {
                                        MessageBox.Show("No se pudo dar de alta el Reporte", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                //Se va a borrar todas las categorias para poder darlas de alta otra vez.
                                CORVAR.pszgblsql = "delete from MTCUCT01";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + Conversion.Val(mkbMaskebox[0].CtlText).ToString();
                                if (CORPROC2.Modifica_Registro() >= 1)
                                {
                                    for (int i = 0; i <= iRenCat - 1; i++)
                                    {
                                        LST_CAT.SelectedIndex = i;
                                        cad_Cat = LST_CAT.Text;
                                        if (Strings.Mid(LST_CAT.Text, 51, 10).Trim() != "")
                                        {
                                            CORVAR.pszgblsql = "insert into MTCUCT01";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_id,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_limite_gasto,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_uso)";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(mkbMaskebox[0].CtlText).ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 5))).ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Strings.Mid(cad_Cat, 51, 10).Trim();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(Strings.Mid(cad_Cat, 70, 10).Trim()).ToString() + ")";
                                        }
                                        else
                                        {
                                            CORVAR.pszgblsql = "insert into MTCUCT01";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_id,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_limite_gasto,";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " cat_uso)";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(mkbMaskebox[0].CtlText).ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 5))).ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",NULL";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",NULL)";
                                        }
                                        if (CORPROC2.Modifica_Registro() != 1)
                                        {
                                            MessageBox.Show("No se pudo dar de alta el cambio de la Categoría", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                else
                                {
                                    //No se pudieron eliminar las categorias
                                }
                                for (int i = 0; i <= CORCTUNI.DefInstance.ID_CEE_UNI_LB.Items.Count - 1; i++)
                                {
                                    CORCTUNI.DefInstance.ID_CEE_UNI_LB.SelectedIndex = i;
                                    if (Conversion.Val(CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Length, 6))) == Conversion.Val(mkbMaskebox[0].CtlText))
                                    {
                                        CORCTUNI.DefInstance.ID_CEE_UNI_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(CORCTUNI.DefInstance.ID_CEE_UNI_LB));
                                        CORCTUNI.DefInstance.ID_CEE_UNI_LB.Items.Add(StringsHelper.Format(Conversion.Val(mkbMaskebox[0].CtlText), Formato.sMascara(Formato.iTipo.Unidad)) + CORCONST.SPC_TRES + mkbMaskebox[3].CtlText.Trim());
                                    }
                                }
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Se ha dado de alta el cambio de la Unidad: " + mkbMaskebox[0].CtlText, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudieron cambiar los datos de la Unidad: " + mkbMaskebox[0].CtlText, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpia_Forma();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta algun dato o uno de los datos no es valido para poder dar de alta la Unidad", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Cursor = Cursors.Default;
                        break;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEE_ALT_PB_Click)", e);
            }
        }

        private void ID_MEE_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;
            CORCTUNI tempLoadForm = CORCTUNI.DefInstance;
            this.Close();
        }

        private void LST_REPO_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            string cad_Rep = String.Empty;
            int i = 0;
            if (KeyAscii == ((int)Keys.Delete))
            {
                i = ListBoxHelper.GetSelectedIndex(LST_REPO[0]);
                cad_Rep = LST_REPO[0].Text;
                LST_REPO[0].Items.RemoveAt((short)i);
                if (Conversion.Val(cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3))) <= 9)
                {
                    LST_REPO[0].Items.Insert(i, Conversion.Val(cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3))).ToString() + new String(' ', 5) + Strings.Mid(cad_Rep, 7, 30) + new String(' ', 8) + "N");
                }
                else
                {
                    LST_REPO[0].Items.Insert(i, Conversion.Val(cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3))).ToString() + new String(' ', 4) + Strings.Mid(cad_Rep, 7, 30) + new String(' ', 8) + "N");
                }
                CMB_REPO[0].Focus();
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void mkbMaskebox_Cat_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int Index = Array.IndexOf(mkbMaskebox_Cat, eventSender);
            switch (Index)
            {
                case 3:
                    if (mkbMaskebox_Cat[Index].CtlText != "")
                    {
                        sLimit = mkbMaskebox_Cat[Index].CtlText;
                        mkbMaskebox_Cat[4].Focus();
                        Cancel = false;
                    }
                    else
                    {
                        Cancel = true;
                    }
                    break;
                case 4:
                    if (mkbMaskebox_Cat[Index].CtlText != "")
                    {
                        if (Conversion.Val(mkbMaskebox_Cat[4].CtlText) <= 100)
                        {
                            if (Conversion.Val(mkbMaskebox_Cat[4].CtlText) >= 0)
                            {
                                sPor_Uso = mkbMaskebox_Cat[Index].CtlText;
                                CMD_ACT_CAT.Enabled = true;
                                CMD_ACT_CAT.Focus();
                                Cancel = false;
                            }
                            else
                            {
                                MessageBox.Show("El Porcentaje de Uso no puede ser Mayor a 100", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                mkbMaskebox_Cat[Index].CtlText = "";
                                Cancel = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Porcentaje de Uso no puede ser Mayor a 100", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mkbMaskebox_Cat[Index].CtlText = "";
                            Cancel = true;
                        }
                    }
                    else
                    {
                        Cancel = true;
                    }
                    break;
            }
            eventArgs.Cancel = Cancel;
        }

        private void mkbMaskebox_Rep_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (mkbMaskebox_Rep[0].CtlText != "" && mkbMaskebox_Rep[1].CtlText != "" && mkbMaskebox_Rep[1].CtlText != "")
            {
                FRAM_REP[0].Enabled = true;
            }
            eventArgs.Cancel = Cancel;
        }

        private void mkbMaskebox_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int Index = Array.IndexOf(mkbMaskebox, eventSender);
            int iCont = 0;
            switch (Index)
            {

                case 0:
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        mkbMaskebox[15].CtlText = "";
                        mkbMaskebox[15].Enabled = false;
                        mkbMaskebox[16].CtlText = "";
                        mkbMaskebox[16].Enabled = false;
                        SSTabHelper.SetTabEnabled(tabStab[0], 1, true);
                        SSTabHelper.SetTabEnabled(tabStab[0], 2, true);
                        mkbMaskebox_Rep[0].CtlText = mkbMaskebox[0].CtlText;
                        mkbMaskebox_Cat[0].CtlText = mkbMaskebox[0].CtlText;
                    }

                    break;
                case 1:
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        if (!bValidaUniPadre())
                        {
                            mkbMaskebox[Index].CtlText = "";
                            Cancel = true;
                        }
                    }
                    else
                    {
                        //        MsgBox "Necesitas llenar el campo de Unidad Padre para poder continuar", vbInformation + vbOKOnly, "Tarjeta Corporativa"
                        //        Cancel = True
                    }

                    break;
                case 2:
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        if (!bValidaNiv())
                        {
                            mkbMaskebox[Index].CtlText = "";
                            Cancel = true;
                        }
                        else
                        {
                            mkbMaskebox_Rep[2].CtlText = mkbMaskebox[2].CtlText;
                            mkbMaskebox_Cat[2].CtlText = mkbMaskebox[2].CtlText;
                        }
                    }
                    else
                    {
                        //        MsgBox "Necesitas llenar el campo de Nivel de Unidad para poder continuar", vbInformation + vbOKOnly, "Tarjeta Corporativa"
                        //        Cancel = True
                    }

                    break;
                case 3:
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        mkbMaskebox_Rep[1].CtlText = mkbMaskebox[Index].CtlText;
                        mkbMaskebox_Cat[1].CtlText = mkbMaskebox[Index].CtlText;
                        if (mkbMaskebox[0].CtlText != "" && mkbMaskebox[2].CtlText != "" && mkbMaskebox[3].CtlText != "")
                        {
                            FRAM_REP[0].Enabled = true;
                            FRAM_CAT.Enabled = true;
                        }
                    }
                    break;
                case 16:
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));

                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + mkbMaskebox[15].CtlText;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and nivel_num = " + mkbMaskebox[16].CtlText;

                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    mkbMaskebox[0].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                    mkbMaskebox[1].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)).ToString();
                                    mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                    mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                    mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                                    mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim();
                                    mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim();
                                    mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
                                    mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim();
                                    cmbCombo[0].Text = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim();
                                    txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
                                    mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim();
                                    mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim();
                                    mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim();
                                    mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim();
                                    mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim();
                                    txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim();

                                    mkbMaskebox_Rep[0].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                    mkbMaskebox_Rep[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                    mkbMaskebox_Rep[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();

                                    mkbMaskebox_Cat[0].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                    mkbMaskebox_Cat[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                    mkbMaskebox_Cat[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                };
                            }
                            Des_Habilita_Forma(1);
                            CORVAR.pszgblsql = "select distinct(report_name) from MTCREP01";
                            if (CORPROC2.Cuenta_Registros() > 0)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {
                                    iCont = 1;
                                    LST_REPO[0].Items.Clear();

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        CMB_REPO[0].Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim());
                                        if (iCont <= 9)
                                        {
                                            LST_REPO[0].Items.Add(iCont.ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 8) + "N");
                                        }
                                        else if (iCont >= 10)
                                        {
                                            LST_REPO[0].Items.Add(iCont.ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 8) + "N");
                                        }
                                        iCont++;
                                    };
                                }
                            }
                            CORVAR.pszgblsql = "select emp_estruct_gastos from MTCEMP01 where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                            if (CORPROC2.Cuenta_Registros() > 0)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        lEstruc_Gastos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                                    };
                                    CORVAR.pszgblsql = "select exp_cat_id,exp_cat_name from MTCCAT01 where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and exp_struc_id =" + lEstruc_Gastos.ToString();
                                    if (CORPROC2.Cuenta_Registros() > 0)
                                    {
                                        if (CORPROC2.Obtiene_Registros() != 0)
                                        {
                                            iCont = 1;
                                            LST_CAT.Items.Clear();

                                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                            {
                                                CMB_CAT.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                                if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length <= 9)
                                                {
                                                    LST_CAT.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                                }
                                                else if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length >= 10)
                                                {
                                                    LST_CAT.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                                }
                                            };
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("La Estructura de Gastos de la Empresa:" + CORVAR.lgblNumEmpresa.ToString() + " no tiene Categorias.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                //MsgBox "No se encontro ninguna Estructura de Gastos de la Empresa:" & lgblNumEmpresa, vbInformation + vbOKOnly, "Tarjeta Corporativa"
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron los datos de la Unidad a Copiar", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Cursor = Cursors.Default;
                    }
                    break;
            }
            eventArgs.Cancel = Cancel;
        }

        private bool Valida_Datos()
        {
            bool result = false;
            for (int i = 0; i <= 13; i++)
            {
                if (i == 1)
                {
                    if (!bNivPadre)
                    {
                    }
                    else if (bNivPadre)
                    {
                        if (mkbMaskebox[i].CtlText == "")
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (mkbMaskebox[i].CtlText == "")
                    {
                        return false;
                    }
                }
            }
            if (cmbCombo[0].SelectedIndex == -1)
            {
                return false;
            }
            if (txtTexto[2].Text == "" || txtTexto[2].Text == "")
            {
                return false;
            }
            switch (Formato.sgForma)
            {
                case "A":
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = " + mkbMaskebox[0].CtlText;

                    result = !(CORPROC2.Cuenta_Registros() >= 1);
                    break;
                case "B":
                    result = true;
                    break;
                case "C":
                    result = true;
                    break;
                case "D":
                    result = true;
                    break;
                case "E":
                    result = true;
                    break;
            }
            return result;
        }

        private void Limpia_Forma()
        {
            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i <= 13; i++)
            {
                mkbMaskebox[i].CtlText = "";
            }
            txtTexto[2].Text = "";
            txtTexto[3].Text = "";
            mkbMaskebox[15].CtlText = "";
            mkbMaskebox[16].CtlText = "";
            cmbCombo[0].SelectedIndex = -1;
            cmbCombo[0].Text = "";

            CORVAR.pszgblsql = "select distinct convert(int,report_id),report_name from MTCREP01";
            if (CORPROC2.Cuenta_Registros() > 0)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    iRenRep = 0;
                    LST_REPO[0].Items.Clear();

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) <= 9)
                        {
                            LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                        }
                        else if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) >= 10)
                        {
                            LST_REPO[0].Items.Add(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 8) + "N");
                        }
                        iRenRep++;
                    };
                }
            }
            mkbMaskebox_Rep[0].CtlText = "";
            mkbMaskebox_Rep[1].CtlText = "";
            mkbMaskebox_Rep[2].CtlText = "";
            FRAM_REP[0].Enabled = false;
            CMD_ACT_REP.Enabled = false;

            CORVAR.pszgblsql = "select emp_estruct_gastos from MTCEMP01 where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and emp_num=" + CORVAR.lgblNumEmpresa.ToString();
            if (CORPROC2.Cuenta_Registros() > 0)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        lEstruc_Gastos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    };
                    CORVAR.pszgblsql = "select exp_cat_id,exp_cat_name from MTCCAT01 where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and exp_struc_id =" + lEstruc_Gastos.ToString();
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {
                            iRenCat = 0;
                            LST_CAT.Items.Clear();

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length <= 9)
                                {
                                    LST_CAT.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim() + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                }
                                else if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim().Length >= 10)
                                {
                                    LST_CAT.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim() + new String(' ', 4) + VBSQL.SqlData(CORVAR.hgblConexion, 2));
                                }
                                iRenCat++;
                            };
                        }
                    }
                    else
                    {
                        MessageBox.Show("La Estructura de Gastos de la Empresa:" + CORVAR.lgblNumEmpresa.ToString() + " no tiene Categorias.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            mkbMaskebox_Cat[0].CtlText = "";
            mkbMaskebox_Cat[1].CtlText = "";
            mkbMaskebox_Cat[2].CtlText = "";
            FRAM_CAT.Enabled = false;
            tabStab[0].SelectedIndex = 0;

            if (!mkbMaskebox[1].Enabled)
            {
                mkbMaskebox[1].Enabled = true;
            }
            if (!mkbMaskebox[2].Enabled)
            {
                mkbMaskebox[2].Enabled = true;
            }

            this.Cursor = Cursors.Default;
        }

        private void txtTexto_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            int Index = Array.IndexOf(txtTexto, eventSender);
            switch (Index)
            {
                case 3:
                    if (KeyAscii == ((int)Keys.Return) || KeyAscii == ((int)Keys.Tab))
                    {
                        tabStab[0].SelectedIndex = 1;
                    }
                    break;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void Des_Habilita_Forma(int Action)
        {
            switch (Action)
            {
                case 1:
                    for (int i = 0; i <= 13; i++)
                    {
                        mkbMaskebox[i].Enabled = true;
                    }
                    cmbCombo[0].Enabled = true;
                    txtTexto[2].Enabled = true;
                    txtTexto[3].Enabled = true;
                    mkbMaskebox[15].Enabled = true;
                    mkbMaskebox[16].Enabled = true;

                    break;
                case 2:
                    for (int i = 0; i <= 13; i++)
                    {
                        mkbMaskebox[i].Enabled = false;
                    }
                    mkbMaskebox[15].Enabled = false;
                    mkbMaskebox[16].Enabled = false;
                    cmbCombo[0].Enabled = false;
                    txtTexto[2].Enabled = false;
                    txtTexto[3].Enabled = false;
                    break;
            }
        }
        private void CORMNUNI_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ID_MEE_IMP_PB_Click(object sender, EventArgs e)
        {

        }
    }
}