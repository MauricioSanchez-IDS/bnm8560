using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORCTDIV
	{
	
#region "Upgrade Support "
		private static CORCTDIV m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTDIV DefInstance
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
		public CORCTDIV():base(){
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
	public static CORCTDIV CreateInstance()
	{
			CORCTDIV theInstance = new CORCTDIV();
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
	public  System.Windows.Forms.Button ID_DIV_CON_PB;
	public  System.Windows.Forms.Button ID_DIV_CAM_PB;
	public  System.Windows.Forms.Button ID_DIV_BAJ_PB;
	public  System.Windows.Forms.Button ID_DIV_ALT_PB;
	public  System.Windows.Forms.Button ID_DIV_CER_PB;
	public  System.Windows.Forms.ListBox ID_DIV_GRP_LB;
	public  System.Windows.Forms.Label SSPanel1Label_Text;
	public  AxThreed.AxSSPanel SSPanel1;
	public  System.Windows.Forms.Label ID_DIV_DES_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_DIV_DES_PNL;
	public  AxThreed.AxSSPanel ID_DIV_PPL_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTDIV));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_DIV_PPL_PNL = new AxThreed.AxSSPanel();
        this.ID_DIV_ALT_PB = new System.Windows.Forms.Button();
        this.ID_DIV_BAJ_PB = new System.Windows.Forms.Button();
        this.ID_DIV_CAM_PB = new System.Windows.Forms.Button();
        this.ID_DIV_CER_PB = new System.Windows.Forms.Button();
        this.ID_DIV_DES_PNL = new AxThreed.AxSSPanel();
        this.ID_DIV_DES_PNLLabel_Text = new System.Windows.Forms.Label();
        this.SSPanel1 = new AxThreed.AxSSPanel();
        this.SSPanel1Label_Text = new System.Windows.Forms.Label();
        this.ID_DIV_GRP_LB = new System.Windows.Forms.ListBox();
        this.ID_DIV_CON_PB = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DIV_PPL_PNL)).BeginInit();
        this.ID_DIV_PPL_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DIV_DES_PNL)).BeginInit();
        this.ID_DIV_DES_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).BeginInit();
        this.SSPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_DIV_PPL_PNL
        // 
        this.ID_DIV_PPL_PNL.Controls.Add(this.ID_DIV_ALT_PB);
        this.ID_DIV_PPL_PNL.Controls.Add(this.ID_DIV_BAJ_PB);
        this.ID_DIV_PPL_PNL.Controls.Add(this.ID_DIV_CAM_PB);
        this.ID_DIV_PPL_PNL.Controls.Add(this.ID_DIV_CER_PB);
        this.ID_DIV_PPL_PNL.Controls.Add(this.ID_DIV_DES_PNL);
        this.ID_DIV_PPL_PNL.Controls.Add(this.SSPanel1);
        this.ID_DIV_PPL_PNL.Controls.Add(this.ID_DIV_GRP_LB);
        this.ID_DIV_PPL_PNL.Controls.Add(this.ID_DIV_CON_PB);
        this.ID_DIV_PPL_PNL.Location = new System.Drawing.Point(1, 0);
        this.ID_DIV_PPL_PNL.Name = "ID_DIV_PPL_PNL";
        this.ID_DIV_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DIV_PPL_PNL.OcxState")));
        this.ID_DIV_PPL_PNL.Size = new System.Drawing.Size(331, 205);
        this.ID_DIV_PPL_PNL.TabIndex = 0;
        this.ID_DIV_PPL_PNL.Tag = "";
        this.ID_DIV_PPL_PNL.MouseMoveEvent += new AxThreed.ISSPNCtrlEvents_MouseMoveEventHandler(this.ID_DIV_PPL_PNL_MouseMoveEvent);
        // 
        // ID_DIV_ALT_PB
        // 
        this.ID_DIV_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DIV_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DIV_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DIV_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DIV_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DIV_ALT_PB.Location = new System.Drawing.Point(232, 46);
        this.ID_DIV_ALT_PB.Name = "ID_DIV_ALT_PB";
        this.ID_DIV_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DIV_ALT_PB.Size = new System.Drawing.Size(84, 22);
        this.ID_DIV_ALT_PB.TabIndex = 5;
        this.ID_DIV_ALT_PB.Tag = "";
        this.ID_DIV_ALT_PB.Text = "&Alta...";
        this.ID_DIV_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_DIV_ALT_PB.Click += new System.EventHandler(this.ID_DIV_ALT_PB_Click);
        // 
        // ID_DIV_BAJ_PB
        // 
        this.ID_DIV_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DIV_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DIV_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DIV_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DIV_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DIV_BAJ_PB.Location = new System.Drawing.Point(232, 71);
        this.ID_DIV_BAJ_PB.Name = "ID_DIV_BAJ_PB";
        this.ID_DIV_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DIV_BAJ_PB.Size = new System.Drawing.Size(84, 22);
        this.ID_DIV_BAJ_PB.TabIndex = 6;
        this.ID_DIV_BAJ_PB.Tag = "";
        this.ID_DIV_BAJ_PB.Text = "&Baja";
        this.ID_DIV_BAJ_PB.UseVisualStyleBackColor = false;
        this.ID_DIV_BAJ_PB.Click += new System.EventHandler(this.ID_DIV_BAJ_PB_Click);
        this.ID_DIV_BAJ_PB.Leave += new System.EventHandler(this.ID_DIV_BAJ_PB_Leave);
        // 
        // ID_DIV_CAM_PB
        // 
        this.ID_DIV_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DIV_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DIV_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DIV_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DIV_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DIV_CAM_PB.Location = new System.Drawing.Point(232, 96);
        this.ID_DIV_CAM_PB.Name = "ID_DIV_CAM_PB";
        this.ID_DIV_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DIV_CAM_PB.Size = new System.Drawing.Size(84, 22);
        this.ID_DIV_CAM_PB.TabIndex = 7;
        this.ID_DIV_CAM_PB.Tag = "";
        this.ID_DIV_CAM_PB.Text = "&Cambio...";
        this.ID_DIV_CAM_PB.UseVisualStyleBackColor = false;
        this.ID_DIV_CAM_PB.Click += new System.EventHandler(this.ID_DIV_CAM_PB_Click);
        // 
        // ID_DIV_CER_PB
        // 
        this.ID_DIV_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DIV_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DIV_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DIV_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DIV_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DIV_CER_PB.Location = new System.Drawing.Point(232, 157);
        this.ID_DIV_CER_PB.Name = "ID_DIV_CER_PB";
        this.ID_DIV_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DIV_CER_PB.Size = new System.Drawing.Size(84, 22);
        this.ID_DIV_CER_PB.TabIndex = 4;
        this.ID_DIV_CER_PB.Tag = "";
        this.ID_DIV_CER_PB.Text = "&Salir";
        this.ID_DIV_CER_PB.UseVisualStyleBackColor = false;
        this.ID_DIV_CER_PB.Click += new System.EventHandler(this.ID_DIV_CER_PB_Click);
        // 
        // ID_DIV_DES_PNL
        // 
        this.ID_DIV_DES_PNL.Controls.Add(this.ID_DIV_DES_PNLLabel_Text);
        this.ID_DIV_DES_PNL.Location = new System.Drawing.Point(49, 21);
        this.ID_DIV_DES_PNL.Name = "ID_DIV_DES_PNL";
        this.ID_DIV_DES_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DIV_DES_PNL.OcxState")));
        this.ID_DIV_DES_PNL.Size = new System.Drawing.Size(178, 24);
        this.ID_DIV_DES_PNL.TabIndex = 2;
        this.ID_DIV_DES_PNL.Tag = "";
        // 
        // ID_DIV_DES_PNLLabel_Text
        // 
        this.ID_DIV_DES_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DIV_DES_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_DIV_DES_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_DIV_DES_PNLLabel_Text.Name = "ID_DIV_DES_PNLLabel_Text";
        this.ID_DIV_DES_PNLLabel_Text.Size = new System.Drawing.Size(176, 22);
        this.ID_DIV_DES_PNLLabel_Text.TabIndex = 0;
        this.ID_DIV_DES_PNLLabel_Text.Tag = "";
        this.ID_DIV_DES_PNLLabel_Text.Text = "División Regional";
        this.ID_DIV_DES_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // SSPanel1
        // 
        this.SSPanel1.Controls.Add(this.SSPanel1Label_Text);
        this.SSPanel1.Location = new System.Drawing.Point(18, 21);
        this.SSPanel1.Name = "SSPanel1";
        this.SSPanel1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel1.OcxState")));
        this.SSPanel1.Size = new System.Drawing.Size(32, 24);
        this.SSPanel1.TabIndex = 1;
        this.SSPanel1.Tag = "";
        // 
        // SSPanel1Label_Text
        // 
        this.SSPanel1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.SSPanel1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.SSPanel1Label_Text.Location = new System.Drawing.Point(0, 0);
        this.SSPanel1Label_Text.Name = "SSPanel1Label_Text";
        this.SSPanel1Label_Text.Size = new System.Drawing.Size(30, 22);
        this.SSPanel1Label_Text.TabIndex = 0;
        this.SSPanel1Label_Text.Tag = "";
        this.SSPanel1Label_Text.Text = " No.";
        this.SSPanel1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_DIV_GRP_LB
        // 
        this.ID_DIV_GRP_LB.BackColor = System.Drawing.Color.White;
        this.ID_DIV_GRP_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DIV_GRP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DIV_GRP_LB.ForeColor = System.Drawing.Color.Black;
        this.ID_DIV_GRP_LB.Location = new System.Drawing.Point(17, 47);
        this.ID_DIV_GRP_LB.Name = "ID_DIV_GRP_LB";
        this.ID_DIV_GRP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DIV_GRP_LB.Size = new System.Drawing.Size(207, 108);
        this.ID_DIV_GRP_LB.Sorted = true;
        this.ID_DIV_GRP_LB.TabIndex = 3;
        this.ID_DIV_GRP_LB.Tag = "";
        this.ID_DIV_GRP_LB.DoubleClick += new System.EventHandler(this.ID_DIV_GRP_LB_DoubleClick);
        this.ID_DIV_GRP_LB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ID_DIV_GRP_LB_KeyDown);
        // 
        // ID_DIV_CON_PB
        // 
        this.ID_DIV_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DIV_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DIV_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DIV_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DIV_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DIV_CON_PB.Location = new System.Drawing.Point(232, 121);
        this.ID_DIV_CON_PB.Name = "ID_DIV_CON_PB";
        this.ID_DIV_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DIV_CON_PB.Size = new System.Drawing.Size(84, 22);
        this.ID_DIV_CON_PB.TabIndex = 8;
        this.ID_DIV_CON_PB.Tag = "";
        this.ID_DIV_CON_PB.Text = "C&onsulta...";
        this.ID_DIV_CON_PB.UseVisualStyleBackColor = false;
        this.ID_DIV_CON_PB.Click += new System.EventHandler(this.ID_DIV_CON_PB_Click);
        // 
        // CORCTDIV
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(331, 205);
        this.Controls.Add(this.ID_DIV_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(222, 159);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCTDIV";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Divisiones Regionales";
        this.Closed += new System.EventHandler(this.CORCTDIV_Closed);
        this.Activated += new System.EventHandler(this.CORCTDIV_Activated);
        ((System.ComponentModel.ISupportInitialize)(this.ID_DIV_PPL_PNL)).EndInit();
        this.ID_DIV_PPL_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_DIV_DES_PNL)).EndInit();
        this.ID_DIV_DES_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).EndInit();
        this.SSPanel1.ResumeLayout(false);
        this.ResumeLayout(false);

	}
#endregion 
}
}