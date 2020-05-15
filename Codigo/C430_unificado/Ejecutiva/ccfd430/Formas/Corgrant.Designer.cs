using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORGRANT
	{
	
#region "Upgrade Support "
		private static CORGRANT m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRANT DefInstance
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
		public CORGRANT():base(){
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
			InitializeID_CEE_GRA_GPB();
			InitializeID_GRA_GPO_TXT();
		}
	public static CORGRANT CreateInstance()
	{
			CORGRANT theInstance = new CORGRANT();
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
	public  AxMSMask.AxMaskEdBox ID_GRA_MFI_MEB;
	public  AxMSMask.AxMaskEdBox ID_GRA_MIN_MEB;
	public  AxMSMask.AxMaskEdBox ID_GRA_AFI_MEB;
	public  AxMSMask.AxMaskEdBox ID_GRA_AIN_MEB;
	public  System.Windows.Forms.ComboBox ID_GRA_EMP_COB;
	public  System.Windows.Forms.ComboBox ID_GRA_TIP_COB;
	public  AxThreed.AxSSCheck ID_CRE_IRA_CHK;
	private  System.Windows.Forms.Label _ID_GRA_GPO_TXT_6;
	private  System.Windows.Forms.Label _ID_GRA_GPO_TXT_4;
	private  System.Windows.Forms.Label _ID_GRA_GPO_TXT_3;
	private  System.Windows.Forms.Label _ID_GRA_GPO_TXT_2;
	private  System.Windows.Forms.Label _ID_GRA_GPO_TXT_1;
	private  System.Windows.Forms.Label _ID_GRA_GPO_TXT_5;
	public  AxThreed.AxSSPanel ID_GRA_PRI_PNL;
	public  System.Windows.Forms.Button ID_GRA_IMP_PB;
	public  System.Windows.Forms.Button ID_GRA_CAN_PB;
	public  System.Windows.Forms.Button ID_GRA_OK_PB;
	private  AxThreed.AxSSRibbon _ID_CEE_GRA_GPB_3;
	private  AxThreed.AxSSRibbon _ID_CEE_GRA_GPB_2;
	private  AxThreed.AxSSRibbon _ID_CEE_GRA_GPB_1;
	private  AxThreed.AxSSRibbon _ID_CEE_GRA_GPB_0;
	public  AxThreed.AxSSPanel ID_GRA_GRP_PNL;
	public  AxGraphLib.AxGraph ID_GRA_GPH;
	public  AxThreed.AxSSPanel ID_GRA_PRI1_PNL;
	public AxThreed.AxSSRibbon[] ID_CEE_GRA_GPB = new AxThreed.AxSSRibbon[4];
	public System.Windows.Forms.Label[] ID_GRA_GPO_TXT = new System.Windows.Forms.Label[7];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRANT));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_GRA_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_CRE_IRA_CHK = new AxThreed.AxSSCheck();
        this._ID_GRA_GPO_TXT_6 = new System.Windows.Forms.Label();
        this.ID_GRA_EMP_COB = new System.Windows.Forms.ComboBox();
        this.ID_GRA_TIP_COB = new System.Windows.Forms.ComboBox();
        this._ID_GRA_GPO_TXT_4 = new System.Windows.Forms.Label();
        this._ID_GRA_GPO_TXT_1 = new System.Windows.Forms.Label();
        this._ID_GRA_GPO_TXT_5 = new System.Windows.Forms.Label();
        this._ID_GRA_GPO_TXT_3 = new System.Windows.Forms.Label();
        this._ID_GRA_GPO_TXT_2 = new System.Windows.Forms.Label();
        this.ID_GRA_AIN_MEB = new AxMSMask.AxMaskEdBox();
        this.ID_GRA_MFI_MEB = new AxMSMask.AxMaskEdBox();
        this.ID_GRA_MIN_MEB = new AxMSMask.AxMaskEdBox();
        this.ID_GRA_AFI_MEB = new AxMSMask.AxMaskEdBox();
        this.ID_GRA_PRI1_PNL = new AxThreed.AxSSPanel();
        this.ID_GRA_OK_PB = new System.Windows.Forms.Button();
        this.ID_GRA_CAN_PB = new System.Windows.Forms.Button();
        this.ID_GRA_IMP_PB = new System.Windows.Forms.Button();
        this.ID_GRA_GPH = new AxGraphLib.AxGraph();
        this.ID_GRA_GRP_PNL = new AxThreed.AxSSPanel();
        this._ID_CEE_GRA_GPB_2 = new AxThreed.AxSSRibbon();
        this._ID_CEE_GRA_GPB_3 = new AxThreed.AxSSRibbon();
        this._ID_CEE_GRA_GPB_0 = new AxThreed.AxSSRibbon();
        this._ID_CEE_GRA_GPB_1 = new AxThreed.AxSSRibbon();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI_PNL)).BeginInit();
        this.ID_GRA_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_IRA_CHK)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_AIN_MEB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_MFI_MEB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_MIN_MEB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_AFI_MEB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI1_PNL)).BeginInit();
        this.ID_GRA_PRI1_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GPH)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GRP_PNL)).BeginInit();
        this.ID_GRA_GRP_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_GRA_GPB_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_GRA_GPB_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_GRA_GPB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_GRA_GPB_1)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_GRA_PRI_PNL
        // 
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_CRE_IRA_CHK);
        this.ID_GRA_PRI_PNL.Controls.Add(this._ID_GRA_GPO_TXT_6);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_EMP_COB);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_TIP_COB);
        this.ID_GRA_PRI_PNL.Controls.Add(this._ID_GRA_GPO_TXT_4);
        this.ID_GRA_PRI_PNL.Controls.Add(this._ID_GRA_GPO_TXT_1);
        this.ID_GRA_PRI_PNL.Controls.Add(this._ID_GRA_GPO_TXT_5);
        this.ID_GRA_PRI_PNL.Controls.Add(this._ID_GRA_GPO_TXT_3);
        this.ID_GRA_PRI_PNL.Controls.Add(this._ID_GRA_GPO_TXT_2);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_AIN_MEB);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_MFI_MEB);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_MIN_MEB);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_AFI_MEB);
        this.ID_GRA_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_PRI_PNL.Name = "ID_GRA_PRI_PNL";
        this.ID_GRA_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PRI_PNL.OcxState")));
        this.ID_GRA_PRI_PNL.Size = new System.Drawing.Size(534, 83);
        this.ID_GRA_PRI_PNL.TabIndex = 0;
        this.ID_GRA_PRI_PNL.Tag = "";
        // 
        // ID_CRE_IRA_CHK
        // 
        this.ID_CRE_IRA_CHK.Location = new System.Drawing.Point(485, 55);
        this.ID_CRE_IRA_CHK.Name = "ID_CRE_IRA_CHK";
        this.ID_CRE_IRA_CHK.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_IRA_CHK.OcxState")));
        this.ID_CRE_IRA_CHK.Size = new System.Drawing.Size(40, 13);
        this.ID_CRE_IRA_CHK.TabIndex = 13;
        this.ID_CRE_IRA_CHK.Tag = "";
        // 
        // _ID_GRA_GPO_TXT_6
        // 
        this._ID_GRA_GPO_TXT_6.BackColor = System.Drawing.Color.Silver;
        this._ID_GRA_GPO_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_GRA_GPO_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_GRA_GPO_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_GRA_GPO_TXT_6.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_GRA_GPO_TXT_6.Location = new System.Drawing.Point(78, 31);
        this._ID_GRA_GPO_TXT_6.Name = "_ID_GRA_GPO_TXT_6";
        this._ID_GRA_GPO_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_GRA_GPO_TXT_6.Size = new System.Drawing.Size(57, 15);
        this._ID_GRA_GPO_TXT_6.TabIndex = 6;
        this._ID_GRA_GPO_TXT_6.Tag = "";
        this._ID_GRA_GPO_TXT_6.Text = "Año &Final";
        this._ID_GRA_GPO_TXT_6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // ID_GRA_EMP_COB
        // 
        this.ID_GRA_EMP_COB.BackColor = System.Drawing.Color.White;
        this.ID_GRA_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_GRA_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_GRA_EMP_COB.Location = new System.Drawing.Point(274, 50);
        this.ID_GRA_EMP_COB.Name = "ID_GRA_EMP_COB";
        this.ID_GRA_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_EMP_COB.Size = new System.Drawing.Size(207, 21);
        this.ID_GRA_EMP_COB.Sorted = true;
        this.ID_GRA_EMP_COB.TabIndex = 8;
        this.ID_GRA_EMP_COB.Tag = "";
        this.ID_GRA_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_GRA_EMP_COB_SelectedIndexChanged);
        // 
        // ID_GRA_TIP_COB
        // 
        this.ID_GRA_TIP_COB.BackColor = System.Drawing.Color.White;
        this.ID_GRA_TIP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_TIP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_GRA_TIP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_TIP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_GRA_TIP_COB.Location = new System.Drawing.Point(45, 49);
        this.ID_GRA_TIP_COB.Name = "ID_GRA_TIP_COB";
        this.ID_GRA_TIP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_TIP_COB.Size = new System.Drawing.Size(161, 21);
        this.ID_GRA_TIP_COB.TabIndex = 7;
        this.ID_GRA_TIP_COB.Tag = "";
        this.ID_GRA_TIP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_GRA_TIP_COB_SelectedIndexChanged);
        // 
        // _ID_GRA_GPO_TXT_4
        // 
        this._ID_GRA_GPO_TXT_4.BackColor = System.Drawing.Color.Silver;
        this._ID_GRA_GPO_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_GRA_GPO_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_GRA_GPO_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_GRA_GPO_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_GRA_GPO_TXT_4.Location = new System.Drawing.Point(76, 9);
        this._ID_GRA_GPO_TXT_4.Name = "_ID_GRA_GPO_TXT_4";
        this._ID_GRA_GPO_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_GRA_GPO_TXT_4.Size = new System.Drawing.Size(67, 17);
        this._ID_GRA_GPO_TXT_4.TabIndex = 5;
        this._ID_GRA_GPO_TXT_4.Tag = "";
        this._ID_GRA_GPO_TXT_4.Text = "Año &Inicio";
        this._ID_GRA_GPO_TXT_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // _ID_GRA_GPO_TXT_1
        // 
        this._ID_GRA_GPO_TXT_1.BackColor = System.Drawing.Color.Silver;
        this._ID_GRA_GPO_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_GRA_GPO_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_GRA_GPO_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_GRA_GPO_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_GRA_GPO_TXT_1.Location = new System.Drawing.Point(303, 9);
        this._ID_GRA_GPO_TXT_1.Name = "_ID_GRA_GPO_TXT_1";
        this._ID_GRA_GPO_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_GRA_GPO_TXT_1.Size = new System.Drawing.Size(67, 17);
        this._ID_GRA_GPO_TXT_1.TabIndex = 2;
        this._ID_GRA_GPO_TXT_1.Tag = "";
        this._ID_GRA_GPO_TXT_1.Text = "Mes I&nicio";
        this._ID_GRA_GPO_TXT_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // _ID_GRA_GPO_TXT_5
        // 
        this._ID_GRA_GPO_TXT_5.BackColor = System.Drawing.Color.Silver;
        this._ID_GRA_GPO_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_GRA_GPO_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_GRA_GPO_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_GRA_GPO_TXT_5.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_GRA_GPO_TXT_5.Location = new System.Drawing.Point(306, 29);
        this._ID_GRA_GPO_TXT_5.Name = "_ID_GRA_GPO_TXT_5";
        this._ID_GRA_GPO_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_GRA_GPO_TXT_5.Size = new System.Drawing.Size(57, 15);
        this._ID_GRA_GPO_TXT_5.TabIndex = 1;
        this._ID_GRA_GPO_TXT_5.Tag = "";
        this._ID_GRA_GPO_TXT_5.Text = "Mes Fi&nal";
        this._ID_GRA_GPO_TXT_5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // _ID_GRA_GPO_TXT_3
        // 
        this._ID_GRA_GPO_TXT_3.BackColor = System.Drawing.Color.Silver;
        this._ID_GRA_GPO_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_GRA_GPO_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_GRA_GPO_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_GRA_GPO_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_GRA_GPO_TXT_3.Location = new System.Drawing.Point(13, 55);
        this._ID_GRA_GPO_TXT_3.Name = "_ID_GRA_GPO_TXT_3";
        this._ID_GRA_GPO_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_GRA_GPO_TXT_3.Size = new System.Drawing.Size(59, 15);
        this._ID_GRA_GPO_TXT_3.TabIndex = 4;
        this._ID_GRA_GPO_TXT_3.Tag = "";
        this._ID_GRA_GPO_TXT_3.Text = "&Tipo";
        // 
        // _ID_GRA_GPO_TXT_2
        // 
        this._ID_GRA_GPO_TXT_2.BackColor = System.Drawing.Color.Silver;
        this._ID_GRA_GPO_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_GRA_GPO_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_GRA_GPO_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_GRA_GPO_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_GRA_GPO_TXT_2.Location = new System.Drawing.Point(217, 54);
        this._ID_GRA_GPO_TXT_2.Name = "_ID_GRA_GPO_TXT_2";
        this._ID_GRA_GPO_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_GRA_GPO_TXT_2.Size = new System.Drawing.Size(51, 15);
        this._ID_GRA_GPO_TXT_2.TabIndex = 3;
        this._ID_GRA_GPO_TXT_2.Tag = "";
        this._ID_GRA_GPO_TXT_2.Text = "&Empresa";
        this._ID_GRA_GPO_TXT_2.Visible = false;
        // 
        // ID_GRA_AIN_MEB
        // 
        this.ID_GRA_AIN_MEB.Location = new System.Drawing.Point(148, 3);
        this.ID_GRA_AIN_MEB.Name = "ID_GRA_AIN_MEB";
        this.ID_GRA_AIN_MEB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_AIN_MEB.OcxState")));
        this.ID_GRA_AIN_MEB.Size = new System.Drawing.Size(56, 22);
        this.ID_GRA_AIN_MEB.TabIndex = 20;
        this.ID_GRA_AIN_MEB.Tag = "";
        this.ID_GRA_AIN_MEB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_GRA_AIN_MEB_KeyPressEvent);
        // 
        // ID_GRA_MFI_MEB
        // 
        this.ID_GRA_MFI_MEB.Location = new System.Drawing.Point(379, 25);
        this.ID_GRA_MFI_MEB.Name = "ID_GRA_MFI_MEB";
        this.ID_GRA_MFI_MEB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_MFI_MEB.OcxState")));
        this.ID_GRA_MFI_MEB.Size = new System.Drawing.Size(46, 22);
        this.ID_GRA_MFI_MEB.TabIndex = 23;
        this.ID_GRA_MFI_MEB.Tag = "";
        this.ID_GRA_MFI_MEB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_GRA_MFI_MEB_KeyPressEvent);
        // 
        // ID_GRA_MIN_MEB
        // 
        this.ID_GRA_MIN_MEB.Location = new System.Drawing.Point(379, 2);
        this.ID_GRA_MIN_MEB.Name = "ID_GRA_MIN_MEB";
        this.ID_GRA_MIN_MEB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_MIN_MEB.OcxState")));
        this.ID_GRA_MIN_MEB.Size = new System.Drawing.Size(46, 22);
        this.ID_GRA_MIN_MEB.TabIndex = 22;
        this.ID_GRA_MIN_MEB.Tag = "";
        this.ID_GRA_MIN_MEB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_GRA_MIN_MEB_KeyPressEvent);
        this.ID_GRA_MIN_MEB.Change += new System.EventHandler(this.ID_GRA_MIN_MEB_Change);
        // 
        // ID_GRA_AFI_MEB
        // 
        this.ID_GRA_AFI_MEB.Location = new System.Drawing.Point(148, 26);
        this.ID_GRA_AFI_MEB.Name = "ID_GRA_AFI_MEB";
        this.ID_GRA_AFI_MEB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_AFI_MEB.OcxState")));
        this.ID_GRA_AFI_MEB.Size = new System.Drawing.Size(56, 22);
        this.ID_GRA_AFI_MEB.TabIndex = 21;
        this.ID_GRA_AFI_MEB.Tag = "";
        this.ID_GRA_AFI_MEB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_GRA_AFI_MEB_KeyPressEvent);
        this.ID_GRA_AFI_MEB.Change += new System.EventHandler(this.ID_GRA_AFI_MEB_Change);
        // 
        // ID_GRA_PRI1_PNL
        // 
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_OK_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_CAN_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_IMP_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_GPH);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_GRP_PNL);
        this.ID_GRA_PRI1_PNL.Location = new System.Drawing.Point(0, 82);
        this.ID_GRA_PRI1_PNL.Name = "ID_GRA_PRI1_PNL";
        this.ID_GRA_PRI1_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PRI1_PNL.OcxState")));
        this.ID_GRA_PRI1_PNL.Size = new System.Drawing.Size(534, 269);
        this.ID_GRA_PRI1_PNL.TabIndex = 15;
        this.ID_GRA_PRI1_PNL.Tag = "";
        // 
        // ID_GRA_OK_PB
        // 
        this.ID_GRA_OK_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_OK_PB.Location = new System.Drawing.Point(292, 239);
        this.ID_GRA_OK_PB.Name = "ID_GRA_OK_PB";
        this.ID_GRA_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_OK_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_OK_PB.TabIndex = 9;
        this.ID_GRA_OK_PB.Tag = "";
        this.ID_GRA_OK_PB.Text = "Graficar";
        this.ID_GRA_OK_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_OK_PB.Click += new System.EventHandler(this.ID_GRA_OK_PB_Click);
        // 
        // ID_GRA_CAN_PB
        // 
        this.ID_GRA_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_GRA_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_CAN_PB.Location = new System.Drawing.Point(438, 239);
        this.ID_GRA_CAN_PB.Name = "ID_GRA_CAN_PB";
        this.ID_GRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_CAN_PB.TabIndex = 10;
        this.ID_GRA_CAN_PB.Tag = "";
        this.ID_GRA_CAN_PB.Text = "Cerrar";
        this.ID_GRA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_CAN_PB.Click += new System.EventHandler(this.ID_GRA_CAN_PB_Click);
        // 
        // ID_GRA_IMP_PB
        // 
        this.ID_GRA_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_IMP_PB.Location = new System.Drawing.Point(365, 239);
        this.ID_GRA_IMP_PB.Name = "ID_GRA_IMP_PB";
        this.ID_GRA_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_IMP_PB.TabIndex = 11;
        this.ID_GRA_IMP_PB.Tag = "";
        this.ID_GRA_IMP_PB.Text = "Imprimir";
        this.ID_GRA_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_IMP_PB.Click += new System.EventHandler(this.ID_GRA_IMP_PB_Click);
        // 
        // ID_GRA_GPH
        // 
        this.ID_GRA_GPH.Location = new System.Drawing.Point(18, 16);
        this.ID_GRA_GPH.Name = "ID_GRA_GPH";
        this.ID_GRA_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_GPH.OcxState")));
        this.ID_GRA_GPH.Size = new System.Drawing.Size(500, 199);
        this.ID_GRA_GPH.TabIndex = 16;
        this.ID_GRA_GPH.Tag = "";
        this.ID_GRA_GPH.DblClick += new System.EventHandler(this.ID_GRA_GPH_DblClick);
        // 
        // ID_GRA_GRP_PNL
        // 
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_CEE_GRA_GPB_2);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_CEE_GRA_GPB_3);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_CEE_GRA_GPB_0);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_CEE_GRA_GPB_1);
        this.ID_GRA_GRP_PNL.Location = new System.Drawing.Point(17, 222);
        this.ID_GRA_GRP_PNL.Name = "ID_GRA_GRP_PNL";
        this.ID_GRA_GRP_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_GRP_PNL.OcxState")));
        this.ID_GRA_GRP_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_GRA_GRP_PNL.TabIndex = 18;
        this.ID_GRA_GRP_PNL.Tag = "";
        // 
        // _ID_CEE_GRA_GPB_2
        // 
        this._ID_CEE_GRA_GPB_2.Location = new System.Drawing.Point(76, 4);
        this._ID_CEE_GRA_GPB_2.Name = "_ID_CEE_GRA_GPB_2";
        this._ID_CEE_GRA_GPB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_GRA_GPB_2.OcxState")));
        this._ID_CEE_GRA_GPB_2.Size = new System.Drawing.Size(37, 33);
        this._ID_CEE_GRA_GPB_2.TabIndex = 17;
        this._ID_CEE_GRA_GPB_2.Tag = "";
        this._ID_CEE_GRA_GPB_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CEE_GRA_GPB_ClickEvent);
        // 
        // _ID_CEE_GRA_GPB_3
        // 
        this._ID_CEE_GRA_GPB_3.Location = new System.Drawing.Point(112, 4);
        this._ID_CEE_GRA_GPB_3.Name = "_ID_CEE_GRA_GPB_3";
        this._ID_CEE_GRA_GPB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_GRA_GPB_3.OcxState")));
        this._ID_CEE_GRA_GPB_3.Size = new System.Drawing.Size(37, 33);
        this._ID_CEE_GRA_GPB_3.TabIndex = 19;
        this._ID_CEE_GRA_GPB_3.Tag = "";
        this._ID_CEE_GRA_GPB_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CEE_GRA_GPB_ClickEvent);
        // 
        // _ID_CEE_GRA_GPB_0
        // 
        this._ID_CEE_GRA_GPB_0.Location = new System.Drawing.Point(4, 4);
        this._ID_CEE_GRA_GPB_0.Name = "_ID_CEE_GRA_GPB_0";
        this._ID_CEE_GRA_GPB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_GRA_GPB_0.OcxState")));
        this._ID_CEE_GRA_GPB_0.Size = new System.Drawing.Size(37, 33);
        this._ID_CEE_GRA_GPB_0.TabIndex = 12;
        this._ID_CEE_GRA_GPB_0.Tag = "";
        this._ID_CEE_GRA_GPB_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CEE_GRA_GPB_ClickEvent);
        // 
        // _ID_CEE_GRA_GPB_1
        // 
        this._ID_CEE_GRA_GPB_1.Location = new System.Drawing.Point(40, 4);
        this._ID_CEE_GRA_GPB_1.Name = "_ID_CEE_GRA_GPB_1";
        this._ID_CEE_GRA_GPB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_GRA_GPB_1.OcxState")));
        this._ID_CEE_GRA_GPB_1.Size = new System.Drawing.Size(37, 33);
        this._ID_CEE_GRA_GPB_1.TabIndex = 14;
        this._ID_CEE_GRA_GPB_1.Tag = "";
        this._ID_CEE_GRA_GPB_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CEE_GRA_GPB_ClickEvent);
        // 
        // CORGRANT
        // 
        this.AcceptButton = this.ID_GRA_OK_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.CancelButton = this.ID_GRA_CAN_PB;
        this.ClientSize = new System.Drawing.Size(535, 352);
        this.Controls.Add(this.ID_GRA_PRI1_PNL);
        this.Controls.Add(this.ID_GRA_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Location = new System.Drawing.Point(186, 112);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRANT";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Antigüedad de la Cuenta";
        this.Closed += new System.EventHandler(this.CORGRANT_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI_PNL)).EndInit();
        this.ID_GRA_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_IRA_CHK)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_AIN_MEB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_MFI_MEB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_MIN_MEB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_AFI_MEB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI1_PNL)).EndInit();
        this.ID_GRA_PRI1_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GPH)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GRP_PNL)).EndInit();
        this.ID_GRA_GRP_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_GRA_GPB_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_GRA_GPB_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_GRA_GPB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_GRA_GPB_1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_CEE_GRA_GPB()
	{
			this.ID_CEE_GRA_GPB[3] = _ID_CEE_GRA_GPB_3;
			this.ID_CEE_GRA_GPB[2] = _ID_CEE_GRA_GPB_2;
			this.ID_CEE_GRA_GPB[1] = _ID_CEE_GRA_GPB_1;
			this.ID_CEE_GRA_GPB[0] = _ID_CEE_GRA_GPB_0;
	}
	void  InitializeID_GRA_GPO_TXT()
	{
			this.ID_GRA_GPO_TXT[6] = _ID_GRA_GPO_TXT_6;
			this.ID_GRA_GPO_TXT[4] = _ID_GRA_GPO_TXT_4;
			this.ID_GRA_GPO_TXT[3] = _ID_GRA_GPO_TXT_3;
			this.ID_GRA_GPO_TXT[2] = _ID_GRA_GPO_TXT_2;
			this.ID_GRA_GPO_TXT[1] = _ID_GRA_GPO_TXT_1;
			this.ID_GRA_GPO_TXT[5] = _ID_GRA_GPO_TXT_5;
	}
#endregion 
}
}