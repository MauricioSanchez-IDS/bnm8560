using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    partial class CORRPANG
    {

        #region "Upgrade Support "
        private static CORRPANG m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        //AIS-Bug 4785 FSQSABORIO
        public static bool DefInstanceCreated
        {
            get
            {
                return ((m_vb6FormDefInstance != null) && (!m_vb6FormDefInstance.IsDisposed));
            }
        }

        public static CORRPANG DefInstance
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
        public CORRPANG()
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
            ID_GIR_CON_SS = new Softtek.Util.Win.Spread.SpreadWrapper(fpID_GIR_CON_SS);
            InitializeHelp();
            InitializeID_ACG_RES_TXT();
            InitializeID_ACG_CON_PNL();
            InitializeID_ACG_ETI_TXT();
            InitializeID_ACG_DEM_TXT();
            //This form is an MDI child.
            //This code simulates the VB6 
            // functionality of automatically
            // loading and showing an MDI
            // child's parent.
            this.MdiParent = TCc430.CORMDIBN.DefInstance;
            TCc430.CORMDIBN.DefInstance.Show();
        }
        public static CORRPANG CreateInstance()
        {
            CORRPANG theInstance = new CORRPANG();
            theInstance.Form_Load();
            //The MDI form in the VB6 project had its
            //AutoShowChildren property set to True
            //To simulate the VB6 behavior, we need to
            //automatically Show the form whenever it
            //is loaded.  If you do not want this behavior
            //then delete the following line of code
            //UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing.
            //AIS-Bug 4785 FSQSABORIO
            //theInstance.Show();
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
        public Softtek.Util.Win.Spread.SpreadWrapper ID_GIR_CON_SS;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.ToolTip ToolTip1;        
        public System.Windows.Forms.Button ID_GIR_IMP_PB;
        public System.Windows.Forms.Button ID_GIR_SAL_PB;
        public System.Windows.Forms.PictureBox ID_ACG_LOG2_IMG;
        public System.Windows.Forms.PictureBox ID_ACG_LOG1_IMG;
        public AxThreed.AxSSPanel ID_ACG_PPL_PNL;
        private System.Windows.Forms.Label _ID_ACG_DEM_TXT_5;
        private System.Windows.Forms.Label _ID_ACG_DEM_TXT_4;
        private System.Windows.Forms.Label _ID_ACG_DEM_TXT_3;
        private System.Windows.Forms.Label _ID_ACG_DEM_TXT_2;
        private System.Windows.Forms.Label _ID_ACG_DEM_TXT_1;
        private System.Windows.Forms.Label _ID_ACG_DEM_TXT_0;
        private AxThreed.AxSSPanel _ID_ACG_CON_PNL_0;
        private System.Windows.Forms.Label _ID_ACG_RES_TXT_7;
        private System.Windows.Forms.Label _ID_ACG_RES_TXT_6;
        private System.Windows.Forms.Label _ID_ACG_RES_TXT_5;
        private System.Windows.Forms.Label _ID_ACG_RES_TXT_4;
        private System.Windows.Forms.Label _ID_ACG_RES_TXT_3;
        private System.Windows.Forms.Label _ID_ACG_RES_TXT_2;
        private System.Windows.Forms.Label _ID_ACG_RES_TXT_1;
        private System.Windows.Forms.Label _ID_ACG_RES_TXT_0;
        private System.Windows.Forms.Label _ID_ACG_ETI_TXT_0;
        private System.Windows.Forms.Label _ID_ACG_ETI_TXT_1;
        private System.Windows.Forms.Label _ID_ACG_ETI_TXT_2;
        private System.Windows.Forms.Label _ID_ACG_ETI_TXT_3;
        private System.Windows.Forms.Label _ID_ACG_ETI_TXT_4;
        private System.Windows.Forms.Label _ID_ACG_ETI_TXT_5;
        private System.Windows.Forms.Label _ID_ACG_ETI_TXT_6;
        private System.Windows.Forms.Label _ID_ACG_ETI_TXT_7;
        private AxThreed.AxSSPanel _ID_ACG_CON_PNL_1;
        public AxThreed.AxSSPanel[] ID_ACG_CON_PNL = new AxThreed.AxSSPanel[2];
        public System.Windows.Forms.Label[] ID_ACG_DEM_TXT = new System.Windows.Forms.Label[6];
        public System.Windows.Forms.Label[] ID_ACG_ETI_TXT = new System.Windows.Forms.Label[8];
        public System.Windows.Forms.Label[] ID_ACG_RES_TXT = new System.Windows.Forms.Label[8];
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPANG));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color50635406953626245423", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text333635406953627015467", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);            
            this.ID_GIR_IMP_PB = new System.Windows.Forms.Button();
            this.ID_GIR_SAL_PB = new System.Windows.Forms.Button();
            this.ID_ACG_PPL_PNL = new AxThreed.AxSSPanel();
            this.ID_ACG_LOG2_IMG = new System.Windows.Forms.PictureBox();
            this.ID_ACG_LOG1_IMG = new System.Windows.Forms.PictureBox();
            this._ID_ACG_CON_PNL_0 = new AxThreed.AxSSPanel();
            this._ID_ACG_DEM_TXT_3 = new System.Windows.Forms.Label();
            this._ID_ACG_DEM_TXT_4 = new System.Windows.Forms.Label();
            this._ID_ACG_DEM_TXT_5 = new System.Windows.Forms.Label();
            this._ID_ACG_DEM_TXT_2 = new System.Windows.Forms.Label();
            this._ID_ACG_DEM_TXT_1 = new System.Windows.Forms.Label();
            this._ID_ACG_DEM_TXT_0 = new System.Windows.Forms.Label();
            this._ID_ACG_CON_PNL_1 = new AxThreed.AxSSPanel();
            this._ID_ACG_ETI_TXT_0 = new System.Windows.Forms.Label();
            this._ID_ACG_ETI_TXT_1 = new System.Windows.Forms.Label();
            this._ID_ACG_RES_TXT_0 = new System.Windows.Forms.Label();
            this._ID_ACG_RES_TXT_2 = new System.Windows.Forms.Label();
            this._ID_ACG_RES_TXT_1 = new System.Windows.Forms.Label();
            this._ID_ACG_ETI_TXT_2 = new System.Windows.Forms.Label();
            this._ID_ACG_ETI_TXT_6 = new System.Windows.Forms.Label();
            this._ID_ACG_ETI_TXT_7 = new System.Windows.Forms.Label();
            this._ID_ACG_ETI_TXT_5 = new System.Windows.Forms.Label();
            this._ID_ACG_ETI_TXT_3 = new System.Windows.Forms.Label();
            this._ID_ACG_ETI_TXT_4 = new System.Windows.Forms.Label();
            this._ID_ACG_RES_TXT_6 = new System.Windows.Forms.Label();
            this._ID_ACG_RES_TXT_7 = new System.Windows.Forms.Label();
            this._ID_ACG_RES_TXT_5 = new System.Windows.Forms.Label();
            this._ID_ACG_RES_TXT_3 = new System.Windows.Forms.Label();
            this._ID_ACG_RES_TXT_4 = new System.Windows.Forms.Label();
            this.fpID_GIR_CON_SS = new FarPoint.Win.Spread.FpSpread();
            this.fpID_GIR_CON_SS_Sheet1 = new FarPoint.Win.Spread.SheetView();            
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACG_PPL_PNL)).BeginInit();
            this.ID_ACG_PPL_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACG_LOG2_IMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACG_LOG1_IMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_ACG_CON_PNL_0)).BeginInit();
            this._ID_ACG_CON_PNL_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_ACG_CON_PNL_1)).BeginInit();
            this._ID_ACG_CON_PNL_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_GIR_CON_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_GIR_CON_SS_Sheet1)).BeginInit();
            this.SuspendLayout();
            
            // 
            // ID_GIR_IMP_PB
            // 
            this.ID_GIR_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_GIR_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_GIR_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_GIR_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_GIR_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_GIR_IMP_PB.Location = new System.Drawing.Point(207, 312);
            this.ID_GIR_IMP_PB.Name = "ID_GIR_IMP_PB";
            this.ID_GIR_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_GIR_IMP_PB.Size = new System.Drawing.Size(73, 23);
            this.ID_GIR_IMP_PB.TabIndex = 27;
            this.ID_GIR_IMP_PB.Tag = "";
            this.ID_GIR_IMP_PB.Text = "&Imprimir";
            this.ID_GIR_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_GIR_IMP_PB.Click += new System.EventHandler(this.ID_GIR_IMP_PB_Click);
            // 
            // ID_GIR_SAL_PB
            // 
            this.ID_GIR_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_GIR_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_GIR_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_GIR_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_GIR_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_GIR_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_GIR_SAL_PB.Location = new System.Drawing.Point(296, 312);
            this.ID_GIR_SAL_PB.Name = "ID_GIR_SAL_PB";
            this.ID_GIR_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_GIR_SAL_PB.Size = new System.Drawing.Size(73, 23);
            this.ID_GIR_SAL_PB.TabIndex = 1;
            this.ID_GIR_SAL_PB.Tag = "";
            this.ID_GIR_SAL_PB.Text = "&Salir";
            this.ID_GIR_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_GIR_SAL_PB.Click += new System.EventHandler(this.ID_GIR_SAL_PB_Click);
            // 
            // ID_ACG_PPL_PNL
            // 
            this.ID_ACG_PPL_PNL.Controls.Add(this.ID_ACG_LOG2_IMG);
            this.ID_ACG_PPL_PNL.Controls.Add(this.ID_ACG_LOG1_IMG);
            this.ID_ACG_PPL_PNL.Location = new System.Drawing.Point(8, 6);
            this.ID_ACG_PPL_PNL.Name = "ID_ACG_PPL_PNL";
            this.ID_ACG_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACG_PPL_PNL.OcxState")));
            this.ID_ACG_PPL_PNL.Size = new System.Drawing.Size(553, 51);
            this.ID_ACG_PPL_PNL.TabIndex = 2;
            this.ID_ACG_PPL_PNL.Tag = "";
            // 
            // ID_ACG_LOG2_IMG
            // 
            this.ID_ACG_LOG2_IMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_ACG_LOG2_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_ACG_LOG2_IMG.Image")));
            this.ID_ACG_LOG2_IMG.Location = new System.Drawing.Point(394, 2);
            this.ID_ACG_LOG2_IMG.Name = "ID_ACG_LOG2_IMG";
            this.ID_ACG_LOG2_IMG.Size = new System.Drawing.Size(146, 40);
            this.ID_ACG_LOG2_IMG.TabIndex = 0;
            this.ID_ACG_LOG2_IMG.TabStop = false;
            this.ID_ACG_LOG2_IMG.Tag = "";
            // 
            // ID_ACG_LOG1_IMG
            // 
            this.ID_ACG_LOG1_IMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_ACG_LOG1_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_ACG_LOG1_IMG.Image")));
            this.ID_ACG_LOG1_IMG.Location = new System.Drawing.Point(0, 0);
            this.ID_ACG_LOG1_IMG.Name = "ID_ACG_LOG1_IMG";
            this.ID_ACG_LOG1_IMG.Size = new System.Drawing.Size(126, 48);
            this.ID_ACG_LOG1_IMG.TabIndex = 1;
            this.ID_ACG_LOG1_IMG.TabStop = false;
            this.ID_ACG_LOG1_IMG.Tag = "";
            // 
            // _ID_ACG_CON_PNL_0
            // 
            this._ID_ACG_CON_PNL_0.Controls.Add(this._ID_ACG_DEM_TXT_3);
            this._ID_ACG_CON_PNL_0.Controls.Add(this._ID_ACG_DEM_TXT_4);
            this._ID_ACG_CON_PNL_0.Controls.Add(this._ID_ACG_DEM_TXT_5);
            this._ID_ACG_CON_PNL_0.Controls.Add(this._ID_ACG_DEM_TXT_2);
            this._ID_ACG_CON_PNL_0.Controls.Add(this._ID_ACG_DEM_TXT_1);
            this._ID_ACG_CON_PNL_0.Controls.Add(this._ID_ACG_DEM_TXT_0);
            this._ID_ACG_CON_PNL_0.Location = new System.Drawing.Point(8, 57);
            this._ID_ACG_CON_PNL_0.Name = "_ID_ACG_CON_PNL_0";
            this._ID_ACG_CON_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACG_CON_PNL_0.OcxState")));
            this._ID_ACG_CON_PNL_0.Size = new System.Drawing.Size(286, 132);
            this._ID_ACG_CON_PNL_0.TabIndex = 0;
            this._ID_ACG_CON_PNL_0.Tag = "";
            // 
            // _ID_ACG_DEM_TXT_3
            // 
            this._ID_ACG_DEM_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_DEM_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_DEM_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_DEM_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_DEM_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_DEM_TXT_3.Location = new System.Drawing.Point(12, 62);
            this._ID_ACG_DEM_TXT_3.Name = "_ID_ACG_DEM_TXT_3";
            this._ID_ACG_DEM_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_DEM_TXT_3.Size = new System.Drawing.Size(265, 13);
            this._ID_ACG_DEM_TXT_3.TabIndex = 6;
            this._ID_ACG_DEM_TXT_3.Tag = "";
            // 
            // _ID_ACG_DEM_TXT_4
            // 
            this._ID_ACG_DEM_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_DEM_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_DEM_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_DEM_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_DEM_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_DEM_TXT_4.Location = new System.Drawing.Point(12, 78);
            this._ID_ACG_DEM_TXT_4.Name = "_ID_ACG_DEM_TXT_4";
            this._ID_ACG_DEM_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_DEM_TXT_4.Size = new System.Drawing.Size(265, 13);
            this._ID_ACG_DEM_TXT_4.TabIndex = 8;
            this._ID_ACG_DEM_TXT_4.Tag = "";
            // 
            // _ID_ACG_DEM_TXT_5
            // 
            this._ID_ACG_DEM_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_DEM_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_DEM_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_DEM_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_DEM_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_DEM_TXT_5.Location = new System.Drawing.Point(12, 94);
            this._ID_ACG_DEM_TXT_5.Name = "_ID_ACG_DEM_TXT_5";
            this._ID_ACG_DEM_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_DEM_TXT_5.Size = new System.Drawing.Size(265, 13);
            this._ID_ACG_DEM_TXT_5.TabIndex = 9;
            this._ID_ACG_DEM_TXT_5.Tag = "";
            // 
            // _ID_ACG_DEM_TXT_2
            // 
            this._ID_ACG_DEM_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_DEM_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_DEM_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_DEM_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_DEM_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_DEM_TXT_2.Location = new System.Drawing.Point(12, 47);
            this._ID_ACG_DEM_TXT_2.Name = "_ID_ACG_DEM_TXT_2";
            this._ID_ACG_DEM_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_DEM_TXT_2.Size = new System.Drawing.Size(265, 13);
            this._ID_ACG_DEM_TXT_2.TabIndex = 5;
            this._ID_ACG_DEM_TXT_2.Tag = "";
            // 
            // _ID_ACG_DEM_TXT_1
            // 
            this._ID_ACG_DEM_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_DEM_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_DEM_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_DEM_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_DEM_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_DEM_TXT_1.Location = new System.Drawing.Point(12, 30);
            this._ID_ACG_DEM_TXT_1.Name = "_ID_ACG_DEM_TXT_1";
            this._ID_ACG_DEM_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_DEM_TXT_1.Size = new System.Drawing.Size(265, 13);
            this._ID_ACG_DEM_TXT_1.TabIndex = 4;
            this._ID_ACG_DEM_TXT_1.Tag = "";
            // 
            // _ID_ACG_DEM_TXT_0
            // 
            this._ID_ACG_DEM_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_DEM_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_DEM_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_DEM_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_DEM_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_DEM_TXT_0.Location = new System.Drawing.Point(12, 14);
            this._ID_ACG_DEM_TXT_0.Name = "_ID_ACG_DEM_TXT_0";
            this._ID_ACG_DEM_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_DEM_TXT_0.Size = new System.Drawing.Size(265, 13);
            this._ID_ACG_DEM_TXT_0.TabIndex = 3;
            this._ID_ACG_DEM_TXT_0.Tag = "";
            // 
            // _ID_ACG_CON_PNL_1
            // 
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_ETI_TXT_0);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_ETI_TXT_1);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_RES_TXT_0);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_RES_TXT_2);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_RES_TXT_1);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_ETI_TXT_2);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_ETI_TXT_6);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_ETI_TXT_7);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_ETI_TXT_5);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_ETI_TXT_3);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_ETI_TXT_4);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_RES_TXT_6);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_RES_TXT_7);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_RES_TXT_5);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_RES_TXT_3);
            this._ID_ACG_CON_PNL_1.Controls.Add(this._ID_ACG_RES_TXT_4);
            this._ID_ACG_CON_PNL_1.Location = new System.Drawing.Point(294, 57);
            this._ID_ACG_CON_PNL_1.Name = "_ID_ACG_CON_PNL_1";
            this._ID_ACG_CON_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACG_CON_PNL_1.OcxState")));
            this._ID_ACG_CON_PNL_1.Size = new System.Drawing.Size(267, 132);
            this._ID_ACG_CON_PNL_1.TabIndex = 7;
            this._ID_ACG_CON_PNL_1.Tag = "";
            // 
            // _ID_ACG_ETI_TXT_0
            // 
            this._ID_ACG_ETI_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_ETI_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_ETI_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_ETI_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_ETI_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_ETI_TXT_0.Location = new System.Drawing.Point(14, 8);
            this._ID_ACG_ETI_TXT_0.Name = "_ID_ACG_ETI_TXT_0";
            this._ID_ACG_ETI_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_ETI_TXT_0.Size = new System.Drawing.Size(119, 16);
            this._ID_ACG_ETI_TXT_0.TabIndex = 17;
            this._ID_ACG_ETI_TXT_0.Tag = "";
            this._ID_ACG_ETI_TXT_0.Text = "Saldo Anterior";
            // 
            // _ID_ACG_ETI_TXT_1
            // 
            this._ID_ACG_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_ETI_TXT_1.Location = new System.Drawing.Point(13, 22);
            this._ID_ACG_ETI_TXT_1.Name = "_ID_ACG_ETI_TXT_1";
            this._ID_ACG_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_ETI_TXT_1.Size = new System.Drawing.Size(119, 16);
            this._ID_ACG_ETI_TXT_1.TabIndex = 16;
            this._ID_ACG_ETI_TXT_1.Tag = "";
            this._ID_ACG_ETI_TXT_1.Text = "   + Consumos";
            // 
            // _ID_ACG_RES_TXT_0
            // 
            this._ID_ACG_RES_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_RES_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_RES_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_RES_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_RES_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_RES_TXT_0.Location = new System.Drawing.Point(136, 9);
            this._ID_ACG_RES_TXT_0.Name = "_ID_ACG_RES_TXT_0";
            this._ID_ACG_RES_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_RES_TXT_0.Size = new System.Drawing.Size(120, 16);
            this._ID_ACG_RES_TXT_0.TabIndex = 18;
            this._ID_ACG_RES_TXT_0.Tag = "";
            this._ID_ACG_RES_TXT_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_ACG_RES_TXT_2
            // 
            this._ID_ACG_RES_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_RES_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_RES_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_RES_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_RES_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_RES_TXT_2.Location = new System.Drawing.Point(136, 37);
            this._ID_ACG_RES_TXT_2.Name = "_ID_ACG_RES_TXT_2";
            this._ID_ACG_RES_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_RES_TXT_2.Size = new System.Drawing.Size(120, 16);
            this._ID_ACG_RES_TXT_2.TabIndex = 20;
            this._ID_ACG_RES_TXT_2.Tag = "";
            this._ID_ACG_RES_TXT_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_ACG_RES_TXT_1
            // 
            this._ID_ACG_RES_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_RES_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_RES_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_RES_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_RES_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_RES_TXT_1.Location = new System.Drawing.Point(136, 23);
            this._ID_ACG_RES_TXT_1.Name = "_ID_ACG_RES_TXT_1";
            this._ID_ACG_RES_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_RES_TXT_1.Size = new System.Drawing.Size(120, 16);
            this._ID_ACG_RES_TXT_1.TabIndex = 19;
            this._ID_ACG_RES_TXT_1.Tag = "";
            this._ID_ACG_RES_TXT_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_ACG_ETI_TXT_2
            // 
            this._ID_ACG_ETI_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_ETI_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_ETI_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_ETI_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_ETI_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_ETI_TXT_2.Location = new System.Drawing.Point(13, 37);
            this._ID_ACG_ETI_TXT_2.Name = "_ID_ACG_ETI_TXT_2";
            this._ID_ACG_ETI_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_ETI_TXT_2.Size = new System.Drawing.Size(119, 16);
            this._ID_ACG_ETI_TXT_2.TabIndex = 15;
            this._ID_ACG_ETI_TXT_2.Tag = "";
            this._ID_ACG_ETI_TXT_2.Text = "   + Disp. en Efectivo";
            // 
            // _ID_ACG_ETI_TXT_6
            // 
            this._ID_ACG_ETI_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_ETI_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_ETI_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_ETI_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_ETI_TXT_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_ETI_TXT_6.Location = new System.Drawing.Point(14, 93);
            this._ID_ACG_ETI_TXT_6.Name = "_ID_ACG_ETI_TXT_6";
            this._ID_ACG_ETI_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_ETI_TXT_6.Size = new System.Drawing.Size(119, 16);
            this._ID_ACG_ETI_TXT_6.TabIndex = 11;
            this._ID_ACG_ETI_TXT_6.Tag = "";
            this._ID_ACG_ETI_TXT_6.Text = "   + I.V.A.";
            // 
            // _ID_ACG_ETI_TXT_7
            // 
            this._ID_ACG_ETI_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_ETI_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_ETI_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_ETI_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_ETI_TXT_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_ETI_TXT_7.Location = new System.Drawing.Point(14, 107);
            this._ID_ACG_ETI_TXT_7.Name = "_ID_ACG_ETI_TXT_7";
            this._ID_ACG_ETI_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_ETI_TXT_7.Size = new System.Drawing.Size(119, 16);
            this._ID_ACG_ETI_TXT_7.TabIndex = 10;
            this._ID_ACG_ETI_TXT_7.Tag = "";
            this._ID_ACG_ETI_TXT_7.Text = "= Saldo Nuevo";
            // 
            // _ID_ACG_ETI_TXT_5
            // 
            this._ID_ACG_ETI_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_ETI_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_ETI_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_ETI_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_ETI_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_ETI_TXT_5.Location = new System.Drawing.Point(14, 79);
            this._ID_ACG_ETI_TXT_5.Name = "_ID_ACG_ETI_TXT_5";
            this._ID_ACG_ETI_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_ETI_TXT_5.Size = new System.Drawing.Size(119, 16);
            this._ID_ACG_ETI_TXT_5.TabIndex = 12;
            this._ID_ACG_ETI_TXT_5.Tag = "";
            this._ID_ACG_ETI_TXT_5.Text = "   + Gastos Cobranza";
            // 
            // _ID_ACG_ETI_TXT_3
            // 
            this._ID_ACG_ETI_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_ETI_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_ETI_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_ETI_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_ETI_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_ETI_TXT_3.Location = new System.Drawing.Point(14, 51);
            this._ID_ACG_ETI_TXT_3.Name = "_ID_ACG_ETI_TXT_3";
            this._ID_ACG_ETI_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_ETI_TXT_3.Size = new System.Drawing.Size(119, 16);
            this._ID_ACG_ETI_TXT_3.TabIndex = 14;
            this._ID_ACG_ETI_TXT_3.Tag = "";
            this._ID_ACG_ETI_TXT_3.Text = "   - Pagos";
            // 
            // _ID_ACG_ETI_TXT_4
            // 
            this._ID_ACG_ETI_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_ETI_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_ETI_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_ETI_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_ETI_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_ETI_TXT_4.Location = new System.Drawing.Point(14, 65);
            this._ID_ACG_ETI_TXT_4.Name = "_ID_ACG_ETI_TXT_4";
            this._ID_ACG_ETI_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_ETI_TXT_4.Size = new System.Drawing.Size(119, 16);
            this._ID_ACG_ETI_TXT_4.TabIndex = 13;
            this._ID_ACG_ETI_TXT_4.Tag = "";
            this._ID_ACG_ETI_TXT_4.Text = "   + Comisiones";
            // 
            // _ID_ACG_RES_TXT_6
            // 
            this._ID_ACG_RES_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_RES_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_RES_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_RES_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_RES_TXT_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_RES_TXT_6.Location = new System.Drawing.Point(136, 93);
            this._ID_ACG_RES_TXT_6.Name = "_ID_ACG_RES_TXT_6";
            this._ID_ACG_RES_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_RES_TXT_6.Size = new System.Drawing.Size(120, 16);
            this._ID_ACG_RES_TXT_6.TabIndex = 25;
            this._ID_ACG_RES_TXT_6.Tag = "";
            this._ID_ACG_RES_TXT_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_ACG_RES_TXT_7
            // 
            this._ID_ACG_RES_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_RES_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_RES_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_RES_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_RES_TXT_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_RES_TXT_7.Location = new System.Drawing.Point(136, 107);
            this._ID_ACG_RES_TXT_7.Name = "_ID_ACG_RES_TXT_7";
            this._ID_ACG_RES_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_RES_TXT_7.Size = new System.Drawing.Size(120, 16);
            this._ID_ACG_RES_TXT_7.TabIndex = 26;
            this._ID_ACG_RES_TXT_7.Tag = "";
            this._ID_ACG_RES_TXT_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_ACG_RES_TXT_5
            // 
            this._ID_ACG_RES_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_RES_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_RES_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_RES_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_RES_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_RES_TXT_5.Location = new System.Drawing.Point(136, 79);
            this._ID_ACG_RES_TXT_5.Name = "_ID_ACG_RES_TXT_5";
            this._ID_ACG_RES_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_RES_TXT_5.Size = new System.Drawing.Size(120, 16);
            this._ID_ACG_RES_TXT_5.TabIndex = 23;
            this._ID_ACG_RES_TXT_5.Tag = "";
            this._ID_ACG_RES_TXT_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_ACG_RES_TXT_3
            // 
            this._ID_ACG_RES_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_RES_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_RES_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_RES_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_RES_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_RES_TXT_3.Location = new System.Drawing.Point(136, 51);
            this._ID_ACG_RES_TXT_3.Name = "_ID_ACG_RES_TXT_3";
            this._ID_ACG_RES_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_RES_TXT_3.Size = new System.Drawing.Size(120, 16);
            this._ID_ACG_RES_TXT_3.TabIndex = 21;
            this._ID_ACG_RES_TXT_3.Tag = "";
            this._ID_ACG_RES_TXT_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_ACG_RES_TXT_4
            // 
            this._ID_ACG_RES_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_ACG_RES_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_ACG_RES_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_ACG_RES_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_ACG_RES_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_ACG_RES_TXT_4.Location = new System.Drawing.Point(136, 65);
            this._ID_ACG_RES_TXT_4.Name = "_ID_ACG_RES_TXT_4";
            this._ID_ACG_RES_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_ACG_RES_TXT_4.Size = new System.Drawing.Size(120, 16);
            this._ID_ACG_RES_TXT_4.TabIndex = 22;
            this._ID_ACG_RES_TXT_4.Tag = "";
            this._ID_ACG_RES_TXT_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fpID_GIR_CON_SS
            // 
            this.fpID_GIR_CON_SS.AccessibleDescription = "";
            this.fpID_GIR_CON_SS.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpID_GIR_CON_SS.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpID_GIR_CON_SS.HorizontalScrollBar.Name = "";
            this.fpID_GIR_CON_SS.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpID_GIR_CON_SS.HorizontalScrollBar.TabIndex = 4;
            this.fpID_GIR_CON_SS.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpID_GIR_CON_SS.Location = new System.Drawing.Point(11, 193);
            this.fpID_GIR_CON_SS.Name = "fpID_GIR_CON_SS";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpID_GIR_CON_SS.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpID_GIR_CON_SS.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpID_GIR_CON_SS_Sheet1});
            this.fpID_GIR_CON_SS.Size = new System.Drawing.Size(548, 113);
            this.fpID_GIR_CON_SS.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpID_GIR_CON_SS.TabIndex = 28;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpID_GIR_CON_SS.TextTipAppearance = tipAppearance1;
            this.fpID_GIR_CON_SS.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpID_GIR_CON_SS.VerticalScrollBar.Name = "";
            this.fpID_GIR_CON_SS.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpID_GIR_CON_SS.VerticalScrollBar.TabIndex = 5;
            this.fpID_GIR_CON_SS.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpID_GIR_CON_SS.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpID_GIR_CON_SS_Sheet1
            // 
            this.fpID_GIR_CON_SS_Sheet1.Reset();
            this.fpID_GIR_CON_SS_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpID_GIR_CON_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpID_GIR_CON_SS_Sheet1.ColumnCount = 2;
            this.fpID_GIR_CON_SS_Sheet1.RowCount = 1000000;
            this.fpID_GIR_CON_SS_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_GIR_CON_SS_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_GIR_CON_SS_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpID_GIR_CON_SS_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_GIR_CON_SS_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpID_GIR_CON_SS_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Numbers;
            this.fpID_GIR_CON_SS_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_GIR_CON_SS_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpID_GIR_CON_SS_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpID_GIR_CON_SS_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_GIR_CON_SS_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpID_GIR_CON_SS_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_GIR_CON_SS_Sheet1.DataAutoCellTypes = false;
            this.fpID_GIR_CON_SS_Sheet1.DataAutoHeadings = false;
            this.fpID_GIR_CON_SS_Sheet1.DefaultStyleName = "Text333635406953627015467";
            this.fpID_GIR_CON_SS_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_GIR_CON_SS_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpID_GIR_CON_SS_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_GIR_CON_SS_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpID_GIR_CON_SS_Sheet1.Protect = false;
            this.fpID_GIR_CON_SS_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpID_GIR_CON_SS_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpID_GIR_CON_SS_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpID_GIR_CON_SS_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_GIR_CON_SS_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpID_GIR_CON_SS_Sheet1.RowHeader.Visible = false;
            this.fpID_GIR_CON_SS_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpID_GIR_CON_SS_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpID_GIR_CON_SS_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_GIR_CON_SS_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpID_GIR_CON_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // CORRPANG
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.ID_GIR_SAL_PB;
            this.ClientSize = new System.Drawing.Size(568, 341);
            this.Controls.Add(this.fpID_GIR_CON_SS);            
            this.Controls.Add(this.ID_GIR_IMP_PB);
            this.Controls.Add(this._ID_ACG_CON_PNL_0);
            this.Controls.Add(this._ID_ACG_CON_PNL_1);
            this.Controls.Add(this.ID_ACG_PPL_PNL);
            this.Controls.Add(this.ID_GIR_SAL_PB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(178, 107);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORRPANG";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = " ";
            this.Text = "Consumos por Giro";
            this.Activated += new System.EventHandler(this.CORRPANG_Activated);
            this.Closed += new System.EventHandler(this.CORRPANG_Closed);
            this.Deactivate += new System.EventHandler(this.CORRPANG_Deactivate);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORRPANG_KeyPress);            
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACG_PPL_PNL)).EndInit();
            this.ID_ACG_PPL_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACG_LOG2_IMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACG_LOG1_IMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_ACG_CON_PNL_0)).EndInit();
            this._ID_ACG_CON_PNL_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ID_ACG_CON_PNL_1)).EndInit();
            this._ID_ACG_CON_PNL_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpID_GIR_CON_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_GIR_CON_SS_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        void InitializeID_ACG_RES_TXT()
        {
            this.ID_ACG_RES_TXT[7] = _ID_ACG_RES_TXT_7;
            this.ID_ACG_RES_TXT[6] = _ID_ACG_RES_TXT_6;
            this.ID_ACG_RES_TXT[5] = _ID_ACG_RES_TXT_5;
            this.ID_ACG_RES_TXT[4] = _ID_ACG_RES_TXT_4;
            this.ID_ACG_RES_TXT[3] = _ID_ACG_RES_TXT_3;
            this.ID_ACG_RES_TXT[2] = _ID_ACG_RES_TXT_2;
            this.ID_ACG_RES_TXT[1] = _ID_ACG_RES_TXT_1;
            this.ID_ACG_RES_TXT[0] = _ID_ACG_RES_TXT_0;
        }
        void InitializeID_ACG_CON_PNL()
        {
            this.ID_ACG_CON_PNL[0] = _ID_ACG_CON_PNL_0;
            this.ID_ACG_CON_PNL[1] = _ID_ACG_CON_PNL_1;
        }
        void InitializeID_ACG_ETI_TXT()
        {
            this.ID_ACG_ETI_TXT[0] = _ID_ACG_ETI_TXT_0;
            this.ID_ACG_ETI_TXT[1] = _ID_ACG_ETI_TXT_1;
            this.ID_ACG_ETI_TXT[2] = _ID_ACG_ETI_TXT_2;
            this.ID_ACG_ETI_TXT[3] = _ID_ACG_ETI_TXT_3;
            this.ID_ACG_ETI_TXT[4] = _ID_ACG_ETI_TXT_4;
            this.ID_ACG_ETI_TXT[5] = _ID_ACG_ETI_TXT_5;
            this.ID_ACG_ETI_TXT[6] = _ID_ACG_ETI_TXT_6;
            this.ID_ACG_ETI_TXT[7] = _ID_ACG_ETI_TXT_7;
        }
        void InitializeID_ACG_DEM_TXT()
        {
            this.ID_ACG_DEM_TXT[5] = _ID_ACG_DEM_TXT_5;
            this.ID_ACG_DEM_TXT[4] = _ID_ACG_DEM_TXT_4;
            this.ID_ACG_DEM_TXT[3] = _ID_ACG_DEM_TXT_3;
            this.ID_ACG_DEM_TXT[2] = _ID_ACG_DEM_TXT_2;
            this.ID_ACG_DEM_TXT[1] = _ID_ACG_DEM_TXT_1;
            this.ID_ACG_DEM_TXT[0] = _ID_ACG_DEM_TXT_0;
        }
        #endregion

        private FarPoint.Win.Spread.FpSpread fpID_GIR_CON_SS;
        private FarPoint.Win.Spread.SheetView fpID_GIR_CON_SS_Sheet1;
    }
}