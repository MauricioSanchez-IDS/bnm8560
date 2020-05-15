using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORRPACL
        : System.Windows.Forms.Form
    {


        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Reporte de aclaraciones a la fecha definida         **
        //**                                                                        **
        //**       Responsable: Felipe Zacarias Jimenez                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        //Variable para la conexion a aclaraciones
        int hConexion = 0;

        private void Carga_Aclaraciones(string pszFechaCorte)
        {

            int iPrefijo = 0;
            int lEmpNum = 0;
            int iEjeNum = 0;
            int iRoll = 0;
            int iDigito = 0;
            int lFolio = 0;
            int lVencim = 0;
            double dImporte = 0;
            int iStatus = 0;
            int iTipo = 0;
            string pszNombre = String.Empty;
            string pszNomEje = String.Empty;

            string pszFechaV = String.Empty;
            string pszSQL = String.Empty;
            string pszCuenta = String.Empty;
            int hAclaracion = 0;
            string pszFechaPaso = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            ID_ACL_REP_SS.ReDraw = false;

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "corte_acl " + pszFechaCorte + "," + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "corte_acl " + pszFechaCorte + "," + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            int iRen = CORVB.NULL_INTEGER;

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iPrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                    lEmpNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL)));
                    iEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FOURTH_COL)));
                    iRoll = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIFTH_COL)));
                    iDigito = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SIXTH_COL)));
                    lFolio = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SEVENTH_COL)));
                    lVencim = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.EIGTH_COL)));
                    dImporte = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.NINETH_COL));
                    iStatus = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.TEN_COL)));
                    iTipo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.ELEVEN_COL)));
                    pszNomEje = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.TWELVE_COL);

                    iRen++;
                    ID_ACL_REP_SS.MaxRows = iRen;

                    ID_ACL_REP_SS.Col = 1;
                    ID_ACL_REP_SS.Row = iRen;

                    //***** Código Anterior     ***********
                    //      pszCuenta = Format$(iPrefijo, "0000") + Format$(igblBanco, "00") + Format$(lEmpNum, sMascara(Empresa)) + Format$(iEjeNum, "00000") + Format$(iRoll, "0") + Format$(iDigito, "0")
                    //***** Fin Código Anterior ***********

                    //EISSA 05.10.2001 Cambio para obtener el rollover en caso de no encontrarse en EJE, obtenerlo de THX
                    //UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour.
                    //UPGRADE_TODO: (1067) Member Ejecutivo is not defined in type int.
                    //UPGRADE_TODO: (1067) Member Empresa is not defined in type int.
                    //AIS-1150 NGONZALEZ
                    pszCuenta = StringsHelper.Format(iPrefijo, "0000") + StringsHelper.Format(CORVAR.igblBanco, "00") + StringsHelper.Format(lEmpNum, Formato.sMascara((Formato.iTipo)Convert.ToInt32(Formato.iTipo.Empresa))) + StringsHelper.Format(iEjeNum, Formato.sMascara((Formato.iTipo)Convert.ToInt32(Formato.iTipo.Ejecutivo))) + StringsHelper.Format(iRoll, "0") + StringsHelper.Format(iDigito, "0");
                    //EISSA 05.10.2001 FIN

                    ID_ACL_REP_SS.Text = Strings.Mid(pszCuenta, 1, 4) + "-" + Strings.Mid(pszCuenta, 5, 4) + "-" + Strings.Mid(pszCuenta, 9, 4) + "-" + Strings.Mid(pszCuenta, 13);

                    ID_ACL_REP_SS.Col = 2;
                    ID_ACL_REP_SS.Row = iRen;
                    ID_ACL_REP_SS.Text = StringsHelper.Format(lFolio, "000000");

                    ID_ACL_REP_SS.Col = 3;
                    ID_ACL_REP_SS.Row = iRen;
                    ID_ACL_REP_SS.Text = Strings.Mid(lVencim.ToString(), 7, 2) + "/" + Strings.Mid(lVencim.ToString(), 5, 2) + "/" + Strings.Mid(lVencim.ToString(), 1, 4);

                    ID_ACL_REP_SS.Col = 4;
                    ID_ACL_REP_SS.Row = iRen;
                    ID_ACL_REP_SS.Text = pszNomEje.Trim();

                    ID_ACL_REP_SS.Col = 5;
                    ID_ACL_REP_SS.Row = iRen;
                    ID_ACL_REP_SS.Text = StringsHelper.Format(dImporte, "###,###,##0.00");

                    ID_ACL_REP_SS.Col = 6;
                    ID_ACL_REP_SS.Row = iRen;
                    if (iStatus <= 899 || iStatus == 901)
                    {
                        ID_ACL_REP_SS.Text = StringsHelper.Format(iStatus, "0000") + " Pendiente";
                    }
                    else if (iStatus == 900)
                    {
                        ID_ACL_REP_SS.Text = StringsHelper.Format(iStatus, "0000") + " Banco";
                    }
                    else if (iStatus == 902)
                    {
                        if (dImporte > CORVB.NULL_INTEGER)
                        {
                            ID_ACL_REP_SS.Text = StringsHelper.Format(iStatus, "0000") + " Cliente";
                        }
                        else
                        {
                            ID_ACL_REP_SS.Text = StringsHelper.Format(iStatus, "0000") + " Pendiente";
                        }
                    }
                    else if (iStatus >= 903)
                    {
                        ID_ACL_REP_SS.Text = StringsHelper.Format(iStatus, "0000") + " Cliente";
                    }
                };
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (iRen == CORVB.NULL_INTEGER)
            {
                this.Cursor = Cursors.Default;
                ID_ACL_REP_SS.MaxRows = CORVB.NULL_INTEGER;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen registros para consultar.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            ID_ACL_REP_SS.ReDraw = true;

            this.Cursor = Cursors.Default;

        }

        private void CORRPACL_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                ID_ACL_FEC_DTB.Focus();
                this.Cursor = Cursors.Default;

            }
        }

        private void CORRPACL_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            this.Show();
            this.Refresh();

            Formatea_Spread();
            this.Cursor = Cursors.Default;

        }


        private void Formatea_Spread()
        {

            FarPoint.Win.Spread.CellType.TextCellType celdaType = new FarPoint.Win.Spread.CellType.TextCellType();

            ID_ACL_REP_SS.Row = -1;
            ID_ACL_REP_SS.Col = -1;
            ID_ACL_REP_SS.CellType = celdaType;

            ID_ACL_REP_SS.Row = -1;
            ID_ACL_REP_SS.Col = 1;
            //  ID_ACL_REP_SS.TypeTextAlignHoriz = 0

            ID_ACL_REP_SS.Row = -1;
            ID_ACL_REP_SS.Col = 2;
            //  ID_ACL_REP_SS.TypeTextAlignHoriz = 0

            ID_ACL_REP_SS.Row = -1;
            ID_ACL_REP_SS.Col = 3;
            //  ID_ACL_REP_SS.TypeTextAlignHoriz = 0

            ID_ACL_REP_SS.Row = -1;
            ID_ACL_REP_SS.Col = 4;
            //  ID_ACL_REP_SS.TypeTextAlignHoriz = 1

            ID_ACL_REP_SS.Row = -1;
            ID_ACL_REP_SS.Col = 5;
            //  ID_ACL_REP_SS.TypeTextAlignHoriz = 2

            ID_ACL_REP_SS.Row = -1;
            ID_ACL_REP_SS.Col = 6;
            //  ID_ACL_REP_SS.TypeTextAlignHoriz = 0

            ID_ACL_REP_SS.Row = CORVB.NULL_INTEGER;
            ID_ACL_REP_SS.Col = 1;
            ID_ACL_REP_SS.set_ColWidth(1, 20);
            ID_ACL_REP_SS.Text = "Cuenta";

            ID_ACL_REP_SS.Col = 2;
            ID_ACL_REP_SS.Text = "Folio";

            ID_ACL_REP_SS.Col = 3;
            ID_ACL_REP_SS.set_ColWidth(3, 12);
            ID_ACL_REP_SS.Text = "Vencimiento";

            ID_ACL_REP_SS.Col = 4;
            ID_ACL_REP_SS.set_ColWidth(4, 23);
            ID_ACL_REP_SS.Text = "Nombre";

            ID_ACL_REP_SS.Col = 5;
            ID_ACL_REP_SS.set_ColWidth(5, 10);
            ID_ACL_REP_SS.Text = "Importe";

            ID_ACL_REP_SS.Col = 6;
            ID_ACL_REP_SS.set_ColWidth(6, 15);
            ID_ACL_REP_SS.Text = "Status S.A.A.";

            ID_ACL_REP_SS.GrayAreaBackColor = Color.Gray;
            //  ID_ACL_REP_SS.AllowSelBlock = False
            //  ID_ACL_REP_SS.AllowResize = False
            ID_ACL_REP_SS.Visible = true;

        }

        private void ID_ACL_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            ID_ACL_REP_SS.PrintAbortMsg = "Imprimiendo";
            ID_ACL_REP_SS.PrintJobName = "Reporte de Aclaraciones";
            ID_ACL_REP_SS.PrintHeader = "/cReporte de Aclaraciones/n/c" + "A la fecha: " + ID_ACL_FEC_DTB.CtlText;
            ID_ACL_REP_SS.PrintFooter = "/r" + DateTime.Now.ToString();

            ID_ACL_REP_SS.PrintBorder = true;
            ID_ACL_REP_SS.PrintColHeaders = true;
            ID_ACL_REP_SS.PrintColor = true;
            ID_ACL_REP_SS.PrintGrid = false;

            ID_ACL_REP_SS.PrintMarginTop = 1000;
            ID_ACL_REP_SS.PrintMarginBottom = 1000;
            ID_ACL_REP_SS.PrintMarginLeft = 150;
            ID_ACL_REP_SS.PrintMarginRight = 150;

            ID_ACL_REP_SS.PrintShadows = false;
            ID_ACL_REP_SS.PrintUseDataMax = true;
            ID_ACL_REP_SS.PrintType = (short)CORVB.NULL_INTEGER;
            ID_ACL_REP_SS.Print();
            //ID_ACL_REP_SS.Action = (FPSpreadADO.ActionConstants)13;

        }

        private void ID_ACL_REF_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Carga_Aclaraciones(Strings.Mid(ID_ACL_FEC_DTB.CtlText, 7, 4) + Strings.Mid(ID_ACL_FEC_DTB.CtlText, 4, 2) + Strings.Mid(ID_ACL_FEC_DTB.CtlText, 1, 2));
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "()", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_ACL_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Close();

            this.Cursor = Cursors.Default;

        }

        //UPGRADE_NOTE: (7001) The following declaration (Nombre_Eje) seems to be dead code
        //private string Nombre_Eje( string pszCveEje,  string pszCveEmp)
        //{
        //
        //int hEjecutivo = 0;
        //string pszNomEje = String.Empty;
        //
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //  pszgblsql = "SELECT ths_nombre FROM " + DB_SYB_THS + " WHERE gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszCveEmp + " AND eje_num = " + pszCveEje
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = "SELECT ths_nombre FROM " + CORBD.DB_SYB_THS + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszCveEmp + " AND eje_num = " + pszCveEje;
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
        //{
        //pszNomEje = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL);
        //}
        //} else
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //AIS-1182 NGONZALEZ
        //CORVAR.igblErr = API.USER.PostMessage(CORRPACL.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
        //}
        //
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //return pszNomEje.Trim();
        //
        //}
        private void CORRPACL_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}