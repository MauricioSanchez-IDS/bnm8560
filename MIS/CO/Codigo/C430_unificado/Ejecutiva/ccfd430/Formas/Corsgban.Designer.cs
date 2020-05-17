using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORSGBAN
	{
	
#region "Upgrade Support "
		private static CORSGBAN m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORSGBAN DefInstance
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
		public CORSGBAN():base(){
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
	public static CORSGBAN CreateInstance()
	{
			CORSGBAN theInstance = new CORSGBAN();
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
	public  System.Windows.Forms.Button ID_BAN_SAL_PB;
	public  System.Windows.Forms.ListBox ID_BAN_BAN_LB;
	public  System.Windows.Forms.Label ID_BAN_NUM_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_BAN_NUM_PNL;
	public  System.Windows.Forms.Label ID_BAN_DES_PNLLabel_Text;
        public AxThreed.AxSSPanel ID_BAN_DES_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORSGBAN));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_BAN_BAN_LB = new System.Windows.Forms.ListBox();
        this.ID_BAN_SAL_PB = new System.Windows.Forms.Button();
        this.ID_BAN_DES_PNL = new AxThreed.AxSSPanel();
        this.ID_BAN_DES_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_BAN_NUM_PNL = new AxThreed.AxSSPanel();
        this.ID_BAN_NUM_PNLLabel_Text = new System.Windows.Forms.Label();
        this.panel1 = new System.Windows.Forms.Panel();
        ((System.ComponentModel.ISupportInitialize)(this.ID_BAN_DES_PNL)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_BAN_NUM_PNL)).BeginInit();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_BAN_BAN_LB
        // 
        this.ID_BAN_BAN_LB.BackColor = System.Drawing.Color.White;
        this.ID_BAN_BAN_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_BAN_BAN_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_BAN_BAN_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_BAN_BAN_LB.Location = new System.Drawing.Point(19, 47);
        this.ID_BAN_BAN_LB.Name = "ID_BAN_BAN_LB";
        this.ID_BAN_BAN_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_BAN_BAN_LB.Size = new System.Drawing.Size(305, 82);
        this.ID_BAN_BAN_LB.TabIndex = 2;
        this.ID_BAN_BAN_LB.Tag = "";
        // 
        // ID_BAN_SAL_PB
        // 
        this.ID_BAN_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_BAN_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_BAN_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_BAN_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_BAN_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_BAN_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_BAN_SAL_PB.Location = new System.Drawing.Point(117, 141);
        this.ID_BAN_SAL_PB.Name = "ID_BAN_SAL_PB";
        this.ID_BAN_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_BAN_SAL_PB.Size = new System.Drawing.Size(102, 25);
        this.ID_BAN_SAL_PB.TabIndex = 0;
        this.ID_BAN_SAL_PB.Tag = "";
        this.ID_BAN_SAL_PB.Text = "&Cambiar a... ";
        this.ID_BAN_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_BAN_SAL_PB.Click += new System.EventHandler(this.ID_BAN_SAL_PB_Click);
        // 
        // ID_BAN_DES_PNL
        // 
        this.ID_BAN_DES_PNL.Location = new System.Drawing.Point(307, 20);
        this.ID_BAN_DES_PNL.Name = "ID_BAN_DES_PNL";
        this.ID_BAN_DES_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_BAN_DES_PNL.OcxState")));
        this.ID_BAN_DES_PNL.Size = new System.Drawing.Size(227, 36);
        this.ID_BAN_DES_PNL.TabIndex = 4;
        this.ID_BAN_DES_PNL.Tag = "";
        // 
        // ID_BAN_DES_PNLLabel_Text
        // 
        this.ID_BAN_DES_PNLLabel_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.ID_BAN_DES_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_BAN_DES_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_BAN_DES_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_BAN_DES_PNLLabel_Text.Location = new System.Drawing.Point(105, 14);
        this.ID_BAN_DES_PNLLabel_Text.Name = "ID_BAN_DES_PNLLabel_Text";
        this.ID_BAN_DES_PNLLabel_Text.Size = new System.Drawing.Size(219, 30);
        this.ID_BAN_DES_PNLLabel_Text.TabIndex = 0;
        this.ID_BAN_DES_PNLLabel_Text.Tag = "";
        this.ID_BAN_DES_PNLLabel_Text.Text = "&Descripción";
        this.ID_BAN_DES_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_BAN_NUM_PNL
        // 
        this.ID_BAN_NUM_PNL.Location = new System.Drawing.Point(3, 78);
        this.ID_BAN_NUM_PNL.Name = "ID_BAN_NUM_PNL";
        this.ID_BAN_NUM_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_BAN_NUM_PNL.OcxState")));
        this.ID_BAN_NUM_PNL.Size = new System.Drawing.Size(89, 36);
        this.ID_BAN_NUM_PNL.TabIndex = 3;
        this.ID_BAN_NUM_PNL.Tag = "";
        // 
        // ID_BAN_NUM_PNLLabel_Text
        // 
        this.ID_BAN_NUM_PNLLabel_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.ID_BAN_NUM_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_BAN_NUM_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_BAN_NUM_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_BAN_NUM_PNLLabel_Text.Location = new System.Drawing.Point(19, 14);
        this.ID_BAN_NUM_PNLLabel_Text.Name = "ID_BAN_NUM_PNLLabel_Text";
        this.ID_BAN_NUM_PNLLabel_Text.Size = new System.Drawing.Size(80, 30);
        this.ID_BAN_NUM_PNLLabel_Text.TabIndex = 0;
        this.ID_BAN_NUM_PNLLabel_Text.Tag = "";
        this.ID_BAN_NUM_PNLLabel_Text.Text = "&Pref - Núm.";
        this.ID_BAN_NUM_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.Color.Silver;
        this.panel1.Controls.Add(this.ID_BAN_NUM_PNLLabel_Text);
        this.panel1.Controls.Add(this.ID_BAN_SAL_PB);
        this.panel1.Controls.Add(this.ID_BAN_DES_PNLLabel_Text);
        this.panel1.Controls.Add(this.ID_BAN_BAN_LB);
        this.panel1.Location = new System.Drawing.Point(1, 2);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(340, 182);
        this.panel1.TabIndex = 5;
        // 
        // CORSGBAN
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(339, 181);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.ID_BAN_DES_PNL);
        this.Controls.Add(this.ID_BAN_NUM_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(184, 140);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORSGBAN";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Banco de Operación";
        this.Closed += new System.EventHandler(this.CORSGBAN_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_BAN_DES_PNL)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_BAN_NUM_PNL)).EndInit();
        this.panel1.ResumeLayout(false);
        this.ResumeLayout(false);

	}
#endregion 

        private System.Windows.Forms.Panel panel1;
}
}