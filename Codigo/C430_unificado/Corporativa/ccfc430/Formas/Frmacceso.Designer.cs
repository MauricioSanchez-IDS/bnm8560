using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmAcceso
	{
	
#region "Upgrade Support "
		private static frmAcceso m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmAcceso DefInstance
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
		public frmAcceso():base(){
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
			InitializechkAccesoNivel();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frmAcceso CreateInstance()
	{
			frmAcceso theInstance = new frmAcceso();
			theInstance.Form_Load();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing.
			theInstance.Show();
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
	public  System.Windows.Forms.Button cmdAceptar;
	public  System.Windows.Forms.Button cmbCancelar;
	public  System.Windows.Forms.TextBox txtClave;
	public  System.Windows.Forms.TextBox txtDescripcion;
	public  System.Windows.Forms.Label lblDescripcion;
	public  System.Windows.Forms.Label lblClave;
	public  AxThreed.AxSSFrame pnlClave;
	public  AxThreed.AxSSCheck chk_estatus_cdf;
	public  AxThreed.AxSSCheck chkBanco;
	public  AxThreed.AxSSCheck chkGrupo;
	public  AxThreed.AxSSCheck chkUsuario;
	public  AxThreed.AxSSCheck chkSeguridad;
	public  AxThreed.AxSSCheck chkLimCred;
	public  AxThreed.AxSSCheck chkCamMasivos;
	public  AxThreed.AxSSCheck chkIntegracion;
	public  AxThreed.AxSSCheck chkParametros;
	public  AxThreed.AxSSCheck chkConfigurar;
	public  AxThreed.AxSSCheck chkSalir;
	public  AxThreed.AxSSPanel pnlGrupo;
	public  AxThreed.AxSSCheck chkEnvioLimCred;
	public  AxThreed.AxSSCheck chk_altas_masivas;
	public  AxThreed.AxSSCheck chk_categorias;
	public  AxThreed.AxSSCheck chk_Reportes;
	public  AxThreed.AxSSCheck chk_unidades;
	public  AxThreed.AxSSCheck chk_Estruct_Gastos;
	public  AxThreed.AxSSCheck chkCCI;
	public  AxThreed.AxSSCheck chkRegiones;
	public  AxThreed.AxSSCheck chkDivisiones;
	public  AxThreed.AxSSCheck chkEjecutivos;
	public  AxThreed.AxSSCheck chkTarjetahabientes;
	public  AxThreed.AxSSCheck chkEmpresas;
	public  AxThreed.AxSSCheck chkCorporativos;
	public  AxThreed.AxSSCheck chkArchivos;
	public  AxThreed.AxSSPanel pnlArchivos;
	public  AxThreed.AxSSCheck chkDepuracion;
	public  AxThreed.AxSSCheck chkTransmision;
	public  AxThreed.AxSSCheck chkInterfaces;
	public  AxThreed.AxSSPanel pnlInterfaces;
	private  AxThreed.AxSSCheck _chkAccesoNivel_0;
	private  AxThreed.AxSSCheck _chkAccesoNivel_3;
	private  AxThreed.AxSSCheck _chkAccesoNivel_2;
	private  AxThreed.AxSSCheck _chkAccesoNivel_1;
	public  System.Windows.Forms.Label pnlAccesoLabel_Text;
	public  AxThreed.AxSSPanel pnlAcceso;
	public  AxThreed.AxSSCheck chkEnvioRep;
	public  AxThreed.AxSSCheck chkEjeBnx;
	public  AxThreed.AxSSCheck chkOpciones;
	public  AxThreed.AxSSCheck chkAclara;
	public  AxThreed.AxSSCheck chkEmulador;
	public  AxThreed.AxSSCheck chkGraficas;
	public  AxThreed.AxSSCheck chkBitacora;
	public  AxThreed.AxSSCheck chkCorporo;
	public  AxThreed.AxSSCheck chkEmp;
	public  AxThreed.AxSSCheck chkAclaraciones;
	public  AxThreed.AxSSCheck chkSituacion;
	public  AxThreed.AxSSCheck chkCreditos;
	public  AxThreed.AxSSCheck chkAntiguedad;
	public  AxThreed.AxSSCheck chkVencidos;
	public  AxThreed.AxSSCheck chkComparativos;
	public  AxThreed.AxSSCheck chkRentabilidad;
	public  AxThreed.AxSSCheck chkCrystal;
	public  AxThreed.AxSSCheck chkAfiliadas;
	public  AxThreed.AxSSCheck chkEjeBanamex;
	public  AxThreed.AxSSCheck chkAtrasos;
	public  AxThreed.AxSSCheck chkDetalle;
	public  AxThreed.AxSSCheck chkConsumos;
	public  AxThreed.AxSSCheck chkGpoEmp;
	public  AxThreed.AxSSCheck chkEmpEje;
	public  AxThreed.AxSSCheck chkConcentrado;
	public  AxThreed.AxSSCheck chkConsultas;
	public  AxThreed.AxSSCheck chkSBF;
	public  AxThreed.AxSSPanel pnlConsultas;
	public AxThreed.AxSSCheck[] chkAccesoNivel = new AxThreed.AxSSCheck[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcceso));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.cmdAceptar = new System.Windows.Forms.Button();
        this.cmbCancelar = new System.Windows.Forms.Button();
        this.pnlClave = new AxThreed.AxSSFrame();
        this.txtDescripcion = new System.Windows.Forms.TextBox();
        this.txtClave = new System.Windows.Forms.TextBox();
        this.lblClave = new System.Windows.Forms.Label();
        this.lblDescripcion = new System.Windows.Forms.Label();
        this.pnlGrupo = new AxThreed.AxSSPanel();
        this.chkLimCred = new AxThreed.AxSSCheck();
        this.chkCamMasivos = new AxThreed.AxSSCheck();
        this.chkUsuario = new AxThreed.AxSSCheck();
        this.chkSeguridad = new AxThreed.AxSSCheck();
        this.chkConfigurar = new AxThreed.AxSSCheck();
        this.chkSalir = new AxThreed.AxSSCheck();
        this.chkIntegracion = new AxThreed.AxSSCheck();
        this.chkParametros = new AxThreed.AxSSCheck();
        this.chkGrupo = new AxThreed.AxSSCheck();
        this.chk_estatus_cdf = new AxThreed.AxSSCheck();
        this.chkBanco = new AxThreed.AxSSCheck();
        this.pnlArchivos = new AxThreed.AxSSPanel();
        this.chkRegiones = new AxThreed.AxSSCheck();
        this.chkDivisiones = new AxThreed.AxSSCheck();
        this.chkCCI = new AxThreed.AxSSCheck();
        this.chk_unidades = new AxThreed.AxSSCheck();
        this.chk_Estruct_Gastos = new AxThreed.AxSSCheck();
        this.chkCorporativos = new AxThreed.AxSSCheck();
        this.chkArchivos = new AxThreed.AxSSCheck();
        this.chkEmpresas = new AxThreed.AxSSCheck();
        this.chkEjecutivos = new AxThreed.AxSSCheck();
        this.chkTarjetahabientes = new AxThreed.AxSSCheck();
        this.chk_altas_masivas = new AxThreed.AxSSCheck();
        this.chkEnvioLimCred = new AxThreed.AxSSCheck();
        this.chk_Reportes = new AxThreed.AxSSCheck();
        this.chk_categorias = new AxThreed.AxSSCheck();
        this.pnlInterfaces = new AxThreed.AxSSPanel();
        this.chkDepuracion = new AxThreed.AxSSCheck();
        this.chkTransmision = new AxThreed.AxSSCheck();
        this.chkInterfaces = new AxThreed.AxSSCheck();
        this.pnlAcceso = new AxThreed.AxSSPanel();
        this._chkAccesoNivel_2 = new AxThreed.AxSSCheck();
        this._chkAccesoNivel_3 = new AxThreed.AxSSCheck();
        this._chkAccesoNivel_0 = new AxThreed.AxSSCheck();
        this.pnlAccesoLabel_Text = new System.Windows.Forms.Label();
        this._chkAccesoNivel_1 = new AxThreed.AxSSCheck();
        this.pnlConsultas = new AxThreed.AxSSPanel();
        this.chkCrystal = new AxThreed.AxSSCheck();
        this.chkRentabilidad = new AxThreed.AxSSCheck();
        this.chkEjeBanamex = new AxThreed.AxSSCheck();
        this.chkAfiliadas = new AxThreed.AxSSCheck();
        this.chkAntiguedad = new AxThreed.AxSSCheck();
        this.chkCreditos = new AxThreed.AxSSCheck();
        this.chkComparativos = new AxThreed.AxSSCheck();
        this.chkVencidos = new AxThreed.AxSSCheck();
        this.chkConcentrado = new AxThreed.AxSSCheck();
        this.chkEmpEje = new AxThreed.AxSSCheck();
        this.chkSBF = new AxThreed.AxSSCheck();
        this.chkConsultas = new AxThreed.AxSSCheck();
        this.chkDetalle = new AxThreed.AxSSCheck();
        this.chkAtrasos = new AxThreed.AxSSCheck();
        this.chkGpoEmp = new AxThreed.AxSSCheck();
        this.chkConsumos = new AxThreed.AxSSCheck();
        this.chkSituacion = new AxThreed.AxSSCheck();
        this.chkAclara = new AxThreed.AxSSCheck();
        this.chkEmulador = new AxThreed.AxSSCheck();
        this.chkOpciones = new AxThreed.AxSSCheck();
        this.chkEnvioRep = new AxThreed.AxSSCheck();
        this.chkEjeBnx = new AxThreed.AxSSCheck();
        this.chkEmp = new AxThreed.AxSSCheck();
        this.chkAclaraciones = new AxThreed.AxSSCheck();
        this.chkCorporo = new AxThreed.AxSSCheck();
        this.chkGraficas = new AxThreed.AxSSCheck();
        this.chkBitacora = new AxThreed.AxSSCheck();
        ((System.ComponentModel.ISupportInitialize)(this.pnlClave)).BeginInit();
        this.pnlClave.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pnlGrupo)).BeginInit();
        this.pnlGrupo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.chkLimCred)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCamMasivos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkUsuario)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkSeguridad)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkConfigurar)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkSalir)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkIntegracion)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkParametros)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkGrupo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_estatus_cdf)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkBanco)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlArchivos)).BeginInit();
        this.pnlArchivos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.chkRegiones)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkDivisiones)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCCI)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_unidades)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_Estruct_Gastos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCorporativos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkArchivos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEmpresas)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEjecutivos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkTarjetahabientes)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_altas_masivas)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEnvioLimCred)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_Reportes)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_categorias)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlInterfaces)).BeginInit();
        this.pnlInterfaces.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.chkDepuracion)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkTransmision)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkInterfaces)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlAcceso)).BeginInit();
        this.pnlAcceso.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._chkAccesoNivel_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._chkAccesoNivel_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._chkAccesoNivel_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._chkAccesoNivel_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlConsultas)).BeginInit();
        this.pnlConsultas.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.chkCrystal)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkRentabilidad)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEjeBanamex)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAfiliadas)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAntiguedad)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCreditos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkComparativos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkVencidos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkConcentrado)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEmpEje)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkSBF)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkConsultas)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkDetalle)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAtrasos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkGpoEmp)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkConsumos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkSituacion)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAclara)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEmulador)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkOpciones)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEnvioRep)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEjeBnx)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEmp)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAclaraciones)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCorporo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkGraficas)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkBitacora)).BeginInit();
        this.SuspendLayout();
        // 
        // cmdAceptar
        // 
        this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
        this.cmdAceptar.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdAceptar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdAceptar.Location = new System.Drawing.Point(256, 440);
        this.cmdAceptar.Name = "cmdAceptar";
        this.cmdAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdAceptar.Size = new System.Drawing.Size(71, 25);
        this.cmdAceptar.TabIndex = 50;
        this.cmdAceptar.Tag = "";
        this.cmdAceptar.Text = "Aceptar";
        this.cmdAceptar.UseVisualStyleBackColor = false;
        this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
        // 
        // cmbCancelar
        // 
        this.cmbCancelar.BackColor = System.Drawing.SystemColors.Control;
        this.cmbCancelar.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmbCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmbCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmbCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmbCancelar.Location = new System.Drawing.Point(344, 440);
        this.cmbCancelar.Name = "cmbCancelar";
        this.cmbCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmbCancelar.Size = new System.Drawing.Size(69, 25);
        this.cmbCancelar.TabIndex = 51;
        this.cmbCancelar.Tag = "";
        this.cmbCancelar.Text = "Cancelar";
        this.cmbCancelar.UseVisualStyleBackColor = false;
        this.cmbCancelar.Click += new System.EventHandler(this.cmbCancelar_Click);
        // 
        // pnlClave
        // 
        this.pnlClave.Controls.Add(this.txtDescripcion);
        this.pnlClave.Controls.Add(this.txtClave);
        this.pnlClave.Controls.Add(this.lblClave);
        this.pnlClave.Controls.Add(this.lblDescripcion);
        this.pnlClave.Location = new System.Drawing.Point(16, 3);
        this.pnlClave.Name = "pnlClave";
        this.pnlClave.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlClave.OcxState")));
        this.pnlClave.Size = new System.Drawing.Size(435, 38);
        this.pnlClave.TabIndex = 52;
        this.pnlClave.Tag = "";
        // 
        // txtDescripcion
        // 
        this.txtDescripcion.AcceptsReturn = true;
        this.txtDescripcion.BackColor = System.Drawing.Color.White;
        this.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtDescripcion.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtDescripcion.Location = new System.Drawing.Point(272, 12);
        this.txtDescripcion.MaxLength = 20;
        this.txtDescripcion.Name = "txtDescripcion";
        this.txtDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtDescripcion.Size = new System.Drawing.Size(147, 19);
        this.txtDescripcion.TabIndex = 1;
        this.txtDescripcion.Tag = "";
        // 
        // txtClave
        // 
        this.txtClave.AcceptsReturn = true;
        this.txtClave.BackColor = System.Drawing.Color.White;
        this.txtClave.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtClave.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtClave.Location = new System.Drawing.Point(142, 11);
        this.txtClave.MaxLength = 3;
        this.txtClave.Name = "txtClave";
        this.txtClave.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtClave.Size = new System.Drawing.Size(38, 19);
        this.txtClave.TabIndex = 0;
        this.txtClave.Tag = "";
        // 
        // lblClave
        // 
        this.lblClave.BackColor = System.Drawing.SystemColors.Control;
        this.lblClave.Cursor = System.Windows.Forms.Cursors.Default;
        this.lblClave.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblClave.ForeColor = System.Drawing.SystemColors.ControlText;
        this.lblClave.Location = new System.Drawing.Point(89, 16);
        this.lblClave.Name = "lblClave";
        this.lblClave.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblClave.Size = new System.Drawing.Size(43, 17);
        this.lblClave.TabIndex = 53;
        this.lblClave.Tag = "";
        this.lblClave.Text = " &Clave";
        // 
        // lblDescripcion
        // 
        this.lblDescripcion.BackColor = System.Drawing.SystemColors.Control;
        this.lblDescripcion.Cursor = System.Windows.Forms.Cursors.Default;
        this.lblDescripcion.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ControlText;
        this.lblDescripcion.Location = new System.Drawing.Point(198, 14);
        this.lblDescripcion.Name = "lblDescripcion";
        this.lblDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblDescripcion.Size = new System.Drawing.Size(73, 15);
        this.lblDescripcion.TabIndex = 54;
        this.lblDescripcion.Tag = "";
        this.lblDescripcion.Text = " &Descripción";
        // 
        // pnlGrupo
        // 
        this.pnlGrupo.Controls.Add(this.chkLimCred);
        this.pnlGrupo.Controls.Add(this.chkCamMasivos);
        this.pnlGrupo.Controls.Add(this.chkUsuario);
        this.pnlGrupo.Controls.Add(this.chkSeguridad);
        this.pnlGrupo.Controls.Add(this.chkConfigurar);
        this.pnlGrupo.Controls.Add(this.chkSalir);
        this.pnlGrupo.Controls.Add(this.chkIntegracion);
        this.pnlGrupo.Controls.Add(this.chkParametros);
        this.pnlGrupo.Controls.Add(this.chkGrupo);
        this.pnlGrupo.Controls.Add(this.chk_estatus_cdf);
        this.pnlGrupo.Controls.Add(this.chkBanco);
        this.pnlGrupo.Location = new System.Drawing.Point(17, 42);
        this.pnlGrupo.Name = "pnlGrupo";
        this.pnlGrupo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlGrupo.OcxState")));
        this.pnlGrupo.Size = new System.Drawing.Size(209, 152);
        this.pnlGrupo.TabIndex = 55;
        this.pnlGrupo.Tag = "";
        // 
        // chkLimCred
        // 
        this.chkLimCred.Location = new System.Drawing.Point(14, 67);
        this.chkLimCred.Name = "chkLimCred";
        this.chkLimCred.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkLimCred.OcxState")));
        this.chkLimCred.Size = new System.Drawing.Size(135, 12);
        this.chkLimCred.TabIndex = 6;
        this.chkLimCred.Tag = "";
        this.chkLimCred.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkLimCred_ClickEvent);
        // 
        // chkCamMasivos
        // 
        this.chkCamMasivos.Location = new System.Drawing.Point(14, 41);
        this.chkCamMasivos.Name = "chkCamMasivos";
        this.chkCamMasivos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkCamMasivos.OcxState")));
        this.chkCamMasivos.Size = new System.Drawing.Size(135, 12);
        this.chkCamMasivos.TabIndex = 5;
        this.chkCamMasivos.Tag = "";
        this.chkCamMasivos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkCamMasivos_ClickEvent);
        // 
        // chkUsuario
        // 
        this.chkUsuario.Location = new System.Drawing.Point(26, 92);
        this.chkUsuario.Name = "chkUsuario";
        this.chkUsuario.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkUsuario.OcxState")));
        this.chkUsuario.Size = new System.Drawing.Size(135, 12);
        this.chkUsuario.TabIndex = 8;
        this.chkUsuario.Tag = "";
        this.chkUsuario.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkUsuario_ClickEvent);
        // 
        // chkSeguridad
        // 
        this.chkSeguridad.Location = new System.Drawing.Point(14, 79);
        this.chkSeguridad.Name = "chkSeguridad";
        this.chkSeguridad.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkSeguridad.OcxState")));
        this.chkSeguridad.Size = new System.Drawing.Size(135, 12);
        this.chkSeguridad.TabIndex = 7;
        this.chkSeguridad.Tag = "";
        this.chkSeguridad.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkSeguridad_ClickEvent);
        // 
        // chkConfigurar
        // 
        this.chkConfigurar.Location = new System.Drawing.Point(3, 3);
        this.chkConfigurar.Name = "chkConfigurar";
        this.chkConfigurar.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkConfigurar.OcxState")));
        this.chkConfigurar.Size = new System.Drawing.Size(135, 12);
        this.chkConfigurar.TabIndex = 2;
        this.chkConfigurar.Tag = "";
        this.chkConfigurar.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkConfigurar_ClickEvent);
        // 
        // chkSalir
        // 
        this.chkSalir.Location = new System.Drawing.Point(13, 134);
        this.chkSalir.Name = "chkSalir";
        this.chkSalir.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkSalir.OcxState")));
        this.chkSalir.Size = new System.Drawing.Size(90, 13);
        this.chkSalir.TabIndex = 11;
        this.chkSalir.Tag = "";
        // 
        // chkIntegracion
        // 
        this.chkIntegracion.Location = new System.Drawing.Point(14, 29);
        this.chkIntegracion.Name = "chkIntegracion";
        this.chkIntegracion.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkIntegracion.OcxState")));
        this.chkIntegracion.Size = new System.Drawing.Size(135, 12);
        this.chkIntegracion.TabIndex = 4;
        this.chkIntegracion.Tag = "";
        this.chkIntegracion.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkIntegracion_ClickEvent);
        // 
        // chkParametros
        // 
        this.chkParametros.Location = new System.Drawing.Point(14, 16);
        this.chkParametros.Name = "chkParametros";
        this.chkParametros.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkParametros.OcxState")));
        this.chkParametros.Size = new System.Drawing.Size(135, 12);
        this.chkParametros.TabIndex = 3;
        this.chkParametros.Tag = "";
        this.chkParametros.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkParametros_ClickEvent);
        // 
        // chkGrupo
        // 
        this.chkGrupo.Location = new System.Drawing.Point(26, 104);
        this.chkGrupo.Name = "chkGrupo";
        this.chkGrupo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkGrupo.OcxState")));
        this.chkGrupo.Size = new System.Drawing.Size(135, 12);
        this.chkGrupo.TabIndex = 9;
        this.chkGrupo.Tag = "";
        this.chkGrupo.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkGrupo_ClickEvent);
        // 
        // chk_estatus_cdf
        // 
        this.chk_estatus_cdf.Location = new System.Drawing.Point(14, 53);
        this.chk_estatus_cdf.Name = "chk_estatus_cdf";
        this.chk_estatus_cdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chk_estatus_cdf.OcxState")));
        this.chk_estatus_cdf.Size = new System.Drawing.Size(115, 14);
        this.chk_estatus_cdf.TabIndex = 67;
        this.chk_estatus_cdf.Tag = "";
        this.chk_estatus_cdf.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chk_estatus_cdf_ClickEvent);
        // 
        // chkBanco
        // 
        this.chkBanco.Location = new System.Drawing.Point(14, 117);
        this.chkBanco.Name = "chkBanco";
        this.chkBanco.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkBanco.OcxState")));
        this.chkBanco.Size = new System.Drawing.Size(135, 12);
        this.chkBanco.TabIndex = 10;
        this.chkBanco.Tag = "";
        this.chkBanco.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkBanco_ClickEvent);
        // 
        // pnlArchivos
        // 
        this.pnlArchivos.Controls.Add(this.chkRegiones);
        this.pnlArchivos.Controls.Add(this.chkDivisiones);
        this.pnlArchivos.Controls.Add(this.chkCCI);
        this.pnlArchivos.Controls.Add(this.chk_unidades);
        this.pnlArchivos.Controls.Add(this.chk_Estruct_Gastos);
        this.pnlArchivos.Controls.Add(this.chkCorporativos);
        this.pnlArchivos.Controls.Add(this.chkArchivos);
        this.pnlArchivos.Controls.Add(this.chkEmpresas);
        this.pnlArchivos.Controls.Add(this.chkEjecutivos);
        this.pnlArchivos.Controls.Add(this.chkTarjetahabientes);
        this.pnlArchivos.Controls.Add(this.chk_altas_masivas);
        this.pnlArchivos.Controls.Add(this.chkEnvioLimCred);
        this.pnlArchivos.Controls.Add(this.chk_Reportes);
        this.pnlArchivos.Controls.Add(this.chk_categorias);
        this.pnlArchivos.Location = new System.Drawing.Point(17, 227);
        this.pnlArchivos.Name = "pnlArchivos";
        this.pnlArchivos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlArchivos.OcxState")));
        this.pnlArchivos.Size = new System.Drawing.Size(208, 192);
        this.pnlArchivos.TabIndex = 56;
        this.pnlArchivos.Tag = "";
        // 
        // chkRegiones
        // 
        this.chkRegiones.Location = new System.Drawing.Point(15, 146);
        this.chkRegiones.Name = "chkRegiones";
        this.chkRegiones.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkRegiones.OcxState")));
        this.chkRegiones.Size = new System.Drawing.Size(106, 13);
        this.chkRegiones.TabIndex = 21;
        this.chkRegiones.Tag = "";
        this.chkRegiones.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkRegiones_ClickEvent);
        // 
        // chkDivisiones
        // 
        this.chkDivisiones.Location = new System.Drawing.Point(15, 133);
        this.chkDivisiones.Name = "chkDivisiones";
        this.chkDivisiones.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkDivisiones.OcxState")));
        this.chkDivisiones.Size = new System.Drawing.Size(161, 12);
        this.chkDivisiones.TabIndex = 20;
        this.chkDivisiones.Tag = "";
        this.chkDivisiones.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkDivisiones_ClickEvent);
        // 
        // chkCCI
        // 
        this.chkCCI.Location = new System.Drawing.Point(15, 120);
        this.chkCCI.Name = "chkCCI";
        this.chkCCI.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkCCI.OcxState")));
        this.chkCCI.Size = new System.Drawing.Size(164, 13);
        this.chkCCI.TabIndex = 61;
        this.chkCCI.Tag = "";
        this.chkCCI.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkCCI_ClickEvent);
        // 
        // chk_unidades
        // 
        this.chk_unidades.Location = new System.Drawing.Point(15, 55);
        this.chk_unidades.Name = "chk_unidades";
        this.chk_unidades.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chk_unidades.OcxState")));
        this.chk_unidades.Size = new System.Drawing.Size(87, 13);
        this.chk_unidades.TabIndex = 63;
        this.chk_unidades.Tag = "";
        this.chk_unidades.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chk_unidades_ClickEvent);
        // 
        // chk_Estruct_Gastos
        // 
        this.chk_Estruct_Gastos.Location = new System.Drawing.Point(15, 17);
        this.chk_Estruct_Gastos.Name = "chk_Estruct_Gastos";
        this.chk_Estruct_Gastos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chk_Estruct_Gastos.OcxState")));
        this.chk_Estruct_Gastos.Size = new System.Drawing.Size(123, 13);
        this.chk_Estruct_Gastos.TabIndex = 62;
        this.chk_Estruct_Gastos.Tag = "";
        this.chk_Estruct_Gastos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chk_Estruct_Gastos_ClickEvent);
        // 
        // chkCorporativos
        // 
        this.chkCorporativos.Location = new System.Drawing.Point(15, 30);
        this.chkCorporativos.Name = "chkCorporativos";
        this.chkCorporativos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkCorporativos.OcxState")));
        this.chkCorporativos.Size = new System.Drawing.Size(106, 12);
        this.chkCorporativos.TabIndex = 16;
        this.chkCorporativos.Tag = "";
        this.chkCorporativos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkCorporativos_ClickEvent);
        // 
        // chkArchivos
        // 
        this.chkArchivos.Location = new System.Drawing.Point(3, 4);
        this.chkArchivos.Name = "chkArchivos";
        this.chkArchivos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkArchivos.OcxState")));
        this.chkArchivos.Size = new System.Drawing.Size(106, 12);
        this.chkArchivos.TabIndex = 15;
        this.chkArchivos.Tag = "";
        this.chkArchivos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkArchivos_ClickEvent);
        // 
        // chkEmpresas
        // 
        this.chkEmpresas.Location = new System.Drawing.Point(15, 43);
        this.chkEmpresas.Name = "chkEmpresas";
        this.chkEmpresas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEmpresas.OcxState")));
        this.chkEmpresas.Size = new System.Drawing.Size(106, 12);
        this.chkEmpresas.TabIndex = 17;
        this.chkEmpresas.Tag = "";
        this.chkEmpresas.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEmpresas_ClickEvent);
        // 
        // chkEjecutivos
        // 
        this.chkEjecutivos.Location = new System.Drawing.Point(15, 108);
        this.chkEjecutivos.Name = "chkEjecutivos";
        this.chkEjecutivos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEjecutivos.OcxState")));
        this.chkEjecutivos.Size = new System.Drawing.Size(152, 12);
        this.chkEjecutivos.TabIndex = 19;
        this.chkEjecutivos.Tag = "";
        this.chkEjecutivos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEjecutivos_ClickEvent);
        // 
        // chkTarjetahabientes
        // 
        this.chkTarjetahabientes.Location = new System.Drawing.Point(15, 95);
        this.chkTarjetahabientes.Name = "chkTarjetahabientes";
        this.chkTarjetahabientes.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkTarjetahabientes.OcxState")));
        this.chkTarjetahabientes.Size = new System.Drawing.Size(160, 12);
        this.chkTarjetahabientes.TabIndex = 18;
        this.chkTarjetahabientes.Tag = "";
        this.chkTarjetahabientes.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkTarjetahabientes_ClickEvent);
        // 
        // chk_altas_masivas
        // 
        this.chk_altas_masivas.Location = new System.Drawing.Point(15, 158);
        this.chk_altas_masivas.Name = "chk_altas_masivas";
        this.chk_altas_masivas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chk_altas_masivas.OcxState")));
        this.chk_altas_masivas.Size = new System.Drawing.Size(118, 14);
        this.chk_altas_masivas.TabIndex = 66;
        this.chk_altas_masivas.Tag = "";
        this.chk_altas_masivas.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chk_altas_masivas_ClickEvent);
        // 
        // chkEnvioLimCred
        // 
        this.chkEnvioLimCred.Location = new System.Drawing.Point(15, 171);
        this.chkEnvioLimCred.Name = "chkEnvioLimCred";
        this.chkEnvioLimCred.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEnvioLimCred.OcxState")));
        this.chkEnvioLimCred.Size = new System.Drawing.Size(137, 17);
        this.chkEnvioLimCred.TabIndex = 68;
        this.chkEnvioLimCred.Tag = "";
        this.chkEnvioLimCred.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEnvioLimCred_ClickEvent);
        // 
        // chk_Reportes
        // 
        this.chk_Reportes.Location = new System.Drawing.Point(15, 68);
        this.chk_Reportes.Name = "chk_Reportes";
        this.chk_Reportes.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chk_Reportes.OcxState")));
        this.chk_Reportes.Size = new System.Drawing.Size(92, 13);
        this.chk_Reportes.TabIndex = 64;
        this.chk_Reportes.Tag = "";
        this.chk_Reportes.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chk_Reportes_ClickEvent);
        // 
        // chk_categorias
        // 
        this.chk_categorias.Location = new System.Drawing.Point(15, 82);
        this.chk_categorias.Name = "chk_categorias";
        this.chk_categorias.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chk_categorias.OcxState")));
        this.chk_categorias.Size = new System.Drawing.Size(74, 13);
        this.chk_categorias.TabIndex = 65;
        this.chk_categorias.Tag = "";
        this.chk_categorias.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chk_categorias_ClickEvent);
        // 
        // pnlInterfaces
        // 
        this.pnlInterfaces.Controls.Add(this.chkDepuracion);
        this.pnlInterfaces.Controls.Add(this.chkTransmision);
        this.pnlInterfaces.Controls.Add(this.chkInterfaces);
        this.pnlInterfaces.Location = new System.Drawing.Point(17, 194);
        this.pnlInterfaces.Name = "pnlInterfaces";
        this.pnlInterfaces.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlInterfaces.OcxState")));
        this.pnlInterfaces.Size = new System.Drawing.Size(209, 32);
        this.pnlInterfaces.TabIndex = 57;
        this.pnlInterfaces.Tag = "";
        // 
        // chkDepuracion
        // 
        this.chkDepuracion.Location = new System.Drawing.Point(16, 44);
        this.chkDepuracion.Name = "chkDepuracion";
        this.chkDepuracion.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkDepuracion.OcxState")));
        this.chkDepuracion.Size = new System.Drawing.Size(147, 11);
        this.chkDepuracion.TabIndex = 14;
        this.chkDepuracion.Tag = "";
        this.chkDepuracion.Visible = false;
        this.chkDepuracion.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkDepuracion_ClickEvent);
        // 
        // chkTransmision
        // 
        this.chkTransmision.Location = new System.Drawing.Point(16, 16);
        this.chkTransmision.Name = "chkTransmision";
        this.chkTransmision.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkTransmision.OcxState")));
        this.chkTransmision.Size = new System.Drawing.Size(190, 11);
        this.chkTransmision.TabIndex = 13;
        this.chkTransmision.Tag = "";
        this.chkTransmision.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkTransmision_ClickEvent);
        // 
        // chkInterfaces
        // 
        this.chkInterfaces.Location = new System.Drawing.Point(4, 2);
        this.chkInterfaces.Name = "chkInterfaces";
        this.chkInterfaces.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkInterfaces.OcxState")));
        this.chkInterfaces.Size = new System.Drawing.Size(72, 11);
        this.chkInterfaces.TabIndex = 12;
        this.chkInterfaces.Tag = "";
        this.chkInterfaces.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkInterfaces_ClickEvent);
        // 
        // pnlAcceso
        // 
        this.pnlAcceso.Controls.Add(this._chkAccesoNivel_2);
        this.pnlAcceso.Controls.Add(this._chkAccesoNivel_3);
        this.pnlAcceso.Controls.Add(this._chkAccesoNivel_0);
        this.pnlAcceso.Controls.Add(this.pnlAccesoLabel_Text);
        this.pnlAcceso.Controls.Add(this._chkAccesoNivel_1);
        this.pnlAcceso.Location = new System.Drawing.Point(41, 420);
        this.pnlAcceso.Name = "pnlAcceso";
        this.pnlAcceso.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlAcceso.OcxState")));
        this.pnlAcceso.Size = new System.Drawing.Size(158, 59);
        this.pnlAcceso.TabIndex = 58;
        this.pnlAcceso.Tag = "";
        // 
        // _chkAccesoNivel_2
        // 
        this._chkAccesoNivel_2.Location = new System.Drawing.Point(74, 20);
        this._chkAccesoNivel_2.Name = "_chkAccesoNivel_2";
        this._chkAccesoNivel_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_chkAccesoNivel_2.OcxState")));
        this._chkAccesoNivel_2.Size = new System.Drawing.Size(76, 16);
        this._chkAccesoNivel_2.TabIndex = 48;
        this._chkAccesoNivel_2.Tag = "";
        this._chkAccesoNivel_2.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAccesoNivel_ClickEvent);
        // 
        // _chkAccesoNivel_3
        // 
        this._chkAccesoNivel_3.Location = new System.Drawing.Point(74, 35);
        this._chkAccesoNivel_3.Name = "_chkAccesoNivel_3";
        this._chkAccesoNivel_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_chkAccesoNivel_3.OcxState")));
        this._chkAccesoNivel_3.Size = new System.Drawing.Size(76, 16);
        this._chkAccesoNivel_3.TabIndex = 49;
        this._chkAccesoNivel_3.Tag = "";
        this._chkAccesoNivel_3.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAccesoNivel_ClickEvent);
        // 
        // _chkAccesoNivel_0
        // 
        this._chkAccesoNivel_0.Location = new System.Drawing.Point(9, 19);
        this._chkAccesoNivel_0.Name = "_chkAccesoNivel_0";
        this._chkAccesoNivel_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_chkAccesoNivel_0.OcxState")));
        this._chkAccesoNivel_0.Size = new System.Drawing.Size(54, 16);
        this._chkAccesoNivel_0.TabIndex = 46;
        this._chkAccesoNivel_0.Tag = "";
        this._chkAccesoNivel_0.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAccesoNivel_ClickEvent);
        // 
        // pnlAccesoLabel_Text
        // 
        this.pnlAccesoLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.pnlAccesoLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.pnlAccesoLabel_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this.pnlAccesoLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.pnlAccesoLabel_Text.Name = "pnlAccesoLabel_Text";
        this.pnlAccesoLabel_Text.Size = new System.Drawing.Size(158, 59);
        this.pnlAccesoLabel_Text.TabIndex = 50;
        this.pnlAccesoLabel_Text.Tag = "";
        this.pnlAccesoLabel_Text.Text = "Acceso del Nivel";
        this.pnlAccesoLabel_Text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // _chkAccesoNivel_1
        // 
        this._chkAccesoNivel_1.Location = new System.Drawing.Point(9, 35);
        this._chkAccesoNivel_1.Name = "_chkAccesoNivel_1";
        this._chkAccesoNivel_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_chkAccesoNivel_1.OcxState")));
        this._chkAccesoNivel_1.Size = new System.Drawing.Size(53, 16);
        this._chkAccesoNivel_1.TabIndex = 47;
        this._chkAccesoNivel_1.Tag = "";
        this._chkAccesoNivel_1.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAccesoNivel_ClickEvent);
        // 
        // pnlConsultas
        // 
        this.pnlConsultas.Controls.Add(this.chkCrystal);
        this.pnlConsultas.Controls.Add(this.chkRentabilidad);
        this.pnlConsultas.Controls.Add(this.chkEjeBanamex);
        this.pnlConsultas.Controls.Add(this.chkAfiliadas);
        this.pnlConsultas.Controls.Add(this.chkAntiguedad);
        this.pnlConsultas.Controls.Add(this.chkCreditos);
        this.pnlConsultas.Controls.Add(this.chkComparativos);
        this.pnlConsultas.Controls.Add(this.chkVencidos);
        this.pnlConsultas.Controls.Add(this.chkConcentrado);
        this.pnlConsultas.Controls.Add(this.chkEmpEje);
        this.pnlConsultas.Controls.Add(this.chkSBF);
        this.pnlConsultas.Controls.Add(this.chkConsultas);
        this.pnlConsultas.Controls.Add(this.chkDetalle);
        this.pnlConsultas.Controls.Add(this.chkAtrasos);
        this.pnlConsultas.Controls.Add(this.chkGpoEmp);
        this.pnlConsultas.Controls.Add(this.chkConsumos);
        this.pnlConsultas.Controls.Add(this.chkSituacion);
        this.pnlConsultas.Controls.Add(this.chkAclara);
        this.pnlConsultas.Controls.Add(this.chkEmulador);
        this.pnlConsultas.Controls.Add(this.chkOpciones);
        this.pnlConsultas.Controls.Add(this.chkEnvioRep);
        this.pnlConsultas.Controls.Add(this.chkEjeBnx);
        this.pnlConsultas.Controls.Add(this.chkEmp);
        this.pnlConsultas.Controls.Add(this.chkAclaraciones);
        this.pnlConsultas.Controls.Add(this.chkCorporo);
        this.pnlConsultas.Controls.Add(this.chkGraficas);
        this.pnlConsultas.Controls.Add(this.chkBitacora);
        this.pnlConsultas.Location = new System.Drawing.Point(234, 44);
        this.pnlConsultas.Name = "pnlConsultas";
        this.pnlConsultas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlConsultas.OcxState")));
        this.pnlConsultas.Size = new System.Drawing.Size(209, 376);
        this.pnlConsultas.TabIndex = 59;
        this.pnlConsultas.Tag = "";
        // 
        // chkCrystal
        // 
        this.chkCrystal.Location = new System.Drawing.Point(18, 125);
        this.chkCrystal.Name = "chkCrystal";
        this.chkCrystal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkCrystal.OcxState")));
        this.chkCrystal.Size = new System.Drawing.Size(104, 13);
        this.chkCrystal.TabIndex = 31;
        this.chkCrystal.Tag = "";
        this.chkCrystal.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkCrystal_ClickEvent);
        // 
        // chkRentabilidad
        // 
        this.chkRentabilidad.Location = new System.Drawing.Point(18, 170);
        this.chkRentabilidad.Name = "chkRentabilidad";
        this.chkRentabilidad.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkRentabilidad.OcxState")));
        this.chkRentabilidad.Size = new System.Drawing.Size(104, 13);
        this.chkRentabilidad.TabIndex = 32;
        this.chkRentabilidad.Tag = "";
        this.chkRentabilidad.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkRentabilidad_ClickEvent);
        // 
        // chkEjeBanamex
        // 
        this.chkEjeBanamex.Location = new System.Drawing.Point(31, 98);
        this.chkEjeBanamex.Name = "chkEjeBanamex";
        this.chkEjeBanamex.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEjeBanamex.OcxState")));
        this.chkEjeBanamex.Size = new System.Drawing.Size(149, 13);
        this.chkEjeBanamex.TabIndex = 29;
        this.chkEjeBanamex.Tag = "";
        this.chkEjeBanamex.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEjeBanamex_ClickEvent);
        // 
        // chkAfiliadas
        // 
        this.chkAfiliadas.Location = new System.Drawing.Point(31, 111);
        this.chkAfiliadas.Name = "chkAfiliadas";
        this.chkAfiliadas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkAfiliadas.OcxState")));
        this.chkAfiliadas.Size = new System.Drawing.Size(104, 13);
        this.chkAfiliadas.TabIndex = 30;
        this.chkAfiliadas.Tag = "";
        this.chkAfiliadas.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAfiliadas_ClickEvent);
        // 
        // chkAntiguedad
        // 
        this.chkAntiguedad.Location = new System.Drawing.Point(32, 282);
        this.chkAntiguedad.Name = "chkAntiguedad";
        this.chkAntiguedad.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkAntiguedad.OcxState")));
        this.chkAntiguedad.Size = new System.Drawing.Size(161, 12);
        this.chkAntiguedad.TabIndex = 40;
        this.chkAntiguedad.Tag = "";
        this.chkAntiguedad.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAntiguedad_ClickEvent);
        // 
        // chkCreditos
        // 
        this.chkCreditos.Location = new System.Drawing.Point(32, 270);
        this.chkCreditos.Name = "chkCreditos";
        this.chkCreditos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkCreditos.OcxState")));
        this.chkCreditos.Size = new System.Drawing.Size(107, 12);
        this.chkCreditos.TabIndex = 39;
        this.chkCreditos.Tag = "";
        this.chkCreditos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkCreditos_ClickEvent);
        // 
        // chkComparativos
        // 
        this.chkComparativos.Location = new System.Drawing.Point(32, 306);
        this.chkComparativos.Name = "chkComparativos";
        this.chkComparativos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkComparativos.OcxState")));
        this.chkComparativos.Size = new System.Drawing.Size(107, 12);
        this.chkComparativos.TabIndex = 42;
        this.chkComparativos.Tag = "";
        this.chkComparativos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkComparativos_ClickEvent);
        // 
        // chkVencidos
        // 
        this.chkVencidos.Location = new System.Drawing.Point(32, 294);
        this.chkVencidos.Name = "chkVencidos";
        this.chkVencidos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkVencidos.OcxState")));
        this.chkVencidos.Size = new System.Drawing.Size(107, 12);
        this.chkVencidos.TabIndex = 41;
        this.chkVencidos.Tag = "";
        this.chkVencidos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkVencidos_ClickEvent);
        // 
        // chkConcentrado
        // 
        this.chkConcentrado.Location = new System.Drawing.Point(18, 20);
        this.chkConcentrado.Name = "chkConcentrado";
        this.chkConcentrado.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkConcentrado.OcxState")));
        this.chkConcentrado.Size = new System.Drawing.Size(104, 13);
        this.chkConcentrado.TabIndex = 23;
        this.chkConcentrado.Tag = "";
        this.chkConcentrado.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkConcentrado_ClickEvent);
        // 
        // chkEmpEje
        // 
        this.chkEmpEje.Location = new System.Drawing.Point(31, 33);
        this.chkEmpEje.Name = "chkEmpEje";
        this.chkEmpEje.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEmpEje.OcxState")));
        this.chkEmpEje.Size = new System.Drawing.Size(157, 13);
        this.chkEmpEje.TabIndex = 24;
        this.chkEmpEje.Tag = "";
        this.chkEmpEje.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEmpEje_ClickEvent);
        // 
        // chkSBF
        // 
        this.chkSBF.Location = new System.Drawing.Point(18, 155);
        this.chkSBF.Name = "chkSBF";
        this.chkSBF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkSBF.OcxState")));
        this.chkSBF.Size = new System.Drawing.Size(65, 17);
        this.chkSBF.TabIndex = 70;
        this.chkSBF.Tag = "";
        this.chkSBF.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkSBF_ClickEvent);
        // 
        // chkConsultas
        // 
        this.chkConsultas.Location = new System.Drawing.Point(6, 6);
        this.chkConsultas.Name = "chkConsultas";
        this.chkConsultas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkConsultas.OcxState")));
        this.chkConsultas.Size = new System.Drawing.Size(104, 13);
        this.chkConsultas.TabIndex = 22;
        this.chkConsultas.Tag = "";
        this.chkConsultas.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkConsultas_ClickEvent);
        // 
        // chkDetalle
        // 
        this.chkDetalle.Location = new System.Drawing.Point(19, 72);
        this.chkDetalle.Name = "chkDetalle";
        this.chkDetalle.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkDetalle.OcxState")));
        this.chkDetalle.Size = new System.Drawing.Size(104, 13);
        this.chkDetalle.TabIndex = 27;
        this.chkDetalle.Tag = "";
        this.chkDetalle.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkDetalle_ClickEvent);
        // 
        // chkAtrasos
        // 
        this.chkAtrasos.Location = new System.Drawing.Point(31, 85);
        this.chkAtrasos.Name = "chkAtrasos";
        this.chkAtrasos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkAtrasos.OcxState")));
        this.chkAtrasos.Size = new System.Drawing.Size(158, 13);
        this.chkAtrasos.TabIndex = 28;
        this.chkAtrasos.Tag = "";
        this.chkAtrasos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAtrasos_ClickEvent);
        // 
        // chkGpoEmp
        // 
        this.chkGpoEmp.Location = new System.Drawing.Point(31, 46);
        this.chkGpoEmp.Name = "chkGpoEmp";
        this.chkGpoEmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkGpoEmp.OcxState")));
        this.chkGpoEmp.Size = new System.Drawing.Size(104, 13);
        this.chkGpoEmp.TabIndex = 25;
        this.chkGpoEmp.Tag = "";
        this.chkGpoEmp.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkGpoEmp_ClickEvent);
        // 
        // chkConsumos
        // 
        this.chkConsumos.Location = new System.Drawing.Point(19, 59);
        this.chkConsumos.Name = "chkConsumos";
        this.chkConsumos.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkConsumos.OcxState")));
        this.chkConsumos.Size = new System.Drawing.Size(145, 13);
        this.chkConsumos.TabIndex = 26;
        this.chkConsumos.Tag = "";
        this.chkConsumos.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkConsumos_ClickEvent);
        // 
        // chkSituacion
        // 
        this.chkSituacion.Location = new System.Drawing.Point(32, 258);
        this.chkSituacion.Name = "chkSituacion";
        this.chkSituacion.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkSituacion.OcxState")));
        this.chkSituacion.Size = new System.Drawing.Size(170, 12);
        this.chkSituacion.TabIndex = 38;
        this.chkSituacion.Tag = "";
        this.chkSituacion.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkSituacion_ClickEvent);
        // 
        // chkAclara
        // 
        this.chkAclara.Location = new System.Drawing.Point(21, 334);
        this.chkAclara.Name = "chkAclara";
        this.chkAclara.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkAclara.OcxState")));
        this.chkAclara.Size = new System.Drawing.Size(113, 14);
        this.chkAclara.TabIndex = 44;
        this.chkAclara.Tag = "";
        this.chkAclara.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAclara_ClickEvent);
        // 
        // chkEmulador
        // 
        this.chkEmulador.Location = new System.Drawing.Point(32, 350);
        this.chkEmulador.Name = "chkEmulador";
        this.chkEmulador.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEmulador.OcxState")));
        this.chkEmulador.Size = new System.Drawing.Size(113, 14);
        this.chkEmulador.TabIndex = 45;
        this.chkEmulador.Tag = "";
        this.chkEmulador.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEmulador_ClickEvent);
        // 
        // chkOpciones
        // 
        this.chkOpciones.Location = new System.Drawing.Point(20, 321);
        this.chkOpciones.Name = "chkOpciones";
        this.chkOpciones.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkOpciones.OcxState")));
        this.chkOpciones.Size = new System.Drawing.Size(113, 14);
        this.chkOpciones.TabIndex = 43;
        this.chkOpciones.Tag = "";
        this.chkOpciones.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkOpciones_ClickEvent);
        // 
        // chkEnvioRep
        // 
        this.chkEnvioRep.Location = new System.Drawing.Point(18, 139);
        this.chkEnvioRep.Name = "chkEnvioRep";
        this.chkEnvioRep.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEnvioRep.OcxState")));
        this.chkEnvioRep.Size = new System.Drawing.Size(137, 17);
        this.chkEnvioRep.TabIndex = 69;
        this.chkEnvioRep.Tag = "";
        this.chkEnvioRep.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEnvioRep_ClickEvent);
        // 
        // chkEjeBnx
        // 
        this.chkEjeBnx.Location = new System.Drawing.Point(18, 184);
        this.chkEjeBnx.Name = "chkEjeBnx";
        this.chkEjeBnx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEjeBnx.OcxState")));
        this.chkEjeBnx.Size = new System.Drawing.Size(157, 13);
        this.chkEjeBnx.TabIndex = 60;
        this.chkEjeBnx.Tag = "";
        this.chkEjeBnx.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEjeBnx_ClickEvent);
        // 
        // chkEmp
        // 
        this.chkEmp.Location = new System.Drawing.Point(32, 234);
        this.chkEmp.Name = "chkEmp";
        this.chkEmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkEmp.OcxState")));
        this.chkEmp.Size = new System.Drawing.Size(107, 12);
        this.chkEmp.TabIndex = 36;
        this.chkEmp.Tag = "";
        this.chkEmp.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkEmp_ClickEvent);
        // 
        // chkAclaraciones
        // 
        this.chkAclaraciones.Location = new System.Drawing.Point(32, 246);
        this.chkAclaraciones.Name = "chkAclaraciones";
        this.chkAclaraciones.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkAclaraciones.OcxState")));
        this.chkAclaraciones.Size = new System.Drawing.Size(107, 12);
        this.chkAclaraciones.TabIndex = 37;
        this.chkAclaraciones.Tag = "";
        this.chkAclaraciones.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkAclaraciones_ClickEvent);
        // 
        // chkCorporo
        // 
        this.chkCorporo.Location = new System.Drawing.Point(32, 222);
        this.chkCorporo.Name = "chkCorporo";
        this.chkCorporo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkCorporo.OcxState")));
        this.chkCorporo.Size = new System.Drawing.Size(107, 12);
        this.chkCorporo.TabIndex = 35;
        this.chkCorporo.Tag = "";
        this.chkCorporo.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkCorporo_ClickEvent);
        // 
        // chkGraficas
        // 
        this.chkGraficas.Location = new System.Drawing.Point(18, 197);
        this.chkGraficas.Name = "chkGraficas";
        this.chkGraficas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkGraficas.OcxState")));
        this.chkGraficas.Size = new System.Drawing.Size(110, 14);
        this.chkGraficas.TabIndex = 33;
        this.chkGraficas.Tag = "";
        this.chkGraficas.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkGraficas_ClickEvent);
        // 
        // chkBitacora
        // 
        this.chkBitacora.Location = new System.Drawing.Point(32, 210);
        this.chkBitacora.Name = "chkBitacora";
        this.chkBitacora.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("chkBitacora.OcxState")));
        this.chkBitacora.Size = new System.Drawing.Size(107, 12);
        this.chkBitacora.TabIndex = 34;
        this.chkBitacora.Tag = "";
        this.chkBitacora.ClickEvent += new AxThreed.ISSCBCtrlEvents_ClickEventHandler(this.chkBitacora_ClickEvent);
        // 
        // frmAcceso
        // 
        this.AcceptButton = this.cmdAceptar;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(487, 481);
        this.Controls.Add(this.cmbCancelar);
        this.Controls.Add(this.cmdAceptar);
        this.Controls.Add(this.pnlInterfaces);
        this.Controls.Add(this.pnlAcceso);
        this.Controls.Add(this.pnlConsultas);
        this.Controls.Add(this.pnlClave);
        this.Controls.Add(this.pnlGrupo);
        this.Controls.Add(this.pnlArchivos);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(289, 119);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmAcceso";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Acceso";
        this.Closed += new System.EventHandler(this.frmAcceso_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.pnlClave)).EndInit();
        this.pnlClave.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pnlGrupo)).EndInit();
        this.pnlGrupo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.chkLimCred)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCamMasivos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkUsuario)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkSeguridad)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkConfigurar)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkSalir)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkIntegracion)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkParametros)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkGrupo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_estatus_cdf)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkBanco)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlArchivos)).EndInit();
        this.pnlArchivos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.chkRegiones)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkDivisiones)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCCI)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_unidades)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_Estruct_Gastos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCorporativos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkArchivos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEmpresas)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEjecutivos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkTarjetahabientes)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_altas_masivas)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEnvioLimCred)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_Reportes)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chk_categorias)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlInterfaces)).EndInit();
        this.pnlInterfaces.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.chkDepuracion)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkTransmision)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkInterfaces)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlAcceso)).EndInit();
        this.pnlAcceso.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._chkAccesoNivel_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._chkAccesoNivel_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._chkAccesoNivel_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._chkAccesoNivel_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlConsultas)).EndInit();
        this.pnlConsultas.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.chkCrystal)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkRentabilidad)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEjeBanamex)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAfiliadas)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAntiguedad)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCreditos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkComparativos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkVencidos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkConcentrado)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEmpEje)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkSBF)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkConsultas)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkDetalle)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAtrasos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkGpoEmp)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkConsumos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkSituacion)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAclara)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEmulador)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkOpciones)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEnvioRep)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEjeBnx)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkEmp)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkAclaraciones)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkCorporo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkGraficas)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chkBitacora)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializechkAccesoNivel()
	{
			this.chkAccesoNivel[0] = _chkAccesoNivel_0;
			this.chkAccesoNivel[3] = _chkAccesoNivel_3;
			this.chkAccesoNivel[2] = _chkAccesoNivel_2;
			this.chkAccesoNivel[1] = _chkAccesoNivel_1;
	}
#endregion 
}
}