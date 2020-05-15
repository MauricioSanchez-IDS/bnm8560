using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORMNEJB
        : System.Windows.Forms.Form
    {

        //**********************************************************
        //*
        //*    Descripción : Módulo de Mantenimiento al Catálogo
        //*                  de Ejecutivos Banamex
        //*
        //*    Fecha de Inicio : 18/04/94
        //*
        //*    Responsable: Abraham Ramírez Basurto
        //*
        //**********************************************************


        const string CLAVE_YA_EXISTE = "La clave que ingresó ya existe";
        const string NO_ALTA_DATO = "Falta por capturar el campo ";

        int bAltaFirma = 0;
        int hConexion = 0;


        private void Carga_Firma()
        {

            ID_MEB_FIR_IMM.ClearImage = true;
            IMAGEN.LeerImagen(ID_MEB_FIR_IMM, "MTCEJX01", "ejx_firma", " where ejx_numero = " + CORVAR.lgblEjxCve.ToString());

        }

        private void CORMNEJB_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                //Verifica si se oprimió el botón de Cambios o Consultas
                //Si es asi se llenan los List box con los datos seleccionados
                if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_ALTA)
                {
                    if (ID_MEB_NOM_PIC.Enabled)
                    {
                        ID_MEB_NOM_PIC.Focus();
                    }

                }
                else if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_CAMBIO)
                {
                    if (CORVAR.bgblFirma == (0))
                    {
                        Muestra_Datos();
                        Carga_Firma();
                        ID_MEB_FIR_IMM.Visible = false;
                        ID_MEB_FIR_IMM.Visible = true;
                    }
                    if (ID_MEB_NOM_EB.Enabled)
                    {
                        ID_MEB_NOM_EB.Focus();
                    }

                }
                else if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_CONSULTA)
                {
                    Muestra_Datos();
                    Carga_Firma();
                    ID_MEB_FIR_IMM.Visible = false;
                    ID_MEB_FIR_IMM.Visible = true;
                }

                this.Cursor = Cursors.Default;
                this.Refresh();

            }
        }

        private void CORMNEJB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            //Verifica si se ha oprimido enter
            if (KeyAscii == CORVB.KEY_RETURN)
            {
                ID_MEB_OK_PB_Click(ID_MEB_OK_PB, new EventArgs());
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

            this.Top = (int)VB6.TwipsToPixelsY(1450);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Refresh();

            this.Cursor = Cursors.WaitCursor;

            CORVAR.bgblAbreFir = 0;
            CORVAR.bgblFirma = 0;
            CORVAR.bgblModFirma = 0;
            CORVAR.bgblEjxActiva = 0;

            Llena_combo();
            CRSGeneral.prCargaEstados();
            CRSGeneral.prCargaEstadoEnCombo(ID_MEB_EDO_EB);
            this.Cursor = Cursors.Default;

        }


        private void CORMNEJB_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
        {
            int Cancel = (eventArgs.Cancel) ? 1 : 0;
            int UnloadMode = (int)eventArgs.CloseReason;

            //Verifica si la forma se cerró por el Control Menú
            if (eventArgs.CloseReason == CloseReason.UserClosing)
            {
                CORVAR.bgblEjxActiva = -1;
            }

            eventArgs.Cancel = Cancel != 0;
        }

        private void CORMNEJB_Closed(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                File.Delete(CORVAR.pszgblPathFirmas + "firma.pcx");

                MemoryHelper.ReleaseMemory();
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(CORMNEJB_Closed)", exc);

                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        private string Guarda_firma()
        {


            //Inicia el proceso de guardar la imagen
            IMAGEN.GrabarImagen(ID_MEB_FIR_IMM, "MTCEJX01", "ejx_firma", " where ejx_numero = " + Conversion.Str(CORVAR.lgblEjxCve));


            return String.Empty;
        }

        private void ID_MEB_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                this.Cursor = Cursors.WaitCursor;

                //Asigna tag para evitar que se realice la baja en el
                //módulo actualiza y da de baja
                CORVAR.bgblCambio = 0;

                //Enciende bandera para activar o no la forma de catálogo
                CORVAR.bgblEjxActiva = -1;

                //***** JPU *****    Se van a obtener los Ejecutivos Banamex
                mdlParametros.gcejxEjecutivoBanamex = null;
                mdlParametros.gcejxEjecutivoBanamex = new colEjecutivoBanamex();
                mdlParametros.gcejxEjecutivoBanamex.prObtenEjecutivoBanamex();
                //***** JPU *****


                File.Delete(CORVAR.pszgblPathFirmas + "firma.pcx");

                this.Close();

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEB_CAN_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_MEB_CIU_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "");
            //KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEB_COL_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "#");
            //KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }



        private void ID_MEB_CP_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        private void ID_MEB_CP_PIC_Leave(Object eventSender, EventArgs eventArgs)
        {

            ID_MEB_CP_PIC.Text = StringsHelper.Format(ID_MEB_CP_PIC.Text, "00000");

        }


        private void ID_MEB_DOM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, ".,-#");
            // KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_MEB_EDO_EB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (ID_MEB_EDO_EB.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un estado para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancel = true;
            }
            eventArgs.Cancel = Cancel;
        }

        private void ID_MEB_EXT_ITB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }



        private void ID_MEB_FAX_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        private void ID_MEB_FIR_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORALTFI.DefInstance.ShowDialog();

            if (CORVAR.bgblModFirma == (-1))
            {
                ID_MEB_FIR_IMM.LoadImage = CORVAR.pszgblPathFirmas + "firma.pcx";
            }
            this.Cursor = Cursors.Default;
            //***** INICIO CODIGO NUEVO *****
            ID_MEB_PPL1.Visible = false;
            ID_MEB_PPL1.Visible = true;
            ID_MEB_PPL2_PNL.Visible = false;
            ID_MEB_PPL2_PNL.Visible = true;
            //***** FIN DE CODIGO NUEVO *****
        }

        private void ID_MEB_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                PrinterHelper.Printer.FontName = "Courier New";

                PrinterHelper.Printer.FontBold = true;
                PrinterHelper.Printer.DocumentName = "TCC430";
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print(new String(' ', 24) + Text);
                PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', Strings.Len(Text)));
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("NOMINA                 : ", ID_MEB_NOM_PIC.Text);
                PrinterHelper.Printer.Print("DIVISION REGIONAL      : ", ID_MEB_DVR_ITB.Text);

                PrinterHelper.Printer.FontBold = false;
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("NOMBRE                 : ", ID_MEB_NOM_EB.Text);
                PrinterHelper.Printer.Print("PUESTO                 : ", ID_MEB_PTO_EB.Text);
                PrinterHelper.Printer.Print("CALLE Y NUMERO         : ", ID_MEB_DOM_EB.Text);
                PrinterHelper.Printer.Print("COLONIA                : ", ID_MEB_COL_EB.Text);
                PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : ", ID_MEB_POB_EB.Text);
                PrinterHelper.Printer.Print("CIUDAD                 : ", ID_MEB_CIU_EB.Text);
                PrinterHelper.Printer.Print("ESTADO                 : ", ID_MEB_EDO_EB.Text);
                PrinterHelper.Printer.Print("C.P.                   : ", ID_MEB_CP_PIC.Text);
                PrinterHelper.Printer.Print("TELEFONO               : ", ID_MEB_TEL_PIC.Text);
                PrinterHelper.Printer.Print("EXTENSION              : ", ID_MEB_EXT_ITB.Text);
                PrinterHelper.Printer.Print("FAX                    : ", ID_MEB_FAX_PIC.Text);
                PrinterHelper.Printer.Print("FIRMA                  : ");

                int hDC = PrinterHelper.Printer.hDC;
                //AIS-1182 NGONZALEZ
                CORVAR.igblErr = API.GDI.SetMapMode(hDC, 6);

                ID_MEB_FIR_IMM.DebugLevel = 1;

                ID_MEB_FIR_IMM.SettingMode = GEAR.MODE_PRINTDRIVER;
                ID_MEB_FIR_IMM.SettingValue = 0;
                ID_MEB_FIR_IMM.PrintSize = GEAR.IG_PRINT_CUSTOM; //IG_PRINT_EIGHTH_PAGE 'IG_PRINT_SIXTEENTH_PAGE
                ID_MEB_FIR_IMM.PrintLeft = Convert.ToInt32(353.6d);
                ID_MEB_FIR_IMM.PrintTop = Convert.ToInt32(1541.9d);
                ID_MEB_FIR_IMM.PrintRight = Convert.ToInt32(1414.3d);
                ID_MEB_FIR_IMM.PrintBottom = Convert.ToInt32(2016.3d);

                //Print the image to the default printer
                ID_MEB_FIR_IMM.PrintImage = PrinterHelper.Printer.hDC;

                //End the print job
                PrinterHelper.Printer.EndDoc();
                //ATR
                //ID_MEB_FIR_IMM.PrnHdc = hDC
                //ID_MEB_FIR_IMM.DstLeft = (1 * IMG_TWIPS) + 1000
                //ID_MEB_FIR_IMM.DstTop = ((1 * IMG_TWIPS) + 2000) * (-1)
                //ID_MEB_FIR_IMM.DstRight = (3 * IMG_TWIPS) + 1000
                //ID_MEB_FIR_IMM.DstBottom = ((2 * IMG_TWIPS) + 2000) * (-1)

                //ID_MEB_FIR_IMM.DoPrint = 1

                //  Printer.EndDoc
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEB_IMP_PB_Click)", exc);

                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_MEB_NOM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "");
            // KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }



        private void ID_MEB_NOM_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        private void ID_MEB_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_ALTA)
                {
                    Realiza_alta();
                }
                else if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_CAMBIO)
                {
                    Realiza_cambio();
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEB_OK_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_MEB_POB_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "");
            //KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEB_PTO_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "");
            // KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void Llena_combo()
        {

            int iDivNum = 0;
            int iValor = 0;
            int hEjeBan = 0;
            int iError = 0;
            int bExiste = 0;
            string pszDescDiv = String.Empty;
            int igblEjxDivNum = 0;
            string pszTemp = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            //Obtiene los Campos de la tabla de Divisiones
            CORVAR.pszgblsql = "select * from " + CORBD.DB_SYB_DIV;

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iDivNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszDescDiv = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    pszTemp = pszDescDiv.Trim();
                    ID_MEB_DVR_ITB.Items.Add(StringsHelper.Format(iDivNum, "000") + " " + pszTemp);
                };
                if (ID_MEB_DVR_ITB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_MEB_DVR_ITB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }

            //Realiza fin de Query
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_ALTA)
            {
                ID_MEB_DVR_ITB.SelectedIndex = CORVB.NULL_INTEGER;
            }
            else
            {
                //Obtiene j
                CORVAR.pszgblsql = "select div_nom from " + CORBD.DB_SYB_DIV + " where div_num = " + Conversion.Str(CORVAR.igblTempEjxDiv);

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        pszDescDiv = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    }
                }

                //Realiza fin de Query
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                for (int iContador = CORVB.NULL_INTEGER; iContador <= (ID_MEB_DVR_ITB.Items.Count - 1); iContador++)
                {
                    if (VB6.GetItemString(ID_MEB_DVR_ITB, iContador) == StringsHelper.Format(CORVAR.igblTempEjxDiv, "000") + " " + pszDescDiv.Trim())
                    {
                        ID_MEB_DVR_ITB.SelectedIndex = iContador;
                    }
                }
            }

            this.Cursor = Cursors.Default;

        }

        private void Muestra_Datos()
        {

            int iError = 0;
            int hEjeBan = 0;
            int iValor = 0;

            string pszEjxPuesto = String.Empty;
            int igblEjxDivNum = 0;
            string pszEjxCalle = String.Empty;
            string szEjxCol = String.Empty;
            int lEjxCP = 0;
            string pszEjxCiu = String.Empty;
            string pszEjxPob = String.Empty;
            string pszEjxEdo = String.Empty;
            string pszEjxTel = String.Empty;
            string pszEjxExt = String.Empty;
            string pszEjxFax = String.Empty;
            string szEjxFirma = String.Empty;

            this.Cursor = Cursors.WaitCursor;


            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            CORVAR.pszgblsql = "select * from " + CORBD.DB_SYB_EJX + " where ejx_numero = " + Conversion.Str(CORVAR.lgblEjxCve);

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                //Obtiene Registro para consulta
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    CORVAR.lgblEjxCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    igblEjxDivNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                    CORVAR.szgblEjxDesc.Value = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    pszEjxPuesto = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                    pszEjxCalle = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                    szEjxCol = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                    lEjxCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7)));
                    pszEjxCiu = VBSQL.SqlData(CORVAR.hgblConexion, 8);
                    pszEjxPob = VBSQL.SqlData(CORVAR.hgblConexion, 9);
                    pszEjxEdo = VBSQL.SqlData(CORVAR.hgblConexion, 10);
                    pszEjxTel = VBSQL.SqlData(CORVAR.hgblConexion, 11);
                    pszEjxExt = VBSQL.SqlData(CORVAR.hgblConexion, 12);
                    pszEjxFax = VBSQL.SqlData(CORVAR.hgblConexion, 13);

                    ID_MEB_NOM_PIC.Text = StringsHelper.Format(CORVAR.lgblEjxCve, "0000000");
                    CORVAR.igblTempEjxDiv = igblEjxDivNum;
                    ID_MEB_NOM_EB.Text = CORVAR.szgblEjxDesc.Value.Trim();
                    ID_MEB_PTO_EB.Text = pszEjxPuesto.Trim();
                    ID_MEB_DOM_EB.Text = pszEjxCalle.Trim();
                    ID_MEB_COL_EB.Text = szEjxCol.Trim();
                    ID_MEB_CP_PIC.Text = StringsHelper.Format(lEjxCP, "00000");
                    ID_MEB_CIU_EB.Text = pszEjxCiu.Trim();
                    ID_MEB_POB_EB.Text = pszEjxPob.Trim();
                    CRSGeneral.prBuscaEstado(ID_MEB_EDO_EB, pszEjxEdo.Trim());
                    ID_MEB_TEL_PIC.Text = pszEjxTel.Trim();
                    ID_MEB_EXT_ITB.Text = pszEjxExt.Trim();
                    ID_MEB_FAX_PIC.Text = pszEjxFax.Trim();
                }
            }

            //Realiza fin de Query
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

        }

        private void Realiza_alta()
        {

            int hEjeBan = 0;
            int iError = 0;
            int iRegistros = 0;

            string pszEjxFirma = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            //Inicializa variable que indica si ya existe la clave
            int bExiste = 0;

            CORVAR.lgblEjxCve = Convert.ToInt32(Conversion.Val(ID_MEB_NOM_PIC.Text));

            //Verifica ya existe la clave accesada
            for (int iContador = 0; iContador <= CORCTEJB.DefInstance.ID_CEB_EJE_LB.Items.Count - 1; iContador++)
            {
                if (Conversion.Val(Strings.Mid(VB6.GetItemString(CORCTEJB.DefInstance.ID_CEB_EJE_LB, iContador), 1, 7)) == CORVAR.lgblEjxCve)
                {
                    bExiste = -1;
                }
            }

            if (~Valida_Campos() != 0)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            int igblEjxDivNum = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_MEB_DVR_ITB.Text, 1, 3)));
            CORVAR.pszgblEjxDesc = ID_MEB_NOM_EB.Text.Trim();
            string pszEjxPuesto = ID_MEB_PTO_EB.Text.Trim();
            string pszEjxCalle = ID_MEB_DOM_EB.Text.Trim();
            string pszEjxCol = ID_MEB_COL_EB.Text.Trim();
            int lEjxCP = Convert.ToInt32(Conversion.Val(ID_MEB_CP_PIC.Text));
            string pszEjxCiu = ID_MEB_CIU_EB.Text.Trim();
            string pszEjxPob = ID_MEB_POB_EB.Text.Trim();
            string pszEjxEdo = CRSGeneral.asgEstados[0, ID_MEB_EDO_EB.SelectedIndex];
            string pszEjxTel = ID_MEB_TEL_PIC.Text.Trim();
            string pszEjxExt = ID_MEB_EXT_ITB.Text.Trim();
            string pszEjxFax = ID_MEB_FAX_PIC.Text.Trim();

            if (CORVAR.bgblModFirma != 0)
            {
                pszEjxFirma = "0x00";
            }

            if (bExiste != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("La clave capturada ya existe en catálogos", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                bExiste = 0;
                return;
            }


            //Da de alta los datos dentro de la tabla de Ejecutivos Banamex
            CORVAR.pszgblsql = "INSERT " + CORBD.DB_SYB_EJX + " VALUES (";
            CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(CORVAR.lgblEjxCve) + "," + Conversion.Str(igblEjxDivNum) + ",'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + CORPROC.Valida_Comilla(CORVAR.pszgblEjxDesc) + "','" + CORPROC.Valida_Comilla(pszEjxPuesto);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "','" + CORPROC.Valida_Comilla(pszEjxCalle) + "','";
            CORVAR.pszgblsql = CORVAR.pszgblsql + CORPROC.Valida_Comilla(pszEjxCol) + "'," + Conversion.Str(lEjxCP) + ",'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + CORPROC.Valida_Comilla(pszEjxCiu) + "','" + CORPROC.Valida_Comilla(pszEjxPob);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "','" + CORPROC.Valida_Comilla(pszEjxEdo) + "','" + pszEjxTel + "','";
            CORVAR.pszgblsql = CORVAR.pszgblsql + pszEjxExt + "','" + pszEjxFax + "'," + pszEjxFirma + ")";

            if (CORPROC2.Modifica_Registro() != 0)
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //cierra la accipón del query anterior

                if (CORVAR.bgblModFirma != 0)
                {
                    pszEjxFirma = Guarda_firma();
                }

                this.Close();
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("El Ejecutivo no pudo ser dado de ALTA.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

        }

        private void Realiza_cambio()
        {

            int hEjeBan = 0;
            int iError = 0;
            FixedLengthString szChar = new FixedLengthString(1);

            string pszEjxFirma = String.Empty;

            if (~Valida_Campos() != 0)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            CORVAR.lgblEjxCve = Convert.ToInt32(Conversion.Val(ID_MEB_NOM_PIC.Text));
            string pszDivDesc = ID_MEB_DVR_ITB.Text;
            string pszEjxDesc = ID_MEB_NOM_EB.Text.Trim();
            string pszEjxPuesto = ID_MEB_PTO_EB.Text.Trim();
            string pszEjxCalle = ID_MEB_DOM_EB.Text.Trim();
            string pszEjxCol = ID_MEB_COL_EB.Text.Trim();
            int lEjxCP = Convert.ToInt32(Conversion.Val(ID_MEB_CP_PIC.Text));
            string pszEjxCiu = ID_MEB_CIU_EB.Text.Trim();
            string pszEjxPob = ID_MEB_POB_EB.Text.Trim();
            string pszEjxEdo = CRSGeneral.asgEstados[0, ID_MEB_EDO_EB.SelectedIndex];
            string pszEjxTel = ID_MEB_TEL_PIC.Text;
            string pszEjxExt = ID_MEB_EXT_ITB.Text;
            string pszEjxFax = ID_MEB_FAX_PIC.Text;

            this.Cursor = Cursors.WaitCursor;

            VB6.SetItemString(CORCTEJB.DefInstance.ID_CEB_EJE_LB, ListBoxHelper.GetSelectedIndex(CORCTEJB.DefInstance.ID_CEB_EJE_LB), Strings.Mid(VB6.GetItemString(CORCTEJB.DefInstance.ID_CEB_EJE_LB, ListBoxHelper.GetSelectedIndex(CORCTEJB.DefInstance.ID_CEB_EJE_LB)), 1, 10) + ID_MEB_NOM_EB.Text.Trim());

            int igblEjxDivNum = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_MEB_DVR_ITB.Text, 1, 3)));

            //Obtiene los campos de la tabla de Divisiones Regionales
            CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EJX + " set ejx_numero = " + Conversion.Str(CORVAR.lgblEjxCve);
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",div_num = " + Conversion.Str(igblEjxDivNum);
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",ejx_nombre = '" + CORPROC.Valida_Comilla(pszEjxDesc);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "',ejx_puesto = '" + CORPROC.Valida_Comilla(pszEjxPuesto);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "',ejx_calle = '" + CORPROC.Valida_Comilla(pszEjxCalle);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "',ejx_col = '" + CORPROC.Valida_Comilla(pszEjxCol);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "',ejx_cp = " + Conversion.Str(lEjxCP);
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", ejx_ciu = '" + CORPROC.Valida_Comilla(pszEjxCiu);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "',ejx_pob = '" + CORPROC.Valida_Comilla(pszEjxPob);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "',ejx_edo ='" + CORPROC.Valida_Comilla(pszEjxEdo);
            CORVAR.pszgblsql = CORVAR.pszgblsql + "',ejx_tel = '" + pszEjxTel + "',ejx_ext = '" + pszEjxExt;
            CORVAR.pszgblsql = CORVAR.pszgblsql + "',ejx_fax = '" + pszEjxFax;
            CORVAR.pszgblsql = CORVAR.pszgblsql + "' where ejx_numero = " + Conversion.Str(CORVAR.lgblEjxCve);


            if (CORPROC2.Modifica_Registro() != 0)
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                if (CORVAR.bgblModFirma == (-1))
                {
                    pszEjxFirma = Guarda_firma();
                }

                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Se modifico el registro.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No se pudo registrar la modificación.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            CORVAR.lgblTempEjxCve = CORVAR.lgblEjxCve;

            this.Cursor = Cursors.Default;

            this.Close();

        }

        private int Valida_Campos()
        {


            int result = 0;
            this.Cursor = Cursors.WaitCursor;

            string pszCampo = CORVB.NULL_STRING;

            //Verifica si se ha ingresado la clave
            if (Conversion.Val(ID_MEB_NOM_PIC.Text) == CORVB.NULL_INTEGER)
            {
                pszCampo = "Nómina";
                ID_MEB_NOM_PIC.Focus();
            }
            else if ((ID_MEB_NOM_EB.Text.Trim() == CORVB.NULL_STRING))
            {
                pszCampo = "Nombre";
                ID_MEB_NOM_EB.Focus();
            }
            else if ((ID_MEB_DOM_EB.Text.Trim() == CORVB.NULL_STRING))
            {
                pszCampo = "Domicilio";
                ID_MEB_DOM_EB.Focus();
            }
            else if ((ID_MEB_COL_EB.Text.Trim() == CORVB.NULL_STRING))
            {
                pszCampo = "Colonia";
                ID_MEB_COL_EB.Focus();
            }
            else if ((ID_MEB_POB_EB.Text.Trim() == CORVB.NULL_STRING))
            {
                pszCampo = "Poblacion";
                ID_MEB_POB_EB.Focus();
            }
            else if ((ID_MEB_CIU_EB.Text.Trim() == CORVB.NULL_STRING))
            {
                pszCampo = "Ciudad";
                ID_MEB_CIU_EB.Focus();
            }
            else if ((ID_MEB_EDO_EB.SelectedIndex < 0))
            {
                pszCampo = "Estado";
                ID_MEB_EDO_EB.Focus();
            }
            else if ((Conversion.Val(ID_MEB_CP_PIC.Text) == CORVB.NULL_INTEGER))
            {
                pszCampo = "Codigo Postal";
                ID_MEB_CP_PIC.Focus();
            }
            else if ((ID_MEB_TEL_PIC.Text.Trim() == CORVB.NULL_STRING))
            {
                pszCampo = "Teléfono";
                ID_MEB_TEL_PIC.Focus();
            }
            else if (CORVAR.bgblModFirma == (0) && this.Tag.ToString() == CORCONST.TAG_ALTA)
            {
                pszCampo = "Firma";
                ID_MEB_FIR_PB.Focus();
            }

            if (pszCampo.Length != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Falta por capturar el campo : " + pszCampo.ToUpper(), (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                result = 0;
            }
            else
            {
                result = -1;
            }

            this.Cursor = Cursors.Default;

            return result;
        }



        private void ID_MEB_TEL_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        public void SetEnable_ID_MEB_PPL1(bool enable)
        {
            ID_MEB_NOM_PIC.Enabled = enable;
            ID_MEB_DVR_ITB.Enabled = enable;

        }

        public void SetEnable_ID_MEB_PPL2_PNL(bool enable)
        {
            ID_MEB_NOM_EB.Enabled = enable;
            ID_MEB_PTO_EB.Enabled = enable;
            ID_MEB_DOM_EB.Enabled = enable;
            ID_MEB_COL_EB.Enabled = enable;
            ID_MEB_POB_EB.Enabled = enable;
            ID_MEB_CIU_EB.Enabled = enable;
            ID_MEB_EDO_EB.Enabled = enable;
            ID_MEB_CP_PIC.Enabled = enable;
            ID_MEB_EXT_ITB.Enabled = enable;
            ID_MEB_TEL_PIC.Enabled = enable;
            ID_MEB_FAX_PIC.Enabled = enable;
            ID_MEB_FIR_PB.Enabled = enable;

        }

        private void ID_MEB_CP_PIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            int KeyAscii = (int)e.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != CORVB.KEY_BACK)
            {
                e.KeyChar = (char)0;
            }
        }

        private void ID_MEB_EXT_ITB_KeyPress(object sender, KeyPressEventArgs e)
        {
            int KeyAscii = (int)e.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != CORVB.KEY_BACK)
            {
                e.KeyChar = (char)0;
            }
        }

        private void ID_MEB_TEL_PIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            int KeyAscii = (int)e.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != CORVB.KEY_BACK)
            {
                e.KeyChar = (char)0;
            }
        }

        private void ID_MEB_FAX_PIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            int KeyAscii = (int)e.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != CORVB.KEY_BACK)
            {
                e.KeyChar = (char)0;
            }
        }

        private void ID_MEB_NOM_PIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            int KeyAscii = (int)e.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != CORVB.KEY_BACK)
            {
                e.KeyChar = (char)0;
            }
        }
    }
}
