using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Runtime.InteropServices;

namespace TCd430
{
    internal class clsAltaTarjetahabiente
    {



        //*****************************************************************************
        //**                                                                         **
        //**                     EISSA / Banamex - Sistemas                          **
        //**                                                                         **
        //**       -----------------------------------------------------------       **
        //**                                                                         **
        //**       Descripción:  Lleva el control de los Estados dentro de           **
        //**                     la alta de los Ejecutivos                           **
        //**                                                                         **
        //**                                                                         **
        //**                                                                         **
        //**       Responsables: Marcos Garcia Cruz                                  **
        //**                                                                         **
        //**       Fecha de Modificación:  9 de Octubre del 2003                     **
        //**                                                                         **
        //**             NOTA: Esta clase esta hecha en Visual Basic 6.0             **
        //**                                                                         **
        //*****************************************************************************


        clsDatosEjecutivo gdteEjecutivo = null;
        string smTablaTemporal = String.Empty;
        //Variable para el dialogo
        clsDialogo gdlgDialogoS016 = null;
        clsDialogo gdlgDialogoS111 = null;
        string slRespuesta = String.Empty;

        //Variables para las conexiones
        /*private OLERut.Conexion _cnxConexionRut = null;
        OLERut.Conexion cnxConexionRut
        {
            get
            {
                if (_cnxConexionRut == null)
                {
                    _cnxConexionRut = new OLERut.Conexion();
                }
                return _cnxConexionRut;
            }
            set
            {
                _cnxConexionRut = value;
            }
        }*/
        string DirExe = Path.GetDirectoryName(Application.ExecutablePath);
        [DllImport("RUT.dll")]
        public extern static int RUT_Connect(string pcHostName, string pcService, bool bVal);
        [DllImport("RUT.dll")]
        public extern static int RUT_Disconnect(bool bVal);
        [DllImport("RUT.dll")]
        public extern static int RUT_WriteRead(string pcServerName, string pcRequest, ushort uRequestSize, [MarshalAs(UnmanagedType.VBByRefStr)] ref string pcReply, [MarshalAs(UnmanagedType.U2)] ref ushort puReplySize, bool bDisplayError);

        //Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
        clsDatosEjecutivo gdteEjeExists = null;

