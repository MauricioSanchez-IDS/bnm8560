using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class frmEjecutivo
        : System.Windows.Forms.Form
    {


        //*****************************************************************************
        //**                                                                         **
        //**                     EISSA / Banamex - Sistemas                          **
        //**                                                                         **
        //**       -----------------------------------------------------------       **
        //**                                                                         **
        //**       Descripción: Realiza las Altas de los Ejecutivos                  **
        //**                    (Llama a la forma                                    **
        //**                                                                         **
        //**                                                                         **
        //**       Responsables: Jaime Paz Uribe / Marcos Garcia Cruz                **
        //**                                                                         **
        //**       Fecha de Modificación:                                            **
        //**                                                                         **
        //**             NOTA: Esta forma esta hecha en Visual Basic 6.0             **
        //**                                                                         **
        //*****************************************************************************

        //Variable para ver la modificacion
        string smModificacion = String.Empty;
        string smCuentaReferencia = String.Empty;

        private clsSucursal ObjSucursal;
        private Collection ColSucursal;

        //Variables para las conexiones
        /* private OLERut.Conexion _cnxConexionRut = null;
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

        //Variable global del objeto datos ejecutivo
        clsDatosEjecutivo gdteEjecutivo = null;

        //Variable global del objeto datos ejecutivo para la consulta del Ejecutivo
        clsDatosEjecutivo gdteEjeExists = null;

        //Variable para el dialogo
        clsDialogo gdlgDialogoS016 = null;
        clsDialogo gdlgDialogoS111 = null;

        private bool fncVerificaCreditoAcumuladoB()
        {
            bool result = false;
            bool Handler = false;
            //Lo que hace esta funcion es devolver verdadero en caso de que el credito acumulado de
            //la empresa más el crédito del ejecutivo no sobrepasen o igualen el crédito total de la
            //empresa.
            int llEmpCredTot = 0;
            int llEmpCredAcum = 0;
            try
            {
                Handler = true;

                //this.Cursor = Cursors.WaitCursor;

                //CORVAR.pszgblsql = "select";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_cred_tot,";
                ////pszgblsql = pszgblsql & " emp_acum_cred"
                //// Modif. 18/Jun/2007 Calc Lim Real
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " ((select isnull(sum(a.eje_limcred),0) from MTCEJE01 a ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " where a.eje_prefijo = MTCEMP01.eje_prefijo ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.gpo_banco = MTCEMP01.gpo_banco ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.emp_num = MTCEMP01.emp_num ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and a.eje_num > 0) - ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " (select distinct isnull(sum(c.eje_limcred),0) from MTCEJE01 c,MTCTHS01 d ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " where c.eje_prefijo = MTCEMP01.eje_prefijo ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.gpo_banco = MTCEMP01.gpo_banco ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.emp_num = MTCEMP01.emp_num ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and c.eje_num > 0 and ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_prefijo=d.eje_prefijo and c.gpo_banco=d.gpo_banco and c.emp_num=d.emp_num and ";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) as emp_acum_cred ";
                ////pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred "

                //CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();

                //'Se obtiene el crédito total y acumulado de la empresa
                //CORVAR.pszgblsql = "select emp_cred_tot, emp_acum_cred from MTCEMP01 where emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString() +
                CORVAR.pszgblsql = "select emp_cred_tot, emp_acum_cred from MTCEMP01 where emp_num = " + CORVAR.lgblEmpCve.ToString() +

                    " and eje_prefijo=" + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString() + " and gpo_banco=" + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        llEmpCredTot = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                        llEmpCredAcum = Convert.ToInt32(MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 2), 0));
                    };
                    //EISSA 01.09.2004 - Cambio para realizar una excepción de un BIN
                    //If gdteEjecutivo.EjeProductoPRD.PrefijoL = 4943 And gdteEjecutivo.EjeProductoPRD.BancoL = 88 Then
                    //   If bfncExcepcionCredito = True Then
                    //      fncVerificaCreditoAcumuladoB = True
                    //   Else
                    if (!CRSParametros.bfncExcepcionCredito())
                    {
                        if ((llEmpCredAcum + gdteEjecutivo.EjeLimCredL) > llEmpCredTot)
                        {
                            result = false;
                            MessageBox.Show("Se ha sobrepasado el crédito de la Empresa." + "\r\n" +
                                            "Crédito dispuesto: " + Conversion.Str(mdlEjecutivo.lmEmpCredTot - mdlEjecutivo.lmEmpCredAcum), AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    result = false;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                this.Cursor = Cursors.Default;
            }
            catch (Exception excep)
            {
                if (!Handler)
                {
                    throw excep;
                }
                string tempRefParam = "FrmEjecutivo:FncVerificaCreditoAcumuladoB";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
                return result;
                if (Handler)
                {

                    string tempRefParam2 = "FnVerificaCreditoAcumuladoB";
                    if (MdlCambioMasivo.fnGetError(ref tempRefParam2))
                    {
                        throw new Exception("Migration Exception: 'Resume' not supported");
                    }
                }
            }
            return result;
        }
        private bool fncAltaEjecutivoB()
        {
            bool result = false;
            clsReenvioTarjetahabientes lEjeReenvio = null;
            clsAltaTarjetahabiente lAltaEje = null;
            string slTablaTemporal = String.Empty;
            try
            {

                if (mdlParametros.ES_DEBUG)
                {
                    MdlCambioMasivo.MsgInfo("Se va a validar el consecutivo");
                }
                if (fncValidarConsecutivoB())
                {

                    if (fncVerificaCreditoAcumuladoB())
                    {
                        if (mdlParametros.ES_DEBUG)
                        {
                            MdlCambioMasivo.MsgInfo("Iniciando la clase clsReenvioTarjetahabientes");
                        }
                        lEjeReenvio = new clsReenvioTarjetahabientes();
                        if (mdlParametros.ES_DEBUG)
                        {
                            MdlCambioMasivo.MsgInfo("Iniciando la clase clsAltaTarjetahabiente");
                        }
                        lAltaEje = new clsAltaTarjetahabiente();
                        if (mdlParametros.ES_DEBUG)
                        {
                            MdlCambioMasivo.MsgInfo("Estableciendo: lAltaEje.EjegdteEjecutivo = gdteEjecutivo");
                        }
                        lAltaEje.EjegdteEjecutivo = gdteEjecutivo;

                        slTablaTemporal = "MTCIND02";
                        if (mdlParametros.ES_DEBUG)
                        {
                            MdlCambioMasivo.MsgInfo("Estableciendo: lAltaEje.Temporal ");
                        }
                        lAltaEje.Temporal = slTablaTemporal;
                        if (mdlParametros.ES_DEBUG)
                        {
                            MdlCambioMasivo.MsgInfo("lEjeReenvio.mObjetoAlta = lAltaEje");
                        }

                        lEjeReenvio.mObjetoAlta = lAltaEje;
                        if (mdlParametros.ES_DEBUG)
                        {
                            MdlCambioMasivo.MsgInfo("lEjeReenvio.EjeStatusS = 0");
                        }
                        gdteEjecutivo.EjeEmpNumL = CORVAR.lgblEmpCve;
                        //lEjeReenvio.EjeStatusS = "0";
                        lEjeReenvio.EjeStatusSComdrv = "0";

                        if (mdlParametros.ES_DEBUG)
                        {
                            MdlCambioMasivo.MsgInfo("fncAltaEjecutivoB = Not lEjeReenvio.Resultado");
                        }
                        result = !lEjeReenvio.resultado;
                        lAltaEje = null;
                        lEjeReenvio = null;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }

                this.Cursor = Cursors.Default;

            }
            catch
            {

                string tempRefParam = "FrmEjecutivo:FncAltaEjecutivoB";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }

            return result;
        }

        private bool fncActualizaConsecutivoB()
        {

            bool result = false;
            try
            {

                this.Cursor = Cursors.WaitCursor;

                CORVAR.pszgblsql = "update MTCEMP01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_con_eje = " + ((gdteEjecutivo.EjeNumL + 1).ToString()) + ",";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    result = true;
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el consecutivo de ejecutivo de la empresa: " + gdteEjecutivo.EjeEmpNumL.ToString(), "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                    this.Cursor = Cursors.Default;
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
                    this.Cursor = Cursors.Default;
                    return result;
                }
            }

            return result;
        }

        private void prActualizaEstatus(int lpEstatus)
        {

            try
            {

                this.Cursor = Cursors.WaitCursor;

                switch (lpEstatus)
                {
                    case 3:
                    case 4:
                    case 12:
                        CORVAR.pszgblsql = "update MTCIND02";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_num = " + gdteEjecutivo.EjeNumL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " ,eje_digit = " + gdteEjecutivo.EjeDigitI.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " ,eje_status_reg = " + lpEstatus.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";

                        break;
                    default:
                        CORVAR.pszgblsql = "update MTCIND02";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set eje_status_reg = " + lpEstatus.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_nom_gra = '" + gdteEjecutivo.EjeNomGrabaS + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_rfc = '" + gdteEjecutivo.EjeRfcRFC.RFCS + "'";
                        break;
                }

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    MessageBox.Show("No se actualizo el estatus del Ejecutivo en la tabla de Respaldo", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (ActualizaEstatus)", e);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }

        }

        private bool fncValidaInfB()
        {

            bool result = false;
            try
            {

                this.Cursor = Cursors.WaitCursor;

                if (gdteEjecutivo.EjeNomS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "NOMBRE DEL EJECUTIVO";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeNomGrabaS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "NOMBRE DE GRABACIÓN";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeRfcRFC.RFCS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "RFC";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeLimCredL.ToString().Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "LIMITE DE CREDITO INCORRECTO";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeSexoS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "SEXO";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeDomEnvioDMC.DomicilioS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "CALLE Y NÚMERO";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeDomEnvioDMC.ColoniaS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "COLONIA";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeDomEnvioDMC.PoblacionS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "POBLACIÓN";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.EstadoS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "ESTADO";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeDomEnvioDMC.CPL.ToString().Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "CÓDIGO POSTAL";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else if (gdteEjecutivo.EjeTelOfiS.Trim() == "")
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "TEL. OFICINA";
                    this.Cursor = Cursors.Default;
                    return result;
                    //FSWB NellyRdz 20070221 Se agregan Atencion A y Persona en validación de vacíos
                    //*** FSWB NR
                    //    ElseIf Trim(gdteEjecutivo.EjeAtencionA) = "" Then
                    //        fncValidaInfB = False
                    //        smValidaInf = "ATENCION A"
                    //        Screen.MousePointer = vbDefault
                    //        Exit Function
                    //    ElseIf Trim(gdteEjecutivo.EjePersona) = "" Then
                    //        fncValidaInfB = False
                    //        smValidaInf = "PERSONA"
                    //        Screen.MousePointer = vbDefault
                    //        Exit Function
                    //    '*** FSWB NR
                }
                else if (ObjSucursal == null)
                {
                    result = false;
                    mdlEjecutivo.smValidaInf = "SUCURSAL PROMOTORA";
                    this.Cursor = Cursors.Default;
                    return result;
                }
                result = true;

                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (ValidaInf)", e);
                    result = false;
                    this.Cursor = Cursors.Default;
                    return result;
                }
            }

            return result;
        }

        private bool fncValidarConsecutivoB()
        {

            bool result = false;
            int llConsecutivo = 0;
            int llConsecutivoTope = 0;

            try
            {

                this.Cursor = Cursors.WaitCursor;

                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_con_eje";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                //CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        llConsecutivo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                        llConsecutivoTope = StringsHelper.IntValue(new string('9', gdteEjecutivo.EjeProductoPRD.LongitudEjecutivoI));
                    };
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                if (llConsecutivo >= llConsecutivoTope)
                {
                    result = false;
                    MessageBox.Show("Se deberá crear una nueva empresa para los siguientes ejecutivos." + "\r\n" +
                                    "Se ha llegado al límite de " + (llConsecutivoTope + 1).ToString() + " tarjetahabientes.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    return result;
                }
                else
                {
                    result = true;
                    this.Cursor = Cursors.Default;
                    return result;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo ValidarConsecutivo", e);
                    result = false;
                    this.Cursor = Cursors.Default;
                    return result;
                }
            }

            return result;
        }

        private void prLlenaCentroC(ComboBox ctrlpControl)
        {

            int llRegistros = 0;
            string slCentroC = String.Empty;
            string slCentroName = String.Empty;
            int llCont = 0;
            ComboBox cmblCombo = null;

            try
            {

                cmblCombo = ctrlpControl;
                cmblCombo.Items.Clear();

                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_id,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " unit_name";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCUNI01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        slCentroC = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                        slCentroName = VBSQL.SqlData(CORVAR.hgblConexion, 2).Trim();
                        cmblCombo.Items.Add(slCentroC + new String(' ', 3) + slCentroName);
                    };
                    cmblCombo.SelectedIndex = 0;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            catch (Exception e)
            {

                if (Information.Err().Number == 91)
                {
                    throw new Exception("Migration Exception: 'Resume Next' not supported");
                }
                else
                {
                    CRSGeneral.prObtenError("frmEjecutivo (LlenaCentroC)", e);
                    return;
                }
            }

        }

        private bool fncObtenValoresEjecutivoB(mdlEjecutivo.enuTipoConsultaEjecutivo ipTipoConsulta)
        {

            bool result = false;
            int ilIndice = 0;

            try
            {

                if (ipTipoConsulta == mdlEjecutivo.enuTipoConsultaEjecutivo.tcneConsultaAlta)
                {

                    CORVAR.pszgblsql = "select";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_tipo_envio";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_calle";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_col";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_pob";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_edo";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_envio_cp";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_sector";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_skip_payment";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tabla_mcc";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tipo_fac ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tipo_producto ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_dia_corte";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tipo_bloqueo";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_atn_a";  //FSWB 20070221 NR Se incluyen campos Atencion A y Persona 
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tipo_persona";  //FSWB NR 20070221 
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", ejx_numero";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + gdteEjecutivo.EjeProductoPRD.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + gdteEjecutivo.EjeProductoPRD.BancoL.ToString();
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + gdteEjecutivo.EjeEmpNumL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblEmpCve.ToString();

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {

                        while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                        {
                            gdteEjecutivo.EjeEmpTipoEnvioS = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                            gdteEjecutivo.EjeDomEnvioDMC.DomicilioS = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                            gdteEjecutivo.EjeDomEnvioDMC.ColoniaS = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                            gdteEjecutivo.EjeDomEnvioDMC.PoblacionS = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                            ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(VBSQL.SqlData(CORVAR.hgblConexion, 5));
                            if (ilIndice != 0)
                            {
                                gdteEjecutivo.EjeDomEnvioDMC.EstadoEST = mdlParametros.gcestEstado[ilIndice];
                            } //FSWB NR 20070227 SE condicionó a que si es cero no ejecut set para evitar error
                            gdteEjecutivo.EjeDomEnvioDMC.CPL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 6));
                            gdteEjecutivo.EjeEmpSectorI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 7));
                            gdteEjecutivo.EjeSkipPaymentL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 8));
                            gdteEjecutivo.EjeTablaMCCL = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 9));
                            gdteEjecutivo.EjeEmpTipoFactS = VBSQL.SqlData(CORVAR.hgblConexion, 10);
                            gdteEjecutivo.EjeEmpTipoProductoS = VBSQL.SqlData(CORVAR.hgblConexion, 11);
                            gdteEjecutivo.EjeDiaCorteI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 12));
                            gdteEjecutivo.EjeTipoBloqueoI = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 13));
                            gdteEjecutivo.EjeAtencionA = VBSQL.SqlData(CORVAR.hgblConexion, 14).Trim(); //FSWB 20070221 NR Se incluyen campos Atencion A y Persona

                            //FSWB NR 20070329
                            if ((VBSQL.SqlData(CORVAR.hgblConexion, 15)) == "")
                            {
                                gdteEjecutivo.EjePersona = 2; //Persona Física
                            }
                            else
                            {
                                gdteEjecutivo.EjePersona = (Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 15))); //FSWB NR 20070221
                            }

                            if (MskNomina1.ClipText.Trim() != "")
                            { CRSGeneral.iEjeBnx = int.Parse(MskNomina1.ClipText); }
                            else
                            { CRSGeneral.iEjeBnx = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 16))); }

                            result = true;
                        };
                    }
                    else
                    {
                        result = false;
                        //MessageBox.Show("No se puede realizar el alta de Ejecutivos de la Empresa: " + gdteEjecutivo.EjeEmpNumL.ToString() + "." + "\r\n" +
                        MessageBox.Show("No se puede realizar el alta de Ejecutivos de la Empresa: " + CORVAR.lgblEmpCve.ToString() + "." + "\r\n" +

                                        "Porque los datos de la Empresa son Incorrecto", "Tarjeta Corporativa Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return result;
                    }

                }
                else if (ipTipoConsulta == mdlEjecutivo.enuTipoConsultaEjecutivo.tcneConsultaCambio)
                {
                }
                else if (ipTipoConsulta == mdlEjecutivo.enuTipoConsultaEjecutivo.tcneConsultaConsulta)
                {
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
                    CRSGeneral.prObtenError("frmEjecutivo (ObtenValoresEjecutivo)", e);
                    return result;
                }
            }

            return result;
        }

        private void prLlenaSubActividad(int ipSector)
        {

            try
            {

                switch (ipSector)
                {
                    case 1:
                        gdteEjecutivo.EjeActiSubactiS = mdlEmpresa.ctesSectorIndustrial.Substring(0, Math.Min(mdlEmpresa.ctesSectorIndustrial.Length, 2)).Trim();
                        break;
                    case 2:
                        gdteEjecutivo.EjeActiSubactiS = mdlEmpresa.ctesSectorComercial.Substring(0, Math.Min(mdlEmpresa.ctesSectorComercial.Length, 2)).Trim();
                        break;
                    case 3:
                        gdteEjecutivo.EjeActiSubactiS = mdlEmpresa.ctesSectorServicios.Substring(0, Math.Min(mdlEmpresa.ctesSectorServicios.Length, 2)).Trim();
                        break;
                    case 4:
                        gdteEjecutivo.EjeActiSubactiS = mdlEmpresa.ctesSectorFinanciero.Substring(0, Math.Min(mdlEmpresa.ctesSectorFinanciero.Length, 2)).Trim();
                        break;
                    case 5:
                        gdteEjecutivo.EjeActiSubactiS = mdlEmpresa.ctesSectorPublico.Substring(0, Math.Min(mdlEmpresa.ctesSectorPublico.Length, 2)).Trim();
                        break;
                    case 6:
                        gdteEjecutivo.EjeActiSubactiS = mdlEmpresa.ctesSectorGobFed.Substring(0, Math.Min(mdlEmpresa.ctesSectorGobFed.Length, 2)).Trim();
                        break;
                    case 7:
                        gdteEjecutivo.EjeActiSubactiS = mdlEmpresa.ctesSectorGobEst.Substring(0, Math.Min(mdlEmpresa.ctesSectorGobEst.Length, 2)).Trim();
                        break;
                    case 8:
                        gdteEjecutivo.EjeActiSubactiS = mdlEmpresa.ctesSectorOtros.Substring(0, Math.Min(mdlEmpresa.ctesSectorOtros.Length, 2)).Trim();
                        break;
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
                    CRSGeneral.prObtenError("frmEjecutivo (LlenaSubActividad)", e);
                    return;
                }
            }

        }
        /*  
           private bool fncVerificaConsultaB(mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
           {

               bool result = false;
               int ilResConS111 = 0;
               string slConS111 = String.Empty;
               string slCausaS111 = String.Empty;
               string slConsulta = String.Empty;
               string slCadena1 = String.Empty;
               string slCadena2 = String.Empty;
               string slCadena3 = String.Empty;
               string slFolio = String.Empty;
               string slCampo = String.Empty;
               int ilRespuestaEnvio = 0;
               string slFecAlta = String.Empty;
               string slFecModificacion = String.Empty;
               string slValidacion = String.Empty;
               string slRespuestaS016 = String.Empty;
               string slNombreGraba = String.Empty;
               string slRFC = String.Empty;
               string slDialogoConsulta = String.Empty;
               string slRespMensaje = String.Empty;
               string slDialogo = String.Empty;
               int ilcont = 0;


               try
               {

                   this.Cursor = Cursors.WaitCursor;

                   if (ipTipoAltaSistema == mdlEjecutivo.enuTipoAltaSistema.tasAltaS111)
                   { //***** CONSULTA S111 *****

                       gdlgDialogoS111 = new clsDialogo();

                       gdlgDialogoS111.prGeneraDlg(gdteEjecutivo, clsDialogo.enuTipoDialogo.tConsEjecutivoS111);

                       slDialogo = gdlgDialogoS111.DialogoS;
                       gdlgDialogoS111 = null;

                       string tempRefParam = "S753-CONALTAS";
                       ilRespuestaEnvio = cnxConexionRut.RutReadWrite(ref slDialogo, ref tempRefParam);
                       Application.DoEvents();

                       cnxConexionRut.Termina_Conexion();

                       slRespMensaje = mdlParametros.fncValorOmisionV(slDialogo, "");

                       if (ilRespuestaEnvio != 0)
                       {
                           prActualizaEstatus(7);
                           MessageBox.Show("Error en el envio de la informacion.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           result = false;
                           this.Cursor = Cursors.Default;
                           return result;
                       }
                       else
                       {
                           slCadena1 = Strings.Mid(slRespMensaje, 1243, 151).Trim();
                           slCadena2 = Strings.Mid(slRespMensaje, 38, 371).Trim();
                           slCadena3 = Strings.Mid(slRespMensaje, 1608, 31).Trim();

                           gdteEjeExists = null;
                           gdteEjeExists = new clsDatosEjecutivo();

                           gdteEjeExists.EjeNomGrabaS = Strings.Mid(slCadena1, 1, 26).Trim();
                           gdteEjeExists.EjeDomEnvioDMC.DomicilioS = Strings.Mid(slCadena1, 46, 35).Trim();
                           gdteEjeExists.EjeDomEnvioDMC.ColoniaS = Strings.Mid(slCadena1, 81, 25).Trim();
                           gdteEjeExists.EjeDomEnvioDMC.PoblacionS = Strings.Mid(slCadena1, 106, 21).Trim();

                           if (Strings.Mid(slCadena1, 138, 1).Trim() == "1")
                           {
                               gdteEjeExists.EjeTipoCuentaS = "       Básica       ";
                           }
                           else if (Strings.Mid(slCadena1, 138, 1).Trim() == "2")
                           {
                               gdteEjeExists.EjeTipoCuentaS = "      Adicional     ";
                           }
                           else if (Strings.Mid(slCadena1, 138, 1).Trim() == "3")
                           {
                               gdteEjeExists.EjeTipoCuentaS = "Básica con Adicional";
                           }

                           gdteEjeExists.EjeSucTransS = Strings.Mid(slCadena1, 139, 4).Trim();
                           gdteEjeExists.EjeSexoS = Strings.Mid(slCadena1, 145, 1).Trim();
                           slCausaS111 = Strings.Mid(slCadena3, 1, 19).Trim();
                           slFecAlta = Strings.Mid(slCadena3, 20, 6).Trim();
                           slFecModificacion = Strings.Mid(slCadena3, 26, 6).Trim();
                           slValidacion = fncValidaDatosS(mdlEjecutivo.enuTipoAltaSistema.tasAltaS111);

                           if (slValidacion == "")
                           {
                               result = true;
                               this.Cursor = Cursors.Default;
                               return result;
                           }
                           else
                           {
                               MessageBox.Show("Hay Inconsistencia de Datos en el S111 en el campo " + slValidacion, "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               result = false;
                               this.Cursor = Cursors.Default;
                               return result;
                           }
                       }
                   }
                   else
                   {
                   }

                   this.Cursor = Cursors.Default;
               }
               catch (Exception e)
               {

                   if (Information.Err().Number == 91)
                   {
                       throw new Exception("Migration Exception: 'Resume Next' not supported");
                   }
                   else
                   {
                       CRSGeneral.prObtenError("frmEjecutivo (VerificaConsultaS111)", e);
                       result = false;
                       this.Cursor = Cursors.Default;
                       return result;
                   }
               }

               return result;
           }
           */

        private string fncValidaDatosS(mdlEjecutivo.enuTipoAltaSistema ipTipoAltaSistema)
        {

            string result = String.Empty;
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
                    result = "Nombre";
                }
                else if (gdteEjeExists.EjeDomEnvioDMC.DomicilioS != gdteEjecutivo.EjeDomEnvioDMC.DomicilioS)
                {
                    result = "Calle";
                }
                else if (gdteEjeExists.EjeDomEnvioDMC.ColoniaS != gdteEjecutivo.EjeDomEnvioDMC.ColoniaS)
                {
                    result = "Colonia";
                }
                else if (gdteEjeExists.EjeDomEnvioDMC.PoblacionS != gdteEjecutivo.EjeDomEnvioDMC.PoblacionS)
                {
                    result = "Población";
                }
                else if (gdteEjeExists.EjeSexoS != gdteEjecutivo.EjeSexoS)
                {
                    result = "Sexo";
                }
                else if (gdteEjeExists.EjeTipoCuentaS != "       Básica       ")
                {
                    result = "Tipo de Cuenta";
                }
                else if (gdteEjeExists.EjeSucTransS != gdteEjecutivo.EjeSucTransS)
                {
                    result = "Sucursal";
                }
            }

            return result;
        }

        private string fncObtenErrorDialogoS(int ipError, mdlConexiones.enuTipoSistema ipTipoSistema)
        {

            string slSistema = String.Empty;
            string slMensaje = String.Empty;

            try
            {

                if (((int)ipTipoSistema) == ((int)mdlConexiones.enuTipoSistema.tsistSistemaTandem))
                {
                    slSistema = CRSDialogo.cteTandem;
                }
                else if (((int)ipTipoSistema) == ((int)mdlConexiones.enuTipoSistema.tsistSistemaS111))
                {
                    slSistema = CRSDialogo.cteS111;
                }
                else if (((int)ipTipoSistema) == ((int)mdlConexiones.enuTipoSistema.tsistSistemaS016))
                {
                    slSistema = CRSDialogo.cteS016;
                }


                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " err_desc";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCERR01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where err_cve = " + ipError.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and err_origen = '" + slSistema + "'";

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        slMensaje = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();
                    }
                }
                else
                {
                    slMensaje = "No se encuentra registrado este Error en la base de datos.";
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


                return mdlParametros.fncValorOmisionV(slMensaje, "Error Desconocido");
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("frmEjecutivo (ObtenErrorDialogo)", e);
                return "Error Desconocido";
            }
        }


        private bool fncVerificaNombreB(ref  string spEjeNom)
        {

            bool result = false;
            FixedLengthString slCaracter = new FixedLengthString(1);
            int ilPosComa = 0;
            int ilPosDiag = 0;

            try
            {

                bool blComa = false;
                bool blDiagonal = false;

                for (int ilcont = 1; ilcont <= spEjeNom.Length; ilcont++)
                {
                    slCaracter.Value = Strings.Mid(spEjeNom, ilcont, 1);
                    if (slCaracter.Value == ",")
                    {
                        blComa = true;
                    }
                    if (blComa && slCaracter.Value == "/")
                    {
                        blDiagonal = true;
                        break;
                    }
                }

                if (blDiagonal)
                {
                    ilPosComa = (spEjeNom.IndexOf(',') + 1);
                    ilPosDiag = (spEjeNom.IndexOf('/') + 1);
                    if (ilPosDiag - ilPosComa <= 1)
                    {
                        spEjeNom = Strings.Mid(spEjeNom, 1, ilPosComa - 1).Trim() + ",/" + Strings.Mid(spEjeNom, ilPosDiag + 1).Trim();
                    }
                    else
                    {
                        spEjeNom = Strings.Mid(spEjeNom, 1, ilPosComa - 1).Trim() + "," + Strings.Mid(spEjeNom, ilPosComa + 1, ilPosDiag - ilPosComa - 1).Trim() + "/" + Strings.Mid(spEjeNom, ilPosDiag + 1).Trim();
                    }
                }
                frmEjecutivo.DefInstance.txtEjecutivos[3].Text = spEjeNom;
                result = blDiagonal;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        private void prVerificaDatos()
        {

            try
            {

                for (int ilContador = 0; ilContador <= 13; ilContador++)
                {
                    if (ilContador == 5)
                    { }
                    else
                        if (txtEjecutivos[ilContador].Text == "")
                        {
                            switch (ilContador)
                            {
                                //case 5:  //Cuenta Contable 
                                //    gdteEjecutivo.EjeCtaContableS = "";
                                //    break;
                                case 6:  //Correo Electronico 
                                    gdteEjecutivo.EjeEmailS = "";
                                    break;
                                case 10:  //Domicilio Particular (Calle y Numero) 
                                    gdteEjecutivo.EjeDomPartDMC.DomicilioS = "";
                                    break;
                                case 11:  //Domicilio Particular (Colonia) 
                                    gdteEjecutivo.EjeDomPartDMC.ColoniaS = "";
                                    break;
                                case 12:  //Domicilio Particular (Pob/Del/Mun) 
                                    gdteEjecutivo.EjeDomPartDMC.PoblacionS = "";
                                    break;
                                case 13:  //Domicilio Particular (Ciudad) 
                                    gdteEjecutivo.EjeDomPartDMC.CiudadS = "";
                                    break;
                            }
                        }
                }

                for (int ilContador = 0; ilContador <= 12; ilContador++)
                {
                    if (mskEjecutivos[ilContador].CtlText == "")
                    {
                        switch (ilContador)
                        {
                            case 1:  //Numero de Nomina 
                                gdteEjecutivo.EjeNumNomS = "";
                                break;
                            case 2:  //Sueldo 
                                gdteEjecutivo.EjeSueldoL = 0;
                                break;
                            case 8:  //Domicilio Envio (Extension) 
                                gdteEjecutivo.EjeExtensionS = "0";
                                break;
                            case 9:  //Domicilio Envio (Fax) 
                                gdteEjecutivo.EjeFaxS = "0";
                                break;
                            case 10:  //Domicilio Particular (CP) 
                                gdteEjecutivo.EjeDomPartDMC.CPL = 0;
                                break;
                            case 11:  //Domicilio Particular (Telefono Domicilio) 
                                gdteEjecutivo.EjeTelDomS = "";
                                break;
                            case 12:  //MCC 
                                gdteEjecutivo.EjeTablaMCCL = 0;
                                break;
                        }
                    }
                }

                for (int ilContador = 0; ilContador <= 8; ilContador++)
                {
                    switch (ilContador)
                    {
                        case 0:  //Sexo (Femenino) 
                            if (optEjecutivos[ilContador].Checked)
                            {
                                gdteEjecutivo.EjeSexoS = "F";
                            }
                            break;
                        case 1:  //Sexo (Masculino) 
                            if (optEjecutivos[ilContador].Checked)
                            {
                                gdteEjecutivo.EjeSexoS = "M";
                            }
                            break;
                        case 2:  //Tipo de Facturacion (Corporativo) 
                            if (optEjecutivos[ilContador].Checked)
                            {
                                gdteEjecutivo.EjeTipoFactS = mdlEmpresa.ctesEjeCorporativo;
                            }
                            break;
                        //case 3:  //Tipo de Facturacion (Individual) 
                        //    if (optEjecutivos[ilContador].Checked)
                        //    {
                        //        gdteEjecutivo.EjeTipoFactS = mdlEmpresa.ctesEjeIndividual;
                        //    }
                        //    break;
                        case 4:  //Nacionalidad (Mexicana) 
                            if (optEjecutivos[ilContador].Checked)
                            {
                                gdteEjecutivo.EjeNacionalidadS = mdlEmpresa.ctesMexicana;
                            }
                            break;
                        case 5:  //Nacionalidad (Extranjera) 
                            if (optEjecutivos[ilContador].Checked)
                            {
                                gdteEjecutivo.EjeNacionalidadS = mdlEmpresa.ctesExtranjera;
                            }
                            break;
                        //case 6:  //Tipo de Bloqueo (No maneja Bloqueo) 
                        //    if (optEjecutivos[ilContador].Checked)
                        //    {
                        //        gdteEjecutivo.EjeTipoBloqueoI = mdlEmpresa.cteiNoManejaBloqueo;
                        //    }
                        //    break;
                        //case 7:  //Tipo de Bloqueo (Bloqueo por MCC) 
                        //    if (optEjecutivos[ilContador].Checked)
                        //    {
                        //        gdteEjecutivo.EjeTipoBloqueoI = mdlEmpresa.cteiBloqueoPorMCC;
                        //    }
                        //    break;
                        //case 8:  //Tipo de Bloqueo (Bloqueo por No. de Negocio) 
                        //    if (optEjecutivos[ilContador].Checked)
                        //    {
                        //        gdteEjecutivo.EjeTipoBloqueoI = mdlEmpresa.cteiBloqueoPorNegocio;
                        //    }
                        //    break;
                    }
                }

                //gdteEjecutivo.EjeAtencionA = txtAtencionA.Text;
                //gdteEjecutivo.EjePersona = StringsHelper.IntValue(Strings.Mid(ID_MEM_PERSONA.Text, 1, 1));
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void prLimpiaPantalla()
        {


            try
            {

                for (int ilContador = 2; ilContador <= 13; ilContador++)
                {
                    if (ilContador == 5)
                    { }
                    else
                        txtEjecutivos[ilContador].Text = "";
                }

                for (int ilContador = 0; ilContador <= 12; ilContador++)
                {
                    if (ilContador == 0)
                    {
                        mskEjecutivos[ilContador].SelStart = 0;
                        mskEjecutivos[ilContador].SelLength = Strings.Len(mskEjecutivos[ilContador].CtlText);
                        mskEjecutivos[ilContador].SelText = "";
                        mskEjecutivos[ilContador].Mask = "????-######-&&&";
                    }
                    //AIS-BUG 4474 FSABORIO
                    try { mskEjecutivos[ilContador].CtlText = ""; }
                    catch { }
                }

                for (int ilContador = 0; ilContador <= 2; ilContador++)
                {
                    if (ilContador == 0)
                    {
                        prLlenaCentroC(cmbEjecutivos[0]);
                        //cmbEjecutivos[ilContador].SelectedIndex = 0;
                    }
                    else
                    {
                        cmbEjecutivos[ilContador].SelectedIndex = -1;
                    }
                }

                gdteEjecutivo = null;
                gdteEjecutivo = new clsDatosEjecutivo();
                gdlgDialogoS016 = null;
                gdlgDialogoS016 = new clsDialogo();
                gdlgDialogoS111 = null;
                gdlgDialogoS111 = new clsDialogo();

                gdteEjecutivo.EjeEmpNumL = CORVAR.lgblEmpCve;
                gdteEjecutivo.EjeCuentaReferenciaS = smCuentaReferencia;
                //gdteEjecutivo.EjeSucPromS = mdlEjecutivo.fncSucursalS(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, CORVAR.lgblEmpCve);
                //gdteEjecutivo.EjeSucTransS = gdteEjecutivo.EjeSucPromS;
                gdteEjecutivo.EjeSucPromS = gdteEjecutivo.EjeSucPromS;
                gdteEjecutivo.EjeSucTransS = "342";
                gdteEjecutivo.EjeEstatusS = "T";


                //txtAtencionA.Text = ""; //FSWB NR 20070221 Limpia campos en pantalla
                //ID_MEM_PERSONA.SelectedIndex = 1; //FSWB NR 20070221 Default Persona Física para ejecutivos

                if (fncObtenValoresEjecutivoB(mdlEjecutivo.enuTipoConsultaEjecutivo.tcneConsultaAlta))
                {
                    prLlenarPantalla();
                }
                else
                {
                    return;
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void prLlenarPantalla()
        {

            int ilContador = 0;

            try
            {

                if (!FnLeeEjeBnmx())
                {
                    MessageBox.Show("El Catálogo de ejecutivos banamex no pudo ser leido");
                    this.Cursor = Cursors.Default;
                    return;
                }

                txtEjecutivos[0].Text = CORVAR.pszgblEmpDesc.Trim();
                //txtEjecutivos[1].Text = StringsHelper.Format(gdteEjecutivo.EjeEmpNumL, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS);
                txtEjecutivos[1].Text = StringsHelper.Format(CORVAR.lgblEmpCve, gdteEjecutivo.EjeProductoPRD.MascaraEmpresaS);
                txtEjecutivos[7].Text = gdteEjecutivo.EjeDomEnvioDMC.DomicilioS.Trim();
                txtEjecutivos[8].Text = gdteEjecutivo.EjeDomEnvioDMC.ColoniaS.Trim();
                txtEjecutivos[9].Text = gdteEjecutivo.EjeDomEnvioDMC.PoblacionS.Trim();
                cmbEjecutivos[1].Text = gdteEjecutivo.EjeDomEnvioDMC.EstadoEST.EstadoS.Trim();
                mskEjecutivos[4].CtlText = "100";
                mskEjecutivos[5].CtlText = gdteEjecutivo.EjeDiaCorteI.ToString().Trim();
                mskEjecutivos[6].CtlText = gdteEjecutivo.EjeDomEnvioDMC.CPL.ToString().Trim();
                mskEjecutivos[12].CtlText = gdteEjecutivo.EjeTablaMCCL.ToString().Trim();
                //UPGRADE_WARNING: (6021) Casting 'double' to Enum may cause different behaviour.
                //AIS-1173 NGONZALEZ
                //chkEjecutivos[2].CheckState = (CheckState)Convert.ToInt32(Math.Floor((double)gdteEjecutivo.EjeSkipPaymentL));
                prLlenaSubActividad(gdteEjecutivo.EjeEmpSectorI);

                //txtAtencionA.Text = gdteEjecutivo.EjeAtencionA; //FSWB NR 20070227 Llena campos con valor de consulta
                //if (gdteEjecutivo.EjePersona == 1)
                //{
                //    ID_MEM_PERSONA.SelectedIndex = 0;
                //} //Moral    'FSWB NR 20070227
                //if (gdteEjecutivo.EjePersona == 2)
                //{
                //    ID_MEM_PERSONA.SelectedIndex = 1;
                //} //Fisica   'FSWB NR 20070227
                //if (gdteEjecutivo.EjePersona == 3)
                //{
                //    ID_MEM_PERSONA.SelectedIndex = 2;
                //} //Fisica c/ Act. Empresarial   'FSWB NR 20070227


                if (gdteEjecutivo.EjeEmpTipoProductoS == mdlEmpresa.ctesDistributionLine)
                {
                    chkEjecutivos[0].Enabled = false;
                    chkEjecutivos[1].Enabled = false;
                }
                else
                {
                    chkEjecutivos[0].Enabled = true;
                    chkEjecutivos[1].Enabled = true;
                }

                if (gdteEjecutivo.EjeEmpTipoFactS == mdlParametros.ctesCorporativo)
                {
                    optEjecutivos[2].Checked = true;
                    //chkEjecutivos[2].Enabled = false;
                }
                else if (gdteEjecutivo.EjeEmpTipoFactS == mdlParametros.ctesIndividual)
                {
                    optEjecutivos[3].Checked = true;
                }

                fraEjecutivos[5].Enabled = false;

                if (gdteEjecutivo.EjeEmpTipoEnvioS == mdlParametros.ctesEmpresa)
                {
                    txtEjecutivos[7].Enabled = false;
                    txtEjecutivos[8].Enabled = false;
                    txtEjecutivos[9].Enabled = false;
                    cmbEjecutivos[1].Enabled = false;
                    mskEjecutivos[6].Enabled = false;
                }

                //if (gdteEjecutivo.EjeTipoBloqueoI == mdlEmpresa.cteiNoManejaBloqueo)
                //{
                //    optEjecutivos[6].Checked = true;
                //}
                //else if (gdteEjecutivo.EjeTipoBloqueoI == mdlEmpresa.cteiBloqueoPorMCC)
                //{
                //    optEjecutivos[7].Checked = true;
                //}
                //else if (gdteEjecutivo.EjeTipoBloqueoI == mdlEmpresa.cteiBloqueoPorNegocio)
                //{
                //    optEjecutivos[8].Checked = true;
                //}

                //if (CORVAR.igblPref == 4859 && CORVAR.igblBanco == 43)
                //{
                //    chkEjecutivos[0].Enabled = true;
                //    chkEjecutivos[1].Enabled = true;
                //}

                if (CRSGeneral.iEjeBnx != 0)
                { FnBoolBuscaComboEjeBnx(CRSGeneral.iEjeBnx); }
                else
                { CboEjecutivoBnx1.SelectedIndex = -1; }

                //ID_MEM_PERSONA.Enabled = true; //FSWB Nelly Rdz 20070221 Habilita control de Persona y Atn A
                //txtAtencionA.Enabled = true; //FSWB Nelly Rdz 20070221
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void prOrdenaTab(int ipIndice)
        {

            try
            {

                switch (ipIndice)
                {
                    case 0:  //Tab "Datos Generales" 
                        if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
                        {
                            txtEjecutivos[2].Focus();
                        }
                        tabEjecutivos.SelectedIndex = ipIndice;
                        break;
                    case 1:  //Tab "Domicilio" 
                        if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
                        {
                            mskEjecutivos[7].Focus();
                        }
                        tabEjecutivos.SelectedIndex = ipIndice;
                        break;
                    case 2:  //Tab "Datos Adicionales" 
                        if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
                        {
                            mskEjecutivos[12].Focus();
                        }
                        tabEjecutivos.SelectedIndex = ipIndice;
                        break;
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void prImprimirEjecutivo()
        {

            try
            {

                PrinterHelper.Printer.FontName = "Courier New";

                PrinterHelper.Printer.FontBold = true;

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print(new String(' ', 24) + Text);
                PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', Strings.Len(Text)));
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("EMPRESA                : " + txtEjecutivos[1].Text);
                PrinterHelper.Printer.Print("NOMBRE                 : " + txtEjecutivos[0].Text);

                PrinterHelper.Printer.FontBold = false;
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("NOMBRE EJECUTIVO       : " + txtEjecutivos[2].Text);
                PrinterHelper.Printer.Print("RFC                    : " + mskEjecutivos[0].CtlText);
                PrinterHelper.Printer.Print("SUELDO                 : " + mskEjecutivos[2].CtlText);
                PrinterHelper.Printer.Print("NOMINA                 : " + mskEjecutivos[1].CtlText);
                PrinterHelper.Printer.Print("CENTRO DE COSTOS       : " + cmbEjecutivos[0].Text);
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("CUENTA                 : " + txtEjecutivos[4].Text);
                PrinterHelper.Printer.Print("MODIFICACION           : " + smModificacion);
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("NOMBRE GRABACION       : " + txtEjecutivos[3].Text);
                PrinterHelper.Printer.Print("CALLE Y NUMERO         : " + txtEjecutivos[7].Text);
                PrinterHelper.Printer.Print("COLONIA                : " + txtEjecutivos[8].Text);
                PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : " + txtEjecutivos[9].Text);
                PrinterHelper.Printer.Print("C.P.                   : " + mskEjecutivos[1].CtlText);
                PrinterHelper.Printer.Print("Z.P.                   : " + "");
                PrinterHelper.Printer.Print("TELEFONO OFICINA       : " + mskEjecutivos[7].CtlText);
                PrinterHelper.Printer.Print("EXTENSION              : " + mskEjecutivos[8].CtlText);
                PrinterHelper.Printer.Print("FAX                    : " + mskEjecutivos[9].CtlText);
                PrinterHelper.Printer.Print("TELEFONO DOMICILIO     : " + mskEjecutivos[11].CtlText);
                PrinterHelper.Printer.Print("LIMITE DE CREDITO      : " + mskEjecutivos[3].CtlText);
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("CORTE                  : " + mskEjecutivos[5].CtlText);
                PrinterHelper.Printer.Print("SUCURSAL               : " + gdteEjecutivo.EjeSucTransS);
                PrinterHelper.Printer.Print("REGION                 : " + gdteEjecutivo.EjeRegNumL.ToString());
                PrinterHelper.Printer.Print("TIPO CUENTA            : " + gdteEjecutivo.EjeTipoCuentaS);
                PrinterHelper.Printer.Print();

                PrinterHelper.Printer.Print("PROCEDENCIA            : " + gdteEjecutivo.EjeOrigenS);
                PrinterHelper.Printer.Print("ACTIVIDAD              : " + mdlParametros.ctesActividad);
                PrinterHelper.Printer.Print("SUBACTIVIDAD           : " + gdteEjecutivo.EjeActiSubactiS);
                PrinterHelper.Printer.Print("INST.ESP.              : " + "");

                //FSWB NR 20070222 Se incluyen campos Atencion A y Persona
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("ATENCION A             : " + gdteEjecutivo.EjeAtencionA);
                PrinterHelper.Printer.Print("PERSONA                : " + gdteEjecutivo.EjePersona.ToString());

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.EndDoc();
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }


        }

        private void chkEjecutivos_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(chkEjecutivos, eventSender);

            switch (Index)
            {
                case 0:  //Plastico y Pin (Genera Plastico) 
                    if (chkEjecutivos[Index].CheckState == CheckState.Unchecked)
                    {
                        chkEjecutivos[1].CheckState = CheckState.Unchecked;
                        chkEjecutivos[1].Enabled = false;
                        //chkEjecutivos[3].Enabled = true;
                    }
                    else
                    {
                        chkEjecutivos[1].Enabled = true;
                        //chkEjecutivos[3].CheckState = CheckState.Unchecked;
                        //chkEjecutivos[3].Enabled = false;
                    }

                    if (chkEjecutivos[Index].CheckState == CheckState.Checked && chkEjecutivos[1].CheckState == CheckState.Checked)
                    {
                        gdteEjecutivo.EjeGenPinPlaI = mdlEmpresa.cteiSiPlasticoSiPIN;
                    }
                    else if (chkEjecutivos[Index].CheckState == CheckState.Unchecked && chkEjecutivos[1].CheckState == CheckState.Unchecked)
                    {
                        gdteEjecutivo.EjeGenPinPlaI = mdlEmpresa.cteiNoPlasticoNoPIN;
                    }
                    else if (chkEjecutivos[Index].CheckState == CheckState.Checked && chkEjecutivos[1].CheckState == CheckState.Unchecked)
                    {
                        gdteEjecutivo.EjeGenPinPlaI = mdlEmpresa.cteiSiPlasticoNoPIN;
                    }
                    break;
                case 1:  //Plastico y Pin (Genera Pin) 
                    if (chkEjecutivos[0].CheckState == CheckState.Checked && chkEjecutivos[Index].CheckState == CheckState.Checked)
                    {
                        gdteEjecutivo.EjeGenPinPlaI = mdlEmpresa.cteiSiPlasticoSiPIN;
                    }
                    else if (chkEjecutivos[0].CheckState == CheckState.Unchecked && chkEjecutivos[Index].CheckState == CheckState.Unchecked)
                    {
                        gdteEjecutivo.EjeGenPinPlaI = mdlEmpresa.cteiNoPlasticoNoPIN;
                    }
                    else if (chkEjecutivos[0].CheckState == CheckState.Checked && chkEjecutivos[Index].CheckState == CheckState.Unchecked)
                    {
                        gdteEjecutivo.EjeGenPinPlaI = mdlEmpresa.cteiSiPlasticoNoPIN;
                    }
                    break;
                case 2:  //Skip Payment 
                    gdteEjecutivo.EjeSkipPaymentL = (int)chkEjecutivos[Index].CheckState;
                    break;
                case 3:  //Cuenta Control 
                    if (chkEjecutivos[Index].CheckState == CheckState.Unchecked)
                    {
                        gdteEjecutivo.EjeIndCtaCtrlS = mdlEmpresa.ctesNoCuentaControl;
                        chkEjecutivos[0].Enabled = true;
                        chkEjecutivos[1].Enabled = true;
                    }
                    else
                    {
                        gdteEjecutivo.EjeIndCtaCtrlS = mdlEmpresa.ctesSiCuentaControl;
                        chkEjecutivos[0].CheckState = CheckState.Unchecked;
                        chkEjecutivos[0].Enabled = false;
                        chkEjecutivos[1].CheckState = CheckState.Unchecked;
                        chkEjecutivos[1].Enabled = false;
                    }
                    break;
            }

        }

        private void cmbEjecutivos_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(cmbEjecutivos, eventSender);


            switch (Index)
            {
                case 0:  //Centro de Costos 
                    for (int ilContador = 1; ilContador <= 15; ilContador++)
                    {
                        if (Strings.Mid(cmbEjecutivos[Index].Text, ilContador, 1).Trim() == "")
                        {
                            gdteEjecutivo.EjeCentroCostS = cmbEjecutivos[Index].Text.Substring(0, Math.Min(cmbEjecutivos[Index].Text.Length, ilContador)).Trim();
                            break;
                        }
                    }
                    break;
                case 1:  //Domicilio Envio (Estado) 
                    break;
                case 2:  //Domicilio Particular (Estado) 
                    break;
            }

        }

        private void cmbEjecutivos_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            //AIS-1595 fsaborio
            if (this.Disposing)
                return;

            bool Cancel = eventArgs.Cancel;
            int Index = Array.IndexOf(cmbEjecutivos, eventSender);
            int ilIndice = 0;


            switch (Index)
            {
                case 0:  //Centro de Costos 
                    break;
                case 1:  //Domicilio Envio (Estado) 
                    if (cmbEjecutivos[Index].SelectedIndex < 0)
                    {
                        MessageBox.Show("Seleccione un estado para continuar.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cancel = true;
                    }
                    else
                    {
                        ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(cmbEjecutivos[Index].Text.Trim());
                        gdteEjecutivo.EjeDomEnvioDMC.EstadoEST = mdlParametros.gcestEstado[ilIndice];
                    }
                    break;
                case 2:  //Domicilio Particular (Estado) 
                    if (cmbEjecutivos[Index].SelectedIndex < 0)
                    {
                        MessageBox.Show("Seleccione un estado para continuar.", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cancel = true;
                    }
                    else
                    {
                        ilIndice = mdlParametros.gcestEstado.fncBuscaEstadoI(cmbEjecutivos[Index].Text.Trim());
                        gdteEjecutivo.EjeDomPartDMC.EstadoEST = mdlParametros.gcestEstado[ilIndice];
                    }
                    break;
            }

            eventArgs.Cancel = Cancel;
        }

        private void cmdEjecutivos_Click(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(cmdEjecutivos, eventSender);
            //AIS-1134 NGONZALEZ
            cmbEjecutivos_SelectedIndexChanged(cmbEjecutivos[0], new EventArgs());

            try
            {
                if (Index == 0)
                { //Aceptar
                    if (this.Tag.ToString() == mdlParametros.ctesTagAlta)
                    {
                        prOrdenaTab(0);
                        prVerificaDatos();
                        if (fncValidaInfB())
                        {
                            if (MessageBox.Show("Confirme el alta de ejecutivo por favor.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                if (mdlParametros.ES_DEBUG)
                                {
                                    MdlCambioMasivo.MsgInfo("Entrando a la funcion fncAltaEjecutivoB");
                                }

                                //gdteEjecutivo.EjeSucPromS = mdlEjecutivo.fncSucursalS(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, Convert.ToInt32(Conversion.Val(this.txtEjecutivos[1].Text)));
                                //gdteEjecutivo.EjeSucTransS = gdteEjecutivo.EjeSucPromS;
                                gdteEjecutivo.EjeSucPromS = Convert.ToString(ObjSucursal.IdSucursal);
                                gdteEjecutivo.EjeSucTransS = "342";
                                gdteEjecutivo.EjeEjecBnx = VB6.GetItemData(CboEjecutivoBnx1, CboEjecutivoBnx1.SelectedIndex);

                                if (fncAltaEjecutivoB())
                                {
                                    if (mdlParametros.ES_DEBUG)
                                    {
                                        MdlCambioMasivo.MsgInfo("Saliendo de la fncAltaEjecutivoB " +
                                                                "\r" + "Va a llamar a limpia pantalla");
                                    }
                                    MdlCambioMasivo.MsgInfo("El ejecutivo Número: " + gdteEjecutivo.EjeNumL.ToString() + "\r\n" +
                                                            gdteEjecutivo.EjeNomS + "\r\n" + " Cuenta:" + gdteEjecutivo.EjeCuentaS + "\r\n" + "Se dio de alta Exitosamente");
                                    prLimpiaPantalla();
                                    if (mdlParametros.ES_DEBUG)
                                    {
                                        MdlCambioMasivo.MsgInfo("Sale de Limpia Pantalla");
                                    }
                                }
                                this.Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Falta por capturar el campo: " + mdlEjecutivo.smValidaInf, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else if (this.Tag.ToString() == mdlParametros.ctesTagCambio)
                    {
                    }
                    else if (this.Tag.ToString() == mdlParametros.ctesTagConsulta)
                    {
                    }

                }
                else if (Index == 1)
                {  //Cancelar
                    this.Close();

                }
                else if (Index == 2)
                {  //Imprimir
                    prImprimirEjecutivo();
                }
                if (mdlParametros.ES_DEBUG)
                {
                    MdlCambioMasivo.MsgInfo("Saliendo del evento click");
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(cmdEjecutivos_Click)", e);
            }
        }

        public bool flag = false;

        private void frmEjecutivo_Activated(Object eventSender, EventArgs eventArgs)
        {
            //AIS-1595 fsaborio
            if (this.Disposing)
                return;

            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                try
                {

                    if (gdteEjecutivo.EjeCuentaReferenciaS.Trim() == "")
                    {
                        MessageBox.Show("No existe ninguna cuenta asociada a esta empresa." + "\r\n" + "Por lo tanto no se pueden hacer altas de ejecutivos." + "\r\n" + "Para hacer alta de un ejecutivo, cerciorese de tener " + "\r\n" + "correctamente el alta de esta empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        if (this.Tag.ToString() == mdlParametros.ctesTagAlta)
                        {
                            chkEjecutivos[0].CheckState = CheckState.Checked;
                            chkEjecutivos[1].CheckState = CheckState.Checked;
                            optEjecutivos[0].Checked = true;
                            optEjecutivos[4].Checked = true;
                            //optEjecutivos[6].Checked = true;
                            if (fncObtenValoresEjecutivoB(mdlEjecutivo.enuTipoConsultaEjecutivo.tcneConsultaAlta))
                            {
                                prLlenarPantalla();
                            }
                            else
                            {
                                return;
                            }

                        }
                        else if (this.Tag.ToString() == mdlParametros.ctesTagCambio)
                        {
                        }
                        else if (this.Tag.ToString() == mdlParametros.ctesTagConsulta)
                        {
                        }
                    }
                    flag = true;
                    return;
                }
                catch (Exception e)
                {

                    if (Information.Err().Number == 91)
                    {
                        throw new Exception("Migration Exception: 'Resume Next' not supported");
                    }
                    else
                    {
                        CRSGeneral.prObtenError("frmEjecutivo (Form_Activate)", e);
                        return;
                    }
                }

            }
        }

        private void frmEjecutivo_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            if (KeyAscii == ((int)Keys.Escape))
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
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);

            gdteEjecutivo = new clsDatosEjecutivo();
            gdteEjecutivo.EjeEmpNumL = CORVAR.lgblEmpCve;

            smCuentaReferencia = mdlEjecutivo.fncCuentaPadreS(gdteEjecutivo.EjeProductoPRD.PrefijoL, gdteEjecutivo.EjeProductoPRD.BancoL, gdteEjecutivo.EjeEmpNumL);
            gdteEjecutivo.EjeCuentaReferenciaS = smCuentaReferencia;

            prLlenaCentroC(cmbEjecutivos[0]);
            mdlCatalogos.prLlenaCombo(mdlParametros.gcestEstado, cmbEjecutivos[1]);
            mdlCatalogos.prLlenaCombo(mdlParametros.gcestEstado, cmbEjecutivos[2]);

            //***
            //FSWB NR 20070221 Inicializa campos Atencion A y Persona
            //ID_MEM_PERSONA.Items.Clear();
            //ID_MEM_PERSONA.Items.Add("1" + new String(' ', 3) + "MORAL");
            //ID_MEM_PERSONA.Items.Add("2" + new String(' ', 3) + "FISICA");
            //ID_MEM_PERSONA.Items.Add("3" + new String(' ', 3) + "FISICA C/ACT. EMPRESARIAL");
            //***

            prOrdenaTab(0);
            if (StringsHelper.DoubleValue(Strings.Mid(CORVAR.igblPref.ToString(), 1, 1)) == 4)
            {
                //Valida si la cuenta es de Mastercard entonces el nombre de grabacion es
                // de un máximo de 26 caracteres
                txtEjecutivos[3].MaxLength = 21;
            }
            else
            {
                txtEjecutivos[3].MaxLength = 26;
            }

            //LMHR & CMET: Se agrega funcion para cargar de datos de prueba
            //FillFormTestData();
        }

        /// <summary>
        /// Método para llenar el formulario con datos de prueba desde un archivo.
        /// </summary>
        ///<!--
        /// Autor: LMHR & CMET
        /// Fecha de creacion: 19/01/2018
        /// Fecha de ultima modificacion: 19/01/2018--> 
        /// </summary>
        private void FillFormTestData()
        {
            try
            {
                if (TestData.TestDataAlta.ExistTest())
                {
                    foreach (var item in TestData.TestDataAlta.getTestData())
                    {
                        string Ctl = item.Key.Substring(0, item.Key.IndexOf('_'));
                        string idCtl = item.Key.Substring((item.Key.IndexOf('_') + 1));

                        switch (Ctl)
                        {
                            case "txt":
                                TextBox tb;
                                tb = (TextBox)(this.Controls.Find(idCtl, true)[0]);
                                tb.Text = item.Value;
                                break;
                            case "Ctxt":
                                AxMSMask.AxMaskEdBox axb;
                                axb = (AxMSMask.AxMaskEdBox)(this.Controls.Find(idCtl, true)[0]);
                                if (!string.IsNullOrEmpty(item.Value))
                                    axb.CtlText = item.Value;
                                break;
                            case "cmb":
                                ComboBox cmb = (ComboBox)(this.Controls.Find(idCtl, true)[0]);
                                cmb.SelectedIndex = int.Parse(item.Value);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void frmEjecutivo_Closed(Object eventSender, EventArgs eventArgs)
        {

            gdteEjecutivo = null;
            gdlgDialogoS016 = null;
            gdlgDialogoS111 = null;

            MemoryHelper.ReleaseMemory();
        }

        private void mskEjecutivos_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(mskEjecutivos, eventSender);
            if (!mskEjecutivos[Index].CtlText.Equals(String.Empty))
                if (mskEjecutivos[Index].CtlText.ToCharArray().GetValue(0).Equals('$'))
                {
                    mskEjecutivos[Index].CtlText = mskEjecutivos[Index].CtlText.Substring(1, mskEjecutivos[Index].CtlText.Length - 1);
                }
            switch (Index)
            {
                case 0:  //RFC 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 1:  //Numero de Nomina 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 2:  //Sueldo 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 3:  //Limite Credito 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 4:  //Limite Disposiciones 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 5:  //Dia de Corte 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 6:  //Domicilio Envio (CP) 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 7:  //Domicilio Envio (Telefono Oficina) 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 8:  //Domicilio Envio (Extension) 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 9:  //Domicilio Envio (Fax) 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 10:  //Domicilio Particular (CP) 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 11:  //Domicilio Particular (Telefono Oficina) 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
                case 12:  //MCC 
                    mskEjecutivos[Index].SelStart = 0;
                    mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                    break;
            }

        }

        private void mskEjecutivos_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            int Index = Array.IndexOf(mskEjecutivos, eventSender);

            switch (Index)
            {
                case 0:  //RFC 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
                    break;
                case 1:  //Numero de Nomina 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
                    break;
                case 2:  //Sueldo 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
                    break;
                case 3:  //Limite Credito 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
                    break;
                case 4:  //Limite Disposiciones 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValEntero, true, false);
                    break;
                case 5:  //Dia de Corte 
                    break;
                case 6:  //Domicilio Envio (CP) 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValEntero, false, false);
                    break;
                case 7:  //Domicilio Envio (Telefono Oficina)
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
                    break;
                case 8:  //Domicilio Envio (Extension) 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
                    break;
                case 9:  //Domicilio Envio (Fax) 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
                    break;
                case 10:  //Domicilio Particular (CP) 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
                    break;
                case 11:  //Domicilio Particular (Telefono Oficina) 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
                    break;
                case 12:  //MCC 
                    //AIS-1094 NGONZALEZ
                    //AIS-1096 NGONZALEZ
                    CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
                    //            If KeyAscii = Asc(vbTab) Then 
                    //                Fichero 0 
                    //            End If 
                    break;
            }

        }

        private int LastMskEjecutivosIndexLeaved = -1;
        private void mskEjecutivos_Leave(Object eventSender, EventArgs eventArgs)
        {
            //AIS-1595 fsaborio
            if (this.Disposing)
                return;

            int Index = Array.IndexOf(mskEjecutivos, eventSender);
            //AIS-1596 fsaborio
            LastMskEjecutivosIndexLeaved = Index;
            try
            {
                switch (Index)
                {
                    case 0:  //RFC 
                        break;
                    case 1:  //Numero de Nomina 
                        gdteEjecutivo.EjeNumNomS = mskEjecutivos[Index].CtlText.Trim();
                        break;
                    case 2:  //Sueldo 
                        gdteEjecutivo.EjeSueldoL = Convert.ToInt32(MdlCambioMasivo.Nvl(mskEjecutivos[Index].CtlText, 0));
                        break;
                    case 3:  //Limite Credito 
                        gdteEjecutivo.EjeLimCredL = (int)Convert.ToDouble(MdlCambioMasivo.Nvl(mskEjecutivos[Index].CtlText, 0));
                        break;
                    case 4:  //Limite Disposiciones 
                        gdteEjecutivo.EjeLimDisEfecL = Convert.ToInt32(MdlCambioMasivo.Nvl(mskEjecutivos[Index].CtlText, 0));
                        break;
                    case 5:  //Dia de Corte 
                        break;
                    case 6:  //Domicilio Envio (CP) 
                        gdteEjecutivo.EjeDomEnvioDMC.CPL = Convert.ToInt32(MdlCambioMasivo.Nvl(mskEjecutivos[Index].CtlText, 0));
                        break;
                    case 7:  //Domicilio Envio (Telefono Oficina) 
                        gdteEjecutivo.EjeTelOfiS = mskEjecutivos[Index].CtlText.Trim();
                        break;
                    case 8:  //Domicilio Envio (Extension) 
                        gdteEjecutivo.EjeExtensionS = mskEjecutivos[Index].CtlText.Trim();
                        break;
                    case 9:  //Domicilio Envio (Fax) 
                        gdteEjecutivo.EjeFaxS = mskEjecutivos[Index].CtlText.Trim();
                        break;
                    case 10:  //Domicilio Particular (CP) 
                        gdteEjecutivo.EjeDomPartDMC.CPL = Convert.ToInt32(MdlCambioMasivo.Nvl(mskEjecutivos[Index].CtlText, 0));
                        break;
                    case 11:  //Domicilio Particular (Telefono Domicilio) 
                        gdteEjecutivo.EjeTelDomS = mskEjecutivos[Index].CtlText.Trim();
                        break;
                    case 12:  //MCC 
                        gdteEjecutivo.EjeTablaMCCL = Convert.ToInt32(MdlCambioMasivo.Nvl(mskEjecutivos[Index].CtlText, 0));
                        break;
                }
            }
            catch
            {

                string tempRefParam = "FrmEjecutivo:MskEjecutivos_LostFocus()";
                if (MdlCambioMasivo.fnGetError(ref tempRefParam))
                {
                    throw new Exception("Migration Exception: 'Resume' not supported");
                }
            }
        }

        private void mskEjecutivos_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            //AIS-1595 fsaborio
            if (this.Disposing)
                return;

            bool Cancel = eventArgs.Cancel;
            int Index = Array.IndexOf(mskEjecutivos, eventSender);
            //AIS-1596 fsaborio
            if (Index != LastMskEjecutivosIndexLeaved)
            {
                LastMskEjecutivosIndexLeaved = -1;
                return;
            }
            LastMskEjecutivosIndexLeaved = -1;

            if (!mskEjecutivos[Index].CtlText.Equals(String.Empty))
                if (mskEjecutivos[Index].CtlText.ToCharArray().GetValue(0).Equals('$'))
                {
                    mskEjecutivos[Index].CtlText = mskEjecutivos[Index].CtlText.Substring(1, mskEjecutivos[Index].CtlText.Length - 1);
                }

            switch (Index)
            {
                case 0:  //RFC 
                    if (!gdteEjecutivo.EjeRfcRFC.fncValidaRFCB(mskEjecutivos[Index].CtlText.Trim(), clsRFC.enuTipoPersona.tprPersonaFisica))
                    {
                        Cancel = true;
                    }
                    break;
                case 1:  //Numero de Nomina 
                    break;
                case 2:  //Sueldo 
                    double dbNumericTemp = 0;
                    if (!Double.TryParse(mskEjecutivos[Index].CtlText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                    {
                        //                Cancel = True
                        //                MsgBox "El sueldo debe estar entre 0 y " & Format(ctelLimiteCredito, "###,###,###.00"), vbInformation + vbOKOnly, "Ejecutivo"
                        mskEjecutivos[Index].CtlText = "0";
                        //                mskEjecutivos(Index).SelStart = 0
                        //                mskEjecutivos(Index).SelLength = Len(mskEjecutivos(Index).Text)
                        //                mskEjecutivos(Index).SetFocus
                    }
                    else if (Conversion.Val(mskEjecutivos[Index].CtlText) > mdlEmpresa.ctelLimiteCredito)
                    {
                        MessageBox.Show("Importe mayor al permitido", "Ejecutivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mskEjecutivos[Index].CtlText = "0";
                        mskEjecutivos[Index].SelStart = 0;
                        mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                        mskEjecutivos[Index].Focus();
                    }
                    break;
                case 3:  //Limite Credito 
                    if (Conversion.Val(mskEjecutivos[Index].CtlText) < 0 || Conversion.Val(mskEjecutivos[Index].CtlText) > 999999)
                    {
                        Cancel = true;
                        //MessageBox.Show("El límite de crédito debe estar entre 0 y " + StringsHelper.Format(mdlEmpresa.ctelLimiteCredito, "###,###,###.00"), "Ejecutivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("El límite de crédito debe estar entre 0 y " + StringsHelper.Format(999999, "###,###.00"), "Ejecutivo", MessageBoxButtons.OK, MessageBoxIcon.Information); //modifica Yuria 12/05/09
                        mskEjecutivos[Index].CtlText = "0";
                        mskEjecutivos[Index].SelStart = 0;
                        mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                        mskEjecutivos[Index].Focus();
                    }
                    else
                    {
                        double dbNumericTemp2 = 0;
                        if (!Double.TryParse(mskEjecutivos[Index].CtlText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2))
                        {
                            Cancel = true;
                            //MessageBox.Show("El límite de crédito debe estar entre 0 y " + StringsHelper.Format(mdlEmpresa.ctelLimiteCredito, "###,###,###.00"), "Ejecutivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show("El límite de crédito debe estar entre 0 y " + StringsHelper.Format(999999, "###,###.00"), "Ejecutivo", MessageBoxButtons.OK, MessageBoxIcon.Information); //yuria modifica 12/05/09
                            mskEjecutivos[Index].CtlText = "0";
                            mskEjecutivos[Index].SelStart = 0;
                            mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                            mskEjecutivos[Index].Focus();
                        }
                    }
                    break;
                case 4:  //Limite Disposiciones 
                    double dbNumericTemp3 = 0;
                    if (Conversion.Val(mskEjecutivos[Index].CtlText) < 0)
                    {
                        Cancel = true;
                        MessageBox.Show("El porcentaje mínimo de disposición de efectivo no puede ser menor al 0%.", "Ejecutivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mskEjecutivos[Index].CtlText = "0";
                        mskEjecutivos[Index].SelStart = 0;
                        mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                        mskEjecutivos[Index].Focus();
                    }
                    else if (Conversion.Val(mskEjecutivos[Index].CtlText) > 100)
                    {
                        Cancel = true;
                        MessageBox.Show("El porcentaje mínimo de disposición de efectivo no puede ser menor al 0%.", "Ejecutivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mskEjecutivos[Index].CtlText = "0";
                        mskEjecutivos[Index].SelStart = 0;
                        mskEjecutivos[Index].SelLength = Strings.Len(mskEjecutivos[Index].CtlText);
                        mskEjecutivos[Index].Focus();
                    }
                    else if (!Double.TryParse(mskEjecutivos[Index].CtlText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp3))
                    {
                        mskEjecutivos[Index].CtlText = "0";
                    }
                    break;
                case 5:  //Dia de Corte 
                    break;
                case 6:  //Domicilio Envio (CP) 
                    if (mskEjecutivos[Index].CtlText == "")
                    {
                        mskEjecutivos[Index].CtlText = "0";
                    }

                    break;
                case 7:  //Domicilio Envio (Telefono Oficina) 
                    break;
                case 8:  //Domicilio Envio (Extension) 
                    break;
                case 9:  //Domicilio Envio (Fax) 
                    break;
                case 10:  //Domicilio Particular (CP) 
                    if (mskEjecutivos[Index].CtlText == "")
                    {
                        mskEjecutivos[Index].CtlText = "0";
                    }

                    break;
                case 11:  //Domicilio Particular (Telefono Domicilio) 
                    break;
                case 12:  //MCC 
                    break;
            }

            eventArgs.Cancel = Cancel;
        }

        //UPGRADE_WARNING: (2050) Threed.SSOption Event optEjecutivos.Click was not upgraded.
        private void optEjecutivos_Click(int Index)
        {

            switch (Index)
            {
                case 0:  //Sexo (Femenino) 
                    gdteEjecutivo.EjeSexoS = "F";
                    break;
                case 1:  //Sexo (Masculino) 
                    gdteEjecutivo.EjeSexoS = "M";
                    break;
                case 2:  //Tipo de Facturacion (Corporativo) 
                    gdteEjecutivo.EjeTipoFactS = mdlEmpresa.ctesEjeCorporativo;
                    break;
                case 3:  //Tipo de Facturacion (Individual) 
                    gdteEjecutivo.EjeTipoFactS = mdlEmpresa.ctesEjeIndividual;
                    break;
                case 4:  //Nacionalidad (Mexicana) 
                    gdteEjecutivo.EjeNacionalidadS = mdlEmpresa.ctesMexicana;
                    break;
                case 5:  //Nacionalidad (Extranjera) 
                    gdteEjecutivo.EjeNacionalidadS = mdlEmpresa.ctesExtranjera;
                    break;
                case 6:  //Tipo de Bloqueo (No maneja Bloqueo) 
                    gdteEjecutivo.EjeTipoBloqueoI = mdlEmpresa.cteiNoManejaBloqueo;
                    mskEjecutivos[12].CtlText = "0";
                    mskEjecutivos[12].Enabled = false;
                    break;
                case 7:  //Tipo de Bloqueo (Bloqueo por MCC) 
                    gdteEjecutivo.EjeTipoBloqueoI = mdlEmpresa.cteiBloqueoPorMCC;
                    mskEjecutivos[12].Enabled = true;
                    break;
                case 8:  //Tipo de Bloqueo (Bloqueo por No. de Negocio) 
                    gdteEjecutivo.EjeTipoBloqueoI = mdlEmpresa.cteiBloqueoPorNegocio;
                    mskEjecutivos[12].Enabled = true;
                    break;
            }

        }

        private void tabEjecutivos_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            prOrdenaTab(tabEjecutivos.SelectedIndex);
            tabEjecutivosPreviousTab = tabEjecutivos.SelectedIndex;
        }

        //private void txtAtencionA_Enter(Object eventSender, EventArgs eventArgs)
        //{
        //    txtAtencionA.SelectionStart = 0;
        //    txtAtencionA.SelectionLength = Strings.Len(txtAtencionA.Text);
        //}

        private void txtAtencionA_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void txtEjecutivos_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(txtEjecutivos, eventSender);
            switch (Index)
            {
                case 0:  //Nombre de la Empresa 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 1:  //Numero de la Empresa 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 2:  //Nombre del Ejecutivo 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 3:  //Nombre de Grabacion 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 4:  //Cuenta 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 5:  //Cuenta Contable 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 6:  //Correo Electronico 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 7:  //Domicilio Envio (Calle y Numero) 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 8:  //Domicilio Envio (Colonia) 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 9:  //Domicilio Envio (Pob/Del/Mun) 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 10:  //Domicilio Particular (Calle y Numero) 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 11:  //Domicilio Particular (Colonia) 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 12:  //Domicilio Particular (Pob/Del/Mun) 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
                case 13:  //Domicilio Particular (Ciudad) 
                    txtEjecutivos[Index].SelectionStart = 0;
                    txtEjecutivos[Index].SelectionLength = Strings.Len(txtEjecutivos[Index].Text);
                    break;
            }
        }

        private void txtEjecutivos_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            int Index = Array.IndexOf(txtEjecutivos, eventSender);
            switch (Index)
            {
                case 0:  //Nombre de la Empresa 
                    break;
                case 1:  //Numero de la Empresa 
                    break;
                case 2:  //Nombre del Ejecutivo 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "@");
                    break;
                case 3:  //Nombre de Grabacion 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, ",/@");
                    break;
                case 4:  //Cuenta 
                    if (KeyAscii < 48 || KeyAscii > 57)
                    {
                        //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                        KeyAscii = CORVB.NULL_INTEGER;
                    }
                    break;
                case 5:  //Cuenta Contable 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false);
                    break;
                case 6:  //Correo Electronico 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValCorreoElectrónico, false, false);
                    break;
                case 7:  //Domicilio Envio (Calle y Numero) 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
                    break;
                case 8:  //Domicilio Envio (Colonia) 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
                    break;
                case 9:  //Domicilio Envio (Pob/Del/Mun) 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
                    break;
                case 10:  //Domicilio Particular (Calle y Numero) 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
                    break;
                case 11:  //Domicilio Particular (Colonia) 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
                    break;
                case 12:  //Domicilio Particular (Pob/Del/Mun) 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
                    break;
                case 13:  //Domicilio Particular (Ciudad) 
                    CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetoSignos, true, true);
                    break;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        //AIS-1596 fsaborio
        private int LastTxtEjecutivosIndexLeaved = -1;
        private void txtEjecutivos_Leave(Object eventSender, EventArgs eventArgs)
        {
            //AIS-1595 fsaborio
            if (this.Disposing)
                return;

            int Index = Array.IndexOf(txtEjecutivos, eventSender);
            //AIS-1596 fsaborio
            LastTxtEjecutivosIndexLeaved = Index;
            switch (Index)
            {
                case 0:  //Nombre de la Empresa 
                    break;
                case 1:  //Numero de la Empresa 
                    break;
                case 2:  //Nombre del Ejecutivo 
                    gdteEjecutivo.EjeNomS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 3:  //Nombre de Grabacion 
                    gdteEjecutivo.EjeNomGrabaS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 4:  //Cuenta 
                    break;
                case 5:  //Cuenta Contable 
                    gdteEjecutivo.EjeCtaContableS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 6:  //Correo Electronico 
                    gdteEjecutivo.EjeEmailS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 7:  //Domicilio Envio (Calle y Numero) 
                    gdteEjecutivo.EjeDomEnvioDMC.DomicilioS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 8:  //Domicilio Envio (Colonia) 
                    gdteEjecutivo.EjeDomEnvioDMC.ColoniaS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 9:  //Domicilio Envio (Pob/Del/Mun) 
                    gdteEjecutivo.EjeDomEnvioDMC.PoblacionS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 10:  //Domicilio Particular (Calle y Numero) 
                    gdteEjecutivo.EjeDomPartDMC.DomicilioS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 11:  //Domicilio Particular (Colonia) 
                    gdteEjecutivo.EjeDomPartDMC.ColoniaS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 12:  //Domicilio Particular (Pob/Del/Mun) 
                    gdteEjecutivo.EjeDomPartDMC.PoblacionS = txtEjecutivos[Index].Text.Trim();
                    break;
                case 13:  //Domicilio Particular (Ciudad) 
                    gdteEjecutivo.EjeDomPartDMC.CiudadS = txtEjecutivos[Index].Text.Trim();
                    break;
            }
        }

        private void txtEjecutivos_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            //AIS-1595 fsaborio
            if (this.Disposing)
                return;

            bool Cancel = eventArgs.Cancel;
            int Index = Array.IndexOf(txtEjecutivos, eventSender);
            //AIS-1596 fsaborio
            if (Index != LastTxtEjecutivosIndexLeaved)
            {
                LastTxtEjecutivosIndexLeaved = -1;
                return;
            }
            LastTxtEjecutivosIndexLeaved = -1;


            switch (Index)
            {
                case 0:  //Nombre de la Empresa 
                    break;
                case 1:  //Numero de la Empresa 
                    break;
                case 2:  //Nombre del Ejecutivo 
                    break;
                case 3:  //Nombre de Grabacion 
                    string tempRefParam = txtEjecutivos[Index].Text.Trim();
                    if (!fncVerificaNombreB(ref tempRefParam))
                    {
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("No se dió de alta correctamente el nombre, el formato es el siguiente: NOMBRE,APELLIDO PATERNO/APELLIDO MATERNO", CORVB.MB_ICONINFORMATION, CORSTR.STR_APP_TIT);
                        Cancel = true;
                    }
                    break;
                case 4:  //Cuenta 
                    break;
                case 5:  //Cuenta Contable 
                    break;
                case 6:  //Correo Electronico 
                    if (txtEjecutivos[Index].Text.Trim().Length > 0)
                    {
                        if ((txtEjecutivos[Index].Text.Trim().IndexOf('@') + 1) == 0 || (txtEjecutivos[Index].Text.Trim().IndexOf('@') + 1) == 1 || (txtEjecutivos[Index].Text.Trim().IndexOf('@') + 1) == txtEjecutivos[Index].Text.Trim().Length)
                        {
                            Cancel = true;
                            MessageBox.Show("Dirección de Correo electrónico incorrecta." + "\r\n" + "Verifique la dirección.", "Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case 7:  //Domicilio Envio (Calle y Numero) 
                    break;
                case 8:  //Domicilio Envio (Colonia) 
                    break;
                case 9:  //Domicilio Envio (Pob/Del/Mun) 
                    break;
                case 10:  //Domicilio Particular (Calle y Numero) 
                    break;
                case 11:  //Domicilio Particular (Colonia) 
                    break;
                case 12:  //Domicilio Particular (Pob/Del/Mun) 
                    break;
                case 13:  //Domicilio Particular (Ciudad) 
                    break;
            }

            eventArgs.Cancel = Cancel;
        }

        private void _optEjecutivos_2_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optEjecutivos, sender);
            optEjecutivos_Click(Index);
        }

        private void _optEjecutivos_3_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optEjecutivos, sender);
            optEjecutivos_Click(Index);
        }

        private void _optEjecutivos_6_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optEjecutivos, sender);
            optEjecutivos_Click(Index);
        }

        private void _optEjecutivos_7_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optEjecutivos, sender);
            optEjecutivos_Click(Index);
        }

        private void _optEjecutivos_8_CheckedChanged(object sender, EventArgs e)
        {
            int Index = Array.IndexOf(optEjecutivos, sender);
            optEjecutivos_Click(Index);
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


        private void BtnAgregarSuc1_Click(object sender, EventArgs e)
        {
            int lngEjeBnx;

            lngEjeBnx = CboEjecutivoBnx1.SelectedIndex;
            if (lngEjeBnx > -1)
            {
                CORMNEJB.DefInstance.Tag = CORCONST.TAG_CAMBIO;
                //VB6.GetItemData(CboEjecutivoBnx1, lngEjeBnx);
                CORVAR.lgblEjxCve = VB6.GetItemData(CboEjecutivoBnx1, lngEjeBnx);

                CORMNEJB.DefInstance.ShowDialog();
                CboEjecutivoBnx1_SelectedIndexChanged_1(CboEjecutivoBnx1, new EventArgs());
                CORCTEJB.DefInstance.Close();
            }
            else
            {
                MessageBox.Show("Eliga un ejecutivo de la lista");
                CboEjecutivoBnx1.Focus();
            }
        }

        private void BtnBuscaNomina1_Click_1(object sender, EventArgs e)
        {
            int iResp = 0; //La respuesta a la advertencia

            if (MskNomina1.ClipText.Trim() != "")
            {
                CRSGeneral.iEjeBnx = int.Parse(MskNomina1.ClipText);
                if (!FnBoolBuscaComboEjeBnx(CRSGeneral.iEjeBnx))
                {
                    this.Cursor = Cursors.Default;
                    iResp = (int)Interaction.MsgBox("El ejecutivo No se encontro " + "\n\r" +
                        "¿ Desea darlo de alta ahora ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                    //this.Cursor = Cursors.WaitCursor;
                    if (iResp == CORVB.IDYES)
                    {
                        CORMNEJB.DefInstance.Tag = CORCONST.TAG_ALTA;
                        CORMNEJB.DefInstance.ShowDialog();
                        FnLeeEjeBnmx();
                        if (CboEjecutivoBnx1.Items.Count > 0)
                        {
                            CboEjecutivoBnx1.SelectedIndex = 0;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe indicar una nomina valida ");
            }
        }

        private bool FnBolLeeSucursal(int lngEjeBnx)
        {
            ObjSucursal = null;

            if (lngEjeBnx > -1)
            {
                CboSucursal1.Items.Clear();
                CORVAR.pszgblsql = "Select sucursal_numero,sucursal_descripcion,sucursal_status  ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " From MTCSUC01 ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " Where ejx_numero=" + lngEjeBnx.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    ColSucursal = new Collection();

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        ObjSucursal = new clsSucursal();
                        ObjSucursal.IdSucursal = int.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                        ObjSucursal.Descripcion = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ObjSucursal.Status = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                        CboSucursal1.Items.Add(new ListBoxItem(StringsHelper.Format(ObjSucursal.IdSucursal, "@@@@") + " " + ObjSucursal.Descripcion, ObjSucursal.IdSucursal));
                        ColSucursal.Add(ObjSucursal, "K_" + ObjSucursal.IdSucursal, null, null);
                    }
                    return true;
                }
            }
            return false;
        }

        private clsSucursal FnAsignaSucursal(string strItem, int iIndex)
        {
            try
            {
                clsSucursal mObjSucursal;
                if (ColSucursal.Contains(strItem))
                {
                    mObjSucursal = (clsSucursal)ColSucursal[iIndex + 1];
                    return mObjSucursal;
                }
                else
                {
                    return null; // 'El elmento no se encontro
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }


        private bool FnLeeEjeBnmx()
        {
            try
            {
                CORVAR.pszgblsql = "select ejx_numero, ejx_nombre  from MTCEJX01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " Order by ejx_numero";
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                CboEjecutivoBnx1.Items.Clear();
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        CboEjecutivoBnx1.Items.Add(new ListBoxItem(StringsHelper.Format(int.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1)), "000000") + " " + VBSQL.SqlData(CORVAR.hgblConexion, 2), int.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1))));
                    }
                }
                return true;
            }
            catch
            {
                MessageBox.Show("No Error:" + Information.Err().Number + "\n\r" + "Descripcion:" + "\n\r" + Information.Err().Description);
                return false;
            }
        }

        private int FnLngBuscaElementoCombo(ComboBox Ctrl, int lngElemento)
        {
            int lngElementos;
            for (lngElementos = 0; lngElementos < Ctrl.Items.Count; lngElementos++)
            {
                if (VB6.GetItemData(Ctrl, lngElementos) == lngElemento)
                {
                    return lngElementos;
                }
            }
            return -1;
        }

        private bool FnBoolBuscaComboEjeBnx(int lngEjeBnx)
        {
            int lngEjecutivos;

            lngEjecutivos = FnLngBuscaElementoCombo(CboEjecutivoBnx1, lngEjeBnx);
            CboEjecutivoBnx1.SelectedIndex = lngEjecutivos;
            CboEjecutivoBnx1_SelectedIndexChanged_1(CboEjecutivoBnx1, new EventArgs());
            if (lngEjecutivos > -1)
            { return true; }
            else
            { return false; }
        }

        private bool FnBoolBuscaComboSucursal(int lngSucursal)
        {
            int mlngSucursal;
            mlngSucursal = FnLngBuscaElementoCombo(CboSucursal1, lngSucursal);
            CboSucursal1.SelectedIndex = mlngSucursal;
            CboSucursal1_SelectedIndexChanged_1(CboSucursal1, new EventArgs());
            if (mlngSucursal > -1)
            { return true; }
            else
            { return false; }

        }

        private void CboEjecutivoBnx1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int lngIndex;
            lngIndex = CboEjecutivoBnx1.SelectedIndex;
            ObjSucursal = null;
            CboSucursal1.Items.Clear();
            if (lngIndex > -1)
            {
                if (!FnBolLeeSucursal(VB6.GetItemData(CboEjecutivoBnx1, lngIndex)))
                {
                    CboSucursal1.SelectedIndex = -1;
                }
            }

        }

        private void CboSucursal1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ObjSucursal = null;
            if (CboSucursal1.SelectedIndex > -1)
            {
                ObjSucursal = FnAsignaSucursal("K_" + VB6.GetItemData(CboSucursal1, CboSucursal1.SelectedIndex), CboSucursal1.SelectedIndex);
                if (ObjSucursal != null)
                {
                    txtEstatusSucursal1.Text = ObjSucursal.Status;
                }
                else
                {
                    txtEstatusSucursal1.Text = "N";
                }
            }
            else
            {
                txtEstatusSucursal1.Text = "";
            }

        }

    }
}