//AIS-1070 NGONZALEZ
using Artinsoft.VB6.Gui;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORREGFI
        : System.Windows.Forms.Form
    {



        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Registro de las firmas de los catalogos de Empresa  **
        //**                    Se graban las firmas de los representantes de la    **
        //**                    empresa                                             **
        //**                                                                        **
        //**       Responsable: Felipe Zacarias Jimenez                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int bDirty = 0;
        int bModifFirma1 = 0;
        int bModifFirma2 = 0;
        int bModifFirma3 = 0;
        int lAltoImagen = 0;
        int lAnchoImagen = 0;

        public int ClipboardWidth = 0;
        public int ClipboardHeight = 0;
        public int ClipboardBitsPerPixel = 0;

        private void Carga_Firmas()
        {

            this.Cursor = Cursors.WaitCursor;



            //------ Firma 1
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //    LeerImagen ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", "  gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + Format$(lgblNumEmpresa)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            IMAGEN.LeerImagen(ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " eje_prefijo = " + CORVAR.igblPref.ToString() + "  AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //------ Firma 2
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //     LeerImagen ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + Format$(lgblNumEmpresa)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            IMAGEN.LeerImagen(ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
            //***** FIN DE CODIGO NUEVO  FSWBMX *****

            //------ Firma 3
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //    LeerImagen ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + Format$(lgblNumEmpresa)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO  FSWBMX *****
            IMAGEN.LeerImagen(ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", "eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            this.Cursor = Cursors.Default;

        }



        private void CORREGFI_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;


                ID_FIR_FR1_PB.Tag = "";
                ID_FIR_FR2_PB.Tag = "";
                ID_FIR_FR3_PB.Tag = "";

                for (int iCont = 0; iCont <= 2; iCont++)
                {
                    if (Strings.Len(CORMNEMP.DefInstance.ID_MEM_NOM_EB[iCont].Text) > 0 && Strings.Len(CORMNEMP.DefInstance.ID_MEM_PUE_EB[iCont].Text) > 0)
                    {
                        switch (iCont)
                        {
                            case 0:
                                ID_FIR_FR1_PB.Tag = "E";
                                break;
                            case 1:
                                ID_FIR_FR2_PB.Tag = "E";
                                break;
                            case 2:
                                ID_FIR_FR3_PB.Tag = "E";
                                break;
                        }
                    }
                }

                if (CORMNEMP.DefInstance.Tag.ToString() != CORCONST.TAG_ALTA)
                {
                    Carga_Firmas();
                }
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int iCont = 0;
            this.Top = (int)VB6.TwipsToPixelsY(1880);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2);
            this.Refresh();

            this.Cursor = Cursors.WaitCursor;
            if (!CORMNEMP.DefInstance.LoadAxgear1 && !CORMNEMP.DefInstance.LoadAxgear2 && !CORMNEMP.DefInstance.LoadAxgear3)
                ID_FIR_ACE_PB.Enabled = false;


            if (CORMNEMP.DefInstance.EnableID_FIR_FR1_PB)
            {
                ID_FIR_FR1_PB.Enabled = true;
            }

            if (CORMNEMP.DefInstance.EnableID_FIR_FR2_PB)
            {
                ID_FIR_FR2_PB.Enabled = true;
            }

            if (CORMNEMP.DefInstance.EnableID_FIR_FR3_PB)
            {
                ID_FIR_FR3_PB.Enabled = true;
            }



            bModifFirma1 = 0;
            bModifFirma2 = 0;
            bModifFirma3 = 0;

            this.Cursor = Cursors.Default;

        }



        private void ID_FIR_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int lArchiLong1 = 0;
            int lArchiLong2 = 0;
            int lArchiLong3 = 0;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.bgblModFirma = -1;

            if (CORMNEMP.DefInstance.Tag.ToString() != CORCONST.TAG_ALTA)
            {
                bModifFirma1 = -1;
                bModifFirma2 = -1;
                bModifFirma3 = -1;
            }

            try
            {

                if (bModifFirma1 != 0)
                {

                    ID_FIR_FR1_IMM.SaveFormat = GEAR.IG_SAVE_PCX;
                    ID_FIR_FR1_IMM.SaveImage = CORVAR.pszgblPathFirmas + "firma1.pcx";

                    if (FileSystem.Dir(CORVAR.pszgblPathFirmas + "firma1.pcx", FileAttribute.Normal) != CORVB.NULL_STRING)
                    {
                        lArchiLong1 = (int)(new FileInfo(CORVAR.pszgblPathFirmas + "firma1.pcx")).Length;
                    }

                    CORVAR.bgblFirma1 = -1;
                    CORVAR.bgblModFir1 = -1;

                    //libera la memoria de las copias
                    ID_FIR_OK_IMM.DelImage = true;
                    ID_FIR_PAG_IMM.DelImage = true;

                }

                if (bModifFirma2 != 0)
                {

                    ID_FIR_FR2_IMM.SaveFormat = GEAR.IG_SAVE_PCX;
                    ID_FIR_FR2_IMM.SaveImage = CORVAR.pszgblPathFirmas + "firma2.pcx";


                    if (FileSystem.Dir(CORVAR.pszgblPathFirmas + "firma2.pcx", FileAttribute.Normal) != CORVB.NULL_STRING)
                    {
                        lArchiLong2 = (int)(new FileInfo(CORVAR.pszgblPathFirmas + "firma2.pcx")).Length;
                    }
                    CORVAR.bgblFirma2 = -1;
                    CORVAR.bgblModFir2 = -1;

                    //libera la memoria de las copias
                    ID_FIR_OK_IMM.DelImage = true;
                    ID_FIR_PAG_IMM.DelImage = true;

                }

                if (bModifFirma3 != 0)
                {

                    ID_FIR_FR3_IMM.SaveFormat = GEAR.IG_SAVE_PCX;
                    ID_FIR_FR3_IMM.SaveImage = CORVAR.pszgblPathFirmas + "firma3.pcx";

                    if (FileSystem.Dir(CORVAR.pszgblPathFirmas + "firma3.pcx", FileAttribute.Normal) != CORVB.NULL_STRING)
                    {
                        lArchiLong3 = (int)(new FileInfo(CORVAR.pszgblPathFirmas + "firma3.pcx")).Length;
                    }

                    CORVAR.bgblFirma3 = -1;
                    CORVAR.bgblModFir3 = -1;

                    //libera la memoria de las copias
                    ID_FIR_OK_IMM.DelImage = true;
                    ID_FIR_PAG_IMM.DelImage = true;

                }

                if ((lArchiLong1 > 16000) || (lArchiLong2 > 16000) || (lArchiLong3 > 16000))
                {
                    if (lArchiLong1 > 16000)
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("La firma del representante 1 es demasiado grande. Favor de minimizarla.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }

                    if (lArchiLong2 > 16000)
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("La firma del representante 2 es demasiado grande. Favor de minimizarla.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }

                    if (lArchiLong3 > 16000)
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("La firma del representante 3 es demasiado grande. Favor de minimizarla.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                }
                else
                {
                    ID_FIR_OK_IMM.DelImage = true;
                    ID_FIR_PAG_IMM.DelImage = true;
                    Close();
                    //Hide();
                    //    Unload Me
                }

                CORMNEMP.DefInstance.EnableID_FIR_FR1_PB = this.ID_FIR_FR1_PB.Enabled;
                CORMNEMP.DefInstance.EnableID_FIR_FR2_PB = this.ID_FIR_FR2_PB.Enabled;
                CORMNEMP.DefInstance.EnableID_FIR_FR3_PB = this.ID_FIR_FR3_PB.Enabled;
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_FIR_ACE_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_FIR_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            CORMNEMP.DefInstance.LoadAxgear1 = false;
            CORMNEMP.DefInstance.LoadAxgear2 = false;
            CORMNEMP.DefInstance.LoadAxgear3 = false;

            CORMNEMP.DefInstance.Axgear1.ClearImage = true;
            CORMNEMP.DefInstance.Axgear2.ClearImage = true;
            CORMNEMP.DefInstance.Axgear3.ClearImage = true;

            CORMNEMP.DefInstance.Axgear1.DelImage = true;
            CORMNEMP.DefInstance.Axgear2.DelImage = true;
            CORMNEMP.DefInstance.Axgear3.DelImage = true;


            CORMNEMP.DefInstance.EnableID_FIR_FR1_PB = false;
            CORMNEMP.DefInstance.EnableID_FIR_FR2_PB = false;
            CORMNEMP.DefInstance.EnableID_FIR_FR3_PB = false;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.bgblModFirma = 0;

            //agrega Yuria 8/05/09
            CORVAR.bgblModFirma = 0;
            CORVAR.bgblFirma1 = 0;
            CORVAR.bgblFirma2 = 0;
            CORVAR.bgblFirma3 = 0;
            //fin Yuria 8/05/09

            //libera la memoria
            ID_FIR_OK_IMM.DelImage = true;
            ID_FIR_PAG_IMM.DelImage = true;

            this.Close();
            this.Cursor = Cursors.Default;
        }


        private void ID_FIR_FR1_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;


            bModifFirma1 = -1;
            //realiza la copia a ID_FIR_FR1_IMM
            ID_FIR_OK_IMM.ClipboardCopy = true;
            ID_FIR_FR1_IMM.ClipboardPaste = true;

            //  ID_FIR_FR1_IMM.FitMethod = 1

            ID_FIR_ACE_PB.Enabled = true;

            ID_FIR_FR1_IMM.ClipboardCopy = true;
            CORMNEMP.DefInstance.Axgear1.ClipboardPaste = true;
            CORMNEMP.DefInstance.LoadAxgear1 = true;

            this.Cursor = Cursors.Default;

        }

        private void ID_FIR_FR2_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            bModifFirma2 = -1;
            //realiza la copia a ID_FIR_FR1_IMM
            ID_FIR_OK_IMM.ClipboardCopy = true;
            ID_FIR_FR2_IMM.ClipboardPaste = true;
            ID_FIR_FR2_IMM.FitMethod = 1;

            ID_FIR_ACE_PB.Enabled = true;

            ID_FIR_FR2_IMM.ClipboardCopy = true;
            CORMNEMP.DefInstance.Axgear2.ClipboardPaste = true;
            CORMNEMP.DefInstance.LoadAxgear2 = true;

            this.Cursor = Cursors.Default;

        }

        private void ID_FIR_FR3_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            bModifFirma3 = -1;
            //realiza la copia a ID_FIR_FR1_IMM
            ID_FIR_OK_IMM.ClipboardCopy = true;
            ID_FIR_FR3_IMM.ClipboardPaste = true;
            ID_FIR_FR3_IMM.FitMethod = 1;

            ID_FIR_ACE_PB.Enabled = true;

            ID_FIR_FR3_IMM.ClipboardCopy = true;
            CORMNEMP.DefInstance.Axgear3.ClipboardPaste = true;
            CORMNEMP.DefInstance.LoadAxgear3 = true;

            this.Cursor = Cursors.Default;

        }

        private void ID_FIR_INS_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            ID_FIR_OK_IMM.ScanOpenSource = true;


        }

        private void ID_FIR_PAG_IMM_Click(Object eventSender, EventArgs eventArgs)
        {

            ID_FIR_PAG_IMM.SelectEvent = 1;

        }
        //AIS-1070 NGONZALEZ
        private void ID_FIR_PAG_IMM_SelectEvent(Object eventSender, AxGEARLib._DGearEvents_SelectEventEvent eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //para realizar el rectangulo o area seleccionada
            ID_FIR_PAG_IMM.ImageRectLeft = eventArgs.lplLeft;
            ID_FIR_PAG_IMM.ImageRectTop = eventArgs.lplTop;
            ID_FIR_PAG_IMM.ImageRectRight = eventArgs.lplRight;
            ID_FIR_PAG_IMM.ImageRectBottom = eventArgs.lplBottom;


            lAltoImagen = eventArgs.lplBottom - eventArgs.lplTop;
            lAnchoImagen = eventArgs.lplRight - eventArgs.lplLeft;

            if (ID_FIR_FR1_PB.Tag.ToString() == "E")
            {
                ID_FIR_FR1_PB.Enabled = true;
            }

            if (ID_FIR_FR2_PB.Tag.ToString() == "E")
            {
                ID_FIR_FR2_PB.Enabled = true;
            }

            if (ID_FIR_FR3_PB.Tag.ToString() == "E")
            {
                ID_FIR_FR3_PB.Enabled = true;
            }

            ID_FIR_PAG_IMM.SelectEvent = 0;

            ID_FIR_OK_IMM.ClearImage = true;

            //Copy the image seleccionada al clipboard
            ID_FIR_PAG_IMM.ClipboardCopy = true;
            ID_FIR_OK_IMM.ClipboardPaste = true;

            ID_FIR_OK_IMM.FitMethod = 3;
            ID_FIR_OK_IMM.ZoomLevel = 30;

            this.Cursor = Cursors.Default;

        }


        private void ID_FIR_SCA_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //se declara defaul para poder realizar n# de scaneos
            ID_FIR_PAG_IMM.ScanShowUI = true;


            //limpio los controles
            ID_FIR_PAG_IMM.ClearImage = false;
            ID_FIR_OK_IMM.ClearImage = false;

            ID_FIR_PAG_IMM.ErrCount = CORVB.NULL_INTEGER;

            //abre la ventana para escanear
            ID_FIR_PAG_IMM.ScanAcquire = true;

            if (ID_FIR_PAG_IMM.ErrCount != CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("El Escaner seleccionado no está instalado. ", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            ID_FIR_PAG_IMM.FitMethod = 3;
            ID_FIR_PAG_IMM.ZoomLevel = 30;

            ID_FIR_PAG_IMM.Focus();


            this.Cursor = Cursors.Default;

        }
        private void CORREGFI_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void CORREGFI_Shown(object sender, EventArgs e)
        {
            if (CORMNEMP.DefInstance.LoadAxgear1)
            {
                CORMNEMP.DefInstance.Axgear1.ClipboardCopy = true;
                this.ID_FIR_FR1_IMM.ClipboardPaste = true;
                this.ID_FIR_FR1_IMM.FitMethod = 1;
            }

            if (CORMNEMP.DefInstance.LoadAxgear2)
            {
                CORMNEMP.DefInstance.Axgear2.ClipboardCopy = true;
                this.ID_FIR_FR2_IMM.ClipboardPaste = true;
                this.ID_FIR_FR2_IMM.FitMethod = 1;
            }

            if (CORMNEMP.DefInstance.LoadAxgear3)
            {
                CORMNEMP.DefInstance.Axgear3.ClipboardCopy = true;
                this.ID_FIR_FR3_IMM.ClipboardPaste = true;
                this.ID_FIR_FR3_IMM.FitMethod = 1;
            }


        }
    }
}