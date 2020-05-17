using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORCTEJE
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Carga los ejecutivos que existen en el Catálogo -   **
        //**                    de Ejecutivos (MTCEJE01) y los pone a disposi-      **
        //**                    sición para Altas, Bajas,Cambios y Consultas        **
        //**                                                                        **
        //**       Responsable: Abraham Ramírez Basurto                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 27/Abril/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        const string EJEEMP = "el ejecutivo de Empresa";

        const int INT_MAX_GRUPOS = 999;
        const int INT_MAX_EMPRESAS = 999;
        const int INT_MAX_EJECUTIVOS = 999;

        string pszAccion = String.Empty;
        int lEmpCve = 0;
        int lGruposRestantes = 0;
        int lEmpresasRestantes = 0;
        int lEjecutivosRestantes = 0;

        int lTotalGrupos = 0;
        int lTotalEmpresas = 0;
        int lTotalEjecutivos = 0;

        int hEjeGpo = 0;
        int hEjeEmpresa = 0;
        int hEjecutivo = 0;

        int hConexion = 0;
        string pszMsg = String.Empty;
        string pszSQL = String.Empty;

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

            //Limpia los ListBox
            ID_CEE_EMP_LB.Items.Clear();
            ID_CEE_EMP_COB.Items.Clear();


            ID_CEE_GRU_COB.Items.Clear();

            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTEIOR FSWBMX *****
            // pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco = " + Format(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            lTotalGrupos = CORPROC2.Cuenta_Registros();

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                if (lTotalGrupos > INT_MAX_GRUPOS)
                {
                    //ros 8/06/99      ID_CEM_MASG_3PB.Enabled = True
                }


                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros 8/06/99 And iCont < INT_MAX_GRUPOS
                    iCorCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszCorDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_CEE_GRU_COB.Items.Add(StringsHelper.Format(iCorCve, "0000") + CORCONST.SPC_TRES + pszCorDesc.Trim());
                    iCont++;
                };

                lGruposRestantes = lTotalGrupos - iCont;

            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


            //Posiciona en el Primer Elemento del ComboBox de Grupos
            if (ID_CEE_GRU_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            //Posiciona en el Primer Elemento del ComboBox de Empresas
            if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

        }

        private void cmdAltasMasivas_Click(Object eventSender, EventArgs eventArgs)
        {

            try
            {

                pszAccion = CORCONST.TAG_ALTA;

                CORVAR.pszgblsql = "select * from MTCMSV01";
                if (CORPROC2.Cuenta_Registros() > 0)
                {
                    MessageBox.Show("Existen registros en la tabla MTCMSV01 que no se han cargado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    return;
                }

                Application.DoEvents();
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));

                frmAltasMasivas tempLoadForm = frmAltasMasivas.DefInstance;
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                frmAltasMasivas.DefInstance.ShowDialog();
                //UPGRADE_WARNING: (2065) Form event CORCTEJE.Activated has a new behavior.
                CORCTEJE_Activated(this, new EventArgs());
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError("CORCTEJE (AltasMasivas)", e);
                return;
            }

        }

        private void cmdConsMasivas_Click(Object eventSender, EventArgs eventArgs)
        {
            frmConsultaMasivas tempLoadForm = frmConsultaMasivas.DefInstance;
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            frmConsultaMasivas.DefInstance.ShowDialog();
        }

        private void cmdReenvios_Click(Object eventSender, EventArgs eventArgs)
        {
            CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
            frmReenvEjecutivo.DefInstance.Show();
        }

        private void CORCTEJE_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;


            }
            //AIS-Bug 4474
            if (pszAccion == CORCONST.TAG_ALTA || pszAccion == CORCONST.TAG_BAJA)
            {
                ID_CEE_EMP_COB_SelectedIndexChanged(ID_CEE_EMP_COB, new EventArgs());
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            //this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            //this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            this.Cursor = Cursors.WaitCursor;
            //
            //  If bgblAdmin Then
            //    ID_CEE_ALT_PB.Enabled = True
            //    ID_CEE_BAJ_PB.Enabled = True
            //    ID_CEE_CAM_PB.Enabled = True
            //    ID_CEE_CON_PB.Enabled = True
            //    ID_CEE_CONS111_PB.Enabled = True
            //    ID_CEE_MAS_3PB.Enabled = True
            //  Else
            //    ID_CEE_ALT_PB.Enabled = OpcionesAcceso(4).bAltas
            //    ID_CEE_BAJ_PB.Enabled = OpcionesAcceso(4).bBajas
            //    ID_CEE_CAM_PB.Enabled = OpcionesAcceso(4).bCambios
            //    ID_CEE_CON_PB.Enabled = OpcionesAcceso(4).bConsultas
            //    ID_CEE_CONS111_PB.Enabled = True
            //    ID_CEE_MAS_3PB.Enabled = True
            //  End If
            mdlParametros.gperPerfil.prHabilitaAcciones(CORCTEJE.DefInstance);
            Carga_Grupos();

            this.Cursor = Cursors.Default;



        }

        private void Habilita_cambio()
        {

            int hEjeEmp = 0;
            int iError = 0;
            int iValor = 0;
            string pszejeStatus = String.Empty;

            //Formamos la Clave para el Bloque de Registro
            string pszClave = StringsHelper.Format(CORVAR.lgblEmpCve, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(CORVAR.igblEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo));

            CORVAR.pszgblsql = "select eje_num from " + CORBD.DB_SYB_EJE;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_num=" + CORVAR.igblEjeNum.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + CORVAR.lgblEmpCve.ToString();
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo=" + CORVAR.igblPref.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();

            CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
            if (CORPROC2.Existe_Dato() != 0)
            {
                //Asigna Propiedades a la forma de mantenimiento
                CORMNEJE.DefInstance.Tag = CORCONST.TAG_CAMBIO;
                //Muestra forma de mantenimiento
                //Descomentar en Producción
                //Private Sub tmrTimer_Timer()
                //    sspPanel(2).Caption = Format(Time, "hh:mm AMPM")
                //End Sub

                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORMNEJE.DefInstance.ShowDialog();
                //Libera el registrD    Form_Activate
            }
            else
            {
                this.Cursor = Cursors.Default;
                pszMsg = "El Tarjetahabiente seleccionado ha sido borrado por otro Usuario";
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                ID_CEE_EMP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEE_EMP_LB));
                if (ID_CEE_EMP_LB.Items.Count != 0)
                {
                    ID_CEE_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }

        }

        private void Habilita_consulta()
        {

            int hEjeEmp = 0;
            int iError = 0;
            int iValor = 0;
            string pszejeStatus = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.pszgblsql = "select eje_num from " + CORBD.DB_SYB_EJE;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_num=" + CORVAR.igblEjeNum.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + CORVAR.lgblEmpCve.ToString();
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo=" + CORVAR.igblPref.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
            if (CORPROC2.Existe_Dato() != 0)
            {

                //Asigna Propiedades a la forma de mantenimiento
                CORMNEJE.DefInstance.Tag = CORCONST.TAG_CONSULTA;
                //Posiciona botones de la forma de mantenimiento
                //CORMNEJE.ID_MEE_CER_PB.Left = (CORMNEJE.Width - (CORMNEJE.ID_MEE_ALT_PB.Width + 120 + CORMNEJE.ID_MEE_CER_PB.Width)) / 2
                //CORMNEJE.ID_MEE_IMP_PB.Left = CORMNEJE.ID_MEE_CER_PB.Left + 120 + CORMNEJE.ID_MEE_CER_PB.Width
                CORMNEJE.DefInstance.ID_MEE_ALT_PB.Visible = false;
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORMNEJE.DefInstance.ShowDialog();
                //UPGRADE_WARNING: (2065) Form event CORCTEJE.Activated has a new behavior.
                CORCTEJE_Activated(this, new EventArgs());
            }
            else
            {
                this.Cursor = Cursors.Default;
                pszMsg = "El Tarjetahabiente seleccionado ha sido borrado por otro Usuario";
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                ID_CEE_EMP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEE_EMP_LB));
                if (ID_CEE_EMP_LB.Items.Count != 0)
                {
                    ID_CEE_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }

        }

        private void ID_CEE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            if (!bfncAnalizaCtaPadre())
            {
                return;
            }


            if (!bfncAnalizaEjecutivo())
            {
                return;
            }

            if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                pszAccion = CORCONST.TAG_ALTA;
                CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, 1 + Formato.sMascara(Formato.iTipo.Empresa).Length).Trim();
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORCOFIR.DefInstance.ShowDialog();
                if (frmEjecutivo.DefInstance.flag)
                {
                    frmEjecutivo.DefInstance.txtEjecutivos[2].Select();
                }
                //UPGRADE_WARNING: (2065) Form event CORCTEJE.Activated has a new behavior.
                CORCTEJE_Activated(this, new EventArgs());
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen Empresas para dar de alta ejecutivos", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            this.Cursor = Cursors.Default;

        }


        private void ID_CEE_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iResp = 0;
            int iIndice = 0;
            int iElementos = 0;

            this.Cursor = Cursors.WaitCursor;
            //EISSA 03-10-2001. Cambio para formato y longitud de número de empresa y número de ejecutivo.
            string pszClave = StringsHelper.Format(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(ID_CEE_EMP_LB.Text.Substring(0, Math.Min(ID_CEE_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length)), Formato.sMascara(Formato.iTipo.Ejecutivo));

            //Verifica que existan elementos en el List Box
            if (ID_CEE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
            {

                //Verifica que se haya seleccionado un elemento
                if (ListBoxHelper.GetSelectedIndex(ID_CEE_EMP_LB) < CORVB.NULL_INTEGER)
                {
                    CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORSTR.STR_NO_SEL_ELEM;
                }
                else
                {
                    this.Cursor = Cursors.Default;

                    CORVAR.pszgblsql = "select eje_num from " + CORBD.DB_SYB_EJE;
                    //EISSA 05-10-2001. Cambio para traer longitud de empresa y ejecutivo
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_num=" + ID_CEE_EMP_LB.Text.Substring(0, Math.Min(ID_CEE_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num=" + ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length)).ToString();
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo=" + CORVAR.igblPref.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX *****
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                    if (CORPROC2.Existe_Dato() != 0)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        iResp = (int)Interaction.MsgBox("Dar de baja al Ejecutivo : " + ID_CEE_EMP_LB.Text, (MsgBoxStyle)(CORVB.MB_YESNO + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        this.Cursor = Cursors.WaitCursor;
                        if (iResp == CORVB.IDYES)
                        {
                            Realiza_baja();
                            if (ID_CEE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
                            {
                                ID_CEE_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        pszMsg = "El Tarjetahabiente seleccionado ha sido borrado por otro Usuario";
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        ID_CEE_EMP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEE_EMP_LB));
                        if (ID_CEE_EMP_LB.Items.Count != 0)
                        {
                            ID_CEE_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                        }
                    }
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //Envía mensaje de que no existen elementos
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CEE_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            pszAccion = CORCONST.TAG_CAMBIO;

            //variable global de cambios masivos en ejecutivos
            CORVAR.gblCamMasivos = false;
            try
            {
                if (ID_CEE_IRE_CKB.Value)
                {
                    this.Cursor = Cursors.Default;
                    CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    CORIREJE.DefInstance.ShowDialog();
                    if (frmEjecutivo.DefInstance.flag)
                        frmEjecutivo.DefInstance.Select();
                    if (CORVAR.bgblCerrar == (0))
                    {
                        if (CORVAR.bgblIrExiste != 0)
                        {
                            Habilita_cambio();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("No existe el elemento que se eligió", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        }
                    }

                }
                else
                {
                    if (ID_CEE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
                    {
                        //Verifica que se haya seleccionado un elemento
                        if (ListBoxHelper.GetSelectedIndex(ID_CEE_EMP_LB) >= CORVB.NULL_INTEGER)
                        {
                            //EISSA 05-10-2001. Cambio para longitud de empresa y de ejecutivo
                            CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                            CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, ID_CEE_EMP_COB.Text.IndexOf(' ') + 1).Trim();
                            CORVAR.igblEjeNum = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_LB.Text.Substring(0, Math.Min(ID_CEE_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length))));
                            Habilita_cambio();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //Envía mensaje acerca de que no se ha seleccionado elemento
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(CORSTR.STR_NO_SEL_ELEM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //Envía mensaje acerca de que no hay elementos a seleccionar
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CEE_CAM_PB_Click " + exc.Message, "Error Corcteje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CEE_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            pszAccion = CORCONST.TAG_CONSULTA;

            try
            {
                if (ID_CEE_IRE_CKB.Value)
                {
                    this.Cursor = Cursors.Default;
                    CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    CORIREJE.DefInstance.ShowDialog(this);
                    if (CORVAR.bgblCerrar == (0))
                    {
                        if (CORVAR.bgblIrExiste != 0)
                        {
                            Habilita_consulta();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("No existe el elemento que se eligió", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                        }
                    }
                }
                else
                {
                    //EISSA 05-10-2001. Cambio para traer longitud de empresa y ejecutivo.
                    CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                    //pszgblEmpDesc = Trim(Mid(ID_CEE_EMP_COB.Text, 8))
                    string tempRefParam = ID_CEE_EMP_COB.Text;
                    CORVAR.pszgblEmpDesc = Strings.Mid(ID_CEE_EMP_COB.Text, CRSGeneral.fncsObtenerElementoDeCadena(ref tempRefParam, 1, " ").Length + 1).Trim();
                    CORVAR.igblEjeNum = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_LB.Text.Substring(0, Math.Min(ID_CEE_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length))));
                    if (ID_CEE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
                    {
                        //Verifica que se haya seleccionado un elemento
                        if (ListBoxHelper.GetSelectedIndex(ID_CEE_EMP_LB) >= CORVB.NULL_INTEGER)
                        {
                            Habilita_consulta();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //Envía mensaje acerca de que no se ha seleccionado elemento
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(CORSTR.STR_NO_SEL_ELEM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //Envía mensaje acerca de que no hay elementos a seleccionar
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CEE_CON_PB_Click " + exc.Message, "Error Corcteje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_CEE_CONS111_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            pszAccion = CORCONST.TAG_CONSULTAS111;

            //Asigna Propiedades a la forma de consulta del s111
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            Cormn111.DefInstance.ShowDialog();
            //UPGRADE_WARNING: (2065) Form event CORCTEJE.Activated has a new behavior.
            CORCTEJE_Activated(this, new EventArgs());
            this.Cursor = Cursors.Default;

        }

        private void ID_CEE_EMP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            int iError = 0;
            int hEjeEmp = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;

            try
            {

                this.Cursor = Cursors.WaitCursor;

                ID_CEE_EMP_LB.Items.Clear();
                lEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));

                CORVAR.pszgblsql = "select eje_num, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nombre from ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + CORBD.DB_SYB_EJE;
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where emp_num = " + Conversion.Str(lEmpCve).Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num > 0";

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                lTotalEjecutivos = CORPROC2.Cuenta_Registros();
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (lTotalEjecutivos != CORVB.NULL_INTEGER)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        { //Or (iCont >= INT_MAX_EJECUTIVOS)
                            CORVAR.igblEjeCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            CORVAR.szgblEjeDesc.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                            ID_CEE_EMP_LB.Items.Add(StringsHelper.Format(CORVAR.igblEjeCve, Formato.sMascara(Formato.iTipo.Ejecutivo)) + CORCONST.SPC_TRES + CORVAR.szgblEjeDesc.Value.Trim());
                            iCont++;
                        };
                        lEjecutivosRestantes = lTotalEjecutivos - iCont;
                    }
                }
                CORVAR.pszgblsql = "select emp_con_eje from ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + CORBD.DB_SYB_EMP;
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where emp_num = " + Conversion.Str(lEmpCve).Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        CORVAR.igblEjeCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        ID_CEE_SIG_EJE.Text = StringsHelper.Format(CORVAR.igblEjeCve, Formato.sMascara(Formato.iTipo.Ejecutivo));
                    }
                }

                if (ID_CEE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_CEE_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }

                this.Cursor = Cursors.Default;

                Application.DoEvents();
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("ErrID_CEE_EMP_COB", e);
            }

        }

        private void ID_CEE_EMP_LB_DoubleClick(Object eventSender, EventArgs eventArgs)
        {

            ID_CEE_CON_PB_Click(ID_CEE_CON_PB, new EventArgs());

        }

        private void ID_CEE_GRU_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCorCve = 0;
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;

            ID_CEE_EMP_COB.Items.Clear();
            ID_CEE_EMP_LB.Items.Clear();

            int iCorNum = Convert.ToInt32(Conversion.Val(ID_CEE_GRU_COB.Text.Substring(0, Math.Min(ID_CEE_GRU_COB.Text.Length, 4))));

            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_num = " + Format$(iCorNum) + "and gpo_banco =" + Str(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where gpo_num = " + iCorNum.ToString() + "and eje_prefijo =" + Conversion.Str(CORVAR.igblPref) + "and gpo_banco =" + Conversion.Str(CORVAR.igblBanco);
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
            lTotalEmpresas = CORPROC2.Cuenta_Registros();
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (lTotalEmpresas != CORVB.NULL_INTEGER)
                {
                    if (lTotalEmpresas > INT_MAX_GRUPOS)
                    {
                        //ros 8/06/99       ID_CEM_MASE_3PB.Enabled = True
                    }

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    { //ros 8/06/99 And iCont < INT_MAX_EMPRESAS
                        lEmpCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        //EISSA 05-10-2001. Cambio para formatear el número de empresa.
                        ID_CEE_EMP_COB.Items.Add(StringsHelper.Format(lEmpCve, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
                        iCont++;
                    };
                    lEmpresasRestantes = lTotalEmpresas - iCont;
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }


            this.Cursor = Cursors.Default;

        }


        private void ID_CEE_MAS_3PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iError = 0;
            int hEjeEmp = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;
            ID_CEE_EMP_LB.Items.Clear(); //Limpia el List Box de Empresas
            //EISSA 05-10-2001. Cambio para traer longitud de empresa.
            lEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //Obtiene el Número de la Empresa

            if (lEjecutivosRestantes > CORVB.NULL_INTEGER)
            {
                //ros    iValor = qeFetchPrev(hEjecutivo)
                CORVAR.igblEjeCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                CORVAR.szgblEjeDesc.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                //EISSA 05-10-2001. Cambio para formatear número de ejecutivo.
                ID_CEE_EMP_LB.Items.Add(StringsHelper.Format(CORVAR.igblEjeCve, Formato.sMascara(Formato.iTipo.Ejecutivo)) + CORCONST.SPC_TRES + CORVAR.szgblEjeDesc.Value.Trim());
                iCont++;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS && iCont < INT_MAX_EJECUTIVOS)
                {
                    CORVAR.igblEjeCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    CORVAR.szgblEjeDesc.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    //EISSA 05-10-2001. Cambio para formatear número de ejecutivo.
                    ID_CEE_EMP_LB.Items.Add(StringsHelper.Format(CORVAR.igblEjeCve, Formato.sMascara(Formato.iTipo.Ejecutivo)) + CORCONST.SPC_TRES + CORVAR.szgblEjeDesc.Value.Trim());
                    iCont++;
                    if (lTotalEjecutivos == iCont + lTotalEjecutivos - lEjecutivosRestantes)
                    {
                        iCont = INT_MAX_EJECUTIVOS;
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    }
                };
                lEjecutivosRestantes -= iCont;

            }
            else
            {
                //Realiza fin de Query
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                ID_CEE_EMP_COB_SelectedIndexChanged(ID_CEE_EMP_COB, new EventArgs());
            }

            //Posiciona en el Primer Elemento del ListBox de
            //Ejecutivos De Empresas
            if (ID_CEE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }
            this.Cursor = Cursors.Default;

            Application.DoEvents();

        }




        private void ID_CEE_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;

            this.Close();

        }

        private void ID_CEM_MASE_3PB_ClickEvent(Object eventSender, EventArgs eventArgs)
        {

            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCorCve = 0;
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;

            int iCorNum = Convert.ToInt32(Conversion.Val(ID_CEE_GRU_COB.Text.Substring(0, Math.Min(ID_CEE_GRU_COB.Text.Length, 4))));
            this.Cursor = Cursors.Default;

            if (lEmpresasRestantes > CORVB.NULL_INTEGER)
            {
                ID_CEE_EMP_COB.Items.Clear();
                ID_CEE_EMP_LB.Items.Clear();
                iCont = CORVB.NULL_INTEGER;
                //ros    iValor = qeFetchPrev(hEjeEmpresa)
                this.Cursor = Cursors.WaitCursor;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS && iCont < INT_MAX_EMPRESAS)
                {
                    lEmpCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    //EISSA 03-10-2001. Cambio para formatear número de empresa.
                    ID_CEE_EMP_COB.Items.Add(StringsHelper.Format(lEmpCve, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
                    iCont++;
                    if (lTotalEmpresas == iCont + lTotalEmpresas - lEmpresasRestantes)
                    {
                        iCont = INT_MAX_EMPRESAS;
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    }
                };
                lEmpresasRestantes -= iCont;
                this.Cursor = Cursors.Default;
            }
            else
            {
                //Realiza fin de Query
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                ID_CEE_GRU_COB_SelectedIndexChanged(ID_CEE_GRU_COB, new EventArgs());
            }
            //Posiciona en el Primer Elemento del ComboBox de Grupos
            if (ID_CEE_EMP_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_EMP_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

        }

        private void ID_CEM_MASG_3PB_ClickEvent(Object eventSender, EventArgs eventArgs)
        {

            int iTempErr = 0;
            int iNumGrupo = 0;
            string pszNomGrupo = String.Empty;
            int iGrupos = 0;
            int iError = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string szEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;

            if (lGruposRestantes > CORVB.NULL_INTEGER)
            {
                //Limpia los ListBox
                ID_CEE_GRU_COB.Items.Clear();
                ID_CEE_EMP_LB.Items.Clear();
                ID_CEE_EMP_COB.Items.Clear();
                iCont = CORVB.NULL_INTEGER;
                //ros    iTempErr = qeFetchPrev(hEjeGpo)

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS && iCont < INT_MAX_GRUPOS)
                {
                    iCorCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszCorDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_CEE_GRU_COB.Items.Add(StringsHelper.Format(iCorCve, "0000") + CORCONST.SPC_TRES + pszCorDesc.Trim());
                    iCont++;
                    if (lTotalGrupos == iCont + lTotalGrupos - lGruposRestantes)
                    {
                        iCont = INT_MAX_GRUPOS;
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    }
                };
                lGruposRestantes -= iCont;
                this.Cursor = Cursors.Default;
                //Realiza fin de Query
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Carga_Grupos();
            }

            //Posiciona en el Primer Elemento del ComboBox de Grupos
            if (ID_CEE_GRU_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEE_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

        }

        private void Realiza_baja()
        {

            int hEjeEmp = 0;
            int iError = 0;
            int reg_mod = 0;

            this.Cursor = Cursors.WaitCursor;

            //EISSA 05-10-2001. Cambio para traer longitud de empresa y de ejecutivo
            int iEjeCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_LB.Text.Substring(0, Math.Min(ID_CEE_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length))));
            lEmpCve = Convert.ToInt32(Conversion.Val(ID_CEE_EMP_COB.Text.Substring(0, Math.Min(ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //Obtiene el Número de la Empresa
            //Obtiene los campos de la tabla de Divisiones Regionales
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "baja_eje_emp " + Str(igblBanco) + "," + Str(lEmpCve) + "," + Str(iEjeCve) + ",''"
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "baja_eje_emp " + Conversion.Str(CORVAR.igblPref) + "," + Conversion.Str(CORVAR.igblBanco) + "," + Conversion.Str(lEmpCve) + "," + Conversion.Str(iEjeCve) + ",''";
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Modifica_Registro() != 0)
            {
                //Borra elemento del ListBox
                ID_CEE_EMP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEE_EMP_LB));
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                //actualiza el limite de credito de la empresa

                //    pszgblsql = "UPDATE MTCEMP01 set emp_acum_cred = (select sum(eje_limcred) from MTCEJE01"
                // Modif. 18/Jun/2007 Calc Lim Real
                CORVAR.pszgblsql = "update MTCEMP01 ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_acum_cred = ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = " + Conversion.Str(CORVAR.igblPref);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + Conversion.Str(lEmpCve);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = " + Conversion.Str(CORVAR.igblPref);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + Conversion.Str(lEmpCve);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) ";
                //    pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) "


                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //   pszgblsql = pszgblsql + " where gpo_banco = " + Str(igblBanco) + " and emp_num = " + Str(lEmpCve) + ")"
                //   pszgblsql = pszgblsql + " where gpo_banco = " + Str(igblBanco) + " and emp_num = " + Str(lEmpCve)
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX *****

                //    pszgblsql = pszgblsql + " where eje_prefijo = " + str(igblPref) + " and gpo_banco = " + str(igblBanco) + " and emp_num = " + str(lEmpCve) + ")"

                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + Conversion.Str(CORVAR.igblPref) + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco) + " and emp_num = " + Conversion.Str(lEmpCve);
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Se realizó con éxito la operación.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            else
            {
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No se pudo realizar la operación. ", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

        }

        public bool bfncAnalizaEjecutivo()
        {

            bool result = false;
            int llConsecutivo = 0;
            string slMensaje = String.Empty;
            int llRetorma = 0;

            try
            {

                Formato.pszgblSql3 = "select";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " max(eje_num) + 1";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " From MTCEJE01 ";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " Where MTCEJE01.eje_prefijo = " + CORVAR.igblPref.ToString();
                Formato.pszgblSql3 = Formato.pszgblSql3 + " and MTCEJE01.gpo_banco  = " + CORVAR.igblBanco.ToString();
                Formato.pszgblSql3 = Formato.pszgblSql3 + " and MTCEJE01.emp_num = " + lEmpCve.ToString();

                if (Formato.ifncObtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(Formato.hgblConexion3) != VBSQL.NOMOREROWS)
                    {
                        llConsecutivo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(Formato.hgblConexion3, 1)));

                        if (llConsecutivo == Formato.lfncTop(Formato.igLongitudEjecutivo))
                        {
                            slMensaje = "Este es el último ejecutivo que podrá dar de alta en esta empresa ";
                            slMensaje = slMensaje + "\r\n" + "Para dar de alta nuevos ejecutivos la siguiente ocasión será necesario cambiar de empresa o crear una nueva.";
                            MessageBox.Show(slMensaje, "Alta de Tarjetahabientes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            result = true;
                        }
                        else if (llConsecutivo > Formato.lfncTop(Formato.igLongitudEjecutivo))
                        {
                            slMensaje = "No se puede crear el ejecutivo siguiente, debido a que se excede el límite de ejecutivos permitidos para esta empresa.";
                            slMensaje = slMensaje + "\r\n" + "Para generar más ejecutivos es necesario cambiar de empresa o crear una nueva.";
                            MessageBox.Show(slMensaje, "Alta de Tarjetahabientes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    };
                }
                else
                {
                    llConsecutivo = 1;
                    result = true;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(Formato.hgblConexion3);
            }
            catch (Exception e)
            {


                CRSGeneral.prObtenError("AnalizaEjecutivo", e);
            }

            return result;
        }


        public bool bfncAnalizaCtaPadre()
        {

            bool result = false;
            string strStatus = String.Empty;
            string slMensaje = String.Empty;
            int llRetorma = 0;

            try
            {

                Formato.pszgblSql3 = "select";
                Formato.pszgblSql3 = Formato.pszgblSql3 + "  ths_situacion_cta";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " From MTCTHS01 ";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " Where MTCTHS01.eje_prefijo = " + CORVAR.igblPref.ToString();
                Formato.pszgblSql3 = Formato.pszgblSql3 + " and MTCTHS01.gpo_banco  = " + CORVAR.igblBanco.ToString();
                Formato.pszgblSql3 = Formato.pszgblSql3 + " and MTCTHS01.emp_num = " + lEmpCve.ToString();
                Formato.pszgblSql3 = Formato.pszgblSql3 + " and MTCTHS01.eje_num = 0";

                if (Formato.ifncObtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(Formato.hgblConexion3) != VBSQL.NOMOREROWS)
                    {
                        int tempRefParam = 1;
                        string tempRefParam2 = " ";
                        strStatus = CRSGeneral.sfncJustificar(VBSQL.SqlData(Formato.hgblConexion3, 1).Trim(), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam, ref tempRefParam2);

                        switch (strStatus)
                        {
                            case "E":
                                slMensaje = "Cuenta Padre Cancelada con Saldo ";
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                Interaction.MsgBox(slMensaje, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                this.Cursor = Cursors.Default;
                                result = false;
                                break;
                            case "C":
                                slMensaje = "Cuenta Padre Cancelada sin Saldo ";
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                Interaction.MsgBox(slMensaje, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                this.Cursor = Cursors.Default;
                                result = false;
                                break;
                            default:
                                result = true;
                                break;
                        }
                    };
                }
                else
                {
                    //slMensaje = "Cuenta Padre no encontrada "
                    //MsgBox slMensaje, MB_ICONEXCLAMATION + MB_OK, STR_APP_TIT
                    this.Cursor = Cursors.Default;
                    result = true;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(Formato.hgblConexion3);
            }
            catch (Exception e)
            {


                CRSGeneral.prObtenError("AnalizaCtaPadre", e);
            }

            return result;
        }
        private void CORCTEJE_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}