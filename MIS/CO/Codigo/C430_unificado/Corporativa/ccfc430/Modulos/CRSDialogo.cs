using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;


namespace TCc430
{
    class CRSDialogo
    {

        //Costantes de Respuesta de Diálogo
        public const int cteAltaS111OK = 1; //Se realizó el alta satisfactoriamente en el S111
        public const int cteAltaS016OK = 2; //Se realizó el alta satisfactoriamente en el S016
        public const int cteAltaOK = 3;
        public const int cteAltaNO = 4;
        public const int cteAltaS111NO = 5; //No se realizó el alta en el S111
        public const int cteAltaS016NO = 6; //No se realizó el alta en el S016
        public const int cteConsultaS111OK = 0; //Se realizó la consulta al S111 satistfactoriamente
        public const int cteConsultaS111NO = 1; //No se realizó la consulta al S111 satisfactoriamente

        public const int cteErrorComunicaciones = -1; //Indica que no se puede enlazar un diálogo

        //Constantes de mensaje del S111
        public enum MensajesS111
        {
            cteExisteEnS111 = 30, //Ya existe la cuenta en el S111
            cteIncInfoS111 = 11 //Indica que hubo inconsitencia
        }

        //Constantes de mensaje del S016
        public enum MensajesS016
        {
            cteExisteEnS016 = 5, //Ya existe la cuenta en el S111
            cteErrComS016 = 11 //Indica que hubo error de comunicaciones hacia el S016
        }

        public enum TipoAlta
        {
            cteAltaS111 = 1,
            cteAltaS016 = 2,
            cteAltaS111ComDrv = 3,
            cteAltaS016ComDrv = 4
        }

        //public enum TipoAlta
        // {
        //    cteAltaS111 = 1 ,
        //    cteAltaS016 = 2
        //}

        public enum TipoSistema
        {
            cteSistemaC430 = 0, //Sistema C430
            cteSistemaS111 = 1, //Sistema S111
            cteSistemaS016 = 2, //Sistema S016
            cteSistemaTandem = 3 //Sistema TANDEM
        }

        //Constantes de Tipo de Cambio que se van al S111
        public enum TipoCambioS111
        {
            cteNombre = 2,
            cteCredito = 3,
            cteDomicilio = 4,
            cteMcc = 5,
            // APQ 1-Jul-2010 Inicio - Cambio Tipo de Bloqueo
            cteSkip = 6,
            cteTipBloq = 7
            // APQ 1-Jul-2010 Fin - Cambio Tipo de Bloqueo

        }

        public const string cteC430 = "c430";
        public const string cteS111 = "S111";
        public const string cteS016 = "S016";
        public const string cteTandem = "tandem";

        //LMHR & CMET: Se agrega constante para Datos Identificación(Layout 5566-01)
        public const string cteIdentificacion = "101599"; //Se solicito el cambio de 100299 => 101599 17/01/2018 

        static public int[,] aigLongitudes = null;

        public struct mtcEmpresa
        {
            public int iPrefijo;
            public int iBanco;
            public int lNumEmpresa;
            public int lCorporativo;
            public int ejx_numero;

            public string sNombreEmpresa;
            public string sNomGrabadoEmpresa;
            public string sEmpRFC;

            public double num_cartera;

            public string sEmpPrincipalAcc;
            public byte sEmpSector;
            public int lEmpCreditoTotal;
            public int lEmpCreditoAcum;
            public System.DateTime dEmpFecVencCred;
            public string sEmpDomFisCalle;
            public string sEmpDomFisColonia;
            public string sEmpDomFisCiudad;
            public string sEmpDomFisPoblacion;
            public string sEmpDomFisEstado;
            public int sEmpDomFisCodPostal;
            public string sEmpTelefono;
            public string sEmpExtension;
            public string sEmpLadaTelefono;
            public string sEmpFax;
            public string sEmpLadaFAX;

            public string param_modem;
            public int vel_transmis;

            public string sEmpEmail;
            public string sEmpInternet;
            public string sEmpDomEnvCalle;
            public string sEmpDomEnvColonia;
            public string sEmpDomEnvCiudad;
            public string sEmpDomEnvPoblacion;
            public string sEmpDomEnvEstado;
            public int sEmpDomEnvCodPostal;
            public double sEmpCuentaCheques;
            public int sEmpSucursalCuentaCheques;
            public string sEmpTipoPago;
            public string sEmpTipoEnvio;

            public string sEmpRep1Nombre;
            public string sEmpRep1Puesto;
            public string sEmpRep1Telefono;
            public string sEmpRep1Extension;
            public string sEmpRep1Fax;
            public PictureBox sEmpRep1Firma;

            public string sEmpRep2Nombre;
            public string sEmpRep2Puesto;
            public string sEmpRep2Telefono;
            public string sEmpRep2Extension;
            public string sEmpRep2Fax;
            public PictureBox sEmpRep2Firma;

            public string sEmpRep3Nombre;
            public string sEmpRep3Puesto;
            public string sEmpRep3Telefono;
            public string sEmpRep3Extension;
            public string sEmpRep3Fax;
            public PictureBox sEmpRep3Firma;

            //Calcular Consecutivo de Ejecutivo
            public int iConsecutivoEjecutivo;

            public int iEmpDiaCorte;
            public int iEmpPlazoGracia;
            public int iEmpPlazoNoCobInteres;
            public int iEmpGenerarSBF;
            public string sEmpTipoFacturacion;
            public string sEmpEsquemaPago;
            public string sEmpTipoProducto;

            public int lEmpEstructGastos;
            public int iEmpMesFiscal;
            public int iEmpLimDisEfec;
            public double dEmpMinimoFacturacion;
            public string sEmpCuentaContable;
            public int iEmpSkipPaymentFlag;
            public int lEmpTablaMCC;
            public string sEmpUsuarioCam;
            public int lEmpFechaAlta;
            public int lEmpFechaCam;
            public int lEmpHoraCam;
            public static mtcEmpresa CreateInstance()
            {
                mtcEmpresa result = new mtcEmpresa();
                result.sNombreEmpresa = String.Empty;
                result.sNomGrabadoEmpresa = String.Empty;
                result.sEmpRFC = String.Empty;
                result.sEmpPrincipalAcc = String.Empty;
                result.sEmpDomFisCalle = String.Empty;
                result.sEmpDomFisColonia = String.Empty;
                result.sEmpDomFisCiudad = String.Empty;
                result.sEmpDomFisPoblacion = String.Empty;
                result.sEmpDomFisEstado = String.Empty;
                result.sEmpTelefono = String.Empty;
                result.sEmpExtension = String.Empty;
                result.sEmpLadaTelefono = String.Empty;
                result.sEmpFax = String.Empty;
                result.sEmpLadaFAX = String.Empty;
                result.param_modem = String.Empty;
                result.sEmpEmail = String.Empty;
                result.sEmpInternet = String.Empty;
                result.sEmpDomEnvCalle = String.Empty;
                result.sEmpDomEnvColonia = String.Empty;
                result.sEmpDomEnvCiudad = String.Empty;
                result.sEmpDomEnvPoblacion = String.Empty;
                result.sEmpDomEnvEstado = String.Empty;
                result.sEmpTipoPago = String.Empty;
                result.sEmpTipoEnvio = String.Empty;
                result.sEmpRep1Nombre = String.Empty;
                result.sEmpRep1Puesto = String.Empty;
                result.sEmpRep1Telefono = String.Empty;
                result.sEmpRep1Extension = String.Empty;
                result.sEmpRep1Fax = String.Empty;
                result.sEmpRep2Nombre = String.Empty;
                result.sEmpRep2Puesto = String.Empty;
                result.sEmpRep2Telefono = String.Empty;
                result.sEmpRep2Extension = String.Empty;
                result.sEmpRep2Fax = String.Empty;
                result.sEmpRep3Nombre = String.Empty;
                result.sEmpRep3Puesto = String.Empty;
                result.sEmpRep3Telefono = String.Empty;
                result.sEmpRep3Extension = String.Empty;
                result.sEmpRep3Fax = String.Empty;
                result.sEmpTipoFacturacion = String.Empty;
                result.sEmpEsquemaPago = String.Empty;
                result.sEmpTipoProducto = String.Empty;
                result.sEmpCuentaContable = String.Empty;
                result.sEmpUsuarioCam = String.Empty;
                return result;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct mtcEjecutivo
        {
            public int iEjePrefijo;
            public int iGpoBanco;
            public int lEmpNum;
            public int lEjeNum;
            public int iEjeRollOver;
            public int iEjeDigit;
            public string sEjeNombre;
            public string sEjeRFC;
            public int lEjeSueldo;
            public string sEjeNumNom;
            public string sEjeCentroCosto;
            public int iEjeNivel;
            public string sEjeNomGrabado;
            public int iNacionalidad;
            public string sEjeCalle;
            public string sEjeColonia;
            public string sEjePoblacion;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 4)]
            public string sEjeEstado;
            public int iEjeZP;
            public int lEjeCP;
            public string sEjeTelefonoDomicilio;
            public string sEjeTelefonoOficina;
            public string sEjeExtension;
            public string sEjeFax;
            public int lEjeLimiteCredito;
            public int lRegNum;
            public string sEjeStatus;
            public string sEjeCuentaBanamex;
            public string sEjeSexo;
            public string sEjeSucTrans;
            public string sEjeSucPromotora;
            public string sEjeOrigen;
            public string sEjeActiSubacti;
            public string sEjeDomCalle;
            public string sEjeDomColonia;
            public string sEjeDomCiudad;
            public string sEjeDomPoblacion;
            public string sEjeDomEstado;
            public int lEjeDomCP;
            public string sEjeEmail;
            public string sEjeCtaContable;
            public int iEjeGenPinPla;
            public int lEjeLimDisEfec;
            public string sEjeTipoCuenta;
            public string sTipoFacturacion;
            public int iSkipPaymentFlag;
            public int iTablaMCC;
            public string sIndicadorLimDisp;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sEjeCuentaPadre;
            public string sEjeUsuarioCam;
            public int lEjeFechaAlta;
            public int lEjeFechaCam;
            public int lEjeHoraCam;
            public static mtcEjecutivo CreateInstance()
            {
                mtcEjecutivo result = new mtcEjecutivo();
                result.sEjeNombre = String.Empty;
                result.sEjeRFC = String.Empty;
                result.sEjeNumNom = String.Empty;
                result.sEjeCentroCosto = String.Empty;
                result.sEjeNomGrabado = String.Empty;
                result.sEjeCalle = String.Empty;
                result.sEjeColonia = String.Empty;
                result.sEjePoblacion = String.Empty;
                result.sEjeTelefonoDomicilio = String.Empty;
                result.sEjeTelefonoOficina = String.Empty;
                result.sEjeExtension = String.Empty;
                result.sEjeFax = String.Empty;
                result.sEjeStatus = String.Empty;
                result.sEjeCuentaBanamex = String.Empty;
                result.sEjeSexo = String.Empty;
                result.sEjeSucTrans = String.Empty;
                result.sEjeSucPromotora = String.Empty;
                result.sEjeOrigen = String.Empty;
                result.sEjeActiSubacti = String.Empty;
                result.sEjeDomCalle = String.Empty;
                result.sEjeDomColonia = String.Empty;
                result.sEjeDomCiudad = String.Empty;
                result.sEjeDomPoblacion = String.Empty;
                result.sEjeDomEstado = String.Empty;
                result.sEjeEmail = String.Empty;
                result.sEjeCtaContable = String.Empty;
                result.sEjeTipoCuenta = String.Empty;
                result.sTipoFacturacion = String.Empty;
                result.sIndicadorLimDisp = String.Empty;
                result.sEjeUsuarioCam = String.Empty;
                return result;
            }
        }


        public struct DatosDialogo
        {
            public int iFechaAlta;
            public string sCuenta;
            public int iDiaCorte;
            public string sNombreGrabacion;
            public string sNombre;
            public string sApellidoPaterno;
            public string sApellidoMaterno;
            public string sSexo;
            public int iSucTransmisora;
            public int iSucPromotora;
            public int lLimiteCredito;
            public string sDomicilio;
            public string sColonia;
            public string sPoblacion;
            public string sEstado;
            public int iZonaPostal;
            public int lCP;
            public int iASActi;
            public double lTelParticular;
            public double lTelOficina;
            public int lExtension;
            public string sRFC;
            public int iGeneraPinPlastico;
            public string sTipoCta;
            public int iSkipPayment;
            public int iIdTablaMCC;
            public double dLimiteDisposiciones;
            public string sCuentaReferencia;
            public string sTipoFacturacion;
            public int iNacionalidad;
            public int lFechaNacimiento;
            public string sAtencionA; //FSWB NR 20070223 Se incluyen campos Atencion A y Persona
            public int iPersona; //FSWB NR 20070223
            private clsEstado mvariEstado;

            public clsEstado iEstado
            {
                get
                {
                    return mvariEstado;
                }
                set
                {
                    mvariEstado = value;
                }
            }

            public static DatosDialogo CreateInstance()
            {
                DatosDialogo result = new DatosDialogo();
                result.sCuenta = String.Empty;
                result.sNombreGrabacion = String.Empty;
                result.sNombre = String.Empty;
                result.sApellidoPaterno = String.Empty;
                result.sApellidoMaterno = String.Empty;
                result.sSexo = String.Empty;
                result.sDomicilio = String.Empty;
                result.sColonia = String.Empty;
                result.sPoblacion = String.Empty;
                result.sEstado = String.Empty;
                result.sRFC = String.Empty;
                result.sTipoCta = String.Empty;
                result.sCuentaReferencia = String.Empty;
                result.sTipoFacturacion = String.Empty;
                result.sAtencionA = String.Empty;
                result.iEstado = new clsEstado();
                return result;
            }
        }

