using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmSeguridad
	{
	
#region "Upgrade Support "
		private static frmSeguridad m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSeguridad DefInstance
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
		public frmSeguridad():base(){
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
			InitializecmdSeguridad();
			InitializetxtSeguridad();
			InitializelblSeguridad();
		}
	public static frmSeguridad CreateInstance()
	{
			frmSeguridad theInstance = new frmSeguridad();
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
	private  System.Windows.Forms.TextBox _txtSeguridad_0;
	private  System.Windows.Forms.Button _cmdSeguridad_1;
	private  System.Windows.Forms.Button _cmdSeguridad_0;
	private  System.Windows.Forms.TextBox _txtSeguridad_1;
	private  System.Windows.Forms.Label _lblSeguridad_0;
	private  System.Windows.Forms.Label _lblSeguridad_1;
	public  AxThreed.AxSSPanel pnlSeguridad;
	public System.Windows.Forms.Button[] cmdSeguridad = new System.Windows.Forms.Button[2];
	public System.Windows.Forms.Label[] lblSeguridad = new System.Windows.Forms.Label[2];
	public System.Windows.Forms.TextBox[] txtSeguridad = new System.Windows.Forms.TextBox[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeguridad));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pnlSeguridad = new AxThreed.AxSSPanel();
			this._txtSeguridad_0 = new System.Windows.Forms.TextBox();
			this._cmdSeguridad_1 = new System.Windows.Forms.Button();
			this._cmdSeguridad_0 = new System.Windows.Forms.Button();
			this._txtSeguridad_1 = new System.Windows.Forms.TextBox();
			this._lblSeguridad_0 = new System.Windows.Forms.Label();
			this._lblSeguridad_1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.pnlSeguridad).BeginInit();
			this.pnlSeguridad.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlSeguridad
			// 
			this.pnlSeguridad.Controls.Add(this._cmdSeguridad_0);
			this.pnlSeguridad.Controls.Add(this._cmdSeguridad_1);
			this.pnlSeguridad.Controls.Add(this._txtSeguridad_0);
			this.pnlSeguridad.Controls.Add(this._txtSeguridad_1);
			this.pnlSeguridad.Controls.Add(this._lblSeguridad_1);
			this.pnlSeguridad.Controls.Add(this._lblSeguridad_0);
			this.pnlSeguridad.Location = new System.Drawing.Point(0, 0);
			this.pnlSeguridad.Name = "pnlSeguridad";
			this.pnlSeguridad.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("pnlSeguridad.OcxState");
			this.pnlSeguridad.Size = new System.Drawing.Size(233, 113);
			this.pnlSeguridad.TabIndex = 2;
			this.pnlSeguridad.Tag = "";
			// 
			// _txtSeguridad_0
			// 
			this._txtSeguridad_0.AcceptsReturn = true;
			this._txtSeguridad_0.AutoSize = false;
			this._txtSeguridad_0.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this._txtSeguridad_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtSeguridad_0.CausesValidation = true;
			this._txtSeguridad_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtSeguridad_0.Enabled = true;
			this._txtSeguridad_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtSeguridad_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtSeguridad_0.HideSelection = true;
			this._txtSeguridad_0.Location = new System.Drawing.Point(59, 16);
			this._txtSeguridad_0.MaxLength = 7;
			this._txtSeguridad_0.Multiline = false;
			this._txtSeguridad_0.Name = "_txtSeguridad_0";
			this._txtSeguridad_0.ReadOnly = false;
			this._txtSeguridad_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtSeguridad_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtSeguridad_0.Size = new System.Drawing.Size(107, 21);
			this._txtSeguridad_0.TabIndex = 0;
			this._txtSeguridad_0.TabStop = true;
			this._txtSeguridad_0.Tag = "";
			this._txtSeguridad_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtSeguridad_0.Visible = true;
			// 
			// _cmdSeguridad_1
			// 
			this._cmdSeguridad_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdSeguridad_1.CausesValidation = true;
			this._cmdSeguridad_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdSeguridad_1.Enabled = true;
			this._cmdSeguridad_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cmdSeguridad_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._cmdSeguridad_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdSeguridad_1.Location = new System.Drawing.Point(152, 80);
			this._cmdSeguridad_1.Name = "_cmdSeguridad_1";
			this._cmdSeguridad_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdSeguridad_1.Size = new System.Drawing.Size(65, 21);
			this._cmdSeguridad_1.TabIndex = 4;
			this._cmdSeguridad_1.TabStop = true;
			this._cmdSeguridad_1.Tag = "";
			this._cmdSeguridad_1.Text = "Cancelar";
			this._cmdSeguridad_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdSeguridad_1.Click += new System.EventHandler(this.cmdSeguridad_Click);
			// 
			// _cmdSeguridad_0
			// 
			this._cmdSeguridad_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdSeguridad_0.CausesValidation = true;
			this._cmdSeguridad_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdSeguridad_0.Enabled = true;
			this._cmdSeguridad_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cmdSeguridad_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._cmdSeguridad_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdSeguridad_0.Location = new System.Drawing.Point(77, 80);
			this._cmdSeguridad_0.Name = "_cmdSeguridad_0";
			this._cmdSeguridad_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdSeguridad_0.Size = new System.Drawing.Size(65, 21);
			this._cmdSeguridad_0.TabIndex = 3;
			this._cmdSeguridad_0.TabStop = true;
			this._cmdSeguridad_0.Tag = "";
			this._cmdSeguridad_0.Text = "Aceptar";
			this._cmdSeguridad_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdSeguridad_0.Click += new System.EventHandler(this.cmdSeguridad_Click);
			// 
			// _txtSeguridad_1
			// 
			this._txtSeguridad_1.AcceptsReturn = true;
			this._txtSeguridad_1.AutoSize = false;
			this._txtSeguridad_1.BackColor = System.Drawing.Color.White;
			this._txtSeguridad_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtSeguridad_1.CausesValidation = true;
			this._txtSeguridad_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtSeguridad_1.Enabled = true;
			this._txtSeguridad_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtSeguridad_1.ForeColor = System.Drawing.Color.Black;
			this._txtSeguridad_1.HideSelection = true;
			this._txtSeguridad_1.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this._txtSeguridad_1.Location = new System.Drawing.Point(59, 46);
			this._txtSeguridad_1.MaxLength = 8;
			this._txtSeguridad_1.Multiline = false;
			this._txtSeguridad_1.Name = "_txtSeguridad_1";
			this._txtSeguridad_1.PasswordChar = (char) 42;
			this._txtSeguridad_1.ReadOnly = false;
			this._txtSeguridad_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtSeguridad_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtSeguridad_1.Size = new System.Drawing.Size(107, 21);
			this._txtSeguridad_1.TabIndex = 1;
			this._txtSeguridad_1.TabStop = true;
			this._txtSeguridad_1.Tag = "";
			this._txtSeguridad_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtSeguridad_1.Visible = true;
			// 
			// _lblSeguridad_0
			// 
			this._lblSeguridad_0.AutoSize = true;
			this._lblSeguridad_0.BackColor = System.Drawing.SystemColors.Control;
			this._lblSeguridad_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblSeguridad_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblSeguridad_0.Enabled = true;
			this._lblSeguridad_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._lblSeguridad_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblSeguridad_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblSeguridad_0.Location = new System.Drawing.Point(16, 20);
			this._lblSeguridad_0.Name = "_lblSeguridad_0";
			this._lblSeguridad_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblSeguridad_0.Size = new System.Drawing.Size(39, 13);
			this._lblSeguridad_0.TabIndex = 6;
			this._lblSeguridad_0.Tag = "";
			this._lblSeguridad_0.Text = "Nomina:";
			this._lblSeguridad_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblSeguridad_0.UseMnemonic = true;
			this._lblSeguridad_0.Visible = true;
			// 
			// _lblSeguridad_1
			// 
			this._lblSeguridad_1.AutoSize = true;
			this._lblSeguridad_1.BackColor = System.Drawing.SystemColors.Control;
			this._lblSeguridad_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblSeguridad_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblSeguridad_1.Enabled = true;
			this._lblSeguridad_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._lblSeguridad_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblSeguridad_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblSeguridad_1.Location = new System.Drawing.Point(16, 50);
			this._lblSeguridad_1.Name = "_lblSeguridad_1";
			this._lblSeguridad_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblSeguridad_1.Size = new System.Drawing.Size(30, 13);
			this._lblSeguridad_1.TabIndex = 5;
			this._lblSeguridad_1.Tag = "";
			this._lblSeguridad_1.Text = "Clave:";
			this._lblSeguridad_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblSeguridad_1.UseMnemonic = true;
			this._lblSeguridad_1.Visible = true;
			// 
			// frmSeguridad
			// 
			this.AcceptButton = this._cmdSeguridad_0;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this._cmdSeguridad_1;
			this.ClientSize = new System.Drawing.Size(234, 114);
			this.ControlBox = true;
			this.Controls.Add(this.pnlSeguridad);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(380, 247);
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "frmSeguridad";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "";
			this.Text = "Clave de Acceso";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.frmSeguridad_Closed);
			((System.ComponentModel.ISupportInitialize) this.pnlSeguridad).EndInit();
			this.pnlSeguridad.ResumeLayout(false);
			this.ResumeLayout(false);
	}
	void  InitializecmdSeguridad()
	{
			this.cmdSeguridad[1] = _cmdSeguridad_1;
			this.cmdSeguridad[0] = _cmdSeguridad_0;
	}
	void  InitializetxtSeguridad()
	{
			this.txtSeguridad[0] = _txtSeguridad_0;
			this.txtSeguridad[1] = _txtSeguridad_1;
	}
	void  InitializelblSeguridad()
	{
			this.lblSeguridad[0] = _lblSeguridad_0;
			this.lblSeguridad[1] = _lblSeguridad_1;
	}
#endregion 
}
}