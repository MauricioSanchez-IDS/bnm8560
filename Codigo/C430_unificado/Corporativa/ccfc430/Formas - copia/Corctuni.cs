using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORCTUNI
        : System.Windows.Forms.Form
    {

        const int INT_MAX_GRUPOS = 999;
        const int INT_MAX_EMPRESAS = 999;
        const int INT_MAX_UNIDADES = 999;

        int lTotalGrupos = 0;
        int lTotalEmpresas = 0;
        int lTotalUnidaes = 0;
        int lUnidadesRestantes = 0;

        private void Carga_Grupos()
        {
            double lGruposRestantes = 0;
            int iError = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;

            this.Cursor = Cursors.WaitCursor;

            ID_CEE_UNI_LB.Items.Clear();
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
                    ID_CEE_GRU_COB.Items.Add(StringsHelper.Format(iCorCve, "0000") + CORCONST.SPC_TRES + pszCorDesc.Trim());
                    iCont++;
                };

                lGruposRestantes = lTotalGrupos - iCont;

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

        private void CORCTUNI_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                ID_CEE_EMP_COB_SelectedIndexChanged(ID_CEE_EMP_COB, new EventArgs());
            }
        }

        //AIS-1609 FSABORIO
        private bool CerrarFormulario = false;
        private bool CargandoFormulario = false;
        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            //AIS-1609 FSABORIO
            CargandoFormulario = true;
            this.Cursor = Cursors.WaitCursor;

            this.Height = (int)VB6.TwipsToPixelsY(5220);
            this.Width = (int)VB6.TwipsToPixelsX(7950);
            this.Top = (int)((CORMDIBN.DefInstance.ClientRectangle.Height - this.Height) / 2);
            this.Left = (int)(CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2;
            this.Show();
            this.Refresh();

            //  If bgblAdmin Then
            //    ID_CEE_ALT_PB.Enabled = True
            //    ID_CEE_BAJ_PB.Enabled = True
            //    ID_CEE_CAM_PB.Enabled = True
            //    ID_CEE_CON_PB.Enabled = True
            //  Else
            //    ID_CEE_ALT_PB.Enabled = OpcionesAcceso(3).bAltas
            //    ID_CEE_BAJ_PB.Enabled = OpcionesAcceso(3).bBajas
            //    ID_CEE_CAM_PB.Enabled = OpcionesAcceso(3).bCambios
            //    ID_CEE_CON_PB.Enabled = OpcionesAcceso(3).bConsultas
            //  End If
            mdlParametros.gperPerfil.prHabilitaAcciones(CORCTUNI.DefInstance);
            Carga_Grupos();
            //AIS-1609 FSABORIO
            CargandoFormulario = false;
        }

        private void ID_CEE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    Formato.pszAccion = CORCONST.TAG_ALTA;
                    CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                    CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
                    Formato.sgForma = "A";

                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " count(*)";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + "0";
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) == 0)
                            {
                                MessageBox.Show("No se puede dar de alta la unidad porque aun no existe el Ejecutivo = 0", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Cursor = Cursors.Default;
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                return;
                            }
                        };
                    }
                    frm_unidades tempLoadForm = frm_unidades.DefInstance;
                    if (Formato.bgForma)
                    {
                        frm_unidades.DefInstance.Show();
                    }
                    else
                    {
                        frm_unidades.DefInstance.Close();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existen Empresas para dar de alta Unidades", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CEE_ALT_PB_Click " + exc.Message, "Error Corctuni", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CEE_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iCont = 0;
            //Dim pszClave    As String

            this.Cursor = Cursors.WaitCursor;
            //pszClave = Format$(Left(ID_CEE_EMP_COB.Text, Len(sMascara(Empresa))), sMascara(Empresa)) + Format$(Left(ID_CEE_UNI_LB.Text, Len(sMascara(Ejecutivo))), sMascara(Ejecutivo))
            try
            {
                if (ID_CEE_UNI_LB.Items.Count > 0)
                {
                    if (ListBoxHelper.GetSelectedIndex(ID_CEE_UNI_LB) != -1)
                    {
                        if (MessageBox.Show("Deseas dar de baja la Unidad: " + Strings.Mid(ID_CEE_UNI_LB.Text, 19, 40).Trim(), "Tarjeta Corporativa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            CORVAR.pszgblsql = "select unit_id from MTCUNI01 where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString() + " and unit_parent_id = '" + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num=  " + CORVAR.igblNumGrupo.ToString();
                            if (CORPROC2.Cuenta_Registros() <= 0)
                            {
                                CORVAR.pszgblsql = "select eje_num from MTCEJE01 where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString() + " and eje_centro_c = '" + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";

                                if (CORPROC2.Cuenta_Registros() <= 0)
                                {
                                    CORVAR.pszgblsql = "delete MTCUNI01 where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString() + " and unit_id = '" + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                                    iCont = 0;
                                    iCont = CORPROC2.Modifica_Registro();
                                    if (iCont == 1)
                                    {
                                        CORVAR.pszgblsql = "select * from MTCURP01 where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString() + " and unit_id = '" + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                                        if (CORPROC2.Cuenta_Registros() >= 1)
                                        {
                                            CORVAR.pszgblsql = "delete MTCURP01 where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString() + " and unit_id = '" + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                                            iCont = 0;
                                            iCont = CORPROC2.Modifica_Registro();
                                            if (iCont < 1)
                                            {
                                                MessageBox.Show("No se pudieron dar de Baja los Reportes", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        CORVAR.pszgblsql = "select * from MTCUCT01 where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString() + " and unit_id = '" + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                                        if (CORPROC2.Cuenta_Registros() >= 1)
                                        {
                                            CORVAR.pszgblsql = "delete MTCUCT01 where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString() + " and unit_id = '" + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
                                            iCont = 0;
                                            iCont = CORPROC2.Modifica_Registro();
                                            if (iCont < 1)
                                            {
                                                MessageBox.Show("No se pudieron dar de Baja las Categorías", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        MessageBox.Show("Se dio de baja la Unidad: " + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ID_CEE_UNI_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEE_UNI_LB));
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se dio de baja la Unidad: " + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La Unidad: " + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + " no se puede eliminar porque tiene Ejecutivos", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La Unidad: " + ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + " no se puede eliminar porque tiene Unidades Hijo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("No se ha seleccionado ninguna Unidad para dar de Baja", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No hay ninguna Unidad para dar de Baja", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CEE_BAJ_PB_Click " + exc.Message, "Error Corctuni", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CEE_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            if (ID_CEE_UNI_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                if (ListBoxHelper.GetSelectedIndex(ID_CEE_UNI_LB) != -1)
                {
                    if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
                    {
                        Formato.igNumUnit = StringsHelper.DoubleValue(ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).ToString());

                        this.Cursor = Cursors.WaitCursor;

                        if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
                        {
                            Formato.pszAccion = CORCONST.TAG_ALTA;
                            CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                            CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
                            if (ID_CEE_IRE_CKB.Value)
                            {
                                Formato.sgForma = "E";
                                CORIRUNI.DefInstance.Show();
                            }
                            else
                            {
                                Formato.sgForma = "B";
                                frm_unidades tempLoadForm = frm_unidades.DefInstance;
                                if (Formato.bgForma)
                                {
                                    frm_unidades.DefInstance.Show();
                                }
                                else
                                {
                                    frm_unidades.DefInstance.Close();
                                }
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("No existen Empresas para dar de alta Unidades", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("No existen Empresas para dar de alta Unidades", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Aun no se ha seleccionado ninguna unidad", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            }

        }

        private void ID_CEE_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            if (ID_CEE_UNI_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                if (ListBoxHelper.GetSelectedIndex(ID_CEE_UNI_LB) != -1)
                {

                    Formato.igNumUnit = StringsHelper.DoubleValue(ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).ToString());

                    this.Cursor = Cursors.WaitCursor;

                    if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
                    {
                        Formato.pszAccion = CORCONST.TAG_ALTA;
                        CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                        CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
                        if (ID_CEE_IRE_CKB.Value)
                        {
                            Formato.sgForma = "D";
                            CORIRUNI.DefInstance.Show();
                        }
                        else
                        {
                            Formato.sgForma = "C";
                            frm_unidades tempLoadForm = frm_unidades.DefInstance;
                            if (Formato.bgForma)
                            {
                                frm_unidades.DefInstance.Show();
                            }
                            else
                            {
                                frm_unidades.DefInstance.Close();
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("No existen Empresas para dar de alta Unidades", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Aun no se ha seleccionado ninguna unidad", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            }

        }

        private void ID_CEE_CON_TARJ_Click(Object eventSender, EventArgs eventArgs)
        {

            if (ID_CEE_UNI_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                if (ListBoxHelper.GetSelectedIndex(ID_CEE_UNI_LB) != -1)
                {

                    Formato.igNumUnit = StringsHelper.DoubleValue(ID_CEE_UNI_LB.Text.Substring(0, Math.Min(ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).ToString());

                    this.Cursor = Cursors.WaitCursor;

                    if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
                    {
                        Formato.pszAccion = CORCONST.TAG_ALTA;
                        CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                        CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
                        frm_cons_tarj_uni tempLoadForm = frm_cons_tarj_uni.DefInstance;
                        if (Formato.bgForma)
                        {
                            frm_cons_tarj_uni.DefInstance.Show();
                        }
                        else
                        {
                            frm_cons_tarj_uni.DefInstance.Close();
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("No existen Empresas para realizar la consulta de TarjetaHabientes Asignados a Unidades", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Aun no se ha seleccionado ninguna unidad", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            }

        }

        private void ID_CEE_EMP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            object ID_CEE_MAS_3PB = null;
            string UniCve = String.Empty;
            string UniDesc = String.Empty;
            int iError = 0;
            int hEjeEmp = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;

            ID_CEE_UNI_LB.Items.Clear();

            int iCorCve = Convert.ToInt32(Conversion.Val(ID_CEE_GRU_COB.Text.Substring(0, Math.Min(ID_CEE_GRU_COB.Text.Length, 4))));
            double lEmpCve = Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)));

            CORVAR.lgblNumEmpresa = Convert.ToInt32(lEmpCve);

            CORVAR.pszgblsql = "select unit_id, unit_name from " + CORBD.DB_SYB_UNI;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where  eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(lEmpCve).Trim();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + Conversion.Val(ID_CEE_GRU_COB.Text.Substring(0, Math.Min(ID_CEE_GRU_COB.Text.Length, 4))).ToString();



            lTotalUnidaes = CORPROC2.Cuenta_Registros();
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (lTotalUnidaes != CORVB.NULL_INTEGER)
                {
                    if (lTotalUnidaes > INT_MAX_UNIDADES)
                    {
                        //UPGRADE_NOTE: (7004) Member access to a non initialized variable. Variable ID_CEE_MAS_3PB Member Enabled.
                        ReflectionHelper.SetMember(ID_CEE_MAS_3PB, "Enabled", true);
                    }

                    while (!((VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS) || (iCont >= INT_MAX_UNIDADES)))
                    {
                        UniCve = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                        UniDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_CEE_UNI_LB.Items.Add(UniCve + CORCONST.SPC_TRES + UniDesc.Trim());
                        iCont++;
                    };
                    lUnidadesRestantes = lTotalUnidaes - iCont;

                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_CEE_UNI_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_UNI_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

            Application.DoEvents();

        }

        private void ID_CEE_GRU_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            double lEmpCve = 0;

            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCorCve = 0;
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;

            ID_CEE_EMP_COB.Items.Clear();
            ID_CEE_UNI_LB.Items.Clear();

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
                        lEmpCve = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                        pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_CEE_EMP_COB.Items.Add(StringsHelper.Format(lEmpCve, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
                        iCont++;
                    };
                }
            }
            else
            {
                MessageBox.Show("No se encontro ninguna Empresa para este grupo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
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
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;
            CORCTUNI.DefInstance.Close();

        }
        private void CORCTUNI_Closed(Object eventSender, EventArgs eventArgs)
        {
            MemoryHelper.ReleaseMemory();
        }

        //AIS-1609 FSABORIO
        private void CORCTUNI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CargandoFormulario)
            {
                e.Cancel = true;
                CerrarFormulario = true;
            }
        }

        //AIS-1609 FSABORIO
        private void CORCTUNI_Shown(object sender, EventArgs e)
        {
            if (CerrarFormulario)
                this.Close();
        }
    }
}