        public bool fncObtenNumB()
        {

            bool result = false;
            string slCuenta = String.Empty;
            int LngConsecutivo = 0;

            try
            {
                result = false;

                Cursor.Current = Cursors.WaitCursor;

                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_con_eje";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        // MsgInfo "No tarjeta Habiente a asignar : " & SqlData(hgblConexion, 1)
                        LngConsecutivo = Convert.ToInt32(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 1), 0));
                        //gdteEjecutivo.EjeNumL = CLng(Nvl(SqlData(hgblConexion, 1), 0))
                        //MsgInfo "No tarjeta Habiente a Asignado: " & gdteEjecutivo.EjeNumL
                    };
                    VBSQL.SqlCancel(CORVAR.hgblConexion);
                    //Determina que no haya ejecutivos que tengan el consecutivo
                    //Definido en la tabla de empresas y evitar inconsistencias en la informacion
                    CORVAR.pszgblsql = "Select Count(eje_num) as ConsecutivoEje";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCEJE01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num >= " + LngConsecutivo.ToString();
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {

                            //UPGRADE_WARNING: (1068) Nvl(SqlData(hgblConexion, 1), 0) of type Variant is being forced to double.
                            if (Convert.ToDouble(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 1), 0)) > 0)
                            {
                                MdlCambioMasivo.MsgError("Ya existen ejecutivos con el consecutivo definido para está empresa");
                                gdteEjecutivo.EjeNumL = -1;
                                //Exit Function
                            }
                            else
                            {
                                gdteEjecutivo.EjeNumL = LngConsecutivo;
                            }


                            //MsgInfo "No tarjeta Habiente a Asignado: " & gdteEjecutivo.EjeNumL
                        };
                    }
                    else
                    {
                        gdteEjecutivo.EjeNumL = -1;

                    }
                    VBSQL.SqlCancel(CORVAR.hgblConexion);

                }
                else
                {
                    MessageBox.Show("No se logro obtener el consecutivo de la empresa: " + StringsHelper.Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                if (gdteEjecutivo.EjeNumL > -1)
                {
                    slCuenta = (StringsHelper.Format(gdteEjecutivo.EjeProductoPRD.PrefijoL, gdteEjecutivo.EjeProductoPRD.MascaraPrefijoS) +
                               StringsHelper.Format(gdteEjecutivo.EjeProductoPRD.BancoL, gdteEjecutivo.EjeProductoPRD.MascaraBancoS) +
                               StringsHelper.Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS) +
                               StringsHelper.Format(gdteEjecutivo.EjeNumL, gdteEjecutivo.EjeProductoPRD.MascaraEjecutivoS) +
                               gdteEjecutivo.EjeRolloverI.ToString()).Trim();
                    //MsgInfo "Cuenta a generar: " & slCuenta
                    //MsgInfo "Iniciando proceso de digito verificador para la cuenta : " & slCuenta
                    gdteEjecutivo.EjeDigitI = CORPROC.Calcula_digito_verif(ref slCuenta);
                    // MsgInfo "Digito verificador calculado como  : " & gdteEjecutivo.EjeDigitI
                    result = true;
                }
                else
                {
                    result = false;
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (ObtenEjeNum)", e);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }

            return result;
        }
        public string fncEnviaDialogoLocalPrimeraS(ref  string spRespuesta, bool bpReAlta)
        {
            //envia el diálogo tanto al S016 como al S111

            //si va a ser una alta al S111 porque ya se encuentra dentro del S016 se
            //pone igIndAltaCteOk a 1, si no se encuentra en ninguno de los dos
            //se pone igIndAltaCteOk a 0

            string result = String.Empty;
            mdlParametros.igIndAltaCteOK = 0;

            gdlgDialogoS111 = new clsDialogo();
            gdlgDialogoS111.prGeneraDlg(gdteEjecutivo, clsDialogo.enuTipoDialogo.tAltaEjecutivoS111);


            Cursor.Current = Cursors.WaitCursor;

            string slDialogo = gdlgDialogoS111.DialogoS;

            gdlgDialogoS111 = null;
            //cnxConexionRut.Termina_Conexion();
            RUT_Disconnect(false);

            //if (! cnxConexionRut.Inicia_Conexion())
            int iresult = RUT_Connect(mdlParametros.sgEquipoUnix, mdlParametros.sgPuertoTandem, false);
            if (iresult != 0)
            {
                MessageBox.Show("No hay conexion al S111. Avise a sistemas.", "Conexión S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return "ErrorConexion";
            }
            //MsgInfo "Conexion establecida con Rut " & Chr(13) & "Se Enviará el dialogo actual al rut"
            mdlSeguridad.EnviaLog("Mensaje a enviar a Rut:" + "\r\n" + slDialogo);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje a enviar a Rut:" + "\r\n" + slDialogo);
            string tempRefParam = "S753-CONALTAS";
            //int ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
            ushort tamsal = 1654;
            string slDialogSal = new String(' ', tamsal);
            int ilRespuestaEnvio = RUT_WriteRead(tempRefParam, slDialogo, (ushort)slDialogo.Length, ref slDialogSal, ref tamsal, false);
            slDialogo = slDialogSal;
            mdlSeguridad.EnviaLog("Mensaje a Recibido de Rut:" + "\r\n" + slDialogo);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje a Recibido de Rut:" + "\r\n" + slDialogo);
            //MsgInfo "Se envio correctamente la  informacion a rut" & vbCrLf & "Se procederá a cerrar conexion con rut"
            Application.DoEvents();
            //cnxConexionRut.Termina_Conexion();
            RUT_Disconnect(false);

            string slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");

            if (ilRespuestaEnvio != 0)
            {
                MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
                result = "ErrorConexion";
                spRespuesta = slRespMensaje;
                return result;
            }
            if (slRespMensaje.IndexOf("error on RUT") >= 0)
            {
                MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
                result = "ErrorRut";
                spRespuesta = slRespMensaje;
                return result;
            }
            //MsgInfo "Procediendo a indetificar datos del rut: "

            string slClaveResultadoTransaccion = Strings.Mid(slRespMensaje, 32, 2);
            //MsgInfo "slClaveResultadoTransaccion:" & slClaveResultadoTransaccion
            string slClaveTransaccionAlta = Strings.Mid(slRespMensaje, 34, 4);
            //MsgInfo "slClaveTransaccionAlta :" & slClaveTransaccionAlta
            string slRespuestaTransaccion = Strings.Mid(slRespMensaje, 38, 30);
            //MsgInfo "slRespuestaTransaccion :" & slRespuestaTransaccion
            string slTextoError = Strings.Mid(slRespMensaje, 68, 60).Trim();
            //MsgInfo "slTextoError :" & slTextoError
            spRespuesta = slTextoError;

            if (slClaveResultadoTransaccion == "00" || slClaveResultadoTransaccion == "02" || slClaveResultadoTransaccion == "05" || slClaveResultadoTransaccion == "06" || slClaveResultadoTransaccion == "35")
            {

                result = slClaveResultadoTransaccion;
                return result;
            }

            if (slClaveResultadoTransaccion == "07")
            {
                //   If instr(UCase(slDescResp)) = "ALTA" Then
                //      fncEnviaDialogoLocalS = slClaveRespTransaccion & "alta"
                //      Screen.MousePointer = vbDefault
                //      Exit Function
                //   End If

                if (slTextoError.ToUpper().IndexOf("OK DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR TIMEOUT DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR COMUNICACION CON UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DATOS DE CALL DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO HAY DRIVERS EN DCRED") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN CSI-DESTINO") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN VALOR DE TIMEOUT") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 31 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 32 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 33 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DCRED EN CAMPO COMPUTER") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO CALIFICADO....") >= 0 || slTextoError.ToUpper().IndexOf("ERROR CODIGO RESPUESTA DESCONOCIDO") >= 0)
                {
                    result = slClaveResultadoTransaccion + "error";
                }
                else
                {
                    result = slClaveResultadoTransaccion + "errorx";
                }
                Cursor.Current = Cursors.Default;
                return result;
            }
            return slClaveResultadoTransaccion;

        }
        public string fncEnviaDialogoLocalSegundaS(ref  string spRespuesta, bool bpReAlta)
        {
            //envia el diálogo tanto al S016 como al S111

            //si va a ser una alta al S111 porque ya se encuentra dentro del S016 se
            //pone igIndAltaCteOk a 1, si no se encuentra en ninguno de los dos
            //se pone igIndAltaCteOk a 0

            string result = String.Empty;
            mdlParametros.igIndAltaCteOK = 1;
            gdlgDialogoS111 = new clsDialogo();
            gdlgDialogoS111.prGeneraDlg(gdteEjecutivo, clsDialogo.enuTipoDialogo.tAltaEjecutivoS111);
            Cursor.Current = Cursors.WaitCursor;
            string slDialogo = gdlgDialogoS111.DialogoS;
            gdlgDialogoS111 = null;
            //cnxConexionRut.Termina_Conexion();
            RUT_Disconnect(false);
            //if (! cnxConexionRut.Inicia_Conexion())

            int iresult = RUT_Connect(mdlParametros.sgEquipoUnix, mdlParametros.sgPuertoTandem, false);
            if (iresult != 0)
            {
                MessageBox.Show("No hay conexion al S111. Avise a sistemas.", "Conexión S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return "ErrorConexion";
            }
            mdlSeguridad.EnviaLog("Mensaje a enviar a Rut:" + "\r\n" + slDialogo);
            string tempRefParam = "S753-CONALTAS";
            //int ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
            ushort tamsal = 1654;
            string slDialogSal = new String(' ', tamsal);
            int ilRespuestaEnvio = RUT_WriteRead(tempRefParam, slDialogo, (ushort)slDialogo.Length, ref slDialogSal, ref tamsal, false);
            slDialogo = slDialogSal;
            mdlSeguridad.EnviaLog("Mensaje a Recibido de Rut:" + "\r\n" + slDialogo);
            Application.DoEvents();
            //cnxConexionRut.Termina_Conexion();
            RUT_Disconnect(false);

            string slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");
            if (ilRespuestaEnvio != 0)
            {
                MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
                result = "ErrorConexion";
                spRespuesta = slRespMensaje;
                return result;
            }
            if (slRespMensaje.IndexOf("error on RUT") >= 0)
            {
                MessageBox.Show("Existe un error en el TANDEM No.: " + slRespMensaje + "\r\n", Application.ProductName);
                result = "ErrorRut";
                spRespuesta = slRespMensaje;
                return result;
            }
            string slClaveResultadoTransaccion = Strings.Mid(slRespMensaje, 32, 2);
            string slClaveTransaccionAlta = Strings.Mid(slRespMensaje, 34, 4);
            string slRespuestaTransaccion = Strings.Mid(slRespMensaje, 38, 30);
            string slTextoError = Strings.Mid(slRespMensaje, 68, 60).Trim();

            spRespuesta = slTextoError;
            if (slClaveResultadoTransaccion == "00" || slClaveResultadoTransaccion == "02" || slClaveResultadoTransaccion == "05" || slClaveResultadoTransaccion == "06" || slClaveResultadoTransaccion == "35")
            {
                return slClaveResultadoTransaccion;
            }
            if (slClaveResultadoTransaccion == "07")
            {
                //   If instr(UCase(slDescResp)) = "ALTA" Then
                //      fncEnviaDialogoLocalS = slClaveRespTransaccion & "alta"
                //      Screen.MousePointer = vbDefault
                //      Exit Function
                //   End If
                if (slTextoError.ToUpper().IndexOf("OK DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR TIMEOUT DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR COMUNICACION CON UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DATOS DE CALL DCUNIS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO HAY DRIVERS EN DCRED") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN CSI-DESTINO") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN VALOR DE TIMEOUT") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 31 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 32 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR RESULT 33 EN HEADER UNISYS") >= 0 || slTextoError.ToUpper().IndexOf("ERROR EN DCRED EN CAMPO COMPUTER") >= 0 || slTextoError.ToUpper().IndexOf("ERROR NO CALIFICADO....") >= 0 || slTextoError.ToUpper().IndexOf("ERROR CODIGO RESPUESTA DESCONOCIDO") >= 0)
                {
                    result = slClaveResultadoTransaccion + "error";
                }
                else
                {
                    result = slClaveResultadoTransaccion + "errorx";
                }
                Cursor.Current = Cursors.Default;
                return result;
            }
            return slClaveResultadoTransaccion;
        }

        public bool fncGrabaTablaRespB()
        {

            bool result = false;
            try
            {
                //    If smTablaTemporal = "MTCMSV01" Then
                //       fncGrabaTablaRespB = True
                //       Exit Function
                //    End If
                Cursor.Current = Cursors.WaitCursor;

                CORVAR.pszgblsql = "insert into " + smTablaTemporal + " ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(eje_prefijo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_roll_over,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_digit,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nombre,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_rfc,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_sueldo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_num_nom,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_centro_c,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nivel,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nom_gra,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_calle,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_col,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_pob,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_edo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_zp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_dom,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_ofi,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ext,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_fax,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_limcred,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "reg_num,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cuenta_bnx,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_sexo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_suc_trans,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_suc_prom,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_origen,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_acti_subacti,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_calle,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_col,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_ciu,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_pob,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_edo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_dom_cp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_email,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cta_contable,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_gen_pin_pla,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_lim_dis_efec,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_cuenta,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_fac,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_skip_payment,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tabla_mcc,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ind_lim_disp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ind_cta_ctrl,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_nacionalidad,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_status_reg,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_bloqueo)";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_atn_a,"; //FSWB NR 20070222 Se incluyen campos Atencion A y Persona
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tipo_persona) "; //FSWB NR 20070222
                CORVAR.pszgblsql = CORVAR.pszgblsql + "values (" + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeEmpNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeRolloverI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeDigitI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeNomS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeSueldoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeNumNomS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeCentroCostS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeNivelI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeNomGrabaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomEnvioDMC.DomicilioS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomEnvioDMC.ColoniaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomEnvioDMC.PoblacionS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeDomEnvioDMC.CPL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeTelDomS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeTelOfiS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeExtensionS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeFaxS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeLimCredL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeRegNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeEstatusS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeCuentaBnxS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeSexoS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeSucTransS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeSucPromS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeOrigenS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeActiSubactiS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.DomicilioS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.ColoniaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.CiudadS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.PoblacionS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeDomPartDMC.EstadoEST.AbreviaturaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeDomPartDMC.CPL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeEmailS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeCtaContableS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeGenPinPlaI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeLimDisEfecL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeTipoCuentaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeTipoFactS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeSkipPaymentL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeTablaMCCL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeIndLimDispS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeIndCtaCtrlS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeNacionalidadS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjeTipoBloqueoI.ToString() + ")";

                //CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + gdteEjecutivo.EjeAtencionA + "'"; //FSWB NR 20070222 Se incluyen campos Atencion A y Persona
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "," + gdteEjecutivo.EjePersona.ToString() + ")"; //FSWB NR 20070222 Se incluyen campos Atencion A y Persona

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    result = true;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el registro en la tabla de respaldo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (GrabaTablaResp)", e);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }

            return result;
        }


        public bool fncActualizaConsecutivoB()
        {

            bool result = false;
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                CORVAR.pszgblsql = "update MTCEMP01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_con_eje = " + ((gdteEjecutivo.EjeNumL + 1).ToString()) + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    result = true;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el consecutivo de ejecutivo de la empresa: " + gdteEjecutivo.EjeEmpNumL.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (ActualizaConsecutivo)", e);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }

            return result;
        }
        public bool fncActualizaEstatusTemporalB(int ipEstatus)
        {
            //ipEstatus es el estado dentro del diagrama de transicion que le corresponde y se graba dentro de
            //MTCIND01
            bool result = false;
            Cursor.Current = Cursors.WaitCursor;

            CORVAR.pszgblsql = "update " + smTablaTemporal + " ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_status_reg = " + ipEstatus.ToString().Trim();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_nom_gra = '" + gdteEjecutivo.EjeNomGrabaS + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";
            if (CORPROC2.Modifica_Registro() != 0)
            {
                Cursor.Current = Cursors.Default;
                return true;
            }
            else
            {
                MessageBox.Show("No se actualizó el estatus del Ejecutivo en la tabla de Respaldo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
                Cursor.Current = Cursors.Default;
                return result;
            }
            return result;
        }

        public string fncConsultaS111S()
        {
            //Lo que hace esta función es ver si el ejecutivo se dió de alta correctamente dentro del S111
            //y si lo que se encuentra dado de alta realmente coincide con los datos que se capturaron

            string result = String.Empty;
            gdlgDialogoS111 = new clsDialogo();
            gdlgDialogoS111.prGeneraDlg(gdteEjecutivo, clsDialogo.enuTipoDialogo.tConsEjecutivoS111);
            string slDialogo = gdlgDialogoS111.DialogoS;
            gdlgDialogoS111 = null;

            //cnxConexionRut.Termina_Conexion();
            RUT_Disconnect(false);
            //if (! cnxConexionRut.Inicia_Conexion())
            int iresult = RUT_Connect(mdlParametros.sgEquipoUnix, mdlParametros.sgPuertoTandem, false);
            if (iresult != 0)
            {
                MessageBox.Show("No hay conexion al S111. Avise a sistemas.", "Conexión S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return "ErrorConexion";
            }
            string tempRefParam = "S753-CONALTAS";
            //int ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
            ushort tamsal = 1654;
            string slDialogSal = new String(' ', tamsal);
            int ilRespuestaEnvio = RUT_WriteRead(tempRefParam, slDialogo, (ushort)slDialogo.Length, ref slDialogSal, ref tamsal, false);
            slDialogo = slDialogSal;
            Application.DoEvents();
            //cnxConexionRut.Termina_Conexion();
            RUT_Disconnect(false);
            string slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");

            if (slDialogo.IndexOf("Error on SEND") >= 0)
            {
                //   MsgBox "Error en la conexión.", vbCritical + vbOKOnly, "Tarjeta Corporativa"
                result = "ErrorConexion";
                Cursor.Current = Cursors.Default;
                return result;
            }
            if (ilRespuestaEnvio != 0)
            {
                //   MsgBox "Error en la conexión.", vbCritical + vbOKOnly, "Tarjeta Corporativa"
                result = "ErrorConexion";
                Cursor.Current = Cursors.Default;
                return result;
            }
            string slCadena1 = Strings.Mid(slRespMensaje, 1243, 151).Trim();
            string slCadena2 = Strings.Mid(slRespMensaje, 38, 371).Trim();
            string slCadena3 = Strings.Mid(slRespMensaje, 1608, 31).Trim();
            if (slCadena1.Trim() == "")
            {
                MessageBox.Show("Error en el envio de la informacion.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = "NoEncontrado";
                Cursor.Current = Cursors.Default;
                return result;
            }
            gdteEjeExists = null;
            gdteEjeExists = new clsDatosEjecutivo();

            gdteEjeExists.EjeNomGrabaS = Strings.Mid(slCadena1, 1, 26).Trim();
            gdteEjeExists.EjeDomEnvioDMC.DomicilioS = Strings.Mid(slCadena1, 46, 35).Trim();
            gdteEjeExists.EjeDomEnvioDMC.ColoniaS = Strings.Mid(slCadena1, 81, 25).Trim();
            gdteEjeExists.EjeDomEnvioDMC.PoblacionS = Strings.Mid(slCadena1, 106, 21).Trim();

            switch (Strings.Mid(slCadena1, 138, 1).Trim())
            {
                case "1":
                    gdteEjeExists.EjeTipoCuentaS = "       Básica       ";
                    break;
                case "2":
                    gdteEjeExists.EjeTipoCuentaS = "      Adicional     ";
                    break;
                case "3":
                    gdteEjeExists.EjeTipoCuentaS = "Básica con Adicional";
                    break;
            }

            gdteEjeExists.EjeSucTransS = Strings.Mid(slCadena1, 139, 4).Trim();
            gdteEjeExists.EjeSexoS = Strings.Mid(slCadena1, 145, 1).Trim();
            gdteEjeExists.EjeRfcRFC.RFCS = Strings.Mid(slRespMensaje, 1396, 10);
            string slCausaS111 = Strings.Mid(slCadena3, 1, 19).Trim();
            string slFecAlta = Strings.Mid(slCadena3, 20, 6).Trim();
            string slFecModificacion = Strings.Mid(slCadena3, 26, 6).Trim();
            string slValidacion = fncValidaDatosS(mdlEjecutivo.enuTipoAltaSistema.tasAltaS111);

            if (slValidacion == "")
            {
                result = "Coinciden";
            }
            else
            {
                //MsgBox "Hay Inconsistencia de Datos en el S111 en el campo " & slValidacion, vbInformation + vbOKOnly, "Tarjeta Corporativa"
                result = "NoCoinciden";
            }
            Cursor.Current = Cursors.Default;
            return result;
        }

        public string fncConsultaTemporal()
        {

            int lContador = 0;
            Cursor.Current = Cursors.WaitCursor;
            CORVAR.pszgblsql = "select ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_num,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_roll_over,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_digit ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + smTablaTemporal;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + gdteEjecutivo.EjeNumL.ToString();


            CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
            CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
            //Si hubo éxito...
            if (CORVAR.igblRetorna == VBSQL.SUCCEED)
            {
                //Si ejecutó correctamente
                CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lContador++;
                };
                if (lContador >= 1)
                {
                    return "Coinciden";
                }
                else
                {
                    return "NoCoinciden";
                }
            }
            else
            {
                return "ErrorConexion";
            }

        }

        public string fncConsultac430S()
        {

            int lContador = 0;
            Cursor.Current = Cursors.WaitCursor;
            CORVAR.pszgblsql = "select ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_banco,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_num,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_roll_over,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_digit ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJE01 ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + gdteEjecutivo.EjeNumL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_nom_gra = '" + gdteEjecutivo.EjeNomGrabaS + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";

            CORVAR.igblRetorna = VBSQL.SqlCmd(CORVAR.hgblConexion, CORVAR.pszgblsql);
            CORVAR.igblRetorna = VBSQL.SqlExec(CORVAR.hgblConexion);
            //Si hubo éxito...
            if (CORVAR.igblRetorna == VBSQL.SUCCEED)
            {
                //Si ejecutó correctamente
                CORVAR.igblRetorna = VBSQL.SqlResults(CORVAR.hgblConexion);

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lContador++;
                };
                if (lContador >= 1)
                {
                    return "Coinciden";
                }
                else
                {
                    return "NoCoinciden";
                }
            }
            else
            {
                return "ErrorConexion";
            }

        }

        public string fncConsultaS111EjeComDrv(string slCuenta, out string slConsulta)
        {
            //Consulta con Trans. 5001 si existe en S111

            string result = String.Empty;
            string slDialogo = String.Empty;
            mdlParametros.igIndAltaCteOK = 0;

            Cursor.Current = Cursors.WaitCursor;
            //string slDialogo = gdlgDialogoS111.DialogoS;
            string gvRecive = String.Empty;
            string gvRecive5566_01 = String.Empty;
            bool resultOk = false;

            if (slCuenta == "")
            {
                slDialogo = "5001 " + gdteEjecutivo.EjeCuentaS + " ";
            }
            else
            {
                slDialogo = "5001 " + slCuenta + " ";
            }

            gvRecive = funConComdrv(slDialogo);
            mdlSeguridad.EnviaLog("Mensaje Envio de Comdrv:" + "\r\n" + slDialogo);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje a enviar a Comdrv:" + "\r\n" + slDialogo);

            if (gvRecive.IndexOf("SEG;") >= 0 || gvRecive.IndexOf("SEG:") >= 0)
            {
                ///////////////////////////////
                
                MessageBox.Show("Necesita firmarse para dar el alta");

                frmLoginS53 frmFirma = new frmLoginS53();
                frmFirma.ShowDialog();
                
                gvRecive = funConComdrv(slDialogo);

                int intIntentos = 1;

                while (Strings.Mid(gvRecive, 1, 4) != "5001" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {

                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {
                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }
            }
            else
            {
                gvRecive = funConComdrv(slDialogo);
                int intIntentos = 1;
                while (Strings.Mid(gvRecive, 1, 4) != "5001" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {
                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {

                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }
            }
            mdlSeguridad.EnviaLog("Mensaje Recive de Comdrv:" + "\r\n" + gvRecive);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje Recibe Comdrv:" + "\r\n" + gvRecive);


            if (gvRecive.ToUpper().IndexOf("S111-CONSUL-NOM") >= 0)
            {
                slConsulta = " ";
                return "ErrorConexion";
            }
            else
                if (gvRecive.ToUpper().IndexOf("DIRECCION") >= 0)
                {
                    slConsulta = gvRecive;
                    return "Coinciden";
                }
                else
                {
                    slConsulta = " ";
                    return "NoCoinciden";
                }



        }

        public bool fncInsertaM111B()
        {

            bool result = false;
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                gdteEjecutivo.EjeCuentaBnxS = (StringsHelper.Format(gdteEjecutivo.EjeProductoPRD.PrefijoL, gdteEjecutivo.EjeProductoPRD.MascaraPrefijoS) + StringsHelper.Format(gdteEjecutivo.EjeProductoPRD.BancoL, gdteEjecutivo.EjeProductoPRD.MascaraBancoS) + StringsHelper.Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS) + StringsHelper.Format(gdteEjecutivo.EjeNumL, gdteEjecutivo.EjeProductoPRD.MascaraEjecutivoS) + gdteEjecutivo.EjeRolloverI.ToString().Trim() + gdteEjecutivo.EjeDigitI.ToString().Trim()).Trim();

                //CORVAR.pszgblsql = "exec spAltaEjecutivo ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeProductoPRD.BancoL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeEmpNumL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeNumL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeRolloverI.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeDigitI.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeNomS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeRfcRFC.RFCS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeSueldoL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeNumNomS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeCentroCostS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeNivelI.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeNomGrabaS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomEnvioDMC.DomicilioS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomEnvioDMC.ColoniaS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomEnvioDMC.PoblacionS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "0,";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeDomEnvioDMC.CPL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeTelDomS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeTelOfiS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeExtensionS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeFaxS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeLimCredL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeRegNumL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeEstatusS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeCuentaBnxS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeSexoS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeSucTransS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeSucPromS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeOrigenS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeActiSubactiS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.DomicilioS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.ColoniaS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.CiudadS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.PoblacionS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeDomPartDMC.EstadoEST.AbreviaturaS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeDomPartDMC.CPL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeEmailS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeCtaContableS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeGenPinPlaI.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeLimDisEfecL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeTipoCuentaS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeTipoFactS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeSkipPaymentL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeTablaMCCL.ToString() + ",";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeIndLimDispS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeIndCtaCtrlS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeNacionalidadS + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + CRSParametros.sgUserID + "',";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeTipoBloqueoI.ToString() + ",";

                //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + gdteEjecutivo.EjeAtencionA + "',"; //FSWB 20070222 Se incluyen campos Atencion A y Persona
                //CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjePersona.ToString(); //FSWB 20070222 Se incluyen campos Atencion A y Persona

                CORVAR.pszgblsql = "exec spI_Alta_Tarjetahabiente ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  @prefijo             =" + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " ,@banco               =" + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@num_emp            =" + gdteEjecutivo.EjeEmpNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@consecutivo        =" + gdteEjecutivo.EjeNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@roll_over          =" + gdteEjecutivo.EjeRolloverI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@digit              =" + gdteEjecutivo.EjeDigitI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@nombre             ='" + gdteEjecutivo.EjeNomS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@rfc                ='" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@sueldo             =" + gdteEjecutivo.EjeSueldoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@num_nom            ='" + gdteEjecutivo.EjeNumNomS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@centro_c           ='" + gdteEjecutivo.EjeCentroCostS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@nivel              =" + gdteEjecutivo.EjeNivelI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@nom_gra            ='" + gdteEjecutivo.EjeNomGrabaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@calle              ='" + gdteEjecutivo.EjeDomEnvioDMC.DomicilioS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@col                ='" + gdteEjecutivo.EjeDomEnvioDMC.ColoniaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@pob                ='" + gdteEjecutivo.EjeDomEnvioDMC.PoblacionS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpEstado           ='" + gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.AbreviaturaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@zp                 = 0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cp                 = " + gdteEjecutivo.EjeDomEnvioDMC.CPL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@tel_dom            ='" + gdteEjecutivo.EjeTelDomS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@tel_ofi            ='" + gdteEjecutivo.EjeTelOfiS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@ext                ='" + gdteEjecutivo.EjeExtensionS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@fax                ='" + gdteEjecutivo.EjeFaxS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@limcred            =" + gdteEjecutivo.EjeLimCredL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@num                =" + gdteEjecutivo.EjeRegNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@status             ='" + gdteEjecutivo.EjeEstatusS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@sexo               ='" + gdteEjecutivo.EjeSexoS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@suctran            ='" + gdteEjecutivo.EjeSucTransS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@sucprom            ='" + gdteEjecutivo.EjeSucPromS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@origen             ='" + gdteEjecutivo.EjeOrigenS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@actisubacti        ='" + gdteEjecutivo.EjeActiSubactiS + "'";
                //'MsgInfo ID_MEM_DOM_EB(0).Text

                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpDomCalle         ='" + gdteEjecutivo.EjeDomPartDMC.DomicilioS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpDomColonia       ='" + gdteEjecutivo.EjeDomPartDMC.ColoniaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpDomCiudad        ='" + gdteEjecutivo.EjeDomPartDMC.CiudadS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpDomPoblacion     ='" + gdteEjecutivo.EjeDomPartDMC.PoblacionS + "'";

                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpDomEstado        ='" + gdteEjecutivo.EjeDomPartDMC.EstadoEST.AbreviaturaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@ipDomCodigoPostal  =";

                if (gdteEjecutivo.EjeDomPartDMC.CPL.ToString() == "")
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "Null";
                }
                else
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + gdteEjecutivo.EjeDomPartDMC.CPL.ToString();
                }

                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpEMail            ='" + gdteEjecutivo.EjeEmailS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpCtaContable      ='" + gdteEjecutivo.EjeCtaContableS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@spGenPinPlastico   =" + gdteEjecutivo.EjeGenPinPlaI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@ipLimDispEfectivo  =" + gdteEjecutivo.EjeLimDisEfecL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpUsuarioCambio    ='" + CRSParametros.sgUserID + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpTipoCuenta       ='" + gdteEjecutivo.EjeTipoCuentaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpTipoFactura      ='" + gdteEjecutivo.EjeTipoFactS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@ipSkipPayment      =" + gdteEjecutivo.EjeSkipPaymentL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@ipTablaMCC         =" + gdteEjecutivo.EjeTablaMCCL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpIndLimEfe        ='P'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpNacionalidad     ='" + gdteEjecutivo.EjeNacionalidadS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@cpIndCtaCtrl       ='" + gdteEjecutivo.EjeIndCtaCtrlS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@eje_tipobloqueo    =" + gdteEjecutivo.EjeTipoBloqueoI.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "  ,@ejx_numero         =" + gdteEjecutivo.EjeEjecBnx.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", @eje_atn_a = '', @eje_tipo_persona = 2";  //'FSWB NR 20070226  'Atencion A y Persona

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    result = true;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el ejecutivo: " + gdteEjecutivo.EjeEmpNumL.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (InsertaEjecutivoM111)", e);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }

            return result;
        }
        public bool fncActualizaCredAcumB()
        {

            bool result = false;
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                //    pszgblsql = "update MTCEMP01 "
                //    pszgblsql = pszgblsql & " set emp_acum_cred = "
                //    pszgblsql = pszgblsql & " (select isnull(sum(eje_limcred),0) "
                //    pszgblsql = pszgblsql & " from MTCEJE01 "
                //    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
                //    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
                //    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
                //    pszgblsql = pszgblsql & " and eje_num > 0 "
                //    pszgblsql = pszgblsql & " group by eje_prefijo, gpo_banco, emp_num),"
                //    pszgblsql = pszgblsql & " emp_usu_cam = '" & sgUserID & "' "
                //    pszgblsql = pszgblsql & " where eje_prefijo = " & gdteEjecutivo.EjeProductoPRD.PrefijoL
                //    pszgblsql = pszgblsql & " and gpo_banco = " & gdteEjecutivo.EjeProductoPRD.BancoL
                //    pszgblsql = pszgblsql & " and emp_num = " & gdteEjecutivo.EjeEmpNumL
                // Modif. 18/Jun/2007 Calc Lim Real
                CORVAR.pszgblsql = "update MTCEMP01 ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_acum_cred = ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )), ";
                //    pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )), "

                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "' ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    result = true;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el credito acumulado de la empresa: " + gdteEjecutivo.EjeEmpNumL.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (ActualizaCredAcumEmp)", e);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }

            return result;
        }
        //Public Property Let Temporal(data As String)
        //If data = "MTCIND01" Then
        //   smTablaTemporal = "MTCIND01"
        //Else
        //   smTablaTemporal = "MTCMSV01"
        //End If
        //End Property
        private string fncValidaDatosS(mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
        {
            string result = String.Empty;
            result = "";
            if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS016)
            {
                if (gdteEjeExists.EjeNomGrabaS != gdteEjecutivo.EjeNomGrabaS)
                {
                    result = "Nombre de Grabación";
                }
                else if (gdteEjeExists.EjeRfcRFC.RFCS != gdteEjecutivo.EjeRfcRFC.RFCS)
                {
                    result = "RFC";
                }

            }
            else if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS111)
            {
                if (gdteEjeExists.EjeNomGrabaS != gdteEjecutivo.EjeNomGrabaS)
                {
                    result = "Nombre de Grabación";
                }
                else if (gdteEjeExists.EjeRfcRFC.RFCS != gdteEjecutivo.EjeRfcRFC.RFCS.Substring(0, Math.Min(gdteEjecutivo.EjeRfcRFC.RFCS.Length, 10)))
                {
                    result = "RFC";
                }
                //            If gdteEjeExists.EjeNomGrabaS <> gdteEjecutivo.EjeNomGrabaS Then
                //                fncValidaDatosS = "Nombre"
                //            ElseIf gdteEjeExists.EjeDomEnvioDMC.DomicilioS <> gdteEjecutivo.EjeDomEnvioDMC.DomicilioS Then
                //                fncValidaDatosS = "Calle"
                //            ElseIf gdteEjeExists.EjeDomEnvioDMC.ColoniaS <> gdteEjecutivo.EjeDomEnvioDMC.ColoniaS Then
                //                fncValidaDatosS = "Colonia"
                //            ElseIf gdteEjeExists.EjeDomEnvioDMC.PoblacionS <> gdteEjecutivo.EjeDomEnvioDMC.PoblacionS Then
                //                fncValidaDatosS = "Población"
                //            ElseIf gdteEjeExists.EjeSexoS <> gdteEjecutivo.EjeSexoS Then
                //                fncValidaDatosS = "Sexo"
                //            ElseIf gdteEjeExists.EjeTipoCuentaS <> "       Básica       " Then
                //                fncValidaDatosS = "Tipo de Cuenta"
                //            ElseIf gdteEjeExists.EjeSucTransS <> gdteEjecutivo.EjeSucTransS Then
                //                fncValidaDatosS = "Sucursal"
                //            End If
            }

            return result;
        }
        public clsDatosEjecutivo EjegdteEjecutivo
        {
            set
            {
                if (Information.IsReference(value))
                {
                    gdteEjecutivo = value;
                }
                else
                {
                    gdteEjecutivo = null;
                }
            }
        }

        public string Temporal
        {
            set
            {
                if (value == "MTCIND02")
                {
                    smTablaTemporal = "MTCIND02";
                }
                else
                {
                    smTablaTemporal = "MTCMSV02";
                }
            }
        }

        public bool fncEliminaRespB()
        {

            bool result = false;
            try
            {

                Cursor.Current = Cursors.WaitCursor;

                CORVAR.pszgblsql = " delete ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + smTablaTemporal + " ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_status_reg = 7 ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_nom_gra = '" + gdteEjecutivo.EjeNomGrabaS + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";
                if (CORPROC2.Modifica_Registro() != 0)
                {
                    result = true;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el respaldo del ejecutivo.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (EliminaEjecutivoResp)", e);
                    result = false;
                    Cursor.Current = Cursors.Default;
                    return result;
                }
            }

            return result;
        }

        //Private Function fncValidaResultadoS(slRespuesta As String) As String
        //Dim ilContador As Integer
        //Dim ilLongitud As Integer
        //Dim slTemporal As String
        //Dim slAux As String
        //Dim caracter As String
        //slAux = Left(Trim(slRespuesta), 100)
        //slTemporal = ""
        //ilLongitud = Len(slAux)
        //For ilContador = 1 To ilLongitud
        //   caracter = Mid(slAux, ilContador, 1)
        //   If IsNumeric(caracter) Or _
        //'      (Asc(caracter) >= 65 And Asc(caracter) >= 90) Or _
        //'      (Asc(caracter) >= 97 And Asc(caracter) >= 122) Or _
        //'      (Asc(caracter) = 32) Or (Asc(caracter) = 91) Then
        //         slTemporal = slTemporal & caracter
        //   End If
        //Next
        //slTemporal = Trim(slTemporal)
        //slTemporal = Left(slTemporal, 100)
        //fncValidaResultadoS = slTemporal
        //End Function
        //Public Sub prRegistraLog(slRespuesta As String)
        //Dim slArchivo As String
        //Dim llarchivo As Integer
        //Dim slResultado As String
        //On Error GoTo falloarchivo
        //slArchivo = Format(Now(), "mmddhms") & ".log"
        //Load frm_error_envio
        //slResultado = fncValidaResultadoS(slRespuesta)
        //frm_error_envio.lblMensajeError = "Se encontró un error al registrar el Alta." & vbCrLf & _
        //'           "Para una información más detallada, vea el archivo " & slArchivo '& vbCrLf & slRespuesta
        //frm_error_envio.txt_error.Text = slRespuesta
        //frm_error_envio.Show vbModal
        //llarchivo = FreeFile()
        //slArchivo = smArchivoLog & slArchivo
        //Open slArchivo For Output As #llarchivo
        //Print #llarchivo, slResultado
        //Print #llarchivo, "Nombre:" & gdteEjecutivo.EjeNomS
        //Print #llarchivo, "RFC:" & gdteEjecutivo.EjeRfcRFC
        //Print #llarchivo, "Nombre Grabado:" & gdteEjecutivo.EjeNomGrabaS
        //Print #llarchivo, "Domicilio Envio:" & gdteEjecutivo.EjeDomEnvioDMC
        //Print #llarchivo, "Limite de Crédito:" & gdteEjecutivo.EjeLimCredL
        //Close #llarchivo
        //Exit Sub
        //falloarchivo:
        //MsgBox "No se pudo crear al archivo " & slArchivo
        //Exit Sub
        //End Sub

        public void prRegistraLog(string slRespuesta)
        {

            string Cadena = String.Empty;
            string slResultado = fncValidaResultadoS(slRespuesta);
            string slMensajesS = fncObtenMensajesS(slResultado);
            frm_error_envio tempLoadForm = frm_error_envio.DefInstance;
            frm_error_envio.DefInstance.lblMensajeError.Text = "Se encontró un error al registrar el Alta.";
            frm_error_envio.DefInstance.txt_error.Text = slResultado;
            frm_error_envio.DefInstance.ShowDialog();
            string slRuta = fncCreaRutaS();
            string slArchivo = fncCreaNombreArchivoS(slRuta);
            int num_archivo = FileSystem.FreeFile();
            if (!fncRevisaCarpetaB(slRuta))
            {
                prCreaCarpeta(slRuta);
                FileSystem.FileOpen(num_archivo, slArchivo, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
            }
            else
            {
                if (!fncRevisaArchivoB(slArchivo))
                {
                    FileSystem.FileOpen(num_archivo, slArchivo, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                }
                else
                {
                    FileSystem.FileOpen(num_archivo, slArchivo, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
                }
            }
            FileSystem.PrintLine(num_archivo, slMensajesS);
            FileSystem.FileClose(num_archivo);
        }

        private string fncValidaResultadoS(string slRespuesta)
        {
            return slRespuesta.Trim();
        }

        private string fncObtenMensajesS(string plRespuesta)
        {
            //Se arma el mensaje de error que va a se introducido dentro del archivo
            string slMensaje = " Nombre Tarjetahabiente: " + gdteEjecutivo.EjeNomS;
            slMensaje = slMensaje + " RFC:" + gdteEjecutivo.EjeRfcRFC.RFCS;
            slMensaje = slMensaje + " Nombre Grabado:" + gdteEjecutivo.EjeNomGrabaS;
            slMensaje = slMensaje + " Domicilio Envio:" + gdteEjecutivo.EjeDomEnvioDMC.CiudadS;
            slMensaje = slMensaje + " Limite de Crédito:" + gdteEjecutivo.EjeLimCredL.ToString();
            slMensaje = slMensaje + plRespuesta;
            return slMensaje;
        }

        private string fncCreaRutaS()
        {
            string CarpetaMensajesError = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "MensajesError";

            if (Directory.Exists(CarpetaMensajesError))
            {
                System.IO.Directory.CreateDirectory(CarpetaMensajesError);
            }
            return CarpetaMensajesError;
            //return Path.GetDirectoryName(Application.ExecutablePath) + Strings.Chr(92).ToString() + "MensajesError";
        }

        private string fncCreaNombreArchivoS(string spRuta)
        {
            return spRuta + Strings.Chr(92).ToString() + "MensajesError.txt";
        }

        private bool fncRevisaCarpetaB(string spCarpeta)
        {
            Scripting.FileSystemObject fs = new Scripting.FileSystemObject();
            return fs.FolderExists(spCarpeta);
        }

        private void prCreaCarpeta(string spCarpeta)
        {
            try
            {
                Directory.CreateDirectory(spCarpeta);
            }
            catch
            {

                MessageBox.Show("No fue posible crear la carpeta de mensajes.", Application.ProductName);
            }
        }

        private bool fncRevisaArchivoB(string spArchivo)
        {
            Scripting.FileSystemObject fs = new Scripting.FileSystemObject();
            return fs.FileExists(spArchivo);
        }

        public bool fncDialogoComdrv(string slMensaje, ref  string slRespuesta)
        {
            bool result = false;
            COMDRV32.TcpServer objProxy = null;
            string slArgumento = String.Empty;
            bool blSalir = false;
            string slContestacion = String.Empty;
            try
            {
                if (pfCargaTcpServerB(ref objProxy))
                {
                    slArgumento = "";
                    //Captura el mensaje enviado por el TCPSERVER
                    slArgumento = "D" + slMensaje.Trim() + Strings.Chr(3).ToString();
                    objProxy.SendRequest(StringsHelper.StrConv(slArgumento, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)slArgumento.Length);
                    blSalir = false;
                    while (!blSalir)
                    {

                        slContestacion = StringsHelper.StrConv(objProxy.ReceiveResponse(60000), StringsHelper.VbStrConvEnum.vbUnicode, 0);
                    }
                    slRespuesta = slContestacion;
                    prDescargaTcpServer(ref objProxy);
                    result = true;
                }
                else
                {
                    MessageBox.Show("Error al cargar al objeto", Application.ProductName);
                }
            }
            catch (Exception excep)
            {

                if (Information.Err().Number == -2147014836)
                {
                    blSalir = true;
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    MessageBox.Show(excep.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                result = true;
            }
            return result;
        }
        private bool pfCargaTcpServerB(ref  COMDRV32.TcpServer objProxy)
        {
            try
            {
                objProxy = new COMDRV32.TcpServer();
                objProxy.Connect();
                return true;
            }
            catch (Exception excep)
            {

                if (Information.Err().Number == 0x80072AFC)
                {
                    MessageBox.Show(Information.Err().Number.ToString() + " direccion ip erronea", Application.ProductName);
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    MessageBox.Show(Information.Err().Number.ToString() + " " + excep.Message, Application.ProductName);
                }
                return false;
            }
        }
        private void prDescargaTcpServer(ref  COMDRV32.TcpServer objProxy)
        {
            //Desconecta al cobjeto comdvr y lo destruye
            objProxy.Disconnect();
        }

        public string fncEnviaDialogoLocalPrimeraSComdrv(ref  string spRespuesta, bool bpReAlta)
        {
            //Envia el diálogo S753

            string result = String.Empty;

            mdlParametros.igIndAltaCteOK = 0;
            gdlgDialogoS111 = new clsDialogo();
            gdlgDialogoS111.prGeneraDlg(gdteEjecutivo, clsDialogo.enuTipoDialogo.tAltaEjecutivosComdrv);
            Cursor.Current = Cursors.WaitCursor;
            string slDialogo = gdlgDialogoS111.DialogoS;
            string gvRecive = String.Empty;
            string gvRecive5566_01 = String.Empty;
            bool resultOk = false;

            mdlSeguridad.EnviaLog("Mensaje Envio de Comdrv:" + "\r\n" + slDialogo);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje a enviar a Comdrv:" + "\r\n" + slDialogo);
            gvRecive = funConComdrv(slDialogo);

            if (gvRecive.IndexOf("SEG;") >= 0 || gvRecive.IndexOf("SEG:") >= 0)
            {
                ///////////////////////////////
                MessageBox.Show("Necesita firmarse para dar el alta");

                frmLoginS53 frmFirma = new frmLoginS53();
                frmFirma.ShowDialog();

                gvRecive = funConComdrv(slDialogo);

                int intIntentos = 1;

                while (Strings.Mid(gvRecive, 1, 4) != "5566" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {
                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {

                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }

                //////segunda parte verifica errores

                if (Strings.Mid(gvRecive, 1, 4) == "5566" && Strings.Mid(gvRecive, 6, 2) == "01")
                {
                    //Validar respuesta sea OK (0)
                    if (Strings.Mid(gvRecive, 45, 2) == "00")// && Strings.Mid(gvRecive, 24, 8) == estHeaderAltas.strHDFolInterno.Value)
                    {
                        gvRecive5566_01 = gvRecive;
                        resultOk = true;

                    }
                    else
                    {
                        Interaction.Beep();
                        if (gvRecive.Trim().Length == 0)
                        {
                            string tempRefParam7 = "Respuesta erronea de Tandem o se acabó el tiempo de espera. Por favor reintente.";
                            MessageBox.Show(tempRefParam7, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {
                            if (gvRecive.IndexOf("CONTRATO A DAR DE ALTA YA EXISTE") >= 0)
                            {
                                gvRecive5566_01 = gvRecive;
                                resultOk = true;
                            }
                            else
                            {
                                string tempRefParam9 = Strings.Mid(gvRecive, 47, 50) + "\n" + "\r" + Strings.Mid(gvRecive, 223, 72).Trim();
                                MessageBox.Show(tempRefParam9, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                        }
                        //resultOk = false;
                    }
                }

                else
                {
                    Interaction.Beep();
                    string tempRefParam11 = Strings.Mid(gvRecive, 1, 50);
                    MessageBox.Show(tempRefParam11, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultOk = false;
                }
            }
            else
            {
                int intIntentos = 1;
                while (Strings.Mid(gvRecive, 1, 4) != "5566" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {
                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {

                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }


                //////segunda parte verifica errores

                if (Strings.Mid(gvRecive, 1, 4) == "5566" && Strings.Mid(gvRecive, 6, 2) == "01")
                {
                    //Validar respuesta sea OK (0)
                    if (Strings.Mid(gvRecive, 45, 2) == "00")// && Strings.Mid(gvRecive, 24, 8) == estHeaderAltas.strHDFolInterno.Value)
                    {
                        gvRecive5566_01 = gvRecive;
                        resultOk = true;
                    }
                    else
                    {
                        Interaction.Beep();
                        if (gvRecive.Trim().Length == 0)
                        {
                            string tempRefParam7 = "Respuesta erronea de Tandem o se acabó el tiempo de espera. Por favor reintente.";
                            MessageBox.Show(tempRefParam7, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (gvRecive.IndexOf("CONTRATO A DAR DE ALTA YA EXISTE") >= 0)
                            {
                                gvRecive5566_01 = gvRecive;
                                resultOk = true;
                            }
                            else
                            {
                                string tempRefParam9 = Strings.Mid(gvRecive, 47, 50) + "\n" + "\r" + Strings.Mid(gvRecive, 223, 72).Trim();
                                MessageBox.Show(tempRefParam9, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        //resultOk = false;
                    }
                }

                else
                {
                    Interaction.Beep();
                    string tempRefParam11 = Strings.Mid(gvRecive, 1, 50);
                    MessageBox.Show(tempRefParam11, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultOk = false;
                }
            }
            if (resultOk)
            {
                result = "00";
            }
            else
            {
                result = gvRecive;
            }
            mdlSeguridad.EnviaLog("Mensaje Recibido de Comdrv:" + "\r\n" + gvRecive);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje Recibido de Comdrv:" + "\r\n" + gvRecive);
            slRespuesta = gvRecive;
            return result;
        }

        public string fncEnviaDialogoLocalSegundaSComdrv(ref  string spRespuesta, bool bpReAlta)
        {
            //Envia el diálogo S753

            string result = String.Empty;

            mdlParametros.igIndAltaCteOK = 1;
            gdlgDialogoS111 = new clsDialogo();
            gdlgDialogoS111.prGeneraDlg(gdteEjecutivo, clsDialogo.enuTipoDialogo.tAltaEjecutivosComdrv);
            Cursor.Current = Cursors.WaitCursor;
            string slDialogo = gdlgDialogoS111.DialogoS;
            string gvRecive = String.Empty;
            string gvRecive5566_01 = String.Empty;
            bool resultOk = false;

            mdlSeguridad.EnviaLog("Mensaje Envio de Comdrv:" + "\r\n" + slDialogo);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje a enviar a Comdrv:" + "\r\n" + slDialogo);
            gvRecive = funConComdrv(slDialogo);

            if (gvRecive.IndexOf("SEG;") >= 0 || gvRecive.IndexOf("SEG:") >= 0)
            {
                MessageBox.Show("Necesita firmarse para dar el alta");

                frmLoginS53 frmFirma = new frmLoginS53();
                frmFirma.ShowDialog();

                gvRecive = funConComdrv(slDialogo);

                int intIntentos = 1;

                while (Strings.Mid(gvRecive, 1, 4) != "5566" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {

                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {
                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }

                //////segunda parte verifica errores

                if (Strings.Mid(gvRecive, 1, 4) == "5566" && Strings.Mid(gvRecive, 6, 2) == "01")
                {
                    //Validar respuesta sea OK (0)
                    if (Strings.Mid(gvRecive, 45, 2) == "00")// && Strings.Mid(gvRecive, 24, 8) == estHeaderAltas.strHDFolInterno.Value)
                    {
                        gvRecive5566_01 = gvRecive;
                        resultOk = true;
                    }
                    else
                    {
                        Interaction.Beep();
                        if (gvRecive.Trim().Length == 0)
                        {
                            string tempRefParam7 = "Respuesta erronea de Tandem o se acabó el tiempo de espera. Por favor reintente.";
                            MessageBox.Show(tempRefParam7, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (gvRecive.IndexOf("CONTRATO A DAR DE ALTA YA EXISTE") >= 0)
                            {
                                gvRecive5566_01 = gvRecive;
                                resultOk = true;
                            }
                            else
                            {
                                string tempRefParam9 = Strings.Mid(gvRecive, 47, 50) + "\n" + "\r" + Strings.Mid(gvRecive, 223, 72).Trim();
                                MessageBox.Show(tempRefParam9, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        //resultOk = false;
                    }
                }
                else
                {
                    Interaction.Beep();
                    string tempRefParam11 = Strings.Mid(gvRecive, 1, 50);
                    MessageBox.Show(tempRefParam11, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultOk = false;
                }
            }
            else
            {
                int intIntentos = 1;
                while (Strings.Mid(gvRecive, 1, 4) != "5566" && (gvRecive.IndexOf("SEG;") + 1) < 1 && intIntentos < 2)
                {
                    if (gvRecive.ToUpper().IndexOf("REPITA TRANSACCION") >= 0)
                    {
                        gvRecive = funConComdrv(slDialogo);
                    }
                    string Recibe = gvRecive;
                    intIntentos++;
                }

                //////segunda parte verifica errores

                if (Strings.Mid(gvRecive, 1, 4) == "5566" && Strings.Mid(gvRecive, 6, 2) == "01")
                {
                    //Validar respuesta sea OK (0)
                    if (Strings.Mid(gvRecive, 45, 2) == "00")// && Strings.Mid(gvRecive, 24, 8) == estHeaderAltas.strHDFolInterno.Value)
                    {
                        gvRecive5566_01 = gvRecive;
                        resultOk = true;
                    }
                    else
                    {
                        Interaction.Beep();
                        if (gvRecive.Trim().Length == 0)
                        {
                            string tempRefParam7 = "Respuesta erronea de Tandem o se acabó el tiempo de espera. Por favor reintente.";
                            MessageBox.Show(tempRefParam7, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (gvRecive.IndexOf("CONTRATO A DAR DE ALTA YA EXISTE") >= 0)
                            {
                                gvRecive5566_01 = gvRecive;
                                resultOk = true;
                            }
                            else
                            {
                                string tempRefParam9 = Strings.Mid(gvRecive, 47, 50) + "\n" + "\r" + Strings.Mid(gvRecive, 223, 72).Trim();
                                MessageBox.Show(tempRefParam9, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        //resultOk = false;
                    }
                }

                else
                {
                    Interaction.Beep();
                    string tempRefParam11 = Strings.Mid(gvRecive, 1, 50);
                    MessageBox.Show(tempRefParam11, "S753 ARIES - CCyBE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultOk = false;
                }
            }


            if (resultOk)
            {
                result = "00";
            }
            else
            {

                result = gvRecive;
            }

            mdlSeguridad.EnviaLog("Mensaje Recibido de Comdrv:" + "\r\n" + gvRecive);
            FileSystem.PrintLine(CORVAR.FileNumber, "Mensaje Recibido de Comdrv:" + "\r\n" + gvRecive);
            slRespuesta = gvRecive;
            return result;

        }

        static private COMDRV32.TcpServer _objProxy = null;

        static public COMDRV32.TcpServer objProxy
        {
            get
            {
                if (_objProxy == null)
                {
                    _objProxy = new COMDRV32.TcpServer();
                }
                return _objProxy;
            }
            set
            {
                _objProxy = value;
            }
        }


        static public string funConComdrv(string strMensaje)
        {
            string strCadPaso = String.Empty;
            strCadPaso = "D" + strMensaje.Trim() + Strings.Chr(3).ToString(); ;
            objProxy.SendRequest(StringsHelper.StrConv4(strCadPaso, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)strCadPaso.Length);
            int intTM = 0;
            string s = String.Empty;
            bool bContinue = false;
            intTM = 0;
            s = "";
            bContinue = true;
            while (bContinue)
            {
                try
                {
                    innerFunCON(ref s, ref intTM, ref strMensaje, ref bContinue);
                }

                catch (Exception e)
                {
                    objProxy = null;
                    objProxy = new COMDRV32.TcpServer();
                    objProxy.Connect();
                    objProxy.SendRequest(StringsHelper.StrConv4(strCadPaso, StringsHelper.VbStrConvEnum.vbFromUnicode, 0), (short)strCadPaso.Length);
                    bContinue = true;
                }
            }
            if (s.IndexOf("SEG;") >= 0 || s.IndexOf("SEG:") >= 0)
            {
                return Strings.Mid(s, 11);
            }
            else
            {
                return Strings.Mid(funDepuraMensaje(ref s), 11);
            }
        }


        private static void innerFunCON(ref string s, ref int intTM, ref string strMensaje, ref bool bContinue)
        {

            s = s + StringsHelper.StrConv4(objProxy.ReceiveResponse(100000), StringsHelper.VbStrConvEnum.vbUnicode, 0) + Strings.Chr(3).ToString();

            if (s.Length > 13)
            {
                if (s.IndexOf("H10013CMDD") >= 0)
                { //Evitamos el mensaje para el ADMWIN
                    s = Strings.Mid(s, s.IndexOf("H10013CMDD") + 14);
                }
                //Checa si al reposicionarnos hay cadena válida
                if (Strings.Mid(s, 1, 2) == "H1" && Strings.Mid(s, 7, 4) == "CMDD")
                {
                    if (intTM == 0)
                    {
                        intTM = StringsHelper.IntValue(Strings.Mid(s, 3, 4)); //Toma la longitud de la cadena
                    }
                    if (s.Length >= intTM - 1)
                    {
                        //Para sincronizar el mensaje (se asegura de que sea el que pidió).
                        if (Strings.Mid(s, 11, 4) == "5447" || Strings.Mid(s, 11, 4) == "5448" || Strings.Mid(s, 11, 4) == "5449")
                        {
                            if (Strings.Mid(strMensaje, 1, 4) == Strings.Mid(s, 11, 4))
                            {
                                bContinue = false;
                            }
                        }
                        else
                        {
                            bContinue = false;
                        }
                    }
                }
            }

        }


        static public string funDepuraMensaje(ref  string vRecive)
        {
            //*****************************************************************************************************
            //* Propósito:  depura mensaje
            //* Entradas: vRecive-> mensaje recibido
            //****************************************************************************************************
            const byte gbFS = 28;
            const byte gbESC = 27;
            const byte gbHOME = 30;
            const byte gbCR = 10;
            const byte gbLF = 13;
            const byte gbEOT = 3;
            const byte gbNULO = 0;
            const byte gbTAB = 9;
            bool gbolEstaSeg = false;
            for (int intvIndice = 1; intvIndice <= vRecive.Length; intvIndice++)
            {

                if (Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbFS).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbEOT).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbLF).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbTAB).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbNULO).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbESC).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbHOME).ToString() || Strings.Mid(vRecive, intvIndice, 1) == Strings.Chr(gbCR).ToString())
                {
                    //Se tuvo que cambiar para evitar los primeros caracteres
                    //y sustituir los intermedio por espacios, en lugar de quitarlos.
                    if (intvIndice > 5)
                    {
                        vRecive = Strings.Mid(vRecive, 1, intvIndice - 1) + " " + Strings.Mid(vRecive, intvIndice + 1);
                    }
                    else
                    {
                        vRecive = Strings.Mid(vRecive, 1, intvIndice - 1) + Strings.Mid(vRecive, intvIndice + 1);
                        intvIndice--;
                    }
                }
            }
            if (vRecive.IndexOf("SEG:") >= 0)
            {
                gbolEstaSeg = true;
            }
            else if (vRecive.IndexOf("SEG;") >= 0)
            {
                gbolEstaSeg = false;
            }

            return vRecive;
        }
    }
}