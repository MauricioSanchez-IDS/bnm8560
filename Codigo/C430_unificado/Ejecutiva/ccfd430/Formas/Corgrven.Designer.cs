using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORGRVEN
	{
	
#region "Upgrade Support "
		private static CORGRVEN m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRVEN DefInstance
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
		public CORGRVEN():base(){
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
			InitializeID_GRA_B3D_GPB();
		}
	public static CORGRVEN CreateInstance()
	{
			CORGRVEN theInstance = new CORGRVEN();
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
	public  System.Windows.Forms.ComboBox ID_CRE_EMP_COB;
	public  System.Windows.Forms.ComboBox ID_GRA_PAR_COB;
	public  AxThreed.AxSSCheck ID_CRE_IRA_CHK;
	public  System.Windows.Forms.Label ID_CRE_EMP_TXT;
	public  System.Windows.Forms.Label ID_CRE_TIP_TXT;
	public  System.Windows.Forms.Label ID_GRA_PAR_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_GRA_PAR_PNL;
	public  System.Windows.Forms.Button ID_GRA_GFC_PB;
	public  System.Windows.Forms.Button ID_GRA_IMP_PB;
	public  System.Windows.Forms.Button ID_GRA_CAN_PB;
	private  AxThreed.AxSSRibbon _ID_GRA_B3D_GPB_0;
	private  AxThreed.AxSSRibbon _ID_GRA_B3D_GPB_1;
	private  AxThreed.AxSSRibbon _ID_GRA_B3D_GPB_2;
	private  AxThreed.AxSSRibbon _ID_GRA_B3D_GPB_3;
	public  AxThreed.AxSSPanel ID_GRA_TIPO_PNL;
	public  AxGraphLib.AxGraph ID_GRA_GPH;
	public  AxThreed.AxSSPanel ID_GRA_PPL_PNL;
	public AxThreed.AxSSRibbon[] ID_GRA_B3D_GPB = new AxThreed.AxSSRibbon[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRVEN));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_GRA_PAR_PNL = new AxThreed.AxSSPanel();
        this.ID_CRE_IRA_CHK = new AxThreed.AxSSCheck();
        this.ID_GRA_PAR_COB = new System.Windows.Forms.ComboBox();
        this.ID_CRE_EMP_COB = new System.Windows.Forms.ComboBox();
        this.ID_CRE_EMP_TXT = new System.Windows.Forms.Label();
        this.ID_GRA_PAR_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_CRE_TIP_TXT = new System.Windows.Forms.Label();
        this.ID_GRA_PPL_PNL = new AxThreed.AxSSPanel();
        this.ID_GRA_CAN_PB = new System.Windows.Forms.Button();
        this.ID_GRA_IMP_PB = new System.Windows.Forms.Button();
        this.ID_GRA_GFC_PB = new System.Windows.Forms.Button();
        this.ID_GRA_GPH = new AxGraphLib.AxGraph();
        this.ID_GRA_TIPO_PNL = new AxThreed.AxSSPanel();
        this._ID_GRA_B3D_GPB_1 = new AxThreed.AxSSRibbon();
        this._ID_GRA_B3D_GPB_0 = new AxThreed.AxSSRibbon();
        this._ID_GRA_B3D_GPB_3 = new AxThreed.AxSSRibbon();
        this._ID_GRA_B3D_GPB_2 = new AxThreed.AxSSRibbon();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PAR_PNL)).BeginInit();
        this.ID_GRA_PAR_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_IRA_CHK)).BeginInit();
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
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_CRE_IRA_CHK);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_GRA_PAR_COB);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_CRE_EMP_COB);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_CRE_EMP_TXT);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_GRA_PAR_PNLLabel_Text);
        this.ID_GRA_PAR_PNL.Controls.Add(this.ID_CRE_TIP_TXT);
        this.ID_GRA_PAR_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_PAR_PNL.Name = "ID_GRA_PAR_PNL";
        this.ID_GRA_PAR_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PAR_PNL.OcxState")));
        this.ID_GRA_PAR_PNL.Size = new System.Drawing.Size(573, 66);
        this.ID_GRA_PAR_PNL.TabIndex = 0;
        this.ID_GRA_PAR_PNL.Tag = "";
        // 
        // ID_CRE_IRA_CHK
        // 
        this.ID_CRE_IRA_CHK.Location = new System.Drawing.Point(528, 33);
        this.ID_CRE_IRA_CHK.Name = "ID_CRE_IRA_CHK";
        this.ID_CRE_IRA_CHK.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CRE_IRA_CHK.OcxState")));
        this.ID_CRE_IRA_CHK.Size = new System.Drawing.Size(37, 20);
        this.ID_CRE_IRA_CHK.TabIndex = 6;
        this.ID_CRE_IRA_CHK.Tag = "";
        // 
        // ID_GRA_PAR_COB
        // 
        this.ID_GRA_PAR_COB.BackColor = System.Drawing.Color.White;
        this.ID_GRA_PAR_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_PAR_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_GRA_PAR_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_PAR_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_GRA_PAR_COB.Location = new System.Drawing.Point(41, 30);
        this.ID_GRA_PAR_COB.Name = "ID_GRA_PAR_COB";
        this.ID_GRA_PAR_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_PAR_COB.Size = new System.Drawing.Size(195, 21);
        this.ID_GRA_PAR_COB.TabIndex = 7;
        this.ID_GRA_PAR_COB.Tag = "";
        this.ID_GRA_PAR_COB.SelectedIndexChanged += new System.EventHandler(this.ID_GRA_PAR_COB_SelectedIndexChanged);
        // 
        // ID_CRE_EMP_COB
        // 
        this.ID_CRE_EMP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CRE_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CRE_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CRE_EMP_COB.Location = new System.Drawing.Point(294, 30);
        this.ID_CRE_EMP_COB.Name = "ID_CRE_EMP_COB";
        this.ID_CRE_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_EMP_COB.Size = new System.Drawing.Size(231, 21);
        this.ID_CRE_EMP_COB.Sorted = true;
        this.ID_CRE_EMP_COB.TabIndex = 10;
        this.ID_CRE_EMP_COB.Tag = "";
        this.ID_CRE_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CRE_EMP_COB_SelectedIndexChanged);
        // 
        // ID_CRE_EMP_TXT
        // 
        this.ID_CRE_EMP_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_CRE_EMP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_EMP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_EMP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_EMP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_EMP_TXT.Location = new System.Drawing.Point(241, 35);
        this.ID_CRE_EMP_TXT.Name = "ID_CRE_EMP_TXT";
        this.ID_CRE_EMP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_EMP_TXT.Size = new System.Drawing.Size(51, 19);
        this.ID_CRE_EMP_TXT.TabIndex = 5;
        this.ID_CRE_EMP_TXT.Tag = "";
        this.ID_CRE_EMP_TXT.Text = "&Empresa";
        // 
        // ID_GRA_PAR_PNLLabel_Text
        // 
        this.ID_GRA_PAR_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_PAR_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_PAR_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_GRA_PAR_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_PAR_PNLLabel_Text.Name = "ID_GRA_PAR_PNLLabel_Text";
        this.ID_GRA_PAR_PNLLabel_Text.Size = new System.Drawing.Size(573, 66);
        this.ID_GRA_PAR_PNLLabel_Text.TabIndex = 11;
        this.ID_GRA_PAR_PNLLabel_Text.Tag = "";
        this.ID_GRA_PAR_PNLLabel_Text.Text = " Parámetros a Graficar";
        // 
        // ID_CRE_TIP_TXT
        // 
        this.ID_CRE_TIP_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_CRE_TIP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CRE_TIP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CRE_TIP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CRE_TIP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CRE_TIP_TXT.Location = new System.Drawing.Point(10, 37);
        this.ID_CRE_TIP_TXT.Name = "ID_CRE_TIP_TXT";
        this.ID_CRE_TIP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CRE_TIP_TXT.Size = new System.Drawing.Size(28, 14);
        this.ID_CRE_TIP_TXT.TabIndex = 4;
        this.ID_CRE_TIP_TXT.Tag = "";
        this.ID_CRE_TIP_TXT.Text = "&Tipo";
        // 
        // ID_GRA_PPL_PNL
        // 
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_CAN_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_IMP_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_GFC_PB);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_GPH);
        this.ID_GRA_PPL_PNL.Controls.Add(this.ID_GRA_TIPO_PNL);
        this.ID_GRA_PPL_PNL.Location = new System.Drawing.Point(0, 65);
        this.ID_GRA_PPL_PNL.Name = "ID_GRA_PPL_PNL";
        this.ID_GRA_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PPL_PNL.OcxState")));
        this.ID_GRA_PPL_PNL.Size = new System.Drawing.Size(573, 290);
        this.ID_GRA_PPL_PNL.TabIndex = 8;
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
        this.ID_GRA_CAN_PB.Location = new System.Drawing.Point(481, 253);
        this.ID_GRA_CAN_PB.Name = "ID_GRA_CAN_PB";
        this.ID_GRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_CAN_PB.TabIndex = 1;
        this.ID_GRA_CAN_PB.Tag = "";
        this.ID_GRA_CAN_PB.Text = "Cerrar";
        this.ID_GRA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_CAN_PB.Click += new System.EventHandler(this.ID_GRA_CAN_PB_Click);
        // 
        // ID_GRA_IMP_PB
        // 
        this.ID_GRA_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_IMP_PB.Location = new System.Drawing.Point(408, 253);
        this.ID_GRA_IMP_PB.Name = "ID_GRA_IMP_PB";
        this.ID_GRA_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_IMP_PB.TabIndex = 2;
        this.ID_GRA_IMP_PB.Tag = "";
        this.ID_GRA_IMP_PB.Text = "&Imprimir";
        this.ID_GRA_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_IMP_PB.Click += new System.EventHandler(this.ID_GRA_IMP_PB_Click);
        // 
        // ID_GRA_GFC_PB
        // 
        this.ID_GRA_GFC_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_GFC_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_GFC_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_GFC_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_GFC_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_GFC_PB.Location = new System.Drawing.Point(336, 253);
        this.ID_GRA_GFC_PB.Name = "ID_GRA_GFC_PB";
        this.ID_GRA_GFC_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_GFC_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_GFC_PB.TabIndex = 3;
        this.ID_GRA_GFC_PB.Tag = "";
        this.ID_GRA_GFC_PB.Text = "&Graficar";
        this.ID_GRA_GFC_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_GFC_PB.Click += new System.EventHandler(this.ID_GRA_GFC_PB_Click);
        // 
        // ID_GRA_GPH
        // 
        this.ID_GRA_GPH.Location = new System.Drawing.Point(15, 13);
        this.ID_GRA_GPH.Name = "ID_GRA_GPH";
        this.ID_GRA_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_GPH.OcxState")));
        this.ID_GRA_GPH.Size = new System.Drawing.Size(540, 222);
        this.ID_GRA_GPH.TabIndex = 9;
        this.ID_GRA_GPH.Tag = "";
        this.ID_GRA_GPH.DblClick += new System.EventHandler(this.ID_GRA_GPH_DblClick);
        // 
        // ID_GRA_TIPO_PNL
        // 
        this.ID_GRA_TIPO_PNL.Controls.Add(this._ID_GRA_B3D_GPB_1);
        this.ID_GRA_TIPO_PNL.Controls.Add(this._ID_GRA_B3D_GPB_0);
        this.ID_GRA_TIPO_PNL.Controls.Add(this._ID_GRA_B3D_GPB_3);
        this.ID_GRA_TIPO_PNL.Controls.Add(this._ID_GRA_B3D_GPB_2);
        this.ID_GRA_TIPO_PNL.Location = new System.Drawing.Point(13, 242);
        this.ID_GRA_TIPO_PNL.Name = "ID_GRA_TIPO_PNL";
        this.ID_GRA_TIPO_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_TIPO_PNL.OcxState")));
        this.ID_GRA_TIPO_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_GRA_TIPO_PNL.TabIndex = 11;
        this.ID_GRA_TIPO_PNL.Tag = "";
        // 
        // _ID_GRA_B3D_GPB_1
        // 
        this._ID_GRA_B3D_GPB_1.Location = new System.Drawing.Point(41, 4);
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
        // CORGRVEN
        // 
        this.AcceptButton = this.ID_GRA_GFC_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.CancelButton = this.ID_GRA_CAN_PB;
        this.ClientSize = new System.Drawing.Size(573, 355);
        this.Controls.Add(this.ID_GRA_PPL_PNL);
        this.Controls.Add(this.ID_GRA_PAR_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Location = new System.Drawing.Point(73, 120);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRVEN";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Vencidos";
        this.Closed += new System.EventHandler(this.CORGRVEN_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PAR_PNL)).EndInit();
        this.ID_GRA_PAR_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CRE_IRA_CHK)).EndInit();
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