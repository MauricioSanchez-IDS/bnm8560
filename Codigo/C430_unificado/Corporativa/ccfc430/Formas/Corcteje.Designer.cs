using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    partial class CORCTEJE
    {

        #region "Upgrade Support "
        private static CORCTEJE m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static CORCTEJE DefInstance
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
        public CORCTEJE()
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
            InitializeComponent();
            InitializeHelp();
            InitializeID_CEE_ETI_PNL();
            //This form is an MDI child.
            //This code simulates the VB6 
            // functionality of automatically
            // loading and showing an MDI
            // child's parent.
            this.MdiParent = TCc430.CORMDIBN.DefInstance;
            TCc430.CORMDIBN.DefInstance.Show();
        }
        public static CORCTEJE CreateInstance()
        {
            CORCTEJE theInstance = new CORCTEJE();
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
        public System.Windows.Forms.Button cmdReenvios;
        public System.Windows.Forms.Button cmdConsMasivas;
        public System.Windows.Forms.Button cmdAltasMasivas;
        public System.Windows.Forms.Button ID_CEE_CONS111_PB;
        public System.Windows.Forms.ComboBox ID_CEE_EMP_COB;
        public System.Windows.Forms.ComboBox ID_CEE_GRU_COB;
        public System.Windows.Forms.ListBox ID_CEE_EMP_LB;
        public System.Windows.Forms.Button ID_CEE_CAM_PB;
        public System.Windows.Forms.Button ID_CEE_BAJ_PB;
        public System.Windows.Forms.Button ID_CEE_ALT_PB;
        public System.Windows.Forms.Button ID_CEE_SAL_PB;
        public System.Windows.Forms.Button ID_CEE_CON_PB;
        public System.Windows.Forms.Button ID_CEE_MAS_3PB;
        private System.Windows.Forms.Label _ID_CEE_ETI_PNL_1;
        private System.Windows.Forms.Label _ID_CEE_ETI_PNL_0;
        private System.Windows.Forms.Label _ID_CEE_ETI_PNL_7;
        private System.Windows.Forms.Label _ID_CEE_ETI_PNL_2;
        public System.Windows.Forms.Button ID_CEM_MASG_3PB;
        public System.Windows.Forms.Button ID_CEM_MASE_3PB;
        public AxThreed.AxSSCheck ID_CEE_IRE_CKB;
        public System.Windows.Forms.Panel ID_CEE_PPL_PNL;
        public System.Windows.Forms.Label[] ID_CEE_ETI_PNL = new System.Windows.Forms.Label[8];
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTEJE));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_CEE_PPL_PNL = new System.Windows.Forms.Panel();
            this.ID_CEE_SIG_EJE = new System.Windows.Forms.TextBox();
            this.ID_CEE_ETI_PNL3 = new System.Windows.Forms.Label();
            this.ID_CEE_EMP_LB = new System.Windows.Forms.ListBox();
            this.ID_CEE_MAS_3PB = new System.Windows.Forms.Button();
            this.ID_CEE_CON_PB = new System.Windows.Forms.Button();
            this.ID_CEE_SAL_PB = new System.Windows.Forms.Button();
            this.ID_CEE_CAM_PB = new System.Windows.Forms.Button();
            this.ID_CEE_BAJ_PB = new System.Windows.Forms.Button();
            this.ID_CEE_ALT_PB = new System.Windows.Forms.Button();
            this._ID_CEE_ETI_PNL_1 = new System.Windows.Forms.Label();
            this.ID_CEM_MASG_3PB = new System.Windows.Forms.Button();
            this.ID_CEM_MASE_3PB = new System.Windows.Forms.Button();
            this.ID_CEE_IRE_CKB = new AxThreed.AxSSCheck();
            this._ID_CEE_ETI_PNL_0 = new System.Windows.Forms.Label();
            this._ID_CEE_ETI_PNL_7 = new System.Windows.Forms.Label();
            this._ID_CEE_ETI_PNL_2 = new System.Windows.Forms.Label();
            this.cmdAltasMasivas = new System.Windows.Forms.Button();
            this.cmdConsMasivas = new System.Windows.Forms.Button();
            this.cmdReenvios = new System.Windows.Forms.Button();
            this.ID_CEE_CONS111_PB = new System.Windows.Forms.Button();
            this.ID_CEE_GRU_COB = new System.Windows.Forms.ComboBox();
            this.ID_CEE_EMP_COB = new System.Windows.Forms.ComboBox();
            this.ID_CEE_PPL_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEE_IRE_CKB)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_CEE_PPL_PNL
            // 
            this.ID_CEE_PPL_PNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_SIG_EJE);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_ETI_PNL3);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_EMP_LB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_MAS_3PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_CON_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_SAL_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_CAM_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_BAJ_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_ALT_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_1);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEM_MASG_3PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEM_MASE_3PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_IRE_CKB);
            this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_0);
            this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_7);
            this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_2);
            this.ID_CEE_PPL_PNL.Controls.Add(this.cmdAltasMasivas);
            this.ID_CEE_PPL_PNL.Controls.Add(this.cmdConsMasivas);
            this.ID_CEE_PPL_PNL.Controls.Add(this.cmdReenvios);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_CONS111_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_GRU_COB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_EMP_COB);
            this.ID_CEE_PPL_PNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_PPL_PNL.Location = new System.Drawing.Point(-2, 0);
            this.ID_CEE_PPL_PNL.Name = "ID_CEE_PPL_PNL";
            this.ID_CEE_PPL_PNL.Size = new System.Drawing.Size(438, 396);
            this.ID_CEE_PPL_PNL.TabIndex = 10;
            this.ID_CEE_PPL_PNL.Tag = "";
            // 
            // ID_CEE_SIG_EJE
            // 
            this.ID_CEE_SIG_EJE.Enabled = false;
            this.ID_CEE_SIG_EJE.Location = new System.Drawing.Point(326, 49);
            this.ID_CEE_SIG_EJE.Name = "ID_CEE_SIG_EJE";
            this.ID_CEE_SIG_EJE.Size = new System.Drawing.Size(102, 20);
            this.ID_CEE_SIG_EJE.TabIndex = 22;
            this.ID_CEE_SIG_EJE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ID_CEE_ETI_PNL3
            // 
            this.ID_CEE_ETI_PNL3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ID_CEE_ETI_PNL3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_CEE_ETI_PNL3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_ETI_PNL3.Location = new System.Drawing.Point(326, 22);
            this.ID_CEE_ETI_PNL3.Name = "ID_CEE_ETI_PNL3";
            this.ID_CEE_ETI_PNL3.Size = new System.Drawing.Size(102, 22);
            this.ID_CEE_ETI_PNL3.TabIndex = 21;
            this.ID_CEE_ETI_PNL3.Tag = "";
            this.ID_CEE_ETI_PNL3.Text = " &Sig. Ejecutivo";
            // 
            // ID_CEE_EMP_LB
            // 
            this.ID_CEE_EMP_LB.BackColor = System.Drawing.Color.White;
            this.ID_CEE_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_EMP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEE_EMP_LB.Location = new System.Drawing.Point(12, 96);
            this.ID_CEE_EMP_LB.Name = "ID_CEE_EMP_LB";
            this.ID_CEE_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_EMP_LB.Size = new System.Drawing.Size(298, 251);
            this.ID_CEE_EMP_LB.Sorted = true;
            this.ID_CEE_EMP_LB.TabIndex = 9;
            this.ID_CEE_EMP_LB.Tag = "";
            this.ID_CEE_EMP_LB.DoubleClick += new System.EventHandler(this.ID_CEE_EMP_LB_DoubleClick);
            // 
            // ID_CEE_MAS_3PB
            // 
            this.ID_CEE_MAS_3PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_MAS_3PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_MAS_3PB.Enabled = false;
            this.ID_CEE_MAS_3PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_MAS_3PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_MAS_3PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_MAS_3PB.Location = new System.Drawing.Point(317, 350);
            this.ID_CEE_MAS_3PB.Name = "ID_CEE_MAS_3PB";
            this.ID_CEE_MAS_3PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_MAS_3PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_MAS_3PB.TabIndex = 6;
            this.ID_CEE_MAS_3PB.Tag = "A";
            this.ID_CEE_MAS_3PB.Text = "&Más";
            this.ID_CEE_MAS_3PB.UseVisualStyleBackColor = false;
            this.ID_CEE_MAS_3PB.Visible = false;
            this.ID_CEE_MAS_3PB.Click += new System.EventHandler(this.ID_CEE_MAS_3PB_Click);
            // 
            // ID_CEE_CON_PB
            // 
            this.ID_CEE_CON_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_CON_PB.Location = new System.Drawing.Point(318, 154);
            this.ID_CEE_CON_PB.Name = "ID_CEE_CON_PB";
            this.ID_CEE_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_CON_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_CON_PB.TabIndex = 3;
            this.ID_CEE_CON_PB.Tag = "";
            this.ID_CEE_CON_PB.Text = "C&onsultas...";
            this.ID_CEE_CON_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_CON_PB.Click += new System.EventHandler(this.ID_CEE_CON_PB_Click);
            // 
            // ID_CEE_SAL_PB
            // 
            this.ID_CEE_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_CEE_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_SAL_PB.Location = new System.Drawing.Point(317, 318);
            this.ID_CEE_SAL_PB.Name = "ID_CEE_SAL_PB";
            this.ID_CEE_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_SAL_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_SAL_PB.TabIndex = 5;
            this.ID_CEE_SAL_PB.Tag = "";
            this.ID_CEE_SAL_PB.Text = "&Salir";
            this.ID_CEE_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_SAL_PB.Click += new System.EventHandler(this.ID_CEE_SAL_PB_Click);
            // 
            // ID_CEE_CAM_PB
            // 
            this.ID_CEE_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_CAM_PB.Location = new System.Drawing.Point(318, 124);
            this.ID_CEE_CAM_PB.Name = "ID_CEE_CAM_PB";
            this.ID_CEE_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_CAM_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_CAM_PB.TabIndex = 2;
            this.ID_CEE_CAM_PB.Tag = "";
            this.ID_CEE_CAM_PB.Text = "&Cambios...";
            this.ID_CEE_CAM_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_CAM_PB.Click += new System.EventHandler(this.ID_CEE_CAM_PB_Click);
            // 
            // ID_CEE_BAJ_PB
            // 
            this.ID_CEE_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_BAJ_PB.Enabled = false;
            this.ID_CEE_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_BAJ_PB.Location = new System.Drawing.Point(181, 303);
            this.ID_CEE_BAJ_PB.Name = "ID_CEE_BAJ_PB";
            this.ID_CEE_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_BAJ_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_BAJ_PB.TabIndex = 1;
            this.ID_CEE_BAJ_PB.Tag = "";
            this.ID_CEE_BAJ_PB.Text = "&Bajas";
            this.ID_CEE_BAJ_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_BAJ_PB.Visible = false;
            this.ID_CEE_BAJ_PB.Click += new System.EventHandler(this.ID_CEE_BAJ_PB_Click);
            // 
            // ID_CEE_ALT_PB
            // 
            this.ID_CEE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_ALT_PB.Location = new System.Drawing.Point(317, 95);
            this.ID_CEE_ALT_PB.Name = "ID_CEE_ALT_PB";
            this.ID_CEE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_ALT_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_ALT_PB.TabIndex = 0;
            this.ID_CEE_ALT_PB.Tag = "";
            this.ID_CEE_ALT_PB.Text = "&Altas...";
            this.ID_CEE_ALT_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_ALT_PB.Click += new System.EventHandler(this.ID_CEE_ALT_PB_Click);
            // 
            // _ID_CEE_ETI_PNL_1
            // 
            this._ID_CEE_ETI_PNL_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._ID_CEE_ETI_PNL_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_CEE_ETI_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEE_ETI_PNL_1.Location = new System.Drawing.Point(12, 23);
            this._ID_CEE_ETI_PNL_1.Name = "_ID_CEE_ETI_PNL_1";
            this._ID_CEE_ETI_PNL_1.Size = new System.Drawing.Size(73, 22);
            this._ID_CEE_ETI_PNL_1.TabIndex = 11;
            this._ID_CEE_ETI_PNL_1.Tag = "";
            this._ID_CEE_ETI_PNL_1.Text = " &Grupo";
            // 
            // ID_CEM_MASG_3PB
            // 
            this.ID_CEM_MASG_3PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_MASG_3PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_MASG_3PB.Location = new System.Drawing.Point(298, 21);
            this.ID_CEM_MASG_3PB.Name = "ID_CEM_MASG_3PB";
            this.ID_CEM_MASG_3PB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ID_CEM_MASG_3PB.Size = new System.Drawing.Size(22, 21);
            this.ID_CEM_MASG_3PB.TabIndex = 12;
            this.ID_CEM_MASG_3PB.Tag = "";
            this.ID_CEM_MASG_3PB.Text = "...";
            this.ID_CEM_MASG_3PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ID_CEM_MASG_3PB.UseVisualStyleBackColor = false;
            this.ID_CEM_MASG_3PB.Click += new System.EventHandler(this.ID_CEM_MASG_3PB_ClickEvent);
            // 
            // ID_CEM_MASE_3PB
            // 
            this.ID_CEM_MASE_3PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_MASE_3PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_MASE_3PB.Location = new System.Drawing.Point(299, 45);
            this.ID_CEM_MASE_3PB.Name = "ID_CEM_MASE_3PB";
            this.ID_CEM_MASE_3PB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ID_CEM_MASE_3PB.Size = new System.Drawing.Size(22, 21);
            this.ID_CEM_MASE_3PB.TabIndex = 14;
            this.ID_CEM_MASE_3PB.Tag = "";
            this.ID_CEM_MASE_3PB.Text = "...";
            this.ID_CEM_MASE_3PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ID_CEM_MASE_3PB.UseVisualStyleBackColor = false;
            this.ID_CEM_MASE_3PB.Click += new System.EventHandler(this.ID_CEM_MASE_3PB_ClickEvent);
            // 
            // ID_CEE_IRE_CKB
            // 
            this.ID_CEE_IRE_CKB.Location = new System.Drawing.Point(12, 362);
            this.ID_CEE_IRE_CKB.Name = "ID_CEE_IRE_CKB";
            this.ID_CEE_IRE_CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEE_IRE_CKB.OcxState")));
            this.ID_CEE_IRE_CKB.Size = new System.Drawing.Size(212, 22);
            this.ID_CEE_IRE_CKB.TabIndex = 17;
            this.ID_CEE_IRE_CKB.Tag = "";
            // 
            // _ID_CEE_ETI_PNL_0
            // 
            this._ID_CEE_ETI_PNL_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._ID_CEE_ETI_PNL_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_CEE_ETI_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEE_ETI_PNL_0.Location = new System.Drawing.Point(12, 47);
            this._ID_CEE_ETI_PNL_0.Name = "_ID_CEE_ETI_PNL_0";
            this._ID_CEE_ETI_PNL_0.Size = new System.Drawing.Size(73, 22);
            this._ID_CEE_ETI_PNL_0.TabIndex = 13;
            this._ID_CEE_ETI_PNL_0.Tag = "";
            this._ID_CEE_ETI_PNL_0.Text = " &Empresa  ";
            // 
            // _ID_CEE_ETI_PNL_7
            // 
            this._ID_CEE_ETI_PNL_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._ID_CEE_ETI_PNL_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_CEE_ETI_PNL_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEE_ETI_PNL_7.Location = new System.Drawing.Point(12, 71);
            this._ID_CEE_ETI_PNL_7.Name = "_ID_CEE_ETI_PNL_7";
            this._ID_CEE_ETI_PNL_7.Size = new System.Drawing.Size(35, 22);
            this._ID_CEE_ETI_PNL_7.TabIndex = 15;
            this._ID_CEE_ETI_PNL_7.Tag = "";
            this._ID_CEE_ETI_PNL_7.Text = " No.";
            // 
            // _ID_CEE_ETI_PNL_2
            // 
            this._ID_CEE_ETI_PNL_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._ID_CEE_ETI_PNL_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_CEE_ETI_PNL_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEE_ETI_PNL_2.Location = new System.Drawing.Point(42, 71);
            this._ID_CEE_ETI_PNL_2.Name = "_ID_CEE_ETI_PNL_2";
            this._ID_CEE_ETI_PNL_2.Size = new System.Drawing.Size(270, 22);
            this._ID_CEE_ETI_PNL_2.TabIndex = 16;
            this._ID_CEE_ETI_PNL_2.Tag = "";
            this._ID_CEE_ETI_PNL_2.Text = " E&jecutivo";
            this._ID_CEE_ETI_PNL_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdAltasMasivas
            // 
            this.cmdAltasMasivas.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAltasMasivas.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdAltasMasivas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdAltasMasivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAltasMasivas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdAltasMasivas.Location = new System.Drawing.Point(317, 210);
            this.cmdAltasMasivas.Name = "cmdAltasMasivas";
            this.cmdAltasMasivas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdAltasMasivas.Size = new System.Drawing.Size(111, 25);
            this.cmdAltasMasivas.TabIndex = 18;
            this.cmdAltasMasivas.Tag = "";
            this.cmdAltasMasivas.Text = "Altas Masi&vas...";
            this.cmdAltasMasivas.UseVisualStyleBackColor = false;
            this.cmdAltasMasivas.Click += new System.EventHandler(this.cmdAltasMasivas_Click);
            // 
            // cmdConsMasivas
            // 
            this.cmdConsMasivas.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConsMasivas.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdConsMasivas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdConsMasivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsMasivas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdConsMasivas.Location = new System.Drawing.Point(317, 240);
            this.cmdConsMasivas.Name = "cmdConsMasivas";
            this.cmdConsMasivas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdConsMasivas.Size = new System.Drawing.Size(111, 33);
            this.cmdConsMasivas.TabIndex = 19;
            this.cmdConsMasivas.Tag = "";
            this.cmdConsMasivas.Text = "&Rechazos de Altas";
            this.cmdConsMasivas.UseVisualStyleBackColor = false;
            this.cmdConsMasivas.Click += new System.EventHandler(this.cmdConsMasivas_Click);
            // 
            // cmdReenvios
            // 
            this.cmdReenvios.BackColor = System.Drawing.SystemColors.Control;
            this.cmdReenvios.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdReenvios.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdReenvios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReenvios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdReenvios.Location = new System.Drawing.Point(317, 277);
            this.cmdReenvios.Name = "cmdReenvios";
            this.cmdReenvios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdReenvios.Size = new System.Drawing.Size(111, 25);
            this.cmdReenvios.TabIndex = 20;
            this.cmdReenvios.Tag = "";
            this.cmdReenvios.Text = "Reenvios";
            this.cmdReenvios.UseVisualStyleBackColor = false;
            this.cmdReenvios.Click += new System.EventHandler(this.cmdReenvios_Click);
            // 
            // ID_CEE_CONS111_PB
            // 
            this.ID_CEE_CONS111_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_CONS111_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_CONS111_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_CONS111_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_CONS111_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_CONS111_PB.Location = new System.Drawing.Point(317, 182);
            this.ID_CEE_CONS111_PB.Name = "ID_CEE_CONS111_PB";
            this.ID_CEE_CONS111_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_CONS111_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_CONS111_PB.TabIndex = 4;
            this.ID_CEE_CONS111_PB.Tag = "";
            this.ID_CEE_CONS111_PB.Text = "Consul&ta S111...";
            this.ID_CEE_CONS111_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_CONS111_PB.Click += new System.EventHandler(this.ID_CEE_CONS111_PB_Click);
            // 
            // ID_CEE_GRU_COB
            // 
            this.ID_CEE_GRU_COB.BackColor = System.Drawing.Color.White;
            this.ID_CEE_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_GRU_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_CEE_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEE_GRU_COB.Location = new System.Drawing.Point(90, 22);
            this.ID_CEE_GRU_COB.Name = "ID_CEE_GRU_COB";
            this.ID_CEE_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_GRU_COB.Size = new System.Drawing.Size(208, 21);
            this.ID_CEE_GRU_COB.Sorted = true;
            this.ID_CEE_GRU_COB.TabIndex = 7;
            this.ID_CEE_GRU_COB.Tag = "";
            this.ID_CEE_GRU_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEE_GRU_COB_SelectedIndexChanged);
            // 
            // ID_CEE_EMP_COB
            // 
            this.ID_CEE_EMP_COB.BackColor = System.Drawing.Color.White;
            this.ID_CEE_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_CEE_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEE_EMP_COB.Location = new System.Drawing.Point(90, 46);
            this.ID_CEE_EMP_COB.Name = "ID_CEE_EMP_COB";
            this.ID_CEE_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_EMP_COB.Size = new System.Drawing.Size(208, 21);
            this.ID_CEE_EMP_COB.Sorted = true;
            this.ID_CEE_EMP_COB.TabIndex = 8;
            this.ID_CEE_EMP_COB.Tag = "";
            this.ID_CEE_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEE_EMP_COB_SelectedIndexChanged);
            // 
            // CORCTEJE
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(434, 395);
            this.Controls.Add(this.ID_CEE_PPL_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(303, 116);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORCTEJE";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Tarjetahabientes Empresa";
            this.Activated += new System.EventHandler(this.CORCTEJE_Activated);
            this.Closed += new System.EventHandler(this.CORCTEJE_Closed);
            this.ID_CEE_PPL_PNL.ResumeLayout(false);
            this.ID_CEE_PPL_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEE_IRE_CKB)).EndInit();
            this.ResumeLayout(false);

        }
        void InitializeID_CEE_ETI_PNL()
        {
            this.ID_CEE_ETI_PNL[1] = _ID_CEE_ETI_PNL_1;
            this.ID_CEE_ETI_PNL[0] = _ID_CEE_ETI_PNL_0;
            this.ID_CEE_ETI_PNL[7] = _ID_CEE_ETI_PNL_7;
            this.ID_CEE_ETI_PNL[2] = _ID_CEE_ETI_PNL_2;
        }
        #endregion

        private System.Windows.Forms.TextBox ID_CEE_SIG_EJE;
        private System.Windows.Forms.Label ID_CEE_ETI_PNL3;
    }
}