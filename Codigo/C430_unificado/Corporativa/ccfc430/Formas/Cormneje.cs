using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;


namespace TCc430
{

    internal partial class CORMNEJE
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Forma de Captura y consulta de Ejecutivos Empresa   **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**                                                                        **
        //****************************************************************************

        int hConexion = 0;
        int iEjePref = 0;
        string pszTempCuenta = String.Empty;
        string pszEjeTempNom = String.Empty;
        int iEjeTempNum = 0;
        int lEjeLimCred = 0;
        bool bConexion = false;
        string pszMensaje = String.Empty;
        string pszMensajeS016 = String.Empty;
        string pszMensajeS111 = String.Empty;
        int ilBanderaAlta = 0;
        int ilBanderaAltaS111 = 0;
        int ilBanderaAltaS016 = 0;

        bool mbActualizaM111 = false;

        bool bAltaNuevamente = false;

        string ppszEjeCalle = String.Empty;
        string ppszEjeCol = String.Empty;
        string slEstado = String.Empty;
        int iEjeZP = 0;
        int lEjeCP = 0;
        string ppszEjePob = String.Empty;
        string pszEjeTelDom = String.Empty;
        string pszEjeTelOfi = String.Empty;
        string pszEjeExt = String.Empty;
        string pszEjeFax = String.Empty;
        int iSucTran = 0;
        int iSucProm = 0;
        int iDiaCorte = 0;
        string pszSexo = String.Empty;
        string pszFecha = String.Empty;
        string pszOrigen = String.Empty;
        string pszActSubAct = String.Empty;
        string pszEjeRFC = String.Empty;
        string pszEjeNom = String.Empty;
        string pszEjeNomGra = String.Empty;
        string msNomGraba = String.Empty;
        string msLimCred = String.Empty;
        string msTelPar = String.Empty;
        string msTelOfi = String.Empty;
        string msExt = String.Empty;
        string msCalle = String.Empty;
        string msCol = String.Empty;
        string msPob = String.Empty;
        string msCP = String.Empty;
        string msSubAct = String.Empty;
        string msSexo = String.Empty;
        string msNombre = String.Empty;
        string msZP = String.Empty;
        string msActividad = String.Empty;
        string msSueldo = String.Empty;
        string msNoNomina = String.Empty;
        string msEjeCC = String.Empty;
        string msNivel = String.Empty;
        string msEjeRFC = String.Empty;
        string msEjeFax = String.Empty;
        string msRegion = String.Empty;
        bool msSexoF = false;
        bool msSexoM = false;

        //Campos adicionales de MTCEJE01
        private string slDomCalle = String.Empty;
        private string slDomColonia = String.Empty;
        private string slDomCiudad = String.Empty;
        private string slDomPoblacion = String.Empty;
        private string slDomEstado = String.Empty;

        private int llDomCodigoPostal = 0;
        string slEMail = String.Empty;
        string slCtaContable = String.Empty;
        int ilGenPinPlastico = 0;
        int llLimDispEfectivo = 0;
        int ilTipoBloqueo = 0;
        string slIndLimDispEfec = String.Empty;
        string slNacionalidad = String.Empty;
        string slIndCtaControl = String.Empty;
        string slTipoProducto = String.Empty;
        string slEsquemaPago = String.Empty;

        string slUsuarioCambio = String.Empty;
        int llFechaAlta = 0;
        int llFechaCambio = 0;
        int ilHoraCambio = 0;

        static readonly string slTipoCuenta = CRSParametros.cteIndividual;
        string slTipoFactura = String.Empty;
        string slCuentaAMostrar = String.Empty;
        string slCuentaBanamex = String.Empty;
        //Fin de Campos Adicionales

        //Campos Heredados
        int ilSkipPayment = 0;
        CheckState ilSkipPaymentHeredado = (CheckState)0;

        int ilTablaMCC = 0;
        int ilTablaMCCHeredado = 0;

        string msCamNomGra = String.Empty;
        string msCamDatGen = String.Empty;
        string msCamLimCre = String.Empty;
        string msCamDatAdi = String.Empty;

        //Variables para la transaccion 5368
        string smCambioMCC = String.Empty;
        string smCambioSKIP = String.Empty;
        string smCambioDISP = String.Empty;
        string smCambioPLA = String.Empty;
        string smCambioBLOQ = String.Empty;

        string bError = String.Empty;
        int iNoIntentos = 0;
        string sEnviaRut = String.Empty;

        bool mbPrimTran = false;

        //Variables que sustituyen a elementos
        string slModificacion = String.Empty; //Sustituye a Text de Modificación
        string slOrigen = String.Empty; //Sustituye a ID_MEE_PRO_EB.Text
        string slActividad = String.Empty; //Sustituye a ID_MEE_ACT_EB.Text
        string slSubActividad = String.Empty; //Sustituye a ID_MEE_SAC_EB.Text
        string slEstadoEnv = String.Empty;
        string blTransmitir = String.Empty; //Sustituye a ID_MEE_TRA_CKB.value
        int ilSucPromotora = 0; //Sustituye a ID_MEE_SUC_PRO_ITB.texto
        int ilSucTransmisora = 0; //Sustituye a ID_MEE_SUC_ITB.texto
        string slRegion = String.Empty; //Sustituye a ID_MEE_REG_PIC.Texto
        string slATM = String.Empty; //Sustituye a ID_MEE_ATM_EB.Texto (Default 05)
        string slInstEspeciales = String.Empty; //Sustituye a Instrucciones Especiales ID_MEE_INE_EB.Text
        string slConsecutivo = String.Empty; //Sustituye a ID_MEE_CON_TXT.Text
        string slNivJerarquico = String.Empty; //Sustituye a ID_MEE_NVJ_ITB.Text

        //Variables para la Transaccion 5368
        int ilSkipPaymentCambio = 0;
        int ilTablaMCCCambio = 0;
        int ilGenPinPlasticoCambio = 0;
        int llLimDispEfectivoCambio = 0;
        int ilTipoBloqueoCambio = 0;

        //Contiene todos los datos del Ejecutivo
        CRSDialogo.DatosEjecutivo ejelEjecutivo = CRSDialogo.DatosEjecutivo.CreateInstance();
        string slCuentaPadre = String.Empty;


        //crea un objeto a la conexion del condrive
        private Conecta.ConexionesHost _ConComDrive = null;
        Conecta.ConexionesHost ConComDrive
        {
            get
            {
                if (_ConComDrive == null)
                {
                    _ConComDrive = new Conecta.ConexionesHost();
                }
                return _ConComDrive;
            }
            set
            {
                _ConComDrive = value;
            }
        }



        //Variable Aucxiliar para detectar UPDATE
        bool blUpdate = false;

        // itsm
        public bool blFirma = false;
        public bool blActualizo = false;

        public bool blActualizaM111 = false;

        clsCuenta ctaCuenta = null; //EISSA 2005 - HVV Cuenta
        prySeguridadS041.clsAccion accAccion = null; //EISSA 2005 - HVV Acción de Cambio de Límite de Crédito

        const string STR_ALTA_EJE = "Se dió de alta el Ejecutivo, el número de cuenta asignado es ";
        clsRFC objRfcEje = null;
        bool CargaTablas = false;
        public N_ActualizaS111.ClsConectaS111 ObjConexionS111 = null;
        private N_ActualizaS111.ClsConectaS111 mcnsS111N = null;
        private bool Actualiza_Campos_M111(ref  string pszParametro)
        {

            bool result = false;
            string pszCadena = String.Empty;
            string pszCaracter = String.Empty;


            string pszNumCta = CORVB.NULL_STRING;

            for (int iPos = 1; iPos <= slCuentaBanamex.Length; iPos++)
            {
                pszCaracter = Strings.Mid(slCuentaBanamex, iPos, 1);
                if (pszCaracter != " ")
                {
                    pszNumCta = pszNumCta + pszCaracter;
                }
            }

            string pszPrefijo = Strings.Mid(pszNumCta, 1, 4);
            string pszBanco = Strings.Mid(pszNumCta, 5, 2);
            string pszEmpresa = Strings.Mid(pszNumCta, 7, Formato.sMascara(Formato.iTipo.Empresa).Length);
            string pszEje = Strings.Mid(pszNumCta, 7 + Formato.sMascara(Formato.iTipo.Empresa).Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length);
            string pszRollOver = Strings.Mid(pszNumCta, 15, 1);
            string pszDigito = Strings.Mid(pszNumCta, 16, 1);

            switch (pszParametro)
            {
                case "Nombre":
                    CORVAR.pszgblsql = " UPDATE MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "  set eje_nom_gra = '" + ID_MEE_NCE_EB.Text + "',";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " Where eje_prefijo = " + pszPrefijo;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + pszBanco;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + pszEje;
                    pszCadena = " el Nombre de Grabación";
                    break;
                case "Telefono":
                    CORVAR.pszgblsql = "UPDATE MTCEJE01 set eje_calle = '" + ID_MEE_CNU_EB.Text + "',eje_col = '" + ID_MEE_COL_EB.Text + "',";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_pob = '" + ID_MEE_POB_EB.Text + "', eje_cp = " + ID_MEE_CP_PIC.defaultText + ",";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_zp = " + ID_MEE_ZPO_PIC.CtlText + ", eje_edo = '" + CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex] + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",eje_tel_dom = '" + ID_MEE_TDO_PIC.CtlText + "',";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_tel_ofi = '" + ID_MEE_TOF_PIC.CtlText + "',eje_ext = '" + ID_MEE_EXT_PIC.CtlText + "',";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " Where eje_prefijo = " + pszPrefijo;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + pszBanco;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + pszEje;
                    pszCadena = " la dirección";
                    break;
                case "Credito":
                    CORVAR.pszgblsql = " Exec spUCamMasivosLimCred " + Conversion.Str(mdlParametros.tgCambioLimCred.LimCredL) + ",";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + pszPrefijo + "," + pszBanco + "," + pszEmpresa + ",";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + pszEje + ",'" + CRSParametros.sgUserID + "'";
                    pszCadena = " el límite de crédito";
                    break;
                case "MCC":
                    CORVAR.pszgblsql = "update MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_tabla_mcc = " + ilTablaMCC.ToString() + ",";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + pszEje;
                    pszCadena = " el MCC";
                    break;
                case "SkipPayment":
                    CORVAR.pszgblsql = "update MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_skip_payment = " + ilSkipPayment.ToString() + ",";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + pszEje;
                    pszCadena = " el Skip Payment";
                    break;
                case "LimiteDisp":
                    CORVAR.pszgblsql = "update MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_lim_dis_efec = " + llLimDispEfectivo.ToString() + ",";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + pszEje;
                    pszCadena = " el Limite de Disposición de Efectivo";
                    break;
                case "GenPinPla":
                    CORVAR.pszgblsql = "update MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_gen_pin_pla = " + ilGenPinPlastico.ToString() + ",";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + pszEje;
                    pszCadena = " la Generación de Pin Plastico";
                    break;
                case "TipoBloqueo":
                    CORVAR.pszgblsql = "update MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_tipo_bloqueo = " + ilTipoBloqueo.ToString() + ",";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + pszEje;
                    pszCadena = " el Tipo de Bloqueo";
                    break;
            }

