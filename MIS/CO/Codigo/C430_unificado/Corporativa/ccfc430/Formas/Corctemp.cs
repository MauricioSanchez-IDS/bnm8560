using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
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
        //**       Descripción: Carga las empresas que existen el Catálogo -        **
        //**                    de Empresas (MTCEMP01) y los pone a disposi-        **
        //**                    sición para Altas, Bajas,Cambios y Consultas        **
        //**                                                                        **
        //**       Responsable: Hugo L. Morales Garcia                              **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 27/Abril/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int iErr = 0; //Para Control local
        int hConexion = 0; //La conexion a la base de datos
        int hBufGrupos = 0; //Apunta al SQL de hGrupos
        string pszSentencia = String.Empty; //Las sentencias SQL
        int iTotalGrupos = 0; //El número total de Grupos Corporativos
        int iGruposRestantes = 0;
        int iTop = 0;
        int iLeft = 0;

        const int INT_MAX_GRUPOS = 999;

        int hBufEmpresa = 0;
        int iTotalEmpresas = 0; //El número total de Grupos Corporativos
        int iEmpresasRestantes = 0;
        string pszMsg = String.Empty;
        string pszSQL = String.Empty;

        const int INT_MAX_EMPRESAS = 999;

        //****************************************************************************
        //**                                                                        **
        //**       Descripción: Carga los Grupos corporativos existentes en el      **
        //**                    Catálogo de Grupos (CMTCOR01) a un Combo Box -      **
        //**                    y que posteriormente sirve para seleccionar  a      **
        //**                    las empresas del Grupo correspondiente              **
        //**                                                                        **
        //**       Declaración: Function Carga_Grupos() as integer                  **
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
                            iResp = (int)Interaction.MsgBox("No existen Grupos en catálogo " + Strings.Chr(CORVB.KEY_RETURN).ToString() + "¿Desea dar de Alta ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
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

            //EISSA 28.11.2001 Analiza el tope de la empresa para limitarlo en cuanto a la generacion de ejecutivos
            if (!bfncAnalizaEmpresa())
            {
                this.Cursor = Cursors.Default;
                return;
            }


            //EISSA 05-10-2001. Cambio para agregar longitud de número de empresa.
            CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //El número de la empresa
            CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 5)))); //El número del Grupo
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
            { //Existió un error
                //AIS-1182 NGONZALEZ
                //iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                flag = true;
            }

            this.Cursor = Cursors.Default;

        }

        private void ID_CEM_BAJ_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            DialogResult iResp = (DialogResult)0; //Respuesta a la advertencia
            int iRes = 0; //El resultado de la Operación
            string pszItem = String.Empty; //la empresa a dar de baja
            int iEmpresas = 0;
            string pszEmpCred = String.Empty;

            this.Cursor = Cursors.WaitCursor;
            //EISSA 05-10-2001. Cambio para agregar longitud de número de empresa.
            CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length))));
            CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 5)))); //El número del Grupo

            int iIndice = ListBoxHelper.GetSelectedIndex(ID_CEM_EMP_LB); //El índice del elemento a borrar
            int iElementos = ID_CEM_EMP_LB.Items.Count; //Los elementos existentes

            try
            {



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
                        //Confirma si realmente se desea dar de baja la división seleccionada
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
                                Interaction.MsgBox("No se pudo dar de baja a empresa " + pszItem + Strings.Chr(CORVB.KEY_RETURN).ToString() + " posiblemente posee Ejecutivos en Catálogo", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
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
                    CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existen Empresas en Catálogo";
                    ID_CEM_ALT_PB.Focus();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CEM_BAJ_PB_Click " + exc.Message, "Error Corctemp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        //EISSA 05-10-2001. Cambio para agregar longitud de número de empresa.
                        CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //El número de la empresa
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 5)))); //El número del Grupo
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
                            { //Existió un error
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
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existen Empresas en Catálogo";
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CEM_CAM_PB_Click " + exc.Message, "Error Corctemp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        //EISSA 05-10-2001. Cambio para agregar longitud de número de empresa.
                        CORVAR.lgblNumEmpresa = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, Formato.sMascara(Formato.iTipo.Empresa).Length)))); //El número de la empresa
                        CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 5)))); //El número del Grupo
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
                        CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = "No existen Empresas en Catálogo";
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_CEM_CON_PB_Click " + exc.Message, "Error Corctemp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Cursor = Cursors.Default;

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
        //**       Descripción: Carga las empresas de un determinado grupo   -      **
        //**                    Corporativo a un ListBox                            **
        //**                                                                        **
        //**       Declaración: Funcion Obten_Empresas() as integer                 **
        //**                                                                        **
        //**       Paso de parámetros: Ninguno                                      **
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

            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;
            int iNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 4)))); //El grupo de quien se trata
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_banco=" + Format$(igblBanco) + " and gpo_num =" + Format$(iNumGrupo)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + iNumGrupo.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            //ros  iTotalEmpresas = Cuenta_Registros

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_CEM_EMP_LB.Items.Clear();
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                { //ros And iCont < INT_MAX_EMPRESAS
                    iNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    //EISSA 03-10-2001 Cambio para formatear número de empresa.
                    ID_CEM_EMP_LB.Items.Add(StringsHelper.Format(iNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
                    iCont++;
                };

                CORVAR.pszgblsql = "select con_emp from " + CORBD.DB_SYB_CON + " where con_pref=" + CORVAR.igblPref.ToString() + " and con_banco=" + CORVAR.igblBanco.ToString();

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                    {
                        iNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        ID_CEE_SIG_EMP.Text = StringsHelper.Format(iNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
                    }
                }

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
                            slMensaje = "No se puede crear la empresa siguiente, debido a que se excede el límite de empresas para este producto.";
                            slMensaje = slMensaje + "\r\n" + "Para generar más empresas es necesario cambiar de producto o generar uno nuevo.";
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
    }
}