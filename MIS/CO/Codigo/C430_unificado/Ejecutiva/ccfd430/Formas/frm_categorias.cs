using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class frm_categorias
        : System.Windows.Forms.Form
    {

        private void frm_categorias_Activated(Object eventSender, EventArgs eventArgs)
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

        private void CMD_ACT_CAT_Click(Object eventSender, EventArgs eventArgs)
        {

            if (sCat_Id != "" && sLimit != "" && sPor_Uso != "")
            {
                for (int I = 0; I <= iRenCat - 1; I++)
                {
                    LST_CAT.SelectedIndex = I;
                    if (Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 3))) == Conversion.Val(sCat_Id))
                    {
                        sCat_Nombre = Strings.Mid(LST_CAT.Text, 7, 20);
                        LST_CAT.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_CAT));
                        if (Conversion.Val(sCat_Id) <= 9)
                        {
                            LST_CAT.Items.Insert(I, Conversion.Val(sCat_Id).ToString() + new String(' ', 5) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                        }
                        else if (Conversion.Val(sCat_Id) >= 10)
                        {
                            LST_CAT.Items.Insert(I, Conversion.Val(sCat_Id).ToString() + new String(' ', 4) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                        }
                    }
                }
                CMB_CAT.SelectedIndex = -1;
                LST_CAT.SelectedIndex = -1;
                CMD_ACT_CAT.Enabled = false;
                mkbMaskebox_Cat[3].CtlText = "";
                mkbMaskebox_Cat[4].CtlText = "";
            }
            else
            {
                MessageBox.Show("No se pueden Actualizar los datos porque falta algun dato.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int iCont = 0;
            string lstrEmp = String.Empty;
            string s = String.Empty;
            int reg = 0;

            this.Height = (int)VB6.TwipsToPixelsY(6945);
            this.Width = (int)VB6.TwipsToPixelsX(8745);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            switch (Formato.sgForma)
            {
                case "A":
                    txtTexto_Cat[0].Text = Strings.Mid(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto_Cat[0].Enabled = false;
                    txtTexto_Cat[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();
                    txtTexto_Cat[1].Enabled = false;

                    if (Strings.Len(txtTexto_Cat[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }
                    else
                    {
                        Formato.bgForma = true;
                    }

                    mkbMaskebox_Cat[2].Format = "00";

                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(frm_men_cat.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));

                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + frm_men_cat.DefInstance.ID_CEE_UNI_COB.Text.Substring(0, Math.Min(frm_men_cat.DefInstance.ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                mkbMaskebox_Cat[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                mkbMaskebox_Cat[0].Enabled = false;
                                mkbMaskebox_Cat[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                mkbMaskebox_Cat[1].Enabled = false;
                                mkbMaskebox_Cat[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                mkbMaskebox_Cat[2].Enabled = false;
                            };
                        }
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
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    CMD_ACT_CAT.Enabled = false;
                    FRAM_CAT.Enabled = true;

                    break;
                case "B":
                    txtTexto_Cat[0].Text = Strings.Mid(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto_Cat[0].Enabled = false;
                    txtTexto_Cat[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();
                    txtTexto_Cat[1].Enabled = false;

                    if (Strings.Len(txtTexto_Cat[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }
                    else
                    {
                        Formato.bgForma = true;
                    }

                    mkbMaskebox_Cat[2].Format = "00";

                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(frm_men_cat.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));

                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + frm_men_cat.DefInstance.ID_CEE_UNI_COB.Text.Substring(0, Math.Min(frm_men_cat.DefInstance.ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                mkbMaskebox_Cat[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                mkbMaskebox_Cat[0].Enabled = false;
                                mkbMaskebox_Cat[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                mkbMaskebox_Cat[1].Enabled = false;
                                mkbMaskebox_Cat[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                mkbMaskebox_Cat[2].Enabled = false;
                            };
                        }
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
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = '" + mkbMaskebox_Cat[0].CtlText.Trim() + "'";

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
                                                    for (int I = 0; I <= iRenCat - 1; I++)
                                                    {
                                                        LST_CAT.SelectedIndex = I;
                                                        if (Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 3))) == Conversion.Val(sCat_Id))
                                                        {
                                                            LST_CAT.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_CAT));
                                                            if (Conversion.Val(sCat_Id) <= 9)
                                                            {
                                                                LST_CAT.Items.Insert(I, Conversion.Val(sCat_Id).ToString() + new String(' ', 5) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                            }
                                                            else if (Conversion.Val(sCat_Id) >= 10)
                                                            {
                                                                LST_CAT.Items.Insert(I, Conversion.Val(sCat_Id).ToString() + new String(' ', 4) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
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
                    }
                    LST_CAT.SelectedIndex = -1;
                    CMD_ACT_CAT.Enabled = false;
                    this.Cursor = Cursors.Default;

                    break;
                case "C":
                    txtTexto_Cat[0].Text = Strings.Mid(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto_Cat[0].Enabled = false;
                    txtTexto_Cat[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(frm_men_cat.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();
                    txtTexto_Cat[1].Enabled = false;

                    if (Strings.Len(txtTexto_Cat[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }
                    else
                    {
                        Formato.bgForma = true;
                    }

                    mkbMaskebox_Cat[2].Format = "00";

                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(frm_men_cat.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));

                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + frm_men_cat.DefInstance.ID_CEE_UNI_COB.Text.Substring(0, Math.Min(frm_men_cat.DefInstance.ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                mkbMaskebox_Cat[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                mkbMaskebox_Cat[0].Enabled = false;
                                mkbMaskebox_Cat[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                mkbMaskebox_Cat[1].Enabled = false;
                                mkbMaskebox_Cat[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                mkbMaskebox_Cat[2].Enabled = false;
                            };
                        }
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
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = '" + mkbMaskebox_Cat[0].CtlText.Trim() + "'";

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
                                                    for (int I = 0; I <= iRenCat - 1; I++)
                                                    {
                                                        LST_CAT.SelectedIndex = I;
                                                        if (Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 3))) == Conversion.Val(sCat_Id))
                                                        {
                                                            LST_CAT.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_CAT));
                                                            if (Conversion.Val(sCat_Id) <= 9)
                                                            {
                                                                LST_CAT.Items.Insert(I, Conversion.Val(sCat_Id).ToString() + new String(' ', 5) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
                                                            }
                                                            else if (Conversion.Val(sCat_Id) >= 10)
                                                            {
                                                                LST_CAT.Items.Insert(I, Conversion.Val(sCat_Id).ToString() + new String(' ', 4) + sCat_Nombre + new String(' ', 25) + sLimit + new String(' ', 11) + sPor_Uso);
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
                    }
                    LST_CAT.SelectedIndex = -1;
                    CMD_ACT_CAT.Enabled = false;
                    ID_MEE_ALT_PB.Enabled = false;
                    FRAM_CAT.Enabled = false;
                    this.Cursor = Cursors.Default;
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
                        for (int I = 0; I <= iRenCat - 1; I++)
                        {
                            LST_CAT.SelectedIndex = I;
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
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox_Cat[0].CtlText.Trim() + "'";
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
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox_Cat[0].CtlText.Trim() + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 5))).ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",NULL";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",NULL)";
                            }
                            if (CORPROC2.Modifica_Registro() != 1)
                            {
                                MessageBox.Show("No se pudo dar de alta la Categoría", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Cursor = Cursors.Default;
                        this.Close();

                        break;
                    case "B":
                        //Se va a borrar todas las categorias para poder darlas de alta otra vez. 
                        CORVAR.pszgblsql = "delete from MTCUCT01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + mkbMaskebox_Cat[0].CtlText.Trim() + "'";
                        if (CORPROC2.Modifica_Registro() >= 1)
                        {
                            for (int I = 0; I <= iRenCat - 1; I++)
                            {
                                LST_CAT.SelectedIndex = I;
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
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox_Cat[0].CtlText.Trim() + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(LST_CAT.Text.Substring(0, Math.Min(LST_CAT.Text.Length, 5))).ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Strings.Mid(cad_Cat, 52, 14).Trim();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(Strings.Mid(cad_Cat, cad_Cat.Length - 3, 4).Trim()).ToString() + ")";
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
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox_Cat[0].CtlText.Trim();
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
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Se realizo con exito el cambio de la Categoria", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Cursor = Cursors.Default;
                        this.Close();

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
            this.Close();
        }

        private void mkbMaskebox_Cat_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            int Index = Array.IndexOf(mkbMaskebox_Cat, eventSender);

            switch (Index)
            {
                case 3:
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, false, false);
                    break;
            }
            //AIS-1094 NGONZALEZ
            if (eventArgs.keyAscii == ((int)Keys.Return))
            {
                VB6.SendKeys("{Tab}", false);
            }
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
                        CMD_ACT_CAT.Enabled = true;
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
        private void frm_categorias_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}