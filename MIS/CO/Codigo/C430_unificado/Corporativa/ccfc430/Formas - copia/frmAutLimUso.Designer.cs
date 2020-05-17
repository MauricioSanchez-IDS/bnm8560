using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    partial class frmAutLimUso
    {

        #region "Upgrade Support "
        private static frmAutLimUso m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static frmAutLimUso DefInstance
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
        public frmAutLimUso()
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
            //This form is an MDI child.
            //This code simulates the VB6 
            // functionality of automatically
            // loading and showing an MDI
            // child's parent.
            this.MdiParent = TCc430.CORMDIBN.DefInstance;
            TCc430.CORMDIBN.DefInstance.Show();
        }
        public static frmAutLimUso CreateInstance()
        {
            frmAutLimUso theInstance = new frmAutLimUso();
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
        public AxMSComctlLib.AxImageList imlImagenes;
        //public AxMSComctlLib.AxStatusBar StatusBar1;
        public AxMSComctlLib.AxToolbar tbrStandar;
        public System.Windows.Forms.TextBox txtLog;
        public AxMSComctlLib.AxListView lvwCuentas;
        public AxMSComCtl2.AxDTPicker dtpAux;
        public System.Windows.Forms.PictureBox Image1;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        //[System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutLimUso));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imlImagenes = new AxMSComctlLib.AxImageList();
            this.tbrStandar = new AxMSComctlLib.AxToolbar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lvwCuentas = new AxMSComctlLib.AxListView();
            this.dtpAux = new AxMSComCtl2.AxDTPicker();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.imlImagenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrStandar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // imlImagenes
            // 
            this.imlImagenes.Enabled = true;
            this.imlImagenes.Location = new System.Drawing.Point(0, 92);
            this.imlImagenes.Name = "imlImagenes";
            this.imlImagenes.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("imlImagenes.OcxState")));
            this.imlImagenes.Size = new System.Drawing.Size(38, 38);
            this.imlImagenes.TabIndex = 4;
            this.imlImagenes.Tag = "";
            // 
            // tbrStandar
            // 
            this.tbrStandar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbrStandar.Location = new System.Drawing.Point(0, 0);
            this.tbrStandar.Name = "tbrStandar";
            this.tbrStandar.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("tbrStandar.OcxState")));
            this.tbrStandar.Size = new System.Drawing.Size(1043, 22);
            this.tbrStandar.TabIndex = 2;
            this.tbrStandar.Tag = "";
            this.tbrStandar.ButtonClick += new AxMSComctlLib.IToolbarEvents_ButtonClickEventHandler(this.tbrStandar_ButtonClick);
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLog.Location = new System.Drawing.Point(9, 337);
            this.txtLog.MaxLength = 0;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1022, 175);
            this.txtLog.TabIndex = 0;
            this.txtLog.Tag = "";
            this.txtLog.Text = "txtLog\r\n";
            // 
            // lvwCuentas
            // 
            this.lvwCuentas.Location = new System.Drawing.Point(9, 32);
            this.lvwCuentas.Name = "lvwCuentas";
            this.lvwCuentas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("lvwCuentas.OcxState")));
            this.lvwCuentas.Size = new System.Drawing.Size(1022, 299);
            this.lvwCuentas.TabIndex = 1;
            this.lvwCuentas.Tag = "";
            this.lvwCuentas.ColumnClick += new AxMSComctlLib.ListViewEvents_ColumnClickEventHandler(this.lvwCuentas_ColumnClick);
            // 
            // dtpAux
            // 
            this.dtpAux.Location = new System.Drawing.Point(0, 0);
            this.dtpAux.Name = "dtpAux";
            this.dtpAux.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dtpAux.OcxState")));
            this.dtpAux.Size = new System.Drawing.Size(169, 21);
            this.dtpAux.TabIndex = 4;
            this.dtpAux.Tag = "";
            this.dtpAux.Visible = false;
            // 
            // Image1
            // 
            this.Image1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Image1.Location = new System.Drawing.Point(660, 252);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(9, 29);
            this.Image1.TabIndex = 5;
            this.Image1.TabStop = false;
            this.Image1.Tag = "";
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 518);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.StatusBar1.ShowPanels = true;
            this.StatusBar1.Size = new System.Drawing.Size(1043, 25);
            this.StatusBar1.TabIndex = 3;
            this.StatusBar1.Tag = "";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 300;
            // 
            // frmAutLimUso
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1043, 543);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.lvwCuentas);
            this.Controls.Add(this.imlImagenes);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.tbrStandar);
            this.Controls.Add(this.dtpAux);
            this.Controls.Add(this.Image1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "frmAutLimUso";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Autorización de Límites de Uso";
            this.Closed += new System.EventHandler(this.frmAutLimUso_Closed);
            this.Resize += new System.EventHandler(this.frmAutLimUso_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imlImagenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrStandar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusBar StatusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
    }
}