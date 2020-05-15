using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORCTUNI
	{
	
#region "Upgrade Support "
		private static CORCTUNI m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTUNI DefInstance
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
		public CORCTUNI():base(){
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
			InitializeID_CEE_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTUNI CreateInstance()
	{
			CORCTUNI theInstance = new CORCTUNI();
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
	public  System.Windows.Forms.Button ID_CEE_CON_TARJ;
	public  System.Windows.Forms.Button ID_CEE_CON_PB;
	public  System.Windows.Forms.Button ID_CEE_SAL_PB;
	public  System.Windows.Forms.Button ID_CEE_ALT_PB;
	public  System.Windows.Forms.Button ID_CEE_BAJ_PB;
	public  System.Windows.Forms.Button ID_CEE_CAM_PB;
	public  System.Windows.Forms.ListBox ID_CEE_UNI_LB;
	public  System.Windows.Forms.ComboBox ID_CEE_GRU_COB;
	public  System.Windows.Forms.ComboBox ID_CEE_EMP_COB;
	private  System.Windows.Forms.Label _ID_CEE_ETI_PNL_1;
        private System.Windows.Forms.Label _ID_CEE_ETI_PNL_0;
        private System.Windows.Forms.Label _ID_CEE_ETI_PNL_7;
        private System.Windows.Forms.Label _ID_CEE_ETI_PNL_2;
	public  AxThreed.AxSSCheck ID_CEE_IRE_CKB;
	public  System.Windows.Forms.Panel ID_CEE_PPL_PNL;
	public System.Windows.Forms.Panel[] ID_CEE_ETI_PNL = new System.Windows.Forms.Panel[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTUNI));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_CEE_PPL_PNL = new System.Windows.Forms.Panel();
        this.ID_CEE_EMP_COB = new System.Windows.Forms.ComboBox();
        this.ID_CEE_GRU_COB = new System.Windows.Forms.ComboBox();
        this.ID_CEE_BAJ_PB = new System.Windows.Forms.Button();
        this.ID_CEE_CAM_PB = new System.Windows.Forms.Button();
        this.ID_CEE_UNI_LB = new System.Windows.Forms.ListBox();
        this._ID_CEE_ETI_PNL_2 = new System.Windows.Forms.Label();
        this.ID_CEE_IRE_CKB = new AxThreed.AxSSCheck();
        this._ID_CEE_ETI_PNL_7 = new System.Windows.Forms.Label();
        this._ID_CEE_ETI_PNL_1 = new System.Windows.Forms.Label();
        this._ID_CEE_ETI_PNL_0 = new System.Windows.Forms.Label();
        this.ID_CEE_CON_PB = new System.Windows.Forms.Button();
        this.ID_CEE_CON_TARJ = new System.Windows.Forms.Button();
        this.ID_CEE_ALT_PB = new System.Windows.Forms.Button();
        this.ID_CEE_SAL_PB = new System.Windows.Forms.Button();
        this.ID_CEE_PPL_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEE_IRE_CKB)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_CEE_PPL_PNL
        // 
        this.ID_CEE_PPL_PNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_EMP_COB);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_GRU_COB);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_BAJ_PB);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_CAM_PB);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_UNI_LB);
        this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_2);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_IRE_CKB);
        this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_7);
        this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_1);
        this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_0);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_CON_PB);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_CON_TARJ);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_ALT_PB);
        this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_SAL_PB);
        this.ID_CEE_PPL_PNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_PPL_PNL.Location = new System.Drawing.Point(0, -2);
        this.ID_CEE_PPL_PNL.Name = "ID_CEE_PPL_PNL";
        this.ID_CEE_PPL_PNL.Size = new System.Drawing.Size(523, 333);
        this.ID_CEE_PPL_PNL.TabIndex = 0;
        this.ID_CEE_PPL_PNL.Tag = "";
        // 
        // ID_CEE_EMP_COB
        // 
        this.ID_CEE_EMP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CEE_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CEE_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEE_EMP_COB.Location = new System.Drawing.Point(114, 44);
        this.ID_CEE_EMP_COB.Name = "ID_CEE_EMP_COB";
        this.ID_CEE_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_EMP_COB.Size = new System.Drawing.Size(208, 21);
        this.ID_CEE_EMP_COB.Sorted = true;
        this.ID_CEE_EMP_COB.TabIndex = 1;
        this.ID_CEE_EMP_COB.Tag = "";
        this.ID_CEE_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEE_EMP_COB_SelectedIndexChanged);
        this.ID_CEE_EMP_COB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ComboBox_KeyPress);
        // 
        // ID_CEE_GRU_COB
        // 
        this.ID_CEE_GRU_COB.BackColor = System.Drawing.Color.White;
        this.ID_CEE_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_GRU_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CEE_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEE_GRU_COB.Location = new System.Drawing.Point(113, 16);
        this.ID_CEE_GRU_COB.Name = "ID_CEE_GRU_COB";
        this.ID_CEE_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_GRU_COB.Size = new System.Drawing.Size(208, 21);
        this.ID_CEE_GRU_COB.Sorted = true;
        this.ID_CEE_GRU_COB.TabIndex = 2;
        this.ID_CEE_GRU_COB.Tag = "";
        this.ID_CEE_GRU_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEE_GRU_COB_SelectedIndexChanged);
        this.ID_CEE_GRU_COB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ComboBox_KeyPress);
        // 
        // ID_CEE_BAJ_PB
        // 
        this.ID_CEE_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_BAJ_PB.Location = new System.Drawing.Point(397, 123);
        this.ID_CEE_BAJ_PB.Name = "ID_CEE_BAJ_PB";
        this.ID_CEE_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_BAJ_PB.Size = new System.Drawing.Size(111, 25);
        this.ID_CEE_BAJ_PB.TabIndex = 5;
        this.ID_CEE_BAJ_PB.Tag = "";
        this.ID_CEE_BAJ_PB.Text = "&Bajas...";
        this.ID_CEE_BAJ_PB.UseVisualStyleBackColor = false;
        this.ID_CEE_BAJ_PB.Click += new System.EventHandler(this.ID_CEE_BAJ_PB_Click);
        // 
        // ID_CEE_CAM_PB
        // 
        this.ID_CEE_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_CAM_PB.Location = new System.Drawing.Point(397, 148);
        this.ID_CEE_CAM_PB.Name = "ID_CEE_CAM_PB";
        this.ID_CEE_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_CAM_PB.Size = new System.Drawing.Size(111, 25);
        this.ID_CEE_CAM_PB.TabIndex = 4;
        this.ID_CEE_CAM_PB.Tag = "";
        this.ID_CEE_CAM_PB.Text = "&Cambios...";
        this.ID_CEE_CAM_PB.UseVisualStyleBackColor = false;
        this.ID_CEE_CAM_PB.Click += new System.EventHandler(this.ID_CEE_CAM_PB_Click);
        // 
        // ID_CEE_UNI_LB
        // 
        this.ID_CEE_UNI_LB.BackColor = System.Drawing.Color.White;
        this.ID_CEE_UNI_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_UNI_LB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_UNI_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEE_UNI_LB.ItemHeight = 14;
        this.ID_CEE_UNI_LB.Location = new System.Drawing.Point(12, 96);
        this.ID_CEE_UNI_LB.Name = "ID_CEE_UNI_LB";
        this.ID_CEE_UNI_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_UNI_LB.Size = new System.Drawing.Size(370, 186);
        this.ID_CEE_UNI_LB.Sorted = true;
        this.ID_CEE_UNI_LB.TabIndex = 3;
        this.ID_CEE_UNI_LB.Tag = "";
        this.ID_CEE_UNI_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CCFmodGeneral.ListBox_KeyPress);
        // 
        // _ID_CEE_ETI_PNL_2
        // 
        this._ID_CEE_ETI_PNL_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this._ID_CEE_ETI_PNL_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEE_ETI_PNL_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEE_ETI_PNL_2.Location = new System.Drawing.Point(139, 73);
        this._ID_CEE_ETI_PNL_2.Name = "_ID_CEE_ETI_PNL_2";
        this._ID_CEE_ETI_PNL_2.Size = new System.Drawing.Size(243, 22);
        this._ID_CEE_ETI_PNL_2.TabIndex = 12;
        this._ID_CEE_ETI_PNL_2.Tag = "";
        this._ID_CEE_ETI_PNL_2.Text = "Unidades";
        this._ID_CEE_ETI_PNL_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_CEE_IRE_CKB
        // 
        this.ID_CEE_IRE_CKB.Location = new System.Drawing.Point(12, 290);
        this.ID_CEE_IRE_CKB.Name = "ID_CEE_IRE_CKB";
        this.ID_CEE_IRE_CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEE_IRE_CKB.OcxState")));
        this.ID_CEE_IRE_CKB.Size = new System.Drawing.Size(200, 20);
        this.ID_CEE_IRE_CKB.TabIndex = 13;
        this.ID_CEE_IRE_CKB.Tag = "";
        // 
        // _ID_CEE_ETI_PNL_7
        // 
        this._ID_CEE_ETI_PNL_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this._ID_CEE_ETI_PNL_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEE_ETI_PNL_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEE_ETI_PNL_7.Location = new System.Drawing.Point(12, 73);
        this._ID_CEE_ETI_PNL_7.Name = "_ID_CEE_ETI_PNL_7";
        this._ID_CEE_ETI_PNL_7.Size = new System.Drawing.Size(126, 22);
        this._ID_CEE_ETI_PNL_7.TabIndex = 11;
        this._ID_CEE_ETI_PNL_7.Tag = "";
        this._ID_CEE_ETI_PNL_7.Text = " No.";
        this._ID_CEE_ETI_PNL_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CEE_ETI_PNL_1
        // 
        this._ID_CEE_ETI_PNL_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this._ID_CEE_ETI_PNL_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEE_ETI_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEE_ETI_PNL_1.Location = new System.Drawing.Point(35, 18);
        this._ID_CEE_ETI_PNL_1.Name = "_ID_CEE_ETI_PNL_1";
        this._ID_CEE_ETI_PNL_1.Size = new System.Drawing.Size(73, 22);
        this._ID_CEE_ETI_PNL_1.TabIndex = 9;
        this._ID_CEE_ETI_PNL_1.Tag = "";
        this._ID_CEE_ETI_PNL_1.Text = " &Grupo";
        // 
        // _ID_CEE_ETI_PNL_0
        // 
        this._ID_CEE_ETI_PNL_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        this._ID_CEE_ETI_PNL_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEE_ETI_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEE_ETI_PNL_0.Location = new System.Drawing.Point(35, 42);
        this._ID_CEE_ETI_PNL_0.Name = "_ID_CEE_ETI_PNL_0";
        this._ID_CEE_ETI_PNL_0.Size = new System.Drawing.Size(73, 22);
        this._ID_CEE_ETI_PNL_0.TabIndex = 10;
        this._ID_CEE_ETI_PNL_0.Tag = "";
        this._ID_CEE_ETI_PNL_0.Text = " &Empresa";
        // 
        // ID_CEE_CON_PB
        // 
        this.ID_CEE_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_CON_PB.Location = new System.Drawing.Point(397, 173);
        this.ID_CEE_CON_PB.Name = "ID_CEE_CON_PB";
        this.ID_CEE_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_CON_PB.Size = new System.Drawing.Size(111, 25);
        this.ID_CEE_CON_PB.TabIndex = 8;
        this.ID_CEE_CON_PB.Tag = "";
        this.ID_CEE_CON_PB.Text = "C&onsultas...";
        this.ID_CEE_CON_PB.UseVisualStyleBackColor = false;
        this.ID_CEE_CON_PB.Click += new System.EventHandler(this.ID_CEE_CON_PB_Click);
        // 
        // ID_CEE_CON_TARJ
        // 
        this.ID_CEE_CON_TARJ.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_CON_TARJ.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_CON_TARJ.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_CON_TARJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_CON_TARJ.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_CON_TARJ.Location = new System.Drawing.Point(397, 198);
        this.ID_CEE_CON_TARJ.Name = "ID_CEE_CON_TARJ";
        this.ID_CEE_CON_TARJ.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_CON_TARJ.Size = new System.Drawing.Size(111, 41);
        this.ID_CEE_CON_TARJ.TabIndex = 14;
        this.ID_CEE_CON_TARJ.Tag = "";
        this.ID_CEE_CON_TARJ.Text = "TarjetaHabientes Asignados";
        this.ID_CEE_CON_TARJ.UseVisualStyleBackColor = false;
        this.ID_CEE_CON_TARJ.Click += new System.EventHandler(this.ID_CEE_CON_TARJ_Click);
        // 
        // ID_CEE_ALT_PB
        // 
        this.ID_CEE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_ALT_PB.Location = new System.Drawing.Point(397, 98);
        this.ID_CEE_ALT_PB.Name = "ID_CEE_ALT_PB";
        this.ID_CEE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_ALT_PB.Size = new System.Drawing.Size(111, 25);
        this.ID_CEE_ALT_PB.TabIndex = 6;
        this.ID_CEE_ALT_PB.Tag = "";
        this.ID_CEE_ALT_PB.Text = "&Altas...";
        this.ID_CEE_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_CEE_ALT_PB.Click += new System.EventHandler(this.ID_CEE_ALT_PB_Click);
        // 
        // ID_CEE_SAL_PB
        // 
        this.ID_CEE_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CEE_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_CEE_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CEE_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CEE_SAL_PB.Location = new System.Drawing.Point(397, 256);
        this.ID_CEE_SAL_PB.Name = "ID_CEE_SAL_PB";
        this.ID_CEE_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_SAL_PB.Size = new System.Drawing.Size(111, 25);
        this.ID_CEE_SAL_PB.TabIndex = 7;
        this.ID_CEE_SAL_PB.Tag = "";
        this.ID_CEE_SAL_PB.Text = "&Salir";
        this.ID_CEE_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_CEE_SAL_PB.Click += new System.EventHandler(this.ID_CEE_SAL_PB_Click);
        // 
        // CORCTUNI
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.ID_CEE_SAL_PB;
        this.ClientSize = new System.Drawing.Size(522, 330);
        this.Controls.Add(this.ID_CEE_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(136, 218);
        this.MaximizeBox = false;
        this.Name = "CORCTUNI";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Unidades";
        this.Closed += new System.EventHandler(this.CORCTUNI_Closed);
        this.Shown += new System.EventHandler(this.CORCTUNI_Shown);
        this.Activated += new System.EventHandler(this.CORCTUNI_Activated);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CORCTUNI_FormClosing);
        this.ID_CEE_PPL_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEE_IRE_CKB)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_CEE_ETI_PNL()
	{
            //this.ID_CEE_ETI_PNL[1] = _ID_CEE_ETI_PNL_1;
            //this.ID_CEE_ETI_PNL[0] = _ID_CEE_ETI_PNL_0;
            //this.ID_CEE_ETI_PNL[7] = _ID_CEE_ETI_PNL_7;
            //this.ID_CEE_ETI_PNL[2] = _ID_CEE_ETI_PNL_2;
	}
#endregion 
}
}