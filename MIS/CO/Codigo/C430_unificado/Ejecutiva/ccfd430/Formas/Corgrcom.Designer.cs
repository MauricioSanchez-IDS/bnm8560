using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORGRCOM
	{
	
#region "Upgrade Support "
		private static CORGRCOM m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRCOM DefInstance
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
		public CORGRCOM():base(){
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
			InitializeID_COM_GRA_GPB();
			InitializeID_COM_ETI_TXT();
		}
	public static CORGRCOM CreateInstance()
	{
			CORGRCOM theInstance = new CORGRCOM();
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
	public  System.Windows.Forms.ComboBox ID_COM_PER_COB;
	public  System.Windows.Forms.ComboBox ID_COM_INF_COB;
	public  System.Windows.Forms.ComboBox ID_COM_CON_COB;
	public  System.Windows.Forms.ComboBox ID_COM_NIV_COB;
	public  AxThreed.AxSSCheck ID_COM_INF_CKB;
	private  System.Windows.Forms.Label _ID_COM_ETI_TXT_1;
	private  System.Windows.Forms.Label _ID_COM_ETI_TXT_2;
	private  System.Windows.Forms.Label _ID_COM_ETI_TXT_3;
	private  System.Windows.Forms.Label _ID_COM_ETI_TXT_4;
	public  AxThreed.AxSSPanel ID_COM_PRI_PNL;
	public  System.Windows.Forms.Button ID_COM_IMP_PB;
	public  System.Windows.Forms.Button ID_COM_SAL_PB;
	public  System.Windows.Forms.Button ID_COM_GRA_PB;
	private  AxThreed.AxSSRibbon _ID_COM_GRA_GPB_3;
	private  AxThreed.AxSSRibbon _ID_COM_GRA_GPB_2;
	private  AxThreed.AxSSRibbon _ID_COM_GRA_GPB_1;
	private  AxThreed.AxSSRibbon _ID_COM_GRA_GPB_0;
	public  AxThreed.AxSSPanel ID_COM_GRP_PNL;
	public  AxGraphLib.AxGraph ID_COM_GPH;
	public  AxThreed.AxSSPanel ID_COM_PRI1_PNL;
	public System.Windows.Forms.Label[] ID_COM_ETI_TXT = new System.Windows.Forms.Label[5];
	public AxThreed.AxSSRibbon[] ID_COM_GRA_GPB = new AxThreed.AxSSRibbon[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRCOM));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_COM_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_COM_INF_CKB = new AxThreed.AxSSCheck();
        this.ID_COM_NIV_COB = new System.Windows.Forms.ComboBox();
        this.ID_COM_CON_COB = new System.Windows.Forms.ComboBox();
        this._ID_COM_ETI_TXT_1 = new System.Windows.Forms.Label();
        this._ID_COM_ETI_TXT_4 = new System.Windows.Forms.Label();
        this._ID_COM_ETI_TXT_3 = new System.Windows.Forms.Label();
        this._ID_COM_ETI_TXT_2 = new System.Windows.Forms.Label();
        this.ID_COM_INF_COB = new System.Windows.Forms.ComboBox();
        this.ID_COM_PER_COB = new System.Windows.Forms.ComboBox();
        this.ID_COM_PRI1_PNL = new AxThreed.AxSSPanel();
        this.ID_COM_GRA_PB = new System.Windows.Forms.Button();
        this.ID_COM_SAL_PB = new System.Windows.Forms.Button();
        this.ID_COM_IMP_PB = new System.Windows.Forms.Button();
        this.ID_COM_GPH = new AxGraphLib.AxGraph();
        this.ID_COM_GRP_PNL = new AxThreed.AxSSPanel();
        this._ID_COM_GRA_GPB_2 = new AxThreed.AxSSRibbon();
        this._ID_COM_GRA_GPB_3 = new AxThreed.AxSSRibbon();
        this._ID_COM_GRA_GPB_0 = new AxThreed.AxSSRibbon();
        this._ID_COM_GRA_GPB_1 = new AxThreed.AxSSRibbon();
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_PRI_PNL)).BeginInit();
        this.ID_COM_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_INF_CKB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_PRI1_PNL)).BeginInit();
        this.ID_COM_PRI1_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_GPH)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_GRP_PNL)).BeginInit();
        this.ID_COM_GRP_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_COM_GRA_GPB_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_COM_GRA_GPB_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_COM_GRA_GPB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_COM_GRA_GPB_1)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_COM_PRI_PNL
        // 
        this.ID_COM_PRI_PNL.Controls.Add(this.ID_COM_INF_CKB);
        this.ID_COM_PRI_PNL.Controls.Add(this.ID_COM_NIV_COB);
        this.ID_COM_PRI_PNL.Controls.Add(this.ID_COM_CON_COB);
        this.ID_COM_PRI_PNL.Controls.Add(this._ID_COM_ETI_TXT_1);
        this.ID_COM_PRI_PNL.Controls.Add(this._ID_COM_ETI_TXT_4);
        this.ID_COM_PRI_PNL.Controls.Add(this._ID_COM_ETI_TXT_3);
        this.ID_COM_PRI_PNL.Controls.Add(this._ID_COM_ETI_TXT_2);
        this.ID_COM_PRI_PNL.Controls.Add(this.ID_COM_INF_COB);
        this.ID_COM_PRI_PNL.Controls.Add(this.ID_COM_PER_COB);
        this.ID_COM_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_COM_PRI_PNL.Name = "ID_COM_PRI_PNL";
        this.ID_COM_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COM_PRI_PNL.OcxState")));
        this.ID_COM_PRI_PNL.Size = new System.Drawing.Size(595, 67);
        this.ID_COM_PRI_PNL.TabIndex = 0;
        this.ID_COM_PRI_PNL.Tag = "";
        // 
        // ID_COM_INF_CKB
        // 
        this.ID_COM_INF_CKB.Location = new System.Drawing.Point(545, 39);
        this.ID_COM_INF_CKB.Name = "ID_COM_INF_CKB";
        this.ID_COM_INF_CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COM_INF_CKB.OcxState")));
        this.ID_COM_INF_CKB.Size = new System.Drawing.Size(40, 13);
        this.ID_COM_INF_CKB.TabIndex = 6;
        this.ID_COM_INF_CKB.Tag = "";
        // 
        // ID_COM_NIV_COB
        // 
        this.ID_COM_NIV_COB.BackColor = System.Drawing.Color.White;
        this.ID_COM_NIV_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_COM_NIV_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_COM_NIV_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_COM_NIV_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_COM_NIV_COB.Location = new System.Drawing.Point(77, 10);
        this.ID_COM_NIV_COB.Name = "ID_COM_NIV_COB";
        this.ID_COM_NIV_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_COM_NIV_COB.Size = new System.Drawing.Size(180, 21);
        this.ID_COM_NIV_COB.TabIndex = 9;
        this.ID_COM_NIV_COB.Tag = "";
        this.ID_COM_NIV_COB.SelectedIndexChanged += new System.EventHandler(this.ID_COM_NIV_COB_SelectedIndexChanged);
        // 
        // ID_COM_CON_COB
        // 
        this.ID_COM_CON_COB.BackColor = System.Drawing.Color.White;
        this.ID_COM_CON_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_COM_CON_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_COM_CON_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_COM_CON_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_COM_CON_COB.Location = new System.Drawing.Point(76, 35);
        this.ID_COM_CON_COB.Name = "ID_COM_CON_COB";
        this.ID_COM_CON_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_COM_CON_COB.Size = new System.Drawing.Size(180, 21);
        this.ID_COM_CON_COB.TabIndex = 10;
        this.ID_COM_CON_COB.Tag = "";
        this.ID_COM_CON_COB.SelectedIndexChanged += new System.EventHandler(this.ID_COM_CON_COB_SelectedIndexChanged);
        // 
        // _ID_COM_ETI_TXT_1
        // 
        this._ID_COM_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
        this._ID_COM_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_COM_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_COM_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_COM_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_COM_ETI_TXT_1.Location = new System.Drawing.Point(19, 13);
        this._ID_COM_ETI_TXT_1.Name = "_ID_COM_ETI_TXT_1";
        this._ID_COM_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_COM_ETI_TXT_1.Size = new System.Drawing.Size(37, 15);
        this._ID_COM_ETI_TXT_1.TabIndex = 8;
        this._ID_COM_ETI_TXT_1.Tag = "";
        this._ID_COM_ETI_TXT_1.Text = "&Nivel";
        // 
        // _ID_COM_ETI_TXT_4
        // 
        this._ID_COM_ETI_TXT_4.BackColor = System.Drawing.Color.Silver;
        this._ID_COM_ETI_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_COM_ETI_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_COM_ETI_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_COM_ETI_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_COM_ETI_TXT_4.Location = new System.Drawing.Point(263, 38);
        this._ID_COM_ETI_TXT_4.Name = "_ID_COM_ETI_TXT_4";
        this._ID_COM_ETI_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_COM_ETI_TXT_4.Size = new System.Drawing.Size(49, 15);
        this._ID_COM_ETI_TXT_4.TabIndex = 4;
        this._ID_COM_ETI_TXT_4.Tag = "";
        this._ID_COM_ETI_TXT_4.Text = "&Periodo";
        // 
        // _ID_COM_ETI_TXT_3
        // 
        this._ID_COM_ETI_TXT_3.BackColor = System.Drawing.Color.Silver;
        this._ID_COM_ETI_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_COM_ETI_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_COM_ETI_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_COM_ETI_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_COM_ETI_TXT_3.Location = new System.Drawing.Point(19, 38);
        this._ID_COM_ETI_TXT_3.Name = "_ID_COM_ETI_TXT_3";
        this._ID_COM_ETI_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_COM_ETI_TXT_3.Size = new System.Drawing.Size(59, 15);
        this._ID_COM_ETI_TXT_3.TabIndex = 5;
        this._ID_COM_ETI_TXT_3.Tag = "";
        this._ID_COM_ETI_TXT_3.Text = "&Concepto";
        // 
        // _ID_COM_ETI_TXT_2
        // 
        this._ID_COM_ETI_TXT_2.BackColor = System.Drawing.Color.Silver;
        this._ID_COM_ETI_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_COM_ETI_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_COM_ETI_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_COM_ETI_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_COM_ETI_TXT_2.Location = new System.Drawing.Point(263, 12);
        this._ID_COM_ETI_TXT_2.Name = "_ID_COM_ETI_TXT_2";
        this._ID_COM_ETI_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_COM_ETI_TXT_2.Size = new System.Drawing.Size(53, 15);
        this._ID_COM_ETI_TXT_2.TabIndex = 7;
        this._ID_COM_ETI_TXT_2.Tag = "";
        this._ID_COM_ETI_TXT_2.Text = "&Empresa";
        // 
        // ID_COM_INF_COB
        // 
        this.ID_COM_INF_COB.BackColor = System.Drawing.Color.White;
        this.ID_COM_INF_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_COM_INF_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_COM_INF_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_COM_INF_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_COM_INF_COB.Location = new System.Drawing.Point(317, 8);
        this.ID_COM_INF_COB.Name = "ID_COM_INF_COB";
        this.ID_COM_INF_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_COM_INF_COB.Size = new System.Drawing.Size(240, 21);
        this.ID_COM_INF_COB.TabIndex = 11;
        this.ID_COM_INF_COB.Tag = "";
        this.ID_COM_INF_COB.SelectedIndexChanged += new System.EventHandler(this.ID_COM_INF_COB_SelectedIndexChanged);
        // 
        // ID_COM_PER_COB
        // 
        this.ID_COM_PER_COB.BackColor = System.Drawing.Color.White;
        this.ID_COM_PER_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_COM_PER_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_COM_PER_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_COM_PER_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_COM_PER_COB.Location = new System.Drawing.Point(317, 32);
        this.ID_COM_PER_COB.Name = "ID_COM_PER_COB";
        this.ID_COM_PER_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_COM_PER_COB.Size = new System.Drawing.Size(221, 21);
        this.ID_COM_PER_COB.TabIndex = 12;
        this.ID_COM_PER_COB.Tag = "";
        this.ID_COM_PER_COB.SelectedIndexChanged += new System.EventHandler(this.ID_COM_PER_COB_SelectedIndexChanged);
        // 
        // ID_COM_PRI1_PNL
        // 
        this.ID_COM_PRI1_PNL.Controls.Add(this.ID_COM_GRA_PB);
        this.ID_COM_PRI1_PNL.Controls.Add(this.ID_COM_SAL_PB);
        this.ID_COM_PRI1_PNL.Controls.Add(this.ID_COM_IMP_PB);
        this.ID_COM_PRI1_PNL.Controls.Add(this.ID_COM_GPH);
        this.ID_COM_PRI1_PNL.Controls.Add(this.ID_COM_GRP_PNL);
        this.ID_COM_PRI1_PNL.Location = new System.Drawing.Point(0, 66);
        this.ID_COM_PRI1_PNL.Name = "ID_COM_PRI1_PNL";
        this.ID_COM_PRI1_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COM_PRI1_PNL.OcxState")));
        this.ID_COM_PRI1_PNL.Size = new System.Drawing.Size(595, 289);
        this.ID_COM_PRI1_PNL.TabIndex = 13;
        this.ID_COM_PRI1_PNL.Tag = "";
        // 
        // ID_COM_GRA_PB
        // 
        this.ID_COM_GRA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_COM_GRA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_COM_GRA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_COM_GRA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_COM_GRA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_COM_GRA_PB.Location = new System.Drawing.Point(363, 250);
        this.ID_COM_GRA_PB.Name = "ID_COM_GRA_PB";
        this.ID_COM_GRA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_COM_GRA_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_COM_GRA_PB.TabIndex = 1;
        this.ID_COM_GRA_PB.Tag = "";
        this.ID_COM_GRA_PB.Text = "&Graficar";
        this.ID_COM_GRA_PB.UseVisualStyleBackColor = false;
        this.ID_COM_GRA_PB.Click += new System.EventHandler(this.ID_COM_GRA_PB_Click);
        // 
        // ID_COM_SAL_PB
        // 
        this.ID_COM_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_COM_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_COM_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_COM_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_COM_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_COM_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_COM_SAL_PB.Location = new System.Drawing.Point(507, 250);
        this.ID_COM_SAL_PB.Name = "ID_COM_SAL_PB";
        this.ID_COM_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_COM_SAL_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_COM_SAL_PB.TabIndex = 2;
        this.ID_COM_SAL_PB.Tag = "";
        this.ID_COM_SAL_PB.Text = "Cerrar";
        this.ID_COM_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_COM_SAL_PB.Click += new System.EventHandler(this.ID_COM_SAL_PB_Click);
        // 
        // ID_COM_IMP_PB
        // 
        this.ID_COM_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_COM_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_COM_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_COM_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_COM_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_COM_IMP_PB.Location = new System.Drawing.Point(435, 250);
        this.ID_COM_IMP_PB.Name = "ID_COM_IMP_PB";
        this.ID_COM_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_COM_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_COM_IMP_PB.TabIndex = 3;
        this.ID_COM_IMP_PB.Tag = "";
        this.ID_COM_IMP_PB.Text = "&Imprimir";
        this.ID_COM_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_COM_IMP_PB.Click += new System.EventHandler(this.ID_COM_IMP_PB_Click);
        // 
        // ID_COM_GPH
        // 
        this.ID_COM_GPH.Location = new System.Drawing.Point(30, 16);
        this.ID_COM_GPH.Name = "ID_COM_GPH";
        this.ID_COM_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COM_GPH.OcxState")));
        this.ID_COM_GPH.Size = new System.Drawing.Size(551, 217);
        this.ID_COM_GPH.TabIndex = 14;
        this.ID_COM_GPH.Tag = "";
        this.ID_COM_GPH.DblClick += new System.EventHandler(this.ID_COM_GPH_DblClick);
        // 
        // ID_COM_GRP_PNL
        // 
        this.ID_COM_GRP_PNL.Controls.Add(this._ID_COM_GRA_GPB_2);
        this.ID_COM_GRP_PNL.Controls.Add(this._ID_COM_GRA_GPB_3);
        this.ID_COM_GRP_PNL.Controls.Add(this._ID_COM_GRA_GPB_0);
        this.ID_COM_GRP_PNL.Controls.Add(this._ID_COM_GRA_GPB_1);
        this.ID_COM_GRP_PNL.Location = new System.Drawing.Point(22, 240);
        this.ID_COM_GRP_PNL.Name = "ID_COM_GRP_PNL";
        this.ID_COM_GRP_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COM_GRP_PNL.OcxState")));
        this.ID_COM_GRP_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_COM_GRP_PNL.TabIndex = 16;
        this.ID_COM_GRP_PNL.Tag = "";
        // 
        // _ID_COM_GRA_GPB_2
        // 
        this._ID_COM_GRA_GPB_2.Location = new System.Drawing.Point(76, 4);
        this._ID_COM_GRA_GPB_2.Name = "_ID_COM_GRA_GPB_2";
        this._ID_COM_GRA_GPB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_COM_GRA_GPB_2.OcxState")));
        this._ID_COM_GRA_GPB_2.Size = new System.Drawing.Size(37, 33);
        this._ID_COM_GRA_GPB_2.TabIndex = 18;
        this._ID_COM_GRA_GPB_2.Tag = "";
        this._ID_COM_GRA_GPB_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_COM_GRA_GPB_ClickEvent);
        // 
        // _ID_COM_GRA_GPB_3
        // 
        this._ID_COM_GRA_GPB_3.Location = new System.Drawing.Point(112, 4);
        this._ID_COM_GRA_GPB_3.Name = "_ID_COM_GRA_GPB_3";
        this._ID_COM_GRA_GPB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_COM_GRA_GPB_3.OcxState")));
        this._ID_COM_GRA_GPB_3.Size = new System.Drawing.Size(37, 33);
        this._ID_COM_GRA_GPB_3.TabIndex = 19;
        this._ID_COM_GRA_GPB_3.Tag = "";
        this._ID_COM_GRA_GPB_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_COM_GRA_GPB_ClickEvent);
        // 
        // _ID_COM_GRA_GPB_0
        // 
        this._ID_COM_GRA_GPB_0.Location = new System.Drawing.Point(4, 4);
        this._ID_COM_GRA_GPB_0.Name = "_ID_COM_GRA_GPB_0";
        this._ID_COM_GRA_GPB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_COM_GRA_GPB_0.OcxState")));
        this._ID_COM_GRA_GPB_0.Size = new System.Drawing.Size(37, 33);
        this._ID_COM_GRA_GPB_0.TabIndex = 15;
        this._ID_COM_GRA_GPB_0.Tag = "";
        this._ID_COM_GRA_GPB_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_COM_GRA_GPB_ClickEvent);
        // 
        // _ID_COM_GRA_GPB_1
        // 
        this._ID_COM_GRA_GPB_1.Location = new System.Drawing.Point(40, 4);
        this._ID_COM_GRA_GPB_1.Name = "_ID_COM_GRA_GPB_1";
        this._ID_COM_GRA_GPB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_COM_GRA_GPB_1.OcxState")));
        this._ID_COM_GRA_GPB_1.Size = new System.Drawing.Size(37, 33);
        this._ID_COM_GRA_GPB_1.TabIndex = 17;
        this._ID_COM_GRA_GPB_1.Tag = "";
        this._ID_COM_GRA_GPB_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_COM_GRA_GPB_ClickEvent);
        // 
        // CORGRCOM
        // 
        this.AcceptButton = this.ID_COM_GRA_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_COM_SAL_PB;
        this.ClientSize = new System.Drawing.Size(595, 355);
        this.Controls.Add(this.ID_COM_PRI1_PNL);
        this.Controls.Add(this.ID_COM_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(179, 109);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRCOM";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Comparativos";
        this.Closed += new System.EventHandler(this.CORGRCOM_Closed);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORGRCOM_KeyPress);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CORGRCOM_KeyDown);
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_PRI_PNL)).EndInit();
        this.ID_COM_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_INF_CKB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_PRI1_PNL)).EndInit();
        this.ID_COM_PRI1_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_GPH)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_COM_GRP_PNL)).EndInit();
        this.ID_COM_GRP_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_COM_GRA_GPB_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_COM_GRA_GPB_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_COM_GRA_GPB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_COM_GRA_GPB_1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_COM_GRA_GPB()
	{
			this.ID_COM_GRA_GPB[3] = _ID_COM_GRA_GPB_3;
			this.ID_COM_GRA_GPB[2] = _ID_COM_GRA_GPB_2;
			this.ID_COM_GRA_GPB[1] = _ID_COM_GRA_GPB_1;
			this.ID_COM_GRA_GPB[0] = _ID_COM_GRA_GPB_0;
	}
	void  InitializeID_COM_ETI_TXT()
	{
			this.ID_COM_ETI_TXT[1] = _ID_COM_ETI_TXT_1;
			this.ID_COM_ETI_TXT[2] = _ID_COM_ETI_TXT_2;
			this.ID_COM_ETI_TXT[3] = _ID_COM_ETI_TXT_3;
			this.ID_COM_ETI_TXT[4] = _ID_COM_ETI_TXT_4;
	}
#endregion 
}
}