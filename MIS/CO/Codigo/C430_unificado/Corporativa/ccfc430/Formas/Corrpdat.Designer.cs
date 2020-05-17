using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORRPDAT
	{
	
#region "Upgrade Support "
		private static CORRPDAT m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORRPDAT DefInstance
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
		public CORRPDAT():base(){
			if (m_vb6FormDefInstance == null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				} else
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
            ID_CEJ_REP_SS = new Softtek.Util.Win.Spread.SpreadWrapper(fpID_CEJ_REP_SS);
			InitializeHelp();
			InitializeID_DAT_DEM_TXT();
			InitializeID_DAT_CUE_TXT();
			InitializeID_DAT_RES_TXT();
			InitializeID_DAT_NUM_TXT();
			InitializeID_DAT_ETI_TXT();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORRPDAT CreateInstance()
	{
			CORRPDAT theInstance = new CORRPDAT();
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
	protected void  InitializeHelp()
	{
			Artinsoft.VB6.Help.HelpSupportClass.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Index);
	}
	private void  ReleaseResources( object eventSender,  System.EventArgs eventArgs)
	{
			Dispose(true);
			m_vb6FormDefInstance = null;
	}
	//Form overrides dispose to clean up the component list.
	[System.Diagnostics.DebuggerNonUserCode]
	 protected   override  void  Dispose( bool Disposing)
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
    public Softtek.Util.Win.Spread.SpreadWrapper ID_CEJ_REP_SS;
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;	
	public  System.Windows.Forms.Button ID_CEJ_IMP_PB;
	public  System.Windows.Forms.Button ID_CEJ_LEY_PB;
	public  System.Windows.Forms.Button ID_CEJ_SAL_PB;
	public  System.Windows.Forms.PictureBox ID_DAT_LOG2_PIC;
	private  System.Windows.Forms.Label _ID_DAT_NUM_TXT_0;
	private  System.Windows.Forms.Label _ID_DAT_CUE_TXT_0;
	public  System.Windows.Forms.Label ID_CEJ_BAN_LBL;
	public  System.Windows.Forms.PictureBox ID_CEJ_LOG_IMG;
	public  System.Windows.Forms.Panel ID_CEJ_TIT_PNL;
	private  System.Windows.Forms.Label _ID_DAT_DEM_TXT_5;
	private  System.Windows.Forms.Label _ID_DAT_DEM_TXT_4;
	private  System.Windows.Forms.Label _ID_DAT_DEM_TXT_2;
	private  System.Windows.Forms.Label _ID_DAT_DEM_TXT_1;
	private  System.Windows.Forms.Label _ID_DAT_DEM_TXT_0;
	private  System.Windows.Forms.Label _ID_DAT_DEM_TXT_3;
        public System.Windows.Forms.Panel ID_DAT_DEM_PNL;
	private  System.Windows.Forms.Label _ID_DAT_RES_TXT_7;
	private  System.Windows.Forms.Label _ID_DAT_RES_TXT_6;
	private  System.Windows.Forms.Label _ID_DAT_RES_TXT_5;
	private  System.Windows.Forms.Label _ID_DAT_RES_TXT_4;
	private  System.Windows.Forms.Label _ID_DAT_RES_TXT_3;
	private  System.Windows.Forms.Label _ID_DAT_RES_TXT_2;
	private  System.Windows.Forms.Label _ID_DAT_RES_TXT_1;
	private  System.Windows.Forms.Label _ID_DAT_RES_TXT_0;
	private  System.Windows.Forms.Label _ID_DAT_ETI_TXT_0;
	private  System.Windows.Forms.Label _ID_DAT_ETI_TXT_1;
	private  System.Windows.Forms.Label _ID_DAT_ETI_TXT_2;
	private  System.Windows.Forms.Label _ID_DAT_ETI_TXT_3;
	private  System.Windows.Forms.Label _ID_DAT_ETI_TXT_4;
	private  System.Windows.Forms.Label _ID_DAT_ETI_TXT_5;
	private  System.Windows.Forms.Label _ID_DAT_ETI_TXT_6;
	private  System.Windows.Forms.Label _ID_DAT_ETI_TXT_7;
        public System.Windows.Forms.Panel ID_DAT_RES_PNL;
	public System.Windows.Forms.Label[] ID_DAT_CUE_TXT = new System.Windows.Forms.Label[1];
	public System.Windows.Forms.Label[] ID_DAT_DEM_TXT = new System.Windows.Forms.Label[6];
	public System.Windows.Forms.Label[] ID_DAT_ETI_TXT = new System.Windows.Forms.Label[8];
	public System.Windows.Forms.Label[] ID_DAT_NUM_TXT = new System.Windows.Forms.Label[1];
	public System.Windows.Forms.Label[] ID_DAT_RES_TXT = new System.Windows.Forms.Label[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPDAT));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color50635406972830773859", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text323635406972830783860", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);            
            this.ID_CEJ_IMP_PB = new System.Windows.Forms.Button();
            this.ID_CEJ_LEY_PB = new System.Windows.Forms.Button();
            this.ID_CEJ_SAL_PB = new System.Windows.Forms.Button();
            this.ID_CEJ_TIT_PNL = new System.Windows.Forms.Panel();
            this._ID_DAT_CUE_TXT_0 = new System.Windows.Forms.Label();
            this._ID_DAT_NUM_TXT_0 = new System.Windows.Forms.Label();
            this.ID_DAT_LOG2_PIC = new System.Windows.Forms.PictureBox();
            this.ID_CEJ_LOG_IMG = new System.Windows.Forms.PictureBox();
            this.ID_CEJ_BAN_LBL = new System.Windows.Forms.Label();
            this.ID_DAT_DEM_PNL = new System.Windows.Forms.Panel();
            this._ID_DAT_DEM_TXT_2 = new System.Windows.Forms.Label();
            this._ID_DAT_DEM_TXT_4 = new System.Windows.Forms.Label();
            this._ID_DAT_DEM_TXT_5 = new System.Windows.Forms.Label();
            this._ID_DAT_DEM_TXT_1 = new System.Windows.Forms.Label();
            this._ID_DAT_DEM_TXT_3 = new System.Windows.Forms.Label();
            this._ID_DAT_DEM_TXT_0 = new System.Windows.Forms.Label();
            this.ID_DAT_RES_PNL = new System.Windows.Forms.Panel();
            this._ID_DAT_ETI_TXT_0 = new System.Windows.Forms.Label();
            this._ID_DAT_ETI_TXT_1 = new System.Windows.Forms.Label();
            this._ID_DAT_RES_TXT_0 = new System.Windows.Forms.Label();
            this._ID_DAT_RES_TXT_2 = new System.Windows.Forms.Label();
            this._ID_DAT_RES_TXT_1 = new System.Windows.Forms.Label();
            this._ID_DAT_ETI_TXT_2 = new System.Windows.Forms.Label();
            this._ID_DAT_ETI_TXT_6 = new System.Windows.Forms.Label();
            this._ID_DAT_ETI_TXT_7 = new System.Windows.Forms.Label();
            this._ID_DAT_ETI_TXT_5 = new System.Windows.Forms.Label();
            this._ID_DAT_ETI_TXT_3 = new System.Windows.Forms.Label();
            this._ID_DAT_ETI_TXT_4 = new System.Windows.Forms.Label();
            this._ID_DAT_RES_TXT_6 = new System.Windows.Forms.Label();
            this._ID_DAT_RES_TXT_7 = new System.Windows.Forms.Label();
            this._ID_DAT_RES_TXT_5 = new System.Windows.Forms.Label();
            this._ID_DAT_RES_TXT_3 = new System.Windows.Forms.Label();
            this._ID_DAT_RES_TXT_4 = new System.Windows.Forms.Label();
            this.fpID_CEJ_REP_SS = new FarPoint.Win.Spread.FpSpread();
            this.fpID_CEJ_REP_SS_Sheet1 = new FarPoint.Win.Spread.SheetView();            
            this.ID_CEJ_TIT_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_DAT_LOG2_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_LOG_IMG)).BeginInit();
            this.ID_DAT_DEM_PNL.SuspendLayout();
            this.ID_DAT_RES_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_CEJ_REP_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_CEJ_REP_SS_Sheet1)).BeginInit();
            this.SuspendLayout();
            
            // 
            // ID_CEJ_IMP_PB
            // 
            this.ID_CEJ_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEJ_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_IMP_PB.Location = new System.Drawing.Point(216, 319);
            this.ID_CEJ_IMP_PB.Name = "ID_CEJ_IMP_PB";
            this.ID_CEJ_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_IMP_PB.Size = new System.Drawing.Size(73, 25);
            this.ID_CEJ_IMP_PB.TabIndex = 32;
            this.ID_CEJ_IMP_PB.Tag = "";
            this.ID_CEJ_IMP_PB.Text = "&Imprimir";
            this.ID_CEJ_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_CEJ_IMP_PB.Click += new System.EventHandler(this.ID_CEJ_IMP_PB_Click);
            // 
            // ID_CEJ_LEY_PB
            // 
            this.ID_CEJ_LEY_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEJ_LEY_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_LEY_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_LEY_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_LEY_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_LEY_PB.Location = new System.Drawing.Point(125, 319);
            this.ID_CEJ_LEY_PB.Name = "ID_CEJ_LEY_PB";
            this.ID_CEJ_LEY_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_LEY_PB.Size = new System.Drawing.Size(73, 25);
            this.ID_CEJ_LEY_PB.TabIndex = 1;
            this.ID_CEJ_LEY_PB.Tag = "";
            this.ID_CEJ_LEY_PB.Text = "&Leyenda";
            this.ID_CEJ_LEY_PB.UseVisualStyleBackColor = false;
            this.ID_CEJ_LEY_PB.Click += new System.EventHandler(this.ID_CEJ_LEY_PB_Click);
            // 
            // ID_CEJ_SAL_PB
            // 
            this.ID_CEJ_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEJ_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_CEJ_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_SAL_PB.Location = new System.Drawing.Point(306, 319);
            this.ID_CEJ_SAL_PB.Name = "ID_CEJ_SAL_PB";
            this.ID_CEJ_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_SAL_PB.Size = new System.Drawing.Size(75, 25);
            this.ID_CEJ_SAL_PB.TabIndex = 2;
            this.ID_CEJ_SAL_PB.Tag = "";
            this.ID_CEJ_SAL_PB.Text = "&Salir";
            this.ID_CEJ_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_CEJ_SAL_PB.Click += new System.EventHandler(this.ID_CEJ_SAL_PB_Click);
            // 
            // ID_CEJ_TIT_PNL
            // 
            this.ID_CEJ_TIT_PNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_CEJ_TIT_PNL.Controls.Add(this._ID_DAT_CUE_TXT_0);
            this.ID_CEJ_TIT_PNL.Controls.Add(this._ID_DAT_NUM_TXT_0);
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_DAT_LOG2_PIC);
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_CEJ_LOG_IMG);
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_CEJ_BAN_LBL);
            this.ID_CEJ_TIT_PNL.Location = new System.Drawing.Point(10, 4);
            this.ID_CEJ_TIT_PNL.Name = "ID_CEJ_TIT_PNL";
            this.ID_CEJ_TIT_PNL.Size = new System.Drawing.Size(593, 49);
            this.ID_CEJ_TIT_PNL.TabIndex = 0;
            this.ID_CEJ_TIT_PNL.Tag = "";
            // 
            // _ID_DAT_CUE_TXT_0
            // 
            this._ID_DAT_CUE_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_CUE_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_CUE_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_CUE_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_CUE_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_DAT_CUE_TXT_0.Location = new System.Drawing.Point(214, 26);
            this._ID_DAT_CUE_TXT_0.Name = "_ID_DAT_CUE_TXT_0";
            this._ID_DAT_CUE_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_CUE_TXT_0.Size = new System.Drawing.Size(46, 15);
            this._ID_DAT_CUE_TXT_0.TabIndex = 30;
            this._ID_DAT_CUE_TXT_0.Tag = "";
            this._ID_DAT_CUE_TXT_0.Text = "Cuenta:";
            // 
            // _ID_DAT_NUM_TXT_0
            // 
            this._ID_DAT_NUM_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_NUM_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_NUM_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_NUM_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_NUM_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_DAT_NUM_TXT_0.Location = new System.Drawing.Point(262, 24);
            this._ID_DAT_NUM_TXT_0.Name = "_ID_DAT_NUM_TXT_0";
            this._ID_DAT_NUM_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_NUM_TXT_0.Size = new System.Drawing.Size(181, 17);
            this._ID_DAT_NUM_TXT_0.TabIndex = 31;
            this._ID_DAT_NUM_TXT_0.Tag = "";
            // 
            // ID_DAT_LOG2_PIC
            // 
            this.ID_DAT_LOG2_PIC.BackColor = System.Drawing.Color.Gray;
            this.ID_DAT_LOG2_PIC.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_LOG2_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_LOG2_PIC.Image = ((System.Drawing.Image)(resources.GetObject("ID_DAT_LOG2_PIC.Image")));
            this.ID_DAT_LOG2_PIC.Location = new System.Drawing.Point(447, 11);
            this.ID_DAT_LOG2_PIC.Name = "ID_DAT_LOG2_PIC";
            this.ID_DAT_LOG2_PIC.Size = new System.Drawing.Size(131, 31);
            this.ID_DAT_LOG2_PIC.TabIndex = 3;
            this.ID_DAT_LOG2_PIC.TabStop = false;
            this.ID_DAT_LOG2_PIC.Tag = "";
            // 
            // ID_CEJ_LOG_IMG
            // 
            this.ID_CEJ_LOG_IMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_LOG_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_CEJ_LOG_IMG.Image")));
            this.ID_CEJ_LOG_IMG.Location = new System.Drawing.Point(7, 3);
            this.ID_CEJ_LOG_IMG.Name = "ID_CEJ_LOG_IMG";
            this.ID_CEJ_LOG_IMG.Size = new System.Drawing.Size(45, 45);
            this.ID_CEJ_LOG_IMG.TabIndex = 32;
            this.ID_CEJ_LOG_IMG.TabStop = false;
            this.ID_CEJ_LOG_IMG.Tag = "";
            // 
            // ID_CEJ_BAN_LBL
            // 
            this.ID_CEJ_BAN_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_BAN_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_BAN_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_BAN_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_BAN_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEJ_BAN_LBL.Location = new System.Drawing.Point(56, 12);
            this.ID_CEJ_BAN_LBL.Name = "ID_CEJ_BAN_LBL";
            this.ID_CEJ_BAN_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_BAN_LBL.Size = new System.Drawing.Size(118, 24);
            this.ID_CEJ_BAN_LBL.TabIndex = 4;
            this.ID_CEJ_BAN_LBL.Tag = "";
            this.ID_CEJ_BAN_LBL.Text = "Banamex";
            // 
            // ID_DAT_DEM_PNL
            // 
            this.ID_DAT_DEM_PNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_DAT_DEM_PNL.Controls.Add(this._ID_DAT_DEM_TXT_2);
            this.ID_DAT_DEM_PNL.Controls.Add(this._ID_DAT_DEM_TXT_4);
            this.ID_DAT_DEM_PNL.Controls.Add(this._ID_DAT_DEM_TXT_5);
            this.ID_DAT_DEM_PNL.Controls.Add(this._ID_DAT_DEM_TXT_1);
            this.ID_DAT_DEM_PNL.Controls.Add(this._ID_DAT_DEM_TXT_3);
            this.ID_DAT_DEM_PNL.Controls.Add(this._ID_DAT_DEM_TXT_0);
            this.ID_DAT_DEM_PNL.Location = new System.Drawing.Point(10, 52);
            this.ID_DAT_DEM_PNL.Name = "ID_DAT_DEM_PNL";
            this.ID_DAT_DEM_PNL.Size = new System.Drawing.Size(341, 125);
            this.ID_DAT_DEM_PNL.TabIndex = 5;
            this.ID_DAT_DEM_PNL.Tag = "";
            // 
            // _ID_DAT_DEM_TXT_2
            // 
            this._ID_DAT_DEM_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_DEM_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_DEM_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_DEM_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_DEM_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_DAT_DEM_TXT_2.Location = new System.Drawing.Point(16, 41);
            this._ID_DAT_DEM_TXT_2.Name = "_ID_DAT_DEM_TXT_2";
            this._ID_DAT_DEM_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_DEM_TXT_2.Size = new System.Drawing.Size(319, 17);
            this._ID_DAT_DEM_TXT_2.TabIndex = 26;
            this._ID_DAT_DEM_TXT_2.Tag = "";
            // 
            // _ID_DAT_DEM_TXT_4
            // 
            this._ID_DAT_DEM_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_DEM_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_DEM_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_DEM_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_DEM_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_DAT_DEM_TXT_4.Location = new System.Drawing.Point(16, 74);
            this._ID_DAT_DEM_TXT_4.Name = "_ID_DAT_DEM_TXT_4";
            this._ID_DAT_DEM_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_DEM_TXT_4.Size = new System.Drawing.Size(319, 17);
            this._ID_DAT_DEM_TXT_4.TabIndex = 27;
            this._ID_DAT_DEM_TXT_4.Tag = "";
            // 
            // _ID_DAT_DEM_TXT_5
            // 
            this._ID_DAT_DEM_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_DEM_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_DEM_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_DEM_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_DEM_TXT_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_DAT_DEM_TXT_5.Location = new System.Drawing.Point(16, 91);
            this._ID_DAT_DEM_TXT_5.Name = "_ID_DAT_DEM_TXT_5";
            this._ID_DAT_DEM_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_DEM_TXT_5.Size = new System.Drawing.Size(319, 17);
            this._ID_DAT_DEM_TXT_5.TabIndex = 28;
            this._ID_DAT_DEM_TXT_5.Tag = "";
            // 
            // _ID_DAT_DEM_TXT_1
            // 
            this._ID_DAT_DEM_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_DEM_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_DEM_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_DEM_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_DEM_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_DAT_DEM_TXT_1.Location = new System.Drawing.Point(16, 24);
            this._ID_DAT_DEM_TXT_1.Name = "_ID_DAT_DEM_TXT_1";
            this._ID_DAT_DEM_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_DEM_TXT_1.Size = new System.Drawing.Size(319, 17);
            this._ID_DAT_DEM_TXT_1.TabIndex = 25;
            this._ID_DAT_DEM_TXT_1.Tag = "";
            // 
            // _ID_DAT_DEM_TXT_3
            // 
            this._ID_DAT_DEM_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_DEM_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_DEM_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_DEM_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_DEM_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_DAT_DEM_TXT_3.Location = new System.Drawing.Point(16, 58);
            this._ID_DAT_DEM_TXT_3.Name = "_ID_DAT_DEM_TXT_3";
            this._ID_DAT_DEM_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_DEM_TXT_3.Size = new System.Drawing.Size(319, 17);
            this._ID_DAT_DEM_TXT_3.TabIndex = 23;
            this._ID_DAT_DEM_TXT_3.Tag = "";
            // 
            // _ID_DAT_DEM_TXT_0
            // 
            this._ID_DAT_DEM_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_DEM_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_DEM_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_DEM_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_DEM_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_DAT_DEM_TXT_0.Location = new System.Drawing.Point(15, 7);
            this._ID_DAT_DEM_TXT_0.Name = "_ID_DAT_DEM_TXT_0";
            this._ID_DAT_DEM_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_DEM_TXT_0.Size = new System.Drawing.Size(319, 17);
            this._ID_DAT_DEM_TXT_0.TabIndex = 24;
            this._ID_DAT_DEM_TXT_0.Tag = "";
            // 
            // ID_DAT_RES_PNL
            // 
            this.ID_DAT_RES_PNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_ETI_TXT_0);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_ETI_TXT_1);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_RES_TXT_0);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_RES_TXT_2);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_RES_TXT_1);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_ETI_TXT_2);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_ETI_TXT_6);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_ETI_TXT_7);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_ETI_TXT_5);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_ETI_TXT_3);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_ETI_TXT_4);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_RES_TXT_6);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_RES_TXT_7);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_RES_TXT_5);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_RES_TXT_3);
            this.ID_DAT_RES_PNL.Controls.Add(this._ID_DAT_RES_TXT_4);
            this.ID_DAT_RES_PNL.Location = new System.Drawing.Point(350, 52);
            this.ID_DAT_RES_PNL.Name = "ID_DAT_RES_PNL";
            this.ID_DAT_RES_PNL.Size = new System.Drawing.Size(253, 125);
            this.ID_DAT_RES_PNL.TabIndex = 12;
            this.ID_DAT_RES_PNL.Tag = "";
            // 
            // _ID_DAT_ETI_TXT_0
            // 
            this._ID_DAT_ETI_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_ETI_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_ETI_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_ETI_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_ETI_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_ETI_TXT_0.Location = new System.Drawing.Point(6, 5);
            this._ID_DAT_ETI_TXT_0.Name = "_ID_DAT_ETI_TXT_0";
            this._ID_DAT_ETI_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_ETI_TXT_0.Size = new System.Drawing.Size(119, 16);
            this._ID_DAT_ETI_TXT_0.TabIndex = 14;
            this._ID_DAT_ETI_TXT_0.Tag = "";
            this._ID_DAT_ETI_TXT_0.Text = "Saldo Anterior";
            // 
            // _ID_DAT_ETI_TXT_1
            // 
            this._ID_DAT_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_ETI_TXT_1.Location = new System.Drawing.Point(5, 19);
            this._ID_DAT_ETI_TXT_1.Name = "_ID_DAT_ETI_TXT_1";
            this._ID_DAT_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_ETI_TXT_1.Size = new System.Drawing.Size(119, 16);
            this._ID_DAT_ETI_TXT_1.TabIndex = 13;
            this._ID_DAT_ETI_TXT_1.Tag = "";
            this._ID_DAT_ETI_TXT_1.Text = "   + Consumos";
            // 
            // _ID_DAT_RES_TXT_0
            // 
            this._ID_DAT_RES_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_RES_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_RES_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_RES_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_RES_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_RES_TXT_0.Location = new System.Drawing.Point(128, 5);
            this._ID_DAT_RES_TXT_0.Name = "_ID_DAT_RES_TXT_0";
            this._ID_DAT_RES_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_RES_TXT_0.Size = new System.Drawing.Size(120, 16);
            this._ID_DAT_RES_TXT_0.TabIndex = 15;
            this._ID_DAT_RES_TXT_0.Tag = "";
            this._ID_DAT_RES_TXT_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_DAT_RES_TXT_2
            // 
            this._ID_DAT_RES_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_RES_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_RES_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_RES_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_RES_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_RES_TXT_2.Location = new System.Drawing.Point(128, 33);
            this._ID_DAT_RES_TXT_2.Name = "_ID_DAT_RES_TXT_2";
            this._ID_DAT_RES_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_RES_TXT_2.Size = new System.Drawing.Size(120, 16);
            this._ID_DAT_RES_TXT_2.TabIndex = 17;
            this._ID_DAT_RES_TXT_2.Tag = "";
            this._ID_DAT_RES_TXT_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_DAT_RES_TXT_1
            // 
            this._ID_DAT_RES_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_RES_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_RES_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_RES_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_RES_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_RES_TXT_1.Location = new System.Drawing.Point(128, 19);
            this._ID_DAT_RES_TXT_1.Name = "_ID_DAT_RES_TXT_1";
            this._ID_DAT_RES_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_RES_TXT_1.Size = new System.Drawing.Size(120, 16);
            this._ID_DAT_RES_TXT_1.TabIndex = 16;
            this._ID_DAT_RES_TXT_1.Tag = "";
            this._ID_DAT_RES_TXT_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_DAT_ETI_TXT_2
            // 
            this._ID_DAT_ETI_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_ETI_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_ETI_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_ETI_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_ETI_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_ETI_TXT_2.Location = new System.Drawing.Point(6, 33);
            this._ID_DAT_ETI_TXT_2.Name = "_ID_DAT_ETI_TXT_2";
            this._ID_DAT_ETI_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_ETI_TXT_2.Size = new System.Drawing.Size(119, 16);
            this._ID_DAT_ETI_TXT_2.TabIndex = 11;
            this._ID_DAT_ETI_TXT_2.Tag = "";
            this._ID_DAT_ETI_TXT_2.Text = "   + Disp. en Efectivo";
            // 
            // _ID_DAT_ETI_TXT_6
            // 
            this._ID_DAT_ETI_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_ETI_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_ETI_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_ETI_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_ETI_TXT_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_ETI_TXT_6.Location = new System.Drawing.Point(6, 89);
            this._ID_DAT_ETI_TXT_6.Name = "_ID_DAT_ETI_TXT_6";
            this._ID_DAT_ETI_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_ETI_TXT_6.Size = new System.Drawing.Size(119, 16);
            this._ID_DAT_ETI_TXT_6.TabIndex = 7;
            this._ID_DAT_ETI_TXT_6.Tag = "";
            this._ID_DAT_ETI_TXT_6.Text = "   + I.V.A.";
            // 
            // _ID_DAT_ETI_TXT_7
            // 
            this._ID_DAT_ETI_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_ETI_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_ETI_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_ETI_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_ETI_TXT_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_ETI_TXT_7.Location = new System.Drawing.Point(6, 103);
            this._ID_DAT_ETI_TXT_7.Name = "_ID_DAT_ETI_TXT_7";
            this._ID_DAT_ETI_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_ETI_TXT_7.Size = new System.Drawing.Size(119, 16);
            this._ID_DAT_ETI_TXT_7.TabIndex = 6;
            this._ID_DAT_ETI_TXT_7.Tag = "";
            this._ID_DAT_ETI_TXT_7.Text = "= Saldo Nuevo";
            // 
            // _ID_DAT_ETI_TXT_5
            // 
            this._ID_DAT_ETI_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_ETI_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_ETI_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_ETI_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_ETI_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_ETI_TXT_5.Location = new System.Drawing.Point(6, 75);
            this._ID_DAT_ETI_TXT_5.Name = "_ID_DAT_ETI_TXT_5";
            this._ID_DAT_ETI_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_ETI_TXT_5.Size = new System.Drawing.Size(119, 16);
            this._ID_DAT_ETI_TXT_5.TabIndex = 8;
            this._ID_DAT_ETI_TXT_5.Tag = "";
            this._ID_DAT_ETI_TXT_5.Text = "   + Gastos Cobranza";
            // 
            // _ID_DAT_ETI_TXT_3
            // 
            this._ID_DAT_ETI_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_ETI_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_ETI_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_ETI_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_ETI_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_ETI_TXT_3.Location = new System.Drawing.Point(6, 47);
            this._ID_DAT_ETI_TXT_3.Name = "_ID_DAT_ETI_TXT_3";
            this._ID_DAT_ETI_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_ETI_TXT_3.Size = new System.Drawing.Size(119, 16);
            this._ID_DAT_ETI_TXT_3.TabIndex = 10;
            this._ID_DAT_ETI_TXT_3.Tag = "";
            this._ID_DAT_ETI_TXT_3.Text = "   - Pagos";
            // 
            // _ID_DAT_ETI_TXT_4
            // 
            this._ID_DAT_ETI_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_ETI_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_ETI_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_ETI_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_ETI_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_ETI_TXT_4.Location = new System.Drawing.Point(6, 61);
            this._ID_DAT_ETI_TXT_4.Name = "_ID_DAT_ETI_TXT_4";
            this._ID_DAT_ETI_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_ETI_TXT_4.Size = new System.Drawing.Size(119, 16);
            this._ID_DAT_ETI_TXT_4.TabIndex = 9;
            this._ID_DAT_ETI_TXT_4.Tag = "";
            this._ID_DAT_ETI_TXT_4.Text = "   + Comisiones";
            // 
            // _ID_DAT_RES_TXT_6
            // 
            this._ID_DAT_RES_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_RES_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_RES_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_RES_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_RES_TXT_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_RES_TXT_6.Location = new System.Drawing.Point(128, 89);
            this._ID_DAT_RES_TXT_6.Name = "_ID_DAT_RES_TXT_6";
            this._ID_DAT_RES_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_RES_TXT_6.Size = new System.Drawing.Size(120, 16);
            this._ID_DAT_RES_TXT_6.TabIndex = 21;
            this._ID_DAT_RES_TXT_6.Tag = "";
            this._ID_DAT_RES_TXT_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_DAT_RES_TXT_7
            // 
            this._ID_DAT_RES_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_RES_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_RES_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_RES_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_RES_TXT_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_RES_TXT_7.Location = new System.Drawing.Point(128, 103);
            this._ID_DAT_RES_TXT_7.Name = "_ID_DAT_RES_TXT_7";
            this._ID_DAT_RES_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_RES_TXT_7.Size = new System.Drawing.Size(120, 16);
            this._ID_DAT_RES_TXT_7.TabIndex = 22;
            this._ID_DAT_RES_TXT_7.Tag = "";
            this._ID_DAT_RES_TXT_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_DAT_RES_TXT_5
            // 
            this._ID_DAT_RES_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_RES_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_RES_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_RES_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_RES_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_RES_TXT_5.Location = new System.Drawing.Point(128, 75);
            this._ID_DAT_RES_TXT_5.Name = "_ID_DAT_RES_TXT_5";
            this._ID_DAT_RES_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_RES_TXT_5.Size = new System.Drawing.Size(120, 16);
            this._ID_DAT_RES_TXT_5.TabIndex = 20;
            this._ID_DAT_RES_TXT_5.Tag = "";
            this._ID_DAT_RES_TXT_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_DAT_RES_TXT_3
            // 
            this._ID_DAT_RES_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_RES_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_RES_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_RES_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_RES_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_RES_TXT_3.Location = new System.Drawing.Point(128, 47);
            this._ID_DAT_RES_TXT_3.Name = "_ID_DAT_RES_TXT_3";
            this._ID_DAT_RES_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_RES_TXT_3.Size = new System.Drawing.Size(120, 16);
            this._ID_DAT_RES_TXT_3.TabIndex = 18;
            this._ID_DAT_RES_TXT_3.Tag = "";
            this._ID_DAT_RES_TXT_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_DAT_RES_TXT_4
            // 
            this._ID_DAT_RES_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_RES_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_RES_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_RES_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_RES_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_RES_TXT_4.Location = new System.Drawing.Point(128, 61);
            this._ID_DAT_RES_TXT_4.Name = "_ID_DAT_RES_TXT_4";
            this._ID_DAT_RES_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_RES_TXT_4.Size = new System.Drawing.Size(120, 16);
            this._ID_DAT_RES_TXT_4.TabIndex = 19;
            this._ID_DAT_RES_TXT_4.Tag = "";
            this._ID_DAT_RES_TXT_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fpID_CEJ_REP_SS
            // 
            this.fpID_CEJ_REP_SS.AccessibleDescription = "";
            this.fpID_CEJ_REP_SS.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpID_CEJ_REP_SS.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpID_CEJ_REP_SS.HorizontalScrollBar.Name = "";
            this.fpID_CEJ_REP_SS.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpID_CEJ_REP_SS.HorizontalScrollBar.TabIndex = 6;
            this.fpID_CEJ_REP_SS.Location = new System.Drawing.Point(12, 186);
            this.fpID_CEJ_REP_SS.Name = "fpID_CEJ_REP_SS";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpID_CEJ_REP_SS.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpID_CEJ_REP_SS.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpID_CEJ_REP_SS_Sheet1});
            this.fpID_CEJ_REP_SS.Size = new System.Drawing.Size(591, 130);
            this.fpID_CEJ_REP_SS.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpID_CEJ_REP_SS.TabIndex = 33;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpID_CEJ_REP_SS.TextTipAppearance = tipAppearance1;
            this.fpID_CEJ_REP_SS.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpID_CEJ_REP_SS.VerticalScrollBar.Name = "";
            this.fpID_CEJ_REP_SS.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpID_CEJ_REP_SS.VerticalScrollBar.TabIndex = 7;
            this.fpID_CEJ_REP_SS.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpID_CEJ_REP_SS.SetViewportLeftColumn(0, 0, 2);
            this.fpID_CEJ_REP_SS.SetActiveViewport(0, 0, -1);
            // 
            // fpID_CEJ_REP_SS_Sheet1
            // 
            this.fpID_CEJ_REP_SS_Sheet1.Reset();
            this.fpID_CEJ_REP_SS_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpID_CEJ_REP_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpID_CEJ_REP_SS_Sheet1.ColumnCount = 13;
            this.fpID_CEJ_REP_SS_Sheet1.RowCount = 5;
            this.fpID_CEJ_REP_SS_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_CEJ_REP_SS_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_CEJ_REP_SS_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpID_CEJ_REP_SS_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_CEJ_REP_SS_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpID_CEJ_REP_SS_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_CEJ_REP_SS_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpID_CEJ_REP_SS_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpID_CEJ_REP_SS_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_CEJ_REP_SS_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpID_CEJ_REP_SS_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_CEJ_REP_SS_Sheet1.DefaultStyleName = "Text323635406972830783860";
            this.fpID_CEJ_REP_SS_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_CEJ_REP_SS_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpID_CEJ_REP_SS_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_CEJ_REP_SS_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpID_CEJ_REP_SS_Sheet1.FrozenColumnCount = 2;
            this.fpID_CEJ_REP_SS_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpID_CEJ_REP_SS_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpID_CEJ_REP_SS_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpID_CEJ_REP_SS_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpID_CEJ_REP_SS_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_CEJ_REP_SS_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpID_CEJ_REP_SS_Sheet1.RowHeader.Visible = false;
            this.fpID_CEJ_REP_SS_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpID_CEJ_REP_SS_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpID_CEJ_REP_SS_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_CEJ_REP_SS_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpID_CEJ_REP_SS_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpID_CEJ_REP_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // CORRPDAT
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.ID_CEJ_SAL_PB;
            this.ClientSize = new System.Drawing.Size(610, 350);
            this.Controls.Add(this.fpID_CEJ_REP_SS);
            this.Controls.Add(this.ID_CEJ_IMP_PB);            
            this.Controls.Add(this.ID_DAT_DEM_PNL);
            this.Controls.Add(this.ID_DAT_RES_PNL);
            this.Controls.Add(this.ID_CEJ_TIT_PNL);
            this.Controls.Add(this.ID_CEJ_LEY_PB);
            this.Controls.Add(this.ID_CEJ_SAL_PB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(118, 209);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORRPDAT";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Detalle de Atrasos por Ejecutivo";
            this.Activated += new System.EventHandler(this.CORRPDAT_Activated);
            this.Closed += new System.EventHandler(this.CORRPDAT_Closed);
            this.Deactivate += new System.EventHandler(this.CORRPDAT_Deactivate);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORRPDAT_KeyPress);            
            this.ID_CEJ_TIT_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_DAT_LOG2_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_LOG_IMG)).EndInit();
            this.ID_DAT_DEM_PNL.ResumeLayout(false);
            this.ID_DAT_RES_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpID_CEJ_REP_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_CEJ_REP_SS_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeID_DAT_DEM_TXT()
	{
			this.ID_DAT_DEM_TXT[5] = _ID_DAT_DEM_TXT_5;
			this.ID_DAT_DEM_TXT[4] = _ID_DAT_DEM_TXT_4;
			this.ID_DAT_DEM_TXT[2] = _ID_DAT_DEM_TXT_2;
			this.ID_DAT_DEM_TXT[1] = _ID_DAT_DEM_TXT_1;
			this.ID_DAT_DEM_TXT[0] = _ID_DAT_DEM_TXT_0;
			this.ID_DAT_DEM_TXT[3] = _ID_DAT_DEM_TXT_3;
	}
	void  InitializeID_DAT_CUE_TXT()
	{
			this.ID_DAT_CUE_TXT[0] = _ID_DAT_CUE_TXT_0;
	}
	void  InitializeID_DAT_RES_TXT()
	{
			this.ID_DAT_RES_TXT[7] = _ID_DAT_RES_TXT_7;
			this.ID_DAT_RES_TXT[6] = _ID_DAT_RES_TXT_6;
			this.ID_DAT_RES_TXT[5] = _ID_DAT_RES_TXT_5;
			this.ID_DAT_RES_TXT[4] = _ID_DAT_RES_TXT_4;
			this.ID_DAT_RES_TXT[3] = _ID_DAT_RES_TXT_3;
			this.ID_DAT_RES_TXT[2] = _ID_DAT_RES_TXT_2;
			this.ID_DAT_RES_TXT[1] = _ID_DAT_RES_TXT_1;
			this.ID_DAT_RES_TXT[0] = _ID_DAT_RES_TXT_0;
	}
	void  InitializeID_DAT_NUM_TXT()
	{
			this.ID_DAT_NUM_TXT[0] = _ID_DAT_NUM_TXT_0;
	}
	void  InitializeID_DAT_ETI_TXT()
	{
			this.ID_DAT_ETI_TXT[0] = _ID_DAT_ETI_TXT_0;
			this.ID_DAT_ETI_TXT[1] = _ID_DAT_ETI_TXT_1;
			this.ID_DAT_ETI_TXT[2] = _ID_DAT_ETI_TXT_2;
			this.ID_DAT_ETI_TXT[3] = _ID_DAT_ETI_TXT_3;
			this.ID_DAT_ETI_TXT[4] = _ID_DAT_ETI_TXT_4;
			this.ID_DAT_ETI_TXT[5] = _ID_DAT_ETI_TXT_5;
			this.ID_DAT_ETI_TXT[6] = _ID_DAT_ETI_TXT_6;
			this.ID_DAT_ETI_TXT[7] = _ID_DAT_ETI_TXT_7;
	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpID_CEJ_REP_SS;
    private FarPoint.Win.Spread.SheetView fpID_CEJ_REP_SS_Sheet1;
}
}