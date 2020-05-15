using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORIREJB
	{
	
#region "Upgrade Support "
		private static CORIREJB m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORIREJB DefInstance
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
		public CORIREJB():base(){
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
	public static CORIREJB CreateInstance()
	{
			CORIREJB theInstance = new CORIREJB();
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
	public  AxMSMask.AxMaskEdBox ID_IRA_NOM_PIC;
	public  System.Windows.Forms.Button ID_IRA_OK_PB;
	public  System.Windows.Forms.Button ID_IRA_CAN_PB;
	public  System.Windows.Forms.Label ID_IRA_TEX_TXT;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORIREJB));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_IRA_NOM_PIC = new AxMSMask.AxMaskEdBox();
        this.ID_IRA_OK_PB = new System.Windows.Forms.Button();
        this.ID_IRA_CAN_PB = new System.Windows.Forms.Button();
        this.ID_IRA_TEX_TXT = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_IRA_NOM_PIC)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_IRA_NOM_PIC
        // 
        this.ID_IRA_NOM_PIC.Location = new System.Drawing.Point(207, 16);
        this.ID_IRA_NOM_PIC.Name = "ID_IRA_NOM_PIC";
        this.ID_IRA_NOM_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_IRA_NOM_PIC.OcxState")));
        this.ID_IRA_NOM_PIC.Size = new System.Drawing.Size(65, 22);
        this.ID_IRA_NOM_PIC.TabIndex = 1;
        this.ID_IRA_NOM_PIC.Tag = "";
        this.ID_IRA_NOM_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_IRA_NOM_PIC_KeyPressEvent);
        this.ID_IRA_NOM_PIC.Leave += new System.EventHandler(this.ID_IRA_NOM_PIC_Leave);
        // 
        // ID_IRA_OK_PB
        // 
        this.ID_IRA_OK_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_IRA_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_IRA_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_IRA_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_IRA_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_IRA_OK_PB.Location = new System.Drawing.Point(80, 56);
        this.ID_IRA_OK_PB.Name = "ID_IRA_OK_PB";
        this.ID_IRA_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_IRA_OK_PB.Size = new System.Drawing.Size(73, 23);
        this.ID_IRA_OK_PB.TabIndex = 2;
        this.ID_IRA_OK_PB.Tag = "";
        this.ID_IRA_OK_PB.Text = "Aceptar";
        this.ID_IRA_OK_PB.UseVisualStyleBackColor = false;
        this.ID_IRA_OK_PB.Click += new System.EventHandler(this.ID_IRA_OK_PB_Click);
        // 
        // ID_IRA_CAN_PB
        // 
        this.ID_IRA_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_IRA_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_IRA_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_IRA_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_IRA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_IRA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_IRA_CAN_PB.Location = new System.Drawing.Point(162, 56);
        this.ID_IRA_CAN_PB.Name = "ID_IRA_CAN_PB";
        this.ID_IRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_IRA_CAN_PB.Size = new System.Drawing.Size(73, 23);
        this.ID_IRA_CAN_PB.TabIndex = 3;
        this.ID_IRA_CAN_PB.Tag = "";
        this.ID_IRA_CAN_PB.Text = "Cancelar";
        this.ID_IRA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_IRA_CAN_PB.Click += new System.EventHandler(this.ID_IRA_CAN_PB_Click);
        // 
        // ID_IRA_TEX_TXT
        // 
        this.ID_IRA_TEX_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_IRA_TEX_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_IRA_TEX_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_IRA_TEX_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_IRA_TEX_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_IRA_TEX_TXT.Location = new System.Drawing.Point(27, 20);
        this.ID_IRA_TEX_TXT.Name = "ID_IRA_TEX_TXT";
        this.ID_IRA_TEX_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_IRA_TEX_TXT.Size = new System.Drawing.Size(175, 16);
        this.ID_IRA_TEX_TXT.TabIndex = 0;
        this.ID_IRA_TEX_TXT.Tag = "";
        this.ID_IRA_TEX_TXT.Text = "Teclee el Número de Nómina:";
        // 
        // CORIREJB
        // 
        this.AcceptButton = this.ID_IRA_OK_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_IRA_CAN_PB;
        this.ClientSize = new System.Drawing.Size(292, 90);
        this.Controls.Add(this.ID_IRA_NOM_PIC);
        this.Controls.Add(this.ID_IRA_CAN_PB);
        this.Controls.Add(this.ID_IRA_TEX_TXT);
        this.Controls.Add(this.ID_IRA_OK_PB);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Location = new System.Drawing.Point(212, 167);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORIREJB";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Ir a...";
        this.Closed += new System.EventHandler(this.CORIREJB_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_IRA_NOM_PIC)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}