        //Este type se Utiliza para recabar los datos a comparar del diálog y del ejecutivo
        public struct DatosEjecutivo
        {
            public string sNombre;
            public string sCalle;
            public string sColonia;
            public string sCiudad;
            public string sCP;
            public string sTipoCuenta;
            public string sSucursal;
            public string sCorte;
            public string sSexo;
            public string sTelDomicilio;
            public string sTelOficina;
            public string sExt;
            public string sFecAlta;
            public string sFecModificacion;
            public string sLimiteCredito;
            public static DatosEjecutivo CreateInstance()
            {
                DatosEjecutivo result = new DatosEjecutivo();
                result.sNombre = String.Empty;
                result.sCalle = String.Empty;
                result.sColonia = String.Empty;
                result.sCiudad = String.Empty;
                result.sCP = String.Empty;
                result.sTipoCuenta = String.Empty;
                result.sSucursal = String.Empty;
                result.sCorte = String.Empty;
                result.sSexo = String.Empty;
                result.sTelDomicilio = String.Empty;
                result.sTelOficina = String.Empty;
                result.sExt = String.Empty;
                result.sFecAlta = String.Empty;
                result.sFecModificacion = String.Empty;
                result.sLimiteCredito = String.Empty;
                return result;
            }
        }
        static public DatosDialogo gdteDatosEmpresa = CRSDialogo.DatosDialogo.CreateInstance();
        //Public Enum RFC
        //    rfcSiglas = 1
        //    rfcFecha = 2
        //    rfcHomoclave = 3
        //End Enum


