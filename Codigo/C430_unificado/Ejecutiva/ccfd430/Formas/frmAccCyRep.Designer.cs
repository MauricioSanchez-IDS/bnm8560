using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmAccCyRep
	{
	
#region "Upgrade Support "
		private static frmAccCyRep m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmAccCyRep DefInstance
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
		public frmAccCyRep():base(){
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
            InitializeComponent(); //AIS-1213 echasiquiza
			InitializeHelp();
			InitializecboCombo();
			InitializechkNivel();
			InitializeID_CEM_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static frmAccCyRep CreateInstance()
	{
			frmAccCyRep theInstance = new frmAccCyRep();
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
	public AxThreed.AxSSPanel[] ID_CEM_ETI_PNL = new AxThreed.AxSSPanel[8];
	public System.Windows.Forms.ComboBox[] cboCombo = new System.Windows.Forms.ComboBox[3];
	public System.Windows.Forms.CheckBox[] chkNivel = new System.Windows.Forms.CheckBox[3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccCyRep));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_CEM_PPL_PNL = new AxThreed.AxSSPanel();
        this.cmdGenerar = new System.Windows.Forms.Button();
        this.cmdSalir = new System.Windows.Forms.Button();
        this._ID_CEM_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_0 = new AxThreed.AxSSPanel();
        this.ID_CEM_GRP_COB = new System.Windows.Forms.ComboBox();
        this._ID_CEM_ETI_PNL_2Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_2 = new AxThreed.AxSSPanel();
        this._cboCombo_1 = new System.Windows.Forms.ComboBox();
        this._ID_CEM_ETI_PNL_3Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_3 = new AxThreed.AxSSPanel();
        this._cboCombo_2 = new System.Windows.Forms.ComboBox();
        this._ID_CEM_ETI_PNL_7Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_7 = new AxThreed.AxSSPanel();
        this._ID_CEM_ETI_PNL_1Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_1 = new AxThreed.AxSSPanel();
        this.ID_CEM_EMP_LB = new System.Windows.Forms.CheckedListBox();
        this._chkNivel_0 = new System.Windows.Forms.CheckBox();
        this._chkNivel_1 = new System.Windows.Forms.CheckBox();
        this._chkNivel_2 = new System.Windows.Forms.CheckBox();
        this.chkCuentaContable = new System.Windows.Forms.CheckBox();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_PPL_PNL)).BeginInit();
        this.ID_CEM_PPL_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_1)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_CEM_PPL_PNL
        // 
        this.ID_CEM_PPL_PNL.Controls.Add(this.cmdGenerar);
        this.ID_CEM_PPL_PNL.Controls.Add(this.cmdSalir);
        this.ID_CEM_PPL_PNL.Location = new System.Drawing.Point(1, 2);
        this.ID_CEM_PPL_PNL.Name = "ID_CEM_PPL_PNL";
        this.ID_CEM_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEM_PPL_PNL.OcxState")));
        this.ID_CEM_PPL_PNL.Size = new System.Drawing.Size(582, 351);
        this.ID_CEM_PPL_PNL.TabIndex = 13;
        this.ID_CEM_PPL_PNL.Tag = "";
        // 
        // cmdGenerar
        // 
        this.cmdGenerar.BackColor = System.Drawing.SystemColors.Control;
        this.cmdGenerar.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdGenerar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdGenerar.Location = new System.Drawing.Point(448, 22);
        this.cmdGenerar.Name = "cmdGenerar";
        this.cmdGenerar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdGenerar.Size = new System.Drawing.Size(114, 22);
        this.cmdGenerar.TabIndex = 14;
        this.cmdGenerar.Tag = "A";
        this.cmdGenerar.Text = "&Generar";
        this.cmdGenerar.UseVisualStyleBackColor = false;
        this.cmdGenerar.Click += new System.EventHandler(this.cmdGenerar_Click);
        // 
        // cmdSalir
        // 
        this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
        this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdSalir.Location = new System.Drawing.Point(449, 51);
        this.cmdSalir.Name = "cmdSalir";
        this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdSalir.Size = new System.Drawing.Size(114, 22);
        this.cmdSalir.TabIndex = 15;
        this.cmdSalir.Tag = "";
        this.cmdSalir.Text = "&Salir";
        this.cmdSalir.UseVisualStyleBackColor = false;
        this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
        // 
        // _ID_CEM_ETI_PNL_0Label_Text
        // 
        this._ID_CEM_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_0Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(18, 26);
        this._ID_CEM_ETI_PNL_0Label_Text.Name = "_ID_CEM_ETI_PNL_0Label_Text";
        this._ID_CEM_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(73, 21);
        this._ID_CEM_ETI_PNL_0Label_Text.TabIndex = 14;
        this._ID_CEM_ETI_PNL_0Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_0Label_Text.Text = " &Grupo";
        this._ID_CEM_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_CEM_ETI_PNL_0
        // 
        this._ID_CEM_ETI_PNL_0.Location = new System.Drawing.Point(16, 26);
        this._ID_CEM_ETI_PNL_0.Name = "_ID_CEM_ETI_PNL_0";
        this._ID_CEM_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_0.OcxState")));
        this._ID_CEM_ETI_PNL_0.Size = new System.Drawing.Size(75, 23);
        this._ID_CEM_ETI_PNL_0.TabIndex = 15;
        this._ID_CEM_ETI_PNL_0.Tag = "";
        // 
        // ID_CEM_GRP_COB
        // 
        this.ID_CEM_GRP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CEM_GRP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEM_GRP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CEM_GRP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEM_GRP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEM_GRP_COB.Location = new System.Drawing.Point(98, 27);
        this.ID_CEM_GRP_COB.Name = "ID_CEM_GRP_COB";
        this.ID_CEM_GRP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEM_GRP_COB.Size = new System.Drawing.Size(349, 21);
        this.ID_CEM_GRP_COB.Sorted = true;
        this.ID_CEM_GRP_COB.TabIndex = 16;
        this.ID_CEM_GRP_COB.Tag = "";
        // 
        // _ID_CEM_ETI_PNL_2Label_Text
        // 
        this._ID_CEM_ETI_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_2Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_2Label_Text.Location = new System.Drawing.Point(17, 56);
        this._ID_CEM_ETI_PNL_2Label_Text.Name = "_ID_CEM_ETI_PNL_2Label_Text";
        this._ID_CEM_ETI_PNL_2Label_Text.Size = new System.Drawing.Size(73, 21);
        this._ID_CEM_ETI_PNL_2Label_Text.TabIndex = 17;
        this._ID_CEM_ETI_PNL_2Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_2Label_Text.Text = " &Mes";
        this._ID_CEM_ETI_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_CEM_ETI_PNL_2
        // 
        this._ID_CEM_ETI_PNL_2.Location = new System.Drawing.Point(16, 54);
        this._ID_CEM_ETI_PNL_2.Name = "_ID_CEM_ETI_PNL_2";
        this._ID_CEM_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_2.OcxState")));
        this._ID_CEM_ETI_PNL_2.Size = new System.Drawing.Size(75, 23);
        this._ID_CEM_ETI_PNL_2.TabIndex = 18;
        this._ID_CEM_ETI_PNL_2.Tag = "";
        // 
        // _cboCombo_1
        // 
        this._cboCombo_1.BackColor = System.Drawing.Color.White;
        this._cboCombo_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._cboCombo_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this._cboCombo_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._cboCombo_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this._cboCombo_1.Location = new System.Drawing.Point(98, 55);
        this._cboCombo_1.Name = "_cboCombo_1";
        this._cboCombo_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._cboCombo_1.Size = new System.Drawing.Size(231, 21);
        this._cboCombo_1.TabIndex = 19;
        this._cboCombo_1.Tag = "";
        // 
        // _ID_CEM_ETI_PNL_3Label_Text
        // 
        this._ID_CEM_ETI_PNL_3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_3Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_3Label_Text.Location = new System.Drawing.Point(16, 82);
        this._ID_CEM_ETI_PNL_3Label_Text.Name = "_ID_CEM_ETI_PNL_3Label_Text";
        this._ID_CEM_ETI_PNL_3Label_Text.Size = new System.Drawing.Size(73, 21);
        this._ID_CEM_ETI_PNL_3Label_Text.TabIndex = 20;
        this._ID_CEM_ETI_PNL_3Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_3Label_Text.Text = " &Año";
        this._ID_CEM_ETI_PNL_3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_CEM_ETI_PNL_3
        // 
        this._ID_CEM_ETI_PNL_3.Location = new System.Drawing.Point(16, 82);
        this._ID_CEM_ETI_PNL_3.Name = "_ID_CEM_ETI_PNL_3";
        this._ID_CEM_ETI_PNL_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_3.OcxState")));
        this._ID_CEM_ETI_PNL_3.Size = new System.Drawing.Size(75, 23);
        this._ID_CEM_ETI_PNL_3.TabIndex = 21;
        this._ID_CEM_ETI_PNL_3.Tag = "";
        // 
        // _cboCombo_2
        // 
        this._cboCombo_2.BackColor = System.Drawing.Color.White;
        this._cboCombo_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._cboCombo_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._cboCombo_2.ForeColor = System.Drawing.SystemColors.WindowText;
        this._cboCombo_2.Location = new System.Drawing.Point(98, 82);
        this._cboCombo_2.Name = "_cboCombo_2";
        this._cboCombo_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._cboCombo_2.Size = new System.Drawing.Size(231, 21);
        this._cboCombo_2.Sorted = true;
        this._cboCombo_2.TabIndex = 22;
        this._cboCombo_2.Tag = "";
        this._cboCombo_2.Text = "cboCombo";
        // 
        // _ID_CEM_ETI_PNL_7Label_Text
        // 
        this._ID_CEM_ETI_PNL_7Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_7Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_7Label_Text.Location = new System.Drawing.Point(20, 114);
        this._ID_CEM_ETI_PNL_7Label_Text.Name = "_ID_CEM_ETI_PNL_7Label_Text";
        this._ID_CEM_ETI_PNL_7Label_Text.Size = new System.Drawing.Size(52, 21);
        this._ID_CEM_ETI_PNL_7Label_Text.TabIndex = 23;
        this._ID_CEM_ETI_PNL_7Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_7Label_Text.Text = "No.";
        this._ID_CEM_ETI_PNL_7Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CEM_ETI_PNL_7
        // 
        this._ID_CEM_ETI_PNL_7.Location = new System.Drawing.Point(20, 114);
        this._ID_CEM_ETI_PNL_7.Name = "_ID_CEM_ETI_PNL_7";
        this._ID_CEM_ETI_PNL_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_7.OcxState")));
        this._ID_CEM_ETI_PNL_7.Size = new System.Drawing.Size(54, 23);
        this._ID_CEM_ETI_PNL_7.TabIndex = 24;
        this._ID_CEM_ETI_PNL_7.Tag = "";
        // 
        // _ID_CEM_ETI_PNL_1Label_Text
        // 
        this._ID_CEM_ETI_PNL_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_1Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_1Label_Text.Location = new System.Drawing.Point(77, 115);
        this._ID_CEM_ETI_PNL_1Label_Text.Name = "_ID_CEM_ETI_PNL_1Label_Text";
        this._ID_CEM_ETI_PNL_1Label_Text.Size = new System.Drawing.Size(369, 21);
        this._ID_CEM_ETI_PNL_1Label_Text.TabIndex = 26;
        this._ID_CEM_ETI_PNL_1Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_1Label_Text.Text = "&Empresa";
        this._ID_CEM_ETI_PNL_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CEM_ETI_PNL_1
        // 
        this._ID_CEM_ETI_PNL_1.Location = new System.Drawing.Point(76, 114);
        this._ID_CEM_ETI_PNL_1.Name = "_ID_CEM_ETI_PNL_1";
        this._ID_CEM_ETI_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_1.OcxState")));
        this._ID_CEM_ETI_PNL_1.Size = new System.Drawing.Size(371, 23);
        this._ID_CEM_ETI_PNL_1.TabIndex = 27;
        this._ID_CEM_ETI_PNL_1.Tag = "";
        // 
        // ID_CEM_EMP_LB
        // 
        this.ID_CEM_EMP_LB.BackColor = System.Drawing.Color.White;
        this.ID_CEM_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEM_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEM_EMP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEM_EMP_LB.Location = new System.Drawing.Point(20, 144);
        this.ID_CEM_EMP_LB.Name = "ID_CEM_EMP_LB";
        this.ID_CEM_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEM_EMP_LB.Size = new System.Drawing.Size(545, 124);
        this.ID_CEM_EMP_LB.Sorted = true;
        this.ID_CEM_EMP_LB.TabIndex = 28;
        this.ID_CEM_EMP_LB.Tag = "";
        // 
        // _chkNivel_0
        // 
        this._chkNivel_0.BackColor = System.Drawing.SystemColors.Control;
        this._chkNivel_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._chkNivel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._chkNivel_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._chkNivel_0.Location = new System.Drawing.Point(25, 271);
        this._chkNivel_0.Name = "_chkNivel_0";
        this._chkNivel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._chkNivel_0.Size = new System.Drawing.Size(160, 21);
        this._chkNivel_0.TabIndex = 29;
        this._chkNivel_0.Tag = "";
        this._chkNivel_0.Text = "&Reporte a nivel Unidad";
        this._chkNivel_0.UseVisualStyleBackColor = false;
        this._chkNivel_0.CheckedChanged += new System.EventHandler(this.chkNivel_CheckStateChanged);
        // 
        // _chkNivel_1
        // 
        this._chkNivel_1.BackColor = System.Drawing.SystemColors.Control;
        this._chkNivel_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._chkNivel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._chkNivel_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._chkNivel_1.Location = new System.Drawing.Point(25, 292);
        this._chkNivel_1.Name = "_chkNivel_1";
        this._chkNivel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._chkNivel_1.Size = new System.Drawing.Size(183, 22);
        this._chkNivel_1.TabIndex = 30;
        this._chkNivel_1.Tag = "";
        this._chkNivel_1.Text = "&Reporte a nivel Tarjeta Habiente";
        this._chkNivel_1.UseVisualStyleBackColor = false;
        this._chkNivel_1.CheckedChanged += new System.EventHandler(this.chkNivel_CheckStateChanged);
        // 
        // _chkNivel_2
        // 
        this._chkNivel_2.BackColor = System.Drawing.SystemColors.Control;
        this._chkNivel_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._chkNivel_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._chkNivel_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._chkNivel_2.Location = new System.Drawing.Point(25, 314);
        this._chkNivel_2.Name = "_chkNivel_2";
        this._chkNivel_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._chkNivel_2.Size = new System.Drawing.Size(160, 24);
        this._chkNivel_2.TabIndex = 31;
        this._chkNivel_2.Tag = "";
        this._chkNivel_2.Text = "&Reporte a nivel Transacción";
        this._chkNivel_2.UseVisualStyleBackColor = false;
        this._chkNivel_2.CheckedChanged += new System.EventHandler(this.chkNivel_CheckStateChanged);
        // 
        // chkCuentaContable
        // 
        this.chkCuentaContable.BackColor = System.Drawing.SystemColors.Control;
        this.chkCuentaContable.Cursor = System.Windows.Forms.Cursors.Default;
        this.chkCuentaContable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.chkCuentaContable.ForeColor = System.Drawing.SystemColors.ControlText;
        this.chkCuentaContable.Location = new System.Drawing.Point(232, 270);
        this.chkCuentaContable.Name = "chkCuentaContable";
        this.chkCuentaContable.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.chkCuentaContable.Size = new System.Drawing.Size(121, 22);
        this.chkCuentaContable.TabIndex = 32;
        this.chkCuentaContable.Tag = "";
        this.chkCuentaContable.Text = "&Cuenta Contable";
        this.chkCuentaContable.UseVisualStyleBackColor = false;
        // 
        // frmAccCyRep
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(585, 354);
        this.Controls.Add(this.chkCuentaContable);
        this.Controls.Add(this._chkNivel_2);
        this.Controls.Add(this._chkNivel_1);
        this.Controls.Add(this._chkNivel_0);
        this.Controls.Add(this.ID_CEM_EMP_LB);
        this.Controls.Add(this._ID_CEM_ETI_PNL_1);
        this.Controls.Add(this._ID_CEM_ETI_PNL_1Label_Text);
        this.Controls.Add(this._ID_CEM_ETI_PNL_7);
        this.Controls.Add(this._ID_CEM_ETI_PNL_7Label_Text);
        this.Controls.Add(this._cboCombo_2);
        this.Controls.Add(this._ID_CEM_ETI_PNL_3);
        this.Controls.Add(this._ID_CEM_ETI_PNL_3Label_Text);
        this.Controls.Add(this._cboCombo_1);
        this.Controls.Add(this._ID_CEM_ETI_PNL_2);
        this.Controls.Add(this._ID_CEM_ETI_PNL_2Label_Text);
        this.Controls.Add(this.ID_CEM_GRP_COB);
        this.Controls.Add(this._ID_CEM_ETI_PNL_0);
        this.Controls.Add(this._ID_CEM_ETI_PNL_0Label_Text);
        this.Controls.Add(this.ID_CEM_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(40, 60);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmAccCyRep";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Account Cycle Report";
        this.Closed += new System.EventHandler(this.frmAccCyRep_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_PPL_PNL)).EndInit();
        this.ID_CEM_PPL_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializecboCombo()
	{
			this.cboCombo[2] = _cboCombo_2;
			this.cboCombo[1] = _cboCombo_1;
	}
	void  InitializechkNivel()
	{
			this.chkNivel[2] = _chkNivel_2;
			this.chkNivel[1] = _chkNivel_1;
			this.chkNivel[0] = _chkNivel_0;
	}
	void  InitializeID_CEM_ETI_PNL()
	{
			this.ID_CEM_ETI_PNL[3] = _ID_CEM_ETI_PNL_3;
			this.ID_CEM_ETI_PNL[0] = _ID_CEM_ETI_PNL_0;
			this.ID_CEM_ETI_PNL[7] = _ID_CEM_ETI_PNL_7;
			this.ID_CEM_ETI_PNL[1] = _ID_CEM_ETI_PNL_1;
			this.ID_CEM_ETI_PNL[2] = _ID_CEM_ETI_PNL_2;
	}
#endregion 

        public AxThreed.AxSSPanel ID_CEM_PPL_PNL;
        public System.Windows.Forms.Button cmdGenerar;
        public System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_0Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_0;
        public System.Windows.Forms.ComboBox ID_CEM_GRP_COB;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_2Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_2;
        private System.Windows.Forms.ComboBox _cboCombo_1;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_3Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_3;
        private System.Windows.Forms.ComboBox _cboCombo_2;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_7Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_7;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_1Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_1;
        public System.Windows.Forms.CheckedListBox ID_CEM_EMP_LB;
        private System.Windows.Forms.CheckBox _chkNivel_0;
        private System.Windows.Forms.CheckBox _chkNivel_1;
        private System.Windows.Forms.CheckBox _chkNivel_2;
        public System.Windows.Forms.CheckBox chkCuentaContable;

}
}