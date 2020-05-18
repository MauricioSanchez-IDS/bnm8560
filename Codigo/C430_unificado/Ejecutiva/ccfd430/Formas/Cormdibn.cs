using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using SAPUFENLACELib;

//Pueba GitHub Mau
namespace TCd430
{
    internal partial class CORMDIBN
        : System.Windows.Forms.Form
    {

        private void CORMDIBN_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Forma MDI que hace la interface del sistema         **
        //**                    Contiene controles globales, menues, barras de      **
        //**                    barras de estado,
        //**                                                                        **
        //**       Responsable: Felipe Zacarias Jimenez                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int hReporteador = 0; //Handle al Reporteador
        bool blbandera = false;


        //Constantes para el Emulador
        const string STR_CAPTION_EMULA = "Captura de Aclaraciones";
        const string STR_CAPTION_CYDD = "Transferencia de Archivos";
        const string STR_MSG_NOEMULA = "El Emulador no fué encontrado";
        const string STR_MSG_NOCYDD = "El programa de transferencias CYDD no fué encontrado";
        const string STR_MSG_NOPATHEMU = "La Ruta de Acceso es incorrecta";
        const string STR_MSG_NOMEMEMU = "No existe memoria suficiente para ejecutar el programa";

        //Constantes para el reporteador
        const string STR_MSG_NOREP = "El Reporteador no fué encontrado";
        const string STR_MSG_NOPATHREP = "Ruta de Acceso incorrecta al Reporteador";
        const string STR_MSG_NOMEMREP = "No existe memoria suficiente para ejecutar el Reporteador";
        const string STR_CAPTION_REP = "Reporteador CORPORATIVA";

        //AIS-1178 NGONZALEZ
        CORVAR.tyFormatos[] pszarrFormatos;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;
        
        private void Actualiza_Bitacora()
        {

            int iAccesos = 0;
            int hBitacoraLec = 0;
            int hBitacoraEsc = 0;
            string pszSQL = String.Empty;

            //ros  hgblConexion = qeConnect(pszgblConexion)

            for (int iCont = CORVAR.iArrBitacora.GetLowerBound(0); iCont <= CORVAR.iArrBitacora.GetUpperBound(0); iCont++)
            {
                iAccesos = CORVB.NULL_INTEGER;
                if (CORVAR.iArrBitacora[iCont, 1] > CORVB.NULL_INTEGER)
                {

                    //Lee los accesos ya almacenados
                    CORVAR.pszgblsql = "SELECT bit_accesos FROM " + CORBD.DB_SYB_BIT + " WHERE bit_grupo = " + CORVAR.iArrBitacora[iCont, 0].ToString() + " AND bit_forma = '" + CORVAR.pszArrBitForma[iCont, 0] + "'";

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            iAccesos = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                            //Actualiza la bitacora
                            CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_BIT + " SET bit_accesos = " + (CORVAR.iArrBitacora[iCont, 1] + iAccesos).ToString() + " WHERE bit_grupo = " + CORVAR.iArrBitacora[iCont, 0].ToString() + " AND bit_forma = '" + CORVAR.pszArrBitForma[iCont, 0] + "'";
                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                            }
                            else
                            {
                                MessageBox.Show("No se modifico la bitácora", Application.ProductName);
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                        else
                        {
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                            //Graba un nuevo registro
                            CORVAR.pszgblsql = "INSERT INTO " + CORBD.DB_SYB_BIT + " (bit_grupo,bit_forma,bit_desc,bit_accesos) VALUES (" + CORVAR.iArrBitacora[iCont, 0].ToString() + ",'" + CORVAR.pszArrBitForma[iCont, 0] + "','" + CORVAR.pszArrBitForma[iCont, 1] + "'," + (CORVAR.iArrBitacora[iCont, 1] + iAccesos).ToString() + ")";
                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                            }
                            else
                            {
                                MessageBox.Show("No se inserto la bitacora ", Application.ProductName);
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    }
                    else
                    {
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        break;
                    }
                }
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        public void Guarda_Fmt(Softtek.Util.Win.Spread.SpreadWrapper sprDatos)
        {

            StringBuilder pszCadena = new StringBuilder();
            pszCadena.Append(String.Empty);
            string pszCadTem = String.Empty;

            //----------------------------------------------------------------------------------------
            //Define los formatos para numéricos, con o sin decimales y alfanuméricos
            for (int iCont = 1; iCont <= pszarrFormatos.GetUpperBound(0); iCont++)
            {

                //Si contiene numericos...
                if (pszarrFormatos[iCont].pszDecimal != CORVB.NULL_STRING)
                {

                    //Si hay decimales...
                    if (Conversion.Val(pszarrFormatos[iCont].pszDecimal) > CORVB.NULL_INTEGER)
                    {

                        //Formatea con decimales
                        pszarrFormatos[iCont].pszFormato = new string('0', Int32.Parse(pszarrFormatos[iCont].pszLong)) + "." + new string('0', Int32.Parse(pszarrFormatos[iCont].pszDecimal));

                    }
                    else
                    {

                        //Formatea sin decimales
                        pszarrFormatos[iCont].pszFormato = new string('0', Int32.Parse(pszarrFormatos[iCont].pszLong));

                    }

                }
                else
                {

                    //Formatea String
                    pszarrFormatos[iCont].pszFormato = new string(new String(' ', 1)[0], Int32.Parse(pszarrFormatos[iCont].pszLong));

                }

            }

            //----------------------------------------------------------------------------------------
            //Por cada renglón de Datos
            for (int iContRow = 1; iContRow <= sprDatos.MaxRows; iContRow++)
            {

                //Inicializa la cadena a grabar
                pszCadena = new StringBuilder(CORVB.NULL_STRING);

                //Por cada renglón de datos
                for (int iContCol = 1; iContCol <= sprDatos.MaxCols; iContCol++)
                {

                    //Posiciona la columna
                    sprDatos.Col = iContCol;

                    //Inicializa el Spread al Primer renglón de Títulos
                    sprDatos.Row = CORVB.NULL_INTEGER;

                    for (int iCont = 1; iCont <= pszarrFormatos.GetUpperBound(0); iCont++)
                    {

                        //Si el campo existe en el Spread de Datos...
                        if (sprDatos.Text == pszarrFormatos[iCont].pszCampo)
                        {

                            //Posiciona el renglón a grabar
                            sprDatos.Row = iContRow;

                            //Si es un registro de datos y con datos
                            if (ColorTranslator.ToOle(sprDatos.BackColor) == CORVB.WHITE)
                            {

                                //Si formatea cadenas...
                                if (pszarrFormatos[iCont].pszFormato.Trim() == CORVB.NULL_STRING)
                                {

                                    //Arma la cadena de campos
                                    pszCadTem = sprDatos.Text.Trim() + new String(' ', pszarrFormatos[iCont].pszFormato.Length);
                                    pszCadena.Append(Strings.Mid(pszCadTem, 1, pszarrFormatos[iCont].pszFormato.Length));

                                }
                                else
                                {

                                    //Si es negativo...
                                    if (Conversion.Val(sprDatos.Text.Trim()) < CORVB.NULL_INTEGER)
                                    {
                                        //Le quita un cero del formato y le pone un -
                                        pszCadena.Append(StringsHelper.Format(sprDatos.Text.Trim(), Strings.Mid(pszarrFormatos[iCont].pszFormato, 2, pszarrFormatos[iCont].pszFormato.Length)));
                                    }
                                    else
                                    {
                                        //Es positivo, formatea normal
                                        pszCadena.Append(StringsHelper.Format(sprDatos.Text.Trim(), pszarrFormatos[iCont].pszFormato));
                                    }

                                }

                            }

                            break;

                        }

                    }

                }

                //Guarda la cadena en el archivo
                FileSystem.PrintLine(1, pszCadena.ToString());

            }

        }

        public void Obten_Formatos(string pszTipoRep, Softtek.Util.Win.Spread.SpreadWrapper sprDatos)
        {

            string pszCampo = String.Empty;
            string pszLong = String.Empty;
            string pszLongTmp = String.Empty;
            string pszCadena = String.Empty;

            //Obtiene el número de campos del Reporte

            int iNumCampos = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\" +pszTipoRep, "NoCampos").Trim());
            //int iNumCampos = Convert.ToInt32(Conversion.Val(CORPROC2.Obten_Dato_Ini(pszTipoRep, "NoCampos")));
            //int iNumCampos = 14;

            //Inicializa el Spread al Primer renglón de Títulos
            sprDatos.Row = CORVB.NULL_INTEGER;
            string pszDecimal = CORVB.NULL_STRING;

            //Inicializa los Formatos
            //UPGRADE_WARNING: (1042) Array pszarrFormatos may need to have individual elements initialized.
            pszarrFormatos = ArraysHelper.RedimPreserve<CORVAR.tyFormatos[]>(pszarrFormatos, new int[] { CORVB.NULL_INTEGER + 1 });

            //Obtiene los campos a exportar
            for (int iCont = 1; iCont <= iNumCampos; iCont++)
            {

                //Obtiene la cadena del Campo del Archivo Ini
                //pszCadena = CORPROC2.Obten_Dato_Ini(pszTipoRep, "Campo" + iCont.ToString()).Trim();
                pszCadena = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\" + pszTipoRep, "Campo"+ iCont.ToString()).Trim();
                //pszCadena = "No.,30";

                //Separa el Campo y la Longitud
                pszCampo = Strings.Mid(pszCadena, 1, pszCadena.IndexOf(',')).Trim();
                pszLong = Strings.Mid(pszCadena, (pszCadena.IndexOf(',') + 1) + 1).Trim();
                pszDecimal = CORVB.NULL_STRING;

                //Si se requiere exportar decimales...
                if ((pszLong.IndexOf('.') + 1) > CORVB.NULL_INTEGER)
                {
                    pszLongTmp = pszLong;
                    //Se obtienen los enteros
                    pszLong = Strings.Mid(pszLongTmp, 1, pszLongTmp.IndexOf('.')).Trim();
                    //Se obtienen los decimales
                    pszDecimal = Strings.Mid(pszLongTmp, (pszLongTmp.IndexOf('.') + 1) + 1).Trim();
                }

                //Busca en el Spread de Datos el Campo
                for (int iContSS = 1; iContSS <= sprDatos.MaxCols; iContSS++)
                {

                    //Posiciona la Columna del Spread de Datos
                    sprDatos.Col = iContSS;

                    //Si el campo existe en el Spread de Datos...
                    if (sprDatos.Text == pszCampo)
                    {

                        //Guarda las posiciones de los campos
                        //UPGRADE_WARNING: (1042) Array pszarrFormatos may need to have individual elements initialized.
                        pszarrFormatos = ArraysHelper.RedimPreserve<CORVAR.tyFormatos[]>(pszarrFormatos, new int[] { pszarrFormatos.GetUpperBound(0) + 2 });
                        pszarrFormatos[pszarrFormatos.GetUpperBound(0)].pszCampo = pszCampo;
                        pszarrFormatos[pszarrFormatos.GetUpperBound(0)].pszLong = pszLong;
                        pszarrFormatos[pszarrFormatos.GetUpperBound(0)].pszDecimal = pszDecimal;

                        //Se sale de la búsqueda en el Spread
                        break;

                    }

                }

            }

        }

        private void Get_Help(byte HelpTopic)
        {

            //igblErr = WinHelp(CORMDIBN.hWnd, pszgblPathRep + "AYUDA.HLP", 3, CLng(HelpTopic))
            //AIS-1182 NGONZALEZ	
            if (File.Exists("Tarjeta Corporativa.HLP") == true)
            {
                CORVAR.igblErr = API.USER.WinHelp(CORMDIBN.DefInstance.Handle.ToInt32(), "Tarjeta Corporativa.HLP", 3, HelpTopic);
            }
            else
            {
                MessageBox.Show("No se puede hallar el archivo de Ayuda Tarjeta Corporativa.HLP.Compruebe si existe en su disco; de lo contrario necesitara instalarlo en nuevo", "Ayuda de Windows", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //UPGRADE_NOTE: (7001) The following declaration (capestado_Change) seems to be dead code
        //private void  capestado_Change()
        //{
        //tamir  If (capestado = True) Then
        //tamir    txtEstado.Caption = "May."
        //tamir  Else
        //tamir    txtEstado.Caption = "Min."
        //tamir  End If
        //}

        //UPGRADE_NOTE: (7001) The following declaration (capNumero_Change) seems to be dead code
        //private void  capNumero_Change()
        //{
        //tamir If (capNumero = True) Then
        //tamir    lblNumero.Caption = "Num."
        //tamir  Else
        //tamir    lblNumero.Caption = "Char."
        //tamir  End If
        //}


        //UPGRADE_NOTE: (7001) The following declaration (ID_SEG_ACC_SQL_Error) seems to be dead code
        //private void  ID_SEG_ACC_SQL_Error( int SqlConn,  int Severity,  int ErrorNum,  string ErrorStr,  int OSErrorNum,  string OSErrorStr,  int RetCode)
        //{
        //
        //Select Case ErrorNum
        //  Case Is <> NULL_INTEGER
        //    MsgBox ErrorNum & " " & ErrorNum, MB_OK + MB_ICONINFORMATION, STR_APP_TIT
        //End Select
        //MessageBox.Show(" SEVERIDAD ERROR: " + Severity.ToString() + " NUMERO: " + ErrorNum.ToString() + "-" + ErrorStr, Application.ProductName);
        //}

        //UPGRADE_NOTE: (7001) The following declaration (ID_SEG_ACC_SQL_Message) seems to be dead code
        //private void  ID_SEG_ACC_SQL_Message( int SqlConn,  int Message,  int State,  int Severity,  string MsgStr,  string ServerNameStr,  string ProcNameStr,  int Line)
        //{
        //
        //Select Case Message
        //
        //  Case 5701
        //  Case Is <> NULL_INTEGER
        //    MsgBox Message & " " & State & " " & MsgStr, MB_OK + MB_ICONINFORMATION, STR_APP_TIT
        //
        //End Select
        //switch(Message)
        //{
        //
        //case 5701 : 
        //break;
        //default:
        //MessageBox.Show(" MENSAJE: " + Message.ToString() + " ESTADO: " + State.ToString() + " SEVERIDAD: " + Severity.ToString() + "-" + ServerNameStr + "-" + ProcNameStr + " LINEA: " + Line.ToString() + "-" + MsgStr, Application.ProductName); 
        // 
        //break;
        //}
        //
        //}


        public void IDM_ACE_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORACERC.DefInstance.ShowDialog();
            //  frmAcerca.Show 1

        }



        public void IDM_ACL_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_ACL;

        }

        public void IDM_AFI_Click(Object eventSender, EventArgs eventArgs)
        {

            //this.Cursor = Cursors.WaitCursor; //AIS-1211 echasiquiza

            //CORVAR.igblNivelActivo = CORCONST.NIV_AFI;
            //CORVAR.iArrBitacora[CORCONST.NIV_AFI, 0] = CORCONST.BIT_CONSULTA;
            //CORVAR.iArrBitacora[CORCONST.NIV_AFI, 1]++;
            //CORVAR.pszArrBitForma[CORCONST.NIV_AFI, 0] = "CORRPEMA";
            //CORVAR.pszArrBitForma[CORCONST.NIV_AFI, 1] = "Detalle de Empresas Afiliadas";
            //CORRPEMA.DefInstance.Show();

        }

        public void IDM_ANA_Click(Object eventSender, EventArgs eventArgs)
        {

            //this.Cursor = Cursors.WaitCursor; //AIS-1211 echasiquiza

            CORVAR.igblNivelActivo = CORCONST.NIV_ANA;
            CORVAR.iArrBitacora[CORCONST.NIV_ANA, 0] = CORCONST.BIT_CONSULTA;
            CORVAR.iArrBitacora[CORCONST.NIV_ANA, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_ANA, 0] = "CORRANG2";
            CORVAR.pszArrBitForma[CORCONST.NIV_ANA, 1] = "Análisis de Consumos por Giro";
            CORRANG2.DefInstance.Show();

        }

        public void IDM_ATR_Click(Object eventSender, EventArgs eventArgs)
        {

            //this.Cursor = Cursors.WaitCursor; AIS-1211 echasiquiza

            CORVAR.igblNivelActivo = CORCONST.NIV_ATR;
            CORVAR.iArrBitacora[CORCONST.NIV_ATR, 0] = CORCONST.BIT_CONSULTA;
            CORVAR.iArrBitacora[CORCONST.NIV_ATR, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_ATR, 0] = "CORRPDA1";
            CORVAR.pszArrBitForma[CORCONST.NIV_ATR, 1] = "Detalle de Atrasos por Ejecutivo";
            CORRPDA1.DefInstance.Show();

        }



        public void IDM_AVE_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_AVE;
            CORVAR.iArrBitacora[CORCONST.NIV_AVE, 0] = CORCONST.BIT_ACLARACIONES;
            CORVAR.iArrBitacora[CORCONST.NIV_AVE, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_AVE, 0] = "CORRPACL";
            CORVAR.pszArrBitForma[CORCONST.NIV_AVE, 1] = "Aclararaciones Vencidas";
            CORRPACL.DefInstance.Show();

        }

        public void IDM_BAN_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_BAN;
            CORVAR.iArrBitacora[CORCONST.NIV_BAN, 0] = CORCONST.BIT_ARCHIVOS;
            CORVAR.iArrBitacora[CORCONST.NIV_BAN, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_BAN, 0] = "CORCTEJB";
            CORVAR.pszArrBitForma[CORCONST.NIV_BAN, 1] = "Catálogo de Ejecutivos Banamex";
            CORCTEJB.DefInstance.Show();
            this.Cursor = Cursors.Default;

        }

        public void IDM_BAS_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //igblErr = WinHelp(CORMDIBN.hWnd, pszgblPathCorpo + "Ayuda.hlp", 261, 0)
            //AIS-1182 NGONZALEZ
            if (File.Exists("Tarjeta Corporativa.HLP") == true)
            {
                CORVAR.igblErr = API.USER.WinHelp(CORMDIBN.DefInstance.Handle.ToInt32(), "Tarjeta Corporativa.HLP", 261, 0);
            }
            else
            {
                MessageBox.Show("No se puede hallar el archivo de Ayuda Tarjeta Corporativa.HLP.Compruebe si existe en su disco; de lo contrario necesitara instalarlo en nuevo", "Ayuda de Windows", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;

        }

        public void IDM_BCO_Click(Object eventSender, EventArgs eventArgs)
        {
            //AIS-1211 NGONZALEZ
            //this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_BCO;
            CORVAR.iArrBitacora[CORCONST.NIV_BCO, 0] = CORCONST.BIT_CONFIGURAR;
            CORVAR.iArrBitacora[CORCONST.NIV_BCO, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_BCO, 0] = "CORSGBAN";
            CORVAR.pszArrBitForma[CORCONST.NIV_BCO, 1] = "Banco de Operación";
            CORSGBAN.DefInstance.Show();

        }



        public void IDM_BNX_Click(Object eventSender, EventArgs eventArgs)
        {

            CORCTBNX.DefInstance.Show();
            if (CORCTBNX.DefInstance.flag)
                CORCTBNX.DefInstance.Close();

        }

        public void IDM_CAMM_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORCAMA.DefInstance.ShowDialog();

            this.Cursor = Cursors.Default;

        }

        static double hMulterm_IDM_CAP_Click = 0;
        public void IDM_CAP_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_CAP;
            CORVAR.iArrBitacora[CORCONST.NIV_CAP, 0] = CORCONST.BIT_ACLARACIONES;
            CORVAR.iArrBitacora[CORCONST.NIV_CAP, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_CAP, 0] = "COREMULA";
            CORVAR.pszArrBitForma[CORCONST.NIV_CAP, 1] = "Captura de Aclaraciones";
            //Handle al Emulador
            Information.Err().Number = CORCONST.OK;

            //Valida si existe el archivo .pif del Emulador
            if (FileSystem.Dir(CORVAR.pszgblPathCorpo + "MULTERM\\emula.pif", FileAttribute.Normal) == CORVB.NULL_STRING)
            {
                //No existe el archivo .pif
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(STR_MSG_NOEMULA + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_MSG_SOLUCION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                this.Cursor = Cursors.Default;
                return;
            }


            if (CORPROC.ModuloEnUso("Captura de Aclaraciones") != 0)
            { //Checa si ya existe
                this.Cursor = Cursors.Default;
                Interaction.AppActivate("Captura de Aclaraciones");
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                //UPGRADE_WARNING: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo
                ProcessStartInfo startInfo = new ProcessStartInfo(CORVAR.pszgblPathCorpo, "MULTERM\\emula.pif");
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                hMulterm_IDM_CAP_Click = Process.Start(startInfo).Id; //Ejecuta
                Application.DoEvents();
                this.Cursor = Cursors.Default;
                if (Information.Err().Number != 0)
                {
                    switch (Information.Err().Number)
                    {
                        case 53:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(STR_MSG_NOEMULA + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_MSG_SOLUCION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case 76:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(STR_MSG_NOPATHEMU + Strings.Chr(CORVB.KEY_RETURN).ToString() + CORSTR.STR_MSG_SOLUCION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case 7:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(STR_MSG_NOMEMEMU, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                    }
                }
            }

            this.Cursor = Cursors.Default;

        }

        public void IDM_CAT_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_CAT;

        }

        public void IDM_CCI_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            MTCBRCCI.DefInstance.Show();
        }

        //public void IDM_CDF_Click(Object eventSender, EventArgs eventArgs)
        //{
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
        //    CORMECDF.DefInstance.ShowDialog();
        //}

        public void IDM_CEJ_Click(Object eventSender, EventArgs eventArgs)
        {

            //this.Cursor = Cursors.WaitCursor; //AIS-1211 echasiquiza

            CORVAR.igblNivelActivo = CORCONST.NIV_CEJ;
            CORVAR.iArrBitacora[CORCONST.NIV_CEJ, 0] = CORCONST.BIT_CONSULTA;
            CORVAR.iArrBitacora[CORCONST.NIV_CEJ, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_CEJ, 0] = "CORRPCE2";
            CORVAR.pszArrBitForma[CORCONST.NIV_CEJ, 1] = "Concentrado Empresa/Ejecutivo";
            CORRPCE2.DefInstance.Show();

        }

        public void IDM_CEM_Click(Object eventSender, EventArgs eventArgs)
        {

            //this.Cursor = Cursors.WaitCursor; //AIS-1211 echasiquiza

            CORVAR.igblNivelActivo = CORCONST.NIV_CEM;
            CORVAR.iArrBitacora[CORCONST.NIV_CEM, 0] = CORCONST.BIT_CONSULTA;
            CORVAR.iArrBitacora[CORCONST.NIV_CEM, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_CEM, 0] = "CORRPGR2";
            CORVAR.pszArrBitForma[CORCONST.NIV_CEM, 1] = "Concentrado Grupo/Empresas";
            CORRPGR2.DefInstance.Show();

        }

        public void IDM_CFG_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.Default;

            CORVAR.igblNivelActivo = CORCONST.NIV_CFG;
            ID_COR_CMD.Action = 5;

        }

        public void IDM_CON_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_CON;

        }

        public void IDM_COR_Click(Object eventSender, EventArgs eventArgs)
        {
            //AIS-1211 NGONZALEZ
            //this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_COR;
            CORVAR.iArrBitacora[CORCONST.NIV_COR, 0] = CORCONST.BIT_ARCHIVOS;
            CORVAR.iArrBitacora[CORCONST.NIV_COR, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_COR, 0] = "CORCTGRU";
            CORVAR.pszArrBitForma[CORCONST.NIV_COR, 1] = "Catálogo de Grupos";
            CORCTGRU.DefInstance.Show();
            if (CORCTGRU.DefInstance.flag)
                CORCTGRU.DefInstance.Close();

        }

        public void IDM_CTA_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_CTA;

        }



