using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORMNESTRUCT2
        : System.Windows.Forms.Form
    {

        private void CORMNESTRUCT2_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        int int_clave_estruct = 0;
        int hConexion = 0;

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Height = (int)VB6.TwipsToPixelsY(2400);
            this.Width = (int)VB6.TwipsToPixelsX(4515);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            switch (Formato.sgForma)
            {
                case "A":
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " max(exp_struc_id)";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEST01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            int_clave_estruct = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) + 1);
                        };
                        ID_EST_CVE_EB.CtlText = int_clave_estruct.ToString();
                    }
                    Formato.bgForma = true;
                    break;
                case "B":
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_struc_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_strucy_name";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEST01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Strings.Mid(CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_strucy_name = '" + Strings.Mid(CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim() + "'";
                    if (CORPROC2.Cuenta_Registros() == 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                ID_EST_CVE_EB.CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                ID_EST_CVE_EB.Enabled = false;
                                ID_ESTRUCT_DESC.Text = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                ID_ESTRUCT_DESC.Enabled = true;
                            };
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontro la estructura de gastos: " + Strings.Mid(CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Formato.bgForma = false;
                        return;
                    }
                    Formato.bgForma = true;
                    break;
                case "C":
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_struc_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_strucy_name";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEST01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Strings.Mid(CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_strucy_name = '" + Strings.Mid(CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim() + "'";
                    if (CORPROC2.Cuenta_Registros() == 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                ID_EST_CVE_EB.CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                                ID_EST_CVE_EB.Enabled = false;
                                ID_ESTRUCT_DESC.Text = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                ID_ESTRUCT_DESC.Enabled = false;
                                ID_EST_ACE_PB.Enabled = false;
                            };
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontro la estructura de gastos: " + Strings.Mid(CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Formato.bgForma = false;
                        return;
                    }
                    Formato.bgForma = true;

                    break;
            }

        }

        private void ID_EST_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            int hestructura = 0;
            int iError = 0;
            int bExiste = 0;
            int iContador = 0;
            int ok1 = 0;

            try
            {
                switch (Formato.sgForma)
                {
                    case "A":
                        this.Cursor = Cursors.WaitCursor;
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "insert into MTCEST01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (exp_struc_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_strucy_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_eje_prefijo,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_gpo_banco)";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " values (";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Val(ID_EST_CVE_EB.CtlText).ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_ESTRUCT_DESC.Text.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ")";

                            if (CORPROC2.Modifica_Registro() == 1)
                            {
                                MessageBox.Show("Se dió de alta correctamente la Estructura : " + ID_ESTRUCT_DESC.Text.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Items.Add(new String(' ', 2) + StringsHelper.Format(ID_EST_CVE_EB.CtlText.Trim(), "0000") + new String(' ', 7) + ID_ESTRUCT_DESC.Text.Trim());
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(" No se pudo dar de alta la Estructura: " + StringsHelper.Format(ID_EST_CVE_EB.CtlText.Trim(), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta algun dato o ya existe la Estructura: " + StringsHelper.Format(ID_EST_CVE_EB.CtlText.Trim(), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        this.Cursor = Cursors.Default;
                        CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.SelectedIndex = 0;

                        break;
                    case "B":
                        this.Cursor = Cursors.WaitCursor;
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "update MTCEST01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " set exp_strucy_name = '" + ID_ESTRUCT_DESC.Text.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_struc_id = " + Conversion.Val(ID_EST_CVE_EB.CtlText).ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                            if (CORPROC2.Modifica_Registro() == 1)
                            {
                                MessageBox.Show("Se dió de alta correctamente el cambio de la Estructura : " + ID_ESTRUCT_DESC.Text.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                for (int I = 0; I <= CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Items.Count - 1; I++)
                                {
                                    CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.SelectedIndex = I;
                                    if (Conversion.Val(Strings.Mid(CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Text, 3, 4)) == Conversion.Val(ID_EST_CVE_EB.CtlText))
                                    {
                                        CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB));
                                        CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.Items.Insert(I, new String(' ', 2) + StringsHelper.Format(Conversion.Val(ID_EST_CVE_EB.CtlText), "0000") + new String(' ', 7) + ID_ESTRUCT_DESC.Text.Trim());
                                    }
                                }
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(" No se pudo dar de alta la Estructura: " + StringsHelper.Format(ID_EST_CVE_EB.CtlText.Trim(), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta algun dato o ya existe la Estructura: " + StringsHelper.Format(ID_EST_CVE_EB.CtlText.Trim(), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        CORCTESTRUCT2.DefInstance.ID_CEE_ESTRUCT_LB.SelectedIndex = 0;
                        this.Cursor = Cursors.Default;

                        break;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_EST_ACE_PB_Click)", e);
            }
        }

        private void ID_EST_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private bool Valida_Datos()
        {
            int reg = 0;

            if (ID_EST_CVE_EB.CtlText == "")
            {
                return false;
            }
            if (ID_ESTRUCT_DESC.Text == "")
            {
                return false;
            }

            if (Formato.sgForma == "A")
            {
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " *";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEST01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_struc_id = " + Conversion.Val(ID_EST_CVE_EB.CtlText).ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_strucy_name = '" + ID_ESTRUCT_DESC.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco =  " + CORVAR.igblBanco.ToString();

                reg = CORPROC2.Cuenta_Registros();
                if (reg >= 1)
                {
                    return false;
                }
            }

            return true;

        }

        private void ID_ESTRUCT_DESC_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, false, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        private void CORMNESTRUCT2_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}