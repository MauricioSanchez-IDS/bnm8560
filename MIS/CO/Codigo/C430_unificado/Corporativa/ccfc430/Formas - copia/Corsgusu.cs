using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORSGUSU
        : System.Windows.Forms.Form
    {

        private void CORSGUSU_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        string pszCadena = String.Empty;
        int hUsuConexion = 0;
        FixedLengthString[] szArrUsuarios = ArraysHelper.InitializeArray<FixedLengthString[]>(new int[] { }, new object[] { });

        private void Carga_Usuarios()
        {

            string sCveUser = String.Empty;
            string sNomUser = String.Empty;

            ID_USU_USU_LB.Items.Clear();

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_nombre";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by usu_clave";

            if (CORPROC2.Cuenta_Registros() >= 1)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        sCveUser = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToUpper();
                        sNomUser = Seguridad.DesEncripta(VBSQL.SqlData(CORVAR.hgblConexion, 2)).ToUpper();
                        switch (sCveUser.Length)
                        {
                            case 8:
                                ID_USU_USU_LB.Items.Add(sCveUser + new String(' ', 8) + sNomUser);
                                break;
                            case 7:
                                ID_USU_USU_LB.Items.Add(sCveUser + new String(' ', 9) + sNomUser);
                                break;
                            case 6:
                                ID_USU_USU_LB.Items.Add(sCveUser + new String(' ', 10) + sNomUser);
                                break;
                        }
                    };
                    ID_USU_USU_LB.SelectedIndex = 0;
                }
            }
            else
            {
                ID_USU_USU_LB.SelectedIndex = -1;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        private bool Checa_Grupos()
        {

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

            int iCont = CORPROC2.Cuenta_Registros();

            return iCont >= 1;

        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Cursor = Cursors.WaitCursor;

            this.Height = (int)VB6.TwipsToPixelsY(4020);
            this.Width = (int)VB6.TwipsToPixelsX(5595);
            this.Top = (int)VB6.TwipsToPixelsY(1995);
            this.Left = (int)VB6.TwipsToPixelsX(4815);
            Carga_Usuarios();

            this.Cursor = Cursors.Default;

        }

        private void ID_USU_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            try
            {

                if (Checa_Grupos())
                {
                    Formato.sgForma = "A"; //ALTAS
                    CORSGCUS tempLoadForm = CORSGCUS.DefInstance;
                    CORSGCUS.DefInstance.Show();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No se encontro ningun tipo de Perfil en la Base de Datos por lo que se no se podra dar de alta", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_USU_ALT_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_USU_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                if (Seguridad.Encripta(Strings.Mid(ID_USU_USU_LB.Text, 1, 9).Trim(), 2) == "ëè¿½¾û")
                {
                    MessageBox.Show("Este usuario no se puede eliminar.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("¿Desea dar de baja al usuario: " + ID_USU_USU_LB.Text.Trim() + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        this.Cursor = Cursors.WaitCursor;

                        if (ID_USU_USU_LB.Items.Count > 0)
                        {
                            if (ListBoxHelper.GetSelectedIndex(ID_USU_USU_LB) != -1)
                            {
                                CORVAR.pszgblsql = "select";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_clave";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_clave = '" + Seguridad.Encripta(Strings.Mid(ID_USU_USU_LB.Text, 1, 9).Trim(), 2) + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                                if (CORPROC2.Cuenta_Registros() >= 1)
                                {
                                    CORVAR.pszgblsql = "delete";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_clave = '" + Seguridad.Encripta(Strings.Mid(ID_USU_USU_LB.Text, 1, 9).Trim(), 2) + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                                    if (CORPROC2.Modifica_Registro() >= 1)
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("Se dio de baja con exito el Usuario", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ID_USU_USU_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_USU_USU_LB));
                                        return;
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("No se pudo dar de baja el Usuario", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("No se encontro ningun usuario similar al seleccionado", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("No se ha seleccionado ningun usuario", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("No existe ningun usuario en la lista", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_USU_BAJ_PB_Click)", e);
            }
        }

        private void ID_USU_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                if (Seguridad.Encripta(Strings.Mid(ID_USU_USU_LB.Text, 1, 9).Trim(), 2) == "ëè¿½¾û")
                {
                    MessageBox.Show("Este usuario no se puede cambiar.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Checa_Grupos())
                    {
                        Formato.sgForma = "B"; //CAMBIOS
                        CORSGCUS tempLoadForm = CORSGCUS.DefInstance;
                        if (Formato.bgForma)
                        {
                            CORSGCUS.DefInstance.Show();
                        }
                        else
                        {
                            CORSGCUS.DefInstance.Close();
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No se encontro ningun tipo de Perfil en la Base de Datos por lo que se no se podra realizar ningun Cambio", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_USU_CAM_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_USU_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                if (Seguridad.Encripta(Strings.Mid(ID_USU_USU_LB.Text, 1, 9).Trim(), 2) == "ëè¿½¾û")
                {
                    MessageBox.Show("Este usuario no se puede consultar.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Checa_Grupos())
                    {
                        Formato.sgForma = "C"; //CONSULTAS
                        CORSGCUS tempLoadForm = CORSGCUS.DefInstance;
                        if (Formato.bgForma)
                        {
                            CORSGCUS.DefInstance.Show();
                        }
                        else
                        {
                            CORSGCUS.DefInstance.Close();
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No se encontro ningun tipo de Perfil en la Base de Datos por lo que se no se podra Consultar", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_USU_CON_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_USU_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        //UPGRADE_NOTE: (7001) The following declaration (ID_USU_USU_EB_Change) seems to be dead code
        //private void  ID_USU_USU_EB_Change()
        //{
        //
        //ID_USU_BAJ_PB.Enabled = Strings.Mid(VB6.GetItemString(ID_USU_USU_LB, ListBoxHelper.GetSelectedIndex(ID_USU_USU_LB)), 1, CORBD.LEN_USU_CVE) != CORCONST.ADM_USU_CVE;
        //
        //}

        private void ID_USU_USU_EB_GotFocus()
        {
            pszCadena = CORVB.NULL_STRING;
        }


        //UPGRADE_NOTE: (7001) The following declaration (ID_USU_USU_EB_KeyUp) seems to be dead code
        //private void  ID_USU_USU_EB_KeyUp( int KeyCode,  int Shift)
        //{
        //
        //if (KeyCode == 8)
        //{
        //ID_USU_USU_EB_GotFocus();
        //}
        //
        //}

        private void ID_USU_USU_LB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            string pszUsuario = String.Empty;

            if (ListBoxHelper.GetSelectedIndex(ID_USU_USU_LB) >= CORVB.NULL_INTEGER)
            {
                pszUsuario = VB6.GetItemString(ID_USU_USU_LB, ListBoxHelper.GetSelectedIndex(ID_USU_USU_LB));
                if (pszUsuario.IndexOf(' ') >= 0)
                {
                    pszUsuario = Strings.Mid(pszUsuario, 1, pszUsuario.IndexOf(' '));
                }

                ID_USU_BAJ_PB.Enabled = pszUsuario != CORCONST.ADM_USU_CVE;
            }

        }
        private void CORSGUSU_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}