using Artinsoft.VB6.Gui;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class frmGeneraCargaIni
        : System.Windows.Forms.Form
    {

        private void frmGeneraCargaIni_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        private void cmdBoton_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (optOption[0].Checked)
                {
                    CRSGeneral.prGenerarCuentasCorp(txtArchivo);
                }
                if (optOption[1].Checked)
                {
                    CRSGeneral.prGenerarRelacionEjeCorp(txtArchivo);
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdBoton_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}