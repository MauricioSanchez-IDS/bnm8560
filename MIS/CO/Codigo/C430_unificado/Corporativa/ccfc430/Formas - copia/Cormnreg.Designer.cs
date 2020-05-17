using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORMNREG
	{
	
#region "Upgrade Support "
		private static CORMNREG m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNREG DefInstance
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
		public CORMNREG():base(){
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
		}
	public static CORMNREG CreateInstance()
	{
			CORMNREG theInstance = new CORMNREG();
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
	public  System.Windows.Forms.Button ID_REG_CAN_PB;
	public  System.Windows.Forms.Button ID_REG_ACE_PB;
	public  System.Windows.Forms.Button ID_REG_IMP_PB;
	public  AxMSMask.AxMaskEdBox ID_REG_CVE_EB;
	public  System.Windows.Forms.TextBox ID_REG_REG_EB;
	public  System.Windows.Forms.Label ID_REG_REG_TXT;
	public  System.Windows.Forms.Label ID_REG_CVE_TXT;
	public  AxThreed.AxSSFrame ID_REG_PRI_FRM;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNREG));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_REG_CAN_PB = new System.Windows.Forms.Button();
        this.ID_REG_ACE_PB = new System.Windows.Forms.Button();
        this.ID_REG_IMP_PB = new System.Windows.Forms.Button();
        this.ID_REG_PRI_FRM = new AxThreed.AxSSFrame();
        this.ID_REG_REG_EB = new System.Windows.Forms.TextBox();
        this.ID_REG_CVE_EB = new AxMSMask.AxMaskEdBox();
        this.ID_REG_CVE_TXT = new System.Windows.Forms.Label();
        this.ID_REG_REG_TXT = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REG_PRI_FRM)).BeginInit();
        this.ID_REG_PRI_FRM.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REG_CVE_EB)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_REG_CAN_PB
        // 
        this.ID_REG_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_REG_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_CAN_PB.Location = new System.Drawing.Point(121, 118);
        this.ID_REG_CAN_PB.Name = "ID_REG_CAN_PB";
        this.ID_REG_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_CAN_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_REG_CAN_PB.TabIndex = 7;
        this.ID_REG_CAN_PB.Tag = "";
        this.ID_REG_CAN_PB.Text = "Cancelar";
        this.ID_REG_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_REG_CAN_PB.Click += new System.EventHandler(this.ID_REG_CAN_PB_Click);
        // 
        // ID_REG_ACE_PB
        // 
        this.ID_REG_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_ACE_PB.Location = new System.Drawing.Point(45, 118);
        this.ID_REG_ACE_PB.Name = "ID_REG_ACE_PB";
        this.ID_REG_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_ACE_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_REG_ACE_PB.TabIndex = 6;
        this.ID_REG_ACE_PB.Tag = "";
        this.ID_REG_ACE_PB.Text = "Aceptar";
        this.ID_REG_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_REG_ACE_PB.Click += new System.EventHandler(this.ID_REG_ACE_PB_Click);
        // 
        // ID_REG_IMP_PB
        // 
        this.ID_REG_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_IMP_PB.Location = new System.Drawing.Point(209, 118);
        this.ID_REG_IMP_PB.Name = "ID_REG_IMP_PB";
        this.ID_REG_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_IMP_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_REG_IMP_PB.TabIndex = 5;
        this.ID_REG_IMP_PB.Tag = "";
        this.ID_REG_IMP_PB.Text = "&Imprimir";
        this.ID_REG_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_REG_IMP_PB.Click += new System.EventHandler(this.ID_REG_IMP_PB_Click);
        // 
        // ID_REG_PRI_FRM
        // 
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_REG_REG_EB);
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_REG_CVE_EB);
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_REG_CVE_TXT);
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_REG_REG_TXT);
        this.ID_REG_PRI_FRM.Location = new System.Drawing.Point(24, 22);
        this.ID_REG_PRI_FRM.Name = "ID_REG_PRI_FRM";
        this.ID_REG_PRI_FRM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REG_PRI_FRM.OcxState")));
        this.ID_REG_PRI_FRM.Size = new System.Drawing.Size(290, 85);
        this.ID_REG_PRI_FRM.TabIndex = 0;
        this.ID_REG_PRI_FRM.Tag = "";
        // 
        // ID_REG_REG_EB
        // 
        this.ID_REG_REG_EB.AcceptsReturn = true;
        this.ID_REG_REG_EB.BackColor = System.Drawing.Color.White;
        this.ID_REG_REG_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_REG_REG_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_REG_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_REG_REG_EB.Location = new System.Drawing.Point(90, 53);
        this.ID_REG_REG_EB.MaxLength = 18;
        this.ID_REG_REG_EB.Name = "ID_REG_REG_EB";
        this.ID_REG_REG_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_REG_EB.Size = new System.Drawing.Size(189, 20);
        this.ID_REG_REG_EB.TabIndex = 4;
        this.ID_REG_REG_EB.Tag = "";
        this.ID_REG_REG_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_REG_REG_EB_KeyPress);
        // 
        // ID_REG_CVE_EB
        // 
        this.ID_REG_CVE_EB.Location = new System.Drawing.Point(90, 25);
        this.ID_REG_CVE_EB.Name = "ID_REG_CVE_EB";
        this.ID_REG_CVE_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REG_CVE_EB.OcxState")));
        this.ID_REG_CVE_EB.Size = new System.Drawing.Size(31, 24);
        this.ID_REG_CVE_EB.TabIndex = 3;
        this.ID_REG_CVE_EB.Tag = "";
        this.ID_REG_CVE_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_REG_CVE_EB_KeyPressEvent);
        // 
        // ID_REG_CVE_TXT
        // 
        this.ID_REG_CVE_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_REG_CVE_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_CVE_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_CVE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_CVE_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_CVE_TXT.Location = new System.Drawing.Point(15, 28);
        this.ID_REG_CVE_TXT.Name = "ID_REG_CVE_TXT";
        this.ID_REG_CVE_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_CVE_TXT.Size = new System.Drawing.Size(85, 19);
        this.ID_REG_CVE_TXT.TabIndex = 1;
        this.ID_REG_CVE_TXT.Tag = "";
        this.ID_REG_CVE_TXT.Text = "Clave";
        // 
        // ID_REG_REG_TXT
        // 
        this.ID_REG_REG_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_REG_REG_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_REG_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_REG_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_REG_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_REG_TXT.Location = new System.Drawing.Point(15, 56);
        this.ID_REG_REG_TXT.Name = "ID_REG_REG_TXT";
        this.ID_REG_REG_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_REG_TXT.Size = new System.Drawing.Size(75, 17);
        this.ID_REG_REG_TXT.TabIndex = 2;
        this.ID_REG_REG_TXT.Tag = "";
        this.ID_REG_REG_TXT.Text = "Descripción";
        // 
        // CORMNREG
        // 
        this.AcceptButton = this.ID_REG_ACE_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_REG_CAN_PB;
        this.ClientSize = new System.Drawing.Size(335, 158);
        this.Controls.Add(this.ID_REG_PRI_FRM);
        this.Controls.Add(this.ID_REG_IMP_PB);
        this.Controls.Add(this.ID_REG_CAN_PB);
        this.Controls.Add(this.ID_REG_ACE_PB);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(200, 121);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORMNREG";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Regiones";
        this.Closed += new System.EventHandler(this.CORMNREG_Closed);
        this.Activated += new System.EventHandler(this.CORMNREG_Activated);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORMNREG_KeyPress);
        ((System.ComponentModel.ISupportInitialize)(this.ID_REG_PRI_FRM)).EndInit();
        this.ID_REG_PRI_FRM.ResumeLayout(false);
        this.ID_REG_PRI_FRM.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REG_CVE_EB)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}