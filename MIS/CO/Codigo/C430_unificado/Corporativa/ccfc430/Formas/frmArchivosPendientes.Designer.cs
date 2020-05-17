using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmArchivosPendientes
	{
	
#region "Upgrade Support "
		private static frmArchivosPendientes m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmArchivosPendientes DefInstance
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
		public frmArchivosPendientes():base(){
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
	public static frmArchivosPendientes CreateInstance()
	{
			frmArchivosPendientes theInstance = new frmArchivosPendientes();
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
	public  AxMSComctlLib.AxListView LstArchivosPendientes;
	public  System.Windows.Forms.Button cmdCancelar;
	public  System.Windows.Forms.Button cmdAceptar;
	public  System.Windows.Forms.TextBox txtTipoProceso;
	public  System.Windows.Forms.Label lblArchivosPendientes;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchivosPendientes));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.LstArchivosPendientes = new AxMSComctlLib.AxListView();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.cmdAceptar = new System.Windows.Forms.Button();
			this.txtTipoProceso = new System.Windows.Forms.TextBox();
			this.lblArchivosPendientes = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.LstArchivosPendientes).BeginInit();
			this.SuspendLayout();
			// 
			// LstArchivosPendientes
			// 
			this.LstArchivosPendientes.Location = new System.Drawing.Point(8, 32);
			this.LstArchivosPendientes.Name = "LstArchivosPendientes";
			this.LstArchivosPendientes.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("LstArchivosPendientes.OcxState");
			this.LstArchivosPendientes.Size = new System.Drawing.Size(657, 241);
			this.LstArchivosPendientes.TabIndex = 3;
			this.LstArchivosPendientes.Tag = "";
			this.LstArchivosPendientes.DblClick += new System.EventHandler(this.LstArchivosPendientes_DblClick);
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancelar.CausesValidation = true;
			this.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancelar.Enabled = true;
			this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancelar.Location = new System.Drawing.Point(320, 280);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancelar.Size = new System.Drawing.Size(113, 25);
			this.cmdCancelar.TabIndex = 2;
			this.cmdCancelar.TabStop = true;
			this.cmdCancelar.Tag = "";
			this.cmdCancelar.Text = "&Cancelar";
			this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
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
			this.cmdAceptar.Location = new System.Drawing.Point(120, 280);
			this.cmdAceptar.Name = "cmdAceptar";
			this.cmdAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdAceptar.Size = new System.Drawing.Size(113, 25);
			this.cmdAceptar.TabIndex = 1;
			this.cmdAceptar.TabStop = true;
			this.cmdAceptar.Tag = "";
			this.cmdAceptar.Text = "&Seleccionar";
			this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
			// 
			// txtTipoProceso
			// 
			this.txtTipoProceso.AcceptsReturn = true;
			this.txtTipoProceso.AutoSize = false;
			this.txtTipoProceso.BackColor = System.Drawing.SystemColors.Window;
			this.txtTipoProceso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtTipoProceso.CausesValidation = true;
			this.txtTipoProceso.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTipoProceso.Enabled = false;
			this.txtTipoProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTipoProceso.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTipoProceso.HideSelection = true;
			this.txtTipoProceso.Location = new System.Drawing.Point(160, 8);
			this.txtTipoProceso.MaxLength = 0;
			this.txtTipoProceso.Multiline = false;
			this.txtTipoProceso.Name = "txtTipoProceso";
			this.txtTipoProceso.ReadOnly = false;
			this.txtTipoProceso.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtTipoProceso.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtTipoProceso.Size = new System.Drawing.Size(121, 19);
			this.txtTipoProceso.TabIndex = 4;
			this.txtTipoProceso.TabStop = true;
			this.txtTipoProceso.Tag = "";
			this.txtTipoProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtTipoProceso.Visible = false;
			// 
			// lblArchivosPendientes
			// 
			this.lblArchivosPendientes.AutoSize = false;
			this.lblArchivosPendientes.BackColor = System.Drawing.SystemColors.Control;
			this.lblArchivosPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblArchivosPendientes.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblArchivosPendientes.Enabled = true;
			this.lblArchivosPendientes.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblArchivosPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblArchivosPendientes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblArchivosPendientes.Location = new System.Drawing.Point(8, 8);
			this.lblArchivosPendientes.Name = "lblArchivosPendientes";
			this.lblArchivosPendientes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblArchivosPendientes.Size = new System.Drawing.Size(145, 17);
			this.lblArchivosPendientes.TabIndex = 0;
			this.lblArchivosPendientes.Tag = "";
			this.lblArchivosPendientes.Text = "Archivo de proceso pendiente";
			this.lblArchivosPendientes.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblArchivosPendientes.UseMnemonic = true;
			this.lblArchivosPendientes.Visible = true;
			// 
			// frmArchivosPendientes
			// 
			this.AcceptButton = this.cmdAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.cmdCancelar;
			this.ClientSize = new System.Drawing.Size(668, 307);
			this.ControlBox = true;
			this.Controls.Add(this.LstArchivosPendientes);
			this.Controls.Add(this.cmdAceptar);
			this.Controls.Add(this.txtTipoProceso);
			this.Controls.Add(this.lblArchivosPendientes);
			this.Controls.Add(this.cmdCancelar);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.Icon = (System.Drawing.Icon) resources.GetObject("frmArchivosPendientes.Icon");
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(4, 23);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmArchivosPendientes";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Tag = "";
			this.Text = "Archivos CCF pendientes de proceso";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.frmArchivosPendientes_Closed);
			((System.ComponentModel.ISupportInitialize) this.LstArchivosPendientes).EndInit();
			this.ResumeLayout(false);
	}
#endregion 
}
}