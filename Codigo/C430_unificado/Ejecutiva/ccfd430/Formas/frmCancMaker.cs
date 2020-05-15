using Artinsoft.VB6.Gui; 
using Artinsoft.VB6.Utils; 
using Microsoft.VisualBasic; 
using System; 
using System.Globalization; 
using System.Windows.Forms; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	internal partial class frmCancMaker
		: System.Windows.Forms.Form
		{

           object numboton;

           private void mprActivarBotones(bool abActivar)
            {
                    bool abVacio = false;

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
                        numboton = 2; //Ninguno
                        tbrStandar.Buttons.get_Item(ref numboton).Enabled = true;
                        numboton = 1; //Todos
                        tbrStandar.Buttons.get_Item(ref numboton).Enabled = true;
                        lvwCuentas.Enabled = true;
                    }
            }

            private bool mfnCargarMallaB()
            {
                clsCancelaciones cncCancelaciones = new clsCancelaciones();

                try 
	            {	        
                    lvwCuentas.ListItems.Clear();
                    lvwCuentas.Sorted = false;
                    lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwDescending;
                    
                    //'*:-------------------- 1 ------- 2 ------
                    CORVAR.pszgblsql = "SELECT cnc_id, cnc_cuenta, ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(yy, cnc_maker_fecha))))) tmp_anio, "; //'*: 3
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(mm, cnc_maker_fecha))))) tmp_mes, ";  //'*: 4
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(dd, cnc_maker_fecha))))) tmp_dia, ";  //'*: 5
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(hh, cnc_maker_fecha))))) tmp_hora, "; //'*: 5
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "(LTrim(RTrim(Str(datepart(mi, cnc_maker_fecha))))) tmp_min, ";  //'*: 7
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_tipo, cnc_cuentahabiente, cnc_num_ctas_hijas ";             //'*: 8, 9, 10
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCCNC01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE cnc_status=" + Conversion.Str(clsCancelaciones.enmCancelacionStatus.CST_SIN_REVISAR) + " AND ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_prefijo=" + mdlParametros.gprdProducto.PrefijoL.ToString() + " AND ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco=" + mdlParametros.gprdProducto.BancoL.ToString() + " AND ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_maker_usr='" + Seguridad.usugUsuario.NominaS.Trim() + "' ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "ORDER BY cnc_maker_fecha";
                    
                    CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);

                    if (CORPROC2.Obtiene_Registros() != 0) 
                    {
                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
							object tempRefParam = Type.Missing;
							object tempRefParam2 = "K" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 1), -1));
							object tempRefParam3 = Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 2), -1));
							object tempRefParam4 = Type.Missing;
							object tempRefParam5 = Type.Missing;
                            MSComctlLib.ListItem ListItem = lvwCuentas.ListItems.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5);
							object tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(1, Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 9), -1)));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            dtpAux.Year = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 3), -1)));
                            dtpAux.Month = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 4), -1)));
                            dtpAux.Day = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 5), -1)));
                            dtpAux.Hour = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 6), -1)));
                            dtpAux.Minute = Int32.Parse(Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 7), -1)));
                            ListItem.set_SubItems(2, Strings.Format(dtpAux, CRSParametros.cteFormatoFecha));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(3, Strings.Format(dtpAux, CRSParametros.cteFormatoHora));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(4, cncCancelaciones.fnTipoDescS((clsCancelaciones.enmCancelacionTipos)MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 8), -1)));
							tempRefParam6 = lvwCuentas.ListItems.Count;
                            ListItem.set_SubItems(5, Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 10), -1)));

                            //lvwCuentas.ListItems.Add , "K_" + Conversion.Str(CLng(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 1), -1))), Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 2), -1));
                            //lvwCuentas.ListItems.Item(lvwCuentas.ListItems.Count).SubItems(1) = Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 9), -1));
                            //lvwCuentas.ListItems.Item(lvwCuentas.ListItems.Count).SubItems(2) = Strings.Format(dtpAux, cteFormatoFecha);
                            //lvwCuentas.ListItems.Item(lvwCuentas.ListItems.Count).SubItems(3) = Strings.Format(dtpAux, cteFormatoHora);
                            //lvwCuentas.ListItems.Item(lvwCuentas.ListItems.Count).SubItems(4) = cncCancelaciones.fnTipoDescS(Int32.Parse(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 8), -1)));
                            //lvwCuentas.ListItems.Item(lvwCuentas.ListItems.Count).SubItems(5) = Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 10), -1));
                        }
                        
                        //lvwCuentas.ListItems(1).Selected = true;
                        object tempRefParam7 = 1;
                        lvwCuentas.ListItems.get_ControlDefault(ref tempRefParam7).Selected = true;

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No existen operaciones pendientes de revisión.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    cncCancelaciones = null;
                    CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            		
	            }
	            catch (Exception)
	            {
                    MessageBox.Show( "Ocurrió el siguiente error en el proceso:" + "\r\n" + "Número: " + Information.Err().Number + "\r\n" +
                            "Descripcion: " + Information.Err().Description + "\r\n" + "Origen: " + Information.Err().Source + "\r\n" +
                            "Módulo: frmCancMaker::mfnCargarMallaB::Click()", Application.ProductName);
                    cncCancelaciones = null;
                    return false;
	            }
            }

            private bool isInitializingComponent;

            private void Form_Load()
            {
                try 
	            {	        
                    this.Cursor = Cursors.WaitCursor;
                    //this.Left = (CORMDIBN.ScaleWidth - this.Width) / 2;
                    //this.Top = (CORMDIBN.ScaleHeight - this.Height) / 2;
                    this.Left = (int)VB6.TwipsToPixelsX(CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2;
                    this.Top = (int)VB6.TwipsToPixelsY(CORMDIBN.DefInstance.ClientRectangle.Height - this.Height) / 2;
                    
                    //lvwCuentas.ColumnHeaders.ColumnHeaders.Add , , "Cuenta"
                    //lvwCuentas.ColumnHeaders.Item(lvwCuentas.ColumnHeaders.Count).Width = 1890
                    //lvwCuentas.ColumnHeaders.Add , , "Cuentahabiente"
                    //lvwCuentas.ColumnHeaders.Item(lvwCuentas.ColumnHeaders.Count).Width = 2910
                    //lvwCuentas.ColumnHeaders.Add , , "Fecha"
                    //lvwCuentas.ColumnHeaders.Item(lvwCuentas.ColumnHeaders.Count).Width = 1140
                    //lvwCuentas.ColumnHeaders.Add , , "Hora"
                    //lvwCuentas.ColumnHeaders.Item(lvwCuentas.ColumnHeaders.Count).Width = 675
                    //lvwCuentas.ColumnHeaders.Add , , "Tipo"
                    //lvwCuentas.ColumnHeaders.Item(lvwCuentas.ColumnHeaders.Count).Width = 1245
                    //lvwCuentas.ColumnHeaders.Add , , "Hijas a Canc"
                    //lvwCuentas.ColumnHeaders.Item(lvwCuentas.ColumnHeaders.Count).Width = 1125
                    //lvwCuentas.ColumnHeaders.Item(6).Alignment = lvwColumnRight
                    
                    object tempRefParam = Type.Missing;
                    object tempRefParam2 = Type.Missing;
                    object tempRefParam3 = "Cuenta";
                    object tempRefParam4 = Type.Missing;
                    object tempRefParam5 = Type.Missing;
                    object tempRefParam6 = Type.Missing;
                    MSComctlLib.ColumnHeader ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    object tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1890);
                    tempRefParam3 = "Cuentahabiente";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(2910);
                    tempRefParam3 = "Fecha";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1140);
                    tempRefParam3 = "Hora";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(675);
                    tempRefParam3 = "Tipo";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1245);
                    tempRefParam3 = "Hijas a Canc";
                    ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                    tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                    ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1125);
                    //ColumnHeader.Alignment = lvwColumnRight;

                    mprActivarBotones(false);

                    if (!mfnCargarMallaB()) 
                    {
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
                            "Módulo: frmCancMaker::Load()", Application.ProductName);
                    this.Cursor = Cursors.Default;
                    //this.Close();
	            }
            }

            private void Form_QueryUnload(int Cancel, int UnloadMode)
            {
                numboton = 1; //Todos
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
            		
	            }
	            catch (Exception)
	            {
	            }
            }

            //private void lvwCuentas_ColumnClick(MSComctlLib.ColumnHeader ColumnHeader)
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
                int I;
                string sAux = "";
                
                for (I = 1; I <= lvwCuentas.ColumnHeaders.Count; I++)
                {
                   object tempRefParam = I;
                   sAux = sAux + lvwCuentas.ColumnHeaders.get_Item(ref tempRefParam).Text + " - " + lvwCuentas.ColumnHeaders.get_Item(ref tempRefParam).Width + "\r\n";
                }
                
                //Debug.Print(sAux);
            }

            //private void tbrStandar_ButtonClick(MSComctlLib.Button Button)
            private void tbrStandar_ButtonClick(Object eventSender,  AxMSComctlLib.IToolbarEvents_ButtonClickEvent e)
            {
                string psAux = "";
                string psModulo = "";
                int I;
                object tempRefParam1;

                try 
	            {	        
                    switch(e.button.Key)
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
                    case "Aceptar":
                        psModulo = "Aceptar";
                        if (MessageBox.Show("¿Desea enviar al checker la(s) solicitud(es) de cancelación seleccionada(s)?", 
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
                                psAux = psAux + Strings.Mid(lvwCuentas.ListItems.get_Item(ref tempRefParam1).Key, 3) + ", ";
                            }
                        }
                        
                        if (psAux.Length > 0)
                        {
                            psAux = psAux.Substring(1,(psAux.Length - 2)) ;
                            CORVAR.pszgblsql = "UPDATE MTCCNC01 ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "SET cnc_status=" + Conversion.Str(clsCancelaciones.enmCancelacionStatus.CST_PENDIENTE) + " ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE " + "cnc_id IN(" + psAux + ")";
                        
                            CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                            
                            if (CORPROC2.Modifica_Registro() != 0) 
                            {
                                MessageBox.Show("La(s) solicitude(s) de cancelación de cuenta(s) se enviaron al checker correctamente.", 
                                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No fue posible enviar al checker las solicitudes de cancelación." + "\r\n" +
                                             "Reintente de nuevo más tarde.", Application.ProductName);
                            }
                        }
                        e.button.Key = "Actualizar";
                        tbrStandar_ButtonClick(eventSender, e);
                        break;
                    case "Cancelar":
                        psModulo = "Cancelar";
                        if (MessageBox.Show("¿Desea declinar la(s) solicitud(es) de cancelación seleccionada(s)?", 
                            CORSTR.STR_APP_TIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }                
                        for (I = 1; I <= lvwCuentas.ListItems.Count;I++)
                        {
                            tempRefParam1 = I;
                            if (lvwCuentas.ListItems.get_Item(ref tempRefParam1).Checked)
                            {
                                psAux = psAux + Strings.Mid(lvwCuentas.ListItems.get_Item(ref tempRefParam1).Key, 3) + ", ";
                            }
                        }
                        
                        if (psAux.Length > 0)
                        {
                            psAux = psAux.Substring(1,(psAux.Length - 2));
                            CORVAR.pszgblsql = "DELETE FROM MTCCNC01 ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE " + "cnc_id IN(" + psAux + ")";
                        
                            CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                            
                            if (CORPROC2.Modifica_Registro() != 0) 
                            {
                                MessageBox.Show("Se eliminaron correctamente la(s) solicitude(s) de cancelación de cuenta(s).", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No fue posible declinar las solicitudes de cancelación." + "\r\n" +
                                             "Reintente de nuevo más tarde.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                                
                        e.button.Key = "Actualizar";
                        tbrStandar_ButtonClick(eventSender, e);
                        break;
                    case "Ninguno":
                        psModulo = "Sel_Ninguno";
                        for (I = 1; I <= lvwCuentas.ListItems.Count; I++)
                        {
                            tempRefParam1 = I;
                            lvwCuentas.ListItems.get_Item(ref tempRefParam1).Checked = false;
                        }
                        break;
                    case "Todos":
                        psModulo = "Sel_Todos";
                        for (I = 1; I <= lvwCuentas.ListItems.Count; I++)
                        {
                            tempRefParam1 = I;
                            lvwCuentas.ListItems.get_Item(ref tempRefParam1).Checked = true;
                        }
                        break;
                    }
            		
	            }
	            catch (Exception)
	            {
                    MessageBox.Show( "Ocurrió el siguiente error en el proceso:" + "\r\n" + "Número: " + Information.Err().Number + "\r\n" +
                            "Descripcion: " + Information.Err().Description + "\r\n" + "Origen: " + Information.Err().Source + "\r\n" +
                            "Módulo: frmCancMaker::btn" + psModulo + "::Click()", Application.ProductName);
                    e.button.Key = "Actualizar";
                    tbrStandar_ButtonClick(eventSender, e);
                    this.Cursor = Cursors.Default;
	            }
            }

    }
}