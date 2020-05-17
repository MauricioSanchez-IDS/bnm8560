using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using Softtek.Utils.Win.Spread;

namespace TCc430
{
    internal partial class FrmTuxedo
        : System.Windows.Forms.Form
    {

        private void FrmTuxedo_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }

        private enum EnTipoReporte
        {
            rptGrupo = 0,
            rptGrupoEmpresa = 1,
            RptGrupoEmpresaUnidad = 2
        }


        int PosInicial = 0;
        string[] ASEstadosSocket = ArraysHelper.InitializeArray<string>(10);
        Collection ReportesCol = null; //Colexion con la lista de reportes a procesar
        EnTipoReporte TipoReporte = (EnTipoReporte)0;


        const string DESCONECTADO = "0";
        const string INICIANDO_NEGOCIACION = "1";
        const string SOLICITA_LOGIN = "2";
        const string SOLICITA_PWD = "3";
        const string LOGIN_INCORRECTO = "4";
        const string LOGIN_MENSAJES_BIENVENIDA = "5";
        const string PRESENTA_PROMPT = "6";
        const string SOLICITAR_PROCESO = "7";
        const string CUENTA_INACTIVA = "8";
        const string CONEXION_CANCELADA = "9";
        const int COL_GENERAREPORTE = 4;
        const int COL_ESTADOREPORTE = 5;
        const int timeout = 30;
        ClsReporteGerencia ObjReporteProcesar = null;

        /*
        private ClsTuxedo _objConexionTuxedo = null; //28/09/09
        ClsTuxedo objConexionTuxedo
        {
            get
            {
                return _objConexionTuxedo;
            }
            set
            {
                if (_objConexionTuxedo != value)
                {
                    if (_objConexionTuxedo != null)
                    {
                        this.objConexionTuxedo.Error -= new ClsTuxedo.ErrorHandler(this.objConexionTuxedo_Error);
                    }
                    _objConexionTuxedo = value;
                    if (_objConexionTuxedo != null)
                    {
                        this.objConexionTuxedo.Error += new ClsTuxedo.ErrorHandler(this.objConexionTuxedo_Error);
                    }
                }
            }
        }
        */

        /*
       private ClsTcpIp _objCnnTcpIp = null; //28/09/09
        ClsTcpIp objCnnTcpIp
        {
            get
            {
                if (_objCnnTcpIp == null)
                {
                    _objCnnTcpIp = new ClsTcpIp();
                }
                return _objCnnTcpIp;
            }
            set
            {
                _objCnnTcpIp = value;
            }
        }
        */


        private void BtnConectar_Click(Object eventSender, EventArgs eventArgs)
        {
            //    Call Conectar
        }

        private void BtnDirNuevo_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                string strDirNuevo = String.Empty;
                //strDirNuevo = CurDir()

                if (txtDirNuevo.Text.Trim().EndsWith("\\"))
                {
                    strDirNuevo = txtDirNuevo.Text.Trim().Substring(0, txtDirNuevo.Text.Trim().Length - 1);
                }
                else
                {
                    strDirNuevo = txtDirNuevo.Text.Trim();
                }

