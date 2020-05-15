using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class frmIntBusqueda
        : System.Windows.Forms.Form
    {

        private void frmIntBusqueda_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        private void chkIntBusqueda_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            mskIntBusqueda.Enabled = chkIntBusqueda.CheckState == CheckState.Checked;
        }

        private void cmbIntBusqueda_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(cmbIntBusqueda, eventSender);
            int llIndice = 0;

            switch (Index)
            {
                case 0:  //Corporativo 
                    this.Cursor = Cursors.WaitCursor;
                    llIndice = mdlParametros.gccrpCorporativo.fncBuscaCorporativoL(mdlParametros.gprdProducto, StringsHelper.IntValue(cmbIntBusqueda[Index].Text.Substring(0, Math.Min(cmbIntBusqueda[Index].Text.Length, mdlParametros.ctelCorporativo))));
                    mdlParametros.gcrpCorporativo = mdlParametros.gccrpCorporativo[llIndice];
                    mdlParametros.gcrpCorporativo.colCatEmpresas.prObtenEmpresa(ref mdlParametros.gcrpCorporativo);
                    mdlCatalogos.prLlenaCombo(mdlParametros.gcrpCorporativo.colCatEmpresas, cmbIntBusqueda[1]);
                    this.Cursor = Cursors.Default;
                    break;
                case 1:  //Empresa 
                    this.Cursor = Cursors.WaitCursor;
                    if (cmbIntBusqueda[Index].SelectedIndex == 0)
                    {
                        cmbIntBusqueda[2].Items.Insert(0, "Todos");
                        cmbIntBusqueda[2].SelectedIndex = 0;
                        cmbIntBusqueda[2].Enabled = false;
                    }
                    else
                    {
                        cmbIntBusqueda[2].Enabled = true;
                        llIndice = mdlParametros.gcrpCorporativo.colCatEmpresas.fncBuscaEmpresaL(mdlParametros.gcrpCorporativo.ProductoPRD, mdlParametros.gcrpCorporativo, StringsHelper.IntValue(CRSGeneral.vfncVPO(cmbIntBusqueda[Index].Text, "0").Substring(0, Math.Min(CRSGeneral.vfncVPO(cmbIntBusqueda[Index].Text, "0").Length, mdlParametros.gprdProducto.LongitudEmpresaI))));
                        if (llIndice > 0)
                        {
                            mdlParametros.gempEmpresa = mdlParametros.gcrpCorporativo.colCatEmpresas[llIndice];
                            mdlParametros.gempEmpresa.prUnidadPadre(mdlParametros.gempEmpresa.EmpresaL);
                            if (mdlParametros.gempEmpresa.UnidadUNI != null)
                            {
                                mdlParametros.gempEmpresa.UnidadUNI.prConstruyeJerarquia();
                                mdlParametros.gempEmpresa.UnidadUNI.prConstruyeLista();
                                mdlCatalogos.prLlenaCombo(mdlParametros.gempEmpresa.UnidadUNI.ListaCUNI, cmbIntBusqueda[2]);
                            }
                            else
                            {
                                cmbIntBusqueda[2].Items.Clear();
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;
                    break;
            }
        }

        private void cmdIntBusqueda_Click(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(cmdIntBusqueda, eventSender);
            try
            {
                switch (Index)
                {
                    case 0:  //Aceptar 
                        prLlenaSpreadIntBusqueda();
                        break;
                    case 1:  //Cancelar 
                        this.Close();
                        break;
                    case 2:  //Inicia Busqueda 
                        prIniciaBusqueda();
                        break;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdIntBusqueda_Click)", e);
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            this.Cursor = Cursors.WaitCursor;
            mdlParametros.gccrpCorporativo = new colCatCorporativos();
            mdlParametros.gcempEmpresa = new colCatEmpresas();
            mdlParametros.gcuniUnidad = new colCatUnidades();
            //AIS-541 NGONZALEZ
            mdlParametros.gcrepReporte = new colCatReporte();
            mdlParametros.gcrpCorporativo = new clsCorporativo();
            mdlParametros.gempEmpresa = new clsEmpresa();
            mdlParametros.guniUnidad = new clsUnidad();
            mdlParametros.grepReporte = new clsReporte();
            chkIntBusqueda.CheckState = CheckState.Checked;
            mskIntBusqueda.CtlText = DateTime.Now.ToString("dd/MM/yyyy");
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            mdlParametros.gcrepReporte.prObtenReportes();
            mdlCatalogos.prLlenaCombo(mdlParametros.gcrepReporte, cmbIntBusqueda[3]);
            mdlParametros.gccrpCorporativo.prObtenCorporativos(ref mdlParametros.gprdProducto);
            mdlCatalogos.prLlenaCombo(mdlParametros.gccrpCorporativo, cmbIntBusqueda[0]);
            this.Cursor = Cursors.Default;
        }

        private void prLlenaSpreadIntBusqueda()
        {

            bool blGrupo = false;
            bool blEmpresa = false;
            bool blUnidad = false;
            bool blReporte = false;
            string slReporte = String.Empty;
            bool blFecha = false;
            string slFecha = String.Empty;
            bool blTransmitido = false;
            bool blNoTransmitido = false;
            bool blTodos = false;
            int ilCont = 0;
            int llRow = 0;
            string slAño = String.Empty;
            string slMes = String.Empty;
            string slDia = String.Empty;

            try
            {

                this.Cursor = Cursors.WaitCursor;

                if (cmbIntBusqueda[0].SelectedIndex != -1)
                { //Corporativos
                    blGrupo = true;
                    if (cmbIntBusqueda[1].SelectedIndex != -1 && cmbIntBusqueda[1].SelectedIndex != 0)
                    { //Empresas
                        blEmpresa = true;
                        if (cmbIntBusqueda[2].SelectedIndex != -1 && cmbIntBusqueda[2].SelectedIndex != 0)
                        { //Unidades
                            blUnidad = true;
                            if (cmbIntBusqueda[3].SelectedIndex != -1 && cmbIntBusqueda[3].SelectedIndex != 0)
                            { //Reportes
                                blReporte = true;
                                slReporte = mdlParametros.gcrepReporte[mdlParametros.gcrepReporte.fncBuscaReporteL(StringsHelper.IntValue(cmbIntBusqueda[3].Text.Substring(0, Math.Min(cmbIntBusqueda[3].Text.Length, mdlParametros.ctelMascaraRep)).Trim()))].ReporteIdS;
                            }
                            else
                            {
                                blReporte = false;
                            }
                        }
                        else
                        {
                            blUnidad = false;
                        }
                    }
                    else
                    {
                        blEmpresa = false;
                    }
                }
                else
                {
                    blGrupo = false;
                }
                //Estatus
                if (!optIntBusqueda[0].Checked) //AIS-576 echasiquiza
                { //Transmitido
                    blTransmitido = false;
                    if (!optIntBusqueda[1].Checked) //AIS-576 echasiquiza
                    { //No Transmitidos
                        blNoTransmitido = false;
                        if (!optIntBusqueda[2].Checked) //AIS-576 echasiquiza
                        { //Todos
                            blTodos = false;
                        }
                        else
                        {
                            blTodos = true;
                        }
                    }
                    else
                    {
                        blNoTransmitido = true;
                    }
                }
                else
                {
                    blTransmitido = true;
                }
                //Fecha
                if (chkIntBusqueda.CheckState == CheckState.Checked)
                {
                    if (Information.IsDate(mskIntBusqueda.CtlText))
                    {
                        slAño = mskIntBusqueda.CtlText.Substring(mskIntBusqueda.CtlText.Length - Math.Min(mskIntBusqueda.CtlText.Length, 4)).Trim();
                        slMes = Strings.Mid(mskIntBusqueda.CtlText, 4, 2).Trim();
                        slDia = mskIntBusqueda.CtlText.Substring(0, Math.Min(mskIntBusqueda.CtlText.Length, 2)).Trim();
                        slFecha = (slAño + slMes + slDia).Trim();
                        blFecha = true;
                    }
                    else
                    {
                        MessageBox.Show("La fecha no es correcta. ¡Verifica!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    blFecha = true;
                }

                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " env_arch_origen,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " rep_id,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " env_estatus,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " env_fecha_archivo";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCENV01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                if (blEmpresa)
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + StringsHelper.IntValue(cmbIntBusqueda[1].Text.Substring(0, Math.Min(cmbIntBusqueda[1].Text.Length, mdlParametros.gprdProducto.LongitudEmpresaI)).Trim()).ToString();
                    if (blUnidad)
                    {
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + Conversion.Val(cmbIntBusqueda[2].Text.Substring(0, Math.Min(cmbIntBusqueda[2].Text.Length, mdlParametros.ctelUnidades))).ToString().Trim() + "'";
                        if (blReporte)
                        {
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and env_arch_origen like '%" + slReporte + "%'";
                        }
                    }
                }
                if (!blTransmitido)
                {
                    if (!blNoTransmitido)
                    {
                        if (blTodos)
                        {
                        }
                    }
                    else
                    {
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and env_estatus in (" + ((int)clsEstatusEnvio.iEstatusEnvio.NoTransmitido).ToString() + "," + ((int)clsEstatusEnvio.iEstatusEnvio.Pendiente).ToString() + ")";
                    }
                }
                else
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and env_estatus = " + ((int)clsEstatusEnvio.iEstatusEnvio.Transmitido).ToString();
                }
                if (blFecha)
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and env_fecha_archivo like '" + slFecha + "%'";
                }
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and dest_id = 1";


                sprIntBusqueda.MaxRows = 0;

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    llRow = 1;

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        sprIntBusqueda.MaxRows++;
                        sprIntBusqueda.Row = llRow;
                        for (int llCol = 1; llCol <= 6; llCol++)
                        {
                            sprIntBusqueda.Col = llCol;
                            sprIntBusqueda.Lock = true;
                            switch (llCol)
                            {
                                case 1:
                                    sprIntBusqueda.Text = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim(), mdlParametros.gprdProducto.MascaraEmpresaS);
                                    break;
                                case 2:
                                    sprIntBusqueda.Text = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim(), mdlParametros.ctesUnidades);
                                    break;
                                case 3:
                                    string tempRefParam = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                                    sprIntBusqueda.Text = mdlParametros.gcrepReporte.fncBuscaNombreReporteS(ref tempRefParam);
                                    break;
                                case 4:
                                    sprIntBusqueda.Text = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                    break;
                                case 5:
                                    double switchVar = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
                                    if (switchVar == ((int)clsEstatusEnvio.iEstatusEnvio.Transmitido))
                                    {
                                        sprIntBusqueda.Text = " OK ";
                                    }
                                    else if (switchVar == ((int)clsEstatusEnvio.iEstatusEnvio.NoTransmitido))
                                    {
                                        sprIntBusqueda.Text = " NO TRANSMITIDO ";
                                    }
                                    else if (switchVar == ((int)clsEstatusEnvio.iEstatusEnvio.Pendiente))
                                    {
                                        sprIntBusqueda.Text = " PENDIENTE POR TRANSMITIR ";
                                    }
                                    break;
                                case 6:
                                    sprIntBusqueda.Text = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim().Substring(VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim().Length - Math.Min(VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim().Length, 2)) + CRSParametros.cteSeparadorFecha + Strings.Mid(VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim(), 5, 2) + CRSParametros.cteSeparadorFecha + VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim().Substring(0, Math.Min(VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim().Length, 4));
                                    break;
                            }
                        }
                        llRow++;
                    };
                }
                if (llRow == 0)
                {
                    MessageBox.Show("No se encontro ningun registro con los parametros especificados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    return;
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("LlenaSpreadIntBusqueda", e);
                this.Cursor = Cursors.Default;
                return;
            }
        }

        private void prIniciaBusqueda()
        {
            sprIntBusqueda.MaxRows = 0;
            for (int ilContador = 0; ilContador <= 3; ilContador++)
            {
                cmbIntBusqueda[ilContador].SelectedIndex = 0;
            }
            for (int ilContador = 0; ilContador <= 2; ilContador++)
            {
                optIntBusqueda[ilContador].Checked = false; //AIS-576 echasiquiza
            }
            mskIntBusqueda.CtlText = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void frmIntBusqueda_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}