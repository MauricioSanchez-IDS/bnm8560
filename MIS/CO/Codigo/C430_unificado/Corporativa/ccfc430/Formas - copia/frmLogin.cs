using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;

namespace TCc430
{
    public partial class frmLogin : Form
    {

        const string STR_SEG_NOT_BAN = "No existen bancos para acceso al sistema. Consulte al Administrador del Sistema.";
        const string STR_SEG_NOT_CON = "La conexión a las bases de datos es invalida. Consulte al Administrador del Sistema.";
        const string STR_SEG_NOT_LOG = "Verifique el usuario o la clave personal, no coinciden.";
        const string STR_ACC_NOT_CVE = "El SOEID no ha sido proporcionado. Favor de asignarlo.";
        const string STR_ACC_NOT_USU = "La clave personal no ha sido proporcionada. Favor de asignarla.";
        const string STR_ACC_LON_TOK = "La longitud del Token debe ser de 6 caracteres";
        const string STR_ACC_NOT_NIV = "El grupo asignado al usuario no tiene niveles de acceso. Deberán ser asignados por el Administrador del Sistema.";
        const string STR_ACC_NOT_ACC = "Verifique el usuario o la clave personal, no coinciden.";
        const string STR_ACC_NOT_EXI = "El usuario no ha sido dado de alta en el sistema. Consulte al Administrador del Sistema.";
        const string STR_ACC_NOT_MEM = "No hay suficiente memoria para realizar la Conección. Inicialice su Computadora.";
        const string STR_ACC_NOT_SER = "No existen servisores instalados.";

