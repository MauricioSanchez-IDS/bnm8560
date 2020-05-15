using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORIRRPG
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Forma para captura de un ejecutivo Empresa          **
        //**                    en la busqueda especifica de reportes               **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        private void CORIRRPG_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                ID_IRA_GPO_PIC.Text = CORVB.NULL_STRING;
                ID_IRA_GPO_PIC.Focus();

                this.Cursor = Cursors.Default;

            }
        }

        private void ID_IRA_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.bgblCerrar = -1;
            this.Close();

            this.Cursor = Cursors.Default;

        }



        private void ID_IRA_GPO_PIC_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (eventArgs.KeyChar == 13)
            {
                ID_IRA_OK_PB.PerformClick();
                return;

            }
            if (KeyAscii < ((int)'0') || KeyAscii > ((int)'9') && KeyAscii != 32)
            {
                KeyAscii = 0;
                Interaction.Beep();
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_IRA_GPO_PIC_Leave(Object eventSender, EventArgs eventArgs)
        {

            ID_IRA_GPO_PIC.Text = StringsHelper.Format(ID_IRA_GPO_PIC.Text, "0000");

        }


        private void ID_IRA_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int hConexion = 0;
            int iCorNum = 0;
            int hGrupo = 0;
            int iError = 0;
            int iValor = 0;
            int reg_mod = 0;

            this.Cursor = Cursors.WaitCursor;

            if (ID_IRA_GPO_PIC.Text.Trim() == CORVB.NULL_STRING)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Favor de capturar la número deseado", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                return;
            }

            CORVAR.lgblGpoCve = Convert.ToInt32(Conversion.Val(ID_IRA_GPO_PIC.Text));

            CORVAR.bgblIrExiste = 0;
            CORVAR.bgblCerrar = 0;

            this.Cursor = Cursors.WaitCursor;

            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "exec ira_grupo_nom " + Format$(igblBanco) + "," + Format$(lgblGpoCve)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            try
            {
                //***** INICIO CODIGO NUEVO FSWBMX *****
                CORVAR.pszgblsql = "exec ira_grupo_nom " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblGpoCve.ToString();
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    //    If Cuenta_Registros > NULL_INTEGER Then
                    CORVAR.bgblIrExiste = -1;
                    //    End If
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                //Realiza Desconexión
                this.Close();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_IRA_OK_PB_Click)", e);
            }
            finally
            { 
                this.Cursor = Cursors.Default;
            }

        }
    }
}