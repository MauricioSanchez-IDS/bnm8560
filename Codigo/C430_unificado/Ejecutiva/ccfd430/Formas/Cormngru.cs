using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMNGRU
        : System.Windows.Forms.Form
    {


        int iErr = 0;
        string pszSentencia = String.Empty;
        int hGruConexion = 0;

        private int Consecutivo_Grupo()
        {

            int result = 0;
            int hParam = 0;
            int htEMPConexion = 0;

            iErr = CORCONST.OK;
            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " con_gpo";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCON01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where con_pref = " + mdlParametros.gprdProducto.PrefijoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and con_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and con_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    result = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                }
                else
                {
                    result = CORVB.NULL_INTEGER;
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return result;
        }

        public string Existen_Blancos()
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            string result = String.Empty;
            try
            {

                if (ID_MGR_GRP_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    ID_MGR_GRP_EB.Focus();
                    result = "NOMBRE DEL GRUPO";
                }
                else if (ID_MGR_DOM_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    ID_MGR_DOM_EB.Focus();
                    result = "CALLE Y NUMERO";
                }
                else if (ID_MGR_COL_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    ID_MGR_COL_EB.Focus();
                    result = "COLONIA";
                }
                else if (ID_MGR_POB_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    ID_MGR_POB_EB.Focus();
                    result = "POBLACION";
                }
                else if (ID_MGR_CIU_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    ID_MGR_CIU_EB.Focus();
                    result = "CIUDAD";
                }
                else
                {
                    try
                    {
                        if (CRSGeneral.asgEstados[0, ID_MGR_EDO_EB.SelectedIndex].Trim() == CORVB.NULL_STRING)
                        {
                            ID_MGR_EDO_EB.Focus();
                            result = "ESTADO";
                        }
                    }
                    catch (Exception e)
                    {
                        ID_MGR_EDO_EB.Focus();
                        result = "ESTADO";
                    }
                    if (result.Equals(String.Empty))
                        if (Conversion.Val(ID_MGR_CP_PIC.CtlText) == CORVB.NULL_INTEGER)
                        {
                            ID_MGR_CP_PIC.Focus();
                            result = "CODIGO POSTAL";
                        }
                        else if (ID_MGR_VEN_CRD_DTB.CtlText.Trim() == CORVB.NULL_STRING)
                        {
                            ID_MGR_VEN_CRD_DTB.Focus();
                            result = "VENCIMIENTO DEL CREDITO";

                        }
                        //else if (Conversion.Val(ID_MGR_CRE_TOT_CRR.CtlText) == CORVB.NULL_INTEGER)
                        //{
                        //    ID_MGR_CRE_TOT_CRR.Focus();
                        //    result = "CREDITO TOTAL";
                            //    ElseIf (Val(ID_MGR_CRE_TOT_CRR.Text) > 999999999) Then
                            //        MsgBox ("Importe mayor al permitido")
                            //        ID_MGR_CRE_TOT_CRR.Text = "0"
                            //        ID_MGR_CRE_TOT_CRR.SetFocus
                            //        Existen_Blancos = "CREDITO TOTAL"
                            //    ElseIf (Val(ID_MGR_CRE_TOT_CRR.Text) <= 0) Then
                            //        MsgBox ("Importe menor al permitido")
                            //        ID_MGR_CRE_TOT_CRR.Text = "0"
                            //        ID_MGR_CRE_TOT_CRR.SetFocus
                            //        Existen_Blancos = "CREDITO TOTAL"
                            //    ElseIf Val(ID_MGR_CRE_TOT_CRR.Text) < 1 Then
                            //        ID_MGR_CRE_TOT_CRR.SetFocus
                            //        Existen_Blancos = "Inserte una cantidad mayor en crédito total."
                        //}
                }

                if (result == CORVB.NULL_STRING)
                {
                    //Verifica que este bien capturada la fecha
                    if (ID_MGR_VEN_CRD_DTB.CtlText != CORVB.NULL_STRING)
                    {
                        if (Conversion.Val(Strings.Mid(ID_MGR_VEN_CRD_DTB.CtlText, 1, 2)) == CORVB.NULL_INTEGER)
                        {
                            result = "EN DIA DEL VENCIMIENTO DEL CREDITO";
                        }
                        else if (Conversion.Val(Strings.Mid(ID_MGR_VEN_CRD_DTB.CtlText, 4, 2)) == CORVB.NULL_INTEGER)
                        {
                            result = "EN MES DEL VENCIMIENTO DEL CREDITO";
                        }
                        else if (Strings.Mid(ID_MGR_VEN_CRD_DTB.CtlText, 7, 4).Length < 4)
                        {
                            result = "EN AÑO DEL VENCIMIENTO DEL CREDITO";
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        private void CORMNGRU_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                int iGrupos = 0;

                CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORSTR.STR_LEE_BD;

                switch (Tag.ToString())
                {
                    case CORCONST.TAG_CAMBIO:
                        iGrupos = Obtiene_DatosGrupo();
                        if (iErr == CORCONST.OK)
                        {
                            if (iGrupos != 0)
                            {
                                ID_MGR_CTA_PNL.Visible = true;
                                ID_MGR_CTA_PNL.Text = StringsHelper.Format(CORVAR.igblNumGrupo, "0000");
                                ID_MGR_GRP_EB.Focus();
                            }
                        }
                        else
                        {
                            this.Close();
                        }

                        break;
                    case CORCONST.TAG_CONSULTA:
                        iGrupos = Obtiene_DatosGrupo();
                        if (iErr == CORCONST.OK)
                        {
                            ID_MGR_CTA_PNL.Visible = true;
                            ID_MGR_TEX_PNL.Visible = true;
                            ID_MGR_CTA_PNL.Text = StringsHelper.Format(CORVAR.igblNumGrupo, "0000");
                            //AIS-1221 NGONZALEZ
                            SetEnable(false);
                            ID_MGR_OK_PB.Enabled = false;
                            ID_MGR_GRP_EB.Enabled = false;
                        }
                        else
                        {
                            this.Close();
                        }

                        break;
                    default:
                        ID_MGR_CTA_PNL.Visible = false;
                        ID_MGR_TEX_PNL.Visible = false;

                        //*****JPU***** 
                        //ID_MGR_CRE_TOT_CRR.CtlText = "0";
                        //Verificar con yuria la razon por la cual antes estaba deshabilitado 
                        //ID_MGR_CRE_TOT_CRR.Enabled = true;
                        //ID_MGR_CRE_ACU_CRR.CtlText = "0";
                        //ID_MGR_CRE_ACU_CRR.Enabled = false;
                        //*****JPU***** 

                        ID_MGR_GRP_EB.Focus();

                        break;
                }

                CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORVB.NULL_STRING;
                this.Cursor = Cursors.Default;
                ID_MGR_SEC_PNL.Visible = false;
                ID_MGR_SEC_PNL.Visible = true;
            }
        }
        //AIS-1221 NGONZALEZ
        public void SetEnable(bool flag)
        {
            ID_MGR_GRP_EB.Enabled = flag;
            ID_MGR_DOM_EB.Enabled = flag;
            ID_MGR_COL_EB.Enabled = flag;
            ID_MGR_POB_EB.Enabled = flag;
            ID_MGR_CIU_EB.Enabled = flag;
            ID_MGR_EDO_EB.Enabled = flag;
            ID_MGR_CP_PIC.Enabled = flag;
            //ID_MGR_CRE_TOT_CRR.Enabled = flag;
            //ID_MGR_CRE_ACU_CRR.Enabled = flag;
            //ID_MGR_CRE_TOT_CRR.Enabled = flag;
            ID_MGR_VEN_CRD_DTB.Enabled = flag;
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int iValor = 0;
            this.SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(630)), Convert.ToInt32((float)VB6.TwipsToPixelsY(1750)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
            this.Cursor = Cursors.WaitCursor;
            CRSGeneral.prCargaEstados();
            CRSGeneral.prCargaEstadoEnCombo(ID_MGR_EDO_EB);
            Inicializa_Controles_Fecha();
            this.Cursor = Cursors.Default;
        }

        private void ID_MGR_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Close();
            this.Cursor = Cursors.Default;
        }

        private void ID_MGR_CIU_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MGR_CIU_EB.SelectionStart = 0;
            ID_MGR_CIU_EB.SelectionLength = Strings.Len(ID_MGR_CIU_EB.Text);
        }

        private void ID_MGR_CIU_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MGR_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MGR_COL_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MGR_COL_EB.SelectionStart = 0;
            ID_MGR_COL_EB.SelectionLength = Strings.Len(ID_MGR_COL_EB.Text);
        }

        private void ID_MGR_COL_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MGR_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, ".,-#");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MGR_CP_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MGR_CP_PIC.SelStart = 0;
            ID_MGR_CP_PIC.SelLength = Strings.Len(ID_MGR_CP_PIC.CtlText);
        }

        private void ID_MGR_CP_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MGR_OK_PB.PerformClick();
                return;
            }
            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8)
            {
                eventArgs.keyAscii = (short)CORVB.NULL_INTEGER;
            }
        }

        private void ID_MGR_CP_PIC_Leave(Object eventSender, EventArgs eventArgs)
        {
            ID_MGR_CP_PIC.CtlText = StringsHelper.Format(ID_MGR_CP_PIC.CtlText, "00000");
        }

        private void ID_MGR_DOM_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MGR_DOM_EB.SelectionStart = 0;
            ID_MGR_DOM_EB.SelectionLength = Strings.Len(ID_MGR_DOM_EB.Text);
        }

        private void ID_MGR_DOM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MGR_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, ".,-#");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MGR_EDO_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MGR_EDO_EB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (ID_MGR_EDO_EB.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un estado válido para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancel = true;
            }
            eventArgs.Cancel = Cancel;
        }

        private void ID_MGR_GRP_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MGR_GRP_EB.SelectionStart = 0;
            ID_MGR_GRP_EB.SelectionLength = Strings.Len(ID_MGR_GRP_EB.Text);
        }

        private void ID_MGR_GRP_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MGR_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MGR_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                PrinterHelper.Printer.FontName = "Courier New";
                PrinterHelper.Printer.DocumentName = "TCc430";
                PrinterHelper.Printer.FontBold = true;

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print(new String(' ', 24) + Text);
                PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', Strings.Len(Text)));
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("PREFIJO                : " + CORVAR.igblPref.ToString());
                PrinterHelper.Printer.Print("BANCO                  : " + CORVAR.igblBanco.ToString());
                PrinterHelper.Printer.Print("NOMBRE                 : " + ID_MGR_CTA_PNL.Text + "  " + ID_MGR_GRP_EB.Text);

                PrinterHelper.Printer.FontBold = false;

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("CALLE Y NUMERO          : " + ID_MGR_DOM_EB.Text);
                PrinterHelper.Printer.Print("COLONIA                 : " + ID_MGR_COL_EB.Text);
                PrinterHelper.Printer.Print("POBLACION/DEL./MUN.     : " + ID_MGR_POB_EB.Text);
                PrinterHelper.Printer.Print("CIUDAD                  : " + ID_MGR_CIU_EB.Text);
                PrinterHelper.Printer.Print("ESTADO                  : " + ID_MGR_EDO_EB.Text);
                PrinterHelper.Printer.Print("C.P.                    : " + ID_MGR_CP_PIC.CtlText);
                PrinterHelper.Printer.Print("CREDITO TOTAL           : 0");
                PrinterHelper.Printer.Print("CREDITO ACUMULADO       : 0");
                PrinterHelper.Printer.Print("VENCIMIENTO DEL CREDITO : " + ID_MGR_VEN_CRD_DTB.CtlText);

                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.EndDoc();
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MGR_IMP_PB_Click)", exc);
                
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_MGR_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                Opera_Grupo();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MGR_OK_PB_Click)", e);
            }
        }

        private void ID_MGR_POB_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MGR_POB_EB.SelectionStart = 0;
            ID_MGR_POB_EB.SelectionLength = Strings.Len(ID_MGR_POB_EB.Text);
        }

        private void ID_MGR_POB_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MGR_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void Limpia_Controles()
        {

            ID_MGR_GRP_EB.Text = CORVB.NULL_STRING;
            ID_MGR_DOM_EB.Text = CORVB.NULL_STRING;
            ID_MGR_COL_EB.Text = CORVB.NULL_STRING;
            ID_MGR_CP_PIC.CtlText = CORVB.NULL_STRING;
            ID_MGR_POB_EB.Text = CORVB.NULL_STRING;
            ID_MGR_CIU_EB.Text = CORVB.NULL_STRING;
            ID_MGR_EDO_EB.SelectedIndex = -1;
            //ID_MGR_CRE_TOT_CRR.CtlText = "0";
            //ID_MGR_CRE_ACU_CRR.CtlText = "0";
            ID_MGR_VEN_CRD_DTB.CtlText = CORVB.NULL_STRING;

        }

        private int Obtiene_DatosGrupo()
        {

            int result = 0;
            int hBufGrupo = 0;
            string pszCadena = String.Empty;
            string pszFecha = String.Empty;
            int iPosIni = 0;
            int iPosFin = 0;
            int iNumGrupo = 0;
            int iTempErr = 0;

            iErr = CORCONST.OK;

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_num";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_nom";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_calle";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_col";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_cp";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_ciu";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_pob";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_edo";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_cred_tot";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_acum_cred";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ",convert(varchar(10),gpo_fec_venc_cred,103)";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCOR01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + CORVAR.igblNumGrupo.ToString();

            if (CORPROC2.Obtiene_Registros() != 0)
            { //Exito
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    ID_MGR_GRP_EB.Text = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                    ID_MGR_DOM_EB.Text = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                    ID_MGR_COL_EB.Text = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                    ID_MGR_CP_PIC.CtlText = StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)), "00000");
                    ID_MGR_POB_EB.Text = VBSQL.SqlData(CORVAR.hgblConexion, 7).Trim();
                    ID_MGR_CIU_EB.Text = VBSQL.SqlData(CORVAR.hgblConexion, 8).Trim();
                    CRSGeneral.prBuscaEstado(ID_MGR_EDO_EB, VBSQL.SqlData(CORVAR.hgblConexion, 9).Trim());
                    //ID_MGR_CRE_TOT_CRR.CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim();
                    //ID_MGR_CRE_ACU_CRR.CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 11).Trim();
                    if (VBSQL.SqlData(CORVAR.hgblConexion, 12) == "")
                    {
                        ID_MGR_VEN_CRD_DTB.CtlText = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        ID_MGR_VEN_CRD_DTB.CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 12);
                    }
                    result = -1;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                result = 0;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return result;
        }

        private void Opera_Grupo()
        {

            int hBufGrupo = 0;
            int iValor = 0;
            string pszNumGrupo = String.Empty;


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                this.Cursor = Cursors.WaitCursor;

                string pszConcBco = Existen_Blancos();
                if (pszConcBco.Length != 0)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Por favor suministre información en el Campo: " + Strings.Chr(CORVB.KEY_RETURN).ToString() + pszConcBco.ToUpper(), (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return;
                }

                string pszNombre = "'" + CORPROC.Valida_Comilla(ID_MGR_GRP_EB.Text) + "'";
                string pszCalle = "'" + CORPROC.Valida_Comilla(ID_MGR_DOM_EB.Text) + "'";
                string pszColonia = "'" + CORPROC.Valida_Comilla(ID_MGR_COL_EB.Text) + "'";
                string pszCP = ID_MGR_CP_PIC.CtlText.Trim();
                string pszCiudad = "'" + CORPROC.Valida_Comilla(ID_MGR_POB_EB.Text) + "'";
                string pszPob = "'" + CORPROC.Valida_Comilla(ID_MGR_CIU_EB.Text) + "'";
                string pszEstado = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MGR_EDO_EB.SelectedIndex]) + "'";
                string pszPref = CORVAR.igblPref.ToString();
                string pszBanco = CORVAR.igblBanco.ToString();

                int iCredTot = 0;
                int iCredAcu = 0;

                string pszVenCred = ID_MGR_VEN_CRD_DTB.CtlText;
                System.DateTime TempDate = DateTime.FromOADate(0);
                pszVenCred = Strings.Mid(pszVenCred, 1, 3) + CORPROC2.Obten_Mes_Ingles(StringsHelper.IntValue((DateTime.TryParse(pszVenCred, out TempDate)) ? TempDate.ToString("MM") : pszVenCred)) + Strings.Mid(pszVenCred, 6, 5);

                if (Tag.ToString() == CORCONST.TAG_CAMBIO)
                {
                    if (iCredTot < iCredAcu)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("El credito total del Grupo " + ID_MGR_GRP_EB.Text.Trim() + " No pudo ser menor al credito acumulado", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), null);
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }

                switch (Tag.ToString())
                {
                    case CORCONST.TAG_ALTA:
                        CORVAR.pszgblsql = "exec alta_grupo";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " 0";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + pszNombre;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + pszCalle;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + pszColonia;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + pszCP;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + pszCiudad;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + pszPob;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + pszEstado;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + iCredTot.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + iCredAcu.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + pszVenCred + "'";

                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El Grupo " + ID_MGR_GRP_EB.Text.Trim() + " fué dado de Alta con el Numero: " + StringsHelper.Format(Consecutivo_Grupo() - 1, "0000"), (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            this.Cursor = Cursors.WaitCursor;
                            try
                            {
                                Limpia_Controles();
                            }
                            catch (Exception e1) { }
                            ID_MGR_GRP_EB.Focus();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El Grupo " + ID_MGR_GRP_EB.Text.Trim() + " No pudo ser dado de Alta", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            this.Cursor = Cursors.WaitCursor;
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        break;
                    case CORCONST.TAG_CAMBIO:
                        pszNumGrupo = CORVAR.igblNumGrupo.ToString();

                        CORVAR.pszgblsql = "update MTCCOR01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set gpo_nom = " + pszNombre;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_calle = " + pszCalle;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_col = " + pszColonia;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_cp = " + pszCP;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_ciu = " + pszCiudad;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_pob = " + pszPob;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_edo = " + pszEstado;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_cred_tot = 0";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_acum_cred = 0";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_fec_venc_cred = '" + pszVenCred + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + pszNumGrupo;

                        this.Cursor = Cursors.Default;
                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            VB6.SetItemString(CORCTGRU.DefInstance.ID_CGR_GRP_LB, ListBoxHelper.GetSelectedIndex(CORCTGRU.DefInstance.ID_CGR_GRP_LB), Strings.Mid(VB6.GetItemString(CORCTGRU.DefInstance.ID_CGR_GRP_LB, ListBoxHelper.GetSelectedIndex(CORCTGRU.DefInstance.ID_CGR_GRP_LB)), 1, 6) + ID_MGR_GRP_EB.Text.Trim());
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El Grupo " + ID_MGR_GRP_EB.Text.Trim() + " fué actualizado", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            this.Cursor = Cursors.WaitCursor;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El Grupo " + ID_MGR_GRP_EB.Text.Trim() + " No pudo ser actualizado", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            this.Cursor = Cursors.WaitCursor;
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Close();

                        break;
                    case "ALTA 1":
                        pszNumGrupo = CORVAR.igblNumGrupo.ToString();

                        CORVAR.pszgblsql = "update MTCCOR01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set gpo_nom = " + pszNombre;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_calle = " + pszCalle;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_col = " + pszColonia;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_cp = " + pszCP;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_ciu = " + pszCiudad;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_pob = " + pszPob;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_edo = " + pszEstado;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_cred_tot = 0";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_acum_cred = 0";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",gpo_fec_venc_cred = '" + pszVenCred + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num = " + pszNumGrupo;

                        this.Cursor = Cursors.Default;
                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            this.Cursor = Cursors.Default;
                            CORCTEMP.DefInstance.ID_CEM_GRP_COB.Items.Add(StringsHelper.Format(pszNumGrupo, "0000") + "  " + ID_MGR_GRP_EB.Text.Trim());
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El Grupo " + ID_MGR_GRP_EB.Text.Trim() + " fué actualizado", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            this.Cursor = Cursors.WaitCursor;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El Grupo " + ID_MGR_GRP_EB.Text.Trim() + " No pudo ser actualizado", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            this.Cursor = Cursors.WaitCursor;
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Close();

                        break;
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void Inicializa_Controles_Fecha()
        {
            ID_MGR_VEN_CRD_DTB.CtlText = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
            ID_MGR_VEN_CRD_DTB.Enabled = true;
        }

        //UPGRADE_NOTE: (7001) The following declaration (ID_MGR_VEN_CRD_DTB_DblClick) seems to be dead code
        //private void  ID_MGR_VEN_CRD_DTB_DblClick( int Col,  int Row)
        //{
        //ID_MGR_VEN_CRD_DTB.Focus();
        //}

        private void ID_MGR_VEN_CRD_DTB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MGR_VEN_CRD_DTB.SelStart = 0;
            ID_MGR_VEN_CRD_DTB.SelLength = Strings.Len(ID_MGR_VEN_CRD_DTB.CtlText);
        }
        bool closing = false;
        private void ID_MGR_VEN_CRD_DTB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            if (!closing)
            {
                bool Cancel = eventArgs.Cancel;
                string tempRefParam = this.Text;
                if (!CRSGeneral.bfncValidaFecha(ID_MGR_VEN_CRD_DTB, 0, ref tempRefParam))
                {
                    Cancel = true;
                }
                eventArgs.Cancel = Cancel;
            }
        }
        private void CORMNGRU_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            closing = true;
        }

        //ais-917 chidalgo
        private object control = null;

        private void HandleSelection_Click(object sender, EventArgs e)
        {
            if (control == null || !control.Equals(sender))
            {
                control = sender;
                TextBox textbox = (TextBox)sender;
                textbox.SelectionStart = 0;
                textbox.SelectionLength = textbox.TextLength;
            }
        }

        private void HandleSelection_MouseEnter(object sender, EventArgs e)
        {
            control = ActiveControl;
        }


    }


}
