using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMNCATS
        : System.Windows.Forms.Form
    {

        private void CORMNCATS_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        int int_clave_catego = 0;

        int hConexion = 0;

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Height = (int)VB6.TwipsToPixelsY(2385);
            this.Width = (int)VB6.TwipsToPixelsX(4695);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            switch (Formato.sgForma)
            {
                case "A":
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " max(exp_cat_id)";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            int_clave_catego = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) + 1);
                        };
                        ID_CAT_CVE_EB.CtlText = int_clave_catego.ToString();
                    }
                    Formato.bgForma = true;
                    break;
                case "B":
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_name";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_id = " + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_name = '" + Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 26, 20).Trim() + "'";
                    if (CORPROC2.Cuenta_Registros() >= 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                ID_CAT_CVE_EB.CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                ID_CAT_DES_EB.Text = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                            };
                        }
                        Formato.bgForma = true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontro ninguna Categoría similar", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Formato.bgForma = false;
                    }
                    break;
                case "C":
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_name";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_id = " + Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_name = '" + Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 26, 20).Trim() + "'";
                    if (CORPROC2.Cuenta_Registros() >= 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                ID_CAT_CVE_EB.CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                ID_CAT_CVE_EB.Enabled = false;
                                ID_CAT_DES_EB.Text = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                ID_CAT_DES_EB.Enabled = false;
                                ID_CAT_ACE_PB.Enabled = false;
                            };
                        }
                        Formato.bgForma = true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontro ninguna Categoría similar", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Formato.bgForma = false;
                    }
                    break;
            }
        }

        private void ID_CAT_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                switch (Formato.sgForma)
                {
                    case "A":
                        this.Cursor = Cursors.WaitCursor;
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "insert into MTCCAT01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_struc_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_last_upd_userid,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_last_upd_date,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_last_upd_time)";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (" + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + Conversion.Val(Formato.IdEstruct).ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + Conversion.Val(ID_CAT_CVE_EB.CtlText).ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + ID_CAT_DES_EB.Text.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserID + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20),getdate(),112))";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate())))";

                            if (CORPROC2.Modifica_Registro() > 0)
                            {
                                MessageBox.Show("Se dió de alta correctamente la Categoría: " + ID_CAT_DES_EB.Text.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CORCTCATS.DefInstance.ID_CAT_LB.Items.Add(new String(' ', 6) + StringsHelper.Format(Conversion.Val(ID_CAT_CVE_EB.CtlText), "0000") + new String(' ', 15) + ID_CAT_DES_EB.Text.Trim());
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(" No se pudo dar de alta la Categoría: " + StringsHelper.Format(ID_CAT_CVE_EB.CtlText.Trim(), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Falta algun dato o ya existe la Categoría: " + StringsHelper.Format(ID_CAT_CVE_EB.CtlText.Trim(), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        this.Cursor = Cursors.Default;

                        break;
                    case "B":
                        this.Cursor = Cursors.WaitCursor;
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "update MTCCAT01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " set exp_cat_name = '" + ID_CAT_DES_EB.Text.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", exp_cat_last_upd_userid = '" + CRSParametros.sgUserID + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", exp_cat_last_upd_date = convert(int,convert(char(20),getdate(),112))";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", exp_cat_last_upd_time = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_id = " + Conversion.Val(ID_CAT_CVE_EB.CtlText).ToString();

                            if (CORPROC2.Modifica_Registro() > 0)
                            {
                                MessageBox.Show("Se dió de alta el cambio de la Categoría: " + ID_CAT_DES_EB.Text.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int i = 0; i <= CORCTCATS.DefInstance.ID_CAT_LB.Items.Count - 1; i++)
                                {
                                    CORCTCATS.DefInstance.ID_CAT_LB.SelectedIndex = i;
                                    if (Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)) == Conversion.Val(ID_CAT_CVE_EB.CtlText))
                                    {
                                        CORCTCATS.DefInstance.ID_CAT_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(CORCTCATS.DefInstance.ID_CAT_LB));
                                        CORCTCATS.DefInstance.ID_CAT_LB.Items.Insert(i, new String(' ', 6) + StringsHelper.Format(Conversion.Val(ID_CAT_CVE_EB.CtlText), "0000") + new String(' ', 15) + ID_CAT_DES_EB.Text.Trim());
                                    }
                                }
                                CORCTCATS.DefInstance.ID_CAT_LB.SelectedIndex = 0;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(" No se pudo dar de alta la Categoría: " + StringsHelper.Format(ID_CAT_CVE_EB.CtlText.Trim(), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta algun dato o ya existe la Categoría: " + StringsHelper.Format(ID_CAT_CVE_EB.CtlText.Trim(), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        this.Cursor = Cursors.Default;

                        break;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CAT_ACE_PB_Click)", e);
            }
        }

        private void ID_CAT_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private bool Valida_Datos()
        {

            int reg = 0;

            if (ID_CAT_CVE_EB.CtlText == "")
            {
                return false;
            }
            if (ID_CAT_DES_EB.Text == "")
            {
                return false;
            }
            if (Formato.sgForma == "A")
            {
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " *";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_cat_id = " + Conversion.Val(ID_CAT_CVE_EB.CtlText).ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_name = '" + ID_CAT_DES_EB.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco =  " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();

                reg = CORPROC2.Cuenta_Registros();
                if (reg >= 1)
                {
                    return false;
                }
            }

            return true;

        }

        private void ID_CAT_DES_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, false, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        private void CORMNCATS_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}