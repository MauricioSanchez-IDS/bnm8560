using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORPARREP
        : System.Windows.Forms.Form
    {

        int iParametro = 0;
        string pszParametro = String.Empty;
        int pszFechaAnt = 0;
        int pszPorcComp = 0;
        int pszPorcDisp = 0;

        public void Proceso_Datos()
        {
            int Anio = 0;
            int iMes = 0;


            bool actualiza = true;
            iParametro = Convert.ToInt32(Conversion.Val(ID_PAR_PAR_TXT.Text));


            switch (pszParametro)
            {
                case "Fecha":

                    iParametro = Convert.ToInt32(Conversion.Val(ID_PAR_PAR_TXT.Text + Conversion.Str(CORVAR.iDiaCorte).Trim()));

                    if (iParametro == 0)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Se requiere capturar la Fecha.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        actualiza = false;
                    }
                    else
                    {


                        Anio = Convert.ToInt32(Conversion.Val(Strings.Mid(Conversion.Str(iParametro).Trim(), 1, 4)));
                        iMes = Convert.ToInt32(Conversion.Val(Strings.Mid(Conversion.Str(iParametro).Trim(), 5, 2)));
                        if (Anio > 2050 || Anio < 1980)
                        {
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El Año es incorrecto.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            actualiza = false;
                        }

                        if (iMes > 12 || iMes < 1)
                        {
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El mes es incorrecto.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            actualiza = false;
                        }
                    }

                    if (actualiza)
                    {
                        if (iMes == 1)
                        {
                            Anio--;
                            iMes = 12;
                        }
                        else
                        {
                            iMes--;
                        }


                        //se asigna el valor a la variable de fecha anterior
                        pszFechaAnt = Convert.ToInt32(Conversion.Val(Conversion.Str(Anio) + StringsHelper.Format(iMes, "00") + Conversion.Str(CORVAR.iDiaCorte)));

                        CORVAR.pszgblsql = "UPDATE MTCPGS01 set pgs_rep_fec = " + Conversion.Str(iParametro) + ",";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "pgs_rep_fec_ant = " + Conversion.Str(pszFechaAnt);

                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("No se modificarón las fechas en datos Generales", Application.ProductName);
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Close();
                    }
                    else
                    {
                        ID_PAR_PAR_TXT.Focus();
                    }


                    break;
                case "PorcentajeC":
                    if (iParametro == 0)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Se requiere capturar el porcentaje de compra.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        actualiza = false;
                    }
                    else
                    {
                    }

                    if (actualiza)
                    {
                        CORVAR.pszgblsql = "UPDATE MTCPGS01 set pgs_rep_porc_comp = " + Conversion.Str(iParametro);

                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("No se modifico el porcentaje de compras en datos Generales", Application.ProductName);
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Close();
                    }
                    else
                    {
                        ID_PAR_PAR_TXT.Focus();
                    }

                    break;
                case "PorcentajeD":
                    if (iParametro == 0)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Se requiere capturar el porcentaje de disposiciones.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        actualiza = false;
                    }
                    else
                    {
                    }

                    if (actualiza)
                    {
                        CORVAR.pszgblsql = "UPDATE MTCPGS01 set pgs_rep_porc_disp = " + Conversion.Str(iParametro);

                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                            /*CORREPCR.DefInstance.Genera_Reporte();*/
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se modifico el porcentaje de disposiciones en datos Generales", Application.ProductName);
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                        this.Close();
                    }
                    else
                    {
                        ID_PAR_PAR_TXT.Focus();
                    }


                    break;
            }

        }

        public void Pide_Parametros()
        {

            int iDia = 0;
            int iMesCorte = 0;
            int iAnoCorte = 0;

            if (pszParametro == "Fecha")
            {
                //por default da la fecha de hoy. si el día es menor al dia de corte es un mes menos
                //si es mayor al diad e corte es el mes en curso
                iDia = DateAndTime.Day(DateTime.Now);
                iMesCorte = DateTime.Now.Month;
                iAnoCorte = DateTime.Now.Year;

                if (iDia <= CORVAR.iDiaCorte)
                { //si el dia es menor o igual al dia de corte
                    if (iMesCorte == 1)
                    {
                        iMesCorte = 12;
                        iAnoCorte--;
                    }
                    else
                    {
                        iMesCorte--;
                    }
                }
                ID_PAR_PAR_TXT.Text = (Conversion.Str(iAnoCorte) + StringsHelper.Format(Conversion.Str(iMesCorte), "00")).Trim();
            }





            //parametro de fecha
            if (pszParametro == "Fecha")
            {
                ID_PAR_ETI1_LBL.Text = "Fecha de Corte";
                ID_PAR_ETI1_LBL.AutoSize = true;
                ID_PAR_ETI2_LBL.Text = "Ej. aaaamm";
                ID_PAR_ETI2_LBL.AutoSize = true;
                ID_PAR_PAR_TXT.MaxLength = 6;
            }

            //parametro de porcentaje compras
            if (pszParametro == "PorcentajeC")
            {
                ID_PAR_ETI1_LBL.Text = "Porcentaje de Compras";
                ID_PAR_ETI1_LBL.AutoSize = true;
                ID_PAR_ETI2_LBL.Text = "Rango de 1 a 100";
                ID_PAR_ETI2_LBL.AutoSize = true;
                ID_PAR_PAR_TXT.Text = CORVAR.iPorComp.ToString();
                ID_PAR_PAR_TXT.MaxLength = 3;
            }
            //parametro de porcentaje disposiciones
            if (pszParametro == "PorcentajeD")
            {
                ID_PAR_ETI1_LBL.Text = "Porcentaje de Disposiciones";
                ID_PAR_ETI1_LBL.AutoSize = true;
                ID_PAR_ETI2_LBL.Text = "Rango de 1 a 100";
                ID_PAR_ETI2_LBL.AutoSize = true;
                ID_PAR_PAR_TXT.Text = CORVAR.iPorDisp.ToString();
                ID_PAR_PAR_TXT.MaxLength = 3;
            }

            ID_PAR_PAR_TXT.Focus();




        }



        private void CORPARREP_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                this.Cursor = Cursors.Default;

                switch (this.Tag.ToString())
                {
                    case "FECHA":
                        pszParametro = "Fecha";
                        Pide_Parametros();
                        break;
                    case "PORCENTAJEC":
                        pszParametro = "PorcentajeC";
                        Pide_Parametros();
                        break;
                    case "PORCENTAJED":
                        pszParametro = "PorcentajeD";
                        Pide_Parametros();

                        break;
                }

            }
        }

        private void ID_PAR_CAN_CB_Click(Object eventSender, EventArgs eventArgs)
        {

            CORPARREP.DefInstance.Tag = "CANCELAR";
            this.Hide();
        }


        private void ID_PAR_OK_CB_Click(Object eventSender, EventArgs eventArgs)
        {
            int Anio = 0;
            int iMes = 0;
            bool bDatoCorrecto = false;
            try
            {

                iParametro = Convert.ToInt32(Conversion.Val(ID_PAR_PAR_TXT.Text));

                switch (pszParametro)
                {
                    case "Fecha":
                        bDatoCorrecto = true;



                        if (iParametro == 0)
                        {
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("Se requiere capturar la Fecha.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            ID_PAR_PAR_TXT.Focus();
                            bDatoCorrecto = false;
                        }
                        else
                        {
                            iParametro = Convert.ToInt32(Conversion.Val(ID_PAR_PAR_TXT.Text + Conversion.Str(CORVAR.iDiaCorte).Trim()));
                            Anio = Convert.ToInt32(Conversion.Val(Strings.Mid(Conversion.Str(iParametro).Trim(), 1, 4)));
                            iMes = Convert.ToInt32(Conversion.Val(Strings.Mid(Conversion.Str(iParametro).Trim(), 5, 2)));
                            if (Anio > 2050 || Anio < 1980)
                            {
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("El Año es incorrecto.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                bDatoCorrecto = false;
                            }

                            if (iMes > 12 || iMes < 1)
                            {
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("El mes es incorrecto.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                bDatoCorrecto = false;
                            }
                        }

                        if (bDatoCorrecto)
                        {
                            if (iMes == 1)
                            {
                                Anio--;
                                iMes = 12;
                            }
                            else
                            {
                                iMes--;
                            }

                            //se asigna el valor a la variable de fecha anterior
                            CORVAR.dgblParametroRep1 = Conversion.Val(Conversion.Str(Anio) + StringsHelper.Format(iMes, "00") + Conversion.Str(CORVAR.iDiaCorte));
                            CORVAR.dgblParametroRep = iParametro;
                            CORPARREP.DefInstance.Tag = "CONTINUAR";
                            this.Hide();
                        }
                        else
                        {
                            ID_PAR_PAR_TXT.Focus();
                        }


                        break;
                    case "PorcentajeC":
                        if (iParametro == 0)
                        {
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("Se requiere capturar el porcentaje de compra.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            ID_PAR_PAR_TXT.Focus();
                        }
                        else
                        {
                            CORVAR.dgblParametroRep = iParametro;
                            CORPARREP.DefInstance.Tag = "CONTINUAR";
                            this.Hide();
                        }

                        break;
                    case "PorcentajeD":
                        if (iParametro == 0)
                        {
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("Se requiere capturar el porcentaje de disposiciones.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                            ID_PAR_PAR_TXT.Focus();
                        }
                        else
                        {
                            CORVAR.dgblParametroRep = iParametro;
                            CORPARREP.DefInstance.Tag = "CONTINUAR";
                            this.Hide();
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_PAR_OK_CB_Click)", e);
            }
        }



        public bool Verifica_Numero(string iParNumero)
        {

            bool result = false;
            string iNumero = String.Empty;

            result = true;
            string pszNumero = iParNumero;

            int longitud = pszNumero.Trim().Length;
            for (int i = 1; i <= longitud; i++)
            {
                iNumero = Strings.Mid(pszNumero.Trim(), i, 1);
                if (((int)iNumero[0]) > 57 || ((int)iNumero[0]) < 48)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private void ID_PAR_PAR_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            if (KeyAscii > 57 || KeyAscii < 48)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        private void CORPARREP_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}