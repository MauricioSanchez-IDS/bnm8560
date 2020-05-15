using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORCOFIR
        : System.Windows.Forms.Form
    {

        private void CORCOFIR_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        const string CAPTION_ALTA_EJE = "Alta de Ejecutivos de Empresas";

        int hCOFConexion = 0;

        private void Carga_Imagen()
        {

            int lejeban = 0;

            string pszNomR1 = CORVB.NULL_STRING;
            string pszNomR2 = CORVB.NULL_STRING;
            string pszNomR3 = CORVB.NULL_STRING;
            string pszNomEjx = CORVB.NULL_STRING;

            try
            {
                CORVAR.pszgblsql = "select ejx_numero,emp_nom_r1, emp_nom_r2, emp_nom_r3  from " + CORBD.DB_SYB_EMP + " WHERE eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco= " + CORVAR.igblBanco.ToString() + " and emp_num = " + CORVAR.lgblEmpCve.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        lejeban = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        pszNomR1 = (VBSQL.SqlData(CORVAR.hgblConexion, 2));
                        pszNomR2 = (VBSQL.SqlData(CORVAR.hgblConexion, 3));
                        pszNomR3 = (VBSQL.SqlData(CORVAR.hgblConexion, 4));
                    }
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                IMAGEN.LeerImagen(ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblEmpCve.ToString());
                IMAGEN.LeerImagen(ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblEmpCve.ToString());
                IMAGEN.LeerImagen(ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " AND gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblEmpCve.ToString());

                CORVAR.pszgblsql = "select ejx_nombre from " + CORBD.DB_SYB_EJX + " where ejx_numero = " + lejeban.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        pszNomEjx = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    }
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                IMAGEN.LeerImagen(ID_FIR_FR4_IMM, "MTCEJX01", "ejx_firma", " where ejx_numero = " + lejeban.ToString());

                ID_FIR_NOM_PNL[0].Caption = pszNomR1.Trim();
                ID_FIR_NOM_PNL[1].Caption = pszNomR2.Trim();
                ID_FIR_NOM_PNL[2].Caption = pszNomR3.Trim();
                ID_FIR_NOM_PNL[3].Caption = pszNomEjx.Trim();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(Carga_Imagen)", e);
            }

        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Cursor = Cursors.WaitCursor;

            this.Top = (int)VB6.TwipsToPixelsY(1230);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Refresh();

            Carga_Imagen();
            //ID_FIR_ACE_PB.SetFocus
            this.Cursor = Cursors.Default;

        }

        private void CORCOFIR_Closed(Object eventSender, EventArgs eventArgs)
        {


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                for (int iCont = 0; iCont <= 3; iCont++)
                {
                    File.Delete(CORVAR.pszgblPathFirmas + "firma" + iCont.ToString() + ".pcx");
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception exc)
            {
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
                CRSGeneral.prObtenError(this.GetType().Name + "(CORCOFIR_Closed)", exc);
            }
        }

        private void ID_CFI_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            PointF p1;
            PointF p2;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                PrinterHelper.Printer.FontName = "LinePrinter";

                PrinterHelper.Printer.FontBold = true;

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print(new String(' ', 50) + "Banamex - Accival" + new String(' ', 40) + DateTime.Now.ToString("dd/MM/yy"));
                PrinterHelper.Printer.Print(new String(' ', 50) + "Consulta de Firmas");
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print(new String(' ', 14) + "Número   :  " + StringsHelper.Format(CORVAR.lgblEmpCve, Formato.sMascara(Formato.iTipo.Empresa)));
                PrinterHelper.Printer.Print(new String(' ', 14) + "Empresa  :  " + CORVAR.pszgblEmpDesc.Trim());
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.FontBold = true;
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.FontBold = false;
                PrinterHelper.Printer.Print(new String(' ', 10) + "REPRESENTANTE 1   : ", ID_FIR_NOM_PNL[0].Caption);
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print(new String(' ', 10) + "REPRESENTANTE 2   : ", ID_FIR_NOM_PNL[1].Caption);
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print(new String(' ', 10) + "REPRESENTANTE 3   : ", ID_FIR_NOM_PNL[2].Caption);
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print(new String(' ', 10) + "EJECUTIVO BANAMEX : ", ID_FIR_NOM_PNL[3].Caption);
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print();

                //AIS-1604 FSQSABORIO   //ScaleMode = Centimeters
                PrinterHelper.Printer.ScaleMode = 7;
                if (ID_FIR_FR1_IMM.Picture != null)
                {
                    p1 = new PointF(20.0357f, 8.3023f);
                    p2 = new PointF(27.107f, 15.419f);
                    PrinterHelper.Printer.PaintPicture(ID_FIR_FR1_IMM.Picture, p1, p2);
                }

                if (ID_FIR_FR2_IMM.Picture != null)
                {
                    p1 = new PointF(20.0357f, 16.605f);
                    p2 = new PointF(27.107f, 23.721f);
                    PrinterHelper.Printer.PaintPicture(ID_FIR_FR2_IMM.Picture, p1, p2);
                }

                if (ID_FIR_FR3_IMM.Picture != null)
                {
                    p1 = new PointF(20.0357f, 24.907f);
                    p2 = new PointF(27.107f, 32.023f);
                    PrinterHelper.Printer.PaintPicture(ID_FIR_FR3_IMM.Picture, p1, p2);
                }

                if (ID_FIR_FR4_IMM.Picture != null)
                {
                    p1 = new PointF(20.0357f, 34.395f);
                    p2 = new PointF(27.107f, 41.512f);
                    PrinterHelper.Printer.PaintPicture(ID_FIR_FR4_IMM.Picture, p1, p2);
                }

                //int hDC = PrinterHelper.Printer.hDC;
                ////AIS-1182 NGONZALEZ
                ////vbMilimeters = 6,
                //CORVAR.igblErr = API.GDI.SetMapMode(hDC, 6);

                //ID_FIR_FR1_IMM.DebugLevel = 1;

                //ID_FIR_FR1_IMM.SettingMode = GEAR.MODE_PRINTDRIVER;
                //ID_FIR_FR1_IMM.SettingValue = 0;
                //ID_FIR_FR1_IMM.PrintSize = GEAR.IG_PRINT_CUSTOM;
                //ID_FIR_FR1_IMM.PrintLeft = Convert.ToInt32(2003.57d);
                //ID_FIR_FR1_IMM.PrintTop = Convert.ToInt32(830.23d);
                //ID_FIR_FR1_IMM.PrintRight = Convert.ToInt32(2710.7d);
                //ID_FIR_FR1_IMM.PrintBottom = Convert.ToInt32(1541.9d);
                //ID_FIR_FR1_IMM.PrintImage = PrinterHelper.Printer.hDC;

                //ID_FIR_FR2_IMM.SettingMode = GEAR.MODE_PRINTDRIVER;
                //ID_FIR_FR2_IMM.SettingValue = 0;
                //ID_FIR_FR2_IMM.PrintSize = GEAR.IG_PRINT_CUSTOM;
                //ID_FIR_FR2_IMM.PrintLeft = Convert.ToInt32(2003.57d);
                //ID_FIR_FR2_IMM.PrintTop = Convert.ToInt32(1660.5d);
                //ID_FIR_FR2_IMM.PrintRight = Convert.ToInt32(2710.7d);
                //ID_FIR_FR2_IMM.PrintBottom = Convert.ToInt32(2372.1d);
                //ID_FIR_FR2_IMM.PrintImage = PrinterHelper.Printer.hDC;

                //ID_FIR_FR3_IMM.SettingMode = GEAR.MODE_PRINTDRIVER;
                //ID_FIR_FR3_IMM.SettingValue = 0;
                //ID_FIR_FR3_IMM.PrintSize = GEAR.IG_PRINT_CUSTOM;
                //ID_FIR_FR3_IMM.PrintLeft = Convert.ToInt32(2003.57d);
                //ID_FIR_FR3_IMM.PrintTop = Convert.ToInt32(2490.7d);
                //ID_FIR_FR3_IMM.PrintRight = Convert.ToInt32(2710.7d);
                //ID_FIR_FR3_IMM.PrintBottom = Convert.ToInt32(3202.3d);
                //ID_FIR_FR3_IMM.PrintImage = PrinterHelper.Printer.hDC;

                //ID_FIR_FR4_IMM.SettingMode = GEAR.MODE_PRINTDRIVER;
                //ID_FIR_FR4_IMM.SettingValue = 0;
                //ID_FIR_FR4_IMM.PrintSize = GEAR.IG_PRINT_CUSTOM;
                //ID_FIR_FR4_IMM.PrintLeft = Convert.ToInt32(2003.57d);
                //ID_FIR_FR4_IMM.PrintTop = Convert.ToInt32(3439.5d);
                //ID_FIR_FR4_IMM.PrintRight = Convert.ToInt32(2710.7d);
                //ID_FIR_FR4_IMM.PrintBottom = Convert.ToInt32(4151.2d);
                //ID_FIR_FR4_IMM.PrintImage = PrinterHelper.Printer.hDC;

                PrinterHelper.Printer.EndDoc();
            }
            catch (Exception exc)
            {
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CFI_IMP_PB_Click)", exc);
            }

        }

        private void ID_FIR_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //***** JPU *****
            //CORMNEJE.DefInstance.Tag = CORCONST.TAG_ALTA;
            //this.Close();
            //CORMNEJE.DefInstance.Show();
            frmEjecutivo.DefInstance.Tag = CORCONST.TAG_ALTA;
            this.Close();
            frmEjecutivo.DefInstance.Show();

            //***** JPU *****

            //    CORMNEJE.Tag = TAG_ALTA
            //    CORMNEJE.Caption = CAPTION_ALTA_EJE
            //    Unload Me
            //    CORMNEJE.Show 1

        }

        private void ID_FIR_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }

        private void CORCOFIR_Load(object sender, EventArgs e)
        {

        }
    }
}