            if (CORPROC2.Modifica_Registro() != 0)
            {
                blActualizaM111 = true;
                CORVAR.gblCamMasivos = true;
                Inserta_Tabla_Cambios(pszNumCta, pszParametro);
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("No se modificó " + pszCadena + " del ejecutivo " + StringsHelper.Format(CORVAR.igblEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + " " + pszEjeNom + " en el M111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.WaitCursor;
                result = true;
                blActualizaM111 = false;
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return result;
        }


        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Inserta en la tabla de MTCCAM01  los registros que   **
        //**                   tuvieron exito en el cambio del S11 y del M111       **
        //**                                                                        **
        //**       Paso de parámetros:Numero de cuenta, identificador de operación  **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 12oct98                                     **
        //**                                                                        **
        //****************************************************************************'
        private void Inserta_Tabla_Cambios(string pszNoCta, string pszParametro)
        {

            string pszNomGra = String.Empty;
            string pszCalle = String.Empty;
            string pszCol = String.Empty;
            string pszPob = String.Empty;
            string pszCP = String.Empty;
            string pszZP = String.Empty;
            string pszTelDom = String.Empty;
            string pszTelOfi = String.Empty;
            string pszExt = String.Empty;
            string pszSexo = String.Empty;
            string pszSubActi = String.Empty;
            string pszActi = String.Empty;
            string pszSueldo = String.Empty;
            string pszSucursal = String.Empty;
            int pszCredSol = 0;
            int pszCredAut = 0;
            string pszNomEmp = String.Empty;
            string pszCalleEmp = String.Empty;
            string pszColEmp = String.Empty;
            string pszPobEmp = String.Empty;
            string pszEdoEmp = String.Empty;
            string pszCPEmp = String.Empty;
            string pszMensaje = String.Empty;
            string pszProceso = String.Empty;
            string pszTipo = String.Empty;

            //desglosa el numero de cuenta
            string pszPrefijo = Strings.Mid(pszNoCta, 1, 4);
            string pszBanco = Strings.Mid(pszNoCta, 5, 2);
            //Código Anterior
            //  pszEmpresa = Mid$(pszNoCta, 7, 5)
            //  pszEje = Mid$(pszNoCta, 12, 3)
            //Código Anterior
            //EISSA 03.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
            string pszEmpresa = Strings.Mid(pszNoCta, 7, Formato.sMascara(Formato.iTipo.Empresa).Length);
            string pszEje = Strings.Mid(pszNoCta, 7 + Formato.sMascara(Formato.iTipo.Empresa).Length, Formato.sMascara(Formato.iTipo.Ejecutivo).Length);
            //EISSA 03.10.2001 FIN
            string pszRollOver = Strings.Mid(pszNoCta, 15, 1);
            string pszDigito = Strings.Mid(pszNoCta, 16, 1);


            //inserta en la tabla de MTCCAM01 que es la tabla de cambios masivos
            //los datos del tarjeta habiente

            this.Cursor = Cursors.WaitCursor;

            //lee el nombre de la empresa
            CORVAR.pszgblsql = "select emp_nom,emp_envio_calle,emp_envio_col, ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_envio_pob,emp_envio_edo, emp_envio_cp,emp_tipo_envio from MTCEMP01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString() +
                               " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + pszEmpresa;

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    pszCalleEmp = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    pszColEmp = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    pszPobEmp = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                    pszEdoEmp = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                    pszCPEmp = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                    pszTipo = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //obtiene los datos generales
            if (ID_MEE_FEM_OPB.Checked)
            {
                pszSexo = "F";
            }
            else
            {
                pszSexo = "M";
            }
            string pszEstatus = "Procesado";

            switch (pszParametro)
            {
                case "Nombre":
                    pszSucursal = ilSucTransmisora.ToString();
                    pszNomGra = ID_MEE_NEJ_EB.Text;
                    pszNomEmp = CORVB.NULL_STRING;
                    pszCalleEmp = CORVB.NULL_STRING;
                    pszColEmp = CORVB.NULL_STRING;
                    pszPobEmp = CORVB.NULL_STRING;
                    pszEdoEmp = CORVB.NULL_STRING;
                    pszCPEmp = "0";
                    pszProceso = "Nombre";
                    pszZP = "0";
                    pszSueldo = "0";
                    pszCP = "0";

                    break;
                case "Telefono":
                    pszNomGra = ID_MEE_NEJ_EB.Text;  //nombre del cliente 
                    pszNomEmp = CORVB.NULL_STRING;
                    pszCalle = ID_MEE_CNU_EB.Text;
                    pszCol = ID_MEE_COL_EB.Text;
                    pszPob = ID_MEE_POB_EB.Text;
                    pszCP = ID_MEE_CP_PIC.CtlText;
                    pszTelOfi = ID_MEE_TOF_PIC.CtlText;
                    pszExt = ID_MEE_EXT_PIC.CtlText;
                    pszTelDom = ID_MEE_TDO_PIC.CtlText;
                    pszNomEmp = CORVB.NULL_STRING;
                    pszCalleEmp = CORVB.NULL_STRING;
                    pszColEmp = CORVB.NULL_STRING;
                    pszPobEmp = CORVB.NULL_STRING;
                    pszEdoEmp = CORVB.NULL_STRING;
                    pszCPEmp = "0";
                    pszProceso = "DomicilioT";
                    pszZP = "0";
                    pszSueldo = "0";

                    break;
                case "Credito":
                    pszSucursal = ilSucTransmisora.ToString();
                    pszCredSol = Convert.ToInt32(Decimal.Parse(ID_MEE_LIM_FTB.defaultText, NumberStyles.Currency));
                    pszNomGra = ID_MEE_NEJ_EB.Text;  //nombre del cliente 
                    pszTelDom = ID_MEE_TDO_PIC.CtlText;
                    pszCalle = ID_MEE_CNU_EB.Text;
                    pszCol = ID_MEE_COL_EB.Text;
                    pszPob = ID_MEE_POB_EB.Text;
                    pszCP = ID_MEE_CP_PIC.CtlText;
                    pszActi = slActividad;
                    pszTelOfi = ID_MEE_TOF_PIC.CtlText;
                    pszExt = ID_MEE_EXT_PIC.CtlText;
                    pszSueldo = ID_MEE_SDO_EB.CtlText;
                    pszProceso = "Limite";
                    pszZP = "0";
                    pszSueldo = "0";

                    break;
            }

            //inserta en la tabla de cambios masivos
            CORVAR.pszgblsql = "insert " + CORBD.DB_SYS_CAM + " select  " + pszPrefijo + "," + pszBanco + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + pszEmpresa + "," + pszEje + "," + pszRollOver + "," + pszDigito + ",'" + pszNomGra + "','";
            CORVAR.pszgblsql = CORVAR.pszgblsql + pszCalle + "','" + pszCol + "','" + pszPob + "'," + ((pszZP == "") ? "0" : pszZP) + "," + ((pszCP == "") ? "0" : pszCP) + ",'" + pszTelDom + "','" + pszTelOfi + "','";
            CORVAR.pszgblsql = CORVAR.pszgblsql + pszExt + "','" + pszSexo + "','" + pszSubActi + "','" + pszActi + "'," + ((pszSueldo == "") ? "0" : pszSueldo) + ",'" + pszSucursal + "'," + pszCredSol.ToString() + "," + pszCredAut.ToString() + ",'" + pszNomEmp + "','" + pszCalleEmp + "','";
            CORVAR.pszgblsql = CORVAR.pszgblsql + pszColEmp + "','" + pszPobEmp + "','" + pszEdoEmp + "'," + pszCPEmp + ",'" + pszEstatus + "','" + pszMensaje + "','" + pszProceso + "','" + DateTime.Today.ToString("MM/dd/yyyy") + "',' ','" + Seguridad.fncsSustituir(ID_MEE_RFC_EB.defaultText.Trim(), "-", "") + "'";
            if (CORPROC2.Modifica_Registro() != 0)
            {
            }
            else
            {
                MessageBox.Show("No se inserto el registro del tarjetahabiente " + ID_MEE_NEJ_EB.Text.Trim() + " en el cambio de " + pszParametro, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }


        //UPGRADE_NOTE: (7001) The following declaration (EnvAccConexion) seems to be dead code
        //private bool EnvAccConexion()
        //{
        //envia la clave de acceso al S111 por medio del condrive
        //
        //bool result = false;
        //int liEdo = 0;
        //int llNomina = 0;
        //FixedLengthString fsNomina = new FixedLengthString(4);
        //FixedLengthString lsPassword = new FixedLengthString(8);
        //
        //string pszRepS111 = String.Empty;
        //string pszCadena = String.Empty;
        //int iPos = 0;
        //string pszMensaje = String.Empty;
        //
        ////UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
        //try
        //{
        //result = false;
        //**********************************************************************
        //this.Cursor = Cursors.Default;
        //CORMNEJE.DefInstance.Tag = "TAG_CAMBIOS_MASIVOS";
        //CORACCOM.DefInstance.ShowDialog();
        //string pszResAcc = CORACCOM.DefInstance.Tag.ToString();
        //if (pszResAcc == "Cancelar")
        //{
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("No se capturaron datos.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
        //ConComDrive.Termina_Conexion();
        //CORACCOM.DefInstance.Close();
        //return true;
        //} else
        //{
        //compacta nómina
        //fsNomina.Value = new string((char) 0, 4);
        //llNomina = Int32.Parse(CORACCOM.DefInstance.ID_ACC_NOM_TXT.Text);
        //liEdo = CORVB.iCompactaNomina(llNomina, fsNomina.Value);
        //compacta password
        //lsPassword.Value = new string((char) 255, 8);
        //liEdo = CORVB.iCompactaPasswd(CORACCOM.DefInstance.ID_ACC_CVE_TXT.Text, lsPassword.Value);
        //
        //arma la cadena para el envio
        //pszCadena = CORCONST.CVE_ACCESO_MODIFICA_S111;
        //pszCadena = pszCadena + fsNomina.Value + lsPassword.Value;
        //pszCadena = pszCadena + " " + "\r" + "\n";
        //
        //envia la cadena al S111
        //this.Cursor = Cursors.WaitCursor;
        //····· Envía mensaje al S111, para verificar la clave de usuario y el numero de nómina
        //pszRepS111 = ConComDrive.Envia_Mensaje(ref pszCadena);
        //pszMensaje = CORPROC.Muestra_Mensaje(pszRepS111);
        //iPos = (pszRepS111.IndexOf("SEG:") + 1);
        //if (iPos > CORVB.NULL_INTEGER)
        //{
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox(" " + pszMensaje, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
        //} else
        //{
        //MessageBox.Show(" " + pszMensaje + "\r" + " FIN DEL PROCESO.", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //result = true; //no se pudo conectar, y envia que falló la conexión
        //ConComDrive.Termina_Conexion();
        //this.Cursor = Cursors.Default;
        //}
        //····· Envía mensaje al S111, para verificar la clave de usuario y el numero de nómina
        //CORACCOM.DefInstance.Close();
        //}
        //}
        //catch (Exception exc)
        //{
        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //}
        //return result;
        //}

        private bool EnviaCambioS111(string pszParametro, N_ActualizaS111.ClsConectaS111 ObjConexionS111)
        {

            bool result = false;
            string pszCadena = String.Empty;
            string pszRegresaS111 = String.Empty;
            string pszCaracter = String.Empty;
            string pszNombre = String.Empty;
            string pszCalle = String.Empty;
            string pszColonia = String.Empty;
            string pszZP = String.Empty;
            string pszPoblacion = String.Empty;
            string pszTelDomi = String.Empty;
            string pszTelOfi = String.Empty;
            string pszExt = String.Empty;
            string slRFC = String.Empty;
            string pszMensaje = String.Empty;
            string pszMensajeS111 = String.Empty;
            string pszCadPaso = String.Empty;

            bool blContinue = false;

            string slRespuesta = String.Empty;
            string slBloque = String.Empty;
            string slCausaError = String.Empty;

            int ilcont = 0;
            int ilLongitudMsg = 0;
            int ilResultado = 0;
            string slDialogo = String.Empty;
            TransS111.EnumRespTransaccion enEstadoTransaccion = (TransS111.EnumRespTransaccion)0;



            int lLim_Cred_Dola = 0;
            int lLim_Cred = 0;
            mbPrimTran = false;
            StringBuilder pszNumCta = new StringBuilder();
            pszNumCta.Append(CORVB.NULL_STRING);

            for (int iPos = 1; iPos <= slCuentaBanamex.Length; iPos++)
            {
                pszCaracter = Strings.Mid(slCuentaBanamex, iPos, 1);
                if (pszCaracter != " ")
                {
                    pszNumCta.Append(pszCaracter);
                }
            }
            Application.DoEvents();
            if (pszParametro == "Nombre")
            {
                ObjConexionS111.StrIdTransaccion = CORCONST.MODIFICA_NOMBRE_EN_LINEA;
                ObjConexionS111.StrNoCuenta = pszNumCta.ToString();
                ObjConexionS111.StrParametrosAdicionales = ID_MEE_NCE_EB.Text;  //Nombre de grabación 

                pszMensaje = "Cambio de Nombre";
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Nombre";


                Application.DoEvents();


            }
            else if (pszParametro == "Credito")
            {
                //-------- EISSA 2005 - HVV ------------------------------------------------------------------- 
                ctaCuenta.productoPRD = mdlParametros.gprdProducto;
                ctaCuenta.CuentaS = pszNumCta.ToString();

                accAccion = new prySeguridadS041.clsAccion();
                accAccion.UsuarioUSU = Seguridad.usugUsuario;
                accAccion.DescripcionS = "Cambio de Límite de Crédito";
                accAccion.HabilitarB = true;
                accAccion.idAccionI = 3;
                accAccion.MakerCheckerE = prySeguridadS041.mchTiposMakerChecker.tmcMancomunado;
                //accAccion.ModuloS = "Ejecutivo" 'Descomentar en Producción 
                accAccion.OperacionI = 1;
                ctaCuenta.ActualizaLimiteCredI(accAccion, Decimal.Parse(ID_MEE_LIM_FTB.CtlText, NumberStyles.Currency), prySeguridadS041.topTipoOperMakerChecker.topMaker);

                //        .StrIdTransaccion = MODIFICA_CREDITO_EN_EJE 
                //        .strNoCuenta = pszNumCta                           'Numero de cuenta 
                //        .StrParametrosAdicionales = Str$(CCur(tgCambioLimCred.LimCredL))     'Limite de credito 
                //-------- EISSA 2005 - HVV ------------------------------------------------------------------- 
                pszMensaje = "Cambio de Línea de Crédito";
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Límite de Crédito";
                Application.DoEvents();

            }
            else if (pszParametro == "Telefono")
            {

                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Dirección";

                if (Strings.Len(ID_MEE_NCE_EB.Text) < 26)
                {
                    pszCadPaso = new String(' ', 26);
                    pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, ID_MEE_NCE_EB.Text);
                    pszNombre = pszCadPaso;
                }
                else
                {
                    pszNombre = Strings.Mid(ID_MEE_NCE_EB.Text, 1, 26);
                }
                Application.DoEvents();

                //Calle 
                if (Strings.Len(ID_MEE_CNU_EB.Text) < 35)
                {
                    pszCadPaso = new String(' ', 35);
                    pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, ID_MEE_CNU_EB.Text);
                    pszCalle = pszCadPaso;
                }
                else
                {
                    pszCalle = Strings.Mid(ID_MEE_CNU_EB.Text, 1, 35);
                }
                Application.DoEvents();

                //Colonia 
                if (Strings.Len(ID_MEE_COL_EB.Text) < 25)
                {
                    pszCadPaso = new String(' ', 25);
                    pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, ID_MEE_COL_EB.Text);
                    pszColonia = pszCadPaso;
                }
                else
                {
                    pszColonia = Strings.Mid(ID_MEE_COL_EB.Text, 1, 25);
                }
                Application.DoEvents();

                //ZP 
                if (Strings.Len(ID_MEE_ZPO_PIC.CtlText) < 2)
                {
                    pszZP = StringsHelper.Format(ID_MEE_ZPO_PIC.CtlText, "00");
                }
                else
                {
                    pszZP = Strings.Mid(ID_MEE_ZPO_PIC.CtlText, 1, 2);
                }
                Application.DoEvents();

                //Población 
                if ((ID_MEE_POB_EB.Text + " " + slEstadoEnv).Length < 25)
                {
                    pszCadPaso = new String(' ', 25);
                    pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, ID_MEE_POB_EB.Text + " " + slEstadoEnv);
                    pszPoblacion = pszCadPaso;
                }
                else
                {
                    pszPoblacion = Strings.Mid(ID_MEE_POB_EB.Text + " " + slEstadoEnv, 1, 25);
                }

                Application.DoEvents();

                //Teléfono Domicilio 
                if (ID_MEE_TDO_PIC.CtlText == CORVB.NULL_STRING)
                {
                    pszTelDomi = "0000000";
                }
                else
                {
                    pszTelDomi = ID_MEE_TDO_PIC.CtlText;
                }
                if (pszTelDomi.Length < 7)
                {
                    pszTelDomi = StringsHelper.Format(ID_MEE_TDO_PIC.CtlText, "0000000");
                }
                Application.DoEvents();

                //Tel oficina 
                if (ID_MEE_TOF_PIC.CtlText == CORVB.NULL_STRING)
                {
                    pszTelOfi = "0000000";
                }
                else
                {
                    pszTelOfi = ID_MEE_TOF_PIC.CtlText;
                }
                if (pszTelOfi.Length < 7)
                {
                    pszTelOfi = StringsHelper.Format(ID_MEE_TOF_PIC.CtlText, "0000000");
                }
                Application.DoEvents();

                //extension 
                if (Strings.Len(ID_MEE_EXT_PIC.CtlText) < 4 || (ID_MEE_EXT_PIC.CtlText) == CORVB.NULL_STRING)
                {
                    pszExt = StringsHelper.Format(ID_MEE_EXT_PIC.CtlText, "0000");
                }
                else
                {
                    pszExt = ID_MEE_EXT_PIC.CtlText;
                }
                Application.DoEvents();

                //sexo 
                if (msSexo == CORVB.NULL_STRING)
                {
                    msSexo = new String(' ', 1);
                }
                Application.DoEvents();

                slRFC = Seguridad.fncsSustituir(ID_MEE_RFC_EB.CtlText.Trim(), "-", "");
                Application.DoEvents();
                ObjConexionS111.StrIdTransaccion = CORCONST.MODIFICA_EMPRESA_MASIVOS;
                ObjConexionS111.StrNoCuenta = pszNumCta.ToString();  //Numero de cuenta 

                pszCadena = "M" + Strings.Chr(28).ToString();  //Modificación 
                pszCadena = pszCadena + pszNombre + Strings.Chr(28).ToString();  //Nombre 
                pszCadena = pszCadena + msSexo + Strings.Chr(28).ToString();  //Sexo 
                pszCadena = pszCadena + pszCalle + Strings.Chr(28).ToString();
                pszCadena = pszCadena + pszColonia + Strings.Chr(28).ToString();
                pszCadena = pszCadena + pszZP + Strings.Chr(28).ToString();
                pszCadena = pszCadena + pszPoblacion + Strings.Chr(28).ToString();
                pszCadena = pszCadena + StringsHelper.Format(ID_MEE_CP_PIC.CtlText, "00000") + Strings.Chr(28).ToString();
                pszCadena = pszCadena + pszTelDomi + Strings.Chr(28).ToString();
                pszCadena = pszCadena + pszTelOfi + Strings.Chr(28).ToString();
                pszCadena = pszCadena + pszExt + Strings.Chr(28).ToString();
                pszCadena = pszCadena + StringsHelper.Format(Strings.Mid(slActividad.Trim(), 1, 2), "00") + Strings.Chr(28).ToString();  //actividad 
                pszCadena = pszCadena + StringsHelper.Format(Strings.Mid(slSubActividad.Trim(), 1, 2), "00") + Strings.Chr(28).ToString();
                pszCadena = pszCadena + slRFC + Strings.Chr(28).ToString();  //RFC 
                pszCadena = pszCadena + " ";
                ObjConexionS111.StrParametrosAdicionales = pszCadena;
                pszMensaje = "Cambio de datos generales";
                Application.DoEvents();

            }
            else if (pszParametro == "SkipPayment")
            {

                //Mensaje que despliega el status del cambio 
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Skip Payment";

                mdlParametros.gdlgDialogo = new clsDialogo();
                mdlParametros.tgCambioS111.SkipPaymentI = ilSkipPayment;
                mdlParametros.gdlgDialogo.prGeneraDlg(null, clsDialogo.enuTipoDialogo.tCambioSkipEjecutivoS111);
                ObjConexionS111.StrIdTransaccion = mdlParametros.gdlgDialogo.mIdTransaccionS;
                ObjConexionS111.StrNoCuenta = mdlParametros.gdlgDialogo.mNumCuentaS;
                ObjConexionS111.StrParametrosAdicionales = mdlParametros.gdlgDialogo.DialogoS;
                pszMensaje = "Cambio de Skip Payment";
                Application.DoEvents();

            }
            else if (pszParametro == "MCC")
            {

                //Mensaje que despliega el status del cambio 
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de MCC";

                mdlParametros.gdlgDialogo = new clsDialogo();
                mdlParametros.tgCambioS111.MccL = Convert.ToInt32(Conversion.Val(mskMCC.CtlText));
                mdlParametros.gdlgDialogo.prGeneraDlg(null, clsDialogo.enuTipoDialogo.tCambioMCCEjecutivoS111);
                ObjConexionS111.StrIdTransaccion = mdlParametros.gdlgDialogo.mIdTransaccionS;
                ObjConexionS111.StrNoCuenta = mdlParametros.gdlgDialogo.mNumCuentaS;
                ObjConexionS111.StrParametrosAdicionales = mdlParametros.gdlgDialogo.DialogoS;
                pszMensaje = "Cambio de MCC";
                Application.DoEvents();

            }
            else if (pszParametro == "LimiteDisp")
            {

                //Mensaje que despliega el status del cambio 
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Limite de Disponible";

                mdlParametros.gdlgDialogo = new clsDialogo();
                mdlParametros.tgCambioS111.PorcentajeDispI = Convert.ToInt32(Conversion.Val(txtDisEfectivo.CtlText));
                mdlParametros.gdlgDialogo.prGeneraDlg(null, clsDialogo.enuTipoDialogo.tCambioDispEjecutivoS111);
                ObjConexionS111.StrIdTransaccion = mdlParametros.gdlgDialogo.mIdTransaccionS;
                ObjConexionS111.StrNoCuenta = mdlParametros.gdlgDialogo.mNumCuentaS;
                ObjConexionS111.StrParametrosAdicionales = mdlParametros.gdlgDialogo.DialogoS;


                pszMensaje = "Cambio de Limite de Disponible";


                Application.DoEvents();
                //        MsgBox "my debug", vbOKOnly, "d16" 

            }
            else if (pszParametro == "GenPinPla")
            {

                //Mensaje que despliega el status del cambio 
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Generación de Pin y Plastico";

                mdlParametros.gdlgDialogo = new clsDialogo();
                mdlParametros.tgCambioS111.PinPlaI = ilGenPinPlastico;
                mdlParametros.gdlgDialogo.prGeneraDlg(null, clsDialogo.enuTipoDialogo.tCambioGenPinPlaEjecutivoS111);
                ObjConexionS111.StrIdTransaccion = mdlParametros.gdlgDialogo.mIdTransaccionS;
                ObjConexionS111.StrNoCuenta = mdlParametros.gdlgDialogo.mNumCuentaS;
                ObjConexionS111.StrParametrosAdicionales = mdlParametros.gdlgDialogo.DialogoS;

                pszMensaje = "Cambio de Generación de Pin y Plastico";


                Application.DoEvents();

            }
            else if (pszParametro == "TipoBloqueo")
            {

                //Mensaje que despliega el status del cambio 
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Tipo de Bloqueo";

                mdlParametros.gdlgDialogo = new clsDialogo();
                //tgCambioS111.BloqueoI = ilGenPinPlastico 
                if (optEjecutivos[0].Checked)
                {
                    mdlParametros.tgCambioS111.BloqueoI = 0;
                }
                if (optEjecutivos[1].Checked)
                {
                    mdlParametros.tgCambioS111.BloqueoI = 1;
                }
                if (optEjecutivos[2].Checked)
                {
                    mdlParametros.tgCambioS111.BloqueoI = 2;
                }
                mdlParametros.gdlgDialogo.prGeneraDlg(null, clsDialogo.enuTipoDialogo.tCambioTipoBloqueoEjecutivoS111);

                ObjConexionS111.StrIdTransaccion = mdlParametros.gdlgDialogo.mIdTransaccionS;
                ObjConexionS111.StrNoCuenta = mdlParametros.gdlgDialogo.mNumCuentaS;
                ObjConexionS111.StrParametrosAdicionales = mdlParametros.gdlgDialogo.DialogoS;

                pszMensaje = "Cambio de Tipo de Bloqueo";

                slDialogo = pszCadena;
                Application.DoEvents();
            }

            //    If InStr(1, glstrLimCred, "linea", vbTextCompare) > 0 Then         EISSA - HVV 14.03.2005 Comentado para eliminación
            if (pszParametro == "Credito")
            {
                enEstadoTransaccion = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
            }
            else
            {
                string tempRefParam = ObjConexionS111.StrIdTransaccion;
                string tempRefParam2 = ObjConexionS111.StrNoCuenta;
                string tempRefParam3 = ObjConexionS111.StrParametrosAdicionales;
                enEstadoTransaccion = (TransS111.EnumRespTransaccion)ObjConexionS111.FnEnviarTransaccion(tempRefParam, tempRefParam2, tempRefParam3);
            }
            if (enEstadoTransaccion == TransS111.EnumRespTransaccion.EnRespTransaccionAceptada)
            {
                if (pszMensaje != "Cambio de Línea de Crédito")
                {
                    MdlCambioMasivo.MsgInfo("Transaccion Aceptada " + pszMensaje);
                }
                else
                {
                    MessageBox.Show("Se ha procesado la solicitud de cambio de Línea de Crédito.", "Maker Límite de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                blActualizo = true;
                result = false;
            }
            else if (enEstadoTransaccion == TransS111.EnumRespTransaccion.EnRespDesconocida && pszParametro == "Credito")
            {

                bool tempRefParam7 = true;
                if (ObjConexionS111.GetMsgerror(ref tempRefParam7).IndexOf("LINEA DE CREDITO ACTUALIZADA A", StringComparison.CurrentCultureIgnoreCase) >= 0)
                {

                    bool tempRefParam4 = true;
                    bool tempRefParam5 = true;
                    bool tempRefParam6 = true;
                    MdlCambioMasivo.MsgInfo(Strings.Mid(ObjConexionS111.GetMsgerror(ref tempRefParam4), ObjConexionS111.GetMsgerror(ref tempRefParam5).IndexOf("LINEA DE CREDITO ACTUALIZADA A", StringComparison.CurrentCultureIgnoreCase) + 1, ObjConexionS111.GetMsgerror(ref tempRefParam6).Length));
                    blActualizo = true;
                    result = false;
                }
            }
            else
            {
                //AIS-1146 NGONZALEZ
                bool tempBool = true;
                MdlCambioMasivo.MsgError(ObjConexionS111.GetMsgerror(ref tempBool));
                blActualizo = false;
                result = true;
            }

            this.Cursor = Cursors.WaitCursor;

            return result;
        }

        private bool ValidaCambioS111()
        {
            bool result = false;
            int intValceros = 0;
            //valida los campos que pueden ser cambiados y enviados al s111
            //por medio del comdrive


            //inicializa las variables en falso de los tipos de cambio
            msCamNomGra = CORVB.NULL_STRING;
            msCamLimCre = CORVB.NULL_STRING;
            msCamDatGen = CORVB.NULL_STRING;
            msCamDatAdi = CORVB.NULL_STRING;

            smCambioMCC = "";
            smCambioSKIP = "";
            smCambioDISP = "";
            smCambioPLA = "";
            smCambioBLOQ = "";

            if (msNomGraba != ID_MEE_NCE_EB.Text.Trim())
            {
                result = true;
                msCamNomGra = "Nombre";
            }

            if (Decimal.Parse(msLimCred, NumberStyles.Currency) != Decimal.Parse(ID_MEE_LIM_FTB.CtlText, NumberStyles.Currency))
            {
                //result = true;
                msCamLimCre = "Credito";
                mdlParametros.bgCamLimCred = true;
            }

            if ((msTelPar != ID_MEE_TDO_PIC.CtlText) || (msTelOfi != ID_MEE_TOF_PIC.CtlText))
            {
                result = true;
                msCamDatGen = "Telefono";
            }

            if ((msCalle.Trim() != ID_MEE_CNU_EB.Text.Trim()) || (msCol.Trim() != ID_MEE_COL_EB.Text.Trim()) || (msPob.Trim() != ID_MEE_POB_EB.Text.Trim()) || (msCP.Trim() != ID_MEE_CP_PIC.CtlText.Trim()) || (msExt.Trim() != ID_MEE_EXT_PIC.CtlText.Trim()) || (msZP.Trim() != ID_MEE_ZPO_PIC.CtlText.Trim()) || slEstado.Trim() != slEstadoEnv.Trim())
            {

                result = true;
                msCamDatGen = "Telefono";
            }

            if (Seguridad.fncsSustituir(msEjeRFC, "-", "").Trim() != Seguridad.fncsSustituir(ID_MEE_RFC_EB.CtlText, "-", "").Trim())
            {
                result = true;
                msCamDatGen = "RFC";
            }

            if (slRegion.Length > msRegion.Length)
            {
                intValceros = slRegion.Length - msRegion.Length;
                for (int intContceros = 1; intContceros <= intValceros; intContceros++)
                {
                    msRegion = "0" + msRegion;
                }
            }

            if ((ID_MEE_NEJ_EB.Text.Trim() != msNombre.Trim()) || (ID_MEE_RFC_EB.CtlText.Trim() != msEjeRFC.Trim()) || (ID_MEE_SDO_EB.CtlText.Trim() != msSueldo.Trim()) || (ID_MEE_NOM_PIC.CtlText.Trim() != msNoNomina.Trim()) || (slNivJerarquico.Trim() != msNivel.Trim()) || (ID_MEE_FAX_PIC.CtlText.Trim() != msEjeFax.Trim()) || (ID_MEE_FEM_OPB.Checked != msSexoF) || (ID_MEE_MAS_OPB.Checked != msSexoM) || (slRegion.Trim() != msRegion.Trim()) || (slActividad.Trim() != msActividad.Trim()))
            {
                msCamDatAdi = "DatosAdi";
                if (ID_MEE_CCO_EB.SelectedIndex == -1)
                {
                    if (ID_MEE_CCO_EB.Text.Trim() != msEjeCC.Trim())
                    {
                        msCamDatAdi = "DatosAdi";
                    }
                }
                else
                {
                    if (CRSGeneral.asgUnidades[0, ID_MEE_CCO_EB.SelectedIndex].Trim() != msEjeCC.Trim())
                    {
                        msCamDatAdi = "DatosAdi";
                    }
                }
            }

            //***** JPU *****
            if (ilTablaMCCCambio != Conversion.Val(mskMCC.CtlText))
            {
                result = true;
                smCambioMCC = "MCC";
            }

            if (ilSkipPaymentCambio != ilSkipPayment)
            {
                result = true;
                smCambioSKIP = "SkipPayment";
            }

            if (llLimDispEfectivoCambio != Conversion.Val(txtDisEfectivo.CtlText))
            {
                result = true;
                smCambioDISP = "LimiteDisp";
            }

            if (ilGenPinPlasticoCambio != ilGenPinPlastico)
            {
                result = true;
                smCambioPLA = "GenPinPla";
            }

            if (ilTipoBloqueoCambio != ilTipoBloqueo)
            {
                result = true;
                smCambioBLOQ = "TipoBloqueo";
            }
            //***** JPU *****

            return result;
        }

        /*public void  Verifica_Consulta_S111( int lNumNom)
        {
					
					
                string pszCadena1 = String.Empty;
                string pszCadena2 = String.Empty;
                string pszCadena3 = String.Empty;
                string pszNombreS111 = String.Empty;
                string pszCalleS111 = String.Empty;
                string pszColS111 = String.Empty;
                string pszCiudadS111 = String.Empty;
                //  Dim pszEntFedS111           As String
                string pszCPS111 = String.Empty;
                string pszTipCtaS111 = String.Empty;
                string pszSucS111 = String.Empty;
                string pszCorteS111 = String.Empty;
                string pszSexoS111 = String.Empty;
                string pszTeDomS111 = String.Empty;
                string pszTeOfiS111 = String.Empty;
                string pszExtS111 = String.Empty;
                string pszCausaS111 = String.Empty;
                string pszFecAltS111 = String.Empty;
                string pszFecModS111 = String.Empty;
                string pszLimCreS111 = String.Empty;
                string pszCampo = String.Empty;
					
                string folio = lNumNom.ToString(); //al folio se le asigna el númerro de nomina
                bool bDatIncorrectos = false; //asigno el valor de faslo a  la bandera de datos obtenidos
					
                pszMensajeS111 = new String(' ', 55);
                //  Mid$(pszMensajeS111, 1, 4) = "S753"                   'Sistema
                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 1, "C430"); //Sistema
                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 5, CORBD.PROCESO_CONSULTA); //clave de proceso
                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 8, "00"); //clave tipo de alta
                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 10, CORBD.TIPO_TRAMITE); //clave tipo de tramite
                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 12, StringsHelper.Format(folio, "00000000")); //numero de folio
                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 20, StringsHelper.Format(Conversion.Str(CORVB.NULL_INTEGER), "000000000000")); //numero de nomina
                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 32, CORBD.TRANSACCION_CONSULTA); //Transacción
                pszMensajeS111 = StringsHelper.MidAssignment(pszMensajeS111, 36, pszTempCuenta); //cuenta
					
                string pszConsulta = pszMensajeS111;
					
                //envia la cadena al rut
                string tempRefParam = "S753-CONALTAS";
                int iResConS111 = ConexionRut.RutReadWrite(ref pszConsulta, ref tempRefParam);
					
                string pszConS111 = pszConsulta;
					
                if (iResConS111 != CORVB.NULL_INTEGER)
                {
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("ERROR EN EL ENVIO DE LA INFORMACION ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                } else
                {
						
                    //Obtengo los datos del S111
                    pszCadena1 = Strings.Mid(pszConS111, 1243, 151).Trim();
                    pszCadena2 = Strings.Mid(pszConS111, 38, 371).Trim();
                    pszCadena3 = Strings.Mid(pszConS111, 1608, 31).Trim();
						
                    pszNombreS111 = Strings.Mid(pszCadena1, 1, 26).Trim();
                    pszCalleS111 = Strings.Mid(pszCadena1, 46, 35).Trim();
                    pszColS111 = Strings.Mid(pszCadena1, 81, 25).Trim();
                    pszCiudadS111 = Strings.Mid(pszCadena1, 106, 25).Trim();
                    //    pszEntFedS111 = Trim$(Mid(pszCadena1, 127, 4))
                    pszCPS111 = Strings.Mid(pszCadena1, 133, 5).Trim();
                    if (Strings.Mid(pszCadena1, 138, 1).Trim() == "1")
                    {
                        pszTipCtaS111 = "       Básica       ";
                    }
                    if (Strings.Mid(pszCadena1, 138, 1).Trim() == "2")
                    {
                        pszTipCtaS111 = "      Adicional     ";
                    }
                    if (Strings.Mid(pszCadena1, 138, 1).Trim() == "3")
                    {
                        pszTipCtaS111 = "Básica con Adicional";
                    }
						
                    pszSucS111 = Strings.Mid(pszCadena1, 139, 4).Trim();
                    pszCorteS111 = Strings.Mid(pszCadena1, 143, 2).Trim();
                    pszSexoS111 = Strings.Mid(pszCadena1, 145, 1).Trim();
                    pszTeDomS111 = Strings.Mid(pszCadena1, 27, 7).Trim();
                    pszTeOfiS111 = Strings.Mid(pszCadena1, 34, 7).Trim();
                    pszExtS111 = Strings.Mid(pszCadena1, 41, 4).Trim();
                    pszCausaS111 = Strings.Mid(pszCadena3, 1, 19).Trim();
                    pszFecAltS111 = Strings.Mid(pszCadena3, 20, 6).Trim();
                    pszFecModS111 = Strings.Mid(pszCadena3, 26, 6).Trim();
                    pszLimCreS111 = Strings.Mid(pszCadena2, 21, 9).Trim();
						
                    //realiza las validaciones de datos con los capturados y los obtnidos del S111
                    if (pszNombreS111 != pszEjeNomGra.Trim())
                    {
                        bDatIncorrectos = true;
                        pszCampo = "Nombre";
                    } else if (pszCalleS111 != ppszEjeCalle.Trim()) { 
                        bDatIncorrectos = true;
                        pszCampo = "Calle";
                    } else if (pszColS111 != ppszEjeCol.Trim()) { 
                        bDatIncorrectos = true;
                        pszCampo = "Colonia";
                    } else if (pszCiudadS111 != ppszEjePob.Trim()) { 
                        bDatIncorrectos = true;
                        pszCampo = "Ciudad";
                    } else if (pszTipCtaS111.Trim() != "Básica") { 
                        bDatIncorrectos = true;
                    } else if (Conversion.Val(pszSucS111) != StringsHelper.DoubleValue(iSucTran.ToString().Trim())) { 
                        bDatIncorrectos = true;
                        pszCampo = "Sucursal";
                    } else if (pszCorteS111 != iDiaCorte.ToString().Trim()) { 
                        bDatIncorrectos = true;
                        pszCampo = "Dia de corte";
                    } else if (pszSexoS111 != pszSexo.Trim()) { 
                        bDatIncorrectos = true;
                        pszCampo = "Sexo";
                    } else if (Conversion.Val(pszTeDomS111) != Conversion.Val(pszEjeTelDom.Trim())) { 
                        bDatIncorrectos = true;
                        pszCampo = "Tel. Domicilio";
                    } else if (Conversion.Val(pszTeOfiS111) != Conversion.Val(pszEjeTelOfi.Trim())) { 
                        bDatIncorrectos = true;
                        pszCampo = "Tel. Oficina.";
                    } else if (Conversion.Val(pszExtS111) != Conversion.Val(pszEjeExt)) { 
                        bDatIncorrectos = true;
                        pszCampo = "Extensión";
                    } else if (pszFecAltS111 != Strings.Mid(pszFecha, 3, 6).Trim()) { 
                        bDatIncorrectos = true;
                        pszCampo = "Fecha de alta";
                        //    ElseIf pszLimCreS111 <> Trim$(lEjeLimCred) Then
                        //      bDatIncorrectos = True
                    }
						
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox(STR_ALTA_EJE + pszTempCuenta, CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
						
                    if (! bDatIncorrectos)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Transacción Completa. ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    } else
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Transacción Completa. Hay Inconsistencia de Datos en el S111 en el campo " + pszCampo, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    }
						
                }
					
        }*/

        private object Busca_Consecutivo(int lEmpNum)
        {

            int hEjeEmp = 0;

            int iEjeNum = CORVB.NULL_INTEGER;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "SELECT emp_con_eje FROM " + DB_SYB_EMP + " WHERE gpo_banco=" + Str$(igblBanco) + " AND emp_num= " + Str$(lEmpNum)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "SELECT emp_con_eje FROM " + CORBD.DB_SYB_EMP + " WHERE eje_prefijo=" + Conversion.Str(CORVAR.igblPref) + " and gpo_banco=" + Conversion.Str(CORVAR.igblBanco) + " AND emp_num= " + Conversion.Str(lEmpNum);
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    iEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    iEjeNum--;
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return iEjeNum;

        }

        private void chkCuentaControl_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            if (chkCuentaControl.CheckState == CheckState.Unchecked)
            {
                slIndCtaControl = CRSParametros.cteNoCuentaControl;
                chkPinPlastico[0].Enabled = true;
                chkPinPlastico[1].Enabled = true;
            }
            else if (chkCuentaControl.CheckState == CheckState.Checked)
            {
                slIndCtaControl = CRSParametros.cteSiCuentaControl;
                chkPinPlastico[0].CheckState = CheckState.Unchecked;
                chkPinPlastico[0].Enabled = false;
                chkPinPlastico[1].CheckState = CheckState.Unchecked;
                chkPinPlastico[1].Enabled = false;
            }
        }

        private void chkSkipPayment_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            ilSkipPayment = (int)chkSkipPayment.CheckState;
        }

        private void CORMNEJE_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;
                try
                {
                    if (!CargaTablas)
                    {
                        return;
                    }

                    ID_MEE_TAR_FPT.SelectedIndex = 0;
                    CargaTablas = false;
                    prInicializaVariables();
                    slUsuarioCambio = CRSParametros.sgUserID;
                    slActividad = "03";
                    slRegion = "01";
                    ilSucTransmisora = 137;
                    ilSucPromotora = 137;
                    blTransmitir = "N";
                    slOrigen = "E";
                    slATM = "05";

                    slCuentaPadre = sfncCuentaPadre(CORVAR.igblPref, CORVAR.igblBanco, CORVAR.lgblEmpCve);
                    if (Conversion.Val(slCuentaPadre) == 0)
                    {
                        MessageBox.Show("No exite ninguna cuenta asociada a ésta empresa." + "\r\n" + "Por lo tanto no se pueden hacer altas de ejecutivos." +
                                        "\r\n" + "Para hacer alta de un ejecutivo, cerciorese de tener " + "\r\n" + "correctamente el alta de esta empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        bError = (false).ToString();
                        if (CORMNEJE.DefInstance.Tag.ToString() == CORCONST.TAG_ALTA)
                        {
                            chkPinPlastico[0].CheckState = CheckState.Checked;
                            chkPinPlastico[1].CheckState = CheckState.Checked;
                            bConexion = false;
                            /*ConexionRut.Termina_Conexion(); 
                            if (ConexionRut.Inicia_Conexion())
                            {
                                bConexion = true;
                            } else
                            {
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("No hay conexion al S111. Avise a sistemas.", CORVB.MB_ICONSTOP, CORSTR.STR_APP_TIT);
                            } */
                            ID_MEE_NEJ_EB.Focus();
                        }
                        else if (CORMNEJE.DefInstance.Tag.ToString() == CORCONST.TAG_CONSULTA)
                        {
                            ID_MEE_DEJ_FRM[0].Enabled = false;
                            fraDomicilio[0].Enabled = false;
                            fraDomicilio[1].Enabled = false;
                            ID_MEE_DEJ_FRM[0].Enabled = false;
                            fraDatosAdicionales[0].Enabled = false;
                            fraDatosAdicionales[1].Enabled = false;
                            fraDatosAdicionales[2].Enabled = false;
                            fraEjecutivos.Enabled = false;
                            ID_MEM_TEX_PNL[1].Enabled = false;
                            mskMCC.Enabled = false;

                        }
                        else if (CORMNEJE.DefInstance.Tag.ToString() == CORCONST.TAG_CAMBIO)
                        {
                            ID_MEE_NEJ_EB.Focus();
                            fraEjecutivos.Enabled = true;
                        }
                        else if (CORMNEJE.DefInstance.Tag.ToString() == "CAMBIO LIMITE DE CREDITO")
                        {
                            Muestra_Datos();
                            ID_MEE_LIM_FTB.CtlText = mdlParametros.tgCambioLimCred.LimCredL.ToString();

                            if (blFirma)
                            {
                                Realiza_cambio();
                            }
                            this.Close();
                            return;
                        }
                        if (CORMNEJE.DefInstance.Tag.ToString() != "TAG_CAMBIOS_MASIVOS")
                        {
                            if (!Boolean.Parse(bError))
                            {
                                Muestra_Datos();
                            }
                            else
                            {
                                //AIS-1182 NGONZALEZ
                                CORVAR.igblErr = API.USER.PostMessage(CORMNEJE.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                            }
                            ID_MEE_TAR_FPT.Visible = false;
                            ID_MEE_TAR_FPT.Visible = true;
                            double dbNumericTemp = 0;
                            ctaCuenta.LimiteCredC = StringsHelper.DecimalValue(Conversion.Str((decimal)Conversion.Val((Double.TryParse(ID_MEE_LIM_FTB.CtlText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp)) ? ID_MEE_LIM_FTB.CtlText : "0"))); //EISSA - HVV 02.03.2005
                            if (CORMNEJE.DefInstance.Tag.ToString() != CORCONST.TAG_CONSULTA)
                            {
                                ID_MEE_NEJ_EB.Focus();
                            }

                            //ID_MEM_PERSONA.ListIndex = 1    'FSWB NR 20070227 Default persona fisica '20070329 Se elimina porque no se consultaba el dato por poner default

                            this.Cursor = Cursors.Default;
                        }

                    }

                    return;
                }
                catch (Exception e)
                {
                    //Rutina de Errores de Conexión con Ruth


                    switch (Information.Err().Number)
                    {
                        //    Case 0    ' el sistema esta oK
                        default: //No hay conexion con Ruth marca cualquier error 
                            //MsgBox ("Error Núm: " + Format$(Err.Number) + Chr(13) + "Descrpción: " + Err.Description) 
                            //MsgBox "No hay conexion al S111. Avise a sistemas.", MB_ICONSTOP, STR_APP_TIT 
                            bError = (true).ToString();
                            //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead. 
                            //throw new Exception("Migration Exception: 'Resume Next' not supported");
                            CRSGeneral.prObtenError(this.GetType().Name + "(CORMNEJE_Activated)", e);
                            break;
                    }
                }
            }
        }
        private void CORMNEJE_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == CORVB.KEY_ESCAPE)
            {
                this.Close();
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            Top = (int)VB6.TwipsToPixelsY(1230);
            this.Refresh();
            this.Cursor = Cursors.WaitCursor;
            //Verifica si se oprimió el botón de Cambios o Consultas
            //Si es asi se llenan los List box con los datos seleccionados
            ctaCuenta = new clsCuenta(); //EISSA - HVV 02.03.2005
            ID_MEE_CON_FRM.Enabled = false;
            if (StringsHelper.DoubleValue(Strings.Mid(CORVAR.igblPref.ToString(), 1, 1)) == 4)
            {
                //Valida si la cuenta es de Mastercard entonces el nombre de grabacion es
                // de un máximo de 26 caracteres
                ID_MEE_NCE_EB.MaxLength = 21;
            }
            else
            {
                ID_MEE_NCE_EB.MaxLength = 26;
            }

            //Muestra fecha del día de hoy
            txtFechaAlta.Text = DateTime.Today.ToString("dd/MM/yyyy");
            blTransmitir = (true).ToString();
            CRSGeneral.prCargaEstadoEnCombo(ID_MEM_EDO_EB[0]);
            CRSGeneral.prCargaEstadoEnCombo(ID_MEM_EDO_EB[1]);
            CRSGeneral.lfncCargaUnidades(ID_MEE_CCO_EB, 0, CORVAR.lgblEmpCve);
            this.Cursor = Cursors.Default;

            blFirma = true;
            blActualizo = true;
            CargaTablas = true;
        }

        private void CORMNEJE_Closed(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            if (Conversion.Val(bError) == (0))
            { // Error de rut
                /*	if (bConexion)
                    { //Conexion del rut
                        if (ConexionRut.Termina_Conexion())
                        {
                            bConexion = false;
                        }
                    }*/
            }
            //UPGRADE_ISSUE: (2064) Threed.SSPanel property ID_COR_MEDO_PNL.FloodPercent was not upgraded.
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = 0;
            //UPGRADE_ISSUE: (2064) Threed.SSPanel property ID_COR_MEDO_PNL.Caption was not upgraded.
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = null;
            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = String.Empty;
            ctaCuenta = null; //EISSA - HVV 02.03.2005
            this.Cursor = Cursors.Default;
            MemoryHelper.ReleaseMemory();
        }


        private void ID_MEE_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            string mstrMensaje = String.Empty;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                if (CORMNEJE.DefInstance.Tag.ToString() == CORCONST.TAG_ALTA)
                {
                    mstrMensaje = "sus Altas ";
                }
                else
                {
                    mstrMensaje = "sus Cambios ";
                }

                ID_MEE_TAR_FPT.SelectedIndex = 0;

                if (MdlCambioMasivo.FnMsgYesno("Confirme " + mstrMensaje + " de ejecutivo por favor."))
                {
                    this.Cursor = Cursors.WaitCursor;
                    //Eliminar en Producción
                    //    CORMNEJE.Tag = "A"
                    if (CORMNEJE.DefInstance.Tag.ToString() == CORCONST.TAG_ALTA)
                    {
                        //EISSA 13.11.2001 Inicio Código Nuevo para generar el Top del total de ejecutivos que se pueden colocar acorde al producto y su longitud de Ejecutivos
                        //UPGRADE_WARNING: (1068) Busca_Consecutivo(Val(ID_MEE_CTA_TXT.Caption)) of type Variant is being forced to double.
                        if (Convert.ToDouble(Busca_Consecutivo(Convert.ToInt32(Conversion.Val(ID_MEE_CTA_TXT.Text)))) >= Formato.lfncTop(Formato.igLongitudEjecutivo))
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("Se deberá crear una nueva empresa para los siguientes ejecutivos." + "\r" + "Se ha llegado al límite de " + (Formato.lfncTop(Formato.igLongitudEjecutivo) + 1).ToString() + " tarjetahabientes.", CORVB.MB_ICONSTOP, CORSTR.STR_APP_TIT);
                            return;
                        }
                        iNoIntentos = 1;
                        try
                        {
                            /*   Alta_Ejecutivo();*/
                        }
                        catch { }
                    }
                    else if (CORMNEJE.DefInstance.Tag.ToString() == CORCONST.TAG_CAMBIO)
                    {
                        mdlParametros.bgCamLimCred = false;
                        try
                        {
                            Realiza_cambio();
                        }
                        catch { }
                        //Unload Me  'SE SUPRIME PARA CASO DE ERROR PODER CAPTURAR DATOS CORRECTOS.
                    }
                    this.Cursor = Cursors.Default;
                }
                ID_MEE_TAR_FPT.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEE_ALT_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }


        private void ID_MEE_CCO_EB_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
        {
            if (ID_MEE_CCO_EB.SelectedIndex >= 0)
            {
                msEjeCC = CRSGeneral.asgUnidades[0, ID_MEE_CCO_EB.SelectedIndex];
            }
            else
            {
                msEjeCC = "";
            }
        }

        private void ID_MEE_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            /*	if (bConexion)
                {
                    if (ConexionRut.Termina_Conexion())
                    {
                        bConexion = false;
                    }
                }*/
            this.Close();
            this.Cursor = Cursors.Default;
        }

        private void ID_MEE_CNU_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_CNU_EB.SelectionStart = 0;
            ID_MEE_CNU_EB.SelectionLength = Strings.Len(ID_MEE_CNU_EB.Text);
        }

        private void ID_MEE_CNU_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEE_COL_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_COL_EB.SelectionStart = 0;
            ID_MEE_COL_EB.SelectionLength = Strings.Len(ID_MEE_COL_EB.Text);
        }

        private void ID_MEE_COL_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEE_CP_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_CP_PIC.SelStart = 0;
            ID_MEE_CP_PIC.SelLength = Strings.Len(ID_MEE_CP_PIC.defaultText);
        }

        private void ID_MEE_CP_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValEntero, false, false);
        }


        private void ID_MEE_CP_PIC_Leave(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_CP_PIC.CtlText = StringsHelper.Format(ID_MEE_CP_PIC.CtlText, "00000");
        }

        private void ID_MEE_EXT_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_EXT_PIC.SelStart = 0;
            ID_MEE_EXT_PIC.SelLength = Strings.Len(ID_MEE_EXT_PIC.defaultText);
        }

        private void ID_MEE_EXT_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
        }


        private void ID_MEE_FAX_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_FAX_PIC.SelStart = 0;
            ID_MEE_FAX_PIC.SelLength = Strings.Len(ID_MEE_FAX_PIC.defaultText);
        }

        private void ID_MEE_FAX_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
        }

        private void ID_MEE_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                PrinterHelper.Printer.FontName = "Courier New";

                PrinterHelper.Printer.FontBold = true;

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print(new String(' ', 24) + Text);
                PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', Strings.Len(Text)));
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("EMPRESA                : " + ID_MEE_CTA_TXT.Text);
                PrinterHelper.Printer.Print("NOMBRE                 : " + ID_MEE_NEM_EB.Text);

                PrinterHelper.Printer.FontBold = false;
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("NOMBRE EJECUTIVO       : " + ID_MEE_NEJ_EB.Text);
                PrinterHelper.Printer.Print("RFC                    : " + ID_MEE_RFC_EB.CtlText);
                PrinterHelper.Printer.Print("SUELDO                 : " + ID_MEE_SDO_EB.CtlText);
                PrinterHelper.Printer.Print("NOMINA                 : " + ID_MEE_NOM_PIC.CtlText);
                PrinterHelper.Printer.Print("CENTRO DE COSTOS       : " + ID_MEE_CCO_EB.Text);
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("CUENTA                 : " + ID_MEJ_CTA_EB.Text);
                PrinterHelper.Printer.Print("MODIFICACION           : " + slModificacion);
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("NOMBRE GRABACION       : " + ID_MEE_NCE_EB.Text); //Crédito total asignado
                PrinterHelper.Printer.Print("CALLE Y NUMERO         : " + ID_MEE_CNU_EB.Text);
                PrinterHelper.Printer.Print("COLONIA                : " + ID_MEE_COL_EB.Text);
                PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : " + ID_MEE_POB_EB.Text); //Poblacion/delegacion
                PrinterHelper.Printer.Print("TELEFONO DOMICILIO     : " + ID_MEE_TDO_PIC.CtlText);
                PrinterHelper.Printer.Print("EXTENSION              : " + ID_MEE_EXT_PIC.CtlText);
                PrinterHelper.Printer.Print("FAX                    : " + ID_MEE_FAX_PIC.CtlText); //Telefono
                PrinterHelper.Printer.Print("TELEFONO OFICINA       : " + ID_MEE_TOF_PIC.CtlText);
                PrinterHelper.Printer.Print("C.P.                   : " + ID_MEE_CP_PIC.CtlText);
                PrinterHelper.Printer.Print("Z.P.                   : " + ID_MEE_ZPO_PIC.CtlText); //Telefono
                PrinterHelper.Printer.Print("LIMITE DE CREDITO      : " + ID_MEE_LIM_FTB.CtlText);
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("CORTE                  : " + ID_MEE_COR_PIC.CtlText);
                PrinterHelper.Printer.Print("SUCURSAL               : " + ilSucTransmisora.ToString());
                PrinterHelper.Printer.Print("REGION                 : " + slRegion);
                //Confirmar
                //UPGRADE_WARNING: (1068) slTipoCuenta of type Variant is being forced to string.
                PrinterHelper.Printer.Print("TIPO CUENTA            : " + Convert.ToString(slTipoCuenta));
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("PROCEDENCIA            : " + slOrigen);
                //Printer.Print "VENCIMIENTO            : " + ID_MEE_VEN_ITB.Text
                PrinterHelper.Printer.Print("ACTIVIDAD              : " + slActividad);
                PrinterHelper.Printer.Print("SUBACTIVIDAD           : " + slSubActividad);
                PrinterHelper.Printer.Print("ATM                    : " + slATM);
                PrinterHelper.Printer.Print("INST.ESP.              : " + slInstEspeciales);

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.EndDoc();
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEE_IMP_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_MEE_IMP_PB_Leave(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_TAR_FPT.SelectedIndex = CORVB.NULL_INTEGER;
        }

        private void ID_MEE_LIM_FTB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_LIM_FTB.SelStart = 0;
            ID_MEE_LIM_FTB.SelLength = Strings.Len(ID_MEE_LIM_FTB.CtlText);
        }

        private void ID_MEE_LIM_FTB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
            //  If (KeyAscii < 48 Or KeyAscii > 57) And KeyAscii <> KEY_BACK And KeyAscii <> 46 Then
            //    KeyAscii = 0
            //  End If
        }

        private void ID_MEE_LIM_FTB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (Conversion.Val(ID_MEE_LIM_FTB.CtlText) < 0 || Conversion.Val(ID_MEE_LIM_FTB.CtlText) > CRSParametros.cteLimiteCredito)
            {
                ID_MEE_LIM_FTB.defaultText = "0";
                MessageBox.Show("El límite de crédito debe estar entre 0 y " + StringsHelper.Format(CRSParametros.cteLimiteCredito, "###,###,###.00"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancel = true;
            }
            else
            {
                double dbNumericTemp = 0;
                if (Double.TryParse(ID_MEE_LIM_FTB.defaultText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                {
                    lEjeLimCred = Int32.Parse(ID_MEE_LIM_FTB.defaultText);
                }
                else
                {
                    lEjeLimCred = 0;
                }
            }
            eventArgs.Cancel = Cancel;
        }

        private void ID_MEE_MAS_OPB_KeyPress(ref  short KeyAscii)
        {
            if (KeyAscii == ((int)"\t"[0]))
            {
                Fichero(1);
            }
        }

        private void ID_MEE_NCE_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_NCE_EB.SelectionStart = 0;
            ID_MEE_NCE_EB.SelectionLength = Strings.Len(ID_MEE_NCE_EB.Text);
        }

        private void ID_MEE_NCE_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, ",/@");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEE_NCE_EB_Leave(Object eventSender, EventArgs eventArgs)
        {
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //UPGRADE_ISSUE: (2072) Control Tag could not be resolved because it was within the generic namespace ActiveControl.
                if (ActiveControl.Tag.ToString() != "Cancela")
                {
                    if (this.Tag.ToString() == CORCONST.TAG_ALTA || this.Tag.ToString() == CORCONST.TAG_CAMBIO)
                    {
                        //Verifica que el nombre tenga el formato
                        if (Verifica_nombre(ID_MEE_NCE_EB.Text.Trim()) == CORVB.NULL_INTEGER)
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("No se dió de alta correctamente el nombre, el formato es el siguiente: NOMBRE,APELLIDO PATERNO/APELLIDO MATERNO", CORVB.MB_ICONINFORMATION, CORSTR.STR_APP_TIT);
                            ID_MEE_NCE_EB.Focus();
                        }
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEE_NCE_EB_Leave)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_MEE_NEJ_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_NEJ_EB.SelectionStart = 0;
            ID_MEE_NEJ_EB.SelectionLength = Strings.Len(ID_MEE_NEJ_EB.Text);
        }

        private void ID_MEE_NEJ_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "@");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEE_NEM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEE_NOM_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_NOM_PIC.SelStart = 0;
            ID_MEE_NOM_PIC.SelLength = Strings.Len(ID_MEE_NOM_PIC.CtlText);
        }

        private void ID_MEE_NOM_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
        }

        private void ID_MEE_POB_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_POB_EB.SelectionStart = 0;
            ID_MEE_POB_EB.SelectionLength = Strings.Len(ID_MEE_POB_EB.Text);
        }

        private void ID_MEE_POB_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEE_RFC_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_RFC_EB.SelStart = 0;
            ID_MEE_RFC_EB.SelLength = Strings.Len(ID_MEE_RFC_EB.defaultText);
        }

        private void ID_MEE_RFC_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
        }

        private void Llena_subactividad(int iSector)
        {

            /*switch(iSector)
            {
                case 1 : 
                    slSubActividad = CORCONST.STR_SEC_IND; 
                    break;
                case 2 : 
                    slSubActividad = CORCONST.STR_SEC_CMR; 
                    break;
                case 3 : 
                    slSubActividad = CORCONST.STR_SEC_SER; 
                    break;
                case 4 : 
                    slSubActividad = CORCONST.STR_SEC_COM; 
                    break;
                case 5 : 
                    slSubActividad = CORCONST.STR_SEC_TRA; 
                    break;
                case 6 : 
                    slSubActividad = CORCONST.STR_SEC_FIN; 
                    break;
                case 7 : 
                    slSubActividad = CORCONST.STR_SEC_TNF; 
                    break;
                case 8 : 
                    slSubActividad = CORCONST.STR_SEC_OTR; 
                    break;
            }*/
            slSubActividad = CORCONST.arregloSectorEmpresa[iSector];

        }

        private void Muestra_Datos()
        {

            //Variables de procedimiento
            int iValor = 0;
            int hEjeEmp = 0;
            int iError = 0;
            int bExiste = 0;
            int iContador = 0;
            string pszTempCuenta = String.Empty;
            int iDigito = 0;

            //Variables de Campos de  la tabla
            string pszTipoEnvio = String.Empty;
            string pszEjeCalle = String.Empty;
            string pszAutoCalle = String.Empty;
            string pszEjeCol = String.Empty;
            string pszAutoCol = String.Empty;
            string pszEjePob = String.Empty;
            string pszAutoPob = String.Empty;
            string pszAutoEdo = String.Empty;
            int lEmpCredTot = 0;
            int lEmpCredAcum = 0;
            int iGpoBanco = 0;
            int lEmpNum = 0;
            int iEjeDigit = 0;
            int iEjeRoll = 0;
            string pszEjeNom = String.Empty;
            int lEjeCred = 0;
            //Dim lNumNom       As Double Cambia Yuria 25/10/06
            string sNumNom = String.Empty;
            int iSector = 0;
            string pszEjeRFC = String.Empty;
            int lEjeSueldo = 0;
            string pszEjeCC = String.Empty;
            int iEjeNivel = 0;
            string ppszEjeNomGra = String.Empty;
            int iEjeZP = 0;
            int lEjeCP = 0;
            int lAutoCP = 0;
            string pszEjeTelDom = String.Empty;
            string pszEjeTelOfi = String.Empty;
            string pszEjeExt = String.Empty;
            string pszEjeFax = String.Empty;
            int iRegNum = 0;
            string pszejeStatus = String.Empty;
            string pszCuenta = String.Empty;
            string pszTemp = String.Empty;
            string pszSexo = String.Empty;

            //variables definidas por YMF 06/09/2000
            int iEjeDigit2 = 0;
            int iEjeRoll2 = 0;

            //Variables para formateo 28-09-2001 PEMP
            int long_Emp = 0;
            int long_eje = 0;
            string num_empresa = String.Empty;
            string num_ejecutivo = String.Empty;
            string paso = String.Empty;

            int ilTipoEnvio = 0;

            string slAtencionA = String.Empty; //FSWB NR 20070222
            int ilPersona = 0; //FSWB NR 20070222


            this.Cursor = Cursors.WaitCursor;

            //***** Código Anterior     ***********
            //ID_MEE_CTA_TXT.Caption = Format$(lgblEmpCve, "00000")
            //***** Fin Código Anterior ***********
            //EISSA 03.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
            ID_MEE_CTA_TXT.Text = StringsHelper.Format(CORVAR.lgblEmpCve, Formato.sMascara(Formato.iTipo.Empresa));
            //EISSA 03.10.2001 FIN

            ID_MEE_NEM_EB.Text = CORVAR.pszgblEmpDesc.Trim();

            int iEjeNum = CORVAR.igblEjeNum;
            iEjeTempNum = iEjeNum;
            lEjeLimCred = CORVB.NULL_INTEGER;


            //obtiene el dia de corte de la base de datsos
            //pszgblsql = "select pgs_dia_corte from MTCPGS01 " se modifica 19/02/01 YMF
            //22.11.2001 Código Anterior
            //  pszgblsql = "Select pgs_dia_corte from  MTCPGS01 "
            //  pszgblsql = pszgblsql + "WHERE pgs_rep_prefijo =" + Format$(igblPref) + " and pgs_rep_banco =" + Format$(igblBanco)
            //  If Obtiene_Registros Then
            //    If SqlNextRow(hgblConexion) = MOREROWS Then
            //       iDiaCorte = Val(SqlData(hgblConexion, 1))
            //    End If
            //  End If
            //22.11.2001 Fin Código Anterior

            //EISSA 22.11.2001 Código Nuevo para extraer la fecha de corte que se hereda al ejecutivo
            iDiaCorte = Formato.lfncDiaCorte(CORVAR.igblPref, CORVAR.igblBanco, CORVAR.lgblEmpCve);
            //EISSA 22.11.2001 Fin de Código Nuevo

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            ID_MEE_COR_PIC.CtlText = iDiaCorte.ToString();

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //   pszgblsql = "select emp_tipo_envio, emp_envio_calle, emp_envio_col, emp_envio_ciu, emp_envio_edo, emp_envio_cp, emp_sector from " + DB_SYB_EMP + " where gpo_banco = " + Format$(igblBanco) + " and emp_num = " + Str$(lgblEmpCve)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //    pszgblsql = "select emp_tipo_envio, emp_envio_calle, emp_envio_col, emp_envio_ciu, emp_envio_edo, emp_envio_cp, emp_sector, emp_tipo_fac from " + DB_SYB_EMP + _
            //'               " where eje_prefijo = " + Format$(igblPref) + " and gpo_banco = " + Format$(igblBanco) + " and emp_num = " + Format$(lgblEmpCve)

            CORVAR.pszgblsql = "select emp_tipo_envio, ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_calle";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_col";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_ciu";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_edo";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_cp";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_sector";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_skip_payment";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tabla_mcc";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tipo_fac ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tipo_producto ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from " + CORBD.DB_SYB_EMP;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    pszTipoEnvio = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    //Verifica si el pago es individual o colectivo
                    if (this.Tag.ToString() == CORCONST.TAG_ALTA)
                    {
                        //Solo Muestra los datos cuando es un Alta
                        if (pszTipoEnvio == "E")
                        {
                            ID_MEE_CNU_EB.Enabled = false;
                            ID_MEE_COL_EB.Enabled = false;
                            ID_MEE_CP_PIC.Enabled = false;
                            ID_MEE_POB_EB.Enabled = false;
                            ID_MEE_ZPO_PIC.Enabled = false;
                            ID_MEM_EDO_EB[1].Enabled = false;
                        }
                        else
                        {
                            ID_MEE_CNU_EB.Enabled = true;
                            ID_MEE_COL_EB.Enabled = true;
                            ID_MEE_CP_PIC.Enabled = true;
                            ID_MEE_POB_EB.Enabled = true;
                            ID_MEE_ZPO_PIC.Enabled = true;
                            ID_MEM_PERSONA.Enabled = true; //FSWB NR 20070223 Se incluyen campos Atencion A y Persona
                            txtAtencionA.Enabled = true; //FSWB NR 20070223
                            this.ID_MEM_EDO_EB[1].Enabled = true;
                        }
                        //Sección que se evalua el tipo de envío
                        pszAutoCalle = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        pszAutoCol = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                        pszAutoPob = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                        pszAutoEdo = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                        slEstadoEnv = pszAutoEdo;
                        CRSGeneral.prBuscaEstado(ID_MEM_EDO_EB[1], pszAutoEdo);
                        lAutoCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));

                        ilTablaMCC = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 9)));
                        ilTablaMCCHeredado = ilTablaMCC;
                        mskMCC.CtlText = ilTablaMCC.ToString();

                        ilSkipPayment = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8)));
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        ilSkipPaymentHeredado = (CheckState)ilSkipPayment;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        chkSkipPayment.CheckState = (CheckState)ilSkipPayment;

                        slTipoFactura = VBSQL.SqlData(CORVAR.hgblConexion, 10);
                        chkSkipPayment.Enabled = slTipoFactura == CRSParametros.cteIndividual;
                        iSector = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7)));
                        slTipoProducto = VBSQL.SqlData(CORVAR.hgblConexion, 11);
                        if (slTipoProducto == CRSParametros.cteDistributionLine)
                        {
                            chkPinPlastico[0].Enabled = false;
                            chkPinPlastico[1].Enabled = false;
                        }
                        else
                        {
                            chkPinPlastico[0].Enabled = true;
                            chkPinPlastico[1].Enabled = false;
                        }

                        //Muestra el sector a que pertenece la empresa
                        Llena_subactividad(iSector);

                        ID_MEE_CNU_EB.Text = pszAutoCalle.Trim();
                        ID_MEE_COL_EB.Text = pszAutoCol.Trim();
                        ID_MEE_CP_PIC.CtlText = StringsHelper.Format(lAutoCP, "00000");
                        ID_MEE_POB_EB.Text = pszAutoPob.Trim() + " " + pszAutoEdo.Trim();

                        CRSGeneral.prBuscaEstado(ID_MEM_EDO_EB[1], pszAutoEdo);

                        if (ID_MEM_EDO_EB[1].Text == pszAutoEdo)
                        {
                            ID_MEM_EDO_EB[1].SelectedIndex = -1;
                        }

                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        chkSkipPayment.CheckState = (CheckState)ilSkipPayment;
                        mskMCC.CtlText = ilTablaMCC.ToString();
                        if (slTipoFactura == CRSParametros.cteIndividual)
                        {
                            ID_MEM_TFA_3OPB[1].Checked = true;
                        }
                        else if (slTipoFactura == CRSParametros.cteCorporativo)
                        {
                            ID_MEM_TFA_3OPB[0].Checked = true;
                        }
                    }
                    if (this.Tag.ToString() == CORCONST.TAG_CAMBIO && pszTipoEnvio == "E")
                    {
                        //Deshabilita los campos para capturar el cambio de domicilio
                        //de envio cuando el envio del estado de cuenta es empresarial
                        ID_MEE_CNU_EB.Enabled = false;
                        ID_MEE_COL_EB.Enabled = false;
                        ID_MEE_CP_PIC.Enabled = false;
                        ID_MEE_POB_EB.Enabled = false;
                        ID_MEE_ZPO_PIC.Enabled = false;
                        this.ID_MEM_EDO_EB[1].Enabled = false;

                    }

                    if (this.Tag.ToString() == CORCONST.TAG_CONSULTA)
                    {
                        ID_MEE_CNU_EB.Enabled = false;
                        ID_MEE_COL_EB.Enabled = false;
                        ID_MEE_CP_PIC.Enabled = false;
                        ID_MEE_POB_EB.Enabled = false;
                        ID_MEE_ZPO_PIC.Enabled = false;
                        ID_MEM_PERSONA.Enabled = false; //FSWB NR 20070223
                        txtAtencionA.Enabled = false; //FSWB NR 20070223
                        this.ID_MEM_EDO_EB[1].Enabled = false;


                    }
                }
            }


            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (this.Tag.ToString() == CORCONST.TAG_ALTA)
            {
                //me.ID_MEE_ETT_TXT( 9).Visible = False
            }
            else if (this.Tag.ToString() == CORCONST.TAG_CAMBIO)
            {


            }

            if (CORMNEJE.DefInstance.Tag.ToString() == CORCONST.TAG_CAMBIO || CORMNEJE.DefInstance.Tag.ToString() == CORCONST.TAG_CONSULTA || CORMNEJE.DefInstance.Tag.ToString() == "CAMBIO LIMITE DE CREDITO")
            {

                //***** Código Anterior     ***********
                //    'cambio generado por YMF el 06/09/2000 para corregir
                //    'el problema de cuando cambia el rollover
                //    'puedan actualizar en el S111 con el último número de cuenta
                //    'tomado de la tabla MTCTHS01
                //    iEjeRoll2 = 0
                //    iEjeDigit2 = 0
                //    pszgblsql = "select eje_roll_over,eje_digit from MTCTHS01 where eje_prefijo = " + Format$(igblPref) + " and gpo_banco = " + Format$(igblBanco) + " and emp_num = " + Str$(lgblEmpCve) + " and eje_num = " + Str$(igblEjeNum)
                //    If Obtiene_Registros Then
                //       If SqlNextRow(hgblConexion) = MOREROWS Then
                //        iEjeRoll2 = Val(SqlData(hgblConexion, 1))
                //        iEjeDigit2 = Val(SqlData(hgblConexion, 2))
                //       End If
                //    End If
                //    igblRetorna = SqlCancel(hgblConexion)
                //    'termina cambio de YMF
                //***** Fin Código Anterior ***********


                //***** INICIO CODIGO ANTERIRO FSWBMX *****
                //   pszgblsql = "select * from " + DB_SYB_EJE + " where gpo_banco = " + Format$(igblBanco) + " and eje_num = " + Str$(igblEjeNum) + " and emp_num = " + Str$(lgblEmpCve)
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //Código Anterior
                //  '***** INICIO CODIGO NUEVO FSWBMX *****
                //      pszgblsql = "select * from " + DB_SYB_EJE + " where eje_prefijo = " + Format$(igblPref) + " and gpo_banco = " + Format$(igblBanco) + " and eje_num = " + Str$(igblEjeNum) + " and emp_num = " + Str$(lgblEmpCve)
                //  '***** FIN DE CODIGO NUEVO FSWBMX *****
                //Fin de Código Anterior

                //EISSA 05.10.2001 Query para extraer todos los datos del tarjetahabiente, haciendo una búsqueda en EJE y
                //                 en caso de no encontrar información en MTCEJE01 buscamos en la tabla de MTCTHS01
                CORVAR.pszgblsql = "sp_InfoEjecutivo " + CORVAR.igblPref.ToString() + ", " + CORVAR.igblBanco.ToString() + ", " + CORVAR.lgblEmpCve.ToString() + ", " + CORVAR.igblEjeNum.ToString();
                //EISSA 05.10.2001 Fin de Código nuevo

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    //Obteiene Registro para consulta
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        iEjePref = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        iGpoBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                        lEmpNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                        CORVAR.igblEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4)));
                        iEjeRoll = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5)));
                        iEjeDigit = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 6)));
                        pszEjeNom = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                        pszEjeRFC = VBSQL.SqlData(CORVAR.hgblConexion, 8);
                        lEjeSueldo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 9)));
                        //lNumNom = Val(SqlData(hgblConexion, 10)) modifica Yuria 25/10/06
                        sNumNom = VBSQL.SqlData(CORVAR.hgblConexion, 10).Trim();
                        pszEjeCC = VBSQL.SqlData(CORVAR.hgblConexion, 11);
                        iEjeNivel = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 12)));
                        ppszEjeNomGra = VBSQL.SqlData(CORVAR.hgblConexion, 13);
                        pszEjeCalle = VBSQL.SqlData(CORVAR.hgblConexion, 14);
                        pszEjeCol = VBSQL.SqlData(CORVAR.hgblConexion, 15);
                        pszEjePob = VBSQL.SqlData(CORVAR.hgblConexion, 16);
                        iEjeZP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 17)));
                        lEjeCP = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 18)));
                        pszEjeTelDom = VBSQL.SqlData(CORVAR.hgblConexion, 19);
                        pszEjeTelOfi = VBSQL.SqlData(CORVAR.hgblConexion, 20);
                        pszEjeExt = VBSQL.SqlData(CORVAR.hgblConexion, 21);
                        pszEjeFax = VBSQL.SqlData(CORVAR.hgblConexion, 22);
                        lEjeLimCred = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 23)));
                        iRegNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 24)));
                        msRegion = iRegNum.ToString();
                        pszejeStatus = VBSQL.SqlData(CORVAR.hgblConexion, 25);
                        pszSexo = VBSQL.SqlData(CORVAR.hgblConexion, 27);

                        //Campos Adicionales
                        // no se están vaciando los datos eje_suc_trans28,eje_suc_prom29,eje_origen30
                        // aunque si los regresa el sp_InfoEjecutivo. Al realizar el cambio, le está poniendo valores fijos:
                        //eje_suc_trans=137,eje_suc_prom=137,eje_origen='E'
                        slSubActividad = VBSQL.SqlData(CORVAR.hgblConexion, 31).Trim();
                        slDomCalle = VBSQL.SqlData(CORVAR.hgblConexion, 32);
                        ID_MEM_DOM_EB[0].Text = slDomCalle;

                        slDomColonia = VBSQL.SqlData(CORVAR.hgblConexion, 33);
                        ID_MEM_COL_EB[0].Text = slDomColonia;

                        slDomCiudad = VBSQL.SqlData(CORVAR.hgblConexion, 34);
                        ID_MEM_CIU_EB[0].Text = slDomCiudad;

                        slDomPoblacion = VBSQL.SqlData(CORVAR.hgblConexion, 35);
                        ID_MEM_PDM_EB[0].Text = slDomPoblacion;

                        slDomEstado = VBSQL.SqlData(CORVAR.hgblConexion, 36);
                        CRSGeneral.prBuscaEstado(ID_MEM_EDO_EB[0], slDomEstado);

                        llDomCodigoPostal = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 37));
                        ID_MEM_CP_PIC[0].defaultText = llDomCodigoPostal.ToString();

                        slEMail = VBSQL.SqlData(CORVAR.hgblConexion, 38);
                        txtMail.Text = slEMail;

                        slCtaContable = VBSQL.SqlData(CORVAR.hgblConexion, 39);
                        txtCContable.Text = slCtaContable;

                        ilGenPinPlastico = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 40));
                        ilGenPinPlasticoCambio = ilGenPinPlastico;
                        prCfgPinPlastico(ilGenPinPlastico);

                        llLimDispEfectivo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 41));
                        llLimDispEfectivoCambio = llLimDispEfectivo;
                        txtDisEfectivo.defaultText = llLimDispEfectivo.ToString();

                        llFechaAlta = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 43));
                        txtFechaAlta.Text = Strings.Mid(llFechaAlta.ToString(), 7, 2) + "/" + Strings.Mid(llFechaAlta.ToString(), 5, 2) + "/" + Strings.Mid(llFechaAlta.ToString(), 1, 4);

                        //slTipoCuenta = SqlData(hgblConexion, 46)
                        //prCfgTipoCuenta slTipoCuenta

                        slCuentaAMostrar = VBSQL.SqlData(CORVAR.hgblConexion, 47).Trim();
                        if (slCuentaAMostrar.Length != 16)
                        {
                            slCuentaAMostrar = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), "0000") + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 2), "00") + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 3), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 4), Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 5), "0") + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 6), "0");
                        }
                        slCuentaBanamex = StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 1), "0000") + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 2), "00") + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 3), Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 4), Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 5), "0") + StringsHelper.Format(VBSQL.SqlData(CORVAR.hgblConexion, 6), "0");
                        ID_MEJ_CTA_EB.Text = slCuentaAMostrar;

                        //Numero de Cuenta para la transaccion 5368
                        mdlParametros.tgCambioS111.NumCuentaS = slCuentaAMostrar;

                        slTipoFactura = VBSQL.SqlData(CORVAR.hgblConexion, 48);
                        if (slTipoFactura == CRSParametros.cteCorporativo)
                        {
                            ID_MEM_TFA_3OPB[0].Checked = true;
                            chkSkipPayment.Enabled = false;
                        }
                        else if (slTipoFactura == CRSParametros.cteIndividual)
                        {
                            ID_MEM_TFA_3OPB[1].Checked = true;
                        }

                        //Skip Payment
                        ilSkipPayment = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 49));
                        ilSkipPaymentCambio = ilSkipPayment;
                        //UPGRADE_WARNING: (6021) Casting 'double' to Enum may cause different behaviour.
                        chkSkipPayment.CheckState = (CheckState)Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 49)));

                        //Tabla de MCC
                        ilTablaMCC = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 50));
                        ilTablaMCCCambio = ilTablaMCC;
                        //mskMCC = ilTablaMCC comenta yuria 16/11/06
                        mskMCC.CtlText = ilTablaMCC.ToString();
                        //Estado
                        slEstado = VBSQL.SqlData(CORVAR.hgblConexion, 51);
                        CRSGeneral.prBuscaEstado(ID_MEM_EDO_EB[1], slEstado);

                        //Nacionalidad
                        slNacionalidad = VBSQL.SqlData(CORVAR.hgblConexion, 53);
                        if (slNacionalidad == CRSParametros.cteMexicana)
                        {
                            optNacionalidad[0].Checked = true;
                        }
                        else if (slNacionalidad == CRSParametros.cteExtranjera)
                        {
                            optNacionalidad[0].Checked = true;
                        }

                        //Indicador de Cuenta de Control
                        slIndCtaControl = VBSQL.SqlData(CORVAR.hgblConexion, 52);
                        prCfgCtaCtrl(slIndCtaControl);

                        if (slIndCtaControl == CRSParametros.cteSiCuentaControl)
                        {
                            ID_MEM_TFA_3OPB[0].Checked = true;
                        }
                        else if (slIndCtaControl == CRSParametros.cteNoCuentaControl)
                        {
                            ID_MEM_TFA_3OPB[1].Checked = true;
                        }

                        //Tipo de Bloqueo
                        ilTipoEnvio = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 54));
                        ilTipoBloqueoCambio = ilTipoEnvio;
                        if (ilTipoEnvio == 0)
                        {
                            optEjecutivos[0].Checked = true;
                        }
                        else if (ilTipoEnvio == 1)
                        {
                            optEjecutivos[1].Checked = true;
                        }
                        else if (ilTipoEnvio == 2)
                        {
                            optEjecutivos[2].Checked = true;
                        }

                        //**** INICIO FSWB NR 20070222 Despliega valores para AtencionA y Persona

                        //Atencion A
                        slAtencionA = VBSQL.SqlData(CORVAR.hgblConexion, 56).Trim(); //NR 29032007
                        txtAtencionA.Text = slAtencionA;

                        //Persona
                        ilPersona = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 57));

                        if (ilPersona == 1)
                        { //And (ID_MEM_PERSONA.ListIndex <> -1) Then '20070329
                            ID_MEM_PERSONA.SelectedIndex = 0;
                        }
                        else if (ilPersona == 2)
                        {
                            ID_MEM_PERSONA.SelectedIndex = 1;
                        }
                        else if (ilPersona == 3)
                        {
                            ID_MEM_PERSONA.SelectedIndex = 2;
                        }

                        //**** FIN FSWB NR 20070222

                        //EISSA 05.10.2001 Se incluyó el siguiente código dentro de la sentencia SQL anterior
                        //'Código Anterior - Ya no es necesario buscar por separado el Rollover y el digito ver
                        //        'código YMF generado el 06/09/2000
                        //        If iEjeRoll2 <> 0 And iEjeDigit2 <> 0 Then
                        //            iEjeRoll = iEjeRoll2
                        //            iEjeDigit = iEjeDigit2
                        //        End If
                        //Código Anterior
                        //Muestra datos del Ejecutivo
                        ID_MEE_NEJ_EB.Text = pszEjeNom.Trim(); //Nombre de Ejecutivo
                        msNombre = ID_MEE_NEJ_EB.Text;

                        ID_MEE_RFC_EB.SelText = StringsHelper.Format(pszEjeRFC, "AAAA-######-&&&");
                        msEjeRFC = ID_MEE_RFC_EB.CtlText;

                        slConsecutivo = StringsHelper.Format(CORVAR.igblEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo));

                        ID_MEE_SDO_EB.CtlText = lEjeSueldo.ToString();
                        msSueldo = ID_MEE_SDO_EB.CtlText;

                        //ID_MEE_NOM_PIC.Text = Format$(lNumNom, "0000000") 'Numero de Nomina Modifica Yuria 25/10/06
                        ID_MEE_NOM_PIC.CtlText = sNumNom.Trim(); //Numero de Nomina
                        msNoNomina = ID_MEE_NOM_PIC.CtlText;

                        CRSGeneral.prBuscaUnidad(ID_MEE_CCO_EB, pszEjeCC.Trim()); //Centro de Costos
                        if (ID_MEE_CCO_EB.SelectedIndex != -1)
                        {
                            msEjeCC = CRSGeneral.asgUnidades[0, ID_MEE_CCO_EB.SelectedIndex];
                        }
                        else
                        {
                            msEjeCC = pszEjeCC.Trim();
                            ID_MEE_CCO_EB.Text = msEjeCC;
                        }

                        slNivJerarquico = StringsHelper.Format(iEjeNivel, "0"); //Nivel Jerárquico
                        msNivel = slNivJerarquico;

                        ID_MEE_NCE_EB.Text = ppszEjeNomGra.Trim(); //Nombre para grabación
                        msNomGraba = ppszEjeNomGra.Trim();

                        ID_MEE_CNU_EB.Text = pszEjeCalle.Trim(); //Calle
                        msCalle = ID_MEE_CNU_EB.Text;

                        ID_MEE_COL_EB.Text = pszEjeCol.Trim(); //Colonia
                        msCol = ID_MEE_COL_EB.Text;

                        ID_MEE_CP_PIC.CtlText = StringsHelper.Format(lEjeCP, "00000"); //Código Postal
                        msCP = ID_MEE_CP_PIC.CtlText;

                        ID_MEE_POB_EB.Text = pszEjePob.Trim(); //Población
                        msPob = ID_MEE_POB_EB.Text;

                        ID_MEE_ZPO_PIC.CtlText = StringsHelper.Format(iEjeZP, "00"); //Zona Postal
                        msZP = ID_MEE_ZPO_PIC.CtlText;

                        ID_MEE_TDO_PIC.CtlText = pszEjeTelDom.Trim(); //Teléfono de Domicilio
                        msTelPar = ID_MEE_TDO_PIC.CtlText;

                        ID_MEE_TOF_PIC.CtlText = pszEjeTelOfi.Trim(); //Teléfono de Oficina
                        msTelOfi = ID_MEE_TOF_PIC.CtlText;

                        ID_MEE_EXT_PIC.CtlText = pszEjeExt.Trim(); //Extensión
                        msExt = ID_MEE_EXT_PIC.CtlText;

                        ID_MEE_FAX_PIC.CtlText = pszEjeFax.Trim(); //Fax
                        msEjeFax = ID_MEE_FAX_PIC.CtlText;

                        ID_MEE_LIM_FTB.CtlText = lEjeLimCred.ToString(); //Límite de Crédito
                        msLimCred = ID_MEE_LIM_FTB.CtlText;

                        msSubAct = slSubActividad;
                        slRegion = iRegNum.ToString(); //Número de División Regional

                        if (pszSexo == "F")
                        {
                            ID_MEE_FEM_OPB.Checked = true;
                            msSexoF = true;
                            msSexoM = false;
                        }
                        else
                        {
                            ID_MEE_MAS_OPB.Checked = true;
                            msSexoF = false;
                            msSexoM = true;
                        }
                        msActividad = slActividad;
                    }

                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }

            //Comentado por EISSA - Código Anterior
            //  ID_MEE_COR_PIC.Text = Busca_Dia_Corte()
            //Fin Comentado por EISSA - Código Anterior
            //EISSA - Inicio Código Nuevo
            ID_MEE_COR_PIC.CtlText = StringsHelper.Format(iDiaCorte, "00");
            //EISSA - Fin de Código Nuevo
            if (this.Tag.ToString() == CORCONST.TAG_ALTA)
            {
                slModificacion = "N";
            }
            else if (this.Tag.ToString() == CORCONST.TAG_CAMBIO)
            {
                slModificacion = "S";
                //ID_MEJ_CTA_EB.Text = NULL_STRING 
                if (pszejeStatus == "N")
                {
                    blTransmitir = (true).ToString();
                }
                else
                {
                    blTransmitir = (false).ToString();
                }

            }
            else if (this.Tag.ToString() == "CAMBIO LIMITE DE CREDITO")
            {
                slModificacion = "S";
                //ID_MEJ_CTA_EB.Text = NULL_STRING 
                if (pszejeStatus == "N")
                {
                    blTransmitir = (true).ToString();
                }
                else
                {
                    blTransmitir = (false).ToString();
                }

                //***** Código Anterior     *********** 
                //    pszTempCuenta = Format$(iEjePref, "0000") + Format$(igblBanco, "00") + Format(lEmpNum, "00000") + Format(igblEjeNum, "000") + Format(iEjeRoll, "0") + Format(iEjeDigit, "0") 
                //***** Fin Código Anterior *********** 
                //EISSA 03.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo 
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior. 
                if (String.IsNullOrEmpty(slCuentaAMostrar.Trim()))
                {
                    pszTempCuenta = StringsHelper.Format(iEjePref, "0000") + StringsHelper.Format(CORVAR.igblBanco, "00") + StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(CORVAR.igblEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iEjeRoll, "0") + StringsHelper.Format(iEjeDigit, "0");
                }
                else
                {
                    pszTempCuenta = slCuentaAMostrar;
                }
                //EISSA 03.10.2001 FIN 
                pszCuenta = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 9, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 13, 4);
                ID_MEJ_CTA_EB.Text = pszCuenta;

            }
            else if (this.Tag.ToString() == CORCONST.TAG_CONSULTA)
            {
                //Calcula cuenta con formato 
                slModificacion = "N";

                //***** Código Anterior     *********** 
                //    pszTempCuenta = Format$(iEjePref, "0000") + Format$(igblBanco, "00") + Format(lEmpNum, "00000") + Format(igblEjeNum, "000") + Format(iEjeRoll, "0") + Format(iEjeDigit, "0") 
                //***** Fin Código Anterior *********** 
                //EISSA 03.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo 
                if (slCuentaAMostrar.Trim() == "" && slCuentaAMostrar.Trim().Length != 16)
                {
                    pszTempCuenta = StringsHelper.Format(iEjePref, "0000") + StringsHelper.Format(CORVAR.igblBanco, "00") + StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(CORVAR.igblEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(iEjeRoll, "0") + StringsHelper.Format(iEjeDigit, "0");
                }
                else
                {
                    pszTempCuenta = slCuentaAMostrar;
                }

                //EISSA 03.10.2001 FIN 
                pszCuenta = Strings.Mid(pszTempCuenta, 1, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 5, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 9, 4) + new String(' ', 1) + Strings.Mid(pszTempCuenta, 13, 4);
                ID_MEJ_CTA_EB.Text = pszCuenta;

                if (pszejeStatus == "N")
                {
                    blTransmitir = (true).ToString();
                }
                else
                {
                    blTransmitir = (false).ToString();
                }
                //ID_MEE_TRA_CKB.Enabled = False 
            }

            //de alta los datos dentro de la tabla de Ejecutivos Banamex
            CORVAR.pszgblsql = "select con_pref from " + CORBD.DB_SYB_CON + " where con_banco = " + StringsHelper.Format(CORVAR.igblBanco, "00");
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                //ros    If qeFetchNext(hEjeEmp) = NULL_INTEGER Then
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    iEjePref = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                }

            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_MEE_NEJ_EB.Enabled)
            {
                ID_MEE_NEJ_EB.Focus();
            }

            this.Cursor = Cursors.Default;

        }

        private void Realiza_cambio()
        {

            //Variables de procedimiento
            int hEjeEmp = 0;
            int iError = 0;
            int iValor = 0;

            //Variables de Campos de  la tabla
            string pszEjeCalle = String.Empty;
            string pszEjeCol = String.Empty;
            string pszEjePob = String.Empty;
            int lEmpCredAcum = 0;
            int iEjeDigit = 0;
            int iEjeNum = 0;
            int lEjeCred = 0;
            //Dim lNumNom As Long
            string pszEjeCC = String.Empty;
            //Dim ppszEjeCalle As String comenta yuria 25/10/06 ya existe una declaración arriba
            //Dim ppszEjeCol As String comenta yuria 25/10/06 ya existe una declaración arriba
            //Dim pszEjePob As String comenta yuria 26/10/06 indica error de compilación porque está duplicada la definicion
            string pszejeStatus = String.Empty;
            int iEmp_num = 0;
            int pszCred = 0;
            int iDiaCorte = 0;
            string pszSexo = String.Empty;
            string pszCadena = String.Empty;
            string pszResAcc = String.Empty;
            string pszRegresaS111 = String.Empty;
            string pszExiste = String.Empty;

            //Se incluyeron 2 campos Atencion A y Persona

            int lID = 0;

            int llValAnt = 0;
            int llValPost = 0;
            int llCta = 0;

            bool respuesta = false;

            //***** JPU *****
            //Variables para validar el limite de credito
            int llTotalAcumulado = 0;
            int llTotalCredito = 0;


            //ObjConexionS111


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                mbPrimTran = false;

                this.Cursor = Cursors.WaitCursor;

                mbActualizaM111 = false;
                string pszCampo = String.Empty;
                int lEmpNum = 0;
                string pszEjeNom = String.Empty;
                string pszEjeRFC = String.Empty;
                string sNumNom = String.Empty;
                int lEjeSueldo = 0;
                try
                {
                    pszCampo = Valida_Campos();
                }
                catch { }

                if (pszCampo.Length != 0)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Falta por capturar el campo: " + pszCampo, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    return;
                }

                int lEmpCredTot = CORVB.NULL_INTEGER;

                this.Cursor = Cursors.WaitCursor;

                int iGpoBanco = CORVAR.igblBanco; //gpo_banco
                try
                {
                    lEmpNum = Convert.ToInt32(Conversion.Val(ID_MEE_CTA_TXT.Text)); //emp_num
                }
                catch { }
                int iEjeRoll = 9; //eje_roll_over
                try
                {
                    pszEjeNom = ID_MEE_NEJ_EB.Text.Trim(); //eje_nom
                }
                catch { }
                try
                {
                    pszEjeRFC = Seguridad.fncsSustituir(ID_MEE_RFC_EB.CtlText.Trim(), "-", ""); //RFC
                }
                catch { }
                //lNumNom = Val(ID_MEE_NOM_PIC.Text) comenta yuria                                 'eje_num_nom
                try
                {
                    sNumNom = ID_MEE_NOM_PIC.CtlText; //agrega yuria 12/10/06 para que número de nómina sea alfanumérico //eje_num_nom
                }
                catch { }
                try
                {
                    lEjeSueldo = Convert.ToInt32(Conversion.Val(ID_MEE_SDO_EB.CtlText)); //eje_sueldo
                }
                catch { }

                if (ID_MEE_CCO_EB.SelectedIndex >= 0)
                {
                    try
                    {
                        pszEjeCC = CRSGeneral.asgUnidades[0, ID_MEE_CCO_EB.SelectedIndex].Trim(); //eje_centro_c
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        pszEjeCC = ID_MEE_CCO_EB.Text.Trim();
                    }
                    catch { }
                }

                int iEjeNivel = Convert.ToInt32(Conversion.Val(slNivJerarquico)); //Nijel Jerárquico
                string pszEjeNomGra = ID_MEE_NCE_EB.Text.Trim(); //Nombre para grabación
                ppszEjeCalle = ID_MEE_CNU_EB.Text.Trim(); //Calle
                ppszEjeCol = ID_MEE_COL_EB.Text.Trim(); //Colonia
                int lEjeCP = Convert.ToInt32(Conversion.Val(ID_MEE_CP_PIC.CtlText)); //Código Postal
                ppszEjePob = ID_MEE_POB_EB.Text.Trim(); //Población
                int iEjeZP = Convert.ToInt32(Conversion.Val(ID_MEE_ZPO_PIC.CtlText)); //Zona Postal
                string pszEjeTelDom = ID_MEE_TDO_PIC.CtlText.Trim(); //Teléfono de Domicilio
                string pszEjeTelOfi = ID_MEE_TOF_PIC.CtlText.Trim(); //Teléfono de Oficina
                string pszEjeExt = ID_MEE_EXT_PIC.CtlText.Trim(); //Extensión
                string pszEjeFax = ID_MEE_FAX_PIC.CtlText.Trim(); //Fax
                int lNvoLimCred = Convert.ToInt32(Conversion.Val(ID_MEE_LIM_FTB.CtlText)); //Límite de Crédito
                int iRegNum = Convert.ToInt32(Conversion.Val(slRegion)); //Número de División Regional
                int iSucTran = ilSucTransmisora; //sucursal transmisora
                int iSucProm = ilSucPromotora; //sucursal promotora
                string pszOrigen = slOrigen; //Origen
                string pszActSubAct = Strings.Mid(slSubActividad, 1, 2); //Acti_subacti
                string pszAtencionA = txtAtencionA.Text; //FSWB NR 20070221 //FSWB NR 20070221                   'Atencion A
                string pszPersona = Strings.Mid(ID_MEM_PERSONA.Text, 1, 1); //FSWB NR 20070221 //FSWB NR 20070221                'Persona

                if (ID_MEE_FEM_OPB.Checked)
                { //Sexo
                    pszSexo = "F";
                }
                else
                {
                    pszSexo = "M";
                }

                if (Boolean.Parse(blTransmitir))
                {
                    pszejeStatus = "N";
                }
                else
                {
                    pszejeStatus = "T";
                }

                if (CORMNEJE.DefInstance.Tag.ToString() != "CAMBIO LIMITE DE CREDITO")
                {
                    try
                    {
                        String str = String.Empty;
                        int index = 0;
                        try
                        {
                            str = VB6.GetItemString(CORCTEJE.DefInstance.ID_CEE_EMP_LB, Artinsoft.VB6.Gui.ListBoxHelper.GetSelectedIndex(CORCTEJE.DefInstance.ID_CEE_EMP_LB));
                        }
                        catch
                        {
                            str = String.Empty;
                        }
                        try
                        {
                            index = ListBoxHelper.GetSelectedIndex(CORCTEJE.DefInstance.ID_CEE_EMP_LB);
                        }
                        catch
                        {
                            index = 0;
                        }
                        VB6.SetItemString(CORCTEJE.DefInstance.ID_CEE_EMP_LB, index, Microsoft.VisualBasic.Strings.Mid(str, 1, 6) + ID_MEE_NEJ_EB.Text.Trim());
                    }
                    catch { }
                }
                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_pago,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cred_tot,";
                //pszgblsql = pszgblsql & " emp_acum_cred"
                //    pszgblsql = pszgblsql & "(select isnull(sum(eje_limcred),0) from  MTCEJE01"
                //    pszgblsql = pszgblsql & " where MTCEJE01.eje_prefijo = MTCEMP01.eje_prefijo"
                //    pszgblsql = pszgblsql & " and MTCEJE01.gpo_banco = MTCEMP01.gpo_banco"
                //    pszgblsql = pszgblsql & " and MTCEJE01.emp_num = MTCEMP01.emp_num"
                //    pszgblsql = pszgblsql & " and MTCEJE01.eje_num > 0) as emp_acum_cred"
                // Modif. 18/Jun/2007 Calc Lim Real
                CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = MTCEMP01.eje_prefijo ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = MTCEMP01.gpo_banco ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = MTCEMP01.emp_num ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c,MTCTHS01 d ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = MTCEMP01.eje_prefijo ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = MTCEMP01.gpo_banco ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = MTCEMP01.emp_num ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) as emp_acum_cred ";
                //    pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred "

                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(lEmpNum);

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        lEmpCredTot = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                        lEmpCredAcum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                    }
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                //Verifica si se ingresó la descripción
                if (ID_MEE_NEJ_EB.Text.Trim() != CORVB.NULL_STRING)
                {
                    //Verifica que no se sobrepase el crédito de la empresa
                    //Eliminar una vez que se establesca una regla

                    //        If bfncExcepcionCredito = True Then GoTo OmiteValidacionLimiteCredito4

                    //*** JPU ***
                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_limcred";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + Conversion.Str(lEmpNum);
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = " + CORVAR.igblEjeNum.ToString();

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            lEjeLimCred = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                        }
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    llTotalAcumulado = lEmpCredAcum - lEjeLimCred;
                    llTotalCredito = lEmpCredTot - llTotalAcumulado;

                    //        If lNvoLimCred > llTotalCredito Then
                    //       28/Jun/2007 Acepta cualquier disminución de crédito
                    if ((lNvoLimCred > llTotalCredito) && (lNvoLimCred > lEjeLimCred))
                    {
                        this.Cursor = Cursors.Default;
                        //            pszCred = lEmpCredTot - lEmpCredAcum + lEjeLimCred
                        pszCred = lEmpCredTot - lEmpCredAcum;
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Se ha sobrepasado el crédito de la Empresa." + "\n" + "Crédito disponible: " + StringsHelper.Format(pszCred, "Currency"), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                    }
                    else
                    {



                        //***** Pasada Conexión al S111 *****
                        //            If ValidaCambioS111 = True Then
                        //                pszExiste = Dir$(pszgblPathComDrive)
                        //                If pszExiste <> NULL_STRING Then                                'Si existe el archivo
                        //                    lID = Shell(pszgblPathComDrive, vbMinimizedNoFocus)         'Carga el condrive
                        //                Else
                        //                    MsgBox "No existe el archivo: " & pszgblPathComDrive
                        //                    Exit Sub
                        //                End If
                        //                'Realiza la conexión al s111 por medio del comdrive
                        //                ConComDrive.Tiempo = 15
                        //
                        //                If ConComDrive.Inicia_Conexion = False Then                     'Si no existe conexión al S111 envia mensaj y sale de la función
                        //                    MsgBox "No hay conexión al S111, intente mas tarde. " + pszCampo, vbCritical, STR_APP_TIT
                        //                    Exit Sub
                        //                Else
                        //                    DoEvents
                        //                    If (EnvAccConexion = True) Then
                        //                        Exit Sub
                        //                    End If
                        //                End If
                        //            End If
                        //***** Pasada Conexión al S111 *****

                        //***** Nueva Conexion al S111 *****
                        if (ValidaCambioS111())
                        {
                            ObjConexionS111 = new N_ActualizaS111.ClsConectaS111();

                            if (mdlParametros.bgCamLimCred)
                            {
                                mdlParametros.bgCamLimCred = !((msCamNomGra != "") || (msCamDatGen != "") || (smCambioSKIP != "") || (smCambioDISP != "") || (smCambioPLA != "") || (smCambioMCC != "") || (smCambioBLOQ != "") || (CORVAR.glstrLimCred.IndexOf("linea", StringComparison.CurrentCultureIgnoreCase) >= 0));
                            }


                            frmLoginS53 frmFirma = new frmLoginS53();
                            var regreso = frmFirma.ShowDialog();


                            if (regreso.ToString() == "OK")
                            {
                                mdlSeguridad.bgSeguridadS041 = true;

                            }
                            else
                            {
                                ObjConexionS111 = null;
                                return;
                            }





                            //AIS-1146 NGONZALEZ
                            //ObjConexionS111.set_PrCheker(ref mdlParametros.bgCamLimBCred);
                            ////AIS-1146 NGONZALEZ
                            //ObjConexionS111.set_Usuario(ref CRSParametros.sgUserID);
                            //ObjConexionS111.strUsuarioMaker = mdlParametros.sgUserCamLimCred;
                            //if ((msCamNomGra != "" || msCamDatGen != "" || smCambioSKIP != "" || smCambioDISP != "" || smCambioPLA != "" || smCambioMCC != "" || smCambioBLOQ != "") || CORVAR.glstrLimCred.IndexOf("linea", StringComparison.CurrentCultureIgnoreCase) >= 0)
                            //{
                            //    if (! ObjConexionS111.FnPreguntaPwd())
                            //    {
                            //        if (ObjConexionS111.EnCausaErrorFirma == TransS111.EnumEstadosFirma.EnUsuarioInvalido)
                            //        {
                            //            while (ObjConexionS111.EnCausaErrorFirma == TransS111.EnumEstadosFirma.EnUsuarioInvalido)
                            //                {

                            //                    ObjConexionS111.EnCausaErrorFirma = TransS111.EnumEstadosFirma.EnFirmaAceptada;
                            //                    respuesta = MessageBox.Show("El sistema S111 no responde. Desea reintentar la firma?", CORSTR.STR_APP_TIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
                            //                    if (respuesta)
                            //                    {
                            //                        if (ObjConexionS111.FnPreguntaPwd())
                            //                        {
                            //                            if (ObjConexionS111.EnCausaErrorFirma != TransS111.EnumEstadosFirma.EnUsuarioInvalido)
                            //                            {
                            //                                mdlSeguridad.bgSeguridadS041 = true;
                            //                                MessageBox.Show(ObjConexionS111.LeyendaS, CORSTR.STR_APP_TIT, MessageBoxButtons.OK);
                            //                            }
                            //                        }
                            //                    } else
                            //                    {
                            //                        ObjConexionS111 = null;
                            //                        return;
                            //                    }
                            //                }
                            //            //MsgError "Usuario Invalido para está operación"
                            //        } else
                            //        {
                            //            MdlCambioMasivo.MsgError(Information.Err().Description);
                            //            ObjConexionS111 = null;
                            //            return;
                            //        }
                            //    } else
                            //    {
                            //        mdlSeguridad.bgSeguridadS041 = true;
                            //        MessageBox.Show(ObjConexionS111.LeyendaS, CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //        //Se logro conectar al S111
                            //    }
                            //} else
                            //{
                            //    mdlSeguridad.bgSeguridadS041 = true;
                            //}
                        }
                        else
                        {
                            mdlSeguridad.bgSeguridadS041 = true;
                            //MessageBox.Show("No se encontraron cambios aplicables al S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK);
                        }
                        

                        if (mdlParametros.bgCamLimCred)
                        {
                            mdlParametros.bgCamLimCred = !((msCamNomGra != "") || (msCamDatGen != "") || (smCambioSKIP != "") || (smCambioDISP != "") || (smCambioPLA != "") || (smCambioMCC != "") || (smCambioBLOQ != "") || (CORVAR.glstrLimCred.IndexOf("linea", StringComparison.CurrentCultureIgnoreCase) >= 0));
                      
                            mdlSeguridad.bgSeguridadS041 = true;
                        }

                        //***** Nueva Conexion al S111 *****

                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;

                        if (mdlSeguridad.bgSeguridadS041)
                        { //Si se pudo conectar
                            if (msCamNomGra == "Nombre")
                            {
                                if (EnviaCambioS111("Nombre", ObjConexionS111))
                                {
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("No se actualizó el nombre del tarjetahabiente en el S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (mbPrimTran)
                                    { //Si es la primera vez de la tranasacción de realiza de nuevo el ciclo if
                                        mbPrimTran = false;
                                        if (EnviaCambioS111("Nombre", ObjConexionS111))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizó el nombre del tarjetahabiente en el S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            string tempRefParam = "Nombre";
                                            if (Actualiza_Campos_M111(ref tempRefParam))
                                            {
                                                this.Cursor = Cursors.Default;
                                                MessageBox.Show("No se actualizó el nombre del tarjetahabiente en el M111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Si no es la primera vez realiza la actualización al M111
                                        string tempRefParam2 = "Nombre";
                                        if (Actualiza_Campos_M111(ref tempRefParam2))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizó el nombre del tarjetahabiente en el M111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }

                            if (msCamLimCre == "Credito")
                            { //Cambio de limite de credito
                                if (mdlParametros.bgCamLimCred)
                                {
                                    if (EnviaCambioS111("Credito", ObjConexionS111))
                                    {

                                        this.Cursor = Cursors.Default;
                                        //itsm
                                        //If blActualizo = False Then
                                        MessageBox.Show("No se actualizó el Crédito del tarjetahabiente en el S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //End If
                                        //fncFirmaS041B "", "", tDesfirmaS041
                                        //objSeguridad.Disconnect
                                        //Set objSeguridad = Nothing

                                        this.Close();
                                        return;
                                    }
                                    else
                                    {
                                        if (mbPrimTran)
                                        {
                                            mbPrimTran = false;
                                            if (EnviaCambioS111("Credito", ObjConexionS111))
                                            {
                                                this.Cursor = Cursors.Default;
                                                MessageBox.Show("No se actualizó el Crédito del tarjetahabiente en el S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                ObjConexionS111 = null;
                                                return;
                                            }
                                            else
                                            {
                                                string tempRefParam4 = "Credito";
                                                if (Actualiza_Campos_M111(ref tempRefParam4))
                                                {
                                                    if (!blActualizaM111)
                                                    {
                                                        this.Cursor = Cursors.Default;
                                                        MessageBox.Show("No se actualizó el Crédito del tarjetahabiente en el M111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        string tempRefParam3 = "";
                                                        mdlSeguridad.fncFirmaS041B(ref tempRefParam3, "", "", mdlSeguridad.enuTipoDlgSeguridad.tDesfirmaS041); //se agrega el 3er parámetro de TOKEN
                                                        mdlSeguridad.objSeguridad.Disconnect();
                                                        mdlSeguridad.objSeguridad = null;
                                                        this.Close();
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        mdlParametros.prActualizaTablaLim();
                                                    }
                                                }
                                                else
                                                {
                                                    mdlParametros.prActualizaTablaLim();
                                                }
                                            }
                                        }
                                        else
                                        {

                                            //''                                If Actualiza_Campos_M111("Credito") = True Then
                                            //''                                    If blActualizaM111 = False Then
                                            //''                                        Screen.MousePointer = Default
                                            //''                                        MsgBox "No se actualizó el Crédito del tarjetahabiente en el M111", vbCritical, STR_APP_TIT
                                            //''                                        fncFirmaS041B "", "", tDesfirmaS041
                                            //''                                        objSeguridad.Disconnect
                                            //''                                        Set objSeguridad = Nothing
                                            //''                                        Unload Me
                                            //''                                        Exit Sub
                                            //''                                    Else
                                            //''                                        prActualizaTablaLim
                                            //''                                    End If
                                            //''                                Else
                                            //''                                    prActualizaTablaLim
                                            //''                                End If

                                            if ((CORVAR.glstrLimCred.IndexOf("linea", StringComparison.CurrentCultureIgnoreCase) + 1) == 0)
                                            {
                                                llValAnt = Int32.Parse(msLimCred);
                                                llValPost = Int32.Parse(ID_MEE_LIM_FTB.CtlText, NumberStyles.Currency);
                                                mdlSeguridad.llNuevoCredito = Int32.Parse(ID_MEE_LIM_FTB.CtlText, NumberStyles.Currency);

                                                //'''                                    prInsertaLimCred llValAnt, llValPost, slCuentaBanamex
                                            }

                                        }
                                    }
                                    CORVAR.gblCamMasivos = false;
                                    this.Close();
                                    return;
                                }
                                else
                                {
                                    llValAnt = Int32.Parse(msLimCred);
                                    llValPost = Int32.Parse(ID_MEE_LIM_FTB.CtlText);
                                    mdlSeguridad.llNuevoCredito = Int32.Parse(ID_MEE_LIM_FTB.CtlText);

                                    mdlParametros.prInsertaLimCred(llValAnt, llValPost, slCuentaBanamex);
                                }
                            }

                            if (msCamDatGen == "Telefono" || msCamDatGen == "RFC")
                            { //Cambio de datos generales
                                if (EnviaCambioS111("Telefono", ObjConexionS111))
                                {
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("No se actualizó los datos generales del tarjetahabiente en el S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (mbPrimTran)
                                    {
                                        mbPrimTran = false;
                                        if (EnviaCambioS111("Telefono", ObjConexionS111))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizó los datos generales del tarjetahabiente en el S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            string tempRefParam5 = "Telefono";
                                            if (Actualiza_Campos_M111(ref tempRefParam5))
                                            {
                                                this.Cursor = Cursors.Default;
                                                MessageBox.Show("No se actualizó los datos generales del tarjetahabiente en el S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string tempRefParam6 = "Telefono";
                                        if (Actualiza_Campos_M111(ref tempRefParam6))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizó los datos generales del tarjetahabiente en el S111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }

                            if (smCambioSKIP == "SkipPayment")
                            { //Cambio de Skip Payment
                                if (EnviaCambioS111("SkipPayment", ObjConexionS111))
                                {
                                    mbActualizaM111 = false;
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("No se actualizo el Skip Payment del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    mbActualizaM111 = !mbPrimTran;
                                }
                                if (mbPrimTran)
                                {
                                    mbPrimTran = false;
                                    if (EnviaCambioS111("SkipPayment", ObjConexionS111))
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("No se actualizo el Skip Payment del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        mbActualizaM111 = true;
                                        string tempRefParam7 = "SkipPayment";
                                        if (Actualiza_Campos_M111(ref tempRefParam7))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo el Skip Payment del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    if (mbActualizaM111)
                                    {
                                        string tempRefParam8 = "SkipPayment";
                                        if (Actualiza_Campos_M111(ref tempRefParam8))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo el Skip Payment del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }

                            if (smCambioDISP == "LimiteDisp")
                            { //Cambio de Limite de Disponible
                                if (EnviaCambioS111("LimiteDisp", ObjConexionS111))
                                {
                                    mbActualizaM111 = false;
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("No se actualizo el Limite de Disposición del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    mbActualizaM111 = !mbPrimTran;
                                }
                                if (mbPrimTran)
                                {
                                    mbPrimTran = false;
                                    if (EnviaCambioS111("LimiteDisp", ObjConexionS111))
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("No se actualizo el Limite de Disposición del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        mbActualizaM111 = true;
                                        string tempRefParam9 = "LimiteDisp";
                                        if (Actualiza_Campos_M111(ref tempRefParam9))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo el Limite de Disposición del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    if (mbActualizaM111)
                                    {
                                        string tempRefParam10 = "LimiteDisp";
                                        if (Actualiza_Campos_M111(ref tempRefParam10))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo el Limite de Disposición del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }

                            if (smCambioPLA == "GenPinPla")
                            { //Cambio de Generacion Pin Plastico
                                if (EnviaCambioS111("GenPinPla", ObjConexionS111))
                                {
                                    mbActualizaM111 = false;
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("No se actualizo la Generación de Pin Plastico del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    mbActualizaM111 = !mbPrimTran;
                                }
                                if (mbPrimTran)
                                {
                                    mbPrimTran = false;
                                    if (EnviaCambioS111("GenPinPla", ObjConexionS111))
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("No se actualizo la Generación de Pin Plastico del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        mbActualizaM111 = true;
                                        string tempRefParam11 = "GenPinPla";
                                        if (Actualiza_Campos_M111(ref tempRefParam11))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo la Generación de Pin Plastico del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    if (mbActualizaM111)
                                    {
                                        string tempRefParam12 = "GenPinPla";
                                        if (Actualiza_Campos_M111(ref tempRefParam12))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo la Generación de Pin Plastico del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }

                            if (smCambioMCC == "MCC")
                            { //Cambio de MCC
                                if (EnviaCambioS111("MCC", ObjConexionS111))
                                {
                                    mbActualizaM111 = false;
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("No se actualizo el MCC del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    mbActualizaM111 = !mbPrimTran;
                                }
                                if (mbPrimTran)
                                {
                                    mbPrimTran = false;
                                    if (EnviaCambioS111("MCC", ObjConexionS111))
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("No se actualizo el MCC del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        mbActualizaM111 = true;
                                        string tempRefParam13 = "MCC";
                                        if (Actualiza_Campos_M111(ref tempRefParam13))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo el MCC del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    if (mbActualizaM111)
                                    {
                                        string tempRefParam14 = "MCC";
                                        if (Actualiza_Campos_M111(ref tempRefParam14))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo el MCC del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }

                            if (smCambioBLOQ == "TipoBloqueo")
                            {
                                if (EnviaCambioS111("TipoBloqueo", ObjConexionS111))
                                {
                                    mbActualizaM111 = false;
                                    this.Cursor = Cursors.Default;
                                    MessageBox.Show("No se actualizo el Tipo de Bloqueo del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    mbActualizaM111 = !mbPrimTran;
                                }
                                if (mbPrimTran)
                                {
                                    mbPrimTran = false;
                                    if (EnviaCambioS111("TipoBloqueo", ObjConexionS111))
                                    {
                                        this.Cursor = Cursors.Default;
                                        MessageBox.Show("No se actualizo el Tipo de Bloqueo del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        mbActualizaM111 = true;
                                        string tempRefParam15 = "TipoBloqueo";
                                        if (Actualiza_Campos_M111(ref tempRefParam15))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo el Tipo de Bloqueo del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    if (mbActualizaM111)
                                    {
                                        string tempRefParam16 = "TipoBloqueo";
                                        if (Actualiza_Campos_M111(ref tempRefParam16))
                                        {
                                            this.Cursor = Cursors.Default;
                                            MessageBox.Show("No se actualizo el Tipo de Bloqueo del tarjetahabiente en el S111.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            if (mdlSeguridad._SOAID != mdlSeguridad.Stdl_ope_id_MM)
                            {
                                string StrIp = mdlSeguridad.GetIP();
                                //string StrIp = "10.199.251.246";
                                int FirmaoDesfirma = 2;

                                string _url = ConfigurationManager.AppSettings["_url"];
                                string _action = ConfigurationManager.AppSettings["_action_b"];

                                mdlSeguridad.Desfirma_checker(StrIp, FirmaoDesfirma, _url, _action);
                            }

                        }

                        mbActualizaM111 = false;

                        this.Cursor = Cursors.WaitCursor;

                        if (msCamNomGra == "Nombre" || msCamLimCre == "Credito" || msCamDatGen == "Telefono" || smCambioMCC == "MCC" || smCambioSKIP == "SkipPayment" || smCambioDISP == "LimiteDisp" || smCambioPLA == "GenPinPla")
                        {

                            //***** Pasada Conexión al S111 *****
                            //                pszCadena = FINALIZA_S111        'Termina la sesión del usuario
                            //                pszRegresaS111 = ConComDrive.Envia_Mensaje(pszCadena)
                            //                pszMensajeS111 = Muestra_Mensaje(pszRegresaS111)
                            //                If InStr(pszMensajeS111, "HASTA LUEGO") <> NULL_INTEGER Then
                            //                    'MsgBox " " & pszMensajeS111, vbExclamation, Me.Caption
                            //                ElseIf InStr(pszMensajeS111, "VUELVA A DARSE DE ALTA") <> 0 Then
                            //                    MsgBox " " & pszMensajeS111, vbCritical, Me.Caption
                            //                End If
                            //                DoEvents
                            //                ConComDrive.Termina_Conexion
                            //                DoEvents
                            //***** Pasada Conexión al S111 *****
                            ObjConexionS111 = null;
                            this.Cursor = Cursors.Default;
                            ID_MEE_ALT_PB.Focus();
                            this.Cursor = Cursors.Default;
                            //itsm
                            if (!mdlParametros.bgCamLimCred)
                            {
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("Se modificó el ejecutivo " + StringsHelper.Format(CORVAR.igblEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + " " + pszEjeNom, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                            }
                        }

                        this.Cursor = Cursors.WaitCursor;

                        if (msCamDatAdi == "DatosAdi" || blUpdate)
                        {
                            CORVAR.pszgblsql = "exec spUCambioEjeEmp ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + CORVAR.igblPref.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + CORVAR.igblBanco.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + lEmpNum.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + CORVAR.igblEjeNum.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszEjeNom.Trim() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszEjeRFC.Trim() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + lEjeSueldo.ToString() + ",";
                            //pszgblsql = pszgblsql & "'" & Format$(lNumNom) & "'," comenta yuria 12/10/06
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + sNumNom.Trim() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszEjeCC.Trim() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + iEjeNivel.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszEjeFax + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + iRegNum.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszejeStatus + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszSexo + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszOrigen + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + iSucTran.ToString() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + iSucProm.ToString() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszActSubAct + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + slDomCalle + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + slDomColonia + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + slDomCiudad + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + slDomPoblacion + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + slDomEstado + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + llDomCodigoPostal.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtMail.Text.Trim() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + txtCContable.Text.Trim() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ilGenPinPlastico.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + llLimDispEfectivo.ToString() + ",";
                            //UPGRADE_WARNING: (1068) slTipoCuenta of type Variant is being forced to string.
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + Convert.ToString(slTipoCuenta) + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + slTipoFactura + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ilSkipPayment.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + ilTablaMCC.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + slUsuarioCambio + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszAtencionA + "',"; //FSWB NR 20070221
                            CORVAR.pszgblsql = CORVAR.pszgblsql + pszPersona; //FSWB NR 20070221

                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                                this.Cursor = Cursors.Default;
                                //itsm
                                if (!mdlParametros.bgCamLimCred)
                                {
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("Se modificó el ejecutivo " + StringsHelper.Format(CORVAR.igblEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + " " + pszEjeNom, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONINFORMATION)), CORSTR.STR_APP_TIT);
                                }
                                this.Cursor = Cursors.Default;
                                this.Close();
                            }

                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                        }

                        //cambia el stasus del emsaje
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = false;

                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Se requiere el nombre del tarjetahabiente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (msCamNomGra == "Nombre" || msCamLimCre == "Credito" || msCamDatGen == "Telefono" || smCambioMCC == "MCC" || smCambioSKIP == "SkipPayment" || smCambioDISP == "LimiteDisp" || smCambioPLA == "GenPinPla")
                    {

                        //termina la sesión del usuario
                        //            pszCadena = FINALIZA_S111

                        //envia la cadena al S111
                        //            pszRegresaS111 = ConComDrive.Envia_Mensaje(pszCadena)

                        //            pszRegresaS111 = Muestra_Mensaje(pszRegresaS111)

                        //            If InStr(pszRegresaS111, "HASTA LUEGO") <> NULL_INTEGER Then
                        //MsgBox " " & pszRegresaS111, vbExclamation, Me.Caption
                        //            Else
                        //                MsgBox " " & pszRegresaS111, vbCritical, Me.Caption
                        //            End If
                        //            ConComDrive.Termina_Conexion
                    }

                }

                if (CORVAR.gblCamMasivos)
                {
                    //genera los archivos si hubo cambios
                    //genera archivos de bitacora y para excel
                    string tempRefParam17 = "Procesado";
                    string tempRefParam18 = "DomicilioT";
                    CORPROC2.Genera_Achivos_Cambios("CMDomici.txt", ref tempRefParam17, ref tempRefParam18, "Normal");
                    string tempRefParam19 = "Procesado";
                    string tempRefParam20 = "Limite";
                    CORPROC2.Genera_Achivos_Cambios("CMLimite.txt", ref tempRefParam19, ref tempRefParam20, "Normal");
                    string tempRefParam21 = "Procesado";
                    string tempRefParam22 = "Nombre";
                    CORPROC2.Genera_Achivos_Cambios("CMNombre.txt", ref tempRefParam21, ref tempRefParam22, "Normal");

                    //genera archivo´para excel
                    string tempRefParam23 = "Procesado";
                    string tempRefParam24 = "Limite";
                    CORPROC2.Genera_Achivos_Cambios("Limite.txt", ref tempRefParam23, ref tempRefParam24, "Excel");
                    string tempRefParam25 = "Procesado";
                    string tempRefParam26 = "DomicilioT";
                    CORPROC2.Genera_Achivos_Cambios("DomEmpre.txt", ref tempRefParam25, ref tempRefParam26, "Excel");

                    //depura la tabla de cambios masivos
                    //Call CORMNEMP.Depura_Tabla_CamMasivos("Limite")
                    //Call CORMNEMP.Depura_Tabla_CamMasivos("DomicilioT")
                    //Call CORMNEMP.Depura_Tabla_CamMasivos("Nombre")
                }

                this.Close();
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private string Valida_Campos()
        {
            string result = String.Empty;
            int iDia = 0;
            int iMes = 0;
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                string pszValida = CORVB.NULL_STRING;
                //****************************************************************************************************************
                //Validaciones del Fichero 0
                //****************************************************************************************************************
                if (ID_MEE_NEJ_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    pszValida = "NOMBRE DEL EJECUTIVO";
                    Fichero(0);
                    ID_MEE_NEJ_EB.Focus();
                }
                else if (ID_MEE_NCE_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    pszValida = "NOMBRE DE GRABACIÓN";
                    Fichero(0);
                    ID_MEE_NCE_EB.Focus();
                }
                else if (!bfncValidaRFCEJE(ID_MEE_RFC_EB.defaultText.Trim()))
                {
                    pszValida = "RFC";
                    Fichero(0);
                    ID_MEE_RFC_EB.Focus();
                }
                else if ((ID_MEE_LIM_FTB.CtlText == CORVB.NULL_STRING))
                {
                    pszValida = "LIMITE DE CREDITO INCORRECTO";
                    ID_MEE_LIM_FTB.CtlText = "0";
                    Fichero(0);
                    ID_MEE_LIM_FTB.Focus();
                }
                else if ((Conversion.Val(ID_MEE_LIM_FTB.CtlText) > CRSParametros.cteLimiteCredito))
                {
                    pszValida = "LIMITE DE CRÉDITO INCORRECTO";
                    MessageBox.Show("Importe mayor al permitido", Application.ProductName);
                    ID_MEE_LIM_FTB.CtlText = "0";
                    Fichero(0);
                    ID_MEE_LIM_FTB.Focus();
                }
                else if ((Conversion.Val(ID_MEE_LIM_FTB.CtlText) < 0))
                {
                    pszValida = "LIMITE DE CRÉDITO INCORRECTO";
                    MessageBox.Show("Importe menor al permitido", "Límite de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ID_MEE_LIM_FTB.CtlText = "0";
                    ID_MEE_LIM_FTB.SelStart = 0;
                    ID_MEE_LIM_FTB.SelLength = Strings.Len(ID_MEE_LIM_FTB.defaultText);
                    Fichero(0);
                    ID_MEE_LIM_FTB.Focus();
                }
                else if (Double.Parse(txtDisEfectivo.defaultText) < 0 || Double.Parse(txtDisEfectivo.defaultText) > 100)
                {
                    double switchVar = Conversion.Val(txtDisEfectivo.defaultText);
                    if (switchVar < 0)
                    {
                        llLimDispEfectivo = Convert.ToInt32(Conversion.Val(txtDisEfectivo.defaultText));
                        MessageBox.Show("El porcentaje mínimo de disposición de efectivo no puede ser menor al 0%.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDisEfectivo.defaultText = "0";
                        txtDisEfectivo.SelStart = 0;
                        txtDisEfectivo.SelLength = Strings.Len(txtDisEfectivo.CtlText);
                    }
                    else if (switchVar > 100)
                    {
                        llLimDispEfectivo = Convert.ToInt32(Conversion.Val(txtDisEfectivo.defaultText));
                        MessageBox.Show("El porcentaje mínimo de disposición de efectivo no debe exceder del 100%.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDisEfectivo.defaultText = "100";
                        txtDisEfectivo.SelStart = 0;
                        txtDisEfectivo.SelLength = Strings.Len(txtDisEfectivo.CtlText);
                    }
                    pszValida = "LÍMITE DE DISPOSICIÓN";
                    Fichero(0);
                    txtDisEfectivo.Focus();
                }
                else if (!ID_MEE_FEM_OPB.Checked && !ID_MEE_MAS_OPB.Checked)
                {
                    pszValida = "SEXO";
                    Fichero(0);
                    //UPGRADE_TODO: (1067) Member SetFocus is not defined in type Threed.SSOption.
                    ID_MEE_FEM_OPB.Focus();
                }
                else if (slRegion == CORVB.NULL_STRING)
                {
                    slRegion = "01";
                    //****************************************************************************************************************
                    //Validaciones del Fichero 1
                    //****************************************************************************************************************
                }
                else if (ID_MEE_CNU_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    pszValida = "CALLE Y NÚMERO";
                    Fichero(1);
                    ID_MEE_CNU_EB.Focus();
                }
                else if (ID_MEE_COL_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    pszValida = "COLONIA";
                    Fichero(1);
                    ID_MEE_COL_EB.Focus();
                }
                else if (ID_MEE_POB_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    pszValida = "POBLACIÓN";
                    Fichero(1);
                    ID_MEE_POB_EB.Focus();
                }
                else if (Conversion.Val(ID_MEE_TOF_PIC.CtlText) == CORVB.NULL_INTEGER)
                {
                    pszValida = "TEL. OFICINA";
                    Fichero(1);
                    ID_MEE_TOF_PIC.Focus();
                }
                else if (Conversion.Val(ID_MEE_CP_PIC.CtlText) == CORVB.NULL_INTEGER)
                {
                    pszValida = "CÓDIGO POSTAL";
                    Fichero(1);
                    ID_MEE_CP_PIC.Focus();
                }
                else if (ID_MEM_EDO_EB[1].SelectedIndex < CORVB.NULL_INTEGER)
                {
                    pszValida = "ESTADO DE ENVIO";
                    Fichero(1);
                    ID_MEM_EDO_EB[1].Focus();
                    //  ElseIf ID_MEM_EDO_EB(0).ListIndex < NULL_INTEGER Then
                    //    pszValida = "ESTADO PARTICULAR"
                    //    Fichero 1
                    //    ID_MEM_EDO_EB(0).SetFocus
                }
                slRegion = "01";
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                result = pszValida;
                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //  ElseIf Val(Mid$(Trim$(ID_MEE_LIM_FTB.Text), 2, Len(ID_MEE_LIM_FTB.Text) - 1)) = NULL_INTEGER Or Val(Mid$(Trim$(ID_MEE_LIM_FTB.Text), 2, Len(ID_MEE_LIM_FTB.Text) - 1)) < 1 Then
                //    pszValida = "LIMITE DE CREDITO O ES INCORRECTO"
                //   ID_MEE_LIM_FTB.SetFocus
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX *****
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                //EISSA 07.01.2001 CÓDIGO ANTERIOR QUE VALIDA RFC Y REGION
                //valida que este bien capturado el rfc del ejecutivo
                //****************************************************************
                //  ID_MEE_RFC_EB.Text = Trim$(ID_MEE_RFC_EB.Text)
                //
                //  If ID_MEE_RFC_EB.Text = "-      -" Then
                //    pszValida = "RFC"
                //    ID_MEE_RFC_EB.SetFocus
                //  Else
                //    If (Mid$(ID_MEE_RFC_EB.Text, 1, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 2, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 3, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 4, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 6, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 7, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 8, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 9, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 10, 1)) = " " Or _
                //'       (Mid$(ID_MEE_RFC_EB.Text, 11, 1)) = " " Then
                //        MsgBox "RFC incompleto", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //        pszValida = "RFC"
                //        ID_MEE_RFC_EB.SetFocus
                //    Else
                //'      If (Mid$(ID_MEE_RFC_EB.Text, 5, 1)) <> "-" Then
                //'          MsgBox "RFC incompleto", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //'          pszValida = "RFC"
                //'          ID_MEE_RFC_EB.SetFocus
                //'      Else
                //''        If Len(Trim$(ID_MEE_RFC_EB.Text)) < 12 Then
                //''           MsgBox "RFC incompleto", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //''           pszValida = "RFC"
                //''           ID_MEE_RFC_EB.SetFocus
                //''        Else
                //''           iMes = Val(Mid$(ID_MEE_RFC_EB.Text, 8, 2))
                //'''           If iMes < 10 And Mid$(ID_MEE_RFC_EB.Text, 8, 1) <> "0" Then
                //'''              MsgBox "RFC erroneo en mes.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //'''              pszValida = "RFC"
                //'''              ID_MEE_RFC_EB.SetFocus
                //'''           Else
                //''''              iDia = Val(Mid$(ID_MEE_RFC_EB.Text, 10, 2))
                //''''              If iDia < 10 And Mid$(ID_MEE_RFC_EB.Text, 10, 1) <> "0" Then
                //''''                 MsgBox "RFC erroneo en mes.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //''''                 pszValida = "RFC"
                //''''                 ID_MEE_RFC_EB.SetFocus
                //''''              Else
                //'''''                 If iMes > 12 Or iMes < 1 Then
                //'''''                    MsgBox "RFC erroneo en mes.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //'''''                    pszValida = "RFC"
                //'''''                    ID_MEE_RFC_EB.SetFocus
                //'''''                 Else
                //'''''                    If iMes = 2 And iDia > 29 Then
                //'''''                       MsgBox "RFC erroneo en dia del mes de fecbrero.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //'''''                       pszValida = "RFC"
                //'''''                       ID_MEE_RFC_EB.SetFocus
                //'''''                    End If
                //'''''                 End If
                //'''''              End If
                //'''''              If iDia > 31 Or iDia < 1 Then
                //'''''                 MsgBox "RFC erroneo en dia.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //'''''                 pszValida = "RFC"
                //'''''                 ID_MEE_RFC_EB.SetFocus
                //'''''              End If
                //''''           End If
                //'''        End If
                //''      End If
                //'    End If
                //  End If
                //****************************************************************
                //valida que la región que se capturo exista
                //  pszgblsql = "select * from MTCREG01"
                //  pszgblsql = pszgblsql + " where reg_num = " + Str$(Val(slRegion))
                //  If Obtiene_Registros Then
                //  Else
                //MsgBox "No existe la región capturada. ", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
                //pszValida = "Región"
                //    slRegion = "01"
                //ID_MEE_REG_PIC.SetFocus
                //  End If
                //  igblRetorna = SqlCancel(hgblConexion)
                //  Valida_Campos = pszValida
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
            return result;
        }

        private int Verifica_nombre(string pszEjeNom)
        {

            FixedLengthString szCaracter = new FixedLengthString(1);
            int iPosComa = 0;
            int iPosDiag = 0;

            object bComa = CORVB.NULL_INTEGER;
            object bDiagonal = CORVB.NULL_INTEGER;

            for (int iCont = 1; iCont <= pszEjeNom.Length; iCont++)
            {
                szCaracter.Value = Strings.Mid(pszEjeNom, iCont, 1);
                if (szCaracter.Value == ",")
                {
                    //UPGRADE_WARNING: (1037) Couldn't resolve default property of object bComa.
                    bComa = true;
                }
                //UPGRADE_WARNING: (1068) bComa of type Variant is being forced to bool.
                if (Convert.ToBoolean(bComa) && szCaracter.Value == "/")
                {
                    //UPGRADE_WARNING: (1037) Couldn't resolve default property of object bDiagonal.
                    bDiagonal = true;
                    break;
                }
            }

            //UPGRADE_WARNING: (1068) bDiagonal of type Variant is being forced to bool.
            if (Convert.ToBoolean(bDiagonal))
            {
                iPosComa = (pszEjeNom.IndexOf(',') + 1);
                iPosDiag = (pszEjeNom.IndexOf('/') + 1);
                if (iPosDiag - iPosComa <= 1)
                {
                    pszEjeNom = Strings.Mid(pszEjeNom, 1, iPosComa - 1).Trim() + ",/" + Strings.Mid(pszEjeNom, iPosDiag + 1).Trim();
                }
                else
                {
                    pszEjeNom = Strings.Mid(pszEjeNom, 1, iPosComa - 1).Trim() + "," + Strings.Mid(pszEjeNom, iPosComa + 1, iPosDiag - iPosComa - 1).Trim() + "/" + Strings.Mid(pszEjeNom, iPosDiag + 1).Trim();
                }
                ID_MEE_NCE_EB.Text = pszEjeNom;
            }

            //UPGRADE_WARNING: (1068) bDiagonal of type Variant is being forced to int.
            return Convert.ToInt32(bDiagonal);

        }

        private void ID_MEE_RFC_EB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            //La propiedad cancel será tru cuando el rfc es invalido
            Cancel = !objRfcEje.fncValidaRFCB(ID_MEE_RFC_EB.defaultText, clsRFC.enuTipoPersona.tprPersonaFisica);


            eventArgs.Cancel = Cancel;
        }

        private void ID_MEE_SDO_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_SDO_EB.SelStart = 0;
            ID_MEE_SDO_EB.SelLength = Strings.Len(ID_MEE_SDO_EB.CtlText);
        }

        private void ID_MEE_SDO_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
        }

        private void ID_MEE_SDO_EB_Leave(Object eventSender, EventArgs eventArgs)
        {
            if (Conversion.Val(ID_MEE_SDO_EB.CtlText) > CRSParametros.cteLimiteCredito)
            {
                MessageBox.Show("Importe mayor al permitido", Application.ProductName);
                ID_MEE_SDO_EB.CtlText = "0";
                ID_MEE_SDO_EB.Focus();
            }
        }

        private void ID_MEE_TAR_FPT_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            Fichero(ID_MEE_TAR_FPT.SelectedIndex);
            ID_MEE_TAR_FPTPreviousTab = ID_MEE_TAR_FPT.SelectedIndex;
        }

        private void ID_MEE_TDO_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_TDO_PIC.SelStart = 0;
            ID_MEE_TDO_PIC.SelLength = Strings.Len(ID_MEE_TDO_PIC.defaultText);
        }

        private void ID_MEE_TDO_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
        }

        private void ID_MEE_TOF_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_TOF_PIC.SelStart = 0;
            ID_MEE_TOF_PIC.SelLength = Strings.Len(ID_MEE_TOF_PIC.defaultText);
        }

        private void ID_MEE_TOF_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
        }


        private void ID_MEE_ZPO_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEE_ZPO_PIC.SelStart = 0;
            ID_MEE_ZPO_PIC.SelLength = Strings.Len(ID_MEE_ZPO_PIC.defaultText);
        }

        private void ID_MEE_ZPO_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValEntero);
        }


        private void ID_MEJ_CTA_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEJ_CTA_EB.SelectionStart = 0;
            ID_MEJ_CTA_EB.SelectionLength = Strings.Len(ID_MEJ_CTA_EB.Text);
        }

        private void ID_MEJ_CTA_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii < 48 || KeyAscii > 57)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_CIU_EB_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            slDomCiudad = ID_MEM_CIU_EB[0].Text;
            blUpdate = true;
        }

        private void ID_MEM_CIU_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_CIU_EB, eventSender);
            ID_MEM_CIU_EB[Index].SelectionStart = 0;
            ID_MEM_CIU_EB[Index].SelectionLength = Strings.Len(ID_MEM_CIU_EB[Index].Text);
        }

        private void ID_MEM_CIU_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_COL_EB_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            slDomColonia = ID_MEM_COL_EB[0].Text;
            blUpdate = true;
        }

        private void ID_MEM_COL_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_COL_EB, eventSender);
            ID_MEM_COL_EB[Index].SelectionStart = 0;
            ID_MEM_COL_EB[Index].SelectionLength = Strings.Len(ID_MEM_COL_EB[Index].Text);
        }

        private void ID_MEM_COL_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_CP_PIC_Change(Object eventSender, EventArgs eventArgs)
        {
            llDomCodigoPostal = Convert.ToInt32(Conversion.Val(ID_MEM_CP_PIC[0].defaultText));
            blUpdate = true;
        }

        private void ID_MEM_CP_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_CP_PIC, eventSender);
            ID_MEM_CP_PIC[Index].SelStart = 0;
            ID_MEM_CP_PIC[Index].SelLength = Strings.Len(ID_MEM_CP_PIC[Index].defaultText);
        }

        private void ID_MEM_CP_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            //AIS-1094 NGONZALEZ
            //AIS-1096 NGONZALEZ
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
        }

        private void ID_MEM_DOM_EB_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            slDomCalle = ID_MEM_DOM_EB[0].Text;
            blUpdate = true;
        }

        private void ID_MEM_DOM_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_DOM_EB, eventSender);
            ID_MEM_DOM_EB[Index].SelectionStart = 0;
            ID_MEM_DOM_EB[Index].SelectionLength = Strings.Len(ID_MEM_DOM_EB[Index].Text);
        }

        private void ID_MEM_DOM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_MEM_EDO_EB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_EDO_EB, eventSender);
            switch (Index)
            {
                case 0:
                    if (ID_MEM_EDO_EB[0].SelectedIndex < 0)
                    {
                        slDomEstado = "";
                    }
                    else
                    {
                        slDomEstado = CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[0].SelectedIndex];
                    }
                    blUpdate = true;
                    break;
                case 1:
                    if (ID_MEM_EDO_EB[1].SelectedIndex < 0)
                    {
                        slEstadoEnv = "";
                    }
                    else
                    {
                        slEstadoEnv = CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex];
                    }
                    blUpdate = true;
                    break;
            }
        }

        private void ID_MEM_PDM_EB_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            slDomPoblacion = ID_MEM_PDM_EB[0].Text;
            blUpdate = true;
        }

        private void ID_MEM_PDM_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_PDM_EB, eventSender);
            ID_MEM_PDM_EB[Index].SelectionStart = 0;
            ID_MEM_PDM_EB[Index].SelectionLength = Strings.Len(ID_MEM_PDM_EB[Index].Text);
        }

        private void ID_MEM_PDM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_MEM_PERSONA_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            txtAtencionA.Enabled = true; //FSWB NR 20070222
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_PERSONA_Leave(Object eventSender, EventArgs eventArgs)
        {
            txtAtencionA.Enabled = true; //FSWB NR 20070222
        }

        //UPGRADE_WARNING: (2050) Threed.SSOption Event ID_MEM_TFA_3OPB.Click was not upgraded.
        private void ID_MEM_TFA_3OPB_Click(int Index)
        {
            switch (Index)
            {
                case 0:
                    slTipoFactura = CRSParametros.cteCorporativo;
                    break;
                case 1:
                    slTipoFactura = CRSParametros.cteIndividual;
                    break;
            }
        }

        private void mskMCC_Change(Object eventSender, EventArgs eventArgs)
        {
            ilTablaMCC = Convert.ToInt32(Conversion.Val(mskMCC.CtlText));
        }

        private void mskMCC_Enter(Object eventSender, EventArgs eventArgs)
        {
            mskMCC.SelStart = 0;
            mskMCC.SelLength = Strings.Len(mskMCC.defaultText);
        }

        private void mskMCC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
            //AIS-421 NGONZALEZ
            if (eventArgs.keyAscii == ((int)"\t"[0]))
            {
                Fichero(0);
            }
        }

        //UPGRADE_WARNING: (2050) Threed.SSOption Event optEjecutivos.Click was not upgraded.
        private void optEjecutivos_Click(int Index)
        {

            switch (Index)
            {
                case 0:  //Tipo de Bloqueo (No maneja Bloqueo) 
                    ilTipoBloqueo = mdlEmpresa.cteiNoManejaBloqueo;
                    mskMCC.CtlText = "0";
                    mskMCC.Enabled = false;
                    break;
                case 1:  //Tipo de Bloqueo (Bloqueo por MCC) 
                    ilTipoBloqueo = mdlEmpresa.cteiBloqueoPorMCC;
                    mskMCC.Enabled = true;
                    break;
                case 2:  //Tipo de Bloqueo (Bloqueo por No. de Negocio) 
                    ilTipoBloqueo = mdlEmpresa.cteiBloqueoPorNegocio;
                    mskMCC.Enabled = true;
                    break;
            }

        }

        //UPGRADE_WARNING: (2050) Threed.SSOption Event optNacionalidad.Click was not upgraded.
        private void optNacionalidad_Click(int Index)
        {
            switch (Index)
            {
                case 0:
                    slNacionalidad = CRSParametros.cteMexicana;
                    break;
                case 1:
                    slNacionalidad = CRSParametros.cteExtranjera;
                    break;
            }
        }

        private void txtAtencionA_Enter(Object eventSender, EventArgs eventArgs)
        {
            txtAtencionA.SelectionStart = 0;
            txtAtencionA.SelectionLength = Strings.Len(txtAtencionA.Text);
        }

        private void txtAtencionA_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            //FSWB NR 20070223
            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void txtCContable_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            slCtaContable = txtCContable.Text;
        }

        private void txtCContable_Enter(Object eventSender, EventArgs eventArgs)
        {
            txtCContable.SelectionStart = 0;
            txtCContable.SelectionLength = Strings.Len(txtCContable.Text);
        }

        private void txtCContable_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void txtDisEfectivo_Change(Object eventSender, EventArgs eventArgs)
        {
            llLimDispEfectivo = Convert.ToInt32(Conversion.Val(txtDisEfectivo.defaultText));
        }

        private void txtDisEfectivo_Enter(Object eventSender, EventArgs eventArgs)
        {
            txtDisEfectivo.SelStart = 0;
            txtDisEfectivo.SelLength = Strings.Len(txtDisEfectivo.defaultText);
        }

        private void txtDisEfectivo_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValEntero, true, false);
        }

        private void txtDisEfectivo_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int ilValorAnterior = Convert.ToInt32(Conversion.Val(txtDisEfectivo.defaultText));
            if (ilValorAnterior < 0)
            {
                llLimDispEfectivo = ilValorAnterior;
                MessageBox.Show("El porcentaje mínimo de disposición de efectivo no puede ser menor al 0%.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDisEfectivo.defaultText = "0";
                txtDisEfectivo.SelStart = 0;
                txtDisEfectivo.SelLength = Strings.Len(txtDisEfectivo.CtlText);
                Cancel = true;
            }
            else if (ilValorAnterior > 100)
            {
                llLimDispEfectivo = ilValorAnterior;
                MessageBox.Show("El porcentaje mínimo de disposición de efectivo no debe exceder del 100%.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDisEfectivo.defaultText = "100";
                txtDisEfectivo.SelStart = 0;
                txtDisEfectivo.SelLength = Strings.Len(txtDisEfectivo.CtlText);
                Cancel = true;
            }
            else if (ilValorAnterior == 100)
            {
                llLimDispEfectivo = Convert.ToInt32(Conversion.Val(txtDisEfectivo.defaultText));
                slEsquemaPago = CRSParametros.cteTotal;
            }
            else
            {
                llLimDispEfectivo = Convert.ToInt32(Conversion.Val(txtDisEfectivo.defaultText));
                slEsquemaPago = CRSParametros.cteMinimo;
            }
            eventArgs.Cancel = Cancel;
        }

        private void txtMail_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            slEMail = txtMail.Text;
        }

        private void chkPinPlastico_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            if (chkPinPlastico[0].CheckState == CheckState.Unchecked)
            {
                chkPinPlastico[1].CheckState = CheckState.Unchecked;
                chkPinPlastico[1].Enabled = false;
                chkCuentaControl.Enabled = true;
            }
            else
            {
                chkPinPlastico[1].Enabled = true;
                chkCuentaControl.CheckState = CheckState.Unchecked;
                chkCuentaControl.Enabled = false;
            }

            if (chkPinPlastico[0].CheckState == CheckState.Checked && chkPinPlastico[1].CheckState == CheckState.Checked)
            {
                ilGenPinPlastico = (int)CRSParametros.GeneracionPlastico.cteSiPlasticoSiPIN;
            }
            if (chkPinPlastico[0].CheckState == CheckState.Unchecked && chkPinPlastico[1].CheckState == CheckState.Unchecked)
            {
                ilGenPinPlastico = (int)CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN;
            }

            if (chkPinPlastico[0].CheckState == CheckState.Checked && chkPinPlastico[1].CheckState == CheckState.Unchecked)
            {
                ilGenPinPlastico = (int)CRSParametros.GeneracionPlastico.cteSiPlasticoNoPIN;
            }
        }

        private void prCfgPinPlastico(int ipPinPlastico)
        {
            //Genera Plástico y Genera PIN
            if (ipPinPlastico == ((int)CRSParametros.GeneracionPlastico.cteSiPlasticoSiPIN))
            {
                chkPinPlastico[0].CheckState = CheckState.Checked;
                chkPinPlastico[1].CheckState = CheckState.Checked;
            }
            else if (ipPinPlastico == ((int)CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN))
            {
                chkPinPlastico[0].CheckState = CheckState.Unchecked;
                chkPinPlastico[1].CheckState = CheckState.Unchecked;
            }
            else if (ipPinPlastico == ((int)CRSParametros.GeneracionPlastico.cteSiPlasticoNoPIN))
            {
                chkPinPlastico[0].CheckState = CheckState.Checked;
                chkPinPlastico[1].CheckState = CheckState.Unchecked;
            }
            else
            {
                chkPinPlastico[0].CheckState = CheckState.Unchecked;
                chkPinPlastico[1].CheckState = CheckState.Unchecked;
            }
        }

        public CRSParametros.GeneracionPlastico ifncPinPlastico()
        {
            CRSParametros.GeneracionPlastico result = CRSParametros.GeneracionPlastico.cteSiPlasticoSiPIN;
            if (chkPinPlastico[0].CheckState == CheckState.Checked && chkPinPlastico[1].CheckState == CheckState.Checked)
            {
                result = CRSParametros.GeneracionPlastico.cteSiPlasticoSiPIN;
            }
            if (chkPinPlastico[0].CheckState == CheckState.Unchecked && chkPinPlastico[1].CheckState == CheckState.Unchecked)
            {
                result = CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN;
            }
            if (chkPinPlastico[0].CheckState == CheckState.Checked && chkPinPlastico[1].CheckState == CheckState.Unchecked)
            {
                result = CRSParametros.GeneracionPlastico.cteSiPlasticoNoPIN;
            }
            return result;
        }

        private string sfncCuentaPadre(int ipPrefijo, int ipBanco, int lpEmpresa)
        {
            try
            {

                return mdlEjecutivo.fncCuentaPadreS(ipPrefijo, ipBanco, lpEmpresa);
            }
            catch
            {

                CRSGeneral.prObtenError("CuentaPadre");
            }
            return String.Empty;
        }

        private void txtMail_Enter(Object eventSender, EventArgs eventArgs)
        {
            txtMail.SelectionStart = 0;
            txtMail.SelectionLength = Strings.Len(txtMail.Text);
        }

        private void txtMail_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValCorreoElectrónico, false, false);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        public void Fichero(int iIndice)
        {
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                switch (iIndice)
                {
                    case 0:
                        if (this.Tag.ToString() != CORCONST.TAG_CONSULTA && this.Tag.ToString() != "CAMBIO LIMITE DE CREDITO")
                        {
                            ID_MEE_NEJ_EB.Focus();
                        }
                        ID_MEE_TAR_FPT.SelectedIndex = iIndice;
                        break;
                    case 1:
                        if (this.Tag.ToString() != CORCONST.TAG_CONSULTA && this.Tag.ToString() != "CAMBIO LIMITE DE CREDITO")
                        {
                            if (ID_MEE_CNU_EB.Enabled)
                            {
                                ID_MEE_CNU_EB.Focus();
                            }
                            else
                            {
                                ID_MEE_TOF_PIC.Focus();
                            }
                        }
                        ID_MEE_TAR_FPT.SelectedIndex = iIndice;
                        break;
                    case 2:
                        if (this.Tag.ToString() != CORCONST.TAG_CONSULTA && this.Tag.ToString() != "CAMBIO LIMITE DE CREDITO")
                        {
                            if (chkPinPlastico[0].Enabled)
                            {
                                chkPinPlastico[0].Focus();
                            }
                            else
                            {
                                mskMCC.Focus();
                            }
                        }
                        ID_MEE_TAR_FPT.SelectedIndex = iIndice;
                        break;
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        public void prCfgCtaCtrl(string slCuentaControl)
        {
            try
            {
                if (slCuentaControl == CRSParametros.cteNoCuentaControl)
                {
                    chkCuentaControl.CheckState = CheckState.Unchecked;
                }
                else if (slCuentaControl == CRSParametros.cteSiCuentaControl)
                {
                    chkCuentaControl.CheckState = CheckState.Checked;
                }
                else
                {
                    chkCuentaControl.CheckState = CheckState.Unchecked;
                }
            }
            catch
            {

                CRSGeneral.prObtenError("CuentaControl");
            }
        }

        /*
            private void  Alta_Ejecutivo()
            {
					
                    CRSDialogo.DatosDialogo dlgAlta = CRSDialogo.DatosDialogo.CreateInstance();
					
                    //Variables de procedimiento
                    int hEjeEmp = 0;
                    int iError = 0;
                    int iValor = 0;
					
                    //Variables de Campos de  la tabla
                    string pszTipoEnvio = String.Empty;
                    string pszEjeCalle = String.Empty;
                    string pszEjeCol = String.Empty;
                    string pszEjePob = String.Empty;
                    int lEmpCredTot = 0;
                    int lEmpCredAcum = 0;
                    int iEjeDigit = 0;
                    int iDigito = 0;
                    int iEjeNum = 0;
                    int lEjeCred = 0;
                    string pszEjeCC = String.Empty;
                    string pszejeStatus = String.Empty;
                    int hEjecEmp = 0;
                    int pszSumaCred = 0;
                    int lNumNom = 0;
					
                    //Variables para formateo de número de empresa y ejecutivo 01-10-2001
                    int long_Emp = 0;
                    int long_eje = 0;
                    string num_empresa = String.Empty;
                    string num_ejecutivo = String.Empty;
                    string paso = String.Empty;
					
					
                    //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
                    try
                    {
                            this.Cursor = Cursors.WaitCursor;
                            bAltaNuevamente = false;
                            int lEmpNum = Convert.ToInt32(Conversion.Val(ID_MEE_CTA_TXT.Text)); //Número de la Empresa
                            string pszCampo = Valida_Campos();
                            slOrigen = CORBD.TIPO_ORIGEN; //Se asigna el valor por default para la alta
							
                            if (pszCampo.Length != 0)
                            {
                                this.Cursor = Cursors.Default;
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("Falta por capturar el campo: " + pszCampo, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                return;
                            }
							
                            //Se obtiene el crédito total y acumulado de la empresa
                            //    pszgblsql = "select emp_tipo_envio, emp_cred_tot, emp_acum_cred from MTCEMP01 where emp_num = " & str$(lEmpNum) & " and eje_prefijo=" & Format$(igblPref) & " and gpo_banco=" & Format$(igblBanco)
                            // Modif. 18/Jun/2007 Calc Lim Real
                            CORVAR.pszgblsql = "select emp_tipo_envio, emp_cred_tot, emp_acum_cred = ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = " + Conversion.Str(lEmpNum);
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = " + Conversion.Str(lEmpNum);
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) ";
                            //    pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) "
							
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01 where emp_num = " + Conversion.Str(lEmpNum) + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
							
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {
                                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                                {
                                    pszTipoEnvio = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                                    lEmpCredTot = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                                    lEmpCredAcum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                                }
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
                            lEjeLimCred = CORVB.NULL_INTEGER;
							
                            //Obtenemos los datos a dar dalta
                            int iGpoBanco = CORVAR.igblBanco; //Banco del Grupo
                            int iEjeRoll = 9; //Roll Over
                            pszEjeNom = ID_MEE_NEJ_EB.Text.Trim(); //Nombre de Ejecutivo
                            pszEjeRFC = Strings.Mid(ID_MEE_RFC_EB.CtlText.Trim(), 1, 4);
                            pszEjeRFC = pszEjeRFC + Strings.Mid(ID_MEE_RFC_EB.CtlText.Trim(), 6, 6); //RFC
                            pszEjeRFC = pszEjeRFC + Strings.Mid(ID_MEE_RFC_EB.CtlText.Trim(), 13, 3);
                            int lEjeSueldo = Convert.ToInt32(Conversion.Val(ID_MEE_SDO_EB.CtlText));
                            //lNumNom = Val(ID_MEE_NOM_PIC.Text)                                  'Numero de Nomina /Modifica Yuria 25/10/06
                            string sNumNom = ID_MEE_NOM_PIC.CtlText.Trim(); //Se agrega esta variable Este módulo ya no se usa, la nómina era numérica //Numero de Nomina
							
                            if (ID_MEE_CCO_EB.SelectedIndex >= 0)
                            {
                                pszEjeCC = CRSGeneral.asgUnidades[0, ID_MEE_CCO_EB.SelectedIndex].Trim(); //Centro de Costos
                            } else
                            {
                                pszEjeCC = ID_MEE_CCO_EB.Text.Trim();
                            }
							
                            int iEjeNivel = Convert.ToInt32(Conversion.Val(slNivJerarquico)); //Nivel Jerárquico
                            pszEjeNomGra = ID_MEE_NCE_EB.Text.Trim(); //Nombre para grabación
                            ppszEjeCalle = ID_MEE_CNU_EB.Text.Trim(); //Calle
                            ppszEjeCol = ID_MEE_COL_EB.Text.Trim(); //Colonia
                            lEjeCP = Convert.ToInt32(Conversion.Val(ID_MEE_CP_PIC.CtlText)); //Código Postal
                            ppszEjePob = ID_MEE_POB_EB.Text.Trim(); //Población
                            iEjeZP = Convert.ToInt32(Conversion.Val(ID_MEE_ZPO_PIC.CtlText)); //Zona Postal
                            pszEjeTelDom = ID_MEE_TDO_PIC.CtlText.Trim(); //Teléfono de Domicilio
                            pszEjeTelOfi = ID_MEE_TOF_PIC.CtlText.Trim(); //Teléfono de Oficina
                            pszEjeExt = ID_MEE_EXT_PIC.CtlText.Trim(); //Extensión
                            pszEjeFax = ID_MEE_FAX_PIC.CtlText.Trim(); //Fax
                            lEjeLimCred = Convert.ToInt32(Conversion.Val(ID_MEE_LIM_FTB.CtlText)); //Límite de Crédito
                            int iRegNum = Convert.ToInt32(Conversion.Val(slRegion)); //Número de División Regional
                            iDiaCorte = Convert.ToInt32(Conversion.Val(ID_MEE_COR_PIC.CtlText)); //dia de corte
                            iSucTran = ilSucTransmisora; //sucursal transmisora
                            iSucProm = ilSucPromotora; //sucursal promotora
                            pszOrigen = slOrigen; //origen
                            pszActSubAct = slSubActividad; //Acti_subacti
                            ilGenPinPlastico = (int) ifncPinPlastico();

                            if (ID_MEE_FEM_OPB.Checked)
                            { //Sexo
                                pszSexo = "F";
                            } else
                            {
                                pszSexo = "M";
                            }
							
                            if (! Boolean.Parse(blTransmitir))
                            {
                                pszejeStatus = "T";
                            } else
                            {
                                pszejeStatus = "N";
                            }
							
                            //Verifica si se ingresó la descripción
                            if (ID_MEE_NEJ_EB.Text.Trim() != CORVB.NULL_STRING)
                            {
                                //Verifica que no se sobrepase el crédito de la empresa
                                //Eliminar una vez que se establesca una regla
                                //        If bfncExcepcionCredito = True Then GoTo OmiteValidacionLimiteCredito3
                                if ((lEmpCredAcum + lEjeLimCred) > lEmpCredTot)
                                {
                                    pszSumaCred = lEmpCredTot - lEmpCredAcum;
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("Se ha sobrepasado el crédito de la Empresa.Crédito dispuesto: " + Conversion.Str(pszSumaCred), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                                } else
                                {
									
                                    //Obtiene el consecutivo de la empresa
                                    CORVAR.pszgblsql = "exec spS_Obtiene_Consecutivo_Emp ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(lEmpNum) + ",";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(CORVAR.igblPref) + ",";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(CORVAR.igblBanco);
									
                                    if (CORPROC2.Obtiene_Registros() != 0)
                                    {
                                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                                        {
                                            iEjeNum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                                        }
                                    } else
                                    {
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("No se logro obtener el consecutivo de la empresa: " + StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa)), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                        return;
                                    }
                                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
									
                                    //Cambio para leer la longitud de la empresa y del ejecutivo
                                    pszTempCuenta = StringsHelper.Format(iEjePref, "0000") + StringsHelper.Format(CORVAR.igblBanco, "00") + StringsHelper.Format(lEmpNum, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(iEjeNum, Formato.sMascara(Formato.iTipo.Ejecutivo)) + "9";
									
                                    iDigito = CORPROC.Calcula_digito_verif(ref pszTempCuenta);
                                    pszTempCuenta = pszTempCuenta + iDigito.ToString();
									
                                    //Se arma la fecha al formato yyyymmdd
                                    pszFecha = Strings.Mid(DateTime.Today.ToString("yyyyMMdd"), 1, 10);
									
                                    //Formatea los campos para ser enviados al tandem
                                    dlgAlta.iFechaAlta = Int32.Parse(pszFecha);
                                    dlgAlta.sCuenta = pszTempCuenta;
                                    dlgAlta.iDiaCorte = iDiaCorte;
                                    dlgAlta.sNombreGrabacion = pszEjeNomGra;
                                    dlgAlta.sNombre = Strings.Mid(pszEjeNomGra, 1, pszEjeNomGra.IndexOf(','));
                                    dlgAlta.sApellidoPaterno = Strings.Mid(pszEjeNomGra, (pszEjeNomGra.IndexOf(',') + 1) + 1, (pszEjeNomGra.IndexOf('/') + 1) - (pszEjeNomGra.IndexOf(',') + 1) - 1);
                                    dlgAlta.sApellidoMaterno = pszEjeNomGra.Substring(pszEjeNomGra.Length - Math.Min(pszEjeNomGra.Length, pszEjeNomGra.Length - (pszEjeNomGra.IndexOf('/') + 1)));
                                    dlgAlta.sSexo = pszSexo;
                                    dlgAlta.iSucTransmisora = iSucTran;
                                    dlgAlta.iSucPromotora = iSucProm;
                                    dlgAlta.lLimiteCredito = lEjeLimCred;
                                    dlgAlta.sDomicilio = ID_MEE_CNU_EB.Text;
                                    dlgAlta.sColonia = ID_MEE_COL_EB.Text;
                                    dlgAlta.sPoblacion = ID_MEE_POB_EB.Text;
                                    //Implementar estado
                                    dlgAlta.sEstado = slEstadoEnv;
                                    dlgAlta.iZonaPostal = Convert.ToInt32(Conversion.Val(ID_MEE_ZPO_PIC.CtlText));
                                    dlgAlta.lCP = Convert.ToInt32(Conversion.Val(ID_MEE_CP_PIC.CtlText));
                                    dlgAlta.iNacionalidad = Convert.ToInt32(Conversion.Val(slNacionalidad));
                                    dlgAlta.iASActi = Convert.ToInt32(Conversion.Val(slSubActividad));
                                    dlgAlta.lTelOficina = Conversion.Val(ID_MEE_TOF_PIC.CtlText);
                                    dlgAlta.lTelParticular = Conversion.Val(ID_MEE_TDO_PIC.CtlText);
                                    dlgAlta.lExtension = Convert.ToInt32(Conversion.Val(ID_MEE_EXT_PIC.CtlText));
                                    dlgAlta.sRFC = Seguridad.fncsSustituir(ID_MEE_RFC_EB.CtlText.Trim(), "-", "");
                                    dlgAlta.iGeneraPinPlastico = ilGenPinPlastico;
                                    dlgAlta.sTipoCta = CRSParametros.cteIndividual;
                                    dlgAlta.iSkipPayment = ilSkipPayment;
                                    dlgAlta.iIdTablaMCC = ilTablaMCC;
                                    dlgAlta.dLimiteDisposiciones = Conversion.Val(txtDisEfectivo.defaultText);
                                    //Descomentar en Producción
                                    dlgAlta.sCuentaReferencia = slCuentaPadre;
                                    dlgAlta.sTipoFacturacion = slTipoFactura;
									
                                    CRSDialogo.Dialogo(ref pszMensaje, dlgAlta, CRSDialogo.TipoAlta.cteAltaS111);
                                    CRSDialogo.Dialogo(ref pszMensajeS016, dlgAlta, CRSDialogo.TipoAlta.cteAltaS016);
									
                                    //Eliminar en Producción
                                    //prLog "Alta del Ejecutivo: " & pszgblsql
									
                                    //La conexion hacia el tandem ya debe estar lista
                                    ConexionRut.Termina_Conexion();
                                    bConexion = ConexionRut.Inicia_Conexion();
									
                                    if (bConexion)
                                    { //Si la función es verdadera se actualiza en el M111 al tarjetahabiente
                                        //Configura los datos del ejecutivo
                                        ejelEjecutivo.sNombre = pszEjeNomGra.Trim();
                                        ejelEjecutivo.sCalle = ppszEjeCalle.Trim();
                                        ejelEjecutivo.sColonia = ppszEjeCol.Trim();
                                        ejelEjecutivo.sCiudad = ppszEjePob.Trim();
                                        ejelEjecutivo.sTipoCuenta = "Básica";
                                        ejelEjecutivo.sSucursal = iSucTran.ToString().Trim();
                                        ejelEjecutivo.sCorte = iDiaCorte.ToString().Trim();
                                        ejelEjecutivo.sSexo = pszSexo.Trim();
                                        ejelEjecutivo.sTelDomicilio = Conversion.Val(pszEjeTelDom.Trim()).ToString();
                                        ejelEjecutivo.sTelOficina = Conversion.Val(pszEjeTelOfi.Trim()).ToString();
                                        ejelEjecutivo.sExt = Conversion.Val(pszEjeExt).ToString();
                                        ejelEjecutivo.sFecAlta = Strings.Mid(pszFecha, 3, 6).Trim();
										
                                        OLERut.Conexion tempRefParam = ConexionRut;
                                        ilBanderaAltaS016 = StringsHelper.IntValue(CRSGeneral.vfncVPO(CRSDialogo.ifncEnviaDialogo(ref tempRefParam, ref lNumNom, ref pszMensajeS016, ref sEnviaRut, ref pszTempCuenta, ref ejelEjecutivo, CRSDialogo.TipoAlta.cteAltaS016).ToString(), "0"));
                                        ConexionRut = tempRefParam;
										
										
                                        if (ilBanderaAltaS016 == CRSDialogo.cteAltaS016OK)
                                        {
                                            OLERut.Conexion tempRefParam2 = ConexionRut;
                                            ilBanderaAltaS111 = StringsHelper.IntValue(CRSGeneral.vfncVPO(CRSDialogo.ifncEnviaDialogo(ref tempRefParam2, ref lNumNom, ref pszMensaje, ref sEnviaRut, ref pszTempCuenta, ref ejelEjecutivo, CRSDialogo.TipoAlta.cteAltaS111).ToString(), "0"));
                                            ConexionRut = tempRefParam2;
                                            //Evalua los casos para realizar la alta del c430
                                            if (ilBanderaAltaS111 == CRSDialogo.cteAltaS111OK)
                                            {
                                                ilBanderaAlta = CRSDialogo.cteAltaOK;
                                            } else
                                            {
                                                if (ilBanderaAlta == ((int) CRSDialogo.MensajesS111.cteExisteEnS111))
                                                {
                                                    MessageBox.Show("La cuenta " + dlgAlta.sCuenta + " ya existe en el Sistema S111" + "\r\n" + "Realice una consulta para asegurarse de que se trate de la misma.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    MessageBox.Show("La cuenta " + dlgAlta.sCuenta + " se dió de alta en el Sistema S016 Satisfactoriamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    ilBanderaAlta = CRSDialogo.cteAltaOK;
                                                } else if (ilBanderaAlta == ((int) CRSDialogo.MensajesS111.cteIncInfoS111)) { 
                                                    ilBanderaAlta = CRSDialogo.cteAltaOK;
                                                } else
                                                {
                                                    MessageBox.Show("La cuenta " + dlgAlta.sCuenta + " no se dió de alta en el S111" + "\r\n" + "Realice una consulta para verificar esta cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ilBanderaAlta = CRSDialogo.cteAltaOK;
                                                }
                                            }
                                        } else
                                        {
                                            ilBanderaAlta = CRSDialogo.cteAltaS016NO;
                                        }
										
                                        if (ilBanderaAlta == CRSDialogo.cteAltaOK)
                                        { //Si se da de alta en el S111 entonces entonces se realiza la alta dentro de Sybase
                                            CORVAR.pszgblsql = "exec spI_Alta_Tarjetahabiente " + Conversion.Str(iEjePref) + "," + Conversion.Str(CORVAR.igblBanco) + ",";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(lEmpNum) + "," + Conversion.Str(iEjeNum) + "," + Conversion.Str(iEjeRoll) + "," + Conversion.Str(iDigito);
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CORPROC.Valida_Comilla(pszEjeNom) + "','" + pszEjeRFC + "',";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(lEjeSueldo) + ",'" + Conversion.Str(lNumNom) + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CORPROC.Valida_Comilla(pszEjeCC) + "'," + Conversion.Str(iEjeNivel);
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CORPROC.Valida_Comilla(pszEjeNomGra) + "','";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + CORPROC.Valida_Comilla(ppszEjeCalle) + "','";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + CORPROC.Valida_Comilla(ppszEjeCol) + "','";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + CORPROC.Valida_Comilla(ppszEjePob) + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " , '" + slEstadoEnv + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + " ," + Conversion.Str(iEjeZP);
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "," + Conversion.Str(lEjeCP);
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + pszEjeTelDom + "','";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + pszEjeTelOfi + "','" + pszEjeExt + "','" + pszEjeFax;
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "'," + Conversion.Str(lEjeLimCred) + "," + Conversion.Str(iRegNum);
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + pszejeStatus + "','";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + pszSexo + "','" + Conversion.Str(iSucTran).Trim() + "','" + Conversion.Str(iSucProm).Trim();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + "','" + pszOrigen + "','" + pszActSubAct + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slDomCalle + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slDomColonia + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slDomCiudad + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slDomPoblacion + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slDomEstado + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + llDomCodigoPostal.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + txtMail.Text.Trim() + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + txtCContable.Text.Trim() + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilGenPinPlastico.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + llLimDispEfectivo.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slUsuarioCambio + "'";
                                            //UPGRADE_WARNING: (1068) slTipoCuenta of type Variant is being forced to string.
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + Convert.ToString(slTipoCuenta) + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slTipoFactura + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilSkipPayment.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilTablaMCC.ToString();
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'P'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slNacionalidad + "'";
                                            CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slIndCtaControl + "'";
											
                                            //FSWB NR 20070222
                                            //CAMBIO???
                                            //BORRAR pszgblsql = pszgblsql & ", '" &  & "'"
                                            //BORRAR pszgblsql = pszgblsql & ", " &
                                            //FSWB NR 20070222
											
                                            //Comentar en Producción
                                            //prLog "INSERT EJECUTIVO " & Now & pszgblsql
											
                                            if (CORPROC2.Modifica_Registro() != 0)
                                            {
                                                bAltaNuevamente = true;
                                                this.Cursor = Cursors.Default;
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                                Interaction.MsgBox(STR_ALTA_EJE + pszTempCuenta, CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                                                this.Cursor = Cursors.WaitCursor;
                                            } else
                                            {
                                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                                Interaction.MsgBox("No se puede dar de alta el ejecutivo", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                                                return;
                                            }
                                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
											
                                        } else if (sEnviaRut == "Existe") {  //Si la cta ya existe
                                            iNoIntentos++;
                                            if (iNoIntentos > 5)
                                            {
                                                iNoIntentos = CORVB.NULL_INTEGER;
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                                Interaction.MsgBox("Ya existe la cuenta. Por favor intente más tarde.", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                                                return;
                                            } else
                                            {
                                                Alta_Ejecutivo();
                                            }
											
                                        } else
                                        {
                                            //Es un error de comunicaciones
                                            return;
                                        }
                                    }
									
                                    if (iEjeNum >= Formato.lfncTop(Formato.igLongitudEjecutivo))
                                    {
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("Se deberá crear una nueva empresa para los ejecutivo." + "\r" + "Se ha llegado al límite de " + Formato.lfncTop(Formato.igLongitudEjecutivo).ToString() + " tarjetahabientes.", CORVB.MB_ICONSTOP, CORSTR.STR_APP_TIT);
                                    }
									
                                    if (bAltaNuevamente)
                                    { //Se limpia la forma para dar una nueva alta si se realizo el alta o hubo reenvío
                                        ID_MEE_NEJ_EB.Text = CORVB.NULL_STRING;
                                        ID_MEE_RFC_EB.SelStart = 0;
                                        ID_MEE_RFC_EB.SelLength = Strings.Len(ID_MEE_RFC_EB.defaultText);
                                        ID_MEE_RFC_EB.SelText = "";
                                        ID_MEE_RFC_EB.Mask = "????-######-&&&";
                                        ID_MEE_SDO_EB.CtlText = CORVB.NULL_STRING;
                                        ID_MEE_NOM_PIC.CtlText = CORVB.NULL_STRING;
                                        ID_MEE_CCO_EB.SelectedIndex = -1;
                                        slNivJerarquico = CORVB.NULL_STRING;
                                        ID_MEE_NCE_EB.Text = CORVB.NULL_STRING;
                                        ID_MEE_TDO_PIC.CtlText = CORVB.NULL_STRING;
                                        ID_MEE_TOF_PIC.CtlText = CORVB.NULL_STRING;
                                        ID_MEE_EXT_PIC.CtlText = CORVB.NULL_STRING;
                                        ID_MEE_FAX_PIC.CtlText = CORVB.NULL_STRING;
                                        ID_MEE_LIM_FTB.CtlText = CORVB.NULL_STRING;
                                        ID_MEE_FEM_OPB.Checked = true;
                                        ID_MEE_MAS_OPB.Checked = false;
                                        ID_MEJ_CTA_EB.Text = CORVB.NULL_STRING;
                                        if (pszTipoEnvio != "E")
                                        {
                                            ID_MEE_CNU_EB.Text = CORVB.NULL_STRING;
                                            ID_MEE_COL_EB.Text = CORVB.NULL_STRING;
                                            ID_MEE_POB_EB.Text = CORVB.NULL_STRING;
                                            ID_MEE_CP_PIC.CtlText = CORVB.NULL_STRING;
                                            ID_MEM_EDO_EB[1].SelectedIndex = -1;
                                            ID_MEE_ZPO_PIC.CtlText = CORVB.NULL_INTEGER.ToString();
                                        }
                                    }
									
                                    //Limpia los elemetos adicionales
									
                                    //***** Folder 0 de Generales *****
                                    txtDisEfectivo.defaultText = CORVB.NULL_INTEGER.ToString();
                                    txtMail.Text = CORVB.NULL_STRING;
									
                                    //***** Folder 1 de Domicilio *****
                                    ID_MEM_DOM_EB[0].Text = CORVB.NULL_STRING;
                                    ID_MEM_COL_EB[0].Text = CORVB.NULL_STRING;
                                    ID_MEM_PDM_EB[0].Text = CORVB.NULL_STRING;
                                    ID_MEM_CIU_EB[0].Text = CORVB.NULL_STRING;
                                    ID_MEM_EDO_EB[0].SelectedIndex = -1;
                                    ID_MEM_CP_PIC[0].defaultText = CORVB.NULL_STRING;
                                    ID_MEE_TDO_PIC.defaultText = CORVB.NULL_STRING;
                                    ID_MEE_NEJ_EB.Focus();
									
                                    //***** Folder 2 de Domicilio *****
                                    chkPinPlastico[0].CheckState = CheckState.Checked;
                                    chkPinPlastico[1].CheckState = CheckState.Checked;
                                    chkCuentaControl.CheckState = CheckState.Unchecked;
                                    //mskMCC = ilTablaMCCHeredado yuria comenta 15/11/06
                                    mskMCC.CtlText = ilTablaMCCHeredado.ToString();
                                    optNacionalidad[0].Checked = true;
                                    chkSkipPayment.CheckState = ilSkipPaymentHeredado;
                                }
                            } else
                            {
                                this.Cursor = Cursors.Default;
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("No se dió de alta la descripción", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                            }
							
                            if (ID_MEE_NEJ_EB.Enabled)
                            {
                                ID_MEE_NEJ_EB.Focus();
                            }
							
                            this.Cursor = Cursors.Default;
                        }
                    catch (Exception exc)
                    {
                        throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
                    }
					
            }
        */
        private void txtMail_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (Strings.Len(txtMail.Text) > 0)
            {
                if ((txtMail.Text.IndexOf('@') + 1) == 0 || (txtMail.Text.IndexOf('@') + 1) == 1 || (txtMail.Text.IndexOf('@') + 1) == Strings.Len(txtMail.Text))
                {
                    Cancel = true;
                    MessageBox.Show("Dirección de Correo electrónico incorrecta." + "\r\n" + "Verifique la dirección.", "Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            eventArgs.Cancel = Cancel;
        }

        private void prInicializaVariables()
        {
            slDomCalle = String.Empty;
            slDomColonia = String.Empty;
            slDomCiudad = String.Empty;
            slDomPoblacion = String.Empty;
            slDomEstado = String.Empty;
            llDomCodigoPostal = 0;
            objRfcEje = new clsRFC();

        }

        public bool bfncValidaRFCEJE(string spRFC)
        {
            bool result = false;
            int ilDia = 0;
            int ilMes = 0;
            int ilAño = 0;
            string slHomoclave = String.Empty;
            string slSiglas = String.Empty;
            string slTitulo = String.Empty;
            try
            {
                spRFC = Seguridad.fncsSustituir(spRFC.Trim(), "-", "");
                slTitulo = "RFC Incorrecto";

                switch (spRFC.Length)
                {
                    case 10:  //AAAA800101 Persona Fisica sin Homoclave 
                        slSiglas = Strings.Mid(spRFC, 1, 4).Trim();
                        ilDia = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 9, 2).Trim()));
                        ilMes = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 7, 2).Trim()));
                        ilAño = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 5, 2).Trim()));
                        slHomoclave = "";
                        break;
                    case 12:  //AAA800101YYY  Persona Moral 
                        slSiglas = Strings.Mid(spRFC, 1, 3).Trim();
                        ilDia = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 8, 2).Trim()));
                        ilMes = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 6, 2).Trim()));
                        ilAño = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 4, 2).Trim()));
                        slHomoclave = Strings.Mid(spRFC, 10, 3).Trim();
                        break;
                    case 13:  //AAAA800101UUU  Persona Física con homoclave 
                        slSiglas = Strings.Mid(spRFC, 1, 4).Trim();
                        ilDia = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 9, 2).Trim()));
                        ilMes = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 7, 2).Trim()));
                        ilAño = Convert.ToInt32(Conversion.Val(Strings.Mid(spRFC, 5, 2).Trim()));
                        slHomoclave = Strings.Mid(spRFC, 11, 3).Trim();
                        break;
                    default:
                        MessageBox.Show("RFC incompleto" + "\r\n" + "Verifique el RFC.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                }

                //Valida Siglas
                for (int ilIndice = 1; ilIndice <= slSiglas.Length; ilIndice++)
                {
                    int switchVar = (int)Strings.Mid(slSiglas, ilIndice, 1).ToUpper()[0];
                    if (switchVar >= 65 && switchVar <= 90)
                    {
                        slSiglas = StringsHelper.MidAssignment(slSiglas, ilIndice, Strings.Mid(slSiglas, ilIndice, 1).ToUpper());
                    }
                    else
                    {
                        MessageBox.Show("RFC incorrecto" + "\r\n" + "Caracter no valido en las siglas del RFC", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                //Valida Año
                if (!(ilAño >= 0 && ilAño <= 99))
                {
                    MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el Año.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                //Valida Mes
                if (!(ilMes > 0 && ilMes <= 12))
                {
                    MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el Mes.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //Valida el Día del RFC
                if (ilMes == 1 || ilMes == 3 || ilMes == 5 || ilMes == 7 || ilMes == 8 || ilMes == 10 || ilMes == 12)
                {
                    if (ilDia >= 1 && ilDia <= 31)
                    {
                    }
                    else
                    {
                        MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el día.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else if (ilMes == 4 || ilMes == 6 || ilMes == 9 || ilMes == 11)
                {
                    if (ilDia >= 1 && ilDia <= 30)
                    {
                    }
                    else
                    {
                        MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el día.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else if (ilMes == 2)
                {
                    if (ilDia >= 1 && ilDia <= 29)
                    {
                        if (!Information.IsDate(StringsHelper.Format(ilDia, "00") + "/" + StringsHelper.Format(ilMes, "00") + "/" + StringsHelper.Format(ilAño, "00")))
                        {
                            MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el día.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("RFC incorrecto" + "\r\n" + "Verifique el día.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                //Valida la Homoclave
                if (slHomoclave.Trim() == "" && Seguridad.fncsSustituir(spRFC, "-", "").Trim().Length == 10)
                {
                    result = true;
                    if (slHomoclave.Length != 3 || slHomoclave.Length != 0)
                    {
                        if (!result)
                        {
                            MessageBox.Show("RFC incorrecto" + "\r\n" + "Homoclave incompleta o no válida.", slTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                CRSGeneral.prObtenError("ValidaRFC");
            }
            return result;
        }

        private void _optEjecutivos_0_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optEjecutivos, sender);
            optEjecutivos_Click(Index);
        }

        private void _optEjecutivos_1_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optEjecutivos, sender);
            optEjecutivos_Click(Index);
        }

        private void _optEjecutivos_2_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optEjecutivos, sender);
            optEjecutivos_Click(Index);
        }

        private void ID_MEE_MAS_OPB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == ((int)"\t"[0]))
            {
                Fichero(1);
            }
        }

        private void _optNacionalidad_0_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optNacionalidad, sender);
            optNacionalidad_Click(Index);
        }

        private void _optNacionalidad_1_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optNacionalidad, sender);
            optNacionalidad_Click(Index);
        }

        private void _ID_MEM_TFA_3OPB_0_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optNacionalidad, sender);
            ID_MEM_TFA_3OPB_Click(Index);
        }

        private void _ID_MEM_TFA_3OPB_1_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optNacionalidad, sender);
            ID_MEM_TFA_3OPB_Click(Index);
        }
    }
}