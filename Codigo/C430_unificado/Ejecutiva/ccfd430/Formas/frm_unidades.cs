using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class frm_unidades
        : System.Windows.Forms.Form
    {

        private void frm_unidades_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        const int INT_MAX_EDO = 999;
        const int LNG_MAX_UNIDAD = 99999;
        int lEstruc_Gastos = 0;
        int lTotalEdo = 0;
        int iRenCat = 0;
        int iRenRep = 0;
        string sRep_ID = String.Empty;
        string sRep_Name = String.Empty;
        string sFreq = String.Empty;
        string sDetail = String.Empty;
        string sDepth = String.Empty;
        string sCat_Id = String.Empty;
        string sCat_Nombre = String.Empty;
        string sLimit = String.Empty;
        string sPor_Uso = String.Empty;
        bool bNivPadre = false;
        string sNivPadre = String.Empty;
        string sMensajeGeneral = String.Empty;

        private void cmd_agregar_Click(Object eventSender, EventArgs eventArgs)
        {
            lstUniRpr.Items.Add(StringsHelper.Format(Conversion.Str(mkbMaskebox[17].CtlText.Trim()), "00"));
            mkbMaskebox[17].CtlText = "";
        }

        private void cmd_quitar_Click(Object eventSender, EventArgs eventArgs)
        {
            lstUniRpr.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(lstUniRpr));
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int i = 0;
            int iCont = 0;
            string lstrEmp = String.Empty;
            string s = String.Empty;
            int reg = 0;
            string sCadRpr = String.Empty;
            string sCadRprTemp = String.Empty;
            int iInicio = 0;

            this.Height = (int)VB6.TwipsToPixelsY(7140);
            this.Width = (int)VB6.TwipsToPixelsX(9645);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            CRSGeneral.prCargaEstadoEnCombo(cmbCombo[0]);

            switch (Formato.sgForma)
            {
                case "A":  //Altas 
                    txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto[0].Enabled = false;
                    txtTexto[1].Text = mdlParametros.gprdProducto.ProductoS + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, mdlParametros.gprdProducto.LongitudEmpresaI))).ToString().Trim(), mdlParametros.gprdProducto.MascaraEmpresaS) + StringsHelper.Format("0", mdlParametros.gprdProducto.MascaraEjecutivoS) + Formato.Formato_Cad_Roll_Digit();
                    txtTexto[1].Enabled = false;
                    mkbMaskebox[2].Enabled = false;

                    if (Strings.Len(txtTexto[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }
                    else
                    {
                        Formato.bgForma = true;
                    }

                    mkbMaskebox[2].Format = "00";

                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));

                    bNivPadre = true;
                    if (validaNivPadre() == 0)
                    {
                        //**Si la Unidad a dar de alta no tiene ninguna Unidad Padre**
                        bNivPadre = false;
                        mkbMaskebox[1].CtlText = ""; //En el campo de Unidad Padre no se pone nada
                        mkbMaskebox[2].CtlText = "1"; //En el campo de Nivel se pone 1
                        mkbMaskebox[1].Enabled = false; //Se deshabilita para que no se pueda poner nada
                        mkbMaskebox[2].Enabled = false; //Se deshabilita para que no se pueda poner nada
                        mkbMaskebox[15].Visible = false;
                        mkbMaskebox[16].Visible = false;
                        lblEtiqueta[19].Visible = false;
                        lblEtiqueta[20].Visible = false;
                    }

                    cmbCombo[0].SelectedIndex = -1;
                    txtTexto[2].Text = "MEX";
                    lstUniRpr.Items.Clear();
                    mkbMaskebox[0].MaxLength = (short)LNG_MAX_UNIDAD.ToString().Length;
                    mkbMaskebox[1].MaxLength = (short)LNG_MAX_UNIDAD.ToString().Length;
                    mkbMaskebox[15].MaxLength = (short)LNG_MAX_UNIDAD.ToString().Length;

                    break;
                case "B":  //Cambios 
                    txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto[1].Text = mdlParametros.gprdProducto.ProductoS + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, mdlParametros.gprdProducto.LongitudEmpresaI))).ToString().Trim(), mdlParametros.gprdProducto.MascaraEmpresaS) + StringsHelper.Format("0", mdlParametros.gprdProducto.MascaraEjecutivoS) + Formato.Formato_Cad_Roll_Digit();

                    if (Strings.Len(txtTexto[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }

                    Formato.bgForma = true;
                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                    mkbMaskebox[0].Enabled = false;
                    mkbMaskebox[1].Enabled = false;
                    mkbMaskebox[2].Enabled = false;
                    mkbMaskebox[2].Format = "00";
                    txtTexto[0].Enabled = false;
                    txtTexto[1].Enabled = false;
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_head_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + CORVAR.igblNumGrupo.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim() + "'";

                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                mkbMaskebox[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim(); //Unidad
                                mkbMaskebox[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim(); //Unidad Padre
                                mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString(); //Nivel
                                mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim(); //Nombre
                                //***JPU***
                                sCadRpr = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim(); //Representante
                                sCadRprTemp = sCadRpr.Substring(0, Math.Min(sCadRpr.Length, 2));
                                iInicio = 1;

                                while (sCadRprTemp != "")
                                {
                                    lstUniRpr.Items.Add(sCadRprTemp);
                                    iInicio += 2;
                                    sCadRprTemp = Strings.Mid(sCadRpr, iInicio, 2);
                                };
                                //***JPU***
                                mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim(); //Responsable
                                mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim(); //Domicilio
                                mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim(); //Colonia
                                mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim(); //Poblacion
                                mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim(); //Ciudad
                                CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim()); //Estado
                                txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim(); //Pais
                                mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim(); //CP
                                mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim(); //Telefono
                                mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim(); //Extension
                                mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim(); //Fax
                                mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim(); //Celular
                                txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 18).Trim(); //Email
                            };
                            mkbMaskebox[15].Enabled = false;
                            mkbMaskebox[16].Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Cursor = Cursors.Default;

                    break;
                case "C":  //Consultas 
                    txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                    txtTexto[1].Text = mdlParametros.gprdProducto.ProductoS + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, mdlParametros.gprdProducto.LongitudEmpresaI))).ToString().Trim(), mdlParametros.gprdProducto.MascaraEmpresaS) + StringsHelper.Format("0", mdlParametros.gprdProducto.MascaraEjecutivoS) + Formato.Formato_Cad_Roll_Digit();
                    if (Strings.Len(txtTexto[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }
                    Formato.bgForma = true;
                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                    mkbMaskebox[0].Enabled = false;
                    mkbMaskebox[1].Enabled = false;
                    mkbMaskebox[2].Enabled = false;
                    mkbMaskebox[2].Format = "00";
                    txtTexto[0].Enabled = false;
                    txtTexto[1].Enabled = false;
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_head_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + CORVAR.igblNumGrupo.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim() + "'";
                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                mkbMaskebox[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim(); //Unidad
                                mkbMaskebox[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim(); //Unidad Padre
                                mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString(); //Nivel
                                mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim(); //Nombre
                                //***JPU***
                                sCadRpr = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim(); //Representante
                                sCadRprTemp = sCadRpr.Substring(0, Math.Min(sCadRpr.Length, 2));
                                iInicio = 1;

                                while (sCadRprTemp != "")
                                {
                                    lstUniRpr.Items.Add(sCadRprTemp);
                                    iInicio += 2;
                                    sCadRprTemp = Strings.Mid(sCadRpr, iInicio, 2);
                                };
                                //***JPU***
                                mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim(); //Responsable
                                mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim(); //Domicilio
                                mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim(); //Colonia
                                mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim(); //Poblacion
                                mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim(); //Ciudad
                                CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim()); //Estado
                                txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim(); //Pais
                                mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim(); //CP
                                mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim(); //Telefono
                                mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim(); //Extension
                                mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim(); //Fax
                                mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim(); //Celular
                                txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 18).Trim(); //Email
                            };
                            ID_MEE_ALT_PB.Visible = false;
                        }
                        Des_Habilita_Forma(2);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Cursor = Cursors.Default;

                    break;
                case "D":  //Consultas con Ir a.. 
                    if (Formato.bgForma)
                    {
                        txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                        txtTexto[1].Text = mdlParametros.gprdProducto.ProductoS + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, mdlParametros.gprdProducto.LongitudEmpresaI))).ToString().Trim(), mdlParametros.gprdProducto.MascaraEmpresaS) + StringsHelper.Format("0", mdlParametros.gprdProducto.MascaraEjecutivoS) + Formato.Formato_Cad_Roll_Digit();
                        if (Strings.Len(txtTexto[1].Text) < 16)
                        {
                            Formato.bgForma = false;
                            return;
                        }
                        Formato.bgForma = true;
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                        mkbMaskebox[0].Enabled = false;
                        mkbMaskebox[1].Enabled = false;
                        mkbMaskebox[2].Enabled = false;
                        mkbMaskebox[2].Format = "00";
                        txtTexto[0].Enabled = false;
                        txtTexto[1].Enabled = false;
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_head_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_UNI_LB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim() + "'";
                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    mkbMaskebox[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim(); //Unidad
                                    mkbMaskebox[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim(); //Unidad Padre
                                    mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString(); //Nivel
                                    mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim(); //Nombre
                                    //***JPU***
                                    sCadRpr = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim(); //Representante
                                    sCadRprTemp = sCadRpr.Substring(0, Math.Min(sCadRpr.Length, 2));
                                    iInicio = 1;

                                    while (sCadRprTemp != "")
                                    {
                                        lstUniRpr.Items.Add(sCadRprTemp);
                                        iInicio += 2;
                                        sCadRprTemp = Strings.Mid(sCadRpr, iInicio, 2);
                                    };
                                    //***JPU***
                                    mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim(); //Responsable
                                    mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim(); //Domicilio
                                    mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim(); //Colonia
                                    mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim(); //Poblacion
                                    mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim(); //Ciudad
                                    CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim()); //Estado
                                    txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim(); //Pais
                                    mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim(); //CP
                                    mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim(); //Telefono
                                    mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim(); //Extension
                                    mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim(); //Fax
                                    mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim(); //Celular
                                    txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 18).Trim(); //Email
                                };
                                ID_MEE_ALT_PB.Visible = false;
                            }
                            Des_Habilita_Forma(2);
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Cursor = Cursors.Default;
                    }

                    break;
                case "E":  //Cambios Ir a... 
                    if (Formato.bgForma)
                    {
                        txtTexto[0].Text = Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, Formato.igLongitudEmpresa + 4, 45);
                        txtTexto[1].Text = mdlParametros.gprdProducto.ProductoS + StringsHelper.Format(Conversion.Val(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text.Length, mdlParametros.gprdProducto.LongitudEmpresaI))).ToString().Trim(), mdlParametros.gprdProducto.MascaraEmpresaS) + StringsHelper.Format("0", mdlParametros.gprdProducto.MascaraEjecutivoS) + Formato.Formato_Cad_Roll_Digit();
                        if (Strings.Len(txtTexto[1].Text) < 16)
                        {
                            Formato.bgForma = false;
                            return;
                        }
                        Formato.bgForma = true;
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                        mkbMaskebox[0].Enabled = false;
                        mkbMaskebox[1].Enabled = false;
                        mkbMaskebox[2].Enabled = false;
                        mkbMaskebox[2].Format = "00";
                        txtTexto[0].Enabled = false;
                        txtTexto[1].Enabled = false;
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + Formato.sgUnit_ID.Trim() + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_name = '" + Formato.sgName_Unit.Trim() + "'";
                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    mkbMaskebox[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim(); //Unidad
                                    mkbMaskebox[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim(); //Unidad Padre
                                    mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString(); //Nivel
                                    mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim(); //Nombre
                                    mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim(); //Responsable
                                    mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim(); //Domicilio
                                    mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim(); //Colonia
                                    mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim(); //Poblacion
                                    mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim(); //Ciudad
                                    CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim()); //Estado
                                    txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim(); //Pais
                                    mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim(); //CP
                                    mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim(); //Telefono
                                    mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim(); //Extension
                                    mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim(); //Fax
                                    mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim(); //Celular
                                    txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim(); //Email
                                };
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        //MsgBox"No se encontro ninguna Unidad Similar",vbInformation +vbOKOnly ,"Tarjeta Corporativa"
                    }
                    break;
            }

        }

        private bool bValidaNiv()
        {
            bool result = false;
            int iError = 0;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;

            this.Cursor = Cursors.WaitCursor;

            int iConsNiv = Convert.ToInt32(Conversion.Val(mkbMaskebox[2].CtlText));
            if (iConsNiv == 1)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se puede dar de alta la unidad " + mkbMaskebox[0].CtlText + " con el Nivel " + mkbMaskebox[2].CtlText + " porque No es valido el Nivel ", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            else
            {
                if (Conversion.Val(mkbMaskebox[2].CtlText) <= Conversion.Val(sNivPadre))
                {
                    MessageBox.Show("No se puede dar de alta la unidad " + mkbMaskebox[0].CtlText + " con el Nivel " + mkbMaskebox[2].CtlText + " porque No es valido el Nivel ", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                else
                {
                    result = true;
                }
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;

            return result;
        }

        private int validaNivPadre()
        {
            int result = 0;
            int iError = 0;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.pszgblsql = "select unit_id from MTCUNI01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + Conversion.Str(CORVAR.igblPref);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(CORVAR.lgblNumEmpresa);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + Conversion.Str(CORVAR.igblNumGrupo);
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and nivel_num = " + Conversion.Str(1);

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            result = CORPROC2.Cuenta_Registros();

            this.Cursor = Cursors.Default;

            return result;
        }

        private bool bValidaUniPadre()
        {
            bool result = false;
            int iError = 0;
            int iValor = 0;
            int iCont = 0;
            object iTempErr = null;

            this.Cursor = Cursors.WaitCursor;
            if (mkbMaskebox[0].CtlText != mkbMaskebox[1].CtlText)
            {
                CORVAR.pszgblsql = "select nivel_num from MTCUNI01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + Conversion.Str(CORVAR.igblPref);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + Conversion.Str(CORVAR.igblBanco);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(CORVAR.lgblNumEmpresa);
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + mkbMaskebox[1].CtlText.Trim() + "'";

                if (CORPROC2.Cuenta_Registros() <= 0)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No se encontro la Unidad Padre " + mkbMaskebox[1].CtlText, CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }
                else
                {
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            sNivPadre = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim(); //Unidad

                        };
                    }
                    result = true;
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            else
            {
                result = false;
                MdlCambioMasivo.MsgInfo("La unidad padre y la unidad actual no pueden ser la misma");
            }
            this.Cursor = Cursors.Default;

            return result;
        }

        private void Des_Habilita_Forma(int Action)
        {

            switch (Action)
            {
                case 1:
                    for (int i = 0; i <= 13; i++)
                    {
                        mkbMaskebox[i].Enabled = true;
                    }
                    cmbCombo[0].Enabled = true;
                    txtTexto[2].Enabled = true;
                    txtTexto[3].Enabled = true;
                    mkbMaskebox[2].Enabled = false;
                    mkbMaskebox[15].Enabled = true;
                    mkbMaskebox[16].Enabled = false;
                    mkbMaskebox[17].Enabled = true;
                    lstUniRpr.Enabled = true;
                    cmd_agregar.Enabled = true;
                    cmd_quitar.Enabled = true;

                    break;
                case 2:
                    for (int i = 0; i <= 13; i++)
                    {
                        mkbMaskebox[i].Enabled = false;
                    }
                    cmbCombo[0].Enabled = false;
                    txtTexto[2].Enabled = false;
                    txtTexto[3].Enabled = false;
                    mkbMaskebox[15].Enabled = false;
                    mkbMaskebox[16].Enabled = false;
                    mkbMaskebox[17].Enabled = false;
                    lstUniRpr.Enabled = false;
                    cmd_agregar.Enabled = false;
                    cmd_quitar.Enabled = false;

                    break;
            }

        }

        private void ID_MEE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            StringBuilder sCadRpr = new StringBuilder();
            sCadRpr.Append(String.Empty);
            string sCadRprTemp = String.Empty;
            int modif = 0;
            try
            {

                switch (Formato.sgForma)
                {
                    case "A":
                        if (Valida_Datos())
                        {
                            CORVAR.pszgblsql = "insert into MTCUNI01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_num,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_head_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_last_upd_userid,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_last_upd_date,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_last_upd_time)";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " values ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString(); //eje_prefijo
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString(); //gpo_banco
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString(); //emp_num
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblNumGrupo.ToString(); //gpo_num
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Conversion.Str(Double.Parse(mkbMaskebox[0].CtlText)).Trim() + "'"; //unit_id
                            if (!bNivPadre)
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",NULL"; //unit_parent_id
                            }
                            else if (bNivPadre)
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[1].CtlText.Trim() + "'"; //unit_parent_id
                            }
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Val(mkbMaskebox[2].CtlText).ToString(); //nivel_num
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[3].CtlText.Trim() + "'"; //unit_name

                            //***JPU***  Se extrae el representante
                            for (int i = 0; i <= lstUniRpr.Items.Count - 1; i++)
                            {
                                lstUniRpr.SelectedIndex = i;
                                sCadRprTemp = lstUniRpr.Text;
                                if (sCadRpr.ToString() == "")
                                {
                                    sCadRpr = new StringBuilder(sCadRprTemp.Trim());
                                }
                                else
                                {
                                    sCadRpr.Append(sCadRprTemp.Trim());
                                }
                            }
                            //***JPU***

                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + sCadRpr.ToString() + "'"; //unit_head_name
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[4].CtlText + "'"; //unit_receipient_name
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[5].CtlText + "'"; //unit_calle
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[6].CtlText + "'"; //unit_col
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[7].CtlText + "'"; //unit_pob
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[8].CtlText + "'"; //unit_city
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSGeneral.asgEstados[0, cmbCombo[0].SelectedIndex] + "'"; //unit_state
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[9].CtlText + "'"; //unit_zip
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[10].CtlText + "'"; //unit_ph
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[11].CtlText + "'"; //unit_ext
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[12].CtlText + "'"; //unit_fax
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox[13].CtlText + "'"; //unit_cel
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + txtTexto[3].Text + "'"; //unit_email
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + txtTexto[2].Text + "'"; //unit_ctry
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserID + "'"; //unit_last_upd_userid
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20),getdate(),112))"; //unit_last_upd_date
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100"; //unit_last_upd_time
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " + convert(int, datepart(mi,getdate())))"; //unit_last_upd_time

                            if (CORPROC2.Modifica_Registro() == 1)
                            {
                                if (!bNivPadre)
                                {
                                    CORVAR.pszgblsql = "update MTCEJE01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_centro_c = '" + mkbMaskebox[0].CtlText.Trim() + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                    if (CORPROC2.Modifica_Registro() == 1)
                                    {
                                    }
                                }
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Se ha dado de alta la Unidad: " + mkbMaskebox[0].CtlText, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Formato.sgUni = new String(' ', 15);
                                Formato.sgUni = StringsHelper.MidAssignment(Formato.sgUni, 1, mkbMaskebox[0].CtlText);
                                CORCTUNI.DefInstance.ID_CEE_UNI_LB.Items.Add(Formato.sgUni + CORCONST.SPC_TRES + mkbMaskebox[3].CtlText.Trim());
                                Limpia_Forma();

                                if (!bNivPadre)
                                {
                                    this.Close();
                                }
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("No se pudo dar de alta la Unidad: " + mkbMaskebox[0].CtlText, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (sMensajeGeneral == "Representante")
                            {
                                MessageBox.Show("Se necesita tener un Representante", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Verifique la información de " + sMensajeGeneral + " por favor", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Cursor = Cursors.Default;

                        break;
                    case "B":
                    case "E":
                        if (Valida_Datos())
                        {
                            for (int i = 0; i <= lstUniRpr.Items.Count - 1; i++)
                            {
                                lstUniRpr.SelectedIndex = i;
                                sCadRprTemp = lstUniRpr.Text;
                                if (sCadRpr.ToString() == "")
                                {
                                    sCadRpr = new StringBuilder(sCadRprTemp.Trim());
                                }
                                else
                                {
                                    sCadRpr.Append(sCadRprTemp.Trim());
                                }
                            }
                            CORVAR.pszgblsql = "update MTCUNI01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " set unit_name = '" + mkbMaskebox[3].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_receipient_name = '" + mkbMaskebox[4].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_head_name = '" + sCadRpr.ToString() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_calle = '" + mkbMaskebox[5].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_col = '" + mkbMaskebox[6].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_pob = '" + mkbMaskebox[7].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_city = '" + mkbMaskebox[8].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_state = '" + CRSGeneral.asgEstados[0, cmbCombo[0].SelectedIndex] + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_ctry = '" + txtTexto[2].Text.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_zip = '" + mkbMaskebox[9].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_ph = '" + mkbMaskebox[10].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_ext = '" + mkbMaskebox[11].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_fax = '" + mkbMaskebox[12].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_cel = '" + mkbMaskebox[13].CtlText.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_email = '" + txtTexto[3].Text.Trim() + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_last_upd_userid = '" + CRSParametros.sgUserID + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_last_upd_date = convert(int,convert(char(20), getdate(),112))";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , unit_last_upd_time = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num  = " + CORVAR.igblNumGrupo.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + mkbMaskebox[0].CtlText + "'";

                            //If Val(mkbMaskebox(1).Text) <> 0 Then
                            //    pszgblsql = pszgblsql & " and unit_parent_id = '" & mkbMaskebox(1).Text & "'"
                            //End If
                            //pszgblsql = pszgblsql & " and nivel_num = " & mkbMaskebox(2).Text

                            if (CORPROC2.Modifica_Registro() == 1)
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("Se ha dado de alta el cambio de la Unidad: " + mkbMaskebox[0].CtlText, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudieron cambiar los datos de la Unidad: " + mkbMaskebox[0].CtlText, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpia_Forma();
                            }
                        }
                        else
                        {
                            if (sMensajeGeneral == "Representante")
                            {
                                MessageBox.Show("Se necesita tener un Representante", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Verifique la información de " + sMensajeGeneral + " por favor", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Cursor = Cursors.Default;
                        break;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEE_ALT_PB_Click)", e);
            }

        }

        private void ID_MEE_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void lstUniRpr_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;
            if (KeyCode == ((int)Keys.Delete))
            {
                lstUniRpr.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(lstUniRpr));
            }
        }

        private void mkbMaskebox_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            int Index = Array.IndexOf(mkbMaskebox, eventSender);
            switch (Index)
            {
                case 0:  //Unidad 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
                    break;
                case 1:  //Unidad Padre
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
                    break;
                case 2:  //Nivel 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
                    break;
                case 3:  //Nombre 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, false, true);
                    break;
                case 4:  //Responsable 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, false, true);
                    break;
                case 5:  //Domicilio 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, false, true, ".,-#");
                    break;
                case 6:  //Colonia 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, false, true, ".,-#");
                    break;
                case 7:  //Pob./Del./Mun. 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, false, true);
                    break;
                case 8:  //Ciudad 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, false, true);
                    break;
                case 9:  //CP 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValEntero, false, false);
                    break;
                case 10:  //Telef 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValTelefonico, false, false);
                    break;
                case 11:  //Ext 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValTelefonico, false, false);
                    break;
                case 12:  //Fax 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValTelefonico, false, false);
                    break;
                case 13:  //Cel 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValTelefonico, false, false);
                    break;
                case 15:  //Copiar de Unidad (Unidad) 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
                    break;
                case 16:  //Copiar de Unidad (Nivel) 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
                    break;
                case 17:  //Numero de Representante 
                    //***JPU*** 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValEntero, false, false);
                    //AIS-1094 NGONZALEZ
                    if (eventArgs.keyAscii == ((int)Keys.Return))
                    {
                        if (mkbMaskebox[17].CtlText != "")
                        {
                            lstUniRpr.Items.Add(StringsHelper.Format(Conversion.Str(mkbMaskebox[17].CtlText.Trim()), "00"));
                            mkbMaskebox[17].CtlText = "";
                        }
                    }
                    //***JPU*** 
                    break;
            }
        }

        private void mkbMaskebox_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int Index = Array.IndexOf(mkbMaskebox, eventSender);
            switch (Index)
            {
                case 0:
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        mkbMaskebox[Index].CtlText = StringsHelper.Format(Double.Parse(mkbMaskebox[Index].CtlText), "###############");

                    }

                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        mkbMaskebox[15].CtlText = "";
                        mkbMaskebox[15].Enabled = false;
                        mkbMaskebox[16].CtlText = "";
                        mkbMaskebox[16].Enabled = false;


                        if (Double.Parse(mkbMaskebox[Index].CtlText) > LNG_MAX_UNIDAD)
                        {
                            MdlCambioMasivo.MsgInfo("La unidad excede del maximo permitido");
                            Cancel = true;
                        }
                    }
                    break;
                case 1:
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        if (Double.Parse(mkbMaskebox[Index].defaultText) <= LNG_MAX_UNIDAD)
                        {
                            if (!bValidaUniPadre())
                            {
                                mkbMaskebox[Index].CtlText = "";
                                Cancel = true;
                            }
                            else
                            {
                                mkbMaskebox[2].CtlText = StringsHelper.Format(Conversion.Val(sNivPadre) + 1, "00"); //Asigna el nivel consecutivo del padre
                            }
                        }
                        else
                        {
                            MdlCambioMasivo.MsgInfo("La unidad seleccionada excede del maximo permitido");
                            Cancel = true;
                        }
                    }

                    break;
                case 2:
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        if (!bValidaNiv())
                        {
                            mkbMaskebox[Index].CtlText = "";
                            Cancel = true;
                        }
                    }

                    break;
                case 15:
                    //If mkbMaskebox(Index).Text <> "" Then 
                    if (mkbMaskebox[Index].CtlText != "")
                    {
                        if (Double.Parse(mkbMaskebox[Index].CtlText) <= LNG_MAX_UNIDAD)
                        {
                            CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(CORCTUNI.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));

                            CORVAR.pszgblsql = "select";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_parent_id,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_receipient_name,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_calle,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_col,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_pob,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_city,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_state,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ctry,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_zip,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ph,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_ext,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_fax,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_cel,";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_email";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + mkbMaskebox[15].CtlText.Trim() + "'";
                            //pszgblsql = pszgblsql & " and nivel_num = " & mkbMaskebox(16).Text

                            if (CORPROC2.Cuenta_Registros() == 1)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        mkbMaskebox[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim(); //Unidad
                                        mkbMaskebox[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim(); //Unidad Padre
                                        mkbMaskebox[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString(); //Nivel
                                        mkbMaskebox[3].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim(); //Nombre
                                        mkbMaskebox[4].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim(); //Responsable
                                        mkbMaskebox[5].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 6).Trim(); //Domicilio
                                        mkbMaskebox[6].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim(); //Colonia
                                        mkbMaskebox[7].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim(); //Poblacion
                                        mkbMaskebox[8].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim(); //Ciudad
                                        CRSGeneral.prBuscaEstado(cmbCombo[0], VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim()); //Estado
                                        txtTexto[2].Text = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim(); //Pais
                                        mkbMaskebox[9].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 12).Trim(); //CP
                                        mkbMaskebox[10].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 13).Trim(); //Telefono
                                        mkbMaskebox[11].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim(); //Extension
                                        mkbMaskebox[12].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 15).Trim(); //Fax
                                        mkbMaskebox[13].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim(); //Celular
                                        txtTexto[3].Text = VBSQL.SqlData(CORVAR.hgblConexion, 17).Trim(); //Email
                                    };
                                }
                                Des_Habilita_Forma(1);
                            }
                            else
                            {
                                if (CORPROC2.Cuenta_Registros() == 0)
                                {
                                    MdlCambioMasivo.MsgInfo("No se encontraron los datos de la Unidad a Copiar");
                                }
                                else
                                {
                                    MdlCambioMasivo.MsgInfo("La unidad búscada está duplicada");
                                }
                            }
                        }
                        else
                        {
                            MdlCambioMasivo.MsgInfo("La unidad seleccionada excede del maximo permitido");
                            Cancel = true;
                        }
                        this.Cursor = Cursors.Default;
                    }
                    //End If 
                    break;
            }
            eventArgs.Cancel = Cancel;
        }

        private bool Valida_Datos()
        {
            bool result = false;

            sMensajeGeneral = "";

            for (int i = 0; i <= 13; i++)
            {
                if (i == 1)
                { //Se valida la Unidad Padre
                    if (Formato.sgForma == "A")
                    {
                        if (bNivPadre)
                        {
                            if (mkbMaskebox[i].CtlText == "")
                            {
                                sMensajeGeneral = "Unidad Padre";
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            //Se valida la Unidad 
                            double dbNumericTemp = 0;
                            if (Double.TryParse(mkbMaskebox[i].CtlText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                            {
                                if (Conversion.Val(mkbMaskebox[i].CtlText) == 0)
                                {
                                    sMensajeGeneral = "Unidad";
                                    return false;
                                }
                                else
                                {
                                    if (mkbMaskebox[1].CtlText == mkbMaskebox[0].CtlText)
                                    {
                                        sMensajeGeneral = "Unidad Padre y la actual no puede ser la misma";
                                        return false;
                                    }

                                }
                            }
                            else
                            {
                                if (mkbMaskebox[i].CtlText == "")
                                {
                                    sMensajeGeneral = "Unidad";
                                    return false;
                                }
                            }

                            break;
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            if (mkbMaskebox[i].CtlText == "")
                            {
                                switch (i)
                                {
                                    case 2:
                                        sMensajeGeneral = "Nivel";
                                        break;
                                    case 3:
                                        sMensajeGeneral = "Nombre";
                                        break;
                                    case 4:
                                        sMensajeGeneral = "Responsable";
                                        break;
                                    case 5:
                                        sMensajeGeneral = "Domicilio";
                                        break;
                                    case 6:
                                        sMensajeGeneral = "Colonia";
                                        break;
                                    case 7:
                                        sMensajeGeneral = "Población";
                                        break;
                                    case 8:
                                        sMensajeGeneral = "Ciudad";
                                        break;
                                }
                                return false;
                            }

                            break;
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                            if (Conversion.Val(mkbMaskebox[i].CtlText) == 0)
                            {
                                switch (i)
                                {
                                    case 9:
                                        sMensajeGeneral = "Codigo Postal";
                                        return false;
                                    case 10:
                                        sMensajeGeneral = "Telefono";
                                        result = true;
                                        break;
                                    case 11:
                                        sMensajeGeneral = "Extención";
                                        result = true;
                                        break;
                                    case 12:
                                        sMensajeGeneral = "Fax";
                                        result = true;
                                        break;
                                    case 13:
                                        sMensajeGeneral = "Celular";
                                        result = true;
                                        break;
                                }
                            }
                            break;
                    }
                }
            }

            if (cmbCombo[0].SelectedIndex == -1)
            {
                sMensajeGeneral = "Estado";
                return false;
            }

            if (txtTexto[2].Text == "")
            {
                sMensajeGeneral = "País";
                return false;
            }


            if (lstUniRpr.Items.Count == 0)
            {
                sMensajeGeneral = "Representante";
                return false;
            }

            switch (Formato.sgForma)
            {
                case "A":
                    //Valida la existencia de la Unidad 
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + mkbMaskebox[0].CtlText.Trim() + "'";

                    if (CORPROC2.Cuenta_Registros() >= 1)
                    {
                        MessageBox.Show("La Unidad " + mkbMaskebox[0].CtlText.Trim() + " esta duplicada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sMensajeGeneral = "Unidad";
                        result = false;
                        mkbMaskebox[0].Focus();
                        return result;
                    }
                    else
                    {
                        result = true;
                    }

                    //Valida la existencia de la Unidad Padre 
                    if (mkbMaskebox[1].CtlText.Trim() == "")
                    {
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_parent_id in (NULL,'') ";

                        if (CORPROC2.Cuenta_Registros() >= 1)
                        {
                            MessageBox.Show("Ya existe una Unidad Padre", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sMensajeGeneral = "Unidad Padre";
                            return false;
                        }
                        else
                        {
                            result = true;
                        }
                    }

                    //Valida la existencia del Nivel 1 
                    if (mkbMaskebox[2].CtlText.Trim() == "1")
                    {
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and nivel_num = 1";

                        if (CORPROC2.Cuenta_Registros() >= 1)
                        {
                            MessageBox.Show("Ya existe una Unidad con nivel 1", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sMensajeGeneral = "Nivel";
                            return false;
                        }
                        else
                        {
                            result = true;
                        }
                    }

                    if (txtTexto[3].Text == "")
                    {
                        sMensajeGeneral = "E-Mail";
                        result = true;
                    }

                    break;
                case "B":
                    result = true;

                    break;
                case "C":
                    result = true;

                    break;
                case "D":
                    result = true;

                    break;
                case "E":
                    result = true;
                    break;
            }

            return result;
        }

        private void Limpia_Forma()
        {

            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i <= 13; i++)
            {
                mkbMaskebox[i].CtlText = "";
            }

            txtTexto[2].Text = "MEX";
            txtTexto[3].Text = "";
            mkbMaskebox[15].CtlText = "";
            mkbMaskebox[16].CtlText = "";
            mkbMaskebox[17].CtlText = "";
            cmbCombo[0].SelectedIndex = -1;
            //cmbCombo(0).Text = ""
            lstUniRpr.Items.Clear();

            if (!mkbMaskebox[1].Enabled)
            {
                mkbMaskebox[1].Enabled = true;
            }
            if (!mkbMaskebox[2].Enabled)
            {
                mkbMaskebox[2].Enabled = true;
            }

            this.Cursor = Cursors.Default;

        }

        private void txtTexto_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            int Index = Array.IndexOf(txtTexto, eventSender);

            switch (Index)
            {
                case 2:
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, false, false);
                    break;
                case 3:
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValCorreoElectrónico, false, false);
                    break;
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void txtTexto_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int Index = Array.IndexOf(txtTexto, eventSender);
            switch (Index)
            {
                case 3:
                    if (Strings.Len(txtTexto[Index].Text) > 0)
                    {
                        if ((txtTexto[Index].Text.IndexOf('@') + 1) == 0 || (txtTexto[Index].Text.IndexOf('@') + 1) == 1 || (txtTexto[Index].Text.IndexOf('@') + 1) == Strings.Len(txtTexto[Index].Text))
                        {
                            Cancel = true;
                            MessageBox.Show("Dirección de Correo electrónico incorrecta." + "\r\n" + "Verifique la dirección.", "Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
            }
            eventArgs.Cancel = Cancel;
        }
        private void frm_unidades_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}