using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORSGACC
	{
	
#region "Upgrade Support "
		private static CORSGACC m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORSGACC DefInstance
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
		public CORSGACC():base(){
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			InitializeHelp();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORSGACC CreateInstance()
	{
			CORSGACC theInstance = new CORSGACC();
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
	public  System.Windows.Forms.ComboBox ID_ACC_BAN_COB;
        public System.Windows.Forms.Label ID_ACC_BAN_PNLLabel_Text;
	public  System.Windows.Forms.Button ID_ACC_ACE_PB;
	public  System.Windows.Forms.Button ID_ACC_CAN_PB;
	public  System.Windows.Forms.ComboBox ID_ACC_SER_COB;
        public System.Windows.Forms.Label ID_ACC_SER_PNLLabel_Text;
	public  System.Windows.Forms.TextBox ID_ACC_USU_EB;
	public  System.Windows.Forms.Label ID_ACC_USU_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_ACC_USU_PNL;
	public  System.Windows.Forms.TextBox ID_ACC_CVE_EB;
	public  System.Windows.Forms.Label ID_ACC_CVE_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_ACC_CVE_PNL;
	public  AxThreed.AxSSPanel ID_ACC_SEC_PNL;
	public  System.Windows.Forms.PictureBox ID_ACC_BAN_PIC;
	public  System.Windows.Forms.Label ID_ACC_COR_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_ACC_COR_PNL;
	public  AxThreed.AxSSPanel ID_ACC_PRI_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	//[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORSGACC));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_ACC_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_ACC_SER_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_ACC_SEC_PNL = new AxThreed.AxSSPanel();
        this.ID_ACC_USU_PNL = new AxThreed.AxSSPanel();
        this.ID_ACC_USU_EB = new System.Windows.Forms.TextBox();
        this.ID_ACC_USU_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_ACC_CVE_PNL = new AxThreed.AxSSPanel();
        this.ID_ACC_CVE_EB = new System.Windows.Forms.TextBox();
        this.ID_ACC_CVE_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_ACC_COR_PNL = new AxThreed.AxSSPanel();
        this.ID_ACC_BAN_PIC = new System.Windows.Forms.PictureBox();
        this.ID_ACC_COR_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_ACC_CAN_PB = new System.Windows.Forms.Button();
        this.ID_ACC_ACE_PB = new System.Windows.Forms.Button();
        this.ID_ACC_SER_COB = new System.Windows.Forms.ComboBox();
        this.ID_ACC_BAN_COB = new System.Windows.Forms.ComboBox();
        this.ID_ACC_BAN_PNLLabel_Text = new System.Windows.Forms.Label();
        this.panel1 = new System.Windows.Forms.Panel();
        this.label1 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_PRI_PNL)).BeginInit();
        this.ID_ACC_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_SEC_PNL)).BeginInit();
        this.ID_ACC_SEC_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_USU_PNL)).BeginInit();
        this.ID_ACC_USU_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_CVE_PNL)).BeginInit();
        this.ID_ACC_CVE_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_COR_PNL)).BeginInit();
        this.ID_ACC_COR_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_BAN_PIC)).BeginInit();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_ACC_PRI_PNL
        // 
        this.ID_ACC_PRI_PNL.Controls.Add(this.ID_ACC_SER_PNLLabel_Text);
        this.ID_ACC_PRI_PNL.Controls.Add(this.ID_ACC_SEC_PNL);
        this.ID_ACC_PRI_PNL.Controls.Add(this.ID_ACC_COR_PNL);
        this.ID_ACC_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_ACC_PRI_PNL.Name = "ID_ACC_PRI_PNL";
        this.ID_ACC_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACC_PRI_PNL.OcxState")));
        this.ID_ACC_PRI_PNL.Size = new System.Drawing.Size(391, 332);
        this.ID_ACC_PRI_PNL.TabIndex = 1;
        this.ID_ACC_PRI_PNL.TabStop = false;
        this.ID_ACC_PRI_PNL.Tag = "";
        // 
        // ID_ACC_SER_PNLLabel_Text
        // 
        this.ID_ACC_SER_PNLLabel_Text.BackColor = System.Drawing.Color.Silver;
        this.ID_ACC_SER_PNLLabel_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.ID_ACC_SER_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_SER_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACC_SER_PNLLabel_Text.Location = new System.Drawing.Point(37, 149);
        this.ID_ACC_SER_PNLLabel_Text.Name = "ID_ACC_SER_PNLLabel_Text";
        this.ID_ACC_SER_PNLLabel_Text.Size = new System.Drawing.Size(169, 29);
        this.ID_ACC_SER_PNLLabel_Text.TabIndex = 11;
        this.ID_ACC_SER_PNLLabel_Text.Tag = "";
        this.ID_ACC_SER_PNLLabel_Text.Text = " &Servidor";
        this.ID_ACC_SER_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ID_ACC_SEC_PNL
        // 
        this.ID_ACC_SEC_PNL.Controls.Add(this.ID_ACC_USU_PNL);
        this.ID_ACC_SEC_PNL.Controls.Add(this.ID_ACC_CVE_PNL);
        this.ID_ACC_SEC_PNL.Location = new System.Drawing.Point(23, 140);
        this.ID_ACC_SEC_PNL.Name = "ID_ACC_SEC_PNL";
        this.ID_ACC_SEC_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACC_SEC_PNL.OcxState")));
        this.ID_ACC_SEC_PNL.Size = new System.Drawing.Size(220, 115);
        this.ID_ACC_SEC_PNL.TabIndex = 2;
        this.ID_ACC_SEC_PNL.TabStop = false;
        this.ID_ACC_SEC_PNL.Tag = "";
        // 
        // ID_ACC_USU_PNL
        // 
        this.ID_ACC_USU_PNL.Controls.Add(this.ID_ACC_USU_EB);
        this.ID_ACC_USU_PNL.Controls.Add(this.ID_ACC_USU_PNLLabel_Text);
        this.ID_ACC_USU_PNL.Location = new System.Drawing.Point(14, 47);
        this.ID_ACC_USU_PNL.Name = "ID_ACC_USU_PNL";
        this.ID_ACC_USU_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACC_USU_PNL.OcxState")));
        this.ID_ACC_USU_PNL.Size = new System.Drawing.Size(169, 30);
        this.ID_ACC_USU_PNL.TabIndex = 21;
        this.ID_ACC_USU_PNL.TabStop = false;
        this.ID_ACC_USU_PNL.Tag = "";
        // 
        // ID_ACC_USU_EB
        // 
        this.ID_ACC_USU_EB.AcceptsReturn = true;
        this.ID_ACC_USU_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_USU_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACC_USU_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_USU_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACC_USU_EB.Location = new System.Drawing.Point(97, 4);
        this.ID_ACC_USU_EB.MaxLength = 8;
        this.ID_ACC_USU_EB.Name = "ID_ACC_USU_EB";
        this.ID_ACC_USU_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_USU_EB.Size = new System.Drawing.Size(68, 20);
        this.ID_ACC_USU_EB.TabIndex = 0;
        this.ID_ACC_USU_EB.Tag = "";
        this.ID_ACC_USU_EB.Leave += new System.EventHandler(this.ID_ACC_USU_EB_Leave);
        this.ID_ACC_USU_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_USU_EB_KeyPress);
        // 
        // ID_ACC_USU_PNLLabel_Text
        // 
        this.ID_ACC_USU_PNLLabel_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.ID_ACC_USU_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_USU_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACC_USU_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_ACC_USU_PNLLabel_Text.Name = "ID_ACC_USU_PNLLabel_Text";
        this.ID_ACC_USU_PNLLabel_Text.Size = new System.Drawing.Size(169, 30);
        this.ID_ACC_USU_PNLLabel_Text.TabIndex = 22;
        this.ID_ACC_USU_PNLLabel_Text.Tag = "";
        this.ID_ACC_USU_PNLLabel_Text.Text = " &Nomina";
        this.ID_ACC_USU_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ID_ACC_CVE_PNL
        // 
        this.ID_ACC_CVE_PNL.Controls.Add(this.ID_ACC_CVE_EB);
        this.ID_ACC_CVE_PNL.Controls.Add(this.ID_ACC_CVE_PNLLabel_Text);
        this.ID_ACC_CVE_PNL.Location = new System.Drawing.Point(14, 78);
        this.ID_ACC_CVE_PNL.Name = "ID_ACC_CVE_PNL";
        this.ID_ACC_CVE_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACC_CVE_PNL.OcxState")));
        this.ID_ACC_CVE_PNL.Size = new System.Drawing.Size(168, 29);
        this.ID_ACC_CVE_PNL.TabIndex = 31;
        this.ID_ACC_CVE_PNL.TabStop = false;
        this.ID_ACC_CVE_PNL.Tag = "";
        // 
        // ID_ACC_CVE_EB
        // 
        this.ID_ACC_CVE_EB.AcceptsReturn = true;
        this.ID_ACC_CVE_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_CVE_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACC_CVE_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_CVE_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACC_CVE_EB.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.ID_ACC_CVE_EB.Location = new System.Drawing.Point(97, 4);
        this.ID_ACC_CVE_EB.MaxLength = 8;
        this.ID_ACC_CVE_EB.Name = "ID_ACC_CVE_EB";
        this.ID_ACC_CVE_EB.PasswordChar = '*';
        this.ID_ACC_CVE_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_CVE_EB.Size = new System.Drawing.Size(67, 20);
        this.ID_ACC_CVE_EB.TabIndex = 0;
        this.ID_ACC_CVE_EB.Tag = "";
        this.ID_ACC_CVE_EB.Leave += new System.EventHandler(this.ID_ACC_CVE_EB_Leave);
        this.ID_ACC_CVE_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_CVE_EB_KeyPress);
        // 
        // ID_ACC_CVE_PNLLabel_Text
        // 
        this.ID_ACC_CVE_PNLLabel_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.ID_ACC_CVE_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_CVE_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACC_CVE_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_ACC_CVE_PNLLabel_Text.Name = "ID_ACC_CVE_PNLLabel_Text";
        this.ID_ACC_CVE_PNLLabel_Text.Size = new System.Drawing.Size(168, 29);
        this.ID_ACC_CVE_PNLLabel_Text.TabIndex = 33;
        this.ID_ACC_CVE_PNLLabel_Text.Tag = "";
        this.ID_ACC_CVE_PNLLabel_Text.Text = " &Clave Personal";
        this.ID_ACC_CVE_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ID_ACC_COR_PNL
        // 
        this.ID_ACC_COR_PNL.Controls.Add(this.ID_ACC_BAN_PIC);
        this.ID_ACC_COR_PNL.Controls.Add(this.ID_ACC_COR_PNLLabel_Text);
        this.ID_ACC_COR_PNL.Location = new System.Drawing.Point(30, 19);
        this.ID_ACC_COR_PNL.Name = "ID_ACC_COR_PNL";
        this.ID_ACC_COR_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACC_COR_PNL.OcxState")));
        this.ID_ACC_COR_PNL.Size = new System.Drawing.Size(333, 236);
        this.ID_ACC_COR_PNL.TabIndex = 1;
        this.ID_ACC_COR_PNL.TabStop = false;
        this.ID_ACC_COR_PNL.Tag = "";
        // 
        // ID_ACC_BAN_PIC
        // 
        this.ID_ACC_BAN_PIC.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_BAN_PIC.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_BAN_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_BAN_PIC.Image = ((System.Drawing.Image)(resources.GetObject("ID_ACC_BAN_PIC.Image")));
        this.ID_ACC_BAN_PIC.Location = new System.Drawing.Point(2, 2);
        this.ID_ACC_BAN_PIC.Name = "ID_ACC_BAN_PIC";
        this.ID_ACC_BAN_PIC.Size = new System.Drawing.Size(329, 244);
        this.ID_ACC_BAN_PIC.TabIndex = 2;
        this.ID_ACC_BAN_PIC.TabStop = false;
        this.ID_ACC_BAN_PIC.Tag = "";
        this.ID_ACC_BAN_PIC.Click += new System.EventHandler(this.ID_ACC_BAN_PIC_Click);
        // 
        // ID_ACC_COR_PNLLabel_Text
        // 
        this.ID_ACC_COR_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_COR_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACC_COR_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_ACC_COR_PNLLabel_Text.Name = "ID_ACC_COR_PNLLabel_Text";
        this.ID_ACC_COR_PNLLabel_Text.Size = new System.Drawing.Size(333, 267);
        this.ID_ACC_COR_PNLLabel_Text.TabIndex = 0;
        this.ID_ACC_COR_PNLLabel_Text.Tag = "";
        this.ID_ACC_COR_PNLLabel_Text.Text = "Panel3D1";
        this.ID_ACC_COR_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // ID_ACC_CAN_PB
        // 
        this.ID_ACC_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_ACC_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACC_CAN_PB.Location = new System.Drawing.Point(199, 298);
        this.ID_ACC_CAN_PB.Name = "ID_ACC_CAN_PB";
        this.ID_ACC_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_CAN_PB.Size = new System.Drawing.Size(71, 25);
        this.ID_ACC_CAN_PB.TabIndex = 5;
        this.ID_ACC_CAN_PB.Tag = "";
        this.ID_ACC_CAN_PB.Text = "Cancelar";
        this.ID_ACC_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_ACC_CAN_PB.Click += new System.EventHandler(this.ID_ACC_CAN_PB_Click);
        // 
        // ID_ACC_ACE_PB
        // 
        this.ID_ACC_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_ACE_PB.Enabled = false;
        this.ID_ACC_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACC_ACE_PB.Location = new System.Drawing.Point(120, 297);
        this.ID_ACC_ACE_PB.Name = "ID_ACC_ACE_PB";
        this.ID_ACC_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_ACE_PB.Size = new System.Drawing.Size(71, 25);
        this.ID_ACC_ACE_PB.TabIndex = 4;
        this.ID_ACC_ACE_PB.Tag = "";
        this.ID_ACC_ACE_PB.Text = "Aceptar";
        this.ID_ACC_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_ACC_ACE_PB.Click += new System.EventHandler(this.ID_ACC_ACE_PB_Click);
        // 
        // ID_ACC_SER_COB
        // 
        this.ID_ACC_SER_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_SER_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_SER_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACC_SER_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_SER_COB.ForeColor = System.Drawing.Color.Black;
        this.ID_ACC_SER_COB.Location = new System.Drawing.Point(95, 153);
        this.ID_ACC_SER_COB.Name = "ID_ACC_SER_COB";
        this.ID_ACC_SER_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_SER_COB.Size = new System.Drawing.Size(107, 21);
        this.ID_ACC_SER_COB.TabIndex = 1;
        this.ID_ACC_SER_COB.Tag = "";
        this.ID_ACC_SER_COB.SelectedIndexChanged += new System.EventHandler(this.ID_ACC_SER_COB_SelectedIndexChanged);
        // 
        // ID_ACC_BAN_COB
        // 
        this.ID_ACC_BAN_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_BAN_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_BAN_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACC_BAN_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_BAN_COB.ForeColor = System.Drawing.Color.Black;
        this.ID_ACC_BAN_COB.Location = new System.Drawing.Point(71, 3);
        this.ID_ACC_BAN_COB.Name = "ID_ACC_BAN_COB";
        this.ID_ACC_BAN_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_BAN_COB.Size = new System.Drawing.Size(259, 21);
        this.ID_ACC_BAN_COB.TabIndex = 0;
        this.ID_ACC_BAN_COB.Tag = "";
        this.ID_ACC_BAN_COB.Leave += new System.EventHandler(this.ID_ACC_BAN_COB_Leave);
        this.ID_ACC_BAN_COB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_BAN_COB_KeyPress);
        this.ID_ACC_BAN_COB.TextChanged += new System.EventHandler(this.ID_ACC_BAN_COB_TextChanged);
        // 
        // ID_ACC_BAN_PNLLabel_Text
        // 
        this.ID_ACC_BAN_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_BAN_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACC_BAN_PNLLabel_Text.Location = new System.Drawing.Point(25, 283);
        this.ID_ACC_BAN_PNLLabel_Text.Name = "ID_ACC_BAN_PNLLabel_Text";
        this.ID_ACC_BAN_PNLLabel_Text.Size = new System.Drawing.Size(338, 29);
        this.ID_ACC_BAN_PNLLabel_Text.TabIndex = 50;
        this.ID_ACC_BAN_PNLLabel_Text.Tag = "";
        this.ID_ACC_BAN_PNLLabel_Text.Text = "    &Servicio";
        this.ID_ACC_BAN_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.Color.Silver;
        this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.panel1.Controls.Add(this.label1);
        this.panel1.Controls.Add(this.ID_ACC_BAN_COB);
        this.panel1.Location = new System.Drawing.Point(23, 253);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(338, 33);
        this.panel1.TabIndex = 3;
        this.panel1.TabStop = true;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Silver;
        this.label1.Location = new System.Drawing.Point(2, 6);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(65, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "   &Servicio";
        // 
        // CORSGACC
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(389, 333);
        this.ControlBox = false;
        this.Controls.Add(this.ID_ACC_SER_COB);
        this.Controls.Add(this.ID_ACC_ACE_PB);
        this.Controls.Add(this.ID_ACC_CAN_PB);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.ID_ACC_PRI_PNL);
        this.Controls.Add(this.ID_ACC_BAN_PNLLabel_Text);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Location = new System.Drawing.Point(175, 193);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORSGACC";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Tarjeta Corporativa";
        this.Closed += new System.EventHandler(this.CORSGACC_Closed);
        this.Activated += new System.EventHandler(this.CORSGACC_Activated);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_PRI_PNL)).EndInit();
        this.ID_ACC_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_SEC_PNL)).EndInit();
        this.ID_ACC_SEC_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_USU_PNL)).EndInit();
        this.ID_ACC_USU_PNL.ResumeLayout(false);
        this.ID_ACC_USU_PNL.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_CVE_PNL)).EndInit();
        this.ID_ACC_CVE_PNL.ResumeLayout(false);
        this.ID_ACC_CVE_PNL.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_COR_PNL)).EndInit();
        this.ID_ACC_COR_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_BAN_PIC)).EndInit();
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        this.ResumeLayout(false);

	}
#endregion 

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

}
}