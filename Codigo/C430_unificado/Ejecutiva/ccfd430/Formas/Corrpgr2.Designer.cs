using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    partial class CORRPGR2
    {

        #region "Upgrade Support "
        private static CORRPGR2 m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static CORRPGR2 DefInstance
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
        public CORRPGR2()
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
            //This call is required by the Windows Form Designer.
            InitializeComponent(); //AIS-1213 echasiquiza
            InitializeHelp();
            InitializeID_REE_ETI_PNL();
            //This form is an MDI child.
            //This code simulates the VB6 
            // functionality of automatically
            // loading and showing an MDI
            // child's parent.
            this.MdiParent = TCd430.CORMDIBN.DefInstance;
            TCd430.CORMDIBN.DefInstance.Show();
        }
        public static CORRPGR2 CreateInstance()
        {
            CORRPGR2 theInstance = new CORRPGR2();
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
        public AxThreed.AxSSPanel[] ID_REE_ETI_PNL = new AxThreed.AxSSPanel[4];
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPGR2));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_REE_PPL_PNL = new AxThreed.AxSSPanel();
            this.ID_RGR_MASG_3PB = new System.Windows.Forms.Button();
            this.ID_REE_ALT_PB = new System.Windows.Forms.Button();
            this._ID_REE_ETI_PNL_3Label_Text = new System.Windows.Forms.Label();
            this._ID_REE_ETI_PNL_3 = new AxThreed.AxSSPanel();
            this.ID_RGR_MES_COB = new System.Windows.Forms.ComboBox();
            this._ID_REE_ETI_PNL_2Label_Text = new System.Windows.Forms.Label();
            this._ID_REE_ETI_PNL_2 = new AxThreed.AxSSPanel();
            this._ID_REE_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
            this._ID_REE_ETI_PNL_0 = new AxThreed.AxSSPanel();
            this.ID_RGR_GPO_LB = new System.Windows.Forms.ListBox();
            this.ID_CEG_IRE_CKB = new AxThreed.AxSSCheck();
            this.ID_REE_CER_PB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ID_REE_PPL_PNL)).BeginInit();
            this.ID_REE_PPL_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEG_IRE_CKB)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_REE_PPL_PNL
            // 
            this.ID_REE_PPL_PNL.Controls.Add(this.ID_RGR_MASG_3PB);
            this.ID_REE_PPL_PNL.Controls.Add(this.ID_REE_ALT_PB);
            this.ID_REE_PPL_PNL.Location = new System.Drawing.Point(1, 2);
            this.ID_REE_PPL_PNL.Name = "ID_REE_PPL_PNL";
            this.ID_REE_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REE_PPL_PNL.OcxState")));
            this.ID_REE_PPL_PNL.Size = new System.Drawing.Size(285, 321);
            this.ID_REE_PPL_PNL.TabIndex = 1;
            this.ID_REE_PPL_PNL.Tag = "";
            // 
            // ID_RGR_MASG_3PB
            // 
            this.ID_RGR_MASG_3PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_RGR_MASG_3PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_RGR_MASG_3PB.Enabled = false;
            this.ID_RGR_MASG_3PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_RGR_MASG_3PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_RGR_MASG_3PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_RGR_MASG_3PB.Location = new System.Drawing.Point(103, 283);
            this.ID_RGR_MASG_3PB.Name = "ID_RGR_MASG_3PB";
            this.ID_RGR_MASG_3PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_RGR_MASG_3PB.Size = new System.Drawing.Size(74, 22);
            this.ID_RGR_MASG_3PB.TabIndex = 2;
            this.ID_RGR_MASG_3PB.Tag = "Cancela";
            this.ID_RGR_MASG_3PB.Text = "&Más";
            this.ID_RGR_MASG_3PB.UseVisualStyleBackColor = false;
            this.ID_RGR_MASG_3PB.Click += new System.EventHandler(this.ID_RGR_MASG_3PB_Click);
            // 
            // ID_REE_ALT_PB
            // 
            this.ID_REE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_REE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_REE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_REE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_REE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_REE_ALT_PB.Location = new System.Drawing.Point(24, 283);
            this.ID_REE_ALT_PB.Name = "ID_REE_ALT_PB";
            this.ID_REE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_REE_ALT_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_REE_ALT_PB.TabIndex = 4;
            this.ID_REE_ALT_PB.Tag = "";
            this.ID_REE_ALT_PB.Text = "&Reporte";
            this.ID_REE_ALT_PB.UseVisualStyleBackColor = false;
            this.ID_REE_ALT_PB.Click += new System.EventHandler(this.ID_REE_ALT_PB_Click);
            // 
            // _ID_REE_ETI_PNL_3Label_Text
            // 
            this._ID_REE_ETI_PNL_3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_REE_ETI_PNL_3Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._ID_REE_ETI_PNL_3Label_Text.Location = new System.Drawing.Point(23, 20);
            this._ID_REE_ETI_PNL_3Label_Text.Name = "_ID_REE_ETI_PNL_3Label_Text";
            this._ID_REE_ETI_PNL_3Label_Text.Size = new System.Drawing.Size(91, 23);
            this._ID_REE_ETI_PNL_3Label_Text.TabIndex = 2;
            this._ID_REE_ETI_PNL_3Label_Text.Tag = "";
            this._ID_REE_ETI_PNL_3Label_Text.Text = " &Mes de corte";
            this._ID_REE_ETI_PNL_3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _ID_REE_ETI_PNL_3
            // 
            this._ID_REE_ETI_PNL_3.Location = new System.Drawing.Point(21, 20);
            this._ID_REE_ETI_PNL_3.Name = "_ID_REE_ETI_PNL_3";
            this._ID_REE_ETI_PNL_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_REE_ETI_PNL_3.OcxState")));
            this._ID_REE_ETI_PNL_3.Size = new System.Drawing.Size(97, 25);
            this._ID_REE_ETI_PNL_3.TabIndex = 3;
            this._ID_REE_ETI_PNL_3.Tag = "";
            // 
            // ID_RGR_MES_COB
            // 
            this.ID_RGR_MES_COB.BackColor = System.Drawing.Color.White;
            this.ID_RGR_MES_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_RGR_MES_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_RGR_MES_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_RGR_MES_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_RGR_MES_COB.Location = new System.Drawing.Point(119, 22);
            this.ID_RGR_MES_COB.Name = "ID_RGR_MES_COB";
            this.ID_RGR_MES_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_RGR_MES_COB.Size = new System.Drawing.Size(147, 21);
            this.ID_RGR_MES_COB.TabIndex = 8;
            this.ID_RGR_MES_COB.Tag = "";
            // 
            // _ID_REE_ETI_PNL_2Label_Text
            // 
            this._ID_REE_ETI_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_REE_ETI_PNL_2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._ID_REE_ETI_PNL_2Label_Text.Location = new System.Drawing.Point(22, 51);
            this._ID_REE_ETI_PNL_2Label_Text.Name = "_ID_REE_ETI_PNL_2Label_Text";
            this._ID_REE_ETI_PNL_2Label_Text.Size = new System.Drawing.Size(57, 15);
            this._ID_REE_ETI_PNL_2Label_Text.TabIndex = 9;
            this._ID_REE_ETI_PNL_2Label_Text.Tag = "";
            this._ID_REE_ETI_PNL_2Label_Text.Text = "  &Clave    ";
            this._ID_REE_ETI_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _ID_REE_ETI_PNL_2
            // 
            this._ID_REE_ETI_PNL_2.Location = new System.Drawing.Point(21, 45);
            this._ID_REE_ETI_PNL_2.Name = "_ID_REE_ETI_PNL_2";
            this._ID_REE_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_REE_ETI_PNL_2.OcxState")));
            this._ID_REE_ETI_PNL_2.Size = new System.Drawing.Size(63, 26);
            this._ID_REE_ETI_PNL_2.TabIndex = 10;
            this._ID_REE_ETI_PNL_2.Tag = "";
            // 
            // _ID_REE_ETI_PNL_0Label_Text
            // 
            this._ID_REE_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_REE_ETI_PNL_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._ID_REE_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(85, 47);
            this._ID_REE_ETI_PNL_0Label_Text.Name = "_ID_REE_ETI_PNL_0Label_Text";
            this._ID_REE_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(187, 24);
            this._ID_REE_ETI_PNL_0Label_Text.TabIndex = 11;
            this._ID_REE_ETI_PNL_0Label_Text.Tag = "";
            this._ID_REE_ETI_PNL_0Label_Text.Text = "              &Grupo     ";
            this._ID_REE_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _ID_REE_ETI_PNL_0
            // 
            this._ID_REE_ETI_PNL_0.Location = new System.Drawing.Point(85, 45);
            this._ID_REE_ETI_PNL_0.Name = "_ID_REE_ETI_PNL_0";
            this._ID_REE_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_REE_ETI_PNL_0.OcxState")));
            this._ID_REE_ETI_PNL_0.Size = new System.Drawing.Size(187, 26);
            this._ID_REE_ETI_PNL_0.TabIndex = 12;
            this._ID_REE_ETI_PNL_0.Tag = "";
            // 
            // ID_RGR_GPO_LB
            // 
            this.ID_RGR_GPO_LB.BackColor = System.Drawing.Color.White;
            this.ID_RGR_GPO_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_RGR_GPO_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_RGR_GPO_LB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_RGR_GPO_LB.Location = new System.Drawing.Point(24, 76);
            this.ID_RGR_GPO_LB.Name = "ID_RGR_GPO_LB";
            this.ID_RGR_GPO_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_RGR_GPO_LB.Size = new System.Drawing.Size(246, 173);
            this.ID_RGR_GPO_LB.Sorted = true;
            this.ID_RGR_GPO_LB.TabIndex = 13;
            this.ID_RGR_GPO_LB.Tag = "";
            // 
            // ID_CEG_IRE_CKB
            // 
            this.ID_CEG_IRE_CKB.Location = new System.Drawing.Point(25, 255);
            this.ID_CEG_IRE_CKB.Name = "ID_CEG_IRE_CKB";
            this.ID_CEG_IRE_CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEG_IRE_CKB.OcxState")));
            this.ID_CEG_IRE_CKB.Size = new System.Drawing.Size(209, 15);
            this.ID_CEG_IRE_CKB.TabIndex = 14;
            this.ID_CEG_IRE_CKB.Tag = "";
            // 
            // ID_REE_CER_PB
            // 
            this.ID_REE_CER_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_REE_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_REE_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_REE_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_REE_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_REE_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_REE_CER_PB.Location = new System.Drawing.Point(184, 286);
            this.ID_REE_CER_PB.Name = "ID_REE_CER_PB";
            this.ID_REE_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_REE_CER_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_REE_CER_PB.TabIndex = 15;
            this.ID_REE_CER_PB.Tag = "Cancela";
            this.ID_REE_CER_PB.Text = "&Salir";
            this.ID_REE_CER_PB.UseVisualStyleBackColor = false;
            this.ID_REE_CER_PB.Click += new System.EventHandler(this.ID_REE_CER_PB_Click);
            // 
            // CORRPGR2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(286, 324);
            this.Controls.Add(this.ID_REE_CER_PB);
            this.Controls.Add(this.ID_CEG_IRE_CKB);
            this.Controls.Add(this.ID_RGR_GPO_LB);
            this.Controls.Add(this._ID_REE_ETI_PNL_0);
            this.Controls.Add(this._ID_REE_ETI_PNL_0Label_Text);
            this.Controls.Add(this._ID_REE_ETI_PNL_2);
            this.Controls.Add(this._ID_REE_ETI_PNL_2Label_Text);
            this.Controls.Add(this.ID_RGR_MES_COB);
            this.Controls.Add(this._ID_REE_ETI_PNL_3);
            this.Controls.Add(this._ID_REE_ETI_PNL_3Label_Text);
            this.Controls.Add(this.ID_REE_PPL_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(187, 126);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORRPGR2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Grupo / Empresa";
            this.Closed += new System.EventHandler(this.CORRPGR2_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.ID_REE_PPL_PNL)).EndInit();
            this.ID_REE_PPL_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEG_IRE_CKB)).EndInit();
            this.ResumeLayout(false);

        }
        void InitializeID_REE_ETI_PNL()
        {
            this.ID_REE_ETI_PNL[3] = _ID_REE_ETI_PNL_3;
            this.ID_REE_ETI_PNL[2] = _ID_REE_ETI_PNL_2;
            this.ID_REE_ETI_PNL[0] = _ID_REE_ETI_PNL_0;
        }
        #endregion

        public AxThreed.AxSSPanel ID_REE_PPL_PNL;
        public System.Windows.Forms.Button ID_RGR_MASG_3PB;
        public System.Windows.Forms.Button ID_REE_ALT_PB;
        private System.Windows.Forms.Label _ID_REE_ETI_PNL_3Label_Text;
        private AxThreed.AxSSPanel _ID_REE_ETI_PNL_3;
        public System.Windows.Forms.ComboBox ID_RGR_MES_COB;
        private System.Windows.Forms.Label _ID_REE_ETI_PNL_2Label_Text;
        private AxThreed.AxSSPanel _ID_REE_ETI_PNL_2;
        private System.Windows.Forms.Label _ID_REE_ETI_PNL_0Label_Text;
        private AxThreed.AxSSPanel _ID_REE_ETI_PNL_0;
        public System.Windows.Forms.ListBox ID_RGR_GPO_LB;
        public AxThreed.AxSSCheck ID_CEG_IRE_CKB;
        public System.Windows.Forms.Button ID_REE_CER_PB;
    }
}