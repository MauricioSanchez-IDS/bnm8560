using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class frmAccCyRep
        : System.Windows.Forms.Form
    {

        private void frmAccCyRep_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        string slSQL = String.Empty;
        public clsREPUnidad unilPadre = null;
        public clsREPReporte rptlReporte = null;
        int llEmpresa = 0;
        string slCuenta = String.Empty;
        int ilAño = 0;
        int ilMes = 0;
        string slNombreEmpresa = String.Empty;
        string slSeparador = String.Empty;
        //string slPath = String.Empty;
        string lsDir = String.Empty;
        int licont = 0;



        private void prPreparaReporte(ref  int lpPrefijo, ref  int lpBanco, ref  int lpEmpresa, string spNombreEmpresa, clsREPUnidad.cteNivelProfundidad ipTipoReporte, int ipPeriodo, int ipAño)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                slSeparador = " ";
                unilPadre = new clsREPUnidad();
                rptlReporte = new clsREPReporte();
                rptlReporte.ColumnasPorPaginaI = 200;
                rptlReporte.CadenaSeparadorS = new string('-', rptlReporte.ColumnasPorPaginaI);
                unilPadre = mdlREPReportes.unifncObtieneUnidadPrincipal(lpPrefijo, lpBanco, lpEmpresa);

                if (unilPadre != null)
                {
                    unilPadre.AñoCorteI = ipAño;
                    unilPadre.PeriodoCorteI = ipPeriodo;
                    rptlReporte.InicializaEncabezado();
                    rptlReporte.InicializaPiePagina();
                    mdlREPReportes.prConstruyeJerarquia(unilPadre.IdS, ref unilPadre);
                    if (((int)ipTipoReporte) == ((int)clsREPUnidad.cteNivelProfundidad.cteNivelUnidad))
                    {
                        clsREPUnidad.cteNivelProfundidad tempRefParam = clsREPUnidad.cteNivelProfundidad.cteNivelUnidad;
                        unilPadre.ActualizaUnidades(ref tempRefParam);
                    }
                    else if (((int)ipTipoReporte) == ((int)clsREPUnidad.cteNivelProfundidad.cteNivelTarjetaHabiente))
                    {
                        clsREPUnidad.cteNivelProfundidad tempRefParam2 = clsREPUnidad.cteNivelProfundidad.cteNivelTarjetaHabiente;
                        unilPadre.ActualizaUnidades(ref tempRefParam2);
                    }
                    else if (((int)ipTipoReporte) == ((int)clsREPUnidad.cteNivelProfundidad.cteNivelTransaccion))
                    {
                        clsREPUnidad.cteNivelProfundidad tempRefParam3 = clsREPUnidad.cteNivelProfundidad.cteNivelTransaccion;
                        unilPadre.ActualizaUnidades(ref tempRefParam3);
                    }
                    unilPadre.GeneraTotales();
                    rptlReporte.InicializaCuerpo();
                }
                else
                {
                    MessageBox.Show("La empresa no cuenta con esquema de Unidades o no tiene una Unidad Padre asociada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("PreparaReporte", e);
            }
        }

        private void cboCombo_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(cboCombo, eventSender);
            switch (Index)
            {
                case 1:
                    if (cboCombo[1].SelectedIndex > 0)
                    {
                        ilMes = cboCombo[1].SelectedIndex;
                    }
                    break;
                case 2:
                    if (cboCombo[2].SelectedIndex > 0)
                    {
                        ilAño = Convert.ToInt32(Conversion.Val(cboCombo[2].Text));
                    }
                    break;
            }
        }

        private void prGeneraReporteAccCyRep()
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                //***JPU***  Se inicia a validacion de los campos
                if (ID_CEM_GRP_COB.SelectedIndex != -1)
                {
                    if (cboCombo[1].SelectedIndex != -1)
                    {
                        if (cboCombo[2].SelectedIndex != -1)
                        {
                            if (ID_CEM_EMP_LB.CheckedIndices.Count >= 1)
                            {
                                if (chkNivel[0].CheckState != CheckState.Checked)
                                {
                                    if (chkNivel[1].CheckState != CheckState.Checked)
                                    {
                                        if (chkNivel[2].CheckState != CheckState.Checked)
                                        {
                                            MessageBox.Show("Seleccione el reporte que desea generar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Cursor = Cursors.Default;
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Para continuar seleccione una Empresa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Cursor = Cursors.Default;
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Para continuar seleccione un Año", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            cboCombo[2].Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para continuar seleccione un Mes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;
                        cboCombo[1].Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Para continuar seleccione un Grupo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    ID_CEM_GRP_COB.Focus();
                    return;
                }
                //***JPU***  Se termina de validar los campos

                licont = 0;


                while (!(licont > ID_CEM_EMP_LB.Items.Count - 1))
                {

                    ID_CEM_EMP_LB.SelectedIndex = licont;

                    if (ID_CEM_EMP_LB.GetItemChecked(licont))
                    {
                        string tempRefParam = ID_CEM_EMP_LB.Text;
                        llEmpresa = Convert.ToInt32(Conversion.Val(CRSGeneral.fncsObtenerElementoDeCadena(ref tempRefParam, 1, " ").Trim()));
                        slNombreEmpresa = Strings.Mid(ID_CEM_EMP_LB.Text, Formato.igLongitudEmpresa + 1).Trim();
                        slCuenta = "NUMERO DE CUENTA";
                        if (chkNivel[2].CheckState == CheckState.Checked)
                        { //Reporte a Nivel Transaccion
                            int tempRefParam2 = CORVAR.igblPref;
                            int tempRefParam3 = CORVAR.igblBanco;
                            prPreparaReporte(ref tempRefParam2, ref tempRefParam3, ref llEmpresa, slNombreEmpresa, clsREPUnidad.cteNivelProfundidad.cteNivelTransaccion, ilMes, ilAño);
                        }
                        else
                        {
                            if (chkNivel[1].CheckState == CheckState.Checked)
                            { //Reporte a Nivel TarjetaHabiente
                                int tempRefParam4 = CORVAR.igblPref;
                                int tempRefParam5 = CORVAR.igblBanco;
                                prPreparaReporte(ref tempRefParam4, ref tempRefParam5, ref llEmpresa, slNombreEmpresa, clsREPUnidad.cteNivelProfundidad.cteNivelTarjetaHabiente, ilMes, ilAño);
                            }
                            else
                            {
                                if (chkNivel[0].CheckState == CheckState.Checked)
                                { //Reporte a Nivel Unidad
                                    int tempRefParam6 = CORVAR.igblPref;
                                    int tempRefParam7 = CORVAR.igblBanco;
                                    prPreparaReporte(ref tempRefParam6, ref tempRefParam7, ref llEmpresa, slNombreEmpresa, clsREPUnidad.cteNivelProfundidad.cteNivelUnidad, ilMes, ilAño);
                                }
                                else
                                {
                                    MessageBox.Show("Seleccione el reporte que desea generar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Cursor = Cursors.Default;
                                    return;
                                }
                            }
                        }
                        //lsDir = slPath + "\\" + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + llEmpresa.ToString() + "\\";
                        lsDir = mdlParametros.sgPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + llEmpresa.ToString() + "\\";

                        if (FileSystem.Dir(lsDir, FileAttribute.Directory) == CORVB.NULL_STRING)
                        {
                            Directory.CreateDirectory(lsDir);
                        }

                        if (chkNivel[0].CheckState == CheckState.Checked)
                        {
                            if (unilPadre.ResumenRUN.TotalesTH.Count == 0)
                            {
                                unilPadre.ResumenRUN.TotalesTH.Add(unilPadre.IdS, "");
                                unilPadre.ResumenRUN.TotalesTH[1].Totales.NumeroCuentaS = mdlEjecutivo.fncCuentaPadreS(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, llEmpresa);
                                mdlREPReportes.cteTipoReporte tempRefParam8 = mdlREPReportes.cteTipoReporte.cteAccountCycleSummaryUnit;
                                string tempRefParam9 = mdlParametros.sgPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + llEmpresa.ToString() + "\\";
                                string tempRefParam10 = unilPadre.ResumenRUN.TotalesTH[1].Totales.NumeroCuentaS;
                                prReporteUnidad(unilPadre, ref tempRefParam8, ref tempRefParam9, ref rptlReporte, ref tempRefParam10, ref slNombreEmpresa, ref slSeparador);
                            }
                            else if (unilPadre.ResumenRUN.TotalesTH.Count > 0)
                            {
                                mdlREPReportes.cteTipoReporte tempRefParam11 = mdlREPReportes.cteTipoReporte.cteAccountCycleSummaryUnit;
                                string tempRefParam12 = mdlParametros.sgPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + llEmpresa.ToString() + "\\";
                                string tempRefParam13 = unilPadre.ResumenRUN.TotalesTH[1].Totales.NumeroCuentaS;
                                prReporteUnidad(unilPadre, ref tempRefParam11, ref tempRefParam12, ref rptlReporte, ref tempRefParam13, ref slNombreEmpresa, ref slSeparador);
                            }
                        }

                        if (chkNivel[1].CheckState == CheckState.Checked)
                        {
                            if (unilPadre.ResumenRUN.TotalesTH.Count == 0)
                            {
                                unilPadre.ResumenRUN.TotalesTH.Add(unilPadre.IdS, "");
                                unilPadre.ResumenRUN.TotalesTH[0].Totales.NumeroCuentaS = mdlEjecutivo.fncCuentaPadreS(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, llEmpresa);
                                mdlREPReportes.cteTipoReporte tempRefParam14 = mdlREPReportes.cteTipoReporte.cteAccountCycleSummaryTH;
                                string tempRefParam15 = mdlParametros.sgPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + llEmpresa.ToString() + "\\";
                                string tempRefParam16 = unilPadre.ResumenRUN.TotalesTH[1].Totales.NumeroCuentaS;
                                prReporteUnidad(unilPadre, ref tempRefParam14, ref tempRefParam15, ref rptlReporte, ref tempRefParam16, ref slNombreEmpresa, ref slSeparador);
                            }
                            else if (unilPadre.ResumenRUN.TotalesTH.Count > 0)
                            {
                                mdlREPReportes.cteTipoReporte tempRefParam17 = mdlREPReportes.cteTipoReporte.cteAccountCycleSummaryTH;
                                string tempRefParam18 = mdlParametros.sgPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + llEmpresa.ToString() + "\\";
                                string tempRefParam19 = unilPadre.ResumenRUN.TotalesTH[1].Totales.NumeroCuentaS;
                                prReporteUnidad(unilPadre, ref tempRefParam17, ref tempRefParam18, ref rptlReporte, ref tempRefParam19, ref slNombreEmpresa, ref slSeparador);
                            }
                        }

                        if (chkNivel[2].CheckState == CheckState.Checked)
                        {
                            if (unilPadre.ResumenRUN.TotalesTH.Count == 0)
                            {
                                unilPadre.ResumenRUN.TotalesTH.Add(unilPadre.IdS, "");
                                unilPadre.ResumenRUN.TotalesTH[0].Totales.NumeroCuentaS = mdlEjecutivo.fncCuentaPadreS(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, llEmpresa);
                                mdlREPReportes.cteTipoReporte tempRefParam20 = mdlREPReportes.cteTipoReporte.cteAccountCycleDetailTransaction;
                                string tempRefParam21 = mdlParametros.sgPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + llEmpresa.ToString() + "\\";
                                string tempRefParam22 = unilPadre.ResumenRUN.TotalesTH[1].Totales.NumeroCuentaS;
                                prReporteUnidad(unilPadre, ref tempRefParam20, ref tempRefParam21, ref rptlReporte, ref tempRefParam22, ref slNombreEmpresa, ref slSeparador);
                            }
                            else if (unilPadre.ResumenRUN.TotalesTH.Count > 0)
                            {
                                mdlREPReportes.cteTipoReporte tempRefParam23 = mdlREPReportes.cteTipoReporte.cteAccountCycleDetailTransaction;
                                string tempRefParam24 = mdlParametros.sgPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + llEmpresa.ToString() + "\\";
                                string tempRefParam25 = unilPadre.ResumenRUN.TotalesTH[1].Totales.NumeroCuentaS;
                                prReporteUnidad(unilPadre, ref tempRefParam23, ref tempRefParam24, ref rptlReporte, ref tempRefParam25, ref slNombreEmpresa, ref slSeparador);
                            }
                        }
                    }
                    licont++;
                };
                MessageBox.Show("FIN DE PROCESO", "Generación de " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {


                if (Information.Err().Number == 91)
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
            }

        }

        private void chkNivel_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            if (chkNivel[0].CheckState == CheckState.Checked)
            {
                chkCuentaContable.Enabled = true;
            }
            else
            {
                chkCuentaContable.Enabled = false;
                chkCuentaContable.CheckState = CheckState.Unchecked;
            }
        }

        private void cmdGenerar_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                prGeneraReporteAccCyRep();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdGenerar_Click)", e);
            }
        }


        private void prReporteUnidad(clsREPUnidad objUnidad, ref  mdlREPReportes.cteTipoReporte ipTipoReporte, ref  string spPath, ref  clsREPReporte rptpReporte, ref  string spCuenta, ref  string spNombreEmpresa, ref  string spSeparador)
        {
            string slPrefijo = String.Empty;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (spSeparador.Length == 0 || String.IsNullOrEmpty(spSeparador) || false)
                {
                    spSeparador = new string(' ', 1);
                }
                rptpReporte.InicializaEncabezado();
                switch (ipTipoReporte)
                {
                    case mdlREPReportes.cteTipoReporte.cteAccountCycleSummaryUnit:
                        slPrefijo = "ACUN";
                        rptpReporte.ColumnasPorPaginaI = 147;
                        rptpReporte.CadenaSeparadorS = new string('-', rptlReporte.ColumnasPorPaginaI);
                        mdlREPReportes.prGeneraEncabezado(objUnidad, rptpReporte, ref spCuenta, ref spNombreEmpresa, spSeparador);
                        break;
                    case mdlREPReportes.cteTipoReporte.cteAccountCycleSummaryTH:
                        slPrefijo = "ACTH";
                        rptpReporte.ColumnasPorPaginaI = 241;
                        rptpReporte.CadenaSeparadorS = new string('-', rptlReporte.ColumnasPorPaginaI);
                        mdlREPReportes.prAgregaEncabezadoTHaReporte(objUnidad, rptpReporte, ref spCuenta, ref spNombreEmpresa, ref spSeparador, chkCuentaContable.CheckState != CheckState.Unchecked);
                        break;
                    case mdlREPReportes.cteTipoReporte.cteAccountCycleDetailTransaction:
                        slPrefijo = "ACDT";
                        rptpReporte.ColumnasPorPaginaI = 143;
                        rptpReporte.CadenaSeparadorS = new string('-', rptlReporte.ColumnasPorPaginaI);
                        mdlREPReportes.prAgregaEncabezadoTransaccionATHRep(objUnidad, rptpReporte, ref spCuenta, ref spNombreEmpresa, ref spSeparador);
                        break;
                }
                rptpReporte.InicializaCuerpo();
                mdlREPReportes.cteTipoReporte tempRefParam = ipTipoReporte;
                mdlREPReportes.prGenerarReporte(ref rptpReporte, ref objUnidad, ref tempRefParam, ref spSeparador, chkCuentaContable.CheckState != CheckState.Unchecked); //Generar reporte
                rptpReporte.InicializaPiePagina();
                mdlREPReportes.prGeneraPiePagina(objUnidad, rptpReporte, ipTipoReporte, spSeparador);
                rptpReporte.prGenerarReporte(spPath + "\\" + slPrefijo + objUnidad.EmpresaL.ToString() + objUnidad.IdS + ".txt"); //Imprime el reporte

                if (objUnidad.colUnidades.Count > 0)
                {
                    for (int llUnidad = 1; llUnidad <= objUnidad.colUnidades.Count; llUnidad++)
                    {
                        mdlREPReportes.cteTipoReporte tempRefParam2 = ipTipoReporte;
                        prReporteUnidad(objUnidad.colUnidades[llUnidad], ref tempRefParam2, ref spPath, ref rptpReporte, ref spCuenta, ref spNombreEmpresa, ref spSeparador);
                        Application.DoEvents();
                    }
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("ReporteUnidad", e);
            }
        }

        private void cmdSalir_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            //Carga Grupos
            Carga_Grupos();
            //Carga las empresas
            Obten_Empresas();
            //Selecciona el reporte
            this.chkNivel[0].CheckState = CheckState.Unchecked;
            this.chkNivel[1].CheckState = CheckState.Unchecked;
            this.chkNivel[2].CheckState = CheckState.Unchecked;
            this.chkCuentaContable.Enabled = false;
            this.Cursor = Cursors.Default;
            CRSGeneral.prCargaMesesEnCombo(cboCombo[1]);
            for (int i = 1990; i <= 2050; i++)
            {
                cboCombo[2].Items.Add(Conversion.Str(i));
            }

            for (int i = 0; i <= cboCombo[2].Items.Count - 1; i++)
            {
                if (VB6.GetItemString(cboCombo[2], i).Trim() == DateTime.Now.ToString("yyyy").Trim())
                {
                    cboCombo[2].SelectedIndex = i;
                    break;
                }
            }
            //slPath = "C:\\Corporativa\\Empresas";
            slSeparador = " ";
        }

        private void frmAccCyRep_Closed(Object eventSender, EventArgs eventArgs)
        {
            unilPadre = null;
            rptlReporte = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private int Carga_Grupos()
        {
            string pszNomGrupo = String.Empty; //El grupo a obtener
            int iNumGrupo = 0; //El consecutivo del grupo
            int iTempErr = 0; //Para control local
            int icont = 0;
            this.Cursor = Cursors.WaitCursor;
            int iErr = CORCONST.OK;

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            //ros  iTotalGrupos = Cuenta_Registros
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_CEM_GRP_COB.Items.Clear();
                icont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros And iCont < INT_MAX_GRUPOS
                    iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_CEM_GRP_COB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
                    icont++;
                };
                //ros     iGruposRestantes = iGruposRestantes - iCont
                //Colocamos a un grupo por default
                if (ID_CEM_GRP_COB.Items.Count != 0)
                {
                    ID_CEM_GRP_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //ros  iGruposRestantes = iTotalGrupos - iCont
            //ros  Carga_Grupos = iTotalGrupos

            this.Cursor = Cursors.Default;

            return 0;
        }


        private int Obten_Empresas()
        {
            int result = 0;
            int iTempErr = 0; //Control local
            string pszEmpresa = String.Empty; //La empresa a obtener
            int iNumEmpresa = 0; //El consecutivo de la empresa
            int icont = 0;
            this.Cursor = Cursors.WaitCursor;
            int iErr = CORCONST.OK;
            int iNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 4)))); //El grupo de quien se trata
            CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + iNumGrupo.ToString();
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_CEM_EMP_LB.Items.Clear();
                icont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros And iCont < INT_MAX_EMPRESAS
                    iNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    //EISSA 03-10-2001 Cambio para formatear número de empresa.
                    ID_CEM_EMP_LB.Items.Add(StringsHelper.Format(iNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
                    icont++;
                };
                //ros    iEmpresasRestantes = iEmpresasRestantes - iCont
                if (ID_CEM_EMP_LB.Items.Count != 0)
                {
                    ID_CEM_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
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
                ID_CEM_EMP_LB.Items.Clear();
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;
            return result;
        }

        private void ID_CEM_GRP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            ID_CEM_EMP_LB.Items.Clear();
            Obten_Empresas();
        }
    }
}