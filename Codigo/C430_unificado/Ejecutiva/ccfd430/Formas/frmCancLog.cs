using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmCancLog
		: System.Windows.Forms.Form
		{
            //'*:********************************************************************************
            //'*:                        EISSA / Banamex - Sistemas                            **
            //'*:------------------------------------------------------------------------------**
            //'*: Responsable:                Miguel A. De la Rosa García (MRG)                **
            //'*: Fecha de Creacion:          16 de Diciembre del 2004                         **
            //'*: Versión:                    1.0.0                                            **
            //'*: Plataforma de Desarrollo:   Visual Basic 6.0                                 **
            //'*:                                                                              **
            //'*: Descripción:    Pantalla para mostrar la salida del proceso maker de         **
            //'*:                 cancelaciones de cuentas de tarjetahabientes o empresas.     **
            //'*:********************************************************************************

            public void prLimpiarLog()
            {
                txtLog.Text = String.Empty;
            }

            public void prLog(string asMsg)
            {
                txtLog.Text = txtLog.Text + asMsg;
            }

            private void cmdCerrar_Click(object sender, EventArgs e)
            {
                //Unload Me;
                this.Close();
            }

            private void Form_Load()
            {
                this.prLimpiarLog();
            }
	
		}
}