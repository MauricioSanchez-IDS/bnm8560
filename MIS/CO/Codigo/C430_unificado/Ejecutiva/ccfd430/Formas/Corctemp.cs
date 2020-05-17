using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORCTEMP
        : System.Windows.Forms.Form
    {

        private void CORCTEMP_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripci�n: Carga las empresas que existen el Cat�logo -        **
        //**                    de Empresas (MTCEMP01) y los pone a disposi-        **
        //**                    sici�n para Altas, Bajas,Cambios y Consultas        **
        //**                                                                        **
        //**       Responsable: Hugo L. Morales Garcia                              **
        //**                                                                        **
        //**       Ultima Fecha de Modificaci�n: 27/Abril/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int iErr = 0; //Para Control local
        int hConexion = 0; //La conexion a la base de datos
        int hBufGrupos = 0; //Apunta al SQL de hGrupos
        string pszSentencia = String.Empty; //Las sentencias SQL
        int iTotalGrupos = 0; //El n�mero total de Grupos Corporativos
        int iGruposRestantes = 0;
        int iTop = 0;
        int iLeft = 0;

        const int INT_MAX_GRUPOS = 999;

        int hBufEmpresa = 0;
        int iTotalEmpresas = 0; //El n�mero total de Grupos Corporativos
        int iEmpresasRestantes = 0;
        string pszMsg = String.Empty;
        string pszSQL = String.Empty;

        const int INT_MAX_EMPRESAS = 999;
        private bool mbCancelado;

        public bool BusquedaCanceladaB
        {
            get
            {
                return mbCancelado;
            }
            set
            {
                mbCancelado = value;
            }
        }

        private void mprActivarBotones(bool abActivar)
        {
            ID_CEM_GRP_COB.Enabled = abActivar;
            ID_CEM_ALT_PB.Enabled = abActivar;
            ID_CEM_CAM_PB.Enabled = abActivar;
            ID_CEM_CON_PB.Enabled = abActivar;
            ID_CEM_CMAS_PB.Enabled = abActivar;
            cmdReenvios.Enabled = abActivar;
            cmdCancelaciones.Enabled = abActivar;
            ID_CEM_CER_PB.Enabled = abActivar;
            ID_CEM_BAJ_PB.Enabled = abActivar;
            ID_CEM_MAS_PB.Enabled = abActivar;
            ID_CEM_EMP_LB.Enabled = abActivar;
            ID_CEM_IRA_3CKB.Enabled = abActivar;
        }

        //****************************************************************************
        //**                                                                        **
        //**       Descripci�n: Carga los Grupos corporativos existentes en el      **
        //**                    Cat�logo de Grupos (CMTCOR01) a un Combo Box -      **
        //**                    y que posteriormente sirve para seleccionar  a      **
        //**                    las empresas del Grupo correspondiente              **
        //**                                                                        **
        //**       Declaraci�n: Function Carga_Grupos() as integer                  **
        //**                                                                        **
        //**       Paso de par�metros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso: El n�mero de registros le�dos                  **
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

            string pszNomGrupo = String.Empty; //El grupo a obtener
            int iNumGrupo = 0; //El consecutivo del grupo
            int iTempErr = 0; //Para control local
            int iCont = 0;

            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            //ros  iTotalGrupos = Cuenta_Registros
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_CEM_GRP_COB.Items.Clear();
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros And iCont < INT_MAX_GRUPOS
                    iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_CEM_GRP_COB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
                    iCont++;
                };
                //ros     iGruposRestantes = iGruposRestantes - iCont
                //Colocamos a un grupo por default
                if (ID_CEM_GRP_COB.Items.Count != 0)
                {
                    ID_CEM_GRP_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //ros  iGruposRestantes = iTotalGrupos - iCont
            //ros  Carga_Grupos = iTotalGrupos

            this.Cursor = Cursors.Default;

            return 0;
        }


        private void cmdReenvios_Click(Object eventSender, EventArgs eventArgs)
        {
            int iNumGrupo = 0;
            double dbNumericTemp = 0;
            if (Double.TryParse(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 4)), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp))
            {
                iNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 4))));
            }
            else
            {
                iNumGrupo = 0;
            }
            frmReenvioEmp tempLoadForm = frmReenvioEmp.DefInstance;
            frmReenvioEmp.DefInstance.igNumeroGrupo = iNumGrupo;
            frmReenvioEmp.DefInstance.Show();
        }
        public bool flag = false;
        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            int iResp = 0;
            int iGrupos = 0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                iLeft = Convert.ToInt32((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2);
                iTop = Convert.ToInt32((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(Height))) / 2);

                this.SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                this.Show();
                this.Refresh();

                this.Cursor = Cursors.WaitCursor;

                CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORSTR.STR_LEE_BD;

                iErr = CORCONST.OK;
                do
                {
                    iGrupos = Carga_Grupos();
                    if (iErr == CORCONST.OK)
                    {
                        if (ID_CEM_GRP_COB.Items.Count == CORVB.NULL_INTEGER)
                        {
                            CORPROC.Alta_GrupoDefault(ref iErr, hConexion);
                            if (iErr != 0)
                            {
                                //AIS-1182 NGONZALEZ
                                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                                flag = true;
                            }
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            iResp = (int)Interaction.MsgBox("No existen Grupos en cat�logo " + Strings.Chr(CORVB.KEY_RETURN).ToString() + "�Desea dar de Alta ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                            this.Cursor = Cursors.WaitCursor;
                            if (iResp == CORVB.IDYES)
                            {
                                CORMNGRU.DefInstance.Tag = "ALTA 1";
                                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                                CORMNGRU.DefInstance.ShowDialog();
                                iGrupos = Carga_Grupos();
                            }
                        }
                    }
                    else
                    {
                        //AIS-1182 NGONZALEZ
                        //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        flag = true;
                        break;
                    }
                }
                while ((((iResp == CORVB.IDYES) ? -1 : 0) | ID_CEM_GRP_COB.Items.Count | ((iErr != CORCONST.OK) ? -1 : 0)) == 0);
                if (iGrupos > INT_MAX_GRUPOS)
                {
                    //ros    ID_CEM_MASG_3PB.Enabled = True
                }

                //  If bgblAdmin Then
                //    ID_CEM_ALT_PB.Enabled = True
                //    ID_CEM_BAJ_PB.Enabled = True
                //    ID_CEM_CAM_PB.Enabled = True
                //    ID_CEM_CON_PB.Enabled = True
                //    ID_CEM_CMAS_PB.Enabled = True
                //    ID_CEM_MAS_PB.Enabled = True
                //  Else
                //    ID_CEM_ALT_PB.Enabled = OpcionesAcceso(2).bAltas
                //    ID_CEM_BAJ_PB.Enabled = OpcionesAcceso(2).bBajas
                //    ID_CEM_CAM_PB.Enabled = OpcionesAcceso(2).bCambios
                //    ID_CEM_CON_PB.Enabled = OpcionesAcceso(2).bConsultas
                //    ID_CEM_CMAS_PB.Enabled = True
                //    ID_CEM_MAS_PB.Enabled = True
                //  End If
                mdlParametros.gperPerfil.prHabilitaAcciones(CORCTEMP.DefInstance);
                CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORVB.NULL_STRING;

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_CEM_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;

            try
            {
                //EISSA 28.11.2001 Analiza el tope de la empresa para limitarlo en cuanto a la generacion de ejecutivos
                if (!bfncAnalizaEmpresa())
                {
                    this.Cursor = Cursors.Default;
                    return;
                }


                //EISSA 05-10-2001. Cambio para agregar longitud de n�mero de empresa.
                CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //El n�mero de la empresa
                CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 5)))); //El n�mero del Grupo
                CORVAR.pszgblNomGrupo = ID_CEM_GRP_COB.Text.Trim();
                CORMNEMP.DefInstance.Tag = CORCONST.TAG_ALTA; //El indicador de Alta fswbmx
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                CORMNEMP.DefInstance.ShowDialog();

                //***** JPU *****        Quitar lo comentado para utilizar lo nuevo
                //igNumGrupo = Val(Left$(ID_CEM_GRP_COB.Text, 5))
                //sgNomGrupo = Trim$(ID_CEM_GRP_COB)
                //lgNumEmpresa = Val(Left$(ID_CEM_EMP_LB.Text, Len(sMascara(EMPRESA))))
                //***** JPU *****

                //***** JPU *****
                //frmEmpresa.Tag = "Alta"
                //frmEmpresa.Show
                //***** JPU *****

                SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                int iEmpresas = Obten_Empresas(); //Actualizamos el ListBox

                if (iErr != CORCONST.OK)
                { //Existi� un error
                    //AIS-1182 NGONZALEZ
                    //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    flag = true;
                }

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEM_ALT_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CEM_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            DialogResult iResp = (DialogResult)0; //Respuesta a la advertencia
            int iRes = 0; //El resultado de la Operaci�n
            string pszItem = String.Empty; //la empresa a dar de baja
            int iEmpresas = 0;
            string pszEmpCred = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                //EISSA 05-10-2001. Cambio para agregar longitud de n�mero de empresa.
                CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
                CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 5)))); //El n�mero del Grupo

                int iIndice = ListBoxHelper.GetSelectedIndex(ID_CEM_EMP_LB); //El �ndice del elemento a borrar
                int iElementos = ID_CEM_EMP_LB.Items.Count; //Los elementos existentes
                if (iIndice >= CORVB.NULL_INTEGER)
                {
                    pszItem = ID_CEM_EMP_LB.Text;
                    this.Cursor = Cursors.Default;

                    //obtiene el credito asignado de la empresa
                    CORVAR.pszgblsql = "select emp_cred_tot from " + CORBD.DB_SYB_EMP + " where emp_num= " + CORVAR.lgblNumEmpresa.ToString();
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //pszgblsql = pszgblsql + " and gpo_num=" + Format$(igblNumGrupo) + " and gpo_banco=" + Format$(igblBanco)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num=" + CORVAR.igblNumGrupo.ToString() + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX *****
                    if (CORPROC2.Obtiene_Registros() != 0)
                    {
                        if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                        {
                            pszEmpCred = Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)).ToString();
                        }
                    }
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    CORVAR.pszgblsql = "select emp_num from " + CORBD.DB_SYB_EMP + " where emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                    //***** INICIO CODIGO ANTERIOR FSWBMX *****
                    //pszgblsql = pszgblsql + " and gpo_num=" + Format$(igblNumGrupo) + " and gpo_banco=" + Format$(igblBanco)
                    //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                    //***** INICIO CODIGO NUEVO FSWBMX *****
                    CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num=" + CORVAR.igblNumGrupo.ToString() + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                    //***** FIN DE CODIGO NUEVO FSWBMX *****

                    if (CORPROC2.Existe_Dato() != 0)
                    {
                        //Confirma si realmente se desea dar de baja la divisi�n seleccionada
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        //UPGRADE_WARNING: (6021) Casting 'MsgBoxResult' to Enum may cause different behaviour.
                        iResp = (DialogResult)Interaction.MsgBox("Realmente desea dar de baja a : " + pszItem.Trim(), (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_OKCANCEL), CORSTR.STR_APP_TIT);
                        this.Cursor = Cursors.WaitCursor;
                        if (iResp == CORVB.IDOK)
                        {
                            iRes = CORPROC.Opera_BajaEmpresa(CORVAR.lgblNumEmpresa, ref iErr);
                            if (iRes != 0)
                            {
                                //Resta el credito acumulado al grupo
                                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                                //pszgblsql = "update MTCCOR01 set gpo_acum_cred = (select sum(emp_cred_tot) from MTCEMP01  where gpo_num = " + Format$(igblNumGrupo) + " and gpo_banco = " + Format$(igblBanco) + ")"
                                //pszgblsql = pszgblsql + "where  gpo_num = " + Format$(igblNumGrupo) + " and gpo_banco = " + Format$(igblBanco)
                                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                                //***** INICIO CODIGO NUEVO FSWBMX *****
                                CORVAR.pszgblsql = "update MTCCOR01 set gpo_acum_cred = (select sum(emp_cred_tot) from MTCEMP01  where gpo_num = " + CORVAR.igblNumGrupo.ToString() + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + ")";
                                CORVAR.pszgblsql = CORVAR.pszgblsql + "where  gpo_num = " + CORVAR.igblNumGrupo.ToString() + " and eje_prefijo =" + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();
                                //***** FIN DE CODIGO NUEVO FSWBMX *****
                                if (CORPROC2.Modifica_Registro() != 0)
                                {
                                }
                                else
                                {
                                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                    Interaction.MsgBox((Double.Parse("No se actualizo el credito acumulado del grupo: ") + CORVAR.igblNumGrupo + Double.Parse("   Restando la cantidad de : ") + Double.Parse(pszEmpCred) + Double.Parse(" Por favor actualiselo ")).ToString(), (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                }
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                                iEmpresas = Obten_Empresas();
                                if (ID_CEM_EMP_LB.Items.Count != 0)
                                {
                                    if (iIndice == iElementos - 1)
                                    {
                                        ID_CEM_EMP_LB.SelectedIndex = iIndice - 1;
                                    }
                                    else
                                    {
                                        ID_CEM_EMP_LB.SelectedIndex = iIndice;
                                    }
                                }
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("No se pudo dar de baja a empresa " + pszItem + Strings.Chr(CORVB.KEY_RETURN).ToString() + " posiblemente posee Ejecutivos en Cat�logo", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        pszMsg = "La Empresa seleccionada ha sido borrada por otro Usuario";
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        ID_CEM_EMP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEM_EMP_LB));
                        if (ID_CEM_EMP_LB.Items.Count != 0)
                        {
                            ID_CEM_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                        }
                    }
                }
                else if (ID_CEM_EMP_LB.Items.Count != 0)
                {
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("Seleccione la Empresa a dar de baja", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                }
                else
                {
                    CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existen Empresas en Cat�logo";
                    ID_CEM_ALT_PB.Focus();
                }

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEM_BAJ_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CEM_CAM_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iEmpresas = 0;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (ID_CEM_IRA_3CKB.Value)
                {
                    this.Cursor = Cursors.Default;
                    CORIREMP.DefInstance.Tag = CORCONST.TAG_CATALOGO;
                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    CORIREMP.DefInstance.ShowDialog();
                }
                else
                {
                    if (ListBoxHelper.GetSelectedIndex(ID_CEM_EMP_LB) >= CORVB.NULL_INTEGER)
                    {
                        //EISSA 05-10-2001. Cambio para agregar longitud de n�mero de empresa.
                        CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //El n�mero de la empresa
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 5)))); //El n�mero del Grupo
                        CORVAR.pszgblNomGrupo = ID_CEM_GRP_COB.Text.Trim();

                        CORVAR.pszgblsql = "select emp_num from " + CORBD.DB_SYB_EMP + " where emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                        //***** INICIO CODIGO ANTERIOR FSWBMX *****'
                        //pszgblsql = pszgblsql + " and gpo_num=" + Format$(igblNumGrupo) + " and gpo_banco=" + Format$(igblBanco)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                        //***** INICIO CODIGO NUEVO FSWBMX *****
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num=" + CORVAR.igblNumGrupo.ToString() + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX *****

                        if (CORPROC2.Existe_Dato() != 0)
                        {
                            //Asigna Propiedades a la forma de mantenimiento
                            CORMNEMP.DefInstance.Tag = CORCONST.TAG_CAMBIO; //El indicador de Cambio
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            CORMNEMP.DefInstance.ShowDialog();
                            SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                            if (iErr != CORCONST.OK)
                            { //Existi� un error
                                //AIS-1182 NGONZALEZ
                                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                                flag = true;
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "La Empresa seleccionada ha sido borrada por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_CEM_EMP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEM_EMP_LB));
                            if (ID_CEM_EMP_LB.Items.Count != 0)
                            {
                                ID_CEM_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else if (ID_CEM_EMP_LB.Items.Count != 0)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Seleccione la Empresa para hacer los cambios correspondientes", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    else
                    {
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existen Empresas en Cat�logo";
                    }
                }

            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEM_CAM_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void ID_CEM_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }

        private void ID_CEM_CMAS_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;

            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
            CORCAMA.DefInstance.ShowDialog();

            this.Cursor = Cursors.Default;


        }

        private void ID_CEM_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ID_CEM_IRA_3CKB.Value)
                {
                    this.Cursor = Cursors.Default;
                    CORIREMP.DefInstance.Tag = CORCONST.TAG_CATALOGO;
                    //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                    CORIREMP.DefInstance.ShowDialog();
                }
                else
                {
                    if (ListBoxHelper.GetSelectedIndex(ID_CEM_EMP_LB) >= CORVB.NULL_INTEGER)
                    {
                        //EISSA 05-10-2001. Cambio para agregar longitud de n�mero de empresa.
                        CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //El n�mero de la empresa
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 5)))); //El n�mero del Grupo
                        CORVAR.pszgblNomGrupo = ID_CEM_GRP_COB.Text.Trim();

                        CORVAR.pszgblsql = "select emp_num from " + CORBD.DB_SYB_EMP + " where emp_num=" + CORVAR.lgblNumEmpresa.ToString();
                        //***** INICIO CODIGO ANTERIOR FSWBMX *****
                        //pszgblsql = pszgblsql + " and gpo_num=" + Format$(igblNumGrupo) + " and gpo_banco=" + Format$(igblBanco)
                        //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                        //***** INICIO CODIGO NUEVO FSWBMX *****
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_num=" + CORVAR.igblNumGrupo.ToString() + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                        //***** FIN DE CODIGO NUEVO FSWBMX *****

                        if (CORPROC2.Existe_Dato() != 0)
                        {
                            CORMNEMP.DefInstance.Tag = CORCONST.TAG_CONSULTA; //El indicador de Consulta
                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                            CORMNEMP.DefInstance.ShowDialog();
                            SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            pszMsg = "La Empresa seleccionada ha sido borrada por otro Usuario";
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(pszMsg, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_CEM_EMP_LB.Items.RemoveAt((short)ListBoxHelper.GetSelectedIndex(ID_CEM_EMP_LB));
                            if (ID_CEM_EMP_LB.Items.Count != 0)
                            {
                                ID_CEM_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                            }
                        }
                    }
                    else if (ID_CEM_EMP_LB.Items.Count != 0)
                    {
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox("Seleccione la Empresa a consultar", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    }
                    else
                    {
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existen Empresas en Cat�logo";
                    }
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEM_CON_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ID_CEM_EMP_LB_DoubleClick(Object eventSender, EventArgs eventArgs)
        {

            ID_CEM_CON_PB_Click(ID_CEM_CON_PB, new EventArgs());

        }

        private void ID_CEM_GRP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {


            int iEmpresas = Obten_Empresas(); //Obtiene las empresas del Grupo
            if (iErr != CORCONST.OK)
            {
                //AIS-1182 NGONZALEZ
                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

        }

        private void ID_CEM_MAS_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iTempErr = 0;
            int iNumGrupo = 0;
            string pszNomGrupo = String.Empty; //El grupo a obtener
            int iCont = 0;
            int iGrupos = 0;
            int iValor = 0;

            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;

            ID_CEM_EMP_LB.Items.Clear();
            try
            {
                if (iEmpresasRestantes != 0)
                {
                    iCont = CORVB.NULL_INTEGER;

                    while (!(VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS && iCont < INT_MAX_EMPRESAS))
                    {
                        iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_CEM_EMP_LB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
                        iCont++;
                    };
                    iEmpresasRestantes -= iCont;
                    //Colocamos a un grupo por default
                    if (ID_CEM_EMP_LB.Items.Count != 0)
                    {
                        ID_CEM_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                    }
                }
                else
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    iValor = Obten_Empresas();
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEM_MAS_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //UPGRADE_NOTE: (7001) The following declaration (ID_CEM_MASG_3PB_Click) seems to be dead code
        //private void  ID_CEM_MASG_3PB_Click()
        //{
        //
        //int iTempErr = 0;
        //int iNumGrupo = 0;
        //string pszNomGrupo = String.Empty; //El grupo a obtener
        //int iCont = 0;
        //int iGrupos = 0;
        //
        //this.Cursor = Cursors.WaitCursor;
        //iErr = CORCONST.OK;
        //
        //ID_CEM_GRP_COB.Items.Clear();
        //if (iGruposRestantes != 0)
        //{
        //iCont = CORVB.NULL_INTEGER;
        //ros    itempErr = qeFetchPrev(hBufGrupos)
        //
        //while(! (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.NOMOREROWS && iCont < INT_MAX_GRUPOS))
        //{
        //iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(hBufGrupos, 1)));
        //pszNomGrupo = VBSQL.SqlData(hBufGrupos, 2);
        //ID_CEM_GRP_COB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
        //iCont++;
        //};
        //iGruposRestantes -= iCont;
        //Colocamos a un grupo por default
        //if (ID_CEM_GRP_COB.Items.Count != 0)
        //{
        //ID_CEM_GRP_COB.SelectedIndex = CORVB.NULL_INTEGER;
        //}
        //} else
        //{
        //CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        //iGrupos = Carga_Grupos();
        //}
        //this.Cursor = Cursors.Default;
        //
        //}

        //****************************************************************************
        //**                                                                        **
        //**       Descripci�n: Carga las empresas de un determinado grupo   -      **
        //**                    Corporativo a un ListBox                            **
        //**                                                                        **
        //**       Declaraci�n: Funcion Obten_Empresas() as integer                 **
        //**                                                                        **
        //**       Paso de par�metros: Ninguno                                      **
        //**                                                                        **
        //**       Valor de Regreso:                                                **
        //**           True: Si existieron empresas                                 **
        //**           False: Si no los hubo                                        **
        //**                                                                        **
        //**       Variables globales que modifica :                                **
        //**           Al Proyecto :                                                **
        //**           A la forma : iErr                                            **
        //**                                                                        **
        //**       Ultima modificacion: 030594                                      **
        //**                                                                        **
        //****************************************************************************
        private int Obten_Empresas()
        {

            int result = 0;
            int iTempErr = 0; //Control local
            string pszEmpresa = String.Empty; //La empresa a obtener
            int iNumEmpresa = 0; //El consecutivo de la empresa
            int iCont = 0;
            string pszEstatus = String.Empty; //El estatus a obtener

            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;
            int iNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 4)))); //El grupo de quien se trata
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_banco=" + Format$(igblBanco) + " and gpo_num =" + Format$(iNumGrupo)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            //CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + iNumGrupo.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //ros  iTotalEmpresas = Cuenta_Registros

            //*** INI:OLV NOV0304 ***
            CORVAR.pszgblsql = "SELECT A.emp_num, A.emp_nom, CASE " +
            " WHEN B.ths_situacion_cta = ' ' THEN 'CTA. NORMAL ' " +
            " WHEN B.ths_situacion_cta = 'O' THEN 'SOBREGIRADA' " +
            " WHEN B.ths_situacion_cta = 'P' THEN 'PROB. COBRO ' " +
            " WHEN B.ths_situacion_cta = 'E' THEN 'CANC.C/SALD ' " +
            " WHEN B.ths_situacion_cta = 'C' THEN 'CANC.S/SALD ' " +
            " WHEN B.ths_situacion_cta = 'D' THEN 'ATRAZADA     ' " +
            " WHEN B.ths_situacion_cta = NULL THEN '- - - - - - - - - - - ' " +
            " END FROM " + CORBD.DB_SYB_EMP + " A, " + CORBD.DB_SYB_THS + " B " +
            " WHERE A.eje_prefijo *= B.eje_prefijo " +
            " AND   A.gpo_banco *= B.gpo_banco " +
            " AND   A.emp_num *= B.emp_num " +
            " AND   B.eje_num = 0" +
            " AND   A.eje_prefijo = " + CORVAR.igblPref.ToString() +
            " AND   A.gpo_banco = " + CORVAR.igblBanco.ToString() +
            " AND   A.gpo_num = " + iNumGrupo.ToString();
            //*** FIN:OLV NOV0304 ***

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_CEM_EMP_LB.Items.Clear();
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros And iCont < INT_MAX_EMPRESAS
                    iNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    pszEstatus = VBSQL.SqlData(CORVAR.hgblConexion, 3);
                    if (pszEstatus == "")
                    { pszEstatus = "- - - - - - - - - - - "; }
                    //EISSA 03-10-2001 Cambio para formatear n�mero de empresa.
                    ID_CEM_EMP_LB.Items.Add(StringsHelper.Format(iNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEstatus + "   " + pszEmpresa);
                    iCont++;
                };
                //ros    iEmpresasRestantes = iEmpresasRestantes - iCont
                if (ID_CEM_EMP_LB.Items.Count != 0)
                {
                    ID_CEM_EMP_LB.SelectedIndex = CORVB.NULL_INTEGER;
                    result = -1;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                //si no obtiene empresas limpia el control
                ID_CEM_EMP_LB.Items.Clear();
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            //ros  iEmpresasRestantes = iTotalEmpresas - iCont

            this.Cursor = Cursors.Default;

            return result;
        }

        public int Resta_CredAcum_Gpo(string pszEmpCred, string pszBanco)
        {

            int result = 0;
            result = 0;


            //  pszgblSql = "update MTCCOR01 set gpo_acum_cred = gpo_acum_cred -" + pszEmpCred + " where  "
            //  pszgblSql = pszgblSql + " gpo_num=" + Format$(igblNumGrupo) + " and gpo_banco=" + Format$(igblBanco)

            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "update MTCCOR01 set gpo_acum_cred = (select sum(emp_acum_cred)from MTCEMP01  where gpo_num = " + Format$(igblNumGrupo) + " and gpo_banco = " + Format$(igblBanco) + ")"
            //pszgblsql = pszgblsql + " gpo_num = " + Format$(igblNumGrupo) + " and gpo_banco = " + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****

            CORVAR.pszgblsql = "update MTCCOR01 set gpo_acum_cred = (select sum(emp_acum_cred)from MTCEMP01  where gpo_num = " + CORVAR.igblNumGrupo.ToString() + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString() + ")";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " gpo_num = " + CORVAR.igblNumGrupo.ToString() + " and eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco = " + CORVAR.igblBanco.ToString();


            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Modifica_Registro() != 0)
            {
                result = -1;
            }
            else
            {
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox((Double.Parse("No se actualizo el credito acumulado del grupo: ") + CORVAR.igblNumGrupo + Double.Parse("   Restando la cantidad de : ") + Double.Parse(pszEmpCred) + Double.Parse(" Por favor actualiselo ")).ToString(), (MsgBoxStyle)(((int)CORVB.MB_ICONINFORMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            return result;
        }


        public bool bfncAnalizaEmpresa()
        {
            bool result = false;
            int llConsecutivo = 0;
            string slMensaje = String.Empty;
            int llRetorma = 0;
            try
            {
                Formato.pszgblSql3 = "select";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " max(emp_num) + ";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " (select pgs_incremento";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " From MTCPGS01 ";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " Where pgs_rep_prefijo = " + CORVAR.igblPref.ToString();
                Formato.pszgblSql3 = Formato.pszgblSql3 + " and MTCPGS01.pgs_rep_banco = " + CORVAR.igblBanco.ToString() + ")";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " From MTCEMP01 ";
                Formato.pszgblSql3 = Formato.pszgblSql3 + " Where MTCEMP01.eje_prefijo = " + CORVAR.igblPref.ToString();
                Formato.pszgblSql3 = Formato.pszgblSql3 + " and MTCEMP01.gpo_banco  = " + CORVAR.igblBanco.ToString();

                if (Formato.ifncObtiene_Registros() != 0)
                {

                    while (VBSQL.SqlNextRow(Formato.hgblConexion3) != VBSQL.NOMOREROWS)
                    {
                        llConsecutivo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(Formato.hgblConexion3, 1)));
                        if (llConsecutivo > Formato.lfncTop(mdlParametros.gprdProducto.LongitudEmpresaI))
                        {
                            slMensaje = "No se puede crear la empresa siguiente, debido a que se excede el l�mite de empresas para este producto.";
                            slMensaje = slMensaje + "\r\n" + "Para generar m�s empresas es necesario cambiar de producto o generar uno nuevo.";
                            MessageBox.Show(slMensaje, "Alta de empresa para el producto " + CORVAR.igblPref.ToString() + " - " + CORVAR.igblBanco.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Cursor = Cursors.Default;
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    };
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(Formato.hgblConexion3);
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError("AnalizaEmpresa", e);
            }

            return result;
        }
        private void CORCTEMP_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void cmdCancelaciones_Click(object sender, EventArgs e)
        {
            clsCancelaciones cncCancelaciones = new clsCancelaciones();

            try
            {
                cncCancelaciones.Class_Initialize();
                if (ID_CEM_IRA_3CKB.Value)
                {
                    this.Cursor = Cursors.Default;
                    CORIREMP.DefInstance.BusquedaListaPadreB = true;
                    CORIREMP.DefInstance.ShowDialog();

                    if (this.BusquedaCanceladaB)
                    {
                        this.BusquedaCanceladaB = false;
                    }
                }

                if (MessageBox.Show("�Desea cancelar la cuenta de le empresa seleccionada?", CORSTR.STR_APP_TIT, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    cncCancelaciones.Class_Terminate();
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                mprActivarBotones(false);
                //frmCancLog.DefInstance.ShowDialog();
                frmCancLog.DefInstance.Show();
                frmCancLog.DefInstance.prLimpiarLog();

                CORVAR.pszgblsql = "SELECT (convert(char(4), isnull(TH.eje_prefijo, EJ.eje_prefijo)) + ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "convert(char(2), isnull(TH.gpo_banco, EJ.gpo_banco)) + ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', " + mdlParametros.gprdProducto.LongitudEmpresaI.ToString() +
                            " - char_length(ltrim(rtrim(str(isnull(TH.emp_num, EJ.emp_num)))))) + " +
                            "ltrim(rtrim(str(isnull(TH.emp_num, EJ.emp_num)))) + ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "replicate ('0', " + mdlParametros.gprdProducto.LongitudEjecutivoI.ToString() +
                            " - char_length(ltrim(rtrim(str(isnull(TH.eje_num, EJ.eje_num)))))) + " +
                            "ltrim(rtrim(str(isnull(TH.eje_num, EJ.eje_num)))) + ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(str(isnull(TH.eje_roll_over, EJ.eje_roll_over))) + ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "ltrim(str(isnull(TH.eje_digit, EJ.eje_digit)))) tmp_cuenta, eje_nombre ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCEJE01 EJ, MTCTHS01 TH ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE TH.eje_prefijo=*EJ.eje_prefijo AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.gpo_banco=*EJ.gpo_banco AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.emp_num=*EJ.emp_num AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.eje_num=*EJ.eje_num AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.eje_prefijo=" + mdlParametros.gprdProducto.PrefijoL.ToString() + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.gpo_banco=" + mdlParametros.gprdProducto.BancoL.ToString() + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.emp_num=" + Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Formato.sMascara(Formato.iTipo.Empresa).Length)) + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.eje_num=0";

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);

                cncCancelaciones.EjeTamI = mdlParametros.gprdProducto.LongitudEjecutivoI;

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        cncCancelaciones.CuentaS = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                        cncCancelaciones.CuentahabienteS = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    }
                }
                else
                {
                    MessageBox.Show("El n�mero de cuenta no existe en el cat�logo." + "\r\n" +
                            "D� aviso del problema a su administrador de redes.", Application.ProductName);
                    cncCancelaciones = null;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    mprActivarBotones(true);
                    this.Cursor = Cursors.Default;
                    return;
                }

                //'        SqlCancel hgblConexion

                CORVAR.pszgblsql = "SELECT COUNT(*) tmpNumCuentas ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "FROM MTCEJE01 EJ, MTCTHS01 TH ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "WHERE TH.eje_prefijo=*EJ.eje_prefijo AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.gpo_banco=*EJ.gpo_banco AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.emp_num=*EJ.emp_num AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.eje_num=*EJ.eje_num AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.eje_prefijo=" + mdlParametros.gprdProducto.PrefijoL + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.gpo_banco=" + mdlParametros.gprdProducto.BancoL + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.emp_num=" + Conversion.Val(ID_CEM_EMP_LB.Text.Substring(1, Formato.sMascara(Formato.iTipo.Empresa).Length)) + " AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "EJ.eje_num<>0 AND ";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "TH.ths_situacion_cta NOT IN('C', 'E')";

                CRSGeneral.prPreparaConsulta(ref CORVAR.hgblConexion);

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        //cncCancelaciones.NumCuentasHijasL = (int)MdlCambioMasivo.Nvl(VBSQL.SqlData(CORVAR.hgblConexion, 1), -1);
                        cncCancelaciones.NumCuentasHijasL = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    }
                }
                else
                {
                    MessageBox.Show("El n�mero de cuenta no existe en el cat�logo." + "\r\n" +
                            "D� aviso del problema a su administrador de redes.", Application.ProductName);
                    cncCancelaciones = null;
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    mprActivarBotones(true);
                    this.Cursor = Cursors.Default;
                    return;
                }

                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                if (!cncCancelaciones.fnLlenarEstadosB())
                {
                    MessageBox.Show("No fue posible acceder al cat�logo de situaciones de cuenta" + "\n\n" + cncCancelaciones.UltMsgS, Application.ProductName);
                    frmCancLog.DefInstance.prLog(cncCancelaciones.TransLogS);
                    cncCancelaciones = null;
                    mprActivarBotones(true);
                    this.Cursor = Cursors.Default;
                    return;
                }

                frmCancLog.DefInstance.prLog(cncCancelaciones.TransLogS);

                if (!cncCancelaciones.fnMkrCancelarCuentaB(clsCancelaciones.enmCancelacionTipos.CTP_CUENTA_PADRE))
                {
                    MessageBox.Show("No fue posible crear la solicitud de cancelaci�n de cuenta, reintente la operaci�n m�s tarde." +
                            "\r\n" + "Si el problema persiste comun�quese con su administrador de sistemas." + "\r\n" +
                            "\r\n" + cncCancelaciones.UltMsgS, Application.ProductName);
                    string vTransLogS = cncCancelaciones.TransLogS;
                    frmCancLog.DefInstance.prLog(vTransLogS);
                    cncCancelaciones = null;
                    mprActivarBotones(true);
                    this.Cursor = Cursors.Default;
                    return;
                }

                frmCancLog.DefInstance.prLog(cncCancelaciones.TransLogS);
                MessageBox.Show("La solicitud de baja de la cuenta " + cncCancelaciones.CuentaS + " se cre� con �xito." + "\r\n" +
                        "Revise que los datos sean correctos antes de enviar al checker." + "\r\n" +
                        "Usuario Maker: " + cncCancelaciones.MakerNombreS + " (" + cncCancelaciones.MakerNominaS + ").", Application.ProductName);
                cncCancelaciones = null;
                mprActivarBotones(true);
                this.Cursor = Cursors.Default;
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurri� el siguiente error en el proceso:" + "\r\n" + "N�mero: " + Information.Err().Number + "\r\n" +
                        "Descripcion: " + Information.Err().Description + "\r\n" + "Origen: " + Information.Err().Source + "\r\n" +
                        "M�dulo: CORCTEMP::cmdCancelaciones::Click()", Application.ProductName);
                cncCancelaciones = null;
                mprActivarBotones(true);
                this.Cursor = Cursors.Default;
                //'*: Fin: EISSA MRG 2004-12-20
                //'*: ********************************************************************************
            }

        }
    }
}