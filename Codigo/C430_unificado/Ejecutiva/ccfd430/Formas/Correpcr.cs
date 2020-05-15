using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORREPCR
        : System.Windows.Forms.Form
    {


        int iErr = 0; //Para Control local
        int lEmpCve = 0;
        int hwndPreviewWindow = 0;
        string pszDirectorio = String.Empty;
        string pszNomArch = String.Empty;





        public void Valor_Parametros()
        {

            double dFecha = 0;
            double dFechaAnt = 0;
            int iPorComp = 0;
            int iPorDisp = 0;

            CORPARREP.DefInstance.Tag = "FECHA";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORPARREP.DefInstance.ShowDialog();
            string pszContinuar = CORPARREP.DefInstance.Tag.ToString();
            CORPARREP.DefInstance.Close();
            if (pszContinuar == "CONTINUAR")
            {
                dFecha = CORVAR.dgblParametroRep;
                dFechaAnt = CORVAR.dgblParametroRep1;
                CORVAR.dgblParametroRep = 0;
                CORPARREP.DefInstance.Tag = "PORCENTAJEC";
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORPARREP.DefInstance.ShowDialog();
                pszContinuar = CORPARREP.DefInstance.Tag.ToString();
                CORPARREP.DefInstance.Close();
                if (pszContinuar == "CONTINUAR")
                {
                    iPorComp = Convert.ToInt32(CORVAR.dgblParametroRep);
                    CORPARREP.DefInstance.Tag = "PORCENTAJED";
                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    CORPARREP.DefInstance.ShowDialog();
                    pszContinuar = CORPARREP.DefInstance.Tag.ToString();
                    CORPARREP.DefInstance.Close();
                    if (pszContinuar == "CONTINUAR")
                    {
                        iPorDisp = Convert.ToInt32(CORVAR.dgblParametroRep);
                        CORPARREP.DefInstance.Close();
                        //actualiza la tabla de parametros
                        CORVAR.pszgblsql = "UPDATE MTCPGS01 set pgs_rep_fec = " + Conversion.Str(dFecha) + ",";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "pgs_rep_fec_ant = " + Conversion.Str(dFechaAnt) + ",";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "pgs_rep_porc_comp = " + Conversion.Str(iPorComp) + ",";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "pgs_rep_porc_disp = " + Conversion.Str(iPorDisp);

                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            Genera_Reporte();
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("No se modificarón las fechas en datos Generales", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    }
                }
            }
        }


        public void Genera_Reporte()
        {

            //***** INICIO CODIGO NUEVO FSWBMX *****
            ID_REP_CRYSTAL.Connect = "DSN=" + CORDBLIB.gsServidor + ";UID=" + CORDBLIB.gsUsuario + ";PWD=" + CORDBLIB.gsPassword + ";DSQ=" + CORDBLIB.gsBaseDatos + ";keeporgmultibyte=1";
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            ID_REP_CRYSTAL.set_ParameterFields(0, "0prefijo" + ";" + CORVAR.igblPref.ToString());
            ID_REP_CRYSTAL.set_ParameterFields(1, "1banco" + ";" + CORVAR.igblBanco.ToString());
            ID_REP_CRYSTAL.ReportFileName = pszDirectorio + pszNomArch; //Nombre del reporte
            ID_REP_CRYSTAL.Destination = Crystal.DestinationConstants.crptToWindow; //windows

            ID_REP_CRYSTAL.Action = 1; //Imprime el reporte
            //AIS-1182 NGONZALEZ
            hwndPreviewWindow = API.USER.GetActiveWindow();
            this.Cursor = Cursors.Default;
            //AIS-1182 NGONZALEZ
            while (API.USER.IsWindow(hwndPreviewWindow) != 0)
            {
                Application.DoEvents();
            };

            // Close the report
            ID_REP_CRYSTAL.ReportFileName = CORVB.NULL_STRING;

        }


        private void CORREPCR_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == CORVB.KEY_ESCAPE)
            {
                this.Close();
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            string pszDirectorio = String.Empty;

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            this.Cursor = Cursors.Default;

            ID_REP_ARCH_FLB.Path = CORVAR.pszgblPathRepCrystal;
            //ID_REP_ARCH_FLB.Path = Obten_Dato_Ini("Corporativa", "ReportesCR")
            //pszDirectorio = ID_REP_ARCH_FLB.Path

            //If Dir$(pszDirectorio, vbDirectory) = NULL_STRING Then
            //  MsgBox "El directorio de reportes " + ID_REP_ARCH_FLB.Path + " no existe ", MB_ICONEXCLAMATION + MB_OK, STR_APP_TIT
            //Else
            ID_REP_ARCH_FLB.Pattern = "*.RPT";
            //End If

        }

        private void ID_REP_ARCH_FLB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            pszNomArch = ID_REP_ARCH_FLB.FileName;

        }

        private void ID_REP_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iSubNum = 0;
            int iRepNum = 0;
            int iResult = 0;

            string pszReporte = String.Empty;
            string pszArchCR = String.Empty;
            int iCont = 0;
            string pszStoreProc = String.Empty;


            //  pszDirectorio = Obten_Dato_Ini("Corporativa", "ReportesCR")
            try
            {
                pszDirectorio = CORVAR.pszgblPathRepCrystal;
                //  If Dir$(pszDirectorio, vbDirectory) = NULL_STRING Then
                //    MsgBox "El directorio de reportes " + ID_REP_ARCH_FLB.Path + " no existe ", MB_ICONEXCLAMATION + MB_OK, STR_APP_TIT
                //  End If

                if (pszNomArch == CORVB.NULL_STRING)
                {
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Seleccione un reporte. ", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return;
                }

                if (pszNomArch == "gerencial.rpt")
                {


                    // obtiene los porcentajes y dia de corte
                    // pszgblsql = "SELECT pgs_rep_porc_comp,pgs_rep_porc_disp,pgs_dia_corte FROM MTCPGS01" se modifica 19/02/01 YMF
                    CORVAR.pszgblsql = "Select pgs_rep_porc_comp,pgs_rep_porc_disp,pgs_dia_corte from  MTCPGS01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE pgs_rep_prefijo =" + CORVAR.igblPref.ToString() + " and pgs_rep_banco =" + CORVAR.igblBanco.ToString();
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            CORVAR.iPorComp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            CORVAR.iPorDisp = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                            CORVAR.iDiaCorte = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                        }
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    //Pide los parametros
                    Valor_Parametros();

                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    Genera_Reporte();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_REP_OK_PB_Click)", e);
            }

        }

        private void ID_REP_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }
        private void CORREPCR_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}