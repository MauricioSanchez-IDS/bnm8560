using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORSGGRU
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Mantenimineto de Altas Bajas Cambios y Consultas    **
        //**                    de usuarios del sistema
        //**                                                                        **
        //**       Responsable: Felipe Zacarias Jimenez                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        const string STR_SEG_CON_GRU = "El grupo que se desea borrar, está asignado a usuarios. Favor de asignar un nuevo grupo a dichos usuarios antes de borrar el grupo seleccionado.";
        const string STR_SEG_GRU_BOR = "Realmente desea dar de baja el grupo ";

        string pszCadena = String.Empty;
        FixedLengthString[] szArrGrupos = ArraysHelper.InitializeArray<FixedLengthString[]>(new int[] { }, new object[] { });
        int hGruConexion = 0;

        private int Borra_Grupo(string pszGrupo)
        {

            int result = 0;
            int hGrupo = 0;

            CORVAR.pszgblsql = "delete";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_gpo_clave = " + pszGrupo;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

            if (CORPROC2.Modifica_Registro() != 0)
            {
                result = -1;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Se realizó con éxito la operación.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            else
            {
                result = 0;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No se pudo realizar la operación.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return result;
        }

        private void Carga_Grupos()
        {

            int iCont = 0;
            int hGrupos = 0;
            string pszCveGrupo = String.Empty;
            string pszDesGrupo = String.Empty;

            ID_GRU_GRU_LB.Items.Clear();
            if (szArrGrupos != null)
            {
                Array.Clear(szArrGrupos, 0, szArrGrupos.Length);
            }

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_clave,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " men_gpo_desc";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMEN01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where men_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by men_gpo_clave";

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    pszCveGrupo = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL), "000");
                    pszDesGrupo = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL);
                    ID_GRU_GRU_LB.Items.Add((pszCveGrupo + new String(' ', 8) + pszDesGrupo).Trim());
                    szArrGrupos = ArraysHelper.RedimPreserve<FixedLengthString[]>(szArrGrupos, new int[] { iCont + 1 });
                    szArrGrupos[iCont].Value = pszCveGrupo;
                    iCont++;
                };
            }
            else
            {
                //        igblErr = PostMessage(CORSGGRU.hwnd, WM_CLOSE, NULL_INTEGER, NULL_INTEGER)
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            if (ID_GRU_GRU_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_GRU_GRU_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }
        }

        private double Checa_Usuarios(string pszGrupo)
        {

            int hGrupo = 0;

            int iUsuConGrupo = CORVB.NULL_INTEGER;

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " usu_grupo";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUSU01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where usu_grupo = '" + Seguridad.Encripta(pszGrupo, 1) + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and usu_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

            iUsuConGrupo = CORPROC2.Cuenta_Registros();

            return iUsuConGrupo;

        }

        private void CORSGGRU_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                ID_GRU_GRU_LB.Focus();

                this.Show();
                this.Refresh();

                this.Cursor = Cursors.WaitCursor;

                Carga_Grupos();

                if (ID_GRU_GRU_LB.Items.Count == CORVB.NULL_INTEGER)
                {
                    ID_GRU_BAJ_PB.Enabled = false;
                    ID_GRU_CAM_PB.Enabled = false;
                    ID_GRU_CON_PB.Enabled = false;
                }
                else
                {
                    ID_GRU_BAJ_PB.Enabled = true;
                    ID_GRU_CAM_PB.Enabled = true;
                    ID_GRU_CON_PB.Enabled = true;
                    if (ID_GRU_GRU_LB.Items.Count != 0)
                    {
                        ID_GRU_GRU_LB.SelectedIndex = CORVB.NULL_INTEGER;
                    }
                }

                this.Cursor = Cursors.Default;

            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

        }

        private void ID_GRU_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //tamir  igblAccion = 1
            this.Tag = "Alta";
            //CORSGCGR.Show

            frmAcceso.DefInstance.Show();

            this.Cursor = Cursors.Default;

        }

        private void ID_GRU_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            FixedLengthString szGrupo = new FixedLengthString(CORBD.LEN_GRU_CVE);

            this.Cursor = Cursors.WaitCursor;
            try
            {
                szGrupo.Value = Strings.Mid(VB6.GetItemString(ID_GRU_GRU_LB, ListBoxHelper.GetSelectedIndex(ID_GRU_GRU_LB)), 1, CORBD.LEN_GRU_CVE).Trim();

                if (Checa_Usuarios(szGrupo.Value) != 0)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(STR_SEG_CON_GRU, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    this.Cursor = Cursors.Default;
                    return;
                }

                string pszMsg = STR_SEG_GRU_BOR + " " + szGrupo.Value + "  ... ?";
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                //UPGRADE_WARNING: (6021) Casting 'MsgBoxResult' to Enum may cause different behaviour.
                DialogResult iResp = (DialogResult)Interaction.MsgBox(pszMsg, (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_OKCANCEL), CORSTR.STR_APP_TIT);

                if (iResp == CORVB.IDOK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (ListBoxHelper.GetSelectedIndex(ID_GRU_GRU_LB) >= CORVB.NULL_INTEGER)
                    {
                        if (ID_GRU_GRU_LB.GetSelected(ListBoxHelper.GetSelectedIndex(ID_GRU_GRU_LB)))
                        {
                            if (Borra_Grupo(szGrupo.Value) != 0)
                            {
                                ID_GRU_GRU_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_GRU_GRU_LB));
                                ID_GRU_GRU_EB_GotFocus();
                            }
                        }
                    }
                }

                if (ID_GRU_GRU_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_GRU_GRU_LB.SelectedIndex = CORVB.NULL_INTEGER;
                    ID_GRU_GRU_LB.SetSelected(CORVB.NULL_INTEGER, true);
                }

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_GRU_BAJ_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_GRU_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Tag = "Cambio";
            //  CORSGCGR.Show
            frmAcceso.DefInstance.Show();

            this.Cursor = Cursors.Default;

        }

        private void ID_GRU_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Tag = "Consultas";
            //tamir  CORSGCGR.Show
            frmAcceso.DefInstance.Show();

            this.Cursor = Cursors.Default;

        }

        private void ID_GRU_GRU_EB_GotFocus()
        {

            pszCadena = CORVB.NULL_STRING;

        }


        //UPGRADE_NOTE: (7001) The following declaration (ID_GRU_GRU_EB_KeyUp) seems to be dead code
        //private void  ID_GRU_GRU_EB_KeyUp( int KeyCode,  int Shift)
        //{
        //
        //if (KeyCode == 8)
        //{
        //ID_GRU_GRU_EB_GotFocus();
        //}
        //
        //}

        private void ID_GRU_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }
        private void CORSGGRU_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}