using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTEMP
	{
	
#region "Upgrade Support "
		private static CORCTEMP m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTEMP DefInstance
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
		public CORCTEMP():base(){
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
			InitializeID_CEM_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTEMP CreateInstance()
	{
			CORCTEMP theInstance = new CORCTEMP();
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
	public  System.Windows.Forms.Button cmdReenvios;
	public  System.Windows.Forms.Button ID_CEM_CMAS_PB;
	public  System.Windows.Forms.ComboBox ID_CEM_GRP_COB;
	public  System.Windows.Forms.ListBox ID_CEM_EMP_LB;
	public  System.Windows.Forms.Button ID_CEM_CAM_PB;
	public  System.Windows.Forms.Button ID_CEM_BAJ_PB;
	public  System.Windows.Forms.Button ID_CEM_ALT_PB;
	public  System.Windows.Forms.Button ID_CEM_CER_PB;
	public  System.Windows.Forms.Button ID_CEM_CON_PB;
        public System.Windows.Forms.Button ID_CEM_MAS_PB;
	public  AxThreed.AxSSCheck ID_CEM_IRA_3CKB;
	public AxThreed.AxSSPanel[] ID_CEM_ETI_PNL = new AxThreed.AxSSPanel[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTEMP));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdReenvios = new System.Windows.Forms.Button();
            this.ID_CEM_CER_PB = new System.Windows.Forms.Button();
            this.ID_CEM_CON_PB = new System.Windows.Forms.Button();
            this.ID_CEM_ALT_PB = new System.Windows.Forms.Button();
            this.ID_CEM_CAM_PB = new System.Windows.Forms.Button();
            this.ID_CEM_BAJ_PB = new System.Windows.Forms.Button();
            this.ID_CEM_IRA_3CKB = new AxThreed.AxSSCheck();
            this.ID_CEM_MAS_PB = new System.Windows.Forms.Button();
            this.ID_CEM_CMAS_PB = new System.Windows.Forms.Button();
            this.ID_CEM_GRP_COB = new System.Windows.Forms.ComboBox();
            this.ID_CEM_EMP_LB = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdCancelaciones = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Grupo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_IRA_3CKB)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdReenvios
            // 
            this.cmdReenvios.BackColor = System.Drawing.SystemColors.Control;
            this.cmdReenvios.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdReenvios.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdReenvios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReenvios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdReenvios.Location = new System.Drawing.Point(434, 148);
            this.cmdReenvios.Name = "cmdReenvios";
            this.cmdReenvios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdReenvios.Size = new System.Drawing.Size(124, 22);
            this.cmdReenvios.TabIndex = 14;
            this.cmdReenvios.Tag = "";
            this.cmdReenvios.Text = "Reenvios";
            this.cmdReenvios.UseVisualStyleBackColor = false;
            this.cmdReenvios.Click += new System.EventHandler(this.cmdReenvios_Click);
            // 
            // ID_CEM_CER_PB
            // 
            this.ID_CEM_CER_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_CEM_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_CER_PB.Location = new System.Drawing.Point(434, 202);
            this.ID_CEM_CER_PB.Name = "ID_CEM_CER_PB";
            this.ID_CEM_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_CER_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_CER_PB.TabIndex = 5;
            this.ID_CEM_CER_PB.Tag = "";
            this.ID_CEM_CER_PB.Text = "&Salir";
            this.ID_CEM_CER_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_CER_PB.Click += new System.EventHandler(this.ID_CEM_CER_PB_Click);
            // 
            // ID_CEM_CON_PB
            // 
            this.ID_CEM_CON_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_CON_PB.Location = new System.Drawing.Point(434, 93);
            this.ID_CEM_CON_PB.Name = "ID_CEM_CON_PB";
            this.ID_CEM_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_CON_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_CON_PB.TabIndex = 3;
            this.ID_CEM_CON_PB.Tag = "B";
            this.ID_CEM_CON_PB.Text = "C&onsulta...";
            this.ID_CEM_CON_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_CON_PB.Click += new System.EventHandler(this.ID_CEM_CON_PB_Click);
            // 
            // ID_CEM_ALT_PB
            // 
            this.ID_CEM_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_ALT_PB.Location = new System.Drawing.Point(434, 38);
            this.ID_CEM_ALT_PB.Name = "ID_CEM_ALT_PB";
            this.ID_CEM_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_ALT_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_ALT_PB.TabIndex = 0;
            this.ID_CEM_ALT_PB.Tag = "A";
            this.ID_CEM_ALT_PB.Text = "&Altas...";
            this.ID_CEM_ALT_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_ALT_PB.Click += new System.EventHandler(this.ID_CEM_ALT_PB_Click);
            // 
            // ID_CEM_CAM_PB
            // 
            this.ID_CEM_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_CAM_PB.Location = new System.Drawing.Point(434, 65);
            this.ID_CEM_CAM_PB.Name = "ID_CEM_CAM_PB";
            this.ID_CEM_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_CAM_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_CAM_PB.TabIndex = 2;
            this.ID_CEM_CAM_PB.Tag = "C";
            this.ID_CEM_CAM_PB.Text = "&Cambios...";
            this.ID_CEM_CAM_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_CAM_PB.Click += new System.EventHandler(this.ID_CEM_CAM_PB_Click);
            // 
            // ID_CEM_BAJ_PB
            // 
            this.ID_CEM_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_BAJ_PB.Enabled = false;
            this.ID_CEM_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_BAJ_PB.Location = new System.Drawing.Point(434, 228);
            this.ID_CEM_BAJ_PB.Name = "ID_CEM_BAJ_PB";
            this.ID_CEM_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_BAJ_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_BAJ_PB.TabIndex = 1;
            this.ID_CEM_BAJ_PB.Tag = "J";
            this.ID_CEM_BAJ_PB.Text = "&Bajas";
            this.ID_CEM_BAJ_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_BAJ_PB.Visible = false;
            this.ID_CEM_BAJ_PB.Click += new System.EventHandler(this.ID_CEM_BAJ_PB_Click);
            // 
            // ID_CEM_IRA_3CKB
            // 
            this.ID_CEM_IRA_3CKB.Location = new System.Drawing.Point(17, 258);
            this.ID_CEM_IRA_3CKB.Name = "ID_CEM_IRA_3CKB";
            this.ID_CEM_IRA_3CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEM_IRA_3CKB.OcxState")));
            this.ID_CEM_IRA_3CKB.Size = new System.Drawing.Size(348, 32);
            this.ID_CEM_IRA_3CKB.TabIndex = 13;
            this.ID_CEM_IRA_3CKB.Tag = "";
            // 
            // ID_CEM_MAS_PB
            // 
            this.ID_CEM_MAS_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_MAS_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_MAS_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_MAS_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_MAS_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_MAS_PB.Location = new System.Drawing.Point(434, 255);
            this.ID_CEM_MAS_PB.Name = "ID_CEM_MAS_PB";
            this.ID_CEM_MAS_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_MAS_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_MAS_PB.TabIndex = 6;
            this.ID_CEM_MAS_PB.Tag = "A";
            this.ID_CEM_MAS_PB.Text = "&Más";
            this.ID_CEM_MAS_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_MAS_PB.Visible = false;
            this.ID_CEM_MAS_PB.Click += new System.EventHandler(this.ID_CEM_MAS_PB_Click);
            // 
            // ID_CEM_CMAS_PB
            // 
            this.ID_CEM_CMAS_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_CMAS_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_CMAS_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_CMAS_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_CMAS_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_CMAS_PB.Location = new System.Drawing.Point(434, 120);
            this.ID_CEM_CMAS_PB.Name = "ID_CEM_CMAS_PB";
            this.ID_CEM_CMAS_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_CMAS_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_CMAS_PB.TabIndex = 4;
            this.ID_CEM_CMAS_PB.Tag = "";
            this.ID_CEM_CMAS_PB.Text = "Pendientes S111...";
            this.ID_CEM_CMAS_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_CMAS_PB.Click += new System.EventHandler(this.ID_CEM_CMAS_PB_Click);
            // 
            // ID_CEM_GRP_COB
            // 
            this.ID_CEM_GRP_COB.BackColor = System.Drawing.Color.White;
            this.ID_CEM_GRP_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_GRP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_CEM_GRP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_GRP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEM_GRP_COB.Location = new System.Drawing.Point(90, 24);
            this.ID_CEM_GRP_COB.Name = "ID_CEM_GRP_COB";
            this.ID_CEM_GRP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_GRP_COB.Size = new System.Drawing.Size(338, 21);
            this.ID_CEM_GRP_COB.Sorted = true;
            this.ID_CEM_GRP_COB.TabIndex = 7;
            this.ID_CEM_GRP_COB.Tag = "";
            this.ID_CEM_GRP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEM_GRP_COB_SelectedIndexChanged);
            // 
            // ID_CEM_EMP_LB
            // 
            this.ID_CEM_EMP_LB.BackColor = System.Drawing.Color.White;
            this.ID_CEM_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_EMP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEM_EMP_LB.Location = new System.Drawing.Point(18, 75);
            this.ID_CEM_EMP_LB.Name = "ID_CEM_EMP_LB";
            this.ID_CEM_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_EMP_LB.Size = new System.Drawing.Size(410, 134);
            this.ID_CEM_EMP_LB.Sorted = true;
            this.ID_CEM_EMP_LB.TabIndex = 8;
            this.ID_CEM_EMP_LB.Tag = "";
            this.ID_CEM_EMP_LB.DoubleClick += new System.EventHandler(this.ID_CEM_EMP_LB_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.cmdCancelaciones);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Grupo);
            this.panel1.Controls.Add(this.ID_CEM_CER_PB);
            this.panel1.Controls.Add(this.ID_CEM_CON_PB);
            this.panel1.Controls.Add(this.ID_CEM_ALT_PB);
            this.panel1.Controls.Add(this.ID_CEM_CAM_PB);
            this.panel1.Controls.Add(this.ID_CEM_BAJ_PB);
            this.panel1.Controls.Add(this.ID_CEM_IRA_3CKB);
            this.panel1.Controls.Add(this.ID_CEM_MAS_PB);
            this.panel1.Controls.Add(this.ID_CEM_CMAS_PB);
            this.panel1.Controls.Add(this.ID_CEM_GRP_COB);
            this.panel1.Controls.Add(this.ID_CEM_EMP_LB);
            this.panel1.Controls.Add(this.cmdReenvios);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 295);
            this.panel1.TabIndex = 15;
            this.panel1.Tag = "";
            // 
            // cmdCancelaciones
            // 
            this.cmdCancelaciones.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelaciones.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdCancelaciones.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancelaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelaciones.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancelaciones.Location = new System.Drawing.Point(434, 175);
            this.cmdCancelaciones.Name = "cmdCancelaciones";
            this.cmdCancelaciones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdCancelaciones.Size = new System.Drawing.Size(124, 22);
            this.cmdCancelaciones.TabIndex = 19;
            this.cmdCancelaciones.Tag = "";
            this.cmdCancelaciones.Text = "Cancelaciones";
            this.cmdCancelaciones.UseVisualStyleBackColor = false;
            this.cmdCancelaciones.Click += new System.EventHandler(this.cmdCancelaciones_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Estatus";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(160, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "&Empresa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Grupo
            // 
            this.Grupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grupo.Location = new System.Drawing.Point(18, 24);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(66, 21);
            this.Grupo.TabIndex = 15;
            this.Grupo.Text = "&Grupo";
            // 
            // CORCTEMP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(563, 297);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(149, 128);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORCTEMP";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Empresas";
            this.Closed += new System.EventHandler(this.CORCTEMP_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_IRA_3CKB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

	}
	void  InitializeID_CEM_ETI_PNL()
	{
            //this.ID_CEM_ETI_PNL[0] = _ID_CEM_ETI_PNL_0;
            //this.ID_CEM_ETI_PNL[7] = _ID_CEM_ETI_PNL_7;
            //this.ID_CEM_ETI_PNL[1] = _ID_CEM_ETI_PNL_1;
	}
#endregion 

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Grupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button cmdCancelaciones;
}
}