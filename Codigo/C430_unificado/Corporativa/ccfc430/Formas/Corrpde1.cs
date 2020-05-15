using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORRPDE1
        : System.Windows.Forms.Form
    {

        private void CORRPDE1_Activated(Object eventSender, EventArgs eventArgs)
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
        //**       Descripción: Catalogo para el reporte detallado                  **
        //**                    por ejecutivo                                       **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int lEmpCve = 0;
        int iEjeCve = 0;
        int hConexion = 0;

        //UPGRADE_NOTE: (7001) The following declaration (Envia_Error) seems to be dead code
        //private void  Envia_Error( int hStmt)
        //{
        //
        //AIS-1182 NGONZALEZ
        //CORVAR.igblErr = API.USER.PostMessage(CORRPDE1.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
        //
        //}

        private void CORRPDE1_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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

            int iError = 0;
            int hEjeEmp = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iCorte = 0;
            int lNumEje = 0;

            int lEjxNum = 0;
            string pszEjxNombre = String.Empty;

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            this.Show();
            this.Refresh();

            this.Cursor = Cursors.WaitCursor;

            //Limpia el ListBox y los Combo Box
            ID_DA1_EMP_LB.Items.Clear();
            ID_DA1_MES_COB.Items.Clear();

            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            CORVAR.pszgblsql = "select ejx_numero, ejx_nombre from " + CORBD.DB_SYB_EJX + " order by ejx_nombre";


            if (CORPROC2.Obtiene_Registros() != 0)
            { //Ocurrio algun error en la ejecución SQL

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lEjxNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEjxNombre = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_DA1_EMP_LB.Items.Add(StringsHelper.Format(lEjxNum, "0000000") + CORCONST.SPC_TRES + pszEjxNombre.Trim());
                };
                ComboBox tempRefParam = ID_DA1_MES_COB;
                CORPROC.Obten_Meses(this, ref tempRefParam);
                ID_DA1_MES_COB = tempRefParam;
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                return; //Salimos de la función
            }


            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Realiza fin de Query

            //Posiciona en el Primer Elemento del List Box de Ejecutivos Banamex
            if (ID_DA1_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_DA1_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_DA1_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int lEmpresas = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (ID_DA1_MES_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    CORVAR.igblMesDiaACG = VB6.GetItemData(ID_DA1_MES_COB, ID_DA1_MES_COB.SelectedIndex);
                    CORVAR.igblAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_DA1_MES_COB.Text.Trim(), (ID_DA1_MES_COB.Text.Trim().IndexOf(' ') + 1) + 1)));
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

                if (ID_DA1_EMP_LB.Items.Count != 0)
                {
                    CORVAR.lgblNumEjeBnx = Convert.ToInt32(Conversion.Val(ID_DA1_EMP_LB.Text.Substring(0, Math.Min(ID_DA1_EMP_LB.Text.Length, 7))));
                    //CORRPDEJ.DefInstance.Close();
                    CORRPDEJ.DefInstance.Show();
                    if (CORRPDEJ.DefInstance.flag)
                        CORRPDEJ.DefInstance.Close();
                }

                //las siguientes lineas arman el nombre del archivo cuando se dese guardarlo en algún formato.
                //gblPathArchivo = Mid$(pszgblPathRepEmpresas, 1, Len(pszgblPathRepEmpresas) - 1)
                CORVAR.gblPathArchivo = CORVAR.pszgblPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + Conversion.Str(CORVAR.lgblNumEmpresaR).Trim();
                if (FileSystem.Dir(CORVAR.gblPathArchivo, FileAttribute.Directory) == CORVB.NULL_STRING)
                {
                    Directory.CreateDirectory(CORVAR.gblPathArchivo);
                }

                CORVAR.gblPathArchivo = CORVAR.gblPathArchivo + "\\E" + StringsHelper.Format(CORVAR.lgblNumEjeBnx, "0000000").Trim();

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_DA1_ALT_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_DA1_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Close();

            this.Cursor = Cursors.Default;

        }
        private void CORRPDE1_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}