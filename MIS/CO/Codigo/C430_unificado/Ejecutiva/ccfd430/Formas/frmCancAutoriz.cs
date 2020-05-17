using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmCancAutoriz
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
            //'*: Descripción:    Pantalla para autorización (cheker) de cancelaciones de      **
            //'*:                 cuentas de tarjetahabientes o empresas.                      **
            //'*:********************************************************************************

            private clsCancelaciones mcncCancelaciones;

            public void mprLog(string asMsg)
            {
                txtLog.Text = asMsg + txtLog.Text;
            }

           object numboton;

           private void mprActivarBotones(bool abActivar)
            {
                    bool abVacio = false;

                    numboton = 7; //Actualizar
                    tbrStandar.Buttons.get_Item(ref numboton).Enabled = abActivar;
                    numboton = 4; //Aceptar
                    tbrStandar.Buttons.get_Item(ref numboton).Enabled = abActivar;
                    numboton = 5; //Cancelar
                    tbrStandar.Buttons.get_Item(ref numboton).Enabled = abActivar;
                    numboton = 2; //Ninguno
                    tbrStandar.Buttons.get_Item(ref numboton).Enabled = abActivar;
                    numboton = 1; //Todos
                    tbrStandar.Buttons.get_Item(ref numboton).Enabled = abActivar;
                    lvwCuentas.Enabled = abActivar;
                    
                    if (abVacio)
                    {
                        numboton = 7; //Actualizar
                        tbrStandar.Buttons.get_Item(ref numboton).Enabled = true;
                        numboton = 2; //Ninguno
                        tbrStandar.Buttons.get_Item(ref numboton).Enabled = true;
                        numboton = 1; //Todos
                        tbrStandar.Buttons.get_Item(ref numboton).Enabled = true;
                        lvwCuentas.Enabled = true;
                    }
            }

            private bool mfnCargarMallaB()
            {
                try 
	            {	        
                    lvwCuentas.ListItems.Clear();
                    lvwCuentas.Sorted = false;
                    lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwDescending;
                
                    //'*:-------------------- 1 ------- 2 ---------- 3 ---------- 4 ------------ 5 --------
                    CORVAR.pszgblsql = "SELECT  cnc_id, cnc_eje_tam, cnc_cuenta, cnc_maker_usr, cnc_maker_nom, ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(yy, cnc_maker_fecha))))) tmp_anio, "; //'*:  6
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(mm, cnc_maker_fecha))))) tmp_mes, ";  //'*:  7
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(dd, cnc_maker_fecha))))) tmp_dia, ";  //'*:  8
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(hh, cnc_maker_fecha))))) tmp_hora, "; //'*:  9
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(mi, cnc_maker_fecha))))) tmp_min, ";  //'*: 10
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_tipo, cnc_cuentahabiente, cnc_num_ctas_hijas ";             //'*: 11, 12, 13
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCCNC01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE cnc_status=" + Conversion.Str(clsCancelaciones.enmCancelacionStatus.CST_PENDIENTE) + " AND ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_prefijo=" + mdlParametros.gprdProducto.PrefijoL.ToString() + " AND ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco=" + mdlParametros.gprdProducto.BancoL.ToString() + " ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "ORDER BY cnc_maker_fecha";
                
                    CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);

                    if (CORPROC2.Obtiene_Registros() != 0) 
                    {
                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            //With lvwCuentas.ListItems
                            //    .Add , "K_" & CStr(CLng(Nvl(SqlData(hgblConexion, 1), -1))) & "_" & _
                            //            CStr(Nvl(SqlData(hgblConexion, 2), -1)) & "_" & CStr(Nvl(SqlData(hgblConexion, 11), -1)), _
                            //            CStr(Nvl(SqlData(hgblConexion, 3), -1))
                            //    .Item(.Count).SubItems(1) = CStr(Nvl(SqlData(hgblConexion, 12), -1))
                            //    .Item(.Count).SubItems(3) = CStr(Nvl(SqlData(hgblConexion, 4), -1))
                            //    .Item(.Count).SubItems(2) = CStr(Nvl(SqlData(hgblConexion, 5), -1))
                            //    dtpAux.Year = CInt(CStr(Nvl(SqlData(hgblConexion, 6), -1)))
                            //    dtpAux.Month = CInt(CStr(Nvl(SqlData(hgblConexion, 7), -1)))
                            //    dtpAux.Day = CInt(CStr(Nvl(SqlData(hgblConexion, 8), -1)))
                            //    dtpAux.Hour = CInt(CStr(Nvl(SqlData(hgblConexion, 9), -1)))
                            //    dtpAux.Minute = CInt(CStr(Nvl(SqlData(hgblConexion, 10), -1)))
                            //    .Item(.Count).SubItems(4) = Format(dtpAux, cteFormatoFecha)
                            //    .Item(.Count).SubItems(5) = Format(dtpAux, cteFormatoHora)
                            //    .Item(.Count).SubItems(6) = mcncCancelaciones.fnTipoDescS(CInt(Nvl(SqlData(hgblConexion, 11), -1)))
                            //    .Item(.Count).SubItems(7) = CInt(Nvl(SqlData(hgblConexion, 13), -1))
                            //End With
							object tempRefParam = Type.Missing;
							object tempRefParam2 = "K" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 1), -1)) + "_" +
                                Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 2), -1)) + "_" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 11), -1));
							object tempRefParam3 = Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 3), -1));
							object tempRefParam4 = Type.Missing;
							object tempRefParam5 = Type.Missing;
                            MSComctlLib.ListItem ListItem = lvwCuentas.ListItems.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5);
							object tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(1, Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 12), -1)));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(3, Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 4), -1)));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(2, Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 5), -1)));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            dtpAux.Year = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 6), -1)));
                            dtpAux.Month = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 7), -1)));
                            dtpAux.Day = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 8), -1)));
                            dtpAux.Hour = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 9), -1)));
                            dtpAux.Minute = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 10), -1)));
                            ListItem.set_SubItems(4, Strings.Format(dtpAux, CRSParametros.cteFormatoFecha));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(5, Strings.Format(dtpAux, CRSParametros.cteFormatoHora));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(6, mcncCancelaciones.fnTipoDescS((clsCancelaciones.enmCancelacionTipos)MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 11), -1)));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(7, Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 13), -1)));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                        }
                        //lvwCuentas.ListItems(1).Selected = true;
                        object tempRefParam7 = 1;
                        lvwCuentas.ListItems.get_ControlDefault(ref tempRefParam7).Selected = true;

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No existen operaciones pendientes de autorización", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            		
	            }
	            catch (Exception)
	            {
                    MessageBox.Show("Ocurrió el siguiente error en el proceso:" + "\r\n" + "Número: " + Information.Err().Number + "\r\n" +
                            "Descripcion: " + Information.Err().Description + "\r\n" + "Origen: " + Information.Err().Source + "\r\n" +
                            "Módulo: frmCancAutoriz::mfnCargarMallaB::Click()", Application.ProductName);
                    return false;
                }
            }

            private bool isInitializingComponent;

            private void Form_Load()
            {
                try
                {
                    //Screen.MousePointer = vbHourglass
                    //Me.Left = (CORMDIBN.ScaleWidth - Me.Width) / 2
                    //Me.Top = (CORMDIBN.ScaleHeight - Me.Height) / 2
                    this.Cursor = Cursors.WaitCursor;
                    this.Left = (int)VB6.TwipsToPixelsX(CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2;
                    this.Top = (int)VB6.TwipsToPixelsY(CORMDIBN.DefInstance.ClientRectangle.Height - this.Height) / 2;

                    //txtLog = NullString
                    txtLog.Text = String.Empty;

                    //With lvwCuentas.ColumnHeaders
                    //    .Add , , "Cuenta"
                    //    .Item(.Count).Width = 1770
                    //    .Add , , "Cuentahabiente"
                    //    .Item(.Count).Width = 1985
                    //    .Add , , "Maker"
                    //    .Item(.Count).Width = 2880
                    //    .Add , , "Nómina"
                    //    .Item(.Count).Width = 900
                    //    .Add , , "Fecha"
                    //    .Item(.Count).Width = 1050
                    //    .Add , , "Hora"
                    //    .Item(.Count).Width = 585
                    //    .Add , , "Tipo"
                    //    .Item(.Count).Width = 1155
                    //    .Add , , "Hijas a Canc"
                    //    .Item(.Count).Width = 1125
                    //    .Item(8).Alignment = lvwColumnRight
                    //End With

                    object tempRefParam = Type.Missing;
                    object tempRefParam2 = Type.Missing;
                    object tempRefParam3 = "Cuenta";
                    object tempRefParam4 = Type.Missing;
                    object tempRefParam5 = Type.Missing;
                    object tempRefParam6 = Type.Missing;
                    MSComctlLib.ColumnHeader ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    object tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1770);
                    tempRefParam3 = "Cuentahabiente";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1985);
                    tempRefParam3 = "Maker";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(2880);
                    tempRefParam3 = "Nómina";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(900);
                    tempRefParam3 = "Fecha";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1050);
                    tempRefParam3 = "Hora";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(585);
                    tempRefParam3 = "Tipo";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1155);
                    tempRefParam3 = "Hijas a Canc";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1125);

                    clsCancelaciones mcncCancelaciones = new clsCancelaciones();

                    mcncCancelaciones.Class_Initialize();

                    mprActivarBotones(false);

                    if (!mcncCancelaciones.fnConectarB())
                    {
                        MessageBox.Show("No fue posible firmarse a los sistemas centrales." + "\r\n" +
                                "Si el problema persiste avise a su administrador de redes.", Application.ProductName);
                        mcncCancelaciones.Class_Terminate();
                        mcncCancelaciones = null;
                        this.Cursor = Cursors.Default;
                        //this.Close();
                        return;
                    }

                    mprLog(mcncCancelaciones.TransLogS);

                    if (!mcncCancelaciones.fnLlenarEstadosB())
                    {
                        MessageBox.Show("No fue posible acceder al catálogo de situaciones de cuenta, reintente la operación más tarde." +
                                "\r\n" + "Si el problema persiste comuníquese con su administrador de sistemas.", Application.ProductName);
                        mcncCancelaciones.Class_Terminate();
                        mcncCancelaciones = null;
                        txtLog.Text = String.Empty;
                        this.Cursor = Cursors.Default;
                        //this.Close();
                        return;
                    }

                    mprLog(mcncCancelaciones.TransLogS);

                    if (!mfnCargarMallaB())
                    {
                        mcncCancelaciones.Class_Terminate();
                        mcncCancelaciones = null;
                        txtLog.Text = String.Empty;
                        this.Cursor = Cursors.Default;
                        //this.Close();
                        return;
                    }

                    mprActivarBotones(true);
                    this.Cursor = Cursors.Default;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió el siguiente error en el proceso:" + "\r\n" + "Número: " + Information.Err().Number + "\r\n" +
                            "Descripcion: " + Information.Err().Description + "\r\n" + "Origen: " + Information.Err().Source + "\r\n" +
                            "Módulo: frmCancAutoriz::Load()", Application.ProductName);
                    mcncCancelaciones.Class_Terminate();
                    mcncCancelaciones = null;
                    this.Cursor = Cursors.Default;
                    //this.Close();
                }
            }

            private void Form_QueryUnload(int Cancel, int UnloadMode)
            {
                numboton = 7; //Actualizar
                if ((UnloadMode == 0) && (!tbrStandar.Buttons.get_Item(ref numboton).Enabled))
                {
                    Cancel = -1; //false
                }
            }

            private void Form_Unload(int Cancel)
            {
                try 
	            {	        
                    mprActivarBotones(false);
            		mcncCancelaciones.fnDesconectarB();
                    //'    If Not mcncCancelaciones.fnDesconectarB Then MsgBox "No fue posible desconectarse de los sistemas centrales." & _
                    //'                        vbNewLine & "Avise del problema a su administrador de redes."
                    //'
                    //'    Set mcncCancelaciones = Nothing

	            }
	            catch (Exception)
	            {
	            }
            }

            private void lvwCuentas_ColumnClick(Object eventSender,  AxMSComctlLib.ListViewEvents_ColumnClickEvent eventArgs)
            {
                lvwCuentas.Sorted = true;

                if (lvwCuentas.SortKey == eventArgs.columnHeader.SubItemIndex)
                {
                    if (lvwCuentas.SortOrder == MSComctlLib.ListSortOrderConstants.lvwAscending)
                    {
                        lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwDescending;
                    }
                    else
                    {
                        lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwAscending;
                    }
                }
                else
                {
                    lvwCuentas.SortKey = (short)eventArgs.columnHeader.SubItemIndex;
                    lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwAscending;
                }
                
                if (lvwCuentas.ListItems.Count > 0)
                {
                    lvwCuentas.SelectedItem.EnsureVisible();
                }
            }

            private void lvwCuentas_DblClick()
            {
            //'Dim i As Integer
            //'
            //'    With lvwCuentas.ColumnHeaders
            //'        For i = 1 To .Count
            //'           mprLog .Item(i).Text & " - " & .Item(i).Width & vbNewLine
            //'        Next i
            //'    End With
            //'    mprLog lvwCuentas.SelectedItem.Key & vbNewLine
            }

            private void tbrStandar_ButtonClick(Object eventSender,  AxMSComctlLib.IToolbarEvents_ButtonClickEvent e)
            {
                int plId; int piEjeTam;
                clsCancelaciones.enmCancelacionTipos peTipo;
                string psAux; int piPosIni; int piPosFin;
                string psModulo;
                int I;
                object tempRefParam1;

                try 
	            {	        
                    switch (e.button.Key)
                    {
                        case "Actualizar":
                            psModulo = "Actualizar";
                            this.Cursor = Cursors.WaitCursor;
                            mprActivarBotones(false);
                        
                            if (!mfnCargarMallaB())
                            {
                                this.Cursor = Cursors.Default;
                                mprActivarBotones(false);
                                return;
                            }
                            
                            mprActivarBotones(true);
                            this.Cursor = Cursors.Default;
                            break;
                        case "Autorizar":
                            psModulo = "Autorizar";
                            if (MessageBox.Show("¿Desea autorizar la ejecución de la(s) solicitud(es) de cancelación seleccionada(s)?", 
                                CORSTR.STR_APP_TIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            {
                                return;
                            }
                            
                            this.Cursor = Cursors.WaitCursor;
                            mprActivarBotones(false);
                            
                            for (I = 1; I <= lvwCuentas.ListItems.Count; I++)
                            {
                                tempRefParam1 = I;
                                if (lvwCuentas.ListItems.get_Item(ref tempRefParam1).Checked)
                                {
                                    psAux = lvwCuentas.ListItems.get_Item(ref tempRefParam1).Key;
                                    piPosIni = 3;
                                    piPosFin = psAux.IndexOf("_",piPosIni);
                                    plId = Int32.Parse(Strings.Mid(psAux, piPosIni, (piPosFin - piPosIni)));
                                    
                                    piPosIni = piPosFin + 1;
                                    piPosFin = psAux.IndexOf("_",piPosIni);
                                    piEjeTam = Int32.Parse(Strings.Mid(psAux, piPosIni, (piPosFin - piPosIni)));
                                    
                                    peTipo = (clsCancelaciones.enmCancelacionTipos)MdlCambioMasivo.Nvl(Strings.Mid(psAux, (piPosFin + 1)), -1);
                                    
                                    mcncCancelaciones.EjeTamI = piEjeTam;
                                    mcncCancelaciones.CuentaS = lvwCuentas.ListItems.get_Item(ref tempRefParam1).Text;
                                    mcncCancelaciones.MakerNominaS = lvwCuentas.ListItems.get_Item(ref tempRefParam1).get_SubItems(3);
                                    
                                    if (!mcncCancelaciones.fnCkrCancelarCuentaB(plId, peTipo))
                                    {
                                        mprLog("No fue posible cancelar la cuenta " + mcncCancelaciones.CuentaS + "\r\n");
                                    }
                                    
                                    mprLog(mcncCancelaciones.TransLogS);
                                }
                            }
                            e.button.Key = "Actualizar";
                            tbrStandar_ButtonClick(eventSender, e);
                            break;
                        case "Declinar":
                            psModulo = "Declinar";
                            if (MessageBox.Show("¿Desea declinar la(s) solicitud(es) de cancelación seleccionada(s)?", 
                                CORSTR.STR_APP_TIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            {
                                return;
                            }
                            
                            this.Cursor = Cursors.WaitCursor;
                            mprActivarBotones(false);
                            
                            for (I = 1; I <= lvwCuentas.ListItems.Count;I++)
                            {
                                tempRefParam1 = I;
                                if (lvwCuentas.ListItems.get_Item(ref tempRefParam1).Checked)
                                {
                                    psAux = lvwCuentas.ListItems.get_Item(ref tempRefParam1).Key;
                                    piPosIni = 3;
                                    piPosFin = psAux.IndexOf("_",piPosIni);
                                    plId = Int32.Parse(Strings.Mid(psAux, piPosIni, (piPosFin - piPosIni)));
                                    
                                    piPosIni = piPosFin + 1;
                                    piPosFin = psAux.IndexOf("_",piPosIni);
                                    piEjeTam = Int32.Parse(Strings.Mid(psAux, piPosIni, (piPosFin - piPosIni)));
                                    
                                    mcncCancelaciones.EjeTamI = piEjeTam;
                                    mcncCancelaciones.CuentaS = lvwCuentas.ListItems.get_Item(ref tempRefParam1).Text;
                                    mcncCancelaciones.MakerNominaS = lvwCuentas.ListItems.get_Item(ref tempRefParam1).get_SubItems(3);
                                    
                                    if (!mcncCancelaciones.fnCkrCancelarSolicitudB(plId))
                                    {
                                        mprLog("No fue posible declinar la operacion sobre la cuenta " + mcncCancelaciones.CuentaS + "\r\n");
                                    }
                                    
                                    mprLog(mcncCancelaciones.TransLogS);
                                }
                            }
                            e.button.Key = "Actualizar";
                            tbrStandar_ButtonClick(eventSender, e);
                            break;
                        case "Ninguno":
                            psModulo = "Sel_Ninguno";
                            for (I = 1; I <= lvwCuentas.ListItems.Count;I++)
                            {
                                tempRefParam1 = I;
                                lvwCuentas.ListItems.get_Item(ref tempRefParam1).Checked = false;
                            }
                            break;
                        case "Todos":
                            psModulo = "Sel_Todos";
                            for (I = 1; I <= lvwCuentas.ListItems.Count;I++)
                            {
                                tempRefParam1 = I;
                                lvwCuentas.ListItems.get_Item(ref tempRefParam1).Checked = true;
                            }
                            break;
                    }
	            }
	            catch (Exception)
	            {
                    MessageBox.Show("Ocurrió el siguiente error en el proceso:" + "\r\n" + "Número: " + Information.Err().Number + "\r\n" +
                            "Descripcion: " + Information.Err().Description + "\r\n" + "Origen: " + Information.Err().Source + "\r\n" +
                            "Módulo: frmCancAutoriz::Load()", Application.ProductName);
                    e.button.Key = "Actualizar";
                    tbrStandar_ButtonClick(eventSender, e);
                    this.Cursor = Cursors.Default;
	            }
            }

    }
}