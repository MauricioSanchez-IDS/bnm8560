using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    partial class CORRPCE2
	{
	
#region "Upgrade Support "
		private static CORRPCE2 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORRPCE2 DefInstance
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
		public CORRPCE2():base(){
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
			InitializeID_REE_ETI_PNL();
			InitializechkEmpresa();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORRPCE2 CreateInstance()
	{
			CORRPCE2 theInstance = new CORRPCE2();
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
	public AxThreed.AxSSPanel[] ID_REE_ETI_PNL = new AxThreed.AxSSPanel[5];
	public System.Windows.Forms.CheckBox[] chkEmpresa = new System.Windows.Forms.CheckBox[1];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPCE2));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this._chkEmpresa_0 = new System.Windows.Forms.CheckBox();
        this.ID_REE_PPL_PNL = new AxThreed.AxSSPanel();
        this._ID_REE_ETI_PNL_1Label_Text = new System.Windows.Forms.Label();
        this.ID_REE_GRU_COB = new System.Windows.Forms.ComboBox();
        this.ID_REE_MASG_3PB = new AxThreed.AxSSCommand();
        this._ID_REE_ETI_PNL_4Label_Text = new System.Windows.Forms.Label();
        this._ID_REE_ETI_PNL_4 = new AxThreed.AxSSPanel();
        this.ID_REE_EMP_LB = new System.Windows.Forms.ComboBox();
        this._ID_REE_ETI_PNL_1 = new AxThreed.AxSSPanel();
        this._ID_REE_ETI_PNL_3Label_Text = new System.Windows.Forms.Label();
        this._ID_REE_ETI_PNL_3 = new AxThreed.AxSSPanel();
        this._ID_REE_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
        this.ID_REE_MES_COB = new System.Windows.Forms.ComboBox();
        this._ID_REE_ETI_PNL_2Label_Text = new System.Windows.Forms.Label();
        this._ID_REE_ETI_PNL_2 = new AxThreed.AxSSPanel();
        this._ID_REE_ETI_PNL_0 = new AxThreed.AxSSPanel();
        this.lstLista = new System.Windows.Forms.ListBox();
        this.ID_REE_IRE_CKB = new AxThreed.AxSSCheck();
        this.ID_REE_ALT_PB = new System.Windows.Forms.Button();
        this.ID_REE_CER_PB = new System.Windows.Forms.Button();
        this.checkBox1 = new System.Windows.Forms.CheckBox();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REE_PPL_PNL)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REE_MASG_3PB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REE_IRE_CKB)).BeginInit();
        this.SuspendLayout();
        // 
        // _chkEmpresa_0
        // 
        this._chkEmpresa_0.BackColor = System.Drawing.SystemColors.Control;
        this._chkEmpresa_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._chkEmpresa_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._chkEmpresa_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._chkEmpresa_0.Location = new System.Drawing.Point(21, 336);
        this._chkEmpresa_0.Name = "_chkEmpresa_0";
        this._chkEmpresa_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._chkEmpresa_0.Size = new System.Drawing.Size(202, 16);
        this._chkEmpresa_0.TabIndex = 14;
        this._chkEmpresa_0.Tag = "";
        this._chkEmpresa_0.Text = "Reporte a Nivel Empresa";
        this._chkEmpresa_0.UseVisualStyleBackColor = false;
        // 
        // ID_REE_PPL_PNL
        // 
        this.ID_REE_PPL_PNL.Location = new System.Drawing.Point(1, 0);
        this.ID_REE_PPL_PNL.Name = "ID_REE_PPL_PNL";
        this.ID_REE_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REE_PPL_PNL.OcxState")));
        this.ID_REE_PPL_PNL.Size = new System.Drawing.Size(459, 366);
        this.ID_REE_PPL_PNL.TabIndex = 25;
        this.ID_REE_PPL_PNL.Tag = "";
        // 
        // _ID_REE_ETI_PNL_1Label_Text
        // 
        this._ID_REE_ETI_PNL_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_REE_ETI_PNL_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_REE_ETI_PNL_1Label_Text.Location = new System.Drawing.Point(26, 26);
        this._ID_REE_ETI_PNL_1Label_Text.Name = "_ID_REE_ETI_PNL_1Label_Text";
        this._ID_REE_ETI_PNL_1Label_Text.Size = new System.Drawing.Size(92, 21);
        this._ID_REE_ETI_PNL_1Label_Text.TabIndex = 27;
        this._ID_REE_ETI_PNL_1Label_Text.Tag = "";
        this._ID_REE_ETI_PNL_1Label_Text.Text = " &Grupo";
        this._ID_REE_ETI_PNL_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ID_REE_GRU_COB
        // 
        this.ID_REE_GRU_COB.BackColor = System.Drawing.Color.White;
        this.ID_REE_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REE_GRU_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_REE_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REE_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_REE_GRU_COB.Location = new System.Drawing.Point(122, 27);
        this.ID_REE_GRU_COB.Name = "ID_REE_GRU_COB";
        this.ID_REE_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REE_GRU_COB.Size = new System.Drawing.Size(289, 21);
        this.ID_REE_GRU_COB.Sorted = true;
        this.ID_REE_GRU_COB.TabIndex = 28;
        this.ID_REE_GRU_COB.Tag = "";
        this.ID_REE_GRU_COB.SelectedIndexChanged += new System.EventHandler(this.ID_REE_GRU_COB_SelectedIndexChanged);
        // 
        // ID_REE_MASG_3PB
        // 
        this.ID_REE_MASG_3PB.Location = new System.Drawing.Point(422, 27);
        this.ID_REE_MASG_3PB.Name = "ID_REE_MASG_3PB";
        this.ID_REE_MASG_3PB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REE_MASG_3PB.OcxState")));
        this.ID_REE_MASG_3PB.Size = new System.Drawing.Size(19, 20);
        this.ID_REE_MASG_3PB.TabIndex = 29;
        this.ID_REE_MASG_3PB.Tag = "";
        this.ID_REE_MASG_3PB.ClickEvent += new System.EventHandler(this.ID_REE_MASG_3PB_ClickEvent);
        // 
        // _ID_REE_ETI_PNL_4Label_Text
        // 
        this._ID_REE_ETI_PNL_4Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_REE_ETI_PNL_4Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_REE_ETI_PNL_4Label_Text.Location = new System.Drawing.Point(25, 56);
        this._ID_REE_ETI_PNL_4Label_Text.Name = "_ID_REE_ETI_PNL_4Label_Text";
        this._ID_REE_ETI_PNL_4Label_Text.Size = new System.Drawing.Size(91, 21);
        this._ID_REE_ETI_PNL_4Label_Text.TabIndex = 30;
        this._ID_REE_ETI_PNL_4Label_Text.Tag = "";
        this._ID_REE_ETI_PNL_4Label_Text.Text = "&Empresas";
        this._ID_REE_ETI_PNL_4Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_REE_ETI_PNL_4
        // 
        this._ID_REE_ETI_PNL_4.Location = new System.Drawing.Point(20, 54);
        this._ID_REE_ETI_PNL_4.Name = "_ID_REE_ETI_PNL_4";
        this._ID_REE_ETI_PNL_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_REE_ETI_PNL_4.OcxState")));
        this._ID_REE_ETI_PNL_4.Size = new System.Drawing.Size(97, 25);
        this._ID_REE_ETI_PNL_4.TabIndex = 31;
        this._ID_REE_ETI_PNL_4.Tag = "";
        // 
        // ID_REE_EMP_LB
        // 
        this.ID_REE_EMP_LB.BackColor = System.Drawing.Color.White;
        this.ID_REE_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REE_EMP_LB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_REE_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REE_EMP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_REE_EMP_LB.Location = new System.Drawing.Point(122, 56);
        this.ID_REE_EMP_LB.Name = "ID_REE_EMP_LB";
        this.ID_REE_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REE_EMP_LB.Size = new System.Drawing.Size(289, 21);
        this.ID_REE_EMP_LB.TabIndex = 32;
        this.ID_REE_EMP_LB.Tag = "";
        this.ID_REE_EMP_LB.SelectedIndexChanged += new System.EventHandler(this.ID_REE_EMP_LB_SelectedIndexChanged);
        // 
        // _ID_REE_ETI_PNL_1
        // 
        this._ID_REE_ETI_PNL_1.Location = new System.Drawing.Point(20, 26);
        this._ID_REE_ETI_PNL_1.Name = "_ID_REE_ETI_PNL_1";
        this._ID_REE_ETI_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_REE_ETI_PNL_1.OcxState")));
        this._ID_REE_ETI_PNL_1.Size = new System.Drawing.Size(98, 25);
        this._ID_REE_ETI_PNL_1.TabIndex = 33;
        this._ID_REE_ETI_PNL_1.Tag = "";
        // 
        // _ID_REE_ETI_PNL_3Label_Text
        // 
        this._ID_REE_ETI_PNL_3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_REE_ETI_PNL_3Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_REE_ETI_PNL_3Label_Text.Location = new System.Drawing.Point(24, 84);
        this._ID_REE_ETI_PNL_3Label_Text.Name = "_ID_REE_ETI_PNL_3Label_Text";
        this._ID_REE_ETI_PNL_3Label_Text.Size = new System.Drawing.Size(91, 25);
        this._ID_REE_ETI_PNL_3Label_Text.TabIndex = 34;
        this._ID_REE_ETI_PNL_3Label_Text.Tag = "";
        this._ID_REE_ETI_PNL_3Label_Text.Text = " &Mes de corte";
        this._ID_REE_ETI_PNL_3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_REE_ETI_PNL_3
        // 
        this._ID_REE_ETI_PNL_3.Location = new System.Drawing.Point(20, 83);
        this._ID_REE_ETI_PNL_3.Name = "_ID_REE_ETI_PNL_3";
        this._ID_REE_ETI_PNL_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_REE_ETI_PNL_3.OcxState")));
        this._ID_REE_ETI_PNL_3.Size = new System.Drawing.Size(97, 27);
        this._ID_REE_ETI_PNL_3.TabIndex = 35;
        this._ID_REE_ETI_PNL_3.Tag = "";
        // 
        // _ID_REE_ETI_PNL_0Label_Text
        // 
        this._ID_REE_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_REE_ETI_PNL_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_REE_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(79, 114);
        this._ID_REE_ETI_PNL_0Label_Text.Name = "_ID_REE_ETI_PNL_0Label_Text";
        this._ID_REE_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(358, 20);
        this._ID_REE_ETI_PNL_0Label_Text.TabIndex = 36;
        this._ID_REE_ETI_PNL_0Label_Text.Tag = "";
        this._ID_REE_ETI_PNL_0Label_Text.Text = "&Unidades";
        this._ID_REE_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_REE_MES_COB
        // 
        this.ID_REE_MES_COB.BackColor = System.Drawing.Color.White;
        this.ID_REE_MES_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REE_MES_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_REE_MES_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REE_MES_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_REE_MES_COB.Location = new System.Drawing.Point(122, 85);
        this.ID_REE_MES_COB.Name = "ID_REE_MES_COB";
        this.ID_REE_MES_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REE_MES_COB.Size = new System.Drawing.Size(289, 21);
        this.ID_REE_MES_COB.TabIndex = 37;
        this.ID_REE_MES_COB.Tag = "";
        // 
        // _ID_REE_ETI_PNL_2Label_Text
        // 
        this._ID_REE_ETI_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_REE_ETI_PNL_2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_REE_ETI_PNL_2Label_Text.Location = new System.Drawing.Point(23, 113);
        this._ID_REE_ETI_PNL_2Label_Text.Name = "_ID_REE_ETI_PNL_2Label_Text";
        this._ID_REE_ETI_PNL_2Label_Text.Size = new System.Drawing.Size(53, 20);
        this._ID_REE_ETI_PNL_2Label_Text.TabIndex = 38;
        this._ID_REE_ETI_PNL_2Label_Text.Tag = "";
        this._ID_REE_ETI_PNL_2Label_Text.Text = " Clave";
        this._ID_REE_ETI_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_REE_ETI_PNL_2
        // 
        this._ID_REE_ETI_PNL_2.Location = new System.Drawing.Point(20, 111);
        this._ID_REE_ETI_PNL_2.Name = "_ID_REE_ETI_PNL_2";
        this._ID_REE_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_REE_ETI_PNL_2.OcxState")));
        this._ID_REE_ETI_PNL_2.Size = new System.Drawing.Size(59, 25);
        this._ID_REE_ETI_PNL_2.TabIndex = 39;
        this._ID_REE_ETI_PNL_2.Tag = "";
        // 
        // _ID_REE_ETI_PNL_0
        // 
        this._ID_REE_ETI_PNL_0.Location = new System.Drawing.Point(79, 111);
        this._ID_REE_ETI_PNL_0.Name = "_ID_REE_ETI_PNL_0";
        this._ID_REE_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_REE_ETI_PNL_0.OcxState")));
        this._ID_REE_ETI_PNL_0.Size = new System.Drawing.Size(362, 25);
        this._ID_REE_ETI_PNL_0.TabIndex = 40;
        this._ID_REE_ETI_PNL_0.Tag = "";
        // 
        // lstLista
        // 
        this.lstLista.BackColor = System.Drawing.Color.White;
        this.lstLista.Cursor = System.Windows.Forms.Cursors.Default;
        this.lstLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lstLista.ForeColor = System.Drawing.SystemColors.WindowText;
        this.lstLista.Location = new System.Drawing.Point(22, 136);
        this.lstLista.Name = "lstLista";
        this.lstLista.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lstLista.Size = new System.Drawing.Size(420, 173);
        this.lstLista.Sorted = true;
        this.lstLista.TabIndex = 41;
        this.lstLista.Tag = "";
        // 
        // ID_REE_IRE_CKB
        // 
        this.ID_REE_IRE_CKB.Location = new System.Drawing.Point(22, 315);
        this.ID_REE_IRE_CKB.Name = "ID_REE_IRE_CKB";
        this.ID_REE_IRE_CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REE_IRE_CKB.OcxState")));
        this.ID_REE_IRE_CKB.Size = new System.Drawing.Size(209, 15);
        this.ID_REE_IRE_CKB.TabIndex = 42;
        this.ID_REE_IRE_CKB.Tag = "";
        // 
        // ID_REE_ALT_PB
        // 
        this.ID_REE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REE_ALT_PB.Location = new System.Drawing.Point(292, 332);
        this.ID_REE_ALT_PB.Name = "ID_REE_ALT_PB";
        this.ID_REE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REE_ALT_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_REE_ALT_PB.TabIndex = 43;
        this.ID_REE_ALT_PB.Tag = "";
        this.ID_REE_ALT_PB.Text = "&Reporte";
        this.ID_REE_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_REE_ALT_PB.Click += new System.EventHandler(this.ID_REE_ALT_PB_Click);
        // 
        // ID_REE_CER_PB
        // 
        this.ID_REE_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REE_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REE_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_REE_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REE_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REE_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REE_CER_PB.Location = new System.Drawing.Point(372, 332);
        this.ID_REE_CER_PB.Name = "ID_REE_CER_PB";
        this.ID_REE_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REE_CER_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_REE_CER_PB.TabIndex = 44;
        this.ID_REE_CER_PB.Tag = "Cancela";
        this.ID_REE_CER_PB.Text = "&Salir";
        this.ID_REE_CER_PB.UseVisualStyleBackColor = false;
        this.ID_REE_CER_PB.Click += new System.EventHandler(this.ID_REE_CER_PB_Click);
        // 
        // checkBox1
        // 
        this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
        this.checkBox1.Cursor = System.Windows.Forms.Cursors.Default;
        this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.checkBox1.Location = new System.Drawing.Point(22, 336);
        this.checkBox1.Name = "checkBox1";
        this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.checkBox1.Size = new System.Drawing.Size(202, 18);
        this.checkBox1.TabIndex = 45;
        this.checkBox1.Tag = "";
        this.checkBox1.Text = "Reporte a Nivel Empresa";
        this.checkBox1.UseVisualStyleBackColor = false;
        // 
        // CORRPCE2
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(459, 366);
        this.Controls.Add(this.checkBox1);
        this.Controls.Add(this.ID_REE_CER_PB);
        this.Controls.Add(this.ID_REE_ALT_PB);
        this.Controls.Add(this.ID_REE_IRE_CKB);
        this.Controls.Add(this.lstLista);
        this.Controls.Add(this._ID_REE_ETI_PNL_0);
        this.Controls.Add(this._ID_REE_ETI_PNL_2);
        this.Controls.Add(this._ID_REE_ETI_PNL_2Label_Text);
        this.Controls.Add(this.ID_REE_MES_COB);
        this.Controls.Add(this._ID_REE_ETI_PNL_0Label_Text);
        this.Controls.Add(this._ID_REE_ETI_PNL_3);
        this.Controls.Add(this._ID_REE_ETI_PNL_3Label_Text);
        this.Controls.Add(this._ID_REE_ETI_PNL_1);
        this.Controls.Add(this.ID_REE_EMP_LB);
        this.Controls.Add(this._ID_REE_ETI_PNL_4);
        this.Controls.Add(this._ID_REE_ETI_PNL_4Label_Text);
        this.Controls.Add(this.ID_REE_MASG_3PB);
        this.Controls.Add(this.ID_REE_GRU_COB);
        this.Controls.Add(this._ID_REE_ETI_PNL_1Label_Text);
        this.Controls.Add(this.ID_REE_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(192, 113);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORRPCE2";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Empresa / Ejecutivo ";
        this.Closed += new System.EventHandler(this.CORRPCE2_Closed);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORRPCE2_KeyPress);
        ((System.ComponentModel.ISupportInitialize)(this.ID_REE_PPL_PNL)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REE_MASG_3PB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_REE_ETI_PNL_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_REE_IRE_CKB)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_REE_ETI_PNL()
	{
			this.ID_REE_ETI_PNL[1] = _ID_REE_ETI_PNL_1;
			this.ID_REE_ETI_PNL[3] = _ID_REE_ETI_PNL_3;
			this.ID_REE_ETI_PNL[2] = _ID_REE_ETI_PNL_2;
			this.ID_REE_ETI_PNL[0] = _ID_REE_ETI_PNL_0;
			this.ID_REE_ETI_PNL[4] = _ID_REE_ETI_PNL_4;
	}
	void  InitializechkEmpresa()
	{
			this.chkEmpresa[0] = checkBox1;
	}
