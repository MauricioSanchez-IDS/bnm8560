using Artinsoft.VB6.Gui;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORIRUNI
        : System.Windows.Forms.Form
    {

        private void CORIRUNI_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        private void CMD_IR_A_Click(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(CMD_IR_A, eventSender);
            int reg = 0;
            try
            {

                switch (Index)
                {
                    case 0:
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01 where";
                        if (mkbMaskebox[0].CtlText.Trim() != "")
                        {
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id = '" + mkbMaskebox[0].CtlText.Trim() + "'";
                        }
                        if (mkbMaskebox[1].CtlText.Trim() != "")
                        {
                            if (mkbMaskebox[0].CtlText.Trim() != "")
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and";
                            }
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name like '" + mkbMaskebox[1].CtlText.Trim() + "%'";
                        }
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "and eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "and emp_num = " + Strings.Mid(CORCTUNI.DefInstance.ID_CEE_EMP_COB.Text, 1, Formato.igLongitudEmpresa);

                        if (mkbMaskebox[0].CtlText.Trim() == "" && mkbMaskebox[1].CtlText.Trim() == "")
                        {
                            MessageBox.Show("Favor de digitar algún criterio de busqueda ", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                            mkbMaskebox[0].Focus();
                        }


                        reg = CORPROC2.Cuenta_Registros();
                        if (reg == 1)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    Formato.sgUnit_ID = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                    Formato.sgName_Unit = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                };
                                Formato.bgForma = true;
                                frm_unidades tempLoadForm = frm_unidades.DefInstance;

                                if (Formato.bgForma)
                                {
                                    frm_unidades.DefInstance.Show();
                                    this.Close();
                                }
                                else
                                {
                                    frm_unidades.DefInstance.Close();

                                }
                            }
                            this.Cursor = Cursors.Default;
                        }
                        else if (reg > 1)
                        {
                            this.Height = (int)VB6.TwipsToPixelsY(4290);
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {
                                //itsm
                                LST_IR_A.Items.Clear();

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    LST_IR_A.Items.Add(new String(' ', 3) + VBSQL.SqlData(CORVAR.hgblConexion, 1) + new String(' ', 5) + VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim());
                                };
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontro la Unidad: " + mkbMaskebox[0].CtlText.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mkbMaskebox[0].Focus();
                        }
                        break;
                    case 1:
                        Formato.bgForma = false;
                        this.Close();
                        break;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(CMD_IR_A_Click)", e);
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            this.Height = (int)VB6.TwipsToPixelsY(2260);
            this.Width = (int)VB6.TwipsToPixelsX(6480);
            this.Top = (int)VB6.TwipsToPixelsY(2800);
            this.Left = (int)VB6.TwipsToPixelsX(4170);
        }

        private void LST_IR_A_DoubleClick(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            Formato.sgUnit_ID = Strings.Mid(LST_IR_A.Text, 4, 15).Trim();
            Formato.sgName_Unit = Strings.Mid(LST_IR_A.Text, 23, 30).Trim();

            Formato.bgForma = true;
            frm_unidades tempLoadForm = frm_unidades.DefInstance;
            if (Formato.bgForma)
            {
                frm_unidades.DefInstance.Show();
                this.Close();
            }
            else
            {
                frm_unidades.DefInstance.Close();
            }

            this.Cursor = Cursors.Default;
        }
        private void CORIRUNI_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}