using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORGRACL
	{
	
#region "Upgrade Support "
		private static CORGRACL m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRACL DefInstance
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
		public CORGRACL():base(){
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
			InitializeID_ACL_ETI_TXT();
			InitializeID_ACL_GRA_GPB();
		}
	public static CORGRACL CreateInstance()
	{
			CORGRACL theInstance = new CORGRACL();
			theInstance.Form_Load();
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
	public  System.Windows.Forms.Button ID_ACL_GRA_PB;
	public  System.Windows.Forms.Button ID_ACL_IMP_PB;
	public  System.Windows.Forms.Button ID_ACL_SAL_PB;
	private  AxThreed.AxSSRibbon _ID_ACL_GRA_GPB_0;
	private  AxThreed.AxSSRibbon _ID_ACL_GRA_GPB_1;
	private  AxThreed.AxSSRibbon _ID_ACL_GRA_GPB_2;
	private  AxThreed.AxSSRibbon _ID_ACL_GRA_GPB_3;
	public  AxThreed.AxSSPanel ID_ACL_GRP_PNL;
	public  AxGraphLib.AxGraph ID_ACL_GPH;
	public  AxThreed.AxSSPanel ID_ACL_PRI1_PNL;
	public  System.Windows.Forms.ComboBox ID_ACL_INF_COB;
	public  System.Windows.Forms.ComboBox ID_ACL_TIP_COB;
	public  AxThreed.AxSSCheck ID_ACL_INF_CKB;
	private  System.Windows.Forms.Label _ID_ACL_ETI_TXT_1;
	private  System.Windows.Forms.Label _ID_ACL_ETI_TXT_2;
	public  System.Windows.Forms.Label ID_ACL_PRI_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_ACL_PRI_PNL;
	public System.Windows.Forms.Label[] ID_ACL_ETI_TXT = new System.Windows.Forms.Label[3];
	public AxThreed.AxSSRibbon[] ID_ACL_GRA_GPB = new AxThreed.AxSSRibbon[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRACL));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_ACL_PRI1_PNL = new AxThreed.AxSSPanel();
        this.ID_ACL_SAL_PB = new System.Windows.Forms.Button();
        this.ID_ACL_IMP_PB = new System.Windows.Forms.Button();
        this.ID_ACL_GRA_PB = new System.Windows.Forms.Button();
        this.ID_ACL_GPH = new AxGraphLib.AxGraph();
        this.ID_ACL_GRP_PNL = new AxThreed.AxSSPanel();
        this._ID_ACL_GRA_GPB_1 = new AxThreed.AxSSRibbon();
        this._ID_ACL_GRA_GPB_0 = new AxThreed.AxSSRibbon();
        this._ID_ACL_GRA_GPB_3 = new AxThreed.AxSSRibbon();
        this._ID_ACL_GRA_GPB_2 = new AxThreed.AxSSRibbon();
        this.ID_ACL_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_ACL_INF_CKB = new AxThreed.AxSSCheck();
        this.ID_ACL_TIP_COB = new System.Windows.Forms.ComboBox();
        this.ID_ACL_INF_COB = new System.Windows.Forms.ComboBox();
        this._ID_ACL_ETI_TXT_1 = new System.Windows.Forms.Label();
        this.ID_ACL_PRI_PNLLabel_Text = new System.Windows.Forms.Label();
        this._ID_ACL_ETI_TXT_2 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_PRI1_PNL)).BeginInit();
        this.ID_ACL_PRI1_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_GPH)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_GRP_PNL)).BeginInit();
        this.ID_ACL_GRP_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_GRA_GPB_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_GRA_GPB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_GRA_GPB_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_GRA_GPB_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_PRI_PNL)).BeginInit();
        this.ID_ACL_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_INF_CKB)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_ACL_PRI1_PNL
        // 
        this.ID_ACL_PRI1_PNL.Controls.Add(this.ID_ACL_SAL_PB);
        this.ID_ACL_PRI1_PNL.Controls.Add(this.ID_ACL_IMP_PB);
        this.ID_ACL_PRI1_PNL.Controls.Add(this.ID_ACL_GRA_PB);
        this.ID_ACL_PRI1_PNL.Controls.Add(this.ID_ACL_GPH);
        this.ID_ACL_PRI1_PNL.Controls.Add(this.ID_ACL_GRP_PNL);
        this.ID_ACL_PRI1_PNL.Location = new System.Drawing.Point(0, 55);
        this.ID_ACL_PRI1_PNL.Name = "ID_ACL_PRI1_PNL";
        this.ID_ACL_PRI1_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_PRI1_PNL.OcxState")));
        this.ID_ACL_PRI1_PNL.Size = new System.Drawing.Size(609, 295);
        this.ID_ACL_PRI1_PNL.TabIndex = 7;
        this.ID_ACL_PRI1_PNL.Tag = "";
        // 
        // ID_ACL_SAL_PB
        // 
        this.ID_ACL_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_SAL_PB.Location = new System.Drawing.Point(519, 259);
        this.ID_ACL_SAL_PB.Name = "ID_ACL_SAL_PB";
        this.ID_ACL_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_SAL_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_ACL_SAL_PB.TabIndex = 1;
        this.ID_ACL_SAL_PB.Tag = "";
        this.ID_ACL_SAL_PB.Text = "Cerrar";
        this.ID_ACL_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_ACL_SAL_PB.Click += new System.EventHandler(this.ID_ACL_SAL_PB_Click);
        // 
        // ID_ACL_IMP_PB
        // 
        this.ID_ACL_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_IMP_PB.Location = new System.Drawing.Point(447, 259);
        this.ID_ACL_IMP_PB.Name = "ID_ACL_IMP_PB";
        this.ID_ACL_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_ACL_IMP_PB.TabIndex = 2;
        this.ID_ACL_IMP_PB.Tag = "";
        this.ID_ACL_IMP_PB.Text = "Imprimir";
        this.ID_ACL_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_ACL_IMP_PB.Click += new System.EventHandler(this.ID_ACL_IMP_PB_Click);
        // 
        // ID_ACL_GRA_PB
        // 
        this.ID_ACL_GRA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_GRA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_GRA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_GRA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_GRA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_GRA_PB.Location = new System.Drawing.Point(375, 259);
        this.ID_ACL_GRA_PB.Name = "ID_ACL_GRA_PB";
        this.ID_ACL_GRA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_GRA_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_ACL_GRA_PB.TabIndex = 3;
        this.ID_ACL_GRA_PB.Tag = "";
        this.ID_ACL_GRA_PB.Text = "Graficar";
        this.ID_ACL_GRA_PB.UseVisualStyleBackColor = false;
        this.ID_ACL_GRA_PB.Click += new System.EventHandler(this.ID_ACL_GRA_PB_Click);
        // 
        // ID_ACL_GPH
        // 
        this.ID_ACL_GPH.Location = new System.Drawing.Point(16, 14);
        this.ID_ACL_GPH.Name = "ID_ACL_GPH";
        this.ID_ACL_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_GPH.OcxState")));
        this.ID_ACL_GPH.Size = new System.Drawing.Size(576, 225);
        this.ID_ACL_GPH.TabIndex = 9;
        this.ID_ACL_GPH.Tag = "";
        this.ID_ACL_GPH.DblClick += new System.EventHandler(this.ID_ACL_GPH_DblClick);
        // 
        // ID_ACL_GRP_PNL
        // 
        this.ID_ACL_GRP_PNL.Controls.Add(this._ID_ACL_GRA_GPB_1);
        this.ID_ACL_GRP_PNL.Controls.Add(this._ID_ACL_GRA_GPB_0);
        this.ID_ACL_GRP_PNL.Controls.Add(this._ID_ACL_GRA_GPB_3);
        this.ID_ACL_GRP_PNL.Controls.Add(this._ID_ACL_GRA_GPB_2);
        this.ID_ACL_GRP_PNL.Location = new System.Drawing.Point(15, 246);
        this.ID_ACL_GRP_PNL.Name = "ID_ACL_GRP_PNL";
        this.ID_ACL_GRP_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_GRP_PNL.OcxState")));
        this.ID_ACL_GRP_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_ACL_GRP_PNL.TabIndex = 11;
        this.ID_ACL_GRP_PNL.Tag = "";
        // 
        // _ID_ACL_GRA_GPB_1
        // 
        this._ID_ACL_GRA_GPB_1.Location = new System.Drawing.Point(40, 4);
        this._ID_ACL_GRA_GPB_1.Name = "_ID_ACL_GRA_GPB_1";
        this._ID_ACL_GRA_GPB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_GRA_GPB_1.OcxState")));
        this._ID_ACL_GRA_GPB_1.Size = new System.Drawing.Size(37, 33);
        this._ID_ACL_GRA_GPB_1.TabIndex = 8;
        this._ID_ACL_GRA_GPB_1.Tag = "";
        this._ID_ACL_GRA_GPB_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_ACL_GRA_GPB_ClickEvent);
        // 
        // _ID_ACL_GRA_GPB_0
        // 
        this._ID_ACL_GRA_GPB_0.Location = new System.Drawing.Point(4, 4);
        this._ID_ACL_GRA_GPB_0.Name = "_ID_ACL_GRA_GPB_0";
        this._ID_ACL_GRA_GPB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_GRA_GPB_0.OcxState")));
        this._ID_ACL_GRA_GPB_0.Size = new System.Drawing.Size(37, 33);
        this._ID_ACL_GRA_GPB_0.TabIndex = 10;
        this._ID_ACL_GRA_GPB_0.Tag = "";
        this._ID_ACL_GRA_GPB_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_ACL_GRA_GPB_ClickEvent);
        // 
        // _ID_ACL_GRA_GPB_3
        // 
        this._ID_ACL_GRA_GPB_3.Location = new System.Drawing.Point(112, 4);
        this._ID_ACL_GRA_GPB_3.Name = "_ID_ACL_GRA_GPB_3";
        this._ID_ACL_GRA_GPB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_GRA_GPB_3.OcxState")));
        this._ID_ACL_GRA_GPB_3.Size = new System.Drawing.Size(37, 33);
        this._ID_ACL_GRA_GPB_3.TabIndex = 4;
        this._ID_ACL_GRA_GPB_3.Tag = "";
        this._ID_ACL_GRA_GPB_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_ACL_GRA_GPB_ClickEvent);
        // 
        // _ID_ACL_GRA_GPB_2
        // 
        this._ID_ACL_GRA_GPB_2.Location = new System.Drawing.Point(76, 4);
        this._ID_ACL_GRA_GPB_2.Name = "_ID_ACL_GRA_GPB_2";
        this._ID_ACL_GRA_GPB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_GRA_GPB_2.OcxState")));
        this._ID_ACL_GRA_GPB_2.Size = new System.Drawing.Size(37, 33);
        this._ID_ACL_GRA_GPB_2.TabIndex = 6;
        this._ID_ACL_GRA_GPB_2.Tag = "";
        this._ID_ACL_GRA_GPB_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_ACL_GRA_GPB_ClickEvent);
        // 
        // ID_ACL_PRI_PNL
        // 
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_INF_CKB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_TIP_COB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_INF_COB);
        this.ID_ACL_PRI_PNL.Controls.Add(this._ID_ACL_ETI_TXT_1);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_PRI_PNLLabel_Text);
        this.ID_ACL_PRI_PNL.Controls.Add(this._ID_ACL_ETI_TXT_2);
        this.ID_ACL_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_ACL_PRI_PNL.Name = "ID_ACL_PRI_PNL";
        this.ID_ACL_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_PRI_PNL.OcxState")));
        this.ID_ACL_PRI_PNL.Size = new System.Drawing.Size(609, 56);
        this.ID_ACL_PRI_PNL.TabIndex = 0;
        this.ID_ACL_PRI_PNL.Tag = "";
        // 
        // ID_ACL_INF_CKB
        // 
        this.ID_ACL_INF_CKB.Location = new System.Drawing.Point(563, 36);
        this.ID_ACL_INF_CKB.Name = "ID_ACL_INF_CKB";
        this.ID_ACL_INF_CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_INF_CKB.OcxState")));
        this.ID_ACL_INF_CKB.Size = new System.Drawing.Size(41, 13);
        this.ID_ACL_INF_CKB.TabIndex = 5;
        this.ID_ACL_INF_CKB.Tag = "";
        // 
        // ID_ACL_TIP_COB
        // 
        this.ID_ACL_TIP_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_TIP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_TIP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACL_TIP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_TIP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_TIP_COB.Location = new System.Drawing.Point(48, 28);
        this.ID_ACL_TIP_COB.Name = "ID_ACL_TIP_COB";
        this.ID_ACL_TIP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_TIP_COB.Size = new System.Drawing.Size(218, 21);
        this.ID_ACL_TIP_COB.TabIndex = 14;
        this.ID_ACL_TIP_COB.Tag = "";
        this.ID_ACL_TIP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_ACL_TIP_COB_SelectedIndexChanged);
        // 
        // ID_ACL_INF_COB
        // 
        this.ID_ACL_INF_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_INF_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_INF_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACL_INF_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_INF_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_INF_COB.Location = new System.Drawing.Point(326, 28);
        this.ID_ACL_INF_COB.Name = "ID_ACL_INF_COB";
        this.ID_ACL_INF_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_INF_COB.Size = new System.Drawing.Size(230, 21);
        this.ID_ACL_INF_COB.TabIndex = 15;
        this.ID_ACL_INF_COB.Tag = "";
        this.ID_ACL_INF_COB.SelectedIndexChanged += new System.EventHandler(this.ID_ACL_INF_COB_SelectedIndexChanged);
        // 
        // _ID_ACL_ETI_TXT_1
        // 
        this._ID_ACL_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
        this._ID_ACL_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_ACL_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_ACL_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_ACL_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_ACL_ETI_TXT_1.Location = new System.Drawing.Point(15, 30);
        this._ID_ACL_ETI_TXT_1.Name = "_ID_ACL_ETI_TXT_1";
        this._ID_ACL_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_ACL_ETI_TXT_1.Size = new System.Drawing.Size(28, 15);
        this._ID_ACL_ETI_TXT_1.TabIndex = 13;
        this._ID_ACL_ETI_TXT_1.Tag = "";
        this._ID_ACL_ETI_TXT_1.Text = "&Tipo";
        // 
        // ID_ACL_PRI_PNLLabel_Text
        // 
        this.ID_ACL_PRI_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_PRI_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACL_PRI_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_ACL_PRI_PNLLabel_Text.Name = "ID_ACL_PRI_PNLLabel_Text";
        this.ID_ACL_PRI_PNLLabel_Text.Size = new System.Drawing.Size(609, 56);
        this.ID_ACL_PRI_PNLLabel_Text.TabIndex = 16;
        this.ID_ACL_PRI_PNLLabel_Text.Tag = "";
        this.ID_ACL_PRI_PNLLabel_Text.Text = " Parámetros a Graficar";
        // 
        // _ID_ACL_ETI_TXT_2
        // 
        this._ID_ACL_ETI_TXT_2.BackColor = System.Drawing.Color.Silver;
        this._ID_ACL_ETI_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_ACL_ETI_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_ACL_ETI_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_ACL_ETI_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_ACL_ETI_TXT_2.Location = new System.Drawing.Point(275, 30);
        this._ID_ACL_ETI_TXT_2.Name = "_ID_ACL_ETI_TXT_2";
        this._ID_ACL_ETI_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_ACL_ETI_TXT_2.Size = new System.Drawing.Size(51, 15);
        this._ID_ACL_ETI_TXT_2.TabIndex = 12;
        this._ID_ACL_ETI_TXT_2.Tag = "";
        this._ID_ACL_ETI_TXT_2.Text = "&Empresa";
        // 
        // CORGRACL
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.ClientSize = new System.Drawing.Size(609, 351);
        this.Controls.Add(this.ID_ACL_PRI_PNL);
        this.Controls.Add(this.ID_ACL_PRI1_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(109, 159);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRACL";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Aclaraciones";
        this.Closed += new System.EventHandler(this.CORGRACL_Closed);
        this.Activated += new System.EventHandler(this.CORGRACL_Activated);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORGRACL_KeyPress);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CORGRACL_KeyDown);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_PRI1_PNL)).EndInit();
        this.ID_ACL_PRI1_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_GPH)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_GRP_PNL)).EndInit();
        this.ID_ACL_GRP_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_GRA_GPB_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_GRA_GPB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_GRA_GPB_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_GRA_GPB_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_PRI_PNL)).EndInit();
        this.ID_ACL_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_INF_CKB)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_ACL_ETI_TXT()
	{
			this.ID_ACL_ETI_TXT[1] = _ID_ACL_ETI_TXT_1;
			this.ID_ACL_ETI_TXT[2] = _ID_ACL_ETI_TXT_2;
	}
	void  InitializeID_ACL_GRA_GPB()
	{
			this.ID_ACL_GRA_GPB[0] = _ID_ACL_GRA_GPB_0;
			this.ID_ACL_GRA_GPB[1] = _ID_ACL_GRA_GPB_1;
			this.ID_ACL_GRA_GPB[2] = _ID_ACL_GRA_GPB_2;
			this.ID_ACL_GRA_GPB[3] = _ID_ACL_GRA_GPB_3;
	}
#endregion 
}
}