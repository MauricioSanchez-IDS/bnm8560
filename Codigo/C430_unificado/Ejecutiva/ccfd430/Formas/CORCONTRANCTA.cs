using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class Corcntrancta
        : System.Windows.Forms.Form
    {

        private void Corcntrancta_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        int iCol = 0;
        int iRow = 0;
        string str_emp_num = String.Empty;
        string str_eje_num = String.Empty;
        string str_eje_roll_over = String.Empty;
        string str_eje_digit = String.Empty;
        string str_dia_corte = String.Empty;
        string str_mes_corte = String.Empty;
        string str_mes_fiscal = String.Empty;
        string str_Fecha_Act = String.Empty;
        string str_Fecha_Ini_Mes = String.Empty;
        string str_Fecha_Trim_1 = String.Empty;
        string str_Fecha_Trim_2 = String.Empty;
        string str_Fecha_Trim_3 = String.Empty;
        string str_Fecha_Trim_4 = String.Empty;

        private void cmd_buscar_Click(Object eventSender, EventArgs eventArgs)
        {
            int I = 0;
            try
            {
                if (Obten_Cadenas(MskPrefBanc.CtlText + MskEmpEjeRollDigit.CtlText))
                {
                    if (Busca_Nombre())
                    {
                        Busco_Fechas();
                        Busco_Transaccion();
                    }
                    else
                    {
                        //No se encontro ninguna cuenta similar en MTCTHS01 y MTCEJE01
                    }
                }
                else
                {
                    //No pudo obtener las cadenas de eje_prefijo, gpo_banco, emp_num, eje_num, eje_roll_over, eje_digit
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmd_buscar_Click)", e);
            }

        }

        private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            string cadena = String.Empty;
            this.Height = (int)VB6.TwipsToPixelsY(4950);
            this.Width = (int)VB6.TwipsToPixelsX(11730);
            MskPrefBanc.Format = "#### ##";
            MskPrefBanc.CtlText = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString();
            MskEmpEjeRollDigit.Left = (int)VB6.TwipsToPixelsX(2670);
            MskEmpEjeRollDigit.Width = (int)VB6.TwipsToPixelsX(1130);
            //UPGRADE_ISSUE: (2069) Line property Line2.X2 was not upgraded.
            //AIS-Estas lineas parecen no ser necesarias migrarlas NGONZALEZ
            //Line2(0).X2 = 3800;
            //UPGRADE_ISSUE: (2069) Line property Line2.X2 was not upgraded.
            //Line2(1).X2 = 3800;
            //UPGRADE_ISSUE: (2069) Line property Line1.X1 was not upgraded.
            //Line1(0).X1 = 3800;
            //UPGRADE_ISSUE: (2069) Line property Line1.X2 was not upgraded.
            //Line1(1).X2 = 3800;
            MskPrefBanc.Enabled = false;
        }

        private bool Busca_Nombre()
        {

            bool result = false;
            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_nombre";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJE01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Val(str_emp_num).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + Conversion.Val(str_eje_num).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_roll_over = " + Conversion.Val(str_eje_roll_over).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_digit = " + Conversion.Val(str_eje_digit).ToString();
            if (CORPROC2.Cuenta_Registros() > 0)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        txt_name.Text = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                    };
                    result = true;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    return result;
                }
            }
            else
            {
                //No se encontro ningun registro en MTCEJE01 y busca en MTCTHS01
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " ths_nombre";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCTHS01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Val(str_emp_num).ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + Conversion.Val(str_eje_num).ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_roll_over = " + Conversion.Val(str_eje_roll_over).ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_digit = " + Conversion.Val(str_eje_digit).ToString();
                if (CORPROC2.Cuenta_Registros() > 0)
                {
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            txt_name.Text = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                        };
                        result = true;
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        return result;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro ninguna cuenta similar", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MskEmpEjeRollDigit.CtlText = "";
                    result = false;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    return result;
                }
            }
            return result;
        }

        private bool Obten_Cadenas(string sCadena)
        {
            bool result = false;
            try
            {
                result = true;

                str_emp_num = Conversion.Val(Strings.Mid(sCadena, 7, Formato.igLongitudEmpresa)).ToString().Trim();
                str_emp_num = StringsHelper.Format(Conversion.Val(str_emp_num.Substring(0, Math.Min(str_emp_num.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa));

                str_eje_num = Conversion.Val(Strings.Mid(sCadena, Formato.igLongitudEmpresa + 7, Formato.igLongitudEjecutivo)).ToString().Trim();
                str_eje_num = StringsHelper.Format(str_eje_num, Formato.sMascara(Formato.iTipo.Ejecutivo));

                str_eje_roll_over = Conversion.Val(Strings.Mid(sCadena, 15, 1)).ToString().Trim();
                str_eje_digit = Conversion.Val(Strings.Mid(sCadena, 16, 1)).ToString().Trim();
            }
            catch
            {

                return false;
            }

            return result;
        }

        private void Busco_Transaccion()
        {
            double dTranAbono = 0;
            double dTranComis = 0;
            double dTranDispo = 0;
            double dTranCompra = 0;

            //Month
            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " a.his_importe,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " b.tip_transaccion";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCHIS01 a, MTCTRA01 b";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " Where a.his_transaccion = b.cve_transaccion";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + Conversion.Val(str_emp_num).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num = " + Conversion.Val(str_eje_num).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_roll_over = " + str_eje_roll_over;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_digit = " + str_eje_digit;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.his_proceso_amd >= " + str_Fecha_Ini_Mes;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.his_proceso_amd <= " + str_Fecha_Act;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by b.tip_transaccion";
            if (CORPROC2.Cuenta_Registros() >= 1)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    dTranAbono = 0;
                    dTranComis = 0;
                    dTranCompra = 0;
                    dTranDispo = 0;
                    iCol = 1;
                    iRow = 1;

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        switch (VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim().ToUpper())
                        {
                            case "ABONO":
                                dTranAbono += Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                            case "COMIS":
                                dTranComis += Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                            case "COMPRA":
                                dTranCompra += Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                            case "DISPO":
                                dTranDispo += Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                        }
                    };
                }
                vaSpread.Col = iCol;
                for (iRow = 1; iRow <= 9; iRow++)
                {
                    vaSpread.Row = iRow;
                    switch (iRow)
                    {
                        case 1:  //Purchase 
                            vaSpread.Text = dTranCompra.ToString();
                            break;
                        case 2:  //Cash Bal 
                            vaSpread.Text = dTranDispo.ToString();
                            break;
                        case 3:  //Misc Deb 
                            vaSpread.Text = "0";
                            break;
                        case 4:  //Misc Cre 
                            vaSpread.Text = "0";
                            break;
                        case 5:  //Payments 
                            vaSpread.Text = dTranAbono.ToString();
                            break;
                        case 6:
                            break;
                        case 7:  //Tax 
                            vaSpread.Text = "0";
                            break;
                        case 8:  //Interest 
                            vaSpread.Text = "0";
                            break;
                        case 9:  //Fees 
                            vaSpread.Text = "0";
                            break;
                    }
                }
            }
            else
            {
                //No se encontro ninguna transaccion en el mes
            }

            //Cycle
            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " a.his_importe,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " b.tip_transaccion";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCHIS01 a, MTCTRA01 b";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " Where a.his_transaccion = b.cve_transaccion";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + Conversion.Val(str_emp_num).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num = " + Conversion.Val(str_eje_num).ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_roll_over = " + str_eje_roll_over;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_digit = " + str_eje_digit;

            CORVAR.pszgblsql = CORVAR.pszgblsql + " and his_mes_y_ciclo_corte  = " + str_mes_corte + str_dia_corte;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by b.tip_transaccion";
            if (CORPROC2.Cuenta_Registros() >= 1)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    dTranAbono = 0;
                    dTranComis = 0;
                    dTranCompra = 0;
                    dTranDispo = 0;
                    iCol = 2;
                    iRow = 1;

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        switch (VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim().ToUpper())
                        {
                            case "ABONO":
                                dTranAbono += Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                            case "COMIS":
                                dTranComis += Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                            case "COMPRA":
                                dTranCompra += Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                            case "DISPO":
                                dTranDispo += Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                                break;
                        }
                    };
                }
                vaSpread.Col = iCol;
                for (iRow = 1; iRow <= 9; iRow++)
                {
                    vaSpread.Row = iRow;
                    switch (iRow)
                    {
                        case 1:  //Purchase (Compra) 
                            vaSpread.Text = dTranCompra.ToString();
                            break;
                        case 2:  //Cash Bal (Disposicion de Efectivo) 
                            vaSpread.Text = dTranDispo.ToString();
                            break;
                        case 3:  //Misc Deb (Misc Debito) 
                            vaSpread.Text = "0";
                            break;
                        case 4:  //Misc Cre (Misc Credito) 
                            vaSpread.Text = "0";
                            break;
                        case 5:  //Payments (Pagos) 
                            vaSpread.Text = dTranAbono.ToString();
                            break;
                        case 6:
                            break;
                        case 7:  //Tax  (Iva) 
                            vaSpread.Text = "0";
                            break;
                        case 8:  //Interest (Intereses) 
                            vaSpread.Text = "0";
                            break;
                        case 9:  //Fees (Comision) 
                            vaSpread.Text = "0";
                            break;
                    }
                }
            }
            else
            {
                //No se encontro ninguna transaccion en el ciclo
            }





        }

        private void Busco_Fechas()
        {
            CORVAR.pszgblsql = "exec dbo.sp_Valida_Fechas " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + Conversion.Val(str_emp_num).ToString();
            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    str_Fecha_Act = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    str_Fecha_Ini_Mes = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    str_Fecha_Trim_1 = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    str_Fecha_Trim_2 = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                    str_Fecha_Trim_3 = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                    str_Fecha_Trim_4 = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                    str_mes_corte = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                    str_dia_corte = VBSQL.SqlData(CORVAR.hgblConexion, 8);
                    str_mes_fiscal = VBSQL.SqlData(CORVAR.hgblConexion, 9);
                };
            }
        }
        private void Corcntrancta_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}