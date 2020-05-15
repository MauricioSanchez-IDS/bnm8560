using System;
using System.Collections.Generic;
using System.Text;
using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Windows.Forms;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic.Compatibility.VB6;
using System.ComponentModel;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 


namespace TCd430
{
    internal class clsCancelaciones
    {
        //'*:********************************************************************************
        //'*:                        EISSA / Banamex - Sistemas                            **
        //'*:------------------------------------------------------------------------------**
        //'*: Responsable:                Miguel A. De la Rosa García (MRG)                **
        //'*: Fecha de Creacion:          2 de Diciembre de 2004                           **
        //'*: Versión:                    1.0.0                                            **
        //'*: Plataforma de Desarrollo:   Visual Basic 6.0                                 **
        //'*:                                                                              **
        //'*: Descripción:    Funcionalidad para realizar cancelaciones de cuentas de      **
        //'*:                 tarjetahabientes o empresas.                                 **
        //'*:********************************************************************************
        //'*:********************************************************************************
        //'*: Opciones de Comportamiento
        //'*:********************************************************************************
        //Option Explicit
        //'*:********************************************************************************
        //'*: Fin: Opciones de Comportamiento
        //'*:********************************************************************************

        //'*:********************************************************************************
        //'*: Constantes Privadas
        //'*:********************************************************************************
        private const string MS_BANCO_MASC = "00";       //'*: Máscara del banco.
        private const int MI_CUENTA_TAM = 16;            //'*: Longitud de la cuenta.
        private const string MS_CUENTA_REGLA = "({#})";  //'*: Regla de validación de la cuenta.
        private const string MS_DISPONIBLE_MIN = "100";  //'*: Mínimo disponible para que una cuenta pueda ser cancelada.
        private const int MI_EJE_TAM_DEFAULT = 3;        //'*: Longitud del ejecutivo por omision.
        private const string MS_MASC_CAR = "0";          //'*: Caracter de relleno de la máscara de ejecutivo y empresa.
        private const string MS_MASC_REGLA = "({[0]})*"; //'*: Regla de validación de la máscara de ejecutivo y empresa.
        private const int MI_NOMBRE_TAM = 80;            //'*: Longitud máxima de nombres.
        private const int MI_PLASTICO_TAM = 8;           //'*: Tamaño del número de plástico.
        private const string MS_PREFIJO_MASC = "0000";   //'*: Máscara del prefijo.
        private const string MS_TABLA_M111 = "MTCCNC01"; //'*: Tabla donde se almacenan las transacciones de cancelaciones.
        //'*:********************************************************************************
        //'*: Fin: Constantes Privadas
        //'*:********************************************************************************

        //'*:********************************************************************************
        //'*: Enumeraciones Privadas
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        //'*: Tipos de transacciones disponibles.
        private enum enmTransaccionTipos
        {
            TTP_304_S_SALDO, //'*: Transacción 304 - Cancelación de cuenta sin saldo.
            TTP_304_C_SALDO, //'*: Transacción 304 - Cancelación de cuenta con saldo.
            TTP_316,         //'*: Transacción 316 - Modificación del límite de disposiciones.
            TTP_377          //'*: Transacción 377 - Consulta detallada de datos de cuenta.
        }
        //'*:--------------------------------------------------------------------------------
        //'*:********************************************************************************
        //'*: Fin: Enumeraciones Privadas
        //'*:********************************************************************************
        //'*:********************************************************************************
        //'*: Enumeraciones Públicas
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        //'*: Status de cancelaciones.
        public enum enmCancelacionStatus
        {
            CST_CANCELADO = -1,  //'*: Transaccion cancelada.
            CST_PENDIENTE = 0,   //'*: Transaccion pendiente de ser aplicada.
            CST_APLICADA = 1,    //'*: Transaccion aplicada.
            CST_SIN_REVISAR = 2 //'*: Transaccion sin revisar por el maker.
        }
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Tipos de cancelaciones disponibles.
        public enum enmCancelacionTipos
        {
            CTP_CUENTA_PADRE,    //'*: Cancelación de cuenta padre.
            CTP_CUENTA_HIJA     //'*: Cancelación de cuenta padre.
        }
        //'*:--------------------------------------------------------------------------------
        //'*:********************************************************************************
        //'*: Fin: Enumeraciones Públicas
        //'*:********************************************************************************

        //'*:********************************************************************************
        //'*: Tipos Privados
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        //'*: Estados (situación) de cuenta.
        public struct typCuentaAsociada
        {
            public string CuentaS;           //'*: Cuenta
            public string CuentahabienteS;   //'*: Cuentahabiente
        }

        //'*:--------------------------------------------------------------------------------
        //'*:********************************************************************************
        //'*: Fin: Tipos Privados
        //'*:********************************************************************************

        //'*:********************************************************************************
        //'*: Tipos Públicos
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        //'*: Estados (situación) de cuenta.
        private struct typCuentaEstado
        {
            public bool CancelableB;                                     //'*: Indica si la cuenta se puede cancelar o no.
            public bool CanceladaB;                                      //'*: Indica que la cuenta ya fue cancelada.
            public string DescripcionS;                                  //'*: Descripción del estado de la cuenta.
            public double DisponibleF;                                   //'*: Efectivo disponible en la cuenta (Saldo).
            //FixedLengthString EstadoS = new FixedLengthString(1); //'*: Clave del estado de la cuenta.
            public string EstadoS;
            public bool SaldoB;                                          //'*: Indica que la cuenta normalment tiene saldo.
            public double SaldoF;                                        //'*: Saldo de la cuenta (Disponible).
            public bool SobregiroB;                                      //'*: Indica que la cuenta está sobregirada.
            public double SobregiroF;                                    //'*: Saldo sobregirado de la cuenta.
            public enmCancelacionStatus StatusTranE;                     //'*: Status del estado de la transaccion.
            public enmCancelacionTipos TipoE;                            //'*: Tipo de cuenta.
        }
        //'*:--------------------------------------------------------------------------------
        //'*:********************************************************************************
        //'*: Fin: Tipos Públicos
        //'*:********************************************************************************



        //'*:********************************************************************************
        //'*: Atributos Privados con Correspondencia en Atributos Públicos
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        //'*: Atributos necesarios para la generación de cuenta.
        //'*:--------------------------------------------------------------------------------
        private int miBanco;           //'*: Número de banco.
        private int mlNumCtasHijas;    //'*: Número de cuentas hijas asociadas.
        private int miDigVerif;        //'*: Dígito verificador.
        private string msEjeMasc;      //'*: Máscara del ejecutivo. Para mantener la consistencia de los atributos de la
                                       //'*: clase, al modificar su valor, se debe alterar el contenido de miEjeTam,
                                       //'*: miEmpMasc y miEmpTam.
        private int mlEjeNum;          //'*: Número de ejecutivo.
        private int miEjeTam;          //'*: Lóngitud de la máscara del ejecutivo. Para mantener la consistencia de los
                                       //'*: atributos de la clase, al modificar su valor, se debe alterar el contenido de
                                       //'*: msEjeMasc, miEmpMasc y miEmpTam.
        private string msEmpMasc;      //'*: Máscara de la empresa. Para mantener la consistencia de los atributos de la
                                       //'*: clase, al modificar su valor, se debe alterar el contenido de msEjeMasc,
                                       //'*: miEjeTam y miEmpTam.
        private int mlEmpNum;          //'*: Número de empresa.
        private int miEmpTam;          //'*: Lóngitud de la máscara de la empresa. Para mantener la consistencia de los
                                       //'*: atributos de la clase, al modificar su valor, se debe alterar el contenido de
                                       //'*: msEjeMasc, miEjeTam y miEmpMasc.
        private int miPrefijo;         //'*: Prefijo.
        private int miRollOver;        //'*: Roll Over.
        private int miNumCtasHijas;
        //'*:--------------------------------------------------------------------------------
        //'*: Atributos para el objeto de acceso a sistemas centrales y cancelaciones.
        //'*:--------------------------------------------------------------------------------
        private string msCheckerNombre;   //'*: Nombre del usuario que autoriza la transacción.
        private string msCheckerNomina;   //'*: Nómina del usuario que autoriza la transacción.
        private string msCuentahabiente;  //'*: Nombre del cuentahabiente.
        private string msMakerNombre;     //'*: Nombre del usuario que solicita la transacción.
        private string msMakerNomina;     //'*: Nómina del usuario que solicita la transacción.
        //'*:--------------------------------------------------------------------------------
        //'*: Atributos informativos de la clase.
        //'*:--------------------------------------------------------------------------------
        private string msTransLog;   //'*: Cadena que contiene la bitacora de las operaciones realizadas.
        private string msUltMsg;     //'*: Cadena que contiene el resultado de la última operación realizada.
        //'*:********************************************************************************
        //'*: Fin: Atributos Privados con Correspondencia en Atributos Públicos
        //'*:********************************************************************************

        //'*:********************************************************************************
        //'*: Atributos Privados sin Correspondencia en Atributos Públicos
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        //'*: Propiedades de la clase.
        //'*:--------------------------------------------------------------------------------
        private string msDispRef;                     //'*: Referencia de cambio de disponible.
        private string msCancRef;                     //'*: Referencia de cancelación de cuenta.
        private typCuentaEstado mcesCuentaDatos;      //'*: Datos de la cuenta.
        private typCuentaEstado[] mxcesCuentaEstados; //'*: Estados (situación) posibles de cuentas.

        public bool tempRefParam;
        public string sTrans;
        public string asCuenta1;
        public string sParamAdi;

        //private struct clsExpresionesRegulares
        //{
        //    public string ExpresionS;
        //    public string ReglaS;
        //}
        //'*:--------------------------------------------------------------------------------
        //'*: Objetos.
        //'*:--------------------------------------------------------------------------------
        private N_ActualizaS111.ClsConectaS111 mscnSisCentrales; //'*: Objeto de conexión a sistemas centrales.
        private EvaluadorExpReg.clsExpresionesRegulares meerEvaluador;            //'*: Objeto para evaluar las entradas externas a la clase en los
                                                                  //'*: valores que modifican atributos privados.
        //'*:********************************************************************************
        //'*: Fin: Atributos Privados sin Correspondencia en Atributos Públicos
        //'*:********************************************************************************

