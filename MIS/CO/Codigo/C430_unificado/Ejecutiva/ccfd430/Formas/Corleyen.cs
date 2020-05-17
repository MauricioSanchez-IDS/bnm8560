using Artinsoft.VB6.Gui;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORLEYEN
        : System.Windows.Forms.Form
    {

        private void CORLEYEN_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Forma para captura de leyendas de los reportes      **
        //**                    para ser impresa en la parte inferior               **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int hConexion1 = 0;
        int hStmt = 0;

        private int Conexion()
        {

            return -1;

        }

        private void CORLEYEN_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            if (KeyAscii == CORVB.KEY_ESCAPE)
            {
                this.Close();
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)(Screen.PrimaryScreen.Bounds.Height - this.Height);

            this.Cursor = Cursors.WaitCursor;

            if (Conexion() != 0)
            {
                ID_LEY_LEY_EB.Text = CORVAR.pszgblLeyenda;
            }
            else
            {
                //AIS-1182 NGONZALEZ
                CORVAR.igblErr = API.USER.PostMessage(CORLEYEN.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }

            this.Cursor = Cursors.Default;
        }

        private void ID_LEY_GRA_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            string pszLey = String.Empty;
            string pszInserta = String.Empty;
            int iPosIni = 0;
            int iPosFin = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (ID_LEY_LEY_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox("Favor de teclear una descripción válida.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    ID_LEY_LEY_EB.Focus();
                }
                else
                {
                    CORVAR.pszgblLeyenda = ID_LEY_LEY_EB.Text.TrimEnd();

                    //borra la leyenda anterior
                    CORVAR.pszgblsql = "DELETE FROM " + CORBD.DB_SYB_MSG + " WHERE msg_forma ='CORRPDEJ'";

                    if (CORPROC2.Modifica_Registro() != 0)
                    {
                    }

                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

                    //Inserta la nueva leyenda
                    pszLey = ID_LEY_LEY_EB.Text.TrimEnd();
                    iPosFin = pszLey.Length / 240;

                    for (int iCont = 1; iCont <= iPosFin; iCont++)
                    {
                        pszInserta = Strings.Mid(pszLey, ((iCont - 1) * 240) + 1, (iCont) * 240);
                        pszLey = Strings.Mid(pszLey, ((iCont) * 240) + 1);
                        CORVAR.pszgblsql = "INSERT " + CORBD.DB_SYB_MSG + " VALUES ('CORRPDEJ','" + pszInserta + "')";

                        if (CORPROC2.Modifica_Registro() != 0)
                        { //Ocurrio algun error en la ejecución SQL
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            CORVAR.igblErr = (int)Interaction.MsgBox("La Leyenda ha sido actualizada.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            CORVAR.igblErr = (int)Interaction.MsgBox("La Leyenda no pudo ser guardada en la Base de Datos , sin embargo, si aparecerá en su reporte.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        }

                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                    }

                    CORVAR.pszgblsql = "INSERT " + CORBD.DB_SYB_MSG + " VALUES ('CORRPDEJ','" + pszLey + "')";

                    if (CORPROC2.Modifica_Registro() != 0)
                    { //Ocurrio algun error en la ejecución SQL
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        CORVAR.igblErr = (int)Interaction.MsgBox("La Leyenda ha sido actualizada.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        CORVAR.igblErr = (int)Interaction.MsgBox("La Leyenda no pudo ser guardada en la Base de Datos , sin embargo, si aparecerá en su reporte.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    }

                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_LEY_GRA_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_LEY_LEY_EB_TextChanged(Object eventSender, EventArgs eventArgs)
        {

            ID_LEY_GRA_PB.Enabled = true;

        }

        private void ID_LEY_LEY_EB_Leave(Object eventSender, EventArgs eventArgs)
        {

            ID_LEY_LEY_EB.Text = ID_LEY_LEY_EB.Text.ToUpper();

        }

        private void ID_LEY_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Close();

            this.Cursor = Cursors.Default;

        }
        private void CORLEYEN_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}