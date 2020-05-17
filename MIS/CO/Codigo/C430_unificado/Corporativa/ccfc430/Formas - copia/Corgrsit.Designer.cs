using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORGRSIT
	{
	
#region "Upgrade Support "
		private static CORGRSIT m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRSIT DefInstance
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
		public CORGRSIT():base(){
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
			InitializeID_CRE_TIP_SSR();
		}
	public static CORGRSIT CreateInstance()
	{
			CORGRSIT theInstance = new CORGRSIT();
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
	public  System.Windows.Forms.ComboBox ID_GRA_PAR_COB;
	public  AxThreed.AxSSCheck ID_CRE_IRA_CHK;
	public  System.Windows.Forms.Label ID_CRE_EMP_TXT;
	public  System.Windows.Forms.Label ID_GRA_TIP_TXT;
	public  System.Windows.Forms.Label ID_GRA_SEC_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_GRA_SEC_PNL;
	public  System.Windows.Forms.Button ID_CRE_SAL_PB;
	public  System.Windows.Forms.Button ID_CRE_GRA_PB;
	public  System.Windows.Forms.Button ID_GRA_IMP_PB;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_3;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_2;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_1;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_0;
	public  AxThreed.AxSSPanel ID_CRE_TIP_PNL;
	public  AxGraphLib.AxGraph ID_CRE_GRA_GPH;
	public  AxThreed.AxSSPanel ID_GRA_PPL_PNL;
	public AxThreed.AxSSRibbon[] ID_CRE_TIP_SSR = new AxThreed.AxSSRibbon[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRSIT));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_GRA_SEC_PNL = new AxThreed.AxSSPanel();
        this.ID_CRE_IRA_CHK = new AxThreed.AxSSCheck();
        this.ID_GRA_PAR_COB = new System.Windows.Forms.ComboBox();
        this.ID_CRE_EMP_COB = new System.Windows.Forms.ComboBox();
        this.ID_CRE_EMP_TXT = new System.Windows.Forms.Label();
        this.ID_GRA_SEC_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_GRA_TIP_TXT = new System.Windows.Forms.Label();
        this.ID_GRA_PPL_PNL = new AxThreed.AxSSPanel();
        this.ID_GRA_IMP_PB = new System.Windows.Forms.Button();
        this.ID_CRE_GRA_PB = new System.Windows.Forms.Button();
        this.ID_CRE_SAL_PB = new System.Windows.Forms.Button();
        this.ID_CRE_GRA_GPH = new AxGraphLib.AxGraph();
        this.ID_CRE_TIP_PNL = new AxThreed.AxSSPanel();
        this._ID_CRE_TIP_SSR_2 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_3 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_0 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_1 = new AxThreed.AxSSRibbon();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_SEC_PNL)).BeginInit();
        this.ID_GRA_SEC_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_IRA_CHK)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PPL_PNL)).BeginInit();
        this.ID_GRA_PPL_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_GRA_GPH)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_TIP_PNL)).BeginInit();
        this.ID_CRE_TIP_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_1)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_GRA_SEC_PNL
        // 
        this.ID_GRA_SEC_PNL.Controls.Add(this.ID_CRE_IRA_CHK);
        this.ID_GRA_SEC_PNL.Controls.Add(this.ID_GRA_PAR_COB);
        this.ID_GRA_SEC_PNL.Controls.Add(this.ID_CRE_EMP_COB);
        this.ID_GRA_SEC_PNL.Controls.Add(this.ID_CRE_EMP_TXT);
        this.ID_GRA_SEC_PNL.Controls.Add(this.ID_GRA_SEC_PNLLabel_Text);
        this.ID_GRA_SEC_PNL.Controls.Add(this.ID_GRA_TIP_TXT);
        this.ID_GRA_SEC_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_SEC_PNL.Name = "ID_GRA_SEC_PNL";
        this.ID_GRA_SEC_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_SEC_PNL.OcxState")));
        this.ID_GRA_SEC_PNL.Size = new System.Drawing.Size(549, 66);
        this.ID_GRA_SEC_PNL.TabIndex = 0;
        this.ID_GRA_SEC_PNL.Tag = "";
        // 
        // ID_CRE_IRA_CHK
        // 
        this.ID_CRE_IRA_CHK.Location = new System.Drawing.Point(505, 35);
        this.ID_CRE_IRA_CHK.Name = "ID_CRE_IRA_CHK";
        this.ID_CRE_IRA_CHK.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_IRA_CHK.OcxState")));
        this.ID_CRE_IRA_CHK.Size = new System.Drawing.Size(36, 20);
        this.ID_CRE_IRA_CHK.TabIndex = 6;
        this.ID_CRE_IRA_CHK.Tag = "";
        // 
        // ID_GRA_PAR_COB
        // 
        this.ID_GRA_PAR_COB.BackColor = System.Drawing.Color.White;
        this.ID_GRA_PAR_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_PAR_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_GRA_PAR_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_PAR_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_GRA_PAR_COB.Location = new System.Drawing.Point(43, 31);
        this.ID_GRA_PAR_COB.Name = "ID_GRA_PAR_COB";
        this.ID_GRA_PAR_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_PAR_COB.Size = new System.Drawing.Size(169, 21);
        this.ID_GRA_PAR_COB.TabIndex = 7;
        this.ID_GRA_PAR_COB.Tag = "";
        this.ID_GRA_PAR_COB.SelectedIndexChanged += new System.EventHandler(this.ID_GRA_PAR_COB_SelectedIndexChanged);
        // 
        // ID_CRE_EMP_COB
        // 
        this.ID_CRE_EMP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CRE_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CRE_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CRE_EMP_COB.Location = new System.Drawing.Point(274, 31);
        this.ID_CRE_EMP_COB.Name = "ID_CRE_EMP_COB";
        this.ID_CRE_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_EMP_COB.Size = new System.Drawing.Size(227, 21);
        this.ID_CRE_EMP_COB.Sorted = true;
        this.ID_CRE_EMP_COB.TabIndex = 9;
        this.ID_CRE_EMP_COB.Tag = "";
        this.ID_CRE_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CRE_EMP_COB_SelectedIndexChanged);
        // 
        // ID_CRE_EMP_TXT
        // 
        this.ID_CRE_EMP_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_CRE_EMP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_EMP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_EMP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_EMP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_EMP_TXT.Location = new System.Drawing.Point(220, 36);
        this.ID_CRE_EMP_TXT.Name = "ID_CRE_EMP_TXT";
        this.ID_CRE_EMP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_EMP_TXT.Size = new System.Drawing.Size(51, 15);
        this.ID_CRE_EMP_TXT.TabIndex = 5;
        this.ID_CRE_EMP_TXT.Tag = "";
        this.ID_CRE_EMP_TXT.Text = "&Empresa";
        // 
        // ID_GRA_SEC_PNLLabel_Text
        // 
        this.ID_GRA_SEC_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_SEC_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_SEC_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_GRA_SEC_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_SEC_PNLLabel_Text.Name = "ID_GRA_SEC_PNLLabel_Text";
        this.ID_GRA_SEC_PNLLabel_Text.Size = new System.Drawing.Size(549, 66);
        this.ID_GRA_SEC_PNLLabel_Text.TabIndex = 10;
        this.ID_GRA_SEC_PNLLabel_Text.Tag = "";
        this.ID_GRA_SEC_PNLLabel_Text.Text = " Parámetros a Graficar";
        // 
        // ID_GRA_TIP_TXT
        // 
        this.ID_GRA_TIP_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_GRA_TIP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_TIP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_TIP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_TIP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_TIP_TXT.Location = new System.Drawing.Point(12, 35);
        this.ID_GRA_TIP_TXT.Name = "ID_GRA_TIP_TXT";
        this.ID_GRA_TIP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_TIP_TXT.Size = new System.Drawing.Size(27, 18);
        this.ID_GRA_TIP_TXT.TabIndex = 4;
        this.ID_GRA_TIP_TXT.Tag = "";
        this.ID_GRA_TIP_TXT.Text = "&Tipo";
        // 
        // ID_GRA_PPL_PNL
        // 
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_IMP_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_CRE_GRA_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_CRE_SAL_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_CRE_GRA_GPH);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_CRE_TIP_PNL);
        this.ID_GRA_PPL_PNL.Location = new System.Drawing.Point(1, 64);
        this.ID_GRA_PPL_PNL.Name = "ID_GRA_PPL_PNL";
        this.ID_GRA_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PPL_PNL.OcxState")));
        this.ID_GRA_PPL_PNL.Size = new System.Drawing.Size(549, 278);
        this.ID_GRA_PPL_PNL.TabIndex = 8;
        this.ID_GRA_PPL_PNL.Tag = "";
        // 
        // ID_GRA_IMP_PB
        // 
        this.ID_GRA_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_IMP_PB.Location = new System.Drawing.Point(379, 231);
        this.ID_GRA_IMP_PB.Name = "ID_GRA_IMP_PB";
        this.ID_GRA_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_IMP_PB.TabIndex = 1;
        this.ID_GRA_IMP_PB.Tag = "";
        this.ID_GRA_IMP_PB.Text = "&Imprimir";
        this.ID_GRA_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_IMP_PB.Click += new System.EventHandler(this.ID_GRA_IMP_PB_Click);
        // 
        // ID_CRE_GRA_PB
        // 
        this.ID_CRE_GRA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CRE_GRA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_GRA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_GRA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_GRA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_GRA_PB.Location = new System.Drawing.Point(308, 230);
        this.ID_CRE_GRA_PB.Name = "ID_CRE_GRA_PB";
        this.ID_CRE_GRA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_GRA_PB.Size = new System.Drawing.Size(70, 23);
        this.ID_CRE_GRA_PB.TabIndex = 2;
        this.ID_CRE_GRA_PB.Tag = "";
        this.ID_CRE_GRA_PB.Text = "&Graficar";
        this.ID_CRE_GRA_PB.UseVisualStyleBackColor = false;
        this.ID_CRE_GRA_PB.Click += new System.EventHandler(this.ID_CRE_GRA_PB_Click);
        // 
        // ID_CRE_SAL_PB
        // 
        this.ID_CRE_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CRE_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_CRE_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_SAL_PB.Location = new System.Drawing.Point(451, 231);
        this.ID_CRE_SAL_PB.Name = "ID_CRE_SAL_PB";
        this.ID_CRE_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_SAL_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CRE_SAL_PB.TabIndex = 3;
        this.ID_CRE_SAL_PB.Tag = "";
        this.ID_CRE_SAL_PB.Text = "Cerrar";
        this.ID_CRE_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_CRE_SAL_PB.Click += new System.EventHandler(this.ID_CRE_SAL_PB_Click);
        // 
        // ID_CRE_GRA_GPH
        // 
        this.ID_CRE_GRA_GPH.Location = new System.Drawing.Point(16, 8);
        this.ID_CRE_GRA_GPH.Name = "ID_CRE_GRA_GPH";
        this.ID_CRE_GRA_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_GRA_GPH.OcxState")));
        this.ID_CRE_GRA_GPH.Size = new System.Drawing.Size(520, 217);
        this.ID_CRE_GRA_GPH.TabIndex = 15;
        this.ID_CRE_GRA_GPH.Tag = "";
        this.ID_CRE_GRA_GPH.DblClick += new System.EventHandler(this.ID_CRE_GRA_GPH_DblClick);
        // 
        // ID_CRE_TIP_PNL
        // 
        this.ID_CRE_TIP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_2);
        this.ID_CRE_TIP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_3);
        this.ID_CRE_TIP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_0);
        this.ID_CRE_TIP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_1);
        this.ID_CRE_TIP_PNL.Location = new System.Drawing.Point(18, 228);
        this.ID_CRE_TIP_PNL.Name = "ID_CRE_TIP_PNL";
        this.ID_CRE_TIP_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_TIP_PNL.OcxState")));
        this.ID_CRE_TIP_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_CRE_TIP_PNL.TabIndex = 11;
        this.ID_CRE_TIP_PNL.Tag = "";
        // 
        // _ID_CRE_TIP_SSR_2
        // 
        this._ID_CRE_TIP_SSR_2.Location = new System.Drawing.Point(76, 4);
        this._ID_CRE_TIP_SSR_2.Name = "_ID_CRE_TIP_SSR_2";
        this._ID_CRE_TIP_SSR_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_2.OcxState")));
        this._ID_CRE_TIP_SSR_2.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_2.TabIndex = 14;
        this._ID_CRE_TIP_SSR_2.Tag = "";
        this._ID_CRE_TIP_SSR_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_3
        // 
        this._ID_CRE_TIP_SSR_3.Location = new System.Drawing.Point(112, 4);
        this._ID_CRE_TIP_SSR_3.Name = "_ID_CRE_TIP_SSR_3";
        this._ID_CRE_TIP_SSR_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_3.OcxState")));
        this._ID_CRE_TIP_SSR_3.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_3.TabIndex = 10;
        this._ID_CRE_TIP_SSR_3.Tag = "";
        this._ID_CRE_TIP_SSR_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_0
        // 
        this._ID_CRE_TIP_SSR_0.Location = new System.Drawing.Point(4, 4);
        this._ID_CRE_TIP_SSR_0.Name = "_ID_CRE_TIP_SSR_0";
        this._ID_CRE_TIP_SSR_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_0.OcxState")));
        this._ID_CRE_TIP_SSR_0.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_0.TabIndex = 12;
        this._ID_CRE_TIP_SSR_0.Tag = "";
        this._ID_CRE_TIP_SSR_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_1
        // 
        this._ID_CRE_TIP_SSR_1.Location = new System.Drawing.Point(41, 4);
        this._ID_CRE_TIP_SSR_1.Name = "_ID_CRE_TIP_SSR_1";
        this._ID_CRE_TIP_SSR_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_1.OcxState")));
        this._ID_CRE_TIP_SSR_1.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_1.TabIndex = 13;
        this._ID_CRE_TIP_SSR_1.Tag = "";
        this._ID_CRE_TIP_SSR_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // CORGRSIT
        // 
        this.AcceptButton = this.ID_CRE_GRA_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_CRE_SAL_PB;
        this.ClientSize = new System.Drawing.Size(549, 343);
        this.Controls.Add(this.ID_GRA_PPL_PNL);
        this.Controls.Add(this.ID_GRA_SEC_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(186, 116);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRSIT";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Situación de la Cuenta";
        this.Closed += new System.EventHandler(this.CORGRSIT_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_SEC_PNL)).EndInit();
        this.ID_GRA_SEC_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_IRA_CHK)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PPL_PNL)).EndInit();
        this.ID_GRA_PPL_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_GRA_GPH)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_TIP_PNL)).EndInit();
        this.ID_CRE_TIP_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_CRE_TIP_SSR()
	{
			this.ID_CRE_TIP_SSR[3] = _ID_CRE_TIP_SSR_3;
			this.ID_CRE_TIP_SSR[2] = _ID_CRE_TIP_SSR_2;
			this.ID_CRE_TIP_SSR[1] = _ID_CRE_TIP_SSR_1;
			this.ID_CRE_TIP_SSR[0] = _ID_CRE_TIP_SSR_0;
	}
#endregion 
}
}