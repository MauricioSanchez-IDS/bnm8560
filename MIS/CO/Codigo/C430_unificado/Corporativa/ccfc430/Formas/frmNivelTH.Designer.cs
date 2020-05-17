using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmNivelTH
	{
	
#region "Upgrade Support "
		private static frmNivelTH m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmNivelTH DefInstance
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
		public frmNivelTH():base(){
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
	public static frmNivelTH CreateInstance()
	{
			frmNivelTH theInstance = new frmNivelTH();
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
	public  System.Windows.Forms.Button cmdGeneraRepo;
	public  System.Windows.Forms.PictureBox Picture1;
	public  System.Windows.Forms.TextBox txtFechaProceso;
	public  System.Windows.Forms.TextBox txtEmpresa;
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.Button cmdConsultaTrans;
	public  System.Windows.Forms.TextBox txtUnidad;
	public  AxMSComctlLib.AxListView LsvTarjeta;
	public  System.Windows.Forms.Label lblFechaProceso;
	public  System.Windows.Forms.Label lblEmpresa;
	public  System.Windows.Forms.Label lblUnidad;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNivelTH));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cmdGeneraRepo = new System.Windows.Forms.Button();
			this.Picture1 = new System.Windows.Forms.PictureBox();
			this.txtFechaProceso = new System.Windows.Forms.TextBox();
			this.txtEmpresa = new System.Windows.Forms.TextBox();
			this.cmdSalir = new System.Windows.Forms.Button();
			this.cmdConsultaTrans = new System.Windows.Forms.Button();
			this.txtUnidad = new System.Windows.Forms.TextBox();
			this.LsvTarjeta = new AxMSComctlLib.AxListView();
			this.lblFechaProceso = new System.Windows.Forms.Label();
			this.lblEmpresa = new System.Windows.Forms.Label();
			this.lblUnidad = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.LsvTarjeta).BeginInit();
			this.SuspendLayout();
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
			this.cmdGeneraRepo.Location = new System.Drawing.Point(232, 352);
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
			this.Picture1.Location = new System.Drawing.Point(-16, 344);
			this.Picture1.Name = "Picture1";
			this.Picture1.Size = new System.Drawing.Size(17, 25);
			this.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.Picture1.TabIndex = 9;
			this.Picture1.TabStop = true;
			this.Picture1.Tag = "";
			this.Picture1.Visible = false;
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
			this.txtFechaProceso.Location = new System.Drawing.Point(104, 40);
			this.txtFechaProceso.MaxLength = 0;
			this.txtFechaProceso.Multiline = false;
			this.txtFechaProceso.Name = "txtFechaProceso";
			this.txtFechaProceso.ReadOnly = false;
			this.txtFechaProceso.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtFechaProceso.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtFechaProceso.Size = new System.Drawing.Size(105, 19);
			this.txtFechaProceso.TabIndex = 8;
			this.txtFechaProceso.TabStop = true;
			this.txtFechaProceso.Tag = "";
			this.txtFechaProceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtFechaProceso.Visible = true;
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
			this.txtEmpresa.Location = new System.Drawing.Point(104, 8);
			this.txtEmpresa.MaxLength = 0;
			this.txtEmpresa.Multiline = false;
			this.txtEmpresa.Name = "txtEmpresa";
			this.txtEmpresa.ReadOnly = false;
			this.txtEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtEmpresa.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtEmpresa.Size = new System.Drawing.Size(321, 19);
			this.txtEmpresa.TabIndex = 6;
			this.txtEmpresa.TabStop = true;
			this.txtEmpresa.Tag = "";
			this.txtEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtEmpresa.Visible = true;
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
			this.cmdSalir.Location = new System.Drawing.Point(440, 352);
			this.cmdSalir.Name = "cmdSalir";
			this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSalir.Size = new System.Drawing.Size(153, 25);
			this.cmdSalir.TabIndex = 3;
			this.cmdSalir.TabStop = true;
			this.cmdSalir.Tag = "";
			this.cmdSalir.Text = "&Salir";
			this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
			// 
			// cmdConsultaTrans
			// 
			this.cmdConsultaTrans.BackColor = System.Drawing.SystemColors.Control;
			this.cmdConsultaTrans.CausesValidation = true;
			this.cmdConsultaTrans.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdConsultaTrans.Enabled = true;
			this.cmdConsultaTrans.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdConsultaTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdConsultaTrans.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdConsultaTrans.Location = new System.Drawing.Point(24, 352);
			this.cmdConsultaTrans.Name = "cmdConsultaTrans";
			this.cmdConsultaTrans.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdConsultaTrans.Size = new System.Drawing.Size(153, 25);
			this.cmdConsultaTrans.TabIndex = 1;
			this.cmdConsultaTrans.TabStop = true;
			this.cmdConsultaTrans.Tag = "";
			this.cmdConsultaTrans.Text = "Consultar &Transacciones";
			this.cmdConsultaTrans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdConsultaTrans.Click += new System.EventHandler(this.cmdConsultaTrans_Click);
			// 
			// txtUnidad
			// 
			this.txtUnidad.AcceptsReturn = true;
			this.txtUnidad.AutoSize = false;
			this.txtUnidad.BackColor = System.Drawing.SystemColors.Window;
			this.txtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtUnidad.CausesValidation = true;
			this.txtUnidad.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtUnidad.Enabled = false;
			this.txtUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtUnidad.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUnidad.HideSelection = true;
			this.txtUnidad.Location = new System.Drawing.Point(280, 40);
			this.txtUnidad.MaxLength = 0;
			this.txtUnidad.Multiline = false;
			this.txtUnidad.Name = "txtUnidad";
			this.txtUnidad.ReadOnly = false;
			this.txtUnidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtUnidad.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtUnidad.Size = new System.Drawing.Size(265, 19);
			this.txtUnidad.TabIndex = 4;
			this.txtUnidad.TabStop = true;
			this.txtUnidad.Tag = "";
			this.txtUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtUnidad.Visible = true;
			// 
			// LsvTarjeta
			// 
			this.LsvTarjeta.Location = new System.Drawing.Point(8, 64);
			this.LsvTarjeta.Name = "LsvTarjeta";
			this.LsvTarjeta.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("LsvTarjeta.OcxState");
			this.LsvTarjeta.Size = new System.Drawing.Size(609, 281);
			this.LsvTarjeta.TabIndex = 10;
			this.LsvTarjeta.Tag = "";
			this.LsvTarjeta.DblClick += new System.EventHandler(this.LsvTarjeta_DblClick);
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
			this.lblFechaProceso.TabIndex = 7;
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
			this.lblEmpresa.Size = new System.Drawing.Size(49, 17);
			this.lblEmpresa.TabIndex = 5;
			this.lblEmpresa.Tag = "";
			this.lblEmpresa.Text = "Empresa";
			this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblEmpresa.UseMnemonic = true;
			this.lblEmpresa.Visible = true;
			// 
			// lblUnidad
			// 
			this.lblUnidad.AutoSize = false;
			this.lblUnidad.BackColor = System.Drawing.SystemColors.Control;
			this.lblUnidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblUnidad.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblUnidad.Enabled = true;
			this.lblUnidad.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblUnidad.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblUnidad.Location = new System.Drawing.Point(232, 40);
			this.lblUnidad.Name = "lblUnidad";
			this.lblUnidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblUnidad.Size = new System.Drawing.Size(41, 17);
			this.lblUnidad.TabIndex = 0;
			this.lblUnidad.Tag = "";
			this.lblUnidad.Text = "Unidad";
			this.lblUnidad.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblUnidad.UseMnemonic = true;
			this.lblUnidad.Visible = true;
			// 
			// frmNivelTH
			// 
			this.AcceptButton = this.cmdConsultaTrans;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(623, 382);
			this.ControlBox = true;
			this.Controls.Add(this.lblFechaProceso);
			this.Controls.Add(this.LsvTarjeta);
			this.Controls.Add(this.txtUnidad);
			this.Controls.Add(this.txtEmpresa);
			this.Controls.Add(this.cmdSalir);
			this.Controls.Add(this.cmdConsultaTrans);
			this.Controls.Add(this.cmdGeneraRepo);
			this.Controls.Add(this.Picture1);
			this.Controls.Add(this.txtFechaProceso);
			this.Controls.Add(this.lblEmpresa);
			this.Controls.Add(this.lblUnidad);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.Icon = (System.Drawing.Icon) resources.GetObject("frmNivelTH.Icon");
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(4, 23);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNivelTH";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Tag = "";
			this.Text = "SBF-CCF Nivel Tarjetahabiente";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.frmNivelTH_Closed);
			((System.ComponentModel.ISupportInitialize) this.LsvTarjeta).EndInit();
			this.ResumeLayout(false);
	}
#endregion 
}
}