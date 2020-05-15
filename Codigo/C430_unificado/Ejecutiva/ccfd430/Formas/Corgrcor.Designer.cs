using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORGRCOR
	{
	
#region "Upgrade Support "
		private static CORGRCOR m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRCOR DefInstance
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
		public CORGRCOR():base(){
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
			InitializeID_GRA_ETI_TXT();
			InitializeID_GRA_B3D_GPB();
		}
	public static CORGRCOR CreateInstance()
	{
			CORGRCOR theInstance = new CORGRCOR();
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
	public  System.Windows.Forms.Button ID_GRA_MAS_PB;
	public  System.Windows.Forms.ComboBox ID_GRA_GRU_COB;
	public  System.Windows.Forms.ComboBox ID_GRA_PAR_COB;
	public  AxThreed.AxSSCheck ID_GRA_IRA_3CKB;
	private  System.Windows.Forms.Label _ID_GRA_ETI_TXT_1;
	public  System.Windows.Forms.Label ID_BIT_GRU_TXT;
	public  System.Windows.Forms.Label ID_GRA_PAR_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_GRA_PAR_PNL;
	public  System.Windows.Forms.Button ID_GRA_IMP_PB;
	public  System.Windows.Forms.Button ID_GRA_GFC_PB;
	public  System.Windows.Forms.Button ID_GRA_CAN_PB;
	private  AxThreed.AxSSRibbon _ID_GRA_B3D_GPB_0;
	private  AxThreed.AxSSRibbon _ID_GRA_B3D_GPB_1;
	private  AxThreed.AxSSRibbon _ID_GRA_B3D_GPB_2;
	private  AxThreed.AxSSRibbon _ID_GRA_B3D_GPB_3;
	public  AxThreed.AxSSPanel ID_GRA_TIPO_PNL;
	public  AxGraphLib.AxGraph ID_GRA_GPH;
	public  AxThreed.AxSSPanel ID_GRA_PPL_PNL;
	public AxThreed.AxSSRibbon[] ID_GRA_B3D_GPB = new AxThreed.AxSSRibbon[4];
	public System.Windows.Forms.Label[] ID_GRA_ETI_TXT = new System.Windows.Forms.Label[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRCOR));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_GRA_PAR_PNL = new AxThreed.AxSSPanel();
        this.ID_GRA_IRA_3CKB = new AxThreed.AxSSCheck();
        this.ID_GRA_PAR_COB = new System.Windows.Forms.ComboBox();
        this.ID_GRA_GRU_COB = new System.Windows.Forms.ComboBox();
        this.ID_GRA_PAR_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_BIT_GRU_TXT = new System.Windows.Forms.Label();
        this._ID_GRA_ETI_TXT_1 = new System.Windows.Forms.Label();
        this.ID_GRA_MAS_PB = new System.Windows.Forms.Button();
        this.ID_GRA_PPL_PNL = new AxThreed.AxSSPanel();
        this.ID_GRA_CAN_PB = new System.Windows.Forms.Button();
        this.ID_GRA_GFC_PB = new System.Windows.Forms.Button();
        this.ID_GRA_IMP_PB = new System.Windows.Forms.Button();
        this.ID_GRA_GPH = new AxGraphLib.AxGraph();
        this.ID_GRA_TIPO_PNL = new AxThreed.AxSSPanel();
        this._ID_GRA_B3D_GPB_1 = new AxThreed.AxSSRibbon();
        this._ID_GRA_B3D_GPB_0 = new AxThreed.AxSSRibbon();
        this._ID_GRA_B3D_GPB_3 = new AxThreed.AxSSRibbon();
        this._ID_GRA_B3D_GPB_2 = new AxThreed.AxSSRibbon();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PAR_PNL)).BeginInit();
        this.ID_GRA_PAR_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_IRA_3CKB)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PPL_PNL)).BeginInit();
        this.ID_GRA_PPL_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GPH)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_TIPO_PNL)).BeginInit();
        this.ID_GRA_TIPO_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_B3D_GPB_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_B3D_GPB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_B3D_GPB_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_B3D_GPB_2)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_GRA_PAR_PNL
        // 
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_GRA_IRA_3CKB);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_GRA_PAR_COB);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_GRA_GRU_COB);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_GRA_PAR_PNLLabel_Text);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_BIT_GRU_TXT);
        this.ID_GRA_PAR_PNL.Controls.Add(this._ID_GRA_ETI_TXT_1);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_GRA_MAS_PB);
        this.ID_GRA_PAR_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_PAR_PNL.Name = "ID_GRA_PAR_PNL";
        this.ID_GRA_PAR_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PAR_PNL.OcxState")));
        this.ID_GRA_PAR_PNL.Size = new System.Drawing.Size(549, 57);
        this.ID_GRA_PAR_PNL.TabIndex = 0;
        this.ID_GRA_PAR_PNL.Tag = "";
        // 
        // ID_GRA_IRA_3CKB
        // 
        this.ID_GRA_IRA_3CKB.Location = new System.Drawing.Point(507, 32);
        this.ID_GRA_IRA_3CKB.Name = "ID_GRA_IRA_3CKB";
        this.ID_GRA_IRA_3CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_IRA_3CKB.OcxState")));
        this.ID_GRA_IRA_3CKB.Size = new System.Drawing.Size(36, 15);
        this.ID_GRA_IRA_3CKB.TabIndex = 4;
        this.ID_GRA_IRA_3CKB.Tag = "";
        // 
        // ID_GRA_PAR_COB
        // 
        this.ID_GRA_PAR_COB.BackColor = System.Drawing.Color.White;
        this.ID_GRA_PAR_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_PAR_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_GRA_PAR_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_PAR_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_GRA_PAR_COB.Location = new System.Drawing.Point(43, 25);
        this.ID_GRA_PAR_COB.Name = "ID_GRA_PAR_COB";
        this.ID_GRA_PAR_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_PAR_COB.Size = new System.Drawing.Size(186, 21);
        this.ID_GRA_PAR_COB.TabIndex = 9;
        this.ID_GRA_PAR_COB.Tag = "";
        this.ID_GRA_PAR_COB.SelectedIndexChanged += new System.EventHandler(this.ID_GRA_PAR_COB_SelectedIndexChanged);
        // 
        // ID_GRA_GRU_COB
        // 
        this.ID_GRA_GRU_COB.BackColor = System.Drawing.Color.White;
        this.ID_GRA_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_GRU_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_GRA_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_GRA_GRU_COB.Location = new System.Drawing.Point(280, 25);
        this.ID_GRA_GRU_COB.Name = "ID_GRA_GRU_COB";
        this.ID_GRA_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_GRU_COB.Size = new System.Drawing.Size(225, 21);
        this.ID_GRA_GRU_COB.TabIndex = 10;
        this.ID_GRA_GRU_COB.Tag = "";
        this.ID_GRA_GRU_COB.SelectedIndexChanged += new System.EventHandler(this.ID_GRA_GRU_COB_SelectedIndexChanged);
        // 
        // ID_GRA_PAR_PNLLabel_Text
        // 
        this.ID_GRA_PAR_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_PAR_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_PAR_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_GRA_PAR_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_PAR_PNLLabel_Text.Name = "ID_GRA_PAR_PNLLabel_Text";
        this.ID_GRA_PAR_PNLLabel_Text.Size = new System.Drawing.Size(549, 57);
        this.ID_GRA_PAR_PNLLabel_Text.TabIndex = 11;
        this.ID_GRA_PAR_PNLLabel_Text.Tag = "";
        this.ID_GRA_PAR_PNLLabel_Text.Text = " Parámetros a Graficar";
        // 
        // ID_BIT_GRU_TXT
        // 
        this.ID_BIT_GRU_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_BIT_GRU_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_BIT_GRU_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_BIT_GRU_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_BIT_GRU_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_BIT_GRU_TXT.Location = new System.Drawing.Point(234, 29);
        this.ID_BIT_GRU_TXT.Name = "ID_BIT_GRU_TXT";
        this.ID_BIT_GRU_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_BIT_GRU_TXT.Size = new System.Drawing.Size(45, 15);
        this.ID_BIT_GRU_TXT.TabIndex = 6;
        this.ID_BIT_GRU_TXT.Tag = "";
        this.ID_BIT_GRU_TXT.Text = "&Grupos";
        // 
        // _ID_GRA_ETI_TXT_1
        // 
        this._ID_GRA_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
        this._ID_GRA_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_GRA_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_GRA_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_GRA_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_GRA_ETI_TXT_1.Location = new System.Drawing.Point(9, 27);
        this._ID_GRA_ETI_TXT_1.Name = "_ID_GRA_ETI_TXT_1";
        this._ID_GRA_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_GRA_ETI_TXT_1.Size = new System.Drawing.Size(28, 15);
        this._ID_GRA_ETI_TXT_1.TabIndex = 8;
        this._ID_GRA_ETI_TXT_1.Tag = "";
        this._ID_GRA_ETI_TXT_1.Text = "&Tipo";
        // 
        // ID_GRA_MAS_PB
        // 
        this.ID_GRA_MAS_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_MAS_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_MAS_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_MAS_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_MAS_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_MAS_PB.Location = new System.Drawing.Point(231, 26);
        this.ID_GRA_MAS_PB.Name = "ID_GRA_MAS_PB";
        this.ID_GRA_MAS_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_MAS_PB.Size = new System.Drawing.Size(22, 20);
        this.ID_GRA_MAS_PB.TabIndex = 16;
        this.ID_GRA_MAS_PB.Tag = "";
        this.ID_GRA_MAS_PB.Text = "...";
        this.ID_GRA_MAS_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_MAS_PB.Click += new System.EventHandler(this.ID_GRA_MAS_PB_Click);
        // 
        // ID_GRA_PPL_PNL
        // 
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_CAN_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_GFC_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_IMP_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_GPH);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_TIPO_PNL);
        this.ID_GRA_PPL_PNL.Location = new System.Drawing.Point(0, 56);
        this.ID_GRA_PPL_PNL.Name = "ID_GRA_PPL_PNL";
        this.ID_GRA_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PPL_PNL.OcxState")));
        this.ID_GRA_PPL_PNL.Size = new System.Drawing.Size(549, 285);
        this.ID_GRA_PPL_PNL.TabIndex = 5;
        this.ID_GRA_PPL_PNL.Tag = "";
        // 
        // ID_GRA_CAN_PB
        // 
        this.ID_GRA_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_GRA_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_CAN_PB.Location = new System.Drawing.Point(455, 250);
        this.ID_GRA_CAN_PB.Name = "ID_GRA_CAN_PB";
        this.ID_GRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_CAN_PB.TabIndex = 1;
        this.ID_GRA_CAN_PB.Tag = "";
        this.ID_GRA_CAN_PB.Text = "Cerrar";
        this.ID_GRA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_CAN_PB.Click += new System.EventHandler(this.ID_GRA_CAN_PB_Click);
        // 
        // ID_GRA_GFC_PB
        // 
        this.ID_GRA_GFC_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_GFC_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_GFC_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_GFC_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_GFC_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_GFC_PB.Location = new System.Drawing.Point(319, 250);
        this.ID_GRA_GFC_PB.Name = "ID_GRA_GFC_PB";
        this.ID_GRA_GFC_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_GFC_PB.Size = new System.Drawing.Size(65, 22);
        this.ID_GRA_GFC_PB.TabIndex = 2;
        this.ID_GRA_GFC_PB.Tag = "";
        this.ID_GRA_GFC_PB.Text = "&Graficar";
        this.ID_GRA_GFC_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_GFC_PB.Click += new System.EventHandler(this.ID_GRA_GFC_PB_Click);
        // 
        // ID_GRA_IMP_PB
        // 
        this.ID_GRA_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_IMP_PB.Location = new System.Drawing.Point(384, 250);
        this.ID_GRA_IMP_PB.Name = "ID_GRA_IMP_PB";
        this.ID_GRA_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_IMP_PB.TabIndex = 3;
        this.ID_GRA_IMP_PB.Tag = "";
        this.ID_GRA_IMP_PB.Text = "&Imprimir";
        this.ID_GRA_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_IMP_PB.Click += new System.EventHandler(this.ID_GRA_IMP_PB_Click);
        // 
        // ID_GRA_GPH
        // 
        this.ID_GRA_GPH.Location = new System.Drawing.Point(16, 18);
        this.ID_GRA_GPH.Name = "ID_GRA_GPH";
        this.ID_GRA_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_GPH.OcxState")));
        this.ID_GRA_GPH.Size = new System.Drawing.Size(514, 213);
        this.ID_GRA_GPH.TabIndex = 7;
        this.ID_GRA_GPH.Tag = "";
        this.ID_GRA_GPH.DblClick += new System.EventHandler(this.ID_GRA_GPH_DblClick);
        // 
        // ID_GRA_TIPO_PNL
        // 
        this.ID_GRA_TIPO_PNL.Controls.Add(this._ID_GRA_B3D_GPB_1);
        this.ID_GRA_TIPO_PNL.Controls.Add(this._ID_GRA_B3D_GPB_0);
        this.ID_GRA_TIPO_PNL.Controls.Add(this._ID_GRA_B3D_GPB_3);
        this.ID_GRA_TIPO_PNL.Controls.Add(this._ID_GRA_B3D_GPB_2);
        this.ID_GRA_TIPO_PNL.Location = new System.Drawing.Point(17, 240);
        this.ID_GRA_TIPO_PNL.Name = "ID_GRA_TIPO_PNL";
        this.ID_GRA_TIPO_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_TIPO_PNL.OcxState")));
        this.ID_GRA_TIPO_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_GRA_TIPO_PNL.TabIndex = 11;
        this.ID_GRA_TIPO_PNL.Tag = "";
        // 
        // _ID_GRA_B3D_GPB_1
        // 
        this._ID_GRA_B3D_GPB_1.Location = new System.Drawing.Point(40, 4);
        this._ID_GRA_B3D_GPB_1.Name = "_ID_GRA_B3D_GPB_1";
        this._ID_GRA_B3D_GPB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_GRA_B3D_GPB_1.OcxState")));
        this._ID_GRA_B3D_GPB_1.Size = new System.Drawing.Size(37, 33);
        this._ID_GRA_B3D_GPB_1.TabIndex = 14;
        this._ID_GRA_B3D_GPB_1.Tag = "";
        this._ID_GRA_B3D_GPB_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_GRA_B3D_GPB_ClickEvent);
        // 
        // _ID_GRA_B3D_GPB_0
        // 
        this._ID_GRA_B3D_GPB_0.Location = new System.Drawing.Point(4, 4);
        this._ID_GRA_B3D_GPB_0.Name = "_ID_GRA_B3D_GPB_0";
        this._ID_GRA_B3D_GPB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_GRA_B3D_GPB_0.OcxState")));
        this._ID_GRA_B3D_GPB_0.Size = new System.Drawing.Size(37, 33);
        this._ID_GRA_B3D_GPB_0.TabIndex = 15;
        this._ID_GRA_B3D_GPB_0.Tag = "";
        this._ID_GRA_B3D_GPB_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_GRA_B3D_GPB_ClickEvent);
        // 
        // _ID_GRA_B3D_GPB_3
        // 
        this._ID_GRA_B3D_GPB_3.Location = new System.Drawing.Point(112, 4);
        this._ID_GRA_B3D_GPB_3.Name = "_ID_GRA_B3D_GPB_3";
        this._ID_GRA_B3D_GPB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_GRA_B3D_GPB_3.OcxState")));
        this._ID_GRA_B3D_GPB_3.Size = new System.Drawing.Size(37, 33);
        this._ID_GRA_B3D_GPB_3.TabIndex = 12;
        this._ID_GRA_B3D_GPB_3.Tag = "";
        this._ID_GRA_B3D_GPB_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_GRA_B3D_GPB_ClickEvent);
        // 
        // _ID_GRA_B3D_GPB_2
        // 
        this._ID_GRA_B3D_GPB_2.Location = new System.Drawing.Point(76, 4);
        this._ID_GRA_B3D_GPB_2.Name = "_ID_GRA_B3D_GPB_2";
        this._ID_GRA_B3D_GPB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_GRA_B3D_GPB_2.OcxState")));
        this._ID_GRA_B3D_GPB_2.Size = new System.Drawing.Size(37, 33);
        this._ID_GRA_B3D_GPB_2.TabIndex = 13;
        this._ID_GRA_B3D_GPB_2.Tag = "";
        this._ID_GRA_B3D_GPB_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_GRA_B3D_GPB_ClickEvent);
        // 
        // CORGRCOR
        // 
        this.AcceptButton = this.ID_GRA_GFC_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.CancelButton = this.ID_GRA_CAN_PB;
        this.ClientSize = new System.Drawing.Size(549, 341);
        this.Controls.Add(this.ID_GRA_PPL_PNL);
        this.Controls.Add(this.ID_GRA_PAR_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Location = new System.Drawing.Point(147, 115);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRCOR";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Corporativos";
        this.Closed += new System.EventHandler(this.CORGRCOR_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PAR_PNL)).EndInit();
        this.ID_GRA_PAR_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_IRA_3CKB)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PPL_PNL)).EndInit();
        this.ID_GRA_PPL_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GPH)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_TIPO_PNL)).EndInit();
        this.ID_GRA_TIPO_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_B3D_GPB_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_B3D_GPB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_B3D_GPB_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_B3D_GPB_2)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_GRA_ETI_TXT()
	{
			this.ID_GRA_ETI_TXT[1] = _ID_GRA_ETI_TXT_1;
	}
	void  InitializeID_GRA_B3D_GPB()
	{
			this.ID_GRA_B3D_GPB[0] = _ID_GRA_B3D_GPB_0;
			this.ID_GRA_B3D_GPB[1] = _ID_GRA_B3D_GPB_1;
			this.ID_GRA_B3D_GPB[2] = _ID_GRA_B3D_GPB_2;
			this.ID_GRA_B3D_GPB[3] = _ID_GRA_B3D_GPB_3;
	}
#endregion 
}
}