#endregion 

        private System.Windows.Forms.CheckBox _chkEmpresa_0;
        public AxThreed.AxSSPanel ID_REE_PPL_PNL;
        private System.Windows.Forms.Label _ID_REE_ETI_PNL_1Label_Text;
        public System.Windows.Forms.ComboBox ID_REE_GRU_COB;
        public AxThreed.AxSSCommand ID_REE_MASG_3PB;
        private System.Windows.Forms.Label _ID_REE_ETI_PNL_4Label_Text;
        private AxThreed.AxSSPanel _ID_REE_ETI_PNL_4;
        public System.Windows.Forms.ComboBox ID_REE_EMP_LB;
        private AxThreed.AxSSPanel _ID_REE_ETI_PNL_1;
        private System.Windows.Forms.Label _ID_REE_ETI_PNL_3Label_Text;
        private AxThreed.AxSSPanel _ID_REE_ETI_PNL_3;
        private System.Windows.Forms.Label _ID_REE_ETI_PNL_0Label_Text;
        public System.Windows.Forms.ComboBox ID_REE_MES_COB;
        private System.Windows.Forms.Label _ID_REE_ETI_PNL_2Label_Text;
        private AxThreed.AxSSPanel _ID_REE_ETI_PNL_2;
        private AxThreed.AxSSPanel _ID_REE_ETI_PNL_0;
        public System.Windows.Forms.ListBox lstLista;
        public AxThreed.AxSSCheck ID_REE_IRE_CKB;
        public System.Windows.Forms.Button ID_REE_ALT_PB;
        public System.Windows.Forms.Button ID_REE_CER_PB;
        private System.Windows.Forms.CheckBox checkBox1;
}
}
