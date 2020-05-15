using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.Globalization;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class frmCambiosMasivos
        : System.Windows.Forms.Form
    {
        private pryActualizaS111.ClsConectaS111 objConS111 = null;

        private void frmCambiosMasivos_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        int intFrmGrupo = 0;
        private clsCambiosMasivos objCambioMasivo = null;
        private const int PROCESA_ARCHIVO = 0;
        private const int PROCESA_EMPRESA = 1;
        //private pryActualizaS111.ClsConectaS111 ObjConexionS111_r = null;

        //'código para cambio de dirección
        private const int TIPO_ENVIO_EMPRESA = 0;
        private const int TIPO_ENVIO_INDIVIDUAL = 1;
        private const int ERROR_VERIFICAR_TIPO_ENVIO = -1;
        int indice;
        int intTipoEnvio;
        bool intExisteCuenta;
        bool intExisteCambio;
        bool intDatoInvalido;
        string strDatoInvalido;
        //'fin del código

        //'codigo agregado jacm 10/11/04
        //'bandera que indica donde se obtendran los datos de las cuentas:
        //'de la base de datos, con valor = 0
        //'de un archivo, con valor = 1
        int intMedioObtencionDatos;
        clsCuenta mctaCuenta;
        prySeguridadS041.clsAccion maccLimiteUso;

        private void BtnProceso_ClickEvent(Object eventSender)
        {
            int Index = Array.IndexOf(BtnProceso, eventSender);

            if (Index == 0)
            {
                if (CboEmpresas[1].SelectedIndex == -1)
                {
                    MdlCambioMasivo.MsgInfo("Grupo seleccionado invalido");
                    CboEmpresas[0].Focus();
                    return;
                }

                if (CboValorModificar.SelectedIndex == -1)
                {
                    MdlCambioMasivo.MsgInfo("Debe elegir un cambio a procesar");
                    CboValorModificar.Focus();
                    return;
                }

                if (CboEmpresas[0].SelectedIndex == -1)
                {
                    MdlCambioMasivo.MsgInfo("Empresa seleccionada invalida");
                    CboEmpresas[0].Focus();
                    return;
                }


                BtnProceso[Index].Enabled = false;

                if (OptTipoCambio[0].Checked)
                {
                    //Procesa el alta por empresa

                    if (MdlCambioMasivo.FnMsgYesno("Los cambios selecionados aplicarán" + "\r\n" +
                                          "a la empresa seleccionada como a TODOS los ejecutivos exitentes" +
                                                   "\r" + "\r" + "¿ Desea Aplicar dichos Cambios ? "))
                    {


                        FnEfectuarCambioMasivo(PROCESA_EMPRESA.ToString());

                    }
                    else
                    {
                        string tempRefParam = "Tarjeta Ejecutiva.- Cambios  Masivos";
                        MdlCambioMasivo.MsgInfo("Proceso Cancelado", ref tempRefParam);
                    }

                }
                else if (OptTipoCambio[1].Checked)
                {
                    //Procesa el alta por archivo

                    if (MdlCambioMasivo.FnMsgYesno("Se procesarán los cambios masivos para la empresa seleccionada" + "\r" +
                                          "Y a las cuentas exitentes en un archivo seleccionado" + "\r" +
                                                   "\r" + "¿Desea Continuar ? "))
                    {
                        FnEfectuarCambioMasivo(PROCESA_ARCHIVO.ToString());
                    }
                    else
                    {
                        string tempRefParam2 = "Tarjeta Ejecutiva.- Cambios  Masivos";
                        MdlCambioMasivo.MsgInfo("Proceso Cancelado", ref tempRefParam2);
                    }
                }
                BtnProceso[Index].Enabled = true;
            }
            else
            {
                objCambioMasivo = null;
                this.Close();
            }
        }


        private void CboEmpresas_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(CboEmpresas, eventSender);
            if (CboEmpresas[Index].SelectedIndex > -1)
            {
                switch (Index)
                {
                    case 0:  //Da un click en la empresa 
                        objCambioMasivo.NoEmpresa = VB6.GetItemData(CboEmpresas[Index], CboEmpresas[Index].SelectedIndex);

                        break;
                    case 1:  //Da un click en el grupo de la empresa 
                        intFrmGrupo = VB6.GetItemData(CboEmpresas[Index], CboEmpresas[Index].SelectedIndex);
                        ActualizarComboEmpresas();
                        break;
                }
            }
        }

        private void CboValorModificar_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            clsDialogo.enuTipoDialogo Item = (clsDialogo.enuTipoDialogo)0;

            if (CboValorModificar.SelectedIndex > -1)
            {
                ChkValorAplicar.Visible = false;
                FrmTipoBloqueo.Visible = false;
                LblPorcentaje.Visible = false;
                MskPorcentaje1.Visible = false;
                Item = objCambioMasivo.get_IdTransaccion(CboValorModificar.SelectedIndex);
                objCambioMasivo.indice = CboValorModificar.SelectedIndex;
                if (Item == clsDialogo.enuTipoDialogo.tCambioCreditoEjeS111)
                {
                  LblPorcentaje.Text = "Límite de Uso:";
                  LblPorcentaje.Visible = true;
                  MskPorcentaje1.Visible = true;
                  MskPorcentaje1.MaxLength = Convert.ToString(MdlCambioMasivo.MAX_LIM_USO).Length;
                  MskPorcentaje1.Mask = "######";
                  MskPorcentaje1.Text = "   100";
                  MskPorcentaje1.SelectionStart = 0;
                  MskPorcentaje1.SelectionLength = MskPorcentaje1.MaxLength;
              
                  objCambioMasivo.ValorModificar = 0;
                }
                else if (Item == clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111)
                {
                    LblPorcentaje.Text = "Porcentaje de Disposición:";
                    LblPorcentaje.Visible = true;
                    MskPorcentaje1.Visible = true;
                    MskPorcentaje1.Mask = "###";
                    MskPorcentaje1.MaxLength = 3;
                    MskPorcentaje1.Text = "0";
                    MskPorcentaje1.SelectionStart = 0;
                    MskPorcentaje1.SelectionLength = MskPorcentaje1.MaxLength;

                    objCambioMasivo.ValorModificar = 0;
                }
                else if (Item == clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111)
                {
                    FrmTipoBloqueo.Visible = true;
                    if (clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111 == objCambioMasivo.get_IdTransaccion(CboValorModificar.SelectedIndex))
                    {
                        FrmTipoBloqueo.Text = "Generación de Pin y Plastico";

                        OptTipoBloqueo[0].Text = "Manejar Pin y Plastico";
                        OptTipoBloqueo[0].Tag = ((int)CRSParametros.GeneracionPlastico.cteSiPlasticoSiPIN).ToString();

                        OptTipoBloqueo[1].Text = "Sin Pin ni plastico";
                        OptTipoBloqueo[1].Tag = ((int)CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN).ToString();

                        OptTipoBloqueo[2].Text = "Solo Plastico";
                        OptTipoBloqueo[2].Tag = ((int)CRSParametros.GeneracionPlastico.cteSiPlasticoNoPIN).ToString();
                    }
                    //else
                    //{
                    //    FrmTipoBloqueo.Text = "Tipo de Bloqueo";
                    //    OptTipoBloqueo[0].Text = "No maneja Bloqueo";
                    //    OptTipoBloqueo[0].Tag = "0";
                    //    OptTipoBloqueo[1].Text = "Bloqueo por MCC";
                    //    OptTipoBloqueo[1].Tag = "1";
                    //    OptTipoBloqueo[2].Text = "Bloqueo por No. negocio";
                    //    OptTipoBloqueo[2].Tag = "2";

                    //}
                    //Actualiza los valores por defecto
                    OptTipoBloqueo[0].Checked = true;
                    OptTipoBloqueo_CheckedChanged(OptTipoBloqueo[0], new EventArgs());
                }
                //else if (Item == clsDialogo.enuTipoDialogo.tCambioSkipEjecutivoS111)
                //{
                //    ChkValorAplicar.Visible = true;
                //    ChkValorAplicar.Text = "Skip Payment";
                //    //Actualiza los valores por defecto
                //    ChkValorAplicar.CheckState = CheckState.Unchecked;
                //    ChkValorAplicar_CheckStateChanged(ChkValorAplicar, new EventArgs());

                //}
                else if (Item == clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111)
                {
                    LblPorcentaje.Visible = true;
                    LblPorcentaje.Text = "Tabla MCC / Negocio";
                    MskPorcentaje1.Visible = true;
                    MskPorcentaje1.Mask = "####";
                    MskPorcentaje1.MaxLength = 4;
                    MskPorcentaje1.Mask = "0000";
                    MskPorcentaje1.Text = "0000";
                    objCambioMasivo.ValorModificar = 0;
                    //Actualiza el valor por defecto de la propiedad
                    //seleccionada
                }

                if (Item == clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111)
                {
                    OptTipoCambio[0].Checked = false;
                    OptTipoCambio[1].Checked = true;
                }
            }
        }

        private void ChkValorAplicar_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            objCambioMasivo.ValorModificar = (int)ChkValorAplicar.CheckState;
        }

        //UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code
        //private void  Command1_Click()
        //{
        //FrmTuxedo.DefInstance.Show();
        //}

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            objCambioMasivo = new clsCambiosMasivos();

            CboValorModificar.Items.Clear();
            for (int intElementos = 0; intElementos <= objCambioMasivo.fnCount(); intElementos++)
            {
                CboValorModificar.Items.Add(objCambioMasivo.get_Descripcion(intElementos));
            }
            //OptTipoCambio(0).Value = True 'El valor por defecto es por empresa
            ActualizarComboGrupo();
            OptTipoCambio_CheckedChanged(OptTipoCambio[0], new EventArgs());
            //this.Height = (int)VB6.TwipsToPixelsY(5790);
            //this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            //this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

        }

        private bool isInitializingComponent;
        private void frmCambiosMasivos_Resize(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            //No permite que la pantalla sea redimensionada
            try
            {
                //Execpto cuando la forma se minimiza
                this.Height = (int)VB6.TwipsToPixelsY(6240);
                this.Width = (int)VB6.TwipsToPixelsX(6450);
                PanToolBar.Width = (int)this.Width;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }


        }

        private void MskPorcentaje_Enter(Object eventSender, EventArgs eventArgs)
        {
            //MskPorcentaje.SelStart = 0;
            //MskPorcentaje.SelLength = Strings.Len(MskPorcentaje.CtlText);
        }

        private void MskPorcentaje_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int result = 0;
            objCambioMasivo.ValorModificar = Int32.TryParse(StringsHelper.Format(MskPorcentaje1.Text, ""), out result) == false ? 0 : result;
            if (~objCambioMasivo.ValorValido() != 0)
            {
                MdlCambioMasivo.MsgInfo("El valor suministrado es invalido");
                Cancel = true;
            }
            eventArgs.Cancel = Cancel;
        }

        private void OptTipoBloqueo_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (((RadioButton)eventSender).Checked)
            {
                int Index = Array.IndexOf(OptTipoBloqueo, eventSender);
                objCambioMasivo.ValorModificar = Int32.Parse(OptTipoBloqueo[Index].Tag.ToString());
                //Envia el valor del tag actual
            }
        }

        private void OptTipoCambio_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (((RadioButton)eventSender).Checked)
            {
            
                //Habilita el control del listado de la empresa
                CboEmpresas[0].Enabled = true;
                CboEmpresas[1].Enabled = true;
                //Refresca el contenido del listado de empresas as procesar
                if (CboEmpresas[1].Items.Count > 0)
                {
                    CboEmpresas[1].SelectedIndex = 0;
                }
                LblPorcentaje.Visible = false;
                MskPorcentaje1.Visible = false;
            }
        }

        private void ActualizarComboGrupo()
        {
            ADODB.Recordset rsGrupos = null;
            string strSql = String.Empty;

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
                    rsGrupos = new ADODB.Recordset();
                    rsGrupos.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                    CboEmpresas[1].Items.Clear();
                    while (!rsGrupos.EOF)
                    {
                        CboEmpresas[1].Items.Add(new ListBoxItem(Convert.ToString(rsGrupos.Fields["gpo_num"].Value) + new String(' ', 5) + Convert.ToString(rsGrupos.Fields["gpo_nom"].Value), Convert.ToInt32(rsGrupos.Fields["gpo_num"].Value)));
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
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    if (rsGrupos.State != 0)
                    {
                        rsGrupos.Close();
                    }
                    rsGrupos = null;
                }

                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }
            }
        }
        private void ActualizarComboEmpresas()
        {
            ADODB.Recordset rsEmpresas = null;
            try
            {
                string strSql = String.Empty;

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
                    strSql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + intFrmGrupo.ToString();
                    strSql = strSql + " Order by emp_num";

                    rsEmpresas = new ADODB.Recordset();
                    rsEmpresas.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, -1);
                    CboEmpresas[0].Items.Clear();
                    while (!rsEmpresas.EOF)
                    {

                        CboEmpresas[0].Items.Add(new ListBoxItem(StringsHelper.Format(rsEmpresas.Fields["emp_num"].Value, "000") + new String(' ', 10) + Convert.ToString(rsEmpresas.Fields["emp_nom"].Value), Convert.ToInt32(rsEmpresas.Fields["emp_num"].Value)));
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

        private bool FnEfectuarCambioMasivo(string intTipoProceso)
        {
            string strSql = String.Empty;
            ADODB.Recordset RsEmpresa = null; //Fuente de datos que se utilizará cuando la actualizacion se haga para toda la empresa y sus objetivos
            int lnRegistrosProcesar = 0;
            int lngRegistrosOK = 0;
            int lngRegistroFallidos = 0;
            int intFreeFile = 0; //Handler del archivo del reporte actual
            int intEjenum = 0; //No Ejecutivo actual
            int intRollOver = 0; //RollOver
            int intDigitoVer = 0; //Digito Verificador
            int intFreeFileCM = 0; //Handler para el archivo fuente de datos de los cambios masivos
            string strLineaArchivo = String.Empty; //Contenido del archivo fuente
            bool bolLineaValido = false; //Resultado de la validacion si la linea actual  del archivo es valida
            string strNombreArchivo = String.Empty; //Nombre del archivo a procesar
            string strNombreArchivoLog = String.Empty;

            int intValorEnviarEjecutivo = 0;
            int lngContador = 0;
            FrmRptCambioMasivo FrmError = null;
            //pryActualizaS111.ClsConectaS111 objConS111 = null;

            objConS111 = new pryActualizaS111.ClsConectaS111();
            string strMsg = String.Empty; //Mensaje recibido desde el dialogo cuando se provoque un error
            int ilLongValorMax = 0;

            //'cod. para cambio dirección
            int intLongValorMaximo = 0;
            int intTipoEnvio;
            int lnPosDato;
            int lnLongRegistro;
            string strDato;
            int intIdTransaccion;
            int ilOpSuccesful = 0;

            //Abre el archivo de los logs
            this.Cursor = Cursors.WaitCursor;

            ilLongValorMax = Conversion.Str(MdlCambioMasivo.MAX_LIM_USO).Length;
            strNombreArchivoLog = "ErrCambioMasivo.txt";
            intFreeFile = intFnAbrirArchivo(ref strNombreArchivoLog);
            if (intFreeFile == -1)
            {
                //El archivo de los logs no pudo ser abierto
                //se cancela el proceso
                MdlCambioMasivo.MsgInfo("El Archivo de logs :" + "\r" +
                                        strNombreArchivo + "\r" +
                                        "No pudo ser abierto se cancela el proceso");
                this.Cursor = Cursors.Default;
                return false;
            }

            //Muestra el Dialogo para firmarse en el S111
            objConS111 = new pryActualizaS111.ClsConectaS111();
            //AIS-1146 NGONZALEZ
            objConS111.set_Usuario(ref CRSParametros.sgUserID);
            switch (objCambioMasivo.get_DlgTransaccion(objCambioMasivo.indice))
            {
                case MdlCambioMasivo.TRANS_LIM_USO:
                    maccLimiteUso = new prySeguridadS041.clsAccion();
                    maccLimiteUso.UsuarioUSU = Seguridad.usugUsuario;
                    maccLimiteUso.DescripcionS = "Cambio de Límite de Uso";
                    maccLimiteUso.HabilitarB = true;
                    maccLimiteUso.idAccionI = 3;
                    maccLimiteUso.MakerCheckerE = prySeguridadS041.mchTiposMakerChecker.tmcMancomunado;
                    //'.ModuloS = "Ejecutivo" 'Descomentar en Producción
                    maccLimiteUso.OperacionI = 1;
                    break;
                default:
                    //Muestra el Dialogo para firmarse en el S111
                    //objConS111 = new pryActualizaS111.ClsConectaS111();
                    //AIS-1146 NGONZALEZ
                    //objConS111.set_Usuario(ref CRSParametros.sgUserID);

                    if (Double.Parse(intTipoProceso) == PROCESA_EMPRESA)
                    {

                        frmLoginS53 frmFirma = new frmLoginS53();
                        var regreso = frmFirma.ShowDialog();

                        if (regreso.ToString() != "OK")
                        {
                            FileSystem.FileClose(intFreeFile);
                            this.Cursor = Cursors.Default;
                            return false;
                        }
                        //Set dlgCambioMasivo = New clsDialogo 'Inicializa la clase para generar el dialogo
                        //Determina
                        //******** Presenta los paneles del estado del proceso   ************
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight;
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short)CORVB.NULL_INTEGER;
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK);
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambios Masivos";
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;
                        FileSystem.PrintLine(intFreeFile, "Proceso Iniciado: " + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                        Application.DoEvents();
                    }
                    break;
            }

            if (Double.Parse(intTipoProceso) == PROCESA_EMPRESA)
            {
                //Procesará el cambio masivo hacia el total de la empresa
                //Determinando los ejecutivos que forman parte de la empresa
                //Cruzando la tabla de MTCEJE01 vs MTCTHS01 ya que está ultima es la que contiene la replica de los datos
                //desde el S111

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
                    strSql = " Select A.eje_prefijo  as ejeprefijo,A.gpo_banco as gpobanco,A.emp_num as empnum, A.eje_num as ejenum,";
                    strSql = strSql + " Case when B.eje_roll_over is null then A.eje_roll_over else B.eje_roll_over end as rollover,";
                    strSql = strSql + " Case  when B.eje_digit is null then A.eje_digit  else B.eje_digit  end as digitover,";
                    strSql = strSql + " eje_limcred as eje_limcred";
                    strSql = strSql + " From MTCEJE01 A LEFT JOIN  MTCTHS01 B";
                    strSql = strSql + " ON  A.emp_num =B.emp_num and A.eje_prefijo = B.eje_prefijo And A.gpo_banco=B.gpo_banco and A.eje_num=B.eje_num";
                    strSql = strSql + " Where A.emp_num= " + objCambioMasivo.NoEmpresa.ToString();
                    strSql = strSql + " And A.eje_prefijo = " + CORVAR.igblPref.ToString();
                    strSql = strSql + " And A.gpo_banco = " + CORVAR.igblBanco.ToString();


                    RsEmpresa = new ADODB.Recordset();

                    lngRegistrosOK = 0;
                    RsEmpresa.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
                    RsEmpresa.CursorType = ADODB.CursorTypeEnum.adOpenKeyset;
                    RsEmpresa.LockType = ADODB.LockTypeEnum.adLockReadOnly;
                    RsEmpresa.Open(strSql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);

                    if (!RsEmpresa.EOF)
                    {
                        lnRegistrosProcesar = RsEmpresa.RecordCount;
                        intValorEnviarEjecutivo = objCambioMasivo.ValorModificar;
                        lngContador = 0;
                        mctaCuenta = new clsCuenta();
                        mctaCuenta.productoPRD = mdlParametros.gprdProducto;
                        do
                        {
                            lngContador++;
                            intEjenum = Convert.ToInt32(RsEmpresa.Fields["Ejenum"].Value);
                            intRollOver = Convert.ToInt32(RsEmpresa.Fields["rollover"].Value);
                            intDigitoVer = Convert.ToInt32(RsEmpresa.Fields["digitover"].Value);

                            switch (objCambioMasivo.get_DlgTransaccion(objCambioMasivo.indice))
                            {
                                case MdlCambioMasivo.TRANS_LIM_USO:
                                    //Determina si la cuenta está mapeada
                                    mctaCuenta.CuentaS = StringsHelper.Format(CORVAR.igblPref, "0000") +
                                                         StringsHelper.Format(CORVAR.igblBanco, "00") +
                                                         StringsHelper.Format(objCambioMasivo.NoEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) +
                                                         StringsHelper.Format(intEjenum, Formato.sMascara(Formato.iTipo.Ejecutivo)) +
                                                         StringsHelper.Format(intRollOver, "0") +
                                                         StringsHelper.Format(intDigitoVer, "0");
                                    mctaCuenta.LimiteCredC = Decimal.Parse(Conversion.Str(RsEmpresa.Fields["eje_limcred"].Value), NumberStyles.Currency);
                                    //'Agregar validación para que la cuenta identifique cuando se trate de una cuenta corporativa y cuando de una ejecutiva
                                    if (mctaCuenta.TipoCuentaE == clsCuenta.ctaTiposCuenta.ctaEjecutiva)
                                    {
                                        ilOpSuccesful = 0;
                                        ilOpSuccesful = mctaCuenta.ActualizaLimiteCredI(maccLimiteUso, Decimal.Parse(Conversion.Str(objCambioMasivo.ValorModificar),NumberStyles.Currency), prySeguridadS041.topTipoOperMakerChecker.topMaker);
                                    }
                                    else
                                    {
                                        lngContador = lngContador - 1;
                                        lnRegistrosProcesar = lnRegistrosProcesar - 1;
                                    }
                                    if (ilOpSuccesful == 0)
                                    {
                                        if (intEjenum > 0)
                                        {
                                            lngRegistroFallidos = lngRegistroFallidos + 1;
                                            FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), mdlParametros.tgCambioS111.NumCuentaS, FileSystem.TAB(45), "La tabla MTCEMP01  no pudo ser actualizada", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                        }
                                    }
                                    else
                                    { lngRegistrosOK = lngRegistrosOK + ilOpSuccesful; }
                                    break;
                                default:
                                    //Determina si la cuenta está mapeada
                                    objCambioMasivo.NoCuentaBanco = StringsHelper.Format(CORVAR.igblPref, "0000") +
                                                                    StringsHelper.Format(CORVAR.igblBanco, "00") +
                                                                    StringsHelper.Format(objCambioMasivo.NoEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) +
                                                                    StringsHelper.Format(intEjenum, Formato.sMascara(Formato.iTipo.Ejecutivo)) +
                                                                    StringsHelper.Format(intRollOver, "0") +
                                                                    StringsHelper.Format(intDigitoVer, "0");
                                    if (intEjenum == 0)
                                    {
                                        //Determina el valor a enviar como cambio masivo cuando se trata de
                                        //una empresa
                                        switch (objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice))
                                        {
                                            //case clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111:
                                            //    objCambioMasivo.ValorModificar = 1;
                                            //    //Indica que para la empresa no aplica pin ni plastico 
                                            //    break;
                                            case clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111:
                                                objCambioMasivo.ValorModificar = 0;  //El porcentaje de disposicion no aplica a la empresa 
                                                break;
                                            //case clsDialogo.enuTipoDialogo.tCambioTipoBloqueoEjecutivoS111:
                                            //    objCambioMasivo.ValorModificar = 0;  //La empresa no maneja tipo de bloqueo 
                                            //    break;
                                            case clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111:
                                                objCambioMasivo.ValorModificar = 0;  //La empresa no maneja MCC 
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        if (objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice) == clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111 || objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice) == clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111)
                                        {
                                            objCambioMasivo.ValorModificar = intValorEnviarEjecutivo; //Aplica el valor seleccionado en la forma
                                        }
                                    }
                                    N_ActualizaS111.ClsConectaS111 ObjConexionS111 = new N_ActualizaS111.ClsConectaS111();
                                    //dlgCambioMasivo.prGeneraDlg objCambioMasivo, objCambioMasivo.IdTransaccion(objCambioMasivo.Indice)
                                    //if (!blCancelada(objConS111, mdlParametros.tgCambioS111.NumCuentaS))    //' se agrega la validación de cta. cancelada - jacm
                                    //{
                                        if (objCambioMasivo.fnEnviarDialogo(strMsg, ObjConexionS111))
                                        {
                                            //Actualiza la tabla de ejecutivos
                                            if (FnActualizaEjecutivo(CORVAR.igblPref, intEjenum, CORVAR.igblBanco))
                                            {
                                                if (intEjenum == 0)
                                                {
                                                    //El ejecutivo que se está actualizando es una empresa por
                                                    //lo tanto se debe actualizar la tabla de empresas.
                                                    if (FnActualizaEmpresa())
                                                    { lngRegistrosOK++; }
                                                    else
                                                    {
                                                        lngRegistroFallidos++;
                                                        FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), mdlParametros.tgCambioS111.NumCuentaS, FileSystem.TAB(45), "La tabla MTCEMP01  no pudo ser actualizada", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                                    }
                                                }
                                                else
                                                { lngRegistrosOK++; }
                                            }
                                            else
                                            {
                                                FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), mdlParametros.tgCambioS111.NumCuentaS, FileSystem.TAB(45), "La tabla MTCEJE01 No pudo ser actualizada", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                                lngRegistroFallidos++;
                                            }

                                        }
                                        else
                                        {
                                            //Actualiza el log

                                            bool tempRefParam = true;
                                            strMsg = Strings.Replace(objConS111.get_MsgError(ref tempRefParam), "\r" + "\n", ".", 1, -1, CompareMethod.Binary);
                                            strMsg = Strings.Replace(strMsg, "..", ".", 1, -1, CompareMethod.Binary);
                                            strMsg = Strings.Replace(strMsg, Strings.Chr(3).ToString(), "", 1, -1, CompareMethod.Binary);
                                            strMsg = Strings.Replace(strMsg, "\r", "", 1, -1, CompareMethod.Binary);
                                            strMsg = Strings.Replace(strMsg, new String(' ', 2), "", 1, -1, CompareMethod.Binary);
                                            FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), mdlParametros.tgCambioS111.NumCuentaS, FileSystem.TAB(45), strMsg + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"));
                                            lngRegistroFallidos++;
                                        }
                                    //}
                                    //else
                                    //{
                                    //    bool tempRefParam1 = true;
                                    //    strMsg = Strings.Replace(objConS111.GetMsgerror(ref tempRefParam1), "\r", ".", 1, -1, CompareMethod.Binary); //'Quita los saltos de linea si es que existen
                                    //    if (strMsg.IndexOf("CANCEL", 1) > 0)
                                    //    { strMsg = " Cuenta Cancelada "; }
                                    //    strMsg = Strings.Replace(strMsg, "\n", "", 1, -1, CompareMethod.Binary); //'Quita los saltos de linea si es que existen
                                    //    strMsg = Strings.Replace(strMsg, "..", ".", 1, -1, CompareMethod.Binary);
                                    //    FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), mdlParametros.tgCambioS111.NumCuentaS, FileSystem.TAB(45), strMsg + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"));
                                    //    lngRegistroFallidos = lngRegistroFallidos + 1;
                                    //}
                                    break;
                            }
                            RsEmpresa.MoveNext();
                            try
                            {
                                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = Convert.ToInt16(100 * (lngRegistroFallidos + lngRegistrosOK) / ((double)lnRegistrosProcesar));
                            }
                            catch (Exception er1) { }
                            try
                            {
                                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Procesando Registro No: " + StringsHelper.Format(lngContador, "###,##0");
                            }
                            catch (Exception er2) { }
                            try
                            {
                                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Refresh();
                            }
                            catch (Exception er3) { }

                            Information.Err().Clear();
                        } while (!RsEmpresa.EOF);
                        RsEmpresa.Close();
                    } //Verifica la existencia de datos en la consulta
                    VBSQL.gConn[10].Close();
                }
            }
            else
            {
                //Procesará el cambio masivo hacia las cuentas de la empresa suministradas en un archivo
                CmdAbrirArchivo.Title = "Cambios Masivos (Archivo Fuente)";
                CmdAbrirArchivo.DefaultExt = "*.xmt";
                CmdAbrirArchivo.Filter = "*.xmt |xmt";
                CmdAbrirArchivo.FilterIndex = 0;
                CmdAbrirArchivo.FileName = "*.xmt";
                CmdAbrirArchivo.ShowDialog();
                strNombreArchivo = CmdAbrirArchivo.FileName;
                intFreeFileCM = FileSystem.FreeFile();
                this.Cursor = Cursors.WaitCursor;
                if (strNombreArchivo != "*.xmt" && strNombreArchivo != "")
                {
                    FileSystem.FileOpen(intFreeFileCM, strNombreArchivo, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
                    if (!FileSystem.EOF(intFreeFileCM))
                    {
                        if (objCambioMasivo.get_DlgTransaccion(objCambioMasivo.indice) != MdlCambioMasivo.TRANS_LIM_USO)
                        {
                            //###########################################################
                            frmLoginS53 frmFirma = new frmLoginS53();
                            var regreso = frmFirma.ShowDialog();

                            if (regreso != DialogResult.OK)
                            {
                                //if (!objConS111.FnPreguntaPwd())
                                //{
                                //Carga el comdrive
                                //Presentará la pantalla donde el usuario por seguridad vuelva a capturar el usuario y password
                                FileSystem.FileClose(intFreeFile);
                                FileSystem.FileClose(intFreeFileCM);
                                this.Cursor = Cursors.Default;
                                return false;
                            }
                        }

                        //'Determina
                        //'******** Presenta los paneles del estado del proceso   ************
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight;
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short)CORVB.NULL_INTEGER;
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK);
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambios Masivos";
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;
                        FileSystem.PrintLine(intFreeFile, "Proceso Iniciado: " + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                        Application.DoEvents();

                        intIdTransaccion = (int) objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice);
                        intTipoEnvio = fnEsTipoEnvioIndividual();
                        
                        if (intIdTransaccion == Convert.ToInt32(clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111))
                        {
                            lnRegistrosProcesar = 0;
                            while (!FileSystem.EOF(intFreeFileCM))
                            {
                                FileSystem.Input(intFreeFileCM, ref strLineaArchivo);
                                lnRegistrosProcesar = lnRegistrosProcesar + 1;
                            }
                            FileSystem.FileClose (intFreeFileCM);
                            intFreeFileCM = FileSystem.FreeFile();
                            FileSystem.FileOpen(intFreeFileCM, strNombreArchivo, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
                            if (FileSystem.EOF(intFreeFileCM))
                            {
                                FileSystem.FileClose(intFreeFile);
                                MdlCambioMasivo.MsgInfo("No pudo habrirse el archivo");
                                return false;
                            }
                        }   
                        else
                        {
                            intLongValorMaximo = objCambioMasivo.ValorMaximo.ToString().Length;
                            lnRegistrosProcesar = Convert.ToInt32(((int)FileSystem.LOF(intFreeFileCM)) / ((double)((9 + Formato.igLongitudEmpresa + Formato.igLongitudEjecutivo + objCambioMasivo.ValorMaximo.ToString().Length) + 2)));
                        }

                        //El tamaño en bytes del archivo entre la longitud permitida de cada registro
                        lngContador = 0;
                        do
                        {
                            lngContador++;
                            FileSystem.Input(intFreeFileCM, ref strLineaArchivo);
                            strLineaArchivo = strLineaArchivo.Trim(); //Elimina espacios en blanco innecesarios

                            if (objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice) == clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111)
                            {
                                intLongValorMaximo = Strings.Mid(strLineaArchivo, 18).Length;
                            }

                            if (strLineaArchivo.Length != (9 + Formato.igLongitudEmpresa + Formato.igLongitudEjecutivo + intLongValorMaximo))
                            {
                                //Verifica el contenido de la linea actual
                                //AIS-1121 NGONZALEZ
                                FileSystem.PrintLine(intFreeFile, new object[] { StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "El formato del archivo no es valido.", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss") });
                                //Print #intFreeFile, Format(lngContador, "######"); Tab(15); Mid(strLineaArchivo, 1, 16); Tab(45); "El formato del archivo no es valido."; ; Tab(100); Format(Date, "yyyy-mm-dd"); Space(1); Format(Time, "hh:mm:ss")
                                lngRegistroFallidos++;
                            }
                            else
                            {
                                //Verifica que la cuenta suministrada corresponda a la empresa solicitada
                                if (Convert.ToDouble(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 7 + Formato.igLongitudEmpresa, Formato.igLongitudEjecutivo), 0)) >= 0 && Convert.ToDouble(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 7 + Formato.igLongitudEmpresa, Formato.igLongitudEjecutivo), 0)) < 99999)
                                {
                                    intEjenum = Convert.ToInt32(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 7 + Formato.igLongitudEmpresa, Formato.igLongitudEjecutivo), 0));
                                }
                                else
                                {
                                    //AIS-1121 NGONZALEZ
                                    FileSystem.PrintLine(intFreeFile, new object[] { StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "Numero de ejecutivo invalido", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss") });
                                }

                                intRollOver = Convert.ToInt32(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 15, 1), 0));
                                //UPGRADE_WARNING: (1068) Nvl() of type Variant is being forced to int.
                                intDigitoVer = Convert.ToInt32(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 16, 1), 0));
                                //UPGRADE_WARNING: (1068) Nvl(Mid(strLineaArchivo, 7 + igLongitudEmpresa, igLongitudEjecutivo), 0) of type Variant is being forced to double.
                                //UPGRADE_WARNING: (1068) Nvl(Mid(strLineaArchivo, 7 + igLongitudEmpresa, igLongitudEjecutivo), 0) of type Variant is being forced to int.
                                //UPGRADE_WARNING: (1068) Nvl(Mid(strLineaArchivo, 5, 2), 0) of type Variant is being forced to double.
                                //UPGRADE_WARNING: (1068) Nvl(Mid(strLineaArchivo, 1, 4), 0) of type Variant is being forced to double.
                                //UPGRADE_WARNING: (1068) Nvl(Mid(strLineaArchivo, 7, igLongitudEmpresa), 0) of type Variant is being forced to double.
                                if (objCambioMasivo.NoEmpresa != Convert.ToDouble(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 7, Formato.igLongitudEmpresa), 0)) || CORVAR.igblPref != Convert.ToDouble(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 1, 4), 0)) || CORVAR.igblBanco != Convert.ToDouble(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 5, 2), 0)) || (Convert.ToInt32(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 7 + Formato.igLongitudEmpresa, Formato.igLongitudEjecutivo), 0)) < 0 && Convert.ToDouble(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 7 + Formato.igLongitudEmpresa, Formato.igLongitudEjecutivo), 0)) > 32767))
                                {
                                    //AIS-1121 NGONZALEZ
                                    FileSystem.PrintLine(intFreeFile, new object[] { StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "No. Cuenta Invalida", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss") });
                                    lngRegistroFallidos++;
                                }
                                //' código para el cambio de dirección de la dirección
                                else
                                {
                                    if ((intIdTransaccion == (int) clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111) && (intTipoEnvio != TIPO_ENVIO_INDIVIDUAL))
                                 {
                                   if (intTipoEnvio == TIPO_ENVIO_EMPRESA)
                                   {  
                                       FileSystem.PrintLine(intFreeFile, new object[] { StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "La empresa no tiene el tipo de envío Individual", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss") });
                                   } 
                                   else 
                                   {
                                     if (intTipoEnvio == ERROR_VERIFICAR_TIPO_ENVIO)
                                     {
                                       FileSystem.PrintLine(intFreeFile, new object[] { StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "No pudo verificarse el tipo de envío", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss") });
                                     }
                                   }
                                   lngRegistroFallidos = lngRegistroFallidos + 1;
                                 }
                                //' fin del código
                                 else
                                    if (Strings.Mid(strLineaArchivo, 17, 1) != objCambioMasivo.get_DlgTransaccion(objCambioMasivo.indice))
                                    {
                                        //Verifica que el archivo contenga el identificador unico para determinar si ela archivo corresponde al dialogo correcto
                                        FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "Identificador de transacción: " + MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 17, 1), "") + "Invalido", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                        lngRegistroFallidos++;
                                    }
                                    else
                                    {
                                        //Solicita se realice la transación al s111 por que la linea del archivo ha sido validada
                                        //Determina si la cuenta actual está mapeada
                                        objCambioMasivo.NoCuentaBanco = StringsHelper.Format(CORVAR.igblPref, "0000") +
                                                                        StringsHelper.Format(CORVAR.igblBanco, "00") +
                                                                        StringsHelper.Format(objCambioMasivo.NoEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) +
                                                                        StringsHelper.Format(intEjenum, Formato.sMascara(Formato.iTipo.Ejecutivo)) +
                                                                        StringsHelper.Format(intRollOver, "0") +
                                                                        StringsHelper.Format(intDigitoVer, "0");
                                        //'cambio de direccion
                                        if (intIdTransaccion != (int) clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111)
                                        {
                                            if (intEjenum != 0)
                                            {
                                                //Aplicará el cambio masivo segun el archivo suministrado
                                                //para los ejecutivos excepto para la empresa
                                                objCambioMasivo.ValorModificar = Convert.ToInt32(MdlCambioMasivo.Nvl(Strings.Mid(strLineaArchivo, 18, objCambioMasivo.ValorMaximo.ToString().Length), 0));
                                                //Determina el valor que se envia al dialogo
                                            }
                                            else
                                            {
                                                switch (objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice))
                                                {
                                                    //case clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111:
                                                    //    objCambioMasivo.ValorModificar = 1;
                                                    //    //Indica que para la empresa no aplica pin ni plastico 
                                                    //    break;
                                                    case clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111:
                                                    {
                                                        objCambioMasivo.ValorModificar = 0;  //El porcentaje de disposicion no aplica a la empresa 
                                                        break;
                                                    }
                                                    //case clsDialogo.enuTipoDialogo.tCambioTipoBloqueoEjecutivoS111:
                                                    //    objCambioMasivo.ValorModificar = 0;  //La empresa no maneja tipo de bloqueo 
                                                    //    break;
                                                    case clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111:
                                                    {
                                                        objCambioMasivo.ValorModificar = 0;  //La empresa no maneja MCC 
                                                        break;
                                                    }
                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (intEjenum != 0)
                                            {
                                                lnPosDato = 18;
                                                lnLongRegistro = strLineaArchivo.Length;
                                                indice = 0;
                                                intExisteCambio = false;
                                                intDatoInvalido = false;
                                                strDatoInvalido = "";
                                                prIniDatosDireccion();
                                                
                                                while ((lnPosDato < lnLongRegistro) && (intDatoInvalido != true))
                                                {
                                                    prGuardarDatos(indice, fncSubstraerDatos(ref lnPosDato, strLineaArchivo).Trim());
                                                    indice = indice + 1;
                                                }
                                                                                                                                                                    
                                                if ((intExisteCambio) && (intDatoInvalido == false))
                                                {
                                                    intExisteCuenta = false;
                                                    //'igblRetorna = SqlCancel(hgblConexion)
                                                    CORVAR.pszgblsql = "select eje_nom_gra,eje_sexo,eje_calle,eje_col,eje_zp,eje_pob,eje_edo,eje_cp,eje_tel_dom,eje_tel_ofi,";
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_ext,eje_acti_subacti,eje_rfc from MTCEJE01";
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo= " + CORVAR.igblPref + " and gpo_banco = " + CORVAR.igblBanco;
                                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + objCambioMasivo.NoEmpresa + " and eje_num = " + intEjenum;

					                                if (CORPROC2.Obtiene_Registros() != 0)
					                                {
						                                while(VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
						                                {
                                                            objCambioMasivo.datosDir_NombreEjecutivo = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                                                            objCambioMasivo.datosDir_Sexo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                                            
                                                            if (objCambioMasivo.datosDir_Calle == "")
                                                            {
                                                                objCambioMasivo.datosDir_Calle = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                                                            }
                                                            
                                                            if (objCambioMasivo.datosDir_Colonia == "")
                                                            {
                                                                objCambioMasivo.datosDir_Colonia = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                                                            }
                                                            
                                                            objCambioMasivo.datosDir_ZP = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                                                            
                                                            if (objCambioMasivo.datosDir_Poblacion == "")
                                                            {
                                                                objCambioMasivo.datosDir_Poblacion = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                                                            }
                                                            
                                                            if (objCambioMasivo.datosDir_Estado == "")
                                                            {
                                                                objCambioMasivo.datosDir_Estado = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                                                            }
                                                                                                        
                                                            if (objCambioMasivo.datosDir_CP == "")
                                                            {
                                                                objCambioMasivo.datosDir_CP = VBSQL.SqlData(CORVAR.hgblConexion, 8);
                                                            }
                                                            
                                                            objCambioMasivo.datosDir_TelDomicilio = VBSQL.SqlData(CORVAR.hgblConexion, 9);
                                                            
                                                            if (objCambioMasivo.datosDir_TelOficina == "")
                                                            {
                                                                objCambioMasivo.datosDir_TelOficina = VBSQL.SqlData(CORVAR.hgblConexion, 10);
                                                            }
                                                            
                                                            if (objCambioMasivo.datosDir_Extension == "")
                                                            {
                                                                objCambioMasivo.datosDir_Extension = VBSQL.SqlData(CORVAR.hgblConexion, 11);
                                                            }
                                                            
                                                            objCambioMasivo.datosDir_Actividad = "03";
                                                            objCambioMasivo.datosDir_SubActividad = VBSQL.SqlData(CORVAR.hgblConexion, 12);
                                                            objCambioMasivo.datosDir_RFC = VBSQL.SqlData(CORVAR.hgblConexion, 13);
                                                            intExisteCuenta = true;
                                                        }
					                                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                                    }
                                                }
                                            }
                                            
                                        }
                                        
                                        if (intEjenum == 0)
                                        {
                                            lngRegistroFallidos = lngRegistroFallidos + 1;
                                            FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "No puede realizarse cambios sobre la cuenta padre", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                        }
                                        else if ((intIdTransaccion == (int) clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111) && (intDatoInvalido))
                                        {
                                            lngRegistroFallidos = lngRegistroFallidos + 1;
                                            FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "Existe error en los datos suministrados: " + strDatoInvalido, FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                        }
                                        else if ((intIdTransaccion == (int) clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111) && (!intExisteCambio))
                                        {
                                            lngRegistroFallidos = lngRegistroFallidos + 1;
                                            FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "No se encontrarón cambios a realizar", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                        }
                                        else if ((intIdTransaccion == (int) clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111) && (!intExisteCuenta))
                                        {
                                            lngRegistroFallidos = lngRegistroFallidos + 1;
                                            FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "No puede realizarse cambios ya que no existe la cuenta", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                        }
                                        //'dlgCambioMasivo.prGeneraDlg objCambioMasivo, objCambioMasivo.IdTransaccion(objCambioMasivo.Indice)
                                        //'genera el dialogo
                                        else if ((objCambioMasivo.get_DlgTransaccion(objCambioMasivo.indice) == MdlCambioMasivo.TRANS_LIM_USO) && (Strings.Mid(strLineaArchivo, 17, 1) == MdlCambioMasivo.TRANS_LIM_USO))
                                        {
                                            mctaCuenta = new clsCuenta();
                                            mctaCuenta.productoPRD = mdlParametros.gprdProducto;
                                            mctaCuenta.CuentaS = Strings.Left(strLineaArchivo, 16);
                                            //'Agregar validación para que la cuenta identifique cuando se trate de una cuenta corporativa y cuando de una ejecutiva
                                            if (mctaCuenta.TipoCuentaE == clsCuenta.ctaTiposCuenta.ctaEjecutiva)
                                            {
                                                ilOpSuccesful = 0;
                                                ilOpSuccesful = mctaCuenta.ActualizaLimiteCredI(maccLimiteUso, Decimal.Parse(Strings.Mid(strLineaArchivo, 18, ilLongValorMax), NumberStyles.Currency), prySeguridadS041.topTipoOperMakerChecker.topMaker);
                                            }
                                            else
                                            {
                                                lngContador = lngContador - 1;
                                                lnRegistrosProcesar = lnRegistrosProcesar - 1;
                                            }
                                            if (ilOpSuccesful == 0)
                                            {
                                                if (intEjenum > 0)
                                                {
                                                    lngRegistroFallidos = lngRegistroFallidos + 1;
                                                    FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "La tabla MTCEMP01  no pudo ser actualizada", FileSystem.TAB(100), DateTime.Today.ToString("yyyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
                                                }
                                            }
                                            else
                                            { lngRegistrosOK = lngRegistrosOK + ilOpSuccesful; }
                                        }
                                        else //if (!blCancelada(objConS111, mdlParametros.tgCambioS111.NumCuentaS))
                                        {
                                            //dlgCambioMasivo.prGeneraDlg objCambioMasivo, objCambioMasivo.IdTransaccion(objCambioMasivo.Indice)
                                            //genera el dialogo
                                            N_ActualizaS111.ClsConectaS111 ObjConexionS111 = new N_ActualizaS111.ClsConectaS111();
                                            if (objCambioMasivo.fnEnviarDialogo(strMsg, ObjConexionS111))
                                            {
                                                //El dialogo paso exitosamente por lo tanto se actualiza la tabla de ejecutivos
                                                //Actualiza la tabla de ejecutivos
                                                if (FnActualizaEjecutivo(CORVAR.igblPref, intEjenum, CORVAR.igblBanco))
                                                {
                                                    if (intEjenum == 0)
                                                    {
                                                        //El ejecutivo que se está actualizando es una empresa por
                                                        //lo tanto se debe actualizar la tabla de empresas.
                                                        if (FnActualizaEmpresa())
                                                        { lngRegistrosOK++; }
                                                        else
                                                        {
                                                            lngRegistroFallidos++;
                                                            //AIS-1121 NGONZALEZ
                                                            FileSystem.PrintLine(intFreeFile, new object[] { StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "La tabla MTCEMP01  no pudo ser actualizada", FileSystem.TAB(100), DateTime.Today.ToString("yyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss") });
                                                        }
                                                    }
                                                    else
                                                    { lngRegistrosOK++; }

                                                }
                                                else
                                                {
                                                    lngRegistroFallidos++;
                                                    //AIS-1121 NGONZALEZ
                                                    FileSystem.PrintLine(intFreeFile, new object[] { StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), "La tabla MTCEJE01  no pudo ser actualizada", FileSystem.TAB(100), DateTime.Today.ToString("yyy-MM-dd") + new String(' ', 1) + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss") });
                                                }
                                            }
                                            else
                                            {
                                                //Actualiza el log
                                                bool tempRefParam2 = true;
                                                strMsg = Strings.Replace(objConS111.get_MsgError(ref tempRefParam2), "\r", ".", 1, -1, CompareMethod.Binary); //Quita los saltos de linea si es que existen
                                                strMsg = Strings.Replace(strMsg, "\n", "", 1, -1, CompareMethod.Binary); //Quita los saltos de linea si es que existen
                                                strMsg = Strings.Replace(strMsg, "..", ".", 1, -1, CompareMethod.Binary);
                                                FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), Strings.Mid(strLineaArchivo, 1, 16), FileSystem.TAB(45), strMsg + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"));
                                                lngRegistroFallidos++;
                                            }
                                        }
                                        //else
                                        //{
                                        //    bool tempRefParam1 = true;
                                        //    strMsg = Strings.Replace(objConS111.GetMsgerror(ref tempRefParam1), "\r", ".", 1, -1, CompareMethod.Binary); //'Quita los saltos de linea si es que existen
                                        //    if (strMsg.IndexOf("CANCEL", 1) > 0)
                                        //    { strMsg = " Cuenta Cancelada "; }
                                        //    strMsg = Strings.Replace(strMsg, "\n", "", 1, -1, CompareMethod.Binary); //'Quita los saltos de linea si es que existen
                                        //    strMsg = Strings.Replace(strMsg, "..", ".", 1, -1, CompareMethod.Binary);
                                        //    FileSystem.PrintLine(intFreeFile, StringsHelper.Format(lngContador, "######"), FileSystem.TAB(15), mdlParametros.tgCambioS111.NumCuentaS, FileSystem.TAB(45), strMsg + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"));
                                        //    lngRegistroFallidos = lngRegistroFallidos + 1;
                                        //}
                                    }
                                }
                            }
                            try { CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = Convert.ToInt16(100 * (lngRegistroFallidos + lngRegistrosOK) / ((double)lnRegistrosProcesar)); }
                            catch { }
                            try { CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Procesando Registro No: " + StringsHelper.Format(lngContador, "###,##0"); }
                            catch { }
                            try { CORMDIBN.DefInstance.ID_COR_MSG_TXT.Refresh(); }
                            catch { }

                            Information.Err().Clear();
                        } while (!FileSystem.EOF(intFreeFileCM));
                        FileSystem.FileClose(intFreeFileCM);
                    }
                    else
                    {
                        MdlCambioMasivo.MsgInfo("El archivo está vacio");
                    }
                }
            }
            //Print #intFreeFile, "Proceso Terminado "; Format(Date, "yyyy-mm-dd") & " " & Format(Time, "hh:mm:ss")
            FileSystem.PrintLine(intFreeFile, "Proceso Terminado: " + DateTime.Now.AddDays(-DateTime.Now.Date.ToOADate()).ToString("HH:mm:ss"));
            FileSystem.FileClose(intFreeFile); //Cierra el archivo del log
            //Set dlgCambioMasivo = Nothing 'Libera el objeto del dialogo
            objConS111 = null;
            RsEmpresa = null;
            this.Cursor = Cursors.Default;

            MdlCambioMasivo.MsgInfo("Proceso Terminado" + "\r" +
                                    "Registros Aceptados:" + StringsHelper.Format(lngRegistrosOK, "###,##0") + "\r" +
                                    "Registros Fallidos :" + StringsHelper.Format(lngRegistroFallidos, "###,##0") + "\r" +
                                    "Total de Registros :" + StringsHelper.Format(lngRegistroFallidos + lngRegistrosOK, "###,##0"));
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = 0;
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = false;
            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "";
            if (lngRegistroFallidos > 0)
            {
                string tempRefParam3 = "Tarjeta Ejecutiva (Cambios Masivos)";
                if (MdlCambioMasivo.FnMsgYesno("¿ Desea ver el resultado de los registros rechazados ? ", ref tempRefParam3))
                {
                    FrmError = FrmRptCambioMasivo.CreateInstance();
                    prActualizarRpt(ref strNombreArchivoLog, FrmError);
                    FrmError.Text = "Tarjeta Ejecutiva.-Cambios Masivos Pendientes de Procesar";
                    FrmError.ShowDialog();
                    FrmError.Close();
                    FrmError = null;

                }
            }
            Application.DoEvents();
            return false;
        Handler:
            string tempRefParam4 = "Tarjeta Ejecutiva.- FnEfectuarCambioMasivo";
            if (MdlCambioMasivo.fnGetError(ref tempRefParam4))
            {
                throw new Exception("Migration Exception: 'Resume' not supported");
            }
            else
            {
                try { FileSystem.FileClose(intFreeFile); }
                catch { } //Cierra el archivo del log
                //Set dlgCambioMasivo = Nothing 'Libera el objeto del dialogo
                objConS111 = null;

                if (RsEmpresa == null)
                {
                    try
                    {
                        if (RsEmpresa.State != 0)
                        { 
                            RsEmpresa.Close(); 
                        }
                    }
                    catch { }
                }
                RsEmpresa = null;
            }

            try
            {
                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                { 
                    VBSQL.gConn[10].Close(); 
                }
            }
            catch { }
            return false;
        }

        private bool FnActualizaEmpresa()
        {
            //Objetivo: Actualiza la tabla de empresas una vez que el dialogo enviado al 111 es procesado correctamente.
            //          y la actualización a la tabla de ejecutivos se hayan realizado exitosamente.
            //Elaboro: Clemente Muñoz Para Eissa Solutions Provider
            //Fecha de Elaboración: 2003-9-02

            bool result = false;
            try
            {
                string strSql = String.Empty;

                if (VBSQL.OpenConn(9) != 0)
                { 
                    VBSQL.gConn[9].Close(); 
                }
                else
                { 
                    VBSQL.gConn[9].Close(); 
                }

                if (VBSQL.OpenConn(9) == 0)
                {

                    //Actualiza la tabla de empresas para sincronizar con el dialogo
                    //por lo tanto se actualiza la empresa
                    clsDialogo.enuTipoDialogo switchVar = objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice);
                    switch (switchVar)
                    {
                        //case clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111:
                        //    strSql = "";  //El porcentaje de disposicion solo aplica al ejecutivo 
                        //    break;
                        //case clsDialogo.enuTipoDialogo.tCambioSkipEjecutivoS111:
                        //    strSql = "Update MTCEMP01 set ";
                        //    strSql = strSql + "emp_skip_payment=" + objCambioMasivo.ValorModificar.ToString();

                        //    break;
                        //case clsDialogo.enuTipoDialogo.tCambioTipoBloqueoEjecutivoS111:
                        //    strSql = "";  //El tipo de bloqueo no aplica a la empresa 
                        //    break;
                        case clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111:
                            strSql = "Update MTCEMP01 set ";
                            strSql = strSql + "emp_tabla_mcc=" + objCambioMasivo.ValorModificar.ToString();
                            break;
                        //case clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111:
                        //    strSql = "";  //La empresa no aplica pin y plastico 
                        //    break;
                    }

                    if (strSql != "")
                    {
                        strSql = strSql + " Where emp_num= " + objCambioMasivo.NoEmpresa.ToString();
                        strSql = strSql + " And eje_prefijo = " + CORVAR.igblPref.ToString();
                        strSql = strSql + " And gpo_banco = " + CORVAR.igblBanco.ToString();
                        strSql = strSql + " and gpo_num =" + intFrmGrupo.ToString();
                        object tempRefParam = Type.Missing;
                        VBSQL.gConn[9].Execute(strSql, out tempRefParam, -1); //Procesa la transaccion a la empresa seleccionada
                    }
                    result = true;
                    VBSQL.gConn[9].Close();
                }
            }
            catch
            {

                string tempRefParam2 = "FnActualizaEmpresa";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam2))
                {
                   throw new Exception("Migration Exception: 'Resume' not supported");
                }

                if (VBSQL.gConn[9].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                { 
                    VBSQL.gConn[9].Close(); 
                }
            }
            return result;
        }

        private bool FnActualizaEjecutivo(int intPrefijo, int intEjecutivo, int intGpoBanco)
        {
            //Objetivo: Actualiza la tabla de ejecutivos una vez que el dialogo enviado al 111 es procesado correctamente.
            //Elaboro: Clemente Muñoz Para Eissa Solutions Provider
            //Fecha de Elaboración: 2003-9-02

            bool result = false;
            string strSql = String.Empty;
            try
            {
                result = false;

                if (VBSQL.OpenConn(9) != 0)
                { 
                    VBSQL.gConn[9].Close(); 
                }
                else
                { 
                    VBSQL.gConn[9].Close(); 
                }

                if (VBSQL.OpenConn(9) == 0)
                {
                    strSql = "Update MTCEJE01 set ";
                    clsDialogo.enuTipoDialogo switchVar = objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice);
                    switch (switchVar)
                    {
                        case clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111:
                            strSql = strSql + "eje_lim_dis_efec=";
                            break;
                        //case clsDialogo.enuTipoDialogo.tCambioSkipEjecutivoS111:
                        //    strSql = strSql + "eje_skip_payment=";
                        //    break;
                        //case clsDialogo.enuTipoDialogo.tCambioTipoBloqueoEjecutivoS111:
                        //    strSql = strSql + "eje_tipo_bloqueo=";
                        //    break;
                        case clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111:
                            strSql = strSql + "eje_tabla_mcc=";
                            break;
                        //case clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111:
                        //    strSql = strSql + " eje_gen_pin_pla = ";
                        //    break;
                        case clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111:
                            if (intEjecutivo == 0)
                            {
                                return false;
                            }
                            strSql = strSql + "eje_calle = '" + objCambioMasivo.datosDir_Calle + "',eje_col = '" + objCambioMasivo.datosDir_Colonia + "',";
                            strSql = strSql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "', ";
                            strSql = strSql + " eje_pob = '" + objCambioMasivo.datosDir_Poblacion + "', eje_cp = " + objCambioMasivo.datosDir_CP + ",";
                            strSql = strSql + " eje_edo = '" + objCambioMasivo.datosDir_Estado + "',";
                            strSql = strSql + " eje_tel_ofi = '" + objCambioMasivo.datosDir_TelOficina + "',eje_ext = '" + objCambioMasivo.datosDir_Extension + "'";
                            if (objCambioMasivo.datosDir_Fax.Trim() != "")
                            {
                                strSql = strSql + ", eje_fax = '" + objCambioMasivo.datosDir_Fax + "'";

                            }
                            break;
                    }

                    if (objCambioMasivo.get_IdTransaccion(objCambioMasivo.indice) != clsDialogo.enuTipoDialogo.tCambioDirEjecutivoS111)
                    {
                        strSql = strSql + objCambioMasivo.ValorModificar;
                    }

                    strSql = strSql + " Where emp_num= " + objCambioMasivo.NoEmpresa.ToString();
                    strSql = strSql + " And eje_num = " + intEjecutivo.ToString();
                    strSql = strSql + " And eje_prefijo = " + intPrefijo.ToString();
                    strSql = strSql + " And gpo_banco = " + intGpoBanco.ToString();
                    object tempRefParam = Type.Missing;
                    VBSQL.gConn[9].Execute(strSql, out tempRefParam, -1);
                    result = true; //La empresa se dio de alta exitosamente
                    VBSQL.gConn[9].Close();
                }
            }
            catch
            {

                string tempRefParam2 = "FnActualizaEjecutivo";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam2))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                if (VBSQL.gConn[9].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[9].Close();
                }
            }
            return result;
        }

        private int intFnAbrirArchivo(ref  string strNombreArchivo)
        {
            //Objetivo: Abre un archivo para su actualización devolviendo el número de Manejador utilizado para dicho archivo
            //Parametros:
            //           strNombreArchivo: Nombre del archivo que se desea procesar
            //                             strNombreArchivo Devuelve el nombre del archivo incluyendo su path
            //Valor devuelto: Número de Manejador utilizado devuelve -1 si el archivo no pudo ser abierto.
            //Elaboro: Clemente Muñoz Para Eissa Solutions Provider
            //Fecha de Elaboración: 2003-10-02


            int result = 0;
            int intHandlerArchivo = 0;
            string pszDirectorio = String.Empty;
            string pszFecha = String.Empty;

            try
            {
                result = -1;
                pszDirectorio = CORVAR.pszgblPathCorpo + "CamMasiv\\";
                if (FileSystem.Dir(pszDirectorio, FileAttribute.Directory) == CORVB.NULL_STRING)
                {
                    Directory.CreateDirectory(pszDirectorio);
                }
                strNombreArchivo = pszDirectorio + strNombreArchivo;
                //verifica si existe el archivo

                intHandlerArchivo = FileSystem.FreeFile(); //Determina el manejador del archivo actual
                if (FileSystem.Dir(strNombreArchivo, FileAttribute.Archive) != CORVB.NULL_STRING)
                {
                    //obtiene la fecha y hora del archivo
                    pszFecha = StringsHelper.DateValue((new FileInfo(strNombreArchivo)).LastWriteTime.ToString("yyyy/MM/dd")).ToString();
                    //si las fechas son diferentes aplastara al archivo existente
                    if (DateTime.Parse(pszFecha) != DateTime.Today)
                    {
                        FileSystem.FileOpen(intHandlerArchivo, strNombreArchivo, OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                        //  Print #intHandlerArchivo, "Reporte de transacciones no realizadas por el proceso de cambios masivos"
                        FileSystem.PrintLine(intHandlerArchivo, "No. Registro", FileSystem.TAB(15), "No. Cta", FileSystem.TAB(45), "Causa de Error", FileSystem.TAB(100), "Fecha (aaaa-mm-dd hh:mm:ss)");

                    }
                    else
                    {
                        // si las fechas son iguales abre al archivo para aggregar
                        FileSystem.FileOpen(intHandlerArchivo, strNombreArchivo, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);


                    }
                }
                else
                {
                    FileSystem.FileOpen(intHandlerArchivo, strNombreArchivo, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
                    //Print #intHandlerArchivo, "Reporte de Transacciones No realizadas por el proceso de cambios masivos"
                    FileSystem.PrintLine(intHandlerArchivo, "No. Registro", FileSystem.TAB(15), "No. Cta", FileSystem.TAB(45), "Causa de Error", FileSystem.TAB(100), "Fecha (aaaa-mm-dd hh:mm:ss)");

                }
                return intHandlerArchivo;
            }
            catch(Exception e)
            {
                //AIS-536 FSABORIO
                if (e is System.IO.IOException)
                    Information.Err().Number = 70;
                else if (e is System.Runtime.InteropServices.COMException)
                    Information.Err().Number = ((System.Runtime.InteropServices.COMException)e).ErrorCode;
                else
                    Information.Err().Number = 0;

                Information.Err().Description = e.Message;


                result = -1;
                if (MdlCambioMasivo.fnGetError())
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                else
                {
                    //Trata de cerrar el archivo en caso de ser necesario
                    try
                    {
                        FileSystem.FileClose(intHandlerArchivo);
                    }
                    catch { }
                }
            }
            return result;
        }
        private void prActualizarRpt(ref  string strArchivo, FrmRptCambioMasivo FrmError)
        {
            int intNoArchivo = 0;
            try
            {
                string strContenidoArchivo = String.Empty;
                this.Cursor = Cursors.WaitCursor;
                if (strArchivo != "")
                {
                    if (FileSystem.Dir(strArchivo, FileAttribute.Archive) != "")
                    {
                        intNoArchivo = FileSystem.FreeFile();
                        FileSystem.FileOpen(intNoArchivo, strArchivo, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);

                        FrmError.LstReporte.Items.Clear();
                        //.Locked = True


                        while (!FileSystem.EOF(intNoArchivo))
                        {
                            FileSystem.Input(intNoArchivo, ref strContenidoArchivo);
                            FrmError.LstReporte.Items.Add(strContenidoArchivo);
                        };
                    }
                }
                FileSystem.FileClose(intNoArchivo);
                FrmError.Refresh();
                this.Cursor = Cursors.Default;
            }
            catch
            {

                string tempRefParam = "prActualizarRpt";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    FileSystem.FileClose(intNoArchivo);
                }
                this.Cursor = Cursors.Default;
            }

        }
        private void frmCambiosMasivos_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void _BtnProceso_0_Click(object sender, EventArgs e)
        {
            BtnProceso_ClickEvent(sender);
        }

        private void _BtnProceso_1_Click(object sender, EventArgs e)
        {
            BtnProceso_ClickEvent(sender);
        }

        private void MskPorcentaje1_Validating(object sender, CancelEventArgs e)
        {
            bool Cancel = e.Cancel;
            int result = 0;
            objCambioMasivo.ValorModificar = Int32.TryParse(StringsHelper.Format(MskPorcentaje1.Text, ""), out result) == false ? 0 : result;
            if (~objCambioMasivo.ValorValido() != 0)
            {
                MdlCambioMasivo.MsgInfo("El valor suministrado es invalido");
                Cancel = true;
            }
            e.Cancel = Cancel;
        }

        private void MskPorcentaje1_Enter(object sender, EventArgs e)
        {
            MskPorcentaje1.SelectionStart = 0;
            MskPorcentaje1.SelectionLength = Strings.Len(MskPorcentaje1.Text);
        }

        public string fncSubstraerDatos(ref int ipPos1,string spDatos)
        {
            int llLongitudDato;
            int intposTab;
            string sDato;

            if ((ipPos1 + 1) < spDatos.Length)
            {
                intposTab = spDatos.IndexOf(Strings.Chr(9), ipPos1 + 1);
            }
            else
            {
                intposTab = 0;
            }

            if (intposTab == ipPos1 + 1)
            {
                return "";
                ipPos1 = ipPos1 + 1;
            }
            else
            {
                if (intposTab == 0)
                {
                    llLongitudDato = spDatos.Length - ipPos1;
                }
                else
                {
                    //llLongitudDato = intposTab - (ipPos1 + 1);
                    llLongitudDato = intposTab - ipPos1;
                }
                
                sDato = Strings.Mid(spDatos, ipPos1 + 1, llLongitudDato);
                ipPos1 = ipPos1 + llLongitudDato + 1;
                return sDato;
            }
        }

        public int fnEsTipoEnvioIndividual()
        {
            int edoConexion;
            string strTipoEnvio;
            //'igblPref, intEjenum, igblBanco
            edoConexion = CORDBLIB.Segunda_ConexionServidor();
            CORVAR.pszgblSql2 = "select emp_tipo_envio from MTCEMP01 where eje_prefijo= " + CORVAR.igblPref;
            CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " and gpo_banco = " + CORVAR.igblBanco;
            CORVAR.pszgblSql2 = CORVAR.pszgblSql2 + " and emp_num = " + objCambioMasivo.NoEmpresa;
                
            //fnEsTipoEnvioIndividual = TIPO_ENVIO_EMPRESA;

            if (edoConexion != VBSQL.FAIL)
            {
                if (CORPROC2.Obtiene_Datos() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.MOREROWS)
                    {
                        strTipoEnvio = VBSQL.SqlData(CORVAR.hgblConexion2, 1);
                        if (strTipoEnvio.Trim() == "I")
                        {
                            return TIPO_ENVIO_INDIVIDUAL;
                        }
                        else
                            return TIPO_ENVIO_EMPRESA;
                    }
                    else
                    {
                        return ERROR_VERIFICAR_TIPO_ENVIO;
                    }
                }
                else
                {
                    return ERROR_VERIFICAR_TIPO_ENVIO;
                }
                
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
                VBSQL.SqlClose (CORVAR.hgblConexion2);
            }
            else
                return ERROR_VERIFICAR_TIPO_ENVIO;
        }

        public void prGuardarDatos(int ipTipoDato,string strDato)
        {
            int intTamDato;
            double dbNumericTemp = 0;
            
            intTamDato = strDato.Length;
            switch (ipTipoDato)
            {
                case 0:
                    {
                        if (intTamDato > 35)
                        {
                            intDatoInvalido = true;
                            strDatoInvalido = "Calle y número excede la longuitud permitida";
                            return;
                        }
                        objCambioMasivo.datosDir_Calle = strDato.ToUpper();
                        break;
                    }
                case 1:
                    {
                        if (intTamDato > 25)
                        {
                            intDatoInvalido = true;
                            strDatoInvalido = "Colonia excede la longuitud permitida";
                            return;
                        }
                        objCambioMasivo.datosDir_Colonia = strDato.ToUpper();
                        break;
                    }
                case 2:
                    {
                        if (intTamDato > 21)
                        {
                            intDatoInvalido = true;
                            strDatoInvalido = "Población excede la longuitud permitida";
                            return;
                        }
                        objCambioMasivo.datosDir_Poblacion = strDato.ToUpper();
                        break;
                    }
                case 3:
                    {
                        if (intTamDato > 4)
                        {
                            intDatoInvalido = true;
                            strDatoInvalido = "Estado excede la longuitud permitida";
                            return;
                        }
                        objCambioMasivo.datosDir_Estado = strDato.ToUpper();
                        break;
                    }
                case 4:
                    {
                        if (intTamDato > 5)
                        {
                            intDatoInvalido = true;
                            strDatoInvalido = "Código Postal excede la longuitud permitida";
                            return;
                        }
                        else
                            if (strDato.Trim() != "")
                            {
                                dbNumericTemp = 0;
                                if ((!Double.TryParse(strDato, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp)) || (strDato.IndexOf(".", 1) > 0))
                                {
                                    intDatoInvalido = true;
                                    strDatoInvalido = "Código Postal suministrado no es numérico";
                                    return;
                                }
                            }
                        objCambioMasivo.datosDir_CP = strDato.ToUpper();
                        break;
                    }
                case 5:
                    {
                        if (intTamDato > 10)
                        {
                            intDatoInvalido = true;
                            strDatoInvalido = "Teléfono de oficina excede de la longuitud permitida";
                            return;
                        }
                        else
                            if (strDato.Trim() != "")
                            {
                                dbNumericTemp = 0;
                                if ((!Double.TryParse(strDato, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp)) || (strDato.IndexOf(".", 1) > 0))
                                {
                                    intDatoInvalido = true;
                                    strDatoInvalido = "Teléfono de oficina suministrado no es numérico.";
                                    return;
                                }
                            }
                        objCambioMasivo.datosDir_TelOficina = strDato.ToUpper();
                        break;
                    }
                case 6:
                    {
                        if (intTamDato > 4)
                        {
                            intDatoInvalido = true;
                            strDatoInvalido = "Extensión excede de la longuitud permitida.";
                            return;
                        }
                        else
                            if (strDato.Trim() != "")
                            {
                                dbNumericTemp = 0;
                                if ((!Double.TryParse(strDato, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp)) || (strDato.IndexOf(".", 1) > 0))
                                {
                                    intDatoInvalido = true;
                                    strDatoInvalido = "La Extensión suministrada no es numérica.";
                                    return;
                                }
                            }
                        objCambioMasivo.datosDir_Extension = strDato.ToUpper();
                        break;
                    }
                case 7:
                    {
                        if (intTamDato > 10)
                        {
                            intDatoInvalido = true;
                            strDatoInvalido = "El Fax excede de la longuitud permitida.";
                            return;
                        }
                        else
                            if (strDato.Trim() != "")
                            {
                                dbNumericTemp = 0;
                                if ((!Double.TryParse(strDato, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp)) || (strDato.IndexOf(".", 1) > 0))
                                {
                                    intDatoInvalido = true;
                                    strDatoInvalido = "El Fax suministrado no es numérico.";
                                    return;
                                }
                            }
                        objCambioMasivo.datosDir_Fax = strDato.ToUpper();
                        break;
                    }
            }

            if (strDato != "")
            {
                intExisteCambio = true;
            }
            
        }

        public void prIniDatosDireccion()
        {
            objCambioMasivo.datosDir_Calle = "";
            objCambioMasivo.datosDir_Colonia = "";
            objCambioMasivo.datosDir_Poblacion = "";
            objCambioMasivo.datosDir_Estado = "";
            objCambioMasivo.datosDir_CP = "";
            objCambioMasivo.datosDir_TelOficina = "";
            objCambioMasivo.datosDir_Extension = "";
            objCambioMasivo.datosDir_Fax = "";
        }

        private bool blCancelada(N_ActualizaS111.ClsConectaS111 obConS111, string peCuenta)
        {
            string slRespuesta;
            int iPosDato;
            string sTrans = "377";
            string sParamAdi = "";

            obConS111.StrIdTransaccion = sTrans;
            obConS111.StrNoCuenta = peCuenta;
            obConS111.StrParametrosAdicionales = sParamAdi;

            //switch (obConS111.FnEnviarTransaccion(ref sTrans,
            //                                      ref peCuenta,
            //                                      ref sParamAdi))
            //{
            //    case TransS111.EnumRespTransaccion.EnRespConfirmar:
            //        return true;
            //    case TransS111.EnumRespTransaccion.EnRespError:
            //        return true;
            //    case TransS111.EnumRespTransaccion.EnRespOperacionNegada:
            //        return true;
            //    case TransS111.EnumRespTransaccion.EnRespSinRespuesta:
            //    case TransS111.EnumRespTransaccion.EnRespIniciado:
            //        return true;
            //    case TransS111.EnumRespTransaccion.EnRespTerminalSinFirmar:
            //    case TransS111.EnumRespTransaccion.EnRespDarseAlta:
            //        return true;
            //    case TransS111.EnumRespTransaccion.EnRespDesconocida:
            //    case TransS111.EnumRespTransaccion.EnRespTransaccionAceptada:
            //        bool bResp = false;
            //        slRespuesta = obConS111.get_MsgError(ref bResp);
            //        //'    MsgBox slRespuesta

            //        iPosDato = slRespuesta.IndexOf("BASICA", 1);
            //        if (iPosDato > 0)
            //        {
            //            if (slRespuesta.IndexOf("CANCEL", iPosDato) > 0)
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //        break;
            //    default:
                    return false;
            //        break;
            //}
        }
    }
}