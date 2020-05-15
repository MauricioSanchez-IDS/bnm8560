using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class COREXALT
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Exportaciones masivas de altas y modificaciones     **
        //**                    en archivos ASCII                                   **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        //Constantes para el Emulador a PCRED
        const string STR_EMULA_ALTAS = "MALTA.PIF";
        const string STR_EMULA_CAMBIOS = "MALTA.PIF";
        const string STR_CAPTION_EMULA = "Altas y Cambios Masivos";
        const string STR_MSG_NOEMULA = "El Emulador no fué encontrado";
        const string STR_MSG_NOPATHEMU = "Ruta de Acceso incorrecta al Emulador";
        const string STR_MSG_NOMEMEMU = "No existe memoria suficiente para ejecutar el Emulador";

        //Constante que indica exportación del registro
        const string STR_STATUS = "T";

        //Arreglo para almacenar los campos necesarios a obtener de la tabla de Ejecutivos de la Empresa (MTCEJE01) para exportarlos
        string[] pszMnemoNeces = null;

        //Bandera para controlar la interrupción del proceso de exportación
        int bCanProc = 0;

        //Variable para la conexión a Btrieve
        int hdbcBtr = 0;

        //Variable para la conexión a Sybase
        int hALTConexion = 0;

        //Variable temporal para el Path de los Archivos Btrieve
        string pszTempPath = String.Empty;

        //Variable para almacenar el dia de corte de las Tarjetas
        int iDiaCorte = 0;

        //Variables para almacenar los valores de los campos a exportar
        FixedLengthString szStatus = new FixedLengthString(1);
        FixedLengthString szUser = new FixedLengthString(8);
        FixedLengthString szFolio = new FixedLengthString(8);
        FixedLengthString szPrefBco = new FixedLengthString(6);
        FixedLengthString szSerie = new FixedLengthString(10);
        FixedLengthString szModif = new FixedLengthString(1);
        FixedLengthString szNombre = new FixedLengthString(26);
        FixedLengthString szDirec1 = new FixedLengthString(35);
        FixedLengthString szDirec2 = new FixedLengthString(26);
        FixedLengthString szDirec3 = new FixedLengthString(20);
        FixedLengthString szCodPos = new FixedLengthString(5);
        FixedLengthString szZP = new FixedLengthString(2);
        FixedLengthString szNomAd1 = new FixedLengthString(26);
        FixedLengthString szDigAd1 = new FixedLengthString(2);
        FixedLengthString szNomAd2 = new FixedLengthString(26);
        FixedLengthString szDigAd2 = new FixedLengthString(2);
        FixedLengthString szNomAd3 = new FixedLengthString(26);
        FixedLengthString szDigAd3 = new FixedLengthString(2);
        FixedLengthString szCorte = new FixedLengthString(2);
        FixedLengthString szSucurs = new FixedLengthString(4);
        FixedLengthString szLimite = new FixedLengthString(7);
        FixedLengthString szRegion = new FixedLengthString(2);
        FixedLengthString szTipCta = new FixedLengthString(1);
        FixedLengthString szProc = new FixedLengthString(1);
        FixedLengthString szVencim = new FixedLengthString(4);
        FixedLengthString szActiv = new FixedLengthString(2);
        FixedLengthString szSubact = new FixedLengthString(2);
        FixedLengthString szCP = new FixedLengthString(1);
        FixedLengthString szInsEsp = new FixedLengthString(24);
        FixedLengthString szTeleOf = new FixedLengthString(15);

        //Variables para Obtener de las Tablas Ejecutivos de la Empresa y Empresas los campos a Exportar
        int lFolio = 0;
        int iGpoBanco = 0;
        int iEjePrefijo = 0;
        int lEmpNum = 0;
        int lEjeNum = 0;
        int iEjeRollOver = 0;
        int iEjeDigit = 0;
        FixedLengthString szEjeNomGra = new FixedLengthString(CORBD.LNG_EJE_NOMGRA);
        FixedLengthString szEjeCalle = new FixedLengthString(CORBD.LNG_EJE_CALLE);
        FixedLengthString szEjeCol = new FixedLengthString(CORBD.LNG_EJE_COL);
        FixedLengthString szEjePob = new FixedLengthString(CORBD.LNG_EJE_POB);
        int iZP = 0;
        int lCP = 0;
        FixedLengthString szTelDom = new FixedLengthString(CORBD.LNG_EJE_TDO);
        FixedLengthString szTelOfi = new FixedLengthString(CORBD.LNG_EJE_TOF);
        FixedLengthString szExt = new FixedLengthString(CORBD.LNG_EJE_EXT);
        int lLimCred = 0;
        int iEmpSector = 0;

        //Variables para Obtener de la Tabla de Cambios Masivos los campos a Exportar
        FixedLengthString szCmaCalle = new FixedLengthString(CORBD.LNG_CMA_CALLE);
        FixedLengthString szCmaCol = new FixedLengthString(CORBD.LNG_CMA_COL);
        FixedLengthString szCamPob = new FixedLengthString(CORBD.LNG_CMA_POB);
        int lCamCP = 0;

        private int Actualiza_Folio()
        {

            int result = 0;
            int hStmt = 0;

            result = -1;

            if (lFolio < 9999)
            {
                lFolio++;
            }
            else
            {
                lFolio = 1;
            }

            CORVAR.pszgblsql = "Update " + CORBD.DB_SYB_PGS + " set pgs_folio=" + lFolio.ToString();

            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
                //Ocurrio algun error en la ejecución SQL
                result = 0;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

            return result;
        }

        //UPGRADE_NOTE: (7001) The following declaration (Archivos_Seleccionados) seems to be dead code
        //private int Archivos_Seleccionados()
        //{
        //
        //Contador de Check box
        //
        //for (int iContCKB = 1; iContCKB <= 2; iContCKB++)
        //{ //De uno a ocho por ser ocho los posibles archivos a integrar
        //if (ID_EXP_ARC_OPB[iContCKB].Value)
        //{ //True indica que esta seleccionado el check box //Existe por lo menos un archivo seleccionado
        //return -1;
        //}
        //}
        //
        //return 0; //No existe por lo menos un archivo seleccionado
        //
        //}

        private void Carga_PCRED(int iOperacion)
        {

            string pszExec = String.Empty;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                switch (iOperacion)
                {
                    case 1:  //Altas Masivas 
                        pszExec = CORVAR.pszgblPathMalta + STR_EMULA_ALTAS;
                        break;
                    case 2:  //Cambios Masivos 
                        pszExec = CORVAR.pszgblPathMalta + STR_EMULA_CAMBIOS;
                        break;
                }

                this.Cursor = Cursors.WaitCursor;
                //UPGRADE_WARNING: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo
                ProcessStartInfo startInfo = new ProcessStartInfo(pszExec);
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                int hMalta = Convert.ToInt32(Process.Start(startInfo).Id); //Carga la Emulación correspondiente
                Application.DoEvents();
                this.Cursor = Cursors.Default;
                if (Information.Err().Number != 0)
                {
                    this.Cursor = Cursors.Default;
                    switch (Information.Err().Number)
                    {
                        case 53:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(STR_MSG_NOEMULA + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case 76:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(STR_MSG_NOPATHEMU + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case 7:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(STR_MSG_NOMEMEMU + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        default:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox("Error desconocido al intentar ejecutar MALTA. " + CORSTR.STR_CON_ADMIN + " y vuelva a intentar.", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void Coloca_Datos_Const_Alt()
        {

            szStatus.Value = "0";
            szUser.Value = new String(' ', 8);
            szModif.Value = "N";
            szNomAd1.Value = new String(' ', 26);
            szDigAd1.Value = new String(' ', 2);
            szNomAd2.Value = new String(' ', 26);
            szDigAd2.Value = new String(' ', 2);
            szNomAd3.Value = new String(' ', 26);
            szDigAd3.Value = new String(' ', 2);
            szSucurs.Value = "0137";
            szRegion.Value = "01";
            szTipCta.Value = "1";
            szProc.Value = "E";
            szVencim.Value = StringsHelper.Format(DateTime.Now.Month, "00") + Strings.Mid(StringsHelper.Format(DateTime.Now.Year + 1, "0000"), 3, 2); //Se calcula de la fecha actual mas un año
            szActiv.Value = "02";
            szCP.Value = "5";
            szInsEsp.Value = new String(' ', 24);
            szCorte.Value = StringsHelper.Format(iDiaCorte, "00");

        }

        private void Coloca_Datos_Const_Cam()
        {

            szStatus.Value = "0";
            szUser.Value = new String(' ', 8);
            szModif.Value = "N";
            szNomAd1.Value = new String(' ', 26);
            szDigAd1.Value = new String(' ', 2);
            szNomAd2.Value = new String(' ', 26);
            szDigAd2.Value = new String(' ', 2);
            szNomAd3.Value = new String(' ', 26);
            szDigAd3.Value = new String(' ', 2);
            szSucurs.Value = "0137";
            szRegion.Value = "01";
            szTipCta.Value = "1";
            szProc.Value = "E";
            szVencim.Value = StringsHelper.Format(DateTime.Now.Month, "00") + Strings.Mid(StringsHelper.Format(DateTime.Now.Year + 1, "0000"), 3, 2); //Se calcula de la fecha actual mas un año
            szActiv.Value = "02";
            szCP.Value = "5";
            szInsEsp.Value = new String(' ', 24);
            szCorte.Value = StringsHelper.Format(iDiaCorte, "00");

            //Campos que no se encuntran en la Tabla de Cambios Masivos
            szNombre.Value = new String(' ', CORBD.LNG_EJE_NOMGRA);
            szZP.Value = new String(' ', 2);
            szTelDom.Value = new String(' ', szTelDom.Value.Length);
            szTeleOf.Value = new String(' ', szTeleOf.Value.Length);
            szExt.Value = new String(' ', szTeleOf.Value.Length);
            szLimite.Value = new String(' ', 7);
            szSubact.Value = new String(' ', 2);

        }


        //UPGRADE_NOTE: (7001) The following declaration (Desconexion) seems to be dead code
        //private void  Desconexion()
        //{
        //
        //
        //}

        private void Exp_Altas()
        {

            bCanProc = -1;

            if (Obten_Dia_Corte() != 0)
            {
                if (Verif_Existan_Campos() != 0)
                {
                    if (Realiza_Exportacion_Altas() != 0)
                    {
                        Carga_PCRED(1); //Se envía el número 1 para indicar Alta Masiva
                        bCanProc = 0;
                    }
                }
            }

        }

        //UPGRADE_NOTE: (7001) The following declaration (Exp_Cambios) seems to be dead code
        //private void  Exp_Cambios()
        //{
        //
        //bCanProc = -1;
        //
        //if (Obten_Dia_Corte() != 0)
        //{
        //if (Limpia_Arch_Cambios() != 0)
        //{
        //if (Realiza_Exportacion_Cambios() != 0)
        //{
        //Carga_PCRED(2); //Se envía el número 2 para indicar Cambio Masivo
        //bCanProc = 0;
        //}
        //}
        //}
        //
        //}

        private void COREXALT_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                this.Cursor = Cursors.Default;

            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

            bCanProc = 0; //Inicializamos a false la cancelacion del proceso de integracion


        }

        private void ID_EXP_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {


            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ID_EXP_ARC_OPB[1].Value)
                { //Altas Masivas
                    //Hacemos visible el panel de porcentaje e invisibles los demas controles
                    ID_EXP_PRI_FRM.Visible = false;
                    ID_EXP_ACE_PB.Visible = false;
                    ID_EXP_SAL_PB.Visible = false;
                    ID_EXP_PORC_PNL.Visible = true;
                    ID_EXP_CAN_PB.Visible = true;
                    this.Refresh();

                    ID_EXP_PORC_PNL.FloodPercent = 0; //Inicializamos la barra de Porcentaje del MDI al cero porciento
                    ID_EXP_PORC_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight; //Indicamos que el porcentaje de avance será de izq. a der.
                    ID_EXP_PORC_PNL.FloodPercent = 5; //Inicializamos la Barra de Porcentaje

                    CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = "Realizando la Exportación de Altas Masivas";
                    Application.DoEvents();
                    CORPROC.Delay(1);
                    Exp_Altas();
                }
                else
                {
                    //Cambios Masivos
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existen movimientos para exportar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    this.Close();
                    return;
                }

                Application.DoEvents();
                int A = Application.OpenForms.Count; //Capturamos el evento cancelar
                if (bCanProc != 0)
                {
                    CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = "La Exportación fué Interrumpida. Reintente";
                    CORPROC.Delay(3); //Retardamos el ciclo
                    CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; //Limpiamos el Status Bar
                    this.Close(); //Descargamos la forma
                    return; //Terminamos el procedimiento
                }

                this.Refresh();

                ID_EXP_PORC_PNL.FloodPercent = 100; //Actualizamos la Barra de Porcentaje
                CORPROC.Delay(2);
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING; //Limpiamos el Status Bar
                ID_EXP_PORC_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK); //Cambiamos el color de la letra de blanco a negro

                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                CORVAR.igblErr = (int)Interaction.MsgBox("Exportación realizada con éxito", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);

                //Hacemos visible el panel de porcentaje e invisibles los demas controles
                ID_EXP_PRI_FRM.Visible = true;
                ID_EXP_ACE_PB.Visible = true;
                ID_EXP_SAL_PB.Visible = true;
                ID_EXP_PORC_PNL.Visible = false;
                ID_EXP_CAN_PB.Visible = false;
                this.Refresh();

                this.Close();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_EXP_ACE_PB_Click)", e);
            }

        }

        private void ID_EXP_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            bCanProc = -1;

        }

        private void ID_EXP_SAL_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
            this.Close();

        }

        private int Inserta_Reg_a_Btrieve(int iMovimiento)
        {

            int result = 0;
            int hStmt = 0;
            string pszTabla = String.Empty;

            result = -1;

            switch (iMovimiento)
            {
                case 1:  //Alta Masiva 
                    pszTabla = CORBD.DB_BTR_ALT;
                    break;
                case 2:  //Cambio Masivo 
                    pszTabla = CORBD.DB_BTR_CAM;
                    break;
            }

            szFolio.Value = Numero_de_Folio();

            CORVAR.pszgblsql = "insert into " + CORVAR.pszgblPathBtrieve + pszTabla;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " values (";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szStatus.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szUser.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szFolio.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szPrefBco.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szSerie.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szModif.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szNombre.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szDirec1.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szDirec2.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szDirec3.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szCodPos.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szZP.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szTelDom.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szTeleOf.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szExt.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szNomAd1.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szDigAd1.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szNomAd2.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szDigAd2.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szNomAd3.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szDigAd3.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szCorte.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szSucurs.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szLimite.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szRegion.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szTipCta.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szProc.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szVencim.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szActiv.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szSubact.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szCP.Value + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + szInsEsp.Value + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ")";

            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
                result = 0;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

            return result;
        }

        //UPGRADE_NOTE: (7001) The following declaration (Limpia_Arch_Altas) seems to be dead code
        //private bool Limpia_Arch_Altas()
        //{
        //
        ////UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
        //bool result = false;
        //try
        //{
        //
        //File.Delete(CORVAR.pszgblPathBtrieve + CORBD.DB_BTR_ALT);
        //File.Copy(CORVAR.pszgblPathBtrieve + CORBD.DB_BTR_INI, CORVAR.pszgblPathBtrieve + CORBD.DB_BTR_ALT);
        //
        //result = Information.Err().Number == CORVB.NULL_INTEGER;
        //}
        //catch (Exception exc)
        //{
        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //}
        //
        //return result;
        //}

        private int Limpia_Arch_Cambios()
        {

            int result = 0;
            int hStmt = 0;

            result = 0;

            CORVAR.pszgblsql = "Delete from " + CORVAR.pszgblPathBtrieve + CORBD.DB_BTR_CAM;

            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
                bCanProc = -1;
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                return result;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

            return -1;

        }

        private string Numero_de_Folio()
        {

            string result = String.Empty;
            int hStmt = 0;

            string pszFolio = "01"; //Mesa de Control

            //Enviamos el SQL
            CORVAR.pszgblsql = "select pgs_folio from MTCPGS01";

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    lFolio = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszFolio = pszFolio + StringsHelper.Format(lFolio, "000000");
                }
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                return result; //Salimos de la función
            }


            result = pszFolio;

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

            return result;
        }

        private void Obten_Datos_Var_Alt(int hStmt)
        {

            iGpoBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
            iEjePrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
            lEmpNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
            lEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
            iEjeRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
            iEjeDigit = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
            szEjeNomGra.Value = VBSQL.SqlData(CORVAR.hgblConexion, 7);
            szEjeCalle.Value = VBSQL.SqlData(CORVAR.hgblConexion, 8);
            szEjeCol.Value = VBSQL.SqlData(CORVAR.hgblConexion, 9);
            szEjePob.Value = VBSQL.SqlData(CORVAR.hgblConexion, 10);
            iZP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 11)));
            lCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12)));
            szTelDom.Value = VBSQL.SqlData(CORVAR.hgblConexion, 13);
            szTelOfi.Value = VBSQL.SqlData(CORVAR.hgblConexion, 14);
            szExt.Value = VBSQL.SqlData(CORVAR.hgblConexion, 15);
            lLimCred = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(hStmt, 16)));
            iEmpSector = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(hStmt, 17)));

            szPrefBco.Value = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iGpoBanco, "00");
            //EISSA 03-10-2001. Cambio para formateo de número de empresa y número de ejecutivo.
            szSerie.Value = StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(lEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iEjeRollOver, "0") + StringsHelper.Format(iEjeDigit, "0");

            szNombre.Value = szEjeNomGra.Value.Trim();
            szDirec1.Value = szEjeCalle.Value.Trim();
            szDirec2.Value = szEjeCol.Value.Trim();
            szDirec3.Value = szEjePob.Value.Trim();
            szCodPos.Value = StringsHelper.Format(lCP, "00000");
            szZP.Value = StringsHelper.Format(iZP, "00");
            szTelDom.Value = StringsHelper.Format(szTelDom.Value, "0000000");
            szTeleOf.Value = StringsHelper.Format(szTelOfi.Value, "0000000");
            szExt.Value = StringsHelper.Format(szExt.Value, "0000");
            szLimite.Value = StringsHelper.Format(lLimCred, "0000000");
            szSubact.Value = StringsHelper.Format(iEmpSector, "00");

        }

        private void Obten_Datos_Var_Cam(int hStmt)
        {

            iGpoBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
            iEjePrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
            lEmpNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
            lEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
            iEjeRollOver = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
            iEjeDigit = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
            szCmaCalle.Value = VBSQL.SqlData(CORVAR.hgblConexion, 7);
            szCmaCol.Value = VBSQL.SqlData(CORVAR.hgblConexion, 8);
            szCamPob.Value = VBSQL.SqlData(CORVAR.hgblConexion, 9);
            lCamCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 10)));

            szPrefBco.Value = StringsHelper.Format(iEjePrefijo, "0000") + StringsHelper.Format(iGpoBanco, "00");
            //************Revisar Este código************************************************
            if (lEmpNum < 1000)
            {
                szSerie.Value = Strings.Mid(StringsHelper.Format(lEmpNum, "00000"), StringsHelper.Format(lEmpNum, "00000").Length - 2, 3) + StringsHelper.Format(lEjeNum, "00000") + StringsHelper.Format(iEjeRollOver, "0") + StringsHelper.Format(iEjeDigit, "0");
            }
            else
            {
                szSerie.Value = StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(lEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iEjeRollOver, "0") + StringsHelper.Format(iEjeDigit, "0");
            }
            //************************************************************************
            szDirec1.Value = szCmaCalle.Value.Trim();
            szDirec2.Value = szCmaCol.Value.Trim();
            szDirec3.Value = szCamPob.Value.Trim();
            szCodPos.Value = StringsHelper.Format(lCamCP, "00000");

        }

        private int Obten_Dia_Corte()
        {

            int result = 0;
            int hStmt = 0; //Para la Sentencia SQL


            FixedLengthString szPath = new FixedLengthString(CORBD.LEN_PAR_PATH);


            result = 0; //Inicializamos la función a falso

            //Enviamos el SQL
            //pszgblsql = "Select pgs_dia_corte from " + DB_SYB_PGS se  modifica 19/02/01 YMF
            CORVAR.pszgblsql = "Select pgs_dia_corte from  MTCPGS01 ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE pgs_rep_prefijo =" + CORVAR.igblPref.ToString() + " and pgs_rep_banco =" + CORVAR.igblBanco.ToString();

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                iDiaCorte = CORVB.NULL_INTEGER;

                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    iDiaCorte = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                }
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                bCanProc = -1;
                return result; //Salimos de la función
            }


            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

            return -1;

        }

        private int Realiza_Exportacion_Altas()
        {

            int result = 0;
            int lContInsert = 0;

            int hStmt = 0; //Para la Sentencia SQL

            result = 0; //Inicializamos la función a falso

            CORVAR.pszgblsql = "Select ";
            for (int iContCol = 1; iContCol <= 16; iContCol++)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + CORBD.DB_SYB_EJE + "." + pszMnemoNeces[iContCol] + ",";
            }
            CORVAR.pszgblsql = CORVAR.pszgblsql + CORBD.DB_SYB_EMP + "." + pszMnemoNeces[17];
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYB_EJE + "," + CORBD.DB_SYB_EMP;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " Where " + CORBD.DB_SYB_EJE + ".eje_status='" + STR_STATUS + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " And " + CORBD.DB_SYB_EJE + ".gpo_banco=" + CORBD.DB_SYB_EMP + ".gpo_banco";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " And " + CORBD.DB_SYB_EJE + ".emp_num=" + CORBD.DB_SYB_EMP + ".emp_num";
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = pszgblsql + " And " + DB_SYB_EJE + ".gpo_banco= " + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " And " + CORBD.DB_SYB_EJE + " where eje_prefijo= " + CORVAR.igblPref.ToString() + ".gpo_banco= " + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //Enviamos el SQL
            //ros  igblErr = qeSetSelectOptions(hALTConexion, QE_UP_DOWN_DIR)

            int lNumAltas = CORPROC2.Cuenta_Registros();

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                lContInsert = CORVB.NULL_INTEGER;

                if (lNumAltas != CORVB.NULL_INTEGER)
                {
                    Coloca_Datos_Const_Alt();

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        Obten_Datos_Var_Alt(CORVAR.hgblConexion);
                        if (Inserta_Reg_a_Btrieve(1) != 0)
                        {
                            lContInsert++;
                            ID_EXP_PORC_PNL.FloodPercent = Convert.ToInt16((lContInsert / ((double)(lNumAltas + 1))) * 100); //Actualizamos la Barra de Porcentaje
                            if (ID_EXP_PORC_PNL.FloodPercent >= 49)
                            {
                                ID_EXP_PORC_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE); //Cambiamos el color de la letra de negro a blanco
                                this.Refresh();
                            }
                            if (~Actualiza_Folio() != 0)
                            { //Actualizamos el numero de Folio
                                result = 0;
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                                return result; //Salimos de la función
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            CORVAR.igblErr = (int)Interaction.MsgBox("El Archivo DatosAlt presenta un error para exportar.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                            return result;
                        }
                    };
                    result = -1;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox("No existen Registros a Exportar", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                }
            }
            else
            {
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                return 0; //Salimos de la función
            }


            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

            return result;
        }

        private int Realiza_Exportacion_Cambios()
        {

            int result = 0;
            int iContCol = 0;
            int lContInsert = 0;

            int hStmt = 0; //Para la Sentencia SQL

            result = 0; //Inicializamos la función a falso

            CORVAR.pszgblsql = "Select gpo_banco,eje_prefijo,emp_num,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num,eje_roll_over,eje_digit,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "cma_calle,cma_col,cma_pob,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "cma_cp ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM " + CORBD.DB_SYB_CMA;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = pszgblsql + " WHERE gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO  FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //Enviamos el SQL
            //ros  igblErr = qeSetSelectOptions(hALTConexion, QE_UP_DOWN_DIR)
            int lNumAltas = CORPROC2.Cuenta_Registros();

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                lContInsert = CORVB.NULL_INTEGER;

                if (lNumAltas != CORVB.NULL_INTEGER)
                {
                    Coloca_Datos_Const_Cam();

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        Obten_Datos_Var_Cam(CORVAR.hgblConexion);
                        if (Inserta_Reg_a_Btrieve(2) != 0)
                        {
                            lContInsert++;
                            ID_EXP_PORC_PNL.FloodPercent = Convert.ToInt16((lContInsert / ((double)(lNumAltas + 1))) * 100); //Actualizamos la Barra de Porcentaje
                            if (ID_EXP_PORC_PNL.FloodPercent >= 49)
                            {
                                ID_EXP_PORC_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE); //Cambiamos el color de la letra de negro a blanco
                                this.Refresh();
                            }
                            if (~Actualiza_Folio() != 0)
                            { //Actualizamos el numero de Folio
                                result = 0;
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                                return result; //Salimos de la función
                            }
                        }
                    };
                    result = -1;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox("No existen Registros a Exportar", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                }
            }
            else
            {
                //Ocurrio algun error en la ejecución SQL
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                return 0; //Salimos de la función
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

            return result;
        }

        private int Verif_Existan_Campos()
        {

            int result = 0;
            int hStmt = 0; //Para la Sentencia SQL

            FixedLengthString szMnemo = new FixedLengthString(CORBD.LEN_FMT_MNE);
            int iNumCols = 0;
            string pszMsg = String.Empty;
            int iContBusqueda = 0;
            int bExistCol = 0;
            int iPosCampo = 0;

            result = -1; //Inicializamos la función a falso

            pszMnemoNeces = ArraysHelper.InitializeArray<string>(17);
            pszMnemoNeces[1] = "gpo_banco";
            pszMnemoNeces[2] = "eje_prefijo";
            pszMnemoNeces[3] = "emp_num";
            pszMnemoNeces[4] = "eje_num";
            pszMnemoNeces[5] = "eje_roll_over";
            pszMnemoNeces[6] = "eje_digit";
            pszMnemoNeces[7] = "eje_nom_gra";
            pszMnemoNeces[8] = "eje_calle";
            pszMnemoNeces[9] = "eje_col";
            pszMnemoNeces[10] = "eje_pob";
            pszMnemoNeces[11] = "eje_zp";
            pszMnemoNeces[12] = "eje_cp";
            pszMnemoNeces[13] = "eje_tel_dom";
            pszMnemoNeces[14] = "eje_tel_ofi";
            pszMnemoNeces[15] = "eje_ext";
            pszMnemoNeces[16] = "eje_limcred";
            pszMnemoNeces[17] = "emp_sector";


            //------------------Campos de la tabla de Ejecutivos de la Empresa
            //Enviamos el SQL
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "Select * from " + DB_SYB_EJE + " WHERE gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "Select * from " + CORBD.DB_SYB_EJE + " eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                iNumCols = VBSQL.SqlNumCols(CORVAR.hgblConexion);

                if (iNumCols == CORVB.NULL_INTEGER)
                {
                    pszMsg = CORVB.NULL_STRING;
                    pszMsg = "No existen en la tabla de Ejecutivos de Empresa ";
                    pszMsg = pszMsg + "los campos necesarios para obtener la información a Exportar. ";
                    pszMsg = pszMsg + "Consulte a su Administrador del Sistema";
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                    bCanProc = -1;
                    result = 0;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                    return result;
                }

                iContBusqueda = CORVB.NULL_INTEGER;
                do
                {
                    iContBusqueda++;
                    bExistCol = 0;
                    for (int iContCol = 1; iContCol <= iNumCols; iContCol++)
                    {
                        //ros        igblErr = qeColNameBuf(hStmt, szMnemo, iContCol)
                        szMnemo.Value = VBSQL.SqlData(CORVAR.hgblConexion, iContCol);
                        iPosCampo = CORVB.NULL_INTEGER;
                        iPosCampo = (szMnemo.Value.IndexOf(pszMnemoNeces[iContBusqueda].Trim()) + 1);
                        if (iPosCampo != CORVB.NULL_INTEGER)
                        {
                            bExistCol = -1;
                            break;
                        }
                    }
                }
                while (((~bExistCol) | ((iContBusqueda == 16) ? -1 : 0)) == 0);

                if (~bExistCol != 0)
                {
                    pszMsg = "No existe en la tabla de Ejecutivos de Empresa ";
                    pszMsg = pszMsg + "el campo ''" + pszMnemoNeces[iContBusqueda].Trim() + "'' que es necesario para obtener la información a Exportar. ";
                    pszMsg = pszMsg + "Consulte a su Administrador del Sistema";
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                    result = 0;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                    return result;
                }
            }
            else
            {
                //Ocurrio algun error en la ejecución SQL
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                return 0; //Salimos de la función
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL


            //------------------Campos de la tabla de Empresas
            //Enviamos el SQL
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "Select * from " + DB_SYB_EMP + " WHERE gpo_banco=" + Format$(igblBanco)
            //***** FIN  CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "Select * from " + CORBD.DB_SYB_EMP + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {

                iNumCols = VBSQL.SqlNumCols(CORVAR.hgblConexion);
                if (iNumCols == CORVB.NULL_INTEGER)
                {
                    pszMsg = CORVB.NULL_STRING;
                    pszMsg = "No existen en la tabla de Empresas ";
                    pszMsg = pszMsg + "los campos necesarios para obtener la información a Exportar. ";
                    pszMsg = pszMsg + "Consulte a su Administrador del Sistema";
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                    bCanProc = -1;
                    result = 0;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                    return result;
                }

                bExistCol = 0;
                for (int iContCol = 1; iContCol <= iNumCols; iContCol++)
                {
                    //ros      igblErr = qeColNameBuf(hStmt, szMnemo, iContCol)
                    szMnemo.Value = VBSQL.SqlData(CORVAR.hgblConexion, iContCol);
                    iPosCampo = CORVB.NULL_INTEGER;
                    iPosCampo = (szMnemo.Value.IndexOf(pszMnemoNeces[17].Trim()) + 1);
                    if (iPosCampo != CORVB.NULL_INTEGER)
                    {
                        bExistCol = -1;
                        break;
                    }
                }

                if (~bExistCol != 0)
                {
                    pszMsg = "No existe en la tabla de Ejecutivos de Empresa ";
                    pszMsg = pszMsg + "el campo ''" + pszMnemoNeces[17].Trim() + "'' que es necesario para obtener la información a Exportar. ";
                    pszMsg = pszMsg + "Consulte a su Administrador del Sistema";
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    CORVAR.igblErr = (int)Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                    result = 0;
                }
            }
            else
            {
                //Ocurrio algun error en la ejecución SQL
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL
                return 0; //Salimos de la función
            }


            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion); //Finalizamos la ejecución del SQL

            return result;
        }
        private void COREXALT_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}