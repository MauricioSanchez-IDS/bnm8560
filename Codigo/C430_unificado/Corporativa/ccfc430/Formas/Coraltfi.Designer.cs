using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORALTFI
	{
	
#region "Upgrade Support "
		private static CORALTFI m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORALTFI DefInstance
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
		public CORALTFI():base(){
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
	public static CORALTFI CreateInstance()
	{
			CORALTFI theInstance = new CORALTFI();
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
	public  System.Windows.Forms.Button ID_FIR_INS_PB;
	public  System.Windows.Forms.Button ID_FIR_CAN_PB;
	public  System.Windows.Forms.Button ID_FIR_ACE_PB;
	public  System.Windows.Forms.Panel ID_FIR_BUT_FRM;
	public  System.Windows.Forms.Button ID_FIR_GUA_PB;
	public  System.Windows.Forms.Button ID_FIR_SCA_PB;
	public  AxGEARLib.AxGear ID_FIR_GUA_IMM;
	public  AxGEARLib.AxGear ID_FIR_OK_IMM;
	public  AxGEARLib.AxGear ID_FIR_PAG_IMM;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORALTFI));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_FIR_INS_PB = new System.Windows.Forms.Button();
        this.ID_FIR_BUT_FRM = new System.Windows.Forms.Panel();
        this.ID_FIR_ACE_PB = new System.Windows.Forms.Button();
        this.ID_FIR_CAN_PB = new System.Windows.Forms.Button();
        this.ID_FIR_GUA_PB = new System.Windows.Forms.Button();
        this.ID_FIR_SCA_PB = new System.Windows.Forms.Button();
        this.ID_FIR_GUA_IMM = new AxGEARLib.AxGear();
        this.ID_FIR_OK_IMM = new AxGEARLib.AxGear();
        this.ID_FIR_PAG_IMM = new AxGEARLib.AxGear();
        this.ID_FIR_BUT_FRM.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_GUA_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_OK_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_PAG_IMM)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_FIR_INS_PB
        // 
        this.ID_FIR_INS_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_INS_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_INS_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_INS_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_INS_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_INS_PB.Location = new System.Drawing.Point(224, 173);
        this.ID_FIR_INS_PB.Name = "ID_FIR_INS_PB";
        this.ID_FIR_INS_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_INS_PB.Size = new System.Drawing.Size(73, 22);
        this.ID_FIR_INS_PB.TabIndex = 2;
        this.ID_FIR_INS_PB.Tag = "";
        this.ID_FIR_INS_PB.Text = "&Instalar";
        this.ID_FIR_INS_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_INS_PB.Click += new System.EventHandler(this.ID_FIR_INS_PB_Click);
        // 
        // ID_FIR_BUT_FRM
        // 
        this.ID_FIR_BUT_FRM.BackColor = System.Drawing.Color.White;
        this.ID_FIR_BUT_FRM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.ID_FIR_BUT_FRM.Controls.Add(this.ID_FIR_ACE_PB);
        this.ID_FIR_BUT_FRM.Controls.Add(this.ID_FIR_CAN_PB);
        this.ID_FIR_BUT_FRM.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_BUT_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_BUT_FRM.Location = new System.Drawing.Point(350, 109);
        this.ID_FIR_BUT_FRM.Name = "ID_FIR_BUT_FRM";
        this.ID_FIR_BUT_FRM.Size = new System.Drawing.Size(101, 82);
        this.ID_FIR_BUT_FRM.TabIndex = 3;
        this.ID_FIR_BUT_FRM.TabStop = true;
        this.ID_FIR_BUT_FRM.Tag = "";
        // 
        // ID_FIR_ACE_PB
        // 
        this.ID_FIR_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_ACE_PB.Enabled = false;
        this.ID_FIR_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_ACE_PB.Location = new System.Drawing.Point(13, 19);
        this.ID_FIR_ACE_PB.Name = "ID_FIR_ACE_PB";
        this.ID_FIR_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_ACE_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_ACE_PB.TabIndex = 4;
        this.ID_FIR_ACE_PB.Tag = "";
        this.ID_FIR_ACE_PB.Text = "Aceptar";
        this.ID_FIR_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_ACE_PB.Click += new System.EventHandler(this.ID_FIR_ACE_PB_Click);
        // 
        // ID_FIR_CAN_PB
        // 
        this.ID_FIR_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_FIR_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_CAN_PB.Location = new System.Drawing.Point(14, 46);
        this.ID_FIR_CAN_PB.Name = "ID_FIR_CAN_PB";
        this.ID_FIR_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_CAN_PB.TabIndex = 5;
        this.ID_FIR_CAN_PB.Tag = "";
        this.ID_FIR_CAN_PB.Text = "Cancelar";
        this.ID_FIR_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_CAN_PB.Click += new System.EventHandler(this.ID_FIR_CAN_PB_Click);
        // 
        // ID_FIR_GUA_PB
        // 
        this.ID_FIR_GUA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_GUA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_GUA_PB.Enabled = false;
        this.ID_FIR_GUA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_GUA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_GUA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_GUA_PB.Location = new System.Drawing.Point(387, 37);
        this.ID_FIR_GUA_PB.Name = "ID_FIR_GUA_PB";
        this.ID_FIR_GUA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_GUA_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_GUA_PB.TabIndex = 0;
        this.ID_FIR_GUA_PB.Tag = "";
        this.ID_FIR_GUA_PB.Text = "&Guardar";
        this.ID_FIR_GUA_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_GUA_PB.Click += new System.EventHandler(this.ID_FIR_GUA_PB_Click);
        // 
        // ID_FIR_SCA_PB
        // 
        this.ID_FIR_SCA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_SCA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_SCA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_SCA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_SCA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_SCA_PB.Location = new System.Drawing.Point(46, 171);
        this.ID_FIR_SCA_PB.Name = "ID_FIR_SCA_PB";
        this.ID_FIR_SCA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_SCA_PB.Size = new System.Drawing.Size(76, 22);
        this.ID_FIR_SCA_PB.TabIndex = 1;
        this.ID_FIR_SCA_PB.Tag = "";
        this.ID_FIR_SCA_PB.Text = "&Scanear";
        this.ID_FIR_SCA_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_SCA_PB.Click += new System.EventHandler(this.ID_FIR_SCA_PB_Click);
        // 
        // ID_FIR_GUA_IMM
        // 
        this.ID_FIR_GUA_IMM.Enabled = true;
        this.ID_FIR_GUA_IMM.Location = new System.Drawing.Point(345, 28);
        this.ID_FIR_GUA_IMM.Name = "ID_FIR_GUA_IMM";
        this.ID_FIR_GUA_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_GUA_IMM.OcxState")));
        this.ID_FIR_GUA_IMM.Size = new System.Drawing.Size(40, 40);
        this.ID_FIR_GUA_IMM.TabIndex = 8;
        this.ID_FIR_GUA_IMM.Tag = "";
        // 
        // ID_FIR_OK_IMM
        // 
        this.ID_FIR_OK_IMM.Enabled = true;
        this.ID_FIR_OK_IMM.Location = new System.Drawing.Point(184, 17);
        this.ID_FIR_OK_IMM.Name = "ID_FIR_OK_IMM";
        this.ID_FIR_OK_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_OK_IMM.OcxState")));
        this.ID_FIR_OK_IMM.Size = new System.Drawing.Size(151, 150);
        this.ID_FIR_OK_IMM.TabIndex = 7;
        this.ID_FIR_OK_IMM.Tag = "";
        // 
        // ID_FIR_PAG_IMM
        // 
        this.ID_FIR_PAG_IMM.Enabled = true;
        this.ID_FIR_PAG_IMM.Location = new System.Drawing.Point(20, 17);
        this.ID_FIR_PAG_IMM.Name = "ID_FIR_PAG_IMM";
        this.ID_FIR_PAG_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_PAG_IMM.OcxState")));
        this.ID_FIR_PAG_IMM.Size = new System.Drawing.Size(150, 150);
        this.ID_FIR_PAG_IMM.TabIndex = 6;
        this.ID_FIR_PAG_IMM.Tag = "";
        this.ID_FIR_PAG_IMM.SelectEventEvent += new AxGEARLib._DGearEvents_SelectEventEventHandler(this.ID_FIR_PAG_IMM_SelectEvent);
        // 
        // CORALTFI
        // 
        this.AcceptButton = this.ID_FIR_SCA_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_FIR_CAN_PB;
        this.ClientSize = new System.Drawing.Size(463, 206);
        this.Controls.Add(this.ID_FIR_INS_PB);
        this.Controls.Add(this.ID_FIR_BUT_FRM);
        this.Controls.Add(this.ID_FIR_OK_IMM);
        this.Controls.Add(this.ID_FIR_PAG_IMM);
        this.Controls.Add(this.ID_FIR_GUA_IMM);
        this.Controls.Add(this.ID_FIR_GUA_PB);
        this.Controls.Add(this.ID_FIR_SCA_PB);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.Location = new System.Drawing.Point(133, 91);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORALTFI";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Firmas";
        this.Closed += new System.EventHandler(this.CORALTFI_Closed);
        this.ID_FIR_BUT_FRM.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_GUA_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_OK_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_PAG_IMM)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}