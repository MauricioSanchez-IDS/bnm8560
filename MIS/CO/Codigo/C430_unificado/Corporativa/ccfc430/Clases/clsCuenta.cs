using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using Microsoft.CSharp;
using System.Configuration;

namespace TCc430
{
    internal class clsCuenta
    {

        private N_TransS111.ClsConsulta N_objConsulta = null;

        private TransS111.ClsConsulta objConsulta = null;
        private const int LIM_CRED_BASE = 5;
        public enum trnTransacciones
        {
            trnActualizaLimite = 5117
        }
        public enum ctaTiposCuenta
        {
            ctaEmpresarial = 1,
            ctaEjecutiva = 2
        }
        public string mensajeRespuestaS = string.Empty;
        private prySeguridadS041.clsMaker _mmkrCambiaLimCred = null;
        private prySeguridadS041.clsMaker mmkrCambiaLimCred
        {
            get
            {
                return _mmkrCambiaLimCred;
            }
            set
            {
                if (_mmkrCambiaLimCred != value)
                {
                    if (_mmkrCambiaLimCred != null)
                    {
                        //this.mmkrCambiaLimCred.Maker -= new prySeguridadS041.__clsMaker_MakerEventHandler(this.mmkrCambiaLimCred_Maker);
                        //this.mmkrCambiaLimCred.Validate -= new prySeguridadS041.__clsMaker_ValidateEventHandler(this.mmkrCambiaLimCred_Validate);
                    }
                    _mmkrCambiaLimCred = value;
                    if (_mmkrCambiaLimCred != null)
                    {
                        this.mmkrCambiaLimCred.Maker += new prySeguridadS041.__clsMaker_MakerEventHandler(this.mmkrCambiaLimCred_Maker);
                        this.mmkrCambiaLimCred.Validate += new prySeguridadS041.__clsMaker_ValidateEventHandler(this.mmkrCambiaLimCred_Validate);
                    }
                }
            }
        }

        private prySeguridadS041.clsChecker _mckrCambiaLimCred = null;
        private prySeguridadS041.clsChecker mckrCambiaLimCred
        {
            get
            {
                return _mckrCambiaLimCred;
            }
            set
            {
                if (_mckrCambiaLimCred != value)
                {
                    if (_mckrCambiaLimCred != null)
                    {
                        //this.mckrCambiaLimCred.Validate -= new prySeguridadS041.__clsChecker_ValidateEventHandler(this.mckrCambiaLimCred_Validate);
                        //this.mckrCambiaLimCred.PreparaDatos -= new prySeguridadS041.__clsChecker_PreparaDatosEventHandler(this.mckrCambiaLimCred_PreparaDatos);
                        //this.mckrCambiaLimCred.PostChecker -= new prySeguridadS041.__clsChecker_PostCheckerEventHandler(this.mckrCambiaLimCred_PostChecker);
                        //this.mckrCambiaLimCred.Checker -= new prySeguridadS041.__clsChecker_CheckerEventHandler(this.mckrCambiaLimCred_Checker);
                    }
                    _mckrCambiaLimCred = value;
                    if (_mckrCambiaLimCred != null)
                    {
                        this.mckrCambiaLimCred.Validate += new prySeguridadS041.__clsChecker_ValidateEventHandler(this.mckrCambiaLimCred_Validate);
                        this.mckrCambiaLimCred.PreparaDatos += new prySeguridadS041.__clsChecker_PreparaDatosEventHandler(this.mckrCambiaLimCred_PreparaDatos);
                        this.mckrCambiaLimCred.PostChecker += new prySeguridadS041.__clsChecker_PostCheckerEventHandler(this.mckrCambiaLimCred_PostChecker);
                        this.mckrCambiaLimCred.Checker += new prySeguridadS041.__clsChecker_CheckerEventHandler(this.mckrCambiaLimCred_Checker);
                    }
                }
            }
        }

        private prySeguridadS041.clsAccion maccAccion = null;

        private string msCuenta = String.Empty;
        private decimal mcLimiteCredS111 = 0;
        private decimal mcLimiteCredNuevo = 0;
        private string msTransLog = String.Empty; //*: Cadena que contiene la bitacora de la última operación realizada.

        private clsProducto mprdProducto = new clsProducto();
        //Desglose de la Cuenta
        private string msPrefijo = String.Empty;
        private string msBanco = String.Empty;
        private string msEmpresa = String.Empty;
        private string msEjecutivo = String.Empty;
        private string msRollOver = String.Empty;
        private string msDigitoVerificador = String.Empty;
        private pryActualizaS111.ClsConectaS111 mcnsS111 = null;

        private N_ActualizaS111.ClsConectaS111 mcnsS111N = null;

        private ctaTiposCuenta meTipoCuenta = (ctaTiposCuenta)0;

        public ctaTiposCuenta TipoCuentaE
        {
            get
            {
                return meTipoCuenta;
            }
        }


        public string LogS
        {
            get
            {
                return msTransLog;
            }
        }

        //*:--------------------------------------------------------------------------------




        public clsProducto productoPRD
        {
            get
            {
                return mprdProducto;
            }
            set
            {
                mprdProducto = value;
            }
        }


        public decimal LimiteCredC
        {
            get
            {
                return mcLimiteCredS111;
            }
            set
            {
                mcLimiteCredS111 = value;
            }
        }




        public string CuentaS
        {
            get
            {
                return msCuenta;
            }
            set
            {
                msCuenta = value;
                msPrefijo = String.Empty;
                msBanco = String.Empty;
                msEmpresa = String.Empty;
                msEjecutivo = String.Empty;
                msRollOver = String.Empty;
                msDigitoVerificador = String.Empty;
                if (msCuenta.Length >= 14)
                {
                    if (mprdProducto.LongitudPrefijoL > 0 && mprdProducto.LongitudBancoL > 0 && mprdProducto.LongitudEmpresaI > 0 && mprdProducto.LongitudEjecutivoI > 0)
                    {
                        msPrefijo = Strings.Mid(msCuenta, 1, mprdProducto.LongitudPrefijoL);
                        msBanco = Strings.Mid(msCuenta, mprdProducto.LongitudPrefijoL + 1, mprdProducto.LongitudBancoL);
                        msEmpresa = Strings.Mid(msCuenta, mprdProducto.LongitudPrefijoL + mprdProducto.LongitudBancoL + 1, mprdProducto.LongitudEmpresaI);
                        msEjecutivo = Strings.Mid(msCuenta, mprdProducto.LongitudPrefijoL + mprdProducto.LongitudBancoL + mprdProducto.LongitudEmpresaI + 1, mprdProducto.LongitudEjecutivoI);
                        if (Double.Parse(msEjecutivo) == 0)
                        {
                            meTipoCuenta = ctaTiposCuenta.ctaEmpresarial;
                        }
                        else
                        {
                            meTipoCuenta = ctaTiposCuenta.ctaEjecutiva;
                        }
                        if (msCuenta.Length > 14)
                        {
                            msRollOver = Strings.Mid(msCuenta, 15, 1);
                        }
                        if (msCuenta.Length > 15)
                        {
                            msDigitoVerificador = Strings.Mid(msCuenta, 16, 1);
                        }
                    }
                }
            }
        }


