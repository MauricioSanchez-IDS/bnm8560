using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class frm_reportes
        : System.Windows.Forms.Form
    {

        private void frm_reportes_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        const int INT_MAX_EDO = 999;
        int lEstruc_Gastos = 0;
        int lTotalEdo = 0;
        int iRenCat = 0;
        int iRenRep = 0;
        string sRep_ID = String.Empty;
        string sRep_Name = String.Empty;
        string sFreq = String.Empty;
        string sGen = String.Empty;
        string sDetail = String.Empty;
        string sDepth = String.Empty;
        string sCat_Id = String.Empty;
        string sCat_Nombre = String.Empty;
        string sLimit = String.Empty;
        string sPor_Uso = String.Empty;
        bool bNivPadre = false;

        private void CMB_REPO_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(CMB_REPO, eventSender);
            int iCalif = 0;

            switch (Index)
            {
                case 0:  //Nombre Reporte 
                    //            If CMB_REPO(Index).Text = "" Then 
                    //                CMB_REPO(Index).SetFocus 
                    //            Else 
                    //                sRep_ID = Trim(CMB_REPO(Index).ItemData(CMB_REPO(Index).ListIndex)) 
                    //                sRep_Name = Trim(CMB_REPO(Index).Text) 
                    //                If Mid$(sRep_Name, 40, 1) = "C" Then 
                    //                    sFreq = "C" 
                    //                Else 
                    //                    sFreq = "D" 
                    //                End If 
                    //'                CMB_REPO(1).SetFocus 
                    //            End If 

                    break;
                case 1:  //Frecuencia 
                    //            If CMB_REPO(Index).Text = "" Then 
                    //                CMB_REPO(Index).SetFocus 
                    //            Else 
                    //                iCalif = Val(CMB_REPO(Index).ItemData(CMB_REPO(Index).ListIndex)) 
                    //                Select Case iCalif 
                    //                    Case 1 
                    //                        sFreq = "Q" 
                    //                    Case 2 
                    //                        sFreq = "M" 
                    //                    Case 3 
                    //                        sFreq = "F" 
                    //                    Case 4 
                    //                        sFreq = "Y" 
                    //                    Case 5 
                    //                        sFreq = "C" 
                    //                    Case 6 
                    //                        sFreq = "A" 
                    //                    Case 7 
                    //                        sFreq = "D" 
                    //                End Select 
                    //                CMB_REPO(2).SetFocus 
                    //            End If 

                    break;
                case 2:  //Detalle 
                    //            If CMB_REPO(Index).Text = "" Then 
                    //                CMB_REPO(Index).SetFocus 
                    //            Else 
                    //                iCalif = Val(CMB_REPO(Index).ItemData(CMB_REPO(Index).ListIndex)) 
                    //                Select Case iCalif 
                    //                    Case 1 
                    //                        sDetail = "S" 
                    //                    Case 2 
                    //                        sDetail = "D" 
                    //                    Case 3 
                    //                        sDetail = "T" 
                    //                End Select 
                    //                CMB_REPO(3).SetFocus 
                    //            End If 

                    break;
                case 3:  //Profundidad 
                    //            If CMB_REPO(Index).Text = "" Then 
                    //                CMB_REPO(Index).SetFocus 
                    //            Else 
                    //                iCalif = Val(CMB_REPO(Index).ItemData(CMB_REPO(Index).ListIndex)) 
                    //                Select Case iCalif 
                    //                    Case 1 
                    //                        sDepth = "1" 
                    //                    Case 2 
                    //                        sDepth = "2" 
                    //                    Case 3 
                    //                        sDepth = "3" 
                    //                End Select 
                    //            End If 
                    break;
            }
        }

        private void CMD_ACT_REP_Click(Object eventSender, EventArgs eventArgs)
        {

            //Dim i As Integer
            //Dim s As String
            //Dim reg As Integer
            //
            //    If CHK_REP.Value = 1 Then
            //        If sRep_ID <> "" And sRep_Name <> "" And sFreq <> "" Then 'And sDetail <> "" And sDepth <> "" Then
            //
            //            pszgblsql = "select"
            //            pszgblsql = pszgblsql & " report_id,"
            //            pszgblsql = pszgblsql & " report_name,"
            //            pszgblsql = pszgblsql & " report_ind_struct,"
            //            pszgblsql = pszgblsql & " supported_frequencies"
            //'            pszgblsql = pszgblsql & " supported_detail,"
            //'            pszgblsql = pszgblsql & " supported_depth"
            //            pszgblsql = pszgblsql & " from MTCREP01"
            //            pszgblsql = pszgblsql & " where report_id = '" & sRep_ID & "'"
            //            pszgblsql = pszgblsql & " and report_name = '" & Trim(Mid(sRep_Name, 5, 30)) & "'"
            //            pszgblsql = pszgblsql & " and supported_frequencies = '" & sFreq & "'"
            //'           pszgblsql = pszgblsql & " and supported_detail = '" & sDetail & "'"
            //'            pszgblsql = pszgblsql & " and supported_depth = '" & sDepth & "'"
            //
            //            reg = Cuenta_Registros
            //            If reg >= 1 Then
            //                If Obtiene_Registros Then
            //                    Do Until SqlNextRow(hgblConexion) = NOMOREROWS
            //                        sRep_ID = Trim(SqlData(hgblConexion, 1))
            //                        sRep_Name = SqlData(hgblConexion, 2)
            //                        sFreq = Trim(SqlData(hgblConexion, 4))
            //'                        sDetail = Trim(SqlData(hgblConexion, 5))
            //'                        sDepth = Trim(SqlData(hgblConexion, 6))
            //                        If Val(SqlData(hgblConexion, 3)) = 0 Then
            //                            For i = 0 To iRenRep - 1
            //                                LST_REPO(0).ListIndex = i
            //                                If Val(Left(LST_REPO(0).Text, 3)) = Val(sRep_ID) Then
            //                                    LST_REPO(0).RemoveItem (LST_REPO(0).ListIndex)
            //                                    If Val(sRep_ID) <= 9 Then
            //'                                        LST_REPO(0).AddItem Val(sRep_ID) & Space(5) & sRep_Name & Space(8) & "Y" & Space(8) & sFreq & Space(8) & sDetail & Space(8) & sDepth, i
            //                                        LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(5) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & "Y", i
            //                                    ElseIf Val(sRep_ID) >= 10 Then
            //'                                        LST_REPO(0).AddItem Val(sRep_ID) & Space(4) & sRep_Name & Space(8) & "Y" & Space(8) & sFreq & Space(8) & sDetail & Space(8) & sDepth, i
            //                                        LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(4) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & "Y", i
            //                                    End If
            //                                End If
            //
            //                            Next i
            //                        Else
            //                            pszgblsql = "select emp_estruct_gastos"
            //                            pszgblsql = pszgblsql & " from MTCEMP01"
            //                            pszgblsql = pszgblsql & " where eje_prefijo = " & igblPref
            //                            pszgblsql = pszgblsql & " and gpo_banco = " & igblBanco
            //                            pszgblsql = pszgblsql & " and emp_num = " & lgblNumEmpresa
            //                            igblRetorna = SqlCancel(hgblConexion)
            //                            If Cuenta_Registros >= 1 Then
            //                                For i = 0 To iRenRep - 1
            //                                    LST_REPO(0).ListIndex = i
            //                                    If Val(Left(LST_REPO(0).Text, 3)) = Val(sRep_ID) Then
            //                                        LST_REPO(0).RemoveItem (LST_REPO(0).ListIndex)
            //                                        If Val(sRep_ID) <= 9 Then
            //'                                            LST_REPO(0).AddItem Val(sRep_ID) & Space(5) & sRep_Name & Space(8) & "Y" & Space(8) & sFreq & Space(8) & sDetail & Space(8) & sDepth, i
            //                                            LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(5) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & "Y", i
            //                                        ElseIf Val(sRep_ID) >= 10 Then
            //'                                            LST_REPO(0).AddItem Val(sRep_ID) & Space(4) & sRep_Name & Space(8) & "Y" & Space(8) & sFreq & Space(8) & sDetail & Space(8) & sDepth, i
            //                                            LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(4) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & "Y", i
            //                                        End If
            //                                    End If
            //                                Next i
            //                            Else
            //                                Screen.MousePointer = vbDefault
            //                                MsgBox "Para poder dar de alta el reporte " & Trim(sRep_Name) & " se necesita que existan categorias.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
            //                                Exit Sub
            //                            End If
            //                        End If
            //                    Loop
            //                End If
            //                For i = 0 To 3
            //                    CMB_REPO.Item(i).ListIndex = -1
            //                Next i
            //                CMB_REPO.Item(0).SetFocus
            //                LST_REPO(0).ListIndex = -1
            //                CHK_REP.Value = 0
            //            ElseIf reg <= 0 Then
            //                MsgBox "No se encontro ninguna Calificación Similar a la que elegiste para este tipo de Reporte.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
            //                Exit Sub
            //            End If
            //        Else
            //            MsgBox "No se pueden Actualizar los datos porque falta algun dato.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
            //            Exit Sub
            //        End If
            //    ElseIf CHK_REP.Value = 0 Then
            //        MsgBox "No se pueden actualizar los datos porque el Botón de Generar no esta activado.", vbInformation + vbOKOnly, "Tarjeta Corporativa"
            //        Exit Sub
            //    End If

        }

        private void CHK_REP_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            if (CHK_REP.CheckState == CheckState.Checked)
            {
                CMD_ACT_REP.Enabled = true;
            }
            else if (CHK_REP.CheckState == CheckState.Unchecked)
            {
                CMD_ACT_REP.Enabled = false;
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int i = 0;
            int iCont = 0;
            string lstrEmp = String.Empty;
            string s = String.Empty;
            int reg = 0;

            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            txtTexto_Rep[0].Text = frm_men_rep.DefInstance.ID_CEE_EMP_COB.Text; //, igLongitudEmpresa + 4, 45)

            CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(Strings.Mid(txtTexto_Rep[0].Text, 1, 5)));

            txtTexto_Rep[0].Enabled = false;
            if (frm_men_rep.DefInstance.TipoReporteProcesar == frm_men_rep.EnTipoReporte.RptGrupoEmpresaUnidad || frm_men_rep.DefInstance.TipoReporteProcesar == frm_men_rep.EnTipoReporte.rptGrupoEmpresa)
            {
                txtTexto_Rep[1].Text = CORVAR.igblPref.ToString() + CORVAR.igblBanco.ToString() + StringsHelper.Format(Conversion.Val(frm_men_rep.DefInstance.ID_CEE_EMP_COB.Text.Substring(0, Math.Min(frm_men_rep.DefInstance.ID_CEE_EMP_COB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))).ToString().Trim(), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format("0", Formato.sMascara(Formato.iTipo.Ejecutivo)) + Formato.Formato_Cad_Roll_Digit();

            }
            else if (frm_men_rep.DefInstance.TipoReporteProcesar == frm_men_rep.EnTipoReporte.rptGrupoEmpresa)
            {

            }
            else
            {
                txtTexto_Rep[1].Text = "";

            }

            txtTexto_Rep[1].Enabled = false;
            txtTexto_Rep[2].Text = frm_men_rep.DefInstance.ID_CEE_GRU_COB.Text;
            txtTexto_Rep[2].Tag = Strings.Mid(frm_men_rep.DefInstance.ID_CEE_GRU_COB.Text, 1, 4);

            //Asigna los valores del encabezado de la forma
            switch (Formato.sgForma)
            {
                case "A":  //Altas 

                    if (Strings.Len(txtTexto_Rep[1].Text) < 16)
                    {
                        Formato.bgForma = false;
                        return;
                    }
                    else
                    {
                        Formato.bgForma = true;
                    }

                    mkbMaskebox_Rep[2].Format = "00";

                    CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(frm_men_rep.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));
                    if (frm_men_rep.DefInstance.TipoReporteProcesar == frm_men_rep.EnTipoReporte.RptGrupoEmpresaUnidad)
                    {
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + frm_men_rep.DefInstance.ID_CEE_UNI_COB.Text.Substring(0, Math.Min(frm_men_rep.DefInstance.ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)) + "'";

                        if (CORPROC2.Cuenta_Registros() > 0)
                        {
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {

                                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                {
                                    mkbMaskebox_Rep[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                    mkbMaskebox_Rep[0].Enabled = false;
                                    mkbMaskebox_Rep[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                                    mkbMaskebox_Rep[1].Enabled = false;
                                    mkbMaskebox_Rep[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                                    mkbMaskebox_Rep[2].Enabled = false;
                                };
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron los datos de la Unidad seleccionada", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            return;
                        }
                    }

                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct convert(int,report_id),";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " report_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " supported_frequencies";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCREP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where rep_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

                    if (CORPROC2.Cuenta_Registros() > 0)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {
                            iCont = 0;
                            iRenRep = 0;
                            LST_REPO[0].Items.Clear();

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                LST_REPO[0].Items.Add(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "#" + new String(' ', 6 - Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString().Length)) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 15) + ((VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim() == "C") ? "CYCLIC" : "DAILY ") + new String(' ', 13) + "N");
                                iCont++;
                                iRenRep++;
                            };
                        }
                    }


                    CMD_ACT_REP.Enabled = false;
                    this.Cursor = Cursors.Default;

                    break;
                case "B":  //Cambios 
                    ConsultaCalificacion();
                    break;
                case "C":
                    ConsultaCalificacion();
                    LST_REPO[0].Enabled = false;


                    //txtTexto_Rep.Item(0).Text = Mid(frm_men_rep.ID_CEE_EMP_COB.Text, igLongitudEmpresa + 4, 45) 
                    //txtTexto_Rep.Item(0).Enabled = False 
                    //txtTexto_Rep.Item(1).Text = igblPref & igblBanco & Format((Trim(Val(Left(frm_men_rep.ID_CEE_EMP_COB.Text, Len(sMascara(Empresa)))))), sMascara(Empresa)) & Format("0", sMascara(Ejecutivo)) & Formato_Cad_Roll_Digit 
                    //txtTexto_Rep.Item(1).Enabled = False 
                    // 
                    //     If Len(txtTexto_Rep.Item(1).Text) < 16 Then 
                    //          bgForma = False 
                    //         Exit Sub 
                    //     Else 
                    Formato.bgForma = true;
                    //    End If 

                    //    bgForma = True 
                    //    igblNumGrupo = Val(Mid(frm_men_rep.ID_CEE_GRU_COB.Text, 1, 4)) 

                    //   pszgblsql = "select" 
                    //   pszgblsql = pszgblsql & " unit_id," 
                    //   pszgblsql = pszgblsql & " unit_name," 
                    //   pszgblsql = pszgblsql & " nivel_num" 
                    //   pszgblsql = pszgblsql & " from MTCUNI01" 
                    //   pszgblsql = pszgblsql & " where eje_prefijo = " & igblPref 
                    //   pszgblsql = pszgblsql & " and gpo_banco = " & igblBanco 
                    //   pszgblsql = pszgblsql & " and emp_num = " & lgblNumEmpresa 
                    //   pszgblsql = pszgblsql & " and unit_id = '" & Left(frm_men_rep.ID_CEE_UNI_COB.Text, Len(sMascara(Unidad))) & "'" 
                    // 
                    //       If Cuenta_Registros > 0 Then 
                    //           If Obtiene_Registros Then 
                    //               Do Until SqlNextRow(hgblConexion) = NOMOREROWS 
                    //                   mkbMaskebox_Rep(0).Text = Trim(SqlData(hgblConexion, 1)) 
                    //                   mkbMaskebox_Rep(0).Enabled = False 
                    //                   mkbMaskebox_Rep(1).Text = Trim(SqlData(hgblConexion, 2)) 
                    //                   mkbMaskebox_Rep(1).Enabled = False 
                    //                   mkbMaskebox_Rep(2).Text = Val(SqlData(hgblConexion, 3)) 
                    //                   mkbMaskebox_Rep(2).Enabled = False 
                    //               Loop 
                    //           End If 
                    // 
                    //           pszgblsql = "select" 
                    //           pszgblsql = pszgblsql & " distinct convert(int,report_id)," 
                    //           pszgblsql = pszgblsql & " report_name," 
                    //           pszgblsql = pszgblsql & " supported_frequencies" 
                    //           pszgblsql = pszgblsql & " from MTCREP01" 
                    //           pszgblsql = pszgblsql & " where rep_tipo_prod = '" & gprdProducto.TipoProductoS & "'" 
                    // 
                    //           If Cuenta_Registros > 0 Then 
                    //               If Obtiene_Registros Then 
                    //                   iCont = 0 
                    //                   iRenRep = 0 
                    //                   LST_REPO.Item(0).Clear 
                    //                   Do Until SqlNextRow(hgblConexion) = NOMOREROWS 
                    //                       If Val(SqlData(hgblConexion, 1)) <= 9 Then 
                    //                           LST_REPO.Item(0).AddItem Val(SqlData(hgblConexion, 1)) & Space(5) & SqlData(hgblConexion, 2) & Space(15) & IIf(Trim(SqlData(hgblConexion, 3)) = "C", "CYCLIC", "DAILY ") & Space(13) & "N" 
                    //                       ElseIf Val(SqlData(hgblConexion, 1)) >= 10 Then 
                    //                           LST_REPO.Item(0).AddItem Val(SqlData(hgblConexion, 1)) & Space(4) & SqlData(hgblConexion, 2) & Space(15) & IIf(Trim(SqlData(hgblConexion, 3)) = "C", "CYCLIC", "DAILY ") & Space(13) & "N" 
                    //                       End If 
                    //                       iCont = iCont + 1 
                    //                       iRenRep = iRenRep + 1 
                    //                   Loop 

                    //                   pszgblsql = "select" 
                    //                   pszgblsql = pszgblsql & " a.report_id," 
                    //                   pszgblsql = pszgblsql & " b.report_name," 
                    //                   pszgblsql = pszgblsql & " a.reporting_freq," 
                    //                   pszgblsql = pszgblsql & " a.reporting_gen" 
                    //                   pszgblsql = pszgblsql & " from MTCURP01 a , MTCREP01 b" 
                    //                   pszgblsql = pszgblsql & " Where b.report_id = a.report_id" 
                    //                   pszgblsql = pszgblsql & " and a.eje_prefijo = " & gprdProducto.PrefijoL 
                    //                   pszgblsql = pszgblsql & " and a.gpo_banco = " & gprdProducto.BancoL 
                    //                   pszgblsql = pszgblsql & " and a.emp_num = " & lgblNumEmpresa 
                    //                   pszgblsql = pszgblsql & " and a.unit_id = '" & Trim(Left(frm_men_rep.ID_CEE_UNI_COB.Text, Len(sMascara(Unidad)))) & "'" 
                    // 
                    //                   reg = Cuenta_Registros 
                    // 
                    //                  If reg >= 1 Then 
                    //                      If Obtiene_Registros Then 
                    //                          Do Until SqlNextRow(hgblConexion) = NOMOREROWS 
                    //                              sRep_ID = Trim(SqlData(hgblConexion, 1)) 
                    //                              sRep_Name = SqlData(hgblConexion, 2) 
                    //                              sFreq = Trim(SqlData(hgblConexion, 3)) 
                    //                              sGen = Trim(SqlData(hgblConexion, 4)) 
                    // 
                    //                              For iCont = 0 To LST_REPO(0).ListCount 
                    //                                  LST_REPO(0).ListIndex = iCont 
                    //                                  If Trim(Left(LST_REPO(0).Text, 3)) = sRep_ID Then 
                    //                                      LST_REPO(0).RemoveItem (LST_REPO(0).ListIndex) 
                    //                                      If Val(sRep_ID) <= 9 Then 
                    //                                          LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(5) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & IIf(sGen = "Y", "Y", "N"), iCont 
                    //                                          Exit For 
                    //                                      ElseIf Val(sRep_ID) >= 10 Then 
                    //                                          LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(4) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & IIf(sGen = "Y", "Y", "N"), iCont 
                    //                                          Exit For 
                    //                                      End If 
                    //                                  End If 
                    //                              Next iCont 
                    //                          Loop 
                    //                      End If 
                    //                  End If 
                    //              End If 
                    //          End If 
                    //          LST_REPO(0).ListIndex = -1 
                    //          LST_REPO(0).Enabled = False 
                    //          ID_MEE_ALT_PB.Enabled = False 
                    //      Else 
                    //          MsgBox "No se encontraron los datos de la Unidad seleccionada", vbInformation + vbOKOnly, "Tarjeta Corporativa" 
                    //          Unload Me 
                    //      End If 
                    //      Screen.MousePointer = Default 

                    break;
            }

        }
        bool procesing = false;

        private void ID_MEE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            procesing = true;

            int modif = 0;
            string cad_Rep = String.Empty;
            string cad_Cat = String.Empty;
            StringBuilder strCriterio = new StringBuilder();
            strCriterio.Append(String.Empty);

            try
            {
                switch (Formato.sgForma)
                {

                    case "A":  //ALTA 
                        for (int i = 0; i <= iRenRep - 1; i++)
                        {
                            LST_REPO[0].SelectedIndex = i;
                            cad_Rep = LST_REPO[0].Text;
                            if (Strings.Mid(cad_Rep, 71, 1).Trim() == "Y")
                            {
                                CORVAR.pszgblsql = "insert into MTCURP01";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " (eje_prefijo,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " report_id,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_gen,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_freq,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_userid,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_date,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " last_upd_time)";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + CORVAR.igblPref.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblBanco.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox_Rep[0].CtlText.Trim() + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3)).Trim() + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 71, 1).Trim() + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 52, 1).Trim() + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserID + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20), getdate(),112))";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " + convert(int, datepart(mi,getdate())))";

                                if (CORPROC2.Modifica_Registro() == 1)
                                {
                                }
                            }
                        }
                        this.Close();

                        break;
                    case "B":  //CAMBIO 

                        for (int i = 0; i <= iRenRep - 1; i++)
                        {
                            LST_REPO[0].SelectedIndex = i;
                            cad_Rep = LST_REPO[0].Text;
                            //Determina si el registro actual existe y en su caso
                            //lo actualiza si ha sufrido algun cambio,
                            //en caso contrario lo da de alta
                            CORVAR.pszgblsql = "select";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " reporting_gen";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCURP01";
                            strCriterio = new StringBuilder("");
                            strCriterio.Append(" eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString());
                            strCriterio.Append(" and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString());
                            strCriterio.Append(" and report_type = " + ((int)frm_men_rep.DefInstance.TipoReporteProcesar).ToString());
                            strCriterio.Append(" and report_id = '" + cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3)).Trim() + "'");
                            switch (frm_men_rep.DefInstance.TipoReporteProcesar)
                            {
                                case frm_men_rep.EnTipoReporte.rptGrupo:
                                    //Filtrará las calificaciones del total del grupo 
                                    strCriterio.Append("and gpo_num = " + CORVAR.igblNumGrupo.ToString());
                                    if (frm_men_rep.DefInstance.ChkNivel.CheckState == CheckState.Checked)
                                    {
                                        strCriterio.Append(" and report_level = " + frm_men_rep.DefInstance.CboNivel.Text);
                                    }
                                    else
                                    {
                                        strCriterio.Append(" and report_level = 0");
                                        //strCriterio = strCriterio & " and unit_id = " & mkbMaskebox_Rep(0).Text
                                    }
                                    break;
                                case frm_men_rep.EnTipoReporte.rptGrupoEmpresa:
                                    //Filtrará las de la empresa 
                                    strCriterio.Append(" and emp_num = " + CORVAR.lgblNumEmpresa.ToString());

                                    if (frm_men_rep.DefInstance.ChkNivel.CheckState == CheckState.Checked)
                                    {
                                        strCriterio.Append(" and report_level = " + frm_men_rep.DefInstance.CboNivel.Text);
                                    }
                                    else
                                    {
                                        strCriterio.Append(" and report_level= 0 ");
                                        strCriterio.Append(" and unit_id = '" + mkbMaskebox_Rep[0].CtlText + "'");
                                    }
                                    break;
                                default:
                                    //Filtrará las de la unidad 
                                    strCriterio.Append(" and emp_num = " + CORVAR.lgblNumEmpresa.ToString());
                                    strCriterio.Append(" and unit_id = '" + frm_men_rep.DefInstance.ID_CEE_UNI_COB.Text.Substring(0, Math.Min(frm_men_rep.DefInstance.ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim() + "'");

                                    break;
                            }
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " Where " + strCriterio.ToString();
                            if (CORPROC2.Cuenta_Registros() >= 1)
                            {
                                if (CORPROC2.Obtiene_Registros() != 0)
                                {

                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        if (VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim() != Strings.Mid(cad_Rep, 71, 1).Trim())
                                        {
                                            //El dato existente en la base y el que se quiere actualizar son diferentes
                                            CORVAR.pszgblsql = "update MTCURP01";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " set reporting_gen = '" + Strings.Mid(cad_Rep, 71, 1).Trim() + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_userid = '" + CRSParametros.sgUserID + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_date = convert(int,convert(char(20),getdate(),112))";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", last_upd_time = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", gpo_num = " + Conversion.Val(txtTexto_Rep[2].Text).ToString().Trim();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " Where " + strCriterio.ToString();
                                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                            CORPROC2.Modifica_Registro();
                                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                                        }

                                    };
                                }
                            }
                            else
                            {
                                //No existe el registro por lo tanto se agrega
                                CORVAR.pszgblsql = "Insert into MTCURP01 (";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_prefijo,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "report_type,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "report_id,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "reporting_gen,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "reporting_freq,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "last_upd_userid,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "last_upd_date,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "last_upd_time,";

                                CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_num, ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "unit_id,";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "report_level ) ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " values ( ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + mdlParametros.gprdProducto.PrefijoL.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mdlParametros.gprdProducto.BancoL.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ((int)frm_men_rep.DefInstance.TipoReporteProcesar).ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + cad_Rep.Substring(0, Math.Min(cad_Rep.Length, 3)).Trim() + "'"; //Identificador del reporte
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 71, 1).Trim() + "'"; //Reporting_Gen
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + Strings.Mid(cad_Rep, 52, 1).Trim() + "'"; //Reporting_Freq
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSParametros.sgUserID + "'"; //last_upd_userid
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20), getdate(),112))"; // last_upd_date
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " + convert(int, datepart(mi,getdate()))"; //last_upd_time
                                switch (frm_men_rep.DefInstance.TipoReporteProcesar)
                                {
                                    case frm_men_rep.EnTipoReporte.rptGrupo:
                                        //Reporte agrupado por grupo 
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblNumGrupo.ToString();  //grupo 
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";  //No. Empresa no aplica 

                                        if (frm_men_rep.DefInstance.ChkNivel.CheckState == CheckState.Checked)
                                        {
                                            //No aplica numero de unidad pero si aplica nivel
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'0'"; //no aplica unidad
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + frm_men_rep.DefInstance.CboNivel.Text;
                                        }
                                        else
                                        {
                                            //Aplica unida pero nivel no lo aplica
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox_Rep[0].CtlText.Trim() + "'"; //No Unidad
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                                        }

                                        break;
                                    case frm_men_rep.EnTipoReporte.rptGrupoEmpresa:
                                        //Reporte agrupado por grupo-empresa 
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.igblNumGrupo.ToString();  //grupo 
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();
                                        if (frm_men_rep.DefInstance.ChkNivel.CheckState == CheckState.Checked)
                                        {
                                            //No aplica numero de unidad pero si aplica nivel
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'0'"; //no aplica unidad
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + frm_men_rep.DefInstance.CboNivel.Text;
                                        }
                                        else
                                        {
                                            //Aplica unida pero nivel no lo aplica
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox_Rep[0].CtlText.Trim() + "'"; //No Unidad
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                                        }
                                        break;
                                    default:
                                        //Reporte agrupado por Grupo-Empresa-Unidad 
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";  //No aplica el grupo 
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + "," + CORVAR.lgblNumEmpresa.ToString();  //aplica la empresa 
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mkbMaskebox_Rep[0].CtlText.Trim() + "'";  //No Unidad si aplica 
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";  //No aplica el nivel 
                                        break;
                                }
                                CORVAR.pszgblsql = CORVAR.pszgblsql + ")";
                                CORPROC2.Modifica_Registro();
                            }
                        }



                        //If Trim(Mid(cad_Rep, 71, 1)) = "Y" Then        'Si el Genera Reporte = 'Y' 
                        // 
                        //    pszgblsql = "select" 
                        //    pszgblsql = pszgblsql & " reporting_gen" 
                        //    pszgblsql = pszgblsql & " from MTCURP01" 
                        //    pszgblsql = pszgblsql & " where eje_prefijo = " & gprdProducto.PrefijoL 
                        //    pszgblsql = pszgblsql & " and gpo_banco = " & gprdProducto.BancoL 
                        //    If frm_men_rep.TipoReporteProcesar = RptGrupoEmpresaUnidad Then 
                        //        pszgblsql = pszgblsql & " and emp_num = " & lgblNumEmpresa 
                        //        pszgblsql = pszgblsql & " and unit_id = '" & Trim(Left(frm_men_rep.ID_CEE_UNI_COB.Text, Len(sMascara(Unidad)))) & "'" 
                        //        pszgblsql = pszgblsql & " and report_id = '" & Trim(Left(cad_Rep, 3)) & "'" 
                        //    Else 

                        //    End If 
                        //    If Cuenta_Registros >= 1 Then 
                        //        If Obtiene_Registros Then 
                        //            Do Until SqlNextRow(hgblConexion) = NOMOREROWS 
                        //                sGen = Trim(SqlData(hgblConexion, 1)) 
                        // 
                        //                If sGen <> Trim(Mid(cad_Rep, 71, 1)) Then 
                        // 
                        //                    pszgblsql = "update MTCURP01" 
                        //                    pszgblsql = pszgblsql & " set reporting_gen = '" & Trim(Mid(cad_Rep, 71, 1)) & "'" 
                        //                    pszgblsql = pszgblsql & ", last_upd_userid = '" & sgUserID & "'" 
                        //                    pszgblsql = pszgblsql & ", last_upd_date = convert(int,convert(char(20),getdate(),112))" 
                        //                    pszgblsql = pszgblsql & ", last_upd_time = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))" 
                        //                    pszgblsql = pszgblsql & " where eje_prefijo = " & gprdProducto.PrefijoL 
                        //                    pszgblsql = pszgblsql & " and gpo_banco = " & gprdProducto.BancoL 
                        //                    pszgblsql = pszgblsql & " and emp_num = " & lgblNumEmpresa 
                        //                    pszgblsql = pszgblsql & " and unit_id = '" & Trim(mkbMaskebox_Rep(0).Text) & "'" 
                        //                    pszgblsql = pszgblsql & " and report_id = '" & Trim(Left(cad_Rep, 3)) & "'" 
                        // 
                        //                    igblRetorna = SqlCancel(hgblConexion) 
                        //                    If Modifica_Registro Then 
                        //                    End If 
                        //               End If 
                        //           Loop 
                        //       End If 
                        //   Else 
                        // 
                        //       pszgblsql = "insert into MTCURP01" 
                        //       pszgblsql = pszgblsql & " (eje_prefijo," 
                        //       pszgblsql = pszgblsql & " gpo_banco," 
                        //       pszgblsql = pszgblsql & " emp_num," 
                        //       pszgblsql = pszgblsql & " unit_id," 
                        //       pszgblsql = pszgblsql & " report_id," 
                        //       pszgblsql = pszgblsql & " reporting_gen," 
                        //       pszgblsql = pszgblsql & " reporting_freq," 
                        //       pszgblsql = pszgblsql & " last_upd_userid," 
                        //       pszgblsql = pszgblsql & " last_upd_date," 
                        //       pszgblsql = pszgblsql & " last_upd_time)" 
                        //       pszgblsql = pszgblsql & " values" 
                        //       pszgblsql = pszgblsql & "(" & gprdProducto.PrefijoL 
                        //       pszgblsql = pszgblsql & "," & gprdProducto.BancoL 
                        //       pszgblsql = pszgblsql & "," & lgblNumEmpresa 
                        //       pszgblsql = pszgblsql & ",'" & Trim(mkbMaskebox_Rep(0).Text) & "'" 
                        //       pszgblsql = pszgblsql & ",'" & Trim(Left(cad_Rep, 3)) & "'" 
                        //       pszgblsql = pszgblsql & ",'" & Trim(Mid(cad_Rep, 71, 1)) & "'" 
                        //       pszgblsql = pszgblsql & ",'" & Trim(Mid(cad_Rep, 52, 1)) & "'" 
                        //       pszgblsql = pszgblsql & ",'" & sgUserID & "'" 
                        //       pszgblsql = pszgblsql & ", convert(int,convert(char(20), getdate(),112))" 
                        //       pszgblsql = pszgblsql & ", convert(int,datepart(hh,getdate())) * 100" 
                        //       pszgblsql = pszgblsql & " + convert(int, datepart(mi,getdate())))" 

                        //       igblRetorna = SqlCancel(hgblConexion) 
                        //       If Modifica_Registro Then 
                        //       End If 

                        //   End If 

                        // Else        'Si el Genera Reporte = 'N' 

                        //    pszgblsql = "select" 
                        //    pszgblsql = pszgblsql & " reporting_gen" 
                        //    pszgblsql = pszgblsql & " from MTCURP01" 
                        //    pszgblsql = pszgblsql & " where eje_prefijo = " & gprdProducto.PrefijoL 
                        //    pszgblsql = pszgblsql & " and gpo_banco = " & gprdProducto.BancoL 
                        //    pszgblsql = pszgblsql & " and emp_num = " & lgblNumEmpresa 
                        //    pszgblsql = pszgblsql & " and unit_id = '" & Trim(Left(frm_men_rep.ID_CEE_UNI_COB.Text, Len(sMascara(Unidad)))) & "'" 
                        //    pszgblsql = pszgblsql & " and report_id = '" & Trim(Left(cad_Rep, 3)) & "'" 

                        //   If Cuenta_Registros >= 1 Then 
                        //       If Obtiene_Registros Then 
                        //           Do Until SqlNextRow(hgblConexion) = NOMOREROWS 
                        //               sGen = Trim(SqlData(hgblConexion, 1)) 
                        // 
                        //               If sGen <> Trim(Mid(cad_Rep, 71, 1)) Then 
                        // 
                        //                   pszgblsql = "update MTCURP01" 
                        //                   pszgblsql = pszgblsql & " set reporting_gen = '" & Trim(Mid(cad_Rep, 71, 1)) & "'" 
                        //                   pszgblsql = pszgblsql & ", last_upd_userid = '" & sgUserID & "'" 
                        //                   pszgblsql = pszgblsql & ", last_upd_date = convert(int,convert(char(20),getdate(),112))" 
                        //                   pszgblsql = pszgblsql & ", last_upd_time = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))" 
                        //                   pszgblsql = pszgblsql & " where eje_prefijo = " & gprdProducto.PrefijoL 
                        //                   pszgblsql = pszgblsql & " and gpo_banco = " & gprdProducto.BancoL 
                        //                   pszgblsql = pszgblsql & " and emp_num = " & lgblNumEmpresa 
                        //                   pszgblsql = pszgblsql & " and unit_id = '" & Trim(mkbMaskebox_Rep(0).Text) & "'" 
                        //                   pszgblsql = pszgblsql & " and report_id = '" & Trim(Left(cad_Rep, 3)) & "'" 
                        // 
                        //                   igblRetorna = SqlCancel(hgblConexion) 
                        //                   If Modifica_Registro Then 
                        //                   End If 
                        //               End If 
                        //           Loop 
                        //       End If 
                        //   End If 
                        //End If 
                        // Next i 

                        break;
                }
                procesing = false;
                this.Close();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEE_ALT_PB_Click)", e);
            }
        }

        private void ID_MEE_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void LST_REPO_DoubleClick(Object eventSender, EventArgs eventArgs)
        {

            string s = String.Empty;
            int reg = 0;

            sRep_ID = LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3)).Trim();
            sRep_Name = Strings.Mid(LST_REPO[0].Text, 7, 30).Trim();
            sFreq = Strings.Mid(LST_REPO[0].Text, 52, 1).Trim();
            sGen = Strings.Mid(LST_REPO[0].Text, 71, 1).Trim();
            try
            {
                if (sRep_ID != "" && sRep_Name != "" && sFreq != "")
                {

                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " report_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " report_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " report_ind_struct,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " supported_frequencies";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCREP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where report_id = '" + sRep_ID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and report_name = '" + sRep_Name.Trim() + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and supported_frequencies = '" + sFreq + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and rep_tipo_prod = 'C'";

                    reg = CORPROC2.Cuenta_Registros();
                    if (reg >= 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                sRep_ID = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                sRep_Name = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                sFreq = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();
                                if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)) == 0)
                                {
                                    for (int i = 0; i <= iRenRep - 1; i++)
                                    {
                                        LST_REPO[0].SelectedIndex = i;
                                        if (Conversion.Val(LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3))) == Conversion.Val(sRep_ID))
                                        {
                                            //LST_REPO(0).RemoveItem (LST_REPO(0).ListIndex)
                                            if (LST_REPO[0].Text.EndsWith("N"))
                                            {
                                                //AIS-1614 FSABORIO
                                                LST_REPO[0].Items[i] = new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(
                                                    StringsHelper.Format(Conversion.Val(sRep_ID), "#" + new String(' ', (int)(6 - Conversion.Val(sRep_ID).ToString().Length))) + sRep_Name + new String(' ', 15) + ((sFreq == "C") ? "CYCLIC" : "DAILY ") + new String(' ', 13) + "Y",
                                                    VB6.GetItemData(LST_REPO[0], i));
                                            }
                                            else if (LST_REPO[0].Text.EndsWith("Y"))
                                            {
                                                //AIS-1614 FSABORIO
                                                LST_REPO[0].Items[i] = new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(
                                                    StringsHelper.Format(Conversion.Val(sRep_ID), "#" + new String(' ', (int)6 - Conversion.Val(sRep_ID).ToString().Length)) + sRep_Name + new String(' ', 15) + ((sFreq == "C") ? "CYCLIC" : "DAILY ") + new String(' ', 13) + "N",
                                                    VB6.GetItemData(LST_REPO[0], i));

                                            }
                                            // Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem listitem = (Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem)_LST_REPO_0.SelectedItem;
                                            // _LST_REPO_0.Items[LST_REPO[0].SelectedIndex] = listitem;
                                            break;
                                            //If Val(sRep_ID) <= 9 Then

                                            //LST_REPO.Item(0).List(i) = Val(sRep_ID) & Space(5) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & "Y" ', i

                                            //LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(5) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & "Y", i
                                            //ElseIf Val(sRep_ID) >= 10 Then
                                            //    LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(4) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & "Y" ', i
                                            //End If
                                        }
                                    }
                                }
                                else
                                {
                                    //cuando se trata de un grupo basta con verificar que haya una
                                    //empresa del grupo que tenta la estructura de gastos

                                    CORVAR.pszgblsql = "select emp_estruct_gastos";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                    if (frm_men_rep.DefInstance.TipoReporteProcesar == frm_men_rep.EnTipoReporte.rptGrupo)
                                    {
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num= " + CORVAR.igblNumGrupo.ToString();
                                    }
                                    else if (frm_men_rep.DefInstance.TipoReporteProcesar == frm_men_rep.EnTipoReporte.RptGrupoEmpresaUnidad)
                                    {
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                                    }


                                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                    if (CORPROC2.Cuenta_Registros() >= 1)
                                    {
                                        for (int i = 0; i <= iRenRep - 1; i++)
                                        {
                                            LST_REPO[0].SelectedIndex = i;
                                            if (Conversion.Val(LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3))) == Conversion.Val(sRep_ID))
                                            {
                                                //AIS-1614 FSABORIO
                                                LST_REPO[0].Items[i] = new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(
                                                    StringsHelper.Format(Conversion.Val(sRep_ID).ToString(), "#" + new String(' ', 6 - Conversion.Val(sRep_ID).ToString().Length)) +
                                                                  sRep_Name + new String(' ', 15) + ((sFreq == "C") ? "CYCLIC" : "DAILY ") + new String(' ', 13) + ((sGen == "N") ? "Y" : "N"),
                                                    VB6.GetItemData(LST_REPO[0], i));
                                                break;
                                                //LST_REPO(0).RemoveItem (LST_REPO(0).ListIndex)
                                                //
                                                //If Val(sRep_ID) <= 9 Then
                                                //    LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(5) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & IIf(sGen = "N", "Y", "N"), i
                                                //ElseIf Val(sRep_ID) >= 10 Then
                                                //    LST_REPO.Item(0).AddItem Val(sRep_ID) & Space(4) & sRep_Name & Space(15) & IIf(sFreq = "C", "CYCLIC", "DAILY ") & Space(13) & IIf(sGen = "N", "Y", "N"), i
                                                //End If

                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("Para poder dar de alta el reporte " + sRep_Name.Trim() + " se necesita que existan categorias.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            };
                        }
                        //LST_REPO(0).ListIndex = 0
                    }
                    else if (reg <= 0)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No se encontro ninguna Calificación Similar a la que elegiste para este tipo de Reporte.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("No se pueden Actualizar los datos porque falta algun dato.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(LST_REPO_DoubleClick)", e);
            }

        }


        private void ConsultaCalificacion()
        {
            int iCont = 0;
            int reg = 0;


            if (Strings.Len(txtTexto_Rep[1].Text) < 16 && frm_men_rep.DefInstance.TipoReporteProcesar != frm_men_rep.EnTipoReporte.rptGrupo)
            {
                //cuando se desea generar a nivel de empresa unidad entonces el numerode cuenta es obligatoriro

                Formato.bgForma = false;
                return;
            }
            else
            {
                Formato.bgForma = true;
            }

            Formato.bgForma = true;
            CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(Strings.Mid(frm_men_rep.DefInstance.ID_CEE_GRU_COB.Text, 1, 4)));

            if (frm_men_rep.DefInstance.TipoReporteProcesar == frm_men_rep.EnTipoReporte.RptGrupoEmpresaUnidad)
            {
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and unit_id = '" + Conversion.Val(frm_men_rep.DefInstance.ID_CEE_UNI_COB.Text.Substring(0, Math.Min(frm_men_rep.DefInstance.ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length))).ToString().Trim() + "'";

                if (CORPROC2.Cuenta_Registros() > 0)
                {
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            mkbMaskebox_Rep[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                            mkbMaskebox_Rep[0].Enabled = false;
                            mkbMaskebox_Rep[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                            mkbMaskebox_Rep[1].Enabled = false;
                            mkbMaskebox_Rep[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                            mkbMaskebox_Rep[2].Enabled = false;
                        };
                    }
                }
                else
                {
                    MdlCambioMasivo.MsgInfo("No se encontrarón datos de la unida seleccionada");
                    Formato.bgForma = false;
                    return;
                }
            }
            else if (frm_men_rep.DefInstance.TipoReporteProcesar == frm_men_rep.EnTipoReporte.rptGrupoEmpresa)
            {
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " nivel_num";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " And nivel_num = 1";

                if (CORPROC2.Cuenta_Registros() > 0)
                {
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            mkbMaskebox_Rep[0].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                            mkbMaskebox_Rep[0].Enabled = false;
                            mkbMaskebox_Rep[1].CtlText = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                            mkbMaskebox_Rep[1].Enabled = false;
                            mkbMaskebox_Rep[2].CtlText = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)).ToString();
                            mkbMaskebox_Rep[2].Enabled = false;
                        };
                    }
                }
                else
                {
                    MdlCambioMasivo.MsgInfo("No se encontrarón datos de la unida seleccionada");
                    Formato.bgForma = false;
                    return;
                }
                //pszgblsql = pszgblsql & " and unit_id = '" & Left(frm_men_rep.ID_CEE_UNI_COB.Text, Len(sMascara(Unidad))) & "'"


            }
            //Determina la lista de reportes del catálogo
            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " distinct convert(int,report_id),";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " report_name,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " supported_frequencies";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCREP01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where rep_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";

            if (CORPROC2.Cuenta_Registros() > 0)
            {
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    iCont = 0;
                    iRenRep = 0;
                    LST_REPO[0].Items.Clear();

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {

                        LST_REPO[0].Items.Add(StringsHelper.Format(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "#" + new String(' ', 6 - Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString().Length)) + VBSQL.SqlData(CORVAR.hgblConexion, 2) + new String(' ', 15) + ((VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim() == "C") ? "CYCLIC" : "DAILY ") + new String(' ', 13) + "N");
                        VB6.SetItemData(LST_REPO[0], iCont, Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
                        iCont++;
                        iRenRep++;
                    };
                    //Determina la lista de reportes que ya se encuentran calificados
                    //ya sea del grupo, empresa y unidad


                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.report_id,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " b.report_name,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_freq,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " a.reporting_gen";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCURP01 a , MTCREP01 b";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " Where b.report_id = a.report_id";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and b.rep_tipo_prod = '" + mdlParametros.gprdProducto.TipoProductoS + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.report_type = " + ((int)frm_men_rep.DefInstance.TipoReporteProcesar).ToString();

                    switch (frm_men_rep.DefInstance.TipoReporteProcesar)
                    {
                        case frm_men_rep.EnTipoReporte.RptGrupoEmpresaUnidad:
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = '" + Conversion.Val(frm_men_rep.DefInstance.ID_CEE_UNI_COB.Text.Substring(0, Math.Min(frm_men_rep.DefInstance.ID_CEE_UNI_COB.Text.Length, Formato.sMascara(Formato.iTipo.Unidad).Length)).Trim()).ToString().Trim() + "'";

                            break;
                        case frm_men_rep.EnTipoReporte.rptGrupoEmpresa:
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_num = " + CORVAR.igblNumGrupo.ToString();  //Filtrá unicamente por el gupo selecionado 

                            if (frm_men_rep.DefInstance.ChkNivel.CheckState == CheckState.Checked)
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.report_level = " + frm_men_rep.DefInstance.CboNivel.Text;
                            }
                            else
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.report_level = 0 ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.unit_id = '" + mkbMaskebox_Rep[0].CtlText + " '";
                            }

                            break;
                        default:
                            //Reporte agrupado unicamente por grupo 
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = 0";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_num = " + txtTexto_Rep[2].Tag.ToString();  //Filtrá unicamente por el gupo selecionado 

                            if (frm_men_rep.DefInstance.ChkNivel.CheckState == CheckState.Checked)
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.report_level = " + frm_men_rep.DefInstance.CboNivel.Text;
                            }
                            else
                            {
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.report_level = 0 ";
                                //pszgblsql = pszgblsql & " and a.unit_id = '" & Trim(Left(frm_men_rep.ID_CEE_UNI_COB.Text, Len(sMascara(Unidad)))) & "'"
                            }
                            break;
                    }



                    reg = CORPROC2.Cuenta_Registros();

                    if (reg >= 1)
                    {
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {

                            while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {
                                sRep_ID = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                                sRep_Name = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                sFreq = VBSQL.SqlData(CORVAR.hgblConexion, 3).Trim();
                                sGen = VBSQL.SqlData(CORVAR.hgblConexion, 4).Trim();

                                for (iCont = 0; iCont <= LST_REPO[0].Items.Count; iCont++)
                                {
                                    LST_REPO[0].SelectedIndex = iCont;
                                    if (LST_REPO[0].Text.Substring(0, Math.Min(LST_REPO[0].Text.Length, 3)).Trim() == sRep_ID)
                                    {

                                        LST_REPO[0].Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(LST_REPO[0]));
                                        if (Conversion.Val(sRep_ID) <= 9)
                                        {
                                            LST_REPO[0].Items.Insert(iCont, Conversion.Val(sRep_ID).ToString() + new String(' ', 5) + sRep_Name + new String(' ', 15) + ((sFreq == "C") ? "CYCLIC" : "DAILY ") + new String(' ', 13) + ((sGen == "Y") ? "Y" : "N"));
                                            break;
                                        }
                                        else if (Conversion.Val(sRep_ID) >= 10)
                                        {
                                            LST_REPO[0].Items.Insert(iCont, Conversion.Val(sRep_ID).ToString() + new String(' ', 4) + sRep_Name + new String(' ', 15) + ((sFreq == "C") ? "CYCLIC" : "DAILY ") + new String(' ', 13) + ((sGen == "Y") ? "Y" : "N"));
                                            break;
                                        }
                                    }
                                }
                            };
                        }
                    }
                }
            }

            LST_REPO[0].SelectedIndex = -1;
            this.Cursor = Cursors.Default;

        }
        private void frm_reportes_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void frm_reportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (procesing)
            {
                e.Cancel = true;
            }
        }
    }
}