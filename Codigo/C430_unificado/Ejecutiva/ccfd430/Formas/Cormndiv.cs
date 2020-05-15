using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMNDIV
        : System.Windows.Forms.Form
    {


        //'**********************************************************
        //*
        //*    Descripción : Módulo de Mantenimiento Catálogo de
        //*                  Divisiones Regionales de Banamex
        //*
        //*    Fecha de Inicio : 18/04/94
        //*
        //*    Responsable: Abraham Ramírez Basurto
        //*
        //**********************************************************

        const string STR_INT_CVE_DIV = "Introduzca clave o descripción de División";

        //Constantes que se asginan a los TAGS
        const string TAG_CONSULTA = "consulta";
        const string TAG_ALTA = "alta";
        const string TAG_CAMBIO = "cambio";
        const string NO_ALTA_DESC = "No se dió de alta la descripción";
        const string NO_ALTA_CVE = "No se dió de alta la clave";
        const string CLAVE_YA_EXISTE = "La clave que ingresó ya existe";

        int hConexion = 0;
        int hDivision = 0;

        int bExitoOpe = 0;


        public void CORMNDIV_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                int iError = 0;
                int iRegistros = 0;

                this.Cursor = Cursors.WaitCursor;

                if (Tag.ToString() != TAG_ALTA)
                {
                    //Obtiene los campos de la tabla de Divisiones Regionales
                    CORVAR.pszgblsql = "select * from " + CORBD.DB_SYB_DIV + " where div_num = " + CORVAR.igblDivCve.ToString();



                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        ID_DIV_CVE_EB.CtlText = StringsHelper.Format(CORVAR.igblDivCve, "000");
                        ID_DIV_DIV_EB.Text = CORVAR.pszgblDivDesc;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("La división " + StringsHelper.Format(CORVAR.igblDivCve, "000") + "  " + CORVAR.pszgblDivDesc + " ha sido borrada", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }

                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                }

                this.Cursor = Cursors.Default;

            }
        }

        public void CORMNDIV_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            //Verifica si se ha oprimido enter
            if (KeyAscii == CORVB.KEY_RETURN)
            {
                ID_DIV_ACE_PB_Click(ID_DIV_ACE_PB, new EventArgs());
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

            int iError = 0;
            int iRegistros = 0;

            CORVAR.bgblDivActiva = 0;
            bExitoOpe = 0;

            //Posiciona Forma
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY(3000);

            this.Refresh();

        }

        public void CORMNDIV_Closed(Object eventSender, EventArgs eventArgs)
        {

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ID_DIV_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                if (CORMNDIV.DefInstance.Tag.ToString() == TAG_ALTA)
                {
                    Realiza_alta();
                }
                else if (CORMNDIV.DefInstance.Tag.ToString() == TAG_CAMBIO)
                {
                    Realiza_cambio();
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_DIV_ACE_PB_Click)", e);
            }
        }

        public void ID_DIV_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.bgblDivActiva = -1;
            this.Close();

        }




        private void ID_DIV_CVE_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
            {
                eventArgs.keyAscii = (short)CORVB.NULL_INTEGER;
            }
        }

        public void ID_DIV_DIV_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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

        public void ID_DIV_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
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
                PrinterHelper.Printer.Print("CLAVE                  : " + ID_DIV_CVE_EB.CtlText);
                PrinterHelper.Printer.Print("DESCRIPCION            : " + ID_DIV_DIV_EB.Text);

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.EndDoc();
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "()", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        public void Realiza_alta()
        {

            int iError = 0;

            this.Cursor = Cursors.WaitCursor;

            //Inicializa variable que indica si ya existe la clave
            int bExiste = 0;

            CORVAR.igblDivCve = Convert.ToInt32(Conversion.Val(ID_DIV_CVE_EB.CtlText));
            CORVAR.pszgblDivDesc = ID_DIV_DIV_EB.Text.Trim();

            //Verifica ya existe la clave accesada
            for (int iContador = 0; iContador <= CORCTDIV.DefInstance.ID_DIV_GRP_LB.Items.Count - 1; iContador++)
            {
                if (Conversion.Val(Strings.Mid(VB6.GetItemString(CORCTDIV.DefInstance.ID_DIV_GRP_LB, iContador), 1, 3)) == CORVAR.igblDivCve)
                {
                    bExiste = -1;
                }
            }

            CORCTDIV.DefInstance.ID_DIV_GRP_LB.Enabled = true;

            //Verifica si  se han ingresado la clave
            if (ID_DIV_CVE_EB.CtlText.Trim() == CORVB.NULL_STRING)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(NO_ALTA_CVE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            //Verifica si  se han ingresado la clave > 0
            if (Conversion.Val(ID_DIV_CVE_EB.CtlText) <= CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("La clave deberá ser mayor de cero.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            //Verifica si se ingresó la descripción
            if (ID_DIV_DIV_EB.Text.Trim() == CORVB.NULL_STRING)
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
                bExiste = 0;

            }
            else
            {
                //pszgblConexion = "INSERT INTO " + DB_SYB_DIV + " values (" + Str(igblDivCve) + ",'" + Valida_Comilla(pszgblDivDesc) + "')"
                CORVAR.pszgblsql = "INSERT INTO " + CORBD.DB_SYB_DIV + " values (" + Conversion.Str(CORVAR.igblDivCve) + ",'" + CORPROC.Valida_Comilla(CORVAR.pszgblDivDesc) + "')";
                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se pudo dar de alta la división " + StringsHelper.Format(CORVAR.igblDivCve, "000") + "  " + CORVAR.pszgblDivDesc, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return;
                }

                ID_DIV_CVE_EB.CtlText = CORVB.NULL_STRING;
                ID_DIV_DIV_EB.Text = CORVB.NULL_STRING;

                this.Close();

            }

            this.Cursor = Cursors.Default;

        }

        public void Realiza_cambio()
        {

            int iError = 0;

            string pszDivDesc = ID_DIV_DIV_EB.Text;

            //Verifica si se ingresó la descripción
            if (ID_DIV_DIV_EB.Text.Trim() == CORVB.NULL_STRING)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(NO_ALTA_DESC, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            VB6.SetItemString(CORCTDIV.DefInstance.ID_DIV_GRP_LB, ListBoxHelper.GetSelectedIndex(CORCTDIV.DefInstance.ID_DIV_GRP_LB), Strings.Mid(VB6.GetItemString(CORCTDIV.DefInstance.ID_DIV_GRP_LB, ListBoxHelper.GetSelectedIndex(CORCTDIV.DefInstance.ID_DIV_GRP_LB)), 1, 6) + ID_DIV_DIV_EB.Text.Trim());

            CORVAR.pszgblsql = "update " + CORBD.DB_SYB_DIV + " set div_nom = " + "'" + CORPROC.Valida_Comilla(pszDivDesc) + "'" + " where div_num = " + Conversion.Str(CORVAR.igblDivCve);

            if (CORPROC2.Modifica_Registro() != 0)
            {
                this.Cursor = Cursors.Default;
                bExitoOpe = -1;
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se pudo actualizar la división " + CORVAR.igblDivCve.ToString() + "  " + pszDivDesc + ". El registro está siendo ocupado por otro usuario o ha sido borrado...", Application.ProductName);
            }

            CORVAR.igblTempDivCve = CORVAR.igblDivCve;

            this.Close();

        }

        private void CMDialog1_Enter(object sender, EventArgs e)
        {

        }
    }
}