using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Artinsoft.VB6.VB;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using System.Data.Odbc;

namespace TCc430
{
    internal partial class CORMNEMP
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**          CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas          **
        //**                                                                        **
        //**       -----------------------------------------------------------      **
        //**                                                                        **
        //**       Descripción: Realiza las Altas de las Empresas o en su ca -      **
        //**                    so, de los Ejecutivos Banamex (Llama a la for-      **
        //**                    ma)                                                 **
        //**                                                                        **
        //**       Responsable: Hugo L. Morales Garcia                              **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 28/Abril/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        //ais
        private AxGEARLib.AxGear axgear1; 
        private AxGEARLib.AxGear axgear2;
        private AxGEARLib.AxGear axgear3; 
        
        private bool loadAxgear1 = false;
        private bool loadAxgear2 = false;
        private bool loadAxgear3 = false;

        private bool enableID_FIR_FR1_PB = false;
        private bool enableID_FIR_FR2_PB = false;
        private bool enableID_FIR_FR3_PB = false;


        public bool EnableID_FIR_FR3_PB
        {
            get
            {
                return enableID_FIR_FR3_PB;
            }
            set { enableID_FIR_FR3_PB = value; }
        }

        public bool EnableID_FIR_FR1_PB
        {
            get
            {
                return enableID_FIR_FR1_PB;
            }
            set { enableID_FIR_FR1_PB = value; }
        }

        public bool EnableID_FIR_FR2_PB
        {
            get
            {
                return enableID_FIR_FR2_PB;
            }
            set { enableID_FIR_FR2_PB = value; }
        }

        public bool LoadAxgear1
        {
            get
            {
                return loadAxgear1;
            }
            set { loadAxgear1 = value; }
        }

        public bool LoadAxgear2
        {
            get
            {
                return loadAxgear2;
            }
            set { loadAxgear2 = value; }
        }

        public bool LoadAxgear3
        {
            get
            {
                return loadAxgear3;
            }
            set { loadAxgear3 = value; }
        }

       

        public AxGEARLib.AxGear Axgear1
        {
            get
            {
                return axgear1;
            }
        }
        public AxGEARLib.AxGear Axgear2
        {
            get
            {
                return axgear2;
            }
        }
        public AxGEARLib.AxGear Axgear3
        {
            get
            {
                return axgear3;
            }
        }

        //ais
        
        
        //Ariadna
        int bActualizarCM = 0;
        //********************************
        
        int iErr = 0;
        int hConexion = 0;
        string pszSentencia = String.Empty;
        string pszEnvioIni = String.Empty;
        string pszCNumAnt = String.Empty;
        string pszColoniaAnt = String.Empty;
        string pszAntPobAnt = String.Empty;
        string pszCiudadAnt = String.Empty;
        string pszEstadoAnt = String.Empty;
        string pszFirma1 = String.Empty;
        string pszFirma2 = String.Empty;
        string pszFirma3 = String.Empty;
        int lCpAnt = 0;
        int lLeeCreditoGlobal = 0;
        string bAceptar = String.Empty;
        string bVerFirmas = String.Empty;

        //variables para verifivar si se realizaron cambios en algún dato
        int mlNominaEjeBNX = 0;
        string msNomEmpresa = String.Empty;
        string msNomCorto = String.Empty;
        string msRFC = String.Empty;
        double mdCartera = 0;
        string msAccionista = String.Empty;
        int miSector = 0;
        int mlCreditoGlobal = 0;
        string msFecVenc = String.Empty;
        string msCalleFis = String.Empty;
        string msColoniaFis = String.Empty;
        string msCiudadFis = String.Empty;
        string msPoblacionFis = String.Empty;
        string msEstadoFis = String.Empty;
        int mlCpFis = 0;
        string msTelefono = String.Empty;
        string msLada = String.Empty;
        string msFax = String.Empty;
        string msTonoPul = String.Empty;
        int miVelTrns = 0;
        string msEmail = String.Empty;
        string msInternet = String.Empty;
        double mdCtaCaptacion = 0;
        int miSucursal = 0;
        string msTipoPago = String.Empty;
        string msTipoPagoGen = String.Empty;
        string msTipoEnv = String.Empty;
        string msNombreR1 = String.Empty;
        string msPuestoR1 = String.Empty;
        string msTelR1 = String.Empty;
        string msExtR1 = String.Empty;
        string msFaxR1 = String.Empty;
        string msNombreR2 = String.Empty;
        string msPuestoR2 = String.Empty;
        string msTelR2 = String.Empty;
        string msExtR2 = String.Empty;
        string msFaxR2 = String.Empty;
        string msNombreR3 = String.Empty;
        string msPuestoR3 = String.Empty;
        string msTelR3 = String.Empty;
        string msExtR3 = String.Empty;
        string msFaxR3 = String.Empty;
        int mlCredAcum = 0;
        string msTelExt = String.Empty;
        string msFaxLada = String.Empty;
        bool bHayReg = false;
        string msAtencionA = String.Empty; //FSWB 20070223 NR Se incluyen campos Atencion A y Persona
        int miPersona = 0; //FSWB NR 20070223

        //Variables de Campos adicionales    26.11.2001 EISSA
        int ilDiaCorte = 0;
        int ilPlazoGracia = 0;
        int ilPlazoGraciaGen = 0;
        int ilPlazoNoCobro = 0;
        int ilPlazoNoCobroGen = 0;
        int ilTablaMCC = 0;
        int ilGeneraSBF = 0;
        int ilGeneraSBFgen = 0;
        string slTipoFactura = String.Empty;
        string slEsquemaPago = String.Empty;
        string slTipoProducto = String.Empty;
        string slTipoProductoGen = String.Empty;
        int llEstructuraGastos = 0;
        int llEstructuraGastosGen = 0;
        int ilMesFiscal = 0;
        int ilMesFiscalGen = 0;
        string slUsuarioCambio = String.Empty;
        int llFechaAlta = 0;
        int llFechaUpdate = 0;
        int llHoraUpdate = 0;
        int ilMontoPorciento = 0;
        int ilMontoPorcientoGen = 0;
        double dlFacturacionMinima = 0;
        double dlFacturacionMinimaGen = 0;
        string slCuentaContable = String.Empty;
        string slCuentaContableGen = String.Empty;
        int ilSkipPayment = 0;
        string slMensaje111 = String.Empty;
        string slNacionalidad = String.Empty;
        string slIndCtaControl = String.Empty;
        string slAtencionA = String.Empty; //FSWB NR 20070226
        int ilPersona = 0; //FSWB NR 20070226
        int ilEnvioCDF = 0;

        //Variables para la Transaccion 5368
        int ilSkipPaymentCambio = 0;
        int ilTablaMCCCambio = 0;
        int ilTipoBloqueoCambio = 0;

        //Variables para la transaccion 5368
        string smCambioMCC = String.Empty;
        string smCambioSKIP = String.Empty;
    
        bool blBanderaMensajeSBF = false;
        CRSDialogo.mtcEjecutivo mtcEjeEmpOriginal = CRSDialogo.mtcEjecutivo.CreateInstance();

        //05112002 ---------Ariadna----------
        //Variable de tipo booleano que indica si ya fue establecida la conexión
        //de manera exitosa (dentro de Alta_Empresa)
        bool blConexionExitosa = false;

        //Fin 05112002 ------------Ariadna---------

        //Actualizar estas constantes cuando se actualicen las propiedades del Scroll
        const int INT_CAMBIO_GRANDE = 300;
        const int INT_CAMBIO_CHICO = 20;
        const string STR_AUTO = "A";
        const string STR_IND = "I";
        const string STR_LIB = "L";
        const string STR_EMP = "E";
        const string STR_TONO = "T";
        const string STR_PULSO = "P";

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


        clsCliente lcteCliente = null;

        int intCont = 0;
        string bolfalfirma = String.Empty;



        private void Agrega_Item()
        {
            //AIS-8 NGONZALEZ
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                int i;
                for (i = 0; i < 20; i++)
                {
                    try
                    {
                        
                        ID_MEM_SEC_COB.Items.Add(CORCONST.arregloSectorEmpresa[i]);
                    }
                    catch { }
                }
                try
                {
                    ID_MEM_SEC_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }
                catch { }
            }
            /*
            try
            {
                ID_MEM_SEC_COB.Items.Add(CORCONST.STR_SEC_IND);
            }
            catch { }
            try
            {
                ID_MEM_SEC_COB.Items.Add(CORCONST.STR_SEC_CMR);
            }
            catch { }
            try
            {
                ID_MEM_SEC_COB.Items.Add(CORCONST.STR_SEC_SER);
            }
            catch  { }
            try
            {
                ID_MEM_SEC_COB.Items.Add(CORCONST.STR_SEC_COM);
            }
            catch { }
            try
            {
                ID_MEM_SEC_COB.Items.Add(CORCONST.STR_SEC_TRA);
            }
            catch  { }
            try
            {
                ID_MEM_SEC_COB.Items.Add(CORCONST.STR_SEC_FIN);
            }
            catch { }
            try
            {
                ID_MEM_SEC_COB.Items.Add(CORCONST.STR_SEC_TNF);
            }
            catch { }
            try
            {
                ID_MEM_SEC_COB.Items.Add(CORCONST.STR_SEC_OTR);
            }
            catch { }
            try
            {
                ID_MEM_SEC_COB.SelectedIndex = CORVB.NULL_INTEGER;
            }
            catch { }
        }*/
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Obtiene el nombre del ejecutivo de acuerdo a -      **
        //**                    su número de nómina                                 **
        //**                                                                        **
        //**       Declaración: Function Nombre_Ejecutivo() as string               **
        //**                                                                        **
        //**       Paso de parámetros: lNomina : La nómina del Ejecutivo            **
        //**                                                                        **
        //**       Valor de Regreso: El nombre del ejecutivo                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr                                            **
        //**                                                                        **
        //**       Ultima modificacion: 030594                                      **
        //**                                                                        **
        //****************************************************************************
        //
        private void Busca_Ejecutivo()
        {


            int iResp = 0; //La respuesta a la advertencia
            string pszNombreEjecutivo = String.Empty; //El nombre del ejecutivo
            int iExistenEjec = 0; //indica si existen ejecutivos
            int iIndice = 0;

            //***** INICIO CODIGO NUEVO FSWBMX *****
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                this.Cursor = Cursors.WaitCursor;

                do
                {//AIS-8 NGONZALEZ
                    try
                    {
                        iIndice = Busca_EnCombo(StringsHelper.Format(ID_MEM_NNA_EB.Text, "0000000"));
                    }
                    catch  { }
                    if (iIndice >= CORVB.NULL_INTEGER)
                    {
                        ID_MEM_NOM_COB.SelectedIndex = iIndice;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        iResp = (int)Interaction.MsgBox("El número de nómina " + StringsHelper.Format(ID_MEM_NNA_EB.Text, "0000000") + " no existe en Catálogos, desea darlo de Alta ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                        this.Cursor = Cursors.WaitCursor;
                        if (iResp == CORVB.IDYES)
                        {
                            CORMNEJB.DefInstance.Tag = CORCONST.TAG_ALTA;
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            //AIS-8 NGONZALEZ
                            try
                            {
                                CORMNEJB.DefInstance.ShowDialog(); //Llamamos a la froma de Altas de Ejecutivos Banamex
                            }
                            catch { }
                            //AIS-8 NGONZALEZ
                            try
                            {
                                iExistenEjec = Obtiene_Ejecutivos(); //Actualizamos el Combo Box
                            }
                            catch  { }
                            ID_MEM_EJE_FRM.Visible = false;
                            ID_MEM_EJE_FRM.Visible = true;
                        }
                        else
                        {
                            if (ID_MEM_NOM_COB.SelectedIndex < CORVB.NULL_INTEGER)
                            {
                                ID_MEM_NOM_COB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                }
                while (!(iResp == CORVB.IDNO || iErr == CORCONST.OK));

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Obtiene el nombre del ejecutivo de acuerdo a -      **
        //**                    su número de nómina                                 **
        //**                                                                        **
        //**       Declaración: Function Nombre_Ejecutivo() as string               **
        //**                                                                        **
        //**       Paso de parámetros: lNomina : La nómina del Ejecutivo            **
        //**                                                                        **
        //**       Valor de Regreso: El nombre del ejecutivo                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr                                            **
        //**                                                                        **
        //**       Ultima modificacion: 030594                                      **
        //**                                                                        **
        //****************************************************************************
        //
        private int Busca_EnCombo(string pszNomina)
        {

            int result = 0;

            //***** INICIO CODIGO NUEVO FSWBMX *****
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** FIN DE CODIGO NUEVO FSWBMX *****


                for (int iCont = 0; iCont <= ID_MEM_NOM_COB.Items.Count; iCont++)
                {
                    if (pszNomina == VB6.GetItemString(ID_MEM_NOM_COB, iCont).Substring(0, Math.Min(VB6.GetItemString(ID_MEM_NOM_COB, iCont).Length, 7)))
                    {
                        return iCont;
                    }
                }
                result = -1;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        //UPGRADE_NOTE: (7001) The following declaration (Busca_Incremento) seems to be dead code
        //private int Busca_Incremento()
        //{
        //
        //int result = 0;
        //int hIncEmp = 0; //Apunta a la sentencia SQL
        //
        //***** INICIO CODIGO NUEVO FSWBMX *****
        ////UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
        //try
        //{
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //int iIncre = CORVB.NULL_INTEGER;
        //CORVAR.pszgblsql = "SELECT pgs_incremento FROM " + CORBD.DB_SYB_PGS;
        //
        //
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
        //{
        //iIncre = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
        //}
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //result = iIncre;
        //}
        //catch (Exception exc)
        //{
        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //}
        //
        //return result;
        //}

        private bool Cambio_DomicilioEnv()
        {

            if ((ID_MEM_DOM_EB[1].Text.Trim().ToUpper() == pszCNumAnt.Trim().ToUpper()) && (ID_MEM_COL_EB[1].Text.Trim().ToUpper() == pszColoniaAnt.Trim().ToUpper()) && (ID_MEM_CIU_EB[1].Text.Trim().ToUpper() == pszAntPobAnt.Trim().ToUpper()) && (ID_MEM_PDM_EB[1].Text.Trim().ToUpper() == pszCiudadAnt.Trim().ToUpper()) && (CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex].Trim().ToUpper() == pszEstadoAnt.Trim().ToUpper()) && (Conversion.Val(ID_MEM_CP_PIC[1].CtlText) == Conversion.Val(lCpAnt.ToString())) && (ID_MEM_CON_TXT.Text == msTelefono.Trim()) && (ID_MEM_TEL_EXT_TXT.Text == msTelExt.Trim()) && mtcEjeEmpOriginal.sEjeRFC.Trim() == Strings.Replace(ID_MEM_RFC_MKE.CtlText, "-", "", 1, -1, CompareMethod.Binary).Trim())
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        //20021122 ---Ariadna--------------------------------------------------------
        private void prBorraCambiosRepetidos(string psNumEmp, string psGpoBanco, string psTipo)
        {

            //Objetivo: Borra los cambios de direccion que esten sin procesar

            int llNumRepeticiones = 0;
            int llRep = 0;
            //'***********************
            //Sólo comparar hasta número de ejecutivo por que las cuentas se reasignan cuando el
            //tarjetahabiente tiene algún problema como perder su tarjeta

            int llNumEje = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_MEM_TEX_PNL[3].Text, Convert.ToInt32(Double.Parse(mdlParametros.gprdProducto.MascaraPrefijoS) + psGpoBanco.Length + Double.Parse(Formato.sMascara(Formato.iTipo.Empresa)) + 1), Int32.Parse(Formato.sMascara(Formato.iTipo.Ejecutivo)))));

            CORVAR.pszgblsql = "delete ";
            //pszgblsql = pszgblsql & " * "
            CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM MTCCAM01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_estado='No Proce' ";

            //pszgblsql = pszgblsql & " AND cam_calle_emp = '" & ID_MEM_DOM_EB(1).Text & "'"
            //pszgblsql = pszgblsql & " AND cam_col_emp = '" & ID_MEM_COL_EB(1).Text & "'"
            //pszgblsql = pszgblsql & " AND cam_pob_emp = '" & ID_MEM_PDM_EB(1).Text & "'"
            //pszgblsql = pszgblsql & " AND cam_estado_emp = '" & asgEstados(0, ID_MEM_EDO_EB(1).ListIndex) & "'"
            //pszgblsql = pszgblsql & " AND cam_cp_emp = " & ID_MEM_CP_PIC(1).Text

            CORVAR.pszgblsql = CORVAR.pszgblsql + " AND eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " AND gpo_banco = " + psGpoBanco;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " AND emp_num = " + psNumEmp;

            if (psTipo == "Individual")
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + " AND eje_num = 0"; //& llNumEje
            }
            CORPROC2.Modifica_Registro();
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


        }

        //UPGRADE_NOTE: (7001) The following declaration (Carga_Firmas) seems to be dead code
        //private void  Carga_Firmas()
        //{
        //
        //***** INICIO CODIGO NUEVO FSWBMX *****
        ////UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
        //try
        //{
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //
        //this.Cursor = Cursors.WaitCursor;
        //
        //CORVAR.bgblFirma1 = 0;
        //CORVAR.bgblFirma2 = 0;
        //CORVAR.bgblFirma3 = 0;
        //
        //pszFirma1 = CORVB.NULL_STRING;
        //pszFirma2 = CORVB.NULL_STRING;
        //pszFirma3 = CORVB.NULL_STRING;
        //
        //obtiene la firma del ejecitivo 1
        //IMAGEN.LeerImagen(CORCONFI.DefInstance.ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //obtiene la firma del ejecitivo 2
        //IMAGEN.LeerImagen(CORCONFI.DefInstance.ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //obtiene la firma del ejecitivo 3
        //IMAGEN.LeerImagen(CORCONFI.DefInstance.ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + CORVAR.lgblNumEmpresa.ToString());
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //}
        //catch (Exception exc)
        //{
        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //}
        //
        //}

        private bool ComparaDatosCambio()
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            bool result = false;
            try
            {

                result = false;

                if (pszCNumAnt != ID_MEM_DOM_EB[1].Text)
                {
                    result = true;
                }

                if (pszColoniaAnt != ID_MEM_COL_EB[1].Text)
                {
                    result = true;
                }

                if (pszAntPobAnt != ID_MEM_CIU_EB[1].Text)
                {
                    result = true;
                }

                if (pszCiudadAnt != ID_MEM_PDM_EB[1].Text)
                {
                    result = true;
                }

                if (pszEstadoAnt != CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex])
                {
                    result = true;
                }

                if (lCpAnt != Conversion.Val(ID_MEM_CP_PIC[1].CtlText))
                {
                    result = true;
                }

                // APQ 1-Jul-2010 Inicio - Cambio Tipo de Bloqueo
                if (ilTipoBloqueoCambio != mdlParametros.igEmpTipoBloqueo)
                {
                    result = true;
                }
                // APQ 1-Jul-2010 Fin - Cambio Tipo de Bloqueo

                if (ilTablaMCCCambio != Conversion.Val(mskMCC.CtlText))
                {
                    result = true;
                }

                if (ilSkipPaymentCambio != ilSkipPayment)
                {
                    result = true;
                }

                //UPGRADE_WARNING: (1068) Nvl(ID_MEM_CRE_FTB.Text, 0) of type Variant is being forced to double.
                if (mtcEjeEmpOriginal.lEjeLimiteCredito != Convert.ToDouble(MdlCambioMasivo.Nvl(ID_MEM_CRE_FTB.CtlText, 0)) && slTipoFactura == "C")
                {
                    result = true;
                }
                if (Seguridad.fncsSustituir(ID_MEM_NCT_EB.Text, "'", "").Trim().ToUpper() != mtcEjeEmpOriginal.sEjeNomGrabado.Trim().ToUpper())
                {
                    result = true;
                }
                //ID_MEM_RFC_MKE Valida si el rfc del cliente sufrio cambios
                if (mtcEjeEmpOriginal.sEjeRFC.Trim() != Strings.Replace(ID_MEM_RFC_MKE.CtlText, "-", "", 1, -1, CompareMethod.Binary).Trim())
                {
                    result = true;
                }

                if (ilSkipPaymentCambio != ((int)chkSkipPayment.CheckState))
                {
                    result = true;
                }

                if (msTelefono != ID_MEM_CON_TXT.Text.Trim())
                {
                    result = true;
                }

                if (msTelExt != ((ID_MEM_TEL_EXT_TXT.Text.Trim() == "") ? "0" : ID_MEM_TEL_EXT_TXT.Text.Trim()))
                {
                    result = true;
                }

                //FSWB NR 20070223 REvisa si hubo campos en campos de Atencion A y Persona
                //***** INICIO
                //if (slAtencionA != txtAtencionA.Text.Trim())
                //{
                //    result = true;
                //}

                //if (ilPersona != StringsHelper.IntValue(Strings.Mid(ID_MEM_PERSONA.Text, 1, 1)))
                //{
                //    result = true;
                //}

                //***** FIN
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }


        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Obtiene el consecutivo de la empresa del catá-      **
        //**                    logo de Consecutivos (MTCCON01) para asignarlo      **
        //**                    a la empresa correspondiente                        **
        //**                                                                        **
        //**       Declaración: Function Consecutivo_Empresa                        **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: El consecutivo de la empresa                   **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr                                            **
        //**                                                                        **
        //**       Ultima modificacion: 030594                                      **
        //**                                                                        **
        //****************************************************************************
        private int Consecutivo_Empresa()
        {

            int result = 0;
            int hParam = 0; //El apuntador a la sentencia SQL

            //***** INICIO CODIGO NUEVO FSWBMX *****
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                iErr = CORCONST.OK;

                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //pszgblsql = "exec consecutivo_empresa " + Format$(igblBanco)
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX *****
                CORVAR.pszgblsql = "exec consecutivo_empresa " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString();
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        result = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))); //A la función, el consecutivo
                    }
                    else
                    {
                        result = CORVB.NULL_INTEGER; //No hay consecutivo, se devuelve 0
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Convierte las firmas de Formato pcx a una cadena binaria*
        //**                                                                        **
        //**       Declaración: sub Convierte_Firma()                               **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma  :                                                **
        //**                                                                        **
        //**       Ultima modificacion: 200594                                      **
        //**                                                                        **
        //****************************************************************************
        //UPGRADE_NOTE: (7001) The following declaration (Convierte_Firma) seems to be dead code
        //private void  Convierte_Firma( string pszNumFirma)
        //{
        //
        //int hFirma = 0;
        //FixedLengthString szChar = new FixedLengthString(1);
        //
        //***** INICIO CODIGO NUEVO FSWBMX *****
        ////UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
        //try
        //{
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //
        //this.Cursor = Cursors.WaitCursor;
        //
        //FileSystem.FileOpen(1, CORVAR.pszgblPathFirmas + "firma" + pszNumFirma + ".pcx", OpenMode.Binary, OpenAccess.Default, OpenShare.Default, -1);
        //StringBuilder pszCadena = new StringBuilder();
        //pszCadena.Append("0x");
        //
        //while(! FileSystem.EOF(1))
        //{
        //szChar.Value = FileSystem.InputString(1, 1);
        //if (((int) szChar.Value[0]).ToString("X").Length != 2)
        //{
        //pszCadena.Append("0" + ((int) szChar.Value[0]).ToString("X"));
        //} else
        //{
        //pszCadena.Append(((int) szChar.Value[0]).ToString("X"));
        //}
        //};
        //FileSystem.FileClose(1);
        //
        //switch(pszNumFirma)
        //{
        //case "1" :  
        //pszFirma1 = pszCadena.ToString(); 
        //break;
        //case "2" :  
        //pszFirma2 = pszCadena.ToString(); 
        //break;
        //case "3" :  
        //pszFirma3 = pszCadena.ToString(); 
        //break;
        //}
        //}
        //catch (Exception exc)
        //{
        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //}
        //
        //}

        //UPGRADE_NOTE: (7001) The following declaration (Convierte_Hex) seems to be dead code
        //private string Convierte_Hex( string pszCadena)
        //{
        //
        //string result = String.Empty;
        //string pszHex = String.Empty;
        //
        //***** INICIO CODIGO NUEVO FSWBMX *****
        ////UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
        //try
        //{
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //StringBuilder pszResulta = new StringBuilder();
        //pszResulta.Append(CORVB.NULL_STRING);
        //for (int lCont = 1; lCont <= pszCadena.Length; lCont++)
        //{
        //pszHex = "0x";
        //pszHex = ((int) Strings.Mid(pszCadena, lCont, 1)[0]).ToString("X");
        //if (pszHex.Length != 2)
        //{
        //pszResulta.Append("0" + pszHex);
        //} else
        //{
        //pszResulta.Append(pszHex);
        //}
        //}
        //
        //result = pszResulta.ToString();
        //}
        //catch (Exception exc)
        //{
        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //}
        //
        //return result;
        //}

        public void Crea_Directorio_Emp(string pszEmpresa)
        {

            string pszDirEmp = String.Empty;

            //***** INICIO CODIGO NUEVO FSWBMX *****
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                //*****Crea el directorio de la Empresa dada de alta******

                //Si existe el directorio de Reportes Empresa...
                if (FileSystem.Dir(CORVAR.pszgblPathRepEmpresas, FileAttribute.Directory) != CORVB.NULL_STRING)
                {

                    //Arma el Directorio de la nueva empresa dada de alta.
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //pszDirEmp = pszgblPathRepEmpresas & pszEmpresa
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    pszDirEmp = CORVAR.pszgblPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + pszEmpresa;
                    //***** FIN DE CODIGO NUEVO FSWBMX *****

                    //Si no existe el directorio de la empresa...
                    if (FileSystem.Dir(pszDirEmp, FileAttribute.Directory) == CORVB.NULL_STRING)
                    {

                        //Se crea su directorio
                        Directory.CreateDirectory(pszDirEmp);

                    }

                    //Si no existe...
                }
                else
                {

                    //Se crea el directorio de Reportes de Empresas
                    Directory.CreateDirectory(CORVAR.pszgblPathRepEmpresas);

                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }
        private void ModificaEstadoCambio(string pszParametro, string pszEmpNum)
        {
            //Parametros de entrada:
            //pszEmpNum.- Empresa a filtrar para marcar los registros como cancelados
            //            si no se suministra este valor entenderá que son todas

            //Ariadna ----------------------------------------------------
            CORVAR.pszgblsql = "select count (eje_num) FROM " + CORBD.DB_SYS_CAM;
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where cam_mensaje like '%OPERACION NEGADA%'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = '" + pszParametro + "'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
            if (pszEmpNum.Trim() != "")
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpNum;
            }

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                VBSQL.SqlNextRow(CORVAR.hgblConexion);
                if (Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)) != 0)
                {
                    if (MdlCambioMasivo.FnMsgYesno("Hay registros que el S111 ha marcado como operacion negada" + "\r\n" + " ¿ Desea que dichos registros se cancele su envio ? "))
                    {
                        VBSQL.SqlCancel(CORVAR.hgblConexion);
                        CORVAR.pszgblsql = "Update " + CORBD.DB_SYS_CAM;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set cam_estado='Cancelado'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where cam_mensaje like '%OPERACION NEGADA%'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = '" + pszParametro + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                        if (pszEmpNum.Trim() != "")
                        {
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszEmpNum;
                        }
                        CORPROC2.Modifica_Registro();

                    }
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                  Borra los registros de la tabla MTCCAM01 dependiendo  **
        //**                  del proceso que ejecuta la función                    **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros: Proceso que ejecuta la función               **
        //**                                                                        **
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 12oct98                                     **
        //**                                                                        **
        //****************************************************************************
        //
        public void Depura_Tabla_CamMasivos(ref  string pszParametro, ref  string pszNumEmpresa)
        {
            //depura la tabla de cambios masivos
            //borrando los registros que estan con estado de Procesado y No cambio

            //Ariadna
            ModificaEstadoCambio(pszParametro, pszNumEmpresa);

            //***** INICIO CODIGO NUEVO FSWBMX *****
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                CORVAR.pszgblsql = "Delete  from " + CORBD.DB_SYS_CAM;
                CORVAR.pszgblsql = CORVAR.pszgblsql + " Where cam_estado = 'Procesado'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " or cam_estado = 'No Cambio'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " or cam_estado = 'Cancelado'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " or cam_estado = 'cancelado'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = '" + pszParametro + "'";
                //***** INICIO CODIGO NUEVO FSWBMX *****
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                if (pszNumEmpresa != "")
                {
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num  = " + pszNumEmpresa;
                }
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private string Existen_Blancos()
        {

            string result = String.Empty;
            string pszFecha = String.Empty;
            int iMes = 0;
            int iDia = 0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                double dbNumericTemp = 0;
                if (ID_MEM_NLG_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(CORVB.NULL_INTEGER);
                    ID_MEM_NLG_EB.Focus();
                    return "Nombre de la Empresa";

                }
                else if (ID_MEM_NCT_EB.Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(0);
                    ID_MEM_NCT_EB.Focus();
                    return "Nombre Corto";

                }
                else if (ID_MEM_RFC_MKE.CtlText.Trim() == "-      -")
                {
                    Fichero(CORVB.NULL_INTEGER);
                    ID_MEM_RFC_MKE.Focus();
                    return "RFC de la Empresa";

                }
                else if (!CRSGeneral.bfncValidaRFC(ID_MEM_RFC_MKE.defaultText))
                {
                    Fichero(CORVB.NULL_INTEGER);
                    ID_MEM_RFC_MKE.Focus();
                    return "RFC de la Empresa";

                }
                else if (Conversion.Val(ID_MEM_CRE_FTB.CtlText.Trim()) == CORVB.NULL_INTEGER)
                {
                    Fichero(CORVB.NULL_INTEGER);
                    ID_MEM_CRE_FTB.Focus();
                    return "Crédito Asignado";

                }
                else if ((Conversion.Val(ID_MEM_CRE_FTB.CtlText) > 999999999))
                {
                    MessageBox.Show("Importe mayor al permitido", Application.ProductName);
                    ID_MEM_CRE_FTB.CtlText = "0";
                    ID_MEM_CRE_FTB.Focus();
                    return "Crédito Asignado";

                }
                else if ((Conversion.Val(ID_MEM_CRE_FTB.CtlText) <= 0))
                {
                    MessageBox.Show("Importe menor al permitido", Application.ProductName);
                    ID_MEM_CRE_FTB.CtlText = "0";
                    ID_MEM_CRE_FTB.Focus();
                    return "Crédito Asignado";

                }
                else if (ID_MEM_FEC_VEN_DTB.CtlText == CORVB.NULL_STRING)
                {
                    Fichero(CORVB.NULL_INTEGER);
                    ID_MEM_FEC_VEN_DTB.Focus();
                    return "Fecha de Vencimiento";

                }
                else if (((int)DateAndTime.DateDiff("d", StringsHelper.DateValue(DateTime.Parse(ID_MEM_FEC_VEN_DTB.CtlText).ToString("dd/MM/yyyy")), StringsHelper.DateValue(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0)
                {
                    MessageBox.Show("Fecha menor a la permitida." + "\r\n" + "La fecha debe ser al menos un dia después al actual.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Fichero(CORVB.NULL_INTEGER);
                    ID_MEM_FEC_VEN_DTB.CtlText = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                    ID_MEM_FEC_VEN_DTB.SelStart = 0;
                    ID_MEM_FEC_VEN_DTB.SelLength = Strings.Len(ID_MEM_FEC_VEN_DTB.defaultText);
                    result = "Fecha de Vencimiento";
                    ID_MEM_FEC_VEN_DTB.Focus();
                    return result;

                    if (ID_MEM_FEC_VEN_DTB.CtlText != CORVB.NULL_STRING)
                    {
                        pszFecha = ID_MEM_FEC_VEN_DTB.CtlText;

                        if (Strings.Mid(ID_MEM_FEC_VEN_DTB.CtlText, 1, 2).Length == CORVB.NULL_INTEGER)
                        {
                            Fichero(CORVB.NULL_INTEGER);
                            ID_MEM_FEC_VEN_DTB.Focus();
                            result = "Día en la Fecha de Vencimiento";
                            ID_MEM_FEC_VEN_DTB.CtlText = pszFecha;
                            return result;
                        }

                        if (Strings.Mid(ID_MEM_FEC_VEN_DTB.CtlText, 4, 2).Length == CORVB.NULL_INTEGER)
                        {
                            Fichero(CORVB.NULL_INTEGER);
                            ID_MEM_FEC_VEN_DTB.Focus();
                            result = "Mes en la Fecha de Vencimiento";
                            ID_MEM_FEC_VEN_DTB.CtlText = pszFecha;
                            return result;
                        }

                        if (Strings.Mid(ID_MEM_FEC_VEN_DTB.CtlText, 7, 4).Length < 4)
                        {
                            Fichero(CORVB.NULL_INTEGER);
                            ID_MEM_FEC_VEN_DTB.Focus();
                            result = "Año en la Fecha de Vencimiento";
                            ID_MEM_FEC_VEN_DTB.CtlText = pszFecha;
                            return result;
                        }
                    }

                }
                else if (!Double.TryParse(mskPorcientoMinimo1.defaultText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
                {
                    Fichero(0);
                    mskPorcientoMinimo1.Focus();
                    result = "Porcentaje Mínimo de pago";
                    mskPorcientoMinimo1.defaultText = "0";
                    return result;

                }
                else if (Conversion.Val(mskPorcientoMinimo1.defaultText) < 0)
                {
                    Fichero(0);
                    mskPorcientoMinimo1.Focus();
                    MessageBox.Show("El Porcentaje mínimo de pago no puede ser menor de 0", "Porcentaje Mínimo de pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    result = "Porcentaje Mínimo de pago";
                    mskPorcientoMinimo1.defaultText = "0";
                    return result;

                }
                else if (Conversion.Val(mskPorcientoMinimo1.defaultText) > 100)
                {
                    Fichero(0);
                    mskPorcientoMinimo1.defaultText = "100";
                    mskPorcientoMinimo1.SelStart = 1;
                    mskPorcientoMinimo1.SelLength = Strings.Len(mskPorcientoMinimo1.defaultText);
                    mskPorcientoMinimo1.Focus();
                    MessageBox.Show("El Porcentaje mínimo de pago no puede ser mayor de 100", Application.ProductName);
                    return "Porcentaje Mínimo de pago";

                }
                else if (Conversion.Val(mskMontoMinimo.defaultText) < 0)
                {
                    Fichero(0);
                    mskMontoMinimo.Focus();
                    MessageBox.Show("El monto mínimo a facturar no puede ser menor de 0", Application.ProductName);
                    mskMontoMinimo.SelStart = 0;
                    mskMontoMinimo.SelLength = Strings.Len(mskMontoMinimo.defaultText);
                    result = "Monto Mínimo a Facturar";
                    mskPorcientoMinimo1.defaultText = "0";
                    return result;

                }
                else if (Conversion.Val(mskDiaCorte.defaultText) <= 0)
                {
                    Fichero(0);
                    mskDiaCorte.Focus();
                    MessageBox.Show("El día de corte no puede ser menor de 1", Application.ProductName);
                    return "Día de Corte";

                }
                else if (Conversion.Val(mskDiaCorte.defaultText) > 28)
                {
                    Fichero(0);
                    mskDiaCorte.Focus();
                    MessageBox.Show("El día de corte no puede ser mayor de 28", Application.ProductName);
                    return "Día de Corte";

                }
                else if (Conversion.Val(mskPeriodoGracia.defaultText) <= 0)
                {
                    Fichero(0);

                    mskPeriodoGracia.Mask = "";
                    mskPeriodoGracia.SelStart = 0;
                    mskPeriodoGracia.SelLength = Strings.Len(mskPeriodoGracia.defaultText);
                    mskPeriodoGracia.Focus();
                    MessageBox.Show("El período de gracia no puede ser menor de 1", Application.ProductName);
                    return "Período de gracia";

                }
                else if (Conversion.Val(mskPeriodoGracia.defaultText) > 31)
                {
                    Fichero(0);
                    mskPeriodoGracia.Focus();
                    MessageBox.Show("El periodo de gracia no puede ser mayor de 31", Application.ProductName);
                    return "Período de gracia";


                }
                else if (Conversion.Val(mskPerNoInteres.defaultText) < 0)
                {
                    Fichero(0);
                    mskPerNoInteres.Focus();
                    MessageBox.Show("El período de no cobro de interéses no puede ser menor de 0", Application.ProductName);
                    return "Período de gracia";

                }
                else if (Conversion.Val(mskDiaCorte.defaultText) > 31)
                {
                    Fichero(0);
                    mskPerNoInteres.Focus();
                    MessageBox.Show("El período de no cobro de interéses no puede ser mayor de 31", Application.ProductName);
                    return "Período de gracia";

                }
                else if (ID_MEM_DOM_EB[0].Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(1);
                    ID_MEM_DOM_EB[0].Focus();
                    return "Calle y Número Fiscal";

                }
                else if (ID_MEM_COL_EB[0].Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(1);
                    ID_MEM_COL_EB[0].Focus();
                    return "Colonia Fiscal";

                }
                else if (ID_MEM_PDM_EB[0].Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(1);
                    ID_MEM_PDM_EB[0].Focus();
                    return "Poblacion Fiscal";

                }
                else if (ID_MEM_CIU_EB[0].Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(1);
                    ID_MEM_CIU_EB[0].Focus();
                    return "Ciudad Fiscal";

                }
                else if (StringsHelper.DoubleValue(ID_MEM_EDO_EB[0].SelectedIndex.ToString().Trim()) < 0)
                {
                    Fichero(1);
                    ID_MEM_EDO_EB[0].Focus();
                    return "Estado Fiscal";

                }
                else if (Conversion.Val(ID_MEM_CP_PIC[0].CtlText) == CORVB.NULL_INTEGER)
                {
                    Fichero(1);
                    ID_MEM_CP_PIC[0].Focus();
                    return "Código Postal Fiscal";

                }
                else if (ID_MEM_DOM_EB[1].Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(1);
                    ID_MEM_DOM_EB[1].Focus();
                    return "Calle y Número de Envío";

                }
                else if (ID_MEM_COL_EB[1].Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(1);
                    ID_MEM_COL_EB[1].Focus();
                    return "Colonia de Envío";

                }
                else if (ID_MEM_PDM_EB[1].Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(1);
                    ID_MEM_PDM_EB[1].Focus();
                    return "Poblacion / Delegación de Envío";

                }
                else if (ID_MEM_CIU_EB[1].Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(1);
                    ID_MEM_CIU_EB[1].Focus();
                    return "Ciudad de Envío";

                }
                else if (StringsHelper.DoubleValue(ID_MEM_EDO_EB[1].SelectedIndex.ToString().Trim()) < 0)
                {
                    Fichero(1);
                    ID_MEM_EDO_EB[1].Focus();
                    return "Estado de Envío";

                }
                else if (Conversion.Val(ID_MEM_CP_PIC[1].CtlText) == CORVB.NULL_INTEGER)
                {
                    Fichero(1);
                    ID_MEM_CP_PIC[1].Focus();
                    return "Código Postal de Envío";

                }

                //    If Not (bfncExcepcionCredito = True And Tag = TAG_CAMBIO) Then
                int iExisten_Blancos = CORVB.NULL_INTEGER;
                for (int iCont = 0; iCont <= 2; iCont++)
                {
                    if (ID_MEM_NOM_EB[iCont].Text.Trim() == CORVB.NULL_STRING)
                    {
                        iExisten_Blancos++;
                    }
                    if (ID_MEM_PUE_EB[iCont].Text.Trim() == CORVB.NULL_STRING)
                    {
                        iExisten_Blancos++;
                    }
                }

                if (iExisten_Blancos == 6)
                {
                    Fichero(2);
                    ID_MEM_REP_3OD[CORVB.NULL_INTEGER].Refresh();
                    ID_MEM_REP_3OD[CORVB.NULL_INTEGER].Focus();
                    ID_MEM_REP_3OD_CheckedChanged(ID_MEM_REP_3OD[CORVB.NULL_INTEGER], new EventArgs());
                    ID_MEM_NOM_EB[CORVB.NULL_INTEGER].Focus();
                    return "Datos de por lo menos un Representante";

                }
                else if ((iExisten_Blancos % 2) != 0)
                {
                    Fichero(2);
                    ID_MEM_REP_3OD[CORVB.NULL_INTEGER].Refresh();
                    ID_MEM_REP_3OD[CORVB.NULL_INTEGER].Focus();
                    ID_MEM_REP_3OD_CheckedChanged(ID_MEM_REP_3OD[CORVB.NULL_INTEGER], new EventArgs());
                    ID_MEM_NOM_EB[CORVB.NULL_INTEGER].Focus();
                    return "Datos de alguno de los Representantes";

                }

                if (ID_MEM_NOM_EB[0].Text.Trim() != CORVB.NULL_STRING && ID_MEM_PUE_EB[0].Text.Trim() != CORVB.NULL_STRING)
                {
                    if (~CORVAR.bgblFirma1 != 0)
                    {
                        Fichero(2);
                        ID_MEM_REP_3OD[CORVB.NULL_INTEGER].Refresh();
                        ID_MEM_REP_3OD[CORVB.NULL_INTEGER].Focus();
                        ID_MEM_REP_3OD_CheckedChanged(ID_MEM_REP_3OD[CORVB.NULL_INTEGER], new EventArgs());
                        ID_MEM_FIR_PB.Focus();
                        return "Firma del representante 1";
                    }
                }

                if (ID_MEM_NOM_EB[1].Text.Trim() != CORVB.NULL_STRING && ID_MEM_PUE_EB[1].Text.Trim() != CORVB.NULL_STRING)
                {
                    if (~CORVAR.bgblFirma2 != 0)
                    {
                        Fichero(2);
                        ID_MEM_REP_3OD[CORVB.NULL_INTEGER].Refresh();
                        ID_MEM_REP_3OD[1].Focus();
                        ID_MEM_REP_3OD_CheckedChanged(ID_MEM_REP_3OD[1], new EventArgs());
                        ID_MEM_FIR_PB.Focus();
                        return "Firma del representante 2";
                    }
                }

                if (ID_MEM_NOM_EB[2].Text.Trim() != CORVB.NULL_STRING && ID_MEM_PUE_EB[2].Text.Trim() != CORVB.NULL_STRING)
                {
                    if (~CORVAR.bgblFirma3 != 0)
                    {
                        Fichero(2);
                        ID_MEM_REP_3OD[CORVB.NULL_INTEGER].Refresh();
                        ID_MEM_REP_3OD[2].Focus();
                        ID_MEM_REP_3OD_CheckedChanged(ID_MEM_REP_3OD[2], new EventArgs());
                        ID_MEM_FIR_PB.Focus();
                        return "Firma del representante 3";
                    }
                }


                if (ID_MEM_NOM_COB.Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(3);
                    ID_MEM_NOM_COB.Focus();
                    return "Nómina del Ejecutivo Banamex";
                }
                else if (ID_MEM_CON_TXT.Text.Trim() == CORVB.NULL_STRING)
                {
                    Fichero(3);
                    ID_MEM_CON_TXT.Focus();
                    return "Teléfono";
                }

                if (Conversion.Val(ID_MEM_SUC_ITB.CtlText) < 0)
                { // it
                    Fichero(4);
                    ID_MEM_SUC_ITB.Focus();
                    return "Sucursal cta. ejecutivo";
                }
                else if (Conversion.Val(ID_MEM_NMC_FTB.CtlText) == CORVB.NULL_INTEGER)
                {
                    Fichero(4);
                    ID_MEM_NMC_FTB.Focus();
                    return "Cuenta de ejecutivo";
                }

                if (Conversion.Val(ID_MEM_NMC_FTB.CtlText) == CORVB.NULL_INTEGER)
                {
                    if (ID_MEM_TPA_3OPB[0].Checked)
                    {
                        Fichero(4);
                        ID_MEM_NMC_FTB.Focus();
                        return "Cuenta de Captación";
                    }
                }
                    if (ID_MEM_SUC_ITB.CtlText.Equals(String.Empty))
                    {
                        Fichero(4);
                        ID_MEM_SUC_ITB.Focus();
                        return "Sucursal";
                    }

                if (ID_MEM_MES_FIS_CBO.SelectedIndex < 0)
                {
                    Fichero(4);
                    result = "Mes Fiscal";
                    ID_MEM_MES_FIS_CBO.Focus();
                    return result;
                }

                //UPGRADE_WARNING: (1041) IsEmpty was upgraded to a comparison and has a new behavior.
                if (String.IsNullOrEmpty(slTipoFactura.Trim()))
                {
                    Fichero(4);
                    result = "Tipo de Facturación";
                    ID_MEM_TFA_3OPB[1].Focus();
                    MessageBox.Show("Seleccione el tipo de facturación para esta empresa.", "Tipo de facturación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                double dbNumericTemp2 = 0;
                if (!Double.TryParse(mskMCC.defaultText, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp2) || mskMCC.defaultText.Trim() == CORVB.NULL_STRING)
                {
                    mskMCC.CtlText = "0";
                }
                //UPGRADE_WARNING: (1068) Nvl(ID_MEM_CRE_FTB, 0) of type Variant is being forced to double.
                //UPGRADE_WARNING: (1041) Mod has a new behavior.
                if (Convert.ToDouble(MdlCambioMasivo.Nvl(ID_MEM_CRE_FTB.defaultText, 0)) % 5 != 0)
                {
                    MdlCambioMasivo.MsgInfo("El limite de credito asignado debe de ser Multiplo de $ 5.00");
                    result = "Crédito Disponible";

                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }


            return result;
        }

        public void Fichero(int iIndice)
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                if (this.mskDiaCorte.CtlText != "0")
                {

                    switch (iIndice)
                    {
                        case 0:
                            ID_MEM_TEX_PNL[0].Visible = true;
                            ID_MEM_TEX_PNL[1].Visible = true;
                            ID_MEM_TEX_PNL[2].Visible = true;
                            //'        ID_MEM_CTA_FRM.Visible = True 
                            if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
                            {
                                ID_MEM_NLG_EB.Focus();
                            }
                            ID_MEM_DG_SSP.SelectedIndex = iIndice;
                            break;
                        case 1:
                            if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
                            {
                                ID_MEM_DOM_EB[0].Focus();
                            }
                            ID_MEM_DG_SSP.SelectedIndex = iIndice;
                            break;
                        case 2:
                            if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
                            {
                                ID_MEM_REP_3OD[0].Focus();
                            }
                            ID_MEM_DG_SSP.SelectedIndex = iIndice;
                            break;
                        case 3:
                            if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
                            {
                                ID_MEM_CON_TXT.Focus();
                            }
                            ID_MEM_DG_SSP.SelectedIndex = iIndice;
                            break;
                        case 4:
                            if (this.Tag.ToString() != CORCONST.TAG_CONSULTA)
                            {
                                ID_MEM_MES_FIS_CBO.Focus();
                            }
                            ID_MEM_DG_SSP.SelectedIndex = iIndice;
                            break;
                    }
                }
                else
                {
                    mskDiaCorte.Focus();
                    ID_MEM_DG_SSP.SelectedIndex = 0;
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }




        //****************************************************************************
        //**                                                                        **
        //**       Descripción:                                                     **
        //**                   Inserta en la tabla de MTCCAM01 a todos los          **
        //**                   ejecutivos que pertenecen a la empresa               **
        //**                                                                        **
        //**       Paso de parámetros:Numero de la empresa, grupo                   **
        //**                                                                        **
        //**       Valor de Regreso: Funcion booleana                               **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 12oct98                                     **
        //**                                                                        **
        //****************************************************************************

        private bool InsertaTablaCambios(ref  string pszNumEmp, ref  string pszGpoBanco,ref string pszTipo,ref string pszNomEmp)
        {

            bool result = false;
            //string pszNomEmp = String.Empty;
            //string pszTipo = String.Empty;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                bHayReg = false;

                //Inserta en la tabla de MTCCAM01 que es la tabla de cambios masivos los datos del Tarjetahabiente

                this.Cursor = Cursors.WaitCursor;

                //Lee el nombre de la empresa
                /*   SE QUITA PORQUE pszTipo SE PASARA COMO PARAMETRO
                  CORVAR.pszgblsql = "select emp_nom,emp_tipo_envio from MTCEMP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmp;

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            pszNomEmp = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                            pszTipo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        }
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    if (ID_MEM_EEC_3OPB[0].Checked)
                    {
                        pszTipo = "Empresa";
                    }
                    else if (ID_MEM_EEC_3OPB[1].Checked)
                    {
                        pszTipo = "Individual";
                    }
                 
                    */

                //Consulta anterior - Algunos ejecutivos no aparecen en THS
                //01112002 Ariadna ----  Desligar EJE de THS

                CORVAR.pszgblsql = "select";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " EJE.emp_num AS eje_num";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEJE01 EJE";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " EJE.eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " AND EJE.gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " AND EJE.emp_num = " + pszNumEmp;

                //Fin 01112002 Ariadna

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        bHayReg = true;
                    }
                }
                else
                {
                    bHayReg = false;
                    result = true;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                if (bHayReg)
                {
                    //lee los tarjetahabientes de la empresa y los inserta en la tabla de cambios masivos
                    //EISSA 05.11.2001 Código Nuevo para extraer todos los tarjetahabientes que en caso de no encontrarse en MTCEJE01
                    //se obtendrán desde MTCTHS01, así mismo traeremos con preferencia la información de THS para reflejar si ha
                    //habido cambio en el correspondiente al roll over y el digito verificador

                    //    '20021121 ---Ariadna---
                    prBorraCambiosRepetidos(pszNumEmp, pszGpoBanco, pszTipo);
                    //***************************

                    //Inserción anterior que utiliza MTCTHS01

                    CORVAR.pszgblsql = "insert " + CORBD.DB_SYS_CAM + " SELECT  ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " isnull(" + CORBD.DB_SYB_THS + ".eje_prefijo, " + CORBD.DB_SYB_EJE + ".eje_prefijo) AS eje_prefijo";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_THS + ".gpo_banco, " + CORBD.DB_SYB_EJE + ".gpo_banco) AS gpo_banco";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_THS + ".emp_num, " + CORBD.DB_SYB_EJE + ".emp_num) AS emp_num";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_THS + ".eje_num, " + CORBD.DB_SYB_EJE + ".eje_num) AS eje_num";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_THS + ".eje_roll_over, " + CORBD.DB_SYB_EJE + ".eje_roll_over) AS eje_roll_over";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_THS + ".eje_digit, " + CORBD.DB_SYB_EJE + ".eje_digit) AS eje_digit";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_nombre, " + CORBD.DB_SYB_THS + ".ths_nombre) AS eje_nombre";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_calle, " + CORBD.DB_SYB_THS + ".ths_direccion_1) AS eje_calle";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_col, " + CORBD.DB_SYB_THS + ".ths_direccion_2) as colonia";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_pob, " + CORBD.DB_SYB_THS + ".ths_direccion_3) as poblacion";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_zp, " + CORBD.DB_SYB_THS + ".ths_zona_postal) as zona_postal";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_cp, " + CORBD.DB_SYB_THS + ".ths_codigo_postal) as codigo_postal";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", case when " + CORBD.DB_SYB_EJE + ".eje_num = 0 then";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "       '" + ID_MEM_CON_TXT.Text.ToString().Trim()+"'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " else ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " isnull(" + CORBD.DB_SYB_EJE + ".eje_tel_dom,  '') ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " End   TEL_PARTICULAR";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", case when " + CORBD.DB_SYB_EJE + ".eje_num = 0 then";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "       '" + ID_MEM_CON_TXT.Text.ToString().Trim()+"'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " else ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " isnull(" + CORBD.DB_SYB_EJE + ".eje_tel_ofi,  '') ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " End   TEL_OFICINA";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", case when " + CORBD.DB_SYB_EJE + ".eje_num = 0 then";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "       '" + ID_MEM_TEL_EXT_TXT.Text.ToString().Trim()+"'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " else ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " isnull(" + CORBD.DB_SYB_EJE + ".eje_ext,  '') ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " End   TEL_EXTENSION";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_tel_dom,  '') as tel_particular";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_tel_ofi, '') as tel_oficina";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_ext, '') as extension";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_sexo, " + CORBD.DB_SYB_THS + ".ths_sexo) AS sexo";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_acti_subacti, '') as acti_subact";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", ''";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_sueldo,0)";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", isnull(" + CORBD.DB_SYB_EJE + ".eje_suc_trans, '') as suc_trans";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", 0, 0, '" + pszNomEmp + "', '" + ID_MEM_DOM_EB[1].Text + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + ID_MEM_COL_EB[1].Text + "', '" + ID_MEM_PDM_EB[1].Text + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex] + "', " + ID_MEM_CP_PIC[1].CtlText + ", 'No Proce'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", ' ', 'DomicilioEmp', '" + DateTime.Today.ToString("MM/dd/yyyy") + "', '" + pszTipo + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ", case when " + CORBD.DB_SYB_EJE + ".eje_num = 0 then";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "       '" + Strings.Replace(ID_MEM_RFC_MKE.defaultText, "-", "", 1, -1, CompareMethod.Binary) + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " else ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "      isnull(" + CORBD.DB_SYB_EJE + ".eje_rfc, '') ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " End   RFC";


                    CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM " + CORBD.DB_SYB_THS + ", " + CORBD.DB_SYB_EJE;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + CORBD.DB_SYB_EJE + ".eje_prefijo *= " + CORBD.DB_SYB_THS + ".eje_prefijo ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_EJE + ".gpo_banco *= " + CORBD.DB_SYB_THS + ".gpo_banco ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_EJE + ".emp_num *= " + CORBD.DB_SYB_THS + ".emp_num ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_EJE + ".eje_num *= " + CORBD.DB_SYB_THS + ".eje_num ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_EJE + ".eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_THS + ".eje_prefijo = " + CORVAR.igblPref.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_EJE + ".gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_THS + ".gpo_banco = " + CORVAR.igblBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_EJE + ".emp_num = " + pszNumEmp;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_THS + ".emp_num = " + pszNumEmp;
                    if (pszTipo == "I")
                    {
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_EJE + ".eje_num = 0";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " AND " + CORBD.DB_SYB_THS + ".eje_num = 0";
                    }

                    //Nueva inserción que sólo utiliza los datos de MTCEJE01 ------ Ariadna ------ 01112002
                    //        pszgblsql = "insert " & DB_SYS_CAM & " SELECT  "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_prefijo AS eje_prefijo,"
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".gpo_banco AS gpo_banco,"
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".emp_num AS emp_num,"
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_num AS eje_num,"
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_roll_over AS eje_roll_over,"
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_digit AS eje_digit,"
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_nombre, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_calle, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_col, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_pob, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_zp, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_cp, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_tel_dom, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_tel_ofi, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_ext, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_sexo, "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_acti_subacti, "
                    //        pszgblsql = pszgblsql & "'', "
                    //        pszgblsql = pszgblsql & "isnull(" & DB_SYB_EJE & ".eje_sueldo,0), "
                    //        pszgblsql = pszgblsql & "isnull(" & DB_SYB_EJE & ".eje_suc_trans, '') as suc_trans, "
                    //        pszgblsql = pszgblsql & " 0, 0, '" & pszNomEmp & "', '" & ID_MEM_DOM_EB(1).Text & "'"

                    //04112002 ------Ariadna-------
                    //Nueva línea

                    //        pszgblsql = pszgblsql & ", '" & ID_MEM_COL_EB(1).Text & "', '" & ID_MEM_PDM_EB(1).Text & "'"

                    //04112002 ----Ariadna-----
                    //Se comenta la siguiente línea para que los datos
                    //que se modifiquen o se den de alta para población sean los
                    //que corresponden a la población,delegación o municipio y no a la ciudad

                    //pszgblsql = pszgblsql & ", '" & ID_MEM_COL_EB(1).Text & "', '" & ID_MEM_CIU_EB(1).Text & "'"

                    //        pszgblsql = pszgblsql & ",'" & asgEstados(0, ID_MEM_EDO_EB(1).ListIndex) & "', " & ID_MEM_CP_PIC(1).Text & ", 'No Proce'"
                    //        pszgblsql = pszgblsql & ", ' ', 'DomicilioEmp', '" & Format(Date, "mm/dd/yyyy") & "', '" & pszTipo & "'"
                    //        pszgblsql = pszgblsql & ", isnull(" & DB_SYB_EJE & ".eje_rfc, '') as RFC"
                    //        pszgblsql = pszgblsql & " FROM " & DB_SYB_EJE
                    //        pszgblsql = pszgblsql & " WHERE "
                    //        pszgblsql = pszgblsql & DB_SYB_EJE & ".eje_prefijo = " & gprdProducto.PrefijoL
                    //        pszgblsql = pszgblsql & " AND " & DB_SYB_EJE & ".gpo_banco = " & gprdProducto.BancoL
                    //        pszgblsql = pszgblsql & " AND " & DB_SYB_EJE & ".emp_num = " & pszNumEmp

                    //20021121 ---Ariadna---
                    //        If pszTipo = "Individual" Then
                    //            pszgblsql = pszgblsql & " AND " & DB_SYB_EJE & ".eje_num = 0"
                    //        End If

                    //Fin Nueva Inserción ......

                    //EISSA 05.11.2001 Fin de código Nuevo
                    result = CORPROC2.Modifica_Registro() != 0;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        private void cboEstructuraGastos_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            if (cboEstructuraGastos.SelectedIndex >= 0)
            {
                llEstructuraGastos = VB6.GetItemData(cboEstructuraGastos, cboEstructuraGastos.SelectedIndex);
            }
            else
            {
                llEstructuraGastos = 0;
            }
        }

        //UPGRADE_NOTE: (7001) The following declaration (Check1_Click) seems to be dead code
        //private void  Check1_Click()
        //{
        //
        //}
        private void chkCheckBox_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(chkCheckBox, eventSender);
            CheckState ilValorAnterior = (CheckState)0;
            int ilUnidades = 0;
            if (chkCheckBox[Index].CheckState == CheckState.Checked)
            {
                switch (Index)
                {
                    case 0:  //Generar SBF (Por corte) 
                        ilValorAnterior = chkCheckBox[0].CheckState;
                        ilUnidades = CRSGeneral.lfncCargaUnidades(null, 0, CORVAR.lgblNumEmpresa);
                        if (ilUnidades <= 0)
                        {
                            MessageBox.Show("No puede activar esta opción de SBF, porque esta empresa no tiene unidades asociadas." + "\r\n" + "Para generar SBF es necesario agregarle unidades a esta empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkCheckBox[0].CheckState = CheckState.Unchecked;
                            chkCheckBox[2].Enabled = false;
                            chkCheckBox[2].CheckState = CheckState.Unchecked;
                        }
                        else
                        {
                            chkCheckBox[2].Enabled = true;
                            chkCheckBox[2].CheckState = CheckState.Unchecked;
                            ilGeneraSBF = (int)ifncSBF();
                        }
                        break;
                    case 1:  //Generar Reporte de detalle de Movimiento 
                        ilValorAnterior = chkCheckBox[1].CheckState;
                        ilUnidades = CRSGeneral.lfncCargaUnidades(null, 0, CORVAR.lgblNumEmpresa);
                        if (ilUnidades <= 0)
                        {
                            MessageBox.Show("No puede activar esta opción de Generador de Detalle de Movimientos " + "\r\n" + "debido a que esta empresa no tiene unidades asociadas." + "\r\n" + "Para generar el derivado de movimientos es necesario agregarle unidades a esta empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkCheckBox[1].CheckState = CheckState.Unchecked;
                        }
                        else
                        {
                            ilGeneraSBF = (int)ifncSBF();
                        }
                        break;
                    case 2:  //Generar SBF (Diario)     Sólo se puede activar si el Genera SBF por corte se Activa 
                        ilValorAnterior = chkCheckBox[2].CheckState;
                        if (chkCheckBox[0].CheckState == CheckState.Unchecked)
                        {
                            MessageBox.Show("No puede activar esta opción de SBF (Diario) porque no está activada la opción de Generar SBF(Por Corte)." + "\r\n" + "Para generar SBF Diario es necesario necesario activar la opción de Generar SBF (Por Corte).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chkCheckBox[2].CheckState = CheckState.Unchecked;
                        }
                        ilGeneraSBF = (int)ifncSBF();
                        break;
                }
            }
            else
            {
                switch (Index)
                {
                    case 0:
                        chkCheckBox[2].CheckState = CheckState.Unchecked;
                        ilGeneraSBF = (int)ifncSBF();
                        break;
                    default:
                        ilGeneraSBF = (int)ifncSBF();
                        break;
                }
            }
        }

        private void chkCheckBox_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            int Index = Array.IndexOf(chkCheckBox, eventSender);
            if (Index == 1)
            {
                if (KeyAscii == ((int)"\t"[0]))
                {
                    Fichero(0);
                }
                else
                {
                }
            }
            else
            {
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void CORMNEMP_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                int iExistenEmp = 0;
                int iExistenEjec = 0;
                int iResp = 0;
                string pszTempGrupo = String.Empty;

                //UPGRADE_TODO: (1065) Error handling statement (On Error Resume Next) could not be converted properly. A throw statement was generated instead.
                //throw new Exception("Migration Exception: 'On Error Resume Next' not supported");

                if (CORVAR.igblCancela != 0)
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORSTR.STR_LEE_BD;
                int iPos = (CORVAR.pszgblNomGrupo.IndexOf(Strings.Chr(0).ToString()) + 1);

                if (iPos > CORVB.NULL_INTEGER)
                {
                    ID_MEM_TEX_PNL[0].Text = Strings.Mid(CORVAR.pszgblNomGrupo, 1, CORVAR.pszgblNomGrupo.IndexOf(Strings.Chr(0).ToString())).Trim();
                }
                else
                {
                    ID_MEM_TEX_PNL[0].Text = CORVAR.pszgblNomGrupo;
                }

                Fichero(0);
                optEmpresa[0].Checked = true;
                /*Yuria agrega mskMCC 16/07/09 */
                mskMCC.CtlText = "0000";
                mskMCC.Enabled = false;
                // APQ 1-Jul-2010 Inicio - Cambio Tipo Bloqueo
                mdlParametros.igEmpTipoBloqueo = 0;
                // APQ 1-Jul-2010 Fin - Cambio Tipo Bloqueo
                mtcEjeEmpOriginal.sEjeCuentaBanamex = sfncCuentaEmpresarial();
                ID_MEM_TEX_PNL[3].Text = mtcEjeEmpOriginal.sEjeCuentaBanamex;


                switch (this.Tag.ToString())
                {
                    case CORCONST.TAG_CAMBIO:

                        ID_MEM_FIR_PB.Text = "Capturar &Firmas";
                        iExistenEmp = Obtiene_DatosEmpresa();
                        mskDiaCorte.Enabled = false;
                        if (iErr != CORCONST.OK)
                        {
                            this.Close();
                            CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORVB.NULL_STRING;
                            return;
                        }
                        ID_MEM_NLG_EB.Focus();
                        ID_MEM_ETT_PNL[1].Enabled = true;
                        fraDatosAdicionales[3].Enabled = false;
                        fraEmpresa.Enabled = true;
                        /*Yuria agrega optEmpresa 0,1,2 16/07/09 */
                        optEmpresa[0].Enabled = true;
                        optEmpresa[1].Enabled = true;
                        optEmpresa[2].Enabled = true;
                        /*_optEmpresa_0.Enabled = true;
                        _optEmpresa_1.Enabled = true;
                        _optEmpresa_2.Enabled = true;*/
                        mskMCC.Enabled = true;
                        ID_MEM_NCT_EB.Enabled = false;  //El nombre corto no puede ser modificado 
                        txtAtencionA.Enabled = true;  //FSWB NR 20070227 Se incluyen campos Atencion A y Persona 
                        ID_MEM_PERSONA.Enabled = true;  //FSWB NR 20070227 


                        break;
                    case CORCONST.TAG_CONSULTA:
                        ID_MEM_FIR_PB.Text = "Consulta &Firmas";
                        iExistenEmp = Obtiene_DatosEmpresa();
                        
                        if (iErr != CORCONST.OK)
                        {
                            this.Close();
                            CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORVB.NULL_STRING;
                            return;
                        }

                        ID_MEM_TEX_PNL[0].Visible = true;
                        ID_MEM_TEX_PNL[1].Visible = true;
                        ID_MEM_TEX_PNL[2].Visible = true;
                        ID_MEM_NOM_TXT.Visible = true;
                        ID_MEM_NOM_COB.Visible = false;
                        ID_MEM_ETT_PNL[1].Enabled = true;
                        ID_MEM_OK_PB.Enabled = false;
                        ID_MEM_DGR_FRM.Enabled = false;
                        ID_MEM_REP_PNL[0].Enabled = false;
                        ID_MEM_REP_PNL[1].Enabled = false;
                        ID_MEM_REP_PNL[2].Enabled = false;
                        ID_MEM_DOM_PNL[0].Enabled = false;
                        ID_MEM_DOM_PNL[1].Enabled = false;
                        ID_MEM_DGR_FRM.Enabled = false;
                        ID_MEM_DOM_PNL[0].Enabled = false;
                        ID_MEM_DOM_PNL[1].Enabled = false;
                        ID_MEM_REP_PNL[2].Enabled = false;
                        ID_MEM_TEL_FRM.Enabled = false;
                        ID_MEM_CEJ_FRM.Enabled = false;
                        ID_MEM_EJE_FRM.Enabled = false;
                        try
                        {
                            fraDatosAdicionales[0].Enabled = false;
                        }
                        catch { }
                        try
                        {
                            fraDatosAdicionales[1].Enabled = false;
                        }
                        catch { }
                        try
                        {
                            fraDatosAdicionales[2].Enabled = false;
                        }
                        catch  { }
                        try
                        {
                            fraDatosAdicionales[3].Enabled = false;
                        }
                        catch  { }
                        try
                        {
                            fraDatosAdicionales[4].Enabled = false;
                        }
                        catch { }
                        try
                        {
                            fraDatosAdicionales[5].Enabled = false;
                        }
                        catch  { }
                        try
                        {
                            fraDatosAdicionales[6].Enabled = false;
                        }
                        catch { }
                        try
                        {
                            ID_MEM_OK_PB.Enabled = false;
                        }
                        catch { }
                        try
                        {
                            ID_MEM_OK_PB.Visible = false;
                        }
                        catch { }
                        try
                        {
                            ID_MEM_NNA_EB.Visible = true;
                        }
                        catch { }
                        try
                        {
                            ID_MEM_ETT_TXT[1].Visible = false;
                        }
                        catch  { }
                        ID_MEM_BUS_PB.Visible = false;
                        ID_MEM_BOR_PB.Enabled = false;
                        ID_MEM_CAN_PB.Focus();
                        cboEstructuraGastos.Enabled = false;
                        ID_MEM_MES_FIS_CBO.Enabled = false;
                        _ID_MEM_MES_FIS_LBL_0.Enabled = false;
                        _ID_MEM_ETT_TXT_39.Enabled = false;
                        mskMCC.Enabled = false;
                        _ID_MEM_MES_FIS_LBL_1.Enabled = false;
                        chkSkipPayment.Enabled = false;
                        fraEmpresa.Enabled = false;
                        txtAtencionA.Enabled = false;  //FSWB NR 20070227 
                        ID_MEM_PERSONA.Enabled = false;  //FSWB NR 20070227
                        _ID_MEE_ETT_TXT_7.Enabled = false;
                        _ID_MEE_ETT_TXT_9.Enabled = false;

                        break;
                    default:
                        if (this.Tag.ToString() == CORCONST.TAG_ALTA)
                        {
                            ID_MEM_TEX_PNL[3].Text = "Cuenta Nueva";
                            chkSkipPayment.Enabled = true;
                            chkCheckBox[0].Enabled = false;
                            chkCheckBox[1].Enabled = false;
                            mskMontoMinimo.defaultText = "50";
                            ID_MEM_TFA_3OPB[1].Checked = true;
                            ID_MEM_NOM_COB.SelectedIndex = -1;
                            txtAtencionA.Enabled = true; //FSWB NR 20070227
                            ID_MEM_PERSONA.Enabled = true; //FSWB NR 20070227

                        }
                        do
                        {
                            ID_MEM_TEX_PNL[2].Visible = false;
                            ID_MEM_ETT_PNL[2].Visible = false;
                            iExistenEjec = Obtiene_Ejecutivos();
                            if (iErr == CORCONST.OK)
                            {
                                if (~iExistenEjec != 0)
                                {
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    iResp = (int)Interaction.MsgBox("No existe ejecutivos en Catálogo " + Strings.Chr(CORVB.KEY_RETURN).ToString() + "¿Desea dar de Alta ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                                    this.Cursor = Cursors.WaitCursor;
                                    if (iResp == CORVB.IDYES)
                                    {
                                        //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                                        CORMNEJB.DefInstance.ShowDialog();
                                    }
                                }
                                else
                                {
                                    ID_MEM_NOM_COB.SelectedIndex = CORVB.NULL_INTEGER;
                                    ID_MEM_NLG_EB.Focus();
                                }
                            }
                            else
                            {
                                this.Close();
                                break;
                            }
                        }
                        while ((((iResp == CORVB.IDNO) ? -1 : 0) | iExistenEjec) == 0);
                        break;
                }
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORVB.NULL_STRING;
                bVerFirmas = (false).ToString();
                ID_MEM_TEX_PNL[0].Visible = true;
                ID_MEM_TEX_PNL[1].Visible = true;
                ID_MEM_TEX_PNL[2].Visible = true;
                ID_MEM_TEX_PNL[0].Refresh();
                ID_MEM_DG_SSP.Visible = false;
                ID_MEM_DG_SSP.Visible = true;


                if ((CORVAR.igblPref == 5473 && CORVAR.igblBanco == 80) || (CORVAR.igblPref == 5475 && CORVAR.igblBanco == 14))
                {
                    ID_MEM_TFA_3OPB[0].Enabled = false;
                }

                this.Cursor = Cursors.Default;

            }
        }


        private void CORMNEMP_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                //Carga los meses del año en el combo de meses
                //    prConfiguracion

                int tempRefParam = 0;
                ID_MEM_DG_SSP_SelectedIndexChanged(ID_MEM_DG_SSP, new EventArgs()); //FSWB NR 20070227 activar el primer tab por default

                lcteCliente = new clsCliente();

                string tempRefParam2 = sfncQueries(0);
                CRSParametros.prCargaCombo(ref tempRefParam2, cboEstructuraGastos);
                CRSGeneral.prCargaMesesEnCombo(ID_MEM_MES_FIS_CBO);
                ID_MEM_MES_FIS_CBO.SelectedIndex = 0;

                this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
                this.Top = (int)VB6.TwipsToPixelsY(1530);
                this.Cursor = Cursors.WaitCursor;
                CORVAR.igblCancela = 0;
                CORVAR.bgblModFirma = 0;
                CORCTEMP.DefInstance.Top = (int)VB6.TwipsToPixelsY(CORVB.NULL_INTEGER);
                CORVAR.bgblFirma1 = 0;
                CORVAR.bgblFirma2 = 0;
                CORVAR.bgblFirma3 = 0;
                bAceptar = (false).ToString();
                Agrega_Item();
                //Fomatea el Control de Fechas
                Inicializa_Controles_Fecha();

                slUsuarioCambio = CRSParametros.sgUserID;
                this.Cursor = Cursors.Default;

                int tempRefParam3 = 0;
                ID_MEM_DG_SSP_SelectedIndexChanged(ID_MEM_DG_SSP, new EventArgs());
                Fichero(0);

                CRSGeneral.prCargaEstadoEnCombo(ID_MEM_EDO_EB[0]);
                CRSGeneral.prCargaEstadoEnCombo(ID_MEM_EDO_EB[1]);

                slIndCtaControl = CRSParametros.cteNoCuentaControl;
                slNacionalidad = CRSParametros.cteMexicana;
                ilGeneraSBF = 0;

                if (FileSystem.Dir(CORVAR.pszgblPathFirmas + "firma1.pcx", FileAttribute.Normal) != "")
                {
                    File.Delete(CORVAR.pszgblPathFirmas + "firma1.pcx");
                }
                if (FileSystem.Dir(CORVAR.pszgblPathFirmas + "firma2.pcx", FileAttribute.Normal) != "")
                {
                    File.Delete(CORVAR.pszgblPathFirmas + "firma2.pcx");
                }
                if (FileSystem.Dir(CORVAR.pszgblPathFirmas + "firma3.pcx", FileAttribute.Normal) != "")
                {
                    File.Delete(CORVAR.pszgblPathFirmas + "firma3.pcx");
                }

                bolfalfirma = "FALSE";

                ID_MEM_PERSONA.SelectedIndex = 0; //FSWB NR 20070227 Persona Moral
                ID_MEM_NLG_EB.Focus(); //FSWB NR 20070227 Da el focus al campo nombre
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }



        public void Inicializa_Controles_Fecha()
        {
            try
            {
                ID_MEM_FEC_VEN_DTB.CtlText = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch
            {
            }
        }

        private void CORMNEMP_Closed(Object eventSender, EventArgs eventArgs)
        {
            /*if (bConexion)
            { //conexion del rut
                if (ConexionRut.Termina_Conexion())
                {
                    bConexion = false;
                }
            }
            ConexionRut = null; YURIA 21102009*/
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = 0;
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = null;
            CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = String.Empty;
            this.Cursor = Cursors.Default;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ID_MEM_BOR_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iIndex = 0;
            int iResp = 0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                this.Cursor = Cursors.WaitCursor;


                CORVAR.bgblModFirma = -1;
                if (CORMNEMP.DefInstance.Tag.ToString() != "A")
                {
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    iResp = (int)Interaction.MsgBox("Al borrar el representante se eliminarán las firmas de la base de datos" + "\r" + "¿Desea Continuar?", (MsgBoxStyle)(CORVB.MB_YESNO + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    this.Cursor = Cursors.WaitCursor;
                    if (iResp == CORVB.IDYES)
                    {
                        if (ID_MEM_REP_3OD[0].Checked)
                        {
                            iIndex = 0;
                            //   bgblFirma1 = False
                            File.Delete(CORVAR.pszgblPathFirmas + "firma1.pcx");
                            CORVAR.pszgblsql = " update MTCEMP01 set emp_fir_r1 = '' ";
                            //***** INICIO CODIGO NUEVO FSWBMX *****
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            //***** FIN DE CODIGO NUEVO FSWBMX *****
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                                CORVAR.bgblFirma1 = 0;
                            }
                            else
                            {
                                CORVAR.bgblFirma1 = -1;
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                        else if (ID_MEM_REP_3OD[1].Checked)
                        {
                            iIndex = 1;
                            //   bgblFirma2 = False
                            File.Delete(CORVAR.pszgblPathFirmas + "firma2.pcx");
                            //      pszgblsql = " update MTCEMP01 set emp_fir_r2 = ''  where emp_num = " + Format$(lgblNumEmpresa)
                            //***** INICIO CODIGO NUEVO FSWBMX *****
                            CORVAR.pszgblsql = " update MTCEMP01 set emp_fir_r2 = '' ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                            //***** FIN DE CODIGO NUEVO FSWBMX *****
                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                                CORVAR.bgblFirma2 = 0;
                            }
                            else
                            {
                                CORVAR.bgblFirma2 = -1;
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                        else if (ID_MEM_REP_3OD[2].Checked)
                        {
                            iIndex = 2;
                            //    bgblFirma3 = False
                            File.Delete(CORVAR.pszgblPathFirmas + "firma3.pcx");
                            //   pszgblsql = " update MTCEMP01 set emp_fir_r3 = ''  where emp_num = " + Format$(lgblNumEmpresa)
                            //***** INICIO CODIGO NUEVO FSWBMX *****
                            CORVAR.pszgblsql = " update MTCEMP01 set emp_fir_r3 = '' ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + CORVAR.igblPref.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();
                            //***** FIN DE CODIGO NUEVO FSWBMX *****
                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                                CORVAR.bgblFirma3 = 0;
                            }
                            else
                            {
                                CORVAR.bgblFirma3 = -1;
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                        ID_MEM_NOM_EB[iIndex].Text = CORVB.NULL_STRING;
                        ID_MEM_PUE_EB[iIndex].Text = CORVB.NULL_STRING;
                        ID_MEM_TEL_MKE[iIndex].CtlText = CORVB.NULL_STRING;
                        ID_MEM_EXT_PIC[iIndex].CtlText = CORVB.NULL_STRING;
                        ID_MEM_FAX_MKE[iIndex].CtlText = CORVB.NULL_STRING;
                    }
                }
                else
                {
                    if (ID_MEM_REP_3OD[0].Checked)
                    {
                        CORVAR.bgblFirma1 = 0;
                        File.Delete(CORVAR.pszgblPathFirmas + "firma1.pcx");
                        CORREGFI.DefInstance.ID_FIR_FR1_PB.Tag = "";
                        CORREGFI.DefInstance.ID_FIR_FR1_PB.Enabled = false;
                        CORREGFI.DefInstance.ID_FIR_FR1_IMM.DelImage = true;
                    }
                    else if (ID_MEM_REP_3OD[1].Checked)
                    {
                        CORVAR.bgblFirma2 = 0;
                        CORREGFI.DefInstance.ID_FIR_FR2_PB.Tag = "";
                        CORREGFI.DefInstance.ID_FIR_FR2_PB.Enabled = false;
                        CORREGFI.DefInstance.ID_FIR_FR2_IMM.DelImage = true;
                        File.Delete(CORVAR.pszgblPathFirmas + "firma2.pcx");
                    }
                    else if (ID_MEM_REP_3OD[2].Checked)
                    {
                        CORVAR.bgblFirma3 = 0;
                        CORREGFI.DefInstance.ID_FIR_FR3_PB.Tag = "";
                        CORREGFI.DefInstance.ID_FIR_FR3_PB.Enabled = false;
                        CORREGFI.DefInstance.ID_FIR_FR3_IMM.DelImage = true;
                        File.Delete(CORVAR.pszgblPathFirmas + "firma3.pcx");
                    }
                    ID_MEM_NOM_EB[iIndex].Text = CORVB.NULL_STRING;
                    ID_MEM_PUE_EB[iIndex].Text = CORVB.NULL_STRING;
                    ID_MEM_TEL_MKE[iIndex].CtlText = CORVB.NULL_STRING;
                    ID_MEM_EXT_PIC[iIndex].CtlText = CORVB.NULL_STRING;
                    ID_MEM_FAX_MKE[iIndex].CtlText = CORVB.NULL_STRING;
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEM_BOR_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        private void ID_MEM_BUS_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            if (Strings.Len(ID_MEM_NNA_EB.Text) != 0)
            {
                Busca_Ejecutivo();
            }
            ID_MEM_NNA_EB.Text = CORVB.NULL_STRING;
        }


        private void ID_MEM_BUS_PB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == ((int)"\t"[0]))
            {
                Fichero(4);
            }
            else
            {
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_MEM_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                File.Delete(CORVAR.pszgblPathFirmas + "firma1.pcx");
                File.Delete(CORVAR.pszgblPathFirmas + "firma2.pcx");
                File.Delete(CORVAR.pszgblPathFirmas + "firma3.pcx");
                this.Close();
                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEM_CAN_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        private void ID_MEM_CAR_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_CAR_PIC.SelStart = 0;
            ID_MEM_CAR_PIC.SelLength = Strings.Len(ID_MEM_CAR_PIC.CtlText);
        }

        private void ID_MEM_CAR_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB_Click(ID_MEM_OK_PB, new EventArgs());
                return;
            }
            else
            {
                //AIS-1096 NGONZALEZ
                CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
            }
        }


        private void ID_MEM_CAR_PIC_Leave(Object eventSender, EventArgs eventArgs)
        {
            bAceptar = (false).ToString();
        }

        private void ID_MEM_CAR_PIC_MouseDown(Object eventSender, MouseEventArgs eventArgs)
        {
            int Button = (int)eventArgs.Button;
            int Shift = (int)Control.ModifierKeys / 0x10000;
            float X = (float)VB6.PixelsToTwipsX(eventArgs.X);
            float Y = (float)VB6.PixelsToTwipsY(eventArgs.Y);
            bAceptar = (true).ToString();
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
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
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
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, ".");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_CON_TXT_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_CON_TXT.SelectionStart = 0;
            ID_MEM_CON_TXT.SelectionLength = Strings.Len(ID_MEM_CON_TXT.Text);
            //Fichero 3
        }

        private void ID_MEM_CON_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_MEM_CP_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_CP_PIC, eventSender);
            ID_MEM_CP_PIC[Index].SelStart = 0;
            ID_MEM_CP_PIC[Index].SelLength = Strings.Len(ID_MEM_CP_PIC[Index].CtlText);
        }


        private void ID_MEM_CP_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_CP_PIC, eventSender);
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            switch (Index)
            {
                case 1:
                    //AIS-1094 NGONZALEZ
                    if (eventArgs.keyAscii == ((int)"\t"[0]))
                    {
                        Fichero(2);
                        return;
                    }
                    break;
            }
            //AIS-1094 NGONZALEZ
            //AIS-1096 NGONZALEZ
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos);
        }

        private void ID_MEM_CRE_FTB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_CRE_FTB.SelStart = 0;
            ID_MEM_CRE_FTB.SelLength = Strings.Len(ID_MEM_CRE_FTB.CtlText);
        }

        private void ID_MEM_CRE_FTB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, false);
        }

        private void ID_MEM_CRE_FTB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {

            bool Cancel = eventArgs.Cancel;
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //If (Len(Format$(ID_MEM_CRE_FTB.Text)) > 13) Then
                if (Conversion.Val(ID_MEM_CRE_FTB.CtlText) > CRSParametros.cteLimiteCredito)
                {
                    MessageBox.Show("Importe mayor al permitido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ID_MEM_CRE_FTB.SelStart = 0;
                    ID_MEM_CRE_FTB.SelLength = Strings.Len(ID_MEM_CRE_FTB.defaultText);
                    //    ID_MEM_CRE_FTB.SetFocus
                    Cancel = true;
                }
                else
                {
                    if (Conversion.Val(ID_MEM_CRE_FTB.defaultText) <= 0)
                    {
                        MessageBox.Show("Importe menor al permitido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ID_MEM_CRE_FTB.CtlText = "0";
                        //        ID_MEM_CRE_FTB.SetFocus
                        ID_MEM_CRE_FTB.SelStart = 0;
                        ID_MEM_CRE_FTB.SelLength = Strings.Len(ID_MEM_CRE_FTB.defaultText);
                        Cancel = true;
                    }
                    else
                    {
                        //UPGRADE_WARNING: (1068) Nvl(ID_MEM_CRE_FTB.Text, 0) of type Variant is being forced to double.
                        //UPGRADE_WARNING: (1041) Mod has a new behavior.
                        if (Convert.ToDouble(MdlCambioMasivo.Nvl(ID_MEM_CRE_FTB.defaultText, 0)) % 5 != 0)
                        {
                            MdlCambioMasivo.MsgInfo("El importe debe de ser Multiplo de $5.00");
                            Cancel = true;
                            ID_MEM_CRE_FTB.SelStart = 0;
                            ID_MEM_CRE_FTB.SelLength = Strings.Len(ID_MEM_CRE_FTB.defaultText);
                        }
                    }

                }

                //Eliminar una vez que se establesca una regla
                //If bfncExcepcionCredito = True Then Exit Sub

                if (Conversion.Val(ID_MEM_CRED_ACUM_FTB.defaultText) > Conversion.Val(ID_MEM_CRE_FTB.defaultText))
                {
                    MessageBox.Show("El monto mímino de crédito que puede especificar debe ser al menos el del acumulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ID_MEM_CRE_FTB.Focus();
                    ID_MEM_CRE_FTB.SelStart = 0;
                    ID_MEM_CRE_FTB.SelLength = Strings.Len(ID_MEM_CRE_FTB.defaultText);
                    Cancel = true;
                }

                eventArgs.Cancel = Cancel;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(AlmacenaCliente)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_MEM_CRED_ACUM_FTB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_CRED_ACUM_FTB.SelStart = 0;
            ID_MEM_CRED_ACUM_FTB.SelLength = Strings.Len(ID_MEM_CRE_FTB.CtlText);
        }

        private void ID_MEM_CRED_ACUM_FTB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            //  bAceptar = True
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8 && eventArgs.keyAscii != 46)
            {
                eventArgs.keyAscii = (short)CORVB.NULL_INTEGER;
            }
        }

        private void ID_MEM_CRED_ACUM_FTB_KeyUpEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyUpEvent eventArgs)
        {
            //  bAceptar = True
        }


        private void ID_MEM_DG_SSP_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_DG_SSPPreviousTab = ID_MEM_DG_SSP.SelectedIndex;
            Fichero(ID_MEM_DG_SSP.SelectedIndex);
            ID_MEM_DG_SSPPreviousTab = ID_MEM_DG_SSP.SelectedIndex;
        }


        private void ID_MEM_DOM_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_DOM_EB, eventSender);
            ID_MEM_DOM_EB[Index].SelectionStart = 0;
            ID_MEM_DOM_EB[Index].SelectionLength = Strings.Len(ID_MEM_DOM_EB[Index].Text);
            if (Index == 0)
            {
                Fichero(1);
            }
        }

        private void ID_MEM_DOM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "#,-.");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_EDO_EB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int Index = Array.IndexOf(ID_MEM_EDO_EB, eventSender);
            if (ID_MEM_EDO_EB[Index].SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un estado para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancel = true;
            }
            eventArgs.Cancel = Cancel;
        }

        private void ID_MEM_EMAIL_TXT_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_EMAIL_TXT.SelectionStart = 0;
            ID_MEM_EMAIL_TXT.SelectionLength = Strings.Len(ID_MEM_EMAIL_TXT.Text);
        }

        private void ID_MEM_EMAIL_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValCorreoElectrónico, false, false);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_EMAIL_TXT_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (Strings.Len(ID_MEM_EMAIL_TXT.Text) > 0)
            {
                if ((ID_MEM_EMAIL_TXT.Text.IndexOf('@') + 1) == 0 || (ID_MEM_EMAIL_TXT.Text.IndexOf('@') + 1) == 1 || (ID_MEM_EMAIL_TXT.Text.IndexOf('@') + 1) == Strings.Len(ID_MEM_EMAIL_TXT.Text))
                {
                    Cancel = true;
                    MessageBox.Show("Dirección de Correo electrónico incorrecta." + "\r\n" + "Verifique la dirección.", "Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            eventArgs.Cancel = Cancel;
        }

        private void ID_MEM_EXT_PIC_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_EXT_PIC, eventSender);
            ID_MEM_EXT_PIC[Index].SelStart = 0;
            ID_MEM_EXT_PIC[Index].SelLength = Strings.Len(ID_MEM_EXT_PIC[Index].CtlText);
        }

        private void ID_MEM_EXT_PIC_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            //AIS-1094 NGONZALEZ
            //AIS-1096 NGONZALEZ
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
        }

        private void ID_MEM_EXT_PIC_Leave(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_EXT_PIC, eventSender);
            ID_MEM_FAX_MKE_Enter(ID_MEM_FAX_MKE[Index], new EventArgs());
        }


        private void ID_MEM_FAX_LADA_TXT_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_FAX_LADA_TXT.SelectionStart = 0;
            ID_MEM_FAX_LADA_TXT.SelectionLength = Strings.Len(ID_MEM_FAX_LADA_TXT.Text);
        }

        private void ID_MEM_FAX_LADA_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_MEM_FAX_MKE_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_FAX_MKE, eventSender);

            ID_MEM_FAX_MKE[Index].SelStart = 0;
            ID_MEM_FAX_MKE[Index].SelLength = Strings.Len(ID_MEM_FAX_MKE[Index].defaultText);

            if (ID_MEM_REP_FRM.Tag.ToString() != CORVB.NULL_STRING)
            {
                switch (Index)
                {
                    case 1:
                    case 2:
                        ID_MEM_REP_3OD[Index].Checked = true;
                        ID_MEM_NOM_EB[Index].Tag = CORVB.NULL_STRING;
                        break;
                }
            }

        }

        private void ID_MEM_FAX_MKE_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            //AIS-1094 NGONZALEZ
            //AIS-1096 NGONZALEZ
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
        }


        private void ID_MEM_FAX_TXT_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_FAX_TXT.SelectionStart = 0;
            ID_MEM_FAX_TXT.SelectionLength = Strings.Len(ID_MEM_FAX_TXT.Text);
        }

        private void ID_MEM_FAX_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_FEC_VEN_DTB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_FEC_VEN_DTB.SelStart = 0;
            ID_MEM_FEC_VEN_DTB.SelLength = Strings.Len(ID_MEM_FEC_VEN_DTB.CtlText);
        }

        private void ID_MEM_FEC_VEN_DTB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            string tempRefParam = this.Text;
            if (!CRSGeneral.bfncValidaFecha(ID_MEM_FEC_VEN_DTB, 0, ref tempRefParam))
            {
                Cancel = true;
            }
            eventArgs.Cancel = Cancel;
        }

        private void ID_MEM_FIR_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //***** INICIO CODIGO NUEVO FSWBMX *****
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                this.Cursor = Cursors.WaitCursor;

                bVerFirmas = (true).ToString();

                if ((Strings.Len(ID_MEM_NOM_EB[0].Text) > 0 && Strings.Len(ID_MEM_PUE_EB[0].Text) > 0) || (Strings.Len(ID_MEM_NOM_EB[1].Text) > 0 && Strings.Len(ID_MEM_PUE_EB[1].Text) > 0) || (Strings.Len(ID_MEM_NOM_EB[2].Text) > 0 && Strings.Len(ID_MEM_PUE_EB[2].Text) > 0))
                {

                    CORVAR.bgblModFir1 = 0;
                    CORVAR.bgblModFir2 = 0;
                    CORVAR.bgblModFir3 = 0;

                    this.Cursor = Cursors.Default;

                    switch (Tag.ToString())
                    {
                        case CORCONST.TAG_ALTA:
                            CORVAR.igblCancela = -1;
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
                            CORREGFI.DefInstance.ShowDialog();
                            break;
                        case CORCONST.TAG_CAMBIO:
                            CORVAR.igblCancela = -1;
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
                            CORREGFI.DefInstance.ShowDialog();
                            break;
                        case CORCONST.TAG_CONSULTA:
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
                            CORCONFI.DefInstance.ShowDialog();
                            break;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se han capturado los datos de los representantes", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEM_FIR_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_MEM_FIR_PB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == ((int)"\t"[0]))
            {
                bAceptar = (true).ToString();
                Fichero(3);
            }
            else
            {
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_FIR_PB_Leave(Object eventSender, EventArgs eventArgs)
        {
            if (!Boolean.Parse(bVerFirmas))
            {
                if (Boolean.Parse(bAceptar))
                {
                    Fichero(3);
                }
            }
            bVerFirmas = (false).ToString();
            bAceptar = (false).ToString();
        }


        private void ID_MEM_IMP_PB_Click(Object eventSender, EventArgs eventArgs)
        {


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                bAceptar = (true).ToString();

                PrinterHelper.Printer.FontName = "Courier New";

                PrinterHelper.Printer.DocumentName = "TCc430";

                PrinterHelper.Printer.FontBold = true;

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print(new String(' ', 24) + Text);
                PrinterHelper.Printer.Print(new String(' ', 24) + new string('-', Strings.Len(Text)));
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("PREFIJO                : " + CORVAR.igblPref.ToString());
                PrinterHelper.Printer.Print("BANCO                  : " + CORVAR.igblBanco.ToString());
                PrinterHelper.Printer.Print("GRUPO                  : " + ID_MEM_TEX_PNL[0].Text);
                PrinterHelper.Printer.Print("EMPRESA                : " + ID_MEM_TEX_PNL[1].Text);

                PrinterHelper.Printer.FontBold = false;

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("NOMBRE LARGO           : " + ID_MEM_NLG_EB.Text);
                PrinterHelper.Printer.Print("NOMBRE CORTO           : " + ID_MEM_NCT_EB.Text);
                PrinterHelper.Printer.Print("RFC                    : " + ID_MEM_RFC_MKE.CtlText);
                PrinterHelper.Printer.Print("NO. CARTERA            : " + ID_MEM_CAR_PIC.CtlText);
                PrinterHelper.Printer.Print("SECTOR                 : " + ID_MEM_SEC_COB.Text);
                PrinterHelper.Printer.Print("PRINCIPAL ACCIONISTA   : " + ID_MEM_PAC_EB.Text); //principal accionista
                PrinterHelper.Printer.Print("CREDITO TOTAL ASIGNADO : " + ID_MEM_CRE_FTB.CtlText); //Crédito total asignado
                PrinterHelper.Printer.Print("CREDITO ACUMULADO      : " + ID_MEM_CRED_ACUM_FTB.CtlText); //Crédito total acumulado
                PrinterHelper.Printer.Print("FECHA DE VENCIMIENTO   : " + ID_MEM_FEC_VEN_DTB.CtlText); //fecha de vencimiento de credito

                PrinterHelper.Printer.Print();

                //Domicilio Fiscal
                PrinterHelper.Printer.Print("     DOMICILIO FISCAL");
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("CALLE Y NUMERO         : " + ID_MEM_DOM_EB[0].Text); //Domicilio Fiscal
                PrinterHelper.Printer.Print("COLONIA                : " + ID_MEM_COL_EB[0].Text); //Colonia"
                PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : " + ID_MEM_PDM_EB[0].Text); //Poblacion/delegacion
                PrinterHelper.Printer.Print("CIUDAD                 : " + ID_MEM_CIU_EB[0].Text); //Ciudad
                PrinterHelper.Printer.Print("ESTADO                 : " + ID_MEM_EDO_EB[0].Text);
                PrinterHelper.Printer.Print("C.P                    : " + ID_MEM_CP_PIC[0].CtlText); //Estado
                PrinterHelper.Printer.Print();

                //Domicilio de envío
                PrinterHelper.Printer.Print("     DOMICILIO DE ENVIO");
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("CALLE Y NUMERO         : " + ID_MEM_DOM_EB[1].Text); //Doimicilio de envio
                PrinterHelper.Printer.Print("COLONIA                : " + ID_MEM_COL_EB[1].Text); //Colonia
                PrinterHelper.Printer.Print("POBLACION/DEL./MUN.    : " + ID_MEM_PDM_EB[1].Text); //Poblacion/delegacion
                PrinterHelper.Printer.Print("CIUDAD                 : " + ID_MEM_CIU_EB[1].Text); //Ciudad
                PrinterHelper.Printer.Print("ESTADO                 : " + ID_MEM_EDO_EB[1].Text);
                PrinterHelper.Printer.Print("C.P                    : " + ID_MEM_CP_PIC[1].CtlText); //Estado
                PrinterHelper.Printer.Print();


                //Representantes
                PrinterHelper.Printer.Print("     REPRESENTANTE 1");
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("NOMBRE                 : " + ID_MEM_NOM_EB[0].Text); //Nombre de representante1"
                PrinterHelper.Printer.Print("PUESTO                 : " + ID_MEM_PUE_EB[0].Text); //Puesto"
                PrinterHelper.Printer.Print("TELEFONO               : " + ID_MEM_TEL_MKE[0].CtlText);
                PrinterHelper.Printer.Print("EXTENSION              : " + ID_MEM_EXT_PIC[0].CtlText);
                PrinterHelper.Printer.Print("FAX                    : " + ID_MEM_FAX_MKE[0].CtlText); //Telefono
                PrinterHelper.Printer.Print(); //Extension

                PrinterHelper.Printer.Print("     REPRESENTANTE 2");
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("NOMBRE                 : " + ID_MEM_NOM_EB[1].Text); //Nombre de representante2
                PrinterHelper.Printer.Print("PUESTO                 : " + ID_MEM_PUE_EB[1].Text); //Puesto
                PrinterHelper.Printer.Print("TELEFONO               : " + ID_MEM_TEL_MKE[1].CtlText);
                PrinterHelper.Printer.Print("EXTENSION              : " + ID_MEM_EXT_PIC[1].CtlText);
                PrinterHelper.Printer.Print("FAX                    : " + ID_MEM_FAX_MKE[1].CtlText); //Telefono
                PrinterHelper.Printer.Print(); //Extension

                PrinterHelper.Printer.Print("     REPRESENTANTE 3");
                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("NOMBRE                 : " + ID_MEM_NOM_EB[2].Text); //Nombre de representante3
                PrinterHelper.Printer.Print("PUESTO                 : " + ID_MEM_PUE_EB[2].Text); //Puesto
                PrinterHelper.Printer.Print("TELEFONO               : " + ID_MEM_TEL_MKE[2].CtlText);
                PrinterHelper.Printer.Print("EXTENSION              : " + ID_MEM_EXT_PIC[2].CtlText);
                PrinterHelper.Printer.Print("FAX                    : " + ID_MEM_FAX_MKE[2].CtlText); //Telefono
                PrinterHelper.Printer.Print(); //Extension

                PrinterHelper.Printer.Print();
                if (ID_MEM_TPA_3OPB[0].Checked)
                {
                    PrinterHelper.Printer.Print("TIPO DE PAGO           : CENTRALIZADO");
                }
                else
                {
                    PrinterHelper.Printer.Print("TIPO DE PAGO           : INDIVIDUAL");
                }
                if (ID_MEM_EEC_3OPB[0].Checked)
                {
                    PrinterHelper.Printer.Print("ENVIO EDO. CUENTA      : EMPRESA"); //pszTipoEnv
                }
                else
                {
                    PrinterHelper.Printer.Print("ENVIO EDO. CUENTA      : INDIVIDUAL"); //pszTipoEnv
                }

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("SUCURSAL               : " + ID_MEM_SUC_ITB.CtlText);
                PrinterHelper.Printer.Print("CUENTA DE CAPTACION    : " + ID_MEM_NMC_FTB.CtlText); //Sucursal"

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("EJECUTIVO BANAMEX        : " + ID_MEM_NOM_COB.Text); //Ejecutivo Banamex

                PrinterHelper.Printer.Print();
                PrinterHelper.Printer.Print("TELEFONO                 : " + ID_MEM_CON_TXT.Text);
                PrinterHelper.Printer.Print("EXTENSION                : " + ID_MEM_TEL_EXT_TXT.Text);
                PrinterHelper.Printer.Print("LADA                     : " + ID_MEM_LADA_TXT.Text);
                PrinterHelper.Printer.Print("FAX                      : " + ID_MEM_FAX_TXT.Text);
                PrinterHelper.Printer.Print("FAX LADA                 : " + ID_MEM_FAX_LADA_TXT.Text);
                //  Printer.Print "VEL. TRANSMISION         : " + ID_MEM_VEL_TRNS_TXT.Text
                PrinterHelper.Printer.Print("EMAIL                    : " + ID_MEM_EMAIL_TXT.Text);
                PrinterHelper.Printer.Print("INTERNET                 : " + ID_MEM_INTER_TXT.Text);
                PrinterHelper.Printer.EndDoc();
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEM_IMP_PB_Click)", exc); 
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_MEM_INTER_TXT_Enter(Object eventSender, EventArgs eventArgs)
        {

            ID_MEM_INTER_TXT.SelectionStart = 0;
            ID_MEM_INTER_TXT.SelectionLength = Strings.Len(ID_MEM_INTER_TXT.Text);
        }

        private void ID_MEM_INTER_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            if (KeyAscii == 32)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, false, false, ".-_");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_MEM_LADA_TXT_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_LADA_TXT.SelectionStart = 0;
            ID_MEM_LADA_TXT.SelectionLength = Strings.Len(ID_MEM_LADA_TXT.Text);
        }

        private void ID_MEM_LADA_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }
        //
        //
        //UPGRADE_NOTE: (7001) The following declaration (ID_MEM_MCO_SSC_Click) seems to be dead code
        //private void  ID_MEM_MCO_SSC_Click( int Index,  int Value)
        //{
        //}

        //UPGRADE_NOTE: (7001) The following declaration (ID_MEM_MCO_SSC_KeyPress) seems to be dead code
        //private void  ID_MEM_MCO_SSC_KeyPress( int Index,  int KeyAscii)
        //{
        //
        //}


        //UPGRADE_NOTE: (7001) The following declaration (ID_MEM_MCO_SSC_LostFocus) seems to be dead code
        //private void  ID_MEM_MCO_SSC_LostFocus( int Index)
        //{
        //
        //}


        private void ID_MEM_MES_FIS_CBO_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            if (ID_MEM_MES_FIS_CBO.SelectedIndex > -1)
            {
                ilMesFiscal = VB6.GetItemData(ID_MEM_MES_FIS_CBO, ID_MEM_MES_FIS_CBO.SelectedIndex);
            }
            else
            {
                ID_MEM_MES_FIS_CBO.SelectedIndex = 0;
                //MsgBox "Se tomará como mes fiscal el " & ID_MEM_MES_FIS_CBO.Text, vbExclamation
                ilMesFiscal = VB6.GetItemData(ID_MEM_MES_FIS_CBO, ID_MEM_MES_FIS_CBO.SelectedIndex);
            }
        }


        private void ID_MEM_NCT_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_NCT_EB.SelectionStart = 0;
            ID_MEM_NCT_EB.SelectionLength = Strings.Len(ID_MEM_NCT_EB.Text);
        }
        private void ID_MEM_NCT_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {

            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, "@");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_NCT_EB_Leave(Object eventSender, EventArgs eventArgs)
        {
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.Tag.ToString() == CORCONST.TAG_ALTA || this.Tag.ToString() == CORCONST.TAG_CAMBIO)
                {
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEM_NCT_EB_Leave)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        private void ID_MEM_NLG_EB_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_TEX_PNL[1].Text = ID_MEM_NLG_EB.Text;
        }

        private void ID_MEM_NLG_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_NLG_EB.SelectionStart = 0;
            ID_MEM_NLG_EB.SelectionLength = Strings.Len(ID_MEM_NLG_EB.Text);
            //  Fichero 0
        }

        private void ID_MEM_NLG_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true, ".,@");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_NMC_FTB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_NMC_FTB.SelStart = 0;
            ID_MEM_NMC_FTB.SelLength = Strings.Len(ID_MEM_NMC_FTB.CtlText);
        }

        private void ID_MEM_NMC_FTB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        private void ID_MEM_NNA_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_NNA_EB.SelectionStart = 0;
            ID_MEM_NNA_EB.SelectionLength = Strings.Len(ID_MEM_NNA_EB.Text);

            VB6.SetDefault(ID_MEM_BUS_PB, true);
            ID_MEM_BUS_PB.Enabled = true;
        }

        private void ID_MEM_NNA_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValEntero);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_MEM_NNA_EB_Leave(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_ISSUE: (2072) Control Tag could not be resolved because it was within the generic namespace ActiveControl.
            if (ActiveControl.Tag.ToString() != "BUSCAR")
            {
                VB6.SetDefault(ID_MEM_BUS_PB, false);
                ID_MEM_BUS_PB.Enabled = false;
            }

        }

        private void ID_MEM_NO_BORRAR_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_NO_BORRAR, eventSender);

            switch (Index)
            {
                case 0:
                    Fichero(2);
                    bAceptar = (false).ToString();
                    break;
                case 1:
                    Fichero(3);
                    bAceptar = (false).ToString();
                    break;
                case 2:
                    Fichero(4);
                    bAceptar = (false).ToString();
                    break;
            }

        }

        private void ID_MEM_NOM_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_NOM_EB, eventSender);
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** FIN DE CODIGO NUEVO FSWBMX *****

                ID_MEM_NOM_EB[Index].SelectionStart = 0;
                ID_MEM_NOM_EB[Index].SelectionLength = Strings.Len(ID_MEM_NOM_EB[Index].Text);

                if (ID_MEM_REP_FRM.Tag.ToString() != CORVB.NULL_STRING)
                {
                    switch (Index)
                    {
                        case 0:
                            ID_MEM_REP_3OD[0].Checked = true;
                            break;
                        case 1:
                            ID_MEM_REP_3OD[1].Checked = true;
                            break;
                        case 2:
                            ID_MEM_REP_3OD[2].Checked = true;
                            break;
                    }
                    ID_MEM_REP_FRM.Tag = CORVB.NULL_STRING;
                }
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(AlmacenaCliente)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }


        }

        private void ID_MEM_NOM_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                CORVAR.igblCancela = -1;

                ID_MEM_OK_PB.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (Tag.ToString() == CORCONST.TAG_ALTA)
                {
                    prAlta_Empresa();
                }
                else
                {
//                    Alta_Empresa();
                    Cambia_Empresa();
                }
                this.Cursor = Cursors.Default;
                ID_MEM_OK_PB.Enabled = true;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MEM_OK_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        private bool EnvAccConexionEmp()
        {

            bool result = false;
            int liEdo = 0;
            int llNomina = 0;
            FixedLengthString fsNomina = new FixedLengthString(4);
            FixedLengthString lsPassword = new FixedLengthString(8);

            string pszRepS111 = String.Empty;
            string pszCadena = String.Empty;
            string pszMensajeS111 = String.Empty;
            int iPos = 0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                result = false;
                this.Cursor = Cursors.Default;
                CORMNEMP.DefInstance.Tag = "TAG_CAMBIOS_MASIVOS";
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORACCOM.DefInstance.ShowDialog();
                string pszResAcc = CORACCOM.DefInstance.Tag.ToString();

                if (pszResAcc == "Cancelar")
                {
                    //UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se capturaron datos.", (MsgBoxStyle)Int32.Parse(((int)CORVB.MB_OK).ToString() + ((int)CORVB.MB_ICONEXCLAMATION).ToString()), CORSTR.STR_APP_TIT);
                    ConComDrive.Termina_Conexion();
                    CORACCOM.DefInstance.Close();
                    return true;
                }
                else
                {
                    //Compacta el numero de nómina de la forma CORACCOM
                    fsNomina.Value = new string((char)0, 4);
                    llNomina = Int32.Parse(CORACCOM.DefInstance.ID_ACC_NOM_TXT.Text);
                    liEdo = API.Encryption.iCompactaNomina(llNomina, fsNomina.Value);

                    //Compacta el password de la forma CORACCOM
                    lsPassword.Value = new string((char)255, 8);
                    liEdo = API.Encryption.iCompactaPasswd(CORACCOM.DefInstance.ID_ACC_CVE_TXT.Text, lsPassword.Value);

                    pszCadena = CORCONST.CVE_ACCESO_MODIFICA_S111;
                    pszCadena = pszCadena + fsNomina.Value + lsPassword.Value;
                    pszCadena = pszCadena + " " + "\r" + "\n";

                    this.Cursor = Cursors.WaitCursor;
                    pszRepS111 = ConComDrive.Envia_Mensaje(ref pszCadena);
                    pszMensajeS111 = CORPROC.Muestra_Mensaje(pszRepS111);
                    iPos = (pszRepS111.IndexOf("SEG:") + 1);
                    if (iPos > CORVB.NULL_INTEGER)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(" " + pszMensajeS111, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    }
                    else
                    {
                        MessageBox.Show(" " + pszMensajeS111 + "\r" + " FIN DEL PROCESO.", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = true;
                        ConComDrive.Termina_Conexion();
                        this.Cursor = Cursors.Default;
                    }
                    CORACCOM.DefInstance.Close();
                }
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(EnvAccConexionEmp)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }



        private void ID_MEM_OK_PB_MouseDown(Object eventSender, MouseEventArgs eventArgs)
        {
            int Button = (int)eventArgs.Button;
            int Shift = (int)Control.ModifierKeys / 0x10000;
            float X = (float)VB6.PixelsToTwipsX(eventArgs.X);
            float Y = (float)VB6.PixelsToTwipsY(eventArgs.Y);
            bAceptar = (true).ToString();
        }

        private void ID_MEM_PAC_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_PAC_EB.SelectionStart = 0;
            ID_MEM_PAC_EB.SelectionLength = Strings.Len(ID_MEM_PAC_EB.Text);
        }

        private void ID_MEM_PAC_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
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
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, ",.-");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_MEM_PUE_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_PUE_EB, eventSender);
            ID_MEM_PUE_EB[Index].SelectionStart = 0;
            ID_MEM_PUE_EB[Index].SelectionLength = Strings.Len(ID_MEM_PUE_EB[Index].Text);
        }

        private void ID_MEM_PUE_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfabetico, true, true);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        //
        private bool isInitializingComponent;
        private void ID_MEM_REP_3OD_CheckedChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (((RadioButton)eventSender).Checked)
            {
                int Index = Array.IndexOf(ID_MEM_REP_3OD, eventSender);

                //***** INICIO CODIGO NUEVO FSWBMX *****
                //UPGRADE_TODO: (1065) Error handling statement (On Error Resume Next) could not be converted properly. A throw statement was generated instead.
                //throw new Exception("Migration Exception: 'On Error Resume Next' not supported");
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                ID_MEM_NOM_EB[Index].Tag = CORVB.NULL_STRING;
                if (ID_MEM_REP_3OD[Index].Checked)
                {
                    switch (Index)
                    {
                        case 0:
                            ID_MEM_REP_PNL[0].BringToFront();
                            if (Tag.ToString() == CORCONST.TAG_CONSULTA)
                            {
                                ID_MEM_REP_PNL[0].BringToFront();
                            }
                            else
                            {
                                ID_MEM_REP_PNL[0].BringToFront();
                            }
                            break;
                        case 1:
                            if (Tag.ToString() == CORCONST.TAG_CONSULTA)
                            {
                                ID_MEM_REP_PNL[1].BringToFront();
                            }
                            else
                            {
                                ID_MEM_REP_PNL[1].BringToFront();
                            }
                            break;
                        case 2:
                            if (Tag.ToString() == CORCONST.TAG_CONSULTA)
                            {
                                ID_MEM_REP_PNL[2].BringToFront();
                            }
                            else
                            {
                                ID_MEM_REP_PNL[2].BringToFront();
                            }
                            break;
                    }
                    if (this.Tag.ToString() == CORCONST.TAG_CAMBIO)
                    {
                        ID_MEM_NOM_EB[Index].Focus();
                    }
                }
            }
        }

        private void ID_MEM_REP_3OD_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_REP_3OD, eventSender);
            if (Index == 0)
            {
                Fichero(2);
            }
        }


        private void ID_MEM_REP_3OD_Leave(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_REP_3OD, eventSender);

            if (ID_MEM_REP_FRM.Tag.ToString() == CORVB.NULL_STRING)
            {
                ID_MEM_REP_PNL[Index].BringToFront();
            }
            else
            {
                ID_MEM_REP_3OD[Convert.ToInt32(Conversion.Val(ID_MEM_REP_FRM.Tag.ToString()))].Checked = true;
            }

        }

        private void ID_MEM_RFC_MKE_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_RFC_MKE.SelStart = 0;
            ID_MEM_RFC_MKE.SelLength = Strings.Len(ID_MEM_RFC_MKE.CtlText);
        }

        private void ID_MEM_RFC_MKE_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
        }


        private void ID_MEM_SUC_ITB_Enter(Object eventSender, EventArgs eventArgs)
        {

            ID_MEM_SUC_ITB.SelStart = 0;
            ID_MEM_SUC_ITB.SelLength = Strings.Len(ID_MEM_SUC_ITB.CtlText);
        }

        private void ID_MEM_SUC_ITB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }
        }

        private void ID_MEM_TEL_EXT_TXT_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_MEM_TEL_EXT_TXT.SelectionStart = 0;
            ID_MEM_TEL_EXT_TXT.SelectionLength = Strings.Len(ID_MEM_TEL_EXT_TXT.Text);
        }

        private void ID_MEM_TEL_EXT_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValDigitos);
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }



        private void ID_MEM_TEL_MKE_Enter(Object eventSender, EventArgs eventArgs)
        {
            int Index = Array.IndexOf(ID_MEM_TEL_MKE, eventSender);
            ID_MEM_TEL_MKE[Index].SelStart = 0;
            ID_MEM_TEL_MKE[Index].SelLength = Strings.Len(ID_MEM_TEL_MKE[Index].CtlText);
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Limpia los datos contenidos en los controles        **
        //**                    despues de una Alta, para sucesivas altas           **
        //**                                                                        **
        //**       Declaración: Sub Limpia_Controles                                **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma :                                                 **
        //**                                                                        **
        //**       Ultima modificacion: 060694                                      **
        //**                                                                        **
        //****************************************************************************
        private void Limpia_Controles()
        {

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                //Numero de la Empresa
                ID_MEM_NLG_EB.Text = CORVB.NULL_STRING; //Nombre de empresa
                ID_MEM_NCT_EB.Text = CORVB.NULL_STRING; //Nombre corto de la empresa
                //***** INICIO CODIGO NUEVO FSWBMX *****
                ID_MEM_RFC_MKE.SelStart = 0;
                ID_MEM_RFC_MKE.SelLength = Strings.Len(ID_MEM_RFC_MKE.defaultText);
                ID_MEM_RFC_MKE.SelText = "";
                try
                {
                    ID_MEM_RFC_MKE.CtlText = CORVB.NULL_STRING; //Rfc
                }
                catch { }
                ID_MEM_RFC_MKE.Mask = "???-######-AAA";
                //***** FIN DE CODIGO NUEBO FSWBMX *****
                ID_MEM_CAR_PIC.CtlText = CORVB.NULL_STRING; //No de cartera
                ID_MEM_PAC_EB.Text = CORVB.NULL_STRING; //principal accionista
                ID_MEM_CRE_FTB.CtlText = CORVB.NULL_STRING; //Crédito total asignado

                //Domicilio Fiscal
                ID_MEM_DOM_EB[0].Text = CORVB.NULL_STRING; //Domicilio Fiscal
                ID_MEM_COL_EB[0].Text = CORVB.NULL_STRING; //Colonia
                ID_MEM_PDM_EB[0].Text = CORVB.NULL_STRING; //Poblacion/delegacion
                ID_MEM_CIU_EB[0].Text = CORVB.NULL_STRING; //Ciudad
                ID_MEM_EDO_EB[0].SelectedIndex = -1; //Estado
                ID_MEM_CP_PIC[0].CtlText = CORVB.NULL_STRING; //Cp
                try
                {
                    ID_MEM_FEC_VEN_DTB.CtlText = CORVB.NULL_STRING; //
                }
                catch { }
                //

                //Domicilio de envío
                ID_MEM_DOM_EB[1].Text = CORVB.NULL_STRING; //Doimicilio de envio
                ID_MEM_COL_EB[1].Text = CORVB.NULL_STRING; //Colonia
                ID_MEM_PDM_EB[1].Text = CORVB.NULL_STRING; //Poblacion/delegacion
                ID_MEM_CIU_EB[1].Text = CORVB.NULL_STRING; //Ciudad
                ID_MEM_EDO_EB[1].SelectedIndex = -1; //Estado
                try
                {
                    ID_MEM_CP_PIC[1].CtlText = CORVB.NULL_STRING; //Cp
                }
                catch { }
                ID_MEM_SUC_ITB.CtlText = CORVB.NULL_STRING; //Sucursal
                ID_MEM_NMC_FTB.CtlText = CORVB.NULL_STRING; //Cuenta de Captación

                //Representantes
                ID_MEM_NOM_EB[0].Text = CORVB.NULL_STRING; //Nombre de representante1
                ID_MEM_PUE_EB[0].Text = CORVB.NULL_STRING; //Puesto
                ID_MEM_TEL_MKE[0].CtlText = CORVB.NULL_STRING; //Telefono
                ID_MEM_EXT_PIC[0].CtlText = CORVB.NULL_STRING; //Extension
                ID_MEM_FAX_MKE[0].CtlText = CORVB.NULL_STRING; //Fax

                ID_MEM_NOM_EB[1].Text = CORVB.NULL_STRING; //Nombre de representante2
                ID_MEM_PUE_EB[1].Text = CORVB.NULL_STRING; //Puesto
                ID_MEM_TEL_MKE[1].CtlText = CORVB.NULL_STRING; //Telefono
                ID_MEM_EXT_PIC[1].CtlText = CORVB.NULL_STRING; //Extension
                ID_MEM_FAX_MKE[1].CtlText = CORVB.NULL_STRING; //Fax

                ID_MEM_NOM_EB[2].Text = CORVB.NULL_STRING; //Nombre de representante3
                ID_MEM_PUE_EB[2].Text = CORVB.NULL_STRING; //Puesto
                ID_MEM_TEL_MKE[2].CtlText = CORVB.NULL_STRING; //Telefono
                ID_MEM_EXT_PIC[2].CtlText = CORVB.NULL_STRING; //Extension
                ID_MEM_FAX_MKE[2].CtlText = CORVB.NULL_STRING; //Fax

                if (ID_MEM_SEC_COB.Items.Count > CORVB.NULL_INTEGER)
                {
                    ID_MEM_SEC_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }

                ID_MEM_CON_TXT.Text = CORVB.NULL_STRING; //telefono
                ID_MEM_TEL_EXT_TXT.Text = CORVB.NULL_STRING; //EXTENSION
                ID_MEM_LADA_TXT.Text = CORVB.NULL_STRING; //lada
                ID_MEM_FAX_TXT.Text = CORVB.NULL_STRING; //fax
                ID_MEM_FAX_LADA_TXT.Text = CORVB.NULL_STRING; //fax lada
                //''''  ID_MEM_VEL_TRNS_TXT.Text = NULL_INTEGER   'velocidad de transmision
                ID_MEM_EMAIL_TXT.Text = CORVB.NULL_STRING; //email
                ID_MEM_INTER_TXT.Text = CORVB.NULL_STRING; //internet

                txtAtencionA.Text = CORVB.NULL_STRING; //FSWB NR 20070223
                ID_MEM_PERSONA.SelectedIndex = 0; //FSWB NR 20070223  Default Pers. Moral

                //Kill pszgblPathFirmas + "firma1.pcx"
                //Kill pszgblPathFirmas + "firma2.pcx"
                //Kill pszgblPathFirmas + "firma3.pcx"

                CORCTEMP.DefInstance.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(CORCTEMP.DefInstance.Height))) / 2);

                //**********************************************************************
                //SE AGREGA EL CODIGO SIGUIENTE PARA EVITAR ALTAS POSTERIORES SIN FIRMA
                //**********************************************************************
                CORVAR.bgblFirma1 = 0;
                try
                {
                    File.Delete(CORVAR.pszgblPathFirmas + "firma1.pcx");
                }
                catch { }
                CORREGFI.DefInstance.ID_FIR_FR1_PB.Tag = "";
                CORREGFI.DefInstance.ID_FIR_FR1_PB.Enabled = false;
                CORREGFI.DefInstance.ID_FIR_FR1_IMM.DelImage = true;

                CORVAR.bgblFirma2 = 0;
                CORREGFI.DefInstance.ID_FIR_FR2_PB.Tag = "";
                CORREGFI.DefInstance.ID_FIR_FR2_PB.Enabled = false;
                CORREGFI.DefInstance.ID_FIR_FR2_IMM.DelImage = true;
                try
                {
                    File.Delete(CORVAR.pszgblPathFirmas + "firma2.pcx");
                }
                catch { }

                CORVAR.bgblFirma3 = 0;
                CORREGFI.DefInstance.ID_FIR_FR3_PB.Tag = "";
                CORREGFI.DefInstance.ID_FIR_FR3_PB.Enabled = false;
                CORREGFI.DefInstance.ID_FIR_FR3_IMM.DelImage = true;
                try
                {
                    File.Delete(CORVAR.pszgblPathFirmas + "firma3.pcx");
                }
                catch { }

                //**********************************************************************
                //**********************************************************************
                ID_MEM_CRED_ACUM_FTB.defaultText = String.Empty;
                //Campos adicionales

                mskPorcientoMinimo1.defaultText = "";
                mskMontoMinimo.defaultText = "";
                txtCuentaContable.Text = "";
                mskDiaCorte.defaultText = "";
                mskPeriodoGracia.defaultText = "";
                mskPerNoInteres.defaultText = "";
                /*mskMCC.defaultText = String.Empty;*/
                mskMCC.CtlText = "0";
                _optEmpresa_0.Checked = true;
                mskMCC.Enabled = false;
                // APQ 1-Jul-2010 Inicio - Cambio Tipo de Bloqueo
                mdlParametros.igEmpTipoBloqueo = 0;
                // APQ 1-Jul-2010 Fin - Cambio Tipo de Bloqueo

                ID_MEM_MES_FIS_CBO.SelectedIndex = -1;

                chkSkipPayment.CheckState = CheckState.Unchecked;
                chkCheckBox[0].CheckState = CheckState.Unchecked;
                chkCheckBox[1].CheckState = CheckState.Unchecked;
                cboEstructuraGastos.SelectedIndex = -1;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        private int Obtiene_DatosEmpresa()
        {

            int result = 0;
            int hBufEmpresa = 0; //Apunta a la sentencia SQL
            int iNumGrupo = 0; //El consecutivo del Grupo
            int iTempErr = 0; //Para control local
            string pszNombreEjec = String.Empty; //el nombre del ejecutivo

            //Campos del catalogo a recibir los datos
            int lNumEmpresa = 0;
            int lNominaEjeBNX = 0;
            string pszNomEmpresa = String.Empty;
            string pszNomCorto = String.Empty;
            string pszRFC = String.Empty;
            double dCartera = 0;
            string pszAccionista = String.Empty;
            int iSector = 0;
            int lCreditoGlobal = 0;
            string pszFecVenc = String.Empty;
            string lCredAcum = String.Empty;

            //Domicilio Fiscal
            string pszCalleFis = String.Empty;
            string pszColoniaFis = String.Empty;
            string pszCiudadFis = String.Empty;
            string pszPoblacionFis = String.Empty;
            string pszEstadoFis = String.Empty;
            int lCpFis = 0;

            string pszTelefono = String.Empty;
            string pszLada = String.Empty;
            string pszFax = String.Empty;
            string pszTelExt = String.Empty;
            string pszFaxLada = String.Empty;
            string pszTonoPul = String.Empty;
            int iVelTrns = 0;
            string pszEmail = String.Empty;
            string pszInternet = String.Empty;

            //Domicilio de envío
            string pszCalleEnv = String.Empty;
            string pszColoniaEnv = String.Empty;
            string pszCiudadEnv = String.Empty;
            string pszPoblacionEnv = String.Empty;
            string pszEstadoEnv = String.Empty;
            int lCpEnv = 0;
            string pszFecVenCred = String.Empty;

            double dCtaCaptacion = 0;
            int iSucursal = 0;

            //Representantes
            string pszNombreR1 = String.Empty;
            string pszPuestoR1 = String.Empty;
            string pszTelR1 = String.Empty;
            string pszExtR1 = String.Empty;
            string pszFaxR1 = String.Empty;
            object vFirmaR1 = null;

            string pszNombreR2 = String.Empty;
            string pszPuestoR2 = String.Empty;
            string pszTelR2 = String.Empty;
            string pszExtR2 = String.Empty;
            string pszFaxR2 = String.Empty;
            object vFirmaR2 = null;

            string pszNombreR3 = String.Empty;
            string pszPuestoR3 = String.Empty;
            string pszTelR3 = String.Empty;
            string pszExtR3 = String.Empty;
            string pszFaxR3 = String.Empty;
            object vFirmaR3 = null;

            string pszTipoPago = String.Empty;
            string pszTipoEnv = String.Empty;

            string pszAtencionA = String.Empty; //FSWB NR 20070223
            int pszPersona = 0; //FSWB NR 20070223

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                iErr = CORCONST.OK;
                lLeeCreditoGlobal = CORVB.NULL_INTEGER;

                CORVAR.pszgblsql = "select ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "ejx_numero,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_graba,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_rfc,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num_cartera,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_princ_acc,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_sector,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_cred_tot,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(varchar(10),emp_fec_venc_cred,103),";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_calle,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_col,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_ciu,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_pob,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_edo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_cp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_telefono,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_envio_calle,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_envio_col,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tel_lada,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_param_modem,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_vel_transmis,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_email,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_internet,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_envio_ciu,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_envio_pob,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_envio_edo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_envio_cp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_cta_capt,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_sucur,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tipo_pago,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tipo_envio,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r1,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_pues_r1,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tel_r1,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_ext_r1,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax_r1,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r2,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_pues_r2,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tel_r2,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_ext_r2,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax_r2,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r3,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_pues_r3,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tel_r3,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_ext_r3,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax_r3,";
                //    pszgblsql = pszgblsql & "(select isnull(sum(eje_limcred),0) from  MTCEJE01"
                //    pszgblsql = pszgblsql & " where MTCEJE01.eje_prefijo = MTCEMP01.eje_prefijo"
                //    pszgblsql = pszgblsql & " and MTCEJE01.gpo_banco = MTCEMP01.gpo_banco"
                //    pszgblsql = pszgblsql & " and MTCEJE01.emp_num = MTCEMP01.emp_num"
                //    pszgblsql = pszgblsql & " and MTCEJE01.eje_num > 0) as emp_acum_cred,"
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
                CORVAR.pszgblsql = CORVAR.pszgblsql + " c.eje_num=d.eje_num and (d.ths_situacion_cta='C' or d.ths_situacion_cta='E') )) as emp_acum_cred, ";
                //    pszgblsql = pszgblsql & " (d.ths_act_saldo + d.ths_act_ext_saldo) = 0 )) as emp_acum_cred, "

                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_extension,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax_lada,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_dia_corte,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_plazo_gracia,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_plazo_no_cob,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tabla_mcc,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_gen_SBF,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tipo_fac,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_esquema_pago,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tipo_producto,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_estruct_gastos,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_mes_fiscal,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_usu_cam,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fech_alta,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fech_cam,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_hora_cam,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_lim_dis_efec,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_min_factura,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_cta_contable,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_skip_payment,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tipo_bloqueo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_gen_CDF,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_atn_a,"; //FSWB 20070223 NR Se incluyen campos Atencion A y Persona
                CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tipo_persona"; //FSWB NB 20070223
                CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + CORVAR.lgblNumEmpresa.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        lNominaEjeBNX = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1))); //El número de Nomina del Ejecutivo
                        mlNominaEjeBNX = lNominaEjeBNX;
                        ID_MEM_NNA_EB.Text = lNominaEjeBNX.ToString();

                        pszNomEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        msNomEmpresa = pszNomEmpresa;
                        ID_MEM_NLG_EB.Text = pszNomEmpresa.Trim(); //El nombre de la empresa
                        ID_MEM_TEX_PNL[1].Text = pszNomEmpresa.Trim();
                        ID_MEM_TEX_PNL[2].Text = StringsHelper.Format(CORVAR.lgblNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
                        mtcEjeEmpOriginal.sEjeNombre = pszNomEmpresa;

                        pszNomCorto = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                        msNomCorto = pszNomCorto;
                        ID_MEM_NCT_EB.Text = pszNomCorto.Trim(); //Nombre corto
                        mtcEjeEmpOriginal.sEjeNomGrabado = pszNomCorto;

                        pszRFC = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                        msRFC = pszRFC;
                        mtcEjeEmpOriginal.sEjeRFC = pszRFC;
                        System.DateTime TempDate = DateTime.FromOADate(0);
                        ID_MEM_RFC_MKE.SelText = (DateTime.TryParse(pszRFC, out TempDate)) ? TempDate.ToString("   -      -   ") : pszRFC; //Su Rfc

                        dCartera = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 5));
                        mdCartera = dCartera;
                        ID_MEM_CAR_PIC.CtlText = StringsHelper.Format(dCartera, "##########"); //Número de Cartera

                        pszAccionista = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                        msAccionista = pszAccionista;
                        ID_MEM_PAC_EB.Text = pszAccionista.Trim(); //Principal Accionista

                        iSector = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 7)));
                        ID_MEM_SEC_COB.SelectedIndex = iSector - 1;
                        miSector = iSector - 1;

                        lCreditoGlobal = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 8)));
                        mlCreditoGlobal = lCreditoGlobal;
                        ID_MEM_CRE_FTB.CtlText = lCreditoGlobal.ToString(); //Credito global otorgado
                        lLeeCreditoGlobal = Int32.Parse(ID_MEM_CRE_FTB.CtlText);
                        mtcEjeEmpOriginal.lEjeLimiteCredito = lCreditoGlobal;

                        pszFecVenc = VBSQL.SqlData(CORVAR.hgblConexion, 9);
                        msFecVenc = pszFecVenc;
                        ID_MEM_FEC_VEN_DTB.CtlText = pszFecVenc;

                        pszCalleFis = VBSQL.SqlData(CORVAR.hgblConexion, 10);
                        msCalleFis = pszCalleFis;
                        ID_MEM_DOM_EB[0].Text = pszCalleFis.Trim(); //Domicilio fiscal

                        pszColoniaFis = VBSQL.SqlData(CORVAR.hgblConexion, 11);
                        msColoniaFis = pszColoniaFis;
                        ID_MEM_COL_EB[0].Text = pszColoniaFis.Trim(); //Colonia

                        pszCiudadFis = VBSQL.SqlData(CORVAR.hgblConexion, 12);
                        msCiudadFis = pszCiudadFis;
                        ID_MEM_CIU_EB[0].Text = pszCiudadFis.Trim(); //Ciudad

                        pszPoblacionFis = VBSQL.SqlData(CORVAR.hgblConexion, 13);
                        msPoblacionFis = pszPoblacionFis;
                        ID_MEM_PDM_EB[0].Text = pszPoblacionFis.Trim(); //Población

                        pszEstadoFis = VBSQL.SqlData(CORVAR.hgblConexion, 14);
                        msEstadoFis = pszEstadoFis;
                        CRSGeneral.prBuscaEstado(ID_MEM_EDO_EB[0], pszEstadoFis.Trim()); //Estado

                        lCpFis = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 15)));
                        mlCpFis = lCpFis;
                        ID_MEM_CP_PIC[0].CtlText = StringsHelper.Format(lCpFis, "00000"); //Código Postal

                        pszTelefono = VBSQL.SqlData(CORVAR.hgblConexion, 16).Trim();
                        msTelefono = pszTelefono.Trim();
                        //ID_MEM_CON_TXT.Text = Format(pszTelefono, "############")               'Teléfono hace que aparezca en nulo, cuando trae 0
                        ID_MEM_CON_TXT.Text = pszTelefono;

                        pszCalleEnv = VBSQL.SqlData(CORVAR.hgblConexion, 17);
                        ID_MEM_DOM_EB[1].Text = pszCalleEnv.Trim(); //Domicilio de Envío
                        mtcEjeEmpOriginal.sEjeCalle = pszCalleEnv;

                        pszColoniaEnv = VBSQL.SqlData(CORVAR.hgblConexion, 18);
                        ID_MEM_COL_EB[1].Text = pszColoniaEnv.Trim(); //Colonia
                        mtcEjeEmpOriginal.sEjeColonia = pszColoniaEnv;

                        pszLada = VBSQL.SqlData(CORVAR.hgblConexion, 19).Trim();
                        msLada = pszLada.Trim();
                        //ID_MEM_LADA_TXT.Text = Format(pszLada, "##########")                    'Lada
                        ID_MEM_LADA_TXT.Text = pszLada;

                        pszFax = VBSQL.SqlData(CORVAR.hgblConexion, 20).Trim();
                        msFax = pszFax.Trim();
                        //ID_MEM_FAX_TXT.Text = Format(pszFax, "####################")            'Fax
                        ID_MEM_FAX_TXT.Text = pszFax;
                        mtcEjeEmpOriginal.sEjeFax = pszFax;

                        pszEmail = VBSQL.SqlData(CORVAR.hgblConexion, 23);
                        msEmail = pszEmail;
                        ID_MEM_EMAIL_TXT.Text = pszEmail; //Email

                        pszInternet = VBSQL.SqlData(CORVAR.hgblConexion, 24);
                        msInternet = pszInternet;
                        ID_MEM_INTER_TXT.Text = pszInternet; //velocidad de transmision

                        pszCiudadEnv = VBSQL.SqlData(CORVAR.hgblConexion, 25);
                        ID_MEM_CIU_EB[1].Text = pszCiudadEnv.Trim(); //Ciudad

                        pszPoblacionEnv = VBSQL.SqlData(CORVAR.hgblConexion, 26);
                        ID_MEM_PDM_EB[1].Text = pszPoblacionEnv.Trim(); //Población
                        mtcEjeEmpOriginal.sEjePoblacion = pszPoblacionEnv;

                        pszEstadoEnv = VBSQL.SqlData(CORVAR.hgblConexion, 27);
                        CRSGeneral.prBuscaEstado(ID_MEM_EDO_EB[1], pszEstadoEnv.Trim()); //Estado
                        mtcEjeEmpOriginal.sEjeEstado = pszEstadoEnv;

                        lCpEnv = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 28)));
                        ID_MEM_CP_PIC[1].CtlText = StringsHelper.Format(lCpEnv, "00000"); //Código Postal
                        mtcEjeEmpOriginal.lEjeCP = lCpEnv;

                        pszCNumAnt = pszCalleEnv.Trim();
                        pszColoniaAnt = pszColoniaEnv.Trim();
                        pszAntPobAnt = pszCiudadEnv.Trim();
                        pszCiudadAnt = pszPoblacionEnv.Trim();
                        pszEstadoAnt = pszEstadoEnv.Trim();
                        lCpAnt = lCpEnv;

                        dCtaCaptacion = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 29));
                        mdCtaCaptacion = dCtaCaptacion;
                        ID_MEM_NMC_FTB.CtlText = dCtaCaptacion.ToString(); //Cuenta de Captación

                        iSucursal = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 30)));
                        miSucursal = iSucursal;
                        ID_MEM_SUC_ITB.CtlText = iSucursal.ToString(); //Sucursal

                        pszTipoPago = VBSQL.SqlData(CORVAR.hgblConexion, 31);
                        msTipoPago = pszTipoPago;
                        msTipoPagoGen = pszTipoPago; 
                        switch (pszTipoPago)
                        {
                            case STR_AUTO:
                                ID_MEM_TPA_3OPB[0].Checked = true;
                                break;
                            case STR_IND:
                                ID_MEM_TPA_3OPB[1].Checked = true;
                                break;
                            case STR_LIB:
                                ID_MEM_TPA_3OPB[2].Checked = true;
                                break;
                        }

                        pszTipoEnv = VBSQL.SqlData(CORVAR.hgblConexion, 32);
                        if (pszTipoEnv == STR_IND)
                        { //Tipo de envío
                            pszEnvioIni = STR_IND;
                            ID_MEM_EEC_3OPB[1].Checked = true;
                        }
                        else
                        {
                            pszEnvioIni = STR_EMP;
                            ID_MEM_EEC_3OPB[0].Checked = true;
                        }
                        msTipoEnv = pszEnvioIni;

                        pszNombreR1 = VBSQL.SqlData(CORVAR.hgblConexion, 33);
                        msNombreR1 = pszNombreR1;
                        ID_MEM_NOM_EB[0].Text = pszNombreR1.Trim(); //Nombre de Representante 1
                        if (pszNombreR1.Trim() != CORVB.NULL_STRING)
                        {
                            CORVAR.bgblFirma1 = -1;
                        }

                        pszPuestoR1 = VBSQL.SqlData(CORVAR.hgblConexion, 34);
                        msPuestoR1 = pszPuestoR1;
                        ID_MEM_PUE_EB[0].Text = pszPuestoR1.Trim(); //Puesto

                        pszTelR1 = VBSQL.SqlData(CORVAR.hgblConexion, 35).Trim();
                        msTelR1 = pszTelR1.Trim();
                        //ID_MEM_TEL_MKE(0).Text = Format$(pszTelR1, "############")              'Telefono
                        ID_MEM_TEL_MKE[0].CtlText = pszTelR1;

                        pszExtR1 = VBSQL.SqlData(CORVAR.hgblConexion, 36).Trim();
                        msExtR1 = pszExtR1.Trim();
                        //ID_MEM_EXT_PIC(0).Text = Format$(pszExtR1, "######")                    'Extension
                        ID_MEM_EXT_PIC[0].CtlText = pszExtR1;


                        pszFaxR1 = VBSQL.SqlData(CORVAR.hgblConexion, 37).Trim();
                        msFaxR1 = pszFaxR1.Trim();
                        //ID_MEM_FAX_MKE(0).Text = Format$(pszFaxR1, "############")              'Fax
                        ID_MEM_FAX_MKE[0].CtlText = pszFaxR1;

                        pszNombreR2 = VBSQL.SqlData(CORVAR.hgblConexion, 38);
                        msNombreR2 = pszNombreR2;
                        ID_MEM_NOM_EB[1].Text = pszNombreR2.Trim(); //Nombre de Representante 2
                        if (pszNombreR2.Trim() != CORVB.NULL_STRING)
                        {
                            CORVAR.bgblFirma2 = -1;
                        }

                        pszPuestoR2 = VBSQL.SqlData(CORVAR.hgblConexion, 39);
                        msPuestoR2 = pszPuestoR2;
                        ID_MEM_PUE_EB[1].Text = pszPuestoR2.Trim(); //Puesto

                        pszTelR2 = VBSQL.SqlData(CORVAR.hgblConexion, 40).Trim();
                        msTelR2 = pszTelR2.Trim();
                        //ID_MEM_TEL_MKE(1).Text = Format$(pszTelR2, "############")              'Telefono
                        ID_MEM_TEL_MKE[1].CtlText = pszTelR2;

                        pszExtR2 = VBSQL.SqlData(CORVAR.hgblConexion, 41).Trim();
                        msExtR2 = pszExtR2.Trim();
                        //ID_MEM_EXT_PIC(1).Text = Format$(pszExtR2, "######")                    'Extension
                        ID_MEM_EXT_PIC[1].CtlText = pszExtR2;

                        pszFaxR2 = VBSQL.SqlData(CORVAR.hgblConexion, 42).Trim();
                        msFaxR2 = pszFaxR2.Trim();
                        //ID_MEM_FAX_MKE(1).Text = Format$(pszFaxR2, "############")              'Fax
                        ID_MEM_FAX_MKE[1].CtlText = pszFaxR2;

                        pszNombreR3 = VBSQL.SqlData(CORVAR.hgblConexion, 43);
                        msNombreR3 = pszNombreR3;
                        ID_MEM_NOM_EB[2].Text = pszNombreR3.Trim(); //Nombre de Representante 3
                        if (pszNombreR3.Trim() != CORVB.NULL_STRING)
                        {
                            CORVAR.bgblFirma3 = -1;
                        }

                        pszPuestoR3 = VBSQL.SqlData(CORVAR.hgblConexion, 44);
                        msPuestoR3 = pszPuestoR3;
                        ID_MEM_PUE_EB[2].Text = pszPuestoR3.Trim(); //Puesto

                        pszTelR3 = VBSQL.SqlData(CORVAR.hgblConexion, 45).Trim();
                        msTelR3 = pszTelR3.Trim();
                        //ID_MEM_TEL_MKE(2).Text = Format$(pszTelR3, "############")              'Telefono
                        ID_MEM_TEL_MKE[2].CtlText = pszTelR3;

                        pszExtR3 = VBSQL.SqlData(CORVAR.hgblConexion, 46).Trim();
                        msExtR3 = pszExtR3.Trim();
                        //ID_MEM_EXT_PIC(2).Text = Format$(pszExtR3, "######")                    'Extension
                        ID_MEM_EXT_PIC[2].CtlText = pszExtR3;

                        pszFaxR3 = VBSQL.SqlData(CORVAR.hgblConexion, 47).Trim();
                        msFaxR3 = pszFaxR3.Trim();
                        //ID_MEM_FAX_MKE(2).Text = Format$(pszFaxR3, "############")              'Fax
                        ID_MEM_FAX_MKE[2].CtlText = pszFaxR3;

                        lCredAcum = VBSQL.SqlData(CORVAR.hgblConexion, 48);
                        mlCredAcum = Convert.ToInt32(Conversion.Val(lCredAcum));
                        ID_MEM_CRED_ACUM_FTB.CtlText = lCredAcum.ToString(); //Credito Acumulado

                        pszTelExt = VBSQL.SqlData(CORVAR.hgblConexion, 49).Trim();
                        msTelExt = pszTelExt.Trim();
                        //ID_MEM_TEL_EXT_TXT.Text = Format$(pszTelExt, "##########")              'Ext. Telef.
                        ID_MEM_TEL_EXT_TXT.Text = pszTelExt;

                        pszFaxLada = VBSQL.SqlData(CORVAR.hgblConexion, 50).Trim();
                        msFaxLada = pszFaxLada.Trim();
                        //ID_MEM_FAX_LADA_TXT.Text = Format(pszFaxLada, "##########")             'Fax Lada
                        ID_MEM_FAX_LADA_TXT.Text = pszFaxLada;

                        ilDiaCorte = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 51));
                        mskDiaCorte.defaultText = ilDiaCorte.ToString(); //Dia de corte

                        ilPlazoGracia = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 52));
                        ilPlazoGraciaGen = ilPlazoGracia;
                        mskPeriodoGracia.defaultText = ilPlazoGracia.ToString(); //Plazo de gracia

                        ilPlazoNoCobro = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 53));
                        ilPlazoNoCobroGen = ilPlazoNoCobro;
                        mskPerNoInteres.defaultText = ilPlazoNoCobro.ToString(); //Plazo de no cobro de intereses

                        ilTablaMCC = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 54));
                        ilTablaMCCCambio = ilTablaMCC; //Bloqueo de MCC
                        mskMCC.defaultText = ilTablaMCC.ToString();

                        ilGeneraSBF = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 55));
                        ilGeneraSBFgen = ilGeneraSBF;
                        prConfiguraSBF(ilGeneraSBF); //Genera SBF

                        slTipoFactura = VBSQL.SqlData(CORVAR.hgblConexion, 56);
                        mtcEjeEmpOriginal.sTipoFacturacion = slTipoFactura;
                        if (slTipoFactura == CRSParametros.cteCorporativo)
                        {
                            ID_MEM_TFA_3OPB[0].Checked = true; //Tipo de facturación
                            ID_MEM_TFA_3OPB[1].Checked = false;
                        }
                        else if (slTipoFactura == CRSParametros.cteIndividual)
                        {
                            ID_MEM_TFA_3OPB[0].Checked = false;
                            ID_MEM_TFA_3OPB[1].Checked = true;
                        }

                        slEsquemaPago = VBSQL.SqlData(CORVAR.hgblConexion, 57); //Esquema de Pago

                        slTipoProducto = VBSQL.SqlData(CORVAR.hgblConexion, 58);
                        slTipoProductoGen = slTipoProducto;

                        switch (slTipoProducto)
                        {
                            case CRSParametros.cteBusinessCard:
                                optTipoProducto[0].Checked = true;
                                optTipoProducto[1].Checked = false;
                                optTipoProducto[2].Checked = false;
                                break;
                            case CRSParametros.ctePurchasingCard:  //Tipo de producto 
                                optTipoProducto[0].Checked = false;
                                optTipoProducto[1].Checked = true;
                                optTipoProducto[2].Checked = false;
                                break;
                            case CRSParametros.cteDistributionLine:
                                optTipoProducto[0].Checked = false;
                                optTipoProducto[1].Checked = false;
                                optTipoProducto[2].Checked = true;
                                break;
                        }

                        llEstructuraGastos = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 59)); //Estructura de Gastos
                        llEstructuraGastosGen = llEstructuraGastos;
                        cboEstructuraGastos.SelectedIndex = CRSParametros.ifncBuscaEnCombo(llEstructuraGastos, cboEstructuraGastos);

                        ilMesFiscal = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 60));
                        ilMesFiscalGen = ilMesFiscal;
                        ID_MEM_MES_FIS_CBO.SelectedIndex = ilMesFiscal - 1; //Mes Fiscal

                        slUsuarioCambio = VBSQL.SqlData(CORVAR.hgblConexion, 61);

                        llFechaAlta = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 62));

                        llFechaUpdate = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 63));

                        llHoraUpdate = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 64));

                        ilMontoPorciento = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 65));
                        ilMontoPorcientoGen = ilMontoPorciento;
                        mskPorcientoMinimo1.defaultText = ilMontoPorciento.ToString(); //Porcentaje Mínimo de Pago

                        dlFacturacionMinima = Double.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 66));
                        dlFacturacionMinimaGen = dlFacturacionMinima;
                        mskMontoMinimo.defaultText = dlFacturacionMinima.ToString(); //Monto mínimo de pago

                        slCuentaContable = VBSQL.SqlData(CORVAR.hgblConexion, 67);
                        slCuentaContableGen = slCuentaContable;
                        txtCuentaContable.Text = slCuentaContable; //Cuenta Contable

                        ilSkipPayment = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 68));
                        ilSkipPaymentCambio = ilSkipPayment; //Skip Payment
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        chkSkipPayment.CheckState = (CheckState)ilSkipPayment;

                        mdlParametros.igEmpTipoBloqueo = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 69)); //Tipo de Bloqueo (Empresa)
                        ilTipoBloqueoCambio = mdlParametros.igEmpTipoBloqueo;
                        switch (mdlParametros.igEmpTipoBloqueo)
                        {
                            case 0:
                                optEmpresa[0].Checked = true;
                                break;
                            case 1:
                                optEmpresa[1].Checked = true;
                                break;
                            case 2:
                                optEmpresa[2].Checked = true;
                                break;
                        }

                        if (VBSQL.SqlData(CORVAR.hgblConexion, 70).Trim() == "")
                        {
                            ChkCDF.CheckState = CheckState.Unchecked;
                            ilEnvioCDF = 0;
                        }
                        else
                        {
                            ilEnvioCDF=Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 70));
                            ChkCDF.CheckState = (CheckState)(ilEnvioCDF);
                        }

                        //***** FSWB NR 20070223 INICIO
                        pszAtencionA = VBSQL.SqlData(CORVAR.hgblConexion, 71); //FSWB NR 20070223
                        slAtencionA = pszAtencionA.Trim(); //FSWB 20070223 NR Se incluyen campos Atencion A y Persona

                        txtAtencionA.Text = pszAtencionA.Trim(); //FSWB NR 20070223
                        try
                        {
                            pszPersona = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 72));
                        }
                        catch { }
                        ilPersona = pszPersona;
                        if ((pszPersona == 1) && (ID_MEM_PERSONA.SelectedIndex != -1))
                        {
                            ID_MEM_PERSONA.SelectedIndex = 0;
                        }
                        else if (pszPersona == 2)
                        {
                            ID_MEM_PERSONA.SelectedIndex = 1;
                        }
                        else if (pszPersona == 3)
                        {
                            ID_MEM_PERSONA.SelectedIndex = 2;
                        }

                        //***** FSWB NR 20070223 FIN

                        if (Tag.ToString() == CORCONST.TAG_CAMBIO)
                        {
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                            iTempErr = Obtiene_Ejecutivos();
                            if (iErr == CORCONST.OK)
                            {
                                ID_MEM_NOM_COB.SelectedIndex = Busca_EnCombo(StringsHelper.Format(ID_MEM_NNA_EB.Text, "0000000"));
                            }
                            else
                            {
                                result = 0;
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                return result;
                            }
                        }
                        else
                        {
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                            iTempErr = Obtiene_Ejecutivos();
                            if (iErr == CORCONST.OK)
                            {
                                ID_MEM_NOM_COB.SelectedIndex = Busca_EnCombo(StringsHelper.Format(lNominaEjeBNX, "0000000"));
                                ID_MEM_NOM_TXT.Text = ID_MEM_NOM_COB.Text;
                            }
                            else
                            {
                                result = 0;
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                return result;
                            }
                        }
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                ID_MEM_CLI_MKE.CtlText = StringsHelper.Format(lcteCliente.fncObtenClienteL(mdlParametros.gprdProducto, CORVAR.lgblNumEmpresa), "########");
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        private int Obtiene_Ejecutivos()
        {

            int result = 0;
            int hBufEje = 0; //Apunta a la sentencia SQL
            int iTempErr = 0; //Control local
            string pszNomEje = String.Empty; //El ejecutivo a obtener
            int lNominaEje = 0; //Número de Nómina del Ejecutivo

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                iErr = CORCONST.OK;
                CORVAR.pszgblsql = "select ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "ejx_numero,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "ejx_nombre ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCEJX01 ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "order by ejx_nombre";

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    ID_MEM_NOM_COB.Items.Clear();

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        lNominaEje = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        pszNomEje = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_MEM_NOM_COB.Items.Add(StringsHelper.Format(lNominaEje, "0000000") + "   " + pszNomEje.Trim());
                    };

                    if (ID_MEM_NOM_COB.Items.Count != 0)
                    {
                        ID_MEM_NOM_COB.SelectedIndex = CORVB.NULL_INTEGER;
                        result = -1;
                    }
                    else
                    {
                        result = 0;
                    }
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Manda los Datos de Envío de una determinda em-      **
        //**                    presa despues de verificarse que hubo un cambio     **
        //**                    en éste (Ver documentación)
        //**                                                                        **
        //**       Declaración: Sub Opera_CambiosMasivos                            **
        //**                                                                        **
        //**       Paso de parámetros: pszNE - el número de la empresa              **
        //**                                                                        **
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr - Error generado por Sybase                **
        //**                                                                        **
        //**       Ultima modificacion: 060694                                      **
        //**                                                                        **
        //****************************************************************************
        //UPGRADE_NOTE: (7001) The following declaration (Opera_CambiosMasivos) seems to be dead code
        //private void  Opera_CambiosMasivos( string pszNE,  string pszCalle,  string pszCol,  string pszCiudad,  string pszEstado,  string pszCP)
        //{
        //
        //string pszSQL = String.Empty;
        //int hBufTHS = 0;
        //int hBufCambiosM = 0;
        //int iRegMod = 0;
        //int iTempErr = 0;
        //
        //
        //***** INICIO CODIGO NUEVO FSWBMX *****
        ////UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
        //try
        //{
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //this.Cursor = Cursors.WaitCursor;
        //
        //iErr = CORCONST.OK;
        //
        //CORVAR.pszgblsql = "insert " + CORBD.DB_SYB_CMA + " select " + CORBD.DB_SYB_THS + ".eje_prefijo,";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + CORBD.DB_SYB_THS + ".gpo_banco," + CORBD.DB_SYB_THS + ".emp_num, eje_num,eje_roll_over,";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_digit, emp_envio_calle,emp_envio_col,emp_envio_pob,emp_envio_cp,";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_envio_ciu,emp_envio_edo from " + CORBD.DB_SYB_THS + "," + CORBD.DB_SYB_EMP;
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //pszgblsql = pszgblsql + " where " + DB_SYB_THS + ".gpo_banco=" + Format$(igblBanco)
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " where " + CORBD.DB_SYB_THS + ".eje_prefijo=" + CORVAR.igblPref.ToString() + " and " + CORBD.DB_SYB_THS + ".gpo_banco=" + CORVAR.igblBanco.ToString();
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and " + CORBD.DB_SYB_THS + ".gpo_banco=" + CORBD.DB_SYB_EMP + ".gpo_banco ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and " + CORBD.DB_SYB_THS + ".emp_num=" + CORBD.DB_SYB_EMP + ".emp_num and " + CORBD.DB_SYB_EMP + ".emp_num=" + pszNE;
        //
        //
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //
        //Actualiza a los Ejecutivo con la nueva dirección de envio de la empresa
        //pszCiudad = pszCiudad.Trim();
        //pszCiudad = Strings.Mid(pszCiudad, 1, pszCiudad.Length - 1);
        //pszEstado = pszEstado.Trim();
        //pszEstado = Strings.Mid(pszEstado, 2);
        //
        //CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_EJE + " SET eje_calle = " + pszCalle + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_col = " + pszCol + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_pob = " + pszCiudad + " " + pszEstado.Trim() + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cp = " + Conversion.Str(Conversion.Val(pszCP));
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + pszNE;
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //this.Cursor = Cursors.Default;
        //}
        //catch (Exception exc)
        //{
        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //}
        //
        //}




        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Realiza los cambios masivos en el S111 y en el      **
        //**                    micro. Realizando primero el proceso en el S111     **
        //**                    y si este fue exito se realiza en el micro.         **
        //**                    Y  realiza una bitacora de los errores              **
        //**                                                                        **
        //**                                                                        **
        //**       Paso de parámetros:                                              **
        //**                                                                        **
        //**       Valor de Regreso: función booleana                               **
        //**                                                                        **
        //**                                                                        **
        //**       Ultima modificacion: 12oct98                                     **
        //**                                                                        **
        //****************************************************************************
        private bool RealizaCambiosMasivosEmp(int pLngNumEmp, N_ActualizaS111.ClsConectaS111 objTransS111)
        {
            //Parametro de enntrada:
            //   pLngNumEmp : Numero de empresa a realizar los cambios masivos
            bool result = false;
            string pszSQL = String.Empty;
            string pszCadena = String.Empty;
            string pszPrefijo = String.Empty;
            string pszBanco = String.Empty;
            int lEmpresa = 0;
            string pszEmpresas = String.Empty;
            int iEjeNum = 0;
            int iEjeDig = 0;
            int iRollOver = 0;
            string pszCalle = String.Empty;
            string pszColonia = String.Empty;
            string pszPob = String.Empty;
            string pszCP = String.Empty;
            string pszNumCuenta = String.Empty;
            string pszNombre = String.Empty;
            string pszZP = String.Empty;
            string pszTelPart = String.Empty;
            string pszTelOfi = String.Empty;
            string pszExt = String.Empty;
            string pszSubActi = String.Empty;
            string slRFC = String.Empty;
            string pszCalleEmp = String.Empty;
            string pszColEmp = String.Empty;
            string pszPobEmp = String.Empty;
            string pszEdoEmp = String.Empty;
            int lCPEmp = 0;
            bool bCambio = false;
            string pszSexo = String.Empty;
            StringBuilder pszEnviaS111 = new StringBuilder();
            pszEnviaS111.Append(String.Empty);
            string pszRegresaS111 = String.Empty;
            int hTemp = 0;
            string pszEspacio = String.Empty;
            string pszMensajeS111 = String.Empty;
            string pszEdo = String.Empty;
            string pszTipo = String.Empty;
            string pszCiudad = String.Empty;
            bool blTerminaconexion = false;
            bool blCamEmpresa = false;
            bool blErrorEnvio = false;
            bool bConComDrive = false;

            bool blContinue = false;
            object slDialogo = null;
            string slRespuesta = String.Empty;
            string slBloque = String.Empty;
            string slCausaError = String.Empty;
            int ilcont = 0;
            int ilLongitudMsg = 0;
            int ilResultado = 0;
            decimal dresult = 0;
            bool bolActualizaEjecutivo = false;
            TransS111.EnumRespTransaccion EnRespTransS111 = (TransS111.EnumRespTransaccion)0;
            //Dim objTransS111 As ClsConectaS111
            TransS111.EnumEstadosFirma EnCausaErrorFirma = (TransS111.EnumEstadosFirma)0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                this.Cursor = Cursors.WaitCursor;
                mdlSeguridad.EnviaLog("Iniciando Funcion RealizaCambiosMasivosEmp ");
                result = false;
                iErr = CORCONST.OK;
                int lTempRow = CORVB.NULL_INTEGER;
                int iCountRow = CORVB.NULL_INTEGER;
                int iFlood = CORVB.NULL_INTEGER;
                int bColorCambiado = 0;
                bool bHayCambios = false;

                int iRegs;
                //string connectionString = "Dsn=c430;uid=c430_dbo;pwd=" + CORDBLIB.gsPassword;
                //string connectionString = "Dsn=" + CORDBLIB.gsServidor+"; uid ="+CORDBLIB.gsUsuario+";pwd=" + CORDBLIB.gsPassword;
                string connectionString = "Dsn=" + CORDBLIB.gsServidor + "; uid =" + CORDBLIB.gsUsuario + ";pwd=" + CORDBLIB.gsPassword + ";keeporgmultibyte=1" + ";Charset=iso_1;";
                OdbcConnection conexion = new OdbcConnection(connectionString);

                //realiza la segunda conexión
                intCont = CORDBLIB.Segunda_ConexionServidor();

                if (intCont == 0)
                {
                    this.Cursor = Cursors.Default;
                    Interaction.MsgBox(CORSTR.STR_NO_CONEXION, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONSTOP)), CORSTR.STR_APP_TIT);
                    CORPROC2.Libera_Memoria(CORVAR.hgblConexion2);
                    VBSQL.SqlClose(CORVAR.hgblConexion2); //Realiza Desconexión
                    return true;
                }

                Application.DoEvents();

                //Se establece el status bar
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = Threed.enumFloodTypeConstants._LeftToRight;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodShowPct = true;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short)CORVB.NULL_INTEGER;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.BLACK);
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambios Masivos";
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = true;

                //cosnulta a la tabla de Cambios masivos
                CORVAR.pszgblsql = " SELECT eje_prefijo,gpo_banco,emp_num,eje_num,eje_roll_over, ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_digit,cam_calle,cam_col,cam_pob,cam_zp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_cp, cam_tel_dom,cam_tel_ofi,cam_ext,cam_sexo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_acti_subacti,cam_calle_emp,cam_col_emp,cam_pob_emp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " cam_cp_emp,eje_nombre,cam_estado_emp,cam_tipo, cam_rfc";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " FROM " + CORBD.DB_SYS_CAM;
                CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pLngNumEmp.ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_mensaje = ''";

                OdbcCommand command = new OdbcCommand(CORVAR.pszgblsql, conexion);
                conexion.Open();
                OdbcDataReader reader = command.ExecuteReader();

                mdlSeguridad.EnviaLog("Consultando Tabla de Cambios Masivos");
                //obtiene el total de registros
                lTempRow = CORPROC2.Cuenta_Registros();
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                //int iBaseConteo = Int32.Parse(mdlParametros.fncReadIniS("Corporativa", "baseRegProcS111"));
                int iBaseConteo = Int32.Parse(mdlParametros.valorRegistro(2, "SOFTWARE\\Banamex\\C430_001\\TarjetaCorporativa\\Parametros", "baseRegProcS111").Trim());
                int lMultiplos = iBaseConteo;
                int lContador = 0;
                string StrRegs = lTempRow.ToString();
                if (lTempRow > iBaseConteo)
                {
                    this.Cursor = Cursors.Default;
                    // 25-Mar-2010 Cambios Masivos
                    int iResp = (int)Interaction.MsgBox("IMPORTANTE El numero de Tarjetahabientes a cambiar de la empresa " + ID_MEM_NLG_EB.Text.Trim() + " es de " + StrRegs + " y este proceso va a tardar mas ¿Desea Continuar?", (MsgBoxStyle)(CORVB.MB_YESNO + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    if (iResp == CORVB.IDNO)
                    {
                        reader.Close();
                        conexion.Close();
                        return false;
                    }
                    //
                }

                this.Cursor = Cursors.WaitCursor;
                if (lTempRow != 0)
                {
                    // 25-Mar-2010 Cambios Masivos
                    while (reader.Read())
                    //
                    {
                        lContador++;

                        bCambio = false;

                        pszPrefijo = reader[0].ToString();
                        pszBanco = reader[1].ToString();
                        lEmpresa = Convert.ToInt32(Conversion.Val(reader[2].ToString()));
                        pszEmpresas = StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
                        iEjeNum = Convert.ToInt32(Conversion.Val(reader[3].ToString()));
                        iRollOver = Convert.ToInt32(Conversion.Val(reader[4].ToString()));
                        iEjeDig = Convert.ToInt32(Conversion.Val(reader[5].ToString()));
                        pszCalle = reader[6].ToString();
                        pszColonia = reader[7].ToString();
                        pszPob = reader[8].ToString();
                        pszZP = Conversion.Val(reader[9].ToString()).ToString();
                        pszCP = reader[10].ToString();
                        //pszTelPart = (reader[11].ToString()).Substring((reader[11].ToString()).Length - Math.Min((reader[11].ToString()).Length, 7));
                        //pszTelOfi = (reader[12].ToString()).Substring((reader[12].ToString()).Length - Math.Min((reader[12].ToString()).Length, 7));
                        //pszExt = (reader[13].ToString()).Substring((reader[13].ToString()).Length - Math.Min((reader[13].ToString()).Length, 4));
                        pszTelPart = reader[11].ToString().Trim();
                        pszTelOfi = reader[12].ToString().Trim();
                        pszExt = reader[13].ToString().Trim();
                        pszSexo = reader[14].ToString();
                        pszSubActi = reader[15].ToString();
                        pszCalleEmp = reader[16].ToString();
                        pszColEmp = reader[17].ToString();
                        pszPobEmp = reader[18].ToString();
                        lCPEmp = Convert.ToInt32(Conversion.Val(reader[19].ToString()));
                        pszNombre = reader[20].ToString();
                        pszEdoEmp = reader[21].ToString();
                        pszTipo = reader[22].ToString();
                        slRFC = reader[23].ToString();

                        //arma el numero de cuenta del ejecutivo

                        pszNumCuenta = pszPrefijo + pszBanco + StringsHelper.Format(pszEmpresas, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(Conversion.Str(iEjeNum).Trim(), Formato.sMascara(Formato.iTipo.Ejecutivo)) + Conversion.Str(iRollOver).Trim() + Conversion.Str(iEjeDig).Trim();


                        bCambio = true;
                        pszCalle = pszCalleEmp;
                        pszColonia = pszColEmp;
                        pszPob = pszPobEmp + " " + pszEdoEmp;
                        pszCP = Conversion.Str(lCPEmp);

                        pszCiudad = CORPROC.Valida_Comilla(ID_MEM_CIU_EB[1].Text);

                        if ((pszCalle.Trim() == pszCNumAnt.Trim()) && (pszColonia.Trim() == pszColoniaAnt.Trim()) && (pszPob.Trim() == (pszPobEmp.Trim() + " " + pszEdoEmp.Trim())) && (Conversion.Val(pszCP) == Conversion.Val(lCpAnt.ToString())))
                        {

                            bCambio = true;
                            pszCalle = pszCalleEmp;
                            pszColonia = pszColEmp;
                            pszPob = pszPobEmp + " " + pszEdoEmp;
                            pszCP = Conversion.Str(lCPEmp);
                        }

                        if (pszSexo == CORVB.NULL_STRING)
                        {
                            pszSexo = " ";
                        }
                        if ( (pszTelPart == CORVB.NULL_STRING) || (pszTelPart=="") )
                        {
                            pszTelPart = new String(' ', 7);
                        }
                        if ((pszTelOfi == CORVB.NULL_STRING) || (pszTelOfi == ""))
                        {
                            pszTelOfi = new String(' ', 7);
                        }
                        if ((pszExt == CORVB.NULL_STRING) || pszExt == "")
                        {
                            pszExt = "0000";
                        }

                        // 25-Mar-2010 Cambios Masivos
                        if ((pszSubActi == CORVB.NULL_STRING) || (pszSubActi == "    "))
                        {
                            pszSubActi = "00";
                        }
                        //

                        if (pszNombre.Length <= 26)
                        {
                            pszEspacio = new String(' ', 26);
                            pszEspacio = StringsHelper.MidAssignment(pszEspacio, 1, Strings.Mid(pszNombre, 1, 26));
                            pszNombre = pszEspacio;
                        }
                        else
                        {
                            pszNombre = Strings.Mid(pszNombre, 1, 26);
                        }

                        if (pszCalle.Length <= 35)
                        {
                            pszEspacio = new String(' ', 35);
                            pszEspacio = StringsHelper.MidAssignment(pszEspacio, 1, Strings.Mid(pszCalle, 1, 35));
                            pszCalle = pszEspacio;
                        }
                        else
                        {
                            pszCalle = Strings.Mid(pszCalle, 1, 26);
                        }
                        if (pszColonia.Length <= 25)
                        {
                            pszEspacio = new String(' ', 25);
                            pszEspacio = StringsHelper.MidAssignment(pszEspacio, 1, Strings.Mid(pszColonia, 1, 25));
                            pszColonia = pszEspacio;
                        }
                        else
                        {
                            pszColonia = Strings.Mid(pszColonia, 1, 26);
                        }
                        if (pszPob.Length <= 25)
                        {
                            pszEspacio = new String(' ', 25);
                            pszEspacio = StringsHelper.MidAssignment(pszEspacio, 1, Strings.Mid(pszPob, 1, 25));
                            pszPob = pszEspacio;
                        }
                        else
                        {
                            pszPob = Strings.Mid(pszPob, 1, 26);
                        }
                        if (pszTelPart == new String(' ', 1))
                        {
                            pszTelPart = "0000000";
                        }
                        else
                        {
                            if (pszTelPart.Length < 7)
                            {
                                pszTelPart = StringsHelper.Format(pszTelPart, "0000000");
                            }
                            else
                            {
                                pszTelPart = Strings.Mid(pszTelPart, 1, 7);
                            }
                        }
                        if (pszTelOfi == new String(' ', 1))
                        {
                            pszTelOfi = "0000000";
                        }
                        else
                        {
                            if (pszTelOfi.Length < 7)
                            {
                                pszTelOfi = StringsHelper.Format(pszTelOfi, "0000000");
                            }
                            else
                            {
                                pszTelOfi = Strings.Mid(pszTelOfi, 1, 7);
                            }
                        }

                        if (pszCP == CORVB.NULL_STRING)
                        {
                            pszCP = "00000";
                        }
                        else
                        {
                            pszCP = StringsHelper.Format(pszCP, "00000");
                        }

                        if (pszZP == " ")
                        {
                            pszZP = "00";
                        }
                        else
                        {
                            pszZP = StringsHelper.Format(pszZP, "00");
                        }
                        //extension
                        if (pszExt == " ")
                        {
                            pszExt = "0000";
                        }
                        else
                        {
                            pszExt = StringsHelper.Format(pszExt, "0000");
                        }

                        slRFC = Seguridad.fncsSustituir(slRFC.Trim(), "-", "");
                        if (slRFC.Trim() == "")
                        {
                            slRFC = new string(CORVB.NULL_STRING[0], 13);
                        }

                        if (ID_MEM_EEC_3OPB[0].Checked)
                        {
                            pszTipo = "Empresa";
                        }
                        else if (ID_MEM_EEC_3OPB[1].Checked)
                        {
                            pszTipo = "Individual";
                        }

                        if (bCambio)
                        { //si hay diferencias

                            //cambia el valor de la bandera para saber que por lom menos hay un cambio
                            bHayCambios = true;

                            //arma la cadena para el S111

                            objTransS111.StrIdTransaccion = CORCONST.MODIFICA_EMPRESA_MASIVOS;
                            objTransS111.StrNoCuenta = pszNumCuenta;

                            pszEnviaS111 = new StringBuilder("");
                            pszEnviaS111.Append("M" + Strings.Chr(28).ToString()); //modificación
                            pszEnviaS111.Append(pszNombre + Strings.Chr(28).ToString()); //nombre
                            //* Inicio: EISSA (MRG) 2005-08-23
                            //*: Código Nuevo:
                            pszEnviaS111.Append(((pszSexo == "H") ? "M" : "F") + Strings.Chr(28).ToString());
                            //*: Código Anterior:
                            //*: pszEnviaS111 = pszEnviaS111 & pszSexo & Chr(28)
                            //* Fin: EISSA (MRG) 2005-08-23
                            pszEnviaS111.Append(pszCalle + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(pszColonia + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(pszZP + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(pszPob + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(pszCP + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(StringsHelper.Format(pszTelPart.Trim(), "0000000") + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(StringsHelper.Format(pszTelOfi.Trim(), "0000000") + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(StringsHelper.Format(pszExt.Trim(), "0000") + Strings.Chr(28).ToString());
                            pszEnviaS111.Append(StringsHelper.Format(Strings.Mid(pszSubActi.Trim(), 1, 2), "00") + Strings.Chr(28).ToString()); //actividad
                            pszEnviaS111.Append(StringsHelper.Format(Strings.Mid(pszSubActi.Trim(), 1, 2), "00") + Strings.Chr(28).ToString());

                            if (iEjeNum == 0)
                            {
                                pszEnviaS111.Append(" " + slRFC + Strings.Chr(28).ToString());
                            }
                            else
                            {
                                pszEnviaS111.Append(slRFC + Strings.Chr(28).ToString());
                            }

                            pszEnviaS111.Append(" ");
                            objTransS111.StrParametrosAdicionales = pszEnviaS111.ToString();
                            //slDialogo = "D" & pszEnviaS111 & Chr(3)
                            //AIS-1119 NGONZALEZ
                            String tempString = String.Empty;

                            // 25-Mar-2010 Cambios Masivos
                            bool tempRefParam1 = true;
                            string StrError = "";
                            do
                            {
                               
                                if ((StrError == ";  SEG; FAVOR\r\n") || (StrError == ";  SEG; VUELV\r\n"))
                                {
                                   
                                    frmLoginS53 frmFirma = new frmLoginS53();
                                    var regreso = frmFirma.ShowDialog();


                                    if (regreso.ToString() != "OK")
                                    {
                                    //if (!objTransS111.FnPreguntaPwd())
                                    //{
                                        if (EnCausaErrorFirma == TransS111.EnumEstadosFirma.EnSinRespuesta)
                                        {
                                            MdlCambioMasivo.MsgInfo("No se encontro respuesta del S111");
                                        }
                                    }
                                }
                                EnRespTransS111 = (TransS111.EnumRespTransaccion)objTransS111.FnEnviarTransaccion( tempString,  tempString,  tempString);
                                StrError = objTransS111.get_Msgerror(ref tempRefParam1);
                            }
                            while ((StrError == ";  SEG; FAVOR\r\n") || (StrError == ";  SEG; VUELV\r\n"));
                            //

                            if (EnRespTransS111 == TransS111.EnumRespTransaccion.EnRespTransaccionAceptada)
                            {
                                blErrorEnvio = false;
                                if (iEjeNum == 0)
                                {
                                    //Cuando se trate del ejecutivocero actualiza la tabla de empresas
                                    CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EMP + " set ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "', ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_calle ='" + pszCalle.Trim() + "',emp_envio_col='" + pszColonia.Trim() + "',emp_envio_ciu='" + pszCiudad.Trim() + "',";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_pob ='" + pszPobEmp.Trim() + "',emp_envio_edo='" + pszEdoEmp.Trim() + "',emp_envio_cp=" + pszCP;
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " , emp_telefono = '" + pszTelPart.Trim() + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " , emp_extension = '" + pszExt.Trim() + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " , emp_rfc = '" + slRFC + "'";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo=" + mdlParametros.gprdProducto.PrefijoL.ToString() + " and gpo_banco=" + mdlParametros.gprdProducto.BancoL.ToString() + " and emp_num =" + lEmpresa.ToString();
                                    //si la actualizacion de la empresa se hace correctamente actualiza ejecutivos
                                    iRegs = 0;
                                    using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                                    { iRegs = command1.ExecuteNonQuery(); }
                                    if (iRegs != 0)
                                    { bolActualizaEjecutivo = true; }
                                    else
                                    { bolActualizaEjecutivo = false; }
                                }
                                else
                                {
                                    //Solo actualiza la tabla de ejecutivos
                                    bolActualizaEjecutivo = true;
                                }
                                this.Cursor = Cursors.Default;
                                mdlSeguridad.EnviaLog("Actualizando Base local Con: " + CORVAR.pszgblsql);

                                if (bolActualizaEjecutivo)
                                {
                                    CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_EJE + " SET eje_calle = '" + pszCalle.Trim() + "',";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_usuario_cam = '" + CRSParametros.sgUserID + "', ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_col = '" + pszColonia.Trim() + "',";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_pob = '" + pszPobEmp.Trim() + "',";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_edo = '" + pszEdoEmp.Trim() + "',";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_cp = " + pszCP + ",";                                    
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_rfc = '" + slRFC + "',";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_fecha_cam =  convert(int , convert( char(12), getdate(),112 ) )  ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",eje_hora_cam = ";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + "datepart(hh,getdate()) *100 + datepart(mi,getdate())";
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString() + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString() + " and emp_num = " + lEmpresa.ToString();
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and  eje_num = " + iEjeNum.ToString();

                                    mdlSeguridad.EnviaLog("Actualizando Base local Con: " + CORVAR.pszgblsql);

                                    iRegs = 0;
                                    using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                                    { iRegs = command1.ExecuteNonQuery(); }
                                    if (iRegs != 0)
                                    {
                                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion2);
                                        CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYS_CAM + " SET cam_estado = 'Procesado'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString() + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString() + " and emp_num = " + lEmpresa.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and  eje_num = " + iEjeNum.ToString();
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'";
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_mensaje = ''";
                                        mdlSeguridad.EnviaLog("Actualizando Base local Con: " + CORVAR.pszgblsql);
                                        iRegs = 0;
                                        using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                                        { iRegs = command1.ExecuteNonQuery(); }
                                        if (iRegs != 0)
                                        { blCamEmpresa = true; }
                                        else
                                        { blCamEmpresa = false; }
                                    }
                                }
                                else
                                {
                                    blCamEmpresa = false;
                                }
                            }
                            else
                            {
                                blErrorEnvio = true;
                                bool tempRefParam = true;
                                pszRegresaS111 = objTransS111.GetMsgerror(ref tempRefParam);

                                // 25-Mar-2010 Cambios Masivos
                                pszRegresaS111 = pszRegresaS111.Substring(3, (pszRegresaS111.Length - 3));
                                pszRegresaS111 = pszRegresaS111.Replace("OPERACION NEGADA", "OPE NEG");
                                //

                                CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYS_CAM + " SET ";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "cam_mensaje = '" + pszRegresaS111 + "'";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + lEmpresa.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and  eje_num = " + iEjeNum.ToString();
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'";
                                mdlSeguridad.EnviaLog("Actualizando Base local Con: " + CORVAR.pszgblsql);
                                iRegs = 0;
                                using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                                { iRegs = command1.ExecuteNonQuery(); }
                            }
                        }
                        else
                        {
                            CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYS_CAM + " SET cam_estado = 'No Cambio'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " and emp_num = " + lEmpresa.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and  eje_num = " + iEjeNum.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_proceso = 'DomicilioEmp'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and cam_mensaje = ''";
                            mdlSeguridad.EnviaLog("Actualizando Base local Con: " + CORVAR.pszgblsql);
                            iRegs = 0;
                            using (OdbcCommand command1 = new OdbcCommand(CORVAR.pszgblsql, conexion))
                            { iRegs = command1.ExecuteNonQuery(); }
                        }

                        iCountRow++;

                        iFlood = Convert.ToInt32(Math.Floor((iCountRow / ((double)lTempRow)) * 100));
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent = (short)iFlood;
                        if ((((CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodPercent > 50) ? -1 : 0) & ~bColorCambiado) != 0)
                        {
                            CORMDIBN.DefInstance.ID_COR_MEDO_PNL.ForeColor = ColorTranslator.FromOle(CORVB.WHITE);
                            bColorCambiado = -1;
                        }

                        Application.DoEvents();

                        if (iEjeNum == 0 && pszTipo == "Individual")
                        {
                            break;
                        }

                    };
                    reader.Close();
                    conexion.Close();

                    if (bHayCambios && !blErrorEnvio)
                    {
                        if (blCamEmpresa)
                        {
                            Interaction.MsgBox("Se actualizaron los datos de domicilio de envío de la empresa " + ID_MEM_NLG_EB.Text.Trim() + " en el M111", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        }
                        else
                        {
                            MessageBox.Show("No se actualizaron los datos de domicilio de envío de la empresa " + ID_MEM_NLG_EB.Text.Trim() + " en el M111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Interaction.MsgBox("Terminó del proceso de cambios masivos.", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    else if (!bHayCambios)
                    {
                        Interaction.MsgBox("NO hay cambios masivos para la empresa ", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    else if (blErrorEnvio)
                    {
                        Interaction.MsgBox("Algunos cambios de Domicilio no pudieron ser realizados, intente reenviarlos con la opción de Pendientes S111", (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }

                }
                else
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    this.Cursor = Cursors.Default;
                    Interaction.MsgBox("No se obtuvieron registros en cambios masivos en la empresa ", (MsgBoxStyle)StringsHelper.IntValue(Conversion.Str(lEmpresa)), (((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)).ToString());
                }

                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.FloodType = CORVB.NONE;
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL.Caption = CORVB.NULL_STRING;
                CORMDIBN.DefInstance.ID_COR_MSG_TXT.Visible = false;
                this.Cursor = Cursors.Default;
                mdlSeguridad.EnviaLog("Solicita desfirmar el componente(RealizaCambiosMasivosEmp)");
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                //genera el archivo de procesados
                mdlSeguridad.EnviaLog("Genera_Achivos_Cambios CMProces.txt");
                string tempRefParam2 = "Procesado";
                string tempRefParam3 = "DomicilioEmp";
                CORPROC2.Genera_Achivos_Cambios("CMProces.txt", ref tempRefParam2, ref tempRefParam3, "Normal");
                //genera archivo de reg que no cambiaron
                mdlSeguridad.EnviaLog("Genera_Achivos_Cambios CMNoCamb.txt");
                string tempRefParam4 = "No Cambio";
                string tempRefParam5 = "DomicilioEmp";
                CORPROC2.Genera_Achivos_Cambios("CMNoCamb.txt", ref tempRefParam4, ref tempRefParam5, "Normal");
                //genera archivo de reg que no se procesaron y estan pendientes
                mdlSeguridad.EnviaLog("Genera_Achivos_Cambios CMPendie.txt");
                string tempRefParam6 = "No Proce";
                string tempRefParam7 = "DomicilioEmp";
                CORPROC2.Genera_Achivos_Cambios("CMPendie.txt", ref tempRefParam6, ref tempRefParam7, "Normal");
                //genera archivos para excel
                mdlSeguridad.EnviaLog("Genera_Achivos_Cambios DomEmpre.txt");
                string tempRefParam8 = "Procesado";
                string tempRefParam9 = "DomicilioEmp";
                CORPROC2.Genera_Achivos_Cambios("DomEmpre.txt", ref tempRefParam8, ref tempRefParam9, "Excel");

                mdlSeguridad.EnviaLog("Depura_Tabla_CamMasivos(DomicilioEmp)");
                //borra los registros procesados
                string tempRefParam10 = "DomicilioEmp";
                string tempRefParam11 = Conversion.Str(pLngNumEmp);
                Depura_Tabla_CamMasivos(ref tempRefParam10, ref tempRefParam11);

                this.Cursor = Cursors.Default;
                mdlSeguridad.EnviaLog("Fin de la funcion RealizaCambiosMasivosEmp");
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        //UPGRADE_NOTE: (7001) The following declaration (Alta_S111_Usuario_Emp) seems to be dead code
        //private bool Alta_S111_Usuario_Emp()
        //{
        //llama al aforma que realiza la conexión al s111
        //
        //if (EnvAccConexionEmp())
        //{
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("Clave de acceso incorrecta.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
        //return false;
        //}
        //
        //return false;
        //}

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Realiza las altas y cambios dependiendo del  -      **
        //**                    tipo de operación solicitada al catálogo de         **
        //**                    empresas (MTCEMP01)                                 **
        //**                                                                        **
        //**       Declaración: Sub Opera_Empresas ()                               **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: Ninguno                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr                                            **
        //**                                                                        **
        //**       Ultima modificacion: 030594                                      **
        //**                                                                        **
        //****************************************************************************'
        //UPGRADE_NOTE: (7001) The following declaration (Opera_Empresas) seems to be dead code
        //private void  Opera_Empresas()
        //{
        //int ilDigitoVer = 0;
        //string slCuentaEjecutivo0 = String.Empty;
        //
        //int hBufEmpresa = 0; //A la sentencia SQL de Empresa
        //int hBufconsec = 0; //A la sentencia SQL de Consecutivo
        //int iTempErr = 0; //Para control local
        //int iResp = 0;
        //int iIncremento = 0;
        //int bActualizarCM = 0;
        //
        //int hTransaction = 0;
        //string pszConsecEmp = String.Empty;
        //
        //Campos del catalogo
        //
        //int lNumEmpresa = 0;
        //string pszNumEmpresa = String.Empty;
        //
        //string pszCredAcum = String.Empty;
        //int lGpoCredTot = 0;
        //int lGpoCredAcum = 0;
        //int lSumaGpoCredAcum = 0;
        //string iVelTrns = String.Empty;
        //string pszTonoPul = String.Empty;
        //
        //Domicilio Fiscal
        //Domicilio de envío
        //Representantes
        //
        //
        //
        //string pszTipoPago = String.Empty;
        //string pszTipoEnv = String.Empty;
        //
        //string pszComunicacion = String.Empty;
        //string pszEnviaS111 = String.Empty;
        //string pszRegresaS111 = String.Empty;
        //string pszMensajeS111 = String.Empty;
        //string pszExiste = String.Empty;
        //int lID = 0;
        //
        //Dialogo
        //CRSDialogo.DatosDialogo dlgAlta = CRSDialogo.DatosDialogo.CreateInstance();
        //string sEnviaRut = String.Empty;
        //
        ////UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
        //try
        //{
        //
        //this.Cursor = Cursors.WaitCursor;
        //
        //bool bConComDrive = false;
        //bool bFlagCambios = false;
        //
        //string pszConcBco = Existen_Blancos();
        //if (pszConcBco.Length != 0)
        //{
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("Por favor suministre información en el Campo: " + Strings.Chr(CORVB.KEY_RETURN).ToString() + pszConcBco.ToUpper(), (MsgBoxStyle) (((int) CORVB.MB_ICONINFORMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //return;
        //}
        //Comentar en Producción
        //    Tag = "A"
        //if (Tag.ToString() == CORCONST.TAG_CAMBIO)
        //{ //Se trata de un cambio
        //compara los campos afectados para realizar un cambio masivo
        //if (ComparaDatosCambio())
        //{
        //Verifica que existe el condrive
        //pszExiste = FileSystem.Dir(CORVAR.pszgblPathComDrive, FileAttribute.Normal);
        //si existe el archivo
        //if (pszExiste != CORVB.NULL_STRING)
        //{
        //carga el condrive
        ////UPGRADE_WARNING: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo
        //ProcessStartInfo startInfo = new ProcessStartInfo(CORVAR.pszgblPathComDrive);
        //startInfo.WindowStyle = ProcessWindowStyle.Minimized;
        //lID = Convert.ToInt32(Process.Start(startInfo).Id);
        //} else
        //{
        //MessageBox.Show("No existe el archivo: " + CORVAR.pszgblPathComDrive, Application.ProductName);
        //return;
        //}
        //
        //verifica que se realize la conexión al S111 si hubo cambios en la dirección fiscal de la empresa
        //ConexionComDrive
        //this.Cursor = Cursors.Default;
        //ConComDrive.Tiempo = 15;
        //if (ConComDrive.Inicia_Conexion())
        //{
        //si existe conexión al S111 por medio del comdrive
        //if (EnvAccConexionEmp())
        //{
        //return;
        //} else
        //{
        //bConComDrive = true;
        //}
        //} else
        //{
        //si no existe conexión al S111 envia mensaj y sale de la función
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("No hay conexión al S111, intente mas tarde. ", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
        //return;
        //}
        //}
        //}
        //
        //this.Cursor = Cursors.WaitCursor;
        //
        //string pszBanco = CORVAR.igblBanco.ToString(); //El banco sobre el que se trabaja
        //string iNumGrupo = Conversion.Val(ID_MEM_TEX_PNL[0]._Caption.Substring(0, Math.Min(ID_MEM_TEX_PNL[0]._Caption.Length, 4))).ToString(); //La cuenta de grupo al que pertenece
        //string pszNumGrupo = iNumGrupo;
        //
        //string pszNomEmpresa = "'" + CORPROC.Valida_Comilla(ID_MEM_NLG_EB.Text.Trim()) + "'"; //Nombre de empresa
        //string pszNomCorto = "'" + CORPROC.Valida_Comilla(ID_MEM_NCT_EB.Text) + "'"; // //Nombre corto de la empresa
        //string pszNominaEjeBNX = Conversion.Val(ID_MEM_NOM_COB.Text).ToString(); //La nómina del ejecutivo Banamex
        //string pszRFC = Seguridad.fncsSustituir(ID_MEM_RFC_MKE.CtlText, "-", "");
        //pszRFC = "'" + CORPROC.Valida_Comilla(pszRFC) + "'"; //RFC
        //string pszCartera = Conversion.Val(ID_MEM_CAR_PIC.CtlText).ToString(); //No de cartera
        //string pszAccionista = "'" + CORPROC.Valida_Comilla(ID_MEM_PAC_EB.Text) + "'"; //principal accionista
        //string pszSector = Strings.Mid(ID_MEM_SEC_COB.Text, 2, 1); //Sector al que pertenece
        //int pszCreditoGlobal = Int32.Parse(ID_MEM_CRE_FTB.CtlText); //Crédito total asignado
        //
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //  pszCredAcum = Str(Format$(ID_MEM_CRED_ACUM_FTB.Text))
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //if (Conversion.Val(ID_MEM_CRED_ACUM_FTB.CtlText) == CORVB.NULL_INTEGER)
        //{
        //pszCredAcum = "0";
        //} else
        //{
        //pszCredAcum = ID_MEM_CRED_ACUM_FTB.CtlText;
        //}
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //string pszFecVenCred = ID_MEM_FEC_VEN_DTB.CtlText; //fecha de vencimiento de credito
        //System.DateTime TempDate = DateTime.FromOADate(0);
        //pszFecVenCred = "'" + Strings.Mid(pszFecVenCred, 1, 3) + CORPROC2.Obten_Mes_Ingles(StringsHelper.IntValue((DateTime.TryParse(pszFecVenCred, out TempDate)) ? TempDate.ToString("MM"): pszFecVenCred)) + Strings.Mid(pszFecVenCred, 6, 5) + "'";
        //Domicilio Fiscal
        //string pszCalleFis = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[0].Text) + "'"; //Domicilio Fiscal
        //string pszColoniaFis = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[0].Text) + "'"; //Colonia
        //string pszCiudadFis = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[0].Text) + "'"; //Ciudad
        //string pszPoblacionFis = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[0].Text) + "'"; //Poblacion/delegacion
        //string pszEstadoFis = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[0].SelectedIndex]) + "'"; //Estado
        //string pszCpFis = Conversion.Val(ID_MEM_CP_PIC[0].CtlText).ToString(); //Cp
        //
        //
        //telefonos
        //string pszTelefono = "'" + Conversion.Val(ID_MEM_CON_TXT.Text).ToString() + "'"; //telefono
        //string pszTelExt = "'" + Conversion.Val(ID_MEM_TEL_EXT_TXT.Text).ToString() + "'"; //extensión
        //string pszLada = "'" + Conversion.Val(ID_MEM_LADA_TXT.Text).ToString() + "'"; //lada
        //string pszFax = "'" + Conversion.Val(ID_MEM_FAX_TXT.Text).ToString() + "'"; //fax
        //string pszFaxLada = "'" + Conversion.Val(ID_MEM_FAX_LADA_TXT.Text).ToString() + "'"; //fax lada
        //''''  iVelTrns = Val(ID_MEM_VEL_TRNS_TXT.Text)                             'velocidad de transmisión
        //string pszEmail = "'" + CORPROC.Valida_Comilla(ID_MEM_EMAIL_TXT.Text) + "'"; //Email
        //string pszInternet = "'" + CORPROC.Valida_Comilla(ID_MEM_INTER_TXT.Text) + "'"; //Internet
        //
        //Comunicaciones
        //''''  If ID_MEM_VEL_TRNS_TXT.Text <> NULL_STRING Then
        //''''    bits de paridad
        //''''    If ID_MEM_PARE_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "E" + ","   'par
        //''''    End If
        //''''    If ID_MEM_PARN_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "N" + ","   'ninguno
        //''''    End If
        //''''    If ID_MEM_PARO_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "O" + ","   'impar
        //''''    End If
        //''''
        //''''    'bits de datos
        //''''    If ID_MEM_BDAT4_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "4" + ","
        //''''    ElseIf ID_MEM_BDAT5_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "5" + ","
        //''''    ElseIf ID_MEM_BDAT6_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "6" + ","
        //''''    ElseIf ID_MEM_BDAT7_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "7" + ","
        //''''    ElseIf ID_MEM_BDAT8_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "8" + ","
        //''''    End If
        //''''
        //''''    'bits de parada
        //''''    If ID_MEM_BPAR1_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "1"
        //''''    ElseIf ID_MEM_BPAR15_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "1.5"
        //''''    ElseIf ID_MEM_BPAR2_OPT.Value = True Then
        //''''      pszComunicacion = pszComunicacion + "2"
        //''''    End If
        //''''
        //''''    pszTonoPul = "'" + pszComunicacion + "'"
        //''''  Else
        //''''    pszTonoPul = "''"
        //''''  End If
        //
        //
        //Domicilio de envío
        //string pszCalleEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[1].Text) + "'"; //Domicilio de envio
        //string pszColoniaEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[1].Text) + "'"; //Colonia
        //string pszCiudadEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[1].Text) + "'"; //Ciudad
        //string pszPoblacionEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[1].Text) + "'"; //Poblacion/delegacion
        //string pszEstadoEnv = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex]) + "'"; //Estado
        //string pszCpEnv = Conversion.Val(ID_MEM_CP_PIC[1].CtlText).ToString(); //Cp
        //
        //string pszSucursal = Conversion.Str(ID_MEM_SUC_ITB.CtlText); //Sucursal
        //string pszCtaCaptacion = Conversion.Val(ID_MEM_NMC_FTB.CtlText).ToString(); //Cuenta de Captación
        //
        //if (ID_MEM_TPA_3OPB[0].Value)
        //{
        //pszTipoPago = "'" + CRSParametros.ctePagoAutomatico + "'"; //Tipo de pago automático
        //} else
        //{
        //if (ID_MEM_TPA_3OPB[1].Value)
        //{
        //pszTipoPago = "'" + CRSParametros.ctePagoIndividual + "'"; //Tipo de pago Individual
        //} else
        //{
        //pszTipoPago = "'" + CRSParametros.ctePagoLibre + "'"; //Tipo de pago Individual
        //}
        //}
        //
        //if (ID_MEM_EEC_3OPB[0].Value)
        //{
        //pszTipoEnv = "'" + CRSParametros.cteEmpresa + "'";
        //} else
        //{
        //pszTipoEnv = "'" + CRSParametros.cteIndividual + "'";
        //}
        //
        //Representantes
        //string pszNombreR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[0].Text) + "'"; //Nombre de representante1
        //string pszPuestoR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[0].Text) + "'"; //Puesto
        //string pszTelR1 = Conversion.Val(ID_MEM_TEL_MKE[0].CtlText).ToString(); //Telefono
        //string pszExtR1 = Conversion.Val(ID_MEM_EXT_PIC[0].CtlText).ToString(); //Extension
        //string pszFaxR1 = Conversion.Val(ID_MEM_FAX_MKE[0].CtlText).ToString(); //Fax
        //
        //string pszNombreR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[1].Text) + "'"; //Nombre de representante2
        //string pszPuestoR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[1].Text) + "'"; //Puesto
        //string pszTelR2 = Conversion.Val(ID_MEM_TEL_MKE[1].CtlText).ToString(); //Telefono
        //string pszExtR2 = Conversion.Val(ID_MEM_EXT_PIC[1].CtlText).ToString(); //Extension
        //string pszFaxR2 = Conversion.Val(ID_MEM_FAX_MKE[1].CtlText).ToString(); //Fax
        //
        //string pszNombreR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[2].Text) + "'"; //Nombre de representante3
        //string pszPuestoR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[2].Text) + "'"; //Puesto
        //string pszTelR3 = Conversion.Val(ID_MEM_TEL_MKE[2].CtlText).ToString(); //Telefono
        //string pszExtR3 = Conversion.Val(ID_MEM_EXT_PIC[2].CtlText).ToString(); //Extension
        //string pszFaxR3 = Conversion.Val(ID_MEM_FAX_MKE[2].CtlText).ToString(); //Fax
        //
        //pszFirma1 = "0x0";
        //pszFirma2 = "0x0";
        //pszFirma3 = "0x0";
        //
        // si el grupo esc cero no se valida el limite de crédito
        //if (Conversion.Val(pszNumGrupo) != 0)
        //{
        //
        //realiza la validación del credito asignado
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //   pszgblsql = "select gpo_cred_tot, gpo_acum_cred from MTCCOR01 where gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = "select gpo_cred_tot, gpo_acum_cred from MTCCOR01 where eje_prefijo =" + CORVAR.igblPref.ToString() + " and   gpo_banco = " + pszBanco + " and   gpo_num = " + pszNumGrupo;
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //
        //if (CORPROC2.Obtiene_Registros() != 0)
        //{
        //if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
        //{
        //lGpoCredTot = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
        //lGpoCredAcum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //if (Tag.ToString() == CORCONST.TAG_ALTA)
        //{
        //if ((lGpoCredAcum + pszCreditoGlobal) > lGpoCredTot)
        //{
        //this.Cursor = Cursors.Default;
        //lSumaGpoCredAcum = lGpoCredTot - lGpoCredAcum;
        //Fichero(0);
        //ID_MEM_CRE_FTB.Focus();
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("Se ha sobrepasado el crédito del Corporativo. Crédito disponible: " + StringsHelper.Format(lSumaGpoCredAcum, "###,###,###.00"), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
        //return;
        //} else
        //{
        //lSumaGpoCredAcum = lGpoCredAcum + pszCreditoGlobal;
        //}
        //} else
        //{
        //es un cambio
        //if (Conversion.Val(ID_MEM_CRE_FTB.CtlText.ToString()) < Conversion.Val(ID_MEM_CRED_ACUM_FTB.CtlText.ToString()))
        //{
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("El credito asignado es menor al credito acumulado", CORVB.MB_ICONEXCLAMATION, null);
        //Fichero(CORVB.NULL_INTEGER);
        //ID_MEM_CRE_FTB.Focus();
        //
        //verifica que si hay conexión al S111 se cierra la conexión
        //if (bConComDrive)
        //{
        //finaliza la sesión del usuario al S111
        //pszEnviaS111 = CORCONST.FINALIZA_S111;
        //envia la cadena al S111
        //pszRegresaS111 = ConComDrive.Envia_Mensaje(ref pszEnviaS111);
        //pszMensajeS111 = CORPROC.Muestra_Mensaje(pszRegresaS111);
        //if ((pszRegresaS111.IndexOf("HASTA LUEGO") + 1) != CORVB.NULL_INTEGER)
        //{
        //              MsgBox " " & pszMensajeS111, vbExclamation, Me.Caption
        //} else
        //{
        //MessageBox.Show(" " + pszMensajeS111, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //
        //termina con la conexión del s111
        //ConComDrive.Termina_Conexion();
        //}
        //this.Cursor = Cursors.Default;
        //return;
        //}
        //if ((lGpoCredAcum - lLeeCreditoGlobal + pszCreditoGlobal) > lGpoCredTot)
        //{
        //this.Cursor = Cursors.Default;
        //lSumaGpoCredAcum = lGpoCredTot - lGpoCredAcum;
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("Se ha sobrepasado el crédito del Corporativo. Crédito disponoble:" + Conversion.Str(lSumaGpoCredAcum), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
        //Fichero(CORVB.NULL_INTEGER);
        //ID_MEM_CRE_FTB.Focus();
        //
        //verifica que si hay conexión al S111 se cierra la conexión
        //if (bConComDrive)
        //{
        //finaliza la sesión del usuario al S111
        //pszEnviaS111 = CORCONST.FINALIZA_S111;
        //envia la cadena al S111
        //pszRegresaS111 = ConComDrive.Envia_Mensaje(ref pszEnviaS111);
        //pszMensajeS111 = CORPROC.Muestra_Mensaje(pszRegresaS111);
        //if ((pszRegresaS111.IndexOf("HASTA LUEGO") + 1) != CORVB.NULL_INTEGER)
        //{
        //              MsgBox " " & pszMensajeS111, vbExclamation, Me.Caption
        //} else
        //{
        //MessageBox.Show(" " + pszMensajeS111, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //termina con la conexión del s111
        //ConComDrive.Termina_Conexion();
        //}
        //return;
        //} else
        //{
        //if (lGpoCredAcum == CORVB.NULL_INTEGER)
        //{
        //lSumaGpoCredAcum = pszCreditoGlobal;
        //} else
        //{
        //lSumaGpoCredAcum = lGpoCredAcum - lLeeCreditoGlobal + pszCreditoGlobal;
        //}
        //}
        //}
        //} //Fin de obtiene registros
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //} //if de if grupo es diferente  de cero
        //
        //if (Tag.ToString() == CORCONST.TAG_ALTA)
        //{ //Se trata de una Alta
        //EISSA 26.11.2001 Código Nuevo para alta de empresa
        //CORVAR.pszgblsql = "exec alta_empresa " + pszNomEmpresa + "," + CORVAR.igblPref.ToString() + "," + pszBanco + "," + pszNumGrupo + "," + pszNominaEjeBNX;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszNomCorto + ", " + pszRFC + ", " + pszCartera + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + pszAccionista + ", " + pszSector + ", " + Conversion.Str(pszCreditoGlobal) + "," + Conversion.Str(0) + ", "; //las comillas son cred acumulado
        //CORVAR.pszgblsql = CORVAR.pszgblsql + pszFecVenCred + ", " + pszCalleFis + ", " + pszColoniaFis + ", " + pszCiudadFis + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + pszPoblacionFis + ", " + pszEstadoFis + ", " + pszCpFis + ", " + pszTelefono + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + pszTelExt + "," + pszLada + ", " + pszFax + ", " + pszFaxLada + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + pszTonoPul + "', " + "0" + ", " + pszEmail + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + pszInternet + ", " + pszCalleEnv + ", " + pszColoniaEnv + ", " + pszCiudadEnv + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + pszPoblacionEnv + ", " + pszEstadoEnv + ", " + pszCpEnv + ", " + pszCtaCaptacion + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + pszSucursal + ", " + pszTipoPago + ", " + pszTipoEnv;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilDiaCorte.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilPlazoGracia.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilPlazoNoCobro.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilTablaMCC.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilGeneraSBF.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slTipoFactura + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slEsquemaPago + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slTipoProducto + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + llEstructuraGastos.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilMesFiscal.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slUsuarioCambio + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilMontoPorciento.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + dlFacturacionMinima.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slCuentaContable + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilSkipPayment.ToString();
        //    prLog "Alta de la empresa: " & pszgblsql
        //EISSA 26.11.2001 Código Nuevo para alta de empresa
        //
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        //lNumEmpresa = Consecutivo_Empresa();
        //***** Código Anterior     ***********
        //      pszNumEmpresa = Format$(lNumEmpresa, "00000")
        //***** Fin Código Anterior ***********
        //EISSA 08.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
        //pszNumEmpresa = StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
        //EISSA 08.10.2001 FIN
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_EMP + " set ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r1 = " + pszNombreR1 + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_pues_r1 = " + pszPuestoR1 + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tel_r1 = '" + pszTelR1 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_ext_r1 = '" + pszExtR1 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax_r1 = '" + pszFaxR1 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fir_r1 = '" + pszFaxR1 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r2 = " + pszNombreR2 + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_pues_r2 = " + pszPuestoR2 + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tel_r2 = '" + pszTelR2 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_ext_r2 = '" + pszExtR2 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax_r2 = '" + pszFaxR2 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fir_r2 = '" + pszFaxR1 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r3 = " + pszNombreR3 + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_pues_r3 = " + pszPuestoR3 + ", ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tel_r3 = '" + pszTelR3 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_ext_r3 = '" + pszExtR3 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax_r3 = '" + pszFaxR3 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fir_r3 = '" + pszFaxR1 + "', ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_con_eje = 1 ";
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //pszgblsql = pszgblsql + "WHERE gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa;
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //Actualiza las firmas de representante 1,2,3
        //if (CORVAR.bgblModFirma != 0)
        //{
        //Inicia el proceso de guardar la imagen
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //GrabarImagen CORREGFI!ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //Inicia el proceso de guardar l2 imagen
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //GrabarImagen CORREGFI!ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", "  gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //Inicia el proceso de guardar la imagen
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //GrabarImagen CORREGFI!ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //}
        //Alta del primer tarjetahabiente con el Número de Ejecutivo 0
        //slCuentaEjecutivo0 = StringsHelper.Format(CORVAR.igblPref, "0000") + StringsHelper.Format(CORVAR.igblBanco, "00") + StringsHelper.Format(pszNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(0, Formato.sMascara(Formato.iTipo.Ejecutivo)) + "9";
        //ilDigitoVer = CORPROC.Calcula_digito_verif(ref slCuentaEjecutivo0);
        //slCuentaEjecutivo0 = StringsHelper.Format(CORVAR.igblPref, "0000") + StringsHelper.Format(CORVAR.igblBanco, "00") + StringsHelper.Format(pszNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + StringsHelper.Format(0, Formato.sMascara(Formato.iTipo.Ejecutivo)) + StringsHelper.Format(9, "0") + StringsHelper.Format(ilDigitoVer, "0");
        //
        //Prepara el diálogo para dar de alta el ejecutivo 0 (CERO) en el S111
        //
        //dlgAlta.iFechaAlta = Convert.ToInt32(Conversion.Val(DateTime.Today.ToString("yyyyMMdd")));
        //dlgAlta.sCuenta = slCuentaEjecutivo0;
        //dlgAlta.iDiaCorte = Int32.Parse(mskDiaCorte.defaultText);
        //dlgAlta.sNombreGrabacion = Seguridad.fncsSustituir(pszNomCorto, "'", "").Trim();
        //dlgAlta.sApellidoPaterno = Strings.Mid(Seguridad.fncsSustituir(Seguridad.fncsSustituir(Seguridad.fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""), 1, 30);
        //dlgAlta.sApellidoMaterno = Strings.Mid(Seguridad.fncsSustituir(Seguridad.fncsSustituir(Seguridad.fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""), 31, 30);
        //dlgAlta.sSexo = "F";
        //dlgAlta.iSucTransmisora = 137;
        //dlgAlta.iSucPromotora = 137;
        //if (slTipoFactura == CRSParametros.cteIndividual)
        //{
        //dlgAlta.lLimiteCredito = 0;
        //} else if (slTipoFactura == CRSParametros.cteCorporativo) { 
        //dlgAlta.lLimiteCredito = pszCreditoGlobal;
        //}
        //dlgAlta.sDomicilio = Seguridad.fncsSustituir(pszCalleEnv, "'", "").Trim();
        //dlgAlta.sColonia = Seguridad.fncsSustituir(pszColoniaEnv, "'", "").Trim();
        //dlgAlta.sPoblacion = Seguridad.fncsSustituir(pszPoblacionEnv, "'", "").Trim();
        //dlgAlta.sEstado = Seguridad.fncsSustituir(pszEstadoEnv, "'", "").Trim();
        //dlgAlta.iZonaPostal = 0;
        //dlgAlta.lCP = Int32.Parse(pszCpEnv);
        //dlgAlta.iASActi = 0;
        //dlgAlta.lTelOficina = StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelefono, "'", "").Trim());
        //dlgAlta.lTelParticular = StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelefono, "'", "").Trim());
        //dlgAlta.lExtension = Convert.ToInt32(StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelExt, "'", "").Trim()));
        //dlgAlta.sRFC = Seguridad.fncsSustituir(pszRFC, "'", "").Trim();
        //dlgAlta.iGeneraPinPlastico = (int) CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN;
        //dlgAlta.sTipoCta = CRSParametros.cteEmpresa;
        //dlgAlta.iSkipPayment = ilSkipPayment;
        //dlgAlta.iIdTablaMCC = ilTablaMCC;
        //dlgAlta.sCuentaReferencia = StringsHelper.Format(pszSucursal, new string('0', 4)) + StringsHelper.Format(pszCtaCaptacion, new string('0', 12));
        //dlgAlta.sTipoFacturacion = slTipoFactura;
        //CRSDialogo.Dialogo(ref pszMensajeS111, dlgAlta, CRSDialogo.TipoAlta.cteAltaS111);
        //
        //if (bfncAltaEnS111(ref pszMensajeS111, dlgAlta))
        //{
        //CORVAR.pszgblsql = "INSERT into MTCEJE01 VALUES (";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + CORVAR.igblPref.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + CORVAR.igblBanco.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + Int32.Parse(pszNumEmpresa).ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "0";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "9";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilDigitoVer.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszNomEmpresa;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszRFC;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "0";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '0'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '0000000'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", 0";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszNomEmpresa;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszCalleEnv;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszColoniaEnv;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszPoblacionEnv;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", 0"; //eje_zp
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszCpEnv;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszTelefono;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszTelefono;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszTelExt;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszFax;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", 1"; //Region
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + dlgAlta.lLimiteCredito.ToString(); //Limite de Crédito
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'N'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", ''";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'F'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '137'"; //& Trim(pszSucursal) & "'"
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '137'"; //& Trim(pszSucursal) & "'"
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'E'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '03'"; //Actividad / Subactividad
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszEstadoEnv;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszCalleEnv; //Domicilio Calle
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszColoniaEnv; //Colonia
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszCiudadEnv; //Ciudad
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszPoblacionEnv; //Población
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszEstadoEnv; //Estado
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszCpEnv; //CP
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + pszEmail; //Mail
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + StringsHelper.Format(slCuentaContable, new string('#', 40)) + "'"; //Cuenta Contable
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ((int) CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN).ToString(); //Generación de PIN Plástico
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + "0"; //Limite de disposición de Efectivo
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + CRSParametros.cteCorporativo + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + CRSParametros.cteEmpresa + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilSkipPayment.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", " + ilTablaMCC.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", 'P'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slNacionalidad + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + slIndCtaControl + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", '" + CRSParametros.sgUserID + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20), getdate(),112))";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,convert(char(20), getdate(),112))";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", convert(int,datepart(hh,getdate())) * 100 + convert(int, datepart(mi,getdate()))" + ")";
        //FSWB NR CAMBio...  ???
        //Eliminar en Producción
        //prLog "Alta del Ejecutivo: " & pszgblsql
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        //MessageBox.Show("Se ha generado la cuenta " + slCuentaEjecutivo0 + " para la empresa " + pszNumEmpresa, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //}
        //Fin de Alta de tarjetahabiente
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("La empresa " + ID_MEM_NLG_EB.Text.Trim() + " fué dada de Alta con el Número " + StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)), (MsgBoxStyle) (((int) CORVB.MB_ICONINFORMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //Limpia_Controles();
        //Fichero(CORVB.NULL_INTEGER);
        //this.Cursor = Cursors.WaitCursor;
        //modifica el credito acumulado del grupo
        //CORVAR.pszgblsql = "UPDATE MTCCOR01 set gpo_acum_cred = (select sum(emp_cred_tot) from MTCEMP01 ";
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //       pszgblsql = pszgblsql + " where gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo + ")"
        //       pszgblsql = pszgblsql + " where gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo + ")";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo;
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        //} else
        //{
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox((Double.Parse("No se actualizó el crédito acumulado del grupo: " + pszNumGrupo + " Con la cantidad de : ") + lSumaGpoCredAcum).ToString(), (MsgBoxStyle) (((int) CORVB.MB_ICONINFORMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //}
        //this.Cursor = Cursors.Default;
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //
        //Llama a la rutina que creará el directorio de la empresa
        //Crea_Directorio_Emp(pszNumEmpresa);
        //} else
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("La empresa " + ID_MEM_NLG_EB.Text.Trim() + " no pudo ser dada de Alta " + Strings.Chr(CORVB.KEY_RETURN).ToString() + "Error al actualizar consecutivo", (MsgBoxStyle) (((int) CORVB.MB_ICONSTOP) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //}
        //} else
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("La empresa " + ID_MEM_NLG_EB.Text.Trim() + " no fué dada de alta", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //}
        //CORREGFI.DefInstance.Close(); //descarga la forma que contiene las firmas
        //} else
        //{
        //*************************  Se trata de un Cambio   *********************
        //VB6.SetItemString(CORCTEMP.DefInstance.ID_CEM_EMP_LB, ListBoxHelper.GetSelectedIndex(CORCTEMP.DefInstance.ID_CEM_EMP_LB), Strings.Mid(VB6.GetItemString(CORCTEMP.DefInstance.ID_CEM_EMP_LB, ListBoxHelper.GetSelectedIndex(CORCTEMP.DefInstance.ID_CEM_EMP_LB)), 1, 8) + ID_MEM_NLG_EB.Text.Trim());
        //pszNumEmpresa = CORVAR.lgblNumEmpresa.ToString(); //La cuenta de la empresa
        //bActualizarCM = 0;
        //    If (pszTipoEnv = "'" + STR_EMP + "'" And Cambio_DomicilioEnv()) Or (pszEnvioIni = STR_IND And pszTipoEnv = "'" + STR_EMP + "'") Then
        //if (Cambio_DomicilioEnv())
        //{
        //   iResp = MsgBox("Se ha cambiado la dirección de envíos. Deseas realizar cambios masivos ?", MB_ICONQUESTION + MB_YESNO, STR_APP_TIT)
        //   If iResp = IDYES Then
        //bActualizarCM = -1;
        //   End If
        //   Screen.MousePointer = HOURGLASS
        //}
        //
        //si se realiza cambio de la empresa
        //if (bActualizarCM == (-1))
        //{
        //
        //realiza los cambios masivos al S111 y en el micro
        //insrta en la tabla de cambios masivos
        //
        //if (! InsertaTablaCambios(ref pszNumEmpresa, ref pszBanco))
        //{
        //
        //this.Cursor = Cursors.Default;
        //MessageBox.Show("No se pudo insertar datos en la tabla de cambios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //return;
        //} else
        //{
        //
        //se actualizan los datos de la empresa domicilio de envio en el M111
        //this.Cursor = Cursors.WaitCursor;
        //CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EMP + " set ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_calle =" + pszCalleEnv + ",emp_envio_col=" + pszColoniaEnv + ",emp_envio_ciu=" + pszCiudadEnv + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_envio_pob =" + pszPoblacionEnv + ",emp_envio_edo=" + pszEstadoEnv + ",emp_envio_cp=" + pszCpEnv;
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //       pszgblsql = pszgblsql + " where gpo_banco=" + pszBanco + " and emp_num =" + pszNumEmpresa
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + pszBanco + " and emp_num =" + pszNumEmpresa;
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //this.Cursor = Cursors.Default;
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("Se actualizaron los datos de domicilio de envío de la empresa " + ID_MEM_NLG_EB.Text.Trim() + " en el M111", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //} else
        //{
        //MessageBox.Show("No se actualizaron los datos de domicilio de envío de la empresa " + ID_MEM_NLG_EB.Text.Trim() + " en el M111", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //this.Cursor = Cursors.WaitCursor;
        //}
        //si inserto registros en la tabla de cambios masivos
        //if (bHayReg)
        //{
        //realiza el proceso de cambios masivo
        //If RealizaCambiosMasivosEmp(pLngNumEmp) = True Then
        //MessageBox.Show("se debe llamar la funcion RealizaCambiosMasivosEmp", Application.ProductName);
        //sale de la función debido a algún error error
        //return;
        // End If
        //}
        //}
        //
        //
        //si cambio algún dato de la empresa si realiza la actualización
        //if ((Conversion.Val(pszNominaEjeBNX) != Conversion.Val(mlNominaEjeBNX.ToString())) || (pszNomEmpresa.Trim() != ("'" + msNomEmpresa.Trim() + "'")) || (pszNomCorto.Trim() != ("'" + msNomCorto.Trim() + "'")) || (pszRFC.Trim() != ("'" + msRFC.Trim() + "'")) || (Conversion.Val(pszCartera) != Conversion.Val(mdCartera.ToString())) || (pszAccionista.Trim() != ("'" + msAccionista.Trim() + "'")) || (Conversion.Val(pszSector) != Conversion.Val((miSector + 1).ToString())) || (Conversion.Val(pszCreditoGlobal.ToString()) != Conversion.Val(mlCreditoGlobal.ToString())) || (Conversion.Val(pszCredAcum) != Conversion.Val(mlCredAcum.ToString())) || (pszCalleFis.Trim() != ("'" + msCalleFis.Trim() + "'")) || (pszColoniaFis.Trim() != ("'" + msColoniaFis.Trim() + "'")) || (pszCiudadFis.Trim() != ("'" + msCiudadFis.Trim() + "'")) || (pszPoblacionFis.Trim() != ("'" + msPoblacionFis.Trim() + "'")) || (pszEstadoFis.Trim() != ("'" + msEstadoFis.Trim() + "'")) || (Conversion.Val(pszCpFis) != Conversion.Val(mlCpFis.ToString())) || (pszTonoPul != ("'" + msTonoPul.Trim() + "'")) || (Conversion.Val(iVelTrns) != Conversion.Val(miVelTrns.ToString())) || (Conversion.Val(ID_MEM_CON_TXT.Text) != Conversion.Val(msTelefono)) || (Conversion.Val(ID_MEM_LADA_TXT.Text) != Conversion.Val(msLada)) || (Conversion.Val(ID_MEM_FAX_TXT.Text) != Conversion.Val(msFax)) || (pszEmail.Trim() != ("'" + msEmail.Trim() + "'")) || (pszInternet.Trim() != ("'" + msInternet.Trim() + "'")) || (Conversion.Val(pszCtaCaptacion) != Conversion.Val(mdCtaCaptacion.ToString())) || (Conversion.Val(pszSucursal) != Conversion.Val(miSucursal.ToString())) || (pszNombreR1.Trim() != ("'" + msNombreR1.Trim() + "'")) || (pszPuestoR1.Trim() != ("'" + msPuestoR1.Trim() + "'")) || (Conversion.Val(pszTelR1) != Conversion.Val(msTelR1)) || (Conversion.Val(pszExtR1) != Conversion.Val(msExtR1)) || (Conversion.Val(pszFaxR1) != Conversion.Val(pszFaxR1)) || (pszNombreR2.Trim() != ("'" + msNombreR2.Trim() + "'")) || (pszPuestoR2.Trim() != ("'" + msPuestoR2.Trim() + "'")) || (Conversion.Val(pszTelR2) != Conversion.Val(msTelR2)) || (Conversion.Val(pszExtR2) != Conversion.Val(msExtR2)) || (Conversion.Val(pszFaxR2) != Conversion.Val(pszFaxR2)) || (pszNombreR3.Trim() != ("'" + msNombreR3.Trim() + "'")) || (pszPuestoR3.Trim() != ("'" + msPuestoR3.Trim() + "'")) || (Conversion.Val(pszTelR3) != Conversion.Val(msTelR3)) || (Conversion.Val(pszExtR3) != Conversion.Val(msExtR3)) || (Conversion.Val(pszFaxR3) != Conversion.Val(pszFaxR3)))
        //{
        //
        //se enciende la bandera de cambios generales
        //bFlagCambios = true;
        //
        //}
        //
        //
        //
        //Actualiza los datos de la empresa en el micro excepto los datos de dirección de envío
        //EISSA 27.11.2001 Código Nuevo para actualizar los datos de emrpesa
        //CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EMP + " set ejx_numero=" + pszNominaEjeBNX + ",emp_nom=" + pszNomEmpresa + ",emp_nom_graba=" + pszNomCorto + ",emp_rfc=" + pszRFC + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_num_cartera=" + pszCartera + ",emp_princ_acc=" + pszAccionista + ",emp_sector=" + pszSector + ",emp_cred_tot=" + Conversion.Str(pszCreditoGlobal) + ",emp_acum_cred=" + pszCredAcum + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_calle=" + pszCalleFis + ",emp_fiscal_col=" + pszColoniaFis + ",emp_fiscal_ciu=" + pszCiudadFis + ",emp_fiscal_pob=" + pszPoblacionFis + ",emp_fiscal_edo=" + pszEstadoFis + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fiscal_cp=" + pszCpFis + ",emp_fec_venc_cred=" + pszFecVenCred + ", emp_telefono=" + pszTelefono + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_tel_lada = " + pszLada + ", emp_fax = " + pszFax + ", emp_param_modem = '" + pszTonoPul + "',";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_vel_transmis = " + Conversion.Val(iVelTrns).ToString() + ", emp_email = " + pszEmail + ", emp_internet = " + pszInternet;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_cta_capt=" + pszCtaCaptacion + ",emp_sucur=" + pszSucursal + ",emp_tipo_pago=" + pszTipoPago + ",emp_tipo_envio=" + pszTipoEnv + ",";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r1=" + pszNombreR1 + ",emp_pues_r1=" + pszPuestoR1 + ",emp_tel_r1='" + pszTelR1 + "',emp_ext_r1='" + pszExtR1 + "',emp_fax_r1='" + pszFaxR1 + "',";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r2=" + pszNombreR2 + ",emp_pues_r2=" + pszPuestoR2 + ",emp_tel_r2='" + pszTelR2 + "',emp_ext_r2='" + pszExtR2 + "',emp_fax_r2='" + pszFaxR2 + "',";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_nom_r3=" + pszNombreR3 + ",emp_pues_r3=" + pszPuestoR3 + ",emp_tel_r3='" + pszTelR3 + "',emp_ext_r3='" + pszExtR3 + "',emp_fax_r3='" + pszFaxR3 + "',";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_fax_lada=" + pszFaxLada + ",emp_extension=" + pszTelExt;
        //
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_dia_corte = " + ilDiaCorte.ToString(); //Realizar validaciones
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_plazo_gracia = " + ilPlazoGracia.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_plazo_no_cob = " + ilPlazoNoCobro.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tabla_mcc = " + ilTablaMCC.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_gen_SBF = " + ilGeneraSBF.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tipo_fac = '" + slTipoFactura + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_esquema_pago = '" + slEsquemaPago + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_tipo_producto = '" + slTipoProducto + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_estruct_gastos = " + llEstructuraGastos.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_mes_fiscal  = " + ilMesFiscal.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_usu_cam = '" + slUsuarioCambio + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_fech_cam = convert(int,convert(char(20), getdate(),112))";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_hora_cam = (convert(int,datepart(hh,getdate())) * 100) + (convert(int, datepart(mi,getdate())))";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_lim_dis_efec = " + ilMontoPorciento.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_min_factura = " + dlFacturacionMinima.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_cta_contable = '" + slCuentaContable + "'";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + ", emp_skip_payment = " + ilSkipPayment.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " where ";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + CORVAR.igblPref.ToString();
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco= " + pszBanco;
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;
        //
        //
        //EISSA 27.11.2001 Código Nuevo para actualizar los datos de empresa
        //
        //this.Cursor = Cursors.Default;
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //Actualiza el ejecutivo correspondiente a la empresa
        //bfncActualizaEjecutivos(CORVAR.igblPref, CORVAR.igblBanco, Convert.ToInt32(Conversion.Val(pszNumEmpresa)));
        //Firma 1
        //Inicia el proceso de guardar la imagen            eje_prefijo = " + Format$(igblPref) + " and
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //GrabarImagen CORREGFI!ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //Inicia el proceso de guardar l2 imagen
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //GrabarImagen CORREGFI!ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //Inicia el proceso de guardar la imagen
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //GrabarImagen CORREGFI!ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " gpo_banco = " + Format$(igblBanco) + " AND emp_num = " + pszNumEmpresa
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //if (iErr == CORCONST.OK)
        //{
        //If bFlagCambios = True Then
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("La empresa " + ID_MEM_NLG_EB.Text.Trim() + " fué actualizada", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //End If
        //this.Cursor = Cursors.WaitCursor;
        //modifica el credito acumulado del grupo
        //CORVAR.pszgblsql = "UPDATE MTCCOR01 set gpo_acum_cred = (select sum(emp_cred_tot) from MTCEMP01 ";
        //***** INICIO CODIGO ANTERIOR FSWBMX *****
        //       pszgblsql = pszgblsql + " where gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo + ")"
        //       pszgblsql = pszgblsql + " where gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo
        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
        //***** INICIO CODIGO NUEVO FSWBMX *****
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo + ")";
        //CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo;
        //***** FIN DE CODIGO NUEVO FSWBMX *****
        //
        //if (CORPROC2.Modifica_Registro() != 0)
        //{
        //} else
        //{
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox((Double.Parse("No se actualizó el crédito acumulado del grupo: " + pszNumGrupo + " Con la cantidad: ") + lSumaGpoCredAcum).ToString(), (MsgBoxStyle) (((int) CORVB.MB_ICONINFORMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //this.Cursor = Cursors.Default;
        //} else
        //{
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("La empresa " + ID_MEM_NLG_EB.Text.Trim() + " no pudo ser actualizada", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //}
        //
        //} else
        //{
        //this.Cursor = Cursors.Default;
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("La empresa " + ID_MEM_NLG_EB.Text.Trim() + " no pudo ser actualizada", (MsgBoxStyle) (((int) CORVB.MB_ICONEXCLAMATION) + ((int) CORVB.MB_OK)), CORSTR.STR_APP_TIT);
        //}
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //CORREGFI.DefInstance.Close(); //descarga la forma que contiene las firmas
        //this.Close();
        //}
        //this.Cursor = Cursors.Default;
        //}
        //catch (Exception exc)
        //{
        //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
        //}
        //}

        private void ID_MEM_TEL_MKE_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            //AIS-1094 NGONZALEZ
            //AIS-1096 NGONZALEZ
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
        }

        //UPGRADE_NOTE: (7001) The following declaration (ID_MEM_VEL_TRNS_TXT_GotFocus) seems to be dead code
        //private void  ID_MEM_VEL_TRNS_TXT_GotFocus()
        //{
        ////
        //  ID_MEM_VEL_TRNS_TXT.SelStart = 0
        //  ID_MEM_VEL_TRNS_TXT.SelLength = Len(ID_MEM_VEL_TRNS_TXT.Text)
        //
        //}

        //UPGRADE_NOTE: (7001) The following declaration (ID_MEM_VEL_TRNS_TXT_KeyPress) seems to be dead code
        //private void  ID_MEM_VEL_TRNS_TXT_KeyPress( int KeyAscii)
        //{
        ////
        // If (KeyAscii < 48 Or KeyAscii > 57) And KeyAscii <> 8 Then
        //    KeyAscii = NULL_INTEGER
        // End If
        //}

        //UPGRADE_NOTE: (7001) The following declaration (ID_MWM_FAX_MKE_KeyPress) seems to be dead code
        //private void  ID_MWM_FAX_MKE_KeyPress( int Index,  int KeyAscii)
        //{
        ////
        //  If (KeyAscii < 48 Or KeyAscii > 57) And KeyAscii <> KEY_BACK Then
        //    KeyAscii = 0
        //  End If
        //
        //}

        //UPGRADE_NOTE: (7001) The following declaration (ID_MNE_EMP_SST_DblClick) seems to be dead code
        //private void  ID_MNE_EMP_SST_DblClick()
        //{
        //    Fichero ID_MNE_EMP_SST.Tab
        //}

        private void ID_MEM_TFA_3OPB_ClickEvent(Object eventSender)
        {
            int Index = Array.IndexOf(ID_MEM_TFA_3OPB, eventSender);
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


        private void ID_MEM_TPA_3OPB_ClickEvent(Object eventSender)
        {
            int Index = Array.IndexOf(ID_MEM_TPA_3OPB, eventSender);
            switch (Index)
            {
                case 0:
                    msTipoPago = STR_AUTO;
                    break;
                case 1:
                    msTipoPago = STR_IND;
                    break;
                case 2:
                    msTipoPago = STR_LIB;
                    break;
            }
        }

        private void mskDiaCorte_Enter(Object eventSender, EventArgs eventArgs)
        {
            mskDiaCorte.SelStart = 0;
            mskDiaCorte.SelLength = Strings.Len(mskDiaCorte.defaultText);
        }

        private void mskDiaCorte_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
        }

        private void mskDiaCorte_Leave(Object eventSender, EventArgs eventArgs)
        {
            if (Conversion.Val(mskDiaCorte.CtlText) > 28 || Conversion.Val(mskDiaCorte.CtlText) < 1)
            {
                bool tempRefParam = false;
                mskDiaCorte_Validating(mskDiaCorte, new CancelEventArgs(tempRefParam));
            }
        }

        private void mskDiaCorte_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int ilAnterior = ilDiaCorte;
            if (Conversion.Val(mskDiaCorte.CtlText) > 28 || Conversion.Val(mskDiaCorte.CtlText) < 1)
            {
                mskDiaCorte.Mask = "";
                mskDiaCorte.CtlText = CRSParametros.cteDiaCorte.ToString();
                mskDiaCorte.SelStart = 0;
                mskDiaCorte.SelLength = Strings.Len(mskDiaCorte.defaultText);
                MessageBox.Show("Día de Corte no válido, este valor debe estar entre 1 y 28.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancel = true;
            }
            else
            {
                ilDiaCorte = Convert.ToInt32(Conversion.Val(mskDiaCorte.CtlText));
            }
            eventArgs.Cancel = Cancel;
        }

        private void mskMCC_Change(Object eventSender, EventArgs eventArgs)
        {
            ilTablaMCC = Convert.ToInt32(Conversion.Val(mskMCC.defaultText));
        }

        private void mskMCC_Enter(Object eventSender, EventArgs eventArgs)
        {
            mskMCC.SelStart = 0;
            mskMCC.SelLength = Strings.Len(mskMCC.defaultText);
        }

        private void mskMontoMinimo_Enter(Object eventSender, EventArgs eventArgs)
        {
            mskMontoMinimo.SelStart = 0;
            mskMontoMinimo.SelLength = Strings.Len(mskMontoMinimo.defaultText);
        }

        private void mskMontoMinimo_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValPuntoFlotante, true, true);
        }

        private void mskMontoMinimo_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (Conversion.Val(mskMontoMinimo.defaultText) < 0)
            {
                MessageBox.Show("El valor no puede ser menor a 0.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskMontoMinimo.defaultText = "0";
                Cancel = true;
            }
            else
            {
                dlFacturacionMinima = Conversion.Val(mskMontoMinimo.defaultText);
            }
            eventArgs.Cancel = Cancel;
        }

        private void mskPeriodoGracia_Change(Object eventSender, EventArgs eventArgs)
        {
            mskPerNoInteres.defaultText = Conversion.Val(mskPeriodoGracia.defaultText).ToString();
        }

        private void mskPeriodoGracia_Enter(Object eventSender, EventArgs eventArgs)
        {
            mskPeriodoGracia.SelStart = 0;
            mskPeriodoGracia.SelLength = Strings.Len(mskPeriodoGracia.defaultText);
        }

        private void mskPeriodoGracia_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
        }

        private void mskPeriodoGracia_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int ilAnterior = ilPlazoGracia;
            if (Conversion.Val(mskPeriodoGracia.defaultText) > 99 || Conversion.Val(mskPeriodoGracia.defaultText) < 1)
            {
                MessageBox.Show("Período de gracia no válido, este valor debe estar entre 1 y 99.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskPeriodoGracia.Mask = "";
                mskPeriodoGracia.CtlText = CRSParametros.ctePlazoGracia.ToString();
                mskPeriodoGracia.SelStart = 0;
                mskPeriodoGracia.SelLength = Strings.Len(mskPeriodoGracia.defaultText);
                Cancel = true;
            }
            else
            {
                ilPlazoGracia = Convert.ToInt32(Conversion.Val(mskPeriodoGracia.defaultText));
            }
            eventArgs.Cancel = Cancel;
        }

        private void mskPerNoInteres_Enter(Object eventSender, EventArgs eventArgs)
        {
            mskPerNoInteres.SelStart = 0;
            mskPerNoInteres.SelLength = Strings.Len(mskPerNoInteres.defaultText);
        }

        private void mskPerNoInteres_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            if (eventArgs.keyAscii == ((int)"\t"[0]))
            {
                Fichero(1);
            }
            else
            {
                //AIS-1096 NGONZALEZ
                CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false);
            }
        }

        private void mskPerNoInteres_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int ilAnterior = ilPlazoNoCobro;
            try
            {
                if (Conversion.Val(mskPerNoInteres.defaultText) > 99 || Conversion.Val(mskPerNoInteres.defaultText) < Double.Parse(mskPeriodoGracia.defaultText))
                {
                    mskPerNoInteres.CtlText = ilAnterior.ToString();
                    MessageBox.Show("Plazo de no cobro de Interéses inválido, este valor debe estar entre " + mskPeriodoGracia.defaultText + " y 99.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mskPerNoInteres.SelStart = 0;
                    mskPerNoInteres.SelLength = Strings.Len(mskPerNoInteres.defaultText);
                    Cancel = true;
                }
                else
                {
                    mskPerNoInteres.Mask = "";
                    mskPerNoInteres.defaultText = Conversion.Val(mskPerNoInteres.defaultText).ToString();
                    ilPlazoNoCobro = Convert.ToInt32(Conversion.Val(mskPerNoInteres.defaultText));
                    mskPerNoInteres.SelStart = 0;
                    mskPerNoInteres.SelLength = Strings.Len(mskPerNoInteres.defaultText);
                }
            }
            catch  { }
            eventArgs.Cancel = Cancel;
        }

        private void mskPorcientoMinimo_Change(Object eventSender, EventArgs eventArgs)
        {
            ilMontoPorciento = Convert.ToInt32(Conversion.Val(mskPorcientoMinimo1.defaultText));
        }

        private void mskPorcientoMinimo_Enter(Object eventSender, EventArgs eventArgs)
        {
            mskPorcientoMinimo1.SelStart = 0;
            mskPorcientoMinimo1.SelLength = Strings.Len(mskPorcientoMinimo1.defaultText);
        }


        private void mskPorcientoMinimo_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            if (eventArgs.keyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, false, false);
        }

        private void mskPorcientoMinimo_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            int ilValorAnterior = Convert.ToInt32(Conversion.Val(mskPorcientoMinimo1.defaultText));
            if (ilValorAnterior < 0)
            {
                ilMontoPorciento = ilValorAnterior;
                MessageBox.Show("El porcentaje mínimo de pago no puede ser menor al 0%.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskPorcientoMinimo1.defaultText = "0";
                mskPorcientoMinimo1.SelStart = 0;
                mskPorcientoMinimo1.SelLength = Strings.Len(mskPorcientoMinimo1.CtlText);
                Cancel = true;
            }
            else if (ilValorAnterior > 100)
            {
                ilMontoPorciento = ilValorAnterior;
                MessageBox.Show("El porcentaje mínimo de pago no debe exceder del 100%.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskPorcientoMinimo1.defaultText = "100";
                mskPorcientoMinimo1.SelStart = 0;
                mskPorcientoMinimo1.SelLength = Strings.Len(mskPorcientoMinimo1.CtlText);
                Cancel = true;
            }
            else if (ilValorAnterior == 100)
            {
                ilMontoPorciento = Convert.ToInt32(Conversion.Val(mskPorcientoMinimo1.defaultText));
                slEsquemaPago = CRSParametros.cteTotal;
            }
            else
            {
                ilMontoPorciento = Convert.ToInt32(Conversion.Val(mskPorcientoMinimo1.defaultText));
                slEsquemaPago = CRSParametros.cteMinimo;
            }
            eventArgs.Cancel = Cancel;
        }
        /* comenta Yuria 16/07/09
         * Debido a que hay problemas con la consulta y cambio
         * del Campo "Tabla de bloqueo o mskMCC*
        private void optEmpresa_ClickEvent(Object eventSender)
        {
            int Index = Array.IndexOf(optEmpresa, eventSender);
            switch (Index)
            {
                case 0:
                    mdlParametros.igEmpTipoBloqueo = 0;
                    mskMCC.CtlText = "0";
                    mskMCC.Enabled = false;
                    break;
                case 1:
                    mdlParametros.igEmpTipoBloqueo = 1;
                    mskMCC.Enabled = true;
                    break;
                case 2:
                    mdlParametros.igEmpTipoBloqueo = 2;
                    mskMCC.Enabled = true;
                    break;
            }
        }
        */
        private void optTipoProducto_ClickEvent(Object eventSender)
        {
            int Index = Array.IndexOf(optTipoProducto, eventSender);
            switch (Index)
            {
                case 0:
                    slTipoProducto = CRSParametros.cteBusinessCard;
                    break;
                case 1:
                    slTipoProducto = CRSParametros.ctePurchasingCard;
                    break;
                case 2:
                    slTipoProducto = CRSParametros.cteDistributionLine;
                    break;
            }
        }

        private CRSParametros.ValoresSBF ifncSBF()
        {
            CRSParametros.ValoresSBF result = new CRSParametros.ValoresSBF();
            if (chkCheckBox[0].CheckState == CheckState.Unchecked && chkCheckBox[1].CheckState == CheckState.Unchecked)
            {
                return CRSParametros.ValoresSBF.cteNoGenerarSBFNoDerivado;
            }
            if (chkCheckBox[0].CheckState == CheckState.Unchecked && chkCheckBox[1].CheckState == CheckState.Checked)
            {
                return CRSParametros.ValoresSBF.cteNoGenerarSBFSiDerivado;
            }
            if (chkCheckBox[0].CheckState == CheckState.Checked && chkCheckBox[1].CheckState == CheckState.Unchecked)
            {
                if (chkCheckBox[2].CheckState == CheckState.Unchecked)
                {
                    return CRSParametros.ValoresSBF.cteSiGenerarSBFNoDerivado;
                }
                else
                {
                    return CRSParametros.ValoresSBF.cteSiGenerarSBFCycleDailyNoDerivado;
                }
            }
            if (chkCheckBox[0].CheckState == CheckState.Checked && chkCheckBox[1].CheckState == CheckState.Checked)
            {
                if (chkCheckBox[2].CheckState == CheckState.Unchecked)
                {
                    return CRSParametros.ValoresSBF.cteSiGenerarSBFSiDerivado;
                }
                else
                {
                    return CRSParametros.ValoresSBF.cteSiGenerarSBFCycleDailySiDerivado;
                }
            }
            //AIS- NGONZALEZ
            return result;
        }

        private void prConfiguraSBF(int ipSBF)
        {
            if (ipSBF == ((int)CRSParametros.ValoresSBF.cteNoGenerarSBFNoDerivado))
            {
                chkCheckBox[0].CheckState = CheckState.Unchecked;
                chkCheckBox[1].CheckState = CheckState.Unchecked;
                chkCheckBox[2].CheckState = CheckState.Unchecked;
            }
            else if (ipSBF == ((int)CRSParametros.ValoresSBF.cteNoGenerarSBFSiDerivado))
            {
                chkCheckBox[0].CheckState = CheckState.Unchecked;
                chkCheckBox[1].CheckState = CheckState.Checked;
                chkCheckBox[2].CheckState = CheckState.Unchecked;
            }
            else if (ipSBF == ((int)CRSParametros.ValoresSBF.cteSiGenerarSBFNoDerivado))
            {
                chkCheckBox[0].CheckState = CheckState.Checked;
                chkCheckBox[1].CheckState = CheckState.Unchecked;
                chkCheckBox[2].CheckState = CheckState.Unchecked;
            }
            else if (ipSBF == ((int)CRSParametros.ValoresSBF.cteSiGenerarSBFSiDerivado))
            {
                chkCheckBox[0].CheckState = CheckState.Checked;
                chkCheckBox[1].CheckState = CheckState.Checked;
                chkCheckBox[2].CheckState = CheckState.Unchecked;
            }
            else if (ipSBF == ((int)CRSParametros.ValoresSBF.cteSiGenerarSBFCycleDailyNoDerivado))
            {
                chkCheckBox[0].CheckState = CheckState.Checked;
                chkCheckBox[1].CheckState = CheckState.Unchecked;
                chkCheckBox[2].CheckState = CheckState.Checked;
            }
            else if (ipSBF == ((int)CRSParametros.ValoresSBF.cteSiGenerarSBFCycleDailySiDerivado))
            {
                chkCheckBox[0].CheckState = CheckState.Checked;
                chkCheckBox[1].CheckState = CheckState.Checked;
                chkCheckBox[2].CheckState = CheckState.Checked;
            }
        }




        public string sfncQueries(int ipOpcion)
        {
            string slSQL = String.Empty;
            switch (ipOpcion)
            {
                case 0:  //Estructuras de Gastos 
                    slSQL = "Select ";
                    slSQL = slSQL + " exp_struc_id as ID,";
                    slSQL = slSQL + " exp_strucy_name As Estructura";
                    slSQL = slSQL + " From MTCEST01";
                    slSQL = slSQL + " Where exp_eje_prefijo = " + CORVAR.igblPref.ToString();
                    slSQL = slSQL + " and exp_gpo_banco = " + CORVAR.igblBanco.ToString();
                    break;
            }
            return slSQL;
        }

       /* private bool bfncAltaEnS111(ref  string sDialogo, CRSDialogo.DatosDialogo dlgpDialogo, ref  string sEnviaRut)
        {
            CRSDialogo.DatosEjecutivo ejelEjecutivo = CRSDialogo.DatosEjecutivo.CreateInstance();
            int ilAltaS016 = 0;
            string ilAltaS111 = String.Empty;
            try
            {
                //Conectarse al 111
                ejelEjecutivo.sNombre = dlgpDialogo.sNombreGrabacion;
                ejelEjecutivo.sCalle = dlgpDialogo.sDomicilio;
                ejelEjecutivo.sColonia = dlgpDialogo.sColonia;
                ejelEjecutivo.sCiudad = dlgpDialogo.sPoblacion;
                ejelEjecutivo.sTipoCuenta = dlgpDialogo.sTipoCta;
                ejelEjecutivo.sSucursal = dlgpDialogo.iSucTransmisora.ToString();
                ejelEjecutivo.sCorte = dlgpDialogo.iDiaCorte.ToString();
                ejelEjecutivo.sSexo = dlgpDialogo.sSexo;
                ejelEjecutivo.sTelDomicilio = Conversion.Val(dlgpDialogo.lTelParticular.ToString().Trim()).ToString();
                ejelEjecutivo.sTelOficina = Conversion.Val(dlgpDialogo.lTelOficina.ToString().Trim()).ToString();
                ejelEjecutivo.sExt = Conversion.Val(dlgpDialogo.lExtension.ToString()).ToString();
                ejelEjecutivo.sFecAlta = Strings.Mid(dlgpDialogo.iFechaAlta.ToString(), 3, 6).Trim();
                OLERut.Conexion tempRefParam = ConexionRut;
                int tempRefParam2 = 333999;
                CRSDialogo.bfncEnviaDialogo(ref tempRefParam, ref tempRefParam2, ref sDialogo, ref sEnviaRut, ref dlgpDialogo.sCuenta, ref ejelEjecutivo);
                ConexionRut = tempRefParam;
                return ilAltaS016 == Double.Parse("OK") || ilAltaS016 == Double.Parse("OKS111");
            }
            catch
            {


                CRSGeneral.prObtenError("AltaEnS111");
            }
            return false;
        }
        */

        /*private bool bfncAltaEnS111(ref  string sDialogo, CRSDialogo.DatosDialogo dlgpDialogo)
        {
            string tempRefParam = "";
            return bfncAltaEnS111(ref sDialogo, dlgpDialogo, ref tempRefParam);
        }
        */

        /*
        private int ifncAltaEnS111(ref  string sDialogoS111, string sDialogoS016, CRSDialogo.DatosDialogo dlgpDialogo, ref  string sEnviaRut)
        {
            int result = 0;
            CRSDialogo.DatosEjecutivo ejelEjecutivo = CRSDialogo.DatosEjecutivo.CreateInstance();
            int ilAltaS016 = 0;
            string ilAltaS111 = String.Empty;

            string slDialogo = String.Empty;

            try
            {

                ejelEjecutivo.sNombre = dlgpDialogo.sNombreGrabacion;
                ejelEjecutivo.sCalle = dlgpDialogo.sDomicilio;
                ejelEjecutivo.sColonia = dlgpDialogo.sColonia;
                ejelEjecutivo.sCiudad = dlgpDialogo.sPoblacion;
                ejelEjecutivo.sTipoCuenta = dlgpDialogo.sTipoCta;
                ejelEjecutivo.sSucursal = dlgpDialogo.iSucTransmisora.ToString();
                ejelEjecutivo.sCorte = dlgpDialogo.iDiaCorte.ToString();
                ejelEjecutivo.sSexo = dlgpDialogo.sSexo;
                ejelEjecutivo.sTelDomicilio = Conversion.Val(dlgpDialogo.lTelParticular.ToString().Trim()).ToString();
                ejelEjecutivo.sTelOficina = Conversion.Val(dlgpDialogo.lTelOficina.ToString().Trim()).ToString();
                ejelEjecutivo.sExt = Conversion.Val(dlgpDialogo.lExtension.ToString()).ToString();
                ejelEjecutivo.sFecAlta = Strings.Mid(dlgpDialogo.iFechaAlta.ToString(), 3, 6).Trim();

                if (ConexionRut == null)
                {
                    ConexionRut = new OLERut.Conexion();
                    ConexionRut.Inicia_Conexion();
                }
                mdlParametros.igContador = 0;
                OLERut.Conexion tempRefParam = ConexionRut;
                int tempRefParam2 = 333999;
                ilAltaS111 = CRSGeneral.vfncVPO(CRSDialogo.ifncEnviaDialogo(ref tempRefParam, ref tempRefParam2, ref sDialogoS111, ref sEnviaRut, ref dlgpDialogo.sCuenta, ref ejelEjecutivo, CRSDialogo.TipoAlta.cteAltaS111).ToString(), "0");
                ConexionRut = tempRefParam;

                if (Double.Parse(ilAltaS111) == CRSDialogo.cteAltaNO)
                { //No se hizo el alta correcta
                    result = CRSDialogo.cteAltaNO;
                }
                else if (Double.Parse(ilAltaS111) == CRSDialogo.cteAltaOK)
                {  //Se hizo el alta correcta
                    result = CRSDialogo.cteAltaOK;
                    if (lcteCliente.fncExtraerClienteL(sDialogoS111) != 0)
                    {
                        lcteCliente.ClienteL = lcteCliente.fncExtraerClienteL(sDialogoS111);
                        if (!lcteCliente.fncAlmacenaClienteB())
                        {
                            MessageBox.Show("No se dio de alta el Cliente", "Tarjeta Corporativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (ilAltaS111 == ((int)CRSDialogo.MensajesS016.cteExisteEnS016).ToString())
                {  //Contrato existe en el S016
                    result = (int)CRSDialogo.MensajesS016.cteExisteEnS016;
                }
                else if (ilAltaS111 == ((int)CRSDialogo.MensajesS111.cteExisteEnS111).ToString())
                {  //Contrato existe en el S111
                    result = (int)CRSDialogo.MensajesS111.cteExisteEnS111;
                }
                else if (Double.Parse(ilAltaS111) == CRSDialogo.cteAltaS016OK)
                {  //Se dio de alta solo en el S016
                    for (mdlParametros.igContador = 1; mdlParametros.igContador <= mdlParametros.igReintentos; mdlParametros.igContador++)
                    {
                        slDialogo = mdlParametros.sgDialogo;
                        OLERut.Conexion tempRefParam3 = ConexionRut;
                        int tempRefParam4 = 333999;
                        ilAltaS111 = CRSGeneral.vfncVPO(CRSDialogo.ifncEnviaDialogo(ref tempRefParam3, ref tempRefParam4, ref slDialogo, ref sEnviaRut, ref dlgpDialogo.sCuenta, ref ejelEjecutivo, CRSDialogo.TipoAlta.cteAltaS111).ToString(), "0");
                        ConexionRut = tempRefParam3;
                        if (Double.Parse(ilAltaS111) != CRSDialogo.cteAltaS016OK)
                        {
                            result = Int32.Parse(ilAltaS111);
                            break;
                        }
                        else
                        {
                            result = CRSDialogo.cteAltaS016OK;
                        }
                    }
                }
            }
            catch (Exception e)
            {

                switch (Information.Err().Number)
                {
                    case 91:
                        //UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted properly. A throw statement was generated instead. 
                        throw new Exception("Migration Exception: 'Resume Next' not supported");
                        break;
                    default:
                        CRSGeneral.prObtenError("AltaEnS111", e);
                        break;
                }
            }

            return result;
        }

        */

        //UPGRADE_NOTE: (7001) The following declaration (ifncVerificaNombre) seems to be dead code
        //private int ifncVerificaNombre( string spNombre)
        //{
        //FixedLengthString szCaracter = new FixedLengthString(1);
        //int iPosComa = 0;
        //int iPosDiag = 0;
        //
        //object bComa = CORVB.NULL_INTEGER;
        //object bDiagonal = CORVB.NULL_INTEGER;
        //
        //for (int iCont = 1; iCont <= spNombre.Length; iCont++)
        //{
        //szCaracter.Value = Strings.Mid(spNombre, iCont, 1);
        //if (szCaracter.Value == ",")
        //{
        ////UPGRADE_WARNING: (1037) Couldn't resolve default property of object bComa.
        //bComa = true;
        //}
        ////UPGRADE_WARNING: (1068) bComa of type Variant is being forced to bool.
        //if (Convert.ToBoolean(bComa) && szCaracter.Value == "/")
        //{
        ////UPGRADE_WARNING: (1037) Couldn't resolve default property of object bDiagonal.
        //bDiagonal = true;
        //break;
        //}
        //}
        //
        ////UPGRADE_WARNING: (1068) bDiagonal of type Variant is being forced to bool.
        //if (Convert.ToBoolean(bDiagonal))
        //{
        //iPosComa = (spNombre.IndexOf(',') + 1);
        //iPosDiag = (spNombre.IndexOf('/') + 1);
        //if (iPosDiag - iPosComa <= 1)
        //{
        //spNombre = Strings.Mid(spNombre, 1, iPosComa - 1).Trim() + ",/" + Strings.Mid(spNombre, iPosDiag + 1).Trim();
        //} else
        //{
        //spNombre = Strings.Mid(spNombre, 1, iPosComa - 1).Trim() + "," + Strings.Mid(spNombre, iPosComa + 1, iPosDiag - iPosComa - 1).Trim() + "/" + Strings.Mid(spNombre, iPosDiag + 1).Trim();
        //}
        //ID_MEM_NCT_EB.Text = spNombre;
        //}
        ////UPGRADE_WARNING: (1068) bDiagonal of type Variant is being forced to int.
        //return Convert.ToInt32(bDiagonal);
        //}

        //UPGRADE_NOTE: (7001) The following declaration (prVisualizaObjeto) seems to be dead code
        //private void  prVisualizaObjeto()
        //{
        //try
        //{
        ////UPGRADE_WARNING: (2065) Form property CORMNEMP.Controls has a new behavior.
        //foreach (Control ctrControl in ContainerHelper.Controls(this))
        //{
        //if (ctrControl is AxThreed.AxSSPanel || ctrControl is GroupBox || ctrControl is AxThreed.AxSSFrame)
        //{
        //ControlHelper.SetVisible(ctrControl, true);
        //}
        //}
        //}
        //catch 
        //{
        //
        //CRSGeneral.prObtenError("VisualizaObjeto");
        //}
        //}


        public void prConfiguracion()
        {
            if (CORVAR.igblPref == 4943 && CORVAR.igblBanco == 88)
            {
                ID_MEM_NCT_EB.MaxLength = 20;
            }
        }


        private string sfncCuentaEmpresarial()
        {
            string result = String.Empty;
            string slCuenta = String.Empty;
            int ilDigitoVerificador = 0;
            ADODB.Recordset adorecord = null;
            string strCtaCiti = String.Empty;

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

                    //Crea la cuenta Banamex
                    slCuenta = StringsHelper.Format(CORVAR.igblPref, "0000");
                    slCuenta = slCuenta + StringsHelper.Format(CORVAR.igblBanco, "00");
                    slCuenta = slCuenta + StringsHelper.Format(CORVAR.lgblNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
                    slCuenta = slCuenta + StringsHelper.Format(0, Formato.sMascara(Formato.iTipo.Ejecutivo));
                    slCuenta = slCuenta + "9";
                    ilDigitoVerificador = CORPROC.Calcula_digito_verif(ref slCuenta);
                    slCuenta = slCuenta + ilDigitoVerificador.ToString();

                    adorecord = new ADODB.Recordset();

                    CORVAR.pszgblsql = " select map_cta_citi from MTCMAP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where map_cta_bnx = '" + slCuenta + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and map_estatus = ''";

                    adorecord.Open(CORVAR.pszgblsql, VBSQL.gConn[10], ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, -1);

                    if (!adorecord.BOF && !adorecord.EOF)
                    {
                        strCtaCiti = Convert.ToString(adorecord.Fields["map_cta_citi"].Value);
                    }

                    adorecord.Close();
                    adorecord = null;

                    if (strCtaCiti == "")
                    {
                        result = slCuenta;
                    }
                    else
                    {
                        result = strCtaCiti;
                    }

                    if (VBSQL.gConn[10].State == 1)
                    {
                        VBSQL.gConn[10].Close();
                    }

                }
            }
            catch (Exception e)
            {

                CRSGeneral.prObtenError("CuentaEmpresarial", e);

                if (adorecord.State != 0)
                {
                    adorecord.Close();
                }
                if (VBSQL.gConn[10].State != ((int)ADODB.ObjectStateEnum.adStateClosed))
                {
                    VBSQL.gConn[10].Close();
                }
            }

            return result;
        }


        private void txtAtencionA_Enter(Object eventSender, EventArgs eventArgs)
        {
            txtAtencionA.SelectionStart = 0;
            txtAtencionA.SelectionLength = Strings.Len(txtAtencionA.Text);
        }

        private void txtAtencionA_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void txtCuentaContable_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            slCuentaContable = txtCuentaContable.Text;
        }

        private void txtCuentaContable_Enter(Object eventSender, EventArgs eventArgs)
        {
            txtCuentaContable.SelectionStart = 0;
            txtCuentaContable.SelectionLength = Strings.Len(txtCuentaContable.Text);
        }

        private void txtCuentaContable_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 13)
            {
                ID_MEM_OK_PB.PerformClick();
                return;
            }
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, false, "-");
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private bool bfncActualizaEjecutivos(int lpEjePrefijo, int lpBanco, int lpEmpresa)
        {

            bool result = false;
            try
            {

                if (slTipoFactura == CRSParametros.cteCorporativo)
                {
                    CORVAR.pszgblsql = "update MTCEJE01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_skip_payment = " + ilSkipPayment.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + lpEjePrefijo.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + lpBanco.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + lpEmpresa.ToString();

                    if (CORPROC2.Modifica_Registro() != 0)
                    {
                        MessageBox.Show("Se han actualizado satisfactoriamente los ejecutivos de la empresa " + StringsHelper.Format(lpEmpresa, Formato.sMascara(Formato.iTipo.Empresa)), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {

                CRSGeneral.prObtenError("ActualizaEjecutivos");
            }

            return result;
        }


    /*
        private void Alta_Empresa()
        {

            int ilDigitoVer = 0;
            string slCuentaEjecutivo0 = String.Empty;
            CRSDialogo.mtcEjecutivo mtcEjecutivo0 = CRSDialogo.mtcEjecutivo.CreateInstance();

            int hBufEmpresa = 0;
            int hBufconsec = 0;
            int iTempErr = 0;
            int iResp = 0;
            int iIncremento = 0;

            //Ariadna
            //Dim bActualizarCM As Integer
            //*********

            int hTransaction = 0;
            string pszConsecEmp = String.Empty;

            //Campos del catalogo

            int lNumEmpresa = 0;
            string pszNumEmpresa = String.Empty;

            string pszCredAcum = String.Empty;
            int lGpoCredTot = 0;
            int lGpoCredAcum = 0;
            int lSumaGpoCredAcum = 0;
            string iVelTrns = String.Empty;
            string pszTonoPul = String.Empty;

            //Domicilio Fiscal

            //Domicilio de envío

            //Representantes




            string pszTipoPago = String.Empty;
            string pszTipoEnv = String.Empty;

            string pszComunicacion = String.Empty;
            string pszEnviaS111 = String.Empty;
            string pszRegresaS111 = String.Empty;
            string pszMensajeS111 = String.Empty;
            string pszMensajeS016 = String.Empty;
            string pszExiste = String.Empty;
            int lID = 0;

            //Dialogo
            CRSDialogo.DatosDialogo dlgAlta = CRSDialogo.DatosDialogo.CreateInstance();
            string sEnviaRut = String.Empty;
            int ilBanderaAlta = 0;
            bool blActualizaCred = false;
            int llCredOriginal = 0;


            int ilcont = 0;
            pryActualizaS111.ClsConectaS111 objTransS111 = null;
            TransS111.EnumEstadosFirma EnCausaErrorFirma = (TransS111.EnumEstadosFirma)0;



            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                this.Cursor = Cursors.WaitCursor;

                bool bConComDrive = false;
                bool bFlagCambios = false;

                int ilIncrReenvio = 1;

                string pszConcBco = Existen_Blancos();

                if (pszConcBco.Length != 0)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Por favor suministre información en el Campo: " + Strings.Chr(CORVB.KEY_RETURN).ToString() + pszConcBco.ToUpper(), (MsgBoxStyle)Int32.Parse(((int)CORVB.MB_ICONINFORMATION).ToString() + ((int)CORVB.MB_OK).ToString()), CORSTR.STR_APP_TIT);
                    return;
                }

                if (Tag.ToString() == CORCONST.TAG_CAMBIO)
                {
                    if (ComparaDatosCambio())
                    {
                        this.Cursor = Cursors.Default;
                        objTransS111 = new pryActualizaS111.ClsConectaS111();
                        //Define el objeto que se va a firmar al S111
                        //AIS-1146 NGONZALEZ
                        objTransS111.set_Usuario(ref CRSParametros.sgUserID);
                        try
                        {
                            if (!objTransS111.FnPreguntaPwd())
                            {
                                if (EnCausaErrorFirma == TransS111.EnumEstadosFirma.EnSinRespuesta)
                                {
                                    MdlCambioMasivo.MsgInfo("No se encontro respuesta del S111");
                                }
                                this.Cursor = Cursors.Default;
                                objTransS111 = null;
                                return;
                            }
                        }
                        catch
                        {
                            if (EnCausaErrorFirma == TransS111.EnumEstadosFirma.EnSinRespuesta)
                            {
                                MdlCambioMasivo.MsgInfo("No se encontro respuesta del S111");
                            }
                            this.Cursor = Cursors.Default;
                            objTransS111 = null;
                            return;


                        }
                    }
                }


                this.Cursor = Cursors.WaitCursor;
                string pszBanco = CORVAR.igblBanco.ToString();
                string iNumGrupo = Conversion.Val(ID_MEM_TEX_PNL[0].Text.Substring(0, Math.Min(ID_MEM_TEX_PNL[0].Text.Length, 4))).ToString();
                string pszNumGrupo = iNumGrupo;

                string pszNomEmpresa = "'" + CORPROC.Valida_Comilla(ID_MEM_NLG_EB.Text.Trim()) + "'"; //Nombre de empresa
                string pszNomCorto = "'" + CORPROC.Valida_Comilla(ID_MEM_NCT_EB.Text) + "'"; // //Nombre corto de la empresa
                string pszNominaEjeBNX = Conversion.Val(ID_MEM_NOM_COB.Text).ToString(); //Nómina del ejecutivo Banamex
                string pszRFC = Seguridad.fncsSustituir(ID_MEM_RFC_MKE.CtlText, "-", "");
                pszRFC = "'" + CORPROC.Valida_Comilla(pszRFC) + "'"; //RFC
                string pszCartera = Conversion.Val(ID_MEM_CAR_PIC.CtlText).ToString(); //No de cartera
                string pszAccionista = "'" + CORPROC.Valida_Comilla(ID_MEM_PAC_EB.Text) + "'"; //Principal accionista
                string pszSector = Strings.Mid(ID_MEM_SEC_COB.Text, 2, 1); //Sector al que pertenece
                int pszCreditoGlobal = Int32.Parse(ID_MEM_CRE_FTB.CtlText); //Crédito total asignado

                if (Conversion.Val(ID_MEM_CRED_ACUM_FTB.CtlText) == CORVB.NULL_INTEGER)
                {
                    pszCredAcum = "0";
                }
                else
                {
                    pszCredAcum = ID_MEM_CRED_ACUM_FTB.CtlText;
                }

                string pszFecVenCred = ID_MEM_FEC_VEN_DTB.CtlText; //Fecha de vencimiento de credito
                System.DateTime TempDate = DateTime.FromOADate(0);
                pszFecVenCred = "'" + Strings.Mid(pszFecVenCred, 1, 3) + CORPROC2.Obten_Mes_Ingles(StringsHelper.IntValue((DateTime.TryParse(pszFecVenCred, out TempDate)) ? TempDate.ToString("MM") : pszFecVenCred)) + Strings.Mid(pszFecVenCred, 6, 5) + "'"; //Domicilio Fiscal
                string pszCalleFis = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[0].Text) + "'"; //Domicilio Fiscal
                string pszColoniaFis = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[0].Text) + "'"; //Colonia
                string pszCiudadFis = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[0].Text) + "'"; //Ciudad
                string pszPoblacionFis = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[0].Text) + "'"; //Poblacion/delegacion
                string pszEstadoFis = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[0].SelectedIndex]) + "'"; //Estado
                string pszCpFis = Conversion.Val(ID_MEM_CP_PIC[0].CtlText).ToString(); //Cp

                //Telefonos
                string pszTelefono = "'" + Conversion.Val(ID_MEM_CON_TXT.Text).ToString() + "'"; //Telefono
                string pszTelExt = "'" + Conversion.Val(ID_MEM_TEL_EXT_TXT.Text).ToString() + "'"; //Extensión
                string pszLada = "'" + Conversion.Val(ID_MEM_LADA_TXT.Text).ToString() + "'"; //Lada
                string pszFax = "'" + Conversion.Val(ID_MEM_FAX_TXT.Text).ToString() + "'"; //Fax
                string pszFaxLada = "'" + Conversion.Val(ID_MEM_FAX_LADA_TXT.Text).ToString() + "'"; //Fax lada
                string pszEmail = "'" + CORPROC.Valida_Comilla(ID_MEM_EMAIL_TXT.Text) + "'"; //Email
                string pszInternet = "'" + CORPROC.Valida_Comilla(ID_MEM_INTER_TXT.Text) + "'"; //Internet

                //Domicilio de envío
                string pszCalleEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[1].Text) + "'"; //Domicilio de envio
                string pszColoniaEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[1].Text) + "'"; //Colonia
                string pszCiudadEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[1].Text) + "'"; //Ciudad
                string pszPoblacionEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[1].Text) + "'"; //Poblacion/delegacion
                string pszEstadoEnv = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex]) + "'"; //Estado
                string pszCpEnv = Conversion.Val(ID_MEM_CP_PIC[1].CtlText).ToString(); //Cp

                string pszSucursal = Conversion.Str(ID_MEM_SUC_ITB.CtlText); //Sucursal
                string pszCtaCaptacion = Conversion.Val(ID_MEM_NMC_FTB.CtlText).ToString(); //Cuenta de Captación


                //Tipo de pago
                if (ID_MEM_TPA_3OPB[0].Checked)
                { //Automático
                    pszTipoPago = "'" + CRSParametros.ctePagoAutomatico + "'";
                }
                else if (ID_MEM_TPA_3OPB[1].Checked)
                {  //Individual
                    pszTipoPago = "'" + CRSParametros.ctePagoIndividual + "'";
                }
                else if (ID_MEM_TPA_3OPB[2].Checked)
                {  //Libre
                    pszTipoPago = "'" + CRSParametros.ctePagoLibre + "'";
                }

                //Envio de Edo. de Cuenta a
                if (ID_MEM_EEC_3OPB[0].Checked)
                { //Empresa
                    pszTipoEnv = "'" + CRSParametros.cteEmpresa + "'";
                }
                else
                {
                    //Individual
                    pszTipoEnv = "'" + CRSParametros.cteIndividual + "'";
                }

                //Tipo de Facturacion
                if (ID_MEM_TFA_3OPB[0].Checked)
                { //Corporativo
                    slTipoFactura = CRSParametros.cteCorporativo;
                }
                else
                {
                    //Individual
                    slTipoFactura = CRSParametros.cteIndividual;
                }

                //Tipo de Producto
                switch (optTipoProducto[0].Checked)
                {
                    case true:  //Business Card 
                        slTipoProducto = CRSParametros.cteBusinessCard;
                        break;
                    //AIS-66 NGONZALEZ
      
                }


                ilSkipPayment = (int)chkSkipPayment.CheckState;

                //Representante 1
                string pszNombreR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[0].Text) + "'"; //Nombre de Representante 1
                string pszPuestoR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[0].Text) + "'"; //Puesto
                string pszTelR1 = Conversion.Val(ID_MEM_TEL_MKE[0].CtlText).ToString(); //Telefono
                string pszExtR1 = Conversion.Val(ID_MEM_EXT_PIC[0].CtlText).ToString(); //Extension
                string pszFaxR1 = Conversion.Val(ID_MEM_FAX_MKE[0].CtlText).ToString(); //Fax

                //Representante 2
                string pszNombreR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[1].Text) + "'"; //Nombre de Representante 2
                string pszPuestoR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[1].Text) + "'"; //Puesto
                string pszTelR2 = Conversion.Val(ID_MEM_TEL_MKE[1].CtlText).ToString(); //Telefono
                string pszExtR2 = Conversion.Val(ID_MEM_EXT_PIC[1].CtlText).ToString(); //Extension
                string pszFaxR2 = Conversion.Val(ID_MEM_FAX_MKE[1].CtlText).ToString(); //Fax

                //Representante 3
                string pszNombreR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[2].Text) + "'"; //Nombre de Representante 3
                string pszPuestoR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[2].Text) + "'"; //Puesto
                string pszTelR3 = Conversion.Val(ID_MEM_TEL_MKE[2].CtlText).ToString(); //Telefono
                string pszExtR3 = Conversion.Val(ID_MEM_EXT_PIC[2].CtlText).ToString(); //Extension
                string pszFaxR3 = Conversion.Val(ID_MEM_FAX_MKE[2].CtlText).ToString(); //Fax


                CheckState ilGenArchivoCDF = ChkCDF.CheckState; //Variable para marcar la generacion de Archivo cdf

                pszFirma1 = "0x0";
                pszFirma2 = "0x0";
                pszFirma3 = "0x0";

                string pszAtencionA = txtAtencionA.Text.Trim(); //FSWB NR 20070223 //FSWB 20070223 NR Se incluyen campos Atencion A y Persona
                int pszPersona = StringsHelper.IntValue(Strings.Mid(ID_MEM_PERSONA.Text, 1, 1)); //FSWB NR 20070223 //FSWB NR 20070223

                if (Conversion.Val(pszNumGrupo) != 0)
                {
                    CORVAR.pszgblsql = "select ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_cred_tot,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_acum_cred ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCCOR01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString() + " ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString() + " ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_num = " + pszNumGrupo;

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            lGpoCredTot = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            lGpoCredAcum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        if (Tag.ToString() == CORCONST.TAG_ALTA)
                        {
                            //                    If bfncExcepcionCredito = True Then GoTo OmiteValidacionLimiteCredito0
                            if ((lGpoCredAcum + pszCreditoGlobal) > lGpoCredTot)
                            {
                                this.Cursor = Cursors.Default;
                                lSumaGpoCredAcum = lGpoCredTot - lGpoCredAcum;
                                Fichero(0);
                                ID_MEM_CRE_FTB.Focus();
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("Se ha sobrepasado el crédito del Corporativo. Crédito disponible: " + StringsHelper.Format(lSumaGpoCredAcum, "###,###,###.00"), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                                return;
                            }
                            else
                            {

                                lSumaGpoCredAcum = lGpoCredAcum + pszCreditoGlobal;
                            }
                        }
                        else
                        {
                            //                    If bfncExcepcionCredito = True Then GoTo OmiteValidacionLimiteCredito1
                            if (Conversion.Val(ID_MEM_CRE_FTB.CtlText.ToString()) < Conversion.Val(ID_MEM_CRED_ACUM_FTB.CtlText.ToString()))
                            {
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("El credito asignado es menor al credito acumulado", CORVB.MB_ICONEXCLAMATION, null);
                                Fichero(CORVB.NULL_INTEGER);
                                ID_MEM_CRE_FTB.Focus();
                                objTransS111 = null;
                                this.Cursor = Cursors.Default;
                                return;
                            }
                            if ((lGpoCredAcum - lLeeCreditoGlobal + pszCreditoGlobal) > lGpoCredTot)
                            {
                                this.Cursor = Cursors.Default;
                                lSumaGpoCredAcum = lGpoCredTot - lGpoCredAcum;
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("Se ha sobrepasado el crédito del Corporativo. Crédito disponoble:" + Conversion.Str(lSumaGpoCredAcum), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                                Fichero(CORVB.NULL_INTEGER);
                                ID_MEM_CRE_FTB.Focus();
                                objTransS111 = null;
                                return;
                            }
                            else
                            {

                                if (lGpoCredAcum == CORVB.NULL_INTEGER)
                                {
                                    lSumaGpoCredAcum = pszCreditoGlobal;
                                }
                                else
                                {
                                    lSumaGpoCredAcum = lGpoCredAcum - lLeeCreditoGlobal + pszCreditoGlobal;
                                }
                            }
                        }
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                }

                if (Tag.ToString() != CORCONST.TAG_ALTA)
                {
                    //***** CAMBIO *****

                    VB6.SetItemString(CORCTEMP.DefInstance.ID_CEM_EMP_LB, ListBoxHelper.GetSelectedIndex(CORCTEMP.DefInstance.ID_CEM_EMP_LB), Strings.Mid(VB6.GetItemString(CORCTEMP.DefInstance.ID_CEM_EMP_LB, ListBoxHelper.GetSelectedIndex(CORCTEMP.DefInstance.ID_CEM_EMP_LB)), 1, 8) + ID_MEM_NLG_EB.Text.Trim());
                    pszNumEmpresa = CORVAR.lgblNumEmpresa.ToString();

                    //        If bfncExcepcionCredito = True Then GoTo OmiteValidacionLimiteCredito2
                    if (Double.Parse(pszCredAcum) <= pszCreditoGlobal)
                    {

                        if (pszCreditoGlobal != mtcEjeEmpOriginal.lEjeLimiteCredito && mtcEjeEmpOriginal.sTipoFacturacion == CRSParametros.cteCorporativo)
                        {
                            llCredOriginal = mtcEjeEmpOriginal.lEjeLimiteCredito;
                            mtcEjeEmpOriginal.lEjeLimiteCredito = pszCreditoGlobal;
                            blActualizaCred = bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteCredito, mtcEjeEmpOriginal, objTransS111);
                            if (blActualizaCred)
                            {
                                llCredOriginal = mtcEjeEmpOriginal.lEjeLimiteCredito;
                            }
                            else
                            {
                                mtcEjeEmpOriginal.lEjeLimiteCredito = llCredOriginal;
                                MessageBox.Show("No se puede realizar la actualización del límite de crédito" + "\r\n" + "debido a un problema de comunicaciones con el S111." + "\r\n" + "Intentelo más tarde.", "Sistema S111", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Cursor = Cursors.WaitCursor;
                                return;
                            }
                        }
                        else
                        {
                            blActualizaCred = true;
                        }
                    }
                    else
                    {
                        Fichero(0);
                        bool tempRefParam = true;
                        ID_MEM_CRE_FTB_Validating(ID_MEM_CRE_FTB, new CancelEventArgs(tempRefParam));
                        this.Cursor = Cursors.Default;
                        return;
                    }

                    if (Seguridad.fncsSustituir(pszNomCorto, "'", "").Trim().ToUpper() != mtcEjeEmpOriginal.sEjeNomGrabado.Trim().ToUpper())
                    {
                        if (bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteNombre, mtcEjeEmpOriginal, objTransS111))
                        {
                            MessageBox.Show("El nombre corto de la empresa ha sido actualizado en el S111.", "Mensaje S111", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se puede realizar la actualización del nombre corto de la empresa." + "\r\n" + "debido a un problema de comunicaciones con el S111." + "\r\n" + "Intentelo más tarde.", Application.ProductName);
                            return;
                        }

                        CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EMP + " set emp_nom_graba=" + pszNomCorto;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " , emp_usu_cam = '" + CRSParametros.sgUserID + "' ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;

                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            MdlCambioMasivo.MsgInfo("El nobre corto de la empresa ha sido actualizado en la Base de Datos.");
                        }
                        else
                        {
                            MdlCambioMasivo.MsgError("El nobre corto de la empresa no pudo ser actualizado en la Base de Datos.");
                        }


                        CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EJE + " set eje_nom_gra=" + pszNomCorto;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " , eje_usuario_cam = '" + CRSParametros.sgUserID + "' ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = 0";

                        if (CORPROC2.Modifica_Registro() == 0)
                        {
                            MdlCambioMasivo.MsgError("El nombre corto de la empresa no pudo ser actualizado en el ejecutivo 0.");
                        }

                    }

                    //*** Valores ***
                    mdlParametros.tgCambioS111.MccL = Convert.ToInt32(Conversion.Val(mskMCC.CtlText));
                    mdlParametros.tgCambioS111.SkipPaymentI = ilSkipPayment;

                    //**Cambio de Skip Payment**
                    if (ilSkipPaymentCambio != mdlParametros.tgCambioS111.SkipPaymentI)
                    {
                        if (bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteSkip, mtcEjeEmpOriginal, objTransS111))
                        {
                            CORVAR.pszgblsql = "update MTCEMP01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_skip_payment = " + mdlParametros.tgCambioS111.SkipPaymentI.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";

                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;

                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                                MessageBox.Show("El Skip Payment de la empresa ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El Skip Payment de la empresa no ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede realizar la actualización del Skip Payment de la empresa." + "\r\n" + "debido a un problema de comunicaciones con el S111." + "\r\n" + "Intentelo más tarde.", Application.ProductName);
                            return;
                        }
                    }

                    //Ariadna ****************************
                    bActualizarCM = 0;

                    if (Cambio_DomicilioEnv())
                    {
                        bActualizarCM = -1;
                    }
                    //************************************


                    //**Cambio de MCC**
                    if (ilTablaMCCCambio != mdlParametros.tgCambioS111.MccL)
                    {
                        if (bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteMcc, mtcEjeEmpOriginal, objTransS111))
                        {
                            CORVAR.pszgblsql = "update MTCEMP01";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_tabla_mcc = " + mdlParametros.tgCambioS111.MccL.ToString() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;

                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                                MessageBox.Show("El MCC de la empresa ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El MCC de la empresa no ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede realizar la actualización del MCC de la empresa." + "\r\n" + "debido a un problema de comunicaciones con el S111." + "\r\n" + "Intentelo más tarde.", Application.ProductName);
                            return;
                        }
                    }

                    if (bActualizarCM != 0)
                    {
                        CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_EJE + " SET ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "eje_tel_dom = '" + ID_MEM_CON_TXT.Text.Trim() + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",eje_tel_ofi = '" + ID_MEM_CON_TXT.Text.Trim() + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + ",eje_ext = '" + ID_MEM_TEL_EXT_TXT.Text.Trim() + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " AND gpo_banco= " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " AND emp_num = " + pszNumEmpresa;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " AND eje_num = 0";

                        if (CORPROC2.Modifica_Registro() == 0)
                        {
                            MessageBox.Show("No fue posible actualizar los datos en el ejecutivo 0.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    if (bActualizarCM == (-1))
                    {
                        if (!InsertaTablaCambios(ref pszNumEmpresa, ref pszBanco))
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("No se pudo insertar datos en la tabla de cambios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (bHayReg)
                        {
                            if (RealizaCambiosMasivosEmp(Int32.Parse(pszNumEmpresa), objTransS111))
                            {
                                return;
                            }
                        }
                    }

                    //fncFirmaS041B "", "", tDesfirmaS041
                    //objSeguridad.Disconnect

                    if ((Conversion.Val(pszNominaEjeBNX) != Conversion.Val(mlNominaEjeBNX.ToString())) || 
                        (pszNomEmpresa.Trim() != ("'" + msNomEmpresa.Trim() + "'")) ||
                        (pszNomCorto.Trim() != ("'" + msNomCorto.Trim() + "'")) || 
                        (pszRFC.Trim() != ("'" + msRFC.Trim() + "'")) || 
                        (Conversion.Val(pszCartera) != Conversion.Val(mdCartera.ToString())) ||
                        (pszAccionista.Trim() != ("'" + msAccionista.Trim() + "'")) ||
                        (Conversion.Val(pszSector) != Conversion.Val((miSector + 1).ToString())) ||
                        (Conversion.Val(pszCreditoGlobal.ToString()) != Conversion.Val(mlCreditoGlobal.ToString())) ||
                        (Conversion.Val(pszCredAcum) != Conversion.Val(mlCredAcum.ToString())) ||
                        (pszCalleFis.Trim() != ("'" + msCalleFis.Trim() + "'")) ||
                        (pszColoniaFis.Trim() != ("'" + msColoniaFis.Trim() + "'")) ||
                        (pszCiudadFis.Trim() != ("'" + msCiudadFis.Trim() + "'")) ||
                        (pszPoblacionFis.Trim() != ("'" + msPoblacionFis.Trim() + "'")) ||
                        (pszEstadoFis.Trim() != ("'" + msEstadoFis.Trim() + "'")) ||
                        (Conversion.Val(pszCpFis) != Conversion.Val(mlCpFis.ToString())) ||
                        (pszTonoPul != ("'" + msTonoPul.Trim() + "'")) ||
                        (Conversion.Val(iVelTrns) != Conversion.Val(miVelTrns.ToString())) ||
                        (Conversion.Val(ID_MEM_CON_TXT.Text) != Conversion.Val(msTelefono)) ||
                        (Conversion.Val(ID_MEM_LADA_TXT.Text) != Conversion.Val(msLada)) ||
                        (Conversion.Val(ID_MEM_FAX_TXT.Text) != Conversion.Val(msFax)) ||
                        (pszEmail.Trim() != ("'" + msEmail.Trim() + "'")) ||
                        (pszInternet.Trim() != ("'" + msInternet.Trim() + "'")) ||
                        (Conversion.Val(pszCtaCaptacion) != Conversion.Val(mdCtaCaptacion.ToString())) ||
                        (Conversion.Val(pszSucursal) != Conversion.Val(miSucursal.ToString())) ||
                        (pszNombreR1.Trim() != ("'" + msNombreR1.Trim() + "'")) ||
                        (pszPuestoR1.Trim() != ("'" + msPuestoR1.Trim() + "'")) ||
                        (Conversion.Val(pszTelR1) != Conversion.Val(msTelR1)) ||
                        (Conversion.Val(pszExtR1) != Conversion.Val(msExtR1)) ||
                        (Conversion.Val(pszFaxR1) != Conversion.Val(pszFaxR1)) ||
                        (pszNombreR2.Trim() != ("'" + msNombreR2.Trim() + "'")) ||
                        (pszPuestoR2.Trim() != ("'" + msPuestoR2.Trim() + "'")) ||
                        (Conversion.Val(pszTelR2) != Conversion.Val(msTelR2)) ||
                        (Conversion.Val(pszExtR2) != Conversion.Val(msExtR2)) ||
                        (Conversion.Val(pszFaxR2) != Conversion.Val(pszFaxR2)) ||
                        (pszNombreR3.Trim() != ("'" + msNombreR3.Trim() + "'")) ||
                        (pszPuestoR3.Trim() != ("'" + msPuestoR3.Trim() + "'")) ||
                        (Conversion.Val(pszTelR3) != Conversion.Val(msTelR3)) ||
                        (Conversion.Val(pszExtR3) != Conversion.Val(msExtR3)) ||
                        (Conversion.Val(pszFaxR3) != Conversion.Val(pszFaxR3)) ||
                        (pszAtencionA.Trim() != ("'" + slAtencionA.Trim() + "'")) ||
                        (Conversion.Val(pszPersona.ToString()) != (Conversion.Val(ilPersona.ToString()))))
                    { //FSWB NR 20070223

                        bFlagCambios = true;

                    }

                    CORVAR.pszgblsql = "update MTCEMP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set ejx_numero = " + pszNominaEjeBNX;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom = " + pszNomEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom_graba = " + pszNomCorto;
                    //pszgblsql = pszgblsql & ",emp_rfc=" & pszRFC
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_num_cartera = " + pszCartera;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_princ_acc = " + pszAccionista;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_sector = " + pszSector;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ((blActualizaCred) ? ",emp_cred_tot=" + Conversion.Str(pszCreditoGlobal) : "");
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_acum_cred = " + pszCredAcum;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_calle = " + pszCalleFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_col = " + pszColoniaFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_ciu = " + pszCiudadFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_pob = " + pszPoblacionFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_edo = " + pszEstadoFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_cp = " + pszCpFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fec_venc_cred = " + pszFecVenCred;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_telefono = " + pszTelefono;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tel_lada = " + pszLada;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax = " + pszFax;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_param_modem = '" + pszTonoPul + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_vel_transmis = " + Conversion.Val(iVelTrns).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_email = " + pszEmail;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_internet = " + pszInternet;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_cta_capt = " + pszCtaCaptacion;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_sucur = " + pszSucursal;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_pago = " + pszTipoPago;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_envio = " + pszTipoEnv;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom_r1 = " + pszNombreR1;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_pues_r1 = " + pszPuestoR1;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tel_r1 = '" + pszTelR1 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_ext_r1 = '" + pszExtR1 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax_r1 = '" + pszFaxR1 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom_r2 = " + pszNombreR2;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_pues_r2 = " + pszPuestoR2;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tel_r2 = '" + pszTelR2 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_ext_r2 = '" + pszExtR2 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax_r2 = '" + pszFaxR2 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom_r3 = " + pszNombreR3;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_pues_r3 = " + pszPuestoR3;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tel_r3 = '" + pszTelR3 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_ext_r3 = '" + pszExtR3 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax_r3 = '" + pszFaxR3 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax_lada = " + pszFaxLada;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_extension = " + pszTelExt;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_dia_corte = " + ilDiaCorte.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_plazo_gracia = " + ilPlazoGracia.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_plazo_no_cob = " + ilPlazoNoCobro.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_gen_SBF = " + ilGeneraSBF.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_fac = '" + slTipoFactura + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_esquema_pago = '" + slEsquemaPago + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_producto = '" + slTipoProducto + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_estruct_gastos = " + llEstructuraGastos.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_mes_fiscal  = " + ilMesFiscal.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_usu_cam = '" + slUsuarioCambio + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fech_cam = convert(int,convert(char(20), getdate(),112))";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_hora_cam = (convert(int,datepart(hh,getdate())) * 100) + (convert(int, datepart(mi,getdate())))";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_lim_dis_efec = " + ilMontoPorciento.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_min_factura = " + dlFacturacionMinima.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_cta_contable = '" + slCuentaContable + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_gen_CDF= " + ((int)ilGenArchivoCDF).ToString() + "";

                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_atn_a = '" + pszAtencionA + "'"; //FSWB NR 20070223
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_persona= " + pszPersona.ToString() + ""; //FSWB NR 20070223

                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco= " + mdlParametros.gprdProducto.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;

                    this.Cursor = Cursors.Default;

                    if (CORPROC2.Modifica_Registro() != 0)
                    {
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                        //FSWB NR 20070323 Se envia mensaje de actualizacion
                        MessageBox.Show("Se actualizó información de la Empresa exitosamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //20021211 --Ariadna--- Comentario
                        //************ JPU ************
                        //OJO Con esta Funcion OJO
                        bfncActualizaEjecutivos(mdlParametros.gprdProducto.PrefijoL, mdlParametros.gprdProducto.BancoL, Convert.ToInt32(Conversion.Val(pszNumEmpresa)));
                        //OJO Con esta Funcion OJO
                        //************ JPU ************

                        IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
                        IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
                        IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);

                        if (iErr == CORCONST.OK)
                        {
                            this.Cursor = Cursors.Default;
                            //MsgBox "La empresa " & Trim$(ID_MEM_NLG_EB) & " fué actualizada", vbInformation, STR_APP_TIT
                            this.Cursor = Cursors.WaitCursor;

                            CORVAR.pszgblsql = "UPDATE MTCCOR01 set gpo_acum_cred = (select sum(emp_cred_tot) from MTCEMP01 ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo + ")";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo;

                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                            }
                            else
                            {
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("No se actualizó el crédito acumulado del grupo: " + pszNumGrupo + " Con la cantidad: " + lSumaGpoCredAcum.ToString(), (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                            this.Cursor = Cursors.Default;

                            CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EJE + " set eje_nombre=" + pszNomEmpresa;
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " where ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco= " + mdlParametros.gprdProducto.BancoL.ToString();
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;
                            CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = 0";

                            if (CORPROC2.Modifica_Registro() == 0)
                            {
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("No se pudo actualizar el nombre largo en el ejecutivo 0", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("La empresa " + ID_MEM_NLG_EB.Text.Trim() + " no pudo ser actualizada", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("La empresa " + ID_MEM_NLG_EB.Text.Trim() + " no pudo ser actualizada", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    CORREGFI.DefInstance.Close();
                    this.Close();
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }
*/
        private void Cambia_Empresa()
        {


            string pszBanco = String.Empty;
            string iNumGrupo = String.Empty;
            string pszNumGrupo = String.Empty;
            string pszNomEmpresa = String.Empty;
            string pszNomCorto = String.Empty;
            string pszNomEmp = String.Empty;
            string pszNominaEjeBNX = String.Empty;
            string pszRFC = String.Empty;
            string pszCartera = String.Empty;
            string pszAccionista = String.Empty;
            string pszSector = String.Empty;
            int pszCreditoGlobal = 0;
            string pszCredAcum = String.Empty;
            string pszFecVenCredito = String.Empty;
            string pszFecVenCred = String.Empty; //variable que se utiliza para dejar el formato fecha que se requiere para sybase
            System.DateTime TempDate = DateTime.FromOADate(0);
            string pszCalleFis = String.Empty;
            string pszColoniaFis = String.Empty;
            string pszCiudadFis = String.Empty;
            string pszPoblacionFis = String.Empty;
            string pszEstadoFis = String.Empty;
            string pszCpFis = String.Empty;
            string pszTelefono = String.Empty;
            string pszTelExt = String.Empty;
            string pszLada = String.Empty;
            string pszFax = String.Empty;
            string pszFaxLada = String.Empty;
            string pszEmail = String.Empty;
            string pszInternet = String.Empty;
            string pszCalleEnv = String.Empty;
            string pszColoniaEnv = String.Empty;
            string pszCiudadEnv = String.Empty;
            string pszPoblacionEnv = String.Empty;
            string pszEstadoEnv = String.Empty;
            string pszCpEnv = String.Empty;
            string pszSucursal = String.Empty;
            string pszCtaCaptacion = String.Empty;
            string pszTipoPago = String.Empty;
            string pszTipoEnv = String.Empty;
            /*slTipoFactura variable global*/
            /*slTipoProducto variable global*/
            /*ilSkipPayment  variable global*/
            string pszNombreR1 = String.Empty;
            string pszPuestoR1 = String.Empty;
            string pszTelR1 = String.Empty;
            string pszExtR1 = String.Empty;
            string pszFaxR1 = String.Empty;

            //Representante 2
            string pszNombreR2 = String.Empty;
            string pszPuestoR2 = String.Empty;
            string pszTelR2 = String.Empty;
            string pszExtR2 = String.Empty;
            string pszFaxR2 = String.Empty;

            //Representante 3
            string pszNombreR3 = String.Empty;
            string pszPuestoR3 = String.Empty;
            string pszTelR3 = String.Empty;
            string pszExtR3 = String.Empty;
            string pszFaxR3 = String.Empty;
            int ilGenArchivoCDF ;
            /* string pszFirma1 variable global*/
            /* string pszFirma2 variable global*/
            /* string pszFirma3 variable global*/
            long lGpoCredTot = 0;
            long lGpoCredAcum = 0;
            long lSumaGpoCredAcum = 0;
            string pszNumEmpresa = String.Empty;
            string pszAtencionA = String.Empty;
            int pszPersona = 0;
            string pszConcBco;
            string pszTipoProducto=String.Empty;
            int pszGeneraSBF=0;
            int pszPlazoGracia = 0;
            int pszPlazoNoCobro = 0;
            int pszEstructuraGastos = 0;   
            int pszMesFiscalGen = 0;       
            int pszMontoPorciento = 0;   
            double pszFacturacionMinima = 0;           
            string pszCuentaContable = String.Empty;
            int banderaCambiosLocales=0;
            int banderaCambiosS111 = 0;
            int banderaCambioDomicilio = 0;
            string alcanceCambio = "I";
            bool blActualizaCred = false;
            int llCredOriginal = 0;


            N_ActualizaS111.ClsConectaS111 objTransS111 = null;
            TransS111.EnumEstadosFirma EnCausaErrorFirma = (TransS111.EnumEstadosFirma)0;
            
            try
            {

                VB6.SetItemString(CORCTEMP.DefInstance.ID_CEM_EMP_LB, ListBoxHelper.GetSelectedIndex(CORCTEMP.DefInstance.ID_CEM_EMP_LB), Strings.Mid(VB6.GetItemString(CORCTEMP.DefInstance.ID_CEM_EMP_LB, ListBoxHelper.GetSelectedIndex(CORCTEMP.DefInstance.ID_CEM_EMP_LB)), 1, 8) + ID_MEM_NLG_EB.Text.Trim());
                pszNumEmpresa = CORVAR.lgblNumEmpresa.ToString();
                this.Cursor = Cursors.WaitCursor;
                pszConcBco = Existen_Blancos();

                if (pszConcBco.Length != 0)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Por favor suministre información en el Campo: " + Strings.Chr(CORVB.KEY_RETURN).ToString() + pszConcBco.ToUpper(), (MsgBoxStyle)Int32.Parse(((int)CORVB.MB_ICONINFORMATION).ToString() + ((int)CORVB.MB_OK).ToString()), CORSTR.STR_APP_TIT);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                pszBanco = CORVAR.igblBanco.ToString();
                iNumGrupo = Conversion.Val(ID_MEM_TEX_PNL[0].Text.Substring(0, Math.Min(ID_MEM_TEX_PNL[0].Text.Length, 4))).ToString();
                pszNumGrupo = iNumGrupo;
                pszNomEmpresa = "'" + CORPROC.Valida_Comilla(ID_MEM_NLG_EB.Text.Trim()) + "'"; //Nombre de empresa
                pszNomEmp = CORPROC.Valida_Comilla(ID_MEM_NCT_EB.Text).Trim(); // //Nombre corto de la empresa
                pszNomCorto = "'" + CORPROC.Valida_Comilla(ID_MEM_NCT_EB.Text) + "'"; // //Nombre corto de la empresa
                pszNominaEjeBNX = Conversion.Val(ID_MEM_NOM_COB.Text).ToString(); //Nómina del ejecutivo Banamex
                pszRFC = Seguridad.fncsSustituir(ID_MEM_RFC_MKE.CtlText, "-", "");
                pszRFC = "'" + CORPROC.Valida_Comilla(pszRFC) + "'"; //RFC
                pszCartera = Conversion.Val(ID_MEM_CAR_PIC.CtlText).ToString(); //No de cartera
                pszAccionista = "'" + CORPROC.Valida_Comilla(ID_MEM_PAC_EB.Text) + "'"; //Principal accionista
                //pszSector = Strings.Mid(ID_MEM_SEC_COB.Text, 2, 1); //Sector al que pertenece
                pszSector = Strings.Mid(ID_MEM_SEC_COB.Text, 1, 2); //Sector al que pertenece
                pszCreditoGlobal = Int32.Parse(ID_MEM_CRE_FTB.CtlText); //Crédito total asignado

                pszPlazoGracia = Convert.ToInt32(Conversion.Val(mskPeriodoGracia.defaultText));
                pszPlazoNoCobro = Convert.ToInt32(Conversion.Val(mskPerNoInteres.defaultText));

                if (Conversion.Val(ID_MEM_CRED_ACUM_FTB.CtlText) == CORVB.NULL_INTEGER)
                {
                    pszCredAcum = "0";
                }
                else
                {
                    pszCredAcum = ID_MEM_CRED_ACUM_FTB.CtlText;
                }
                
                pszFecVenCredito = ID_MEM_FEC_VEN_DTB.CtlText; //Fecha de vencimiento de credito
                TempDate = DateTime.FromOADate(0);
                pszFecVenCred = "'" + Strings.Mid(pszFecVenCredito, 1, 3) + CORPROC2.Obten_Mes_Ingles(StringsHelper.IntValue((DateTime.TryParse(pszFecVenCredito, out TempDate)) ? TempDate.ToString("MM") : pszFecVenCredito)) + Strings.Mid(pszFecVenCredito, 6, 5) + "'";                 
                pszCalleFis = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[0].Text) + "'"; //Domicilio Fiscal
                pszColoniaFis = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[0].Text) + "'"; //Colonia
                pszCiudadFis = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[0].Text) + "'"; //Ciudad
                pszPoblacionFis = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[0].Text) + "'"; //Poblacion/delegacion
                pszEstadoFis = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[0].SelectedIndex]) + "'"; //Estado
                pszCpFis = Conversion.Val(ID_MEM_CP_PIC[0].CtlText).ToString(); //Cp

                //Telefonos
                pszTelefono = "'" + Conversion.Val(ID_MEM_CON_TXT.Text).ToString() + "'"; //Telefono
                pszTelExt = "'" + Conversion.Val(ID_MEM_TEL_EXT_TXT.Text).ToString() + "'"; //Extensión
                pszLada = "'" + Conversion.Val(ID_MEM_LADA_TXT.Text).ToString() + "'"; //Lada
                pszFax = "'" + Conversion.Val(ID_MEM_FAX_TXT.Text).ToString() + "'"; //Fax
                pszFaxLada = "'" + Conversion.Val(ID_MEM_FAX_LADA_TXT.Text).ToString() + "'"; //Fax lada
                pszEmail = "'" + CORPROC.Valida_Comilla(ID_MEM_EMAIL_TXT.Text) + "'"; //Email
                pszInternet = "'" + CORPROC.Valida_Comilla(ID_MEM_INTER_TXT.Text) + "'"; //Internet

                //Domicilio de envío
                pszCalleEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[1].Text) + "'"; //Domicilio de envio
                pszColoniaEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[1].Text) + "'"; //Colonia
                pszCiudadEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[1].Text) + "'"; //Ciudad
                pszPoblacionEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[1].Text) + "'"; //Poblacion/delegacion
                pszEstadoEnv = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex]) + "'"; //Estado
                pszCpEnv = Conversion.Val(ID_MEM_CP_PIC[1].CtlText).ToString(); //Cp

                pszSucursal = Conversion.Str(ID_MEM_SUC_ITB.CtlText); //Sucursal
                pszCtaCaptacion = Conversion.Val(ID_MEM_NMC_FTB.CtlText).ToString(); //Cuenta de Captación

                /*
                if ( _ID_MEM_TPA_3OPB_0.Checked )
                    pszTipoPago = "'" + CRSParametros.ctePagoAutomatico + "'";
                if ( _ID_MEM_TPA_3OPB_1.Checked)
                    pszTipoPago = "'" + CRSParametros.ctePagoIndividual + "'";
                if (_ID_MEM_TPA_3OPB_2.Checked)
                    pszTipoPago = "'" + CRSParametros.ctePagoLibre + "'";*/
                
                //Tipo de pago
                if (ID_MEM_TPA_3OPB[0].Checked)
                { //Automático
                    pszTipoPago = "'" + CRSParametros.ctePagoAutomatico + "'";
                }
                else if (ID_MEM_TPA_3OPB[1].Checked)
                {  //Individual
                    pszTipoPago = "'" + CRSParametros.ctePagoIndividual + "'";
                }
                else if (ID_MEM_TPA_3OPB[2].Checked)
                {  //Libre
                    pszTipoPago = "'" + CRSParametros.ctePagoLibre + "'";
                }

                //Envio de Edo. de Cuenta a
                if (ID_MEM_EEC_3OPB[0].Checked)
                { //Empresa
                    pszTipoEnv = "'" + CRSParametros.cteEmpresa + "'";
                }
                else
                {
                    //Individual
                    pszTipoEnv = "'" + CRSParametros.cteIndividual + "'";
                }

                //Tipo de Facturacion
                if (ID_MEM_TFA_3OPB[0].Checked)
                { //Corporativo
                    slTipoFactura = CRSParametros.cteCorporativo;
                }
                else
                {
                    //Individual
                    slTipoFactura = CRSParametros.cteIndividual;
                }

                if (optTipoProducto[0].Checked)
                    pszTipoProducto = CRSParametros.cteBusinessCard;
                if (optTipoProducto[1].Checked)//Tipo de Producto
                    pszTipoProducto = CRSParametros.ctePurchasingCard;
                if (optTipoProducto[2].Checked)
                    pszTipoProducto = CRSParametros.cteDistributionLine;


            if ((!chkCheckBox[0].Checked) && (!chkCheckBox[1].Checked) && (!chkCheckBox[2].Checked) )
            {
                pszGeneraSBF=(int)CRSParametros.ValoresSBF.cteNoGenerarSBFNoDerivado;
                /*chkCheckBox[0].CheckState = CheckState.Unchecked;
                chkCheckBox[1].CheckState = CheckState.Unchecked;
                chkCheckBox[2].CheckState = CheckState.Unchecked;*/
            }
            else if ((!chkCheckBox[0].Checked) && (chkCheckBox[1].Checked) && (!chkCheckBox[2].Checked))
            {
                pszGeneraSBF = (int)CRSParametros.ValoresSBF.cteNoGenerarSBFSiDerivado;
                /*chkCheckBox[0].CheckState = CheckState.Unchecked;
                chkCheckBox[1].CheckState = CheckState.Checked;
                chkCheckBox[2].CheckState = CheckState.Unchecked;*/
            }
            else if ((chkCheckBox[0].Checked) && (!chkCheckBox[1].Checked) && (!chkCheckBox[2].Checked))
            {
                pszGeneraSBF = (int)CRSParametros.ValoresSBF.cteSiGenerarSBFNoDerivado;
                /*chkCheckBox[0].CheckState = CheckState.Checked;
                chkCheckBox[1].CheckState = CheckState.Unchecked;
                chkCheckBox[2].CheckState = CheckState.Unchecked;*/
            }
            else if ((chkCheckBox[0].Checked) && (chkCheckBox[1].Checked) && (!chkCheckBox[2].Checked))
            {
                pszGeneraSBF = (int)CRSParametros.ValoresSBF.cteSiGenerarSBFSiDerivado;
                /*chkCheckBox[0].CheckState = CheckState.Checked;
                chkCheckBox[1].CheckState = CheckState.Checked;
                chkCheckBox[2].CheckState = CheckState.Unchecked;*/
            }
            else if ((chkCheckBox[0].Checked) && (!chkCheckBox[1].Checked) && (chkCheckBox[2].Checked))
            {
                pszGeneraSBF = (int)CRSParametros.ValoresSBF.cteSiGenerarSBFCycleDailyNoDerivado;
                /*chkCheckBox[0].CheckState = CheckState.Checked;
                chkCheckBox[1].CheckState = CheckState.Unchecked;
                chkCheckBox[2].CheckState = CheckState.Checked;*/
            }
            else if ((chkCheckBox[0].Checked) && (chkCheckBox[1].Checked) && (chkCheckBox[2].Checked))
            {
                pszGeneraSBF = (int)CRSParametros.ValoresSBF.cteSiGenerarSBFCycleDailySiDerivado;
                /*chkCheckBox[0].CheckState = CheckState.Checked;
                chkCheckBox[1].CheckState = CheckState.Checked;
                chkCheckBox[2].CheckState = CheckState.Checked;*/
            }
        



                /*int pszEstructuraGastos = 0;
                int pszMesFiscalGen = 0;
                int pszMontoPorciento = 0;
                double pszFacturacionMinima = 0;
                string slCuentaContableGen = String.Empty; */
                pszMontoPorciento = int.Parse(mskPorcientoMinimo1.defaultText);
                pszFacturacionMinima = Double.Parse(mskMontoMinimo.defaultText);
                pszCuentaContable = txtCuentaContable.Text.Trim();
                pszEstructuraGastos = cboEstructuraGastos.SelectedIndex;

                ilSkipPayment = (int)chkSkipPayment.CheckState;

                //Representante 1
                pszNombreR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[0].Text) + "'"; //Nombre de Representante 1
                pszPuestoR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[0].Text) + "'"; //Puesto
                pszTelR1 = Conversion.Val(ID_MEM_TEL_MKE[0].CtlText).ToString(); //Telefono
                pszExtR1 = Conversion.Val(ID_MEM_EXT_PIC[0].CtlText).ToString(); //Extension
                pszFaxR1 = Conversion.Val(ID_MEM_FAX_MKE[0].CtlText).ToString(); //Fax

                //Representante 2
                pszNombreR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[1].Text) + "'"; //Nombre de Representante 2
                pszPuestoR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[1].Text) + "'"; //Puesto
                pszTelR2 = Conversion.Val(ID_MEM_TEL_MKE[1].CtlText).ToString(); //Telefono
                pszExtR2 = Conversion.Val(ID_MEM_EXT_PIC[1].CtlText).ToString(); //Extension
                pszFaxR2 = Conversion.Val(ID_MEM_FAX_MKE[1].CtlText).ToString(); //Fax

                //Representante 3
                pszNombreR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[2].Text) + "'"; //Nombre de Representante 3
                pszPuestoR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[2].Text) + "'"; //Puesto
                pszTelR3 = Conversion.Val(ID_MEM_TEL_MKE[2].CtlText).ToString(); //Telefono
                pszExtR3 = Conversion.Val(ID_MEM_EXT_PIC[2].CtlText).ToString(); //Extension
                pszFaxR3 = Conversion.Val(ID_MEM_FAX_MKE[2].CtlText).ToString(); //Fax


                ilGenArchivoCDF = (int)ChkCDF.CheckState; //Variable para marcar la generacion de Archivo cdf

                pszFirma1 = "0x0";
                pszFirma2 = "0x0";
                pszFirma3 = "0x0";

                pszAtencionA = txtAtencionA.Text.Trim(); //FSWB NR 20070223 //FSWB 20070223 NR Se incluyen campos Atencion A y Persona
                pszPersona = StringsHelper.IntValue(Strings.Mid(ID_MEM_PERSONA.Text, 1, 1)); //FSWB NR 20070223 //FSWB NR 20070223

                if (Conversion.Val(pszNumGrupo) != 0)
                {
                    CORVAR.pszgblsql = "select ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_cred_tot,";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_acum_cred ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCCOR01 ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString() + " ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString() + " ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_num = " + pszNumGrupo;

                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            lGpoCredTot = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                            lGpoCredAcum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        //                    If bfncExcepcionCredito = True Then GoTo OmiteValidacionLimiteCredito1
                        if (Conversion.Val(ID_MEM_CRE_FTB.CtlText.ToString()) < Conversion.Val(ID_MEM_CRED_ACUM_FTB.CtlText.ToString()))
                        {
                           //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                           //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                           Interaction.MsgBox("El credito asignado es menor al credito acumulado", CORVB.MB_ICONEXCLAMATION, null);
                           Fichero(CORVB.NULL_INTEGER);
                           ID_MEM_CRE_FTB.Focus();                                
                           this.Cursor = Cursors.Default;
                           return;
                         }
                         if ((lGpoCredAcum - lLeeCreditoGlobal + pszCreditoGlobal) > lGpoCredTot)
                         {
                           this.Cursor = Cursors.Default;
                           lSumaGpoCredAcum = lGpoCredTot - lGpoCredAcum;
                           //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                           //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                           Interaction.MsgBox("Se ha sobrepasado el crédito del Corporativo. Crédito disponoble:" + Conversion.Str(lSumaGpoCredAcum), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                           Fichero(CORVB.NULL_INTEGER);
                           ID_MEM_CRE_FTB.Focus();
                                
                           return;
                        }
                        else
                        {

                                if (lGpoCredAcum == CORVB.NULL_INTEGER)
                                {
                                    lSumaGpoCredAcum = pszCreditoGlobal;
                                }
                                else
                                {
                                    lSumaGpoCredAcum = lGpoCredAcum - lLeeCreditoGlobal + pszCreditoGlobal;
                                }
                        }
                        
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                }                

                
                if ((Conversion.Val(pszNominaEjeBNX) != Conversion.Val(mlNominaEjeBNX.ToString())) ||
                    (pszNomEmpresa.Trim() != ("'" + msNomEmpresa.Trim() + "'")) ||
                    (Conversion.Val(pszCartera) != Conversion.Val(mdCartera.ToString())) ||
                    (pszAccionista.Trim() != ("'" + msAccionista.Trim() + "'")) ||
                    (Conversion.Val(pszSector) != Conversion.Val((miSector + 1).ToString())) ||
                    //(Conversion.Val(pszCreditoGlobal.ToString()) != Conversion.Val(mlCreditoGlobal.ToString())) ||
                    ( pszFecVenCredito.Trim() != msFecVenc.Trim()) ||
                    (Conversion.Val(pszCpFis) != Conversion.Val(mlCpFis.ToString())) ||
                     (pszCalleFis.Trim() != ("'" + msCalleFis.Trim() + "'")) ||
                        (pszColoniaFis.Trim() != ("'" + msColoniaFis.Trim() + "'")) ||
                        (pszCiudadFis.Trim() != ("'" + msCiudadFis.Trim() + "'")) ||
                        (pszPoblacionFis.Trim() != ("'" + msPoblacionFis.Trim() + "'")) ||
                        (pszEstadoFis.Trim() != ("'" + msEstadoFis.Trim() + "'")) ||
                        (Conversion.Val(pszCpFis) != Conversion.Val(mlCpFis.ToString())) ||
                        (pszLada.Trim() != ("'" + msLada.Trim() + "'")) ||
                        (pszFaxLada.Trim() != ("'" + msFaxLada.Trim() + "'")) ||
                        (pszFax.Trim() != ("'" + msFax.Trim() + "'")) ||
                        (pszEmail.Trim() != ("'" + msEmail.Trim() + "'")) ||
                        (Conversion.Val(pszCtaCaptacion) != Conversion.Val(mdCtaCaptacion.ToString())) ||
                        (Conversion.Val(pszSucursal) != Conversion.Val(miSucursal.ToString())) ||
                        (pszNombreR1.Trim() != ("'" + msNombreR1.Trim() + "'")) ||
                        (pszPuestoR1.Trim() != ("'" + msPuestoR1.Trim() + "'")) ||
                        (Conversion.Val(pszTelR1) != Conversion.Val(msTelR1)) ||
                        (Conversion.Val(pszExtR1) != Conversion.Val(msExtR1)) ||
                        (Conversion.Val(pszFaxR1) != Conversion.Val(pszFaxR1)) ||
                        (pszNombreR2.Trim() != ("'" + msNombreR2.Trim() + "'")) ||
                        (pszPuestoR2.Trim() != ("'" + msPuestoR2.Trim() + "'")) ||
                        (Conversion.Val(pszTelR2) != Conversion.Val(msTelR2)) ||
                        (Conversion.Val(pszExtR2) != Conversion.Val(msExtR2)) ||
                        (Conversion.Val(pszFaxR2) != Conversion.Val(pszFaxR2)) ||
                        (pszNombreR3.Trim() != ("'" + msNombreR3.Trim() + "'")) ||
                        (pszPuestoR3.Trim() != ("'" + msPuestoR3.Trim() + "'")) ||
                        (Conversion.Val(pszTelR3) != Conversion.Val(msTelR3)) ||
                        (Conversion.Val(pszExtR3) != Conversion.Val(msExtR3)) ||
                        (Conversion.Val(pszFaxR3) != Conversion.Val(pszFaxR3)) ||
                        (pszTipoPago != ("'"+msTipoPagoGen+"'" )) ||
                        (pszTipoEnv != ("'" + msTipoEnv + "'")) ||
                        (pszTipoProducto != slTipoProductoGen) ||
                        (pszPlazoGracia != ilPlazoGraciaGen) ||
                        (pszPlazoNoCobro != ilPlazoNoCobroGen) ||
                        (pszMontoPorciento != ilMontoPorcientoGen) ||
                        ( pszFacturacionMinima != dlFacturacionMinimaGen ) ||
                        ( pszCuentaContable.Trim() != slCuentaContableGen.Trim() ) ||
                        (pszGeneraSBF != ilGeneraSBFgen ) ||
                        (ilGenArchivoCDF != ilEnvioCDF) ||
                        (pszAtencionA.Trim() != slAtencionA.Trim()) ||                        
                        (Conversion.Val(pszPersona.ToString()) != (Conversion.Val(ilPersona.ToString()))))
                    {
                        banderaCambiosLocales = 1;
                    }

                    /*inician los cambios que se envían al S111*/
                    if (ComparaDatosCambio())
                    {
                        this.Cursor = Cursors.Default;
                        objTransS111 = new N_ActualizaS111.ClsConectaS111();
                        //Define el objeto que se va a firmar al S111
                        //AIS-1146 NGONZALEZ
                    
                        try
                        {
                            frmLoginS53 frmFirma = new frmLoginS53();
                            var regreso = frmFirma.ShowDialog();


                            if (regreso.ToString() != "OK") 
                            //if (!objTransS111.FnPreguntaPwd())
                            {
                                if (EnCausaErrorFirma == TransS111.EnumEstadosFirma.EnSinRespuesta)
                                {
                                    MdlCambioMasivo.MsgInfo("No se encontro respuesta del S111");
                                }
                                this.Cursor = Cursors.Default;
                                objTransS111 = null;
                                return;
                            }
                            else
                            {
                                banderaCambiosS111 = 1;
                            }
                        }
                        catch
                        {
                            if (EnCausaErrorFirma == TransS111.EnumEstadosFirma.EnSinRespuesta)
                            {
                                MdlCambioMasivo.MsgInfo("No se encontro respuesta del S111");
                            }
                            this.Cursor = Cursors.Default;
                            objTransS111 = null;
                            return;


                        }
                    }/*fin de ComparaDatosCambio() pide firma al s041 para enviar cambios al S111*/
                    
                //Verifica si se modificó el límite de crédtio
                    if (mtcEjeEmpOriginal.lEjeLimiteCredito != Convert.ToDouble(MdlCambioMasivo.Nvl(ID_MEM_CRE_FTB.CtlText, 0)))
                    {
                        if (Double.Parse(pszCredAcum) <= pszCreditoGlobal)
                        {

                            if ((pszCreditoGlobal != mtcEjeEmpOriginal.lEjeLimiteCredito) && (mtcEjeEmpOriginal.sTipoFacturacion == CRSParametros.cteCorporativo))
                            {
                                llCredOriginal = mtcEjeEmpOriginal.lEjeLimiteCredito;
                                mtcEjeEmpOriginal.lEjeLimiteCredito = pszCreditoGlobal;
                                blActualizaCred = bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteCredito, mtcEjeEmpOriginal, objTransS111);
                                if (blActualizaCred)
                                {
                                    llCredOriginal = mtcEjeEmpOriginal.lEjeLimiteCredito;
                                }
                                else
                                {
                                    mtcEjeEmpOriginal.lEjeLimiteCredito = llCredOriginal;
                                    MessageBox.Show("No se puede realizar la actualizacion del limite de credito.", "Sistema S111",MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Cursor = Cursors.WaitCursor;
                                    return;
                                }
                            }
                            else
                            {
                                blActualizaCred = true;
                            }
                        }
                    }

                    if (blActualizaCred)
                    {
                        CORVAR.pszgblsql = "update MTCEMP01 set ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + "emp_cred_tot=" + Conversion.Str(pszCreditoGlobal);
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where ";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco= " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;
                        
                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            if (Conversion.Val(pszNumGrupo) != 0)
                            {
                              CORVAR.pszgblsql = "UPDATE MTCCOR01 set gpo_acum_cred = (select sum(emp_cred_tot) from MTCEMP01 ";
                              CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo + ")";
                              CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco =" + pszBanco + " and   gpo_num = " + pszNumGrupo;

                              if (CORPROC2.Modifica_Registro() != 0)
                              {
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                MessageBox.Show("Se actualiza LIMITE DE CREDITO en forma exitosa", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 //MessageBox.Show("Se actualizó el LIMITE DE CREDITO en forma exitosa.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                              }
                              else
                              {
                                 MessageBox.Show("No se pudo actualizar el LIMITE DE CREDITO en MTCCOR01 avise a Ingenieria.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                              }
                            }
                            else
                            {
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                MessageBox.Show("Se actualiza LIMITE DE CREDITO en forma exitosa", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                    }
                    else
                    {
                         MessageBox.Show("No se pudo actualizar el LIMITE DE CREDITO en MTCEMP01 avise a Ingenieria", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                         //Interaction.MsgBox("Los cambios locales en el C430 de la empresa " + ID_MEM_NLG_EB.Text.Trim() + " NO se pudieron realizar", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                         //Interaction.MsgBox("El cambio de LIMITE de CREDITO  NO se pudo realizar en el C430.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);

                    }
                    
                }    

                //CAMBIO DE NOMBRE DE LA EMPRESA, por ahora se queda comentado
                //porque el campo en la pantalla de empresa está deshabilitado, hay que verificar si funciona, en caso de tener que descomentar.

                //if (Seguridad.fncsSustituir(pszNomCorto, "'", "").Trim().ToUpper() != mtcEjeEmpOriginal.sEjeNomGrabado.Trim().ToUpper())
                //{
                //    if (bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteNombre, mtcEjeEmpOriginal, objTransS111))
                //    {
                //        MessageBox.Show("El nombre corto de la empresa ha sido actualizado en el S111.", "Mensaje S111", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        MessageBox.Show("No se puede realizar la actualización del nombre corto de la empresa." + "\r\n" + "debido a un problema de comunicaciones con el S111." + "\r\n" + "Intentelo más tarde.", Application.ProductName);
                //        return;
                //    }

                //    CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EMP + " set emp_nom_graba=" + pszNomCorto;
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " , emp_usu_cam = '" + CRSParametros.sgUserID + "' ";
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;

                //    if (CORPROC2.Modifica_Registro() != 0)
                //    {
                //        MdlCambioMasivo.MsgInfo("El nobre corto de la empresa ha sido actualizado en la Base de Datos.");
                //    }
                //    else
                //    {
                //        MdlCambioMasivo.MsgError("El nobre corto de la empresa no pudo ser actualizado en la Base de Datos.");
                //    }


                //    CORVAR.pszgblsql = "update " + CORBD.DB_SYB_EJE + " set eje_nom_gra=" + pszNomCorto;
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " , eje_usuario_cam = '" + CRSParametros.sgUserID + "' ";
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;
                //    CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_num = 0";

                //    if (CORPROC2.Modifica_Registro() == 0)
                //    {
                //        MdlCambioMasivo.MsgError("El nombre corto de la empresa no pudo ser actualizado en el ejecutivo 0.");
                //    }

                //}

                //*** Valores ***
                mdlParametros.tgCambioS111.MccL = Convert.ToInt32(Conversion.Val(mskMCC.CtlText));
                mdlParametros.tgCambioS111.SkipPaymentI = ilSkipPayment;

                //**Cambio de Skip Payment**
                if (ilSkipPaymentCambio != mdlParametros.tgCambioS111.SkipPaymentI)
                {
                    if (bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteSkip, mtcEjeEmpOriginal, objTransS111))
                    {
                        CORVAR.pszgblsql = "update MTCEMP01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_skip_payment = " + mdlParametros.tgCambioS111.SkipPaymentI.ToString() + ",";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";

                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;

                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            MessageBox.Show("El Skip Payment de la empresa ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El Skip Payment de la empresa no ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede realizar la actualización del Skip Payment de la empresa.", Application.ProductName);
                        return;
                    }
                }

                //Modificacion de tabla de bloqueo MCC
                //**Cambio de MCC**
                if (ilTablaMCCCambio != mdlParametros.tgCambioS111.MccL)
                {
                    if (bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteMcc, mtcEjeEmpOriginal, objTransS111))
                    {
                        CORVAR.pszgblsql = "update MTCEMP01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_tabla_mcc = " + mdlParametros.tgCambioS111.MccL.ToString() + ",";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;

                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            MessageBox.Show("El MCC de la empresa ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El MCC de la empresa no ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede realizar la actualización del MCC de la empresa.", Application.ProductName);
                        return;
                    }
                }

                // APQ 1-Jul-20101 Inicio - Cambio de Tipo de Bloqueo
                //**Cambio Tipo de Bloqueo**
                mdlParametros.tgCambioS111.BloqueoI = mdlParametros.igEmpTipoBloqueo;
                if (ilTipoBloqueoCambio != mdlParametros.tgCambioS111.BloqueoI)
                {
                    if (bfncEnviaCambioS111(CRSDialogo.TipoCambioS111.cteTipBloq, mtcEjeEmpOriginal, objTransS111))
                    {
                        CORVAR.pszgblsql = "update MTCEMP01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " set emp_tipo_bloqueo = " + mdlParametros.tgCambioS111.BloqueoI.ToString() + ",";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_usu_cam = '" + CRSParametros.sgUserID + "'";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString();
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;
                        if (CORPROC2.Modifica_Registro() != 0)
                        {
                            MessageBox.Show("El Tipo de Bloqueo de la empresa ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El Tipo de Bloqueo de la empresa no ha sido actualizado en la Base de Datos.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede realizar la actualización del Tipo de Bloqueo de la empresa.", Application.ProductName);
                        return;
                    }
                }
                // APQ 1-Jul-20101 Inicio - Cambio de Tipo de Bloqueo


                if (banderaCambiosLocales==1)
                {
                    CORVAR.pszgblsql = "update MTCEMP01";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " set ejx_numero = " + pszNominaEjeBNX;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom = " + pszNomEmpresa;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom_graba = " + pszNomCorto;
                    //pszgblsql = pszgblsql & ",emp_rfc=" & pszRFC
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_num_cartera = " + pszCartera;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_princ_acc = " + pszAccionista;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_sector = " + pszSector;
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ((blActualizaCred) ? ",emp_cred_tot=" + Conversion.Str(pszCreditoGlobal) : "");
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_acum_cred = " + pszCredAcum;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_calle = " + pszCalleFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_col = " + pszColoniaFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_ciu = " + pszCiudadFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_pob = " + pszPoblacionFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_edo = " + pszEstadoFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fiscal_cp = " + pszCpFis;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fec_venc_cred = " + pszFecVenCred;
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_telefono = " + pszTelefono;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tel_lada = " + pszLada;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax = " + pszFax;
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_param_modem = '" + pszTonoPul + "'";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_vel_transmis = " + Conversion.Val(iVelTrns).ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_email = " + pszEmail;
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_internet = " + pszInternet;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_cta_capt = " + pszCtaCaptacion;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_sucur = " + pszSucursal;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_pago = " + pszTipoPago;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_envio = " + pszTipoEnv;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom_r1 = " + pszNombreR1;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_pues_r1 = " + pszPuestoR1;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tel_r1 = '" + pszTelR1 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_ext_r1 = '" + pszExtR1 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax_r1 = '" + pszFaxR1 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom_r2 = " + pszNombreR2;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_pues_r2 = " + pszPuestoR2;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tel_r2 = '" + pszTelR2 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_ext_r2 = '" + pszExtR2 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax_r2 = '" + pszFaxR2 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_nom_r3 = " + pszNombreR3;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_pues_r3 = " + pszPuestoR3;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tel_r3 = '" + pszTelR3 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_ext_r3 = '" + pszExtR3 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax_r3 = '" + pszFaxR3 + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fax_lada = " + pszFaxLada;
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_extension = " + pszTelExt;
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_dia_corte = " + ilDiaCorte.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_plazo_gracia = " + pszPlazoGracia.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_plazo_no_cob = " + pszPlazoNoCobro.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_gen_SBF = " + ilGeneraSBF.ToString();
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_fac = '" + slTipoFactura + "'";
                    //CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_esquema_pago = '" + slEsquemaPago + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_esquema_pago = " + pszTipoPago ;
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_producto = '" + pszTipoProducto + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_estruct_gastos = " + llEstructuraGastos.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_mes_fiscal  = " + ilMesFiscal.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_usu_cam = '" + slUsuarioCambio + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_fech_cam = convert(int,convert(char(20), getdate(),112))";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_hora_cam = (convert(int,datepart(hh,getdate())) * 100) + (convert(int, datepart(mi,getdate())))";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_lim_dis_efec = " + ilMontoPorciento.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_min_factura = " + dlFacturacionMinima.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_cta_contable = '" + slCuentaContable + "'";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_gen_CDF= " + ((int)ilGenArchivoCDF).ToString() + "";

                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_atn_a = '" + pszAtencionA + "'"; //FSWB NR 20070223
                    CORVAR.pszgblsql = CORVAR.pszgblsql + ",emp_tipo_persona= " + pszPersona.ToString() + ""; //FSWB NR 20070223

                    CORVAR.pszgblsql = CORVAR.pszgblsql + " where ";
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco= " + mdlParametros.gprdProducto.BancoL.ToString();
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszNumEmpresa;

                    //this.Cursor = Cursors.Default;

                    if (CORPROC2.Modifica_Registro() != 0)
                    {
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                        //FSWB NR 20070323 Se envia mensaje de actualizacion
                        MessageBox.Show("Se actualizan datos LOCALES en forma exitosa", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        //this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Los cambios locales en el C430 de la empresa " + ID_MEM_NLG_EB.Text.Trim() + " NO se pudieron realizar", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    //this.Close();
                }/*termina de realizar cambios locales de la empresa*/

                if (CORVAR.bgblModFirma == -1)
                {
                    IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR1_IMM, "MTCEMP01", "emp_fir_r1", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
                    IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR2_IMM, "MTCEMP01", "emp_fir_r2", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
                    IMAGEN.GrabarImagen(CORREGFI.DefInstance.ID_FIR_FR3_IMM, "MTCEMP01", "emp_fir_r3", " eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + " AND emp_num = " + pszNumEmpresa);
                    MessageBox.Show("Termina proceso de grabar FIRMA de REPRESENTANTE", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);                        

                }

                
                if ((ID_MEM_DOM_EB[1].Text.Trim().ToUpper() == pszCNumAnt.Trim().ToUpper()) &&
                    (ID_MEM_COL_EB[1].Text.Trim().ToUpper() == pszColoniaAnt.Trim().ToUpper()) &&
                    (ID_MEM_CIU_EB[1].Text.Trim().ToUpper() == pszAntPobAnt.Trim().ToUpper()) &&
                    (ID_MEM_PDM_EB[1].Text.Trim().ToUpper() == pszCiudadAnt.Trim().ToUpper()) &&
                    (CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex].Trim().ToUpper() == pszEstadoAnt.Trim().ToUpper()) &&
                    (Conversion.Val(ID_MEM_CP_PIC[1].CtlText) == Conversion.Val(lCpAnt.ToString())) &&
                    ((ID_MEM_CON_TXT.Text != msTelefono.Trim()) ||
                    (ID_MEM_TEL_EXT_TXT.Text != msTelExt.Trim()) ||
                    mtcEjeEmpOriginal.sEjeRFC.Trim() != Strings.Replace(ID_MEM_RFC_MKE.CtlText, "-", "", 1, -1, CompareMethod.Binary).Trim()))
                {
                    banderaCambioDomicilio=1;
                    alcanceCambio = "I"; //sólo la cuenta papa
                }
                else if ((ID_MEM_DOM_EB[1].Text.Trim().ToUpper() != pszCNumAnt.Trim().ToUpper()) ||
                    (ID_MEM_COL_EB[1].Text.Trim().ToUpper() != pszColoniaAnt.Trim().ToUpper()) ||
                    (ID_MEM_CIU_EB[1].Text.Trim().ToUpper() != pszAntPobAnt.Trim().ToUpper()) ||
                    (ID_MEM_PDM_EB[1].Text.Trim().ToUpper() != pszCiudadAnt.Trim().ToUpper()) ||
                    (CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex].Trim().ToUpper() != pszEstadoAnt.Trim().ToUpper()) ||
                    (Conversion.Val(ID_MEM_CP_PIC[1].CtlText) != Conversion.Val(lCpAnt.ToString())) )
                {

                    banderaCambioDomicilio = 1;
                    if (pszTipoEnv=="I")
                    {
                        alcanceCambio = "I";
                    }else
                    {
                        alcanceCambio = "E";
                    }
                }

                if (banderaCambioDomicilio==1)
                {
                    if (!InsertaTablaCambios(ref pszNumEmpresa, ref pszBanco, ref alcanceCambio, ref pszNomEmp))
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("No se pudo insertar datos en la tabla de cambios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (bHayReg)
                    {
                        if (RealizaCambiosMasivosEmp(Int32.Parse(pszNumEmpresa), objTransS111))
                        {
                            return;
                        }
                    }
      
                    banderaCambiosS111 = 0;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                this.Close();
                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        
        }



        private bool bfncEnviaCambioS111(CRSDialogo.TipoCambioS111 ipTipoCambio, CRSDialogo.mtcEjecutivo dejpEjecutivo, N_ActualizaS111.ClsConectaS111 objTransS111)
        {
            //Objetivo: Envia la transacccion al S111 via el Comdrv32

            bool result = false;
            bool blCxnEstablecida = false;
            string slCadena = String.Empty;
            string slDialogo = String.Empty;
            string slCadenaAux = String.Empty;
            string slRespuestaS111 = String.Empty;
            int iPos = 0;
            string pszCaracter = String.Empty;
            string slMensajeS111 = String.Empty;
            int lLim_Cred = 0;
            int lLim_Cred_Dola = 0;
            string pszCadPaso = String.Empty;
            string pszExiste = String.Empty;
            int lID = 0;
            bool mbPrimTran = false;
            string slRFC = String.Empty;

            bool blContinue = false;

            string slRespuesta = String.Empty;
            string slBloque = String.Empty;
            string slCausaError = String.Empty;

            int ilcont = 0;
            int ilLongitudMsg = 0;
            int ilResultado = 0;
            TransS111.EnumRespTransaccion enEstadoTransS111 = (TransS111.EnumRespTransaccion)0;

            try
            {

                result = false;
                lLim_Cred_Dola = 0;
                lLim_Cred = 0;

                mbPrimTran = false;
                dejpEjecutivo.sEjeCuentaBanamex = Seguridad.fncsSustituir(dejpEjecutivo.sEjeCuentaBanamex, " ", "");
                mdlParametros.tgCambioS111.NumCuentaS = dejpEjecutivo.sEjeCuentaBanamex;
                switch (ipTipoCambio)
                {
                    case CRSDialogo.TipoCambioS111.cteNombre:
                        dejpEjecutivo.sEjeNomGrabado = ID_MEM_NCT_EB.Text;
                        objTransS111.StrIdTransaccion = CORCONST.MODIFICA_NOMBRE_EN_LINEA;
                        objTransS111.StrNoCuenta = dejpEjecutivo.sEjeCuentaBanamex;
                        objTransS111.StrParametrosAdicionales = Strings.Mid(dejpEjecutivo.sEjeNomGrabado.Trim(), 1, 24) + ",/";

                        //slDialogo = "D" & slCadena & Chr(3) 

                        slMensajeS111 = "Cambio de Nombre";
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Nombre";

                        break;
                    case CRSDialogo.TipoCambioS111.cteCredito:
                        objTransS111.StrIdTransaccion = CORCONST.MODIFICA_CREDITO_EN_EJE;
                        objTransS111.StrNoCuenta = dejpEjecutivo.sEjeCuentaBanamex;
                        objTransS111.StrParametrosAdicionales = Conversion.Str(dejpEjecutivo.lEjeLimiteCredito);
                        slMensajeS111 = "Cambio de línea de crédito";
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Límite de Crédito";

                        break;
                    case CRSDialogo.TipoCambioS111.cteDomicilio:

                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Dirección";

                        if (dejpEjecutivo.sEjeNomGrabado.Length < 26)
                        {
                            pszCadPaso = new String(' ', 26);
                            pszCadPaso = StringsHelper.MidAssignment(pszCadPaso, 1, ID_MEM_NCT_EB.Text);
                            dejpEjecutivo.sEjeNomGrabado = pszCadPaso;
                        }
                        else
                        {
                            dejpEjecutivo.sEjeNomGrabado = Strings.Mid(ID_MEM_NCT_EB.Text, 1, 26);
                        }

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

                        //UPGRADE_WARNING: (1041) Len has a new behavior. 
                        if (Marshal.SizeOf(dejpEjecutivo.iEjeZP) < 2)
                        {
                            dejpEjecutivo.iEjeZP = StringsHelper.IntValue(StringsHelper.Format(dejpEjecutivo.iEjeZP, "00"));
                        }
                        else
                        {
                            dejpEjecutivo.iEjeZP = StringsHelper.IntValue(Strings.Mid(dejpEjecutivo.iEjeZP.ToString(), 1, 2));
                        }

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

                        if (ID_MEM_CON_TXT.Text == CORVB.NULL_STRING)
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

                        if (dejpEjecutivo.sEjeExtension.Length < 4 || (dejpEjecutivo.sEjeExtension) == CORVB.NULL_STRING)
                        {
                            dejpEjecutivo.sEjeExtension = StringsHelper.Format(dejpEjecutivo.sEjeExtension, "0000");
                        }
                        else
                        {
                            dejpEjecutivo.sEjeExtension = dejpEjecutivo.sEjeExtension;
                        }

                        if (dejpEjecutivo.sEjeSexo == CORVB.NULL_STRING)
                        {
                            dejpEjecutivo.sEjeSexo = new String(' ', 1);
                        }

                        slRFC = Seguridad.fncsSustituir(dejpEjecutivo.sEjeRFC.Trim(), "-", "");
                        if (slRFC.Trim() == "")
                        {
                            slRFC = new string(CORVB.NULL_STRING[0], 13);
                        }

                        objTransS111.StrIdTransaccion = CORCONST.MODIFICA_EMPRESA_MASIVOS;
                        objTransS111.StrNoCuenta = dejpEjecutivo.sEjeCuentaBanamex;


                        slCadena = "M" + Strings.Chr(28).ToString();
                        slCadena = slCadena + dejpEjecutivo.sEjeNomGrabado + Strings.Chr(28).ToString();
                        slCadena = slCadena + dejpEjecutivo.sEjeSexo + Strings.Chr(28).ToString();
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
                        slCadena = slCadena + slRFC + Strings.Chr(28).ToString();
                        slCadena = slCadena + " ";
                        objTransS111.StrParametrosAdicionales = slCadena;
                        slMensajeS111 = "Cambio de datos generales";

                        break;
                    case CRSDialogo.TipoCambioS111.cteSkip:
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Skip Payment";

                        mdlParametros.gdlgDialogo = new clsDialogo();
                        mdlParametros.gdlgDialogo.prGeneraDlg(null, clsDialogo.enuTipoDialogo.tCambioSkipEmpresaS111);
                        objTransS111.StrIdTransaccion = mdlParametros.gdlgDialogo.mIdTransaccionS;
                        objTransS111.StrNoCuenta = mdlParametros.gdlgDialogo.mNumCuentaS;
                        objTransS111.StrParametrosAdicionales = mdlParametros.gdlgDialogo.DialogoS;

                        slMensajeS111 = "Cambio de Skip Payment";

                        break;
                    // APQ 1-Jul-2010 Inicio - Cambio Tipo Bloqueo
                    case CRSDialogo.TipoCambioS111.cteTipBloq:
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de Tipo de Bloqueo";

                        mdlParametros.gdlgDialogo = new clsDialogo();
                        mdlParametros.gdlgDialogo.prGeneraDlg(null, clsDialogo.enuTipoDialogo.tCambioTipBloqEmpresaS111);
                        objTransS111.StrIdTransaccion = mdlParametros.gdlgDialogo.mIdTransaccionS;
                        objTransS111.StrNoCuenta = mdlParametros.gdlgDialogo.mNumCuentaS;
                        objTransS111.StrParametrosAdicionales = mdlParametros.gdlgDialogo.DialogoS;
                        slMensajeS111 = "Cambio de Tipo de Bloqueo";

                        break;
                    // APQ 1-Jul-2010 Fin - Cambio Tipo Bloqueo
                    case CRSDialogo.TipoCambioS111.cteMcc:
                        CORMDIBN.DefInstance.ID_COR_MSG_TXT.Text = "Realizando Cambio de MCC";

                        mdlParametros.gdlgDialogo = new clsDialogo();
                        mdlParametros.gdlgDialogo.prGeneraDlg(null, clsDialogo.enuTipoDialogo.tCambioMCCEmpresaS111);
                        objTransS111.StrIdTransaccion = mdlParametros.gdlgDialogo.mIdTransaccionS;
                        objTransS111.StrNoCuenta = mdlParametros.gdlgDialogo.mNumCuentaS;
                        objTransS111.StrParametrosAdicionales = mdlParametros.gdlgDialogo.DialogoS;
                        slMensajeS111 = "Cambio de MCC";

                        break;
                }
                //AIS-1119 NGONZALEZ
                String tempString = String.Empty;
                enEstadoTransS111 = (TransS111.EnumRespTransaccion)objTransS111.FnEnviarTransaccion( tempString,  tempString,  tempString);


                if (enEstadoTransS111 == TransS111.EnumRespTransaccion.EnRespTransaccionAceptada)
                {
                    MdlCambioMasivo.MsgInfo("Transacción aceptada en S111 en " + slMensajeS111);
                    result = true;
                }
                else if (enEstadoTransS111 == TransS111.EnumRespTransaccion.EnRespDesconocida && ipTipoCambio == CRSDialogo.TipoCambioS111.cteCredito)
                {
                    bool tempRefParam = true;
                    if (objTransS111.GetMsgerror(ref tempRefParam).IndexOf("LINEA DE CREDITO ACTUALIZADA A", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        MdlCambioMasivo.MsgInfo("La Linea de Credito fue aceptada en el S111");
                        result = true;
                    }
                    else
                    {
                        //AIS-1146 NGONZALEZ
                        bool tempBool = true;
                        MdlCambioMasivo.MsgInfo(objTransS111.GetMsgerror(ref tempBool));
                    }
                }
                else
                {
                    //AIS-1146 NGONZALEZ
                    bool tempBool = true;
                    MdlCambioMasivo.MsgError(objTransS111.GetMsgerror(ref tempBool));
                }
            }
            catch (Exception excep)
            {

                MdlCambioMasivo.MsgError(excep.Message);
                result = false;
            }

            return result;
        }


        public bool EnvAccConexion()
        {
            //Envia la clave de acceso al S111 por medio del condrive
            bool result = false;
            int liEdo = 0;
            int llNomina = 0;
            FixedLengthString fsNomina = new FixedLengthString(4);
            FixedLengthString lsPassword = new FixedLengthString(8);

            string pszRepS111 = String.Empty;
            string pszCadena = String.Empty;
            string pszResAcc = String.Empty;
            int iPos = 0;
            string pszMensaje = String.Empty;
            try
            {
                //   On Error Resume Next
                result = false;
                //**********************************************************************
                this.Cursor = Cursors.Default;
                //  CORMNEJE.Tag = "TAG_CAMBIOS_MASIVOS"
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORACCOM.DefInstance.ShowDialog();
                pszResAcc = CORACCOM.DefInstance.Tag.ToString();
                if (pszResAcc == "Cancelar")
                {
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No se capturaron datos.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    ConComDrive.Termina_Conexion();
                    CORACCOM.DefInstance.Close();
                    return true;
                }
                else
                {
                    //compacta nómina
                    fsNomina.Value = new string((char)0, 4);
                    llNomina = Int32.Parse(CORACCOM.DefInstance.ID_ACC_NOM_TXT.Text);
                    liEdo = API.Encryption.iCompactaNomina(llNomina, fsNomina.Value);
                    //compacta password
                    lsPassword.Value = new string((char)255, 8);
                    //AIS-1182 NGONZALEZ
                    liEdo = API.Encryption.iCompactaPasswd(CORACCOM.DefInstance.ID_ACC_CVE_TXT.Text, lsPassword.Value);
                    //arma la cadena para el envio
                    pszCadena = CORCONST.CVE_ACCESO_MODIFICA_S111;
                    pszCadena = pszCadena + fsNomina.Value + lsPassword.Value;
                    pszCadena = pszCadena + " " + "\r" + "\n";
                    //envia la cadena al S111
                    this.Cursor = Cursors.WaitCursor;
                    //····· Envía mensaje al S111, para verificar la clave de usuario y el numero de nómina
                    //      prLog Time & "CADENA EJECUTADA " & pszCadena
                    pszRepS111 = ConComDrive.Envia_Mensaje(ref pszCadena);
                    Application.DoEvents();
                    //      prLog Time & "MENSAJE DEL S111 " & pszRepS111
                    pszMensaje = CORPROC.Muestra_Mensaje(pszRepS111);
                    //      prLog Time & "pszMensaje = Muestra_Mensaje(pszRepS111)"
                    iPos = (pszRepS111.IndexOf("SEG:") + 1);
                    //      prLog Time & "iPos = InStr(pszRepS111, SEG:)"
                    if (iPos > CORVB.NULL_INTEGER)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(" " + pszMensaje, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        //        prLog Time & "MsgBox & pszMensaje, MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT"
                    }
                    else
                    {
                        MessageBox.Show(" " + pszMensaje + "\r" + " FIN DEL PROCESO.", CORSTR.STR_APP_TIT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = true; //no se pudo conectar, y envia que falló la conexión
                        ConComDrive.Termina_Conexion();
                        this.Cursor = Cursors.Default;
                    }
                    //····· Envía mensaje al S111, para verificar la clave de usuario y el numero de nómina
                    CORACCOM.DefInstance.Close();
                    Application.DoEvents();
                    //      prLog Time & "Unload CORACCOM"
                }
            }
            catch (Exception e)
            {


                CRSGeneral.prObtenError("EnvAccConexion", e);
            }

            return result;
        }



        //*************************************************************************************************
        //*                                                                                               *
        //*                                                                                               *
        //*                                                                                               *
        //*                                                                                               *
        //*     Parte proporcionada para la alta de empresas                                              *
        //*     Autor Marcos García Cruz                                                                  *
        //*                                                                                               *
        //*                                                                                               *
        //*                                                                                               *
        //*************************************************************************************************
        private void prAlta_Empresa()
        {

            bolfalfirma = "True";
            if (!pfValidaAltaEmpresa())
            {
                return;
            }

            int ilDigitoVer = 0;
            string slCuentaEjecutivo0 = String.Empty;
            CRSDialogo.mtcEjecutivo mtcEjecutivo0 = CRSDialogo.mtcEjecutivo.CreateInstance();

            int hBufEmpresa = 0;
            int hBufconsec = 0;
            int iTempErr = 0;
            string pszConcBco = String.Empty;
            int iResp = 0;
            int iIncremento = 0;

            //Ariadna
            //Dim bActualizarCM As Integer
            //*********

            int hTransaction = 0;
            string pszConsecEmp = String.Empty;

            //Campos del catalogo

            int lNumEmpresa = 0;
            string pszNumEmpresa = String.Empty;

            string pszCredAcum = String.Empty;
            int lGpoCredTot = 0;
            int lGpoCredAcum = 0;
            int lSumaGpoCredAcum = 0;
            string iVelTrns = String.Empty;
            string pszTonoPul = String.Empty;

            //Domicilio Fiscal

            //Domicilio de envío

            //Representantes



            string pszTipoPago = String.Empty;
            string pszTipoEnv = String.Empty;

            string pszComunicacion = String.Empty;
            string pszEnviaS111 = String.Empty;
            string pszRegresaS111 = String.Empty;
            string pszMensajeS111 = String.Empty;
            string pszMensajeS016 = String.Empty;
            string pszExiste = String.Empty;
            int lID = 0;

            int ilPersona = 0; //FSWB NR 20070223 Se incluyen campos Atencion A y Persona
            string slAtencionA = String.Empty; //FSWB NR 20070223

            //Dialogo
            CRSDialogo.DatosDialogo dlgAlta = CRSDialogo.DatosDialogo.CreateInstance();
            clsDatosEmpresa gdteEmpresa = null;
            string sEnviaRut = String.Empty;
            int ilBanderaAlta = 0;
            bool blActualizaCred = false;
            int llCredOriginal = 0;


            int ilcont = 0;


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                this.Cursor = Cursors.WaitCursor;

                bool bConComDrive = false;
                bool bFlagCambios = false;

                int ilIncrReenvio = 1;

                this.Cursor = Cursors.WaitCursor;
                string pszBanco = CORVAR.igblBanco.ToString();
                string iNumGrupo = Conversion.Val(ID_MEM_TEX_PNL[0].Text.Substring(0, Math.Min(ID_MEM_TEX_PNL[0].Text.Length, 4))).ToString();
                string pszNumGrupo = iNumGrupo;

                string pszNomEmpresa = "'" + CORPROC.Valida_Comilla(ID_MEM_NLG_EB.Text.Trim()) + "'"; //Nombre de empresa
                string pszNomCorto = "'" + CORPROC.Valida_Comilla(ID_MEM_NCT_EB.Text) + "'"; // //Nombre corto de la empresa
                string pszNominaEjeBNX = Conversion.Val(ID_MEM_NOM_COB.Text).ToString(); //Nómina del ejecutivo Banamex
                string pszRFC = Seguridad.fncsSustituir(ID_MEM_RFC_MKE.CtlText, "-", "");
                pszRFC = "'" + CORPROC.Valida_Comilla(pszRFC) + "'"; //RFC
                string pszCartera = Conversion.Val(ID_MEM_CAR_PIC.CtlText).ToString(); //No de cartera
                string pszAccionista = "'" + CORPROC.Valida_Comilla(ID_MEM_PAC_EB.Text) + "'"; //Principal accionista
                //string pszSector = Strings.Mid(ID_MEM_SEC_COB.Text, 2, 1); //Sector al que pertenece
                string pszSector = Strings.Mid(ID_MEM_SEC_COB.Text, 1, 2); //Sector al que pertenece
                int pszCreditoGlobal = Int32.Parse(ID_MEM_CRE_FTB.CtlText); //Crédito total asignado

                if (Conversion.Val(ID_MEM_CRED_ACUM_FTB.CtlText) == CORVB.NULL_INTEGER)
                {
                    pszCredAcum = "0";
                }
                else
                {
                    pszCredAcum = ID_MEM_CRED_ACUM_FTB.CtlText;
                }

                string pszFecVenCred = ID_MEM_FEC_VEN_DTB.CtlText; //Fecha de vencimiento de credito
                System.DateTime TempDate = DateTime.FromOADate(0);
                pszFecVenCred = "'" + Strings.Mid(pszFecVenCred, 1, 3) + CORPROC2.Obten_Mes_Ingles(StringsHelper.IntValue((DateTime.TryParse(pszFecVenCred, out TempDate)) ? TempDate.ToString("MM") : pszFecVenCred)) + Strings.Mid(pszFecVenCred, 6, 5) + "'"; //Domicilio Fiscal
                string pszCalleFis = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[0].Text) + "'"; //Domicilio Fiscal
                string pszColoniaFis = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[0].Text) + "'"; //Colonia
                string pszCiudadFis = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[0].Text) + "'"; //Ciudad
                string pszPoblacionFis = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[0].Text) + "'"; //Poblacion/delegacion
                string pszEstadoFis = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[0].SelectedIndex]) + "'"; //Estado
                string pszCpFis = Conversion.Val(ID_MEM_CP_PIC[0].CtlText).ToString(); //Cp

                //Telefonos
                string pszTelefono = "'" + Conversion.Val(ID_MEM_CON_TXT.Text).ToString() + "'"; //Telefono
                string pszTelExt = "'" + Conversion.Val(ID_MEM_TEL_EXT_TXT.Text).ToString() + "'"; //Extensión
                string pszLada = "'" + Conversion.Val(ID_MEM_LADA_TXT.Text).ToString() + "'"; //Lada
                string pszFax = "'" + Conversion.Val(ID_MEM_FAX_TXT.Text).ToString() + "'"; //Fax
                string pszFaxLada = "'" + Conversion.Val(ID_MEM_FAX_LADA_TXT.Text).ToString() + "'"; //Fax lada
                string pszEmail = "'" + CORPROC.Valida_Comilla(ID_MEM_EMAIL_TXT.Text) + "'"; //Email
                string pszInternet = "'" + CORPROC.Valida_Comilla(ID_MEM_INTER_TXT.Text) + "'"; //Internet

                //Domicilio de envío
                string pszCalleEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[1].Text) + "'"; //Domicilio de envio
                string pszColoniaEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[1].Text) + "'"; //Colonia
                string pszCiudadEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[1].Text) + "'"; //Ciudad
                string pszPoblacionEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[1].Text) + "'"; //Poblacion/delegacion
                string pszEstadoEnv = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex]) + "'"; //Estado
                string pszCpEnv = Conversion.Val(ID_MEM_CP_PIC[1].CtlText).ToString(); //Cp

                string pszSucursal = Conversion.Str(ID_MEM_SUC_ITB.CtlText); //Sucursal
                string pszCtaCaptacion = Conversion.Val(ID_MEM_NMC_FTB.CtlText).ToString(); //Cuenta de Captación

                //Tipo de pago
                if (ID_MEM_TPA_3OPB[0].Checked)
                { //Automático
                    pszTipoPago = "'" + CRSParametros.ctePagoAutomatico + "'";
                }
                else if (ID_MEM_TPA_3OPB[1].Checked)
                {  //Individual
                    pszTipoPago = "'" + CRSParametros.ctePagoIndividual + "'";
                }
                else if (ID_MEM_TPA_3OPB[2].Checked)
                {  //Libre
                    pszTipoPago = "'" + CRSParametros.ctePagoLibre + "'";
                }
                ilPlazoGracia = Convert.ToInt32(Conversion.Val(mskPeriodoGracia.defaultText)); //Periodo de gracias
                ilPlazoNoCobro = Convert.ToInt32(Conversion.Val(mskPerNoInteres.defaultText));
                //Envio de Edo. de Cuenta a
                if (ID_MEM_EEC_3OPB[0].Checked)
                { //Empresa
                    pszTipoEnv = "'" + CRSParametros.cteEmpresa + "'";
                }
                else
                {
                    //Individual
                    pszTipoEnv = "'" + CRSParametros.cteIndividual + "'";
                }

                //Tipo de Facturacion
                if (ID_MEM_TFA_3OPB[0].Checked)
                { //Corporativo
                    slTipoFactura = CRSParametros.cteCorporativo;
                }
                else
                {
                    //Individual
                    slTipoFactura = CRSParametros.cteIndividual;
                }

                //Tipo de Producto
                switch (optTipoProducto[0].Checked)
                {
                    case true:  //Business Card 
                        slTipoProducto = CRSParametros.cteBusinessCard;
                        break;
                    //AIS-66 NGONZALEZ
                    /*case true :  //Purchasing Card 
                        slTipoProducto = CRSParametros.ctePurchasingCard; 
                        break;
                    case true :  //Distribution Line 
                        slTipoProducto = CRSParametros.cteDistributionLine; 
                        break;*/
                }

                ilSkipPayment = (int)chkSkipPayment.CheckState;

                //Representante 1
                string pszNombreR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[0].Text) + "'"; //Nombre de Representante 1
                string pszPuestoR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[0].Text) + "'"; //Puesto
                string pszTelR1 = Conversion.Val(ID_MEM_TEL_MKE[0].CtlText).ToString(); //Telefono
                string pszExtR1 = Conversion.Val(ID_MEM_EXT_PIC[0].CtlText).ToString(); //Extension
                string pszFaxR1 = Conversion.Val(ID_MEM_FAX_MKE[0].CtlText).ToString(); //Fax

                //Representante 2
                string pszNombreR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[1].Text) + "'"; //Nombre de Representante 2
                string pszPuestoR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[1].Text) + "'"; //Puesto
                string pszTelR2 = Conversion.Val(ID_MEM_TEL_MKE[1].CtlText).ToString(); //Telefono
                string pszExtR2 = Conversion.Val(ID_MEM_EXT_PIC[1].CtlText).ToString(); //Extension
                string pszFaxR2 = Conversion.Val(ID_MEM_FAX_MKE[1].CtlText).ToString(); //Fax

                //Representante 3
                string pszNombreR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[2].Text) + "'"; //Nombre de Representante 3
                string pszPuestoR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[2].Text) + "'"; //Puesto
                string pszTelR3 = Conversion.Val(ID_MEM_TEL_MKE[2].CtlText).ToString(); //Telefono
                string pszExtR3 = Conversion.Val(ID_MEM_EXT_PIC[2].CtlText).ToString(); //Extension
                string pszFaxR3 = Conversion.Val(ID_MEM_FAX_MKE[2].CtlText).ToString(); //Fax
                CheckState ilGenArchivoCDF = ChkCDF.CheckState; //Variable para marcar la generacion de Archivo cdf

                pszFirma1 = "0x0";
                pszFirma2 = "0x0";
                pszFirma3 = "0x0";


                int pszPersona = StringsHelper.IntValue(Strings.Mid(ID_MEM_PERSONA.Text, 1, 1)); //FSWB NR 20070223 //FSWB NR 20070223 Se incluyen campos Atencion A y Persona
                string pszAtencionA = txtAtencionA.Text.Trim(); //FSWB NR 20070223 //FSWB NR 20070223

                //Si pertenece a un grupo valida que no se exceda el acumulado del grupo
                if (!fncValidaGrupoB(pszNumGrupo, ref lGpoCredTot, ref lGpoCredAcum, ref lSumaGpoCredAcum, pszCreditoGlobal))
                {
                    return;
                }

                MessageBox.Show("Necesita firmarse para dar el alta");

                frmLoginS53 frmFirma = new frmLoginS53();
                var regreso = frmFirma.ShowDialog();


                if (regreso.ToString() == "OK")
                {
                    #region Alta De Empresa


                    //Prepara el diálogo para dar de alta el ejecutivo 0 (CERO) en el S111
                    dlgAlta.iFechaAlta = Convert.ToInt32(Conversion.Val(DateTime.Today.ToString("yyyyMMdd")));
                    //gdteEmpresa.EmpFechaAltaL = Val(Format(Date, "yyyymmdd"))
                    //dlgAlta.sCuenta = slCuentaEjecutivo0
                    //gdteEmpresa.EmpCuentaS = slCuentaEjecutivo0
                    dlgAlta.iDiaCorte = Int32.Parse(mskDiaCorte.defaultText);
                    //gdteEmpresa.EmpDiaCorteI = mskDiaCorte

                    dlgAlta.sNombreGrabacion = Seguridad.fncsSustituir(pszNomCorto, "'", "").Trim();
                    //gdteEmpresa.EmpNomGrabaS = Trim(fncsSustituir(pszNomCorto, "'", ""))
                    dlgAlta.sApellidoPaterno = Strings.Mid(Seguridad.fncsSustituir(Seguridad.fncsSustituir(Seguridad.fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""), 1, 30);
                    //gdteEmpresa.EmpApellidoPaternoS = Mid(fncsSustituir(fncsSustituir(fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""), 1, 30)

                    dlgAlta.sApellidoMaterno = Strings.Mid(Seguridad.fncsSustituir(Seguridad.fncsSustituir(Seguridad.fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""), 31, 30);
                    //gdteEmpresa.EmpApellidoMaternoS = Mid(fncsSustituir(fncsSustituir(fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""), 31, 30)
                    dlgAlta.sSexo = "F";
                    //gdteEmpresa.EmpSexoS = "F"

                    //* INICIO: EISSA (MRG) 2005-08-30
                    //*: Código Nuevo
                    dlgAlta.iSucTransmisora = Int32.Parse(pszSucursal);
                    dlgAlta.iSucPromotora = Int32.Parse(pszSucursal);
                    //*: Código anterior
                    //        dlgAlta.iSucTransmisora = 137
                    //        'gdteEmpresa.EmpSucTransmisora = 137
                    //        dlgAlta.iSucPromotora = 137
                    //        'gdteEmpresa.EmpSucPromotora = 137
                    //* FIN: EISSA (MRG) 2005-08-30

                    if (slTipoFactura == CRSParametros.cteIndividual)
                    {
                        dlgAlta.lLimiteCredito = 0;
                        //gdteEmpresa.EmpLimDisEfecI = 0
                    }
                    else if (slTipoFactura == CRSParametros.cteCorporativo)
                    {
                        dlgAlta.lLimiteCredito = pszCreditoGlobal;
                        //gdteEmpresa.EmpLimDisEfecI = pszCreditoGlobal
                    }
                    dlgAlta.sDomicilio = Seguridad.fncsSustituir(pszCalleEnv, "'", "").Trim();
                    //gdteEmpresa.EmpDomEnvioDMC.DomicilioS = Trim(fncsSustituir(pszCalleEnv, "'", ""))
                    dlgAlta.sColonia = Seguridad.fncsSustituir(pszColoniaEnv, "'", "").Trim();
                    //gdteEmpresa.EmpDomEnvioDMC.ColoniaS = Trim(fncsSustituir(pszColoniaEnv, "'", ""))

                    dlgAlta.sPoblacion = Seguridad.fncsSustituir(pszPoblacionEnv, "'", "").Trim();
                    //gdteEmpresa.EmpDomEnvioDMC.PoblacionS = Trim(fncsSustituir(pszPoblacionEnv, "'", ""))
                    dlgAlta.sEstado = Seguridad.fncsSustituir(pszEstadoEnv, "'", "").Trim();
                    //gdteEmpresa.EmpDomEnvioDMC.EstadoEST.AbreviaturaS = Trim(fncsSustituir(pszEstadoEnv, "'", ""))

                    dlgAlta.iZonaPostal = 0;
                    //gdteEmpresa.EmpZonaPostalI = 0
                    dlgAlta.lCP = Int32.Parse(pszCpEnv);
                    //gdteEmpresa.EmpDomEnvioDMC.CPL = CLng(pszCpEnv)

                    dlgAlta.iASActi = 0;
                    //gdteEmpresa.EmpASActiI = 0
                    dlgAlta.lTelOficina = StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelefono, "'", "").Trim());
                    //gdteEmpresa.EmpTelefonoS = CLng(pszCpEnv)

                    dlgAlta.lTelParticular = StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelefono, "'", "").Trim());
                    //gdteEmpresa.EmpTelefonoS = CDbl(Trim(fncsSustituir(pszTelefono, "'", "")))
                    dlgAlta.lExtension = Convert.ToInt32(StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelExt, "'", "").Trim()));

                    dlgAlta.sRFC = Seguridad.fncsSustituir(pszRFC, "'", "").Trim();
                    dlgAlta.iGeneraPinPlastico = (int)CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN;

                    dlgAlta.sTipoCta = CRSParametros.cteEmpresa;
                    dlgAlta.iSkipPayment = ilSkipPayment;
                    //gdteEmpresa.EmpSkipPaymentI = ilSkipPayment
                    dlgAlta.iIdTablaMCC = ilTablaMCC;
                    //gdteEmpresa.EmpTablaMccL = ilTablaMCC
                    dlgAlta.sCuentaReferencia = StringsHelper.Format(pszSucursal, new string('0', 4)) + StringsHelper.Format(pszCtaCaptacion, new string('0', 12));
                    //gdteEmpresa.EmpSucEjeL = Format(pszSucursal, String(4, "0"))
                    //gdteEmpresa.EmpSucEjeL = Format(pszCtaCaptacion, String(12, "0"))

                    dlgAlta.sTipoFacturacion = slTipoFactura;
                    dlgAlta.sAtencionA = pszAtencionA; //FSWB NR 20070223
                    dlgAlta.iPersona = pszPersona; //FSWB NR 20070223

                    //gdteEmpresa.EmpTipoFacS = slTipoFactura
                    clsReenvioEmpresas lEmpReenvio = new clsReenvioEmpresas(); //clsReenvioTarjetahabientes //New clsReenvioTarjetahabientes
                    clsAltaEmpresa lAltaEmp = new clsAltaEmpresa();
                    //lAltaEmp.EmpgdteEmpresa = dlgAlta
                    lAltaEmp.pszBanco = pszBanco;
                    lAltaEmp.pszNumGrupo = pszNumGrupo;
                    lAltaEmp.pszNomEmpresa = pszNomEmpresa;
                    lAltaEmp.pszNomCorto = pszNomCorto;
                    lAltaEmp.pszRFC = pszRFC;
                    lAltaEmp.pszCartera = pszCartera;
                    lAltaEmp.pszSector = pszSector;
                    lAltaEmp.pszAccionista = pszAccionista;
                    lAltaEmp.pszSucursal = pszSucursal;
                    lAltaEmp.pszCreditoGlobal = pszCreditoGlobal;
                    lAltaEmp.pszTelefono = pszTelefono;
                    lAltaEmp.pszLada = pszLada;
                    lAltaEmp.pszFax = pszFax;
                    lAltaEmp.pszEmail = pszEmail;
                    lAltaEmp.pszInternet = pszInternet;
                    lAltaEmp.pszTonoPul = pszTonoPul;
                    lAltaEmp.pszFaxLada = pszFaxLada;
                    lAltaEmp.pszTelExt = pszTelExt;
                    lAltaEmp.pszCalleFis = pszCalleFis;
                    lAltaEmp.pszColoniaFis = pszColoniaFis;
                    lAltaEmp.pszCiudadFis = pszCiudadFis;
                    lAltaEmp.pszPoblacionFis = pszPoblacionFis;
                    lAltaEmp.pszEstadoFis = pszEstadoFis;
                    lAltaEmp.pszCpFis = pszCpFis;
                    lAltaEmp.pszCalleEnv = pszCalleEnv;
                    lAltaEmp.pszColoniaEnv = pszColoniaEnv;
                    lAltaEmp.pszCiudadEnv = pszCiudadEnv;
                    lAltaEmp.pszPoblacionEnv = pszPoblacionEnv;
                    lAltaEmp.pszEstadoEnv = pszEstadoEnv;
                    lAltaEmp.pszCpEnv = pszCpEnv;
                    lAltaEmp.pszTipoPago = pszTipoPago;
                    lAltaEmp.pszTipoEnv = pszTipoEnv;
                    lAltaEmp.pszCtaCaptacion = pszCtaCaptacion;
                    lAltaEmp.pszNominaEjeBNX = pszNominaEjeBNX;
                    lAltaEmp.pszFecVenCred = pszFecVenCred;
                    ilDiaCorte = Convert.ToInt32(Conversion.Val(mskDiaCorte.CtlText));
                    lAltaEmp.ilDiaCorte = ilDiaCorte;
                    lAltaEmp.ilPlazoGracia = ilPlazoGracia;
                    lAltaEmp.ilPlazoNoCobro = ilPlazoNoCobro;
                    lAltaEmp.slTipoFactura = slTipoFactura;
                    lAltaEmp.slEsquemaPago = slEsquemaPago;
                    lAltaEmp.slTipoProducto = slTipoProducto;
                    lAltaEmp.llEstructuraGastos = llEstructuraGastos;
                    lAltaEmp.ilMesFiscal = ilMesFiscal;
                    lAltaEmp.ilMontoPorciento = ilMontoPorciento;
                    lAltaEmp.dlFacturacionMinima = dlFacturacionMinima;
                    lAltaEmp.slCuentaContable = slCuentaContable;
                    lAltaEmp.ilSkipPayment = ilSkipPayment;
                    lAltaEmp.ilTablaMCCCambio = ilTablaMCCCambio;
                    lAltaEmp.ilTablaMCC = ilTablaMCC;
                    lAltaEmp.slUsuarioCambio = slUsuarioCambio;
                    lAltaEmp.msNombreR1 = pszNombreR1;
                    lAltaEmp.msPuestoR1 = pszPuestoR1;
                    lAltaEmp.msTelR1 = pszTelR1;
                    lAltaEmp.msExtR1 = pszExtR1;
                    lAltaEmp.msFaxR1 = pszFaxR1;
                    lAltaEmp.msNombreR2 = pszNombreR2;
                    lAltaEmp.msPuestoR2 = pszPuestoR2;
                    lAltaEmp.msTelR2 = pszTelR2;
                    lAltaEmp.msExtR2 = pszExtR2;
                    lAltaEmp.msFaxR2 = pszFaxR2;
                    lAltaEmp.msNombreR3 = pszNombreR3;
                    lAltaEmp.msPuestoR3 = pszPuestoR3;
                    lAltaEmp.msTelR3 = pszTelR3;
                    lAltaEmp.msExtR3 = pszExtR3;
                    lAltaEmp.msFaxR3 = pszFaxR3;
                    lAltaEmp.mskDiaCorte = Int32.Parse(mskDiaCorte.defaultText);
                    lAltaEmp.slNacionalidad = slNacionalidad;
                    lAltaEmp.slIndCtaControl = slIndCtaControl;
                    lAltaEmp.imEmpTipoBloqueo = mdlParametros.igEmpTipoBloqueo.ToString();
                    lAltaEmp.imPrefijo = CORVAR.igblPref;
                    lAltaEmp.imBanco = CORVAR.igblBanco;
                    lAltaEmp.ilGenArchivoCDF = ilGenArchivoCDF;
                    lAltaEmp.bmblModFirma = CORVAR.bgblModFirma != 0;
                    lAltaEmp.smblPathRepEmpresas = CORVAR.pszgblPathRepEmpresas;
                    lAltaEmp.ilPersona = pszPersona; //FSWB NR 20070228 Se agregan Atencion A y persona
                    lAltaEmp.slAtencionA = pszAtencionA; //FSWB NR 20070228


                    lAltaEmp.EmplcteCliente = lcteCliente;

                    CRSDialogo.gdteDatosEmpresa = dlgAlta;
                    lAltaEmp.EmpgdteEmpresa();
                    lEmpReenvio.mObjetoAlta = lAltaEmp;
                    //lEmpReenvio.EjeStatusS = "0";
                    lEmpReenvio.EjeStatusSComDrv = "0";

                    if (!lEmpReenvio.resultado)
                    {
                        Limpia_Controles();
                    }
                    if (mdlEmpresa.intReenvio == 1)
                    {
                        Limpia_Controles();
                        mdlEmpresa.intReenvio = 0;
                    }
                    lAltaEmp = null;
                    lEmpReenvio = null;

                    Fichero(CORVB.NULL_INTEGER);
                    CORREGFI.DefInstance.Close();
                   

                    #endregion
                }



            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        private bool fncValidaGrupoB(string pszNumGrupo, ref  int lGpoCredTot, ref  int lGpoCredAcum, ref  int lSumaGpoCredAcum, int pszCreditoGlobal)
        {
            bool result = false;
            if (Conversion.Val(pszNumGrupo) == 0)
            {
                return true;
            }
            result = true;
            CORVAR.pszgblsql = "select ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_cred_tot,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_acum_cred ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "from MTCCOR01 ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "where eje_prefijo = " + mdlParametros.gprdProducto.PrefijoL.ToString() + " ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_banco = " + mdlParametros.gprdProducto.BancoL.ToString() + " ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "and gpo_num = " + pszNumGrupo;

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    lGpoCredTot = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    lGpoCredAcum = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                //                     If bfncExcepcionCredito = False Then
                if ((lGpoCredAcum + pszCreditoGlobal) > lGpoCredTot)
                {
                    this.Cursor = Cursors.Default;
                    lSumaGpoCredAcum = lGpoCredTot - lGpoCredAcum;
                    Fichero(0);
                    ID_MEM_CRE_FTB.Focus();
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Se ha sobrepasado el crédito del Corporativo. Crédito disponible: " + StringsHelper.Format(lSumaGpoCredAcum, "###,###,###.00"), CORVB.MB_ICONEXCLAMATION, CORSTR.STR_APP_TIT);
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    return false;
                }
                //                     End If
                lSumaGpoCredAcum = lGpoCredAcum + pszCreditoGlobal;
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            return result;
        }
        private bool pfValidaAltaEmpresa()
        {
            bool result = false;
            this.Cursor = Cursors.WaitCursor;
            string pszConcBco = Existen_Blancos();
            result = true;
            if (pszConcBco.Length != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Por favor suministre información en el Campo: " + Strings.Chr(CORVB.KEY_RETURN).ToString() + pszConcBco.ToUpper(), (MsgBoxStyle)Int32.Parse(((int)CORVB.MB_ICONINFORMATION).ToString() + ((int)CORVB.MB_OK).ToString()), CORSTR.STR_APP_TIT);
                result = false;
                bolfalfirma = result.ToString();
                bAceptar = (false).ToString();
            }
            return result;
        }
        /* comenta Yuria 16/07/09 
        private void _optEmpresa_0_CheckedChanged(object sender, EventArgs e)
        {
            optEmpresa_ClickEvent(sender);
        }

        private void _optEmpresa_1_CheckedChanged(object sender, EventArgs e)
        {
            optEmpresa_ClickEvent(sender);
        }

        private void _optEmpresa_2_CheckedChanged(object sender, EventArgs e)
        {
            optEmpresa_ClickEvent(sender);
        }
        */
        private void _ID_MEM_TPA_3OPB_0_CheckedChanged(object sender, EventArgs e)
        {
            ID_MEM_TPA_3OPB_ClickEvent(sender);
        }

        private void _ID_MEM_TPA_3OPB_1_CheckedChanged(object sender, EventArgs e)
        {
            ID_MEM_TPA_3OPB_ClickEvent(sender);
        }

        private void _ID_MEM_TPA_3OPB_2_CheckedChanged(object sender, EventArgs e)
        {
            ID_MEM_TPA_3OPB_ClickEvent(sender);
        }

        private void _optTipoProducto_0_CheckedChanged(object sender, EventArgs e)
        {
            optTipoProducto_ClickEvent(sender);
        }

        private void _optTipoProducto_1_CheckedChanged(object sender, EventArgs e)
        {
            optTipoProducto_ClickEvent(sender);
        }

        private void _optTipoProducto_2_CheckedChanged(object sender, EventArgs e)
        {
            optTipoProducto_ClickEvent(sender);
        }

        private void _ID_MEM_TFA_3OPB_0_CheckedChanged(object sender, EventArgs e)
        {
            ID_MEM_TFA_3OPB_ClickEvent(sender);
        }

        private void _ID_MEM_TFA_3OPB_1_CheckedChanged(object sender, EventArgs e)
        {
            ID_MEM_TFA_3OPB_ClickEvent(sender);
        }

        private object control = null;

        //AIS-917 CHidalgo
        private void HandleSelection_Click(object sender, EventArgs e)
        {


            if (control == null || !control.Equals(sender))
            {
                control = sender;
                TextBox textbox = (TextBox)sender;
                textbox.SelectionStart = 0;
                textbox.SelectionLength = textbox.TextLength;
            }

        }

        //AIS-917 CHidalgo
        private void HandleSelection_MouseEnter(object sender, EventArgs e)
        {

            control = ActiveControl;

        }

        private void CORMNEMP_Shown(object sender, EventArgs e)
        {
            ID_MEM_TFA_3OPB_ClickEvent( CORMNEMP.DefInstance.ID_MEM_TFA_3OPB[1]);
        }
        private void prAlta_Empresa2()
        {

            bolfalfirma = "True";
            if (!pfValidaAltaEmpresa())
            {
                return;
            }

            int ilDigitoVer = 0;
            string slCuentaEjecutivo0 = String.Empty;
            CRSDialogo.mtcEjecutivo mtcEjecutivo0 = CRSDialogo.mtcEjecutivo.CreateInstance();

            int hBufEmpresa = 0;
            int hBufconsec = 0;
            int iTempErr = 0;
            string pszConcBco = String.Empty;
            int iResp = 0;
            int iIncremento = 0;

            //Ariadna
            //Dim bActualizarCM As Integer
            //*********

            int hTransaction = 0;
            string pszConsecEmp = String.Empty;

            //Campos del catalogo

            int lNumEmpresa = 0;
            string pszNumEmpresa = String.Empty;

            string pszCredAcum = String.Empty;
            int lGpoCredTot = 0;
            int lGpoCredAcum = 0;
            int lSumaGpoCredAcum = 0;
            string iVelTrns = String.Empty;
            string pszTonoPul = String.Empty;

            //Domicilio Fiscal

            //Domicilio de envío

            //Representantes



            string pszTipoPago = String.Empty;
            string pszTipoEnv = String.Empty;

            string pszComunicacion = String.Empty;
            string pszEnviaS111 = String.Empty;
            string pszRegresaS111 = String.Empty;
            string pszMensajeS111 = String.Empty;
            string pszMensajeS016 = String.Empty;
            string pszExiste = String.Empty;
            int lID = 0;

            int ilPersona = 0; //FSWB NR 20070223 Se incluyen campos Atencion A y Persona
            string slAtencionA = String.Empty; //FSWB NR 20070223

            //Dialogo
            CRSDialogo.DatosDialogo dlgAlta = CRSDialogo.DatosDialogo.CreateInstance();
            clsDatosEmpresa gdteEmpresa = null;
            string sEnviaRut = String.Empty;
            int ilBanderaAlta = 0;
            bool blActualizaCred = false;
            int llCredOriginal = 0;


            int ilcont = 0;


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                this.Cursor = Cursors.WaitCursor;

                bool bConComDrive = false;
                bool bFlagCambios = false;

                int ilIncrReenvio = 1;

                this.Cursor = Cursors.WaitCursor;
                string pszBanco = CORVAR.igblBanco.ToString();
                string iNumGrupo = Conversion.Val(ID_MEM_TEX_PNL[0].Text.Substring(0, Math.Min(ID_MEM_TEX_PNL[0].Text.Length, 4))).ToString();
                string pszNumGrupo = iNumGrupo;

                string pszNomEmpresa = "'" + CORPROC.Valida_Comilla(ID_MEM_NLG_EB.Text.Trim()) + "'"; //Nombre de empresa
                string pszNomCorto = "'" + CORPROC.Valida_Comilla(ID_MEM_NCT_EB.Text) + "'"; // //Nombre corto de la empresa
                string pszNominaEjeBNX = Conversion.Val(ID_MEM_NOM_COB.Text).ToString(); //Nómina del ejecutivo Banamex
                string pszRFC = Seguridad.fncsSustituir(ID_MEM_RFC_MKE.CtlText, "-", "");
                pszRFC = "'" + CORPROC.Valida_Comilla(pszRFC) + "'"; //RFC
                string pszCartera = Conversion.Val(ID_MEM_CAR_PIC.CtlText).ToString(); //No de cartera
                string pszAccionista = "'" + CORPROC.Valida_Comilla(ID_MEM_PAC_EB.Text) + "'"; //Principal accionista
                string pszSector = ID_MEM_SEC_COB.Text[1].ToString(); //Sector al que pertenece
                int pszCreditoGlobal = Int32.Parse(ID_MEM_CRE_FTB.CtlText); //Crédito total asignado

                if (Conversion.Val(ID_MEM_CRED_ACUM_FTB.CtlText) == CORVB.NULL_INTEGER)
                {
                    pszCredAcum = "0";
                }
                else
                {
                    pszCredAcum = ID_MEM_CRED_ACUM_FTB.CtlText;
                }

                string pszFecVenCred = ID_MEM_FEC_VEN_DTB.CtlText; //Fecha de vencimiento de credito
                System.DateTime TempDate = DateTime.FromOADate(0);
                pszFecVenCred = "'" + pszFecVenCred.Substring(0, 3) + CORPROC2.Obten_Mes_Ingles(StringsHelper.IntValue((DateTime.TryParse(pszFecVenCred, out TempDate)) ? TempDate.ToString("MM") : pszFecVenCred)) + pszFecVenCred.Substring(5, 5) + "'"; //Domicilio Fiscal
                string pszCalleFis = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[0].Text) + "'"; //Domicilio Fiscal
                string pszColoniaFis = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[0].Text) + "'"; //Colonia
                string pszCiudadFis = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[0].Text) + "'"; //Ciudad
                string pszPoblacionFis = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[0].Text) + "'"; //Poblacion/delegacion
                string pszEstadoFis = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[0].SelectedIndex]) + "'"; //Estado
                string pszCpFis = Conversion.Val(ID_MEM_CP_PIC[0].CtlText).ToString(); //Cp

                //Telefonos
                string pszTelefono = "'" + Conversion.Val(ID_MEM_CON_TXT.Text).ToString() + "'"; //Telefono
                string pszTelExt = "'" + Conversion.Val(ID_MEM_TEL_EXT_TXT.Text).ToString() + "'"; //Extensión
                string pszLada = "'" + Conversion.Val(ID_MEM_LADA_TXT.Text).ToString() + "'"; //Lada
                string pszFax = "'" + Conversion.Val(ID_MEM_FAX_TXT.Text).ToString() + "'"; //Fax
                string pszFaxLada = "'" + Conversion.Val(ID_MEM_FAX_LADA_TXT.Text).ToString() + "'"; //Fax lada
                string pszEmail = "'" + CORPROC.Valida_Comilla(ID_MEM_EMAIL_TXT.Text) + "'"; //Email
                string pszInternet = "'" + CORPROC.Valida_Comilla(ID_MEM_INTER_TXT.Text) + "'"; //Internet

                //Domicilio de envío
                string pszCalleEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_DOM_EB[1].Text) + "'"; //Domicilio de envio
                string pszColoniaEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_COL_EB[1].Text) + "'"; //Colonia
                string pszCiudadEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_CIU_EB[1].Text) + "'"; //Ciudad
                string pszPoblacionEnv = "'" + CORPROC.Valida_Comilla(ID_MEM_PDM_EB[1].Text) + "'"; //Poblacion/delegacion
                string pszEstadoEnv = "'" + CORPROC.Valida_Comilla(CRSGeneral.asgEstados[0, ID_MEM_EDO_EB[1].SelectedIndex]) + "'"; //Estado
                string pszCpEnv = Conversion.Val(ID_MEM_CP_PIC[1].CtlText).ToString(); //Cp

                string pszSucursal = Conversion.Str(ID_MEM_SUC_ITB.CtlText); //Sucursal
                string pszCtaCaptacion = Conversion.Val(ID_MEM_NMC_FTB.CtlText).ToString(); //Cuenta de Captación

                //Tipo de pago
                if (ID_MEM_TPA_3OPB[0].Checked)
                { //Automático
                    pszTipoPago = "'" + CRSParametros.ctePagoAutomatico + "'";
                }
                else if (ID_MEM_TPA_3OPB[1].Checked)
                {  //Individual
                    pszTipoPago = "'" + CRSParametros.ctePagoIndividual + "'";
                }
                else if (ID_MEM_TPA_3OPB[2].Checked)
                {  //Libre
                    pszTipoPago = "'" + CRSParametros.ctePagoLibre + "'";
                }
                ilPlazoGracia = Convert.ToInt32(Conversion.Val(mskPeriodoGracia.defaultText)); //Periodo de gracias
                ilPlazoNoCobro = Convert.ToInt32(Conversion.Val(mskPerNoInteres.defaultText));
                //Envio de Edo. de Cuenta a
                if (ID_MEM_EEC_3OPB[0].Checked)
                { //Empresa
                    pszTipoEnv = "'" + CRSParametros.cteEmpresa + "'";
                }
                else
                {
                    //Individual
                    pszTipoEnv = "'" + CRSParametros.cteIndividual + "'";
                }

                //Tipo de Facturacion
                if (ID_MEM_TFA_3OPB[0].Checked)
                { //Corporativo
                    slTipoFactura = CRSParametros.cteCorporativo;
                }
                else
                {
                    //Individual
                    slTipoFactura = CRSParametros.cteIndividual;
                }

                //Tipo de Producto
                switch (optTipoProducto[0].Checked)
                {
                    case true:  //Business Card 
                        slTipoProducto = CRSParametros.cteBusinessCard;
                        break;
                    //case true:  //Purchasing Card 
                    //    slTipoProducto = CRSParametros.ctePurchasingCard;
                    //    break;
                    //case true:  //Distribution Line 
                    //    slTipoProducto = CRSParametros.cteDistributionLine;
                    //    break;
                }

                ilSkipPayment = (int)chkSkipPayment.CheckState;

                //Representante 1
                string pszNombreR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[0].Text) + "'"; //Nombre de Representante 1
                string pszPuestoR1 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[0].Text) + "'"; //Puesto
                string pszTelR1 = Conversion.Val(ID_MEM_TEL_MKE[0].CtlText).ToString(); //Telefono
                string pszExtR1 = Conversion.Val(ID_MEM_EXT_PIC[0].CtlText).ToString(); //Extension
                string pszFaxR1 = Conversion.Val(ID_MEM_FAX_MKE[0].CtlText).ToString(); //Fax

                //Representante 2
                string pszNombreR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[1].Text) + "'"; //Nombre de Representante 2
                string pszPuestoR2 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[1].Text) + "'"; //Puesto
                string pszTelR2 = Conversion.Val(ID_MEM_TEL_MKE[1].CtlText).ToString(); //Telefono
                string pszExtR2 = Conversion.Val(ID_MEM_EXT_PIC[1].CtlText).ToString(); //Extension
                string pszFaxR2 = Conversion.Val(ID_MEM_FAX_MKE[1].CtlText).ToString(); //Fax

                //Representante 3
                string pszNombreR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_NOM_EB[2].Text) + "'"; //Nombre de Representante 3
                string pszPuestoR3 = "'" + CORPROC.Valida_Comilla(ID_MEM_PUE_EB[2].Text) + "'"; //Puesto
                string pszTelR3 = Conversion.Val(ID_MEM_TEL_MKE[2].CtlText).ToString(); //Telefono
                string pszExtR3 = Conversion.Val(ID_MEM_EXT_PIC[2].CtlText).ToString(); //Extension
                string pszFaxR3 = Conversion.Val(ID_MEM_FAX_MKE[2].CtlText).ToString(); //Fax
                CheckState ilGenArchivoCDF = ChkCDF.CheckState; //Variable para marcar la generacion de Archivo cdf

                pszFirma1 = "0x0";
                pszFirma2 = "0x0";
                pszFirma3 = "0x0";


                int pszPersona = StringsHelper.IntValue(ID_MEM_PERSONA.Text[0].ToString()); //FSWB NR 20070223 //FSWB NR 20070223 Se incluyen campos Atencion A y Persona
                string pszAtencionA = txtAtencionA.Text.Trim(); //FSWB NR 20070223 //FSWB NR 20070223

                //Si pertenece a un grupo valida que no se exceda el acumulado del grupo
                if (!fncValidaGrupoB(pszNumGrupo, ref lGpoCredTot, ref lGpoCredAcum, ref lSumaGpoCredAcum, pszCreditoGlobal))
                {
                    return;
                }

                //If Tag = TAG_ALTA Then
                //bConexion = false;
                //        ConexionRut.Termina_Conexion
                //        If ConexionRut.Inicia_Conexion = True Then
                //            bConexion = True
                //        Else
                //            MsgBox "No hay conexion al S111. Avise a sistemas.", MB_ICONSTOP, STR_APP_TIT
                //        End If

                //Obtiene el Consecutivo
                //        pszgblsql = "select con_emp from MTCCON01"
                //        pszgblsql = pszgblsql & " where con_pref = " & igblPref
                //        pszgblsql = pszgblsql & " and con_banco = " & igblBanco
                //        If Obtiene_Registros() Then
                //            While SqlNextRow(hgblConexion) <> NOMOREROWS
                //                lNumEmpresa = SqlData(hgblConexion, 1)
                //            Wend
                //        End If
                //        igblRetorna = SqlCancel(hgblConexion)
                //        If lNumEmpresa <= 0 Then
                //            MsgBox "Se ha generado un número de empresa no valida, por favor intentelo nuevamente.", vbInformation, Me.Caption
                //            Screen.MousePointer = vbDefault
                //            Exit Sub
                //        End If

                //***** JPU *****
                //Se le asignan los valores a las propiedades de la Clase Clientes
                //        lcteCliente.EmpresaL = Format(lNumEmpresa, sMascara(Empresa))
                //***** JPU *****

                //Alta del primer tarjetahabiente con el Número de Ejecutivo 0
                //slCuentaEjecutivo0 = Format(igblPref, "0000") & Format(igblBanco, "00") & Format(lNumEmpresa, sMascara(Empresa)) & Format(0, sMascara(Ejecutivo)) & "9"
                //ilDigitoVer = Calcula_digito_verif(slCuentaEjecutivo0)
                //slCuentaEjecutivo0 = slCuentaEjecutivo0 & ilDigitoVer

                //Prepara el diálogo para dar de alta el ejecutivo 0 (CERO) en el S111
                dlgAlta.iFechaAlta = Convert.ToInt32(Conversion.Val(DateTime.Today.ToString("yyyyMMdd")));
                //gdteEmpresa.EmpFechaAltaL = Val(Format(Date, "yyyymmdd"))
                //dlgAlta.sCuenta = slCuentaEjecutivo0
                //gdteEmpresa.EmpCuentaS = slCuentaEjecutivo0
                dlgAlta.iDiaCorte = Int32.Parse(mskDiaCorte.defaultText);
                //gdteEmpresa.EmpDiaCorteI = mskDiaCorte

                dlgAlta.sNombreGrabacion = Seguridad.fncsSustituir(pszNomCorto, "'", "").Trim();
                //gdteEmpresa.EmpNomGrabaS = Trim(fncsSustituir(pszNomCorto, "'", ""))
                dlgAlta.sApellidoPaterno = Microsoft.VisualBasic.Strings.Mid(Seguridad.fncsSustituir(Seguridad.fncsSustituir(Seguridad.fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""),1, 30);
                //gdteEmpresa.EmpApellidoPaternoS = Mid(fncsSustituir(fncsSustituir(fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""), 1, 30)

                dlgAlta.sApellidoMaterno = Microsoft.VisualBasic.Strings.Mid(Seguridad.fncsSustituir(Seguridad.fncsSustituir(Seguridad.fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""),31, 30);
                //gdteEmpresa.EmpApellidoMaternoS = Mid(fncsSustituir(fncsSustituir(fncsSustituir(pszNomEmpresa, ",", ""), ".", ""), "'", ""), 31, 30)
                dlgAlta.sSexo = "F";
                //gdteEmpresa.EmpSexoS = "F"

                //* INICIO: EISSA (MRG) 2005-08-30
                //*: Código Nuevo
                dlgAlta.iSucTransmisora = Int32.Parse(pszSucursal);
                dlgAlta.iSucPromotora = Int32.Parse(pszSucursal);
                //*: Código anterior
                //        dlgAlta.iSucTransmisora = 137
                //        'gdteEmpresa.EmpSucTransmisora = 137
                //        dlgAlta.iSucPromotora = 137
                //        'gdteEmpresa.EmpSucPromotora = 137
                //* FIN: EISSA (MRG) 2005-08-30

                if (slTipoFactura == CRSParametros.cteIndividual)
                {
                    dlgAlta.lLimiteCredito = 0;
                    //gdteEmpresa.EmpLimDisEfecI = 0
                }
                else if (slTipoFactura == CRSParametros.cteCorporativo)
                {
                    dlgAlta.lLimiteCredito = pszCreditoGlobal;
                    //gdteEmpresa.EmpLimDisEfecI = pszCreditoGlobal
                }
                dlgAlta.sDomicilio = Seguridad.fncsSustituir(pszCalleEnv, "'", "").Trim();
                //gdteEmpresa.EmpDomEnvioDMC.DomicilioS = Trim(fncsSustituir(pszCalleEnv, "'", ""))
                dlgAlta.sColonia = Seguridad.fncsSustituir(pszColoniaEnv, "'", "").Trim();
                //gdteEmpresa.EmpDomEnvioDMC.ColoniaS = Trim(fncsSustituir(pszColoniaEnv, "'", ""))

                dlgAlta.sPoblacion = Seguridad.fncsSustituir(pszPoblacionEnv, "'", "").Trim();
                //gdteEmpresa.EmpDomEnvioDMC.PoblacionS = Trim(fncsSustituir(pszPoblacionEnv, "'", ""))
                dlgAlta.sEstado = Seguridad.fncsSustituir(pszEstadoEnv, "'", "").Trim();
                //gdteEmpresa.EmpDomEnvioDMC.EstadoEST.AbreviaturaS = Trim(fncsSustituir(pszEstadoEnv, "'", ""))

                dlgAlta.iZonaPostal = 0;
                //gdteEmpresa.EmpZonaPostalI = 0
                dlgAlta.lCP = Int32.Parse(pszCpEnv);
                //gdteEmpresa.EmpDomEnvioDMC.CPL = CLng(pszCpEnv)

                dlgAlta.iASActi = 0;
                //gdteEmpresa.EmpASActiI = 0
                dlgAlta.lTelOficina = StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelefono, "'", "").Trim());
                //gdteEmpresa.EmpTelefonoS = CLng(pszCpEnv)

                dlgAlta.lTelParticular = StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelefono, "'", "").Trim());
                //gdteEmpresa.EmpTelefonoS = CDbl(Trim(fncsSustituir(pszTelefono, "'", "")))
                dlgAlta.lExtension = Convert.ToInt32(StringsHelper.DoubleValue(Seguridad.fncsSustituir(pszTelExt, "'", "").Trim()));

                dlgAlta.sRFC = Seguridad.fncsSustituir(pszRFC, "'", "").Trim();
                dlgAlta.iGeneraPinPlastico = (int)CRSParametros.GeneracionPlastico.cteNoPlasticoNoPIN;

                dlgAlta.sTipoCta = CRSParametros.cteEmpresa;
                dlgAlta.iSkipPayment = ilSkipPayment;
                //gdteEmpresa.EmpSkipPaymentI = ilSkipPayment
                dlgAlta.iIdTablaMCC = ilTablaMCC;
                //gdteEmpresa.EmpTablaMccL = ilTablaMCC
                dlgAlta.sCuentaReferencia = StringsHelper.Format(pszSucursal, new string('0', 4)) + StringsHelper.Format(pszCtaCaptacion, new string('0', 12));
                //gdteEmpresa.EmpSucEjeL = Format(pszSucursal, String(4, "0"))
                //gdteEmpresa.EmpSucEjeL = Format(pszCtaCaptacion, String(12, "0"))

                dlgAlta.sTipoFacturacion = slTipoFactura;
                dlgAlta.sAtencionA = pszAtencionA; //FSWB NR 20070223
                dlgAlta.iPersona = pszPersona; //FSWB NR 20070223

                //gdteEmpresa.EmpTipoFacS = slTipoFactura
                clsReenvioEmpresas lEmpReenvio = new clsReenvioEmpresas(); //clsReenvioTarjetahabientes //New clsReenvioTarjetahabientes
                clsAltaEmpresa lAltaEmp = new clsAltaEmpresa();
                //lAltaEmp.EmpgdteEmpresa = dlgAlta
                lAltaEmp.pszBanco = pszBanco;
                lAltaEmp.pszNumGrupo = pszNumGrupo;
                lAltaEmp.pszNomEmpresa = pszNomEmpresa;
                lAltaEmp.pszNomCorto = pszNomCorto;
                lAltaEmp.pszRFC = pszRFC;
                lAltaEmp.pszCartera = pszCartera;
                lAltaEmp.pszSector = pszSector;
                lAltaEmp.pszAccionista = pszAccionista;
                lAltaEmp.pszSucursal = pszSucursal;
                lAltaEmp.pszCreditoGlobal = pszCreditoGlobal;
                lAltaEmp.pszTelefono = pszTelefono;
                lAltaEmp.pszLada = pszLada;
                lAltaEmp.pszFax = pszFax;
                lAltaEmp.pszEmail = pszEmail;
                lAltaEmp.pszInternet = pszInternet;
                lAltaEmp.pszTonoPul = pszTonoPul;
                lAltaEmp.pszFaxLada = pszFaxLada;
                lAltaEmp.pszTelExt = pszTelExt;
                lAltaEmp.pszCalleFis = pszCalleFis;
                lAltaEmp.pszColoniaFis = pszColoniaFis;
                lAltaEmp.pszCiudadFis = pszCiudadFis;
                lAltaEmp.pszPoblacionFis = pszPoblacionFis;
                lAltaEmp.pszEstadoFis = pszEstadoFis;
                lAltaEmp.pszCpFis = pszCpFis;
                lAltaEmp.pszCalleEnv = pszCalleEnv;
                lAltaEmp.pszColoniaEnv = pszColoniaEnv;
                lAltaEmp.pszCiudadEnv = pszCiudadEnv;
                lAltaEmp.pszPoblacionEnv = pszPoblacionEnv;
                lAltaEmp.pszEstadoEnv = pszEstadoEnv;
                lAltaEmp.pszCpEnv = pszCpEnv;
                lAltaEmp.pszTipoPago = pszTipoPago;
                lAltaEmp.pszTipoEnv = pszTipoEnv;
                lAltaEmp.pszCtaCaptacion = pszCtaCaptacion;
                lAltaEmp.pszNominaEjeBNX = pszNominaEjeBNX;
                lAltaEmp.pszFecVenCred = pszFecVenCred;
                ilDiaCorte = Convert.ToInt32(Conversion.Val(mskDiaCorte.CtlText));
                lAltaEmp.ilDiaCorte = ilDiaCorte;
                lAltaEmp.ilPlazoGracia = ilPlazoGracia;
                lAltaEmp.ilPlazoNoCobro = ilPlazoNoCobro;
                lAltaEmp.slTipoFactura = slTipoFactura;
                lAltaEmp.slEsquemaPago = slEsquemaPago;
                lAltaEmp.slTipoProducto = slTipoProducto;
                lAltaEmp.llEstructuraGastos = llEstructuraGastos;
                lAltaEmp.ilMesFiscal = ilMesFiscal;
                lAltaEmp.ilMontoPorciento = ilMontoPorciento;
                lAltaEmp.dlFacturacionMinima = dlFacturacionMinima;
                lAltaEmp.slCuentaContable = slCuentaContable;
                lAltaEmp.ilSkipPayment = ilSkipPayment;
                lAltaEmp.ilTablaMCCCambio = ilTablaMCCCambio;
                lAltaEmp.ilTablaMCC = ilTablaMCC;
                lAltaEmp.slUsuarioCambio = slUsuarioCambio;
                lAltaEmp.msNombreR1 = pszNombreR1;
                lAltaEmp.msPuestoR1 = pszPuestoR1;
                lAltaEmp.msTelR1 = pszTelR1;
                lAltaEmp.msExtR1 = pszExtR1;
                lAltaEmp.msFaxR1 = pszFaxR1;
                lAltaEmp.msNombreR2 = pszNombreR2;
                lAltaEmp.msPuestoR2 = pszPuestoR2;
                lAltaEmp.msTelR2 = pszTelR2;
                lAltaEmp.msExtR2 = pszExtR2;
                lAltaEmp.msFaxR2 = pszFaxR2;
                lAltaEmp.msNombreR3 = pszNombreR3;
                lAltaEmp.msPuestoR3 = pszPuestoR3;
                lAltaEmp.msTelR3 = pszTelR3;
                lAltaEmp.msExtR3 = pszExtR3;
                lAltaEmp.msFaxR3 = pszFaxR3;
                lAltaEmp.mskDiaCorte = Int32.Parse(mskDiaCorte.defaultText);
                lAltaEmp.slNacionalidad = slNacionalidad;
                lAltaEmp.slIndCtaControl = slIndCtaControl;
                lAltaEmp.imEmpTipoBloqueo = mdlParametros.igEmpTipoBloqueo.ToString();
                lAltaEmp.imPrefijo = CORVAR.igblPref;
                lAltaEmp.imBanco = CORVAR.igblBanco;
                lAltaEmp.ilGenArchivoCDF = ilGenArchivoCDF;
                lAltaEmp.bmblModFirma = CORVAR.bgblModFirma != 0;
                lAltaEmp.smblPathRepEmpresas = CORVAR.pszgblPathRepEmpresas;
                lAltaEmp.ilPersona = pszPersona; //FSWB NR 20070228 Se agregan Atencion A y persona
                lAltaEmp.slAtencionA = pszAtencionA; //FSWB NR 20070228


                lAltaEmp.EmplcteCliente = lcteCliente;

                CRSDialogo.gdteDatosEmpresa = dlgAlta;
                lAltaEmp.EmpgdteEmpresa();
                lEmpReenvio.mObjetoAlta = lAltaEmp;
                //lEmpReenvio.EjeStatusS = "20";
                lEmpReenvio.EjeStatusSComDrv = "20";
                //If Not lEmpReenvio.resultado Then
                Limpia_Controles();
                //End If
                //If intReenvio = 1 Then
                //    Limpia_Controles
                //    intReenvio = 0
                //End If
                lAltaEmp = null;
                lEmpReenvio = null;

                Fichero(CORVB.NULL_INTEGER);
                CORREGFI.DefInstance.Close();
                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void Command1_Click(Object eventSender, EventArgs eventArgs)
        {
            prAlta_Empresa2();
        }

        private void _optEmpresa_0_Click(object sender, EventArgs e)
        {
            mdlParametros.igEmpTipoBloqueo = 0;
            mskMCC.CtlText = "0";
            mskMCC.Enabled = false;
        }

        private void _optEmpresa_1_Click(object sender, EventArgs e)
        {
            mdlParametros.igEmpTipoBloqueo = 1;
            mskMCC.Enabled = true;
        }

        private void _optEmpresa_2_Click(object sender, EventArgs e)
        {
            mdlParametros.igEmpTipoBloqueo = 2;
            mskMCC.Enabled = true;
        }

        private void _optEmpresa_0_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
