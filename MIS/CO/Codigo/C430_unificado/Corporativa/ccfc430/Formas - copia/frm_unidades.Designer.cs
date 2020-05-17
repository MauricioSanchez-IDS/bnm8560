using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frm_unidades
	{
	
#region "Upgrade Support "
		private static frm_unidades m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_unidades DefInstance
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
		public frm_unidades():base(){
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
			InitializecmbCombo();
			InitializelblEtiqueta();
			InitializefrmFrame();
			InitializetxtTexto();
			InitializemkbMaskebox();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frm_unidades CreateInstance()
	{
			frm_unidades theInstance = new frm_unidades();
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
	private  System.Windows.Forms.TextBox _txtTexto_3;
	private  System.Windows.Forms.ComboBox _cmbCombo_0;
	private  System.Windows.Forms.TextBox _txtTexto_2;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_2;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_9;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_11;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_12;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_13;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_15;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_16;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_3;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_4;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_5;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_6;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_7;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_8;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_10;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_0;
	private  System.Windows.Forms.Label _lblEtiqueta_4;
	private  System.Windows.Forms.Label _lblEtiqueta_2;
	private  System.Windows.Forms.Label _lblEtiqueta_3;
	private  System.Windows.Forms.Label _lblEtiqueta_5;
	private  System.Windows.Forms.Label _lblEtiqueta_6;
	private  System.Windows.Forms.Label _lblEtiqueta_7;
	private  System.Windows.Forms.Label _lblEtiqueta_8;
	private  System.Windows.Forms.Label _lblEtiqueta_9;
	private  System.Windows.Forms.Label _lblEtiqueta_10;
	private  System.Windows.Forms.Label _lblEtiqueta_11;
	private  System.Windows.Forms.Label _lblEtiqueta_12;
	private  System.Windows.Forms.Label _lblEtiqueta_13;
	private  System.Windows.Forms.Label _lblEtiqueta_14;
	private  System.Windows.Forms.Label _lblEtiqueta_15;
	private  System.Windows.Forms.Label _lblEtiqueta_16;
	private  System.Windows.Forms.Label _lblEtiqueta_17;
	private  System.Windows.Forms.Label _lblEtiqueta_18;
	private  System.Windows.Forms.Label _lblEtiqueta_19;
	private  System.Windows.Forms.Label _lblEtiqueta_20;
	private  AxThreed.AxSSFrame _frmFrame_1;
	private  System.Windows.Forms.TextBox _txtTexto_0;
	private  System.Windows.Forms.TextBox _txtTexto_1;
	private  System.Windows.Forms.Label _lblEtiqueta_1;
	private  System.Windows.Forms.Label _lblEtiqueta_0;
	private  AxThreed.AxSSFrame _frmFrame_0;
	public  System.Windows.Forms.Button ID_MEE_CER_PB;
	public  System.Windows.Forms.Button ID_MEE_ALT_PB;
	private  System.Windows.Forms.TabPage _TabUni_TabPage0;
	private  System.Windows.Forms.Label _lblEtiqueta_22;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_17;
	public  System.Windows.Forms.ListBox lstUniRpr;
	private  System.Windows.Forms.GroupBox _frmFrame_2;
	public  System.Windows.Forms.Button cmd_agregar;
	public  System.Windows.Forms.Button cmd_quitar;
	private  System.Windows.Forms.TabPage _TabUni_TabPage1;
	public  System.Windows.Forms.TabControl TabUni;
	public System.Windows.Forms.ComboBox[] cmbCombo = new System.Windows.Forms.ComboBox[1];
	public AxThreed.AxSSFrame[] frmFrame = new AxThreed.AxSSFrame[3];
	public System.Windows.Forms.Label[] lblEtiqueta = new System.Windows.Forms.Label[23];
	public AxMSMask.AxMaskEdBox[] mkbMaskebox = new AxMSMask.AxMaskEdBox[18];
	public System.Windows.Forms.TextBox[] txtTexto = new System.Windows.Forms.TextBox[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_unidades));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.TabUni = new System.Windows.Forms.TabControl();
        this._TabUni_TabPage0 = new System.Windows.Forms.TabPage();
        this.ID_MEE_CER_PB = new System.Windows.Forms.Button();
        this.ID_MEE_ALT_PB = new System.Windows.Forms.Button();
        this._TabUni_TabPage1 = new System.Windows.Forms.TabPage();
        this._frmFrame_2 = new System.Windows.Forms.GroupBox();
        this.lstUniRpr = new System.Windows.Forms.ListBox();
        this.cmd_agregar = new System.Windows.Forms.Button();
        this.cmd_quitar = new System.Windows.Forms.Button();
        this._lblEtiqueta_22 = new System.Windows.Forms.Label();
        this._frmFrame_0 = new AxThreed.AxSSFrame();
        this._txtTexto_1 = new System.Windows.Forms.TextBox();
        this._txtTexto_0 = new System.Windows.Forms.TextBox();
        this._lblEtiqueta_0 = new System.Windows.Forms.Label();
        this._lblEtiqueta_1 = new System.Windows.Forms.Label();
        this._frmFrame_1 = new AxThreed.AxSSFrame();
        this._lblEtiqueta_6 = new System.Windows.Forms.Label();
        this._lblEtiqueta_5 = new System.Windows.Forms.Label();
        this._lblEtiqueta_7 = new System.Windows.Forms.Label();
        this._lblEtiqueta_9 = new System.Windows.Forms.Label();
        this._lblEtiqueta_8 = new System.Windows.Forms.Label();
        this._lblEtiqueta_3 = new System.Windows.Forms.Label();
        this._mkbMaskebox_10 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_8 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_0 = new AxMSMask.AxMaskEdBox();
        this._lblEtiqueta_2 = new System.Windows.Forms.Label();
        this._lblEtiqueta_4 = new System.Windows.Forms.Label();
        this._lblEtiqueta_17 = new System.Windows.Forms.Label();
        this._lblEtiqueta_16 = new System.Windows.Forms.Label();
        this._lblEtiqueta_18 = new System.Windows.Forms.Label();
        this._lblEtiqueta_20 = new System.Windows.Forms.Label();
        this._lblEtiqueta_19 = new System.Windows.Forms.Label();
        this._lblEtiqueta_15 = new System.Windows.Forms.Label();
        this._lblEtiqueta_11 = new System.Windows.Forms.Label();
        this._lblEtiqueta_10 = new System.Windows.Forms.Label();
        this._lblEtiqueta_12 = new System.Windows.Forms.Label();
        this._lblEtiqueta_14 = new System.Windows.Forms.Label();
        this._lblEtiqueta_13 = new System.Windows.Forms.Label();
        this._mkbMaskebox_9 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_2 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_12 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_11 = new AxMSMask.AxMaskEdBox();
        this._cmbCombo_0 = new System.Windows.Forms.ComboBox();
        this._txtTexto_3 = new System.Windows.Forms.TextBox();
        this._mkbMaskebox_1 = new AxMSMask.AxMaskEdBox();
        this._txtTexto_2 = new System.Windows.Forms.TextBox();
        this._mkbMaskebox_5 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_4 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_7 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_6 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_15 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_13 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_3 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_16 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_17 = new AxMSMask.AxMaskEdBox();
        this.TabUni.SuspendLayout();
        this._TabUni_TabPage0.SuspendLayout();
        this._TabUni_TabPage1.SuspendLayout();
        this._frmFrame_2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_0)).BeginInit();
        this._frmFrame_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_1)).BeginInit();
        this._frmFrame_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_17)).BeginInit();
        this.SuspendLayout();
        // 
        // TabUni
        // 
        this.TabUni.Controls.Add(this._TabUni_TabPage0);
        this.TabUni.Controls.Add(this._TabUni_TabPage1);
        this.TabUni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TabUni.ItemSize = new System.Drawing.Size(316, 18);
        this.TabUni.Location = new System.Drawing.Point(0, 0);
        this.TabUni.Multiline = true;
        this.TabUni.Name = "TabUni";
        this.TabUni.SelectedIndex = 0;
        this.TabUni.Size = new System.Drawing.Size(639, 453);
        this.TabUni.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        this.TabUni.TabIndex = 25;
        this.TabUni.Tag = "";
        // 
        // _TabUni_TabPage0
        // 
        this._TabUni_TabPage0.Controls.Add(this._frmFrame_0);
        this._TabUni_TabPage0.Controls.Add(this.ID_MEE_CER_PB);
        this._TabUni_TabPage0.Controls.Add(this.ID_MEE_ALT_PB);
        this._TabUni_TabPage0.Controls.Add(this._frmFrame_1);
        this._TabUni_TabPage0.Location = new System.Drawing.Point(4, 22);
        this._TabUni_TabPage0.Name = "_TabUni_TabPage0";
        this._TabUni_TabPage0.Size = new System.Drawing.Size(631, 427);
        this._TabUni_TabPage0.TabIndex = 0;
        this._TabUni_TabPage0.Tag = "";
        this._TabUni_TabPage0.Text = "Datos Generales";
        // 
        // ID_MEE_CER_PB
        // 
        this.ID_MEE_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_MEE_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEE_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEE_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEE_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEE_CER_PB.Location = new System.Drawing.Point(360, 388);
        this.ID_MEE_CER_PB.Name = "ID_MEE_CER_PB";
        this.ID_MEE_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEE_CER_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_MEE_CER_PB.TabIndex = 24;
        this.ID_MEE_CER_PB.Tag = "Cancela";
        this.ID_MEE_CER_PB.Text = "Cancelar";
        this.ID_MEE_CER_PB.UseVisualStyleBackColor = false;
        this.ID_MEE_CER_PB.Click += new System.EventHandler(this.ID_MEE_CER_PB_Click);
        // 
        // ID_MEE_ALT_PB
        // 
        this.ID_MEE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_MEE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEE_ALT_PB.Location = new System.Drawing.Point(216, 388);
        this.ID_MEE_ALT_PB.Name = "ID_MEE_ALT_PB";
        this.ID_MEE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEE_ALT_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_MEE_ALT_PB.TabIndex = 23;
        this.ID_MEE_ALT_PB.Tag = "";
        this.ID_MEE_ALT_PB.Text = "Aceptar";
        this.ID_MEE_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_MEE_ALT_PB.Click += new System.EventHandler(this.ID_MEE_ALT_PB_Click);
        // 
        // _TabUni_TabPage1
        // 
        this._TabUni_TabPage1.Controls.Add(this._frmFrame_2);
        this._TabUni_TabPage1.Controls.Add(this.cmd_agregar);
        this._TabUni_TabPage1.Controls.Add(this.cmd_quitar);
        this._TabUni_TabPage1.Controls.Add(this._lblEtiqueta_22);
        this._TabUni_TabPage1.Controls.Add(this._mkbMaskebox_17);
        this._TabUni_TabPage1.Location = new System.Drawing.Point(4, 22);
        this._TabUni_TabPage1.Name = "_TabUni_TabPage1";
        this._TabUni_TabPage1.Size = new System.Drawing.Size(631, 427);
        this._TabUni_TabPage1.TabIndex = 1;
        this._TabUni_TabPage1.Tag = "";
        this._TabUni_TabPage1.Text = "Representantes Bancanet";
        // 
        // _frmFrame_2
        // 
        this._frmFrame_2.Controls.Add(this.lstUniRpr);
        this._frmFrame_2.Location = new System.Drawing.Point(352, 44);
        this._frmFrame_2.Name = "_frmFrame_2";
        this._frmFrame_2.Size = new System.Drawing.Size(193, 345);
        this._frmFrame_2.TabIndex = 26;
        this._frmFrame_2.TabStop = false;
        this._frmFrame_2.Tag = "";
        this._frmFrame_2.Text = "Representantes Bancanet";
        // 
        // lstUniRpr
        // 
        this.lstUniRpr.BackColor = System.Drawing.SystemColors.Window;
        this.lstUniRpr.Cursor = System.Windows.Forms.Cursors.Default;
        this.lstUniRpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lstUniRpr.ForeColor = System.Drawing.SystemColors.WindowText;
        this.lstUniRpr.Location = new System.Drawing.Point(16, 24);
        this.lstUniRpr.Name = "lstUniRpr";
        this.lstUniRpr.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lstUniRpr.Size = new System.Drawing.Size(161, 303);
        this.lstUniRpr.TabIndex = 22;
        this.lstUniRpr.Tag = "";
        this.lstUniRpr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstUniRpr_KeyDown);
        // 
        // cmd_agregar
        // 
        this.cmd_agregar.BackColor = System.Drawing.SystemColors.Control;
        this.cmd_agregar.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmd_agregar.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmd_agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmd_agregar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmd_agregar.Location = new System.Drawing.Point(208, 108);
        this.cmd_agregar.Name = "cmd_agregar";
        this.cmd_agregar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmd_agregar.Size = new System.Drawing.Size(74, 22);
        this.cmd_agregar.TabIndex = 51;
        this.cmd_agregar.Tag = "";
        this.cmd_agregar.Text = "Agregar";
        this.cmd_agregar.UseVisualStyleBackColor = false;
        this.cmd_agregar.Click += new System.EventHandler(this.cmd_agregar_Click);
        // 
        // cmd_quitar
        // 
        this.cmd_quitar.BackColor = System.Drawing.SystemColors.Control;
        this.cmd_quitar.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmd_quitar.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmd_quitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmd_quitar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmd_quitar.Location = new System.Drawing.Point(208, 148);
        this.cmd_quitar.Name = "cmd_quitar";
        this.cmd_quitar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmd_quitar.Size = new System.Drawing.Size(74, 22);
        this.cmd_quitar.TabIndex = 52;
        this.cmd_quitar.Tag = "";
        this.cmd_quitar.Text = "Quitar";
        this.cmd_quitar.UseVisualStyleBackColor = false;
        this.cmd_quitar.Click += new System.EventHandler(this.cmd_quitar_Click);
        // 
        // _lblEtiqueta_22
        // 
        this._lblEtiqueta_22.AutoSize = true;
        this._lblEtiqueta_22.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_22.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_22.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_22.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_22.Location = new System.Drawing.Point(32, 72);
        this._lblEtiqueta_22.Name = "_lblEtiqueta_22";
        this._lblEtiqueta_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_22.Size = new System.Drawing.Size(184, 13);
        this._lblEtiqueta_22.TabIndex = 50;
        this._lblEtiqueta_22.Tag = "";
        this._lblEtiqueta_22.Text = "Numero de Representante Bancanet:";
        // 
        // _frmFrame_0
        // 
        this._frmFrame_0.Controls.Add(this._txtTexto_1);
        this._frmFrame_0.Controls.Add(this._txtTexto_0);
        this._frmFrame_0.Controls.Add(this._lblEtiqueta_0);
        this._frmFrame_0.Controls.Add(this._lblEtiqueta_1);
        this._frmFrame_0.Location = new System.Drawing.Point(72, 20);
        this._frmFrame_0.Name = "_frmFrame_0";
        this._frmFrame_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_0.OcxState")));
        this._frmFrame_0.Size = new System.Drawing.Size(503, 47);
        this._frmFrame_0.TabIndex = 27;
        this._frmFrame_0.Tag = "";
        // 
        // _txtTexto_1
        // 
        this._txtTexto_1.AcceptsReturn = true;
        this._txtTexto_1.BackColor = System.Drawing.Color.White;
        this._txtTexto_1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_1.Location = new System.Drawing.Point(384, 17);
        this._txtTexto_1.MaxLength = 45;
        this._txtTexto_1.Name = "_txtTexto_1";
        this._txtTexto_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_1.Size = new System.Drawing.Size(105, 20);
        this._txtTexto_1.TabIndex = 1;
        this._txtTexto_1.TabStop = false;
        this._txtTexto_1.Tag = "";
        this._txtTexto_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        this._txtTexto_1.Validating += new System.ComponentModel.CancelEventHandler(this.txtTexto_Validating);
        // 
        // _txtTexto_0
        // 
        this._txtTexto_0.AcceptsReturn = true;
        this._txtTexto_0.BackColor = System.Drawing.Color.White;
        this._txtTexto_0.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_0.Location = new System.Drawing.Point(62, 17);
        this._txtTexto_0.MaxLength = 45;
        this._txtTexto_0.Name = "_txtTexto_0";
        this._txtTexto_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_0.Size = new System.Drawing.Size(267, 20);
        this._txtTexto_0.TabIndex = 0;
        this._txtTexto_0.TabStop = false;
        this._txtTexto_0.Tag = "";
        this._txtTexto_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        this._txtTexto_0.Validating += new System.ComponentModel.CancelEventHandler(this.txtTexto_Validating);
        // 
        // _lblEtiqueta_0
        // 
        this._lblEtiqueta_0.AutoSize = true;
        this._lblEtiqueta_0.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_0.Location = new System.Drawing.Point(17, 21);
        this._lblEtiqueta_0.Name = "_lblEtiqueta_0";
        this._lblEtiqueta_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_0.Size = new System.Drawing.Size(44, 13);
        this._lblEtiqueta_0.TabIndex = 28;
        this._lblEtiqueta_0.Tag = "";
        this._lblEtiqueta_0.Text = "N&ombre";
        // 
        // _lblEtiqueta_1
        // 
        this._lblEtiqueta_1.AutoSize = true;
        this._lblEtiqueta_1.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_1.Location = new System.Drawing.Point(335, 21);
        this._lblEtiqueta_1.Name = "_lblEtiqueta_1";
        this._lblEtiqueta_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_1.Size = new System.Drawing.Size(44, 13);
        this._lblEtiqueta_1.TabIndex = 29;
        this._lblEtiqueta_1.Tag = "";
        this._lblEtiqueta_1.Text = "&Número";
        // 
        // _frmFrame_1
        // 
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_6);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_5);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_7);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_9);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_8);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_3);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_10);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_8);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_0);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_2);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_4);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_17);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_16);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_18);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_20);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_19);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_15);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_11);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_10);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_12);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_14);
        this._frmFrame_1.Controls.Add(this._lblEtiqueta_13);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_9);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_2);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_12);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_11);
        this._frmFrame_1.Controls.Add(this._cmbCombo_0);
        this._frmFrame_1.Controls.Add(this._txtTexto_3);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_1);
        this._frmFrame_1.Controls.Add(this._txtTexto_2);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_5);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_4);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_7);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_6);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_15);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_13);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_3);
        this._frmFrame_1.Controls.Add(this._mkbMaskebox_16);
        this._frmFrame_1.Location = new System.Drawing.Point(24, 69);
        this._frmFrame_1.Name = "_frmFrame_1";
        this._frmFrame_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_1.OcxState")));
        this._frmFrame_1.Size = new System.Drawing.Size(595, 309);
        this._frmFrame_1.TabIndex = 30;
        this._frmFrame_1.Tag = "";
        // 
        // _lblEtiqueta_6
        // 
        this._lblEtiqueta_6.AutoSize = true;
        this._lblEtiqueta_6.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_6.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_6.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_6.Location = new System.Drawing.Point(6, 73);
        this._lblEtiqueta_6.Name = "_lblEtiqueta_6";
        this._lblEtiqueta_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_6.Size = new System.Drawing.Size(69, 13);
        this._lblEtiqueta_6.TabIndex = 45;
        this._lblEtiqueta_6.Tag = "";
        this._lblEtiqueta_6.Text = "Responsable";
        // 
        // _lblEtiqueta_5
        // 
        this._lblEtiqueta_5.AutoSize = true;
        this._lblEtiqueta_5.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_5.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_5.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_5.Location = new System.Drawing.Point(6, 47);
        this._lblEtiqueta_5.Name = "_lblEtiqueta_5";
        this._lblEtiqueta_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_5.Size = new System.Drawing.Size(44, 13);
        this._lblEtiqueta_5.TabIndex = 46;
        this._lblEtiqueta_5.Tag = "";
        this._lblEtiqueta_5.Text = "Nombre";
        // 
        // _lblEtiqueta_7
        // 
        this._lblEtiqueta_7.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_7.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_7.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_7.Location = new System.Drawing.Point(6, 99);
        this._lblEtiqueta_7.Name = "_lblEtiqueta_7";
        this._lblEtiqueta_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_7.Size = new System.Drawing.Size(123, 13);
        this._lblEtiqueta_7.TabIndex = 44;
        this._lblEtiqueta_7.Tag = "";
        this._lblEtiqueta_7.Text = "Domicilio (C&alle y Número)";
        // 
        // _lblEtiqueta_9
        // 
        this._lblEtiqueta_9.AutoSize = true;
        this._lblEtiqueta_9.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_9.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_9.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_9.Location = new System.Drawing.Point(6, 151);
        this._lblEtiqueta_9.Name = "_lblEtiqueta_9";
        this._lblEtiqueta_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_9.Size = new System.Drawing.Size(82, 13);
        this._lblEtiqueta_9.TabIndex = 42;
        this._lblEtiqueta_9.Tag = "";
        this._lblEtiqueta_9.Text = "&Pob./Del./Mun.";
        // 
        // _lblEtiqueta_8
        // 
        this._lblEtiqueta_8.AutoSize = true;
        this._lblEtiqueta_8.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_8.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_8.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_8.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_8.Location = new System.Drawing.Point(6, 125);
        this._lblEtiqueta_8.Name = "_lblEtiqueta_8";
        this._lblEtiqueta_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_8.Size = new System.Drawing.Size(42, 13);
        this._lblEtiqueta_8.TabIndex = 43;
        this._lblEtiqueta_8.Tag = "";
        this._lblEtiqueta_8.Text = "Co&lonia";
        // 
        // _lblEtiqueta_3
        // 
        this._lblEtiqueta_3.AutoSize = true;
        this._lblEtiqueta_3.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_3.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_3.Location = new System.Drawing.Point(280, 22);
        this._lblEtiqueta_3.Name = "_lblEtiqueta_3";
        this._lblEtiqueta_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_3.Size = new System.Drawing.Size(72, 13);
        this._lblEtiqueta_3.TabIndex = 47;
        this._lblEtiqueta_3.Tag = "";
        this._lblEtiqueta_3.Text = "Unidad Padre";
        // 
        // _mkbMaskebox_10
        // 
        this._mkbMaskebox_10.Location = new System.Drawing.Point(135, 225);
        this._mkbMaskebox_10.Name = "_mkbMaskebox_10";
        this._mkbMaskebox_10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_10.OcxState")));
        this._mkbMaskebox_10.Size = new System.Drawing.Size(57, 21);
        this._mkbMaskebox_10.TabIndex = 14;
        this._mkbMaskebox_10.Tag = "";
        this._mkbMaskebox_10.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_10.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_8
        // 
        this._mkbMaskebox_8.Location = new System.Drawing.Point(135, 173);
        this._mkbMaskebox_8.Name = "_mkbMaskebox_8";
        this._mkbMaskebox_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_8.OcxState")));
        this._mkbMaskebox_8.Size = new System.Drawing.Size(448, 21);
        this._mkbMaskebox_8.TabIndex = 10;
        this._mkbMaskebox_8.Tag = "";
        this._mkbMaskebox_8.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_8.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_0
        // 
        this._mkbMaskebox_0.Location = new System.Drawing.Point(135, 18);
        this._mkbMaskebox_0.Name = "_mkbMaskebox_0";
        this._mkbMaskebox_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_0.OcxState")));
        this._mkbMaskebox_0.Size = new System.Drawing.Size(140, 21);
        this._mkbMaskebox_0.TabIndex = 2;
        this._mkbMaskebox_0.Tag = "";
        this._mkbMaskebox_0.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _lblEtiqueta_2
        // 
        this._lblEtiqueta_2.AutoSize = true;
        this._lblEtiqueta_2.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_2.Location = new System.Drawing.Point(6, 22);
        this._lblEtiqueta_2.Name = "_lblEtiqueta_2";
        this._lblEtiqueta_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_2.Size = new System.Drawing.Size(41, 13);
        this._lblEtiqueta_2.TabIndex = 48;
        this._lblEtiqueta_2.Tag = "";
        this._lblEtiqueta_2.Text = "Unidad";
        // 
        // _lblEtiqueta_4
        // 
        this._lblEtiqueta_4.AutoSize = true;
        this._lblEtiqueta_4.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_4.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_4.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_4.Location = new System.Drawing.Point(495, 21);
        this._lblEtiqueta_4.Name = "_lblEtiqueta_4";
        this._lblEtiqueta_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_4.Size = new System.Drawing.Size(31, 13);
        this._lblEtiqueta_4.TabIndex = 49;
        this._lblEtiqueta_4.Tag = "";
        this._lblEtiqueta_4.Text = "Nivel";
        // 
        // _lblEtiqueta_17
        // 
        this._lblEtiqueta_17.AutoSize = true;
        this._lblEtiqueta_17.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_17.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_17.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_17.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_17.Location = new System.Drawing.Point(452, 229);
        this._lblEtiqueta_17.Name = "_lblEtiqueta_17";
        this._lblEtiqueta_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_17.Size = new System.Drawing.Size(39, 13);
        this._lblEtiqueta_17.TabIndex = 34;
        this._lblEtiqueta_17.Tag = "";
        this._lblEtiqueta_17.Text = "Celular";
        // 
        // _lblEtiqueta_16
        // 
        this._lblEtiqueta_16.AutoSize = true;
        this._lblEtiqueta_16.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_16.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_16.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_16.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_16.Location = new System.Drawing.Point(347, 228);
        this._lblEtiqueta_16.Name = "_lblEtiqueta_16";
        this._lblEtiqueta_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_16.Size = new System.Drawing.Size(24, 13);
        this._lblEtiqueta_16.TabIndex = 35;
        this._lblEtiqueta_16.Tag = "";
        this._lblEtiqueta_16.Text = "Fax";
        // 
        // _lblEtiqueta_18
        // 
        this._lblEtiqueta_18.AutoSize = true;
        this._lblEtiqueta_18.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_18.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_18.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_18.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_18.Location = new System.Drawing.Point(6, 257);
        this._lblEtiqueta_18.Name = "_lblEtiqueta_18";
        this._lblEtiqueta_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_18.Size = new System.Drawing.Size(34, 13);
        this._lblEtiqueta_18.TabIndex = 33;
        this._lblEtiqueta_18.Tag = "";
        this._lblEtiqueta_18.Text = "e-mail";
        // 
        // _lblEtiqueta_20
        // 
        this._lblEtiqueta_20.AutoSize = true;
        this._lblEtiqueta_20.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_20.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_20.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_20.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_20.Location = new System.Drawing.Point(340, 284);
        this._lblEtiqueta_20.Name = "_lblEtiqueta_20";
        this._lblEtiqueta_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_20.Size = new System.Drawing.Size(31, 13);
        this._lblEtiqueta_20.TabIndex = 31;
        this._lblEtiqueta_20.Tag = "";
        this._lblEtiqueta_20.Text = "Nivel";
        // 
        // _lblEtiqueta_19
        // 
        this._lblEtiqueta_19.AutoSize = true;
        this._lblEtiqueta_19.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_19.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_19.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_19.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_19.Location = new System.Drawing.Point(151, 285);
        this._lblEtiqueta_19.Name = "_lblEtiqueta_19";
        this._lblEtiqueta_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_19.Size = new System.Drawing.Size(89, 13);
        this._lblEtiqueta_19.TabIndex = 32;
        this._lblEtiqueta_19.Tag = "";
        this._lblEtiqueta_19.Text = "Copiar de Unidad";
        // 
        // _lblEtiqueta_15
        // 
        this._lblEtiqueta_15.AutoSize = true;
        this._lblEtiqueta_15.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_15.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_15.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_15.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_15.Location = new System.Drawing.Point(214, 229);
        this._lblEtiqueta_15.Name = "_lblEtiqueta_15";
        this._lblEtiqueta_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_15.Size = new System.Drawing.Size(53, 13);
        this._lblEtiqueta_15.TabIndex = 36;
        this._lblEtiqueta_15.Tag = "";
        this._lblEtiqueta_15.Text = "Extensión";
        // 
        // _lblEtiqueta_11
        // 
        this._lblEtiqueta_11.AutoSize = true;
        this._lblEtiqueta_11.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_11.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_11.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_11.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_11.Location = new System.Drawing.Point(6, 203);
        this._lblEtiqueta_11.Name = "_lblEtiqueta_11";
        this._lblEtiqueta_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_11.Size = new System.Drawing.Size(40, 13);
        this._lblEtiqueta_11.TabIndex = 40;
        this._lblEtiqueta_11.Tag = "";
        this._lblEtiqueta_11.Text = "Estado";
        // 
        // _lblEtiqueta_10
        // 
        this._lblEtiqueta_10.AutoSize = true;
        this._lblEtiqueta_10.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_10.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_10.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_10.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_10.Location = new System.Drawing.Point(6, 177);
        this._lblEtiqueta_10.Name = "_lblEtiqueta_10";
        this._lblEtiqueta_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_10.Size = new System.Drawing.Size(40, 13);
        this._lblEtiqueta_10.TabIndex = 41;
        this._lblEtiqueta_10.Tag = "";
        this._lblEtiqueta_10.Text = "Ciudad";
        // 
        // _lblEtiqueta_12
        // 
        this._lblEtiqueta_12.AutoSize = true;
        this._lblEtiqueta_12.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_12.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_12.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_12.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_12.Location = new System.Drawing.Point(313, 203);
        this._lblEtiqueta_12.Name = "_lblEtiqueta_12";
        this._lblEtiqueta_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_12.Size = new System.Drawing.Size(29, 13);
        this._lblEtiqueta_12.TabIndex = 39;
        this._lblEtiqueta_12.Tag = "";
        this._lblEtiqueta_12.Text = "País";
        // 
        // _lblEtiqueta_14
        // 
        this._lblEtiqueta_14.AutoSize = true;
        this._lblEtiqueta_14.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_14.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_14.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_14.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_14.Location = new System.Drawing.Point(6, 229);
        this._lblEtiqueta_14.Name = "_lblEtiqueta_14";
        this._lblEtiqueta_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_14.Size = new System.Drawing.Size(49, 13);
        this._lblEtiqueta_14.TabIndex = 37;
        this._lblEtiqueta_14.Tag = "";
        this._lblEtiqueta_14.Text = "Telefono";
        // 
        // _lblEtiqueta_13
        // 
        this._lblEtiqueta_13.AutoSize = true;
        this._lblEtiqueta_13.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_13.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_13.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_13.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_13.Location = new System.Drawing.Point(421, 203);
        this._lblEtiqueta_13.Name = "_lblEtiqueta_13";
        this._lblEtiqueta_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_13.Size = new System.Drawing.Size(72, 13);
        this._lblEtiqueta_13.TabIndex = 38;
        this._lblEtiqueta_13.Tag = "";
        this._lblEtiqueta_13.Text = "Codigo Postal";
        // 
        // _mkbMaskebox_9
        // 
        this._mkbMaskebox_9.Location = new System.Drawing.Point(494, 199);
        this._mkbMaskebox_9.Name = "_mkbMaskebox_9";
        this._mkbMaskebox_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_9.OcxState")));
        this._mkbMaskebox_9.Size = new System.Drawing.Size(89, 21);
        this._mkbMaskebox_9.TabIndex = 13;
        this._mkbMaskebox_9.Tag = "";
        this._mkbMaskebox_9.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_9.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_2
        // 
        this._mkbMaskebox_2.Location = new System.Drawing.Point(530, 17);
        this._mkbMaskebox_2.Name = "_mkbMaskebox_2";
        this._mkbMaskebox_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_2.OcxState")));
        this._mkbMaskebox_2.Size = new System.Drawing.Size(41, 21);
        this._mkbMaskebox_2.TabIndex = 4;
        this._mkbMaskebox_2.Tag = "";
        this._mkbMaskebox_2.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_12
        // 
        this._mkbMaskebox_12.Location = new System.Drawing.Point(372, 225);
        this._mkbMaskebox_12.Name = "_mkbMaskebox_12";
        this._mkbMaskebox_12.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_12.OcxState")));
        this._mkbMaskebox_12.Size = new System.Drawing.Size(57, 21);
        this._mkbMaskebox_12.TabIndex = 16;
        this._mkbMaskebox_12.Tag = "";
        this._mkbMaskebox_12.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_12.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_11
        // 
        this._mkbMaskebox_11.Location = new System.Drawing.Point(272, 224);
        this._mkbMaskebox_11.Name = "_mkbMaskebox_11";
        this._mkbMaskebox_11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_11.OcxState")));
        this._mkbMaskebox_11.Size = new System.Drawing.Size(57, 21);
        this._mkbMaskebox_11.TabIndex = 15;
        this._mkbMaskebox_11.Tag = "";
        this._mkbMaskebox_11.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_11.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _cmbCombo_0
        // 
        this._cmbCombo_0.BackColor = System.Drawing.SystemColors.Window;
        this._cmbCombo_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._cmbCombo_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this._cmbCombo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._cmbCombo_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._cmbCombo_0.Location = new System.Drawing.Point(135, 199);
        this._cmbCombo_0.Name = "_cmbCombo_0";
        this._cmbCombo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._cmbCombo_0.Size = new System.Drawing.Size(161, 21);
        this._cmbCombo_0.TabIndex = 11;
        this._cmbCombo_0.Tag = "";
        // 
        // _txtTexto_3
        // 
        this._txtTexto_3.AcceptsReturn = true;
        this._txtTexto_3.BackColor = System.Drawing.SystemColors.Window;
        this._txtTexto_3.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_3.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_3.Location = new System.Drawing.Point(135, 251);
        this._txtTexto_3.MaxLength = 50;
        this._txtTexto_3.Name = "_txtTexto_3";
        this._txtTexto_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_3.Size = new System.Drawing.Size(448, 20);
        this._txtTexto_3.TabIndex = 18;
        this._txtTexto_3.Tag = "";
        this._txtTexto_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        this._txtTexto_3.Validating += new System.ComponentModel.CancelEventHandler(this.txtTexto_Validating);
        // 
        // _mkbMaskebox_1
        // 
        this._mkbMaskebox_1.Location = new System.Drawing.Point(356, 18);
        this._mkbMaskebox_1.Name = "_mkbMaskebox_1";
        this._mkbMaskebox_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_1.OcxState")));
        this._mkbMaskebox_1.Size = new System.Drawing.Size(133, 21);
        this._mkbMaskebox_1.TabIndex = 3;
        this._mkbMaskebox_1.Tag = "";
        this._mkbMaskebox_1.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _txtTexto_2
        // 
        this._txtTexto_2.AcceptsReturn = true;
        this._txtTexto_2.BackColor = System.Drawing.Color.White;
        this._txtTexto_2.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_2.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_2.Location = new System.Drawing.Point(347, 199);
        this._txtTexto_2.MaxLength = 3;
        this._txtTexto_2.Name = "_txtTexto_2";
        this._txtTexto_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_2.Size = new System.Drawing.Size(73, 20);
        this._txtTexto_2.TabIndex = 12;
        this._txtTexto_2.Tag = "";
        this._txtTexto_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        this._txtTexto_2.Validating += new System.ComponentModel.CancelEventHandler(this.txtTexto_Validating);
        // 
        // _mkbMaskebox_5
        // 
        this._mkbMaskebox_5.Location = new System.Drawing.Point(135, 95);
        this._mkbMaskebox_5.Name = "_mkbMaskebox_5";
        this._mkbMaskebox_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_5.OcxState")));
        this._mkbMaskebox_5.Size = new System.Drawing.Size(448, 21);
        this._mkbMaskebox_5.TabIndex = 7;
        this._mkbMaskebox_5.Tag = "";
        this._mkbMaskebox_5.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_5.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_4
        // 
        this._mkbMaskebox_4.Location = new System.Drawing.Point(135, 69);
        this._mkbMaskebox_4.Name = "_mkbMaskebox_4";
        this._mkbMaskebox_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_4.OcxState")));
        this._mkbMaskebox_4.Size = new System.Drawing.Size(448, 21);
        this._mkbMaskebox_4.TabIndex = 6;
        this._mkbMaskebox_4.Tag = "";
        this._mkbMaskebox_4.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_4.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_7
        // 
        this._mkbMaskebox_7.Location = new System.Drawing.Point(135, 147);
        this._mkbMaskebox_7.Name = "_mkbMaskebox_7";
        this._mkbMaskebox_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_7.OcxState")));
        this._mkbMaskebox_7.Size = new System.Drawing.Size(448, 21);
        this._mkbMaskebox_7.TabIndex = 9;
        this._mkbMaskebox_7.Tag = "";
        this._mkbMaskebox_7.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_7.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_6
        // 
        this._mkbMaskebox_6.Location = new System.Drawing.Point(135, 121);
        this._mkbMaskebox_6.Name = "_mkbMaskebox_6";
        this._mkbMaskebox_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_6.OcxState")));
        this._mkbMaskebox_6.Size = new System.Drawing.Size(448, 21);
        this._mkbMaskebox_6.TabIndex = 8;
        this._mkbMaskebox_6.Tag = "";
        this._mkbMaskebox_6.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_6.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_15
        // 
        this._mkbMaskebox_15.Location = new System.Drawing.Point(246, 280);
        this._mkbMaskebox_15.Name = "_mkbMaskebox_15";
        this._mkbMaskebox_15.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_15.OcxState")));
        this._mkbMaskebox_15.Size = new System.Drawing.Size(89, 21);
        this._mkbMaskebox_15.TabIndex = 19;
        this._mkbMaskebox_15.Tag = "";
        this._mkbMaskebox_15.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_15.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_13
        // 
        this._mkbMaskebox_13.Location = new System.Drawing.Point(494, 225);
        this._mkbMaskebox_13.Name = "_mkbMaskebox_13";
        this._mkbMaskebox_13.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_13.OcxState")));
        this._mkbMaskebox_13.Size = new System.Drawing.Size(89, 21);
        this._mkbMaskebox_13.TabIndex = 17;
        this._mkbMaskebox_13.Tag = "";
        this._mkbMaskebox_13.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_13.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_3
        // 
        this._mkbMaskebox_3.Location = new System.Drawing.Point(135, 43);
        this._mkbMaskebox_3.Name = "_mkbMaskebox_3";
        this._mkbMaskebox_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_3.OcxState")));
        this._mkbMaskebox_3.Size = new System.Drawing.Size(448, 21);
        this._mkbMaskebox_3.TabIndex = 5;
        this._mkbMaskebox_3.Tag = "";
        this._mkbMaskebox_3.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_3.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_16
        // 
        this._mkbMaskebox_16.Location = new System.Drawing.Point(374, 280);
        this._mkbMaskebox_16.Name = "_mkbMaskebox_16";
        this._mkbMaskebox_16.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_16.OcxState")));
        this._mkbMaskebox_16.Size = new System.Drawing.Size(41, 21);
        this._mkbMaskebox_16.TabIndex = 20;
        this._mkbMaskebox_16.Tag = "";
        this._mkbMaskebox_16.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_16.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // _mkbMaskebox_17
        // 
        this._mkbMaskebox_17.Location = new System.Drawing.Point(216, 68);
        this._mkbMaskebox_17.Name = "_mkbMaskebox_17";
        this._mkbMaskebox_17.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_17.OcxState")));
        this._mkbMaskebox_17.Size = new System.Drawing.Size(57, 21);
        this._mkbMaskebox_17.TabIndex = 21;
        this._mkbMaskebox_17.Tag = "";
        this._mkbMaskebox_17.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
        this._mkbMaskebox_17.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_KeyPressEvent);
        // 
        // frm_unidades
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(635, 449);
        this.Controls.Add(this.TabUni);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(91, 72);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frm_unidades";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Mantenimiento Unidades";
        this.Closed += new System.EventHandler(this.frm_unidades_Closed);
        this.TabUni.ResumeLayout(false);
        this._TabUni_TabPage0.ResumeLayout(false);
        this._TabUni_TabPage1.ResumeLayout(false);
        this._TabUni_TabPage1.PerformLayout();
        this._frmFrame_2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_0)).EndInit();
        this._frmFrame_0.ResumeLayout(false);
        this._frmFrame_0.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_1)).EndInit();
        this._frmFrame_1.ResumeLayout(false);
        this._frmFrame_1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_17)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializecmbCombo()
	{
			this.cmbCombo[0] = _cmbCombo_0;
	}
	void  InitializelblEtiqueta()
	{
			this.lblEtiqueta[1] = _lblEtiqueta_1;
			this.lblEtiqueta[0] = _lblEtiqueta_0;
			this.lblEtiqueta[4] = _lblEtiqueta_4;
			this.lblEtiqueta[2] = _lblEtiqueta_2;
			this.lblEtiqueta[3] = _lblEtiqueta_3;
			this.lblEtiqueta[5] = _lblEtiqueta_5;
			this.lblEtiqueta[6] = _lblEtiqueta_6;
			this.lblEtiqueta[7] = _lblEtiqueta_7;
			this.lblEtiqueta[8] = _lblEtiqueta_8;
			this.lblEtiqueta[9] = _lblEtiqueta_9;
			this.lblEtiqueta[10] = _lblEtiqueta_10;
			this.lblEtiqueta[11] = _lblEtiqueta_11;
			this.lblEtiqueta[12] = _lblEtiqueta_12;
			this.lblEtiqueta[13] = _lblEtiqueta_13;
			this.lblEtiqueta[14] = _lblEtiqueta_14;
			this.lblEtiqueta[15] = _lblEtiqueta_15;
			this.lblEtiqueta[16] = _lblEtiqueta_16;
			this.lblEtiqueta[17] = _lblEtiqueta_17;
			this.lblEtiqueta[18] = _lblEtiqueta_18;
			this.lblEtiqueta[19] = _lblEtiqueta_19;
			this.lblEtiqueta[20] = _lblEtiqueta_20;
			this.lblEtiqueta[22] = _lblEtiqueta_22;
	}
	void  InitializefrmFrame()
	{
            //this.frmFrame[2] = _frmFrame_2;
            //this.frmFrame[0] = _frmFrame_0;
            //this.frmFrame[1] = _frmFrame_1;
	}
	void  InitializetxtTexto()
	{
			this.txtTexto[0] = _txtTexto_0;
			this.txtTexto[1] = _txtTexto_1;
			this.txtTexto[3] = _txtTexto_3;
			this.txtTexto[2] = _txtTexto_2;
	}
	void  InitializemkbMaskebox()
	{
			this.mkbMaskebox[1] = _mkbMaskebox_1;
			this.mkbMaskebox[2] = _mkbMaskebox_2;
			this.mkbMaskebox[9] = _mkbMaskebox_9;
			this.mkbMaskebox[11] = _mkbMaskebox_11;
			this.mkbMaskebox[12] = _mkbMaskebox_12;
			this.mkbMaskebox[13] = _mkbMaskebox_13;
			this.mkbMaskebox[15] = _mkbMaskebox_15;
			this.mkbMaskebox[16] = _mkbMaskebox_16;
			this.mkbMaskebox[3] = _mkbMaskebox_3;
			this.mkbMaskebox[4] = _mkbMaskebox_4;
			this.mkbMaskebox[5] = _mkbMaskebox_5;
			this.mkbMaskebox[6] = _mkbMaskebox_6;
			this.mkbMaskebox[7] = _mkbMaskebox_7;
			this.mkbMaskebox[8] = _mkbMaskebox_8;
			this.mkbMaskebox[10] = _mkbMaskebox_10;
			this.mkbMaskebox[0] = _mkbMaskebox_0;
			this.mkbMaskebox[17] = _mkbMaskebox_17;
	}
#endregion 
}
}