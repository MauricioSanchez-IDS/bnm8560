using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTACL
	{
	
#region "Upgrade Support "
		private static CORCTACL m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTACL DefInstance
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
		public CORCTACL():base(){
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
			InitializeID_ACL_TIG_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTACL CreateInstance()
	{
			CORCTACL theInstance = new CORCTACL();
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
	public  System.Windows.Forms.ComboBox ID_ACL_EJE_COB;
	public  System.Windows.Forms.ComboBox ID_ACL_EMP_COB;
	public  System.Windows.Forms.ComboBox ID_ACL_GRU_COB;
	public  System.Windows.Forms.Button ID_ACL_CON_PB;
	public  System.Windows.Forms.Button ID_ACL_SAL_PB;
	public  System.Windows.Forms.ListBox ID_ACL_CTA_LB;
	private  System.Windows.Forms.Label _ID_ACL_TIG_PNL_1Label_Text;
	private  AxThreed.AxSSPanel _ID_ACL_TIG_PNL_1;
	private  System.Windows.Forms.Label _ID_ACL_TIG_PNL_2Label_Text;
	private  AxThreed.AxSSPanel _ID_ACL_TIG_PNL_2;
	private  System.Windows.Forms.Label _ID_ACL_TIG_PNL_0Label_Text;
	private  AxThreed.AxSSPanel _ID_ACL_TIG_PNL_0;
	public  System.Windows.Forms.Label ID_ACL_TIT_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_ACL_TIT_PNL;
	public  System.Windows.Forms.Label ID_ACL_IMP_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_ACL_IMP_PNL;
	public  System.Windows.Forms.Label ID_ACL_TITD_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_ACL_TITD_PNL;
	public  AxThreed.AxSSCheck ID_ACL_IRA_CKB;
	public  AxThreed.AxSSPanel ID_ACL_PRI_PNL;
	public AxThreed.AxSSPanel[] ID_ACL_TIG_PNL = new AxThreed.AxSSPanel[3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTACL));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_ACL_PRI_PNL = new AxThreed.AxSSPanel();
        this._ID_ACL_TIG_PNL_1 = new AxThreed.AxSSPanel();
        this._ID_ACL_TIG_PNL_1Label_Text = new System.Windows.Forms.Label();
        this._ID_ACL_TIG_PNL_2 = new AxThreed.AxSSPanel();
        this._ID_ACL_TIG_PNL_2Label_Text = new System.Windows.Forms.Label();
        this.ID_ACL_CTA_LB = new System.Windows.Forms.ListBox();
        this.ID_ACL_CON_PB = new System.Windows.Forms.Button();
        this.ID_ACL_SAL_PB = new System.Windows.Forms.Button();
        this.ID_ACL_TITD_PNL = new AxThreed.AxSSPanel();
        this.ID_ACL_TITD_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_ACL_IRA_CKB = new AxThreed.AxSSCheck();
        this.ID_ACL_IMP_PNL = new AxThreed.AxSSPanel();
        this.ID_ACL_IMP_PNLLabel_Text = new System.Windows.Forms.Label();
        this._ID_ACL_TIG_PNL_0 = new AxThreed.AxSSPanel();
        this._ID_ACL_TIG_PNL_0Label_Text = new System.Windows.Forms.Label();
        this.ID_ACL_TIT_PNL = new AxThreed.AxSSPanel();
        this.ID_ACL_TIT_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_ACL_EJE_COB = new System.Windows.Forms.ComboBox();
        this.ID_ACL_EMP_COB = new System.Windows.Forms.ComboBox();
        this.ID_ACL_GRU_COB = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_PRI_PNL)).BeginInit();
        this.ID_ACL_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_TIG_PNL_1)).BeginInit();
        this._ID_ACL_TIG_PNL_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_TIG_PNL_2)).BeginInit();
        this._ID_ACL_TIG_PNL_2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_TITD_PNL)).BeginInit();
        this.ID_ACL_TITD_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_IRA_CKB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_IMP_PNL)).BeginInit();
        this.ID_ACL_IMP_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_TIG_PNL_0)).BeginInit();
        this._ID_ACL_TIG_PNL_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_TIT_PNL)).BeginInit();
        this.ID_ACL_TIT_PNL.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_ACL_PRI_PNL
        // 
        this.ID_ACL_PRI_PNL.Controls.Add(this._ID_ACL_TIG_PNL_1);
        this.ID_ACL_PRI_PNL.Controls.Add(this._ID_ACL_TIG_PNL_2);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_CTA_LB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_CON_PB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_SAL_PB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_TITD_PNL);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_IRA_CKB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_IMP_PNL);
        this.ID_ACL_PRI_PNL.Controls.Add(this._ID_ACL_TIG_PNL_0);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_TIT_PNL);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_EJE_COB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_EMP_COB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_GRU_COB);
        this.ID_ACL_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_ACL_PRI_PNL.Name = "ID_ACL_PRI_PNL";
        this.ID_ACL_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_PRI_PNL.OcxState")));
        this.ID_ACL_PRI_PNL.Size = new System.Drawing.Size(427, 278);
        this.ID_ACL_PRI_PNL.TabIndex = 4;
        this.ID_ACL_PRI_PNL.Tag = "";
        // 
        // _ID_ACL_TIG_PNL_1
        // 
        this._ID_ACL_TIG_PNL_1.Controls.Add(this._ID_ACL_TIG_PNL_1Label_Text);
        this._ID_ACL_TIG_PNL_1.Location = new System.Drawing.Point(26, 12);
        this._ID_ACL_TIG_PNL_1.Name = "_ID_ACL_TIG_PNL_1";
        this._ID_ACL_TIG_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_TIG_PNL_1.OcxState")));
        this._ID_ACL_TIG_PNL_1.Size = new System.Drawing.Size(79, 31);
        this._ID_ACL_TIG_PNL_1.TabIndex = 0;
        this._ID_ACL_TIG_PNL_1.Tag = "";
        // 
        // _ID_ACL_TIG_PNL_1Label_Text
        // 
        this._ID_ACL_TIG_PNL_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_ACL_TIG_PNL_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_ACL_TIG_PNL_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_ACL_TIG_PNL_1Label_Text.Name = "_ID_ACL_TIG_PNL_1Label_Text";
        this._ID_ACL_TIG_PNL_1Label_Text.Size = new System.Drawing.Size(73, 25);
        this._ID_ACL_TIG_PNL_1Label_Text.TabIndex = 0;
        this._ID_ACL_TIG_PNL_1Label_Text.Tag = "";
        this._ID_ACL_TIG_PNL_1Label_Text.Text = " &Grupo";
        this._ID_ACL_TIG_PNL_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_ACL_TIG_PNL_2
        // 
        this._ID_ACL_TIG_PNL_2.Controls.Add(this._ID_ACL_TIG_PNL_2Label_Text);
        this._ID_ACL_TIG_PNL_2.Location = new System.Drawing.Point(26, 38);
        this._ID_ACL_TIG_PNL_2.Name = "_ID_ACL_TIG_PNL_2";
        this._ID_ACL_TIG_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_TIG_PNL_2.OcxState")));
        this._ID_ACL_TIG_PNL_2.Size = new System.Drawing.Size(79, 31);
        this._ID_ACL_TIG_PNL_2.TabIndex = 1;
        this._ID_ACL_TIG_PNL_2.Tag = "";
        // 
        // _ID_ACL_TIG_PNL_2Label_Text
        // 
        this._ID_ACL_TIG_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_ACL_TIG_PNL_2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_ACL_TIG_PNL_2Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_ACL_TIG_PNL_2Label_Text.Name = "_ID_ACL_TIG_PNL_2Label_Text";
        this._ID_ACL_TIG_PNL_2Label_Text.Size = new System.Drawing.Size(73, 25);
        this._ID_ACL_TIG_PNL_2Label_Text.TabIndex = 0;
        this._ID_ACL_TIG_PNL_2Label_Text.Tag = "";
        this._ID_ACL_TIG_PNL_2Label_Text.Text = " &Empresa";
        this._ID_ACL_TIG_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ID_ACL_CTA_LB
        // 
        this.ID_ACL_CTA_LB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_CTA_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_CTA_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_CTA_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_CTA_LB.Location = new System.Drawing.Point(22, 122);
        this.ID_ACL_CTA_LB.Name = "ID_ACL_CTA_LB";
        this.ID_ACL_CTA_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_CTA_LB.Size = new System.Drawing.Size(313, 108);
        this.ID_ACL_CTA_LB.TabIndex = 3;
        this.ID_ACL_CTA_LB.Tag = "";
        this.ID_ACL_CTA_LB.SelectedIndexChanged += new System.EventHandler(this.ID_ACL_CTA_LB_SelectedIndexChanged);
        // 
        // ID_ACL_CON_PB
        // 
        this.ID_ACL_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_CON_PB.Location = new System.Drawing.Point(344, 175);
        this.ID_ACL_CON_PB.Name = "ID_ACL_CON_PB";
        this.ID_ACL_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_CON_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_ACL_CON_PB.TabIndex = 6;
        this.ID_ACL_CON_PB.Tag = "";
        this.ID_ACL_CON_PB.Text = "C&onsulta";
        this.ID_ACL_CON_PB.UseVisualStyleBackColor = false;
        this.ID_ACL_CON_PB.Click += new System.EventHandler(this.ID_ACL_CON_PB_Click);
        // 
        // ID_ACL_SAL_PB
        // 
        this.ID_ACL_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_ACL_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_SAL_PB.Location = new System.Drawing.Point(344, 206);
        this.ID_ACL_SAL_PB.Name = "ID_ACL_SAL_PB";
        this.ID_ACL_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_SAL_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_ACL_SAL_PB.TabIndex = 5;
        this.ID_ACL_SAL_PB.Tag = "";
        this.ID_ACL_SAL_PB.Text = "&Salir";
        this.ID_ACL_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_ACL_SAL_PB.Click += new System.EventHandler(this.ID_ACL_SAL_PB_Click);
        // 
        // ID_ACL_TITD_PNL
        // 
        this.ID_ACL_TITD_PNL.Controls.Add(this.ID_ACL_TITD_PNLLabel_Text);
        this.ID_ACL_TITD_PNL.Location = new System.Drawing.Point(200, 97);
        this.ID_ACL_TITD_PNL.Name = "ID_ACL_TITD_PNL";
        this.ID_ACL_TITD_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_TITD_PNL.OcxState")));
        this.ID_ACL_TITD_PNL.Size = new System.Drawing.Size(138, 24);
        this.ID_ACL_TITD_PNL.TabIndex = 11;
        this.ID_ACL_TITD_PNL.Tag = "";
        // 
        // ID_ACL_TITD_PNLLabel_Text
        // 
        this.ID_ACL_TITD_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_TITD_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACL_TITD_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_ACL_TITD_PNLLabel_Text.Name = "ID_ACL_TITD_PNLLabel_Text";
        this.ID_ACL_TITD_PNLLabel_Text.Size = new System.Drawing.Size(136, 22);
        this.ID_ACL_TITD_PNLLabel_Text.TabIndex = 0;
        this.ID_ACL_TITD_PNLLabel_Text.Tag = "";
        this.ID_ACL_TITD_PNLLabel_Text.Text = "&Tipo";
        this.ID_ACL_TITD_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_ACL_IRA_CKB
        // 
        this.ID_ACL_IRA_CKB.Location = new System.Drawing.Point(24, 247);
        this.ID_ACL_IRA_CKB.Name = "ID_ACL_IRA_CKB";
        this.ID_ACL_IRA_CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_IRA_CKB.OcxState")));
        this.ID_ACL_IRA_CKB.Size = new System.Drawing.Size(216, 15);
        this.ID_ACL_IRA_CKB.TabIndex = 13;
        this.ID_ACL_IRA_CKB.Tag = "";
        this.ID_ACL_IRA_CKB.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.ID_ACL_IRA_CKB_ClickEvent);
        // 
        // ID_ACL_IMP_PNL
        // 
        this.ID_ACL_IMP_PNL.Controls.Add(this.ID_ACL_IMP_PNLLabel_Text);
        this.ID_ACL_IMP_PNL.Location = new System.Drawing.Point(90, 97);
        this.ID_ACL_IMP_PNL.Name = "ID_ACL_IMP_PNL";
        this.ID_ACL_IMP_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_IMP_PNL.OcxState")));
        this.ID_ACL_IMP_PNL.Size = new System.Drawing.Size(109, 24);
        this.ID_ACL_IMP_PNL.TabIndex = 9;
        this.ID_ACL_IMP_PNL.Tag = "";
        // 
        // ID_ACL_IMP_PNLLabel_Text
        // 
        this.ID_ACL_IMP_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_IMP_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACL_IMP_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_ACL_IMP_PNLLabel_Text.Name = "ID_ACL_IMP_PNLLabel_Text";
        this.ID_ACL_IMP_PNLLabel_Text.Size = new System.Drawing.Size(107, 22);
        this.ID_ACL_IMP_PNLLabel_Text.TabIndex = 0;
        this.ID_ACL_IMP_PNLLabel_Text.Tag = "";
        this.ID_ACL_IMP_PNLLabel_Text.Text = "&Importe";
        this.ID_ACL_IMP_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_ACL_TIG_PNL_0
        // 
        this._ID_ACL_TIG_PNL_0.Controls.Add(this._ID_ACL_TIG_PNL_0Label_Text);
        this._ID_ACL_TIG_PNL_0.Location = new System.Drawing.Point(26, 65);
        this._ID_ACL_TIG_PNL_0.Name = "_ID_ACL_TIG_PNL_0";
        this._ID_ACL_TIG_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_TIG_PNL_0.OcxState")));
        this._ID_ACL_TIG_PNL_0.Size = new System.Drawing.Size(79, 32);
        this._ID_ACL_TIG_PNL_0.TabIndex = 2;
        this._ID_ACL_TIG_PNL_0.Tag = "";
        // 
        // _ID_ACL_TIG_PNL_0Label_Text
        // 
        this._ID_ACL_TIG_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_ACL_TIG_PNL_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_ACL_TIG_PNL_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_ACL_TIG_PNL_0Label_Text.Name = "_ID_ACL_TIG_PNL_0Label_Text";
        this._ID_ACL_TIG_PNL_0Label_Text.Size = new System.Drawing.Size(73, 26);
        this._ID_ACL_TIG_PNL_0Label_Text.TabIndex = 0;
        this._ID_ACL_TIG_PNL_0Label_Text.Tag = "";
        this._ID_ACL_TIG_PNL_0Label_Text.Text = " E&jecutivo";
        this._ID_ACL_TIG_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ID_ACL_TIT_PNL
        // 
        this.ID_ACL_TIT_PNL.Controls.Add(this.ID_ACL_TIT_PNLLabel_Text);
        this.ID_ACL_TIT_PNL.Location = new System.Drawing.Point(22, 97);
        this.ID_ACL_TIT_PNL.Name = "ID_ACL_TIT_PNL";
        this.ID_ACL_TIT_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_TIT_PNL.OcxState")));
        this.ID_ACL_TIT_PNL.Size = new System.Drawing.Size(67, 24);
        this.ID_ACL_TIT_PNL.TabIndex = 7;
        this.ID_ACL_TIT_PNL.Tag = "";
        // 
        // ID_ACL_TIT_PNLLabel_Text
        // 
        this.ID_ACL_TIT_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_TIT_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACL_TIT_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_ACL_TIT_PNLLabel_Text.Name = "ID_ACL_TIT_PNLLabel_Text";
        this.ID_ACL_TIT_PNLLabel_Text.Size = new System.Drawing.Size(65, 22);
        this.ID_ACL_TIT_PNLLabel_Text.TabIndex = 0;
        this.ID_ACL_TIT_PNLLabel_Text.Tag = "";
        this.ID_ACL_TIT_PNLLabel_Text.Text = "&No. S.A.A.";
        this.ID_ACL_TIT_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_ACL_EJE_COB
        // 
        this.ID_ACL_EJE_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_EJE_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_EJE_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACL_EJE_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_EJE_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_EJE_COB.Location = new System.Drawing.Point(102, 67);
        this.ID_ACL_EJE_COB.Name = "ID_ACL_EJE_COB";
        this.ID_ACL_EJE_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_EJE_COB.Size = new System.Drawing.Size(228, 21);
        this.ID_ACL_EJE_COB.TabIndex = 12;
        this.ID_ACL_EJE_COB.Tag = "";
        this.ID_ACL_EJE_COB.SelectedIndexChanged += new System.EventHandler(this.ID_ACL_EJE_COB_SelectedIndexChanged);
        // 
        // ID_ACL_EMP_COB
        // 
        this.ID_ACL_EMP_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACL_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_EMP_COB.Location = new System.Drawing.Point(103, 40);
        this.ID_ACL_EMP_COB.Name = "ID_ACL_EMP_COB";
        this.ID_ACL_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_EMP_COB.Size = new System.Drawing.Size(227, 21);
        this.ID_ACL_EMP_COB.TabIndex = 10;
        this.ID_ACL_EMP_COB.Tag = "";
        this.ID_ACL_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_ACL_EMP_COB_SelectedIndexChanged);
        // 
        // ID_ACL_GRU_COB
        // 
        this.ID_ACL_GRU_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_GRU_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACL_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_GRU_COB.Location = new System.Drawing.Point(103, 14);
        this.ID_ACL_GRU_COB.Name = "ID_ACL_GRU_COB";
        this.ID_ACL_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_GRU_COB.Size = new System.Drawing.Size(227, 21);
        this.ID_ACL_GRU_COB.TabIndex = 8;
        this.ID_ACL_GRU_COB.Tag = "";
        this.ID_ACL_GRU_COB.SelectedIndexChanged += new System.EventHandler(this.ID_ACL_GRU_COB_SelectedIndexChanged);
        // 
        // CORCTACL
        // 
        this.AcceptButton = this.ID_ACL_CON_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.CancelButton = this.ID_ACL_SAL_PB;
        this.ClientSize = new System.Drawing.Size(429, 279);
        this.Controls.Add(this.ID_ACL_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(186, 108);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCTACL";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Consulta Histórica";
        this.Closed += new System.EventHandler(this.CORCTACL_Closed);
        this.Activated += new System.EventHandler(this.CORCTACL_Activated);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_PRI_PNL)).EndInit();
        this.ID_ACL_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_TIG_PNL_1)).EndInit();
        this._ID_ACL_TIG_PNL_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_TIG_PNL_2)).EndInit();
        this._ID_ACL_TIG_PNL_2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_TITD_PNL)).EndInit();
        this.ID_ACL_TITD_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_IRA_CKB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_IMP_PNL)).EndInit();
        this.ID_ACL_IMP_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_TIG_PNL_0)).EndInit();
        this._ID_ACL_TIG_PNL_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_TIT_PNL)).EndInit();
        this.ID_ACL_TIT_PNL.ResumeLayout(false);
        this.ResumeLayout(false);

	}
	void  InitializeID_ACL_TIG_PNL()
	{
			this.ID_ACL_TIG_PNL[1] = _ID_ACL_TIG_PNL_1;
			this.ID_ACL_TIG_PNL[2] = _ID_ACL_TIG_PNL_2;
			this.ID_ACL_TIG_PNL[0] = _ID_ACL_TIG_PNL_0;
	}
#endregion 
}
}