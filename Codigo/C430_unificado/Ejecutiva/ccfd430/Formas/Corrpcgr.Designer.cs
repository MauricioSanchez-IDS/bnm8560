using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCd430
{
    partial class CORRPCGR
    {

        #region "Upgrade Support "
        private static CORRPCGR m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static CORRPCGR DefInstance
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
        public CORRPCGR()
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
            ID_CGR_REP_SS = new Softtek.Util.Win.Spread.SpreadWrapper(fpsID_CGR_REP_SS);
            InitializeHelp();
            InitializeID_CGR_ETI_TXT();
            InitializeID_CGR_RES_TXT();
            //This form is an MDI child.
            //This code simulates the VB6 
            // functionality of automatically
            // loading and showing an MDI
            // child's parent.
            this.MdiParent = TCd430.CORMDIBN.DefInstance;
            TCd430.CORMDIBN.DefInstance.Show();
        }
        public static CORRPCGR CreateInstance()
        {
            CORRPCGR theInstance = new CORRPCGR();
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
        public System.Windows.Forms.Button ID_CGR_IMP_PB;
        public System.Windows.Forms.Button ID_CGR_SAL_PB;
        public System.Windows.Forms.PictureBox ID_CGR_COR_PIC;
        public System.Windows.Forms.PictureBox ID_CGR_LOG_IMG;
        public System.Windows.Forms.Label ID_CGR_BAN_LBL;
        public AxThreed.AxSSPanel ID_CGR_TIT_PNL;
        public System.Windows.Forms.Label ID_CGR_FEC_CRED_LBL;
        public System.Windows.Forms.Label ID_CGR_FEC_LBL;
        public System.Windows.Forms.Label ID_CGR_CRE_ACU_LBL;
        public System.Windows.Forms.Label ID_CGR_ACUM_LBL;
        public System.Windows.Forms.Label ID_CGR_CRE_TOT_LBL;
        public System.Windows.Forms.Label ID_CGR_CRED_LBL;
        public System.Windows.Forms.Label ID_CGR_EMP_LBL;
        public System.Windows.Forms.Label ID_CGR_DI1_LBL;
        public System.Windows.Forms.Label ID_CGR_DI2_LBL;
        public System.Windows.Forms.Label ID_CGR_DI3_LBL;
        public System.Windows.Forms.Label ID_CGR_CP_LBL;
        public AxThreed.AxSSPanel ID_CGR_IDE_PNL;
        private System.Windows.Forms.Label _ID_CGR_ETI_TXT_7;
        private System.Windows.Forms.Label _ID_CGR_ETI_TXT_6;
        private System.Windows.Forms.Label _ID_CGR_ETI_TXT_5;
        private System.Windows.Forms.Label _ID_CGR_ETI_TXT_4;
        private System.Windows.Forms.Label _ID_CGR_ETI_TXT_3;
        private System.Windows.Forms.Label _ID_CGR_ETI_TXT_2;
        private System.Windows.Forms.Label _ID_CGR_ETI_TXT_1;
        private System.Windows.Forms.Label _ID_CGR_ETI_TXT_0;
        private System.Windows.Forms.Label _ID_CGR_RES_TXT_0;
        private System.Windows.Forms.Label _ID_CGR_RES_TXT_1;
        private System.Windows.Forms.Label _ID_CGR_RES_TXT_2;
        private System.Windows.Forms.Label _ID_CGR_RES_TXT_3;
        private System.Windows.Forms.Label _ID_CGR_RES_TXT_4;
        private System.Windows.Forms.Label _ID_CGR_RES_TXT_5;
        private System.Windows.Forms.Label _ID_CGR_RES_TXT_6;
        private System.Windows.Forms.Label _ID_CGR_RES_TXT_7;
        public AxThreed.AxSSPanel ID_CGR_SAL_PNL;
        public System.Windows.Forms.Label[] ID_CGR_ETI_TXT = new System.Windows.Forms.Label[8];
        public System.Windows.Forms.Label[] ID_CGR_RES_TXT = new System.Windows.Forms.Label[8];
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPCGR));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color50635410218420574441", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text323635410218420584441", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_CGR_IMP_PB = new System.Windows.Forms.Button();
            this.ID_CGR_SAL_PB = new System.Windows.Forms.Button();
            this.ID_CGR_TIT_PNL = new AxThreed.AxSSPanel();
            this.ID_CGR_COR_PIC = new System.Windows.Forms.PictureBox();
            this.ID_CGR_LOG_IMG = new System.Windows.Forms.PictureBox();
            this.ID_CGR_BAN_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_IDE_PNL = new AxThreed.AxSSPanel();
            this.ID_CGR_CRED_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_EMP_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_ACUM_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_CRE_TOT_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_DI3_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_CP_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_DI1_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_DI2_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_CRE_ACU_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_FEC_CRED_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_FEC_LBL = new System.Windows.Forms.Label();
            this.ID_CGR_SAL_PNL = new AxThreed.AxSSPanel();
            this._ID_CGR_RES_TXT_0 = new System.Windows.Forms.Label();
            this._ID_CGR_RES_TXT_1 = new System.Windows.Forms.Label();
            this._ID_CGR_ETI_TXT_0 = new System.Windows.Forms.Label();
            this._ID_CGR_ETI_TXT_2 = new System.Windows.Forms.Label();
            this._ID_CGR_ETI_TXT_1 = new System.Windows.Forms.Label();
            this._ID_CGR_RES_TXT_2 = new System.Windows.Forms.Label();
            this._ID_CGR_RES_TXT_6 = new System.Windows.Forms.Label();
            this._ID_CGR_RES_TXT_7 = new System.Windows.Forms.Label();
            this._ID_CGR_RES_TXT_5 = new System.Windows.Forms.Label();
            this._ID_CGR_RES_TXT_3 = new System.Windows.Forms.Label();
            this._ID_CGR_RES_TXT_4 = new System.Windows.Forms.Label();
            this._ID_CGR_ETI_TXT_6 = new System.Windows.Forms.Label();
            this._ID_CGR_ETI_TXT_7 = new System.Windows.Forms.Label();
            this._ID_CGR_ETI_TXT_5 = new System.Windows.Forms.Label();
            this._ID_CGR_ETI_TXT_3 = new System.Windows.Forms.Label();
            this._ID_CGR_ETI_TXT_4 = new System.Windows.Forms.Label();
            this.fpsID_CGR_REP_SS = new FarPoint.Win.Spread.FpSpread();
            this.fpsID_CGR_REP_SS_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_TIT_PNL)).BeginInit();
            this.ID_CGR_TIT_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_COR_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_LOG_IMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_IDE_PNL)).BeginInit();
            this.ID_CGR_IDE_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_SAL_PNL)).BeginInit();
            this.ID_CGR_SAL_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CGR_REP_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CGR_REP_SS_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_CGR_IMP_PB
            // 
            this.ID_CGR_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CGR_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_IMP_PB.Location = new System.Drawing.Point(206, 346);
            this.ID_CGR_IMP_PB.Name = "ID_CGR_IMP_PB";
            this.ID_CGR_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_IMP_PB.Size = new System.Drawing.Size(83, 25);
            this.ID_CGR_IMP_PB.TabIndex = 34;
            this.ID_CGR_IMP_PB.Tag = "";
            this.ID_CGR_IMP_PB.Text = "&Imprimir";
            this.ID_CGR_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_CGR_IMP_PB.Visible = false;
            this.ID_CGR_IMP_PB.Click += new System.EventHandler(this.ID_CGR_IMP_PB_Click);
            // 
            // ID_CGR_SAL_PB
            // 
            this.ID_CGR_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CGR_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_CGR_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_SAL_PB.Location = new System.Drawing.Point(261, 346);
            this.ID_CGR_SAL_PB.Name = "ID_CGR_SAL_PB";
            this.ID_CGR_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_SAL_PB.Size = new System.Drawing.Size(82, 25);
            this.ID_CGR_SAL_PB.TabIndex = 2;
            this.ID_CGR_SAL_PB.Tag = "";
            this.ID_CGR_SAL_PB.Text = "&Salir";
            this.ID_CGR_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_CGR_SAL_PB.Click += new System.EventHandler(this.ID_CGR_SAL_PB_Click);
            // 
            // ID_CGR_TIT_PNL
            // 
            this.ID_CGR_TIT_PNL.Controls.Add(this.ID_CGR_COR_PIC);
            this.ID_CGR_TIT_PNL.Controls.Add(this.ID_CGR_LOG_IMG);
            this.ID_CGR_TIT_PNL.Controls.Add(this.ID_CGR_BAN_LBL);
            this.ID_CGR_TIT_PNL.Location = new System.Drawing.Point(6, 8);
            this.ID_CGR_TIT_PNL.Name = "ID_CGR_TIT_PNL";
            this.ID_CGR_TIT_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CGR_TIT_PNL.OcxState")));
            this.ID_CGR_TIT_PNL.Size = new System.Drawing.Size(585, 55);
            this.ID_CGR_TIT_PNL.TabIndex = 0;
            this.ID_CGR_TIT_PNL.Tag = "";
            // 
            // ID_CGR_COR_PIC
            // 
            this.ID_CGR_COR_PIC.BackColor = System.Drawing.Color.Gray;
            this.ID_CGR_COR_PIC.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_COR_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_COR_PIC.Image = ((System.Drawing.Image)(resources.GetObject("ID_CGR_COR_PIC.Image")));
            this.ID_CGR_COR_PIC.Location = new System.Drawing.Point(436, 12);
            this.ID_CGR_COR_PIC.Name = "ID_CGR_COR_PIC";
            this.ID_CGR_COR_PIC.Size = new System.Drawing.Size(131, 31);
            this.ID_CGR_COR_PIC.TabIndex = 3;
            this.ID_CGR_COR_PIC.TabStop = false;
            this.ID_CGR_COR_PIC.Tag = "";
            this.ID_CGR_COR_PIC.Visible = false;
            // 
            // ID_CGR_LOG_IMG
            // 
            this.ID_CGR_LOG_IMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_LOG_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_CGR_LOG_IMG.Image")));
            this.ID_CGR_LOG_IMG.Location = new System.Drawing.Point(16, 8);
            this.ID_CGR_LOG_IMG.Name = "ID_CGR_LOG_IMG";
            this.ID_CGR_LOG_IMG.Size = new System.Drawing.Size(45, 45);
            this.ID_CGR_LOG_IMG.TabIndex = 4;
            this.ID_CGR_LOG_IMG.TabStop = false;
            this.ID_CGR_LOG_IMG.Tag = "";
            // 
            // ID_CGR_BAN_LBL
            // 
            this.ID_CGR_BAN_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_BAN_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_BAN_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_BAN_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_BAN_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CGR_BAN_LBL.Location = new System.Drawing.Point(67, 16);
            this.ID_CGR_BAN_LBL.Name = "ID_CGR_BAN_LBL";
            this.ID_CGR_BAN_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_BAN_LBL.Size = new System.Drawing.Size(118, 24);
            this.ID_CGR_BAN_LBL.TabIndex = 4;
            this.ID_CGR_BAN_LBL.Tag = "";
            this.ID_CGR_BAN_LBL.Text = "Banamex";
            // 
            // ID_CGR_IDE_PNL
            // 
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_CRED_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_EMP_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_ACUM_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_CRE_TOT_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_DI3_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_CP_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_DI1_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_DI2_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_CRE_ACU_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_FEC_CRED_LBL);
            this.ID_CGR_IDE_PNL.Controls.Add(this.ID_CGR_FEC_LBL);
            this.ID_CGR_IDE_PNL.Location = new System.Drawing.Point(6, 63);
            this.ID_CGR_IDE_PNL.Name = "ID_CGR_IDE_PNL";
            this.ID_CGR_IDE_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CGR_IDE_PNL.OcxState")));
            this.ID_CGR_IDE_PNL.Size = new System.Drawing.Size(297, 157);
            this.ID_CGR_IDE_PNL.TabIndex = 1;
            this.ID_CGR_IDE_PNL.Tag = "";
            // 
            // ID_CGR_CRED_LBL
            // 
            this.ID_CGR_CRED_LBL.AutoSize = true;
            this.ID_CGR_CRED_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_CRED_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_CRED_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_CRED_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_CRED_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_CRED_LBL.Location = new System.Drawing.Point(9, 102);
            this.ID_CGR_CRED_LBL.Name = "ID_CGR_CRED_LBL";
            this.ID_CGR_CRED_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_CRED_LBL.Size = new System.Drawing.Size(84, 13);
            this.ID_CGR_CRED_LBL.TabIndex = 28;
            this.ID_CGR_CRED_LBL.Tag = "";
            this.ID_CGR_CRED_LBL.Text = "Credito Total ";
            this.ID_CGR_CRED_LBL.Visible = false;
            // 
            // ID_CGR_EMP_LBL
            // 
            this.ID_CGR_EMP_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_EMP_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_EMP_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_EMP_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_EMP_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_EMP_LBL.Location = new System.Drawing.Point(11, 16);
            this.ID_CGR_EMP_LBL.Name = "ID_CGR_EMP_LBL";
            this.ID_CGR_EMP_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_EMP_LBL.Size = new System.Drawing.Size(273, 13);
            this.ID_CGR_EMP_LBL.TabIndex = 10;
            this.ID_CGR_EMP_LBL.Tag = "";
            // 
            // ID_CGR_ACUM_LBL
            // 
            this.ID_CGR_ACUM_LBL.AutoSize = true;
            this.ID_CGR_ACUM_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_ACUM_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_ACUM_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_ACUM_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_ACUM_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_ACUM_LBL.Location = new System.Drawing.Point(10, 120);
            this.ID_CGR_ACUM_LBL.Name = "ID_CGR_ACUM_LBL";
            this.ID_CGR_ACUM_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_ACUM_LBL.Size = new System.Drawing.Size(86, 13);
            this.ID_CGR_ACUM_LBL.TabIndex = 30;
            this.ID_CGR_ACUM_LBL.Tag = "";
            this.ID_CGR_ACUM_LBL.Text = "Límite de Uso";
            // 
            // ID_CGR_CRE_TOT_LBL
            // 
            this.ID_CGR_CRE_TOT_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_CRE_TOT_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_CRE_TOT_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_CRE_TOT_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_CRE_TOT_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_CRE_TOT_LBL.Location = new System.Drawing.Point(132, 103);
            this.ID_CGR_CRE_TOT_LBL.Name = "ID_CGR_CRE_TOT_LBL";
            this.ID_CGR_CRE_TOT_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_CRE_TOT_LBL.Size = new System.Drawing.Size(153, 16);
            this.ID_CGR_CRE_TOT_LBL.TabIndex = 29;
            this.ID_CGR_CRE_TOT_LBL.Tag = "";
            this.ID_CGR_CRE_TOT_LBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ID_CGR_CRE_TOT_LBL.Visible = false;
            // 
            // ID_CGR_DI3_LBL
            // 
            this.ID_CGR_DI3_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_DI3_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_DI3_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_DI3_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_DI3_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_DI3_LBL.Location = new System.Drawing.Point(12, 66);
            this.ID_CGR_DI3_LBL.Name = "ID_CGR_DI3_LBL";
            this.ID_CGR_DI3_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_DI3_LBL.Size = new System.Drawing.Size(273, 13);
            this.ID_CGR_DI3_LBL.TabIndex = 6;
            this.ID_CGR_DI3_LBL.Tag = "";
            // 
            // ID_CGR_CP_LBL
            // 
            this.ID_CGR_CP_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_CP_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_CP_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_CP_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_CP_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_CP_LBL.Location = new System.Drawing.Point(12, 82);
            this.ID_CGR_CP_LBL.Name = "ID_CGR_CP_LBL";
            this.ID_CGR_CP_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_CP_LBL.Size = new System.Drawing.Size(273, 13);
            this.ID_CGR_CP_LBL.TabIndex = 5;
            this.ID_CGR_CP_LBL.Tag = "";
            // 
            // ID_CGR_DI1_LBL
            // 
            this.ID_CGR_DI1_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_DI1_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_DI1_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_DI1_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_DI1_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_DI1_LBL.Location = new System.Drawing.Point(12, 32);
            this.ID_CGR_DI1_LBL.Name = "ID_CGR_DI1_LBL";
            this.ID_CGR_DI1_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_DI1_LBL.Size = new System.Drawing.Size(273, 13);
            this.ID_CGR_DI1_LBL.TabIndex = 8;
            this.ID_CGR_DI1_LBL.Tag = "";
            // 
            // ID_CGR_DI2_LBL
            // 
            this.ID_CGR_DI2_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_DI2_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_DI2_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_DI2_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_DI2_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_DI2_LBL.Location = new System.Drawing.Point(12, 49);
            this.ID_CGR_DI2_LBL.Name = "ID_CGR_DI2_LBL";
            this.ID_CGR_DI2_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_DI2_LBL.Size = new System.Drawing.Size(273, 13);
            this.ID_CGR_DI2_LBL.TabIndex = 7;
            this.ID_CGR_DI2_LBL.Tag = "";
            // 
            // ID_CGR_CRE_ACU_LBL
            // 
            this.ID_CGR_CRE_ACU_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_CRE_ACU_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_CRE_ACU_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_CRE_ACU_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_CRE_ACU_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_CRE_ACU_LBL.Location = new System.Drawing.Point(132, 119);
            this.ID_CGR_CRE_ACU_LBL.Name = "ID_CGR_CRE_ACU_LBL";
            this.ID_CGR_CRE_ACU_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_CRE_ACU_LBL.Size = new System.Drawing.Size(153, 14);
            this.ID_CGR_CRE_ACU_LBL.TabIndex = 31;
            this.ID_CGR_CRE_ACU_LBL.Tag = "";
            this.ID_CGR_CRE_ACU_LBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ID_CGR_FEC_CRED_LBL
            // 
            this.ID_CGR_FEC_CRED_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_FEC_CRED_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_FEC_CRED_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_FEC_CRED_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_FEC_CRED_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_FEC_CRED_LBL.Location = new System.Drawing.Point(145, 138);
            this.ID_CGR_FEC_CRED_LBL.Name = "ID_CGR_FEC_CRED_LBL";
            this.ID_CGR_FEC_CRED_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_FEC_CRED_LBL.Size = new System.Drawing.Size(139, 14);
            this.ID_CGR_FEC_CRED_LBL.TabIndex = 33;
            this.ID_CGR_FEC_CRED_LBL.Tag = "";
            this.ID_CGR_FEC_CRED_LBL.Visible = false;
            // 
            // ID_CGR_FEC_LBL
            // 
            this.ID_CGR_FEC_LBL.AutoSize = true;
            this.ID_CGR_FEC_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CGR_FEC_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CGR_FEC_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CGR_FEC_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CGR_FEC_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CGR_FEC_LBL.Location = new System.Drawing.Point(9, 136);
            this.ID_CGR_FEC_LBL.Name = "ID_CGR_FEC_LBL";
            this.ID_CGR_FEC_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CGR_FEC_LBL.Size = new System.Drawing.Size(133, 13);
            this.ID_CGR_FEC_LBL.TabIndex = 32;
            this.ID_CGR_FEC_LBL.Tag = "";
            this.ID_CGR_FEC_LBL.Text = "Fecha de Vencimiento";
            this.ID_CGR_FEC_LBL.Visible = false;
            // 
            // ID_CGR_SAL_PNL
            // 
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_RES_TXT_0);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_RES_TXT_1);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_ETI_TXT_0);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_ETI_TXT_2);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_ETI_TXT_1);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_RES_TXT_2);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_RES_TXT_6);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_RES_TXT_7);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_RES_TXT_5);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_RES_TXT_3);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_RES_TXT_4);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_ETI_TXT_6);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_ETI_TXT_7);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_ETI_TXT_5);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_ETI_TXT_3);
            this.ID_CGR_SAL_PNL.Controls.Add(this._ID_CGR_ETI_TXT_4);
            this.ID_CGR_SAL_PNL.Location = new System.Drawing.Point(303, 63);
            this.ID_CGR_SAL_PNL.Name = "ID_CGR_SAL_PNL";
            this.ID_CGR_SAL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CGR_SAL_PNL.OcxState")));
            this.ID_CGR_SAL_PNL.Size = new System.Drawing.Size(288, 157);
            this.ID_CGR_SAL_PNL.TabIndex = 9;
            this.ID_CGR_SAL_PNL.Tag = "";
            // 
            // _ID_CGR_RES_TXT_0
            // 
            this._ID_CGR_RES_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_RES_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_RES_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_RES_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_RES_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_RES_TXT_0.Location = new System.Drawing.Point(137, 8);
            this._ID_CGR_RES_TXT_0.Name = "_ID_CGR_RES_TXT_0";
            this._ID_CGR_RES_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_RES_TXT_0.Size = new System.Drawing.Size(120, 16);
            this._ID_CGR_RES_TXT_0.TabIndex = 18;
            this._ID_CGR_RES_TXT_0.Tag = "";
            this._ID_CGR_RES_TXT_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CGR_RES_TXT_1
            // 
            this._ID_CGR_RES_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_RES_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_RES_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_RES_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_RES_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_RES_TXT_1.Location = new System.Drawing.Point(137, 22);
            this._ID_CGR_RES_TXT_1.Name = "_ID_CGR_RES_TXT_1";
            this._ID_CGR_RES_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_RES_TXT_1.Size = new System.Drawing.Size(120, 16);
            this._ID_CGR_RES_TXT_1.TabIndex = 17;
            this._ID_CGR_RES_TXT_1.Tag = "";
            this._ID_CGR_RES_TXT_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CGR_ETI_TXT_0
            // 
            this._ID_CGR_ETI_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_ETI_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_ETI_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_ETI_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_ETI_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_ETI_TXT_0.Location = new System.Drawing.Point(15, 7);
            this._ID_CGR_ETI_TXT_0.Name = "_ID_CGR_ETI_TXT_0";
            this._ID_CGR_ETI_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_ETI_TXT_0.Size = new System.Drawing.Size(119, 16);
            this._ID_CGR_ETI_TXT_0.TabIndex = 19;
            this._ID_CGR_ETI_TXT_0.Tag = "";
            this._ID_CGR_ETI_TXT_0.Text = "Saldo Anterior";
            // 
            // _ID_CGR_ETI_TXT_2
            // 
            this._ID_CGR_ETI_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_ETI_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_ETI_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_ETI_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_ETI_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_ETI_TXT_2.Location = new System.Drawing.Point(15, 36);
            this._ID_CGR_ETI_TXT_2.Name = "_ID_CGR_ETI_TXT_2";
            this._ID_CGR_ETI_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_ETI_TXT_2.Size = new System.Drawing.Size(119, 16);
            this._ID_CGR_ETI_TXT_2.TabIndex = 21;
            this._ID_CGR_ETI_TXT_2.Tag = "";
            this._ID_CGR_ETI_TXT_2.Text = "   - Disp. en Efectivo";
            // 
            // _ID_CGR_ETI_TXT_1
            // 
            this._ID_CGR_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_ETI_TXT_1.Location = new System.Drawing.Point(15, 22);
            this._ID_CGR_ETI_TXT_1.Name = "_ID_CGR_ETI_TXT_1";
            this._ID_CGR_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_ETI_TXT_1.Size = new System.Drawing.Size(119, 16);
            this._ID_CGR_ETI_TXT_1.TabIndex = 20;
            this._ID_CGR_ETI_TXT_1.Tag = "";
            this._ID_CGR_ETI_TXT_1.Text = "   - Consumos";
            // 
            // _ID_CGR_RES_TXT_2
            // 
            this._ID_CGR_RES_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_RES_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_RES_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_RES_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_RES_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_RES_TXT_2.Location = new System.Drawing.Point(137, 36);
            this._ID_CGR_RES_TXT_2.Name = "_ID_CGR_RES_TXT_2";
            this._ID_CGR_RES_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_RES_TXT_2.Size = new System.Drawing.Size(120, 16);
            this._ID_CGR_RES_TXT_2.TabIndex = 16;
            this._ID_CGR_RES_TXT_2.Tag = "";
            this._ID_CGR_RES_TXT_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CGR_RES_TXT_6
            // 
            this._ID_CGR_RES_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_RES_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_RES_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_RES_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_RES_TXT_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_RES_TXT_6.Location = new System.Drawing.Point(137, 92);
            this._ID_CGR_RES_TXT_6.Name = "_ID_CGR_RES_TXT_6";
            this._ID_CGR_RES_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_RES_TXT_6.Size = new System.Drawing.Size(120, 16);
            this._ID_CGR_RES_TXT_6.TabIndex = 12;
            this._ID_CGR_RES_TXT_6.Tag = "";
            this._ID_CGR_RES_TXT_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CGR_RES_TXT_7
            // 
            this._ID_CGR_RES_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_RES_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_RES_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_RES_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_RES_TXT_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_RES_TXT_7.Location = new System.Drawing.Point(137, 106);
            this._ID_CGR_RES_TXT_7.Name = "_ID_CGR_RES_TXT_7";
            this._ID_CGR_RES_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_RES_TXT_7.Size = new System.Drawing.Size(120, 16);
            this._ID_CGR_RES_TXT_7.TabIndex = 11;
            this._ID_CGR_RES_TXT_7.Tag = "";
            this._ID_CGR_RES_TXT_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CGR_RES_TXT_5
            // 
            this._ID_CGR_RES_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_RES_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_RES_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_RES_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_RES_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_RES_TXT_5.Location = new System.Drawing.Point(137, 78);
            this._ID_CGR_RES_TXT_5.Name = "_ID_CGR_RES_TXT_5";
            this._ID_CGR_RES_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_RES_TXT_5.Size = new System.Drawing.Size(120, 16);
            this._ID_CGR_RES_TXT_5.TabIndex = 13;
            this._ID_CGR_RES_TXT_5.Tag = "";
            this._ID_CGR_RES_TXT_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CGR_RES_TXT_3
            // 
            this._ID_CGR_RES_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_RES_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_RES_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_RES_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_RES_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_RES_TXT_3.Location = new System.Drawing.Point(137, 50);
            this._ID_CGR_RES_TXT_3.Name = "_ID_CGR_RES_TXT_3";
            this._ID_CGR_RES_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_RES_TXT_3.Size = new System.Drawing.Size(120, 16);
            this._ID_CGR_RES_TXT_3.TabIndex = 15;
            this._ID_CGR_RES_TXT_3.Tag = "";
            this._ID_CGR_RES_TXT_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CGR_RES_TXT_4
            // 
            this._ID_CGR_RES_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_RES_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_RES_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_RES_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_RES_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_RES_TXT_4.Location = new System.Drawing.Point(137, 64);
            this._ID_CGR_RES_TXT_4.Name = "_ID_CGR_RES_TXT_4";
            this._ID_CGR_RES_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_RES_TXT_4.Size = new System.Drawing.Size(120, 16);
            this._ID_CGR_RES_TXT_4.TabIndex = 14;
            this._ID_CGR_RES_TXT_4.Tag = "";
            this._ID_CGR_RES_TXT_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CGR_ETI_TXT_6
            // 
            this._ID_CGR_ETI_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_ETI_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_ETI_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_ETI_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_ETI_TXT_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_ETI_TXT_6.Location = new System.Drawing.Point(15, 92);
            this._ID_CGR_ETI_TXT_6.Name = "_ID_CGR_ETI_TXT_6";
            this._ID_CGR_ETI_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_ETI_TXT_6.Size = new System.Drawing.Size(119, 16);
            this._ID_CGR_ETI_TXT_6.TabIndex = 25;
            this._ID_CGR_ETI_TXT_6.Tag = "";
            this._ID_CGR_ETI_TXT_6.Text = "   - I.V.A.";
            // 
            // _ID_CGR_ETI_TXT_7
            // 
            this._ID_CGR_ETI_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_ETI_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_ETI_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_ETI_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_ETI_TXT_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_ETI_TXT_7.Location = new System.Drawing.Point(14, 106);
            this._ID_CGR_ETI_TXT_7.Name = "_ID_CGR_ETI_TXT_7";
            this._ID_CGR_ETI_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_ETI_TXT_7.Size = new System.Drawing.Size(119, 16);
            this._ID_CGR_ETI_TXT_7.TabIndex = 27;
            this._ID_CGR_ETI_TXT_7.Tag = "";
            this._ID_CGR_ETI_TXT_7.Text = "= Saldo Nuevo";
            // 
            // _ID_CGR_ETI_TXT_5
            // 
            this._ID_CGR_ETI_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_ETI_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_ETI_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_ETI_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_ETI_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_ETI_TXT_5.Location = new System.Drawing.Point(15, 78);
            this._ID_CGR_ETI_TXT_5.Name = "_ID_CGR_ETI_TXT_5";
            this._ID_CGR_ETI_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_ETI_TXT_5.Size = new System.Drawing.Size(119, 16);
            this._ID_CGR_ETI_TXT_5.TabIndex = 24;
            this._ID_CGR_ETI_TXT_5.Tag = "";
            this._ID_CGR_ETI_TXT_5.Text = "   - Gastos Cobranza ";
            // 
            // _ID_CGR_ETI_TXT_3
            // 
            this._ID_CGR_ETI_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_ETI_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_ETI_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_ETI_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_ETI_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_ETI_TXT_3.Location = new System.Drawing.Point(15, 50);
            this._ID_CGR_ETI_TXT_3.Name = "_ID_CGR_ETI_TXT_3";
            this._ID_CGR_ETI_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_ETI_TXT_3.Size = new System.Drawing.Size(119, 16);
            this._ID_CGR_ETI_TXT_3.TabIndex = 22;
            this._ID_CGR_ETI_TXT_3.Tag = "";
            this._ID_CGR_ETI_TXT_3.Text = "   + Pagos";
            // 
            // _ID_CGR_ETI_TXT_4
            // 
            this._ID_CGR_ETI_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_CGR_ETI_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CGR_ETI_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CGR_ETI_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CGR_ETI_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CGR_ETI_TXT_4.Location = new System.Drawing.Point(15, 64);
            this._ID_CGR_ETI_TXT_4.Name = "_ID_CGR_ETI_TXT_4";
            this._ID_CGR_ETI_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CGR_ETI_TXT_4.Size = new System.Drawing.Size(119, 16);
            this._ID_CGR_ETI_TXT_4.TabIndex = 23;
            this._ID_CGR_ETI_TXT_4.Tag = "";
            this._ID_CGR_ETI_TXT_4.Text = "   - Comisiones";
            // 
            // fpsID_CGR_REP_SS
            // 
            this.fpsID_CGR_REP_SS.AccessibleDescription = "";
            this.fpsID_CGR_REP_SS.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsID_CGR_REP_SS.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsID_CGR_REP_SS.HorizontalScrollBar.Name = "";
            this.fpsID_CGR_REP_SS.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsID_CGR_REP_SS.HorizontalScrollBar.TabIndex = 6;
            this.fpsID_CGR_REP_SS.Location = new System.Drawing.Point(6, 227);
            this.fpsID_CGR_REP_SS.Name = "fpsID_CGR_REP_SS";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpsID_CGR_REP_SS.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpsID_CGR_REP_SS.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsID_CGR_REP_SS_Sheet1});
            this.fpsID_CGR_REP_SS.Size = new System.Drawing.Size(585, 113);
            this.fpsID_CGR_REP_SS.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsID_CGR_REP_SS.TabIndex = 35;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsID_CGR_REP_SS.TextTipAppearance = tipAppearance1;
            this.fpsID_CGR_REP_SS.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsID_CGR_REP_SS.VerticalScrollBar.Name = "";
            this.fpsID_CGR_REP_SS.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsID_CGR_REP_SS.VerticalScrollBar.TabIndex = 7;
            this.fpsID_CGR_REP_SS.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpsID_CGR_REP_SS.SetViewportLeftColumn(0, 0, 2);
            this.fpsID_CGR_REP_SS.SetActiveViewport(0, 0, -1);
            // 
            // fpsID_CGR_REP_SS_Sheet1
            // 
            this.fpsID_CGR_REP_SS_Sheet1.Reset();
            this.fpsID_CGR_REP_SS_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsID_CGR_REP_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsID_CGR_REP_SS_Sheet1.ColumnCount = 11;
            this.fpsID_CGR_REP_SS_Sheet1.RowCount = 5;
            this.fpsID_CGR_REP_SS_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CGR_REP_SS_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CGR_REP_SS_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsID_CGR_REP_SS_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CGR_REP_SS_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsID_CGR_REP_SS_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CGR_REP_SS_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CGR_REP_SS_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CGR_REP_SS_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CGR_REP_SS_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsID_CGR_REP_SS_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CGR_REP_SS_Sheet1.DefaultStyleName = "Text323635410218420584441";
            this.fpsID_CGR_REP_SS_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CGR_REP_SS_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsID_CGR_REP_SS_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CGR_REP_SS_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsID_CGR_REP_SS_Sheet1.FrozenColumnCount = 2;
            this.fpsID_CGR_REP_SS_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpsID_CGR_REP_SS_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsID_CGR_REP_SS_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CGR_REP_SS_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CGR_REP_SS_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CGR_REP_SS_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsID_CGR_REP_SS_Sheet1.RowHeader.Visible = false;
            this.fpsID_CGR_REP_SS_Sheet1.Rows.Get(0).Height = 16F;
            this.fpsID_CGR_REP_SS_Sheet1.Rows.Get(1).Height = 17F;
            this.fpsID_CGR_REP_SS_Sheet1.Rows.Get(2).Height = 16F;
            this.fpsID_CGR_REP_SS_Sheet1.Rows.Get(3).Height = 16F;
            this.fpsID_CGR_REP_SS_Sheet1.Rows.Get(4).Height = 16F;
            this.fpsID_CGR_REP_SS_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CGR_REP_SS_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CGR_REP_SS_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CGR_REP_SS_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsID_CGR_REP_SS_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpsID_CGR_REP_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // CORRPCGR
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.ID_CGR_SAL_PB;
            this.ClientSize = new System.Drawing.Size(597, 376);
            this.Controls.Add(this.fpsID_CGR_REP_SS);
            this.Controls.Add(this.ID_CGR_SAL_PB);
            this.Controls.Add(this.ID_CGR_IMP_PB);
            this.Controls.Add(this.ID_CGR_IDE_PNL);
            this.Controls.Add(this.ID_CGR_SAL_PNL);
            this.Controls.Add(this.ID_CGR_TIT_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(99, 131);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORRPCGR";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Concentrado Grupo/Empresa";
            this.Activated += new System.EventHandler(this.CORRPCGR_Activated);
            this.Closed += new System.EventHandler(this.CORRPCGR_Closed);
            this.Deactivate += new System.EventHandler(this.CORRPCGR_Deactivate);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORRPCGR_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_TIT_PNL)).EndInit();
            this.ID_CGR_TIT_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_COR_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_LOG_IMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_IDE_PNL)).EndInit();
            this.ID_CGR_IDE_PNL.ResumeLayout(false);
            this.ID_CGR_IDE_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_SAL_PNL)).EndInit();
            this.ID_CGR_SAL_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CGR_REP_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CGR_REP_SS_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        void InitializeID_CGR_ETI_TXT()
        {
            this.ID_CGR_ETI_TXT[7] = _ID_CGR_ETI_TXT_7;
            this.ID_CGR_ETI_TXT[6] = _ID_CGR_ETI_TXT_6;
            this.ID_CGR_ETI_TXT[5] = _ID_CGR_ETI_TXT_5;
            this.ID_CGR_ETI_TXT[4] = _ID_CGR_ETI_TXT_4;
            this.ID_CGR_ETI_TXT[3] = _ID_CGR_ETI_TXT_3;
            this.ID_CGR_ETI_TXT[2] = _ID_CGR_ETI_TXT_2;
            this.ID_CGR_ETI_TXT[1] = _ID_CGR_ETI_TXT_1;
            this.ID_CGR_ETI_TXT[0] = _ID_CGR_ETI_TXT_0;
        }
        void InitializeID_CGR_RES_TXT()
        {
            this.ID_CGR_RES_TXT[0] = _ID_CGR_RES_TXT_0;
            this.ID_CGR_RES_TXT[1] = _ID_CGR_RES_TXT_1;
            this.ID_CGR_RES_TXT[2] = _ID_CGR_RES_TXT_2;
            this.ID_CGR_RES_TXT[3] = _ID_CGR_RES_TXT_3;
            this.ID_CGR_RES_TXT[4] = _ID_CGR_RES_TXT_4;
            this.ID_CGR_RES_TXT[5] = _ID_CGR_RES_TXT_5;
            this.ID_CGR_RES_TXT[6] = _ID_CGR_RES_TXT_6;
            this.ID_CGR_RES_TXT[7] = _ID_CGR_RES_TXT_7;
        }
        #endregion

        private FarPoint.Win.Spread.FpSpread fpsID_CGR_REP_SS;
        private FarPoint.Win.Spread.SheetView fpsID_CGR_REP_SS_Sheet1;
        public Softtek.Util.Win.Spread.SpreadWrapper ID_CGR_REP_SS;
    }
}