        //'*:********************************************************************************
        //'*: Métodos Privados
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        private string mfnEliminarEspaciosS(string asCad)
        {
            if (asCad != "")
            {
                while (asCad.IndexOf("  ") > 0)
                {
                    asCad = asCad.Replace("  ", " ");
                }
                return asCad;
            }
            else
            {
                return CORVB.NULL_STRING;
            }
        }
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private void mprLogSeparador()
        {
            msTransLog = msTransLog + (new String('-', 80)) + "\r\n";
        }
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private void mprLog(string asAccion)
        {
            bool abUltMsg = true;
            msTransLog = msTransLog + asAccion + "\r\n";
            
            if (abUltMsg)
            {
                msUltMsg = asAccion;
            }
        }
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private bool mfnGuardarHistoricoB(int alID, ref typCuentaEstado rcesCuenta,
                                            string asCuenta, string asCuentahabiente,
                                            bool abCtaAsociada, bool abAddTab)
        {
            try 
	        {	        
                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : "") + "Grabando datos para el histórico.");
                if (abCtaAsociada)
                {
                    CORVAR.pszgblsql = "INSERT INTO MTCCNH01 (";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_id, ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnh_cuenta, ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnh_cuentahabiente, ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnh_ref_disp, ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnh_ref_canc, ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnh_canc_saldo";
                    
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ") VALUES (";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + alID + ", ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + asCuenta + "', ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + asCuentahabiente.Substring(0, 79) + "', ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ((msDispRef == "") ? "NULL" : "'" + msDispRef + "'") + ", ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ((msCancRef == "") ? "NULL" : "'" + msCancRef + "'") + ", ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ((rcesCuenta.SaldoB) ? "1" : "0");
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ")";
                }
                else
                {
                    CORVAR.pszgblsql = "UPDATE " + MS_TABLA_M111 + " ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "SET cnc_ref_disp=" + ((msDispRef == "") ? "NULL" : "'" + msDispRef + "'") + 
                                ", ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_ref_canc=" + ((msCancRef == "") ? "NULL" : "'" + msCancRef + "'") + ", ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_canc_saldo=" + ((rcesCuenta.SaldoB) ? "1" : "0") + " ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE " + "cnc_id=" + alID;
                }

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                
                if (CORPROC2.Modifica_Registro() != 0)
                {
                    return true;;
                }
                else
                {
                    mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + "No fue posible guardar los datos del historico.");
                    mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + "Dé aviso a su administrador de sistemas.");
                    return false;;
                }
                CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
	        }
	        catch (Exception)
	        {
                mprErrLog("mfnGuardarHistoricoB()");
                return false;;
	        }
        }
        //'*: Fin: mfnGuardarHistoricoB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private bool mfnParsearResultadoB(enmTransaccionTipos aeTransaccion,ref typCuentaEstado rcesCuenta)
        {
            int i;
            string psRes;
            int piPosIni; int piPosFin;
            string psAux;
            bool pbSaldoEnContra; bool pbSobregiro;
            bool pbRevisarPadre;

            try 
	        {	        
                mprLog("Verificando datos de respuesta.");
                    
                switch (aeTransaccion)
                {
                    case enmTransaccionTipos.TTP_304_C_SALDO:
                    case enmTransaccionTipos.TTP_304_S_SALDO:
                        psRes = mfnEliminarEspaciosS(mscnSisCentrales.RespuestaS);
                        piPosIni = psRes.IndexOf("REFERENCIA#",1);
                        if (piPosIni == -1) 
                        {
                            piPosIni = psRes.IndexOf("REFERENCIA #",1);
                        }
                        if (piPosIni == -1)
                        {
                            mprLog("Ocurrió un error al intentar obtener los datos de respuesta.");
                            return false;
                        }
                        piPosIni = psRes.IndexOf("#",piPosIni);
                        piPosFin = psRes.IndexOf("\r\n",piPosIni + 1);
                        msCancRef = (Strings.Mid(psRes, (piPosIni + 1), (piPosFin - piPosIni - 1))).Trim();
                        return true;
                    case enmTransaccionTipos.TTP_316:
                        psRes = mfnEliminarEspaciosS(mscnSisCentrales.RespuestaS);
                        piPosIni = psRes.IndexOf("REFERENCIA#",1);
                        if (piPosIni == -1)
                        {
                            piPosIni = psRes.IndexOf("REFERENCIA #",1);
                        }                   
                        if (piPosIni == -1)
                        {
                            mprLog("Ocurrió un error al intentar obtener los datos de respuesta.");
                            return false;
                        }
                        piPosIni = psRes.IndexOf("#",piPosIni);
                        piPosFin = psRes.IndexOf("\r\n",piPosIni + 1);
                        msDispRef = (Strings.Mid(psRes, (piPosIni + 1), (piPosFin - piPosIni - 1))).Trim();
                        return true;
                    case enmTransaccionTipos.TTP_377:
                        psRes = mfnEliminarEspaciosS(mscnSisCentrales.GetMsgerror(ref tempRefParam));
                        //'*: Información de sobregiro
                        pbSobregiro = true;;
                        piPosIni = psRes.IndexOf("SOBREGIRO:",1);
                        if (piPosIni == -1)
                        {
                            piPosIni = psRes.IndexOf("SOBREGIRO :",1);
                        }
                        if (piPosIni == -1)
                        {
                            piPosIni = psRes.IndexOf("SOBREGIRO",1);
                        }                   
                        if (piPosIni == -1)
                        {
                            pbSobregiro = false;;
                            rcesCuenta.SobregiroF = 0;
                        }
                        else
                        {
                            piPosIni = psRes.IndexOf("G6",piPosIni); //'Strings.Chr(CORVB.KEY_ESCAPE), vbTextCompare)
                            piPosFin = psRes.IndexOf(Strings.Chr(CORVB.KEY_ESCAPE),piPosIni + 1);
                            double dbNumericTemp;
                            if (Double.TryParse((Strings.Mid(psRes, (piPosIni + 2), (piPosFin - piPosIni - 2))).Trim(), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                            {
                                rcesCuenta.SobregiroF = double.Parse((Strings.Mid(psRes, (piPosIni + 2), (piPosFin - piPosIni - 2))).Trim());
                            }
                            else
                            {
                                rcesCuenta.SobregiroF = 0;
                                mprLog("La cuenta padre se encuentra sobregirada.");
                            }
                        }
                        
                        //'*: Información de saldo
                        pbSaldoEnContra = true;;
                        piPosIni = psRes.IndexOf("SALDO DEUDOR:",1);
                        if (piPosIni == -1)
                        {
                            piPosIni = psRes.IndexOf("SALDO DEUDOR :",1);
                        }                    
                        if (piPosIni == -1)
                        {
                            piPosIni = psRes.IndexOf("SALDO A FAVOR:",1);
                            pbSaldoEnContra = false;;
                            
                            if (piPosIni == -1)
                            {
                                piPosIni = psRes.IndexOf("SALDO A FAVOR :",1);
                            }
                        }
                        if (piPosIni == -1)
                        {
                            mprLog("Ocurrió un error al intentar obtener los datos de respuesta.");
                            return false;
                        }
                        piPosIni = psRes.IndexOf(Strings.Chr(CORVB.KEY_ESCAPE),piPosIni);
                        piPosFin = psRes.IndexOf(Strings.Chr(CORVB.KEY_ESCAPE),piPosIni + 1);
                        rcesCuenta.DisponibleF = double.Parse((Strings.Mid(psRes, (piPosIni + 3), (piPosFin - piPosIni - 2))).Trim());
                        //'*: Información de diponible
                        piPosIni = psRes.IndexOf("LIM:",1);
                        if (piPosIni == -1)
                        {
                            piPosIni = psRes.IndexOf("LIM :",1);
                        }
                        if (piPosIni == -1)
                        {
                            mprLog("Ocurrió un error al intentar obtener los datos de respuesta.");
                            return false;
                        }
                        piPosIni = psRes.IndexOf(Strings.Chr(CORVB.KEY_ESCAPE),piPosIni);
                        piPosFin = psRes.IndexOf("\r\n",piPosIni + 1);
                        rcesCuenta.SaldoF = double.Parse((Strings.Mid(psRes, (piPosIni + 3), (piPosFin - piPosIni - 2))).Trim());
                        //'*: Información de situación de cuenta
                        piPosIni = psRes.IndexOf("BASICA:",1);
                        if (piPosIni == -1)
                        {
                            piPosIni = psRes.IndexOf("BASICA :",1);
                        }
                        if (piPosIni == -1)
                        {
                            mprLog("Ocurrió un error al intentar obtener los datos de respuesta.");
                            return false;
                        }
                        piPosIni = piPosIni + 7; //'InStr(piPosIni, psRes, Strings.Chr(CORVB.KEY_ESCAPE), vbTextCompare)
                        piPosFin = psRes.IndexOf("\r\n",piPosIni);
                        string svar1 = Strings.Mid(psRes, piPosIni, (piPosFin - piPosIni));
                        rcesCuenta.DescripcionS = (svar1.Replace(":", CORVB.NULL_STRING)).Trim();
                        for (i = 0; i < mxcesCuentaEstados.Length; i++)
                        {
                            if (mxcesCuentaEstados[i].DescripcionS == rcesCuenta.DescripcionS)
                            {
                                if (!pbSobregiro)
                                {
                                    rcesCuenta.CancelableB = mxcesCuentaEstados[i].CancelableB;
                                }
                                else
                                {
                                   rcesCuenta.CancelableB = false;
                                }
                                rcesCuenta.CanceladaB = mxcesCuentaEstados[i].CanceladaB;
                                rcesCuenta.EstadoS = mxcesCuentaEstados[i].EstadoS;
                                rcesCuenta.SaldoB = mxcesCuentaEstados[i].SaldoB;
                                rcesCuenta.SobregiroB = pbSobregiro;
                                rcesCuenta.StatusTranE = enmCancelacionStatus.CST_PENDIENTE;
                                rcesCuenta.TipoE = (enmCancelacionTipos)aeTransaccion;
                                return true;
                            }
                            else
                            {
                                rcesCuenta.CancelableB = false;;
                                rcesCuenta.CanceladaB = false;;
                                rcesCuenta.EstadoS = "X";
                                rcesCuenta.SobregiroB = false;;
                                rcesCuenta.StatusTranE = enmCancelacionStatus.CST_PENDIENTE;
                                rcesCuenta.TipoE = (enmCancelacionTipos)aeTransaccion;
                            }
                        }
                        
                        if (rcesCuenta.EstadoS == "X")
                        {
                            rcesCuenta.DescripcionS = "OTRO";
                            return true;;
                        }
                        return false;
                }
                return false;
	        }
	        catch (Exception)
	        {
                mprErrLog("mfnParsearResultadoB()");
                //'Resume 0
                return false;;
       		
	        }
        }
        //'*: Fin: mfnParsearResultadoB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Llena el objeto de acceso a sistemas centrales con la información necesaria
        //'*: para efectuar una transacción.
        //'*:
        //'*: NOTA:   Para poder utilizar este procedimiento, debe establecer los atributos miBanco, miDigVerif, msEjeMasc,
        //'*:         mlEjeNum, miEjeTam, msEmpMasc, mlEmpNum, miEmpTam, miPrefijo y miRollOver de antemano, ya sea directamente,
        //'*:         a través de sus equivalentes públicos (BancoI, DigVerifI, EjeMascS, EjeNumL, EjeTamI, EmpMascS, EmpNumI,
        //'*:         EmpTamI, PrefijoI, RollOverI) o mediante las propiedades CuentaS, EjeMascS/EjeTamI y EmpMascS/EmpNumI
        //'*:         prefiriendo las ultimas dos formas, ya que estas, conservan la consistencia de valores para los pares de
        //'*:         datos msEjeMasc/miEjeTam y msEmpMasc/miEmpTam.
        //'*:
        //'*: Parámetros:
        //'*:         eTransaccion:   Enumeración que contiene las transacciones que se pueden utilizar dentro de la clase.
        //'*:
        //'*: Ejemplo:
        //'*:         Si se desea cancelar una cuenta con saldo, debe llamar al método mprParametros antes de enviar el diálogo a
        //'*:         los sistemas centrales de la siguiente forma:
        //'*:
        //'*:             this.mprParametros TTS_304
        //'*:
        //'*:         para consultar un saldo:
        //'*:
        //'*:             this.mprParametros TTS_377
        //'*:         ó
        //'*:             this.mprParametros TTS_303
        //'*:
        //'*:         Para otras transacciónes disponibles vea la definición de enmTransaccionTipos.
        private void mprParametros(string asCuenta, enmTransaccionTipos aeTransaccion)
        {
            try 
	        {	        
                mscnSisCentrales.StrNoCuenta = asCuenta;

                switch (aeTransaccion)
                {
                case enmTransaccionTipos.TTP_304_C_SALDO:
                    mscnSisCentrales.StrIdTransaccion = "304";
                    mscnSisCentrales.StrParametrosAdicionales = "E";
                    break;
                case enmTransaccionTipos.TTP_304_S_SALDO:
                    mscnSisCentrales.StrIdTransaccion = "304";
                    mscnSisCentrales.StrParametrosAdicionales = "C";
                    break;
                case enmTransaccionTipos.TTP_316:
                    mscnSisCentrales.StrIdTransaccion = "316";
                    mscnSisCentrales.StrParametrosAdicionales = MS_DISPONIBLE_MIN;
                    break;
                case enmTransaccionTipos.TTP_377:
                    mscnSisCentrales.StrIdTransaccion = "377";
                    mscnSisCentrales.StrParametrosAdicionales = CORVB.NULL_STRING;
                    break;
                }
	        }
	        catch (System.Exception)
	        {
                mprErrLog("mprParametros()");
	        }
        }
        //'*: Fin: mfnParametros()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Cancela una cuenta hija.
        //'*:
        //'*: NOTA:   Para poder utilizar este procedimiento, debe establecer los atributos miBanco, miDigVerif, msEjeMasc,
        //'*:         mlEjeNum, miEjeTam, msEmpMasc, mlEmpNum, miEmpTam, miPrefijo y miRollOver de antemano, ya sea directamente,
        //'*:         a través de sus equivalentes públicos (BancoI, DigVerifI, EjeMascS, EjeNumL, EjeTamI, EmpMascS, EmpNumI,
        //'*:         EmpTamI, PrefijoI, RollOverI) o mediante las propiedades CuentaS, EjeMascS/EjeTamI y EmpMascS/EmpNumI
        //'*:         prefiriendo las ultimas dos formas, ya que estas, conservan la consistencia de valores para los pares de
        //'*:         datos msEjeMasc/miEjeTam y msEmpMasc/miEmpTam.
        //'*:
        //'*: Ejemplo:
        //'*:         if Not clsCancelaciones.fnCancelarCtaHijaMakerB() Then
        //'*:             Msgbox "Se produjo un error al enviar la solicitud de cancelación de cuenta"
        //'*:         }
        private bool mfnMkrInsSolicitudB(string asMakerNomina, string asMakerNombre, enmCancelacionTipos aeTipo)
        {
            int lId = 0;

            try 
	        {	        
                mprLog("Insertando solicitud para baja de cuenta " + this.CuentaS + ".");
                CORVAR.pszgblsql = "SELECT MAX(cnc_id) + 1 FROM MTCCNC01";

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                       lId = (int)(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 1), -1));
                    }
                }
                else
                {
                    mprErrLog("mfnMkrInsSolicitudB()");
                    mprLog("No fue posible insertar la solicitud de cancelación.");
                    mprLog("No es posible obtener el consecutivo del identificador de cancelación.");
                    return false;
                }
                
                CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                
                CORVAR.pszgblsql = "INSERT INTO " + MS_TABLA_M111 + " (";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_id, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_prefijo, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_eje_tam, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_emp_tam, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_cuenta, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_maker_usr, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_maker_nom, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_maker_fecha, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_checker_usr, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_checker_nom, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_checker_fecha, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_cuentahabiente, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_num_ctas_hijas, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_tipo, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_status";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ") VALUES (";
                CORVAR.pszgblsql = CORVAR.pszgblsql + lId + ", ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + miPrefijo + ", ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + miBanco + ", ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + miEjeTam + ", ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + miEmpTam + ", ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + this.CuentaS + "', ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + asMakerNomina + "', ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + asMakerNombre.Substring(0, MI_NOMBRE_TAM - 1) + "', ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "getdate(), ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "NULL, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + msCuentahabiente.Substring(0, 79) + "', ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + mlNumCtasHijas + ", ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(aeTipo) + ", ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + Conversion.Str(enmCancelacionStatus.CST_SIN_REVISAR);
                CORVAR.pszgblsql = CORVAR.pszgblsql + ")";

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                
                if (CORPROC2.Modifica_Registro() != 0)
                {
                    mprLog("Transaccion aplicada, pendiente de autorización.");
                    return true;
                }
                else
                {
                    mprLog("No fue posible crear la solicitud de baja de la cuenta.");
                    return false;
                }
                
                CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
	        }
	        catch (Exception)
	        {
                 mprErrLog("mfnMkrInsSolicitudB()");
                 return false;
	        }
        }
        //'*: Fin: mfnMkrInsSolicitudB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private void mprErrLog(string asMetodo)
        {
            mprLog("Se produjo un error al ejecutar el procedimiento." + "\r\n" + "Número: " + Information.Err().Number + "\r\n" + 
                    "Descripción: " + Information.Err().Description + "\r\n" + "Origen: clsCancelaciones::" + asMetodo);
        }
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private bool mfnExisteCtaEnCancelacionesB()
        {

            try 
	        {	        
                mprLog("Verificando cuenta en cancelaciones.");
                
                CORVAR.pszgblsql = "SELECT cnc_id ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM " + MS_TABLA_M111 + " ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE cnc_cuenta='" + this.CuentaS + "' AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_status IN(" + Conversion.Str(enmCancelacionStatus.CST_SIN_REVISAR) + ", " + Conversion.Str(enmCancelacionStatus.CST_PENDIENTE) + ")";

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    mprLog("No fue posible ejecutar la operacion.");
                    mprLog("La cuenta ya se encuentra pendiente de autorización para ser cancelada.");
                    mprLog("Termine el proceso antes de ejecutar la cancelación.");
                    return true;
                }
                else
                {
                    return false;
                }
                
                CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        		
	        }
	        catch (Exception)
	        {
                mprLog("No fue posible ejecutar la operacion.");
                mprErrLog("mfnExisteCtaEnCancelacionesB()");
                return true;
	        }
        }
        //'*: Fin: mfnExisteCtaEnCancelacionesB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private bool mfnExisteCtaEnReenviosB(bool abCuentaPadre)
        {
            try 
	        {	        
                mprLog("Verificando registro en reenvíos y altas masivas.");
                
                CORVAR.pszgblsql = "SELECT eje_num ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCIND02 ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE eje_prefijo=" + miPrefijo + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco=" + miBanco + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num=" + mlEmpNum;
                
                if (!abCuentaPadre)
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND eje_num=" + mlEjeNum;
                }

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    mprLog("No fue posible ejecutar la operacion.");
                    
                    if (abCuentaPadre)
                    {
                        mprLog("Existen cuentas hijas pendientes de alta.");
                    }
                    else
                    {
                        mprLog("La cuenta se encuentra pendiente de alta.");
                    }
                    
                    mprLog("Termine el proceso antes de ejecutar la cancelación.");
                    return true;
                }
                
                CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                CORVAR.pszgblsql = "SELECT eje_num ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCMSV02 ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE eje_prefijo=" + miPrefijo + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_banco=" + miBanco + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num=" + mlEmpNum;
                
                if (!abCuentaPadre)
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND eje_num=" + mlEjeNum;
                }

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    mprLog("No fue posible ejecutar la operacion.");
                    
                    if (abCuentaPadre)
                    {
                        mprLog("Existen cuentas hijas pendientes de alta.");
                    }
                    else
                    {
                        mprLog("La cuenta se encuentra pendiente de alta.");
                    }                
                    mprLog("Termine el proceso antes de ejecutar la cancelación.");
                    return true;
                }
                else
                {
                    return false;
                }
                
                CORVAR.igblRetorna = CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        		
	        }
	        catch (Exception)
	        {
                mprLog("No fue posible ejecutar la operacion.");
                mprErrLog("mfnExisteCtaEnReenviosB()");
                return true;
	        }
        }
        //'*: Fin: mfnExisteCtaEnReenviosB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private bool mfnActualizarLimDispCtaHijaB(string asCuenta, ref typCuentaEstado rcesCuenta, bool abAddTab)
        {
            bool pbReintentar = false;

            try 
	        {	        
                if (rcesCuenta.SaldoF > 100)
                {
                    do
                    {
                        mprParametros(asCuenta, enmTransaccionTipos.TTP_316);
                        sTrans = mscnSisCentrales.StrIdTransaccion;
                        sParamAdi = mscnSisCentrales.StrParametrosAdicionales;
                        switch ((TransS111.EnumRespTransaccion) mscnSisCentrales.FnEnviarTransaccion( sTrans,
                                                                      asCuenta,
                                                                      sParamAdi))
                        {
                            case TransS111.EnumRespTransaccion.EnRespConfirmar:
                                pbReintentar = true;
                                break;
                            case TransS111.EnumRespTransaccion.EnRespError:
                                pbReintentar = false;
                                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) +
                                        "Ocurrió un error al ejecutar la consulta a los sistemas centrales.");
                                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) +
                                        "Dé aviso del problema a su administrador de redes.");
                                tempRefParam = false;
                                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + mscnSisCentrales.GetMsgerror(ref tempRefParam));
                                return false;
                                break;
                            case TransS111.EnumRespTransaccion.EnRespOperacionNegada:
                                pbReintentar = false;
                                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) +
                                        "La operaciódn fue rechazada por los sistemas centrales.");
                                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + mscnSisCentrales.GetMsgerror(ref tempRefParam));
                                return false;
                                break;
                            case TransS111.EnumRespTransaccion.EnRespSinRespuesta:
                            case TransS111.EnumRespTransaccion.EnRespIniciado:
                                pbReintentar = false;
                                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) +
                                        "No hay respuesta de los sistemas centrales, reintente de nuevo más tarde.");
                                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) +
                                        "Si el problema persiste dé aviso a su administrador de redes.");
                                return false;
                                break;
                            case TransS111.EnumRespTransaccion.EnRespTerminalSinFirmar:
                            case TransS111.EnumRespTransaccion.EnRespDarseAlta:
                                if (!fnConectarB())
                                {
                                    return false;
                                }
                                pbReintentar = true;
                                break;
                            case TransS111.EnumRespTransaccion.EnRespDesconocida:
                            case TransS111.EnumRespTransaccion.EnRespTransaccionAceptada:
                                rcesCuenta.SaldoF = double.Parse(MS_DISPONIBLE_MIN);
                                mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) +
                                        "Se cambió el límite de disposiciones de la cuenta " + asCuenta + " exitosamente.");
                                mprLog(mscnSisCentrales.RespuestaS);
                                mfnParsearResultadoB(enmTransaccionTipos.TTP_316, ref rcesCuenta);
                                pbReintentar = false;
                                return true;
                                break;
                        }
                    } while (pbReintentar);
                    return false;
                }
                else
                {
                    mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + "El límite de disposiciones de la cuenta " + asCuenta + 
                            " es el mínimo, no necesita actualizarse.");
                    return true;
                }

	        }
	        catch (Exception)
	        {
                mprErrLog("mfnActualizarLimDispCtaHijaB()");
                return false;
	        }
        }
        //'*: Fin: mfnActualizarLimDispCtaHijaB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        private bool mfnCancelarCuentaB(string asCuenta, ref typCuentaEstado rcesCuenta,
                                        bool abCuentaHija,bool abAddTab, ref string rsRespuesta)
        {
            bool pbReintentar = false;

            try 
	        {	        
                do
                {
                    if (abCuentaHija)
                    {
                        if (rcesCuenta.SaldoF == 0)
                        {
                            mprParametros(asCuenta, enmTransaccionTipos.TTP_304_S_SALDO);
                            rcesCuenta.SaldoB = false;
                        }
                        else
                        {
                            mprParametros(asCuenta, enmTransaccionTipos.TTP_304_C_SALDO);
                            rcesCuenta.SaldoB = true;
                        }
                    }
                    else
                    {
                        if (rcesCuenta.DisponibleF == 0)
                        {
                            mprParametros(asCuenta,enmTransaccionTipos.TTP_304_S_SALDO);
                            rcesCuenta.SaldoB = false;
                        }
                        else
                        {
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + "No fue posible cancelar la cuenta debido a " + 
                                    "que el saldo no es cero.");
                            rcesCuenta.SaldoB = true;
                            return false;
                        }
                    }

                    sTrans = mscnSisCentrales.StrIdTransaccion;
                    sParamAdi = mscnSisCentrales.StrParametrosAdicionales;
                    switch ((TransS111.EnumRespTransaccion) mscnSisCentrales.FnEnviarTransaccion( sTrans,
                                                                  asCuenta,
                                                                  sParamAdi))
                    
                    {
                        case TransS111.EnumRespTransaccion.EnRespConfirmar:
                            pbReintentar = true;
                            break;
                        case TransS111.EnumRespTransaccion.EnRespError:
                            pbReintentar = false;
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + 
                                    "Ocurrió un error al ejecutar la consulta a los sistemas centrales.");
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + 
                                    "Dé aviso del problema a su administrador de redes.");
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + mscnSisCentrales.GetMsgerror(ref tempRefParam));
                            return false;
                            break;
                        case TransS111.EnumRespTransaccion.EnRespOperacionNegada:
                            pbReintentar = false;
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + 
                                    "La operación fue rechazada por los sistemas centrales.");
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + mscnSisCentrales.GetMsgerror(ref tempRefParam));
                            return false;
                            break;
                        case TransS111.EnumRespTransaccion.EnRespSinRespuesta:
                        case TransS111.EnumRespTransaccion.EnRespIniciado:
                            pbReintentar = false;
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + 
                                    "No hay respuesta de los sistemas centrales, reintente de nuevo más tarde.");
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + 
                                    "Si el problema persiste dé aviso a su administrador de redes.");
                            return false;
                            break;
                        case TransS111.EnumRespTransaccion.EnRespTerminalSinFirmar:
                        case TransS111.EnumRespTransaccion.EnRespDarseAlta:
                            if (! fnConectarB())
                            {
                                return false;
                            }
                            
                            pbReintentar = true;
                            break;
                        case TransS111.EnumRespTransaccion.EnRespDesconocida:
                        case TransS111.EnumRespTransaccion.EnRespTransaccionAceptada:
                            mprLog(((abAddTab) ? Conversion.Str(CORVB.KEY_TAB) : CORVB.NULL_STRING) + "La cuenta " + asCuenta + " se canceló existosamente.");
                            rsRespuesta = mscnSisCentrales.RespuestaS;
                            mfnParsearResultadoB(enmTransaccionTipos.TTP_304_C_SALDO, ref rcesCuenta);
                            mprLog(rsRespuesta);
                            pbReintentar = false;
                            return true;
                            break;
                    }
                } while (pbReintentar);
                return false;
	        }
	        catch (Exception)
	        {
                mprErrLog("mfnCancelarCuentaB()");
                return false;
	        }
        }
        //'*: Fin: mfnCancelarCuentaB()
        //'*:--------------------------------------------------------------------------------
        //'*:********************************************************************************
        //'*: Fin: Métodos Privados
        //'*:********************************************************************************



        //'*:********************************************************************************
        //'*: Métodos Públicos
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        public bool fnCambiarStatusB(int alID, enmCancelacionStatus aeStatus)
        {

            try 
	        {	        
                CORVAR.pszgblsql = "UPDATE " + MS_TABLA_M111 + " ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "SET cnc_status=" + aeStatus + ", ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_checker_usr='" + this.CheckerNominaS + "', ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_checker_nom='" + this.CheckerNombreS + "', ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "cnc_checker_fecha=getdate()" + " ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE " + "cnc_id=" + alID;

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);

                if (CORPROC2.Modifica_Registro() == 0)
                {
                    mprLog("No fue posible cambiar el status de la cuenta " + this.CuentaS + ".");
                    mprLog("Si el probleme persiste dé aviso a sus administrador de redes.");
                    return false;
                }
                return true;
	        }
	        catch (Exception)
	        {
                mprLog("No fue posible cambiar el status de la cuenta " + this.CuentaS + " debido a un error.");
                mprLog("Si el probleme persiste dé aviso a sus administrador de redes.");
                mprErrLog("fnCambiarStatusB()");
                mprLogSeparador();
                return false;
	        }
        }
        //'*: Fin: fnCambiarStatusB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        public bool fnCkrCancelarSolicitudB(int alID)
        {
            try 
	        {	        
                this.CheckerNombreS = mscnSisCentrales.NombreS;
                this.CheckerNominaS = mscnSisCentrales.NominaS;
                
                msTransLog = CORVB.NULL_STRING;;
                
                if (this.CheckerNominaS.Trim() == this.MakerNominaS.Trim())
                {
                    mprLog("El maker debe ser diferente del cheker.");
                    mprLogSeparador();
                    return false;
                }
                
                if (fnCambiarStatusB(alID, enmCancelacionStatus.CST_CANCELADO))
                {
                    mprLog("La operación sobre la cuenta " + this.CuentaS + " fue declinada exitosamente.");
                    return true;
                }
                else
                {
                    mprLog("No fue posible declinar la operación sobre la cuenta " + this.CuentaS + ".");
                    mprLog("Si el probleme persiste dé aviso a sus administrador de redes.");
                    return false;
                }
                
                mprLogSeparador();
	        }
	        catch (Exception)
	        {
                mprLog("No fue posible declinar la operación sobre la cuenta " + this.CuentaS + " debido a un error.");
                mprLog("Si el probleme persiste dé aviso a sus administrador de redes.");
                mprErrLog("fnCkrCancelarSolicitudB()");
                mprLogSeparador();
                return false;
	        }
        }
        //'*: Fin: fnCkrCancelarSolicitudB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Cancela una cuenta (proceso Cheker).
        //'*:
        //'*: NOTA:   Para poder utilizar este procedimiento, debe establecer los atributos miBanco, miDigVerif, msEjeMasc,
        //'*:         mlEjeNum, miEjeTam, msEmpMasc, mlEmpNum, miEmpTam, miPrefijo y miRollOver de antemano, ya sea directamente,
        //'*:         a través de sus equivalentes públicos (BancoI, DigVerifI, EjeMascS, EjeNumL, EjeTamI, EmpMascS, EmpNumI,
        //'*:         EmpTamI, PrefijoI, RollOverI) o mediante las propiedades CuentaS, EjeMascS/EjeTamI y EmpMascS/EmpNumI
        //'*:         prefiriendo las ultimas dos formas, ya que estas, conservan la consistencia de valores para los pares de
        //'*:         datos msEjeMasc/miEjeTam y msEmpMasc/miEmpTam.
        //'*:
        //'*: Ejemplo:
        //'*:         if Not clsCancelaciones.fnCkrCancelarCuentaB() Then
        //'*:             Msgbox "Se produjo un error al cancelar la cuenta"
        //'*:         }
        public bool fnCkrCancelarCuentaB(int alID,enmCancelacionTipos aeTipo)
        {
            bool pbReintentar;
            typCuentaEstado pcesAux = new typCuentaEstado();
            bool pbCtaCancelable = false;
            string psCuenta; string psCuentahabiente; string psRespuesta = null;
            typCuentaAsociada[] pcasCuentasHijas = ArraysHelper.InitializeArray<typCuentaAsociada[]>(new int[] {}); 
            int i;

            try 
	        {	        
                msTransLog = CORVB.NULL_STRING;
                
                if (mfnExisteCtaEnReenviosB(((aeTipo == enmCancelacionTipos.CTP_CUENTA_PADRE) ? true : false)))
                {
                    mprLogSeparador();
                    return false;
                }
                
                this.CheckerNombreS = mscnSisCentrales.NombreS;
                this.CheckerNominaS = mscnSisCentrales.NominaS;
                
                msTransLog = CORVB.NULL_STRING;
                
                if (this.CheckerNominaS.Trim() == this.MakerNominaS.Trim())
                {
                    mprLog("El maker debe ser diferente del cheker.");
                    mprLogSeparador();
                    return false;
                }
                pbReintentar = false;
                mprLog("Consultando datos de la cuenta " + this.CuentaS + " a los sistemas centrales.");
                
                do
                {
                    mprParametros(this.CuentaS, enmTransaccionTipos.TTP_377);

                    sTrans = mscnSisCentrales.StrIdTransaccion;
                    asCuenta1 = mscnSisCentrales.StrNoCuenta;
                    sParamAdi = mscnSisCentrales.StrParametrosAdicionales;
                    switch ((TransS111.EnumRespTransaccion) mscnSisCentrales.FnEnviarTransaccion( sTrans,
                                                                  asCuenta1,
                                                                  sParamAdi))
                    {
                        case TransS111.EnumRespTransaccion.EnRespConfirmar:
                        return true;
                        break;
                    case TransS111.EnumRespTransaccion.EnRespError:
                        pbReintentar = false;
                        mprLog("Ocurrió un error al ejecutar la consulta a los sistemas centrales.");
                        mprLog("Dé aviso del problema a su administrador de redes.");
                        mprLog(mscnSisCentrales.GetMsgerror(ref tempRefParam));
                        return false;
                        break;
                    case TransS111.EnumRespTransaccion.EnRespOperacionNegada:
                        pbReintentar = false;
                        mprLog("La operación fue rechazada por los sistemas centrales.");
                        mprLog(mscnSisCentrales.GetMsgerror(ref tempRefParam));
                        return false;
                        break;
                    case TransS111.EnumRespTransaccion.EnRespSinRespuesta:
                    case TransS111.EnumRespTransaccion.EnRespIniciado:
                        pbReintentar = false;
                        mprLog("No hay respuesta de los sistemas centrales, reintente de nuevo más tarde.");
                        mprLog("Si el problema persiste dé aviso a su administrador de redes.");
                        return false;
                        break;
                    case TransS111.EnumRespTransaccion.EnRespTerminalSinFirmar:
                    case TransS111.EnumRespTransaccion.EnRespDarseAlta:
                        if (!fnConectarB())
                        {
                            mprLogSeparador();
                            return false;
                        }
                        pbReintentar = true;
                        break;
                    case TransS111.EnumRespTransaccion.EnRespDesconocida:
                    case TransS111.EnumRespTransaccion.EnRespTransaccionAceptada:
                        mfnParsearResultadoB(enmTransaccionTipos.TTP_377, ref mcesCuentaDatos);
                        if (mcesCuentaDatos.CancelableB)
                        {
                            switch (aeTipo)
                            {
                            case enmCancelacionTipos.CTP_CUENTA_PADRE:
                                if (mcesCuentaDatos.DisponibleF != 0)
                                {
                                    mprLog("La cuenta " + this.CuentaS + " no se pudo cancelar debido a que el saldo es " +
                                            "diferente de cero.");
                                    mprLogSeparador();
                                    return false;
                                }
                                CORVAR.pszgblsql = "SELECT (convert(char(4), isnull(TH.eje_prefijo, EJ.eje_prefijo)) + ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(char(2), isnull(TH.gpo_banco, EJ.gpo_banco)) + ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', " + this.EmpTamI +
                                            " - char_length(ltrim(rtrim(str(isnull(TH.emp_num, EJ.emp_num)))))) + " +
                                            "ltrim(rtrim(str(isnull(TH.emp_num, EJ.emp_num)))) + ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', " + this.EjeTamI +
                                            " - char_length(ltrim(rtrim(str(isnull(TH.eje_num, EJ.eje_num)))))) + " +
                                            "ltrim(rtrim(str(isnull(TH.eje_num, EJ.eje_num)))) + ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(str(isnull(TH.eje_roll_over, EJ.eje_roll_over))) + ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(str(isnull(TH.eje_digit, EJ.eje_digit)))) tmp_cuenta, EJ.eje_nombre ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCEJE01 EJ, MTCTHS01 TH ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE TH.eje_prefijo=*EJ.eje_prefijo AND ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.gpo_banco=*EJ.gpo_banco AND ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.emp_num=*EJ.emp_num AND ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.eje_num=*EJ.eje_num AND ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.eje_prefijo=" + this.PrefijoI + " AND ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.gpo_banco=" + this.BancoI + " AND ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.emp_num=" + this.EmpNumL + " AND ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.eje_num<>0";

                                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                                pbCtaCancelable = true;;
                                mprLog(Conversion.Str(CORVB.KEY_TAB) + "Preparando para cancelar cuentas asociadas a la cuenta " + this.CuentaS + "...");
                                mprLogSeparador();

                                if (CORPROC2.Obtiene_Registros() != 0)
                                {
                                    //ReDim pcasCuentasHijas(0);
                                    pcasCuentasHijas = ArraysHelper.RedimPreserve<typCuentaAsociada[]>(pcasCuentasHijas, new int[] {0});
                                    
                                    
                                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                                    {
                                        //ReDim Preserve pcasCuentasHijas((UBound(pcasCuentasHijas) + 1));
                                        pcasCuentasHijas = ArraysHelper.RedimPreserve<typCuentaAsociada[]>(pcasCuentasHijas, new int[] {pcasCuentasHijas.GetUpperBound(0) + 1});

                                        pcasCuentasHijas[pcasCuentasHijas.GetUpperBound(0)].CuentaS = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                                        pcasCuentasHijas[pcasCuentasHijas.GetUpperBound(0)].CuentahabienteS = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                                    }
                                    
                                    for (i = 1; i == pcasCuentasHijas.GetUpperBound(0);i++)
                                    {
                                        psCuenta = pcasCuentasHijas[i].CuentaS;
                                        psCuentahabiente = pcasCuentasHijas[i].CuentahabienteS;
                                    
                                        mprLog(Conversion.Str(CORVB.KEY_TAB) + "Consultando datos de la cuenta " + psCuenta + 
                                                " a los sistemas centrales.");
                                    
                                        do
                                        {
                                            mprParametros(psCuenta, enmTransaccionTipos.TTP_377);
                                            sTrans = mscnSisCentrales.StrIdTransaccion;
                                            sParamAdi = mscnSisCentrales.StrParametrosAdicionales;
                                            switch ((TransS111.EnumRespTransaccion) mscnSisCentrales.FnEnviarTransaccion(sTrans,
                                                                                         psCuenta,
                                                                                         sParamAdi))
                                            {
                                            case TransS111.EnumRespTransaccion.EnRespConfirmar:
                                                pbReintentar = true;
                                                break;
                                            case TransS111.EnumRespTransaccion.EnRespError:
                                                pbReintentar = false;
                                                pbCtaCancelable = false;
                                                mprLog(Conversion.Str(CORVB.KEY_TAB) + "Ocurrió un error al ejecutar la consulta a los sistemas" + 
                                                        " centrales.");
                                                mprLog(Conversion.Str(CORVB.KEY_TAB) + "Dé aviso del problema a su administrador de redes.");
                                                mprLog(Conversion.Str(CORVB.KEY_TAB) + mscnSisCentrales.GetMsgerror(ref tempRefParam));
                                                break;
                                            case TransS111.EnumRespTransaccion.EnRespOperacionNegada:
                                                pbReintentar = false;
                                                pbCtaCancelable = false;
                                                mprLog(Conversion.Str(CORVB.KEY_TAB) + "La operación fue rechazada por los sistemas centrales.");
                                                mprLog(Conversion.Str(CORVB.KEY_TAB) + mscnSisCentrales.GetMsgerror(ref tempRefParam));
                                                break;
                                            case TransS111.EnumRespTransaccion.EnRespSinRespuesta:
                                            case TransS111.EnumRespTransaccion.EnRespIniciado:
                                                pbReintentar = false;
                                                pbCtaCancelable = false;
                                                mprLog(Conversion.Str(CORVB.KEY_TAB) + "No hay respuesta de los sistemas centrales, reintente " + 
                                                        "de nuevo más tarde.");
                                                mprLog(Conversion.Str(CORVB.KEY_TAB) + "Si el problema persiste dé aviso a su administrador de redes.");
                                                break;
                                            case TransS111.EnumRespTransaccion.EnRespTerminalSinFirmar:
                                            case TransS111.EnumRespTransaccion.EnRespDarseAlta:
                                                if (!fnConectarB())
                                                {
                                                    mprLogSeparador();
                                                    return false;
                                                }
                                                pbReintentar = true;
                                                break;
                                            case TransS111.EnumRespTransaccion.EnRespDesconocida:
                                            case TransS111.EnumRespTransaccion.EnRespTransaccionAceptada:
                                                mfnParsearResultadoB(enmTransaccionTipos.TTP_377, ref pcesAux);
                                                if (pcesAux.CancelableB)
                                                {
                                                    msCancRef = CORVB.NULL_STRING;
                                                    msDispRef = CORVB.NULL_STRING;
                                                    mprLog(Conversion.Str(CORVB.KEY_TAB) + "Actualizando límite de disposiciones.");
                                                    
                                                    if (mfnActualizarLimDispCtaHijaB(psCuenta, ref pcesAux, true))
                                                    {
                                                        mprLog(Conversion.Str(CORVB.KEY_TAB) + "Cancelando cuenta.");
                                                    
                                                        if (!mfnCancelarCuentaB(psCuenta, ref pcesAux, true, false, ref psRespuesta))
                                                        {
                                                            mprLog(psRespuesta);
                                                            mprLogSeparador();
                                                            return false;
                                                        }
                                                        
                                                        if (!mfnGuardarHistoricoB(alID, ref pcesAux, psCuenta, psCuentahabiente, true, true))
                                                        {
                                                            MessageBox.Show("No fue posible guardar los datos de la cancelación en el " + 
                                                                    "histórico." + "\r\n" + "Dé aviso de esto a su " + 
                                                                    "administrador de sistemas.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        mprLogSeparador();
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    if (pcesAux.CanceladaB)
                                                    {
                                                        mprLog(Conversion.Str(CORVB.KEY_TAB) + "La cuenta " + psCuenta + " ya fue cancelada con " + 
                                                            "anterioridad.");
                                                    }
                                                    else
                                                    {
                                                        mprLog(Conversion.Str(CORVB.KEY_TAB) + "La cuenta " + psCuenta + " no puede ser cancelada " + 
                                                            "debido a " + "que su estado es " + pcesAux.DescripcionS);
                                                        pbCtaCancelable = false;
                                                    }
                                                }
                                                pbReintentar = false;
                                                break;
                                            }
                                        } while (pbReintentar);
                                        
                                        mprLogSeparador();
                                    }
                                    
                                    //ReDim pcasCuentasHijas(0);
                                    pcasCuentasHijas = ArraysHelper.RedimPreserve<typCuentaAsociada[]>(pcasCuentasHijas, new int[] {0});
                                }
                                else
                                {
                                    mprLog("No existen cuentas asociadas.");
                                }

                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                                mprLog("Cancelando cuenta.");
                                
                                if (pbCtaCancelable)
                                {
                                    if (mfnCancelarCuentaB(this.CuentaS, ref mcesCuentaDatos, false, false, ref psRespuesta))
                                    {
                                        MessageBox.Show("La cuenta " + this.CuentaS + " se canceló exitósamente." + "\r\n\r\n" + 
                                                psRespuesta, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        
                                        if (!mfnGuardarHistoricoB(alID, ref mcesCuentaDatos, this.CuentaS, CORVB.NULL_STRING, false, false))
                                        {
                                            MessageBox.Show("No fue posible guardar los datos de la cancelación en el histórico." + 
                                                    "\r\n" + "Dé aviso de esto a su administrador de sistemas.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        mprLogSeparador();
                                        return false;
                                    }
                                }
                                else
                                {   
                                    psRespuesta = "La cuenta " + this.CuentaS + " no pudo ser cancelada debido a que no fue " + 
                                                    "posible cancelar todas las cuentas asociadas.";
                                    mprLog(psRespuesta);
            //'                        MsgBox psRespuesta, vbExclamation, App.ProductName
                                }
                                break;
                            case enmCancelacionTipos.CTP_CUENTA_HIJA:
                                msCancRef = CORVB.NULL_STRING;
                                msDispRef = CORVB.NULL_STRING;
                                mprLog("Actualizando límite de disposiciones.");
                                
                                if (!mfnActualizarLimDispCtaHijaB(this.CuentaS, ref mcesCuentaDatos, false))
                                {
                                    mprLogSeparador();
                                    return false;
                                }
                                    
                                mprLog("Cancelando cuenta.");
                                
                                if (mfnCancelarCuentaB(this.CuentaS, ref mcesCuentaDatos, true, false, ref psRespuesta))
                                {
                                    MessageBox.Show("La cuenta " + this.CuentaS + " se canceló exitósamente." + "\r\n\r\n" + 
                                            psRespuesta, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    mprLogSeparador();
                                    return false;
                                }

                                if (!mfnGuardarHistoricoB(alID, ref mcesCuentaDatos, this.CuentaS, CORVB.NULL_STRING, false, false))
                                {
                                    MessageBox.Show("No fue posible guardar los datos de la cancelación en el histórico." + "\r\n" +
                                            "Dé aviso de esto a su administrador de sistemas.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                pbCtaCancelable = true;
                                break;
                            } // Switch
                    
                            if (pbCtaCancelable)
                            {
                                if (fnCambiarStatusB(alID, enmCancelacionStatus.CST_APLICADA))
                                {
                                    mprLog("La cuenta " + this.CuentaS + " fue cancelada exitosamente.");
                                    return true;
                                }
                                else
                                {
                                    mprLog("La cuenta " + this.CuentaS + " se canceló correctamente en los sistemas centrales,");
                                    mprLog("pero no se pudo actualizar su estado en el sistema C430.");
                                    mprLog("Dé aviso de esto a su administrador de redes.");
                                    return false;
                                }
                            }
                    }
                    else
                    {
                        if (mcesCuentaDatos.CanceladaB)
                        {
                            mprLog("La cuenta " + this.CuentaS + " ya se encuentra cancelada." + "\r\n" + 
                                    "El estado de la cuenta es " + mcesCuentaDatos.DescripcionS);
                        }
                        else
                        {
                            if (mcesCuentaDatos.SobregiroB)
                            {
                                mprLog("La cuenta " + this.CuentaS + " no se pudo cancelar debido a que se encuentra sobregirada." + 
                                    "\r\n" + "El estado de la cuenta es " + mcesCuentaDatos.DescripcionS);
                            }
                            else
                            {
                                mprLog("La cuenta " + this.CuentaS + " no puede ser cancelada debido a que su estado es " + 
                                    mcesCuentaDatos.DescripcionS);
                            }
                        }

                        return false;
                    }
                    pbReintentar = false;
                    break;
                    } // Switch
                } while (pbReintentar);
                mprLogSeparador();
                return false;
	        }
	        catch (Exception)
	        {
                mprErrLog("fnMkrCancelarCuentaB()");
                mprLogSeparador();
                return false;
	        }
        }
        //'*: Fin: fnCkrCancelarCuentaB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        public bool fnConectarB()
        {
            try 
	        {
                frmLoginS53 frmFirma = new frmLoginS53();
                var regreso = frmFirma.ShowDialog();

                if (regreso == DialogResult.OK)
                {
                    mprLog("Firma en sistemas centrales aceptada.");
                    return true;
                }
                else
                {
                    mprLog("No se puedo registrar la firma en los sistemas centrales:");
                    mprLog(mscnSisCentrales.LeyendaS);
                    return false;
                }
                mprLogSeparador();
	        }
	        catch (System.Exception)
	        {
                mprLog("No se puedo registrar la firma en los sistemas centrales.");
                mprErrLog("fnConectarB()");
                return false;
	        }
        }
        //'*: Fin: fnConectarB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        public bool fnDesconectarB()
        {
            try 
	        {	        
                bool fnDesconectarB1 = (!mscnSisCentrales.FnDesconectarS111());
                mprLog("Desconectando de los sistemas centrales.");
                mprLogSeparador();
                return fnDesconectarB1;
	        }
	        catch (System.Exception)
	        {
                mprLog("Ocurrió un error al intentar desconectarse de los sitemas centrales.");
                mprLog("Si el error persiste de aviso a su administrador de sistemas.");
                mprErrLog("fnDesconectarB()");
                return false;
	        }
        }

        public bool fnLlenarEstadosB()
        {
            try 
	        {	        
                msTransLog = CORVB.NULL_STRING;
                mprLog("Solicitando estados (situaciones) de cuenta.");
                
                CORVAR.pszgblsql = "SELECT ect_estado, ect_descripcion, ect_cancelable, ect_cancelada, ect_saldo FROM MTCECT01";

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);
                
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        //ReDim Preserve mxcesCuentaEstados[mxcesCuentaEstados.GetUpperBound(0) + 1];
                        mxcesCuentaEstados = ArraysHelper.RedimPreserve<typCuentaEstado[]>(mxcesCuentaEstados, new int[] { mxcesCuentaEstados.GetUpperBound(0) + 2 });
                        mxcesCuentaEstados[mxcesCuentaEstados.GetUpperBound(0)].EstadoS = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                        mxcesCuentaEstados[mxcesCuentaEstados.GetUpperBound(0)].DescripcionS = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        string sValor1 = (string)MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 3), -1);
                        string sValor2 = (string)MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 4), -1);
                        string sValor3 = (string)MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 4), -1);
                        mxcesCuentaEstados[mxcesCuentaEstados.GetUpperBound(0)].CancelableB = Boolean.Parse(sValor1);
                        mxcesCuentaEstados[mxcesCuentaEstados.GetUpperBound(0)].CanceladaB = Boolean.Parse(sValor2);
                        mxcesCuentaEstados[mxcesCuentaEstados.GetUpperBound(0)].SaldoB = Boolean.Parse(sValor3);
                    }
                    
                    mprLog("Transacción aplicada con éxito.");
                    return true;
                }
                else
                {
                    mprLog("No existen estados en el catálogo.");
                    mprLog("Dé aviso del problema a su administrador de redes.");
                    return false;
                }
                    
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                mprLogSeparador();
	        }
	        catch (System.Exception)
	        {
                mprErrLog("fnLlenarEstadosB");
                return false;
	        }
        }
        //'*: Fin: fnLlenarEstadosB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Envía la solicitud de cancelación de una cuenta (proceso Maker).
        //'*:
        //'*: NOTA:   Para poder utilizar este procedimiento, debe establecer los atributos miBanco, miDigVerif, msEjeMasc,
        //'*:         mlEjeNum, miEjeTam, msEmpMasc, mlEmpNum, miEmpTam, miPrefijo y miRollOver de antemano, ya sea directamente,
        //'*:         a través de sus equivalentes públicos (BancoI, DigVerifI, EjeMascS, EjeNumL, EjeTamI, EmpMascS, EmpNumI,
        //'*:         EmpTamI, PrefijoI, RollOverI) o mediante las propiedades CuentaS, EjeMascS/EjeTamI y EmpMascS/EmpNumI
        //'*:         prefiriendo las ultimas dos formas, ya que estas, conservan la consistencia de valores para los pares de
        //'*:         datos msEjeMasc/miEjeTam y msEmpMasc/miEmpTam.
        //'*:
        //'*: Ejemplo:
        //'*:         if Not clsCancelaciones.fnMkrCancelarCuentaB() Then
        //'*:             Msgbox "Se produjo un error al enviar la solicitud de cancelación de cuenta"
        //'*:         }
        public bool fnMkrCancelarCuentaB(enmCancelacionTipos aeTipo)
        {
            bool pbReintentar;

            try 
	        {	        
                msTransLog = CORVB.NULL_STRING;
                
                if (mfnExisteCtaEnCancelacionesB())
                {
                    mprLogSeparador();
                    return false;
                }
                
                if (mfnExisteCtaEnReenviosB(((aeTipo == enmCancelacionTipos.CTP_CUENTA_PADRE) ? true : false)))
                {
                    mprLogSeparador();
                    return false;
                }
                
                if (!fnConectarB())
                {
                    mprLogSeparador();
                    return false;
                }
                
                this.MakerNombreS = mscnSisCentrales.NombreS;
                this.MakerNominaS = mscnSisCentrales.NominaS;
                pbReintentar = false;

                do
                {
                    mprParametros(this.CuentaS, enmTransaccionTipos.TTP_377);

                    sTrans = mscnSisCentrales.StrIdTransaccion;
                    asCuenta1 = mscnSisCentrales.StrNoCuenta;
                    sParamAdi = mscnSisCentrales.StrParametrosAdicionales;
                    switch ((TransS111.EnumRespTransaccion) mscnSisCentrales.FnEnviarTransaccion(sTrans,
                                                                 asCuenta1,
                                                                 sParamAdi))
                    {
                    case TransS111.EnumRespTransaccion.EnRespConfirmar:
                        pbReintentar = true;
                        break;
                    case TransS111.EnumRespTransaccion.EnRespError:
                        pbReintentar = false;
                        mprLog("Ocurrió un error al ejecutar la consulta a los sistemas centrales." + "\r\n" + 
                                "Dé aviso del problema a su administrador de redes.");
                        mprLog(mscnSisCentrales.GetMsgerror(ref tempRefParam));
                        return false;
                    case TransS111.EnumRespTransaccion.EnRespOperacionNegada:
                        pbReintentar = false;
                        mprLog("La operación fue rechazada por los sistemas centrales.");
                        mprLog(mscnSisCentrales.GetMsgerror(ref tempRefParam));
                        return false;
                    case TransS111.EnumRespTransaccion.EnRespSinRespuesta:
                    case TransS111.EnumRespTransaccion.EnRespIniciado:
                        pbReintentar = false;
                        mprLog("No hay respuesta de los sistemas centrales, reintente de nuevo más tarde." + "\r\n" + 
                                "Si el problema persiste dé aviso a su administrador de redes.");
                        return false;
                    case TransS111.EnumRespTransaccion.EnRespTerminalSinFirmar:
                    case TransS111.EnumRespTransaccion.EnRespDarseAlta:
                        if (!fnConectarB())
                        {
                            mprLogSeparador();
                            mscnSisCentrales.FnDesconectarS111();
                            mprLog("Desconectando de los sistemas centrales.");
                            mprLogSeparador();
                            return false;
                        }
                        pbReintentar = true;
                        break;
                    case TransS111.EnumRespTransaccion.EnRespDesconocida:
                    case TransS111.EnumRespTransaccion.EnRespTransaccionAceptada:
                        mfnParsearResultadoB(enmTransaccionTipos.TTP_377, ref mcesCuentaDatos);
                        
                        if (mcesCuentaDatos.CancelableB)
                        {
                            return mfnMkrInsSolicitudB(msMakerNomina, msMakerNombre, aeTipo);
                        }
                        else
                        {
                            if (mcesCuentaDatos.CanceladaB)
                            {
                                mprLog("La cuenta " + this.CuentaS + " ya se encuentra cancelada." + "\r\n" + 
                                        "El estado de la cuenta es " + mcesCuentaDatos.DescripcionS);
                            }
                            else
                            {
                                if (mcesCuentaDatos.SobregiroB)
                                {
                                    mprLog("La cuenta " + this.CuentaS + " no se pudo cancelar debido a que se encuentra sobregirada." + 
                                        "\r\n" + "El estado de la cuenta es " + mcesCuentaDatos.DescripcionS);
                                }
                                else
                                {
                                    mprLog("La cuenta " + this.CuentaS + " no puede ser cancelada debido a que su estado es " + 
                                        mcesCuentaDatos.DescripcionS);
                                }
                            }
                            return false;
                        }
                        pbReintentar = false;
                        break;
                    } // switch
                } while (pbReintentar);
                
                mscnSisCentrales.FnDesconectarS111();
                mprLog("Desconectando de los sistemas centrales.");
                mprLogSeparador();
                return false;
	        }
	        catch (System.Exception)
	        {
                mprErrLog("fnMkrCancelarCuentaB()");
                mprLogSeparador();
                mscnSisCentrales.FnDesconectarS111();
                mprLog("Desconectando de los sistemas centrales.");
                mprLogSeparador();
                return false;
	        }
        }
        //'*: Fin: fnMkrCancelarCuentaB()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Regresa la descripción del estatus de transacción.
        //'*:
        //'*: Ejemplo:
        //'*:         For i = 0 to iNumRecs - 1
        //'*:             grdMalla(i, CONS_ESTADO) = clsCancelaciones.fnStatusDescS
        //'*:         Next i
        public string fnStatusDescS()
        {
            switch (mcesCuentaDatos.StatusTranE)
            {
            case enmCancelacionStatus.CST_APLICADA:
                return "Aplicada";
            case enmCancelacionStatus.CST_CANCELADO:
                return "Cancelada";
            case enmCancelacionStatus.CST_PENDIENTE:
                return "Pendiente";
            default:
                return "Sin Descripción";
            }
        }
        //'*: Fin: fnStatusDescS()
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Regresa la descripción del tipo de transacción.
        //'*:
        //'*: Ejemplo:
        //'*:         For i = 0 to iNumRecs - 1
        //'*:             grdMalla(i, CONS_TIPO) = clsCancelaciones.fnTipoDescS
        //'*:         Next i
        public string fnTipoDescS(enmCancelacionTipos aeTipo)
        {
            if (aeTipo == null)
            {
                aeTipo = mcesCuentaDatos.TipoE;
            }
            switch (aeTipo)
            {
                case enmCancelacionTipos.CTP_CUENTA_HIJA:
                    return "Hija";
                case enmCancelacionTipos.CTP_CUENTA_PADRE:
                    return "Padre";
                default:
                    return "Sin Descripción";
            }
            string variantType = "Cuenta " + fnTipoDescS(aeTipo);
            return variantType;
        }
        //'*: Fin: fnStatusDescS()
        //'*:--------------------------------------------------------------------------------
        //'*:********************************************************************************
        //'*: Fin: Métodos Públicos
        //'*:********************************************************************************



        //'*:********************************************************************************
        //'*: Atributos Públicos sin Correspondencia en Atributos Privados
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        //'*: Regresa el mensaje de error, en caso de este que sucediera, provocado por el objeto de acceso a los sistemas
        //'*: centrales.
        public string MsgErrorS
        {
		    get
		    {
                return mscnSisCentrales.GetMsgerror(ref tempRefParam);
		    }
        }
        //'*: Fin: MsgErrorS
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Regresa o establece el número de cuenta. Al modificar su valor, también lo hacen los atributos privados de la clase.
        //'*: En caso de que la longitud de cuenta sea mayor a MI_CUENTA_TAM dígitos, se truncará a los primeros dígitos; si la
        //'*: longitud de la cuenta es menor a MI_CUENTA_TAM dígitos, se rellenará con ceros. En caso de que se introduzcan
        //'*: valores no válidos los atributos de la clase no se verán afectados. No se avisará de esto al usuario.
        //'*:
        //'*: NOTA:   Para poder utilizar esta propiedad, debe establecer los atributos msEjeMasc/miEjeTam y msEmpMasc/miEmpTam de
        //'*:         antemano, ya sea directamente, a través de sus equivalentes públicos (EjeMascS/EjeTamI y EmpMascS/EmpTamI,
        //'*:         prefiriendose la ultima forma, ya que esta, conserva la consistencia de valores para los pares de datos
        //'*:         msEjeMasc/miEjeTam y msEmpMasc/miEmpTam. En caso de que alguno de los valores antes mencionados sea 0 (cero),
        //'*:         se establecerán a los valores predeterminados: 5 (cinco) para msEmpMasc y 3 (tres) para msEjeMasc.
        //'*:
        //'*: Ejemplo:
        //'*:         iRes = Msgbox("¿Está seguro que desea cancelar la cuenta: " + clsCancelaciones.CuentaS + "?", vbYesNo)
        public string CuentaS
        {
		    get
		    {
			    return StringsHelper.Format(miPrefijo, MS_PREFIJO_MASC) + StringsHelper.Format(miBanco, MS_BANCO_MASC) + StringsHelper.Format(mlEmpNum, msEmpMasc) +
                        StringsHelper.Format(mlEjeNum, msEjeMasc) + miRollOver + miDigVerif;
		    }
		    set
		    {
                int piPos;

                value = value.Trim();
                
                if (value.Length > MI_CUENTA_TAM)
                {
                    value = value.Substring(0, MI_CUENTA_TAM - 1);
                }
                else
                {
                    if (value.Length < MI_CUENTA_TAM)
                    {
                        value = value + new String('0', MI_CUENTA_TAM - value.Length);
                    }
                }
                
                meerEvaluador.ExpresionS = value;
                meerEvaluador.ReglaS = MS_CUENTA_REGLA + Conversion.Str(MI_CUENTA_TAM);
                
                if (meerEvaluador.fnValidarExpresionB())
                {
                    return;
                }
                    
                piPos = 1;
                miPrefijo = int.Parse(Strings.Mid(value, piPos, MS_PREFIJO_MASC.Length));
                piPos = piPos + MS_PREFIJO_MASC.Length;
                miBanco = int.Parse(Strings.Mid(value, piPos, MS_BANCO_MASC.Length));
                piPos = piPos + MS_BANCO_MASC.Length;
                mlEmpNum = int.Parse(Strings.Mid(value, piPos, miEmpTam));
                piPos = piPos + miEmpTam;
                mlEjeNum = int.Parse(Strings.Mid(value, piPos, miEjeTam));
                piPos = piPos + miEjeTam;
                miRollOver = int.Parse(Strings.Mid(value, piPos, 1));
                piPos = piPos + 1;
                miDigVerif = int.Parse(Strings.Mid(value, piPos, 1));
		    }

        }
        //'*:--------------------------------------------------------------------------------
        //'*:********************************************************************************
        //'*: Fin: Atributos Públicos sin Correspondencia en Atributos Privados
        //'*:********************************************************************************



        //'*:********************************************************************************
        //'*: Atributos Públicos con Correspondencia en Atributos Privados
        //'*:********************************************************************************
        //'*:--------------------------------------------------------------------------------
        //'*: Atributo miBanco.
	    public int BancoI
	    {
		    get
		    {
			    return miBanco;
		    }
		    set
		    {
			    miBanco = value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msCheckerNombre
	    public string CheckerNombreS
	    {
		    get
		    {
			    return msCheckerNombre;
		    }
		    set
		    {
			    msCheckerNombre = value.Trim();
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msCheckerNomina
	    public string CheckerNominaS
	    {
		    get
		    {
			    return msCheckerNomina;
		    }
		    set
		    {
			    msCheckerNomina = value.Trim();
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msCuentahabiente
	    public string CuentahabienteS
	    {
		    get
		    {
			    return msCuentahabiente;
		    }
		    set
		    {
			    msCuentahabiente = value.Trim();
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo miDigVerif.
	    public int DigVerifI
	    {
		    get
		    {
			    return miDigVerif;
		    }
		    set
		    {
			    miDigVerif = value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msEjeMasc.
        //'*: Al establecer este atributo se modifican los valores de msEjeMasc, miEjeTam, miEmpMasc y miEmpTam. En caso de que se
        //'*: introduzcan valores no validos los atributos de la clase no se verán afectados. No se avisará de esto al usuario.
        public string EjeMascS
        {
		    get
		    {
			    return msEjeMasc;
		    }
		    set
		    {
                int piTam;

                value = value.Trim();
                piTam = value.Length;
                
                if (piTam > MI_PLASTICO_TAM)
                {
                    return;
                }           
                meerEvaluador.ExpresionS = value;
                meerEvaluador.ReglaS = MS_MASC_REGLA;
                
                if (!meerEvaluador.fnValidarExpresionB())
                {
                    return;
                }            
                msEjeMasc = new String(char.Parse(MS_MASC_CAR), piTam);
                miEjeTam = piTam;
                msEmpMasc = new String(char.Parse(MS_MASC_CAR), MI_PLASTICO_TAM - piTam);
                miEmpTam = MI_PLASTICO_TAM - piTam;
		    }

        }
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo mlEjeNum.
	    public int EjeNumL
	    {
		    get
		    {
			    return mlEjeNum;
		    }
		    set
		    {
			    mlEjeNum = value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo miEjeTam
        //'*: Al establecer este atributo se modifican los valores de msEjeMasc, miEjeTam, miEmpMasc y miEmpTam. En caso de que se
        //'*: introduzcan valores no validos los atributos de la clase no se verán afectados. No se avisará de esto al usuario.
	    public int EjeTamI
	    {
		    get
		    {
			    return miEjeTam;
		    }
		    set
		    {
                if ((value > MI_PLASTICO_TAM) || (value < CORVB.NULL_INTEGER))
                {
                    return;
                }
                msEjeMasc = new String(char.Parse(MS_MASC_CAR), value);
                miEjeTam = value;
                msEmpMasc = new String(char.Parse(MS_MASC_CAR), MI_PLASTICO_TAM - value);
                miEmpTam = MI_PLASTICO_TAM - value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msEmpMasc
        //'*: Al establecer este atributo se modifican los valores de msEjeMasc, miEjeTam, miEmpMasc y miEmpTam. En caso de que se
        //'*: introduzcan valores no validos los atributos de la clase no se verán afectados. No se avisará de esto al usuario.
        public string EmpMascS
        {
		    get
		    {
			    return msEmpMasc;
		    }
		    set
		    {
                int piTam;

                value = value.Trim();
                piTam = value.Length;
                
                if (piTam > MI_PLASTICO_TAM)
                {
                    return;
                }
                
                meerEvaluador.ExpresionS = value;
                meerEvaluador.ReglaS = MS_MASC_REGLA;
                
                if (!meerEvaluador.fnValidarExpresionB())
                {
                    return;
                }

                msEjeMasc = new String(char.Parse(MS_MASC_CAR), MI_PLASTICO_TAM - piTam);
                miEjeTam = MI_PLASTICO_TAM - piTam;
                msEmpMasc = new String(char.Parse(MS_MASC_CAR), piTam);
                miEmpTam = piTam;
		    }

        }
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo mlEmpNum
	    public int EmpNumL
	    {
		    get
		    {
			    return mlEmpNum;
		    }
		    set
		    {
			    mlEmpNum = value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo miEmpTam
        //'*: Al establecer este atributo se modifican los valores de msEjeMasc, miEjeTam, miEmpMasc y miEmpTam. En caso de que se
        //'*: introduzcan valores no validos los atributos de la clase no se verán afectados. No se avisará de esto al usuario.
	    public int EmpTamI
	    {
		    get
		    {
			    return miEmpTam;
		    }
		    set
		    {
                if ((value > MI_PLASTICO_TAM) || (value < CORVB.NULL_INTEGER))
                {
                    return;
                }
                
                msEjeMasc = new String(char.Parse(MS_MASC_CAR), MI_PLASTICO_TAM - value);
                miEjeTam = MI_PLASTICO_TAM - value;
                msEmpMasc = new String(char.Parse(MS_MASC_CAR), value);
			    miEmpTam = value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msMakerNombre
	    public string MakerNombreS
	    {
		    get
		    {
			    return msMakerNombre;
		    }
		    set
		    {
			    msMakerNombre = value.Trim();
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msMakerNomina
	    public string MakerNominaS
	    {
		    get
		    {
			    return msMakerNomina;
		    }
		    set
		    {
			    msMakerNomina = value.Trim();
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo miNumCtasHijas
	    public int NumCuentasHijasL
	    {
		    get
		    {
			    return miNumCtasHijas;
		    }
		    set
		    {
			    miNumCtasHijas = value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo miPrefijo
	    public int PrefijoI
	    {
		    get
		    {
			    return miPrefijo;
		    }
		    set
		    {
			    miPrefijo = value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo miRollOver
	    public int RollOverI
	    {
		    get
		    {
			    return miRollOver;
		    }
		    set
		    {
			    miRollOver = value;
		    }
	    }

        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msTransLog
        //'*: Atributo de sólo lectura.
	    public string TransLogS
	    {
		    get
		    {
			    return msTransLog;
		    }
        }
        //'*:--------------------------------------------------------------------------------

        //'*:--------------------------------------------------------------------------------
        //'*: Atributo msUltMsg
        //'*: Atributo de sólo lectura.
	    public string UltMsgS
	    {
		    get
		    {
			    return msUltMsg;
		    }
        }

        //'*:--------------------------------------------------------------------------------
        //'*:********************************************************************************
        //'*: Fin: Atributos Públicos con Correspondencia en Atributos Privados
        //'*:********************************************************************************

        //'*:********************************************************************************
        //'*: Constructor y Destructor
        //'*:********************************************************************************
        public void Class_Initialize()
        {
            mscnSisCentrales = new N_ActualizaS111.ClsConectaS111();
            meerEvaluador = new EvaluadorExpReg.clsExpresionesRegulares();
            this.EjeTamI = MI_EJE_TAM_DEFAULT;
            mlNumCtasHijas = 0;
            
            mcesCuentaDatos.CancelableB = false;
            mcesCuentaDatos.CanceladaB = false;
            mcesCuentaDatos.DescripcionS = CORVB.NULL_STRING;
            mcesCuentaDatos.DisponibleF = 0;
            mcesCuentaDatos.EstadoS = CORVB.NULL_STRING;
            mcesCuentaDatos.SaldoB = false;
            mcesCuentaDatos.SaldoF = 0;
            mcesCuentaDatos.SobregiroB = false;
            mcesCuentaDatos.SobregiroF = 0;
            mcesCuentaDatos.StatusTranE = enmCancelacionStatus.CST_PENDIENTE;
            mcesCuentaDatos.TipoE = enmCancelacionTipos.CTP_CUENTA_HIJA;
            
            //ReDim mxcesCuentaEstados(0);
            mxcesCuentaEstados = ArraysHelper.RedimPreserve<typCuentaEstado[]>(mxcesCuentaEstados, new int[] {0});

        }

        public void Class_Terminate()
        {
            try 
	        {	        
                mscnSisCentrales = null;
                meerEvaluador = null;
                //ReDim mxcesCuentaEstados(0);
                mxcesCuentaEstados = ArraysHelper.RedimPreserve<typCuentaEstado[]>(mxcesCuentaEstados, new int[] {0});
	        }
	        catch (System.Exception)
	        {
	        }
        }
        //'*:********************************************************************************
        //'*: Fin: Constructor y Destructor
        //'*:********************************************************************************

    }
}
