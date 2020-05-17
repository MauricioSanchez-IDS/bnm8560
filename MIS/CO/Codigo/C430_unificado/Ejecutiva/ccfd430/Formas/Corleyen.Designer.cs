using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORLEYEN
	{
	
#region "Upgrade Support "
		private static CORLEYEN m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORLEYEN DefInstance
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
		public CORLEYEN():base(){
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
	public static CORLEYEN CreateInstance()
	{
			CORLEYEN theInstance = new CORLEYEN();
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
	public  System.Windows.Forms.Button ID_LEY_SAL_PB;
	public  System.Windows.Forms.Button ID_LEY_GRA_PB;
	public  System.Windows.Forms.TextBox ID_LEY_LEY_EB;
	public  System.Windows.Forms.Panel ID_LEY_LEY_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_LEY_SAL_PB = new System.Windows.Forms.Button();
        this.ID_LEY_GRA_PB = new System.Windows.Forms.Button();
        this.ID_LEY_LEY_PNL = new System.Windows.Forms.Panel();
        this.ID_LEY_LEY_EB = new System.Windows.Forms.TextBox();
        this.ID_LEY_LEY_PNL.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_LEY_SAL_PB
        // 
        this.ID_LEY_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_LEY_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_LEY_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_LEY_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_LEY_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_LEY_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_LEY_SAL_PB.Location = new System.Drawing.Point(556, 80);
        this.ID_LEY_SAL_PB.Name = "ID_LEY_SAL_PB";
        this.ID_LEY_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_LEY_SAL_PB.Size = new System.Drawing.Size(73, 25);
        this.ID_LEY_SAL_PB.TabIndex = 3;
        this.ID_LEY_SAL_PB.Tag = "";
        this.ID_LEY_SAL_PB.Text = "Salir";
        this.ID_LEY_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_LEY_SAL_PB.Click += new System.EventHandler(this.ID_LEY_SAL_PB_Click);
        // 
        // ID_LEY_GRA_PB
        // 
        this.ID_LEY_GRA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_LEY_GRA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_LEY_GRA_PB.Enabled = false;
        this.ID_LEY_GRA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_LEY_GRA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_LEY_GRA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_LEY_GRA_PB.Location = new System.Drawing.Point(481, 80);
        this.ID_LEY_GRA_PB.Name = "ID_LEY_GRA_PB";
        this.ID_LEY_GRA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_LEY_GRA_PB.Size = new System.Drawing.Size(73, 25);
        this.ID_LEY_GRA_PB.TabIndex = 2;
        this.ID_LEY_GRA_PB.Tag = "";
        this.ID_LEY_GRA_PB.Text = "&Grabar";
        this.ID_LEY_GRA_PB.UseVisualStyleBackColor = false;
        this.ID_LEY_GRA_PB.Click += new System.EventHandler(this.ID_LEY_GRA_PB_Click);
        // 
        // ID_LEY_LEY_PNL
        // 
        this.ID_LEY_LEY_PNL.Controls.Add(this.ID_LEY_LEY_EB);
        this.ID_LEY_LEY_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_LEY_LEY_PNL.Name = "ID_LEY_LEY_PNL";
        this.ID_LEY_LEY_PNL.Size = new System.Drawing.Size(633, 79);
        this.ID_LEY_LEY_PNL.TabIndex = 0;
        this.ID_LEY_LEY_PNL.Tag = "";
        // 
        // ID_LEY_LEY_EB
        // 
        this.ID_LEY_LEY_EB.AcceptsReturn = true;
        this.ID_LEY_LEY_EB.BackColor = System.Drawing.Color.Silver;
        this.ID_LEY_LEY_EB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.ID_LEY_LEY_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_LEY_LEY_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_LEY_LEY_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_LEY_LEY_EB.Location = new System.Drawing.Point(3, 3);
        this.ID_LEY_LEY_EB.MaxLength = 240;
        this.ID_LEY_LEY_EB.Multiline = true;
        this.ID_LEY_LEY_EB.Name = "ID_LEY_LEY_EB";
        this.ID_LEY_LEY_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_LEY_LEY_EB.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
        this.ID_LEY_LEY_EB.Size = new System.Drawing.Size(627, 73);
        this.ID_LEY_LEY_EB.TabIndex = 1;
        this.ID_LEY_LEY_EB.Tag = " ";
        this.ID_LEY_LEY_EB.WordWrap = false;
        this.ID_LEY_LEY_EB.Leave += new System.EventHandler(this.ID_LEY_LEY_EB_Leave);
        this.ID_LEY_LEY_EB.TextChanged += new System.EventHandler(this.ID_LEY_LEY_EB_TextChanged);
        // 
        // CORLEYEN
        // 
        this.AcceptButton = this.ID_LEY_GRA_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_LEY_SAL_PB;
        this.ClientSize = new System.Drawing.Size(631, 107);
        this.Controls.Add(this.ID_LEY_GRA_PB);
        this.Controls.Add(this.ID_LEY_SAL_PB);
        this.Controls.Add(this.ID_LEY_LEY_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(146, 131);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORLEYEN";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Closed += new System.EventHandler(this.CORLEYEN_Closed);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORLEYEN_KeyPress);
        this.ID_LEY_LEY_PNL.ResumeLayout(false);
        this.ID_LEY_LEY_PNL.PerformLayout();
        this.ResumeLayout(false);

	}
#endregion 
}
}