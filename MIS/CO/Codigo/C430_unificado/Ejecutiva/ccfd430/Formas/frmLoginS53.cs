using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Artinsoft.VB6.Gui;
using Artinsoft.VB6.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;

using System.IO;

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    public partial class frmLoginS53 : Form
    {
        public frmLoginS53()
        {
            InitializeComponent();
        }

        const string STR_SEG_NOT_BAN = "No existen bancos para acceso al sistema. Consulte al Administrador del Sistema.";
        const string STR_SEG_NOT_CON = "La conexión a las bases de datos es invalida. Consulte al Administrador del Sistema.";
        const string STR_SEG_NOT_LOG = "Verifique el usuario o la clave personal, no coinciden.";
        const string STR_ACC_NOT_CVE = "El SOEID no ha sido proporcionado. Favor de asignarlo.";
        const string STR_ACC_NOT_USU = "La clave personal no ha sido proporcionada. Favor de asignarla.";
        const string STR_ACC_LON_TOK = "La longitud del Token debe ser de 6 caracteres";
        const string STR_ACC_NOT_NIV = "El grupo asignado al usuario no tiene niveles de acceso. Deberán ser asignados por el Administrador del Sistema.";
        const string STR_ACC_NOT_ACC = "Verifique el usuario o la clave personal, no coinciden.";
        const string STR_ACC_NOT_EXI = "El usuario no ha sido dado de alta en el sistema. Consulte al Administrador del Sistema.";
        const string STR_ACC_NOT_MEM = "No hay suficiente memoria para realizar la Conección. Inicialice su Computadora.";
        const string STR_ACC_NOT_SER = "No existen servisores instalados.";
        string pszGrupo = String.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
         
            this.Close();
        }

        private void ID_ACC_ACE_PB_Click(object sender, EventArgs e)
        {
            
            try
            {

                //mdlSeguridad.objSeguridad = new COMDRV32.TcpServer();
                //mdlSeguridad.objSeguridad.Connect();

                if (ID_ACC_USU_EB.Text.Trim() == CORVB.NULL_STRING)
                { 
                    this.Cursor = Cursors.Default;
                    Interaction.MsgBox(STR_ACC_NOT_CVE, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    ID_ACC_USU_EB.Focus();
                    return;
                }

                if (ID_ACC_CVE_EB.Text.Trim() == CORVB.NULL_STRING)
                { 
                    this.Cursor = Cursors.Default;
                    Interaction.MsgBox(STR_ACC_NOT_USU, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                    ID_ACC_CVE_EB.Focus();
                    return;
                }

                if (ID_ACC_TOKEN_EB.Text.Trim() != CORVB.NULL_STRING)
                { //Valido que el campo de token tenga una longitud de 6
                    if (ID_ACC_TOKEN_EB.TextLength != 6)
                    {
                        this.Cursor = Cursors.Default;
                        Interaction.MsgBox(STR_ACC_LON_TOK, (MsgBoxStyle)(((int)CORVB.MB_ICONEXCLAMATION) + ((int)CORVB.MB_OK)), CORSTR.STR_APP_TIT);
                        ID_ACC_TOKEN_EB.Focus();
                        return;
                    }
                }

                this.Cursor = Cursors.WaitCursor;
                Seguridad.usugUsuario.NominaS = ID_ACC_USU_EB.Text; //EISSA:HVV 25.12.2004 -> Seguridad para uso exclusivo de Maker Cheker
                Seguridad.usugUsuario.PasswordS = ID_ACC_CVE_EB.Text; //EISSA:HVV 25.12.2004 -> Seguridad para uso exclusivo de Maker Cheker
                string tempRefParam2 = ID_ACC_USU_EB.Text.Trim();

                string StrIp = mdlSeguridad.GetIP();
                string _url = ConfigurationManager.AppSettings["_url"];
                string _action = ConfigurationManager.AppSettings["_action_a"];

                string valor = mdlSeguridad.Servicios_SSS(ID_ACC_USU_EB.Text, ID_ACC_CVE_EB.Text, StrIp, ID_ACC_TOKEN_EB.Text, "0", 1, _url, _action);

                if (valor == "1")
                {

                    this.DialogResult = DialogResult.OK;
                  
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    mdlSeguridad.objSeguridad = null;
                    this.Close();
                   
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception excep)
            {

                MdlCambioMasivo.MsgError("Se Provoco el siguiente error: " + "\r\n" +
                                         "No. Error        :" + Information.Err().Number.ToString() + "\r\n" +
                                         "Descripcion      : " + excep.Message + "\r\n" +
                                         "Origen del Error : " + excep.Source);
            }
        }

        private void frmLoginS53_Load(object sender, EventArgs e)
        {
            ID_ACC_USU_EB.Text = mdlSeguridad._SOAID.ToString();
            ID_ACC_CVE_EB.Focus();
        }
    }
}