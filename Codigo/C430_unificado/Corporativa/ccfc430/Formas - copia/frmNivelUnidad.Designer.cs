using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmNivelUnidad
	{
	
#region "Upgrade Support "
		private static frmNivelUnidad m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmNivelUnidad DefInstance
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
		public frmNivelUnidad():base(){
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
	public static frmNivelUnidad CreateInstance()
	{
			frmNivelUnidad theInstance = new frmNivelUnidad();
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
	public  System.Windows.Forms.PictureBox Picture1;
	public  System.Windows.Forms.Button cmdGeneraRepo;
	public  System.Windows.Forms.TextBox txtFechaFinal;
	public  System.Windows.Forms.TextBox txtFechaInicial;
	public  System.Windows.Forms.TextBox txtFechaProceso;
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.Button cmdConsultaTH;
	public  System.Windows.Forms.TextBox txtEmpresa;
	public  AxMSComctlLib.AxListView LsvUnidades;
	public  System.Windows.Forms.Label lblFechaFinal;
	public  System.Windows.Forms.Label lblFechaInicial;
	public  System.Windows.Forms.Label lblFechaProceso;
	public  System.Windows.Forms.Label lblEmpresa;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNivelUnidad));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.cmdGeneraRepo = new System.Windows.Forms.Button();
			this.txtFechaFinal = new System.Windows.Forms.TextBox();
			this.txtFechaInicial = new System.Windows.Forms.TextBox();
			this.txtFechaProceso = new System.Windows.Forms.TextBox();
			this.cmdSalir = new System.Windows.Forms.Button();
			this.cmdConsultaTH = new System.Windows.Forms.Button();
			this.txtEmpresa = new System.Windows.Forms.TextBox();
			this.LsvUnidades = new AxMSComctlLib.AxListView();
			this.lblFechaFinal = new System.Windows.Forms.Label();
			this.lblFechaInicial = new System.Windows.Forms.Label();
			this.lblFechaProceso = new System.Windows.Forms.Label();
			this.lblEmpresa = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.LsvUnidades).BeginInit();
			this.SuspendLayout();
			// 
			// Picture1
			// 
			this.Picture1.BackColor = System.Drawing.SystemColors.Control;
			this.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Picture1.CausesValidation = true;
			this.Picture1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Picture1.Dock = System.Windows.Forms.DockStyle.None;
			this.Picture1.Enabled = true;
			this.Picture1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Picture1.Image = (System.Drawing.Image) resources.GetObject("Picture1.Image");
			this.Picture1.Location = new System.Drawing.Point(0, 392);
			this.Picture1.Name = "Picture1";
			this.Picture1.Size = new System.Drawing.Size(25, 9);
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Picture1.TabIndex = 12;
			this.Picture1.TabStop = true;
			this.Picture1.Tag = "";
			this.Picture1.Visible = true;
			// 
			// cmdGeneraRepo
			// 
			this.cmdGeneraRepo.BackColor = System.Drawing.SystemColors.Control;
			this.cmdGeneraRepo.CausesValidation = true;
			this.cmdGeneraRepo.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdGeneraRepo.Enabled = true;
			this.cmdGeneraRepo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdGeneraRepo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdGeneraRepo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdGeneraRepo.Location = new System.Drawing.Point(248, 336);
			this.cmdGeneraRepo.Name = "cmdGeneraRepo";
			this.cmdGeneraRepo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGeneraRepo.Size = new System.Drawing.Size(137, 25);
			this.cmdGeneraRepo.TabIndex = 2;
			this.cmdGeneraRepo.TabStop = true;
			this.cmdGeneraRepo.Tag = "";
			this.cmdGeneraRepo.Text = "Generar &Reporte";
			this.cmdGeneraRepo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGeneraRepo.Click += new System.EventHandler(this.cmdGeneraRepo_Click);
			// 
			// txtFechaFinal
			// 
			this.txtFechaFinal.AcceptsReturn = true;
			this.txtFechaFinal.AutoSize = false;
			this.txtFechaFinal.BackColor = System.Drawing.SystemColors.Window;
			this.txtFechaFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtFechaFinal.CausesValidation = true;
			this.txtFechaFinal.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFechaFinal.Enabled = false;
			this.txtFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFechaFinal.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFechaFinal.HideSelection = true;
			this.txtFechaFinal.Location = new System.Drawing.Point(528, 40);
			this.txtFechaFinal.MaxLength = 0;
			this.txtFechaFinal.Multiline = false;
			this.txtFechaFinal.Name = "txtFechaFinal";
			this.txtFechaFinal.ReadOnly = false;
			this.txtFechaFinal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFechaFinal.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFechaFinal.Size = new System.Drawing.Size(97, 19);
			this.txtFechaFinal.TabIndex = 10;
			this.txtFechaFinal.TabStop = true;
			this.txtFechaFinal.Tag = "";
			this.txtFechaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFechaFinal.Visible = true;
			// 
			// txtFechaInicial
			// 
			this.txtFechaInicial.AcceptsReturn = true;
			this.txtFechaInicial.AutoSize = false;
			this.txtFechaInicial.BackColor = System.Drawing.SystemColors.Window;
			this.txtFechaInicial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtFechaInicial.CausesValidation = true;
			this.txtFechaInicial.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFechaInicial.Enabled = false;
			this.txtFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFechaInicial.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFechaInicial.HideSelection = true;
			this.txtFechaInicial.Location = new System.Drawing.Point(528, 8);
			this.txtFechaInicial.MaxLength = 0;
			this.txtFechaInicial.Multiline = false;
			this.txtFechaInicial.Name = "txtFechaInicial";
			this.txtFechaInicial.ReadOnly = false;
			this.txtFechaInicial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFechaInicial.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFechaInicial.Size = new System.Drawing.Size(97, 19);
			this.txtFechaInicial.TabIndex = 8;
			this.txtFechaInicial.TabStop = true;
			this.txtFechaInicial.Tag = "";
			this.txtFechaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFechaInicial.Visible = true;
			// 
			// txtFechaProceso
			// 
			this.txtFechaProceso.AcceptsReturn = true;
			this.txtFechaProceso.AutoSize = false;
			this.txtFechaProceso.BackColor = System.Drawing.SystemColors.Window;
			this.txtFechaProceso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtFechaProceso.CausesValidation = true;
			this.txtFechaProceso.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtFechaProceso.Enabled = false;
			this.txtFechaProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFechaProceso.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtFechaProceso.HideSelection = true;
			this.txtFechaProceso.Location = new System.Drawing.Point(112, 40);
			this.txtFechaProceso.MaxLength = 0;
			this.txtFechaProceso.Multiline = false;
			this.txtFechaProceso.Name = "txtFechaProceso";
			this.txtFechaProceso.ReadOnly = false;
			this.txtFechaProceso.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFechaProceso.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFechaProceso.Size = new System.Drawing.Size(105, 19);
			this.txtFechaProceso.TabIndex = 6;
			this.txtFechaProceso.TabStop = true;
			this.txtFechaProceso.Tag = "";
			this.txtFechaProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFechaProceso.Visible = true;
			// 
			// cmdSalir
			// 
			this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
			this.cmdSalir.CausesValidation = true;
			this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdSalir.Enabled = true;
			this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdSalir.Location = new System.Drawing.Point(480, 336);
			this.cmdSalir.Name = "cmdSalir";
			this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSalir.Size = new System.Drawing.Size(137, 25);
			this.cmdSalir.TabIndex = 3;
			this.cmdSalir.TabStop = true;
			this.cmdSalir.Tag = "";
			this.cmdSalir.Text = "&Salir";
			this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
			// 
			// cmdConsultaTH
			// 
			this.cmdConsultaTH.BackColor = System.Drawing.SystemColors.Control;
			this.cmdConsultaTH.CausesValidation = true;
			this.cmdConsultaTH.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdConsultaTH.Enabled = true;
			this.cmdConsultaTH.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdConsultaTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdConsultaTH.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdConsultaTH.Location = new System.Drawing.Point(24, 336);
			this.cmdConsultaTH.Name = "cmdConsultaTH";
			this.cmdConsultaTH.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdConsultaTH.Size = new System.Drawing.Size(137, 25);
			this.cmdConsultaTH.TabIndex = 1;
			this.cmdConsultaTH.TabStop = true;
			this.cmdConsultaTH.Tag = "";
			this.cmdConsultaTH.Text = "&Consultar Tarjetahabientes";
			this.cmdConsultaTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdConsultaTH.Click += new System.EventHandler(this.cmdConsultaTH_Click);
			// 
			// txtEmpresa
			// 
			this.txtEmpresa.AcceptsReturn = true;
			this.txtEmpresa.AutoSize = false;
			this.txtEmpresa.BackColor = System.Drawing.SystemColors.Window;
			this.txtEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtEmpresa.CausesValidation = true;
			this.txtEmpresa.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtEmpresa.Enabled = false;
			this.txtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtEmpresa.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtEmpresa.HideSelection = true;
			this.txtEmpresa.Location = new System.Drawing.Point(112, 8);
			this.txtEmpresa.MaxLength = 0;
			this.txtEmpresa.Multiline = false;
			this.txtEmpresa.Name = "txtEmpresa";
			this.txtEmpresa.ReadOnly = false;
			this.txtEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtEmpresa.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtEmpresa.Size = new System.Drawing.Size(249, 19);
			this.txtEmpresa.TabIndex = 4;
			this.txtEmpresa.TabStop = true;
			this.txtEmpresa.Tag = "";
			this.txtEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtEmpresa.Visible = true;
			// 
			// LsvUnidades
			// 
			this.LsvUnidades.Location = new System.Drawing.Point(8, 64);
			this.LsvUnidades.Name = "LsvUnidades";
			this.LsvUnidades.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("LsvUnidades.OcxState");
			this.LsvUnidades.Size = new System.Drawing.Size(625, 265);
			this.LsvUnidades.TabIndex = 7;
			this.LsvUnidades.Tag = "";
			this.LsvUnidades.DblClick += new System.EventHandler(this.LsvUnidades_DblClick);
			// 
			// lblFechaFinal
			// 
			this.lblFechaFinal.AutoSize = false;
			this.lblFechaFinal.BackColor = System.Drawing.SystemColors.Control;
			this.lblFechaFinal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblFechaFinal.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFechaFinal.Enabled = true;
			this.lblFechaFinal.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblFechaFinal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblFechaFinal.Location = new System.Drawing.Point(448, 40);
			this.lblFechaFinal.Name = "lblFechaFinal";
			this.lblFechaFinal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFechaFinal.Size = new System.Drawing.Size(65, 17);
			this.lblFechaFinal.TabIndex = 11;
			this.lblFechaFinal.Tag = "";
			this.lblFechaFinal.Text = "Fecha Final:";
			this.lblFechaFinal.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblFechaFinal.UseMnemonic = true;
			this.lblFechaFinal.Visible = true;
			// 
			// lblFechaInicial
			// 
			this.lblFechaInicial.AutoSize = false;
			this.lblFechaInicial.BackColor = System.Drawing.SystemColors.Control;
			this.lblFechaInicial.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblFechaInicial.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFechaInicial.Enabled = true;
			this.lblFechaInicial.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblFechaInicial.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblFechaInicial.Location = new System.Drawing.Point(448, 8);
			this.lblFechaInicial.Name = "lblFechaInicial";
			this.lblFechaInicial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFechaInicial.Size = new System.Drawing.Size(65, 17);
			this.lblFechaInicial.TabIndex = 9;
			this.lblFechaInicial.Tag = "";
			this.lblFechaInicial.Text = "Fecha Inicial:";
			this.lblFechaInicial.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblFechaInicial.UseMnemonic = true;
			this.lblFechaInicial.Visible = true;
			// 
			// lblFechaProceso
			// 
			this.lblFechaProceso.AutoSize = false;
			this.lblFechaProceso.BackColor = System.Drawing.SystemColors.Control;
			this.lblFechaProceso.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblFechaProceso.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFechaProceso.Enabled = true;
			this.lblFechaProceso.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFechaProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblFechaProceso.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblFechaProceso.Location = new System.Drawing.Point(8, 40);
			this.lblFechaProceso.Name = "lblFechaProceso";
			this.lblFechaProceso.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFechaProceso.Size = new System.Drawing.Size(89, 17);
			this.lblFechaProceso.TabIndex = 5;
			this.lblFechaProceso.Tag = "";
			this.lblFechaProceso.Text = "Fecha de proceso";
			this.lblFechaProceso.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblFechaProceso.UseMnemonic = true;
			this.lblFechaProceso.Visible = true;
			// 
			// lblEmpresa
			// 
			this.lblEmpresa.AutoSize = false;
			this.lblEmpresa.BackColor = System.Drawing.SystemColors.Control;
			this.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblEmpresa.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblEmpresa.Enabled = true;
			this.lblEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblEmpresa.Location = new System.Drawing.Point(8, 8);
			this.lblEmpresa.Name = "lblEmpresa";
			this.lblEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblEmpresa.Size = new System.Drawing.Size(41, 17);
			this.lblEmpresa.TabIndex = 0;
			this.lblEmpresa.Tag = "";
			this.lblEmpresa.Text = "Empresa";
			this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblEmpresa.UseMnemonic = true;
			this.lblEmpresa.Visible = true;
			// 
			// frmNivelUnidad
			// 
			this.AcceptButton = this.cmdConsultaTH;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(645, 374);
			this.ControlBox = true;
			this.Controls.Add(this.txtFechaProceso);
			this.Controls.Add(this.txtFechaInicial);
			this.Controls.Add(this.cmdConsultaTH);
			this.Controls.Add(this.cmdSalir);
			this.Controls.Add(this.Picture1);
			this.Controls.Add(this.lblEmpresa);
			this.Controls.Add(this.txtFechaFinal);
			this.Controls.Add(this.cmdGeneraRepo);
			this.Controls.Add(this.lblFechaFinal);
			this.Controls.Add(this.lblFechaInicial);
			this.Controls.Add(this.LsvUnidades);
			this.Controls.Add(this.txtEmpresa);
			this.Controls.Add(this.lblFechaProceso);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.Icon = (System.Drawing.Icon) resources.GetObject("frmNivelUnidad.Icon");
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(4, 23);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNivelUnidad";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Tag = "";
			this.Text = "SBF-CCF Nivel Unidad";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.frmNivelUnidad_Closed);
			((System.ComponentModel.ISupportInitialize) this.LsvUnidades).EndInit();
			this.ResumeLayout(false);
	}
#endregion 
}
}