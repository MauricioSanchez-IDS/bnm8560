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
using Softtek.Utils.Win.Spread;

namespace TCd430
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


        public enum spdTipoCelda { CeldaTexto = 1,
                                   CeldaNumero = 3,
                                   CeldaLectura = 5,
                                   CeldaBoton = 7,
                                   CeldaCheckBox = 10 };

        //'Define las propiedades de los encabezados del SpreedSheet
        public struct tpSpdSucursal
        {
            public spdTipoCelda TipoCelda;
            public string Encabezado;
            public int Tamano;
            public int IdColumna;
        }

        //'Identificadores de los campos a presentar en el spreedsheet
        const int COL_NO_SUCURSAL = 0;                       //'Identificador de la columna No. Sucursal
        const int COL_DESC_SUCURSAL = 1;                     //'Identificador de la columna Descripcion
        const int COL_ESTATUS_SUCURSAL = 2;                  //'Identificador de la columna Status_Sucursal

        const string CLAVE_YA_EXISTE = "La clave que ingresó ya existe";
        const string NO_ALTA_DATO = "Falta por capturar el campo ";
        private Collection ColSucursal;                 //'Colexion que almacenará las sucursales que han sufrido un cambio
        private clsSucursal ObjSucursal;                //'Objeto que define las propiedades de la sucursal
        private bool errAsignarObjeto;                  //'Valor que nos indicará si hubo un error al asignar los valores del objeto sucursal
        tpSpdSucursal[] tpTitulosSpd = new tpSpdSucursal[3]; //'Arreglo en el que se almacenan las propiedades de las celdas del spreadsheet

        int bAltaFirma = 0;
        int hConexion = 0;

        FarPoint.Win.Spread.CellType.TextCellType TextCellType = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.NumberCellType NumberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.CurrencyCellType CurrCellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
        FarPoint.Win.Spread.CellType.CheckBoxCellType CheckBoxCellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
        FarPoint.Win.Spread.CellType.DateTimeCellType DateCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();

        object sender1;
        FarPoint.Win.Spread.LeaveCellEventArgs e1;


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
                        Muestra_Datos(false);
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
                    Muestra_Datos(true);
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
            ColSucursal = new Collection();

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

            PrInicializaSpd(true);

            this.Cursor = Cursors.Default;

        }


        private void CORMNEJB_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
        {
            int Cancel = (eventArgs.Cancel) ? 1 : 0;
            int UnloadMode = (int)eventArgs.CloseReason;

            //Verifica si la forma se cerró por el Control Menú
            //if (eventArgs.CloseReason == CloseReason.UserClosing)
            //{
            //    CORVAR.bgblEjxActiva = -1;
            //}

            eventArgs.Cancel = Cancel != 0;
        }

        private void CORMNEJB_Closed(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //Yuria 19/05/09 modifica
                //File.Delete(CORVAR.pszgblPathFirmas + "firma.pcx");
                //ver en la forma CORALTFI.CS
                //en la función ID_FIR_GUA_PB_Click
                //se corrigió:
                //ID_FIR_OK_IMM.SaveImage = CORVAR.pszgblPathFirmas + "firmaa.pcx";
                File.Delete(CORVAR.pszgblPathFirmas + "firmaa.pcx");

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


                //File.Delete(CORVAR.pszgblPathFirmas + "firma.pcx");
                //Yuria 19/05/09 modifica el nombre del archivo firma
                // ver en la forma CORALTFI.CS
                //en la función ID_FIR_GUA_PB_Click
                //se corrigió:
                //ID_FIR_OK_IMM.SaveImage = CORVAR.pszgblPathFirmas + "firmaa.pcx"; 
                File.Delete(CORVAR.pszgblPathFirmas + "firmaa.pcx");

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
                //ID_MEB_FIR_IMM.LoadImage = CORVAR.pszgblPathFirmas + "firma.pcx";
                //Yuria 19/05/09 Modifica
                // ver en la forma CORALTFI.CS
                //en la función ID_FIR_GUA_PB_Click
                //se corrigió:
                //ID_FIR_OK_IMM.SaveImage = CORVAR.pszgblPathFirmas + "firmaa.pcx";
                ID_MEB_FIR_IMM.LoadImage = CORVAR.pszgblPathFirmas + "firmaa.pcx";
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

            int lngSucursales;

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

                if (FnActualizaColSucursal())
                {
                    for (lngSucursales = 1; lngSucursales <= ColSucursal.Count; lngSucursales++)
                    {
                        ObjSucursal = (clsSucursal)ColSucursal[lngSucursales];
                        PrinterHelper.Printer.Print(String.Format(ObjSucursal.IdSucursal.ToString(), "@@@@@"));
                        PrinterHelper.Printer.Print(ObjSucursal.Descripcion);
                        PrinterHelper.Printer.Print(ObjSucursal.Status);
                    }

                }


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

        private void Muestra_Datos(bool mBolConsulta)
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
                    FnLeeSucursales(CORVAR.lgblEjxCve, mBolConsulta);

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

            //string pszEjxEdo = CRSGeneral.asgEstados[0, ID_MEB_EDO_EB.SelectedIndex];
            string pszEjxEdo;
            if (ID_MEB_EDO_EB.SelectedIndex > -1 )
            { pszEjxEdo = CRSGeneral.asgEstados[0, ID_MEB_EDO_EB.SelectedIndex]; }
            else
            { pszEjxEdo = ""; }

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

            if (pszEjxFirma.Trim() == "")
            { pszEjxFirma = "'0x0'"; }

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

                if (FnActualizaSucursal(CORVAR.lgblEjxCve))
                {
                    MdlCambioMasivo.MsgInfo("Ejecutivo " + CORVAR.lgblEjxCve + " Actualizado Exitosamente ");
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

                FnActualizaSucursal(CORVAR.lgblEjxCve);

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
            //else if ((ID_MEB_DOM_EB.Text.Trim() == CORVB.NULL_STRING))
            //{
            //    pszCampo = "Domicilio";
            //    ID_MEB_DOM_EB.Focus();
            //}
            //else if ((ID_MEB_COL_EB.Text.Trim() == CORVB.NULL_STRING))
            //{
            //    pszCampo = "Colonia";
            //    ID_MEB_COL_EB.Focus();
            //}
            //else if ((ID_MEB_POB_EB.Text.Trim() == CORVB.NULL_STRING))
            //{
            //    pszCampo = "Poblacion";
            //    ID_MEB_POB_EB.Focus();
            //}
            //else if ((ID_MEB_CIU_EB.Text.Trim() == CORVB.NULL_STRING))
            //{
            //    pszCampo = "Ciudad";
            //    ID_MEB_CIU_EB.Focus();
            //}
            //else if ((ID_MEB_EDO_EB.SelectedIndex < 0))
            //{
            //    pszCampo = "Estado";
            //    ID_MEB_EDO_EB.Focus();
            //}
            //else if ((Conversion.Val(ID_MEB_CP_PIC.Text) == CORVB.NULL_INTEGER))
            //{
            //    pszCampo = "Codigo Postal";
            //    ID_MEB_CP_PIC.Focus();
            //}
            //else if ((ID_MEB_TEL_PIC.Text.Trim() == CORVB.NULL_STRING))
            //{
            //    pszCampo = "Teléfono";
            //    ID_MEB_TEL_PIC.Focus();
            //}
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

        private void SpdSucursales_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            ObjSucursal = FnAsignaSpdSucursal("K_" + (e.Row + 1));
            if (e.GetButtonDown() == 1)
            {
                ObjSucursal.Status = "S";
            }
            else
            {
                ObjSucursal.Status = "N";
            }
        }

        private void SpdSucursales_EditModeEvent(object sender, EventArgs e)
        {
            //'Establece las propiedades de edicion del renglon actual
            object strIdSucursal;
            object strDescripcionSucursal;
            int intEncabezados;

            //APQ 28-Ene-2016
            object mStrDescSucursal;
            object mStrIdSucursal;
            object mStrStatusSucusal;
            mStrDescSucursal = "";
            mStrIdSucursal = null;

            ObjSucursal = FnAsignaSpdSucursal("K_" + SpdSucursales.ActiveRow);
            Application.DoEvents();
            SpdSucursales.GetText((COL_NO_SUCURSAL + 1), SpdSucursales.ActiveRow, ref mStrIdSucursal);
            SpdSucursales.GetText((COL_DESC_SUCURSAL + 1), SpdSucursales.ActiveRow, ref mStrDescSucursal);

            ObjSucursal.IdSucursal = Convert.ToInt32(Conversion.Val(mStrIdSucursal));
            ObjSucursal.Descripcion = mStrDescSucursal.ToString();

            //APQ 28-Ene-2016
        }


        //'************************************************************
        //'*Objetivo: Actualiza la colexion de sucursales
        //'*Elaboro: Clemente Muñoz
        //'*Fecha: 15/Jun/2004
        //'
        //'************************************************************

        private bool FnActualizaColSucursal()
        {
            try
            {
                object strIdSucursal;
                object strDescripcionSucursal;
                object strStatus;

                int LngRows;

                if (errAsignarObjeto)
                { return false; }

                errAsignarObjeto = false;
                strIdSucursal = null;
                strDescripcionSucursal = null;
                strStatus = null;
                ColSucursal = null;
                ColSucursal = new Collection();

                for (LngRows = 1; LngRows < SpdSucursales.MaxRows; LngRows++)
                {
                    SpdSucursales.GetText((COL_NO_SUCURSAL + 1), LngRows, ref strIdSucursal);
                    SpdSucursales.GetText((COL_DESC_SUCURSAL + 1), LngRows, ref strDescripcionSucursal);
                    SpdSucursales.GetText((COL_ESTATUS_SUCURSAL + 1), LngRows, ref strStatus);
                    if (strIdSucursal.ToString() == "")
                    { strIdSucursal = "0"; }
                    if (strIdSucursal.ToString() != "0")
                    {
                        ObjSucursal = new clsSucursal();
                        ObjSucursal.IdSucursal = Convert.ToInt32(strIdSucursal.ToString());
                        ObjSucursal.Descripcion = strDescripcionSucursal.ToString();
                        if (strStatus.ToString() == "1")
                        {
                            ObjSucursal.Status = "S";
                        }
                        else
                        {
                            ObjSucursal.Status = "N";
                        }
                        ColSucursal.Add(ObjSucursal, "K_" + ObjSucursal.IdSucursal, null, null);
                    }
                }
                return true;

            }
            catch
            {
                errAsignarObjeto = true;

                if (Information.Err().Number == 457)
                {
                    MdlCambioMasivo.MsgError("La sucursal: " + ObjSucursal.IdSucursal + ".- " + ObjSucursal.Descripcion + "\r\n" + "Esta duplicada" + "\r\n" + "Modifique para corregir el error ");
                }
                else
                {
                    MdlCambioMasivo.MsgError("No Error: " + Information.Err().Number + "\r\n" + "Descripción:" + Information.Err().Description);
                }
                Information.Err().Clear();
                errAsignarObjeto = false;
                return false;
            }
        }

        private void CargaAtributosCeldas()
        {
            int intEncabezados;

            //APQ 28-Ene-2016

            for (intEncabezados = 0; intEncabezados < 3; intEncabezados++)
            {
                SpdSucursales.Row = SpdSucursales.ActiveRow;  //e.row;
                SpdSucursales.Col = intEncabezados + 1;

                switch (tpTitulosSpd[intEncabezados].IdColumna)
                {
                    case COL_NO_SUCURSAL:
                        if (SpdSucursales.CellType != TextCellType)
                        //if (SpdSucursales.CellType != NumberCellType)
                        {
                            //SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                            SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.TextCellType();

                            //SpdSucursales.CellType = NumberCellType;
                            SpdSucursales.CellType = TextCellType;
                            SpdSucursales.TypeIntegerMin = 0;
                            SpdSucursales.TypeIntegerMax = 9999;
                            SpdSucursales.TypeMaxEditLen = 4;
                        }
                        break;
                    case COL_DESC_SUCURSAL:
                        switch (Convert.ToInt16(tpTitulosSpd[intEncabezados].TipoCelda))
                        {
                            case 1:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
                                break;
                            case 3:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                                //SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                                break;
                            case 5:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                                break;
                            case 8:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                                break;
                            case 10:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                                break;
                            default:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                                break;
                        }
                        break;
                    case COL_ESTATUS_SUCURSAL:                   //'Identificador de la columna Status_Sucursal
                        if (SpdSucursales.ActiveColumn != COL_ESTATUS_SUCURSAL)
                        {
                            switch (Convert.ToInt16(tpTitulosSpd[intEncabezados].TipoCelda))
                            {
                                case 1:
                                    SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
                                    break;
                                case 3:
                                    SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                                    //SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                                    break;
                                case 5:
                                    SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                                    break;
                                case 8:
                                    SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                                    break;
                                case 10:
                                    {
                                     SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                                     ObjSucursal = FnAsignaSpdSucursal("K_" + SpdSucursales.Row);
                                     //SpdSucursales.Value = "1";
                                     if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_ALTA)
                                     { 
                                        ObjSucursal.Status = "S";
                                        SpdSucursales.Value = true; 
                                     }
                                     else if (CORMNEJB.DefInstance.Tag.ToString() == CORCONST.TAG_CAMBIO)
                                     {
                                         if (ObjSucursal.Status == "S")
                                         { SpdSucursales.Value = true; }
                                         else
                                         { SpdSucursales.Value = false; }
                                     }
                                     break;
                                    }
                                default:
                                    SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                                    break;
                            }

                        }
                        break;
                }
            }

        }

        //'************************************************************
        //'*Objetivo: Define las propiedades del SpdSheet
        //'*Elaboro: Clemente Muñoz
        //'*Fecha: 15/Jun/2004
        //'Parametros:bolEditMode .- Define el modo de edicion del SpreadSheet
        //'
        //'************************************************************
        private void PrInicializaSpd(bool bolEditMode)
        {
            int intEncabezados;
            //'*********** Inicializa el arreglo con la definición de las propiedades de cada celda
            tpTitulosSpd[COL_NO_SUCURSAL].Encabezado = "No. Sucursal";
            tpTitulosSpd[COL_NO_SUCURSAL].IdColumna = COL_NO_SUCURSAL;
            //tpTitulosSpd[COL_NO_SUCURSAL].TipoCelda = (spdTipoCelda)spdTipoCelda.CeldaLectura;
            //tpTitulosSpd[COL_NO_SUCURSAL].TipoCelda = (spdTipoCelda)spdTipoCelda.CeldaNumero;
            tpTitulosSpd[COL_NO_SUCURSAL].TipoCelda = (spdTipoCelda)spdTipoCelda.CeldaTexto;
            tpTitulosSpd[COL_NO_SUCURSAL].Tamano = tpTitulosSpd[COL_NO_SUCURSAL].Encabezado.Length + 1;

            tpTitulosSpd[COL_DESC_SUCURSAL].Encabezado = "Descripcion";
            tpTitulosSpd[COL_DESC_SUCURSAL].IdColumna = COL_DESC_SUCURSAL;
            tpTitulosSpd[COL_DESC_SUCURSAL].TipoCelda = (spdTipoCelda)spdTipoCelda.CeldaTexto;
            tpTitulosSpd[COL_DESC_SUCURSAL].Tamano = 30;

            tpTitulosSpd[COL_ESTATUS_SUCURSAL].Encabezado = "Activa";
            tpTitulosSpd[COL_ESTATUS_SUCURSAL].IdColumna = COL_ESTATUS_SUCURSAL;
            tpTitulosSpd[COL_ESTATUS_SUCURSAL].TipoCelda = (spdTipoCelda)spdTipoCelda.CeldaCheckBox;
            tpTitulosSpd[COL_ESTATUS_SUCURSAL].Tamano = 10;

            if (String.Empty.Equals(bolEditMode))
            {
                bolEditMode = true;
            }

            SpdSucursales.MaxCols = tpTitulosSpd.GetUpperBound(0) + 1;
            SpdSucursales.MaxRows = 0;
            //'Define que cuando se pulse la tecla enter el control se movera a la siguiente celda
            //int EditEnterActionNext = 5;
            //SpdSucursales.EditEnterAction = EditEnterActionNext;

            //SpdSucursales.EditMode = bolEditMode;
            //for (intEncabezados = tpTitulosSpd.GetLowerBound(0); intEncabezados = tpTitulosSpd.GetUpperBound(0); intEncabezados++)
            for (intEncabezados = 0; intEncabezados < 3; intEncabezados++)
            {
                //'Define los titulos de cada columa asi como su ancho
                SpdSucursales.Row = 0;
                SpdSucursales.Col = intEncabezados + 1;
                SpdSucursales.Text = tpTitulosSpd[intEncabezados].Encabezado;
                SpdSucursales.set_ColWidth(intEncabezados + 1, tpTitulosSpd[intEncabezados].Tamano*8);
                //SpdSucursales.ProcessTab = true; Comentado en Remediación
            }
            SpdSucursales.MaxRows = 1;

            CargaAtributosCeldas();

            object mStrDescSucursal;
            object mStrIdSucursal;
            object mStrStatusSucusal;
            mStrDescSucursal = "";
            mStrIdSucursal = null;
            SpdSucursales.Row = 1;

            ObjSucursal = FnAsignaSpdSucursal("K_" + SpdSucursales.Row);
            Application.DoEvents();
            SpdSucursales.GetText((COL_NO_SUCURSAL + 1), SpdSucursales.Row, ref mStrIdSucursal);
            SpdSucursales.GetText((COL_DESC_SUCURSAL + 1), SpdSucursales.Row, ref mStrDescSucursal);

            ObjSucursal.IdSucursal = Convert.ToInt32(Conversion.Val(mStrIdSucursal));
            ObjSucursal.Descripcion = mStrDescSucursal.ToString();
            //APQ 28-Ene-2016

        }

        //'************************************************************
        //'*Objetivo: Actualiza en la base de datos la tabla MTCSUC01
        //'*Elaboro: Clemente Muñoz
        //'*Fecha: 15/Jun/2004
        //'*Parametros:intEjexNumero.- Define el ejecutivo al que se le asignará las sucursales
        //'*Valor devuelto: True en caso de que el cambio se logre aplicar
        //'*                False en caso contrario
        //'************************************************************
        private bool FnActualizaSucursal(int intEjexNumero)
        {
            try
            {
                int intSucursales;

                for (intSucursales = 1; intSucursales < (ColSucursal.Count + 1); intSucursales++)
                {
                    ObjSucursal = (clsSucursal)ColSucursal[intSucursales];
                    if (ObjSucursal.IdSucursal != 0)
                    {
                        CORVAR.pszgblsql = "If not exists (Select sucursal_numero from MTCSUC01 " +
                                        "               Where ejx_numero         = " + intEjexNumero +
                                                        "     and sucursal_numero= " + ObjSucursal.IdSucursal + " )" + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "Begin" + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "   INSERT INTO MTCSUC01 (ejx_numero," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "   sucursal_numero," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "   sucursal_descripcion," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "   usuario_cambio," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "   sucursal_status) " + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "   values (" + intEjexNumero + "," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "            " + ObjSucursal.IdSucursal + "," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "            '" + ObjSucursal.Descripcion + "'," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "            '" + CRSParametros.sgUserID + "'," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "            '" + ObjSucursal.Status + "')" + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "End" + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "Else" + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "begin" + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "   update MTCSUC01 set sucursal_descripcion = '" + ObjSucursal.Descripcion + "'," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "            usuario_cambio='" + CRSParametros.sgUserID + "'," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "            fecha_cambio= getdate()," + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "            sucursal_status='" + ObjSucursal.Status + "'" + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "   Where ejx_numero = " + intEjexNumero + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "     And sucursal_numero = " + ObjSucursal.IdSucursal + "\r\n";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "end";

                        CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
                        CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);

                        if (CORVAR.igblRetorna == VBSQL.SUCCEED)
                        {
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                        else
                        {
                            Information.Err().Raise(-10, null, "Error al actualizar la sucursal:  " + ObjSucursal.IdSucursal, null, null);
                        }
                    }
                }
                return true;
            }
            catch
            {
                MdlCambioMasivo.MsgError(Information.Err().Description);
                return false;
            }
        }

        //'************************************************************
        //'*Objetivo: Actualiza el contenido del SpreadSheet con los valores de las sucursales
        //'*          Existentes en la base de datos
        //'*Elaboro: Clemente Muñoz
        //'*Fecha: 15/Jun/2004
        //'*Parametros:intEjexNum.- Define el ejecutivo al que se desea consultar
        //'*         bolConsulta .- Define si el SpreadSheet es uncamente de lectura o no
        //'*         si bolConsulta = true significa que es unicamente de lectura
        //'*         en caso contrario el spread será unicamente de lectura
        //'*Valor devuelto: True en caso de que el cambio se logre aplicar
        //'*                False en caso contrario
        //'************************************************************

        private bool FnLeeSucursales(int intEjexNum, bool bolConsulta)
        {
            int intColumna;

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            CORVAR.pszgblsql = "select sucursal_numero, sucursal_descripcion,sucursal_status from MTCSUC01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " Where ejx_numero= " + intEjexNum;

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    for (intColumna = 1; intColumna < (SpdSucursales.MaxCols + 1); intColumna++)
                    {
                        SpdSucursales.Col = intColumna;
                        SpdSucursales.Row = SpdSucursales.MaxRows;
                        switch (Convert.ToInt16(tpTitulosSpd[intColumna - 1].TipoCelda))
                        {
                            case 1:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
                                break;
                            case 3:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                                //SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                                break;
                            case 5:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.CurrencyCellType();
                                break;
                            case 8:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                                break;
                            case 10:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                                break;
                            default:
                                SpdSucursales.CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                                break;
                        }

                        if (tpTitulosSpd[intColumna - 1].TipoCelda == spdTipoCelda.CeldaCheckBox)
                        {
                            //SpdSucursales.Value = Math.Abs(VBSQL.SqlData(CORVAR.hgblConexion, intColumna) = "S");
                            if ((VBSQL.SqlData(CORVAR.hgblConexion, intColumna) == "S"))
                            {
                                //SpdSucursales.Value = "1";
                                SpdSucursales.Value = true;
                                ObjSucursal.Status = "S";

                            }
                            else
                            {
                                //SpdSucursales.Value = "0";
                                SpdSucursales.Value = false;
                                ObjSucursal.Status = "N";

                            }
                            ObjSucursal = FnAsignaSpdSucursal("K_" + SpdSucursales.Row);
                        }
                        else
                        {
                            SpdSucursales.Value = VBSQL.SqlData(CORVAR.hgblConexion, intColumna);
                        }
                    }
                    SpdSucursales.MaxRows = SpdSucursales.MaxRows + 1;
                }
                if (bolConsulta)
                {
                    //'Determina si el spd es unicamente de consulta
                    SpdSucursales.Col = -1;
                    SpdSucursales.Col2 = -1;
                    SpdSucursales.Row = -1;
                    SpdSucursales.Row2 = -1;
                    //SpdSucursales.EditMode = false;
                    SpdSucursales.Lock = true;
                    SpdSucursales.Protect = true;
                }
                return true;
            }
            else
            { return false; }
        }

        private void SpdSucursales_KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            if (SpdSucursales.ActiveColumn == (COL_DESC_SUCURSAL + 1))
            {
                int KeyAscii = (int)e.KeyChar;
                CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "");
            }
        
        }

        private void SpdSucursales_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            object  mStrDescSucursal;
            object mStrIdSucursal;
            object mStrStatusSucusal;
            mStrDescSucursal = "";
            mStrIdSucursal = null;

            //ObjSucursal = FnAsignaSpdSucursal("K_" + e.Row);
            ObjSucursal = FnAsignaSpdSucursal("K_" + SpdSucursales.ActiveRow);
            Application.DoEvents();
            //SpdSucursales.GetText((COL_NO_SUCURSAL + 1), e.Row, ref mStrIdSucursal);
            //SpdSucursales.GetText((COL_DESC_SUCURSAL + 1), e.Row, ref mStrDescSucursal);
            SpdSucursales.GetText((COL_NO_SUCURSAL + 1), SpdSucursales.ActiveRow, ref mStrIdSucursal);
            SpdSucursales.GetText((COL_DESC_SUCURSAL + 1), SpdSucursales.ActiveRow, ref mStrDescSucursal);

            ObjSucursal.IdSucursal = Convert.ToInt32(Conversion.Val(mStrIdSucursal));
            ObjSucursal.Descripcion = mStrDescSucursal.ToString();

            if (ObjSucursal.IdSucursal != 0 && ObjSucursal.Descripcion != "" && ObjSucursal.Status != "")
            {
                SpdSucursales.MaxRows = SpdSucursales.MaxRows + 1;
                CargaAtributosCeldas();
            }

            Application.DoEvents();
        }

        private clsSucursal FnAsignaSpdSucursal(string strItem)
        {
            clsSucursal mObjSucursal;
            mObjSucursal = null;


            if (!ColSucursal.Contains(strItem))
            {
                mObjSucursal = new clsSucursal();
                ColSucursal.Add(mObjSucursal, strItem, null, null);
            }
            else
            {
                mObjSucursal = (clsSucursal)ColSucursal[strItem];
            }
            return mObjSucursal;
        }

        private void fpsSucursales_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

    }
}