        string pszGrupo = String.Empty;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private int Carga_Bancos()
        {

            int result = 0;
            //int iErr = 0;
            //int hBanco = 0;
            int iBancoCve = 0;

            //***** INICIO CODIGO NUEVO FSWBMX *****
            int iBancoPref = 0;
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            string pszBancoDes = String.Empty;
            FixedLengthString pszCad = new FixedLengthString(256);

            result = -1;

            ID_ACC_BAN_COB.Items.Clear();

            if (CORVAR.hgblConexion != 0)
            {

                //***** INICIO CODIGO NUEVO FSWBMX *****
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_pref,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_banco,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_ban_des";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCON01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where con_tipo_prod = 'C'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY con_banco";
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                if (CORPROC2.Obtiene_Registros() != 0)
                {


                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        //***** INICIO CODIGO NUEVO FSWBMX *****
                        iBancoPref = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                        iBancoCve = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL)));
                        pszBancoDes = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL);
                        ID_ACC_BAN_COB.Items.Add(iBancoPref.ToString() + " - " + iBancoCve.ToString() + " - " + pszBancoDes.Trim().ToUpper());
                        //***** FIN DE CODIGO NUEVO FSWBMX *****
                    };
                }
                else
                {
                    //AIS-1182 NGONZALEZ
                    CORVAR.igblErr = API.USER.PostMessage(CORSGACC.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    return 0;
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                if (ID_ACC_BAN_COB.Items.Count != 0)
                {
                    ID_ACC_BAN_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }
                else
                {
                    //Si la aplicacion no contiene bancos
                    this.Cursor = Cursors.Default;
                    //MsgBox STR_SEG_NOT_BAN, MB_ICONSTOP + MB_OK, STR_APP_TIT
                    return 0;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return 0;
            }

            return result;
        }


        private void frmLogin_Activated(object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                ID_ACC_USU_EB.Text = CORVB.NULL_STRING;
                ID_ACC_CAN_PB.Enabled = true;
                ID_ACC_USU_EB.Focus();
                this.Refresh();
            }

        }

        private void Carga_Path()
        {

            string pszPath = String.Empty;
            //int hParam = 0;

            CORVAR.pszgblsql = "SELECT pgs_path FROM " + CORBD.DB_SYB_PGS;

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    pszPath = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL);
                    if (FileSystem.Dir(pszPath, FileAttribute.Normal) != CORVB.NULL_STRING)
                    {
                        CORVAR.pszgblPath = pszPath.Trim();
                    }
                    else
                    {
                        CORVAR.pszgblPath = Directory.GetCurrentDirectory();
                    }
                }
                else
                {
                    CORVAR.pszgblPath = Directory.GetCurrentDirectory();
                }
            }
            else
            {
                //AIS-1182 NGONZALEZ
                CORVAR.igblErr = API.USER.PostMessage(CORSGACC.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                return;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        }

        private void Finaliza_Sesion()
        {
            VBSQL.SqlExit();
            VBSQL.SqlWinExit();
            this.Cursor = Cursors.Default;
            Environment.Exit(0);
        }

        private void Form_Load()
        {
            Seguridad.usugUsuario = new prySeguridadS041.clsUsuario(); //EISSA:HVV 25.02.2005 - Se inicializa una instancia de Usuario.

            this.Left = (int)VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY(300);
            this.Show();
            this.Refresh();
            //SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(Screen.PrimaryScreen.Bounds.Width) - ((float)VB6.PixelsToTwipsX(Width))) / 2)), Convert.ToInt32((float)VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(Screen.PrimaryScreen.Bounds.Height) - ((float)VB6.PixelsToTwipsY(Height))) / 2)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
            this.Cursor = Cursors.WaitCursor;


            //*****JPU*****
            mdlParametros.gprdProducto = new clsProducto();

            CORPROC.Obten_Paths_Globales();

            //Obtiene Bancos
            if (~Carga_Bancos() != 0)
            {
                CORDBLIB.gsMsg = "No existen Bancos en la Base de Datos.";
                Interaction.MsgBox(CORDBLIB.gsMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                this.Cursor = Cursors.Default;
                Environment.Exit(0);
            }

            if (ID_ACC_BAN_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_ACC_ACE_PB.Enabled = true;
            }

            //EISSA Fin Conexión para Formateo de Empresa y Ejecutivo
            this.Refresh();
            Application.DoEvents();
            this.Cursor = Cursors.Default;
        }

        //    VALIDADATOS   
        public bool validaDatos()
        {
            if (ID_ACC_USU_EB.Text != "")
            {
                if (ID_ACC_CVE_EB.Text != "")
                {
                    StrIp = mdlSeguridad.GetIP();
                    Strpassword = ID_ACC_CVE_EB.Text.Trim();
                    Strnomina = ID_ACC_USU_EB.Text.Trim();
                    return true;
                }
                else
                {
                    MessageBox.Show("Favor de capturar la contraseña", "Password");
                    ID_ACC_CVE_EB.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Favor de capturar SOEID", "SOEID");
                ID_ACC_USU_EB.Focus();
                return false;
            }
        }

        //    VALIDADATOS

        //Obtienen ip de la maquina
        //public string GetIP()
        //{
        //    string strHostName = "";
        //    string localIP = "";

        //    strHostName = System.Net.Dns.GetHostName();
        //    IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        //    foreach (var item in ipEntry.AddressList)
        //    {
        //        if (item.AddressFamily.ToString() == "InterNetwork")
        //        {
        //            localIP = item.ToString();
        //        }
        //    }

        //    return localIP;
        //}

        //    INICIASESION
        public void iniciasesion()
        {
            /*if (validaDatos())
            {
                Conexion.Roles.numnomina = Strsoeid;
                Conexion.sgPassword = MdVarGlobales.usuario.Strpassword;
                string tempRefParam = bnxFacultad;
                MdVarGlobales.bAutentificado = mdlSeguridad.Firmasprincipal();
                if (bAutentificado)
                {
                    frmLogin.DefInstance.Show();
                    this.Hide();
                    ID_ACC_CVE_EB.Text = "";
                    ID_ACC_CVE_EB.Focus();
                }
                else
                {
                    ID_ACC_CVE_EB.Text = "";
                    ID_ACC_USU_EB.Text = "";
                    ID_ACC_USU_EB.Focus();
                }
            }*/
        }
        //    INICIASESION

        private void ID_ACC_ACE_PB_Click(object eventSender, EventArgs eventArgs)
        {
            string pszBanco = String.Empty;
            int iPos = 0;

            try
            {
                CORMDIBN.DefInstance.IDT_GPB[0].Enabled = true;
                CORMDIBN.DefInstance.IDT_GPB[1].Enabled = true;
                CORMDIBN.DefInstance.IDT_GPB[2].Enabled = true;

                if (ID_ACC_USU_EB.Text.Trim() == CORVB.NULL_STRING)
                { //Valido que el campo de usuario tenga un valor
                    this.Cursor = Cursors.Default;
                    Interaction.MsgBox(STR_ACC_NOT_CVE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    ID_ACC_USU_EB.Focus();
                    return;
                }

                if (ID_ACC_CVE_EB.Text.Trim() == CORVB.NULL_STRING)
                { //Valido que el campo de clave tenga un valor
                    this.Cursor = Cursors.Default;
                    Interaction.MsgBox(STR_ACC_NOT_USU, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    ID_ACC_CVE_EB.Focus();
                    return;
                }

                if (ID_ACC_TOKEN_EB.Text.Trim() != CORVB.NULL_STRING)
                { //Valido que el campo de clave tenga un valor
                    if (ID_ACC_TOKEN_EB.TextLength != 6)
                    {
                        this.Cursor = Cursors.Default;
                        Interaction.MsgBox(STR_ACC_LON_TOK, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        ID_ACC_TOKEN_EB.Focus();
                        return;
                    }
                }

                this.Cursor = Cursors.WaitCursor;
                Seguridad.usugUsuario.NominaS = ID_ACC_USU_EB.Text;
                Seguridad.usugUsuario.PasswordS = ID_ACC_CVE_EB.Text;
                //Define el nivel del modulo 4022 al usuario 3260151
                // ya que el usuario no ha sido dado de alta en el sistema
                //S041
                //FSWB NR TESTER Comentarizar el if para permitir acceso sin firma validada en s041
                CRSParametros.sgPasswd = ID_ACC_CVE_EB.Text.Trim();


                string StrSoeid = ID_ACC_USU_EB.Text.Trim();
                string StrPassword = ID_ACC_CVE_EB.Text.Trim();
                string StrToken = ID_ACC_TOKEN_EB.Text.Trim();
                string StrIp = mdlSeguridad.GetIP();
                //PARA SISTEMAS
                string StrSist = "0";

                //opcionParaFirmarse A SSS
                int FirmaoDesfirma = 1;

                string _url = ConfigurationManager.AppSettings["_url"];
                string _action = ConfigurationManager.AppSettings["_action_a"];

                String SSS = mdlSeguridad.Servicios_SSS(StrSoeid, StrPassword, StrIp, StrToken, StrSist, FirmaoDesfirma, _url, _action);

                if (SSS == "1")
                {
                    //CRSParametros.sgPasswd = "";
                    Seguridad.usugUsuario.NominaS = mdlSeguridad.Stdl_ope_id;


                    string tempRefParam2 = mdlSeguridad.Stdl_ope_id;
                    CRSParametros.sgUserID = mdlSeguridad.Stdl_ope_id;

                    mdlParametros.gperPerfil.ModulosPermisosS = mdlSeguridad.sgDlgSeguridad;
                    mdlParametros.gperPerfil.prHabilitaAcciones(CORMDIBN.DefInstance);

                    Seguridad.usugUsuario.NombreS = CRSParametros.sgUserName;

                    MessageBox.Show("                                            ADVERTENCIA" + "\r\n" +
                                    "Ud. esta autorizado para usar este Sistema unicamente para propositos" + "\r\n" +
                                    "aprobados del negocio. Esta prohibido su uso para cualquier otro" + "\r\n" +
                                    "proposito. Todos los registros de transacciones, reportes, correo" + "\r\n" +
                                    "electronico e-mail, programas y otros datos generados o residentes en" + "\r\n" +
                                    "este Sistema son propiedad de Grupo Financiero Banamex, Subsidiarias y" + "\r\n" +
                                    "Afiliadas de Mexico y pueden ser usados por Grupo Financiero Banamex," + "\r\n" +
                                    "Subsidiarias y Afiliadas de Mexico para cualquier proposito. Las" + "\r\n" +
                                    "actividades autorizadas y no autorizadas pueden ser monitoreadas.", "Tarjeta Corporativa", MessageBoxButtons.OK);

                    Carga_Path();
                    /*Elimina_TMP();*/
                    if (ID_ACC_BAN_COB.Items.Count > CORVB.NULL_INTEGER)
                    { //Asigna el banco seleccionado por el usuario a la variable global
                        pszBanco = VB6.GetItemString(ID_ACC_BAN_COB, ID_ACC_BAN_COB.SelectedIndex);
                        if (pszBanco.Trim().Length != 0)
                        {
                            iPos = Strings.Mid(pszBanco, 1, pszBanco.IndexOf(' ')).Length + 3;
                            mdlParametros.gprdProducto.prConfiguraProducto(Convert.ToInt32(Conversion.Val(Strings.Mid(pszBanco, 1, pszBanco.IndexOf(' ')))), Convert.ToInt32(Conversion.Val(Strings.Mid(pszBanco, iPos, pszBanco.IndexOf(' ')))));
                            CORVAR.igblPref = mdlParametros.gprdProducto.PrefijoL;
                            CORVAR.igblBanco = mdlParametros.gprdProducto.BancoL;
                            CORMDIBN.DefInstance.Text = "Tarjeta Corporativa Banamex " + "[ " + pszBanco + " ]";
                            CORMDIBN.DefInstance.IDM_BNX.Enabled = CORVAR.igblBanco == 80;
                        }
                    }

                    this.Close();

                    CORMENIN tempLoadForm = CORMENIN.DefInstance;
                    CORMENIN.DefInstance.Close();

                    //Load CORMECDF
                    //Unload CORMECDF

                    //Load frmIntInicio
                    //AIS-541 NGONZALEZ
                    mdlParametros.gcestEstado = new colcatEstado();
                    mdlParametros.gcestEstado.prObtenEstado();

                    mdlParametros.prObtenPathsIni();
                    /*SE EMPATA CON LA VERSIÓN DE PRODUCCIÓN 14/01/10*/
                    // Creación del C430.Log de forma Temporal
                    string filepath;
                    string sFecha = DateTime.Today.ToString("ddMMyy");
                    //String DirExe = Path.GetDirectoryName(Application.ExecutablePath);
                    filepath = mdlParametros.sgPathLogs + "AltasCorp" + sFecha + ".Log";
                    //CORVAR.FileNumber = FileSystem.FreeFile();
                    CORVAR.FileNumber = 201;
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

                    //AIS-541 NGONZALEZ
                    mdlParametros.gcejxEjecutivoBanamex = new colEjecutivoBanamex();
                    mdlParametros.gcejxEjecutivoBanamex.prObtenEjecutivoBanamex();

                    Formato.prConfiguraLongEmpEje(CORVAR.igblPref, CORVAR.igblBanco);
                    CORMDIBN.DefInstance.sspPanel[0].Caption = CRSParametros.sgUserID;

                    //FSWB NR TESTER Para evitar firma comentarizar el else completo y endif
                }
                else
                {
                    // Ejecutar webservice de deslogeo
                    MessageBox.Show(SSS, "Error!!!", MessageBoxButtons.OK);
                    //mdlSeguridad.objSeguridad.Disconnect();
                    mdlSeguridad.objSeguridad = null;
                }
                //}

                this.Cursor = Cursors.Default;
            }
            catch (Exception excep)
            {

                MdlCambioMasivo.MsgError("Se Provoco el siguiente error: " + "\r\n" +
                                         "No. Error        :" + Information.Err().Number.ToString() + "\r\n" +
                                         "Descripcion      : " + excep.Message + "\r\n" +
                                         "Origen del Error : " + excep.Source);
            }

        }

        private bool isInitializingComponent;
        private void ID_ACC_BAN_COB_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            panel1.Refresh();
        }

        private void ID_ACC_BAN_COB_KeyPress(object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            switch (KeyAscii)
            {
                case 13:
                    ID_ACC_ACE_PB.Focus();
                    //ID_ACC_ACE_PB_Click(ID_ACC_ACE_PB, new EventArgs());
                    break;
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_ACC_BAN_COB_Leave(object sender, EventArgs e)
        {
            this.Refresh();
            Application.DoEvents();
        }

        private void ID_ACC_CAN_PB_Click(object sender, EventArgs e)
        {
            CORMDIBN.DefInstance.Close();
        }

        private void ID_ACC_USU_EB_KeyPress(object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

            if ((KeyAscii < 48 || KeyAscii > 57) && (KeyAscii < 65 || KeyAscii > 122) && KeyAscii != CORVB.KEY_TAB && KeyAscii != CORVB.KEY_RETURN && KeyAscii != CORVB.KEY_BACK)
            {
                KeyAscii = 0;
            }

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
                case 13:
                    ID_ACC_CVE_EB.Focus();
                    break;
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_ACC_TOKEN_EB_KeyPress(object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            //  KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

            if ((KeyAscii < 48 || KeyAscii > 57) && (KeyAscii < 65 || KeyAscii > 122) && KeyAscii != CORVB.KEY_TAB && KeyAscii != CORVB.KEY_RETURN && KeyAscii != CORVB.KEY_BACK)
            {
                KeyAscii = 0;
            }

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
                case 13:

                    if (ID_ACC_BAN_COB.Items.Count > CORVB.NULL_INTEGER)
                    {
                        ID_ACC_BAN_COB.Focus();
                    }
                    break;
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_ACC_USU_EB_Leave(object eventSender, EventArgs eventArgs)
        {
            ID_ACC_USU_EB.Text = ID_ACC_USU_EB.Text.ToUpper();
            CRSParametros.sgUserID = ID_ACC_USU_EB.Text;
        }

        private void ID_ACC_CVE_EB_KeyPress(object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            // KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

            if ((KeyAscii < 48 || KeyAscii > 57) && (KeyAscii < 65 || KeyAscii > 122) && KeyAscii != CORVB.KEY_TAB && KeyAscii != CORVB.KEY_RETURN && KeyAscii != CORVB.KEY_BACK)
            {
                KeyAscii = 0;
            }

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
                case 13:
                    ID_ACC_TOKEN_EB.Focus();
                    break;
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_ACC_CVE_EB_Leave(object eventSender, EventArgs eventArgs)
        {
            CRSParametros.sgPasswd = ID_ACC_CVE_EB.Text;
        }

        private void ID_ACC_TOKEN_EB_TextChanged(object sender, EventArgs e)
        {

        }

        private void ID_ACC_TOKEN_EB_Leave(object sender, EventArgs e)
        {
            CRSParametros.sgTokenID = ID_ACC_TOKEN_EB.Text;
        }

        // vars
        String strnomina = String.Empty;

        public String Strnomina
        {
            get { return strnomina; }
            set { strnomina = value; }
        }

        String strpassword = String.Empty;

        public String Strpassword
        {
            get { return strpassword; }
            set { strpassword = value; }
        }

        String strSirhOpe = String.Empty;

        public String StrSirhOpe
        {
            get { return strSirhOpe; }
            set { strSirhOpe = value; }
        }

        String strCaja = String.Empty;


        public String StrCaja
        {
            get { return strCaja; }
            set { strCaja = value; }
        }

        String strIp = String.Empty;

        public String StrIp
        {
            get { return strIp; }
            set { strIp = value; }
        }

        /*Datos de sesion*/
        String response_code = String.Empty;

        public String Response_code
        {
            get { return response_code; }
            set { response_code = value; }
        }


        String response_desc = String.Empty;

        public String Response_desc
        {
            get { return response_desc; }
            set { response_desc = value; }
        }
        String stds_err_txt = String.Empty;

        public String Stds_err_txt
        {
            get { return stds_err_txt; }
            set { stds_err_txt = value; }
        }
        String stdl_ses_id = String.Empty;

        public String Stdl_ses_id
        {
            get { return stdl_ses_id; }
            set { stdl_ses_id = value; }
        }
        String stdi_ope_numofic = String.Empty;

        public String Stdi_ope_numofic
        {
            get { return stdi_ope_numofic; }
            set { stdi_ope_numofic = value; }
        }


        String stds_ope_nombre = String.Empty;

        public String Stds_ope_nombre
        {
            get { return stds_ope_nombre; }
            set { stds_ope_nombre = value; }
        }

        String stdi_sol_rslt = String.Empty;
        public String Stdi_sol_rslt
        {
            get { return stdi_sol_rslt; }
            set { stdi_sol_rslt = value; }
        }

        String stdi_err_rslt = String.Empty;

        public String Stdi_err_rslt
        {
            get { return stdi_err_rslt; }
            set { stdi_err_rslt = value; }
        }
        String strCsi = String.Empty;
        public String StrCsi
        {
            get { return strCsi; }
            set { strCsi = value; }
        }

        String strToken = String.Empty;
        public String StrToken
        {
            get { return strToken; }
            set { strToken = value; }
        }

        String strSist = String.Empty;
        public String StrSist
        {
            get { return strSist; }
            set { strSist = value; }
        }

        // vars
    }
}