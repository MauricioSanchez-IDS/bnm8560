using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frm_reportes
	{
	
#region "Upgrade Support "
		private static frm_reportes m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_reportes DefInstance
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
		public frm_reportes():base(){
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
			InitializeCMB_REPO();
			InitializelblEtiqueta();
			InitializemkbMaskebox_Rep();
			InitializeLST_REPO();
			InitializeFRAM_REP();
			InitializetxtTexto_Rep();
			InitializefrmFrame();
			InitializePAN_REP();
		}
	public static frm_reportes CreateInstance()
	{
			frm_reportes theInstance = new frm_reportes();
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
	private  System.Windows.Forms.TextBox _txtTexto_Rep_2;
	public  System.Windows.Forms.GroupBox Frame1;
	public  System.Windows.Forms.Button ID_MEE_ALT_PB;
	public  System.Windows.Forms.Button ID_MEE_CER_PB;
	private  System.Windows.Forms.ListBox _LST_REPO_0;
	private  System.Windows.Forms.ComboBox _CMB_REPO_1;
	private  System.Windows.Forms.ComboBox _CMB_REPO_2;
	private  System.Windows.Forms.ComboBox _CMB_REPO_3;
	private  System.Windows.Forms.ComboBox _CMB_REPO_0;
	public  System.Windows.Forms.CheckBox CHK_REP;
	public  System.Windows.Forms.Button CMD_ACT_REP;
	private  System.Windows.Forms.Label _lblEtiqueta_24;
	private  System.Windows.Forms.Label _lblEtiqueta_25;
	private  System.Windows.Forms.Label _lblEtiqueta_26;
	private  System.Windows.Forms.Label _lblEtiqueta_23;
	private  System.Windows.Forms.Label _lblEtiqueta_34;
	private  AxThreed.AxSSFrame _FRAM_REP_0;
	private  System.Windows.Forms.Label _PAN_REP_0Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_0;
	private  System.Windows.Forms.TextBox _txtTexto_Rep_1;
	private  System.Windows.Forms.TextBox _txtTexto_Rep_0;
	private  System.Windows.Forms.Label _lblEtiqueta_21;
	private  System.Windows.Forms.Label _lblEtiqueta_27;
	private  AxThreed.AxSSFrame _frmFrame_2;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Rep_0;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Rep_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Rep_2;
	private  System.Windows.Forms.Label _lblEtiqueta_38;
	private  System.Windows.Forms.Label _lblEtiqueta_40;
	private  System.Windows.Forms.Label _lblEtiqueta_22;
	private  AxThreed.AxSSFrame _frmFrame_3;
	private  System.Windows.Forms.Label _PAN_REP_1Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_1;
	private  System.Windows.Forms.Label _PAN_REP_2Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_2;
	private  System.Windows.Forms.Label _PAN_REP_3Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_3;
	private  System.Windows.Forms.Label _PAN_REP_4Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_4;
	private  System.Windows.Forms.Label _PAN_REP_8Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_8;
	private  System.Windows.Forms.Label _PAN_REP_5Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_5;
	public  AxThreed.AxSSPanel SSPanel1;
	public System.Windows.Forms.ComboBox[] CMB_REPO = new System.Windows.Forms.ComboBox[4];
	public AxThreed.AxSSFrame[] FRAM_REP = new AxThreed.AxSSFrame[1];
	public System.Windows.Forms.ListBox[] LST_REPO = new System.Windows.Forms.ListBox[1];
	public AxThreed.AxSSPanel[] PAN_REP = new AxThreed.AxSSPanel[9];
	public AxThreed.AxSSFrame[] frmFrame = new AxThreed.AxSSFrame[4];
	public System.Windows.Forms.Label[] lblEtiqueta = new System.Windows.Forms.Label[41];
	public AxMSMask.AxMaskEdBox[] mkbMaskebox_Rep = new AxMSMask.AxMaskEdBox[3];
	public System.Windows.Forms.TextBox[] txtTexto_Rep = new System.Windows.Forms.TextBox[3];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_reportes));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.SSPanel1 = new AxThreed.AxSSPanel();
        this._frmFrame_3 = new AxThreed.AxSSFrame();
        this._mkbMaskebox_Rep_2 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_Rep_1 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_Rep_0 = new AxMSMask.AxMaskEdBox();
        this._lblEtiqueta_38 = new System.Windows.Forms.Label();
        this._lblEtiqueta_22 = new System.Windows.Forms.Label();
        this._lblEtiqueta_40 = new System.Windows.Forms.Label();
        this._PAN_REP_1 = new AxThreed.AxSSPanel();
        this._PAN_REP_1Label_Text = new System.Windows.Forms.Label();
        this._frmFrame_2 = new AxThreed.AxSSFrame();
        this._txtTexto_Rep_0 = new System.Windows.Forms.TextBox();
        this._txtTexto_Rep_1 = new System.Windows.Forms.TextBox();
        this._lblEtiqueta_27 = new System.Windows.Forms.Label();
        this._lblEtiqueta_21 = new System.Windows.Forms.Label();
        this._FRAM_REP_0 = new AxThreed.AxSSFrame();
        this.CHK_REP = new System.Windows.Forms.CheckBox();
        this.CMD_ACT_REP = new System.Windows.Forms.Button();
        this._CMB_REPO_3 = new System.Windows.Forms.ComboBox();
        this._CMB_REPO_0 = new System.Windows.Forms.ComboBox();
        this._lblEtiqueta_24 = new System.Windows.Forms.Label();
        this._lblEtiqueta_23 = new System.Windows.Forms.Label();
        this._lblEtiqueta_34 = new System.Windows.Forms.Label();
        this._lblEtiqueta_25 = new System.Windows.Forms.Label();
        this._lblEtiqueta_26 = new System.Windows.Forms.Label();
        this._CMB_REPO_1 = new System.Windows.Forms.ComboBox();
        this._CMB_REPO_2 = new System.Windows.Forms.ComboBox();
        this._PAN_REP_0 = new AxThreed.AxSSPanel();
        this._PAN_REP_0Label_Text = new System.Windows.Forms.Label();
        this._PAN_REP_8 = new AxThreed.AxSSPanel();
        this._PAN_REP_8Label_Text = new System.Windows.Forms.Label();
        this._PAN_REP_5 = new AxThreed.AxSSPanel();
        this._PAN_REP_5Label_Text = new System.Windows.Forms.Label();
        this._PAN_REP_4 = new AxThreed.AxSSPanel();
        this._PAN_REP_4Label_Text = new System.Windows.Forms.Label();
        this._PAN_REP_2 = new AxThreed.AxSSPanel();
        this._PAN_REP_2Label_Text = new System.Windows.Forms.Label();
        this._PAN_REP_3 = new AxThreed.AxSSPanel();
        this._PAN_REP_3Label_Text = new System.Windows.Forms.Label();
        this.ID_MEE_ALT_PB = new System.Windows.Forms.Button();
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this._txtTexto_Rep_2 = new System.Windows.Forms.TextBox();
        this._LST_REPO_0 = new System.Windows.Forms.ListBox();
        this.ID_MEE_CER_PB = new System.Windows.Forms.Button();
        this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).BeginInit();
        this.SSPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_3)).BeginInit();
        this._frmFrame_3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_1)).BeginInit();
        this._PAN_REP_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_2)).BeginInit();
        this._frmFrame_2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._FRAM_REP_0)).BeginInit();
        this._FRAM_REP_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_0)).BeginInit();
        this._PAN_REP_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_8)).BeginInit();
        this._PAN_REP_8.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_5)).BeginInit();
        this._PAN_REP_5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_4)).BeginInit();
        this._PAN_REP_4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_2)).BeginInit();
        this._PAN_REP_2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_3)).BeginInit();
        this._PAN_REP_3.SuspendLayout();
        this.Frame1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
        this.SuspendLayout();
        // 
        // SSPanel1
        // 
        this.SSPanel1.Controls.Add(this._frmFrame_3);
        this.SSPanel1.Controls.Add(this._PAN_REP_1);
        this.SSPanel1.Controls.Add(this._frmFrame_2);
        this.SSPanel1.Controls.Add(this._FRAM_REP_0);
        this.SSPanel1.Controls.Add(this._PAN_REP_0);
        this.SSPanel1.Controls.Add(this._PAN_REP_8);
        this.SSPanel1.Controls.Add(this._PAN_REP_5);
        this.SSPanel1.Controls.Add(this._PAN_REP_4);
        this.SSPanel1.Controls.Add(this._PAN_REP_2);
        this.SSPanel1.Controls.Add(this._PAN_REP_3);
        this.SSPanel1.Controls.Add(this.ID_MEE_ALT_PB);
        this.SSPanel1.Controls.Add(this.Frame1);
        this.SSPanel1.Controls.Add(this._LST_REPO_0);
        this.SSPanel1.Controls.Add(this.ID_MEE_CER_PB);
        this.SSPanel1.Location = new System.Drawing.Point(2, 0);
        this.SSPanel1.Name = "SSPanel1";
        this.SSPanel1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel1.OcxState")));
        this.SSPanel1.Size = new System.Drawing.Size(566, 510);
        this.SSPanel1.TabIndex = 2;
        this.SSPanel1.Tag = "";
        // 
        // _frmFrame_3
        // 
        this._frmFrame_3.Controls.Add(this._mkbMaskebox_Rep_2);
        this._frmFrame_3.Controls.Add(this._mkbMaskebox_Rep_1);
        this._frmFrame_3.Controls.Add(this._mkbMaskebox_Rep_0);
        this._frmFrame_3.Controls.Add(this._lblEtiqueta_38);
        this._frmFrame_3.Controls.Add(this._lblEtiqueta_22);
        this._frmFrame_3.Controls.Add(this._lblEtiqueta_40);
        this._frmFrame_3.Location = new System.Drawing.Point(8, 104);
        this._frmFrame_3.Name = "_frmFrame_3";
        this._frmFrame_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_3.OcxState")));
        this._frmFrame_3.Size = new System.Drawing.Size(550, 46);
        this._frmFrame_3.TabIndex = 22;
        this._frmFrame_3.Tag = "";
        // 
        // _mkbMaskebox_Rep_2
        // 
        this._mkbMaskebox_Rep_2.Location = new System.Drawing.Point(495, 18);
        this._mkbMaskebox_Rep_2.Name = "_mkbMaskebox_Rep_2";
        this._mkbMaskebox_Rep_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Rep_2.OcxState")));
        this._mkbMaskebox_Rep_2.Size = new System.Drawing.Size(41, 21);
        this._mkbMaskebox_Rep_2.TabIndex = 25;
        this._mkbMaskebox_Rep_2.Tag = "";
        // 
        // _mkbMaskebox_Rep_1
        // 
        this._mkbMaskebox_Rep_1.Location = new System.Drawing.Point(189, 18);
        this._mkbMaskebox_Rep_1.Name = "_mkbMaskebox_Rep_1";
        this._mkbMaskebox_Rep_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Rep_1.OcxState")));
        this._mkbMaskebox_Rep_1.Size = new System.Drawing.Size(269, 21);
        this._mkbMaskebox_Rep_1.TabIndex = 24;
        this._mkbMaskebox_Rep_1.Tag = "";
        // 
        // _mkbMaskebox_Rep_0
        // 
        this._mkbMaskebox_Rep_0.Location = new System.Drawing.Point(47, 18);
        this._mkbMaskebox_Rep_0.Name = "_mkbMaskebox_Rep_0";
        this._mkbMaskebox_Rep_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Rep_0.OcxState")));
        this._mkbMaskebox_Rep_0.Size = new System.Drawing.Size(93, 21);
        this._mkbMaskebox_Rep_0.TabIndex = 23;
        this._mkbMaskebox_Rep_0.Tag = "";
        // 
        // _lblEtiqueta_38
        // 
        this._lblEtiqueta_38.AutoSize = true;
        this._lblEtiqueta_38.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_38.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_38.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_38.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_38.Location = new System.Drawing.Point(144, 22);
        this._lblEtiqueta_38.Name = "_lblEtiqueta_38";
        this._lblEtiqueta_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_38.Size = new System.Drawing.Size(44, 13);
        this._lblEtiqueta_38.TabIndex = 28;
        this._lblEtiqueta_38.Tag = "";
        this._lblEtiqueta_38.Text = "Nombre";
        // 
        // _lblEtiqueta_22
        // 
        this._lblEtiqueta_22.AutoSize = true;
        this._lblEtiqueta_22.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_22.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_22.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_22.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_22.Location = new System.Drawing.Point(461, 22);
        this._lblEtiqueta_22.Name = "_lblEtiqueta_22";
        this._lblEtiqueta_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_22.Size = new System.Drawing.Size(31, 13);
        this._lblEtiqueta_22.TabIndex = 26;
        this._lblEtiqueta_22.Tag = "";
        this._lblEtiqueta_22.Text = "Nivel";
        // 
        // _lblEtiqueta_40
        // 
        this._lblEtiqueta_40.AutoSize = true;
        this._lblEtiqueta_40.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_40.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_40.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_40.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_40.Location = new System.Drawing.Point(4, 20);
        this._lblEtiqueta_40.Name = "_lblEtiqueta_40";
        this._lblEtiqueta_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_40.Size = new System.Drawing.Size(41, 13);
        this._lblEtiqueta_40.TabIndex = 27;
        this._lblEtiqueta_40.Tag = "";
        this._lblEtiqueta_40.Text = "Unidad";
        // 
        // _PAN_REP_1
        // 
        this._PAN_REP_1.Controls.Add(this._PAN_REP_1Label_Text);
        this._PAN_REP_1.Location = new System.Drawing.Point(352, 257);
        this._PAN_REP_1.Name = "_PAN_REP_1";
        this._PAN_REP_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_1.OcxState")));
        this._PAN_REP_1.Size = new System.Drawing.Size(74, 20);
        this._PAN_REP_1.TabIndex = 29;
        this._PAN_REP_1.Tag = "";
        this._PAN_REP_1.Visible = false;
        // 
        // _PAN_REP_1Label_Text
        // 
        this._PAN_REP_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_1Label_Text.Name = "_PAN_REP_1Label_Text";
        this._PAN_REP_1Label_Text.Size = new System.Drawing.Size(74, 20);
        this._PAN_REP_1Label_Text.TabIndex = 0;
        this._PAN_REP_1Label_Text.Tag = "";
        this._PAN_REP_1Label_Text.Text = "Frecuencia";
        this._PAN_REP_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _frmFrame_2
        // 
        this._frmFrame_2.Controls.Add(this._txtTexto_Rep_0);
        this._frmFrame_2.Controls.Add(this._txtTexto_Rep_1);
        this._frmFrame_2.Controls.Add(this._lblEtiqueta_27);
        this._frmFrame_2.Controls.Add(this._lblEtiqueta_21);
        this._frmFrame_2.Location = new System.Drawing.Point(8, 56);
        this._frmFrame_2.Name = "_frmFrame_2";
        this._frmFrame_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_2.OcxState")));
        this._frmFrame_2.Size = new System.Drawing.Size(550, 47);
        this._frmFrame_2.TabIndex = 17;
        this._frmFrame_2.Tag = "";
        // 
        // _txtTexto_Rep_0
        // 
        this._txtTexto_Rep_0.AcceptsReturn = true;
        this._txtTexto_Rep_0.BackColor = System.Drawing.Color.White;
        this._txtTexto_Rep_0.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_Rep_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_Rep_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_Rep_0.Location = new System.Drawing.Point(59, 17);
        this._txtTexto_Rep_0.MaxLength = 45;
        this._txtTexto_Rep_0.Name = "_txtTexto_Rep_0";
        this._txtTexto_Rep_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_Rep_0.Size = new System.Drawing.Size(317, 20);
        this._txtTexto_Rep_0.TabIndex = 18;
        this._txtTexto_Rep_0.TabStop = false;
        this._txtTexto_Rep_0.Tag = "";
        // 
        // _txtTexto_Rep_1
        // 
        this._txtTexto_Rep_1.AcceptsReturn = true;
        this._txtTexto_Rep_1.BackColor = System.Drawing.Color.White;
        this._txtTexto_Rep_1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_Rep_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_Rep_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_Rep_1.Location = new System.Drawing.Point(430, 17);
        this._txtTexto_Rep_1.MaxLength = 45;
        this._txtTexto_Rep_1.Name = "_txtTexto_Rep_1";
        this._txtTexto_Rep_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_Rep_1.Size = new System.Drawing.Size(107, 20);
        this._txtTexto_Rep_1.TabIndex = 19;
        this._txtTexto_Rep_1.TabStop = false;
        this._txtTexto_Rep_1.Tag = "";
        // 
        // _lblEtiqueta_27
        // 
        this._lblEtiqueta_27.AutoSize = true;
        this._lblEtiqueta_27.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_27.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_27.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_27.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_27.Location = new System.Drawing.Point(385, 21);
        this._lblEtiqueta_27.Name = "_lblEtiqueta_27";
        this._lblEtiqueta_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_27.Size = new System.Drawing.Size(44, 13);
        this._lblEtiqueta_27.TabIndex = 20;
        this._lblEtiqueta_27.Tag = "";
        this._lblEtiqueta_27.Text = "Número";
        // 
        // _lblEtiqueta_21
        // 
        this._lblEtiqueta_21.AutoSize = true;
        this._lblEtiqueta_21.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_21.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_21.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_21.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_21.Location = new System.Drawing.Point(8, 24);
        this._lblEtiqueta_21.Name = "_lblEtiqueta_21";
        this._lblEtiqueta_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_21.Size = new System.Drawing.Size(44, 13);
        this._lblEtiqueta_21.TabIndex = 21;
        this._lblEtiqueta_21.Tag = "";
        this._lblEtiqueta_21.Text = "Nombre";
        // 
        // _FRAM_REP_0
        // 
        this._FRAM_REP_0.Controls.Add(this.CHK_REP);
        this._FRAM_REP_0.Controls.Add(this.CMD_ACT_REP);
        this._FRAM_REP_0.Controls.Add(this._CMB_REPO_3);
        this._FRAM_REP_0.Controls.Add(this._CMB_REPO_0);
        this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_24);
        this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_23);
        this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_34);
        this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_25);
        this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_26);
        this._FRAM_REP_0.Controls.Add(this._CMB_REPO_1);
        this._FRAM_REP_0.Controls.Add(this._CMB_REPO_2);
        this._FRAM_REP_0.Location = new System.Drawing.Point(14, 203);
        this._FRAM_REP_0.Name = "_FRAM_REP_0";
        this._FRAM_REP_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_FRAM_REP_0.OcxState")));
        this._FRAM_REP_0.Size = new System.Drawing.Size(534, 81);
        this._FRAM_REP_0.TabIndex = 3;
        this._FRAM_REP_0.Tag = "";
        this._FRAM_REP_0.Visible = false;
        // 
        // CHK_REP
        // 
        this.CHK_REP.BackColor = System.Drawing.SystemColors.Control;
        this.CHK_REP.Cursor = System.Windows.Forms.Cursors.Default;
        this.CHK_REP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CHK_REP.ForeColor = System.Drawing.SystemColors.ControlText;
        this.CHK_REP.Location = new System.Drawing.Point(410, 40);
        this.CHK_REP.Name = "CHK_REP";
        this.CHK_REP.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CHK_REP.Size = new System.Drawing.Size(15, 15);
        this.CHK_REP.TabIndex = 5;
        this.CHK_REP.Tag = "";
        this.CHK_REP.UseVisualStyleBackColor = false;
        this.CHK_REP.CheckStateChanged += new System.EventHandler(this.CHK_REP_CheckStateChanged);
        // 
        // CMD_ACT_REP
        // 
        this.CMD_ACT_REP.BackColor = System.Drawing.SystemColors.Control;
        this.CMD_ACT_REP.Cursor = System.Windows.Forms.Cursors.Default;
        this.CMD_ACT_REP.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.CMD_ACT_REP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CMD_ACT_REP.ForeColor = System.Drawing.SystemColors.ControlText;
        this.CMD_ACT_REP.Location = new System.Drawing.Point(463, 36);
        this.CMD_ACT_REP.Name = "CMD_ACT_REP";
        this.CMD_ACT_REP.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CMD_ACT_REP.Size = new System.Drawing.Size(64, 20);
        this.CMD_ACT_REP.TabIndex = 4;
        this.CMD_ACT_REP.Tag = "";
        this.CMD_ACT_REP.Text = "&Actualizar";
        this.CMD_ACT_REP.UseVisualStyleBackColor = false;
        this.CMD_ACT_REP.Click += new System.EventHandler(this.CMD_ACT_REP_Click);
        // 
        // _CMB_REPO_3
        // 
        this._CMB_REPO_3.BackColor = System.Drawing.SystemColors.Window;
        this._CMB_REPO_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._CMB_REPO_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this._CMB_REPO_3.Enabled = false;
        this._CMB_REPO_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._CMB_REPO_3.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this._CMB_REPO_3, new int[] {
            1,
            2,
            3});
        this._CMB_REPO_3.Items.AddRange(new object[] {
            "Unit",
            "Card",
            "Transaction"});
        this._CMB_REPO_3.Location = new System.Drawing.Point(216, 174);
        this._CMB_REPO_3.Name = "_CMB_REPO_3";
        this._CMB_REPO_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._CMB_REPO_3.Size = new System.Drawing.Size(83, 21);
        this._CMB_REPO_3.TabIndex = 7;
        this._CMB_REPO_3.Tag = "";
        this._CMB_REPO_3.Visible = false;
        this._CMB_REPO_3.SelectedIndexChanged += new System.EventHandler(this.CMB_REPO_SelectedIndexChanged);
        // 
        // _CMB_REPO_0
        // 
        this._CMB_REPO_0.BackColor = System.Drawing.SystemColors.Window;
        this._CMB_REPO_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._CMB_REPO_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this._CMB_REPO_0.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._CMB_REPO_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this._CMB_REPO_0, new int[0]);
        this._CMB_REPO_0.Location = new System.Drawing.Point(10, 35);
        this._CMB_REPO_0.Name = "_CMB_REPO_0";
        this._CMB_REPO_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._CMB_REPO_0.Size = new System.Drawing.Size(369, 22);
        this._CMB_REPO_0.TabIndex = 6;
        this._CMB_REPO_0.Tag = "";
        this._CMB_REPO_0.SelectedIndexChanged += new System.EventHandler(this.CMB_REPO_SelectedIndexChanged);
        // 
        // _lblEtiqueta_24
        // 
        this._lblEtiqueta_24.AutoSize = true;
        this._lblEtiqueta_24.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_24.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_24.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_24.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_24.Location = new System.Drawing.Point(29, 159);
        this._lblEtiqueta_24.Name = "_lblEtiqueta_24";
        this._lblEtiqueta_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_24.Size = new System.Drawing.Size(60, 13);
        this._lblEtiqueta_24.TabIndex = 14;
        this._lblEtiqueta_24.Tag = "";
        this._lblEtiqueta_24.Text = "Frecuencia";
        this._lblEtiqueta_24.Visible = false;
        // 
        // _lblEtiqueta_23
        // 
        this._lblEtiqueta_23.AutoSize = true;
        this._lblEtiqueta_23.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_23.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_23.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_23.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_23.Location = new System.Drawing.Point(11, 19);
        this._lblEtiqueta_23.Name = "_lblEtiqueta_23";
        this._lblEtiqueta_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_23.Size = new System.Drawing.Size(85, 13);
        this._lblEtiqueta_23.TabIndex = 11;
        this._lblEtiqueta_23.Tag = "";
        this._lblEtiqueta_23.Text = "Nombre Reporte";
        // 
        // _lblEtiqueta_34
        // 
        this._lblEtiqueta_34.AutoSize = true;
        this._lblEtiqueta_34.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_34.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_34.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_34.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_34.Location = new System.Drawing.Point(398, 19);
        this._lblEtiqueta_34.Name = "_lblEtiqueta_34";
        this._lblEtiqueta_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_34.Size = new System.Drawing.Size(45, 13);
        this._lblEtiqueta_34.TabIndex = 10;
        this._lblEtiqueta_34.Tag = "";
        this._lblEtiqueta_34.Text = "Generar";
        // 
        // _lblEtiqueta_25
        // 
        this._lblEtiqueta_25.AutoSize = true;
        this._lblEtiqueta_25.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_25.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_25.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_25.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_25.Location = new System.Drawing.Point(143, 160);
        this._lblEtiqueta_25.Name = "_lblEtiqueta_25";
        this._lblEtiqueta_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_25.Size = new System.Drawing.Size(40, 13);
        this._lblEtiqueta_25.TabIndex = 13;
        this._lblEtiqueta_25.Tag = "";
        this._lblEtiqueta_25.Text = "Detalle";
        this._lblEtiqueta_25.Visible = false;
        // 
        // _lblEtiqueta_26
        // 
        this._lblEtiqueta_26.AutoSize = true;
        this._lblEtiqueta_26.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_26.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_26.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_26.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_26.Location = new System.Drawing.Point(227, 160);
        this._lblEtiqueta_26.Name = "_lblEtiqueta_26";
        this._lblEtiqueta_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_26.Size = new System.Drawing.Size(64, 13);
        this._lblEtiqueta_26.TabIndex = 12;
        this._lblEtiqueta_26.Tag = "";
        this._lblEtiqueta_26.Text = "Profundidad";
        this._lblEtiqueta_26.Visible = false;
        // 
        // _CMB_REPO_1
        // 
        this._CMB_REPO_1.BackColor = System.Drawing.SystemColors.Window;
        this._CMB_REPO_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._CMB_REPO_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this._CMB_REPO_1.Enabled = false;
        this._CMB_REPO_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._CMB_REPO_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this._CMB_REPO_1, new int[] {
            1,
            2,
            3,
            4,
            5,
            6,
            7});
        this._CMB_REPO_1.Items.AddRange(new object[] {
            "Quarterly",
            "Monthly",
            "Fiscal Quarterly",
            "Annual",
            "Cyclic",
            "Fiscal Annual",
            "Daily"});
        this._CMB_REPO_1.Location = new System.Drawing.Point(8, 174);
        this._CMB_REPO_1.Name = "_CMB_REPO_1";
        this._CMB_REPO_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._CMB_REPO_1.Size = new System.Drawing.Size(108, 21);
        this._CMB_REPO_1.TabIndex = 9;
        this._CMB_REPO_1.Tag = "";
        this._CMB_REPO_1.Visible = false;
        this._CMB_REPO_1.SelectedIndexChanged += new System.EventHandler(this.CMB_REPO_SelectedIndexChanged);
        // 
        // _CMB_REPO_2
        // 
        this._CMB_REPO_2.BackColor = System.Drawing.SystemColors.Window;
        this._CMB_REPO_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._CMB_REPO_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this._CMB_REPO_2.Enabled = false;
        this._CMB_REPO_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._CMB_REPO_2.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this._CMB_REPO_2, new int[] {
            1,
            2,
            3});
        this._CMB_REPO_2.Items.AddRange(new object[] {
            "Summary",
            "Detail",
            "Transaction"});
        this._CMB_REPO_2.Location = new System.Drawing.Point(118, 174);
        this._CMB_REPO_2.Name = "_CMB_REPO_2";
        this._CMB_REPO_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._CMB_REPO_2.Size = new System.Drawing.Size(96, 21);
        this._CMB_REPO_2.TabIndex = 8;
        this._CMB_REPO_2.Tag = "";
        this._CMB_REPO_2.Visible = false;
        this._CMB_REPO_2.SelectedIndexChanged += new System.EventHandler(this.CMB_REPO_SelectedIndexChanged);
        // 
        // _PAN_REP_0
        // 
        this._PAN_REP_0.Controls.Add(this._PAN_REP_0Label_Text);
        this._PAN_REP_0.Location = new System.Drawing.Point(32, 153);
        this._PAN_REP_0.Name = "_PAN_REP_0";
        this._PAN_REP_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_0.OcxState")));
        this._PAN_REP_0.Size = new System.Drawing.Size(266, 20);
        this._PAN_REP_0.TabIndex = 16;
        this._PAN_REP_0.Tag = "";
        // 
        // _PAN_REP_0Label_Text
        // 
        this._PAN_REP_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._PAN_REP_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_0Label_Text.Name = "_PAN_REP_0Label_Text";
        this._PAN_REP_0Label_Text.Size = new System.Drawing.Size(266, 20);
        this._PAN_REP_0Label_Text.TabIndex = 0;
        this._PAN_REP_0Label_Text.Tag = "";
        this._PAN_REP_0Label_Text.Text = "Nombre Reporte";
        this._PAN_REP_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _PAN_REP_8
        // 
        this._PAN_REP_8.Controls.Add(this._PAN_REP_8Label_Text);
        this._PAN_REP_8.Location = new System.Drawing.Point(474, 153);
        this._PAN_REP_8.Name = "_PAN_REP_8";
        this._PAN_REP_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_8.OcxState")));
        this._PAN_REP_8.Size = new System.Drawing.Size(62, 20);
        this._PAN_REP_8.TabIndex = 33;
        this._PAN_REP_8.Tag = "";
        // 
        // _PAN_REP_8Label_Text
        // 
        this._PAN_REP_8Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_8Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._PAN_REP_8Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_8Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_8Label_Text.Name = "_PAN_REP_8Label_Text";
        this._PAN_REP_8Label_Text.Size = new System.Drawing.Size(62, 20);
        this._PAN_REP_8Label_Text.TabIndex = 0;
        this._PAN_REP_8Label_Text.Tag = "";
        this._PAN_REP_8Label_Text.Text = "Generar";
        this._PAN_REP_8Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _PAN_REP_5
        // 
        this._PAN_REP_5.Controls.Add(this._PAN_REP_5Label_Text);
        this._PAN_REP_5.Location = new System.Drawing.Point(298, 153);
        this._PAN_REP_5.Name = "_PAN_REP_5";
        this._PAN_REP_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_5.OcxState")));
        this._PAN_REP_5.Size = new System.Drawing.Size(176, 20);
        this._PAN_REP_5.TabIndex = 36;
        this._PAN_REP_5.Tag = "";
        // 
        // _PAN_REP_5Label_Text
        // 
        this._PAN_REP_5Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_5Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._PAN_REP_5Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_5Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_5Label_Text.Name = "_PAN_REP_5Label_Text";
        this._PAN_REP_5Label_Text.Size = new System.Drawing.Size(176, 20);
        this._PAN_REP_5Label_Text.TabIndex = 0;
        this._PAN_REP_5Label_Text.Tag = "";
        this._PAN_REP_5Label_Text.Text = "Frecuencia";
        this._PAN_REP_5Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _PAN_REP_4
        // 
        this._PAN_REP_4.Controls.Add(this._PAN_REP_4Label_Text);
        this._PAN_REP_4.Location = new System.Drawing.Point(7, 153);
        this._PAN_REP_4.Name = "_PAN_REP_4";
        this._PAN_REP_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_4.OcxState")));
        this._PAN_REP_4.Size = new System.Drawing.Size(25, 20);
        this._PAN_REP_4.TabIndex = 32;
        this._PAN_REP_4.Tag = "";
        // 
        // _PAN_REP_4Label_Text
        // 
        this._PAN_REP_4Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_4Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._PAN_REP_4Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_4Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_4Label_Text.Name = "_PAN_REP_4Label_Text";
        this._PAN_REP_4Label_Text.Size = new System.Drawing.Size(25, 20);
        this._PAN_REP_4Label_Text.TabIndex = 0;
        this._PAN_REP_4Label_Text.Tag = "";
        this._PAN_REP_4Label_Text.Text = "ID";
        this._PAN_REP_4Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _PAN_REP_2
        // 
        this._PAN_REP_2.Controls.Add(this._PAN_REP_2Label_Text);
        this._PAN_REP_2.Location = new System.Drawing.Point(426, 257);
        this._PAN_REP_2.Name = "_PAN_REP_2";
        this._PAN_REP_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_2.OcxState")));
        this._PAN_REP_2.Size = new System.Drawing.Size(52, 20);
        this._PAN_REP_2.TabIndex = 30;
        this._PAN_REP_2.Tag = "";
        this._PAN_REP_2.Visible = false;
        // 
        // _PAN_REP_2Label_Text
        // 
        this._PAN_REP_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_2Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_2Label_Text.Name = "_PAN_REP_2Label_Text";
        this._PAN_REP_2Label_Text.Size = new System.Drawing.Size(52, 20);
        this._PAN_REP_2Label_Text.TabIndex = 0;
        this._PAN_REP_2Label_Text.Tag = "";
        this._PAN_REP_2Label_Text.Text = "Detalle";
        this._PAN_REP_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _PAN_REP_3
        // 
        this._PAN_REP_3.Controls.Add(this._PAN_REP_3Label_Text);
        this._PAN_REP_3.Location = new System.Drawing.Point(478, 257);
        this._PAN_REP_3.Name = "_PAN_REP_3";
        this._PAN_REP_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_3.OcxState")));
        this._PAN_REP_3.Size = new System.Drawing.Size(77, 20);
        this._PAN_REP_3.TabIndex = 31;
        this._PAN_REP_3.Tag = "";
        this._PAN_REP_3.Visible = false;
        // 
        // _PAN_REP_3Label_Text
        // 
        this._PAN_REP_3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_3Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_3Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_3Label_Text.Name = "_PAN_REP_3Label_Text";
        this._PAN_REP_3Label_Text.Size = new System.Drawing.Size(77, 20);
        this._PAN_REP_3Label_Text.TabIndex = 0;
        this._PAN_REP_3Label_Text.Tag = "";
        this._PAN_REP_3Label_Text.Text = "Profundidad";
        this._PAN_REP_3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_MEE_ALT_PB
        // 
        this.ID_MEE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_MEE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEE_ALT_PB.Location = new System.Drawing.Point(187, 481);
        this.ID_MEE_ALT_PB.Name = "ID_MEE_ALT_PB";
        this.ID_MEE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEE_ALT_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_MEE_ALT_PB.TabIndex = 35;
        this.ID_MEE_ALT_PB.Tag = "";
        this.ID_MEE_ALT_PB.Text = "Aceptar";
        this.ID_MEE_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_MEE_ALT_PB.Click += new System.EventHandler(this.ID_MEE_ALT_PB_Click);
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this._txtTexto_Rep_2);
        this.Frame1.Enabled = false;
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(8, 0);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(553, 49);
        this.Frame1.TabIndex = 0;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Grupo";
        // 
        // _txtTexto_Rep_2
        // 
        this._txtTexto_Rep_2.AcceptsReturn = true;
        this._txtTexto_Rep_2.BackColor = System.Drawing.SystemColors.Window;
        this._txtTexto_Rep_2.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_Rep_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_Rep_2.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_Rep_2.Location = new System.Drawing.Point(16, 14);
        this._txtTexto_Rep_2.MaxLength = 0;
        this._txtTexto_Rep_2.Name = "_txtTexto_Rep_2";
        this._txtTexto_Rep_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_Rep_2.Size = new System.Drawing.Size(521, 20);
        this._txtTexto_Rep_2.TabIndex = 1;
        this._txtTexto_Rep_2.Tag = "";
        // 
        // _LST_REPO_0
        // 
        this._LST_REPO_0.BackColor = System.Drawing.SystemColors.Window;
        this._LST_REPO_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._LST_REPO_0.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._LST_REPO_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this._LST_REPO_0, new int[0]);
        this._LST_REPO_0.ItemHeight = 14;
        this._LST_REPO_0.Location = new System.Drawing.Point(8, 176);
        this._LST_REPO_0.Name = "_LST_REPO_0";
        this._LST_REPO_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._LST_REPO_0.Size = new System.Drawing.Size(548, 298);
        this._LST_REPO_0.TabIndex = 15;
        this._LST_REPO_0.Tag = "";
        this._LST_REPO_0.DoubleClick += new System.EventHandler(this.LST_REPO_DoubleClick);
        // 
        // ID_MEE_CER_PB
        // 
        this.ID_MEE_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_MEE_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEE_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEE_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEE_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEE_CER_PB.Location = new System.Drawing.Point(307, 481);
        this.ID_MEE_CER_PB.Name = "ID_MEE_CER_PB";
        this.ID_MEE_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEE_CER_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_MEE_CER_PB.TabIndex = 34;
        this.ID_MEE_CER_PB.Tag = "Cancela";
        this.ID_MEE_CER_PB.Text = "Cancelar";
        this.ID_MEE_CER_PB.UseVisualStyleBackColor = false;
        this.ID_MEE_CER_PB.Click += new System.EventHandler(this.ID_MEE_CER_PB_Click);
        // 
        // frm_reportes
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(568, 508);
        this.Controls.Add(this.SSPanel1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(439, 191);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frm_reportes";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Reportes";
        this.Closed += new System.EventHandler(this.frm_reportes_Closed);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_reportes_FormClosing);
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).EndInit();
        this.SSPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_3)).EndInit();
        this._frmFrame_3.ResumeLayout(false);
        this._frmFrame_3.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_1)).EndInit();
        this._PAN_REP_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_2)).EndInit();
        this._frmFrame_2.ResumeLayout(false);
        this._frmFrame_2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._FRAM_REP_0)).EndInit();
        this._FRAM_REP_0.ResumeLayout(false);
        this._FRAM_REP_0.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_0)).EndInit();
        this._PAN_REP_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_8)).EndInit();
        this._PAN_REP_8.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_5)).EndInit();
        this._PAN_REP_5.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_4)).EndInit();
        this._PAN_REP_4.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_2)).EndInit();
        this._PAN_REP_2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_3)).EndInit();
        this._PAN_REP_3.ResumeLayout(false);
        this.Frame1.ResumeLayout(false);
        this.Frame1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeCMB_REPO()
	{
			this.CMB_REPO[1] = _CMB_REPO_1;
			this.CMB_REPO[2] = _CMB_REPO_2;
			this.CMB_REPO[3] = _CMB_REPO_3;
			this.CMB_REPO[0] = _CMB_REPO_0;
	}
	void  InitializelblEtiqueta()
	{
			this.lblEtiqueta[24] = _lblEtiqueta_24;
			this.lblEtiqueta[25] = _lblEtiqueta_25;
			this.lblEtiqueta[26] = _lblEtiqueta_26;
			this.lblEtiqueta[23] = _lblEtiqueta_23;
			this.lblEtiqueta[34] = _lblEtiqueta_34;
			this.lblEtiqueta[21] = _lblEtiqueta_21;
			this.lblEtiqueta[27] = _lblEtiqueta_27;
			this.lblEtiqueta[38] = _lblEtiqueta_38;
			this.lblEtiqueta[40] = _lblEtiqueta_40;
			this.lblEtiqueta[22] = _lblEtiqueta_22;
	}
	void  InitializemkbMaskebox_Rep()
	{
			this.mkbMaskebox_Rep[0] = _mkbMaskebox_Rep_0;
			this.mkbMaskebox_Rep[1] = _mkbMaskebox_Rep_1;
			this.mkbMaskebox_Rep[2] = _mkbMaskebox_Rep_2;
	}
	void  InitializeLST_REPO()
	{
			this.LST_REPO[0] = _LST_REPO_0;
	}
	void  InitializeFRAM_REP()
	{
			this.FRAM_REP[0] = _FRAM_REP_0;
	}
	void  InitializetxtTexto_Rep()
	{
			this.txtTexto_Rep[2] = _txtTexto_Rep_2;
			this.txtTexto_Rep[1] = _txtTexto_Rep_1;
			this.txtTexto_Rep[0] = _txtTexto_Rep_0;
	}
	void  InitializefrmFrame()
	{
			this.frmFrame[2] = _frmFrame_2;
			this.frmFrame[3] = _frmFrame_3;
	}
	void  InitializePAN_REP()
	{
			this.PAN_REP[0] = _PAN_REP_0;
			this.PAN_REP[1] = _PAN_REP_1;
			this.PAN_REP[2] = _PAN_REP_2;
			this.PAN_REP[3] = _PAN_REP_3;
			this.PAN_REP[4] = _PAN_REP_4;
			this.PAN_REP[8] = _PAN_REP_8;
			this.PAN_REP[5] = _PAN_REP_5;
	}
#endregion 
}
}