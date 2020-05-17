using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    partial class FrmTuxedo
    {

        #region "Upgrade Support "
        private static FrmTuxedo m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static FrmTuxedo DefInstance
        {
            get
            {
                if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
                {
                    m_InitializingDefInstance = true;
                    m_vb6FormDefInstance = CreateInstance();
                    m_vb6FormDefInstance.Closed += new EventHandler(m_vb6FormDefInstance.ReleaseResources);
                    m_InitializingDefInstance = false;
                }
                return m_vb6FormDefInstance;
            }
            set
            {
                m_vb6FormDefInstance = value;
            }
        }

        #endregion
        #region "Windows Form Designer generated code "
        public FrmTuxedo()
            : base()
        {
            if (m_vb6FormDefInstance == null)
            {
                if (m_InitializingDefInstance)
                {
                    m_vb6FormDefInstance = this;
                }
                else
                {
                    try
                    {
                        //For the start-up form, the first instance created is the default instance.
                        if (System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
                        {
                            m_vb6FormDefInstance = this;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            isInitializingComponent = true;
            InitializeComponent();
            isInitializingComponent = false;
            InitializeHelp();
            InitializeOptReporte();
            InitializeCboEmpresas();
            InitializeMskFecha();
            InitializeCboNivel();
            InitializeLblFecha();
            //This form is an MDI child.
            //This code simulates the VB6 
            // functionality of automatically
            // loading and showing an MDI
            // child's parent.
            this.MdiParent = TCc430.CORMDIBN.DefInstance;
            TCc430.CORMDIBN.DefInstance.Show();
        }
        public static FrmTuxedo CreateInstance()
        {
            FrmTuxedo theInstance = new FrmTuxedo();
            theInstance.Form_Load();
            //The MDI form in the VB6 project had its
            //AutoShowChildren property set to True
            //To simulate the VB6 behavior, we need to
            //automatically Show the form whenever it
            //is loaded.  If you do not want this behavior
            //then delete the following line of code
            //UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing.
            theInstance.Show();
            return theInstance;
        }
        protected void InitializeHelp()
        {
            Artinsoft.VB6.Help.HelpSupportClass.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Index);
        }
        private void ReleaseResources(object eventSender, System.EventArgs eventArgs)
        {
            Dispose(true);
            m_vb6FormDefInstance = null;
        }
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode]
        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(Disposing);
        }
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.ToolTip ToolTip1;

        private AxMSMask.AxMaskEdBox _MskFecha_0;
        public System.Windows.Forms.ComboBox CboFecha;
        private AxMSMask.AxMaskEdBox _MskFecha_1;
        private System.Windows.Forms.Label _LblFecha_1;
        private System.Windows.Forms.Label _LblFecha_0;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.GroupBox FrmFechaReprote;
        private System.Windows.Forms.ComboBox _CboEmpresas_2;
        private System.Windows.Forms.ComboBox _CboEmpresas_0;
        private System.Windows.Forms.ComboBox _CboEmpresas_1;
        private System.Windows.Forms.ComboBox _CboNivel_0;
        public System.Windows.Forms.CheckBox ChkNivel;
        private System.Windows.Forms.RadioButton _OptReporte_2;
        private System.Windows.Forms.RadioButton _OptReporte_1;
        private System.Windows.Forms.RadioButton _OptReporte_0;
        public System.Windows.Forms.GroupBox FrmTipoReporte;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.GroupBox FrmParReporte;
        public Microsoft.VisualBasic.Compatibility.VB6.DirListBox DirLocal;
        public Microsoft.VisualBasic.Compatibility.VB6.FileListBox FilLocal;
        public Microsoft.VisualBasic.Compatibility.VB6.DriveListBox DrvLocal;
        public System.Windows.Forms.TextBox txtDirNuevo;
        public System.Windows.Forms.Button BtnDirNuevo;
        public System.Windows.Forms.GroupBox Frame1;
        public System.Windows.Forms.GroupBox Frm_Local;
        public System.Windows.Forms.TextBox TxtTelnet;
        public System.Windows.Forms.StatusStrip TelnetSb;
        public AxMSWinsockLib.AxWinsock TelnetWS;
        public System.Windows.Forms.Button BtnEnviar;
        public System.Windows.Forms.Button BtnConectar;
        public System.Windows.Forms.TextBox txtComando;
        public System.Windows.Forms.Panel PanToolBar;
        public System.Windows.Forms.ComboBox[] CboEmpresas = new System.Windows.Forms.ComboBox[3];
        public System.Windows.Forms.ComboBox[] CboNivel = new System.Windows.Forms.ComboBox[1];
        public System.Windows.Forms.Label[] LblFecha = new System.Windows.Forms.Label[2];
        public AxMSMask.AxMaskEdBox[] MskFecha = new AxMSMask.AxMaskEdBox[2];
        public System.Windows.Forms.RadioButton[] OptReporte = new System.Windows.Forms.RadioButton[3];
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        //[System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTuxedo));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtnDirNuevo = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnDetener = new System.Windows.Forms.Button();
            this.BtnProcesar = new System.Windows.Forms.Button();
            this.FrmParReporte = new System.Windows.Forms.GroupBox();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this._CboNivel_0 = new System.Windows.Forms.ComboBox();
            this.FrmTipoReporte = new System.Windows.Forms.GroupBox();
            this._OptReporte_2 = new System.Windows.Forms.RadioButton();
            this._OptReporte_1 = new System.Windows.Forms.RadioButton();
            this._OptReporte_0 = new System.Windows.Forms.RadioButton();
            this.ChkNivel = new System.Windows.Forms.CheckBox();
            this._CboEmpresas_0 = new System.Windows.Forms.ComboBox();
            this._CboEmpresas_1 = new System.Windows.Forms.ComboBox();
            this.FrmFechaReprote = new System.Windows.Forms.GroupBox();
            this._MskFecha_1 = new AxMSMask.AxMaskEdBox();
            this._MskFecha_0 = new AxMSMask.AxMaskEdBox();
            this.CboFecha = new System.Windows.Forms.ComboBox();
            this._LblFecha_1 = new System.Windows.Forms.Label();
            this._LblFecha_0 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this._CboEmpresas_2 = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Frm_Local = new System.Windows.Forms.GroupBox();
            this.DirLocal = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.FilLocal = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.txtDirNuevo = new System.Windows.Forms.TextBox();
            this.DrvLocal = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
            this.TxtTelnet = new System.Windows.Forms.TextBox();
            this.TelnetSb = new System.Windows.Forms.StatusStrip();
            this.TelnetWS = new AxMSWinsockLib.AxWinsock();
            this.BtnConectar = new System.Windows.Forms.Button();
            this.txtComando = new System.Windows.Forms.TextBox();
            this.PanToolBar = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.SpdReportes = new AxFPSpread.AxvaSpread();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FrmParReporte.SuspendLayout();
            this.FrmTipoReporte.SuspendLayout();
            this.FrmFechaReprote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._MskFecha_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._MskFecha_0)).BeginInit();
            this.Frm_Local.SuspendLayout();
            this.Frame1.SuspendLayout();
            this.TelnetSb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TelnetWS)).BeginInit();
            this.PanToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpdReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDirNuevo
            // 
            this.BtnDirNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.BtnDirNuevo.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnDirNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDirNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnDirNuevo.Location = new System.Drawing.Point(192, 16);
            this.BtnDirNuevo.Name = "BtnDirNuevo";
            this.BtnDirNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnDirNuevo.Size = new System.Drawing.Size(25, 17);
            this.BtnDirNuevo.TabIndex = 20;
            this.BtnDirNuevo.Tag = "";
            this.BtnDirNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolTip1.SetToolTip(this.BtnDirNuevo, "Crear directorio");
            this.BtnDirNuevo.UseVisualStyleBackColor = false;
            this.BtnDirNuevo.Click += new System.EventHandler(this.BtnDirNuevo_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Image = global::C430_NET.Properties.Resources.icon3;
            this.BtnSalir.Location = new System.Drawing.Point(84, 1);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(39, 36);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolTip1.SetToolTip(this.BtnSalir, "Salir");
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_ClickEvent);
            // 
            // BtnDetener
            // 
            this.BtnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDetener.Image = ((System.Drawing.Image)(resources.GetObject("BtnDetener.Image")));
            this.BtnDetener.Location = new System.Drawing.Point(42, 1);
            this.BtnDetener.Name = "BtnDetener";
            this.BtnDetener.Size = new System.Drawing.Size(39, 36);
            this.BtnDetener.TabIndex = 1;
            this.BtnDetener.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolTip1.SetToolTip(this.BtnDetener, "Detener Reporte");
            //this.BtnDetener.Click += new System.EventHandler(this.BtnDetener_ClickEvent);28/09/09
            // 
            // BtnProcesar
            // 
            this.BtnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnProcesar.Image = global::C430_NET.Properties.Resources.icon1;
            this.BtnProcesar.Location = new System.Drawing.Point(1, -1);
            this.BtnProcesar.Name = "BtnProcesar";
            this.BtnProcesar.Size = new System.Drawing.Size(39, 39);
            this.BtnProcesar.TabIndex = 0;
            this.BtnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolTip1.SetToolTip(this.BtnProcesar, "Generar Reporte en Linea");
            this.BtnProcesar.Click += new System.EventHandler(this.BtnProcesar_ClickEvent);
            // 
            // FrmParReporte
            // 
            this.FrmParReporte.BackColor = System.Drawing.SystemColors.Control;
            this.FrmParReporte.Controls.Add(this.BtnEnviar);
            this.FrmParReporte.Controls.Add(this._CboNivel_0);
            this.FrmParReporte.Controls.Add(this.FrmTipoReporte);
            this.FrmParReporte.Controls.Add(this.ChkNivel);
            this.FrmParReporte.Controls.Add(this._CboEmpresas_0);
            this.FrmParReporte.Controls.Add(this._CboEmpresas_1);
            this.FrmParReporte.Controls.Add(this.FrmFechaReprote);
            this.FrmParReporte.Controls.Add(this._CboEmpresas_2);
            this.FrmParReporte.Controls.Add(this.Label2);
            this.FrmParReporte.Controls.Add(this.Label4);
            this.FrmParReporte.Controls.Add(this.Label3);
            this.FrmParReporte.Controls.Add(this.Label1);
            this.FrmParReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrmParReporte.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FrmParReporte.Location = new System.Drawing.Point(273, 48);
            this.FrmParReporte.Name = "FrmParReporte";
            this.FrmParReporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FrmParReporte.Size = new System.Drawing.Size(456, 513);
            this.FrmParReporte.TabIndex = 24;
            this.FrmParReporte.TabStop = false;
            this.FrmParReporte.Tag = "";
            this.FrmParReporte.Text = "Seleccione los reportes a generar en linea ";
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnEnviar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnEnviar.Location = new System.Drawing.Point(8, 202);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnEnviar.Size = new System.Drawing.Size(129, 25);
            this.BtnEnviar.TabIndex = 16;
            this.BtnEnviar.Tag = "";
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnEnviar.UseVisualStyleBackColor = false;
            this.BtnEnviar.Visible = false;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // _CboNivel_0
            // 
            this._CboNivel_0.BackColor = System.Drawing.SystemColors.Window;
            this._CboNivel_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._CboNivel_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CboNivel_0.Enabled = false;
            this._CboNivel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CboNivel_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._CboNivel_0.Location = new System.Drawing.Point(280, 294);
            this._CboNivel_0.Name = "_CboNivel_0";
            this._CboNivel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CboNivel_0.Size = new System.Drawing.Size(113, 21);
            this._CboNivel_0.TabIndex = 9;
            this._CboNivel_0.Tag = "";
            this._CboNivel_0.SelectedIndexChanged += new System.EventHandler(this.CboNivel_SelectedIndexChanged);
            // 
            // FrmTipoReporte
            // 
            this.FrmTipoReporte.BackColor = System.Drawing.SystemColors.Control;
            this.FrmTipoReporte.Controls.Add(this._OptReporte_2);
            this.FrmTipoReporte.Controls.Add(this._OptReporte_1);
            this.FrmTipoReporte.Controls.Add(this._OptReporte_0);
            this.FrmTipoReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrmTipoReporte.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FrmTipoReporte.Location = new System.Drawing.Point(16, 16);
            this.FrmTipoReporte.Name = "FrmTipoReporte";
            this.FrmTipoReporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FrmTipoReporte.Size = new System.Drawing.Size(417, 97);
            this.FrmTipoReporte.TabIndex = 25;
            this.FrmTipoReporte.TabStop = false;
            this.FrmTipoReporte.Tag = "";
            this.FrmTipoReporte.Text = "Agrupar el reporte por :";
            // 
            // _OptReporte_2
            // 
            this._OptReporte_2.BackColor = System.Drawing.SystemColors.Control;
            this._OptReporte_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._OptReporte_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._OptReporte_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OptReporte_2.Location = new System.Drawing.Point(24, 72);
            this._OptReporte_2.Name = "_OptReporte_2";
            this._OptReporte_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._OptReporte_2.Size = new System.Drawing.Size(233, 17);
            this._OptReporte_2.TabIndex = 1;
            this._OptReporte_2.TabStop = true;
            this._OptReporte_2.Tag = "";
            this._OptReporte_2.Text = "Grupo,Empresa, Un&idad";
            this._OptReporte_2.UseVisualStyleBackColor = false;
            this._OptReporte_2.CheckedChanged += new System.EventHandler(this.OptReporte_CheckedChanged);
            // 
            // _OptReporte_1
            // 
            this._OptReporte_1.BackColor = System.Drawing.SystemColors.Control;
            this._OptReporte_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._OptReporte_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._OptReporte_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OptReporte_1.Location = new System.Drawing.Point(24, 48);
            this._OptReporte_1.Name = "_OptReporte_1";
            this._OptReporte_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._OptReporte_1.Size = new System.Drawing.Size(233, 17);
            this._OptReporte_1.TabIndex = 2;
            this._OptReporte_1.TabStop = true;
            this._OptReporte_1.Tag = "";
            this._OptReporte_1.Text = "Grupo, E&mpresa";
            this._OptReporte_1.UseVisualStyleBackColor = false;
            this._OptReporte_1.CheckedChanged += new System.EventHandler(this.OptReporte_CheckedChanged);
            // 
            // _OptReporte_0
            // 
            this._OptReporte_0.BackColor = System.Drawing.SystemColors.Control;
            this._OptReporte_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._OptReporte_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._OptReporte_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._OptReporte_0.Location = new System.Drawing.Point(24, 24);
            this._OptReporte_0.Name = "_OptReporte_0";
            this._OptReporte_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._OptReporte_0.Size = new System.Drawing.Size(145, 17);
            this._OptReporte_0.TabIndex = 0;
            this._OptReporte_0.TabStop = true;
            this._OptReporte_0.Tag = "";
            this._OptReporte_0.Text = "G&rupo";
            this._OptReporte_0.UseVisualStyleBackColor = false;
            this._OptReporte_0.CheckedChanged += new System.EventHandler(this.OptReporte_CheckedChanged);
            // 
            // ChkNivel
            // 
            this.ChkNivel.BackColor = System.Drawing.SystemColors.Control;
            this.ChkNivel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChkNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkNivel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChkNivel.Location = new System.Drawing.Point(16, 296);
            this.ChkNivel.Name = "ChkNivel";
            this.ChkNivel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChkNivel.Size = new System.Drawing.Size(121, 17);
            this.ChkNivel.TabIndex = 8;
            this.ChkNivel.Tag = "";
            this.ChkNivel.Text = "&Con Niveles";
            this.ChkNivel.UseVisualStyleBackColor = false;
            this.ChkNivel.CheckStateChanged += new System.EventHandler(this.ChkNivel_CheckStateChanged);
            // 
            // _CboEmpresas_0
            // 
            this._CboEmpresas_0.BackColor = System.Drawing.SystemColors.Window;
            this._CboEmpresas_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._CboEmpresas_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CboEmpresas_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CboEmpresas_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._CboEmpresas_0.Location = new System.Drawing.Point(104, 233);
            this._CboEmpresas_0.Name = "_CboEmpresas_0";
            this._CboEmpresas_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CboEmpresas_0.Size = new System.Drawing.Size(289, 21);
            this._CboEmpresas_0.TabIndex = 6;
            this._CboEmpresas_0.Tag = "";
            this._CboEmpresas_0.SelectedIndexChanged += new System.EventHandler(this.CboEmpresas_SelectedIndexChanged);
            this._CboEmpresas_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ComboBox_KeyPress);
            
            // 
            // _CboEmpresas_1
            // 
            this._CboEmpresas_1.BackColor = System.Drawing.SystemColors.Window;
            this._CboEmpresas_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._CboEmpresas_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CboEmpresas_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CboEmpresas_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._CboEmpresas_1.Location = new System.Drawing.Point(104, 264);
            this._CboEmpresas_1.Name = "_CboEmpresas_1";
            this._CboEmpresas_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CboEmpresas_1.Size = new System.Drawing.Size(289, 21);
            this._CboEmpresas_1.TabIndex = 7;
            this._CboEmpresas_1.Tag = "";
            this._CboEmpresas_1.SelectedIndexChanged += new System.EventHandler(this.CboEmpresas_SelectedIndexChanged);
            this._CboEmpresas_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ComboBox_KeyPress);
            // 
            // FrmFechaReprote
            // 
            this.FrmFechaReprote.BackColor = System.Drawing.SystemColors.Control;
            this.FrmFechaReprote.Controls.Add(this._MskFecha_1);
            this.FrmFechaReprote.Controls.Add(this._MskFecha_0);
            this.FrmFechaReprote.Controls.Add(this.CboFecha);
            this.FrmFechaReprote.Controls.Add(this._LblFecha_1);
            this.FrmFechaReprote.Controls.Add(this._LblFecha_0);
            this.FrmFechaReprote.Controls.Add(this.Label5);
            this.FrmFechaReprote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrmFechaReprote.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FrmFechaReprote.Location = new System.Drawing.Point(16, 113);
            this.FrmFechaReprote.Name = "FrmFechaReprote";
            this.FrmFechaReprote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FrmFechaReprote.Size = new System.Drawing.Size(417, 105);
            this.FrmFechaReprote.TabIndex = 34;
            this.FrmFechaReprote.TabStop = false;
            this.FrmFechaReprote.Tag = "";
            this.FrmFechaReprote.Text = "Rango";
            this.FrmFechaReprote.Enter += new System.EventHandler(this.FrmFechaReprote_Enter);
            // 
            // _MskFecha_1
            // 
            this._MskFecha_1.Location = new System.Drawing.Point(232, 64);
            this._MskFecha_1.Name = "_MskFecha_1";
            this._MskFecha_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_MskFecha_1.OcxState")));
            this._MskFecha_1.Size = new System.Drawing.Size(105, 19);
            this._MskFecha_1.TabIndex = 5;
            this._MskFecha_1.Tag = "";
            this._MskFecha_1.Validating += new System.ComponentModel.CancelEventHandler(this.MskFecha_Validating);
            // 
            // _MskFecha_0
            // 
            this._MskFecha_0.Location = new System.Drawing.Point(232, 40);
            this._MskFecha_0.Name = "_MskFecha_0";
            this._MskFecha_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_MskFecha_0.OcxState")));
            this._MskFecha_0.Size = new System.Drawing.Size(105, 19);
            this._MskFecha_0.TabIndex = 4;
            this._MskFecha_0.Tag = "";
            this._MskFecha_0.Validating += new System.ComponentModel.CancelEventHandler(this.MskFecha_Validating);
            // 
            // CboFecha
            // 
            this.CboFecha.BackColor = System.Drawing.SystemColors.Window;
            this.CboFecha.Cursor = System.Windows.Forms.Cursors.Default;
            this.CboFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboFecha.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CboFecha.Location = new System.Drawing.Point(192, 12);
            this.CboFecha.Name = "CboFecha";
            this.CboFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CboFecha.Size = new System.Drawing.Size(145, 21);
            this.CboFecha.TabIndex = 3;
            this.CboFecha.Tag = "";
            this.CboFecha.SelectedIndexChanged += new System.EventHandler(this.CboFecha_SelectedIndexChanged);
            // 
            // _LblFecha_1
            // 
            this._LblFecha_1.AutoSize = true;
            this._LblFecha_1.BackColor = System.Drawing.SystemColors.Control;
            this._LblFecha_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblFecha_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._LblFecha_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblFecha_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblFecha_1.Location = new System.Drawing.Point(16, 64);
            this._LblFecha_1.Name = "_LblFecha_1";
            this._LblFecha_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblFecha_1.Size = new System.Drawing.Size(171, 13);
            this._LblFecha_1.TabIndex = 37;
            this._LblFecha_1.Tag = "";
            this._LblFecha_1.Text = "Fecha Final ( YYYY/MM/DD)";
            // 
            // _LblFecha_0
            // 
            this._LblFecha_0.AutoSize = true;
            this._LblFecha_0.BackColor = System.Drawing.SystemColors.Control;
            this._LblFecha_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblFecha_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._LblFecha_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblFecha_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblFecha_0.Location = new System.Drawing.Point(16, 40);
            this._LblFecha_0.Name = "_LblFecha_0";
            this._LblFecha_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblFecha_0.Size = new System.Drawing.Size(94, 13);
            this._LblFecha_0.TabIndex = 36;
            this._LblFecha_0.Tag = "";
            this._LblFecha_0.Text = "Fecha de Corte";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(8, 16);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(169, 17);
            this.Label5.TabIndex = 35;
            this.Label5.Tag = "";
            this.Label5.Text = "Tipo de Reporte a Generar:";
            // 
            // _CboEmpresas_2
            // 
            this._CboEmpresas_2.BackColor = System.Drawing.SystemColors.Window;
            this._CboEmpresas_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._CboEmpresas_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CboEmpresas_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CboEmpresas_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._CboEmpresas_2.Location = new System.Drawing.Point(104, 323);
            this._CboEmpresas_2.Name = "_CboEmpresas_2";
            this._CboEmpresas_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CboEmpresas_2.Size = new System.Drawing.Size(289, 21);
            this._CboEmpresas_2.TabIndex = 10;
            this._CboEmpresas_2.Tag = "";
            this._CboEmpresas_2.SelectedIndexChanged += new System.EventHandler(this.CboEmpresas_SelectedIndexChanged);
            this._CboEmpresas_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ComboBox_KeyPress);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(16, 266);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(65, 17);
            this.Label2.TabIndex = 27;
            this.Label2.Tag = "";
            this.Label2.Text = "&Empresa";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.SystemColors.Control;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(224, 295);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(65, 17);
            this.Label4.TabIndex = 26;
            this.Label4.Tag = "";
            this.Label4.Text = "&Nivel:";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(17, 237);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(81, 17);
            this.Label3.TabIndex = 28;
            this.Label3.Tag = "";
            this.Label3.Text = "&Grupo";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(16, 325);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(81, 17);
            this.Label1.TabIndex = 29;
            this.Label1.Tag = "";
            this.Label1.Text = "&Unidad";
            // 
            // Frm_Local
            // 
            this.Frm_Local.BackColor = System.Drawing.SystemColors.Control;
            this.Frm_Local.Controls.Add(this.DirLocal);
            this.Frm_Local.Controls.Add(this.FilLocal);
            this.Frm_Local.Controls.Add(this.Frame1);
            this.Frm_Local.Controls.Add(this.DrvLocal);
            this.Frm_Local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frm_Local.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Frm_Local.Location = new System.Drawing.Point(16, 48);
            this.Frm_Local.Name = "Frm_Local";
            this.Frm_Local.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frm_Local.Size = new System.Drawing.Size(240, 521);
            this.Frm_Local.TabIndex = 18;
            this.Frm_Local.TabStop = false;
            this.Frm_Local.Tag = "";
            this.Frm_Local.Text = "Destino del archivo a generar";
            // 
            // DirLocal
            // 
            this.DirLocal.BackColor = System.Drawing.SystemColors.Window;
            this.DirLocal.Cursor = System.Windows.Forms.Cursors.Default;
            this.DirLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirLocal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DirLocal.FormattingEnabled = true;
            this.DirLocal.IntegralHeight = false;
            this.DirLocal.Location = new System.Drawing.Point(0, 103);
            this.DirLocal.Name = "DirLocal";
            this.DirLocal.Size = new System.Drawing.Size(225, 201);
            this.DirLocal.TabIndex = 23;
            this.DirLocal.Tag = "";
            this.DirLocal.Change += new System.EventHandler(this.DirLocal_Change);
            // 
            // FilLocal
            // 
            this.FilLocal.BackColor = System.Drawing.SystemColors.Window;
            this.FilLocal.Cursor = System.Windows.Forms.Cursors.Default;
            this.FilLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilLocal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FilLocal.FormattingEnabled = true;
            this.FilLocal.Location = new System.Drawing.Point(8, 320);
            this.FilLocal.Name = "FilLocal";
            this.FilLocal.Pattern = "*.txt";
            this.FilLocal.Size = new System.Drawing.Size(225, 186);
            this.FilLocal.TabIndex = 22;
            this.FilLocal.Tag = "";
            this.FilLocal.DoubleClick += new System.EventHandler(this.FilLocal_DoubleClick);
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.SystemColors.Control;
            this.Frame1.Controls.Add(this.txtDirNuevo);
            this.Frame1.Controls.Add(this.BtnDirNuevo);
            this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame1.Location = new System.Drawing.Point(8, 48);
            this.Frame1.Name = "Frame1";
            this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame1.Size = new System.Drawing.Size(233, 49);
            this.Frame1.TabIndex = 19;
            this.Frame1.TabStop = false;
            this.Frame1.Tag = "";
            this.Frame1.Text = "Crear Directorio";
            // 
            // txtDirNuevo
            // 
            this.txtDirNuevo.AcceptsReturn = true;
            this.txtDirNuevo.BackColor = System.Drawing.SystemColors.Window;
            this.txtDirNuevo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDirNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirNuevo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDirNuevo.Location = new System.Drawing.Point(8, 16);
            this.txtDirNuevo.MaxLength = 0;
            this.txtDirNuevo.Name = "txtDirNuevo";
            this.txtDirNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDirNuevo.Size = new System.Drawing.Size(177, 20);
            this.txtDirNuevo.TabIndex = 21;
            this.txtDirNuevo.Tag = "";
            this.txtDirNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDirNuevo_KeyPress);
            // 
            // DrvLocal
            // 
            this.DrvLocal.BackColor = System.Drawing.SystemColors.Window;
            this.DrvLocal.Cursor = System.Windows.Forms.Cursors.Default;
            this.DrvLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrvLocal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DrvLocal.FormattingEnabled = true;
            this.DrvLocal.Location = new System.Drawing.Point(8, 16);
            this.DrvLocal.Name = "DrvLocal";
            this.DrvLocal.Size = new System.Drawing.Size(217, 21);
            this.DrvLocal.TabIndex = 13;
            this.DrvLocal.Tag = "";
            this.DrvLocal.SelectedIndexChanged += new System.EventHandler(this.DrvLocal_SelectedIndexChanged);
            // 
            // TxtTelnet
            // 
            this.TxtTelnet.AcceptsReturn = true;
            this.TxtTelnet.BackColor = System.Drawing.SystemColors.WindowText;
            this.TxtTelnet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtTelnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelnet.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtTelnet.Location = new System.Drawing.Point(96, 400);
            this.TxtTelnet.MaxLength = 0;
            this.TxtTelnet.Multiline = true;
            this.TxtTelnet.Name = "TxtTelnet";
            this.TxtTelnet.ReadOnly = true;
            this.TxtTelnet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtTelnet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtTelnet.Size = new System.Drawing.Size(665, 33);
            this.TxtTelnet.TabIndex = 12;
            this.TxtTelnet.Tag = "";
            this.TxtTelnet.Visible = false;
            this.TxtTelnet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTelnet_KeyPress);
            this.TxtTelnet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTelnet_KeyDown);
            // 
            // TelnetSb
            // 
            this.TelnetSb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.TelnetSb.Location = new System.Drawing.Point(0, 735);
            this.TelnetSb.Name = "TelnetSb";
            this.TelnetSb.Size = new System.Drawing.Size(838, 22);
            this.TelnetSb.TabIndex = 17;
            this.TelnetSb.Tag = "";
            // 
            // TelnetWS
            // 
            this.TelnetWS.Enabled = true;
            this.TelnetWS.Location = new System.Drawing.Point(192, 464);
            this.TelnetWS.Name = "TelnetWS";
            this.TelnetWS.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TelnetWS.OcxState")));
            this.TelnetWS.Size = new System.Drawing.Size(28, 28);
            this.TelnetWS.TabIndex = 17;
            this.TelnetWS.Tag = "";
            this.TelnetWS.Error += new AxMSWinsockLib.DMSWinsockControlEvents_ErrorEventHandler(this.TelnetWS_Error);
            this.TelnetWS.CloseEvent += new System.EventHandler(this.TelnetWS_CloseEvent);
            this.TelnetWS.ConnectEvent += new System.EventHandler(this.TelnetWS_ConnectEvent);
            this.TelnetWS.DataArrival += new AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEventHandler(this.TelnetWS_DataArrival);
            // 
            // BtnConectar
            // 
            this.BtnConectar.BackColor = System.Drawing.SystemColors.Control;
            this.BtnConectar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnConectar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConectar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnConectar.Location = new System.Drawing.Point(8, 376);
            this.BtnConectar.Name = "BtnConectar";
            this.BtnConectar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnConectar.Size = new System.Drawing.Size(153, 25);
            this.BtnConectar.TabIndex = 15;
            this.BtnConectar.Tag = "";
            this.BtnConectar.Text = "&Conectar";
            this.BtnConectar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnConectar.UseVisualStyleBackColor = false;
            this.BtnConectar.Visible = false;
            this.BtnConectar.Click += new System.EventHandler(this.BtnConectar_Click);
            // 
            // txtComando
            // 
            this.txtComando.AcceptsReturn = true;
            this.txtComando.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtComando.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComando.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComando.ForeColor = System.Drawing.SystemColors.Window;
            this.txtComando.Location = new System.Drawing.Point(96, 464);
            this.txtComando.MaxLength = 0;
            this.txtComando.Name = "txtComando";
            this.txtComando.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtComando.Size = new System.Drawing.Size(664, 13);
            this.txtComando.TabIndex = 14;
            this.txtComando.Tag = "";
            this.txtComando.Visible = false;
            this.txtComando.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComando_KeyPress);
            this.txtComando.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComando_KeyDown);
            // 
            // PanToolBar
            // 
            this.PanToolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanToolBar.Controls.Add(this.BtnSalir);
            this.PanToolBar.Controls.Add(this.BtnDetener);
            this.PanToolBar.Controls.Add(this.BtnProcesar);
            this.PanToolBar.Location = new System.Drawing.Point(16, 3);
            this.PanToolBar.Name = "PanToolBar";
            this.PanToolBar.Size = new System.Drawing.Size(713, 40);
            this.PanToolBar.TabIndex = 30;
            this.PanToolBar.Tag = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SpdReportes
            // 
            this.SpdReportes.Location = new System.Drawing.Point(289, 415);
            this.SpdReportes.Name = "SpdReportes";
            this.SpdReportes.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SpdReportes.OcxState")));
            this.SpdReportes.Size = new System.Drawing.Size(417, 137);
            this.SpdReportes.TabIndex = 31;
            this.SpdReportes.ButtonClicked += new AxFPSpread._DSpreadEvents_ButtonClickedEventHandler(this.SpdReportes_ButtonClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 1);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(792, 19);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmTuxedo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(838, 757);
            this.Controls.Add(this.SpdReportes);
            this.Controls.Add(this.TelnetWS);
            this.Controls.Add(this.Frm_Local);
            this.Controls.Add(this.FrmParReporte);
            this.Controls.Add(this.TelnetSb);
            this.Controls.Add(this.TxtTelnet);
            this.Controls.Add(this.BtnConectar);
            this.Controls.Add(this.txtComando);
            this.Controls.Add(this.PanToolBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "FrmTuxedo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Generación de reportes en linea";
            this.Closed += new System.EventHandler(this.FrmTuxedo_Closed);
            this.FrmParReporte.ResumeLayout(false);
            this.FrmTipoReporte.ResumeLayout(false);
            this.FrmFechaReprote.ResumeLayout(false);
            this.FrmFechaReprote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._MskFecha_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._MskFecha_0)).EndInit();
            this.Frm_Local.ResumeLayout(false);
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            this.TelnetSb.ResumeLayout(false);
            this.TelnetSb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TelnetWS)).EndInit();
            this.PanToolBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpdReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        void InitializeOptReporte()
        {
            this.OptReporte[2] = _OptReporte_2;
            this.OptReporte[1] = _OptReporte_1;
            this.OptReporte[0] = _OptReporte_0;
        }
        void InitializeCboEmpresas()
        {
            this.CboEmpresas[2] = _CboEmpresas_2;
            this.CboEmpresas[0] = _CboEmpresas_0;
            this.CboEmpresas[1] = _CboEmpresas_1;
        }
        void InitializeMskFecha()
        {
            this.MskFecha[0] = _MskFecha_0;
            this.MskFecha[1] = _MskFecha_1;
        }
        void InitializeCboNivel()
        {
            this.CboNivel[0] = _CboNivel_0;
        }
        void InitializeLblFecha()
        {
            this.LblFecha[1] = _LblFecha_1;
            this.LblFecha[0] = _LblFecha_0;
        }
        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private AxFPSpread.AxvaSpread SpdReportes;
        private System.Windows.Forms.Button BtnProcesar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnDetener;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}