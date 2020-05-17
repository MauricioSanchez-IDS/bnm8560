using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORREGFI
	{
	
#region "Upgrade Support "
		private static CORREGFI m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORREGFI DefInstance
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
		public CORREGFI():base(){
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
	public static CORREGFI CreateInstance()
	{
			CORREGFI theInstance = new CORREGFI();
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
	public  System.Windows.Forms.Button ID_FIR_FR3_PB;
	public  System.Windows.Forms.Button ID_FIR_FR2_PB;
	public  System.Windows.Forms.Button ID_FIR_FR1_PB;
	public  System.Windows.Forms.Button ID_FIR_INS_PB;
	public  System.Windows.Forms.Button ID_FIR_SCA_PB;
	public  System.Windows.Forms.Button ID_FIR_ACE_PB;
        public System.Windows.Forms.Button ID_FIR_CAN_PB;
	public  AxGEARLib.AxGear ID_FIR_FR3_IMM;
	public  AxGEARLib.AxGear ID_FIR_FR2_IMM;
	public  AxGEARLib.AxGear ID_FIR_FR1_IMM;
	public  AxGEARLib.AxGear ID_FIR_OK_IMM;
	public  AxGEARLib.AxGear ID_FIR_PAG_IMM;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	//[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORREGFI));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_FIR_FR3_PB = new System.Windows.Forms.Button();
        this.ID_FIR_FR2_PB = new System.Windows.Forms.Button();
        this.ID_FIR_FR1_PB = new System.Windows.Forms.Button();
        this.ID_FIR_INS_PB = new System.Windows.Forms.Button();
        this.ID_FIR_SCA_PB = new System.Windows.Forms.Button();
        this.ID_FIR_ACE_PB = new System.Windows.Forms.Button();
        this.ID_FIR_CAN_PB = new System.Windows.Forms.Button();
        this.ID_FIR_FR3_IMM = new AxGEARLib.AxGear();
        this.ID_FIR_FR2_IMM = new AxGEARLib.AxGear();
        this.ID_FIR_FR1_IMM = new AxGEARLib.AxGear();
        this.ID_FIR_OK_IMM = new AxGEARLib.AxGear();
        this.ID_FIR_PAG_IMM = new AxGEARLib.AxGear();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR3_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR2_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR1_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_OK_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_PAG_IMM)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_FIR_FR3_PB
        // 
        this.ID_FIR_FR3_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_FR3_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_FR3_PB.Enabled = false;
        this.ID_FIR_FR3_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_FR3_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_FR3_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_FR3_PB.Location = new System.Drawing.Point(379, 78);
        this.ID_FIR_FR3_PB.Name = "ID_FIR_FR3_PB";
        this.ID_FIR_FR3_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_FR3_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_FR3_PB.TabIndex = 2;
        this.ID_FIR_FR3_PB.Tag = "";
        this.ID_FIR_FR3_PB.Text = "Represt. &3";
        this.ID_FIR_FR3_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_FR3_PB.Click += new System.EventHandler(this.ID_FIR_FR3_PB_Click);
        // 
        // ID_FIR_FR2_PB
        // 
        this.ID_FIR_FR2_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_FR2_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_FR2_PB.Enabled = false;
        this.ID_FIR_FR2_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_FR2_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_FR2_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_FR2_PB.Location = new System.Drawing.Point(379, 48);
        this.ID_FIR_FR2_PB.Name = "ID_FIR_FR2_PB";
        this.ID_FIR_FR2_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_FR2_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_FR2_PB.TabIndex = 1;
        this.ID_FIR_FR2_PB.Tag = "";
        this.ID_FIR_FR2_PB.Text = "Represt. &2";
        this.ID_FIR_FR2_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_FR2_PB.Click += new System.EventHandler(this.ID_FIR_FR2_PB_Click);
        // 
        // ID_FIR_FR1_PB
        // 
        this.ID_FIR_FR1_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_FR1_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_FR1_PB.Enabled = false;
        this.ID_FIR_FR1_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_FR1_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_FR1_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_FR1_PB.Location = new System.Drawing.Point(379, 19);
        this.ID_FIR_FR1_PB.Name = "ID_FIR_FR1_PB";
        this.ID_FIR_FR1_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_FR1_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_FR1_PB.TabIndex = 0;
        this.ID_FIR_FR1_PB.Tag = "";
        this.ID_FIR_FR1_PB.Text = "Represt. &1";
        this.ID_FIR_FR1_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_FR1_PB.Click += new System.EventHandler(this.ID_FIR_FR1_PB_Click);
        // 
        // ID_FIR_INS_PB
        // 
        this.ID_FIR_INS_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_INS_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_INS_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_INS_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_INS_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_INS_PB.Location = new System.Drawing.Point(222, 180);
        this.ID_FIR_INS_PB.Name = "ID_FIR_INS_PB";
        this.ID_FIR_INS_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_INS_PB.Size = new System.Drawing.Size(79, 21);
        this.ID_FIR_INS_PB.TabIndex = 4;
        this.ID_FIR_INS_PB.Tag = "";
        this.ID_FIR_INS_PB.Text = "&Instalar";
        this.ID_FIR_INS_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_INS_PB.Click += new System.EventHandler(this.ID_FIR_INS_PB_Click);
        // 
        // ID_FIR_SCA_PB
        // 
        this.ID_FIR_SCA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_SCA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_SCA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_SCA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_SCA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_SCA_PB.Location = new System.Drawing.Point(46, 179);
        this.ID_FIR_SCA_PB.Name = "ID_FIR_SCA_PB";
        this.ID_FIR_SCA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_SCA_PB.Size = new System.Drawing.Size(76, 22);
        this.ID_FIR_SCA_PB.TabIndex = 3;
        this.ID_FIR_SCA_PB.Tag = "";
        this.ID_FIR_SCA_PB.Text = "&Scanear";
        this.ID_FIR_SCA_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_SCA_PB.Click += new System.EventHandler(this.ID_FIR_SCA_PB_Click);
        // 
        // ID_FIR_ACE_PB
        // 
        this.ID_FIR_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_ACE_PB.Location = new System.Drawing.Point(362, 149);
        this.ID_FIR_ACE_PB.Name = "ID_FIR_ACE_PB";
        this.ID_FIR_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_ACE_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_ACE_PB.TabIndex = 7;
        this.ID_FIR_ACE_PB.Tag = "";
        this.ID_FIR_ACE_PB.Text = "Aceptar";
        this.ID_FIR_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_ACE_PB.Click += new System.EventHandler(this.ID_FIR_ACE_PB_Click);
        // 
        // ID_FIR_CAN_PB
        // 
        this.ID_FIR_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_CAN_PB.Location = new System.Drawing.Point(361, 177);
        this.ID_FIR_CAN_PB.Name = "ID_FIR_CAN_PB";
        this.ID_FIR_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_CAN_PB.TabIndex = 6;
        this.ID_FIR_CAN_PB.Tag = "";
        this.ID_FIR_CAN_PB.Text = "Cancelar";
        this.ID_FIR_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_CAN_PB.Click += new System.EventHandler(this.ID_FIR_CAN_PB_Click);
        // 
        // ID_FIR_FR3_IMM
        // 
        this.ID_FIR_FR3_IMM.Enabled = true;
        this.ID_FIR_FR3_IMM.Location = new System.Drawing.Point(341, 77);
        this.ID_FIR_FR3_IMM.Name = "ID_FIR_FR3_IMM";
        this.ID_FIR_FR3_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_FR3_IMM.OcxState")));
        this.ID_FIR_FR3_IMM.Size = new System.Drawing.Size(36, 26);
        this.ID_FIR_FR3_IMM.TabIndex = 12;
        this.ID_FIR_FR3_IMM.Tag = "";
       
        // 
        // ID_FIR_FR2_IMM
        // 
        this.ID_FIR_FR2_IMM.Enabled = true;
        this.ID_FIR_FR2_IMM.Location = new System.Drawing.Point(341, 48);
        this.ID_FIR_FR2_IMM.Name = "ID_FIR_FR2_IMM";
        this.ID_FIR_FR2_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_FR2_IMM.OcxState")));
        this.ID_FIR_FR2_IMM.Size = new System.Drawing.Size(36, 26);
        this.ID_FIR_FR2_IMM.TabIndex = 11;
        this.ID_FIR_FR2_IMM.Tag = "";
        // 
        // ID_FIR_FR1_IMM
        // 
        this.ID_FIR_FR1_IMM.Enabled = true;
        this.ID_FIR_FR1_IMM.Location = new System.Drawing.Point(340, 18);
        this.ID_FIR_FR1_IMM.Name = "ID_FIR_FR1_IMM";
        this.ID_FIR_FR1_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_FR1_IMM.OcxState")));
        this.ID_FIR_FR1_IMM.Size = new System.Drawing.Size(36, 26);
        this.ID_FIR_FR1_IMM.TabIndex = 10;
        this.ID_FIR_FR1_IMM.Tag = "";
        // 
        // ID_FIR_OK_IMM
        // 
        this.ID_FIR_OK_IMM.Enabled = true;
        this.ID_FIR_OK_IMM.Location = new System.Drawing.Point(192, 14);
        this.ID_FIR_OK_IMM.Name = "ID_FIR_OK_IMM";
        this.ID_FIR_OK_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_OK_IMM.OcxState")));
        this.ID_FIR_OK_IMM.Size = new System.Drawing.Size(134, 158);
        this.ID_FIR_OK_IMM.TabIndex = 9;
        this.ID_FIR_OK_IMM.Tag = "";
        // 
        // ID_FIR_PAG_IMM
        // 
        this.ID_FIR_PAG_IMM.Enabled = true;
        this.ID_FIR_PAG_IMM.Location = new System.Drawing.Point(27, 14);
        this.ID_FIR_PAG_IMM.Name = "ID_FIR_PAG_IMM";
        this.ID_FIR_PAG_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_PAG_IMM.OcxState")));
        this.ID_FIR_PAG_IMM.Size = new System.Drawing.Size(134, 158);
        this.ID_FIR_PAG_IMM.TabIndex = 8;
        this.ID_FIR_PAG_IMM.Tag = "";
        this.ID_FIR_PAG_IMM.SelectEventEvent += new AxGEARLib._DGearEvents_SelectEventEventHandler(this.ID_FIR_PAG_IMM_SelectEvent);
        this.ID_FIR_PAG_IMM.ClickEvent += new System.EventHandler(this.ID_FIR_PAG_IMM_Click);
        // 
        // CORREGFI
        // 
        this.AcceptButton = this.ID_FIR_SCA_PB;
       
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.ClientSize = new System.Drawing.Size(463, 217);
        this.Controls.Add(this.ID_FIR_CAN_PB);
        this.Controls.Add(this.ID_FIR_ACE_PB);
        this.Controls.Add(this.ID_FIR_FR1_IMM);
        this.Controls.Add(this.ID_FIR_FR2_IMM);
        this.Controls.Add(this.ID_FIR_FR3_IMM);
        this.Controls.Add(this.ID_FIR_INS_PB);
        this.Controls.Add(this.ID_FIR_SCA_PB);
 
        this.Controls.Add(this.ID_FIR_FR3_PB);
        
        this.Controls.Add(this.ID_FIR_FR2_PB);
        this.Controls.Add(this.ID_FIR_FR1_PB);
        this.Controls.Add(this.ID_FIR_OK_IMM);
        this.Controls.Add(this.ID_FIR_PAG_IMM);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.Location = new System.Drawing.Point(150, 205);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORREGFI";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Firmas";
        this.Closed += new System.EventHandler(this.CORREGFI_Closed);
        this.Shown += new System.EventHandler(this.CORREGFI_Shown);
        this.Activated += new System.EventHandler(this.CORREGFI_Activated);
      

        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR3_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR2_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR1_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_OK_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_PAG_IMM)).EndInit();
       
        this.ResumeLayout(false);

	}
#endregion 
}
}