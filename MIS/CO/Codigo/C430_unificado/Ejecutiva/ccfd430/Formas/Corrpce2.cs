using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORRPCE2
        : System.Windows.Forms.Form
    {

        private void CORRPCE2_Activated(Object eventSender, EventArgs eventArgs)
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
        //**       Descripción: Catalogo para el reporte de concentrado por         **
        //**                    ejecutivo a la fecha de corte                       **
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

        //Variables para Conexiones de grupos
        int hConexion = 0;
        int hGrupo = 0;

        int iGruposRestantes = 0;
        int iTotalGrupos = 0;
        const int INT_MAX_GRUPOS = 999;

        //Variables para Conexiones de empresas
        int hRepEmp = 0;

        int iEmpresasRestantes = 0;
        int iTotalEmpresas = 0;
        const int INT_MAX_EMPRESAS = 999;

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
            ID_REE_EMP_LB.Items.Clear();
            ID_REE_MES_COB.Items.Clear();


            ID_REE_GRU_COB.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco = " + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //
            iTotalGrupos = CORPROC2.Cuenta_Registros();

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                if (iTotalGrupos > INT_MAX_GRUPOS)
                {
                    //      ID_REE_MASG_3PB.Enabled = True
                }

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros 8/06/99 And iCont < INT_MAX_GRUPOS
                    iCorCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszCorDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_REE_GRU_COB.Items.Add(StringsHelper.Format(iCorCve, "0000") + CORCONST.SPC_TRES + pszCorDesc.Trim());
                    iCont++;
                };
                iGruposRestantes = iTotalGrupos - iCont;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            ComboBox tempRefParam = ID_REE_MES_COB;
            CORPROC.Obten_Meses(this, ref tempRefParam);
            ID_REE_MES_COB = tempRefParam;

            //Posiciona en el Primer Elemento del ComboBox de Grupos
            if (ID_REE_GRU_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_REE_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            //Posiciona en el Primer Elemento del ComboBox de Empresas
            if (ID_REE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_REE_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }

        }

        private void CORRPCE2_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            Carga_Grupos();

        }

        private void ID_REE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ID_REE_MES_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    CORVAR.igblMesCorte = VB6.GetItemData(ID_REE_MES_COB, ID_REE_MES_COB.SelectedIndex);
                    CORVAR.igblAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_REE_MES_COB.Text.Trim(), (ID_REE_MES_COB.Text.Trim().IndexOf(' ') + 1) + 1)));
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
                if (ID_REE_IRE_CKB.Value)
                {
                    CORIRRPE.DefInstance.ShowDialog();
                    if (CORVAR.bgblCerrar == (0))
                    {
                        if (CORVAR.bgblIrExiste != 0)
                        {
                            CORRPCEJ.DefInstance.Show();
                            if (CORRPCEJ.DefInstance.flag)
                            {
                                CORRPCEJ.DefInstance.Close();
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("No existe la empresa seleccionada", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    if (ID_REE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
                    {
                        if (ID_REE_MES_COB.Items.Count > CORVB.NULL_INTEGER)
                        {
                            CORVAR.igblMesCorte = VB6.GetItemData(ID_REE_MES_COB, ID_REE_MES_COB.SelectedIndex);
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

                        //***** Código Anterior     ***********
                        //      lgblEmpCve = Val(Left(ID_REE_EMP_LB.Text, 5))
                        //***** Fin Código Anterior ***********
                        //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
                        CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(ID_REE_EMP_LB.Text.Substring(0, Math.Min(ID_REE_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                        //EISSA 05.10.2001 FIN

                        CORRPCEJ.DefInstance.Show();
                        if (CORRPCEJ.DefInstance.flag)
                        {
                            CORRPCEJ.DefInstance.Close();
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("No existen empresas a consultar", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    }
                }

                //las siguientes lineas arman el nombre del archivo cuando se dese guardarlo en algún formato.
                CORVAR.gblPathArchivo = CORVAR.pszgblPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + Conversion.Str(CORVAR.lgblEmpCve).Trim();

                if (FileSystem.Dir(CORVAR.gblPathArchivo, FileAttribute.Directory) == CORVB.NULL_STRING)
                {
                    Directory.CreateDirectory(CORVAR.gblPathArchivo);
                }

                CORVAR.gblPathArchivo = CORVAR.gblPathArchivo + "\\" + Conversion.Str(CORVAR.igblAñoCorte).Trim() + Strings.Mid(StringsHelper.Format(CORVAR.igblMesCorte, "0000"), 1, 2).Trim() + "CE";

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

            this.Close();

            this.Cursor = Cursors.Default;

        }




        private void ID_REE_EMP_LB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            CRSGeneral.lfncCargaUnidades(lstLista, StringsHelper.IntValue(Strings.Mid(ID_REE_GRU_COB.Text, 1, ID_REE_GRU_COB.Text.IndexOf(' ') + 1)), StringsHelper.IntValue(Strings.Mid(ID_REE_EMP_LB.Text, 1, ID_REE_EMP_LB.Text.IndexOf(' ') + 1)));
        }

        private void ID_REE_GRU_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int iCorCve = 0;
            int iCont = 0;
            int lEmpCve = 0;

            this.Cursor = Cursors.WaitCursor;

            ID_REE_EMP_LB.Items.Clear();

            int iCorNum = Convert.ToInt32(Conversion.Val(ID_REE_GRU_COB.Text.Substring(0, Math.Min(ID_REE_GRU_COB.Text.Length, 4))));

            this.Cursor = Cursors.WaitCursor;
            lstLista.Items.Clear();
            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_num = " + Format$(iCorNum) + " and gpo_banco =" + Str(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where gpo_num = " + iCorNum.ToString() + " and eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco =" + Conversion.Str(CORVAR.igblBanco);
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            iTotalEmpresas = CORPROC2.Cuenta_Registros();

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (iTotalEmpresas > INT_MAX_EMPRESAS)
                {
                    //ros 8/06/99        ID_REE_MAS_PB.Enabled = True
                }


                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros 8/06/99 And iCont < INT_MAX_EMPRESAS
                    lEmpCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_REE_EMP_LB.Items.Add(StringsHelper.Format(lEmpCve, Formato.sMascara(Formato.iTipo.Empresa)) + CORCONST.SPC_TRES + pszEmpDesc.Trim());
                    iCont++;
                };

                iEmpresasRestantes = iTotalEmpresas - iCont;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_REE_EMP_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_REE_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_REE_MASG_3PB_ClickEvent(Object eventSender, EventArgs eventArgs)
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

            if (iGruposRestantes > CORVB.NULL_INTEGER)
            {
                //Limpia los ListBox
                ID_REE_GRU_COB.Items.Clear();
                ID_REE_EMP_LB.Items.Clear();
                iCont = CORVB.NULL_INTEGER;
                //ros    itempErr = qeFetchPrev(hGrupo)

                while (!(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS && iCont < INT_MAX_GRUPOS))
                {
                    iCorCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszCorDesc = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_REE_GRU_COB.Items.Add(StringsHelper.Format(iCorCve, "0000") + CORCONST.SPC_TRES + pszCorDesc.Trim());
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
            if (ID_REE_GRU_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_REE_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            this.Cursor = Cursors.Default;

        }

        //UPGRADE_WARNING: (2050) ListBox Event lstLista.ItemCheck was not upgraded.

        private void lstLista_ItemCheck(int Item)
        {
            ID_REE_ALT_PB_Click(ID_REE_ALT_PB, new EventArgs());
        }
        private void CORRPCE2_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }




    }
}