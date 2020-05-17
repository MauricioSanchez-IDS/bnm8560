using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class frm_men_cat
        : System.Windows.Forms.Form
    {

        private void frm_men_cat_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        const int INT_MAX_GRUPOS = 999;
        const int INT_MAX_EMPRESAS = 999;
        const int INT_MAX_UNIDADES = 999;

        int lTotalGrupos = 0;
        int lTotalEmpresas = 0;
        int lTotalUnidaes = 0;
        int lUnidadesRestantes = 0;

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Cursor = Cursors.WaitCursor;

            this.Height = (int)VB6.TwipsToPixelsY(2565);
            this.Width = (int)VB6.TwipsToPixelsX(9660);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Show();
            this.Refresh();

            if (CORVAR.bgblAdmin != 0)
            {
                ID_CEE_ALT_PB.Enabled = true;
                ID_CEE_CAM_PB.Enabled = true;
                ID_CEE_CON_PB.Enabled = true;
            }
            else
            {
                ID_CEE_ALT_PB.Enabled = CORVAR.OpcionesAcceso[9].bAltas;
                ID_CEE_CAM_PB.Enabled = CORVAR.OpcionesAcceso[9].bCambios;
                ID_CEE_CON_PB.Enabled = CORVAR.OpcionesAcceso[9].bConsultas;
            }

            Carga_Grupos();

        }

        private void Carga_Grupos()
        {

            int iError = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;

            this.Cursor = Cursors.WaitCursor;

            ID_CEE_UNI_COB.Items.Clear();
            ID_CEE_EMP_COB.Items.Clear();
            ID_CEE_GRU_COB.Items.Clear();

            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo = " + Conversion.Str(CORVAR.igblPref) + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco);

            lTotalGrupos = CORPROC2.Cuenta_Registros();

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                if (lTotalGrupos > INT_MAX_GRUPOS)
                {

                }



                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iCorCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszCorDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_CEE_GRU_COB.Items.Add(StringsHelper.Format(iCorCve, "0000") + new String(' ', 14) + pszCorDesc.Trim());
                    iCont++;
                };

            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_CEE_GRU_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CEE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ID_CEE_UNI_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                    CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();

                    CORVAR.pszgblsql = "select *";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUCT01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + ID_CEE_UNI_COB.Text.Substring(0, Math.Min(ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim() + "'";
                    if (CORPROC2.Cuenta_Registros() == 0)
                    {
                        Formato.sgForma = "A";

                        frm_categorias tempLoadForm = frm_categorias.DefInstance;
                        if (Formato.bgForma)
                        {
                            frm_categorias.DefInstance.Show();
                        }
                        else
                        {
                            frm_categorias.DefInstance.Close();
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Las categorias de la Unidad: " + ID_CEE_UNI_COB.Text.Substring(0, Math.Min(ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim() + "  ya fueron dadas de alta. Por lo que solo podras realizar Cambios.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existen Unidades para dar de alta sus Categorias", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEE_ALT_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CEE_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ID_CEE_UNI_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
                Formato.sgForma = "B";
                frm_categorias tempLoadForm = frm_categorias.DefInstance;
                if (Formato.bgForma)
                {
                    frm_categorias.DefInstance.Show();
                }
                else
                {
                    frm_categorias.DefInstance.Close();
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen Unidades para realizar cambios a sus Categorias", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CEE_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ID_CEE_UNI_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
                Formato.sgForma = "C";
                frm_categorias tempLoadForm = frm_categorias.DefInstance;
                if (Formato.bgForma)
                {
                    frm_categorias.DefInstance.Show();
                }
                else
                {
                    frm_categorias.DefInstance.Close();
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen Unidades para consultar sus Categorias", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CEE_EMP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            string UniCve = String.Empty;
            string UniDesc = String.Empty;
            int iError = 0;
            int hEjeEmp = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;

            ID_CEE_UNI_COB.Items.Clear();

            int lEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
            CORVAR.lgblNumEmpresa = lEmpCve;

            CORVAR.pszgblsql = "select unit_id, unit_name from " + CORBD.DB_SYB_UNI;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where  eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(lEmpCve).Trim() + " and gpo_num = " + iCorCve.ToString();

            lTotalUnidaes = CORPROC2.Cuenta_Registros();
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (lTotalUnidaes != CORVB.NULL_INTEGER)
                {

                    while (!((VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS) || (iCont >= INT_MAX_UNIDADES)))
                    {
                        UniCve = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                        UniDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_CEE_UNI_COB.Items.Add(UniCve + CORCONST.SPC_TRES + UniDesc.Trim());
                        iCont++;
                    };
                    lUnidadesRestantes = lTotalUnidaes - iCont;
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_CEE_UNI_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_UNI_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

            Application.DoEvents();

        }

        private void ID_CEE_GRU_COB_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
        {
            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCorCve = 0;
            int iCont = 0;
            int lEmpCve = 0;
            this.Cursor = Cursors.WaitCursor;

            ID_CEE_EMP_COB.Items.Clear();
            ID_CEE_UNI_COB.Items.Clear();

            int iCorNum = Convert.ToInt32(Conversion.Val(ID_CEE_GRU_COB.Text.Substring(0, Math.Min(ID_CEE_GRU_COB.Text.Length, 4))));

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_nom";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYB_EMP;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where gpo_num = " + iCorNum.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo =" + Conversion.Str(CORVAR.igblPref);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco =" + Conversion.Str(CORVAR.igblBanco);

            if (CORPROC2.Cuenta_Registros() >= 1)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        lEmpCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_CEE_EMP_COB.Items.Add(StringsHelper.Format(lEmpCve, Formato.sMascara(Formato.iTipo.Empresa)) + new String(' ', 12) + pszEmpDesc.Trim());
                        iCont++;
                    };
                }
            }
            else
            {
                MessageBox.Show("No se encontro ninguna Empresa para este grupo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_CEE_EMP_COB.Items.Count > 0)
            {
                ID_CEE_EMP_COB.SelectedIndex = 0;
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CEE_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }
        private void frm_men_cat_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}