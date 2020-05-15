using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTGRU
	{
	
#region "Upgrade Support "
		private static CORCTGRU m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTGRU DefInstance
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
		public CORCTGRU():base(){
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
			InitializeID_CGR_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTGRU CreateInstance()
	{
			CORCTGRU theInstance = new CORCTGRU();
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
	public  System.Windows.Forms.ListBox ID_CGR_GRP_LB;
	public  System.Windows.Forms.Button ID_CGR_CER_PB;
	public  System.Windows.Forms.Button ID_CGR_ALT_PB;
	public  System.Windows.Forms.Button ID_CGR_BAJ_PB;
	public  System.Windows.Forms.Button ID_CGR_CAM_PB;
	public  System.Windows.Forms.Button ID_CGR_CON_PB;
        private System.Windows.Forms.Label _ID_CGR_ETI_PNL_0Label_Text;
        public System.Windows.Forms.Label ID_CGR_NOM_PNLLabel_Text;
        public AxThreed.AxSSCheck ID_CGR_IRA_3CKB;
	public AxThreed.AxSSPanel[] ID_CGR_ETI_PNL = new AxThreed.AxSSPanel[1];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTGRU));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_CGR_BAJ_PB = new System.Windows.Forms.Button();
        this.ID_CGR_CAM_PB = new System.Windows.Forms.Button();
        this.ID_CGR_CER_PB = new System.Windows.Forms.Button();
        this.ID_CGR_ALT_PB = new System.Windows.Forms.Button();
        this.ID_CGR_NOM_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_CGR_CON_PB = new System.Windows.Forms.Button();
        this._ID_CGR_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
        this.ID_CGR_GRP_LB = new System.Windows.Forms.ListBox();
        this.panel1 = new System.Windows.Forms.Panel();
        this.ID_CGR_IRA_3CKB = new AxThreed.AxSSCheck();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_IRA_3CKB)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_CGR_BAJ_PB
        // 
        this.ID_CGR_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CGR_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CGR_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CGR_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CGR_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CGR_BAJ_PB.Location = new System.Drawing.Point(324, 66);
        this.ID_CGR_BAJ_PB.Name = "ID_CGR_BAJ_PB";
        this.ID_CGR_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CGR_BAJ_PB.Size = new System.Drawing.Size(81, 22);
        this.ID_CGR_BAJ_PB.TabIndex = 5;
        this.ID_CGR_BAJ_PB.Tag = "J";
        this.ID_CGR_BAJ_PB.Text = "&Bajas";
        this.ID_CGR_BAJ_PB.UseVisualStyleBackColor = false;
        this.ID_CGR_BAJ_PB.Click += new System.EventHandler(this.ID_CGR_BAJ_PB_Click);
        // 
        // ID_CGR_CAM_PB
        // 
        this.ID_CGR_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CGR_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CGR_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CGR_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CGR_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CGR_CAM_PB.Location = new System.Drawing.Point(324, 94);
        this.ID_CGR_CAM_PB.Name = "ID_CGR_CAM_PB";
        this.ID_CGR_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CGR_CAM_PB.Size = new System.Drawing.Size(81, 22);
        this.ID_CGR_CAM_PB.TabIndex = 4;
        this.ID_CGR_CAM_PB.Tag = "C";
        this.ID_CGR_CAM_PB.Text = "&Cambios...";
        this.ID_CGR_CAM_PB.UseVisualStyleBackColor = false;
        this.ID_CGR_CAM_PB.Click += new System.EventHandler(this.ID_CGR_CAM_PB_Click);
        // 
        // ID_CGR_CER_PB
        // 
        this.ID_CGR_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CGR_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CGR_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_CGR_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CGR_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CGR_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CGR_CER_PB.Location = new System.Drawing.Point(324, 160);
        this.ID_CGR_CER_PB.Name = "ID_CGR_CER_PB";
        this.ID_CGR_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CGR_CER_PB.Size = new System.Drawing.Size(81, 22);
        this.ID_CGR_CER_PB.TabIndex = 7;
        this.ID_CGR_CER_PB.Tag = "";
        this.ID_CGR_CER_PB.Text = "&Salir";
        this.ID_CGR_CER_PB.UseVisualStyleBackColor = false;
        this.ID_CGR_CER_PB.Click += new System.EventHandler(this.ID_CGR_CER_PB_Click);
        // 
        // ID_CGR_ALT_PB
        // 
        this.ID_CGR_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CGR_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CGR_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CGR_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CGR_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CGR_ALT_PB.Location = new System.Drawing.Point(324, 38);
        this.ID_CGR_ALT_PB.Name = "ID_CGR_ALT_PB";
        this.ID_CGR_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CGR_ALT_PB.Size = new System.Drawing.Size(81, 22);
        this.ID_CGR_ALT_PB.TabIndex = 6;
        this.ID_CGR_ALT_PB.Tag = "A";
        this.ID_CGR_ALT_PB.Text = "&Altas...";
        this.ID_CGR_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_CGR_ALT_PB.Click += new System.EventHandler(this.ID_CGR_ALT_PB_Click);
        // 
        // ID_CGR_NOM_PNLLabel_Text
        // 
        this.ID_CGR_NOM_PNLLabel_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.ID_CGR_NOM_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CGR_NOM_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_CGR_NOM_PNLLabel_Text.Location = new System.Drawing.Point(55, 17);
        this.ID_CGR_NOM_PNLLabel_Text.Name = "ID_CGR_NOM_PNLLabel_Text";
        this.ID_CGR_NOM_PNLLabel_Text.Size = new System.Drawing.Size(260, 21);
        this.ID_CGR_NOM_PNLLabel_Text.TabIndex = 0;
        this.ID_CGR_NOM_PNLLabel_Text.Tag = "";
        this.ID_CGR_NOM_PNLLabel_Text.Text = "&Grupo Corporativo";
        this.ID_CGR_NOM_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_CGR_CON_PB
        // 
        this.ID_CGR_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CGR_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CGR_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CGR_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CGR_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CGR_CON_PB.Location = new System.Drawing.Point(324, 122);
        this.ID_CGR_CON_PB.Name = "ID_CGR_CON_PB";
        this.ID_CGR_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CGR_CON_PB.Size = new System.Drawing.Size(81, 22);
        this.ID_CGR_CON_PB.TabIndex = 3;
        this.ID_CGR_CON_PB.Tag = "B";
        this.ID_CGR_CON_PB.Text = "C&onsulta...";
        this.ID_CGR_CON_PB.UseVisualStyleBackColor = false;
        this.ID_CGR_CON_PB.Click += new System.EventHandler(this.ID_CGR_CON_PB_Click);
        // 
        // _ID_CGR_ETI_PNL_0Label_Text
        // 
        this._ID_CGR_ETI_PNL_0Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CGR_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CGR_ETI_PNL_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_CGR_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(15, 17);
        this._ID_CGR_ETI_PNL_0Label_Text.Name = "_ID_CGR_ETI_PNL_0Label_Text";
        this._ID_CGR_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(41, 21);
        this._ID_CGR_ETI_PNL_0Label_Text.TabIndex = 0;
        this._ID_CGR_ETI_PNL_0Label_Text.Tag = "";
        this._ID_CGR_ETI_PNL_0Label_Text.Text = "No.";
        this._ID_CGR_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_CGR_GRP_LB
        // 
        this.ID_CGR_GRP_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CGR_GRP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CGR_GRP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CGR_GRP_LB.Location = new System.Drawing.Point(15, 38);
        this.ID_CGR_GRP_LB.Name = "ID_CGR_GRP_LB";
        this.ID_CGR_GRP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CGR_GRP_LB.Size = new System.Drawing.Size(300, 108);
        this.ID_CGR_GRP_LB.Sorted = true;
        this.ID_CGR_GRP_LB.TabIndex = 8;
        this.ID_CGR_GRP_LB.Tag = "";
        this.ID_CGR_GRP_LB.DoubleClick += new System.EventHandler(this.ID_CGR_GRP_LB_DoubleClick);
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.Color.Silver;
        this.panel1.Controls.Add(this.ID_CGR_IRA_3CKB);
        this.panel1.Controls.Add(this._ID_CGR_ETI_PNL_0Label_Text);
        this.panel1.Controls.Add(this.ID_CGR_NOM_PNLLabel_Text);
        this.panel1.Controls.Add(this.ID_CGR_GRP_LB);
        this.panel1.Controls.Add(this.ID_CGR_CER_PB);
        this.panel1.Controls.Add(this.ID_CGR_CAM_PB);
        this.panel1.Controls.Add(this.ID_CGR_BAJ_PB);
        this.panel1.Controls.Add(this.ID_CGR_ALT_PB);
        this.panel1.Controls.Add(this.ID_CGR_CON_PB);
        this.panel1.Location = new System.Drawing.Point(1, 1);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(421, 235);
        this.panel1.TabIndex = 1;
        // 
        // ID_CGR_IRA_3CKB
        // 
        this.ID_CGR_IRA_3CKB.Location = new System.Drawing.Point(15, 172);
        this.ID_CGR_IRA_3CKB.Name = "ID_CGR_IRA_3CKB";
        this.ID_CGR_IRA_3CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CGR_IRA_3CKB.OcxState")));
        this.ID_CGR_IRA_3CKB.Size = new System.Drawing.Size(181, 26);
        this.ID_CGR_IRA_3CKB.TabIndex = 9;
        this.ID_CGR_IRA_3CKB.Tag = "";
        // 
        // CORCTGRU
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(420, 236);
        this.Controls.Add(this.panel1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(173, 190);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCTGRU";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Corporativos";
        this.Closed += new System.EventHandler(this.CORCTGRU_Closed);
        this.Activated += new System.EventHandler(this.CORCTGRU_Activated);
        this.panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CGR_IRA_3CKB)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_CGR_ETI_PNL()
	{
			//this.ID_CGR_ETI_PNL[0] = _ID_CGR_ETI_PNL_0;
	}
#endregion 

        private System.Windows.Forms.Panel panel1;
}
}