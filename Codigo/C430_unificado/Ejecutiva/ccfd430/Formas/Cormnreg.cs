using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMNREG
        : System.Windows.Forms.Form
    {

        //**********************************************************
        //*
        //*    Descripción : Módulo de Manteminiento al Catálogo
        //*                  Regionales de Banamex
        //*
        //*    Fecha de Inicio : 18/04/94
        //*
        //*    Responsable: Abraham Ramírez Basurto
        //*
        //**********************************************************

        //Declaración de Constantes
        const string STR_INT_CVE_REG = "Introduzca clave o descripción de Región";

        //Constantes que se asignan a los TAGS
        const string TAG_CONSULTA = "consulta";
        const string TAG_ALTA = "alta";
        const string TAG_CAMBIO = "cambio";

        const string CLAVE_YA_EXISTE = "La clave que ingresó ya existe";
        const string NO_ALTA_DESC = "No se dió de alta la descripción";
        const string NO_ALTA_CVE = "No se dió de alta la clave";

        int hConexion = 0;

        public void CORMNREG_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                //Verifica si se oprimió el botón de Altas, Cambios o Consultas
                if (Tag.ToString() != TAG_ALTA)
                {
                    ID_REG_CVE_EB.CtlText = StringsHelper.Format(CORVAR.igblRegCve, "000");
                    ID_REG_REG_EB.Text = CORVAR.pszgblRegDesc;
                }

            }
        }

        public void CORMNREG_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            if (KeyAscii == CORVB.KEY_RETURN)
            {
                ID_REG_ACE_PB_Click(ID_REG_ACE_PB, new EventArgs());
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        public void Form_Load()
        {

            //Posiciona Forma
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY(3000);

            this.Cursor = Cursors.WaitCursor;

            CORVAR.bgblRegActiva = 0;


            this.Cursor = Cursors.Default;

        }


        public void ID_REG_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                if (CORMNREG.DefInstance.Tag.ToString() == TAG_ALTA)
                {
                    Realiza_alta();
                }
                else if (CORMNREG.DefInstance.Tag.ToString() == TAG_CAMBIO)
                {
                    Realiza_cambio();
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_REG_ACE_PB_Click)", e);
            }
        }

        public void ID_REG_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.bgblRegActiva = -1;
            this.Close();

        }


        private void ID_REG_CVE_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
            {
                eventArgs.keyAscii = (short)CORVB.NULL_INTEGER;
            }
        }

        public void ID_REG_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                PrinterHelper.Printer.FontName = "Courier New";

                PrinterHelper.Printer.FontBold = true;

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print(new String(' ', 24) + Text);
                PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', Strings.Len(Text)));
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("CLAVE                  : " + ID_REG_CVE_EB.CtlText);
                PrinterHelper.Printer.Print("DESCRIPCION            : " + ID_REG_REG_EB.Text);

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.EndDoc();
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_REG_IMP_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        public void ID_REG_REG_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        public void Realiza_alta()
        {

            int hRegion = 0;
            int iError = 0;

            this.Cursor = Cursors.WaitCursor;

            int bExiste = 0;

            CORVAR.igblRegCve = Convert.ToInt32(Conversion.Val(ID_REG_CVE_EB.CtlText));
            CORVAR.pszgblRegDesc = ID_REG_REG_EB.Text.Trim();

            //Verifica ya existe la clave accesada
            for (int iContador = 0; iContador <= CORCTREG.DefInstance.ID_REG_GRP_LB.Items.Count - 1; iContador++)
            {
                if (Conversion.Val(Strings.Mid(VB6.GetItemString(CORCTREG.DefInstance.ID_REG_GRP_LB, iContador), 1, 3)) == CORVAR.igblRegCve)
                {
                    bExiste = -1;
                }
            }

            //Verifica que se haya ingresado la clave
            if (ID_REG_CVE_EB.CtlText.Trim() == CORVB.NULL_STRING)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(NO_ALTA_CVE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            //Verifica que se haya ingresado la clave > 0
            if (Conversion.Val(ID_REG_CVE_EB.CtlText) == CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("La clave deberá ser mayor a cero.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            //Verifica que se haya ingresado la descripción
            if (ID_REG_REG_EB.Text.Trim() == CORVB.NULL_STRING)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(NO_ALTA_DESC, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            if (bExiste != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CLAVE_YA_EXISTE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            else
            {

                CORVAR.pszgblsql = "insert " + CORBD.DB_SYB_REG + " (reg_num, reg_nom)" + " values (" + Conversion.Str(CORVAR.igblRegCve) + ",'" + CORPROC.Valida_Comilla(CORVAR.pszgblRegDesc) + "')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se pudo dar de alta la región " + StringsHelper.Format(CORVAR.igblRegCve, "000") + "  " + CORVAR.pszgblRegDesc, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                this.Close();

            }

            this.Cursor = Cursors.Default;

        }

        public void Realiza_cambio()
        {

            int hRegion = 0;
            int iError = 0;
            int bExiste = 0;
            int iContador = 0;

            this.Cursor = Cursors.WaitCursor;


            //Verifica que se haya ingresado la clave
            if (ID_REG_CVE_EB.CtlText.Trim() == CORVB.NULL_STRING)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(NO_ALTA_CVE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            //Verifica que se haya ingresado la clave > 0
            if (Conversion.Val(ID_REG_CVE_EB.CtlText) == CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("La clave deberá ser mayor a cero.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            //Verifica que se haya ingresado la descripción
            if (ID_REG_REG_EB.Text.Trim() == CORVB.NULL_STRING)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(NO_ALTA_DESC, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            VB6.SetItemString(CORCTREG.DefInstance.ID_REG_GRP_LB, ListBoxHelper.GetSelectedIndex(CORCTREG.DefInstance.ID_REG_GRP_LB), Strings.Mid(VB6.GetItemString(CORCTREG.DefInstance.ID_REG_GRP_LB, ListBoxHelper.GetSelectedIndex(CORCTREG.DefInstance.ID_REG_GRP_LB)), 1, 6) + ID_REG_REG_EB.Text.Trim());

            string pszRegDesc = ID_REG_REG_EB.Text;

            //Obtiene tabla de Reiones Geográficas
            CORVAR.pszgblsql = "update " + CORBD.DB_SYB_REG + " set reg_nom = " + "'" + CORPROC.Valida_Comilla(pszRegDesc) + "'" + " where reg_num = " + Conversion.Str(CORVAR.igblRegCve);
            CORVAR.igblTempRegCve = CORVAR.igblRegCve;

            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Close();

            this.Cursor = Cursors.Default;

        }
        private void CORMNREG_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}