                if (strDirNuevo.Trim().Substring(0, Math.Min(strDirNuevo.Trim().Length, 1)) == "\\")
                {
                    strDirNuevo = strDirNuevo.Trim();
                    //AIS-NO ES NECESARIO NGONZALEZ
                    //strDirNuevo.Substring[0, Math.Min(strDirNuevo.Length, 1)] = "";


                }
                if (!Directory.GetCurrentDirectory().EndsWith("\\"))
                {
                    strDirNuevo = Directory.GetCurrentDirectory() + "\\" + strDirNuevo;
                }
                else
                {
                    strDirNuevo = Directory.GetCurrentDirectory() + strDirNuevo;
                }
                Directory.CreateDirectory(strDirNuevo);
                DirLocal.Refresh();
            }
            catch (Exception excep)
            {

                MdlCambioMasivo.MsgInfo(excep.Message);
            }



        }

        private void BtnEnviar_Click(Object eventSender, EventArgs eventArgs)
        {
            if (Strings.Len(TxtTelnet.Text) > 60000)
            {
                TxtTelnet.Text = ""; //Inicia el contenido de la pantalla ya que un control de texto no soporta
                //Contenidos superiores a los 64K
            }
            if (TelnetWS.CtlState == 7)
            {
                TelnetWS.SendData(txtComando.Text + "\r\n");
                txtComando.Text = "";
            }
            else
            {
                MdlCambioMasivo.MsgInfo("No está conectado al equipo remoto");
            }

        }

        private void BtnProcesar_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            string strData = String.Empty;
            bool blReportesSeleccionados = false;
            int lngLongitudRpt = 0;
            ADODB.Recordset rsMTCPGS = null;
            string strEstadoReporte = String.Empty;
            string strDescEstadoReporte = String.Empty;

            string strIdEmpresa = String.Empty;
            string strUnidad = String.Empty;
            string strNivel = String.Empty;
            int HoraInicial = 0;
            int renglon = 0;
            System.DateTime lngHoraArranque = DateTime.FromOADate(0);
            string strEstadoRpt = String.Empty;
            int intReportesRestantes = 0;
            string strCicloReporte = String.Empty;
            string strFechaInicial = String.Empty;
            string strFechaFinal = String.Empty;
            string strFechaCorte = String.Empty;

            //Inician definiciones Yuria
            string EmpresaMenor = String.Empty;
            string fecha1 = String.Empty;
            object serv_rep = null;
            StringBuilder SqlCmd = new StringBuilder();
            SqlCmd.Append(String.Empty);
            ADODB.Recordset rs1 = null;
            string strCmdShell = String.Empty;
            string strFecha = String.Empty;
            string mstrFechaIni = String.Empty;
            string mstrFechaFin = String.Empty;
            string mstrFechaCorte = String.Empty;
            string strError = String.Empty;
            int lngError = 0;
            string datosRep = String.Empty;
            int estadoProc = 0;

            string Prefijo = String.Empty;
            string Banco = String.Empty;
            string Empresa = String.Empty;
            string Unidad = String.Empty;
            string Reporte = String.Empty;
            string Frecuencia = String.Empty;
            string LongEmpresa = String.Empty;
            string LongEjecutivo = String.Empty;
            string LongUnidad = String.Empty;
            string LongReporte = String.Empty;
            string Por_Grupo = String.Empty;
            string NivelIni = String.Empty;
            string NivelFin = String.Empty;
            //Dim strCicloReporte As String
            string strFechaIni = String.Empty;
            string strFechaFin = String.Empty;
            string Grupo = String.Empty;
            //rsMTCPGS = new ADODB.Recordset();
            string strNombreArchivoCte = String.Empty;
            const int MAX_LONG_ARCHIVO_DESTINO = 150;


            int intFile = 0;
            string StrCadena = String.Empty, strfile = String.Empty;
            ADODB.Recordset adorst = null;


            int lngTimeOut = 5; //TimeOut en segundos para esperar respuesta del telnet //Segundos para esperar una respuesta del cliente de telnet
            try
            {
                //TxtTelnet.Visible = True
                // SpdReportes.Visible = False

                DirLocal_Change(DirLocal, new EventArgs());

                if (!MdlCambioMasivo.FnMsgYesno("Este Proceso generará los reportes seleccionados en: " + "\r\n" + Directory.GetCurrentDirectory() +
                                                 "\r\n" + "¿ Desea Continuar ? "))
                {
                    return;
                }


                if (CboEmpresas[0].SelectedIndex == -1)
                {
                    CboEmpresas[0].Focus();
                    MdlCambioMasivo.MsgInfo("Debe elegir un grupo a procesar");
                    return;
                }

                if (CboEmpresas[1].SelectedIndex == -1 && TipoReporte != EnTipoReporte.rptGrupo)
                {
                    CboEmpresas[1].Focus();
                    MdlCambioMasivo.MsgInfo("Debe elegir una empresa a procesar");
                    return;
                }
                if (CboEmpresas[2].SelectedIndex == -1 && TipoReporte == EnTipoReporte.RptGrupoEmpresaUnidad)
                {
                    CboEmpresas[2].Focus();
                    MdlCambioMasivo.MsgInfo("Debe elegir una unidad a procesar");
                    return;
                }
                if (ChkNivel.CheckState == CheckState.Checked && CboNivel[0].SelectedIndex == -1)
                {
                    CboNivel[0].Focus();
                    MdlCambioMasivo.MsgInfo("Debe elegir un nivel a procesar");
                    return;
                }

                if (CboFecha.SelectedIndex == -1)
                {
                    MdlCambioMasivo.MsgInfo("Debe Elegir un Periodo para el reporte a procesar");
                    return;
                }
                else
                {
                    if (!FnBolValidaFecha(MskFecha[0]))
                    {
                        MskFecha[0].Focus();
                        return;
                    }
                    else
                    {
                        strFechaInicial = MskFecha[0].CtlText;
                    }
                    strFechaFinal = ""; //Inicializa las fecha Inicial
                    if (MskFecha[1].Visible)
                    {
                        string tempRefParam = DateTime.Parse(MskFecha[0].defaultText).ToString("yyyy/MM/dd");
                        string tempRefParam2 = DateTime.Parse(MskFecha[0].defaultText).AddMonths(1).ToString("yyyy/MM/dd");
                        if (!FnBolValidaFecha(MskFecha[1], ref tempRefParam, ref tempRefParam2))
                        {
                            MskFecha[1].Focus();
                            return;
                        }
                        else
                        {
                            strFechaFinal = MskFecha[1].CtlText;
                        }
                    }

                    if (CboFecha.SelectedIndex == 0)
                    {
                        strCicloReporte = "C"; //Reporte al corte
                    }
                    else
                    {
                        strCicloReporte = "D"; //Reporte Diario
                    }
                }

                if (ReportesCol.Count == 0)
                {
                    SpdReportes.Visible = true;

                    SpdReportes.Focus();
                    MdlCambioMasivo.MsgInfo("Debe elegir al menos un reporte a procesar");
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                blReportesSeleccionados = false;
                //FrmTuxedo.Enabled = False

                blReportesSeleccionados = ReportesCol.Count > 0;


                if (!blReportesSeleccionados)
                {
                    MdlCambioMasivo.MsgInfo("Debe elegir al menos un reporte a procesar");
                    FrmTuxedo.DefInstance.Enabled = true;
                    return;
                }
                BtnProcesar.Enabled = false;
                BtnDetener.Enabled = true;
                Frm_Local.Enabled = false;
                FrmParReporte.Enabled = false;

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

                    strData = "Select pgs_long_rep from MTCPGS01";
                    strData = strData + " Where pgs_rep_banco = " + CORVAR.igblBanco.ToString();
                    strData = strData + " And pgs_rep_prefijo = " + CORVAR.igblPref.ToString();
                    rsMTCPGS = new ADODB.Recordset();
                    rsMTCPGS.Open(strData, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                    if (rsMTCPGS.EOF)
                    {
                        //La longitud del reporte no se encontro por lo tanto toma el valor por defecto 0
                        lngLongitudRpt = 0;
                    }
                    else
                    {
                        //UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to int.
                        lngLongitudRpt = Convert.ToInt32(MdlCambioMasivo.Nvl(rsMTCPGS.Fields["pgs_long_rep"].Value, 0));
                    }
                    VBSQL.gConn[10].Close();
                }

                //Set objCnnTcpIp = New ClsTcpIp yuria

                for (int intReportes = 1; intReportes <= ReportesCol.Count; intReportes++)
                {
                    //Se conecta con Tuxedo para generar los reportes gerenciales


                    ObjReporteProcesar = (ClsReporteGerencia)ReportesCol[intReportes];
                    SpdReportes.Row = ObjReporteProcesar.Row;
                    SpdReportes.Col = COL_ESTADOREPORTE;
                    TelnetSb.Items[0].Text = "Generando reporte ..." + ObjReporteProcesar.Reporte.ToString();
                    // .Picture = LoadPicture("C:\Archivos de programa\Microsoft Visual Studio\Common\Graphics\Bitmaps\Gauge\horz.bmp")

                    switch (TipoReporte)
                    {
                        case EnTipoReporte.rptGrupo:
                            //Reporte por grupo 
                            strIdEmpresa = VB6.GetItemData(CboEmpresas[0], CboEmpresas[0].SelectedIndex).ToString();  //Se enviará el nombre del grupo cuando el reporte sea por grupo 
                            if (ChkNivel.CheckState == CheckState.Unchecked)
                            {
                                strUnidad = "0";
                                strNivel = "1";
                            }
                            else
                            {
                                strUnidad = "0";
                                strNivel = CboNivel[0].Text.Trim();
                            }

                            break;
                        case EnTipoReporte.rptGrupoEmpresa:
                            //Reporte por grupo-empresa 
                            strIdEmpresa = VB6.GetItemData(CboEmpresas[1], CboEmpresas[1].SelectedIndex).ToString();
                            if (ChkNivel.CheckState == CheckState.Checked)
                            {
                                strUnidad = "0";
                                strNivel = CboNivel[0].Text.Trim();
                            }
                            else
                            {
                                //                        strUnidad = FnUnidadPadreStr(igblPref, igblBanco, CboEmpresas(1).ItemData(CboEmpresas(1).ListIndex), rptGrupoEmpresa, ObjReporteProcesar.Reporte)
                                strNivel = "1";
                            }

                            break;
                        default:
                            //Reporte por grupo-empresa-unidad 
                            strIdEmpresa = VB6.GetItemData(CboEmpresas[1], CboEmpresas[1].SelectedIndex).ToString();
                            strUnidad = VB6.GetItemData(CboEmpresas[2], CboEmpresas[2].SelectedIndex).ToString();
                            strNivel = "1";
                            break;
                    }
                    //###Inicia codigo Yuria
                    Prefijo = CORVAR.igblPref.ToString();
                    Banco = CORVAR.igblBanco.ToString();
                    Empresa = strIdEmpresa;
                    Unidad = strUnidad.Trim();
                    Reporte = ObjReporteProcesar.Reporte.ToString();
                    Frecuencia = ObjReporteProcesar.Frecuencia;
                    LongEmpresa = Formato.igLongitudEmpresa.ToString();
                    LongEjecutivo = Formato.igLongitudEjecutivo.ToString();
                    LongUnidad = "5";
                    LongReporte = lngLongitudRpt.ToString();
                    Por_Grupo = Math.Abs((TipoReporte == EnTipoReporte.rptGrupo) ? -1 : 0).ToString();
                    NivelIni = strNivel;
                    NivelFin = "99";
                    //strCicloReporte = strCicloReporte
                    strFechaIni = strFechaInicial;
                    strFechaFin = strFechaFinal;
                    //''''###ini
                    if (Conversion.Val(Por_Grupo) == 1)
                    {
                        //Determina si el reporte generado es por grupo o por empresa
                        //Por lo que determinará el número de empresa menor para que
                        //el reporte lleve ese nombre

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
                            SqlCmd = new StringBuilder("select distinct emp_num from MTCUNI01 where gpo_num = ");
                            SqlCmd.Append(Empresa + " order by emp_num");
                            rs1 = new ADODB.Recordset();
                            rs1.Open(SqlCmd.ToString(), VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, -1);
                            rs1.MoveFirst();
                            EmpresaMenor = Convert.ToString(rs1.Fields["emp_num"].Value);
                            rs1.Close();
                            rs1 = null;
                            VBSQL.gConn[10].Close();
                        }
                    }
                    else
                    {
                        EmpresaMenor = Empresa;
                    }

                    if (Unidad.Length <= 5)
                    {
                        //Determina que la unidad no exceda del maximo permitido
                        //para poder continuar con el proceso
                        if (strCicloReporte == "C")
                        {
                            strFechaCorte = Strings.Mid(strFechaIni, 1, 2) + Strings.Mid(strFechaIni, 4, 2);
                            if (String.CompareOrdinal(Strings.Mid(strFechaIni, 1, 2), StringsHelper.Format(DateTime.Now.Month, "00")) > 0)
                            {
                                mstrFechaFin = StringsHelper.Format(DateTime.Now.Year - 1, "0000") + "/" + StringsHelper.Format(Strings.Mid(strFechaIni, 1, 2), "00") + "/" + StringsHelper.Format(Strings.Mid(strFechaIni, 4, 2), "00");
                            }
                            else
                            {
                                mstrFechaFin = StringsHelper.Format(DateTime.Now.Year, "0000") + "/" + StringsHelper.Format(Strings.Mid(strFechaIni, 1, 2), "00") + "/" + StringsHelper.Format(Strings.Mid(strFechaIni, 4, 2), "00");
                            }
                            //Regresa el calendario de la fecha calculada un mes
                            //para determinar la fecha inicial
                            mstrFechaIni = DateTime.Parse(mstrFechaFin).AddMonths(-1).ToString("yyyy/MM/dd");
                            mstrFechaIni = DateTime.Parse(mstrFechaIni).AddDays(1).ToString("yyyyMMdd");
                            //Formatea la fecha fin
                            System.DateTime TempDate = DateTime.FromOADate(0);
                            mstrFechaFin = (DateTime.TryParse(mstrFechaFin, out TempDate)) ? TempDate.ToString("yyyyMMdd") : mstrFechaFin;
                        }
                        else
                        {
                            strFechaCorte = "0";
                            System.DateTime TempDate2 = DateTime.FromOADate(0);
                            mstrFechaIni = (DateTime.TryParse(strFechaIni, out TempDate2)) ? TempDate2.ToString("yyyyMMdd") : strFechaIni;
                            System.DateTime TempDate3 = DateTime.FromOADate(0);
                            mstrFechaFin = (DateTime.TryParse(strFechaFin, out TempDate3)) ? TempDate3.ToString("yyyyMMdd") : strFechaFin;
                        }
                        strFecha = DateTime.Now.ToString("yyyyMMdd");
                        if (!Directory.GetCurrentDirectory().EndsWith("\\"))
                        {
                            strNombreArchivoCte = Directory.GetCurrentDirectory() + "\\";
                        }
                        else
                        {
                            strNombreArchivoCte = Directory.GetCurrentDirectory();
                        }
                        //Variable que indica el nombre del reporte generado y es el que enviará al cliente del FTP
                        strNombreArchivoCte = strNombreArchivoCte + strFecha + "." + StringsHelper.Format(Conversion.Val(Unidad), new string('0', Convert.ToInt32(Conversion.Val(LongUnidad)))) + ".rpt" + StringsHelper.Format(Conversion.Val(Reporte), new string('0', Convert.ToInt32(Conversion.Val(LongReporte)))) + ".txt";
                        //Validará que el nombre del archivo generado no exceda del maximo permitido
                        if (strNombreArchivoCte.Length > MAX_LONG_ARCHIVO_DESTINO)
                        {
                            MessageBox.Show("La longitud del archivo excede la longitud", Application.ProductName);
                            //RaiseEvent Error(1, "El nombre del archivo destino excede del maximo permitido:" & MAX_LONG_ARCHIVO_DESTINO)
                            //Exit Function
                        }
                        else
                        {
                            if (FileSystem.Dir(strNombreArchivoCte, FileAttribute.Archive) != "")
                            {
                                //Borra el archivo destino si es que existe
                                File.Delete(strNombreArchivoCte);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La unidad está mal formateada", Application.ProductName);
                        //Exit Function
                    }

                    if (TipoReporte == EnTipoReporte.rptGrupo)
                    {
                        Por_Grupo = "1";
                        Grupo = strIdEmpresa;
                        Empresa = "0";
                    }
                    else
                    {
                        Grupo = "0";
                    }

                    //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected.
                    if (Convert.IsDBNull(Unidad) || Unidad == "" || Unidad == "0")
                    {
                        Unidad = "NULL";
                    }
                    else
                    {
                        Unidad = "'" + Unidad + "'";
                    }

                    estadoProc = 0;

                    switch (Reporte)
                    {
                        case "13":
                            CORVAR.pszgblsql = "exec sp_ObtenDatosRep13 " + Prefijo + "," + Banco + "," + Empresa + "," + Por_Grupo + "," + Grupo + ",'" + strFecha + "'";
                            break;
                        case "14":
                            CORVAR.pszgblsql = "exec sp_ObtenDatosRep14 " + Prefijo + "," + Banco + "," + Empresa + "," + Por_Grupo + "," + Grupo + "," + Unidad + ",'" + strFecha + "'";
                            break;
                        case "18":
                            CORVAR.pszgblsql = "exec sp_ObtenDatosRep18 " + Prefijo + "," + Banco + "," + Empresa + ",0," + Por_Grupo + "," + Grupo + "," + Unidad + ",'" + strFecha + "'";
                            break;
                        case "22":
                            CORVAR.pszgblsql = "exec sp_ObtenDatosRep22 " + Prefijo + "," + Banco + "," + Empresa + ",0," + Por_Grupo + "," + Grupo + "," + Unidad + ",'" + strFechaCorte + "','" + strFecha + "'";
                            break;
                        case "24":
                            CORVAR.pszgblsql = "exec sp_ObtenDatosRep24 " + Prefijo + "," + Banco + "," + Empresa + ",0," + Por_Grupo + "," + Grupo + "," + Unidad + ",'" + mstrFechaIni + "','" + mstrFechaFin + "','" + strFechaCorte + "','" + strFecha + "'";
                            break;
                        case "25":
                        case "26":
                            if (Double.Parse(Reporte) == 26)
                            {
                                mstrFechaIni = "00000000";
                                mstrFechaFin = "00000000";
                            }
                            CORVAR.pszgblsql = "exec sp_ObtenDatosRep26 " + Prefijo + "," + Banco + "," + Empresa + "," + Por_Grupo + "," + Grupo + "," + Unidad + ",'" + mstrFechaIni + "','" + mstrFechaFin + "','" + strFechaCorte + "','" + strFecha + "'";
                            break;
                        default:
                            estadoProc = 3;
                            CORVAR.pszgblsql = " ";
                            break;
                    }

                    if (estadoProc == 0)
                    {
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
                            adorst = new ADODB.Recordset();
                            adorst.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, -1);

                            if (adorst.State == 1)
                            {
                                if (!adorst.BOF && !adorst.EOF)
                                {
                                    intFile = FileSystem.FreeFile();
                                    strfile = strNombreArchivoCte;
                                    FileSystem.FileOpen(intFile, strfile, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                                    while (!adorst.EOF)
                                    {

                                        StrCadena = Convert.ToString(adorst.Fields["detalle"].Value);
                                        FileSystem.PrintLine(intFile, StrCadena);
                                        adorst.MoveNext();
                                    }
                                    FileSystem.FileClose(intFile);
                                    estadoProc = 0;
                                }
                                else
                                {
                                    estadoProc = 1;
                                }
                            }
                            else
                            {
                                estadoProc = 2;
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
                    }
                    //        If ((Reporte = 13) Or _
                    //'            (Reporte = 14) Or _
                    //'            (Reporte = 24) Or _
                    //'            (Reporte = 26)) Then
                    //             mstrFechaIni = "00000000"
                    //             mstrFechaFin = "00000000"
                    //             datosRep$ = Reporte & " Rep" & Reporte & " " & strFecha & " " & Prefijo & " " & Banco & " " & Empresa & " " & Unidad & " " & mstrFechaIni & " " & mstrFechaFin & " " & strFechaCorte & " " & Nvl(NivelIni, "0") & " " & Nvl(NivelFin, "0") & " " & "file_c.tmp" & " " & Por_Grupo    'ultimo dato se Subtotales
                    //        End If
                    //        If ((Reporte = 15) Or _
                    //'            (Reporte = 16)) Then
                    //             strFechaCorte = "0000"
                    //             datosRep$ = Reporte & " Rep" & Reporte & " " & strFecha & " " & Prefijo & " " & Banco & " " & Empresa & " " & Unidad & " " & mstrFechaIni & " " & mstrFechaFin & " " & Nvl(NivelIni, "0") & " " & Nvl(NivelFin, "0") & " " & "file_c.tmp" & " " & Por_Grupo    'ultimo dato se Subtotales
                    //        End If
                    //        If ((Reporte = 23) Or _
                    //'            (Reporte = 25)) Then
                    //             strFechaCorte = "0000"
                    //             datosRep$ = Reporte & " Rep" & Reporte & " " & strFecha & " " & Prefijo & " " & Banco & " " & Empresa & " " & Unidad & " " & mstrFechaIni & " " & mstrFechaFin & " " & strFechaCorte & " " & Nvl(NivelIni, "0") & " " & Nvl(NivelFin, "0") & " " & "file_c.tmp" & " " & Por_Grupo    'ultimo dato se Subtotales
                    //        End If
                    //        If ((Reporte = 18) Or _
                    //'            (Reporte = 20) Or _
                    //'            (Reporte = 22)) Then
                    //             mstrFechaIni = "00000000"
                    //             mstrFechaFin = "00000000"
                    //             datosRep$ = Reporte & " Rep" & Reporte & " " & strFecha & " " & Prefijo & " " & Banco & " " & Empresa & " " & Unidad & " " & strFechaCorte & " " & Nvl(NivelIni, "0") & " " & Nvl(NivelFin, "0") & " " & "file_c.tmp" & " " & Por_Grupo & " " & "0"
                    //MsgBox (datosRep$)
                    //        End If
                    //        Inicia_VarEnv
                    //        Conecta_Tuxedo
                    //        reserva_libera 2
                    //        estadoProc = Envia(datosRep$, strNombreArchivoCte)
                    //        Desconecta_Tuxedo


                    strDescEstadoReporte = "Error Desconocido";
                    if (estadoProc == 0)
                    {
                        strDescEstadoReporte = "Reporte Exitoso";
                    }
                    if (estadoProc == 1)
                    {
                        strDescEstadoReporte = "Reporte Fallo";
                    }
                    if (estadoProc == 2)
                    {
                        strDescEstadoReporte = "Sin Datos";
                    }
                    if (estadoProc == 3)
                    {
                        strDescEstadoReporte = "Reporte No Existe";
                    }
                    SpdReportes.Col2 = SpdReportes.Col;
                    SpdReportes.Row2 = SpdReportes.Row;
                    SpdReportes.Protect = false;
                    SpdReportes.Lock = false;
                    SpdReportes.Value = strDescEstadoReporte;
                }
                //Bloquea las celdas que no son editables

                SpdReportes.Col = 1;
                SpdReportes.Row = -1;
                SpdReportes.Col2 = 3;
                SpdReportes.Row2 = -1;
                SpdReportes.Protect = true;
                SpdReportes.Lock = true;
                DrvLocal_SelectedIndexChanged(DrvLocal, new EventArgs());
                MdlCambioMasivo.MsgInfo("Proceso terminado");


                BtnProcesar.Enabled = true;
                BtnDetener.Enabled = false;
                Frm_Local.Enabled = true;
                FrmParReporte.Enabled = true;
                //Set objCnnTcpIp = Nothing yuria
                //Set objConexionTuxedo = Nothing   yuria
                this.Cursor = Cursors.Default;
                Application.DoEvents();
            }
            catch
            {

                string tempRefParam4 = "Tarjeta Corporativa.-FrmTuxedo.-BtnProcesar_Click";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam4))
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    //throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    BtnProcesar.Enabled = true;
                    BtnDetener.Enabled = false;
                    Frm_Local.Enabled = true;
                    FrmTipoReporte.Enabled = true;
                }

                if (rsMTCPGS.State != 0)
                {
                    rsMTCPGS.Close();
                }

                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }
            }


        }

        private void BtnSalir_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void CboEmpresas_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(CboEmpresas, eventSender);
            int intNoEmpresa = 0;
            int intNoGrupo = 0;
            SpdReportes.MaxRows = 0;
            //SpdReportes.MaxRows = 1

            switch (Index)
            {
                case 0:
                    //Lista de grupo 

                    if (CboEmpresas[Index].SelectedIndex > -1)
                    {
                        //Acaba de elegir un elmento de la lista de grupos
                        //Cuando la opcion es de grupo o grupo empresa genera la lista
                        if (!OptReporte[0].Checked)
                        {
                            //El tipo de reporte es por grupo-empresa o grupo-empresa-unidad
                            //por lo tanto determina la lista de empresas

                            PrListaEmpresas(VB6.GetItemData(CboEmpresas[Index], CboEmpresas[Index].SelectedIndex));
                        }
                        else
                        {
                           /* if (!FnVerificaEstructruraJerquiaBl(VB6.GetItemData(CboEmpresas[Index], CboEmpresas[Index].SelectedIndex)))
                            {
                                MdlCambioMasivo.MsgInfo("Existen unidades que no han sido dadas de alta  en todas las empresas del grupo." +
                                                        "\r" + "Revise la estructura de las unidades antes de continuar");
                                return;
                            }*/

                        }

                        if (!OptReporte[2].Checked)
                        {
                            //El tipo de reporte es grupo o grupo-empresa
                            //por lo tanto debe verificar los niveles del reporte
                            intNoGrupo = VB6.GetItemData(CboEmpresas[0], CboEmpresas[0].SelectedIndex);
                            intNoEmpresa = -1;

                            if (ChkNivel.CheckState == CheckState.Checked)
                            {
                                //El reporte incluye niveles
                                PrListaNiveles(CboNivel[0], CORVAR.igblPref, CORVAR.igblBanco, intNoGrupo, intNoEmpresa, -1);
                            }
                            else
                            {
                                //CboNivel(1).Clear
                                if (OptReporte[0].Checked)
                                {
                                    //El reporte es de grupo por lo tanto no se necesita la empresa
                                    int tempRefParam = 0;
                                    PrListaReportes(CORVAR.igblPref, CORVAR.igblBanco, -1, 0, intNoGrupo, ref tempRefParam);
                                }

                            }
                        }


                    }
                    else
                    {
                        CboEmpresas[1].Items.Clear();
                        CboEmpresas[1].SelectedIndex = -1;
                    }
                    break;
                case 1:
                    //Lista de Empresas 

                    if (CboEmpresas[1].SelectedIndex > -1 && CboEmpresas[0].SelectedIndex > -1)
                    {
                        if (OptReporte[2].Checked)
                        {
                            //El reporte a generar es por grupo - empresa - unidad
                            PrListaUnidades(CORVAR.igblPref, CORVAR.igblBanco, VB6.GetItemData(CboEmpresas[1], CboEmpresas[1].SelectedIndex), VB6.GetItemData(CboEmpresas[0], CboEmpresas[0].SelectedIndex));
                        }
                        else
                        {
                            CboEmpresas[2].SelectedIndex = -1;
                            //El tipo de reporte es de grupo o grupo empresa
                            if (ChkNivel.CheckState == CheckState.Checked)
                            {
                                intNoGrupo = VB6.GetItemData(CboEmpresas[0], CboEmpresas[0].SelectedIndex);
                                intNoEmpresa = VB6.GetItemData(CboEmpresas[1], CboEmpresas[1].SelectedIndex);
                                PrListaNiveles(CboNivel[0], CORVAR.igblPref, CORVAR.igblBanco, intNoGrupo, intNoEmpresa, -1);
                            }
                            else
                            {
                                //CboNivel(1).Clear
                                intNoGrupo = VB6.GetItemData(CboEmpresas[0], CboEmpresas[0].SelectedIndex);
                                intNoEmpresa = VB6.GetItemData(CboEmpresas[1], CboEmpresas[1].SelectedIndex);
                                int tempRefParam2 = 0;
                                PrListaReportes(CORVAR.igblPref, CORVAR.igblBanco, intNoEmpresa, 0, intNoGrupo, ref tempRefParam2);

                            }
                        }

                    }
                    break;
                case 2:
                    //Lista de Unidades 
                    if (CboEmpresas[Index].SelectedIndex > -1)
                    {
                        PrListaReportes(CORVAR.igblPref, CORVAR.igblBanco, VB6.GetItemData(CboEmpresas[1], CboEmpresas[1].SelectedIndex), VB6.GetItemData(CboEmpresas[2], CboEmpresas[2].SelectedIndex));
                    }
                    else
                    {
                        SpdReportes.MaxRows = 0;
                        // SpdReportes.MaxRows = 1
                    }
                    break;
            }

        }


        private void CboFecha_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            string[,] AstrFecha = ArraysHelper.InitializeArray<string[,]>(new int[] { 3, 4 }, new int[] { 0, 0 });
            AstrFecha[0, 0] = "Fecha de Corte (MM/DD) "; //Etiqueta Fecha Inicial corte
            AstrFecha[0, 1] = "##/##"; //Formato de captura Corte
            AstrFecha[0, 2] = "mm/dd"; //Formato de fecha Corte
            AstrFecha[0, 3] = "m"; //Tiempo a restar a la fecha actual Corte
            AstrFecha[1, 0] = "Fecha Inicial (YYYY/MM/DD) "; //Etiqueta Fecha Incial Diario
            AstrFecha[1, 1] = "####/##/##"; //Formato de Cmptura Diario
            AstrFecha[1, 2] = "yyyy/mm/dd"; //Formato de Fecha
            AstrFecha[1, 3] = "d"; //Tiempo
            SpdReportes.MaxRows = 0;
            if (CboFecha.SelectedIndex > -1)
            {
                LblFecha[0].Text = AstrFecha[CboFecha.SelectedIndex, 0];

                MskFecha[0].Mask = AstrFecha[CboFecha.SelectedIndex, 1];
                MskFecha[0].CtlText = StringsHelper.Format(DateAndTime.DateAdd(AstrFecha[CboFecha.SelectedIndex, 3], -1, DateTime.Now), AstrFecha[CboFecha.SelectedIndex, 2]);
                MskFecha[1].Mask = AstrFecha[CboFecha.SelectedIndex, 1];
                MskFecha[1].CtlText = StringsHelper.Format(DateAndTime.DateAdd(AstrFecha[CboFecha.SelectedIndex, 3], -1, DateTime.Now), AstrFecha[CboFecha.SelectedIndex, 2]);
                //Ha elegido reporte diario
                LblFecha[1].Visible = CboFecha.SelectedIndex == 1;
                MskFecha[1].Visible = CboFecha.SelectedIndex == 1;
            }
            else
            {
                MdlCambioMasivo.MsgInfo("Selección de tipo de reporte invalido");
                CboFecha.Focus();

            }



        }

        private void CboNivel_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(CboNivel, eventSender);
            //Determina la lista de niveles
            int intNoEmpresa = 0;
            int intNoGrupo = 0;
            if (Index == 0 && CboNivel[0].SelectedIndex > -1)
            {
                intNoGrupo = VB6.GetItemData(CboEmpresas[0], CboEmpresas[0].SelectedIndex);
                if (CboEmpresas[1].SelectedIndex > -1)
                {
                    intNoEmpresa = VB6.GetItemData(CboEmpresas[1], CboEmpresas[1].SelectedIndex);
                }
                else
                {
                    intNoEmpresa = -1;
                }
                // Call PrListaNiveles(CboNivel(1), igblPref, igblBanco, intNoGrupo, intNoEmpresa, CboNivel(0).Text)
                //AIS-Bug 4213 fsaborio
                int tempRefParam = Artinsoft.VB6.Utils.StringsHelper.IntValue(CboNivel[0].Text);
                PrListaReportes(CORVAR.igblPref, CORVAR.igblBanco, intNoEmpresa, 0, intNoGrupo, ref tempRefParam);
            }
            else if (Index == 0)
            {

            }



        }

        private void ChkNivel_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            CboNivel[0].SelectedIndex = -1;
            // CboNivel(1).ListIndex = -1
            CboNivel[0].Enabled = ChkNivel.CheckState == CheckState.Checked;
            CboNivel[0].SelectedIndex = -1;
            // CboNivel(1).Enabled = ChkNivel.Value = 1
            // CboNivel(1).ListIndex = -1
            //AIS-1134 NGONZALEZ
            CboEmpresas_SelectedIndexChanged(CboEmpresas[0], new EventArgs());
        }

       /* private void BtnDetener_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            if (objConexionTuxedo != null)
            {
                if (MdlCambioMasivo.FnMsgYesno("Está Seguro de detener la generación actual ? "))
                {
                    objConexionTuxedo.PrDetenerReporte();
                }
            }
        }
        //28/09/09
        */

        private void DirLocal_Change(Object eventSender, EventArgs eventArgs)
        {
            FilLocal.Path = DirLocal.Path;
            FilLocal.Refresh();
            Directory.SetCurrentDirectory(FilLocal.Path);
            Application.DoEvents();
        }

        private void DrvLocal_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            FileSystem.ChDrive(DrvLocal.Drive);
            DirLocal.Path = DrvLocal.Drive;
            DirLocal.Refresh();
            FilLocal.Refresh();
        }


        private void FilLocal_DoubleClick(Object eventSender, EventArgs eventArgs)
        {
            string strDirAcctual = String.Empty;
            try
            {
                strDirAcctual = (!FilLocal.Path.EndsWith("\\")) ? FilLocal.Path + "\\" : FilLocal.Path;
                //UPGRADE_WARNING: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo
                ProcessStartInfo startInfo = new ProcessStartInfo("Notepad.exe", strDirAcctual + FilLocal.FileName);
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(startInfo);
            }
            catch
            {

                if (MdlCambioMasivo.fnGetError())
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            //ClsTcpIp objTcpIp = null;
            string strDirActual = String.Empty;

            //    Call Conectar 'Llama la rutina de conexion
            ADODB.Recordset rsGrupos = null;
            string strSql = String.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                //Carga los mensajes existentes en el socket
                ASEstadosSocket[0] = "Cerrado";
                ASEstadosSocket[1] = "Socket Abierto"; //sckOpen 1 Open
                ASEstadosSocket[2] = "Escuchando"; //sckListening 2 Listening
                ASEstadosSocket[3] = "Solicitando Conection "; //sckConnectionPending  3 Connection pending
                ASEstadosSocket[4] = "Resolviendo Host"; //sckResolvingHost  4 Resolving host
                ASEstadosSocket[5] = "Host Resuelto"; //sckHostResolved  5 Host resolved
                ASEstadosSocket[6] = "Conectando"; //sckConnecting  6 Connecting
                ASEstadosSocket[7] = "Conectado"; //sckConnected  7 Connected
                ASEstadosSocket[8] = "Cerrando la sesion"; //sckClosing  8 Peer is closing the connection
                ASEstadosSocket[9] = "Error en el Socket"; //sckError  9 Error
                SpdReportes.MaxCols = 5;
                SpdReportes.Col = 1;
                SpdReportes.Row = 0;
                SpdReportes.Text = "Reporte";
                SpdReportes.Col = 2;
                SpdReportes.Text = "Calificado";
                SpdReportes.Col = 3;
                SpdReportes.Text = "Frecuencia";
                SpdReportes.set_ColWidth(3, 10 * 9);
                SpdReportes.Col = 4;
                SpdReportes.Text = "Generar";
                SpdReportes.Col = 5;
                SpdReportes.set_ColWidth(5, 30 * 2);
                SpdReportes.Text = "Estado";
                this.Cursor = Cursors.Default;
                OptReporte[0].Checked = true;
                CboFecha.Items.Add("Reporte Mensual");
                CboFecha.Items.Add("Reporte Diario");
                CboFecha.SelectedIndex = 0;
                this.Height = (int)VB6.TwipsToPixelsY(9400);
                this.Width = (int)VB6.TwipsToPixelsX(11205);
                this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
                this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

                //objTcpIp = new ClsTcpIp(); 28/09/09
                //strDirActual = objTcpIp.DirLocalCte;
                strDirActual = mdlParametros.sgPathRepEmpresas;
                Directory.SetCurrentDirectory(strDirActual);
                DrvLocal.Refresh();
                if (!Directory.Exists(strDirActual))
                {
                    Directory.CreateDirectory(strDirActual);
                }
                DirLocal.Path = strDirActual;
                DirLocal.Refresh();
               // objTcpIp = null;


                //PanToolBar.Width = (int) this.Width;
                //PanToolBar.BackColor = this.BackColor;

                Application.DoEvents();
            }
            catch
            {

                if (Information.Err().Number == 76)
                {
                    MdlCambioMasivo.MsgInfo("El directorio: " + "\r\n" + strDirActual + "\r\n" + "No pudo ser creado favor de crearlo manualmente");
                }
                else
                {

                    if (MdlCambioMasivo.fnGetError())
                    {
                        //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                        throw new Exception("Migration Exception: 'Resume' not supported");
                    }
                    else
                    {
                        rsGrupos = null;
                    }
                }
            }
        }
        private bool closed = false;

        private void FrmTuxedo_Closed(Object eventSender, EventArgs eventArgs)
        {
            //If Not (objConexionTuxedo Is Nothing) Then yuria
            //   If objConexionTuxedo.Estado = EnEstadoProcesando Then
            //         If FnMsgYesno("Hay reportes generandose en este momento " & vbCrLf & _
            //'                      "¿ Está Seguro de detener la generación actual ? ") Then
            //                      objConexionTuxedo.PrDetenerReporte
            //         Else
            //             Cancel = True
            //         End If
            //    End If
            // End If
            closed = true;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        protected bool formIsClosing()
        {
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
            for (int i = 2; i < stackTrace.FrameCount; i++)
            {
                if (stackTrace.GetFrame(i).GetMethod().Name == "WmClose")
                {
                    return true;
                }
            }
            return false;
        }

        private void MskFecha_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            if (!formIsClosing())
            {

                bool Cancel = eventArgs.Cancel;
                int Index = Array.IndexOf(MskFecha, eventSender);
                try
                {
                    switch (Index)
                    {
                        case 0:
                            Cancel = !FnBolValidaFecha(MskFecha[Index]);
                            break;
                        case 1:
                            string tempRefParam = DateTime.Parse(MskFecha[0].defaultText).ToString("yyyy/MM/dd");
                            string tempRefParam2 = DateTime.Parse(MskFecha[0].defaultText).AddMonths(1).ToString("yyyy/MM/dd");
                            Cancel = !FnBolValidaFecha(MskFecha[Index], ref tempRefParam, ref tempRefParam2);
                            break;
                    }
                }
                catch
                {

                    string tempRefParam3 = "MskFecha_Validate";
                    if (MdlCambioMasivo.fnGetError(ref tempRefParam3))
                    {
                        //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                        throw new Exception("Migration Exception: 'Resume' not supported");
                    }

                    eventArgs.Cancel = Cancel;
                }

                eventArgs.Cancel = Cancel;
            }
        }
        public bool FnBolValidaFecha(AxMSMask.AxMaskEdBox MskFecha, ref  string pStrFechaMinima, ref  string pStrFechaMaxima)
        {
            bool result = false;
            string strFecha = String.Empty;
            string strFechaAct = String.Empty;
            int intDia = 0;
            int intMes = 0;
            int intAnio = 0;
            string strSql = String.Empty;
            ADODB.Recordset rsDiaCorte = null;
            try
            {
                if (false)
                {
                    pStrFechaMinima = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
                }
                else
                {
                    //UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to DateTime.
                    pStrFechaMinima = Convert.ToDateTime(MdlCambioMasivo.Nvl(pStrFechaMinima, DateTime.Now.AddYears(-1))).ToString("yyyy/MM/dd");
                }

                if (false)
                {
                    pStrFechaMaxima = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
                }
                else
                {
                    //UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to DateTime.
                    pStrFechaMaxima = Convert.ToDateTime(MdlCambioMasivo.Nvl(pStrFechaMaxima, DateTime.Now.AddDays(-1))).ToString("yyyy/MM/dd");
                }



                result = false;

                strFecha = MskFecha.CtlText;
                if (CboFecha.SelectedIndex == 0)
                {
                    double dbNumericTemp2 = 0;
                    double dbNumericTemp = 0;
                    if (Double.TryParse(Strings.Mid(strFecha, 1, 2), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) && Double.TryParse(Strings.Mid(strFecha, 4, 2), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
                    {
                        //Los valores son candidatos a fecha
                        intMes = StringsHelper.IntValue(Strings.Mid(strFecha, 1, 2));
                        intDia = StringsHelper.IntValue(Strings.Mid(strFecha, 4, 2));
                        if (intMes > DateTime.Now.Month)
                        {
                            intAnio = DateTime.Now.Year - 1;
                            //Cuando el mes de corte sea mayor que el actual considerará como el año a validar el año anterior
                        }
                        else
                        {
                            intAnio = DateTime.Now.Year;
                            //En caso contrario el mes a considerar será el del año actual
                        }
                    }
                    else
                    {
                        MdlCambioMasivo.MsgInfo("La fecha suministrada es invalida");
                        return result;
                    }
                }
                else
                {
                    double dbNumericTemp5 = 0;
                    double dbNumericTemp4 = 0;
                    double dbNumericTemp3 = 0;
                    if (Double.TryParse(Strings.Mid(strFecha, 1, 4), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3) && Double.TryParse(Strings.Mid(strFecha, 6, 2), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp4) && Double.TryParse(Strings.Mid(strFecha, 9, 2), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp5))
                    {
                        //Los valores son candidatos a fecha
                        intAnio = StringsHelper.IntValue(Strings.Mid(strFecha, 1, 4));
                        intMes = StringsHelper.IntValue(Strings.Mid(strFecha, 6, 2));
                        intDia = StringsHelper.IntValue(Strings.Mid(strFecha, 9, 2));
                    }
                    else
                    {
                        MdlCambioMasivo.MsgInfo("La fecha suministrada es invalida");
                        return result;
                    }

                }

                if (intAnio < DateTime.Now.Year - 1 || intAnio > DateTime.Now.Year)
                {
                    MdlCambioMasivo.MsgInfo("El Año Suministrado es invalido");
                    return result;
                }

                if (intMes < 1 || intMes > 12)
                {
                    MdlCambioMasivo.MsgInfo("El Mes Suministrado es Invalido");
                    return result;
                }

                if (intDia < 1 || intDia > 31)
                {
                    MdlCambioMasivo.MsgInfo("El dia suministrado es invalido");
                    return result;
                }
                else
                {
                    if (CboFecha.SelectedIndex == 0)
                    {
                        //El reporte es por corte por lo tanto validará si las empresas tienen ese dia de corte valido
                        strSql = "Select Count(emp_dia_corte) as DiasCorte";
                        strSql = strSql + " From MTCEMP01 ";
                        strSql = strSql + " Where emp_dia_corte = " + intDia.ToString();
                        strSql = strSql + " And eje_prefijo = " + CORVAR.igblPref.ToString();
                        strSql = strSql + " And gpo_banco =  " + CORVAR.igblBanco.ToString();
                        strSql = strSql + " Group By eje_prefijo,gpo_banco";

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

                            rsDiaCorte = new ADODB.Recordset();
                            rsDiaCorte.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                            if (rsDiaCorte.BOF)
                            {
                                MdlCambioMasivo.MsgInfo("El dia de corte es invalido");
                                rsDiaCorte.Close();
                                rsDiaCorte = null;
                                return result;
                            }
                            else
                            {
                                //UPGRADE_WARNING: (1068) Nvl(rsDiaCorte!DiasCorte, 0) of type Variant is being forced to double.
                                if (Convert.ToDouble(MdlCambioMasivo.Nvl(rsDiaCorte.Fields["DiasCorte"].Value, 0)) <= 0)
                                {
                                    MdlCambioMasivo.MsgInfo("El Dia de Corte es invalido");
                                    rsDiaCorte.Close();
                                    rsDiaCorte = null;
                                    return result;
                                }
                            }
                            VBSQL.gConn[10].Close();
                        }
                    }
                }

                System.DateTime TempDate2 = DateTime.FromOADate(0);
                if (String.CompareOrdinal(StringsHelper.Format(intAnio, "00") + StringsHelper.Format(intMes, "00") + StringsHelper.Format(intDia, "00"), (DateTime.TryParse(pStrFechaMaxima, out TempDate2)) ? TempDate2.ToString("yyyyMMdd") : pStrFechaMaxima) > 0)
                {
                    System.DateTime TempDate = DateTime.FromOADate(0);
                    MdlCambioMasivo.MsgInfo("La fecha del reporte no puede ser mayor a :" + ((DateTime.TryParse(pStrFechaMaxima, out TempDate)) ? TempDate.ToString("yyyy/MM/dd") : pStrFechaMaxima));
                    return result;
                }

                System.DateTime TempDate4 = DateTime.FromOADate(0);
                if (String.CompareOrdinal(StringsHelper.Format(intAnio, "00") + StringsHelper.Format(intMes, "00") + StringsHelper.Format(intDia, "00"), (DateTime.TryParse(pStrFechaMinima, out TempDate4)) ? TempDate4.ToString("yyyyMMdd") : pStrFechaMinima) < 0)
                {
                    System.DateTime TempDate3 = DateTime.FromOADate(0);
                    MdlCambioMasivo.MsgInfo("La fecha del reporte no puede ser Menor a : " + ((DateTime.TryParse(pStrFechaMinima, out TempDate3)) ? TempDate3.ToString("yyyy/MM/dd") : pStrFechaMinima));
                    return result;
                }


                return true;
            }
            catch
            {


                string tempRefParam = "FnBolFecha";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }

                if (rsDiaCorte.State != 0)
                {
                    rsDiaCorte.Close();
                }

                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }
            }

            return result;
        }

        public bool FnBolValidaFecha(AxMSMask.AxMaskEdBox MskFecha, ref  string pStrFechaMinima)
        {
            string tempRefParam = "";
            return FnBolValidaFecha(MskFecha, ref pStrFechaMinima, ref tempRefParam);
        }

        public bool FnBolValidaFecha(AxMSMask.AxMaskEdBox MskFecha)
        {
            string tempRefParam2 = "";
            string tempRefParam3 = "";
            return FnBolValidaFecha(MskFecha, ref tempRefParam2, ref tempRefParam3);
        }

        private void objConexionTuxedo_Error(ref  int NumeroError, ref  string Descripcion)
        {
            MdlCambioMasivo.MsgError(" Error: " + NumeroError.ToString() + "\r\n" + "Decripción:" + Descripcion);

        }

        private bool isInitializingComponent;
        private void OptReporte_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (((RadioButton)eventSender).Checked)
            {
                int Index = Array.IndexOf(OptReporte, eventSender);
                ChkNivel.CheckState = CheckState.Unchecked;

                ChkNivel.Enabled = Index != 2;
                //  CboEmpresas(3).Enabled = Index = 2 'Cuando da click en el tercer option button se activas
                //el combo de unidades
                CboEmpresas[2].Enabled = Index == 2;
                CboEmpresas[1].Enabled = Index != 0;
                SpdReportes.MaxRows = 0;
                //SpdReportes.MaxRows = 1
                CboEmpresas[0].SelectedIndex = -1;
                CboEmpresas[1].SelectedIndex = -1;
                CboEmpresas[2].SelectedIndex = -1;

                PrListaGrupos(Index != 0);
                switch (Index)
                {
                    case 0:
                        TipoReporte = FrmTuxedo.EnTipoReporte.rptGrupo;
                        break;
                    case 1:
                        TipoReporte = FrmTuxedo.EnTipoReporte.rptGrupoEmpresa;
                        break;
                    case 2:
                        TipoReporte = FrmTuxedo.EnTipoReporte.RptGrupoEmpresaUnidad;
                        break;
                }
            }
        }

       

        //UPGRADE_NOTE: (7001) The following declaration (SSCommand1_Click) seems to be dead code
        //private void  SSCommand1_Click()
        //{
        //
        //}

        private void TelnetWS_CloseEvent(Object eventSender, EventArgs eventArgs)
        {
            TelnetSb.Items[0].Text = "Desconectado";
            TelnetWS.Tag = DESCONECTADO;
            //    MsgInfo "Se perdio la conexion con el host"
        }

        private void TelnetWS_ConnectEvent(Object eventSender, EventArgs eventArgs)
        {
            TelnetSb.Items[0].Text = "Conectado a : " + TelnetWS.RemoteHost;
        }

        private void TelnetWS_DataArrival(Object eventSender, AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent eventArgs)
        {
            string strdat = String.Empty;
            int X = 0;
            try
            {

                //Sale de la rutina para detener el proceso
                //debido a que el password es incorrecto
                if (TelnetWS.CtlState != ((short)MSWinsockLib.StateConstants.sckConnected))
                {
                    return;
                }
                object tempRefParam = strdat;
                TelnetWS.GetData(ref tempRefParam, Type.Missing, Type.Missing);
                if (strdat == Strings.Chr(255).ToString() + Strings.Chr(253).ToString() + Strings.Chr(37).ToString() + Strings.Chr(255).ToString() + Strings.Chr(251).ToString() + Strings.Chr(1).ToString() + Strings.Chr(255).ToString() + Strings.Chr(253).ToString() + Strings.Chr(3).ToString() + Strings.Chr(255).ToString() + Strings.Chr(253).ToString() + Strings.Chr(31).ToString() + Strings.Chr(255).ToString() + Strings.Chr(253).ToString() + Strings.Chr(0).ToString() + Strings.Chr(255).ToString() + Strings.Chr(251).ToString() + Strings.Chr(0).ToString())
                {
                    TelnetWS.SendData(Strings.Chr(255).ToString() + Strings.Chr(252).ToString() + Strings.Chr(37).ToString());
                    TelnetWS.Tag = INICIANDO_NEGOCIACION;
                }
                else if (strdat == Strings.Chr(255).ToString() + Strings.Chr(253).ToString() + Strings.Chr(36).ToString())
                {
                    TelnetWS.Tag = INICIANDO_NEGOCIACION;
                    TelnetWS.SendData(Strings.Chr(255).ToString() + Strings.Chr(252).ToString() + Strings.Chr(36).ToString());

                }
                else if (strdat == Strings.Chr(255).ToString() + Strings.Chr(251).ToString() + Strings.Chr(36).ToString())
                {
                    TelnetWS.Tag = INICIANDO_NEGOCIACION;
                    TelnetWS.SendData(Strings.Chr(255).ToString() + Strings.Chr(252).ToString() + Strings.Chr(36).ToString());
                }
                else if (strdat == Strings.Chr(255).ToString() + Strings.Chr(253).ToString() + Strings.Chr(24).ToString())
                {
                    TelnetWS.Tag = INICIANDO_NEGOCIACION;
                    TelnetWS.SendData(Strings.Chr(255).ToString() + Strings.Chr(251).ToString() + Strings.Chr(24).ToString());

                }
                else if (strdat == Strings.Chr(255).ToString() + Strings.Chr(250).ToString() + Strings.Chr(24).ToString() + Strings.Chr(1).ToString() + Strings.Chr(255).ToString() + Strings.Chr(240).ToString())
                {
                    TelnetWS.Tag = INICIANDO_NEGOCIACION;
                    TelnetWS.SendData(Strings.Chr(255).ToString() + Strings.Chr(250).ToString() + Strings.Chr(24).ToString() + Strings.Chr(0).ToString() + "DEC-VT100" + Strings.Chr(255).ToString() + Strings.Chr(240).ToString());
                }
                else if (strdat == Strings.Chr(255).ToString() + Strings.Chr(253).ToString() + Strings.Chr(32).ToString())
                {
                    TelnetWS.Tag = INICIANDO_NEGOCIACION;
                    TelnetWS.SendData(Strings.Chr(255).ToString() + Strings.Chr(252).ToString() + Strings.Chr(32).ToString());
                }
                else
                {

                    if (strdat.IndexOf("login:", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        if (TelnetWS.Tag.ToString() == INICIANDO_NEGOCIACION)
                        { //Es la primer vez que solicita el usuario
                            TelnetWS.Tag = SOLICITA_LOGIN; //Evita envio descontrolado de datos hacia el servidor de telnet
                            //.SendData ObjCnnTelnet.User + vbCrLf
                        }
                        else
                        {
                            TelnetWS.SendData(""); //Envia una cadena de caracteres para detener la llegada de datos
                            //Descontrolada
                            if (TelnetWS.Tag.ToString() == CONEXION_CANCELADA)
                            {
                                TelnetWS.Close();
                                Application.DoEvents();
                            }
                            else
                            {
                                TelnetWS.Tag = SOLICITA_LOGIN;
                                TelnetWS.SendData(""); //Envia una cadena en blanco para evitar recepcion descontrolada de datos
                                TelnetWS.Close();
                                MdlCambioMasivo.MsgError("El usuario o password es incorrecto." + "\r\n" +
                                                         "\r\n" + "Introducir una contraseña incorrecta puede " +
                                                         "ocasionar el bloqueo de su cuenta");


                                //ObjCnnTelnet.PrPreguntaPassword "Usuario o Password Incorrecto." & Chr(13) & _
                                //'                           "Reescribir un password incorrecto" & _
                                //'                           Chr(13) & "puede ocasionar el bloqueo de su cuenta."
                                //If ObjCnnTelnet.Password <> "" And .state = 7 Then
                                //Verifica que la conexion siga activa debido
                                //a que el usuario puede tardar un tiempo infinito en proporcionar el password
                                //    .Tag = SOLICITA_LOGIN   'Actualiza la bandera para indicar que el siguiente dato esperado es el password
                                //    .SendData ObjCnnTelnet.User & vbCrLf  'Manda nuevamente el usuario
                                //Else
                                //    .Tag = CONEXION_CANCELADA
                                //    .Close
                                //End If
                            }
                        }

                    }
                    else if (strdat.IndexOf("password:", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        if (TelnetWS.Tag.ToString() == SOLICITA_LOGIN)
                        { //Envio el password por primera vez
                            TelnetWS.Tag = SOLICITA_PWD; //Password Enviado
                            //.SendData ObjCnnTelnet.Password + vbCrLf
                        }
                        else
                        {
                            //El password enviado fue incorrecto
                            TelnetWS.Tag = LOGIN_INCORRECTO;
                            TelnetWS.SendData("");

                        }
                        // Timer1.Enabled = True
                    }
                    else if (strdat.IndexOf("login incorrect", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        TelnetWS.Tag = LOGIN_INCORRECTO; //Bandera para detener la llegada de datos del servidor telnet
                        TelnetWS.Close();
                        Application.DoEvents();
                        MdlCambioMasivo.MsgError("El usuario o password es incorrecto." + "\r\n" +
                                                 "\r\n" + "Introducir una contraseña incorrecta puede " +
                                                 "ocasionar el bloqueo de su cuenta");

                    }
                    else if (strdat.IndexOf("Account is disable", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        TelnetWS.Tag = CONEXION_CANCELADA;
                        TelnetWS.Close();
                        MdlCambioMasivo.MsgInfo("La cuenta está desactivada");
                    }
                    else if (TelnetWS.Tag.ToString() == SOLICITA_PWD && (strdat.IndexOf("login:", StringComparison.CurrentCultureIgnoreCase) + 1) == 0 && (strdat.IndexOf("login incorrect", StringComparison.CurrentCultureIgnoreCase) + 1) == 0 && strdat != "\r" + "\n" && strdat != ".")
                    {
                        //El estado anterior es la solicitud del password
                        //y no se está reintentando la captura del password este momento el login
                        TelnetWS.Tag = LOGIN_MENSAJES_BIENVENIDA;
                        TelnetWS.SendData("" + "\r" + "\n"); //manda un enter al telnet para obligarlo a que devuelve el prompt
                        //.SendData Chr(255) + Chr(252) + Chr(24)

                    }
                    else if (TelnetWS.Tag.ToString() == LOGIN_MENSAJES_BIENVENIDA && (strdat.IndexOf("\r" + "\n") + 1) >= 1)
                    {

                        TelnetWS.Tag = PRESENTA_PROMPT;

                        //.SendData vbCrLf            'Estamos en espera del promp por lo que los comandos ya se pueden poner en la  cola del proceso
                    }
                    else if (TelnetWS.Tag.ToString() == SOLICITAR_PROCESO)
                    {
                        TelnetWS.Tag = PRESENTA_PROMPT;
                    }
                    else
                    {

                        //  For x = 1 To bytesTotal
                        //      TxtTelnet.Text = TxtTelnet.Text & Chr(13) + "  " & Asc(Mid(strdat, x, 1)) & Chr(13)
                        //  Next x

                        //Timer1.Enabled = False
                        // ElseIf InStr(1, strdat, Chr(255) & Chr(253) & Chr(24), vbBinaryCompare) > 0 Then
                        //    Winsock1.SendData Chr(255) + Chr(251) + Chr(24)
                        //    MsgBox "password aceptado"
                    }
                }

                //Actualiza la ventana que tiene las respuestas del telnet
                TxtTelnet.Text = TxtTelnet.Text + strdat;
                TxtTelnet.Refresh();
                TxtTelnet.SelectionStart = Strings.Len(TxtTelnet.Text);
                txtComando.Visible = true;

                //txtComando.SetFocus

                PosInicial = 0;
                Application.DoEvents();
                //Me.Refresh
            }
            catch
            {


                string tempRefParam2 = "Tarjeta Corporativa.-TelnetWs.-DataArrival";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam2))
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }

        }

        private void TelnetWS_Error(Object eventSender, AxMSWinsockLib.DMSWinsockControlEvents_ErrorEvent eventArgs)
        {
            MdlCambioMasivo.MsgError("Se provoco el siguiente error en el socket" + "\r\n" +
                                     "No:" + eventArgs.number.ToString() + "\r\n" +
                                     "Descripción:" + eventArgs.description + "\r\n");
            TelnetWS.Close();
        }
        //Private Function Conectar()
        //    Set ObjCnnTelnet = Nothing 'Libera el objeto si es que ya está inicializado
        //    Set ObjCnnTelnet = New ClsTcpIp
        //    Dim HoraActual  As Date
        //
        //
        //    Conectar = False
        //    ObjCnnTelnet.PrPreguntaPassword "Password Autorizado"
        //    If ObjCnnTelnet.Password <> "" Then
        //        TelnetWS.Tag = DESCONECTADO 'Variable que prepara al usuario para evitar avalancha de peticiones
        //        TelnetWS.Close 'Cierra la conexion existente en el winsock para evitar que se quede algun error en el sistema
        //        TelnetWS.RemoteHost = ObjCnnTelnet.Host
        //        TelnetWS.RemotePort = ObjCnnTelnet.Puerto("Telnet")
        //        TelnetSb.Panels(1).Text = "Conectando a: " & TelnetWS.RemoteHost & "..."
        //        TelnetSb.Refresh
        //        TelnetWS.Connect
        //        'Conectar = True
        //        Do
        //            DoEvents
        //            HoraActual = TimeSerial(Hour(Time), Minute(Time), Second(Time) + TimeOut)
        //            'Do
        //               ' MsgBox "**** Hora:" & Time & "Time Out : " & HoraActual
        //            'Loop Until HoraActual < Time
        //
        //        Loop While TelnetWS.Tag = DESCONECTADO And TelnetWS.State = sckClosed
        //
        //        Do
        //           ' DoEvents
        //           HoraActual = TimeSerial(Hour(Time), Minute(Time), Second(Time) + TimeOut)
        //            Do
        //
        //                If TelnetWS.State = sckClosing Or TelnetWS.State = sckClosed Then
        //                    TelnetSb.Panels(1).Text = "Se perdio la conexión con el host"
        //                    Exit Do
        //                End If
        //
        //
        //                DoEvents
        //            Loop Until HoraActual < Time
        //            If HoraActual < Time Then
        //                Exit Do
        //            Else
        //                If TelnetWS.State = sckClosing Or TelnetWS.State = sckClosed Then
        //                    TelnetSb.Panels(1).Text = "Se perdio la conexión con el host"
        //                    Exit Do
        //                End If
        //
        //            End If
        //        Loop While (TelnetWS.Tag <> PRESENTA_PROMPT And TelnetWS.Tag <> LOGIN_MENSAJES_BIENVENIDA)
        //        Conectar = TelnetWS.Tag = PRESENTA_PROMPT Or TelnetWS.Tag = LOGIN_MENSAJES_BIENVENIDA
        //    Else
        //        MsgInfo "Proceso cancelado por el usuario"
        //
        //    End If
        //
        //End Function

        private void txtComando_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;
            if (KeyCode == ((int)Keys.Up) || KeyCode == ((int)Keys.Down))
            {
                txtComando.Text = Strings.Chr(27).ToString();
            }
        }

        private void txtComando_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            switch (KeyAscii)
            {
                case 13:

                    KeyAscii = 0;
                    BtnEnviar_Click(BtnEnviar, new EventArgs());
                    break;
                case 27:
                    KeyAscii = 0;
                    txtComando.Text = Strings.Chr(27).ToString();
                    BtnEnviar_Click(BtnEnviar, new EventArgs());
                    break;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void txtDirNuevo_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (("?*/\\+$").IndexOf(Strings.Chr(KeyAscii).ToString()) >= 0)
            {
                KeyAscii = 0;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void TxtTelnet_KeyDown(Object eventSender, KeyEventArgs eventArgs)
        {
            int KeyCode = (int)eventArgs.KeyCode;
            int Shift = (int)eventArgs.KeyData / 0x10000;
            if (PosInicial == 0)
            {
                PosInicial = Strings.Len(TxtTelnet.Text);
            }
        }

        private void TxtTelnet_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            switch (KeyAscii)
            {
                case 13:
                    KeyAscii = 0;
                    txtComando.Text = Strings.Mid(TxtTelnet.Text, PosInicial, Strings.Len(TxtTelnet.Text));
                    BtnEnviar_Click(BtnEnviar, new EventArgs());

                    break;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        private void PrListaEmpresas(int intGrupo)
        {
            ADODB.Recordset rsEmpresas = null;
            try
            {
                string strSql = String.Empty;

                this.Cursor = Cursors.WaitCursor;


                strSql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + intGrupo.ToString();
                strSql = strSql + " Order by emp_num";

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
                    rsEmpresas = new ADODB.Recordset();
                    rsEmpresas.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, -1);
                    CboEmpresas[1].Items.Clear();
                    while (!rsEmpresas.EOF)
                    {

                        CboEmpresas[1].Items.Add(new ListBoxItem(StringsHelper.Format(rsEmpresas.Fields["emp_num"].Value, "000") + new String(' ', 5) + Convert.ToString(rsEmpresas.Fields["emp_nom"].Value).Trim(), Convert.ToInt32(rsEmpresas.Fields["emp_num"].Value)));
                        rsEmpresas.MoveNext();
                    }
                    rsEmpresas.Close();
                    rsEmpresas = null;
                    VBSQL.gConn[10].Close();
                }
                this.Cursor = Cursors.Default;
            }
            catch
            {

                if (MdlCambioMasivo.fnGetError())
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    if (rsEmpresas.State != 0)
                    {
                        rsEmpresas.Close();
                    }
                    rsEmpresas = null;
                }

                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }

                this.Cursor = Cursors.Default;
            }

        }
        private void PrListaReportes(int intEjePrefijo, int intGpoBanco, int lngEmpNum, int intNoUnidad, int intGpoNum, ref  int NivelInicial, object NivelFinal)
        {
            string strSql = String.Empty;
            ADODB.Recordset rsReportes = null;
            int lngRenglon = 0;
            int intColumna = 0;
            string strTipoEjec = String.Empty;


            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (CboFecha.SelectedIndex)
                {
                    case 1:
                        strTipoEjec = "D";
                        break;
                    case 0:
                        strTipoEjec = "C";
                        break;
                    default:
                        MdlCambioMasivo.MsgInfo("Debe elegir un tipo de reporte a procesar");
                        CboFecha.Focus();
                        return;
                }

                strSql = "Select Distinct  A.eje_prefijo,A.gpo_banco,convert(int,A.report_id) as  report_id,reporting_gen,A.reporting_freq";
                strSql = strSql + " from MTCURP01  A ,";
                strSql = strSql + " MTCREP01 B";
                strSql = strSql + " Where";
                strSql = strSql + " A.report_id = B.report_id";
                strSql = strSql + " And upper(ltrim(rtrim(reporting_gen))) = 'Y' ";
                strSql = strSql + " And A.eje_prefijo = " + intEjePrefijo.ToString();
                strSql = strSql + " And  A.gpo_banco = " + intGpoBanco.ToString();
                strSql = strSql + " And A.report_type = " + ((int)TipoReporte).ToString();
                strSql = strSql + " And upper(ltrim(rtrim(A.reporting_freq))) = '" + strTipoEjec + "'";
                strSql = strSql + " And Convert(int,A.report_id) >= 13";
                strSql = strSql + " And ltrim(rtrim(B.rep_tipo_prod)) = 'C'";
                //UPGRADE_ISSUE: (1040) IsMissing function is not supported.
                //AIS-1123 NGONZALEZ
                if (NivelInicial == -1)
                {
                    NivelInicial = 0;
                }
                switch (TipoReporte)
                {
                    case EnTipoReporte.rptGrupo:
                        strSql = strSql + " and  A.gpo_num = " + intGpoNum.ToString();
                        strSql = strSql + " and report_level = " + NivelInicial;


                        break;
                    case EnTipoReporte.rptGrupoEmpresa:
                        strSql = strSql + " And A.emp_num = " + lngEmpNum.ToString();
                        strSql = strSql + " and report_level = " + NivelInicial;

                        break;
                    case EnTipoReporte.RptGrupoEmpresaUnidad:
                        strSql = strSql + " And A.emp_num = " + lngEmpNum.ToString();
                        strSql = strSql + " And A.unit_id = '" + intNoUnidad.ToString() + "'";

                        break;
                }
                strSql = strSql + " Order by convert(int,report_id)";
                ReportesCol = null; //Libera la coleccion
                ReportesCol = new Collection(); //Genera nueva coleccion para los reportes seleccionados cuando el usuario selecciona un reporte

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
                    rsReportes = new ADODB.Recordset();
                    rsReportes.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                    SpdReportes.MaxCols = 5;
                    SpdReportes.MaxRows = 0;
                    // SpdReportes.MaxRows = 1
                    //Establece las propiedades por default
                    //ya que la opcion de blockmode aplica para
                    //todo el conjunto de celdas y al hacer la consulta repetidamente
                    //se comporta de manera erratica
                    SpdReportes.Protect = false;
                    SpdReportes.Lock = false;
                    SpdReportes.BlockMode = false;

                    while (!rsReportes.EOF)
                    {

                        lngRenglon++;
                        //SpdReportes.Tag = "";  REMEDIACIÓN JULIO2014
                        SpdReportes.MaxRows = lngRenglon;
                        SpdReportes.Row = lngRenglon;
                        SpdReportes.Col = 1;
                        SpdReportes.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();
                        //.Text = Nvl(rsReportes!unit_id, "0") 
                        //UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
                        SpdReportes.Text = Convert.ToString(MdlCambioMasivo.Nvl(rsReportes.Fields["report_id"].Value, "0"));
                        SpdReportes.Col = 2;
                        SpdReportes.CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();   //La columna acepta check box
                        SpdReportes.TypeCheckCenter = true;  
                        //UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
                        SpdReportes.Text = Math.Abs((("SY").IndexOf(Convert.ToString(MdlCambioMasivo.Nvl(rsReportes.Fields["reporting_gen"].Value, "N"))) >= 0) ? -1 : 0).ToString();
                        SpdReportes.Col = 3;
                        SpdReportes.CellType = new FarPoint.Win.Spread.CellType.EditBaseCellType();                        
                        //UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
                        SpdReportes.Text = Convert.ToString(MdlCambioMasivo.Nvl(rsReportes.Fields["reporting_freq"].Value, "0"));
                        SpdReportes.Col = 5;
                        SpdReportes.CellType = new FarPoint.Win.Spread.CellType.TextCellType();                        
                        rsReportes.MoveNext();
                    }
                    rsReportes.Close();
                    VBSQL.gConn[10].Close();
                }
                SpdReportes.Col = 4;
                SpdReportes.Row = 0; //Selecciona toda la columna del reporte
                SpdReportes.Row2 = SpdReportes.MaxRows;
                SpdReportes.CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();        //La columna es de un grupo de check Box
                
                //Bloquea el contenido de la celda
                SpdReportes.Col = 1; //Evita que el usuario
                SpdReportes.Col2 = 3; //pueda modificar
                SpdReportes.Row = 1; //el valor de ciertas
                SpdReportes.Row2 = SpdReportes.MaxRows; //columnas del grid
                SpdReportes.BlockMode = true;
                SpdReportes.Lock = true;
                SpdReportes.Protect = true;

                SpdReportes.Col = 5;
                SpdReportes.Row = 0;
                SpdReportes.Text = "Estado";
                this.Refresh();
                Application.DoEvents();
                this.Cursor = Cursors.Default;
            }
            catch
            {

                string tempRefParam = "PrListReportes";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    if (rsReportes.State != 0)
                    {
                        rsReportes.Close();
                    }
                    rsReportes = null;
                }

                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }

                this.Cursor = Cursors.Default;
            }

        }

        private void PrListaReportes(int intEjePrefijo, int intGpoBanco, int lngEmpNum, int intNoUnidad, int intGpoNum, ref  int NivelInicial)
        {
            PrListaReportes(intEjePrefijo, intGpoBanco, lngEmpNum, intNoUnidad, intGpoNum, ref NivelInicial, null);
        }

        private void PrListaReportes(int intEjePrefijo, int intGpoBanco, int lngEmpNum, int intNoUnidad, int intGpoNum)
        {
            int tempRefParam4 = -1;
            PrListaReportes(intEjePrefijo, intGpoBanco, lngEmpNum, intNoUnidad, intGpoNum, ref tempRefParam4, null);
        }

        private void PrListaReportes(int intEjePrefijo, int intGpoBanco, int lngEmpNum, int intNoUnidad)
        {
            int tempRefParam5 = -1;
            PrListaReportes(intEjePrefijo, intGpoBanco, lngEmpNum, intNoUnidad, 0, ref tempRefParam5, null);
        }

        private void PrListaUnidades(int intEjePrefijo, int intNoGpoBanco, int intNoEmpresa, int intGpoNum)
        {
            string strSql = String.Empty;
            ADODB.Recordset rsUnidad = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;

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
                    strSql = "Select unit_id,unit_name from MTCUNI01 ";
                    strSql = strSql + " Where emp_num = " + intNoEmpresa.ToString();
                    strSql = strSql + " And gpo_banco = " + intNoGpoBanco.ToString();
                    strSql = strSql + " and eje_prefijo = " + intEjePrefijo.ToString();
                    strSql = strSql + " and gpo_num = " + intGpoNum.ToString();
                    rsUnidad = new ADODB.Recordset();
                    rsUnidad.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                    CboEmpresas[2].Items.Clear();

                    while (!rsUnidad.EOF)
                    {

                        CboEmpresas[2].Items.Add(new ListBoxItem(StringsHelper.Format(rsUnidad.Fields["unit_id"].Value, "0000") + new String(' ', 2) + Convert.ToString(rsUnidad.Fields["unit_name"].Value), Convert.ToInt32(rsUnidad.Fields["unit_id"].Value)));
                        rsUnidad.MoveNext();

                    }
                    //OptReporte(0).Value = True
                    rsUnidad.Close();
                    VBSQL.gConn[10].Close();
                }
                this.Cursor = Cursors.Default;
            }
            catch
            {

                if (MdlCambioMasivo.fnGetError())
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    if (rsUnidad.State != 0)
                    {
                        rsUnidad.Close();
                    }
                    rsUnidad = null;
                }

                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }
                this.Cursor = Cursors.Default;
            }
        }


        private void PrListaNiveles(ComboBox Ctrl, int intEjePrefijo, int intGpoBanco, int intGpoNum, int intEmpNum, int intNivelInicial)
        {
            string strSql = String.Empty;
            ADODB.Recordset rsNiveles = null;

            try
            {

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
                    strSql = "Select Distinct nivel_num from MTCUNI01 ";
                    strSql = strSql + "Where eje_prefijo = " + intEjePrefijo.ToString();
                    strSql = strSql + " And gpo_banco = " + intGpoBanco.ToString();
                    strSql = strSql + " And gpo_num = " + intGpoNum.ToString();
                    if (intEmpNum > -1)
                    {
                        //Desea filtrarse por no. empresa
                        strSql = strSql + " And emp_num= " + intEmpNum.ToString();
                    }
                    if (intNivelInicial > -1)
                    {
                        strSql = strSql + " And nivel_num  >= " + intNivelInicial.ToString();
                    }
                    rsNiveles = new ADODB.Recordset();
                    rsNiveles.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                    Ctrl.Items.Clear();
                    while (!rsNiveles.EOF)
                    {

                        //UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
                        Ctrl.Items.Add(Convert.ToString(MdlCambioMasivo.Nvl(rsNiveles.Fields["nivel_num"].Value, 0)));
                        rsNiveles.MoveNext();
                    }
                    rsNiveles.Close();
                    VBSQL.gConn[10].Close();
                }
            }
            catch
            {
            }


            if (MdlCambioMasivo.fnGetError())
            {
                //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                throw new Exception("Migration Exception: 'Resume' not supported");
            }

            if (rsNiveles.State != 0)
            {
                rsNiveles.Close();
            }
            if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
            {
                VBSQL.gConn[10].Close();
            }

        }



        private void PrListaGrupos(bool bolTodos)
        {
            //Lee la lista de grupos si boltodos =false se excluye el grupo 0
            string strSql = String.Empty;
            ADODB.Recordset rsGrupos = null;
            try
            {

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
                    strSql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                    if (!bolTodos)
                    {
                        strSql = strSql + " And gpo_num  <> 0";
                    }
                    rsGrupos = new ADODB.Recordset();
                    rsGrupos.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                    CboEmpresas[1].Items.Clear();
                    CboEmpresas[0].Items.Clear();

                    while (!rsGrupos.EOF)
                    {

                        CboEmpresas[0].Items.Add(new ListBoxItem(Convert.ToString(rsGrupos.Fields["gpo_num"].Value) + new String(' ', 5) + Convert.ToString(rsGrupos.Fields["gpo_nom"].Value), Convert.ToInt32(rsGrupos.Fields["gpo_num"].Value)));
                        rsGrupos.MoveNext();
                    }
                    rsGrupos.Close();
                    rsGrupos = null;
                    VBSQL.gConn[10].Close();
                }
            }
            catch
            {

                if (MdlCambioMasivo.fnGetError())
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }

                if (rsGrupos.State != 0)
                {
                    rsGrupos.Close();
                }
                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }
            }

        }

        private bool FnVerificaEstructruraJerquiaBl(int intGpoNum)
        {
            bool result = false;
            string strSql = String.Empty;
            ADODB.Recordset rsEstructura = null;
            try
            {

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
                    strSql = "Select A.eje_prefijo,A.gpo_banco, A.unit_id , A.unit_parent_id, A.nivel_num, A.gpo_num, Count(A.unit_id)";
                    strSql = strSql + " from MTCUNI01 A";
                    strSql = strSql + " Where A.gpo_num = " + intGpoNum.ToString();
                    strSql = strSql + " And A.eje_prefijo = " + CORVAR.igblPref.ToString();
                    strSql = strSql + " And gpo_banco = " + CORVAR.igblBanco.ToString();
                    strSql = strSql + " group by A.eje_prefijo,A.gpo_banco, A.unit_id, A.unit_parent_id , A.nivel_num ,A.gpo_num";
                    strSql = strSql + " having Count(A.unit_id) <> (Select Count (B.unit_id) from MTCUNI01 B";
                    strSql = strSql + " where B.gpo_num = A.gpo_num and B.nivel_num = 1  and A.eje_prefijo = B.eje_prefijo  and B.gpo_banco = A.gpo_banco)";
                    rsEstructura = new ADODB.Recordset();
                    rsEstructura.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                    result = rsEstructura.EOF && rsEstructura.BOF;
                    rsEstructura.Close();
                    rsEstructura = null;
                    VBSQL.gConn[10].Close();
                }
            }
            catch
            {

                if (MdlCambioMasivo.fnGetError())
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    if (rsEstructura.State != 0)
                    {
                        rsEstructura.Close();
                    }
                    rsEstructura = null;
                }
                result = false;

                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }
            }

            return result;
        }


        private void FrmFechaReprote_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {

        }

        private void fpSpdReportes_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            
            ////string strNoreporte = String.Empty;
            string strNoreporte = null;
            ////string strFrecuencia = String.Empty;
            string strFrecuencia = null;

            //UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted properly. A throw statement was generated instead.
            //throw new Exception("Migration Exception: 'On Error Goto Handler' not supported");
            try
            {
              
                if ((e.Column + 1) == COL_GENERAREPORTE)
                {
                    //Determina si se dio un click en el check box de la columna de generar reportes
                    object tempRefParam = null;
                    try
                    {
                        SpdReportes.GetText(1, (e.Row + 1), ref tempRefParam);
                    }
                    catch
                    { }
                    strNoreporte = tempRefParam.ToString();
                    strNoreporte = strNoreporte.Trim();
                    object tempRefParam2 = null;
                    SpdReportes.GetText(3, (e.Row + 1), ref tempRefParam2);
                    strFrecuencia = tempRefParam2.ToString();
                    strFrecuencia = strFrecuencia.Trim();
                    ObjReporteProcesar = new ClsReporteGerencia();
                    ObjReporteProcesar.Col = e.Column + 1;
                    ObjReporteProcesar.Id = "Row" + (e.Row + 1).ToString();
                    ObjReporteProcesar.Reporte = StringsHelper.IntValue(strNoreporte);
                    ObjReporteProcesar.Row = e.Row + 1;
                    ObjReporteProcesar.Frecuencia = strFrecuencia;

                    if (e.GetButtonDown() == 1)
                    {
                        //Se agrega un elemento a la colexion de datos a procesar

                        ReportesCol.Add(ObjReporteProcesar, ObjReporteProcesar.Id, null, null); //Agrega un elemento a la colexion
                    }
                    else
                    {
                        //Se elimina un elemento de la colexion de datos a procesar
                        //UPGRADE_TODO: (1065) Error handling statement (On Error Resume Next) could not be converted properly. A throw statement was generated instead.
                        //throw new Exception("Migration Exception: 'On Error Resume Next' not supported");
                        try
                        {
                            ReportesCol.Remove(ObjReporteProcesar.Id);
                        }
                        catch 
                        {
                            //if (Information.Err().Number != 0)
                            // {
                            //El elemento en la colexion no existe
                            //     Information.Err().Clear();
                            // }
                        }
                        //UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted properly. A throw statement was generated instead.
                        //throw new Exception("Migration Exception: 'On Error Goto Handler' not supported");
                    }
                }
            }
            catch (Exception error)
            {
                //Handler; 
                if (MdlCambioMasivo.fnGetError())
                {
                    //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                    //throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }
            return;
        
        }



        //Function Genera_ReporteTux(Prefijo As String, Banco As String, Empresa As String, _
        //'       Unidad As String, Reporte As String, Frecuencia As String, LongEmpresa As String, _
        //'       LongEjecutivo As String, LongUnidad As String, LongReporte As String, _
        //'       Por_Grupo As String, NivelIni As String, NivelFin As String) As String
        //    Dim EmpresaMenor As String
        //    Dim fecha1 As String
        //    Dim serv_rep As Object
        //    Dim SqlCmd  As String
        //    Dim rs1 As ADODB.Recordset
        //    Dim strCmdShell As String
        //    Dim strFecha As String
        //    Dim strFechaIni As String
        //    Dim strFechaFin As String
        //    Dim strFechaCorte As String
        //    Dim strNombreArchivo As String
        //    Dim objTuxedo As New Tuxdriver.servicio
        //
        //    'Set serv_rep = New Form
        //    Genera_ReporteTux = ""
        //
        //    If (Val(Por_Grupo)) Then
        //        SqlCmd = "select distinct emp_num from MTCUNI01 where gpo_num = "
        //        SqlCmd = SqlCmd & Empresa & " order by emp_num"
        //        Set rs1 = New ADODB.Recordset
        //        rs1.Open SqlCmd, xcnn, adOpenForwardOnly, adLockReadOnly
        //        rs1.MoveFirst
        //        EmpresaMenor = rs1!emp_num
        //        rs1.Close
        //        Set rs1 = Nothing
        //     Else
        //        EmpresaMenor = Empresa
        //     End If
        //
        //     If (Len(Unidad) <= 5) Then
        //
        //         If (Day(Now - 1) = 17 Or Day(Now - 1) = 21) Then
        //            strFechaIni = Format(DateSerial(Year(Now), Month(Now) - 1, Day(Now)), "yyyymmdd")
        //            strFechaCorte = Month(Now) & Format(Day(Now - 1), "00")
        //         Else
        //            strFechaIni = Format(DateSerial(Year(Now - 1), Month(Now - 1), Day(Now - 1)), "yyyymmdd")
        //            strFechaCorte = "0"
        //         End If
        //         strFecha = Format(Now, "yyyymmdd")
        //         strFechaFin = Format(DateSerial(Year(Now - 1), Month(Now - 1), Day(Now - 1)), "yyyymmdd")
        //         'strNombreArchivo =  Prefijo & Banco _
        //'                            & Format(Val(EmpresaMenor), String(Val(LongEmpresa), "0")) _
        //'                            & "/" & strFecha & "." & Format(Val(Unidad), String(Val(LongUnidad), "0")) _
        //'                            & ".rpt" & Format(Val(Reporte), String(Val(LongReporte), "0")) & ".TXT"
        //         strNombreArchivo = strFecha & "." & Format(Val(Unidad), String(Val(LongUnidad), "0")) _
        //'                            & ".rpt" & Format(Val(Reporte), String(Val(LongReporte), "0")) & ".TXT"
        //
        //     Else
        //        Exit Function
        //     End If
        //     Set objTuxedo = New Tuxdriver.servicio
        //     With objTuxedo
        //        .setbGrupo (Por_Grupo)
        //        .setPrefijo (Prefijo)
        //        .setBanco (Banco)
        //        .setEmpresa (EmpresaMenor)
        //        .setFecha (strFecha)
        //        .setFechaCorteMD (strFechaCorte)
        //        .setFechaFinAMD (strFechaFin)
        //        .setFechaIniAMD (strFechaIni)
        //        .setFrecuencia (Frecuencia)
        //        .setNivelIni (NivelIni)
        //        .setNivelFin (NivelFin)
        //        .setNombreRep ("Reporte_" & Reporte)
        //        .setReporte ("rep" & Trim(Reporte))
        //        .setUnidad (Unidad)
        //        .setArchivoDisco ("temp.tmp")
        //        .setArchivoTemp ("reporte.tmp")
        //        .setbTotales ("0")
        //        If .ejecuta("DEBUG") = -1 Then
        //            Genera_ReporteTux = "Error"
        //        Else
        //            Genera_ReporteTux = "Ok"
        //        End If
        //
        //     End With
        //     Set objTuxedo = Nothing
        //
        //End Function
        //
        //Function Genera_Reporte(Prefijo As String, Banco As String, Empresa As String, _
        //'       Unidad As String, Reporte As String, Frecuencia As String, LongEmpresa As String, _
        //'       LongEjecutivo As String, LongUnidad As String, LongReporte As String, _
        //'       Por_Grupo As String, NivelIni As String, NivelFin As String) As String
        //
        //    Dim EmpresaMenor As String
        //    Dim fecha1 As String
        //    Dim serv_rep As Object
        //    Dim SqlCmd  As String
        //    Dim rs1 As ADODB.Recordset
        //    Dim strCmdShell As String
        //    Dim strFecha As String
        //    Dim strFechaIni As String
        //    Dim strFechaFin As String
        //    Dim strFechaCorte As String
        //    Dim strNombreArchivo As String
        //
        //    'Set serv_rep = New Form
        //    Genera_Reporte = ""
        //
        //    If (Val(Por_Grupo)) Then
        //        SqlCmd = "select distinct emp_num from MTCUNI01 where gpo_num = "
        //        SqlCmd = SqlCmd & Empresa & " order by emp_num"
        //        Set rs1 = New ADODB.Recordset
        //        rs1.Open SqlCmd, xcnn, adOpenForwardOnly, adLockReadOnly
        //        rs1.MoveFirst
        //        EmpresaMenor = rs1!emp_num
        //        rs1.Close
        //        Set rs1 = Nothing
        //     Else
        //        EmpresaMenor = Empresa
        //     End If
        //
        //     If (Len(Unidad) <= 5) Then
        //
        //         If (Day(Now - 1) = 17 Or Day(Now - 1) = 21) Then
        //            strFechaIni = Format(DateSerial(Year(Now), Month(Now) - 1, Day(Now)), "yyyymmdd")
        //            strFechaCorte = Month(Now) & Format(Day(Now - 1), "00")
        //         Else
        //            strFechaIni = Format(DateSerial(Year(Now - 1), Month(Now - 1), Day(Now - 1)), "yyyymmdd")
        //            strFechaCorte = "0"
        //         End If
        //         strFecha = Format(Now, "yyyymmdd")
        //         strFechaFin = Format(DateSerial(Year(Now - 1), Month(Now - 1), Day(Now - 1)), "yyyymmdd")
        //         'strNombreArchivo =  Prefijo & Banco _
        //'                            & Format(Val(EmpresaMenor), String(Val(LongEmpresa), "0")) _
        //'                            & "/" & strFecha & "." & Format(Val(Unidad), String(Val(LongUnidad), "0")) _
        //'                            & ".rpt" & Format(Val(Reporte), String(Val(LongReporte), "0")) & ".TXT"
        //         strNombreArchivo = strFecha & "." & Format(Val(Unidad), String(Val(LongUnidad), "0")) _
        //'                            & ".rpt" & Format(Val(Reporte), String(Val(LongReporte), "0")) & ".TXT"
        //
        //         '   d = DateSerial(Year(Date), Month(Now) - 1, Day(Now))
        //         '   serv_rep.servicio.parametros.SetFechaIniAMD = Format(Year(d), "0000") & _
        //'         '   Format(Month(d), "00") & Format(Day(d), "00")
        //         '   serv_rep.servicio.parametros.SetFechaCorteMD = Month(Now) & Format(Day(Now - 1), "00")
        //         'Else
        //         '   serv_rep.servicio.parametros.SetFechaIniAMD = Format(Year(Now - 1), "0000") & _
        //'         '   Format(Month(Now - 1), "00") & Format(Day(Now - 1), "00")
        //         '   serv_rep.servicio.parametros.SetFechaCorteMD = "0"
        //         'End If
        //         'fecha1 = Format(Year(Now), "0000") & Format(Month(Now), "00") & Format(Day(Now), "00")
        //         'serv_rep.servicio.parametros.SetFecha = fecha1
        //         'serv_rep.servicio.parametros.SetFechaFinAMD = Format(Year(Now - 1), "0000") & _
        //'         'Format(Month(Now - 1), "00") & Format(Day(Now - 1), "00")
        //         'serv_rep.servicio.parametros.SetArchivoDisco = "deposito/" & Prefijo & Banco _
        //'         '& Format(Val(EmpresaMenor), String(Val(LongEmpresa), "0")) _
        //'         '& "/" & fecha1 & "." & Format(Val(Unidad), String(Val(LongUnidad), "0")) _
        //'         '& ".rpt" & Format(Val(Reporte), String(Val(LongReporte), "0")) & ".TXT"
        //     Else
        //        Exit Function
        //     End If
        //     Select Case Val(Reporte)
        //     Case 13, 14, 23, 24
        //        ' rep14 sNomRep, sFecha, Prefijo, Banco, Empresa, Unidad, fechaIniAMD, fechaFinAMD, fechaCorteMD, R1, R2, Archivo, Por_Grupo
        //        ' rep24 sNomRep, sFecha, Prefijo, Banco, Empresa, Unidad, fechaIniAMD, fechaFinAMD, fechaCorteMD, R1, R2, Archivo, Por_Grupo
        //
        //
        //        strCmdShell = "rep" & Trim(Val(Reporte) + (Val(Reporte) Mod 2))
        //        strCmdShell = strCmdShell & " rep" & Trim(Reporte)
        //        strCmdShell = strCmdShell & " " & strFecha
        //        strCmdShell = strCmdShell & " " & Prefijo
        //        strCmdShell = strCmdShell & " " & Banco
        //        strCmdShell = strCmdShell & " " & Empresa
        //        strCmdShell = strCmdShell & " " & Unidad
        //        strCmdShell = strCmdShell & " " & strFechaIni
        //        strCmdShell = strCmdShell & " " & strFechaFin
        //        strCmdShell = strCmdShell & " " & strFechaCorte
        //        strCmdShell = strCmdShell & " " & NivelIni
        //        strCmdShell = strCmdShell & " " & NivelFin
        //        strCmdShell = strCmdShell & " " & strNombreArchivo
        //        strCmdShell = strCmdShell & " " & Por_Grupo
        //
        //     Case 15, 16
        //
        //        'rep16 sNomRep, sFecha, Prefijo, Banco, Empresa, Unidad, fechaIniAMD, fechaFinAMD, R1, R2, Archivo, Por_Grupo
        //        strCmdShell = "rep" & Trim(Val(Reporte) + (Val(Reporte) Mod 2))
        //        strCmdShell = strCmdShell & " rep" & Trim(Reporte)
        //        strCmdShell = strCmdShell & " " & strFecha
        //        strCmdShell = strCmdShell & " " & Prefijo
        //        strCmdShell = strCmdShell & " " & Banco
        //        strCmdShell = strCmdShell & " " & Empresa
        //        strCmdShell = strCmdShell & " " & Unidad
        //        strCmdShell = strCmdShell & " " & strFechaIni
        //        strCmdShell = strCmdShell & " " & strFechaFin
        //        strCmdShell = strCmdShell & " " & NivelIni
        //        strCmdShell = strCmdShell & " " & NivelFin
        //        strCmdShell = strCmdShell & " " & strNombreArchivo
        //        strCmdShell = strCmdShell & " " & Por_Grupo
        //
        //     Case 17, 18, 19, 20, 21, 22
        //      'rep18 sNomRep, sFecha, Prefijo, Banco, Empresa, Unidad, fechaCorteMD, R1, R2, Archivo, Por_Grupo, Por_Tot
        //      'rep20 sNomRep, sFecha, Prefijo, Banco, Empresa, Unidad, fechaCorteMD, R1, R2, Archivo, Por_Grupo, Por_Tot
        //      'rep22 sNomRep, sFecha, Prefijo, Banco, Empresa, Unidad, fechaCorteMD, R1, R2, Archivo, Por_Grupo, Por_Tot
        //
        //        strCmdShell = "rep" & Trim(Val(Reporte) + (Val(Reporte) Mod 2))
        //        strCmdShell = strCmdShell & " rep" & Trim(Reporte)
        //        strCmdShell = strCmdShell & " " & strFecha
        //        strCmdShell = strCmdShell & " " & Prefijo
        //        strCmdShell = strCmdShell & " " & Banco
        //        strCmdShell = strCmdShell & " " & Empresa
        //        strCmdShell = strCmdShell & " " & Unidad
        //        strCmdShell = strCmdShell & " " & strFechaCorte
        //        strCmdShell = strCmdShell & " " & NivelIni
        //        strCmdShell = strCmdShell & " " & NivelFin
        //        strCmdShell = strCmdShell & " " & strNombreArchivo
        //        strCmdShell = strCmdShell & " " & Por_Grupo
        //        strCmdShell = strCmdShell & " " & 0
        //     End Select
        //
        //      Genera_Reporte = "/opt/c430/reportes2/" & strCmdShell
        //      'serv_rep.servicio.parametros.SetPrefijo = Prefijo
        //      'serv_rep.servicio.parametros.SetBanco = Banco
        //      'serv_rep.servicio.parametros.SetEmpresa = Empresa
        //      'serv_rep.servicio.parametros.SetUnidad = Unidad
        //      'serv_rep.servicio.parametros.SetReporte = Reporte
        //      'serv_rep.servicio.parametros.SetFrecuencia = Frecuencia
        //      'serv_rep.servicio.parametros.SetLongEmpresa = LongEmpresa
        //      'serv_rep.servicio.parametros.SetLongEjecutivo = LongEjecutivo
        //      'serv_rep.servicio.parametros.SetLongUnidad = LongUnidad
        //      'serv_rep.servicio.parametros.SetLongReporte = LongReporte
        //      'serv_rep.servicio.parametros.SetBandGrupo = Por_Grupo
        //
        //
        //
        //         'serv_rep.servicio.parametros.SetNombreRep = "REP" & Reporte
        //         'serv_rep.servicio.parametros.SetArchivoTemp = "report.tmp"
        //         'serv_rep.servicio.parametros.SetNivelIni = NivelIni
        //         'serv_rep.servicio.parametros.SetNivelFin = NivelFin
        //        '
        //         'If (Day(Now - 1) = 13 Or Day(Now - 1) = 22) Then
        //         '   Dim d As String
        //         '   d = DateSerial(Year(Date), Month(Now) - 1, Day(Now))
        //         '   serv_rep.servicio.parametros.SetFechaIniAMD = Format(Year(d), "0000") & _
        //'         '   Format(Month(d), "00") & Format(Day(d), "00")
        //         '   serv_rep.servicio.parametros.SetFechaCorteMD = Month(Now) & Format(Day(Now - 1), "00")
        //         'Else
        //         '   serv_rep.servicio.parametros.SetFechaIniAMD = Format(Year(Now - 1), "0000") & _
        //'         '   Format(Month(Now - 1), "00") & Format(Day(Now - 1), "00")
        //         '   serv_rep.servicio.parametros.SetFechaCorteMD = "0"
        //         'End If
        //         'fecha1 = Format(Year(Now), "0000") & Format(Month(Now), "00") & Format(Day(Now), "00")
        //         'serv_rep.servicio.parametros.SetFecha = fecha1
        //         'serv_rep.servicio.parametros.SetFechaFinAMD = Format(Year(Now - 1), "0000") & _
        //'         'Format(Month(Now - 1), "00") & Format(Day(Now - 1), "00")
        //         'serv_rep.servicio.parametros.SetArchivoDisco = "deposito/" & Prefijo & Banco _
        //'         '& Format(Val(EmpresaMenor), String(Val(LongEmpresa), "0")) _
        //'         '& "/" & fecha1 & "." & Format(Val(Unidad), String(Val(LongUnidad), "0")) _
        //'         '& ".rpt" & Format(Val(Reporte), String(Val(LongReporte), "0")) & ".TXT"
        //
        //        ' If Not (serv_rep.servicio.ejecuta) Then
        //        '    Genera_Reporte = "SUCCEED"
        //        ' Else
        //        '    Genera_Reporte = "FAIL"
        //         'End If
        //     'End If
        //
        //End Function

        //UPGRADE_NOTE: (7001) The following declaration (FnUnidadPadreStr) seems to be dead code
        //private string FnUnidadPadreStr( int intEjePrefijo,  int intGpoBanco,  int intNumEmp,  EnTipoReporte pTipoReporte,  string pStrReporteId)
        //{
        //
        //string result = String.Empty;
        //string strSql = String.Empty;
        //ADODB.Recordset RsUnidadPadre = null;
        //
        //try
        //{
        //
        //if (VBSQL.OpenConn(10) != 0)
        //{
        //VBSQL.gConn[10].Close();
        //} else
        //{
        //VBSQL.gConn[10].Close();
        //}
        //
        //if (VBSQL.OpenConn(10) == 0)
        //{
        //strSql = " Select unit_id from MTCURP01 A";
        //strSql = strSql + " Where A.eje_prefijo = " + intEjePrefijo.ToString();
        //strSql = strSql + " And A.gpo_banco = " + intGpoBanco.ToString();
        //strSql = strSql + " And A.emp_num = " + intNumEmp.ToString();
        //strSql = strSql + " And A.report_type =  " + ((int) pTipoReporte).ToString();
        //strSql = strSql + " And A.reporting_gen = 'Y'"; //Filtrará solo los reportes calificados
        //strSql = strSql + " And A.report_id = '" + pStrReporteId + "'";
        //strSql = strSql + " And A.report_level = 0";
        //RsUnidadPadre = new ADODB.Recordset();
        //RsUnidadPadre.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
        //if (! RsUnidadPadre.EOF)
        //{
        ////UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to string.
        //result = Convert.ToString(MdlCambioMasivo.Nvl(RsUnidadPadre.Fields["unit_id"], "1"));
        //
        //} else
        //{
        //result = "1";
        //}
        //RsUnidadPadre.Close();
        //RsUnidadPadre = null;
        //VBSQL.gConn[10].Close();
        //}
        //}
        //catch 
        //{
        //}
        //
        //
        //
        //if (RsUnidadPadre.State != 0)
        //{
        //RsUnidadPadre.Close();
        //}
        //
        //if (VBSQL.gConn[10].State != ((int) ADODB.ObjectStateEnum.adStateClosed))
        //{
        //VBSQL.gConn[10].Close();
        //}
        //
        //return result;
        //}
    }
}