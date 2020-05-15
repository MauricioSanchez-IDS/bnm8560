using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	internal partial class frmAutAltasMasivas
		: System.Windows.Forms.Form
		{

            private bool bmHayReg;
            private pryActualizaS111.ClsConectaS111 conS111;
            private string[] smdatosCuenta;

            private void pActualizarpantalla()
            {
                Cursor.Current = Cursors.WaitCursor;
                    
                if (!fnLlenaTabla())
                {
                    bmHayReg = false;
                    Cursor.Current = Cursors.Default;
                    return;
                }
                else
                {
                    bmHayReg = true;
                }
                Cursor.Current = Cursors.Default;
            }

            private void pDeselTodas()
            {
                int i;

                for (i = 1; i <= lvwCuentas.ListItems.Count; i++)
                {
                    //lvwCuentas.ListItems.Item[i].CHECKED = false;
                    object tempRefParam = i;
                    lvwCuentas.ListItems.get_Item(ref tempRefParam).Checked = false;
                }
            }

            private void pSelTodas()
            {
                int i;

                for (i = 1; i <= lvwCuentas.ListItems.Count; i++)
                {
                    //lvwCuentas.ListItems.Item[i].CHECKED = true;
                    object tempRefParam = i;
                    lvwCuentas.ListItems.get_Item(ref tempRefParam).Checked = true;
                }
            }

            private bool isInitializingComponent;

            private void Form_Load()
            {
                Cursor.Current = Cursors.WaitCursor;
                //this.Left = (CORMDIBN.ScaleWidth - this.Width) / 2;
                //this.Top = (CORMDIBN.ScaleHeight - this.Height) / 2;
                this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
                this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

                this.lvwCuentas.Width = this.Width - 20;
                this.txtLog.Width = this.Width - 20;
                //'txtLog = vbNullString
                           
                pCargaEncabezados();
                
                if (!fnLlenaTabla())
                {
                    bmHayReg = false;
                    Cursor.Current = Cursors.Default;
                }
            //'        MsgBox "No existen altas masivas por autorizar", vbInformation, App.ProductName
            //'        Unload Me
                else
                {
                    bmHayReg = true;
                    //mdlAltasMasivas.slCuentasAutorizar = Array[0];
                    Cursor.Current = Cursors.Default;
                }

            }

            private void pCargaEncabezados()
            {
				object tempRefParam1 = Type.Missing;
				object tempRefParam2 = Type.Missing;
				object tempRefParam4 = Type.Missing;
				object tempRefParam5 = Type.Missing;
				object tempRefParam6 = Type.Missing;

                //lvwCuentas.ColumnHeaders.Add , , " ";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 500;
				object tempRefParam3 = " ";
                MSComctlLib.ColumnHeader ColumnHeader  = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
				object tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int) VB6.TwipsToPixelsX(500);

                //lvwCuentas.ColumnHeaders.Add , , "Empresa";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 3500;
				tempRefParam3 = "Empresa";
                ColumnHeader  = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
				tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int) VB6.TwipsToPixelsX(3500);

                //lvwCuentas.ColumnHeaders.Add , , "Cuenta de la Empresa";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 2000;
                tempRefParam3 = "Cuenta de la Empresa";
                ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int)VB6.TwipsToPixelsX(2000);

                //lvwCuentas.ColumnHeaders.Add , , "Tarjetahabiente";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 3500;
                tempRefParam3 = "Tarjetahabiente";
                ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int)VB6.TwipsToPixelsX(3500);

                //lvwCuentas.ColumnHeaders.Add , , "Tope";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 900;
                tempRefParam3 = "Tope";
                ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int)VB6.TwipsToPixelsX(900);

                //lvwCuentas.ColumnHeaders.Add , , "Porcentaje de Disposición";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 2500;
                tempRefParam3 = "Porcentaje de Disposición";
                ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int)VB6.TwipsToPixelsX(2500);

                //lvwCuentas.ColumnHeaders.Add , , "Maker";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 3500;
                tempRefParam3 = "Maker";
                ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int)VB6.TwipsToPixelsX(3500);

                //lvwCuentas.ColumnHeaders.Add , , "Nomina";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 1250;
                tempRefParam3 = "Nomina";
                ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1250);

                //lvwCuentas.ColumnHeaders.Add , , "Fecha";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 1200;
                tempRefParam3 = "Fecha";
                ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1200);

                //lvwCuentas.ColumnHeaders.Add , , "Hora";
                //lvwCuentas.ColumnHeaders.Item[lvwCuentas.ColumnHeaders.Count].Width = 1000;
                tempRefParam3 = "Hora";
                ColumnHeader = lvwCuentas.ColumnHeaders.Add(ref tempRefParam1, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5, ref tempRefParam6);
                tempRefParam7 = lvwCuentas.ColumnHeaders.Count;
                ColumnHeader.Width = (int)VB6.TwipsToPixelsX(1000);
            }

            private bool fnLlenaTabla()
            {
                try 
	            {	        
                    int i;
                    
                    lvwCuentas.ListItems.Clear();
                    lvwCuentas.Sorted = false;
                    lvwCuentas.SortOrder = MSComctlLib.ListSortOrderConstants.lvwDescending;
                    
                    
                    CORVAR.pszgblsql = "SELECT convert(char(4),msv.eje_prefijo)+convert(char(2),msv.gpo_banco)+replicate('0',5-char_length(convert(varchar(5),msv.emp_num)))+convert(varchar(5),msv.emp_num)+replicate('0',3-char_length(convert(varchar(3),'0')))+convert(varchar(3),'0')+convert(char(1),eje.eje_roll_over)+convert(char(1),eje.eje_digit) as cuenta,";
                    //'                                           2                3            4           5               6                7            8                  9                  10              11                                    12                                            13
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "msv.eje_prefijo,msv.gpo_banco,msv.emp_num,msv.eje_nom_gra,emp.emp_nom_graba,msv.eje_rfc,msv.eje_limcred,msv.eje_lim_dis_efec,msv.eje_maker_nom,msv.eje_maker_num,convert(varchar(10),msv.eje_fec_maker,103) as fecha,convert(varchar(10),msv.eje_fec_maker,108) as hora";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCMSM02 msv ,MTCEJE01 eje,MTCEMP01 emp";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " msv.eje_prefijo=eje.eje_prefijo and msv.gpo_banco=eje.gpo_banco and msv.emp_num=eje.emp_num and eje.eje_num=0";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp.eje_prefijo=eje.eje_prefijo and emp.gpo_banco=eje.gpo_banco and emp.emp_num=eje.emp_num";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and msv.eje_status_reg=0";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and msv.eje_prefijo=" + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and msv.gpo_banco=" + mdlParametros.gprdProducto.BancoL.ToString();
					
                    CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);

					if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        i = 0;
                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                                i = i + 1;
                                //lvwCuentas.ListItems.Add , Conversion.Str(MdlCambioMasivo.Nvl(SqlData(hgblConexion, 2), "")) + "|" + CStr(Nvl(SqlData(hgblConexion, 3), "")) + "|" + CStr(Nvl(SqlData(hgblConexion, 4), "")) + "|" + CStr(Nvl(SqlData(hgblConexion, 7), "")) + "|" + Trim(CStr(Nvl(SqlData(hgblConexion, 5), ""))) + "|" + Trim(CStr(Nvl(SqlData(hgblConexion, 6), ""))) + "|" + Trim(CStr(Nvl(SqlData(hgblConexion, 11), ""))) + "|" + CStr(i);
								object tempRefParam = Type.Missing;
                                //object tempRefParam2 = Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 2), "")) + "|" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 3), "")) + "|" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 4), "")) + "|" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 7), "")) + "|" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 5), "")).Trim() + "|" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 6), "")).Trim() + "|" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 11), "")).Trim() + "|" + Conversion.Str(i);
                                object tempRefParam2 = Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 2), "")) + "|" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 3), "")) + "|" + Conversion.Str(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 4), "")) + "|" + MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 7), "") + "|" + MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 5), "") + "|" + MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 6), "") + "|" + MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 11), "") + "|" + Conversion.Str(i);
								object tempRefParam3 = Type.Missing;
                                object tempRefParam4 = Type.Missing;
								object tempRefParam5 = Type.Missing;
                                MSComctlLib.ListItem ListItem = lvwCuentas.ListItems.Add(ref tempRefParam, ref tempRefParam2, ref tempRefParam3, ref tempRefParam4, ref tempRefParam5);

                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(1) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 6), ""))
								object tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(1, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 6), ""));
                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(2) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 1), ""))
                                tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(2, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 1), ""));
                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(3) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 5), ""))
                                tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(3, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 5), ""));
                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(4) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 8), ""))
                                tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(4, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 8), ""));
                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(5) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 9), ""))
                                tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(5, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 9), ""));
                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(6) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 10), ""))
                                tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(6, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 10), ""));
                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(7) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 11), ""))
                                tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(7, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 11), ""));
                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(8) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 12), ""))
                                tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(8, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 12), ""));
                                //lvwCuentas.ListItems.Item[lvwCuentas.ListItems.Count].SubItems(9) = Conversion.Str(Nvl(SqlData(CORVAR.hgblConexion, 13), ""))
                                tempRefParam6 = lvwCuentas.ListItems.Count;
                                ListItem.set_SubItems(9, mdlParametros.fncValorOmisionV(VBSQL.SqlData(CORVAR.hgblConexion, 13), ""));
                        }
                        
                        //lvwCuentas.ListItems[1].Selected = true;
                        object tempRefParam7 = 1;
                        lvwCuentas.ListItems.get_ControlDefault(ref tempRefParam7).Selected = true;

                        return true;
                    }
                    else
                //'        MsgBox "No existen altas masivas por autorizar", vbInformation, App.ProductName
                    {
                        return false;
                    }

                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    
	            }
	            catch (Exception)
	            {
                    MessageBox.Show("Ocurrió el siguiente error en el proceso: " + "\r\n" + "Número: " + Information.Err().Number + "\r\n" +
                            "Descripcion: " + Information.Err().Description + "\r\n" + "Origen: " + Information.Err().Source + "\r\n" + "Módulo: frmAutAltasMasivas", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
	            }
            }

            private void lvwCuentas_ColumnClick(Object eventSender, AxMSComctlLib.ListViewEvents_ColumnClickEvent eventArgs)
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


            private void tbrStandar_ButtonClick(Object eventSender,  AxMSComctlLib.IToolbarEvents_ButtonClickEvent eventArgs)
            {
            try 
            {	        
                int i;
                int cont;
                string Msg;
                string eje_prefijo;
                string gpo_banco;
                string emp_num;
                string eje_rfc;
                object datosCuenta;
                object tempRefParam4;

                if (!(bmHayReg && eventArgs.button.Key.ToString() != "Actualizar"))
                {
                    return;
                }

                switch (eventArgs.button.Key.ToString())
                {
                    case "Todo":
                    pSelTodas();
                    break;
                    case "Ninguno":
                    pDeselTodas();
                    break;
                    case "Autorizar":
                //'    Set conS111 = New ClsConectaS111
                //'    conS111.Usuario = usugUsuario.NominaS
                //'
                //'    If Not conS111.FnPreguntaPwd() Then
                //'        MsgBox "No se puede establecer enlace al Sistema S111." & conS111.LeyendaS
                //'        Exit Sub
                //'    End If
                //'
                //'    conS111.FnDesconectarS111

                    //mdlAltasMasivas.slCuentasAutorizar = Array[0];
                    mdlAltasMasivas.slCuentasAutorizar[0] = "";
                    Cursor.Current = Cursors.WaitCursor;
                        
                    int ilEtapa = 0;
                    cont = 0;
                    for (i = 1; i <= lvwCuentas.ListItems.Count; i++)
                    {
                        //if (lvwCuentas.ListItems.Item[i].CHECKED)
						tempRefParam4 = i;
						if (lvwCuentas.ListItems.get_Item(ref tempRefParam4).Checked)
                        {
                            //ReDim Preserve slCuentasAutorizar[cont];
                            mdlAltasMasivas.slCuentasAutorizar = ArraysHelper.RedimPreserve<string[]>(mdlAltasMasivas.slCuentasAutorizar, new int[] {cont + 1});
                            tempRefParam4 = i;
                            //mdlAltasMasivas.slCuentasAutorizar[cont] = lvwCuentas.ListItems.Item[i].Key;
                            mdlAltasMasivas.slCuentasAutorizar[cont] = lvwCuentas.ListItems.get_Item(ref tempRefParam4).Key;
                            cont = cont + 1;
                        }
                    }

                    if (mdlAltasMasivas.slCuentasAutorizar.GetUpperBound(0) == 0)
                    {
                        if (mdlAltasMasivas.slCuentasAutorizar[0] == "")
                        {
                            MessageBox.Show("Debe seleccionar al menos una cuenta", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                    }
                    
                //'    Msg = ""
                //'    For i = 0 To UBound(slCuentasAutorizar)
                //'        Msg = Msg & slCuentasAutorizar(i) + Chr(13)
                //'    Next i
                //'
                //'    MsgBox "lista: " + Msg
                    
                    Cursor.Current = Cursors.Default;
                    int ilTipoOperacion = 1;
                    frmAltasMasivas.DefInstance.Show();

                    break;
                    //'fnLlenaTabla

                //'INI: OLV 31ENE2005
                    case "Declinar":

                //'    Set conS111 = New ClsConectaS111
                //'    conS111.Usuario = usugUsuario.NominaS
                //'    If Not conS111.FnPreguntaPwd() Then
                //'        MsgBox "No se puede establecer enlace al Sistema S111." & conS111.LeyendaS
                //'        Exit Sub
                //'    End If
                //'    conS111.FnDesconectarS111

                    //mdlAltasMasivas.slCuentasAutorizar = Array[0];
                    mdlAltasMasivas.slCuentasAutorizar[0] = "";
                    Cursor.Current = Cursors.WaitCursor;
                        
                    ilEtapa = 0;
                    cont = 0;
                    for (i = 1; i <= lvwCuentas.ListItems.Count; i++)
                    {
                        //if (lvwCuentas.ListItems.Item[i].CHECKED)
						tempRefParam4 = i;
						if (lvwCuentas.ListItems.get_Item(ref tempRefParam4).Checked)
                        {
                            //ReDim Preserve slCuentasAutorizar[cont];
                            mdlAltasMasivas.slCuentasAutorizar = ArraysHelper.RedimPreserve<string[]>(mdlAltasMasivas.slCuentasAutorizar, new int[] {cont + 1});
                            //mdlAltasMasivas.slCuentasAutorizar[cont] = lvwCuentas.ListItems.Item[i].Key;
                            tempRefParam4 = i;
                            mdlAltasMasivas.slCuentasAutorizar[cont] = lvwCuentas.ListItems.get_Item(ref tempRefParam4).Key;

                            cont = cont + 1;
                        }
                    }

                    if (mdlAltasMasivas.slCuentasAutorizar.GetUpperBound(0) == 0)
                    {
                        if (mdlAltasMasivas.slCuentasAutorizar[0] == "")
                        {
                            MessageBox.Show("Debe seleccionar al menos una cuenta", "Tarjeta Ejecutiva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                    }
                    Cursor.Current = Cursors.WaitCursor;

                    bool respuesta;
                    respuesta = MessageBox.Show("¿Desea realmente declinar la ejecución del(los) registro(s) seleccionado(s)?", CORSTR.STR_APP_TIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
                    if (respuesta)
                    {
                         
                         txtLog.Text = "";
                         for (i = 0; i <= mdlAltasMasivas.slCuentasAutorizar.GetUpperBound(0); i++)
                         {

                             if (mdlAltasMasivas.slCuentasAutorizar[i] != "")
                             {
                                 smdatosCuenta = mdlAltasMasivas.slCuentasAutorizar[i].Split('|');
                                 eje_prefijo = Conversion.Str(smdatosCuenta[0]);
                                 gpo_banco = Conversion.Str(smdatosCuenta[1]);
                                 emp_num = Conversion.Str(smdatosCuenta[2]);
                                 eje_rfc = Conversion.Str(smdatosCuenta[3]);
                             
                                if (Seguridad.usugUsuario.NominaS == Conversion.Str(smdatosCuenta[6]).Trim())
                                {
                                    txtLog.Text = txtLog.Text + "El Checker no puede ser igual a Maker al declinar la cuenta del tarjetahabiente: " + Conversion.Str(smdatosCuenta[4]) + " de la empresa: " + Conversion.Str(smdatosCuenta[5]) + "\r\n";
                                }
                                else
                                {
                                    //'Borra el registro seleccionado
                                    CORVAR.pszgblsql = "delete ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCMSM02 ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "where eje_prefijo = " + eje_prefijo + " ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_banco = " + gpo_banco + " ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "and emp_num = " + emp_num + " ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "and eje_rfc = '" + eje_rfc + "'";
                                    if (CORPROC2.Modifica_Registro() != 0)
                                    {   
                                        txtLog.Text = txtLog.Text + "Se declino la cuenta del tarjetahabiente: " + Conversion.Str(smdatosCuenta[4]) + " de la empresa: " + Conversion.Str(smdatosCuenta[5]) + "\r\n";
                                    }
                                    else
                                    {
                                      MessageBox.Show ("No se elimino el registro de Altas Masivas");
                                    }
                                }
                             }
                         }
                    pActualizarpantalla();
                }
                    Cursor.Current = Cursors.Default;
                    return;
                //'FIN: OLV 31ENE2005

                    case "Actualizar":
                    pActualizarpantalla();
                    break;
                }

	        }
	        catch 
	        {
                MessageBox.Show( "Ocurrió el siguiente error en el proceso:" + "\r\n" + "Número: " + Information.Err().Number + "\r\n" +
                        "Descripcion: " + Information.Err().Description + "\r\n" + "Origen: " + Information.Err().Source + "\r\n" +
                        "Módulo: frmAutAltasMasivas::tbrStandar_ButtonClick", Application.ProductName);
                //'Resume 0
                return;
                Cursor.Current = Cursors.Default;
	        }
            }

		}
}