using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class frm_men_rep
        : System.Windows.Forms.Form
    {

        private void frm_men_rep_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        public enum EnTipoReporte
        {
            rptGrupo = 0,
            rptGrupoEmpresa = 1,
            RptGrupoEmpresaUnidad = 2
        }

        const int INT_MAX_GRUPOS = 999;
        const int INT_MAX_EMPRESAS = 999;
        const int INT_MAX_UNIDADES = 999;

        int lTotalGrupos = 0;
        int lTotalEmpresas = 0;
        int lTotalUnidaes = 0;
        int lUnidadesRestantes = 0;
        EnTipoReporte[] AsTipoReporte = new EnTipoReporte[3];
        public EnTipoReporte TipoReporteProcesar = (EnTipoReporte)0;



        private void ChkNivel_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {

            CboNivel.Enabled = ChkNivel.CheckState == CheckState.Checked;
            if (ChkNivel.CheckState == CheckState.Checked)
            {
                PrListaNiveles();
            }
            else
            {
                CboNivel.Items.Clear();
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            AsTipoReporte[0] = EnTipoReporte.rptGrupo;
            AsTipoReporte[1] = EnTipoReporte.rptGrupoEmpresa;
            AsTipoReporte[2] = EnTipoReporte.RptGrupoEmpresaUnidad;

            this.Cursor = Cursors.WaitCursor;

            this.Height = (int)VB6.TwipsToPixelsY(4905);
            this.Width = (int)VB6.TwipsToPixelsX(7935);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Show();
            this.Refresh();

            //  If bgblAdmin Then
            //    ID_CEE_ALT_PB.Enabled = True
            //    ID_CEE_CAM_PB.Enabled = True
            //    ID_CEE_CON_PB.Enabled = True
            //  Else
            //    ID_CEE_ALT_PB.Enabled = OpcionesAcceso(8).bAltas
            //    ID_CEE_CAM_PB.Enabled = OpcionesAcceso(8).bCambios
            //    ID_CEE_CON_PB.Enabled = OpcionesAcceso(8).bConsultas
            //  End If
            mdlParametros.gperPerfil.prHabilitaAcciones(frm_men_rep.DefInstance);
            OptReporte[0].Checked = true;
            ChkNivel.CheckState = CheckState.Unchecked;
            CboNivel.Enabled = false;

            Application.DoEvents();
            //Carga_Grupos

        }

        //UPGRADE_NOTE: (7001) The following declaration (ID_CEE_ALT_PB_Click) seems to be dead code
        //private void  ID_CEE_ALT_PB_Click()
        //{
        //this.Cursor = Cursors.WaitCursor;
        //
        //if (ID_CEE_UNI_COB.Items.Count > CORVB.NULL_INTEGER)
        //{
        //CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
        //CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
        //
        //CORVAR.pszgblsql = "select *";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCURP01";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + ID_CEE_UNI_COB.Text.Substring(0, Math.Min(ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";
        //if (CORPROC2.Cuenta_Registros() == 0)
        //{
        //Formato.sgForma = "A";
        //
        //frm_reportes tempLoadForm = frm_reportes.DefInstance;
        //if (Formato.bgForma)
        //{
        //frm_reportes.DefInstance.Show();
        //} else
        //{
        //frm_reportes.DefInstance.Close();
        //}
        //} else
        //{
        //this.Cursor = Cursors.Default;
        //MessageBox.Show("Los reportes de la Unidad: " + ID_CEE_UNI_COB.Text.Substring(0, Math.Min(ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim() + "  ya fueron dados de alta. Por lo que solo podras realizar Cambios.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //return;
        //}
        //} else
        //{
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("No existen Unidades para dar de alta sus Reportes", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //}
        //
        //this.Cursor = Cursors.Default;
        //
        //}

        private void ID_CEE_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (OptReporte[0].Checked)
                { //Grupo
                    //Consulta que determina si la unidad no está dada de alta en todas las empresas
                    CORVAR.pszgblsql = "Select A.eje_prefijo,A.gpo_banco, A.unit_id , A.unit_parent_id, A.nivel_num, A.gpo_num, Count(A.unit_id)";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01 A";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " Where A.gpo_num = " + Strings.Mid(VB6.GetItemString(ID_CEE_GRU_COB, ID_CEE_GRU_COB.SelectedIndex), 1, 4);
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " And A.eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " And gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " group by A.eje_prefijo,A.gpo_banco, A.unit_id, A.unit_parent_id , A.nivel_num ,A.gpo_num";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " having Count(A.unit_id) <> (Select Count (B.unit_id) from MTCUNI01 B";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where B.gpo_num = A.gpo_num and B.nivel_num = 1  and A.eje_prefijo = B.eje_prefijo  and B.gpo_banco = A.gpo_banco)";

                    //pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where eje_prefijo = " & Str(igblPref) & " and gpo_banco = " + Str(igblBanco)

                    if (CORPROC2.Cuenta_Registros() != 0)
                    {
                        //Cada unidad en sus diferentes niveles debe estar dada de alta
                        //en cada empresa
                        this.Cursor = Cursors.Default;
                        VBSQL.SqlCancel(CORVAR.hgblConexion);
                        MdlCambioMasivo.MsgInfo("Se encontrarón unidades que no se han dado de alta en todas las empresas del grupo" + "\r" +
                                                "Favor de darlas de alta para continuar");
                        return;
                    }
                    VBSQL.SqlCancel(CORVAR.hgblConexion);

                    if (ChkNivel.CheckState == CheckState.Checked && CboNivel.SelectedIndex == -1)
                    {
                        MdlCambioMasivo.MsgInfo("Debe elegir un nivel de la lista");
                    }
                }
                else if (OptReporte[1].Checked)
                {  //Grupo - empresa
                    if (ChkNivel.CheckState == CheckState.Checked && CboNivel.SelectedIndex == -1)
                    {
                        MdlCambioMasivo.MsgInfo("Debe elegir un nivel de la lista");
                    }
                    else
                    {
                        //Determina la unidad padre

                        CORVAR.pszgblsql = "Select A.eje_prefijo,A.gpo_banco, A.unit_id , A.unit_parent_id, A.nivel_num, A.gpo_num, Count(A.unit_id)";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01 A";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " group by A.eje_prefijo,A.gpo_banco, A.unit_id, A.unit_parent_id , A.nivel_num ,A.gpo_num";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " having Count(A.unit_id) <> (Select Count (B.unit_id) from MTCUNI01 B";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where B.gpo_num = A.gpo_num and B.nivel_num = 1  and A.eje_prefijo = B.eje_prefijo  and B.gpo_banco = A.gpo_banco)";
                        CORVAR.pszgblsql = "SELECT unit_id from MTCUNI01 ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " Where A.gpo_num = " + Strings.Mid(VB6.GetItemString(ID_CEE_GRU_COB, ID_CEE_GRU_COB.SelectedIndex), 1, 4);
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " And A.eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " And gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num = " + Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and nivel_num = 1 ";
                    }

                }
                else if (OptReporte[2].Checked)
                {  //Grupo empresa unidad
                    //La unidad es un registro obligatorio
                    if (ID_CEE_UNI_COB.SelectedIndex == -1)
                    {
                        this.Cursor = Cursors.Default;
                        string tempRefParam = CORSTR.STR_APP_TIT;
                        MdlCambioMasivo.MsgInfo("Debe elegir una unidad del catálogo", ref tempRefParam);
                        this.Cursor = Cursors.Default;
                        return;
                    }

                }
                CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
                Formato.sgForma = "B"; //Manda el valor de cambios debido a que la calificacion puede existir o no
                frm_reportes tempLoadForm = frm_reportes.DefInstance;
                if (Formato.bgForma)
                {
                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    frm_reportes.DefInstance.ShowDialog();
                }
                else
                {
                    frm_reportes.DefInstance.Close();
                    this.Cursor = Cursors.Default;

                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEE_CAM_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CEE_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (OptReporte[2].Checked)
            {
                if (ID_CEE_UNI_COB.SelectedIndex == -1)
                {

                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existen Unidades para consultar sus Reportes", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return;
                }


            }
            CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
            CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
            Formato.sgForma = "C";
            frm_reportes tempLoadForm = frm_reportes.DefInstance;
            if (Formato.bgForma)
            {
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                frm_reportes.DefInstance.ShowDialog();
            }
            else
            {
                frm_reportes.DefInstance.Close();
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
            int lEmpCve = 0;
            ID_CEE_UNI_COB.Items.Clear();
            if (ID_CEE_EMP_COB.SelectedIndex == -1)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            if (TipoReporteProcesar == EnTipoReporte.RptGrupoEmpresaUnidad)
            {
                //Verifica que cuando el reporte llega a nivel de unidades hace la consulta de la lista de unidades a procesar

                lEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                CORVAR.lgblNumEmpresa = lEmpCve;

                CORVAR.pszgblsql = "select unit_id, unit_name from " + CORBD.DB_SYB_UNI;
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where  eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(lEmpCve).Trim();

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
            }
            this.Cursor = Cursors.Default;

            Application.DoEvents();

        }

        private void ID_CEE_GRU_COB_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
        {
            int iCorNum = 0;
            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCorCve = 0;
            int iCont = 0;
            int lEmpCve = 0;
            this.Cursor = Cursors.WaitCursor;

            ID_CEE_EMP_COB.Items.Clear();
            ID_CEE_UNI_COB.Items.Clear();
            if (TipoReporteProcesar != EnTipoReporte.rptGrupo)
            {
                iCorNum = Convert.ToInt32(Conversion.Val(ID_CEE_GRU_COB.Text.Substring(0, Math.Min(ID_CEE_GRU_COB.Text.Length, 4))));

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
            }
            this.Cursor = Cursors.Default;

        }

        private void ID_CEE_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
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
            if (TipoReporteProcesar == EnTipoReporte.rptGrupo)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num <> 0";
            }

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

                //    lGruposRestantes = lTotalGrupos - iCont

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

        private bool isInitializingComponent;
        private void OptReporte_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (((RadioButton)eventSender).Checked)
            {
                int Index = Array.IndexOf(OptReporte, eventSender);
                ChkNivel.CheckState = CheckState.Unchecked;
                ChkNivel.Enabled = (Index != 2);
                ID_CEE_EMP_COB.Enabled = Index != 0;
                ID_CEE_UNI_COB.Enabled = Index == 2;
                TipoReporteProcesar = AsTipoReporte[Index];
                Carga_Grupos();
            }
        }
        private void PrListaNiveles()
        {
            CboNivel.Items.Clear();
            CORVAR.pszgblsql = "Select nivel_num ";

            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + Conversion.Str(CORVAR.igblPref) + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
            if (ID_CEE_GRU_COB.SelectedIndex > -1)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + " And gpo_num =" + Conversion.Val(Strings.Mid(ID_CEE_GRU_COB.Text, 1, 5)).ToString();
            }
            if (ID_CEE_EMP_COB.SelectedIndex > -1)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Strings.Mid(ID_CEE_EMP_COB.Text, 1, 5);
            }
            CORVAR.pszgblsql = CORVAR.pszgblsql + " group by nivel_num";
            int lTotalNiveles = CORPROC2.Cuenta_Registros();
            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    CboNivel.Items.Add(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                };
            }
        }
        private void frm_men_rep_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ID_CEE_GRU_COB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iCorNum = 0;
            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCorCve = 0;
            int iCont = 0;
            int lEmpCve = 0;
            this.Cursor = Cursors.WaitCursor;

            ID_CEE_EMP_COB.Items.Clear();
            ID_CEE_UNI_COB.Items.Clear();
            if (TipoReporteProcesar != EnTipoReporte.rptGrupo)
            {
                iCorNum = Convert.ToInt32(Conversion.Val(ID_CEE_GRU_COB.Text.Substring(0, Math.Min(ID_CEE_GRU_COB.Text.Length, 4))));

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
            }
            this.Cursor = Cursors.Default;
        }
    }
}