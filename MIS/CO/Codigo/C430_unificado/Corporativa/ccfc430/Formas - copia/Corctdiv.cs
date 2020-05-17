using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORCTDIV
        : System.Windows.Forms.Form
    {

        //**********************************************************
        //*
        //*    Descripción : Módulo de Catálogo de Divisiones
        //*                  Regionales de Banamex
        //*
        //*    Fecha de Inicio : 18/04/94
        //*
        //*    Responsable: Abraham Ramírez Basurto
        //*
        //**********************************************************

        //Constantes de Captions y mensajes
        const string STR_BAJA_DIV_REGION = "Bajas de Divisiones Regionales";
        const string CAPTION_ALTA_DIV = "Altas de Divisiones Regionales";
        const string CAPTION_CONS_DIV = "Consultas de Divisiones Regionales ";
        const string STR_INT_CVE_DIV = "Introduzca clave o descripción de División";
        const string STR_ALT_DIV = "Altas de Divisiones Regionales";
        const string CAPTION_CAM_DIV = "Cambios de Divisiones Regionales";

        //Constantes que se asginan a los TAGS
        const string TAG_CONSULTA = "consulta";
        const string TAG_ALTA = "alta";
        const string TAG_CAMBIO = "cambio";

        const string DIVISION = "la División ";
        const string MODIF_REGISTRO = "Se actualizó ";

        //Handle de Conexion
        int hConexion = 0;
        string pszMsg = String.Empty;
        string pszSQL = String.Empty;

        private void CORCTDIV_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                int iError = 0;
                int hDivision = 0;
                int iValor = 0;

                //Inhabilita forma para no poder oprimir salir y descargarla
                this.Enabled = false;

                //Limpia el List box
                ID_DIV_GRP_LB.Items.Clear();

                this.Cursor = Cursors.WaitCursor;

                //Obtiene los Campos de la tabla de divisiones
                CORVAR.pszgblsql = "select * from " + CORBD.DB_SYB_DIV;

                if (CORPROC2.Obtiene_Registros() != 0)
                {


                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        CORVAR.igblDivCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        CORVAR.szgblDivDesc.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_DIV_GRP_LB.Items.Add(StringsHelper.Format(CORVAR.igblDivCve, "000") + CORCONST.SPC_TRES + CORVAR.szgblDivDesc.Value.Trim());
                    };
                }

                //Realiza fin de Query
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                //Posiciona en el Primer Elemento del ListBox
                if (ID_DIV_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_DIV_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
                Application.DoEvents();


                //habilita forma para  poder oprimir salir y descargarla
                this.Enabled = true;

                this.Cursor = Cursors.Default;

            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            //Posiciona forma
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            this.Refresh();

            this.Cursor = Cursors.WaitCursor;


            if (CORVAR.bgblAdmin != 0)
            {
                ID_DIV_ALT_PB.Enabled = true;
                ID_DIV_BAJ_PB.Enabled = true;
                ID_DIV_CAM_PB.Enabled = true;
                ID_DIV_CON_PB.Enabled = true;
            }
            else
            {
                ID_DIV_ALT_PB.Enabled = CORVAR.OpcionesAcceso[6].bAltas;
                ID_DIV_BAJ_PB.Enabled = CORVAR.OpcionesAcceso[6].bBajas;
                ID_DIV_CAM_PB.Enabled = CORVAR.OpcionesAcceso[6].bCambios;
                ID_DIV_CON_PB.Enabled = CORVAR.OpcionesAcceso[6].bConsultas;
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_DIV_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //Asigna propiedades a la forma de mantenimiento
            CORMNDIV.DefInstance.Tag = TAG_ALTA;
            CORMNDIV.DefInstance.Text = CAPTION_ALTA_DIV;

            //Muestra forma de Mantenimiento
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORMNDIV.DefInstance.ShowDialog();

            //Refresca la forma
            //UPGRADE_WARNING: (2065) Form event CORCTDIV.Activated has a new behavior.
            CORCTDIV_Activated(this, new EventArgs());

        }

        private void ID_DIV_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iRespuesta = 0;
            int iIndice = 0;


            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Verifica que existan elementos en el List Box
                if (ID_DIV_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                {

                    //Verifica que se haya seleccionado un elemento
                    if (ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB) < CORVB.NULL_INTEGER)
                    {
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORSTR.STR_NO_SEL_ELEM;
                    }
                    else
                    {

                        CORVAR.igblDivCve = Convert.ToInt32(Conversion.Val(ID_DIV_GRP_LB.Text.Substring(0, Math.Min(ID_DIV_GRP_LB.Text.Length, 3))));
                        CORVAR.pszgblDivDesc = Strings.Mid(ID_DIV_GRP_LB.Text, 7).Trim();

                        CORVAR.pszgblsql = "select div_num from " + CORBD.DB_SYB_DIV + " where div_num=" + CORVAR.igblDivCve.ToString();

                        if (CORPROC2.Existe_Dato() != 0)
                        {

                            //Confirma si realmente se desea dar de baja la división seleccionada
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            iRespuesta = (int)Interaction.MsgBox(CORSTR.STR_CONF_BAJA + "\r" + DIVISION + CORVAR.pszgblDivDesc + Strings.Chr(63).ToString(), (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), STR_BAJA_DIV_REGION);
                            if (iRespuesta == CORVB.IDYES)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                iIndice = ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB);
                                Realiza_baja();
                                if (ID_DIV_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                                {
                                    if (iIndice - 1 >= CORVB.NULL_INTEGER)
                                    {
                                        ID_DIV_GRP_LB.SelectedIndex = iIndice - 1;
                                    }
                                    else
                                    {
                                        ID_DIV_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                                    }
                                }
                            }

                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "La división seleccionada ha sido borrada por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_DIV_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB));
                            if (ID_DIV_GRP_LB.Items.Count != 0)
                            {
                                ID_DIV_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
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
                    Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_DIV_BAJ_PB_Click " + exc.Message, "Error Corctdiv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_DIV_BAJ_PB_Leave(Object eventSender, EventArgs eventArgs)
        {

            //Borra mensaje del Status Bar
            if (ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB) < CORVB.NULL_INTEGER)
            {
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = " ";
                Application.DoEvents();
            }

        }

        private void ID_DIV_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                //Verifica que existan elementos enel List Box
                if (ID_DIV_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                {

                    //Verifica que se haya seleccionado un elemento
                    if (ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB) >= CORVB.NULL_INTEGER)
                    {

                        CORVAR.igblDivCve = Convert.ToInt32(Conversion.Val(ID_DIV_GRP_LB.Text.Substring(0, Math.Min(ID_DIV_GRP_LB.Text.Length, 3))));
                        CORVAR.pszgblDivDesc = Strings.Mid(ID_DIV_GRP_LB.Text, 7).Trim();

                        CORVAR.pszgblsql = "select div_num from " + CORBD.DB_SYB_DIV + " where div_num=" + CORVAR.igblDivCve.ToString();

                        if (CORPROC2.Existe_Dato() != 0)
                        {

                            //Asigna Propiedades a la forma de mantenimiento
                            CORMNDIV.DefInstance.Tag = TAG_CAMBIO;
                            CORMNDIV.DefInstance.Text = CAPTION_CAM_DIV;
                            CORMNDIV.DefInstance.ID_DIV_CVE_EB.Enabled = false;

                            //Muestra forma de mantenimiento
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            CORMNDIV.DefInstance.ShowDialog();

                            //Refresca la forma
                            if (CORVAR.bgblDivActiva == (0))
                            {
                                //UPGRADE_WARNING: (2065) Form event CORCTDIV.Activated has a new behavior.
                                CORCTDIV_Activated(this, new EventArgs());
                            }

                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "La división seleccionada ha sido borrada por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_DIV_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB));
                            if (ID_DIV_GRP_LB.Items.Count != 0)
                            {
                                ID_DIV_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //Envía mensaje acerca de que no se ha seleccionado elemento
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(CORSTR.STR_NO_SEL_ELEM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), STR_BAJA_DIV_REGION);
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //Envía mensaje acerca de que no hay elementos a seleccionar
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), STR_BAJA_DIV_REGION);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_DIV_CAM_PB_Click " + exc.Message, "Error Corctdiv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                this.Cursor = Cursors.Default;
            }
        }

        private void ID_DIV_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //Cierra catálogo de divisiones regionales
            this.Close();

        }

        private void ID_DIV_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            try
            {
                //Verifica que existan elementos enel List Box
                if (ID_DIV_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
                {

                    //Verifica que se haya seleccionado un elemento
                    if (ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB) >= CORVB.NULL_INTEGER)
                    {

                        CORVAR.igblDivCve = StringsHelper.IntValue(ID_DIV_GRP_LB.Text.Substring(0, Math.Min(ID_DIV_GRP_LB.Text.Length, 3)));
                        CORVAR.pszgblDivDesc = Strings.Mid(ID_DIV_GRP_LB.Text, 7).Trim();

                        CORVAR.pszgblsql = "select div_num from " + CORBD.DB_SYB_DIV + " where div_num=" + CORVAR.igblDivCve.ToString();

                        if (CORPROC2.Existe_Dato() != 0)
                        {

                            //Posiciona botones de la forma de mantenimiento
                            CORMNDIV.DefInstance.ID_DIV_CAN_PB.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMNDIV.DefInstance.Width)) - (((float)VB6.PixelsToTwipsX(CORMNDIV.DefInstance.ID_DIV_ACE_PB.Width)) + 120 + ((float)VB6.PixelsToTwipsX(CORMNDIV.DefInstance.ID_DIV_CAN_PB.Width)))) / 2);
                            CORMNDIV.DefInstance.ID_DIV_IMP_PB.Left = (int)VB6.TwipsToPixelsX(((float)VB6.PixelsToTwipsX(CORMNDIV.DefInstance.ID_DIV_CAN_PB.Left)) + ((float)VB6.PixelsToTwipsX(CORMNDIV.DefInstance.ID_DIV_CAN_PB.Width)) + 120);
                            CORMNDIV.DefInstance.ID_DIV_ACE_PB.Visible = false;

                            //Asigna Propiedades a la forma de mantenimiento
                            CORMNDIV.DefInstance.Tag = TAG_CONSULTA;
                            CORMNDIV.DefInstance.Text = CAPTION_CONS_DIV;
                            CORMNDIV.DefInstance.ID_DIV_CVE_EB.Enabled = false;
                            CORMNDIV.DefInstance.ID_DIV_DIV_EB.Enabled = false;

                            //Muestra forma de mantenimiento
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            CORMNDIV.DefInstance.ShowDialog();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "La división seleccionada ha sido borrada por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_DIV_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB));
                            if (ID_DIV_GRP_LB.Items.Count != 0)
                            {
                                ID_DIV_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //Envía mensaje acerca de que no se ha seleccionado elemento
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(CORSTR.STR_NO_SEL_ELEM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), STR_BAJA_DIV_REGION);
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //Envía mensaje acerca de que no hay elementos a seleccionar
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORSTR.STR_NO_EXIS_ELE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), STR_BAJA_DIV_REGION);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_DIV_CON_PB_Click " + exc.Message, "Error Corctdiv", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_DIV_GRP_LB_DoubleClick(Object eventSender, EventArgs eventArgs)
        {

            ID_DIV_CON_PB_Click(ID_DIV_CON_PB, new EventArgs());

        }

        private void ID_DIV_GRP_LB_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;

            //Verifica si hay elementos seleccionados
            if (ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB) >= CORVB.NULL_INTEGER)
            {
                //Verifica si se ha oprimido la tecla de suprimir
                if (KeyCode == CORVB.KEY_DELETE)
                {
                    //Da de baja el elemento seleccionado
                    ID_DIV_BAJ_PB_Click(ID_DIV_BAJ_PB, new EventArgs());
                }
            }

        }

        private void ID_DIV_PPL_PNL_MouseMoveEvent(Object eventSender, AxThreed.ISSPNCtrlEvents_MouseMoveEvent eventArgs)
        {

            //Limpia el panel del Status Bar
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = " ";

        }

        private void Realiza_baja()
        {

            int hDivision = 0;
            int hFinDivision = 0;
            int iError = 0;
            string pszMsg = String.Empty;

            int iRegMod = 1;

            this.Cursor = Cursors.WaitCursor;

            //Obtiene los campos de la tabla de Divisiones Regionales
            CORVAR.pszgblsql = "DELETE FROM " + CORBD.DB_SYB_DIV + " WHERE div_num = " + CORVAR.igblDivCve.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and (select count(*) from MTCEJX01" + " where div_num =" + Conversion.Str(CORVAR.igblDivCve) + ") = 0";

            if (CORPROC2.Modifica_Registro() != 0)
            {
                //Borra elemento del ListBox
                ID_DIV_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_DIV_GRP_LB));
            }
            else
            {
                this.Cursor = Cursors.Default;
                pszMsg = "No se puede dar de baja." + Strings.Chr(CORVB.KEY_RETURN).ToString() + "Causas: " + Strings.Chr(CORVB.KEY_RETURN).ToString();
                pszMsg = pszMsg + "1. Existen ejecutivos Banamex asignados a esta División." + Strings.Chr(CORVB.KEY_RETURN).ToString();
                pszMsg = pszMsg + "2. Este registro pudo haber sido borrado por otro usuario. Intente cargando el catálogo otra vez.";
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


            this.Cursor = Cursors.Default;

        }
        private void CORCTDIV_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}