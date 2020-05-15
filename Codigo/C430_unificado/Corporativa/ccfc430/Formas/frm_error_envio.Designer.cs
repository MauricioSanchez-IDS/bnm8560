using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frm_error_envio
	{
	
#region "Upgrade Support "
		private static frm_error_envio m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_error_envio DefInstance
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
		public frm_error_envio():base(){
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
	public static frm_error_envio CreateInstance()
	{
			frm_error_envio theInstance = new frm_error_envio();
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
	public  System.Windows.Forms.TextBox txt_error;
	public  System.Windows.Forms.Button cmdAceptar;
	public  System.Windows.Forms.Label lblMensajeError;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_error_envio));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txt_error = new System.Windows.Forms.TextBox();
			this.cmdAceptar = new System.Windows.Forms.Button();
			this.lblMensajeError = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txt_error
			// 
			this.txt_error.AcceptsReturn = true;
			this.txt_error.AutoSize = false;
			this.txt_error.BackColor = System.Drawing.SystemColors.Window;
			this.txt_error.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txt_error.CausesValidation = true;
			this.txt_error.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txt_error.Enabled = true;
			this.txt_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txt_error.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txt_error.HideSelection = true;
			this.txt_error.Location = new System.Drawing.Point(8, 104);
			this.txt_error.MaxLength = 0;
			this.txt_error.Multiline = true;
			this.txt_error.Name = "txt_error";
			this.txt_error.ReadOnly = false;
			this.txt_error.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txt_error.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_error.Size = new System.Drawing.Size(465, 185);
			this.txt_error.TabIndex = 2;
			this.txt_error.TabStop = true;
			this.txt_error.Tag = "";
			this.txt_error.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txt_error.Visible = true;
			// 
			// cmdAceptar
			// 
			this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
			this.cmdAceptar.CausesValidation = true;
			this.cmdAceptar.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdAceptar.Enabled = true;
			this.cmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdAceptar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdAceptar.Location = new System.Drawing.Point(160, 296);
			this.cmdAceptar.Name = "cmdAceptar";
			this.cmdAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAceptar.Size = new System.Drawing.Size(161, 33);
			this.cmdAceptar.TabIndex = 1;
			this.cmdAceptar.TabStop = true;
			this.cmdAceptar.Tag = "";
			this.cmdAceptar.Text = "Aceptar";
			this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
			// 
			// lblMensajeError
			// 
			this.lblMensajeError.AutoSize = false;
			this.lblMensajeError.BackColor = System.Drawing.Color.Red;
			this.lblMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMensajeError.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblMensajeError.Enabled = true;
			this.lblMensajeError.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblMensajeError.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblMensajeError.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblMensajeError.Location = new System.Drawing.Point(32, 8);
			this.lblMensajeError.Name = "lblMensajeError";
			this.lblMensajeError.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMensajeError.Size = new System.Drawing.Size(417, 81);
			this.lblMensajeError.TabIndex = 0;
			this.lblMensajeError.Tag = "";
			this.lblMensajeError.Text = "Error";
			this.lblMensajeError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblMensajeError.UseMnemonic = true;
			this.lblMensajeError.Visible = true;
			// 
			// frm_error_envio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Red;
			this.ClientSize = new System.Drawing.Size(484, 337);
			this.ControlBox = true;
			this.Controls.Add(this.txt_error);
			this.Controls.Add(this.cmdAceptar);
			this.Controls.Add(this.lblMensajeError);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = false;
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_error_envio";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
			this.Tag = "";
			this.Text = "Error!";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.ResumeLayout(false);
	}
#endregion 
}
}