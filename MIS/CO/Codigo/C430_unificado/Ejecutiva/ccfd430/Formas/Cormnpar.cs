using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORMNPAR
        : System.Windows.Forms.Form
    {

        //****************************************************************************
        //**                                                                        **
        //**         CopyRight(C) DDEMESIS, SA DE CV / Banamex - Sistemas           **
        //**                                                                        **
        //**       ---------------------------------------------------------        **
        //**                                                                        **
        //**       Descripción: Mantenimiento a los parametros generales del        **
        //**                    sistema ademas de dar de alta a los nuevos banco    **
        //**                    operen en el sistema.                               **
        //**                                                                        **
        //**       Responsable: Felipe Zacarias Jimenez                             **
        //**                                                                        **
        //**       Ultima Fecha de Modificación: 24/Junio/1994                      **
        //**                                                                        **
        //**       NOTA: Esta forma necesita Visual Basic 3.0                       **
        //**                                                                        **
        //****************************************************************************

        const string STR_PGS_NOT_NUL = "Falta por capturar el campo ";
        const string STR_PGS_SIN_PUN = "Los nombres de los archivos deberán estar sin punto.";
        const string STR_PGS_CON_PUNT = "El formato de la versión del sistema es con punto si se requiere.";
        const string STR_PGS_REP_NUM = "El número de Banco se encuentra repetido, verifiquelo.";
        const string STR_PGS_REP_PRE = "El prefijo del Banco se encuentra repetido.";

        string[,] pszArrBancos = null;
        int iIndiceMat = 0;
        int bCambioBancos = 0;
        int iErr = 0; //Para Control local
        int iRes = 0; //Para Control local

        bool bmExisteBanco = false;


        private void Carga_Bancos()
        {

            int hBanco = 0;
            int iBanco = 0;
            int iPrefijo = 0;
            int iGrupo = 0;
            int lEmpresa = 0;
            string pszBanDes = String.Empty;

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " con_banco,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " con_ban_des,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " con_pref,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " con_gpo,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " con_emp";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCCON01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where con_tipo_prod = 'D'";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by con_banco";

            int iCont = CORPROC2.Cuenta_Registros();
            if (iCont >= 1)
            {
                bmExisteBanco = true;
                if (CORPROC2.Obtiene_Registros() != 0)
                {
                    ID_PAR_NOM_COB.Items.Clear();
                    if (pszArrBancos != null)
                    {
                        Array.Clear(pszArrBancos, 0, pszArrBancos.Length);
                    }
                    pszArrBancos = ArraysHelper.InitializeArray<string[,]>(new int[] { iCont + 1, 5 }, new int[] { 0, 0 });
                    iCont = CORVB.NULL_INTEGER;

                    while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                    {
                        iBanco = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                        pszBanDes = VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.SECOND_COL);
                        iPrefijo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.THIRD_COL)));
                        iGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FOURTH_COL)));
                        lEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIFTH_COL)));
                        pszArrBancos[iCont, 0] = StringsHelper.Format(iBanco, "#0");
                        pszArrBancos[iCont, 1] = pszBanDes.Trim();
                        pszArrBancos[iCont, 2] = StringsHelper.Format(iPrefijo, "###0");
                        pszArrBancos[iCont, 3] = StringsHelper.Format(iGrupo, "####0");
                        pszArrBancos[iCont, 4] = StringsHelper.Format(lEmpresa, Formato.sMascara(Formato.iTipo.Empresa));
                        ID_PAR_NOM_COB.Items.Add(pszBanDes.Trim());
                        iCont++;
                    };
                    ID_PAR_NOM_COB.SelectedIndex = 0;
                    //            ID_PAR_NOM_COB.AddItem "Nuevo"
                    //            pszArrBancos(iCont, 1) = "Nuevo"
                }
                else
                {
                    //AIS-1182 NGONZALEZ
                    CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                if (ID_PAR_NOM_COB.Items.Count > 1)
                {
                    iIndiceMat = CORVB.NULL_INTEGER;
                    ID_PAR_NUM_EB.CtlText = pszArrBancos[CORVB.NULL_INTEGER, 0];
                    ID_PAR_PRE_EB.CtlText = pszArrBancos[CORVB.NULL_INTEGER, 2];
                    ID_PAR_GRU_EB.CtlText = pszArrBancos[CORVB.NULL_INTEGER, 3];
                    ID_PAR_CON_EB.CtlText = pszArrBancos[CORVB.NULL_INTEGER, 4];
                    ID_PAR_NUM_EB.Enabled = false;
                    ID_PAR_PRE_EB.Enabled = false;
                    ID_PAR_GRU_EB.Enabled = false;
                    ID_PAR_CON_EB.Enabled = false;
                    ID_PAR_NOM_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }
            else
            {
                bmExisteBanco = false;
            }

        }

        public void Carga_Parametros()
        {

            int hParam = 0;
            string pszCampos = String.Empty;
            FixedLengthString szEmpresa = new FixedLengthString(CORBD.LEN_PAR_EMP);
            FixedLengthString szPath = new FixedLengthString(CORBD.LEN_PAR_PATH);
            FixedLengthString szThs = new FixedLengthString(CORBD.LEN_PAR_THS);
            FixedLengthString szPla = new FixedLengthString(CORBD.LEN_PAR_PLA);
            FixedLengthString szHis = new FixedLengthString(CORBD.LEN_PAR_HIS);
            FixedLengthString szAra = new FixedLengthString(CORBD.LEN_PAR_ARA);
            FixedLengthString szSgo = new FixedLengthString(CORBD.LEN_PAR_SGO);
            FixedLengthString szNeg = new FixedLengthString(CORBD.LEN_PAR_NEG);
            FixedLengthString szAct = new FixedLengthString(CORBD.LEN_PAR_ACT);
            FixedLengthString szAcl = new FixedLengthString(CORBD.LEN_PAR_ACL);

            int iCorte = 0;
            int iIncre = 0;
            int iMes = 0;
            float sVersion = 0;
            int IlLongEmp = 0;
            int IlLongEje = 0;

            string pszTelefono = String.Empty;
            string pszLada = String.Empty;
            string pszFax = String.Empty;
            string pszFaxLada = String.Empty;
            int iPtoCom = 0;
            string pszEmail = String.Empty;
            string pszInternet = String.Empty;
            string pszExtension = String.Empty;
            string pszParComunica = String.Empty;
            int iVelTrans = 0;

            CORVAR.pszgblsql = "select";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_emp,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_mes_oper,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_dia_corte,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ver,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_path,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ths,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_pla,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_his,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ara,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_sgo,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_neg,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_act,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_acl,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_incremento,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_telefono,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_tel_lada,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_fax,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_fax_lada,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_par_comu,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_pto_modem,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_vel_transmis,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_email,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_internet,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_extension,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_emp,";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_eje";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCPGS01";
            if (bmExisteBanco)
            {
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where pgs_rep_prefijo = " + ID_PAR_PRE_EB.CtlText;
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and pgs_rep_banco = " + ID_PAR_NUM_EB.CtlText;
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and pgs_tipo_prod = 'D'";
            }

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    szEmpresa.Value = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    iMes = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 2)));
                    iCorte = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                    sVersion = (float)Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 4));
                    szPath.Value = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                    szThs.Value = VBSQL.SqlData(CORVAR.hgblConexion, 6);
                    szPla.Value = VBSQL.SqlData(CORVAR.hgblConexion, 7);
                    szHis.Value = VBSQL.SqlData(CORVAR.hgblConexion, 8);
                    szAra.Value = VBSQL.SqlData(CORVAR.hgblConexion, 9);
                    szSgo.Value = VBSQL.SqlData(CORVAR.hgblConexion, 10);
                    szNeg.Value = VBSQL.SqlData(CORVAR.hgblConexion, 11);
                    szAct.Value = VBSQL.SqlData(CORVAR.hgblConexion, 12);
                    szAcl.Value = VBSQL.SqlData(CORVAR.hgblConexion, 13);
                    iIncre = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 14)));
                    pszTelefono = VBSQL.SqlData(CORVAR.hgblConexion, 15);
                    pszLada = VBSQL.SqlData(CORVAR.hgblConexion, 16);
                    pszFax = VBSQL.SqlData(CORVAR.hgblConexion, 17);
                    pszFaxLada = VBSQL.SqlData(CORVAR.hgblConexion, 18);
                    pszParComunica = VBSQL.SqlData(CORVAR.hgblConexion, 19);
                    iPtoCom = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 20)));
                    iVelTrans = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 21)));
                    pszEmail = VBSQL.SqlData(CORVAR.hgblConexion, 22);
                    pszInternet = VBSQL.SqlData(CORVAR.hgblConexion, 23);
                    pszExtension = VBSQL.SqlData(CORVAR.hgblConexion, 24);
                    IlLongEmp = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 25));
                    IlLongEje = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 26));

                    ID_PAR_EMP_EB.Text = szEmpresa.Value.Trim();
                    ID_PAR_MES_COB.SelectedIndex = (int)(iMes - 1);
                    ID_PAR_DIA_EB.CtlText = StringsHelper.Format(iCorte, "00");
                    ID_PAR_VER_EB.CtlText = sVersion.ToString();
                    ID_PAR_TEL_TXT.Text = pszTelefono.Trim();
                    ID_PAR_LADA_TXT.Text = pszLada.Trim();
                    ID_PAR_FAX_TXT.Text = pszFax.Trim();
                    ID_PAR_FAX_LADA_TXT.Text = pszFaxLada.Trim();
                    ID_PAR_EMAIL_TXT.Text = pszEmail.Trim();
                    ID_PAR_INTER_TXT.Text = pszInternet.Trim();
                    ID_PAR_TEL_EXT_TXT.Text = pszExtension.Trim();
                    //            ID_PAR_COM_TRA_COB.Text = iVelTrans
                    ID_PAR_LEM_EB.defaultText = IlLongEmp.ToString();
                    ID_PAR_LEJ_EB.defaultText = IlLongEje.ToString();

                    //Puerto de Comunicaciones
                    //            If iPtoCom = 1 Then
                    //              ID_PAR_COM1_OB.Value = True
                    //            ElseIf iPtoCom = 2 Then
                    //              ID_PAR_COM2_OB.Value = True
                    //            ElseIf iPtoCom = 3 Then
                    //              ID_PAR_COM3_OB.Value = True
                    //            ElseIf iPtoCom = 4 Then
                    //              ID_PAR_COM4_OB.Value = True
                    //            End If

                    if (iIncre == 1)
                    {
                        ID_PAR_INC_COB.SelectedIndex = CORVB.NULL_INTEGER;
                    }
                    else
                    {
                        ID_PAR_INC_COB.SelectedIndex = 1;
                    }
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
        }

        private void CORMNPAR_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != eventSender)
            {
                ActivateHelper.myActiveForm = (Form)eventSender;

                ID_PAR_EMP_EB.Focus();

            }
        }

        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            double dou = VB6.TwipsToPixelsX(4942);
            dou = VB6.TwipsToPixelsY(13215);
            this.Left = (int)((CORMDIBN.DefInstance.ClientRectangle.Width - this.Width) / 2);
            this.Top = (int)((CORMDIBN.DefInstance.ClientRectangle.Height - 87 - this.Height) / 2);

            this.Show();
            this.Refresh();

            this.Cursor = Cursors.WaitCursor;

            bCambioBancos = 0;

            ID_PAR_MES_COB.Items.Clear();
            ID_PAR_MES_COB.Items.Add("ENERO");
            ID_PAR_MES_COB.Items.Add("FEBRERO");
            ID_PAR_MES_COB.Items.Add("MARZO");
            ID_PAR_MES_COB.Items.Add("ABRIL");
            ID_PAR_MES_COB.Items.Add("MAYO");
            ID_PAR_MES_COB.Items.Add("JUNIO");
            ID_PAR_MES_COB.Items.Add("JULIO");
            ID_PAR_MES_COB.Items.Add("AGOSTO");
            ID_PAR_MES_COB.Items.Add("SEPTIEMBRE");
            ID_PAR_MES_COB.Items.Add("OCTUBRE");
            ID_PAR_MES_COB.Items.Add("NOVIEMBRE");
            ID_PAR_MES_COB.Items.Add("DICIEMBRE");
            ID_PAR_MES_COB.SelectedIndex = CORVB.NULL_INTEGER;

            ID_PAR_INC_COB.Items.Add("1");
            ID_PAR_INC_COB.Items.Add("100");

            //    ID_PAR_COM_TRA_COB.AddItem "0"
            //    ID_PAR_COM_TRA_COB.AddItem "300"
            //    ID_PAR_COM_TRA_COB.AddItem "1200"
            //    ID_PAR_COM_TRA_COB.AddItem "2400"
            //    ID_PAR_COM_TRA_COB.AddItem "4800"
            //    ID_PAR_COM_TRA_COB.AddItem "9600"
            //    ID_PAR_COM_TRA_COB.AddItem "19200"
            //    ID_PAR_COM_TRA_COB.AddItem "38400"
            //    ID_PAR_COM_TRA_COB.AddItem "57600"
            //    ID_PAR_COM_TRA_COB.AddItem "115200"
            //    ID_PAR_COM_TRA_COB.AddItem "230400"

            Carga_Bancos();

            //If bmExisteBanco = True Then TODO este bloque se comenta 12/10/06 ya que no permite alta de productos
            //    Carga_Parametros
            //
            //    If Not bgblAdmin Then
            //        ID_PAR_BAN_PNL.Enabled = False
            //    End If
            //Else
            //    ID_PAR_BAN_PNL.Enabled = True
            //End If

            ID_PAR_BAN_PNL.Enabled = true;
            mdlParametros.gperPerfil.prHabilitaAcciones(CORMNPAR.DefInstance);
            this.Cursor = Cursors.Default;

        }

        private void FSW_Bco_Alta_Click(Object eventSender, EventArgs eventArgs)
        {

            CORMNPAR.DefInstance.Tag = "BCO_ALTA";

            ID_PAR_NUM_EB.Enabled = true;
            ID_PAR_PRE_EB.Enabled = true;

            FSW_Bco_Alta.Enabled = false;
            Fsw_Bco_Baja.Enabled = false;
            ID_PAR_NOM_COB.SelectedIndex = ID_PAR_NOM_COB.Items.Count - 1;
            limpia_campos();

        }

        private void Fsw_Bco_Baja_Click(Object eventSender, EventArgs eventArgs)
        {
            int iResp = 0;
            CORMNPAR.DefInstance.Tag = "BCO_BAJA";
            FSW_Bco_Alta.Enabled = false;
            try
            {
                if (CORVAR.igblBanco == Conversion.Val(ID_PAR_NUM_EB.CtlText) && CORVAR.igblPref == Conversion.Val(ID_PAR_PRE_EB.CtlText))
                {
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    iResp = (int)Interaction.MsgBox("No puede dar de baja el banco está en operación: " + ID_PAR_NOM_COB.Text, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)MsgBoxStyle.Critical)), CORSTR.STR_APP_TIT);
                }
                else
                {
                    //************************************************************
                    //   CONFIRMA EL BORRADO DEL PRODUCTO
                    //************************************************************
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    iResp = (int)Interaction.MsgBox("Dar de baja al Banco : " + ID_PAR_NOM_COB.Text, (MsgBoxStyle)(CORVB.MB_YESNO + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                    this.Cursor = Cursors.WaitCursor;
                    if (iResp == CORVB.IDYES)
                    {
                        //************************************************************
                        //   VERIFICA DEPENDENCIAS PARA EL BORRADO
                        //************************************************************
                        CORVAR.pszgblsql = "SELECT * FROM " + CORBD.DB_SYB_EMP;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + ID_PAR_PRE_EB.CtlText + " and gpo_banco = " + ID_PAR_NUM_EB.CtlText;

                        if (CORPROC2.Cuenta_Registros() != 0)
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("No se puede borrar un banco si existen aún empresas asignadas." + "\r" + "Favor de dar primero de baja las empresas asignados a él.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                        else
                        {
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                            if (Verifica_Banco_Borrado())
                            {
                                this.Cursor = Cursors.Default;
                                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                                Interaction.MsgBox("No se puede borrar un banco si existen grupos asignados." + "\r" + "Favor de dar primero de baja los grupos o empresas asignados a él.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            }
                            else
                            {
                                CORVAR.pszgblsql = "DELETE FROM " + CORBD.DB_SYB_PGS;
                                CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE pgs_rep_prefijo = " + ID_PAR_PRE_EB.CtlText + " and pgs_rep_banco = " + ID_PAR_NUM_EB.CtlText;


                                if (CORPROC2.Modifica_Registro() != 0)
                                {
                                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                    CORVAR.pszgblsql = "DELETE FROM " + CORBD.DB_SYB_CON;
                                    CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE con_pref = " + ID_PAR_PRE_EB.CtlText + " and con_banco = " + ID_PAR_NUM_EB.CtlText;

                                    if (CORPROC2.Modifica_Registro() != 0)
                                    {
                                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                        CORVAR.pszgblsql = "DELETE FROM " + CORBD.DB_SYB_COR;
                                        CORVAR.pszgblsql = CORVAR.pszgblsql + " WHERE eje_prefijo = " + ID_PAR_PRE_EB.CtlText + " and gpo_banco = " + ID_PAR_NUM_EB.CtlText;
                                        if (CORPROC2.Modifica_Registro() != 0)
                                        {
                                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                        }
                                        else
                                        {
                                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                        }
                                    }
                                }
                                else
                                {
                                    //AIS-1182 NGONZALEZ
                                    CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                }
                                Carga_Bancos();
                                Carga_Parametros();
                                CORMNPAR tempLoadForm = this;
                            }
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                CORMNPAR.DefInstance.Tag = "";
                FSW_Bco_Alta.Enabled = true;
                Fsw_Bco_Baja.Enabled = true;
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(Fsw_Bco_Baja_Click)", e);
            }

        }


        public void ID_PAR_ACE_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            string pszCampoNulo = String.Empty;
            int bPosPunto = 0;
            int iPos = 0;
            int iReg = 0;
            int bExiste = 0;
            int i = 0;


            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                int bSinErr = -1;
                this.Cursor = Cursors.WaitCursor;

                if (CORMNPAR.DefInstance.Tag.ToString() != "BCO_BAJA")
                {

                    pszCampoNulo = CORVB.NULL_STRING;
                    if (ID_PAR_EMP_EB.Text.Trim() == CORVB.NULL_STRING)
                    {
                        pszCampoNulo = "Empresa";
                    }
                    if (ID_PAR_DIA_EB.CtlText.Trim() == CORVB.NULL_STRING)
                    {
                        pszCampoNulo = "Día de Corte";
                    }
                    if (Conversion.Val(ID_PAR_DIA_EB.CtlText.Trim()) < 0 || Conversion.Val(ID_PAR_DIA_EB.CtlText.Trim()) > 31)
                    {
                        pszCampoNulo = " Día de Corte Invalido 1 a 31 ";
                    }
                    if (ID_PAR_NUM_EB.CtlText.Trim() == CORVB.NULL_STRING)
                    {
                        pszCampoNulo = "No. de Banco";
                    }
                    if (ID_PAR_PRE_EB.CtlText.Trim() == CORVB.NULL_STRING)
                    {
                        pszCampoNulo = "Prefijo";
                    }
                    if (ID_PAR_INC_COB.Text.Trim() == CORVB.NULL_STRING)
                    {
                        pszCampoNulo = "Incremento";
                    }
                    if (ID_PAR_VER_EB.CtlText.Trim() == CORVB.NULL_STRING)
                    {
                        pszCampoNulo = "Versión";
                    }
                    else
                    {
                        if (ID_PAR_VER_EB.CtlText.IndexOf(',') >= 0)
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(STR_PGS_CON_PUNT, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            bSinErr = 0;
                        }
                    }
                    if (ID_PAR_TEL_TXT.Text.Trim() == CORVB.NULL_STRING)
                    {
                        pszCampoNulo = "Teléfono";
                    }
                    if (bmExisteBanco)
                    {
                        iReg = ID_PAR_NOM_COB.Items.Count - 1;
                        if ((pszArrBancos[iReg, 1].Trim() == CORVB.NULL_STRING || pszArrBancos[iReg, 1].Trim() == "Nuevo") && (Conversion.Val(pszArrBancos[iReg, 0]) != CORVB.NULL_INTEGER && Conversion.Val(pszArrBancos[iReg, 2]) != CORVB.NULL_INTEGER))
                        {
                            pszCampoNulo = "Nombre de Banco";
                        }
                        else
                        {
                            if ((pszArrBancos[iReg, 1].Trim() != "Nuevo") && (pszArrBancos[iReg, 1].Trim() != CORVB.NULL_STRING))
                            {
                                if (Conversion.Val(pszArrBancos[iReg, 0]) == CORVB.NULL_INTEGER)
                                {
                                    pszCampoNulo = "Número de Banco";
                                }
                                if (Conversion.Val(pszArrBancos[iReg, 2]) == CORVB.NULL_INTEGER)
                                {
                                    pszCampoNulo = "Prefijo";
                                }
                            }
                        }
                    }
                    if (pszCampoNulo.Length != 0)
                    {
                        this.Cursor = Cursors.Default;
                        //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                        //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                        Interaction.MsgBox(STR_PGS_NOT_NUL + pszCampoNulo, (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                        bSinErr = 0;
                    }
                }

                if (CORMNPAR.DefInstance.Tag.ToString() != "BCO_BAJA")
                {
                    if (bSinErr != 0)
                    {
                        if (Verifica_Banco_Repetido() != 0)
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox(STR_PGS_REP_NUM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            bSinErr = 0;
                            ID_PAR_NUM_EB.Focus();
                        }
                        if (Verifica_Empresa_Repetida(iReg) != 0)
                        {
                            this.Cursor = Cursors.Default;
                            //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                            //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                            Interaction.MsgBox("El consecutivo para la Empresa ya existe como una clave de Empresa. Favor de cambiarlo.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                            ID_PAR_CON_EB.Focus();
                            bSinErr = 0;
                        }
                    }

                    if (bSinErr != 0)
                    {
                        switch (CORMNPAR.DefInstance.Tag.ToString())
                        {
                            case "BCO_ALTA":
                                Inserta_Banco();
                                if (bmExisteBanco)
                                {
                                    CORMNPAR tempLoadForm = this;
                                    Carga_Bancos();
                                    FSW_Bco_Alta_Click(FSW_Bco_Alta, new EventArgs());
                                }
                                else
                                {
                                    this.Close();
                                }
                                break;
                            default:
                                Modifica_Bancos();
                                CORMNPAR tempLoadForm2 = this;
                                FSW_Bco_Alta.Enabled = true;
                                Fsw_Bco_Baja.Enabled = true;
                                break;
                        }
                    }
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exc)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_PAR_ACE_PB_Click)", exc);
                //throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        public void ID_PAR_ACL_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

        }

        public void ID_PAR_ACT_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

        }

        public void ID_PAR_ARE_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

        }


        public void ID_PAR_CAN_PB_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Cursor = Cursors.WaitCursor;
            FSW_Bco_Alta.Enabled = true;
            Fsw_Bco_Baja.Enabled = true;
            CORMNPAR.DefInstance.Tag = "";
            this.Close();
            this.Cursor = Cursors.Default;
        }

        //Private Sub ID_PAR_COM_TRA_COB_KeyPress(KeyAscii As Integer)
        //
        //  If (KeyAscii > 57 Or KeyAscii < 48) Then
        //    KeyAscii = NULL_INTEGER
        //  End If
        //
        //End Sub

        public void ID_PAR_CON_EB_Change(Object eventSender, EventArgs eventArgs)
        {

            //***** Código Anterior     ***********
            //  pszArrBancos(iIndiceMat, 4) = Format$(ID_PAR_CON_EB.Text, "00000")
            //***** Fin Código Anterior ***********

            //EISSA 03.10.2001 Cambio para leer la longitud de la empresa y del ejecutivo
            if (bmExisteBanco)
            {
                pszArrBancos[iIndiceMat, 4] = StringsHelper.Format(ID_PAR_CON_EB.CtlText, Formato.sMascara(Formato.iTipo.Empresa));
                bCambioBancos = -1;
            }

        }

        public void ID_PAR_DIA_SPB_SpinDown()
        {

            int LimiteDias = 0;

            switch (ID_PAR_MES_COB.SelectedIndex + 1)
            {
                case 1:
                    LimiteDias = 31;
                    break;
                case 2:
                    LimiteDias = 29;
                    break;
                case 3:
                    LimiteDias = 31;
                    break;
                case 4:
                    LimiteDias = 30;
                    break;
                case 5:
                    LimiteDias = 31;
                    break;
                case 6:
                    LimiteDias = 30;
                    break;
                case 7:
                    LimiteDias = 31;
                    break;
                case 8:
                    LimiteDias = 31;
                    break;
                case 9:
                    LimiteDias = 30;
                    break;
                case 10:
                    LimiteDias = 31;
                    break;
                case 11:
                    LimiteDias = 30;
                    break;
                case 12:
                    LimiteDias = 31;
                    break;
            }

            ID_PAR_DIA_EB.CtlText = Conversion.Str(Conversion.Val((Double.Parse(ID_PAR_DIA_EB.CtlText) - 1).ToString())).Trim();
            if (Conversion.Val(ID_PAR_DIA_EB.CtlText) >= 1 && Conversion.Val(ID_PAR_DIA_EB.CtlText) <= LimiteDias)
            {
                if (Conversion.Val(ID_PAR_DIA_EB.CtlText) >= 1 && Conversion.Val(ID_PAR_DIA_EB.CtlText) <= 9)
                {
                    ID_PAR_DIA_EB.CtlText = StringsHelper.Format(Conversion.Val(ID_PAR_DIA_EB.CtlText), "00");
                }
            }
            else
            {
                ID_PAR_DIA_EB.CtlText = Conversion.Str(LimiteDias).Trim();
            }

        }

        public void ID_PAR_DIA_SPB_SpinUp()
        {

            int LimiteDias = 0;

            switch (ID_PAR_MES_COB.SelectedIndex + 1)
            {
                case 1:
                    LimiteDias = 31;
                    break;
                case 2:
                    LimiteDias = 29;
                    break;
                case 3:
                    LimiteDias = 31;
                    break;
                case 4:
                    LimiteDias = 30;
                    break;
                case 5:
                    LimiteDias = 31;
                    break;
                case 6:
                    LimiteDias = 30;
                    break;
                case 7:
                    LimiteDias = 31;
                    break;
                case 8:
                    LimiteDias = 31;
                    break;
                case 9:
                    LimiteDias = 30;
                    break;
                case 10:
                    LimiteDias = 31;
                    break;
                case 11:
                    LimiteDias = 30;
                    break;
                case 12:
                    LimiteDias = 31;
                    break;
            }

            ID_PAR_DIA_EB.CtlText = Conversion.Str(Conversion.Val((Double.Parse(ID_PAR_DIA_EB.CtlText) + 1).ToString())).Trim();
            if (Conversion.Val(ID_PAR_DIA_EB.CtlText) >= 1 && Conversion.Val(ID_PAR_DIA_EB.CtlText) <= LimiteDias)
            {
                if (Conversion.Val(ID_PAR_DIA_EB.CtlText) >= 1 && Conversion.Val(ID_PAR_DIA_EB.CtlText) <= 9)
                {
                    ID_PAR_DIA_EB.CtlText = StringsHelper.Format(Conversion.Val(ID_PAR_DIA_EB.CtlText), "00");
                }
            }
            else
            {
                ID_PAR_DIA_EB.CtlText = StringsHelper.Format(1, "00");
            }

        }

        public void ID_PAR_DIR_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }

            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];
        }



        private void ID_PAR_CON_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        private void ID_PAR_DIA_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }




        private void ID_PAR_EMAIL_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 32)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        public void ID_PAR_EMP_EB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            CRSGeneral.prValidaCaracter(ref KeyAscii, CRSGeneral.cteValidaciones.cteValAlfaNumerico, true, true, "");
            // KeyAscii = Asc(UCase$(Chr$(KeyAscii)))

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_PAR_FAX_LADA_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_PAR_FAX_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        private void ID_PAR_GRU_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        public void ID_PAR_HIS_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

        }

        private bool isInitializingComponent;
        //UPGRADE_WARNING: (2074) ComboBox event ID_PAR_INC_COB.Change was upgraded to ID_PAR_INC_COB.TextChanged which has a new behavior.
        private void ID_PAR_INC_COB_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (CORMNPAR.DefInstance.Tag.ToString() == "BCO_ALTA")
            {
                ID_PAR_CON_EB.CtlText = ID_PAR_INC_COB.Text;
            }
        }

        private void ID_PAR_INC_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            if (CORMNPAR.DefInstance.Tag.ToString() == "BCO_ALTA")
            {
                ID_PAR_CON_EB.CtlText = ID_PAR_INC_COB.Text;
            }
        }

        private void ID_PAR_INTER_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if (KeyAscii == 32)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_PAR_LADA_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        public void ID_PAR_NEG_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

        }


        private void ID_PAR_LEJ_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_PAR_LEJ_EB.SelStart = 0;
            ID_PAR_LEJ_EB.SelLength = Strings.Len(ID_PAR_LEJ_EB.defaultText);
        }

        private void ID_PAR_LEJ_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false, String.Empty, "089");
        }

        private void ID_PAR_LEJ_EB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (Conversion.Val(ID_PAR_LEJ_EB.defaultText) < CRSParametros.cteLongitudEmpresaEjecutivo)
            {
                ID_PAR_LEM_EB.defaultText = (CRSParametros.cteLongitudEmpresaEjecutivo - Conversion.Val(ID_PAR_LEJ_EB.defaultText)).ToString();
            }
            else
            {
                MessageBox.Show("Valor no válido para la longitud del ejecutivo." + "\r\n" + "El valor debe ser menor a " + CRSParametros.cteLongitudEmpresaEjecutivo.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ID_PAR_LEJ_EB.SelStart = 0;
                ID_PAR_LEJ_EB.SelLength = Strings.Len(ID_PAR_LEJ_EB.defaultText);
                Cancel = true;
            }
            eventArgs.Cancel = Cancel;
        }

        private void ID_PAR_LEM_EB_Enter(Object eventSender, EventArgs eventArgs)
        {
            ID_PAR_LEM_EB.SelStart = 0;
            ID_PAR_LEM_EB.SelLength = Strings.Len(ID_PAR_LEM_EB.defaultText);
        }

        private void ID_PAR_LEM_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {
            CRSGeneral.prValidaCaracter(ref eventArgs.keyAscii, CRSGeneral.cteValidaciones.cteValDigitos, true, false, String.Empty, "089");
        }

        private void ID_PAR_LEM_EB_Validating(Object eventSender, CancelEventArgs eventArgs)
        {
            bool Cancel = eventArgs.Cancel;
            if (Conversion.Val(ID_PAR_LEM_EB.defaultText) < CRSParametros.cteLongitudEmpresaEjecutivo)
            {
                ID_PAR_LEJ_EB.defaultText = (CRSParametros.cteLongitudEmpresaEjecutivo - Conversion.Val(ID_PAR_LEM_EB.defaultText)).ToString();
            }
            else
            {
                MessageBox.Show("Valor no válido para la longitud de la empresa." + "\r\n" + "El valor debe ser menor a " + CRSParametros.cteLongitudEmpresaEjecutivo.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancel = true;
                ID_PAR_LEM_EB.SelStart = 0;
                ID_PAR_LEM_EB.SelLength = Strings.Len(ID_PAR_LEM_EB.defaultText);
            }
            eventArgs.Cancel = Cancel;
        }

        private void ID_PAR_NOM_COB_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
        {

            int iCont = 0;
            int iConsecutivo = 0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {
                iIndiceMat = ID_PAR_NOM_COB.SelectedIndex;

                //Entra si es el nuevo banco
                if (ID_PAR_NOM_COB.SelectedIndex == -1)
                {
                    FSW_Bco_Alta_Click(FSW_Bco_Alta, new EventArgs());
                }
                else
                {
                    if (CORMNPAR.DefInstance.Tag.ToString() == "BCO_ALTA")
                    {
                        ID_PAR_NOM_COB.SelectedIndex = ID_PAR_NOM_COB.Items.Count - 1;
                    }
                    else
                    {
                        ID_PAR_NUM_EB.Enabled = true;
                        ID_PAR_PRE_EB.Enabled = true;
                        ID_PAR_GRU_EB.Enabled = true;
                        ID_PAR_CON_EB.Enabled = true;

                        ID_PAR_NUM_EB.CtlText = pszArrBancos[iIndiceMat, 0];
                        ID_PAR_PRE_EB.CtlText = pszArrBancos[iIndiceMat, 2];
                        ID_PAR_GRU_EB.CtlText = pszArrBancos[iIndiceMat, 3];
                        ID_PAR_CON_EB.CtlText = pszArrBancos[iIndiceMat, 4];

                        ID_PAR_NUM_EB.Enabled = false;
                        ID_PAR_PRE_EB.Enabled = false;
                        ID_PAR_GRU_EB.Enabled = false;
                        ID_PAR_CON_EB.Enabled = false;
                        Carga_Parametros();
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }
        }

        //UPGRADE_WARNING: (2074) ComboBox event ID_PAR_NOM_COB.Change was upgraded to ID_PAR_NOM_COB.TextChanged which has a new behavior.
        public void ID_PAR_NOM_COB_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            if (isInitializingComponent)
            {
                return;
            }
            if (bmExisteBanco)
            {
                pszArrBancos[iIndiceMat, 1] = ID_PAR_NOM_COB.Text;
                bCambioBancos = -1;
            }
        }

        public void ID_PAR_NOM_COB_DropDown(Object eventSender, EventArgs eventArgs)
        {
            VB6.SetItemString(ID_PAR_NOM_COB, iIndiceMat, ID_PAR_NOM_COB.Text);
        }

        public void ID_PAR_NOM_COB_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }

        public void ID_PAR_NUM_EB_Change(Object eventSender, EventArgs eventArgs)
        {

            if (bmExisteBanco)
            {
                pszArrBancos[iIndiceMat, 0] = StringsHelper.Format(ID_PAR_NUM_EB.CtlText, "#0");
                bCambioBancos = -1;
            }
        }

        private void ID_PAR_NUM_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        public void ID_PAR_NUM_EB_Leave(Object eventSender, EventArgs eventArgs)
        {

            if (Verifica_Banco_Repetido() != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(STR_PGS_REP_NUM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

        }

        public void ID_PAR_PLA_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

        }

        public void ID_PAR_PRE_EB_Change(Object eventSender, EventArgs eventArgs)
        {

            if (bmExisteBanco)
            {
                pszArrBancos[iIndiceMat, 2] = StringsHelper.Format(ID_PAR_PRE_EB.CtlText, "#0");
                bCambioBancos = -1;
            }

        }


        private void ID_PAR_PRE_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != CORVB.KEY_BACK)
            {
                eventArgs.keyAscii = 0;
            }

        }

        public void ID_PAR_SEG_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

        }

        private void ID_PAR_PRE_EB_Leave(Object eventSender, EventArgs eventArgs)
        {
            if (Verifica_Banco_Repetido() != 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox(STR_PGS_REP_NUM, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
        }


        private void ID_PAR_TEL_EXT_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        private void ID_PAR_TEL_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;
            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8)
            {
                //UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant
                KeyAscii = CORVB.NULL_INTEGER;
            }
            if (KeyAscii == 0)
            {
                eventArgs.Handled = true;
            }
            eventArgs.KeyChar = Convert.ToChar(KeyAscii);
        }


        public void ID_PAR_THS_EB_KeyPress(ref  int KeyAscii)
        {

            switch (KeyAscii)
            {
                case 39:
                    KeyAscii = 32;
                    break;
            }
            KeyAscii = (int)Strings.Chr(KeyAscii).ToString().ToUpper()[0];

        }

        public void Inserta_Campos()
        {

            int hBanco = 0;
            int hBancos = 0;
            int hInsBanco = 0;
            int hParam = 0;
            string pszSQL = String.Empty;
            int iPtoCom = 0;

            if (bCambioBancos != 0)
            {
                CORVAR.pszgblsql = "DELETE FROM " + CORBD.DB_SYB_CON;

                //Solo si se borran los bancos se vuelven a guardar con los nuevos datos de la matriz

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

                    for (int iCont = pszArrBancos.GetLowerBound(0); iCont <= pszArrBancos.GetUpperBound(0); iCont++)
                    {
                        if (Conversion.Val(pszArrBancos[iCont, 0]) != CORVB.NULL_INTEGER && pszArrBancos[iCont, 1].Trim() != CORVB.NULL_STRING && pszArrBancos[iCont, 1].Trim() != "Nuevo")
                        {
                            CORVAR.pszgblsql = "INSERT INTO " + CORBD.DB_SYB_CON + " (con_banco,con_ban_des,con_pref,con_gpo,con_emp) ";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + "VALUES (" + pszArrBancos[iCont, 0].Trim() + ",'";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + pszArrBancos[iCont, 1].Trim() + "',";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + pszArrBancos[iCont, 2].Trim() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + pszArrBancos[iCont, 3].Trim() + ",";
                            CORVAR.pszgblsql = CORVAR.pszgblsql + pszArrBancos[iCont, 4].Trim() + ")";


                            if (CORPROC2.Modifica_Registro() != 0)
                            {
                            }
                            else
                            {
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                //AIS-1182 NGONZALEZ
                                CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                                return;
                            }
                            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                        }
                    }
                }
                else
                {
                    //AIS-1182 NGONZALEZ
                    CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                }
            }

            //se verifica el puerto del modem
            //  If ID_PAR_COM1_OB.Value = True Then
            //     iPtoCom = 1
            //  ElseIf ID_PAR_COM2_OB.Value = True Then
            //     iPtoCom = 2
            //  ElseIf ID_PAR_COM3_OB.Value = True Then
            //     iPtoCom = 3
            //  ElseIf ID_PAR_COM4_OB.Value = True Then
            //     iPtoCom = 4
            //  End If


            //Se actualizan los parametros generales
            CORVAR.pszgblsql = "UPDATE " + CORBD.DB_SYB_PGS + " SET";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_emp = '" + ID_PAR_EMP_EB.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_mes_oper = " + (ID_PAR_MES_COB.SelectedIndex + 1).ToString().Trim() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_dia_corte = " + ID_PAR_DIA_EB.CtlText.Trim() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ver = " + ID_PAR_VER_EB.CtlText.Trim() + ",";
            //  pszgblSql = pszgblSql + " pgs_path = '" + Trim$(ID_PAR_DIR_EB.Text) + "',"
            //  pszgblsql = pszgblsql + " pgs_ths = '" + Trim$(ID_PAR_THS_EB.Text) + "',"
            //  pszgblsql = pszgblsql + " pgs_pla = '" + Trim$(ID_PAR_PLA_EB.Text) + "',"
            //  pszgblsql = pszgblsql + " pgs_his = '" + Trim$(ID_PAR_HIS_EB.Text) + "',"
            //  pszgblsql = pszgblsql + " pgs_ara = '" + Trim$(ID_PAR_ARE_EB.Text) + "',"
            //  pszgblsql = pszgblsql + " pgs_sgo = '" + Trim$(ID_PAR_SEG_EB.Text) + "',"
            //  pszgblsql = pszgblsql + " pgs_neg = '" + Trim$(ID_PAR_NEG_EB.Text) + "',"
            //  pszgblsql = pszgblsql + " pgs_act = '" + Trim$(ID_PAR_ACT_EB.Text) + "',"
            //  pszgblsql = pszgblsql + " pgs_acl = '" + Trim$(ID_PAR_ACL_EB.Text) + "',"
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_incremento = " + VB6.GetItemString(ID_PAR_INC_COB, ID_PAR_INC_COB.SelectedIndex).Trim() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_telefono = '" + ID_PAR_TEL_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_tel_lada = '" + ID_PAR_LADA_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_fax = '" + ID_PAR_FAX_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_fax_lada = '" + ID_PAR_FAX_LADA_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_vel_transmis  = 0" + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_pto_modem  = 0" + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_email  = '" + ID_PAR_EMAIL_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_internet = '" + ID_PAR_INTER_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_extension  = '" + ID_PAR_TEL_EXT_TXT.Text.Trim() + "'";

            if (CORPROC2.Modifica_Registro() != 0)
            {
                //    If Dir$(Trim$(ID_PAR_DIR_EB.Text)) <> NULL_STRING Then
                //      pszgblPath = Trim$(ID_PAR_DIR_EB.Text)
                //    Else
                CORVAR.pszgblPath = Directory.GetCurrentDirectory();
                //    End If
                this.Cursor = Cursors.WaitCursor;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Se han modificado los parámetros generales.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                this.Cursor = Cursors.Default;
            }
            else
            {
                //AIS-1182 NGONZALEZ
                CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

        }

        public bool Verifica_Banco_Borrado()
        {

            int iCont = 0;
            int hBanco = 0;
            int iGrupo = 0;

            bool bExiste = false;
            int iBanco = CORVB.NULL_INTEGER;

            //For iCont = LBound(pszArrBancos, 1) To UBound(pszArrBancos, 1)
            //If Trim$(pszArrBancos(iCont, 1)) = NULL_STRING Then
            CORVAR.pszgblsql = "SELECT gpo_num FROM " + CORBD.DB_SYB_COR + " where eje_prefijo= " + ID_PAR_PRE_EB.CtlText + " and gpo_banco = " + ID_PAR_NUM_EB.CtlText;
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                //Obtiene cuantos grupos existen

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, CORCONST.FIRST_COL)));
                    if (iGrupo > CORVB.NULL_INTEGER)
                    {
                        bExiste = true;
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    }
                };
                if (!bExiste)
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                }
            }
            else
            {
                //AIS-1182 NGONZALEZ
                CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            //End If
            //Next
            return bExiste;
        }

        public int Verifica_Banco_Repetido()
        {

            int result = 0;
            int iRepetido = 0;

            if (bmExisteBanco)
            {
                iRepetido = 0;
                for (int iCont = pszArrBancos.GetLowerBound(0); iCont <= pszArrBancos.GetUpperBound(0); iCont++)
                {
                    if (iCont != iIndiceMat)
                    {
                        if (ID_PAR_NUM_EB.CtlText == pszArrBancos[iCont, 0])
                        {
                            iRepetido = -1;
                            break;
                        }
                    }
                }
                result = iRepetido;
            }

            return result;
        }

        public int Verifica_Empresa_Repetida(int iRenglon)
        {

            int result = 0;
            int hParam = 0;
            int bExiste = 0;

            if (bmExisteBanco)
            {
                bExiste = 0;
                for (int iCont = pszArrBancos.GetLowerBound(0); iCont <= pszArrBancos.GetUpperBound(0); iCont++)
                {
                    if (Conversion.Val(pszArrBancos[iCont, 0]) != 0)
                    {
                        CORVAR.pszgblsql = "select";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " emp_num";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " from MTCEMP01";
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " where eje_prefijo = " + ID_PAR_PRE_EB.CtlText;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and gpo_banco = " + ID_PAR_NUM_EB.CtlText;
                        CORVAR.pszgblsql = CORVAR.pszgblsql + " and emp_num = " + pszArrBancos[iCont, 4].ToString();

                        if (CORPROC2.Obtiene_Registros() != 0)
                        {
                            if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                            {
                                bExiste = -1;
                                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                                break;
                            }
                        }
                        CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    }
                }
                result = bExiste;
            }

            return result;
        }

        private void ID_PAR_VER_EB_KeyPressEvent(Object eventSender, AxMSMask.MaskEdBoxEvents_KeyPressEvent eventArgs)
        {

            if ((eventArgs.keyAscii < 48 || eventArgs.keyAscii > 57) && eventArgs.keyAscii != 8 && eventArgs.keyAscii != 46)
            {
                eventArgs.keyAscii = (short)CORVB.NULL_INTEGER;
            }

        }

        public void limpia_campos()
        {

            ID_PAR_MES_COB.SelectedIndex = 0;
            ID_PAR_NUM_EB.CtlText = CORVB.NULL_STRING;
            ID_PAR_PRE_EB.CtlText = CORVB.NULL_STRING;
            ID_PAR_GRU_EB.CtlText = "1";
            ID_PAR_CON_EB.CtlText = ID_PAR_INC_COB.Text;
            ID_PAR_DIA_EB.CtlText = "1";
            ID_PAR_VER_EB.CtlText = CORVB.NULL_STRING;
            ID_PAR_TEL_TXT.Text = CORVB.NULL_STRING;
            ID_PAR_LADA_TXT.Text = CORVB.NULL_STRING;
            ID_PAR_FAX_TXT.Text = CORVB.NULL_STRING;
            ID_PAR_FAX_LADA_TXT.Text = CORVB.NULL_STRING;
            ID_PAR_EMAIL_TXT.Text = CORVB.NULL_STRING;
            ID_PAR_INTER_TXT.Text = CORVB.NULL_STRING;
            ID_PAR_TEL_EXT_TXT.Text = CORVB.NULL_STRING;
            //    ID_PAR_COM_TRA_COB.ListIndex = 0

            //Puerto de Comunicaciones
            //    ID_PAR_COM1_OB.Value = True
            //    ID_PAR_COM2_OB.Value = False
            //    ID_PAR_COM3_OB.Value = False
            //    ID_PAR_COM4_OB.Value = False
            //    ID_PAR_NOM_COB.SetFocus

            //Configuración de Longitudes
            ID_PAR_LEM_EB.defaultText = CORVB.NULL_STRING;
            ID_PAR_LEJ_EB.defaultText = CORVB.NULL_STRING;

        }

        public void Inserta_Banco()
        {
            int iPtoCom = 0;

            //UPGRADE_TODO: (1069) Error handling statement (On Error Resume Next) was converted to a complex pattern which might not be equivalent to the original.
            try
            {

                CORVAR.pszgblsql = "insert into MTCCON01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(con_banco,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_ban_des,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_pref,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_gpo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_emp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_tipo_prod,";
                //* APQ 20-Feb-2008 - Se agrega nombre de campo ya que por default no acepta null
                CORVAR.pszgblsql = CORVAR.pszgblsql + " con_product_line)";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " values";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(" + ID_PAR_NUM_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_PAR_NOM_COB.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_PRE_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_GRU_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_CON_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'D'";
                //* APQ 20-Feb-2008 - Se agrega valor de campo ya que por default no acepta null
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0)";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                }
                else
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    //AIS-1182 NGONZALEZ
                    CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    return;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


                //   If ID_PAR_COM1_OB.Value = True Then
                //       iPtoCom = 1
                //   ElseIf ID_PAR_COM2_OB.Value = True Then
                //       iPtoCom = 2
                //   ElseIf ID_PAR_COM3_OB.Value = True Then
                //       iPtoCom = 3
                //   ElseIf ID_PAR_COM4_OB.Value = True Then
                //       iPtoCom = 4
                //   End If

                CORVAR.pszgblsql = "insert into MTCPGS01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "(pgs_emp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_dia_corte,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_mes_oper,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ver,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_path,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ths,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_pla,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_his,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ara,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_sgo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_neg,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_act,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_acl,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_folio,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_incremento,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_telefono,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_extension,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_tel_lada,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_fax,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_fax_lada,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_par_comu,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_vel_transmis,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_pto_modem,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_email,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_internet,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_fec,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_fec_ant,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_banco,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_prefijo,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_porc_comp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_porc_disp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_emp,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_eje,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_uni,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_cli,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_long_rep,";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_tipo_prod)";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " values(";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "'" + ID_PAR_EMP_EB.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_DIA_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + (ID_PAR_MES_COB.SelectedIndex + 1).ToString();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_VER_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",' '";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + (VB6.GetItemString(ID_PAR_INC_COB, ID_PAR_INC_COB.SelectedIndex));
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_PAR_TEL_TXT.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_PAR_TEL_EXT_TXT.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_PAR_LADA_TXT.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_PAR_FAX_TXT.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_PAR_FAX_LADA_TXT.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",''";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_PAR_EMAIL_TXT.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'" + ID_PAR_INTER_TXT.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_NUM_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_PRE_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",0";
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_LEM_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + "," + ID_PAR_LEJ_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",5";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",12";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",3";
                CORVAR.pszgblsql = CORVAR.pszgblsql + ",'D')";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    MessageBox.Show("Se dio de alta correctamente el Banco", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                    //AIS-1182 NGONZALEZ
                    CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                    return;
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            }
            catch (Exception exc)
            {
                throw new Exception("Migration Exception: The following exception could be handled in a different way after the conversion: " + exc.Message);
            }

        }

        public void Modifica_Bancos()
        {

            int hBanco = 0;
            int hBancos = 0;
            int hInsBanco = 0;
            int hParam = 0;
            int iCont = 0;
            string pszSQL = String.Empty;
            int iPtoCom = 0;

            if (bCambioBancos != 0)
            {
                CORVAR.pszgblsql = "update MTCCON01";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " set con_ban_des = '" + ID_PAR_NOM_COB.Text.Trim() + "'";
                CORVAR.pszgblsql = CORVAR.pszgblsql + " where con_pref = " + ID_PAR_PRE_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and con_banco  = " + ID_PAR_NUM_EB.CtlText.Trim();
                CORVAR.pszgblsql = CORVAR.pszgblsql + " and con_tipo_prod  = 'D'";

                if (CORPROC2.Modifica_Registro() != 0)
                {
                    CORVAR.pszgblPath = Directory.GetCurrentDirectory();
                }
                else
                {
                    //AIS-1182 NGONZALEZ
                    CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
                }
                CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
                this.Cursor = Cursors.Default;
            }

            //Se verifica el puerto del modem
            //    If ID_PAR_COM1_OB.Value = True Then
            //        iPtoCom = 1
            //    ElseIf ID_PAR_COM2_OB.Value = True Then
            //        iPtoCom = 2
            //    ElseIf ID_PAR_COM3_OB.Value = True Then
            //        iPtoCom = 3
            //    ElseIf ID_PAR_COM4_OB.Value = True Then
            //        iPtoCom = 4
            //    End If

            //Se actualizan los parametros generales
            CORVAR.pszgblsql = "update MTCPGS01";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " set pgs_emp = '" + ID_PAR_EMP_EB.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_mes_oper = " + (ID_PAR_MES_COB.SelectedIndex + 1).ToString().Trim() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_dia_corte = " + ID_PAR_DIA_EB.CtlText.Trim() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ver = " + ID_PAR_VER_EB.CtlText.Trim() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ths = ' ',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_pla = ' ',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_his = ' ',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_ara = ' ',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_sgo = ' ',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_neg = ' ',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_act = ' ',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_acl = ' ',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_incremento = " + VB6.GetItemString(ID_PAR_INC_COB, ID_PAR_INC_COB.SelectedIndex).Trim() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_telefono = '" + ID_PAR_TEL_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_tel_lada = '" + ID_PAR_LADA_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_fax = '" + ID_PAR_FAX_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_fax_lada = '" + ID_PAR_FAX_LADA_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_vel_transmis  = 0" + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_pto_modem  = 0" + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_email  = '" + ID_PAR_EMAIL_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_internet = '" + ID_PAR_INTER_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_extension  = '" + ID_PAR_TEL_EXT_TXT.Text.Trim() + "',";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_prefijo = " + ID_PAR_PRE_EB.CtlText.Trim() + ",";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " pgs_rep_banco   = " + ID_PAR_NUM_EB.CtlText.Trim();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where pgs_rep_prefijo = " + ID_PAR_PRE_EB.CtlText.Trim();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and pgs_rep_banco = " + ID_PAR_NUM_EB.CtlText.Trim();
            CORVAR.pszgblsql = CORVAR.pszgblsql + " and pgs_tipo_prod = 'D'";

            if (CORPROC2.Modifica_Registro() != 0)
            {
                CORVAR.pszgblPath = Directory.GetCurrentDirectory();
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Se han modificado los parámetros generales.", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            else
            {
                //AIS-1182 NGONZALEZ
                CORVAR.igblErr = API.USER.PostMessage(CORMNPAR.DefInstance.Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;

        }

        //UPGRADE_NOTE: (7001) The following declaration (prLimpiaCampos) seems to be dead code
        //private void  prLimpiaCampos()
        //{
        //ID_PAR_MES_COB.SelectedIndex = 0;
        //ID_PAR_NUM_EB.CtlText = CORVB.NULL_STRING;
        //ID_PAR_PRE_EB.CtlText = CORVB.NULL_STRING;
        //
        //ID_PAR_GRU_EB.CtlText = "1";
        //ID_PAR_CON_EB.CtlText = ID_PAR_INC_COB.Text;
        //ID_PAR_DIA_EB.CtlText = "1";
        //
        //ID_PAR_VER_EB.CtlText = CORVB.NULL_STRING;
        //
        //ID_PAR_TEL_TXT.Text = CORVB.NULL_STRING;
        //ID_PAR_LADA_TXT.Text = CORVB.NULL_STRING;
        //ID_PAR_FAX_TXT.Text = CORVB.NULL_STRING;
        //ID_PAR_FAX_LADA_TXT.Text = CORVB.NULL_STRING;
        //ID_PAR_EMAIL_TXT.Text = CORVB.NULL_STRING;
        //ID_PAR_INTER_TXT.Text = CORVB.NULL_STRING;
        //ID_PAR_TEL_EXT_TXT.Text = CORVB.NULL_STRING;
        //  ID_PAR_COM_TRA_COB.ListIndex = 0
        //
        //puerto de comunicaciones
        //  ID_PAR_COM1_OB.Value = True
        //  ID_PAR_COM2_OB.Value = False
        //  ID_PAR_COM3_OB.Value = False
        //  ID_PAR_COM4_OB.Value = False
        //ID_PAR_NOM_COB.Focus();
        //
        //Configuración de Longitudes
        //ID_PAR_LEM_EB.defaultText = CORVB.NULL_STRING;
        //ID_PAR_LEJ_EB.defaultText = CORVB.NULL_STRING;
        //}
        private void CORMNPAR_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ID_PAR_LEM_EB_Change(object sender, EventArgs e)
        {

        }

    }
}