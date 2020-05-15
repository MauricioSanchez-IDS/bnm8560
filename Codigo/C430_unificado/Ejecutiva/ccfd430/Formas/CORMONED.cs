using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMONE
        : System.Windows.Forms.Form
    {

        private void Command1_Click(Object eventSender, EventArgs eventArgs)
        {
            object MOREROWS = null;
            string MapEstatus = String.Empty;
            string nombrePais = Text1.Text;
            try
            {
                CORVAR.pszgblsql = " select alpha_currency_code,numeric_currency_code,pais_tasa1,pais_tasa2,pais_tipo from MTCPAIS01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where nombre_pais = '" + nombrePais + "'";
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    //UPGRADE_WARNING: (1037) Couldn't resolve default property of object MOREROWS.
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion).Equals(VBSQL.MOREROWS))
                    {
                        MaskEdBox2.CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                        MaskEdBox3.CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                        MaskEdBox4.CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                        MaskEdBox5.CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                        MapEstatus = VBSQL.SqlData(CORVAR.hgblConexion, 5).Trim();
                        if (StringsHelper.DoubleValue(MapEstatus) == 0)
                        {
                            Check1.CheckState = CheckState.Unchecked;
                        }
                        else
                        {
                            Check1.CheckState = CheckState.Checked;
                        }
                    }
                    else
                    {
                        MaskEdBox2.CtlText = " ";
                        MessageBox.Show("No se localizó el País solicitado", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MaskEdBox2.CtlText = " ";
                    MessageBox.Show("No se encontro el País solicitado", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string MapEstatus = String.Empty;
            double rango1 = 0;
            double rango2 = 0;

            string nombrePais = Text1.Text;
            byte sicontinua = 0;
            try
            {
                CORVAR.pszgblsql = " select alpha_currency_code,numeric_currency_code,pais_tasa1,pais_tasa2,pais_tipo from MTCPAIS01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where nombre_pais = '" + nombrePais + "'";
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    //UPGRADE_WARNING: (1068) hgblConexion of type Variant is being forced to int.
                    //UPGRADE_WARNING: (1037) Couldn't resolve default property of object MOREROWS.
                    if (VBSQL.SqlNextRow(Convert.ToInt32(CORVAR.hgblConexion)).Equals(VBSQL.MOREROWS))
                    {
                        sicontinua = 1;
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el País capturado", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                        sicontinua = 0;
                    }
                }
                else
                {
                    MaskEdBox2.CtlText = " ";
                    MessageBox.Show("No se encontro el País solicitado", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    sicontinua = 0;
                }

                if (sicontinua == 1)
                {
                    if (Check1.CheckState == CheckState.Unchecked)
                    {
                        MapEstatus = "0";
                    }
                    else
                    {
                        MapEstatus = "1";
                    }

                    if (MaskEdBox4.CtlText.Trim().Length == 0)
                    { //no debe poner blancos en rango1 debe poner ceros
                        MaskEdBox4.CtlText = "0.00";
                    }

                    if (MaskEdBox5.CtlText.Trim().Length == 0)
                    { //no debe poner blancos en rango2 debe ponder  ceros
                        MaskEdBox5.CtlText = "0.00";
                    }

                    rango1 = Conversion.Val(MaskEdBox4.CtlText);
                    rango2 = Conversion.Val(MaskEdBox5.CtlText);

                    if (MapEstatus == "1")
                    {
                        if ((rango1 > 0) && (rango2 > 0))
                        {
                            if (rango1 < rango2)
                            {
                                sicontinua = 1;
                            }
                            else
                            {
                                sicontinua = 0;
                                MessageBox.Show("El valor de [Tasa cambio mínima] debe ser menor al valor de [Tasa cambio máxima].", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            sicontinua = 0;
                            MessageBox.Show("El valor de [Tasa cambio mínima] y [Tasa cambio máxima] debe ser mayor a cero.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        if ((rango1 == 0) && (rango2 == 0))
                        {
                            sicontinua = 1;
                        }
                        else
                        {
                            sicontinua = 0;
                            MessageBox.Show("El valor de [Tasa cambio mínima] y [Tasa cambio máxima] deben ser igual a cero.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Cursor = Cursors.Default;
                        }
                    }
                }

                if (sicontinua == 1)
                {
                    if ((MaskEdBox2.CtlText.Trim().Length == 3) && (MaskEdBox3.CtlText.Trim().Length == 3))
                    {
                        CORVAR.pszgblsql = " update MTCPAIS01 set pais_tipo = " + Conversion.Str(MapEstatus) + ", ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "  alpha_currency_code='" + MaskEdBox2.CtlText.Trim() + "', ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "  numeric_currency_code ='" + MaskEdBox3.CtlText.Trim() + "', ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "  pais_tasa1 = " + MaskEdBox4.CtlText + ", ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "  pais_tasa2 = " + MaskEdBox5.CtlText;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where nombre_pais = '" + Text1.Text + "'";
                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            MessageBox.Show("Actualización de Moneda Exitosa", Application.ProductName);
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            MessageBox.Show(" No se Actualizo Moneda ", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La longitud del código de moneda numérico debe ser de 3 posiciones con ceros a la izquierda.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(Command2_Click)", e);
            }

        }

        private void Command3_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            Text1.Text = "";
            MaskEdBox2.CtlText = "";
            MaskEdBox3.CtlText = "";
            MaskEdBox4.CtlText = "0.00";
            MaskEdBox5.CtlText = "0.00";
            Check1.CheckState = CheckState.Unchecked;
        }

        private void MaskEdBox2_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true);
        }

        private void MaskEdBox3_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValEntero, true, false);
        }

        private void MaskEdBox4_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
        }

        private void MaskEdBox5_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
        }
        private void CORMONE_Closed(Object eventSender, EventArgs eventArgs)
        {
            MemoryHelper.ReleaseMemory();
        }
    }
}