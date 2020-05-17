using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORIREMP
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Forma para captura de una empresa                   **
        //**                    en la busqueda especifica de catalogos              **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int hConexionTemp = 0;
        string pszSentencia = String.Empty;
        int iErr = 0;
        string pszEmpresa = String.Empty;
        string pszNomGrupo = String.Empty;

        private int Conexion()
        {
            return -1;
        }

        private int Existe_Empresa()
        {

            int result = 0;
            int hBufEmpresa = 0;
            int iTempErr = 0;

            this.Cursor = Cursors.WaitCursor;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            CORVAR.pszgblsql = "exec ir_empresa " + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblNumEmpresa.ToString();
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "exec ir_empresa " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblNumEmpresa.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    CORVAR.pszgblNomGrupo = StringsHelper.Format(CORVAR.igblNumGrupo, "0000") + "  " + pszNomGrupo.Trim();
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    result = -1;
                }
                else
                {
                    result = 0;
                }
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.WaitCursor;

            return result;
        }


        private void cmdNuevo_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Height = (int)VB6.TwipsToPixelsY(2300);
            switch (sstFolder[0].SelectedIndex)
            {
                case 1:
                    txtTexto[0].Text = String.Empty;
                    txtTexto[0].Focus();
                    break;
                case 0:
                    lstLista.Items.Clear();
                    txtTexto[1].Text = String.Empty;
                    txtTexto[1].Focus();
                    break;
            }
        }

        private void CORIREMP_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {

                ActivateHelper.myActiveForm = (Form)eventSender;
                this.Cursor = Cursors.Default;
                _txtTexto_0.Text = CORVB.NULL_STRING;
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            this.Height = (int)VB6.TwipsToPixelsY(2300);
            Left = (int)VB6.TwipsToPixelsX(2950);
            Top = (int)VB6.TwipsToPixelsY(1675);
        }

        //UPGRADE_ISSUE: (1057) Event parameter UnloadMode was not upgraded.
        //AIS-999 NGONZALEZ
        private void CORIREMP_Closing(Object eventSender, FormClosingEventArgs eventArgs)
        {
            int Cancel = (eventArgs.Cancel) ? -1 : 0;

            if (eventArgs.CloseReason == CloseReason.UserClosing)
            {
                switch (Tag.ToString())
                {
                    case "CORGRCOM":
                    case "CORGRACL":
                    case "CORGRCRE":
                    case "CORGRANT":
                    case "CORGRVEN":
                    case "CORGRSIT":
                        CORVAR.lgblTempNumEmp = -5;  //-5 Indica que la empresa no fue encontrada o no fue Buscada 
                        CORMDIBN.DefInstance.Enabled = true;
                        break;
                    case "CORRPDAT":
                        CORMDIBN.DefInstance.Enabled = true;
                        break;
                }
            }

            eventArgs.Cancel = Cancel != 0;
        }

        private void ID_IRA_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            switch (Tag.ToString())
            {
                case "CORGRCOM":
                case "CORGRACL":
                case "CORGRCRE":
                case "CORGRANT":
                case "CORGRVEN":
                case "CORGRSIT":
                    CORVAR.lgblTempNumEmp = -5;  //-5 Indica que la empresa no fue encontrada o no fue Buscada 
                    CORMDIBN.DefInstance.Enabled = true;
                    break;
                case "CORRPDAT":
                    CORMDIBN.DefInstance.Enabled = true;
                    break;
            }
            this.Close();
            this.Cursor = Cursors.Default;
        }


        private void lstLista_DoubleClick(Object eventSender, EventArgs eventArgs)
        {
            if (lstLista.Items.Count > 0)
            {
                string tempRefParam = VB6.GetItemString(lstLista, ListBoxHelper.GetSelectedIndex(lstLista));
                ifncIrEmpresa(Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref tempRefParam, 1, CRSParametros.cteSeparador)));

            }
        }

        private void txtTexto_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //ais-1597 chidalgo
            if (KeyAscii == 13)
            {
                ID_IRA_OK_PB_Click(this, eventArgs);
                return;
            }

            int Index = Array.IndexOf(txtTexto, eventSender);
            switch (Index)
            {
                case 0:
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false);
                    break;
                case 1:
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true);
                    break;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void txtTexto_Leave(Object eventSender, EventArgs eventArgs)
        {
            //EISSA 03-10-2001. Cambio para el formateo del número de empresa.
            txtTexto[0].Text = StringsHelper.Format(txtTexto[0].Text, Formato.sMascara(Formato.iTipo.Empresa));
        }


        private void ID_IRA_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            switch (sstFolder[0].SelectedIndex)
            {
                case 1:
                    double dbNumericTemp = 0;
                    if (Double.TryParse(txtTexto[0].Text, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                    {
                        ifncIrEmpresa(Convert.ToInt32(Conversion.Val(txtTexto[0].Text)));
                    }
                    else
                    {
                        ifncIrEmpresa(Convert.ToInt32(Conversion.Val(txtTexto[0].Text)));
                    }
                    break;
                case 0:
                    prCargaEmpresas(txtTexto[1].Text);
                    break;
            }
        }

        public int ifncIrEmpresa(int lpEmpresa)
        {
            int iResultado = 0;
            int iResp = 0;
            this.Cursor = Cursors.WaitCursor;
            CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(lpEmpresa.ToString()));
            if (CORVAR.lgblNumEmpresa <= CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Favor de capturar la clave de la Empresa .", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                txtTexto[0].Focus();
                return 0;
            }
            if (Conexion() != 0)
            {
                if (Existe_Empresa() != 0)
                {
                    switch (Tag.ToString())
                    {
                        case CORCONST.TAG_CATALOGO:
                            //UPGRADE_ISSUE: (2072) Control Tag could not be resolved because it was within the generic namespace ActiveControl. 
                            switch (CORCTEMP.DefInstance.ActiveControl.Tag.ToString())
                            {
                                case CORCONST.TAG_CAMBIO:
                                    this.Cursor = Cursors.WaitCursor;
                                    CORMNEMP.DefInstance.Tag = CORCONST.TAG_CAMBIO;
                                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
                                    CORMNEMP.DefInstance.ShowDialog(this);
                                    break;
                                case CORCONST.TAG_CONSULTA:
                                    this.Cursor = Cursors.WaitCursor;
                                    CORMNEMP.DefInstance.Tag = CORCONST.TAG_CONSULTA;
                                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
                                    CORMNEMP.DefInstance.ShowDialog(this);
                                    break;
                                case CORCONST.TAG_BAJA:
                                    this.Cursor = Cursors.Default;
                                    //EISSA 03-10-2001 Cambio para el formateo del número de empresa. 
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                    iResp = (int)Interaction.MsgBox("Realmente desea dar de baja a " + StringsHelper.Format(CORVAR.lgblNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + pszEmpresa.Trim(), (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                                    if (iResp == CORVB.IDYES)
                                    {
                                        this.Cursor = Cursors.Default;
                                        iResultado = CORPROC.Opera_BajaEmpresa(CORVAR.lgblNumEmpresa, ref iErr);
                                        if (iErr == CORCONST.OK)
                                        {
                                            if (iResultado == CORVB.NULL_INTEGER)
                                            {
                                                this.Cursor = Cursors.Default;
                                                //EISSA 03-10-2001 Cambio para el formateo del número de empresa.
                                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                                Interaction.MsgBox("No se dió de baja a la " + StringsHelper.Format(CORVAR.lgblNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + pszEmpresa.Trim() + Strings.Chr(CORVB.KEY_RETURN).ToString() + "posiblemente posee ejecutivos en Catálogo", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                            }
                                        }
                                        else
                                        {
                                            this.Close();
                                        }
                                    }
                                    break;
                            }

                            for (int iCont = 1; iCont <= CORCTEMP.DefInstance.ID_CEM_GRP_COB.Items.Count; iCont++)
                            {
                                if (CORVAR.igblNumGrupo == Conversion.Val(Strings.Mid(VB6.GetItemString(CORCTEMP.DefInstance.ID_CEM_GRP_COB, iCont - 1), 1, 4)))
                                {
                                    CORCTEMP.DefInstance.ID_CEM_GRP_COB.SelectedIndex = iCont - 1;
                                    break;
                                }
                            }

                            this.Close();
                            break;
                        case "CORRPDAT":
                            CORVAR.lgblNumEmpresaR = CORVAR.lgblNumEmpresa;
                            CORMDIBN.DefInstance.Enabled = true;
                            this.Close();
                           // CORRPDAT.DefInstance.Close();
                            CORRPDAT.DefInstance.Show();
                            if (CORRPDAT.DefInstance.flag)
                            {
                                CORRPDAT.DefInstance.Close();
                            }
                            break;
                        case "CORGRCOM":
                            CORVAR.lgblTempNumEmp = CORVAR.lgblNumEmpresa;
                            CORMDIBN.DefInstance.Enabled = true;

                            this.Close();

                            break;
                        case "CORGRCRE":
                            CORVAR.lgblTempNumEmp = CORVAR.lgblNumEmpresa;
                            CORMDIBN.DefInstance.Enabled = true;

                            for (int iCont = 1; iCont <= CORGRCRE.DefInstance.ID_CRE_EMP_COB.Items.Count; iCont++)
                            {
                                //EISSA 03-10-2001. Cambio para traer la longitud del número de empresa
                                if (CORVAR.lgblTempNumEmp == Conversion.Val(Strings.Mid(VB6.GetItemString(CORGRCRE.DefInstance.ID_CRE_EMP_COB, iCont - 1), 1, Formato.sMascara(Formato.iTipo.Empresa).Length)))
                                {
                                    CORGRCRE.DefInstance.ID_CRE_EMP_COB.SelectedIndex = iCont - 1;
                                    break;
                                }
                            }

                            this.Close();

                            break;
                        case "CORGRACL":
                            CORVAR.lgblTempNumEmp = CORVAR.lgblNumEmpresa;
                            CORMDIBN.DefInstance.Enabled = true;

                            for (int iCont = 1; iCont <= CORGRACL.DefInstance.ID_ACL_INF_COB.Items.Count; iCont++)
                            {
                                //EISSA 03-10-2001. Cambio para traer la longitud del número de empresa
                                if (CORVAR.lgblTempNumEmp == Conversion.Val(Strings.Mid(VB6.GetItemString(CORGRACL.DefInstance.ID_ACL_INF_COB, iCont - 1), 1, Formato.sMascara(Formato.iTipo.Empresa).Length)))
                                {
                                    CORGRACL.DefInstance.ID_ACL_INF_COB.SelectedIndex = iCont - 1;
                                    break;
                                }
                            }

                            this.Close();
                            break;
                        case "CORGRANT":
                            CORVAR.lgblTempNumEmp = CORVAR.lgblNumEmpresa;
                            CORMDIBN.DefInstance.Enabled = true;

                            for (int iCont = 1; iCont <= CORGRANT.DefInstance.ID_GRA_EMP_COB.Items.Count; iCont++)
                            {
                                //EISSA 03-10-2001. Cambio para traer la longitud del número de empresa
                                if (CORVAR.lgblTempNumEmp == Conversion.Val(Strings.Mid(VB6.GetItemString(CORGRANT.DefInstance.ID_GRA_EMP_COB, iCont - 1), 1, Formato.sMascara(Formato.iTipo.Empresa).Length)))
                                {
                                    CORGRANT.DefInstance.ID_GRA_EMP_COB.SelectedIndex = iCont - 1;
                                    break;
                                }
                            }

                            this.Close();
                            break;
                        case "CORGRVEN":
                            CORVAR.lgblTempNumEmp = CORVAR.lgblNumEmpresa;
                            CORMDIBN.DefInstance.Enabled = true;

                            for (int iCont = 1; iCont <= CORGRVEN.DefInstance.ID_CRE_EMP_COB.Items.Count; iCont++)
                            {
                                //EISSA 03-10-2001. Cambio para traer la longitud del número de empresa
                                if (CORVAR.lgblTempNumEmp == Conversion.Val(Strings.Mid(VB6.GetItemString(CORGRVEN.DefInstance.ID_CRE_EMP_COB, iCont - 1), 1, Formato.sMascara(Formato.iTipo.Empresa).Length)))
                                {
                                    CORGRVEN.DefInstance.ID_CRE_EMP_COB.SelectedIndex = iCont - 1;
                                    break;
                                }
                            }

                            this.Close();

                            break;
                        case "CORGRSIT":
                            CORVAR.lgblTempNumEmp = CORVAR.lgblNumEmpresa;
                            CORMDIBN.DefInstance.Enabled = true;

                            for (int iCont = 1; iCont <= CORGRSIT.DefInstance.ID_CRE_EMP_COB.Items.Count; iCont++)
                            {
                                //EISSA 03-10-2001. Cambio para traer la longitud del número de empresa.
                                if (CORVAR.lgblTempNumEmp == Conversion.Val(Strings.Mid(VB6.GetItemString(CORGRSIT.DefInstance.ID_CRE_EMP_COB, iCont - 1), 1, Formato.sMascara(Formato.iTipo.Empresa).Length)))
                                {
                                    CORGRSIT.DefInstance.ID_CRE_EMP_COB.SelectedIndex = iCont - 1;
                                    break;
                                }
                            }

                            this.Close();

                            break;
                        case CORCONST.TAG_GRAFICA:
                            CORVAR.lgblTempNumEmp = CORVAR.lgblNumEmpresa;
                            this.Close();

                            break;
                        default:
                            CORVAR.lgblNumEmpresaR = CORVAR.lgblNumEmpresa;
                            CORMDIBN.DefInstance.Enabled = true;
                            this.Close();
                            //AIS-Bug 4785 FSQSABORIO
                            if (CORRPANG.DefInstanceCreated)
                                CORRPANG.DefInstance.Close();

                            CORRPANG.DefInstance.Show();
                            //AIS-Bug 4785 FSQSABORIO
                            if (CORRPANG.DefInstance.FormNeedsToClose)
                                CORRPANG.DefInstance.Close();

                            break;
                    }

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("La Empresa no existe en Catálogos", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    switch (Tag.ToString())
                    {
                        case "CORGRCOM":
                        case "CORGRACL":
                        case "CORGRCRE":
                        case "CORGRANT":
                        case "CORGRVEN":
                        case "CORGRSIT":
                            CORVAR.lgblTempNumEmp = -5;  //-5 Indica que la empresa no fue encontrada o no fue Buscada 
                            lpEmpresa = Int32.Parse(CORVB.NULL_STRING);
                            txtTexto[0].Focus();
                            break;
                        case "CORRPDAT":
                            lpEmpresa = (int)Conversion.Val(CORVB.NULL_STRING); //AIS-1245 echasiquiza
                            txtTexto[0].Focus();
                            break;
                        default:
                            CORMDIBN.DefInstance.Enabled = true;
                            break;
                    }
                    lpEmpresa = 0;
                    txtTexto[0].Text = CORVB.NULL_STRING;
                    txtTexto[0].Focus();
                }
            }
            else
            {
                CORMDIBN.DefInstance.Enabled = true;
                //AIS-1182 NGONZALEZ
                CORVAR.igblErr = API.USER.PostMessage(CORIREMP.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                if (Tag.ToString() == "CORGRCOM" || Tag.ToString() == "CORGRACL" || Tag.ToString() == CORCONST.TAG_GRAFICA || Tag.ToString() == "CORGRCRE" || Tag.ToString() == "CORGRANT" || Tag.ToString() == "CORGRVEN" || Tag.ToString() == "CORGRSIT")
                {
                    CORVAR.lgblTempNumEmp = -5; //-5 Indica que la empresa no fue encontrada o no fue Buscada
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }

            //  Screen.MousePointer = HOURGLASS
            this.Cursor = Cursors.Default;
            return 0;
        }


        private void prCargaEmpresas(string spCadena)
        {
            string slSQL = String.Empty;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                slSQL = "select emp_num, gpo_num, emp_nom from MTCEMP01";
                slSQL = slSQL + " where emp_nom like '%" + spCadena.ToUpper() + "%'";
                slSQL = slSQL + " and eje_prefijo = " + CORVAR.igblPref.ToString();
                slSQL = slSQL + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                slSQL = slSQL + " order by emp_nom";
                CORVAR.pszgblsql = slSQL;
                lstLista.Items.Clear();
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    this.Height = (int)VB6.TwipsToPixelsY(5150);
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {

                        lstLista.Items.Add(StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), Formato.sMascara(Formato.iTipo.Empresa)) + CRSParametros.cteSeparador + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 2), new string('0', 4)) + CRSParametros.cteSeparador + VBSQL.SqlData(CORVAR.hgblConexion, 3));
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna empresa con la descripción " + spCadena + "\r\n" + " Intentelo nuevamente", "Busqueda de Empresas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTexto[1].SelectionStart = 0;
                    txtTexto[1].SelectionLength = Strings.Len(txtTexto[1].Text);
                    txtTexto[1].Focus();
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("CargaEmpresas", e);
            }
        }
        private void CORIREMP_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
