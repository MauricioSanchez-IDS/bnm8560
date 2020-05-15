using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTREG
	{
	
#region "Upgrade Support "
		private static CORCTREG m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTREG DefInstance
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
		public CORCTREG():base(){
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
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTREG CreateInstance()
	{
			CORCTREG theInstance = new CORCTREG();
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
	public  System.Windows.Forms.Button ID_REG_CON_PB;
	public  System.Windows.Forms.Button ID_REG_CAM_PB;
	public  System.Windows.Forms.Button ID_REG_BAJ_PB;
        public System.Windows.Forms.Button ID_REG_ALT_PB;
        public AxThreed.AxSSPanel ID_REG_TIT_PNL;
        public AxThreed.AxSSPanel ID_REG_DES_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTREG));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_REG_BAJ_PB = new System.Windows.Forms.Button();
        this.ID_REG_CAM_PB = new System.Windows.Forms.Button();
        this.ID_REG_CON_PB = new System.Windows.Forms.Button();
        this.ID_REG_ALT_PB = new System.Windows.Forms.Button();
        this.ID_REG_TIT_PNL = new AxThreed.AxSSPanel();
        this.ID_REG_DES_PNL = new AxThreed.AxSSPanel();
        this.ID_REG_GRP_LB = new System.Windows.Forms.ListBox();
        this.ID_REG_CER_PB = new System.Windows.Forms.Button();
        this.panel1 = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REG_TIT_PNL)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REG_DES_PNL)).BeginInit();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_REG_BAJ_PB
        // 
        this.ID_REG_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_BAJ_PB.Location = new System.Drawing.Point(257, 50);
        this.ID_REG_BAJ_PB.Name = "ID_REG_BAJ_PB";
        this.ID_REG_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_BAJ_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_REG_BAJ_PB.TabIndex = 5;
        this.ID_REG_BAJ_PB.Tag = "";
        this.ID_REG_BAJ_PB.Text = "&Bajas";
        this.ID_REG_BAJ_PB.UseVisualStyleBackColor = false;
        this.ID_REG_BAJ_PB.Click += new System.EventHandler(this.ID_REG_BAJ_PB_Click);
        this.ID_REG_BAJ_PB.Leave += new System.EventHandler(this.ID_REG_BAJ_PB_Leave);
        // 
        // ID_REG_CAM_PB
        // 
        this.ID_REG_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_CAM_PB.Location = new System.Drawing.Point(257, 76);
        this.ID_REG_CAM_PB.Name = "ID_REG_CAM_PB";
        this.ID_REG_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_CAM_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_REG_CAM_PB.TabIndex = 6;
        this.ID_REG_CAM_PB.Tag = "";
        this.ID_REG_CAM_PB.Text = "&Cambio...";
        this.ID_REG_CAM_PB.UseVisualStyleBackColor = false;
        this.ID_REG_CAM_PB.Click += new System.EventHandler(this.ID_REG_CAM_PB_Click);
        // 
        // ID_REG_CON_PB
        // 
        this.ID_REG_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_CON_PB.Location = new System.Drawing.Point(257, 103);
        this.ID_REG_CON_PB.Name = "ID_REG_CON_PB";
        this.ID_REG_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_CON_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_REG_CON_PB.TabIndex = 7;
        this.ID_REG_CON_PB.Tag = "";
        this.ID_REG_CON_PB.Text = "C&onsulta...";
        this.ID_REG_CON_PB.UseVisualStyleBackColor = false;
        this.ID_REG_CON_PB.Click += new System.EventHandler(this.ID_REG_CON_PB_Click);
        // 
        // ID_REG_ALT_PB
        // 
        this.ID_REG_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_ALT_PB.Location = new System.Drawing.Point(257, 24);
        this.ID_REG_ALT_PB.Name = "ID_REG_ALT_PB";
        this.ID_REG_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_ALT_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_REG_ALT_PB.TabIndex = 4;
        this.ID_REG_ALT_PB.Tag = "";
        this.ID_REG_ALT_PB.Text = "&Alta...";
        this.ID_REG_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_REG_ALT_PB.Click += new System.EventHandler(this.ID_REG_ALT_PB_Click);
        // 
        // ID_REG_TIT_PNL
        // 
        this.ID_REG_TIT_PNL.Location = new System.Drawing.Point(21, 21);
        this.ID_REG_TIT_PNL.Name = "ID_REG_TIT_PNL";
        this.ID_REG_TIT_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REG_TIT_PNL.OcxState")));
        this.ID_REG_TIT_PNL.Size = new System.Drawing.Size(32, 24);
        this.ID_REG_TIT_PNL.TabIndex = 1;
        this.ID_REG_TIT_PNL.Tag = "";
        // 
        // ID_REG_DES_PNL
        // 
        this.ID_REG_DES_PNL.Location = new System.Drawing.Point(53, 21);
        this.ID_REG_DES_PNL.Name = "ID_REG_DES_PNL";
        this.ID_REG_DES_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REG_DES_PNL.OcxState")));
        this.ID_REG_DES_PNL.Size = new System.Drawing.Size(193, 24);
        this.ID_REG_DES_PNL.TabIndex = 2;
        this.ID_REG_DES_PNL.Tag = "";
        // 
        // ID_REG_GRP_LB
        // 
        this.ID_REG_GRP_LB.Location = new System.Drawing.Point(22, 46);
        this.ID_REG_GRP_LB.Name = "ID_REG_GRP_LB";
        this.ID_REG_GRP_LB.Size = new System.Drawing.Size(223, 108);
        this.ID_REG_GRP_LB.TabIndex = 3;
        // 
        // ID_REG_CER_PB
        // 
        this.ID_REG_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_CER_PB.Location = new System.Drawing.Point(258, 159);
        this.ID_REG_CER_PB.Name = "ID_REG_CER_PB";
        this.ID_REG_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_CER_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_REG_CER_PB.TabIndex = 8;
        this.ID_REG_CER_PB.Tag = "";
        this.ID_REG_CER_PB.Text = "&Salir";
        this.ID_REG_CER_PB.UseVisualStyleBackColor = false;
        this.ID_REG_CER_PB.Click += new System.EventHandler(this.ID_REG_CER_PB_Click);
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
        this.panel1.Controls.Add(this.ID_REG_CER_PB);
        this.panel1.Controls.Add(this.ID_REG_CON_PB);
        this.panel1.Controls.Add(this.ID_REG_CAM_PB);
        this.panel1.Controls.Add(this.ID_REG_BAJ_PB);
        this.panel1.Controls.Add(this.ID_REG_DES_PNL);
        this.panel1.Controls.Add(this.ID_REG_GRP_LB);
        this.panel1.Controls.Add(this.ID_REG_ALT_PB);
        this.panel1.Controls.Add(this.ID_REG_TIT_PNL);
        this.panel1.Location = new System.Drawing.Point(1, 2);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(349, 201);
        this.panel1.TabIndex = 9;
        // 
        // CORCTREG
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(350, 203);
        this.Controls.Add(this.panel1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(249, 119);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCTREG";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Regiones";
        this.Closed += new System.EventHandler(this.CORCTREG_Closed);
        this.Activated += new System.EventHandler(this.CORCTREG_Activated);
        this.Load += new System.EventHandler(this.CORCTREG_Load);
        ((System.ComponentModel.ISupportInitialize)(this.ID_REG_TIT_PNL)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REG_DES_PNL)).EndInit();
        this.panel1.ResumeLayout(false);
        this.ResumeLayout(false);

	}
#endregion 

        public System.Windows.Forms.ListBox ID_REG_GRP_LB;
        public System.Windows.Forms.Button ID_REG_CER_PB;
        private System.Windows.Forms.Panel panel1;
}
}