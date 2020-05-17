using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORCTCATS
        : System.Windows.Forms.Form
    {

        private void CORCTCATS_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Cursor = Cursors.WaitCursor;

            if (CORVAR.bgblAdmin != 0)
            {
                ID_CAT_ALT_PB.Enabled = true;
                ID_CAT_BAJ_PB.Enabled = true;
                ID_CAT_CAM_PB.Enabled = true;
                ID_CAT_CON_PB.Enabled = true;
                ID_CAT_UNPA_PB.Enabled = true;
                ID_CAT_RAPA_PB.Enabled = true;
                ID_CAT_SAPA_PB.Enabled = true;
            }
            else
            {
                ID_CAT_ALT_PB.Enabled = CORVAR.OpcionesAcceso[2].bAltas;
                ID_CAT_BAJ_PB.Enabled = CORVAR.OpcionesAcceso[2].bBajas;
                ID_CAT_CAM_PB.Enabled = CORVAR.OpcionesAcceso[2].bCambios;
                ID_CAT_CON_PB.Enabled = CORVAR.OpcionesAcceso[2].bConsultas;
                try
                {
                    ID_CAT_UNPA_PB.Enabled = Boolean.Parse(CORVAR.OpcionesAcceso[2].sOpcion);
                }
                catch { }
                try
                {
                    ID_CAT_RAPA_PB.Enabled = Boolean.Parse(CORVAR.OpcionesAcceso[2].sOpcion);
                }
                catch { }
                try
                {
                    ID_CAT_SAPA_PB.Enabled = Boolean.Parse(CORVAR.OpcionesAcceso[2].sOpcion);
                }
                catch { }
            }

            ID_PROD.Text = "";
            ID_PROD.Enabled = false;
            ID_EST_TXT.Text = "";
            ID_EST_TXT.Enabled = false;
            ID_PROD.Text = CORVAR.igblPref.ToString().Trim() + " - " + CORVAR.igblBanco.ToString().Trim();
            ID_EST_TXT.Text = StringsHelper.Format(Formato.IdEstruct, "000000");

            this.Height = (int)VB6.TwipsToPixelsY(4350);
            this.Width = (int)VB6.TwipsToPixelsX(5715);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            Carga_Categorias();

            this.Cursor = Cursors.Default;

        }

        private void ID_CAT_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            int int_clave = 0;
            this.Cursor = Cursors.WaitCursor;


            try
            {


                if (ID_PROD.Text != "" && ID_EST_TXT.Text != "")
                {
                    Formato.sgForma = "A";

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
                            int_clave = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) + 1);
                        };
                        if (int_clave > 15)
                        {
                            MessageBox.Show("No se pueden dar mas de 15 Categorias", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            return;
                        }
                    }
                    CORMNCATS tempLoadForm = CORMNCATS.DefInstance;
                    if (Formato.bgForma)
                    {
                        CORMNCATS.DefInstance.Show();
                    }
                    else
                    {
                        CORMNCATS.DefInstance.Close();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No existe ningun Producto para dar de alta sus Estructuras de Gastos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CAT_ALT_PB_Click " + exc.Message, "Error CORCTCATS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void ID_CAT_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ID_CAT_LB.Items.Count > 0)
                {
                    if (ListBoxHelper.GetSelectedIndex(ID_CAT_LB) != -1)
                    {
                        if (MessageBox.Show("Deseas dar de baja la Categoria: " + Strings.Mid(ID_CAT_LB.Text, 26, 20).Trim(), "Tarjeta Corporativa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            CORVAR.pszgblsql = "select";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " *";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_id = " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_name = '" + Strings.Mid(ID_CAT_LB.Text, 26, 20).Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();

                            if (CORPROC2.Cuenta_Registros() >= 1)
                            {
                                CORVAR.pszgblsql = "select";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " *";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCRAG01";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_eje_prefijo = " + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_id = " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString();
                                if (CORPROC2.Cuenta_Registros() >= 1)
                                {
                                    CORVAR.pszgblsql = "delete MTCRAG01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where cat_eje_prefijo = " + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_gpo_banco = " + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_exp_struct_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and cat_id = " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString();
                                    if (CORPROC2.Modifica_Registro() == 1)
                                    {
                                        CORVAR.pszgblsql = "delete MTCCAT01";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_id = " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_name = '" + Strings.Mid(ID_CAT_LB.Text, 26, 20).Trim() + "'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                                        if (CORPROC2.Modifica_Registro() == 1)
                                        {
                                            MessageBox.Show("Se dio de Baja la Categoría: " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ID_CAT_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CAT_LB));
                                            ID_CAT_LB.SelectedIndex = 0;
                                            this.Cursor = Cursors.Default;
                                            return;
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo dar de Baja la Categoría: " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Cursor = Cursors.Default;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo dar de Baja el Rango de la Categoria: " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Cursor = Cursors.Default;
                                        return;
                                    }
                                }
                                else
                                {
                                    CORVAR.pszgblsql = "delete MTCCAT01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_id = " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_cat_name = '" + Strings.Mid(ID_CAT_LB.Text, 26, 20).Trim() + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();
                                    if (CORPROC2.Modifica_Registro() == 1)
                                    {
                                        MessageBox.Show("Se dio de Baja la Categoría: " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ID_CAT_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CAT_LB));
                                        if (ID_CAT_LB.Items.Count > 0)
                                        {
                                            ID_CAT_LB.SelectedIndex = 0;
                                        }
                                        this.Cursor = Cursors.Default;
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo dar de Baja la Categoría: " + Conversion.Val(Strings.Mid(ID_CAT_LB.Text, 7, 4)).ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Cursor = Cursors.Default;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontro la Categoría que deseaba dar de Baja", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Cursor = Cursors.Default;
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
                        MessageBox.Show("No se ha seleccionado ninguna Categoria para dar de Baja", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No hay ninguna Categoria para dar de Baja", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    return;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CAT_BAJ_PB_Click " + exc.Message, "Error CORCTCATS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_CAT_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            if (ID_CAT_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                Formato.sgForma = "B";
                CORMNCATS tempLoadForm = CORMNCATS.DefInstance;
                if (Formato.bgForma)
                {
                    CORMNCATS.DefInstance.Show();
                }
                else
                {
                    CORMNCATS.DefInstance.Close();
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No existen Categorias para realizar Cambios", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CAT_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ID_CAT_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                if (ListBoxHelper.GetSelectedIndex(ID_CAT_LB) != -1)
                {
                    Formato.sgForma = "C";
                    CORMNCATS tempLoadForm = CORMNCATS.DefInstance;
                    if (Formato.bgForma)
                    {
                        CORMNCATS.DefInstance.Show();
                    }
                    else
                    {
                        CORMNCATS.DefInstance.Close();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Aun no ha seleccionado alguna Categorias para realizar Consultas", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No existen Categorias para realizar Consultas", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CAT_RAPA_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ID_CAT_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                if (ListBoxHelper.GetSelectedIndex(ID_CAT_LB) != -1)
                {
                    RangosCats tempLoadForm = RangosCats.DefInstance;
                    if (Formato.bgForma)
                    {
                        RangosCats.DefInstance.Show();
                    }
                    else
                    {
                        RangosCats.DefInstance.Close();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Aun no ha seleccionado alguna Categorias para agregar sus Rangos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No existen Categorias para agregar sus Rangos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CAT_SAPA_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void ID_CAT_UNPA_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ID_CAT_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                if (ListBoxHelper.GetSelectedIndex(ID_CAT_LB) != -1)
                {
                    ConsulUni tempLoadForm = ConsulUni.DefInstance;
                    if (Formato.bgForma)
                    {
                        ConsulUni.DefInstance.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se encontro ninguna Unidad ligada a la Categoría: " + StringsHelper.Format(Conversion.Val(Strings.Mid(CORCTCATS.DefInstance.ID_CAT_LB.Text, 7, 4)), "0000"), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ConsulUni.DefInstance.Close();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Aun no ha seleccionado alguna Categorias para realizar Consultas", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No existen Categorias para realizar Consultas", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;

        }

        private void Carga_Categorias()
        {

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_id,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " exp_cat_name";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCAT01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and exp_struc_id = " + Conversion.Val(Formato.IdEstruct).ToString();

            if (CORPROC2.Cuenta_Registros() >= 1)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    ID_CAT_LB.Items.Clear();

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        ID_CAT_LB.Items.Add(new String(' ', 6) + StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "0000") + new String(' ', 15) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                    };
                }
            }
            else
            {
                //MsgBox "No se encontro ninguna Categoría para este producto", vbInformation, "Tarjeta Corporativa"
                return;
            }
            if (ID_CAT_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CAT_LB.SelectedIndex = 0;
            }

        }
        private void CORCTCATS_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}