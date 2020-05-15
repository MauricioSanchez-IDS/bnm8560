using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmCambiosMasivos
	{
	
#region "Upgrade Support "
		private static frmCambiosMasivos m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmCambiosMasivos DefInstance
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
		public frmCambiosMasivos():base(){
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			InitializeHelp();
			InitializeBtnProceso();
			InitializeCboEmpresas();
			InitializeOptTipoBloqueo();
			InitializeOptTipoCambio();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frmCambiosMasivos CreateInstance()
	{
			frmCambiosMasivos theInstance = new frmCambiosMasivos();
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
	public  System.Windows.Forms.Panel PanToolBar;
	public  System.Windows.Forms.CheckBox ChkValorAplicar;
	private  System.Windows.Forms.RadioButton _OptTipoCambio_0;
	private  System.Windows.Forms.RadioButton _OptTipoCambio_1;
	public  System.Windows.Forms.GroupBox Frame1;
	public  System.Windows.Forms.ComboBox CboValorModificar;
	private  System.Windows.Forms.ComboBox _CboEmpresas_0;
	private  System.Windows.Forms.ComboBox _CboEmpresas_1;        
        public System.Windows.Forms.OpenFileDialog CmdAbrirArchivo;
	private  System.Windows.Forms.RadioButton _OptTipoBloqueo_0;
	private  System.Windows.Forms.RadioButton _OptTipoBloqueo_1;
	private  System.Windows.Forms.RadioButton _OptTipoBloqueo_2;
	public  System.Windows.Forms.GroupBox FrmTipoBloqueo;
	public  System.Windows.Forms.Label Label1;
	public  System.Windows.Forms.Label LblPorcentaje;
	public  System.Windows.Forms.Label Label2;
	public  System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Button[] BtnProceso = new System.Windows.Forms.Button[2];
	public System.Windows.Forms.ComboBox[] CboEmpresas = new System.Windows.Forms.ComboBox[2];
	public System.Windows.Forms.RadioButton[] OptTipoBloqueo = new System.Windows.Forms.RadioButton[3];
	public System.Windows.Forms.RadioButton[] OptTipoCambio = new System.Windows.Forms.RadioButton[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiosMasivos));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this._BtnProceso_0 = new System.Windows.Forms.Button();
        this._BtnProceso_1 = new System.Windows.Forms.Button();
        this.PanToolBar = new System.Windows.Forms.Panel();
        this.ChkValorAplicar = new System.Windows.Forms.CheckBox();
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this._OptTipoCambio_0 = new System.Windows.Forms.RadioButton();
        this._OptTipoCambio_1 = new System.Windows.Forms.RadioButton();
        this.CboValorModificar = new System.Windows.Forms.ComboBox();
        this._CboEmpresas_0 = new System.Windows.Forms.ComboBox();
        this._CboEmpresas_1 = new System.Windows.Forms.ComboBox();
        this.CmdAbrirArchivo = new System.Windows.Forms.OpenFileDialog();        
        this.FrmTipoBloqueo = new System.Windows.Forms.GroupBox();
        this._OptTipoBloqueo_0 = new System.Windows.Forms.RadioButton();
        this._OptTipoBloqueo_2 = new System.Windows.Forms.RadioButton();
        this._OptTipoBloqueo_1 = new System.Windows.Forms.RadioButton();
        this.MskPorcentaje1 = new System.Windows.Forms.MaskedTextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.LblPorcentaje = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.PanToolBar.SuspendLayout();
        this.Frame1.SuspendLayout();        
        this.FrmTipoBloqueo.SuspendLayout();
        this.SuspendLayout();
        // 
        // _BtnProceso_0
        // 
        this._BtnProceso_0.BackColor = System.Drawing.SystemColors.Control;
        this._BtnProceso_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        this._BtnProceso_0.Image = global::C430_NET.Properties.Resources.icon5;
        this._BtnProceso_0.Location = new System.Drawing.Point(3, 1);
        this._BtnProceso_0.Name = "_BtnProceso_0";
        this._BtnProceso_0.Size = new System.Drawing.Size(44, 37);
        this._BtnProceso_0.TabIndex = 20;
        this.ToolTip1.SetToolTip(this._BtnProceso_0, "Aceptar");
        this._BtnProceso_0.UseVisualStyleBackColor = false;
        this._BtnProceso_0.Click += new System.EventHandler(this._BtnProceso_0_Click);
        // 
        // _BtnProceso_1
        // 
        this._BtnProceso_1.BackColor = System.Drawing.SystemColors.Control;
        this._BtnProceso_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        this._BtnProceso_1.Image = global::C430_NET.Properties.Resources.icon4;
        this._BtnProceso_1.Location = new System.Drawing.Point(47, 1);
        this._BtnProceso_1.Name = "_BtnProceso_1";
        this._BtnProceso_1.Size = new System.Drawing.Size(44, 37);
        this._BtnProceso_1.TabIndex = 19;
        this.ToolTip1.SetToolTip(this._BtnProceso_1, "Salir");
        this._BtnProceso_1.UseVisualStyleBackColor = false;
        this._BtnProceso_1.Click += new System.EventHandler(this._BtnProceso_1_Click);
        // 
        // PanToolBar
        // 
        this.PanToolBar.BackColor = System.Drawing.SystemColors.ActiveBorder;
        this.PanToolBar.Controls.Add(this._BtnProceso_0);
        this.PanToolBar.Controls.Add(this._BtnProceso_1);
        this.PanToolBar.Dock = System.Windows.Forms.DockStyle.Top;
        this.PanToolBar.Location = new System.Drawing.Point(0, 0);
        this.PanToolBar.Name = "PanToolBar";
        this.PanToolBar.Size = new System.Drawing.Size(448, 41);
        this.PanToolBar.TabIndex = 16;
        this.PanToolBar.Tag = "";
        // 
        // ChkValorAplicar
        // 
        this.ChkValorAplicar.BackColor = System.Drawing.SystemColors.Control;
        this.ChkValorAplicar.Cursor = System.Windows.Forms.Cursors.Default;
        this.ChkValorAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ChkValorAplicar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ChkValorAplicar.Location = new System.Drawing.Point(16, 272);
        this.ChkValorAplicar.Name = "ChkValorAplicar";
        this.ChkValorAplicar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ChkValorAplicar.Size = new System.Drawing.Size(123, 25);
        this.ChkValorAplicar.TabIndex = 11;
        this.ChkValorAplicar.Tag = "";
        this.ChkValorAplicar.Text = "Check1";
        this.ChkValorAplicar.UseVisualStyleBackColor = false;
        this.ChkValorAplicar.Visible = false;
        this.ChkValorAplicar.CheckStateChanged += new System.EventHandler(this.ChkValorAplicar_CheckStateChanged);
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this._OptTipoCambio_0);
        this.Frame1.Controls.Add(this._OptTipoCambio_1);
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(24, 48);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(361, 73);
        this.Frame1.TabIndex = 4;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Cambios Masivos";
        // 
        // _OptTipoCambio_0
        // 
        this._OptTipoCambio_0.BackColor = System.Drawing.SystemColors.Control;
        this._OptTipoCambio_0.Checked = true;
        this._OptTipoCambio_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._OptTipoCambio_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._OptTipoCambio_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._OptTipoCambio_0.Location = new System.Drawing.Point(16, 24);
        this._OptTipoCambio_0.Name = "_OptTipoCambio_0";
        this._OptTipoCambio_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._OptTipoCambio_0.Size = new System.Drawing.Size(321, 18);
        this._OptTipoCambio_0.TabIndex = 6;
        this._OptTipoCambio_0.TabStop = true;
        this._OptTipoCambio_0.Tag = "";
        this._OptTipoCambio_0.Text = "Aplicar a todas las cuentas de la empresa seleccionada";
        this._OptTipoCambio_0.UseVisualStyleBackColor = false;
        this._OptTipoCambio_0.CheckedChanged += new System.EventHandler(this.OptTipoCambio_CheckedChanged);
        // 
        // _OptTipoCambio_1
        // 
        this._OptTipoCambio_1.BackColor = System.Drawing.SystemColors.Control;
        this._OptTipoCambio_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._OptTipoCambio_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._OptTipoCambio_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._OptTipoCambio_1.Location = new System.Drawing.Point(16, 48);
        this._OptTipoCambio_1.Name = "_OptTipoCambio_1";
        this._OptTipoCambio_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._OptTipoCambio_1.Size = new System.Drawing.Size(337, 19);
        this._OptTipoCambio_1.TabIndex = 5;
        this._OptTipoCambio_1.TabStop = true;
        this._OptTipoCambio_1.Tag = "";
        this._OptTipoCambio_1.Text = "Aplicar a las cuentas listadas en un archivo";
        this._OptTipoCambio_1.UseVisualStyleBackColor = false;
        this._OptTipoCambio_1.CheckedChanged += new System.EventHandler(this.OptTipoCambio_CheckedChanged);
        // 
        // CboValorModificar
        // 
        this.CboValorModificar.BackColor = System.Drawing.SystemColors.Window;
        this.CboValorModificar.Cursor = System.Windows.Forms.Cursors.Default;
        this.CboValorModificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.CboValorModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CboValorModificar.ForeColor = System.Drawing.SystemColors.WindowText;
        this.CboValorModificar.Location = new System.Drawing.Point(136, 232);
        this.CboValorModificar.Name = "CboValorModificar";
        this.CboValorModificar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CboValorModificar.Size = new System.Drawing.Size(185, 21);
        this.CboValorModificar.TabIndex = 3;
        this.CboValorModificar.Tag = "";
        this.CboValorModificar.SelectedIndexChanged += new System.EventHandler(this.CboValorModificar_SelectedIndexChanged);
        // 
        // _CboEmpresas_0
        // 
        this._CboEmpresas_0.BackColor = System.Drawing.SystemColors.Window;
        this._CboEmpresas_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._CboEmpresas_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._CboEmpresas_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._CboEmpresas_0.Location = new System.Drawing.Point(24, 192);
        this._CboEmpresas_0.Name = "_CboEmpresas_0";
        this._CboEmpresas_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._CboEmpresas_0.Size = new System.Drawing.Size(297, 21);
        this._CboEmpresas_0.TabIndex = 1;
        this._CboEmpresas_0.Tag = "";
        this._CboEmpresas_0.SelectedIndexChanged += new System.EventHandler(this.CboEmpresas_SelectedIndexChanged);
        // 
        // _CboEmpresas_1
        // 
        this._CboEmpresas_1.BackColor = System.Drawing.SystemColors.Window;
        this._CboEmpresas_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._CboEmpresas_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._CboEmpresas_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this._CboEmpresas_1.Location = new System.Drawing.Point(24, 144);
        this._CboEmpresas_1.Name = "_CboEmpresas_1";
        this._CboEmpresas_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._CboEmpresas_1.Size = new System.Drawing.Size(297, 21);
        this._CboEmpresas_1.TabIndex = 0;
        this._CboEmpresas_1.Tag = "";
        this._CboEmpresas_1.SelectedIndexChanged += new System.EventHandler(this.CboEmpresas_SelectedIndexChanged);
      
        // 
        // FrmTipoBloqueo
        // 
        this.FrmTipoBloqueo.BackColor = System.Drawing.SystemColors.Control;
        this.FrmTipoBloqueo.Controls.Add(this._OptTipoBloqueo_0);
        this.FrmTipoBloqueo.Controls.Add(this._OptTipoBloqueo_2);
        this.FrmTipoBloqueo.Controls.Add(this._OptTipoBloqueo_1);
        this.FrmTipoBloqueo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FrmTipoBloqueo.ForeColor = System.Drawing.SystemColors.ControlText;
        this.FrmTipoBloqueo.Location = new System.Drawing.Point(16, 272);
        this.FrmTipoBloqueo.Name = "FrmTipoBloqueo";
        this.FrmTipoBloqueo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.FrmTipoBloqueo.Size = new System.Drawing.Size(305, 105);
        this.FrmTipoBloqueo.TabIndex = 7;
        this.FrmTipoBloqueo.TabStop = false;
        this.FrmTipoBloqueo.Tag = "";
        this.FrmTipoBloqueo.Text = "Tipo de bloqueo";
        this.FrmTipoBloqueo.Visible = false;
        // 
        // _OptTipoBloqueo_0
        // 
        this._OptTipoBloqueo_0.BackColor = System.Drawing.SystemColors.Control;
        this._OptTipoBloqueo_0.Checked = true;
        this._OptTipoBloqueo_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._OptTipoBloqueo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._OptTipoBloqueo_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._OptTipoBloqueo_0.Location = new System.Drawing.Point(8, 28);
        this._OptTipoBloqueo_0.Name = "_OptTipoBloqueo_0";
        this._OptTipoBloqueo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._OptTipoBloqueo_0.Size = new System.Drawing.Size(265, 21);
        this._OptTipoBloqueo_0.TabIndex = 10;
        this._OptTipoBloqueo_0.TabStop = true;
        this._OptTipoBloqueo_0.Tag = "";
        this._OptTipoBloqueo_0.Text = "No maneja bloqueo";
        this._OptTipoBloqueo_0.UseVisualStyleBackColor = false;
        this._OptTipoBloqueo_0.CheckedChanged += new System.EventHandler(this.OptTipoBloqueo_CheckedChanged);
        // 
        // _OptTipoBloqueo_2
        // 
        this._OptTipoBloqueo_2.BackColor = System.Drawing.SystemColors.Control;
        this._OptTipoBloqueo_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._OptTipoBloqueo_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._OptTipoBloqueo_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._OptTipoBloqueo_2.Location = new System.Drawing.Point(8, 72);
        this._OptTipoBloqueo_2.Name = "_OptTipoBloqueo_2";
        this._OptTipoBloqueo_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._OptTipoBloqueo_2.Size = new System.Drawing.Size(273, 17);
        this._OptTipoBloqueo_2.TabIndex = 8;
        this._OptTipoBloqueo_2.TabStop = true;
        this._OptTipoBloqueo_2.Tag = "";
        this._OptTipoBloqueo_2.Text = "Bloqueo por No. de Negocio";
        this._OptTipoBloqueo_2.UseVisualStyleBackColor = false;
        this._OptTipoBloqueo_2.CheckedChanged += new System.EventHandler(this.OptTipoBloqueo_CheckedChanged);
        // 
        // _OptTipoBloqueo_1
        // 
        this._OptTipoBloqueo_1.BackColor = System.Drawing.SystemColors.Control;
        this._OptTipoBloqueo_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._OptTipoBloqueo_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._OptTipoBloqueo_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._OptTipoBloqueo_1.Location = new System.Drawing.Point(8, 48);
        this._OptTipoBloqueo_1.Name = "_OptTipoBloqueo_1";
        this._OptTipoBloqueo_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._OptTipoBloqueo_1.Size = new System.Drawing.Size(265, 18);
        this._OptTipoBloqueo_1.TabIndex = 9;
        this._OptTipoBloqueo_1.TabStop = true;
        this._OptTipoBloqueo_1.Tag = "";
        this._OptTipoBloqueo_1.Text = "Bloqueo por MCC";
        this._OptTipoBloqueo_1.UseVisualStyleBackColor = false;
        this._OptTipoBloqueo_1.CheckedChanged += new System.EventHandler(this.OptTipoBloqueo_CheckedChanged);
        // 
        // MskPorcentaje1
        // 
        this.MskPorcentaje1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.MskPorcentaje1.Location = new System.Drawing.Point(231, 280);
        this.MskPorcentaje1.Mask = "99999";
        this.MskPorcentaje1.Name = "MskPorcentaje1";
        this.MskPorcentaje1.Size = new System.Drawing.Size(68, 20);
        this.MskPorcentaje1.TabIndex = 2;
        this.MskPorcentaje1.ValidatingType = typeof(int);
        this.MskPorcentaje1.Visible = false;
        this.MskPorcentaje1.Validating += new System.ComponentModel.CancelEventHandler(this.MskPorcentaje1_Validating);
        this.MskPorcentaje1.Enter += new System.EventHandler(this.MskPorcentaje1_Enter);
        // 
        // Label1
        // 
        this.Label1.BackColor = System.Drawing.SystemColors.Control;
        this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label1.Location = new System.Drawing.Point(24, 232);
        this.Label1.Name = "Label1";
        this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label1.Size = new System.Drawing.Size(105, 17);
        this.Label1.TabIndex = 15;
        this.Label1.Tag = "";
        this.Label1.Text = "Valor a Modificar";
        // 
        // LblPorcentaje
        // 
        this.LblPorcentaje.BackColor = System.Drawing.SystemColors.Control;
        this.LblPorcentaje.Cursor = System.Windows.Forms.Cursors.Default;
        this.LblPorcentaje.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.LblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.LblPorcentaje.ForeColor = System.Drawing.SystemColors.ControlText;
        this.LblPorcentaje.Location = new System.Drawing.Point(16, 272);
        this.LblPorcentaje.Name = "LblPorcentaje";
        this.LblPorcentaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LblPorcentaje.Size = new System.Drawing.Size(161, 17);
        this.LblPorcentaje.TabIndex = 14;
        this.LblPorcentaje.Tag = "";
        this.LblPorcentaje.Text = "Porcentaje a aplicar";
        this.LblPorcentaje.Visible = false;
        // 
        // Label2
        // 
        this.Label2.BackColor = System.Drawing.SystemColors.Control;
        this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label2.Location = new System.Drawing.Point(24, 168);
        this.Label2.Name = "Label2";
        this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label2.Size = new System.Drawing.Size(65, 17);
        this.Label2.TabIndex = 13;
        this.Label2.Tag = "";
        this.Label2.Text = "Empresa";
        // 
        // Label3
        // 
        this.Label3.BackColor = System.Drawing.SystemColors.Control;
        this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label3.Location = new System.Drawing.Point(24, 128);
        this.Label3.Name = "Label3";
        this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label3.Size = new System.Drawing.Size(81, 17);
        this.Label3.TabIndex = 12;
        this.Label3.Tag = "";
        this.Label3.Text = "Grupo";
        // 
        // frmCambiosMasivos
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(448, 389);
        this.Controls.Add(this._CboEmpresas_1);
        this.Controls.Add(this._CboEmpresas_0);
        this.Controls.Add(this.ChkValorAplicar);
        this.Controls.Add(this.PanToolBar);
        this.Controls.Add(this.CboValorModificar);
        this.Controls.Add(this.Frame1);        
        this.Controls.Add(this.LblPorcentaje);
        this.Controls.Add(this.MskPorcentaje1);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.FrmTipoBloqueo);
        this.Controls.Add(this.Label1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(345, 184);
        this.MaximizeBox = false;
        this.Name = "frmCambiosMasivos";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Cambios Masivos";
        this.Closed += new System.EventHandler(this.frmCambiosMasivos_Closed);
        this.Resize += new System.EventHandler(this.frmCambiosMasivos_Resize);
        this.PanToolBar.ResumeLayout(false);
        this.Frame1.ResumeLayout(false);        
        this.FrmTipoBloqueo.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	void  InitializeBtnProceso()
	{
			this.BtnProceso[1] = _BtnProceso_1;
			this.BtnProceso[0] = _BtnProceso_0;
	}
	void  InitializeCboEmpresas()
	{
			this.CboEmpresas[0] = _CboEmpresas_0;
			this.CboEmpresas[1] = _CboEmpresas_1;
	}
	void  InitializeOptTipoBloqueo()
	{
			this.OptTipoBloqueo[0] = _OptTipoBloqueo_0;
			this.OptTipoBloqueo[1] = _OptTipoBloqueo_1;
			this.OptTipoBloqueo[2] = _OptTipoBloqueo_2;
	}
	void  InitializeOptTipoCambio()
	{
			this.OptTipoCambio[0] = _OptTipoCambio_0;
			this.OptTipoCambio[1] = _OptTipoCambio_1;
	}
#endregion 

        private System.Windows.Forms.Button _BtnProceso_1;
        private System.Windows.Forms.Button _BtnProceso_0;
        public System.Windows.Forms.MaskedTextBox MskPorcentaje1;

}
}