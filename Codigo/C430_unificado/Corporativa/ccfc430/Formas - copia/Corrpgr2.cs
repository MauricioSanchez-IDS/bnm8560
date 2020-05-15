using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORRPGR2
        : System.Windows.Forms.Form
    {

        private void CORRPGR2_Activated(Object eventSender, EventArgs eventArgs)
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
        //**       Descripción: Catalogo para el reporte concentrado por empresa    **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        //Variables para Conexiones de grupos
        int hRepGpo = 0;
        int hConexion = 0;

        int iGruposRestantes = 0;
        int iTotalGrupos = 0;

        const int INT_MAX_GRUPOS = 999;



        private void Carga_Grupos()
        {

            int iError = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;

            //Limpia los ListBox
            ID_RGR_MES_COB.Items.Clear();
            ID_RGR_GPO_LB.Items.Clear();


            this.Cursor = Cursors.WaitCursor;


            this.Cursor = Cursors.WaitCursor;
            //Obtiene los meses con formato y llena combobox
            ComboBox tempRefParam = ID_RGR_MES_COB;
            CORPROC.Obten_Meses(this, ref tempRefParam);
            ID_RGR_MES_COB = tempRefParam;

            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //ros    igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            // pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco = " + Format(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****


            if (CORPROC2.Obtiene_Registros() != 0)
            {


                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros 8/06/99 And iCont < INT_MAX_GRUPOS
                    iCorCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszCorDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_RGR_GPO_LB.Items.Add(StringsHelper.Format(iCorCve, "0000") + CORCONST.SPC_TRES + pszCorDesc.Trim());
                    iCont++;
                };
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


            //Posiciona en el Primer Elemento del ComboBox de Grupos
            if (ID_RGR_GPO_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_RGR_GPO_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            //AIS-1624 FSABORIO
            this.Left = (CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2;
            this.Top = (CORMDIBN.DefInstance.ClientRectangle.Height -
                CORMDIBN.DefInstance.ID_COR_BHER.Height -
                CORMDIBN.DefInstance.ID_COR_BEDO.Height - this.Height) / 2;

            Carga_Grupos();

        }

        private void ID_REE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {

                if (ID_RGR_MES_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    CORVAR.igblMesCorte = VB6.GetItemData(ID_RGR_MES_COB, ID_RGR_MES_COB.SelectedIndex);
                    CORVAR.igblAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_RGR_MES_COB.Text.Trim(), (ID_RGR_MES_COB.Text.Trim().IndexOf(' ') + 1) + 1)));
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existen meses de corte para generar el reporte.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                    return;
                }

                if (ID_RGR_GPO_LB.Items.Count > 0)
                {
                    if (ID_CEG_IRE_CKB.Value)
                    {
                        CORIRRPG.DefInstance.ShowDialog();
                        if (CORVAR.bgblCerrar == (0))
                        {
                            if (CORVAR.bgblIrExiste != 0)
                            {
                                CORRPCGR.DefInstance.Show();
                                if (CORRPCGR.DefInstance.flag == true)
                                {
                                    CORRPCGR.DefInstance.Close();
                                }
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("No existe el Grupo seleccionado", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            }
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        CORVAR.lgblGpoCve = Convert.ToInt32(Conversion.Val(ID_RGR_GPO_LB.Text.Substring(0, Math.Min(ID_RGR_GPO_LB.Text.Length, 5))));

                        CORRPCGR.DefInstance.Show();
                        if (CORRPCGR.DefInstance.flag == true)
                        {
                            CORRPCGR.DefInstance.Close();
                        }
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existe elementos a seleccionar", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                }

                //las siguientes lineas arman el nombre del archivo cuando se dese guardarlo en algún formato.
                CORVAR.gblPathArchivo = CORVAR.pszgblPathRepCorporativo + Conversion.Str(CORVAR.lgblGpoCve).Trim();

                if (FileSystem.Dir(CORVAR.gblPathArchivo, FileAttribute.Directory) == CORVB.NULL_STRING)
                {
                    Directory.CreateDirectory(CORVAR.gblPathArchivo);
                }

                CORVAR.gblPathArchivo = CORVAR.gblPathArchivo + "\\" + Conversion.Str(CORVAR.igblAñoCorte).Trim() + Strings.Mid(StringsHelper.Format(CORVAR.igblMesCorte, "0000"), 1, 2).Trim() + "CG";
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_REE_ALT_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_REE_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Cursor = Cursors.Default;
            this.Close();

        }

        private void ID_RGR_MASG_3PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iTempErr = 0;
            int iNumGrupo = 0;
            string pszNomGrupo = String.Empty; //El grupo a obtener
            int iGrupos = 0;
            int iError = 0;
            int iCorCve = 0;
            string pszCorDesc = String.Empty;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;
            //Se realiza la conexión para llenado de listBox y comboboxes

            try
            {
                if (iGruposRestantes > CORVB.NULL_INTEGER)
                {
                    //Limpia los ListBox
                    ID_RGR_GPO_LB.Items.Clear();
                    iCont = CORVB.NULL_INTEGER;

                    while (!(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS && iCont < INT_MAX_GRUPOS))
                    {
                        iCorCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        pszCorDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_RGR_GPO_LB.Items.Add(StringsHelper.Format(iCorCve, "0000") + CORCONST.SPC_TRES + pszCorDesc.Trim());
                        iCont++;
                        if (iTotalGrupos == iCont + iTotalGrupos - iGruposRestantes)
                        {
                            iCont = INT_MAX_GRUPOS;
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                    };
                    iGruposRestantes -= iCont;
                    this.Cursor = Cursors.Default;
                    //Realiza fin de Query
                }
                else
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    Carga_Grupos();
                }

                //Posiciona en el Primer Elemento del ComboBox de Grupos
                if (ID_RGR_GPO_LB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_RGR_GPO_LB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_RGR_MASG_3PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        private void CORRPGR2_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}