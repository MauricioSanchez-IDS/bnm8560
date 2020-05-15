using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    internal partial class CORIRGRU
        : System.Windows.Forms.Form
    {

        private void CORIRGRU_Activated(Object eventSender, EventArgs eventArgs)
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
        //**       Descripción: Forma para captura de un Grupo                      **
        //**                    en la busqueda especifica de catalogos              **
        //**                                                                        **
        //**       Responsable:                                                     **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        int hConexionTemp = 0;
        string pszSentencia = String.Empty;
        int iErr = 0;
        string pszGrupo = String.Empty;

        private int Conexion()
        {

            return -1;


        }

        private int Existe_Grupo()
        {

            int result = 0;
            int hBufGrupo = 0;
            int iTempErr = 0;

            this.Cursor = Cursors.WaitCursor;
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //pszgblsql = "exec ira_grupo_nom "," + Format$(igblBanco) + "," + Format$(igblNumGrupo)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "exec ira_grupo_nom " + CORVAR.igblPref.ToString() + "," + CORVAR.igblBanco.ToString() + "," + CORVAR.igblNumGrupo.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    pszGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 1).Trim();

                    CORVAR.pszgblNomGrupo = StringsHelper.Format(CORVAR.igblNumGrupo, "0000") + "  " + pszGrupo.TrimEnd();
                    result = -1;
                }
                else
                {
                    result = 0;
                }
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

            return result;
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {

            this.Left = (int)VB6.TwipsToPixelsX(3380);
            this.Top = (int)VB6.TwipsToPixelsY(2090);

            this.Cursor = Cursors.Default;

        }

        //UPGRADE_ISSUE: (1057) Event parameter UnloadMode was not upgraded.
        //AIS-999 NGONZALEZ	
        private void CORIRGRU_Closing(Object eventSender, FormClosingEventArgs eventArgs)
        {
            int Cancel = (eventArgs.Cancel) ? -1 : 0;

            if (eventArgs.CloseReason == CloseReason.UserClosing)
            {
                switch (Tag.ToString())
                {
                    case "CORGRCOM":
                        CORVAR.igblNumGrupo = -5;  //-5 Indica que el grupo no fue encontrado o no fue Buscado 
                        break;
                }
            }

            eventArgs.Cancel = Cancel != 0;
        }

        private void ID_IRA_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            switch (Tag.ToString())
            {
                case "CORGRCOM":
                    CORVAR.igblNumGrupo = -5;  //-5 Indica que el grupo no fue encontrado o no fue Buscado 
                    break;
                case "CORGRCOR":
                    CORVAR.igblNumGrupo = -5;  //-5 Indica que el grupo no fue encontrado o no fue Buscado 
                    break;
            }

            this.Close();

        }

        private void ID_IRA_GRU_PIC_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            if (KeyAscii == 13)
            {
                ID_IRA_OK_PB.PerformClick();
            }

            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != CORVB.KEY_BACK)
            {
                KeyAscii = 0;
            }

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_IRA_GRU_PIC_Leave(Object eventSender, EventArgs eventArgs)
        {

            ID_IRA_GRU_PIC.Text = StringsHelper.Format(ID_IRA_GRU_PIC.Text, "0000");

        }


        private void ID_IRA_OK_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            int iResultado = 0;
            int iResp = 0;

            this.Cursor = Cursors.WaitCursor;
            try
            {


                CORVAR.igblNumGrupo = Convert.ToInt32(Conversion.Val(ID_IRA_GRU_PIC.Text));
                if (CORVAR.igblNumGrupo != 0)
                {
                    if (Conexion() != 0)
                    {
                        if (Existe_Grupo() != 0)
                        {
                            switch (Tag.ToString())
                            {
                                case CORCONST.TAG_CATALOGO:
                                    //Posiciona el list box en el grupo seleccionado 
                                    for (int iCont = 1; iCont <= CORCTGRU.DefInstance.ID_CGR_GRP_LB.Items.Count; iCont++)
                                    {
                                        if (CORVAR.igblNumGrupo == Conversion.Val(Strings.Mid(VB6.GetItemString(CORCTGRU.DefInstance.ID_CGR_GRP_LB, iCont), 1, 4)))
                                        {
                                            CORCTGRU.DefInstance.ID_CGR_GRP_LB.SelectedIndex = iCont;
                                            break;
                                        }
                                    }

                                    //UPGRADE_ISSUE: (2072) Control Tag could not be resolved because it was within the generic namespace ActiveControl. 
                                    switch (CORCTGRU.DefInstance.ActiveControl.Tag.ToString())
                                    {
                                        case CORCONST.TAG_CAMBIO:
                                            CORMNGRU.DefInstance.Tag = CORCONST.TAG_CAMBIO;
                                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
                                            CORMNGRU.DefInstance.ShowDialog();
                                            break;
                                        case CORCONST.TAG_CONSULTA:
                                            CORMNGRU.DefInstance.Tag = CORCONST.TAG_CONSULTA;
                                            //UPGRADE_WARNING: (7009) Multiples invocations to ShowDialog in Forms with ActiveX Controls might throw runtime exceptions 
                                            CORMNGRU.DefInstance.ShowDialog();
                                            break;
                                        case CORCONST.TAG_BAJA:
                                            this.Cursor = Cursors.Default;
                                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                                            iResp = (int)Interaction.MsgBox("Confirmar baja de " + CORVAR.pszgblNomGrupo.Trim(), (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                                            if (iResp == CORVB.IDYES)
                                            {
                                                this.Cursor = Cursors.WaitCursor;
                                                iResultado = CORPROC.Opera_BajaGrupo(CORVAR.igblNumGrupo, ref iErr);
                                                if (iErr == CORCONST.OK)
                                                {
                                                    if (iResultado == CORVB.NULL_INTEGER)
                                                    {
                                                        this.Cursor = Cursors.Default;
                                                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                                        Interaction.MsgBox("No se pudo dar de baja a " + CORVAR.pszgblNomGrupo.Trim() + Strings.Chr(CORVB.KEY_RETURN).ToString() + "posiblemente posee Empresas en Catálogo", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                                                    }
                                                }
                                                else
                                                {
                                                    this.Close();
                                                }
                                            }
                                            break;
                                    }

                                    break;
                                case "CORGRCOM":
                                    CORVAR.lgblTempNumGpo = CORVAR.igblNumGrupo;
                                    CORMDIBN.DefInstance.Enabled = true;
                                    this.Close();
                                    break;
                                case "CORGRCOR":
                                    CORVAR.lgblTempNumGpo = CORVAR.igblNumGrupo;
                                    this.Close();

                                    break;
                                default:
                                    this.Close();
                                    break;
                            }
                            this.Close();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El grupo " + StringsHelper.Format(CORVAR.igblNumGrupo, "0000") + " no existe en Catálogos", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            switch (Tag.ToString())
                            {
                                case "CORGRCOM":
                                    CORVAR.lgblTempNumGpo = -5;  //-5 Indica que el grupo no fue encontrada o no fue Buscado 
                                    ID_IRA_GRU_PIC.Text = CORVB.NULL_STRING;
                                    ID_IRA_GRU_PIC.Focus();
                                    break;
                                default:
                                    ID_IRA_GRU_PIC.Text = CORVB.NULL_STRING;
                                    ID_IRA_GRU_PIC.Focus();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        //AIS-1182 NGONZALEZ
                        CORVAR.igblErr = API.USER.PostMessage(CORIRGRU.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                        switch (Tag.ToString())
                        {
                            case "CORGRCOM":
                                CORVAR.lgblTempNumGpo = -5;  //-5 Indica que el grupo no fue encontrada o no fue Buscado 
                                this.Close();
                                break;
                            default:
                                this.Close();
                                break;
                        }
                    }
                }
                else
                {
                    switch (Tag.ToString())
                    {
                        case "CORGRCOM":
                            CORVAR.lgblTempNumGpo = 0;  //Tecleo Grupo cero 
                            this.Close();
                            break;
                        case "CORGRCOR":
                            CORVAR.lgblTempNumGpo = 0;  //Tecleo Grupo cero 
                            this.Close();
                            break;
                        default:
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed. 
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. 
                            Interaction.MsgBox("No se puede hacer ningún movimiento sobre " + Strings.Chr(CORVB.KEY_RETURN).ToString() + " el Grupo 0000 ", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_IRA_GRU_PIC.Text = CORVB.NULL_STRING;
                            ID_IRA_GRU_PIC.Focus();
                            break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fallo operación ID_IRA_OK_PB_Click " + exc.Message, "Error Corirgru", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
    }
}