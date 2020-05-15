using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmNivelTrans
	{
	
#region "Upgrade Support "
		private static frmNivelTrans m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmNivelTrans DefInstance
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
		public frmNivelTrans():base(){
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
	public static frmNivelTrans CreateInstance()
	{
			frmNivelTrans theInstance = new frmNivelTrans();
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
	public  System.Windows.Forms.TextBox txtUnidad;
	public  System.Windows.Forms.TextBox txtEmpresa;
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.Button cmdGeneraRepo;
	public  System.Windows.Forms.TextBox txtNumCuenta;
	public  System.Windows.Forms.TextBox txtTH;
	public  AxMSComctlLib.AxListView LsvTran;
	public  System.Windows.Forms.Label lblUnidad;
	public  System.Windows.Forms.Label lblEmpresa;
	public  System.Windows.Forms.Label lblNumCuenta;
	public  System.Windows.Forms.Label lblTH;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNivelTrans));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.txtUnidad = new System.Windows.Forms.TextBox();
			this.txtEmpresa = new System.Windows.Forms.TextBox();
			this.cmdSalir = new System.Windows.Forms.Button();
			this.cmdGeneraRepo = new System.Windows.Forms.Button();
			this.txtNumCuenta = new System.Windows.Forms.TextBox();
			this.txtTH = new System.Windows.Forms.TextBox();
			this.LsvTran = new AxMSComctlLib.AxListView();
			this.lblUnidad = new System.Windows.Forms.Label();
			this.lblEmpresa = new System.Windows.Forms.Label();
			this.lblNumCuenta = new System.Windows.Forms.Label();
			this.lblTH = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.LsvTran).BeginInit();
			this.SuspendLayout();
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
			this.txtUnidad.Location = new System.Drawing.Point(440, 8);
			this.txtUnidad.MaxLength = 0;
			this.txtUnidad.Multiline = false;
			this.txtUnidad.Name = "txtUnidad";
			this.txtUnidad.ReadOnly = false;
			this.txtUnidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtUnidad.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtUnidad.Size = new System.Drawing.Size(177, 19);
			this.txtUnidad.TabIndex = 9;
			this.txtUnidad.TabStop = true;
			this.txtUnidad.Tag = "";
			this.txtUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtUnidad.Visible = true;
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
			this.txtEmpresa.Location = new System.Drawing.Point(80, 8);
			this.txtEmpresa.MaxLength = 0;
			this.txtEmpresa.Multiline = false;
			this.txtEmpresa.Name = "txtEmpresa";
			this.txtEmpresa.ReadOnly = false;
			this.txtEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtEmpresa.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtEmpresa.Size = new System.Drawing.Size(281, 19);
			this.txtEmpresa.TabIndex = 8;
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
			this.cmdSalir.Location = new System.Drawing.Point(400, 360);
			this.cmdSalir.Name = "cmdSalir";
			this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdSalir.Size = new System.Drawing.Size(137, 25);
			this.cmdSalir.TabIndex = 2;
			this.cmdSalir.TabStop = true;
			this.cmdSalir.Tag = "";
			this.cmdSalir.Text = "&Salir";
			this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
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
			this.cmdGeneraRepo.Location = new System.Drawing.Point(96, 360);
			this.cmdGeneraRepo.Name = "cmdGeneraRepo";
			this.cmdGeneraRepo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdGeneraRepo.Size = new System.Drawing.Size(137, 25);
			this.cmdGeneraRepo.TabIndex = 1;
			this.cmdGeneraRepo.TabStop = true;
			this.cmdGeneraRepo.Tag = "";
			this.cmdGeneraRepo.Text = "Generar &Reporte";
			this.cmdGeneraRepo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdGeneraRepo.Click += new System.EventHandler(this.cmdGeneraRepo_Click);
			// 
			// txtNumCuenta
			// 
			this.txtNumCuenta.AcceptsReturn = true;
			this.txtNumCuenta.AutoSize = false;
			this.txtNumCuenta.BackColor = System.Drawing.SystemColors.Window;
			this.txtNumCuenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtNumCuenta.CausesValidation = true;
			this.txtNumCuenta.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtNumCuenta.Enabled = false;
			this.txtNumCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNumCuenta.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtNumCuenta.HideSelection = true;
			this.txtNumCuenta.Location = new System.Drawing.Point(440, 32);
			this.txtNumCuenta.MaxLength = 0;
			this.txtNumCuenta.Multiline = false;
			this.txtNumCuenta.Name = "txtNumCuenta";
			this.txtNumCuenta.ReadOnly = false;
			this.txtNumCuenta.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtNumCuenta.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtNumCuenta.Size = new System.Drawing.Size(177, 19);
			this.txtNumCuenta.TabIndex = 5;
			this.txtNumCuenta.TabStop = true;
			this.txtNumCuenta.Tag = "";
			this.txtNumCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtNumCuenta.Visible = true;
			// 
			// txtTH
			// 
			this.txtTH.AcceptsReturn = true;
			this.txtTH.AutoSize = false;
			this.txtTH.BackColor = System.Drawing.SystemColors.Window;
			this.txtTH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtTH.CausesValidation = true;
			this.txtTH.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtTH.Enabled = false;
			this.txtTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTH.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTH.HideSelection = true;
			this.txtTH.Location = new System.Drawing.Point(80, 32);
			this.txtTH.MaxLength = 0;
			this.txtTH.Multiline = false;
			this.txtTH.Name = "txtTH";
			this.txtTH.ReadOnly = false;
			this.txtTH.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtTH.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtTH.Size = new System.Drawing.Size(281, 19);
			this.txtTH.TabIndex = 3;
			this.txtTH.TabStop = true;
			this.txtTH.Tag = "";
			this.txtTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtTH.Visible = true;
			// 
			// LsvTran
			// 
			this.LsvTran.Location = new System.Drawing.Point(8, 56);
			this.LsvTran.Name = "LsvTran";
			this.LsvTran.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("LsvTran.OcxState");
			this.LsvTran.Size = new System.Drawing.Size(633, 297);
			this.LsvTran.TabIndex = 10;
			this.LsvTran.Tag = "";
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
			this.lblUnidad.Location = new System.Drawing.Point(368, 8);
			this.lblUnidad.Name = "lblUnidad";
			this.lblUnidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblUnidad.Size = new System.Drawing.Size(41, 17);
			this.lblUnidad.TabIndex = 7;
			this.lblUnidad.Tag = "";
			this.lblUnidad.Text = "Unidad";
			this.lblUnidad.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblUnidad.UseMnemonic = true;
			this.lblUnidad.Visible = true;
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
			this.lblEmpresa.Location = new System.Drawing.Point(0, 8);
			this.lblEmpresa.Name = "lblEmpresa";
			this.lblEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblEmpresa.Size = new System.Drawing.Size(49, 17);
			this.lblEmpresa.TabIndex = 6;
			this.lblEmpresa.Tag = "";
			this.lblEmpresa.Text = "Empresa";
			this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblEmpresa.UseMnemonic = true;
			this.lblEmpresa.Visible = true;
			// 
			// lblNumCuenta
			// 
			this.lblNumCuenta.AutoSize = false;
			this.lblNumCuenta.BackColor = System.Drawing.SystemColors.Control;
			this.lblNumCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblNumCuenta.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblNumCuenta.Enabled = true;
			this.lblNumCuenta.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblNumCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblNumCuenta.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblNumCuenta.Location = new System.Drawing.Point(368, 32);
			this.lblNumCuenta.Name = "lblNumCuenta";
			this.lblNumCuenta.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblNumCuenta.Size = new System.Drawing.Size(89, 17);
			this.lblNumCuenta.TabIndex = 4;
			this.lblNumCuenta.Tag = "";
			this.lblNumCuenta.Text = "No. de Cuenta";
			this.lblNumCuenta.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblNumCuenta.UseMnemonic = true;
			this.lblNumCuenta.Visible = true;
			// 
			// lblTH
			// 
			this.lblTH.AutoSize = false;
			this.lblTH.BackColor = System.Drawing.SystemColors.Control;
			this.lblTH.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblTH.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblTH.Enabled = true;
			this.lblTH.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblTH.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblTH.Location = new System.Drawing.Point(0, 32);
			this.lblTH.Name = "lblTH";
			this.lblTH.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblTH.Size = new System.Drawing.Size(81, 17);
			this.lblTH.TabIndex = 0;
			this.lblTH.Tag = "";
			this.lblTH.Text = "Tarjetahabiente";
			this.lblTH.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblTH.UseMnemonic = true;
			this.lblTH.Visible = true;
			// 
			// frmNivelTrans
			// 
			this.AcceptButton = this.cmdGeneraRepo;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(645, 389);
			this.ControlBox = true;
			this.Controls.Add(this.lblEmpresa);
			this.Controls.Add(this.lblUnidad);
			this.Controls.Add(this.LsvTran);
			this.Controls.Add(this.cmdGeneraRepo);
			this.Controls.Add(this.txtNumCuenta);
			this.Controls.Add(this.txtTH);
			this.Controls.Add(this.txtUnidad);
			this.Controls.Add(this.txtEmpresa);
			this.Controls.Add(this.cmdSalir);
			this.Controls.Add(this.lblNumCuenta);
			this.Controls.Add(this.lblTH);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.Icon = (System.Drawing.Icon) resources.GetObject("frmNivelTrans.Icon");
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(4, 23);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNivelTrans";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Tag = "";
			this.Text = "SBF-CCF Nivel Transacción";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.frmNivelTrans_Closed);
			((System.ComponentModel.ISupportInitialize) this.LsvTran).EndInit();
			this.ResumeLayout(false);
	}
#endregion 
}
}