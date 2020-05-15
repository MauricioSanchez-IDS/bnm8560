using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORDEPUR
	{
	
#region "Upgrade Support "
		private static CORDEPUR m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORDEPUR DefInstance
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
		public CORDEPUR():base(){
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
			InitializeHelp();
			InitializeID_DEP_EST_TXT();
			InitializeID_DEP_ARC_OPB();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORDEPUR CreateInstance()
	{
			CORDEPUR theInstance = new CORDEPUR();
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
	public  System.Windows.Forms.PictureBox ID_DEP_LOG_PIC;
	public  System.Windows.Forms.Button ID_DEP_ACE_PB;
	public  System.Windows.Forms.Button ID_DEP_SAL_PB;
	public  System.Windows.Forms.Button ID_DEP_IMP_PB;
	public  System.Windows.Forms.Button ID_DEP_CAN_PB;
	private  AxThreed.AxSSOption _ID_DEP_ARC_OPB_3;
	private  AxThreed.AxSSOption _ID_DEP_ARC_OPB_2;
	private  AxThreed.AxSSOption _ID_DEP_ARC_OPB_1;
	private  AxThreed.AxSSOption _ID_DEP_ARC_OPB_0;
	public  AxThreed.AxSSFrame ID_DEP_PRI_FRM;
	public  AxThreed.AxSSPanel ID_DEP_PORC_PNL;
	public  System.Windows.Forms.ComboBox ID_DEP_DIG_COB;
	public  System.Windows.Forms.ComboBox ID_DEP_EJE_COB;
	public  System.Windows.Forms.ComboBox ID_DEP_DUP_COB;
	public  System.Windows.Forms.ComboBox ID_DEP_THS_COB;
	private  System.Windows.Forms.Label _ID_DEP_EST_TXT_0;
	private  System.Windows.Forms.Label _ID_DEP_EST_TXT_1;
	private  System.Windows.Forms.Label _ID_DEP_EST_TXT_2;
	private  System.Windows.Forms.Label _ID_DEP_EST_TXT_3;
	private  System.Windows.Forms.Label _ID_DEP_EST_TXT_4;
	private  System.Windows.Forms.Label _ID_DEP_EST_TXT_5;
	private  System.Windows.Forms.Label _ID_DEP_EST_TXT_6;
	private  System.Windows.Forms.Label _ID_DEP_EST_TXT_7;
	public  AxThreed.AxSSFrame ID_DEP_EST_PNL;
	public  System.Windows.Forms.Label ID_DEP_BAN_LBL;
	public  System.Windows.Forms.PictureBox ID_DEP_LOG_IMG;
	public  AxThreed.AxSSPanel ID_DEP_PRI_PNL;
	public AxThreed.AxSSOption[] ID_DEP_ARC_OPB = new AxThreed.AxSSOption[4];
	public System.Windows.Forms.Label[] ID_DEP_EST_TXT = new System.Windows.Forms.Label[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORDEPUR));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_DEP_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_DEP_CAN_PB = new System.Windows.Forms.Button();
        this.ID_DEP_PRI_FRM = new AxThreed.AxSSFrame();
        this._ID_DEP_ARC_OPB_2 = new AxThreed.AxSSOption();
        this._ID_DEP_ARC_OPB_3 = new AxThreed.AxSSOption();
        this._ID_DEP_ARC_OPB_0 = new AxThreed.AxSSOption();
        this._ID_DEP_ARC_OPB_1 = new AxThreed.AxSSOption();
        this.ID_DEP_SAL_PB = new System.Windows.Forms.Button();
        this.ID_DEP_IMP_PB = new System.Windows.Forms.Button();
        this.ID_DEP_BAN_LBL = new System.Windows.Forms.Label();
        this.ID_DEP_LOG_IMG = new System.Windows.Forms.PictureBox();
        this.ID_DEP_PORC_PNL = new AxThreed.AxSSPanel();
        this.ID_DEP_EST_PNL = new AxThreed.AxSSFrame();
        this._ID_DEP_EST_TXT_1 = new System.Windows.Forms.Label();
        this._ID_DEP_EST_TXT_2 = new System.Windows.Forms.Label();
        this.ID_DEP_THS_COB = new System.Windows.Forms.ComboBox();
        this._ID_DEP_EST_TXT_0 = new System.Windows.Forms.Label();
        this._ID_DEP_EST_TXT_3 = new System.Windows.Forms.Label();
        this._ID_DEP_EST_TXT_6 = new System.Windows.Forms.Label();
        this._ID_DEP_EST_TXT_7 = new System.Windows.Forms.Label();
        this._ID_DEP_EST_TXT_4 = new System.Windows.Forms.Label();
        this._ID_DEP_EST_TXT_5 = new System.Windows.Forms.Label();
        this.ID_DEP_DIG_COB = new System.Windows.Forms.ComboBox();
        this.ID_DEP_EJE_COB = new System.Windows.Forms.ComboBox();
        this.ID_DEP_DUP_COB = new System.Windows.Forms.ComboBox();
        this.ID_DEP_LOG_PIC = new System.Windows.Forms.PictureBox();
        this.ID_DEP_ACE_PB = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_PRI_PNL)).BeginInit();
        this.ID_DEP_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_PRI_FRM)).BeginInit();
        this.ID_DEP_PRI_FRM.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DEP_ARC_OPB_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DEP_ARC_OPB_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DEP_ARC_OPB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DEP_ARC_OPB_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_LOG_IMG)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_PORC_PNL)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_EST_PNL)).BeginInit();
        this.ID_DEP_EST_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_LOG_PIC)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_DEP_PRI_PNL
        // 
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_CAN_PB);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_PRI_FRM);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_SAL_PB);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_IMP_PB);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_BAN_LBL);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_LOG_IMG);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_PORC_PNL);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_EST_PNL);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_LOG_PIC);
        this.ID_DEP_PRI_PNL.Controls.Add(this.ID_DEP_ACE_PB);
        this.ID_DEP_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_DEP_PRI_PNL.Name = "ID_DEP_PRI_PNL";
        this.ID_DEP_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DEP_PRI_PNL.OcxState")));
        this.ID_DEP_PRI_PNL.Size = new System.Drawing.Size(475, 334);
        this.ID_DEP_PRI_PNL.TabIndex = 0;
        this.ID_DEP_PRI_PNL.Tag = "";
        // 
        // ID_DEP_CAN_PB
        // 
        this.ID_DEP_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DEP_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DEP_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DEP_CAN_PB.Location = new System.Drawing.Point(210, 299);
        this.ID_DEP_CAN_PB.Name = "ID_DEP_CAN_PB";
        this.ID_DEP_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_CAN_PB.Size = new System.Drawing.Size(73, 23);
        this.ID_DEP_CAN_PB.TabIndex = 10;
        this.ID_DEP_CAN_PB.Tag = "";
        this.ID_DEP_CAN_PB.Text = "Cancelar";
        this.ID_DEP_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_DEP_CAN_PB.Visible = false;
        this.ID_DEP_CAN_PB.Click += new System.EventHandler(this.ID_DEP_CAN_PB_Click);
        // 
        // ID_DEP_PRI_FRM
        // 
        this.ID_DEP_PRI_FRM.Controls.Add(this._ID_DEP_ARC_OPB_2);
        this.ID_DEP_PRI_FRM.Controls.Add(this._ID_DEP_ARC_OPB_3);
        this.ID_DEP_PRI_FRM.Controls.Add(this._ID_DEP_ARC_OPB_0);
        this.ID_DEP_PRI_FRM.Controls.Add(this._ID_DEP_ARC_OPB_1);
        this.ID_DEP_PRI_FRM.Location = new System.Drawing.Point(28, 46);
        this.ID_DEP_PRI_FRM.Name = "ID_DEP_PRI_FRM";
        this.ID_DEP_PRI_FRM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DEP_PRI_FRM.OcxState")));
        this.ID_DEP_PRI_FRM.Size = new System.Drawing.Size(421, 98);
        this.ID_DEP_PRI_FRM.TabIndex = 11;
        this.ID_DEP_PRI_FRM.Tag = "";
        // 
        // _ID_DEP_ARC_OPB_2
        // 
        this._ID_DEP_ARC_OPB_2.Location = new System.Drawing.Point(132, 73);
        this._ID_DEP_ARC_OPB_2.Name = "_ID_DEP_ARC_OPB_2";
        this._ID_DEP_ARC_OPB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_DEP_ARC_OPB_2.OcxState")));
        this._ID_DEP_ARC_OPB_2.Size = new System.Drawing.Size(153, 20);
        this._ID_DEP_ARC_OPB_2.TabIndex = 14;
        this._ID_DEP_ARC_OPB_2.Tag = "";
        this._ID_DEP_ARC_OPB_2.ClickEvent += new AxThreed.ISSRBCtrlEvents_ClickEventHandler(this.ID_DEP_ARC_OPB_ClickEvent);
        // 
        // _ID_DEP_ARC_OPB_3
        // 
        this._ID_DEP_ARC_OPB_3.Location = new System.Drawing.Point(132, 15);
        this._ID_DEP_ARC_OPB_3.Name = "_ID_DEP_ARC_OPB_3";
        this._ID_DEP_ARC_OPB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_DEP_ARC_OPB_3.OcxState")));
        this._ID_DEP_ARC_OPB_3.Size = new System.Drawing.Size(208, 20);
        this._ID_DEP_ARC_OPB_3.TabIndex = 15;
        this._ID_DEP_ARC_OPB_3.Tag = "";
        this._ID_DEP_ARC_OPB_3.ClickEvent += new AxThreed.ISSRBCtrlEvents_ClickEventHandler(this.ID_DEP_ARC_OPB_ClickEvent);
        // 
        // _ID_DEP_ARC_OPB_0
        // 
        this._ID_DEP_ARC_OPB_0.Location = new System.Drawing.Point(132, 34);
        this._ID_DEP_ARC_OPB_0.Name = "_ID_DEP_ARC_OPB_0";
        this._ID_DEP_ARC_OPB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_DEP_ARC_OPB_0.OcxState")));
        this._ID_DEP_ARC_OPB_0.Size = new System.Drawing.Size(205, 20);
        this._ID_DEP_ARC_OPB_0.TabIndex = 12;
        this._ID_DEP_ARC_OPB_0.Tag = "";
        this._ID_DEP_ARC_OPB_0.ClickEvent += new AxThreed.ISSRBCtrlEvents_ClickEventHandler(this.ID_DEP_ARC_OPB_ClickEvent);
        // 
        // _ID_DEP_ARC_OPB_1
        // 
        this._ID_DEP_ARC_OPB_1.Location = new System.Drawing.Point(132, 53);
        this._ID_DEP_ARC_OPB_1.Name = "_ID_DEP_ARC_OPB_1";
        this._ID_DEP_ARC_OPB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_DEP_ARC_OPB_1.OcxState")));
        this._ID_DEP_ARC_OPB_1.Size = new System.Drawing.Size(180, 20);
        this._ID_DEP_ARC_OPB_1.TabIndex = 13;
        this._ID_DEP_ARC_OPB_1.Tag = "";
        this._ID_DEP_ARC_OPB_1.ClickEvent += new AxThreed.ISSRBCtrlEvents_ClickEventHandler(this.ID_DEP_ARC_OPB_ClickEvent);
        // 
        // ID_DEP_SAL_PB
        // 
        this.ID_DEP_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DEP_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_DEP_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DEP_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DEP_SAL_PB.Location = new System.Drawing.Point(243, 299);
        this.ID_DEP_SAL_PB.Name = "ID_DEP_SAL_PB";
        this.ID_DEP_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_SAL_PB.Size = new System.Drawing.Size(73, 23);
        this.ID_DEP_SAL_PB.TabIndex = 1;
        this.ID_DEP_SAL_PB.Tag = "";
        this.ID_DEP_SAL_PB.Text = "Salir";
        this.ID_DEP_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_DEP_SAL_PB.Click += new System.EventHandler(this.ID_DEP_SAL_PB_Click);
        // 
        // ID_DEP_IMP_PB
        // 
        this.ID_DEP_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DEP_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DEP_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DEP_IMP_PB.Location = new System.Drawing.Point(375, 299);
        this.ID_DEP_IMP_PB.Name = "ID_DEP_IMP_PB";
        this.ID_DEP_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_IMP_PB.Size = new System.Drawing.Size(73, 23);
        this.ID_DEP_IMP_PB.TabIndex = 3;
        this.ID_DEP_IMP_PB.Tag = "";
        this.ID_DEP_IMP_PB.Text = "&Imprimir";
        this.ID_DEP_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_DEP_IMP_PB.Click += new System.EventHandler(this.ID_DEP_IMP_PB_Click);
        // 
        // ID_DEP_BAN_LBL
        // 
        this.ID_DEP_BAN_LBL.BackColor = System.Drawing.Color.Silver;
        this.ID_DEP_BAN_LBL.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_BAN_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DEP_BAN_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_BAN_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_DEP_BAN_LBL.Location = new System.Drawing.Point(70, 17);
        this.ID_DEP_BAN_LBL.Name = "ID_DEP_BAN_LBL";
        this.ID_DEP_BAN_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_BAN_LBL.Size = new System.Drawing.Size(118, 24);
        this.ID_DEP_BAN_LBL.TabIndex = 17;
        this.ID_DEP_BAN_LBL.Tag = "";
        this.ID_DEP_BAN_LBL.Text = "Banamex";
        // 
        // ID_DEP_LOG_IMG
        // 
        this.ID_DEP_LOG_IMG.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_LOG_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_DEP_LOG_IMG.Image")));
        this.ID_DEP_LOG_IMG.Location = new System.Drawing.Point(17, 5);
        this.ID_DEP_LOG_IMG.Name = "ID_DEP_LOG_IMG";
        this.ID_DEP_LOG_IMG.Size = new System.Drawing.Size(45, 45);
        this.ID_DEP_LOG_IMG.TabIndex = 18;
        this.ID_DEP_LOG_IMG.TabStop = false;
        this.ID_DEP_LOG_IMG.Tag = "";
        // 
        // ID_DEP_PORC_PNL
        // 
        this.ID_DEP_PORC_PNL.Location = new System.Drawing.Point(26, 102);
        this.ID_DEP_PORC_PNL.Name = "ID_DEP_PORC_PNL";
        this.ID_DEP_PORC_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DEP_PORC_PNL.OcxState")));
        this.ID_DEP_PORC_PNL.Size = new System.Drawing.Size(425, 35);
        this.ID_DEP_PORC_PNL.TabIndex = 18;
        this.ID_DEP_PORC_PNL.Tag = "";
        // 
        // ID_DEP_EST_PNL
        // 
        this.ID_DEP_EST_PNL.Controls.Add(this._ID_DEP_EST_TXT_1);
        this.ID_DEP_EST_PNL.Controls.Add(this._ID_DEP_EST_TXT_2);
        this.ID_DEP_EST_PNL.Controls.Add(this.ID_DEP_THS_COB);
        this.ID_DEP_EST_PNL.Controls.Add(this._ID_DEP_EST_TXT_0);
        this.ID_DEP_EST_PNL.Controls.Add(this._ID_DEP_EST_TXT_3);
        this.ID_DEP_EST_PNL.Controls.Add(this._ID_DEP_EST_TXT_6);
        this.ID_DEP_EST_PNL.Controls.Add(this._ID_DEP_EST_TXT_7);
        this.ID_DEP_EST_PNL.Controls.Add(this._ID_DEP_EST_TXT_4);
        this.ID_DEP_EST_PNL.Controls.Add(this._ID_DEP_EST_TXT_5);
        this.ID_DEP_EST_PNL.Controls.Add(this.ID_DEP_DIG_COB);
        this.ID_DEP_EST_PNL.Controls.Add(this.ID_DEP_EJE_COB);
        this.ID_DEP_EST_PNL.Controls.Add(this.ID_DEP_DUP_COB);
        this.ID_DEP_EST_PNL.Location = new System.Drawing.Point(28, 144);
        this.ID_DEP_EST_PNL.Name = "ID_DEP_EST_PNL";
        this.ID_DEP_EST_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DEP_EST_PNL.OcxState")));
        this.ID_DEP_EST_PNL.Size = new System.Drawing.Size(421, 140);
        this.ID_DEP_EST_PNL.TabIndex = 19;
        this.ID_DEP_EST_PNL.Tag = "";
        // 
        // _ID_DEP_EST_TXT_1
        // 
        this._ID_DEP_EST_TXT_1.BackColor = System.Drawing.Color.Silver;
        this._ID_DEP_EST_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_DEP_EST_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DEP_EST_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_DEP_EST_TXT_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_DEP_EST_TXT_1.Location = new System.Drawing.Point(9, 42);
        this._ID_DEP_EST_TXT_1.Name = "_ID_DEP_EST_TXT_1";
        this._ID_DEP_EST_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_DEP_EST_TXT_1.Size = new System.Drawing.Size(122, 17);
        this._ID_DEP_EST_TXT_1.TabIndex = 24;
        this._ID_DEP_EST_TXT_1.Tag = "";
        this._ID_DEP_EST_TXT_1.Text = "D&if. en Datos Grales.";
        // 
        // _ID_DEP_EST_TXT_2
        // 
        this._ID_DEP_EST_TXT_2.BackColor = System.Drawing.Color.Silver;
        this._ID_DEP_EST_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_DEP_EST_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DEP_EST_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_DEP_EST_TXT_2.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_DEP_EST_TXT_2.Location = new System.Drawing.Point(10, 64);
        this._ID_DEP_EST_TXT_2.Name = "_ID_DEP_EST_TXT_2";
        this._ID_DEP_EST_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_DEP_EST_TXT_2.Size = new System.Drawing.Size(120, 17);
        this._ID_DEP_EST_TXT_2.TabIndex = 23;
        this._ID_DEP_EST_TXT_2.Tag = "";
        this._ID_DEP_EST_TXT_2.Text = "Sobran en Ejecs.";
        // 
        // ID_DEP_THS_COB
        // 
        this.ID_DEP_THS_COB.BackColor = System.Drawing.Color.White;
        this.ID_DEP_THS_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_THS_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_DEP_THS_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_THS_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_DEP_THS_COB.Location = new System.Drawing.Point(146, 84);
        this.ID_DEP_THS_COB.Name = "ID_DEP_THS_COB";
        this.ID_DEP_THS_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_THS_COB.Size = new System.Drawing.Size(260, 21);
        this.ID_DEP_THS_COB.TabIndex = 7;
        this.ID_DEP_THS_COB.Tag = "";
        // 
        // _ID_DEP_EST_TXT_0
        // 
        this._ID_DEP_EST_TXT_0.BackColor = System.Drawing.Color.Silver;
        this._ID_DEP_EST_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_DEP_EST_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DEP_EST_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_DEP_EST_TXT_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_DEP_EST_TXT_0.Location = new System.Drawing.Point(9, 19);
        this._ID_DEP_EST_TXT_0.Name = "_ID_DEP_EST_TXT_0";
        this._ID_DEP_EST_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_DEP_EST_TXT_0.Size = new System.Drawing.Size(137, 17);
        this._ID_DEP_EST_TXT_0.TabIndex = 25;
        this._ID_DEP_EST_TXT_0.Tag = "";
        this._ID_DEP_EST_TXT_0.Text = "&Diferencia en Roll Over";
        // 
        // _ID_DEP_EST_TXT_3
        // 
        this._ID_DEP_EST_TXT_3.BackColor = System.Drawing.Color.Silver;
        this._ID_DEP_EST_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_DEP_EST_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DEP_EST_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_DEP_EST_TXT_3.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_DEP_EST_TXT_3.Location = new System.Drawing.Point(10, 86);
        this._ID_DEP_EST_TXT_3.Name = "_ID_DEP_EST_TXT_3";
        this._ID_DEP_EST_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_DEP_EST_TXT_3.Size = new System.Drawing.Size(115, 17);
        this._ID_DEP_EST_TXT_3.TabIndex = 22;
        this._ID_DEP_EST_TXT_3.Tag = "";
        this._ID_DEP_EST_TXT_3.Text = "Sobran en THS";
        // 
        // _ID_DEP_EST_TXT_6
        // 
        this._ID_DEP_EST_TXT_6.BackColor = System.Drawing.Color.White;
        this._ID_DEP_EST_TXT_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_DEP_EST_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_DEP_EST_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DEP_EST_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_DEP_EST_TXT_6.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_DEP_EST_TXT_6.Location = new System.Drawing.Point(146, 108);
        this._ID_DEP_EST_TXT_6.Name = "_ID_DEP_EST_TXT_6";
        this._ID_DEP_EST_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_DEP_EST_TXT_6.Size = new System.Drawing.Size(55, 17);
        this._ID_DEP_EST_TXT_6.TabIndex = 8;
        this._ID_DEP_EST_TXT_6.Tag = "";
        this._ID_DEP_EST_TXT_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // _ID_DEP_EST_TXT_7
        // 
        this._ID_DEP_EST_TXT_7.BackColor = System.Drawing.Color.White;
        this._ID_DEP_EST_TXT_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_DEP_EST_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_DEP_EST_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DEP_EST_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_DEP_EST_TXT_7.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_DEP_EST_TXT_7.Location = new System.Drawing.Point(351, 108);
        this._ID_DEP_EST_TXT_7.Name = "_ID_DEP_EST_TXT_7";
        this._ID_DEP_EST_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_DEP_EST_TXT_7.Size = new System.Drawing.Size(55, 17);
        this._ID_DEP_EST_TXT_7.TabIndex = 9;
        this._ID_DEP_EST_TXT_7.Tag = "";
        this._ID_DEP_EST_TXT_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // _ID_DEP_EST_TXT_4
        // 
        this._ID_DEP_EST_TXT_4.BackColor = System.Drawing.Color.Silver;
        this._ID_DEP_EST_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_DEP_EST_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DEP_EST_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_DEP_EST_TXT_4.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_DEP_EST_TXT_4.Location = new System.Drawing.Point(10, 109);
        this._ID_DEP_EST_TXT_4.Name = "_ID_DEP_EST_TXT_4";
        this._ID_DEP_EST_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_DEP_EST_TXT_4.Size = new System.Drawing.Size(95, 17);
        this._ID_DEP_EST_TXT_4.TabIndex = 21;
        this._ID_DEP_EST_TXT_4.Tag = "";
        this._ID_DEP_EST_TXT_4.Text = "# de Ejecutivos";
        // 
        // _ID_DEP_EST_TXT_5
        // 
        this._ID_DEP_EST_TXT_5.BackColor = System.Drawing.Color.Silver;
        this._ID_DEP_EST_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_DEP_EST_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DEP_EST_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_DEP_EST_TXT_5.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_DEP_EST_TXT_5.Location = new System.Drawing.Point(214, 111);
        this._ID_DEP_EST_TXT_5.Name = "_ID_DEP_EST_TXT_5";
        this._ID_DEP_EST_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_DEP_EST_TXT_5.Size = new System.Drawing.Size(110, 17);
        this._ID_DEP_EST_TXT_5.TabIndex = 20;
        this._ID_DEP_EST_TXT_5.Tag = "";
        this._ID_DEP_EST_TXT_5.Text = "# de Ejec. en THS";
        // 
        // ID_DEP_DIG_COB
        // 
        this.ID_DEP_DIG_COB.BackColor = System.Drawing.Color.White;
        this.ID_DEP_DIG_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_DIG_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_DEP_DIG_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_DIG_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_DEP_DIG_COB.Location = new System.Drawing.Point(146, 15);
        this.ID_DEP_DIG_COB.Name = "ID_DEP_DIG_COB";
        this.ID_DEP_DIG_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_DIG_COB.Size = new System.Drawing.Size(260, 21);
        this.ID_DEP_DIG_COB.TabIndex = 4;
        this.ID_DEP_DIG_COB.Tag = "";
        // 
        // ID_DEP_EJE_COB
        // 
        this.ID_DEP_EJE_COB.BackColor = System.Drawing.Color.White;
        this.ID_DEP_EJE_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_EJE_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_DEP_EJE_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_EJE_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_DEP_EJE_COB.Location = new System.Drawing.Point(146, 61);
        this.ID_DEP_EJE_COB.Name = "ID_DEP_EJE_COB";
        this.ID_DEP_EJE_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_EJE_COB.Size = new System.Drawing.Size(260, 21);
        this.ID_DEP_EJE_COB.TabIndex = 6;
        this.ID_DEP_EJE_COB.Tag = "";
        // 
        // ID_DEP_DUP_COB
        // 
        this.ID_DEP_DUP_COB.BackColor = System.Drawing.Color.White;
        this.ID_DEP_DUP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_DUP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_DEP_DUP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_DUP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_DEP_DUP_COB.Location = new System.Drawing.Point(146, 38);
        this.ID_DEP_DUP_COB.Name = "ID_DEP_DUP_COB";
        this.ID_DEP_DUP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_DUP_COB.Size = new System.Drawing.Size(260, 21);
        this.ID_DEP_DUP_COB.TabIndex = 5;
        this.ID_DEP_DUP_COB.Tag = "";
        // 
        // ID_DEP_LOG_PIC
        // 
        this.ID_DEP_LOG_PIC.BackColor = System.Drawing.Color.Gray;
        this.ID_DEP_LOG_PIC.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_LOG_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_LOG_PIC.Image = ((System.Drawing.Image)(resources.GetObject("ID_DEP_LOG_PIC.Image")));
        this.ID_DEP_LOG_PIC.Location = new System.Drawing.Point(268, 9);
        this.ID_DEP_LOG_PIC.Name = "ID_DEP_LOG_PIC";
        this.ID_DEP_LOG_PIC.Size = new System.Drawing.Size(131, 31);
        this.ID_DEP_LOG_PIC.TabIndex = 16;
        this.ID_DEP_LOG_PIC.Tag = "";
        // 
        // ID_DEP_ACE_PB
        // 
        this.ID_DEP_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DEP_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEP_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DEP_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEP_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DEP_ACE_PB.Location = new System.Drawing.Point(167, 299);
        this.ID_DEP_ACE_PB.Name = "ID_DEP_ACE_PB";
        this.ID_DEP_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEP_ACE_PB.Size = new System.Drawing.Size(73, 23);
        this.ID_DEP_ACE_PB.TabIndex = 2;
        this.ID_DEP_ACE_PB.Tag = "";
        this.ID_DEP_ACE_PB.Text = "Aceptar";
        this.ID_DEP_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_DEP_ACE_PB.Click += new System.EventHandler(this.ID_DEP_ACE_PB_Click);
        // 
        // CORDEPUR
        // 
        this.AcceptButton = this.ID_DEP_ACE_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.CancelButton = this.ID_DEP_SAL_PB;
        this.ClientSize = new System.Drawing.Size(474, 333);
        this.Controls.Add(this.ID_DEP_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(176, 167);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORDEPUR";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Depuración";
        this.Closed += new System.EventHandler(this.CORDEPUR_Closed);
        this.Activated += new System.EventHandler(this.CORDEPUR_Activated);
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_PRI_PNL)).EndInit();
        this.ID_DEP_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_PRI_FRM)).EndInit();
        this.ID_DEP_PRI_FRM.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_DEP_ARC_OPB_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DEP_ARC_OPB_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DEP_ARC_OPB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DEP_ARC_OPB_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_LOG_IMG)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_PORC_PNL)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_EST_PNL)).EndInit();
        this.ID_DEP_EST_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEP_LOG_PIC)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_DEP_EST_TXT()
	{
			this.ID_DEP_EST_TXT[0] = _ID_DEP_EST_TXT_0;
			this.ID_DEP_EST_TXT[1] = _ID_DEP_EST_TXT_1;
			this.ID_DEP_EST_TXT[2] = _ID_DEP_EST_TXT_2;
			this.ID_DEP_EST_TXT[3] = _ID_DEP_EST_TXT_3;
			this.ID_DEP_EST_TXT[4] = _ID_DEP_EST_TXT_4;
			this.ID_DEP_EST_TXT[5] = _ID_DEP_EST_TXT_5;
			this.ID_DEP_EST_TXT[6] = _ID_DEP_EST_TXT_6;
			this.ID_DEP_EST_TXT[7] = _ID_DEP_EST_TXT_7;
	}
	void  InitializeID_DEP_ARC_OPB()
	{
			this.ID_DEP_ARC_OPB[3] = _ID_DEP_ARC_OPB_3;
			this.ID_DEP_ARC_OPB[2] = _ID_DEP_ARC_OPB_2;
			this.ID_DEP_ARC_OPB[1] = _ID_DEP_ARC_OPB_1;
			this.ID_DEP_ARC_OPB[0] = _ID_DEP_ARC_OPB_0;
	}
#endregion 
}
}