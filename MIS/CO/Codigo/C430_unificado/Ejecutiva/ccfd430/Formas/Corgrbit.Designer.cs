using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORGRBIT
	{
	
#region "Upgrade Support "
		private static CORGRBIT m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRBIT DefInstance
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
		public CORGRBIT():base(){
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
			InitializeID_CRE_TIP_SSR();
		}
	public static CORGRBIT CreateInstance()
	{
			CORGRBIT theInstance = new CORGRBIT();
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
	public  System.Windows.Forms.ComboBox ID_BIT_GRU_COB;
	public  System.Windows.Forms.Label ID_BIT_GRU_TXT;
	public  System.Windows.Forms.Label ID_GRA_PRI_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_GRA_PRI_PNL;
	public  System.Windows.Forms.Button ID_GRA_CAN_PB;
	public  System.Windows.Forms.Button ID_GRA_IMP_PB;
	public  System.Windows.Forms.Button ID_BIT_GRA_PB;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_3;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_2;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_1;
	private  AxThreed.AxSSRibbon _ID_CRE_TIP_SSR_0;
	public  AxThreed.AxSSPanel ID_GRA_GRP_PNL;
	public  AxGraphLib.AxGraph ID_BIT_GRA_GPH;
	public  AxThreed.AxSSPanel ID_GRA_PRI1_PNL;
	public AxThreed.AxSSRibbon[] ID_CRE_TIP_SSR = new AxThreed.AxSSRibbon[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRBIT));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_GRA_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_BIT_GRU_COB = new System.Windows.Forms.ComboBox();
        this.ID_BIT_GRU_TXT = new System.Windows.Forms.Label();
        this.ID_GRA_PRI_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_GRA_PRI1_PNL = new AxThreed.AxSSPanel();
        this.ID_GRA_IMP_PB = new System.Windows.Forms.Button();
        this.ID_GRA_CAN_PB = new System.Windows.Forms.Button();
        this.ID_BIT_GRA_PB = new System.Windows.Forms.Button();
        this.ID_BIT_GRA_GPH = new AxGraphLib.AxGraph();
        this.ID_GRA_GRP_PNL = new AxThreed.AxSSPanel();
        this._ID_CRE_TIP_SSR_2 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_3 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_0 = new AxThreed.AxSSRibbon();
        this._ID_CRE_TIP_SSR_1 = new AxThreed.AxSSRibbon();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI_PNL)).BeginInit();
        this.ID_GRA_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI1_PNL)).BeginInit();
        this.ID_GRA_PRI1_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_BIT_GRA_GPH)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GRP_PNL)).BeginInit();
        this.ID_GRA_GRP_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_1)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_GRA_PRI_PNL
        // 
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_BIT_GRU_COB);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_BIT_GRU_TXT);
        this.ID_GRA_PRI_PNL.Controls.Add(this.ID_GRA_PRI_PNLLabel_Text);
        this.ID_GRA_PRI_PNL.Location = new System.Drawing.Point(1, 0);
        this.ID_GRA_PRI_PNL.Name = "ID_GRA_PRI_PNL";
        this.ID_GRA_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PRI_PNL.OcxState")));
        this.ID_GRA_PRI_PNL.Size = new System.Drawing.Size(537, 57);
        this.ID_GRA_PRI_PNL.TabIndex = 0;
        this.ID_GRA_PRI_PNL.Tag = "";
        // 
        // ID_BIT_GRU_COB
        // 
        this.ID_BIT_GRU_COB.BackColor = System.Drawing.Color.White;
        this.ID_BIT_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_BIT_GRU_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_BIT_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_BIT_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_BIT_GRU_COB.Location = new System.Drawing.Point(183, 28);
        this.ID_BIT_GRU_COB.Name = "ID_BIT_GRU_COB";
        this.ID_BIT_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_BIT_GRU_COB.Size = new System.Drawing.Size(165, 21);
        this.ID_BIT_GRU_COB.TabIndex = 6;
        this.ID_BIT_GRU_COB.Tag = "";
        this.ID_BIT_GRU_COB.SelectedIndexChanged += new System.EventHandler(this.ID_BIT_GRU_COB_SelectedIndexChanged);
        // 
        // ID_BIT_GRU_TXT
        // 
        this.ID_BIT_GRU_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_BIT_GRU_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_BIT_GRU_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_BIT_GRU_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_BIT_GRU_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_BIT_GRU_TXT.Location = new System.Drawing.Point(124, 32);
        this.ID_BIT_GRU_TXT.Name = "ID_BIT_GRU_TXT";
        this.ID_BIT_GRU_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_BIT_GRU_TXT.Size = new System.Drawing.Size(45, 15);
        this.ID_BIT_GRU_TXT.TabIndex = 8;
        this.ID_BIT_GRU_TXT.Tag = "";
        this.ID_BIT_GRU_TXT.Text = "&Grupos";
        // 
        // ID_GRA_PRI_PNLLabel_Text
        // 
        this.ID_GRA_PRI_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_PRI_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_PRI_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_GRA_PRI_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_GRA_PRI_PNLLabel_Text.Name = "ID_GRA_PRI_PNLLabel_Text";
        this.ID_GRA_PRI_PNLLabel_Text.Size = new System.Drawing.Size(537, 57);
        this.ID_GRA_PRI_PNLLabel_Text.TabIndex = 9;
        this.ID_GRA_PRI_PNLLabel_Text.Tag = "";
        this.ID_GRA_PRI_PNLLabel_Text.Text = " Parámetros a Graficar";
        // 
        // ID_GRA_PRI1_PNL
        // 
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_IMP_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_CAN_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_BIT_GRA_PB);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_BIT_GRA_GPH);
        this.ID_GRA_PRI1_PNL.Controls.Add(this.ID_GRA_GRP_PNL);
        this.ID_GRA_PRI1_PNL.Location = new System.Drawing.Point(0, 58);
        this.ID_GRA_PRI1_PNL.Name = "ID_GRA_PRI1_PNL";
        this.ID_GRA_PRI1_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_PRI1_PNL.OcxState")));
        this.ID_GRA_PRI1_PNL.Size = new System.Drawing.Size(537, 275);
        this.ID_GRA_PRI1_PNL.TabIndex = 4;
        this.ID_GRA_PRI1_PNL.Tag = "";
        // 
        // ID_GRA_IMP_PB
        // 
        this.ID_GRA_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRA_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRA_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_IMP_PB.Location = new System.Drawing.Point(371, 240);
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
        this.ID_GRA_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRA_CAN_PB.Location = new System.Drawing.Point(443, 240);
        this.ID_GRA_CAN_PB.Name = "ID_GRA_CAN_PB";
        this.ID_GRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRA_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_GRA_CAN_PB.TabIndex = 3;
        this.ID_GRA_CAN_PB.Tag = "";
        this.ID_GRA_CAN_PB.Text = "Cerrar";
        this.ID_GRA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_GRA_CAN_PB.Click += new System.EventHandler(this.ID_GRA_CAN_PB_Click);
        // 
        // ID_BIT_GRA_PB
        // 
        this.ID_BIT_GRA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_BIT_GRA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_BIT_GRA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_BIT_GRA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_BIT_GRA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_BIT_GRA_PB.Location = new System.Drawing.Point(299, 240);
        this.ID_BIT_GRA_PB.Name = "ID_BIT_GRA_PB";
        this.ID_BIT_GRA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_BIT_GRA_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_BIT_GRA_PB.TabIndex = 1;
        this.ID_BIT_GRA_PB.Tag = "";
        this.ID_BIT_GRA_PB.Text = "Graficar";
        this.ID_BIT_GRA_PB.UseVisualStyleBackColor = false;
        this.ID_BIT_GRA_PB.Click += new System.EventHandler(this.ID_BIT_GRA_PB_Click);
        // 
        // ID_BIT_GRA_GPH
        // 
        this.ID_BIT_GRA_GPH.Location = new System.Drawing.Point(19, 14);
        this.ID_BIT_GRA_GPH.Name = "ID_BIT_GRA_GPH";
        this.ID_BIT_GRA_GPH.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_BIT_GRA_GPH.OcxState")));
        this.ID_BIT_GRA_GPH.Size = new System.Drawing.Size(502, 205);
        this.ID_BIT_GRA_GPH.TabIndex = 5;
        this.ID_BIT_GRA_GPH.Tag = "";
        this.ID_BIT_GRA_GPH.DblClick += new System.EventHandler(this.ID_BIT_GRA_GPH_DblClick);
        // 
        // ID_GRA_GRP_PNL
        // 
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_2);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_3);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_0);
        this.ID_GRA_GRP_PNL.Controls.Add(this._ID_CRE_TIP_SSR_1);
        this.ID_GRA_GRP_PNL.Location = new System.Drawing.Point(19, 226);
        this.ID_GRA_GRP_PNL.Name = "ID_GRA_GRP_PNL";
        this.ID_GRA_GRP_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRA_GRP_PNL.OcxState")));
        this.ID_GRA_GRP_PNL.Size = new System.Drawing.Size(153, 41);
        this.ID_GRA_GRP_PNL.TabIndex = 7;
        this.ID_GRA_GRP_PNL.Tag = "";
        // 
        // _ID_CRE_TIP_SSR_2
        // 
        this._ID_CRE_TIP_SSR_2.Location = new System.Drawing.Point(76, 4);
        this._ID_CRE_TIP_SSR_2.Name = "_ID_CRE_TIP_SSR_2";
        this._ID_CRE_TIP_SSR_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_2.OcxState")));
        this._ID_CRE_TIP_SSR_2.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_2.TabIndex = 11;
        this._ID_CRE_TIP_SSR_2.Tag = "";
        this._ID_CRE_TIP_SSR_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_3
        // 
        this._ID_CRE_TIP_SSR_3.Location = new System.Drawing.Point(112, 4);
        this._ID_CRE_TIP_SSR_3.Name = "_ID_CRE_TIP_SSR_3";
        this._ID_CRE_TIP_SSR_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_3.OcxState")));
        this._ID_CRE_TIP_SSR_3.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_3.TabIndex = 12;
        this._ID_CRE_TIP_SSR_3.Tag = "";
        this._ID_CRE_TIP_SSR_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_0
        // 
        this._ID_CRE_TIP_SSR_0.Location = new System.Drawing.Point(4, 4);
        this._ID_CRE_TIP_SSR_0.Name = "_ID_CRE_TIP_SSR_0";
        this._ID_CRE_TIP_SSR_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_0.OcxState")));
        this._ID_CRE_TIP_SSR_0.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_0.TabIndex = 9;
        this._ID_CRE_TIP_SSR_0.Tag = "";
        this._ID_CRE_TIP_SSR_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // _ID_CRE_TIP_SSR_1
        // 
        this._ID_CRE_TIP_SSR_1.Location = new System.Drawing.Point(40, 4);
        this._ID_CRE_TIP_SSR_1.Name = "_ID_CRE_TIP_SSR_1";
        this._ID_CRE_TIP_SSR_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CRE_TIP_SSR_1.OcxState")));
        this._ID_CRE_TIP_SSR_1.Size = new System.Drawing.Size(37, 33);
        this._ID_CRE_TIP_SSR_1.TabIndex = 10;
        this._ID_CRE_TIP_SSR_1.Tag = "";
        this._ID_CRE_TIP_SSR_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.ID_CRE_TIP_SSR_ClickEvent);
        // 
        // CORGRBIT
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.ClientSize = new System.Drawing.Size(537, 332);
        this.Controls.Add(this.ID_GRA_PRI1_PNL);
        this.Controls.Add(this.ID_GRA_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Location = new System.Drawing.Point(175, 108);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRBIT";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Bitácora";
        this.Closed += new System.EventHandler(this.CORGRBIT_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI_PNL)).EndInit();
        this.ID_GRA_PRI_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_PRI1_PNL)).EndInit();
        this.ID_GRA_PRI1_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_BIT_GRA_GPH)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRA_GRP_PNL)).EndInit();
        this.ID_GRA_GRP_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CRE_TIP_SSR_1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_CRE_TIP_SSR()
	{
			this.ID_CRE_TIP_SSR[3] = _ID_CRE_TIP_SSR_3;
			this.ID_CRE_TIP_SSR[2] = _ID_CRE_TIP_SSR_2;
			this.ID_CRE_TIP_SSR[1] = _ID_CRE_TIP_SSR_1;
			this.ID_CRE_TIP_SSR[0] = _ID_CRE_TIP_SSR_0;
	}
#endregion 
}
}