using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORRPCEJ
	{
	
#region "Upgrade Support "
		private static CORRPCEJ m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORRPCEJ DefInstance
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
		public CORRPCEJ():base(){
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
			InitializeComponent(); //AIS-1213 echasiquiza
            ID_CEJ_REP_SS = new Softtek.Util.Win.Spread.SpreadWrapper(fpsID_CEJ_REP_SS);
			InitializeHelp();
			InitializeID_CEJ_ETI_TXT();
			InitializeID_DAT_CUE_TXT();
			InitializeID_DAT_NUM_TXT();
			InitializeID_CEJ_RES_TXT();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORRPCEJ CreateInstance()
	{
			CORRPCEJ theInstance = new CORRPCEJ();
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
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;
    public  System.Windows.Forms.Button ID_CEJ_IMP_PB;
	public  System.Windows.Forms.PictureBox ID_CEJ_COR_PIC;
	public  System.Windows.Forms.Label ID_CEJ_BAN_LBL;
	private  System.Windows.Forms.Label _ID_DAT_NUM_TXT_0;
	private  System.Windows.Forms.Label _ID_DAT_CUE_TXT_0;
	public  System.Windows.Forms.PictureBox ID_CEJ_LOG_IMG;
	public  AxThreed.AxSSPanel ID_CEJ_TIT_PNL;
	public  System.Windows.Forms.TextBox ID_CEJ_MSG_TXT;
	public  System.Windows.Forms.Button ID_CEJ_SAL_PB;
	public  System.Windows.Forms.TextBox ID_CEJ_CRE_EB;
	public  System.Windows.Forms.Label ID_CEJ_FEC_CRE_EB;
	public  System.Windows.Forms.Label ID_DAT_FEC_CRE_TXT;
	public  System.Windows.Forms.Label ID_CEJ_CRE_ACU_EB;
	public  System.Windows.Forms.Label ID_DAT_CRE_ACU_TXT;
	public  System.Windows.Forms.Label ID_CEJ_DI3_LBL;
	public  System.Windows.Forms.Label ID_CEJ_DI2_LBL;
	public  System.Windows.Forms.Label ID_CEJ_DI1_LBL;
	public  System.Windows.Forms.Label ID_CEJ_EMP_LBL;
	public  System.Windows.Forms.Label ID_DAT_CRE_TXT;
	public  System.Windows.Forms.Label ID_CEJ_CP_LBL;
	public  AxThreed.AxSSPanel ID_CEJ_IDE_PNL;
	private  System.Windows.Forms.Label _ID_CEJ_ETI_TXT_7;
	private  System.Windows.Forms.Label _ID_CEJ_ETI_TXT_6;
	private  System.Windows.Forms.Label _ID_CEJ_ETI_TXT_5;
	private  System.Windows.Forms.Label _ID_CEJ_ETI_TXT_4;
	private  System.Windows.Forms.Label _ID_CEJ_ETI_TXT_3;
	private  System.Windows.Forms.Label _ID_CEJ_ETI_TXT_2;
	private  System.Windows.Forms.Label _ID_CEJ_ETI_TXT_1;
	private  System.Windows.Forms.Label _ID_CEJ_ETI_TXT_0;
	private  System.Windows.Forms.Label _ID_CEJ_RES_TXT_0;
	private  System.Windows.Forms.Label _ID_CEJ_RES_TXT_1;
	private  System.Windows.Forms.Label _ID_CEJ_RES_TXT_2;
	private  System.Windows.Forms.Label _ID_CEJ_RES_TXT_3;
	private  System.Windows.Forms.Label _ID_CEJ_RES_TXT_4;
	private  System.Windows.Forms.Label _ID_CEJ_RES_TXT_5;
	private  System.Windows.Forms.Label _ID_CEJ_RES_TXT_6;
	private  System.Windows.Forms.Label _ID_CEJ_RES_TXT_7;
	public  AxThreed.AxSSPanel ID_CEJ_SAL_PNL;
	public  AxMSComDlg.AxCommonDialog ID_REJ_ARC_CDG;
	public  System.Windows.Forms.Label ID_CEJ_LEY_LB;
	public System.Windows.Forms.Label[] ID_CEJ_ETI_TXT = new System.Windows.Forms.Label[8];
	public System.Windows.Forms.Label[] ID_CEJ_RES_TXT = new System.Windows.Forms.Label[8];
	public System.Windows.Forms.Label[] ID_DAT_CUE_TXT = new System.Windows.Forms.Label[1];
	public System.Windows.Forms.Label[] ID_DAT_NUM_TXT = new System.Windows.Forms.Label[1];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPCEJ));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410404728369448", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text338635410404728379449", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("Text704635410404728399451");
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("Text753635410404728399451");
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_CEJ_IMP_PB = new System.Windows.Forms.Button();
            this.ID_CEJ_TIT_PNL = new AxThreed.AxSSPanel();
            this._ID_DAT_NUM_TXT_0 = new System.Windows.Forms.Label();
            this.ID_CEJ_BAN_LBL = new System.Windows.Forms.Label();
            this.ID_CEJ_COR_PIC = new System.Windows.Forms.PictureBox();
            this.ID_CEJ_LOG_IMG = new System.Windows.Forms.PictureBox();
            this._ID_DAT_CUE_TXT_0 = new System.Windows.Forms.Label();
            this.ID_CEJ_MSG_TXT = new System.Windows.Forms.TextBox();
            this.ID_CEJ_SAL_PB = new System.Windows.Forms.Button();
            this.ID_CEJ_IDE_PNL = new AxThreed.AxSSPanel();
            this.ID_CEJ_DI3_LBL = new System.Windows.Forms.Label();
            this.ID_CEJ_DI2_LBL = new System.Windows.Forms.Label();
            this.ID_CEJ_CRE_ACU_EB = new System.Windows.Forms.Label();
            this.ID_DAT_CRE_ACU_TXT = new System.Windows.Forms.Label();
            this.ID_DAT_CRE_TXT = new System.Windows.Forms.Label();
            this.ID_CEJ_CP_LBL = new System.Windows.Forms.Label();
            this.ID_CEJ_DI1_LBL = new System.Windows.Forms.Label();
            this.ID_CEJ_EMP_LBL = new System.Windows.Forms.Label();
            this.ID_DAT_FEC_CRE_TXT = new System.Windows.Forms.Label();
            this.ID_CEJ_CRE_EB = new System.Windows.Forms.TextBox();
            this.ID_CEJ_FEC_CRE_EB = new System.Windows.Forms.Label();
            this.ID_CEJ_SAL_PNL = new AxThreed.AxSSPanel();
            this._ID_CEJ_RES_TXT_0 = new System.Windows.Forms.Label();
            this._ID_CEJ_RES_TXT_1 = new System.Windows.Forms.Label();
            this._ID_CEJ_ETI_TXT_0 = new System.Windows.Forms.Label();
            this._ID_CEJ_ETI_TXT_2 = new System.Windows.Forms.Label();
            this._ID_CEJ_ETI_TXT_1 = new System.Windows.Forms.Label();
            this._ID_CEJ_RES_TXT_2 = new System.Windows.Forms.Label();
            this._ID_CEJ_RES_TXT_6 = new System.Windows.Forms.Label();
            this._ID_CEJ_RES_TXT_7 = new System.Windows.Forms.Label();
            this._ID_CEJ_RES_TXT_5 = new System.Windows.Forms.Label();
            this._ID_CEJ_RES_TXT_3 = new System.Windows.Forms.Label();
            this._ID_CEJ_RES_TXT_4 = new System.Windows.Forms.Label();
            this._ID_CEJ_ETI_TXT_6 = new System.Windows.Forms.Label();
            this._ID_CEJ_ETI_TXT_7 = new System.Windows.Forms.Label();
            this._ID_CEJ_ETI_TXT_5 = new System.Windows.Forms.Label();
            this._ID_CEJ_ETI_TXT_3 = new System.Windows.Forms.Label();
            this._ID_CEJ_ETI_TXT_4 = new System.Windows.Forms.Label();
            this.ID_REJ_ARC_CDG = new AxMSComDlg.AxCommonDialog();
            this.ID_CEJ_LEY_LB = new System.Windows.Forms.Label();
            this.fpsID_CEJ_REP_SS = new FarPoint.Win.Spread.FpSpread();
            this.fpsID_CEJ_REP_SS_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_TIT_PNL)).BeginInit();
            this.ID_CEJ_TIT_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_COR_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_LOG_IMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_IDE_PNL)).BeginInit();
            this.ID_CEJ_IDE_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_SAL_PNL)).BeginInit();
            this.ID_CEJ_SAL_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_REJ_ARC_CDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CEJ_REP_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CEJ_REP_SS_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_CEJ_IMP_PB
            // 
            this.ID_CEJ_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEJ_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_IMP_PB.Location = new System.Drawing.Point(212, 362);
            this.ID_CEJ_IMP_PB.Name = "ID_CEJ_IMP_PB";
            this.ID_CEJ_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_IMP_PB.Size = new System.Drawing.Size(78, 25);
            this.ID_CEJ_IMP_PB.TabIndex = 38;
            this.ID_CEJ_IMP_PB.Tag = "";
            this.ID_CEJ_IMP_PB.Text = "Imprimir";
            this.ID_CEJ_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_CEJ_IMP_PB.Click += new System.EventHandler(this.ID_CEJ_IMP_PB_Click);
            // 
            // ID_CEJ_TIT_PNL
            // 
            this.ID_CEJ_TIT_PNL.Controls.Add(this._ID_DAT_NUM_TXT_0);
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_CEJ_BAN_LBL);
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_CEJ_COR_PIC);
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_CEJ_LOG_IMG);
            this.ID_CEJ_TIT_PNL.Controls.Add(this._ID_DAT_CUE_TXT_0);
            this.ID_CEJ_TIT_PNL.Location = new System.Drawing.Point(11, 6);
            this.ID_CEJ_TIT_PNL.Name = "ID_CEJ_TIT_PNL";
            this.ID_CEJ_TIT_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEJ_TIT_PNL.OcxState")));
            this.ID_CEJ_TIT_PNL.Size = new System.Drawing.Size(593, 51);
            this.ID_CEJ_TIT_PNL.TabIndex = 7;
            this.ID_CEJ_TIT_PNL.Tag = "";
            // 
            // _ID_DAT_NUM_TXT_0
            // 
            this._ID_DAT_NUM_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_NUM_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_NUM_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_NUM_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_NUM_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_NUM_TXT_0.Location = new System.Drawing.Point(260, 19);
            this._ID_DAT_NUM_TXT_0.Name = "_ID_DAT_NUM_TXT_0";
            this._ID_DAT_NUM_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_NUM_TXT_0.Size = new System.Drawing.Size(132, 17);
            this._ID_DAT_NUM_TXT_0.TabIndex = 6;
            this._ID_DAT_NUM_TXT_0.Tag = "";
            // 
            // ID_CEJ_BAN_LBL
            // 
            this.ID_CEJ_BAN_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_BAN_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_BAN_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_BAN_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_BAN_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEJ_BAN_LBL.Location = new System.Drawing.Point(62, 16);
            this.ID_CEJ_BAN_LBL.Name = "ID_CEJ_BAN_LBL";
            this.ID_CEJ_BAN_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_BAN_LBL.Size = new System.Drawing.Size(118, 24);
            this.ID_CEJ_BAN_LBL.TabIndex = 8;
            this.ID_CEJ_BAN_LBL.Tag = "";
            this.ID_CEJ_BAN_LBL.Text = "Banamex";
            // 
            // ID_CEJ_COR_PIC
            // 
            this.ID_CEJ_COR_PIC.BackColor = System.Drawing.Color.Gray;
            this.ID_CEJ_COR_PIC.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_COR_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_COR_PIC.Image = ((System.Drawing.Image)(resources.GetObject("ID_CEJ_COR_PIC.Image")));
            this.ID_CEJ_COR_PIC.Location = new System.Drawing.Point(456, 9);
            this.ID_CEJ_COR_PIC.Name = "ID_CEJ_COR_PIC";
            this.ID_CEJ_COR_PIC.Size = new System.Drawing.Size(131, 31);
            this.ID_CEJ_COR_PIC.TabIndex = 4;
            this.ID_CEJ_COR_PIC.TabStop = false;
            this.ID_CEJ_COR_PIC.Tag = "";
            this.ID_CEJ_COR_PIC.Visible = false;
            // 
            // ID_CEJ_LOG_IMG
            // 
            this.ID_CEJ_LOG_IMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_LOG_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_CEJ_LOG_IMG.Image")));
            this.ID_CEJ_LOG_IMG.Location = new System.Drawing.Point(11, 4);
            this.ID_CEJ_LOG_IMG.Name = "ID_CEJ_LOG_IMG";
            this.ID_CEJ_LOG_IMG.Size = new System.Drawing.Size(45, 45);
            this.ID_CEJ_LOG_IMG.TabIndex = 9;
            this.ID_CEJ_LOG_IMG.TabStop = false;
            this.ID_CEJ_LOG_IMG.Tag = "";
            // 
            // _ID_DAT_CUE_TXT_0
            // 
            this._ID_DAT_CUE_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_DAT_CUE_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_DAT_CUE_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_DAT_CUE_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_DAT_CUE_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_DAT_CUE_TXT_0.Location = new System.Drawing.Point(207, 19);
            this._ID_DAT_CUE_TXT_0.Name = "_ID_DAT_CUE_TXT_0";
            this._ID_DAT_CUE_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_DAT_CUE_TXT_0.Size = new System.Drawing.Size(47, 15);
            this._ID_DAT_CUE_TXT_0.TabIndex = 5;
            this._ID_DAT_CUE_TXT_0.Tag = "";
            this._ID_DAT_CUE_TXT_0.Text = "Cuenta:";
            // 
            // ID_CEJ_MSG_TXT
            // 
            this.ID_CEJ_MSG_TXT.AcceptsReturn = true;
            this.ID_CEJ_MSG_TXT.BackColor = System.Drawing.Color.White;
            this.ID_CEJ_MSG_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_CEJ_MSG_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_MSG_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEJ_MSG_TXT.Location = new System.Drawing.Point(74, 336);
            this.ID_CEJ_MSG_TXT.MaxLength = 170;
            this.ID_CEJ_MSG_TXT.Name = "ID_CEJ_MSG_TXT";
            this.ID_CEJ_MSG_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_MSG_TXT.Size = new System.Drawing.Size(527, 20);
            this.ID_CEJ_MSG_TXT.TabIndex = 3;
            this.ID_CEJ_MSG_TXT.Tag = "";
            // 
            // ID_CEJ_SAL_PB
            // 
            this.ID_CEJ_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEJ_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_CEJ_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_SAL_PB.Location = new System.Drawing.Point(314, 362);
            this.ID_CEJ_SAL_PB.Name = "ID_CEJ_SAL_PB";
            this.ID_CEJ_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_SAL_PB.Size = new System.Drawing.Size(78, 25);
            this.ID_CEJ_SAL_PB.TabIndex = 1;
            this.ID_CEJ_SAL_PB.Tag = "";
            this.ID_CEJ_SAL_PB.Text = "&Salir";
            this.ID_CEJ_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_CEJ_SAL_PB.Click += new System.EventHandler(this.ID_CEJ_SAL_PB_Click);
            // 
            // ID_CEJ_IDE_PNL
            // 
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_CEJ_DI3_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_CEJ_DI2_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_CEJ_CRE_ACU_EB);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_DAT_CRE_ACU_TXT);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_DAT_CRE_TXT);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_CEJ_CP_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_CEJ_DI1_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_CEJ_EMP_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_DAT_FEC_CRE_TXT);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_CEJ_CRE_EB);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_CEJ_FEC_CRE_EB);
            this.ID_CEJ_IDE_PNL.Location = new System.Drawing.Point(10, 58);
            this.ID_CEJ_IDE_PNL.Name = "ID_CEJ_IDE_PNL";
            this.ID_CEJ_IDE_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEJ_IDE_PNL.OcxState")));
            this.ID_CEJ_IDE_PNL.Size = new System.Drawing.Size(313, 149);
            this.ID_CEJ_IDE_PNL.TabIndex = 0;
            this.ID_CEJ_IDE_PNL.Tag = "";
            // 
            // ID_CEJ_DI3_LBL
            // 
            this.ID_CEJ_DI3_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_DI3_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_DI3_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_DI3_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_DI3_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_DI3_LBL.Location = new System.Drawing.Point(11, 63);
            this.ID_CEJ_DI3_LBL.Name = "ID_CEJ_DI3_LBL";
            this.ID_CEJ_DI3_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_DI3_LBL.Size = new System.Drawing.Size(287, 13);
            this.ID_CEJ_DI3_LBL.TabIndex = 16;
            this.ID_CEJ_DI3_LBL.Tag = "";
            // 
            // ID_CEJ_DI2_LBL
            // 
            this.ID_CEJ_DI2_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_DI2_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_DI2_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_DI2_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_DI2_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_DI2_LBL.Location = new System.Drawing.Point(11, 46);
            this.ID_CEJ_DI2_LBL.Name = "ID_CEJ_DI2_LBL";
            this.ID_CEJ_DI2_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_DI2_LBL.Size = new System.Drawing.Size(287, 13);
            this.ID_CEJ_DI2_LBL.TabIndex = 15;
            this.ID_CEJ_DI2_LBL.Tag = "";
            // 
            // ID_CEJ_CRE_ACU_EB
            // 
            this.ID_CEJ_CRE_ACU_EB.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_CRE_ACU_EB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_CRE_ACU_EB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_CRE_ACU_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_CRE_ACU_EB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_CRE_ACU_EB.Location = new System.Drawing.Point(137, 114);
            this.ID_CEJ_CRE_ACU_EB.Name = "ID_CEJ_CRE_ACU_EB";
            this.ID_CEJ_CRE_ACU_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_CRE_ACU_EB.Size = new System.Drawing.Size(148, 13);
            this.ID_CEJ_CRE_ACU_EB.TabIndex = 35;
            this.ID_CEJ_CRE_ACU_EB.Tag = "";
            this.ID_CEJ_CRE_ACU_EB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ID_CEJ_CRE_ACU_EB.Visible = false;
            // 
            // ID_DAT_CRE_ACU_TXT
            // 
            this.ID_DAT_CRE_ACU_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_DAT_CRE_ACU_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_CRE_ACU_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DAT_CRE_ACU_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_CRE_ACU_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_DAT_CRE_ACU_TXT.Location = new System.Drawing.Point(13, 114);
            this.ID_DAT_CRE_ACU_TXT.Name = "ID_DAT_CRE_ACU_TXT";
            this.ID_DAT_CRE_ACU_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DAT_CRE_ACU_TXT.Size = new System.Drawing.Size(117, 12);
            this.ID_DAT_CRE_ACU_TXT.TabIndex = 34;
            this.ID_DAT_CRE_ACU_TXT.Tag = "";
            this.ID_DAT_CRE_ACU_TXT.Text = "Credito Acumulado";
            this.ID_DAT_CRE_ACU_TXT.Visible = false;
            // 
            // ID_DAT_CRE_TXT
            // 
            this.ID_DAT_CRE_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_DAT_CRE_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_CRE_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DAT_CRE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_CRE_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_DAT_CRE_TXT.Location = new System.Drawing.Point(13, 98);
            this.ID_DAT_CRE_TXT.Name = "ID_DAT_CRE_TXT";
            this.ID_DAT_CRE_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DAT_CRE_TXT.Size = new System.Drawing.Size(105, 16);
            this.ID_DAT_CRE_TXT.TabIndex = 11;
            this.ID_DAT_CRE_TXT.Tag = "";
            this.ID_DAT_CRE_TXT.Text = "Crédito Otorgado";
            this.ID_DAT_CRE_TXT.Visible = false;
            // 
            // ID_CEJ_CP_LBL
            // 
            this.ID_CEJ_CP_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_CP_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_CP_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_CP_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_CP_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_CP_LBL.Location = new System.Drawing.Point(11, 80);
            this.ID_CEJ_CP_LBL.Name = "ID_CEJ_CP_LBL";
            this.ID_CEJ_CP_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_CP_LBL.Size = new System.Drawing.Size(287, 13);
            this.ID_CEJ_CP_LBL.TabIndex = 10;
            this.ID_CEJ_CP_LBL.Tag = "";
            // 
            // ID_CEJ_DI1_LBL
            // 
            this.ID_CEJ_DI1_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_DI1_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_DI1_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_DI1_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_DI1_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_DI1_LBL.Location = new System.Drawing.Point(11, 29);
            this.ID_CEJ_DI1_LBL.Name = "ID_CEJ_DI1_LBL";
            this.ID_CEJ_DI1_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_DI1_LBL.Size = new System.Drawing.Size(287, 13);
            this.ID_CEJ_DI1_LBL.TabIndex = 14;
            this.ID_CEJ_DI1_LBL.Tag = "";
            // 
            // ID_CEJ_EMP_LBL
            // 
            this.ID_CEJ_EMP_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_EMP_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_EMP_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_EMP_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_EMP_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_EMP_LBL.Location = new System.Drawing.Point(11, 12);
            this.ID_CEJ_EMP_LBL.Name = "ID_CEJ_EMP_LBL";
            this.ID_CEJ_EMP_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_EMP_LBL.Size = new System.Drawing.Size(287, 13);
            this.ID_CEJ_EMP_LBL.TabIndex = 13;
            this.ID_CEJ_EMP_LBL.Tag = "";
            // 
            // ID_DAT_FEC_CRE_TXT
            // 
            this.ID_DAT_FEC_CRE_TXT.AutoSize = true;
            this.ID_DAT_FEC_CRE_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_DAT_FEC_CRE_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_FEC_CRE_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DAT_FEC_CRE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_FEC_CRE_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_DAT_FEC_CRE_TXT.Location = new System.Drawing.Point(14, 130);
            this.ID_DAT_FEC_CRE_TXT.Name = "ID_DAT_FEC_CRE_TXT";
            this.ID_DAT_FEC_CRE_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DAT_FEC_CRE_TXT.Size = new System.Drawing.Size(141, 13);
            this.ID_DAT_FEC_CRE_TXT.TabIndex = 36;
            this.ID_DAT_FEC_CRE_TXT.Tag = "";
            this.ID_DAT_FEC_CRE_TXT.Text = "Vencimiento del Credito";
            this.ID_DAT_FEC_CRE_TXT.Visible = false;
            // 
            // ID_CEJ_CRE_EB
            // 
            this.ID_CEJ_CRE_EB.AcceptsReturn = true;
            this.ID_CEJ_CRE_EB.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_CRE_EB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ID_CEJ_CRE_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_CEJ_CRE_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_CRE_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEJ_CRE_EB.Location = new System.Drawing.Point(137, 98);
            this.ID_CEJ_CRE_EB.MaxLength = 0;
            this.ID_CEJ_CRE_EB.Multiline = true;
            this.ID_CEJ_CRE_EB.Name = "ID_CEJ_CRE_EB";
            this.ID_CEJ_CRE_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_CRE_EB.Size = new System.Drawing.Size(148, 17);
            this.ID_CEJ_CRE_EB.TabIndex = 9;
            this.ID_CEJ_CRE_EB.Tag = "";
            this.ID_CEJ_CRE_EB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ID_CEJ_CRE_EB.Visible = false;
            // 
            // ID_CEJ_FEC_CRE_EB
            // 
            this.ID_CEJ_FEC_CRE_EB.AutoSize = true;
            this.ID_CEJ_FEC_CRE_EB.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_FEC_CRE_EB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_FEC_CRE_EB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_FEC_CRE_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_FEC_CRE_EB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEJ_FEC_CRE_EB.Location = new System.Drawing.Point(165, 129);
            this.ID_CEJ_FEC_CRE_EB.Name = "ID_CEJ_FEC_CRE_EB";
            this.ID_CEJ_FEC_CRE_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_FEC_CRE_EB.Size = new System.Drawing.Size(0, 13);
            this.ID_CEJ_FEC_CRE_EB.TabIndex = 37;
            this.ID_CEJ_FEC_CRE_EB.Tag = "";
            this.ID_CEJ_FEC_CRE_EB.Visible = false;
            // 
            // ID_CEJ_SAL_PNL
            // 
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_RES_TXT_0);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_RES_TXT_1);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_ETI_TXT_0);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_ETI_TXT_2);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_ETI_TXT_1);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_RES_TXT_2);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_RES_TXT_6);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_RES_TXT_7);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_RES_TXT_5);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_RES_TXT_3);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_RES_TXT_4);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_ETI_TXT_6);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_ETI_TXT_7);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_ETI_TXT_5);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_ETI_TXT_3);
            this.ID_CEJ_SAL_PNL.Controls.Add(this._ID_CEJ_ETI_TXT_4);
            this.ID_CEJ_SAL_PNL.Location = new System.Drawing.Point(324, 58);
            this.ID_CEJ_SAL_PNL.Name = "ID_CEJ_SAL_PNL";
            this.ID_CEJ_SAL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEJ_SAL_PNL.OcxState")));
            this.ID_CEJ_SAL_PNL.Size = new System.Drawing.Size(279, 148);
            this.ID_CEJ_SAL_PNL.TabIndex = 12;
            this.ID_CEJ_SAL_PNL.Tag = "";
            // 
            // _ID_CEJ_RES_TXT_0
            // 
            this._ID_CEJ_RES_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_RES_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_RES_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_RES_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_RES_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_RES_TXT_0.Location = new System.Drawing.Point(135, 13);
            this._ID_CEJ_RES_TXT_0.Name = "_ID_CEJ_RES_TXT_0";
            this._ID_CEJ_RES_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_RES_TXT_0.Size = new System.Drawing.Size(120, 16);
            this._ID_CEJ_RES_TXT_0.TabIndex = 24;
            this._ID_CEJ_RES_TXT_0.Tag = "";
            this._ID_CEJ_RES_TXT_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CEJ_RES_TXT_1
            // 
            this._ID_CEJ_RES_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_RES_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_RES_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_RES_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_RES_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_RES_TXT_1.Location = new System.Drawing.Point(135, 27);
            this._ID_CEJ_RES_TXT_1.Name = "_ID_CEJ_RES_TXT_1";
            this._ID_CEJ_RES_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_RES_TXT_1.Size = new System.Drawing.Size(120, 16);
            this._ID_CEJ_RES_TXT_1.TabIndex = 23;
            this._ID_CEJ_RES_TXT_1.Tag = "";
            this._ID_CEJ_RES_TXT_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CEJ_ETI_TXT_0
            // 
            this._ID_CEJ_ETI_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_ETI_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_ETI_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_ETI_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_ETI_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_ETI_TXT_0.Location = new System.Drawing.Point(12, 14);
            this._ID_CEJ_ETI_TXT_0.Name = "_ID_CEJ_ETI_TXT_0";
            this._ID_CEJ_ETI_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_ETI_TXT_0.Size = new System.Drawing.Size(119, 16);
            this._ID_CEJ_ETI_TXT_0.TabIndex = 25;
            this._ID_CEJ_ETI_TXT_0.Tag = "";
            this._ID_CEJ_ETI_TXT_0.Text = "Saldo Anterior";
            // 
            // _ID_CEJ_ETI_TXT_2
            // 
            this._ID_CEJ_ETI_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_ETI_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_ETI_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_ETI_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_ETI_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_ETI_TXT_2.Location = new System.Drawing.Point(13, 42);
            this._ID_CEJ_ETI_TXT_2.Name = "_ID_CEJ_ETI_TXT_2";
            this._ID_CEJ_ETI_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_ETI_TXT_2.Size = new System.Drawing.Size(119, 16);
            this._ID_CEJ_ETI_TXT_2.TabIndex = 27;
            this._ID_CEJ_ETI_TXT_2.Tag = "";
            this._ID_CEJ_ETI_TXT_2.Text = "   + Disp. en Efectivo";
            // 
            // _ID_CEJ_ETI_TXT_1
            // 
            this._ID_CEJ_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_ETI_TXT_1.Location = new System.Drawing.Point(13, 28);
            this._ID_CEJ_ETI_TXT_1.Name = "_ID_CEJ_ETI_TXT_1";
            this._ID_CEJ_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_ETI_TXT_1.Size = new System.Drawing.Size(119, 16);
            this._ID_CEJ_ETI_TXT_1.TabIndex = 26;
            this._ID_CEJ_ETI_TXT_1.Tag = "";
            this._ID_CEJ_ETI_TXT_1.Text = "   + Consumos";
            // 
            // _ID_CEJ_RES_TXT_2
            // 
            this._ID_CEJ_RES_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_RES_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_RES_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_RES_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_RES_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_RES_TXT_2.Location = new System.Drawing.Point(135, 41);
            this._ID_CEJ_RES_TXT_2.Name = "_ID_CEJ_RES_TXT_2";
            this._ID_CEJ_RES_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_RES_TXT_2.Size = new System.Drawing.Size(120, 16);
            this._ID_CEJ_RES_TXT_2.TabIndex = 22;
            this._ID_CEJ_RES_TXT_2.Tag = "";
            this._ID_CEJ_RES_TXT_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CEJ_RES_TXT_6
            // 
            this._ID_CEJ_RES_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_RES_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_RES_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_RES_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_RES_TXT_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_RES_TXT_6.Location = new System.Drawing.Point(135, 97);
            this._ID_CEJ_RES_TXT_6.Name = "_ID_CEJ_RES_TXT_6";
            this._ID_CEJ_RES_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_RES_TXT_6.Size = new System.Drawing.Size(120, 16);
            this._ID_CEJ_RES_TXT_6.TabIndex = 18;
            this._ID_CEJ_RES_TXT_6.Tag = "";
            this._ID_CEJ_RES_TXT_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CEJ_RES_TXT_7
            // 
            this._ID_CEJ_RES_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_RES_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_RES_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_RES_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_RES_TXT_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_RES_TXT_7.Location = new System.Drawing.Point(135, 111);
            this._ID_CEJ_RES_TXT_7.Name = "_ID_CEJ_RES_TXT_7";
            this._ID_CEJ_RES_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_RES_TXT_7.Size = new System.Drawing.Size(120, 16);
            this._ID_CEJ_RES_TXT_7.TabIndex = 17;
            this._ID_CEJ_RES_TXT_7.Tag = "";
            this._ID_CEJ_RES_TXT_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CEJ_RES_TXT_5
            // 
            this._ID_CEJ_RES_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_RES_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_RES_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_RES_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_RES_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_RES_TXT_5.Location = new System.Drawing.Point(135, 83);
            this._ID_CEJ_RES_TXT_5.Name = "_ID_CEJ_RES_TXT_5";
            this._ID_CEJ_RES_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_RES_TXT_5.Size = new System.Drawing.Size(120, 16);
            this._ID_CEJ_RES_TXT_5.TabIndex = 19;
            this._ID_CEJ_RES_TXT_5.Tag = "";
            this._ID_CEJ_RES_TXT_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CEJ_RES_TXT_3
            // 
            this._ID_CEJ_RES_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_RES_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_RES_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_RES_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_RES_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_RES_TXT_3.Location = new System.Drawing.Point(135, 55);
            this._ID_CEJ_RES_TXT_3.Name = "_ID_CEJ_RES_TXT_3";
            this._ID_CEJ_RES_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_RES_TXT_3.Size = new System.Drawing.Size(120, 16);
            this._ID_CEJ_RES_TXT_3.TabIndex = 21;
            this._ID_CEJ_RES_TXT_3.Tag = "";
            this._ID_CEJ_RES_TXT_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CEJ_RES_TXT_4
            // 
            this._ID_CEJ_RES_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_RES_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_RES_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_RES_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_RES_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_RES_TXT_4.Location = new System.Drawing.Point(135, 69);
            this._ID_CEJ_RES_TXT_4.Name = "_ID_CEJ_RES_TXT_4";
            this._ID_CEJ_RES_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_RES_TXT_4.Size = new System.Drawing.Size(120, 16);
            this._ID_CEJ_RES_TXT_4.TabIndex = 20;
            this._ID_CEJ_RES_TXT_4.Tag = "";
            this._ID_CEJ_RES_TXT_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_CEJ_ETI_TXT_6
            // 
            this._ID_CEJ_ETI_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_ETI_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_ETI_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_ETI_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_ETI_TXT_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_ETI_TXT_6.Location = new System.Drawing.Point(14, 98);
            this._ID_CEJ_ETI_TXT_6.Name = "_ID_CEJ_ETI_TXT_6";
            this._ID_CEJ_ETI_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_ETI_TXT_6.Size = new System.Drawing.Size(119, 15);
            this._ID_CEJ_ETI_TXT_6.TabIndex = 32;
            this._ID_CEJ_ETI_TXT_6.Tag = "";
            this._ID_CEJ_ETI_TXT_6.Text = "   + I.V.A.";
            // 
            // _ID_CEJ_ETI_TXT_7
            // 
            this._ID_CEJ_ETI_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_ETI_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_ETI_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_ETI_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_ETI_TXT_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_ETI_TXT_7.Location = new System.Drawing.Point(12, 111);
            this._ID_CEJ_ETI_TXT_7.Name = "_ID_CEJ_ETI_TXT_7";
            this._ID_CEJ_ETI_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_ETI_TXT_7.Size = new System.Drawing.Size(119, 16);
            this._ID_CEJ_ETI_TXT_7.TabIndex = 33;
            this._ID_CEJ_ETI_TXT_7.Tag = "";
            this._ID_CEJ_ETI_TXT_7.Text = "= Saldo Nuevo";
            // 
            // _ID_CEJ_ETI_TXT_5
            // 
            this._ID_CEJ_ETI_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_ETI_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_ETI_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_ETI_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_ETI_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_ETI_TXT_5.Location = new System.Drawing.Point(14, 84);
            this._ID_CEJ_ETI_TXT_5.Name = "_ID_CEJ_ETI_TXT_5";
            this._ID_CEJ_ETI_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_ETI_TXT_5.Size = new System.Drawing.Size(119, 16);
            this._ID_CEJ_ETI_TXT_5.TabIndex = 31;
            this._ID_CEJ_ETI_TXT_5.Tag = "";
            this._ID_CEJ_ETI_TXT_5.Text = "   - Rendimientos";
            // 
            // _ID_CEJ_ETI_TXT_3
            // 
            this._ID_CEJ_ETI_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_ETI_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_ETI_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_ETI_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_ETI_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_ETI_TXT_3.Location = new System.Drawing.Point(13, 56);
            this._ID_CEJ_ETI_TXT_3.Name = "_ID_CEJ_ETI_TXT_3";
            this._ID_CEJ_ETI_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_ETI_TXT_3.Size = new System.Drawing.Size(119, 16);
            this._ID_CEJ_ETI_TXT_3.TabIndex = 28;
            this._ID_CEJ_ETI_TXT_3.Tag = "";
            this._ID_CEJ_ETI_TXT_3.Text = "   - Pagos";
            // 
            // _ID_CEJ_ETI_TXT_4
            // 
            this._ID_CEJ_ETI_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_CEJ_ETI_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_CEJ_ETI_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEJ_ETI_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEJ_ETI_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEJ_ETI_TXT_4.Location = new System.Drawing.Point(13, 70);
            this._ID_CEJ_ETI_TXT_4.Name = "_ID_CEJ_ETI_TXT_4";
            this._ID_CEJ_ETI_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_CEJ_ETI_TXT_4.Size = new System.Drawing.Size(119, 16);
            this._ID_CEJ_ETI_TXT_4.TabIndex = 30;
            this._ID_CEJ_ETI_TXT_4.Tag = "";
            this._ID_CEJ_ETI_TXT_4.Text = "   + Comisiones";
            // 
            // ID_REJ_ARC_CDG
            // 
            this.ID_REJ_ARC_CDG.Enabled = true;
            this.ID_REJ_ARC_CDG.Location = new System.Drawing.Point(6, 362);
            this.ID_REJ_ARC_CDG.Name = "ID_REJ_ARC_CDG";
            this.ID_REJ_ARC_CDG.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REJ_ARC_CDG.OcxState")));
            this.ID_REJ_ARC_CDG.Size = new System.Drawing.Size(32, 32);
            this.ID_REJ_ARC_CDG.TabIndex = 39;
            this.ID_REJ_ARC_CDG.Tag = "";
            // 
            // ID_CEJ_LEY_LB
            // 
            this.ID_CEJ_LEY_LB.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_LEY_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_LEY_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_LEY_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_LEY_LB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEJ_LEY_LB.Location = new System.Drawing.Point(14, 338);
            this.ID_CEJ_LEY_LB.Name = "ID_CEJ_LEY_LB";
            this.ID_CEJ_LEY_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_LEY_LB.Size = new System.Drawing.Size(54, 16);
            this.ID_CEJ_LEY_LB.TabIndex = 2;
            this.ID_CEJ_LEY_LB.Tag = "";
            this.ID_CEJ_LEY_LB.Text = "Leyenda";
            // 
            // fpsID_CEJ_REP_SS
            // 
            this.fpsID_CEJ_REP_SS.AccessibleDescription = "";
            this.fpsID_CEJ_REP_SS.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsID_CEJ_REP_SS.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsID_CEJ_REP_SS.HorizontalScrollBar.Name = "";
            this.fpsID_CEJ_REP_SS.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsID_CEJ_REP_SS.HorizontalScrollBar.TabIndex = 4;
            this.fpsID_CEJ_REP_SS.Location = new System.Drawing.Point(9, 215);
            this.fpsID_CEJ_REP_SS.Name = "fpsID_CEJ_REP_SS";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            textCellType2.MaxLength = 60;
            namedStyle3.CellType = textCellType2;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = textCellType2;
            textCellType3.MaxLength = 60;
            namedStyle4.CellType = textCellType3;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = textCellType3;
            this.fpsID_CEJ_REP_SS.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.fpsID_CEJ_REP_SS.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsID_CEJ_REP_SS_Sheet1});
            this.fpsID_CEJ_REP_SS.Size = new System.Drawing.Size(592, 113);
            this.fpsID_CEJ_REP_SS.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsID_CEJ_REP_SS.TabIndex = 40;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsID_CEJ_REP_SS.TextTipAppearance = tipAppearance1;
            this.fpsID_CEJ_REP_SS.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsID_CEJ_REP_SS.VerticalScrollBar.Name = "";
            this.fpsID_CEJ_REP_SS.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsID_CEJ_REP_SS.VerticalScrollBar.TabIndex = 5;
            this.fpsID_CEJ_REP_SS.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpsID_CEJ_REP_SS.SetViewportLeftColumn(0, 0, 2);
            this.fpsID_CEJ_REP_SS.SetActiveViewport(0, 0, -1);
            // 
            // fpsID_CEJ_REP_SS_Sheet1
            // 
            this.fpsID_CEJ_REP_SS_Sheet1.Reset();
            this.fpsID_CEJ_REP_SS_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsID_CEJ_REP_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnCount = 12;
            this.fpsID_CEJ_REP_SS_Sheet1.RowCount = 5;
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_REP_SS_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(3).StyleName = "Text704635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(4).StyleName = "Text753635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(5).StyleName = "Text704635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(6).StyleName = "Text704635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(7).StyleName = "Text704635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(8).StyleName = "Text704635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(9).StyleName = "Text704635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(10).StyleName = "Text704635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.Columns.Get(11).StyleName = "Text704635410404728399451";
            this.fpsID_CEJ_REP_SS_Sheet1.DefaultStyleName = "Text338635410404728379449";
            this.fpsID_CEJ_REP_SS_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_REP_SS_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsID_CEJ_REP_SS_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_REP_SS_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsID_CEJ_REP_SS_Sheet1.FrozenColumnCount = 2;
            this.fpsID_CEJ_REP_SS_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpsID_CEJ_REP_SS_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsID_CEJ_REP_SS_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CEJ_REP_SS_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CEJ_REP_SS_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_REP_SS_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsID_CEJ_REP_SS_Sheet1.RowHeader.Visible = false;
            this.fpsID_CEJ_REP_SS_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CEJ_REP_SS_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CEJ_REP_SS_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_REP_SS_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsID_CEJ_REP_SS_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpsID_CEJ_REP_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // CORRPCEJ
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.ID_CEJ_SAL_PB;
            this.ClientSize = new System.Drawing.Size(610, 390);
            this.Controls.Add(this.fpsID_CEJ_REP_SS);
            this.Controls.Add(this.ID_CEJ_TIT_PNL);
            this.Controls.Add(this.ID_CEJ_IMP_PB);
            this.Controls.Add(this.ID_CEJ_SAL_PNL);
            this.Controls.Add(this.ID_REJ_ARC_CDG);
            this.Controls.Add(this.ID_CEJ_LEY_LB);
            this.Controls.Add(this.ID_CEJ_MSG_TXT);
            this.Controls.Add(this.ID_CEJ_SAL_PB);
            this.Controls.Add(this.ID_CEJ_IDE_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(97, 107);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORRPCEJ";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Concentrado Empresa/Ejecutivo";
            this.Activated += new System.EventHandler(this.CORRPCEJ_Activated);
            this.Closed += new System.EventHandler(this.CORRPCEJ_Closed);
            this.Deactivate += new System.EventHandler(this.CORRPCEJ_Deactivate);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORRPCEJ_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_TIT_PNL)).EndInit();
            this.ID_CEJ_TIT_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_COR_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_LOG_IMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_IDE_PNL)).EndInit();
            this.ID_CEJ_IDE_PNL.ResumeLayout(false);
            this.ID_CEJ_IDE_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_SAL_PNL)).EndInit();
            this.ID_CEJ_SAL_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_REJ_ARC_CDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CEJ_REP_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CEJ_REP_SS_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
	void  InitializeID_CEJ_ETI_TXT()
	{
			this.ID_CEJ_ETI_TXT[7] = _ID_CEJ_ETI_TXT_7;
			this.ID_CEJ_ETI_TXT[6] = _ID_CEJ_ETI_TXT_6;
			this.ID_CEJ_ETI_TXT[5] = _ID_CEJ_ETI_TXT_5;
			this.ID_CEJ_ETI_TXT[4] = _ID_CEJ_ETI_TXT_4;
			this.ID_CEJ_ETI_TXT[3] = _ID_CEJ_ETI_TXT_3;
			this.ID_CEJ_ETI_TXT[2] = _ID_CEJ_ETI_TXT_2;
			this.ID_CEJ_ETI_TXT[1] = _ID_CEJ_ETI_TXT_1;
			this.ID_CEJ_ETI_TXT[0] = _ID_CEJ_ETI_TXT_0;
	}
	void  InitializeID_DAT_CUE_TXT()
	{
			this.ID_DAT_CUE_TXT[0] = _ID_DAT_CUE_TXT_0;
	}
	void  InitializeID_DAT_NUM_TXT()
	{
			this.ID_DAT_NUM_TXT[0] = _ID_DAT_NUM_TXT_0;
	}
	void  InitializeID_CEJ_RES_TXT()
	{
			this.ID_CEJ_RES_TXT[0] = _ID_CEJ_RES_TXT_0;
			this.ID_CEJ_RES_TXT[1] = _ID_CEJ_RES_TXT_1;
			this.ID_CEJ_RES_TXT[2] = _ID_CEJ_RES_TXT_2;
			this.ID_CEJ_RES_TXT[3] = _ID_CEJ_RES_TXT_3;
			this.ID_CEJ_RES_TXT[4] = _ID_CEJ_RES_TXT_4;
			this.ID_CEJ_RES_TXT[5] = _ID_CEJ_RES_TXT_5;
			this.ID_CEJ_RES_TXT[6] = _ID_CEJ_RES_TXT_6;
			this.ID_CEJ_RES_TXT[7] = _ID_CEJ_RES_TXT_7;
	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpsID_CEJ_REP_SS;
    private FarPoint.Win.Spread.SheetView fpsID_CEJ_REP_SS_Sheet1;
    public Softtek.Util.Win.Spread.SpreadWrapper ID_CEJ_REP_SS;
}
}