using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORACCOM
	{
	
#region "Upgrade Support "
		private static CORACCOM m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORACCOM DefInstance
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
		public CORACCOM():base(){
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
	public static CORACCOM CreateInstance()
	{
			CORACCOM theInstance = new CORACCOM();
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
	public  System.Windows.Forms.TextBox ID_ACC_CVE_TXT;
	public  System.Windows.Forms.Button ID_ACC_OK_PB;
	public  System.Windows.Forms.Button ID_ACC_CAN_PB;
	public  System.Windows.Forms.TextBox ID_ACC_NOM_TXT;
	public  System.Windows.Forms.Label ID_ACC_CVE_LB;
	public  System.Windows.Forms.Label ID_ACC_NOM_LB;
	public  AxThreed.AxSSPanel ID_ACC_PAN_PRIN_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORACCOM));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_ACC_PAN_PRIN_PNL = new AxThreed.AxSSPanel();
        this.ID_ACC_CAN_PB = new System.Windows.Forms.Button();
        this.ID_ACC_OK_PB = new System.Windows.Forms.Button();
        this.ID_ACC_CVE_TXT = new System.Windows.Forms.TextBox();
        this.ID_ACC_NOM_TXT = new System.Windows.Forms.TextBox();
        this.ID_ACC_NOM_LB = new System.Windows.Forms.Label();
        this.ID_ACC_CVE_LB = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_PAN_PRIN_PNL)).BeginInit();
        this.ID_ACC_PAN_PRIN_PNL.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_ACC_PAN_PRIN_PNL
        // 
        this.ID_ACC_PAN_PRIN_PNL.Controls.Add(this.ID_ACC_CAN_PB);
        this.ID_ACC_PAN_PRIN_PNL.Controls.Add(this.ID_ACC_OK_PB);
        this.ID_ACC_PAN_PRIN_PNL.Controls.Add(this.ID_ACC_CVE_TXT);
        this.ID_ACC_PAN_PRIN_PNL.Controls.Add(this.ID_ACC_NOM_TXT);
        this.ID_ACC_PAN_PRIN_PNL.Controls.Add(this.ID_ACC_NOM_LB);
        this.ID_ACC_PAN_PRIN_PNL.Controls.Add(this.ID_ACC_CVE_LB);
        this.ID_ACC_PAN_PRIN_PNL.Location = new System.Drawing.Point(4, 4);
        this.ID_ACC_PAN_PRIN_PNL.Name = "ID_ACC_PAN_PRIN_PNL";
        this.ID_ACC_PAN_PRIN_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACC_PAN_PRIN_PNL.OcxState")));
        this.ID_ACC_PAN_PRIN_PNL.Size = new System.Drawing.Size(238, 102);
        this.ID_ACC_PAN_PRIN_PNL.TabIndex = 1;
        this.ID_ACC_PAN_PRIN_PNL.Tag = "";
        // 
        // ID_ACC_CAN_PB
        // 
        this.ID_ACC_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_ACC_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACC_CAN_PB.Location = new System.Drawing.Point(162, 72);
        this.ID_ACC_CAN_PB.Name = "ID_ACC_CAN_PB";
        this.ID_ACC_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_CAN_PB.Size = new System.Drawing.Size(65, 21);
        this.ID_ACC_CAN_PB.TabIndex = 4;
        this.ID_ACC_CAN_PB.Tag = "";
        this.ID_ACC_CAN_PB.Text = "Cancelar";
        this.ID_ACC_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_ACC_CAN_PB.Click += new System.EventHandler(this.ID_ACC_CAN_PB_Click);
        // 
        // ID_ACC_OK_PB
        // 
        this.ID_ACC_OK_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACC_OK_PB.Location = new System.Drawing.Point(90, 72);
        this.ID_ACC_OK_PB.Name = "ID_ACC_OK_PB";
        this.ID_ACC_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_OK_PB.Size = new System.Drawing.Size(65, 21);
        this.ID_ACC_OK_PB.TabIndex = 3;
        this.ID_ACC_OK_PB.Tag = "";
        this.ID_ACC_OK_PB.Text = "Aceptar";
        this.ID_ACC_OK_PB.UseVisualStyleBackColor = false;
        this.ID_ACC_OK_PB.Click += new System.EventHandler(this.ID_ACC_OK_PB_Click);
        // 
        // ID_ACC_CVE_TXT
        // 
        this.ID_ACC_CVE_TXT.AcceptsReturn = true;
        this.ID_ACC_CVE_TXT.BackColor = System.Drawing.Color.White;
        this.ID_ACC_CVE_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACC_CVE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_CVE_TXT.ForeColor = System.Drawing.Color.Black;
        this.ID_ACC_CVE_TXT.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.ID_ACC_CVE_TXT.Location = new System.Drawing.Point(70, 42);
        this.ID_ACC_CVE_TXT.MaxLength = 8;
        this.ID_ACC_CVE_TXT.Name = "ID_ACC_CVE_TXT";
        this.ID_ACC_CVE_TXT.PasswordChar = '*';
        this.ID_ACC_CVE_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_CVE_TXT.Size = new System.Drawing.Size(83, 20);
        this.ID_ACC_CVE_TXT.TabIndex = 2;
        this.ID_ACC_CVE_TXT.Tag = "";
        this.ID_ACC_CVE_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_CVE_TXT_KeyPress);
        // 
        // ID_ACC_NOM_TXT
        // 
        this.ID_ACC_NOM_TXT.AcceptsReturn = true;
        this.ID_ACC_NOM_TXT.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.ID_ACC_NOM_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACC_NOM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_NOM_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACC_NOM_TXT.Location = new System.Drawing.Point(71, 12);
        this.ID_ACC_NOM_TXT.MaxLength = 7;
        this.ID_ACC_NOM_TXT.Name = "ID_ACC_NOM_TXT";
        this.ID_ACC_NOM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_NOM_TXT.Size = new System.Drawing.Size(83, 20);
        this.ID_ACC_NOM_TXT.TabIndex = 0;
        this.ID_ACC_NOM_TXT.Tag = "";
        this.ID_ACC_NOM_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_NOM_TXT_KeyPress);
        // 
        // ID_ACC_NOM_LB
        // 
        this.ID_ACC_NOM_LB.AutoSize = true;
        this.ID_ACC_NOM_LB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_NOM_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_NOM_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_NOM_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_NOM_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACC_NOM_LB.Location = new System.Drawing.Point(12, 16);
        this.ID_ACC_NOM_LB.Name = "ID_ACC_NOM_LB";
        this.ID_ACC_NOM_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_NOM_LB.Size = new System.Drawing.Size(46, 13);
        this.ID_ACC_NOM_LB.TabIndex = 5;
        this.ID_ACC_NOM_LB.Tag = "";
        this.ID_ACC_NOM_LB.Text = "Nomina:";
        // 
        // ID_ACC_CVE_LB
        // 
        this.ID_ACC_CVE_LB.AutoSize = true;
        this.ID_ACC_CVE_LB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_CVE_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_CVE_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACC_CVE_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_CVE_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACC_CVE_LB.Location = new System.Drawing.Point(14, 46);
        this.ID_ACC_CVE_LB.Name = "ID_ACC_CVE_LB";
        this.ID_ACC_CVE_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_CVE_LB.Size = new System.Drawing.Size(37, 13);
        this.ID_ACC_CVE_LB.TabIndex = 6;
        this.ID_ACC_CVE_LB.Tag = "";
        this.ID_ACC_CVE_LB.Text = "Clave:";
        // 
        // CORACCOM
        // 
        this.AcceptButton = this.ID_ACC_OK_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.ID_ACC_CAN_PB;
        this.ClientSize = new System.Drawing.Size(245, 109);
        this.Controls.Add(this.ID_ACC_PAN_PRIN_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Location = new System.Drawing.Point(222, 222);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORACCOM";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Clave de Acceso";
        this.Closed += new System.EventHandler(this.CORACCOM_Closed);
        this.Activated += new System.EventHandler(this.CORACCOM_Activated);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACC_PAN_PRIN_PNL)).EndInit();
        this.ID_ACC_PAN_PRIN_PNL.ResumeLayout(false);
        this.ID_ACC_PAN_PRIN_PNL.PerformLayout();
        this.ResumeLayout(false);

	}
#endregion 
}
}