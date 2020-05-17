using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORRANG2
        : System.Windows.Forms.Form
    {

        private void CORRANG2_Activated(Object eventSender, EventArgs eventArgs)
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

        const int INT_MAX_GRUPOS = 200;

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

            int result = 0;
            string pszNomGrupo = String.Empty; //El grupo a obtener
            int iNumGrupo = 0; //El consecutivo del grupo
            int iTempErr = 0; //Para control local
            int iCont = 0;

            iErr = CORCONST.OK;
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                //***** INICIO CODIGO ANTERIOR FSWBMX *****
                //  pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco=" + Format$(igblBanco)
                //***** FIN DE CODIGO ANTERIOR FSWBMX *****
                //***** INICIO CODIGO NUEVO FSWBMX *****
                CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
                //***** FIN DE CODIGO NUEVO FSWBMX *****
                //ros  igblErr = qeSetSelectOptions(hConexion, QE_UP_DOWN_DIR)

                //ros  iTotalGrupos = Cuenta_Registros

                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    ID_CEM_GRP_COB.Items.Clear();
                    iCont = CORVB.NULL_INTEGER;

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    { //ros 8/06/99 And iCont < INT_MAX_GRUPOS
                        iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                        pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                        ID_CEM_GRP_COB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
                        iCont++;
                    };
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

                iGruposRestantes = iTotalGrupos - iCont;
                result = iCont;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

            return result;
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            int iResp = 0;
            int iGrupos = 0;
            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
                this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);

                this.Show();
                this.Refresh();


                iErr = CORCONST.OK;
                do
                {
                    iGrupos = Carga_Grupos();
                    if (iErr == CORCONST.OK)
                    {
                        if (ID_CEM_GRP_COB.Items.Count == CORVB.NULL_INTEGER)
                        {
                            CORPROC.Alta_GrupoDefault(ref iErr, CORVAR.hgblConexion);
                            if (iErr != 0)
                            {
                                //AIS-1182 NGONZALEZ
                                iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                            }
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            iResp = (int)Interaction.MsgBox("No existen Grupos en catálogo " + Strings.Chr(CORVB.KEY_RETURN).ToString() + "¿Desea dar de Alta ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                            if (iResp == CORVB.IDYES)
                            {
                                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                                CORMNGRU.DefInstance.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        //AIS-1182 NGONZALEZ
                        iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        break;
                    }
                }
                while ((((iResp == CORVB.IDYES) ? -1 : 0) | ID_CEM_GRP_COB.Items.Count) == 0);
                if (iGrupos > INT_MAX_GRUPOS)
                {
                    ID_CEM_MASG_3PB.Enabled = true;
                }
                ComboBox tempRefParam = ID_ACG_MES_COB;
                CORPROC.Obten_Meses(this, ref tempRefParam);
                ID_ACG_MES_COB = tempRefParam;

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(Form_Load)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        private void ID_CEM_ALT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int lEmpresas = 0;

            this.Cursor = Cursors.WaitCursor;
            if (ID_ACG_MES_COB.Items.Count > CORVB.NULL_INTEGER)
            {
                CORVAR.igblMesDiaACG = VB6.GetItemData(ID_ACG_MES_COB, ID_ACG_MES_COB.SelectedIndex);
                CORVAR.igblAñoCorte = Convert.ToInt32(Conversion.Val(Strings.Mid(ID_ACG_MES_COB.Text.Trim(), (ID_ACG_MES_COB.Text.Trim().IndexOf(' ') + 1) + 1)));
            }
            else
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen meses de corte para generar reportes.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                return;
            }

            if (ID_CEM_IRA_3CKB.Value)
            {
                CORIREMP.DefInstance.Show();
                //AIS-BUG 4513 FSABORIO
                CORIREMP.DefInstance.Activate();
            }
            else
            {
                if (ID_CEM_EMP_LB.Items.Count != 0)
                {
                    CORVAR.lgblNumEmpresaR = Convert.ToInt32(Conversion.Val(ID_CEM_EMP_LB.Text.Substring(0, Math.Min(ID_CEM_EMP_LB.Text.Length, 5))));
                    CORRPANG.DefInstance.Show();
                    //AIS-BUG 4513 FSABORIO
                    CORRPANG.DefInstance.Activate();
                    if (CORRPANG.DefInstance.FormNeedsToClose)
                    { CORRPANG.DefInstance.Close(); }
                }
            }

            //las siguientes lineas arman el nombre del archivo cuando se dese guardarlo en algún formato.
            CORVAR.gblPathArchivo = CORVAR.pszgblPathRepEmpresas + Conversion.Str(CORVAR.lgblNumEmpresaR).Trim();


            if (FileSystem.Dir(CORVAR.gblPathArchivo, FileAttribute.Directory) == CORVB.NULL_STRING)
            {
                Directory.CreateDirectory(CORVAR.gblPathArchivo);
            }

            CORVAR.gblPathArchivo = CORVAR.gblPathArchivo + "\\" + Conversion.Str(CORVAR.igblAñoCorte).Trim() + Strings.Mid(StringsHelper.Format(CORVAR.igblMesCorte, "0000"), 1, 2).Trim() + "GR";
            this.Cursor = Cursors.Default;

        }

        private void ID_CEM_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void ID_CEM_GRP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {


            int lEmpresas = Obten_Empresas(); //Obtiene las empresas del Grupo
            if (iErr != CORCONST.OK)
            {
                //AIS-1182 NGONZALEZ
                iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }

        }

        private void ID_CEM_MASG_3PB_ClickEvent(Object eventSender, EventArgs eventArgs)
        {

            int iTempErr = 0;
            int iNumGrupo = 0;
            string pszNomGrupo = String.Empty; //El grupo a obtener
            int iCont = 0;
            int iGrupos = 0;

            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;

            // ID_CEM_GRP_COB.Clear 'COMENTADO POR FSWBMX
            if (iGruposRestantes != 0)
            {
                iCont = CORVB.NULL_INTEGER;
                //    iTempErr = qeFetchPrev(hBufGrupos)
                //    While qeFetchNext(hBufGrupos) = NULL_INTEGER And iCont < INT_MAX_GRUPOS
                //      iNumGrupo = qeValInt(hBufGrupos, 1)
                //      iTempErr = qeValCharBuf(hBufGrupos, pszNomGrupo, 2, NULL_STRING, LNG_COR_NOM)
                //      ID_CEM_GRP_COB.AddItem Format$(iNumGrupo, "0000") + "  " + pszNomGrupo
                //      iCont = iCont + 1
                //    Wend
                iGruposRestantes -= iCont;
                //Colocamos a un grupo por default
                if (ID_CEM_GRP_COB.Items.Count != 0)
                {
                    ID_CEM_GRP_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }
            else
            {
                try
                {
                    //    hBufGrupos = qeEndSQL(hBufGrupos)
                    iGrupos = Carga_Grupos();
                }
                catch (Exception e)
                {
                    CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEM_MASG_3PB_ClickEvent)", e);
                }
            }

            //  hBufGrupos = qeEndSQL(hBufGrupos)

            this.Cursor = Cursors.Default;

        }

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
            int htEMPConexion = 0; //Conexion a la base de datos
            int hBufEmpresa = 0; //Apuntador a la sentencia SQL
            int iTempErr = 0; //Control local
            string pszEmpresa = String.Empty; //La empresa a obtener
            int lNumEmpresa = 0; //El consecutivo de la empresa

            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;
            int iNumGrupo = Convert.ToInt32(Conversion.Val(ID_CEM_GRP_COB.Text.Substring(0, Math.Min(ID_CEM_GRP_COB.Text.Length, 4)))); //El grupo de quien se trata
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_num =" + Format$(iNumGrupo) + " and gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where gpo_num =" + iNumGrupo.ToString() + " and eje_prefijo= " + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_CEM_EMP_LB.Items.Clear();

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    //***** Código Anterior     ***********
                    //      ID_CEM_EMP_LB.AddItem Format$(lNumEmpresa, "00000") + "   " + pszEmpresa
                    //***** Fin Código Anterior ***********

                    //EISSA 05.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
                    ID_CEM_EMP_LB.Items.Add(StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
                    //EISSA 05.10.2001 FIN
                };
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
                ID_CEM_EMP_LB.Items.Clear();
                this.Cursor = Cursors.Default;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

            return result;
        }
        private void CORRANG2_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}