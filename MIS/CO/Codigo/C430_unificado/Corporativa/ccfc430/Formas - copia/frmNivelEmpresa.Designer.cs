using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmNivelEmpresa
	{
	
#region "Upgrade Support "
		private static frmNivelEmpresa m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmNivelEmpresa DefInstance
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
		public frmNivelEmpresa():base(){
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
	public static frmNivelEmpresa CreateInstance()
	{
			frmNivelEmpresa theInstance = new frmNivelEmpresa();
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
	public  AxMSComctlLib.AxListView LsvEmpresa;
	public  System.Windows.Forms.TextBox txtNombreArchivo;
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.Button cmdUnidad;
	public  System.Windows.Forms.Button cmdError;
	public  System.Windows.Forms.Button cmdVistoBueno;
	public  System.Windows.Forms.TextBox txtFechaFinal;
	public  System.Windows.Forms.TextBox txtFechaInicial;
	public  System.Windows.Forms.Label lblNombreArchivo;
	public  System.Windows.Forms.Label lblFechaFinal;
	public  System.Windows.Forms.Label lblFechaInicial;
	private Artinsoft.VB6.Gui.CommandButtonHelper CommandButtonHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNivelEmpresa));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.cmdGeneraRepo = new System.Windows.Forms.Button();
        this.LsvEmpresa = new AxMSComctlLib.AxListView();
        this.txtNombreArchivo = new System.Windows.Forms.TextBox();
        this.cmdSalir = new System.Windows.Forms.Button();
        this.cmdUnidad = new System.Windows.Forms.Button();
        this.cmdError = new System.Windows.Forms.Button();
        this.cmdVistoBueno = new System.Windows.Forms.Button();
        this.txtFechaFinal = new System.Windows.Forms.TextBox();
        this.txtFechaInicial = new System.Windows.Forms.TextBox();
        this.lblNombreArchivo = new System.Windows.Forms.Label();
        this.lblFechaFinal = new System.Windows.Forms.Label();
        this.lblFechaInicial = new System.Windows.Forms.Label();
        this.CommandButtonHelper1 = new Artinsoft.VB6.Gui.CommandButtonHelper(this.components);
        ((System.ComponentModel.ISupportInitialize)(this.LsvEmpresa)).BeginInit();
        this.SuspendLayout();
        // 
        // cmdGeneraRepo
        // 
        this.cmdGeneraRepo.BackColor = System.Drawing.SystemColors.Control;
        this.cmdGeneraRepo.Cursor = System.Windows.Forms.Cursors.Default;
        this.CommandButtonHelper1.SetDisabledPicture(this.cmdGeneraRepo, null);
        this.CommandButtonHelper1.SetDownPicture(this.cmdGeneraRepo, null);
        this.cmdGeneraRepo.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdGeneraRepo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdGeneraRepo.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdGeneraRepo.Location = new System.Drawing.Point(280, 352);
        this.CommandButtonHelper1.SetMaskColor(this.cmdGeneraRepo, System.Drawing.Color.Silver);
        this.cmdGeneraRepo.Name = "cmdGeneraRepo";
        this.cmdGeneraRepo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdGeneraRepo.Size = new System.Drawing.Size(105, 25);
        this.CommandButtonHelper1.SetStyle(this.cmdGeneraRepo, 0);
        this.cmdGeneraRepo.TabIndex = 2;
        this.cmdGeneraRepo.Tag = "";
        this.cmdGeneraRepo.Text = "Generar &Reporte";
        this.cmdGeneraRepo.UseVisualStyleBackColor = false;
        this.cmdGeneraRepo.Click += new System.EventHandler(this.cmdGeneraRepo_Click);
        // 
        // LsvEmpresa
        // 
        this.LsvEmpresa.Location = new System.Drawing.Point(8, 64);
        this.LsvEmpresa.Name = "LsvEmpresa";
        this.LsvEmpresa.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("LsvEmpresa.OcxState")));
        this.LsvEmpresa.Size = new System.Drawing.Size(697, 281);
        this.LsvEmpresa.TabIndex = 11;
        this.LsvEmpresa.Tag = "";
        this.LsvEmpresa.DblClick += new System.EventHandler(this.LsvEmpresa_DblClick);
        // 
        // txtNombreArchivo
        // 
        this.txtNombreArchivo.AcceptsReturn = true;
        this.txtNombreArchivo.BackColor = System.Drawing.SystemColors.Window;
        this.txtNombreArchivo.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtNombreArchivo.Enabled = false;
        this.txtNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtNombreArchivo.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtNombreArchivo.Location = new System.Drawing.Point(152, 8);
        this.txtNombreArchivo.MaxLength = 0;
        this.txtNombreArchivo.Name = "txtNombreArchivo";
        this.txtNombreArchivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtNombreArchivo.Size = new System.Drawing.Size(273, 19);
        this.txtNombreArchivo.TabIndex = 10;
        this.txtNombreArchivo.Tag = "";
        // 
        // cmdSalir
        // 
        this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
        this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
        this.CommandButtonHelper1.SetDisabledPicture(this.cmdSalir, null);
        this.CommandButtonHelper1.SetDownPicture(this.cmdSalir, null);
        this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
        this.cmdSalir.Location = new System.Drawing.Point(416, 352);
        this.CommandButtonHelper1.SetMaskColor(this.cmdSalir, System.Drawing.Color.Silver);
        this.cmdSalir.Name = "cmdSalir";
        this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdSalir.Size = new System.Drawing.Size(105, 25);
        this.CommandButtonHelper1.SetStyle(this.cmdSalir, 0);
        this.cmdSalir.TabIndex = 3;
        this.cmdSalir.Tag = "";
        this.cmdSalir.Text = "&Salir";
        this.cmdSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        this.cmdSalir.UseVisualStyleBackColor = false;
        this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
        // 
        // cmdUnidad
        // 
        this.cmdUnidad.BackColor = System.Drawing.SystemColors.Control;
        this.cmdUnidad.Cursor = System.Windows.Forms.Cursors.Default;
        this.CommandButtonHelper1.SetDisabledPicture(this.cmdUnidad, null);
        this.CommandButtonHelper1.SetDownPicture(this.cmdUnidad, null);
        this.cmdUnidad.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdUnidad.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdUnidad.Location = new System.Drawing.Point(144, 352);
        this.CommandButtonHelper1.SetMaskColor(this.cmdUnidad, System.Drawing.Color.Silver);
        this.cmdUnidad.Name = "cmdUnidad";
        this.cmdUnidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdUnidad.Size = new System.Drawing.Size(97, 25);
        this.CommandButtonHelper1.SetStyle(this.cmdUnidad, 0);
        this.cmdUnidad.TabIndex = 1;
        this.cmdUnidad.Tag = "";
        this.cmdUnidad.Text = "Consultar &Unidad";
        this.cmdUnidad.UseVisualStyleBackColor = false;
        this.cmdUnidad.Click += new System.EventHandler(this.cmdUnidad_Click);
        // 
        // cmdError
        // 
        this.cmdError.BackColor = System.Drawing.SystemColors.ActiveBorder;
        this.cmdError.Cursor = System.Windows.Forms.Cursors.Default;
        this.CommandButtonHelper1.SetDisabledPicture(this.cmdError, null);
        this.CommandButtonHelper1.SetDownPicture(this.cmdError, null);
        this.cmdError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdError.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdError.Image = ((System.Drawing.Image)(resources.GetObject("cmdError.Image")));
        this.cmdError.Location = new System.Drawing.Point(576, 0);
        this.CommandButtonHelper1.SetMaskColor(this.cmdError, System.Drawing.Color.Silver);
        this.cmdError.Name = "cmdError";
        this.cmdError.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdError.Size = new System.Drawing.Size(81, 57);
        this.CommandButtonHelper1.SetStyle(this.cmdError, 1);
        this.cmdError.TabIndex = 5;
        this.cmdError.Tag = "";
        this.cmdError.Text = "&Rechazar";
        this.cmdError.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        this.cmdError.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        this.cmdError.UseVisualStyleBackColor = false;
        this.cmdError.Click += new System.EventHandler(this.cmdError_Click);
        // 
        // cmdVistoBueno
        // 
        this.cmdVistoBueno.BackColor = System.Drawing.SystemColors.ActiveBorder;
        this.cmdVistoBueno.Cursor = System.Windows.Forms.Cursors.Default;
        this.CommandButtonHelper1.SetDisabledPicture(this.cmdVistoBueno, null);
        this.CommandButtonHelper1.SetDownPicture(this.cmdVistoBueno, null);
        this.cmdVistoBueno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdVistoBueno.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdVistoBueno.Image = ((System.Drawing.Image)(resources.GetObject("cmdVistoBueno.Image")));
        this.cmdVistoBueno.Location = new System.Drawing.Point(456, 0);
        this.CommandButtonHelper1.SetMaskColor(this.cmdVistoBueno, System.Drawing.Color.Silver);
        this.cmdVistoBueno.Name = "cmdVistoBueno";
        this.cmdVistoBueno.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdVistoBueno.Size = new System.Drawing.Size(81, 57);
        this.CommandButtonHelper1.SetStyle(this.cmdVistoBueno, 1);
        this.cmdVistoBueno.TabIndex = 4;
        this.cmdVistoBueno.Tag = "";
        this.cmdVistoBueno.Text = "&Liberar";
        this.cmdVistoBueno.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        this.cmdVistoBueno.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        this.cmdVistoBueno.UseVisualStyleBackColor = false;
        this.cmdVistoBueno.Click += new System.EventHandler(this.cmdVistoBueno_Click);
        // 
        // txtFechaFinal
        // 
        this.txtFechaFinal.AcceptsReturn = true;
        this.txtFechaFinal.BackColor = System.Drawing.SystemColors.Window;
        this.txtFechaFinal.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtFechaFinal.Enabled = false;
        this.txtFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtFechaFinal.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtFechaFinal.Location = new System.Drawing.Point(328, 32);
        this.txtFechaFinal.MaxLength = 0;
        this.txtFechaFinal.Name = "txtFechaFinal";
        this.txtFechaFinal.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtFechaFinal.Size = new System.Drawing.Size(97, 19);
        this.txtFechaFinal.TabIndex = 8;
        this.txtFechaFinal.Tag = "";
        // 
        // txtFechaInicial
        // 
        this.txtFechaInicial.AcceptsReturn = true;
        this.txtFechaInicial.BackColor = System.Drawing.SystemColors.Window;
        this.txtFechaInicial.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtFechaInicial.Enabled = false;
        this.txtFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtFechaInicial.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtFechaInicial.Location = new System.Drawing.Point(152, 32);
        this.txtFechaInicial.MaxLength = 0;
        this.txtFechaInicial.Name = "txtFechaInicial";
        this.txtFechaInicial.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtFechaInicial.Size = new System.Drawing.Size(97, 19);
        this.txtFechaInicial.TabIndex = 7;
        this.txtFechaInicial.Tag = "";
        // 
        // lblNombreArchivo
        // 
        this.lblNombreArchivo.BackColor = System.Drawing.SystemColors.Control;
        this.lblNombreArchivo.Cursor = System.Windows.Forms.Cursors.Default;
        this.lblNombreArchivo.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.lblNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblNombreArchivo.ForeColor = System.Drawing.SystemColors.ControlText;
        this.lblNombreArchivo.Location = new System.Drawing.Point(8, 8);
        this.lblNombreArchivo.Name = "lblNombreArchivo";
        this.lblNombreArchivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblNombreArchivo.Size = new System.Drawing.Size(137, 17);
        this.lblNombreArchivo.TabIndex = 9;
        this.lblNombreArchivo.Tag = "";
        this.lblNombreArchivo.Text = "Nombre del archivo a validar";
        // 
        // lblFechaFinal
        // 
        this.lblFechaFinal.BackColor = System.Drawing.SystemColors.Control;
        this.lblFechaFinal.Cursor = System.Windows.Forms.Cursors.Default;
        this.lblFechaFinal.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.lblFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblFechaFinal.ForeColor = System.Drawing.SystemColors.ControlText;
        this.lblFechaFinal.Location = new System.Drawing.Point(264, 32);
        this.lblFechaFinal.Name = "lblFechaFinal";
        this.lblFechaFinal.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblFechaFinal.Size = new System.Drawing.Size(65, 17);
        this.lblFechaFinal.TabIndex = 6;
        this.lblFechaFinal.Tag = "";
        this.lblFechaFinal.Text = "Fecha Final:";
        // 
        // lblFechaInicial
        // 
        this.lblFechaInicial.BackColor = System.Drawing.SystemColors.Control;
        this.lblFechaInicial.Cursor = System.Windows.Forms.Cursors.Default;
        this.lblFechaInicial.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.lblFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblFechaInicial.ForeColor = System.Drawing.SystemColors.ControlText;
        this.lblFechaInicial.Location = new System.Drawing.Point(8, 32);
        this.lblFechaInicial.Name = "lblFechaInicial";
        this.lblFechaInicial.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblFechaInicial.Size = new System.Drawing.Size(65, 17);
        this.lblFechaInicial.TabIndex = 0;
        this.lblFechaInicial.Tag = "";
        this.lblFechaInicial.Text = "Fecha Inicial:";
        // 
        // frmNivelEmpresa
        // 
        this.AcceptButton = this.cmdUnidad;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(710, 386);
        this.Controls.Add(this.lblNombreArchivo);
        this.Controls.Add(this.txtFechaInicial);
        this.Controls.Add(this.txtFechaFinal);
        this.Controls.Add(this.cmdUnidad);
        this.Controls.Add(this.cmdError);
        this.Controls.Add(this.cmdVistoBueno);
        this.Controls.Add(this.cmdSalir);
        this.Controls.Add(this.cmdGeneraRepo);
        this.Controls.Add(this.LsvEmpresa);
        this.Controls.Add(this.txtNombreArchivo);
        this.Controls.Add(this.lblFechaFinal);
        this.Controls.Add(this.lblFechaInicial);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Location = new System.Drawing.Point(4, 23);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmNivelEmpresa";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "SBF-CCF Nivel Empresa";
        this.Closed += new System.EventHandler(this.frmNivelEmpresa_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.LsvEmpresa)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}