        static public void Dialogo(ref  string sDialogo, DatosDialogo dlgDialogo, TipoAlta ipTipoAlta)
        {
            int lpNumNom = 0;
            try
            {
                int llFolio = 0;

                sDialogo = new String(' ', 1178);
                llFolio = lpNumNom;
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1, "C430"); //Sistema
                sDialogo = StringsHelper.MidAssignment(sDialogo, 5, CORBD.PROCESO_ALTA); //Clave de proceso
                sDialogo = StringsHelper.MidAssignment(sDialogo, 8, StringsHelper.Format(CORBD.TIPO_ALTA, "00")); //Clave tipo de alta
                sDialogo = StringsHelper.MidAssignment(sDialogo, 10, CORBD.TIPO_TRAMITE); //Clave tipo de trámite
                sDialogo = StringsHelper.MidAssignment(sDialogo, 12, StringsHelper.Format(llFolio, "00000000")); //Número de Folio
                sDialogo = StringsHelper.MidAssignment(sDialogo, 20, StringsHelper.Format(CORVB.NULL_INTEGER, "000000000000")); //Numero de Nómina
                sDialogo = StringsHelper.MidAssignment(sDialogo, 32, CORBD.TIPO_TRANSACCION); //Transacción
                sDialogo = StringsHelper.MidAssignment(sDialogo, 36, Seguridad.fncsSustituir(dlgDialogo.sCuenta, "'", "")); //Cuenta
                sDialogo = StringsHelper.MidAssignment(sDialogo, 52, Seguridad.fncsSustituir(dlgDialogo.sNombreGrabacion, "'", "")); //Nombre
                sDialogo = StringsHelper.MidAssignment(sDialogo, 78, Seguridad.fncsSustituir(dlgDialogo.sSexo, "'", "")); //Sexo
                sDialogo = StringsHelper.MidAssignment(sDialogo, 79, StringsHelper.Format(dlgDialogo.iDiaCorte, "00")); //Format(iDiaCorte, "00") 'iDiaCorte               'Dia de Corte
                sDialogo = StringsHelper.MidAssignment(sDialogo, 81, StringsHelper.Format(Conversion.Str(dlgDialogo.iSucTransmisora), "0000")); //Sucursal Transmisora
                sDialogo = StringsHelper.MidAssignment(sDialogo, 85, StringsHelper.Format(Conversion.Str(dlgDialogo.iSucPromotora), "0000")); //Sucursal Promotora
                sDialogo = StringsHelper.MidAssignment(sDialogo, 89, StringsHelper.Format(Conversion.Str(dlgDialogo.lLimiteCredito), "000000000")); //Límite de Crédito
                sDialogo = StringsHelper.MidAssignment(sDialogo, 98, StringsHelper.Format(dlgDialogo.iFechaAlta, "00000000")); //Fecha Alta
                sDialogo = StringsHelper.MidAssignment(sDialogo, 106, CORBD.TIPO_ORIGEN); //Origen
                sDialogo = StringsHelper.MidAssignment(sDialogo, 107, Seguridad.fncsSustituir(dlgDialogo.sDomicilio, "'", "")); //ID_MEE_CNU_EB.Text     'Calle y Número
                sDialogo = StringsHelper.MidAssignment(sDialogo, 142, Seguridad.fncsSustituir(dlgDialogo.sColonia, "'", "")); //ID_MEE_COL_EB.Text     'Colonia/Población/Fracc.
                sDialogo = StringsHelper.MidAssignment(sDialogo, 167, Seguridad.fncsSustituir(dlgDialogo.sPoblacion, "'", "")); //ID_MEE_POB_EB.Text     'Poblacion
                sDialogo = StringsHelper.MidAssignment(sDialogo, 188, (Seguridad.fncsSustituir(dlgDialogo.sEstado, "'", "") + new string(' ', 4)).Substring(0, Math.Min((Seguridad.fncsSustituir(dlgDialogo.sEstado, "'", "") + new string(' ', 4)).Length, 4))); //ID_MEE_POB_EB.Text     'Poblacion
                sDialogo = StringsHelper.MidAssignment(sDialogo, 192, StringsHelper.Format(dlgDialogo.iZonaPostal, "00")); //zona postal
                sDialogo = StringsHelper.MidAssignment(sDialogo, 194, StringsHelper.Format(dlgDialogo.lCP, "00000")); //codigo postal
                sDialogo = StringsHelper.MidAssignment(sDialogo, 199, StringsHelper.Format(dlgDialogo.iASActi, "0000")); //actividad_subactividad
                sDialogo = StringsHelper.MidAssignment(sDialogo, 203, StringsHelper.Format(dlgDialogo.lTelParticular.ToString().Substring(dlgDialogo.lTelParticular.ToString().Length - Math.Min(dlgDialogo.lTelParticular.ToString().Length, 7)), "0000000")); //telefono particular
                sDialogo = StringsHelper.MidAssignment(sDialogo, 210, StringsHelper.Format(dlgDialogo.lTelOficina.ToString().Substring(dlgDialogo.lTelOficina.ToString().Length - Math.Min(dlgDialogo.lTelOficina.ToString().Length, 7)), "0000000")); //telefono de oficiona
                sDialogo = StringsHelper.MidAssignment(sDialogo, 217, StringsHelper.Format(dlgDialogo.lExtension.ToString().Substring(dlgDialogo.lExtension.ToString().Length - Math.Min(dlgDialogo.lExtension.ToString().Length, 4)), "0000")); //extension
                sDialogo = StringsHelper.MidAssignment(sDialogo, 221, new String(' ', 1)); //Trim(ID_MEE_NVJ_ITB.Text)   'categoria o nivel jerarquico
                sDialogo = StringsHelper.MidAssignment(sDialogo, 222, Seguridad.fncsSustituir(Seguridad.fncsSustituir(dlgDialogo.sRFC, "-", ""), "'", "").Trim()); //RFC
                sDialogo = StringsHelper.MidAssignment(sDialogo, 235, StringsHelper.Format(CORVB.NULL_INTEGER, "000")); //lada telefono casa
                sDialogo = StringsHelper.MidAssignment(sDialogo, 238, StringsHelper.Format(CORVB.NULL_INTEGER, "000")); //lada telefono oficina
                sDialogo = StringsHelper.MidAssignment(sDialogo, 241, StringsHelper.Format(CORVB.NULL_INTEGER, "000")); //puntos del scoredcard
                sDialogo = StringsHelper.MidAssignment(sDialogo, 244, StringsHelper.Format(CORVB.NULL_INTEGER, "000")); //identificador del scoredcard
                sDialogo = StringsHelper.MidAssignment(sDialogo, 247, StringsHelper.Format(dlgDialogo.iFechaAlta, "000000")); //fecha de evalución
                sDialogo = StringsHelper.MidAssignment(sDialogo, 253, CORVB.NULL_STRING); //direccion 1 domicilio 2
                sDialogo = StringsHelper.MidAssignment(sDialogo, 288, CORVB.NULL_STRING); //direccion 1 domicilio 2
                sDialogo = StringsHelper.MidAssignment(sDialogo, 313, CORVB.NULL_STRING); //direccion 1 domicilio 2
                sDialogo = StringsHelper.MidAssignment(sDialogo, 338, StringsHelper.Format(CORVB.NULL_INTEGER, "00000")); //codigo postal
                sDialogo = StringsHelper.MidAssignment(sDialogo, 343, CORVB.NULL_STRING); //nombre soltera madre
                sDialogo = StringsHelper.MidAssignment(sDialogo, 398, StringsHelper.Format(CORVB.NULL_INTEGER, "00000000")); //fecha de nacimiento madre
                sDialogo = StringsHelper.MidAssignment(sDialogo, 406, dlgDialogo.iGeneraPinPlastico.ToString()); //NULL_INTEGER                   'identificador de generación de plastico 0=normal, 1=urgente
                sDialogo = StringsHelper.MidAssignment(sDialogo, 407, "1"); //identificador de domicilio 1=casa 2=oficina
                sDialogo = StringsHelper.MidAssignment(sDialogo, 408, new String(' ', 10)); //Identificador de Linea Aerea (9 blancos)
                //Información adicional del tarjetahabiente
                sDialogo = StringsHelper.MidAssignment(sDialogo, 418, dlgDialogo.sNombre); //npombre  ********************** adicional
                sDialogo = StringsHelper.MidAssignment(sDialogo, 448, dlgDialogo.sApellidoPaterno); //NULL_STRING materno
                sDialogo = StringsHelper.MidAssignment(sDialogo, 478, dlgDialogo.sApellidoMaterno); //NULL_STRING paterno (Nombre largo)
                //Fin Información adicional del tarjetahabiente

                //Comienza transacción 5185
                sDialogo = StringsHelper.MidAssignment(sDialogo, 508, StringsHelper.Format(CORVB.NULL_INTEGER, "0000")); //transaccion
                sDialogo = StringsHelper.MidAssignment(sDialogo, 512, StringsHelper.Format(CORVB.NULL_INTEGER, "0000000000000000")); //numero de cuenta
                sDialogo = StringsHelper.MidAssignment(sDialogo, 528, CORVB.NULL_STRING); //nombre del solicitante
                sDialogo = StringsHelper.MidAssignment(sDialogo, 554, CORVB.NULL_STRING); //sexo

                sDialogo = StringsHelper.MidAssignment(sDialogo, 555, StringsHelper.Format(CORVB.NULL_INTEGER, "00000000")); //fecha de nacimiento madre
                sDialogo = StringsHelper.MidAssignment(sDialogo, 563, CORVB.NULL_STRING); //direccion 1
                sDialogo = StringsHelper.MidAssignment(sDialogo, 598, CORVB.NULL_STRING); //direccion 2
                sDialogo = StringsHelper.MidAssignment(sDialogo, 623, CORVB.NULL_STRING); //direccion3
                sDialogo = StringsHelper.MidAssignment(sDialogo, 648, StringsHelper.Format(CORVB.NULL_INTEGER, "00")); //zona postal
                sDialogo = StringsHelper.MidAssignment(sDialogo, 650, StringsHelper.Format(CORVB.NULL_INTEGER, "00000")); //codigo postal
                sDialogo = StringsHelper.MidAssignment(sDialogo, 655, StringsHelper.Format(CORVB.NULL_INTEGER, "0000000")); //telefono particular
                sDialogo = StringsHelper.MidAssignment(sDialogo, 662, StringsHelper.Format(CORVB.NULL_INTEGER, "000")); //lada
                sDialogo = StringsHelper.MidAssignment(sDialogo, 665, StringsHelper.Format(CORVB.NULL_INTEGER, "000000000")); //credito
                sDialogo = StringsHelper.MidAssignment(sDialogo, 674, CORVB.NULL_INTEGER.ToString()); //indicador de generacion de plastico 0=normal, 1=urgente

                //EISSA 10.12.2001   Elementos adicionales
                sDialogo = StringsHelper.MidAssignment(sDialogo, 675, StringsHelper.Format(CORVB.NULL_INTEGER, "0000")); //Region grupo
                sDialogo = StringsHelper.MidAssignment(sDialogo, 679, StringsHelper.Format(CORVB.NULL_INTEGER, "0000")); //Región en Cadena
                sDialogo = StringsHelper.MidAssignment(sDialogo, 683, StringsHelper.Format(CORVB.NULL_INTEGER, "00000000")); //Número de Negocio
                sDialogo = StringsHelper.MidAssignment(sDialogo, 691, new string(' ', 40)); //NombreRazon

                if (dlgDialogo.sTipoCta == CRSParametros.cteEmpresa)
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 731, StringsHelper.Format(CORVB.NULL_INTEGER, "00000000")); //Fecha de Nacimiento
                }
                else
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 731, StringsHelper.Format(CRSGeneral.lfncFechaNacimiento(dlgDialogo.sRFC), "00000000")); //Fecha de Nacimiento
                }

                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(dlgDialogo.sCuentaReferencia))
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 739, StringsHelper.Format(CORVB.NULL_INTEGER, new string('0', 16))); //Tarjeta 1
                }
                else
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 739, StringsHelper.Format(dlgDialogo.sCuentaReferencia, new string('0', 16))); //Tarjeta 1
                }
                sDialogo = StringsHelper.MidAssignment(sDialogo, 755, StringsHelper.Format(CORVB.NULL_INTEGER, new string('0', 16))); //Tarjeta 2

                if (dlgDialogo.sTipoCta == CRSParametros.cteEmpresa)
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 771, StringsHelper.Format(CORVB.NULL_INTEGER, "00")); //Clave Nacionalidad
                }
                else
                {
                    if (dlgDialogo.iNacionalidad == 0)
                    {
                        sDialogo = StringsHelper.MidAssignment(sDialogo, 771, StringsHelper.Format(1, "00")); //Clave Nacionalidad
                    }
                    else
                    {
                        sDialogo = StringsHelper.MidAssignment(sDialogo, 771, StringsHelper.Format(dlgDialogo.iNacionalidad, "00")); //Clave Nacionalidad
                    }
                }

                sDialogo = StringsHelper.MidAssignment(sDialogo, 773, StringsHelper.Format(CORVB.NULL_INTEGER, "0000")); //ClaveOcupacion
                sDialogo = StringsHelper.MidAssignment(sDialogo, 777, StringsHelper.Format(CORVB.NULL_INTEGER, new string('0', 10))); //Número de nómina
                //El siguiente campo tiene como valor ADE, cuando se trata de una cuenta empresarial y blancos cuando
                if (dlgDialogo.sTipoCta == CRSParametros.cteEmpresa)
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 787, "ADE"); //Tipo Operacion ()
                }
                else
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 787, new string(' ', 3)); //Tipo Operacion ()
                }
                sDialogo = StringsHelper.MidAssignment(sDialogo, 790, new string(' ', 55)); //Nombre Largo Adicional
                sDialogo = StringsHelper.MidAssignment(sDialogo, 845, new string(CORVB.NULL_INTEGER.ToString()[0], 8)); //Fecha Nacimiento Adicional
                sDialogo = StringsHelper.MidAssignment(sDialogo, 853, new string(' ', 1)); //Clave Parentesco Adicional
                sDialogo = StringsHelper.MidAssignment(sDialogo, 854, new string(' ', 38)); //Filler
                sDialogo = StringsHelper.MidAssignment(sDialogo, 892, new string(' ', 56)); //Info tabla B11
                sDialogo = StringsHelper.MidAssignment(sDialogo, 948, new string(' ', 0)); //Comentarios
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1098, StringsHelper.Format(new string(CORVB.NULL_INTEGER.ToString()[0], 2), "00")); //Familia Producto y Tipo Solicitud
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1100, StringsHelper.Format(new string(CORVB.NULL_INTEGER.ToString()[0], 2), "00")); //Tipo Solicitud
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1102, dlgDialogo.sTipoCta); //Tipo Cuenta (Clave Opcion)
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1103, StringsHelper.Format(dlgDialogo.iSkipPayment, "0")); //Skip Payment
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1104, StringsHelper.Format(dlgDialogo.iIdTablaMCC, "0000")); //Indicativo de tabla MCC
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1108, StringsHelper.Format(dlgDialogo.dLimiteDisposiciones, "000")); //% de límite de disposición de efectivo
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1111, dlgDialogo.sTipoFacturacion); //% de límite de disposición de efectivo
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1112, new String(' ', 20)); //***** Campos que no se usan *****
                sDialogo = StringsHelper.MidAssignment(sDialogo, 1132, mdlParametros.igEmpTipoBloqueo.ToString()); //Tipo de Bloqueo
                if (ipTipoAlta == TipoAlta.cteAltaS111)
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 1133, new String(' ', 1));
                }
                else if (ipTipoAlta == TipoAlta.cteAltaS016)
                {
                    sDialogo = StringsHelper.MidAssignment(sDialogo, 1133, "1");
                }
                //FSWB NR CAMBIO??
                // Mid$(sDialogo, 1133, 45) = Trim(txtAtencionA.Text)  'AtencionaA     'FSWB NR 20070223
                // Mid$(sDialogo, 1178, 1) = Mid(ID_MEM_PERSONA.Text, 1, 1)   'Persona        'FSWB NR 20070223
                //Tipo de Bloqueo
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError("Dialogo", e);
            }

        }

        
        static public void DialogoComDrv(ref  string slDialogo, DatosDialogo dlgDialogo, TipoAlta ipTipoAlta)
        {
            int lpNumNom = 0;
            try
            {
                int llFolio = 0;
                int ilIndice = 0;

                ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(dlgDialogo.sEstado);
                if (ilIndice != 0)
                {
                    dlgDialogo.iEstado.CodigoI = mdlParametros.gcestEstado[ilIndice].CodigoI;
                } //FSWB NR 20070227 SE condicionó a que si es cero no ejecut set para evitar error


                slDialogo = new String(' ', 1197);  //Variable local que va a tener el Dialogo 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1, "5566");  //Sistema 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 5, " ");     //Clave de proceso 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 6, "01");     //Subtransaccion
                slDialogo = StringsHelper.MidAssignment(slDialogo, 8, "0000000000000000");
                slDialogo = StringsHelper.MidAssignment(slDialogo, 24, "00000000");  //Número de Folio 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 32, "C430");//Sistema
                slDialogo = StringsHelper.MidAssignment(slDialogo, 36, CORBD.TIPO_TRAMITE);  //Clave tipo de trámite 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 38, "00");     ////Familia Producto
                slDialogo = StringsHelper.MidAssignment(slDialogo, 40, "00");     ////Tipo de Solicitud
                slDialogo = StringsHelper.MidAssignment(slDialogo, 42, "000");//Status (de la solicitud)
                slDialogo = StringsHelper.MidAssignment(slDialogo, 45, "00");//Resultado de la transacción
                slDialogo = StringsHelper.MidAssignment(slDialogo, 47, new String(' ', 50));//Resultado de la transacción
                slDialogo = StringsHelper.MidAssignment(slDialogo, 97, new String(' ', 10));//Ejecutivo
                slDialogo = StringsHelper.MidAssignment(slDialogo, 107, StringsHelper.Format(CORBD.TIPO_ALTA, "000"));  //Clave tipo de alta
                slDialogo = StringsHelper.MidAssignment(slDialogo, 110, "0");//Flag Informativo
                slDialogo = StringsHelper.MidAssignment(slDialogo, 111, "0");//Indicador Control de Cambios
                slDialogo = StringsHelper.MidAssignment(slDialogo, 112, "00");//Numero de pantalla
                slDialogo = StringsHelper.MidAssignment(slDialogo, 114, "                                                               ");//filler
                //Datos
                slDialogo = StringsHelper.MidAssignment(slDialogo, 177, "000000000000");  //Numero de Nómina 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 189, dlgDialogo.sNombreGrabacion);//Nombre
                slDialogo = StringsHelper.MidAssignment(slDialogo, 215, dlgDialogo.sNombre);//npombre 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 265, dlgDialogo.sApellidoPaterno);// paterno 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 325, dlgDialogo.sApellidoMaterno);//materno
                slDialogo = StringsHelper.MidAssignment(slDialogo, 385, StringsHelper.Format(dlgDialogo.lFechaNacimiento, "00000000"));//fecha de nacimiento
                slDialogo = StringsHelper.MidAssignment(slDialogo, 393, dlgDialogo.sRFC);  //RFC
                slDialogo = StringsHelper.MidAssignment(slDialogo, 406, dlgDialogo.sSexo);  //Sexo 
                //if (dlgDialogo.sTipoCta == CRSParametros.cteEmpresa)
                //{
                //    slDialogo = StringsHelper.MidAssignment(slDialogo, 407, StringsHelper.Format(CORVB.NULL_INTEGER, "00")); //Clave Nacionalidad
                //}
                //else
                //{
                //    if (dlgDialogo.iNacionalidad == 0)
                //    {
                //        slDialogo = StringsHelper.MidAssignment(slDialogo, 407, StringsHelper.Format(1, "00")); //Clave Nacionalidad
                //    }
                //    else
                //    {
                //        slDialogo = StringsHelper.MidAssignment(slDialogo, 407, StringsHelper.Format(dlgDialogo.iNacionalidad, "00")); //Clave Nacionalidad
                //    }
                //}

                slDialogo = StringsHelper.MidAssignment(slDialogo, 407, "01"); //Clave Nacionalidad


                slDialogo = StringsHelper.MidAssignment(slDialogo, 409, "0000");  //Clave Ocupacion 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 413, StringsHelper.Format(dlgDialogo.iASActi, "0000"));  //Actividad Subactividad 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 417, "1");  //Identificador de Domicilio 1=casa 2=oficina 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 418, dlgDialogo.sDomicilio);  //Calle y Número 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 453, dlgDialogo.sColonia);  //Colonia 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 478, dlgDialogo.sPoblacion);  //Poblacion 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 499, StringsHelper.Format(dlgDialogo.iEstado.CodigoI, "00"));  //Estado 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 501, "00");  //Zona Postal 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 503, StringsHelper.Format(dlgDialogo.lCP, "00000"));  //Codigo Postal 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 508, "000");  //Lada Telefono Casa
                slDialogo = StringsHelper.MidAssignment(slDialogo, 511, StringsHelper.Format(StringsHelper.DoubleValue(dlgDialogo.lTelParticular.ToString()).ToString().Substring(StringsHelper.DoubleValue(dlgDialogo.lTelParticular.ToString()).ToString().Length - Math.Min(StringsHelper.DoubleValue(dlgDialogo.lTelParticular.ToString()).ToString().Length, 7)), "0000000"));  //Telefono Particular
                slDialogo = StringsHelper.MidAssignment(slDialogo, 518, "000");  //Lada Telefono Oficina
                slDialogo = StringsHelper.MidAssignment(slDialogo, 521, StringsHelper.Format(StringsHelper.DoubleValue(dlgDialogo.lTelOficina.ToString()).ToString().Substring(StringsHelper.DoubleValue(dlgDialogo.lTelOficina.ToString()).ToString().Length - Math.Min(StringsHelper.DoubleValue(dlgDialogo.lTelOficina.ToString()).ToString().Length, 7)), "0000000"));  //Telefono de Oficina 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 528, StringsHelper.Format(StringsHelper.IntValue(dlgDialogo.lExtension.ToString()).ToString().Substring(StringsHelper.IntValue(dlgDialogo.lExtension.ToString()).ToString().Length - Math.Min(StringsHelper.DoubleValue(dlgDialogo.lExtension.ToString()).ToString().Length, 4)), "0000"));  //Extension 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 533, new String(' ', 35));  //Direccion 1 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 568, new String(' ', 25));  //Direccion 2 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 593, new String(' ', 21));  //CIUDAD-2   
                slDialogo = StringsHelper.MidAssignment(slDialogo, 614, "00");  //ESTADO-2 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 616, "00000");  //COD-POSTAL-2
                slDialogo = StringsHelper.MidAssignment(slDialogo, 621, StringsHelper.Format(dlgDialogo.iSucTransmisora, "0000"));  //Sucursal Transmisora 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 625, StringsHelper.Format(dlgDialogo.iSucPromotora, "0000"));  //Sucursal Promotora 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 629, CORBD.TIPO_ORIGEN);  //Origen  
                slDialogo = StringsHelper.MidAssignment(slDialogo, 630, StringsHelper.Format(dlgDialogo.sCuenta, "0000000000000000"));  //Cuenta 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 646, StringsHelper.Format(Conversion.Str(dlgDialogo.lLimiteCredito), "000000000"));  //Límite de Crédito 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 655, "000");  //Puntos del Scoredcard 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 658, "000");  //Identificador del Scoredcard 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 661, StringsHelper.Format(DateTime.Today.ToString("yyyyMMdd"), "000000"));  //FEC-EVAL-SCORECARD 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 667, "0");  //Indicador de generacion de plastico 0=normal, 1=urgente 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 668, StringsHelper.Format(dlgDialogo.dLimiteDisposiciones, "000"));  //Limite de Disposiciones 
                if (String.IsNullOrEmpty(dlgDialogo.sCuentaReferencia))
                {
                    slDialogo = StringsHelper.MidAssignment(slDialogo, 671, StringsHelper.Format(CORVB.NULL_INTEGER, new string('0', 16))); //Tarjeta 1
                }
                else
                {
                    slDialogo = StringsHelper.MidAssignment(slDialogo, 671, StringsHelper.Format(dlgDialogo.sCuentaReferencia, new string('0', 16))); //Tarjeta 1
                }
                slDialogo = StringsHelper.MidAssignment(slDialogo, 687, "0000000000000000");  //Tarjeta 2 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 703, new String(' ', 1)); //-BAS-CATEGORIA 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 704, "ADE");  //Tipo Operacion 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 707, CORBD.TIPO_ORIGEN);  //BAS-CVE-OPCION  
                slDialogo = StringsHelper.MidAssignment(slDialogo, 708, StringsHelper.Format(dlgDialogo.iSkipPayment, "0"));  //Skip Payment 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 709, StringsHelper.Format(dlgDialogo.iIdTablaMCC, "0000"));  //Indicativo de tabla MCC 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 713, dlgDialogo.sTipoFacturacion);  //Tipo de Facturacion 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 714, new String(' ', 10));  //Identificador de Linea Aerea 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 724, new String(' ', 55));  //Nombre Largo Adicional 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 779, "00000000");  //Fecha Nacimiento Adicional
                slDialogo = StringsHelper.MidAssignment(slDialogo, 787, StringsHelper.Format(dlgDialogo.iDiaCorte, "00"));  //Dia de Corte 
                if (ipTipoAlta == TipoAlta.cteAltaS111ComDrv)
                {
                    slDialogo = StringsHelper.MidAssignment(slDialogo, 789, "0");
                }
                else if (ipTipoAlta == TipoAlta.cteAltaS016ComDrv)
                {
                    slDialogo = StringsHelper.MidAssignment(slDialogo, 789, "1");
                }
                slDialogo = StringsHelper.MidAssignment(slDialogo, 790, "0");  //Tipo de Bloqueo 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 791, new String(' ', 46));  //Filler 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 837, DateTime.Today.ToString("yyyyMMdd"));  //Fecha Alta 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 845, "000000"); //-PROC-HH-HORA-INICIAL   
                slDialogo = StringsHelper.MidAssignment(slDialogo, 851, "00000000"); //PROC-FEC-FINAL    
                slDialogo = StringsHelper.MidAssignment(slDialogo, 859, "000000"); //PROC-HH-HORA-FINAL
                slDialogo = StringsHelper.MidAssignment(slDialogo, 865, "0000"); //PROC-CVE-CAUSA-RECHAZO 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 869, new String(' ', 150)); //WKS-PROC-COMENTARIOS 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1019, "0000000000000000");  //Numero de Cuenta 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1035, new String(' ', 30));  //TR01-NOMBRE-EMPRESA 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1065, "0000");  //PAIS NACIONALIDAD
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1069, "0000");  //PAIS NACIMIENTO
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1073, new String(' ', 20));  //FIEL  
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1093, new String(' ', 18));//CURP
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1111, new String(' ', 78));  //mail 
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1189, "000000");//giro
                slDialogo = StringsHelper.MidAssignment(slDialogo, 1195, "00"); //Endidad de nacimiento

               //LMHR & CMET: Se agrega funcionalidad para completar la cadena segun la definicion del layout
               slDialogo = ComplementaDialogo(slDialogo);

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError("Dialogo", e);
            }
        }

        /// <summary>
        /// Método para construir cadena de comunicacion con comDrv agregando los datos complementarios para el layout 5566-01
        /// </summary>
        ///<!--
        /// Autor: LMHR & CMET
        /// Fecha de creacion: 09/01/2018
        /// Fecha de ultima modificacion: 09/01/2018-->
        /// <param name="iniCadena">Cadena prellenada que inicializa el stringbuilder</param>
        /// <returns>Una cadena con los datos complementarios para el dialogo</returns>
        public static string ComplementaDialogo(string iniCadena) 
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(iniCadena.TrimEnd());
            string sDate, sTime;

            sb.Append(fnArmaCadena(string.Empty, ' ', 20)); //ID Fiscal Equi1
            sb.Append(fnArmaCadena(string.Empty, ' ', 4)); //Pais que asigno1
            sb.Append(fnArmaCadena(string.Empty, ' ', 20));//ID Fiscal Equi2
            sb.Append(fnArmaCadena(string.Empty, ' ', 4));//Pais que asigno2
            sb.Append(fnArmaCadena(string.Empty, ' ', 2));//Tipo Persona
            sb.Append(fnArmaCadena(string.Empty, ' ', 8));//Fecha constitucion
            sb.Append(fnArmaCadena(string.Empty, ' ', 20));//Firma electronica
            sb.Append(fnArmaCadena(string.Empty, ' ', 2)); //Has trabajado en el ext
            sb.Append(fnArmaCadena(string.Empty, ' ', 70));//Empresa empleador
            sb.Append(fnArmaCadena(cteIdentificacion.ToUpper(), ' ', 10));//Datos de identificacion

            sb.Append(fnArmaCadena(Seguridad.usugUsuario.NominaS, ' ', 10));//Nomina del operador
            sb.Append(fnArmaCadena(mdlSeguridad._SIRH, '0', 4, FillDirection.Izquierda));//SIRH

            fncDateTimeToSend(out sDate, out sTime);

            sb.Append(fnArmaCadena(sDate, '0', 8));//Fecha transacccion
            sb.Append(fnArmaCadena(sTime, ' ', 8));//Hora transaccion
            sb.Append(fnArmaCadena(string.Empty, ' ', 190));//Filler

            return sb.ToString();

        }
         

        /// <summary>
        /// Método para construir cadena de comunicacion con comDrv
        /// </summary>
        ///<!--
        /// Autor: LMHR & CMET
        /// Fecha de creacion: 15/12/2017
        /// Fecha de ultima modificacion: 02/01/2018-->
        /// <param name="slDialogo">Variable por referencia tipo cadena donde se regresa el dialogo construido</param>
        /// <param name="dlgDialogo">Objeto Tipo Alta contiene los elementos para armar la cadena.</param>
        /// <param name="ipTipoAlta">Flag de tipo entero para indicar el tipo de alta</param>
        static public void DialogoComDrv2(ref string slDialogo, DatosDialogo dlgDialogo, TipoAlta ipTipoAlta)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("5566 ");
            string sDate, sTime;

            try
            {
                #region  Header
                sb.Append(fnArmaCadena("1", '0', 2, FillDirection.Izquierda)); //Id Transaccion
                sb.Append(fnArmaCadena(string.Empty, '0', 16));//Numero de Folio Preimpreso
                sb.Append(fnArmaCadena(string.Empty, '0', 8));//Numero de Folio
                sb.Append(fnArmaCadena(cteC430.ToUpper(), ' ', 4));  //Sistema (C430)
                sb.Append(fnArmaCadena(CORBD.TIPO_TRAMITE, '0', 2, FillDirection.Izquierda)); //Clave tipo de trámite 
                sb.Append(fnArmaCadena(string.Empty, '0', 2));//Familia Producto
                sb.Append(fnArmaCadena(string.Empty, '0', 2));//Tipo de Solicitud
                sb.Append(fnArmaCadena(string.Empty, '0', 3));//Status (de la solicitud)
                sb.Append(fnArmaCadena(string.Empty, '0', 2));//Resultado de la transacción
                sb.Append(fnArmaCadena(string.Empty, ' ', 45));//Descripcion del resultado
                sb.Append(fnArmaCadena(string.Empty, '0', 5));//Codigo de error
                sb.Append(fnArmaCadena(string.Empty, ' ', 10));//Ejecutivo
                sb.Append(fnArmaCadena(CORBD.TIPO_ALTA, '0', 3, FillDirection.Izquierda));//Clave de Proceso
                sb.Append(fnArmaCadena(string.Empty, '0', 1));//Flag Informativo
                sb.Append(fnArmaCadena(string.Empty, '0', 1));//Indicador Control Cambio
                sb.Append(fnArmaCadena(string.Empty, '0', 2));//Numero de pantalla
                sb.Append(fnArmaCadena(string.Empty, ' ', 63));//Filler
                #endregion

                //Datos
                sb.Append(fnArmaCadena(string.Empty, '0', 12)); //Numero de  Cliente 

                #region Datos Personales
                sb.Append(fnArmaCadena(dlgDialogo.sNombreGrabacion, ' ', 26));//Nombre Codificado corte
                sb.Append(fnArmaCadena(dlgDialogo.sNombre, ' ', 50));//Nombre 
                sb.Append(fnArmaCadena(dlgDialogo.sApellidoPaterno, ' ', 60));//Paterno 
                sb.Append(fnArmaCadena(dlgDialogo.sApellidoMaterno, ' ', 60));//Materno
                sb.Append(fnArmaCadena(dlgDialogo.lFechaNacimiento.ToString(), '0', 8));//Fecha de nacimiento
                sb.Append(fnArmaCadena(dlgDialogo.sRFC, ' ', 13)); //RFC
                sb.Append(fnArmaCadena(dlgDialogo.sSexo, ' ', 1));  //Sexo 
                sb.Append(fnArmaCadena("1", '0', 2, FillDirection.Izquierda)); //Clave Nacionalidad
                sb.Append(fnArmaCadena(string.Empty, '0', 4, FillDirection.Izquierda)); //Clave Ocupacion 
                sb.Append(fnArmaCadena(dlgDialogo.iASActi.ToString(), '0', 4, FillDirection.Izquierda));//Actividad Subactividad
                #endregion;

                #region Datos Domicilio
                sb.Append(fnArmaCadena("1", '0', 1));  //Identificador de Domicilio 1=casa 2=oficina 
                sb.Append(fnArmaCadena(dlgDialogo.sDomicilio, ' ', 35));  //Calle Num1 
                sb.Append(fnArmaCadena(dlgDialogo.sColonia, ' ', 25));  //Colonia1 
                sb.Append(fnArmaCadena(dlgDialogo.sPoblacion, ' ', 21));  //Ciudad1
                sb.Append(fnArmaCadena(dlgDialogo.iEstado.CodigoI.ToString(), '0', 2, FillDirection.Izquierda)); //Estado1 
                sb.Append(fnArmaCadena(string.Empty, '0', 2));//Zona Postal 
                sb.Append(fnArmaCadena(dlgDialogo.lCP.ToString(), '0', 5, FillDirection.Izquierda)); //Codigo Postal 
                sb.Append(fnArmaCadena(string.Empty, '0', 3, FillDirection.Izquierda));//Lada Telefono Casa
                sb.Append(fnArmaCadena(StringsHelper.DoubleValue(dlgDialogo.lTelParticular.ToString()).ToString().Substring(StringsHelper.DoubleValue(dlgDialogo.lTelParticular.ToString()).ToString().Length - Math.Min(StringsHelper.DoubleValue(dlgDialogo.lTelParticular.ToString()).ToString().Length, 7)), '0', 7, FillDirection.Izquierda));//Telefono Particular
                sb.Append(fnArmaCadena(string.Empty, '0', 3, FillDirection.Izquierda));//Lada Telefono Oficina
                sb.Append(fnArmaCadena(StringsHelper.DoubleValue(dlgDialogo.lTelOficina.ToString()).ToString().Substring(StringsHelper.DoubleValue(dlgDialogo.lTelOficina.ToString()).ToString().Length - Math.Min(StringsHelper.DoubleValue(dlgDialogo.lTelOficina.ToString()).ToString().Length, 7)), '0', 7, FillDirection.Izquierda));  //Telefono de Oficina 
                sb.Append(fnArmaCadena(StringsHelper.IntValue(dlgDialogo.lExtension.ToString()).ToString().Substring(StringsHelper.IntValue(dlgDialogo.lExtension.ToString()).ToString().Length - Math.Min(StringsHelper.DoubleValue(dlgDialogo.lExtension.ToString()).ToString().Length, 4)), '0', 5, FillDirection.Izquierda));  //Extension 
                sb.Append(fnArmaCadena(string.Empty, ' ', 35));  //Calle Num2 
                sb.Append(fnArmaCadena(string.Empty, ' ', 25));  //Colonia2 
                sb.Append(fnArmaCadena(string.Empty, ' ', 21));  //CIUDAD2   
                sb.Append(fnArmaCadena(string.Empty, '0', 2, FillDirection.Izquierda));  //ESTADO2 
                sb.Append(fnArmaCadena(string.Empty, '0', 5, FillDirection.Izquierda));  //COD-POSTAL2
                #endregion;

                #region Datos Basica
                sb.Append(fnArmaCadena(dlgDialogo.iSucTransmisora.ToString(), '0', 4, FillDirection.Izquierda));  //Sucursal Transmisora 
                sb.Append(fnArmaCadena(dlgDialogo.iSucPromotora.ToString(), '0', 4, FillDirection.Izquierda));  //Sucursal Promotora 
                sb.Append(fnArmaCadena(CORBD.TIPO_ORIGEN, ' ', 1));  //Origen * 
                sb.Append(fnArmaCadena(dlgDialogo.sCuenta, '0', 16, FillDirection.Izquierda));  //Cuenta 
                sb.Append(fnArmaCadena(dlgDialogo.lLimiteCredito.ToString(), '0', 9, FillDirection.Izquierda));  //Límite de Crédito 
                sb.Append(fnArmaCadena(string.Empty, '0', 3));  //Puntos del Scoredcard 
                sb.Append(fnArmaCadena(string.Empty, '0', 3));  //Identificador del Scoredcard 
                sb.Append(fnArmaCadena(DateTime.Today.ToString("yyyyMM"), '0', 6));  //FEC-EVAL-SCORECARD 
                sb.Append(fnArmaCadena(string.Empty, '0', 1));  //Indicador de generacion de plastico 0=normal, 1=urgente 
                sb.Append(fnArmaCadena(dlgDialogo.dLimiteDisposiciones.ToString(), '0', 3));  //Limite de Disposiciones 

                if (String.IsNullOrEmpty(dlgDialogo.sCuentaReferencia))
                {
                    sb.Append(fnArmaCadena(CORVB.NULL_INTEGER.ToString(), '0', 16, FillDirection.Izquierda)); //Tarjeta 1
                }
                else
                {
                    sb.Append(fnArmaCadena(dlgDialogo.sCuentaReferencia, '0', 16, FillDirection.Izquierda)); //Tarjeta 1
                }
                sb.Append(fnArmaCadena(string.Empty, '0', 16));  //Tarjeta 2 
                sb.Append(fnArmaCadena(string.Empty, ' ', 1)); //-BAS-CATEGORIA 
                sb.Append(fnArmaCadena("ADE", ' ', 3));  //Tipo Operacion 
                sb.Append(fnArmaCadena(CORBD.TIPO_ORIGEN, ' ', 1));  //BAS-CVE-OPCION  
                sb.Append(fnArmaCadena(dlgDialogo.iSkipPayment.ToString(), '0', 1));  //Skip Payment 
                sb.Append(fnArmaCadena(dlgDialogo.iIdTablaMCC.ToString(), '0', 4, FillDirection.Izquierda));  //Indicativo de tabla MCC 
                sb.Append(fnArmaCadena(dlgDialogo.sTipoFacturacion, '0', 1));  //Tipo de Facturacion 
                sb.Append(fnArmaCadena(string.Empty, ' ', 10));  //Identificador de Linea Aerea 
                sb.Append(fnArmaCadena(string.Empty, ' ', 55));  //Nombre Largo Adicional 
                sb.Append(fnArmaCadena(string.Empty, '0', 8));  //Fecha Nacimiento Adicional
                sb.Append(fnArmaCadena(dlgDialogo.iDiaCorte.ToString(), '0', 2, FillDirection.Izquierda));  //Dia de Corte

                if (ipTipoAlta == TipoAlta.cteAltaS111ComDrv)
                {
                    sb.Append(fnArmaCadena(string.Empty, '0', 1));
                }
                else if (ipTipoAlta == TipoAlta.cteAltaS016ComDrv)
                {
                    sb.Append(fnArmaCadena("1", '0', 1));
                }
                sb.Append(fnArmaCadena(string.Empty, '0', 1));  //Tipo de Bloqueo MCC 
                sb.Append(fnArmaCadena(string.Empty, ' ', 46));//Filler
                #endregion;

                #region Datos Proc Eempresa
                sb.Append(fnArmaCadena(DateTime.Today.ToString("yyyyMMdd"), '0', 8));//Fecha Alta
                sb.Append(fnArmaCadena(string.Empty, '0', 6));//-PROC-HH-HORA-INICIAL   
                sb.Append(fnArmaCadena(string.Empty, '0', 8)); //PROC-FEC-FINAL    
                sb.Append(fnArmaCadena(string.Empty, '0', 6)); //PROC-HH-HORA-FINAL
                sb.Append(fnArmaCadena(string.Empty, '0', 4)); //PROC-CVE-CAUSA-RECHAZO 
                sb.Append(fnArmaCadena(string.Empty, ' ', 150)); //WKS-PROC-COMENTARIOS 
                sb.Append(fnArmaCadena(string.Empty, '0', 16));  //Numero de Cuenta 
                sb.Append(fnArmaCadena(string.Empty, ' ', 30));  //TR01-NOMBRE-EMPRESA 
                #endregion;

                #region Datos Comp S016
                sb.Append(fnArmaCadena(string.Empty, '0', 4, FillDirection.Izquierda));//PAIS NACIONALIDAD
                sb.Append(fnArmaCadena(string.Empty, '0', 4, FillDirection.Izquierda));//PAIS NACIMIENTO
                sb.Append(fnArmaCadena(string.Empty, ' ', 20));//FIEL  
                sb.Append(fnArmaCadena(string.Empty, ' ', 18));//CURP
                sb.Append(fnArmaCadena(string.Empty, ' ', 78));//mail 
                sb.Append(fnArmaCadena(string.Empty, '0', 6, FillDirection.Izquierda));//giro
                sb.Append(fnArmaCadena(string.Empty, '0', 2, FillDirection.Izquierda));//Endidad de nacimiento
                sb.Append(fnArmaCadena(string.Empty, ' ', 20)); //ID Fiscal Equi1
                sb.Append(fnArmaCadena(string.Empty, ' ', 4)); //Pais que asigno1
                sb.Append(fnArmaCadena(string.Empty, ' ', 20));//ID Fiscal Equi2
                sb.Append(fnArmaCadena(string.Empty, ' ', 4));//Pais que asigno2
                sb.Append(fnArmaCadena(string.Empty, ' ', 2));//Tipo Persona
                sb.Append(fnArmaCadena(string.Empty, ' ', 8));//Fecha constitucion
                sb.Append(fnArmaCadena(string.Empty, ' ', 20));//Firma electronica
                sb.Append(fnArmaCadena(string.Empty, ' ', 2)); //Has trabajado en el ext
                sb.Append(fnArmaCadena(string.Empty, ' ', 70));//Empresa empleador
                sb.Append(fnArmaCadena(cteIdentificacion.ToUpper(), ' ', 10));//Datos de identificacion

                sb.Append(fnArmaCadena(Seguridad.usugUsuario.NominaS, ' ', 10));//Nomina del operador
                sb.Append(fnArmaCadena(mdlSeguridad._SIRH, '0', 4, FillDirection.Izquierda));//SIRH

                fncDateTimeToSend(out sDate, out sTime);

                sb.Append(fnArmaCadena(sDate, '0', 8));//Fecha transacccion
                sb.Append(fnArmaCadena(sTime, ' ', 8));//Hora transaccion
                sb.Append(fnArmaCadena(string.Empty, ' ', 190));//Filler

                #endregion;

                slDialogo = sb.ToString();

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError("Dialogo", e);
            }
        }

        /// <summary>
        /// Obtiene la fecha y hora del sistema en un par de cadenas de texto separadas en formatos especificos
        /// </summary>
        ///<!--
        /// Autor: LMHR & CMET
        /// Fecha de creacion: 15/12/2017
        /// Fecha de ultima modificacion: 22/12/2017-->
        /// <param name="sPDate">Variable de tipo string donde se recuperara la fecha actual en formato[yyyyMMdd]</param>
        /// <param name="sPTime">Variable de tipo string donde se recuperara la hora actual en formato[HH:mm:ss]</param>     
        public static void fncDateTimeToSend(out string sPDate, out string sPTime)
        {
            sPDate = DateTime.Now.ToString("yyyyMMdd");
            sPTime = DateTime.Now.ToString("HHmmss");
        }

        /// <summary>
        /// Crea una cadena formateada de longitud fija
        /// </summary>
        ///<!--
        /// Autor: LMHR & CMET
        /// Fecha de creacion: 15/12/2017
        /// Fecha de ultima modificacion: 18/12/2017-->
        /// <param name="sCadenaOrig">Cadena a la que se le aplicara el formato</param>
        /// <param name="cRelleno">Valor con el que se rellenara la cadena</param>
        /// <param name="iLongitud">Logitud final que tendra la cadena</param>
        /// <param name="fd">Direccion en la que se rellenara la cadena</param>
        /// <returns>Regresara una cadena con formato</returns>  
        public static string fnArmaCadena(string sCadenaOrig, char cRelleno, int iLongitud, FillDirection fd = FillDirection.Derecha)
        {
            string sResp = "";

            switch (fd)
            {
                case FillDirection.Izquierda:
                    sResp = sCadenaOrig.PadLeft(iLongitud, cRelleno);
                    break;
                default:
                    sResp = sCadenaOrig.PadRight(iLongitud, cRelleno);
                    break;
            }
            return sResp;
        }


        /*static public int ifncEnviaDialogo(ref  OLERut.Conexion cnxpConexionRut, ref  int lpNumNom, ref  string spMensaje, ref  string spEnviaRut, ref  string spCuenta, ref  DatosEjecutivo ejepEjecutivo,  TipoAlta ipTipoAlta)
        {
            int result = 0;
            int ilRespuestaEnvio = 0;
            string slResMensaje = String.Empty;
            string slCveResTransaccion = String.Empty;
            string slCveTransaccion = String.Empty;
            string slRespS111 = String.Empty;
            string slDescMsg = String.Empty;
            string slDescMsgS111 = String.Empty;
            string slMensaje = String.Empty;
			
            try
            {
                    spEnviaRut = "Error";
                    string tempRefParam = "S753-CONALTAS";
                    ilRespuestaEnvio = cnxpConexionRut.RutReadWrite(ref spMensaje, ref tempRefParam);
                    Application.DoEvents();
                    slResMensaje = CRSGeneral.vfncVPO(spMensaje, CORVB.NULL_STRING);
					
                    if (ilRespuestaEnvio == 0)
                    {
                        slCveResTransaccion = Strings.Mid(slResMensaje, 32, 2);
                        slCveTransaccion = Strings.Mid(slResMensaje, 34, 4);
                        slRespS111 = Strings.Mid(slResMensaje, 38, 30);
                        slMensaje = Strings.Mid(slResMensaje, 50, 78).Trim();
						
                        if ((("0123456789").IndexOf(Strings.Mid(slCveResTransaccion, 1, 1)) + 1) == 0)
                        {
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("Existe un error de comunicaciones.Avise a sistemas", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                            if (((int) ipTipoAlta) == ((int) TipoAlta.cteAltaS111))
                            {
                                result = cteAltaNO;
                            } else
                            {
                            }
                            Cursor.Current = Cursors.WaitCursor;
                            return result;
                        }
						
                        if ((slCveResTransaccion == "04" || slCveResTransaccion == "05") && slRespS111 == CORVB.NULL_STRING)
                        {
                            slCveResTransaccion = "01";
                        }
						
                        if (((int) ipTipoAlta) == ((int) TipoAlta.cteAltaS111))
                        {
                            switch(slRespS111.Trim())
                            {
                                case "0030" : 
                                    result = (int) MensajesS111.cteExisteEnS111; 
                                    if (sfncVerificaConsulta111(cnxpConexionRut, lpNumNom, spCuenta, ref spMensaje, ref ejepEjecutivo).Trim() == "")
                                    {
                                        result = cteAltaS111OK;
                                        spEnviaRut = "OK";
                                    } else
                                    {
                                        spEnviaRut = "Error";
                                    } 
                                    return result;
                                default:
                                    break;
                            }
							
                            switch(slCveResTransaccion)
                            {
                                case "00" : 
                                    slMensaje = sfncVerificaConsulta111(cnxpConexionRut, lpNumNom, spCuenta, ref spMensaje, ref ejepEjecutivo); 
                                    if (slMensaje.Trim() == "")
                                    {
                                        result = cteAltaOK;
                                        spEnviaRut = "OK";
                                    } else
                                    {
                                        MessageBox.Show(slMensaje, "S111" + "Inconsistencia de Información.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        result = cteAltaS111NO;
                                        spEnviaRut = "Error";
                                    } 
									 
                                    break;
                                case "01" : case "03" : 
                                    result = cteAltaNO; 
                                    MessageBox.Show("El servidor CONALTAS no esta disponible", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                                    spEnviaRut = "Error"; 
                                    return result; 
									
                                case "02" : 
                                    result = cteAltaNO; 
                                    MessageBox.Show(slMensaje.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                                    spEnviaRut = "Error"; 
                                    return result; 
									
                                case "05" : 
                                    if (mdlParametros.igContador >= 3)
                                    {
                                        MessageBox.Show(slMensaje.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    } 
                                    result = cteAltaS016OK; 
                                    spEnviaRut = "Error"; 
									 
                                    break;
                                case "06" : 
                                    if (slMensaje.Trim() == "CONTRATO A DAR DE ALTA YA EXISTE")
                                    {
                                        MessageBox.Show(slMensaje.Trim().ToUpper(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        result = (int) MensajesS016.cteExisteEnS016;
                                        spEnviaRut = "Error";
                                    } else
                                    {
                                        MessageBox.Show(slMensaje.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        result = cteAltaNO;
                                        spEnviaRut = "Error";
                                    } 
									 
                                    break;
                                case "07" : 
                                    result = cteAltaNO; 
                                    MessageBox.Show(slMensaje.Trim(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                                    spEnviaRut = "Error"; 
                                    return result; 
									
                                case "35" : 
                                    result = cteAltaNO; 
                                    MessageBox.Show("No existe el producto " + mdlParametros.gprdProducto.PrefijoL.ToString() + mdlParametros.gprdProducto.BancoL.ToString() + " en catálogos.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                                    spEnviaRut = "Error"; 
                                    return result; 
									
                                default:
                                    slMensaje = sfncVerificaConsulta111(cnxpConexionRut, lpNumNom, spCuenta, ref spMensaje, ref ejepEjecutivo); 
                                    if (slMensaje.Trim() == "")
                                    {
                                        result = cteAltaOK;
                                        spEnviaRut = "OK";
                                    } else
                                    {
                                        //UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour.
                                        MessageBox.Show("Mensaje de respuesta del diálogo " + "\r\n" + sfncObtenErrorDialogo(Convert.ToInt32(Conversion.Val(slCveResTransaccion)), (TipoSistema) Int32.Parse(cteTandem)), Application.ProductName);
                                        result = cteAltaNO;
                                        spEnviaRut = "Error";
                                    } 
                                    break;
                            }
                        } else
                        {
                        }
						
                    } else
                    {
                        result = cteAltaNO;
                        spEnviaRut = "Error";
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Existe un error en el TANDEM No.: " + ilRespuestaEnvio.ToString() + " " + "\r\n" + sfncObtenErrorDialogo(ilRespuestaEnvio, TipoSistema.cteSistemaTandem), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Favor de intentar más tarde", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                    }
                }
                catch (Exception e)
            {
				
                switch(Information.Err().Number)
                {
                    case 28 : 
                        //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead. 
                        throw new Exception("Migration Exception: 'Resume Next' not supported"); 
                        break;
                    default:
                        CRSGeneral.prObtenError("EnviaDialogo",e ); 
                        break;
                }
            }
			
            return result;
        }
		
        */

        /*
        static public string sfncVerificaConsulta111( OLERut.Conexion cnxpConexionRut,  int lpNumNom,  string spCuenta, ref  string spMensaje, ref  DatosEjecutivo ejepEjecutivo)
        {
            string result = String.Empty;
            string STR_ALTA_EJE = String.Empty;
            DatosEjecutivo ejelEjecutivo111 = DatosEjecutivo.CreateInstance();
            int ilResConS111 = 0;
            string slConS111 = String.Empty;
            string slCausaS111 = String.Empty;
            string slConsulta = String.Empty;
            string slCadena1 = String.Empty;
            string slCadena2 = String.Empty;
            string slCadena3 = String.Empty;
            string slFolio = String.Empty;
            string slCampo = String.Empty;
			
            try
            {
					
                    slFolio = lpNumNom.ToString(); //al slFolio se le asigna el númerro de nomina
					
                    spMensaje = new String(' ', 55);
                    spMensaje = StringsHelper.MidAssignment(spMensaje, 1, "C430"); //Sistema
                    spMensaje = StringsHelper.MidAssignment(spMensaje, 5, CORBD.PROCESO_CONSULTA); //clave de proceso
                    spMensaje = StringsHelper.MidAssignment(spMensaje, 8, "00"); //clave tipo de alta
                    spMensaje = StringsHelper.MidAssignment(spMensaje, 10, CORBD.TIPO_TRAMITE); //clave tipo de tramite
                    spMensaje = StringsHelper.MidAssignment(spMensaje, 12, StringsHelper.Format(slFolio, "00000000")); //numero de slFolio
                    spMensaje = StringsHelper.MidAssignment(spMensaje, 20, StringsHelper.Format(Conversion.Str(CORVB.NULL_INTEGER), "000000000000")); //numero de nomina
                    spMensaje = StringsHelper.MidAssignment(spMensaje, 32, CORBD.TRANSACCION_CONSULTA); //Transacción
                    spMensaje = StringsHelper.MidAssignment(spMensaje, 36, spCuenta); //cuenta
					
                    slConsulta = spMensaje;
					
                    //envia la cadena al rut
                    //  prPreparaConexion cnxpConexionRut   'Prepara objeto Conexion
                    string tempRefParam = "S753-CONALTAS";
                    ilResConS111 = cnxpConexionRut.RutReadWrite(ref slConsulta, ref tempRefParam);
                    Application.DoEvents();
                    slConS111 = slConsulta;
					
                    if (ilResConS111 != CORVB.NULL_INTEGER)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("ERROR EN EL ENVIO DE LA INFORMACION ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    } else
                    {
						
                        //Obtengo los datos del S111
                        slCadena1 = Strings.Mid(slConS111, 1243, 151).Trim();
                        slCadena2 = Strings.Mid(slConS111, 38, 371).Trim();
                        slCadena3 = Strings.Mid(slConS111, 1608, 31).Trim();
						
                        ejelEjecutivo111.sNombre = Strings.Mid(slCadena1, 1, 26).Trim();
                        ejelEjecutivo111.sCalle = Strings.Mid(slCadena1, 46, 35).Trim();
                        ejelEjecutivo111.sColonia = Strings.Mid(slCadena1, 81, 25).Trim();
                        ejelEjecutivo111.sCiudad = Strings.Mid(slCadena1, 106, 25).Trim();
                        //    pszEntFedS111 = Trim$(Mid(slCadena1, 127, 4))
                        ejelEjecutivo111.sCP = Strings.Mid(slCadena1, 133, 5).Trim();
                        if (Strings.Mid(slCadena1, 138, 1).Trim() == "1")
                        {
                            ejelEjecutivo111.sTipoCuenta = "       Básica       ";
                        }
                        if (Strings.Mid(slCadena1, 138, 1).Trim() == "2")
                        {
                            ejelEjecutivo111.sTipoCuenta = "      Adicional     ";
                        }
                        if (Strings.Mid(slCadena1, 138, 1).Trim() == "3")
                        {
                            ejelEjecutivo111.sTipoCuenta = "Básica con Adicional";
                        }
						
						
                        ejelEjecutivo111.sSucursal = Strings.Mid(slCadena1, 139, 4).Trim();
                        ejelEjecutivo111.sCorte = Strings.Mid(slCadena1, 143, 2).Trim();
                        ejelEjecutivo111.sSexo = Strings.Mid(slCadena1, 144, 1).Trim();
                        ejelEjecutivo111.sTelDomicilio = Strings.Mid(slCadena1, 27, 7).Trim();
                        ejelEjecutivo111.sTelOficina = Strings.Mid(slCadena1, 34, 7).Trim();
                        ejelEjecutivo111.sExt = Strings.Mid(slCadena1, 41, 4).Trim();
                        slCausaS111 = Strings.Mid(slCadena3, 1, 19).Trim();
                        ejelEjecutivo111.sFecAlta = Strings.Mid(slCadena3, 20, 6).Trim();
                        ejelEjecutivo111.sFecModificacion = Strings.Mid(slCadena3, 26, 6).Trim();
                        ejelEjecutivo111.sLimiteCredito = Strings.Mid(slCadena2, 21, 9).Trim();
						
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(STR_ALTA_EJE + spCuenta, CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                        slCampo = sfncValidaDatos(ejelEjecutivo111, ejepEjecutivo);
                        result = slCampo;
                        //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                        if (String.IsNullOrEmpty(slCampo.Trim()))
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
                            Interaction.MsgBox("Transacción Completa. Hay Inconsistencia de Datos en el S111 en el campo " + slCampo, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        }
                    }
                }
                catch (Exception e)
            {
				
                CRSGeneral.prObtenError("VerificaConsulta111",e );
            }
            return result;
        }
		
        */

        static public string sfncValidaDatos(DatosEjecutivo ejepEjecutivo111, DatosEjecutivo ejepEjecutivoLocal)
        {
            //Realiza las validaciones de datos con los capturados y los obtenidos del S111
            string result = String.Empty;
            if (ejepEjecutivo111.sNombre != ejepEjecutivoLocal.sNombre.Trim())
            {
                result = "Nombre";
            }
            else if (ejepEjecutivo111.sCalle != ejepEjecutivoLocal.sCalle.Trim())
            {
                result = "Calle";
            }
            else if (ejepEjecutivo111.sColonia != ejepEjecutivoLocal.sColonia.Trim())
            {
                result = "Colonia";
                //    ElseIf ejepEjecutivo111.sCiudad <> Trim$(ejepEjecutivoLocal.sCiudad) Then
                //      sfncValidaDatos = "Ciudad"
            }
            else if (ejepEjecutivo111.sTipoCuenta.Trim() != "Básica")
            {
                result = "Tipo de Cuenta";
            }
            else if (Conversion.Val(ejepEjecutivo111.sSucursal) != StringsHelper.DoubleValue(ejepEjecutivoLocal.sSucursal.Trim()))
            {
                result = "Sucursal";
            }
            else if (StringsHelper.Format(Conversion.Val(ejepEjecutivo111.sCorte), "00") != StringsHelper.Format(Conversion.Val(ejepEjecutivoLocal.sCorte.Trim()), "00"))
            {
                result = "Dia de corte";
                //    ElseIf ejepEjecutivo111.sSexo <> Trim$(ejepEjecutivoLocal.sSexo) Then
                //      sfncValidaDatos = "Sexo"
            }
            else if (Conversion.Val(ejepEjecutivo111.sTelDomicilio) != Conversion.Val(ejepEjecutivoLocal.sTelDomicilio.Substring(ejepEjecutivoLocal.sTelDomicilio.Length - Math.Min(ejepEjecutivoLocal.sTelDomicilio.Length, ejepEjecutivo111.sTelDomicilio.Length)).Trim()))
            {
                result = "Tel. Domicilio";
            }
            else if (Conversion.Val(ejepEjecutivo111.sTelOficina) != Conversion.Val(ejepEjecutivoLocal.sTelOficina.Substring(ejepEjecutivoLocal.sTelOficina.Length - Math.Min(ejepEjecutivoLocal.sTelOficina.Length, ejepEjecutivo111.sTelOficina.Length)).Trim()))
            {
                result = "Tel. Oficina.";
            }
            else if (Conversion.Val(ejepEjecutivo111.sExt) != Conversion.Val(ejepEjecutivoLocal.sExt.Substring(ejepEjecutivoLocal.sExt.Length - Math.Min(ejepEjecutivoLocal.sExt.Length, ejepEjecutivo111.sExt.Length))))
            {
                result = "Extensión";
                //    ElseIf ejepEjecutivo111.sFecAlta <> Trim$(IIf(Len(ejepEjecutivoLocal.sFecAlta) > 6, Mid$(ejepEjecutivoLocal.sFecAlta, 3, 6), ejepEjecutivoLocal.sFecAlta)) Then
                //      sfncValidaDatos = "Fecha de alta"
            }
            return result;
        }

        static public void prLog(string spCadena)
        {
            string sArchivo = "C:\\windows\\Escritorio\\Dialogo.Log";
            FileSystem.FileOpen(100, sArchivo, OpenMode.Append, OpenAccess.Default, OpenShare.Default, -1);
            FileSystem.PrintLine(100, spCadena);
            FileSystem.FileClose(100);
        }

        static public mtcEjecutivo ejefncGeneraEjecutivoMasivo(ref  string spRegistro, ref  string spSeparador)
        {
            mtcEjecutivo result = new mtcEjecutivo();
            try
            {
                //Sección del ejecutivo
                result.iEjePrefijo = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 1, spSeparador));
                result.iGpoBanco = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 2, spSeparador));
                result.lEmpNum = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 3, spSeparador));
                result.lEjeNum = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 4, spSeparador));
                result.iEjeRollOver = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 5, spSeparador));
                result.iEjeDigit = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 6, spSeparador));

                //Sección de datos Generales del TarjetaHabiente
                result.sEjeNombre = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 7, spSeparador).Trim();
                result.sEjeRFC = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 8, spSeparador).Trim();
                result.lEjeSueldo = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 9, spSeparador));
                result.sEjeNumNom = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 10, spSeparador);

                result.sEjeCentroCosto = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 11, spSeparador);
                result.iEjeNivel = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 12, spSeparador));

                //Valida nombre del ejecutivo y sus datos
                result.sEjeNomGrabado = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 13, spSeparador).Trim();
                result.iNacionalidad = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 14, spSeparador));
                result.sEjeCalle = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 15, spSeparador);
                result.sEjeColonia = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 16, spSeparador);
                result.sEjePoblacion = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 17, spSeparador);
                result.sEjeEstado = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 18, spSeparador);
                result.iEjeZP = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 19, spSeparador));

                result.lEjeCP = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 20, spSeparador));

                result.sEjeTelefonoDomicilio = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 21, spSeparador);
                result.sEjeTelefonoOficina = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 22, spSeparador);
                result.sEjeExtension = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 23, spSeparador);
                result.sEjeFax = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 24, spSeparador);

                //Sección de datos Adicionales del TarjetaHabiente
                result.lEjeLimiteCredito = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 25, spSeparador));
                result.lRegNum = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 26, spSeparador));
                result.sEjeStatus = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 27, spSeparador);
                result.sEjeCuentaBanamex = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 28, spSeparador);
                result.sEjeSexo = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 29, spSeparador);
                result.sEjeSucTrans = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 30, spSeparador);
                result.sEjeSucPromotora = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 31, spSeparador);
                result.sEjeOrigen = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 32, spSeparador);
                result.sEjeActiSubacti = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 33, spSeparador);

                //Campos Nuevos de Ejecutivo
                result.sEjeDomCalle = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 34, spSeparador);
                result.sEjeDomColonia = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 35, spSeparador);
                result.sEjeDomCiudad = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 36, spSeparador);
                result.sEjeDomPoblacion = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 37, spSeparador);
                result.sEjeDomEstado = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 38, spSeparador);
                result.lEjeDomCP = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 39, spSeparador));
                result.sEjeEmail = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 40, spSeparador);
                result.sEjeCtaContable = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 41, spSeparador);
                result.iEjeGenPinPla = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 42, spSeparador));
                result.lEjeLimDisEfec = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 43, spSeparador));
                result.sEjeTipoCuenta = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 44, spSeparador);
                result.sTipoFacturacion = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 45, spSeparador);
                result.iSkipPaymentFlag = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 46, spSeparador));
                result.iTablaMCC = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 47, spSeparador));
                result.sIndicadorLimDisp = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 48, spSeparador);
                result.sEjeCuentaPadre = CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 49, spSeparador);
                result.sEjeUsuarioCam = CRSParametros.sgUserID;
                result.lEjeFechaAlta = Int32.Parse(CRSGeneral.fncsObtenerElementoDeCadena(ref spRegistro, 50, spSeparador));
            }
            catch (Exception e)
            {


                CRSGeneral.prObtenError("GeneraEjecutivoMasivo", e);
            }
            return result;
        }

        static public int ifncAltaEjecutivo(mtcEjecutivo mejeEjecutivo, string spStatus, string spMensaje, int ipOperacion)
        {
            string pszEjeCC = String.Empty;
            try
            {
                //Construye cadena de alta de a M111 (Sybase)
                //Sección del ejecutivo
                CORVAR.pszgblsql = "exec sp_RegAltaMasTarjHab ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + mejeEjecutivo.iEjePrefijo.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.iGpoBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.lEmpNum.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.lEjeNum.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.iEjeRollOver.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.iEjeDigit.ToString();
                //Sección de datos Generales del TarjetaHabiente
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeNombre + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeRFC + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.lEjeSueldo.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeNumNom + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + pszEjeCC + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.iEjeNivel.ToString();
                //Validar el formato del nombre grabado
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeNomGrabado + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeCalle + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeColonia + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjePoblacion + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.iEjeZP.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.lEjeCP.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeTelefonoDomicilio + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeTelefonoOficina + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeExtension + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeFax + "'";

                //Sección de datos Adicionales del TarjetaHabiente
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.lEjeLimiteCredito.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + mejeEjecutivo.lRegNum.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeStatus + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeSexo + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeSucTrans.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeSucPromotora.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeOrigen + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + mejeEjecutivo.sEjeActiSubacti + "'";

                //Campos Nuevos de Ejecutivo
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sEjeDomCalle + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sEjeDomColonia + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sEjeDomCiudad + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sEjeDomPoblacion + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sEjeDomEstado + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + mejeEjecutivo.lEjeDomCP.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sEjeEmail + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sEjeCtaContable + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + mejeEjecutivo.iEjeGenPinPla.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + mejeEjecutivo.lEjeLimDisEfec.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + CRSParametros.sgUserID + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sEjeTipoCuenta + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sTipoFacturacion + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + mejeEjecutivo.iSkipPaymentFlag.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + mejeEjecutivo.iTablaMCC.ToString();
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(mejeEjecutivo.sIndicadorLimDisp.Trim()))
                {
                    mejeEjecutivo.sIndicadorLimDisp = "P";
                }
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + mejeEjecutivo.sIndicadorLimDisp + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + mejeEjecutivo.lEjeFechaAlta.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + spStatus + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + spMensaje + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "0";
                //Comentar en Producción
                //prLog "INSERT EJECUTIVO " & Now & pszgblsql
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("AltaEjecutivo", e);
            }
            return 0;
        }

        static public void prLongitudes()
        {
            int ilIndice = 0;
            try
            {
                ilIndice = 0;
                CORVAR.pszgblsql = "select ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "pgs_rep_prefijo";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", pgs_rep_banco";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", pgs_long_emp";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ", pgs_long_eje";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCPGS01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " ORDER BY pgs_rep_prefijo";
                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {

                        aigLongitudes = ArraysHelper.RedimPreserve<int[,]>(aigLongitudes, new int[] { 4, ilIndice + 1 });
                        aigLongitudes[0, ilIndice] = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                        aigLongitudes[1, ilIndice] = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 2));
                        aigLongitudes[2, ilIndice] = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 3));
                        aigLongitudes[3, ilIndice] = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 4));
                        ilIndice++;
                    }
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("Longitudes", e);
            }
        }

        static public int ifncLongitudEmpresa(int ipEjePrefijo, int ipBanco)
        {
            int result = 0;
            try
            {
                for (int ilIndice = 0; ilIndice <= aigLongitudes.GetUpperBound(1); ilIndice++)
                {
                    if (aigLongitudes[0, ilIndice] == ipEjePrefijo)
                    {
                        if (aigLongitudes[1, ilIndice] == ipBanco)
                        {
                            result = aigLongitudes[2, ilIndice];
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("LongitudEmpresa", e);
            }
            return result;
        }

        static public int ifncLongitudEjecutivo(int ipEjePrefijo, int ipBanco)
        {
            int result = 0;
            try
            {
                for (int ilIndice = 0; ilIndice <= aigLongitudes.GetUpperBound(1); ilIndice++)
                {
                    if (aigLongitudes[0, ilIndice] == ipEjePrefijo)
                    {
                        if (aigLongitudes[1, ilIndice] == ipBanco)
                        {
                            result = aigLongitudes[3, ilIndice];
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("LongitudEjecutivo", e);
            }
            return result;
        }

        static public string sfncObtenErrorDialogo(int ipError, TipoSistema ipTipoSistema)
        {
            string result = String.Empty;
            string slSistema = String.Empty;
            string slMensaje = String.Empty;
            try
            {
                switch (ipTipoSistema)
                {
                    case TipoSistema.cteSistemaTandem:
                        slSistema = cteTandem;
                        break;
                    case TipoSistema.cteSistemaS111:
                        slSistema = cteS111;
                        break;
                    case TipoSistema.cteSistemaS016:
                        slSistema = cteS016;
                        break;
                }
                CORVAR.pszgblsql = "SELECT err_desc from MTCERR01 ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE err_cve = " + ipError.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and err_origen = '" + slSistema + "'";
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        slMensaje = CRSGeneral.vfncVPO(VBSQL.SqlData(CORVAR.hgblConexion, 1), "Error Desconocido");
                    }
                }
                else
                {
                    slMensaje = "No se encuentra registrado este Error en la base de datos.";
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                result = CRSGeneral.vfncVPO(slMensaje, "Error Desconocido");
            }
            catch
            {
                CRSGeneral.prObtenError("ObtenErrorDialogo");
            }
            return result;

        }


        //********************************** Respaldo de Código que envia dialogo a TANDEM **********************************
        //'Proceso que envia al Tandem por medio del rut
        /*static public bool bfncEnviaDialogo(ref  OLERut.Conexion cnxpConexionRut, ref  int lpNumNom, ref  string spMensaje, ref  string spEnviaRut, ref  string spCuenta, ref  DatosEjecutivo ejepEjecutivo)
        {
            bool result = false;
            int ilRespuestaEnvio = 0;
            string slResMensaje = String.Empty;
            string slCveResTransaccion = String.Empty;
            string slCveTransaccion = String.Empty;
            string slRespS111 = String.Empty;
            string slDescMsg = String.Empty;
            string slDescMsgS111 = String.Empty;
            string slMensaje = String.Empty;
			
            try
            {
                    spEnviaRut = "Error";
                    //Se envia mensaje al TANDEM
                    //  prPreparaConexion cnxpConexionRut   'Prepara objeto Conexion
                    string tempRefParam = "S753-CONALTAS";
                    ilRespuestaEnvio = cnxpConexionRut.RutReadWrite(ref spMensaje, ref tempRefParam);
					
                    //Se Asigna el Valor de la Respuesta a spMensaje Asignado por el OLE Server spMensaje trae la respuesta de la Transacción
                    slResMensaje = spMensaje;
                    if (ilRespuestaEnvio != 0)
                    { //existe un error de comunicación o servicio de alta no disponible
                        CORVAR.pszgblsql = "Select err_desc from MTCERR01 where err_cve = " + Conversion.Str(ilRespuestaEnvio) + " and err_origen = 'tandem'";
                        if (CORPROC2.Obtiene_Registros() != 0)
                        {
                            if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                            {
                                slDescMsg = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                            }
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Existe un error en el tandem No.: " + Conversion.Str(ilRespuestaEnvio) + "   " + slDescMsg, CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Favor de intentar más tarde", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
						
                    } else
                    {
                        //hay respuesta de la transacción
                        slCveResTransaccion = Strings.Mid(slResMensaje, 32, 2); //si es diferente de cero es error
                        slCveTransaccion = Strings.Mid(slResMensaje, 34, 4); //si no se dio de alta trae 5181, si la dio de alta trae 0000
                        slRespS111 = Strings.Mid(slResMensaje, 38, 30); //0030 cta existe, 0048 problema con datos
                        slMensaje = Strings.Mid(slResMensaje, 39, 60);
						
                        //se revisa el mensaje enviado por la respuesta de transaccion que no sea otro tipo de error
                        //como error en la comunicación de envio
                        if (Strings.Mid(slCveResTransaccion, 1, 1) != "0" && Strings.Mid(slCveResTransaccion, 1, 1) != "1" && Strings.Mid(slCveResTransaccion, 1, 1) != "2" && Strings.Mid(slCveResTransaccion, 1, 1) != "3" && Strings.Mid(slCveResTransaccion, 1, 1) != "4" && Strings.Mid(slCveResTransaccion, 1, 1) != "5" && Strings.Mid(slCveResTransaccion, 1, 1) != "6" && Strings.Mid(slCveResTransaccion, 1, 1) != "7" && Strings.Mid(slCveResTransaccion, 1, 1) != "8" && Strings.Mid(slCveResTransaccion, 1, 1) != "9")
                        {
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("Existe un error de comunicaciones. Avise a sistemas", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                            return result;
                        }
						
                        //si el codigo es iagula al 0030 ya existe la cuenta
                        if (slRespS111.Trim() == "0030")
                        {
                            spEnviaRut = "Existe";
                            return result;
                        }
						
                        //se revisa el mensaje enviado por la respuesta de transaccion
                        if (Double.Parse(slCveResTransaccion) != CORVB.NULL_INTEGER)
                        {
                            CORVAR.pszgblsql = "select err_desc from MTCERR01 ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "where err_cve = " + slCveResTransaccion;
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and err_origen = 'tandem'";
                            if (CORPROC2.Obtiene_Registros() != 0)
                            {
                                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                                {
                                    slDescMsg = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                                    MessageBox.Show("Mensaje de respuesta del diálogo " + slDescMsg, Application.ProductName);
                                }
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
							
                        }
                        //se verifica que no sea error de comunicacion del S111
                        if ((slCveResTransaccion == "04" || slCveResTransaccion == "05") && slRespS111 == CORVB.NULL_STRING)
                        {
                            slCveResTransaccion = "01";
                        }
						
                        //se toma la acción a ejecutar dependiendo de la cve de respuesta del transacción
                        switch(slCveResTransaccion)
                        {
                            case "00" :  //transaccion OK 
                                if (Double.Parse(slCveTransaccion) == CORVB.NULL_INTEGER)
                                {
                                    //verificamos que haya entrado correctamente en el S111
                                    if ((Strings.Mid(slRespS111, 1, 4) == CORBD.TIPO_TRANSACCION && Strings.Mid(slRespS111, 5, 16) == spCuenta) || (Strings.Mid(slRespS111, 1, 4).Trim() == CORVB.NULL_STRING.Trim() && Strings.Mid(slRespS111, 5, 16).Trim() == CORVB.NULL_STRING.Trim()))
                                    {
                                        //realiza la consulta al S111
                                        sfncVerificaConsulta111(cnxpConexionRut, lpNumNom, spCuenta, ref spMensaje, ref ejepEjecutivo);
                                        //se logro dar de alta la cta
                                        spEnviaRut = "OK";
                                        result = true;
                                    }
                                } 
                                break;
                            case "01" : case "03" :  //se grava en reenvios time out S111 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                Interaction.MsgBox("El servidor CONALTAS no esta disponible", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT); 
                                break;
                            case "02" :  //sale de secuenci por error de informacion 
                                result = true; 
                                break;
                            case "04" : case "05" :  //B_ok,A_no         ,  B_no 
                                //se busca el tipo de error en la tabla de MTCERR01 
                                if (Conversion.Val(slRespS111) != CORVB.NULL_INTEGER)
                                {
                                    CORVAR.pszgblsql = "select err_desc from MTCERR01 ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where err_cve = " + Conversion.Str(Conversion.Val(slRespS111)) + " and  err_origen = 'S111'";
									
                                    if (CORPROC2.Obtiene_Registros() != 0)
                                    {
                                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                                        {
                                            slDescMsgS111 = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                                        }
                                    }
                                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
									
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("Mensaje del S111 : " + slDescMsgS111, (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                                } 
								 
                                if (slCveResTransaccion == "05")
                                { //basica no_ok
                                } else
                                {
                                    //no realiza nada debido que si es 04 la basica se dio de alta y no existe adicional
                                } 
                                break;
                            case "06" : case "09" :  // para el s16   B_ok,A_ok,C_no    ,  B_ok,A_no,C_no error de informacion 
                                spEnviaRut = "OK"; 
                                result = true; 
                                break;
                            case "07" : case "08" :  //para el s16 problemas de comunicacion B_ok, A_ok, C_no    ,B_ok,A_no,C_no 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                Interaction.MsgBox("Existen problemas de Comunicaciones", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT); 
                                break;
                            case "10" : case "12" :  //B , 237, C , error de comunicacion 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                Interaction.MsgBox("Existen problemas de Comunicaciones", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT); 
                                break;
                            case "11" : case "13" :  //B , 237, C , error de informacion 
								 
                                break;
                            case "14" :  //Parámetro PATHCOM 237 incorrecto 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                Interaction.MsgBox("Existen problemas de Comunicaciones, PATHCOM incorrecto.", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT); 
                                break;
                            case "21" : case "22" : case "23" :  //clientes no x homonimos 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                Interaction.MsgBox("Existen problemas de Comunicaciones,Clientes no por homonimos.", CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT); 
                                break;
                            default:
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                Interaction.MsgBox("Error no definido. ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT); 
                                break;
                        }
                    }
                    //    Debug.Print "------Diálogo de Respuesta ------------------------------------------------------------"
                    //    Debug.Print Time & Date
                    //    Debug.Print spCuenta
                    //    Debug.Print slRespS111
                    //    Debug.Print slDescMsgS111
                    //    prLog "Resp " & spCuenta & " " & Time & " " & Date & " " & " Resp:" & slRespS111 & " DescMsg:" & slDescMsgS111
                    //    Debug.Print "------Fin Diálogo de Respuesta ------------------------------------------------------------"
                }
                catch (Exception e)
            {
				
				
                switch(Information.Err().Number)
                {
                    case 28 : 
                        //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead. 
                        throw new Exception("Migration Exception: 'Resume Next' not supported"); 
                        break;
                }
                CRSGeneral.prObtenError("EnviaDialogo",e );
            }
            return result;
        }
        //******************************* Fin de Respaldo de Código que envia dialogo a TANDEM *******************************
        */

        static public int ifncEnviaCambioS111(TipoCambioS111 ipTipoCambio, mtcEjecutivo dejpEjecutivo)
        {
            int result = 0;
            object ConComDrive = null;
            object ID_MEE_NCE_EB = null;
            object ID_MEE_TOF_PIC = null;
            bool blCxnEstablecida = false;
            Conecta.ConexionesHost cnxConexion = new Conecta.ConexionesHost();
            string slCadena = String.Empty;
            string slRespuestaS111 = String.Empty;
            int iPos = 0;
            string pszCaracter = String.Empty;
            string slMensajeS111 = String.Empty;
            string pszCadPaso = String.Empty;

            result = 0;

            int lLim_Cred_Dola = 0;
            int lLim_Cred = 0;

            bool mbPrimTran = false;
            dejpEjecutivo.sEjeCuentaBanamex = Seguridad.fncsSustituir(dejpEjecutivo.sEjeCuentaBanamex, " ", "");

            switch (ipTipoCambio)
            {
                case TipoCambioS111.cteNombre:  //Cambio de Nombre 
                    slCadena = CORCONST.MODIFICA_NOMBRE_EN_LINEA + " ";  //5330 
                    slCadena = slCadena + dejpEjecutivo.sEjeCuentaBanamex + " ";  //numero de cuenta 
                    slCadena = slCadena + dejpEjecutivo.sEjeNomGrabado;  //nombre de grabación 
                    slMensajeS111 = "Cambio de Nombre";
                    //mesaje que despliega el status del cambio 
                    CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Nombre";
                    break;
                case TipoCambioS111.cteCredito:  //Cambio de la línea de crédito 
                    slCadena = CORCONST.MODIFICA_CREDITO_EN_EJE + " ";  //5117 
                    slCadena = slCadena + dejpEjecutivo.sEjeCuentaBanamex;  //numero de cuenta 
                    slCadena = slCadena + Conversion.Str(dejpEjecutivo.lEjeLimiteCredito);  //limite de credito 
                    slMensajeS111 = "Cambio de línea de crédito";
                    //Mesaje que despliega el status del cambio 
                    CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Límite de Crédito";
                    break;
                case TipoCambioS111.cteDomicilio:  //Cambio de domicilio 
                    //Mesaje que despliega el status del cambio 
                    CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Dirección";

                    //Formatea todos los campos 
                    if (dejpEjecutivo.sEjeNomGrabado.Length < 26)
                    {
                        pszCadPaso = new String(' ', 26);
                        //UPGRADE_NOTE: (7004) Member access to a non initialized variable. Variable ID_MEE_NCE_EB Member Text.
                        pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, Convert.ToString(ReflectionHelper.GetMember(ID_MEE_NCE_EB, "Text")));
                        dejpEjecutivo.sEjeNomGrabado = pszCadPaso;
                    }
                    else
                    {
                        //UPGRADE_NOTE: (7004) Member access to a non initialized variable. Variable ID_MEE_NCE_EB Member Text.
                        dejpEjecutivo.sEjeNomGrabado = Strings.Mid(Convert.ToString(ReflectionHelper.GetMember(ID_MEE_NCE_EB, "Text")), 1, 26);
                    }
                    //Calle 
                    if (dejpEjecutivo.sEjeCalle.Length < 35)
                    {
                        pszCadPaso = new String(' ', 35);
                        pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, dejpEjecutivo.sEjeCalle);
                        dejpEjecutivo.sEjeCalle = pszCadPaso;
                    }
                    else
                    {
                        dejpEjecutivo.sEjeCalle = Strings.Mid(dejpEjecutivo.sEjeCalle, 1, 35);
                    }
                    //Colonia 
                    if (dejpEjecutivo.sEjeColonia.Length < 25)
                    {
                        pszCadPaso = new String(' ', 25);
                        pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, dejpEjecutivo.sEjeColonia);
                        dejpEjecutivo.sEjeColonia = pszCadPaso;
                    }
                    else
                    {
                        dejpEjecutivo.sEjeColonia = Strings.Mid(dejpEjecutivo.sEjeColonia, 1, 25);
                    }
                    //ZP 
                    //UPGRADE_WARNING: (1041) Len has a new behavior. 
                    if (Marshal.SizeOf(dejpEjecutivo.iEjeZP) < 2)
                    {
                        dejpEjecutivo.iEjeZP = StringsHelper.IntValue(StringsHelper.Format(dejpEjecutivo.iEjeZP, "00"));
                    }
                    else
                    {
                        dejpEjecutivo.iEjeZP = StringsHelper.IntValue(Strings.Mid(dejpEjecutivo.iEjeZP.ToString(), 1, 2));
                    }
                    //Población 
                    if (dejpEjecutivo.sEjePoblacion.Length < 25)
                    {
                        pszCadPaso = new String(' ', 25);
                        pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, dejpEjecutivo.sEjePoblacion);
                        dejpEjecutivo.sEjePoblacion = pszCadPaso;
                    }
                    else
                    {
                        dejpEjecutivo.sEjePoblacion = Strings.Mid(dejpEjecutivo.sEjePoblacion, 1, 25);
                    }

                    //TELÉFONO DOMICILIO 
                    if (dejpEjecutivo.sEjeTelefonoDomicilio == CORVB.NULL_STRING)
                    {
                        dejpEjecutivo.sEjeTelefonoDomicilio = "0000000";
                    }
                    else
                    {
                        dejpEjecutivo.sEjeTelefonoDomicilio = dejpEjecutivo.sEjeTelefonoDomicilio;
                    }
                    if (dejpEjecutivo.sEjeTelefonoDomicilio.Length < 7)
                    {
                        dejpEjecutivo.sEjeTelefonoDomicilio = StringsHelper.Format(dejpEjecutivo.sEjeTelefonoDomicilio, "0000000");
                    }
                    //Tel Oficina 
                    //UPGRADE_NOTE: (7004) Member access to a non initialized variable. Variable ID_MEE_TOF_PIC Member Text. 
                    if (Convert.ToString(ReflectionHelper.GetMember(ID_MEE_TOF_PIC, "Text")) == CORVB.NULL_STRING)
                    {
                        dejpEjecutivo.sEjeTelefonoOficina = "0000000";
                    }
                    else
                    {
                        dejpEjecutivo.sEjeTelefonoOficina = dejpEjecutivo.sEjeTelefonoOficina;
                    }
                    if (dejpEjecutivo.sEjeTelefonoOficina.Length < 7)
                    {
                        dejpEjecutivo.sEjeTelefonoOficina = StringsHelper.Format(dejpEjecutivo.sEjeTelefonoOficina, "0000000");
                    }

                    //Extension 
                    if (dejpEjecutivo.sEjeExtension.Length < 4 || (dejpEjecutivo.sEjeExtension) == CORVB.NULL_STRING)
                    {
                        dejpEjecutivo.sEjeExtension = StringsHelper.Format(dejpEjecutivo.sEjeExtension, "0000");
                    }
                    else
                    {
                        dejpEjecutivo.sEjeExtension = dejpEjecutivo.sEjeExtension;
                    }
                    //sexo 
                    if (dejpEjecutivo.sEjeSexo == CORVB.NULL_STRING)
                    {
                        dejpEjecutivo.sEjeSexo = new String(' ', 1);
                    }
                    slCadena = CORCONST.MODIFICA_EMPRESA_MASIVOS + " ";
                    slCadena = slCadena + dejpEjecutivo.sEjeCuentaBanamex + " ";  //numero de cuenta 
                    slCadena = slCadena + "M" + Strings.Chr(28).ToString();  //modificación 
                    slCadena = slCadena + dejpEjecutivo.sEjeNomGrabado + Strings.Chr(28).ToString();  //nombre 
                    slCadena = slCadena + dejpEjecutivo.sEjeSexo + Strings.Chr(28).ToString();  //sexo 
                    slCadena = slCadena + dejpEjecutivo.sEjeCalle + Strings.Chr(28).ToString();
                    slCadena = slCadena + dejpEjecutivo.sEjeColonia + Strings.Chr(28).ToString();
                    slCadena = slCadena + dejpEjecutivo.iEjeZP.ToString() + Strings.Chr(28).ToString();
                    slCadena = slCadena + dejpEjecutivo.sEjePoblacion + Strings.Chr(28).ToString();
                    slCadena = slCadena + StringsHelper.Format(dejpEjecutivo.lEjeCP, "00000") + Strings.Chr(28).ToString();
                    slCadena = slCadena + dejpEjecutivo.sEjeTelefonoDomicilio + Strings.Chr(28).ToString();
                    slCadena = slCadena + dejpEjecutivo.sEjeTelefonoOficina + Strings.Chr(28).ToString();
                    slCadena = slCadena + dejpEjecutivo.sEjeExtension + Strings.Chr(28).ToString();
                    slCadena = slCadena + StringsHelper.Format(Strings.Mid(dejpEjecutivo.sEjeActiSubacti.Trim(), 1, 2), "00") + Strings.Chr(28).ToString();  //actividad 
                    slCadena = slCadena + StringsHelper.Format(Strings.Mid(dejpEjecutivo.sEjeActiSubacti.Trim(), 3, 2), "00") + Strings.Chr(28).ToString();
                    slCadena = slCadena + dejpEjecutivo.sEjeRFC.Trim() + Strings.Chr(28).ToString();
                    slCadena = slCadena + " ";
                    slMensajeS111 = "Cambio de datos generales";
                    break;
            }

            //Establece la conexión al S111
            //  Set cnxConexion = New Conexion
            cnxConexion.Termina_Conexion();
            if (cnxConexion.Inicia_Conexion())
            {
                blCxnEstablecida = true;
            }
            else
            {
                blCxnEstablecida = true;
            }
            //envia la cadena al S111
            if (blCxnEstablecida)
            {
                //UPGRADE_NOTE: (7004) Member access to a non initialized variable. Variable ConComDrive Member Envia_Mensaje.
                slRespuestaS111 = Convert.ToString(ReflectionHelper.Invoke(ConComDrive, "Envia_Mensaje", new object[] { slCadena }));
                if (slRespuestaS111 == CORVB.NULL_STRING)
                {
                    //UPGRADE_NOTE: (7004) Member access to a non initialized variable. Variable ConComDrive Member Envia_Mensaje.
                    slRespuestaS111 = Convert.ToString(ReflectionHelper.Invoke(ConComDrive, "Envia_Mensaje", new object[] { slCadena }));
                }

                slRespuestaS111 = CORPROC.Muestra_Mensaje(slRespuestaS111);

                //verifica que la respuesta sea VUELVA A DARSE DE ALTA. para realizar nuevamente la conexión
                if ((slRespuestaS111.IndexOf("VUELVA A DARSE DE ALTA") >= 0) || (slRespuestaS111.IndexOf(" FAVOR DE DARSE DE ALTA ") >= 0) || (slRespuestaS111.IndexOf("SERVICIO NO EXISTE") >= 0))
                {
                    result = -1;
                    Cursor.Current = Cursors.Default;
                    if (slRespuestaS111.IndexOf("SERVICIO NO EXISTE") >= 0)
                    {
                        MessageBox.Show(" " + slRespuestaS111 + " AVISE A SISTEMAS.", "S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(" " + slRespuestaS111 + " E INICIE NUEVAMENTE EL PROCESO.", "S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return result;
                }
                Cursor.Current = Cursors.Default;
                //verifica el primer mensaje de confirmaci´+on que manfa el comdrive
                if (slRespuestaS111.IndexOf("Confirmado,Repita Transaccion") >= 0)
                {
                    mbPrimTran = true;
                    //la siguiente variable es false por no hay problemas de ningún tipo
                    return 0;
                }

                if ((slRespuestaS111.IndexOf("TRANSACCION ACEPTADA") >= 0) || (slRespuestaS111.IndexOf("TRANSACCION  ACEPTADA") >= 0) || (slRespuestaS111.IndexOf("LINEA DE CREDITO ACTUALIZADA A") >= 0))
                {
                    if (slRespuestaS111.IndexOf("LINEA DE CREDITO ACTUALIZADA A") >= 0)
                    {
                        MessageBox.Show(" " + slRespuestaS111, "S111", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Transacción aceptada en S111 en " + slMensajeS111, "Mensaje S111", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("No se realizó la transacción en el S111 en " + slMensajeS111 + " " + slRespuestaS111, "Mensaje S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = -1;
                }
            }
            else
            {
                MessageBox.Show("No se ha establecido la conexión al S111" + "No se realizaron los cambios.", "Problemas de conexión al S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = -1;
            }
            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = String.Empty;
            Cursor.Current = Cursors.WaitCursor;
            return result;
        }


        /*static public void  prPreparaConexion(ref  OLERut.Conexion cnxpConexion)
        {
            if (cnxpConexion == null)
            {
                cnxpConexion = new OLERut.Conexion();
            }
            cnxpConexion.Termina_Conexion();
            cnxpConexion.Inicia_Conexion();
        }*/
    }

    /// <summary>
    /// Enumerador para indicar la direccion de relleno de una cadena
    /// Autor: LMHR & CMET
    /// Fecha de creacion: 15/12/2017
    /// Fecha de ultima modificacion: 18/12/2017
    /// </summary>
    public enum FillDirection
    {
        Derecha,
        Izquierda
    }
}