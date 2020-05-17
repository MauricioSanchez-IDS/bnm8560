using Artinsoft.VB6.Gui;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORRPEMA
        : System.Windows.Forms.Form
    {

        private void CORRPEMA_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        //****************************************************************************
        //**                                                                        **
        //**          CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas          **
        //**                                                                        **
        //**       -----------------------------------------------------------      **
        //**                                                                        **
        //**       Descripción: Obtiene el detalle de todas las Empresas con -      **
        //**                    tenidas en el Header de l Históricoa a la for-      **
        //**                                                                        **
        //**       Responsable: Hugo L. Morales Garcia                              **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 06/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************


        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2)), Convert.ToInt32((float)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(Height))) / 2)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
            //Llena el combo box con los meses disponibles en El Histórico

            ComboBox tempRefParam = ID_DEA_MES_COB;
            CORPROC.Obten_Meses(this, ref tempRefParam);
            ID_DEA_MES_COB = tempRefParam;

        }

        private void ID_DEA_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblCancela = -1;
            this.Close();

            this.Cursor = Cursors.Default;

        }

        private void ID_DEA_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {

                if (ID_DEA_MES_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    CORVAR.igblMesDiaDEA = VB6.GetItemData(ID_DEA_MES_COB, ID_DEA_MES_COB.SelectedIndex);
                    CORVAR.igblAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_DEA_MES_COB.Text.Trim(), (ID_DEA_MES_COB.Text.Trim().IndexOf(' ') + 1) + 1)));
                    CORVAR.pszgblMesCorte = ID_DEA_MES_COB.Text;
                    CORRPEM2.DefInstance.Show();
                    if (CORRPEM2.DefInstance.flag)
                    {
                        CORRPEM2.DefInstance.flag = false;
                        CORRPEM2.DefInstance.Close();
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existen meses de corte para generar reportes.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    return;
                }


                //las siguientes lineas arman el nombre del archivo cuando se dese guardarlo en algún formato.
                //***** INICIO CODIGO NUEVO FSWBMX *****
                CORVAR.gblPathArchivo = CORVAR.pszgblPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString();
                if (FileSystem.Dir(CORVAR.gblPathArchivo, FileAttribute.Directory) == CORVB.NULL_STRING)
                {
                    Directory.CreateDirectory(CORVAR.gblPathArchivo);
                }
                CORVAR.gblPathArchivo = CORVAR.pszgblPathRepEmpresas + "Afiliadas";
                CORVAR.gblPathArchivo = CORVAR.pszgblPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "\\Afiliadas";

                if (FileSystem.Dir(CORVAR.gblPathArchivo, FileAttribute.Directory) == CORVB.NULL_STRING)
                {
                    Directory.CreateDirectory(CORVAR.gblPathArchivo);
                }
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                //gblPathArchivo = gblPathArchivo + "\" + Trim$(Str(igblAñoCorte)) + Trim$(Mid$(Format(igblMesCorte, "0000"), 1, 2)) + "DE"

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_DEA_OK_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CORRPEMA_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}