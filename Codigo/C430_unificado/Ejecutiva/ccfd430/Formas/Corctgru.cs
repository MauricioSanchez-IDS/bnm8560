using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORCTGRU
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       --------------------------------------------------------         **
        //**                                                                        **
        //**       Descripción: Carga los Grupos Corporativos existentes en         **
        //**                    Catálogo (MTCCOR01) y los pone a disposi  -         **
        //**                    ción para Altas, Bajas, Cambios y Consultas         **
        //**                                                                        **
        //**       Responsable: Hugo L. Morales Garcia                              **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 18/Marzo/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int iErr = 0; //Para Control local
        string pszSentencia = String.Empty;
        int iTop = 0;
        int iLeft = 0;
        int hConexion = 0; //La conexion a la base de datos
        string pszAccion = String.Empty;
        string pszMsg = String.Empty;
        string pszSQL = String.Empty;

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Carga los Grupos corporativos existentes en el      **
        //**                    Catálogo de Grupos (CMTCOR01) a un List Box         **
        //**                                                                        **
        //**       Declaración: Function Carga_Grupos()                             **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: El número de registros leídos                  **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr                                            **
        //**                                                                        **
        //**       Ultima modificacion: 030594                                      **
        //**                                                                        **
        //****************************************************************************
        private int Carga_Grupos()
        {

            int result = 0;
            int hBufGrupo = 0; //El apuntador a la sentencia SQL
            string pszNomGrupo = String.Empty; //El Grupo a obtener
            int iNumGrupo = 0; //El consecutivo del grupo
            int iTempErr = 0; //Control local
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****

            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            //ros  iCont = Cuenta_Registros
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_CGR_GRP_LB.Items.Clear();

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_CGR_GRP_LB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
                    iCont++;
                };
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            if (ID_CGR_GRP_LB.Items.Count > CORVB.NULL_INTEGER)
            {
                ID_CGR_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
            }

            result = iCont;

            this.Cursor = Cursors.Default;

            return result;
        }

        private void CORCTGRU_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                if (pszAccion == CORCONST.TAG_ALTA || pszAccion == CORCONST.TAG_BAJA)
                {
                    //Colocamos un grupo por default
                    if (ID_CGR_GRP_LB.Items.Count != 0)
                    {
                        ID_CGR_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                    }
                }

            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {


            iLeft = Convert.ToInt32((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2); //Posicionamos la forma
            iTop = Convert.ToInt32((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2); //

            this.SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
            this.Show();
            this.Refresh();

            this.Cursor = Cursors.WaitCursor;
            //
            //  If bgblAdmin Then
            //    ID_CGR_ALT_PB.Enabled = True
            //    ID_CGR_BAJ_PB.Enabled = True
            //    ID_CGR_CAM_PB.Enabled = True
            //    ID_CGR_CON_PB.Enabled = True
            //  Else
            //    'el indice es cero por ser el primes catalogo
            //    ID_CGR_ALT_PB.Enabled = OpcionesAcceso(1).bAltas
            //    ID_CGR_BAJ_PB.Enabled = OpcionesAcceso(1).bBajas
            //    ID_CGR_CAM_PB.Enabled = OpcionesAcceso(1).bCambios
            //    ID_CGR_CON_PB.Enabled = OpcionesAcceso(1).bConsultas
            //
            //  End If
            mdlParametros.gperPerfil.prHabilitaAcciones(CORCTGRU.DefInstance);
            CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORSTR.STR_LEE_BD;

            int iGrupos = Carga_Grupos(); //Cargamos los grupos

            if (iErr == CORCONST.OK)
            { //Existió un error
                if (iGrupos == CORVB.NULL_INTEGER)
                {
                    CORPROC.Alta_GrupoDefault(ref iErr, hConexion);
                }
            }
            if (iErr != CORCONST.OK)
            {
                //AIS-1182 NGONZALEZ
                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORVB.NULL_STRING;

            this.Cursor = Cursors.Default;
            CORMDIBN.DefInstance.Cursor = Cursors.Default;

        }

        public bool flag = false;

        private void ID_CGR_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CGR_GRP_LB.Text.Substring(0, Math.Min(ID_CGR_GRP_LB.Text.Length, 4))));

                CORMNGRU.DefInstance.Tag = CORCONST.TAG_ALTA; //Colocamos el indicador de Alta
                pszAccion = CORCONST.TAG_ALTA;
                SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(350)), Convert.ToInt32((float)VB6.TwipsToPixelsY(220)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORMNGRU.DefInstance.ShowDialog(); //En forma modal la forma de Altas
                SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                int iGrupos = Carga_Grupos(); //Refrescamos el List Box
                if (iErr != CORCONST.OK)
                {
                    this.Close();
                } //Existió un error
                //UPGRADE_WARNING: (2065) Form event CORCTGRU.Activated has a new behavior.
                CORCTGRU_Activated(this, new EventArgs());
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CGR_ALT_PB_Click)", e);
            }
        }

        private void ID_CGR_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            DialogResult iResp = (DialogResult)0; //La respuesta a la advertencia
            string pszItem = String.Empty; //El grupo a borrar
            int iRes = 0; //El resultado de la Operación
            int iGrupos = 0;

            int iIndice = ListBoxHelper.GetSelectedIndex(ID_CGR_GRP_LB); //El índice a borrar
            int iElementos = ID_CGR_GRP_LB.Items.Count; //Los elementos existentes
            CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CGR_GRP_LB.Text.Substring(0, Math.Min(ID_CGR_GRP_LB.Text.Length, 4))));

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (CORVAR.igblNumGrupo == CORVB.NULL_INTEGER)
                {
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("El grupo " + CORVAR.igblNumGrupo.ToString().Trim() + " No se dará de baja.", (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                }
                else
                {


                    if (iIndice >= CORVB.NULL_INTEGER)
                    {
                        pszItem = ID_CGR_GRP_LB.Text.Trim();
                        this.Cursor = Cursors.Default;

                        CORVAR.pszgblsql = "select gpo_num from " + CORBD.DB_SYB_COR + " where gpo_num=" + CORVAR.igblNumGrupo.ToString();
                        //***** INICIO CODIGO ANTERIOR FSWBMX *****
                        //    pszgblsql = pszgblsql + " and gpo_banco=" + Format$(igblBanco)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                        //***** INICIO CODIGO NUEVO FSWBMX *****
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX *****

                        if (CORPROC2.Existe_Dato() != 0)
                        {
                            //Confirma si realmente se desea dar de baja la división seleccionada
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            //UPGRADE_WARNING: (6021) Casting 'MsgBoxResult' to Enum may cause different behaviour.
                            iResp = (DialogResult)Interaction.MsgBox("Realmente desea dar de baja a : " + pszItem.Trim(), (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_OKCANCEL), CORSTR.STR_APP_TIT);
                            if (iResp == CORVB.IDOK)
                            {
                                iRes = CORPROC.Opera_BajaGrupo(CORVAR.igblNumGrupo, ref iErr);
                                if (iErr == CORCONST.OK)
                                { //No hubo error
                                    if (iRes != 0)
                                    { //Se  borró el elemento
                                        iGrupos = Carga_Grupos();
                                        if (ID_CGR_GRP_LB.Items.Count != 0)
                                        {
                                            if (iIndice - 1 >= CORVB.NULL_INTEGER)
                                            {
                                                ID_CGR_GRP_LB.SelectedIndex = iIndice - 1;
                                            }
                                            else
                                            {
                                                ID_CGR_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Existen empresas de ese grupo
                                        this.Cursor = Cursors.Default;
                                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                        Interaction.MsgBox("El grupo " + pszItem.Trim() + " posee empresas en Catálogo. No se dará de baja el grupo.", (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                    }
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox("No se pudo dar de baja al grupo " + pszItem + Strings.Chr(CORVB.KEY_RETURN).ToString() + "posiblemente posee empresas en Catálogo", (MsgBoxStyle)(((int)CORVB.MB_ICONSTOP) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                }
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "El Grupo seleccionado ha sido borrado por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_CGR_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CGR_GRP_LB));
                            if (ID_CGR_GRP_LB.Items.Count != 0)
                            {
                                ID_CGR_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else if (ID_CGR_GRP_LB.Items.Count != 0)
                    {
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "Seleccione la Empresa a dar de baja";
                    }
                    else
                    {
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existe Empresas en catálogos";
                        ID_CGR_ALT_PB.Focus();
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CGR_BAJ_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_CGR_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iGrupos = 0;

            pszAccion = CORCONST.TAG_CAMBIO;
            try
            {
                if (ID_CGR_IRA_3CKB.Value)
                {
                    CORIRGRU.DefInstance.Tag = CORCONST.TAG_CATALOGO;
                    CORIRGRU.DefInstance.ShowDialog();
                }
                else
                {
                    if (ListBoxHelper.GetSelectedIndex(ID_CGR_GRP_LB) >= CORVB.NULL_INTEGER)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CGR_GRP_LB.Text.Substring(0, Math.Min(ID_CGR_GRP_LB.Text.Length, 4))));
                        CORVAR.pszgblsql = "select gpo_num from " + CORBD.DB_SYB_COR + " where gpo_num=" + CORVAR.igblNumGrupo.ToString();
                        //***** INICIO CODIGO ANTERIOR FSWBMX *****
                        //      pszgblsql = pszgblsql + " and gpo_banco=" + Format$(igblBanco)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                        //***** INICIO CODIGO NUEVO  FSWBMX *****
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo = " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX *****
                        if (CORPROC2.Existe_Dato() != 0)
                        {
                            //Asigna Propiedades a la forma de mantenimiento
                            CORMNGRU.DefInstance.Tag = CORCONST.TAG_CAMBIO; //El indicador de Cambios
                            SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(350)), Convert.ToInt32((float)VB6.TwipsToPixelsY(220)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            CORMNGRU.DefInstance.ShowDialog(); //La forma de Cambios en modal
                            SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                            //UPGRADE_WARNING: (2065) Form event CORCTGRU.Activated has a new behavior.
                            CORCTGRU_Activated(this, new EventArgs());
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "El Grupo seleccionado ha sido borrado por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_CGR_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CGR_GRP_LB));
                            if (ID_CGR_GRP_LB.Items.Count != 0)
                            {
                                ID_CGR_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else
                    {
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existe una Empresas seleccionada";
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CGR_CAM_PB_Click)", e);
            }

        }

        private void ID_CGR_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }

        private void ID_CGR_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            pszAccion = CORCONST.TAG_CONSULTA;
            try
            {
                if (ID_CGR_IRA_3CKB.Value)
                {
                    this.Cursor = Cursors.WaitCursor;
                    CORIRGRU.DefInstance.Tag = CORCONST.TAG_CATALOGO;
                    CORIRGRU.DefInstance.ShowDialog();
                }
                else
                {
                    if (ListBoxHelper.GetSelectedIndex(ID_CGR_GRP_LB) >= CORVB.NULL_INTEGER)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CGR_GRP_LB.Text.Substring(0, Math.Min(ID_CGR_GRP_LB.Text.Length, 4))));
                        CORVAR.pszgblsql = "select gpo_num from " + CORBD.DB_SYB_COR + " where gpo_num=" + CORVAR.igblNumGrupo.ToString();
                        //***** INICIO CODIGO ANTERIOR FSWBMX *****
                        //      pszgblsql = pszgblsql  + " and gpo_banco=" + Format$(igblBanco)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                        //***** INICIO CODIGO NUEVO FSWBMX *****
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX *****
                        if (CORPROC2.Existe_Dato() != 0)
                        {
                            CORMNGRU.DefInstance.Tag = CORCONST.TAG_CONSULTA; //El indicador de Consulta
                            SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(350)), Convert.ToInt32((float)VB6.TwipsToPixelsY(220)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            CORMNGRU.DefInstance.ShowDialog(); //En forma modal la forma de consultas
                            SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "El Grupo seleccionado ha sido borrado por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_CGR_GRP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CGR_GRP_LB));
                            if (ID_CGR_GRP_LB.Items.Count != 0)
                            {
                                ID_CGR_GRP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else
                    {
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existe una Empresas seleccionada";
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CGR_CON_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CGR_GRP_LB_DoubleClick(Object eventSender, EventArgs eventArgs)
        {

            ID_CGR_CON_PB_Click(ID_CGR_CON_PB, new EventArgs());

        }

        private void ID_CGR_PPL_PNL_MouseMoveEvent(Object eventSender, AxThreed.ISSPNCtrlEvents_MouseMoveEvent eventArgs)
        {

            CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORVB.NULL_STRING;

        }
        private void CORCTGRU_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}