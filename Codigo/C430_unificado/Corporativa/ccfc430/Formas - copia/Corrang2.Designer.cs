using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORRANG2
	{
	
#region "Upgrade Support "
		private static CORRANG2 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORRANG2 DefInstance
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
		public CORRANG2():base(){
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
			InitializeID_CEM_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORRANG2 CreateInstance()
	{
			CORRANG2 theInstance = new CORRANG2();
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
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRANG2));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_CEM_PPL_PNL = new AxThreed.AxSSPanel();
        this.ID_CEM_CER_PB = new System.Windows.Forms.Button();
        this.ID_CEM_IRA_3CKB = new AxThreed.AxSSCheck();
        this._ID_CEM_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_0 = new AxThreed.AxSSPanel();
        this.ID_CEM_GRP_COB = new System.Windows.Forms.ComboBox();
        this._ID_CEM_ETI_PNL_2Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_2 = new AxThreed.AxSSPanel();
        this._ID_CEM_ETI_PNL_7Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_7 = new AxThreed.AxSSPanel();
        this._ID_CEM_ETI_PNL_1Label_Text = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_1 = new AxThreed.AxSSPanel();
        this.ID_CEM_EMP_LB = new System.Windows.Forms.ListBox();
        this.ID_ACG_MES_COB = new System.Windows.Forms.ComboBox();
        this.ID_CEM_ALT_PB = new System.Windows.Forms.Button();
        this.ID_CEM_MASG_3PB = new AxThreed.AxSSCommand();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_PPL_PNL)).BeginInit();
        this.ID_CEM_PPL_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_IRA_3CKB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_MASG_3PB)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_CEM_PPL_PNL
        // 
        this.ID_CEM_PPL_PNL.Controls.Add(this.ID_CEM_CER_PB);
        this.ID_CEM_PPL_PNL.Controls.Add(this.ID_CEM_IRA_3CKB);
        this.ID_CEM_PPL_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_CEM_PPL_PNL.Name = "ID_CEM_PPL_PNL";
        this.ID_CEM_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEM_PPL_PNL.OcxState")));
        this.ID_CEM_PPL_PNL.Size = new System.Drawing.Size(318, 342);
        this.ID_CEM_PPL_PNL.TabIndex = 1;
        this.ID_CEM_PPL_PNL.Tag = "";
        // 
        // ID_CEM_CER_PB
        // 
        this.ID_CEM_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEM_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEM_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_CEM_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEM_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEM_CER_PB.Location = new System.Drawing.Point(148, 298);
        this.ID_CEM_CER_PB.Name = "ID_CEM_CER_PB";
        this.ID_CEM_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEM_CER_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CEM_CER_PB.TabIndex = 2;
        this.ID_CEM_CER_PB.Tag = "";
        this.ID_CEM_CER_PB.Text = "&Salir";
        this.ID_CEM_CER_PB.UseVisualStyleBackColor = false;
        this.ID_CEM_CER_PB.Click += new System.EventHandler(this.ID_CEM_CER_PB_Click);
        // 
        // ID_CEM_IRA_3CKB
        // 
        this.ID_CEM_IRA_3CKB.Location = new System.Drawing.Point(19, 262);
        this.ID_CEM_IRA_3CKB.Name = "ID_CEM_IRA_3CKB";
        this.ID_CEM_IRA_3CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEM_IRA_3CKB.OcxState")));
        this.ID_CEM_IRA_3CKB.Size = new System.Drawing.Size(216, 21);
        this.ID_CEM_IRA_3CKB.TabIndex = 9;
        this.ID_CEM_IRA_3CKB.Tag = "";
        // 
        // _ID_CEM_ETI_PNL_0Label_Text
        // 
        this._ID_CEM_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_CEM_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(17, 23);
        this._ID_CEM_ETI_PNL_0Label_Text.Name = "_ID_CEM_ETI_PNL_0Label_Text";
        this._ID_CEM_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(89, 21);
        this._ID_CEM_ETI_PNL_0Label_Text.TabIndex = 3;
        this._ID_CEM_ETI_PNL_0Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_0Label_Text.Text = " &Grupo";
        this._ID_CEM_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_CEM_ETI_PNL_0
        // 
        this._ID_CEM_ETI_PNL_0.Location = new System.Drawing.Point(15, 23);
        this._ID_CEM_ETI_PNL_0.Name = "_ID_CEM_ETI_PNL_0";
        this._ID_CEM_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_0.OcxState")));
        this._ID_CEM_ETI_PNL_0.Size = new System.Drawing.Size(91, 22);
        this._ID_CEM_ETI_PNL_0.TabIndex = 4;
        this._ID_CEM_ETI_PNL_0.Tag = "";
        // 
        // ID_CEM_GRP_COB
        // 
        this.ID_CEM_GRP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CEM_GRP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEM_GRP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CEM_GRP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEM_GRP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEM_GRP_COB.Location = new System.Drawing.Point(108, 23);
        this.ID_CEM_GRP_COB.Name = "ID_CEM_GRP_COB";
        this.ID_CEM_GRP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEM_GRP_COB.Size = new System.Drawing.Size(172, 21);
        this.ID_CEM_GRP_COB.Sorted = true;
        this.ID_CEM_GRP_COB.TabIndex = 7;
        this.ID_CEM_GRP_COB.Tag = "";
        this.ID_CEM_GRP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEM_GRP_COB_SelectedIndexChanged);
        // 
        // _ID_CEM_ETI_PNL_2Label_Text
        // 
        this._ID_CEM_ETI_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_CEM_ETI_PNL_2Label_Text.Location = new System.Drawing.Point(16, 48);
        this._ID_CEM_ETI_PNL_2Label_Text.Name = "_ID_CEM_ETI_PNL_2Label_Text";
        this._ID_CEM_ETI_PNL_2Label_Text.Size = new System.Drawing.Size(89, 21);
        this._ID_CEM_ETI_PNL_2Label_Text.TabIndex = 9;
        this._ID_CEM_ETI_PNL_2Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_2Label_Text.Text = "&Mes de Corte";
        this._ID_CEM_ETI_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CEM_ETI_PNL_2
        // 
        this._ID_CEM_ETI_PNL_2.Location = new System.Drawing.Point(15, 48);
        this._ID_CEM_ETI_PNL_2.Name = "_ID_CEM_ETI_PNL_2";
        this._ID_CEM_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_2.OcxState")));
        this._ID_CEM_ETI_PNL_2.Size = new System.Drawing.Size(91, 23);
        this._ID_CEM_ETI_PNL_2.TabIndex = 10;
        this._ID_CEM_ETI_PNL_2.Tag = "";
        // 
        // _ID_CEM_ETI_PNL_7Label_Text
        // 
        this._ID_CEM_ETI_PNL_7Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_7Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_CEM_ETI_PNL_7Label_Text.Location = new System.Drawing.Point(16, 82);
        this._ID_CEM_ETI_PNL_7Label_Text.Name = "_ID_CEM_ETI_PNL_7Label_Text";
        this._ID_CEM_ETI_PNL_7Label_Text.Size = new System.Drawing.Size(43, 21);
        this._ID_CEM_ETI_PNL_7Label_Text.TabIndex = 11;
        this._ID_CEM_ETI_PNL_7Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_7Label_Text.Text = "&No.";
        this._ID_CEM_ETI_PNL_7Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CEM_ETI_PNL_7
        // 
        this._ID_CEM_ETI_PNL_7.Location = new System.Drawing.Point(14, 81);
        this._ID_CEM_ETI_PNL_7.Name = "_ID_CEM_ETI_PNL_7";
        this._ID_CEM_ETI_PNL_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_7.OcxState")));
        this._ID_CEM_ETI_PNL_7.Size = new System.Drawing.Size(45, 23);
        this._ID_CEM_ETI_PNL_7.TabIndex = 12;
        this._ID_CEM_ETI_PNL_7.Tag = "";
        // 
        // _ID_CEM_ETI_PNL_1Label_Text
        // 
        this._ID_CEM_ETI_PNL_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_CEM_ETI_PNL_1Label_Text.Location = new System.Drawing.Point(62, 82);
        this._ID_CEM_ETI_PNL_1Label_Text.Name = "_ID_CEM_ETI_PNL_1Label_Text";
        this._ID_CEM_ETI_PNL_1Label_Text.Size = new System.Drawing.Size(244, 21);
        this._ID_CEM_ETI_PNL_1Label_Text.TabIndex = 13;
        this._ID_CEM_ETI_PNL_1Label_Text.Tag = "";
        this._ID_CEM_ETI_PNL_1Label_Text.Text = "&Empresa";
        this._ID_CEM_ETI_PNL_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CEM_ETI_PNL_1
        // 
        this._ID_CEM_ETI_PNL_1.Location = new System.Drawing.Point(60, 81);
        this._ID_CEM_ETI_PNL_1.Name = "_ID_CEM_ETI_PNL_1";
        this._ID_CEM_ETI_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEM_ETI_PNL_1.OcxState")));
        this._ID_CEM_ETI_PNL_1.Size = new System.Drawing.Size(246, 23);
        this._ID_CEM_ETI_PNL_1.TabIndex = 14;
        this._ID_CEM_ETI_PNL_1.Tag = "";
        // 
        // ID_CEM_EMP_LB
        // 
        this.ID_CEM_EMP_LB.BackColor = System.Drawing.Color.White;
        this.ID_CEM_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEM_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEM_EMP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEM_EMP_LB.Location = new System.Drawing.Point(15, 106);
        this.ID_CEM_EMP_LB.Name = "ID_CEM_EMP_LB";
        this.ID_CEM_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEM_EMP_LB.Size = new System.Drawing.Size(290, 134);
        this.ID_CEM_EMP_LB.Sorted = true;
        this.ID_CEM_EMP_LB.TabIndex = 15;
        this.ID_CEM_EMP_LB.Tag = "";
        // 
        // ID_ACG_MES_COB
        // 
        this.ID_ACG_MES_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACG_MES_COB.FormattingEnabled = true;
        this.ID_ACG_MES_COB.Location = new System.Drawing.Point(108, 48);
        this.ID_ACG_MES_COB.Name = "ID_ACG_MES_COB";
        this.ID_ACG_MES_COB.Size = new System.Drawing.Size(189, 21);
        this.ID_ACG_MES_COB.TabIndex = 16;
        // 
        // ID_CEM_ALT_PB
        // 
        this.ID_CEM_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEM_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEM_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEM_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEM_ALT_PB.Location = new System.Drawing.Point(68, 298);
        this.ID_CEM_ALT_PB.Name = "ID_CEM_ALT_PB";
        this.ID_CEM_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEM_ALT_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_CEM_ALT_PB.TabIndex = 17;
        this.ID_CEM_ALT_PB.Tag = "";
        this.ID_CEM_ALT_PB.Text = "&Reporte";
        this.ID_CEM_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_CEM_ALT_PB.Click += new System.EventHandler(this.ID_CEM_ALT_PB_Click);
        // 
        // ID_CEM_MASG_3PB
        // 
        this.ID_CEM_MASG_3PB.Location = new System.Drawing.Point(282, 24);
        this.ID_CEM_MASG_3PB.Name = "ID_CEM_MASG_3PB";
        this.ID_CEM_MASG_3PB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEM_MASG_3PB.OcxState")));
        this.ID_CEM_MASG_3PB.Size = new System.Drawing.Size(19, 20);
        this.ID_CEM_MASG_3PB.TabIndex = 18;
        this.ID_CEM_MASG_3PB.Tag = "";
        this.ID_CEM_MASG_3PB.ClickEvent += new System.EventHandler(this.ID_CEM_MASG_3PB_ClickEvent);
        // 
        // CORRANG2
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(317, 341);
        this.Controls.Add(this.ID_CEM_MASG_3PB);
        this.Controls.Add(this.ID_CEM_ALT_PB);
        this.Controls.Add(this.ID_ACG_MES_COB);
        this.Controls.Add(this.ID_CEM_EMP_LB);
        this.Controls.Add(this._ID_CEM_ETI_PNL_1);
        this.Controls.Add(this._ID_CEM_ETI_PNL_1Label_Text);
        this.Controls.Add(this._ID_CEM_ETI_PNL_7);
        this.Controls.Add(this._ID_CEM_ETI_PNL_7Label_Text);
        this.Controls.Add(this._ID_CEM_ETI_PNL_2);
        this.Controls.Add(this._ID_CEM_ETI_PNL_2Label_Text);
        this.Controls.Add(this.ID_CEM_GRP_COB);
        this.Controls.Add(this._ID_CEM_ETI_PNL_0);
        this.Controls.Add(this._ID_CEM_ETI_PNL_0Label_Text);
        this.Controls.Add(this.ID_CEM_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(355, 109);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORRANG2";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Consumos por Giro";
        this.Closed += new System.EventHandler(this.CORRANG2_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_PPL_PNL)).EndInit();
        this.ID_CEM_PPL_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_IRA_3CKB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEM_ETI_PNL_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_MASG_3PB)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_CEM_ETI_PNL()
	{
			this.ID_CEM_ETI_PNL[0] = _ID_CEM_ETI_PNL_0;
			this.ID_CEM_ETI_PNL[2] = _ID_CEM_ETI_PNL_2;
			this.ID_CEM_ETI_PNL[7] = _ID_CEM_ETI_PNL_7;
			this.ID_CEM_ETI_PNL[1] = _ID_CEM_ETI_PNL_1;
	}
#endregion 

        public AxThreed.AxSSPanel ID_CEM_PPL_PNL;
        public System.Windows.Forms.Button ID_CEM_CER_PB;
        public AxThreed.AxSSCheck ID_CEM_IRA_3CKB;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_0Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_0;
        public System.Windows.Forms.ComboBox ID_CEM_GRP_COB;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_2Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_2;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_7Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_7;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_1Label_Text;
        private AxThreed.AxSSPanel _ID_CEM_ETI_PNL_1;
        public System.Windows.Forms.ListBox ID_CEM_EMP_LB;
        private System.Windows.Forms.ComboBox ID_ACG_MES_COB;
        public System.Windows.Forms.Button ID_CEM_ALT_PB;
        public AxThreed.AxSSCommand ID_CEM_MASG_3PB;
}
}