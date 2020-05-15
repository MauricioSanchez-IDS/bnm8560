using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORGREMP
	{
	
#region "Upgrade Support "
		private static CORGREMP m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGREMP DefInstance
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
		public CORGREMP():base(){
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
			InitializeID_GRA_GRA_GPB();
		}
	public static CORGREMP CreateInstance()
	{
			CORGREMP theInstance = new CORGREMP();
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
	public  System.Windows.Forms.Button ID_GRA_MEMP_PB;
	public  System.Windows.Forms.ComboBox ID_CEE_EMP_COB;
	public  System.Windows.Forms.Label ID_GRA_TIP_TXT;
	public  System.Windows.Forms.Label ID_GRA_PRI_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_GRA_PRI_PNL;
	public  System.Windows.Forms.Button ID_GRA_CAN_PB;
	public  System.Windows.Forms.Button ID_GRA_IMP_PB;
	public  System.Windows.Forms.Button ID_EMP_GRA_PB;
	private  AxThreed.AxSSRibbon _ID_GRA_GRA_GPB_0;
	private  AxThreed.AxSSRibbon _ID_GRA_GRA_GPB_1;
	private  AxThreed.AxSSRibbon _ID_GRA_GRA_GPB_2;
	private  AxThreed.AxSSRibbon _ID_GRA_GRA_GPB_3;
	public  AxThreed.AxSSPanel ID_GRA_GRP_PNL;
	public  AxGraphLib.AxGraph ID_GRA_GPH;
	public  AxThreed.AxSSPanel ID_GRA_PRI1_PNL;
	public AxThreed.AxSSRibbon[] ID_GRA_GRA_GPB = new AxThreed.AxSSRibbon[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGREMP));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_GRA_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_CEE_EMP_COB = new System.Windows.Forms.ComboBox();
        this.ID_GRA_MEMP_PB = new System.Windows.Forms.Button();
        this.ID_GRA_PRI_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_GRA_TIP_TXT = new System.Windows.Forms.Label();
        this.ID_GRA_PRI1_PNL = new AxThreed.AxSSPanel();
        this.ID_EMP_GRA_PB = new System.Windows.Forms.Button();
        this.ID_GRA_IMP_PB = new System.Windows.Forms.Button();
        this.ID_GRA_CAN_PB = new System.Windows.Forms.Button();
        this.ID_GRA_GPH = new AxGraphLib.AxGraph();
        this.ID_GRA_GRP_PNL = new AxThreed.AxSSPanel();
        this._ID_GRA_GRA_GPB_1 = new AxThreed.AxSSRibbon();
        this._ID_GRA_GRA_GPB_0 = new AxThreed.AxSSRibbon();
        this._ID_GRA_GRA_GPB_3 = new AxThreed.AxSSRibbon();
        this._ID_GRA_GRA_GPB_2 = new AxThreed.AxSSRibbon();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI_PNL)).BeginInit();
        this.ID_GRA_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI1_PNL)).BeginInit();
        this.ID_GRA_PRI1_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GPH)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GRP_PNL)).BeginInit();
        this.ID_GRA_GRP_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_GRA_GPB_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_GRA_GPB_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_GRA_GPB_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_GRA_GPB_2)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_GRA_PRI_PNL
        // 
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_CEE_EMP_COB);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_MEMP_PB);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_PRI_PNLLabel_Text);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_TIP_TXT);
        this.ID_GRA_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_PRI_PNL.Name = "ID_GRA_PRI_PNL";
        this.ID_GRA_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PRI_PNL.OcxState")));
        this.ID_GRA_PRI_PNL.Size = new System.Drawing.Size(515, 52);
        this.ID_GRA_PRI_PNL.TabIndex = 0;
        this.ID_GRA_PRI_PNL.Tag = "";
        // 
        // ID_CEE_EMP_COB
        // 
        this.ID_CEE_EMP_COB.BackColor = System.Drawing.Color.White;
        this.ID_CEE_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_CEE_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEE_EMP_COB.Location = new System.Drawing.Point(173, 15);
        this.ID_CEE_EMP_COB.Name = "ID_CEE_EMP_COB";
        this.ID_CEE_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_EMP_COB.Size = new System.Drawing.Size(147, 21);
        this.ID_CEE_EMP_COB.TabIndex = 8;
        this.ID_CEE_EMP_COB.Tag = "";
        this.ID_CEE_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEE_EMP_COB_SelectedIndexChanged);
        // 
        // ID_GRA_MEMP_PB
        // 
        this.ID_GRA_MEMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_MEMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_MEMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_MEMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_MEMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_MEMP_PB.Location = new System.Drawing.Point(323, 16);
        this.ID_GRA_MEMP_PB.Name = "ID_GRA_MEMP_PB";
        this.ID_GRA_MEMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_MEMP_PB.Size = new System.Drawing.Size(23, 21);
        this.ID_GRA_MEMP_PB.TabIndex = 13;
        this.ID_GRA_MEMP_PB.Tag = "";
        this.ID_GRA_MEMP_PB.Text = "...";
        this.ID_GRA_MEMP_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_MEMP_PB.Click += new System.EventHandler(this.ID_GRA_MEMP_PB_Click);
        // 
        // ID_GRA_PRI_PNLLabel_Text
        // 
        this.ID_GRA_PRI_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_PRI_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_PRI_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_GRA_PRI_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_PRI_PNLLabel_Text.Name = "ID_GRA_PRI_PNLLabel_Text";
        this.ID_GRA_PRI_PNLLabel_Text.Size = new System.Drawing.Size(515, 52);
        this.ID_GRA_PRI_PNLLabel_Text.TabIndex = 14;
        this.ID_GRA_PRI_PNLLabel_Text.Tag = "";
        this.ID_GRA_PRI_PNLLabel_Text.Text = " Parámetros a Graficar";
        // 
        // ID_GRA_TIP_TXT
        // 
        this.ID_GRA_TIP_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_GRA_TIP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_TIP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_TIP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_TIP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_TIP_TXT.Location = new System.Drawing.Point(141, 17);
        this.ID_GRA_TIP_TXT.Name = "ID_GRA_TIP_TXT";
        this.ID_GRA_TIP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_TIP_TXT.Size = new System.Drawing.Size(31, 16);
        this.ID_GRA_TIP_TXT.TabIndex = 7;
        this.ID_GRA_TIP_TXT.Tag = "";
        this.ID_GRA_TIP_TXT.Text = "&Tipo";
        // 
        // ID_GRA_PRI1_PNL
        // 
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_EMP_GRA_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_IMP_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_CAN_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_GPH);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_GRP_PNL);
        this.ID_GRA_PRI1_PNL.Location = new System.Drawing.Point(0, 51);
        this.ID_GRA_PRI1_PNL.Name = "ID_GRA_PRI1_PNL";
        this.ID_GRA_PRI1_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PRI1_PNL.OcxState")));
        this.ID_GRA_PRI1_PNL.Size = new System.Drawing.Size(515, 293);
        this.ID_GRA_PRI1_PNL.TabIndex = 4;
        this.ID_GRA_PRI1_PNL.Tag = "";
        // 
        // ID_EMP_GRA_PB
        // 
        this.ID_EMP_GRA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EMP_GRA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EMP_GRA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EMP_GRA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EMP_GRA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EMP_GRA_PB.Location = new System.Drawing.Point(285, 247);
        this.ID_EMP_GRA_PB.Name = "ID_EMP_GRA_PB";
        this.ID_EMP_GRA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EMP_GRA_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_EMP_GRA_PB.TabIndex = 1;
        this.ID_EMP_GRA_PB.Tag = "";
        this.ID_EMP_GRA_PB.Text = "Graficar";
        this.ID_EMP_GRA_PB.UseVisualStyleBackColor = false;
        this.ID_EMP_GRA_PB.Click += new System.EventHandler(this.ID_EMP_GRA_PB_Click);
        // 
        // ID_GRA_IMP_PB
        // 
        this.ID_GRA_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_IMP_PB.Location = new System.Drawing.Point(357, 247);
        this.ID_GRA_IMP_PB.Name = "ID_GRA_IMP_PB";
        this.ID_GRA_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_IMP_PB.TabIndex = 2;
        this.ID_GRA_IMP_PB.Tag = "";
        this.ID_GRA_IMP_PB.Text = "Imprimir";
        this.ID_GRA_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_IMP_PB.Click += new System.EventHandler(this.ID_GRA_IMP_PB_Click);
        // 
        // ID_GRA_CAN_PB
        // 
        this.ID_GRA_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_GRA_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_CAN_PB.Location = new System.Drawing.Point(430, 247);
        this.ID_GRA_CAN_PB.Name = "ID_GRA_CAN_PB";
        this.ID_GRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_CAN_PB.TabIndex = 3;
        this.ID_GRA_CAN_PB.Tag = "";
        this.ID_GRA_CAN_PB.Text = "Cerrar";
        this.ID_GRA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_CAN_PB.Click += new System.EventHandler(this.ID_GRA_CAN_PB_Click);
        // 
        // ID_GRA_GPH
        // 
        this.ID_GRA_GPH.Location = new System.Drawing.Point(18, 15);
        this.ID_GRA_GPH.Name = "ID_GRA_GPH";
        this.ID_GRA_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_GPH.OcxState")));
        this.ID_GRA_GPH.Size = new System.Drawing.Size(479, 222);
        this.ID_GRA_GPH.TabIndex = 5;
        this.ID_GRA_GPH.Tag = "";
        this.ID_GRA_GPH.DblClick += new System.EventHandler(this.ID_GRA_GPH_DblClick);
        // 
        // ID_GRA_GRP_PNL
        // 
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_GRA_GRA_GPB_1);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_GRA_GRA_GPB_0);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_GRA_GRA_GPB_3);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_GRA_GRA_GPB_2);
        this.ID_GRA_GRP_PNL.Location = new System.Drawing.Point(17, 243);
        this.ID_GRA_GRP_PNL.Name = "ID_GRA_GRP_PNL";
        this.ID_GRA_GRP_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_GRP_PNL.OcxState")));
        this.ID_GRA_GRP_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_GRA_GRP_PNL.TabIndex = 6;
        this.ID_GRA_GRP_PNL.Tag = "";
        // 
        // _ID_GRA_GRA_GPB_1
        // 
        this._ID_GRA_GRA_GPB_1.Location = new System.Drawing.Point(40, 4);
        this._ID_GRA_GRA_GPB_1.Name = "_ID_GRA_GRA_GPB_1";
        this._ID_GRA_GRA_GPB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_GRA_GRA_GPB_1.OcxState")));
        this._ID_GRA_GRA_GPB_1.Size = new System.Drawing.Size(37, 33);
        this._ID_GRA_GRA_GPB_1.TabIndex = 11;
        this._ID_GRA_GRA_GPB_1.Tag = "";
        this._ID_GRA_GRA_GPB_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_GRA_GRA_GPB_ClickEvent);
        // 
        // _ID_GRA_GRA_GPB_0
        // 
        this._ID_GRA_GRA_GPB_0.Location = new System.Drawing.Point(4, 4);
        this._ID_GRA_GRA_GPB_0.Name = "_ID_GRA_GRA_GPB_0";
        this._ID_GRA_GRA_GPB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_GRA_GRA_GPB_0.OcxState")));
        this._ID_GRA_GRA_GPB_0.Size = new System.Drawing.Size(37, 33);
        this._ID_GRA_GRA_GPB_0.TabIndex = 12;
        this._ID_GRA_GRA_GPB_0.Tag = "";
        this._ID_GRA_GRA_GPB_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_GRA_GRA_GPB_ClickEvent);
        // 
        // _ID_GRA_GRA_GPB_3
        // 
        this._ID_GRA_GRA_GPB_3.Location = new System.Drawing.Point(112, 4);
        this._ID_GRA_GRA_GPB_3.Name = "_ID_GRA_GRA_GPB_3";
        this._ID_GRA_GRA_GPB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_GRA_GRA_GPB_3.OcxState")));
        this._ID_GRA_GRA_GPB_3.Size = new System.Drawing.Size(37, 33);
        this._ID_GRA_GRA_GPB_3.TabIndex = 9;
        this._ID_GRA_GRA_GPB_3.Tag = "";
        this._ID_GRA_GRA_GPB_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_GRA_GRA_GPB_ClickEvent);
        // 
        // _ID_GRA_GRA_GPB_2
        // 
        this._ID_GRA_GRA_GPB_2.Location = new System.Drawing.Point(76, 4);
        this._ID_GRA_GRA_GPB_2.Name = "_ID_GRA_GRA_GPB_2";
        this._ID_GRA_GRA_GPB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_GRA_GRA_GPB_2.OcxState")));
        this._ID_GRA_GRA_GPB_2.Size = new System.Drawing.Size(37, 33);
        this._ID_GRA_GRA_GPB_2.TabIndex = 10;
        this._ID_GRA_GRA_GPB_2.Tag = "";
        this._ID_GRA_GRA_GPB_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_GRA_GRA_GPB_ClickEvent);
        // 
        // CORGREMP
        // 
        this.AcceptButton = this.ID_EMP_GRA_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.CancelButton = this.ID_GRA_CAN_PB;
        this.ClientSize = new System.Drawing.Size(516, 344);
        this.Controls.Add(this.ID_GRA_PRI1_PNL);
        this.Controls.Add(this.ID_GRA_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(160, 249);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGREMP";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Empresas";
        this.Closed += new System.EventHandler(this.CORGREMP_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI_PNL)).EndInit();
        this.ID_GRA_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI1_PNL)).EndInit();
        this.ID_GRA_PRI1_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GPH)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GRP_PNL)).EndInit();
        this.ID_GRA_GRP_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_GRA_GPB_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_GRA_GPB_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_GRA_GPB_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_GRA_GRA_GPB_2)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_GRA_GRA_GPB()
	{
			this.ID_GRA_GRA_GPB[0] = _ID_GRA_GRA_GPB_0;
			this.ID_GRA_GRA_GPB[1] = _ID_GRA_GRA_GPB_1;
			this.ID_GRA_GRA_GPB[2] = _ID_GRA_GRA_GPB_2;
			this.ID_GRA_GRA_GPB[3] = _ID_GRA_GRA_GPB_3;
	}
#endregion 
}
}