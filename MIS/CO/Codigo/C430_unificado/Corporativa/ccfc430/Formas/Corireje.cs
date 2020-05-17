using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORIREJE
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Forma para captura de un ejecutivo Empresa          **
        //**                    en la busqueda especifica de catalogos              **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        private void cmdNuevo_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Height = (int)VB6.TwipsToPixelsY(2300);
            lstLista.Items.Clear();
            txtTexto[0].Text = String.Empty;
            txtTexto[1].Text = String.Empty;
            txtTexto[2].Text = String.Empty;
            txtTexto[3].Text = String.Empty;
            txtTexto[4].Text = String.Empty;
            sstFolder[0].SelectedIndex = 0;
            txtTexto[0].Focus();
        }

        private void CORIREJE_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                txtTexto[0].Text = CORVAR.lgblEmpCve.ToString();
                txtTexto[2].Text = CORVAR.lgblEmpCve.ToString();
                switch (sstFolder[0].SelectedIndex)
                {
                    case 1:
                        txtTexto[1].Focus();
                        break;
                    case 2:
                        txtTexto[3].Focus();
                        break;
                    case 3:
                        txtTexto[4].Focus();
                        break;
                }
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            this.Height = (int)VB6.TwipsToPixelsY(5353);
        }

        private void ID_IRA_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.bgblCerrar = -1;
            this.Close();

        }


        //UPGRADE_NOTE: (7001) The following declaration (ID_IRA_EJE_PIC_KeyPress) seems to be dead code
        //private void  ID_IRA_EJE_PIC_KeyPress(ref  int KeyAscii)
        //{
        //if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != CORVB.KEY_BACK)
        //{
        //KeyAscii = 0;
        //}
        //}


        private int ifncIrEjecutivo(int lpEmpresa, int lpEjecutivo)
        {
            int hConexion = 0;
            int iCorNum = 0;
            int hEjeEmp = 0;
            int iError = 0;
            string pszEmpDesc = String.Empty;
            int iValor = 0;
            int reg_mod = 0;
            int lGrupo = 0;
            int iGrupo = 0;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.lgblEmpCve = Convert.ToInt32(Conversion.Val(lpEmpresa.ToString()));
            CORVAR.igblEjeNum = Convert.ToInt32(Conversion.Val(lpEjecutivo.ToString()));

            if (CORVAR.lgblEmpCve <= CORVB.NULL_INTEGER || CORVAR.igblEjeNum <= CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                CORVAR.igblErr = (int)Interaction.MsgBox("La Empresa o el Ejecutivo no han sido proporcionado", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                return 0;
            }

            CORVAR.bgblIrExiste = 0;
            CORVAR.bgblCerrar = 0;
            //Obtiene los Campos de la tabla de Ejecutivos Banamex
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "exec ir_empresa " + Format$(igblBanco) + "," + Format$(lgblEmpCve)
            //***** FIN DE CODIGO ANTERIOR FSWBMX
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "exec ir_empresa " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblEmpCve.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    iGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpDesc = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    CORVAR.pszgblEmpDesc = pszEmpDesc;
                }
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //Busca al Ejecutivo
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "exec ira_ejecutivo " + Format$(igblBanco) + "," + Format$(lgblEmpCve) + "," + Format$(igblEjeNum)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "exec ira_ejecutivo " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.lgblEmpCve.ToString() + "," + CORVAR.igblEjeNum.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Existe_Dato() != 0)
            {
                CORVAR.bgblIrExiste = -1;
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            if (CORVAR.bgblIrExiste != 0)
            {
                for (int iCont = 1; iCont <= CORCTEJE.DefInstance.ID_CEE_GRU_COB.Items.Count; iCont++)
                {
                    if (iGrupo == Conversion.Val(Strings.Mid(VB6.GetItemString(CORCTEJE.DefInstance.ID_CEE_GRU_COB, iCont - 1), 1, 4)))
                    {
                        CORCTEJE.DefInstance.ID_CEE_GRU_COB.SelectedIndex = iCont - 1;
                        break;
                    }
                }
                this.Close();
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                CORVAR.igblErr = (int)Interaction.MsgBox("La Empresa o el Ejecutivo no existen en catálogos.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
            }
            return 0;
        }


        //A partir de la cuenta se puede tener Empresa
        //Ejecutivo, Gpo_Banco y Eje_Prefijo
        //
        private void ID_IRA_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                switch (sstFolder[0].SelectedIndex)
                {
                    case 0:  //Búsqueda por texto 
                        //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior. 
                        if (String.IsNullOrEmpty(txtTexto[1].Text.Trim()))
                        {
                            MessageBox.Show("No se ha tecleado el ejecutivo que se desea buscar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTexto[1].Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        else
                        {
                            prCargaEjecutivos(Convert.ToInt32(Conversion.Val(txtTexto[0].Text)), txtTexto[1].Text);
                        }
                        break;
                    case 1:  //Búsqueda por Empresa y Ejecutivo 
                        //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior. 
                        if (String.IsNullOrEmpty(txtTexto[2].Text.Trim()))
                        {
                            MessageBox.Show("No se ha proporcionado el número de empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTexto[2].Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior. 
                        if (String.IsNullOrEmpty(txtTexto[3].Text.Trim()))
                        {
                            MessageBox.Show("No se ha proporcionado el número de ejecutivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTexto[3].Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        ifncIrEjecutivo(Convert.ToInt32(Conversion.Val(txtTexto[2].Text)), Convert.ToInt32(Conversion.Val(txtTexto[3].Text)));
                        break;
                    case 2:  //Búsqueda por Cuenta 
                        //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior. 
                        if (String.IsNullOrEmpty(txtTexto[4].Text.Trim()))
                        {
                            MessageBox.Show("No se ha proporcionado el número de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTexto[4].Focus();
                            this.Cursor = Cursors.Default;
                            return;
                        }
                        if (txtTexto[4].Text.Trim().Length == 16)
                        {
                            prLocalizaCuenta(txtTexto[4].Text);
                        }
                        else
                        {
                            MessageBox.Show("Número de cuenta incompleta, verifique el número de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTexto[4].Focus();
                            this.Cursor = Cursors.Default;
                        }
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_IRA_OK_PB_Click " + exc.Message, "Error Corireje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void prCargaEjecutivos(int lpEmpresa, string spCadena)
        {
            string slSQL = String.Empty;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                slSQL = "select ";
                slSQL = slSQL + " emp_num, ";
                slSQL = slSQL + " eje_num, ";
                slSQL = slSQL + " eje_nombre, ";
                slSQL = slSQL + " eje_prefijo, ";
                slSQL = slSQL + " gpo_banco ";
                slSQL = slSQL + " From MTCEJE01 ";
                slSQL = slSQL + " where ";
                slSQL = slSQL + " eje_prefijo = " + CORVAR.igblPref.ToString();
                slSQL = slSQL + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                slSQL = slSQL + " and eje_nombre like '%" + spCadena.ToUpper() + "%'";
                if (lpEmpresa > 0)
                {
                    slSQL = slSQL + " and emp_num = " + lpEmpresa.ToString();
                }
                slSQL = slSQL + " order by eje_nombre";
                CORVAR.pszgblsql = slSQL;
                lstLista.Items.Clear();
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    this.Height = (int)VB6.TwipsToPixelsY(5150);
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {

                        lstLista.Items.Add(StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), Formato.sMascara(Formato.iTipo.Empresa)) + CRSParametros.cteSeparador + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 2), Formato.sMascara(Formato.iTipo.Ejecutivo)) + CRSParametros.cteSeparador + VBSQL.SqlData(CORVAR.hgblConexion, 3));
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún ejecutivo con la descripción " + spCadena + "\r\n" + " Intentelo nuevamente", "Busqueda de Empresas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (sstFolder[0].SelectedIndex)
                    {
                        case 1:
                            txtTexto[1].SelectionStart = 0;
                            txtTexto[1].SelectionLength = Strings.Len(txtTexto[1].Text);
                            txtTexto[1].Focus();
                            break;
                        case 2:
                            txtTexto[3].SelectionStart = 0;
                            txtTexto[3].SelectionLength = Strings.Len(txtTexto[3].Text);
                            txtTexto[3].Focus();
                            break;
                        case 3:
                            txtTexto[4].SelectionStart = 0;
                            txtTexto[4].SelectionLength = Strings.Len(txtTexto[4].Text);
                            txtTexto[4].Focus();
                            break;
                    }
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("CargaEjecutivos", e);
            }
        }

        private void lstLista_DoubleClick(Object eventSender, EventArgs eventArgs)
        {
            if (lstLista.Items.Count > 0)
            {
                string tempRefParam = VB6.GetItemString(lstLista, ListBoxHelper.GetSelectedIndex(lstLista));
                string tempRefParam2 = VB6.GetItemString(lstLista, ListBoxHelper.GetSelectedIndex(lstLista));
                ifncIrEjecutivo(Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref tempRefParam, 1, CRSParametros.cteSeparador)), Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref tempRefParam2, 2, CRSParametros.cteSeparador)));
            }
            else
            {
            }
        }

        static Hashtable PreviousTabs_sstFolder_SelectedIndexChanged = new Hashtable();
        private void sstFolder_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            //int Index = Array.IndexOf(sstFolder, eventSender);
            //int PreviousTab = (int) PreviousTabs_sstFolder_SelectedIndexChanged[Index];
            switch (sstFolder[0].SelectedIndex)
            {
                case 0:
                    txtTexto[0].SelectionStart = 0;
                    txtTexto[0].SelectionLength = Strings.Len(txtTexto[0].Text);
                    txtTexto[0].Focus();
                    break;
                case 1:
                    txtTexto[3].SelectionStart = 0;
                    txtTexto[3].SelectionLength = Strings.Len(txtTexto[3].Text);
                    txtTexto[3].Focus();
                    break;
                case 2:
                    txtTexto[4].SelectionStart = 0;
                    txtTexto[4].SelectionLength = Strings.Len(txtTexto[4].Text);
                    txtTexto[4].Focus();
                    break;
            }
            //PreviousTabs_sstFolder_SelectedIndexChanged[Index] = sstFolder[Index].SelectedIndex;
        }

        private void txtTexto_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            int Index = Array.IndexOf(txtTexto, eventSender);
            switch (Index)
            {
                case 0:
                case 2:
                case 3:
                case 4:
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
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

        private void prLocalizaCuenta(string spCuenta)
        {
            int llEmpresa = 0;
            int llEjecutivo = 0;
            string slCuentaBanamex = String.Empty;
            ADODB.Recordset adorst = null;
            string strCtaBanamex = String.Empty;

            try
            {
                //Buscar cuenta banamex en la tabla de Citi

                slCuentaBanamex = "0000000000000000";

                if (VBSQL.OpenConn(10) != 0)
                {
                    VBSQL.gConn[10].Close();
                }
                else
                {
                    VBSQL.gConn[10].Close();
                }

                if (VBSQL.OpenConn(10) == 0)
                {
                    adorst = new ADODB.Recordset();
                    CORVAR.pszgblsql = " select map_cta_bnx from MTCMAP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where map_cta_citi = '" + spCuenta + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and map_estatus = ''";

                    adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);

                    if (!adorst.EOF && !adorst.BOF)
                    {
                        strCtaBanamex = Convert.ToString(adorst.Fields["map_cta_bnx"].Value);
                    }

                    adorst.Close();
                    adorst = null;

                    if (strCtaBanamex == "")
                    {
                        slCuentaBanamex = spCuenta;
                    }
                    else
                    {
                        slCuentaBanamex = strCtaBanamex;
                    }

                    if (VBSQL.gConn[10].State == 1)
                    {
                        VBSQL.gConn[10].Close();
                    }

                }
                //Extraer la cuenta Banamex
                llEmpresa = Convert.ToInt32(Conversion.Val(Strings.Mid(slCuentaBanamex, 7, Formato.sMascara(Formato.iTipo.Empresa).Length)));
                //Extraer la Empresa y el Ejecutivo
                llEjecutivo = Convert.ToInt32(Conversion.Val(Strings.Mid(slCuentaBanamex, 7 + Formato.sMascara(Formato.iTipo.Empresa).Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length)));
                //Ir al ejecutivo determinado
                ifncIrEjecutivo(llEmpresa, llEjecutivo);
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("LocalizaCuenta", e);

                if (adorst.State != 0)
                {
                    adorst.Close();
                }

                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }
            }

        }
        private void CORIREJE_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}