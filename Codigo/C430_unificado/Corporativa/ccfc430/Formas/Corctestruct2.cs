using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORCTESTRUCT2
        : System.Windows.Forms.Form
    {

        private void CORCTESTRUCT2_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        public void Carga_Estructuras()
        {

            this.Cursor = Cursors.WaitCursor;

            ID_CEE_ESTRUCT_LB.Items.Clear();

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_struc_id,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_strucy_name";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEST01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();

            if (CORPROC2.Cuenta_Registros() >= 1)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        ID_CEE_ESTRUCT_LB.Items.Add(new String(' ', 2) + StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "0000") + new String(' ', 7) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                    };
                }
            }

            this.Cursor = Cursors.Default;

        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            this.Cursor = Cursors.WaitCursor;

            //  If bgblAdmin Then
            //    ID_EST_ALT_PB.Enabled = True
            //    ID_EST_BAJ_PB.Enabled = True
            //    ID_EST_CAM_PB.Enabled = True
            //    ID_EST_CAT_PB.Enabled = True
            //    ID_EST_CON_PB.Enabled = True
            //    ID_EST_EMPA_PB.Enabled = True
            //  Else
            //    ID_EST_ALT_PB.Enabled = OpcionesAcceso(0).bAltas
            //    ID_EST_BAJ_PB.Enabled = OpcionesAcceso(0).bBajas
            //    ID_EST_CAM_PB.Enabled = OpcionesAcceso(0).bCambios
            //    ID_EST_CON_PB.Enabled = OpcionesAcceso(0).bConsultas
            //    ID_EST_CAT_PB.Enabled = OpcionesAcceso(0).bAltas
            //    ID_EST_EMPA_PB.Enabled = True
            //  End If

            mdlParametros.gperPerfil.prHabilitaAcciones(CORCTESTRUCT2.DefInstance);
            this.Height = (int)VB6.TwipsToPixelsY(4125);
            this.Width = (int)VB6.TwipsToPixelsX(5880);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            txtTexto[0].Enabled = false;
            txtTexto[0].Text = CORVAR.igblPref.ToString().Trim() + " - " + CORVAR.igblBanco.ToString().Trim();

            Carga_Estructuras();

            if (ID_CEE_ESTRUCT_LB.Items.Count > 0)
            {
                ID_CEE_ESTRUCT_LB.SelectedIndex = 0;
            }

        }

        private void ID_EST_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            if (txtTexto[0].Text != "")
            {
                Formato.sgForma = "A";
                CORMNESTRUCT2 tempLoadForm = CORMNESTRUCT2.DefInstance;
                CORMNESTRUCT2.DefInstance.Show();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No existe ningun Producto para dar de alta sus Estructuras de Gastos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = Cursors.Default;

        }

        private void ID_EST_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            double reg = 0;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ID_CEE_ESTRUCT_LB.Items.Count > 0)
                {
                    if (ListBoxHelper.GetSelectedIndex(ID_CEE_ESTRUCT_LB) != -1)
                    {
                        if (MessageBox.Show("Deseas dar de baja la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            CORVAR.pszgblsql = "select *";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEST01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_struc_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_strucy_name = '" + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                            if (CORPROC2.Cuenta_Registros() == 1)
                            {
                                CORVAR.pszgblsql = "select";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " count(*)";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_estruct_gastos = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                if (CORPROC2.Cuenta_Registros() >= 1)
                                {
                                    if (CORPROC2.Obtiene_Registros() != 0)
                                    {

                                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                        {
                                            reg = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                        };
                                    }
                                    if (reg == 0)
                                    {
                                        CORVAR.pszgblsql = "select *";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                        if (CORPROC2.Cuenta_Registros() >= 1)
                                        {
                                            CORVAR.pszgblsql = "select *";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCRAG01";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_eje_prefijo = " + CORVAR.igblPref.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                            if (CORPROC2.Cuenta_Registros() >= 1)
                                            {
                                                CORVAR.pszgblsql = "delete MTCEST01";
                                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_struc_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_strucy_name = '" + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim() + "'";
                                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                                                if (CORPROC2.Modifica_Registro() > 0)
                                                {
                                                    CORVAR.pszgblsql = "delete MTCCAT01";
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                                    if (CORPROC2.Modifica_Registro() > 0)
                                                    {
                                                        CORVAR.pszgblsql = "delete MTCRAG01";
                                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_eje_prefijo = " + CORVAR.igblPref.ToString();
                                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
                                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                                        if (CORPROC2.Modifica_Registro() > 0)
                                                        {
                                                            this.Cursor = Cursors.Default;
                                                            MessageBox.Show("Se dio de Baja con exito la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            ID_CEE_ESTRUCT_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEE_ESTRUCT_LB));
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            this.Cursor = Cursors.Default;
                                                            MessageBox.Show("No se dio de Baja el o los Rangos de la Estructura:" + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Cursor = Cursors.Default;
                                                        MessageBox.Show("No se pudo dar de baja la o las Categoría(s) de la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    this.Cursor = Cursors.Default;
                                                    MessageBox.Show("No se pudo dar de baja la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                CORVAR.pszgblsql = "delete MTCEST01";
                                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_struc_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_strucy_name = '" + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim() + "'";
                                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                                                if (CORPROC2.Modifica_Registro() == 1)
                                                {
                                                    CORVAR.pszgblsql = "delete MTCCAT01";
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                                    if (CORPROC2.Modifica_Registro() == 1)
                                                    {
                                                        this.Cursor = Cursors.Default;
                                                        MessageBox.Show("Se dio de Baja con exito la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        ID_CEE_ESTRUCT_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEE_ESTRUCT_LB));
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        this.Cursor = Cursors.Default;
                                                        MessageBox.Show("No se pudo dar de baja la o las Categoría(s) de la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    this.Cursor = Cursors.Default;
                                                    MessageBox.Show("No se pudo dar de baja la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            CORVAR.pszgblsql = "delete MTCEST01";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where exp_struc_id = " + Conversion.Val(Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4)).ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_strucy_name = '" + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim() + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                                            if (CORPROC2.Modifica_Registro() == 1)
                                            {
                                                this.Cursor = Cursors.Default;
                                                MessageBox.Show("Se dio de Baja con exito la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ID_CEE_ESTRUCT_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEE_ESTRUCT_LB));
                                                return;
                                            }
                                            else
                                            {
                                                this.Cursor = Cursors.Default;
                                                MessageBox.Show("No se dio de Baja el o los Rangos de la Estructura:" + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                    }
                                    else if (reg >= 1)
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("La Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim() + " tiene ligado por lo menos una Empresa. Por lo que no se podra dar de Baja.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("No existe la Estructura: " + Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Aun no se ha seleccionado ninguna Estructura para dar de Baja", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No existe ninguna Estructura para dar de Baja", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_EST_BAJ_PB_Click " + exc.Message, "Error Corctestruct2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_EST_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (txtTexto[0].Text != "")
            {
                Formato.sgForma = "B";
                CORMNESTRUCT2 tempLoadForm = CORMNESTRUCT2.DefInstance;
                if (Formato.bgForma)
                {
                    CORMNESTRUCT2.DefInstance.Show();
                }
                else
                {
                    CORMNESTRUCT2.DefInstance.Close();
                }
            }
            else
            {
                MessageBox.Show("No existe ningun Producto para dar de alta sus Estructuras de Gastos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;

        }

        private void ID_EST_CAT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            if (ID_CEE_ESTRUCT_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                if (ListBoxHelper.GetSelectedIndex(ID_CEE_ESTRUCT_LB) < CORVB.NULL_INTEGER)
                {
                    CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORSTR.STR_NO_SEL_ELEM;
                }
                else
                {
                    Formato.IdEstruct = Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4);
                    Formato.NomEstruct = Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20);
                }
            }
            CORCTCATS.DefInstance.Show();
        }

        private void ID_EST_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (txtTexto[0].Text != "")
            {
                Formato.sgForma = "C";
                CORMNESTRUCT2 tempLoadForm = CORMNESTRUCT2.DefInstance;
                if (Formato.bgForma)
                {
                    CORMNESTRUCT2.DefInstance.Show();
                }
                else
                {
                    CORMNESTRUCT2.DefInstance.Close();
                }
            }
            else
            {
                MessageBox.Show("No existe ningun Producto para dar de alta sus Estructuras de Gastos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }

        private void ID_EST_EMPA_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            if (ID_CEE_ESTRUCT_LB.Items.Count > 0)
            {
                if (ListBoxHelper.GetSelectedIndex(ID_CEE_ESTRUCT_LB) != -1)
                {
                    Formato.IdEstruct = Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 3, 4);
                    Formato.NomEstruct = Strings.Mid(ID_CEE_ESTRUCT_LB.Text, 14, 20);
                    EmpAsig tempLoadForm = EmpAsig.DefInstance;
                    if (Formato.bgForma)
                    {
                        EmpAsig.DefInstance.Show();
                    }
                    else
                    {
                        EmpAsig.DefInstance.Close();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No se ha seleccionado ninguna Estructura para ver sus Empresas asignadas", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No existe ninguna Estructura para ver sus Empresas asignadas", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_SALIR_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;
            this.Close();
        }
        private void CORCTESTRUCT2_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void CORCTESTRUCT2_Load(object sender, EventArgs e)
        {

        }
    }
}