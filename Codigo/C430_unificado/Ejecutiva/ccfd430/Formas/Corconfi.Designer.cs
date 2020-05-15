using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCONFI
	{
	
#region "Upgrade Support "
		private static CORCONFI m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCONFI DefInstance
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
		public CORCONFI():base(){
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
			InitializeID_FIR_FIR_PNL();
			InitializeID_CFI_ETI_PNL();
			InitializeID_FIR_NOM_PNL();
		}
	public static CORCONFI CreateInstance()
	{
			CORCONFI theInstance = new CORCONFI();
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
	public  System.Windows.Forms.Button ID_FIR_IMP_PB;
	public  System.Windows.Forms.Button ID_FIR_SAL_PB;
	private  System.Windows.Forms.Label _ID_CFI_ETI_PNL_0Label_Text;
	private  AxThreed.AxSSPanel _ID_CFI_ETI_PNL_0;
	public  AxGEARLib.AxGear ID_FIR_FR1_IMM;
	private  AxThreed.AxSSPanel _ID_FIR_FIR_PNL_0;
	private  AxThreed.AxSSPanel _ID_FIR_NOM_PNL_0;
	private  System.Windows.Forms.Label _ID_CFI_ETI_PNL_1Label_Text;
	private  AxThreed.AxSSPanel _ID_CFI_ETI_PNL_1;
	private  System.Windows.Forms.Label _ID_CFI_ETI_PNL_2Label_Text;
	private  AxThreed.AxSSPanel _ID_CFI_ETI_PNL_2;
	public  AxGEARLib.AxGear ID_FIR_FR2_IMM;
	private  AxThreed.AxSSPanel _ID_FIR_FIR_PNL_1;
	public  AxGEARLib.AxGear ID_FIR_FR3_IMM;
	private  AxThreed.AxSSPanel _ID_FIR_FIR_PNL_2;
	private  AxThreed.AxSSPanel _ID_FIR_NOM_PNL_1;
	private  AxThreed.AxSSPanel _ID_FIR_NOM_PNL_2;
	public AxThreed.AxSSPanel[] ID_CFI_ETI_PNL = new AxThreed.AxSSPanel[3];
	public AxThreed.AxSSPanel[] ID_FIR_FIR_PNL = new AxThreed.AxSSPanel[3];
	public AxThreed.AxSSPanel[] ID_FIR_NOM_PNL = new AxThreed.AxSSPanel[3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCONFI));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_FIR_IMP_PB = new System.Windows.Forms.Button();
        this.ID_FIR_SAL_PB = new System.Windows.Forms.Button();
        this._ID_CFI_ETI_PNL_0 = new AxThreed.AxSSPanel();
        this._ID_CFI_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
        this._ID_FIR_FIR_PNL_0 = new AxThreed.AxSSPanel();
        this.ID_FIR_FR1_IMM = new AxGEARLib.AxGear();
        this._ID_FIR_NOM_PNL_0 = new AxThreed.AxSSPanel();
        this._ID_CFI_ETI_PNL_1 = new AxThreed.AxSSPanel();
        this._ID_CFI_ETI_PNL_1Label_Text = new System.Windows.Forms.Label();
        this._ID_CFI_ETI_PNL_2 = new AxThreed.AxSSPanel();
        this._ID_CFI_ETI_PNL_2Label_Text = new System.Windows.Forms.Label();
        this._ID_FIR_FIR_PNL_1 = new AxThreed.AxSSPanel();
        this.ID_FIR_FR2_IMM = new AxGEARLib.AxGear();
        this._ID_FIR_FIR_PNL_2 = new AxThreed.AxSSPanel();
        this.ID_FIR_FR3_IMM = new AxGEARLib.AxGear();
        this._ID_FIR_NOM_PNL_1 = new AxThreed.AxSSPanel();
        this._ID_FIR_NOM_PNL_2 = new AxThreed.AxSSPanel();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CFI_ETI_PNL_0)).BeginInit();
        this._ID_CFI_ETI_PNL_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_FIR_PNL_0)).BeginInit();
        this._ID_FIR_FIR_PNL_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR1_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_NOM_PNL_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CFI_ETI_PNL_1)).BeginInit();
        this._ID_CFI_ETI_PNL_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CFI_ETI_PNL_2)).BeginInit();
        this._ID_CFI_ETI_PNL_2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_FIR_PNL_1)).BeginInit();
        this._ID_FIR_FIR_PNL_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR2_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_FIR_PNL_2)).BeginInit();
        this._ID_FIR_FIR_PNL_2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR3_IMM)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_NOM_PNL_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_NOM_PNL_2)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_FIR_IMP_PB
        // 
        this.ID_FIR_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_IMP_PB.Location = new System.Drawing.Point(456, 176);
        this.ID_FIR_IMP_PB.Name = "ID_FIR_IMP_PB";
        this.ID_FIR_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_IMP_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_IMP_PB.TabIndex = 4;
        this.ID_FIR_IMP_PB.Tag = "";
        this.ID_FIR_IMP_PB.Text = "&Imprimir";
        this.ID_FIR_IMP_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_IMP_PB.Click += new System.EventHandler(this.ID_FIR_IMP_PB_Click);
        // 
        // ID_FIR_SAL_PB
        // 
        this.ID_FIR_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_FIR_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_FIR_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_FIR_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_FIR_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_FIR_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_FIR_SAL_PB.Location = new System.Drawing.Point(236, 178);
        this.ID_FIR_SAL_PB.Name = "ID_FIR_SAL_PB";
        this.ID_FIR_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_FIR_SAL_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_FIR_SAL_PB.TabIndex = 2;
        this.ID_FIR_SAL_PB.Tag = "";
        this.ID_FIR_SAL_PB.Text = "Salir";
        this.ID_FIR_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_FIR_SAL_PB.Click += new System.EventHandler(this.ID_FIR_SAL_PB_Click);
        // 
        // _ID_CFI_ETI_PNL_0
        // 
        this._ID_CFI_ETI_PNL_0.Controls.Add(this._ID_CFI_ETI_PNL_0Label_Text);
        this._ID_CFI_ETI_PNL_0.Location = new System.Drawing.Point(5, 5);
        this._ID_CFI_ETI_PNL_0.Name = "_ID_CFI_ETI_PNL_0";
        this._ID_CFI_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CFI_ETI_PNL_0.OcxState")));
        this._ID_CFI_ETI_PNL_0.Size = new System.Drawing.Size(173, 21);
        this._ID_CFI_ETI_PNL_0.TabIndex = 0;
        this._ID_CFI_ETI_PNL_0.Tag = "";
        // 
        // _ID_CFI_ETI_PNL_0Label_Text
        // 
        this._ID_CFI_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CFI_ETI_PNL_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CFI_ETI_PNL_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_CFI_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_CFI_ETI_PNL_0Label_Text.Name = "_ID_CFI_ETI_PNL_0Label_Text";
        this._ID_CFI_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(173, 21);
        this._ID_CFI_ETI_PNL_0Label_Text.TabIndex = 0;
        this._ID_CFI_ETI_PNL_0Label_Text.Tag = "";
        this._ID_CFI_ETI_PNL_0Label_Text.Text = "Representante 1";
        this._ID_CFI_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_FIR_FIR_PNL_0
        // 
        this._ID_FIR_FIR_PNL_0.Controls.Add(this.ID_FIR_FR1_IMM);
        this._ID_FIR_FIR_PNL_0.Location = new System.Drawing.Point(5, 27);
        this._ID_FIR_FIR_PNL_0.Name = "_ID_FIR_FIR_PNL_0";
        this._ID_FIR_FIR_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_FIR_FIR_PNL_0.OcxState")));
        this._ID_FIR_FIR_PNL_0.Size = new System.Drawing.Size(173, 113);
        this._ID_FIR_FIR_PNL_0.TabIndex = 1;
        this._ID_FIR_FIR_PNL_0.Tag = "";
        // 
        // ID_FIR_FR1_IMM
        // 
        this.ID_FIR_FR1_IMM.Enabled = true;
        this.ID_FIR_FR1_IMM.Location = new System.Drawing.Point(4, 4);
        this.ID_FIR_FR1_IMM.Name = "ID_FIR_FR1_IMM";
        this.ID_FIR_FR1_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_FR1_IMM.OcxState")));
        this.ID_FIR_FR1_IMM.Size = new System.Drawing.Size(164, 104);
        this.ID_FIR_FR1_IMM.TabIndex = 11;
        this.ID_FIR_FR1_IMM.Tag = "";
        // 
        // _ID_FIR_NOM_PNL_0
        // 
        this._ID_FIR_NOM_PNL_0.Location = new System.Drawing.Point(5, 140);
        this._ID_FIR_NOM_PNL_0.Name = "_ID_FIR_NOM_PNL_0";
        this._ID_FIR_NOM_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_FIR_NOM_PNL_0.OcxState")));
        this._ID_FIR_NOM_PNL_0.Size = new System.Drawing.Size(173, 25);
        this._ID_FIR_NOM_PNL_0.TabIndex = 3;
        this._ID_FIR_NOM_PNL_0.Tag = "";
        // 
        // _ID_CFI_ETI_PNL_1
        // 
        this._ID_CFI_ETI_PNL_1.Controls.Add(this._ID_CFI_ETI_PNL_1Label_Text);
        this._ID_CFI_ETI_PNL_1.Location = new System.Drawing.Point(187, 5);
        this._ID_CFI_ETI_PNL_1.Name = "_ID_CFI_ETI_PNL_1";
        this._ID_CFI_ETI_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CFI_ETI_PNL_1.OcxState")));
        this._ID_CFI_ETI_PNL_1.Size = new System.Drawing.Size(173, 21);
        this._ID_CFI_ETI_PNL_1.TabIndex = 5;
        this._ID_CFI_ETI_PNL_1.Tag = "";
        // 
        // _ID_CFI_ETI_PNL_1Label_Text
        // 
        this._ID_CFI_ETI_PNL_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CFI_ETI_PNL_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CFI_ETI_PNL_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_CFI_ETI_PNL_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_CFI_ETI_PNL_1Label_Text.Name = "_ID_CFI_ETI_PNL_1Label_Text";
        this._ID_CFI_ETI_PNL_1Label_Text.Size = new System.Drawing.Size(173, 21);
        this._ID_CFI_ETI_PNL_1Label_Text.TabIndex = 0;
        this._ID_CFI_ETI_PNL_1Label_Text.Tag = "";
        this._ID_CFI_ETI_PNL_1Label_Text.Text = "Representante 2";
        this._ID_CFI_ETI_PNL_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CFI_ETI_PNL_2
        // 
        this._ID_CFI_ETI_PNL_2.Controls.Add(this._ID_CFI_ETI_PNL_2Label_Text);
        this._ID_CFI_ETI_PNL_2.Location = new System.Drawing.Point(367, 5);
        this._ID_CFI_ETI_PNL_2.Name = "_ID_CFI_ETI_PNL_2";
        this._ID_CFI_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CFI_ETI_PNL_2.OcxState")));
        this._ID_CFI_ETI_PNL_2.Size = new System.Drawing.Size(173, 21);
        this._ID_CFI_ETI_PNL_2.TabIndex = 6;
        this._ID_CFI_ETI_PNL_2.Tag = "";
        // 
        // _ID_CFI_ETI_PNL_2Label_Text
        // 
        this._ID_CFI_ETI_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CFI_ETI_PNL_2Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CFI_ETI_PNL_2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_CFI_ETI_PNL_2Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_CFI_ETI_PNL_2Label_Text.Name = "_ID_CFI_ETI_PNL_2Label_Text";
        this._ID_CFI_ETI_PNL_2Label_Text.Size = new System.Drawing.Size(173, 21);
        this._ID_CFI_ETI_PNL_2Label_Text.TabIndex = 0;
        this._ID_CFI_ETI_PNL_2Label_Text.Tag = "";
        this._ID_CFI_ETI_PNL_2Label_Text.Text = "Representante 3";
        this._ID_CFI_ETI_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_FIR_FIR_PNL_1
        // 
        this._ID_FIR_FIR_PNL_1.Controls.Add(this.ID_FIR_FR2_IMM);
        this._ID_FIR_FIR_PNL_1.Location = new System.Drawing.Point(187, 27);
        this._ID_FIR_FIR_PNL_1.Name = "_ID_FIR_FIR_PNL_1";
        this._ID_FIR_FIR_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_FIR_FIR_PNL_1.OcxState")));
        this._ID_FIR_FIR_PNL_1.Size = new System.Drawing.Size(173, 113);
        this._ID_FIR_FIR_PNL_1.TabIndex = 7;
        this._ID_FIR_FIR_PNL_1.Tag = "";
        // 
        // ID_FIR_FR2_IMM
        // 
        this.ID_FIR_FR2_IMM.Enabled = true;
        this.ID_FIR_FR2_IMM.Location = new System.Drawing.Point(3, 4);
        this.ID_FIR_FR2_IMM.Name = "ID_FIR_FR2_IMM";
        this.ID_FIR_FR2_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_FR2_IMM.OcxState")));
        this.ID_FIR_FR2_IMM.Size = new System.Drawing.Size(165, 105);
        this.ID_FIR_FR2_IMM.TabIndex = 12;
        this.ID_FIR_FR2_IMM.Tag = "";
        // 
        // _ID_FIR_FIR_PNL_2
        // 
        this._ID_FIR_FIR_PNL_2.Controls.Add(this.ID_FIR_FR3_IMM);
        this._ID_FIR_FIR_PNL_2.Location = new System.Drawing.Point(368, 28);
        this._ID_FIR_FIR_PNL_2.Name = "_ID_FIR_FIR_PNL_2";
        this._ID_FIR_FIR_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_FIR_FIR_PNL_2.OcxState")));
        this._ID_FIR_FIR_PNL_2.Size = new System.Drawing.Size(173, 113);
        this._ID_FIR_FIR_PNL_2.TabIndex = 8;
        this._ID_FIR_FIR_PNL_2.Tag = "";
        // 
        // ID_FIR_FR3_IMM
        // 
        this.ID_FIR_FR3_IMM.Enabled = true;
        this.ID_FIR_FR3_IMM.Location = new System.Drawing.Point(3, 3);
        this.ID_FIR_FR3_IMM.Name = "ID_FIR_FR3_IMM";
        this.ID_FIR_FR3_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_FIR_FR3_IMM.OcxState")));
        this.ID_FIR_FR3_IMM.Size = new System.Drawing.Size(167, 106);
        this.ID_FIR_FR3_IMM.TabIndex = 13;
        this.ID_FIR_FR3_IMM.Tag = "";
        // 
        // _ID_FIR_NOM_PNL_1
        // 
        this._ID_FIR_NOM_PNL_1.Location = new System.Drawing.Point(187, 140);
        this._ID_FIR_NOM_PNL_1.Name = "_ID_FIR_NOM_PNL_1";
        this._ID_FIR_NOM_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_FIR_NOM_PNL_1.OcxState")));
        this._ID_FIR_NOM_PNL_1.Size = new System.Drawing.Size(173, 25);
        this._ID_FIR_NOM_PNL_1.TabIndex = 9;
        this._ID_FIR_NOM_PNL_1.Tag = "";
        // 
        // _ID_FIR_NOM_PNL_2
        // 
        this._ID_FIR_NOM_PNL_2.Location = new System.Drawing.Point(366, 140);
        this._ID_FIR_NOM_PNL_2.Name = "_ID_FIR_NOM_PNL_2";
        this._ID_FIR_NOM_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_FIR_NOM_PNL_2.OcxState")));
        this._ID_FIR_NOM_PNL_2.Size = new System.Drawing.Size(173, 25);
        this._ID_FIR_NOM_PNL_2.TabIndex = 10;
        this._ID_FIR_NOM_PNL_2.Tag = "";
        // 
        // CORCONFI
        // 
        this.AcceptButton = this.ID_FIR_IMP_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_FIR_SAL_PB;
        this.ClientSize = new System.Drawing.Size(546, 210);
        this.Controls.Add(this._ID_FIR_FIR_PNL_2);
        this.Controls.Add(this._ID_FIR_FIR_PNL_1);
        this.Controls.Add(this._ID_CFI_ETI_PNL_2);
        this.Controls.Add(this._ID_FIR_FIR_PNL_0);
        this.Controls.Add(this._ID_FIR_NOM_PNL_0);
        this.Controls.Add(this._ID_CFI_ETI_PNL_1);
        this.Controls.Add(this.ID_FIR_IMP_PB);
        this.Controls.Add(this.ID_FIR_SAL_PB);
        this.Controls.Add(this._ID_CFI_ETI_PNL_0);
        this.Controls.Add(this._ID_FIR_NOM_PNL_1);
        this.Controls.Add(this._ID_FIR_NOM_PNL_2);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.Location = new System.Drawing.Point(190, 249);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCONFI";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Firmas";
        this.Closed += new System.EventHandler(this.CORCONFI_Closed);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CFI_ETI_PNL_0)).EndInit();
        this._ID_CFI_ETI_PNL_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_FIR_PNL_0)).EndInit();
        this._ID_FIR_FIR_PNL_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR1_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_NOM_PNL_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CFI_ETI_PNL_1)).EndInit();
        this._ID_CFI_ETI_PNL_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CFI_ETI_PNL_2)).EndInit();
        this._ID_CFI_ETI_PNL_2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_FIR_PNL_1)).EndInit();
        this._ID_FIR_FIR_PNL_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR2_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_FIR_PNL_2)).EndInit();
        this._ID_FIR_FIR_PNL_2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_FIR_FR3_IMM)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_NOM_PNL_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_FIR_NOM_PNL_2)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_FIR_FIR_PNL()
	{
			this.ID_FIR_FIR_PNL[0] = _ID_FIR_FIR_PNL_0;
			this.ID_FIR_FIR_PNL[1] = _ID_FIR_FIR_PNL_1;
			this.ID_FIR_FIR_PNL[2] = _ID_FIR_FIR_PNL_2;
	}
	void  InitializeID_CFI_ETI_PNL()
	{
			this.ID_CFI_ETI_PNL[0] = _ID_CFI_ETI_PNL_0;
			this.ID_CFI_ETI_PNL[1] = _ID_CFI_ETI_PNL_1;
			this.ID_CFI_ETI_PNL[2] = _ID_CFI_ETI_PNL_2;
	}
	void  InitializeID_FIR_NOM_PNL()
	{
			this.ID_FIR_NOM_PNL[0] = _ID_FIR_NOM_PNL_0;
			this.ID_FIR_NOM_PNL[1] = _ID_FIR_NOM_PNL_1;
			this.ID_FIR_NOM_PNL[2] = _ID_FIR_NOM_PNL_2;
	}
#endregion 
}
}