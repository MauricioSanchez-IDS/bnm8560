using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORMNACL
	{
	
#region "Upgrade Support "
		private static CORMNACL m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNACL DefInstance
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
		public CORMNACL():base(){
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
			InitializeID_ACL_ORI_CKB();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORMNACL CreateInstance()
	{
			CORMNACL theInstance = new CORMNACL();
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
	public  System.Windows.Forms.TextBox ID_ACL_EMP_EB;
	public  System.Windows.Forms.TextBox ID_ACL_NOM_EB;
	public  System.Windows.Forms.TextBox ID_ACL_TIP_EB;
	public  System.Windows.Forms.TextBox ID_ACL_CTA_EB;
	public  System.Windows.Forms.Button ID_ACL_ACE_PB;
	public  System.Windows.Forms.Button ID_ACL_IMP_PB;
	public  System.Windows.Forms.TextBox ID_ACL_NIV_EB;
	public  System.Windows.Forms.Label ID_ACL_NOM_TXT;
	public  System.Windows.Forms.Label ID_ACL_EMP_TXT;
	public  System.Windows.Forms.Label ID_ACL_NIV_TXT;
	public  AxThreed.AxSSFrame ID_ACL_EJE_PNL;
	public  System.Windows.Forms.TextBox ID_ACL_FECV_EB;
	public  System.Windows.Forms.TextBox ID_ACL_NREG_EB;
	public  System.Windows.Forms.TextBox ID_ACL_IMP_EB;
	public  System.Windows.Forms.TextBox ID_ACL_FEC_EB;
	private  AxThreed.AxSSCheck _ID_ACL_ORI_CKB_2;
	private  AxThreed.AxSSCheck _ID_ACL_ORI_CKB_1;
	private  AxThreed.AxSSCheck _ID_ACL_ORI_CKB_0;
	public  AxThreed.AxSSPanel ID_ACL_ORI_PNL;
	public  System.Windows.Forms.Label ID_ACL_FEC_TXT;
	public  System.Windows.Forms.Label ID_ACL_IMP_TXT;
	public  System.Windows.Forms.Label ID_ACL_NREG_TXT;
	public  System.Windows.Forms.Label ID_ACL_FECV_TXT;
	public  System.Windows.Forms.Label ID_ACL_ORI_TXT;
	public  AxThreed.AxSSFrame ID_ACL_ABO_PNL;
	public  System.Windows.Forms.TextBox ID_ACL_PEN_EB;
	public  System.Windows.Forms.TextBox ID_ACL_CLI_EB;
	public  System.Windows.Forms.TextBox ID_ACL_BAN_EB;
	public  System.Windows.Forms.TextBox ID_ACL_NUM_EB;
	public  System.Windows.Forms.Label ID_ACL_NUM_TXT;
	public  System.Windows.Forms.Label ID_ACL_BAN_TXT;
	public  System.Windows.Forms.Label ID_ACL_CLI_TXT;
	public  System.Windows.Forms.Label ID_ACL_PEN_TXT;
	public  AxThreed.AxSSFrame ID_ACL_HIS_PNL;
	public  System.Windows.Forms.TextBox ID_ACL_RES_EB;
	public  System.Windows.Forms.TextBox ID_ACL_IMPA_EB;
	public  System.Windows.Forms.TextBox ID_ACL_FECA_EB;
	public  System.Windows.Forms.Label ID_ACL_FECA_TXT;
	public  System.Windows.Forms.Label ID_ACL_IMPA_TXT;
	public  System.Windows.Forms.Label ID_ACL_RES_TXT;
	public  AxThreed.AxSSFrame ID_ACL_ABD_PNL;
	public  System.Windows.Forms.Label ID_ACL_CTA_TXT;
	public  System.Windows.Forms.Label ID_ACL_TIP_TXT;
	public  AxThreed.AxSSPanel ID_ACL_PRI_PNL;
	public AxThreed.AxSSCheck[] ID_ACL_ORI_CKB = new AxThreed.AxSSCheck[3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNACL));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_ACL_EMP_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_NOM_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_ACL_EJE_PNL = new AxThreed.AxSSFrame();
        this.ID_ACL_NOM_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_NIV_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_NIV_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_EMP_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_ABO_PNL = new AxThreed.AxSSFrame();
        this.ID_ACL_ORI_PNL = new AxThreed.AxSSPanel();
        this._ID_ACL_ORI_CKB_2 = new AxThreed.AxSSCheck();
        this._ID_ACL_ORI_CKB_1 = new AxThreed.AxSSCheck();
        this._ID_ACL_ORI_CKB_0 = new AxThreed.AxSSCheck();
        this.ID_ACL_FEC_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_IMP_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_FEC_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_FECV_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_ORI_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_IMP_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_NREG_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_FECV_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_NREG_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_ACE_PB = new System.Windows.Forms.Button();
        this.ID_ACL_IMP_PB = new System.Windows.Forms.Button();
        this.ID_ACL_CTA_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_TIP_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_HIS_PNL = new AxThreed.AxSSFrame();
        this.ID_ACL_NUM_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_BAN_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_CLI_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_NUM_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_PEN_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_CLI_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_BAN_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_PEN_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_ABD_PNL = new AxThreed.AxSSFrame();
        this.ID_ACL_FECA_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_IMPA_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_RES_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_FECA_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_RES_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_IMPA_TXT = new System.Windows.Forms.Label();
        this.ID_ACL_TIP_EB = new System.Windows.Forms.TextBox();
        this.ID_ACL_CTA_EB = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_PRI_PNL)).BeginInit();
        this.ID_ACL_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_EJE_PNL)).BeginInit();
        this.ID_ACL_EJE_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_ABO_PNL)).BeginInit();
        this.ID_ACL_ABO_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_ORI_PNL)).BeginInit();
        this.ID_ACL_ORI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_ORI_CKB_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_ORI_CKB_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_ORI_CKB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_HIS_PNL)).BeginInit();
        this.ID_ACL_HIS_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_ABD_PNL)).BeginInit();
        this.ID_ACL_ABD_PNL.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_ACL_EMP_EB
        // 
        this.ID_ACL_EMP_EB.AcceptsReturn = true;
        this.ID_ACL_EMP_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_EMP_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_EMP_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_EMP_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_EMP_EB.Location = new System.Drawing.Point(86, 83);
        this.ID_ACL_EMP_EB.MaxLength = 0;
        this.ID_ACL_EMP_EB.Name = "ID_ACL_EMP_EB";
        this.ID_ACL_EMP_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_EMP_EB.Size = new System.Drawing.Size(236, 19);
        this.ID_ACL_EMP_EB.TabIndex = 10;
        this.ID_ACL_EMP_EB.Tag = "";
        // 
        // ID_ACL_NOM_EB
        // 
        this.ID_ACL_NOM_EB.AcceptsReturn = true;
        this.ID_ACL_NOM_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_NOM_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_NOM_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_NOM_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_NOM_EB.Location = new System.Drawing.Point(86, 56);
        this.ID_ACL_NOM_EB.MaxLength = 0;
        this.ID_ACL_NOM_EB.Name = "ID_ACL_NOM_EB";
        this.ID_ACL_NOM_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_NOM_EB.Size = new System.Drawing.Size(237, 19);
        this.ID_ACL_NOM_EB.TabIndex = 8;
        this.ID_ACL_NOM_EB.Tag = "";
        // 
        // ID_ACL_PRI_PNL
        // 
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_EJE_PNL);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_ABO_PNL);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_ACE_PB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_IMP_PB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_TIP_TXT);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_HIS_PNL);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_ABD_PNL);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_TIP_EB);
        this.ID_ACL_PRI_PNL.Controls.Add(this.ID_ACL_CTA_EB);
        this.ID_ACL_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_ACL_PRI_PNL.Name = "ID_ACL_PRI_PNL";
        this.ID_ACL_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_PRI_PNL.OcxState")));
        this.ID_ACL_PRI_PNL.Size = new System.Drawing.Size(530, 344);
        this.ID_ACL_PRI_PNL.TabIndex = 0;
        this.ID_ACL_PRI_PNL.Tag = "";
        // 
        // ID_ACL_EJE_PNL
        // 
        this.ID_ACL_EJE_PNL.Controls.Add(this.ID_ACL_NOM_TXT);
        this.ID_ACL_EJE_PNL.Controls.Add(this.ID_ACL_NIV_EB);
        this.ID_ACL_EJE_PNL.Controls.Add(this.ID_ACL_NIV_TXT);
        this.ID_ACL_EJE_PNL.Controls.Add(this.ID_ACL_EMP_TXT);
        this.ID_ACL_EJE_PNL.Location = new System.Drawing.Point(14, 37);
        this.ID_ACL_EJE_PNL.Name = "ID_ACL_EJE_PNL";
        this.ID_ACL_EJE_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_EJE_PNL.OcxState")));
        this.ID_ACL_EJE_PNL.Size = new System.Drawing.Size(331, 103);
        this.ID_ACL_EJE_PNL.TabIndex = 5;
        this.ID_ACL_EJE_PNL.Tag = "";
        // 
        // ID_ACL_NOM_TXT
        // 
        this.ID_ACL_NOM_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_NOM_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_NOM_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_NOM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_NOM_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_NOM_TXT.Location = new System.Drawing.Point(14, 22);
        this.ID_ACL_NOM_TXT.Name = "ID_ACL_NOM_TXT";
        this.ID_ACL_NOM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_NOM_TXT.Size = new System.Drawing.Size(49, 17);
        this.ID_ACL_NOM_TXT.TabIndex = 6;
        this.ID_ACL_NOM_TXT.Tag = "";
        this.ID_ACL_NOM_TXT.Text = "&Nombre";
        // 
        // ID_ACL_NIV_EB
        // 
        this.ID_ACL_NIV_EB.AcceptsReturn = true;
        this.ID_ACL_NIV_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_NIV_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_NIV_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_NIV_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_NIV_EB.Location = new System.Drawing.Point(111, 72);
        this.ID_ACL_NIV_EB.MaxLength = 0;
        this.ID_ACL_NIV_EB.Name = "ID_ACL_NIV_EB";
        this.ID_ACL_NIV_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_NIV_EB.Size = new System.Drawing.Size(31, 19);
        this.ID_ACL_NIV_EB.TabIndex = 11;
        this.ID_ACL_NIV_EB.Tag = "";
        // 
        // ID_ACL_NIV_TXT
        // 
        this.ID_ACL_NIV_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_NIV_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_NIV_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_NIV_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_NIV_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_NIV_TXT.Location = new System.Drawing.Point(14, 73);
        this.ID_ACL_NIV_TXT.Name = "ID_ACL_NIV_TXT";
        this.ID_ACL_NIV_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_NIV_TXT.Size = new System.Drawing.Size(99, 17);
        this.ID_ACL_NIV_TXT.TabIndex = 9;
        this.ID_ACL_NIV_TXT.Tag = "";
        this.ID_ACL_NIV_TXT.Text = "Nivel &Jerárquico";
        // 
        // ID_ACL_EMP_TXT
        // 
        this.ID_ACL_EMP_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_EMP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_EMP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_EMP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_EMP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_EMP_TXT.Location = new System.Drawing.Point(14, 48);
        this.ID_ACL_EMP_TXT.Name = "ID_ACL_EMP_TXT";
        this.ID_ACL_EMP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_EMP_TXT.Size = new System.Drawing.Size(49, 17);
        this.ID_ACL_EMP_TXT.TabIndex = 7;
        this.ID_ACL_EMP_TXT.Tag = "";
        this.ID_ACL_EMP_TXT.Text = "&Empresa";
        // 
        // ID_ACL_ABO_PNL
        // 
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_ORI_PNL);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_FEC_TXT);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_IMP_EB);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_FEC_EB);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_FECV_TXT);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_ORI_TXT);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_IMP_TXT);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_NREG_TXT);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_FECV_EB);
        this.ID_ACL_ABO_PNL.Controls.Add(this.ID_ACL_NREG_EB);
        this.ID_ACL_ABO_PNL.Location = new System.Drawing.Point(18, 172);
        this.ID_ACL_ABO_PNL.Name = "ID_ACL_ABO_PNL";
        this.ID_ACL_ABO_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_ABO_PNL.OcxState")));
        this.ID_ACL_ABO_PNL.Size = new System.Drawing.Size(329, 159);
        this.ID_ACL_ABO_PNL.TabIndex = 15;
        this.ID_ACL_ABO_PNL.Tag = "";
        // 
        // ID_ACL_ORI_PNL
        // 
        this.ID_ACL_ORI_PNL.Controls.Add(this._ID_ACL_ORI_CKB_2);
        this.ID_ACL_ORI_PNL.Controls.Add(this._ID_ACL_ORI_CKB_1);
        this.ID_ACL_ORI_PNL.Controls.Add(this._ID_ACL_ORI_CKB_0);
        this.ID_ACL_ORI_PNL.Location = new System.Drawing.Point(60, 126);
        this.ID_ACL_ORI_PNL.Name = "ID_ACL_ORI_PNL";
        this.ID_ACL_ORI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_ORI_PNL.OcxState")));
        this.ID_ACL_ORI_PNL.Size = new System.Drawing.Size(261, 27);
        this.ID_ACL_ORI_PNL.TabIndex = 24;
        this.ID_ACL_ORI_PNL.Tag = "";
        // 
        // _ID_ACL_ORI_CKB_2
        // 
        this._ID_ACL_ORI_CKB_2.Location = new System.Drawing.Point(176, 6);
        this._ID_ACL_ORI_CKB_2.Name = "_ID_ACL_ORI_CKB_2";
        this._ID_ACL_ORI_CKB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_ORI_CKB_2.OcxState")));
        this._ID_ACL_ORI_CKB_2.Size = new System.Drawing.Size(79, 17);
        this._ID_ACL_ORI_CKB_2.TabIndex = 27;
        this._ID_ACL_ORI_CKB_2.Tag = "";
        // 
        // _ID_ACL_ORI_CKB_1
        // 
        this._ID_ACL_ORI_CKB_1.Location = new System.Drawing.Point(90, 6);
        this._ID_ACL_ORI_CKB_1.Name = "_ID_ACL_ORI_CKB_1";
        this._ID_ACL_ORI_CKB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_ORI_CKB_1.OcxState")));
        this._ID_ACL_ORI_CKB_1.Size = new System.Drawing.Size(79, 17);
        this._ID_ACL_ORI_CKB_1.TabIndex = 26;
        this._ID_ACL_ORI_CKB_1.Tag = "";
        // 
        // _ID_ACL_ORI_CKB_0
        // 
        this._ID_ACL_ORI_CKB_0.Location = new System.Drawing.Point(8, 6);
        this._ID_ACL_ORI_CKB_0.Name = "_ID_ACL_ORI_CKB_0";
        this._ID_ACL_ORI_CKB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_ACL_ORI_CKB_0.OcxState")));
        this._ID_ACL_ORI_CKB_0.Size = new System.Drawing.Size(77, 17);
        this._ID_ACL_ORI_CKB_0.TabIndex = 25;
        this._ID_ACL_ORI_CKB_0.Tag = "";
        // 
        // ID_ACL_FEC_TXT
        // 
        this.ID_ACL_FEC_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_FEC_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_FEC_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_FEC_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_FEC_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_FEC_TXT.Location = new System.Drawing.Point(13, 27);
        this.ID_ACL_FEC_TXT.Name = "ID_ACL_FEC_TXT";
        this.ID_ACL_FEC_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_FEC_TXT.Size = new System.Drawing.Size(49, 17);
        this.ID_ACL_FEC_TXT.TabIndex = 19;
        this.ID_ACL_FEC_TXT.Tag = "";
        this.ID_ACL_FEC_TXT.Text = "&Fecha";
        // 
        // ID_ACL_IMP_EB
        // 
        this.ID_ACL_IMP_EB.AcceptsReturn = true;
        this.ID_ACL_IMP_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_IMP_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_IMP_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_IMP_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_IMP_EB.Location = new System.Drawing.Point(104, 50);
        this.ID_ACL_IMP_EB.MaxLength = 0;
        this.ID_ACL_IMP_EB.Name = "ID_ACL_IMP_EB";
        this.ID_ACL_IMP_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_IMP_EB.Size = new System.Drawing.Size(89, 19);
        this.ID_ACL_IMP_EB.TabIndex = 21;
        this.ID_ACL_IMP_EB.Tag = "";
        // 
        // ID_ACL_FEC_EB
        // 
        this.ID_ACL_FEC_EB.AcceptsReturn = true;
        this.ID_ACL_FEC_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_FEC_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_FEC_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_FEC_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_FEC_EB.Location = new System.Drawing.Point(104, 25);
        this.ID_ACL_FEC_EB.MaxLength = 0;
        this.ID_ACL_FEC_EB.Name = "ID_ACL_FEC_EB";
        this.ID_ACL_FEC_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_FEC_EB.Size = new System.Drawing.Size(89, 19);
        this.ID_ACL_FEC_EB.TabIndex = 20;
        this.ID_ACL_FEC_EB.Tag = "";
        // 
        // ID_ACL_FECV_TXT
        // 
        this.ID_ACL_FECV_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_FECV_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_FECV_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_FECV_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_FECV_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_FECV_TXT.Location = new System.Drawing.Point(12, 109);
        this.ID_ACL_FECV_TXT.Name = "ID_ACL_FECV_TXT";
        this.ID_ACL_FECV_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_FECV_TXT.Size = new System.Drawing.Size(131, 17);
        this.ID_ACL_FECV_TXT.TabIndex = 16;
        this.ID_ACL_FECV_TXT.Tag = "";
        this.ID_ACL_FECV_TXT.Text = "Fecha de &Vencimiento";
        // 
        // ID_ACL_ORI_TXT
        // 
        this.ID_ACL_ORI_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_ORI_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_ORI_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_ORI_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_ORI_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_ORI_TXT.Location = new System.Drawing.Point(13, 134);
        this.ID_ACL_ORI_TXT.Name = "ID_ACL_ORI_TXT";
        this.ID_ACL_ORI_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_ORI_TXT.Size = new System.Drawing.Size(45, 13);
        this.ID_ACL_ORI_TXT.TabIndex = 14;
        this.ID_ACL_ORI_TXT.Tag = "";
        this.ID_ACL_ORI_TXT.Text = "&Origen";
        // 
        // ID_ACL_IMP_TXT
        // 
        this.ID_ACL_IMP_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_IMP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_IMP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_IMP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_IMP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_IMP_TXT.Location = new System.Drawing.Point(13, 53);
        this.ID_ACL_IMP_TXT.Name = "ID_ACL_IMP_TXT";
        this.ID_ACL_IMP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_IMP_TXT.Size = new System.Drawing.Size(49, 17);
        this.ID_ACL_IMP_TXT.TabIndex = 18;
        this.ID_ACL_IMP_TXT.Tag = "";
        this.ID_ACL_IMP_TXT.Text = "&Importe";
        // 
        // ID_ACL_NREG_TXT
        // 
        this.ID_ACL_NREG_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_NREG_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_NREG_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_NREG_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_NREG_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_NREG_TXT.Location = new System.Drawing.Point(13, 82);
        this.ID_ACL_NREG_TXT.Name = "ID_ACL_NREG_TXT";
        this.ID_ACL_NREG_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_NREG_TXT.Size = new System.Drawing.Size(149, 17);
        this.ID_ACL_NREG_TXT.TabIndex = 17;
        this.ID_ACL_NREG_TXT.Tag = "";
        this.ID_ACL_NREG_TXT.Text = "&No. de Registro en S.S.A.";
        // 
        // ID_ACL_FECV_EB
        // 
        this.ID_ACL_FECV_EB.AcceptsReturn = true;
        this.ID_ACL_FECV_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_FECV_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_FECV_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_FECV_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_FECV_EB.Location = new System.Drawing.Point(170, 102);
        this.ID_ACL_FECV_EB.MaxLength = 0;
        this.ID_ACL_FECV_EB.Name = "ID_ACL_FECV_EB";
        this.ID_ACL_FECV_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_FECV_EB.Size = new System.Drawing.Size(91, 19);
        this.ID_ACL_FECV_EB.TabIndex = 23;
        this.ID_ACL_FECV_EB.Tag = "";
        // 
        // ID_ACL_NREG_EB
        // 
        this.ID_ACL_NREG_EB.AcceptsReturn = true;
        this.ID_ACL_NREG_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_NREG_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_NREG_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_NREG_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_NREG_EB.Location = new System.Drawing.Point(170, 77);
        this.ID_ACL_NREG_EB.MaxLength = 0;
        this.ID_ACL_NREG_EB.Name = "ID_ACL_NREG_EB";
        this.ID_ACL_NREG_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_NREG_EB.Size = new System.Drawing.Size(91, 19);
        this.ID_ACL_NREG_EB.TabIndex = 22;
        this.ID_ACL_NREG_EB.Tag = "";
        // 
        // ID_ACL_ACE_PB
        // 
        this.ID_ACL_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_ACE_PB.Location = new System.Drawing.Point(441, 302);
        this.ID_ACL_ACE_PB.Name = "ID_ACL_ACE_PB";
        this.ID_ACL_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_ACE_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_ACL_ACE_PB.TabIndex = 3;
        this.ID_ACL_ACE_PB.Tag = "";
        this.ID_ACL_ACE_PB.Text = "Salir";
        this.ID_ACL_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_ACL_ACE_PB.Click += new System.EventHandler(this.ID_ACL_ACE_PB_Click);
        // 
        // ID_ACL_IMP_PB
        // 
        this.ID_ACL_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_IMP_PB.Location = new System.Drawing.Point(360, 302);
        this.ID_ACL_IMP_PB.Name = "ID_ACL_IMP_PB";
        this.ID_ACL_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_IMP_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_ACL_IMP_PB.TabIndex = 2;
        this.ID_ACL_IMP_PB.Tag = "";
        this.ID_ACL_IMP_PB.Text = "&Imprimir";
        this.ID_ACL_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_ACL_IMP_PB.Click += new System.EventHandler(this.ID_ACL_IMP_PB_Click);
        // 
        // ID_ACL_CTA_TXT
        // 
        this.ID_ACL_CTA_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_ACL_CTA_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_CTA_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_CTA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_CTA_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_CTA_TXT.Location = new System.Drawing.Point(152, 15);
        this.ID_ACL_CTA_TXT.Name = "ID_ACL_CTA_TXT";
        this.ID_ACL_CTA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_CTA_TXT.Size = new System.Drawing.Size(47, 17);
        this.ID_ACL_CTA_TXT.TabIndex = 1;
        this.ID_ACL_CTA_TXT.Tag = "";
        this.ID_ACL_CTA_TXT.Text = "&Cuenta";
        // 
        // ID_ACL_TIP_TXT
        // 
        this.ID_ACL_TIP_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_ACL_TIP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_TIP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_TIP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_TIP_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_TIP_TXT.Location = new System.Drawing.Point(25, 153);
        this.ID_ACL_TIP_TXT.Name = "ID_ACL_TIP_TXT";
        this.ID_ACL_TIP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_TIP_TXT.Size = new System.Drawing.Size(111, 17);
        this.ID_ACL_TIP_TXT.TabIndex = 12;
        this.ID_ACL_TIP_TXT.Tag = "";
        this.ID_ACL_TIP_TXT.Text = "&Tipo de Aclaración";
        // 
        // ID_ACL_HIS_PNL
        // 
        this.ID_ACL_HIS_PNL.Controls.Add(this.ID_ACL_NUM_EB);
        this.ID_ACL_HIS_PNL.Controls.Add(this.ID_ACL_BAN_EB);
        this.ID_ACL_HIS_PNL.Controls.Add(this.ID_ACL_CLI_EB);
        this.ID_ACL_HIS_PNL.Controls.Add(this.ID_ACL_NUM_TXT);
        this.ID_ACL_HIS_PNL.Controls.Add(this.ID_ACL_PEN_TXT);
        this.ID_ACL_HIS_PNL.Controls.Add(this.ID_ACL_CLI_TXT);
        this.ID_ACL_HIS_PNL.Controls.Add(this.ID_ACL_BAN_TXT);
        this.ID_ACL_HIS_PNL.Controls.Add(this.ID_ACL_PEN_EB);
        this.ID_ACL_HIS_PNL.Location = new System.Drawing.Point(356, 37);
        this.ID_ACL_HIS_PNL.Name = "ID_ACL_HIS_PNL";
        this.ID_ACL_HIS_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_HIS_PNL.OcxState")));
        this.ID_ACL_HIS_PNL.Size = new System.Drawing.Size(161, 133);
        this.ID_ACL_HIS_PNL.TabIndex = 28;
        this.ID_ACL_HIS_PNL.Tag = "";
        // 
        // ID_ACL_NUM_EB
        // 
        this.ID_ACL_NUM_EB.AcceptsReturn = true;
        this.ID_ACL_NUM_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_NUM_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_NUM_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_NUM_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_NUM_EB.Location = new System.Drawing.Point(81, 18);
        this.ID_ACL_NUM_EB.MaxLength = 0;
        this.ID_ACL_NUM_EB.Name = "ID_ACL_NUM_EB";
        this.ID_ACL_NUM_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_NUM_EB.Size = new System.Drawing.Size(27, 19);
        this.ID_ACL_NUM_EB.TabIndex = 33;
        this.ID_ACL_NUM_EB.Tag = "";
        // 
        // ID_ACL_BAN_EB
        // 
        this.ID_ACL_BAN_EB.AcceptsReturn = true;
        this.ID_ACL_BAN_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_BAN_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_BAN_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_BAN_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_BAN_EB.Location = new System.Drawing.Point(81, 44);
        this.ID_ACL_BAN_EB.MaxLength = 0;
        this.ID_ACL_BAN_EB.Name = "ID_ACL_BAN_EB";
        this.ID_ACL_BAN_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_BAN_EB.Size = new System.Drawing.Size(27, 19);
        this.ID_ACL_BAN_EB.TabIndex = 34;
        this.ID_ACL_BAN_EB.Tag = "";
        // 
        // ID_ACL_CLI_EB
        // 
        this.ID_ACL_CLI_EB.AcceptsReturn = true;
        this.ID_ACL_CLI_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_CLI_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_CLI_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_CLI_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_CLI_EB.Location = new System.Drawing.Point(81, 70);
        this.ID_ACL_CLI_EB.MaxLength = 0;
        this.ID_ACL_CLI_EB.Name = "ID_ACL_CLI_EB";
        this.ID_ACL_CLI_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_CLI_EB.Size = new System.Drawing.Size(27, 19);
        this.ID_ACL_CLI_EB.TabIndex = 35;
        this.ID_ACL_CLI_EB.Tag = "";
        // 
        // ID_ACL_NUM_TXT
        // 
        this.ID_ACL_NUM_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_NUM_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_NUM_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_NUM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_NUM_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_NUM_TXT.Location = new System.Drawing.Point(11, 21);
        this.ID_ACL_NUM_TXT.Name = "ID_ACL_NUM_TXT";
        this.ID_ACL_NUM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_NUM_TXT.Size = new System.Drawing.Size(49, 17);
        this.ID_ACL_NUM_TXT.TabIndex = 32;
        this.ID_ACL_NUM_TXT.Tag = "";
        this.ID_ACL_NUM_TXT.Text = "&Número";
        // 
        // ID_ACL_PEN_TXT
        // 
        this.ID_ACL_PEN_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_PEN_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_PEN_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_PEN_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_PEN_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_PEN_TXT.Location = new System.Drawing.Point(10, 101);
        this.ID_ACL_PEN_TXT.Name = "ID_ACL_PEN_TXT";
        this.ID_ACL_PEN_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_PEN_TXT.Size = new System.Drawing.Size(57, 17);
        this.ID_ACL_PEN_TXT.TabIndex = 29;
        this.ID_ACL_PEN_TXT.Tag = "";
        this.ID_ACL_PEN_TXT.Text = "&Pendiente";
        // 
        // ID_ACL_CLI_TXT
        // 
        this.ID_ACL_CLI_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_CLI_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_CLI_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_CLI_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_CLI_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_CLI_TXT.Location = new System.Drawing.Point(12, 73);
        this.ID_ACL_CLI_TXT.Name = "ID_ACL_CLI_TXT";
        this.ID_ACL_CLI_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_CLI_TXT.Size = new System.Drawing.Size(49, 17);
        this.ID_ACL_CLI_TXT.TabIndex = 30;
        this.ID_ACL_CLI_TXT.Tag = "";
        this.ID_ACL_CLI_TXT.Text = "&Cliente";
        // 
        // ID_ACL_BAN_TXT
        // 
        this.ID_ACL_BAN_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_BAN_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_BAN_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_BAN_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_BAN_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_BAN_TXT.Location = new System.Drawing.Point(10, 47);
        this.ID_ACL_BAN_TXT.Name = "ID_ACL_BAN_TXT";
        this.ID_ACL_BAN_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_BAN_TXT.Size = new System.Drawing.Size(49, 17);
        this.ID_ACL_BAN_TXT.TabIndex = 31;
        this.ID_ACL_BAN_TXT.Tag = "";
        this.ID_ACL_BAN_TXT.Text = "&Banco";
        // 
        // ID_ACL_PEN_EB
        // 
        this.ID_ACL_PEN_EB.AcceptsReturn = true;
        this.ID_ACL_PEN_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_PEN_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_PEN_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_PEN_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_PEN_EB.Location = new System.Drawing.Point(81, 97);
        this.ID_ACL_PEN_EB.MaxLength = 0;
        this.ID_ACL_PEN_EB.Name = "ID_ACL_PEN_EB";
        this.ID_ACL_PEN_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_PEN_EB.Size = new System.Drawing.Size(27, 19);
        this.ID_ACL_PEN_EB.TabIndex = 36;
        this.ID_ACL_PEN_EB.Tag = "";
        // 
        // ID_ACL_ABD_PNL
        // 
        this.ID_ACL_ABD_PNL.Controls.Add(this.ID_ACL_FECA_EB);
        this.ID_ACL_ABD_PNL.Controls.Add(this.ID_ACL_IMPA_EB);
        this.ID_ACL_ABD_PNL.Controls.Add(this.ID_ACL_RES_EB);
        this.ID_ACL_ABD_PNL.Controls.Add(this.ID_ACL_FECA_TXT);
        this.ID_ACL_ABD_PNL.Controls.Add(this.ID_ACL_RES_TXT);
        this.ID_ACL_ABD_PNL.Controls.Add(this.ID_ACL_IMPA_TXT);
        this.ID_ACL_ABD_PNL.Location = new System.Drawing.Point(356, 172);
        this.ID_ACL_ABD_PNL.Name = "ID_ACL_ABD_PNL";
        this.ID_ACL_ABD_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_ABD_PNL.OcxState")));
        this.ID_ACL_ABD_PNL.Size = new System.Drawing.Size(161, 116);
        this.ID_ACL_ABD_PNL.TabIndex = 37;
        this.ID_ACL_ABD_PNL.Tag = "";
        // 
        // ID_ACL_FECA_EB
        // 
        this.ID_ACL_FECA_EB.AcceptsReturn = true;
        this.ID_ACL_FECA_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_FECA_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_FECA_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_FECA_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_FECA_EB.Location = new System.Drawing.Point(65, 20);
        this.ID_ACL_FECA_EB.MaxLength = 0;
        this.ID_ACL_FECA_EB.Name = "ID_ACL_FECA_EB";
        this.ID_ACL_FECA_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_FECA_EB.Size = new System.Drawing.Size(67, 19);
        this.ID_ACL_FECA_EB.TabIndex = 41;
        this.ID_ACL_FECA_EB.Tag = "";
        // 
        // ID_ACL_IMPA_EB
        // 
        this.ID_ACL_IMPA_EB.AcceptsReturn = true;
        this.ID_ACL_IMPA_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_IMPA_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_IMPA_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_IMPA_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_IMPA_EB.Location = new System.Drawing.Point(65, 46);
        this.ID_ACL_IMPA_EB.MaxLength = 0;
        this.ID_ACL_IMPA_EB.Name = "ID_ACL_IMPA_EB";
        this.ID_ACL_IMPA_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_IMPA_EB.Size = new System.Drawing.Size(67, 19);
        this.ID_ACL_IMPA_EB.TabIndex = 42;
        this.ID_ACL_IMPA_EB.Tag = "";
        // 
        // ID_ACL_RES_EB
        // 
        this.ID_ACL_RES_EB.AcceptsReturn = true;
        this.ID_ACL_RES_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_RES_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_RES_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_RES_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_RES_EB.Location = new System.Drawing.Point(9, 88);
        this.ID_ACL_RES_EB.MaxLength = 0;
        this.ID_ACL_RES_EB.Name = "ID_ACL_RES_EB";
        this.ID_ACL_RES_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_RES_EB.Size = new System.Drawing.Size(142, 19);
        this.ID_ACL_RES_EB.TabIndex = 43;
        this.ID_ACL_RES_EB.Tag = "";
        // 
        // ID_ACL_FECA_TXT
        // 
        this.ID_ACL_FECA_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_FECA_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_FECA_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_FECA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_FECA_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_FECA_TXT.Location = new System.Drawing.Point(9, 19);
        this.ID_ACL_FECA_TXT.Name = "ID_ACL_FECA_TXT";
        this.ID_ACL_FECA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_FECA_TXT.Size = new System.Drawing.Size(39, 17);
        this.ID_ACL_FECA_TXT.TabIndex = 40;
        this.ID_ACL_FECA_TXT.Tag = "";
        this.ID_ACL_FECA_TXT.Text = "&Fecha";
        // 
        // ID_ACL_RES_TXT
        // 
        this.ID_ACL_RES_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_RES_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_RES_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_RES_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_RES_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_RES_TXT.Location = new System.Drawing.Point(48, 69);
        this.ID_ACL_RES_TXT.Name = "ID_ACL_RES_TXT";
        this.ID_ACL_RES_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_RES_TXT.Size = new System.Drawing.Size(57, 17);
        this.ID_ACL_RES_TXT.TabIndex = 38;
        this.ID_ACL_RES_TXT.Tag = "";
        this.ID_ACL_RES_TXT.Text = "&Resultado";
        // 
        // ID_ACL_IMPA_TXT
        // 
        this.ID_ACL_IMPA_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACL_IMPA_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACL_IMPA_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACL_IMPA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_IMPA_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACL_IMPA_TXT.Location = new System.Drawing.Point(9, 46);
        this.ID_ACL_IMPA_TXT.Name = "ID_ACL_IMPA_TXT";
        this.ID_ACL_IMPA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_IMPA_TXT.Size = new System.Drawing.Size(53, 17);
        this.ID_ACL_IMPA_TXT.TabIndex = 39;
        this.ID_ACL_IMPA_TXT.Tag = "";
        this.ID_ACL_IMPA_TXT.Text = "&Importe";
        // 
        // ID_ACL_TIP_EB
        // 
        this.ID_ACL_TIP_EB.AcceptsReturn = true;
        this.ID_ACL_TIP_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_TIP_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_TIP_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_TIP_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_TIP_EB.Location = new System.Drawing.Point(139, 149);
        this.ID_ACL_TIP_EB.MaxLength = 0;
        this.ID_ACL_TIP_EB.Name = "ID_ACL_TIP_EB";
        this.ID_ACL_TIP_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_TIP_EB.Size = new System.Drawing.Size(185, 20);
        this.ID_ACL_TIP_EB.TabIndex = 13;
        this.ID_ACL_TIP_EB.Tag = "";
        // 
        // ID_ACL_CTA_EB
        // 
        this.ID_ACL_CTA_EB.AcceptsReturn = true;
        this.ID_ACL_CTA_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACL_CTA_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACL_CTA_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACL_CTA_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACL_CTA_EB.Location = new System.Drawing.Point(205, 15);
        this.ID_ACL_CTA_EB.MaxLength = 16;
        this.ID_ACL_CTA_EB.Name = "ID_ACL_CTA_EB";
        this.ID_ACL_CTA_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACL_CTA_EB.Size = new System.Drawing.Size(139, 19);
        this.ID_ACL_CTA_EB.TabIndex = 4;
        this.ID_ACL_CTA_EB.Tag = "";
        // 
        // CORMNACL
        // 
        this.AcceptButton = this.ID_ACL_IMP_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(531, 344);
        this.Controls.Add(this.ID_ACL_EMP_EB);
        this.Controls.Add(this.ID_ACL_NOM_EB);
        this.Controls.Add(this.ID_ACL_PRI_PNL);
        this.Controls.Add(this.ID_ACL_CTA_TXT);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(185, 95);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORMNACL";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Aclaraciones";
        this.Closed += new System.EventHandler(this.CORMNACL_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_PRI_PNL)).EndInit();
        this.ID_ACL_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_EJE_PNL)).EndInit();
        this.ID_ACL_EJE_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_ABO_PNL)).EndInit();
        this.ID_ACL_ABO_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_ORI_PNL)).EndInit();
        this.ID_ACL_ORI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_ORI_CKB_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_ORI_CKB_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_ACL_ORI_CKB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_HIS_PNL)).EndInit();
        this.ID_ACL_HIS_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_ABD_PNL)).EndInit();
        this.ID_ACL_ABD_PNL.ResumeLayout(false);
        this.ResumeLayout(false);

	}
	void  InitializeID_ACL_ORI_CKB()
	{
			this.ID_ACL_ORI_CKB[2] = _ID_ACL_ORI_CKB_2;
			this.ID_ACL_ORI_CKB[1] = _ID_ACL_ORI_CKB_1;
			this.ID_ACL_ORI_CKB[0] = _ID_ACL_ORI_CKB_0;
	}
#endregion 
}
}