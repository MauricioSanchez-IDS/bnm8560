using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORCTEJB
        : System.Windows.Forms.Form
    {

        //**********************************************************
        //*
        //*    Descripción : Módulo de Catálogo de Ejecutivos Banamex
        //*
        //*    Fecha de Inicio : 18/04/94
        //*
        //*    Responsable: Abraham Ramírez Basurto
        //*
        //**********************************************************

        //Constantes de Captions y mensajes
        const string STR_INT_CVE_EJX = "Introduzca clave o descripción de Ejecutivo Banamex";
        const string DIVISION = "la División ";
        const string EJEBAN = "el Ejecutivo Banamex ";
        const string MODIF_REGISTRO = "Se actualizó ";
        const string NO_BAJA_DIV = "No se puede dar de baja, existen ejecutivos Banamex asignados a esta División";
        const int INT_MAX_EJECUTIVOS = 200;

        string pszAccion = String.Empty;
        int lEjxTempCve = 0;
        int hConexion = 0;
        int hEjeMasBan = 0;
        int iTotalEjecutivos = 0; //El número total de Grupos Corporativos
        int iEjecutivosRestantes = 0;
        string pszSQL = String.Empty;
        string pszMsg = String.Empty;

        private void Actualiza_y_da_baja()
        {

            int iValor = 0;
            int hEjeBan = 0;
            int iError = 0;
            int reg_mod = 0;
            int iRespuesta = 0;

            this.Cursor = Cursors.WaitCursor;

            this.Cursor = Cursors.Default;

            CORVAR.pszgblsql = "delete from " + CORBD.DB_SYB_EJX + " where ejx_numero = " + Conversion.Str(lEjxTempCve);

            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //Obtiene los campos de la tabla de Ejecutivos Banemex
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "UPDATE " + DB_SYB_EMP + " SET ejx_numero = " + Str(lgblEjxCve) + " WHERE ejx_numero = " + Str(lEjxTempCve) + " and gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_EMP + " SET ejx_numero = " + Conversion.Str(CORVAR.lgblEjxCve) + " WHERE ejx_numero = " + Conversion.Str(lEjxTempCve) + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Modifica_Registro() != 0)
            {
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

        }

        private void Carga_Ejecutivos()
        {

            int iError = 0;
            int iValor = 0;
            int iCont = 0;
            object lEje = null;
            int lEjxCve = 0;

            //Limpia el List box
            ID_CEB_EJE_LB.Items.Clear();

            this.Cursor = Cursors.WaitCursor;

            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            CORVAR.pszgblsql = "select ejx_numero, ejx_nombre from " + CORBD.DB_SYB_EJX;

            iTotalEjecutivos = CORPROC2.Cuenta_Registros();
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                //    If iTotalEjecutivos > INT_MAX_EJECUTIVOS Then
                //        ID_CEB_MAS_3PB.Enabled = True
                //    End If
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //And iCont <= INT_MAX_EJECUTIVOS
                    lEjxCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    CORVAR.szgblEjxDesc.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_CEB_EJE_LB.Items.Add(StringsHelper.Format(lEjxCve, "0000000") + CORCONST.SPC_TRES + CORVAR.szgblEjxDesc.Value.Trim());
                    iCont++;
                };
            }

            //Realiza fin de Query
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //  iEjecutivosRestantes = iTotalEjecutivos - iCont

            //Posiciona en el Primer Elemento del ListBox
            if (ID_CEB_EJE_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEB_EJE_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

        }

        private void Command4_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void CORCTEJB_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                CORVAR.bgblCambio = -1;
                CORVAR.bgblValida = 0;

                if (pszAccion == CORCONST.TAG_ALTA || pszAccion == CORCONST.TAG_BAJA)
                {
                    Carga_Ejecutivos();
                }

            }
        }

        //ais-1593 chidalgo
        private void CORCTEJB_Activated()
        {
            CORVAR.bgblCambio = -1;
            CORVAR.bgblValida = 0;

            if (pszAccion == CORCONST.TAG_ALTA || pszAccion == CORCONST.TAG_BAJA)
            {
                Carga_Ejecutivos();
            }


        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Cursor = Cursors.WaitCursor;

            //Posiciona la forma
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Refresh();
            //
            //  If bgblAdmin Then
            //    ID_CEB_ALT_PB.Enabled = True
            //    ID_CEB_BAJ_PB.Enabled = True
            //    ID_CEB_CAM_PB.Enabled = True
            //    ID_CEB_CON_PB.Enabled = True
            //  Else
            //    ID_CEB_ALT_PB.Enabled = OpcionesAcceso(5).bAltas
            //    ID_CEB_BAJ_PB.Enabled = OpcionesAcceso(5).bBajas
            //    ID_CEB_CAM_PB.Enabled = OpcionesAcceso(5).bCambios
            //    ID_CEB_CON_PB.Enabled = OpcionesAcceso(5).bConsultas
            //  End If
            mdlParametros.gperPerfil.prHabilitaAcciones(CORCTEJB.DefInstance);
            Carga_Ejecutivos();

            this.Cursor = Cursors.Default;

        }

        private void Habilita_cambio()
        {

            string pszMsg = String.Empty;

            CORVAR.pszgblsql = "select ejx_numero from " + CORBD.DB_SYB_EJX + " where ejx_numero=" + CORVAR.lgblEjxCve.ToString();

            if (CORPROC2.Existe_Dato() != 0)
            {

                //Asigna Propiedades a la forma de mantenimiento
                CORMNEJB.DefInstance.Tag = CORCONST.TAG_CAMBIO;
                CORMNEJB.DefInstance.ID_MEB_NOM_PIC.Enabled = false;
                //Muestra forma de mantenimiento
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORMNEJB.DefInstance.ShowDialog();

                //UPGRADE_WARNING: (2065) Form event CORCTEJB.Activated has a new behavior.
                //ais-1593 chidalgo
                CORCTEJB_Activated();
            }
            else
            {
                this.Cursor = Cursors.Default;
                pszMsg = "El Ejecutivo Banamex seleccionado ha sido borrado por otro Usuario";
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                ID_CEB_EJE_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEB_EJE_LB));
                if (ID_CEB_EJE_LB.Items.Count != 0)
                {
                    ID_CEB_EJE_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }

        }

        private void Habilita_consulta()
        {

            CORVAR.pszgblsql = "select ejx_numero from " + CORBD.DB_SYB_EJX + " where ejx_numero=" + CORVAR.lgblEjxCve.ToString();

            if (CORPROC2.Existe_Dato() != 0)
            {

                //Asigna Propiedades a la forma de mantenimiento
                CORMNEJB.DefInstance.Tag = CORCONST.TAG_CONSULTA;
                CORMNEJB.DefInstance.SetEnable_ID_MEB_PPL2_PNL(false);
                CORMNEJB.DefInstance.SetEnable_ID_MEB_PPL1(false);
                //Posiciona botones de la forma de mantenimiento
                CORMNEJB.DefInstance.ID_MEB_CAN_PB.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMNEJB.DefInstance.Width)) - (((float)VB6.PixelsToTwipsX(CORMNEJB.DefInstance.ID_MEB_OK_PB.Width)) + 120 + ((float)VB6.PixelsToTwipsX(CORMNEJB.DefInstance.ID_MEB_CAN_PB.Width)))) / 2);
                CORMNEJB.DefInstance.ID_MEB_IMP_PB.Left = (int)VB6.TwipsToPixelsX(((float)VB6.PixelsToTwipsX(CORMNEJB.DefInstance.ID_MEB_CAN_PB.Left)) + ((float)VB6.PixelsToTwipsX(CORMNEJB.DefInstance.ID_MEB_CAN_PB.Width)) + 120);
                CORMNEJB.DefInstance.ID_MEB_OK_PB.Visible = false;
                //Muestra forma de mantenimiento
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORMNEJB.DefInstance.ShowDialog();
            }
            else
            {
                this.Cursor = Cursors.Default;
                pszMsg = "El Ejecutivo Banamex seleccionado ha sido borrado por otro Usuario";
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                ID_CEB_EJE_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEB_EJE_LB));
                if (ID_CEB_EJE_LB.Items.Count != 0)
                {
                    ID_CEB_EJE_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }

        }

        private void ID_CEB_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //Asigna propiedades a la forma de mantenimiento
            pszAccion = CORCONST.TAG_ALTA;
            CORMNEJB.DefInstance.Tag = CORCONST.TAG_ALTA;

            //Muestra forma de Mantenimiento
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORMNEJB.DefInstance.ShowDialog();

            //Refresca la forma
            if (CORVAR.bgblEjxActiva == (0) && CORVAR.bgblValida == (0))
            {
                //UPGRADE_WARNING: (2065) Form event CORCTEJB.Activated has a new behavior.
                //ais-1593 chidalgo
                CORCTEJB_Activated();
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CEB_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iResp = 0;
            int iIndice = 0;
            int iElementos = 0;


            this.Cursor = Cursors.WaitCursor;

            pszAccion = CORCONST.TAG_BAJA;
            try
            {
                //Verifica que existan elementos en el List Box
                if (ID_CEB_EJE_LB.Items.Count > CORVB.NULL_INTEGER)
                {

                    //Verifica que se haya seleccionado un elemento
                    if (ListBoxHelper.GetSelectedIndex(ID_CEB_EJE_LB) < CORVB.NULL_INTEGER)
                    {
                        //UPGRADE_ISSUE: (2064) Threed.SSPanel property ID_COR_MEDO_PNL.Caption was not upgraded.
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORSTR.STR_NO_SEL_ELEM;
                    }
                    else
                    {

                        CORVAR.lgblEjxCve = Convert.ToInt32(Conversion.Val(ID_CEB_EJE_LB.Text.Substring(0, Math.Min(ID_CEB_EJE_LB.Text.Length, 7))));
                        CORVAR.pszgblEjxDesc = Strings.Mid(ID_CEB_EJE_LB.Text, 10).Trim();

                        CORVAR.pszgblsql = "select ejx_numero from " + CORBD.DB_SYB_EJX + " where ejx_numero=" + CORVAR.lgblEjxCve.ToString();

                        if (CORPROC2.Existe_Dato() != 0)
                        {
                            //Confirma si realmente se desea dar de baja la división seleccionada
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            iResp = (int)Interaction.MsgBox("Dar de baja a : " + ID_CEB_EJE_LB.Text, (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                            if (iResp == CORVB.IDYES)
                            {
                                Realiza_baja();
                                //UPGRADE_WARNING: (2065) Form event CORCTEJB.Activated has a new behavior.
                                //ais-1593 chidalgo
                                CORCTEJB_Activated();
                                if (ID_CEB_EJE_LB.Items.Count > CORVB.NULL_INTEGER)
                                {
                                    ID_CEB_EJE_LB.SelectedIndex = CORVB.NULL_INTEGER;
                                }
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "El Ejecutivo Banamex seleccionado ha sido borrado por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_CEB_EJE_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEB_EJE_LB));
                            if (ID_CEB_EJE_LB.Items.Count != 0)
                            {
                                ID_CEB_EJE_LB.SelectedIndex = CORVB.NULL_INTEGER;
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
                MessageBox.Show("Fallo operación ID_CEB_BAJ_PB_Click " + exc.Message, "Error Corctejb", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_CEB_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            pszAccion = CORCONST.TAG_CAMBIO;

            if (ID_CEB_IRE_CKB.Value)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORIREJB.DefInstance.ShowDialog();
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

                if (ID_CEB_EJE_LB.Items.Count > CORVB.NULL_INTEGER)
                {

                    //Verifica que se haya seleccionado un elemento
                    if (ListBoxHelper.GetSelectedIndex(ID_CEB_EJE_LB) >= CORVB.NULL_INTEGER)
                    {

                        CORVAR.lgblEjxCve = Convert.ToInt32(Conversion.Val(ID_CEB_EJE_LB.Text.Substring(0, Math.Min(ID_CEB_EJE_LB.Text.Length, 7))));
                        CORVAR.pszgblEjxDesc = Strings.Mid(ID_CEB_EJE_LB.Text, 10).Trim();

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

            this.Cursor = Cursors.Default;

        }

        //UPGRADE_NOTE: (7001) The following declaration (ID_CEB_CER_PB_Click) seems to be dead code
        //private void  ID_CEB_CER_PB_Click()
        //{
        //
        //this.Close();
        //
        //}

        private void ID_CEB_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            pszAccion = CORCONST.TAG_CONSULTA;

            try
            {



                if (ID_CEB_IRE_CKB.Value)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    CORIREJB.DefInstance.ShowDialog();

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

                    //Verifica que existan elementos enel List Box
                    if (ID_CEB_EJE_LB.Items.Count > CORVB.NULL_INTEGER)
                    {

                        //Verifica que se haya seleccionado un elemento
                        if (ListBoxHelper.GetSelectedIndex(ID_CEB_EJE_LB) >= CORVB.NULL_INTEGER)
                        {

                            CORVAR.lgblEjxCve = StringsHelper.IntValue(ID_CEB_EJE_LB.Text.Substring(0, Math.Min(ID_CEB_EJE_LB.Text.Length, 7)));
                            CORVAR.pszgblEjxDesc = Strings.Mid(ID_CEB_EJE_LB.Text, 10).Trim();
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
                MessageBox.Show("Fallo operación ID_CEB_CON_PB_Click " + exc.Message, "Error Corctejb", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_CEB_EJE_LB_DoubleClick(Object eventSender, EventArgs eventArgs)
        {
            if (ID_CEB_CON_PB.Enabled)
            {
                ID_CEB_CON_PB_Click(ID_CEB_CON_PB, new EventArgs());
            }
        }

        private void ID_CEB_EJE_LB_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;

            if (KeyCode == CORVB.KEY_DELETE)
            {
                ID_CEB_BAJ_PB_Click(ID_CEB_BAJ_PB, new EventArgs());
            }

        }

        private void ID_CEB_MAS_3PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iError = 0;
            int iValor = 0;
            int iCont = 0;

            //Limpia el List box
            ID_CEB_EJE_LB.Items.Clear();

            if (iEjecutivosRestantes > CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.WaitCursor;
                //Obtiene los Campos de la tabla de Ejecutivos Banamex
                //ros    iValor = qeFetchPrev(hEjeMasBan)

                while (!(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS && iCont < INT_MAX_EJECUTIVOS))
                {
                    CORVAR.lgblEjxCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    CORVAR.szgblEjxDesc.Value = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_CEB_EJE_LB.Items.Add(StringsHelper.Format(CORVAR.lgblEjxCve, "0000000") + CORCONST.SPC_TRES + CORVAR.szgblEjxDesc.Value.Trim());
                    iCont++;
                    if (iTotalEjecutivos == iCont + iTotalEjecutivos - iEjecutivosRestantes)
                    {
                        iCont = INT_MAX_EJECUTIVOS;
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    }
                };
                iEjecutivosRestantes -= iCont;
                this.Cursor = Cursors.Default;
            }
            else
            {
                //Realiza fin de Query
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                Carga_Ejecutivos();
            }

            //Posiciona en el Primer Elemento del ListBox
            if (ID_CEB_EJE_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CEB_EJE_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }
            Application.DoEvents();

        }

        private void Realiza_baja()
        {

            int hEjeBan = 0;
            int iError = 0;
            DialogResult iRespuesta = (DialogResult)0;
            int iValor = 0;

            int reg_mod = 1;

            this.Cursor = Cursors.WaitCursor;

            //Obtiene los campos de la tabla de Ejecutivos Banemex
            CORVAR.pszgblsql = "delete from " + CORBD.DB_SYB_EJX + " where ejx_numero = " + Conversion.Str(CORVAR.lgblEjxCve) + " and (select count(*) from " + CORBD.DB_SYB_EMP + " where ejx_numero = " + Conversion.Str(CORVAR.lgblEjxCve) + ") = 0";

            //  reg_mod = Cuenta_Registros

            if (CORPROC2.Modifica_Registro() != 0)
            {
                ID_CEB_EJE_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEB_EJE_LB));
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Se realizó con éxito la operación.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                //UPGRADE_WARNING: (6021) Casting 'MsgBoxResult' to Enum may cause different behaviour.
                iRespuesta = (DialogResult)Interaction.MsgBox("El ejecutivo seleccionado está asignado a alguna empresa, si desea borralo presione aceptar y aparecerá pantalla para dar de alta uno nuevo y asignarselo a las empresas", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + CORVB.MB_OKCANCEL), CORSTR.STR_APP_TIT);
                if (iRespuesta == CORVB.IDOK)
                {
                    CORVAR.bgblValida = -1;
                    lEjxTempCve = CORVAR.lgblEjxCve;
                    ID_CEB_ALT_PB_Click(ID_CEB_ALT_PB, new EventArgs());
                    CORVAR.bgblValida = 0;
                    if (CORVAR.bgblCambio == (-1))
                    {
                        Actualiza_y_da_baja();
                    }
                    ID_CEB_EJE_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEB_EJE_LB));
                }
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


            this.Cursor = Cursors.Default;

        }
        private void CORCTEJB_Closed(Object eventSender, EventArgs eventArgs)
        {
            MemoryHelper.ReleaseMemory();
        }
    }
}