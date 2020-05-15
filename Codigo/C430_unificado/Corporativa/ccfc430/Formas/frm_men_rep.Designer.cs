using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frm_men_rep
	{
	
#region "Upgrade Support "
		private static frm_men_rep m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_men_rep DefInstance
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
		public frm_men_rep():base(){
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
			InitializeOptReporte();
			InitializeID_CEE_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frm_men_rep CreateInstance()
	{
			frm_men_rep theInstance = new frm_men_rep();
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
	public  System.Windows.Forms.CheckBox ChkNivel;
	public  System.Windows.Forms.ComboBox CboNivel;
	private  System.Windows.Forms.RadioButton _OptReporte_2;
	private  System.Windows.Forms.RadioButton _OptReporte_1;
	private  System.Windows.Forms.RadioButton _OptReporte_0;
	public  System.Windows.Forms.GroupBox FrmTipoReporte;
	public  System.Windows.Forms.Button ID_CEE_CON_PB;
	public  System.Windows.Forms.Button ID_CEE_SAL_PB;
	public  System.Windows.Forms.Button ID_CEE_CAM_PB;
	public  System.Windows.Forms.ComboBox ID_CEE_GRU_COB;
	public  System.Windows.Forms.ComboBox ID_CEE_EMP_COB;
        public System.Windows.Forms.ComboBox ID_CEE_UNI_COB;
        private AxThreed.AxSSPanel _ID_CEE_ETI_PNL_1;
        private AxThreed.AxSSPanel _ID_CEE_ETI_PNL_0;
        private AxThreed.AxSSPanel _ID_CEE_ETI_PNL_2;
	private  AxThreed.AxSSPanel _ID_CEE_ETI_PNL_3;
	public AxThreed.AxSSPanel[] ID_CEE_ETI_PNL = new AxThreed.AxSSPanel[4];
	public System.Windows.Forms.RadioButton[] OptReporte = new System.Windows.Forms.RadioButton[3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_men_rep));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ChkNivel = new System.Windows.Forms.CheckBox();
        this.CboNivel = new System.Windows.Forms.ComboBox();
        this.FrmTipoReporte = new System.Windows.Forms.GroupBox();
        this._OptReporte_2 = new System.Windows.Forms.RadioButton();
        this._OptReporte_1 = new System.Windows.Forms.RadioButton();
        this._OptReporte_0 = new System.Windows.Forms.RadioButton();
        this.ID_CEE_CON_PB = new System.Windows.Forms.Button();
        this.ID_CEE_SAL_PB = new System.Windows.Forms.Button();
        this.ID_CEE_CAM_PB = new System.Windows.Forms.Button();
        this.ID_CEE_GRU_COB = new System.Windows.Forms.ComboBox();
        this.ID_CEE_EMP_COB = new System.Windows.Forms.ComboBox();
        this.ID_CEE_UNI_COB = new System.Windows.Forms.ComboBox();
        this._ID_CEE_ETI_PNL_1 = new AxThreed.AxSSPanel();
        this._ID_CEE_ETI_PNL_0 = new AxThreed.AxSSPanel();
        this._ID_CEE_ETI_PNL_2 = new AxThreed.AxSSPanel();
        this._ID_CEE_ETI_PNL_3 = new AxThreed.AxSSPanel();
        this.FrmTipoReporte.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_3)).BeginInit();
        this.SuspendLayout();
        // 
        // ChkNivel
        // 
        this.ChkNivel.BackColor = System.Drawing.SystemColors.Control;
        this.ChkNivel.Cursor = System.Windows.Forms.Cursors.Default;
        this.ChkNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ChkNivel.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ChkNivel.Location = new System.Drawing.Point(8, 200);
        this.ChkNivel.Name = "ChkNivel";
        this.ChkNivel.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ChkNivel.Size = new System.Drawing.Size(209, 17);
        this.ChkNivel.TabIndex = 8;
        this.ChkNivel.Tag = "";
        this.ChkNivel.Text = "Con Niveles";
        this.ChkNivel.UseVisualStyleBackColor = false;
        this.ChkNivel.CheckStateChanged += new System.EventHandler(this.ChkNivel_CheckStateChanged);
        // 
        // CboNivel
        // 
        this.CboNivel.BackColor = System.Drawing.SystemColors.Window;
        this.CboNivel.Cursor = System.Windows.Forms.Cursors.Default;
        this.CboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.CboNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CboNivel.ForeColor = System.Drawing.SystemColors.WindowText;
        this.CboNivel.Location = new System.Drawing.Point(352, 200);
        this.CboNivel.Name = "CboNivel";
        this.CboNivel.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CboNivel.Size = new System.Drawing.Size(73, 21);
        this.CboNivel.TabIndex = 10;
        this.CboNivel.Tag = "";
        // 
        // FrmTipoReporte
        // 
        this.FrmTipoReporte.BackColor = System.Drawing.SystemColors.Control;
        this.FrmTipoReporte.Controls.Add(this._OptReporte_2);
        this.FrmTipoReporte.Controls.Add(this._OptReporte_1);
        this.FrmTipoReporte.Controls.Add(this._OptReporte_0);
        this.FrmTipoReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FrmTipoReporte.ForeColor = System.Drawing.SystemColors.ControlText;
        this.FrmTipoReporte.Location = new System.Drawing.Point(8, 8);
        this.FrmTipoReporte.Name = "FrmTipoReporte";
        this.FrmTipoReporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.FrmTipoReporte.Size = new System.Drawing.Size(489, 113);
        this.FrmTipoReporte.TabIndex = 0;
        this.FrmTipoReporte.TabStop = false;
        this.FrmTipoReporte.Tag = "";
        this.FrmTipoReporte.Text = "Agrupar el reporte por :";
        // 
        // _OptReporte_2
        // 
        this._OptReporte_2.BackColor = System.Drawing.SystemColors.Control;
        this._OptReporte_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._OptReporte_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._OptReporte_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._OptReporte_2.Location = new System.Drawing.Point(20, 72);
        this._OptReporte_2.Name = "_OptReporte_2";
        this._OptReporte_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._OptReporte_2.Size = new System.Drawing.Size(233, 17);
        this._OptReporte_2.TabIndex = 3;
        this._OptReporte_2.TabStop = true;
        this._OptReporte_2.Tag = "";
        this._OptReporte_2.Text = "Grupo,Empresa, U&nidad";
        this._OptReporte_2.UseVisualStyleBackColor = false;
        this._OptReporte_2.CheckedChanged += new System.EventHandler(this.OptReporte_CheckedChanged);
        // 
        // _OptReporte_1
        // 
        this._OptReporte_1.BackColor = System.Drawing.SystemColors.Control;
        this._OptReporte_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._OptReporte_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._OptReporte_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._OptReporte_1.Location = new System.Drawing.Point(20, 48);
        this._OptReporte_1.Name = "_OptReporte_1";
        this._OptReporte_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._OptReporte_1.Size = new System.Drawing.Size(233, 17);
        this._OptReporte_1.TabIndex = 2;
        this._OptReporte_1.TabStop = true;
        this._OptReporte_1.Tag = "";
        this._OptReporte_1.Text = "Grupo, E&mpresa";
        this._OptReporte_1.UseVisualStyleBackColor = false;
        this._OptReporte_1.CheckedChanged += new System.EventHandler(this.OptReporte_CheckedChanged);
        // 
        // _OptReporte_0
        // 
        this._OptReporte_0.BackColor = System.Drawing.SystemColors.Control;
        this._OptReporte_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._OptReporte_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._OptReporte_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._OptReporte_0.Location = new System.Drawing.Point(20, 24);
        this._OptReporte_0.Name = "_OptReporte_0";
        this._OptReporte_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._OptReporte_0.Size = new System.Drawing.Size(233, 17);
        this._OptReporte_0.TabIndex = 1;
        this._OptReporte_0.TabStop = true;
        this._OptReporte_0.Tag = "";
        this._OptReporte_0.Text = "G&rupo";
        this._OptReporte_0.UseVisualStyleBackColor = false;
        this._OptReporte_0.CheckedChanged += new System.EventHandler(this.OptReporte_CheckedChanged);
        // 
        // ID_CEE_CON_PB
        // 
        this.ID_CEE_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_CON_PB.Location = new System.Drawing.Point(136, 264);
        this.ID_CEE_CON_PB.Name = "ID_CEE_CON_PB";
        this.ID_CEE_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_CON_PB.Size = new System.Drawing.Size(111, 23);
        this.ID_CEE_CON_PB.TabIndex = 15;
        this.ID_CEE_CON_PB.Tag = "";
        this.ID_CEE_CON_PB.Text = "C&onsultas...";
        this.ID_CEE_CON_PB.UseVisualStyleBackColor = false;
        this.ID_CEE_CON_PB.Click += new System.EventHandler(this.ID_CEE_CON_PB_Click);
        // 
        // ID_CEE_SAL_PB
        // 
        this.ID_CEE_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_CEE_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_SAL_PB.Location = new System.Drawing.Point(280, 264);
        this.ID_CEE_SAL_PB.Name = "ID_CEE_SAL_PB";
        this.ID_CEE_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_SAL_PB.Size = new System.Drawing.Size(111, 25);
        this.ID_CEE_SAL_PB.TabIndex = 14;
        this.ID_CEE_SAL_PB.Tag = "";
        this.ID_CEE_SAL_PB.Text = "&Salir";
        this.ID_CEE_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_CEE_SAL_PB.Click += new System.EventHandler(this.ID_CEE_SAL_PB_Click);
        // 
        // ID_CEE_CAM_PB
        // 
        this.ID_CEE_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_CAM_PB.Location = new System.Drawing.Point(8, 264);
        this.ID_CEE_CAM_PB.Name = "ID_CEE_CAM_PB";
        this.ID_CEE_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_CAM_PB.Size = new System.Drawing.Size(111, 25);
        this.ID_CEE_CAM_PB.TabIndex = 13;
        this.ID_CEE_CAM_PB.Tag = "";
        this.ID_CEE_CAM_PB.Text = "&Asignación";
        this.ID_CEE_CAM_PB.UseVisualStyleBackColor = false;
        this.ID_CEE_CAM_PB.Click += new System.EventHandler(this.ID_CEE_CAM_PB_Click);
        // 
        // ID_CEE_GRU_COB
        // 
        this.ID_CEE_GRU_COB.BackColor = System.Drawing.Color.White;
        this.ID_CEE_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEE_GRU_COB.Location = new System.Drawing.Point(86, 136);
        this.ID_CEE_GRU_COB.Name = "ID_CEE_GRU_COB";
        this.ID_CEE_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_GRU_COB.Size = new System.Drawing.Size(338, 21);
        this.ID_CEE_GRU_COB.Sorted = true;
        this.ID_CEE_GRU_COB.TabIndex = 5;
        this.ID_CEE_GRU_COB.Tag = "";
        this.ID_CEE_GRU_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEE_GRU_COB_SelectedIndexChanged);
        this.ID_CEE_GRU_COB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ComboBox_KeyPress);
        // 
        // ID_CEE_EMP_COB
        // 
        this.ID_CEE_EMP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CEE_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CEE_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEE_EMP_COB.Location = new System.Drawing.Point(87, 170);
        this.ID_CEE_EMP_COB.Name = "ID_CEE_EMP_COB";
        this.ID_CEE_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_EMP_COB.Size = new System.Drawing.Size(338, 21);
        this.ID_CEE_EMP_COB.Sorted = true;
        this.ID_CEE_EMP_COB.TabIndex = 7;
        this.ID_CEE_EMP_COB.Tag = "";
        this.ID_CEE_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEE_EMP_COB_SelectedIndexChanged);
        this.ID_CEE_EMP_COB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ComboBox_KeyPress);
        // 
        // ID_CEE_UNI_COB
        // 
        this.ID_CEE_UNI_COB.BackColor = System.Drawing.Color.White;
        this.ID_CEE_UNI_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_UNI_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CEE_UNI_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_UNI_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEE_UNI_COB.Location = new System.Drawing.Point(87, 228);
        this.ID_CEE_UNI_COB.Name = "ID_CEE_UNI_COB";
        this.ID_CEE_UNI_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_UNI_COB.Size = new System.Drawing.Size(339, 21);
        this.ID_CEE_UNI_COB.Sorted = true;
        this.ID_CEE_UNI_COB.TabIndex = 12;
        this.ID_CEE_UNI_COB.Tag = "";
        this.ID_CEE_UNI_COB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ComboBox_KeyPress);
        // 
        // _ID_CEE_ETI_PNL_1
        // 
        this._ID_CEE_ETI_PNL_1.Location = new System.Drawing.Point(8, 137);
        this._ID_CEE_ETI_PNL_1.Name = "_ID_CEE_ETI_PNL_1";
        this._ID_CEE_ETI_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_ETI_PNL_1.OcxState")));
        this._ID_CEE_ETI_PNL_1.Size = new System.Drawing.Size(75, 24);
        this._ID_CEE_ETI_PNL_1.TabIndex = 4;
        this._ID_CEE_ETI_PNL_1.Tag = "";
        // 
        // _ID_CEE_ETI_PNL_0
        // 
        this._ID_CEE_ETI_PNL_0.Location = new System.Drawing.Point(8, 170);
        this._ID_CEE_ETI_PNL_0.Name = "_ID_CEE_ETI_PNL_0";
        this._ID_CEE_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_ETI_PNL_0.OcxState")));
        this._ID_CEE_ETI_PNL_0.Size = new System.Drawing.Size(75, 24);
        this._ID_CEE_ETI_PNL_0.TabIndex = 6;
        this._ID_CEE_ETI_PNL_0.Tag = "";
        // 
        // _ID_CEE_ETI_PNL_2
        // 
        this._ID_CEE_ETI_PNL_2.Location = new System.Drawing.Point(8, 227);
        this._ID_CEE_ETI_PNL_2.Name = "_ID_CEE_ETI_PNL_2";
        this._ID_CEE_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_ETI_PNL_2.OcxState")));
        this._ID_CEE_ETI_PNL_2.Size = new System.Drawing.Size(75, 24);
        this._ID_CEE_ETI_PNL_2.TabIndex = 11;
        this._ID_CEE_ETI_PNL_2.Tag = "";
        // 
        // _ID_CEE_ETI_PNL_3
        // 
        this._ID_CEE_ETI_PNL_3.Location = new System.Drawing.Point(272, 200);
        this._ID_CEE_ETI_PNL_3.Name = "_ID_CEE_ETI_PNL_3";
        this._ID_CEE_ETI_PNL_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_ETI_PNL_3.OcxState")));
        this._ID_CEE_ETI_PNL_3.Size = new System.Drawing.Size(75, 24);
        this._ID_CEE_ETI_PNL_3.TabIndex = 9;
        this._ID_CEE_ETI_PNL_3.Tag = "";
        // 
        // frm_men_rep
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.ID_CEE_SAL_PB;
        this.ClientSize = new System.Drawing.Size(523, 302);
        this.Controls.Add(this.ID_CEE_SAL_PB);
        this.Controls.Add(this.CboNivel);
        this.Controls.Add(this.ChkNivel);
        this.Controls.Add(this.ID_CEE_CON_PB);
        this.Controls.Add(this.FrmTipoReporte);
        this.Controls.Add(this._ID_CEE_ETI_PNL_0);
        this.Controls.Add(this._ID_CEE_ETI_PNL_1);
        this.Controls.Add(this._ID_CEE_ETI_PNL_3);
        this.Controls.Add(this._ID_CEE_ETI_PNL_2);
        this.Controls.Add(this.ID_CEE_GRU_COB);
        this.Controls.Add(this.ID_CEE_CAM_PB);
        this.Controls.Add(this.ID_CEE_UNI_COB);
        this.Controls.Add(this.ID_CEE_EMP_COB);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(166, 542);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frm_men_rep";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Reportes";
        this.Closed += new System.EventHandler(this.frm_men_rep_Closed);
        this.FrmTipoReporte.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_3)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeOptReporte()
	{
			this.OptReporte[2] = _OptReporte_2;
			this.OptReporte[1] = _OptReporte_1;
			this.OptReporte[0] = _OptReporte_0;
	}
	void  InitializeID_CEE_ETI_PNL()
	{
			this.ID_CEE_ETI_PNL[1] = _ID_CEE_ETI_PNL_1;
			this.ID_CEE_ETI_PNL[0] = _ID_CEE_ETI_PNL_0;
			this.ID_CEE_ETI_PNL[2] = _ID_CEE_ETI_PNL_2;
			this.ID_CEE_ETI_PNL[3] = _ID_CEE_ETI_PNL_3;
	}
#endregion 
}
}