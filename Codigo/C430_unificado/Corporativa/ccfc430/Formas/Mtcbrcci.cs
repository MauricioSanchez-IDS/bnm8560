using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class MTCBRCCI
        : System.Windows.Forms.Form
    {

        private void MTCBRCCI_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        public int iNumRep = 0;
        public int icargaInicial = 0;
        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Carga los Grupos corporativos existentes en el      **
        //**                    Catálogo de Grupos (CMTCOR01) a un Combo Box -      **
        //**                    y que posteriormente sirve para seleccionar  a      **
        //**                    las empresas del Grupo correspondiente              **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: El número de registros leídos                  **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 240999                                    **
        //**                                                                        **
        //****************************************************************************
        private int Carga_Grupos()
        {

            string pszNomGrupo = String.Empty; //El grupo a obtener
            int iNumGrupo = 0; //El consecutivo del grupo
            int iTempErr = 0; //Para control local
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;
            object iErr = CORCONST.OK;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                cboGrupo.Items.Clear();
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    cboGrupo.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
                    iCont++;
                };
                //Colocamos a un grupo por default
                if (cboGrupo.Items.Count != 0)
                {
                    cboGrupo.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


            this.Cursor = Cursors.Default;

            return 0;
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Carga las empresas de un determinado grupo   -      **
        //**                    Corporativo a un ListBox                            **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**           True: Si existieron empresas                                 **
        //**           False: Si no los hubo                                        **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 240999                                  **
        //**                                                                        **
        //****************************************************************************
        private int Obten_Empresas()
        {

            int result = 0;
            int iTempErr = 0; //Control local
            string pszEmpresa = String.Empty; //La empresa a obtener
            int iNumEmpresa = 0; //El consecutivo de la empresa
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;
            object iErr = CORCONST.OK;
            int iNumGrupo = Convert.ToInt32(Conversion.Val(cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 4)))); //El grupo de quien se trata
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_banco=" + Format$(igblBanco) + " and gpo_num =" + Format$(iNumGrupo)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + iNumGrupo.ToString() + " order by emp_num";
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                lstEmpresas.Items.Clear();
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);

                    //EISSA 03-10-2001. Cambio para el formateo del número de empresa
                    lstEmpresas.Items.Add(StringsHelper.Format(iNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
                    iCont++;
                };

                if (lstEmpresas.Items.Count != 0)
                {
                    ListBoxHelper.SetSelectedIndex(lstEmpresas, CORVB.NULL_INTEGER);
                    result = -1;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                //si no obtiene empresas limpia el control
                lstEmpresas.Items.Clear();
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


            this.Cursor = Cursors.Default;

            return result;
        }


        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Carga las empresas de un determinado grupo   -      **
        //**                    Corporativo a un ListBox                            **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**           True: Si existieron empresas                                 **
        //**           False: Si no los hubo                                        **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 240999                                  **
        //**                                                                        **
        //****************************************************************************
        private int Carga_ReportesCCI()
        {
            int result = 0;
            string pszNomReporte = String.Empty; //El reporte a obtener
            int iNumReporte = 0; //La posicion del reporte
            int iTempErr = 0; //Para control local
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;
            object iErr = CORCONST.OK;

            CORVAR.pszgblsql = "select nrp_posicion_rep, nrp_nom_reporte from " + CORBD.DB_SYB_NRP;

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                lstReportes.Items.Clear();
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumReporte = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomReporte = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    lstReportes.Items.Add(StringsHelper.Format(iNumReporte, "0000") + "  " + pszNomReporte);
                    iCont++;
                };
                //Colocamos a al primer reporte por default
                //If cboReporte.ListCount Then
                //  cboReporte.ListIndex = NULL_INTEGER
                //End If
                result = -1;
            }
            else
            {
                result = 0;
                this.Cursor = Cursors.Default;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


            this.Cursor = Cursors.Default;
            return result;
        }









        private void cboGrupo_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            ErrObject iErr = null;
            int lEmpresas = Obten_Empresas(); //Obtiene las empresas del Grupo
            //UPGRADE_WARNING: (1068) iErr of type Variant is being forced to double.
            if (Convert.ToDouble(iErr) != CORCONST.OK)
            {
                //AIS-1182 NGONZALEZ
                iErr.Number = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }
        }

        private void chkTodEmp_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {

            if (chkTodEmp.CheckState == CheckState.Unchecked)
            {
                cboGrupo.Enabled = true;
                lstEmpresas.Enabled = true;
                chkTodGrp.Enabled = true;
            }
            else
            {
                cboGrupo.Enabled = false;
                lstEmpresas.Enabled = false;
                chkTodGrp.Enabled = false;
            }
        }

        private void chkTodGrp_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {

            if (chkTodGrp.CheckState == CheckState.Unchecked)
            {
                lstEmpresas.Enabled = true;
                chkTodEmp.Enabled = true;
            }
            else
            {
                lstEmpresas.Enabled = false;
                chkTodEmp.Enabled = false;
            }
        }

        private void cmdAceptar_Click(Object eventSender, EventArgs eventArgs)
        {
            int numReporte = 0;
            double numeroReporte = 0;
            int numFinRep = 0;
            int iNumGrupo = 0;

            this.Cursor = Cursors.WaitCursor;
            try
            {

                for (int i = 0; i <= lstReportes.Items.Count - 1; i++)
                {
                    if (lstReportes.GetSelected(i))
                    {
                        numReporte = Convert.ToInt32(Conversion.Val(VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 4))));
                        numeroReporte = (int)Math.Pow(2, numReporte);
                        numReporte = Convert.ToInt32(Math.Floor(numeroReporte));
                        if (i == 0)
                        {
                            numFinRep = numReporte;
                        }
                        else
                        {
                            numFinRep = numFinRep | numReporte;
                        }
                    }
                }
                string operador = " | (" + numFinRep.ToString() + ")";
                int siGenera = 0;
                CORVAR.pszgblsql = "update " + CORBD.DB_SYB_BRP + " set brp_banderas = brp_banderas " + operador;
                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //pszgblsql = pszgblsql + " where gpo_banco = " + Format$(igblBanco)
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX ****
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                //***** FIN DE CODIGO NUEVO FSWBMX ****
                if (chkTodEmp.CheckState == CheckState.Checked)
                {
                    siGenera = 1;
                }
                else
                {
                    if (chkTodGrp.CheckState == CheckState.Checked)
                    {
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 4));
                        siGenera = 1;
                    }
                    else
                    {
                        if (lstReportes.SelectedItems.Count > 0)
                        {
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 4));
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)).Substring(0, Math.Min(VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)).Length, 5));
                            siGenera = 1;
                        }
                    }
                }

                if (siGenera == 1 && lstReportes.SelectedItems.Count > 0)
                {
                    if (CORPROC2.Modifica_Registro() != 0)
                    {
                        this.Cursor = Cursors.Default;
                        if (lstReportes.SelectedItems.Count > 0)
                        {
                            for (int i = 0; i <= lstReportes.Items.Count - 1; i++)
                            {
                                if (lstReportes.GetSelected(i))
                                {
                                    VB6.SetItemString(lstReportes, i, VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 58)) + "Si");
                                }
                                lstReportes.SetSelected(i, false);
                            }
                        }
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Se realizó con éxito la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("No se pudo realizar la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Debe seleccionar por lo menos un reporte.", Application.ProductName);
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdAceptar_Click)", e);
            }
        }









        private void cmdNoGen_Click(Object eventSender, EventArgs eventArgs)
        {
            int numReporte = 0;
            double numeroReporte = 0;
            int numFinRep = 0;
            int iNumGrupo = 0;

            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i <= lstReportes.Items.Count - 1; i++)
            {
                if (lstReportes.GetSelected(i))
                {
                    numReporte = Convert.ToInt32(Conversion.Val(VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 4))));
                    numeroReporte = (int)Math.Pow(2, numReporte);
                    numReporte = ~Convert.ToInt32(Math.Floor(numeroReporte));
                    if (i == 0)
                    {
                        numFinRep = numReporte;
                    }
                    else
                    {
                        numFinRep = numFinRep & numReporte;
                    }
                }
            }
            string operador = " & (" + numFinRep.ToString() + ")";
            int siGenera = 0;
            CORVAR.pszgblsql = "update " + CORBD.DB_SYB_BRP + " set brp_banderas = brp_banderas " + operador;
            //***** INICIO DE CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = pszgblsql + " where gpo_banco = " + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO DE CODIGO NUEVO FSWBMX ****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (chkTodEmp.CheckState == CheckState.Checked)
            {
                siGenera = 1;
            }
            else
            {
                if (chkTodGrp.CheckState == CheckState.Checked)
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 4));
                    siGenera = 1;
                }
                else
                {
                    if (lstReportes.SelectedItems.Count > 0)
                    {
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + cboGrupo.Text.Substring(0, Math.Min(cboGrupo.Text.Length, 4));
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)).Substring(0, Math.Min(VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)).Length, 5));
                        siGenera = 1;
                    }
                }
            }

            if (siGenera == 1 && lstReportes.SelectedItems.Count > 0)
            {
                if (CORPROC2.Modifica_Registro() != 0)
                {
                    this.Cursor = Cursors.Default;
                    for (int i = 0; i <= lstReportes.Items.Count - 1; i++)
                    {
                        if (lstReportes.GetSelected(i))
                        {
                            VB6.SetItemString(lstReportes, i, VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 58)) + "No");
                        }
                        lstReportes.SetSelected(i, false);
                    }
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Se realizó con éxito la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se pudo realizar la operación.", CORVB.MB_OK, CORSTR.STR_APP_TIT);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Debe seleccionar por lo menos un reporte.", Application.ProductName);
            }


        }

        private void cmdSalir_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            string DB_SYB_BPR = String.Empty;
            object iCont = null;
            double numRep = 0;
            double numRepLeido = 0;
            double reporte = 0;
            int iGrupos = 0;

            int iErr;
            iErr = CORCONST.OK;
            float iLeft = (((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2;
            float iTop = (((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(Height))) / 2;

            //this.SetBounds(Convert.ToInt32((float) VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float) VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
            this.Show();
            this.Refresh();

            this.Cursor = Cursors.WaitCursor;

            //UPGRADE_ISSUE: (2064) Threed.SSPanel property ._Caption was not upgraded.
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORSTR.STR_LEE_BD;




            //obtiene el grupo y la empresa
            do
            {
                iGrupos = Carga_Grupos();
                //UPGRADE_WARNING: (1068) iErr of type Variant is being forced to double.
                if (Convert.ToDouble(iErr) == CORCONST.OK)
                {
                    if (cboGrupo.Items.Count == CORVB.NULL_INTEGER)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No existen Grupos en catálogo ", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.WaitCursor;
                        break;
                    }
                }
                else
                {
                    //AIS-1182 NGONZALEZ
                    iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);

                    break;
                }
                //UPGRADE_WARNING: (1068) iErr of type Variant is being forced to double.
            }
            while ((cboGrupo.Items.Count | ((Convert.ToDouble(iErr) != CORCONST.OK) ? -1 : 0)) == 0);
            int iReportes = Carga_ReportesCCI();
            //UPGRADE_WARNING: (1068) iErr of type Variant is being forced to double.
            if (Convert.ToDouble(iErr) == CORCONST.OK)
            {
                if (lstReportes.Items.Count == CORVB.NULL_INTEGER)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No existen Reportes en catálogo ", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.WaitCursor;
                }
            }
            else
            {
                //AIS-1182 NGONZALEZ
                iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }
            ListBoxHelper.SetSelectedIndex(lstReportes, CORVB.NULL_INTEGER);
            CORVAR.pszgblsql = "select brp_banderas from " + CORBD.DB_SYB_BRP;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where gpo_banco = " + CORVAR.igblBanco.ToString();
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + VB6.GetItemString(cboGrupo, cboGrupo.SelectedIndex).Substring(0, Math.Min(VB6.GetItemString(cboGrupo, cboGrupo.SelectedIndex).Length, 4));
            //***** INICIO CODIGO NUEVO FSWBMX *****
            if (lstEmpresas.Items.Count == 0)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + "00000";
            }
            else
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + VB6.GetItemString(lstEmpresas, 0).Substring(0, Math.Min(VB6.GetItemString(lstEmpresas, 0).Length, 5));
            }
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                //UPGRADE_WARNING: (1037) Couldn't resolve default property of object iCont.
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    for (int i = 0; i <= lstReportes.Items.Count - 1; i++)
                    {
                        numRep = Conversion.Val(VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 4)));
                        reporte = Math.Pow(2, numRep);
                        numRep = Math.Floor(reporte);
                        numRepLeido = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                        numRep = Convert.ToInt32(numRep) & Convert.ToInt32(numRepLeido);
                        if (numRep > 0)
                        { //checa si está prendida la bandera para ese reporte
                            VB6.SetItemString(lstReportes, i, VB6.GetItemString(lstReportes, i) + "  Si");
                        }
                        else
                        {
                            VB6.SetItemString(lstReportes, i, VB6.GetItemString(lstReportes, i) + "  No");
                        }
                        //UPGRADE_WARNING: (1068) iCont of type Variant is being forced to double.
                        //UPGRADE_WARNING: (1037) Couldn't resolve default property of object iCont.
                        iCont = Convert.ToDouble(iCont) + 1;
                    }
                };
            }
            else
            {
                MessageBox.Show("no existe la empresa en la tabla" + DB_SYB_BPR, Application.ProductName);
                //UPGRADE_WARNING: (1037) Couldn't resolve default property of object iCont.
                iCont = CORVB.NULL_INTEGER;
                for (int i = 0; i <= lstReportes.Items.Count - 1; i++)
                {
                    numRep = Conversion.Val(VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 4)));
                    reporte = Math.Pow(2, numRep);
                    numRep = Math.Floor(reporte);
                    numRepLeido = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                    numRep = Convert.ToInt32(numRep) & Convert.ToInt32(numRepLeido);
                    VB6.SetItemString(lstReportes, i, VB6.GetItemString(lstReportes, i) + "    ");
                    //UPGRADE_WARNING: (1068) iCont of type Variant is being forced to double.
                    //UPGRADE_WARNING: (1037) Couldn't resolve default property of object iCont.
                    iCont = Convert.ToDouble(iCont) + 1;
                }
            }
            //'End If
            mdlParametros.gperPerfil.prHabilitaAcciones(MTCBRCCI.DefInstance);
            this.Cursor = Cursors.Default;
        }

        private void lstEmpresas_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            string DB_SYB_BPR = String.Empty;
            object iCont = null;
            double numRep = 0;
            double numRepLeido = 0;
            double reporte = 0;

            this.Cursor = Cursors.WaitCursor;
            if (lstEmpresas.SelectedItems.Count > 0)
            {
                CORVAR.pszgblsql = "select brp_banderas from " + CORBD.DB_SYB_BRP;
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where gpo_banco= " + CORVAR.igblBanco.ToString();
                //***** INICIO CODIGO NUEVO FSWBMX *****
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo= " + CORVAR.igblPref.ToString();
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num= " + VB6.GetItemString(cboGrupo, cboGrupo.SelectedIndex).Substring(0, Math.Min(VB6.GetItemString(cboGrupo, cboGrupo.SelectedIndex).Length, 4));
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num= " + VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)).Substring(0, Math.Min(VB6.GetItemString(lstEmpresas, ListBoxHelper.GetSelectedIndex(lstEmpresas)).Length, 5));
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    //UPGRADE_WARNING: (1037) Couldn't resolve default property of object iCont.
                    iCont = CORVB.NULL_INTEGER;

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        for (int i = 0; i <= lstReportes.Items.Count - 1; i++)
                        {
                            numRep = Conversion.Val(VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 4)));
                            reporte = Math.Pow(2, numRep);
                            numRep = Math.Floor(reporte);
                            numRepLeido = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                            numRep = Convert.ToInt32(numRep) & Convert.ToInt32(numRepLeido);
                            if (numRep > 0)
                            { //checa si está prendida la bandera para ese reporte
                                VB6.SetItemString(lstReportes, i, VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 58)) + "Si");
                            }
                            else
                            {
                                VB6.SetItemString(lstReportes, i, VB6.GetItemString(lstReportes, i).Substring(0, Math.Min(VB6.GetItemString(lstReportes, i).Length, 58)) + "No");
                            }
                            //UPGRADE_WARNING: (1068) iCont of type Variant is being forced to double.
                            //UPGRADE_WARNING: (1037) Couldn't resolve default property of object iCont.
                            iCont = Convert.ToDouble(iCont) + 1;
                        }
                    };
                }
                else
                {
                    MessageBox.Show("no existe la empresa en la tabla" + DB_SYB_BPR, Application.ProductName);
                }
            }

            this.Cursor = Cursors.Default;
        }


        //UPGRADE_NOTE: (7001) The following declaration (SSOption1_Click) seems to be dead code
        //private void  SSOption1_Click( int Value)
        //{
        //
        //}


        //UPGRADE_NOTE: (7001) The following declaration (SSOption2_Click) seems to be dead code
        //private void  SSOption2_Click( int Value)
        //{
        //}
    }
}