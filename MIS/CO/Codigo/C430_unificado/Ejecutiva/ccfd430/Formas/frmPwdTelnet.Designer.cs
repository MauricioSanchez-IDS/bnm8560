using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmPwdTelnet
	{
	
#region "Upgrade Support "
		private static frmPwdTelnet m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmPwdTelnet DefInstance
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
		public frmPwdTelnet():base(){
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
			InitializelblLabels();
		}
	public static frmPwdTelnet CreateInstance()
	{
			frmPwdTelnet theInstance = new frmPwdTelnet();
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
	public  System.Windows.Forms.Button cmdOK;
	public  System.Windows.Forms.Button cmdCancel;
	public  System.Windows.Forms.TextBox txtPassword;
	public  System.Windows.Forms.Label LblMensaje;
	public  System.Windows.Forms.PictureBox Image1;
	private  System.Windows.Forms.Label _lblLabels_1;
	public System.Windows.Forms.Label[] lblLabels = new System.Windows.Forms.Label[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPwdTelnet));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.cmdOK = new System.Windows.Forms.Button();
        this.cmdCancel = new System.Windows.Forms.Button();
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.LblMensaje = new System.Windows.Forms.Label();
        this.Image1 = new System.Windows.Forms.PictureBox();
        this._lblLabels_1 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
        this.SuspendLayout();
        // 
        // cmdOK
        // 
        this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
        this.cmdOK.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdOK.Location = new System.Drawing.Point(96, 96);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdOK.Size = new System.Drawing.Size(116, 26);
        this.cmdOK.TabIndex = 2;
        this.cmdOK.Tag = "";
        this.cmdOK.Text = "OK";
        this.cmdOK.UseVisualStyleBackColor = false;
        this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
        // 
        // cmdCancel
        // 
        this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
        this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdCancel.Location = new System.Drawing.Point(304, 96);
        this.cmdCancel.Name = "cmdCancel";
        this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdCancel.Size = new System.Drawing.Size(140, 26);
        this.cmdCancel.TabIndex = 3;
        this.cmdCancel.Tag = "";
        this.cmdCancel.Text = "Cancel";
        this.cmdCancel.UseVisualStyleBackColor = false;
        this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
        // 
        // txtPassword
        // 
        this.txtPassword.AcceptsReturn = true;
        this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
        this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.txtPassword.Location = new System.Drawing.Point(288, 59);
        this.txtPassword.MaxLength = 0;
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.PasswordChar = '*';
        this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtPassword.Size = new System.Drawing.Size(155, 23);
        this.txtPassword.TabIndex = 1;
        this.txtPassword.Tag = "";
        // 
        // LblMensaje
        // 
        this.LblMensaje.AutoSize = true;
        this.LblMensaje.BackColor = System.Drawing.SystemColors.Control;
        this.LblMensaje.Cursor = System.Windows.Forms.Cursors.Default;
        this.LblMensaje.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.LblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.LblMensaje.ForeColor = System.Drawing.Color.Red;
        this.LblMensaje.Location = new System.Drawing.Point(96, 8);
        this.LblMensaje.Name = "LblMensaje";
        this.LblMensaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LblMensaje.Size = new System.Drawing.Size(0, 13);
        this.LblMensaje.TabIndex = 4;
        this.LblMensaje.Tag = "";
        // 
        // Image1
        // 
        this.Image1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Image1.Image = ((System.Drawing.Image)(resources.GetObject("Image1.Image")));
        this.Image1.Location = new System.Drawing.Point(16, 16);
        this.Image1.Name = "Image1";
        this.Image1.Size = new System.Drawing.Size(32, 32);
        this.Image1.TabIndex = 3;
        this.Image1.TabStop = false;
        this.Image1.Tag = "";
        // 
        // _lblLabels_1
        // 
        this._lblLabels_1.BackColor = System.Drawing.SystemColors.Control;
        this._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblLabels_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblLabels_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblLabels_1.Location = new System.Drawing.Point(96, 64);
        this._lblLabels_1.Name = "_lblLabels_1";
        this._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblLabels_1.Size = new System.Drawing.Size(72, 18);
        this._lblLabels_1.TabIndex = 0;
        this._lblLabels_1.Tag = "";
        this._lblLabels_1.Text = "&Password:";
        // 
        // frmPwdTelnet
        // 
        this.AcceptButton = this.cmdOK;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.cmdCancel;
        this.ClientSize = new System.Drawing.Size(464, 127);
        this.Controls.Add(this.cmdOK);
        this.Controls.Add(this.Image1);
        this.Controls.Add(this._lblLabels_1);
        this.Controls.Add(this.LblMensaje);
        this.Controls.Add(this.cmdCancel);
        this.Controls.Add(this.txtPassword);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(189, 232);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmPwdTelnet";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Login";
        ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	void  InitializelblLabels()
	{
			this.lblLabels[1] = _lblLabels_1;
	}
#endregion 
}
}