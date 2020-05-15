using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class frmCliBancanet
        : System.Windows.Forms.Form
    {

        string smNombreEmpresa = String.Empty;
        int lmNumeroEmpresa = 0;
        int imPrefijo = 0;
        int imBanco = 0;
        bool bmClienteCorrecto = false;
        string smModoOperacion = String.Empty;
        private pryActualizaS111.ClsConectaS111 ObjConexionS111_r = null;

        public void prPasaParametros(int lpNumeroEmpresa, string spNombreEmpresa, int ipPrefijo, int ipBanco, string spModo)
        {
            lmNumeroEmpresa = lpNumeroEmpresa;
            smNombreEmpresa = spNombreEmpresa;
            imPrefijo = ipPrefijo;
            imBanco = ipBanco;
            txtmNumeroEmpresa.Text = StringsHelper.Format(lmNumeroEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
            txtmNombreEmpresa.Text = smNombreEmpresa.Trim();
            txtmNumeroCliente.Text = "";
            chkmBancanet.CheckState = CheckState.Unchecked;
            //prRecargaCliente lpNumeroEmpresa, ipPrefijo, ipBanco
            txtmNumeroEmpresa.Enabled = false;
            txtmNombreEmpresa.Enabled = false;
            txtmNumeroClienteCorrecto.Text = "";
            txtmNumeroClienteCorrecto.Enabled = false;

            cmdmSalir.Enabled = true;
            if (spModo == "consulta")
            {
                txtmNumeroCliente.Enabled = true;
                chkmBancanet.Enabled = false;
                cmdmActualizar.Enabled = false;
            }
            if (spModo == "actualizar")
            {
                txtmNumeroCliente.Enabled = true;
                chkmBancanet.Enabled = true;
                cmdmActualizar.Enabled = true;
                bmClienteCorrecto = false;
                txtmNumeroClienteCorrecto.Text = "";
            }
            cmdmSalir.Enabled = true;
            smModoOperacion = spModo;
        }
        //Private Sub prRecargaCliente(lpNumeroEmpresa As Long, _
        //'                            ipPrefijo As Integer, ipBanco As Integer)
        //'Esta funcion lo que hace es traerse los datos de los clientes en caso de que existan
        //Dim llCliente As Long
        //Dim slNombreCliente As String
        //Dim ilBancanet As Integer
        //If fncExisteClienteB(lpNumeroEmpresa, ipPrefijo, ipBanco) Then
        //   prCargaClienteBD lpNumeroEmpresa, ipPrefijo, _
        //'                        ipBanco, llCliente, ilBancanet
        //   txtmNumeroCliente.Text = Trim(CStr(llCliente))
        //   If ilBancanet = 0 Then
        //      chkmBancanet.Value = 0
        //   Else
        //      chkmBancanet.Value = 1
        //   End If
        //Else
        //   llCliente = fncLanzaDialogoI(lpNumeroEmpresa, ipPrefijo, ipBanco)
        //   If llCliente < 0 Then
        //      'no tuvo èxito el diálogo
        //      llCliente = 0
        //   End If
        //End If
        //
        //End Sub
        //Private Function fncExisteClienteB(lpNumeroEmpresa As Long, _
        //'                            ipPrefijo As Integer, ipBanco As Integer) As Boolean
        //'Verifica que el cliente exista en la bd.
        //Dim slsql As String
        //
        //
        //'slsql = "select * from MTCCLI01"
        //'pszgblsql = slsql
        //'If Obtiene_Registros Then
        //'   Do Until SqlNextRow(hgblConexion) = NOMOREROWS 'ros And iCont < INT_MAX_EMPRESAS
        //'      Debug.Print "********************************************************************"
        //'      Debug.Print SqlData(hgblConexion, 1)
        //'      Debug.Print SqlData(hgblConexion, 2)
        //'      Debug.Print SqlData(hgblConexion, 3)
        //'      Debug.Print SqlData(hgblConexion, 4)
        //'      Debug.Print SqlData(hgblConexion, 5)
        //'    Loop
        //'End If
        //'igblRetorna = SqlCancel(hgblConexion)
        //
        //
        //slsql = ""
        //fncExisteClienteB = True
        //slsql = "select count(*) as cuenta  "
        //slsql = slsql & " from MTCCLI01  "
        //slsql = slsql & " where eje_prefijo = " & Trim(CStr(ipPrefijo)) & " "
        //slsql = slsql & " and gpo_banco = " & Trim(CStr(ipBanco)) & " "
        //slsql = slsql & " and emp_num = " & Trim(CStr(lpNumeroEmpresa)) & " "
        //
        //pszgblsql = slsql
        //  If Obtiene_Registros Then
        //     If Not (SqlNextRow(hgblConexion) = NOMOREROWS) Then
        //        If Val(SqlData(hgblConexion, 1)) = 0 Then
        //           fncExisteClienteB = False
        //        End If
        //     End If
        //  Else
        //       fncExisteClienteB = False
        //  End If
        //  igblRetorna = SqlCancel(hgblConexion)
        //End Function
        //
        //Private Function fncLanzaDialogoI(lpNumeroEmpresa As Long, _
        //'                            ipPrefijo As Integer, ipBanco As Integer) As Integer
        //'Lanza el dialogo y proporciona los datos del cliente
        //fncLanzaDialogoI = 0
        //MsgBox "Dialogo Lanzado"
        //End Function
        //
        //Private Sub prCargaClienteBD(lpNumeroEmpresa As Long, _
        //'                            ipPrefijo As Integer, ipBanco As Integer, _
        //'                            lpCliente As Long, ipBancanet As Integer)
        //'Carga los datos de la base de datos MTCCLI01
        //Dim slsql As String
        //slsql = " select cliente_num, isnull(cli_bancanet, 0) "
        //slsql = slsql & " from MTCCLI01    "
        //slsql = slsql & " where eje_prefijo =  " & Trim(CStr(ipPrefijo)) & " "
        //slsql = slsql & " and gpo_banco = " & Trim(CStr(ipBanco)) & " "
        //slsql = slsql & " and emp_num = " & Trim(CStr(lpNumeroEmpresa)) & " "
        //lpCliente = 0
        //ipBancanet = 0
        //pszgblsql = slsql
        //
        //If Obtiene_Registros Then
        //   If Not (SqlNextRow(hgblConexion) = NOMOREROWS) Then
        //      lpCliente = Val(SqlData(hgblConexion, 1))
        //      ipBancanet = Val(SqlData(hgblConexion, 2))
        //   End If
        //End If
        //igblRetorna = SqlCancel(hgblConexion)
        //End Sub
        //Private Sub ID_CEM_ACT_PB_Click()
        //
        //End Sub

        private void cmdmActualizar_Click(Object eventSender, EventArgs eventArgs)
        {
            string slSQL = String.Empty;
            try
            {
                int tempRefParam = 13;
                txtmNumeroCliente_KeyPress(txtmNumeroCliente, new KeyPressEventArgs(Convert.ToChar(tempRefParam))); //Realiza la validacion del cliente

                slSQL = "";
                if (bmClienteCorrecto)
                {
                    if (fncSeEncuentraRegistradoCliB())
                    {
                        if (MessageBox.Show("¿Desea actualizar Bancanet para el cliente: " + txtmNumeroCliente.Text.Trim(), "Confirmar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            slSQL = "update MTCCLI01 ";
                            slSQL = slSQL + " set cliente_num = " + txtmNumeroCliente.Text.Trim() + ", ";
                            //slSQL = slSQL & " cli_bancanet =  " & Trim(CStr(chkmBancanet.Value)) & " "
                            slSQL = slSQL + " cli_bancanet =  " + "1" + " "; //se corrige prender bandera
                            slSQL = slSQL + " from MTCCLI01 ";
                            slSQL = slSQL + " where eje_prefijo = " + imPrefijo.ToString().Trim() + " ";
                            slSQL = slSQL + " and gpo_banco = " + imBanco.ToString().Trim();
                            slSQL = slSQL + " and emp_num = " + lmNumeroEmpresa.ToString().Trim() + " ";
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("¿Desea actualizar Bancanet para el cliente: " + txtmNumeroCliente.Text.Trim(), "Confirmar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            slSQL = " insert into MTCCLI01  ";
                            slSQL = slSQL + " (eje_prefijo, gpo_banco, emp_num, cliente_num, cli_bancanet) ";
                            slSQL = slSQL + " values (" + imPrefijo.ToString().Trim() + ",";
                            slSQL = slSQL + imBanco.ToString().Trim() + ",";
                            slSQL = slSQL + lmNumeroEmpresa.ToString().Trim() + ",";
                            slSQL = slSQL + txtmNumeroCliente.Text.Trim() + ",";
                            //slSQL = slSQL & Trim(CStr(chkmBancanet.Value)) & ") "
                            slSQL = slSQL + "1" + ") "; //se corrige para prender bandera de SAPUF
                        }
                    }
                    if (slSQL.Trim() != "")
                    {
                        CORVAR.pszgblsql = slSQL;

                        if (CORPROC2.Obtiene_Registros() != 0)
                        {
                            if (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                            {

                            }
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El numero del cliente no es correcto.", Application.ProductName);
                }
            }
            catch
            {

                string tempRefParam2 = "CmdmActualizar_Click";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam2))
                {
                    //throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }
        }
        private void cmdmSalir_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void frmCliBancanet_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                txtmNumeroCliente.Focus();
            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            this.Width = (int)VB6.TwipsToPixelsX(6735);
            this.Height = (int)VB6.TwipsToPixelsY(3270);
            int iLeft = ((CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2);
            int iTop = ((CORMDIBN.DefInstance.ClientRectangle.Height - this.Height) / 2);

            this.SetBounds(iLeft, iTop, 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
        }

        private void prCargaDatosCliente(string pszRegresaS111, ref  string slNumeroCliente, ref  string slNombreCliente, ref  string slInformacionCliente)
        {
            pszRegresaS111 = pszRegresaS111.Replace("La transacción en el S111 no fue aceptada\r\nPor la siguiente causa:\r\n", "");

            slNumeroCliente = Strings.Mid(pszRegresaS111, 112, 12);
            slNombreCliente = Strings.Mid(pszRegresaS111, 124, 55).Trim();
            slInformacionCliente = "NOMBRE: " + slNombreCliente + "\r\n" + "RFC: " + Strings.Mid(pszRegresaS111, 317, 4).Trim() + Strings.Mid(pszRegresaS111, 322, 6).Trim() + Strings.Mid(pszRegresaS111, 328, 3).Trim();
        }

        private bool fncEnviaDialogo(ref  string slNumeroCliente, ref  string slNombreCliente, ref  string slInformacionCliente)
        {

            bool result = false;
            string slDialogo = String.Empty;
            string pszRegresaS111 = String.Empty;
            bool EnviaCambioS111 = false;
            string slUsuario = String.Empty;
            string slPassword = String.Empty;

            N_ActualizaS111.ClsConectaS111 ObjConexionS111 = new N_ActualizaS111.ClsConectaS111();

            ObjConexionS111_r = new pryActualizaS111.ClsConectaS111();

            try
            {

                frmLoginS53 frmFirma = new frmLoginS53();
                var regreso = frmFirma.ShowDialog();


                ObjConexionS111_r.set_Usuario(ref CRSParametros.sgUserID);
                ObjConexionS111_r.strUsuarioMaker = mdlParametros.sgUserCamLimCred;

                if (regreso.ToString() == "OK")
                {
                    mdlSeguridad.bgSeguridadS041 = true;
                    prcEnviaDialogo(ref slDialogo, ref pszRegresaS111, ref EnviaCambioS111, ObjConexionS111);


                    
                    if (EnviaCambioS111)
                    {
                        prCargaDatosCliente(pszRegresaS111, ref slNumeroCliente, ref slNombreCliente, ref slInformacionCliente);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    ObjConexionS111 = null;
                    return false;
                }




            }
            catch (Exception excep)
            {

                MdlCambioMasivo.MsgError(excep.Message);
                result = false;
            }


            return result;
        }

        private void prLlenaBanamex()
        {
            //Llena el check box de banamex de acuerdo con MTCCLI
            int llCliBancanet = 0;
            string slSQL = " select isnull(cli_bancanet,0)  ";
            slSQL = slSQL + " from MTCCLI01  ";
            slSQL = slSQL + " where eje_prefijo =  " + imPrefijo.ToString().Trim();
            slSQL = slSQL + " and gpo_banco =  " + imBanco.ToString().Trim();
            slSQL = slSQL + " and emp_num =  " + lmNumeroEmpresa.ToString().Trim();
            CORVAR.pszgblsql = slSQL;
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    llCliBancanet = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    if (llCliBancanet == 0)
                    {
                        chkmBancanet.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        chkmBancanet.CheckState = CheckState.Checked;
                    }
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        }

        private bool fncSeEncuentraRegistradoB()
        {
            //Verifica que se encuentre el registro dentro de MTCCLI

            bool result = false;
            string slSQL = "";
            result = true;
            slSQL = "select count(*) as cuenta  ";
            slSQL = slSQL + " from MTCCLI01  ";
            slSQL = slSQL + " where eje_prefijo = " + imPrefijo.ToString().Trim() + " ";
            slSQL = slSQL + " and gpo_banco = " + imBanco.ToString().Trim() + " ";
            slSQL = slSQL + " and emp_num = " + lmNumeroEmpresa.ToString().Trim() + " ";

            CORVAR.pszgblsql = slSQL;
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) == 0)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            return result;
        }
        private bool fncSeEncuentraRegistradoCliB()
        {
            //Verifica que se encuentre el registro dentro de MTCCLI

            bool result = false;
            string slSQL = "";
            result = true;
            slSQL = "select count(*) as cuenta  ";
            slSQL = slSQL + " from MTCCLI01  ";
            slSQL = slSQL + " where eje_prefijo = " + imPrefijo.ToString().Trim() + " ";
            slSQL = slSQL + " and gpo_banco = " + imBanco.ToString().Trim() + " ";
            slSQL = slSQL + " and emp_num = " + lmNumeroEmpresa.ToString().Trim() + " ";
            //slSQL = slSQL & "  and  cliente_num = " & Trim(txtmNumeroCliente.Text) & " "

            CORVAR.pszgblsql = slSQL;
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) == 0)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            return result;
        }
        private bool fncValidaTxtCliente()
        {
            string slNumeroCliente = txtmNumeroCliente.Text.Trim();

            if (slNumeroCliente == "")
            {
                return false;
            }
            if (slNumeroCliente.IndexOf(' ') >= 0)
            {
                return false;
            }
            for (int ilContador = 1; ilContador <= slNumeroCliente.Length; ilContador++)
            {
                if (!fncCaracterValidoB(Strings.Mid(slNumeroCliente, ilContador, 1)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool fncCaracterValidoB(string spCaracter)
        {
            int ilCaracter = (int)spCaracter[0];
            if (ilCaracter >= 48 && ilCaracter <= 57)
            {
                return true;
            }
            //If ilCaracter >= 65 And ilCaracter <= 90 Then
            //   fncCaracterValidoB = True
            //   Exit Function
            //End If
            //If ilCaracter >= 97 And ilCaracter <= 122 Then
            //   fncCaracterValidoB = True
            //   Exit Function
            //End If
            return false;
        }

        private void txtmNumeroCliente_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            string slInformacionCliente = String.Empty;
            string slNumeroCliente = String.Empty;
            string slMensaje = String.Empty;
            string slNombreCliente = String.Empty;
            try
            {
                bmClienteCorrecto = false;

                txtmNumeroClienteCorrecto.Text = "";
                if (KeyAscii == 13)
                {
                    if (fncValidaTxtCliente())
                    {
                        slNumeroCliente = txtmNumeroCliente.Text.Trim();

                        if (fncEnviaDialogo(ref slNumeroCliente, ref slNombreCliente, ref slInformacionCliente))
                        {
                            slMensaje = slInformacionCliente + "\r\n" + " ¿Son correctos los datos del cliente?";
                            if (MessageBox.Show(slMensaje, "Confirmar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                //txtmNombreEmpresa.Text = slNombreCliente
                                if (fncSeEncuentraRegistradoB())
                                {
                                    prLlenaBanamex();
                                }
                                else
                                {
                                    chkmBancanet.CheckState = CheckState.Unchecked;
                                    if (smModoOperacion == "consulta")
                                    {
                                        MessageBox.Show("El cliente: " + txtmNumeroCliente.Text + "\r\n" +
                                                        "no tiene asignado Bancanet", Application.ProductName);
                                    }
                                }
                                bmClienteCorrecto = true;
                                txtmNumeroClienteCorrecto.Text = txtmNumeroCliente.Text;
                                if (chkmBancanet.Enabled)
                                {
                                    chkmBancanet.Focus();
                                }
                                else
                                {
                                    cmdmSalir.Focus();
                                }
                            }
                            else
                            {
                                txtmNumeroCliente.Text = "";
                                chkmBancanet.CheckState = CheckState.Unchecked;
                            }
                            //       Else
                            //          If fncSeEncuentraRegistradoCliB() Then
                            //                prLlenaBanamex
                            //                MsgBox "Cliente encontrado"
                            //                bmClienteCorrecto = True
                            //          Else
                            //             MsgBox "Cliente " & Trim(txtmNumeroCliente.Text) & " no encontrado"
                            //          End If
                            //       End If
                        }
                    }
                }
                else
                {
                    //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                    KeyAscii = fncValidaEntrada(ref KeyAscii, txtmNumeroCliente);
                }
                if (KeyAscii == 0)
                {
                    eventArgs.Handled = true;
                }
                return;
            }
            catch
            {
            }


            string tempRefParam = "txtmNumeroCliente:Keypress";
            if (MdlCambioMasivo.fnGetError(ref tempRefParam))
            {
                throw new Exception("Migration Exception: 'Resume' not supported");
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        private int fncValidaEntrada(ref  int KeyAscii, TextBox txtpNumero)
        {
            if (KeyAscii == 8)
            {
                return 8;
            }
            if (txtpNumero.Text.Trim().Length >= 12)
            {
                KeyAscii = 0;
                return 0;
            }
            if (KeyAscii >= 97 && KeyAscii <= 122)
            {
                return KeyAscii;
            }
            if (KeyAscii >= 65 && KeyAscii <= 90)
            {
                return KeyAscii;
            }
            if (KeyAscii >= 48 && KeyAscii <= 57)
            {
                return KeyAscii;
            }

            return 0;
        }
        //Private Sub prcEnviaMensaje()
        //Dim slDialogo As String
        //Dim pszRegresaS111 As String
        //Dim EnviaCambioS111 As Boolean
        //Dim slUsuario As String
        //Dim slPassword As String
        //frmAccesoBancanet.Show vbModal
        //If frmAccesoBancanet.sgModoSalida = "aceptar" Then
        //   slUsuario = Trim(frmAccesoBancanet.txtmUsuario)
        //   slPassword = Trim(frmAccesoBancanet.txtmPassword)
        //   Unload frmAccesoBancanet
        //   Set objSeguridad = New COMDRV32.TcpServer
        //   objSeguridad.Connect
        //   If fncFirmaS041B(slUsuario, slPassword, tFirmaConModuloS041) = True Then
        //      prcEnviaDialogo slDialogo, pszRegresaS111, EnviaCambioS111
        //      fncFirmaS041B "", "", tDesfirmaS041
        //   End If
        //   objSeguridad.Disconnect
        //   Set objSeguridad = Nothing
        //Else
        //   Unload frmAccesoBancanet
        //End If
        //End Sub

        private void prcEnviaDialogo(ref  string slDialogo, ref  string pszRegresaS111, ref  bool EnviaCambioS111, N_ActualizaS111.ClsConectaS111 ObjConexionS111)
        {
            string slCuenta = String.Empty;
            bool blContinue = false;
            int ilCont = 0;
            string slRespuesta = String.Empty;
            int ilLongitudMsg = 0;
            string slBloque = String.Empty;
            int ilResultado = 0;
            string slCausaError = String.Empty;
            bool mbPrimTran = false;
            string pszMensaje = String.Empty;
            bool blActualizo = false;

            clsProducto lproducto = new clsProducto();

            clsDatosEjecutivo ldteEjecutivo = new clsDatosEjecutivo();
            lproducto.PrefijoL = ldteEjecutivo.EjeProductoPRD.PrefijoL;
            lproducto.BancoL = ldteEjecutivo.EjeProductoPRD.BancoL;
            ldteEjecutivo.EjeProductoPRD.PrefijoL = 0;
            ldteEjecutivo.EjeProductoPRD.BancoL = 0;
            ldteEjecutivo.EjeEmpNumL = 0;
            ldteEjecutivo.EjeNumL = 0;

            clsDialogo gdlgDialogoS016 = new clsDialogo();
            gdlgDialogoS016.prGeneraDlg(ldteEjecutivo, clsDialogo.enuTipoDialogo.tConsEjecutivoS016); //, tConsEmpresaS016
            slDialogo = gdlgDialogoS016.DialogoS.Trim();
            ldteEjecutivo.EjeProductoPRD.PrefijoL = lproducto.PrefijoL;
            ldteEjecutivo.EjeProductoPRD.BancoL = lproducto.BancoL;
            lproducto = null;
            ldteEjecutivo = null;
            gdlgDialogoS016 = null;
            slDialogo = StringsHelper.MidAssignment(slDialogo, 112, StringsHelper.Format(Int32.Parse(txtmNumeroCliente.Text), new string('0', 12)));
            slDialogo = StringsHelper.MidAssignment(slDialogo, 124, new string('0', 4));
            slDialogo = StringsHelper.MidAssignment(slDialogo, 128, new string('0', 4));
            slDialogo = StringsHelper.MidAssignment(slDialogo, 132, new string('0', 16));
            slDialogo = StringsHelper.MidAssignment(slDialogo, 97, "1");
            //slDialogo = "P" & slDialogo & Chr(3)
            ObjConexionS111.StrIdTransaccion = slDialogo;
            //AIS-1119 NGONZALEZ
            String tempString = String.Empty;
            EnviaCambioS111 = (TransS111.EnumRespTransaccion) ObjConexionS111.FnEnviarTransaccion( tempString,  tempString,  tempString) == TransS111.EnumRespTransaccion.EnRespDesconocida; //Solo es verdaderá la transaccion cuando no contesta una situacion de error como operacion negada, etc.

            bool tempRefParam = true;
            pszRegresaS111 = ObjConexionS111.GetMsgerror(ref tempRefParam); //Lee el mensaje que llega del s111

            if (pszRegresaS111.IndexOf("REGISTRO NO EXISTE EN LA BASE", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                EnviaCambioS111 = false;
                MdlCambioMasivo.MsgError("Numero de cliente inexistente");
            }

            if (pszRegresaS111.IndexOf("Esta en Sesion Dual, Use 004101ADIOS", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                EnviaCambioS111 = false;
                MdlCambioMasivo.MsgError("Favor de intentar nuevamente, no se ha podido validar el número de Cliente.");
            }

            if (pszRegresaS111.IndexOf(txtmNumeroCliente.Text, StringComparison.CurrentCultureIgnoreCase) < 0)
            {
                EnviaCambioS111 = false;
                MdlCambioMasivo.MsgError("Numero de cliente inexistente");
            }


            Application.DoEvents();
            // dialogo patrón
            //slDialogo = "P" & "001644000000001644000000000000110060001501000B001073000000000005020515171250220000000000AFDC0010100000000000000000024845423000000000000000000000000" & Chr(3)

        }
        //Private Sub cb_ejecutar_click()
        //
        //
        //'lmNumeroEmpresa = 18100
        //'imPrefijo = 5473
        //'imBanco = 80
        //'txtmNumeroCliente.Text = "8426457"
        //prcEnviaMensaje
        //End Sub
        private void txtmNumeroEmpresa_TextChanged(Object eventSender, EventArgs eventArgs)
        {

        }
        private void frmCliBancanet_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}