using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORSGCUS
        : System.Windows.Forms.Form
    {

        private void CORSGCUS_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            string sCve_Grupo = String.Empty;
            string sNom_Grupo = String.Empty;
            int iCont = 0;

            this.Width = (int)VB6.TwipsToPixelsX(4500);
            this.Height = (int)VB6.TwipsToPixelsY(4125);
            this.Left = (int)VB6.TwipsToPixelsX(5280);
            this.Top = (int)VB6.TwipsToPixelsY(1935);

            switch (Formato.sgForma)
            {
                case "A":  //Alta 
                    ID_CUS_GRU_COB.Items.Clear();
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_clave,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                    iCont = 0;
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            sCve_Grupo = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), "000");
                            sNom_Grupo = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                            ID_CUS_GRU_COB.Items.Insert(iCont, sCve_Grupo + new String(' ', 3) + sNom_Grupo);
                            VB6.SetItemData(ID_CUS_GRU_COB, iCont, Convert.ToInt32(Conversion.Val(sCve_Grupo)));
                            iCont++;
                        };
                        ID_CUS_GRU_COB.SelectedIndex = -1;
                    }

                    break;
                case "B":  //Cambio 
                    ID_CUS_GRU_COB.Items.Clear();
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_clave,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                    iCont = 0;
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            sCve_Grupo = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), "000");
                            sNom_Grupo = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                            ID_CUS_GRU_COB.Items.Insert(iCont, sCve_Grupo + new String(' ', 3) + sNom_Grupo);
                            VB6.SetItemData(ID_CUS_GRU_COB, iCont, Convert.ToInt32(Conversion.Val(sCve_Grupo)));
                            iCont++;
                        };
                    }

                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_clave,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_grupo,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_nombre,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_ape_pat,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_ape_mat,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_cve_per";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_clave = '" + Seguridad.Encripta(Strings.Mid(CORSGUSU.DefInstance.ID_USU_USU_LB.Text, 1, 9).Trim(), 2) + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                    if (CORPROC2.Cuenta_Registros() == 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                ID_CUS_USU_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim()).ToUpper();
                                for (int I = 0; I <= ID_CUS_GRU_COB.Items.Count - 1; I++)
                                {
                                    ID_CUS_GRU_COB.SelectedIndex = I;
                                    if (Conversion.Val(Strings.Mid(ID_CUS_GRU_COB.Text, 1, 3).Trim()) == Conversion.Val(Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 2))))
                                    {
                                        break;
                                    }
                                }
                                ID_CUS_NOM_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim()).ToUpper();
                                ID_CUS_PAT_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim()).ToUpper();
                                ID_CUS_MAT_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim()).ToUpper();
                                ID_CUS_PAS_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim()).ToUpper();
                                ID_CUS_USU_EB.Enabled = false;
                                ID_CUS_NOM_EB.Enabled = true;
                                ID_CUS_PAT_EB.Enabled = true;
                                ID_CUS_MAT_EB.Enabled = true;
                                ID_CUS_PAS_EB.Enabled = true;
                            };
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No se encontro ningun usuario similar", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Formato.bgForma = false;
                        return;
                    }
                    Formato.bgForma = true;
                    break;
                case "C":  //Consulta 
                    ID_CUS_GRU_COB.Items.Clear();
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_clave,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                    iCont = 0;
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            sCve_Grupo = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), "000");
                            sNom_Grupo = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                            ID_CUS_GRU_COB.Items.Insert(iCont, sCve_Grupo + new String(' ', 3) + sNom_Grupo);
                            VB6.SetItemData(ID_CUS_GRU_COB, iCont, Convert.ToInt32(Conversion.Val(sCve_Grupo)));
                            iCont++;
                        };
                    }
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_clave,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_grupo,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_nombre,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_ape_pat,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_ape_mat,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_cve_per";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_clave = '" + Seguridad.Encripta(Strings.Mid(CORSGUSU.DefInstance.ID_USU_USU_LB.Text, 1, 9).Trim(), 2) + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                    if (CORPROC2.Cuenta_Registros() == 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                ID_CUS_USU_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim()).ToUpper();
                                for (int I = 0; I <= ID_CUS_GRU_COB.Items.Count - 1; I++)
                                {
                                    ID_CUS_GRU_COB.SelectedIndex = I;
                                    if (Conversion.Val(Strings.Mid(ID_CUS_GRU_COB.Text, 1, 3).Trim()) == Conversion.Val(Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 2))))
                                    {
                                        break;
                                    }
                                }
                                ID_CUS_NOM_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim()).ToUpper();
                                ID_CUS_PAT_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim()).ToUpper();
                                ID_CUS_MAT_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim()).ToUpper();
                                ID_CUS_PAS_EB.Text = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim()).ToUpper();
                                ID_CUS_GRU_COB.Enabled = false;
                                ID_CUS_USU_EB.Enabled = false;
                                ID_CUS_NOM_EB.Enabled = false;
                                ID_CUS_PAT_EB.Enabled = false;
                                ID_CUS_MAT_EB.Enabled = false;
                                ID_CUS_PAS_EB.Enabled = false;
                                ID_CUS_ACE_PB.Visible = false;
                                ID_CUS_ACE_PB.Enabled = false;
                            };
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No se encontro ningun usuario similar", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Formato.bgForma = false;
                        return;
                    }
                    Formato.bgForma = true;
                    break;
            }
        }

        private void ID_CUS_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {

                switch (Formato.sgForma)
                {
                    case "A":  //ALTAS 
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "insert into MTCUSU01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (usu_clave,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_grupo,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_nombre,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_ape_pat,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_ape_mat,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_cve_per,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_tipo_prod)";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " values(";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + Seguridad.Encripta(ID_CUS_USU_EB.Text.Trim(), 2) + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + Seguridad.Encripta(VB6.GetItemData(ID_CUS_GRU_COB, ID_CUS_GRU_COB.SelectedIndex).ToString().Trim(), 2) + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + Seguridad.Encripta(ID_CUS_NOM_EB.Text.Trim(), 2) + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + Seguridad.Encripta(ID_CUS_PAT_EB.Text.Trim(), 2) + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + Seguridad.Encripta(ID_CUS_MAT_EB.Text.Trim(), 2) + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + Seguridad.Encripta(ID_CUS_PAS_EB.Text.Trim(), 2) + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " '" + mdlParametros.gprdProducto.TipoProductoS + "')";

                            if (CORPROC2.Modifica_Registro() >= 1)
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Se dio de alta el Usuario", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                switch (Strings.Len(ID_CUS_USU_EB.Text))
                                {
                                    case 8:
                                        CORSGUSU.DefInstance.ID_USU_USU_LB.Items.Add(ID_CUS_USU_EB.Text + new String(' ', 8) + ID_CUS_NOM_EB.Text);
                                        break;
                                    case 7:
                                        CORSGUSU.DefInstance.ID_USU_USU_LB.Items.Add(ID_CUS_USU_EB.Text + new String(' ', 9) + ID_CUS_NOM_EB.Text);
                                        break;
                                    case 6:
                                        CORSGUSU.DefInstance.ID_USU_USU_LB.Items.Add(ID_CUS_USU_EB.Text + new String(' ', 10) + ID_CUS_NOM_EB.Text);
                                        break;
                                    case 5:
                                        CORSGUSU.DefInstance.ID_USU_USU_LB.Items.Add(ID_CUS_USU_EB.Text + new String(' ', 11) + ID_CUS_NOM_EB.Text);
                                        break;
                                }
                                this.Close();
                                return;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("No se pudo dar de alta el Usuario", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            //Falta algun campo de llenar
                            return;
                        }
                        break;
                    case "B":  //CAMBIOS 
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "update MTCUSU01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " set";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_grupo = '" + Seguridad.Encripta(Conversion.Val(VB6.GetItemData(ID_CUS_GRU_COB, ID_CUS_GRU_COB.SelectedIndex).ToString()).ToString(), 2) + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", usu_nombre = '" + Seguridad.Encripta(ID_CUS_NOM_EB.Text.Trim(), 2) + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", usu_ape_pat = '" + Seguridad.Encripta(ID_CUS_PAT_EB.Text.Trim(), 2) + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", usu_ape_mat = '" + Seguridad.Encripta(ID_CUS_MAT_EB.Text.Trim(), 2) + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", usu_cve_per = '" + Seguridad.Encripta(ID_CUS_PAS_EB.Text.Trim(), 2) + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_clave = '" + Seguridad.Encripta(ID_CUS_USU_EB.Text.Trim(), 2) + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                            if (CORPROC2.Modifica_Registro() >= 1)
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Se Actualizaron los valores para el usuario " + ID_CUS_USU_EB.Text, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                return;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("No se pudo dar de alta el cambio del Usuario", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            //Falta algun campo de llenar
                            return;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CUS_ACE_PB_Click)", e);
            }
        }

        private bool Valida_Datos()
        {

            this.Cursor = Cursors.WaitCursor;

            if (ID_CUS_USU_EB.Text == "")
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se admite el espacio en el campo Usuario.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_USU_EB.Text.Trim().IndexOf(' ') >= 0)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se admite el espacio en el campo Usuario.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_USU_EB.Text.Trim().Length < 6)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("La longitud del Usuario no puede ser menor de 6 caracteres.", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_GRU_COB.SelectedIndex != -1)
            {
                if (VB6.GetItemData(ID_CUS_GRU_COB, ID_CUS_GRU_COB.SelectedIndex) == 0)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Se necesita seleccionar algo en el campo Grupo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Se necesita seleccionar algo en el campo Grupo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_NOM_EB.Text == "")
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se admite el espacio en el campo Nombre.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_PAT_EB.Text == "")
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se admite el espacio en el campo Paterno.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_MAT_EB.Text == "")
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se admite el espacio en el campo Materno.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_PAS_EB.Text == "")
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se admite el espacio en el campo Clave Personal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_PAS_EB.Text.Trim().IndexOf(' ') >= 0)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se admite el espacio en el campo Clave Personal.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (ID_CUS_PAS_EB.Text.Trim().Length < 3)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("La longitud de la Clave Personal no puede ser menor de 3 caracteres.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Formato.sgForma == "A")
            {
                CORVAR.pszgblsql = "select *";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_clave = '" + Seguridad.Encripta(ID_CUS_USU_EB.Text.Trim(), 2) + "'";

                //    pszgblsql = "select *"
                //    pszgblsql = pszgblsql & " from MTCUSER01"
                //    pszgblsql = pszgblsql & " where usu_clave = '" & Encripta(Trim(ID_CUS_USU_EB.Text), 2) & "'"

                if (CORPROC2.Cuenta_Registros() >= 1)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No se puede dar de alta el usuario porque ya existe .", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;

        }

        private void ID_CUS_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void ID_CUS_MAT_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "");
            //KeyAscii = Asc(UCase$(Chr$(KeyAscii)))
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_CUS_NOM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "");
            //KeyAscii = Asc(UCase$(Chr$(KeyAscii)))
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_CUS_PAS_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_CUS_PAT_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "");
            //KeyAscii = Asc(UCase$(Chr$(KeyAscii)))
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_CUS_USU_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "");
            //KeyAscii = Asc(UCase$(Chr$(KeyAscii)))
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        private void CORSGCUS_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}