using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORSGCUS
	{
	
#region "Upgrade Support "
		private static CORSGCUS m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORSGCUS DefInstance
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
		public CORSGCUS():base(){
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
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORSGCUS CreateInstance()
	{
			CORSGCUS theInstance = new CORSGCUS();
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
	public  System.Windows.Forms.Button ID_CUS_ACE_PB;
	public  System.Windows.Forms.Button ID_CUS_CAN_PB;
	public  System.Windows.Forms.TextBox ID_CUS_PAS_EB;
	public  System.Windows.Forms.TextBox ID_CUS_MAT_EB;
	public  System.Windows.Forms.TextBox ID_CUS_PAT_EB;
	public  System.Windows.Forms.TextBox ID_CUS_NOM_EB;
	public  System.Windows.Forms.ComboBox ID_CUS_GRU_COB;
	public  System.Windows.Forms.TextBox ID_CUS_USU_EB;
	public  System.Windows.Forms.Label ID_CUS_USU_TXT;
	public  System.Windows.Forms.Label ID_CUS_GRU_TXT;
	public  System.Windows.Forms.Label ID_CUS_NOM_TXT;
	public  System.Windows.Forms.Label ID_CUS_PAT_TXT;
	public  System.Windows.Forms.Label ID_CUS_MAT_TXT;
	public  System.Windows.Forms.Label ID_CUS_PAS_TXT;
	public  AxThreed.AxSSFrame SSFrame1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORSGCUS));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.SSFrame1 = new AxThreed.AxSSFrame();
        this.ID_CUS_USU_EB = new System.Windows.Forms.TextBox();
        this.ID_CUS_USU_TXT = new System.Windows.Forms.Label();
        this.ID_CUS_GRU_COB = new System.Windows.Forms.ComboBox();
        this.ID_CUS_PAT_EB = new System.Windows.Forms.TextBox();
        this.ID_CUS_NOM_EB = new System.Windows.Forms.TextBox();
        this.ID_CUS_MAT_TXT = new System.Windows.Forms.Label();
        this.ID_CUS_PAS_TXT = new System.Windows.Forms.Label();
        this.ID_CUS_PAT_TXT = new System.Windows.Forms.Label();
        this.ID_CUS_GRU_TXT = new System.Windows.Forms.Label();
        this.ID_CUS_NOM_TXT = new System.Windows.Forms.Label();
        this.ID_CUS_CAN_PB = new System.Windows.Forms.Button();
        this.ID_CUS_ACE_PB = new System.Windows.Forms.Button();
        this.ID_CUS_MAT_EB = new System.Windows.Forms.TextBox();
        this.ID_CUS_PAS_EB = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.SSFrame1)).BeginInit();
        this.SSFrame1.SuspendLayout();
        this.SuspendLayout();
        // 
        // SSFrame1
        // 
        this.SSFrame1.Controls.Add(this.ID_CUS_USU_EB);
        this.SSFrame1.Controls.Add(this.ID_CUS_USU_TXT);
        this.SSFrame1.Controls.Add(this.ID_CUS_GRU_COB);
        this.SSFrame1.Controls.Add(this.ID_CUS_PAT_EB);
        this.SSFrame1.Controls.Add(this.ID_CUS_NOM_EB);
        this.SSFrame1.Controls.Add(this.ID_CUS_MAT_TXT);
        this.SSFrame1.Controls.Add(this.ID_CUS_PAS_TXT);
        this.SSFrame1.Controls.Add(this.ID_CUS_PAT_TXT);
        this.SSFrame1.Controls.Add(this.ID_CUS_GRU_TXT);
        this.SSFrame1.Controls.Add(this.ID_CUS_NOM_TXT);
        this.SSFrame1.Controls.Add(this.ID_CUS_CAN_PB);
        this.SSFrame1.Controls.Add(this.ID_CUS_ACE_PB);
        this.SSFrame1.Controls.Add(this.ID_CUS_MAT_EB);
        this.SSFrame1.Controls.Add(this.ID_CUS_PAS_EB);
        this.SSFrame1.Location = new System.Drawing.Point(0, 0);
        this.SSFrame1.Name = "SSFrame1";
        this.SSFrame1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSFrame1.OcxState")));
        this.SSFrame1.Size = new System.Drawing.Size(292, 248);
        this.SSFrame1.TabIndex = 8;
        this.SSFrame1.Tag = "";
        // 
        // ID_CUS_USU_EB
        // 
        this.ID_CUS_USU_EB.AcceptsReturn = true;
        this.ID_CUS_USU_EB.BackColor = System.Drawing.Color.White;
        this.ID_CUS_USU_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_CUS_USU_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_USU_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_USU_EB.Location = new System.Drawing.Point(89, 19);
        this.ID_CUS_USU_EB.MaxLength = 8;
        this.ID_CUS_USU_EB.Name = "ID_CUS_USU_EB";
        this.ID_CUS_USU_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_USU_EB.Size = new System.Drawing.Size(87, 20);
        this.ID_CUS_USU_EB.TabIndex = 0;
        this.ID_CUS_USU_EB.Tag = "";
        this.ID_CUS_USU_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_CUS_USU_EB_KeyPress);
        // 
        // ID_CUS_USU_TXT
        // 
        this.ID_CUS_USU_TXT.AutoSize = true;
        this.ID_CUS_USU_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_CUS_USU_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_USU_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CUS_USU_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_USU_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_USU_TXT.Location = new System.Drawing.Point(47, 22);
        this.ID_CUS_USU_TXT.Name = "ID_CUS_USU_TXT";
        this.ID_CUS_USU_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_USU_TXT.Size = new System.Drawing.Size(43, 13);
        this.ID_CUS_USU_TXT.TabIndex = 14;
        this.ID_CUS_USU_TXT.Tag = "";
        this.ID_CUS_USU_TXT.Text = "&Usuario";
        // 
        // ID_CUS_GRU_COB
        // 
        this.ID_CUS_GRU_COB.BackColor = System.Drawing.Color.White;
        this.ID_CUS_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_GRU_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CUS_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_GRU_COB.Location = new System.Drawing.Point(89, 45);
        this.ID_CUS_GRU_COB.Name = "ID_CUS_GRU_COB";
        this.ID_CUS_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_GRU_COB.Size = new System.Drawing.Size(181, 21);
        this.ID_CUS_GRU_COB.TabIndex = 1;
        this.ID_CUS_GRU_COB.Tag = "";
        // 
        // ID_CUS_PAT_EB
        // 
        this.ID_CUS_PAT_EB.AcceptsReturn = true;
        this.ID_CUS_PAT_EB.BackColor = System.Drawing.Color.White;
        this.ID_CUS_PAT_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_CUS_PAT_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_PAT_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_PAT_EB.Location = new System.Drawing.Point(89, 101);
        this.ID_CUS_PAT_EB.MaxLength = 20;
        this.ID_CUS_PAT_EB.Name = "ID_CUS_PAT_EB";
        this.ID_CUS_PAT_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_PAT_EB.Size = new System.Drawing.Size(157, 21);
        this.ID_CUS_PAT_EB.TabIndex = 3;
        this.ID_CUS_PAT_EB.Tag = "";
        this.ID_CUS_PAT_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_CUS_PAT_EB_KeyPress);
        // 
        // ID_CUS_NOM_EB
        // 
        this.ID_CUS_NOM_EB.AcceptsReturn = true;
        this.ID_CUS_NOM_EB.BackColor = System.Drawing.Color.White;
        this.ID_CUS_NOM_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_CUS_NOM_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_NOM_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_NOM_EB.Location = new System.Drawing.Point(90, 73);
        this.ID_CUS_NOM_EB.MaxLength = 20;
        this.ID_CUS_NOM_EB.Name = "ID_CUS_NOM_EB";
        this.ID_CUS_NOM_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_NOM_EB.Size = new System.Drawing.Size(157, 21);
        this.ID_CUS_NOM_EB.TabIndex = 2;
        this.ID_CUS_NOM_EB.Tag = "";
        this.ID_CUS_NOM_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_CUS_NOM_EB_KeyPress);
        // 
        // ID_CUS_MAT_TXT
        // 
        this.ID_CUS_MAT_TXT.AutoSize = true;
        this.ID_CUS_MAT_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_CUS_MAT_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_MAT_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CUS_MAT_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_MAT_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_MAT_TXT.Location = new System.Drawing.Point(44, 136);
        this.ID_CUS_MAT_TXT.Name = "ID_CUS_MAT_TXT";
        this.ID_CUS_MAT_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_MAT_TXT.Size = new System.Drawing.Size(46, 13);
        this.ID_CUS_MAT_TXT.TabIndex = 10;
        this.ID_CUS_MAT_TXT.Tag = "";
        this.ID_CUS_MAT_TXT.Text = "&Materno";
        // 
        // ID_CUS_PAS_TXT
        // 
        this.ID_CUS_PAS_TXT.AutoSize = true;
        this.ID_CUS_PAS_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_CUS_PAS_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_PAS_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CUS_PAS_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_PAS_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_PAS_TXT.Location = new System.Drawing.Point(12, 165);
        this.ID_CUS_PAS_TXT.Name = "ID_CUS_PAS_TXT";
        this.ID_CUS_PAS_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_PAS_TXT.Size = new System.Drawing.Size(78, 13);
        this.ID_CUS_PAS_TXT.TabIndex = 9;
        this.ID_CUS_PAS_TXT.Tag = "";
        this.ID_CUS_PAS_TXT.Text = "C&lave Personal";
        // 
        // ID_CUS_PAT_TXT
        // 
        this.ID_CUS_PAT_TXT.AutoSize = true;
        this.ID_CUS_PAT_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_CUS_PAT_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_PAT_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CUS_PAT_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_PAT_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_PAT_TXT.Location = new System.Drawing.Point(46, 105);
        this.ID_CUS_PAT_TXT.Name = "ID_CUS_PAT_TXT";
        this.ID_CUS_PAT_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_PAT_TXT.Size = new System.Drawing.Size(44, 13);
        this.ID_CUS_PAT_TXT.TabIndex = 11;
        this.ID_CUS_PAT_TXT.Tag = "";
        this.ID_CUS_PAT_TXT.Text = "&Paterno";
        // 
        // ID_CUS_GRU_TXT
        // 
        this.ID_CUS_GRU_TXT.AutoSize = true;
        this.ID_CUS_GRU_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_CUS_GRU_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_GRU_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CUS_GRU_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_GRU_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_GRU_TXT.Location = new System.Drawing.Point(54, 49);
        this.ID_CUS_GRU_TXT.Name = "ID_CUS_GRU_TXT";
        this.ID_CUS_GRU_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_GRU_TXT.Size = new System.Drawing.Size(36, 13);
        this.ID_CUS_GRU_TXT.TabIndex = 13;
        this.ID_CUS_GRU_TXT.Tag = "";
        this.ID_CUS_GRU_TXT.Text = "&Grupo";
        // 
        // ID_CUS_NOM_TXT
        // 
        this.ID_CUS_NOM_TXT.AutoSize = true;
        this.ID_CUS_NOM_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_CUS_NOM_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_NOM_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CUS_NOM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_NOM_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_NOM_TXT.Location = new System.Drawing.Point(46, 77);
        this.ID_CUS_NOM_TXT.Name = "ID_CUS_NOM_TXT";
        this.ID_CUS_NOM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_NOM_TXT.Size = new System.Drawing.Size(44, 13);
        this.ID_CUS_NOM_TXT.TabIndex = 12;
        this.ID_CUS_NOM_TXT.Tag = "";
        this.ID_CUS_NOM_TXT.Text = "&Nombre";
        // 
        // ID_CUS_CAN_PB
        // 
        this.ID_CUS_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CUS_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_CUS_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CUS_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CUS_CAN_PB.Location = new System.Drawing.Point(157, 201);
        this.ID_CUS_CAN_PB.Name = "ID_CUS_CAN_PB";
        this.ID_CUS_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_CAN_PB.Size = new System.Drawing.Size(71, 25);
        this.ID_CUS_CAN_PB.TabIndex = 7;
        this.ID_CUS_CAN_PB.Tag = "";
        this.ID_CUS_CAN_PB.Text = "Cancelar";
        this.ID_CUS_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_CUS_CAN_PB.Click += new System.EventHandler(this.ID_CUS_CAN_PB_Click);
        // 
        // ID_CUS_ACE_PB
        // 
        this.ID_CUS_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CUS_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CUS_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CUS_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CUS_ACE_PB.Location = new System.Drawing.Point(66, 201);
        this.ID_CUS_ACE_PB.Name = "ID_CUS_ACE_PB";
        this.ID_CUS_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_ACE_PB.Size = new System.Drawing.Size(71, 25);
        this.ID_CUS_ACE_PB.TabIndex = 6;
        this.ID_CUS_ACE_PB.Tag = "";
        this.ID_CUS_ACE_PB.Text = "Aceptar";
        this.ID_CUS_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_CUS_ACE_PB.Click += new System.EventHandler(this.ID_CUS_ACE_PB_Click);
        // 
        // ID_CUS_MAT_EB
        // 
        this.ID_CUS_MAT_EB.AcceptsReturn = true;
        this.ID_CUS_MAT_EB.BackColor = System.Drawing.Color.White;
        this.ID_CUS_MAT_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_CUS_MAT_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_MAT_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_MAT_EB.Location = new System.Drawing.Point(89, 132);
        this.ID_CUS_MAT_EB.MaxLength = 20;
        this.ID_CUS_MAT_EB.Name = "ID_CUS_MAT_EB";
        this.ID_CUS_MAT_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_MAT_EB.Size = new System.Drawing.Size(157, 21);
        this.ID_CUS_MAT_EB.TabIndex = 4;
        this.ID_CUS_MAT_EB.Tag = "";
        this.ID_CUS_MAT_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_CUS_MAT_EB_KeyPress);
        // 
        // ID_CUS_PAS_EB
        // 
        this.ID_CUS_PAS_EB.AcceptsReturn = true;
        this.ID_CUS_PAS_EB.BackColor = System.Drawing.Color.White;
        this.ID_CUS_PAS_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_CUS_PAS_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CUS_PAS_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CUS_PAS_EB.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.ID_CUS_PAS_EB.Location = new System.Drawing.Point(89, 161);
        this.ID_CUS_PAS_EB.MaxLength = 8;
        this.ID_CUS_PAS_EB.Name = "ID_CUS_PAS_EB";
        this.ID_CUS_PAS_EB.PasswordChar = '*';
        this.ID_CUS_PAS_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CUS_PAS_EB.Size = new System.Drawing.Size(73, 21);
        this.ID_CUS_PAS_EB.TabIndex = 5;
        this.ID_CUS_PAS_EB.Tag = "";
        this.ID_CUS_PAS_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_CUS_PAS_EB_KeyPress);
        // 
        // CORSGCUS
        // 
        this.AcceptButton = this.ID_CUS_ACE_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Menu;
        this.CancelButton = this.ID_CUS_CAN_PB;
        this.ClientSize = new System.Drawing.Size(292, 248);
        this.Controls.Add(this.SSFrame1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(371, 237);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORSGCUS";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Usuarios";
        this.Closed += new System.EventHandler(this.CORSGCUS_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.SSFrame1)).EndInit();
        this.SSFrame1.ResumeLayout(false);
        this.SSFrame1.PerformLayout();
        this.ResumeLayout(false);

	}
#endregion 
}
}