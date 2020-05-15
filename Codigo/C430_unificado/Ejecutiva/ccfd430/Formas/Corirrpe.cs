using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORIRRPE
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Forma para captura de una Empresa                   **
        //**                    en la busqueda especifica de reportes               **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        private void CORIRRPE_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                ID_IRA_EMP_PIC.Focus();
                ID_IRA_EMP_PIC.Text = CORVB.NULL_STRING;

                this.Cursor = Cursors.Default;

            }
        }

        private void ID_IRA_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.bgblCerrar = -1;
            this.Close();

        }



        private void ID_IRA_EMP_PIC_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //ais-1597 chidalgo
            if (KeyAscii == 13)
            {
                ID_IRA_OK_PB_Click(this, eventArgs);
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

        private void ID_IRA_EMP_PIC_Leave(Object eventSender, EventArgs eventArgs)
        {
            //EISSA 03-10-2001. Cambio para el formateo del número de empresa
            ID_IRA_EMP_PIC.Text = StringsHelper.Format(ID_IRA_EMP_PIC.Text, Formato.sMascara(Formato.iTipo.Empresa));

        }


        private void ID_IRA_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int hConexion = 0;
            int iCorNum = 0;
            int hEmpresa = 0;
            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int reg_mod = 0;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_IRA_EMP_PIC.Text));

            if (CORVAR.lgblEmpCve <= CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("La clave de la empresa deberá se mayor de cero.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                return;
            }

            CORVAR.bgblIrExiste = 0;
            CORVAR.bgblCerrar = 0;


            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "exec ir_empresa " + Format$(igblBanco) + "," + Format$(lgblEmpCve)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            try
            {
                //***** INICIO CODIGO NUEVO FSWBMX *****
                CORVAR.pszgblsql = "exec ir_empresa " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblEmpCve.ToString();
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        iCorNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                        CORVAR.pszgblEmpDesc = pszEmpDesc;
                        CORVAR.bgblIrExiste = -1;
                    }
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                if (CORVAR.bgblIrExiste != 0)
                {
                    for (int iCont = 1; iCont <= CORRPCE2.DefInstance.ID_REE_GRU_COB.Items.Count; iCont++)
                    {
                        if (iCorNum == Conversion.Val(Strings.Mid(VB6.GetItemString(CORRPCE2.DefInstance.ID_REE_GRU_COB, iCont - 1), 1, 4)))
                        {
                            CORRPCE2.DefInstance.ID_REE_GRU_COB.SelectedIndex = iCont - 1;
                            break;
                        }
                    }
                    this.Close();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox("La empresa capturada no existe en catálogos", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    ID_IRA_EMP_PIC.Text = CORVB.NULL_STRING;
                }

                this.Cursor = Cursors.Default;

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_IRA_OK_PB_Click)", e);
            }
        }

    }
}