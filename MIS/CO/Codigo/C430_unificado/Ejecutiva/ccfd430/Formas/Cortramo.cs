//AIS-1167 NGONZALEZ
using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    internal partial class CORTRAMO
        : System.Windows.Forms.Form
    {

        private void CORTRAMO_Activated(Object eventSender, EventArgs eventArgs)
        {
            if (ActivateHelper.myActiveForm != this)
            {
                ActivateHelper.myActiveForm = this;
            }
        }


        int iHandshaking = 0;
        string[] iArrayNomArch = null;
        string[] ArrayNombres = null;

        int lNumEmp = 0;
        int iNumGpo = 0;
        string pszNomArchivo = String.Empty;
        string pszArchivo = String.Empty;
        string pszParametros = String.Empty;

        string pszErrorConec = String.Empty;
        string pszBandera = String.Empty;

        object hSend = null;
        int lFilePos = 0;
        int iNumArchivo = 0;
        int iNumArchSelec = 0;
        string pszCadArch = String.Empty;
        string pszPathArch = String.Empty;
        int iErr = 0;

        int iNumPuerto = 0;
        string pszPathEmp = String.Empty;

        // variables de ventanas anexas
        int TempProtocol = 0;
        string DownloadDir = String.Empty;
        string UploadDir = String.Empty;
        string InitialDir = String.Empty;
        string Msg = String.Empty;

        int DataFileNum = 0;
        int CurModemNumber = 0;

        //AIS-1178 NGONZALEZ
        COMMCTRL.MWSettings[] MWPhoneEntry;// = ArraysHelper.InitializeArray<Acceso[]>(new int[]{});;

        string Work = String.Empty;
        string FileStamp = String.Empty;
        int Spac = 0;
        object CurOpt = null;
        object FileNLen = null;
        int iNoPuerto = 0;

        const int SHIFT_MASK = 1;
        const int CTRL_MASK = 2;

        const int KEY_DELETE = 0x2E;
        const int KEY_INSERT = 0x2D;
        const int KEY_NEXT = 0x22;
        const int KEY_PRIOR = 0x21;

        //UPGRADE_NOTE: (7001) The following declaration (Valida_Datos) seems to be dead code
        //private string Valida_Datos()
        //{
        //
        //string result = String.Empty;
        //result = (true).ToString();
        //
        //if (TxtFilename.Text == "")
        //{
        ////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
        ////UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
        //Interaction.MsgBox("Seleccione un archivo.", (MsgBoxStyle) (((int) CORVB.MB_OK) + ((int) CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
        //return (false).ToString();
        //}
        //''''
        //''''  If CmbProtocol.ListIndex < 0 Then
        //''''    MsgBox "Seleccione un protocolo.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    CmbProtocol.SetFocus
        //''''    Exit Function
        //''''  End If
        //''''
        //''''  If txtNumero.Text = "" Then
        //''''    MsgBox "Proporcione numero a Marcar", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    txtNumero.SetFocus
        //''''    Exit Function
        //''''  End If
        //
        //''''  If InStr(txtNumero.Text, ",") > 0 Then
        //''''    If InStr(txtNumero.Text, ",") <> 3 Then
        //''''      MsgBox "La posición de la coma es incorrecto.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''      Valida_Datos = False
        //''''      txtNumero.SetFocus
        //''''      Exit Function
        //''''    End If
        //''''  End If
        //''''
        //''''  If CmbProtocol.ListIndex = 8 And UCase(Right(TxtFilename.Text, 3)) <> "TXT" Then
        //''''    MsgBox "Para el protocolo ASCII se requieren archivos .TXT", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    Exit Function
        //''''  End If
        //''''
        //''''  If (CmbProtocol.ListIndex = 8 Or CmbProtocol.ListIndex = 0 Or CmbProtocol.ListIndex = 1 Or CmbProtocol.ListIndex = 2) And iNumArchSelec > 1 Then
        //''''    MsgBox "Para el protocolo ASCII y XMODEM se requiere seleccionar un solo archivo TXT", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    Exit Function
        //''''  End If
        //
        //''''  If CmbComPort.ListIndex < 0 Then
        //''''    MsgBox "Se requiere capturar el número de puerto.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    CmbComPort.SetFocus
        //''''    Exit Function
        //''''  End If
        //
        //''''  If CmbBaudRate.ListIndex < 0 Then
        //''''    MsgBox "Se requiere capturar la velocidad de transmisión.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    CmbBaudRate.SetFocus
        //''''    Exit Function
        //''''  End If
        //''''
        //''''  If CmbDataBits.ListIndex < 0 Then
        //''''    MsgBox "Se requiere capturar el bits de datos", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    CmbDataBits.SetFocus
        //''''    Exit Function
        //''''  End If
        //''''
        //''''  If CmbParity.ListIndex < 0 Then
        //''''    MsgBox "Se requiere capturar el bits de paridad.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    CmbParity.SetFocus
        //''''    Exit Function
        //''''  End If
        //''''
        //''''  If CmbStopBits.ListIndex < 0 Then
        //''''    MsgBox "Se requiere capturar el bits de parada.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Valida_Datos = False
        //''''    CmbStopBits.SetFocus
        //''''    Exit Function
        //''''  End If
        //
        //return result;
        //}

        private void cmdSalir_Click(Object eventSender, EventArgs eventArgs)
        {

            //descueldga el telefono
            //''''CMTPDQCOM EISSA 30.11.2001
            //''''    If Comm1.CDHolding = False Then
            //''''        Resetea_Modem
            this.Close();
            //''''  Else
            //''''    MsgBox "Cuelgue antes de salir. ", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
            //''''  End If
            //'''' Fin CMTPDQCOM EISSA 30.11.2001


        }


        //UPGRADE_WARNING: (1041) Form_Load event was upgraded to Form_Load method and has a new behavior.
        private void Form_Load()
        {
            int iGrupos = 0;
            int iLeft = 0;
            int iTop = 0;
            this.Cursor = Cursors.WaitCursor;
            this.Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.Width)) - ((float)VB6.PixelsToTwipsX(this.Width))) / 2);
            this.Top = (int)VB6.TwipsToPixelsY((((float)VB6.PixelsToTwipsY(CORMDIBN.DefInstance.Height)) - ((float)VB6.PixelsToTwipsY(this.Height))) / 2);
            this.Refresh();
            //''''  Call Agrega_Items
            cmdEnvia.Enabled = false;
            pszBandera = (false).ToString();
            pszNomArchivo = "";
            iNumArchivo = 1;
            Left = (int)VB6.TwipsToPixelsX((((float)VB6.PixelsToTwipsX(CORMDIBN.DefInstance.ClientRectangle.Width)) - ((float)VB6.PixelsToTwipsX(Width))) / 2);
            Top = (int)VB6.TwipsToPixelsY(1550);
            this.Refresh();
            //  Call Resetea_Modem
            //''''   LoadModemSettings Comm1
            this.Cursor = Cursors.WaitCursor;
            iErr = CORCONST.OK;
            do
            {
                iGrupos = Carga_Grupos();
                if (ID_MCO_GRU_COB.Items.Count == CORVB.NULL_INTEGER)
                {
                    this.Cursor = Cursors.Default;
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                    //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                    Interaction.MsgBox("No existen Grupos en catálogo " + Strings.Chr(CORVB.KEY_RETURN).ToString() + "¿Desea dar de Alta ?", (MsgBoxStyle)(CORVB.MB_ICONQUESTION + CORVB.MB_YESNO), CORSTR.STR_APP_TIT);
                    this.Cursor = Cursors.WaitCursor;
                }
            }
            while ((ID_MCO_GRU_COB.Items.Count | ((iErr != CORCONST.OK) ? -1 : 0)) == 0);
            //obtiene numero de puerto del modem
            CORVAR.pszgblsql = "select pgs_pto_modem from MTCPGS01";
            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    iNoPuerto = Int32.Parse(VBSQL.SqlData(CORVAR.hgblConexion, 1));
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);
            this.Cursor = Cursors.Default;
        }



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
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select gpo_num, gpo_nom from " + DB_SYB_COR + " where gpo_banco=" + Format$(igblBanco)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select gpo_num, gpo_nom from " + CORBD.DB_SYB_COR + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                ID_MCO_GRU_COB.Items.Clear();
                iCont = CORVB.NULL_INTEGER;

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    iNumGrupo = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszNomGrupo = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    ID_MCO_GRU_COB.Items.Add(StringsHelper.Format(iNumGrupo, "0000") + "  " + pszNomGrupo);
                    iCont++;
                };

                //Colocamos a un grupo por default
                if (ID_MCO_GRU_COB.Items.Count != 0)
                {
                    ID_MCO_GRU_COB.SelectedIndex = CORVB.NULL_INTEGER;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);

            this.Cursor = Cursors.Default;

            return 0;
        }



        public void Define_Archivos()
        {
            int J = 0;
            StringBuilder pszNombre = new StringBuilder();
            pszNombre.Append(String.Empty);

            iNumArchSelec = 0;
            pszCadArch = "";
            pszPathArch = "";


            ID_MCO_FIL_FLB.Path = pszPathEmp;

            for (int I = 1; I <= ID_MCO_FIL_FLB.Items.Count; I++)
            {
                if (ID_MCO_FIL_FLB.GetSelected(I - 1))
                {
                    J++;
                }
            }

            //redimensionamos el array para los nombres de los archivos
            iNumArchSelec = J;
            iArrayNomArch = ArraysHelper.InitializeArray<string[]>(new int[] { iNumArchSelec + 1 }, new int[] { 0 });
            ArrayNombres = ArraysHelper.InitializeArray<string[]>(new int[] { iNumArchSelec + 1 }, new int[] { 0 });
            J = 0;
            for (int I = 1; I <= ID_MCO_FIL_FLB.Items.Count; I++)
            {

                //si el archivo fue seleccionado
                if (ID_MCO_FIL_FLB.GetSelected(I - 1))
                {


                    //se asigna el directorio y nombre completo
                    if (ID_MCO_FIL_FLB.Path.Trim().EndsWith("\\"))
                    {
                        pszArchivo = ID_MCO_FIL_FLB.Path.Trim() + ID_MCO_FIL_FLB.get_Items(I - 1); //ID_MCO_FIL_FLB.filename
                    }
                    else
                    {
                        pszArchivo = ID_MCO_FIL_FLB.Path.Trim() + "\\" + ID_MCO_FIL_FLB.get_Items(I - 1); //ID_MCO_FIL_FLB.filename
                    }

                    //concatena la cadena para email
                    if (pszCadArch == "")
                    {
                        pszCadArch = ID_MCO_FIL_FLB.get_Items(I - 1);
                        pszPathArch = pszArchivo;
                        pszNombre = new StringBuilder(ID_MCO_FIL_FLB.get_Items(I - 1));
                    }
                    else
                    {
                        pszCadArch = pszCadArch + ";" + ID_MCO_FIL_FLB.get_Items(I - 1);
                        pszPathArch = pszPathArch + ";" + pszArchivo;
                        pszNombre.Append(" " + ID_MCO_FIL_FLB.get_Items(I - 1));

                    }


                    ArrayNombres[J] = ID_MCO_FIL_FLB.get_Items(I - 1);
                    iArrayNomArch[J] = pszArchivo;
                    J++;

                }
            }

            TxtFilename.Text = pszNombre.ToString();
            LblPath.Text = ID_MCO_FIL_FLB.Path;

        }




        public void Envia_Mail()
        {

            this.Cursor = Cursors.WaitCursor;

            try
            {


                ID_MCOM_MAIL.MsgIndex = -1;
                //Activa la Sesión
                ID_MCOM_SESS.Action = 1;
                ID_MCOM_MAIL.SessionID = ID_MCOM_SESS.SessionID;
                //Crea Información del Mensaje
                ID_MCOM_MAIL.Compose();
                ID_MCOM_MAIL.RecipDisplayName = ID_MCO_EMAIL_TXT.Text; //"jacosta@banamex.com"
                ID_MCOM_MAIL.MsgReceiptRequested = true;
                ID_MCOM_MAIL.MsgSubject = "Transmisión de Archivos vía Email.";
                for (int I = 0; I <= iNumArchSelec - 1; I++)
                {
                    ID_MCOM_MAIL.AttachmentIndex = I; //ID_MCOM_MAIL.AttachmentCount + 1
                    ID_MCOM_MAIL.AttachmentName = ArrayNombres[I]; //"pbamail.txt"
                    ID_MCOM_MAIL.AttachmentPathName = iArrayNomArch[I]; //"c:\Corbnx32\pbamail.txt"
                    ID_MCOM_MAIL.AttachmentPosition = 0; //ID_MCOM_MAIL.AttachmentIndex
                    ID_MCOM_MAIL.AttachmentType = 0;
                }
                ID_MCOM_MAIL.MsgNoteText = "              ";

                //Desactiva la Sesión
                ID_MCOM_MAIL.Action = 2;
                ID_MCOM_SESS.Action = 2;
            }
            catch
            {



                this.Cursor = Cursors.Default;
            }


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
        //**                                                                        **
        //**                                                                        **
        //****************************************************************************
        private int Obten_Empresas()
        {

            int result = 0;
            int iTempErr = 0; //Control local
            string pszEmpresa = String.Empty; //La empresa a obtener
            int lNumEmpresa = 0; //El consecutivo de la empresa

            this.Cursor = Cursors.WaitCursor;
            int iNumGrupo = Convert.ToInt32(Conversion.Val(ID_MCO_GRU_COB.Text.Substring(0, Math.Min(ID_MCO_GRU_COB.Text.Length, 4)))); //El grupo de quien se trata
            //***** INICIO CODIGO ANTERIOR FSWBMX *****
            //  pszgblsql = "select emp_num, emp_nom from " + DB_SYB_EMP + " where gpo_banco=" + Format$(igblBanco) + " and gpo_num =" + Format$(iNumGrupo)
            //***** FIN DE CODIGO ANTERIOR FSWBMX *****
            //***** INICIO CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = "select emp_num, emp_nom from " + CORBD.DB_SYB_EMP + " where eje_prefijo=" + CORVAR.igblPref.ToString() + " and gpo_banco=" + CORVAR.igblBanco.ToString() + " and gpo_num =" + iNumGrupo.ToString();
            //***** FIN DE CODIGO NUEVO FSWBMX *****
            CORVAR.pszgblsql = CORVAR.pszgblsql + " order by emp_num ";

            if (CORPROC2.Obtiene_Registros() != 0)
            {

                ID_MCO_EMP_LB.Items.Clear();

                while (VBSQL.SqlNextRow(CORVAR.hgblConexion) != VBSQL.NOMOREROWS)
                {
                    lNumEmpresa = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 1)));
                    pszEmpresa = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    //EISSA. 03-10-2001. Cambio para el formateo del número de empresa.
                    ID_MCO_EMP_LB.Items.Add(StringsHelper.Format(lNumEmpresa, Formato.sMascara(Formato.iTipo.Empresa)) + "   " + pszEmpresa);
                };

                if (ID_MCO_EMP_LB.Items.Count != 0)
                {
                    //      ID_MCO_EMP_LB.ListIndex = NULL_INTEGER
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





        private void Obtiene_DatosEmp()
        {
            string pszTelefono = String.Empty;
            string pszLada = String.Empty;
            int lVelTrans = 0;
            string pszEmail = String.Empty;
            string pszParam = String.Empty;

            this.Cursor = Cursors.WaitCursor;

            CORVAR.pszgblsql = "select emp_telefono,emp_tel_lada,emp_vel_transmis,emp_email,emp_param_modem from MTCEMP01 ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + " where emp_num = " + lNumEmp.ToString() + " and ";
            CORVAR.pszgblsql = CORVAR.pszgblsql + "gpo_num = " + iNumGpo.ToString();

            if (CORPROC2.Obtiene_Registros() != 0)
            {
                if (VBSQL.SqlNextRow(CORVAR.hgblConexion) == VBSQL.MOREROWS)
                {
                    pszTelefono = VBSQL.SqlData(CORVAR.hgblConexion, 1);
                    pszLada = VBSQL.SqlData(CORVAR.hgblConexion, 2);
                    lVelTrans = Convert.ToInt32(Conversion.Val(VBSQL.SqlData(CORVAR.hgblConexion, 3)));
                    pszEmail = VBSQL.SqlData(CORVAR.hgblConexion, 4);
                    pszParam = VBSQL.SqlData(CORVAR.hgblConexion, 5);
                }
            }
            CORVAR.igblRetorna = VBSQL.SqlCancel(CORVAR.hgblConexion);


            //'''' 'asigna datos a los controles
            //'''' txtNumero.Text = pszTelefono
            //'''' If lVelTrans = NULL_INTEGER Then
            //''''   CmbBaudRate.Text = " "
            //'''' Else
            //''''   CmbBaudRate.Text = lVelTrans
            //'''' End If
            //''''
            ID_MCO_EMAIL_TXT.Text = pszEmail;
            //''''
            //'''' CmbComPort.Text = iNoPuerto

            // Select Case Mid$(pszParam, 1, 1)
            //         Case "E"                                 'par
            //              CmbParity.Text = "Even"
            //         Case "N"                                 'ninguno
            //''''              CmbParity.Text = "None"
            //         Case "O"                                 'impar
            //              CmbParity.Text = "Odd"
            //  End Select

            //datos
            //  Select Case Mid$(pszParam, 3, 1)
            //         Case 4
            //              CmbDataBits.Text = "4"
            //         Case 5
            //              CmbDataBits.Text = "5"
            //         Case 6
            //              CmbDataBits.Text = "6"
            //         Case 7
            //              CmbDataBits.Text = "7"
            //         Case 8
            //''''              CmbDataBits.Text = "8"
            //  End Select

            //parada
            //  Select Case Mid$(pszParam, 5, 3)
            //         Case 1
            //''''              CmbStopBits.Text = "1"
            //         Case 1.5
            //              CmbStopBits.Text = "1.5"
            //         Case 2
            //              CmbStopBits.Text = "2"
            //  End Select




            this.Cursor = Cursors.Default;

        }


        private string Verifica_Mail()
        {

            string result = String.Empty;
            this.Cursor = Cursors.WaitCursor;

            result = (true).ToString();

            if (ID_MCO_EMAIL_TXT.Text == "")
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Se requiere la dirección Email.", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                result = (false).ToString();
                ID_MCO_EMAIL_TXT.Focus();
                return result;
            }

            if (iNumArchSelec == 0)
            {
                this.Cursor = Cursors.Default;
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Seleccione un archivo", (MsgBoxStyle)(((int)CORVB.MB_OK) + ((int)CORVB.MB_ICONEXCLAMATION)), CORSTR.STR_APP_TIT);
                return (false).ToString();
            }

            this.Cursor = Cursors.Default;

            return result;
        }
        //
        //
        //Private Sub Marca_Telefono(sTelefono As String)
        //
        //On Error Resume Next
        //
        //
        //Dim Element As Integer, OldShaking As Integer, OldEcho As Integer, AutoP As Integer, ErrLineNum As Integer, Dummy As Integer
        //Dim Tries As Integer, Result As Integer
        //Dim ModemBaud&, RealBaud&
        //Dim OldSettings$, ErrLine$, Mode$, Msg$, Temp$
        //Dim OK As Integer
        //
        //
        //
        //'Set session settings.
        //If Comm1.PortOpen Then Comm1.PortOpen = False
        //Comm1.CommPort = Val(CmbComPort.Text) 'iNoPuerto
        //Comm1.PortOpen = True
        //If Err Then
        //  Screen.MousePointer = DEFAULT
        //  MsgBox "El número de puerto no es valido.", MB_ICONEXCLAMATION + MB_OK, STR_APP_TIT
        //  Exit Sub
        //End If
        //Dummy = CondenseSettings(Temp$, Val(Trim$(CmbBaudRate.Text)), Mid$(Trim$(CmbParity.Text), 1, 1), Val(Trim$(CmbDataBits.Text)), Val(Trim$(CmbStopBits.Text)))
        //Comm1.Settings = Temp$
        //Comm1.Handshaking = iHandshaking
        //Comm1.DTREnable = ChkDTREnable.Value
        //Comm1.RTSEnable = ChkRTSEnable.Value
        //Comm1.Emulation = 0
        //Comm1.Backspace = 0
        //Comm1.Echo = 0
        //Comm1.InBufferCount = 0
        //'comm1.ForeColor = MWPhoneEntry(Element).ForeColor
        //'comm1.BackColor = MWPhoneEntry(Element).BackColor
        //'comm1.ColorFilter = MWPhoneEntry(Element).ColorFilter
        //'comm1.Rows = MWPhoneEntry(Element).Rows
        //'comm1.Columns = MWPhoneEntry(Element).Columns
        //'comm1.ScrollRows = MWPhoneEntry(Element).ScrollRows
        //'comm1.Font.Bold = MWPhoneEntry(Element).FontBold
        //'comm1.Font.Italic = MWPhoneEntry(Element).FontItalic
        //'comm1.Font.Size = MWPhoneEntry(Element).FontSize
        //'comm1.Font.Name = MWPhoneEntry(Element).FontName
        //'comm1.CursorType = MWPhoneEntry(Element).CursorType
        //
        //'-- Save AutoProcess
        //AutoP = Comm1.AutoProcess
        //
        //'-- This is the main dialing loop.
        //Tries = 0
        //
        //'-- Tell everyone we're dialing
        //Call MWStatus(MW_STAT_PHBOOK_DIALING, Trim$(sTelefono))
        //
        //'-- Call the ModemWare PlaceCall routine to dial the number.
        //Call PlaceCall(Comm1, sTelefono, 1, 90, Result, ModemBaud&, RealBaud&, Mode$)
        //
        //'Do
        //    '-- CARL! The user should be able to change the Timeout
        //    '-- What happenned?
        //    Select Case MWError()
        //           '-- Operation was canceled, port is not open, control can not be accessed, Timeout
        //           Case MW_ER_CANCELED, MW_ER_PORTCLOSED, MW_ER_CTRLERROR, MW_ER_TIMEOUT
        //              Call MWStatus(0, MWErrorMsg$())
        //           Case MW_PLACECALL_OK  '-- A valid result code was returned. Check Result
        //                Select Case Result
        //                      Case MW_RESULT_CONNECT
        //                          '-- CONNECT
        //                          Msg$ = "Connected at" & Str$(ModemBaud&)
        //                          If Len(Mode$) Then
        //                              Msg$ = Msg$ & " With " & Mode$
        //                          End If
        //                          Call MWStatus(0, Msg$)
        //                          cmdResetea.Enabled = True
        //                          cmdEnvia.Enabled = True
        //                          cmdMarcar.Enabled = False
        //                          Exit Sub 'Exit Do
        //                      Case MW_RESULT_NO_CARRIER
        //                          '-- NO CARRIER
        //                          Call MWStatus(0, "NO CARRIER")
        //                      Case MW_RESULT_ERROR
        //                          '-- ERROR
        //                          Call MWStatus(0, "The modem returned an error, retrying.")
        //                      Case MW_RESULT_NO_DIALTONE
        //                          '-- NO DIALTONE
        //                          Call MWStatus(0, "No dial tone. Check connections and try again.")
        //                      Case MW_RESULT_BUSY
        //                          '-- BUSY
        //                          Call MWStatus(0, "The line is busy, retrying.")
        //                          Tries = Tries + 1
        //                          Call MWStatus(MW_STAT_PHBOOK_REDIAL, Str$(Tries))
        //                          MWPause 1
        //                          Comm1.InBufferCount = 0
        //                          Comm1.OutBufferCount = 0
        //                      Case MW_RESULT_NO_ANSWER
        //                          '-- NO ANSWER
        //                          Call MWStatus(0, "There is no answer.")
        //                      Case MW_RESULT_TIMEOUT
        //                          '-- TIMEOUT
        //                          Call MWStatus(0, "The modem is returning 'TIMEOUT'.")
        //                End Select
        //    End Select
        //    MWPause 1
        //'Loop
        //
        //End Sub

        //Public Sub Transmite_Archivo()
        //'-- This routine gets a filename (if applicable) and uploads it (send)
        //
        //Dim Protocol As Integer
        //Dim Flags    As Integer
        //Dim Spac     As Integer
        //Dim ErrCode  As Integer
        //Dim Filename As String
        //Dim Prot     As String
        //Dim file     As String
        //Dim FPath    As String
        //
        //    MW_TransferType = MW_XFER_UPLOAD
        //    InitialDir = UploadDir
        //
        //    'Get the protocol that was selected.
        //    Protocol = Me.CmbProtocol.ListIndex
        //    If Protocol <> 8 Then Comm1.XferProtocol = Protocol
        //
        //    MW_TransferProtocol = Protocol
        //    Comm1.XferStatusDialog = PDQ_XFERDIALOG_MODELESS
        //
        //    'Get the filename.
        //    Filename = TxtFilename.Text
        //
        //    '-- Are we recording a script?
        //    If MW_ScriptRecording Then
        //        Select Case Protocol
        //            Case 8
        //                GoTo MWStartUpload:
        //            Case PDQ_XMODEM_CHECKSUM
        //                Prot = "XMODEM-CHECKSUM"
        //            Case PDQ_XMODEM_CRC
        //                Prot = "XMODEM-CRC"
        //            Case PDQ_XMODEM_1K
        //                Prot = "XMODEM-1K"
        //            Case PDQ_YMODEM_BATCH
        //                Prot = "YMODEM-BATCH"
        //            Case PDQ_YMODEM_G
        //                Prot = "YMODEM-G"
        //            Case PDQ_ZMODEM
        //                Prot = "ZMODEM"
        //            Case PDQ_KERMIT
        //                Prot = "KERMIT"
        //            Case PDQ_COMPUSERVE_BPLUS
        //                Prot = "COMPUSERVE"
        //        End Select
        //        AddToRecScriptData "PROTOCOL", Prot
        //    End If
        //
        //    'Get the path, if one is not included in the file name.
        //    If (Mid$(Filename, 2, 1) = ":") Or (Left$(Filename, 1) = "\") Then
        //        'Assume full path provided
        //        FPath = ""
        //    Else
        //        'Assume relative path provided
        //        FPath = LblPath.Caption
        //        'Add a backslash if it doesn't end in one
        //        If Not Right$(FPath, 1) = "\" Then FPath = FPath & "\"
        //    End If
        //
        //MWStartUpload:
        //
        //    '-- Upload
        //    If Protocol = 8 Then    '-- ASCII
        //
        //        Call MWStatus(0, "Transmitiendo Archivo en ASCII")
        //        Call AsciiSend(Comm1, FPath & Filename, ErrCode)
        //        Select Case ErrCode
        //               '-- Operation was canceled, Carrier was lost, port does not exist or cannot be accessed
        //               Case MW_ER_CANCELED, MW_ER_LOST_CARRIER, MW_ER_PORTCLOSED, MW_ER_CTRLERROR
        //                    Msg$ = MWErrorMsg$()
        //               Case MW_ASCIISEND_NOTFOUND  '-- File not found.
        //                    Msg$ = "Archivo no Encontrado"
        //               Case MW_ASCIISEND_FILE_ERR  '-- Error reading file.
        //                    Msg$ = "Error al Intentar Leer el Archivo : " & Filename$
        //               Case MW_ASCIISEND_OK        '-- File sent ok.
        //                    Msg$ = "Transferencia del Archivo Completa."
        //        End Select
        //        Call MWStatus(0, Msg)
        //
        //    Else 'Non-ASCII
        //
        //        Spac = InStr(Filename, " ")
        //        Do While Spac
        //            file = Left$(Filename, Spac - 1)
        //            Filename = Mid$(Filename, Spac + 1)
        //            If MW_ScriptRecording Then AddToRecScriptData "UPLOAD", UCase$(FPath) & UCase$(file)
        //            Comm1.Upload = UCase$(FPath) & file$
        //            Debug.Print "Uploading "; FPath & file
        //            Spac = InStr(Filename, " ")
        //        Loop
        //        If MW_ScriptRecording Then AddToRecScriptData "UPLOAD", UCase$(Filename)
        //        Comm1.Upload = FPath & Filename
        //        Debug.Print "Uploading "; FPath & Filename
        //
        //    End If
        //
        //
        //End Sub
        //
        //Sub AsciiSend(Comm1 As Control, Filename$, CDFlag)
        //'-- This routine sends a file via the ASCII protocol
        //
        //Dim Handle      As Integer
        //Dim AutoP       As Integer
        //Dim RT          As Integer
        //Dim NextLine    As String
        //
        //    '-- Test Comm port validity
        //    On Error Resume Next
        //    If Comm1.PortOpen = False Then
        //        '-- Port it closed
        //        MWSetError MW_ER_PORTCLOSED
        //        Exit Sub
        //    End If
        //    If Err Then
        //        '-- Port can not be accessed
        //        MWSetError MW_ER_CTRLERROR
        //        Exit Sub
        //    End If
        //
        //    '-- InitModemWare initializes MW_CR$, MW_LF$, etc.
        //    Call InitModemWare
        //
        //    '-- Initialize return variables
        //    MWSetError 0
        //
        //    '-- Open the file and count the number of lines.
        //    Handle = FreeFile
        //    Open Filename$ For Input As Handle
        //    If Err Then
        //        MWSetError MW_ASCIISEND_NOTFOUND
        //        Exit Sub
        //    End If
        //
        //    '-- Tell everyone where we are.
        //    If Not MW_CurRoutine Then
        //        MW_CurRoutine = MW_PROC_ASCIISEND
        //    End If
        //
        //    '-- Turn Off AutoProcess & RThreshold
        //    AutoP = Comm1.AutoProcess
        //    If AutoP Then
        //        Comm1.AutoProcess = PDQ_AUTOPROCESS_NONE
        //    End If
        //    RT = Comm1.RThreshold
        //    If RT Then
        //        Comm1.RThreshold = 0
        //    End If
        //
        //    '-- Are we recording a script?
        //    If MW_ScriptRecording Then
        //        AddToRecScriptData "PROTOCOL", "ASCII"
        //        AddToRecScriptData "UPLOAD", UCase$(Filename$)
        //    End If
        //
        //    '-- Here we go...
        //    Do
        //        '-- Check Carrier
        //        If CDFlag Then
        //            If Comm1.CDHolding = False Then
        //                MWSetError MW_ER_LOST_CARRIER
        //                Exit Do
        //            End If
        //        End If
        //
        //        '-- Have we been Canceled?
        //        If MW_CancelFlag Then
        //            MW_CancelFlag = False
        //            MWSetError MW_ER_CANCELED
        //            MWStatus 0, "Ascii Send Aborted"
        //            Exit Do
        //        End If
        //
        //        '-- Get the next line
        //        Line Input #Handle, NextLine$
        //
        //        '-- Possibly end of file?
        //        If Len(NextLine$) = 0 Then
        //            If EOF(Handle) Then
        //                MWSetError MW_ASCIISEND_OK
        //                Exit Do
        //            End If
        //        End If
        //
        //        '-- File Error?
        //        If Err Then
        //            MWSetError MW_ER_FILE_ERR
        //            Exit Do
        //        End If
        //
        //        '-- Send it out the comm port
        //        Comm1.Output = NextLine$ & MW_CRLF$
        //
        //        '-- Wait until the transmit buffer is empty
        //        Do
        //            DoEvents
        //        Loop Until Comm1.OutBufferCount = 0
        //
        //        '-- Process the next line
        //        If EOF(Handle) Then
        //            MWSetError MW_ASCIISEND_OK
        //            Exit Do
        //        End If
        //
        //    Loop
        //
        //    '-- Close the file, and we're done
        //    Close Handle
        //
        //ASExit:
        //
        //    '-- Reset AutoProcess and RThreshold
        //    If AutoP Then
        //        Comm1.AutoProcess = AutoP
        //    End If
        //    Comm1.RThreshold = 1
        //
        //    '-- We're outta here
        //    MW_CurRoutine = MW_PROC_NONE
        //
        //
        //End Sub




        private void CORTRAMO_Paint(Object eventSender, PaintEventArgs eventArgs)
        {
            COMMCTRL.StatusPrint("");
        }

        private void ID_MCO_EMAIL_TXT_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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


        private void ID_MCO_EMP_LB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            //  Screen.MousePointer = HOURGLASS
            if (ListBoxHelper.GetSelectedIndex(ID_MCO_EMP_LB) >= CORVB.NULL_INTEGER)
            {
                lNumEmp = Convert.ToInt32(Conversion.Val(ID_MCO_EMP_LB.Text.Substring(0, Math.Min(ID_MCO_EMP_LB.Text.Length, 5))));
                iNumGpo = Convert.ToInt32(Conversion.Val(ID_MCO_GRU_COB.Text.Substring(0, Math.Min(ID_MCO_GRU_COB.Text.Length, 5)))); //El número del Grupo

                Obtiene_DatosEmp();
                //Selecciona el direcctorio de empresas
                pszPathEmp = CORVAR.pszgblPathRepEmpresas + CORVAR.igblPref.ToString() + "_" + CORVAR.igblBanco.ToString() + "_" + Conversion.Str(lNumEmp).Trim();

                //verifica que exista el directorio
                if (FileSystem.Dir(pszPathEmp, FileAttribute.Directory) != CORVB.NULL_STRING)
                {
                    ID_MCO_FIL_FLB.Path = pszPathEmp;
                }
                else
                {
                    //Se crea su directorio
                    Directory.CreateDirectory(pszPathEmp);
                    ID_MCO_FIL_FLB.Path = pszPathEmp;
                }

            }
            else if (ID_MCO_EMP_LB.Items.Count != 0)
            {
                //      Screen.MousePointer = DEFAULT
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("Seleccione la Empresa a consultar", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }
            else
            {
                //      Screen.MousePointer = DEFAULT
                //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'context' is not supported, and was removed.
                //UPGRADE_WARNING: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed.
                Interaction.MsgBox("No existen Empresas en Catálogo", (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
            }

            // Screen.MousePointer = DEFAULT
        }




        private void ID_MCO_GRU_COB_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {

            int lEmpresas = Obten_Empresas(); //Obtiene las empresas del Grupo
            if (iErr != CORCONST.OK)
            {
                //AIS-1182 NGONZALEZ
                iErr = API.USER.PostMessage(Handle.ToInt32(), CORVB.WM_CLOSE, CORVB.NULL_INTEGER, CORVB.NULL_INTEGER);
            }
        }



        private void ID_MCO_INT_PB_Click(Object eventSender, EventArgs eventArgs)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {

                Define_Archivos();

                if (Boolean.Parse(Verifica_Mail()))
                {
                    Envia_Mail();
                }
            }
            catch (Exception e)
            {
                CRSGeneral.prObtenError(this.GetType().Name + "(ID_MCO_INT_PB_Click)", e);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }


        private void txtNumero_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
        {
            int KeyAscii = (int)eventArgs.KeyChar;

            if ((KeyAscii < 48 || KeyAscii > 57) && KeyAscii != 8 && KeyAscii != 44)
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



        //CMTPDQCOM EISSA 30.11.2001 Inicio de Código utilizado para PDQCOM
        //''''Private Sub Comm1_OnComm()
        //''''
        //''''    Static LastMsg, Filename$
        //''''    Dim FileDate As Variant, FileTime As Variant
        //''''    Dim i
        //''''
        //''''    '-- The OnComm event is triggered whenever a communications event or
        //''''    '   error occurs. The CommEvent property reflects the most recent
        //''''    '   communications event or error. In this case, we are printing
        //''''    '   a status message based on the error or event received.
        //''''
        //''''    Select Case Comm1.CommEvent
        //''''    Case PDQ_EV_SEND
        //''''    Case PDQ_EV_RECEIVE
        //''''        '-- This event only happens when AutoProcess is set
        //''''        '   to _NONE or _KEY
        //''''
        //''''        '-- If RThreshold is 1, read in 1 character
        //''''        Work$ = Comm1.Input
        //''''
        //''''        '-- Call script recording routine (returns immediately
        //''''        '   if not recording a script
        //''''        Call ScriptRecordOnComm(Work$)
        //''''
        //''''        '-- Display the character.
        //''''        Comm1.Disp = Work$
        //''''
        //''''    Case PDQ_EV_CTS '-- Change in CTS
        //''''        If Comm1.CTSHolding Then
        //''''            Msg$ = "CTS has gone HIGH"
        //''''            cmdMarcar.Enabled = True
        //''''            cmdMarcar.SetFocus
        //''''        Else
        //''''            Msg$ = "CTS has gone LOW"
        //''''        End If
        //''''    Case PDQ_EV_DSR '-- Change in DSR
        //''''        If Comm1.DSRHolding Then
        //''''            Msg$ = "DSR has gone HIGH"
        //''''        Else
        //''''            Msg$ = "DSR has gone LOW"
        //''''        End If
        //''''    Case PDQ_EV_CD  '-- Change in CD
        //''''        If Comm1.CDHolding = False Then
        //''''            Msg$ = "Carrier has gone LOW"
        //''''        End If
        //''''    Case PDQ_EV_RING    '-- Change in RI
        //'''''        Msg$ = "The Phone is ringing"
        //''''         Msg$ = "El teléfono esta llamando."
        //''''    Case PDQ_EV_EOF     '-- Chr$(26) detected
        //'''''        Msg$ = "End of file Detected"
        //''''        Msg$ = "Fin de archivo detectado."
        //''''    Case PDQ_EV_XFER
        //''''        Select Case Comm1.XferStatus
        //''''            Case PDQ_XFER_WAITING: Msg$ = "Esperando el siguiente archivo."  'Msg$ = "Waiting For Next File"
        //''''            Case PDQ_XFER_FILE_READY
        //'''''                Msg$ = "Preparing File"
        //''''                 Msg$ = "Preparando el archivo."
        //''''                If MW_TransferType = MW_XFER_DOWNLOAD Then
        //''''                    If Len(Filename$) = 0 Then
        //''''                        Filename$ = Comm1.XferDestFilename
        //''''                        Debug.Print "Filename: "; Filename$; " Transfer Type:"; MW_TransferType; " Protocol:"; MW_TransferProtocol
        //''''                        If MW_TransferProtocol >= PDQ_YMODEM_BATCH Then
        //''''                            Filename$ = DownloadDir$ & Filename$
        //''''                        End If
        //''''                        If Len(Dir$(Filename$)) Then
        //''''                            If MW_TransferProtocol = PDQ_ZMODEM Then
        //''''                                FileStamp$ = FileDateTime(Filename$)
        //''''                                Spac% = InStr(FileStamp$, " ")
        //''''                                FileDate = DateValue(Left$(FileStamp$, Spac% - 1))
        //''''                                FileTime = TimeValue(Mid$(FileStamp$, Spac% + 1))
        //''''                                If (ZModOpts = ZMODEM_RESUME And FileDate = DateValue(Comm1.XferFileDate) And FileTime = TimeValue(Comm1.XferFileTime)) Then
        //''''                                    CurOpt = ZModOpts
        //''''                                ElseIf ZModOpts <> ZMODEM_RESUME Then
        //''''                                    CurOpt = ZModOpts
        //''''                                Else
        //''''                                    CurOpt = ZMODEM_RENAME
        //''''                                End If
        //''''                                Select Case CurOpt
        //''''                                    Case ZMODEM_RESUME
        //''''                                        Comm1.XferStatus = PDQ_XFER_RESUME
        //''''                                    Case ZMODEM_SKIP
        //''''                                        Comm1.XferStatus = PDQ_XFER_SKIP
        //''''                                    Case ZMODEM_RENAME
        //''''                                        FileNLen = Len(Filename$) - 1
        //''''                                        For i = 1 To 9
        //''''                                            If Len(Dir$(Left$(Filename$, FileNLen) & LTrim$(Str$(i)))) = 0 Then
        //''''                                                Exit For
        //''''                                            End If
        //''''                                        Next
        //''''                                        Filename$ = Left$(Filename$, FileNLen) & LTrim$(Str$(i))
        //''''                                End Select
        //''''                            Else
        //''''                                Select Case TransOpts
        //''''                                    Case TRANS_CANCEL
        //''''                                        Comm1.XferStatus = PDQ_XFER_ABORT
        //''''                                    Case TRANS_RENAME
        //''''                                        FileNLen = Len(Filename$) - 1
        //''''                                        For i = 1 To 9
        //''''                                            If Len(Dir$(Left$(Filename$, FileNLen) & LTrim$(Str$(i)))) = 0 Then
        //''''                                                Exit For
        //''''                                            End If
        //''''                                        Next
        //''''                                        Filename$ = Left$(Filename$, FileNLen) & LTrim$(Str$(i))
        //''''                                End Select
        //''''                            End If
        //''''                        End If
        //''''                        Comm1.XferDestFilename = Filename$
        //''''                    End If
        //''''                End If
        //''''            Case PDQ_XFER_FILE_START: Msg$ = "Iniciando la transferencia del archivo." 'Msg$ = "Starting File Transfer"
        //''''            Case PDQ_XFER_XFERING
        //''''                If LastMsg <> PDQ_XFER_XFERING Then
        //'''''                    Msg$ = "Transferring"
        //''''                    Msg$ = "Transfiriendo."
        //''''                Else
        //''''                    Msg$ = ""
        //''''                End If
        //''''            Case PDQ_XFER_LOSTCARRIER: Msg$ = "Lost Carrier"
        //''''            Case PDQ_XFER_SKIP
        //''''                Msg$ = "Skipping File"
        //''''                Filename$ = ""
        //''''            Case PDQ_XFER_TIMEOUT: Msg$ = "Timeout Waiting For Transfer"
        //''''            Case PDQ_XFER_ABORT
        //'''''                Msg$ = "Transfer Aborted"
        //''''                Msg$ = "Transferencia abortada."
        //''''                Filename$ = ""
        //''''            Case PDQ_XFER_FINISHED
        //'''''                Msg$ = "File Transferred"
        //''''                Msg$ = "Archivo transferido."
        //''''                Filename$ = ""
        //''''            Case PDQ_XFER_TERM_ERROR
        //'''''                Msg$ = "Transfer Unsuccessful"
        //''''                Msg$ = "Transferencia Erronea."
        //''''                MW_TransferType = 0
        //''''            Case PDQ_XFER_TERM_OK
        //'''''                Msg$ = "Transfer Successful"
        //''''                Msg$ = "Transferencia exitosa."
        //''''                MW_TransferType = 0
        //''''        End Select
        //''''        LastMsg = Comm1.XferStatus
        //''''        If Len(Msg$) Then
        //''''            Debug.Print Msg$
        //''''        End If
        //''''    Case PDQ_EV_ZMODEM
        //''''        If MW_TransferType = 0 And MW_ScriptPlaying = 0 Then
        //''''            MW_TransferType = MW_XFER_DOWNLOAD
        //''''            MW_TransferProtocol = PDQ_ZMODEM
        //''''            Comm1.XferProtocol = PDQ_ZMODEM
        //''''            Comm1.XferStatusDialog = PDQ_XFERDIALOG_MODELESS
        //''''            If MW_ScriptRecording Then
        //''''                AddToRecScriptData "PROTOCOL", "ZMODEM"
        //''''                AddToRecScriptData "DOWNLOAD", ""
        //''''            End If
        //''''            Comm1.Download = ""
        //''''        End If
        //''''    Case PDQ_ER_BREAK   '-- Break
        //''''        Msg$ = "Break Detected"
        //''''    Case PDQ_ER_CTSTO   '-- CTS Timeout
        //''''        Msg$ = "CTS Timeout"
        //''''    Case PDQ_ER_DSRTO   '-- DSR Timeout
        //''''        Msg$ = "DSR Timeout"
        //''''    Case PDQ_ER_FRAME   '-- Framing Error
        //''''        Msg$ = "Framing Error"
        //''''    Case PDQ_ER_INTO    '-- Input Timeout
        //''''        Msg$ = "Input Timeout"
        //''''    Case PDQ_ER_OVERRUN '-- Overrun error
        //''''        Msg$ = "Overrun Error"
        //''''    Case PDQ_ER_CDTO    '-- CD Timeout
        //''''        Msg$ = "Carrier Detect Timeout"
        //''''    Case PDQ_ER_RXOVER  '-- Receive buffer overflow
        //''''        Msg$ = "Receive Overflow"
        //''''    Case PDQ_ER_TXFULL  '-- Transmit buffer full
        //''''        Msg$ = "Transmit Buffer Overflow"
        //''''    End Select
        //''''
        //''''    If Len(Msg$) Then
        //''''        '-- Print the error message
        //''''        StatusPrint Msg$
        //''''    End If
        //''''
        //''''
        //''''
        //''''End Sub
        //''''
        //''''
        //''''
        //''''
        //''''Sub Inicializa_Modem()
        //''''
        //''''  Dim Temp  As String
        //''''
        //''''  On Error Resume Next
        //''''
        //''''  If Comm1.PortOpen = False Then
        //''''      Comm1.PortOpen = True
        //''''      Comm1.InBufferCount = 0
        //''''      Comm1.Output = "ATZ" + Chr(13) + Chr(10)   'A=answer, T=touch-tone dialing, Z=reset modem
        //''''      Comm1.PortOpen = False
        //''''      Err = 0
        //''''  End If
        //''''End Sub
        //''''
        //''''
        //''''
        //''''Private Sub cmdEnvia_Click()
        //'''''Filename required unless CompuServe B+ protocol.
        //''''  Screen.MousePointer = HOURGLASS
        //''''
        //''''  'Concatena Archivos a Transmitir
        //''''  Call Define_Archivos
        //''''
        //''''  'Validamos la Seleccion del Protocolo y Archivo a Tx
        //''''  If Valida_Datos = True Then
        //''''    If (CmbProtocol.ListIndex <> PDQ_COMPUSERVE_BPLUS) And (TxtFilename.Text = "") Then
        //''''        MsgBox "Seleccione archivo a tranferir.", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''        Exit Sub
        //''''    End If
        //''''
        //''''  'Envia Archivo(s) segun Protocolo eligido
        //''''  Call Transmite_Archivo
        //''''
        //''''    If Comm1.XferStatus = PDQ_XFER_TERM_OK Then
        //''''      Screen.MousePointer = DEFAULT
        //''''      Msg$ = "Archivo transferido."
        //''''      StatusPrint Msg
        //''''    End If
        //''''  End If
        //''''
        //''''  Screen.MousePointer = DEFAULT
        //''''End Sub
        //''''
        //''''Private Sub cmdMarcar_Click()
        //''''
        //''''
        //''''  Screen.MousePointer = HOURGLASS
        //''''
        //''''  Call Define_Archivos
        //''''
        //''''  If Valida_Datos = True Then
        //''''    Call Marca_Telefono(txtNumero.Text)
        //''''  End If
        //''''
        //''''
        //''''
        //''''  Screen.MousePointer = DEFAULT
        //''''End Sub
        //''''
        //''''
        //''''
        //''''
        //''''Private Sub cmdResetea_Click()
        //''''  'descueldga el telefono
        //''''  Screen.MousePointer = HOURGLASS
        //''''  Call Hangup(Comm1, 10, True)
        //''''
        //''''  Select Case MWError()
        //''''     Case MW_ER_CANCELED, MW_ER_LOST_CARRIER, MW_ER_PORTCLOSED, MW_ER_CTRLERROR, MW_ER_TIMEOUT, MW_HANGUP_ERROR, MW_HANGUP_OFFLINE
        //''''          Msg = MWErrorMsg()
        //''''     Case MW_HANGUP_OK
        //''''          Msg = "modem desconectado..."
        //''''          If Comm1.PortOpen = True Then
        //''''           Comm1.Output = "ATH" + Chr$(13) + Chr$(10)
        //''''           Comm1.SThreshold = 0
        //''''         End If
        //''''    End Select
        //''''
        //''''
        //''''  StatusPrint Msg
        //''''
        //''''  cmdMarcar.Enabled = True
        //''''  cmdEnvia.Enabled = False
        //''''
        //''''  Screen.MousePointer = DEFAULT
        //''''End Sub
        //''''
        //''''
        //''''Private Sub Resetea_Modem()
        //''''  Dim RestDTR
        //''''
        //''''  Comm1.SThreshold = 0
        //''''
        //''''  If Comm1.PortOpen = True Then
        //''''    Comm1.Output = "ATH" + Chr$(13) + Chr$(10)
        //''''    Comm1.SThreshold = 0
        //'''''    Comm1.Output = "ATZ" + Chr$(13) + Chr$(10)
        //''''  End If
        //''''  'RestDTR = Comm1.DTREnable
        //''''  Comm1.DTREnable = False
        //''''
        //'''''  Comm1.DTREnable = RestDTR        'restaura el valor anterior
        //''''  If Comm1.PortOpen = True Then
        //''''    Comm1.PortOpen = False
        //'''''    MWStatus 0, " "
        //''''  End If
        //''''
        //''''
        //''''
        //''''
        //''''End Sub
        //''''Private Sub Form_Unload(Cancel As Integer)
        //''''
        //''''  If Comm1.CDHolding = False Then
        //''''    Call Resetea_Modem
        //''''    Unload Me
        //''''  Else
        //''''    MsgBox "Cuelgue antes de salir. ", MB_OK + MB_ICONEXCLAMATION, STR_APP_TIT
        //''''    Exit Sub
        //''''  End If
        //''''
        //''''End Sub
        //''''
        //''''
        //''''
        //''''Private Sub Agrega_Items()
        //''''
        //''''  'Load the combo box with available protocols.
        //''''  CmbProtocol.AddItem "Xmodem-Checksum"
        //''''  CmbProtocol.AddItem "Xmodem-CRC"
        //''''  CmbProtocol.AddItem "Xmodem-1K"
        //''''  CmbProtocol.AddItem "Ymodem-Batch"
        //''''  CmbProtocol.AddItem "Ymodem-G"
        //''''  CmbProtocol.AddItem "Zmodem"
        //''''  CmbProtocol.AddItem "Kermit"
        //''''  CmbProtocol.AddItem "CompuServe B+"
        //''''  CmbProtocol.AddItem "ASCII"
        //''''
        //''''  'Populate list boxes.
        //''''  CmbBaudRate.AddItem " "
        //''''  CmbBaudRate.AddItem "300"
        //''''  CmbBaudRate.AddItem "1200"
        //''''  CmbBaudRate.AddItem "2400"
        //''''  CmbBaudRate.AddItem "4800"
        //''''  CmbBaudRate.AddItem "9600"
        //''''  CmbBaudRate.AddItem "19200"
        //''''  CmbBaudRate.AddItem "38400"
        //''''  CmbBaudRate.AddItem "57600"
        //''''  CmbBaudRate.AddItem "115200"
        //''''  CmbBaudRate.AddItem "230400"
        //''''
        //''''  CmbDataBits.AddItem "5"
        //''''  CmbDataBits.AddItem "6"
        //''''  CmbDataBits.AddItem "7"
        //''''  CmbDataBits.AddItem "8"
        //''''
        //''''  CmbStopBits.AddItem "1"
        //''''  CmbStopBits.AddItem "1.5"
        //''''  CmbStopBits.AddItem "2"
        //''''
        //''''  CmbParity.AddItem "Even"
        //''''  CmbParity.AddItem "Odd"
        //''''  CmbParity.AddItem "None"
        //''''  CmbParity.AddItem "Mark"
        //''''  CmbParity.AddItem "Space"
        //''''
        //''''  CmbComPort.AddItem "1"
        //''''  CmbComPort.AddItem "2"
        //''''  CmbComPort.AddItem "3"
        //''''  CmbComPort.AddItem "4"
        //''''  CmbComPort.AddItem "5"
        //''''  CmbComPort.AddItem "6"
        //''''  CmbComPort.AddItem "7"
        //''''  CmbComPort.AddItem "8"
        //''''  CmbComPort.AddItem "9"
        //''''  CmbComPort.AddItem "10"
        //''''  CmbComPort.AddItem "11"
        //''''  CmbComPort.AddItem "12"
        //''''  CmbComPort.AddItem "13"
        //''''  CmbComPort.AddItem "14"
        //''''  CmbComPort.AddItem "15"
        //''''  CmbComPort.AddItem "16"
        //''''
        //''''End Sub
        //''''
        //''''
        //''''
        //''''
        //''''
        //''''Private Sub ChkHandshakingHardware_Click()
        //''''
        //''''If ChkHandshakingHardware.Value = 1 Then
        //'''''User has selected to use hardware handshaking.
        //''''
        //''''    'Select and disable ChkRTSEnable, since this is required
        //''''    'for hardware handshaking.
        //''''    TempSettings.RTSEnable = True
        //''''    ChkRTSEnable.Value = 1
        //''''    ChkRTSEnable.Enabled = False
        //''''
        //''''Else
        //'''''User has deselected hardware handshaking.
        //''''
        //''''    'Re-enable ChkRTSEnable.
        //''''    ChkRTSEnable.Enabled = True
        //''''
        //''''End If
        //''''
        //'''''Recalculate handshaking.
        //''''iHandshaking = (iHandshaking And 1) Or ChkHandshakingHardware.Value * 2
        //''''
        //''''End Sub
        //''''
        //''''
        //''''Private Sub ChkHandshakingSoftware_Click()
        //''''
        //'''''Recalculate handshaking.
        //''''iHandshaking = (iHandshaking And 2) Or ChkHandshakingSoftware.Value
        //''''
        //''''End Sub
        //''''
        //''''Private Sub Command1_Click()
        //''''    Call Inicializa_Modem
        //''''End Sub

        //EISSA Fin de CMTPDQCOM
        private void CORTRAMO_Closed(Object eventSender, EventArgs eventArgs)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ID_MCOM_MAIL_Enter(object sender, EventArgs e)
        {

        }
    }
}