        public void IDM_DEJ_Click(Object eventSender, EventArgs eventArgs)
        {

            //this.Cursor = Cursors.WaitCursor; //AIS-1211 echasiquiza

            CORVAR.igblNivelActivo = CORCONST.NIV_DEJ;
            CORVAR.iArrBitacora[CORCONST.NIV_DEJ, 0] = CORCONST.BIT_CONSULTA;
            CORVAR.iArrBitacora[CORCONST.NIV_DEJ, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_DEJ, 0] = "CORRPDE1";
            CORVAR.pszArrBitForma[CORCONST.NIV_DEJ, 1] = "Detalle de Ejecutivo Banamex";
            CORRPDE1.DefInstance.Show();

        }

        public void IDM_DEP_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_DEP;
            CORVAR.iArrBitacora[CORCONST.NIV_DEP, 0] = CORCONST.BIT_INTERFASES;
            CORVAR.iArrBitacora[CORCONST.NIV_DEP, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_DEP, 0] = "CORDEPUR";
            CORVAR.pszArrBitForma[CORCONST.NIV_DEP, 1] = "Depuración de Procesos";
            CORDEPUR.DefInstance.Show();

        }

        public void IDM_DET_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_DET;

        }


        public void IDM_DIV_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            CORVAR.igblNivelActivo = CORCONST.NIV_DIV;
            CORVAR.iArrBitacora[CORCONST.NIV_DIV, 0] = CORCONST.BIT_ARCHIVOS;
            CORVAR.iArrBitacora[CORCONST.NIV_DIV, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_DIV, 0] = "CORCTDIV";
            CORVAR.pszArrBitForma[CORCONST.NIV_DIV, 1] = "Catálogo de Divisiones";
            CORCTDIV.DefInstance.Show();

            this.Cursor = Cursors.Default;

        }

        public void IDM_EER_Click(Object eventSender, EventArgs eventArgs)
        {
            frmIntBusqueda.DefInstance.Show();
        }

        public void IDM_EJE_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            CORVAR.igblNivelActivo = CORCONST.NIV_EJE;
            CORVAR.iArrBitacora[CORCONST.NIV_EJE, 0] = CORCONST.BIT_ARCHIVOS;
            CORVAR.iArrBitacora[CORCONST.NIV_EJE, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_EJE, 0] = "CORCTEJE";
            CORVAR.pszArrBitForma[CORCONST.NIV_EJE, 1] = "Catálogo de Tarjetahabientes";
            CORVAR.glstrLimCred = "empresa";
            CORCTEJE.DefInstance.Show();
            this.Cursor = Cursors.Default;
        }

        public void IDM_EMP_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            CORVAR.igblNivelActivo = CORCONST.NIV_EMP;
            CORVAR.iArrBitacora[CORCONST.NIV_EMP, 0] = CORCONST.BIT_ARCHIVOS;
            CORVAR.iArrBitacora[CORCONST.NIV_EMP, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_EMP, 0] = "CORCTEMP";
            CORVAR.pszArrBitForma[CORCONST.NIV_EMP, 1] = "Catálogo de Empresas";
            CORCTEMP.DefInstance.Show();
            if (CORCTEMP.DefInstance.flag)
                CORCTEMP.DefInstance.Close();
            this.Cursor = Cursors.Default;
        }

        public void IDM_ENV_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                frmIntInicio.DefInstance.Show();
            }
            catch
            {
            }
        }

        //Se quito el menu Actualizacion de Envios con nombre IDM_ENV
        //Private Sub IDM_ENV_Click()
        //  Screen.MousePointer = HOURGLASS
        //  igblNivelActivo = NIV_ENV
        //  iArrBitacora(NIV_ENV, 0) = BIT_INTERFASES
        //  iArrBitacora(NIV_ENV, 1) = iArrBitacora(NIV_ENV, 1) + 1
        //  pszArrBitForma(NIV_ENV, 0) = "CORACENV"
        //  pszArrBitForma(NIV_ENV, 1) = "Actualización de Envíos"
        //  CORACENV.Show
        //End Sub

        public void IDM_ESP_Click(Object eventSender, EventArgs eventArgs)
        {
            CORVAR.igblNivelActivo = CORCONST.NIV_ESP;
        }

        public void IDM_EXC_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_EXC;
            //  iArrBitacora(NIV_EXC, 0) = BIT_OPCIONES
            //  iArrBitacora(NIV_EXC, 1) = iArrBitacora(NIV_EXC, 1) + 1
            //  pszArrBitForma(NIV_EXC, 0) = "COREXPEX"
            //  pszArrBitForma(NIV_EXC, 1) = "Exportación a EXCEL"
            CORPROC.Exporta_Excel();

        }

        public void IDM_FMT_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_FMT;
            //  iArrBitacora(NIV_FMT, 0) = BIT_OPCIONES
            //  iArrBitacora(NIV_FMT, 1) = iArrBitacora(NIV_TXT, 1) + 1
            //  pszArrBitForma(NIV_FMT, 0) = "COREXPFM"
            //  pszArrBitForma(NIV_FMT, 1) = "Exportación a Formato Fijo"

            Guarda_Formato();

            this.Cursor = Cursors.Default;

        }
        public void Guarda_Formato()
        {


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                if (CORVAR.igblFormaActiva == CORCONST.INT_ACT_CEJ || CORVAR.igblFormaActiva == CORCONST.INT_ACT_CGR || CORVAR.igblFormaActiva == CORCONST.INT_ACT_ANG || CORVAR.igblFormaActiva == CORCONST.INT_ACT_DAT || CORVAR.igblFormaActiva == CORCONST.INT_ACT_DEJ || CORVAR.igblFormaActiva == CORCONST.INT_ACT_EMA)
                {
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existe un reporte para exportar a Formato Fijo.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return;
                }

                //los comentarios de ros son realializados para guardar el nombre en un archivo fijo
                //ros  CORMDIBN!ID_COR_CMD.Flags = OFN_HIDEREADONLY Or OFN_OVERWRITEPROMPT Or OFN_SHOWHELP
                //ros      CORMDIBN!ID_COR_CMD.CancelError = True
                //ros      CORMDIBN!ID_COR_CMD.Filter = "Texto (*.txt)|*.txt"
                //ros      CORMDIBN!ID_COR_CMD.FilterIndex = 0
                //ros      CORMDIBN!ID_COR_CMD.DialogTitle = STR_MSG_EXP
                //ros      CORMDIBN!ID_COR_CMD.DefaultExt = "txt"
                //ros      CORMDIBN!ID_COR_CMD.Filename = NULL_STRING
                //ros      CORMDIBN!ID_COR_CMD.InitDir = pszgblPath

                //ros  Screen.MousePointer = DEFAULT

                //ros      CORMDIBN!ID_COR_CMD.Action = DLG_FILE_SAVE

                //ros      If Err = CDERR_CANCEL Then
                //ros        Screen.MousePointer = DEFAULT
                //ros        Exit Sub
                //ros       End If

                this.Cursor = Cursors.WaitCursor;

                //ros      CORMDIBN!ID_COR_CMD.Action = NONE
                //ros      CORMDIBN!ID_COR_CMD.CancelError = False

                //ros      pszNombreCompleto = CORMDIBN!ID_COR_CMD.Filename

                //asigna el nombre armado del archivo
                string pszNombreCompleto = CORVAR.gblPathArchivo + ".FFT";

                Information.Err().Number = CORCONST.OK;
                FileSystem.FileOpen(1, pszNombreCompleto, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);

                if (Information.Err().Number != CORCONST.OK)
                {
                    this.Cursor = Cursors.Default;
                    switch (Information.Err().Number)
                    {
                        case CORCTERR.INT_DISCO_LLENO:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(CORSTR.STR_DISCO_LLENO, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case CORCTERR.INT_PERMISO_NEG:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(CORSTR.STR_PERMISO_NEG, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case CORCTERR.INT_UNIDAD_NOLIS:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(CORSTR.STR_UNIDAD_NOLIS, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case CORCTERR.INT_ERR_ACCPATHFILE:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(CORSTR.STR_ERR_ACCPATHFILE, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case CORCONST.INT_NO_PATH:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(CORSTR.STR_NO_PATH, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        case CORCONST.INT_NO_MEMORIA:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(CORSTR.STR_NO_MEMORIA, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                        default:
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox(CORSTR.ERR_ERROR_DESC, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            break;
                    }
                    return;
                }

                //Se establece el status bar
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short)CORVB.NULL_INTEGER;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;

                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = CORSTR.STR_EXPORTANDO_TXT;
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;

                this.Cursor = Cursors.WaitCursor;

                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight; //Se establece el status bar
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short)CORVB.NULL_INTEGER;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK);
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = CORSTR.STR_EXPORTANDO_TXT;
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;

                //UPGRADE_WARNING: (1042) Array pszarrFormatos may need to have individual elements initialized.
                pszarrFormatos = new CORVAR.tyFormatos[CORVB.NULL_INTEGER + 1];

                switch (CORVAR.igblFormaActiva)
                {
                    case CORCONST.INT_ACT_CEJ:
                        Obten_Formatos("ConcentradoEmpresa", CORRPCEJ.DefInstance.ID_CEJ_REP_SS);
                        Guarda_Fmt(CORRPCEJ.DefInstance.ID_CEJ_REP_SS);
                        break;
                    case CORCONST.INT_ACT_CGR:
                        Obten_Formatos("ConcentradoGrupo", CORRPCGR.DefInstance.ID_CGR_REP_SS);
                        Guarda_Fmt(CORRPCGR.DefInstance.ID_CGR_REP_SS);
                        break;
                    case CORCONST.INT_ACT_ANG:
                        Obten_Formatos("ConsumosPorGiro", CORRPANG.DefInstance.ID_GIR_CON_SS);
                        Guarda_Fmt(CORRPANG.DefInstance.ID_GIR_CON_SS);
                        break;
                    case CORCONST.INT_ACT_DAT:
                        Obten_Formatos("DetalleAtrasos", CORRPDAT.DefInstance.ID_CEJ_REP_SS);
                        Guarda_Fmt(CORRPDAT.DefInstance.ID_CEJ_REP_SS);
                        break;
                    case CORCONST.INT_ACT_DEJ:
                        Obten_Formatos("DetalleEjecutivos", CORRPDEJ.DefInstance.ID_CEJ_REP_SS);
                        Guarda_Fmt(CORRPDEJ.DefInstance.ID_CEJ_REP_SS);
                        break;
                    case CORCONST.INT_ACT_EMA:
                        Obten_Formatos("EmpresasAfiliadas", CORRPEM2.DefInstance.ID_EMA_REP_SS);
                        Guarda_Fmt(CORRPEM2.DefInstance.ID_EMA_REP_SS);
                        break;
                }

                //Cerramos el Archivo
                FileSystem.FileClose(1);

                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_EXP_EXITO, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);


                //Regresamos el status bar
                this.Cursor = Cursors.WaitCursor;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = false;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = CORVB.NONE;

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        public void IDM_FTP_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            //FrmFtp.Show
            MessageBox.Show("PARA RECUPERAR LOS REPORTES DEBE HACERLO POR LA WEB", Application.ProductName);
            this.Cursor = Cursors.Default;
        }

        //Private Sub IDM_FOR_Click()
        //
        //  Screen.MousePointer = HOURGLASS
        //
        //  igblNivelActivo = NIV_FOR
        //  iArrBitacora(NIV_FOR, 0) = BIT_CONFIGURAR
        //  iArrBitacora(NIV_FOR, 1) = iArrBitacora(NIV_FOR, 1) + 1
        //  pszArrBitForma(NIV_FOR, 0) = "CORMNFOR"
        //  pszArrBitForma(NIV_FOR, 1) = "Formato de Archivos"
        //  CORMNFOR.Show
        //
        //End Sub

        public void IDM_GACL_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GAC;
            CORVAR.iArrBitacora[CORCONST.NIV_GAC, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GAC, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GAC, 0] = "CORGRACL";
            CORVAR.pszArrBitForma[CORCONST.NIV_GAC, 1] = "Gráfica Aclaraciones";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGRACL.DefInstance.ShowDialog();

        }

        public void IDM_GANT_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GAN;
            CORVAR.iArrBitacora[CORCONST.NIV_GAN, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GAN, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GAN, 0] = "CORGRANT";
            CORVAR.pszArrBitForma[CORCONST.NIV_GAN, 1] = "Gráfica Antigüedad de la Cuenta";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGRANT.DefInstance.ShowDialog();

        }

        public void IDM_GBIT_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GBI;
            CORVAR.iArrBitacora[CORCONST.NIV_GBI, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GBI, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GBI, 0] = "CORGRBIT";
            CORVAR.pszArrBitForma[CORCONST.NIV_GBI, 1] = "Gráfica de Bitácora";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGRBIT.DefInstance.ShowDialog();
            if (CORGRBIT.DefInstance.flag)
                CORGRBIT.DefInstance.Close();

        }

        public void IDM_GCOM_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GCO;
            CORVAR.iArrBitacora[CORCONST.NIV_GCO, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GCO, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GCO, 0] = "CORGRCOM";
            CORVAR.pszArrBitForma[CORCONST.NIV_GCO, 1] = "Gráfica Comparativos";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGRCOM.DefInstance.ShowDialog();

        }

        public void IDM_GCOR_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GCO;
            CORVAR.iArrBitacora[CORCONST.NIV_GCO, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GCO, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GCO, 0] = "CORGRCOR";
            CORVAR.pszArrBitForma[CORCONST.NIV_GCO, 1] = "Gráfica Corporativa";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGRCOR.DefInstance.ShowDialog();
            if (CORGRCOR.DefInstance.flag)
            { CORGRCOR.DefInstance.Close(); }

        }

        public void IDM_GCRE_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GCR;
            CORVAR.iArrBitacora[CORCONST.NIV_GCR, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GCR, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GCR, 0] = "CORGRCRE";
            CORVAR.pszArrBitForma[CORCONST.NIV_GCR, 1] = "Gráfica Créditos";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGRCRE.DefInstance.ShowDialog();

        }

        public void IDM_GEMP_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GEM;
            CORVAR.iArrBitacora[CORCONST.NIV_GEM, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GEM, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GEM, 0] = "CORGREMP";
            CORVAR.pszArrBitForma[CORCONST.NIV_GEM, 1] = "Gráfica de Empresas";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGREMP.DefInstance.ShowDialog();

        }

        public void IDM_GER_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            CORVAR.igblNivelActivo = CORCONST.NIV_GER;
            CORVAR.iArrBitacora[CORCONST.NIV_GER, 0] = CORCONST.BIT_CONFIGURAR;
            CORVAR.iArrBitacora[CORCONST.NIV_GER, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GER, 0] = "CORREPCR";
            CORVAR.pszArrBitForma[CORCONST.NIV_GER, 1] = "Reportes de Crystal";

            CORREPCR.DefInstance.Show();

            this.Cursor = Cursors.Default;

        }

        public void IDM_GRA_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_GRA;

        }

        public void IDM_GRU_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GRU;
            CORVAR.iArrBitacora[CORCONST.NIV_GRU, 0] = CORCONST.BIT_CONFIGURAR;
            CORVAR.iArrBitacora[CORCONST.NIV_GRU, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GRU, 0] = "CORSGGRU";
            CORVAR.pszArrBitForma[CORCONST.NIV_GRU, 1] = "Grupos de Usuarios";
            CORSGGRU.DefInstance.Show();

        }

        public void IDM_GSIT_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GSI;
            CORVAR.iArrBitacora[CORCONST.NIV_GSI, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GSI, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GSI, 0] = "CORGRSIT";
            CORVAR.pszArrBitForma[CORCONST.NIV_GSI, 1] = "Gráfica de Sit. de la Cuenta";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGRSIT.DefInstance.ShowDialog();

        }

        public void IDM_GVEN_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_GVE;
            CORVAR.iArrBitacora[CORCONST.NIV_GVE, 0] = CORCONST.BIT_GRAFICAS;
            CORVAR.iArrBitacora[CORCONST.NIV_GVE, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_GVE, 0] = "CORGRVEN";
            CORVAR.pszArrBitForma[CORCONST.NIV_GVE, 1] = "Gráfica de Vencidos";
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORGRVEN.DefInstance.ShowDialog();

        }



        public void IDM_HIS_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_HIS;
            CORVAR.iArrBitacora[CORCONST.NIV_HIS, 0] = CORCONST.BIT_ACLARACIONES;
            CORVAR.iArrBitacora[CORCONST.NIV_HIS, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_HIS, 0] = "CORCTACL";
            CORVAR.pszArrBitForma[CORCONST.NIV_HIS, 1] = "Catálogo de Aclaraciones";
            CORCTACL.DefInstance.Show();
            if (CORCTACL.DefInstance.flag)
            {
                CORCTACL.DefInstance.Close();
            }
        }

        public void IDM_IMP_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_IMP;
            CORVAR.iArrBitacora[CORCONST.NIV_IMP, 0] = CORCONST.BIT_OPCIONES;
            CORVAR.iArrBitacora[CORCONST.NIV_IMP, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_IMP, 0] = "CORIMPRE";
            CORVAR.pszArrBitForma[CORCONST.NIV_IMP, 1] = "Impresión de Reportes";
            CORPROC.Imprime_Reporte();

            this.Cursor = Cursors.Default;

        }

        public void IDM_IND_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            Get_Help(1);

            this.Cursor = Cursors.Default;

        }


        public void IDM_INTD_Click(Object eventSender, EventArgs eventArgs)
        {
            //AIS-1211 NGONZALEZ
            //this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_INTD;
            CORVAR.iArrBitacora[CORCONST.NIV_INT, 0] = CORCONST.BIT_INTERFASES;
            CORVAR.iArrBitacora[CORCONST.NIV_INT, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_INT, 0] = "CORMENIN";
            CORVAR.pszArrBitForma[CORCONST.NIV_INT, 1] = "Estatus de Integración";
            CORMENIN.DefInstance.Tag = CORVB.NULL_STRING;
            //CORMENIN.DefInstance.ShowDialog(this);
            CORMENIN.DefInstance.Close();

        }


        public void IDM_LIM_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_LIM;
            CORVAR.iArrBitacora[CORCONST.NIV_LIM, 0] = CORCONST.BIT_CONFIGURAR;
            CORVAR.iArrBitacora[CORCONST.NIV_LIM, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_LIM, 0] = "CORLIMCR";
            CORVAR.pszArrBitForma[CORCONST.NIV_LIM, 1] = "Límites de Crédito";
            //AIS-1199 NGONZALEZ
            //VB6.ShowForm(CORLIMCR.DefInstance, (int) CORVB.MODAL, this);
            CORLIMCR.DefInstance.ShowDialog(this);

        }

        public void IDM_NET_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            //  igblNivelActivo = NIV_EMP
            //  iArrBitacora(NIV_EMP, 0) = BIT_ARCHIVOS
            //  iArrBitacora(NIV_EMP, 1) = iArrBitacora(NIV_EMP, 1) + 1
            //  pszArrBitForma(NIV_EMP, 0) = "CORCTEMP"
            //  pszArrBitForma(NIV_EMP, 1) = "Catálogo de Empresas"
            frmBancanet.DefInstance.Show();
            this.Cursor = Cursors.Default;
        }

        public void IDM_OPC_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_OPC;

        }

        public void IDM_OPE_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_OPE;

        }

        public void IDM_PAR_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_PAR;
            CORVAR.iArrBitacora[CORCONST.NIV_PAR, 0] = CORCONST.BIT_CONFIGURAR;
            CORVAR.iArrBitacora[CORCONST.NIV_PAR, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_PAR, 0] = "CORMNPAR";
            CORVAR.pszArrBitForma[CORCONST.NIV_PAR, 1] = "Parámetros Generales";
            //  CORCTPGS.Show
            CORMNPAR.DefInstance.Show();
            this.Cursor = Cursors.Default;

        }

        //UPGRADE_NOTE: (7001) The following declaration (IDM_RCOS_Click) seems to be dead code
        //private void  IDM_RCOS_Click()
        //{
        // SE COMENTA ESTA FORMA POR SER EXCLUIDA DEL PROYECTO FSWBMX
        //CORCTCOS.Show
        //
        //
        //}


        public void IDM_REG_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            CORVAR.igblNivelActivo = CORCONST.NIV_REG;
            CORVAR.iArrBitacora[CORCONST.NIV_REG, 0] = CORCONST.BIT_ARCHIVOS;
            CORVAR.iArrBitacora[CORCONST.NIV_REG, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_REG, 0] = "CORCTREG";
            CORVAR.pszArrBitForma[CORCONST.NIV_REG, 1] = "Catálogo de Regiones";

            CORCTREG.DefInstance.Show();
            this.Cursor = Cursors.Default;

        }

        public void IDM_REN_Click(Object eventSender, EventArgs eventArgs)
        {

            CORCTREN.DefInstance.Show();
            if (CORCTREN.DefInstance.flag)
                CORCTREN.DefInstance.Close();

        }

        public void IDM_REPORTE_Click(Object eventSender, EventArgs eventArgs)
        {
            frmCtasNvas tempLoadForm = frmCtasNvas.DefInstance;
        }

        public void IDM_RPT_TUXEDO_Click(Object eventSender, EventArgs eventArgs)
        {
            FrmTuxedo.DefInstance.Show();
        }

        //Se quito el menu Reporte de Movimientos con nombre IDM_REP
        //Private Sub IDM_REP_Click()
        //
        //  Screen.MousePointer = HOURGLASS
        //
        //  igblNivelActivo = NIV_REP
        //  iArrBitacora(NIV_REP, 0) = BIT_INTERFASES
        //  iArrBitacora(NIV_REP, 1) = iArrBitacora(NIV_REP, 1) + 1
        //  pszArrBitForma(NIV_REP, 0) = "CORRPMOV"
        //  pszArrBitForma(NIV_REP, 1) = "Reporte de Movimientos"
        //  CORRPMOV.Show
        //
        //End Sub

        public void IDM_SAL_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            this.Close();

            this.Cursor = Cursors.Default;

        }

        public void IDM_SEG_Click(Object eventSender, EventArgs eventArgs)
        {

            CORVAR.igblNivelActivo = CORCONST.NIV_SEG;

        }


        public void IDM_TRR_Click(Object eventSender, EventArgs eventArgs)
        {
            CORVAR.igblNivelActivo = CORCONST.NIV_TRR;
            CORVAR.iArrBitacora[CORCONST.NIV_TRR, 0] = CORCONST.BIT_CONFIGURAR;
            CORVAR.iArrBitacora[CORCONST.NIV_TRR, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_TRR, 0] = "CORTRAMO";
            CORVAR.pszArrBitForma[CORCONST.NIV_TRR, 1] = "Transmisión de Reportes.";

            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORTRAMO.DefInstance.ShowDialog();
        }


        public void IDM_TXT_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_TXT;
            //  iArrBitacora(NIV_TXT, 0) = BIT_OPCIONES
            //  iArrBitacora(NIV_TXT, 1) = iArrBitacora(NIV_TXT, 1) + 1
            //  pszArrBitForma(NIV_TXT, 0) = "COREXPTX"
            //  pszArrBitForma(NIV_TXT, 1) = "Exportación a Texto"
            CORPROC.Guarda_Texto();

            this.Cursor = Cursors.Default;

        }

        public void IDM_UAY_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            //igblErr = WinHelp(CORMDIBN.hWnd, pszgblPathCorpo + "Ayuda.hlp", 4, 0)
            //AIS-1182 NGONZALEZ
            if (File.Exists("Tarjeta Corporativa.HLP") == true)
            {
                CORVAR.igblErr = API.USER.WinHelp(CORMDIBN.DefInstance.Handle.ToInt32(), "Tarjeta Corporativa.HLP", 4, 0);
            }
            else
            {
                MessageBox.Show("No se puede hallar el archivo de Ayuda Tarjeta Corporativa.HLP.Compruebe si existe en su disco; de lo contrario necesitara instalarlo en nuevo", "Ayuda de Windows", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Cursor = Cursors.Default;

        }

        public void IDM_USU_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_USU;
            CORVAR.iArrBitacora[CORCONST.NIV_USU, 0] = CORCONST.BIT_CONFIGURAR;
            CORVAR.iArrBitacora[CORCONST.NIV_USU, 1]++;
            CORVAR.pszArrBitForma[CORCONST.NIV_USU, 0] = "CORSGUSU";
            CORVAR.pszArrBitForma[CORCONST.NIV_USU, 1] = "Usuarios del Sistema";
            CORSGUSU.DefInstance.Show();

        }

        public void IDM_WCRED_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_EXC;
            CORPROC.Abre_Word("Credito");

            this.Cursor = Cursors.Default;
        }

        public void IDM_WDOM_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            CORVAR.igblNivelActivo = CORCONST.NIV_EXC;
            CORPROC.Abre_Word("Domicilio");

            this.Cursor = Cursors.Default;


        }

        private void IDT_GPB_ClickEvent(Object eventSender, AxThreed.ISSRICtrlEvents_ClickEvent eventArgs)
        {
            int Index = Array.IndexOf(IDT_GPB, eventSender);
            //AIS-1095 NGONZALEZ
            if (eventArgs.value != 0)
            {
                if (Index != 8)
                {
                    this.Cursor = Cursors.WaitCursor;
                }
                switch (Index)
                {
                    case 0:
                        IDM_EMP_Click(IDM_EMP, new EventArgs());
                        break;
                    case 1:
                        IDM_EJE_Click(IDM_EJE, new EventArgs());
                        break;
                    case 2:
                        IDM_COR_Click(IDM_COR, new EventArgs());
                        //      Case 2: IDM_REP_Click 
                        break;
                    case 3:
                        //IDM_CAP_Click(IDM_CAP, new EventArgs());
                        //      Case 4: IDM_CAP_Click 
                        //      Case 5: IDM_HIS_Click 
                        //'      Case 6: IDM_RPT_Click 
                        //      Case 7: IDM_IND_Click 
                        break;
                    case 8:
                        VB6.SendKeys("%(NR)", false);
                        break;
                }

                IDT_GPB[Index].Value = false;

            }

        }

        public SAPUF_Enlace Sapuf;

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            // INICIA DECLARACIONES PARA SAPUF
            string BaseSAPUF = String.Empty;
            SAPUF_Enlace SapufEnlace = new SAPUF_Enlace();

            //CORSGPRE.DefInstance.Show();

            //StringBuilder s = new StringBuilder(255);
            //StringBuilder sError = new StringBuilder(4);
            //StringBuilder sSubError = new StringBuilder(4);
            object s;
            object sError;
            object sSubError;
            int tam = 0;
            string sDato = String.Empty;
            string respuesta = String.Empty;
            string Tipo_problema = String.Empty;
            string Codigo_error = String.Empty;

            //FIN DECLARACIONES PARA SAPUF 18/05/06


            this.Cursor = Cursors.WaitCursor;

            Seguridad.Deshabilita_Menu();

            ID_COR_BHER.Enabled = true;
            //Inicializa la bandera de existencia del scaner
            CORVAR.bgblScanActivo = 0;

            //Redimensiona la matriz que contabiliza la bitacora
            CORVAR.iArrBitacora = new int[CORCONST.MAX_NIVELES + 1, 2];
            CORVAR.pszArrBitForma = ArraysHelper.InitializeArray<string[,]>(new int[] { CORCONST.MAX_NIVELES + 1, 2 }, new int[] { 0, 0 });

            //Arma las variables de Conexión
            //CORDBLIB.gsServidor = mdlParametros.fncReadIniS("Corporativa", "Servidor");
            //CORDBLIB.gsBaseDatos = mdlParametros.fncReadIniS("Corporativa", "BaseDatos");
            //CORDBLIB.gsPuerto = mdlParametros.fncReadIniS("Corporativa", "Puerto");
            CORDBLIB.gsServidor = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\DataBase", "DBserver");
            CORDBLIB.gsBaseDatos = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\DataBase", "DBname");
            CORDBLIB.gsPuerto = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\DataBase", "DBport");

            if (CORDBLIB.gsPuerto.Trim() == "")
            {
                CORDBLIB.gsPuerto = "10430";
            }
            //    gsUsuario = fncReadIniS("Corporativa", "User")
            //    gsPassword = fncReadIniS("Corporativa", "Password")

            //Arma las variables de Conexión
            //mgc
            //gsUsuario = "c430_dbo"
            //gsUsuario = "c430"
            //gsPassword = "P48y37SX"
            //gsPassword = "P48i37SX" YURIA 18/05/06
            //UsuarioSAPUF = c430_dbo
            //BaseSAPUF = M111
            //ServidorSAPUF = SYB_C430
            //OperacionSAPUF = 11
            //MaqDestinoSAPUF = UEPSIMX
            //UsuDestinoSAPUF = c430_dbo
            //TipoDestSAPUF = SY
            //AplDestinoSAPUF = SYB_C430
            //AplOrigenSAPUF = C430_001
            //ModoRefrSAPUF = 0
            //TimerSAPUF = 9999
            //INICIA BLOQUE PARA OBTENER password a través de SAPU
            //string UsuarioSAPUF = mdlParametros.fncReadIniS("Corporativa", "UsuarioSAPUF").Trim();
            //string ServidorSAPUF = mdlParametros.fncReadIniS("Corporativa", "ServidorSAPUF").Trim();
            //int OperacionSAPUF = StringsHelper.IntValue(mdlParametros.fncReadIniS("Corporativa", "OperacionSAPUF").Trim());
            //string MaqDestinoSAPUF = mdlParametros.fncReadIniS("Corporativa", "MaqDestinoSAPUF").Trim();
            //string UsuDestinoSAPUF = mdlParametros.fncReadIniS("Corporativa", "UsuDestinoSAPUF").Trim();
            //string TipoDestSAPUF = mdlParametros.fncReadIniS("Corporativa", "TipoDestSAPUF").Trim();
            //string AplDestinoSAPUF = mdlParametros.fncReadIniS("Corporativa", "AplDestinoSAPUF").Trim();
            //string AplOrigenSAPUF = mdlParametros.fncReadIniS("Corporativa", "AplOrigenSAPUF").Trim();
            //int ModoRefrSAPUF = Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "ModoRefrSAPUF")); //mod refresh inicia con cero
            //int TimerSAPUF = Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "TimerSAPUF"));
            string UsuarioSAPUF = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "UsuarioSAPUF").Trim();
            string ServidorSAPUF = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "ServidorSAPUF").Trim();
            int OperacionSAPUF = StringsHelper.IntValue(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "OperacionSAPUF").Trim());
            string MaqDestinoSAPUF = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "MaqDestinoSAPUF").Trim();
            string UsuDestinoSAPUF = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "UsuDestinoSAPUF").Trim();
            string TipoDestSAPUF = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "TipoDestSAPUF").Trim();
            string AplDestinoSAPUF = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "AplDestinoSAPUF").Trim();
            string AplOrigenSAPUF = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "AplOrigenSAPUF").Trim();
            int ModoRefrSAPUF = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "ModoRefrSAPUF")); //mod refresh inicia con cero
            int TimerSAPUF = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\SAPUF", "TimerSAPUF"));
            mdlParametros.sgPathLogs = mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Rutas", "Logs").Trim();
            CORDBLIB.gsUsuario = UsuDestinoSAPUF;

            string cve_operacion = OperacionSAPUF.ToString(); // "11"
            //AIS-1182 NGONZALEZ
            //int resultado = API.Encryption.Solicitar_Password(cve_operacion, MaqDestinoSAPUF, UsuDestinoSAPUF, TipoDestSAPUF, AplDestinoSAPUF, AplOrigenSAPUF, ModoRefrSAPUF.ToString(), TimerSAPUF.ToString());
            int resultado = SapufEnlace.Solicitar_Password(cve_operacion, MaqDestinoSAPUF,
            UsuDestinoSAPUF, TipoDestSAPUF, AplDestinoSAPUF, AplOrigenSAPUF, ModoRefrSAPUF.ToString(), TimerSAPUF.ToString());
            if (resultado == 0)
            {
                //AIS-1182 NGONZALEZ
                //tam = API.Encryption.Recuperar_msg(s, sError, sSubError);
                tam = SapufEnlace.Recuperar_msg(out s, out sError, out sSubError);
                CORDBLIB.gsPassword = s.ToString();
                if (sError.ToString() == "0000" && sSubError.ToString() == "0000")
                {
                    //Tiempo del ConComDrive
                    //mdlParametros.igTimeComDrive = Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "Tiempo"));
                    mdlParametros.igTimeComDrive = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Comdrv", "comdrvTime"));

                    //Realiza la conexión al servidor configurado
                    if (CORDBLIB.Conexion_Servidor() == VBSQL.FAIL)
                    {
                        ModoRefrSAPUF = 1; //primera sol en modo refresco
                        //AIS-1182 NGONZALEZ
                        //resultado = API.Encryption.Solicitar_Password(cve_operacion, MaqDestinoSAPUF, UsuDestinoSAPUF, TipoDestSAPUF, AplDestinoSAPUF, AplOrigenSAPUF, ModoRefrSAPUF.ToString(), TimerSAPUF.ToString());
                        resultado = SapufEnlace.Solicitar_Password(cve_operacion, MaqDestinoSAPUF,
                        UsuDestinoSAPUF, TipoDestSAPUF, AplDestinoSAPUF, AplOrigenSAPUF, ModoRefrSAPUF.ToString(), TimerSAPUF.ToString());
                        if (resultado == 0)
                        {
                            //AIS-1182 NGONZALEZ
                            //tam = API.Encryption.Recuperar_msg(s, sError, sSubError);
                            tam = SapufEnlace.Recuperar_msg(out s, out sError, out sSubError);
                            CORDBLIB.gsPassword = s.ToString();
                            if (sError.ToString() == "0000" && sSubError.ToString() == "0000")
                            {
                                MessageBox.Show("eror " + sError.ToString() + "suberror" + sSubError.ToString(), Application.ProductName);
                                //Tiempo del ConComDrive
                                //mdlParametros.igTimeComDrive = Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "Tiempo"));
                                mdlParametros.igTimeComDrive = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Comdrv", "comdrvTime"));

                                if (CORDBLIB.Conexion_Servidor() == VBSQL.FAIL)
                                {
                                    ModoRefrSAPUF = 2; //segunda sol en modo refresco
                                    //AIS-1182 NGONZALEZ
                                    //resultado = API.Encryption.Solicitar_Password(cve_operacion, MaqDestinoSAPUF, UsuDestinoSAPUF, TipoDestSAPUF, AplDestinoSAPUF, AplOrigenSAPUF, ModoRefrSAPUF.ToString(), TimerSAPUF.ToString());
                                    resultado = SapufEnlace.Solicitar_Password(cve_operacion, MaqDestinoSAPUF,
                                    UsuDestinoSAPUF, TipoDestSAPUF, AplDestinoSAPUF, AplOrigenSAPUF, ModoRefrSAPUF.ToString(), TimerSAPUF.ToString());
                                    if (resultado == 0)
                                    {
                                        //AIS-1182 NGONZALEZ
                                        //tam = API.Encryption.Recuperar_msg(s, sError, sSubError);
                                        tam = SapufEnlace.Recuperar_msg(out s, out sError, out sSubError);
                                        CORDBLIB.gsPassword = s.ToString();
                                        if (sError.ToString() == "0000" && sSubError.ToString() == "0000")
                                        {
                                            //Tiempo del ConComDrive
                                            //mdlParametros.igTimeComDrive = Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "Tiempo"));
                                            mdlParametros.igTimeComDrive = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Comdrv", "comdrvTime"));

                                            if (CORDBLIB.Conexion_Servidor() == VBSQL.FAIL)
                                            {
                                                CORDBLIB.gsMsg = "DESINCRONIZACIÓN CON SAPUF";
                                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                                Interaction.MsgBox(CORDBLIB.gsMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                                this.Cursor = Cursors.Default;
                                                ModoRefrSAPUF = 3; //se notifica a SAPUF que existe desincronización
                                                Tipo_problema = "01";
                                                Codigo_error = "01";
                                                cve_operacion = Tipo_problema + Codigo_error;
                                                //AIS-1182 NGONZALEZ
                                                //resultado = API.Encryption.Solicitar_Password(cve_operacion, MaqDestinoSAPUF, UsuDestinoSAPUF, TipoDestSAPUF, AplDestinoSAPUF, AplOrigenSAPUF, ModoRefrSAPUF.ToString(), TimerSAPUF.ToString());
                                                resultado = SapufEnlace.Solicitar_Password(cve_operacion, MaqDestinoSAPUF,
                                                UsuDestinoSAPUF, TipoDestSAPUF, AplDestinoSAPUF, AplOrigenSAPUF, ModoRefrSAPUF.ToString(), TimerSAPUF.ToString());
                                                if (resultado != 0)
                                                {
                                                    CORDBLIB.gsMsg = "NO SE PUDO REALIZAR EL ANUNCIO DE DESINCRONIZACIÓN CON SAPUF";
                                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                                    Interaction.MsgBox(CORDBLIB.gsMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                                    this.Cursor = Cursors.Default;
                                                    Environment.Exit(0);
                                                }
                                                Environment.Exit(0);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("TERCER ERROR SAPUF " + " Error " + sError.ToString() + " SubError " + sSubError.ToString(), Application.ProductName);
                                            Environment.Exit(0);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error de SAPUF con segundo regreso (Atributo=2)" + Conversion.Str(resultado), "Error en Operación", MessageBoxButtons.OK, MessageBoxIcon.Error); //FSWB NR 20070315
                                        this.Cursor = Cursors.Default;
                                        Environment.Exit(0);
                                    } //fin del resultado=0 del pwd solicitado con atributo =2
                                } //fin de la segunda conexión solicitada con Atributo=1
                            }
                            else
                            {
                                MessageBox.Show("SEGUNDO ERROR SAPUF " + " Error " + sError.ToString() + " SubError " + sSubError.ToString(), Application.ProductName); //FSWB NR 20070315
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error de SAPUF con primer refresco (Atributo=1) " + Conversion.Str(resultado), "Error en Operación", MessageBoxButtons.OK, MessageBoxIcon.Error); //FSWB NR 20070315
                            this.Cursor = Cursors.Default;
                            Environment.Exit(0);
                        } //fin del if resultado =0 del envío con 1
                    } //fin de la primera conexión
                }
                else
                {
                    MessageBox.Show("PRIMER ERROR SAPUF " + " Error " + sError.ToString() + " SubError " + sSubError.ToString(), Application.ProductName); //FSWB NR 20070315
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("Error de SAPUF " + Conversion.Str(resultado), "Error en Operación", MessageBoxButtons.OK, MessageBoxIcon.Error); //FSWB NR 20070315
                this.Cursor = Cursors.Default;
                Environment.Exit(0);
            }


            //Declaracion de Seguridad
            mdlParametros.gperPerfil = new clsPerfil();

            if (fncCuentaBancosI() >= 1)
            {
                //CORSGACC.DefInstance.Show();
                //CCFmodGeneral.ffrmLogin.Show();
                frmLogin.DefInstance.Show();
            }
            else
            {
                CORSGPRE.DefInstance.Close();
                prHabilitaParametros();
            }

            if (Formato.ifncConexionFormato() == VBSQL.FAIL)
            {
                CORDBLIB.gsMsg = "La conexión a la Base de Datos no es válida. Consulte al Administrador del Sistema.";
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORDBLIB.gsMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                this.Cursor = Cursors.Default;
                Environment.Exit(0);
            }

            sspPanel[0].Caption = CRSParametros.sgUserID;
            char[] chrArray = DateTime.Today.ToString("dd MMM yyyy").ToCharArray();
            chrArray.SetValue(Char.ToUpper((char)chrArray.GetValue(3)), 3);
            sspPanel[1].Caption = new String(chrArray);
            CRSGeneral.prCargaEstados();
            this.Cursor = Cursors.Default;
            /*SE EMPATA CON LA VERSIÓN DE PRODUCCIÓN 14/01/10*/
            // Creación del C430.Log de forma Temporal
            string filepath;
            string sFecha = DateTime.Today.ToString("ddMMyy");
            //String DirExe = Path.GetDirectoryName(Application.ExecutablePath);
            filepath = mdlParametros.sgPathLogs + "AltasEjec" + sFecha + ".Log";
            CORVAR.FileNumber = FileSystem.FreeFile();
            try
            {
                FileSystem.FileOpen(CORVAR.FileNumber, filepath, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
                FileSystem.FileClose(CORVAR.FileNumber);
                CORVAR.FileNumber = FileSystem.FreeFile();
                FileSystem.FileOpen(CORVAR.FileNumber, filepath, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
            }

            catch (Exception ex)
            {
                //Artinsoft.VB6.VB.Err.LoadError(ex, false);
                FileSystem.FileOpen(CORVAR.FileNumber, filepath, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
            }

            //Timer MyTimer = new Timer();
            //MyTimer.Interval = (1 * 60 *1000);
            //MyTimer.Tick += new EventHandler(MyTimer_Tick);
            //MyTimer.
            //MyTimer.Start();

        }

        //private void MyTimer_Tick(object sender, EventArgs e)
        //{
        //    MessageBox.Show("La aplicacion se cerrara por inactividad", "Terminado");
        //    this.Close();
        //}

        private void CORMDIBN_Closing(Object eventSender, CancelEventArgs eventArgs)
        {
            int Cancel = (eventArgs.Cancel) ? -1 : 0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                int iResp = (int)Interaction.MsgBox("¿Salir de la Aplicación... ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                
                if (iResp == CORVB.IDYES)
                {
                    //###########################################################################################################################
                    string StrIp = mdlSeguridad.GetIP();
                    //string StrIp = "10.199.251.246";
                    int FirmaoDesfirma = 2;

                    string _url = ConfigurationManager.AppSettings["_url"];
                    string _action = ConfigurationManager.AppSettings["_action_b"];

                    String desfirma = mdlSeguridad.Desfirma(StrIp, FirmaoDesfirma, _url, _action);

                    if (desfirma == "1") 
                    {
                        mdlParametros.gperPerfil = null;
                        mdlBitacora.sgClaveTransaccion = "SALIDA C430";
                        mdlBitacora.sgClaveResolucion = "SALIDA EXITOSA";
                        //###########################################################################################################################

                        mdlBitacora.prInsertaBitacora(mdlBitacora.enuTipoBitacora.tbitTransacciones);
                        if (CORPROC.ModuloEnUso("Reporteador") != 0)
                        {
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            iResp = (int)Interaction.MsgBox("¿Cerrar tambien el Reporteador ?...", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                            if (iResp == CORVB.IDYES)
                            {
                                Information.Err().Number = CORCONST.OK;
                                Interaction.AppActivate("Reporteador");
                                if (Information.Err().Number != 0)
                                {
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("No se pudo cerrar el Reporteador. Favor de cerrarlo manualmente", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    iResp = 0;
                                }
                                else
                                {
                                    SendKeys.SendWait("^{F4}");
                                }
                            }
                        }
                    }

                    if (iResp != 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.Hide();

                        //Inicializa las variables del nombre y la clave del usuario en el corbnx32.ini
                        //AIS-1182 NGONZALEZ
                        //CORVAR.igblErr = API.KERNEL.WritePrivateProfileString("Corporativa", "Clave", "", "corbnx32.ini");

                        Actualiza_Bitacora();
                        //AIS-1195 NGONZALEZ
                        //this.Close();
                        //CORSGACC.DefInstance.Close();
                        //CCFmodGeneral.ffrmLogin.Close();
                        //frmLogin.DefInstance.Close();
                    }
                }
                else
                {
                    Cancel = -1;
                }

                eventArgs.Cancel = Cancel != 0;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        private void CORMDIBN_Closed(Object eventSender, EventArgs eventArgs)
        {
            //Libera memoria de las fuciones de VBSQL
            VBSQL.SqlClose(CORVAR.hgblConexion);
            VBSQL.SqlClose(Formato.hgblConexion3);
            VBSQL.SqlExit();
            VBSQL.SqlWinExit();
            this.Cursor = Cursors.Default;
            //Cierra la Aplicación
            Environment.Exit(0);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


        public void Estructuras_Gastos_Click(Object eventSender, EventArgs eventArgs)
        {
            CORCTESTRUCT2.DefInstance.Show();
        }

        public void mnu_account_cycle_Click(Object eventSender, EventArgs eventArgs)
        {
            frmAccCyRep.DefInstance.Show();
        }

        public void mnu_account_tran_Click(Object eventSender, EventArgs eventArgs)
        {
            Corcntrancta.DefInstance.Show();
        }

        public void mnu_categorias_Click(Object eventSender, EventArgs eventArgs)
        {
            frm_men_cat.DefInstance.Show();
        }

        public void mnu_corte_sbf_Click(Object eventSender, EventArgs eventArgs)
        {
            //VB6.ShowForm(frm_CCFSeleccion.DefInstance, (int) FormShowConstants.Modal, this);
            //AIS-1199 NGONZALEZ
            frm_CCFSeleccion.DefInstance.ShowDialog(this);
            switch (CRSParametros.giccftipo)
            {
                case 1:
                    ccf_corte();
                    break;
                case 2:
                    sbf_diario();
                    break;
                case 3:
                    sbf_corte();
                    break;
            }
        }

        private void ccf_corte()
        {
            //Periodo Al Corte variable=1
            //TIPO_PERIODO = 1
            CCFmodGeneral.TIPO_PERIODO = 0;
            //Creando la fecha
            string lsFecha = DateTime.Today.AddDays(-1).ToString();
            string LsAnio = lsFecha.Substring(lsFecha.Length - Math.Min(lsFecha.Length, 4));
            lsFecha = lsFecha.Substring(0, lsFecha.Length - 5);
            string lsMes = lsFecha.Substring(lsFecha.Length - Math.Min(lsFecha.Length, 2));
            string lsDia = lsFecha.Substring(0, Math.Min(lsFecha.Length, 2));
            lsFecha = lsMes + lsDia;
            //Creando el nombre del archivo CCF
            CCFmodGeneral.NOMBRE_ARCHIVO = "CCF" + lsFecha + "D.txt";
            //Verifico que el archivo diario exista
            CCFmodGeneral.FunVerificaArchivoCCF(CCFmodGeneral.NOMBRE_ARCHIVO);
            frmArchivosPendientes tempLoadForm = frmArchivosPendientes.DefInstance;
            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            frmArchivosPendientes.DefInstance.ShowDialog();
        }
        //
        private void sbf_corte()
        {
            mdlParametros.IgEnvioSBF = 3;
            mdlParametros.prBuscaNombreArch(mdlParametros.IgEnvioSBF);
            //    If fncBuscaGenSbfB = True Then          'Si existe el archivo
            //        prBuscaErrorB
            //        If blbandera = True Then
            //            frmSBFEmpresa.Show 1
            //        End If
            //    Else                                    'No existe el archivo
            //        MsgBox "El archivo SBF no ha sido generado", vbInformation + vbOKOnly, App.Title
            //        Exit Sub
            //    End If
            if (!mdlParametros.fncBuscaGenSbfB())
            { //Si no existe el archivo
                prBuscaErrorB();
                return;
            }
            else
            {
                //Si existe el archivo
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                frmSBFEmpresa.DefInstance.ShowDialog();
            }
        }

        private void sbf_diario()
        {

            //Form1.Show 1

            mdlParametros.IgEnvioSBF = 2;
            mdlParametros.prBuscaNombreArch(mdlParametros.IgEnvioSBF);

            //    If fncBuscaGenSbfB = True Then          'Si existe el archivo
            //        prBuscaErrorB
            //        If blbandera = True Then
            //            frmSBFEmpresa.Show 1
            //        End If
            //    Else                                    'No existe el archivo
            //        MsgBox "El archivo SBF no ha sido generado", vbInformation + vbOKOnly, App.Title
            //        Exit Sub
            //    End If

            if (!mdlParametros.fncBuscaGenSbfB())
            { //Si no existe el archivo
                prBuscaErrorB();
                return;
            }
            else
            {
                //Si existe el archivo
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                frmSBFEmpresa.DefInstance.ShowDialog();
            }


        }

        public void mnu_reportes_Click(Object eventSender, EventArgs eventArgs)
        {
            frm_men_rep.DefInstance.Show();
        }

        public void mnu_unidades_Click(Object eventSender, EventArgs eventArgs)
        {
            CORCTUNI.DefInstance.Show();
        }

        public void mnuArcRevisionCanc_Click(Object eventSender, EventArgs eventArgs)
        {
            frmCancMaker.DefInstance.Show();
        }

        public void mnuArchAutCancelaciones_Click(Object eventSender, EventArgs eventArgs)
        {
            frmCancAutoriz.DefInstance.Show();
        }

        public void mnuAutAltasMasivas_Click(Object eventSender, EventArgs eventArgs)
        {
            frmAutAltasMasivas.DefInstance.Show();
        }

        //UPGRADE_NOTE: (7001) The following declaration (tmp_Click) seems to be dead code
        //private void  tmp_Click()
        //{
        //frmAltaMasivaTH.DefInstance.Show();
        //}

        public void mnuCamMasivos_Click(Object eventSender, EventArgs eventArgs)
        {
            frmCambiosMasivos.DefInstance.Show();
        }

        public void mnuCnsDtlEmpresas_Click(Object eventSender, EventArgs eventArgs)
        {
            int intFile = 0;
            string strfile = String.Empty;
            StringBuilder StrCadena = new StringBuilder();
            StrCadena.Append(String.Empty);
            ADODB.Recordset adorst = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                mdlParametros.bgCamLimCred = true;

                if (VBSQL.OpenConn(10) != 0)
                {
                    VBSQL.gConn[10].Close();
                }
                else
                {
                    VBSQL.gConn[10].Close();
                }

                if (VBSQL.OpenConn(10) == 0)
                {
                    //            pszgblsql = "SELECT emp_num, emp_nom, emp_fec_venc_cred, emp_cred_tot, emp_acum_cred, emp_dia_corte "
                    // Modif. 18/Jun/2007 Calc Lim Real
                    CORVAR.pszgblsql = "SELECT emp_num, emp_nom, emp_fec_venc_cred, emp_cred_tot, emp_acum_cred = ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = MTCEMP01.emp_num ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = MTCEMP01.emp_num ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )), ";
                    //            pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )), "
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_dia_corte ";

                    CORVAR.pszgblsql = CORVAR.pszgblsql + "From MTCEMP01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " AND gpo_banco=" + CORVAR.igblBanco.ToString() + " ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "ORDER BY emp_num";
                    //           MsgBox pszgblsql
                    adorst = new ADODB.Recordset();

                    adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, -1);

                    if (!adorst.BOF && !adorst.EOF)
                    {
                        intFile = FileSystem.FreeFile();

                        strfile = mdlParametros.sgPathFirmas + "RepEmpNvas" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                        //pszgblPathRepCrystal
                        FileSystem.FileOpen(intFile, strfile, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                        StrCadena = new StringBuilder("Núm Emp Nombre                                        Fecha Venc.           Crédito Asignado");
                        StrCadena.Append("  Crédito Acumulado  Día Corte");
                        FileSystem.PrintLine(intFile, StrCadena.ToString());

                        while (!adorst.EOF)
                        {

                            int tempRefParam = 8;
                            string tempRefParam2 = " ";
                            StrCadena = new StringBuilder(CRSGeneral.sfncJustificar(StringsHelper.Format(adorst.Fields["emp_num"].Value, new string('0', Formato.igLongitudEmpresa)), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam, ref tempRefParam2));
                            int tempRefParam3 = 46;
                            string tempRefParam4 = " ";
                            StrCadena.Append(CRSGeneral.sfncJustificar(Convert.ToString(adorst.Fields["emp_nom"].Value).Trim(), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam3, ref tempRefParam4));
                            int tempRefParam5 = 19;
                            string tempRefParam6 = " ";
                            StrCadena.Append(CRSGeneral.sfncJustificar(DateTime.Parse(adorst.Fields["emp_fec_venc_cred"].Value.ToString()).ToString("d"), CRSGeneral.cteJustificado.cteIzquierda, ref tempRefParam5, ref tempRefParam6));
                            int tempRefParam7 = 19;
                            string tempRefParam8 = " ";
                            StrCadena.Append(CRSGeneral.sfncJustificar(StringsHelper.Format(adorst.Fields["emp_cred_tot"].Value, "#,###,###,##0.00"), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam7, ref tempRefParam8));
                            int tempRefParam9 = 19;
                            string tempRefParam10 = " ";
                            StrCadena.Append(CRSGeneral.sfncJustificar(StringsHelper.Format(adorst.Fields["emp_acum_cred"].Value, "#,###,###,##0.00"), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam9, ref tempRefParam10));
                            int tempRefParam11 = 11;
                            string tempRefParam12 = " ";
                            StrCadena.Append(CRSGeneral.sfncJustificar(StringsHelper.Format(adorst.Fields["emp_dia_corte"].Value, "00"), CRSGeneral.cteJustificado.cteDerecha, ref tempRefParam11, ref tempRefParam12));

                            FileSystem.PrintLine(intFile, StrCadena.ToString());

                            adorst.MoveNext();
                        }
                        FileSystem.FileClose(intFile);

                        MessageBox.Show("Reporte Generado" + "\n" + "\r" + "Nombre:" + strfile, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Reporte No Generado por falta de datos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                    if (adorst.State == 1)
                    {
                        adorst.Close();
                    }

                    if (VBSQL.gConn[10].State == 1)
                    {
                        VBSQL.gConn[10].Close();
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch
            {

                string tempRefParam13 = "Tarjeta Ejecutiva.- cmdReporte_Click";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam13))
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }

                if (adorst.State == 1)
                {
                    adorst.Close();
                }

                if (VBSQL.gConn[10].State == 1)
                {
                    VBSQL.gConn[10].Close();
                }
                this.Cursor = Cursors.Default;
            }
        }

        public void mnuEmpresaNueva_Click(Object eventSender, EventArgs eventArgs)
        {
            frmEmpresa.DefInstance.Show();
        }

        private void prBuscaErrorB()
        {

            string slFecha = String.Empty;
            string slHora = String.Empty;
            string slNomArch = String.Empty;
            int ilEstatus = 0;
            string slMensaje = String.Empty;
            string smfecha = String.Empty;
            string smhora = String.Empty;

            try
            {

                smfecha = DateTime.Today.ToString("yyyyMMdd");
                smhora = DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss");

                ilEstatus = CORVB.NULL_INTEGER;
                slMensaje = CORVB.NULL_STRING;

                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_estatus";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCPRO03";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where pro_fecha = '" + smfecha + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch = '" + mdlParametros.sgDescArch + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_estatus = 12";

                if (CORPROC2.Cuenta_Registros() > 0)
                {
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_estatus,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_nomarch,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " pro_mensaje";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCPRO03";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where pro_fecha = '" + smfecha + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_nomarch = '" + mdlParametros.sgDescArch + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_estatus <= 12";

                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and pro_estatus not in(0,2,5,6,8,10)";

                    CORVAR.pszgblsql = CORVAR.pszgblsql + " order by pro_hora desc";

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) != 12)
                            {
                                ilEstatus = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                                slNomArch = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                slMensaje = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                                break;
                            }
                        };
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    if (ilEstatus != 0)
                    {
                        MessageBox.Show("Se ha presentado el siguiente error en la generación del archivo " + slNomArch + " : " + slMensaje, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        blbandera = false;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No existen datos con la información solicitada ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    blbandera = true;
                    return;
                }
            }
            catch (Exception e)
            {


                CRSGeneral.prObtenError("frmSBFEmpresa (BuscaError)", e);
                return;
            }


        }

        public void mnuEnvioTope_Click(Object eventSender, EventArgs eventArgs)
        {
            frmAutLimUso.DefInstance.Show();
            //    glstrLimCred = "linea"
            //    frmEnvioLimCred.Show MODAL
        }

        //descomentar en produccion
        //Private Sub tmrTimer_Timer()
        //    sspPanel(2).Caption = Format(Time, "hh:mm AMPM")
        //End Sub

        //Private Sub Unidades_Click()
        //  CORCTUNI.Show
        //End Sub

        private void prHabilitaParametros()
        {

            //1er. Menu
            CORMDIBN.DefInstance.IDM_ESP.Enabled = true; //Configurar
            CORMDIBN.DefInstance.IDM_PAR.Enabled = true; //Parametros
            CORMDIBN.DefInstance.IDM_INTD.Enabled = false; //Estatus de Integracion
            //CORMDIBN.DefInstance.IDM_CDF.Enabled = false; //Estatus CDF
            CORMDIBN.DefInstance.IDM_ENV.Enabled = false; //Estatus Intelar
            //CORMDIBN.IDM_CAMM.Enabled = False                   'Cambios Masivos
            //CORMDIBN.DefInstance.IDM_LIM.Enabled = false; //Limite de Credito
            CORMDIBN.DefInstance.IDM_SEG.Enabled = false; //Seguridad
            CORMDIBN.DefInstance.IDM_USU.Enabled = false; //Usuario
            CORMDIBN.DefInstance.IDT_GPB[0].Enabled = true;
            CORMDIBN.DefInstance.IDM_GRU.Enabled = false; //Grupo
            CORMDIBN.DefInstance.IDT_GPB[1].Enabled = true;
            CORMDIBN.DefInstance.IDM_BCO.Enabled = false; //Banco de Operacion
            CORMDIBN.DefInstance.IDM_SAL.Enabled = true; //Salir

            //2o. Menu
            //CORMDIBN.IDM_OPE.Enabled = False                    'Interfaces
            CORMDIBN.DefInstance.IDM_TRR.Enabled = false; //Transmision de Reportes

            //3er. Menu
            CORMDIBN.DefInstance.IDM_CAT.Enabled = false; //Archivos
            //CORMDIBN.DefInstance.Estructuras_Gastos.Enabled = false; //Estructura de Gastos
            CORMDIBN.DefInstance.IDM_COR.Enabled = false; //Corporativos
            CORMDIBN.DefInstance.IDM_EMP.Enabled = false; //Empresas
            CORMDIBN.DefInstance.mnu_unidades.Enabled = false; //Unidades
            CORMDIBN.DefInstance.mnu_reportes.Enabled = false; //Reportes
            //CORMDIBN.mnu_categorias.Enabled = False             'Categorias
            CORMDIBN.DefInstance.IDM_EJE.Enabled = false; //TajetaHabientes
            CORMDIBN.DefInstance.IDM_BAN.Enabled = false; //Ejecutivos Banamex
            CORMDIBN.DefInstance.IDM_CCI.Enabled = false; //Activar Reportes en CCI
            //CORMDIBN.IDM_DIV.Enabled = False                    'Divisiones Regionales
            //CORMDIBN.IDM_REG.Enabled = False                    'Regiones
            //CORMDIBN.DefInstance.IDM_ALTAS_MASIVAS.Enabled = false; //Altas Masivas

            //4o. Menu
            CORMDIBN.DefInstance.IDM_CTA.Enabled = false; //Consultas
            CORMDIBN.DefInstance.IDM_CON.Enabled = false; //Concentrado
            CORMDIBN.DefInstance.IDM_CEJ.Enabled = false; //Empresas/Ejecutivos
            CORMDIBN.DefInstance.IDM_CEM.Enabled = false; //Grupo/Empresa
            CORMDIBN.DefInstance.IDM_ANA.Enabled = false; //Consumos por Giro
            CORMDIBN.DefInstance.IDM_DET.Enabled = false; //Detalle
            //CORMDIBN.DefInstance.IDM_ATR.Enabled = false; //Atrasos por Ejecutivo
            CORMDIBN.DefInstance.IDM_DEJ.Enabled = false; //Ejecutivos Banamex
            CORMDIBN.DefInstance.IDM_AFI.Enabled = false; //Empresas Afiliadas
            //CORMDIBN.IDM_GER.Enabled = False                    'Crystal Report
            //CORMDIBN.DefInstance.IDM_REN.Enabled = false; //Rentabilidad
            //CORMDIBN.IDM_BNX.Enabled = False                    'Ejecutivos Banamex
            //CORMDIBN.IDM_GRA.Enabled = False                    'Graficas
            //CORMDIBN.DefInstance.IDM_GBIT.Enabled = false; //Bitacora
            //CORMDIBN.DefInstance.IDM_GCOR.Enabled = false; //Corporativos
            //CORMDIBN.DefInstance.IDM_GEMP.Enabled = false; //Empresas
            //CORMDIBN.DefInstance.IDM_GACL.Enabled = false; //Aclaraciones
            //CORMDIBN.DefInstance.IDM_GSIT.Enabled = false; //Situacion de la Cuenta
            //CORMDIBN.DefInstance.IDM_GCRE.Enabled = false; //Creditos
            //CORMDIBN.DefInstance.IDM_GANT.Enabled = false; //Antiguedad de la Cuenta
            //CORMDIBN.DefInstance.IDM_GVEN.Enabled = false; //Vencidos
            //CORMDIBN.DefInstance.IDM_GCOM.Enabled = false; //Comparativos
            CORMDIBN.DefInstance.IDM_OPC.Enabled = false; //Opciones

            //5o. menu
            //CORMDIBN.DefInstance.IDM_ACL.Enabled = true;
            //CORMDIBN.DefInstance.IDM_CAP.Enabled = true;
            //CORMDIBN.DefInstance.IDM_HIS.Enabled = true;
            //CORMDIBN.DefInstance.IDM_AVE.Enabled = true;
            CORMDIBN.DefInstance.ID_COR_BHER.Enabled = true;

            //Toolbar
            CORMDIBN.DefInstance.IDT_GPB[0].Enabled = false; //Empresa
            CORMDIBN.DefInstance.IDT_GPB[1].Enabled = false; //Ejecutivo
            CORMDIBN.DefInstance.IDT_GPB[2].Enabled = false; //Corporativo

        }

        private int fncCuentaBancosI()
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            int result = 0;
            try
            {

                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_pref,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_banco,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_ban_des";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCON01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where con_tipo_prod = 'D'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY con_banco";

                result = CORPROC2.Cuenta_Registros();
                if (result <= 0)
                {
                    MessageBox.Show("No existen Bancos en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    return result;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        //UPGRADE_NOTE: (7001) The following declaration (ProcesoEspecial_Click) seems to be dead code
        //private void  ProcesoEspecial_Click()
        //{
        //
        //}

        public void mnuProcEsp_Click(Object eventSender, EventArgs eventArgs)
        {
            CORPROE.DefInstance.Show();
        }
        //UPGRADE_NOTE: (7001) The following declaration (Form_Unload) seems to be dead code
        //private void  Form_Unload(ref  int Cancel)
        //{
        //}
        [STAThread]
        static void Main()
        {
            Application.Run(CreateInstance());
        }

        private void catalogosDeMonedasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CORMONE.DefInstance.Show();
        }

        //AIS-1601 FSABORIO
        private void IDM_AYU_DropDownClosed(object sender, EventArgs e)
        {
            List<ToolStripItem> menuList = new List<ToolStripItem>();
            foreach (ToolStripItem menu in IDM_VEN.DropDownItems)
            {
                menuList.Add(menu);
            }

            foreach (ToolStripItem menu in menuList)
            {
                mnuWindowList.DropDownItems.Add(menu);
            }
        }

        //AIS-1601 FSABORIO
        private void IDM_AYU_DropDownOpening(object sender, EventArgs e)
        {
            List<ToolStripItem> menuList = new List<ToolStripItem>();
            foreach (ToolStripItem menu in mnuWindowList.DropDownItems)
            {
                menuList.Add(menu);
            }

            foreach (ToolStripItem menu in menuList)
            {
                IDM_VEN.DropDownItems.Add(menu);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (CCFmodGeneral.searchStr)
            {
                CCFmodGeneral.searchStr = "";
            }
        }
    }
}
