using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORGRCRE
	{
	
#region "Upgrade Support "
		private static CORGRCRE m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRCRE DefInstance
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
		public CORGRCRE():base(){
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
			InitializeID_GRA_ETI_TXT();
			InitializeID_CRE_MAX_FTB();
			InitializeID_CRE_CON_TXT();
			InitializeID_CRE_ETI_TXT();
			InitializeID_CRE_MIN_FTB();
			InitializeID_CRE_TIP_SSR();
		}
	public static CORGRCRE CreateInstance()
	{
			CORGRCRE theInstance = new CORGRCRE();
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
	public  System.Windows.Forms.ComboBox ID_CRE_EMP_COB;
	public  System.Windows.Forms.ComboBox ID_CRE_TIP_COB;
	public  AxThreed.AxSSCheck ID_CRE_IRA_CHK;
	private  System.Windows.Forms.Label _ID_CRE_ETI_TXT_3;
	private  System.Windows.Forms.Label _ID_GRA_ETI_TXT_1;
	public  System.Windows.Forms.Label ID_CRE_PRI_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_CRE_PRI_PNL;
	public  System.Windows.Forms.Button ID_CRE_RAN_PB;
	public  System.Windows.Forms.Button ID_CRE_SAL_PB;
	public  System.Windows.Forms.Button ID_CRE_IMP_PB;
	public  System.Windows.Forms.Button ID_CRE_GRA_PB;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_0;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_1;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_2;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_3;
	public  AxThreed.AxSSPanel ID_CRE_TIP_PNL;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_0;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_0;
	public  System.Windows.Forms.Button ID_CRE_ACT_PB;
	public  System.Windows.Forms.Button ID_CRE_CAN_PB;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_1;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_2;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_3;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_4;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_5;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_6;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_7;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_8;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MIN_FTB_9;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_1;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_2;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_3;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_4;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_5;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_6;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_7;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_8;
	private  AxMSMask.AxMaskEdBox _ID_CRE_MAX_FTB_9;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_1;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_0;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_2;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_3;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_4;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_5;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_6;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_7;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_8;
	private  System.Windows.Forms.Label _ID_CRE_CON_TXT_9;
	public  System.Windows.Forms.Label ID_CRE_RAN_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_CRE_RAN_PNL;
	public  AxGraphLib.AxGraph ID_CRE_GRA_GPH;
	public  AxThreed.AxSSPanel ID_CRE_PRI1_PNL;
	public System.Windows.Forms.Label[] ID_CRE_CON_TXT = new System.Windows.Forms.Label[10];
	public System.Windows.Forms.Label[] ID_CRE_ETI_TXT = new System.Windows.Forms.Label[4];
	public AxMSMask.AxMaskEdBox[] ID_CRE_MAX_FTB = new AxMSMask.AxMaskEdBox[10];
	public AxMSMask.AxMaskEdBox[] ID_CRE_MIN_FTB = new AxMSMask.AxMaskEdBox[10];
	public AxThreed.AxSSRibbon[] ID_CRE_TIP_SSR = new AxThreed.AxSSRibbon[4];
	public System.Windows.Forms.Label[] ID_GRA_ETI_TXT = new System.Windows.Forms.Label[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRCRE));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_CRE_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_CRE_IRA_CHK = new AxThreed.AxSSCheck();
        this.ID_CRE_TIP_COB = new System.Windows.Forms.ComboBox();
        this.ID_CRE_EMP_COB = new System.Windows.Forms.ComboBox();
        this._ID_CRE_ETI_TXT_3 = new System.Windows.Forms.Label();
        this.ID_CRE_PRI_PNLLabel_Text = new System.Windows.Forms.Label();
        this._ID_GRA_ETI_TXT_1 = new System.Windows.Forms.Label();
        this.ID_CRE_PRI1_PNL = new AxThreed.AxSSPanel();
        this.ID_CRE_GRA_PB = new System.Windows.Forms.Button();
        this.ID_CRE_IMP_PB = new System.Windows.Forms.Button();
        this.ID_CRE_SAL_PB = new System.Windows.Forms.Button();
        this.ID_CRE_GRA_GPH = new AxGraphLib.AxGraph();
        this.ID_CRE_RAN_PNL = new AxThreed.AxSSPanel();
        this._ID_CRE_MAX_FTB_8 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MAX_FTB_7 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_CON_TXT_1 = new System.Windows.Forms.Label();
        this._ID_CRE_MAX_FTB_9 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MAX_FTB_6 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MAX_FTB_3 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MAX_FTB_2 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MAX_FTB_5 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MAX_FTB_4 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_CON_TXT_0 = new System.Windows.Forms.Label();
        this._ID_CRE_CON_TXT_8 = new System.Windows.Forms.Label();
        this._ID_CRE_CON_TXT_7 = new System.Windows.Forms.Label();
        this.ID_CRE_RAN_PNLLabel_Text = new System.Windows.Forms.Label();
        this._ID_CRE_CON_TXT_9 = new System.Windows.Forms.Label();
        this._ID_CRE_CON_TXT_6 = new System.Windows.Forms.Label();
        this._ID_CRE_CON_TXT_3 = new System.Windows.Forms.Label();
        this._ID_CRE_CON_TXT_2 = new System.Windows.Forms.Label();
        this._ID_CRE_CON_TXT_5 = new System.Windows.Forms.Label();
        this._ID_CRE_CON_TXT_4 = new System.Windows.Forms.Label();
        this._ID_CRE_MAX_FTB_1 = new AxMSMask.AxMaskEdBox();
        this.ID_CRE_CAN_PB = new System.Windows.Forms.Button();
        this._ID_CRE_MIN_FTB_1 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MIN_FTB_2 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MAX_FTB_0 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MIN_FTB_0 = new AxMSMask.AxMaskEdBox();
        this.ID_CRE_ACT_PB = new System.Windows.Forms.Button();
        this._ID_CRE_MIN_FTB_3 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MIN_FTB_7 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MIN_FTB_8 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MIN_FTB_9 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MIN_FTB_4 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MIN_FTB_5 = new AxMSMask.AxMaskEdBox();
        this._ID_CRE_MIN_FTB_6 = new AxMSMask.AxMaskEdBox();
        this.ID_CRE_TIP_PNL = new AxThreed.AxSSPanel();
        this._ID_CRE_TIP_SSR_1 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_0 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_3 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_2 = new AxThreed.AxSSRibbon();
        this.ID_CRE_RAN_PB = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_PRI_PNL)).BeginInit();
        this.ID_CRE_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_IRA_CHK)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_PRI1_PNL)).BeginInit();
        this.ID_CRE_PRI1_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_GRA_GPH)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_RAN_PNL)).BeginInit();
        this.ID_CRE_RAN_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_TIP_PNL)).BeginInit();
        this.ID_CRE_TIP_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_2)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_CRE_PRI_PNL
        // 
        this.ID_CRE_PRI_PNL.Controls.Add(this.ID_CRE_IRA_CHK);
        this.ID_CRE_PRI_PNL.Controls.Add(this.ID_CRE_TIP_COB);
        this.ID_CRE_PRI_PNL.Controls.Add(this.ID_CRE_EMP_COB);
        this.ID_CRE_PRI_PNL.Controls.Add(this._ID_CRE_ETI_TXT_3);
        this.ID_CRE_PRI_PNL.Controls.Add(this.ID_CRE_PRI_PNLLabel_Text);
        this.ID_CRE_PRI_PNL.Controls.Add(this._ID_GRA_ETI_TXT_1);
        this.ID_CRE_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_CRE_PRI_PNL.Name = "ID_CRE_PRI_PNL";
        this.ID_CRE_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_PRI_PNL.OcxState")));
        this.ID_CRE_PRI_PNL.Size = new System.Drawing.Size(606, 67);
        this.ID_CRE_PRI_PNL.TabIndex = 0;
        this.ID_CRE_PRI_PNL.Tag = "";
        // 
        // ID_CRE_IRA_CHK
        // 
        this.ID_CRE_IRA_CHK.Location = new System.Drawing.Point(561, 36);
        this.ID_CRE_IRA_CHK.Name = "ID_CRE_IRA_CHK";
        this.ID_CRE_IRA_CHK.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_IRA_CHK.OcxState")));
        this.ID_CRE_IRA_CHK.Size = new System.Drawing.Size(39, 13);
        this.ID_CRE_IRA_CHK.TabIndex = 3;
        this.ID_CRE_IRA_CHK.Tag = "";
        // 
        // ID_CRE_TIP_COB
        // 
        this.ID_CRE_TIP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CRE_TIP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_TIP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CRE_TIP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_TIP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CRE_TIP_COB.Location = new System.Drawing.Point(34, 28);
        this.ID_CRE_TIP_COB.Name = "ID_CRE_TIP_COB";
        this.ID_CRE_TIP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_TIP_COB.Size = new System.Drawing.Size(232, 21);
        this.ID_CRE_TIP_COB.TabIndex = 1;
        this.ID_CRE_TIP_COB.Tag = "";
        this.ID_CRE_TIP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CRE_TIP_COB_SelectedIndexChanged);
        // 
        // ID_CRE_EMP_COB
        // 
        this.ID_CRE_EMP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CRE_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CRE_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CRE_EMP_COB.Location = new System.Drawing.Point(321, 28);
        this.ID_CRE_EMP_COB.Name = "ID_CRE_EMP_COB";
        this.ID_CRE_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_EMP_COB.Size = new System.Drawing.Size(240, 21);
        this.ID_CRE_EMP_COB.TabIndex = 2;
        this.ID_CRE_EMP_COB.Tag = "";
        this.ID_CRE_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CRE_EMP_COB_SelectedIndexChanged);
        // 
        // _ID_CRE_ETI_TXT_3
        // 
        this._ID_CRE_ETI_TXT_3.BackColor = System.Drawing.Color.Silver;
        this._ID_CRE_ETI_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_ETI_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_ETI_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_ETI_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_ETI_TXT_3.Location = new System.Drawing.Point(271, 32);
        this._ID_CRE_ETI_TXT_3.Name = "_ID_CRE_ETI_TXT_3";
        this._ID_CRE_ETI_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_ETI_TXT_3.Size = new System.Drawing.Size(51, 15);
        this._ID_CRE_ETI_TXT_3.TabIndex = 12;
        this._ID_CRE_ETI_TXT_3.Tag = "";
        this._ID_CRE_ETI_TXT_3.Text = "&Empresa";
        // 
        // ID_CRE_PRI_PNLLabel_Text
        // 
        this.ID_CRE_PRI_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_PRI_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_PRI_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_CRE_PRI_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_CRE_PRI_PNLLabel_Text.Name = "ID_CRE_PRI_PNLLabel_Text";
        this.ID_CRE_PRI_PNLLabel_Text.Size = new System.Drawing.Size(606, 67);
        this.ID_CRE_PRI_PNLLabel_Text.TabIndex = 13;
        this.ID_CRE_PRI_PNLLabel_Text.Tag = "";
        this.ID_CRE_PRI_PNLLabel_Text.Text = " Parámetros a Graficar";
        // 
        // _ID_GRA_ETI_TXT_1
        // 
        this._ID_GRA_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
        this._ID_GRA_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_GRA_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_GRA_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_GRA_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_GRA_ETI_TXT_1.Location = new System.Drawing.Point(5, 31);
        this._ID_GRA_ETI_TXT_1.Name = "_ID_GRA_ETI_TXT_1";
        this._ID_GRA_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_GRA_ETI_TXT_1.Size = new System.Drawing.Size(28, 15);
        this._ID_GRA_ETI_TXT_1.TabIndex = 10;
        this._ID_GRA_ETI_TXT_1.Tag = "";
        this._ID_GRA_ETI_TXT_1.Text = "&Tipo";
        // 
        // ID_CRE_PRI1_PNL
        // 
        this.ID_CRE_PRI1_PNL.Controls.Add(this.ID_CRE_GRA_PB);
        this.ID_CRE_PRI1_PNL.Controls.Add(this.ID_CRE_IMP_PB);
        this.ID_CRE_PRI1_PNL.Controls.Add(this.ID_CRE_SAL_PB);
        this.ID_CRE_PRI1_PNL.Controls.Add(this.ID_CRE_GRA_GPH);
        this.ID_CRE_PRI1_PNL.Controls.Add(this.ID_CRE_RAN_PNL);
        this.ID_CRE_PRI1_PNL.Controls.Add(this.ID_CRE_TIP_PNL);
        this.ID_CRE_PRI1_PNL.Controls.Add(this.ID_CRE_RAN_PB);
        this.ID_CRE_PRI1_PNL.Location = new System.Drawing.Point(0, 64);
        this.ID_CRE_PRI1_PNL.Name = "ID_CRE_PRI1_PNL";
        this.ID_CRE_PRI1_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_PRI1_PNL.OcxState")));
        this.ID_CRE_PRI1_PNL.Size = new System.Drawing.Size(606, 289);
        this.ID_CRE_PRI1_PNL.TabIndex = 8;
        this.ID_CRE_PRI1_PNL.Tag = "";
        // 
        // ID_CRE_GRA_PB
        // 
        this.ID_CRE_GRA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CRE_GRA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_GRA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_GRA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_GRA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_GRA_PB.Location = new System.Drawing.Point(374, 262);
        this.ID_CRE_GRA_PB.Name = "ID_CRE_GRA_PB";
        this.ID_CRE_GRA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_GRA_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CRE_GRA_PB.TabIndex = 13;
        this.ID_CRE_GRA_PB.Tag = "";
        this.ID_CRE_GRA_PB.Text = "&Graficar";
        this.ID_CRE_GRA_PB.UseVisualStyleBackColor = false;
        this.ID_CRE_GRA_PB.Click += new System.EventHandler(this.ID_CRE_GRA_PB_Click);
        // 
        // ID_CRE_IMP_PB
        // 
        this.ID_CRE_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CRE_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_IMP_PB.Location = new System.Drawing.Point(446, 262);
        this.ID_CRE_IMP_PB.Name = "ID_CRE_IMP_PB";
        this.ID_CRE_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CRE_IMP_PB.TabIndex = 14;
        this.ID_CRE_IMP_PB.Tag = "";
        this.ID_CRE_IMP_PB.Text = "&Imprimir";
        this.ID_CRE_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_CRE_IMP_PB.Click += new System.EventHandler(this.ID_CRE_IMP_PB_Click);
        // 
        // ID_CRE_SAL_PB
        // 
        this.ID_CRE_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CRE_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_CRE_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_SAL_PB.Location = new System.Drawing.Point(518, 262);
        this.ID_CRE_SAL_PB.Name = "ID_CRE_SAL_PB";
        this.ID_CRE_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_SAL_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CRE_SAL_PB.TabIndex = 37;
        this.ID_CRE_SAL_PB.Tag = "";
        this.ID_CRE_SAL_PB.Text = "Cerrar";
        this.ID_CRE_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_CRE_SAL_PB.Click += new System.EventHandler(this.ID_CRE_SAL_PB_Click);
        // 
        // ID_CRE_GRA_GPH
        // 
        this.ID_CRE_GRA_GPH.Location = new System.Drawing.Point(14, 13);
        this.ID_CRE_GRA_GPH.Name = "ID_CRE_GRA_GPH";
        this.ID_CRE_GRA_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_GRA_GPH.OcxState")));
        this.ID_CRE_GRA_GPH.Size = new System.Drawing.Size(577, 218);
        this.ID_CRE_GRA_GPH.TabIndex = 9;
        this.ID_CRE_GRA_GPH.Tag = "";
        this.ID_CRE_GRA_GPH.DblClick += new System.EventHandler(this.ID_CRE_GRA_GPH_DblClick);
        // 
        // ID_CRE_RAN_PNL
        // 
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_8);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_7);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_1);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_9);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_6);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_3);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_2);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_5);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_4);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_0);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_8);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_7);
        this.ID_CRE_RAN_PNL.Controls.Add(this.ID_CRE_RAN_PNLLabel_Text);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_9);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_6);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_3);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_2);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_5);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_CON_TXT_4);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_1);
        this.ID_CRE_RAN_PNL.Controls.Add(this.ID_CRE_CAN_PB);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_1);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_2);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MAX_FTB_0);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_0);
        this.ID_CRE_RAN_PNL.Controls.Add(this.ID_CRE_ACT_PB);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_3);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_7);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_8);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_9);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_4);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_5);
        this.ID_CRE_RAN_PNL.Controls.Add(this._ID_CRE_MIN_FTB_6);
        this.ID_CRE_RAN_PNL.Location = new System.Drawing.Point(184, 0);
        this.ID_CRE_RAN_PNL.Name = "ID_CRE_RAN_PNL";
        this.ID_CRE_RAN_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_RAN_PNL.OcxState")));
        this.ID_CRE_RAN_PNL.Size = new System.Drawing.Size(177, 248);
        this.ID_CRE_RAN_PNL.TabIndex = 39;
        this.ID_CRE_RAN_PNL.Tag = "";
        // 
        // _ID_CRE_MAX_FTB_8
        // 
        this._ID_CRE_MAX_FTB_8.Location = new System.Drawing.Point(96, 173);
        this._ID_CRE_MAX_FTB_8.Name = "_ID_CRE_MAX_FTB_8";
        this._ID_CRE_MAX_FTB_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_8.OcxState")));
        this._ID_CRE_MAX_FTB_8.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_8.TabIndex = 32;
        this._ID_CRE_MAX_FTB_8.Tag = "";
        this._ID_CRE_MAX_FTB_8.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_MAX_FTB_7
        // 
        this._ID_CRE_MAX_FTB_7.Location = new System.Drawing.Point(96, 154);
        this._ID_CRE_MAX_FTB_7.Name = "_ID_CRE_MAX_FTB_7";
        this._ID_CRE_MAX_FTB_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_7.OcxState")));
        this._ID_CRE_MAX_FTB_7.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_7.TabIndex = 30;
        this._ID_CRE_MAX_FTB_7.Tag = "";
        this._ID_CRE_MAX_FTB_7.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_CON_TXT_1
        // 
        this._ID_CRE_CON_TXT_1.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_1.Location = new System.Drawing.Point(9, 20);
        this._ID_CRE_CON_TXT_1.Name = "_ID_CRE_CON_TXT_1";
        this._ID_CRE_CON_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_1.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_1.TabIndex = 49;
        this._ID_CRE_CON_TXT_1.Tag = "";
        this._ID_CRE_CON_TXT_1.Text = "1";
        // 
        // _ID_CRE_MAX_FTB_9
        // 
        this._ID_CRE_MAX_FTB_9.Location = new System.Drawing.Point(96, 192);
        this._ID_CRE_MAX_FTB_9.Name = "_ID_CRE_MAX_FTB_9";
        this._ID_CRE_MAX_FTB_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_9.OcxState")));
        this._ID_CRE_MAX_FTB_9.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_9.TabIndex = 34;
        this._ID_CRE_MAX_FTB_9.Tag = "";
        this._ID_CRE_MAX_FTB_9.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_MAX_FTB_6
        // 
        this._ID_CRE_MAX_FTB_6.Location = new System.Drawing.Point(96, 135);
        this._ID_CRE_MAX_FTB_6.Name = "_ID_CRE_MAX_FTB_6";
        this._ID_CRE_MAX_FTB_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_6.OcxState")));
        this._ID_CRE_MAX_FTB_6.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_6.TabIndex = 28;
        this._ID_CRE_MAX_FTB_6.Tag = "";
        this._ID_CRE_MAX_FTB_6.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_MAX_FTB_3
        // 
        this._ID_CRE_MAX_FTB_3.Location = new System.Drawing.Point(96, 78);
        this._ID_CRE_MAX_FTB_3.Name = "_ID_CRE_MAX_FTB_3";
        this._ID_CRE_MAX_FTB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_3.OcxState")));
        this._ID_CRE_MAX_FTB_3.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_3.TabIndex = 22;
        this._ID_CRE_MAX_FTB_3.Tag = "";
        this._ID_CRE_MAX_FTB_3.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_MAX_FTB_2
        // 
        this._ID_CRE_MAX_FTB_2.Location = new System.Drawing.Point(96, 59);
        this._ID_CRE_MAX_FTB_2.Name = "_ID_CRE_MAX_FTB_2";
        this._ID_CRE_MAX_FTB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_2.OcxState")));
        this._ID_CRE_MAX_FTB_2.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_2.TabIndex = 20;
        this._ID_CRE_MAX_FTB_2.Tag = "";
        this._ID_CRE_MAX_FTB_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_MAX_FTB_5
        // 
        this._ID_CRE_MAX_FTB_5.Location = new System.Drawing.Point(96, 116);
        this._ID_CRE_MAX_FTB_5.Name = "_ID_CRE_MAX_FTB_5";
        this._ID_CRE_MAX_FTB_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_5.OcxState")));
        this._ID_CRE_MAX_FTB_5.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_5.TabIndex = 26;
        this._ID_CRE_MAX_FTB_5.Tag = "";
        this._ID_CRE_MAX_FTB_5.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_MAX_FTB_4
        // 
        this._ID_CRE_MAX_FTB_4.Location = new System.Drawing.Point(96, 97);
        this._ID_CRE_MAX_FTB_4.Name = "_ID_CRE_MAX_FTB_4";
        this._ID_CRE_MAX_FTB_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_4.OcxState")));
        this._ID_CRE_MAX_FTB_4.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_4.TabIndex = 24;
        this._ID_CRE_MAX_FTB_4.Tag = "";
        this._ID_CRE_MAX_FTB_4.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_CON_TXT_0
        // 
        this._ID_CRE_CON_TXT_0.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_0.Location = new System.Drawing.Point(8, 40);
        this._ID_CRE_CON_TXT_0.Name = "_ID_CRE_CON_TXT_0";
        this._ID_CRE_CON_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_0.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_0.TabIndex = 48;
        this._ID_CRE_CON_TXT_0.Tag = "";
        this._ID_CRE_CON_TXT_0.Text = "2";
        // 
        // _ID_CRE_CON_TXT_8
        // 
        this._ID_CRE_CON_TXT_8.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_8.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_8.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_8.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_8.Location = new System.Drawing.Point(8, 173);
        this._ID_CRE_CON_TXT_8.Name = "_ID_CRE_CON_TXT_8";
        this._ID_CRE_CON_TXT_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_8.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_8.TabIndex = 41;
        this._ID_CRE_CON_TXT_8.Tag = "";
        this._ID_CRE_CON_TXT_8.Text = "9";
        // 
        // _ID_CRE_CON_TXT_7
        // 
        this._ID_CRE_CON_TXT_7.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_7.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_7.Location = new System.Drawing.Point(8, 154);
        this._ID_CRE_CON_TXT_7.Name = "_ID_CRE_CON_TXT_7";
        this._ID_CRE_CON_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_7.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_7.TabIndex = 42;
        this._ID_CRE_CON_TXT_7.Tag = "";
        this._ID_CRE_CON_TXT_7.Text = "8";
        // 
        // ID_CRE_RAN_PNLLabel_Text
        // 
        this.ID_CRE_RAN_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_RAN_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_RAN_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_CRE_RAN_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_CRE_RAN_PNLLabel_Text.Name = "ID_CRE_RAN_PNLLabel_Text";
        this.ID_CRE_RAN_PNLLabel_Text.Size = new System.Drawing.Size(177, 248);
        this.ID_CRE_RAN_PNLLabel_Text.TabIndex = 50;
        this.ID_CRE_RAN_PNLLabel_Text.Tag = "";
        this.ID_CRE_RAN_PNLLabel_Text.Text = "Rangos";
        this.ID_CRE_RAN_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // _ID_CRE_CON_TXT_9
        // 
        this._ID_CRE_CON_TXT_9.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_9.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_9.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_9.Location = new System.Drawing.Point(5, 192);
        this._ID_CRE_CON_TXT_9.Name = "_ID_CRE_CON_TXT_9";
        this._ID_CRE_CON_TXT_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_9.Size = new System.Drawing.Size(14, 14);
        this._ID_CRE_CON_TXT_9.TabIndex = 40;
        this._ID_CRE_CON_TXT_9.Tag = "";
        this._ID_CRE_CON_TXT_9.Text = "10";
        // 
        // _ID_CRE_CON_TXT_6
        // 
        this._ID_CRE_CON_TXT_6.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_6.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_6.Location = new System.Drawing.Point(8, 135);
        this._ID_CRE_CON_TXT_6.Name = "_ID_CRE_CON_TXT_6";
        this._ID_CRE_CON_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_6.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_6.TabIndex = 43;
        this._ID_CRE_CON_TXT_6.Tag = "";
        this._ID_CRE_CON_TXT_6.Text = "7";
        // 
        // _ID_CRE_CON_TXT_3
        // 
        this._ID_CRE_CON_TXT_3.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_3.Location = new System.Drawing.Point(8, 78);
        this._ID_CRE_CON_TXT_3.Name = "_ID_CRE_CON_TXT_3";
        this._ID_CRE_CON_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_3.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_3.TabIndex = 46;
        this._ID_CRE_CON_TXT_3.Tag = "";
        this._ID_CRE_CON_TXT_3.Text = "4";
        // 
        // _ID_CRE_CON_TXT_2
        // 
        this._ID_CRE_CON_TXT_2.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_2.Location = new System.Drawing.Point(8, 59);
        this._ID_CRE_CON_TXT_2.Name = "_ID_CRE_CON_TXT_2";
        this._ID_CRE_CON_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_2.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_2.TabIndex = 47;
        this._ID_CRE_CON_TXT_2.Tag = "";
        this._ID_CRE_CON_TXT_2.Text = "3";
        // 
        // _ID_CRE_CON_TXT_5
        // 
        this._ID_CRE_CON_TXT_5.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_5.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_5.Location = new System.Drawing.Point(8, 116);
        this._ID_CRE_CON_TXT_5.Name = "_ID_CRE_CON_TXT_5";
        this._ID_CRE_CON_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_5.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_5.TabIndex = 44;
        this._ID_CRE_CON_TXT_5.Tag = "";
        this._ID_CRE_CON_TXT_5.Text = "6";
        // 
        // _ID_CRE_CON_TXT_4
        // 
        this._ID_CRE_CON_TXT_4.BackColor = System.Drawing.SystemColors.Control;
        this._ID_CRE_CON_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_CRE_CON_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CRE_CON_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CRE_CON_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_CRE_CON_TXT_4.Location = new System.Drawing.Point(9, 97);
        this._ID_CRE_CON_TXT_4.Name = "_ID_CRE_CON_TXT_4";
        this._ID_CRE_CON_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_CRE_CON_TXT_4.Size = new System.Drawing.Size(10, 14);
        this._ID_CRE_CON_TXT_4.TabIndex = 45;
        this._ID_CRE_CON_TXT_4.Tag = "";
        this._ID_CRE_CON_TXT_4.Text = "5";
        // 
        // _ID_CRE_MAX_FTB_1
        // 
        this._ID_CRE_MAX_FTB_1.Location = new System.Drawing.Point(96, 40);
        this._ID_CRE_MAX_FTB_1.Name = "_ID_CRE_MAX_FTB_1";
        this._ID_CRE_MAX_FTB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_1.OcxState")));
        this._ID_CRE_MAX_FTB_1.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_1.TabIndex = 18;
        this._ID_CRE_MAX_FTB_1.Tag = "";
        this._ID_CRE_MAX_FTB_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // ID_CRE_CAN_PB
        // 
        this.ID_CRE_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CRE_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_CAN_PB.Location = new System.Drawing.Point(90, 216);
        this.ID_CRE_CAN_PB.Name = "ID_CRE_CAN_PB";
        this.ID_CRE_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CRE_CAN_PB.TabIndex = 36;
        this.ID_CRE_CAN_PB.Tag = "";
        this.ID_CRE_CAN_PB.Text = "Cancelar";
        this.ID_CRE_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_CRE_CAN_PB.Click += new System.EventHandler(this.ID_CRE_CAN_PB_Click);
        // 
        // _ID_CRE_MIN_FTB_1
        // 
        this._ID_CRE_MIN_FTB_1.Location = new System.Drawing.Point(21, 40);
        this._ID_CRE_MIN_FTB_1.Name = "_ID_CRE_MIN_FTB_1";
        this._ID_CRE_MIN_FTB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_1.OcxState")));
        this._ID_CRE_MIN_FTB_1.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_1.TabIndex = 17;
        this._ID_CRE_MIN_FTB_1.Tag = "";
        this._ID_CRE_MIN_FTB_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_1.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // _ID_CRE_MIN_FTB_2
        // 
        this._ID_CRE_MIN_FTB_2.Location = new System.Drawing.Point(21, 59);
        this._ID_CRE_MIN_FTB_2.Name = "_ID_CRE_MIN_FTB_2";
        this._ID_CRE_MIN_FTB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_2.OcxState")));
        this._ID_CRE_MIN_FTB_2.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_2.TabIndex = 19;
        this._ID_CRE_MIN_FTB_2.Tag = "";
        this._ID_CRE_MIN_FTB_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_2.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // _ID_CRE_MAX_FTB_0
        // 
        this._ID_CRE_MAX_FTB_0.Location = new System.Drawing.Point(96, 20);
        this._ID_CRE_MAX_FTB_0.Name = "_ID_CRE_MAX_FTB_0";
        this._ID_CRE_MAX_FTB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MAX_FTB_0.OcxState")));
        this._ID_CRE_MAX_FTB_0.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MAX_FTB_0.TabIndex = 16;
        this._ID_CRE_MAX_FTB_0.Tag = "";
        this._ID_CRE_MAX_FTB_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MAX_FTB_KeyPressEvent);
        // 
        // _ID_CRE_MIN_FTB_0
        // 
        this._ID_CRE_MIN_FTB_0.Location = new System.Drawing.Point(21, 20);
        this._ID_CRE_MIN_FTB_0.Name = "_ID_CRE_MIN_FTB_0";
        this._ID_CRE_MIN_FTB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_0.OcxState")));
        this._ID_CRE_MIN_FTB_0.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_0.TabIndex = 15;
        this._ID_CRE_MIN_FTB_0.Tag = "";
        this._ID_CRE_MIN_FTB_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_0.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // ID_CRE_ACT_PB
        // 
        this.ID_CRE_ACT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CRE_ACT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_ACT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_ACT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_ACT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_ACT_PB.Location = new System.Drawing.Point(10, 216);
        this.ID_CRE_ACT_PB.Name = "ID_CRE_ACT_PB";
        this.ID_CRE_ACT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_ACT_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CRE_ACT_PB.TabIndex = 35;
        this.ID_CRE_ACT_PB.Tag = "";
        this.ID_CRE_ACT_PB.Text = "Actualizar";
        this.ID_CRE_ACT_PB.UseVisualStyleBackColor = false;
        this.ID_CRE_ACT_PB.Click += new System.EventHandler(this.ID_CRE_ACT_PB_Click);
        // 
        // _ID_CRE_MIN_FTB_3
        // 
        this._ID_CRE_MIN_FTB_3.Location = new System.Drawing.Point(21, 78);
        this._ID_CRE_MIN_FTB_3.Name = "_ID_CRE_MIN_FTB_3";
        this._ID_CRE_MIN_FTB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_3.OcxState")));
        this._ID_CRE_MIN_FTB_3.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_3.TabIndex = 21;
        this._ID_CRE_MIN_FTB_3.Tag = "";
        this._ID_CRE_MIN_FTB_3.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_3.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // _ID_CRE_MIN_FTB_7
        // 
        this._ID_CRE_MIN_FTB_7.Location = new System.Drawing.Point(21, 154);
        this._ID_CRE_MIN_FTB_7.Name = "_ID_CRE_MIN_FTB_7";
        this._ID_CRE_MIN_FTB_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_7.OcxState")));
        this._ID_CRE_MIN_FTB_7.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_7.TabIndex = 29;
        this._ID_CRE_MIN_FTB_7.Tag = "";
        this._ID_CRE_MIN_FTB_7.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_7.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // _ID_CRE_MIN_FTB_8
        // 
        this._ID_CRE_MIN_FTB_8.Location = new System.Drawing.Point(21, 173);
        this._ID_CRE_MIN_FTB_8.Name = "_ID_CRE_MIN_FTB_8";
        this._ID_CRE_MIN_FTB_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_8.OcxState")));
        this._ID_CRE_MIN_FTB_8.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_8.TabIndex = 31;
        this._ID_CRE_MIN_FTB_8.Tag = "";
        this._ID_CRE_MIN_FTB_8.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_8.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // _ID_CRE_MIN_FTB_9
        // 
        this._ID_CRE_MIN_FTB_9.Location = new System.Drawing.Point(21, 192);
        this._ID_CRE_MIN_FTB_9.Name = "_ID_CRE_MIN_FTB_9";
        this._ID_CRE_MIN_FTB_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_9.OcxState")));
        this._ID_CRE_MIN_FTB_9.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_9.TabIndex = 33;
        this._ID_CRE_MIN_FTB_9.Tag = "";
        this._ID_CRE_MIN_FTB_9.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_9.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // _ID_CRE_MIN_FTB_4
        // 
        this._ID_CRE_MIN_FTB_4.Location = new System.Drawing.Point(21, 97);
        this._ID_CRE_MIN_FTB_4.Name = "_ID_CRE_MIN_FTB_4";
        this._ID_CRE_MIN_FTB_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_4.OcxState")));
        this._ID_CRE_MIN_FTB_4.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_4.TabIndex = 23;
        this._ID_CRE_MIN_FTB_4.Tag = "";
        this._ID_CRE_MIN_FTB_4.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_4.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // _ID_CRE_MIN_FTB_5
        // 
        this._ID_CRE_MIN_FTB_5.Location = new System.Drawing.Point(21, 116);
        this._ID_CRE_MIN_FTB_5.Name = "_ID_CRE_MIN_FTB_5";
        this._ID_CRE_MIN_FTB_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_5.OcxState")));
        this._ID_CRE_MIN_FTB_5.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_5.TabIndex = 25;
        this._ID_CRE_MIN_FTB_5.Tag = "";
        this._ID_CRE_MIN_FTB_5.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_5.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // _ID_CRE_MIN_FTB_6
        // 
        this._ID_CRE_MIN_FTB_6.Location = new System.Drawing.Point(21, 135);
        this._ID_CRE_MIN_FTB_6.Name = "_ID_CRE_MIN_FTB_6";
        this._ID_CRE_MIN_FTB_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_MIN_FTB_6.OcxState")));
        this._ID_CRE_MIN_FTB_6.Size = new System.Drawing.Size(67, 19);
        this._ID_CRE_MIN_FTB_6.TabIndex = 27;
        this._ID_CRE_MIN_FTB_6.Tag = "";
        this._ID_CRE_MIN_FTB_6.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_CRE_MIN_FTB_KeyPressEvent);
        this._ID_CRE_MIN_FTB_6.Change += new System.EventHandler(this.ID_CRE_MIN_FTB_Change);
        // 
        // ID_CRE_TIP_PNL
        // 
        this.ID_CRE_TIP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_1);
        this.ID_CRE_TIP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_0);
        this.ID_CRE_TIP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_3);
        this.ID_CRE_TIP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_2);
        this.ID_CRE_TIP_PNL.Location = new System.Drawing.Point(14, 240);
        this.ID_CRE_TIP_PNL.Name = "ID_CRE_TIP_PNL";
        this.ID_CRE_TIP_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_TIP_PNL.OcxState")));
        this.ID_CRE_TIP_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_CRE_TIP_PNL.TabIndex = 11;
        this.ID_CRE_TIP_PNL.Tag = "";
        // 
        // _ID_CRE_TIP_SSR_1
        // 
        this._ID_CRE_TIP_SSR_1.Location = new System.Drawing.Point(40, 4);
        this._ID_CRE_TIP_SSR_1.Name = "_ID_CRE_TIP_SSR_1";
        this._ID_CRE_TIP_SSR_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_1.OcxState")));
        this._ID_CRE_TIP_SSR_1.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_1.TabIndex = 5;
        this._ID_CRE_TIP_SSR_1.Tag = "";
        this._ID_CRE_TIP_SSR_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_0
        // 
        this._ID_CRE_TIP_SSR_0.Location = new System.Drawing.Point(4, 4);
        this._ID_CRE_TIP_SSR_0.Name = "_ID_CRE_TIP_SSR_0";
        this._ID_CRE_TIP_SSR_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_0.OcxState")));
        this._ID_CRE_TIP_SSR_0.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_0.TabIndex = 4;
        this._ID_CRE_TIP_SSR_0.Tag = "";
        this._ID_CRE_TIP_SSR_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_3
        // 
        this._ID_CRE_TIP_SSR_3.Location = new System.Drawing.Point(112, 4);
        this._ID_CRE_TIP_SSR_3.Name = "_ID_CRE_TIP_SSR_3";
        this._ID_CRE_TIP_SSR_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_3.OcxState")));
        this._ID_CRE_TIP_SSR_3.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_3.TabIndex = 7;
        this._ID_CRE_TIP_SSR_3.Tag = "";
        this._ID_CRE_TIP_SSR_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_2
        // 
        this._ID_CRE_TIP_SSR_2.Location = new System.Drawing.Point(76, 4);
        this._ID_CRE_TIP_SSR_2.Name = "_ID_CRE_TIP_SSR_2";
        this._ID_CRE_TIP_SSR_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_2.OcxState")));
        this._ID_CRE_TIP_SSR_2.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_2.TabIndex = 6;
        this._ID_CRE_TIP_SSR_2.Tag = "";
        this._ID_CRE_TIP_SSR_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // ID_CRE_RAN_PB
        // 
        this.ID_CRE_RAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CRE_RAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_RAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_RAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_RAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_RAN_PB.Location = new System.Drawing.Point(246, 262);
        this.ID_CRE_RAN_PB.Name = "ID_CRE_RAN_PB";
        this.ID_CRE_RAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_RAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CRE_RAN_PB.TabIndex = 38;
        this.ID_CRE_RAN_PB.Tag = "";
        this.ID_CRE_RAN_PB.Text = "&Rangos";
        this.ID_CRE_RAN_PB.UseVisualStyleBackColor = false;
        this.ID_CRE_RAN_PB.Click += new System.EventHandler(this.ID_CRE_RAN_PB_Click);
        // 
        // CORGRCRE
        // 
        this.AcceptButton = this.ID_CRE_GRA_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_CRE_SAL_PB;
        this.ClientSize = new System.Drawing.Size(606, 355);
        this.Controls.Add(this.ID_CRE_PRI1_PNL);
        this.Controls.Add(this.ID_CRE_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(398, 378);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRCRE";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Créditos";
        this.Closed += new System.EventHandler(this.CORGRCRE_Closed);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORGRCRE_KeyPress);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CORGRCRE_KeyDown);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_PRI_PNL)).EndInit();
        this.ID_CRE_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_IRA_CHK)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_PRI1_PNL)).EndInit();
        this.ID_CRE_PRI1_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_GRA_GPH)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_RAN_PNL)).EndInit();
        this.ID_CRE_RAN_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MAX_FTB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_MIN_FTB_6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_TIP_PNL)).EndInit();
        this.ID_CRE_TIP_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_2)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_GRA_ETI_TXT()
	{
			this.ID_GRA_ETI_TXT[1] = _ID_GRA_ETI_TXT_1;
	}
	void  InitializeID_CRE_MAX_FTB()
	{
			this.ID_CRE_MAX_FTB[0] = _ID_CRE_MAX_FTB_0;
			this.ID_CRE_MAX_FTB[1] = _ID_CRE_MAX_FTB_1;
			this.ID_CRE_MAX_FTB[2] = _ID_CRE_MAX_FTB_2;
			this.ID_CRE_MAX_FTB[3] = _ID_CRE_MAX_FTB_3;
			this.ID_CRE_MAX_FTB[4] = _ID_CRE_MAX_FTB_4;
			this.ID_CRE_MAX_FTB[5] = _ID_CRE_MAX_FTB_5;
			this.ID_CRE_MAX_FTB[6] = _ID_CRE_MAX_FTB_6;
			this.ID_CRE_MAX_FTB[7] = _ID_CRE_MAX_FTB_7;
			this.ID_CRE_MAX_FTB[8] = _ID_CRE_MAX_FTB_8;
			this.ID_CRE_MAX_FTB[9] = _ID_CRE_MAX_FTB_9;
	}
	void  InitializeID_CRE_CON_TXT()
	{
			this.ID_CRE_CON_TXT[1] = _ID_CRE_CON_TXT_1;
			this.ID_CRE_CON_TXT[0] = _ID_CRE_CON_TXT_0;
			this.ID_CRE_CON_TXT[2] = _ID_CRE_CON_TXT_2;
			this.ID_CRE_CON_TXT[3] = _ID_CRE_CON_TXT_3;
			this.ID_CRE_CON_TXT[4] = _ID_CRE_CON_TXT_4;
			this.ID_CRE_CON_TXT[5] = _ID_CRE_CON_TXT_5;
			this.ID_CRE_CON_TXT[6] = _ID_CRE_CON_TXT_6;
			this.ID_CRE_CON_TXT[7] = _ID_CRE_CON_TXT_7;
			this.ID_CRE_CON_TXT[8] = _ID_CRE_CON_TXT_8;
			this.ID_CRE_CON_TXT[9] = _ID_CRE_CON_TXT_9;
	}
	void  InitializeID_CRE_ETI_TXT()
	{
			this.ID_CRE_ETI_TXT[3] = _ID_CRE_ETI_TXT_3;
	}
	void  InitializeID_CRE_MIN_FTB()
	{
			this.ID_CRE_MIN_FTB[0] = _ID_CRE_MIN_FTB_0;
			this.ID_CRE_MIN_FTB[1] = _ID_CRE_MIN_FTB_1;
			this.ID_CRE_MIN_FTB[2] = _ID_CRE_MIN_FTB_2;
			this.ID_CRE_MIN_FTB[3] = _ID_CRE_MIN_FTB_3;
			this.ID_CRE_MIN_FTB[4] = _ID_CRE_MIN_FTB_4;
			this.ID_CRE_MIN_FTB[5] = _ID_CRE_MIN_FTB_5;
			this.ID_CRE_MIN_FTB[6] = _ID_CRE_MIN_FTB_6;
			this.ID_CRE_MIN_FTB[7] = _ID_CRE_MIN_FTB_7;
			this.ID_CRE_MIN_FTB[8] = _ID_CRE_MIN_FTB_8;
			this.ID_CRE_MIN_FTB[9] = _ID_CRE_MIN_FTB_9;
	}
	void  InitializeID_CRE_TIP_SSR()
	{
			this.ID_CRE_TIP_SSR[0] = _ID_CRE_TIP_SSR_0;
			this.ID_CRE_TIP_SSR[1] = _ID_CRE_TIP_SSR_1;
			this.ID_CRE_TIP_SSR[2] = _ID_CRE_TIP_SSR_2;
			this.ID_CRE_TIP_SSR[3] = _ID_CRE_TIP_SSR_3;
	}
#endregion 
}
}