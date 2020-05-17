using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORCTREG
        : System.Windows.Forms.Form
    {

        //**********************************************************
        //*
        //*    Descripción : Módulo de Catálogo de Regiones
        //*                  de Banamex
        //*
        //*    Fecha de Inicio : 18/04/94
        //*
        //*    Responsable: Abraham Ramírez Basurto
        //*
        //**********************************************************

        //Constantes de Captions y mensajes
        const string STR_INT_CVE_REG = "Introduzca clave o descripción de Región";

        //Constantes que se asignan a los TAGS
        const string TAG_CONSULTA = "consulta";
        const string TAG_ALTA = "alta";
        const string TAG_CAMBIO = "cambio";

        const string REGION_Renamed = "la Región ";
        const string MODIF_REGISTRO = "Se actualizó ";

        //Dim pszgblRegDesc As String
        int hConexion = 0;
        string pszMsg = String.Empty;
        string pszSQL = String.Empty;

        private void CORCTREG_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                int iError = 0;
                int hRegion = 0;
                int iValor = 0;

                this.Cursor = Cursors.WaitCursor;

                ID_REG_GRP_LB.Items.Clear();

                //Obtiene los Campos de la tabla
                CORVAR.pszgblsql = "select * from " + CORBD.DB_SYB_REG;

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        CORVAR.igblRegCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        CORVAR.pszgblRegDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_REG_GRP_LB.Items.Add(StringsHelper.Format(CORVAR.igblRegCve, "000") + CORCONST.SPC_TRES + CORVAR.pszgblRegDesc.Trim());
                    };
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                //Posiciona en el Primer Elemento del ListBox
                if (ID_REG_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_REG_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
                Application.DoEvents();

                this.Cursor = Cursors.Default;

            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            if (CORVAR.bgblAdmin != 0)
            {
                ID_REG_ALT_PB.Enabled = true;
                ID_REG_BAJ_PB.Enabled = true;
                ID_REG_CAM_PB.Enabled = true;
                ID_REG_CON_PB.Enabled = true;
            }
            else
            {
                ID_REG_ALT_PB.Enabled = CORVAR.OpcionesAcceso[7].bAltas;
                ID_REG_BAJ_PB.Enabled = CORVAR.OpcionesAcceso[7].bBajas;
                ID_REG_CAM_PB.Enabled = CORVAR.OpcionesAcceso[7].bCambios;
                ID_REG_CON_PB.Enabled = CORVAR.OpcionesAcceso[7].bConsultas;
            }
        }

        private void ID_REG_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //Asigna propiedades a la forma de mantenimiento
            CORMNREG.DefInstance.Tag = TAG_ALTA;

            //Muestra forma de Mantenimiento
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORMNREG.DefInstance.ShowDialog();

            //Refresca la forma
            //UPGRADE_WARNING: (2065) Form event CORCTREG.Activated has a new behavior.
            CORCTREG_Activated(this, new EventArgs());


        }

        private void ID_REG_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iRespuesta = 0;
            int iIndice = 0;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Verifica que existan elementos en el List Box
                if (ID_REG_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    //Verifica que se han seleccionado elementos
                    if (ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB) < CORVB.NULL_INTEGER)
                    {
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORSTR.STR_NO_SEL_ELEM;
                    }
                    else
                    {
                        CORVAR.igblRegCve = Convert.ToInt32(Conversion.Val(ID_REG_GRP_LB.Text.Substring(0, Math.Min(ID_REG_GRP_LB.Text.Length, 3))));
                        CORVAR.pszgblRegDesc = Strings.Mid(ID_REG_GRP_LB.Text, 7).Trim();

                        CORVAR.pszgblsql = "select reg_num from " + CORBD.DB_SYB_REG + " where reg_num=" + CORVAR.igblRegCve.ToString();

                        if (CORPROC2.Existe_Dato() != 0)
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            iRespuesta = (int)Interaction.MsgBox(CORSTR.STR_CONF_BAJA + "\r" + REGION_Renamed + CORVAR.pszgblRegDesc + Strings.Chr(63).ToString(), (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                            if (iRespuesta == CORVB.IDYES)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                iIndice = ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB);
                                Realiza_baja();
                                if (ID_REG_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                                {
                                    if (iIndice - 1 >= CORVB.NULL_INTEGER)
                                    {
                                        ID_REG_GRP_LB.SelectedIndex = iIndice - 1;
                                    }
                                    else
                                    {
                                        ID_REG_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "La Región seleccionada ha sido borrada por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_REG_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB));
                            if (ID_REG_GRP_LB.Items.Count != 0)
                            {
                                ID_REG_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_REG_BAJ_PB_Click " + exc.Message, "Error Corctreg", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_REG_BAJ_PB_Leave(Object eventSender, EventArgs eventArgs)
        {

            if (ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB) < CORVB.NULL_INTEGER)
            {
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = " ";
                Application.DoEvents();
            }

        }

        private void ID_REG_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iRespuesta = 0;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Verifica que existan elementos enel List Box
                if (ID_REG_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                {

                    //Verifica que se haya seleccionado un elemento
                    if (ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB) >= CORVB.NULL_INTEGER)
                    {

                        CORVAR.igblRegCve = Convert.ToInt32(Conversion.Val(ID_REG_GRP_LB.Text.Substring(0, Math.Min(ID_REG_GRP_LB.Text.Length, 3))));
                        CORVAR.pszgblRegDesc = Strings.Mid(ID_REG_GRP_LB.Text, 7).Trim();

                        CORVAR.pszgblsql = "select reg_num from " + CORBD.DB_SYB_REG + " where reg_num=" + CORVAR.igblRegCve.ToString();

                        if (CORPROC2.Existe_Dato() != 0)
                        {
                            //Asigna Propiedades a la forma de mantenimiento
                            CORMNREG.DefInstance.Tag = TAG_CAMBIO;
                            CORMNREG.DefInstance.ID_REG_CVE_EB.Enabled = false;

                            //Muestra forma de mantenimiento
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            CORMNREG.DefInstance.ShowDialog();

                            //Refresca la forma
                            //UPGRADE_WARNING: (2065) Form event CORCTREG.Activated has a new behavior.
                            CORCTREG_Activated(this, new EventArgs());
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "La Región seleccionada ha sido borrada por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_REG_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB));
                            if (ID_REG_GRP_LB.Items.Count != 0)
                            {
                                ID_REG_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(CORSTR.STR_NO_SEL_ELEM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_REG_CAM_PB_Click " + exc.Message, "Error Corctreg", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_REG_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }

        private void ID_REG_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Verifica que existan elementos enel List Box
                if (ID_REG_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                {

                    //Verifica que se haya seleccionado un elemento
                    if (ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB) >= CORVB.NULL_INTEGER)
                    {

                        CORVAR.igblRegCve = Convert.ToInt32(Conversion.Val(ID_REG_GRP_LB.Text.Substring(0, Math.Min(ID_REG_GRP_LB.Text.Length, 3))));
                        CORVAR.pszgblRegDesc = Strings.Mid(ID_REG_GRP_LB.Text, 7).Trim();

                        CORVAR.pszgblsql = "select reg_num from " + CORBD.DB_SYB_REG + " where reg_num=" + CORVAR.igblRegCve.ToString();

                        if (CORPROC2.Existe_Dato() != 0)
                        {

                            //Posiciona botones de la forma de mantenimiento
                            CORMNREG.DefInstance.ID_REG_CAN_PB.Left = (int)VB6.ToPixelsUserX((((float)VB6.PixelsToTwipsX(CORMNREG.DefInstance.Width)) - (((float)VB6.FromPixelsUserWidth(CORMNREG.DefInstance.ID_REG_ACE_PB.Width, 3834.57, 335)) + 120 + ((float)VB6.FromPixelsUserWidth(CORMNREG.DefInstance.ID_REG_CAN_PB.Width, 3834.57, 335)))) / 2, 0, 3834.57, 335);
                            CORMNREG.DefInstance.ID_REG_IMP_PB.Left = (int)VB6.ToPixelsUserX(((float)VB6.FromPixelsUserX(CORMNREG.DefInstance.ID_REG_CAN_PB.Left, 0, 3834.57, 335)) + ((float)VB6.FromPixelsUserWidth(CORMNREG.DefInstance.ID_REG_CAN_PB.Width, 3834.57, 335)) + 120, 0, 3834.57, 335);
                            CORMNREG.DefInstance.ID_REG_ACE_PB.Visible = false;

                            //Asigna Propiedades a la forma de mantenimiento
                            CORMNREG.DefInstance.Tag = TAG_CONSULTA;
                            CORMNREG.DefInstance.ID_REG_CVE_EB.Enabled = false;
                            CORMNREG.DefInstance.ID_REG_REG_EB.Enabled = false;

                            //Muestra forma de mantenimiento
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            CORMNREG.DefInstance.ShowDialog();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "La Región seleccionada ha sido borrada por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_REG_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB));
                            if (ID_REG_GRP_LB.Items.Count != 0)
                            {
                                ID_REG_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(CORSTR.STR_NO_SEL_ELEM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_REG_CON_PB_Click " + exc.Message, "Error Corctreg", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_REG_GRP_LB_DoubleClick(Object eventSender, EventArgs eventArgs)
        {

            ID_REG_CON_PB_Click(ID_REG_CON_PB, new EventArgs());

        }

        private void ID_REG_GRP_LB_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;

            //Verifica si se ha oprimido el botón de delete, si es
            //así se da de baja el elemento
            if (ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB) >= CORVB.NULL_INTEGER)
            {
                if (KeyCode == CORVB.KEY_DELETE)
                {
                    ID_REG_BAJ_PB_Click(ID_REG_BAJ_PB, new EventArgs());
                }
            }

        }

        private void ID_REG_PPL_PNL_MouseMoveEvent(Object eventSender, AxThreed.ISSPNCtrlEvents_MouseMoveEvent eventArgs)
        {

            //Limpia la barra de Estatus
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = " ";

        }

        private void Realiza_baja()
        {

            int hRegion = 0;
            int iError = 0;

            int iRegMod = 0;

            this.Cursor = Cursors.WaitCursor;


            //Obtiene los campos de la tabla de Regiones
            this.Cursor = Cursors.WaitCursor;

            CORVAR.pszgblsql = "delete from " + CORBD.DB_SYB_REG + " where reg_num =" + Conversion.Str(CORVAR.igblRegCve);
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //    pszgblsql = pszgblsql & " and (select count(*) from MTCEJE01" + " where reg_num =" + Str(igblRegCve) + " And gpo_banco = " + Format$(igblBanco) + ") = 0"
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and (select count(*) from MTCEJE01" + " where reg_num =" + Conversion.Str(CORVAR.igblRegCve) + " and eje_prefijo= " + CORVAR.igblPref.ToString() + " And gpo_banco = " + CORVAR.igblBanco.ToString() + ") = 0";
            //***** FIN DE CODIGO NUEVO  FSWBMX *****
            if (CORPROC2.Modifica_Registro() != 0)
            {
                iRegMod = 1;
                ID_REG_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_REG_GRP_LB)); //Borra elemento del ListBox
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (iRegMod == CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                pszMsg = "No se puede dar de baja." + Strings.Chr(CORVB.KEY_RETURN).ToString() + "Causas: " + Strings.Chr(CORVB.KEY_RETURN).ToString();
                pszMsg = pszMsg + "1. Existen ejecutivos Banamex asignados a esta Región." + Strings.Chr(CORVB.KEY_RETURN).ToString();
                pszMsg = pszMsg + "2. Pudo haber sido borrado por otro usuario. Intente cargando el catálogo otra vez.";
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }



            this.Cursor = Cursors.Default;

        }
        private void CORCTREG_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void CORCTREG_Load(object sender, EventArgs e)
        {

        }
    }
}