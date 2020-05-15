using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class frmBancanet
        : System.Windows.Forms.Form
    {

        private void frmBancanet_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }
        int iErr = 0; //Para Control local
        int hConexion = 0; //La conexion a la base de datos
        int iTop = 0;
        int iLeft = 0;

        const int INT_MAX_GRUPOS = 999;
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

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int iResp = 0;
            int iGrupos = 0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                this.Width = (int)VB6.TwipsToPixelsX(6900);
                this.Height = (int)VB6.TwipsToPixelsY(4890);
                int iLeft = Convert.ToInt32((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2);
                iTop = Convert.ToInt32((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.ClientRectangle.Height)) - ((float)VB6.PixelsToTwipsY(Height))) / 2);

                this.SetBounds(Convert.ToInt32((float)VB6.TwipsToPixelsX(iLeft)), Convert.ToInt32((float)VB6.TwipsToPixelsY(iTop)), 0, 0, BoundsSpecified.X | BoundsSpecified.Y);

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
                                iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
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
                        iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        break;
                    }
                }
                while ((((iResp == CORVB.IDYES) ? -1 : 0) | ID_CEM_GRP_COB.Items.Count | ((iErr != CORCONST.OK) ? -1 : 0)) == 0);
                if (iGrupos > INT_MAX_GRUPOS)
                {

                }


                CORMDIBN.DefInstance.ID_COR_MEDO_PNL._Caption = CORVB.NULL_STRING;

                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }
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

        private void ID_CEM_ACT_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                prActualizar();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEM_ACT_PB_Click)", e);
            }
        }
        private void prActualizar()
        {
            //Se actualizan los datos correspondientes
            string slNombreEmpresa = String.Empty;
            int llNumeroEmpresa = 0;
            int ilPrefijo = 0;
            int ilBanco = 0;
            string slEmpresa = String.Empty;
            if (fncValidaClienteB())
            {
                ilPrefijo = CORVAR.igblPref;
                ilBanco = CORVAR.igblBanco;
                slEmpresa = ID_CEM_EMP_LB.Text.Trim();
                llNumeroEmpresa = Convert.ToInt32(Conversion.Val(slEmpresa.Substring(0, Math.Min(slEmpresa.Length, 5))));
                if (slEmpresa.Length >= 5)
                {
                    slNombreEmpresa = slEmpresa.Substring(slEmpresa.Length - (slEmpresa.Length - 5)).Trim();
                }
                else
                {
                    slNombreEmpresa = "";
                }
                frmCliBancanet tempLoadForm = frmCliBancanet.DefInstance;
                frmCliBancanet.DefInstance.prPasaParametros(llNumeroEmpresa, slNombreEmpresa, ilPrefijo, ilBanco, "actualizar");
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                frmCliBancanet.DefInstance.ShowDialog();

            }
        }
        private void ID_CEM_CER_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Close();

        }
        private bool fncValidaClienteB()
        {
            if (ID_CEM_EMP_LB.Items.Count < 1)
            {
                return false;
            }
            if (ID_CEM_EMP_LB.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void ID_CEM_CON_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                prConsulta();
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_CEM_CON_PB_Click)", e);
            }

        }
        private void prConsulta()
        {
            //Se llama a la forma con los datos de la consulta
            string slNombreEmpresa = String.Empty;
            int llNumeroEmpresa = 0;
            int ilPrefijo = 0;
            int ilBanco = 0;
            string slEmpresa = String.Empty;
            if (fncValidaClienteB())
            {
                ilPrefijo = CORVAR.igblPref;
                ilBanco = CORVAR.igblBanco;
                slEmpresa = ID_CEM_EMP_LB.Text.Trim();

                llNumeroEmpresa = Convert.ToInt32(Conversion.Val(slEmpresa.Substring(0, Math.Min(slEmpresa.Length, 5))));
                if (slEmpresa.Length >= 5)
                {
                    slNombreEmpresa = slEmpresa.Substring(slEmpresa.Length - (slEmpresa.Length - 5)).Trim();
                }
                else
                {
                    slNombreEmpresa = "";
                }
                frmCliBancanet tempLoadForm = frmCliBancanet.DefInstance;
                frmCliBancanet.DefInstance.prPasaParametros(llNumeroEmpresa, slNombreEmpresa, ilPrefijo, ilBanco, "consulta");
                //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions
                frmCliBancanet.DefInstance.ShowDialog();

            }

        }
        private void ID_CEM_GRP_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {


            int iEmpresas = Obten_Empresas(); //Obtiene las empresas del Grupo
            if (iErr != CORCONST.OK)
            {
                //AIS-1182 NGONZALEZ
                iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }

        }
        private void frmBancanet_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}