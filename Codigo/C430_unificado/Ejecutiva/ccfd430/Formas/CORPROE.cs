using Artinsoft.VB6.Gui;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORPROE
        : System.Windows.Forms.Form
    {

        private void CORPROE_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        string CuentaBnmx = String.Empty;
        string MapEstatus = String.Empty;

        private void Command1_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                CuentaBnmx = Text1.Text;
                CORVAR.pszgblsql = " select map_cta_citi, map_estatus from MTCMAP01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where map_cta_bnx = '" + CuentaBnmx + "'";
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        Text2.Text = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                        MapEstatus = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                        if (MapEstatus == "")
                        {
                            Check1.CheckState = CheckState.Unchecked;
                        }
                        else
                        {
                            Check1.CheckState = CheckState.Checked;
                        }
                    }
                }
                else
                {
                    Text2.Text = " ";
                    MessageBox.Show("No se encontro la Cuenta Banamex", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(Command1_Click)", e);
            }

        }

        private void Command2_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void Command3_Click(Object eventSender, EventArgs eventArgs)
        {
            if (Check1.CheckState == CheckState.Unchecked)
            {
                MapEstatus = " ";
            }
            else
            {
                MapEstatus = "R";
            }
            try
            {
                CORVAR.pszgblsql = " update MTCMAP01 set map_estatus = '" + MapEstatus + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where map_cta_bnx = '" + Text1.Text + "'";
                if (CORPROC2.Modifica_Registro() != 0)
                {
                    MessageBox.Show("Actualización de Marca Exitosa", Application.ProductName);
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("No se Actualizo Marca", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(Command3_Click)", e);
            }
        }
    }
}