        //*---Métodos para el Manejo de Enlace al Sistema S111---------------------------------------------------------------
        public bool ConectarS111B(prySeguridadS041.clsUsuario usupUsuario)
        {
            bool result = false;

            pryActualizaS111.ClsConectaS111 mcnsS111Obj = null;
            try
            {

                if (usupUsuario != null)
                {
                    mcnsS111Obj = new pryActualizaS111.ClsConectaS111();

                    mcnsS111N = new N_ActualizaS111.ClsConectaS111();

                    //AIS-1146 NGONZALEZ
                    string tempStr = Seguridad.usugUsuario.NominaS;
                    mcnsS111Obj.set_Usuario(ref tempStr);
                    //mcnsS111N.set_Usuario(ref tempStr);
                    //if (mcnsS111.FnPreguntaPwd())
                    //{
                    N_objConsulta = new N_TransS111.ClsConsulta();
                    //objConsulta = new TransS111.ClsConsulta();
                    frmLoginS53 frmFirma = new frmLoginS53();
                    var regreso = frmFirma.ShowDialog();

                    if (regreso == DialogResult.OK)
                    {
                        mprLog("Sesion S111 Aceptada.");
                        result = true;
                    }
                    else
                    {
                        mprLog("No se puede establecer enlace al Sistema S111.");
                        mprLog(mcnsS111Obj.LeyendaS);
                        result = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se ha establecido un usuario Válido.", "Conecta S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch( Exception ex)
            {

                mprLog("No se puede establecer enlace al Sistema S111.");
                //    mprErrLog "ConectarS111B()"
                result = false;
            }
            return result;
        }

        public bool fnDesconectarB()
        {
            bool result = false;
            //result = ! mcnsS111.FnDesconectarS111();
            mprLog("Desconectando del Sistema S111.");
            mprLogSeparador();
            return result;
        }
        //*------------------------------------------------------------------------------------------------------------------

        //*:--Métodos Para Manejo de LOG---------------------------------------------------
        private void mprLogSeparador()
        {
            msTransLog = msTransLog + new string('-', 80) + "\n";
        }

        private void mprLog(string asAccion)
        {
            msTransLog = msTransLog + asAccion + "\r\n";
        }

        private bool bfncValidaCuenta(bool bpDesplegarError)
        {
            if (bpDesplegarError)
            {
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(msPrefijo))
                {
                    MessageBox.Show("No se ha determinado el Prefijo, la operación efectuada no será consistente.", "Valida Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            else
            {
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(msPrefijo))
                {
                    MessageBox.Show("No se ha determinado el Prefijo, la operación efectuada no será consistente.", "Valida Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }

            if (bpDesplegarError)
            {
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(msBanco))
                {
                    MessageBox.Show("No se ha determinado el Banco, la operación efectuada no será consistente.", "Valida Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            else
            {
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(msBanco))
                {
                    MessageBox.Show("No se ha determinado el Banco, la operación efectuada no será consistente.", "Valida Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }

            if (bpDesplegarError)
            {
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(msEmpresa))
                {
                    MessageBox.Show("No se ha determinado la Empresa, la operación efectuada no será consistente.", "Valida Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            else
            {
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(msEmpresa))
                {
                    MessageBox.Show("No se ha determinado la Empresa, la operación efectuada no será consistente.", "Valida Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }

            if (bpDesplegarError)
            {
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(msEjecutivo))
                {
                    MessageBox.Show("No se ha determinado el Ejecutivo, la operación efectuada no será consistente.", "Valida Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            else
            {
                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(msEjecutivo))
                {
                    MessageBox.Show("No se ha determinado el Ejecutivo, la operación efectuada no será consistente.", "Valida Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            return true;
        }

        private bool bfncValidaCuenta()
        {
            return bfncValidaCuenta(false);
        }

        public clsCuenta()
        {
            mmkrCambiaLimCred = new prySeguridadS041.clsMaker();
            mckrCambiaLimCred = new prySeguridadS041.clsChecker();
            //Maker
            mmkrCambiaLimCred.UsuarioUSU = Seguridad.usugUsuario;
            mckrCambiaLimCred.UsuarioUSR = Seguridad.usugUsuario;
        }

        ~clsCuenta()
        {
            mprdProducto = null;
            mmkrCambiaLimCred = null;
            mckrCambiaLimCred = null;
        }


        //---------- PROCEDIMIENTOS Y FUNCIONES PARA ACTUALIZAR EL LÍMITE DE Crédito ----------------------------------------------------------'
        public int ActualizaLimiteCredI(prySeguridadS041._clsAccion accpAccion, decimal cpNuevoLimiteCred, prySeguridadS041.topTipoOperMakerChecker epModoOp)
        {
            bool blOpSuccesful = false;
            string spParametros = String.Empty;

            msTransLog = String.Empty;
            if (accpAccion == null)
            {
                MessageBox.Show("No se ha determinado una acción.", "Actualiza Límite de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            maccAccion = (prySeguridadS041.clsAccion)accpAccion;
            if (epModoOp == prySeguridadS041.topTipoOperMakerChecker.topMaker)
            {
                mmkrCambiaLimCred.AccionI = (short)accpAccion.idAccionI;
                if (mdlADO.fncVerificaConexionM111b())
                {
                    mcLimiteCredNuevo = cpNuevoLimiteCred;
                    prySeguridadS041.clsUsuario tempRefParam = mmkrCambiaLimCred.UsuarioUSU;
                    blOpSuccesful = mmkrCambiaLimCred.EjecutaMakerI(ref tempRefParam, ref VBSQL.gConn[10], maccAccion) != 0;
                }
                else
                {
                    blOpSuccesful = false;
                }
            }

            if (epModoOp == prySeguridadS041.topTipoOperMakerChecker.topChecker)
            {
                mckrCambiaLimCred.HeredarAccion(ref accpAccion);
                spParametros = " 3, " + msPrefijo + ", " + msBanco + ", " + msEmpresa + ", " + msEjecutivo;
                if (mdlADO.fncVerificaConexionM111b())
                {
                    mcLimiteCredNuevo = cpNuevoLimiteCred;
                    mckrCambiaLimCred.RolMakerCheckerI = 2;
                    //UPGRADE_WARNING: (6021) Casting 'byte' to Enum may cause different behaviour.
                    blOpSuccesful = mckrCambiaLimCred.EjecutaCheckerB(ref VBSQL.gConn[10], (prySeguridadS041.enuOperaciones)0, "sp_ObtenMaker", spParametros, maccAccion);
                }
                else
                {
                    blOpSuccesful = false;
                }
            }
            return Convert.ToInt32(Math.Abs((blOpSuccesful) ? -1 : 0));
        }
        private int ConsultaS111I()
        {
            int result = 0;
            TransS111.ClsConsulta cns377 = new TransS111.ClsConsulta();



            //Objetivo: Realizar una consulta de propiedades al sistema S111
            try
            {
                cns377 = new TransS111.ClsConsulta();


                //AIS-1146 NGONZALEZ
                TransS111.ClsSeguridad tempSg = Seguridad.usugUsuario.SesionS041_SGR;




                cns377.set_ConexionSeguridad(ref tempSg);
                cns377.prIdTransaccion("377");

                //AIS-1119 NGONZALEZ
                String tempString = String.Empty;
                cns377.Enviar(ref msCuenta, ref tempString);


                if (cns377.RespuestaTransS111.IndexOf("NO EXISTE") == -1)
                {
                    result = 0;
                    if (cns377.RespuestaTransS111.IndexOf("NO EXISTE") >= 0)
                    {
                        result = 1;
                        mprLog("377 " + msCuenta);
                        mprLog(cns377.RespuestaTransS111);
                    }
                    else
                    {

                        int iniciocorte = cns377.RespuestaTransS111.IndexOf("LIM:(") + 6;
                        int finalcorte = cns377.RespuestaTransS111.IndexOf("MINIMO PAGAR: (") - 1;

                        string limitestr = cns377.RespuestaTransS111.Substring(iniciocorte, finalcorte - iniciocorte).Replace("\r\n", "").Replace(",", "").Trim();

                        mcLimiteCredS111 = Convert.ToDecimal(limitestr);
                    }
                }
                else
                {
                    result = 1;
                }
            }
            catch
            {

                MessageBox.Show(cns377.RespuestaTransS111, Application.ProductName);
                //throw new Exception("Migration Exception: 'Resume Next' not supported");
            }
            return result;
        }


        //private int ConsultaS111I()
        //{
        //    int result = 0;
        //    TransS111.ClsConsulta cns377 = new TransS111.ClsConsulta();
        //    N_ActualizaS111.ClsConectaS111 conecta = new N_ActualizaS111.ClsConectaS111();

        //    conecta.FnEnviarTransaccion("377", msCuenta);

        //    //Objetivo: Realizar una consulta de propiedades al sistema S111
        //    try
        //    {
        //        cns377 = new TransS111.ClsConsulta();
        //        //AIS-1146 NGONZALEZ
        //        TransS111.ClsSeguridad tempSg = Seguridad.usugUsuario.SesionS041_SGR;
        //        cns377.set_ConexionSeguridad(ref tempSg);
        //        cns377.prIdTransaccion("377");
        //        //AIS-1119 NGONZALEZ
        //        String tempString = String.Empty;
        //        cns377.Enviar(ref msCuenta, ref tempString);
        //        if (cns377.ContarPropiedades > 0)
        //        {
        //            result = 0;
        //            if (cns377.RespuestaTransS111.IndexOf("NO EXISTE") >= 0)
        //            {
        //                result = 1;
        //                mprLog("377 " + msCuenta);
        //                mprLog(cns377.RespuestaTransS111);
        //            }
        //            else
        //            {
        //                //UPGRADE_WARNING: (1068) cns377.Propiedades().Valor of type Variant is being forced to decimal.
        //                object tempRefParam = "LIMITE";
        //                //AIS-1146 NGONZALEZ
        //                mcLimiteCredS111 = Convert.ToDecimal(cns377.get_Propiedades(ref tempRefParam).get_Valor());
        //            }
        //        }
        //        else
        //        {
        //            result = 1;
        //        }
        //    }
        //    catch
        //    {

        //        MessageBox.Show(cns377.RespuestaTransS111, Application.ProductName);
        //        //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
        //        //throw new Exception("Migration Exception: 'Resume Next' not supported");
        //    }
        //    return result;
        //}

        private TransS111.EnumRespTransaccion ActualizaS111(trnTransacciones ptrnTransaccion)
        {
            //Objetivo: Realizar una consulta de propiedades al sistema S111
            TransS111.EnumRespTransaccion result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
            try
            {
                if (ptrnTransaccion == trnTransacciones.trnActualizaLimite)
                {
                    //Determina Layout de Transacción

                    N_ActualizaS111.ClsConectaS111 mcnsS111N_Actualiza = new N_ActualizaS111.ClsConectaS111();
                 

                    mcnsS111N_Actualiza.StrNoCuenta = msCuenta;
                    mcnsS111N_Actualiza.StrIdTransaccion = ((int)trnTransacciones.trnActualizaLimite).ToString();
                    mcnsS111N_Actualiza.StrParametrosAdicionales = Convert.ToInt32(mcLimiteCredNuevo).ToString();

                    String tempString = String.Empty;
                    string _Reintentos = ConfigurationManager.AppSettings["_Reintentos"];
                    int contador = 0;

                    do
                    {
                        result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
                        result = (TransS111.EnumRespTransaccion)mcnsS111N_Actualiza.FnEnviarTransaccion(tempString, tempString, tempString);

                        if (TransS111.EnumRespTransaccion.EnRespDesconocida == result)
                        {
                            if (mcnsS111N_Actualiza.RespuestaS.IndexOf("Sesion Dual") >= 0 || mcnsS111N_Actualiza.RespuestaS.IndexOf("SEG; FAVOR") >= 0)
                            {
                                contador--;
                                result = TransS111.EnumRespTransaccion.EnRespOperacionNegada;
                            }
                            else {
                                result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
                            }
                        }
                        contador++;
                    }
                    while (contador < Convert.ToInt32(_Reintentos) && TransS111.EnumRespTransaccion.EnRespOperacionNegada == result);

                    /*

                    if (TransS111.EnumRespTransaccion.EnRespDesconocida == result)
                    {

                        if (mcnsS111N.RespuestaS.IndexOf("CREDITO ACTUALIZADA") >= 0)
                            result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
                        else
                        {
                            if (TransS111.EnumRespTransaccion.EnRespDesconocida == result)
                            {
                                if (mcnsS111N.RespuestaS.IndexOf("Sesion Dual") >= 0 || mcnsS111N.RespuestaS.IndexOf("SEG; FAVOR") >= 0)
                                {
                                    result = (TransS111.EnumRespTransaccion)mcnsS111N.FnEnviarTransaccion(tempString, tempString, tempString);
                                }


                                if (mcnsS111N.RespuestaS.IndexOf("OPERADOR NO AUTORIZADO") >= 0)
                                {
                                    //AIS-1119 NGONZALEZ
                                    //result = mcnsS111.FnEnviarTransaccion(ref tempString, ref tempString, ref tempString);
                                    result = (TransS111.EnumRespTransaccion)mcnsS111N.FnEnviarTransaccion(tempString, tempString, tempString);

                                    if (TransS111.EnumRespTransaccion.EnRespDesconocida == result)
                                    {

                                        if (mcnsS111N.RespuestaS.IndexOf("OPERADOR NO AUTORIZADO") >= 0)
                                        {
                                            result = TransS111.EnumRespTransaccion.EnRespOperacionNegada;
                                        }

                                    }

                                }

                                if (mcnsS111N.RespuestaS.IndexOf("ERROR EN IMPORTE") >= 0 || mcnsS111N.RespuestaS.IndexOf("OPERADOR NO AUTORIZADO") >= 0)
                                {
                                    result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
                                }


                                if (mcnsS111N.RespuestaS.IndexOf("CREDITO ACTUALIZADA") >= 0)
                                    result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
                                if (mcnsS111N.RespuestaS.IndexOf("TRANSAC NO PERMITIDA") >= 0)
                                    result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;


                            }
                        }
                    }


                    */

                    //mprLog(mcnsS111.StrIdTransaccion + " " + msCuenta + " " + Convert.ToInt32(mcLimiteCredNuevo).ToString());
                    //mprLog(mcnsS111.RespuestaS);
                    //if (mcnsS111.RespuestaS.IndexOf("ERROR EN IMPORTE") >= 0 || mcnsS111.RespuestaS.IndexOf("OPERADOR NO AUTORIZADO") >= 0)
                    mprLog(mcnsS111N_Actualiza.StrIdTransaccion + " " + msCuenta + " " + Convert.ToInt32(mcLimiteCredNuevo).ToString());
                    mprLog(mcnsS111N_Actualiza.RespuestaS);

                mensajeRespuestaS=mcnsS111N_Actualiza.RespuestaS;
                }
                else
                {
                    MessageBox.Show("Transacción no implementada.", "Actualiza S111", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {

                //MessageBox.Show(mcnsS111.RespuestaS, Application.ProductName);
                MessageBox.Show(mcnsS111N.RespuestaS, Application.ProductName);

                //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead.
                //  throw new Exception("Migration Exception: 'Resume Next' not supported");
            }
            return result;
        }


        private TransS111.EnumRespTransaccion ConsultaCuentaS111(trnTransacciones ptrnTransaccion)
        {
            //Objetivo: Realizar una consulta de propiedades al sistema S111
            TransS111.EnumRespTransaccion result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
            try
            {
                if (ptrnTransaccion == trnTransacciones.trnActualizaLimite)
                {
                    //Determina Layout de Transacción

                    N_ActualizaS111.ClsConectaS111 mcnsS111N_Actualiza = new N_ActualizaS111.ClsConectaS111();


                    mcnsS111N_Actualiza.StrNoCuenta = msCuenta;
                    mcnsS111N_Actualiza.StrIdTransaccion = "5001";
                  

                    String tempString = String.Empty;
                    string _Reintentos = ConfigurationManager.AppSettings["_Reintentos"];
                    int contador = 0;

                    do
                    {
                        result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
                        result = (TransS111.EnumRespTransaccion)mcnsS111N_Actualiza.FnEnviarTransaccion(tempString, tempString, tempString);

                        if (TransS111.EnumRespTransaccion.EnRespDesconocida == result)
                        {
                            if (mcnsS111N_Actualiza.RespuestaS.IndexOf("Sesion Dual") >= 0 || mcnsS111N_Actualiza.RespuestaS.IndexOf("SEG; FAVOR") >= 0)
                            {
                                contador--;
                                result = TransS111.EnumRespTransaccion.EnRespOperacionNegada;
                            }
                            else
                            {
                                result = TransS111.EnumRespTransaccion.EnRespTransaccionAceptada;
                            }
                        }
                        contador++;
                    }
                    while (contador < Convert.ToInt32(_Reintentos) && TransS111.EnumRespTransaccion.EnRespOperacionNegada == result);


                    mprLog(mcnsS111N_Actualiza.StrIdTransaccion + " " + msCuenta + " " + Convert.ToInt32(mcLimiteCredNuevo).ToString());
                    mprLog(mcnsS111N_Actualiza.RespuestaS);

                    mensajeRespuestaS = mcnsS111N_Actualiza.RespuestaS;
                }
                else
                {
                    MessageBox.Show("Transacción no implementada.", "Actualiza S111", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {

              
                MessageBox.Show(mcnsS111N.RespuestaS, Application.ProductName);

              
            }
            return result;
        }
        private int ActualizaM111(ADODB.Connection cnnpConexion)
        {
            int result = 0;
            bool ErrActualizaM111 = false;
            string slSQL = String.Empty;
            int lira = 0;
            try
            {
                ErrActualizaM111 = true;
                result = 0;
                if (cnnpConexion.State != 0)
                {
                    //Actualiza el límite del ejecutivo
                    slSQL = "BEGIN TRAN" + "\n";
                    slSQL = slSQL + "   UPDATE MTCEJE01 SET" + "\n";
                    slSQL = slSQL + "       eje_limcred = " + mcLimiteCredS111.ToString() + "\n";
                    slSQL = slSQL + "   WHERE " + "\n";
                    slSQL = slSQL + "       eje_prefijo = " + msPrefijo + "\n";
                    slSQL = slSQL + "   AND gpo_banco = " + msBanco + "\n";
                    slSQL = slSQL + "   AND emp_num = " + msEmpresa + "\n";
                    slSQL = slSQL + "   AND eje_num = " + msEjecutivo + "\n" + "\n";
                    //Actualiza el Acumulado de la empresa
                    slSQL = slSQL + "   UPDATE MTCEMP01 SET" + "\n";
                    //        slSQL = slSQL & "   emp_acum_cred = (select sum(eje_limcred) from MTCEJE01" & vbNewLine
                    //        slSQL = slSQL & "                 WHERE " & vbNewLine
                    //        slSQL = slSQL & "                     eje_prefijo = MTCEMP01.eje_prefijo" & vbNewLine
                    //        slSQL = slSQL & "                 AND gpo_banco = MTCEMP01.gpo_banco " & vbNewLine
                    //        'slSQL = slSQL & "                 AND emp_num = MTCEMP01.emp_num)" & vbNewLine
                    //        slSQL = slSQL & "                 AND emp_num = MTCEMP01.emp_num AND eje_num >0 )" & vbNewLine 'corrige YURIA 18/05/06 eje_num > 0
                    // Modif. 18/Jun/2007 Calc Lim Real
                    slSQL = slSQL + "   emp_acum_cred = ";
                    slSQL = slSQL + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a " + "\n";
                    slSQL = slSQL + " where a.eje_prefijo = MTCEMP01.eje_prefijo " + "\n";
                    slSQL = slSQL + " and a.gpo_banco = MTCEMP01.gpo_banco " + "\n";
                    slSQL = slSQL + " and a.emp_num = MTCEMP01.emp_num " + "\n";
                    slSQL = slSQL + " and a.eje_num > 0) - " + "\n";
                    slSQL = slSQL + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c, MTCTHS01 d " + "\n";
                    slSQL = slSQL + " where c.eje_prefijo = MTCEMP01.eje_prefijo " + "\n";
                    slSQL = slSQL + " and c.gpo_banco = MTCEMP01.gpo_banco " + "\n";
                    slSQL = slSQL + " and c.emp_num = MTCEMP01.emp_num " + "\n";
                    slSQL = slSQL + " and c.eje_num > 0 and " + "\n";
                    slSQL = slSQL + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and " + "\n";
                    slSQL = slSQL + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) " + "\n";
                    //        slSQL = slSQL & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) " & vbNewLine

                    slSQL = slSQL + "   WHERE " + "\n";
                    slSQL = slSQL + "       eje_prefijo = " + msPrefijo + "\n";
                    slSQL = slSQL + "   AND gpo_banco = " + msBanco + "\n";
                    slSQL = slSQL + "   AND emp_num = " + msEmpresa + "\n" + "\n";

                    //Elimina el registro una vez actualizado
                    slSQL = slSQL + "   DELETE FROM MTCLIM01 " + "\n";
                    slSQL = slSQL + "   WHERE " + "\n";
                    slSQL = slSQL + "       eje_prefijo = " + msPrefijo + "\n";
                    slSQL = slSQL + "   AND gpo_banco = " + msBanco + "\n";
                    slSQL = slSQL + "   AND lim_cta_bnx = '" + msCuenta + "'" + "\n";
                    slSQL = slSQL + "COMMIT TRAN" + "\n";
                    object tempRefParam = lira;
                    cnnpConexion.Execute(slSQL, out tempRefParam, -1);
                    //ais-1396 chidalgo
                    result = Convert.ToInt32(tempRefParam);
                }
                else
                {
                    MessageBox.Show("No se ha establecido una sesión válida en la Base de Datos.", "Cuenta - Actualiza M111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception excep)
            {
                if (!ErrActualizaM111)
                {
                    throw excep;
                }
                //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                throw new Exception("Migration Exception: 'Resume' not supported");
                if (ErrActualizaM111)
                {

                    CRSGeneral.prObtenError("ActualizaM111");
                }
            }
            return result;
        }

        public int EliminaMakerI(ADODB.Connection cnnpConexion)
        {
            int result = 0;
            string slSQL = String.Empty;
            int lira = 0;
            if (MessageBox.Show("¿Esta seguro de Eliminar la Solicitud de cambio de Límite de Crédito para la cuenta " + msCuenta + "?", "Eliminar Solicitud de Cambio de Límite de Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cnnpConexion.State != 0)
                {
                    //Elimina el registro de la tabla de MTCLIM01
                    slSQL = "SET ROWCOUNT 1" + "\n";
                    slSQL = slSQL + "BEGIN TRAN" + "\n";
                    slSQL = slSQL + "   DELETE FROM MTCLIM01 " + "\n";
                    slSQL = slSQL + "   WHERE " + "\n";
                    slSQL = slSQL + "       eje_prefijo = " + msPrefijo + "\n";
                    slSQL = slSQL + "   AND gpo_banco = " + msBanco + "\n";
                    slSQL = slSQL + "   AND lim_cta_bnx = '" + msCuenta + "'" + "\n";
                    slSQL = slSQL + "COMMIT TRAN" + "\n";
                    slSQL = slSQL + "SET ROWCOUNT 1" + "\n";
                    object tempRefParam = lira;
                    cnnpConexion.Execute(slSQL, out tempRefParam, -1);
                    result = lira;
                }
                else
                {
                    MessageBox.Show("No se ha establecido una sesión válida en la Base de Datos.", "Elimina Solicitud de Límite de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return result;
        }
        //------ FIN PROCEDIMIENTOS Y FUNCIONES PARA ACTUALIZAR EL LÍMITE DE Crédito ----------------------------------------------------------'


        //------ PROCEDIMIENTOS Y FUNCIONES PARA MANEJO DE MAKER CHECKER ----------------------------------------------------------'
        private void mckrCambiaLimCred_Checker(ref  bool bpAutorizado, ref  prySeguridadS041.enuOperaciones epOperacionSol, ref  prySeguridadS041.clsMaker mkrpMaker)
        {
            //Prepara la transacción a enviarse

            //    If (msPrefijo = 4943 And msBanco = 88) Or (msPrefijo = 4859 And msBanco = 42) Then
            //    Else
            ADODB.Connection tempRefParam = VBSQL.gConn[10];
            if (ValidaAcumuladoEmpresaI(ref tempRefParam) == 0)
            {
                return;
            }
            //    End If
            //ConsultaCuentaS111(trnTransacciones.trnActualizaLimite);
            ActualizaS111(trnTransacciones.trnActualizaLimite);
            //Se evalua respuesta
            if (ConsultaS111I() == 0)
            {
                if (mcLimiteCredNuevo == mcLimiteCredS111)
                {
                    //Se actualiza la Base de datos
                    if (ActualizaM111(VBSQL.gConn[10]) != 0)
                    {
                        //Si todo se efectúa correctamente, entonces se Notifica
                        bpAutorizado = true;
                        mprLog("Se actualizó el límite de la cuenta " + msCuenta + " a " + StringsHelper.Format(mcLimiteCredS111, "$ ###,###,###.##") + " propuesto por " + mkrpMaker.NominaMakerS + " el día " + mkrpMaker.FechaMaker);
                    }
                    else
                    {
                        mprLog("No se actualizó el límite de la cuenta " + msCuenta + " en M111." + "\n" + "Intentelo nuevamente más tarde.");
                    }
                }
            }
            else
            {
                mprLog("No se actualizó el límite de Crédito debido a:");
                mprLog("Respuesta S111: " + this.mensajeRespuestaS);
            }


        }


        private void mckrCambiaLimCred_PostChecker(ref  bool bpAutorizado, ref  prySeguridadS041.topTipoOperMakerChecker ipOperacionRealizada, ref  prySeguridadS041.clsMaker mkrMaker, ref  prySeguridadS041.enuOperaciones epOperacionSol)
        {
            if (!bpAutorizado)
            {
                MessageBox.Show("Usted no puede completar el proceso de Cambio de Límite de Crédito" + "\n" +
                    "para la cuenta " + msCuenta + "\n" + "Verifique que su SOEID no corresponda al del maker (" +
                    mkrMaker.NominaMakerS + ")" + "\n" +
                    "O bien verifique que tiene facultades en seguridad de la información.",
                    "Autorización Límite de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mckrCambiaLimCred_PreparaDatos()
        {
            mckrCambiaLimCred.FuncionMakerCheckerI = 2;
            mckrCambiaLimCred.RolMakerCheckerI = 2;
            mckrCambiaLimCred.UsuarioUSR = Seguridad.usugUsuario;
        }

        private void mckrCambiaLimCred_Validate(ref  short ipContinuarFlujo)
        {
            ipContinuarFlujo = 0;
            if (bfncValidaCuenta(true))
            {
                if (mcnsS111 == null)
                {
                    MessageBox.Show("La conexión al sistema S111 no es válida.", "Actualiza Límite de Crédito.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ipContinuarFlujo = 1;
                }
            }
        }


        private void mmkrCambiaLimCred_Maker(ref  ADODB.Connection cnnpConexion, ref  bool bpContinuar)
        {
            bool ErrMaker = false;
            string slSQL = String.Empty;
            int ilRecs = 0;
            ADODB.Recordset rst = null;
            DialogResult elReemplazar = (DialogResult)0;
            try
            {
                ErrMaker = true;


                //investigar que exista el registro, en caso de existir presentar un mensaje al usuario, para que no proceda el cambio
                //en caso de que el usuario desee puede continuar con el cambio,

                slSQL = "SELECT  lim_cred_ant," + "\r\n";
                slSQL = slSQL + " lim_cred_post," + "\r\n";
                slSQL = slSQL + " lim_usu_maker," + "\r\n";
                slSQL = slSQL + " lim_nom_maker," + "\r\n";
                slSQL = slSQL + " convert(datetime, convert(varchar, lim_fecha_maker) + ' ' + substring(replicate('0',  4 - char_length(convert(varchar, lim_hora_maker))) + convert(varchar, lim_hora_maker),1,2) + ':' + substring(replicate('0',  4 - char_length(convert(varchar,lim_hora_maker))) + convert(varchar, lim_hora_maker),3,2)) as lim_fecha_maker ";
                slSQL = slSQL + " FROM MTCLIM01" + "\r\n";
                slSQL = slSQL + " WHERE " + "\n";
                slSQL = slSQL + "     eje_prefijo = " + msPrefijo + "\n";
                slSQL = slSQL + " AND gpo_banco = " + msBanco + "\n";
                slSQL = slSQL + " AND lim_cta_bnx = '" + msCuenta + "'" + "\n";
                rst = new ADODB.Recordset();
                rst.Open(slSQL, cnnpConexion, ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                if (!(rst.BOF && rst.EOF))
                {
                    elReemplazar = MessageBox.Show("El cambio de Límite de Crédito para la cuenta " + msCuenta +
                                   "\r\n" + "fué solicitado por " + Convert.ToString(rst.Fields["lim_nom_maker"].Value) +
                                   "\r\n" + "de " + StringsHelper.Format(rst.Fields["lim_cred_ant"].Value, "Currency") + " a " + StringsHelper.Format(rst.Fields["lim_cred_post"].Value, "Currency") +
                                   "\r\n" + "el día " + Convert.ToString(rst.Fields["lim_fecha_maker"].Value) + "\r\n" + "\r\n" + "¿Desea que la solicitud de Límite de Crédito se actualice a " + StringsHelper.Format(mcLimiteCredNuevo, "Currency") + "?", "Solicitud de Cambio de Límite de Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (elReemplazar == System.Windows.Forms.DialogResult.Yes)
                    {
                        slSQL = "declare @limite_cred_ant int" + "\r\n";
                        slSQL = slSQL + "SELECT" + "\r\n";
                        slSQL = slSQL + "    @limite_cred_ant = eje_limcred" + "\r\n";
                        slSQL = slSQL + " From MTCEJE01" + "\r\n";
                        slSQL = slSQL + " Where emp_num = " + msEmpresa + "\r\n";
                        slSQL = slSQL + " And eje_num = " + msEjecutivo + "\r\n";
                        slSQL = slSQL + " And eje_prefijo = " + msPrefijo + "\r\n";
                        slSQL = slSQL + " And gpo_banco = " + msBanco + "\r\n";
                        slSQL = slSQL + " UPDATE MTCLIM01 SET" + "\r\n";
                        slSQL = slSQL + " lim_cred_ant = @limite_cred_ant," + "\r\n";
                        slSQL = slSQL + " lim_cred_post = " + mcLimiteCredNuevo.ToString() + "," + "\r\n";
                        slSQL = slSQL + " lim_usu_maker = '" + mmkrCambiaLimCred.UsuarioUSU.NominaS + "', " + "\r\n";
                        slSQL = slSQL + " lim_nom_maker = '" + mmkrCambiaLimCred.UsuarioUSU.NombreS + "', " + "\r\n";
                        slSQL = slSQL + " lim_fecha_maker = convert(int, convert(varchar, getdate(),112)), " + "\r\n";
                        slSQL = slSQL + " lim_hora_maker = convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))" + "\r\n";
                        slSQL = slSQL + " WHERE " + "\n";
                        slSQL = slSQL + "     eje_prefijo = " + msPrefijo + "\n";
                        slSQL = slSQL + " AND gpo_banco = " + msBanco + "\n";
                        slSQL = slSQL + " AND lim_cta_bnx = '" + msCuenta + "'" + "\n";
                    }
                    else
                    {
                        bpContinuar = false;
                        rst.Close();
                        rst = null;
                        return;
                    }
                }
                else
                {
                    slSQL = "declare @limite_cred_ant int" + "\r\n";
                    slSQL = slSQL + "SELECT" + "\r\n";
                    slSQL = slSQL + "    @limite_cred_ant = eje_limcred" + "\r\n";
                    slSQL = slSQL + "From MTCEJE01" + "\r\n";
                    slSQL = slSQL + "Where emp_num = " + msEmpresa + "\r\n";
                    slSQL = slSQL + "And eje_num = " + msEjecutivo + "\r\n";
                    slSQL = slSQL + "And eje_prefijo = " + msPrefijo + "\r\n";
                    slSQL = slSQL + "And gpo_banco = " + msBanco + "\r\n";
                    slSQL = slSQL + "INSERT INTO MTCLIM01 (" + "\r\n";
                    slSQL = slSQL + "eje_prefijo," + "\r\n";
                    slSQL = slSQL + "gpo_banco," + "\r\n";
                    slSQL = slSQL + "lim_cta_bnx," + "\r\n";
                    slSQL = slSQL + "lim_cred_ant," + "\r\n";
                    slSQL = slSQL + "lim_cred_post," + "\r\n";
                    slSQL = slSQL + "lim_usu_maker," + "\r\n";
                    slSQL = slSQL + "lim_nom_maker," + "\r\n";
                    slSQL = slSQL + "lim_fecha_maker," + "\r\n";
                    slSQL = slSQL + "lim_hora_maker)" + "\r\n";
                    slSQL = slSQL + "Values (" + "\r\n";
                    slSQL = slSQL + msPrefijo + ", " + "\r\n";
                    slSQL = slSQL + msBanco + ", " + "\r\n";
                    slSQL = slSQL + "'" + msCuenta + "', " + "\r\n";
                    slSQL = slSQL + "@limite_cred_ant, " + "\r\n";
                    slSQL = slSQL + mcLimiteCredNuevo.ToString() + ", " + "\r\n";
                    slSQL = slSQL + "'" + mmkrCambiaLimCred.UsuarioUSU.NominaS + "', " + "\r\n";
                    slSQL = slSQL + "'" + mmkrCambiaLimCred.UsuarioUSU.NombreS + "', " + "\r\n";
                    slSQL = slSQL + "convert(int, convert(varchar, getdate(),112)), " + "\r\n";
                    slSQL = slSQL + "convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))";
                    slSQL = slSQL + ")";
                }
                rst.Close();
                rst = null;

                object tempRefParam = ilRecs;
                cnnpConexion.Execute(slSQL, out tempRefParam, -1);
                ilRecs = (int)tempRefParam;
                bpContinuar = ilRecs > 0;
            }
            catch (Exception excep)
            {
                if (!ErrMaker)
                {
                    throw excep;
                }
                //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                throw new Exception("Migration Exception: 'Resume' not supported");
                if (ErrMaker)
                {

                    CRSGeneral.prObtenError("CambiaLimCred:Maker");
                }
            }

        }

        private void mmkrCambiaLimCred_Validate(ref  bool bpContinuar)
        {
            if (msCuenta.Length != 16)
            {
                bpContinuar = false;
            }
            else
            {
                bpContinuar = mdlADO.fncVerificaConexionM111b();
            }
            if (mcLimiteCredNuevo == 0 || ((double)mcLimiteCredNuevo) % LIM_CRED_BASE > 0)
            {
                MessageBox.Show("El Nuevo Límite de Crédito debe ser múltiplo de " + StringsHelper.Format(LIM_CRED_BASE, "Currency") + "." + "\r\n" + "La solicitud de cambio de Límite de Crédito para la cuenta" + "\r\n" + msCuenta + " al límite de Crédito" + StringsHelper.Format(mcLimiteCredNuevo, "Currency") + "\r\n" + " no se procesará.", "Cambio de Límite de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bpContinuar = false;
            }
        }
        //------ FIN PROCEDIMIENTOS Y FUNCIONES PARA MANEJO DE MAKER CHECKER -------------------------------------------------------'


        //------ INICIO DE VALIDACIÓN DE LIMITE EMPRESARIAL ------------------------------------------------------------------------'
        private int ValidaAcumuladoEmpresaI(ref  ADODB.Connection cnnpConexion)
        {
            int result = 0;
            bool ErrValidaLimiteCorp = false;
            ADODB.Recordset rst = null;
            string slSQL = String.Empty;
            try
            {
                ErrValidaLimiteCorp = true;

                result = 0;
                //    slSQL = "select " & vbNewLine
                //    slSQL = slSQL & " emp_cred_tot," & vbNewLine
                //    slSQL = slSQL & " (select isnull(sum(eje_limcred),0) from  MTCEJE01"
                //    slSQL = slSQL & " where MTCEJE01.eje_prefijo = MTCEMP01.eje_prefijo"
                //    slSQL = slSQL & " and MTCEJE01.gpo_banco = MTCEMP01.gpo_banco"
                //    slSQL = slSQL & " and MTCEJE01.emp_num = MTCEMP01.emp_num"
                //    slSQL = slSQL & " and MTCEJE01.eje_num > 0) as emp_acum_cred, " & vbNewLine
                //    slSQL = slSQL & " isnull((emp_cred_tot - " & "(select isnull(sum(eje_limcred),0) from  MTCEJE01"
                //    slSQL = slSQL & " where MTCEJE01.eje_prefijo = MTCEMP01.eje_prefijo"
                //    slSQL = slSQL & " and MTCEJE01.gpo_banco = MTCEMP01.gpo_banco"
                //    slSQL = slSQL & " and MTCEJE01.emp_num = MTCEMP01.emp_num"
                //    slSQL = slSQL & " and MTCEJE01.eje_num > 0)    "
                //    slSQL = slSQL & " ),0) as emp_cred_disp" & vbNewLine
                //    slSQL = slSQL & " From MTCEMP01" & vbNewLine
                //    slSQL = slSQL & " Where" & vbNewLine
                //    slSQL = slSQL & "     eje_prefijo = " & msPrefijo & vbNewLine
                //    slSQL = slSQL & " AND gpo_banco = " & msBanco & vbNewLine
                //    slSQL = slSQL & " AND emp_num = " & msEmpresa & vbNewLine
                // Modif. 18/Jun/2007 Calc Lim Real
                slSQL = "select " + "\n";
                slSQL = slSQL + " emp_cred_tot," + "\n";
                slSQL = slSQL + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a " + "\n";
                slSQL = slSQL + " where a.eje_prefijo = MTCEMP01.eje_prefijo " + "\n";
                slSQL = slSQL + " and a.gpo_banco = MTCEMP01.gpo_banco " + "\n";
                slSQL = slSQL + " and a.emp_num = MTCEMP01.emp_num " + "\n";
                slSQL = slSQL + " and a.eje_num > 0) - " + "\n";
                slSQL = slSQL + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c,MTCTHS01 d " + "\n";
                slSQL = slSQL + " where c.eje_prefijo = MTCEMP01.eje_prefijo " + "\n";
                slSQL = slSQL + " and c.gpo_banco = MTCEMP01.gpo_banco " + "\n";
                slSQL = slSQL + " and c.emp_num = MTCEMP01.emp_num " + "\n";
                slSQL = slSQL + " and c.eje_num > 0 and " + "\n";
                slSQL = slSQL + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and " + "\n";
                slSQL = slSQL + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) as emp_acum_cred, " + "\n";
                //    slSQL = slSQL & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred, " & vbNewLine

                slSQL = slSQL + " isnull((emp_cred_tot - " + "\n";
                slSQL = slSQL + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a " + "\n";
                slSQL = slSQL + " where a.eje_prefijo = MTCEMP01.eje_prefijo " + "\n";
                slSQL = slSQL + " and a.gpo_banco = MTCEMP01.gpo_banco " + "\n";
                slSQL = slSQL + " and a.emp_num = MTCEMP01.emp_num " + "\n";
                slSQL = slSQL + " and a.eje_num > 0) - " + "\n";
                slSQL = slSQL + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c,MTCTHS01 d " + "\n";
                slSQL = slSQL + " where c.eje_prefijo = MTCEMP01.eje_prefijo " + "\n";
                slSQL = slSQL + " and c.gpo_banco = MTCEMP01.gpo_banco " + "\n";
                slSQL = slSQL + " and c.emp_num = MTCEMP01.emp_num " + "\n";
                slSQL = slSQL + " and c.eje_num > 0 and " + "\n";
                slSQL = slSQL + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and " + "\n";
                slSQL = slSQL + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) " + "\n";
                //    slSQL = slSQL & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) " & vbNewLine

                slSQL = slSQL + " ),0) as emp_cred_disp" + "\n";
                slSQL = slSQL + " From MTCEMP01" + "\n";
                slSQL = slSQL + " Where" + "\n";
                slSQL = slSQL + "     eje_prefijo = " + msPrefijo + "\n";
                slSQL = slSQL + " AND gpo_banco = " + msBanco + "\n";
                slSQL = slSQL + " AND emp_num = " + msEmpresa + "\n";

                rst = new ADODB.Recordset();
                rst.Open(slSQL, cnnpConexion, ADODB.CursorTypeEnum.adOpenUnspecified, ADODB.LockTypeEnum.adLockUnspecified, -1);
                if (!(rst.BOF && rst.EOF))
                {
                    //        If (rst.Fields("emp_cred_disp") + mcLimiteCredS111 - mcLimiteCredNuevo) >= 0 Then
                    //       6/Jul/2007 Acepta cualquier disminución de crédito
                    if (((((decimal)(Convert.ToDouble(rst.Fields["emp_cred_disp"].Value) + ((double)mcLimiteCredS111))) - mcLimiteCredNuevo) >= 0) || (mcLimiteCredS111 > mcLimiteCredNuevo))
                    {
                        result = 1;
                    }
                    else
                    {
                        MessageBox.Show("Se ha excedido la línea de Crédito de la Empresa." + "\r\n" + "La empresa dispone actualmente de " + StringsHelper.Format(rst.Fields["emp_cred_disp"].Value, "Currency") + " disponibles de " + StringsHelper.Format(rst.Fields["emp_cred_tot"].Value, "Currency") + "\r\n" + "No se actualizará el límite de crédito de la cuenta " + msCuenta + ".", "Validación de Línea de Crédito Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mprLog("Se ha excedido la línea de Crédito de la Empresa." + "\r\n" + "La empresa dispone actualmente de " + StringsHelper.Format(rst.Fields["emp_cred_disp"].Value, "Currency") + " disponibles de " + StringsHelper.Format(rst.Fields["emp_cred_tot"].Value, "Currency") + "\r\n" + "No se actualizará el límite de crédito de la cuenta " + msCuenta + ".");
                        result = 0;
                    }
                }
                rst.Close();
                rst = null;
            }
            catch (Exception excep)
            {
                if (!ErrValidaLimiteCorp)
                {
                    throw excep;
                }
                //UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted properly. A throw statement was generated instead.
                throw new Exception("Migration Exception: 'Resume' not supported");
                if (ErrValidaLimiteCorp)
                {

                    CRSGeneral.prObtenError("ValidaLimiteCorp");
                }
            }
            return result;
        }
    }
}